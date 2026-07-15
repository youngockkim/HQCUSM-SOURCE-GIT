/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_create_job_change_master.c
    Description : Job_Change_Master Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Create_Job_Change_Master()
            + Create/Update/Delete Job_Change_Master definition
        - CJCM_CREATE_JOB_CHANGE_MASTER()
            + Main sub function of CJCM_Create_Job_Change_Master function
            + Create/Update/Delete Job_Change_Master definition
        - CJCM_Create_Job_Change_Master_Validation()
            + Main sub function of CJCM_CREATE_JOB_CHANGE_MASTER function
            + Check the condition for create/update/delete Job_Change_Master
    Detail Description
        - CJCM_CREATE_JOB_CHANGE_MASTER()
            + h_proc_step
                + MP_STEP_CREATE : Create Job_Change_Master definition
                + MP_STEP_UPDATE : Update Job_Change_Master definition
                + MP_STEP_DELETE : Delete Job_Change_Master definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/08/07             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_Create_Job_Change_Master_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_Create_Job_Change_Master()
        - Create/Update/Delete Job_Change_Master definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Create_Job_Change_Master(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_CREATE_JOB_CHANGE_MASTER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_CREATE_JOB_CHANGE_MASTER", out_node);

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
    CJCM_CREATE_JOB_CHANGE_MASTER()
        - Main sub function of "CJCM_Create_Job_Change_Master" function
        - Create/Update/Delete Job_Change_Master definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_CREATE_JOB_CHANGE_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
	struct CWIPORDSTS_TAG CWIPORDSTS;
	struct CJCMJOBITM_TAG CJCMJOBITM;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CJCMITMDEF_TAG CJCMITMDEF; //변경 될수 도 있음. 

    char   s_sys_time[14];
	int    i_case;
	int    i_case2;

	char   s_start_date[8];
	char   s_end_date[8];
	double d_start_date;
	double d_end_date;
	char   s_line_code[30];

    LOG_head("CJCM_CREATE_JOB_CHANGE_MASTER");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));    
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Create_Job_Change_Master",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

	if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
		TRS.set_string(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(s_start_date, ' ', sizeof(s_start_date));
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

	memcpy(s_start_date, s_sys_time, sizeof(s_start_date));

	i_case = 104;
	i_case2 = 2;
	CDB_init_cwipordsts(&CWIPORDSTS);
	TRS.copy(CWIPORDSTS.FACTORY, sizeof(CWIPORDSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(CWIPORDSTS.START_DATE, s_start_date, sizeof(s_start_date));
	//memcpy(CWIPORDSTS.START_DATE, "20230801", sizeof(s_start_date)); //TEST 용
	CDB_open_cwipordsts(i_case, &CWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPORDSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDSTS.FACTORY), CWIPORDSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "START_DATE", MP_STR, sizeof(CWIPORDSTS.START_DATE), CWIPORDSTS.START_DATE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	while(1)
    {
        CDB_fetch_cwipordsts(i_case, &CWIPORDSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipordsts(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CWIPORDSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDSTS.FACTORY), CWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwipordsts(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		memset(s_line_code, ' ', sizeof(s_line_code));

		d_start_date = 0; 
		d_end_date = 0;

		//MES LINE_ID 조회
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		memcpy(MGCMTBLDAT.DATA_2, CWIPORDSTS.WORK_CENTER, sizeof(CWIPORDSTS.WORK_CENTER));
		DBC_select_mgcmtbldat(102, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			memcpy(s_line_code, MGCMTBLDAT.KEY_1, sizeof(s_line_code));
		}


		CDB_init_cjcmitmdef(&CJCMITMDEF);
		memcpy(CJCMITMDEF.FACTORY, CWIPORDSTS.FACTORY, sizeof(CJCMITMDEF.FACTORY));
		memcpy(CJCMITMDEF.CMF_1, CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
		CDB_open_cjcmitmdef(i_case2, &CJCMITMDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "CMN-0003");
			TRS.add_fieldmsg(out_node, "CJCMITMDEF OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_cjcmitmdef(i_case2, &CJCMITMDEF);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cjcmitmdef(i_case2);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CJCMITMDEF FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cjcmitmdef(i_case2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			memset(s_start_date, ' ', sizeof(s_start_date));
			memset(s_end_date, ' ', sizeof(s_end_date));
			
			//ITEM, LINE 별 담당자 조회 
			
			
			//JOB ITEM Insert
			CDB_init_cjcmjobitm(&CJCMJOBITM);
			memcpy(CJCMJOBITM.FACTORY, CWIPORDSTS.FACTORY, sizeof(CJCMJOBITM.FACTORY));
			memcpy(CJCMJOBITM.ORDER_ID, CWIPORDSTS.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID));
			memcpy(CJCMJOBITM.ITEM_CODE, CJCMITMDEF.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
			CJCMJOBITM.AUTO_FLAG = CJCMITMDEF.AUTO_FLAG;
			memcpy(CJCMJOBITM.DEPT_CODE, CJCMITMDEF.DEPT_CODE, sizeof(CJCMJOBITM.DEPT_CODE));
			//ITEM, LINE 별 담당자 조회 
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_RESPONSIBILITY", strlen("@JCM_RESPONSIBILITY"));
			memcpy(MGCMTBLDAT.KEY_1, s_line_code, sizeof(MGCMTBLDAT.KEY_1));
			memcpy(MGCMTBLDAT.KEY_2, CJCMITMDEF.DEPT_CODE, sizeof(CJCMITMDEF.DEPT_CODE));
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				memcpy(CJCMJOBITM.RESPONSIBILITY, MGCMTBLDAT.DATA_1, sizeof(CJCMJOBITM.RESPONSIBILITY));
			}
			////담당장의 부서 정보 확인
			//DBC_init_mgcmtbldat(&MGCMTBLDAT);
			//TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			//memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_USER_INFO", strlen("@JCM_USER_INFO"));
			//memcpy(MGCMTBLDAT.KEY_1, CJCMJOBITM.RESPONSIBILITY, sizeof(CJCMJOBITM.RESPONSIBILITY));
			//DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			//if(DB_error_code == DB_SUCCESS)
			//{
			//	memcpy(CJCMJOBITM.DEPT_CODE, MGCMTBLDAT.DATA_2, sizeof(CJCMJOBITM.DEPT_CODE));
			//}

			//memcpy(CJCMJOBITM.RESPONSIBILITY, CJCMITMDEF.RESPONSIBILITY, sizeof(CJCMJOBITM.RESPONSIBILITY));
			//memcpy(CJCMJOBITM.DEPT_CODE, CJCMITMDEF.DEPT_CODE, sizeof(CJCMJOBITM.DEPT_CODE));
			//memcpy(CJCMJOBITM.PLAN_START_DATE, CJCMITMDEF.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
			//memcpy(CJCMJOBITM.ITEM_CODE, CJCMITMDEF.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
			//memcpy(CJCMJOBITM.ITEM_CODE, CJCMITMDEF.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
			//memcpy(CJCMJOBITM.ITEM_CODE, CJCMITMDEF.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));

			if (d_start_date == 0) 
				d_start_date = CJCMITMDEF.PLAN_START_DAYS_BEFORE;

			if (d_start_date > CJCMITMDEF.PLAN_START_DAYS_BEFORE)
				d_start_date = CJCMITMDEF.PLAN_START_DAYS_BEFORE;

			if (d_end_date < CJCMITMDEF.PLAN_END_DAYS_BEFORE)
				d_end_date = CJCMITMDEF.PLAN_END_DAYS_BEFORE;

			COM_ultoa(s_start_date, CJCMITMDEF.PLAN_START_DAYS_BEFORE, sizeof(s_start_date));
			COM_ultoa(s_end_date, CJCMITMDEF.PLAN_END_DAYS_BEFORE, sizeof(s_end_date));

			memcpy(CJCMJOBITM.PLAN_START_DATE, s_start_date, sizeof(CJCMJOBITM.PLAN_END_DATE));
			memcpy(CJCMJOBITM.PLAN_END_DATE, s_end_date, sizeof(CJCMJOBITM.PLAN_END_DATE));

			CJCMJOBITM.STATUS = 'W'; //Wating
			CJCMJOBITM.ALARM_FLAG = CJCMITMDEF.ALARM_FLAG;
			memcpy(CJCMJOBITM.CMF_1, CJCMITMDEF.CMF_1, sizeof(CJCMJOBITM.CMF_1));
			memcpy(CJCMJOBITM.ALARM_CODE, CJCMITMDEF.ALARM_CODE, sizeof(CJCMJOBITM.ALARM_CODE));
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
			TRS.add_string(in_node, "ORDER_ID",  CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID));
			TRS.add_string(in_node, "ITEM_CODE",  CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE));
			if (CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		COM_ultoa(s_start_date, d_start_date, (int)sizeof(s_start_date));
		COM_ultoa(s_end_date, d_end_date, (int)sizeof(s_end_date));

		//CJCMJOBSTS  Insert 
		CDB_init_cjcmjobsts(&CJCMJOBSTS);
		memcpy(CJCMJOBSTS.FACTORY, CWIPORDSTS.FACTORY, sizeof(CJCMJOBSTS.FACTORY));
		memcpy(CJCMJOBSTS.ORDER_ID, CWIPORDSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID));
		memcpy(CJCMJOBSTS.MAT_ID, CWIPORDSTS.MAT_ID, sizeof(CJCMJOBSTS.MAT_ID));
		//memcpy(CJCMJOBSTS.LINE_ID, CWIPORDSTS.LINE_ID, sizeof(CJCMJOBSTS.LINE_ID));
		memcpy(CJCMJOBSTS.ORD_START_DATE, CWIPORDSTS.START_DATE, sizeof(CJCMJOBSTS.ORD_START_DATE));
		memcpy(CJCMJOBSTS.PLAN_START_DATE, s_start_date, sizeof(CJCMJOBSTS.PLAN_START_DATE));
		memcpy(CJCMJOBSTS.PLAN_END_DATE, s_end_date, sizeof(CJCMJOBSTS.PLAN_END_DATE));
		CJCMJOBSTS.STATUS = 'W'; //Wating
		CJCMJOBSTS.ALARM_FLAG = 'Y';
		
		TRS.copy(CJCMJOBSTS.CREATE_USER_ID, sizeof(CJCMJOBSTS.CREATE_USER_ID), in_node, IN_USERID);
		memcpy(CJCMJOBSTS.CREATE_TIME, s_sys_time, sizeof(CJCMJOBSTS.CREATE_TIME));
		memcpy(CJCMJOBSTS.LINE_ID, s_line_code, sizeof(s_line_code));
		////MES LINE_ID 조회
		//DBC_init_mgcmtbldat(&MGCMTBLDAT);
		//TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		//memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		//memcpy(MGCMTBLDAT.DATA_2, CWIPORDSTS.WORK_CENTER, sizeof(MGCMTBLDAT.DATA_2));
		//DBC_select_mgcmtbldat(102, &MGCMTBLDAT);
		//if(DB_error_code == DB_SUCCESS)
		//{
		//	memcpy(CJCMJOBSTS.LINE_ID, MGCMTBLDAT.KEY_1, sizeof(CJCMJOBSTS.LINE_ID));
		//}

		////GCM 조회 @JCM_LINE_MANAGER
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_LINE_MANAGER", strlen("@JCM_LINE_MANAGER"));
		memcpy(MGCMTBLDAT.KEY_1, CJCMJOBSTS.LINE_ID, sizeof(MGCMTBLDAT.KEY_1));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			memcpy(CJCMJOBSTS.MANAGER, MGCMTBLDAT.DATA_1, sizeof(CJCMJOBSTS.MANAGER));
			memcpy(CJCMJOBSTS.ALARM_CODE, MGCMTBLDAT.DATA_3, sizeof(CJCMJOBSTS.ALARM_CODE));
		}

		////GCM 조회 @JCM_USER_INFO
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_USER_INFO", strlen("@JCM_USER_INFO"));
		memcpy(MGCMTBLDAT.KEY_1, CJCMJOBSTS.MANAGER, sizeof(CJCMJOBSTS.MANAGER));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			memcpy(CJCMJOBSTS.DEPT_CODE, MGCMTBLDAT.DATA_2, sizeof(CJCMJOBSTS.DEPT_CODE));
		}
		
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

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Create_Job_Change_Master",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CJCM_Create_Job_Change_Master_Validation()
        - Main sub function of "CJCM_CREATE_JOB_CHANGE_MASTER" function
        - Check the condition for create/update/delete Job_Change_Master
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Create_Job_Change_Master_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
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
        strcpy(s_msg_code, "WIP-0001");
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
        strcpy(s_msg_code, "WIP-0001");
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
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0018");
            TRS.add_fieldmsg(out_node, "CJCMJOBSTS SELECT", MP_NVST);
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

            TRS.add_fieldmsg(out_node, "CJCMJOBSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS.FACTORY), CJCMJOBSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS.ORDER_ID), CJCMJOBSTS.ORDER_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

