/******************************************************************************'

	System      : MESplus
	Module      : INVCore
	File Name   : INVCore_view_inv_view_transfer_history_list.c
	Description : View Inv_view_transfer_history List function module

	MES Version : 5.2.0

	Function List
		- TIV_View_Inv_view_transfer_history_List()
			+ View Inv_view_transfer_history definition List
		- TIV_VIEW_TIV_VIEW_TRANSFER_HISTORY_LIST()
			+ Main sub function of TIV_View_Inv_view_transfer_history_List function
			+ View Inv_view_transfer_history definition List
	Detail Description
		- TIV_VIEW_TIV_VIEW_TRANSFER_HISTORY()
			+ h_proc_step
				+ 1 : View Inv_view_transfer_history definition List by Primary Key
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

/*******************************************************************************
	TIV_View_Inv_view_transfer_history_List()
		- View Inv_view_transfer_history definition List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Transfer_History(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TIV_VIEW_TRANSFER_HISTORY(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TIV_VIEW_TRANSFER_HISTORY", out_node);

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
	TIV_VIEW_TIV_VIEW_TRANSFER_HISTORY_LIST()
		- Main sub function of "TIV_View_Inv_view_transfer_history_List" function
		- View Inv_view_transfer_history definition List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_TRANSFER_HISTORY(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTIVTRSHIS_TAG MTIVTRSHIS;
    struct MTIVMATDEF_TAG MTIVMATDEF;
	struct MTIVTRSMST_TAG MTIVTRSMST;
	TRSNode *list_item;

	int i_step = 0;

	LOG_head("TIV_View_Transfer_History");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("hist_seq", MP_INT, TRS.get_int(in_node, "HIST_SEQ "));
	LOG_add("factory", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
	LOG_add("trs_no", MP_NSTR, TRS.get_string(in_node, "TRS_NO"));
	LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer_History",
							 MP_UPOINT_BEFORE,
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 

	/* ProcStep Validation */
	if(COM_service_validation(s_msg_code, in_node, out_node, TRS.get_procstep(in_node), "123") == MP_FALSE) 
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}



	/* Hist_seq Validation */
	/*if(TRS.get_int(in_node, "HIST_SEQ")==0)
	{
		strcpy(s_msg_code, "INV-0001");
		TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}*/
	/* Factory Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
	{
		strcpy(s_msg_code, "INV-0001");
		TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* Trs_no Validation */
	/*if(COM_isnullspace(TRS.get_string(in_node, "TRS_NO")) == MP_TRUE)
	{
		strcpy(s_msg_code, "INV-0001");
		TRS.add_fieldmsg(out_node, "TRS_NO", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}*/
	/* Lot_id Validation */
	/*if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "INV-0001");
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}*/

    if(TRS.get_procstep(in_node)=='1')
	    i_step = 1;
    else if(TRS.get_procstep(in_node) == '2')
        i_step = 2;
	else if(TRS.get_procstep(in_node) == '3')
		i_step = 3;

	DBC_init_mtivtrshis(&MTIVTRSHIS);
	MTIVTRSHIS.HIST_SEQ  = TRS.get_char(in_node, "HIST_SEQ"); 
	TRS.copy(MTIVTRSHIS.FACTORY, sizeof(MTIVTRSHIS.FACTORY), in_node, "FACTORY");
	TRS.copy(MTIVTRSHIS.TRS_NO, sizeof(MTIVTRSHIS.TRS_NO), in_node, "TRS_NO");
	TRS.copy(MTIVTRSHIS.LOT_ID, sizeof(MTIVTRSHIS.LOT_ID), in_node, "LOT_ID");
    TRS.copy(MTIVTRSHIS.MAT_ID, sizeof(MTIVTRSHIS.MAT_ID), in_node, "MAT_ID");
    MTIVTRSHIS.MAT_VER = TRS.get_int(in_node, "MAT_VER");
    TRS.copy(MTIVTRSHIS.FROM_OPER, sizeof(MTIVTRSHIS.FROM_OPER), in_node, "FROM_OPER");
    TRS.copy(MTIVTRSHIS.TO_OPER, sizeof(MTIVTRSHIS.TO_OPER), in_node, "TO_OPER");
    TRS.copy(MTIVTRSHIS.FROM_LOCATION_NO, sizeof(MTIVTRSHIS.FROM_LOCATION_NO), in_node, "FROM_LOCATION_NO");
    TRS.copy(MTIVTRSHIS.TO_LOCATION_NO, sizeof(MTIVTRSHIS.TO_LOCATION_NO), in_node, "TO_LOCATION_NO");
    DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_TIME, sizeof(DBC_Q_COND.FROM_TIME), in_node, "FROM_TIME");
    TRS.copy(DBC_Q_COND.TO_TIME, sizeof(DBC_Q_COND.TO_TIME), in_node, "TO_TIME");
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

	DBC_open_mtivtrshis(i_step, &MTIVTRSHIS); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "INV-0004"); 
		TRS.add_fieldmsg(out_node, "MTIVTRSHIS OPEN", MP_NVST); 
		TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVTRSHIS.HIST_SEQ); 
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSHIS.FACTORY), MTIVTRSHIS.FACTORY); 
		TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSHIS.TRS_NO), MTIVTRSHIS.TRS_NO); 
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSHIS.LOT_ID), MTIVTRSHIS.LOT_ID); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		DBC_fetch_mtivtrshis(i_step, &MTIVTRSHIS); 
		if(DB_error_code != DB_SUCCESS)
		{
			DBC_close_mtivtrshis(i_step); 
			break;
		}
		list_item = TRS.add_node(out_node, "LIST");
		TRS.add_string(list_item, "CREATE_USER_ID", MTIVTRSHIS.CREATE_USER_ID, sizeof(MTIVTRSHIS.CREATE_USER_ID));
		TRS.add_string(list_item, "CREATE_TIME", MTIVTRSHIS.CREATE_TIME, sizeof(MTIVTRSHIS.CREATE_TIME));
		TRS.add_int(list_item, "HIST_SEQ", MTIVTRSHIS.HIST_SEQ);
		TRS.add_string(list_item, "FACTORY", MTIVTRSHIS.FACTORY, sizeof(MTIVTRSHIS.FACTORY));
		TRS.add_string(list_item, "TRS_NO", MTIVTRSHIS.TRS_NO, sizeof(MTIVTRSHIS.TRS_NO));
		TRS.add_string(list_item, "LOT_ID", MTIVTRSHIS.LOT_ID, sizeof(MTIVTRSHIS.LOT_ID));
		TRS.add_string(list_item, "FROM_OPER", MTIVTRSHIS.FROM_OPER, sizeof(MTIVTRSHIS.FROM_OPER));
		TRS.add_string(list_item, "TO_OPER", MTIVTRSHIS.TO_OPER, sizeof(MTIVTRSHIS.TO_OPER));
		TRS.add_string(list_item, "FROM_LOCATION_NO", MTIVTRSHIS.FROM_LOCATION_NO, sizeof(MTIVTRSHIS.FROM_LOCATION_NO));
		TRS.add_string(list_item, "TO_LOCATION_NO", MTIVTRSHIS.TO_LOCATION_NO, sizeof(MTIVTRSHIS.TO_LOCATION_NO));
		TRS.add_string(list_item, "MAT_ID", MTIVTRSHIS.MAT_ID, sizeof(MTIVTRSHIS.MAT_ID));
		TRS.add_int(list_item, "MAT_VER", MTIVTRSHIS.MAT_VER);
		TRS.add_double(list_item, "QTY_1", MTIVTRSHIS.QTY_1);
		TRS.add_double(list_item, "QTY_2", MTIVTRSHIS.QTY_2);
		TRS.add_double(list_item, "QTY_3", MTIVTRSHIS.QTY_3);
		TRS.add_string(list_item, "UNIT_1", MTIVTRSHIS.UNIT_1, sizeof(MTIVTRSHIS.UNIT_1));
		TRS.add_string(list_item, "UNIT_2", MTIVTRSHIS.UNIT_2, sizeof(MTIVTRSHIS.UNIT_2));
		TRS.add_string(list_item, "UNIT_3", MTIVTRSHIS.UNIT_3, sizeof(MTIVTRSHIS.UNIT_3));

        /*Get Mat Desc*/
	    DBC_init_mtivmatdef(&MTIVMATDEF);
	    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
	    memcpy(MTIVMATDEF.MAT_ID, MTIVTRSHIS.MAT_ID, sizeof(MTIVTRSHIS.MAT_ID));
        MTIVMATDEF.MAT_VER = MTIVTRSHIS.MAT_VER;
	    DBC_select_mtivmatdef(1, &MTIVMATDEF);
	    if(DB_error_code != DB_SUCCESS) 
	    {
	        if(DB_error_code != DB_NOT_FOUND)
	        {
	            strcpy(s_msg_code, "INV-0004");
	            gs_log_type.e_type = MP_LOG_E_SYSTEM;
	            TRS.add_dberrmsg(out_node, DB_error_msg);

                TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
	            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
	            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);

	            gs_log_type.type = MP_LOG_ERROR;
	            gs_log_type.category = MP_LOG_CATE_VIEW;
	            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	            return MP_FALSE;
	        }
	    }

	    //Material Info
	    TRS.add_string(list_item, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));
        TRS.add_string(list_item, "MAT_SHORT_DESC", MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC));
        TRS.add_string(list_item, "BASE_MAT_ID", MTIVMATDEF.BASE_MAT_ID, sizeof(MTIVMATDEF.BASE_MAT_ID));

		if(TRS.get_procstep(in_node) == '3')
		{
			DBC_init_mtivtrsmst(&MTIVTRSMST);
			memcpy(MTIVTRSMST.FACTORY, MTIVTRSHIS.FACTORY, sizeof(MTIVTRSMST.FACTORY));
			memcpy(MTIVTRSMST.TRS_NO, MTIVTRSHIS.TRS_NO, sizeof(MTIVTRSMST.TRS_NO));
			DBC_select_mtivtrsmst(1, &MTIVTRSMST);

			TRS.set_enc_string(out_node, "CREATE_USER_ID", MTIVTRSMST.CREATE_USER_ID, sizeof(MTIVTRSMST.CREATE_USER_ID));
			TRS.set_string(out_node, "CREATE_TIME", MTIVTRSMST.CREATE_TIME, sizeof(MTIVTRSMST.CREATE_TIME));
			TRS.set_enc_string(out_node, "UPDATE_USER_ID", MTIVTRSMST.UPDATE_USER_ID, sizeof(MTIVTRSMST.UPDATE_USER_ID));
			TRS.set_string(out_node, "UPDATE_TIME", MTIVTRSMST.UPDATE_TIME, sizeof(MTIVTRSMST.UPDATE_TIME));
			TRS.set_string(out_node, "FACTORY", MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY));
			TRS.set_string(out_node, "TRS_NO", MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO));
			TRS.set_string(out_node, "TRS_USER", MTIVTRSMST.TRS_USER, sizeof(MTIVTRSMST.TRS_USER));
			TRS.set_string(out_node, "INV_USER", MTIVTRSMST.INV_USER, sizeof(MTIVTRSMST.INV_USER));
			TRS.set_string(out_node, "TRS_DATE_TIME", MTIVTRSMST.TRS_DATE_TIME, sizeof(MTIVTRSMST.TRS_DATE_TIME));
			TRS.set_char(out_node, "TRS_PRIORITY", MTIVTRSMST.TRS_PRIORITY);
			TRS.set_char(out_node, "STATUS_FLAG", MTIVTRSMST.STATUS_FLAG);
			TRS.set_string(out_node, "TRS_COMMENT", MTIVTRSMST.TRS_COMMENT, sizeof(MTIVTRSMST.TRS_COMMENT));
			TRS.set_string(out_node, "TRS_CMF_1", MTIVTRSMST.TRS_CMF_1, sizeof(MTIVTRSMST.TRS_CMF_1));
			TRS.set_string(out_node, "TRS_CMF_2", MTIVTRSMST.TRS_CMF_2, sizeof(MTIVTRSMST.TRS_CMF_2));
			TRS.set_string(out_node, "TRS_CMF_3", MTIVTRSMST.TRS_CMF_3, sizeof(MTIVTRSMST.TRS_CMF_3));
			TRS.set_string(out_node, "TRS_CMF_4", MTIVTRSMST.TRS_CMF_4, sizeof(MTIVTRSMST.TRS_CMF_4));
			TRS.set_string(out_node, "TRS_CMF_5", MTIVTRSMST.TRS_CMF_5, sizeof(MTIVTRSMST.TRS_CMF_5));
			TRS.set_string(out_node, "TRS_CMF_6", MTIVTRSMST.TRS_CMF_6, sizeof(MTIVTRSMST.TRS_CMF_6));
			TRS.set_string(out_node, "TRS_CMF_7", MTIVTRSMST.TRS_CMF_7, sizeof(MTIVTRSMST.TRS_CMF_7));
			TRS.set_string(out_node, "TRS_CMF_8", MTIVTRSMST.TRS_CMF_8, sizeof(MTIVTRSMST.TRS_CMF_8));
			TRS.set_string(out_node, "TRS_CMF_9", MTIVTRSMST.TRS_CMF_9, sizeof(MTIVTRSMST.TRS_CMF_9));
			TRS.set_string(out_node, "TRS_CMF_10", MTIVTRSMST.TRS_CMF_10, sizeof(MTIVTRSMST.TRS_CMF_10));
			TRS.set_string(out_node, "DELETE_TIME", MTIVTRSMST.DELETE_TIME, sizeof(MTIVTRSMST.DELETE_TIME));
			TRS.set_enc_string(out_node, "DELETE_USER_ID", MTIVTRSMST.DELETE_USER_ID, sizeof(MTIVTRSMST.DELETE_USER_ID));
			TRS.set_char(out_node, "DOC_TYPE", MTIVTRSMST.DOC_TYPE);
			TRS.set_char(out_node, "INV_FLAG", MTIVTRSMST.INV_FLAG);
			TRS.set_char(out_node, "OSP_FLAG", MTIVTRSMST.OSP_FLAG);
			TRS.set_char(out_node, "RT_FLAG", MTIVTRSMST.RT_FLAG);
			TRS.set_enc_string(out_node, "RT_REASON", MTIVTRSMST.RT_REASON, sizeof(MTIVTRSMST.RT_REASON));
		}
	}

	if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer_History",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 