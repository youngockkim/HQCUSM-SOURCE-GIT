/*******************************************************************************
 
    System      : MESplus
    Module      : Validate For Fqc Rejudgment
    File Name   : CWIP_validate_for_fqc_rejudgment.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.01.24  hyunjun.jo

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_VALIDATE_FOR_FQC_REJUDGMENT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Validate_For_Fqc_Rejudgment()
        - Validate_For_fqc_Rejudgment
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Validate_For_Fqc_Rejudgment(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VALIDATE_FOR_FQC_REJUDGMENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Validate_For_Fqc_Rejudgment", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}


/*******************************************************************************
    CWIP_VALIDATE_FOR_FQC_REJUDGMENT()
        - VALIDATE_FOR_FQC_REJUDGMENT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VALIDATE_FOR_FQC_REJUDGMENT(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	//struct CWIPACMHIS_TAG CWIPACMHIS;
	//struct CWIPRWKDAT_TAG CWIPRWKDAT;  // 2023-03-08 JSLEE ADD
	//struct CWIPLOTPAK_TAG CWIPLOTPAK;
	int txtSize;

	/* - [GERP PROJECT] 시작****************************************************************/
	//FQC 이력 확인 
	/*
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CEDCLOTRLT.INS_TYPE, "FC", strlen("FC"));
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);
	// 이전 FQC와 동일 등급 POWER 아니면 재작업 오더 확인 
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT(1)", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	else
	{
		if (TRS.mem_cmp(in_node, "INS_VALUE", CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE)) != 0 ||
			TRS.mem_cmp(in_node, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)) != 0)
		{
			CDB_init_cwiplotpak(&CWIPLOTPAK);
			memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPLOTPAK.LOT_ID, CEDCLOTRLT.LOT_ID, strlen(CEDCLOTRLT.LOT_ID));
			//if (CDB_select_cwiplotpak_scalar(2, &CWIPLOTPAK) > 0)// 2023-03-09 JSLEE
			if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
			{
				//2023-03-18 재작업 선정 모듈 중 오더 2회 에 대하여 포장이력이 없는 것이 최종 재작업 오더의 모듈
				CDB_init_cwiprwkdat(&CWIPRWKDAT);
				memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				//memcpy(CWIPRWKDAT.MODULE_ID, CEDCLOTRLT.LOT_ID, sizeof(CWIPRWKDAT.MODULE_ID));
				TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "LOT_ID");

				if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) <= 0)
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
		}
	}
	*/
	/* - [GERP PROJECT] 끝*****************************************************************/

	// Check Ground Test
	// CEDCLOTRLT.INS_TYPE = GR
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CEDCLOTRLT.INS_TYPE, "GR", strlen("GR"));
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1,&CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
	{
		//if GR does not exist, create one.
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "554");
			TRS.set_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof("M3100"), "M3100");
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	if(memcmp(CEDCLOTRLT.RESULT_VALUE, "NG", strlen("NG")) == 0 ||
		memcmp(CEDCLOTRLT.RESULT_VALUE, "NO", strlen("NO")) == 0 ||
		COM_isnullspace(CEDCLOTRLT.RESULT_VALUE) == MP_TRUE)
	{
        if(memcmp(TRS.get_string(in_node, "GRADE"), "G06", 3) != 0 && memcmp(TRS.get_string(in_node, "GRADE"), "RWK", 3) != 0)
        {
		    strcpy(s_msg_code, "554");
		    TRS.set_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
			    TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof("M3100"), "M3100");
			    TRS.add_dberrmsg(out_node, DB_error_msg);

			    gs_log_type.type = MP_LOG_ERROR;
			    gs_log_type.e_type = MP_LOG_E_SYSTEM;
			    gs_log_type.category = MP_LOG_CATE_TRANS;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
        }
	}


	// Hipot Test
	// CEDCLOTRLT.INS_TYPE = HI
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CEDCLOTRLT.INS_TYPE, "HI", strlen("HI"));
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1,&CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
	{
		//if GR does not exist, create one.
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "555");
			TRS.set_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof("M3060"), "M3060");
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	if(memcmp(CEDCLOTRLT.RESULT_VALUE, "NG", strlen("NG")) == 0 ||
		memcmp(CEDCLOTRLT.RESULT_VALUE, "NO", strlen("NO")) == 0 ||
		COM_isnullspace(CEDCLOTRLT.RESULT_VALUE) == MP_TRUE)
	{
        if(memcmp(TRS.get_string(in_node, "GRADE"), "G06", 3) != 0 && memcmp(TRS.get_string(in_node, "GRADE"), "RWK", 3) != 0)
        {
		    strcpy(s_msg_code, "555");
		    TRS.set_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
			    TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof("M3060"), "M3060");
			    TRS.add_dberrmsg(out_node, DB_error_msg);

			    gs_log_type.type = MP_LOG_ERROR;
			    gs_log_type.e_type = MP_LOG_E_SYSTEM;
			    gs_log_type.category = MP_LOG_CATE_TRANS;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
        }
	}



	//AC모듈 대상일때 A등급인 경우 인버터 아이디 없으면 에러처리.
	//CEDCLOTRLT.MAT_ID
	//IN_NODE.GRADE
	//lot_id로 인버터 id존재 여부 체크.
	//lot_id로 인버터  id가지고 ac모듈 존재 여부 체크.
	//[AC모듈]대상인경우
	// LOT SELECT
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0044");
		TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
		//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);  // Server Crash
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);  // Server Crash
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;

		return MP_FALSE;
	}

	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
	if(memcmp(MGCMLAGDAT.DATA_10, "Y", strlen("Y")) == 0){
		if(memcmp(TRS.get_string(in_node, "GRADE"), "G01", 3) == 0 || memcmp(TRS.get_string(in_node, "GRADE"), "G02", 3) == 0
			|| memcmp(TRS.get_string(in_node, "GRADE"), "G03", 3) == 0
			|| memcmp(TRS.get_string(in_node, "GRADE"), "G04", 3) == 0
			){ //--[G03/G04 로직 추가]
			for(txtSize = 0; MWIPLOTSTS.LOT_CMF_15[txtSize] != ' '; ++txtSize);
			if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) == 0){
				//[AC ALARM]인버터 ID가 없습니다.
				strcpy(s_msg_code, "WIP-0610");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, strlen(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(12 != txtSize){
				//[AC ALARM]잘못된 인버터 ID 자리수를 가지고 있습니다.
				strcpy(s_msg_code, "WIP-0607");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, strlen(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			/*
			CDB_init_cwipacmhis(&CWIPACMHIS);
			memcpy(CWIPACMHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CWIPACMHIS.PCU_SN, MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
			memcpy(CWIPACMHIS.CMF_1, "D", sizeof("D"));
			CDB_select_cwipacmhis(3, &CWIPACMHIS);
			if(memcmp(MWIPLOTSTS.LOT_ID, CWIPACMHIS.LOT_ID, sizeof(CWIPACMHIS.LOT_ID)) != 0){//크로스체크
				strcpy(s_msg_code, "WIP-0611");//[AC ALARM]잘못된 인버터ID이거나 정보를 가지고 있습니다. 
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CWIPACMHIS.LOT_ID), CWIPACMHIS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			*/
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}