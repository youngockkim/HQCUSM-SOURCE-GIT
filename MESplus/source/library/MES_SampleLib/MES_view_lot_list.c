/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : MES_view_lot_list.c
    Description : user function of user defined shared library

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/06/03  Aiden          Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "SLIB_common.h"

/*******************************************************************************
    View_Lot_List_1()
        - View Lot List Inquiry Service Sample
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int View_Lot_List_1(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = VIEW_LOT_LIST_SAMPLE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "VIEW_LOT_LIST_SAMPLE", out_node);

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
    VIEW_LOT_LIST_SAMPLE()
        - View Lot List Inquiry Service Sample
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int VIEW_LOT_LIST_SAMPLE(char *s_msg_code,
                           TRSNode *in_node, 
                           TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    TRSNode *list_item;


    LOG_head("VIEW_LOT_LIST_SAMPLE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    LOG_add("flow", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("next_lot_id", MP_NSTR, TRS.get_string(in_node, "NEXT_LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS);

    TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "NEXT_LOT_ID");
    TRS.copy(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID), in_node, "MAT_ID");
    MWIPLOTSTS.MAT_VER  = TRS.get_int(in_node, "MAT_VER");
    TRS.copy(MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW), in_node, "FLOW");
    TRS.copy(MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER), in_node, "OPER");

    DBC_open_mwiplotsts(2, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
            return MP_TRUE;
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    while(1) 
    {
        DBC_fetch_mwiplotsts(2, &MWIPLOTSTS);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            DBC_close_mwiplotsts(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mwiplotsts(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_string(out_node, "NEXT_LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
            DBC_close_mwiplotsts(2);
            break;
        }

        list_item = TRS.add_node(out_node, "LIST");

        TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
        TRS.add_string(list_item, "LOT_DESC", MWIPLOTSTS.LOT_DESC, sizeof(MWIPLOTSTS.LOT_DESC));
        TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
        TRS.add_int(list_item, "MAT_VER", MWIPLOTSTS.MAT_VER);
        TRS.add_string(list_item, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
        TRS.add_int(list_item, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
        TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
        TRS.add_double(list_item, "QTY_1", MWIPLOTSTS.QTY_1);
        TRS.add_double(list_item, "QTY_2", MWIPLOTSTS.QTY_2);
        TRS.add_double(list_item, "QTY_3", MWIPLOTSTS.QTY_3);
        TRS.add_char(list_item, "LOT_TYPE", MWIPLOTSTS.LOT_TYPE);
        TRS.add_string(list_item, "OWNER_CODE", MWIPLOTSTS.OWNER_CODE, sizeof(MWIPLOTSTS.OWNER_CODE));
        TRS.add_string(list_item, "CREATE_CODE", MWIPLOTSTS.CREATE_CODE, sizeof(MWIPLOTSTS.CREATE_CODE));
        TRS.add_char(list_item, "LOT_PRIORITY", MWIPLOTSTS.LOT_PRIORITY);
        TRS.add_string(list_item, "LOT_STATUS", MWIPLOTSTS.LOT_STATUS, sizeof(MWIPLOTSTS.LOT_STATUS));
        TRS.add_char(list_item, "HOLD_FLAG", MWIPLOTSTS.HOLD_FLAG);
        TRS.add_string(list_item, "HOLD_CODE", MWIPLOTSTS.HOLD_CODE, sizeof(MWIPLOTSTS.HOLD_CODE));
        TRS.add_string(list_item, "HOLD_PRV_GRP_ID", MWIPLOTSTS.HOLD_PRV_GRP_ID, sizeof(MWIPLOTSTS.HOLD_PRV_GRP_ID));
        TRS.add_char(list_item, "INV_FLAG", MWIPLOTSTS.INV_FLAG);
        TRS.add_char(list_item, "TRANSIT_FLAG", MWIPLOTSTS.TRANSIT_FLAG);
        TRS.add_char(list_item, "RWK_FLAG", MWIPLOTSTS.RWK_FLAG);
        TRS.add_string(list_item, "RWK_CODE", MWIPLOTSTS.RWK_CODE, sizeof(MWIPLOTSTS.RWK_CODE));
        TRS.add_char(list_item, "NSTD_FLAG", MWIPLOTSTS.NSTD_FLAG);
        TRS.add_char(list_item, "REP_FLAG", MWIPLOTSTS.REP_FLAG);
        TRS.add_char(list_item, "START_FLAG", MWIPLOTSTS.START_FLAG);
        TRS.add_string(list_item, "START_RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
        TRS.add_char(list_item, "END_FLAG", MWIPLOTSTS.END_FLAG);
        TRS.add_string(list_item, "END_RES_ID", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));
        TRS.add_string(list_item, "SHIP_CODE", MWIPLOTSTS.SHIP_CODE, sizeof(MWIPLOTSTS.SHIP_CODE));
        TRS.add_string(list_item, "SHIP_TIME", MWIPLOTSTS.SHIP_TIME, sizeof(MWIPLOTSTS.SHIP_TIME));
        TRS.add_string(list_item, "SCH_DUE_TIME", MWIPLOTSTS.SCH_DUE_TIME, sizeof(MWIPLOTSTS.SCH_DUE_TIME));
        TRS.add_string(list_item, "ORG_DUE_TIME", MWIPLOTSTS.ORG_DUE_TIME, sizeof(MWIPLOTSTS.ORG_DUE_TIME));
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}
