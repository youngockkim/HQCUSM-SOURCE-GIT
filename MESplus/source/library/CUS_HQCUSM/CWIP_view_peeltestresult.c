/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIPCore_view_peeltestresult.c
    Description : View PeelTestResult function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_PeelTestResult()
            + View PeelTestResult definition
        - CWIP_VIEW_PEELTESTRESULT()
            + Main sub function of CWIP_View_PeelTestResult function
            + View PeelTestResult definition
    Detail Description
        - CWIP_VIEW_PEELTESTRESULT()
            + h_proc_step
                + 1 : View PeelTestResult definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/06/24             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>

/*******************************************************************************
    CWIP_View_PeelTestResult()
        - View PeelTestResult definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_PeelTestResult(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_PEELTESTRESULT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_PEELTESTRESULT", out_node);

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
    CWIP_VIEW_PEELTESTRESULT()
        - Main sub function of "CWIP_View_PeelTestResult" function
        - View PeelTestResult definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_PEELTESTRESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPPTSRPT_TAG CWIPPTSRPT;

    LOG_head("CWIP_VIEW_PEELTESTRESULT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("ptst_date", MP_NSTR, TRS.get_string(in_node, "PTST_DATE"));
    LOG_add("bsbr_pos", MP_NSTR, TRS.get_string(in_node, "BSBR_POS"));
    LOG_add("pos_point", MP_INT, TRS.get_int(in_node, "POS_POINT"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_PeelTestResult",
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
    /* PTST_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "PTST_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "PTST_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* BSBR_POS Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "BSBR_POS")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "BSBR_POS", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* POS_POINT Validation */
    if(TRS.get_int(in_node, "POS_POINT") == 0)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "POS_POINT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwipptsrpt(&CWIPPTSRPT);
    TRS.copy(CWIPPTSRPT.FACTORY, sizeof(CWIPPTSRPT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPPTSRPT.LINE_ID, sizeof(CWIPPTSRPT.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPPTSRPT.PTST_DATE, sizeof(CWIPPTSRPT.PTST_DATE), in_node, "PTST_DATE");
    TRS.copy(CWIPPTSRPT.BSBR_POS, sizeof(CWIPPTSRPT.BSBR_POS), in_node, "BSBR_POS");
    CWIPPTSRPT.POS_POINT = TRS.get_int(in_node, "POS_POINT");
    CDB_select_cwipptsrpt(1, &CWIPPTSRPT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPPTSRPT SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTSRPT.FACTORY), CWIPPTSRPT.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTSRPT.LINE_ID), CWIPPTSRPT.LINE_ID);
        TRS.add_fieldmsg(out_node, "PTST_DATE", MP_STR, sizeof(CWIPPTSRPT.PTST_DATE), CWIPPTSRPT.PTST_DATE);
        TRS.add_fieldmsg(out_node, "BSBR_POS", MP_STR, sizeof(CWIPPTSRPT.BSBR_POS), CWIPPTSRPT.BSBR_POS);
        TRS.add_fieldmsg(out_node, "POS_POINT", MP_INT, CWIPPTSRPT.POS_POINT);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CWIPPTSRPT.FACTORY, sizeof(CWIPPTSRPT.FACTORY));
    TRS.add_string(out_node, "LINE_ID", CWIPPTSRPT.LINE_ID, sizeof(CWIPPTSRPT.LINE_ID));
    TRS.add_string(out_node, "PTST_DATE", CWIPPTSRPT.PTST_DATE, sizeof(CWIPPTSRPT.PTST_DATE));
    TRS.add_string(out_node, "BSBR_POS", CWIPPTSRPT.BSBR_POS, sizeof(CWIPPTSRPT.BSBR_POS));
    TRS.add_int(out_node, "POS_POINT", CWIPPTSRPT.POS_POINT);
    TRS.add_double(out_node, "PEAK", CWIPPTSRPT.PEAK);
    TRS.add_string(out_node, "MENISCUS", CWIPPTSRPT.MENISCUS, sizeof(CWIPPTSRPT.MENISCUS));
    TRS.add_double(out_node, "WIDTH_LEFT", CWIPPTSRPT.WIDTH_LEFT);
    TRS.add_double(out_node, "WIDTH_RIGHT", CWIPPTSRPT.WIDTH_RIGHT);
    TRS.add_string(out_node, "CMF_1", CWIPPTSRPT.CMF_1, sizeof(CWIPPTSRPT.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPPTSRPT.CMF_2, sizeof(CWIPPTSRPT.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPPTSRPT.CMF_3, sizeof(CWIPPTSRPT.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPPTSRPT.CMF_4, sizeof(CWIPPTSRPT.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPPTSRPT.CMF_5, sizeof(CWIPPTSRPT.CMF_5));
    TRS.add_string(out_node, "CMF_6", CWIPPTSRPT.CMF_6, sizeof(CWIPPTSRPT.CMF_6));
    TRS.add_string(out_node, "CMF_7", CWIPPTSRPT.CMF_7, sizeof(CWIPPTSRPT.CMF_7));
    TRS.add_string(out_node, "CMF_8", CWIPPTSRPT.CMF_8, sizeof(CWIPPTSRPT.CMF_8));
    TRS.add_string(out_node, "CMF_9", CWIPPTSRPT.CMF_9, sizeof(CWIPPTSRPT.CMF_9));
    TRS.add_string(out_node, "CMF_10", CWIPPTSRPT.CMF_10, sizeof(CWIPPTSRPT.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPPTSRPT.CREATE_USER_ID, sizeof(CWIPPTSRPT.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPPTSRPT.CREATE_TIME, sizeof(CWIPPTSRPT.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPPTSRPT.UPDATE_USER_ID, sizeof(CWIPPTSRPT.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPPTSRPT.UPDATE_TIME, sizeof(CWIPPTSRPT.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_PeelTestResult",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

