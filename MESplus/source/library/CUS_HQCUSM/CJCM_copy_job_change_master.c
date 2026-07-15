/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_copy_job_change_master.c
    Description : Job_Change_Master Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Copy_Job_Change_Master()
            + Create/Update/Delete Job_Change_Master definition
        - CJCM_COPY_JOB_CHANGE_MASTER()
            + Main sub function of CJCM_Copy_Job_Change_Master function
            + Create/Update/Delete Job_Change_Master definition
        - CJCM_Copy_Job_Change_Master_Validation()
            + Main sub function of CJCM_COPY_JOB_CHANGE_MASTER function
            + Check the condition for create/update/delete Job_Change_Master
    Detail Description
        - CJCM_COPY_JOB_CHANGE_MASTER()
            + h_proc_step
                + MP_STEP_CREATE : Create Job_Change_Master definition
                + MP_STEP_UPDATE : Update Job_Change_Master definition
                + MP_STEP_DELETE : Delete Job_Change_Master definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/10/27             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_Copy_Job_Change_Master_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_Copy_Job_Change_Master()
        - Create/Update/Delete Job_Change_Master definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Copy_Job_Change_Master(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_COPY_JOB_CHANGE_MASTER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_COPY_JOB_CHANGE_MASTER", out_node);

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
    CJCM_COPY_JOB_CHANGE_MASTER()
        - Main sub function of "CJCM_Copy_Job_Change_Master" function
        - Create/Update/Delete Job_Change_Master definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_COPY_JOB_CHANGE_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
    struct CJCMJOBSTS_TAG CJCMJOBSTS_s;
	struct CJCMJOBITM_TAG CJCMJOBITM;
    struct CJCMJOBITM_TAG CJCMJOBITM_o;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
    char   s_sys_time[14];
	int i_case;

    LOG_head("CJCM_COPY_JOB_CHANGE_MASTER");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
	LOG_add("to_order_id", MP_NSTR, TRS.get_string(in_node, "TO_ORDER_ID"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("ord_start_date", MP_NSTR, TRS.get_string(in_node, "ORD_START_DATE"));
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
    if(COM_proc_user_routine("CJCM", "CJCM_Copy_Job_Change_Master",
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

    if(CJCM_Copy_Job_Change_Master_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cjcmjobsts(&CJCMJOBSTS_s);
    TRS.copy(CJCMJOBSTS_s.FACTORY, sizeof(CJCMJOBSTS_s.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMJOBSTS_s.ORDER_ID, sizeof(CJCMJOBSTS_s.ORDER_ID), in_node, "ORDER_ID");
	CDB_select_cjcmjobsts(1, &CJCMJOBSTS_s);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMJOBSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS_s.FACTORY), CJCMJOBSTS_s.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS_s.ORDER_ID), CJCMJOBSTS_s.ORDER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	CDB_init_cjcmjobsts(&CJCMJOBSTS);
	memcpy(CJCMJOBSTS.FACTORY, CJCMJOBSTS_s.FACTORY, sizeof(CJCMJOBSTS.FACTORY));
	TRS.copy(CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID), in_node, "TO_ORDER_ID");
	memcpy(CJCMJOBSTS.MAT_ID, CJCMJOBSTS_s.MAT_ID, sizeof(CJCMJOBSTS.MAT_ID));
	TRS.copy(CJCMJOBSTS.LINE_ID, sizeof(CJCMJOBSTS.LINE_ID), in_node, "LINE_ID");
	memcpy(CJCMJOBSTS.ORD_START_DATE, CJCMJOBSTS_s.ORD_START_DATE, sizeof(CJCMJOBSTS.ORD_START_DATE));	
	memcpy(CJCMJOBSTS.DEPT_CODE, CJCMJOBSTS_s.DEPT_CODE, sizeof(CJCMJOBSTS.DEPT_CODE));
	memcpy(CJCMJOBSTS.PLAN_START_DATE, CJCMJOBSTS_s.PLAN_START_DATE, sizeof(CJCMJOBSTS.PLAN_START_DATE));
	memcpy(CJCMJOBSTS.PLAN_END_DATE, CJCMJOBSTS_s.PLAN_END_DATE, sizeof(CJCMJOBSTS.PLAN_END_DATE));
	//TRS.copy(CJCMJOBSTS.START_TIME, sizeof(CJCMJOBSTS.START_TIME), in_node, "START_TIME");
    //TRS.copy(CJCMJOBSTS.END_TIME, sizeof(CJCMJOBSTS.END_TIME), in_node, "END_TIME");
	CJCMJOBSTS.STATUS = 'W';
	CJCMJOBSTS.ALARM_FLAG = CJCMJOBSTS_s.ALARM_FLAG;
	//memcpy(CJCMJOBSTS.ALARM_CODE, CJCMJOBSTS_s.ALARM_CODE, sizeof(CJCMJOBSTS.ALARM_CODE));
	memcpy(CJCMJOBSTS.CMF_1, CJCMJOBSTS_s.CMF_1, sizeof(CJCMJOBSTS.CMF_1));
	memcpy(CJCMJOBSTS.CMF_2, CJCMJOBSTS_s.CMF_2, sizeof(CJCMJOBSTS.CMF_2));
	memcpy(CJCMJOBSTS.CMF_3, CJCMJOBSTS_s.CMF_3, sizeof(CJCMJOBSTS.CMF_3));
	memcpy(CJCMJOBSTS.CMF_4, CJCMJOBSTS_s.CMF_4, sizeof(CJCMJOBSTS.CMF_4));
	memcpy(CJCMJOBSTS.CMF_5, CJCMJOBSTS_s.CMF_5, sizeof(CJCMJOBSTS.CMF_5));
	memcpy(CJCMJOBSTS.CMF_6, CJCMJOBSTS_s.CMF_6, sizeof(CJCMJOBSTS.CMF_6));
	memcpy(CJCMJOBSTS.CMF_7, CJCMJOBSTS_s.CMF_7, sizeof(CJCMJOBSTS.CMF_7));
	memcpy(CJCMJOBSTS.CMF_8, CJCMJOBSTS_s.CMF_8, sizeof(CJCMJOBSTS.CMF_8));
	memcpy(CJCMJOBSTS.CMF_9, CJCMJOBSTS_s.CMF_9, sizeof(CJCMJOBSTS.CMF_9));
	memcpy(CJCMJOBSTS.CMF_10, CJCMJOBSTS_s.CMF_10, sizeof(CJCMJOBSTS.CMF_10));
	TRS.copy(CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID), in_node, IN_USERID);
    memcpy(CJCMJOBITM.CREATE_TIME, s_sys_time, sizeof(CJCMJOBITM.CREATE_TIME));
	
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	memcpy(MGCMTBLDAT.FACTORY, CJCMJOBSTS_s.FACTORY, sizeof(CJCMJOBSTS_s.FACTORY));
	memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_LINE_MANAGER", strlen("@JCM_LINE_MANAGER"));
	TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		memcpy(CJCMJOBSTS.MANAGER, MGCMTBLDAT.DATA_1, sizeof(CJCMJOBSTS.MANAGER));
		memcpy(CJCMJOBSTS.ALARM_CODE, MGCMTBLDAT.DATA_2, sizeof(CJCMJOBSTS.ALARM_CODE));
	}
	else
	{
		memcpy(CJCMJOBSTS.MANAGER, CJCMJOBSTS_s.MANAGER, sizeof(CJCMJOBSTS.MANAGER));
		memcpy(CJCMJOBSTS.ALARM_CODE, CJCMJOBSTS_s.ALARM_CODE, sizeof(CJCMJOBSTS.ALARM_CODE));
	}


	CDB_insert_cjcmjobsts(&CJCMJOBSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CJCM-0004");
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

	i_case = 1;
	CDB_init_cjcmjobitm(&CJCMJOBITM_o);
	memcpy(CJCMJOBITM_o.FACTORY, CJCMJOBSTS_s.FACTORY, sizeof(CJCMJOBITM_o.FACTORY));
	memcpy(CJCMJOBITM_o.ORDER_ID, CJCMJOBSTS_s.ORDER_ID, sizeof(CJCMJOBITM_o.ORDER_ID));
    CDB_open_cjcmjobitm(i_case, &CJCMJOBITM_o);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMJOBITM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM_o.FACTORY), CJCMJOBITM_o.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM_o.ORDER_ID), CJCMJOBITM_o.ORDER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	while(1)
    {
        CDB_fetch_cjcmjobitm(i_case, &CJCMJOBITM_o);                                                                                                                                                                                                            
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cjcmjobitm(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBITM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM_o.FACTORY), CJCMJOBITM_o.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM_o.ORDER_ID), CJCMJOBITM_o.ORDER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cjcmjobitm(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		CDB_init_cjcmjobitm(&CJCMJOBITM);
		memcpy(CJCMJOBITM.FACTORY, CJCMJOBITM_o.FACTORY, sizeof(CJCMJOBITM.FACTORY));
		TRS.copy(CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID), in_node, "TO_ORDER_ID");
		memcpy(CJCMJOBITM.ITEM_CODE, CJCMJOBITM_o.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));		
		memcpy(CJCMJOBITM.DEPT_CODE, CJCMJOBITM_o.DEPT_CODE, sizeof(CJCMJOBITM.DEPT_CODE));
		memcpy(CJCMJOBITM.PLAN_START_DATE, CJCMJOBITM_o.PLAN_START_DATE, sizeof(CJCMJOBITM.PLAN_START_DATE));
		memcpy(CJCMJOBITM.PLAN_END_DATE, CJCMJOBITM_o.PLAN_END_DATE, sizeof(CJCMJOBITM.PLAN_END_DATE));
		memcpy(CJCMJOBITM.ALARM_CODE, CJCMJOBITM_o.ALARM_CODE, sizeof(CJCMJOBITM.ALARM_CODE));
		CJCMJOBITM.WORK_TIME = 0;
		CJCMJOBITM.STATUS = 'W';
		CJCMJOBITM.ALARM_FLAG = CJCMJOBITM_o.ALARM_FLAG;
		TRS.copy(CJCMJOBITM.CMF_1, sizeof(CJCMJOBITM.CMF_1), in_node, "LINE_ID");
		memcpy(CJCMJOBITM.CMF_2, CJCMJOBITM_o.CMF_2, sizeof(CJCMJOBITM.CMF_2));
		memcpy(CJCMJOBITM.CMF_3, CJCMJOBITM_o.CMF_3, sizeof(CJCMJOBITM.CMF_3));
		memcpy(CJCMJOBITM.CMF_4, CJCMJOBITM_o.CMF_4, sizeof(CJCMJOBITM.CMF_4));
		memcpy(CJCMJOBITM.CMF_5, CJCMJOBITM_o.CMF_5, sizeof(CJCMJOBITM.CMF_5));
		memcpy(CJCMJOBITM.CMF_6, CJCMJOBITM_o.CMF_6, sizeof(CJCMJOBITM.CMF_6));
		memcpy(CJCMJOBITM.CMF_7, CJCMJOBITM_o.CMF_7, sizeof(CJCMJOBITM.CMF_7));
		memcpy(CJCMJOBITM.CMF_8, CJCMJOBITM_o.CMF_8, sizeof(CJCMJOBITM.CMF_8));
		memcpy(CJCMJOBITM.CMF_9, CJCMJOBITM_o.CMF_9, sizeof(CJCMJOBITM.CMF_9));
		memcpy(CJCMJOBITM.CMF_10, CJCMJOBITM_o.CMF_10, sizeof(CJCMJOBITM.CMF_10));
		TRS.copy(CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMJOBITM.CREATE_USER_ID), in_node, IN_USERID);
		memcpy(CJCMJOBITM.CREATE_TIME, s_sys_time, sizeof(CJCMJOBITM.CREATE_TIME));

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CJCMJOBITM_o.FACTORY, sizeof(CJCMJOBITM_o.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_RESPONSIBILITY", strlen("@JCM_RESPONSIBILITY"));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");
		memcpy(MGCMTBLDAT.KEY_2, CJCMJOBITM_o.DEPT_CODE, sizeof(CJCMJOBITM_o.DEPT_CODE));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			memcpy(CJCMJOBITM.RESPONSIBILITY, MGCMTBLDAT.DATA_1, sizeof(CJCMJOBITM.RESPONSIBILITY));
		}
		else
		{
			memcpy(CJCMJOBITM.RESPONSIBILITY, CJCMJOBITM_o.RESPONSIBILITY, sizeof(CJCMJOBITM.RESPONSIBILITY));
		}

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
		////CJCMITMHIS Insert 추가
		//TRS.add_char(in_node, "TRAN_FLAG", 'I');
		//TRS.add_string(in_node, "ORDER_ID",  CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID));
		//TRS.add_string(in_node, "ITEM_CODE",  CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
		//if (CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node) == MP_FALSE)
		//{
		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	return MP_FALSE;
		//}
    }


    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Copy_Job_Change_Master",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CJCM_Copy_Job_Change_Master_Validation()
        - Main sub function of "CJCM_COPY_JOB_CHANGE_MASTER" function
        - Check the condition for create/update/delete Job_Change_Master
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Copy_Job_Change_Master_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "I") == MP_FALSE) //IUD --> I만 받음
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
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
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

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    //else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    //{

    //    /*if(DB_error_code != DB_SUCCESS)
    //    {
    //        if(DB_error_code == DB_NOT_FOUND)
    //        {
    //            strcpy(s_msg_code, "CMN-0004");
    //            gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        }
    //        else
    //        {
    //            strcpy(s_msg_code, "CMN-0003");
    //            TRS.add_dberrmsg(out_node, DB_error_msg);

    //            gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        }

    //        TRS.add_fieldmsg(out_node, "CJCMJOBSTS SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS.FACTORY), CJCMJOBSTS.FACTORY);
    //        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS.ORDER_ID), CJCMJOBSTS.ORDER_ID);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;
    //        return MP_FALSE;
    //    }*/
    //}

    return MP_TRUE;
}

