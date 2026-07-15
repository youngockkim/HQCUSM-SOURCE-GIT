/******************************************************************************'

    System      : MESplus
    Module      : JCM
    File Name   : CJCM_view_job_change_item.c
    Description : View Job_Change_Item function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_View_Job_Change_Item()
            + View Job_Change_Item definition
        - CJCM_VIEW_JOB_CHANGE_ITEM()
            + Main sub function of JCM_View_Job_Change_Item function
            + View Job_Change_Item definition
    Detail Description
        - CJCM_VIEW_JOB_CHANGE_ITEM()
            + h_proc_step
                + 1 : View Job_Change_Item definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/17             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CJCM_View_Job_Change_Item()
        - View Job_Change_Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Job_Change_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_VIEW_JOB_CHANGE_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_VIEW_JOB_CHANGE_ITEM", out_node);

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
    CJCM_VIEW_JOB_CHANGE_ITEM()
        - Main sub function of "JCM_View_Job_Change_Item" function
        - View Job_Change_Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_VIEW_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBITM_TAG CJCMJOBITM;
	struct CJCMITMDEF_TAG CJCMITMDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CWIPORDSTS_TAG CWIPORDSTS;
	struct CJCMJOBSTS_TAG CJCMJOBSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;

    LOG_head("CJCM_VIEW_JOB_CHANGE_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("JCM", "JCM_View_Job_Change_Item",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* ORDER_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ORDER_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* ITEM_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cjcmjobitm(&CJCMJOBITM);
    TRS.copy(CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID), in_node, "ORDER_ID");
    TRS.copy(CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cjcmjobitm(1, &CJCMJOBITM);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMJOBITM SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM.ITEM_CODE), CJCMJOBITM.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY));
    TRS.add_string(out_node, "ORDER_ID", CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID));
    TRS.add_string(out_node, "ITEM_CODE", CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
    TRS.add_char(out_node, "AUTO_FLAG", CJCMJOBITM.AUTO_FLAG);
    TRS.add_string(out_node, "RESPONSIBILITY", CJCMJOBITM.RESPONSIBILITY, sizeof(CJCMJOBITM.RESPONSIBILITY));
    TRS.add_string(out_node, "DEPT_CODE", CJCMJOBITM.DEPT_CODE, sizeof(CJCMJOBITM.DEPT_CODE));
    TRS.add_string(out_node, "PLAN_START_DATE", CJCMJOBITM.PLAN_START_DATE, sizeof(CJCMJOBITM.PLAN_START_DATE));
    TRS.add_string(out_node, "PLAN_END_DATE", CJCMJOBITM.PLAN_END_DATE, sizeof(CJCMJOBITM.PLAN_END_DATE));
    TRS.add_string(out_node, "START_TIME", CJCMJOBITM.START_TIME, sizeof(CJCMJOBITM.START_TIME));
    TRS.add_string(out_node, "END_TIME", CJCMJOBITM.END_TIME, sizeof(CJCMJOBITM.END_TIME));
    TRS.add_int(out_node, "WORK_TIME", CJCMJOBITM.WORK_TIME);
    TRS.add_char(out_node, "STATUS", CJCMJOBITM.STATUS);
    TRS.add_char(out_node, "ALARM_FLAG", CJCMJOBITM.ALARM_FLAG);
    TRS.add_string(out_node, "ALARM_CODE", CJCMJOBITM.ALARM_CODE, sizeof(CJCMJOBITM.ALARM_CODE));
    TRS.add_string(out_node, "CMF_1", CJCMJOBITM.CMF_1, sizeof(CJCMJOBITM.CMF_1));
    TRS.add_string(out_node, "CMF_2", CJCMJOBITM.CMF_2, sizeof(CJCMJOBITM.CMF_2));
    TRS.add_string(out_node, "CMF_3", CJCMJOBITM.CMF_3, sizeof(CJCMJOBITM.CMF_3));
    TRS.add_string(out_node, "CMF_4", CJCMJOBITM.CMF_4, sizeof(CJCMJOBITM.CMF_4));
    TRS.add_string(out_node, "CMF_5", CJCMJOBITM.CMF_5, sizeof(CJCMJOBITM.CMF_5));
    TRS.add_string(out_node, "CMF_6", CJCMJOBITM.CMF_6, sizeof(CJCMJOBITM.CMF_6));
    TRS.add_string(out_node, "CMF_7", CJCMJOBITM.CMF_7, sizeof(CJCMJOBITM.CMF_7));
    TRS.add_string(out_node, "CMF_8", CJCMJOBITM.CMF_8, sizeof(CJCMJOBITM.CMF_8));
    TRS.add_string(out_node, "CMF_9", CJCMJOBITM.CMF_9, sizeof(CJCMJOBITM.CMF_9));
    TRS.add_string(out_node, "CMF_10", CJCMJOBITM.CMF_10, sizeof(CJCMJOBITM.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CJCMJOBITM.CREATE_TIME, sizeof(CJCMJOBITM.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CJCMJOBITM.UPDATE_USER_ID, sizeof(CJCMJOBITM.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CJCMJOBITM.UPDATE_TIME, sizeof(CJCMJOBITM.UPDATE_TIME));

	CDB_init_cjcmitmdef(&CJCMITMDEF);
	memcpy(CJCMITMDEF.FACTORY, CJCMJOBITM.FACTORY, sizeof(CJCMITMDEF.FACTORY));
	memcpy(CJCMITMDEF.ITEM_CODE, CJCMJOBITM.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE));
	CDB_select_cjcmitmdef(1, &CJCMITMDEF);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "ITEM_NAME", CJCMITMDEF.ITEM_NAME, sizeof(CJCMITMDEF.ITEM_NAME));
	}

	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	memcpy(MGCMTBLDAT.FACTORY, CJCMJOBITM.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
	memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_ITEM_STATUS", strlen("@JCM_ITEM_STATUS"));
	MGCMTBLDAT.KEY_1[0] =  CJCMJOBITM.STATUS;
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "STATUS_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}

	CDB_init_cwipordsts(&CWIPORDSTS);
	memcpy(CWIPORDSTS.FACTORY, CJCMJOBITM.FACTORY, sizeof(CWIPORDSTS.FACTORY));
	memcpy(CWIPORDSTS.ORDER_ID, CJCMJOBITM.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
	CDB_select_cwipordsts(1, &CWIPORDSTS);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "MAT_ID", CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.MAT_ID));
		TRS.add_string(out_node, "ORDER_DESC", CWIPORDSTS.PROD_NO_DESC, sizeof(CWIPORDSTS.PROD_NO_DESC));
	}
	else
	{
		CDB_init_cjcmjobsts(&CJCMJOBSTS);
		memcpy(CJCMJOBSTS.FACTORY, CJCMJOBITM.FACTORY, sizeof(CJCMJOBSTS.FACTORY));
		memcpy(CJCMJOBSTS.ORDER_ID, CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID));
		CDB_select_cjcmjobsts(1, &CJCMJOBSTS);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(out_node, "MAT_ID", CJCMJOBSTS.MAT_ID, sizeof(CJCMJOBSTS.MAT_ID));
		
			DBC_init_mwipmatdef(&MWIPMATDEF);
			memcpy(MWIPMATDEF.FACTORY, CJCMJOBITM.FACTORY, sizeof(MWIPMATDEF.FACTORY));
			memcpy(MWIPMATDEF.MAT_ID, CJCMJOBSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			DBC_select_mwipmatdef(3, &MWIPMATDEF);
 			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(out_node, "ORDER_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
			}		
		}
	}

    /* Not use in customizing
    if(COM_proc_user_routine("JCM", "JCM_View_Job_Change_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

