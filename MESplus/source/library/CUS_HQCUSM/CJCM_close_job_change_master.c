/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_close_job_change_master.c
    Description : Job_Change_Master Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Close_Job_Change_Master()
            + Create/Update/Delete Job_Change_Master definition
        - CJCM_CLOSE_JOB_CHANGE_MASTER()
            + Main sub function of CJCM_Close_Job_Change_Master function
            + Create/Update/Delete Job_Change_Master definition
        - CJCM_Close_Job_Change_Master_Validation()
            + Main sub function of CJCM_CLOSE_JOB_CHANGE_MASTER function
            + Check the condition for create/update/delete Job_Change_Master
    Detail Description
        - CJCM_CLOSE_JOB_CHANGE_MASTER()
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

int CJCM_Close_Job_Change_Master_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_Close_Job_Change_Master()
        - Create/Update/Delete Job_Change_Master definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Close_Job_Change_Master(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_CLOSE_JOB_CHANGE_MASTER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_CLOSE_JOB_CHANGE_MASTER", out_node);

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
    CJCM_CLOSE_JOB_CHANGE_MASTER()
        - Main sub function of "CJCM_Close_Job_Change_Master" function
        - Create/Update/Delete Job_Change_Master definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_CLOSE_JOB_CHANGE_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
    struct CJCMJOBSTS_TAG CJCMJOBSTS_o;
    char   s_sys_time[14];
	int i_case;

    LOG_head("CJCM_CLOSE_JOB_CHANGE_MASTER");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Close_Job_Change_Master",
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

    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
		TRS.set_string(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
    }

	//Order Start Date 기준 15일이 경과된 Job Change는 자동으로 Close 
	// 긴급 개발로 15일을 Query에 적용 (추 후 필요 시 GCM 으로 변경 필요)
	i_case = 2;
    CDB_init_cjcmjobsts(&CJCMJOBSTS_o);
    TRS.copy(CJCMJOBSTS_o.FACTORY, sizeof(CJCMJOBSTS_o.FACTORY), in_node, IN_FACTORY);
	CDB_open_cjcmjobsts(i_case, &CJCMJOBSTS_o);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMJOBSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS_o.FACTORY), CJCMJOBSTS_o.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {        
        CDB_fetch_cjcmjobsts(i_case, &CJCMJOBSTS_o);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cjcmjobsts(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS_o.FACTORY), CJCMJOBSTS_o.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS_o.ORDER_ID), CJCMJOBSTS_o.ORDER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cjcmjobsts(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        CDB_init_cjcmjobsts(&CJCMJOBSTS);
		memcpy(CJCMJOBSTS.FACTORY, CJCMJOBSTS_o.FACTORY, sizeof(CJCMJOBSTS.FACTORY));
		memcpy(CJCMJOBSTS.ORDER_ID, CJCMJOBSTS_o.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID));
		CJCMJOBSTS.STATUS = 'C';
		TRS.copy(CJCMJOBSTS.UPDATE_USER_ID, sizeof(CJCMJOBSTS.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CJCMJOBSTS.UPDATE_TIME, s_sys_time, sizeof(CJCMJOBSTS.UPDATE_TIME));
		CDB_update_cjcmjobsts(4, &CJCMJOBSTS);
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

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Close_Job_Change_Master",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 


