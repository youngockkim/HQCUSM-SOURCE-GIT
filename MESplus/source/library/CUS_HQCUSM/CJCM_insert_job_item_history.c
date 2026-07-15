/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_insert_job_item_history.c
    Description : Job_Item_History Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Insert_Job_Item_History()
            + Create/Update/Delete Job_Item_History definition
        - CJCM_INSERT_JOB_ITEM_HISTORY()
            + Main sub function of CJCM_Insert_Job_Item_History function
            + Create/Update/Delete Job_Item_History definition
        - CJCM_Insert_Job_Item_History_Validation()
            + Main sub function of CJCM_INSERT_JOB_ITEM_HISTORY function
            + Check the condition for create/update/delete Job_Item_History
    Detail Description
        - CJCM_INSERT_JOB_ITEM_HISTORY()
            + h_proc_step
                + MP_STEP_CREATE : Create Job_Item_History definition
                + MP_STEP_UPDATE : Update Job_Item_History definition
                + MP_STEP_DELETE : Delete Job_Item_History definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/08/10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_Insert_Job_Item_History_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_Insert_Job_Item_History()
        - Create/Update/Delete Job_Item_History definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Insert_Job_Item_History(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_INSERT_JOB_ITEM_HISTORY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_INSERT_JOB_ITEM_HISTORY", out_node);

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
    CJCM_INSERT_JOB_ITEM_HISTORY()
        - Main sub function of "CJCM_Insert_Job_Item_History" function
        - Create/Update/Delete Job_Item_History definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_INSERT_JOB_ITEM_HISTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMITMHIS_TAG CJCMITMHIS;
    struct CJCMJOBITM_TAG CJCMJOBITM;
    char   s_sys_time[14];
	int    i_case;

    LOG_head("CJCM_INSERT_JOB_ITEM_HISTORY");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));   
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Insert_Job_Item_History",
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

    //if(CJCM_Insert_Job_Item_History_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    //{
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

	if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
	{
		i_case = 1;
	}
	else
	{
		i_case = 3;
	}
	

    CDB_init_cjcmjobitm(&CJCMJOBITM);
    TRS.copy(CJCMJOBITM.FACTORY, sizeof(CJCMJOBITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMJOBITM.ORDER_ID, sizeof(CJCMJOBITM.ORDER_ID), in_node, "ORDER_ID");
	TRS.copy(CJCMJOBITM.ITEM_CODE, sizeof(CJCMJOBITM.ITEM_CODE), in_node, "ITEM_CODE");
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

		CDB_init_cjcmitmhis(&CJCMITMHIS);
		memcpy(CJCMITMHIS.FACTORY, CJCMJOBITM.FACTORY, sizeof(CJCMITMHIS.FACTORY));
		memcpy(CJCMITMHIS.ORDER_ID, CJCMJOBITM.ORDER_ID, sizeof(CJCMITMHIS.ORDER_ID));
		memcpy(CJCMITMHIS.ITEM_CODE, CJCMJOBITM.ITEM_CODE, sizeof(CJCMITMHIS.ITEM_CODE));
		memcpy(CJCMITMHIS.TRAN_TIME, s_sys_time, sizeof(CJCMITMHIS.TRAN_TIME));
		CJCMITMHIS.TRAN_FLAG = TRS.get_char(in_node, "TRAN_FLAG");
		CJCMITMHIS.AUTO_FLAG = CJCMJOBITM.AUTO_FLAG;
		memcpy(CJCMITMHIS.RESPONSIBILITY, CJCMJOBITM.RESPONSIBILITY, sizeof(CJCMITMHIS.RESPONSIBILITY));
		memcpy(CJCMITMHIS.DEPT_CODE, CJCMJOBITM.DEPT_CODE, sizeof(CJCMITMHIS.DEPT_CODE));
		memcpy(CJCMITMHIS.PLAN_START_DATE, CJCMJOBITM.PLAN_START_DATE, sizeof(CJCMITMHIS.PLAN_START_DATE));
		memcpy(CJCMITMHIS.PLAN_END_DATE, CJCMJOBITM.PLAN_END_DATE, sizeof(CJCMITMHIS.PLAN_END_DATE));
		memcpy(CJCMITMHIS.START_TIME, CJCMJOBITM.START_TIME, sizeof(CJCMITMHIS.START_TIME));
		memcpy(CJCMITMHIS.END_TIME, CJCMJOBITM.END_TIME, sizeof(CJCMITMHIS.END_TIME));
		CJCMITMHIS.WORK_TIME = CJCMJOBITM.WORK_TIME;
		CJCMITMHIS.STATUS = CJCMJOBITM.STATUS;
		CJCMITMHIS.ALARM_FLAG = CJCMJOBITM.ALARM_FLAG;
		memcpy(CJCMITMHIS.ALARM_CODE, CJCMJOBITM.ALARM_CODE, sizeof(CJCMITMHIS.ALARM_CODE));
		memcpy(CJCMITMHIS.CMF_1, CJCMJOBITM.CMF_1, sizeof(CJCMITMHIS.CMF_1));
		memcpy(CJCMITMHIS.CMF_2, CJCMJOBITM.CMF_2, sizeof(CJCMITMHIS.CMF_2));
		memcpy(CJCMITMHIS.CMF_3, CJCMJOBITM.CMF_3, sizeof(CJCMITMHIS.CMF_3));
		memcpy(CJCMITMHIS.CMF_4, CJCMJOBITM.CMF_4, sizeof(CJCMITMHIS.CMF_4));
		memcpy(CJCMITMHIS.CMF_5, CJCMJOBITM.CMF_5, sizeof(CJCMITMHIS.CMF_5));
		memcpy(CJCMITMHIS.CMF_6, CJCMJOBITM.CMF_6, sizeof(CJCMITMHIS.CMF_6));
		memcpy(CJCMITMHIS.CMF_7, CJCMJOBITM.CMF_7, sizeof(CJCMITMHIS.CMF_7));
		memcpy(CJCMITMHIS.CMF_8, CJCMJOBITM.CMF_8, sizeof(CJCMITMHIS.CMF_8));
		memcpy(CJCMITMHIS.CMF_9, CJCMJOBITM.CMF_9, sizeof(CJCMITMHIS.CMF_9));
		memcpy(CJCMITMHIS.CMF_10, CJCMJOBITM.CMF_10, sizeof(CJCMITMHIS.CMF_10));
		memcpy(CJCMITMHIS.CREATE_USER_ID, CJCMJOBITM.CREATE_USER_ID, sizeof(CJCMITMHIS.CREATE_USER_ID));
		memcpy(CJCMITMHIS.CREATE_TIME, CJCMJOBITM.CREATE_TIME, sizeof(CJCMITMHIS.CREATE_TIME));
		memcpy(CJCMITMHIS.UPDATE_USER_ID, CJCMJOBITM.UPDATE_USER_ID, sizeof(CJCMITMHIS.UPDATE_USER_ID));
		memcpy(CJCMITMHIS.UPDATE_TIME, CJCMJOBITM.UPDATE_TIME, sizeof(CJCMITMHIS.UPDATE_TIME));
		CDB_insert_cjcmitmhis(&CJCMITMHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMITMHIS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMHIS.FACTORY), CJCMITMHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMITMHIS.ORDER_ID), CJCMITMHIS.ORDER_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMHIS.ITEM_CODE), CJCMITMHIS.ITEM_CODE);
            TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CJCMITMHIS.TRAN_TIME), CJCMITMHIS.TRAN_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_Insert_Job_Item_History",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CJCM_Insert_Job_Item_History_Validation()
        - Main sub function of "CJCM_INSERT_JOB_ITEM_HISTORY" function
        - Check the condition for create/update/delete Job_Item_History
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Insert_Job_Item_History_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct CJCMITMHIS_TAG CJCMITMHIS;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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
    ///* ITEM_CODE Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CJCM-0001");
    //    TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    
    return MP_TRUE;
}

