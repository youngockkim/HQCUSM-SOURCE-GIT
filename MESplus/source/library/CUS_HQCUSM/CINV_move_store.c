/******************************************************************************'

    System      : MESplus
    Module      : CINV
    File Name   : CINV_move_store.c
    Description : Customized Move Store Lot to Store Service

    MES Version : 5.3.4 ~

    Function List
        - CINV_Move_Store()
            + Setup service interface function
        - CINV_MOVE_STORE()
            + Main sub function of CINV_Move_Store function
            + Setup service main business function
        - CINV_Move_Store_Validation()
            + Main sub function of CINV_MOVE_STORE function
            + Check the condition for create/update/delete
    Detail Description
        - CINV_MOVE_STORE()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-29  jhji           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"

int CINV_Move_Store_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CINV_Move_Store()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CINV_Move_Store(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CINV_MOVE_STORE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CINV_MOVE_STORE", out_node);

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
    CINV_MOVE_STORE()
        - Main sub function of "CINV_Move_Store" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CINV_MOVE_STORE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MWIPLOTSTS_TAG MWIPLOTSTS_OLD;
    struct MWIPLOTHIS_TAG MWIPLOTHIS;
    struct MWIPLOTHIS_TAG MWIPLOTHIS_OLD;

    char s_sys_time[14];

    LOG_head("CINV_MOVE_STORE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    // SYSTEM TIME SETTING
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(CINV_Move_Store_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    //Select Last mwiplothis Data
    DBC_init_mwiplothis(&MWIPLOTHIS);
    TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
    MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
    DBC_select_mwiplothis(1, &MWIPLOTHIS);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTHIS.FACTORY), MWIPLOTHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }
    

    //Set Lot History Data
    MWIPLOTHIS.HIST_SEQ += 1;
    memcpy(MWIPLOTHIS.TRAN_TIME, s_sys_time, sizeof(MWIPLOTHIS.TRAN_TIME));
    memcpy(MWIPLOTHIS.SYS_TRAN_TIME, s_sys_time, sizeof(MWIPLOTHIS.SYS_TRAN_TIME));
    memcpy(MWIPLOTHIS.TRAN_CODE, HQCEL_LOT_TRAN_MOVE_STORE, sizeof(HQCEL_LOT_TRAN_MOVE_STORE));
    TRS.copy(MWIPLOTHIS.OPER, sizeof(MWIPLOTHIS.OPER), in_node, "TO_OPER");
    memcpy(MWIPLOTHIS.OPER_IN_TIME, s_sys_time, sizeof(MWIPLOTHIS.OPER_IN_TIME));
    memcpy(MWIPLOTHIS.OLD_OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
    memcpy(MWIPLOTHIS.OLD_OPER_IN_TIME, MWIPLOTSTS.OPER_IN_TIME, sizeof(MWIPLOTSTS.OPER_IN_TIME));
    TRS.copy(MWIPLOTHIS.TRAN_USER_ID, sizeof(MWIPLOTHIS.TRAN_USER_ID), in_node, IN_USERID);
    MWIPLOTHIS.PREV_ACTIVE_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

    //Update Lot History
    DBC_insert_mwiplothis(&MWIPLOTHIS);

    //Set Lot Data
    memcpy(MWIPLOTSTS.OPER, MWIPLOTHIS.OPER, sizeof(MWIPLOTSTS.OPER));
    memcpy(MWIPLOTSTS.OPER_IN_TIME, MWIPLOTHIS.TRAN_TIME, sizeof(MWIPLOTHIS.TRAN_TIME));
    memcpy(MWIPLOTSTS.LAST_TRAN_TIME, MWIPLOTHIS.TRAN_TIME, sizeof(MWIPLOTHIS.TRAN_TIME));
    memcpy(MWIPLOTSTS.LAST_TRAN_CODE, MWIPLOTHIS.TRAN_CODE, sizeof(MWIPLOTHIS.TRAN_CODE));
    MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ = MWIPLOTHIS.HIST_SEQ;
    MWIPLOTSTS.LAST_HIST_SEQ = MWIPLOTHIS.HIST_SEQ;

    //Update Lot Status
    DBC_update_mwiplotsts(1, &MWIPLOTSTS);


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CINV_Move_Store_Validation()
        - Main sub function of "CINV_MOVE_STORE" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CINV_Move_Store_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

   
    return MP_TRUE;
}

