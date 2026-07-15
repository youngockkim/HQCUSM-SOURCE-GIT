/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_update_setup_job_change_item.c
    Description : Setup_Job_Change_Item Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Update_Setup_Job_Change_Item()
            + Create/Update/Delete Setup_Job_Change_Item definition
        - CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM()
            + Main sub function of CJCM_Update_Setup_Job_Change_Item function
            + Create/Update/Delete Setup_Job_Change_Item definition
        - CJCM_Update_Setup_Job_Change_Item_Validation()
            + Main sub function of CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM function
            + Check the condition for create/update/delete Setup_Job_Change_Item
    Detail Description
        - CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM()
            + h_proc_step
                + MP_STEP_CREATE : Create Setup_Job_Change_Item definition
                + MP_STEP_UPDATE : Update Setup_Job_Change_Item definition
                + MP_STEP_DELETE : Delete Setup_Job_Change_Item definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/18             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_Update_Setup_Job_Change_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_Update_Setup_Job_Change_Item()
        - Create/Update/Delete Setup_Job_Change_Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Update_Setup_Job_Change_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM", out_node);

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
    CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM()
        - Main sub function of "CJCM_Update_Setup_Job_Change_Item" function
        - Create/Update/Delete Setup_Job_Change_Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMITMDEF_TAG CJCMITMDEF;
    struct CJCMITMDEF_TAG CJCMITMDEF_o;
    char   s_sys_time[14];
	char   s_sql[4000];
	char   s_sql_temp[4000];

    LOG_head("CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
	LOG_add("item_name", MP_NSTR, TRS.get_string(in_node, "ITEM_NAME"));
    LOG_add("auto_flag", MP_CHR, TRS.get_char(in_node, "AUTO_FLAG"));
    LOG_add("responsibility", MP_NSTR, TRS.get_string(in_node, "RESPONSIBILITY"));
    LOG_add("dept_code", MP_NSTR, TRS.get_string(in_node, "DEPT_CODE"));
    LOG_add("plan_start_days_before", MP_INT, TRS.get_int(in_node, "PLAN_START_DAYS_BEFORE"));
    LOG_add("plan_end_days_before", MP_INT, TRS.get_int(in_node, "PLAN_END_DAYS_BEFORE"));
    LOG_add("alarm_flag", MP_CHR, TRS.get_char(in_node, "ALARM_FLAG"));
    LOG_add("alarm_code", MP_NSTR, TRS.get_string(in_node, "ALARM_CODE"));
    LOG_add("sql_text", MP_NSTR, TRS.get_string(in_node, "SQL_TEXT"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
	LOG_add("use_flag", MP_CHR, TRS.get_char(in_node, "USE_FLAG"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Update_Setup_Job_Change_Item",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

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

	if(TRS.get_procstep(in_node) == 'Q')
	{
		//SQL Check ÀÎ °æ¿ì
		memset(s_sql, ' ', sizeof(s_sql));
		memset(s_sql_temp, ' ', sizeof(s_sql_temp));

		TRS.copy(s_sql_temp, sizeof(s_sql_temp), in_node, "SQL_TEXT");
		COM_memcpy_add_null(s_sql, s_sql_temp, sizeof(s_sql_temp));
		DBC_execute_query2(s_sql);
		if(DB_error_code == DB_SUCCESS)
        {
			DBC_close_dsql();
			COM_set_result(out_node, MP_SUCCESS_C, "UID-0056", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}
		else
		{		
			strcpy(s_msg_code, "UID-0050");
            TRS.add_dberrmsg(out_node, DB_error_msg);

			DBC_close_dsql();
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));			
			return MP_FALSE;
		}	
	}


    if(CJCM_Update_Setup_Job_Change_Item_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cjcmitmdef(&CJCMITMDEF);
    TRS.copy(CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
	TRS.copy(CJCMITMDEF.ITEM_NAME, sizeof(CJCMITMDEF.ITEM_NAME), in_node, "ITEM_NAME");
    CJCMITMDEF.AUTO_FLAG = TRS.get_char(in_node, "AUTO_FLAG");
    TRS.copy(CJCMITMDEF.RESPONSIBILITY, sizeof(CJCMITMDEF.RESPONSIBILITY), in_node, "RESPONSIBILITY");
    TRS.copy(CJCMITMDEF.DEPT_CODE, sizeof(CJCMITMDEF.DEPT_CODE), in_node, "DEPT_CODE");
    CJCMITMDEF.PLAN_START_DAYS_BEFORE = TRS.get_int(in_node, "PLAN_START_DAYS_BEFORE");
    CJCMITMDEF.PLAN_END_DAYS_BEFORE = TRS.get_int(in_node, "PLAN_END_DAYS_BEFORE");
    CJCMITMDEF.ALARM_FLAG = TRS.get_char(in_node, "ALARM_FLAG");
    TRS.copy(CJCMITMDEF.ALARM_CODE, sizeof(CJCMITMDEF.ALARM_CODE), in_node, "ALARM_CODE");
    TRS.copy(CJCMITMDEF.SQL_TEXT, sizeof(CJCMITMDEF.SQL_TEXT), in_node, "SQL_TEXT");
    TRS.copy(CJCMITMDEF.CMF_1, sizeof(CJCMITMDEF.CMF_1), in_node, "CMF_1");
    TRS.copy(CJCMITMDEF.CMF_2, sizeof(CJCMITMDEF.CMF_2), in_node, "CMF_2");
    TRS.copy(CJCMITMDEF.CMF_3, sizeof(CJCMITMDEF.CMF_3), in_node, "CMF_3");
    TRS.copy(CJCMITMDEF.CMF_4, sizeof(CJCMITMDEF.CMF_4), in_node, "CMF_4");
    TRS.copy(CJCMITMDEF.CMF_5, sizeof(CJCMITMDEF.CMF_5), in_node, "CMF_5");
    TRS.copy(CJCMITMDEF.CMF_6, sizeof(CJCMITMDEF.CMF_6), in_node, "CMF_6");
    TRS.copy(CJCMITMDEF.CMF_7, sizeof(CJCMITMDEF.CMF_7), in_node, "CMF_7");
    TRS.copy(CJCMITMDEF.CMF_8, sizeof(CJCMITMDEF.CMF_8), in_node, "CMF_8");
    TRS.copy(CJCMITMDEF.CMF_9, sizeof(CJCMITMDEF.CMF_9), in_node, "CMF_9");
    TRS.copy(CJCMITMDEF.CMF_10, sizeof(CJCMITMDEF.CMF_10), in_node, "CMF_10");
	CJCMITMDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
    TRS.copy(CJCMITMDEF.CREATE_USER_ID, sizeof(CJCMITMDEF.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CJCMITMDEF.CREATE_TIME, sizeof(CJCMITMDEF.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CJCMITMDEF.UPDATE_USER_ID, sizeof(CJCMITMDEF.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CJCMITMDEF.UPDATE_TIME, sizeof(CJCMITMDEF.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CJCMITMDEF.CREATE_USER_ID, sizeof(CJCMITMDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CJCMITMDEF.CREATE_TIME, s_sys_time, sizeof(CJCMITMDEF.CREATE_TIME));
        CDB_insert_cjcmitmdef(&CJCMITMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0004");
            TRS.add_fieldmsg(out_node, "CJCMITMDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        CDB_init_cjcmitmdef(&CJCMITMDEF_o);
        TRS.copy(CJCMITMDEF_o.FACTORY, sizeof(CJCMITMDEF_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CJCMITMDEF_o.ITEM_CODE, sizeof(CJCMITMDEF_o.ITEM_CODE), in_node, "ITEM_CODE");
        CDB_select_cjcmitmdef_for_update(1, &CJCMITMDEF_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0004");
            TRS.add_fieldmsg(out_node, "CJCMITMDEF SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF_o.FACTORY), CJCMITMDEF_o.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF_o.ITEM_CODE), CJCMITMDEF_o.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CJCMITMDEF.CREATE_USER_ID, CJCMITMDEF_o.CREATE_USER_ID, sizeof(CJCMITMDEF.CREATE_USER_ID));
        memcpy(CJCMITMDEF.CREATE_TIME, CJCMITMDEF_o.CREATE_TIME, sizeof(CJCMITMDEF.CREATE_TIME));
        TRS.copy(CJCMITMDEF.UPDATE_USER_ID, sizeof(CJCMITMDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CJCMITMDEF.UPDATE_TIME, s_sys_time, sizeof(CJCMITMDEF.UPDATE_TIME));

        CDB_update_cjcmitmdef(1, &CJCMITMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0004");
            TRS.add_fieldmsg(out_node, "CJCMITMDEF UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        CDB_delete_cjcmitmdef(1, &CJCMITMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0004");
            TRS.add_fieldmsg(out_node, "CJCMITMDEF DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Update_Setup_Job_Change_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CJCM_Update_Setup_Job_Change_Item_Validation()
        - Main sub function of "CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM" function
        - Check the condition for create/update/delete Setup_Job_Change_Item
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Update_Setup_Job_Change_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMITMDEF_TAG CJCMITMDEF;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    /* ITEM_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0001");
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cjcmitmdef(&CJCMITMDEF);
    TRS.copy(CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cjcmitmdef(1, &CJCMITMDEF);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0018");
            TRS.add_fieldmsg(out_node, "CJCMITMDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "CMN-XXXX");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CMN-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CJCMITMDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

