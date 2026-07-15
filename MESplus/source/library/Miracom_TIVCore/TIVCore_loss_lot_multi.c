/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_transfer_lot_multi.c
    Description : Transaction Lot Material Transfer function module

    MES Version : 5.2.0

    Function List
        - TIV_Transfer_Lot()
            + Transaction Raw Material Transfer
        - TIV_TRANSFER_LOT()
            + Main Sub function of "TIV_Transfer_Lot"
            + (called by "TIV_Transfer_Lot")
        - TIV_Transfer_Lot_Validation()
            + Validation Check sub function of "TIV_TRANSFER_LOT" function
            + (called by "TIV_TRANSFER_LOT")
       
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/25  hans         Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"
#include <WIPCore_common.h>
#include "CUS_common.h"

int TIV_Loss_Lot_Multi_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node);


/*******************************************************************************
    TIV_Transfer_Lot()
        - Raw Material Transfer
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TIV_Transfer_Lot_In_Tag *TIV_Transfer_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Loss_Lot_Multi(TRSNode *in_node, 
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_LOSS_LOT_MULTI(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_LOSS_LOT_MULTI", out_node);

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
    TIV_TRANSFER_LOT()
        - Main sub function of "TIV_Transfer_Lot" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_TRANSFER_LOT_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_LOSS_LOT_MULTI(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node)

{
    int i;
	int i_lot_count = 0;

	char s_sys_time[14];

	TRSNode** inv_lot_list;

    LOG_head("TIV_LOSS_LOT_MULTI");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Loss_Lot_Multi",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

	//memset(s_sys_time, ' ', sizeof(s_sys_time));
    /*memset(s_tran_time, ' ', sizeof(s_tran_time));*/

    /*' Validation Check*/
    if(TIV_Loss_Lot_Multi_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

	i_lot_count = TRS.get_item_count(in_node, "TIV_LOT_LIST");
	inv_lot_list = TRS.get_list(in_node, "TIV_LOT_LIST");

	for(i = 0; i < i_lot_count; i++)
	{
		TRS.add_nstring(inv_lot_list[i], IN_PASSPORT, TRS.get_passport(in_node));
		TRS.add_char(inv_lot_list[i], IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_factory(in_node));
		TRS.add_nstring(inv_lot_list[i], IN_USERID, TRS.get_userid(in_node));
		TRS.add_nstring(inv_lot_list[i], IN_PASSWORD, TRS.get_password(in_node));
		TRS.add_char(inv_lot_list[i], IN_PROCSTEP, TRS.get_procstep(in_node));
		//TRS.add_string(inv_lot_list[i], "__SYS_TIME", s_sys_time, sizeof(s_sys_time));
		TRS.add_nstring(inv_lot_list[i], "PRC_USER", TRS.get_string(in_node, "PRC_USER"));

		TRS.set_nstring(inv_lot_list[i], "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
		TRS.set_nstring(inv_lot_list[i], "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
		TRS.set_nstring(inv_lot_list[i], "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
		TRS.set_nstring(inv_lot_list[i], "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
		TRS.set_nstring(inv_lot_list[i], "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
		TRS.set_char(inv_lot_list[i], "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));
		TRS.set_char(inv_lot_list[i], "__GET_TIME_INFO_FLAG", TRS.get_char(in_node, "__GET_TIME_INFO_FLAG"));

		if(TIV_LOSS_LOT(s_msg_code, inv_lot_list[i], out_node) == FALSE)
		{
			return MP_FALSE;
		}
    }

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Loss_Lot_Multi",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_Loss_Lot_Multi_Validation()
        - Validation Check sub function of "TIV_Transfer_Lot" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_Transfer_Lot_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Loss_Lot_Multi_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node)
{
    //char s_inv_lot_id[25];

    
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    
    return MP_TRUE;
}
