/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_view_setup_job_change_item.c
    Description : View Setup_Job_Change_Item function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_View_Setup_Job_Change_Item()
            + View Setup_Job_Change_Item definition
        - CJCM_VIEW_SETUP_JOB_CHANGE_ITEM()
            + Main sub function of CJCM_View_Setup_Job_Change_Item function
            + View Setup_Job_Change_Item definition
        - CJCM_View_Setup_Job_Change_Item_Validation()
            + Main sub function of CJCM_VIEW_SETUP_JOB_CHANGE_ITEM function
            + Check the condition for view Setup_Job_Change_Item
    Detail Description
        - CJCM_VIEW_SETUP_JOB_CHANGE_ITEM()
            + h_proc_step
                + 1 : View Setup_Job_Change_Item definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/18             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_View_Setup_Job_Change_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_View_Setup_Job_Change_Item()
        - View Setup_Job_Change_Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Setup_Job_Change_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_VIEW_SETUP_JOB_CHANGE_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_VIEW_SETUP_JOB_CHANGE_ITEM", out_node);

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
    CJCM_VIEW_SETUP_JOB_CHANGE_ITEM()
        - Main sub function of "CJCM_View_Setup_Job_Change_Item" function
        - View Setup_Job_Change_Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_VIEW_SETUP_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMITMDEF_TAG CJCMITMDEF;
	struct MSECUSRDEF_TAG MSECUSRDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    LOG_head("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Setup_Job_Change_Item",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CJCM_View_Setup_Job_Change_Item_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cjcmitmdef(&CJCMITMDEF);
    TRS.copy(CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cjcmitmdef(1, &CJCMITMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMITMDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY));
    TRS.add_string(out_node, "ITEM_CODE", CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE));
	TRS.add_string(out_node, "ITEM_NAME", CJCMITMDEF.ITEM_NAME, sizeof(CJCMITMDEF.ITEM_NAME));
    TRS.add_char(out_node, "AUTO_FLAG", CJCMITMDEF.AUTO_FLAG);
    TRS.add_string(out_node, "RESPONSIBILITY", CJCMITMDEF.RESPONSIBILITY, sizeof(CJCMITMDEF.RESPONSIBILITY));
    TRS.add_string(out_node, "DEPT_CODE", CJCMITMDEF.DEPT_CODE, sizeof(CJCMITMDEF.DEPT_CODE));
    TRS.add_int(out_node, "PLAN_START_DAYS_BEFORE", CJCMITMDEF.PLAN_START_DAYS_BEFORE);
    TRS.add_int(out_node, "PLAN_END_DAYS_BEFORE", CJCMITMDEF.PLAN_END_DAYS_BEFORE);
    TRS.add_char(out_node, "ALARM_FLAG", CJCMITMDEF.ALARM_FLAG);
    TRS.add_string(out_node, "ALARM_CODE", CJCMITMDEF.ALARM_CODE, sizeof(CJCMITMDEF.ALARM_CODE));
    TRS.add_string(out_node, "SQL_TEXT", CJCMITMDEF.SQL_TEXT, sizeof(CJCMITMDEF.SQL_TEXT));
    TRS.add_string(out_node, "CMF_1", CJCMITMDEF.CMF_1, sizeof(CJCMITMDEF.CMF_1));
    TRS.add_string(out_node, "CMF_2", CJCMITMDEF.CMF_2, sizeof(CJCMITMDEF.CMF_2));
    TRS.add_string(out_node, "CMF_3", CJCMITMDEF.CMF_3, sizeof(CJCMITMDEF.CMF_3));
    TRS.add_string(out_node, "CMF_4", CJCMITMDEF.CMF_4, sizeof(CJCMITMDEF.CMF_4));
    TRS.add_string(out_node, "CMF_5", CJCMITMDEF.CMF_5, sizeof(CJCMITMDEF.CMF_5));
    TRS.add_string(out_node, "CMF_6", CJCMITMDEF.CMF_6, sizeof(CJCMITMDEF.CMF_6));
    TRS.add_string(out_node, "CMF_7", CJCMITMDEF.CMF_7, sizeof(CJCMITMDEF.CMF_7));
    TRS.add_string(out_node, "CMF_8", CJCMITMDEF.CMF_8, sizeof(CJCMITMDEF.CMF_8));
    TRS.add_string(out_node, "CMF_9", CJCMITMDEF.CMF_9, sizeof(CJCMITMDEF.CMF_9));
    TRS.add_string(out_node, "CMF_10", CJCMITMDEF.CMF_10, sizeof(CJCMITMDEF.CMF_10));
	TRS.add_char(out_node, "USE_FLAG", CJCMITMDEF.USE_FLAG);
    TRS.add_string(out_node, "CREATE_USER_ID", CJCMITMDEF.CREATE_USER_ID, sizeof(CJCMITMDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CJCMITMDEF.CREATE_TIME, sizeof(CJCMITMDEF.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CJCMITMDEF.UPDATE_USER_ID, sizeof(CJCMITMDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CJCMITMDEF.UPDATE_TIME, sizeof(CJCMITMDEF.UPDATE_TIME));

	DBC_init_msecusrdef(&MSECUSRDEF);
    TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MSECUSRDEF.USER_ID, CJCMITMDEF.RESPONSIBILITY, sizeof(CJCMITMDEF.RESPONSIBILITY));
	DBC_select_msecusrdef(1, &MSECUSRDEF);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "RESPONSIBILITY_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
    }

	//항목별 라인 담당자.
	if( TRS.get_procstep(in_node) == '2')
	{
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_RESPONSIBILITY", strlen("@JCM_RESPONSIBILITY"));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_CODE");
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "ITEM_CODE");
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(out_node, "RESPONSIBILITY_ID", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
	}
    
	/* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Setup_Job_Change_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CJCM_View_Setup_Job_Change_Item_Validation()
        - Main sub function of "CJCM_VIEW_SETUP_JOB_CHANGE_ITEM" function
        - Check the condition for view Setup_Job_Change_Item
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Setup_Job_Change_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMITMDEF_TAG CJCMITMDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST); 

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

    CDB_init_cjcmitmdef(&CJCMITMDEF);
    TRS.copy(CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cjcmitmdef(1, &CJCMITMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "CMN-0004");
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "CJCMITMDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

