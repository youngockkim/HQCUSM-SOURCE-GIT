/******************************************************************************'

	System      : MESplus
	Module      : TAPCore
	File Name   : TAPCore_update_header_user.c
	Description : Header_User Setup function module

	MES Version : 5.2.0

	Function List
		- TAP_Update_Header_User()
			+ Create/Update/Delete Header_User definition
		- TAP_UPDATE_HEADER_USER()
			+ Main sub function of TAP_Update_Header_User function
			+ Create/Update/Delete Header_User definition
		- TAP_Update_Header_User_Validation()
			+ Main sub function of TAP_UPDATE_HEADER_USER function
			+ Check the condition for create/update/delete Header_User
	Detail Description
		- TAP_UPDATE_HEADER_USER()
			+ h_proc_step
				+ MP_STEP_CREATE : Create Header_User definition
				+ MP_STEP_UPDATE : Update Header_User definition
				+ MP_STEP_DELETE : Delete Header_User definition

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

int TAP_Update_Header_User_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node);

/*******************************************************************************
	TAP_Update_Header_User()
		- Create/Update/Delete Header_User definition
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_Update_Header_User(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TAP_UPDATE_HEADER_USER(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TAP_UPDATE_HEADER_USER", out_node);

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
	TAP_UPDATE_HEADER_USER()
		- Main sub function of "TAP_Update_Header_User" function
		- Create/Update/Delete Header_User definition
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_UPDATE_HEADER_USER(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTAPDVUHDR_TAG MTAPDVUHDR;
	struct MTAPDVUHDR_TAG MTAPDVUHDR_o;

	LOG_head("TAP_Update_Header_User");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("factory", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
	LOG_add("view_id", MP_NSTR, TRS.get_string(in_node, "VIEW_ID"));
	LOG_add("user_id", MP_NSTR, TRS.get_string(in_node, "USER_ID"));
	LOG_add("col_name", MP_NSTR, TRS.get_string(in_node, "COL_NAME"));
    LOG_add("col_seq", MP_INT, TRS.get_int(in_node, "COL_SEQ"));
	LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
	LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
	LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
	LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("TIV", "TAP_Update_Header_User",
							 MP_UPOINT_BEFORE,
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 

	if(TAP_Update_Header_User_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	DBC_init_mtapdvuhdr(&MTAPDVUHDR);
	TRS.copy(MTAPDVUHDR.FACTORY, sizeof(MTAPDVUHDR.FACTORY), in_node, "FACTORY");
	TRS.copy(MTAPDVUHDR.VIEW_ID, sizeof(MTAPDVUHDR.VIEW_ID), in_node, "VIEW_ID");
	TRS.copy(MTAPDVUHDR.USER_ID, sizeof(MTAPDVUHDR.USER_ID), in_node, "USER_ID");
	TRS.copy(MTAPDVUHDR.COL_NAME, sizeof(MTAPDVUHDR.COL_NAME), in_node, "COL_NAME");
    MTAPDVUHDR.COL_SEQ = TRS.get_int(in_node, "COL_SEQ");
	TRS.copy(MTAPDVUHDR.CREATE_TIME, sizeof(MTAPDVUHDR.CREATE_TIME), in_node, "CREATE_TIME");
	TRS.copy(MTAPDVUHDR.CREATE_USER_ID, sizeof(MTAPDVUHDR.CREATE_USER_ID), in_node, "CREATE_USER_ID");
	TRS.copy(MTAPDVUHDR.UPDATE_TIME, sizeof(MTAPDVUHDR.UPDATE_TIME), in_node, "UPDATE_TIME");
	TRS.copy(MTAPDVUHDR.UPDATE_USER_ID, sizeof(MTAPDVUHDR.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");

	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{

		//----[Addtional Logic for Create Case]----
		/*TRS.copy(MTAPDVUHDR.CREATE_USER_ID, sizeof(MTAPDVUHDR.CREATE_USER_ID), in_node, IN_USERID);
		DB_get_systime(MTAPDVUHDR.CREATE_TIME); 
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
		}*/

		DBC_insert_mtapdvuhdr(&MTAPDVUHDR); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVUHDR INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPDVUHDR.FACTORY), MTAPDVUHDR.FACTORY); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVUHDR.VIEW_ID), MTAPDVUHDR.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MTAPDVUHDR.USER_ID), MTAPDVUHDR.USER_ID); 
			TRS.add_fieldmsg(out_node, "COL_NAME", MP_STR, sizeof(MTAPDVUHDR.COL_NAME), MTAPDVUHDR.COL_NAME); 
            TRS.add_fieldmsg(out_node, "COL_SEQ", MP_INT, MTAPDVUHDR.COL_SEQ); 
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
		DBC_init_mtapdvuhdr(&MTAPDVUHDR_o); 
		TRS.copy(MTAPDVUHDR_o.FACTORY, sizeof(MTAPDVUHDR_o.FACTORY), in_node, "FACTORY");
		TRS.copy(MTAPDVUHDR_o.VIEW_ID, sizeof(MTAPDVUHDR_o.VIEW_ID), in_node, "VIEW_ID");
		TRS.copy(MTAPDVUHDR_o.USER_ID, sizeof(MTAPDVUHDR_o.USER_ID), in_node, "USER_ID");
		TRS.copy(MTAPDVUHDR_o.COL_NAME, sizeof(MTAPDVUHDR_o.COL_NAME), in_node, "COL_NAME");
        MTAPDVUHDR_o.COL_SEQ = TRS.get_int(in_node, "COL_SEQ");
		DBC_select_mtapdvuhdr_for_update(1, &MTAPDVUHDR_o);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVUHDR SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPDVUHDR.FACTORY), MTAPDVUHDR.FACTORY); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVUHDR.VIEW_ID), MTAPDVUHDR.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MTAPDVUHDR.USER_ID), MTAPDVUHDR.USER_ID); 
			TRS.add_fieldmsg(out_node, "COL_NAME", MP_STR, sizeof(MTAPDVUHDR.COL_NAME), MTAPDVUHDR.COL_NAME); 
            TRS.add_fieldmsg(out_node, "COL_SEQ", MP_INT, MTAPDVUHDR.COL_SEQ); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 

		//----[Addtional Logic for Create Case]----
		/*memcpy(MTAPDVUHDR.CREATE_USER_ID, MTAPDVUHDR_o.CREATE_USER_ID, sizeof(MTAPDVUHDR.CREATE_USER_ID)); 
		memcpy(MTAPDVUHDR.CREATE_TIME, MTAPDVUHDR_o.CREATE_TIME, sizeof(MTAPDVUHDR.CREATE_TIME));
		TRS.copy(MTAPDVUHDR.UPDATE_USER_ID, sizeof(MTAPDVUHDR.UPDATE_USER_ID), in_node, IN_USERID);
		DB_get_systime(MTAPDVUHDR.UPDATE_TIME); 
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
		} */

		DBC_update_mtapdvuhdr(1, &MTAPDVUHDR);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVUHDR UPDATE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPDVUHDR.FACTORY), MTAPDVUHDR.FACTORY); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVUHDR.VIEW_ID), MTAPDVUHDR.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MTAPDVUHDR.USER_ID), MTAPDVUHDR.USER_ID); 
			TRS.add_fieldmsg(out_node, "COL_NAME", MP_STR, sizeof(MTAPDVUHDR.COL_NAME), MTAPDVUHDR.COL_NAME); 
            TRS.add_fieldmsg(out_node, "COL_SEQ", MP_INT, MTAPDVUHDR.COL_SEQ); 
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
		DBC_delete_mtapdvuhdr(1, &MTAPDVUHDR);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVUHDR DELETE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPDVUHDR.FACTORY), MTAPDVUHDR.FACTORY); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVUHDR.VIEW_ID), MTAPDVUHDR.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MTAPDVUHDR.USER_ID), MTAPDVUHDR.USER_ID); 
			TRS.add_fieldmsg(out_node, "COL_NAME", MP_STR, sizeof(MTAPDVUHDR.COL_NAME), MTAPDVUHDR.COL_NAME); 
            TRS.add_fieldmsg(out_node, "COL_SEQ", MP_INT, MTAPDVUHDR.COL_SEQ); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 
	}

	if(COM_proc_user_routine("TIV", "TAP_Update_Header_User",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	TAP_Update_Header_User_Validation()
		- Main sub function of "TAP_UPDATE_HEADER_USER" function
		- Check the condition for create/update/delete Header_User & vbCrLf	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_Update_Header_User_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct MTAPDVUHDR_TAG MTAPDVUHDR;
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

	/* Factory Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
	{
		strcpy(s_msg_code, "TAP-0001");
		TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
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
	/* User_id Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "USER_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "TAP-0001");
		TRS.add_fieldmsg(out_node, "USER_ID", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* Col_name Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "COL_NAME")) == MP_TRUE)
	{
		strcpy(s_msg_code, "TAP-0001");
		TRS.add_fieldmsg(out_node, "COL_NAME", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
    if(TRS.get_int(in_node, "COL_SEQ")==0)
    {
        strcpy(s_msg_code, "TAP-0001");
		TRS.add_fieldmsg(out_node, "COL_SEQ", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }
	DBC_init_mtapdvuhdr(&MTAPDVUHDR);
	TRS.copy(MTAPDVUHDR.FACTORY, sizeof(MTAPDVUHDR.FACTORY), in_node, "FACTORY");
	TRS.copy(MTAPDVUHDR.VIEW_ID, sizeof(MTAPDVUHDR.VIEW_ID), in_node, "VIEW_ID");
	TRS.copy(MTAPDVUHDR.USER_ID, sizeof(MTAPDVUHDR.USER_ID), in_node, "USER_ID");
	TRS.copy(MTAPDVUHDR.COL_NAME, sizeof(MTAPDVUHDR.COL_NAME), in_node, "COL_NAME");
    MTAPDVUHDR.COL_SEQ = TRS.get_int(in_node, "COL_SEQ");
	DBC_select_mtapdvuhdr(1, &MTAPDVUHDR); 
	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{
		if(DB_error_code == DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-XXXX"); 
			TRS.add_fieldmsg(out_node, "MTAPDVUHDR SELECT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPDVUHDR.FACTORY), MTAPDVUHDR.FACTORY); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVUHDR.VIEW_ID), MTAPDVUHDR.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MTAPDVUHDR.USER_ID), MTAPDVUHDR.USER_ID); 
			TRS.add_fieldmsg(out_node, "COL_NAME", MP_STR, sizeof(MTAPDVUHDR.COL_NAME), MTAPDVUHDR.COL_NAME); 
            TRS.add_fieldmsg(out_node, "COL_SEQ", MP_INT, MTAPDVUHDR.COL_SEQ); 
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

			TRS.add_fieldmsg(out_node, "MTAPDVUHDR SELECT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPDVUHDR.FACTORY), MTAPDVUHDR.FACTORY); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVUHDR.VIEW_ID), MTAPDVUHDR.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MTAPDVUHDR.USER_ID), MTAPDVUHDR.USER_ID); 
			TRS.add_fieldmsg(out_node, "COL_NAME", MP_STR, sizeof(MTAPDVUHDR.COL_NAME), MTAPDVUHDR.COL_NAME); 
            TRS.add_fieldmsg(out_node, "COL_SEQ", MP_INT, MTAPDVUHDR.COL_SEQ); 

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			return MP_FALSE;
		}
	}
	return MP_TRUE;
}