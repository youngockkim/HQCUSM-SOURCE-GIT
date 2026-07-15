/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_laminator_recipe_list.c
    Description : View Laminator_Recipe List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Laminator_Recipe_List()
            + View Laminator_Recipe definition List
        - CWIP_VIEW_LAMINATOR_RECIPE_LIST()
            + Main sub function of CWIP_View_Laminator_Recipe_List function
            + View Laminator_Recipe definition List
    Detail Description
        - CWIP_VIEW_LAMINATOR_RECIPE_LIST()
            + h_proc_step
                + 1 : View Laminator_Recipe definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-08-08             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Laminator_Recipe_List()
        - View Laminator_Recipe definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Laminator_Recipe_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_LAMINATOR_RECIPE_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_LAMINATOR_RECIPE_LIST", out_node);

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
    CWIP_VIEW_LAMINATOR_RECIPE_LIST()
        - Main sub function of "CWIP_View_Laminator_Recipe_List" function
        - View Laminator_Recipe definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LAMINATOR_RECIPE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLAMRCP_TAG CWIPLAMRCP;
    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_LAMINATOR_RECIPE_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("chmb_cd", MP_NSTR, TRS.get_string(in_node, "CHMB_CD"));
    LOG_add("chmb_attr", MP_NSTR, TRS.get_string(in_node, "CHMB_ATTR"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Laminator_Recipe_List",
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
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    } 
    i_case = 1;

    CDB_init_cwiplamrcp(&CWIPLAMRCP);
    TRS.copy(CWIPLAMRCP.FACTORY, sizeof(CWIPLAMRCP.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID), in_node, "LINE_ID");
    CDB_open_cwiplamrcp(i_case, &CWIPLAMRCP);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPLAMRCP OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLAMRCP.FACTORY), CWIPLAMRCP.FACTORY);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLAMRCP.WORK_DATE), CWIPLAMRCP.WORK_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMRCP.LINE_ID), CWIPLAMRCP.LINE_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwiplamrcp(i_case, &CWIPLAMRCP);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiplamrcp(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLAMRCP FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLAMRCP.FACTORY), CWIPLAMRCP.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLAMRCP.WORK_DATE), CWIPLAMRCP.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMRCP.LINE_ID), CWIPLAMRCP.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMRCP.RES_ID), CWIPLAMRCP.RES_ID);
            TRS.add_fieldmsg(out_node, "CHMB_CD", MP_STR, sizeof(CWIPLAMRCP.CHMB_CD), CWIPLAMRCP.CHMB_CD);
            TRS.add_fieldmsg(out_node, "CHMB_ATTR", MP_STR, sizeof(CWIPLAMRCP.CHMB_ATTR), CWIPLAMRCP.CHMB_ATTR);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwiplamrcp(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_WORK_DATE", CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE));
            TRS.set_string(out_node, "NEXT_LINE_ID", CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID));
            TRS.set_string(out_node, "NEXT_RES_ID", CWIPLAMRCP.RES_ID, sizeof(CWIPLAMRCP.RES_ID));
            TRS.set_string(out_node, "NEXT_CHMB_CD", CWIPLAMRCP.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD));
            TRS.set_string(out_node, "NEXT_CHMB_ATTR", CWIPLAMRCP.CHMB_ATTR, sizeof(CWIPLAMRCP.CHMB_ATTR));
            CDB_close_cwiplamrcp(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "LAMINATOR_RECIPE_LIST");

        TRS.add_string(list_item, "FACTORY", CWIPLAMRCP.FACTORY, sizeof(CWIPLAMRCP.FACTORY));
        TRS.add_string(list_item, "WORK_DATE", CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE));
        TRS.add_string(list_item, "LINE_ID", CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID));
        TRS.add_string(list_item, "RES_ID", CWIPLAMRCP.RES_ID, sizeof(CWIPLAMRCP.RES_ID));
        TRS.add_string(list_item, "CHMB_CD", CWIPLAMRCP.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD));
        TRS.add_string(list_item, "CHMB_ATTR", CWIPLAMRCP.CHMB_ATTR, sizeof(CWIPLAMRCP.CHMB_ATTR));
        TRS.add_double(list_item, "ATTR_VAL", CWIPLAMRCP.ATTR_VAL);
        TRS.add_string(list_item, "CMF_1", CWIPLAMRCP.CMF_1, sizeof(CWIPLAMRCP.CMF_1));
        TRS.add_string(list_item, "CMF_2", CWIPLAMRCP.CMF_2, sizeof(CWIPLAMRCP.CMF_2));
        TRS.add_string(list_item, "CMF_3", CWIPLAMRCP.CMF_3, sizeof(CWIPLAMRCP.CMF_3));
        TRS.add_string(list_item, "CMF_4", CWIPLAMRCP.CMF_4, sizeof(CWIPLAMRCP.CMF_4));
        TRS.add_string(list_item, "CMF_5", CWIPLAMRCP.CMF_5, sizeof(CWIPLAMRCP.CMF_5));
        TRS.add_string(list_item, "CMF_6", CWIPLAMRCP.CMF_6, sizeof(CWIPLAMRCP.CMF_6));
        TRS.add_string(list_item, "CMF_7", CWIPLAMRCP.CMF_7, sizeof(CWIPLAMRCP.CMF_7));
        TRS.add_string(list_item, "CMF_8", CWIPLAMRCP.CMF_8, sizeof(CWIPLAMRCP.CMF_8));
        TRS.add_string(list_item, "CMF_9", CWIPLAMRCP.CMF_9, sizeof(CWIPLAMRCP.CMF_9));
        TRS.add_string(list_item, "CMF_10", CWIPLAMRCP.CMF_10, sizeof(CWIPLAMRCP.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CWIPLAMRCP.CREATE_USER_ID, sizeof(CWIPLAMRCP.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CWIPLAMRCP.CREATE_TIME, sizeof(CWIPLAMRCP.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPLAMRCP.UPDATE_USER_ID, sizeof(CWIPLAMRCP.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CWIPLAMRCP.UPDATE_TIME, sizeof(CWIPLAMRCP.UPDATE_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Laminator_Recipe_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

