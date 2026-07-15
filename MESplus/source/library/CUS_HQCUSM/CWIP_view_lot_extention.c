/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_lot_extention.c
    Description : View lot_extention function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_lot_extention()
            + View lot_extention definition
        - CWIP_VIEW_LOT_EXTENTION()
            + Main sub function of CWIP_View_lot_extention function
            + View lot_extention definition
    Detail Description
        - CWIP_VIEW_LOT_EXTENTION()
            + h_proc_step
                + 1 : View lot_extention definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-05-19             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_lot_extention()
        - View lot_extention definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_lot_extention(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_LOT_EXTENTION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_LOT_EXTENTION", out_node);

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
    CWIP_VIEW_LOT_EXTENTION()
        - Main sub function of "CWIP_View_lot_extention" function
        - View lot_extention definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LOT_EXTENTION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTEXT_TAG CWIPLOTEXT;

    LOG_head("CWIP_VIEW_LOT_EXTENTION");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_lot_extention",
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

    /* LOT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplotext(&CWIPLOTEXT);
    TRS.copy(CWIPLOTEXT.LOT_ID, sizeof(CWIPLOTEXT.LOT_ID), in_node, "LOT_ID");
    CDB_select_cwiplotext(1, &CWIPLOTEXT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPLOTEXT SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTEXT.LOT_ID), CWIPLOTEXT.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "LOT_ID", CWIPLOTEXT.LOT_ID, sizeof(CWIPLOTEXT.LOT_ID));
    TRS.add_string(out_node, "CMF_1", CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPLOTEXT.CMF_4, sizeof(CWIPLOTEXT.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPLOTEXT.CMF_5, sizeof(CWIPLOTEXT.CMF_5));
    TRS.add_string(out_node, "CMF_6", CWIPLOTEXT.CMF_6, sizeof(CWIPLOTEXT.CMF_6));
    TRS.add_string(out_node, "CMF_7", CWIPLOTEXT.CMF_7, sizeof(CWIPLOTEXT.CMF_7));
    TRS.add_string(out_node, "CMF_8", CWIPLOTEXT.CMF_8, sizeof(CWIPLOTEXT.CMF_8));
    TRS.add_string(out_node, "CMF_9", CWIPLOTEXT.CMF_9, sizeof(CWIPLOTEXT.CMF_9));
    TRS.add_string(out_node, "CMF_10", CWIPLOTEXT.CMF_10, sizeof(CWIPLOTEXT.CMF_10));
    TRS.add_string(out_node, "CMF_11", CWIPLOTEXT.CMF_11, sizeof(CWIPLOTEXT.CMF_11));
    TRS.add_string(out_node, "CMF_12", CWIPLOTEXT.CMF_12, sizeof(CWIPLOTEXT.CMF_12));
    TRS.add_string(out_node, "CMF_13", CWIPLOTEXT.CMF_13, sizeof(CWIPLOTEXT.CMF_13));
    TRS.add_string(out_node, "CMF_14", CWIPLOTEXT.CMF_14, sizeof(CWIPLOTEXT.CMF_14));
    TRS.add_string(out_node, "CMF_15", CWIPLOTEXT.CMF_15, sizeof(CWIPLOTEXT.CMF_15));
    TRS.add_string(out_node, "CMF_16", CWIPLOTEXT.CMF_16, sizeof(CWIPLOTEXT.CMF_16));
    TRS.add_string(out_node, "CMF_17", CWIPLOTEXT.CMF_17, sizeof(CWIPLOTEXT.CMF_17));
    TRS.add_string(out_node, "CMF_18", CWIPLOTEXT.CMF_18, sizeof(CWIPLOTEXT.CMF_18));
    TRS.add_string(out_node, "CMF_19", CWIPLOTEXT.CMF_19, sizeof(CWIPLOTEXT.CMF_19));
    TRS.add_string(out_node, "CMF_20", CWIPLOTEXT.CMF_20, sizeof(CWIPLOTEXT.CMF_20));
    TRS.add_string(out_node, "CMF_21", CWIPLOTEXT.CMF_21, sizeof(CWIPLOTEXT.CMF_21));
    TRS.add_string(out_node, "CMF_22", CWIPLOTEXT.CMF_22, sizeof(CWIPLOTEXT.CMF_22));
    TRS.add_string(out_node, "CMF_23", CWIPLOTEXT.CMF_23, sizeof(CWIPLOTEXT.CMF_23));
    TRS.add_string(out_node, "CMF_24", CWIPLOTEXT.CMF_24, sizeof(CWIPLOTEXT.CMF_24));
    TRS.add_string(out_node, "CMF_25", CWIPLOTEXT.CMF_25, sizeof(CWIPLOTEXT.CMF_25));
    TRS.add_string(out_node, "CMF_26", CWIPLOTEXT.CMF_26, sizeof(CWIPLOTEXT.CMF_26));
    TRS.add_string(out_node, "CMF_27", CWIPLOTEXT.CMF_27, sizeof(CWIPLOTEXT.CMF_27));
    TRS.add_string(out_node, "CMF_28", CWIPLOTEXT.CMF_28, sizeof(CWIPLOTEXT.CMF_28));
    TRS.add_string(out_node, "CMF_29", CWIPLOTEXT.CMF_29, sizeof(CWIPLOTEXT.CMF_29));
    TRS.add_string(out_node, "CMF_30", CWIPLOTEXT.CMF_30, sizeof(CWIPLOTEXT.CMF_30));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPLOTEXT.CREATE_USER_ID, sizeof(CWIPLOTEXT.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPLOTEXT.CREATE_TIME, sizeof(CWIPLOTEXT.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPLOTEXT.UPDATE_USER_ID, sizeof(CWIPLOTEXT.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPLOTEXT.UPDATE_TIME, sizeof(CWIPLOTEXT.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_lot_extention",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

