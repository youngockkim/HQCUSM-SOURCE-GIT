/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_line_list.c
	Description : View Line List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Line_List()
			+ View Lot
		- CWIP_VIEW_LINE_LIST()
			+ Main sub function of CWIP_View_Line_List function
			+ View Line List definition
		- CWIP_View_Line_List_Validation()
			+ Main sub function of CWIP_VIEW_LINE_LIST function
			+ Check the condition for view Line List
	Detail Description
		- CWIP_VIEW_LINE_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Line_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Line_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Line_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_LINE_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_LINE_LIST", out_node);

	if (i_ret == MP_TRUE)
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
	CWIP_VIEW_LINE_LIST()
		- Main sub function of "CWIP_View_Line_List" function
		- View Line List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LINE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MGCMTBLDEF_TAG MGCMTBLDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    TRSNode *list_item;

    int i_step;

    LOG_head("CWIP_VIEW_LINE_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_View_Line_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Line List by Line Group */
    DBC_init_mgcmtbldef(&MGCMTBLDEF);
    TRS.copy(MGCMTBLDEF.FACTORY, sizeof(MGCMTBLDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MGCMTBLDEF.TABLE_NAME, sizeof(MGCMTBLDEF.TABLE_NAME), in_node, "TABLE_NAME");
    DBC_select_mgcmtbldef(1, &MGCMTBLDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "GCM-0002");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "GCM-0007");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }

        TRS.add_fieldmsg(out_node, "MGCMTBLDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    i_step = 0;
    //2023-08-28 LINE LOCATION에 따른 스탭 변경
	if (TRS.get_procstep(in_node) == '1')
    {
        if (COM_isnullspace(TRS.get_string(in_node, "LINE_LOCATION")) == MP_TRUE)
        {
            i_step = 101;
        }
        else
        {
            i_step = 107;
        }
    }

    DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
    TRS.copy(MGCMTBLDAT.DATA_5, sizeof(MGCMTBLDAT.DATA_5), in_node, "LINE_GROUP");
    TRS.copy(MGCMTBLDAT.DATA_7, sizeof(MGCMTBLDAT.DATA_7), in_node, "LINE_LOCATION");

    DBC_open_mgcmtbldat(i_step, &MGCMTBLDAT);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "GCM-0007");
        TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
        TRS.add_fieldmsg(out_node, "DATA_5", MP_STR, sizeof(MGCMTBLDAT.DATA_5), MGCMTBLDAT.DATA_5);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mgcmtbldat(i_step, &MGCMTBLDAT);

        if(DB_error_code == DB_NOT_FOUND) 
        {
            DBC_close_mgcmtbldat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "GCM-0007");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "DATA_5", MP_STR, sizeof(MGCMTBLDAT.DATA_5), MGCMTBLDAT.DATA_5);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            DBC_close_mgcmtbldat(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_string(out_node, "NEXT_KEY_1", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
            TRS.add_string(out_node, "NEXT_KEY_2", MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2));
            TRS.add_string(out_node, "NEXT_KEY_3", MGCMTBLDAT.KEY_3, sizeof(MGCMTBLDAT.KEY_3));
            TRS.add_string(out_node, "NEXT_KEY_4", MGCMTBLDAT.KEY_4, sizeof(MGCMTBLDAT.KEY_4));
            TRS.add_string(out_node, "NEXT_KEY_5", MGCMTBLDAT.KEY_5, sizeof(MGCMTBLDAT.KEY_5));
            TRS.add_string(out_node, "NEXT_KEY_6", MGCMTBLDAT.KEY_6, sizeof(MGCMTBLDAT.KEY_6));
            TRS.add_string(out_node, "NEXT_KEY_7", MGCMTBLDAT.KEY_7, sizeof(MGCMTBLDAT.KEY_7));
            TRS.add_string(out_node, "NEXT_KEY_8", MGCMTBLDAT.KEY_8, sizeof(MGCMTBLDAT.KEY_8));
            TRS.add_string(out_node, "NEXT_KEY_9", MGCMTBLDAT.KEY_9, sizeof(MGCMTBLDAT.KEY_9));
            TRS.add_string(out_node, "NEXT_KEY_10", MGCMTBLDAT.KEY_10, sizeof(MGCMTBLDAT.KEY_10));

            DBC_close_mgcmtbldat(i_step);
            break;
        }

        list_item = TRS.add_node(out_node, "DATA_LIST");
        TRS.add_string(list_item, "KEY_1", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
        TRS.add_string(list_item, "KEY_2", MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2));
        TRS.add_string(list_item, "KEY_3", MGCMTBLDAT.KEY_3, sizeof(MGCMTBLDAT.KEY_3));
        TRS.add_string(list_item, "KEY_4", MGCMTBLDAT.KEY_4, sizeof(MGCMTBLDAT.KEY_4));
        TRS.add_string(list_item, "KEY_5", MGCMTBLDAT.KEY_5, sizeof(MGCMTBLDAT.KEY_5));
        TRS.add_string(list_item, "KEY_6", MGCMTBLDAT.KEY_6, sizeof(MGCMTBLDAT.KEY_6));
        TRS.add_string(list_item, "KEY_7", MGCMTBLDAT.KEY_7, sizeof(MGCMTBLDAT.KEY_7));
        TRS.add_string(list_item, "KEY_8", MGCMTBLDAT.KEY_8, sizeof(MGCMTBLDAT.KEY_8));
        TRS.add_string(list_item, "KEY_9", MGCMTBLDAT.KEY_9, sizeof(MGCMTBLDAT.KEY_9));
        TRS.add_string(list_item, "KEY_10", MGCMTBLDAT.KEY_10, sizeof(MGCMTBLDAT.KEY_10));
        TRS.add_string(list_item, "DATA_1", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        TRS.add_string(list_item, "DATA_2", MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
        TRS.add_string(list_item, "DATA_3", MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3));
        TRS.add_string(list_item, "DATA_4", MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4));
        TRS.add_string(list_item, "DATA_5", MGCMTBLDAT.DATA_5, sizeof(MGCMTBLDAT.DATA_5));
        TRS.add_string(list_item, "DATA_6", MGCMTBLDAT.DATA_6, sizeof(MGCMTBLDAT.DATA_6));
        TRS.add_string(list_item, "DATA_7", MGCMTBLDAT.DATA_7, sizeof(MGCMTBLDAT.DATA_7));
        TRS.add_string(list_item, "DATA_8", MGCMTBLDAT.DATA_8, sizeof(MGCMTBLDAT.DATA_8));
        TRS.add_string(list_item, "DATA_9", MGCMTBLDAT.DATA_9, sizeof(MGCMTBLDAT.DATA_9));
        TRS.add_string(list_item, "DATA_10", MGCMTBLDAT.DATA_10, sizeof(MGCMTBLDAT.DATA_10));
        TRS.add_string(list_item, "CREATE_USER_ID", MGCMTBLDAT.CREATE_USER_ID, sizeof(MGCMTBLDAT.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", MGCMTBLDAT.CREATE_TIME, sizeof(MGCMTBLDAT.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", MGCMTBLDAT.UPDATE_USER_ID, sizeof(MGCMTBLDAT.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", MGCMTBLDAT.UPDATE_TIME, sizeof(MGCMTBLDAT.UPDATE_TIME));
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Line_List_Validation()
		- Main sub function of "CWIP_VIEW_LINE_LIST" function
		- Check the condition for view Line List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Line_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

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


    return MP_TRUE;
}