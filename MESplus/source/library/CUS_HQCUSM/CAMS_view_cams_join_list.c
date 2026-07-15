/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_view_cams_join_list.c
    Description : View Cams_Join List function module

    MES Version : 5.3.4 ~

    Function List
        - CAMS_View_Cams_Join_List()
            + View Cams_Join definition List
        - CAMS_VIEW_CAMS_JOIN_LIST()
            + Main sub function of CAMS_View_Cams_Join_List function
            + View Cams_Join definition List
    Detail Description
        - CAMS_VIEW_CAMS_JOIN_LIST()
            + h_proc_step
                + 1 : View Cams_Join definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/06/20             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CAMS_View_Cams_Join_List()
        - View Cams_Join definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_View_Cams_Join_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_VIEW_CAMS_JOIN_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_VIEW_CAMS_JOIN_LIST", out_node);

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
    CAMS_VIEW_CAMS_JOIN_LIST()
        - Main sub function of "CAMS_View_Cams_Join_List" function
        - View Cams_Join definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_VIEW_CAMS_JOIN_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMS_JOIN_TAG CAMS_JOIN;
    TRSNode *list_item;

    int i_case;

    LOG_head("CAMS_VIEW_CAMS_JOIN_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Cams_Join_List",
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


    i_case = 1;

    CDB_init_cams_join(&CAMS_JOIN);
	TRS.copy(CAMS_JOIN.FACTORY, sizeof(CAMS_JOIN.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CAMS_JOIN.PLAN_DATE, sizeof(CAMS_JOIN.PLAN_DATE), in_node, "FROM_DATE");
	TRS.copy(CAMS_JOIN.AUDIT_DATE, sizeof(CAMS_JOIN.AUDIT_DATE), in_node, "TO_DATE");	
	TRS.copy(CAMS_JOIN.CUSTOMER_CODE, sizeof(CAMS_JOIN.CUSTOMER_CODE), in_node, "CUSTOMER_CODE");
	TRS.copy(CAMS_JOIN.MANAGER_ID, sizeof(CAMS_JOIN.MANAGER_ID), in_node, "MANAGER_ID");
	CAMS_JOIN.STATUS = TRS.get_char(in_node, "STATUS");	
    CDB_open_cams_join(i_case, &CAMS_JOIN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CAMS_JOIN OPEN", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cams_join(i_case, &CAMS_JOIN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cams_join(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMS_JOIN FETCH", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cams_join(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            CDB_close_cams_join(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "CAMS_JOIN_LIST");
		
        TRS.add_string(list_item, "FACTORY", CAMS_JOIN.FACTORY, sizeof(CAMS_JOIN.FACTORY));
        TRS.add_string(list_item, "AUDIT_ID", CAMS_JOIN.AUDIT_ID, sizeof(CAMS_JOIN.AUDIT_ID));
        TRS.add_string(list_item, "AUDIT_DESC", CAMS_JOIN.AUDIT_DESC, sizeof(CAMS_JOIN.AUDIT_DESC));
        TRS.add_string(list_item, "PLAN_DATE", CAMS_JOIN.PLAN_DATE, sizeof(CAMS_JOIN.PLAN_DATE));
        TRS.add_string(list_item, "CUSTOMER_CODE", CAMS_JOIN.CUSTOMER_CODE, sizeof(CAMS_JOIN.CUSTOMER_CODE));
        TRS.add_string(list_item, "CUSTOMER_NAME", CAMS_JOIN.CUSTOMER_NAME, sizeof(CAMS_JOIN.CUSTOMER_NAME));
        TRS.add_string(list_item, "AUDITOR", CAMS_JOIN.AUDITOR, sizeof(CAMS_JOIN.AUDITOR));
        TRS.add_string(list_item, "MANAGER_ID", CAMS_JOIN.MANAGER_ID, sizeof(CAMS_JOIN.MANAGER_ID));
        TRS.add_string(list_item, "MANAGER_NAME", CAMS_JOIN.MANAGER_NAME, sizeof(CAMS_JOIN.MANAGER_NAME));
        TRS.add_string(list_item, "AGENDA", CAMS_JOIN.AGENDA, sizeof(CAMS_JOIN.AGENDA));
        TRS.add_string(list_item, "AUDIT_DATE", CAMS_JOIN.AUDIT_DATE, sizeof(CAMS_JOIN.AUDIT_DATE));
        TRS.add_string(list_item, "RESULT", CAMS_JOIN.RESULT, sizeof(CAMS_JOIN.RESULT));
        TRS.add_char(list_item, "STATUS", CAMS_JOIN.STATUS);
        TRS.add_string(list_item, "STATUS_DESC", CAMS_JOIN.STATUS_DESC, sizeof(CAMS_JOIN.STATUS_DESC));
		TRS.add_string(list_item, "DOCUMENT", CAMS_JOIN.DOCUMENT, sizeof(CAMS_JOIN.DOCUMENT));
        TRS.add_string(list_item, "ITEM_DIVISION", CAMS_JOIN.ITEM_DIVISION, sizeof(CAMS_JOIN.ITEM_DIVISION));
        TRS.add_string(list_item, "ITEM_DIV_DESC", CAMS_JOIN.ITEM_DIV_DESC, sizeof(CAMS_JOIN.ITEM_DIV_DESC));
        TRS.add_string(list_item, "ITEM_NAME", CAMS_JOIN.ITEM_NAME, sizeof(CAMS_JOIN.ITEM_NAME));
        TRS.add_string(list_item, "CHECK_DETAIL", CAMS_JOIN.CHECK_DETAIL, sizeof(CAMS_JOIN.CHECK_DETAIL));
        TRS.add_string(list_item, "CHECK_RESULT", CAMS_JOIN.CHECK_RESULT, sizeof(CAMS_JOIN.CHECK_RESULT));
        TRS.add_string(list_item, "FILE_NAME", CAMS_JOIN.FILE_NAME, sizeof(CAMS_JOIN.FILE_NAME));
        TRS.add_string(list_item, "ACTION_MGR_ID", CAMS_JOIN.ACTION_MGR_ID, sizeof(CAMS_JOIN.ACTION_MGR_ID));
        TRS.add_string(list_item, "ACTION_MGR_NAME", CAMS_JOIN.ACTION_MGR_NAME, sizeof(CAMS_JOIN.ACTION_MGR_NAME));
        TRS.add_string(list_item, "ACTION_LIMIT_DATE", CAMS_JOIN.ACTION_LIMIT_DATE, sizeof(CAMS_JOIN.ACTION_LIMIT_DATE));
        TRS.add_string(list_item, "ACTION_DATE", CAMS_JOIN.ACTION_DATE, sizeof(CAMS_JOIN.ACTION_DATE));
        TRS.add_string(list_item, "ACTION_USER_ID", CAMS_JOIN.ACTION_USER_ID, sizeof(CAMS_JOIN.ACTION_USER_ID));
        TRS.add_string(list_item, "ACTION_USER_NAME", CAMS_JOIN.ACTION_USER_NAME, sizeof(CAMS_JOIN.ACTION_USER_NAME));
        TRS.add_string(list_item, "ACTION_FILE_NAME", CAMS_JOIN.ACTION_FILE_NAME, sizeof(CAMS_JOIN.ACTION_FILE_NAME));
        TRS.add_string(list_item, "ACTION_RESULT", CAMS_JOIN.ACTION_RESULT, sizeof(CAMS_JOIN.ACTION_RESULT));
        TRS.add_string(list_item, "REMARKS", CAMS_JOIN.REMARKS, sizeof(CAMS_JOIN.REMARKS));

		/*if (COM_isspace(CAMS_JOIN.FILE_PATH, sizeof(CAMS_JOIN.FILE_PATH)) == MP_FALSE)
		{
			if(CMMS_get_attached_file(s_msg_code, out_node, CAMS_JOIN.FILE_PATH, TRS.get_string(list_item, "FILE_NAME"), 'Y') == MP_FALSE)
			{
				COM_set_result(list_item, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
			}
		}

		if (COM_isspace(CAMS_JOIN.ACTION_FILE_PATH, sizeof(CAMS_JOIN.ACTION_FILE_PATH)) == MP_FALSE)
		{
			if(CMMS_get_attached_file(s_msg_code, out_node, CAMS_JOIN.ACTION_FILE_PATH, TRS.get_string(list_item, "ACTION_FILE_NAME"), 'Y') == MP_FALSE)
			{
				COM_set_result(list_item, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
			}
		}*/
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Cams_Join_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

