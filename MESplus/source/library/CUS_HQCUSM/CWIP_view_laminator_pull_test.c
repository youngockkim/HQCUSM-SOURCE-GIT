/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_laminator_pull_test.c
    Description : View Laminator_Pull_Test function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Laminator_Pull_Test()
            + View Laminator_Pull_Test definition
        - CWIP_VIEW_LAMINATOR_PULL_TEST()
            + Main sub function of CWIP_View_Laminator_Pull_Test function
            + View Laminator_Pull_Test definition
    Detail Description
        - CWIP_VIEW_LAMINATOR_PULL_TEST()
            + h_proc_step
                + 1 : View Laminator_Pull_Test definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025-04-14             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>

/*******************************************************************************
    CWIP_View_Laminator_Pull_Test()
        - View Laminator_Pull_Test definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Laminator_Pull_Test(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_LAMINATOR_PULL_TEST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_LAMINATOR_PULL_TEST", out_node);

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
    CWIP_VIEW_LAMINATOR_PULL_TEST()
        - Main sub function of "CWIP_View_Laminator_Pull_Test" function
        - View Laminator_Pull_Test definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LAMINATOR_PULL_TEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLAMPTS_TAG CWIPLAMPTS;

    LOG_head("CWIP_VIEW_LAMINATOR_PULL_TEST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("msmt_date", MP_NSTR, TRS.get_string(in_node, "MSMT_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("module_no", MP_INT, TRS.get_int(in_node, "MODULE_NO"));
    LOG_add("part_type", MP_NSTR, TRS.get_string(in_node, "PART_TYPE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Laminator_Pull_Test",
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

    /* MSMT_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "MSMT_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_NVST);

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
    /* MODULE_NO Validation */
    if(TRS.get_int(in_node, "MODULE_NO") == 0)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "MODULE_NO", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* PART_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "PART_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "PART_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplampts(&CWIPLAMPTS);
    TRS.copy(CWIPLAMPTS.MSMT_DATE, sizeof(CWIPLAMPTS.MSMT_DATE), in_node, "MSMT_DATE");
    TRS.copy(CWIPLAMPTS.LINE_ID, sizeof(CWIPLAMPTS.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPLAMPTS.RES_ID, sizeof(CWIPLAMPTS.RES_ID), in_node, "RES_ID");
    CWIPLAMPTS.MODULE_NO = TRS.get_int(in_node, "MODULE_NO");
    TRS.copy(CWIPLAMPTS.PART_TYPE, sizeof(CWIPLAMPTS.PART_TYPE), in_node, "PART_TYPE");
    CDB_select_cwiplampts(1, &CWIPLAMPTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPLAMPTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_STR, sizeof(CWIPLAMPTS.MSMT_DATE), CWIPLAMPTS.MSMT_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMPTS.LINE_ID), CWIPLAMPTS.LINE_ID);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMPTS.RES_ID), CWIPLAMPTS.RES_ID);
        TRS.add_fieldmsg(out_node, "MODULE_NO", MP_INT, CWIPLAMPTS.MODULE_NO);
        TRS.add_fieldmsg(out_node, "PART_TYPE", MP_STR, sizeof(CWIPLAMPTS.PART_TYPE), CWIPLAMPTS.PART_TYPE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "MSMT_DATE", CWIPLAMPTS.MSMT_DATE, sizeof(CWIPLAMPTS.MSMT_DATE));
    TRS.add_string(out_node, "LINE_ID", CWIPLAMPTS.LINE_ID, sizeof(CWIPLAMPTS.LINE_ID));
    TRS.add_string(out_node, "RES_ID", CWIPLAMPTS.RES_ID, sizeof(CWIPLAMPTS.RES_ID));
    TRS.add_int(out_node, "MODULE_NO", CWIPLAMPTS.MODULE_NO);
    TRS.add_string(out_node, "PART_TYPE", CWIPLAMPTS.PART_TYPE, sizeof(CWIPLAMPTS.PART_TYPE));
    TRS.add_double(out_node, "MSMT_POS1", CWIPLAMPTS.MSMT_POS1);
    TRS.add_double(out_node, "MSMT_POS2", CWIPLAMPTS.MSMT_POS2);
    TRS.add_double(out_node, "MSMT_POS3", CWIPLAMPTS.MSMT_POS3);
    TRS.add_double(out_node, "MSMT_POS4", CWIPLAMPTS.MSMT_POS4);
    TRS.add_double(out_node, "MSMT_POS5", CWIPLAMPTS.MSMT_POS5);
    TRS.add_double(out_node, "MSMT_POS6", CWIPLAMPTS.MSMT_POS6);
    TRS.add_double(out_node, "MSMT_POS7", CWIPLAMPTS.MSMT_POS7);
    TRS.add_double(out_node, "MSMT_POS8", CWIPLAMPTS.MSMT_POS8);
    TRS.add_double(out_node, "MSMT_POS9", CWIPLAMPTS.MSMT_POS9);
    TRS.add_double(out_node, "MSMT_POS10", CWIPLAMPTS.MSMT_POS10);
    TRS.add_string(out_node, "CMF_1", CWIPLAMPTS.CMF_1, sizeof(CWIPLAMPTS.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPLAMPTS.CMF_2, sizeof(CWIPLAMPTS.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPLAMPTS.CMF_3, sizeof(CWIPLAMPTS.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPLAMPTS.CMF_4, sizeof(CWIPLAMPTS.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPLAMPTS.CMF_5, sizeof(CWIPLAMPTS.CMF_5));
    TRS.add_string(out_node, "CMF_6", CWIPLAMPTS.CMF_6, sizeof(CWIPLAMPTS.CMF_6));
    TRS.add_string(out_node, "CMF_7", CWIPLAMPTS.CMF_7, sizeof(CWIPLAMPTS.CMF_7));
    TRS.add_string(out_node, "CMF_8", CWIPLAMPTS.CMF_8, sizeof(CWIPLAMPTS.CMF_8));
    TRS.add_string(out_node, "CMF_9", CWIPLAMPTS.CMF_9, sizeof(CWIPLAMPTS.CMF_9));
    TRS.add_string(out_node, "CMF_10", CWIPLAMPTS.CMF_10, sizeof(CWIPLAMPTS.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPLAMPTS.CREATE_USER_ID, sizeof(CWIPLAMPTS.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPLAMPTS.CREATE_TIME, sizeof(CWIPLAMPTS.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPLAMPTS.UPDATE_USER_ID, sizeof(CWIPLAMPTS.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPLAMPTS.UPDATE_TIME, sizeof(CWIPLAMPTS.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Laminator_Pull_Test",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

