/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CWIP_validate_terminate_lot.c
    Description : 

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Validate_Terminate_Lot()
            + Setup service interface function
        - CWIP_VALIDATE_TERMINATE_LOT()
            + Main sub function of EAPMES_Sample function
            + Setup service main business function
    Detail Description
        - CWIP_VALIDATE_TERMINATE_LOT()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019/08/06  sy7.kwon       desc 

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_Validate_Terminate_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Validate_Terminate_Lot(TRSNode *in_node, TRSNode *out_node)			// CUS_HQCUSM_service.h	/ CUSHQCUSMAddService.c 선언 추가
{	
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VALIDATE_TERMINATE_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VALIDATE_TERMINATE_LOT", out_node);

	// 결과가 성공일 경우 DB commit
    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
	// 결과가 실패일 경우 DB rollback
	else
    {
		DB_rollback();
	}
	
    return MP_TRUE;
}

/*******************************************************************************
    CWIP_VALIDATE_TERMINATE_LOT()
        - Main sub function of "CWIP_Validate_Terminate_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VALIDATE_TERMINATE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)	// CUS_HQCUSM_common.h ¼±¾ð Ãß°¡
{
	// 사용할 변수 선언
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPRWKDAT_TAG CWIPRWKDAT; //[ERP 23.05.23] 

	// 설비/OI에서 전송한 in_node 값 전부 로그 작성
    LOG_head("CWIP_VALIDATE_TERMINATE_LOT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);  
	
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID");

	//C: COMPLETE,  I:INITIAL(AUTO PACKING 에서 사용함)	, //D: ERP->MES PACKING 해제된 LOT
	CWIPLOTPAK.STATUS_FLAG = 'C';  

	//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 재PACKING 못하게함.
	if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
	{
		//완료된 PACKING 정보가 있으면 에러처리함.
		strcpy(s_msg_code, "WIP-0564");
		TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
		//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID); // Server Crash
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID); // Server Crash
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	/* - [GERP PROJECT] [ERP 23.05.23] 시작****************************************************************/
    // 23.05.03 패킹이력이 있을경우 폐기 Validation
    CDB_init_cwiplotpak(&CWIPLOTPAK);
    TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID");

    if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
    {
        // 23.05.03 패킹이력이 있지만 재작업 오더가 있을떈 폐기 가능
        CDB_init_cwiprwkdat(&CWIPRWKDAT);
        memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
        memcpy(CWIPRWKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, strlen(CWIPLOTPAK.LOT_ID));
        if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) == 0) // 재작업으로 패킹된이력이 있으면  Error
        {
            strcpy(s_msg_code, "WIP-0616"); // This module requires a rework order
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);// 2023-03-09 JSLEE ADD
            TRS.add_dberrmsg(out_node, DB_error_msg);
        
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    /* - [GERP PROJECT] 끝*****************************************************************/

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 