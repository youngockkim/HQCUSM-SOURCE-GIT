/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_xlinktest.c
    Description : View Xlinktest function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_Xlinktest()
            + View Xlinktest definition
        - CRAS_VIEW_XLINKTEST()
            + Main sub function of CRAS_View_Xlinktest function
            + View Xlinktest definition
    Detail Description
        - CRAS_VIEW_XLINKTEST()
            + h_proc_step
                + 1 : View Xlinktest definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/04/11             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_Xlinktest()
        - View Xlinktest definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Xlinktest(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_XLINKTEST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_XLINKTEST", out_node);

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
    CRAS_VIEW_XLINKTEST()
        - Main sub function of "CRAS_View_Xlinktest" function
        - View Xlinktest definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_XLINKTEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASXLINKR_TAG CRASXLINKR;

    //LOG_head("CRAS_VIEW_XLINKTEST");
    //LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    //LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    //LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    //LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    //LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    //LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    //LOG_add("lami_numer", MP_NSTR, TRS.get_string(in_node, "LAMI_NUMER"));
    //LOG_add("lami_pos", MP_NSTR, TRS.get_string(in_node, "LAMI_POS"));
    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    ///* Not use in customizing
    //if(COM_proc_user_routine("CRAS", "CRAS_View_Xlinktest",
    //                         MP_UPOINT_BEFORE,
    //                         in_node,
    //                         out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    //*/

    ///* ProcStep Validation */
    //if(COM_service_validation(s_msg_code,
    //                          in_node,
    //                          out_node,
    //                          TRS.get_procstep(in_node),
    //                          "1") == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    ///* WORK_DATE Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* LINE_ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* LAMI_NUMER Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LAMI_NUMER")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "LAMI_NUMER", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* LAMI_POS Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LAMI_POS")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "LAMI_POS", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    //DBC_init_crasxlinkr(&CRASXLINKR);
    //TRS.copy(CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE), in_node, "WORK_DATE");
    //TRS.copy(CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID), in_node, "LINE_ID");
    //TRS.copy(CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER), in_node, "LAMI_NUMER");
    //TRS.copy(CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS), in_node, "LAMI_POS");
    //DBC_select_crasxlinkr(1, &CRASXLINKR);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    strcpy(s_msg_code, "CRAS-9999");
    //    TRS.add_fieldmsg(out_node, "CRASXLINKR SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASXLINKR.WORK_DATE), CRASXLINKR.WORK_DATE);
    //    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASXLINKR.LINE_ID), CRASXLINKR.LINE_ID);
    //    TRS.add_fieldmsg(out_node, "LAMI_NUMER", MP_STR, sizeof(CRASXLINKR.LAMI_NUMER), CRASXLINKR.LAMI_NUMER);
    //    TRS.add_fieldmsg(out_node, "LAMI_POS", MP_STR, sizeof(CRASXLINKR.LAMI_POS), CRASXLINKR.LAMI_POS);
    //    TRS.add_dberrmsg(out_node, DB_error_msg);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;

    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    //TRS.add_string(out_node, "WORK_DATE", CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE));
    //TRS.add_string(out_node, "LINE_ID", CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID));
    //TRS.add_string(out_node, "LAMI_NUMER", CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER));
    //TRS.add_string(out_node, "LAMI_POS", CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS));
    //TRS.add_string(out_node, "TEST_DATE", CRASXLINKR.TEST_DATE, sizeof(CRASXLINKR.TEST_DATE));
    //TRS.add_double(out_node, "LX11", CRASXLINKR.LX11);
    //TRS.add_double(out_node, "LX12", CRASXLINKR.LX12);
    //TRS.add_double(out_node, "LX21", CRASXLINKR.LX21);
    //TRS.add_double(out_node, "LX22", CRASXLINKR.LX22);
    //TRS.add_double(out_node, "LX31", CRASXLINKR.LX31);
    //TRS.add_double(out_node, "LX32", CRASXLINKR.LX32);
    //TRS.add_double(out_node, "LX41", CRASXLINKR.LX41);
    //TRS.add_double(out_node, "LX42", CRASXLINKR.LX42);
    //TRS.add_double(out_node, "LX51", CRASXLINKR.LX51);
    //TRS.add_double(out_node, "LX52", CRASXLINKR.LX52);
    //TRS.add_double(out_node, "LXTAT1", CRASXLINKR.LXTAT1);
    //TRS.add_double(out_node, "LXTAT2", CRASXLINKR.LXTAT2);
    //TRS.add_double(out_node, "DX11", CRASXLINKR.DX11);
    //TRS.add_double(out_node, "DX12", CRASXLINKR.DX12);
    //TRS.add_double(out_node, "DX21", CRASXLINKR.DX21);
    //TRS.add_double(out_node, "DX22", CRASXLINKR.DX22);
    //TRS.add_double(out_node, "DX31", CRASXLINKR.DX31);
    //TRS.add_double(out_node, "DX32", CRASXLINKR.DX32);
    //TRS.add_double(out_node, "DX41", CRASXLINKR.DX41);
    //TRS.add_double(out_node, "DX42", CRASXLINKR.DX42);
    //TRS.add_double(out_node, "DX51", CRASXLINKR.DX51);
    //TRS.add_double(out_node, "DX52", CRASXLINKR.DX52);
    //TRS.add_double(out_node, "DXTAT1", CRASXLINKR.DXTAT1);
    //TRS.add_double(out_node, "DXTAT2", CRASXLINKR.DXTAT2);
    //TRS.add_string(out_node, "CREATE_USER_ID", CRASXLINKR.CREATE_USER_ID, sizeof(CRASXLINKR.CREATE_USER_ID));
    //TRS.add_string(out_node, "TRAN_TIME", CRASXLINKR.TRAN_TIME, sizeof(CRASXLINKR.TRAN_TIME));
    //TRS.add_string(out_node, "UPDATE_USER_ID", CRASXLINKR.UPDATE_USER_ID, sizeof(CRASXLINKR.UPDATE_USER_ID));
    //TRS.add_string(out_node, "UPDATE_TIME", CRASXLINKR.UPDATE_TIME, sizeof(CRASXLINKR.UPDATE_TIME));
    //TRS.add_string(out_node, "CMF_1", CRASXLINKR.CMF_1, sizeof(CRASXLINKR.CMF_1));
    //TRS.add_string(out_node, "CMF_2", CRASXLINKR.CMF_2, sizeof(CRASXLINKR.CMF_2));
    //TRS.add_string(out_node, "CMF_3", CRASXLINKR.CMF_3, sizeof(CRASXLINKR.CMF_3));
    //TRS.add_string(out_node, "CMF_4", CRASXLINKR.CMF_4, sizeof(CRASXLINKR.CMF_4));
    //TRS.add_string(out_node, "CMF_5", CRASXLINKR.CMF_5, sizeof(CRASXLINKR.CMF_5));
    //TRS.add_string(out_node, "CMF_6", CRASXLINKR.CMF_6, sizeof(CRASXLINKR.CMF_6));
    //TRS.add_string(out_node, "CMF_7", CRASXLINKR.CMF_7, sizeof(CRASXLINKR.CMF_7));
    //TRS.add_string(out_node, "CMF_8", CRASXLINKR.CMF_8, sizeof(CRASXLINKR.CMF_8));
    //TRS.add_string(out_node, "CMF_9", CRASXLINKR.CMF_9, sizeof(CRASXLINKR.CMF_9));
    //TRS.add_string(out_node, "CMF_10", CRASXLINKR.CMF_10, sizeof(CRASXLINKR.CMF_10));

    ///* Not use in customizing
    //if(COM_proc_user_routine("CRAS", "CRAS_View_Xlinktest",
    //                         MP_UPOINT_AFTER,
    //                         in_node,
    //                         out_node) == MP_FALSE) return MP_FALSE;
    //*/

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

