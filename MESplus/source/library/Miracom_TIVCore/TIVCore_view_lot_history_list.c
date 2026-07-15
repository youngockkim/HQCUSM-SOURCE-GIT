/******************************************************************************'

	System      : MESplus
	Module      : INVCore
	File Name   : INVCore_view_int_lot_history_list.c
	Description : View Inv_view_lot_history_list List function module

	MES Version : 5.2.0

	Function List
		- TIV_View_Lot_History_List()
			+ View Inv_view_lot_history_list definition List
		- TIV_VIEW_TIV_VIEW_LOT_HISTORY_LIST()
			+ Main sub function of TIV_View_Inv_view_lot_history_list function
			+ View Inv_view_lot_history_list definition List
	Detail Description
		- TIV_VIEW_TIV_VIEW_LOT_HISTORY_LIST()
			+ h_proc_step
				+ 1 : View Inv_view_lot_history_list definition List by Primary Key
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

/*******************************************************************************
	TIV_View_Lot_History_List()
		- View Inv_view_lot_history_list definition List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_History_List(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TIV_VIEW_LOT_HISTORY_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TIV_View_Lot_History_List", out_node);

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
	TIV_VIEW_LOT_HISTORY_LIST()
		- Main sub function of "TIV_View_Lot_History_List" function
		- View TIV_View_Lot_History_List_List definition List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT_HISTORY_LIST(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTIVLOTHIS_TAG MTIVLOTHIS;
	TRSNode *list_item;

	int i_step = 0;

	LOG_head("TIV_VIew_Lot_History_List");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("MES_UserTIV", "TIV_VIew_Lot_History_List",
							 MP_UPOINT_BEFORE,
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 

	/* ProcStep Validation */
	if(COM_service_validation(s_msg_code, in_node, out_node, TRS.get_procstep(in_node), "1") == MP_FALSE) 
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

    if(TRS.get_procstep(in_node)=='1')
    {
        i_step = 5;
    }
	DBC_init_mtivlothis(&MTIVLOTHIS);
    TRS.copy(MTIVLOTHIS.FACTORY , sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);    
    TRS.copy(MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER), in_node, "OPER");
    MTIVLOTHIS.HIST_DEL_FLAG = TRS.get_char(in_node, "HIST_DEL_FLAG"); 
    TRS.copy(MTIVLOTHIS.TRAN_CODE, sizeof(MTIVLOTHIS.TRAN_CODE), in_node, "TRAN_CODE");
    TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), in_node, "TRAN_CMF_1");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2), in_node, "TRAN_CMF_2");
	DBC_open_mtivlothis(i_step, &MTIVLOTHIS); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "INV-0004"); 
		TRS.add_fieldmsg(out_node, "MTIVLOTHIS OPEN", MP_NVST); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		DBC_fetch_mtivlothis(i_step, &MTIVLOTHIS); 
		if(DB_error_code != DB_SUCCESS)
		{
			DBC_close_mtivlothis(i_step); 
			break;
		}
		list_item = TRS.add_node(out_node, "LOT_HIST_LIST");
		TRS.add_string(list_item, "FACTORY", MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY));
		TRS.add_string(list_item, "LOT_ID", MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID));
		TRS.add_int(list_item, "LOT_GRP_SEQ", MTIVLOTHIS.LOT_GRP_SEQ);
		TRS.add_string(list_item, "TRAN_CODE", MTIVLOTHIS.TRAN_CODE, sizeof(MTIVLOTHIS.TRAN_CODE));
		TRS.add_string(list_item, "TRAN_TYPE", MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE));
		TRS.add_string(list_item, "TRAN_TIME", MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME));
		TRS.add_string(list_item, "SYS_TRAN_TIME", MTIVLOTHIS.SYS_TRAN_TIME, sizeof(MTIVLOTHIS.SYS_TRAN_TIME));
		TRS.add_string(list_item, "MAT_ID", MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID));
		TRS.add_int(list_item, "MAT_VER", MTIVLOTHIS.MAT_VER);
		TRS.add_string(list_item, "OPER", MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER));
		TRS.add_char(list_item, "LOT_TYPE", MTIVLOTHIS.LOT_TYPE);
		TRS.add_double(list_item, "QTY_1", MTIVLOTHIS.QTY_1);
		TRS.add_double(list_item, "QTY_2", MTIVLOTHIS.QTY_2);
		TRS.add_double(list_item, "QTY_3", MTIVLOTHIS.QTY_3);
		TRS.add_double(list_item, "CREATE_QTY_1", MTIVLOTHIS.CREATE_QTY_1);
		TRS.add_double(list_item, "CREATE_QTY_2", MTIVLOTHIS.CREATE_QTY_2);
		TRS.add_double(list_item, "CREATE_QTY_3", MTIVLOTHIS.CREATE_QTY_3);
		TRS.add_string(list_item, "CREATE_TIME", MTIVLOTHIS.CREATE_TIME, sizeof(MTIVLOTHIS.CREATE_TIME));
		TRS.add_char(list_item, "IN_OUT_FLAG", MTIVLOTHIS.IN_OUT_FLAG);
		TRS.add_string(list_item, "FROM_TO_LOT_ID", MTIVLOTHIS.FROM_TO_LOT_ID, sizeof(MTIVLOTHIS.FROM_TO_LOT_ID));
		TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTHIS.FROM_TO_HIST_SEQ);
		TRS.add_int(list_item, "FROM_TO_LOT_GRP_SEQ", MTIVLOTHIS.FROM_TO_LOT_GRP_SEQ);
		TRS.add_char(list_item, "FROM_TO_FLAG", MTIVLOTHIS.FROM_TO_FLAG);
		TRS.add_double(list_item, "FROM_TO_QTY_1", MTIVLOTHIS.FROM_TO_QTY_1);
		TRS.add_double(list_item, "FROM_TO_QTY_2", MTIVLOTHIS.FROM_TO_QTY_2);
		TRS.add_double(list_item, "FROM_TO_QTY_3", MTIVLOTHIS.FROM_TO_QTY_3);
		TRS.add_string(list_item, "PROD_LOT_ID", MTIVLOTHIS.PROD_LOT_ID, sizeof(MTIVLOTHIS.PROD_LOT_ID));
		TRS.add_int(list_item, "PROD_HIST_SEQ", MTIVLOTHIS.PROD_HIST_SEQ);
		TRS.add_double(list_item, "PROD_QTY_1", MTIVLOTHIS.PROD_QTY_1);
		TRS.add_double(list_item, "PROD_QTY_2", MTIVLOTHIS.PROD_QTY_2);
		TRS.add_double(list_item, "PROD_QTY_3", MTIVLOTHIS.PROD_QTY_3);
		TRS.add_string(list_item, "ORDER_ID", MTIVLOTHIS.ORDER_ID, sizeof(MTIVLOTHIS.ORDER_ID));
		TRS.add_string(list_item, "LINE_NO", MTIVLOTHIS.LINE_NO, sizeof(MTIVLOTHIS.LINE_NO));
		TRS.add_string(list_item, "OLD_FACTORY", MTIVLOTHIS.OLD_FACTORY, sizeof(MTIVLOTHIS.OLD_FACTORY));
		TRS.add_string(list_item, "OLD_OPER", MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER));
		TRS.add_double(list_item, "OLD_QTY_1", MTIVLOTHIS.OLD_QTY_1);
		TRS.add_double(list_item, "OLD_QTY_2", MTIVLOTHIS.OLD_QTY_2);
		TRS.add_double(list_item, "OLD_QTY_3", MTIVLOTHIS.OLD_QTY_3);
		TRS.add_string(list_item, "UNIT_1", MTIVLOTHIS.UNIT_1, sizeof(MTIVLOTHIS.UNIT_1));
		TRS.add_string(list_item, "UNIT_2", MTIVLOTHIS.UNIT_2, sizeof(MTIVLOTHIS.UNIT_2));
		TRS.add_string(list_item, "UNIT_3", MTIVLOTHIS.UNIT_3, sizeof(MTIVLOTHIS.UNIT_3));
		TRS.add_char(list_item, "INSPECTION_FLAG", MTIVLOTHIS.INSPECTION_FLAG);
		TRS.add_char(list_item, "INSPECTION_RESULT", MTIVLOTHIS.INSPECTION_RESULT);
		TRS.add_string(list_item, "TRAN_COMMENT", MTIVLOTHIS.TRAN_COMMENT, sizeof(MTIVLOTHIS.TRAN_COMMENT));
		TRS.add_string(list_item, "TRAN_USER_ID", MTIVLOTHIS.TRAN_USER_ID, sizeof(MTIVLOTHIS.TRAN_USER_ID));
		TRS.add_char(list_item, "LOT_DEL_FLAG", MTIVLOTHIS.LOT_DEL_FLAG);
		TRS.add_string(list_item, "LOT_DEL_USER_ID", MTIVLOTHIS.LOT_DEL_USER_ID, sizeof(MTIVLOTHIS.LOT_DEL_USER_ID));
		TRS.add_string(list_item, "LOT_DEL_TIME", MTIVLOTHIS.LOT_DEL_TIME, sizeof(MTIVLOTHIS.LOT_DEL_TIME));
		TRS.add_string(list_item, "LOT_DEL_REASON", MTIVLOTHIS.LOT_DEL_REASON, sizeof(MTIVLOTHIS.LOT_DEL_REASON));
		TRS.add_char(list_item, "HIST_DEL_FLAG", MTIVLOTHIS.HIST_DEL_FLAG);
		TRS.add_string(list_item, "HIST_DEL_USER_ID", MTIVLOTHIS.HIST_DEL_USER_ID, sizeof(MTIVLOTHIS.HIST_DEL_USER_ID));
		TRS.add_string(list_item, "HIST_DEL_TIME", MTIVLOTHIS.HIST_DEL_TIME, sizeof(MTIVLOTHIS.HIST_DEL_TIME));
		TRS.add_string(list_item, "LOCATION_NO", MTIVLOTHIS.LOCATION_NO, sizeof(MTIVLOTHIS.LOCATION_NO));
		TRS.add_char(list_item, "HOLD_FLAG", MTIVLOTHIS.HOLD_FLAG);
		TRS.add_string(list_item, "HOLD_CODE", MTIVLOTHIS.HOLD_CODE, sizeof(MTIVLOTHIS.HOLD_CODE));
		TRS.add_string(list_item, "RELEASE_CODE", MTIVLOTHIS.RELEASE_CODE, sizeof(MTIVLOTHIS.RELEASE_CODE));
		TRS.add_char(list_item, "PICK_FLAG", MTIVLOTHIS.PICK_FLAG);
		TRS.add_char(list_item, "SHIP_FLAG", MTIVLOTHIS.SHIP_FLAG);
		TRS.add_string(list_item, "GRADE", MTIVLOTHIS.GRADE, sizeof(MTIVLOTHIS.GRADE));
		TRS.add_string(list_item, "ADD_ORDER_ID_1", MTIVLOTHIS.ADD_ORDER_ID_1, sizeof(MTIVLOTHIS.ADD_ORDER_ID_1));
		TRS.add_string(list_item, "ADD_ORDER_LINE_1", MTIVLOTHIS.ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_1));
		TRS.add_string(list_item, "ADD_ORDER_ID_2", MTIVLOTHIS.ADD_ORDER_ID_2, sizeof(MTIVLOTHIS.ADD_ORDER_ID_2));
		TRS.add_string(list_item, "ADD_ORDER_LINE_2", MTIVLOTHIS.ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_2));
		TRS.add_string(list_item, "ADD_ORDER_ID_3", MTIVLOTHIS.ADD_ORDER_ID_3, sizeof(MTIVLOTHIS.ADD_ORDER_ID_3));
		TRS.add_string(list_item, "ADD_ORDER_LINE_3", MTIVLOTHIS.ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_3));
		TRS.add_string(list_item, "VENDOR_LOT_ID", MTIVLOTHIS.VENDOR_LOT_ID, sizeof(MTIVLOTHIS.VENDOR_LOT_ID));
		TRS.add_string(list_item, "PO_MAT_ID", MTIVLOTHIS.PO_MAT_ID, sizeof(MTIVLOTHIS.PO_MAT_ID));
		TRS.add_int(list_item, "PO_SEQ_NUM", MTIVLOTHIS.PO_SEQ_NUM);
		TRS.add_string(list_item, "INV_CMF_1", MTIVLOTHIS.INV_CMF_1, sizeof(MTIVLOTHIS.INV_CMF_1));
		TRS.add_string(list_item, "INV_CMF_2", MTIVLOTHIS.INV_CMF_2, sizeof(MTIVLOTHIS.INV_CMF_2));
		TRS.add_string(list_item, "INV_CMF_3", MTIVLOTHIS.INV_CMF_3, sizeof(MTIVLOTHIS.INV_CMF_3));
		TRS.add_string(list_item, "INV_CMF_4", MTIVLOTHIS.INV_CMF_4, sizeof(MTIVLOTHIS.INV_CMF_4));
		TRS.add_string(list_item, "INV_CMF_5", MTIVLOTHIS.INV_CMF_5, sizeof(MTIVLOTHIS.INV_CMF_5));
		TRS.add_string(list_item, "INV_CMF_6", MTIVLOTHIS.INV_CMF_6, sizeof(MTIVLOTHIS.INV_CMF_6));
		TRS.add_string(list_item, "INV_CMF_7", MTIVLOTHIS.INV_CMF_7, sizeof(MTIVLOTHIS.INV_CMF_7));
		TRS.add_string(list_item, "INV_CMF_8", MTIVLOTHIS.INV_CMF_8, sizeof(MTIVLOTHIS.INV_CMF_8));
		TRS.add_string(list_item, "INV_CMF_9", MTIVLOTHIS.INV_CMF_9, sizeof(MTIVLOTHIS.INV_CMF_9));
		TRS.add_string(list_item, "INV_CMF_10", MTIVLOTHIS.INV_CMF_10, sizeof(MTIVLOTHIS.INV_CMF_10));
		TRS.add_string(list_item, "INV_CMF_11", MTIVLOTHIS.INV_CMF_11, sizeof(MTIVLOTHIS.INV_CMF_11));
		TRS.add_string(list_item, "INV_CMF_12", MTIVLOTHIS.INV_CMF_12, sizeof(MTIVLOTHIS.INV_CMF_12));
		TRS.add_string(list_item, "INV_CMF_13", MTIVLOTHIS.INV_CMF_13, sizeof(MTIVLOTHIS.INV_CMF_13));
		TRS.add_string(list_item, "INV_CMF_14", MTIVLOTHIS.INV_CMF_14, sizeof(MTIVLOTHIS.INV_CMF_14));
		TRS.add_string(list_item, "INV_CMF_15", MTIVLOTHIS.INV_CMF_15, sizeof(MTIVLOTHIS.INV_CMF_15));
		TRS.add_string(list_item, "INV_CMF_16", MTIVLOTHIS.INV_CMF_16, sizeof(MTIVLOTHIS.INV_CMF_16));
		TRS.add_string(list_item, "INV_CMF_17", MTIVLOTHIS.INV_CMF_17, sizeof(MTIVLOTHIS.INV_CMF_17));
		TRS.add_string(list_item, "INV_CMF_18", MTIVLOTHIS.INV_CMF_18, sizeof(MTIVLOTHIS.INV_CMF_18));
		TRS.add_string(list_item, "INV_CMF_19", MTIVLOTHIS.INV_CMF_19, sizeof(MTIVLOTHIS.INV_CMF_19));
		TRS.add_string(list_item, "INV_CMF_20", MTIVLOTHIS.INV_CMF_20, sizeof(MTIVLOTHIS.INV_CMF_20));
		TRS.add_string(list_item, "OWNER_CODE", MTIVLOTHIS.OWNER_CODE, sizeof(MTIVLOTHIS.OWNER_CODE));
		TRS.add_string(list_item, "VENDOR_ID", MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID));
		TRS.add_string(list_item, "FROM_TO_OPER", MTIVLOTHIS.FROM_TO_OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
		TRS.add_string(list_item, "OLD_LOCATION_NO", MTIVLOTHIS.OLD_LOCATION_NO, sizeof(MTIVLOTHIS.OLD_LOCATION_NO));
		TRS.add_int(list_item, "HIST_SEQ", MTIVLOTHIS.HIST_SEQ);
		TRS.add_string(list_item, "LOT_GROUP_ID", MTIVLOTHIS.LOT_GROUP_ID, sizeof(MTIVLOTHIS.LOT_GROUP_ID));
		TRS.add_string(list_item, "EXPIRE_DATE", MTIVLOTHIS.EXPIRE_DATE, sizeof(MTIVLOTHIS.EXPIRE_DATE));
		TRS.add_string(list_item, "INV_IN_TIME", MTIVLOTHIS.INV_IN_TIME, sizeof(MTIVLOTHIS.INV_IN_TIME));
		TRS.add_string(list_item, "INV_OUT_TIME", MTIVLOTHIS.INV_OUT_TIME, sizeof(MTIVLOTHIS.INV_OUT_TIME));
		TRS.add_string(list_item, "OINV_IN_TIME", MTIVLOTHIS.OINV_IN_TIME, sizeof(MTIVLOTHIS.OINV_IN_TIME));
		TRS.add_string(list_item, "OINV_OUT_TIME", MTIVLOTHIS.OINV_OUT_TIME, sizeof(MTIVLOTHIS.OINV_OUT_TIME));
		TRS.add_string(list_item, "WIP_IN_TIME", MTIVLOTHIS.WIP_IN_TIME, sizeof(MTIVLOTHIS.WIP_IN_TIME));
		TRS.add_string(list_item, "WIP_OUT_TIME", MTIVLOTHIS.WIP_OUT_TIME, sizeof(MTIVLOTHIS.WIP_OUT_TIME));
		TRS.add_string(list_item, "TRAN_CMF_1", MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
		TRS.add_string(list_item, "TRAN_CMF_2", MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2));
		TRS.add_string(list_item, "TRAN_CMF_3", MTIVLOTHIS.TRAN_CMF_3, sizeof(MTIVLOTHIS.TRAN_CMF_3));
		TRS.add_string(list_item, "TRAN_CMF_4", MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVLOTHIS.TRAN_CMF_4));
		TRS.add_string(list_item, "TRAN_CMF_5", MTIVLOTHIS.TRAN_CMF_5, sizeof(MTIVLOTHIS.TRAN_CMF_5));
		TRS.add_string(list_item, "TRAN_CMF_6", MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6));
		TRS.add_string(list_item, "TRAN_CMF_7", MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7));
		TRS.add_string(list_item, "TRAN_CMF_8", MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8));
		TRS.add_string(list_item, "TRAN_CMF_9", MTIVLOTHIS.TRAN_CMF_9, sizeof(MTIVLOTHIS.TRAN_CMF_9));
		TRS.add_string(list_item, "TRAN_CMF_10", MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10));
		TRS.add_string(list_item, "TRAN_CMF_11", MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11));
		TRS.add_string(list_item, "TRAN_CMF_12", MTIVLOTHIS.TRAN_CMF_12, sizeof(MTIVLOTHIS.TRAN_CMF_12));
		TRS.add_string(list_item, "TRAN_CMF_13", MTIVLOTHIS.TRAN_CMF_13, sizeof(MTIVLOTHIS.TRAN_CMF_13));
		TRS.add_string(list_item, "TRAN_CMF_14", MTIVLOTHIS.TRAN_CMF_14, sizeof(MTIVLOTHIS.TRAN_CMF_14));
		TRS.add_string(list_item, "TRAN_CMF_15", MTIVLOTHIS.TRAN_CMF_15, sizeof(MTIVLOTHIS.TRAN_CMF_15));
		TRS.add_string(list_item, "TRAN_CMF_16", MTIVLOTHIS.TRAN_CMF_16, sizeof(MTIVLOTHIS.TRAN_CMF_16));
		TRS.add_string(list_item, "TRAN_CMF_17", MTIVLOTHIS.TRAN_CMF_17, sizeof(MTIVLOTHIS.TRAN_CMF_17));
		TRS.add_string(list_item, "TRAN_CMF_18", MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18));
		TRS.add_string(list_item, "TRAN_CMF_19", MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19));
		TRS.add_string(list_item, "TRAN_CMF_20", MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20));

		TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTHIS.FROM_TO_HIST_SEQ);
        TRS.add_string(list_item, "CREATE_CODE", MTIVLOTHIS.CREATE_CODE, sizeof(MTIVLOTHIS.CREATE_CODE));
        TRS.add_string(list_item, "INV_CMF_21", MTIVLOTHIS.INV_CMF_21, sizeof(MTIVLOTHIS.INV_CMF_21));
        TRS.add_string(list_item, "INV_CMF_22", MTIVLOTHIS.INV_CMF_22, sizeof(MTIVLOTHIS.INV_CMF_22));
        TRS.add_string(list_item, "INV_CMF_23", MTIVLOTHIS.INV_CMF_23, sizeof(MTIVLOTHIS.INV_CMF_23));
        TRS.add_string(list_item, "INV_CMF_24", MTIVLOTHIS.INV_CMF_24, sizeof(MTIVLOTHIS.INV_CMF_24));
        TRS.add_string(list_item, "INV_CMF_25", MTIVLOTHIS.INV_CMF_25, sizeof(MTIVLOTHIS.INV_CMF_25));
        TRS.add_string(list_item, "INV_CMF_26", MTIVLOTHIS.INV_CMF_26, sizeof(MTIVLOTHIS.INV_CMF_26));
        TRS.add_string(list_item, "INV_CMF_27", MTIVLOTHIS.INV_CMF_27, sizeof(MTIVLOTHIS.INV_CMF_27));
        TRS.add_string(list_item, "INV_CMF_28", MTIVLOTHIS.INV_CMF_28, sizeof(MTIVLOTHIS.INV_CMF_28));
        TRS.add_string(list_item, "INV_CMF_29", MTIVLOTHIS.INV_CMF_29, sizeof(MTIVLOTHIS.INV_CMF_29));
        TRS.add_string(list_item, "INV_CMF_30", MTIVLOTHIS.INV_CMF_30, sizeof(MTIVLOTHIS.INV_CMF_30));
        TRS.add_char(list_item, "INV_FLAG_1", MTIVLOTHIS.INV_FLAG_1);
        TRS.add_char(list_item, "INV_FLAG_2", MTIVLOTHIS.INV_FLAG_2);
        TRS.add_char(list_item, "INV_FLAG_3", MTIVLOTHIS.INV_FLAG_3);
        TRS.add_char(list_item, "INV_FLAG_4", MTIVLOTHIS.INV_FLAG_4);
        TRS.add_char(list_item, "INV_FLAG_5", MTIVLOTHIS.INV_FLAG_5);
        TRS.add_string(list_item, "ERP_CREATE_DATE", MTIVLOTHIS.ERP_CREATE_DATE, sizeof(MTIVLOTHIS.ERP_CREATE_DATE));
        TRS.add_string(list_item, "ERP_INV_IN_DATE", MTIVLOTHIS.ERP_INV_IN_DATE, sizeof(MTIVLOTHIS.ERP_INV_IN_DATE));
        TRS.add_string(list_item, "ERP_OINV_IN_DATE", MTIVLOTHIS.ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS.ERP_OINV_IN_DATE));
        TRS.add_string(list_item, "ERP_TRAN_DATE", MTIVLOTHIS.ERP_TRAN_DATE, sizeof(MTIVLOTHIS.ERP_TRAN_DATE));


	}

	if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_History_List",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 