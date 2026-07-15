/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_tool_use_check.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// TOOL사용횟수 초과 체크 후 메일전송

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2019/10/22  JGCHOI.       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include "SPCCore_common.h"
#include <MessageCaster.h>
int CSUM_BATCHPROCESS_TOOL_USE_CHECK(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
CSUM_BatchProcess_Tool_Use_Check()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Tool_Use_Check(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	
	i_ret = CSUM_BATCHPROCESS_TOOL_USE_CHECK(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_TOOL_USE_CHECK", out_node);

	if(i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	CUS_COM_BATCHPROCESS_STATUS_UPDATE('E', in_node, out_node);

	return MP_TRUE;
}


/*******************************************************************************
CSUM_BATCHPROCESS_TOOL_USE_CHECK()
- Main sub function of "CSUM_BatchProcess_Tool_Use_Check" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_TOOL_USE_CHECK(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	
	struct CRASTOLSTS_TAG CRASTOLSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	
	TRSNode* tran_in_node;
	TRSNode* list_item;

	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
	/*
	char s_tmpstr[1000];
	char s_line_id[10];
	char s_check_time[30];
	char s_over_rate[30];
	
	double std_lower_spec = 0;	
	double ng_rate = 0;
	*/
	int i_ng_cnt = 0;
			
    LOG_head("CSUM_BATCHPROCESS_TOOL_USE_CHECK");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}

	tran_in_node = TRS.create_node("alarm_in_node");

	//ealge #1
	CDB_init_crastolsts(&CRASTOLSTS);
	TRS.copy(CRASTOLSTS.FACTORY, sizeof(CRASTOLSTS.FACTORY), in_node, IN_FACTORY);
	
	CDB_open_crastolsts(2, &CRASTOLSTS);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "CRASTOLSTS OPEN", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		TRS.free_node(tran_in_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		CDB_fetch_crastolsts(2, &CRASTOLSTS);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			CDB_close_crastolsts(2);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "CRASTOLSTS FETCH", MP_NVST);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			CDB_close_crastolsts(2);
			TRS.free_node(tran_in_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		list_item = TRS.add_node(tran_in_node, "TOOL_LIST");
		TRS.add_string(list_item, "LINE_ID", CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID)); // Work Shop
		TRS.add_string(list_item, "RES_ID", CRASTOLSTS.RES_ID, sizeof(CRASTOLSTS.RES_ID));  // EQ

		DBC_init_mrasresdef(&MRASRESDEF);		
		TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MRASRESDEF.RES_ID, CRASTOLSTS.RES_ID, sizeof(MRASRESDEF.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS) 
		{
			//Do Nothing
		}
		
		TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC)); // EQ NAME
		TRS.add_string(list_item, "RES_GROUP", MRASRESDEF.RES_CMF_7, sizeof(MRASRESDEF.RES_CMF_7)); //RES GROUP 
		TRS.add_string(list_item, "PLC_ID", CRASTOLSTS.CMF_4, sizeof(CRASTOLSTS.CMF_4));
		
		TRS.add_string(list_item, "CHANGE_CNT", CRASTOLSTS.CMF_3, sizeof(CRASTOLSTS.CMF_3));  
		TRS.add_string(list_item, "PART_NAME", CRASTOLSTS.PART_NAME, sizeof(CRASTOLSTS.PART_NAME)); // Part Name
		TRS.add_string(list_item, "CURR_USE_CNT", CRASTOLSTS.CMF_1, sizeof(CRASTOLSTS.CMF_1)); // Current Use Cnt
		TRS.add_string(list_item, "LIMIT_USE_CNT", CRASTOLSTS.CMF_2, sizeof(CRASTOLSTS.CMF_2)); // Limit Use Cnt
		i_ng_cnt +=1;
	}

	if(i_ng_cnt > 0)
	{
		CCOM_copy_in_node(in_node, tran_in_node);

		TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
		TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
		TRS.set_nstring(tran_in_node, "ALARM_ID", "ALM_TOOL_USE_LIMIT");				
		TRS.set_string(tran_in_node, "RES_ID", CRASTOLSTS.RES_ID, sizeof(CRASTOLSTS.RES_ID));				
		TRS.set_nstring(tran_in_node, "ALARM_SUBJECT", "# TOOL USAGE LIMIT OVER ALARM #");
		TRS.set_nstring(tran_in_node, "ALARM_MSG", "The limit of tool usage has been exceeded.");
		TRS.set_string(tran_in_node, "SOURCE_ID_1", CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID));
		TRS.set_string(tran_in_node, "SOURCE_ID_2",CRASTOLSTS.CMF_1, sizeof(CRASTOLSTS.CMF_1));
		TRS.set_string(tran_in_node, "SOURCE_ID_3", CRASTOLSTS.CMF_2, sizeof(CRASTOLSTS.CMF_2));

		if(ALM_RAISE_ALARM(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}
	//TRS.free_node(tran_in_node);	

	//ealge #2
	i_ng_cnt = 0;
	CDB_init_crastolsts(&CRASTOLSTS);
	TRS.copy(CRASTOLSTS.FACTORY, sizeof(CRASTOLSTS.FACTORY), in_node, IN_FACTORY);
	
	CDB_open_crastolsts(3, &CRASTOLSTS);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "CRASTOLSTS OPEN", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		TRS.free_node(tran_in_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		CDB_fetch_crastolsts(3, &CRASTOLSTS);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			CDB_close_crastolsts(3);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "CRASTOLSTS FETCH", MP_NVST);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			CDB_close_crastolsts(3);
			TRS.free_node(tran_in_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		list_item = TRS.add_node(tran_in_node, "TOOL_LIST");
		TRS.add_string(list_item, "LINE_ID", CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID)); // Work Shop
		TRS.add_string(list_item, "RES_ID", CRASTOLSTS.RES_ID, sizeof(CRASTOLSTS.RES_ID));  // EQ

		DBC_init_mrasresdef(&MRASRESDEF);		
		TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MRASRESDEF.RES_ID, CRASTOLSTS.RES_ID, sizeof(MRASRESDEF.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS) 
		{
			//Do Nothing
		}
		
		TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC)); // EQ NAME
		TRS.add_string(list_item, "RES_GROUP", MRASRESDEF.RES_CMF_7, sizeof(MRASRESDEF.RES_CMF_7)); //RES GROUP 
		TRS.add_string(list_item, "PLC_ID", CRASTOLSTS.CMF_4, sizeof(CRASTOLSTS.CMF_4));
		
		TRS.add_string(list_item, "CHANGE_CNT", CRASTOLSTS.CMF_3, sizeof(CRASTOLSTS.CMF_3));  
		TRS.add_string(list_item, "PART_NAME", CRASTOLSTS.PART_NAME, sizeof(CRASTOLSTS.PART_NAME)); // Part Name
		TRS.add_string(list_item, "CURR_USE_CNT", CRASTOLSTS.CMF_1, sizeof(CRASTOLSTS.CMF_1)); // Current Use Cnt
		TRS.add_string(list_item, "LIMIT_USE_CNT", CRASTOLSTS.CMF_2, sizeof(CRASTOLSTS.CMF_2)); // Limit Use Cnt
		i_ng_cnt +=1;
	}

	if(i_ng_cnt > 0)
	{
		CCOM_copy_in_node(in_node, tran_in_node);

		TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
		TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
		TRS.set_nstring(tran_in_node, "ALARM_ID", "ALM_TOOL_USE_LIMIT2");				
		TRS.set_string(tran_in_node, "RES_ID", CRASTOLSTS.RES_ID, sizeof(CRASTOLSTS.RES_ID));				
		TRS.set_nstring(tran_in_node, "ALARM_SUBJECT", "# TOOL USAGE LIMIT OVER ALARM #");
		TRS.set_nstring(tran_in_node, "ALARM_MSG", "The limit of tool usage has been exceeded.");
		TRS.set_string(tran_in_node, "SOURCE_ID_1", CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID));
		TRS.set_string(tran_in_node, "SOURCE_ID_2",CRASTOLSTS.CMF_1, sizeof(CRASTOLSTS.CMF_1));
		TRS.set_string(tran_in_node, "SOURCE_ID_3", CRASTOLSTS.CMF_2, sizeof(CRASTOLSTS.CMF_2));

		if(ALM_RAISE_ALARM(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}
	TRS.free_node(tran_in_node);	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}
