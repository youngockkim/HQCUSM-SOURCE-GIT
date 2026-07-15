/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_BatchProcess_MainFunction.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// SUMMARY 재집계를 위한 기능

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2019/02/08  Juhyeon.Jung   Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"


int CSUM_RESUMMARY_EXECUTEBYPERIOD(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int UWIP_SUMMARY_TEMP_LOT(char *s_msg_code, TRSNode *in_node,TRSNode *out_node);

/*******************************************************************************
CSUM_ReSummary_ExecuteByPeriod()
- 
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_ReSummary_ExecuteByPeriod(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_RESUMMARY_EXECUTEBYPERIOD(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_TRANSACTION", out_node);

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
CSUM_RESUMMARY_EXECUTEBYPERIOD()
- 재집계
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_RESUMMARY_EXECUTEBYPERIOD(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MWIPLOTHIS_TAG	MWIPLOTHIS;
	struct MTMPLOTHIS_TAG   MTMPLOTHIS;
	struct RSUMWIPMOV_TAG   RSUMWIPMOV;
	struct RSUMHORMOV_TAG   RSUMHORMOV;
	struct RSUMHORLOS_TAG   RSUMHORLOS;
	struct RSUMWIPEOH_TAG   RSUMWIPEOH;
	
	
	int iStep;

	TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("CSUM_RESUMMARY_EXECUTEBYPERIOD");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	//FROM ~ TO 기간의 데이터 삭제
	//1.RSUMWIPMOV
	CDB_init_rsumwipmov(&RSUMWIPMOV);
	TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, "FACTORY");
	TRS.copy(RSUMWIPMOV.CM_KEY_1, sizeof(RSUMWIPMOV.CM_KEY_1), in_node, "FROM_DATE");
	TRS.copy(RSUMWIPMOV.CM_KEY_2, sizeof(RSUMWIPMOV.CM_KEY_2), in_node, "TO_DATE");
	CDB_delete_rsumwipmov(2, &RSUMWIPMOV);
	if((DB_error_code != DB_SUCCESS) && (DB_error_code != DB_NOT_FOUND))
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV DELETE", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	//2.RSUMHORMOV
	CDB_init_rsumhormov(&RSUMHORMOV);
	TRS.copy(RSUMHORMOV.FACTORY, sizeof(RSUMHORMOV.FACTORY), in_node, "FACTORY");
	TRS.copy(RSUMHORMOV.CM_KEY_1, sizeof(RSUMHORMOV.CM_KEY_1), in_node, "FROM_DATE");
	TRS.copy(RSUMHORMOV.CM_KEY_2, sizeof(RSUMHORMOV.CM_KEY_2), in_node, "TO_DATE");
	CDB_delete_rsumhormov(2, &RSUMHORMOV);
	if((DB_error_code != DB_SUCCESS) && (DB_error_code != DB_NOT_FOUND))
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "RSUMHORMOV DELETE", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	//3.RSUMHORLOS ( 
	CDB_init_rsumhorlos(&RSUMHORLOS);
	TRS.copy(RSUMHORLOS.FACTORY, sizeof(RSUMHORLOS.FACTORY), in_node, "FACTORY");
	TRS.copy(RSUMHORLOS.CMF_1, sizeof(RSUMHORLOS.CMF_1), in_node, "FROM_DATE");
	TRS.copy(RSUMHORLOS.CMF_2, sizeof(RSUMHORLOS.CMF_2), in_node, "TO_DATE");
	CDB_delete_rsumhorlos(2, &RSUMHORLOS);
	if((DB_error_code != DB_SUCCESS) && (DB_error_code != DB_NOT_FOUND))
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "RSUMHORMOV DELETE", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	//4.RSUMWIPEOH ( 
	CDB_init_rsumwipeoh(&RSUMWIPEOH);
	TRS.copy(RSUMWIPEOH.FACTORY, sizeof(RSUMWIPEOH.FACTORY), in_node, "FACTORY");
	TRS.copy(RSUMWIPEOH.CM_KEY_1, sizeof(RSUMWIPEOH.CM_KEY_1), in_node, "FROM_DATE");
	TRS.copy(RSUMWIPEOH.CM_KEY_2, sizeof(RSUMWIPEOH.CM_KEY_2), in_node, "TO_DATE");
	CDB_delete_rsumwipeoh(2, &RSUMWIPEOH);
	if((DB_error_code != DB_SUCCESS) && (DB_error_code != DB_NOT_FOUND))
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "RSUMWIPEOH DELETE", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	
	//시간 ( from + 06:00) ~ to +1 일 06:00)
	CDB_init_mtmplothis(&MTMPLOTHIS);
	TRS.copy(MTMPLOTHIS.TRAN_CMF_1, 8, in_node, "FROM_DATE");
	TRS.copy(MTMPLOTHIS.TRAN_CMF_2, 8, in_node, "TO_DATE");
	CDB_select_mtmplothis(2, &MTMPLOTHIS);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "FROM TO DATE GET", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	if ((COM_isspace(MTMPLOTHIS.CM_KEY_1, sizeof(MTMPLOTHIS.CM_KEY_1)) ==MP_TRUE) ||
		(COM_isspace(MTMPLOTHIS.CM_KEY_2, sizeof(MTMPLOTHIS.CM_KEY_2)) ==MP_TRUE))
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "FROM TO DATE GET", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	
	/* MWIPLOTHIS 기준 MTMPLOTHIS 에 데이터 INSERT */
	iStep = 2;
	CDB_init_mwiplothis(&MWIPLOTHIS);

	memcpy(MWIPLOTHIS.TRAN_CMF_1, MTMPLOTHIS.CM_KEY_1, 14);
	memcpy(MWIPLOTHIS.TRAN_CMF_2, MTMPLOTHIS.CM_KEY_2, 14);


	CDB_open_mwiplothis(iStep, &MWIPLOTHIS);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "MWIPLOTHIS OPEN", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		CDB_fetch_mwiplothis(iStep, &MWIPLOTHIS);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			CDB_close_mwiplothis(iStep);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "MWIPLOTHIS FETCH", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			CDB_close_mwiplothis(iStep);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		memset(s_msg_code, 0x00, MP_SIZE_MSG);
		

		tran_in_node = TRS.create_node("SUM_LOT_IN");
		tran_out_node = TRS.create_node("SUM_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);

		TRS.add_char(tran_in_node, "PROCSTEP",'1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		TRS.add_int(tran_in_node, "HIST_SEQ", MWIPLOTHIS.HIST_SEQ);

		if(UWIP_SUMMARY_TEMP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			if (memcmp(s_msg_code, "WIP-0260", 8) == 0)
			{
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				continue;
			}
			//TRS.init_node(out_node);
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);

			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Close 추가
			CDB_close_mwiplothis(iStep);

			return MP_FALSE;
		}

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}