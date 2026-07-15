/*******************************************************************************

    System      : MESplus
    Module      : Update Tabber Status
    File Name   : CWIP_update_tabber_status.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.08.11  yeonkeun.lim

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_UPDATE_TABBER_STATUS(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_update_tabber_status()
        - CWIP_update_tabber_status
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Tabber_Status(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_TABBER_STATUS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_TABBER_STATUS", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}


/*******************************************************************************
    CWIP_UPDATE_TABBER_STATUS()
        - CWIP_UPDATE_TABBER_STATUS
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_TABBER_STATUS(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPTABSTS_TAG CWIPTABSTS;
	struct CWIPTABSTS_TAG CWIPTABSTS_EXIST;
	struct CWIPTABSTS_TAG CWIPTABSTS_SEQ;
	struct CWIPTABSTS_TAG CWIPTABSTS_GET;

	TRSNode ** Tran_List;

	char s_sys_time[14];
	int    i_tran_count = 0;
	int i_max_ins_seq;
	int    i = 0;

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_TABBER_STATUS");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
    Tran_List = TRS.get_list(in_node, "WORK_LIST");
    i_tran_count = TRS.get_item_count(in_node, "WORK_LIST");
	for(i = 0; i < i_tran_count; i++)
	{
		CDB_init_cwiptabsts(&CWIPTABSTS);
		TRS.copy(CWIPTABSTS.FACTORY, sizeof(CWIPTABSTS.FACTORY), Tran_List[i], "FACTORY");
		TRS.copy(CWIPTABSTS.OPER, sizeof(CWIPTABSTS.OPER), Tran_List[i], "OPER");
		TRS.copy(CWIPTABSTS.LINE_ID, sizeof(CWIPTABSTS.LINE_ID), Tran_List[i], "LINE_ID");
		TRS.copy(CWIPTABSTS.RES_ID, sizeof(CWIPTABSTS.RES_ID), Tran_List[i], "RES_ID");
		TRS.copy(CWIPTABSTS.COMMENT_1, sizeof(CWIPTABSTS.COMMENT_1), Tran_List[i], "COMMENT_1");
		TRS.copy(CWIPTABSTS.COMMENT_2, sizeof(CWIPTABSTS.COMMENT_2), Tran_List[i], "COMMENT_2");

		TRS.copy(CWIPTABSTS.CMF_1, sizeof(CWIPTABSTS.CMF_1), Tran_List[i], "CMF_1");
		

		memcpy(CWIPTABSTS.CREATE_USER_ID, MODULE_CLI, strlen(MODULE_CLI));
		memcpy(CWIPTABSTS.CREATE_TIME, s_sys_time, sizeof(CWIPTABSTS.CREATE_TIME));
		memcpy(CWIPTABSTS.UPDATE_USER_ID, MODULE_CLI, strlen(MODULE_CLI));
		memcpy(CWIPTABSTS.UPDATE_TIME, s_sys_time, sizeof(CWIPTABSTS.UPDATE_TIME));


		/* 1. Save All Tracking and Defect Data */
		i_max_ins_seq = 0;
		CDB_init_cwiptabsts(&CWIPTABSTS_SEQ);
		TRS.copy(CWIPTABSTS_SEQ.FACTORY, sizeof(CWIPTABSTS_SEQ.FACTORY), Tran_List[i], "FACTORY");
		TRS.copy(CWIPTABSTS_SEQ.RES_ID, sizeof(CWIPTABSTS_SEQ.RES_ID), Tran_List[i], "RES_ID");

		i_max_ins_seq = CDB_select_cwiptabsts_scalar(1, &CWIPTABSTS_SEQ);
		if(DB_error_code != DB_SUCCESS)
		{
			//return MP_TRUE;
		}

		//데이터 변경여부 체크 start
		CDB_init_cwiptabsts(&CWIPTABSTS_EXIST);
		TRS.copy(CWIPTABSTS_EXIST.FACTORY, sizeof(CWIPTABSTS_EXIST.FACTORY), Tran_List[i], "FACTORY");
		TRS.copy(CWIPTABSTS_EXIST.RES_ID, sizeof(CWIPTABSTS_EXIST.RES_ID), Tran_List[i], "RES_ID");
		CWIPTABSTS_EXIST.SEQ = i_max_ins_seq;
		TRS.copy(CWIPTABSTS_EXIST.COMMENT_1, sizeof(CWIPTABSTS_EXIST.COMMENT_1), Tran_List[i], "COMMENT_1");
		TRS.copy(CWIPTABSTS_EXIST.COMMENT_2, sizeof(CWIPTABSTS_EXIST.COMMENT_2), Tran_List[i], "COMMENT_2");


		CDB_init_cwiptabsts(&CWIPTABSTS_GET);
		TRS.copy(CWIPTABSTS_GET.FACTORY, sizeof(CWIPTABSTS_GET.FACTORY), Tran_List[i], "FACTORY");
		TRS.copy(CWIPTABSTS_GET.OPER, sizeof(CWIPTABSTS_GET.OPER), Tran_List[i], "OPER");
		TRS.copy(CWIPTABSTS_GET.RES_ID, sizeof(CWIPTABSTS_GET.RES_ID), Tran_List[i], "RES_ID");		
		TRS.copy(CWIPTABSTS_GET.LINE_ID, sizeof(CWIPTABSTS_GET.LINE_ID), Tran_List[i], "LINE_ID");
		CWIPTABSTS_GET.SEQ = i_max_ins_seq;

		CDB_select_cwiptabsts(1, &CWIPTABSTS_GET);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0005");
			TRS.set_fieldmsg(out_node, "SELECT CWIPTABSTS_EXIST", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
		
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		if(CDB_select_cwiptabsts_scalar(2, &CWIPTABSTS_EXIST) > 0){
			continue;
		}
		if(CDB_select_cwiptabsts_scalar(3, &CWIPTABSTS_EXIST) > 0){
			memcpy(CWIPTABSTS.CMF_2, s_sys_time, sizeof(s_sys_time));			
			
			TRS.copy(CWIPTABSTS.CMF_3, sizeof(CWIPTABSTS.CMF_3), Tran_List[i], "CMF_3");
			TRS.copy(CWIPTABSTS.CMF_5, sizeof(CWIPTABSTS.CMF_5), Tran_List[i], "CMF_5");					
			memcpy(CWIPTABSTS.CMF_4, CWIPTABSTS_GET.CMF_4, sizeof(CWIPTABSTS.CMF_4));

		}
		if(CDB_select_cwiptabsts_scalar(4, &CWIPTABSTS_EXIST) > 0){
			memcpy(CWIPTABSTS.CMF_4, s_sys_time, sizeof(s_sys_time));
			
			memcpy(CWIPTABSTS.CMF_2, CWIPTABSTS_GET.CMF_2, sizeof(CWIPTABSTS.CMF_2));
			TRS.copy(CWIPTABSTS.CMF_3, sizeof(CWIPTABSTS.CMF_3), Tran_List[i], "CMF_3");
			TRS.copy(CWIPTABSTS.CMF_5, sizeof(CWIPTABSTS.CMF_5), Tran_List[i], "CMF_5");	
		}
		if(CDB_select_cwiptabsts_scalar(5, &CWIPTABSTS_EXIST) > 0){

			memcpy(CWIPTABSTS.CMF_2, s_sys_time, sizeof(s_sys_time));
			memcpy(CWIPTABSTS.CMF_4, s_sys_time, sizeof(s_sys_time));
			
			TRS.copy(CWIPTABSTS.CMF_3, sizeof(CWIPTABSTS.CMF_3), Tran_List[i], "CMF_3");
			TRS.copy(CWIPTABSTS.CMF_5, sizeof(CWIPTABSTS.CMF_5), Tran_List[i], "CMF_5");	
		}
		//데이터 변경여부 체크 end

		CWIPTABSTS.SEQ = ++i_max_ins_seq;
		
		CDB_insert_cwiptabsts(&CWIPTABSTS);

		if(DB_error_code != DB_SUCCESS)
		{
		  LOG_head("CWIPTABSTS ");
		  LOG_printf("CWIPTABSTS ORA- %d   ",DB_error_code);
		  COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

		  strcpy(s_msg_code, "WIP-0004");
		  TRS.add_fieldmsg(out_node, "CWIPTABSTS update", MP_NVST);
		  TRS.add_dberrmsg(out_node, DB_error_msg);
		  gs_log_type.type = MP_LOG_ERROR;
		  gs_log_type.e_type = MP_LOG_E_SYSTEM;
		  gs_log_type.category = MP_LOG_CATE_VIEW;

		  COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
      
		  return MP_FALSE;
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}