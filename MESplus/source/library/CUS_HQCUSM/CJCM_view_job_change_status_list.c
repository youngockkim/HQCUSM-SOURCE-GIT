/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_view_job_change_status_list.c
    Description : View Job_Change_Status List function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_View_Job_Change_Status_List()
            + View Job_Change_Status definition List
        - CJCM_VIEW_JOB_CHANGE_STATUS_LIST()
            + Main sub function of CJCM_View_Job_Change_Status_List function
            + View Job_Change_Status definition List
    Detail Description
        - CJCM_VIEW_JOB_CHANGE_STATUS_LIST()
            + h_proc_step
                + 1 : View Job_Change_Status definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/17             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CJCM_View_Job_Change_Status_List()
        - View Job_Change_Status definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Job_Change_Status_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_VIEW_JOB_CHANGE_STATUS_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_VIEW_JOB_CHANGE_STATUS_LIST", out_node);

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
    CJCM_VIEW_JOB_CHANGE_STATUS_LIST()
        - Main sub function of "CJCM_View_Job_Change_Status_List" function
        - View Job_Change_Status definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_VIEW_JOB_CHANGE_STATUS_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMJOBSTS_TAG CJCMJOBSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MSECUSRDEF_TAG MSECUSRDEF;

    TRSNode *list_item;

    int i_case;

    LOG_head("CJCM_VIEW_JOB_CHANGE_STATUS_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Job_Change_Status_List",
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


    i_case = 1;
    CDB_init_cjcmjobsts(&CJCMJOBSTS);
    TRS.copy(CJCMJOBSTS.FACTORY, sizeof(CJCMJOBSTS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CJCMJOBSTS.PLAN_START_DATE, sizeof(CJCMJOBSTS.PLAN_START_DATE), in_node, "FROM_DATE");
	TRS.copy(CJCMJOBSTS.PLAN_END_DATE, sizeof(CJCMJOBSTS.PLAN_END_DATE), in_node, "TO_DATE");
    TRS.copy(CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID), in_node, "ORDER_ID");
	TRS.copy(CJCMJOBSTS.LINE_ID, sizeof(CJCMJOBSTS.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CJCMJOBSTS.MAT_ID, sizeof(CJCMJOBSTS.MAT_ID), in_node, "MAT_ID");
    CDB_open_cjcmjobsts(i_case, &CJCMJOBSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMJOBSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS.FACTORY), CJCMJOBSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS.ORDER_ID), CJCMJOBSTS.ORDER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cjcmjobsts(i_case, &CJCMJOBSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cjcmjobsts(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCMJOBSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMJOBSTS.FACTORY), CJCMJOBSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CJCMJOBSTS.ORDER_ID), CJCMJOBSTS.ORDER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cjcmjobsts(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //    TRS.set_string(out_node, "NEXT_ORDER_ID", CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID));
        //    CDB_close_cjcmjobsts(i_case);
        //    break;
        //}

        list_item = TRS.add_node(out_node, "JOB_CHANGE_STATUS_LIST");

        TRS.add_string(list_item, "FACTORY", CJCMJOBSTS.FACTORY, sizeof(CJCMJOBSTS.FACTORY));
        TRS.add_string(list_item, "ORDER_ID", CJCMJOBSTS.ORDER_ID, sizeof(CJCMJOBSTS.ORDER_ID));
		TRS.add_string(list_item, "LINE_ID", CJCMJOBSTS.LINE_ID, sizeof(CJCMJOBSTS.LINE_ID));
		TRS.add_string(list_item, "MAT_ID", CJCMJOBSTS.MAT_ID, sizeof(CJCMJOBSTS.MAT_ID));
		TRS.add_string(list_item, "ORD_START_DATE", CJCMJOBSTS.ORD_START_DATE, sizeof(CJCMJOBSTS.ORD_START_DATE));
        TRS.add_string(list_item, "MANAGER", CJCMJOBSTS.MANAGER, sizeof(CJCMJOBSTS.MANAGER));
        TRS.add_string(list_item, "DEPT_CODE", CJCMJOBSTS.DEPT_CODE, sizeof(CJCMJOBSTS.DEPT_CODE));
        TRS.add_string(list_item, "PLAN_START_DATE", CJCMJOBSTS.PLAN_START_DATE, sizeof(CJCMJOBSTS.PLAN_START_DATE));
        TRS.add_string(list_item, "PLAN_END_DATE", CJCMJOBSTS.PLAN_END_DATE, sizeof(CJCMJOBSTS.PLAN_END_DATE));
        TRS.add_string(list_item, "START_TIME", CJCMJOBSTS.START_TIME, sizeof(CJCMJOBSTS.START_TIME));
        TRS.add_string(list_item, "END_TIME", CJCMJOBSTS.END_TIME, sizeof(CJCMJOBSTS.END_TIME));
        TRS.add_char(list_item, "STATUS", CJCMJOBSTS.STATUS);
        TRS.add_char(list_item, "ALARM_FLAG", CJCMJOBSTS.ALARM_FLAG);
        TRS.add_string(list_item, "ALARM_CODE", CJCMJOBSTS.ALARM_CODE, sizeof(CJCMJOBSTS.ALARM_CODE));
        TRS.add_string(list_item, "CMF_1", CJCMJOBSTS.CMF_1, sizeof(CJCMJOBSTS.CMF_1));
        TRS.add_string(list_item, "CMF_2", CJCMJOBSTS.CMF_2, sizeof(CJCMJOBSTS.CMF_2));
        TRS.add_string(list_item, "CMF_3", CJCMJOBSTS.CMF_3, sizeof(CJCMJOBSTS.CMF_3));
        TRS.add_string(list_item, "CMF_4", CJCMJOBSTS.CMF_4, sizeof(CJCMJOBSTS.CMF_4));
        TRS.add_string(list_item, "CMF_5", CJCMJOBSTS.CMF_5, sizeof(CJCMJOBSTS.CMF_5));
        TRS.add_string(list_item, "CMF_6", CJCMJOBSTS.CMF_6, sizeof(CJCMJOBSTS.CMF_6));
        TRS.add_string(list_item, "CMF_7", CJCMJOBSTS.CMF_7, sizeof(CJCMJOBSTS.CMF_7));
        TRS.add_string(list_item, "CMF_8", CJCMJOBSTS.CMF_8, sizeof(CJCMJOBSTS.CMF_8));
        TRS.add_string(list_item, "CMF_9", CJCMJOBSTS.CMF_9, sizeof(CJCMJOBSTS.CMF_9));
        TRS.add_string(list_item, "CMF_10", CJCMJOBSTS.CMF_10, sizeof(CJCMJOBSTS.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CJCMJOBSTS.CREATE_USER_ID, sizeof(CJCMJOBSTS.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CJCMJOBSTS.CREATE_TIME, sizeof(CJCMJOBSTS.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CJCMJOBSTS.UPDATE_USER_ID, sizeof(CJCMJOBSTS.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CJCMJOBSTS.UPDATE_TIME, sizeof(CJCMJOBSTS.UPDATE_TIME));

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CJCMJOBSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		memcpy(MGCMTBLDAT.KEY_1, CJCMJOBSTS.LINE_ID, sizeof(MGCMTBLDAT.KEY_1));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "LINE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY, CJCMJOBSTS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, CJCMJOBSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		DBC_select_mwipmatdef(3, &MWIPMATDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		}

		DBC_init_msecusrdef(&MSECUSRDEF);
		memcpy(MSECUSRDEF.FACTORY, CJCMJOBSTS.FACTORY, sizeof(MSECUSRDEF.FACTORY));
		memcpy(MSECUSRDEF.USER_ID, CJCMJOBSTS.MANAGER, sizeof(MSECUSRDEF.USER_ID));
		DBC_select_msecusrdef(1, &MSECUSRDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MANAGER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
		}

		////JOB CHANGE STATUS 
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CJCMJOBSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_ITEM_STATUS", strlen("@JCM_ITEM_STATUS"));
		MGCMTBLDAT.KEY_1[0] =  CJCMJOBSTS.STATUS;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "STATUS_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

    }

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Job_Change_Status_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

