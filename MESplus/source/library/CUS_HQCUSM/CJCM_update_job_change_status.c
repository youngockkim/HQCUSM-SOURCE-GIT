/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_update_job_change_status.c
    Description : Job_Change_Status Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Update_Job_Change_Status()
            + Create/Update/Delete Job_Change_Status definition
        - CJCM_UPDATE_JOB_CHANGE_STATUS()
            + Main sub function of CJCM_Update_Job_Change_Status function
            + Create/Update/Delete Job_Change_Status definition
        - CJCM_Update_Job_Change_Status_Validation()
            + Main sub function of CJCM_UPDATE_JOB_CHANGE_STATUS function
            + Check the condition for create/update/delete Job_Change_Status
    Detail Description
        - CJCM_UPDATE_JOB_CHANGE_STATUS()
            + h_proc_step
                + MP_STEP_CREATE : Create Job_Change_Status definition
                + MP_STEP_UPDATE : Update Job_Change_Status definition
                + MP_STEP_DELETE : Delete Job_Change_Status definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/17             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_Update_Job_Change_Status_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_Update_Job_Change_Status()
        - Create/Update/Delete Job_Change_Status definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Update_Job_Change_Status(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_UPDATE_JOB_CHANGE_STATUS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_UPDATE_JOB_CHANGE_STATUS", out_node);

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
    CJCM_UPDATE_JOB_CHANGE_STATUS()
        - Main sub function of "CJCM_Update_Job_Change_Status" function
        - Create/Update/Delete Job_Change_Status definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_UPDATE_JOB_CHANGE_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
    //struct CJCMJOBSTS_TAG CJCMJOBSTS_o;
	struct CJCMJOBITM_TAG CJCMJOBITM;
    char   s_sys_time[14];

	int		i;
	int		i_item_count;
	TRSNode **item_list;

    LOG_head("CJCM_UPDATE_JOB_CHANGE_STATUS");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    LOG_add("manager", MP_NSTR, TRS.get_string(in_node, "MANAGER"));
    LOG_add("dept_code", MP_NSTR, TRS.get_string(in_node, "DEPT_CODE"));
    LOG_add("plan_start_date", MP_NSTR, TRS.get_string(in_node, "PLAN_START_DATE"));
    LOG_add("plan_end_date", MP_NSTR, TRS.get_string(in_node, "PLAN_END_DATE"));
    LOG_add("start_time", MP_NSTR, TRS.get_string(in_node, "START_TIME"));
    LOG_add("end_time", MP_NSTR, TRS.get_string(in_node, "END_TIME"));
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
    if(COM_proc_user_routine("CJCM", "CJCM_Update_Job_Change_Status",
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

    if(CJCM_Update_Job_Change_Status_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//DELETE 인 경우
	if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
		//CJCMITMHIS Insert 추가
		TRS.add_char(in_node, "TRAN_FLAG", 'D');
		if (CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//JOB ITEM DELETE 
		CDB_init_cjcmjobitm(&CJCMJOBITM);
		TRS.copy(CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID), in_node, "ORDER_ID");
		CDB_delete_cjcmjobitm(2, &CJCMJOBITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBSTS DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS.FACTORY), CJCMJOBSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS.ORDER_ID), CJCMJOBSTS.ORDER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		
		CDB_init_cjcmjobsts(&CJCMJOBSTS);
		TRS.copy(CJCMJOBSTS.FACTORY, sizeof(CJCMJOBSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID), in_node, "ORDER_ID");
		CDB_delete_cjcmjobsts(1, &CJCMJOBSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBSTS DELETE", MP_NVST);
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
	else 
	{
		CDB_init_cjcmjobsts(&CJCMJOBSTS);
		TRS.copy(CJCMJOBSTS.FACTORY, sizeof(CJCMJOBSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID), in_node, "ORDER_ID");
		TRS.copy(CJCMJOBSTS.MAT_ID, sizeof(CJCMJOBSTS.MAT_ID), in_node, "MAT_ID");
		TRS.copy(CJCMJOBSTS.LINE_ID, sizeof(CJCMJOBSTS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CJCMJOBSTS.ORD_START_DATE, sizeof(CJCMJOBSTS.ORD_START_DATE), in_node, "ORD_START_DATE");
		TRS.copy(CJCMJOBSTS.MANAGER, sizeof(CJCMJOBSTS.MANAGER), in_node, "MANAGER");
		TRS.copy(CJCMJOBSTS.DEPT_CODE, sizeof(CJCMJOBSTS.DEPT_CODE), in_node, "DEPT_CODE");
		TRS.copy(CJCMJOBSTS.PLAN_START_DATE, sizeof(CJCMJOBSTS.PLAN_START_DATE), in_node, "PLAN_START_DATE");
		TRS.copy(CJCMJOBSTS.PLAN_END_DATE, sizeof(CJCMJOBSTS.PLAN_END_DATE), in_node, "PLAN_END_DATE");
		TRS.copy(CJCMJOBSTS.START_TIME, sizeof(CJCMJOBSTS.START_TIME), in_node, "START_TIME");
		TRS.copy(CJCMJOBSTS.END_TIME, sizeof(CJCMJOBSTS.END_TIME), in_node, "END_TIME");
		CJCMJOBSTS.STATUS = TRS.get_char(in_node, "STATUS");
		CJCMJOBSTS.ALARM_FLAG = TRS.get_char(in_node, "ALARM_FLAG");
		TRS.copy(CJCMJOBSTS.ALARM_CODE, sizeof(CJCMJOBSTS.ALARM_CODE), in_node, "ALARM_CODE");
		TRS.copy(CJCMJOBSTS.CMF_1, sizeof(CJCMJOBSTS.CMF_1), in_node, "CMF_1");
		TRS.copy(CJCMJOBSTS.CMF_2, sizeof(CJCMJOBSTS.CMF_2), in_node, "CMF_2");
		TRS.copy(CJCMJOBSTS.CMF_3, sizeof(CJCMJOBSTS.CMF_3), in_node, "CMF_3");
		TRS.copy(CJCMJOBSTS.CMF_4, sizeof(CJCMJOBSTS.CMF_4), in_node, "CMF_4");
		TRS.copy(CJCMJOBSTS.CMF_5, sizeof(CJCMJOBSTS.CMF_5), in_node, "CMF_5");
		TRS.copy(CJCMJOBSTS.CMF_6, sizeof(CJCMJOBSTS.CMF_6), in_node, "CMF_6");
		TRS.copy(CJCMJOBSTS.CMF_7, sizeof(CJCMJOBSTS.CMF_7), in_node, "CMF_7");
		TRS.copy(CJCMJOBSTS.CMF_8, sizeof(CJCMJOBSTS.CMF_8), in_node, "CMF_8");
		TRS.copy(CJCMJOBSTS.CMF_9, sizeof(CJCMJOBSTS.CMF_9), in_node, "CMF_9");
		TRS.copy(CJCMJOBSTS.CMF_10, sizeof(CJCMJOBSTS.CMF_10), in_node, "CMF_10");
		TRS.copy(CJCMJOBSTS.CREATE_USER_ID, sizeof(CJCMJOBSTS.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		TRS.copy(CJCMJOBSTS.CREATE_TIME, sizeof(CJCMJOBSTS.CREATE_TIME), in_node, "CREATE_TIME");
		TRS.copy(CJCMJOBSTS.UPDATE_USER_ID, sizeof(CJCMJOBSTS.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
		TRS.copy(CJCMJOBSTS.UPDATE_TIME, sizeof(CJCMJOBSTS.UPDATE_TIME), in_node, "UPDATE_TIME");
		if(TRS.get_char(in_node, "PROC_STEP") == MP_STEP_CREATE)
		{
			TRS.copy(CJCMJOBSTS.CREATE_USER_ID, sizeof(CJCMJOBSTS.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CJCMJOBSTS.CREATE_TIME, s_sys_time, sizeof(CJCMJOBSTS.CREATE_TIME));
			CDB_insert_cjcmjobsts(&CJCMJOBSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CJCMJOBSTS INSERT", MP_NVST);
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
		else
		{
			TRS.copy(CJCMJOBSTS.UPDATE_USER_ID, sizeof(CJCMJOBSTS.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CJCMJOBSTS.UPDATE_TIME, s_sys_time, sizeof(CJCMJOBSTS.UPDATE_TIME));

			CDB_update_cjcmjobsts(1, &CJCMJOBSTS);
			if(DB_error_code != DB_SUCCESS)
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

		i_item_count = TRS.get_item_count(in_node, "JOB_CHANGE_ITEM_LIST");
		item_list = TRS.get_list(in_node, "JOB_CHANGE_ITEM_LIST");
		for(i = 0; i < i_item_count; i++)
        {
			CDB_init_cjcmjobitm(&CJCMJOBITM);
			memcpy(CJCMJOBITM.FACTORY, CJCMJOBSTS.FACTORY, sizeof(CJCMJOBITM.FACTORY));
			memcpy(CJCMJOBITM.ORDER_ID, CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID));
			TRS.copy(CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE), item_list[i], "ITEM_CODE");
			
			CDB_select_cjcmjobitm(1, &CJCMJOBITM);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "CMN-0003");
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
				// INSERT 
				TRS.copy(CJCMJOBITM.RESPONSIBILITY, sizeof(CJCMJOBITM.RESPONSIBILITY), item_list[i], "RESPONSIBILITY");
				TRS.copy(CJCMJOBITM.DEPT_CODE, sizeof(CJCMJOBITM.DEPT_CODE), item_list[i], "DEPT_CODE");
				TRS.copy(CJCMJOBITM.PLAN_START_DATE, sizeof(CJCMJOBITM.PLAN_START_DATE), item_list[i], "PLAN_START_DATE");
				TRS.copy(CJCMJOBITM.PLAN_END_DATE, sizeof(CJCMJOBITM.PLAN_END_DATE), item_list[i], "PLAN_END_DATE");
				TRS.copy(CJCMJOBITM.ALARM_CODE, sizeof(CJCMJOBITM.ALARM_CODE), item_list[i], "ALARM_CODE");
				CJCMJOBITM.ALARM_FLAG = 'Y';
				CJCMJOBITM.STATUS = TRS.get_char(item_list[i], "STATUS");
				CJCMJOBITM.AUTO_FLAG = TRS.get_char(item_list[i], "AUTO_FLAG");
				TRS.copy(CJCMJOBITM.CMF_1, sizeof(CJCMJOBITM.CMF_1), item_list[i], "CMF_1");
				TRS.copy(CJCMJOBITM.CMF_2, sizeof(CJCMJOBITM.CMF_2), item_list[i], "CMF_2");
				TRS.copy(CJCMJOBITM.CMF_3, sizeof(CJCMJOBITM.CMF_3), item_list[i], "CMF_3");
				TRS.copy(CJCMJOBITM.CMF_4, sizeof(CJCMJOBITM.CMF_4), item_list[i], "CMF_4");
				TRS.copy(CJCMJOBITM.CMF_5, sizeof(CJCMJOBITM.CMF_5), item_list[i], "CMF_5");
				TRS.copy(CJCMJOBITM.CMF_6, sizeof(CJCMJOBITM.CMF_6), item_list[i], "CMF_6");
				TRS.copy(CJCMJOBITM.CMF_7, sizeof(CJCMJOBITM.CMF_7), item_list[i], "CMF_7");
				TRS.copy(CJCMJOBITM.CMF_8, sizeof(CJCMJOBITM.CMF_8), item_list[i], "CMF_8");
				TRS.copy(CJCMJOBITM.CMF_9, sizeof(CJCMJOBITM.CMF_9), item_list[i], "CMF_9");
				TRS.copy(CJCMJOBITM.CMF_10, sizeof(CJCMJOBITM.CMF_10), item_list[i], "CMF_10");
				//TRS.copy(CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID), item_list[i], "CREATE_USER_ID");
				//TRS.copy(CJCMJOBITM.CREATE_TIME, sizeof(CJCMJOBITM.CREATE_TIME), item_list[i], "CREATE_TIME");
				//TRS.copy(CJCMJOBITM.UPDATE_USER_ID, sizeof(CJCMJOBITM.UPDATE_USER_ID), item_list[i], "UPDATE_USER_ID");
				//TRS.copy(CJCMJOBITM.UPDATE_TIME, sizeof(CJCMJOBITM.UPDATE_TIME), item_list[i], "UPDATE_TIME");
				TRS.copy(CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CJCMJOBITM.CREATE_TIME, s_sys_time, sizeof(CJCMJOBITM.CREATE_TIME));
				CDB_insert_cjcmjobitm(&CJCMJOBITM);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "CMN-0003");
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
			}
			else
			{
				// UPDATE
				TRS.copy(CJCMJOBITM.RESPONSIBILITY, sizeof(CJCMJOBITM.RESPONSIBILITY), item_list[i], "RESPONSIBILITY");
				TRS.copy(CJCMJOBITM.DEPT_CODE, sizeof(CJCMJOBITM.DEPT_CODE), item_list[i], "DEPT_CODE");
				TRS.copy(CJCMJOBITM.PLAN_START_DATE, sizeof(CJCMJOBITM.PLAN_START_DATE), item_list[i], "PLAN_START_DATE");
				TRS.copy(CJCMJOBITM.PLAN_END_DATE, sizeof(CJCMJOBITM.PLAN_END_DATE), item_list[i], "PLAN_END_DATE");
				TRS.copy(CJCMJOBITM.ALARM_CODE, sizeof(CJCMJOBITM.ALARM_CODE), item_list[i], "ALARM_CODE");
				CJCMJOBITM.ALARM_FLAG = 'Y';
				CJCMJOBITM.STATUS = TRS.get_char(item_list[i], "STATUS");
				CJCMJOBITM.AUTO_FLAG = TRS.get_char(item_list[i], "AUTO_FLAG");
				TRS.copy(CJCMJOBITM.CMF_1, sizeof(CJCMJOBITM.CMF_1), item_list[i], "CMF_1");
				TRS.copy(CJCMJOBITM.CMF_2, sizeof(CJCMJOBITM.CMF_2), item_list[i], "CMF_2");
				TRS.copy(CJCMJOBITM.CMF_3, sizeof(CJCMJOBITM.CMF_3), item_list[i], "CMF_3");
				TRS.copy(CJCMJOBITM.CMF_4, sizeof(CJCMJOBITM.CMF_4), item_list[i], "CMF_4");
				TRS.copy(CJCMJOBITM.CMF_5, sizeof(CJCMJOBITM.CMF_5), item_list[i], "CMF_5");
				TRS.copy(CJCMJOBITM.CMF_6, sizeof(CJCMJOBITM.CMF_6), item_list[i], "CMF_6");
				TRS.copy(CJCMJOBITM.CMF_7, sizeof(CJCMJOBITM.CMF_7), item_list[i], "CMF_7");
				TRS.copy(CJCMJOBITM.CMF_8, sizeof(CJCMJOBITM.CMF_8), item_list[i], "CMF_8");
				TRS.copy(CJCMJOBITM.CMF_9, sizeof(CJCMJOBITM.CMF_9), item_list[i], "CMF_9");
				TRS.copy(CJCMJOBITM.CMF_10, sizeof(CJCMJOBITM.CMF_10), item_list[i], "CMF_10");
				TRS.copy(CJCMJOBITM.UPDATE_USER_ID, sizeof(CJCMJOBITM.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CJCMJOBITM.UPDATE_TIME, s_sys_time, sizeof(CJCMJOBITM.UPDATE_TIME));

				CDB_update_cjcmjobitm(3, &CJCMJOBITM);
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
				TRS.add_char(in_node, "TRAN_FLAG", 'U');
			}

			//CJCMITMHIS Insert 추가				
			TRS.set_string(in_node, "ITEM_CODE",  CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
			if (CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Update_Job_Change_Status",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CJCM_Update_Job_Change_Status_Validation()
        - Main sub function of "CJCM_UPDATE_JOB_CHANGE_STATUS" function
        - Check the condition for create/update/delete Job_Change_Status
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Update_Job_Change_Status_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD1") == MP_FALSE)
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

    CDB_init_cjcmjobsts(&CJCMJOBSTS);
    TRS.copy(CJCMJOBSTS.FACTORY, sizeof(CJCMJOBSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID), in_node, "ORDER_ID");
    CDB_select_cjcmjobsts(1, &CJCMJOBSTS);
	if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
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

            TRS.add_fieldmsg(out_node, "CJCMJOBSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS.FACTORY), CJCMJOBSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS.ORDER_ID), CJCMJOBSTS.ORDER_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
	}
	else
	{
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_char(in_node, "PROC_STEP", MP_STEP_UPDATE);
		}
		else
		{
			TRS.add_char(in_node, "PROC_STEP", MP_STEP_CREATE);
		}
	}

    return MP_TRUE;
}

