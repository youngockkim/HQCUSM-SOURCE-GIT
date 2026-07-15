/******************************************************************************'

    System      : MESplus
    Module      : JCM
    File Name   : CJCM_update_job_change_item.c
    Description : Job_Change_Item Setup function module

    MES Version : 5.3.4 ~

    Function List
        -CJCM_Update_Job_Change_Item()
            + Create/Update/Delete Job_Change_Item definition
        -CJCM_UPDATE_JOB_CHANGE_ITEM()
            + Main sub function of JCM_Update_Job_Change_Item function
            + Create/Update/Delete Job_Change_Item definition
        -CJCM_Update_Job_Change_Item_Validation()
            + Main sub function of JCM_UPDATE_JOB_CHANGE_ITEM function
            + Check the condition for create/update/delete Job_Change_Item
    Detail Description
        -CJCM_UPDATE_JOB_CHANGE_ITEM()
            + h_proc_step
                + MP_STEP_CREATE : Create Job_Change_Item definition
                + MP_STEP_UPDATE : Update Job_Change_Item definition
                + MP_STEP_DELETE : Delete Job_Change_Item definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/17             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_Update_Job_Change_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
   CJCM_Update_Job_Change_Item()
        - Create/Update/Delete Job_Change_Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Update_Job_Change_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret =CJCM_UPDATE_JOB_CHANGE_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_UPDATE_JOB_CHANGE_ITEM", out_node);

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
   CJCM_UPDATE_JOB_CHANGE_ITEM()
        - Main sub function of "JCM_Update_Job_Change_Item" function
        - Create/Update/Delete Job_Change_Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_UPDATE_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBITM_TAG CJCMJOBITM;
    struct CJCMJOBITM_TAG CJCMJOBITM_o;
	struct CJCMJOBSTS_TAG CJCMJOBSTS;
	
    char   s_sys_time[14];
	int    i_case;
	char   c_main_status;
	char   s_main_start_time[14];
	char   s_main_end_time[14];
    LOG_head("CJCM_UPDATE_JOB_CHANGE_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    LOG_add("auto_flag", MP_CHR, TRS.get_char(in_node, "AUTO_FLAG"));
    LOG_add("responsibility", MP_NSTR, TRS.get_string(in_node, "RESPONSIBILITY"));
    LOG_add("dept_code", MP_NSTR, TRS.get_string(in_node, "DEPT_CODE"));
    LOG_add("plan_start_date", MP_NSTR, TRS.get_string(in_node, "PLAN_START_DATE"));
    LOG_add("plan_end_date", MP_NSTR, TRS.get_string(in_node, "PLAN_END_DATE"));
    LOG_add("start_time", MP_NSTR, TRS.get_string(in_node, "START_TIME"));
    LOG_add("end_time", MP_NSTR, TRS.get_string(in_node, "END_TIME"));
    LOG_add("work_time", MP_INT, TRS.get_int(in_node, "WORK_TIME"));
    LOG_add("status", MP_CHR, TRS.get_char(in_node, "STATUS"));
    LOG_add("alarm_flag", MP_CHR, TRS.get_char(in_node, "ALARM_FLAG"));
    LOG_add("alarm_code", MP_NSTR, TRS.get_string(in_node, "ALARM_CODE"));
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
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("JCM", "JCM_Update_Job_Change_Item",
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

    if(CJCM_Update_Job_Change_Item_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cjcmjobitm(&CJCMJOBITM);
    TRS.copy(CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID), in_node, "ORDER_ID");
    TRS.copy(CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE), in_node, "ITEM_CODE");
    CJCMJOBITM.AUTO_FLAG = TRS.get_char(in_node, "AUTO_FLAG");
    TRS.copy(CJCMJOBITM.RESPONSIBILITY, sizeof(CJCMJOBITM.RESPONSIBILITY), in_node, "RESPONSIBILITY");
    TRS.copy(CJCMJOBITM.DEPT_CODE, sizeof(CJCMJOBITM.DEPT_CODE), in_node, "DEPT_CODE");
    TRS.copy(CJCMJOBITM.PLAN_START_DATE, sizeof(CJCMJOBITM.PLAN_START_DATE), in_node, "PLAN_START_DATE");
    TRS.copy(CJCMJOBITM.PLAN_END_DATE, sizeof(CJCMJOBITM.PLAN_END_DATE), in_node, "PLAN_END_DATE");
    TRS.copy(CJCMJOBITM.START_TIME, sizeof(CJCMJOBITM.START_TIME), in_node, "START_TIME");
    TRS.copy(CJCMJOBITM.END_TIME, sizeof(CJCMJOBITM.END_TIME), in_node, "END_TIME");
    CJCMJOBITM.WORK_TIME = TRS.get_int(in_node, "WORK_TIME");
    CJCMJOBITM.STATUS = TRS.get_char(in_node, "STATUS");
    CJCMJOBITM.ALARM_FLAG = TRS.get_char(in_node, "ALARM_FLAG");
    TRS.copy(CJCMJOBITM.ALARM_CODE, sizeof(CJCMJOBITM.ALARM_CODE), in_node, "ALARM_CODE");
    TRS.copy(CJCMJOBITM.CMF_1, sizeof(CJCMJOBITM.CMF_1), in_node, "CMF_1");
    TRS.copy(CJCMJOBITM.CMF_2, sizeof(CJCMJOBITM.CMF_2), in_node, "CMF_2");
    TRS.copy(CJCMJOBITM.CMF_3, sizeof(CJCMJOBITM.CMF_3), in_node, "CMF_3");
    TRS.copy(CJCMJOBITM.CMF_4, sizeof(CJCMJOBITM.CMF_4), in_node, "CMF_4");
    TRS.copy(CJCMJOBITM.CMF_5, sizeof(CJCMJOBITM.CMF_5), in_node, "CMF_5");
    TRS.copy(CJCMJOBITM.CMF_6, sizeof(CJCMJOBITM.CMF_6), in_node, "CMF_6");
    TRS.copy(CJCMJOBITM.CMF_7, sizeof(CJCMJOBITM.CMF_7), in_node, "CMF_7");
    TRS.copy(CJCMJOBITM.CMF_8, sizeof(CJCMJOBITM.CMF_8), in_node, "CMF_8");
    TRS.copy(CJCMJOBITM.CMF_9, sizeof(CJCMJOBITM.CMF_9), in_node, "CMF_9");
    TRS.copy(CJCMJOBITM.CMF_10, sizeof(CJCMJOBITM.CMF_10), in_node, "CMF_10");
    TRS.copy(CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CJCMJOBITM.CREATE_TIME, sizeof(CJCMJOBITM.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CJCMJOBITM.UPDATE_USER_ID, sizeof(CJCMJOBITM.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CJCMJOBITM.UPDATE_TIME, sizeof(CJCMJOBITM.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CJCMJOBITM.CREATE_TIME, s_sys_time, sizeof(CJCMJOBITM.CREATE_TIME));
        CDB_insert_cjcmjobitm(&CJCMJOBITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "JCM-0004");
            TRS.add_fieldmsg(out_node, "CJCMJOBITM INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM.ITEM_CODE), CJCMJOBITM.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		//CJCMITMHIS Insert 추가
		TRS.add_char(in_node, "TRAN_FLAG", 'I');
		if (CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        CDB_init_cjcmjobitm(&CJCMJOBITM_o);
        TRS.copy(CJCMJOBITM_o.FACTORY, sizeof(CJCMJOBITM_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CJCMJOBITM_o.ORDER_ID, sizeof(CJCMJOBITM_o.ORDER_ID), in_node, "ORDER_ID");
        TRS.copy(CJCMJOBITM_o.ITEM_CODE, sizeof(CJCMJOBITM_o.ITEM_CODE), in_node, "ITEM_CODE");
        CDB_select_cjcmjobitm_for_update(1, &CJCMJOBITM_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "JCM-0004");
            TRS.add_fieldmsg(out_node, "CJCMJOBITM SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM_o.FACTORY), CJCMJOBITM_o.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM_o.ORDER_ID), CJCMJOBITM_o.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM_o.ITEM_CODE), CJCMJOBITM_o.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CJCMJOBITM.CREATE_USER_ID, CJCMJOBITM_o.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID));
        memcpy(CJCMJOBITM.CREATE_TIME, CJCMJOBITM_o.CREATE_TIME, sizeof(CJCMJOBITM.CREATE_TIME));
        TRS.copy(CJCMJOBITM.UPDATE_USER_ID, sizeof(CJCMJOBITM.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CJCMJOBITM.UPDATE_TIME, s_sys_time, sizeof(CJCMJOBITM.UPDATE_TIME));
		i_case = 1;
		if (TRS.get_char(in_node, "STATUS") == 'S')
			i_case = 4;
		else if (TRS.get_char(in_node, "STATUS") == 'E')
		{
			i_case = 5;	
		}
		else if (TRS.get_char(in_node, "STATUS") == 'W')
			i_case = 6;
		else if (TRS.get_char(in_node, "STATUS") == 'B')
			i_case = 7;

        CDB_update_cjcmjobitm(i_case, &CJCMJOBITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBITM UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM.ITEM_CODE), CJCMJOBITM.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		//CJCMITMHIS Insert 추가
		TRS.add_char(in_node, "TRAN_FLAG", 'U');
		if (CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
		//CJCMITMHIS Insert 추가
		TRS.add_char(in_node, "TRAN_FLAG", 'D');
		if (CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

        CDB_delete_cjcmjobitm(1, &CJCMJOBITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBITM DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM.ITEM_CODE), CJCMJOBITM.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

	// Main Status Check Update
	c_main_status = 'W';
	memset(s_main_start_time, ' ', sizeof(s_main_start_time));
	memset(s_main_end_time, ' ', sizeof(s_main_end_time));
	CDB_init_cjcmjobitm(&CJCMJOBITM);
	TRS.copy(CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID), in_node, "ORDER_ID");
	CDB_select_cjcmjobitm(2, &CJCMJOBITM);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMJOBITM SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	else 
	{
		if(COM_isnullspace(CJCMJOBITM.START_TIME) == MP_TRUE)
		{
			c_main_status = 'W';//대기 상태
		}
		else
		{
			memcpy(s_main_start_time, CJCMJOBITM.START_TIME, sizeof(CJCMJOBITM.START_TIME));
			if(CJCMJOBITM.STATUS == 'E')
			{
				c_main_status = 'E'; //End 상태
				memcpy(s_main_end_time, CJCMJOBITM.END_TIME, sizeof(CJCMJOBITM.END_TIME));
			}
			else
			{
				c_main_status = 'S'; //시작 상태
			}
		}
	}

	CDB_init_cjcmjobsts(&CJCMJOBSTS);
    TRS.copy(CJCMJOBSTS.FACTORY, sizeof(CJCMJOBSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID), in_node, "ORDER_ID");
	memcpy(CJCMJOBSTS.START_TIME, s_main_start_time, sizeof(CJCMJOBSTS.START_TIME));
	if (c_main_status == 'E')
	{
		memcpy(CJCMJOBSTS.END_TIME, s_main_end_time, sizeof(CJCMJOBSTS.END_TIME));
	}
	CJCMJOBSTS.STATUS = c_main_status;
	TRS.copy(CJCMJOBSTS.UPDATE_USER_ID, sizeof(CJCMJOBSTS.UPDATE_USER_ID), in_node, IN_USERID);
    memcpy(CJCMJOBSTS.UPDATE_TIME, s_sys_time, sizeof(CJCMJOBSTS.UPDATE_TIME));
	CDB_update_cjcmjobsts(3, &CJCMJOBSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code != DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "CMN-0003");
			TRS.add_fieldmsg(out_node, "CJCMJOBSTS UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS.FACTORY), CJCMJOBSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS.ORDER_ID), CJCMJOBSTS.ORDER_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

    /* Not use in customizing
    if(COM_proc_user_routine("JCM", "JCM_Update_Job_Change_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
   CJCM_Update_Job_Change_Item_Validation()
        - Main sub function of "JCM_UPDATE_JOB_CHANGE_ITEM" function
        - Check the condition for create/update/delete Job_Change_Item
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Update_Job_Change_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBITM_TAG CJCMJOBITM;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUDB") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
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

    /* ORDER_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ORDER_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
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
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cjcmjobitm(&CJCMJOBITM);
    TRS.copy(CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID), in_node, "ORDER_ID");
    TRS.copy(CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cjcmjobitm(1, &CJCMJOBITM);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0018");
            TRS.add_fieldmsg(out_node, "CJCMJOBITM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM.ITEM_CODE), CJCMJOBITM.ITEM_CODE);
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
                strcpy(s_msg_code, "CMN-0004");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CMN-0003");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CJCMJOBITM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM.ITEM_CODE), CJCMJOBITM.ITEM_CODE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

