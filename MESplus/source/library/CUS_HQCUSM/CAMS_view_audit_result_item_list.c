/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_view_audit_result_item_list.c
    Description : View Audit_Result_Item List function module

    MES Version : 5.3.4 ~

    Function List
        - CAMS_View_Audit_Result_Item_List()
            + View Audit_Result_Item definition List
        - CAMS_VIEW_AUDIT_RESULT_ITEM_LIST()
            + Main sub function of CAMS_View_Audit_Result_Item_List function
            + View Audit_Result_Item definition List
        - CAMS_View_Audit_Result_Item_List_Validation()
            + Main sub function of CAMS_VIEW_AUDIT_RESULT_ITEM_LIST function
            + Check the condition for view Audit_Result_Item list
    Detail Description
        - CAMS_VIEW_AUDIT_RESULT_ITEM_LIST()
            + h_proc_step
                + 1 : View Audit_Result_Item definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-26             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CAMS_View_Audit_Result_Item_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CAMS_View_Audit_Result_Item_List()
        - View Audit_Result_Item definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_View_Audit_Result_Item_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_VIEW_AUDIT_RESULT_ITEM_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_VIEW_AUDIT_RESULT_ITEM_LIST", out_node);

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
    CAMS_VIEW_AUDIT_RESULT_ITEM_LIST()
        - Main sub function of "CAMS_View_Audit_Result_Item_List" function
        - View Audit_Result_Item definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_VIEW_AUDIT_RESULT_ITEM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTITM_TAG CAMSADTITM;
    TRSNode *list_item;

    int i_case;

    LOG_head("CAMS_VIEW_AUDIT_RESULT_ITEM_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("audit_id", MP_NSTR, TRS.get_string(in_node, "AUDIT_ID"));
    LOG_add("sort_order", MP_INT, TRS.get_int(in_node, "SORT_ORDER"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Audit_Result_Item_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CAMS_View_Audit_Result_Item_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_camsadtitm(&CAMSADTITM);
    TRS.copy(CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID), in_node, "AUDIT_ID");
    CAMSADTITM.SORT_ORDER = TRS.get_int(in_node, "SORT_ORDER");
    CDB_open_camsadtitm(i_case, &CAMSADTITM);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CAMSADTITM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
        TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_camsadtitm(i_case, &CAMSADTITM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_camsadtitm(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTITM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
            TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_camsadtitm(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_AUDIT_ID", CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
            TRS.set_int(out_node, "NEXT_SORT_ORDER", CAMSADTITM.SORT_ORDER);
            CDB_close_camsadtitm(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "AUDIT_RESULT_ITEM_LIST");

        TRS.add_string(list_item, "FACTORY", CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY));
        TRS.add_string(list_item, "AUDIT_ID", CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
        TRS.add_int(list_item, "SORT_ORDER", CAMSADTITM.SORT_ORDER);
        TRS.add_string(list_item, "ITEM_DIVISION", CAMSADTITM.ITEM_DIVISION, sizeof(CAMSADTITM.ITEM_DIVISION));
        TRS.add_string(list_item, "ITEM_NAME", CAMSADTITM.ITEM_NAME, sizeof(CAMSADTITM.ITEM_NAME));
        TRS.add_string(list_item, "CHECK_DETAIL", CAMSADTITM.CHECK_DETAIL, sizeof(CAMSADTITM.CHECK_DETAIL));
        TRS.add_char(list_item, "CHECK_RESULT", CAMSADTITM.CHECK_RESULT);
        TRS.add_string(list_item, "FILE_NAME", CAMSADTITM.FILE_NAME, sizeof(CAMSADTITM.FILE_NAME));
        TRS.add_string(list_item, "FILE_PATH", CAMSADTITM.FILE_PATH, sizeof(CAMSADTITM.FILE_PATH));
        TRS.add_string(list_item, "ACTION_MGR_ID", CAMSADTITM.ACTION_MGR_ID, sizeof(CAMSADTITM.ACTION_MGR_ID));
        TRS.add_string(list_item, "ACTION_LIMIT_DATE", CAMSADTITM.ACTION_LIMIT_DATE, sizeof(CAMSADTITM.ACTION_LIMIT_DATE));
        TRS.add_string(list_item, "ACTION_DATE", CAMSADTITM.ACTION_DATE, sizeof(CAMSADTITM.ACTION_DATE));
        TRS.add_string(list_item, "ACTION_USER_ID", CAMSADTITM.ACTION_USER_ID, sizeof(CAMSADTITM.ACTION_USER_ID));
        TRS.add_string(list_item, "ACTION_FILE_NAME", CAMSADTITM.ACTION_FILE_NAME, sizeof(CAMSADTITM.ACTION_FILE_NAME));
        TRS.add_string(list_item, "ACTION_FILE_PATH", CAMSADTITM.ACTION_FILE_PATH, sizeof(CAMSADTITM.ACTION_FILE_PATH));
        TRS.add_char(list_item, "ACTION_RESULT", CAMSADTITM.ACTION_RESULT);
        TRS.add_string(list_item, "REMARKS", CAMSADTITM.REMARKS, sizeof(CAMSADTITM.REMARKS));
        TRS.add_char(list_item, "STATUS", CAMSADTITM.STATUS);
        TRS.add_string(list_item, "CMF_1", CAMSADTITM.CMF_1, sizeof(CAMSADTITM.CMF_1));
        TRS.add_string(list_item, "CMF_2", CAMSADTITM.CMF_2, sizeof(CAMSADTITM.CMF_2));
        TRS.add_string(list_item, "CMF_3", CAMSADTITM.CMF_3, sizeof(CAMSADTITM.CMF_3));
        TRS.add_string(list_item, "CMF_4", CAMSADTITM.CMF_4, sizeof(CAMSADTITM.CMF_4));
        TRS.add_string(list_item, "CMF_5", CAMSADTITM.CMF_5, sizeof(CAMSADTITM.CMF_5));
        TRS.add_string(list_item, "CMF_6", CAMSADTITM.CMF_6, sizeof(CAMSADTITM.CMF_6));
        TRS.add_string(list_item, "CMF_7", CAMSADTITM.CMF_7, sizeof(CAMSADTITM.CMF_7));
        TRS.add_string(list_item, "CMF_8", CAMSADTITM.CMF_8, sizeof(CAMSADTITM.CMF_8));
        TRS.add_string(list_item, "CMF_9", CAMSADTITM.CMF_9, sizeof(CAMSADTITM.CMF_9));
        TRS.add_string(list_item, "CMF_10", CAMSADTITM.CMF_10, sizeof(CAMSADTITM.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CAMSADTITM.CREATE_USER_ID, sizeof(CAMSADTITM.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CAMSADTITM.CREATE_TIME, sizeof(CAMSADTITM.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CAMSADTITM.UPDATE_USER_ID, sizeof(CAMSADTITM.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CAMSADTITM.UPDATE_TIME, sizeof(CAMSADTITM.UPDATE_TIME));

    }

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Audit_Result_Item_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CAMS_View_Audit_Result_Item_List_Validation()
        - Main sub function of "CAMS_VIEW_AUDIT_RESULT_ITEM_LIST" function
        - Check the condition for view Audit_Result_Item list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_View_Audit_Result_Item_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
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
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* AUDIT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "AUDIT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
   
    return MP_TRUE;
}

