	/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot.c
    Description : View Inventory Lot Information related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Lot_Ext()
            + View Inventory Lot Information
        - TIV_VIEW_LOT_EXT()
            + Main Sub function of "TIV_View_Lot_Ext"
            + (called by "TIV_View_Lot_Ext")  
        - TIV_View_Lot_Ext_Validation()
            + Validation Check sub function of "TIV_VIEW_LOT_EXT" function
            + (called by "TIV_VIEW_LOT_EXT")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/24  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"
#include "CUS_common.h"

int TIV_View_Lot_Ext_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


/*******************************************************************************
    TIV_View_Lot_Ext()
        - View Inventory Lot Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_Ext(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT_EXT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT_EXT", out_node);

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
    TIV_VIEW_LOT_EXT()
        - Main sub function of "TIV_View_Lot_Ext" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT_EXT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
//#if 0
    
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
	struct MTIVLOTSTS_TAG MTIVLOTSTS_SUB;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEFX;
    //struct MTIVTRSDTL_TAG MTIVTRSDTL;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
	//struct MTIVTRSMST_TAG MTIVTRSMST;
	//struct CWIPDLVDTL_TAG CWIPDLVDTL;
	struct MTIVLOTHIS_TAG MTIVLOTHIS;
	struct MSECUSRDEF_TAG MSECUSRDEF;
	struct MWIPFACDEF_TAG MWIPFACDEF;
	struct MATRNAMSTS_TAG MATRNAMSTS;
	struct MTIVMATUSE_TAG MTIVMATUSE;
	 
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	// CPLNMIMDEF_TAG CPLNMIMDEF;

	//TRSNode *lot_list;
	 TRSNode *list_item;
	 
	int istep = 0;
	int i_cursor_step = 0;

	//char c_fifo_flag = ' ';
	//int i_fifo_check_days = 0;
	//int iMaxProjectVer = 0;
   //double dQty = 0;

	//char test = ' ';

	//char c_oper_check = ' ';
	 
    LOG_head("TIV_View_Lot_Ext");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_Ext",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
  
    /* Validation Check - Factory Validation */
    if(TIV_View_Lot_Ext_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
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
        gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }    


	if(TRS.get_procstep(in_node)=='1')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
		//istep = 20;
		istep = 6;
		DBC_select_mtivlotsts(istep, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
		    if(DB_error_code == DB_NOT_FOUND)
		    {
				strcpy(s_msg_code, "INV-0030");
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
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
			
		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.category = MP_LOG_CATE_VIEW;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}
	}
	 
	if (TRS.get_char(in_node, "CHECK_FACTORY_FLAG") == 'Y')
	{
		if (TRS.mem_cmp(in_node, IN_FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY)) != 0)
		{
			strcpy(s_msg_code, "WIP-0748");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "INPUT_FACTORY", MP_NSTR, TRS.get_factory(in_node));
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
			 
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	if (TRS.get_char(in_node, "CHECK_OPER_FLAG") == 'Y')
	{
		if (TRS.mem_cmp(in_node, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER)) != 0)
		{
			strcpy(s_msg_code, "WIP-0747");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "INPUT_OPER", MP_NSTR, TRS.get_string(in_node, "OPER"));
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
			 
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	if (TRS.get_char(in_node, "CHECK_DELETE_FLAG") == 'Y')
	{
		if (MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
		{
			strcpy(s_msg_code, "WIP-0076");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);			
			TRS.add_fieldmsg(out_node, "LOT_DEL_REASON", MP_STR, sizeof(MTIVLOTSTS.LOT_DEL_REASON), MTIVLOTSTS.LOT_DEL_REASON);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	if (TRS.get_char(in_node, "CHECK_HOLD_FLAG") == 'Y')
	{
		if (MTIVLOTSTS.HOLD_FLAG == 'Y')
		{
			strcpy(s_msg_code, "INV-0038");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);			
			TRS.add_fieldmsg(out_node, "HOLD_CODE", MP_STR, sizeof(MTIVLOTSTS.HOLD_CODE), MTIVLOTSTS.HOLD_CODE);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	if (TRS.get_char(in_node, "CHECK_OQC_FLAG") == 'Y')
	{
		if (MTIVLOTSTS.INSPECTION_FLAG != MP_TIV_INSP_FLAG_OQC)
		{
			strcpy(s_msg_code, "WIP-0749");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);			
			 
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if (MTIVLOTSTS.INSPECTION_RESULT != MP_TIV_INSP_RESULT_PASS)
		{
			strcpy(s_msg_code, "WIP-0750");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);			
			TRS.add_fieldmsg(out_node, "INSPECTION_RESULT", MP_CHR, MTIVLOTSTS.INSPECTION_RESULT);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	 
    TRS.add_string(out_node, "FACTORY", MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
	TRS.add_string(out_node, "FACTORY_DESC", MWIPFACDEF.FAC_DESC, sizeof(MWIPFACDEF.FAC_DESC));

	TRS.add_string(out_node, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
	TRS.add_string(out_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	TRS.add_string(out_node, "LOT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));    
	TRS.add_string(out_node, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	TRS.add_int(out_node, "MAT_VER", MTIVLOTSTS.MAT_VER);
	TRS.add_char(out_node, "LOT_TYPE", MTIVLOTSTS.LOT_TYPE);
	TRS.add_double(out_node, "QTY_1", MTIVLOTSTS.QTY_1);
	TRS.add_double(out_node, "QTY_2", MTIVLOTSTS.QTY_2);
	TRS.add_double(out_node, "QTY_3", MTIVLOTSTS.QTY_3);
	TRS.add_double(out_node, "CREATE_QTY_1", MTIVLOTSTS.CREATE_QTY_1);
	TRS.add_double(out_node, "CREATE_QTY_2", MTIVLOTSTS.CREATE_QTY_2);
	TRS.add_double(out_node, "CREATE_QTY_3", MTIVLOTSTS.CREATE_QTY_3);
	TRS.add_string(out_node, "CREATE_TIME", MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME));
	TRS.add_string(out_node, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
	TRS.add_string(out_node, "OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
	TRS.add_char(out_node, "IN_OUT_FLAG", MTIVLOTSTS.IN_OUT_FLAG);
	TRS.add_string(out_node, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
	TRS.add_string(out_node, "LINE_NO", MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO));
	TRS.add_string(out_node, "UNIT_1", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
	TRS.add_string(out_node, "UNIT_2", MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
	TRS.add_string(out_node, "UNIT_3", MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));
	TRS.add_char(out_node, "INSPECTION_FLAG", MTIVLOTSTS.INSPECTION_FLAG);
	TRS.add_char(out_node, "INSPECTION_RESULT", MTIVLOTSTS.INSPECTION_RESULT);
	TRS.add_string(out_node, "LAST_TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
	TRS.add_string(out_node, "LAST_TRAN_TYPE", MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));
	TRS.add_string(out_node, "LAST_TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
	TRS.add_int(out_node, "LAST_HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);
	TRS.add_int(out_node, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
	TRS.add_string(out_node, "LAST_COMMENT", MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT));
	TRS.add_char(out_node, "LOT_DEL_FLAG", MTIVLOTSTS.LOT_DEL_FLAG);
	TRS.add_enc_string(out_node, "LOT_DEL_USER_ID", MTIVLOTSTS.LOT_DEL_USER_ID, sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
	TRS.add_string(out_node, "LOT_DEL_TIME", MTIVLOTSTS.LOT_DEL_TIME, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
	TRS.add_string(out_node, "LOT_DEL_REASON", MTIVLOTSTS.LOT_DEL_REASON, sizeof(MTIVLOTSTS.LOT_DEL_REASON));
	TRS.add_string(out_node, "LOCATION", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));
	TRS.add_string(out_node, "LOCATION_NO", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));
	TRS.add_char(out_node, "HOLD_FLAG", MTIVLOTSTS.HOLD_FLAG);
	TRS.add_string(out_node, "HOLD_CODE", MTIVLOTSTS.HOLD_CODE, sizeof(MTIVLOTSTS.HOLD_CODE));
	TRS.add_string(out_node, "RELEASE_CODE", MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE));
	TRS.add_char(out_node, "PICK_FLAG", MTIVLOTSTS.PICK_FLAG);
	TRS.add_char(out_node, "SHIP_FLAG", MTIVLOTSTS.SHIP_FLAG);
	TRS.add_string(out_node, "TIV_GRADE", MTIVLOTSTS.GRADE, sizeof(MTIVLOTSTS.GRADE));
	TRS.add_string(out_node, "ADD_ORDER_ID_1", MTIVLOTSTS.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS.ADD_ORDER_ID_1));
	TRS.add_string(out_node, "ADD_ORDER_LINE_1", MTIVLOTSTS.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_1));
	TRS.add_string(out_node, "ADD_ORDER_ID_2", MTIVLOTSTS.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS.ADD_ORDER_ID_2));
	TRS.add_string(out_node, "ADD_ORDER_LINE_2", MTIVLOTSTS.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_2));
	TRS.add_string(out_node, "ADD_ORDER_ID_3", MTIVLOTSTS.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS.ADD_ORDER_ID_3));
	TRS.add_string(out_node, "ADD_ORDER_LINE_3", MTIVLOTSTS.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_3));
	TRS.add_string(out_node, "VENDOR", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
	TRS.add_string(out_node, "PO_MAT_ID", MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID));
	TRS.add_int(out_node, "PO_SEQ_NUM", MTIVLOTSTS.PO_SEQ_NUM);
	 
	TRS.add_string(out_node, "LOT_CREATE_TIME", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
	TRS.add_string(out_node, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
	TRS.add_string(out_node, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
	TRS.add_string(out_node, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
	TRS.add_string(out_node, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
	TRS.add_string(out_node, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
	TRS.add_string(out_node, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
	TRS.add_string(out_node, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
	TRS.add_string(out_node, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
	TRS.add_string(out_node, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
	TRS.add_string(out_node, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
	TRS.add_string(out_node, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
	TRS.add_string(out_node, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
	TRS.add_string(out_node, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
	TRS.add_string(out_node, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
	TRS.add_string(out_node, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
	TRS.add_string(out_node, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
	TRS.add_string(out_node, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
	TRS.add_string(out_node, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
	TRS.add_string(out_node, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
	TRS.add_string(out_node, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
	TRS.add_string(out_node, "TIV_OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
	TRS.add_string(out_node, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
	TRS.add_string(out_node, "VENDOR_LOT_ID", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
	TRS.add_string(out_node, "FROM_TO_LOT_ID", MTIVLOTSTS.FROM_TO_LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
	TRS.add_char(out_node, "FROM_TO_FLAG", MTIVLOTSTS.FROM_TO_FLAG);
	TRS.add_string(out_node, "LOT_GROUP_ID", MTIVLOTSTS.LOT_GROUP_ID, sizeof(MTIVLOTSTS.LOT_GROUP_ID));
	TRS.add_string(out_node, "EXPIRE_DATE", MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE));
    TRS.add_string(out_node, "INV_IN_TIME", MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME));
    TRS.add_string(out_node, "INV_OUT_TIME", MTIVLOTSTS.INV_OUT_TIME, sizeof(MTIVLOTSTS.INV_OUT_TIME));
    TRS.add_string(out_node, "OINV_IN_TIME", MTIVLOTSTS.OINV_IN_TIME, sizeof(MTIVLOTSTS.OINV_IN_TIME));
    TRS.add_string(out_node, "OINV_OUT_TIME", MTIVLOTSTS.OINV_OUT_TIME, sizeof(MTIVLOTSTS.OINV_OUT_TIME));
    TRS.add_string(out_node, "WIP_IN_TIME", MTIVLOTSTS.WIP_IN_TIME, sizeof(MTIVLOTSTS.WIP_IN_TIME));
    TRS.add_string(out_node, "WIP_OUT_TIME", MTIVLOTSTS.WIP_OUT_TIME, sizeof(MTIVLOTSTS.WIP_OUT_TIME));
    TRS.add_char(out_node, "TERM_FLAG", MTIVLOTSTS.TERM_FLAG);
    TRS.add_int(out_node, "FROM_TO_HIST_SEQ", MTIVLOTSTS.FROM_TO_HIST_SEQ);
    TRS.add_string(out_node, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
    TRS.add_string(out_node, "INV_CMF_21", MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21));
    TRS.add_string(out_node, "INV_CMF_22", MTIVLOTSTS.INV_CMF_22, sizeof(MTIVLOTSTS.INV_CMF_22));
    TRS.add_string(out_node, "INV_CMF_23", MTIVLOTSTS.INV_CMF_23, sizeof(MTIVLOTSTS.INV_CMF_23));
    TRS.add_string(out_node, "INV_CMF_24", MTIVLOTSTS.INV_CMF_24, sizeof(MTIVLOTSTS.INV_CMF_24));
    TRS.add_string(out_node, "INV_CMF_25", MTIVLOTSTS.INV_CMF_25, sizeof(MTIVLOTSTS.INV_CMF_25));
    TRS.add_string(out_node, "INV_CMF_26", MTIVLOTSTS.INV_CMF_26, sizeof(MTIVLOTSTS.INV_CMF_26));
    TRS.add_string(out_node, "INV_CMF_27", MTIVLOTSTS.INV_CMF_27, sizeof(MTIVLOTSTS.INV_CMF_27));
    TRS.add_string(out_node, "INV_CMF_28", MTIVLOTSTS.INV_CMF_28, sizeof(MTIVLOTSTS.INV_CMF_28));
    TRS.add_string(out_node, "INV_CMF_29", MTIVLOTSTS.INV_CMF_29, sizeof(MTIVLOTSTS.INV_CMF_29));
    TRS.add_string(out_node, "INV_CMF_30", MTIVLOTSTS.INV_CMF_30, sizeof(MTIVLOTSTS.INV_CMF_30));
    TRS.add_char(out_node, "INV_FLAG_1", MTIVLOTSTS.INV_FLAG_1);
    TRS.add_char(out_node, "INV_FLAG_2", MTIVLOTSTS.INV_FLAG_2);
    TRS.add_char(out_node, "INV_FLAG_3", MTIVLOTSTS.INV_FLAG_3);
    TRS.add_char(out_node, "INV_FLAG_4", MTIVLOTSTS.INV_FLAG_4);
    TRS.add_char(out_node, "INV_FLAG_5", MTIVLOTSTS.INV_FLAG_5);
    TRS.add_string(out_node, "ERP_CREATE_DATE", MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE));
    TRS.add_string(out_node, "ERP_INV_IN_DATE", MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE));
    TRS.add_string(out_node, "ERP_OINV_IN_DATE", MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE));
    TRS.add_string(out_node, "ERP_LAST_TRAN_DATE", MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE));
    TRS.add_string(out_node, "LAST_TRAN_USER_ID", MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID));

	if (MTIVLOTSTS.INSPECTION_FLAG != ' ')
	{
		DBU_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_TYPE, strlen(MP_GCM_INSP_TYPE));
		MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_FLAG;
			 
		istep = 1;
		DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{	
				
			}
			else
			{	
				strcpy(s_msg_code,"GCM-0004");			
				TRS.add_dberrmsg(out_node, DB_error_msg);	
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
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

		TRS.add_string(out_node, "INSPECTION_FLAG_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}
	else
	{
		TRS.add_string(out_node, "INSPECTION_FLAG_DESC", " ", strlen(" "));
	}

	if (MTIVLOTSTS.INSPECTION_RESULT != ' ')
	{
		DBU_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_RESULT, strlen(MP_GCM_INSP_RESULT));
		MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_RESULT;
			 
		istep = 1;
		DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{	
				
			}
			else
			{	
				strcpy(s_msg_code,"GCM-0004");			
				TRS.add_dberrmsg(out_node, DB_error_msg);	
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
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
		TRS.add_string(out_node, "INSPECTION_RESULT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}
	else
	{
		TRS.add_string(out_node, "INSPECTION_RESULT_DESC", " ", strlen(" "));
	}

	if (MTIVLOTSTS.INV_CMF_7[0] != ' ')
	{
		DBU_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_TBL_INV_LOCATION, strlen(MP_GCM_TBL_INV_LOCATION));
		memcpy(MGCMTBLDAT.KEY_1, MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		memcpy(MGCMTBLDAT.KEY_2, MTIVLOTSTS.INV_CMF_7, sizeof(MGCMTBLDAT.KEY_2));
		istep = 1;
		DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{	
				
			}
			else
			{	
				strcpy(s_msg_code,"GCM-0004");			
				TRS.add_dberrmsg(out_node, DB_error_msg);	
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
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
		TRS.add_string(out_node, "RACK_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}
	else
	{
		TRS.add_string(out_node, "RACK_DESC", " ", strlen(" "));
	}
 
	/*Get Mat Desc*/
	DBC_init_mwipmatdef(&MWIPMATDEFX);
	TRS.copy(MWIPMATDEFX.FACTORY, sizeof(MWIPMATDEFX.FACTORY), in_node, IN_FACTORY);
	memcpy(MWIPMATDEFX.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
    MWIPMATDEFX.MAT_VER = MTIVLOTSTS.MAT_VER;
	DBC_select_mwipmatdef(1, &MWIPMATDEFX);
	if(DB_error_code != DB_SUCCESS) 
	{
	    if(DB_error_code == DB_NOT_FOUND)
	    {
	        strcpy(s_msg_code, "WIP-0006");
	        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
	    }
        else
	    {
	        strcpy(s_msg_code, "WIP-0004");
	        gs_log_type.e_type = MP_LOG_E_SYSTEM;	       
	    }

	    TRS.add_dberrmsg(out_node, DB_error_msg);

        TRS.add_fieldmsg(out_node, "MWIPMATDEFX SELECT", MP_NVST);
	    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEFX.FACTORY), MWIPMATDEFX.FACTORY);
	    TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEFX.MAT_ID), MWIPMATDEFX.MAT_ID);

	    gs_log_type.type = MP_LOG_ERROR;
	    gs_log_type.category = MP_LOG_CATE_VIEW;
	    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	    return MP_FALSE;
	}

	//Material Info
	TRS.set_string(out_node, "MAT_DESC", MWIPMATDEFX.MAT_DESC, sizeof(MWIPMATDEFX.MAT_DESC));
    TRS.set_string(out_node, "MAT_TYPE", MWIPMATDEFX.MAT_TYPE, sizeof(MWIPMATDEFX.MAT_TYPE));
    TRS.set_string(out_node, "MAT_GRP_1", MWIPMATDEFX.MAT_GRP_1, sizeof(MWIPMATDEFX.MAT_GRP_1));
    TRS.set_string(out_node, "MAT_GRP_2", MWIPMATDEFX.MAT_GRP_2, sizeof(MWIPMATDEFX.MAT_GRP_2));
    TRS.set_string(out_node, "MAT_GRP_3", MWIPMATDEFX.MAT_GRP_3, sizeof(MWIPMATDEFX.MAT_GRP_3));
    TRS.set_string(out_node, "MAT_GRP_4", MWIPMATDEFX.MAT_GRP_4, sizeof(MWIPMATDEFX.MAT_GRP_4));
    TRS.set_string(out_node, "MAT_GRP_5", MWIPMATDEFX.MAT_GRP_5, sizeof(MWIPMATDEFX.MAT_GRP_5));
    TRS.set_string(out_node, "MAT_GRP_6", MWIPMATDEFX.MAT_GRP_6, sizeof(MWIPMATDEFX.MAT_GRP_6));
    TRS.set_string(out_node, "MAT_GRP_7", MWIPMATDEFX.MAT_GRP_7, sizeof(MWIPMATDEFX.MAT_GRP_7));
    TRS.set_string(out_node, "MAT_GRP_8", MWIPMATDEFX.MAT_GRP_8, sizeof(MWIPMATDEFX.MAT_GRP_8));
    TRS.set_string(out_node, "MAT_GRP_9", MWIPMATDEFX.MAT_GRP_9, sizeof(MWIPMATDEFX.MAT_GRP_9));
    TRS.set_string(out_node, "MAT_GRP_10", MWIPMATDEFX.MAT_GRP_10, sizeof(MWIPMATDEFX.MAT_GRP_10));
    TRS.set_string(out_node, "MAT_CMF_1", MWIPMATDEFX.MAT_CMF_1, sizeof(MWIPMATDEFX.MAT_CMF_1));
    TRS.set_string(out_node, "MAT_CMF_2", MWIPMATDEFX.MAT_CMF_2, sizeof(MWIPMATDEFX.MAT_CMF_2));
    TRS.set_string(out_node, "MAT_CMF_3", MWIPMATDEFX.MAT_CMF_3, sizeof(MWIPMATDEFX.MAT_CMF_3));
    TRS.set_string(out_node, "MAT_CMF_4", MWIPMATDEFX.MAT_CMF_4, sizeof(MWIPMATDEFX.MAT_CMF_4));
    TRS.set_string(out_node, "MAT_CMF_5", MWIPMATDEFX.MAT_CMF_5, sizeof(MWIPMATDEFX.MAT_CMF_5));
    TRS.set_string(out_node, "MAT_CMF_6", MWIPMATDEFX.MAT_CMF_6, sizeof(MWIPMATDEFX.MAT_CMF_6));
    TRS.set_string(out_node, "MAT_CMF_7", MWIPMATDEFX.MAT_CMF_7, sizeof(MWIPMATDEFX.MAT_CMF_7));
    TRS.set_string(out_node, "MAT_CMF_8", MWIPMATDEFX.MAT_CMF_8, sizeof(MWIPMATDEFX.MAT_CMF_8));
    TRS.set_string(out_node, "MAT_CMF_9", MWIPMATDEFX.MAT_CMF_9, sizeof(MWIPMATDEFX.MAT_CMF_9));
    TRS.set_string(out_node, "MAT_CMF_10", MWIPMATDEFX.MAT_CMF_10, sizeof(MWIPMATDEFX.MAT_CMF_10));
    TRS.set_string(out_node, "MAT_CMF_11", MWIPMATDEFX.MAT_CMF_11, sizeof(MWIPMATDEFX.MAT_CMF_11));
    TRS.set_string(out_node, "MAT_CMF_12", MWIPMATDEFX.MAT_CMF_12, sizeof(MWIPMATDEFX.MAT_CMF_12));
    TRS.set_string(out_node, "MAT_CMF_13", MWIPMATDEFX.MAT_CMF_13, sizeof(MWIPMATDEFX.MAT_CMF_13));
    TRS.set_string(out_node, "MAT_CMF_14", MWIPMATDEFX.MAT_CMF_14, sizeof(MWIPMATDEFX.MAT_CMF_14));
    TRS.set_string(out_node, "MAT_CMF_15", MWIPMATDEFX.MAT_CMF_15, sizeof(MWIPMATDEFX.MAT_CMF_15));
    TRS.set_string(out_node, "MAT_CMF_16", MWIPMATDEFX.MAT_CMF_16, sizeof(MWIPMATDEFX.MAT_CMF_16));
    TRS.set_string(out_node, "MAT_CMF_17", MWIPMATDEFX.MAT_CMF_17, sizeof(MWIPMATDEFX.MAT_CMF_17));
    TRS.set_string(out_node, "MAT_CMF_18", MWIPMATDEFX.MAT_CMF_18, sizeof(MWIPMATDEFX.MAT_CMF_18));
    TRS.set_string(out_node, "MAT_CMF_19", MWIPMATDEFX.MAT_CMF_19, sizeof(MWIPMATDEFX.MAT_CMF_19));
    TRS.set_string(out_node, "MAT_CMF_20", MWIPMATDEFX.MAT_CMF_20, sizeof(MWIPMATDEFX.MAT_CMF_20));
    TRS.set_string(out_node, "MAT_CMF_21", " ", strlen(" "));
    TRS.set_string(out_node, "MAT_CMF_22", " ", strlen(" "));
    TRS.set_string(out_node, "FIRST_FLOW", MWIPMATDEFX.FIRST_FLOW, sizeof(MWIPMATDEFX.FIRST_FLOW));
    TRS.set_int(out_node, "FIRST_FLOW_SEQ_NUM", MWIPMATDEFX.FIRST_FLOW_SEQ_NUM);
    TRS.set_string(out_node, "LAST_FLOW", MWIPMATDEFX.LAST_FLOW, sizeof(MWIPMATDEFX.LAST_FLOW));
    TRS.set_int(out_node, "LAST_FLOW_SEQ_NUM", MWIPMATDEFX.LAST_FLOW_SEQ_NUM);
    TRS.set_string(out_node, "MFG_DEVISION", MWIPMATDEFX.MFG_DEVISION, sizeof(MWIPMATDEFX.MFG_DEVISION));
    TRS.set_char(out_node, "SUBCONTRACT_FLAG", MWIPMATDEFX.SUBCONTRACT_FLAG);
    //TRS.set_string(out_node, "BASE_MAT_ID", MWIPMATDEFX.BASE_MAT_ID, sizeof(MWIPMATDEFX.BASE_MAT_ID));
    TRS.set_string(out_node, "MAT_VENDOR_ID", MWIPMATDEFX.VENDOR_ID, sizeof(MWIPMATDEFX.VENDOR_ID));
    //TRS.set_string(out_node, "VENDOR_MAT_ID", MWIPMATDEFX.VENDOR_MAT_ID, sizeof(MWIPMATDEFX.VENDOR_MAT_ID));
    TRS.set_string(out_node, "CUSTOMER_ID", MWIPMATDEFX.CUSTOMER_ID, sizeof(MWIPMATDEFX.CUSTOMER_ID));
    TRS.set_string(out_node, "CUSTOMER_MAT_ID", MWIPMATDEFX.CUSTOMER_MAT_ID, sizeof(MWIPMATDEFX.CUSTOMER_MAT_ID));
    TRS.set_double(out_node, "DEF_QTY_1", MWIPMATDEFX.DEF_QTY_1);
    TRS.set_double(out_node, "DEF_QTY_2", MWIPMATDEFX.DEF_QTY_2);
    TRS.set_double(out_node, "DEF_QTY_3", MWIPMATDEFX.DEF_QTY_3);
    TRS.set_string(out_node, "MAT_UNIT_1", MWIPMATDEFX.UNIT_1, sizeof(MWIPMATDEFX.UNIT_1));
    TRS.set_string(out_node, "MAT_UNIT_2", MWIPMATDEFX.UNIT_2, sizeof(MWIPMATDEFX.UNIT_2));
    TRS.set_string(out_node, "MAT_UNIT_3", MWIPMATDEFX.UNIT_3, sizeof(MWIPMATDEFX.UNIT_3));
    TRS.set_double(out_node, "WEIGHT_NET", MWIPMATDEFX.WEIGHT_NET);
    TRS.set_double(out_node, "WEIGHT_GROSS", MWIPMATDEFX.WEIGHT_GROSS);
    TRS.set_string(out_node, "WEIGHT_UNIT", MWIPMATDEFX.WEIGHT_UNIT, sizeof(MWIPMATDEFX.WEIGHT_UNIT));
    TRS.set_double(out_node, "VOLUME", MWIPMATDEFX.VOLUME);
    TRS.set_string(out_node, "VOLUME_UNIT", MWIPMATDEFX.VOLUME_UNIT, sizeof(MWIPMATDEFX.VOLUME_UNIT));
    TRS.set_double(out_node, "DIMENSION_HR", MWIPMATDEFX.DIMENSION_HR);
    TRS.set_string(out_node, "DIMENSION_HR_UNIT", MWIPMATDEFX.DIMENSION_HR_UNIT, sizeof(MWIPMATDEFX.DIMENSION_HR_UNIT));
    TRS.set_double(out_node, "DIMENSION_VT", MWIPMATDEFX.DIMENSION_VT);
    TRS.set_string(out_node, "DIMENSION_VT_UNIT", MWIPMATDEFX.DIMENSION_VT_UNIT, sizeof(MWIPMATDEFX.DIMENSION_VT_UNIT));
    TRS.set_double(out_node, "DIMENSION_HT", MWIPMATDEFX.DIMENSION_HT);
    TRS.set_string(out_node, "DIMENSION_HT_UNIT", MWIPMATDEFX.DIMENSION_HT_UNIT, sizeof(MWIPMATDEFX.DIMENSION_HT_UNIT));
    TRS.set_string(out_node, "BOM_SET_ID", MWIPMATDEFX.BOM_SET_ID, sizeof(MWIPMATDEFX.BOM_SET_ID));
    TRS.set_string(out_node, "DEF_INV_OPER", MWIPMATDEFX.DEF_INV_OPER, sizeof(MWIPMATDEFX.DEF_INV_OPER));
    TRS.set_char(out_node, "PACK_TYPE", MWIPMATDEFX.PACK_TYPE);
    TRS.set_int(out_node, "PACK_LOT_COUNT", MWIPMATDEFX.PACK_LOT_COUNT);
    TRS.set_double(out_node, "PACK_QTY", MWIPMATDEFX.PACK_QTY);
    TRS.set_double(out_node, "LE_STOCK_LEVEL", MWIPMATDEFX.LE_STOCK_LEVEL);
    TRS.set_double(out_node, "LW_STOCK_LEVEL", MWIPMATDEFX.LW_STOCK_LEVEL);
    TRS.set_double(out_node, "HW_STOCK_LEVEL", MWIPMATDEFX.HW_STOCK_LEVEL);
    TRS.set_double(out_node, "HE_STOCK_LEVEL", MWIPMATDEFX.HE_STOCK_LEVEL);
    TRS.set_char(out_node, "IQC_FLAG", MWIPMATDEFX.IQC_FLAG);
    TRS.set_char(out_node, "IQC_SAMPLE_FLAG", MWIPMATDEFX.IQC_SAMPLE_FLAG);
    TRS.set_char(out_node, "IQC_SAMPLE_RULE", MWIPMATDEFX.IQC_SAMPLE_RULE);
    TRS.set_char(out_node, "OQC_FLAG", MWIPMATDEFX.OQC_FLAG);
    TRS.set_char(out_node, "OQC_SAMPLE_FLAG", MWIPMATDEFX.OQC_SAMPLE_FLAG);
    TRS.set_char(out_node, "OQC_SAMPLE_RULE", MWIPMATDEFX.OQC_SAMPLE_RULE);
    TRS.set_double(out_node, "TARGET_YIELD", MWIPMATDEFX.TARGET_YIELD);
    TRS.set_double(out_node, "TARGET_DUE_DAY", MWIPMATDEFX.TARGET_DUE_DAY);
    TRS.set_double(out_node, "TARGET_QTY_1", MWIPMATDEFX.TARGET_QTY_1);
    TRS.set_double(out_node, "TARGET_QTY_2", MWIPMATDEFX.TARGET_QTY_2);
    TRS.set_double(out_node, "TARGET_QTY_3", MWIPMATDEFX.TARGET_QTY_3);
    TRS.set_string(out_node, "APPLY_START_TIME", MWIPMATDEFX.APPLY_START_TIME, sizeof(MWIPMATDEFX.APPLY_START_TIME));
    TRS.set_string(out_node, "APPLY_END_TIME", MWIPMATDEFX.APPLY_END_TIME, sizeof(MWIPMATDEFX.APPLY_END_TIME));
    TRS.set_char(out_node, "APPROVAL_FLAG", MWIPMATDEFX.APPROVAL_FLAG);
    TRS.set_string(out_node, "APPROVAL_USER_ID", MWIPMATDEFX.APPROVAL_USER_ID, sizeof(MWIPMATDEFX.APPROVAL_USER_ID));
    TRS.set_string(out_node, "APPROVAL_TIME", MWIPMATDEFX.APPROVAL_TIME, sizeof(MWIPMATDEFX.APPROVAL_TIME));
    TRS.set_char(out_node, "RELEASE_FLAG", MWIPMATDEFX.RELEASE_FLAG);
    TRS.set_string(out_node, "RELEASE_USER_ID", MWIPMATDEFX.RELEASE_USER_ID, sizeof(MWIPMATDEFX.RELEASE_USER_ID));
    TRS.set_string(out_node, "RELEASE_TIME", MWIPMATDEFX.RELEASE_TIME, sizeof(MWIPMATDEFX.RELEASE_TIME));
    TRS.set_char(out_node, "DEACTIVE_FLAG", MWIPMATDEFX.DEACTIVE_FLAG);
    TRS.set_string(out_node, "DEACTIVE_USER_ID", MWIPMATDEFX.DEACTIVE_USER_ID, sizeof(MWIPMATDEFX.DEACTIVE_USER_ID));
    TRS.set_string(out_node, "DEACTIVE_TIME", MWIPMATDEFX.DEACTIVE_TIME, sizeof(MWIPMATDEFX.DEACTIVE_TIME));
    TRS.set_char(out_node, "DELETE_FLAG", MWIPMATDEFX.DELETE_FLAG);
    //TRS.set_string(out_node, "DELETE_USER_ID", MWIPMATDEFX.DELETE_USER_ID, sizeof(MWIPMATDEFX.DELETE_USER_ID));
    //TRS.set_string(out_node, "DELETE_TIME", MWIPMATDEFX.DELETE_TIME, sizeof(MWIPMATDEFX.DELETE_TIME));
    //TRS.set_string(out_node, "CREATE_USER_ID", MWIPMATDEFX.CREATE_USER_ID, sizeof(MWIPMATDEFX.CREATE_USER_ID));
    //TRS.set_string(out_node, "CREATE_TIME", MWIPMATDEFX.CREATE_TIME, sizeof(MWIPMATDEFX.CREATE_TIME));
    //TRS.set_string(out_node, "UPDATE_USER_ID", MWIPMATDEFX.UPDATE_USER_ID, sizeof(MWIPMATDEFX.UPDATE_USER_ID));
    //TRS.set_string(out_node, "UPDATE_TIME", MWIPMATDEFX.UPDATE_TIME, sizeof(MWIPMATDEFX.UPDATE_TIME));
    TRS.set_string(out_node, "MAT_SHORT_DESC", MWIPMATDEFX.MAT_SHORT_DESC, sizeof(MWIPMATDEFX.MAT_SHORT_DESC));

 
	/*Get Oper Desc*/
    DBC_init_mtivoprdef(&MTIVOPRDEF);
    memcpy(MTIVOPRDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
    memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));    
    
    DBC_select_mtivoprdef(1, &MTIVOPRDEF);    
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }

        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);        
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }  

	TRS.add_string(out_node, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
	TRS.add_string(out_node, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));

	if (TRS.get_char(in_node, "CHECK_FIFO_FLAG") == 'Y')
	{
		//if (CUS_Check_First_In_First_Out_V2(s_msg_code,
		//								 MTIVLOTSTS.FACTORY,
		//								 MTIVLOTSTS.LOT_ID,
		//								 MTIVLOTSTS.OPER,
		//								 MTIVLOTSTS.ERP_CREATE_DATE,
		//								 MTIVLOTSTS.MAT_ID,
		//								 in_node,
		//								 out_node) == MP_FALSE)
		//{
		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	return MP_FALSE;
		//}
		/*if (CUS_Check_First_In_First_Out(s_msg_code,
										 MTIVLOTSTS.FACTORY,
										 MTIVLOTSTS.LOT_ID,
										 MTIVLOTSTS.OPER,
										 MTIVLOTSTS.ERP_CREATE_DATE,
										 MTIVLOTSTS.MAT_ID,
										 out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}*/
	}

	if (MTIVLOTSTS.VENDOR_ID[0] != ' ')
	{
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_VENDOR, strlen(MP_GCM_VENDOR));
		memcpy(MGCMTBLDAT.KEY_1, MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
	 
		istep = 1;
		DBC_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{

			}
			else
			{
				strcpy(s_msg_code,"GCM-0008");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "DATA_2", MP_STR, sizeof(MGCMTBLDAT.DATA_2), MGCMTBLDAT.DATA_2);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
 
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}		
		}

		TRS.add_string(out_node, "VENDOR_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));   
	}
	
	DBC_init_matrnamsts(&MATRNAMSTS);
	TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_LOT, strlen(MP_ATTR_TYPE_INV_LOT));
	memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_NAME_CUSTOMER_MAT_ID, strlen(MP_ATTR_NAME_CUSTOMER_MAT_ID));
	memcpy(MATRNAMSTS.ATTR_KEY, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));

	DBC_select_matrnamsts(1, &MATRNAMSTS);
	if(DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
				 
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
			TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
			TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}				
	}
	TRS.set_string(out_node, "CUST_MAT_ID", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));

	DBC_init_matrnamsts(&MATRNAMSTS);
	TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_LOT, strlen(MP_ATTR_TYPE_INV_LOT));
	memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_NAME_USE_FACTORY, strlen(MP_ATTR_NAME_USE_FACTORY));
	memcpy(MATRNAMSTS.ATTR_KEY, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));

	DBC_select_matrnamsts(1, &MATRNAMSTS);
	if(DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
				 
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
			TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
			TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}				
	}
	TRS.set_string(out_node, "USE_FACTORY", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));

	TRS.set_string(out_node, "USE_FACTORY_DESC", " ", strlen(" "));
	if (COM_isnullspace(MATRNAMSTS.ATTR_VALUE) == MP_FALSE)
	{
		DBC_init_mwipfacdef(&MWIPFACDEF);
		memcpy(MWIPFACDEF.FACTORY, MATRNAMSTS.ATTR_VALUE, sizeof(MWIPFACDEF.FACTORY));

		DBC_select_mwipfacdef(1, &MWIPFACDEF);
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
						 
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				return MP_FALSE;
			}
		}    

		TRS.set_string(out_node, "USE_FACTORY_DESC", MWIPFACDEF.FAC_DESC, sizeof(MWIPFACDEF.FAC_DESC));
	}
	 
	TRS.set_string(out_node, "PALLET_DESC", " ", strlen(" "));
	if (COM_isnullspace(MTIVLOTSTS.INV_CMF_4) == MP_FALSE)
	{
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_PALLET_TYPE, strlen(MP_GCM_PALLET_TYPE));
		memcpy(MGCMTBLDAT.KEY_1, MTIVLOTSTS.INV_CMF_4, sizeof(MGCMTBLDAT.KEY_1));				 
		istep = 1;
		DBC_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
					 
			}
			else
			{
				strcpy(s_msg_code,"WIP-0004");
				TRS.add_dberrmsg(out_node, DB_error_msg);

				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
			
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			}						
		}
		TRS.set_string(out_node, "PALLET_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}


	TRS.set_string(out_node, "CREATE_USER_ID", " ", strlen(" "));
                              	TRS.set_string(out_node, "CREATE_USER_DESC", " ", strlen(" "));

	if (TRS.get_char(in_node, "CREATE_USER_FLAG") == 'Y')
	{
		DBC_init_mtivlothis(&MTIVLOTHIS);			
		TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "LOT_ID");
		MTIVLOTHIS.HIST_SEQ = 1;

		DBC_select_mtivlothis(6, &MTIVLOTHIS);
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0030");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}
				
			TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);
			TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS.HIST_SEQ);
 
				
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
 
			return MP_FALSE;
		}

		TRS.set_string(out_node, "CREATE_USER_ID", MTIVLOTHIS.TRAN_USER_ID, sizeof(MTIVLOTHIS.TRAN_USER_ID));

		DBC_init_msecusrdef(&MSECUSRDEF);
		memcpy(MSECUSRDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MSECUSRDEF.FACTORY));
		memcpy(MSECUSRDEF.USER_ID, MTIVLOTHIS.TRAN_USER_ID, sizeof(MSECUSRDEF.USER_ID));
        
		DBC_select_msecusrdef(1, &MSECUSRDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
                 
			}
			else
			{
				strcpy(s_msg_code, "SEC-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node,DB_error_msg);
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}           
		}
		TRS.set_string(out_node, "CREATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
	}

	TRS.set_string(out_node, "RUB_LOT_ID", " ", strlen(" "));
	TRS.set_string(out_node, "RUB_CREATE_TIME", " ", strlen(" "));
	TRS.set_string(out_node, "RUB_MAT_ID", " ", strlen(" "));

	if (TRS.get_char(in_node, "RUB_INFO_FLAG") == 'Y')
	{
		//MP_MAT_GRP_2_RUB
		DBC_init_mtivmatuse(&MTIVMATUSE);
		TRS.copy(MTIVMATUSE.FACTORY, sizeof(MTIVMATUSE.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVMATUSE.LOT_ID, sizeof(MTIVMATUSE.LOT_ID), in_node, "LOT_ID");
		memcpy(MTIVMATUSE.INPUT_MAT_TYPE, MP_MAT_GRP_2_RUB, strlen(MP_MAT_GRP_2_RUB));
		istep = 3;
		DBC_select_mtivmatuse(istep, &MTIVMATUSE);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
					 
			}
			else
			{	
				strcpy(s_msg_code,"GCM-0008");			
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.add_fieldmsg(out_node, "MTIVMATUSE SELECT FACTORY", MP_STR, sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
				TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR, sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
  
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}				
		}
		else
		{				 
			DBC_init_mtivlotsts(&MTIVLOTSTS_SUB);				
			memcpy(MTIVLOTSTS_SUB.LOT_ID, MTIVMATUSE.INPUT_LOT_ID, sizeof(MTIVMATUSE.INPUT_LOT_ID));
			istep = 20;
			DBC_select_mtivlotsts(istep, &MTIVLOTSTS_SUB);
			if(DB_error_code != DB_SUCCESS) 
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "INV-0030");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;				
				}
				else 
				{
					strcpy(s_msg_code, "INV-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}

				TRS.add_fieldmsg(out_node, "MTIVLOTSTS_SUB SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_SUB.FACTORY), MTIVLOTSTS_SUB.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_SUB.LOT_ID), MTIVLOTSTS_SUB.LOT_ID);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_SUB.OPER), MTIVLOTSTS_SUB.OPER);
			
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			TRS.set_string(out_node, "RUB_LOT_ID", MTIVLOTSTS_SUB.LOT_ID, sizeof(MTIVLOTSTS_SUB.LOT_ID));
			TRS.set_string(out_node, "RUB_CREATE_TIME", MTIVLOTSTS_SUB.CREATE_TIME, sizeof(MTIVLOTSTS_SUB.CREATE_TIME));
			TRS.set_string(out_node, "RUB_MAT_ID", MTIVLOTSTS_SUB.MAT_ID, sizeof(MTIVLOTSTS_SUB.MAT_ID));				 
		}
	}

	if (TRS.get_char(in_node, "GROUP_INFO_FLAG") == 'Y' &&
		COM_isnullspace(MTIVLOTSTS.LOT_GROUP_ID) == MP_FALSE)
	{
		/*DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);		
		memcpy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");*/
		i_cursor_step = 13;

		DBC_open_mtivlotsts(i_cursor_step, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "INV-0004");
			TRS.add_fieldmsg(out_node, "MTIVLOTSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);        
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		while(1) 
		{
			DBC_fetch_mtivlotsts(i_cursor_step, &MTIVLOTSTS);
			if(DB_error_code == DB_NOT_FOUND) 
			{
				DBC_close_mtivlotsts(i_cursor_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "INV-0004");
				TRS.add_fieldmsg(out_node, "MTIVLOTSTS FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);            
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				DBC_close_mtivlotsts(i_cursor_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				TRS.add_string(out_node, "NEXT_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
				DBC_close_mwiplotsts(i_cursor_step);
				break;
			}

			list_item = TRS.add_node(out_node, "LOT_LIST");

			TRS.add_string(list_item, "FACTORY", MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
			TRS.add_string(list_item, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.add_string(list_item, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.add_string(list_item, "LOT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));    
			TRS.add_string(list_item, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
			TRS.add_int(list_item, "MAT_VER", MTIVLOTSTS.MAT_VER);
			TRS.add_char(list_item, "LOT_TYPE", MTIVLOTSTS.LOT_TYPE);
			TRS.add_double(list_item, "QTY_1", MTIVLOTSTS.QTY_1);
			TRS.add_double(list_item, "QTY_2", MTIVLOTSTS.QTY_2);
			TRS.add_double(list_item, "QTY_3", MTIVLOTSTS.QTY_3);
			TRS.add_double(list_item, "CREATE_QTY_1", MTIVLOTSTS.CREATE_QTY_1);
			TRS.add_double(list_item, "CREATE_QTY_2", MTIVLOTSTS.CREATE_QTY_2);
			TRS.add_double(list_item, "CREATE_QTY_3", MTIVLOTSTS.CREATE_QTY_3);
			TRS.add_string(list_item, "CREATE_TIME", MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME));
			TRS.add_string(list_item, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
			TRS.add_string(list_item, "OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
			TRS.add_char(list_item, "IN_OUT_FLAG", MTIVLOTSTS.IN_OUT_FLAG);
			TRS.add_string(list_item, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
			TRS.add_string(list_item, "LINE_NO", MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO));
			TRS.add_string(list_item, "UNIT_1", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
			TRS.add_string(list_item, "UNIT_2", MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
			TRS.add_string(list_item, "UNIT_3", MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));
			TRS.add_char(list_item, "INSPECTION_FLAG", MTIVLOTSTS.INSPECTION_FLAG);
			TRS.add_char(list_item, "INSPECTION_RESULT", MTIVLOTSTS.INSPECTION_RESULT);
			TRS.add_string(list_item, "LAST_TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
			TRS.add_string(list_item, "LAST_TRAN_TYPE", MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));
			TRS.add_string(list_item, "LAST_TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
			TRS.add_int(list_item, "LAST_LOT_GRP_SEQ", MTIVLOTSTS.LAST_LOT_GRP_SEQ);
			TRS.add_int(list_item, "LAST_ACTIVE_LOT_GRP_SEQ", MTIVLOTSTS.LAST_ACTIVE_LOT_GRP_SEQ);
			TRS.add_int(list_item, "LAST_HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);
			TRS.add_int(list_item, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
			TRS.add_string(list_item, "LAST_COMMENT", MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT));
			TRS.add_char(list_item, "LOT_DEL_FLAG", MTIVLOTSTS.LOT_DEL_FLAG);
			TRS.add_enc_string(list_item, "LOT_DEL_USER_ID", MTIVLOTSTS.LOT_DEL_USER_ID, sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
			TRS.add_string(list_item, "LOT_DEL_TIME", MTIVLOTSTS.LOT_DEL_TIME, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
			TRS.add_string(list_item, "LOT_DEL_REASON", MTIVLOTSTS.LOT_DEL_REASON, sizeof(MTIVLOTSTS.LOT_DEL_REASON));
			TRS.add_string(list_item, "LOCATION", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));    
			TRS.add_string(list_item, "LOCATION_NO", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));    
			TRS.add_char(list_item, "HOLD_FLAG", MTIVLOTSTS.HOLD_FLAG);
			TRS.add_string(list_item, "HOLD_CODE", MTIVLOTSTS.HOLD_CODE, sizeof(MTIVLOTSTS.HOLD_CODE));
			TRS.add_string(list_item, "RELEASE_CODE", MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE));
			TRS.add_char(list_item, "PICK_FLAG", MTIVLOTSTS.PICK_FLAG);
			TRS.add_char(list_item, "SHIP_FLAG", MTIVLOTSTS.SHIP_FLAG);
			//TRS.add_string(list_item, "FROM_LOT_ID", MTIVLOTSTS.FROM_LOT_ID, sizeof(MTIVLOTSTS.FROM_LOT_ID));
			//TRS.add_string(list_item, "FROM_OPER", MTIVLOTSTS.FROM_OPER, sizeof(MTIVLOTSTS.FROM_OPER));
			TRS.add_string(list_item, "TIV_GRADE", MTIVLOTSTS.GRADE, sizeof(MTIVLOTSTS.GRADE));
			TRS.add_string(list_item, "ADD_ORDER_ID_1", MTIVLOTSTS.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS.ADD_ORDER_ID_1));
			TRS.add_string(list_item, "ADD_ORDER_LINE_1", MTIVLOTSTS.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_1));
			TRS.add_string(list_item, "ADD_ORDER_ID_2", MTIVLOTSTS.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS.ADD_ORDER_ID_2));
			TRS.add_string(list_item, "ADD_ORDER_LINE_2", MTIVLOTSTS.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_2));
			TRS.add_string(list_item, "ADD_ORDER_ID_3", MTIVLOTSTS.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS.ADD_ORDER_ID_3));
			TRS.add_string(list_item, "ADD_ORDER_LINE_3", MTIVLOTSTS.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_3));
			TRS.add_string(list_item, "VENDOR", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
			TRS.add_string(list_item, "PO_MAT_ID", MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID));
			TRS.add_int(list_item, "PO_SEQ_NUM", MTIVLOTSTS.PO_SEQ_NUM);
			TRS.add_string(list_item, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
			TRS.add_string(list_item, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
			TRS.add_string(list_item, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
			TRS.add_string(list_item, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
			TRS.add_string(list_item, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
			TRS.add_string(list_item, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
			TRS.add_string(list_item, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
			TRS.add_string(list_item, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
			TRS.add_string(list_item, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
			TRS.add_string(list_item, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
			TRS.add_string(list_item, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
			TRS.add_string(list_item, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
			TRS.add_string(list_item, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
			TRS.add_string(list_item, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
			TRS.add_string(list_item, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
			TRS.add_string(list_item, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
			TRS.add_string(list_item, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
			TRS.add_string(list_item, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
			TRS.add_string(list_item, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
			TRS.add_string(list_item, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
			TRS.add_string(list_item, "TIV_OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
			TRS.add_string(list_item, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
			TRS.add_string(list_item, "FROM_TO_LOT_ID", MTIVLOTSTS.FROM_TO_LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
			TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTSTS.FROM_TO_HIST_SEQ);
			TRS.add_char(list_item, "FROM_TO_FLAG", MTIVLOTSTS.FROM_TO_FLAG);
			TRS.add_string(list_item, "LOT_GROUP_ID", MTIVLOTSTS.LOT_GROUP_ID, sizeof(MTIVLOTSTS.LOT_GROUP_ID));
			TRS.add_string(list_item, "EXPIRE_DATE", MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE));
			TRS.add_string(list_item, "INV_IN_TIME", MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME));
			TRS.add_string(list_item, "INV_OUT_TIME", MTIVLOTSTS.INV_OUT_TIME, sizeof(MTIVLOTSTS.INV_OUT_TIME));
			TRS.add_string(list_item, "OINV_IN_TIME", MTIVLOTSTS.OINV_IN_TIME, sizeof(MTIVLOTSTS.OINV_IN_TIME));
			TRS.add_string(list_item, "OINV_OUT_TIME", MTIVLOTSTS.OINV_OUT_TIME, sizeof(MTIVLOTSTS.OINV_OUT_TIME));
			TRS.add_string(list_item, "WIP_IN_TIME", MTIVLOTSTS.WIP_IN_TIME, sizeof(MTIVLOTSTS.WIP_IN_TIME));
			TRS.add_string(list_item, "WIP_OUT_TIME", MTIVLOTSTS.WIP_OUT_TIME, sizeof(MTIVLOTSTS.WIP_OUT_TIME));

			TRS.add_string(list_item, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
			TRS.add_string(list_item, "INV_CMF_21", MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21));
			TRS.add_string(list_item, "INV_CMF_22", MTIVLOTSTS.INV_CMF_22, sizeof(MTIVLOTSTS.INV_CMF_22));
			TRS.add_string(list_item, "INV_CMF_23", MTIVLOTSTS.INV_CMF_23, sizeof(MTIVLOTSTS.INV_CMF_23));
			TRS.add_string(list_item, "INV_CMF_24", MTIVLOTSTS.INV_CMF_24, sizeof(MTIVLOTSTS.INV_CMF_24));
			TRS.add_string(list_item, "INV_CMF_25", MTIVLOTSTS.INV_CMF_25, sizeof(MTIVLOTSTS.INV_CMF_25));
			TRS.add_string(list_item, "INV_CMF_26", MTIVLOTSTS.INV_CMF_26, sizeof(MTIVLOTSTS.INV_CMF_26));
			TRS.add_string(list_item, "INV_CMF_27", MTIVLOTSTS.INV_CMF_27, sizeof(MTIVLOTSTS.INV_CMF_27));
			TRS.add_string(list_item, "INV_CMF_28", MTIVLOTSTS.INV_CMF_28, sizeof(MTIVLOTSTS.INV_CMF_28));
			TRS.add_string(list_item, "INV_CMF_29", MTIVLOTSTS.INV_CMF_29, sizeof(MTIVLOTSTS.INV_CMF_29));
			TRS.add_string(list_item, "INV_CMF_30", MTIVLOTSTS.INV_CMF_30, sizeof(MTIVLOTSTS.INV_CMF_30));
			TRS.add_char(list_item, "INV_FLAG_1", MTIVLOTSTS.INV_FLAG_1);
			TRS.add_char(list_item, "INV_FLAG_2", MTIVLOTSTS.INV_FLAG_2);
			TRS.add_char(list_item, "INV_FLAG_3", MTIVLOTSTS.INV_FLAG_3);
			TRS.add_char(list_item, "INV_FLAG_4", MTIVLOTSTS.INV_FLAG_4);
			TRS.add_char(list_item, "INV_FLAG_5", MTIVLOTSTS.INV_FLAG_5);
			TRS.add_string(list_item, "ERP_CREATE_DATE", MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE));
			TRS.add_string(list_item, "ERP_INV_IN_DATE", MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE));
			TRS.add_string(list_item, "ERP_OINV_IN_DATE", MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE));
			TRS.add_string(list_item, "ERP_LAST_TRAN_DATE", MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE));
			TRS.add_string(list_item, "LAST_TRAN_USER_ID", MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID));



			DBC_init_mwipmatdef(&MWIPMATDEFX);
			TRS.copy(MWIPMATDEFX.FACTORY, sizeof(MWIPMATDEFX.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEFX.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEFX.MAT_ID));
			MWIPMATDEFX.MAT_VER = MTIVLOTSTS.MAT_VER;
			DBC_select_mwipmatdef(1, &MWIPMATDEFX);
			if(DB_error_code != DB_SUCCESS) 
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "INV-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);

					TRS.add_fieldmsg(out_node, "MWIPMATDEFX SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEFX.FACTORY), MWIPMATDEFX.FACTORY);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEFX.MAT_ID), MWIPMATDEFX.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEFX.MAT_VER);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_COMMON;
					return MP_FALSE;
				}
			}
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEFX.MAT_DESC, sizeof(MWIPMATDEFX.MAT_DESC));
			TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEFX.MAT_SHORT_DESC, sizeof(MWIPMATDEFX.MAT_SHORT_DESC));
			TRS.add_string(list_item, "BASE_MAT_ID", MWIPMATDEFX.BASE_MAT_ID, sizeof(MWIPMATDEFX.BASE_MAT_ID));
			TRS.add_string(list_item, "PACK_UNIT_1", MWIPMATDEFX.UNIT_1, sizeof(MWIPMATDEFX.UNIT_1));//PACK_UNIT_1
			TRS.add_string(list_item, "PACK_UNIT_2", MWIPMATDEFX.UNIT_2, sizeof(MWIPMATDEFX.UNIT_2));
			TRS.add_double(list_item, "DEF_QTY_1", MWIPMATDEFX.DEF_QTY_1);
			TRS.add_double(list_item, "DEF_QTY_2", MWIPMATDEFX.DEF_QTY_2);
			TRS.add_string(list_item, "MAT_TYPE", MWIPMATDEFX.MAT_TYPE, sizeof(MWIPMATDEFX.MAT_TYPE));

			TRS.add_string(list_item, "MAT_CMF_1", MWIPMATDEFX.MAT_CMF_1, sizeof(MWIPMATDEFX.MAT_CMF_1));
			TRS.add_string(list_item, "MAT_CMF_2", MWIPMATDEFX.MAT_CMF_2, sizeof(MWIPMATDEFX.MAT_CMF_2));
			TRS.add_string(list_item, "MAT_CMF_3", MWIPMATDEFX.MAT_CMF_3, sizeof(MWIPMATDEFX.MAT_CMF_3));
			TRS.add_string(list_item, "MAT_CMF_4", MWIPMATDEFX.MAT_CMF_4, sizeof(MWIPMATDEFX.MAT_CMF_4));
			TRS.add_string(list_item, "MAT_CMF_5", MWIPMATDEFX.MAT_CMF_5, sizeof(MWIPMATDEFX.MAT_CMF_5));
			TRS.add_string(list_item, "MAT_CMF_6", MWIPMATDEFX.MAT_CMF_6, sizeof(MWIPMATDEFX.MAT_CMF_6));
			TRS.add_string(list_item, "MAT_CMF_7", MWIPMATDEFX.MAT_CMF_7, sizeof(MWIPMATDEFX.MAT_CMF_7));
			TRS.add_string(list_item, "MAT_CMF_8", MWIPMATDEFX.MAT_CMF_8, sizeof(MWIPMATDEFX.MAT_CMF_8));
			TRS.add_string(list_item, "MAT_CMF_9", MWIPMATDEFX.MAT_CMF_9, sizeof(MWIPMATDEFX.MAT_CMF_9));
			TRS.add_string(list_item, "MAT_CMF_10", MWIPMATDEFX.MAT_CMF_10, sizeof(MWIPMATDEFX.MAT_CMF_10));
			TRS.add_string(list_item, "MAT_CMF_11", MWIPMATDEFX.MAT_CMF_11, sizeof(MWIPMATDEFX.MAT_CMF_11));
			TRS.add_string(list_item, "MAT_CMF_12", MWIPMATDEFX.MAT_CMF_12, sizeof(MWIPMATDEFX.MAT_CMF_12));
			TRS.add_string(list_item, "MAT_CMF_13", MWIPMATDEFX.MAT_CMF_13, sizeof(MWIPMATDEFX.MAT_CMF_13));
			TRS.add_string(list_item, "MAT_CMF_14", MWIPMATDEFX.MAT_CMF_14, sizeof(MWIPMATDEFX.MAT_CMF_14));
			TRS.add_string(list_item, "MAT_CMF_15", MWIPMATDEFX.MAT_CMF_15, sizeof(MWIPMATDEFX.MAT_CMF_15));
			TRS.add_string(list_item, "MAT_CMF_16", MWIPMATDEFX.MAT_CMF_16, sizeof(MWIPMATDEFX.MAT_CMF_16));
			TRS.add_string(list_item, "MAT_CMF_17", MWIPMATDEFX.MAT_CMF_17, sizeof(MWIPMATDEFX.MAT_CMF_17));
			TRS.add_string(list_item, "MAT_CMF_18", MWIPMATDEFX.MAT_CMF_18, sizeof(MWIPMATDEFX.MAT_CMF_18));
			TRS.add_string(list_item, "MAT_CMF_19", MWIPMATDEFX.MAT_CMF_19, sizeof(MWIPMATDEFX.MAT_CMF_19));
			TRS.add_string(list_item, "MAT_CMF_20", MWIPMATDEFX.MAT_CMF_20, sizeof(MWIPMATDEFX.MAT_CMF_20));
            TRS.add_string(list_item, "MAT_CMF_21", " ", strlen(" "));
            TRS.add_string(list_item, "MAT_CMF_22", " ", strlen(" "));

			DBC_init_mtivoprdef(&MTIVOPRDEF);
			TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));
			DBC_select_mtivoprdef(1, &MTIVOPRDEF);
			if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);

				TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);        
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_COMMON;
				return MP_FALSE;
			}  
			TRS.add_string(list_item, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
			TRS.add_string(list_item, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));
			 
			if (MTIVLOTSTS.INSPECTION_FLAG != ' ')
			{
				DBU_init_mgcmtbldat(&MGCMTBLDAT);
				TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_TYPE, strlen(MP_GCM_INSP_TYPE));
				MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_FLAG;
			 
				istep = 1;
				DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{	
				
					}
					else
					{	
						strcpy(s_msg_code,"GCM-0004");			
						TRS.add_dberrmsg(out_node, DB_error_msg);	
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
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

				TRS.add_string(list_item, "INSPECTION_FLAG_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
			else
			{
				TRS.add_string(list_item, "INSPECTION_FLAG_DESC", " ", strlen(" "));
			}

			if (MTIVLOTSTS.INSPECTION_RESULT != ' ')
			{
				DBU_init_mgcmtbldat(&MGCMTBLDAT);
				TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_RESULT, strlen(MP_GCM_INSP_RESULT));
				MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_RESULT;
			 
				istep = 1;
				DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{	
				
					}
					else
					{	
						strcpy(s_msg_code,"GCM-0004");			
						TRS.add_dberrmsg(out_node, DB_error_msg);	
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
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
				TRS.add_string(list_item, "INSPECTION_RESULT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
			else
			{
				TRS.add_string(list_item, "INSPECTION_RESULT_DESC", " ", strlen(" "));
			}

			if (MTIVLOTSTS.VENDOR_ID[0] != ' ')
			{
				DBC_init_mgcmtbldat(&MGCMTBLDAT);
				TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_VENDOR, strlen(MP_GCM_VENDOR));
				memcpy(MGCMTBLDAT.KEY_1, MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
	 
				istep = 1;
				DBC_select_mgcmtbldat(istep, &MGCMTBLDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{

					}
					else
					{
						strcpy(s_msg_code,"GCM-0008");
						TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
						TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
						TRS.add_fieldmsg(out_node, "DATA_2", MP_STR, sizeof(MGCMTBLDAT.DATA_2), MGCMTBLDAT.DATA_2);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;
 
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}		
				}

				TRS.add_string(list_item, "VENDOR_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));   
			}
		}
		 
	}

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_Ext",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
//#endif

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Lot_Ext_Validation()
        - Validation Check sub function of "TIV_VIEW_LOT_EXT" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_Ext_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                               "12345679AB") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }    
    /* Lot ID Validation */
   
    return MP_TRUE;
}







