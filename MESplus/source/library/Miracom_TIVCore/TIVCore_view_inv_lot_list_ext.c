/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : TIVCore_view_inv_lot_list_ext.c
    Description : View Inventory Lot List related function module

    MES Version : 5.2.0.0

    Function Listpr
        - TIV_View_Inv_Lot_List_Ext()
            + View Inventory Lot List
        - TIV_VIEW_INV_LOT_LIST_EXT()
            + Main Sub function of "TIV_View_Inv_Lot_List_Ext"
            + (called by "TIV_View_Inv_Lot_List_Ext")
        - TIV_View_Inv_Lot_List_Ext_Validation()
            + Validation Check sub function of "TIV_VIEW_INV_LOT_LIST_EXT" function
            + (called by "TIV_VIEW_INV_LOT_LIST_EXT")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/29  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Inv_Lot_List_Ext_Validation(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);


/*******************************************************************************
    TIV_View_Inv_Lot_List_Ext()
        - View Inventory Lot Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Inv_Lot_List_Ext(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_INV_LOT_LIST_EXT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_INV_LOT_LIST_EXT", out_node);

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
    TIV_VIEW_INV_LOT_LIST_EXT()
        - Main sub function of "TIV_View_Inv_Lot_List_Ext" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_INV_LOT_LIST_EXT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;

	//struct MGCMTBLDAT_TAG MGCMTBLDAT;

	char	s_oper_id[10];
	char	s_oper_desc[200];

	char	s_mat_id[30];
	char	s_mat_short_desc[50];
	char	s_mat_desc[200];

    TRSNode *list_item;

	int i_cursor_step = 0;
    //int i_step = 0;
    
	LOG_head("TIV_View_Inv_Lot_List_Ext");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Inv_Lot_List_Ext",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

	memset(s_mat_id, ' ', sizeof(s_mat_id));	
	memset(s_mat_short_desc, ' ', sizeof(s_mat_short_desc));
	memset(s_mat_desc, ' ', sizeof(s_mat_desc));
	 
	memset(s_oper_id, ' ', sizeof(s_oper_id));	
	memset(s_oper_desc, ' ', sizeof(s_oper_desc));

    /* Validation Check */
    if(TIV_View_Inv_Lot_List_Ext_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if(TRS.get_procstep(in_node)=='1')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");		
		TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), in_node, "VENDOR_ID");        
		MTIVLOTSTS.HOLD_FLAG = TRS.get_char(in_node, "HOLD_FLAG");
		MTIVLOTSTS.LOT_DEL_FLAG = TRS.get_char(in_node, "LOT_DEL_FLAG");
        
		if (TRS.get_char(in_node, "TIME_FLAG") == 'Y')
		{
			TRS.copy(MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME), in_node, "FROM_TIME");
			TRS.copy(MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME), in_node, "TO_TIME");
		}
		
		if (TRS.get_char(in_node, "LAST_ACTIVE_LOT_FLAG") == 'Y')
		{
			MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = 1;
		}

		
		TRS.copy(MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21), in_node, "LOT_ID");

		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "NEXT_LOT_ID");

		i_cursor_step = 17;
	}
	 
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

		list_item = TRS.add_node(out_node, "LIST");

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
		TRS.add_char(list_item, "INSP_FLAG", MTIVLOTSTS.INSPECTION_FLAG);
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
		TRS.add_char(list_item, "TERM_FLAG", MTIVLOTSTS.TERM_FLAG);
        TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTSTS.FROM_TO_HIST_SEQ);
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

		if (memcmp(MTIVLOTSTS.OPER, s_oper_id, sizeof(s_oper_id)) != 0)
		{
			DBC_init_mtivoprdef(&MTIVOPRDEF);
			TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));
			DBC_select_mtivoprdef(1, &MTIVOPRDEF);
			if(DB_error_code != DB_SUCCESS) 
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

				DBC_close_mwiplotsts(i_cursor_step);

				TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

				gs_log_type.type = MP_LOG_ERROR;    
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			memcpy(s_oper_id, MTIVOPRDEF.OPER, sizeof(s_oper_id));
			memcpy(s_oper_desc, MTIVOPRDEF.OPER_DESC, sizeof(s_oper_desc));
		}
		TRS.add_string(list_item, "OPER_DESC", s_oper_desc, sizeof(s_oper_desc));

		if (memcmp(MTIVLOTSTS.MAT_ID, s_mat_id, sizeof(s_mat_id)) != 0)
		{
			DBC_init_mwipmatdef(&MWIPMATDEF);
			TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPMATDEF.MAT_VER  = MTIVLOTSTS.MAT_VER;
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
					strcpy(s_msg_code, "WIP-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
				TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
 
				DBC_close_mwiplotsts(i_cursor_step);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			memcpy(s_mat_id, MWIPMATDEF.MAT_ID, sizeof(s_mat_id));
			memcpy(s_mat_short_desc, MWIPMATDEF.MAT_SHORT_DESC, sizeof(s_mat_short_desc));
			memcpy(s_mat_desc, MWIPMATDEF.MAT_DESC, sizeof(s_mat_desc));
		}
		TRS.add_string(list_item, "MAT_SHORT_DESC", s_mat_short_desc, sizeof(s_mat_short_desc));
		TRS.add_string(list_item, "MAT_DESC", s_mat_desc, sizeof(s_mat_desc));



	}
	
	
	if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Inv_Lot_List_Ext",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Inv_Lot_List_Ext_Validation()
        - Validation Check sub function of "TIV_VIEW_INV_LOT_LIST_EXT" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Inv_Lot_List_Ext_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;    

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
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
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
        return MP_FALSE;
    }    

    return MP_TRUE;
}
	
	
