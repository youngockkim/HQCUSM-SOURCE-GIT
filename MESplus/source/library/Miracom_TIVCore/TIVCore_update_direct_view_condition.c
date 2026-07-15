/******************************************************************************'

	System      : MESplus
	Module      : TAPCore
	File Name   : TAPCore_update_direct_view_condition.c
	Description : Direct_View_Condition Setup function module

	MES Version : 5.2.0

	Function List
		- TAP_Update_Direct_View_Condition()
			+ Create/Update/Delete Direct_View_Condition definition
		- TAP_UPDATE_DIRECT_VIEW_CONDITION()
			+ Main sub function of TAP_Update_Direct_View_Condition function
			+ Create/Update/Delete Direct_View_Condition definition
		- TAP_Update_Direct_View_Condition_Validation()
			+ Main sub function of TAP_UPDATE_DIRECT_VIEW_CONDITION function
			+ Check the condition for create/update/delete Direct_View_Condition
	Detail Description
		- TAP_UPDATE_DIRECT_VIEW_CONDITION()
			+ h_proc_step
				+ MP_STEP_CREATE : Create Direct_View_Condition definition
				+ MP_STEP_UPDATE : Update Direct_View_Condition definition
				+ MP_STEP_DELETE : Delete Direct_View_Condition definition

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

int TAP_Update_Direct_View_Condition_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node);

/*******************************************************************************
	TAP_Update_Direct_View_Condition()
		- Create/Update/Delete Direct_View_Condition definition
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_Update_Direct_View_Condition(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TAP_UPDATE_DIRECT_VIEW_CONDITION(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TAP_UPDATE_DIRECT_VIEW_CONDITION", out_node);

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
	TAP_UPDATE_DIRECT_VIEW_CONDITION()
		- Main sub function of "TAP_Update_Direct_View_Condition" function
		- Create/Update/Delete Direct_View_Condition definition
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_UPDATE_DIRECT_VIEW_CONDITION(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTAPDVWCND_TAG MTAPDVWCND;
	struct MTAPDVWCND_TAG MTAPDVWCND_o;

	LOG_head("TAP_Update_Direct_View_Condition");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("view_id", MP_NSTR, TRS.get_string(in_node, "VIEW_ID"));
	LOG_add("cond_seq", MP_INT, TRS.get_int(in_node, "COND_SEQ"));
	LOG_add("cond_name", MP_NSTR, TRS.get_string(in_node, "COND_NAME"));
	LOG_add("cond_desc", MP_NSTR, TRS.get_string(in_node, "COND_DESC"));
	LOG_add("req_flag", MP_CHR, TRS.get_char(in_node, "REQ_FLAG"));
	LOG_add("data_type", MP_NSTR, TRS.get_string(in_node, "DATA_TYPE"));
	LOG_add("input_type", MP_NSTR, TRS.get_string(in_node, "INPUT_TYPE"));
	LOG_add("data_tbl", MP_NSTR, TRS.get_string(in_node, "DATA_TBL"));
	LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
	LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
	LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
	LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("TIV", "TAP_Update_Direct_View_Condition",
							 MP_UPOINT_BEFORE,
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 

	if(TAP_Update_Direct_View_Condition_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	DBC_init_mtapdvwcnd(&MTAPDVWCND);
	TRS.copy(MTAPDVWCND.VIEW_ID, sizeof(MTAPDVWCND.VIEW_ID), in_node, "VIEW_ID");
	MTAPDVWCND.COND_SEQ  = TRS.get_int(in_node, "COND_SEQ"); 
	TRS.copy(MTAPDVWCND.COND_NAME, sizeof(MTAPDVWCND.COND_NAME), in_node, "COND_NAME");
	TRS.copy(MTAPDVWCND.COND_DESC, sizeof(MTAPDVWCND.COND_DESC), in_node, "COND_DESC");
	MTAPDVWCND.REQ_FLAG  = TRS.get_char(in_node, "REQ_FLAG"); 
	TRS.copy(MTAPDVWCND.DATA_TYPE, sizeof(MTAPDVWCND.DATA_TYPE), in_node, "DATA_TYPE");
	TRS.copy(MTAPDVWCND.INPUT_TYPE, sizeof(MTAPDVWCND.INPUT_TYPE), in_node, "INPUT_TYPE");
	TRS.copy(MTAPDVWCND.DATA_TBL, sizeof(MTAPDVWCND.DATA_TBL), in_node, "DATA_TBL");
	TRS.copy(MTAPDVWCND.CREATE_TIME, sizeof(MTAPDVWCND.CREATE_TIME), in_node, "CREATE_TIME");
	TRS.copy(MTAPDVWCND.CREATE_USER_ID, sizeof(MTAPDVWCND.CREATE_USER_ID), in_node, "CREATE_USER_ID");
	TRS.copy(MTAPDVWCND.UPDATE_TIME, sizeof(MTAPDVWCND.UPDATE_TIME), in_node, "UPDATE_TIME");
	TRS.copy(MTAPDVWCND.UPDATE_USER_ID, sizeof(MTAPDVWCND.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");

	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{

		//----[Addtional Logic for Create Case]----
		/*TRS.copy(MTAPDVWCND.CREATE_USER_ID, sizeof(MTAPDVWCND.CREATE_USER_ID), in_node, IN_USERID);
		DB_get_systime(MTAPDVWCND.CREATE_TIME); 
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

		DBC_insert_mtapdvwcnd(&MTAPDVWCND); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVWCND INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWCND.VIEW_ID), MTAPDVWCND.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "COND_SEQ", MP_INT, MTAPDVWCND.COND_SEQ); 
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
		DBC_init_mtapdvwcnd(&MTAPDVWCND_o); 
		TRS.copy(MTAPDVWCND_o.VIEW_ID, sizeof(MTAPDVWCND_o.VIEW_ID), in_node, "VIEW_ID");
		MTAPDVWCND_o.COND_SEQ  = TRS.get_int(in_node, "COND_SEQ"); 
		DBC_select_mtapdvwcnd_for_update(1, &MTAPDVWCND_o);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVWCND SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWCND.VIEW_ID), MTAPDVWCND.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "COND_SEQ", MP_INT, MTAPDVWCND.COND_SEQ); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 

		//----[Addtional Logic for Create Case]----
		/*memcpy(MTAPDVWCND.CREATE_USER_ID, MTAPDVWCND_o.CREATE_USER_ID, sizeof(MTAPDVWCND.CREATE_USER_ID)); 
		memcpy(MTAPDVWCND.CREATE_TIME, MTAPDVWCND_o.CREATE_TIME, sizeof(MTAPDVWCND.CREATE_TIME));
		TRS.copy(MTAPDVWCND.UPDATE_USER_ID, sizeof(MTAPDVWCND.UPDATE_USER_ID), in_node, IN_USERID);
		DB_get_systime(MTAPDVWCND.UPDATE_TIME); 
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

		DBC_update_mtapdvwcnd(1, &MTAPDVWCND);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVWCND UPDATE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWCND.VIEW_ID), MTAPDVWCND.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "COND_SEQ", MP_INT, MTAPDVWCND.COND_SEQ); 
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
		DBC_delete_mtapdvwcnd(1, &MTAPDVWCND);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-0004"); 
			TRS.add_fieldmsg(out_node, "MTAPDVWCND DELETE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWCND.VIEW_ID), MTAPDVWCND.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "COND_SEQ", MP_INT, MTAPDVWCND.COND_SEQ); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 
	}

	if(COM_proc_user_routine("TIV", "TAP_Update_Direct_View_Condition",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	TAP_Update_Direct_View_Condition_Validation()
		- Main sub function of "TAP_UPDATE_DIRECT_VIEW_CONDITION" function
		- Check the condition for create/update/delete Direct_View_Condition & vbCrLf	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_Update_Direct_View_Condition_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct MTAPDVWCND_TAG MTAPDVWCND;
	struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MTAPSQLDEF_TAG MTAPSQLDEF;

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
	/* Cond_seq Validation */
	if(TRS.get_int(in_node, "COND_SEQ")==0)
	{
		strcpy(s_msg_code, "TAP-0001");
		TRS.add_fieldmsg(out_node, "COND_SEQ", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
    DBC_init_mtapsqldef(&MTAPSQLDEF);
	TRS.copy(MTAPSQLDEF.VIEW_ID, sizeof(MTAPSQLDEF.VIEW_ID), in_node, "VIEW_ID");
	DBC_select_mtapsqldef(1, &MTAPSQLDEF); 
	if(DB_error_code != DB_SUCCESS)
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
	DBC_init_mtapdvwcnd(&MTAPDVWCND);
	TRS.copy(MTAPDVWCND.VIEW_ID, sizeof(MTAPDVWCND.VIEW_ID), in_node, "VIEW_ID");
	MTAPDVWCND.COND_SEQ  = TRS.get_int(in_node, "COND_SEQ"); 
	DBC_select_mtapdvwcnd(1, &MTAPDVWCND); 
	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{
		if(DB_error_code == DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "TAP-XXXX"); 
			TRS.add_fieldmsg(out_node, "MTAPDVWCND SELECT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWCND.VIEW_ID), MTAPDVWCND.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "COND_SEQ", MP_INT, MTAPDVWCND.COND_SEQ); 
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

			TRS.add_fieldmsg(out_node, "MTAPDVWCND SELECT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVWCND.VIEW_ID), MTAPDVWCND.VIEW_ID); 
			TRS.add_fieldmsg(out_node, "COND_SEQ", MP_INT, MTAPDVWCND.COND_SEQ); 

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			return MP_FALSE;
		}
	}
	return MP_TRUE;
}