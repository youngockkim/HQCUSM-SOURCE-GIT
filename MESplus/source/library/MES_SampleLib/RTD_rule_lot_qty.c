/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : RTD_rule_lot_qty.c
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

int RTD_Rule_Lot_Qty_1(TRSNode *in_node, TRSNode *out_node)
{
    char c_predispatch_flag;
    char s_msg[MP_SIZE_FIELD_MSG];
    char s_msg_code[MP_SIZE_MSG];

    struct MWIPLOTSTS_TAG MWIPLOTSTS;

    LOG_head("RTD_Rule_Lot_Qty_1");
    LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("RES_ID", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("KEY_VALUE_1", MP_NSTR, TRS.get_string(in_node, "KEY_VALUE_1"));
    LOG_add("KEY_VALUE_2", MP_NSTR, TRS.get_string(in_node, "KEY_VALUE_2"));
    LOG_add("PREDISPATCH_FLAG", MP_CHR, TRS.get_char(in_node, "PREDISPATCH_FLAG"));
    LOG_add("MAT_ID", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("MAT_VER", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    LOG_add("FLOW", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    LOG_add("OPER", MP_NSTR, TRS.get_string(in_node, "OPER"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    //Default Result
    TRS.add_int(out_node, "NUM_VALUE", 0);

    c_predispatch_flag = TRS.get_char(in_node, "PREDISPATCH_FLAG");

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");

    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "WIP-0044");
            COM_get_message('1', s_msg_code, s_msg);
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            COM_get_message('1', s_msg_code, s_msg);
        }

        LOG_head("RTD_Rule_Lot_Qty_1");
        LOG_add("table", MP_NSTR, "MWIPLOTSTS SELECT");
        LOG_add("LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        LOG_add("error_msg", MP_STR, MP_SIZE_FIELD_MSG, s_msg );
        LOG_add("db_error_msg", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg );
        COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

        return MP_FALSE;
    }

    //maxvalue 10000
    TRS.set_int(out_node, "NUM_VALUE", (int)MWIPLOTSTS.QTY_1);

    return MP_TRUE;
}

