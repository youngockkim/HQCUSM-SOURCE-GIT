/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_laminator_recipe.c
    Description : View Laminator_Recipe function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Laminator_Recipe()
            + View Laminator_Recipe definition
        - CWIP_VIEW_LAMINATOR_RECIPE()
            + Main sub function of CWIP_View_Laminator_Recipe function
            + View Laminator_Recipe definition
    Detail Description
        - CWIP_VIEW_LAMINATOR_RECIPE()
            + h_proc_step
                + 1 : View Laminator_Recipe definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-08-08             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Laminator_Recipe()
        - View Laminator_Recipe definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Laminator_Recipe(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_LAMINATOR_RECIPE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_LAMINATOR_RECIPE", out_node);

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
    CWIP_VIEW_LAMINATOR_RECIPE()
        - Main sub function of "CWIP_View_Laminator_Recipe" function
        - View Laminator_Recipe definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LAMINATOR_RECIPE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLAMRCP_TAG CWIPLAMRCP;

    LOG_head("CWIP_VIEW_LAMINATOR_RECIPE");
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
    if(COM_proc_user_routine("CWIP", "CWIP_View_Laminator_Recipe",
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
    /* RES_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CHMB_CD Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CHMB_CD")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "CHMB_CD", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CHMB_ATTR Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CHMB_ATTR")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "CHMB_ATTR", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplamrcp(&CWIPLAMRCP);
    TRS.copy(CWIPLAMRCP.FACTORY, sizeof(CWIPLAMRCP.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPLAMRCP.RES_ID, sizeof(CWIPLAMRCP.RES_ID), in_node, "RES_ID");
    TRS.copy(CWIPLAMRCP.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD), in_node, "CHMB_CD");
    TRS.copy(CWIPLAMRCP.CHMB_ATTR, sizeof(CWIPLAMRCP.CHMB_ATTR), in_node, "CHMB_ATTR");
    CDB_select_cwiplamrcp(1, &CWIPLAMRCP);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPLAMRCP SELECT", MP_NVST);
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

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CWIPLAMRCP.FACTORY, sizeof(CWIPLAMRCP.FACTORY));
    TRS.add_string(out_node, "WORK_DATE", CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE));
    TRS.add_string(out_node, "LINE_ID", CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID));
    TRS.add_string(out_node, "RES_ID", CWIPLAMRCP.RES_ID, sizeof(CWIPLAMRCP.RES_ID));
    TRS.add_string(out_node, "CHMB_CD", CWIPLAMRCP.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD));
    TRS.add_string(out_node, "CHMB_ATTR", CWIPLAMRCP.CHMB_ATTR, sizeof(CWIPLAMRCP.CHMB_ATTR));
    TRS.add_double(out_node, "ATTR_VAL", CWIPLAMRCP.ATTR_VAL);
    TRS.add_string(out_node, "CMF_1", CWIPLAMRCP.CMF_1, sizeof(CWIPLAMRCP.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPLAMRCP.CMF_2, sizeof(CWIPLAMRCP.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPLAMRCP.CMF_3, sizeof(CWIPLAMRCP.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPLAMRCP.CMF_4, sizeof(CWIPLAMRCP.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPLAMRCP.CMF_5, sizeof(CWIPLAMRCP.CMF_5));
    TRS.add_string(out_node, "CMF_6", CWIPLAMRCP.CMF_6, sizeof(CWIPLAMRCP.CMF_6));
    TRS.add_string(out_node, "CMF_7", CWIPLAMRCP.CMF_7, sizeof(CWIPLAMRCP.CMF_7));
    TRS.add_string(out_node, "CMF_8", CWIPLAMRCP.CMF_8, sizeof(CWIPLAMRCP.CMF_8));
    TRS.add_string(out_node, "CMF_9", CWIPLAMRCP.CMF_9, sizeof(CWIPLAMRCP.CMF_9));
    TRS.add_string(out_node, "CMF_10", CWIPLAMRCP.CMF_10, sizeof(CWIPLAMRCP.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPLAMRCP.CREATE_USER_ID, sizeof(CWIPLAMRCP.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPLAMRCP.CREATE_TIME, sizeof(CWIPLAMRCP.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPLAMRCP.UPDATE_USER_ID, sizeof(CWIPLAMRCP.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPLAMRCP.UPDATE_TIME, sizeof(CWIPLAMRCP.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Laminator_Recipe",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

