/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_View_Tabber_Status.c
	Description : View Tabber Status

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Tabber_Status()
		- CWIP_VIEW_TABBER_STATUS()
	Detail Description
		- CWIP_VIEW_TABBER_STATUS()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2020/08/11  Lim Yeon Keun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"


/*******************************************************************************
	CWIP_View_Tabber_Status()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Tabber_Status(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_TABBER_STATUS(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_TABBER_STATUS", out_node);

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
	CWIP_VIEW_TABBER_STATUS()
		- Main sub function of "CWIP_View_Tabber_Status" function
		- View Tabber Status
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_TABBER_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPTABSTS_TAG CWIPTABSTS;
	//struct MGCMTBLDAT_TAG MGCMTBLDAT_LINE;
	//struct MGCMTBLDAT_TAG MGCMTBLDAT_FRAME_EQ;

    TRSNode *list_item;
    int i_step;

    LOG_head("CWIP_VIEW_TABBER_STATUS");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(TRS.get_procstep(in_node) == '1') 
	{

		/* Select Area by Line Code */
		i_step = 2;
		CDB_init_cwiptabsts(&CWIPTABSTS);

		//TRS.copy(CWIPTABSTS.FACTORY, sizeof(CWIPTABSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPTABSTS.LINE_ID, sizeof(CWIPTABSTS.LINE_ID), in_node, "LINE_ID");

		CDB_open_cwiptabsts(i_step, &CWIPTABSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CWIPTABSTS OPEN", MP_NVST);
			//TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTABSTS.FACTORY), CWIPTABSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTABSTS.LINE_ID), CWIPTABSTS.LINE_ID);
			
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		while(1)
		{
			CDB_fetch_cwiptabsts(i_step, &CWIPTABSTS);

			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwiptabsts(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "CWIPTABSTS FETCH", MP_NVST);
				//TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTABSTS.FACTORY), CWIPTABSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTABSTS.LINE_ID), CWIPTABSTS.LINE_ID);

				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cwiptabsts(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				
				CDB_close_cwiptabsts(i_step);
				break;
			}

			list_item = TRS.add_node(out_node, "LIST");

			TRS.add_string(list_item, "FACTORY", CWIPTABSTS.FACTORY, sizeof(CWIPTABSTS.FACTORY));
			TRS.add_string(list_item, "LINE", CWIPTABSTS.LINE_ID, sizeof(CWIPTABSTS.LINE_ID));
			TRS.add_string(list_item, "OPER", CWIPTABSTS.OPER, sizeof(CWIPTABSTS.OPER));
			TRS.add_string(list_item, "RES_ID", CWIPTABSTS.RES_ID, sizeof(CWIPTABSTS.RES_ID));
			TRS.add_string(list_item, "RES_DESC", CWIPTABSTS.CMF_1, sizeof(CWIPTABSTS.CMF_1));
			TRS.add_string(list_item, "COMMENT_1", CWIPTABSTS.COMMENT_1, sizeof(CWIPTABSTS.COMMENT_1));
			TRS.add_string(list_item, "COMMENT_2", CWIPTABSTS.COMMENT_2, sizeof(CWIPTABSTS.COMMENT_2));
			TRS.add_string(list_item, "CMF_1", CWIPTABSTS.CMF_1, sizeof(CWIPTABSTS.CMF_1));
			TRS.add_string(list_item, "CMF_2", CWIPTABSTS.CMF_2, sizeof(CWIPTABSTS.CMF_2));
			TRS.add_string(list_item, "CMF_3", CWIPTABSTS.CMF_3, sizeof(CWIPTABSTS.CMF_3));
			TRS.add_string(list_item, "CMF_4", CWIPTABSTS.CMF_4, sizeof(CWIPTABSTS.CMF_4));
			TRS.add_string(list_item, "CMF_5", CWIPTABSTS.CMF_5, sizeof(CWIPTABSTS.CMF_5));
			TRS.add_string(list_item, "CREATE_USER_ID", CWIPTABSTS.CREATE_USER_ID, sizeof(CWIPTABSTS.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CWIPTABSTS.CREATE_TIME, sizeof(CWIPTABSTS.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CWIPTABSTS.UPDATE_USER_ID, sizeof(CWIPTABSTS.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", CWIPTABSTS.UPDATE_TIME, sizeof(CWIPTABSTS.UPDATE_TIME));
		}
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 
