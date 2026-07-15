/******************************************************************************'

	System      : MESplus
	Module      : TAPCore
	File Name   : TAPCore_view_direct_view_condition_list.c
	Description : View Direct_View_Condition List function module

	MES Version : 5.2.0

	Function List
		- TAP_View_Direct_View_Condition_List()
			+ View Direct_View_Condition definition List
		- TAP_VIEW_DIRECT_VIEW_CONDITION_LIST()
			+ Main sub function of TAP_View_Direct_View_Condition_List function
			+ View Direct_View_Condition definition List
	Detail Description
		- TAP_VIEW_DIRECT_VIEW_CONDITION()
			+ h_proc_step
				+ 1 : View Direct_View_Condition definition List by Primary Key
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

/*******************************************************************************
	TAP_View_Direct_View_Condition_List()
		- View Direct_View_Condition definition List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_View_Direct_View_Condition_List(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TAP_VIEW_DIRECT_VIEW_CONDITION_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TAP_VIEW_DIRECT_VIEW_CONDITION_LIST", out_node);

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
	TAP_VIEW_DIRECT_VIEW_CONDITION_LIST()
		- Main sub function of "TAP_View_Direct_View_Condition_List" function
		- View Direct_View_Condition definition List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_VIEW_DIRECT_VIEW_CONDITION_LIST(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTAPDVWCND_TAG MTAPDVWCND;
	struct MTAPSQLDEF_TAG MTAPSQLDEF;
	TRSNode *list_item;

	int i_step;

	LOG_head("TAP_View_Direct_View_Condition_List");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("view_id", MP_NSTR, TRS.get_string(in_node, "VIEW_ID"));
	LOG_add("cond_seq", MP_INT, TRS.get_int(in_node, "COND_SEQ"));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("TIV", "TAP_View_Direct_View_Condition_List",
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

	i_step = 1;

	/* View_id Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "VIEW_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "TAP-0001");
		TRS.add_fieldmsg(out_node, "VIEW_ID", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	DBC_init_mtapsqldef(&MTAPSQLDEF);
	TRS.copy(MTAPSQLDEF.VIEW_ID, sizeof(MTAPSQLDEF.VIEW_ID), in_node, "VIEW_ID");
	DBC_select_mtapsqldef(i_step, &MTAPSQLDEF); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "TAP-0004"); 
		TRS.add_fieldmsg(out_node, "MTAPSQLDEF SELECT", MP_NVST); 
		TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	TRS.add_string(out_node, "VIEW_ID", MTAPSQLDEF.VIEW_ID, sizeof(MTAPSQLDEF.VIEW_ID));
	TRS.add_string(out_node, "VIEW_DESC", MTAPSQLDEF.VIEW_DESC, sizeof(MTAPSQLDEF.VIEW_DESC));
	TRS.add_string(out_node, "SQL_1", MTAPSQLDEF.SQL_1, sizeof(MTAPSQLDEF.SQL_1));
	TRS.add_string(out_node, "SQL_2", MTAPSQLDEF.SQL_2, sizeof(MTAPSQLDEF.SQL_2));
	TRS.add_string(out_node, "SQL_3", MTAPSQLDEF.SQL_3, sizeof(MTAPSQLDEF.SQL_3));
	TRS.add_string(out_node, "SQL_4", MTAPSQLDEF.SQL_4, sizeof(MTAPSQLDEF.SQL_4));
	TRS.add_string(out_node, "SQL_5", MTAPSQLDEF.SQL_5, sizeof(MTAPSQLDEF.SQL_5));
	TRS.add_string(out_node, "SQL_6", MTAPSQLDEF.SQL_6, sizeof(MTAPSQLDEF.SQL_6));
	TRS.add_string(out_node, "SQL_7", MTAPSQLDEF.SQL_7, sizeof(MTAPSQLDEF.SQL_7));
	TRS.add_string(out_node, "SQL_8", MTAPSQLDEF.SQL_8, sizeof(MTAPSQLDEF.SQL_8));
	TRS.add_string(out_node, "SQL_9", MTAPSQLDEF.SQL_9, sizeof(MTAPSQLDEF.SQL_9));
	TRS.add_string(out_node, "SQL_10", MTAPSQLDEF.SQL_10, sizeof(MTAPSQLDEF.SQL_10));


	DBC_init_mtapdvwcnd(&MTAPDVWCND);
	TRS.copy(MTAPDVWCND.VIEW_ID, sizeof(MTAPDVWCND.VIEW_ID), in_node, "VIEW_ID");
	MTAPDVWCND.COND_SEQ  = TRS.get_int(in_node, "COND_SEQ"); 
	DBC_open_mtapdvwcnd(i_step, &MTAPDVWCND);   
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "TAP-0004"); 
		TRS.add_fieldmsg(out_node, "MTAPDVWCND OPEN", MP_NVST); 
		TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWCND.VIEW_ID), MTAPDVWCND.VIEW_ID); 
		TRS.add_fieldmsg(out_node, "COND_SEQ", MP_INT, MTAPDVWCND.COND_SEQ); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		DBC_fetch_mtapdvwcnd(i_step, &MTAPDVWCND); 
		if(DB_error_code != DB_SUCCESS)
		{
			DBC_close_mtapdvwcnd(i_step); 
			break;
		}
		list_item = TRS.add_node(out_node, "LIST");
		TRS.add_string(list_item, "VIEW_ID", MTAPDVWCND.VIEW_ID, sizeof(MTAPDVWCND.VIEW_ID));
		TRS.add_int(list_item, "COND_SEQ", MTAPDVWCND.COND_SEQ);
		TRS.add_string(list_item, "COND_NAME", MTAPDVWCND.COND_NAME, sizeof(MTAPDVWCND.COND_NAME));
		TRS.add_string(list_item, "COND_DESC", MTAPDVWCND.COND_DESC, sizeof(MTAPDVWCND.COND_DESC));
		TRS.add_char(list_item, "REQ_FLAG", MTAPDVWCND.REQ_FLAG);
		TRS.add_string(list_item, "DATA_TYPE", MTAPDVWCND.DATA_TYPE, sizeof(MTAPDVWCND.DATA_TYPE));
		TRS.add_string(list_item, "INPUT_TYPE", MTAPDVWCND.INPUT_TYPE, sizeof(MTAPDVWCND.INPUT_TYPE));
		TRS.add_string(list_item, "DATA_TBL", MTAPDVWCND.DATA_TBL, sizeof(MTAPDVWCND.DATA_TBL));
		TRS.add_string(list_item, "CREATE_TIME", MTAPDVWCND.CREATE_TIME, sizeof(MTAPDVWCND.CREATE_TIME));
		TRS.add_string(list_item, "CREATE_USER_ID", MTAPDVWCND.CREATE_USER_ID, sizeof(MTAPDVWCND.CREATE_USER_ID));
		TRS.add_string(list_item, "UPDATE_TIME", MTAPDVWCND.UPDATE_TIME, sizeof(MTAPDVWCND.UPDATE_TIME));
		TRS.add_string(list_item, "UPDATE_USER_ID", MTAPDVWCND.UPDATE_USER_ID, sizeof(MTAPDVWCND.UPDATE_USER_ID));
	}

	if(COM_proc_user_routine("TIV", "TAP_View_Direct_View_Condition_List",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 