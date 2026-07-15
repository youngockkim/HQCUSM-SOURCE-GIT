/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_scraplb_tb.c
    Description : View ScrapLb_Tb function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_ScrapLb_Tb()
            + View ScrapLb_Tb definition
        - CWIP_VIEW_SCRAPLB_TB()
            + Main sub function of CWIP_View_ScrapLb_Tb function
            + View ScrapLb_Tb definition
    Detail Description
        - CWIP_VIEW_SCRAPLB_TB()
            + h_proc_step
                + 1 : View ScrapLb_Tb definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-11             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_ScrapLb_Tb()
        - View ScrapLb_Tb definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_ScrapLb_Tb(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_SCRAPLB_TB(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_SCRAPLB_TB", out_node);

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
    CWIP_VIEW_SCRAPLB_TB()
        - Main sub function of "CWIP_View_ScrapLb_Tb" function
        - View ScrapLb_Tb definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_SCRAPLB_TB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOSTAB_TAG CWIPLOSTAB;

    LOG_head("CWIP_VIEW_SCRAPLB_TB");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("oper_id", MP_NSTR, TRS.get_string(in_node, "OPER_ID"));
    LOG_add("oper_sub_id", MP_NSTR, TRS.get_string(in_node, "OPER_SUB_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("operator_id", MP_NSTR, TRS.get_string(in_node, "OPERATOR_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_ScrapLb_Tb",
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
    /* OPER_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "OPER_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "OPER_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* OPER_SUB_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "OPER_SUB_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_SHIFT Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* OPERATOR_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "OPERATOR_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplostab(&CWIPLOSTAB);
    TRS.copy(CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID), in_node, "RES_ID");
    TRS.copy(CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID), in_node, "OPER_ID");
    TRS.copy(CWIPLOSTAB.OPER_SUB_ID, sizeof(CWIPLOSTAB.OPER_SUB_ID), in_node, "OPER_SUB_ID");
    TRS.copy(CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID), in_node, "OPERATOR_ID");
    CDB_select_cwiplostab(1, &CWIPLOSTAB);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPLOSTAB SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
        TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_ID), CWIPLOSTAB.OPER_ID);
        TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_SUB_ID), CWIPLOSTAB.OPER_SUB_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_STR, sizeof(CWIPLOSTAB.OPERATOR_ID), CWIPLOSTAB.OPERATOR_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "WORK_DATE", CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE));
    TRS.add_string(out_node, "FACTORY", CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY));
    TRS.add_string(out_node, "LINE_ID", CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID));
    TRS.add_string(out_node, "RES_ID", CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID));
    TRS.add_string(out_node, "OPER_ID", CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID));
    TRS.add_string(out_node, "OPER_SUB_ID", CWIPLOSTAB.OPER_SUB_ID, sizeof(CWIPLOSTAB.OPER_SUB_ID));
    TRS.add_string(out_node, "WORK_SHIFT", CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT));
    TRS.add_string(out_node, "OPERATOR_ID", CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID));
    TRS.add_double(out_node, "LOSS_QTY", CWIPLOSTAB.LOSS_QTY);
    TRS.add_string(out_node, "LOSS_CAUSE", CWIPLOSTAB.LOSS_CAUSE, sizeof(CWIPLOSTAB.LOSS_CAUSE));
    TRS.add_string(out_node, "LOSS_COMMENT", CWIPLOSTAB.LOSS_COMMENT, sizeof(CWIPLOSTAB.LOSS_COMMENT));
    TRS.add_string(out_node, "LOSS_LB", CWIPLOSTAB.LOSS_LB, sizeof(CWIPLOSTAB.LOSS_LB));
    TRS.add_string(out_node, "LOSS_LB_CHECK", CWIPLOSTAB.LOSS_LB_CHECK, sizeof(CWIPLOSTAB.LOSS_LB_CHECK));
    TRS.add_string(out_node, "BOX_USE", CWIPLOSTAB.BOX_USE, sizeof(CWIPLOSTAB.BOX_USE));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPLOSTAB.CREATE_USER_ID, sizeof(CWIPLOSTAB.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPLOSTAB.CREATE_TIME, sizeof(CWIPLOSTAB.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPLOSTAB.UPDATE_USER_ID, sizeof(CWIPLOSTAB.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPLOSTAB.UPDATE_TIME, sizeof(CWIPLOSTAB.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_ScrapLb_Tb",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

