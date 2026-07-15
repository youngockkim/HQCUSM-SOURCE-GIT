/******************************************************************************'

    System      : MESplus
    Module      : JCM
    File Name   : CJCM_check_job_change_item.c
    Description : Check Job_Change_Item List function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Check_Job_Change_Item()
            + Check Job_Change_Item definition List
        - CJCM_CHECK_JOB_CHANGE_ITEM()
            + Main sub function of cJCM_cHECK_Job_Change_Item function
            + cHECK Job_Change_Item definition List
    Detail Description
        - CJCM_CHECK_JOB_CHANGE_ITEM()
            + h_proc_step
                + 1 : Check Job_Change_Item definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/17             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"


/*******************************************************************************
    CJCM_Check_Job_Change_Item()
        - Check Job_Change_Item definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Check_Job_Change_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_CHECK_JOB_CHANGE_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_CHECK_JOB_CHANGE_ITEM", out_node); 

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
    CJCM_CHECK_JOB_CHANGE_ITEM()
        - Main sub function of "CCM_Check_Job_Change_Item" function
        - Check Job_Change_Item definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_CHECK_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBITM_TAG CJCMJOBITM;
	struct CJCMJOBITM_TAG CJCMJOBITM_o;
	struct CJCMITMDEF_TAG CJCMITMDEF;

	char   s_sys_time[14];
    int i_case;

	char s_sql[4000];
	char s_sql_tmp[4000];
	char c_check_flag;
	char s_order_id[25];
	char s_err_code[50];
	int row_count;

    LOG_head("CJCM_CHECK_JOB_CHANGE_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);



	if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
		TRS.set_string(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
    }

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

    i_case = 2;
    CDB_init_cjcmjobitm(&CJCMJOBITM);
    TRS.copy(CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY), in_node, IN_FACTORY);
	memcpy(CJCMJOBITM.PLAN_END_DATE, "20230801", sizeof(CJCMJOBITM.PLAN_END_DATE));
	//memcpy(CJCMJOBITM.PLAN_END_DATE, s_sys_time, sizeof(CJCMJOBITM.PLAN_END_DATE));
	CJCMJOBITM.AUTO_FLAG = 'Y';
	CJCMJOBITM.STATUS = 'E'; // E(End)가 아닌 것 조회
    CDB_open_cjcmjobitm(i_case, &CJCMJOBITM);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMJOBITM OPEN", MP_NVST);
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
	
    while(1)
    {
        CDB_fetch_cjcmjobitm(i_case, &CJCMJOBITM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cjcmjobitm(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBITM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBITM.FACTORY), CJCMJOBITM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBITM.ORDER_ID), CJCMJOBITM.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMJOBITM.ITEM_CODE), CJCMJOBITM.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cjcmjobitm(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		

		CDB_init_cjcmitmdef(&CJCMITMDEF);
		TRS.copy(CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(CJCMITMDEF.ITEM_CODE, CJCMJOBITM.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE));
		CDB_select_cjcmitmdef(1, &CJCMITMDEF);
		if(DB_error_code == DB_SUCCESS)
		{

			row_count = 0;
			c_check_flag = 'W'; //Wait			
			memset(s_err_code, ' ', sizeof(s_err_code));
			memset(s_order_id, ' ', sizeof(s_order_id));
			memset(s_sql, ' ', sizeof(s_sql));
			memset(s_sql_tmp, ' ', sizeof(s_sql_tmp));
			COM_memcpy_add_null(s_sql_tmp, CJCMITMDEF.SQL_TEXT, sizeof(CJCMITMDEF.SQL_TEXT));
			COM_memcpy_add_null(s_order_id, CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID));

			sprintf(s_sql, s_sql_tmp, s_order_id);

			DBC_execute_query2(s_sql);
			if(DB_error_code == DB_SUCCESS)
            {
				while(1)
                {
					DBC_get_next();
                    if(DB_error_code != DB_SUCCESS)
                    {
                        DBC_close_dsql();
                        break;
                    }
					row_count++;
				}
				if (row_count > 0)
					c_check_flag = 'E'; // End
				else
					c_check_flag = 'F';	// Fail	
			}
			else
			{
				COM_itoa(s_err_code, DB_error_code, 10);
				c_check_flag = 'F';	// Fail		
				DBC_close_dsql();
			}			

			if (c_check_flag != 'W') 
			{
				CDB_init_cjcmjobitm(&CJCMJOBITM_o);
				memcpy(CJCMJOBITM_o.FACTORY, CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM_o.FACTORY));
				memcpy(CJCMJOBITM_o.ORDER_ID, CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM_o.ORDER_ID));
				memcpy(CJCMJOBITM_o.ITEM_CODE, CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM_o.ITEM_CODE));
				CDB_select_cjcmjobitm_for_update(1, &CJCMJOBITM_o);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "CMN-0003");
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

				/*if(COM_isnullspace(CJCMJOBITM.START_TIME) == MP_TRUE)
				{
					 memcpy(CJCMJOBITM.START_TIME, s_sys_time, sizeof(CJCMJOBITM.START_TIME));
				}*/
				memcpy(CJCMJOBITM.START_TIME, s_sys_time, sizeof(CJCMJOBITM.START_TIME));
				if(c_check_flag == 'E')
				{
					memcpy(CJCMJOBITM.END_TIME, s_sys_time, sizeof(CJCMJOBITM.END_TIME));
					CJCMJOBITM.WORK_TIME = 0;
				}
				else
				{
					memcpy(CJCMJOBITM.CMF_1, s_err_code, sizeof(CJCMJOBITM.CMF_1));
				}
				CJCMJOBITM.STATUS = c_check_flag;
				TRS.copy(CJCMJOBITM.UPDATE_USER_ID, sizeof(CJCMJOBITM.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CJCMJOBITM.UPDATE_TIME, s_sys_time, sizeof(CJCMJOBITM.UPDATE_TIME));

				CDB_update_cjcmjobitm(2, &CJCMJOBITM);
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
			}
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


