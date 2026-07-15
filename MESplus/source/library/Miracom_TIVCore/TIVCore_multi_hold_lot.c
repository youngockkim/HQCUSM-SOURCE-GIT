/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_multi_hold_lot.c
    Description : Multi Hold Lot transaction function module

    MES Version : 5.2.0.0

    Function List
        - TIV_Multi_Hold_Lot()
            + Multi Hold Lot
        - TIV_MULTI_HOLD_LOT()
            + Main sub function of "TIV_Multi_Hold_Lot" function
            + Multi Hold Lot definition

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/06/01  DY Oh          Create

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_Multi_Hold_Lot_Validation(char *s_msg_code,
                                       TRSNode *in_node, 
                                       TRSNode *out_node);

/*******************************************************************************
    TIV_Multi_Hold_Lot()
        - Multi Hold Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Multi_Hold_Lot(TRSNode *in_node,
                        TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_MULTI_HOLD_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_MULTI_HOLD_LOT", out_node);

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
    TIV_MULTI_HOLD_LOT()
        - Main sub function of "TIV_Multi_Hold_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_MULTI_HOLD_LOT(char *s_msg_code,
                             TRSNode *in_node,
                             TRSNode *out_node)
{ 
    struct MTIVLOTSTS_TAG MTIVLOTSTS;    
    int i;
    TRSNode *hold_lot_in;

    int i_lot_count;
    TRSNode** lot_list;

    LOG_head("TIV_Multi_Hold_Lot");
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Multi_Hold_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(TIV_Multi_Hold_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}
	

    i_lot_count = TRS.get_item_count(in_node, "LOT_LIST");
    lot_list = TRS.get_list(in_node, "LOT_LIST");

	hold_lot_in = TRS.add_node(in_node, "LOT_LIST");

    for (i = 0; i < i_lot_count; i++)
    {
        #ifdef _ALM
        /* Save Factory, res_id, lot_id , ...for alarm */
        TRS.copy(gs_alm_factory, sizeof(gs_alm_factory), in_node, IN_FACTORY);
        TRS.copy(gs_alm_user_id, sizeof(gs_alm_user_id), in_node, IN_USERID);
        TRS.copy(gs_alm_lot_id, sizeof(gs_alm_lot_id), lot_list[i], "LOT_ID");
        //TRS.copy(gs_alm_res_id, sizeof(gs_alm_res_id), in_node, "RES_ID");
        TRS.copy(gs_alm_source_id, sizeof(gs_alm_source_id), lot_list[i], "LOT_ID");
        memcpy(gs_alm_module, MP_TRAN_CODE_HOLD, strlen(MP_TRAN_CODE_HOLD));
        #endif /* _ALM */

        TRS.set_nstring(hold_lot_in, "LOT_ID", TRS.get_string(lot_list[i], "LOT_ID"));
        TRS.set_nstring(hold_lot_in, "HOLD_CODE", TRS.get_string(lot_list[i], "HOLD_CODE"));
        TRS.set_nstring(hold_lot_in, "HOLD_PASSWORD", TRS.get_string(lot_list[i], "HOLD_PASSWORD"));
        TRS.set_int(hold_lot_in, "LAST_ACTIVE_HIST_SEQ", TRS.get_int(lot_list[i], "LAST_ACTIVE_HIST_SEQ"));
        
		TRS.add_nstring(hold_lot_in, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));

        DBC_init_mtivlotsts(&MTIVLOTSTS);
        TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), lot_list[i], IN_FACTORY);        
        TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
        DBC_select_mtivlotsts(1, &MTIVLOTSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "INV-0044");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }     
            TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);            
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            TRS.free_node(hold_lot_in);
            return MP_FALSE;
        }

        if(TRS.get_int(lot_list[i], "LAST_ACTIVE_HIST_SEQ") > 0)
        {
//            if(TRS.get_int(lot_list[i], "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ)
            {
                strcpy(s_msg_code, "WIP-0113");
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
//                TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_TRANS;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                TRS.free_node(hold_lot_in);
                return MP_TRUE;
            }
        }

        /*TRS.set_string(hold_lot_in, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
        TRS.set_int(hold_lot_in, "MAT_VER", MWIPLOTSTS.MAT_VER);
        TRS.set_string(hold_lot_in, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
        TRS.set_int(hold_lot_in, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
        TRS.set_string(hold_lot_in, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));*/


        if(TIV_HOLD_LOT(s_msg_code, hold_lot_in, out_node) == MP_FALSE)
        {
            TRS.free_node(hold_lot_in);
            return MP_FALSE;
        }

        if(TRS.get_char(in_node, "EACH_COMMIT_FLAG") == 'Y')
        {
            DB_commit();
        }
    }
    TRS.free_node(hold_lot_in);




    if(COM_proc_user_routine("MES_UserTIV", "TIV_Multi_Hold_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Multi_Hold_Lot_Validation()
        - Validation Check sub function of "TIV_Multi_Hold_Lot" function
        - Check the conditions before Create/Update/Delete Material Definition
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Multi_Hold_Lot_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node)
{



    return MP_TRUE;
}