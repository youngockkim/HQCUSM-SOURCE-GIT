/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_hourly_fqc_worklog.c
    Description : View Hourly_Fqc_Worklog function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Hourly_Fqc_Worklog()
            + View Hourly_Fqc_Worklog definition
        - CWIP_VIEW_HOURLY_FQC_WORKLOG()
            + Main sub function of CWIP_View_Hourly_Fqc_Worklog function
            + View Hourly_Fqc_Worklog definition
    Detail Description
        - CWIP_VIEW_HOURLY_FQC_WORKLOG()
            + h_proc_step
                + 1 : View Hourly_Fqc_Worklog definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024-01-17             Create by Generator

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Hourly_Fqc_Worklog()
        - View Hourly_Fqc_Worklog definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Hourly_Fqc_Worklog(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_HOURLY_FQC_WORKLOG(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_HOURLY_FQC_WORKLOG", out_node);

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
    CWIP_VIEW_HOURLY_FQC_WORKLOG()
        - Main sub function of "CWIP_View_Hourly_Fqc_Worklog" function
        - View Hourly_Fqc_Worklog definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_HOURLY_FQC_WORKLOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPHURFQC_TAG CWIPHURFQC;

    LOG_head("CWIP_VIEW_HOURLY_FQC_WORKLOG");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("hour_type", MP_NSTR, TRS.get_string(in_node, "HOUR_TYPE"));
    LOG_add("work_time", MP_NSTR, TRS.get_string(in_node, "WORK_TIME"));
    LOG_add("hist_seq", MP_INT, TRS.get_int(in_node, "HIST_SEQ"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Hourly_Fqc_Worklog",
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
    /* BEFE_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "BEFE_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "BEFE_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* SIML_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SIML_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "SIML_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_TIME Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_TIME")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_TIME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* HIST_SEQ Validation */
    if(TRS.get_int(in_node, "HIST_SEQ") == 0)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiphurfqc(&CWIPHURFQC);
    TRS.copy(CWIPHURFQC.WORK_DATE, sizeof(CWIPHURFQC.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPHURFQC.LINE_ID, sizeof(CWIPHURFQC.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPHURFQC.WORK_SHIFT, sizeof(CWIPHURFQC.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPHURFQC.BEFE_TYPE, sizeof(CWIPHURFQC.BEFE_TYPE), in_node, "BEFE_TYPE");
    TRS.copy(CWIPHURFQC.SIML_TYPE, sizeof(CWIPHURFQC.SIML_TYPE), in_node, "SIML_TYPE");
    TRS.copy(CWIPHURFQC.WORK_TIME, sizeof(CWIPHURFQC.WORK_TIME), in_node, "WORK_TIME");
    CWIPHURFQC.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
    CDB_select_cwiphurfqc(1, &CWIPHURFQC);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPHURFQC SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPHURFQC.WORK_DATE), CWIPHURFQC.WORK_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPHURFQC.LINE_ID), CWIPHURFQC.LINE_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPHURFQC.WORK_SHIFT), CWIPHURFQC.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "BEFE_TYPE", MP_STR, sizeof(CWIPHURFQC.BEFE_TYPE), CWIPHURFQC.BEFE_TYPE);
        TRS.add_fieldmsg(out_node, "SIML_TYPE", MP_STR, sizeof(CWIPHURFQC.SIML_TYPE), CWIPHURFQC.SIML_TYPE);
        TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CWIPHURFQC.WORK_TIME), CWIPHURFQC.WORK_TIME);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPHURFQC.HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "WORK_DATE", CWIPHURFQC.WORK_DATE, sizeof(CWIPHURFQC.WORK_DATE));
    TRS.add_string(out_node, "LINE_ID", CWIPHURFQC.LINE_ID, sizeof(CWIPHURFQC.LINE_ID));
    TRS.add_string(out_node, "WORK_SHIFT", CWIPHURFQC.WORK_SHIFT, sizeof(CWIPHURFQC.WORK_SHIFT));
    TRS.add_string(out_node, "BEFE_TYPE", CWIPHURFQC.BEFE_TYPE, sizeof(CWIPHURFQC.BEFE_TYPE));
    TRS.add_string(out_node, "SIML_TYPE", CWIPHURFQC.SIML_TYPE, sizeof(CWIPHURFQC.SIML_TYPE));
    TRS.add_string(out_node, "WORK_TIME", CWIPHURFQC.WORK_TIME, sizeof(CWIPHURFQC.WORK_TIME));
    TRS.add_int(out_node, "HIST_SEQ", CWIPHURFQC.HIST_SEQ);
    TRS.add_string(out_node, "PIC_NAME", CWIPHURFQC.PIC_NAME, sizeof(CWIPHURFQC.PIC_NAME));
    TRS.add_string(out_node, "MACHINE_NO", CWIPHURFQC.MACHINE_NO, sizeof(CWIPHURFQC.MACHINE_NO));
    TRS.add_string(out_node, "DEFECT_CODE", CWIPHURFQC.DEFECT_CODE, sizeof(CWIPHURFQC.DEFECT_CODE));
    TRS.add_string(out_node, "DEFECT_DETAIL", CWIPHURFQC.DEFECT_DETAIL, sizeof(CWIPHURFQC.DEFECT_DETAIL));
    TRS.add_string(out_node, "ROOT_CAUSE", CWIPHURFQC.ROOT_CAUSE, sizeof(CWIPHURFQC.ROOT_CAUSE));
    TRS.add_string(out_node, "ACTION_STTM", CWIPHURFQC.ACTION_STTM, sizeof(CWIPHURFQC.ACTION_STTM));
    TRS.add_string(out_node, "ACTION_EDTM", CWIPHURFQC.ACTION_EDTM, sizeof(CWIPHURFQC.ACTION_EDTM));
    TRS.add_string(out_node, "ACTION_PLAN", CWIPHURFQC.ACTION_PLAN, sizeof(CWIPHURFQC.ACTION_PLAN));
    TRS.add_string(out_node, "MONITORING_RESULT", CWIPHURFQC.MONITORING_RESULT, sizeof(CWIPHURFQC.MONITORING_RESULT));
    TRS.add_string(out_node, "CMF_1", CWIPHURFQC.CMF_1, sizeof(CWIPHURFQC.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPHURFQC.CMF_2, sizeof(CWIPHURFQC.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPHURFQC.CMF_3, sizeof(CWIPHURFQC.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPHURFQC.CMF_4, sizeof(CWIPHURFQC.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPHURFQC.CMF_5, sizeof(CWIPHURFQC.CMF_5));
    TRS.add_string(out_node, "CMF_6", CWIPHURFQC.CMF_6, sizeof(CWIPHURFQC.CMF_6));
    TRS.add_string(out_node, "CMF_7", CWIPHURFQC.CMF_7, sizeof(CWIPHURFQC.CMF_7));
    TRS.add_string(out_node, "CMF_8", CWIPHURFQC.CMF_8, sizeof(CWIPHURFQC.CMF_8));
    TRS.add_string(out_node, "CMF_9", CWIPHURFQC.CMF_9, sizeof(CWIPHURFQC.CMF_9));
    TRS.add_string(out_node, "CMF_10", CWIPHURFQC.CMF_10, sizeof(CWIPHURFQC.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPHURFQC.CREATE_USER_ID, sizeof(CWIPHURFQC.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPHURFQC.CREATE_TIME, sizeof(CWIPHURFQC.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPHURFQC.UPDATE_USER_ID, sizeof(CWIPHURFQC.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPHURFQC.UPDATE_TIME, sizeof(CWIPHURFQC.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Hourly_Fqc_Worklog",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

