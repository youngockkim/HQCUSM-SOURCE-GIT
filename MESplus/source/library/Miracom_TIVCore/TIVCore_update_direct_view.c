/******************************************************************************'

	System      : MESplus
	Module      : TAPCore
	File Name   : TAPCore_update_direct_view.c
	Description : Direct_view Setup function module

	MES Version : 5.2.0

	Function List
		- TAP_Update_Direct_View()
			+ Create/Update/Delete Direct_view definition
		- TAP_UPDATE_DIRECT_VIEW()
			+ Main sub function of TAP_Update_Direct_View function
			+ Create/Update/Delete Direct_view definition
		- TAP_Update_Direct_View_Validation()
			+ Main sub function of TAP_UPDATE_DIRECT_VIEW function
			+ Check the condition for create/update/delete Direct_view
	Detail Description
		- TAP_UPDATE_DIRECT_VIEW()
			+ h_proc_step
				+ MP_STEP_CREATE : Create Direct_view definition
				+ MP_STEP_UPDATE : Update Direct_view definition
				+ MP_STEP_DELETE : Delete Direct_view definition

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

int TAP_Update_Direct_View_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node);

/*******************************************************************************
	TAP_Update_Direct_View()
		- Create/Update/Delete Direct_view definition
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_Update_Direct_View(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TAP_UPDATE_DIRECT_VIEW(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TAP_UPDATE_DIRECT_VIEW", out_node);

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
	TAP_UPDATE_DIRECT_VIEW()
		- Main sub function of "TAP_Update_Direct_View" function
		- Create/Update/Delete Direct_view definition
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_UPDATE_DIRECT_VIEW(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTAPSQLDEF_TAG MTAPSQLDEF;
	struct MTAPSQLDEF_TAG MTAPSQLDEF_o;
    struct MTAPDVWHDR_TAG MTAPDVWHDR;
    struct MTAPDVWCND_TAG MTAPDVWCND;

	LOG_head("TAP_Update_Direct_View");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("view_id", MP_NSTR, TRS.get_string(in_node, "VIEW_ID"));
	LOG_add("view_desc", MP_NSTR, TRS.get_string(in_node, "VIEW_DESC"));
	LOG_add("sql_1", MP_NSTR, TRS.get_string(in_node, "SQL_1"));
	LOG_add("sql_2", MP_NSTR, TRS.get_string(in_node, "SQL_2"));
	LOG_add("sql_3", MP_NSTR, TRS.get_string(in_node, "SQL_3"));
	LOG_add("sql_4", MP_NSTR, TRS.get_string(in_node, "SQL_4"));
	LOG_add("sql_5", MP_NSTR, TRS.get_string(in_node, "SQL_5"));
	LOG_add("sql_6", MP_NSTR, TRS.get_string(in_node, "SQL_6"));
	LOG_add("sql_7", MP_NSTR, TRS.get_string(in_node, "SQL_7"));
	LOG_add("sql_8", MP_NSTR, TRS.get_string(in_node, "SQL_8"));
	LOG_add("sql_9", MP_NSTR, TRS.get_string(in_node, "SQL_9"));
	LOG_add("sql_10", MP_NSTR, TRS.get_string(in_node, "SQL_10"));
	LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
	LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
	LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
	LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("TIV", "TAP_Update_Direct_View",
							 MP_UPOINT_BEFORE,
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 

	if(TAP_Update_Direct_View_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	DBC_init_mtapsqldef(&MTAPSQLDEF);
	TRS.copy(MTAPSQLDEF.VIEW_ID, sizeof(MTAPSQLDEF.VIEW_ID), in_node, "VIEW_ID");
	TRS.copy(MTAPSQLDEF.VIEW_DESC, sizeof(MTAPSQLDEF.VIEW_DESC), in_node, "VIEW_DESC");
	TRS.copy(MTAPSQLDEF.SQL_1, sizeof(MTAPSQLDEF.SQL_1), in_node, "SQL_1");
	TRS.copy(MTAPSQLDEF.SQL_2, sizeof(MTAPSQLDEF.SQL_2), in_node, "SQL_2");
	TRS.copy(MTAPSQLDEF.SQL_3, sizeof(MTAPSQLDEF.SQL_3), in_node, "SQL_3");
	TRS.copy(MTAPSQLDEF.SQL_4, sizeof(MTAPSQLDEF.SQL_4), in_node, "SQL_4");
	TRS.copy(MTAPSQLDEF.SQL_5, sizeof(MTAPSQLDEF.SQL_5), in_node, "SQL_5");
	TRS.copy(MTAPSQLDEF.SQL_6, sizeof(MTAPSQLDEF.SQL_6), in_node, "SQL_6");
	TRS.copy(MTAPSQLDEF.SQL_7, sizeof(MTAPSQLDEF.SQL_7), in_node, "SQL_7");
	TRS.copy(MTAPSQLDEF.SQL_8, sizeof(MTAPSQLDEF.SQL_8), in_node, "SQL_8");
	TRS.copy(MTAPSQLDEF.SQL_9, sizeof(MTAPSQLDEF.SQL_9), in_node, "SQL_9");
	TRS.copy(MTAPSQLDEF.SQL_10, sizeof(MTAPSQLDEF.SQL_10), in_node, "SQL_10");
	TRS.copy(MTAPSQLDEF.CREATE_TIME, sizeof(MTAPSQLDEF.CREATE_TIME), in_node, "CREATE_TIME");
	TRS.copy(MTAPSQLDEF.CREATE_USER_ID, sizeof(MTAPSQLDEF.CREATE_USER_ID), in_node, "CREATE_USER_ID");
	TRS.copy(MTAPSQLDEF.UPDATE_TIME, sizeof(MTAPSQLDEF.UPDATE_TIME), in_node, "UPDATE_TIME");
	TRS.copy(MTAPSQLDEF.UPDATE_USER_ID, sizeof(MTAPSQLDEF.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");

	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{

		//----[Addtional Logic for Create Case]----
		TRS.copy(MTAPSQLDEF.CREATE_USER_ID, sizeof(MTAPSQLDEF.CREATE_USER_ID), in_node, IN_USERID);
		DB_get_systime(MTAPSQLDEF.CREATE_TIME); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}

		DBC_insert_mtapsqldef(&MTAPSQLDEF); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPSQLDEF INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 
	}
	else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
	{
		DBC_init_mtapsqldef(&MTAPSQLDEF_o); 
		TRS.copy(MTAPSQLDEF_o.VIEW_ID, sizeof(MTAPSQLDEF_o.VIEW_ID), in_node, "VIEW_ID");
		DBC_select_mtapsqldef_for_update(1, &MTAPSQLDEF_o);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPSQLDEF SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 

		//----[Addtional Logic for Create Case]----
		memcpy(MTAPSQLDEF.CREATE_USER_ID, MTAPSQLDEF_o.CREATE_USER_ID, sizeof(MTAPSQLDEF.CREATE_USER_ID)); 
		memcpy(MTAPSQLDEF.CREATE_TIME, MTAPSQLDEF_o.CREATE_TIME, sizeof(MTAPSQLDEF.CREATE_TIME));
		TRS.copy(MTAPSQLDEF.UPDATE_USER_ID, sizeof(MTAPSQLDEF.UPDATE_USER_ID), in_node, IN_USERID);
		DB_get_systime(MTAPSQLDEF.UPDATE_TIME); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 

		DBC_update_mtapsqldef(1, &MTAPSQLDEF);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPSQLDEF UPDATE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 
	}
	else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
	{
		DBC_delete_mtapsqldef(1, &MTAPSQLDEF);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPSQLDEF DELETE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
        DBC_init_mtapdvwhdr(&MTAPDVWHDR);
        memcpy(MTAPDVWHDR.VIEW_ID, MTAPSQLDEF.VIEW_ID, sizeof(MTAPDVWHDR.VIEW_ID));
        DBC_delete_mtapdvwhdr(2, &MTAPDVWHDR);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVWHDR DELETE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
        DBC_init_mtapdvwcnd(&MTAPDVWCND);
        memcpy(MTAPDVWCND.VIEW_ID, MTAPSQLDEF.VIEW_ID, sizeof(MTAPDVWCND.VIEW_ID));
        DBC_delete_mtapdvwcnd(2, &MTAPDVWCND);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVWCND DELETE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}

	}

	if(COM_proc_user_routine("TIV", "TAP_Update_Direct_View",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	TAP_Update_Direct_View_Validation()
		- Main sub function of "TAP_UPDATE_DIRECT_VIEW" function
		- Check the condition for create/update/delete Direct_view & vbCrLf	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_Update_Direct_View_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct MTAPSQLDEF_TAG MTAPSQLDEF;
	struct MWIPFACDEF_TAG MWIPFACDEF;

	//int i_count = 0;

	/* ProcStep Validation */
	if(COM_service_validation(s_msg_code,
							in_node,
							out_node,
							TRS.get_procstep(in_node),
							"IUD") == MP_FALSE)
	{
		return MP_FALSE;
	}

	/* Factory Validation */
	if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		strcpy(s_msg_code, "TAP-0001");
		TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		return MP_FALSE;
	}
	else
	{
		DBC_init_mwipfacdef(&MWIPFACDEF);
		TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
		DBC_select_mwipfacdef(1, &MWIPFACDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0005");
			TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			return MP_FALSE;
		}
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
	DBC_select_mtapsqldef(1, &MTAPSQLDEF); 
	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{
		if(DB_error_code == DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-XXXX"); 
			TRS.add_fieldmsg(out_node, "MTAPSQLDEF SELECT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
	}
	else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE ||
			TRS.get_procstep(in_node) == MP_STEP_DELETE) 
	{
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "TAP-XXXX"); 
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
			}
			else
			{
				strcpy(s_msg_code, "TAP-0004"); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}

			TRS.add_fieldmsg(out_node, "MTAPSQLDEF SELECT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPSQLDEF.VIEW_ID), MTAPSQLDEF.VIEW_ID); 

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			return MP_FALSE;
		}
	}
	return MP_TRUE;
}