/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_View_Acmodule_History_List.c
	Description : View Operation List

    MES Version : 5.3.6.CW

		- CWIP_VIEW_SILICONE_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2020/06/24  Lim Yeon Keun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"


/*******************************************************************************
	CWIP_View_Acmodule_History_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Acmodule_History_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_ACMODULE_HISTORY_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_ACMODULE_HISTORY_LIST", out_node);

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
	CWIP_VIEW_ACMODULE_HISTORY_LIST()
		- Main sub function of "CWIP_View_Acmodule_History_List" function
		- View Silicone List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_ACMODULE_HISTORY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CEDCLOTRLH_TAG CEDCLOTRLH;

    TRSNode *list_item;
	
    int i_step;

    LOG_head("CWIP_VIEW_ACMODULE_HISTORY_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(TRS.get_procstep(in_node) == '3') 
	{
		/* Select Area by Line Code */
		i_step = 2;
		CDB_init_cedclotrlh(&CEDCLOTRLH);	
		TRS.copy(CEDCLOTRLH.FACTORY, sizeof(CEDCLOTRLH.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTRLH.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		memcpy(CEDCLOTRLH.LOT_ID, TRS.get_string(in_node,"LOT_ID"), strlen(TRS.get_string(in_node,"LOT_ID")));

		CDB_open_cedclotrlh(i_step, &CEDCLOTRLH);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
				return MP_TRUE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CEDCLOTRLH OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		// FETCH
		while(1)
		{
			CDB_fetch_cedclotrlh(i_step, &CEDCLOTRLH);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cedclotrlh(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CEDCLOTRLH OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_cedclotrlh(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				CDB_close_cedclotrlh(i_step);
				break;
			}

			list_item = TRS.add_node(out_node, "VIEW_FQCHIS_OUT");
			TRS.add_int(list_item, "INS_CNT", CEDCLOTRLH.INS_CNT);
			TRS.add_string(list_item, "RES_ID", CEDCLOTRLH.RES_ID, sizeof(CEDCLOTRLH.RES_ID)); 
			TRS.add_string(list_item, "INS_TIME", CEDCLOTRLH.INS_TIME, sizeof(CEDCLOTRLH.INS_TIME));
			TRS.add_string(list_item, "INS_VALUE", CEDCLOTRLH.INS_VALUE, sizeof(CEDCLOTRLH.INS_VALUE));
			TRS.add_string(list_item, "RESULT_TIME", CEDCLOTRLH.RESULT_TIME, sizeof(CEDCLOTRLH.RESULT_TIME));
			TRS.add_string(list_item, "RESULT_VALUE", CEDCLOTRLH.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE));
			TRS.add_string(list_item, "DEFECT_CODE", CEDCLOTRLH.CMF_2, sizeof(CEDCLOTRLH.CMF_2));
			TRS.add_string(list_item, "GRADE", CEDCLOTRLH.GRADE, sizeof(CEDCLOTRLH.GRADE));
			TRS.add_string(list_item, "POWER", CEDCLOTRLH.POWER, sizeof(CEDCLOTRLH.POWER));
			TRS.add_string(list_item, "ARTICLE_NO", CEDCLOTRLH.ARTICLE_NO, sizeof(CEDCLOTRLH.ARTICLE_NO));
			TRS.add_string(list_item, "COLOR_CLASS", CEDCLOTRLH.COLOR_CLASS, sizeof(CEDCLOTRLH.COLOR_CLASS));
			TRS.add_string(list_item, "MAT_ID", CEDCLOTRLH.MAT_ID, sizeof(CEDCLOTRLH.MAT_ID));
		}
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 
