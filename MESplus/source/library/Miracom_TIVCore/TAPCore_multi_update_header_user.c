/******************************************************************************'

	System      : MESplus
	Module      : TAPCore
	File Name   : TAPCore_multi_update_header_user.c
	Description : Direct_View_Header Setup function module

	MES Version : 5.2.0

	Function List
		- TAP_Multi_Update_Header_User()
			+ Create/Update/Delete Direct_View_Header definition
		- TAP_MULTI_UPDATE_HEADER_USER()
			+ Main sub function of TAP_Multi_Update_Header_User function
			+ Create/Update/Delete Direct_View_Header definition
		- TAP_Multi_Update_Header_User_Validation()
			+ Main sub function of TAP_MULTI_UPDATE_HEADER_USER function
			+ Check the condition for create/update/delete Direct_View_Header
	Detail Description
		- TAP_MULTI_UPDATE_HEADER_USER()
			+ h_proc_step
				+ MP_STEP_CREATE : Create Direct_View_Header definition
				+ MP_STEP_UPDATE : Update Direct_View_Header definition
				+ MP_STEP_DELETE : Delete Direct_View_Header definition

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/08/01  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"

int TAP_Multi_Update_Header_User_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node);

/*******************************************************************************
	TAP_Multi_Update_Header_User()
		- Create/Update/Delete Direct_View_Header definition
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_Multi_Update_Header_User(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TAP_MULTI_UPDATE_HEADER_USER(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TAP_MULTI_UPDATE_HEADER_USER", out_node);

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
	TAP_MULTI_UPDATE_HEADER_USER()
		- Main sub function of "TAP_Multi_Update_Header_User" function
		- Create/Update/Delete Direct_View_Header definition
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TAP_MULTI_UPDATE_HEADER_USER(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	struct MTAPDVUHDR_TAG MTAPDVUHDR;

    TRSNode **List;
    //TRSNode *update_in_node;

    int i=0;

	LOG_head("TAP_Multi_Update_Header_User");
	LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
	LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
	LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
	LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(COM_proc_user_routine("TIV", "TAP_Multi_Update_Header_User",
							 MP_UPOINT_BEFORE,
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 


    DBC_init_mtapdvuhdr(&MTAPDVUHDR);
    TRS.copy(MTAPDVUHDR.FACTORY, sizeof(MTAPDVUHDR.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTAPDVUHDR.USER_ID, sizeof(MTAPDVUHDR.USER_ID), in_node, IN_USERID);
    TRS.copy(MTAPDVUHDR.VIEW_ID, sizeof(MTAPDVUHDR.VIEW_ID), in_node, "VIEW_ID");
    DBC_delete_mtapdvuhdr(2, &MTAPDVUHDR);
    if(DB_error_code!=DB_NOT_FOUND && DB_error_code!=DB_SUCCESS)
    {
        strcpy(s_msg_code, "TAP-0004"); 
		TRS.add_fieldmsg(out_node, "MTAPDVUHDR DELETE", MP_NVST); 
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPDVUHDR.FACTORY), MTAPDVUHDR.FACTORY); 
		TRS.add_fieldmsg(out_node, "VIEW_ID", MP_STR, sizeof(MTAPDVUHDR.VIEW_ID), MTAPDVUHDR.VIEW_ID); 
		TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MTAPDVUHDR.USER_ID), MTAPDVUHDR.USER_ID); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
    }


    List =  TRS.get_list(in_node, "LIST");

    for(i = 0;i<TRS.get_item_count(in_node, "LIST");i++)
    {
        TRS.set_char(List[i], "PROCSTEP", MP_STEP_CREATE);
        TRS.set_char(List[i], "LANGUAGE", TRS.get_language(in_node));
        TRS.set_nstring(List[i], "FACTORY", TRS.get_factory(in_node));
        TRS.set_nstring(List[i], "USERID", TRS.get_userid(in_node));
        TRS.set_nstring(List[i], "VIEW_ID", TRS.get_string(in_node, "VIEW_ID"));
        TRS.set_nstring(List[i], "USER_ID", TRS.get_string(in_node, "USER_ID"));
        if(TAP_UPDATE_HEADER_USER(s_msg_code, List[i], out_node)==MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
        }
    }
	


	if(COM_proc_user_routine("TIV", "TAP_Multi_Update_Header_User",
							 MP_UPOINT_AFTER, 
							 in_node,
							 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 
