/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_tb_cleaning_schedule.c
    Description : View Tb_Cleaning_Schedule function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Tb_Cleaning_Schedule()
            + View Tb_Cleaning_Schedule definition
        - CWIP_VIEW_TB_CLEANING_SCHEDULE()
            + Main sub function of CWIP_View_Tb_Cleaning_Schedule function
            + View Tb_Cleaning_Schedule definition
    Detail Description
        - CWIP_VIEW_TB_CLEANING_SCHEDULE()
            + h_proc_step
                + 1 : View Tb_Cleaning_Schedule definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/08/27             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Tb_Cleaning_Schedule()
        - View Tb_Cleaning_Schedule definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Tb_Cleaning_Schedule(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_TB_CLEANING_SCHEDULE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_TB_CLEANING_SCHEDULE", out_node);

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
    CWIP_VIEW_TB_CLEANING_SCHEDULE()
        - Main sub function of "CWIP_View_Tb_Cleaning_Schedule" function
        - View Tb_Cleaning_Schedule definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_TB_CLEANING_SCHEDULE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASTBRCLN_TAG CRASTBRCLN;

    LOG_head("CWIP_VIEW_TB_CLEANING_SCHEDULE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("clng_date", MP_NSTR, TRS.get_string(in_node, "CLNG_DATE"));
    LOG_add("clng_time", MP_NSTR, TRS.get_string(in_node, "CLNG_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Tb_Cleaning_Schedule",
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
    /* CLNG_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CLNG_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CLNG_TIME Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CLNG_TIME")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_crastbrcln(&CRASTBRCLN);
    TRS.copy(CRASTBRCLN.FACTORY, sizeof(CRASTBRCLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASTBRCLN.LINE_ID, sizeof(CRASTBRCLN.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CRASTBRCLN.WORK_SHIFT, sizeof(CRASTBRCLN.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CRASTBRCLN.RES_ID, sizeof(CRASTBRCLN.RES_ID), in_node, "RES_ID");
    TRS.copy(CRASTBRCLN.CLNG_DATE, sizeof(CRASTBRCLN.CLNG_DATE), in_node, "CLNG_DATE");
    TRS.copy(CRASTBRCLN.CLNG_TIME, sizeof(CRASTBRCLN.CLNG_TIME), in_node, "CLNG_TIME");
    CDB_select_crastbrcln(1, &CRASTBRCLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CRASTBRCLN SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRCLN.FACTORY), CRASTBRCLN.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASTBRCLN.LINE_ID), CRASTBRCLN.LINE_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASTBRCLN.WORK_SHIFT), CRASTBRCLN.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTBRCLN.RES_ID), CRASTBRCLN.RES_ID);
        TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_STR, sizeof(CRASTBRCLN.CLNG_DATE), CRASTBRCLN.CLNG_DATE);
        TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_STR, sizeof(CRASTBRCLN.CLNG_TIME), CRASTBRCLN.CLNG_TIME);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CRASTBRCLN.FACTORY, sizeof(CRASTBRCLN.FACTORY));
    TRS.add_string(out_node, "LINE_ID", CRASTBRCLN.LINE_ID, sizeof(CRASTBRCLN.LINE_ID));
    TRS.add_string(out_node, "WORK_SHIFT", CRASTBRCLN.WORK_SHIFT, sizeof(CRASTBRCLN.WORK_SHIFT));
    TRS.add_string(out_node, "RES_ID", CRASTBRCLN.RES_ID, sizeof(CRASTBRCLN.RES_ID));
    TRS.add_string(out_node, "CLNG_DATE", CRASTBRCLN.CLNG_DATE, sizeof(CRASTBRCLN.CLNG_DATE));
    TRS.add_string(out_node, "CLNG_TIME", CRASTBRCLN.CLNG_TIME, sizeof(CRASTBRCLN.CLNG_TIME));
    TRS.add_string(out_node, "CLNG_TYPE", CRASTBRCLN.CLNG_TYPE, sizeof(CRASTBRCLN.CLNG_TYPE));
    TRS.add_string(out_node, "RQST_DPMT", CRASTBRCLN.RQST_DPMT, sizeof(CRASTBRCLN.RQST_DPMT));
    TRS.add_string(out_node, "CLNG_PLAN", CRASTBRCLN.CLNG_PLAN, sizeof(CRASTBRCLN.CLNG_PLAN));
    TRS.add_string(out_node, "CLNG_CMMT", CRASTBRCLN.CLNG_CMMT, sizeof(CRASTBRCLN.CLNG_CMMT));
    TRS.add_string(out_node, "CMF_1", CRASTBRCLN.CMF_1, sizeof(CRASTBRCLN.CMF_1));
    TRS.add_string(out_node, "CMF_2", CRASTBRCLN.CMF_2, sizeof(CRASTBRCLN.CMF_2));
    TRS.add_string(out_node, "CMF_3", CRASTBRCLN.CMF_3, sizeof(CRASTBRCLN.CMF_3));
    TRS.add_string(out_node, "CMF_4", CRASTBRCLN.CMF_4, sizeof(CRASTBRCLN.CMF_4));
    TRS.add_string(out_node, "CMF_5", CRASTBRCLN.CMF_5, sizeof(CRASTBRCLN.CMF_5));
    TRS.add_string(out_node, "CMF_6", CRASTBRCLN.CMF_6, sizeof(CRASTBRCLN.CMF_6));
    TRS.add_string(out_node, "CMF_7", CRASTBRCLN.CMF_7, sizeof(CRASTBRCLN.CMF_7));
    TRS.add_string(out_node, "CMF_8", CRASTBRCLN.CMF_8, sizeof(CRASTBRCLN.CMF_8));
    TRS.add_string(out_node, "CMF_9", CRASTBRCLN.CMF_9, sizeof(CRASTBRCLN.CMF_9));
    TRS.add_string(out_node, "CMF_10", CRASTBRCLN.CMF_10, sizeof(CRASTBRCLN.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CRASTBRCLN.CREATE_USER_ID, sizeof(CRASTBRCLN.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CRASTBRCLN.CREATE_TIME, sizeof(CRASTBRCLN.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CRASTBRCLN.UPDATE_USER_ID, sizeof(CRASTBRCLN.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CRASTBRCLN.UPDATE_TIME, sizeof(CRASTBRCLN.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Tb_Cleaning_Schedule",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

