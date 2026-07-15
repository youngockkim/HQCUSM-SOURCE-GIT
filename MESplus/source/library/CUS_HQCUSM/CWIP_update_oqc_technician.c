/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_oqc_technician.c
    Description : OQC_TECHNICIAN Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_OQC_TECHNICIAN()
            + Create/Update/Delete OQC_TECHNICIAN definition
        - CWIP_UPDATE_OQC_TECHNICIAN()
            + Main sub function of CWIP_Update_OQC_TECHNICIAN function
            + Create/Update/Delete OQC_TECHNICIAN definition
        - CWIP_Update_OQC_TECHNICIAN_Validation()
            + Main sub function of CWIP_UPDATE_OQC_TECHNICIAN function
            + Check the condition for create/update/delete OQC_TECHNICIAN
    Detail Description
        - CWIP_UPDATE_OQC_TECHNICIAN()
            + h_proc_step
                + MP_STEP_CREATE : Create OQC_TECHNICIAN definition
                + MP_STEP_UPDATE : Update OQC_TECHNICIAN definition
                + MP_STEP_DELETE : Delete OQC_TECHNICIAN definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2020-09-05             Create by Generator

    Copyright(C) 1998-2020 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_OQC_TECHNICIAN_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_OQC_TECHNICIAN()
        - Create/Update/Delete OQC_TECHNICIAN definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Oqc_Technician(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

	if(CWIP_Update_OQC_TECHNICIAN_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    i_ret = CWIP_UPDATE_OQC_TECHNICIAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_OQC_TECHNICIAN", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CWIP_UPDATE_OQC_TECHNICIAN()
        - Main sub function of "CWIP_Update_OQC_TECHNICIAN" function
        - Create/Update/Delete OQC_TECHNICIAN definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_OQC_TECHNICIAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPOQCSTS_TAG CWIPOQCSTS;
	struct CWIPOQCHIS_TAG CWIPOQCHIS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;


    char   s_sys_time[14];
	char   OQC_update_flag ;
	int	   i_ins_cnt = 0;
	

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	TRSNode** list = TRS.get_list(in_node, "CWIP_UPDATE_OQC_TECHNICIAN");

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_OQC_TECHNICIAN");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }



	/* LOT이 신규 인지 업데이트인지 체크*/

    CDB_init_cwipoqcsts(&CWIPOQCSTS);
    TRS.copy(CWIPOQCSTS.LOT_ID, sizeof(CWIPOQCSTS.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CWIPOQCSTS.INS_TYPE, sizeof(CWIPOQCSTS.INS_TYPE), in_node, "INS_TYPE");		//TEC , ENG
    CDB_select_cwipoqcsts_for_update(1, &CWIPOQCSTS);			//LOCK 처리
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			OQC_update_flag = 'I';					//데이터 저장			
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPOQCSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPOQCSTS.LOT_ID), CWIPOQCSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CWIPOQCSTS.INS_TYPE), CWIPOQCSTS.INS_TYPE);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	else
	{	
			OQC_update_flag = 'U';	;	//데이터 업데이트
			i_ins_cnt = CWIPOQCSTS.INS_CNT;	// i_ins_cnt = CEDECLOTRLT.INS_CNT
	}


	/* MWIPLOTSTS 실적 저장*/

    if (OQC_update_flag == 'U')
	{
		CWIPOQCSTS.INS_CNT = CWIPOQCSTS.INS_CNT + 1;		
	}
	else
	{
		CWIPOQCSTS.INS_CNT = 1;

	}

    memcpy(CWIPOQCSTS.TRAN_TIME, s_sys_time, sizeof(CWIPOQCSTS.TRAN_TIME));
    TRS.copy(CWIPOQCSTS.FACTORY, sizeof(CWIPOQCSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPOQCSTS.INS_USER_ID, sizeof(CWIPOQCSTS.INS_USER_ID), in_node, "INS_USER_ID");
    TRS.copy(CWIPOQCSTS.GRADE, sizeof(CWIPOQCSTS.GRADE), in_node, "GRADE");
    TRS.copy(CWIPOQCSTS.DEFECT_CODE, sizeof(CWIPOQCSTS.DEFECT_CODE), in_node, "DEFECT_CODE");
    TRS.copy(CWIPOQCSTS.CELL_INFO, sizeof(CWIPOQCSTS.CELL_INFO), in_node, "CELL_INFO");
    TRS.copy(CWIPOQCSTS.REMARK, sizeof(CWIPOQCSTS.REMARK), in_node, "REMARK");
    TRS.copy(CWIPOQCSTS.CMF_1, sizeof(CWIPOQCSTS.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPOQCSTS.CMF_2, sizeof(CWIPOQCSTS.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPOQCSTS.CMF_3, sizeof(CWIPOQCSTS.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPOQCSTS.CMF_4, sizeof(CWIPOQCSTS.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPOQCSTS.CMF_5, sizeof(CWIPOQCSTS.CMF_5), in_node, "CMF_5");
	memcpy(CWIPOQCSTS.CREATE_TIME, s_sys_time, sizeof(CWIPOQCSTS.CREATE_TIME));
    TRS.copy(CWIPOQCSTS.CREATE_USER_ID, sizeof(CWIPOQCSTS.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    //TRS.copy(CWIPOQCSTS.CREATE_TIME, sizeof(CWIPOQCSTS.CREATE_TIME), in_node, "CREATE_TIME");
		

   	if (OQC_update_flag == 'I')
    {
        CDB_insert_cwipoqcsts(&CWIPOQCSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPOQCSTS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPOQCSTS.LOT_ID), CWIPOQCSTS.LOT_ID);
            TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CWIPOQCSTS.INS_TYPE), CWIPOQCSTS.INS_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
	else if (OQC_update_flag == 'U')
    {

        CDB_update_cwipoqcsts(1, &CWIPOQCSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPOQCSTS UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPOQCSTS.LOT_ID), CWIPOQCSTS.LOT_ID);
            TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CWIPOQCSTS.INS_TYPE), CWIPOQCSTS.INS_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    //CWIPOQCHIS 히스토리 실적 저장*/
	
	CDB_init_cwipoqchis(&CWIPOQCHIS);
	memcpy(CWIPOQCHIS.LOT_ID, CWIPOQCSTS.LOT_ID, sizeof(struct CWIPOQCHIS_TAG));//스트럭쳐 copy
    CDB_insert_cwipoqchis(&CWIPOQCHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPOQCHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPOQCHIS.LOT_ID), CWIPOQCHIS.LOT_ID);
        TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CWIPOQCHIS.INS_TYPE), CWIPOQCHIS.INS_TYPE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_OQC_TECHNICIAN_Validation()
        - Main sub function of "CWIP_UPDATE_OQC_TECHNICIAN" function
        - Check the condition for create/update/delete OQC_TECHNICIAN
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_OQC_TECHNICIAN_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPOQCSTS_TAG CWIPOQCSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;

   
    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

  
    /* LOT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* INS_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "INS_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "INS_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/* LOT ID 조회. LOT 체크 */

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	
	DBC_select_mwiplotsts(102, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0044");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	

  

    return MP_TRUE;
}

