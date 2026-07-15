/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : MES_multi_transaction.c
    Description : user function of user defined shared library

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/02/16  Aiden          Create

    Copyright(C) 1998-2009 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "SLIB_common.h"
#include <WIPCore_common.h>
#include <RASCore_common.h>


/*******************************************************************************
    Multi_Transaction_1()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int Multi_Transaction_1(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = MULTI_TRANSACTION_1(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "MULTI_TRANSACTION_1", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    Multi_Transaction_2()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int Multi_Transaction_2(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = MULTI_TRANSACTION_2(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "MULTI_TRANSACTION_2", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    MULTI_TRANSACTION_1()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int MULTI_TRANSACTION_1(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    TRSNode *start_lot;
    TRSNode *end_lot;
    TRSNode *res_lst_in;
    TRSNode *res_lst_out;

    int     i;
    TRSNode **res_lst;


    LOG_head("MULTI_TRANSACTION_1");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    res_lst_in = TRS.create_node("RES_LIST_IN");
    res_lst_out = TRS.create_node("RES_LIST_OUT");

    TRS.add_char(res_lst_in, IN_PROCSTEP, '2');
    TRS.add_enc_nstring(res_lst_in, IN_USERID, TRS.get_userid(in_node));
    TRS.add_char(res_lst_in, IN_LANGUAGE, TRS.get_language(in_node));
    TRS.add_nstring(res_lst_in, IN_FACTORY, TRS.get_factory(in_node));
    TRS.add_string(res_lst_in, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    TRS.add_int(res_lst_in, "MAT_VER", MWIPLOTSTS.MAT_VER);
    TRS.add_string(res_lst_in, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
    TRS.add_string(res_lst_in, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

    if(RAS_VIEW_RESOURCE_LIST(s_msg_code, res_lst_in, res_lst_out) == MP_FALSE)
    {
        COM_set_field_db_msg(out_node, res_lst_out);
        TRS.free_node(res_lst_in);
        TRS.free_node(res_lst_out);
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    start_lot = TRS.create_node("START_LOT");

    TRS.add_char(start_lot, IN_PROCSTEP, '1');
    TRS.add_enc_nstring(start_lot, IN_USERID, TRS.get_userid(in_node));
    TRS.add_char(start_lot, IN_LANGUAGE, TRS.get_language(in_node));
    TRS.add_nstring(start_lot, IN_FACTORY, TRS.get_factory(in_node));
    TRS.add_string(start_lot, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    TRS.add_int(start_lot, "LAST_ACTIVE_HIST_SEQ", 0);

    if(TRS.get_item_count(res_lst_out, "RES_LIST") > 0)
    {
        res_lst = TRS.get_list(res_lst_out, "RES_LIST");
        for(i = 0; i < TRS.get_item_count(res_lst_out, "RES_LIST"); i++)
        {
            if(TRS.get_char(res_lst[i], "RES_UP_DOWN_FLAG") == 'U')
            {
                break;
            }
        }

        if(i < TRS.get_item_count(res_lst_out, "RES_LIST"))
        {
            TRS.add_nstring(start_lot, "RES_ID", TRS.get_string(res_lst[i], "RES_ID"));
        }
    }
    TRS.free_node(res_lst_in);
    TRS.free_node(res_lst_out);

    if(WIP_START_LOT(s_msg_code, start_lot, out_node) == MP_FALSE)
    {
        TRS.free_node(start_lot);
        return MP_FALSE;
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    end_lot = TRS.create_node("END_LOT");

    TRS.add_char(end_lot, IN_PROCSTEP, '1');
    TRS.add_enc_nstring(end_lot, IN_USERID, TRS.get_userid(in_node));
    TRS.add_char(end_lot, IN_LANGUAGE, TRS.get_language(in_node));
    TRS.add_nstring(end_lot, IN_FACTORY, TRS.get_factory(in_node));
    TRS.add_string(end_lot, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    TRS.add_int(end_lot, "LAST_ACTIVE_HIST_SEQ", 0);

    TRS.add_nstring(end_lot, "RES_ID", TRS.get_string(start_lot, "RES_ID"));
    
    if(WIP_END_LOT(s_msg_code, end_lot, out_node) == MP_FALSE)
    {
        TRS.free_node(end_lot);
        return MP_FALSE;
    }

    TRS.free_node(start_lot);
    TRS.free_node(end_lot);

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    MULTI_TRANSACTION_2()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int MULTI_TRANSACTION_2(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
    LOG_head("MULTI_TRANSACTION_2");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    gb_multi_transaction = MP_TRUE;

    if(SLP_call_service("Start_Lot", 0, "MES_SampleLib", "", "", in_node, out_node) == MP_FALSE)
        return MP_FALSE;
    if(TRS.get_char(out_node, OUT_STATUSVALUE) == MP_FAIL_C)
        return MP_FALSE;

    if(SLP_call_service("End_Lot", 0, "MES_SampleLib", "", "", in_node, out_node) == MP_FALSE)
        return MP_FALSE;
    if(TRS.get_char(out_node, OUT_STATUSVALUE) == MP_FAIL_C)
        return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    Start_Lot_1()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int Start_Lot_1(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = START_LOT_1(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "START_LOT_1", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    START_LOT_1()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int START_LOT_1(char *s_msg_code,
                TRSNode *in_node, 
                TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    TRSNode *start_lot;
    TRSNode *res_lst_in;
    TRSNode *res_lst_out;

    int     i;
    TRSNode **res_lst;


    LOG_head("START_LOT_1");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    res_lst_in = TRS.create_node("RES_LIST_IN");
    res_lst_out = TRS.create_node("RES_LIST_OUT");

    TRS.add_char(res_lst_in, IN_PROCSTEP, '2');
    TRS.add_enc_nstring(res_lst_in, IN_USERID, TRS.get_userid(in_node));
    TRS.add_char(res_lst_in, IN_LANGUAGE, TRS.get_language(in_node));
    TRS.add_nstring(res_lst_in, IN_FACTORY, TRS.get_factory(in_node));
    TRS.add_string(res_lst_in, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    TRS.add_int(res_lst_in, "MAT_VER", MWIPLOTSTS.MAT_VER);
    TRS.add_string(res_lst_in, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
    TRS.add_string(res_lst_in, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

    if(RAS_VIEW_RESOURCE_LIST(s_msg_code, res_lst_in, res_lst_out) == MP_FALSE)
    {
        COM_set_field_db_msg(out_node, res_lst_out);
        TRS.free_node(res_lst_in);
        TRS.free_node(res_lst_out);
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    start_lot = TRS.create_node("START_LOT");

    TRS.add_char(start_lot, IN_PROCSTEP, '1');
    TRS.add_enc_nstring(start_lot, IN_USERID, TRS.get_userid(in_node));
    TRS.add_char(start_lot, IN_LANGUAGE, TRS.get_language(in_node));
    TRS.add_nstring(start_lot, IN_FACTORY, TRS.get_factory(in_node));
    TRS.add_string(start_lot, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    TRS.add_int(start_lot, "LAST_ACTIVE_HIST_SEQ", 0);

    if(TRS.get_item_count(res_lst_out, "RES_LIST") > 0)
    {
        res_lst = TRS.get_list(res_lst_out, "RES_LIST");
        for(i = 0; i < TRS.get_item_count(res_lst_out, "RES_LIST"); i++)
        {
            if(TRS.get_char(res_lst[i], "RES_UP_DOWN_FLAG") == 'U')
            {
                break;
            }
        }

        if(i < TRS.get_item_count(res_lst_out, "RES_LIST"))
        {
            TRS.add_nstring(start_lot, "RES_ID", TRS.get_string(res_lst[i], "RES_ID"));
        }
    }
    TRS.free_node(res_lst_in);
    TRS.free_node(res_lst_out);

    if(WIP_START_LOT(s_msg_code, start_lot, out_node) == MP_FALSE)
    {
        TRS.free_node(start_lot);
        return MP_FALSE;
    }

    TRS.free_node(start_lot);

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    End_Lot_1()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int End_Lot_1(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = END_LOT_1(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "END_LOT_1", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    END_LOT_1()
        - Multi Transaction Sample Code
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int END_LOT_1(char *s_msg_code,
              TRSNode *in_node, 
              TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    TRSNode *end_lot;

    LOG_head("END_LOT_1");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    end_lot = TRS.create_node("END_LOT");

    TRS.add_char(end_lot, IN_PROCSTEP, '1');
    TRS.add_enc_nstring(end_lot, IN_USERID, TRS.get_userid(in_node));
    TRS.add_char(end_lot, IN_LANGUAGE, TRS.get_language(in_node));
    TRS.add_nstring(end_lot, IN_FACTORY, TRS.get_factory(in_node));
    TRS.add_string(end_lot, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    TRS.add_int(end_lot, "LAST_ACTIVE_HIST_SEQ", 0);

    TRS.add_string(end_lot, "RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
    
    if(WIP_END_LOT(s_msg_code, end_lot, out_node) == MP_FALSE)
    {
        TRS.free_node(end_lot);
        return MP_FALSE;
    }

    TRS.free_node(end_lot);

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}
