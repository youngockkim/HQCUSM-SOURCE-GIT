/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_BatchProcess_MainFunction.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// MTMPLOTHIS 기준데이터를 읽어서  SUMMARY 및 필요한 데이터 처리 진행.

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2018/11/27  Juhyeon.Jung       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"


int CSUM_BATCHPROCESS_TRANSACTION_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CSUM_BatchProcess_Transaction_Gerp_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
CSUM_BatchProcess_Transaction_Gerp()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Transaction_Gerp(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CSUM_BATCHPROCESS_TRANSACTION_GERP(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_TRANSACTION_GERP", out_node);

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
CSUM_BATCHPROCESS_TRANSACTION_GERP()
- Main sub function of "CSUM_BatchProcess_Transaction_Gerp" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_TRANSACTION_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MTMPLOTHIS_TAG MTMPLOTHIS;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
	
	//struct RSUMPRCLOG_TAG RSUMPRCLOG;
	

	struct worktime_tag cur_work_time;
	
	char cIUDFlag ;
	char s_sys_time[14];
	int iStep  = 0;
	char s_actual_time[15];
	char c_work_shift = ' ';
		
    LOG_head("CSUM_BATCHPROCESS_TRANSACTION_GERP");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}

	//EOH (향후 진행)
	//CSUM_BATCHPROCESS_EOH();

	//SUMMARY TEMP TABLE OPEN
	iStep = 101;
	DBC_init_mtmplothis(&MTMPLOTHIS);  //PROCESS_FLAG 가 SPACE 인것만 조회

	if(TRS.get_char(in_node, "PROCSTEP") != ' ')
		MTMPLOTHIS.PROCESS_FLAG = TRS.get_char(in_node, "PROCSTEP"); //MAINT 용
	
	DBC_open_mtmplothis(iStep, &MTMPLOTHIS);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "MTMPLOTHIS OPEN", MP_NVST);
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
		DBC_fetch_mtmplothis(iStep, &MTMPLOTHIS);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			DBC_close_mtmplothis(iStep);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "MTMPLOTHIS FETCH", MP_NVST);
			TRS.set_fieldmsg(out_node, "ITEM CODE", MP_STR, sizeof(MTMPLOTHIS.LOT_ID), MTMPLOTHIS.LOT_ID);				
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			DBC_close_mtmplothis(iStep);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//WORK TIME GET.
		memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
		memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash 초기화 되지 않은 변수
		memcpy(s_actual_time, MTMPLOTHIS.TRAN_TIME, sizeof(MTMPLOTHIS.TRAN_TIME));  // Server Crash 초기화 되지 않은 변수
		CCOM_get_work_time(s_actual_time, &cur_work_time);
		c_work_shift = CCOM_get_work_shift(s_actual_time);

		/*if (COM_isspace(MTMPLOTHIS.CM_KEY_3, sizeof(MTMPLOTHIS.CM_KEY_3)) == MP_TRUE)
			continue;*/
		
		//DELETE LOT HISTORY 인경우 별도 처리함.
		if((MTMPLOTHIS.HIST_DEL_FLAG == 'Y') &&
			 (memcmp(MTMPLOTHIS.TRAN_CODE, "TERMINATE", strlen("TERMINATE")) != 0))
		{
			//DELETE LOT HISTORY 인경우 필요한 경우만 처리
			DBC_delete_mtmplothis(1, &MTMPLOTHIS);
			DB_commit();
			continue;
		}

		//PROCESS FLAG (처리중이거나/ 삭제/ MAINT 등인 레코드이면 처리안함.
		if(MTMPLOTHIS.PROCESS_FLAG != ' ')
		{
			if (TRS.get_char(in_node, "PROCSTEP") !=  MTMPLOTHIS.PROCESS_FLAG)
				continue;
		}

		/* MWIPELTSTS TABLE */
		if (memcmp(MTMPLOTHIS.CREATE_CODE, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE)) == 0)
		{
			CDB_init_mwipeltsts(&MWIPELTSTS);
			memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS.LOT_ID, sizeof(MTMPLOTHIS.LOT_ID));
			CDB_select_mwipeltsts(1, &MWIPELTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				MWIPELTSTS.HIST_SEQ = 1;
				memcpy(MWIPELTSTS.CURING_TIME, s_sys_time, sizeof(MWIPELTSTS.CURING_TIME)) ;//파티션키로 사용하고 있으므로 업데이트 금지
				CDB_insert_mwipeltsts(&MWIPELTSTS);
			}
		}
		
		/************************************/
		//MWIPELTSTS, MTMPLOTHIS 에 들어가야 하는값 이 잇으면 보정함.
		/************************************/
		
		//END RESID 가 안들어 간경우 보정.
		if (COM_isspace(MTMPLOTHIS.END_RES_ID, sizeof(MTMPLOTHIS.END_RES_ID)) == MP_TRUE)
		{
			DBC_init_mwiplothis(&MWIPLOTHIS);
			memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS.LOT_ID, sizeof(MTMPLOTHIS.LOT_ID));
			MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS.HIST_SEQ ;
			DBC_select_mwiplothis(1, &MWIPLOTHIS);
			if(DB_error_code == DB_SUCCESS)
			{
				memcpy(MTMPLOTHIS.END_RES_ID, MWIPLOTHIS.END_RES_ID, sizeof(MWIPLOTHIS.END_RES_ID));
			}
		}

		//HALFCELL 이고 TABBER LINE / ORDER / 설비를 TABBER 기준으로 변경
		if ((memcmp(MTMPLOTHIS.CREATE_CODE, HQCEL_LOT_CREATECODE_HCELBX, strlen(HQCEL_LOT_CREATECODE_HCELBX)) == 0) &&
			(memcmp(MTMPLOTHIS.TRAN_CODE, "START", strlen("START")) == 0) &&
			(memcmp(MTMPLOTHIS.OLD_OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)) == 0))
		{
			memset(MTMPLOTHIS.CM_KEY_1, ' ', sizeof(MTMPLOTHIS.CM_KEY_1));
			memset(MTMPLOTHIS.ORDER_ID, ' ' , sizeof(MTMPLOTHIS.ORDER_ID));
			
			memcpy(MTMPLOTHIS.CM_KEY_1, MTMPLOTHIS.TRAN_CMF_4, sizeof(MTMPLOTHIS.TRAN_CMF_4));
			//memcpy(MTMPLOTHIS.ORDER_ID, MTMPLOTHIS.TRAN_CMF_5, sizeof(MTMPLOTHIS.TRAN_CMF_5));  // Server Crash
			memcpy(MTMPLOTHIS.ORDER_ID, MTMPLOTHIS.TRAN_CMF_5, sizeof(MTMPLOTHIS.ORDER_ID));  // Server Crash
		}

		/* CM_KEY 재정의 */

		//CM_KEY_5 는 WORK SHIFT 로 사용
		MTMPLOTHIS.CM_KEY_5[0] = c_work_shift;

		//MTMPLOTHIS.CM_KEY_1 : LINE_ID
		if (COM_isspace(MTMPLOTHIS.CM_KEY_1, sizeof(MTMPLOTHIS.CM_KEY_1)) == MP_TRUE)
		{
			memcpy(MTMPLOTHIS.CM_KEY_1, MTMPLOTHIS.LOT_CMF_1, sizeof(MTMPLOTHIS.LOT_CMF_1));
		}
		
		if (memcmp(MTMPLOTHIS.OLD_OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER))  == 0)
		{
			//MTMPLOTHIS.
			//CM_KEY_2 : FQC_POWER
			//CM_KEY_4 : FQC_GRADE
			CDB_init_cedclotrlh(&CEDCLOTRLH);
			memcpy(CEDCLOTRLH.FACTORY, MTMPLOTHIS.FACTORY, sizeof(CEDCLOTRLH.FACTORY));
			memcpy(CEDCLOTRLH.INS_TYPE, "FC", 2);
			memcpy(CEDCLOTRLH.LOT_ID, MTMPLOTHIS.LOT_ID, sizeof(MTMPLOTHIS.LOT_ID));
			CEDCLOTRLH.HIST_SEQ = MTMPLOTHIS.HIST_SEQ;
			CDB_select_cedclotrlh(2, &CEDCLOTRLH);
			if(DB_error_code == DB_SUCCESS)
			{
				memcpy(MTMPLOTHIS.CM_KEY_2, CEDCLOTRLH.POWER, sizeof(CEDCLOTRLH.POWER));
				memcpy(MTMPLOTHIS.CM_KEY_4, CEDCLOTRLH.GRADE, sizeof(CEDCLOTRLH.GRADE));
			}

			if ((COM_isspace(MTMPLOTHIS.CM_KEY_2, sizeof(MTMPLOTHIS.CM_KEY_2)) == MP_TRUE) ||
				(COM_isspace(MTMPLOTHIS.CM_KEY_4, sizeof(MTMPLOTHIS.CM_KEY_4)) == MP_TRUE))
			{
				memcpy(MTMPLOTHIS.CM_KEY_2, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
				memcpy(MTMPLOTHIS.CM_KEY_4, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
			}

		}
		else if (memcmp(MTMPLOTHIS.CREATE_CODE, HQCEL_LOT_CREATECODE_STRING, strlen(HQCEL_LOT_CREATECODE_STRING)) == 0)
		{
			/* STRING 실적일경우 LEFT/RIGHT TABLE */
		
			//SUB-RESOURCE / LEFT - RIGHT
			MTMPLOTHIS.CM_KEY_4[0] = MTMPLOTHIS.LOT_ID[2] ;
		}
	
		//MTMPLOTHIS.CM_KEY_3 : CREATE CODE
		if (COM_isspace(MTMPLOTHIS.CM_KEY_3, sizeof(MTMPLOTHIS.CM_KEY_3)) == MP_TRUE)
		{
			memcpy(MTMPLOTHIS.CM_KEY_3, MTMPLOTHIS.CREATE_CODE, sizeof(MTMPLOTHIS.CREATE_CODE));
		}

		
		
		/*********************************************************************/
		//0 . TRANSACTION  별 처리 옵션
		/*********************************************************************/
		if (memcmp(MTMPLOTHIS.TRAN_CODE, "END", strlen("END")) == 0)
		{

			if (MTMPLOTHIS.PROCESS_FLAG =='R')
			{
				//ERP 실적 재전송
				TRS.set_string(in_node, "LOT_ID", MTMPLOTHIS.LOT_ID, sizeof(MTMPLOTHIS.LOT_ID));
				TRS.set_string(in_node, "BACK_TIME", MTMPLOTHIS.TRAN_TIME, sizeof(MTMPLOTHIS.TRAN_TIME));
				TRS.set_char(in_node, "INF_UPLOAD_TYPE_FLAG", '5'); 
				if (CINF_UPLOAD_ERP_FUNCTION_GERP(s_msg_code,in_node, out_node ) == MP_FALSE)
				{
					//ERROR 
					DB_rollback();
					continue;
				}
			}
			else
			{
				//LOT TRACE AND 시간별 SUMMARY, LOT TRACE 등 기본 데이터 처리
				if (CSUM_SUMMARY_WIP_TRAN_HOUR(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
				{
					//DO
				}

				//WIP MOVEMENT SUMMARY
				if (CSUM_SUMMARY_WIP_TRAN_ENDLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
				{
					//ERROR 
					DB_rollback();
					continue;
				}
			}
			
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "START", strlen("START")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_STARTLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "CREATE", strlen("CREATE")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_CREATELOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "ADAPT", strlen("ADAPT")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_ADAPTLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "SPLIT", strlen("SPLIT")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_SPLITLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}

		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "LOSS", strlen("LOSS")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_LOSSLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "COMBINE", strlen("COMBINE")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_COMBINELOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
			
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "CV", strlen("CV")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_CVLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "MERGE", strlen("MERGE")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_MERGELOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
			
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "REWORK", strlen("REWORK")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_REWORKLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "SHIP", strlen("SHIP")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_SHIPLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "SKIP", strlen("SKIP")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_SKIPLOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "MOVE", strlen("MOVE")) == 0)
		{
			if (CSUM_SUMMARY_WIP_TRAN_MOVELOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}
		else if (memcmp(MTMPLOTHIS.TRAN_CODE, "TERMINATE", strlen("TERMINATE")) == 0)
		{
			//Cleaving Half Cell Confirm ERP Interface 수행
			TRS.set_string(in_node, "LOT_ID", MTMPLOTHIS.LOT_ID, sizeof(MTMPLOTHIS.LOT_ID));
			TRS.set_string(in_node, "BACK_TIME", MTMPLOTHIS.TRAN_TIME, sizeof(MTMPLOTHIS.TRAN_TIME));
			TRS.set_char(in_node, "INF_UPLOAD_TYPE_FLAG", '7'); 

			if(MTMPLOTHIS.HIST_DEL_FLAG == 'Y')
			{
				TRS.set_char(in_node, "CANCEL_FLAG", 'Y');
			}
			if (CINF_UPLOAD_ERP_FUNCTION_GERP(s_msg_code,in_node, out_node ) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
			if (CSUM_SUMMARY_WIP_TRAN_TERMINATELOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
			{
				//ERROR 
				DB_rollback();
				continue;
			}
		}


		// Delete MTMPLOTHIS Data
		cIUDFlag = 'D';
		if (memcmp(MTMPLOTHIS.TRAN_CODE, "COMBINE", strlen("COMBINE")) == 0)
		{
			//cIUDFlag = 'E';
		}
		if (cIUDFlag == 'D')
		{
			DBC_delete_mtmplothis(1, &MTMPLOTHIS);
		//	CSUM_insert_cbaklothis(&CBAKLOTHIS);
		}
		
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.set_fieldmsg(out_node, "CBOMMATDEF UPDATE", MP_NVST);
				TRS.set_fieldmsg(out_node, "ITEM CODE", MP_STR, sizeof(MTMPLOTHIS.LOT_ID), MTMPLOTHIS.LOT_ID);				
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				continue;
			}
		}

		DB_commit();

		/*********************************************************************/
		//0.2 . DATA CLEAR
		/*********************************************************************/
		//if (CUS_BATCHPROCESS_DATACLEAR(s_msg_code, in_node, out_node) == MP_FALSE)
		//{
		//	//DO NOTHING
		//}

		//DB_commit();
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
CSUM_BatchProcess_Transaction_Gerp_Validation()
- Validation check sub function of "CSUM_BatchProcess_Transaction_Gerp" function
- Check the Conditions before Custom End Lot Function List
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Transaction_Gerp_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	/* ProcStep Validation */
	if ((TRS.get_procstep(in_node) == ' ')  || (TRS.get_procstep(in_node) == '\0'))
	{
		//BATCH 에서 실행되므로 PROC STEP 은 1로 무조건 실행함.
		TRS.set_char(in_node, IN_PROCSTEP, '1');
	}
	if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
		strcpy(s_msg_code, "WIP-0001");
        TRS.set_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

	return MP_TRUE;
}


