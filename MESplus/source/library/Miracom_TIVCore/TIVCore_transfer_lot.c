/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_Transfer_Lot.c
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


int TIV_Transfer_Lot_Validation(char *s_msg_code,
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
int TIV_Transfer_Lot(TRSNode *in_node, 
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_TRANSFER_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_TRANSFER_LOT", out_node);

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

int TIV_TRANSFER_LOT(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node)

{
    //struct MTIVMATDEF_TAG MTIVMATDEF;
	//struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_TO;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_FROM;
    //struct MTIVLOTSTS_TAG MTIVLOTSTS_COMPARE;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    //struct MATRNAMSTS_TAG MATRNAMSTS_OLD;
	//struct MATRNAMSTS_TAG MATRNAMSTS;

	struct  MTIVTRSLOT_TAG  MTIVTRSLOT;
	struct  MTIVTRSMST_TAG  MTIVTRSMST;
	struct	MTIVTRSDTL_TAG  MTIVTRSDTL;
	struct  MTIVMLSTRS_TAG  MTIVMLSTRS;
	struct  MTMPLOTLSM_TAG  MTMPLOTLSM;
	
	//char s_oper_temp[10];

	//struct CPLNMIMDEF_TAG CPLNMIMDEF;
	
	char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];

    char s_inv_lot_id[25];
    int b_lot_dup = 0;
	int i_step;
	//int iMaxProjectVer;

	int i_last_active_hist_seq;
  
	TRSNode * IF_node;

	TRSNode * Loss_Lot_In;
	TRSNode * list_item;

	TRSNode * CV_Lot_In;
	TRSNode * cv_item;

    LOG_head("TIV_TRANSFER_LOT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("to_factory", MP_NSTR, TRS.get_string(in_node, "TO_FACTORY"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));    
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("location_no", MP_NSTR, TRS.get_string(in_node, "LOCATION_NO"));
    LOG_add("to_oper", MP_NSTR, TRS.get_string(in_node, "TO_OPER"));
	LOG_add("to_location_no", MP_NSTR, TRS.get_string(in_node, "TO_LOCATION_NO"));
	LOG_add("qty_1", MP_DBL, TRS.get_double(in_node, "QTY_1"));
    LOG_add("qty_2", MP_DBL, TRS.get_double(in_node, "QTY_2"));
    LOG_add("qty_3", MP_DBL, TRS.get_double(in_node, "QTY_3"));
    LOG_add("move_qty_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
    LOG_add("move_qty_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
    LOG_add("move_qty_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));
    //LOG_add("tran_code", MP_NSTR, TRS.get_string(in_node, "TRAN_CODE"));
    LOG_add("tran_type", MP_NSTR, TRS.get_string(in_node, "TRAN_TYPE"));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));    
    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
    LOG_add("inv_cmf_1", MP_NSTR, TRS.get_string(in_node, "INV_CMF_1"));
    LOG_add("inv_cmf_2", MP_NSTR, TRS.get_string(in_node, "INV_CMF_2"));
    LOG_add("inv_cmf_3", MP_NSTR, TRS.get_string(in_node, "INV_CMF_3"));
    LOG_add("inv_cmf_4", MP_NSTR, TRS.get_string(in_node, "INV_CMF_4"));
    LOG_add("inv_cmf_5", MP_NSTR, TRS.get_string(in_node, "INV_CMF_5"));
    LOG_add("inv_cmf_6", MP_NSTR, TRS.get_string(in_node, "INV_CMF_6"));
    LOG_add("inv_cmf_7", MP_NSTR, TRS.get_string(in_node, "INV_CMF_7"));
    LOG_add("inv_cmf_8", MP_NSTR, TRS.get_string(in_node, "INV_CMF_8"));
    LOG_add("inv_cmf_9", MP_NSTR, TRS.get_string(in_node, "INV_CMF_9"));
    LOG_add("inv_cmf_10", MP_NSTR, TRS.get_string(in_node, "INV_CMF_10"));
    LOG_add("inv_cmf_11", MP_NSTR, TRS.get_string(in_node, "INV_CMF_11"));
    LOG_add("inv_cmf_12", MP_NSTR, TRS.get_string(in_node, "INV_CMF_12"));
    LOG_add("inv_cmf_13", MP_NSTR, TRS.get_string(in_node, "INV_CMF_13"));
    LOG_add("inv_cmf_14", MP_NSTR, TRS.get_string(in_node, "INV_CMF_14"));
    LOG_add("inv_cmf_15", MP_NSTR, TRS.get_string(in_node, "INV_CMF_15"));
    LOG_add("inv_cmf_16", MP_NSTR, TRS.get_string(in_node, "INV_CMF_16"));
    LOG_add("inv_cmf_17", MP_NSTR, TRS.get_string(in_node, "INV_CMF_17"));
    LOG_add("inv_cmf_18", MP_NSTR, TRS.get_string(in_node, "INV_CMF_18"));
    LOG_add("inv_cmf_19", MP_NSTR, TRS.get_string(in_node, "INV_CMF_19"));
    LOG_add("inv_cmf_20", MP_NSTR, TRS.get_string(in_node, "INV_CMF_20"));

	LOG_add("SKIP_IF_INFO_FLAG", MP_CHR, TRS.get_char(in_node, "SKIP_IF_INFO_FLAG"));
	LOG_add("SKIP_MOVE_INFO", MP_CHR, TRS.get_char(in_node, "SKIP_MOVE_INFO"));

	LOG_add("attr_type", MP_NSTR, TRS.get_string(in_node, "ATTR_TYPE"));
	LOG_add("attr_name", MP_NSTR, TRS.get_string(in_node, "ATTR_NAME"));
	LOG_add("attr_key", MP_NSTR, TRS.get_string(in_node, "ATTR_KEY"));
	LOG_add("expire_date", MP_NSTR, TRS.get_string(in_node,"EXPIRE_DATE"));

    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
	 
    memset(s_inv_lot_id,' ', sizeof(s_inv_lot_id));
	memset(s_erp_tran_time, ' ', sizeof(s_erp_tran_time));
	memset(s_tran_time, ' ', sizeof(s_tran_time));
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
 
	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}
	

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");
	
    TRS.set_nstring(in_node, "__FACTORY", TRS.get_string(in_node, IN_FACTORY));
    TRS.set_nstring(in_node, "__OPER", TRS.get_string(in_node, "OPER"));
    if(TIV_Lot_Fill_InTag_Cmf(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    
    /*' Validation Check*/ //Attribute값도 같이 가지고옴 
    if(TIV_Transfer_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.copy(s_inv_lot_id, sizeof(s_inv_lot_id), in_node, "LOT_ID");

    //From Status & History
    DBC_init_mtivlotsts(&MTIVLOTSTS_FROM);
    TRS.copy(MTIVLOTSTS_FROM.FACTORY, sizeof(MTIVLOTSTS_FROM.FACTORY), in_node, IN_FACTORY);    
    TRS.copy(MTIVLOTSTS_FROM.LOT_ID, sizeof(MTIVLOTSTS_FROM.LOT_ID), in_node, "LOT_ID");
	TRS.copy(MTIVLOTSTS_FROM.OPER, sizeof(MTIVLOTSTS_FROM.OPER), in_node, "OPER");
    DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_FROM);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0022");             
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");            
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_FROM.FACTORY), MTIVLOTSTS_FROM.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_FROM.OPER), MTIVLOTSTS_FROM.OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_FROM.LOT_ID), MTIVLOTSTS_FROM.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (fabs(MTIVLOTSTS_FROM.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1")) > 0.0005)
	{
		if (MTIVLOTSTS_FROM.QTY_1 > TRS.get_double(in_node, "MOVE_QTY_1"))
		{
			// 기타출고 Case
			Loss_Lot_In = TRS.create_node("LOSS_INV_LOT_ID");	
			TRS.add_char(Loss_Lot_In, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(Loss_Lot_In, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(Loss_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(Loss_Lot_In, IN_FACTORY, TRS.get_factory(in_node));
			TRS.add_nstring(Loss_Lot_In, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));
			if (COM_isnullspace(TRS.get_string(in_node, "ERP_BACK_TIME")) == MP_FALSE)
			{
				TRS.add_nstring(Loss_Lot_In, "ERP_BACK_TIME", TRS.get_string(in_node, "ERP_BACK_TIME"));
			}
			TRS.add_nstring(Loss_Lot_In, "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
			TRS.add_nstring(Loss_Lot_In, "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
			TRS.add_nstring(Loss_Lot_In, "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
			TRS.add_nstring(Loss_Lot_In, "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
			TRS.add_nstring(Loss_Lot_In, "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
			TRS.add_char(Loss_Lot_In, "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));
			TRS.add_char(Loss_Lot_In, "__GET_TIME_INFO_FLAG", 'Y');

			TRS.set_string(Loss_Lot_In, "TRAN_TYPE", MP_TIV_TRAN_TYPE_MV_LOSS, strlen(MP_TIV_TRAN_TYPE_MV_LOSS));
			TRS.set_string(Loss_Lot_In, "INV_LOT_ID", MTIVLOTSTS_FROM.LOT_ID, sizeof(MTIVLOTSTS_FROM.LOT_ID));
			TRS.set_string(Loss_Lot_In, "TIV_LOT_ID", MTIVLOTSTS_FROM.LOT_ID, sizeof(MTIVLOTSTS_FROM.LOT_ID));
			TRS.set_int(Loss_Lot_In, "LAST_HIST_SEQ", MTIVLOTSTS_FROM.LAST_ACTIVE_HIST_SEQ);

			TRS.set_string(Loss_Lot_In, "MAT_ID", MTIVLOTSTS_FROM.MAT_ID, sizeof(MTIVLOTSTS_FROM.MAT_ID));
			TRS.set_string(Loss_Lot_In, "TIV_MAT_ID", MTIVLOTSTS_FROM.MAT_ID, sizeof(MTIVLOTSTS_FROM.MAT_ID));
			 
			TRS.set_int(Loss_Lot_In, "MAT_VER", MTIVLOTSTS_FROM.MAT_VER);
			TRS.set_int(Loss_Lot_In, "TIV_MAT_VER", MTIVLOTSTS_FROM.MAT_VER);
		
			TRS.set_nstring(Loss_Lot_In, "OPER", TRS.get_string(in_node, "OPER"));
			TRS.set_nstring(Loss_Lot_In, "TIV_OPER", TRS.get_string(in_node, "OPER"));
			TRS.set_nstring(Loss_Lot_In, "LOSS_COMMENT", TRS.get_string(in_node, "COMMENT"));
			TRS.set_nstring(Loss_Lot_In, "TRAN_COMMENT", TRS.get_string(in_node, "COMMENT"));

			TRS.set_string(Loss_Lot_In, "MVT_CODE", MP_ERP_MVT_551, strlen(MP_ERP_MVT_551));
			TRS.add_char(Loss_Lot_In, "MVT_IN_OUT_FLAG", MP_MVT_IN_OUT_FLAG_OUT);

			TRS.set_double(Loss_Lot_In, "OUT_QTY_1", TRS.get_double(in_node, "MOVE_QTY_1"));
		
			// MTIVLOTSTS_FROM.QTY_1 - TRS.get_double(in_node, "SCRAP_QTY")
			list_item = TRS.add_node(Loss_Lot_In, "UNIT1");
			TRS.set_string(list_item, "CODE", MP_TIV_LOSS_CODE_MV_LOSS, strlen(MP_TIV_LOSS_CODE_MV_LOSS));
			TRS.set_double(list_item, "QTY", MTIVLOTSTS_FROM.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1"));
			TRS.set_char(list_item,	"NO_SCRAP_FLAG", ' ');	
			  
			if(TIV_LOSS_LOT(s_msg_code, Loss_Lot_In, out_node) == MP_FALSE)
			{			
				TRS.free_node(Loss_Lot_In);
				return MP_FALSE;
			}
			TRS.free_node(Loss_Lot_In);
			 
		}
		else if (MTIVLOTSTS_FROM.QTY_1 < TRS.get_double(in_node, "MOVE_QTY_1"))
		{
			// 수량보정 Case

			CV_Lot_In = TRS.create_node("CV_LOT_IN");

			TRS.add_char(CV_Lot_In, IN_PROCSTEP, '1');
				
			TRS.add_nstring(CV_Lot_In, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
			TRS.add_char(CV_Lot_In, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
			TRS.add_nstring(CV_Lot_In, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
			TRS.add_nstring(CV_Lot_In, IN_USERID, TRS.get_string(in_node, IN_USERID));
			TRS.add_nstring(CV_Lot_In, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
			TRS.add_nstring(CV_Lot_In, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));

			if (COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_FALSE)
			{
				TRS.add_nstring(CV_Lot_In, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
			}
			TRS.add_nstring(CV_Lot_In, "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
			TRS.add_nstring(CV_Lot_In, "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
			TRS.add_nstring(CV_Lot_In, "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
			TRS.add_nstring(CV_Lot_In, "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
			TRS.add_nstring(CV_Lot_In, "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
			TRS.add_char(CV_Lot_In, "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));
			TRS.add_char(CV_Lot_In, "__GET_TIME_INFO_FLAG", 'Y');
			TRS.set_string(CV_Lot_In, "MVT_CODE", MP_ERP_MVT_552, strlen(MP_ERP_MVT_552));
			TRS.add_char(CV_Lot_In, "MVT_IN_OUT_FLAG", MP_MVT_IN_OUT_FLAG_IN);
			
			TRS.set_char(CV_Lot_In, "REBIRTH_LOT", 'Y');

			list_item = TRS.add_node(CV_Lot_In, "TIV_LOT_LIST");
			TRS.set_string(list_item, "TRAN_TYPE", MP_INV_TRAN_TYPE_MAT_IN, strlen(MP_INV_TRAN_TYPE_MAT_IN)); 
			TRS.set_string(list_item, "TIV_LOT_ID", MTIVLOTSTS_FROM.LOT_ID, sizeof(MTIVLOTSTS_FROM.LOT_ID));
			TRS.set_string(list_item, "LOT_ID", MTIVLOTSTS_FROM.LOT_ID, sizeof(MTIVLOTSTS_FROM.LOT_ID));								
			TRS.set_string(list_item, "TIV_OPER", MTIVLOTSTS_FROM.OPER, sizeof(MTIVLOTSTS_FROM.OPER));
			TRS.set_string(list_item, "OPER", MTIVLOTSTS_FROM.OPER, sizeof(MTIVLOTSTS_FROM.OPER));
			TRS.set_string(list_item, "TIV_MAT_ID", MTIVLOTSTS_FROM.MAT_ID, sizeof(MTIVLOTSTS_FROM.MAT_ID));
			TRS.set_int(list_item, "TIV_MAT_VER", MTIVLOTSTS_FROM.MAT_VER);
			TRS.set_double(list_item, "OUT_QTY", TRS.get_double(in_node, "MOVE_QTY_1"));

			cv_item = TRS.add_node(list_item, "UNIT1");
			TRS.set_string(cv_item, "CODE", MP_TIV_CV_CODE_MV_ADJ, strlen(MP_TIV_CV_CODE_MV_ADJ));
			TRS.set_double(cv_item, "QTY", TRS.get_double(in_node, "MOVE_QTY_1") - MTIVLOTSTS_FROM.QTY_1);
		  
			if(TIV_CV_LOT(s_msg_code, CV_Lot_In, out_node) == MP_FALSE)
			{
				TRS.free_node(CV_Lot_In);
				return MP_FALSE;
			}
			TRS.free_node(CV_Lot_In);

		}

		DBC_init_mtivlotsts(&MTIVLOTSTS_FROM);
		TRS.copy(MTIVLOTSTS_FROM.FACTORY, sizeof(MTIVLOTSTS_FROM.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS_FROM.LOT_ID, sizeof(MTIVLOTSTS_FROM.LOT_ID), in_node, "LOT_ID");
		TRS.copy(MTIVLOTSTS_FROM.OPER, sizeof(MTIVLOTSTS_FROM.OPER), in_node, "OPER");
		DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_FROM);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0022");             
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");            
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_FROM.FACTORY), MTIVLOTSTS_FROM.FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_FROM.OPER), MTIVLOTSTS_FROM.OPER);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_FROM.LOT_ID), MTIVLOTSTS_FROM.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}


    //To Status & History
    DBC_init_mtivlotsts(&MTIVLOTSTS_TO);
    TRS.copy(MTIVLOTSTS_TO.FACTORY, sizeof(MTIVLOTSTS_TO.FACTORY), in_node, IN_FACTORY);    
    TRS.copy(MTIVLOTSTS_TO.LOT_ID, sizeof(MTIVLOTSTS_TO.LOT_ID), in_node, "LOT_ID");
	TRS.copy(MTIVLOTSTS_TO.OPER, sizeof(MTIVLOTSTS_TO.OPER), in_node, "TO_OPER");
    DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_TO);
    if(DB_error_code == DB_SUCCESS)
    {
        b_lot_dup = MP_TRUE;
    }
    else if(DB_error_code == DB_SUCCESS)
    {
        
    }
    else if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
    {
        strcpy(s_msg_code, "INV-0004");
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_TO.FACTORY), MTIVLOTSTS_TO.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_TO.OPER), MTIVLOTSTS_TO.OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_TO.LOT_ID), MTIVLOTSTS_TO.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
 
	DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
	memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS_FROM, sizeof(MTIVLOTSTS_FROM));

	if (COM_isnullspace(TRS.get_string(in_node, "OWNER_CODE")) == MP_FALSE)
	{
		TRS.copy(MTIVLOTSTS_FROM.OWNER_CODE, sizeof(MTIVLOTSTS_FROM.OWNER_CODE), in_node, "OWNER_CODE");    
	}

	//MTIVLOTSTS_FROM.QTY_1 = MTIVLOTSTS_FROM.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1");
 //   MTIVLOTSTS_FROM.QTY_2 = MTIVLOTSTS_FROM.QTY_2 - TRS.get_double(in_node, "MOVE_QTY_2");
 //   MTIVLOTSTS_FROM.QTY_3 = MTIVLOTSTS_FROM.QTY_3 - TRS.get_double(in_node, "MOVE_QTY_3");
	//memcpy(MTIVLOTSTS_FROM.LAST_TRAN_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));
 //   TRS.copy(MTIVLOTSTS_FROM.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_FROM.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
	//memcpy(MTIVLOTSTS_FROM.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LAST_TRAN_TIME));
 //   TRS.copy(MTIVLOTSTS_FROM.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");  
	// 
	//memcpy(MTIVLOTSTS_FROM.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	i_step = 10;
	i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS_FROM);

	/*MTIVLOTSTS_FROM.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
	MTIVLOTSTS_FROM.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_FROM.LAST_HIST_SEQ;
	MTIVLOTSTS_FROM.IN_OUT_FLAG = 'O';*/

	// 수정 - 이전 공정의 Lot수량이 0이면 STATUS 정보 삭제 하는 로직으로 변경 (20160109 By Derek)
	// 기존 로직 - 주석부분
	/*if(MTIVLOTSTS_FROM.QTY_1 < 0.0005 && MTIVLOTSTS_FROM.QTY_2 < 0.0005)
	{
		if(TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT") != 'Y')
		{
			MTIVLOTSTS_FROM.LOT_DEL_FLAG = 'Y';
			TRS.copy(MTIVLOTSTS_FROM.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS_FROM.LOT_DEL_USER_ID), in_node, IN_USERID);
			memcpy(MTIVLOTSTS_FROM.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS_FROM.LOT_DEL_TIME));
			memcpy(MTIVLOTSTS_FROM.LOT_DEL_REASON, MP_WIP_AUTO_TERMINATE_CODE, strlen(MP_WIP_AUTO_TERMINATE_CODE));
		}
	}  
	 
	TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U'); 

	DBC_init_mtivlothis(&MTIVLOTHIS);

	if(TIV_update_insert_lot_status_history_transfer(s_msg_code, 
                                            in_node,
                                            out_node,
                                            s_sys_time,
											&MTIVLOTSTS_OLD,
                                            &MTIVLOTSTS_FROM,
                                            &MTIVLOTHIS) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }*/
	
	DBC_delete_mtivlotsts(4, &MTIVLOTSTS_FROM);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "INV-0004");
		TRS.add_fieldmsg(out_node, "MTIVLOTSTS_FROM UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_FROM.FACTORY), MTIVLOTSTS_FROM.FACTORY);
		TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_FROM.OPER), MTIVLOTSTS_FROM.OPER);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_FROM.LOT_ID), MTIVLOTSTS_FROM.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_COMMON;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	 
	/*TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U'); 

	DBC_init_mtivlothis(&MTIVLOTHIS);*/

	/*if(TIV_update_insert_lot_status_history_transfer(s_msg_code, 
                                            in_node,
                                            out_node,
                                            s_sys_time,
											&MTIVLOTSTS_OLD,
                                            &MTIVLOTSTS_FROM,
                                            &MTIVLOTHIS) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }*/
	

	// END 수정-----------------------------

	//i_step = 10;
	//i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS_TO);

    if(b_lot_dup==MP_TRUE)//Target Lot이 존재할때
    {
		DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
		memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS_TO, sizeof(MTIVLOTSTS_TO));

		TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "FROM_OPER");

		memset(MTIVLOTSTS_OLD.INV_CMF_8, ' ' , sizeof(MTIVLOTSTS_OLD.INV_CMF_8));
		memset(MTIVLOTSTS_OLD.INV_CMF_9, ' ' , sizeof(MTIVLOTSTS_OLD.INV_CMF_9));
		memset(MTIVLOTSTS_TO.INV_CMF_8, ' ' , sizeof(MTIVLOTSTS_TO.INV_CMF_8));
		memset(MTIVLOTSTS_TO.INV_CMF_9, ' ' , sizeof(MTIVLOTSTS_TO.INV_CMF_9));

        MTIVLOTSTS_TO.QTY_1 = MTIVLOTSTS_TO.QTY_1 + TRS.get_double(in_node, "MOVE_QTY_1");
        MTIVLOTSTS_TO.QTY_2 = MTIVLOTSTS_TO.QTY_2 + TRS.get_double(in_node, "MOVE_QTY_2");
        MTIVLOTSTS_TO.QTY_3 = MTIVLOTSTS_TO.QTY_3 + TRS.get_double(in_node, "MOVE_QTY_3");
 
		MTIVLOTSTS_TO.LOT_DEL_FLAG = ' ';
        memset(MTIVLOTSTS_TO.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_USER_ID));
        memset(MTIVLOTSTS_TO.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_TIME));
        memset(MTIVLOTSTS_TO.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_REASON));

		memcpy(MTIVLOTSTS_TO.LAST_TRAN_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
		memcpy(MTIVLOTSTS_TO.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LAST_TRAN_TIME));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");
		memcpy(MTIVLOTSTS_TO.OINV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.OINV_IN_TIME));

		TRS.copy(MTIVLOTSTS_TO.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS_TO.ERP_OINV_IN_DATE), in_node, "WORK_DATE");
		memcpy(MTIVLOTSTS_TO.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

		TRS.copy(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS_TO.LAST_TRAN_USER_ID), in_node, "PRC_USER");
	
		MTIVLOTSTS_TO.IN_OUT_FLAG = 'I';
		MTIVLOTSTS_TO.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
        //MTIVLOTSTS.LAST_HIST_SEQ ++;
        MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_TO.LAST_HIST_SEQ;

		if (COM_isnullspace(TRS.get_string(in_node, "TO_RACK"))== MP_FALSE)
		{
			TRS.copy(MTIVLOTSTS_TO.INV_CMF_7,  sizeof(MTIVLOTSTS_TO.INV_CMF_7), in_node, "TO_RACK");
		}
		else
		{
			memset(MTIVLOTSTS_TO.INV_CMF_7, ' ', sizeof(MTIVLOTSTS_TO.INV_CMF_7));
		}

		if (TRS.get_char(in_node, "IN_STOCK_FLAG") == 'Y')
		{
			//memcpy(MTIVLOTSTS.INV_CMF_1, s_tran_time, sizeof(s_tran_time));
			memcpy(MTIVLOTSTS_TO.INV_IN_TIME, s_erp_tran_time, sizeof(MTIVLOTSTS_TO.INV_IN_TIME));
		}

		if (TRS.get_char(in_node, "PLANT_PO_FLAG") == 'Y')
		{			
			memset(MTIVLOTSTS_TO.ADD_ORDER_ID_1, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_ID_1));
			memset(MTIVLOTSTS_TO.ADD_ORDER_ID_2, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_ID_2));
			memset(MTIVLOTSTS_TO.ADD_ORDER_ID_3, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_ID_3));

			memset(MTIVLOTSTS_TO.ADD_ORDER_LINE_1, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_LINE_1));
			memset(MTIVLOTSTS_TO.ADD_ORDER_LINE_2, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_LINE_2));
			memset(MTIVLOTSTS_TO.ADD_ORDER_LINE_3, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_LINE_3));
		}
		 
    }
    else//Target Lot이 존재하지 않을때 - B의 수량은 이동수량만
    {
		memset(MTIVLOTSTS_OLD.INV_CMF_8, ' ' , sizeof(MTIVLOTSTS_OLD.INV_CMF_8));
		memset(MTIVLOTSTS_OLD.INV_CMF_9, ' ' , sizeof(MTIVLOTSTS_OLD.INV_CMF_9));
		memset(MTIVLOTSTS_TO.INV_CMF_8, ' ' , sizeof(MTIVLOTSTS_TO.INV_CMF_8));
		memset(MTIVLOTSTS_TO.INV_CMF_9, ' ' , sizeof(MTIVLOTSTS_TO.INV_CMF_9));


		MTIVLOTSTS_OLD.QTY_1 = MTIVLOTSTS_FROM.QTY_1;
		MTIVLOTSTS_OLD.QTY_2 = MTIVLOTSTS_FROM.QTY_2;
		MTIVLOTSTS_OLD.QTY_3 = MTIVLOTSTS_FROM.QTY_3;
		memset(MTIVLOTSTS_OLD.LOCATION_NO, ' ', sizeof(MTIVLOTSTS_OLD.LOCATION_NO));

        memcpy(&MTIVLOTSTS_TO, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS_TO));
		
		TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "FROM_OPER");

	    TRS.copy(MTIVLOTSTS_TO.OPER,  sizeof(MTIVLOTSTS_TO.OPER), in_node, "TO_OPER");
	    TRS.copy(MTIVLOTSTS_TO.LOCATION_NO,  sizeof(MTIVLOTSTS_TO.LOCATION_NO), in_node, "TO_LOCATION_NO");

		MTIVLOTSTS_TO.QTY_1 = TRS.get_double(in_node, "MOVE_QTY_1");
        MTIVLOTSTS_TO.QTY_2 = TRS.get_double(in_node, "MOVE_QTY_2");
        MTIVLOTSTS_TO.QTY_3 = TRS.get_double(in_node, "MOVE_QTY_3");

		memset(MTIVLOTSTS_TO.INV_CMF_7, ' ', sizeof(MTIVLOTSTS_TO.INV_CMF_7));

        memcpy(MTIVLOTSTS_TO.LAST_TRAN_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
        memcpy(MTIVLOTSTS_TO.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LAST_TRAN_TIME));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");
		memcpy(MTIVLOTSTS_TO.OINV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.OINV_IN_TIME));

		TRS.copy(MTIVLOTSTS_TO.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS_TO.ERP_OINV_IN_DATE), in_node, "WORK_DATE");

		TRS.copy(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS_TO.LAST_TRAN_USER_ID), in_node, "PRC_USER");

		memcpy(MTIVLOTSTS_TO.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

        memset(MTIVLOTSTS_TO.FROM_TO_LOT_ID, ' ', sizeof(MTIVLOTSTS_TO.FROM_TO_LOT_ID));
		MTIVLOTSTS_TO.FROM_TO_HIST_SEQ = 0;
        MTIVLOTSTS_TO.FROM_TO_FLAG = ' ';
        MTIVLOTSTS_TO.LOT_DEL_FLAG = ' ';
        memset(MTIVLOTSTS_TO.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_USER_ID));
        memset(MTIVLOTSTS_TO.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_TIME));
        memset(MTIVLOTSTS_TO.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_REASON));

        MTIVLOTSTS_TO.IN_OUT_FLAG = 'I';
        if(COM_isnullspace(TRS.get_string(in_node, "ORDER_ID")) == MP_FALSE)
        {
            TRS.copy(MTIVLOTSTS_TO.ORDER_ID, sizeof(MTIVLOTSTS_TO.ORDER_ID), in_node, "ORDER_ID");
        }

		MTIVLOTSTS_TO.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
        //MTIVLOTSTS.LAST_HIST_SEQ ++;
        MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_TO.LAST_HIST_SEQ;
        //TRS.copy(MTIVLOTSTS_TO.INV_CMF_1, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_1");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_2, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_2");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_3, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_3");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_4, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_4");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_5, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_5");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_6, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_6");
        //TRS.copy(MTIVLOTSTS_TO.INV_CMF_7, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_7");
        //TRS.copy(MTIVLOTSTS_TO.INV_CMF_8, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_8");
        //TRS.copy(MTIVLOTSTS_TO.INV_CMF_9, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_9");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_10, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_10");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_11, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_11");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_12, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_12");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_13, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_13");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_14, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_14");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_15, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_15");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_16, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_16");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_17, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_17");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_18, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_18");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_19, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_19");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_20, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_20");

		TRS.copy(MTIVLOTSTS_TO.INV_CMF_21, sizeof(MTIVLOTSTS_TO.INV_CMF_21), in_node, "INV_CMF_21");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_22, sizeof(MTIVLOTSTS_TO.INV_CMF_22), in_node, "INV_CMF_22");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_23, sizeof(MTIVLOTSTS_TO.INV_CMF_23), in_node, "INV_CMF_23");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_24, sizeof(MTIVLOTSTS_TO.INV_CMF_24), in_node, "INV_CMF_24");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_25, sizeof(MTIVLOTSTS_TO.INV_CMF_25), in_node, "INV_CMF_25");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_26, sizeof(MTIVLOTSTS_TO.INV_CMF_26), in_node, "INV_CMF_26");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_27, sizeof(MTIVLOTSTS_TO.INV_CMF_27), in_node, "INV_CMF_27");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_28, sizeof(MTIVLOTSTS_TO.INV_CMF_28), in_node, "INV_CMF_28");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_29, sizeof(MTIVLOTSTS_TO.INV_CMF_29), in_node, "INV_CMF_29");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_30, sizeof(MTIVLOTSTS_TO.INV_CMF_30), in_node, "INV_CMF_30");

	    TRS.copy(MTIVLOTSTS_TO.EXPIRE_DATE, sizeof(MTIVLOTSTS_TO.EXPIRE_DATE), in_node, "EXPIRE_DATE");

		if (COM_isnullspace(TRS.get_string(in_node, "TO_RACK"))== MP_FALSE)
		{
			TRS.copy(MTIVLOTSTS_TO.INV_CMF_7,  sizeof(MTIVLOTSTS_TO.INV_CMF_7), in_node, "TO_RACK");
		}
		else
		{
			memset(MTIVLOTSTS_TO.INV_CMF_7, ' ', sizeof(MTIVLOTSTS_TO.INV_CMF_7));
		}

		if (TRS.get_char(in_node, "IN_STOCK_FLAG") == 'Y')
		{
			//memcpy(MTIVLOTSTS.INV_CMF_1, s_tran_time, sizeof(s_tran_time));
			memcpy(MTIVLOTSTS_TO.INV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.INV_IN_TIME));
			TRS.copy(MTIVLOTSTS_TO.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS_TO.ERP_INV_IN_DATE), in_node, "WORK_DATE");
		}

		if (TRS.get_char(in_node, "PLANT_PO_FLAG") == 'Y')
		{			
			memset(MTIVLOTSTS_TO.ADD_ORDER_ID_1, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_ID_1));
			memset(MTIVLOTSTS_TO.ADD_ORDER_ID_2, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_ID_2));
			memset(MTIVLOTSTS_TO.ADD_ORDER_ID_3, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_ID_3));

			memset(MTIVLOTSTS_TO.ADD_ORDER_LINE_1, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_LINE_1));
			memset(MTIVLOTSTS_TO.ADD_ORDER_LINE_2, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_LINE_2));
			memset(MTIVLOTSTS_TO.ADD_ORDER_LINE_3, ' ', sizeof(MTIVLOTSTS_TO.ADD_ORDER_LINE_3));
		}		 
    }

	if (b_lot_dup==MP_TRUE)//Lot이 존재할때
		TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U');            
    else
        TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'I');    

    DBC_init_mtivlothis(&MTIVLOTHIS);
  
    if(TIV_update_insert_lot_status_history_transfer(s_msg_code, 
                                            in_node,
                                            out_node,
                                            s_sys_time,
                                            &MTIVLOTSTS_OLD,
                                            &MTIVLOTSTS_TO,
                                            &MTIVLOTHIS) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	 
	if (TRS.get_char(in_node, "SKIP_IF_INFO_FLAG") != 'Y')
	{
		IF_node = TRS.create_node("INTERFACE_IN");
		TRS.add_char(IF_node, IN_PROCSTEP, '1');
		TRS.add_enc_nstring(IF_node, IN_USERID, TRS.get_userid(in_node));
		TRS.add_char(IF_node, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(IF_node, IN_FACTORY, TRS.get_factory(in_node));
					
		 
		TRS.add_nstring(IF_node, "BUDAT", TRS.get_string(in_node, "WORK_DATE"));				 
		//TRS.add_nstring(IF_node, "AUFNR", TRS.get_string(in_node, "ORDER_ID"));
		
		TRS.add_char(IF_node, "RETURN_FLAG", TRS.get_char(in_node, "RETURN_FLAG"));
		TRS.add_nstring(IF_node, "LIFNR", TRS.get_string(in_node, "VENDOR_CODE"));

		TRS.add_nstring(IF_node, "WERKS", TRS.get_factory(in_node));
		TRS.add_nstring(IF_node, "WERKS1", TRS.get_factory(in_node));
		TRS.add_string(IF_node, "MATNR", MTIVLOTSTS_TO.MAT_ID, sizeof(MTIVLOTSTS_TO.MAT_ID));
		TRS.add_string(IF_node, "MATNR1", MTIVLOTSTS_TO.MAT_ID, sizeof(MTIVLOTSTS_TO.MAT_ID));

		if (TRS.get_char(in_node, "RETURN_FLAG") == 'Y')
		{			
			TRS.add_nstring(IF_node, "LGORT", TRS.get_string(in_node, "TO_OPER"));			
			TRS.add_nstring(IF_node, "LGORT1", TRS.get_string(in_node, "OPER"));			
		}
		else
		{
			TRS.add_nstring(IF_node, "LGORT", TRS.get_string(in_node, "OPER"));		 
			TRS.add_nstring(IF_node, "LGORT1", TRS.get_string(in_node, "TO_OPER"));		 
		}
		 
		//i_last_if_seq++; ?????
		//TRS.add_int(IF_node, "SEQNO", i_last_if_seq);
	 
		TRS.add_double(IF_node, "MENGE", MTIVLOTSTS_TO.QTY_1);
 			
		TRS.add_string(IF_node, "ERNAM", "MES", strlen("MES"));
		TRS.add_string(IF_node, "ERDAT", s_sys_time, 8);
		TRS.add_string(IF_node, "ERZET", s_sys_time + 8, 6);
				
		TRS.add_string(IF_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));
			
		TRS.add_string(IF_node, "LOT_ID", MTIVLOTSTS_TO.LOT_ID, sizeof(MTIVLOTSTS_TO.LOT_ID));
		TRS.add_int(IF_node, "HIST_SEQ", MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ);
		TRS.add_string(IF_node, "MEINS", MTIVLOTSTS_TO.UNIT_1, sizeof(MTIVLOTSTS_TO.UNIT_1));
						
		TRS.add_int(IF_node, "MAT_VER", MTIVLOTSTS_TO.MAT_VER);

		if (TRS.get_char(in_node, "CUST_RETURN_FLAG") == 'Y')
		{
			TRS.set_char(IF_node, "ONLY_MOVE_INFO_FLAG", 'Y');
			TRS.set_string(IF_node, "MVT_CODE", MP_ERP_MVT_NA, strlen(MP_ERP_MVT_NA));
			TRS.set_char(IF_node,"ERP_IN_OUT_FLAG", MP_MVT_IN_OUT_FLAG_IN);

			TRS.add_string(IF_node, "BWART", MP_ERP_MVT_NA, strlen(MP_ERP_MVT_NA));	 
		} 
		else
		{
			TRS.add_nstring(IF_node, "BWART", TRS.get_string(in_node, "MVT_CODE"));	 
			TRS.add_char(IF_node, "ERP_IN_OUT_FLAG", MP_MVT_IN_OUT_FLAG_BOTH);		
		}

		if (TRS.get_char(in_node, "RETURN_FLAG") == 'Y')
		{
			//if (CUS_MES_To_ERP_Return(s_msg_code, IF_node, out_node) == MP_FALSE)
			//{
			//	TRS.free_node(IF_node);
			//	return MP_FALSE;
			//}
		}
		else
		{
			//if (CUS_MES_To_ERP_Move(s_msg_code, IF_node, out_node) == MP_FALSE)
			//{
			//	TRS.free_node(IF_node);
			//	return MP_FALSE;
			//}
		}
		
		TRS.free_node(IF_node);

	}

	

	if (TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG") == 'Y')
	{	
//		memset(s_oper_temp, ' ', sizeof(s_oper_temp));
//		TRS.copy(s_oper_temp, sizeof(s_oper_temp), in_node, "OPER");
//
//		/*TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
//		TRS.set_string(in_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));*/
//		TRS.set_nstring(in_node, "OPER", TRS.get_string(in_node, "FROM_OPER"));
//		
//		TRS.set_string(in_node, "MAT_ID", MTIVLOTSTS_TO.MAT_ID, sizeof(MTIVLOTSTS_TO.MAT_ID));
//		TRS.set_int(in_node, "MAT_VER", MTIVLOTSTS_TO.MAT_VER);
//		TRS.set_char(in_node, "IN_OUT_FLAG", 'O');
//		TRS.set_double(in_node, "ADJUST_QTY_1",  TRS.get_double(in_node, "MOVE_QTY_1"));
//		TRS.set_int(in_node, "HIST_SEQ", MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ);
//		if (TIV_Create_Inventory_Adjust_Info(s_msg_code, in_node, out_node) == MP_FALSE)
//		{
//			return MP_FALSE;
//		}
//
//		TRS.set_string(in_node, "OPER", s_oper_temp, sizeof(s_oper_temp));
//
//
//		/*memset(s_oper_temp, ' ', sizeof(s_oper_temp));
//		TRS.copy(s_oper_temp, sizeof(s_oper_temp), in_node, "OPER");
//*/
//		/*TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
//		TRS.set_string(in_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));*/
//
//		TRS.set_string(in_node, "MAT_ID", MTIVLOTSTS_TO.MAT_ID, sizeof(MTIVLOTSTS_TO.MAT_ID));
//		TRS.set_int(in_node, "MAT_VER", MTIVLOTSTS_TO.MAT_VER);
//		TRS.set_nstring(in_node, "OPER", TRS.get_string(in_node, "TO_OPER"));
//		TRS.set_char(in_node, "IN_OUT_FLAG", 'I');
//		TRS.set_double(in_node, "ADJUST_QTY_1",  TRS.get_double(in_node, "MOVE_QTY_1"));
//		TRS.set_int(in_node, "HIST_SEQ", MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ);
//		if (TIV_Create_Inventory_Adjust_Info(s_msg_code, in_node, out_node) == MP_FALSE)
//		{
//			return MP_FALSE;
//		}

		//TRS.set_string(in_node, "OPER", s_oper_temp, sizeof(s_oper_temp));
	}

	if (TRS.get_char(in_node, "TRS_FLAG") == 'Y')
	{
		// Transfer Request Related Logic - Add TRS Info

		DBC_init_mtivtrsmst(&MTIVTRSMST);
		TRS.copy(MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
		DBC_select_mtivtrsmst_for_update(1, &MTIVTRSMST);
		if(DB_error_code != DB_SUCCESS) 
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0015");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);	
			}

			TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;              
		}

		if (MTIVTRSMST.RT_FLAG == 'Y')
		{
			DBC_init_mtivtrsdtl(&MTIVTRSDTL);
			TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
			TRS.copy(MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID), in_node, "LOT_ID");
			i_step = 4;
		}
		else
		{
			DBC_init_mtivtrsdtl(&MTIVTRSDTL);
			TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
			TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.TRS_NO), in_node, "MAT_ID");
			i_step = 3;
		}
		
		DBC_select_mtivtrsdtl_for_update(i_step, &MTIVTRSDTL);	
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0714");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}

			TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_CHR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// Assign Lot to TRS 
		DBC_init_mtivtrslot(&MTIVTRSLOT);
		TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
		TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
		MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
		memcpy(MTIVTRSLOT.LOT_ID, MTIVLOTSTS_TO.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
		TRS.copy(MTIVTRSLOT.OPER, sizeof(MTIVTRSLOT.OPER), in_node, "FROM_OPER");
			 
		i_step = 1;
		DBC_select_mtivtrslot(i_step, &MTIVTRSLOT);			
		if(DB_error_code != DB_SUCCESS) 
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
					
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVTRSLOT OPEN", MP_NVST);        
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
				TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
				TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}				
		}
		else
		{
			strcpy(s_msg_code, "WIP-0712");
			TRS.add_fieldmsg(out_node, "MTIVTRSLOT OPEN", MP_NVST);        
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
			TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
		TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
		MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
		memcpy(MTIVTRSLOT.LOT_ID, MTIVLOTSTS_TO.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));

		TRS.copy(MTIVTRSLOT.OPER, sizeof(MTIVTRSLOT.OPER), in_node, "FROM_OPER");
		//memcpy(MTIVTRSLOT.OPER, MTIVLOTSTS.OPER, sizeof(MTIVTRSLOT.OPER));
		
		memcpy(MTIVTRSLOT.MAT_ID, MTIVLOTSTS_TO.MAT_ID, sizeof(MTIVTRSLOT.MAT_ID));
		MTIVTRSLOT.MAT_VER = MTIVLOTSTS_TO.MAT_VER;
		MTIVTRSLOT.ASSIGN_QTY = TRS.get_double(in_node, "MOVE_QTY_1");
		TRS.copy(MTIVTRSLOT.CREATE_USER_ID, sizeof(MTIVTRSLOT.CREATE_USER_ID), in_node, "PRC_USER");
		memcpy(MTIVTRSLOT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

		DBC_insert_mtivtrslot(&MTIVTRSLOT);        
		if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MTIVTRSLOT INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
			TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
            
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, "PRC_USER");
		memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
		
		MTIVTRSDTL.QTY_1 += TRS.get_double(in_node, "MOVE_QTY_1");

		MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_PROCESSING;
		if (MTIVTRSMST.RT_FLAG == 'Y')
		{
			i_step = 6;
		}
		else
		{
			i_step = 5;
		}

		DBC_update_mtivtrsdtl(i_step, &MTIVTRSDTL);	
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0714");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}

			TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_CHR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.copy(MTIVTRSMST.UPDATE_USER_ID, sizeof(MTIVTRSMST.UPDATE_USER_ID), in_node, "PRC_USER");
		memcpy(MTIVTRSMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
		MTIVTRSMST.STATUS_FLAG = MP_INV_STATUS_PROCESSING;
		i_step = 3;
		DBC_update_mtivtrsmst(i_step, &MTIVTRSMST);
		if(DB_error_code != DB_SUCCESS) 
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0015");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);	
			}

			TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;              
		}


		DBC_init_mtivmlstrs(&MTIVMLSTRS);   
		TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
		memcpy(MTIVMLSTRS.WORK_DATE, MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVMLSTRS.WORK_DATE));
		memcpy(MTIVMLSTRS.SHIFT, MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVMLSTRS.SHIFT));
		if (COM_isnum(MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3), 'N', MP_FALSE) == MP_FALSE)
		{
			MTIVMLSTRS.GEN_SEQ_NUM = 0;
		}
		else
		{
			MTIVMLSTRS.GEN_SEQ_NUM = COM_atoi(MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3));
		}
		memcpy(MTIVMLSTRS.MAT_ID, MTIVTRSDTL.MAT_ID, sizeof(MTIVMLSTRS.MAT_ID));
		MTIVMLSTRS.MAT_VER  = MTIVTRSDTL.MAT_VER;

		i_step = 1;
		DBC_select_mtivmlstrs_for_update(i_step, &MTIVMLSTRS); 
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
						
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
				TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
				TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}					
		}
		else
		{			
			MTIVMLSTRS.TOTAL_RCV_QTY_1 += TRS.get_double(in_node, "MOVE_QTY_1");
			 
			i_step = 3;
			DBC_update_mtivmlstrs(i_step, &MTIVMLSTRS); 
			if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
				TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
				TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		
	}

	if (TRS.get_char(in_node, "__FROM_LOSS_OPER_FLAG") == 'Y')
	{
		DBC_init_mtmplotlsm(&MTMPLOTLSM);
		TRS.copy(MTMPLOTLSM.FACTORY , sizeof(MTMPLOTLSM.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTMPLOTLSM.LOT_ID, sizeof(MTMPLOTLSM.LOT_ID), in_node, "LOT_ID");
		MTMPLOTLSM.HIST_DEL_FLAG = 'Y';
		
        DBC_update_mtmplotlsm(3, &MTMPLOTLSM);        
        if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTMPLOTLSM UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTMPLOTLSM.LOT_ID), MTMPLOTLSM.LOT_ID);
			  
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }


	}
	 
    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_TRANSFER_LOT() - OLD Logic
        - Main sub function of "TIV_Transfer_Lot" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_TRANSFER_LOT_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
//int TIV_TRANSFER_LOT(char *s_msg_code,
//                       TRSNode *in_node, 
//                       TRSNode *out_node)
//
//{
//    struct MTIVMATDEF_TAG MTIVMATDEF;
//    struct MTIVLOTSTS_TAG MTIVLOTSTS;
//    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
//    struct MTIVLOTSTS_TAG MTIVLOTSTS_COMPARE;
//    struct MTIVLOTHIS_TAG MTIVLOTHIS;
//    struct MATRNAMSTS_TAG MATRNAMSTS_OLD;
//	struct MATRNAMSTS_TAG MATRNAMSTS;
//
//	struct  MTIVTRSLOT_TAG  MTIVTRSLOT;
//	struct  MTIVTRSMST_TAG  MTIVTRSMST;
//	struct	MTIVTRSDTL_TAG  MTIVTRSDTL;
//
//	//struct CPLNMIMDEF_TAG CPLNMIMDEF;
//	
//    char s_sys_time[14];
//    char s_inv_lot_id[25];
//    int b_lot_dup = 0;
//	int i_step;
//	int iMaxProjectVer;
//
//	int i_last_active_hist_seq;
//	 
//    LOG_head("TIV_TRANSFER_LOT");
//    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
//    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
//    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
//    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
//    LOG_add("to_factory", MP_NSTR, TRS.get_string(in_node, "TO_FACTORY"));
//    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
//    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
//    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));    
//    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
//    LOG_add("location_no", MP_NSTR, TRS.get_string(in_node, "LOCATION_NO"));
//    LOG_add("to_oper", MP_NSTR, TRS.get_string(in_node, "TO_OPER"));
//	LOG_add("to_location_no", MP_NSTR, TRS.get_string(in_node, "TO_LOCATION_NO"));
//	LOG_add("qty_1", MP_DBL, TRS.get_double(in_node, "QTY_1"));
//    LOG_add("qty_2", MP_DBL, TRS.get_double(in_node, "QTY_2"));
//    LOG_add("qty_3", MP_DBL, TRS.get_double(in_node, "QTY_3"));
//    LOG_add("move_qty_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
//    LOG_add("move_qty_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
//    LOG_add("move_qty_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));
//    //LOG_add("tran_code", MP_NSTR, TRS.get_string(in_node, "TRAN_CODE"));
//    LOG_add("tran_type", MP_NSTR, TRS.get_string(in_node, "TRAN_TYPE"));
//    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));    
//    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
//    LOG_add("inv_cmf_1", MP_NSTR, TRS.get_string(in_node, "INV_CMF_1"));
//    LOG_add("inv_cmf_2", MP_NSTR, TRS.get_string(in_node, "INV_CMF_2"));
//    LOG_add("inv_cmf_3", MP_NSTR, TRS.get_string(in_node, "INV_CMF_3"));
//    LOG_add("inv_cmf_4", MP_NSTR, TRS.get_string(in_node, "INV_CMF_4"));
//    LOG_add("inv_cmf_5", MP_NSTR, TRS.get_string(in_node, "INV_CMF_5"));
//    LOG_add("inv_cmf_6", MP_NSTR, TRS.get_string(in_node, "INV_CMF_6"));
//    LOG_add("inv_cmf_7", MP_NSTR, TRS.get_string(in_node, "INV_CMF_7"));
//    LOG_add("inv_cmf_8", MP_NSTR, TRS.get_string(in_node, "INV_CMF_8"));
//    LOG_add("inv_cmf_9", MP_NSTR, TRS.get_string(in_node, "INV_CMF_9"));
//    LOG_add("inv_cmf_10", MP_NSTR, TRS.get_string(in_node, "INV_CMF_10"));
//    LOG_add("inv_cmf_11", MP_NSTR, TRS.get_string(in_node, "INV_CMF_11"));
//    LOG_add("inv_cmf_12", MP_NSTR, TRS.get_string(in_node, "INV_CMF_12"));
//    LOG_add("inv_cmf_13", MP_NSTR, TRS.get_string(in_node, "INV_CMF_13"));
//    LOG_add("inv_cmf_14", MP_NSTR, TRS.get_string(in_node, "INV_CMF_14"));
//    LOG_add("inv_cmf_15", MP_NSTR, TRS.get_string(in_node, "INV_CMF_15"));
//    LOG_add("inv_cmf_16", MP_NSTR, TRS.get_string(in_node, "INV_CMF_16"));
//    LOG_add("inv_cmf_17", MP_NSTR, TRS.get_string(in_node, "INV_CMF_17"));
//    LOG_add("inv_cmf_18", MP_NSTR, TRS.get_string(in_node, "INV_CMF_18"));
//    LOG_add("inv_cmf_19", MP_NSTR, TRS.get_string(in_node, "INV_CMF_19"));
//    LOG_add("inv_cmf_20", MP_NSTR, TRS.get_string(in_node, "INV_CMF_20"));
//
//	LOG_add("attr_type", MP_NSTR, TRS.get_string(in_node, "ATTR_TYPE"));
//	LOG_add("attr_name", MP_NSTR, TRS.get_string(in_node, "ATTR_NAME"));
//	LOG_add("attr_key", MP_NSTR, TRS.get_string(in_node, "ATTR_KEY"));
//	LOG_add("expire_date", MP_NSTR, TRS.get_string(in_node,"EXPIRE_DATE"));
//
//    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
//
//    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Lot",
//                             MP_UPOINT_BEFORE,
//                             in_node,
//                             out_node) == MP_FALSE)     return MP_FALSE;
//    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
//
//    memset(s_sys_time, ' ', sizeof(s_sys_time));
//    memset(s_inv_lot_id,' ', sizeof(s_inv_lot_id));
//
//    DB_get_systime(s_sys_time);
//    if(DB_error_code != DB_SUCCESS)
//    {
//        strcpy(s_msg_code, "INV-0004");
//        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.e_type = MP_LOG_E_SYSTEM;
//        gs_log_type.category = MP_LOG_CATE_TRANS;
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//
//    TRS.set_nstring(in_node, "__FACTORY", TRS.get_string(in_node, IN_FACTORY));
//    TRS.set_nstring(in_node, "__OPER", TRS.get_string(in_node, "OPER"));
//    if(TIV_Lot_Fill_InTag_Cmf(s_msg_code, in_node, out_node) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//    
//    /*' Validation Check*/ //Attribute값도 같이 가지고옴 
//    if(TIV_Transfer_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//
//    TRS.copy(s_inv_lot_id, sizeof(s_inv_lot_id), in_node, "LOT_ID");
//
//    //From Status & History
//    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
//    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);    
//    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "LOT_ID");
//	TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "OPER");
//    DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_OLD);
//    if(DB_error_code != DB_SUCCESS)
//    {
//        if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "INV-0022");             
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else 
//        {
//            strcpy(s_msg_code, "INV-0004");            
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//        }
//
//        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);
//        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_OLD.OPER), MTIVLOTSTS_OLD.OPER);
//        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);
//        TRS.add_dberrmsg(out_node, DB_error_msg);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_TRANS;
//
//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//
//    //To Status & History
//    DBC_init_mtivlotsts(&MTIVLOTSTS);
//    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
//    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
//	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TO_OPER");
//    DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS);
//    if(DB_error_code == DB_SUCCESS && TRS.get_char(in_node, "LOT_GROUP_FLAG")=='Y')
//    {
//        b_lot_dup=MP_TRUE;
//    }
//    else if(DB_error_code == DB_SUCCESS)
//    {
//        
//    }
//    else if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
//    {
//        strcpy(s_msg_code, "INV-0004");
//        gs_log_type.e_type = MP_LOG_E_SYSTEM;
//        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
//        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
//        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
//        TRS.add_dberrmsg(out_node, DB_error_msg);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_TRANS;
//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//
//	i_step = 10;
//	i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS);
//
//    if(b_lot_dup==MP_TRUE)//Target Lot이 존재할때
//    {
//         //Make Old Status   //일부가 나갈때
//        if(MTIVLOTSTS_OLD.QTY_1>=TRS.get_double(in_node, "MOVE_QTY_1") || 
//			MTIVLOTSTS_OLD.QTY_2>=TRS.get_double(in_node, "MOVE_QTY_2") ||
//			MTIVLOTSTS_OLD.QTY_3>=TRS.get_double(in_node, "MOVE_QTY_3"))
//        {
//            ////OLD LOT수량계산
//            //if(TRS.get_char(in_node, "IQC_LOT")!='Y')
//            //{
//            MTIVLOTSTS_OLD.QTY_1 = MTIVLOTSTS_OLD.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1");
//            MTIVLOTSTS_OLD.QTY_2 = MTIVLOTSTS_OLD.QTY_2 - TRS.get_double(in_node, "MOVE_QTY_2");
//            MTIVLOTSTS_OLD.QTY_3 = MTIVLOTSTS_OLD.QTY_3 - TRS.get_double(in_node, "MOVE_QTY_3");
//            /*}*/
//        }
//
//        //TargetLot수량계산
//        MTIVLOTSTS.QTY_1 = MTIVLOTSTS.QTY_1 + TRS.get_double(in_node, "MOVE_QTY_1");
//        MTIVLOTSTS.QTY_2 = MTIVLOTSTS.QTY_2 + TRS.get_double(in_node, "MOVE_QTY_2");
//        MTIVLOTSTS.QTY_3 = MTIVLOTSTS.QTY_3 + TRS.get_double(in_node, "MOVE_QTY_3");
//		MTIVLOTSTS.LOT_DEL_FLAG=' ';
//		memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));
//        TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
//		memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_sys_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
//        TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");    
//    }
//    else//Target Lot이 존재하지 않을때 - B의 수량은 이동수량만
//    {
//        memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));
//
//        //Make New Status
//	    TRS.copy(MTIVLOTSTS.OPER,  sizeof(MTIVLOTSTS.OPER), in_node, "TO_OPER");
//	    TRS.copy(MTIVLOTSTS.LOCATION_NO,  sizeof(MTIVLOTSTS.LOCATION_NO), in_node, "TO_LOCATION_NO");
//        //Target Lot은 받는수량이 QTY수량
//
//        //if(TRS.get_char(in_node,"LOT_GROUP_FLAG")=='Y')
//        //{
//        MTIVLOTSTS.QTY_1 = TRS.get_double(in_node, "MOVE_QTY_1");
//        MTIVLOTSTS.QTY_2 = TRS.get_double(in_node, "MOVE_QTY_2");
//        MTIVLOTSTS.QTY_3 = TRS.get_double(in_node, "MOVE_QTY_3");
//
//        MTIVLOTSTS_OLD.QTY_1 = MTIVLOTSTS_OLD.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1");
//        MTIVLOTSTS_OLD.QTY_2 = MTIVLOTSTS_OLD.QTY_2 - TRS.get_double(in_node, "MOVE_QTY_2");
//        MTIVLOTSTS_OLD.QTY_3 = MTIVLOTSTS_OLD.QTY_3 - TRS.get_double(in_node, "MOVE_QTY_3");
//        //}
//
//        memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));
//        TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
//        memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_sys_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
//        TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");    
//        memset(MTIVLOTSTS.FROM_TO_LOT_ID, ' ', sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
//		MTIVLOTSTS.FROM_TO_HIST_SEQ = 0;
//        MTIVLOTSTS.FROM_TO_FLAG = ' ';
//        MTIVLOTSTS.LOT_DEL_FLAG = ' ';
//        memset(MTIVLOTSTS.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
//        memset(MTIVLOTSTS.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS.LOT_DEL_TIME));
//        memset(MTIVLOTSTS.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS.LOT_DEL_REASON));
//        MTIVLOTSTS.IN_OUT_FLAG = 'O';
//        if(COM_isnullspace(TRS.get_string(in_node, "ORDER_ID")) == MP_FALSE)
//        {
//            TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), in_node, "ORDER_ID");
//        }
//
//		MTIVLOTSTS.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
//        //MTIVLOTSTS.LAST_HIST_SEQ ++;
//        MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;
//        TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_1");
//        TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_2");
//        TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_3");
//        TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_4");
//        TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_5");
//        TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_6");
//        TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_7");
//        TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_8");
//        TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_9");
//        TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_10");
//        TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_11");
//        TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_12");
//        TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_13");
//        TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_14");
//        TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_15");
//        TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_16");
//        TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_17");
//        TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_18");
//        TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_19");
//        TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_20");
//	    TRS.copy(MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE), in_node, "EXPIRE_DATE");
//    }
//	
//	/*DBC_init_cplnmimdef(&CPLNMIMDEF);   
//	TRS.copy(CPLNMIMDEF.FACTORY, sizeof(CPLNMIMDEF.FACTORY), in_node, IN_FACTORY);
//	TRS.copy(CPLNMIMDEF.PROJECT_ID, sizeof(CPLNMIMDEF.PROJECT_ID), in_node, "PROJECT_CODE");
//	memcpy(CPLNMIMDEF.CHILD_MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(CPLNMIMDEF.CHILD_MAT_ID));
//	CPLNMIMDEF.CHILD_MAT_VER = MTIVLOTSTS.MAT_VER;
//	
//	i_step = 2;
//	iMaxProjectVer = (int)DBC_select_cplnmimdef_scalar(i_step, &CPLNMIMDEF);
//
//	if (iMaxProjectVer <= 0)
//	{
//		strcpy(s_msg_code, "WIP-0625");
//		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//		TRS.add_dberrmsg(out_node, DB_error_msg);
//
//		TRS.add_fieldmsg(out_node, "CPLNMIMDEF SELECT", MP_NVST);        
//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(CPLNMIMDEF.FACTORY), CPLNMIMDEF.FACTORY);
//		TRS.add_fieldmsg(out_node, "PROJECT_ID", MP_STR,  sizeof(CPLNMIMDEF.PROJECT_ID), CPLNMIMDEF.PROJECT_ID);
//		TRS.add_fieldmsg(out_node, "CHILD_MAT_ID", MP_STR,  sizeof(CPLNMIMDEF.CHILD_MAT_ID), CPLNMIMDEF.CHILD_MAT_ID);
//
//		gs_log_type.type = MP_LOG_ERROR;
//		gs_log_type.category = MP_LOG_CATE_VIEW;
//
//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//		return MP_FALSE;		
//	}
//	*/
//    DBC_init_mtivlothis(&MTIVLOTHIS);
//    //Lot exist in to_oper already
//    if(TRS.get_char(in_node, "LOT_GROUP_FLAG")=='Y')
//    {
//        if(b_lot_dup==MP_TRUE)//Lot이 존재할때
//            TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U');    
//        //Lot not exist in to_oper already
//        /*else if(MTIVLOTSTS_OLD.QTY_1 != 0 || MTIVLOTSTS_OLD.QTY_2 != 0 || MTIVLOTSTS_OLD.QTY_3 != 0)
//            TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U');*/
//        //Normal case as wiplot. whole lot move and to_oper desn't have same lot.
//        else
//            TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'I');    
//    }
//    else
//        TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U');    
//
//	//TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), in_node, "PROJECT_CODE");
//	//TRS.copy(MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2), in_node, "SHOP_CODE");
//	COM_ftoa(MTIVLOTHIS.TRAN_CMF_1, TRS.get_double(in_node, "MOVE_QTY_1"), sizeof(MTIVLOTHIS.TRAN_CMF_1));
//	COM_ftoa(MTIVLOTHIS.TRAN_CMF_2, TRS.get_double(in_node, "MOVE_QTY_2"), sizeof(MTIVLOTHIS.TRAN_CMF_2));
//	COM_ftoa(MTIVLOTHIS.TRAN_CMF_3, TRS.get_double(in_node, "MOVE_QTY_3"), sizeof(MTIVLOTHIS.TRAN_CMF_3));
//
//	if (TRS.get_char(in_node, "TRS_FLAG") == 'Y')
//	{
//		TRS.copy(MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
//	}   
//
//    if(TIV_update_insert_lot_status_history_transfer(s_msg_code, 
//                                            in_node,
//                                            out_node,
//                                            s_sys_time,
//                                            &MTIVLOTSTS_OLD,
//                                            &MTIVLOTSTS,
//                                            &MTIVLOTHIS) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//
//    
//  //  if(TRS.get_char(in_node, "LOT_GROUP_FLAG")=='Y')
//  //  {
//		////모든 수량이 처리되지 않으면
//    DBC_update_mtivlotsts(3, &MTIVLOTSTS_OLD);
//    if(DB_error_code != DB_SUCCESS)
//	{
//		strcpy(s_msg_code, "WIP-0004");
//		TRS.add_dberrmsg(out_node, DB_error_msg);
//		TRS.add_fieldmsg(out_node, "MTIVLOTSTS UPDATE", MP_NVST);
//		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);			
//		TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_OLD.OPER), MTIVLOTSTS_OLD.OPER);		
//
//		gs_log_type.type = MP_LOG_ERROR;
//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
//		gs_log_type.category = MP_LOG_CATE_TRANS;
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//		return MP_FALSE;
//    }
//  //    //  if((MTIVLOTSTS_OLD.QTY_1 == 0 && MTIVLOTSTS_OLD.QTY_2 == 0 && MTIVLOTSTS_OLD.QTY_3 == 0))
//  //    //  {
//  //    //      DBC_delete_mtivlotsts(4, &MTIVLOTSTS_OLD);
//  //    //      if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
//		//    //{
//		//	   // strcpy(s_msg_code, "WIP-0004");
//		//	   // TRS.add_dberrmsg(out_node, DB_error_msg);
//		//	   // TRS.add_fieldmsg(out_node, "MTIVLOTSTS DELETE", MP_NVST);
//		//	   // TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_COMPARE.LOT_ID), MTIVLOTSTS_COMPARE.LOT_ID);			
//		//	   // TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_COMPARE.OPER), MTIVLOTSTS_COMPARE.OPER);		
//
//		//	   // gs_log_type.type = MP_LOG_ERROR;
//		//	   // gs_log_type.e_type = MP_LOG_E_SYSTEM;
//		//	   // gs_log_type.category = MP_LOG_CATE_TRANS;
//  //    //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//		//	   // return MP_FALSE;
//		//    //}
//  //    //  }
//  //    //  else
//  //    //  {
//  //    //      //모든 수량이 처리되지 않으면
//  //    //      DBC_update_mtivlotsts(3, &MTIVLOTSTS_OLD);
//  //    //      if(DB_error_code != DB_SUCCESS)
//		//    //{
//		//	   // strcpy(s_msg_code, "WIP-0004");
//		//	   // TRS.add_dberrmsg(out_node, DB_error_msg);
//		//	   // TRS.add_fieldmsg(out_node, "MTIVLOTSTS UPDATE", MP_NVST);
//		//	   // TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);			
//		//	   // TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_OLD.OPER), MTIVLOTSTS_OLD.OPER);		
//
//		//	   // gs_log_type.type = MP_LOG_ERROR;
//		//	   // gs_log_type.e_type = MP_LOG_E_SYSTEM;
//		//	   // gs_log_type.category = MP_LOG_CATE_TRANS;
//  //    //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//		//	   // return MP_FALSE;
//  //    //      }
//  //    //  }
//  //  }
//
//	if (TRS.get_char(in_node, "TRS_FLAG") == 'Y')
//	{
//		// Transfer Request Related Logic - Add TRS Info
//
//		DBC_init_mtivtrsmst(&MTIVTRSMST);
//		TRS.copy(MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
//		TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
//		DBC_select_mtivtrsmst_for_update(1, &MTIVTRSMST);
//		if(DB_error_code != DB_SUCCESS) 
//		{
//			if (DB_error_code == DB_NOT_FOUND)
//			{
//				strcpy(s_msg_code, "INV-0015");
//				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//			}
//			else
//			{
//				strcpy(s_msg_code, "INV-0004");
//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
//				TRS.add_dberrmsg(out_node, DB_error_msg);	
//			}
//
//			TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
//			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
//			TRS.add_dberrmsg(out_node, DB_error_msg);
//
//			gs_log_type.type = MP_LOG_ERROR;
//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//			gs_log_type.category = MP_LOG_CATE_TRANS;
//
//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//			return MP_FALSE;              
//		}
//
//		DBC_init_mtivtrsdtl(&MTIVTRSDTL);
//		TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
//		TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
//		TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.TRS_NO), in_node, "MAT_ID");
//		i_step = 3;
//		DBC_select_mtivtrsdtl_for_update(i_step, &MTIVTRSDTL);	
//		if(DB_error_code != DB_SUCCESS)
//		{
//			if(DB_error_code == DB_NOT_FOUND)
//			{
//				strcpy(s_msg_code, "WIP-0714");
//				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//			}
//			else 
//			{
//				strcpy(s_msg_code, "INV-0004");
//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
//				TRS.add_dberrmsg(out_node, DB_error_msg);
//			}
//
//			TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT FOR UPDATE", MP_NVST);
//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
//			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
//			TRS.add_fieldmsg(out_node, "MAT_ID", MP_CHR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
//			TRS.add_dberrmsg(out_node, DB_error_msg);
//
//			gs_log_type.type = MP_LOG_ERROR;
//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//			gs_log_type.category = MP_LOG_CATE_VIEW;
//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//			return MP_FALSE;
//		}
//
//		// Assign Lot to TRS 
//		DBC_init_mtivtrslot(&MTIVTRSLOT);
//		TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
//		TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
//		MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
//		memcpy(MTIVTRSLOT.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
//		TRS.copy(MTIVTRSLOT.OPER, sizeof(MTIVTRSLOT.OPER), in_node, "FROM_OPER");
//			 
//		i_step = 1;
//		DBC_select_mtivtrslot(i_step, &MTIVTRSLOT);			
//		if(DB_error_code != DB_SUCCESS) 
//		{
//			if (DB_error_code == DB_NOT_FOUND)
//			{
//					
//			}
//			else
//			{
//				strcpy(s_msg_code, "WIP-0004");
//				TRS.add_fieldmsg(out_node, "MTIVTRSLOT OPEN", MP_NVST);        
//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
//				TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
//				TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
//				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
//				TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
//				gs_log_type.type = MP_LOG_ERROR;
//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
//				gs_log_type.category = MP_LOG_CATE_VIEW;
//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//				return MP_FALSE;
//			}				
//		}
//		else
//		{
//			strcpy(s_msg_code, "WIP-0712");
//			TRS.add_fieldmsg(out_node, "MTIVTRSLOT OPEN", MP_NVST);        
//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
//			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
//			TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
//			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
//			TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
//			gs_log_type.type = MP_LOG_ERROR;
//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//			gs_log_type.category = MP_LOG_CATE_VIEW;
//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//			return MP_FALSE;
//		}
//
//		TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
//		TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
//		MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
//		memcpy(MTIVTRSLOT.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
//
//		TRS.copy(MTIVTRSLOT.OPER, sizeof(MTIVTRSLOT.OPER), in_node, "FROM_OPER");
//		//memcpy(MTIVTRSLOT.OPER, MTIVLOTSTS.OPER, sizeof(MTIVTRSLOT.OPER));
//		
//		memcpy(MTIVTRSLOT.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVTRSLOT.MAT_ID));
//		MTIVTRSLOT.MAT_VER = MTIVLOTSTS.MAT_VER;
//		MTIVTRSLOT.ASSIGN_QTY = TRS.get_double(in_node, "MOVE_QTY_1");
//		TRS.copy(MTIVTRSLOT.CREATE_USER_ID, sizeof(MTIVTRSLOT.CREATE_USER_ID), in_node, IN_USERID);
//		memcpy(MTIVTRSLOT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
//
//		DBC_insert_mtivtrslot(&MTIVTRSLOT);        
//		if(DB_error_code != DB_SUCCESS) 
//		{
//			strcpy(s_msg_code, "WIP-0004");
//			TRS.add_fieldmsg(out_node, "MTIVTRSLOT INSERT", MP_NVST);
//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
//			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
//			TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
//			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
//			TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
//            
//			TRS.add_dberrmsg(out_node, DB_error_msg);
//
//			gs_log_type.type = MP_LOG_ERROR;
//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//			gs_log_type.category = MP_LOG_CATE_SETUP;
//
//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//			return MP_FALSE;
//		}
//
//		TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, IN_USERID);
//		memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
//		
//		MTIVTRSDTL.QTY_1 += TRS.get_double(in_node, "MOVE_QTY_1");
//
//		MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_PROCESSING;
//		i_step = 5;
//		DBC_update_mtivtrsdtl(i_step, &MTIVTRSDTL);	
//		if(DB_error_code != DB_SUCCESS)
//		{
//			if(DB_error_code == DB_NOT_FOUND)
//			{
//				strcpy(s_msg_code, "WIP-0714");
//				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//			}
//			else 
//			{
//				strcpy(s_msg_code, "INV-0004");
//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
//				TRS.add_dberrmsg(out_node, DB_error_msg);
//			}
//
//			TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT FOR UPDATE", MP_NVST);
//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
//			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
//			TRS.add_fieldmsg(out_node, "MAT_ID", MP_CHR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
//			TRS.add_dberrmsg(out_node, DB_error_msg);
//
//			gs_log_type.type = MP_LOG_ERROR;
//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//			gs_log_type.category = MP_LOG_CATE_VIEW;
//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//			return MP_FALSE;
//		}
//
//		TRS.copy(MTIVTRSMST.UPDATE_USER_ID, sizeof(MTIVTRSMST.UPDATE_USER_ID), in_node, IN_USERID);
//		memcpy(MTIVTRSMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
//		MTIVTRSMST.STATUS_FLAG = MP_INV_STATUS_PROCESSING;
//		i_step = 3;
//		DBC_update_mtivtrsmst(i_step, &MTIVTRSMST);
//		if(DB_error_code != DB_SUCCESS) 
//		{
//			if (DB_error_code == DB_NOT_FOUND)
//			{
//				strcpy(s_msg_code, "INV-0015");
//				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//			}
//			else
//			{
//				strcpy(s_msg_code, "INV-0004");
//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
//				TRS.add_dberrmsg(out_node, DB_error_msg);	
//			}
//
//			TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
//			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
//			TRS.add_dberrmsg(out_node, DB_error_msg);
//
//			gs_log_type.type = MP_LOG_ERROR;
//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//			gs_log_type.category = MP_LOG_CATE_TRANS;
//
//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//			return MP_FALSE;              
//		}
//		
//	}
//
//
//    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Lot",
//                             MP_UPOINT_AFTER,
//                             in_node,
//                             out_node) == MP_FALSE)     return MP_FALSE;
//    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
//
//    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
//    return MP_TRUE;
//}


/*******************************************************************************
    TIV_Transfer_Lot_Validation()
        - Validation Check sub function of "TIV_Transfer_Lot" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_Transfer_Lot_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Transfer_Lot_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    
	struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MATRNAMSTS_TAG MATRNAMSTS;
	struct MTIVOPRDEF_TAG MTIVOPRDEF_F;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;

    //int i_mat_ver = 0;
	//char s_temp[10];

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Proc Step validation */
    if(COM_check_value(s_msg_code,
                       in_node,
                       out_node,
                       IN_PROCSTEP,
                       'Y',
                       ' ',
                       0x00,
                       0x00,
                       0x00) == MP_FALSE)
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
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }      
    
    if(COM_isnullspace(TRS.get_string(in_node, "TO_FACTORY")) == MP_TRUE)
    {
        TRS.set_nstring(in_node, "TO_FACTORY", TRS.get_string(in_node, IN_FACTORY));
    }
    if(COM_isnullspace(TRS.get_string(in_node, "TO_OPER")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TO_OPER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_string(in_node, "TRAN_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TRAN_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /*if ((TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_MAT_TRN, strlen(MP_INV_TRAN_TYPE_MAT_TRN)) != 0) &&
        (TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_SPE_TRN, strlen(MP_INV_TRAN_TYPE_SPE_TRN)) != 0) &&
        (TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_WIP_TRN, strlen(MP_INV_TRAN_TYPE_WIP_TRN)) != 0) &&
		(TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_RJT_TRN, strlen(MP_INV_TRAN_TYPE_RJT_TRN)) != 0) &&
        (TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_RET_TRN, strlen(MP_INV_TRAN_TYPE_RET_TRN)) != 0))    
    {
        strcpy(s_msg_code, "INV-0004");
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        TRS.add_fieldmsg(out_node, "TRAN_TYPE", MP_STR, sizeof(TRS.get_string(in_node, "TRAN_TYPE")), TRS.get_string(in_node, "IN_TYPE"));
            
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        
        return MP_FALSE;
    }*/
    if(TRS.get_item_count(in_node, "CHILD_LOT_LIST") > 1)
    {
        strcpy(s_msg_code, "INV-0234");
        TRS.add_fieldmsg(out_node, "CHILD_LOT_LIST", MP_NVST);
        TRS.add_fieldmsg(out_node, "ITEM COUNT", MP_INT, TRS.get_item_count(in_node, "CHILD_LOT_LIST"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0005");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    //MTIVLOTSTS Check
    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);  
	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");

    DBC_select_mtivlotsts(4, &MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0022");             
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");            
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);        
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
	if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") < 1)
    {
        TRS.set_int(in_node, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
	}
	else
	{
		/* Hist Seq Validation */
		if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ) 
		{
			strcpy(s_msg_code, "WIP-0113");
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
			TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			return MP_FALSE;
		}
	}

    if(MTIVLOTSTS.LOT_DEL_FLAG =='Y')
    {
        strcpy(s_msg_code, "INV-0023");  
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;

    }

	if (COM_isnullspace(MTIVLOTSTS.INV_CMF_8) == MP_FALSE)
	{
		/*strcpy(s_msg_code, "WIP-0731");  
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
		TRS.add_fieldmsg(out_node, "INV_CMF_8", MP_STR, sizeof(MTIVLOTSTS.INV_CMF_8), MTIVLOTSTS.INV_CMF_8);
		TRS.add_fieldmsg(out_node, "INV_CMF_9", MP_STR, sizeof(MTIVLOTSTS.INV_CMF_9), MTIVLOTSTS.INV_CMF_9);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;*/
	}

    if(MTIVLOTSTS.HOLD_FLAG =='Y')
    {
        strcpy(s_msg_code, "INV-0024");  
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	/*if(TRS.get_double(in_node, "MOVE_QTY_1") > MTIVLOTSTS.QTY_1)
    {
        strcpy(s_msg_code, "WIP-0078");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	if(TRS.get_double(in_node, "MOVE_QTY_2") > MTIVLOTSTS.QTY_2)
    {
        strcpy(s_msg_code, "WIP-0078");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_QTY_2", MP_DBL, MTIVLOTSTS.QTY_2);
        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	if(TRS.get_double(in_node, "MOVE_QTY_3") > MTIVLOTSTS.QTY_1)
    {
        strcpy(s_msg_code, "WIP-0078");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_QTY_3", MP_DBL, MTIVLOTSTS.QTY_3);
        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
*/
	
 
	if (TIV_Check_Factory(s_msg_code, "MP_OnlyOneLiveINVLot", TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		if (TRS.get_char(in_node, "ALLOW_QTY_ADJUST_FLAG") != 'Y')
		{
			if(fabs(MTIVLOTSTS.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1")) > 0.0005) 
			{
				strcpy(s_msg_code, "WIP-0723");
				TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);
				TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				return MP_FALSE;
			}
		
			if(fabs(MTIVLOTSTS.QTY_2 - TRS.get_double(in_node, "MOVE_QTY_2")) > 0.0005) 
			{
				strcpy(s_msg_code, "WIP-0723");
				TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_QTY_2", MP_DBL, MTIVLOTSTS.QTY_2);
				TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				return MP_FALSE;
			}
		
			if(fabs(MTIVLOTSTS.QTY_3 - TRS.get_double(in_node, "MOVE_QTY_3")) > 0.0005) 
			{
				strcpy(s_msg_code, "WIP-0723");
				TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_QTY_3", MP_DBL, MTIVLOTSTS.QTY_3);
				TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				return MP_FALSE;
			}
		}
	}
   
	if (COM_isnullspace(TRS.get_string(in_node, "TO_RACK")) == MP_FALSE)
	{
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
        memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_TBL_INV_LOCATION, strlen(MP_GCM_TBL_INV_LOCATION));
        TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "TO_OPER");
        TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "TO_RACK");
        DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            if (DB_error_code == DB_NOT_FOUND)
            {   
                strcpy(s_msg_code,"GCM-0008");                          
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
            else
            {   
                strcpy(s_msg_code,"GCM-0004");          
                TRS.add_dberrmsg(out_node, DB_error_msg);   
                gs_log_type.e_type = MP_LOG_E_SYSTEM;                    
            }
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
            TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;
 
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
   }


	if(TIV_check_backtime(s_msg_code,
                            in_node,
                            out_node,
                            MTIVLOTSTS.LAST_TRAN_TIME) == MP_FALSE)
    {
        return MP_FALSE;
        
    } 

    //MAT check
    /*DBC_init_mtivmatdef(&MTIVMATDEF);
    memcpy(MTIVMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVMATDEF.FACTORY));
    memcpy(MTIVMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
    MTIVMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
    DBC_select_mtivmatdef(1, &MTIVMATDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0006");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");            
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }*/

	//MAT check
    DBC_init_mwipmatdef(&MWIPMATDEF);
    memcpy(MWIPMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
    memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
    MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
    DBC_select_mwipmatdef(1, &MWIPMATDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0006");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");            
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    //Get Lor Group option from attribute 
	/*DBC_init_matrnamsts(&MATRNAMSTS);
	TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_MATERIAL, sizeof(MATRNAMSTS.ATTR_TYPE));
    memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_TIV_LOT_GROUP, strlen(MP_ATTR_TIV_LOT_GROUP)); 
    memcpy(MATRNAMSTS.ATTR_KEY, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
    i_mat_ver = MWIPMATDEF.MAT_VER;
    memcpy(MATRNAMSTS.ATTR_KEY + COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))," : ", 3);
    MATRNAMSTS.ATTR_KEY[COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))+1]=i_mat_ver + 48;
    DBC_select_matrnamsts(1, &MATRNAMSTS);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.set_char(in_node, "LOT_GROUP_FLAG", MATRNAMSTS.ATTR_VALUE[0]);
    }

    if(TRS.get_item_count(in_node, "CHILD_LOT_LIST") > 0 && MATRNAMSTS.ATTR_VALUE[0]=='Y')
    {
        strcpy(s_msg_code, "INV-0051");
        TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);
        TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }*/

	//From Oper 
    DBC_init_mtivoprdef(&MTIVOPRDEF_F);
    TRS.copy(MTIVOPRDEF_F.FACTORY, sizeof(MTIVOPRDEF_F.FACTORY), in_node, "FACTORY");
    TRS.copy(MTIVOPRDEF_F.OPER, sizeof(MTIVOPRDEF_F.OPER), in_node, "OPER");
    DBC_select_mtivoprdef(1, &MTIVOPRDEF_F);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MTIVOPRDEF_F SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF_F.FACTORY), MTIVOPRDEF_F.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF_F.OPER), MTIVOPRDEF_F.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	if (MTIVOPRDEF_F.OPER_CMF_3[0] == 'L')
	{
		TRS.set_char(in_node, "__FROM_LOSS_OPER_FLAG", 'Y');
	}

    //To Oper 
    DBC_init_mtivoprdef(&MTIVOPRDEF);
    TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, "TO_FACTORY");
    TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "TO_OPER");
    DBC_select_mtivoprdef(1, &MTIVOPRDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
	
	if (memcmp(MTIVOPRDEF.OPER, MTIVOPRDEF_F.OPER, sizeof(MTIVOPRDEF.OPER)) == 0)
	{
		strcpy(s_msg_code, "WIP-0728");
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;

        TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(MTIVOPRDEF_F.OPER), MTIVOPRDEF_F.OPER);
		TRS.add_fieldmsg(out_node, "TO_OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
	}

	if (COM_isnullspace(TRS.get_string(in_node, "MVT_CODE")) == MP_TRUE)
	{
		if (memcmp(MTIVOPRDEF.OPER_CMF_2, MP_TIV_OPER_CMF_2_OSC, strlen(MP_TIV_OPER_CMF_2_OSC)) == 0)
		{
			TRS.add_string(in_node, "MVT_CODE", MP_TIV_ERP_MVT_541, strlen(MP_TIV_ERP_MVT_541));
			TRS.add_string(in_node, "VENDOR_CODE", MTIVOPRDEF.OPER_CMF_6, sizeof(MTIVOPRDEF.OPER_CMF_6));
		}
		else if (memcmp(MTIVOPRDEF_F.OPER_CMF_2, MP_TIV_OPER_CMF_2_OSC, strlen(MP_TIV_OPER_CMF_2_OSC)) == 0)
		{
			TRS.add_string(in_node, "MVT_CODE", MP_TIV_ERP_MVT_542, strlen(MP_TIV_ERP_MVT_542));
			TRS.add_string(in_node, "VENDOR_CODE", MTIVOPRDEF_F.OPER_CMF_6, sizeof(MTIVOPRDEF_F.OPER_CMF_6));
			TRS.add_char(in_node, "RETURN_FLAG", 'Y');
		}
		else
		{
			TRS.add_string(in_node, "MVT_CODE", MP_TIV_ERP_MVT_311, strlen(MP_TIV_ERP_MVT_311));
		}
	}
	
	/*memset(s_temp, ' ', sizeof(s_temp));
	memcpy(s_temp, MTIVOPRDEF_F.OPER_CMF_2, 3);
	s_temp[3]='-';
	memcpy(s_temp+4, MTIVOPRDEF.OPER_CMF_2, 3);

	TRS.set_string(in_node, "TRAN_TYPE", s_temp, sizeof(s_temp));*/

    return MP_TRUE;
}






