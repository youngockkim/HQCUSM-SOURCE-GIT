/******************************************************************************'

	System      : MESplus
	Module      : TAPCore
	File Name   : TAPCore_view_direct_view.c
	Description : View Direct_view function module

	MES Version : 5.2.0

	Function List
		- TAP_View_Direct_View()
			+ View Direct_view definition
		- TAP_VIEW_DIRECT_VIEW()
			+ Main sub function of TAP_View_Direct_View function
			+ View Direct_view definition
	Detail Description
		- TAP_VIEW_DIRECT_VIEW()
			+ h_proc_step
				+ 1 : View Direct_view definition  by Primary Key
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

/*******************************************************************************
	TAP_View_Direct_View()
		- View Direct_view definition
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_View_Direct_View(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TAP_VIEW_DIRECT_VIEW(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TAP_VIEW_DIRECT_VIEW", out_node);

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
	TAP_VIEW_DIRECT_VIEW()
		- Main sub function of "TAP_View_Direct_View" function
		- View Direct_view definition
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_VIEW_DIRECT_VIEW(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTAPSQLDEF_TAG MTAPSQLDEF;
    //struct MTAPDVUHDR_TAG MTAPDVUHDR;
    struct MTAPDVWHDR_TAG MTAPDVWHDR;
	int i_step;

    TRSNode *list_item;


	i_step=1;

	LOG_head("TAP_View_Direct_View");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("view_id", MP_NSTR, TRS.get_string(in_node, "VIEW_ID"));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("TIV", "TAP_View_Direct_View",
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
	TRS.add_string(out_node, "CREATE_TIME", MTAPSQLDEF.CREATE_TIME, sizeof(MTAPSQLDEF.CREATE_TIME));
	TRS.add_string(out_node, "CREATE_USER_ID", MTAPSQLDEF.CREATE_USER_ID, sizeof(MTAPSQLDEF.CREATE_USER_ID));
	TRS.add_string(out_node, "UPDATE_TIME", MTAPSQLDEF.UPDATE_TIME, sizeof(MTAPSQLDEF.UPDATE_TIME));
	TRS.add_string(out_node, "UPDATE_USER_ID", MTAPSQLDEF.UPDATE_USER_ID, sizeof(MTAPSQLDEF.UPDATE_USER_ID));

   
    i_step=2;

    DBC_init_mtapdvwhdr(&MTAPDVWHDR);
	TRS.copy(MTAPDVWHDR.VIEW_ID, sizeof(MTAPDVWHDR.VIEW_ID), in_node, "VIEW_ID");
    TRS.copy(MTAPDVWHDR.COL_NAME, sizeof(MTAPDVWHDR.COL_NAME), in_node, IN_FACTORY);
    TRS.copy(MTAPDVWHDR.DISPLAY_NAME, sizeof(MTAPDVWHDR.DISPLAY_NAME), in_node, "USER_ID");
	DBC_open_mtapdvwhdr(i_step, &MTAPDVWHDR); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "TAP-0004"); 
		TRS.add_fieldmsg(out_node, "MTAPDVWHDR OPEN", MP_NVST); 
		TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWHDR.VIEW_ID), MTAPDVWHDR.VIEW_ID); 
		TRS.add_fieldmsg(out_node, "COL_NAME", MP_STR, sizeof(MTAPDVWHDR.COL_NAME), MTAPDVWHDR.COL_NAME); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		DBC_fetch_mtapdvwhdr(i_step, &MTAPDVWHDR); 
		if(DB_error_code != DB_SUCCESS)
		{
			DBC_close_mtapdvwhdr(i_step); 
			break;
		}
		list_item = TRS.add_node(out_node, "HEADER_LIST");
		TRS.add_string(list_item, "VIEW_ID", MTAPDVWHDR.VIEW_ID, sizeof(MTAPDVWHDR.VIEW_ID));
		TRS.add_string(list_item, "COL_NAME", MTAPDVWHDR.COL_NAME, sizeof(MTAPDVWHDR.COL_NAME));
        TRS.add_string(list_item, "DISPLAY_NAME", MTAPDVWHDR.DISPLAY_NAME, sizeof(MTAPDVWHDR.DISPLAY_NAME));

        if(COM_isspace(MTAPDVWHDR.DISPLAY_NAME, sizeof(MTAPDVWHDR.DISPLAY_NAME))==MP_TRUE)
            TRS.set_string(list_item, "DISPLAY_NAME", MTAPDVWHDR.COL_NAME, sizeof(MTAPDVWHDR.COL_NAME));

        TRS.add_string(list_item, "COL_DESC", MTAPDVWHDR.COL_DESC, sizeof(MTAPDVWHDR.COL_DESC));
		TRS.add_string(list_item, "CREATE_TIME", MTAPDVWHDR.CREATE_TIME, sizeof(MTAPDVWHDR.CREATE_TIME));
		TRS.add_string(list_item, "CREATE_USER_ID", MTAPDVWHDR.CREATE_USER_ID, sizeof(MTAPDVWHDR.CREATE_USER_ID));
		TRS.add_string(list_item, "UPDATE_TIME", MTAPDVWHDR.UPDATE_TIME, sizeof(MTAPDVWHDR.UPDATE_TIME));
		TRS.add_string(list_item, "UPDATE_USER_ID", MTAPDVWHDR.UPDATE_USER_ID, sizeof(MTAPDVWHDR.UPDATE_USER_ID));
	}

	if(COM_proc_user_routine("TIV", "TAP_View_Direct_View",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 