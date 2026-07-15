/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_multi_hold_lot.c
    Description : Multi Split Lot transaction function module

    MES Version : 5.2.0.0

    Function List
        - TIV_Multi_Split_Lot()
            + Multi Split Lot
        - TIV_MULTI_SPLIT_LOT()
            + Main sub function of "TIV_Multi_Split_Lot" function
            + Multi Split Lot definition

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


int TIV_Multi_Split_Lot_Validation(char *s_msg_code,
                                       TRSNode *in_node, 
                                       TRSNode *out_node);

/*******************************************************************************
    TIV_Multi_Split_Lot()
        - Multi Split Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Multi_Split_Lot(TRSNode *in_node,
                        TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_MULTI_SPLIT_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_MULTI_SPLIT_LOT", out_node);

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
    TIV_MULTI_SPLIT_LOT()
        - Main sub function of "TIV_Multi_Split_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_MULTI_SPLIT_LOT(char *s_msg_code,
                             TRSNode *in_node,
                             TRSNode *out_node)
{ 
    struct MTIVLOTSTS_TAG MTIVLOTSTS;    
    int i;
//    TRSNode *split_lot_in;
	char s_sys_time[14];


    int i_lot_count;
    TRSNode** lot_list;

    LOG_head("TIV_Multi_Split_Lot");
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Multi_Split_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(TIV_Multi_Split_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}

	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));

    i_lot_count = TRS.get_item_count(in_node, "LOT_LIST");
    lot_list = TRS.get_list(in_node, "LOT_LIST");

    for (i = 0; i < i_lot_count; i++)
    {
        #ifdef _ALM
        /* Save Factory, res_id, lot_id , ...for alarm */
        TRS.copy(gs_alm_factory, sizeof(gs_alm_factory), in_node, IN_FACTORY);
        TRS.copy(gs_alm_user_id, sizeof(gs_alm_user_id), in_node, IN_USERID);
        TRS.copy(gs_alm_lot_id, sizeof(gs_alm_lot_id), in_node, "TIV_LOT_ID");
        //TRS.copy(gs_alm_res_id, sizeof(gs_alm_res_id), in_node, "RES_ID");
        TRS.copy(gs_alm_source_id, sizeof(gs_alm_source_id), lot_list[i], "CHILD_LOT_ID");
        memcpy(gs_alm_module, MP_TRAN_CODE_SPLIT, strlen(MP_TRAN_CODE_SPLIT));
        #endif /* _ALM */

		DBC_init_mtivlotsts(&MTIVLOTSTS);
        TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);        
        TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), lot_list[i], "TIV_LOT_ID");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), lot_list[i], "FROM_OPER");
        DBC_select_mtivlotsts(4, &MTIVLOTSTS);
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
            TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            //TRS.free_node(split_lot_in);
            return MP_FALSE;
        }

		TRS.set_char(lot_list[i], IN_PROCSTEP, TRS.get_char(in_node, IN_PROCSTEP));
		TRS.set_nstring(lot_list[i], IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
		TRS.set_nstring(lot_list[i], IN_USERID, TRS.get_string(in_node, IN_USERID));
		TRS.add_nstring(lot_list[i], "PRC_USER", TRS.get_string(in_node, "PRC_USER"));

		TRS.set_nstring(lot_list[i], "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
		TRS.set_nstring(lot_list[i], "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
		TRS.set_nstring(lot_list[i], "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
		TRS.set_nstring(lot_list[i], "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
		TRS.set_nstring(lot_list[i], "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
		TRS.set_char(lot_list[i], "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));
		TRS.set_char(lot_list[i], "__GET_TIME_INFO_FLAG", TRS.get_char(in_node, "__GET_TIME_INFO_FLAG"));

        TRS.set_nstring(lot_list[i], "INV_LOT_ID", TRS.get_string(lot_list[i], "TIV_LOT_ID"));
		TRS.set_string(lot_list[i], "MAT_ID",MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
		TRS.set_int(lot_list[i], "MAT_VER", MTIVLOTSTS.MAT_VER);

        if(TRS.get_int(lot_list[i], "LAST_ACTIVE_HIST_SEQ") > 0)
        {
//            if(TRS.get_int(lot_list[i], "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ)
            {
                strcpy(s_msg_code, "WIP-0113");
                TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
//                TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_TRANS;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                //TRS.free_node(split_lot_in);
                return MP_TRUE;
            }
        }

        /*TRS.set_string(split_lot_in, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
        TRS.set_int(split_lot_in, "MAT_VER", MWIPLOTSTS.MAT_VER);
        TRS.set_string(split_lot_in, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
        TRS.set_int(split_lot_in, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
        TRS.set_string(split_lot_in, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));*/


        if(TIV_SPLIT_LOT(s_msg_code, lot_list[i], out_node) == MP_FALSE)
        {
            //TRS.free_node(split_lot_in);
            return MP_FALSE;
        }

        if(TRS.get_char(in_node, "EACH_COMMIT_FLAG") == 'Y')
        {
            DB_commit();
        }
    }
    //TRS.free_node(split_lot_in);




    if(COM_proc_user_routine("MES_UserTIV", "TIV_Multi_Split_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Multi_Split_Lot_Validation()
        - Validation Check sub function of "TIV_Multi_Split_Lot" function
        - Check the conditions before Create/Update/Delete Material Definition
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Multi_Split_Lot_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node)
{



    return MP_TRUE;
}