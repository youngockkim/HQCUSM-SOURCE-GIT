/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_Transfer_Lot.c
    Description : Transaction Lot Material Transfer function module

    MES Version : 5.2.0
	
    Function List
        - TIV_Ship_Lot()
            + Transaction Raw Material Transfer
        - TIV_SHIP_LOT()
            + Main Sub function of "TIV_Ship_Lot"
            + (called by "TIV_Ship_Lot")
        - TIV_Ship_Lot_Validation()
            + Validation Check sub function of "TIV_SHIP_LOT" function
            + (called by "TIV_SHIP_LOT")
       
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


int TIV_Ship_Lot_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node);


/*******************************************************************************
    TIV_Ship_Lot()
        - Raw Material Transfer
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TIV_Ship_Lot_In_Tag *TIV_Ship_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Ship_Lot(TRSNode *in_node, 
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_SHIP_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_SHIP_LOT", out_node);

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

int TIV_SHIP_LOT(char *s_msg_code,
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
	struct  MTIVSHPLOT_TAG  MTIVSHPLOT;

	struct MTIVFACSHP_TAG MTIVFACSHP;

	//char	s_oper_temp[10];

	//struct CPLNMIMDEF_TAG CPLNMIMDEF;
	
    char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];
	 
    char s_inv_lot_id[25];
    int b_lot_dup = 0;
	int i_step;
	//int iMaxProjectVer;

	int i_last_active_hist_seq;
	int	i_ship_hist_seq;


	//TRSNode * IF_node;
  
    LOG_head("TIV_SHIP_LOT");
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

	LOG_add("attr_type", MP_NSTR, TRS.get_string(in_node, "ATTR_TYPE"));
	LOG_add("attr_name", MP_NSTR, TRS.get_string(in_node, "ATTR_NAME"));
	LOG_add("attr_key", MP_NSTR, TRS.get_string(in_node, "ATTR_KEY"));
	LOG_add("expire_date", MP_NSTR, TRS.get_string(in_node,"EXPIRE_DATE"));

    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Ship_Lot",
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
    if(TIV_Ship_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	DBC_init_mtivfacshp(&MTIVFACSHP);

	if(TRS.get_char(in_node,"SHIP_CANCEL_FLAG")!='Y')
	{
		
		TRS.copy(MTIVFACSHP.FACTORY_FROM, sizeof(MTIVFACSHP.FACTORY_FROM), in_node, IN_FACTORY);
		TRS.copy(MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO), in_node, "TO_FACTORY");
		TRS.copy(MTIVFACSHP.TRANSIT_OPER, sizeof(MTIVFACSHP.TRANSIT_OPER), in_node, "TO_OPER");
		DBC_select_mtivfacshp(1, &MTIVFACSHP);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0097");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}     
			TRS.add_fieldmsg(out_node, "MTIVFACSHP SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "TO FACTORY", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
			TRS.add_fieldmsg(out_node, "TRANSIT OPER", MP_STR, sizeof(MTIVFACSHP.TRANSIT_OPER), MTIVFACSHP.TRANSIT_OPER);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
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

	i_ship_hist_seq = MTIVLOTSTS_FROM.LAST_ACTIVE_HIST_SEQ;

    //To Status & History
    DBC_init_mtivlotsts(&MTIVLOTSTS_TO);
    TRS.copy(MTIVLOTSTS_TO.FACTORY, sizeof(MTIVLOTSTS_TO.FACTORY), in_node, "TO_FACTORY");    
    TRS.copy(MTIVLOTSTS_TO.LOT_ID, sizeof(MTIVLOTSTS_TO.LOT_ID), in_node, "LOT_ID");
	//TRS.copy(MTIVLOTSTS_TO.OPER, sizeof(MTIVLOTSTS_TO.OPER), in_node, "TO_OPER");
    DBC_select_mtivlotsts_for_update(4, &MTIVLOTSTS_TO);
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
 
	/*if (TRS.get_char(in_node,"SHIP_CANCEL_FLAG") !='Y' && b_lot_dup == MP_TRUE)
	{
		strcpy(s_msg_code, "WIP-0760");
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
	}*/

	if (b_lot_dup == MP_TRUE &&
		memcmp(MTIVLOTSTS_FROM.INV_CMF_21, MTIVLOTSTS_TO.INV_CMF_21, sizeof(MTIVLOTSTS_FROM.INV_CMF_21)) != 0)
	{
		strcpy(s_msg_code, "WIP-0760");
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "TO_FACTORY", MP_STR, sizeof(MTIVLOTSTS_TO.FACTORY), MTIVLOTSTS_TO.FACTORY);
        TRS.add_fieldmsg(out_node, "TO_OPER", MP_STR, sizeof(MTIVLOTSTS_TO.OPER), MTIVLOTSTS_TO.OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_TO.LOT_ID), MTIVLOTSTS_TO.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
	memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS_FROM, sizeof(MTIVLOTSTS_FROM));

	MTIVLOTSTS_FROM.QTY_1 = 0;
    MTIVLOTSTS_FROM.QTY_2 = 0;
    MTIVLOTSTS_FROM.QTY_3 = 0;
	memcpy(MTIVLOTSTS_FROM.LAST_TRAN_CODE, MP_TIV_TRAN_CODE_SHIP, strlen(MP_TIV_TRAN_CODE_SHIP));
    TRS.copy(MTIVLOTSTS_FROM.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_FROM.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
	memcpy(MTIVLOTSTS_FROM.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS_FROM.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");  
	 
	memcpy(MTIVLOTSTS_FROM.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	i_step = 10;
	i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS_FROM);
	i_last_active_hist_seq++;

	MTIVLOTSTS_FROM.LAST_HIST_SEQ = i_last_active_hist_seq;
	MTIVLOTSTS_FROM.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_FROM.LAST_HIST_SEQ;
	MTIVLOTSTS_FROM.IN_OUT_FLAG = 'O';

	if(MTIVLOTSTS_FROM.QTY_1 < 0.0005 && MTIVLOTSTS_FROM.QTY_2 < 0.0005)
	{
		if(TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT") != 'Y')
		{
			MTIVLOTSTS_FROM.LOT_DEL_FLAG = 'Y';
			TRS.copy(MTIVLOTSTS_FROM.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS_FROM.LOT_DEL_USER_ID), in_node, "PRC_USER");
			memcpy(MTIVLOTSTS_FROM.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS_FROM.LOT_DEL_TIME));
			memcpy(MTIVLOTSTS_FROM.LOT_DEL_REASON, MP_WIP_AUTO_TERMINATE_CODE, strlen(MP_WIP_AUTO_TERMINATE_CODE));
		}
	}  
	 
	TRS.copy(MTIVLOTSTS_FROM.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS_FROM.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS_FROM.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS_FROM.LAST_TRAN_USER_ID), in_node, "PRC_USER");

	TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U'); 
	
	if (TRS.get_char(in_node,"SHIP_CANCEL_FLAG")!='Y')
	{
		if (TRS.get_char(in_node, "IN_STOCK_FLAG") == 'Y')
		{
			//memcpy(MTIVLOTSTS.INV_CMF_1, s_tran_time, sizeof(s_tran_time));
			memcpy(MTIVLOTSTS_TO.INV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.INV_IN_TIME));
			TRS.copy(MTIVLOTSTS_TO.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS_TO.ERP_INV_IN_DATE), in_node, "WORK_DATE");
		}
		else
		{
			memset(MTIVLOTSTS_TO.INV_IN_TIME, ' ' , sizeof(MTIVLOTSTS_TO.INV_IN_TIME));
			memset(MTIVLOTSTS_TO.ERP_INV_IN_DATE, ' ' , sizeof(MTIVLOTSTS_TO.ERP_INV_IN_DATE));
		}
	}
	
	memset(MTIVLOTSTS_TO.INV_CMF_8, ' ' , sizeof(MTIVLOTSTS_TO.INV_CMF_8));
	memset(MTIVLOTSTS_TO.INV_CMF_9, ' ' , sizeof(MTIVLOTSTS_TO.INV_CMF_9));


	DBC_init_mtivlothis(&MTIVLOTHIS);

	TRS.set_char(in_node, "__SKIP_HIST_GEN", 'N');

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
    }

	/*DBC_delete_mtivlotsts(4, &MTIVLOTSTS_FROM);
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
	}*/
 
    if(b_lot_dup==MP_TRUE)//Target Lot이 존재할때
    {
		DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
		memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS_TO, sizeof(MTIVLOTSTS_TO));


		memcpy(MTIVLOTSTS_OLD.FACTORY, MTIVLOTSTS_FROM.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY));
		memcpy(MTIVLOTSTS_OLD.OPER, MTIVLOTSTS_FROM.OPER, sizeof(MTIVLOTSTS_OLD.OPER));

		memcpy(MTIVLOTSTS_TO.ADD_ORDER_ID_1, MTIVLOTSTS_FROM.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_ID_1));
		memcpy(MTIVLOTSTS_TO.ADD_ORDER_ID_2, MTIVLOTSTS_FROM.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_ID_2));
		memcpy(MTIVLOTSTS_TO.ADD_ORDER_ID_3, MTIVLOTSTS_FROM.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_ID_3));
		memcpy(MTIVLOTSTS_TO.ADD_ORDER_LINE_1, MTIVLOTSTS_FROM.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_LINE_1));
		memcpy(MTIVLOTSTS_TO.ADD_ORDER_LINE_2, MTIVLOTSTS_FROM.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_LINE_2));
		memcpy(MTIVLOTSTS_TO.ADD_ORDER_LINE_3, MTIVLOTSTS_FROM.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_LINE_3));

        MTIVLOTSTS_TO.QTY_1 = MTIVLOTSTS_TO.QTY_1 + TRS.get_double(in_node, "MOVE_QTY_1");
        MTIVLOTSTS_TO.QTY_2 = MTIVLOTSTS_TO.QTY_2 + TRS.get_double(in_node, "MOVE_QTY_2");
        MTIVLOTSTS_TO.QTY_3 = MTIVLOTSTS_TO.QTY_3 + TRS.get_double(in_node, "MOVE_QTY_3");
		 
		TRS.copy(MTIVLOTSTS_TO.OPER,  sizeof(MTIVLOTSTS_TO.OPER), in_node, "TO_OPER");

		if(MTIVFACSHP.AUTO_TERM_FLAG == 'Y')
		{
			MTIVLOTSTS_TO.LOT_DEL_FLAG = 'Y';
			memcpy(MTIVLOTSTS_TO.LOT_DEL_REASON, MP_WIP_AUTO_TERMINATE_CODE, sizeof(MTIVLOTSTS_TO.LOT_DEL_REASON));
			memcpy(MTIVLOTSTS_TO.LOT_DEL_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LOT_DEL_TIME));
			TRS.copy(MTIVLOTSTS_TO.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS_TO.LOT_DEL_USER_ID), in_node, "PRC_USER");
		}
		else
		{		
			MTIVLOTSTS_TO.LOT_DEL_FLAG = ' ';
			memset(MTIVLOTSTS_TO.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_USER_ID));
			memset(MTIVLOTSTS_TO.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_TIME));
			memset(MTIVLOTSTS_TO.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_REASON));			
		}

		memset(MTIVLOTSTS_TO.INV_CMF_7, ' ', sizeof(MTIVLOTSTS_TO.INV_CMF_7));

		memcpy(MTIVLOTSTS_TO.LAST_TRAN_CODE, MP_TIV_TRAN_CODE_SHIP, strlen(MP_TIV_TRAN_CODE_SHIP));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
		memcpy(MTIVLOTSTS_TO.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LAST_TRAN_TIME));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");
		memcpy(MTIVLOTSTS_TO.OINV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.OINV_IN_TIME));
		TRS.copy(MTIVLOTSTS_TO.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS_TO.ERP_OINV_IN_DATE), in_node, "WORK_DATE");

		TRS.copy(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS_TO.LAST_TRAN_USER_ID), in_node, "PRC_USER");


		memcpy(MTIVLOTSTS_TO.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

		MTIVLOTSTS_TO.IN_OUT_FLAG = 'I';
		i_last_active_hist_seq++;
		MTIVLOTSTS_TO.LAST_HIST_SEQ = i_last_active_hist_seq;
        //MTIVLOTSTS.LAST_HIST_SEQ ++;
        MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_TO.LAST_HIST_SEQ;



    }
    else//Target Lot이 존재하지 않을때 - B의 수량은 이동수량만
    {
		MTIVLOTSTS_OLD.QTY_1 = MTIVLOTSTS_FROM.QTY_1;
		MTIVLOTSTS_OLD.QTY_2 = MTIVLOTSTS_FROM.QTY_2;
		MTIVLOTSTS_OLD.QTY_3 = MTIVLOTSTS_FROM.QTY_3;
		memset(MTIVLOTSTS_OLD.LOCATION_NO, ' ', sizeof(MTIVLOTSTS_OLD.LOCATION_NO));

		memcpy(MTIVLOTSTS_OLD.ADD_ORDER_ID_1, MTIVLOTSTS_FROM.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_ID_1));
		memcpy(MTIVLOTSTS_OLD.ADD_ORDER_ID_2, MTIVLOTSTS_FROM.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_ID_2));
		memcpy(MTIVLOTSTS_OLD.ADD_ORDER_ID_3, MTIVLOTSTS_FROM.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_ID_3));
		memcpy(MTIVLOTSTS_OLD.ADD_ORDER_LINE_1, MTIVLOTSTS_FROM.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_LINE_1));
		memcpy(MTIVLOTSTS_OLD.ADD_ORDER_LINE_2, MTIVLOTSTS_FROM.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_LINE_2));
		memcpy(MTIVLOTSTS_OLD.ADD_ORDER_LINE_3, MTIVLOTSTS_FROM.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS_OLD.ADD_ORDER_LINE_3));

        memcpy(&MTIVLOTSTS_TO, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS_TO));

		if (COM_isnullspace(TRS.get_string(in_node, "OWNER_CODE")) == MP_FALSE)
		{
			TRS.copy(MTIVLOTSTS_TO.OWNER_CODE, sizeof(MTIVLOTSTS_TO.OWNER_CODE), in_node, "OWNER_CODE");    
		}

		TRS.copy(MTIVLOTSTS_TO.FACTORY, sizeof(MTIVLOTSTS_TO.FACTORY), in_node, "TO_FACTORY");    
	    TRS.copy(MTIVLOTSTS_TO.OPER,  sizeof(MTIVLOTSTS_TO.OPER), in_node, "TO_OPER");
	    TRS.copy(MTIVLOTSTS_TO.LOCATION_NO,  sizeof(MTIVLOTSTS_TO.LOCATION_NO), in_node, "TO_LOCATION_NO");

		TRS.copy(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS_TO.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS_TO.LAST_TRAN_USER_ID), in_node, "PRC_USER");

		memset(MTIVLOTSTS_TO.INV_CMF_7, ' ', sizeof(MTIVLOTSTS_TO.INV_CMF_7));
		 

		MTIVLOTSTS_TO.QTY_1 = TRS.get_double(in_node, "MOVE_QTY_1");
        MTIVLOTSTS_TO.QTY_2 = TRS.get_double(in_node, "MOVE_QTY_2");
        MTIVLOTSTS_TO.QTY_3 = TRS.get_double(in_node, "MOVE_QTY_3");

        memcpy(MTIVLOTSTS_TO.LAST_TRAN_CODE, MP_TIV_TRAN_CODE_SHIP, strlen(MP_TIV_TRAN_CODE_SHIP));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
        memcpy(MTIVLOTSTS_TO.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LAST_TRAN_TIME));
        TRS.copy(MTIVLOTSTS_TO.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS_TO.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");    
		memcpy(MTIVLOTSTS_TO.OINV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.OINV_IN_TIME));
		TRS.copy(MTIVLOTSTS_TO.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS_TO.ERP_OINV_IN_DATE), in_node, "WORK_DATE");

		memcpy(MTIVLOTSTS_TO.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

        memset(MTIVLOTSTS_TO.FROM_TO_LOT_ID, ' ', sizeof(MTIVLOTSTS_TO.FROM_TO_LOT_ID));
		MTIVLOTSTS_TO.FROM_TO_HIST_SEQ = 0;
        MTIVLOTSTS_TO.FROM_TO_FLAG = ' ';

		if(MTIVFACSHP.AUTO_TERM_FLAG == 'Y')
		{
			MTIVLOTSTS_TO.LOT_DEL_FLAG = 'Y';
			memcpy(MTIVLOTSTS_TO.LOT_DEL_REASON, MP_WIP_AUTO_TERMINATE_CODE, sizeof(MTIVLOTSTS_TO.LOT_DEL_REASON));
			memcpy(MTIVLOTSTS_TO.LOT_DEL_TIME, s_tran_time, sizeof(MTIVLOTSTS_TO.LOT_DEL_TIME));
			TRS.copy(MTIVLOTSTS_TO.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS_TO.LOT_DEL_USER_ID), in_node, "PRC_USER");
		}
		else
		{
			MTIVLOTSTS_TO.LOT_DEL_FLAG = ' ';
			memset(MTIVLOTSTS_TO.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_USER_ID));
			memset(MTIVLOTSTS_TO.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_TIME));
			memset(MTIVLOTSTS_TO.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS_TO.LOT_DEL_REASON));
		}

        MTIVLOTSTS_TO.IN_OUT_FLAG = 'I';
        if(COM_isnullspace(TRS.get_string(in_node, "ORDER_ID")) == MP_FALSE)
        {
            TRS.copy(MTIVLOTSTS_TO.ORDER_ID, sizeof(MTIVLOTSTS_TO.ORDER_ID), in_node, "ORDER_ID");
        }

		i_last_active_hist_seq++;
		MTIVLOTSTS_TO.LAST_HIST_SEQ = i_last_active_hist_seq;
        //MTIVLOTSTS.LAST_HIST_SEQ ++;
        MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_TO.LAST_HIST_SEQ;
        //TRS.copy(MTIVLOTSTS_TO.INV_CMF_1, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_1");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_2, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_2");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_3, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_3");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_4, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_4");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_5, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_5");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_6, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_6");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_7, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_7");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_8, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_8");
        TRS.copy(MTIVLOTSTS_TO.INV_CMF_9, sizeof(MTIVLOTSTS_TO.INV_CMF_1), in_node, "INV_CMF_9");
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
	    TRS.copy(MTIVLOTSTS_TO.EXPIRE_DATE, sizeof(MTIVLOTSTS_TO.EXPIRE_DATE), in_node, "EXPIRE_DATE");
    }

	if (TRS.get_char(in_node, "CUST_RETURN_FLAG") == 'Y')
	{
		TRS.copy(MTIVLOTSTS_TO.OWNER_CODE, sizeof(MTIVLOTSTS_TO.OWNER_CODE), in_node, "OWNER_CODE");
	}

	if (b_lot_dup==MP_TRUE)//Lot이 존재할때
		TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U');            
    else
        TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'I');    

	TRS.set_char(in_node, "__SHIP_FLAG", 'Y'); 

    DBC_init_mtivlothis(&MTIVLOTHIS);
  
	TRS.set_char(in_node, "__SKIP_HIST_GEN", 'N');
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
	 
	if (TRS.get_char(in_node, "SHIP_WITHOUT_PO_FLAG") == 'Y' &&
		TRS.get_char(in_node, "SKIP_IF_INFO_FLAG") != 'Y')
	{
		//IF_node = TRS.create_node("INTERFACE_IN");
		//TRS.add_char(IF_node, IN_PROCSTEP, '1');
		//TRS.add_enc_nstring(IF_node, IN_USERID, TRS.get_userid(in_node));
		//TRS.add_char(IF_node, IN_LANGUAGE, TRS.get_language(in_node));
		//TRS.add_nstring(IF_node, IN_FACTORY, TRS.get_factory(in_node));
		//			
		//TRS.add_nstring(IF_node, "WERKS", TRS.get_factory(in_node));
		////TRS.add_nstring(IF_node, "WERKS1", TRS.get_factory(in_node));
		//TRS.add_nstring(IF_node, "BUDAT", TRS.get_string(in_node, "WORK_DATE"));				 
		////TRS.add_nstring(IF_node, "AUFNR", TRS.get_string(in_node, "ORDER_ID"));	
		//TRS.add_nstring(IF_node, "BWART", TRS.get_string(in_node, "MVT_CODE"));
	
		//TRS.add_string(IF_node, "MATNR", MTIVLOTSTS_TO.MAT_ID, sizeof(MTIVLOTSTS_TO.MAT_ID));
		////TRS.add_string(IF_node, "MATNR1", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));

		//TRS.add_string(IF_node, "LGORT", MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER));
		//TRS.add_string(IF_node, "LGORT1", MTIVLOTSTS_TO.OPER, sizeof(MTIVLOTSTS_TO.OPER));
		////i_last_if_seq++; ?????
		////TRS.add_int(IF_node, "SEQNO", i_last_if_seq);
	 //
		///*if (TRS.get_char(in_node, "MVT_PM") == 'P')
		//	TRS.add_double(IF_node, "MENGE", d_total_cv_qty_1);
		//else
		//	TRS.add_double(IF_node, "MENGE", -1 * d_total_cv_qty_1);*/
		//TRS.add_double(IF_node, "MENGE", d_total_cv_qty_1);
		//TRS.add_string(IF_node, "ERNAM", "MES", strlen("MES"));
		//TRS.add_string(IF_node, "ERDAT", s_sys_time, 8);
		//TRS.add_string(IF_node, "ERZET", s_sys_time + 8, 6);
		//		
		//TRS.add_string(IF_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));

		//TRS.add_string(IF_node, "MEINS", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
		//TRS.add_string(IF_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		//TRS.add_int(IF_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

		//if (CUS_MES_To_ERP_Move(s_msg_code, IF_node, out_node) == MP_FALSE)
		//{
		//	TRS.free_node(IF_node);
		//	return MP_FALSE;
		//}
		//TRS.free_node(IF_node);


	}

	if (TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG") == 'Y')
	{		
//		memset(s_oper_temp, ' ', sizeof(s_oper_temp));
//		TRS.copy(s_oper_temp, sizeof(s_oper_temp), in_node, "OPER");
//
//		/*TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
//		TRS.set_string(in_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));*/
//		
//		TRS.set_nstring(in_node, "EXT_FACTORY", TRS.get_string(in_node, "FROM_OPER"));
//		TRS.set_nstring(in_node, "OPER", TRS.get_string(in_node, "FROM_OPER"));
//
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
//		/*memset(s_oper_temp, ' ', sizeof(s_oper_temp));
//		TRS.copy(s_oper_temp, sizeof(s_oper_temp), in_node, "OPER");
//*/
//		/*TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
//		TRS.set_string(in_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));*/
//		TRS.set_nstring(in_node, "EXT_FACTORY", TRS.get_string(in_node, "TO_FACTORY"));
//		TRS.set_nstring(in_node, "OPER", TRS.get_string(in_node, "TO_OPER"));
//		TRS.set_char(in_node, "IN_OUT_FLAG", 'I');
//		TRS.set_double(in_node, "ADJUST_QTY_1",  TRS.get_double(in_node, "MOVE_QTY_1"));
//		TRS.set_int(in_node, "HIST_SEQ", MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ);
//		if (TIV_Create_Inventory_Adjust_Info(s_msg_code, in_node, out_node) == MP_FALSE)
//		{
//			return MP_FALSE;
//		}
//
		//TRS.set_string(in_node, "OPER", s_oper_temp, sizeof(s_oper_temp));
	}
	
	if (TRS.get_char(in_node, "CUST_RETURN_FLAG") != 'Y')
	{
		if (TRS.get_char(in_node, "SHIP_CANCEL_FLAG") == 'Y')
		{
			DBC_init_mtivshplot(&MTIVSHPLOT);
			memcpy(MTIVSHPLOT.FACTORY, MTIVLOTSTS_TO.FACTORY, sizeof(MTIVSHPLOT.FACTORY));
			memcpy(MTIVSHPLOT.LOT_ID, MTIVLOTSTS_TO.LOT_ID, sizeof(MTIVSHPLOT.LOT_ID));
			MTIVSHPLOT.HIST_SEQ = i_ship_hist_seq;

			MTIVSHPLOT.HIST_DEL_FLAG = 'Y';
			memcpy(MTIVSHPLOT.HIST_DEL_TIME, s_tran_time, sizeof(MTIVSHPLOT.HIST_DEL_TIME));
			TRS.copy(MTIVSHPLOT.HIST_DEL_USER_ID, sizeof(MTIVSHPLOT.HIST_DEL_USER_ID), in_node, "PRC_USER");
		 
			i_step = 2;
			DBC_update_mtivshplot(i_step, &MTIVSHPLOT);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				 
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "MTIVSHPLOT UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVSHPLOT.FACTORY), MTIVSHPLOT.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVSHPLOT.LOT_ID), MTIVSHPLOT.LOT_ID);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}    
			}

		}
		else
		{
			DBC_init_mtivshplot(&MTIVSHPLOT);
			memcpy(MTIVSHPLOT.FACTORY, MTIVLOTSTS_FROM.FACTORY, sizeof(MTIVSHPLOT.FACTORY));
			memcpy(MTIVSHPLOT.LOT_ID, MTIVLOTSTS_FROM.LOT_ID, sizeof(MTIVSHPLOT.LOT_ID));
			memcpy(MTIVSHPLOT.OPER, MTIVLOTSTS_FROM.OPER, sizeof(MTIVSHPLOT.OPER));
			memcpy(MTIVSHPLOT.MAT_ID, MTIVLOTSTS_FROM.MAT_ID, sizeof(MTIVSHPLOT.MAT_ID));
			MTIVSHPLOT.MAT_VER = MTIVLOTSTS_FROM.MAT_VER;

			MTIVSHPLOT.HIST_SEQ = MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ;
			MTIVSHPLOT.SHIP_QTY_1 = MTIVLOTSTS_TO.QTY_1;
			MTIVSHPLOT.SHIP_QTY_2 = MTIVLOTSTS_TO.QTY_2;
			MTIVSHPLOT.SHIP_QTY_3 = MTIVLOTSTS_TO.QTY_3;
     
			memcpy(MTIVSHPLOT.TO_FACTORY, MTIVLOTSTS_TO.FACTORY, sizeof(MTIVSHPLOT.TO_FACTORY));
			memcpy(MTIVSHPLOT.TO_OPER, MTIVLOTSTS_TO.OPER, sizeof(MTIVSHPLOT.TO_OPER));

			if (memcmp(MTIVFACSHP.FACTORY_TO, MP_TIV_CUSTOMER_FACTORY, strlen(MP_TIV_CUSTOMER_FACTORY)) == 0)
			{
				MTIVSHPLOT.SHIP_TYPE = MP_TIV_SHIP_TYPE_CUSTOMER;
			}
			else
			{
				MTIVSHPLOT.SHIP_TYPE = MP_TIV_SHIP_TYPE_INTERNAL;
			}

			TRS.copy(MTIVSHPLOT.CUSTOMER_CODE, sizeof(MTIVSHPLOT.CUSTOMER_CODE), in_node, "CUSTOMER_CODE");
			TRS.copy(MTIVSHPLOT.NOTE_ID, sizeof(MTIVSHPLOT.NOTE_ID), in_node, "NOTE_ID");
			TRS.copy(MTIVSHPLOT.NOTE_ITEM, sizeof(MTIVSHPLOT.NOTE_ITEM), in_node, "NOTE_ITEM");
			TRS.copy(MTIVSHPLOT.INVOICE_NO, sizeof(MTIVSHPLOT.INVOICE_NO), in_node, "INVOICE_NO");
			TRS.copy(MTIVSHPLOT.PO_NO, sizeof(MTIVSHPLOT.PO_NO), in_node, "PO_NO");
			TRS.copy(MTIVSHPLOT.WORK_DATE, sizeof(MTIVSHPLOT.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(MTIVSHPLOT.SHIFT, sizeof(MTIVSHPLOT.SHIFT), in_node, "SHIFT");

			memcpy(MTIVSHPLOT.TRAN_TIME, s_tran_time, sizeof(MTIVSHPLOT.TRAN_TIME));
			memcpy(MTIVSHPLOT.SYS_TRAN_TIME, s_sys_time, sizeof(MTIVSHPLOT.SYS_TRAN_TIME));
	 
			TRS.copy(MTIVSHPLOT.TRAN_USER_ID, sizeof(MTIVSHPLOT.TRAN_USER_ID), in_node, "PRC_USER");

			MTIVSHPLOT.AUTO_TERM_FLAG = MTIVFACSHP.AUTO_TERM_FLAG;
   
			TRS.copy(MTIVSHPLOT.SHP_CMF_1, sizeof(MTIVSHPLOT.SHP_CMF_1), in_node, "EXPORT_TYPE");
			TRS.copy(MTIVSHPLOT.SHP_CMF_2, sizeof(MTIVSHPLOT.SHP_CMF_2), in_node, "SHP_CMF_2");
			TRS.copy(MTIVSHPLOT.SHP_CMF_3, sizeof(MTIVSHPLOT.SHP_CMF_3), in_node, "SHP_CMF_3");
			TRS.copy(MTIVSHPLOT.SHP_CMF_4, sizeof(MTIVSHPLOT.SHP_CMF_4), in_node, "SHP_CMF_4");
			TRS.copy(MTIVSHPLOT.SHP_CMF_5, sizeof(MTIVSHPLOT.SHP_CMF_5), in_node, "SHP_CMF_5");
			TRS.copy(MTIVSHPLOT.SHP_CMF_6, sizeof(MTIVSHPLOT.SHP_CMF_6), in_node, "SHP_CMF_6");
			TRS.copy(MTIVSHPLOT.SHP_CMF_7, sizeof(MTIVSHPLOT.SHP_CMF_7), in_node, "SHP_CMF_7");
			TRS.copy(MTIVSHPLOT.SHP_CMF_8, sizeof(MTIVSHPLOT.SHP_CMF_8), in_node, "SHP_CMF_8");
			TRS.copy(MTIVSHPLOT.SHP_CMF_9, sizeof(MTIVSHPLOT.SHP_CMF_9), in_node, "SHP_CMF_9");
			TRS.copy(MTIVSHPLOT.SHP_CMF_10, sizeof(MTIVSHPLOT.SHP_CMF_10), in_node, "SHP_CMF_10");
 
			DBC_insert_mtivshplot(&MTIVSHPLOT);        
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVSHPLOT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVSHPLOT.FACTORY), MTIVSHPLOT.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVSHPLOT.LOT_ID), MTIVSHPLOT.LOT_ID);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVSHPLOT.HIST_SEQ);
            
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

	}
	 

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Ship_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}



/*******************************************************************************
    TIV_Ship_Lot_Validation()
        - Validation Check sub function of "TIV_Ship_Lot" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_Ship_Lot_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Ship_Lot_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    //struct MTIVMATDEF_TAG MTIVMATDEF;    
	struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MATRNAMSTS_TAG MATRNAMSTS;
	struct MTIVOPRDEF_TAG MTIVOPRDEF_F;
	struct MWIPMATDEF_TAG MWIPMATDEF;

    //int i_mat_ver = 0;
	char s_temp[10];

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

	
    /*if(COM_isnullspace(TRS.get_string(in_node, "TO_OPER")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TO_OPER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }*/

    if(COM_isnullspace(TRS.get_string(in_node, "TRAN_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TRAN_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

  /*  if ((TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_MAT_TRN, strlen(MP_INV_TRAN_TYPE_MAT_TRN)) != 0) &&
        (TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_SPE_TRN, strlen(MP_INV_TRAN_TYPE_SPE_TRN)) != 0) &&
        (TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_WIP_TRN, strlen(MP_INV_TRAN_TYPE_WIP_TRN)) != 0) &&
		(TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_RJT_TRN, strlen(MP_INV_TRAN_TYPE_RJT_TRN)) != 0) &&
        (TRS.mem_cmp(in_node, "TRAN_TYPE", MP_INV_TRAN_TYPE_RET_TRN, strlen(MP_INV_TRAN_TYPE_RET_TRN)) != 0) &&
		(TRS.mem_cmp(in_node, "TRAN_TYPE", MP_TIV_TRAN_TYPE_DLLH, strlen(MP_TIV_TRAN_TYPE_DLLH)) != 0)
		)    
    {
        strcpy(s_msg_code, "INV-0004");
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        TRS.add_fieldmsg(out_node, "TRAN_TYPE", MP_STR, sizeof(TRS.get_string(in_node, "TRAN_TYPE")), TRS.get_string(in_node, "IN_TYPE"));
            
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        
        return MP_FALSE;
    }*/
  /*  if(TRS.get_item_count(in_node, "CHILD_LOT_LIST") > 1)
    {
        strcpy(s_msg_code, "INV-0234");
        TRS.add_fieldmsg(out_node, "CHILD_LOT_LIST", MP_NVST);
        TRS.add_fieldmsg(out_node, "ITEM COUNT", MP_INT, TRS.get_item_count(in_node, "CHILD_LOT_LIST"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
*/
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
	
	// CUSTOMER 일 경우 TO_FACTORY로 변경
	if(memcmp(MTIVLOTSTS.FACTORY,"CUSTOMER",strlen("CUSTOMER")) ==0)
	{
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, "TO_FACTORY");		
	}
	else 
	{
		memcpy(MWIPMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
	}
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
	 
	//To Oper 
	if(COM_isnullspace(TRS.get_string(in_node, "TO_OPER")) == MP_FALSE)
	{		 
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
	}

	// CUSTOMER 일 경우OPER 체크하지 않는다.
	if(memcmp(MTIVLOTSTS.FACTORY,"CUSTOMER",strlen("CUSTOMER")) !=0)
	{
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

		//if (MTIVOPRDEF_F.SHIP_FLAG != 'Y')
		//{




		//}

		memset(s_temp, ' ', sizeof(s_temp));
		memcpy(s_temp, MTIVOPRDEF_F.OPER_CMF_2, 3);
		s_temp[3]='-';
		if (COM_isnullspace(MTIVOPRDEF.OPER_CMF_2) == MP_FALSE)
		{
			memcpy(s_temp+4, MTIVOPRDEF.OPER_CMF_2, 3);
		}
		else
		{
			memcpy(s_temp+4, "CUS", 3);
		}
	
		TRS.set_string(in_node, "TRAN_TYPE", s_temp, sizeof(s_temp));
	}

    return MP_TRUE;
}






