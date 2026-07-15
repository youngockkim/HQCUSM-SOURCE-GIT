/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_day_inventory.c
    Description : View Day_Inventory function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Day_Inventory()
            + View Day_Inventory definition
        - CWIP_VIEW_DAY_INVENTORY()
            + Main sub function of CWIP_View_Day_Inventory function
            + View Day_Inventory definition
    Detail Description
        - CWIP_VIEW_DAY_INVENTORY()
            + h_proc_step
                + 1 : View Day_Inventory definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024-04-13             Create by Generator

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Day_Inventory()
        - View Day_Inventory definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Day_Inventory(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_DAY_INVENTORY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_DAY_INVENTORY", out_node);

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
    CWIP_VIEW_DAY_INVENTORY()
        - Main sub function of "CWIP_View_Day_Inventory" function
        - View Day_Inventory definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_DAY_INVENTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPDAYINV_TAG CWIPDAYINV;

    LOG_head("CWIP_VIEW_DAY_INVENTORY");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("invt_seq", MP_INT, TRS.get_int(in_node, "INVT_SEQ"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Day_Inventory",
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

    CDB_init_cwipdayinv(&CWIPDAYINV);
    TRS.copy(CWIPDAYINV.WORK_DATE, sizeof(CWIPDAYINV.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPDAYINV.FACTORY, sizeof(CWIPDAYINV.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPDAYINV.LINE_ID, sizeof(CWIPDAYINV.LINE_ID), in_node, "LINE_ID");
    CWIPDAYINV.INVT_SEQ = TRS.get_int(in_node, "INVT_SEQ");
    CDB_select_cwipdayinv(1, &CWIPDAYINV);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPDAYINV SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPDAYINV.WORK_DATE), CWIPDAYINV.WORK_DATE);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPDAYINV.FACTORY), CWIPDAYINV.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPDAYINV.LINE_ID), CWIPDAYINV.LINE_ID);
        TRS.add_fieldmsg(out_node, "INVT_SEQ", MP_INT, CWIPDAYINV.INVT_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "WORK_DATE", CWIPDAYINV.WORK_DATE, sizeof(CWIPDAYINV.WORK_DATE));
    TRS.add_string(out_node, "FACTORY", CWIPDAYINV.FACTORY, sizeof(CWIPDAYINV.FACTORY));
    TRS.add_string(out_node, "LINE_ID", CWIPDAYINV.LINE_ID, sizeof(CWIPDAYINV.LINE_ID));
    TRS.add_int(out_node, "INVT_SEQ", CWIPDAYINV.INVT_SEQ);
    TRS.add_string(out_node, "OPER_TYPE", CWIPDAYINV.OPER_TYPE, sizeof(CWIPDAYINV.OPER_TYPE));
    TRS.add_string(out_node, "OPER_NAME", CWIPDAYINV.OPER_NAME, sizeof(CWIPDAYINV.OPER_NAME));
    TRS.add_string(out_node, "MAT_ID", CWIPDAYINV.MAT_ID, sizeof(CWIPDAYINV.MAT_ID));
	TRS.add_double(out_node, "MAT_QTY", CWIPDAYINV.MAT_QTY);
    TRS.add_string(out_node, "BATCH_NO", CWIPDAYINV.BATCH_NO, sizeof(CWIPDAYINV.BATCH_NO));
    TRS.add_string(out_node, "TRAN_TIME", CWIPDAYINV.TRAN_TIME, sizeof(CWIPDAYINV.TRAN_TIME));
    TRS.add_string(out_node, "INVT_BRCD", CWIPDAYINV.INVT_BRCD, sizeof(CWIPDAYINV.INVT_BRCD));
    TRS.add_string(out_node, "INVT_MSGS", CWIPDAYINV.INVT_MSGS, sizeof(CWIPDAYINV.INVT_MSGS));
    TRS.add_string(out_node, "CMF_1", CWIPDAYINV.CMF_1, sizeof(CWIPDAYINV.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPDAYINV.CMF_2, sizeof(CWIPDAYINV.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPDAYINV.CMF_3, sizeof(CWIPDAYINV.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPDAYINV.CMF_4, sizeof(CWIPDAYINV.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPDAYINV.CMF_5, sizeof(CWIPDAYINV.CMF_5));
    TRS.add_string(out_node, "CMF_6", CWIPDAYINV.CMF_6, sizeof(CWIPDAYINV.CMF_6));
    TRS.add_string(out_node, "CMF_7", CWIPDAYINV.CMF_7, sizeof(CWIPDAYINV.CMF_7));
    TRS.add_string(out_node, "CMF_8", CWIPDAYINV.CMF_8, sizeof(CWIPDAYINV.CMF_8));
    TRS.add_string(out_node, "CMF_9", CWIPDAYINV.CMF_9, sizeof(CWIPDAYINV.CMF_9));
    TRS.add_string(out_node, "CMF_10", CWIPDAYINV.CMF_10, sizeof(CWIPDAYINV.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPDAYINV.CREATE_USER_ID, sizeof(CWIPDAYINV.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPDAYINV.CREATE_TIME, sizeof(CWIPDAYINV.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPDAYINV.UPDATE_USER_ID, sizeof(CWIPDAYINV.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPDAYINV.UPDATE_TIME, sizeof(CWIPDAYINV.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Day_Inventory",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

