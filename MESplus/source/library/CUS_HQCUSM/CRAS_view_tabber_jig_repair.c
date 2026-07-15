/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_tabber_jig_repair.c
    Description : View Tabber_Jig_Repair function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_Tabber_Jig_Repair()
            + View Tabber_Jig_Repair definition
        - CRAS_VIEW_TABBER_JIG_REPAIR()
            + Main sub function of CRAS_View_Tabber_Jig_Repair function
            + View Tabber_Jig_Repair definition
    Detail Description
        - CRAS_VIEW_TABBER_JIG_REPAIR()
            + h_proc_step
                + 1 : View Tabber_Jig_Repair definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/10/08             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_Tabber_Jig_Repair()
        - View Tabber_Jig_Repair definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Tabber_Jig_Repair(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_TABBER_JIG_REPAIR(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_TABBER_JIG_REPAIR", out_node);

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
    CRAS_VIEW_TABBER_JIG_REPAIR()
        - Main sub function of "CRAS_View_Tabber_Jig_Repair" function
        - View Tabber_Jig_Repair definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_TABBER_JIG_REPAIR(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASTBRJGR_TAG CRASTBRJGR;

    LOG_head("CRAS_VIEW_TABBER_JIG_REPAIR");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("jgr_seq", MP_INT, TRS.get_int(in_node, "JGR_SEQ"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CRAS", "CRAS_View_Tabber_Jig_Repair",
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
        strcpy(s_msg_code, "CRAS-0001");
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
        strcpy(s_msg_code, "CRAS-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* JGR_SEQ Validation */
    if(TRS.get_int(in_node, "JGR_SEQ") == 0)
    {
        strcpy(s_msg_code, "CRAS-0001");
        TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_crastbrjgr(&CRASTBRJGR);
    TRS.copy(CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASTBRJGR.WORK_DATE, sizeof(CRASTBRJGR.WORK_DATE), in_node, "WORK_DATE");
    CRASTBRJGR.JGR_SEQ = TRS.get_int(in_node, "JGR_SEQ");
    CDB_select_crastbrjgr(1, &CRASTBRJGR);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CRAS-9999");
        TRS.add_fieldmsg(out_node, "CRASTBRJGR SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
        TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY));
    TRS.add_string(out_node, "WORK_DATE", CRASTBRJGR.WORK_DATE, sizeof(CRASTBRJGR.WORK_DATE));
    TRS.add_int(out_node, "JGR_SEQ", CRASTBRJGR.JGR_SEQ);
	TRS.add_string(out_node, "JGR_PROC", CRASTBRJGR.JGR_PROC, sizeof(CRASTBRJGR.JGR_PROC));
    TRS.add_string(out_node, "LINE_ID", CRASTBRJGR.LINE_ID, sizeof(CRASTBRJGR.LINE_ID));
    TRS.add_string(out_node, "RES_ID", CRASTBRJGR.RES_ID, sizeof(CRASTBRJGR.RES_ID));
    TRS.add_string(out_node, "WORK_TIME", CRASTBRJGR.WORK_TIME, sizeof(CRASTBRJGR.WORK_TIME));
    TRS.add_string(out_node, "JIG_NO", CRASTBRJGR.JIG_NO, sizeof(CRASTBRJGR.JIG_NO));
    TRS.add_string(out_node, "WRKR_NAME", CRASTBRJGR.WRKR_NAME, sizeof(CRASTBRJGR.WRKR_NAME));
    TRS.add_string(out_node, "DEPT_CD", CRASTBRJGR.DEPT_CD, sizeof(CRASTBRJGR.DEPT_CD));
    TRS.add_string(out_node, "JGR_RSN", CRASTBRJGR.JGR_RSN, sizeof(CRASTBRJGR.JGR_RSN));
    TRS.add_string(out_node, "JGR_REMARKS", CRASTBRJGR.JGR_REMARKS, sizeof(CRASTBRJGR.JGR_REMARKS));
    TRS.add_string(out_node, "CMF_1", CRASTBRJGR.CMF_1, sizeof(CRASTBRJGR.CMF_1));
    TRS.add_string(out_node, "CMF_2", CRASTBRJGR.CMF_2, sizeof(CRASTBRJGR.CMF_2));
    TRS.add_string(out_node, "CMF_3", CRASTBRJGR.CMF_3, sizeof(CRASTBRJGR.CMF_3));
    TRS.add_string(out_node, "CMF_4", CRASTBRJGR.CMF_4, sizeof(CRASTBRJGR.CMF_4));
    TRS.add_string(out_node, "CMF_5", CRASTBRJGR.CMF_5, sizeof(CRASTBRJGR.CMF_5));
    TRS.add_string(out_node, "CMF_6", CRASTBRJGR.CMF_6, sizeof(CRASTBRJGR.CMF_6));
    TRS.add_string(out_node, "CMF_7", CRASTBRJGR.CMF_7, sizeof(CRASTBRJGR.CMF_7));
    TRS.add_string(out_node, "CMF_8", CRASTBRJGR.CMF_8, sizeof(CRASTBRJGR.CMF_8));
    TRS.add_string(out_node, "CMF_9", CRASTBRJGR.CMF_9, sizeof(CRASTBRJGR.CMF_9));
    TRS.add_string(out_node, "CMF_10", CRASTBRJGR.CMF_10, sizeof(CRASTBRJGR.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CRASTBRJGR.CREATE_USER_ID, sizeof(CRASTBRJGR.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CRASTBRJGR.CREATE_TIME, sizeof(CRASTBRJGR.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CRASTBRJGR.UPDATE_USER_ID, sizeof(CRASTBRJGR.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CRASTBRJGR.UPDATE_TIME, sizeof(CRASTBRJGR.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CRAS", "CRAS_View_Tabber_Jig_Repair",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

