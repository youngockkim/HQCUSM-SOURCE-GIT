/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_view_setup_job_change_item_list.c
    Description : View Setup_Job_Change_Item List function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_View_Setup_Job_Change_Item_List()
            + View Setup_Job_Change_Item definition List
        - CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST()
            + Main sub function of CJCM_View_Setup_Job_Change_Item_List function
            + View Setup_Job_Change_Item definition List
        - CJCM_View_Setup_Job_Change_Item_List_Validation()
            + Main sub function of CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST function
            + Check the condition for view Setup_Job_Change_Item list
    Detail Description
        - CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST()
            + h_proc_step
                + 1 : View Setup_Job_Change_Item definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/07/18             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_View_Setup_Job_Change_Item_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_View_Setup_Job_Change_Item_List()
        - View Setup_Job_Change_Item definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Setup_Job_Change_Item_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG); 

    i_ret = CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST(s_msg_code, in_node, out_node); 

    COM_out_msg_log_write(s_msg_code, "CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST", out_node);

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
    CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST()
        - Main sub function of "CJCM_View_Setup_Job_Change_Item_List" function
        - View Setup_Job_Change_Item definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCMITMDEF_TAG CJCMITMDEF;
    TRSNode *list_item;

    int i_case;

    LOG_head("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Setup_Job_Change_Item_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CJCM_View_Setup_Job_Change_Item_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_cjcmitmdef(&CJCMITMDEF);
    TRS.copy(CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    TRS.copy(CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE), in_node, "NEXT_ITEM_CODE");
    CDB_open_cjcmitmdef(i_case, &CJCMITMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCMITMDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cjcmitmdef(i_case, &CJCMITMDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cjcmitmdef(i_case);
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

            CDB_close_cjcmitmdef(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_ITEM_CODE", CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE));
            CDB_close_cjcmitmdef(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "SETUP_JOB_CHANGE_ITEM_LIST");

        TRS.add_string(list_item, "FACTORY", CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY));
        TRS.add_string(list_item, "ITEM_CODE", CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE));
		TRS.add_string(list_item, "ITEM_NAME", CJCMITMDEF.ITEM_NAME, sizeof(CJCMITMDEF.ITEM_NAME));
        TRS.add_char(list_item, "AUTO_FLAG", CJCMITMDEF.AUTO_FLAG);
        TRS.add_string(list_item, "RESPONSIBILITY", CJCMITMDEF.RESPONSIBILITY, sizeof(CJCMITMDEF.RESPONSIBILITY));
        TRS.add_string(list_item, "DEPT_CODE", CJCMITMDEF.DEPT_CODE, sizeof(CJCMITMDEF.DEPT_CODE));
        TRS.add_int(list_item, "PLAN_START_DAYS_BEFORE", CJCMITMDEF.PLAN_START_DAYS_BEFORE);
        TRS.add_int(list_item, "PLAN_END_DAYS_BEFORE", CJCMITMDEF.PLAN_END_DAYS_BEFORE);
        TRS.add_char(list_item, "ALARM_FLAG", CJCMITMDEF.ALARM_FLAG);
        TRS.add_string(list_item, "ALARM_CODE", CJCMITMDEF.ALARM_CODE, sizeof(CJCMITMDEF.ALARM_CODE));
        TRS.add_string(list_item, "SQL_TEXT", CJCMITMDEF.SQL_TEXT, sizeof(CJCMITMDEF.SQL_TEXT));
        TRS.add_string(list_item, "CMF_1", CJCMITMDEF.CMF_1, sizeof(CJCMITMDEF.CMF_1));
        TRS.add_string(list_item, "CMF_2", CJCMITMDEF.CMF_2, sizeof(CJCMITMDEF.CMF_2));
        TRS.add_string(list_item, "CMF_3", CJCMITMDEF.CMF_3, sizeof(CJCMITMDEF.CMF_3));
        TRS.add_string(list_item, "CMF_4", CJCMITMDEF.CMF_4, sizeof(CJCMITMDEF.CMF_4));
        TRS.add_string(list_item, "CMF_5", CJCMITMDEF.CMF_5, sizeof(CJCMITMDEF.CMF_5));
        TRS.add_string(list_item, "CMF_6", CJCMITMDEF.CMF_6, sizeof(CJCMITMDEF.CMF_6));
        TRS.add_string(list_item, "CMF_7", CJCMITMDEF.CMF_7, sizeof(CJCMITMDEF.CMF_7));
        TRS.add_string(list_item, "CMF_8", CJCMITMDEF.CMF_8, sizeof(CJCMITMDEF.CMF_8));
        TRS.add_string(list_item, "CMF_9", CJCMITMDEF.CMF_9, sizeof(CJCMITMDEF.CMF_9));
        TRS.add_string(list_item, "CMF_10", CJCMITMDEF.CMF_10, sizeof(CJCMITMDEF.CMF_10));
		TRS.add_char(list_item, "USE_FLAG", CJCMITMDEF.USE_FLAG);
        TRS.add_string(list_item, "CREATE_USER_ID", CJCMITMDEF.CREATE_USER_ID, sizeof(CJCMITMDEF.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CJCMITMDEF.CREATE_TIME, sizeof(CJCMITMDEF.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CJCMITMDEF.UPDATE_USER_ID, sizeof(CJCMITMDEF.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CJCMITMDEF.UPDATE_TIME, sizeof(CJCMITMDEF.UPDATE_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Setup_Job_Change_Item_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CJCM_View_Setup_Job_Change_Item_List_Validation()
        - Main sub function of "CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST" function
        - Check the condition for view Setup_Job_Change_Item list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Setup_Job_Change_Item_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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
    ///* ITEM_CODE Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CMN-0002");
    //    TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    /*CDB_init_cjcmitmdef(&CJCMITMDEF);
    TRS.copy(CJCMITMDEF.FACTORY, sizeof(CJCMITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CJCMITMDEF.ITEM_CODE, sizeof(CJCMITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cjcmitmdef(1, &CJCMITMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "CMN-XXXX");
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "CJCMITMDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCMITMDEF.FACTORY), CJCMITMDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CJCMITMDEF.ITEM_CODE), CJCMITMDEF.ITEM_CODE);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }
*/
    return MP_TRUE;
}

