/*******************************************************************************

	System      : MESplus
	Module      : Update FQC Result
	File Name   : CWIP_update_fqc_result.c

	MES Version : 5.0

	Function List
		-

	Detail Description
		-

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2018.12.22  SW.HWANG

	Copyright(C) 1998-2008 Miracom,Inc.
	All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_UPDATE_FQC_RESULT(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node);


/*******************************************************************************
	CWIP_Update_Fqc_Result()
		- Update_Fqc_Result
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Fqc_Result(TRSNode* in_node, TRSNode* out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret = MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_FQC_RESULT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_Update_Fqc_Result", out_node);

	if (i_ret == MP_TRUE)
	{
		if (gb_multi_transaction == MP_FALSE)
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
	CWIP_UPDATE_FQC_RESULT()
		- UPDATE_FQC_RESULT
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- char *s_msg_code : Error Msg Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_FQC_RESULT(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	// INIT
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CWIPLOTTRC_TAG CWIPLOTTRC;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CWIPLOTSTR_TAG CWIPLOTSTR;
	struct CEDCINSDAT_TAG CEDCINSDAT;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_G;
	struct CWIPGRTAVG_TAG CWIPGRTAVG;
	struct CWIPRWKDAT_TAG CWIPRWKDAT;// 2023-03-08 JSLEE
	struct CWIPABNLOG_TAG CWIPABNLOG; // 23.5.01 Log Add
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	char store_flag = HQCEL_FLAG_NO;
	char tmpOper[10];

	char s_sys_time[14];
	char res_id[20];
	int mwiplotsts_flag = 102;
	int i_max_seq_num;
	int d_max_seq_num;
	int i_ins_his_cnt;
	//int i_power;


	char operTmp[10];
	
	//init 

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	//	TRSNode* tran_in_node_adapt;
	//	TRSNode* tran_out_node_adapt;  

		// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_FQC_RESULT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	/*if (TRS.get_char(in_node, "TYPE_FLAG") != '1')
	{
		if(TRS.mem_cmp(in_node, "GRADE", "G01", strlen("G01")) != 0
			&& TRS.mem_cmp(in_node, "GRADE", "G02", strlen("G02")) != 0)
		{
			if(COM_isnullspace(TRS.get_string(in_node, "DEFECT_CODE")) == MP_TRUE)
			{
				strcpy(s_msg_code, "WIP-0001");
				TRS.add_fieldmsg(out_node, "DEFECT_CODE", MP_NVST);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_isnullspace(TRS.get_string(in_node, "CELL_INFO")) == MP_TRUE)
			{
				strcpy(s_msg_code, "WIP-0001");
				TRS.add_fieldmsg(out_node, "CELL_INFO", MP_NVST);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else if(TRS.mem_cmp(in_node, "GRADE", "G02", strlen("G02")) == 0)
		{
			if(TRS.mem_cmp(in_node, "DEFECT_CODE", "E19", strlen("E19")) != 0
				&& TRS.mem_cmp(in_node, "DEFECT_CODE", "A01", strlen("A01")) != 0)
			{
				strcpy(s_msg_code, "WIP-0595");

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_isnullspace(TRS.get_string(in_node, "CELL_INFO")) == MP_TRUE)
			{
				strcpy(s_msg_code, "WIP-0001");
				TRS.add_fieldmsg(out_node, "CELL_INFO", MP_NVST);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else if(TRS.mem_cmp(in_node, "GRADE", "G01", strlen("G01")) == 0)
		{
			if(COM_isnullspace(TRS.get_string(in_node, "DEFECT_CODE")) == MP_FALSE)
			{
				strcpy(s_msg_code, "WIP-0596");

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}*/


	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	// SEL MWIPLOTSTS
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(in_node, "LOT_ID"), strlen(TRS.get_string(in_node, "LOT_ID")));

	DBC_select_mwiplotsts(mwiplotsts_flag, &MWIPLOTSTS);
	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0044");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	//이미 TERMINATE 된 LOT CHECK
	if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
	{
		//TERMINATE 정보가 있으면 에러처리함.
		strcpy(s_msg_code, "WIP-0594");
		TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
		//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);  // Server Crash
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);  // Server Crash
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	//PACKING 에서 LOT VALIDATION 을 위해 보낸데이터 일경우 체크
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
	memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

	//C: COMPLETE,  I:INITIAL(AUTO PACKING 에서 사용함)	, //D: ERP->MES PACKING 해제된 LOT
	CWIPLOTPAK.STATUS_FLAG = 'C';

	//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 재FQC 못하게함.
	if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
	{
		//완료된 PACKING 정보가 있으면 에러처리함.
		strcpy(s_msg_code, "WIP-0564");
		TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
		//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID); // Server Crash
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID); // Server Crash
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	// OPEN MWIPELTSTS
	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, TRS.get_string(in_node, "LOT_ID"), strlen(TRS.get_string(in_node, "LOT_ID")));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);
	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code != DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPELTSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}


	/* - [GERP PROJECT] 시작****************************************************************/
	if (TRS.get_char(in_node, "TYPE_FLAG") != '1')
	{
		// Packing 이력 확인 
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		// 2023-05-04 JHEE PACKING 여부와 이력 확인 
		if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
		{
			//FQC 이력 확인 
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CEDCLOTRLT.INS_TYPE, "FC", strlen("FC"));
			TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
			CDB_select_cedclotrlt(1, &CEDCLOTRLT);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				// 이전 FQC와 동일 등급 POWER 아니면 재작업 오더 확인 
				if (TRS.mem_cmp(in_node, "INS_VALUE", CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE)) != 0 ||
					TRS.mem_cmp(in_node, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)) != 0)
				{
					//재작업 선정 모듈 중 오더 2회 에 대하여 포장이력이 없는 것이 최종 재작업 오더의 모듈
					CDB_init_cwiprwkdat(&CWIPRWKDAT);
					memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
					TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "LOT_ID");
					//case 2 : pallet id가 없는 재작업 오더 모듈목록 포함
					if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) <= 0)
					{
						strcpy(s_msg_code, "WIP-0616"); // This module requires a rework order
						TRS.add_fieldmsg(out_node, "CWIPRWKDAT SCALAR(2)", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);// 2023-03-09 JSLEE ADD
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}

				// OI에서 보내주는 INS_VALUE값이 잘못 올라는 경우가 있어
				//GRADE 값으로 한번 더 비교함
				//24.02.01
				if (TRS.mem_cmp(in_node, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE)) != 0 ||
					TRS.mem_cmp(in_node, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)) != 0)
				{
					//재작업 선정 모듈 중 오더 2회 에 대하여 포장이력이 없는 것이 최종 재작업 오더의 모듈
					CDB_init_cwiprwkdat(&CWIPRWKDAT);
					memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
					TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "LOT_ID");
					//case 2 : pallet id가 없는 재작업 오더 모듈목록 포함
					if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) <= 0)
					{
						strcpy(s_msg_code, "WIP-0616"); // This module requires a rework order
						TRS.add_fieldmsg(out_node, "CWIPRWKDAT SCALAR(2)", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);// 2023-03-09 JSLEE ADD
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
			}
		}
		/* - [GERP PROJECT] 끝******************************************************************/

		// Check Ground Test
		// CEDCLOTRLT.INS_TYPE = GR
		CDB_init_cedclotrlt(&CEDCLOTRLT);
		memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CEDCLOTRLT.INS_TYPE, "GR", strlen("GR"));
		TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotrlt(2, &CEDCLOTRLT);
		if (DB_error_code != DB_SUCCESS)
		{
			//if GR does not exist, create one.
			if (DB_error_code == DB_NOT_FOUND)
			{

				//change OPER = M3100
				memcpy(MWIPLOTSTS.OPER, "M3100", strlen("M3100"));
				DBC_update_mwiplotsts(1, &MWIPLOTSTS);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "EDC-0004");
					TRS.set_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				strcpy(res_id, TRS.get_string(in_node, "RES_ID"));	//US-E#-FQC-02

				//US-E#-GRT-01
				res_id[6] = 'G';
				res_id[7] = 'R';
				res_id[8] = 'T';
				res_id[11] = '1';

				/* Start Lot */
				tran_in_node = TRS.create_node("START_LOT_IN");
				tran_out_node = TRS.create_node("START_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.add_string(tran_in_node, "OPER", "M3100", strlen("M3100"));
				TRS.add_nstring(tran_in_node, "RES_ID", res_id);
				TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "WORK_LINE"));
				if (CWIP_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					// Do Nothing
				}

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);

				CDB_init_cedclotrlt(&CEDCLOTRLT);

				memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CEDCLOTRLT.INS_TYPE, "GR", strlen("GR"));
				memcpy(CEDCLOTRLT.OPER, "M3100", strlen("M3100"));
				memcpy(CEDCLOTRLT.RES_ID, res_id, strlen(res_id));

				TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
				TRS.copy(CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID), in_node, "WORK_LINE");

				TRS.copy(CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID), in_node, "INS_USER_ID");
				memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));

				memcpy(CEDCLOTRLT.RESULT_VALUE, "OK", strlen("OK"));
				TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "INS_USER_ID");
				memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));

				CEDCLOTRLT.TYPE_FLAG = TRS.get_char(in_node, "TYPE_FLAG");
				CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ + 1;
				CEDCLOTRLT.QTY = 1;
				CEDCLOTRLT.INS_CNT = 1;

				memcpy(CEDCLOTRLT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				memcpy(CEDCLOTRLT.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				memcpy(CEDCLOTRLT.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
				TRS.copy(CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLT.LOC_ID), in_node, "LOC_ID");

				CDB_insert_cedclotrlt(&CEDCLOTRLT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "EDC-0004");
					TRS.set_fieldmsg(out_node, "CEDCLOTRLT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				/* History */
				CDB_init_cedclotrlh(&CEDCLOTRLH);
				memcpy(CEDCLOTRLH.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLH.FACTORY));
				memcpy(CEDCLOTRLH.INS_TYPE, CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLH.INS_TYPE));
				memcpy(CEDCLOTRLH.OPER, CEDCLOTRLT.OPER, sizeof(CEDCLOTRLH.OPER));
				memcpy(CEDCLOTRLH.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLH.RES_ID));
				memcpy(CEDCLOTRLH.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID));
				memcpy(CEDCLOTRLH.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLH.LINE_ID));
				memcpy(CEDCLOTRLH.INS_USER_ID, CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLH.INS_USER_ID));
				memcpy(CEDCLOTRLH.INS_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLH.INS_TIME));
				memcpy(CEDCLOTRLH.RESULT_VALUE, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE));
				memcpy(CEDCLOTRLH.RESULT_USER_ID, CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID));
				memcpy(CEDCLOTRLH.RESULT_TIME, CEDCLOTRLT.RESULT_TIME, sizeof(CEDCLOTRLH.RESULT_TIME));
				memcpy(CEDCLOTRLH.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLH.MAT_ID));
				memcpy(CEDCLOTRLH.FLOW, CEDCLOTRLT.FLOW, sizeof(CEDCLOTRLH.FLOW));
				memcpy(CEDCLOTRLH.ORDER_ID, CEDCLOTRLT.ORDER_ID, sizeof(CEDCLOTRLH.ORDER_ID));
				memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1));
				memcpy(CEDCLOTRLH.LOC_ID, CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLH.LOC_ID));
				CEDCLOTRLH.TYPE_FLAG = CEDCLOTRLT.TYPE_FLAG;
				CEDCLOTRLH.HIST_SEQ = 1;
				CEDCLOTRLH.QTY = 1;
				CEDCLOTRLH.INS_CNT = 1;

				CDB_insert_cedclotrlh(&CEDCLOTRLH);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "EDC-0004");
					TRS.set_fieldmsg(out_node, "CEDCLOTRLH INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLH.FACTORY), CEDCLOTRLH.FACTORY);
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLH.INS_TYPE), CEDCLOTRLH.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
					TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CEDCLOTRLH.HIST_SEQ);
					TRS.add_fieldmsg(out_node, "INS_CNT", MP_INT, CEDCLOTRLH.INS_CNT);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				// Get Max Sequence Number
				d_max_seq_num = 0;
				CDB_init_cedcinsdat(&CEDCINSDAT);
				memcpy(CEDCINSDAT.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID));
				memcpy(CEDCINSDAT.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCINSDAT.RES_ID));
				//memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCINSDAT.TRAN_TIME));IS-21-01-094 MES logic 개선
				memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));

				d_max_seq_num = (int)CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);

				// Common
				CDB_init_cedcinsdat(&CEDCINSDAT);
				memcpy(CEDCINSDAT.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID));
				memcpy(CEDCINSDAT.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCINSDAT.RES_ID));
				memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));
				memcpy(CEDCINSDAT.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCINSDAT.LINE_ID));
				memcpy(CEDCINSDAT.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCINSDAT.FACTORY));
				memcpy(CEDCINSDAT.OPER, CEDCLOTRLT.OPER, sizeof(CEDCINSDAT.OPER));
				CEDCINSDAT.LOT_HIST_SEQ = CEDCLOTRLT.LAST_HIST_SEQ;

				//GET AVG GRT VALUES BY THE MAT_ID
				CDB_init_cedclotrlt(&CEDCLOTRLT_G);
				memcpy(CEDCLOTRLT_G.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT_G.MAT_ID));
				//20201002 HCHKIM CWIPGRTAVG CHECK
				CDB_init_cwipgrtavg(&CWIPGRTAVG);
				memcpy(CWIPGRTAVG.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(CWIPGRTAVG.MAT_ID));

				CDB_select_cwipgrtavg(1, &CWIPGRTAVG);
				if (DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{
						CDB_select_cedclotrlt(3, &CEDCLOTRLT_G);
						if (DB_error_code != DB_SUCCESS)
						{
							//DO NOTHING
						}
					}
				}
				else
				{
					memcpy(CEDCLOTRLT_G.CMF_1, CWIPGRTAVG.STEP_1_MEASURE, sizeof(CEDCLOTRLT_G.CMF_1));
					memcpy(CEDCLOTRLT_G.CMF_2, CWIPGRTAVG.STEP_2_MEASURE, sizeof(CEDCLOTRLT_G.CMF_2));
					memcpy(CEDCLOTRLT_G.CMF_3, CWIPGRTAVG.STEP_3_MEASURE, sizeof(CEDCLOTRLT_G.CMF_3));
					memcpy(CEDCLOTRLT_G.CMF_4, CWIPGRTAVG.STEP_4_MEASURE, sizeof(CEDCLOTRLT_G.CMF_4));
				}
				//CDB_select_cedclotrlt(3, &CEDCLOTRLT_G);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_MODULE_ID", sizeof("I_GRD_01_MODULE_ID"));
				TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.LOT_ID), in_node, "LOT_ID");
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_1_MEASURE_OHM", sizeof("I_GRD_01_STEP_1_MEASURE_OHM"));
				memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_1, sizeof(CEDCLOTRLT_G.CMF_1));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_1_RESULT", sizeof("I_GRD_01_STEP_1_RESULT"));
				memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_2_MEASURE_OHM", sizeof("I_GRD_01_STEP_2_MEASURE_OHM"));
				memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_2, sizeof(CEDCLOTRLT_G.CMF_2));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_2_RESULT", sizeof("I_GRD_01_STEP_2_RESULT"));
				memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_3_MEASURE_OHM", sizeof("I_GRD_01_STEP_3_MEASURE_OHM"));
				memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_3, sizeof(CEDCLOTRLT_G.CMF_3));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_3_RESULT", sizeof("I_GRD_01_STEP_3_RESULT"));
				memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_4_MEASURE_OHM", sizeof("I_GRD_01_STEP_4_MEASURE_OHM"));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				if (memcmp(CEDCLOTRLT_G.CMF_4, "0.00000", 1) == 0)
				{
					memcpy(CEDCINSDAT.PARAM_VALUE, " ", sizeof(" "));
				}
				else
				{
					memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_4, sizeof(CEDCLOTRLT_G.CMF_4));
				}
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_4_RESULT", sizeof("I_GRD_01_STEP_4_RESULT"));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				if (memcmp(CEDCLOTRLT_G.CMF_4, "0.00000", 1) == 0)
				{
					memcpy(CEDCINSDAT.PARAM_VALUE, " ", sizeof(" "));
				}
				else
				{
					memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
				}
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				/* End Lot */
				tran_in_node = TRS.create_node("END_LOT_IN");
				tran_out_node = TRS.create_node("END_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.add_string(tran_in_node, "OPER", "M3100", strlen("M3100"));
				TRS.add_nstring(tran_in_node, "RES_ID", res_id);
				TRS.add_string(tran_in_node, "TRAN_CMF_2", s_sys_time, sizeof(s_sys_time)); //TRAN_CMF_2 에 검사데이터 처리후 END 했을경우 해당 시간 넣음.
				TRS.add_char(tran_in_node, "INSPECT_FLAG", 'Y');
				if (EAPMES_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE) // GR
				{
					// Do Nothing
				}

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}

	// Insert OR Update CEDCLOTRLT
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLT.INS_TYPE), in_node, "INS_TYPE");
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);

	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			CEDCLOTRLT.INS_CNT = 0;
			memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
			CDB_insert_cedclotrlt(&CEDCLOTRLT);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

	}

	//현재 CEDCLOTRLT.INS_CNT  와 실제 DB 의 INS_CNT 비교
	/*
	if (CEDCLOTRLT.INS_CNT != TRS.get_int(in_node, "INS_CNT"))
	{
		strcpy(s_msg_code, "WIP-0602");
		TRS.set_fieldmsg(out_node, "HISTORY SEQUECT MISMATCH", MP_NVST);
		 gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	*/

	TRS.copy(CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID), in_node, "WORK_LINE");
	TRS.copy(CEDCLOTRLT.OPER, sizeof(CEDCLOTRLT.OPER), in_node, "OPER");
	TRS.copy(CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID), in_node, "RES_ID");

	//WORK SHIFT
	//TRS.copy(CEDCLOTRLT.WORK_SHIFT, sizeof(CEDCLOTRLT.WORK_SHIFT), in_node, "WORK_SHIFT");
	CEDCLOTRLT.WORK_SHIFT[0] = CCOM_get_work_shift(s_sys_time);

	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	TRS.copy(CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLT.INS_TYPE), in_node, "INS_TYPE");

	TRS.copy(CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID), in_node, "INS_USER_ID");
	memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));

	TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "RESULT_USER_ID");
	memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));



	TRS.copy(CEDCLOTRLT.RLT_COMMENT, sizeof(CEDCLOTRLT.RLT_COMMENT), in_node, "RLT_COMMENT");
	TRS.copy(CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE), in_node, "GRADE");

	/***************************************************
	* MANUAL 처리시 CEDCLOTFQC 저장 (설비에서 올라오는 데이터 테이블)
	***************************************************/
	memset(CEDCLOTRLT.RESULT_VALUE, ' ', sizeof(CEDCLOTRLT.RESULT_VALUE));
	memset(CEDCLOTRLT.INS_VALUE, ' ', sizeof(CEDCLOTRLT.INS_VALUE));
	if (TRS.get_char(in_node, "TYPE_FLAG") != '1')
	{
		//매뉴얼작업(OI) 일경우 RESULT VALUE 변경
		if (memcmp(CEDCLOTRLT.GRADE, "G01", 3) == 0)
		{
			CEDCLOTRLT.RESULT_VALUE[0] = 'A';
			memcpy(CEDCLOTRLT.INS_VALUE, "CL510", strlen("CL510"));
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G02", 3) == 0)
		{
			CEDCLOTRLT.RESULT_VALUE[0] = 'A';
			memcpy(CEDCLOTRLT.INS_VALUE, "CL511", strlen("CL511"));
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G03", 3) == 0)		//--[G03/G04 로직 추가]
		{
			CEDCLOTRLT.RESULT_VALUE[0] = 'A';
			memcpy(CEDCLOTRLT.INS_VALUE, "CL520", strlen("CL520"));
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G04", 3) == 0)		//--[G03/G04 로직 추가]	
		{
			CEDCLOTRLT.RESULT_VALUE[0] = 'A';
			memcpy(CEDCLOTRLT.INS_VALUE, "CL530", strlen("CL530"));
		}
		else if (CEDCLOTRLT.GRADE[0] == 'B')
		{
			CEDCLOTRLT.RESULT_VALUE[0] = 'B';
			memcpy(CEDCLOTRLT.INS_VALUE, "CL512", strlen("CL512"));
		}
		else if (CEDCLOTRLT.GRADE[0] == 'C')
		{
			CEDCLOTRLT.RESULT_VALUE[0] = 'C';
			memcpy(CEDCLOTRLT.INS_VALUE, "CL514", strlen("CL514"));
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G06", 3) == 0)
		{
			memcpy(CEDCLOTRLT.RESULT_VALUE, "SC", 2);
			memcpy(CEDCLOTRLT.INS_VALUE, "CL207", strlen("CL207"));
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "RWK", 3) == 0)
		{
			memcpy(CEDCLOTRLT.RESULT_VALUE, "RW", 2);
			memcpy(CEDCLOTRLT.INS_VALUE, "RWK", strlen("RWK"));
		}
		else
		{
			TRS.copy(CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE), in_node, "RESULT_VALUE");
			TRS.copy(CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE), in_node, "INS_VALUE");
		}
	}
	else
	{
		//설비에서 올라온경우
		TRS.copy(CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE), in_node, "RESULT_VALUE");
		TRS.copy(CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE), in_node, "INS_VALUE");
	}


	TRS.copy(CEDCLOTRLT.CMF_4, sizeof(CEDCLOTRLT.CMF_4), in_node, "POWER"); //FQC PPMP 값
	TRS.copy(CEDCLOTRLT.CMF_5, sizeof(CEDCLOTRLT.CMF_5), in_node, "REJUDGMENT"); //REJUDGMENT 추가(2023/09/13)

	TRS.copy(CEDCLOTRLT.OSC, sizeof(CEDCLOTRLT.OSC), in_node, "OSC");
	TRS.copy(CEDCLOTRLT.ESC, sizeof(CEDCLOTRLT.ESC), in_node, "ESC");
	//TRS.copy(CEDCLOTRLT.EL, sizeof(CEDCLOTRLT.EL), in_node, "EL");

	CEDCLOTRLT.QTY = TRS.get_int(in_node, "QTY");
	CEDCLOTRLT.INS_CNT = CEDCLOTRLT.INS_CNT + 1;
	CEDCLOTRLT.TYPE_FLAG = TRS.get_char(in_node, "TYPE_FLAG");
	CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;


	// Setting Value
	memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CEDCLOTRLT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(CEDCLOTRLT.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));

	memcpy(CEDCLOTRLT.EFF, MWIPELTSTS.EFF, sizeof(MWIPELTSTS.EFF));
	memcpy(CEDCLOTRLT.RSH, MWIPELTSTS.RSH, sizeof(MWIPELTSTS.RSH));
	memcpy(CEDCLOTRLT.RS, MWIPELTSTS.RS, sizeof(MWIPELTSTS.RS));
	memcpy(CEDCLOTRLT.FF, MWIPELTSTS.FF, sizeof(MWIPELTSTS.FF));
	memcpy(CEDCLOTRLT.ISC, MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC));
	memcpy(CEDCLOTRLT.VOC, MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC));
	memcpy(CEDCLOTRLT.IMPP, MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP));
	memcpy(CEDCLOTRLT.VMPP, MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP));
	memcpy(CEDCLOTRLT.PMPP, MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));
	memcpy(CEDCLOTRLT.TEMP, MWIPELTSTS.TEMP, sizeof(MWIPELTSTS.TEMP));
	memcpy(CEDCLOTRLT.TREF, MWIPELTSTS.TREF, sizeof(MWIPELTSTS.TREF));
	memcpy(CEDCLOTRLT.SURFTEMP, MWIPELTSTS.SURFTEMP, sizeof(MWIPELTSTS.SURFTEMP));
	memcpy(CEDCLOTRLT.SUN, MWIPELTSTS.SUN, sizeof(MWIPELTSTS.SUN));
	//memcpy(CEDCLOTRLT.OSC, MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC));
	//memcpy(CEDCLOTRLT.ESC, MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC));
	memcpy(CEDCLOTRLT.EL, MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL));
	memcpy(CEDCLOTRLT.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE, sizeof(MWIPELTSTS.FLASHER_CODE));

	memcpy(CEDCLOTRLT.COLOR_CLASS, MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS));
	memcpy(CEDCLOTRLT.PALLET_ID, MWIPELTSTS.PALLET_ID, sizeof(MWIPELTSTS.PALLET_ID));
	memcpy(CEDCLOTRLT.PAK_BAR_INFO, MWIPELTSTS.PAK_BAR_INFO, sizeof(MWIPELTSTS.PAK_BAR_INFO));
	memcpy(CEDCLOTRLT.PAK_GROUP, MWIPELTSTS.PAK_GROUP, sizeof(MWIPELTSTS.PAK_GROUP));
	memcpy(CEDCLOTRLT.PAK_MOD_TYPE, MWIPELTSTS.PAK_MOD_TYPE, sizeof(MWIPELTSTS.PAK_MOD_TYPE));

	if (CEDCLOTRLT.INS_CNT <= 1)
	{
		memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
	}

	if (COM_isspace(CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLT.CMF_1)) == MP_TRUE)
	{
		//데이터 보정용 : 이전 FQC 실적이 있는지 찿아봄
		CDB_init_cwiplottrc(&CWIPLOTTRC);
		memcpy(CWIPLOTTRC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		CDB_select_cwiplottrc(1, &CWIPLOTTRC);
		memcpy(CEDCLOTRLT.CMF_1, CWIPLOTTRC.FQC1_TIME, 14);
	}

	/* Select Power Grade */
	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_POWER_RANGE, strlen(HQCEL_M1_GCM_POWER_RANGE));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	TRS.copy(MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2), in_node, "GRADE");
	TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "POWER");

	CDB_select_mgcmlagdat(4, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code == DB_NOT_FOUND)
		{

		}
		else
		{

		}
	}

	/* Power */
	memcpy(CEDCLOTRLT.POWER, MGCMLAGDAT.DATA_1, sizeof(CEDCLOTRLT.POWER));


	//if(TRS.mem_cmp(in_node, "GRADE", "RWK", strlen("RWK")) == 0)
	//{
	//	i_power = COM_atoi(TRS.get_string(in_node, "POWER"), 3);
	//	COM_itoa_left(CEDCLOTRLT.POWER, i_power, sizeof(CEDCLOTRLT.POWER));
	//}
	//else
	//{
	//	/* Select Power Grade */
	//	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	//	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	//	memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_POWER_RANGE, strlen(HQCEL_M1_GCM_POWER_RANGE));
	//	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	//	TRS.copy(MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2), in_node, "GRADE");
	//	TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "POWER");

	//	CDB_select_mgcmlagdat(4, &MGCMLAGDAT);
	//	if(DB_error_code != DB_SUCCESS)
	//	{
	//		if(DB_error_code == DB_NOT_FOUND)
	//		{

	//		}
	//		else
	//		{

	//		}
	//	}

	//	/* Power */
	//	memcpy(CEDCLOTRLT.POWER, MGCMLAGDAT.DATA_1, sizeof(CEDCLOTRLT.POWER));
	//}

	/* Select Article No */
	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_ARTICLE, strlen(HQCEL_M1_GCM_ARTICLE));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(MGCMLAGDAT.DATA_1, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
	TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "GRADE");

	CDB_select_mgcmlagdat(5, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			memcpy(CEDCLOTRLT.WORK_WEEK, "POWER", strlen("POWER"));		//[IS-20-09-023]
		}
		else
		{

		}
	}

	/* Article */
	memcpy(CEDCLOTRLT.ARTICLE_NO, MGCMLAGDAT.KEY_2, sizeof(CEDCLOTRLT.ARTICLE_NO));
	memcpy(CEDCLOTRLT.ARTICLE_EXT_NO, MGCMLAGDAT.KEY_2, sizeof(CEDCLOTRLT.ARTICLE_EXT_NO));

	memcpy(CEDCLOTRLT.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

	//First Not Rework Ins Time ISSUE-09-050_일일보고전산화관련 by kim 20191016
	if (memcmp(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC)) == 0)
	{
		if (memcmp(CEDCLOTRLT.RESULT_VALUE, "RW", strlen("RW")) != 0 && CEDCLOTRLT.CMF_3[0] == ' ')
		{
			memcpy(CEDCLOTRLT.CMF_3, s_sys_time, sizeof(s_sys_time));
		}
	}

	CDB_update_cedclotrlt(1, &CEDCLOTRLT);
	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code != DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "CEDCLOTRLT UPDATE", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
			TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;

		}
	}
	
	/* - [GERP PROJECT] 시작****************************************************************/
	// 2023-03-18  재작업 지시 테이블에 FQC 검사 결과 업데이트
	CDB_init_cwiprwkdat(&CWIPRWKDAT);

	// ORDER_ID가 존재하는지 체크한다.
	memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CWIPRWKDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID)); // Rework Order
	memcpy(CWIPRWKDAT.MODULE_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID)); // Module ID == LOT_ID  Key value

	//CDB_select_cwiprwkdat(1,&CWIPRWKDAT);
	CDB_select_cwiprwkdat(4, &CWIPRWKDAT); //취소된 재작업 제외 
	if (DB_error_code == DB_SUCCESS)
	{	
		// [ERP 23.05.26] 첫 판정이라면  FQC 판정 INS_CNT 저장 
		if (COM_isnullspace(CWIPRWKDAT.REWORK_JUDGE) == MP_TRUE)
		{
			i_ins_his_cnt = 0;
			CDB_init_cedclotrlh(&CEDCLOTRLH);
			memcpy(CEDCLOTRLH.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CEDCLOTRLH.LOT_ID, TRS.get_string(in_node, "LOT_ID"), strlen(TRS.get_string(in_node, "LOT_ID")));
			memcpy(CEDCLOTRLH.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			i_ins_his_cnt = (int)CDB_select_cedclotrlh_scalar(3, &CEDCLOTRLH);
			COM_itoa_left(CWIPRWKDAT.CMF_2, i_ins_his_cnt, sizeof(CWIPRWKDAT.CMF_2)); //INSPECTION COUNT
		}

		memset(CWIPRWKDAT.REWORK_JUDGE, 0x00, sizeof(CWIPRWKDAT.REWORK_JUDGE));
		memcpy(CWIPRWKDAT.REWORK_JUDGE, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE)); // REWORK_JUDGE Result
		TRS.copy(CWIPRWKDAT.UPDATE_USER_ID, sizeof(CWIPRWKDAT.UPDATE_USER_ID), in_node, "INS_USER_ID");
		memcpy(CWIPRWKDAT.UPDATE_TIME, s_sys_time, sizeof(CWIPRWKDAT.UPDATE_TIME));			

		CDB_update_cwiprwkdat(1, &CWIPRWKDAT);
	}
	else
	{
		// Do Nothing
	}
	/* - [GERP PROJECT] 끝*****************************************************************/

	// Insert CEDCLOTRLH
	CDB_init_cedclotrlh(&CEDCLOTRLH);

	// Setting Value
	memcpy(CEDCLOTRLH.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CEDCLOTRLH.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(CEDCLOTRLH.OPER, TRS.get_string(in_node, "OPER"), strlen(TRS.get_string(in_node, "OPER")));
	memcpy(CEDCLOTRLH.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
	memcpy(CEDCLOTRLH.LINE_ID, TRS.get_string(in_node, "WORK_LINE"), strlen(TRS.get_string(in_node, "WORK_LINE")));
	memcpy(CEDCLOTRLH.INS_TYPE, TRS.get_string(in_node, "INS_TYPE"), strlen(TRS.get_string(in_node, "INS_TYPE")));
	memcpy(CEDCLOTRLH.LOT_ID, TRS.get_string(in_node, "LOT_ID"), strlen(TRS.get_string(in_node, "LOT_ID")));
	CEDCLOTRLH.INS_CNT = CEDCLOTRLT.INS_CNT;
	//CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.INS_CNT;

	memcpy(CEDCLOTRLH.INS_VALUE, CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE));
	TRS.copy(CEDCLOTRLH.INS_USER_ID, sizeof(CEDCLOTRLH.INS_USER_ID), in_node, "INS_USER_ID");
	memcpy(CEDCLOTRLH.INS_TIME, s_sys_time, sizeof(CEDCLOTRLH.INS_TIME));

	TRS.copy(CEDCLOTRLH.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID), in_node, "RESULT_USER_ID");
	memcpy(CEDCLOTRLH.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLH.RESULT_TIME));
	memcpy(CEDCLOTRLH.RESULT_VALUE, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));

	memcpy(CEDCLOTRLH.RLT_COMMENT, TRS.get_string(in_node, "RLT_COMMENT"), strlen(TRS.get_string(in_node, "RLT_COMMENT")));
	memcpy(CEDCLOTRLH.RES_ID, TRS.get_string(in_node, "RES_ID"), strlen(TRS.get_string(in_node, "RES_ID")));
	//CEDCLOTRLH.TYPE_FLAG = TRS.get_char(in_node,"TYPE_FLAG");
	CEDCLOTRLH.TYPE_FLAG = CEDCLOTRLT.TYPE_FLAG;

	//memcpy(CEDCLOTRLH.GRADE, TRS.get_string(in_node,"GRADE"), strlen(TRS.get_string(in_node,"GRADE")));

	memcpy(CEDCLOTRLH.POWER, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLH.POWER));
	memcpy(CEDCLOTRLH.ARTICLE_NO, CEDCLOTRLT.ARTICLE_NO, sizeof(CEDCLOTRLT.ARTICLE_NO));
	memcpy(CEDCLOTRLH.ARTICLE_EXT_NO, CEDCLOTRLT.ARTICLE_EXT_NO, sizeof(CEDCLOTRLT.ARTICLE_EXT_NO));

	//memcpy(CEDCLOTRLH.WORK_SHIFT, TRS.get_string(in_node,"WORK_SHIFT"), strlen(TRS.get_string(in_node,"WORK_SHIFT")));
	memcpy(CEDCLOTRLH.WORK_SHIFT, CEDCLOTRLT.WORK_SHIFT, sizeof(CEDCLOTRLT.WORK_SHIFT));

	TRS.copy(CEDCLOTRLH.EL, sizeof(CEDCLOTRLH.EL), in_node, "EL");
	TRS.copy(CEDCLOTRLH.OSC, sizeof(CEDCLOTRLH.OSC), in_node, "OSC");
	TRS.copy(CEDCLOTRLH.ESC, sizeof(CEDCLOTRLH.ESC), in_node, "ESC");

	/* Power */
	memcpy(CEDCLOTRLH.GRADE, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLH.GRADE));
	memcpy(CEDCLOTRLH.POWER, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLH.POWER));

	/* Simulator Result */
	memcpy(CEDCLOTRLH.EFF, MWIPELTSTS.EFF, sizeof(MWIPELTSTS.EFF));
	memcpy(CEDCLOTRLH.RSH, MWIPELTSTS.RSH, sizeof(MWIPELTSTS.RSH));
	memcpy(CEDCLOTRLH.RS, MWIPELTSTS.RS, sizeof(MWIPELTSTS.RS));
	memcpy(CEDCLOTRLH.FF, MWIPELTSTS.FF, sizeof(MWIPELTSTS.FF));
	memcpy(CEDCLOTRLH.ISC, MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC));
	memcpy(CEDCLOTRLH.VOC, MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC));
	memcpy(CEDCLOTRLH.IMPP, MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP));
	memcpy(CEDCLOTRLH.VMPP, MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP));
	memcpy(CEDCLOTRLH.PMPP, MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));
	memcpy(CEDCLOTRLH.TEMP, MWIPELTSTS.TEMP, sizeof(MWIPELTSTS.TEMP));
	memcpy(CEDCLOTRLH.TREF, MWIPELTSTS.TREF, sizeof(MWIPELTSTS.TREF));
	memcpy(CEDCLOTRLH.SURFTEMP, MWIPELTSTS.SURFTEMP, sizeof(MWIPELTSTS.SURFTEMP));
	memcpy(CEDCLOTRLH.SUN, MWIPELTSTS.SUN, sizeof(MWIPELTSTS.SUN));
	//memcpy(CEDCLOTRLH.OSC, MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC));
	//memcpy(CEDCLOTRLH.ESC, MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC));
	memcpy(CEDCLOTRLH.EL, MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL));

	memcpy(CEDCLOTRLH.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE, sizeof(MWIPELTSTS.FLASHER_CODE));
	memcpy(CEDCLOTRLH.COLOR_CLASS, MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS));
	memcpy(CEDCLOTRLH.PALLET_ID, MWIPELTSTS.PALLET_ID, sizeof(MWIPELTSTS.PALLET_ID));
	memcpy(CEDCLOTRLH.PAK_BAR_INFO, MWIPELTSTS.PAK_BAR_INFO, sizeof(MWIPELTSTS.PAK_BAR_INFO));
	memcpy(CEDCLOTRLH.PAK_GROUP, MWIPELTSTS.PAK_GROUP, sizeof(MWIPELTSTS.PAK_GROUP));
	memcpy(CEDCLOTRLH.PAK_MOD_TYPE, MWIPELTSTS.PAK_MOD_TYPE, sizeof(MWIPELTSTS.PAK_MOD_TYPE));

	CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.LAST_HIST_SEQ;

	memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1)); /* Initial Inspection Time */
	memcpy(CEDCLOTRLH.CMF_2, CEDCLOTRLT.CMF_2, sizeof(CEDCLOTRLH.CMF_2));
	memcpy(CEDCLOTRLH.CMF_3, CEDCLOTRLT.CMF_3, sizeof(CEDCLOTRLH.CMF_3));
	memcpy(CEDCLOTRLH.CMF_4, CEDCLOTRLT.CMF_4, sizeof(CEDCLOTRLH.CMF_4)); /* Original Power */
	memcpy(CEDCLOTRLH.CMF_5, CEDCLOTRLT.CMF_5, sizeof(CEDCLOTRLH.CMF_5)); /* Rejudgment - 2023.09.13 */
	memcpy(CEDCLOTRLH.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

	CDB_insert_cedclotrlh(&CEDCLOTRLH);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "CDB_update_cedclotrlh", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	
	/***************************************************/
	// MWIPELTSTS Apply
	/***************************************************/

	// INIT
	CDB_init_mwipeltsts(&MWIPELTSTS);
	TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwipeltsts(1, &MWIPELTSTS);
	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			MWIPELTSTS.HIST_SEQ = 0;
			memcpy(MWIPELTSTS.CURING_TIME, s_sys_time, sizeof(MWIPELTSTS.CURING_TIME));//파티션키로 사용하고 있으므로 업데이트 금지
			CDB_insert_mwipeltsts(&MWIPELTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	MWIPELTSTS.HIST_SEQ = MWIPELTSTS.HIST_SEQ + 1;
	/*
	TRS.copy(MWIPELTSTS.LINE_ID, sizeof(MWIPELTSTS.LINE_ID), in_node, "WORK_LINE");
	TRS.copy(MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL), in_node, "EL");
	TRS.copy(MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC), in_node, "ESC");
	TRS.copy(MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC), in_node, "OSC");
	TRS.copy(MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE), in_node, "GRADE");
	TRS.copy(MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER), in_node, "POWER");
	*/
	memcpy(MWIPELTSTS.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(MWIPELTSTS.LINE_ID));
	memcpy(MWIPELTSTS.EL, CEDCLOTRLT.EL, sizeof(MWIPELTSTS.EL));
	memcpy(MWIPELTSTS.ESC, CEDCLOTRLT.ESC, sizeof(MWIPELTSTS.ESC));
	memcpy(MWIPELTSTS.OSC, CEDCLOTRLT.OSC, sizeof(MWIPELTSTS.OSC));

	memcpy(MWIPELTSTS.FQC_TIME, s_sys_time, sizeof(MWIPELTSTS.FQC_TIME));

	/* Power */
	memcpy(MWIPELTSTS.GRADE, CEDCLOTRLT.GRADE, sizeof(MWIPELTSTS.GRADE));
	memcpy(MWIPELTSTS.POWER, CEDCLOTRLT.POWER, sizeof(MWIPELTSTS.POWER));

	/* Article No */
	memcpy(MWIPELTSTS.ARTICLE_NO, CEDCLOTRLT.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO));

	/*COLOR CLASS 값이 있는지 체크하여 없으면 UPDATE  함 */
	if (COM_isspace(MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS)) == MP_TRUE)
	{
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if (DB_error_code == DB_SUCCESS)
		{
			memcpy(MWIPELTSTS.COLOR_CLASS, MWIPORDSTS.ORD_CMF_3, sizeof(MWIPELTSTS.COLOR_CLASS));
		}
	}

	CDB_update_mwipeltsts(1, &MWIPELTSTS);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "MWIPELTSTS UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/***************************************************
	* MANUAL 처리시 CEDCLOTFQC 저장 (설비에서 올라오는 데이터 테이블)
	***************************************************/
	if (TRS.get_char(in_node, "TYPE_FLAG") != '1')
	{
		//설비에서 오는 데이터는 이곳을 타지않음.
		int i_max_ins_seq = 0;
		CDB_init_cedclotfqc(&CEDCLOTFQC);
		memcpy(CEDCLOTFQC.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
		memcpy(CEDCLOTFQC.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID));

		i_max_ins_seq = (int)CDB_select_cedclotfqc_scalar(2, &CEDCLOTFQC);
		if (DB_error_code != DB_SUCCESS)
		{
			//return MP_TRUE;
		}

		CDB_init_cedclotfqc(&CEDCLOTFQC);
		memcpy(CEDCLOTFQC.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
		memcpy(CEDCLOTFQC.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID));
		CEDCLOTFQC.INS_SEQ = ++i_max_ins_seq;
		CEDCLOTFQC.DEFECT_SEQ = 0; // initial defect sequence
		memcpy(CEDCLOTFQC.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY));
		memcpy(CEDCLOTFQC.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID));
		memcpy(CEDCLOTFQC.OPER, CEDCLOTRLT.OPER, sizeof(CEDCLOTRLT.OPER));
		CEDCLOTFQC.LOT_HIST_SEQ = CEDCLOTRLT.LAST_HIST_SEQ;
		memcpy(CEDCLOTFQC.INS_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));
		memcpy(CEDCLOTFQC.INS_TYPE, CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLT.INS_TYPE));
		CEDCLOTFQC.INS_CNT = CEDCLOTRLT.INS_CNT; // CEDECLOTRLT.INS_CNT
		memcpy(CEDCLOTFQC.INS_USER_ID, CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID));
		memcpy(CEDCLOTFQC.GRADE, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
		memcpy(CEDCLOTFQC.FQC_JUDGE, CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE));
		memcpy(CEDCLOTFQC.WORK_SHIFT, CEDCLOTRLT.WORK_SHIFT, sizeof(CEDCLOTRLT.WORK_SHIFT));

		memcpy(CEDCLOTFQC.FQC_RESULT, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));
		memcpy(CEDCLOTFQC.CMF_2, "MANUAL", strlen("MANUAL"));

		memcpy(CEDCLOTFQC.POWER_GRADE, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
		TRS.copy(CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE), in_node, "DEFECT_CODE");
		TRS.copy(CEDCLOTFQC.CELL_INFO, sizeof(CEDCLOTFQC.CELL_INFO), in_node, "CELL_INFO");
		TRS.copy(CEDCLOTFQC.CMF_5, sizeof(CEDCLOTFQC.CMF_5), in_node, "REJUDGMENT"); //ReJudgment 추가 ( 2023/09/13 )

		CDB_insert_cedclotfqc(&CEDCLOTFQC);
		if (DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

		// 2023-03-14 JSLEE ADD 재작업 지시 테이블에 FQC 검사 결과 업데이트
		//***************************************************************************/
		if (COM_isnullspace(TRS.get_string(in_node, "DEFECT_CODE")) == MP_FALSE)
		{
			// CEDCLOTRLT UPDATE CMF_2 : 대표불량코드
			TRS.copy(CEDCLOTRLT.CMF_2, sizeof(CEDCLOTRLT.CMF_2), in_node, "DEFECT_CODE");
			CDB_update_cedclotrlt(2, &CEDCLOTRLT);
			if (DB_error_code != DB_SUCCESS)
			{
				// Do Nothing
			}

			// 4. 이력 테이블 업데이트
			TRS.copy(CEDCLOTRLH.CMF_2, sizeof(CEDCLOTRLH.CMF_2), in_node, "DEFECT_CODE");
			CDB_update_cedclotrlh(2, &CEDCLOTRLH);
			if (DB_error_code != DB_SUCCESS)
			{
				// Do Nothing
			}

			i_max_seq_num = 0;
			CDB_init_cwipcellos(&CWIPCELLOS);
			TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LOT_ID");	/* Cell ID */
			i_max_seq_num = (int)CDB_select_cwipcellos_scalar(2, &CWIPCELLOS);
			if (DB_error_code != DB_SUCCESS)
			{
				return MP_TRUE;
			}

			/* Insert defect items */
			CDB_init_cwipcellos(&CWIPCELLOS);
			TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LOT_ID");
			CWIPCELLOS.LOSS_SEQ = ++i_max_seq_num;

			TRS.copy(CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE), in_node, "DEFECT_CODE");
			TRS.copy(CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID), in_node, "CELL_INFO");
			TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");

			memcpy(CWIPCELLOS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

			TRS.copy(CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID), in_node, "WORK_LINE");
			TRS.copy(CWIPCELLOS.RES_ID, sizeof(CWIPCELLOS.RES_ID), in_node, "RES_ID");

			memcpy(CWIPCELLOS.CREATE_TIME, s_sys_time, sizeof(CWIPCELLOS.CREATE_TIME));
			memcpy(CWIPCELLOS.TRAN_TIME, s_sys_time, sizeof(CWIPCELLOS.TRAN_TIME));

			CWIPCELLOS.WORK_SHIFT = CEDCLOTFQC.WORK_SHIFT[0];

			CWIPCELLOS.INS_CNT = CEDCLOTRLT.INS_CNT;
			memcpy(CWIPCELLOS.RESULT_VALUE, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));
			CWIPCELLOS.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

			//LOCATION 에 따른 위치GET
			CDB_init_cwiplotstr(&CWIPLOTSTR);
			TRS.copy(CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID), in_node, "LOT_ID");
			CWIPLOTSTR.STRING_LOC[0] = CWIPCELLOS.LOCATION_ID[0];
			{
				int itmp = 0;
				itmp = COM_atoi(CWIPCELLOS.LOCATION_ID + 1, 2);
				COM_itoa_zero(CWIPLOTSTR.STRING_LOC + 1, itmp, 2);
			}
			CDB_select_cwiplotstr(2, &CWIPLOTSTR);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}

			memcpy(CWIPCELLOS.STRING_ID, CWIPLOTSTR.STRING_ID, sizeof(CWIPLOTSTR.STRING_ID));
			memcpy(CWIPCELLOS.LOSS_GROUP, CWIPLOTSTR.CMF_2, sizeof(CWIPCELLOS.LOSS_GROUP));

			CDB_insert_cwipcellos(&CWIPCELLOS);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
		else
		{
			// 메뉴얼 FQC 판정일때 G01, G02 로 변경될 경우 DEFECT CODE 업데이트를 하지 않아서 이력에 남는것 수정.
			// A Grade 일때 Defect code 초기화 시킴
			if (CEDCLOTRLT.RESULT_VALUE[0] == 'A')
			{
				// CEDCLOTRLT UPDATE CMF_2 : 대표불량코드				
				memset(CEDCLOTRLT.CMF_2, ' ', sizeof(CEDCLOTRLT.CMF_2));
				CDB_update_cedclotrlt(2, &CEDCLOTRLT);
				if (DB_error_code != DB_SUCCESS)
				{
					// Do Nothing
				}

				// 4. 이력 테이블 업데이트				
				memset(CEDCLOTRLH.CMF_2, ' ', sizeof(CEDCLOTRLH.CMF_2));
				CDB_update_cedclotrlh(2, &CEDCLOTRLH);
				if (DB_error_code != DB_SUCCESS)
				{
					// Do Nothing
				}
			}
		}
	}


	/***************************************************/
	// MWIPELTHIS Apply
	/***************************************************/
	// INIT
	/*
	CDB_init_mwipelthis(&MWIPELTHIS);

	//STRUCTURE 구조가 같을경우 전체 STRUCT 를 COPY 할떄 사용.
	//( 대상이 되는 첫주소 에 소스의 첫주소 부터 전체 STRUCTURE 를 카피하라는 문장임)
		// 이해안되면 사용함 안됨.
		// 두스트럭쳐가 틀리면 사용하면 안됨.
	memcpy(MWIPELTHIS.LOT_ID, MWIPELTSTS.LOT_ID, sizeof(struct MWIPELTSTS_TAG));

	CDB_insert_mwipelthis(&MWIPELTHIS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "MWIPELTHIS INSERT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTHIS.LOT_ID), MWIPELTHIS.LOT_ID);
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	*/

	/***************************************************/
	//END LOT
	/***************************************************/

	memset(operTmp, ' ', sizeof(operTmp));
	memcpy(operTmp, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
	
	//if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_FQC_OPER, sizeof(MWIPLOTSTS.OPER)) == 0 ) 
	//if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0 ) 
	{
		/* - [GERP PROJECT] 시작****************************************************************/
		//FQC 검사 데이터가 올라오면 무조건 END 다시 처리함..(ERP 실적 UPLOAD 됨)
		//[ERP 23.05.23] Log 제거 
		/*Store LOT*/
		TRSNode* tran_in_node;
		TRSNode* tran_out_node;

		/* UNSTORE Lot */
		tran_in_node = TRS.create_node("UNSTORE_LOT_IN");
		tran_out_node = TRS.create_node("UNSTORE_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

		TRS.add_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.STR_RET_FLOW, sizeof(MWIPLOTSTS.STR_RET_FLOW));

		store_flag = MWIPLOTSTS.INV_FLAG;
		memset(tmpOper, ' ', sizeof(tmpOper));
		memcpy(tmpOper, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

		//23.12.08 STR_RET_OPER값이 Garbage 데이터가 들어옴
		//23.12.08 STR_RET_OPER값이 Garbage 데이터가 들어옴
		if (memcmp(MWIPLOTSTS.STR_RET_OPER, TRS.get_string(in_node, "OPER"), strlen(TRS.get_string(in_node, "OPER"))))
		{
			//////23.12.08 Garbage 데이터가 들어오는 현상 확인
			memset(MWIPLOTSTS.STR_RET_OPER, ' ', sizeof(MWIPLOTSTS.STR_RET_OPER));
			//////23.12.08 Garbage 데이터가 들어오는 현상 확인
			memcpy(MWIPLOTSTS.STR_RET_OPER, TRS.get_string(in_node, "OPER"), sizeof(MWIPLOTSTS.STR_RET_OPER));
			DBC_update_mwiplotsts(1, &MWIPLOTSTS);
		}

		TRS.add_string(tran_in_node, "TO_OPER", MWIPLOTSTS.STR_RET_OPER, sizeof(MWIPLOTSTS.STR_RET_OPER));

		if (WIP_UNSTORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			//DO NOTHING
			//TRS_add_all_member_to_log(tran_out_node);
		}
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		tran_in_node = TRS.create_node("SKIP_LOT_IN");
		tran_out_node = TRS.create_node("SKIP_LOT_OUT");

		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(in_node, "LOT_ID"), strlen(TRS.get_string(in_node, "LOT_ID")));

		DBC_select_mwiplotsts(mwiplotsts_flag, &MWIPLOTSTS);

		tran_in_node = TRS.create_node("START_LOT_IN");
		tran_out_node = TRS.create_node("START_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
		TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

		//ERP Interface 를 위해 임시COCE ( M3000, M3040, M3110 ) 데이터 자동생김
		TRS.set_string(tran_in_node, "TO_FLOW", "MDP100", strlen("MDP100"));
		TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		TRS.add_string(tran_in_node, "TO_OPER", "M3110", strlen("M3110"));

		if (WIP_SKIP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			//DO NOTHING
			//TRS_add_all_member_to_log(tran_out_node);
		}

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		/* - [GERP PROJECT] 끝***********************************************************************************************/

		/* End Lot */
		tran_in_node = TRS.create_node("END_LOT_IN");
		tran_out_node = TRS.create_node("END_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
		TRS.add_string(tran_in_node, "TRAN_CMF_2", s_sys_time, sizeof(s_sys_time)); //TRAN_CMF_2 에 검사데이데 처리후 END 했을경우 해당 시간 넣음.
		TRS.add_char(tran_in_node, "INSPECT_FLAG", 'Y');
		TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '5');
		if (EAPMES_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			// Do Nothing
			//TRS_add_all_member_to_log(tran_out_node);
		}

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
	}

	TRS.add_int(out_node, "INS_CNT", CEDCLOTRLT.INS_CNT);



	/* - [GERP PROJECT] 시작****************************************************************/
	///made by lakejang 23.03.21 
	///FQC 완료 후 등급별로 창고 이동을 한다. 
	//[ERP 23.05.23] 창고 이동 설비 조건 추가 
	/*
	등급이 B,C,Z 일경우 P21, 1라인 A등급일 경우 P11, 2라인 A등급 P12, 3라인 A등급 P13, R등급 RWK
	현재 공정이 FQC 이면 창고로 이동 시키기 
	*/
	{
		/*[23.05.11] 창고 이동 조건 수정*/ 
		//R 창고 제외 창고 일 경우 현 위치 고정 
		if (TRS.get_char(in_node, "TYPE_FLAG") != '1' 
			&& store_flag == HQCEL_FLAG_YES 
			&& (memcmp(operTmp, HQCEL_M1_REWORK_OPER, strlen(HQCEL_M1_REWORK_OPER)) != 0
			   || memcmp(operTmp, HQCEL_M1_REWORK_OPER_E2, strlen(HQCEL_M1_REWORK_OPER_E2)) != 0))
		{
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(in_node, "LOT_ID"), strlen(TRS.get_string(in_node, "LOT_ID")));

			DBC_select_mwiplotsts(mwiplotsts_flag, &MWIPLOTSTS);

			/* STORE Lot */
			tran_in_node = TRS.create_node("STORE_LOT_IN");
			tran_out_node = TRS.create_node("STORE_LOT_OUT");

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_string(tran_in_node, "TO_OPER", tmpOper, sizeof(tmpOper));

			if (WIP_STORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
		}
		else if (TRS.get_char(in_node, "TYPE_FLAG") != '1' && memcmp(operTmp, HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER)) == 0)
		{
			// 품질 창고에서 수동 FQC 판정일 경우 이동 하지 않는다. 
			// SKIP
			tran_in_node = TRS.create_node("END_LOT");

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

			TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.set_string(tran_in_node, "TO_OPER", HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER));

			if (WIP_SKIP_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(tran_in_node);
				return MP_FALSE;
			}

			TRS.free_node(tran_in_node);
		}
		else if (TRS.get_char(in_node, "TYPE_FLAG") != '1' && memcmp(operTmp, HQCEL_M1_OQC_OPER_E2, strlen(HQCEL_M1_OQC_OPER_E2)) == 0)
		{
			// 품질 창고에서 수동 FQC 판정일 경우 이동 하지 않는다. 
			// SKIP
			tran_in_node = TRS.create_node("END_LOT");

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

			TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.set_string(tran_in_node, "TO_OPER", HQCEL_M1_OQC_OPER_E2, strlen(HQCEL_M1_OQC_OPER_E2));

			if (WIP_SKIP_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(tran_in_node);
				return MP_FALSE;
			}

			TRS.free_node(tran_in_node);
		}
		else
		{
			// 그외는 이동 처리 
			///GCM 조회하여 라인별 등급으로 이동할 STORE를 찾는다
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "@GRADE_TYPE_OPER", strlen("@GRADE_TYPE_OPER"));
			TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "GRADE");
			TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "WORK_LINE");
			DBC_select_mgcmtbldat(105, &MGCMTBLDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "GCM-0008");
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT(105)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
					TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				else
				{
					strcpy(s_msg_code, "GCM-0007");
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT(105)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
					TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			/* 23.05.01 Power Range 값 없는 Case R등급 창고로 이동 */
			if (COM_isnullspace(MGCMLAGDAT.DATA_1) == MP_TRUE)
			{
				memcpy(MGCMTBLDAT.DATA_1, HQCEL_M1_REWORK_OPER, sizeof(MGCMTBLDAT.DATA_1));

				// Save Log
				CDB_init_cwipabnlog(&CWIPABNLOG);
				memcpy(CWIPABNLOG.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CWIPABNLOG.LOG_TYPE, HQCEL_ABN_NOT_POWER, strlen(HQCEL_ABN_NOT_POWER));
				memcpy(CWIPABNLOG.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				memcpy(CWIPABNLOG.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
				TRS.copy(CWIPABNLOG.TRAN_USER_ID, sizeof(CWIPABNLOG.TRAN_USER_ID), in_node, IN_USERID);
				memcpy(CWIPABNLOG.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
				TRS.copy(CWIPABNLOG.CREATE_USER_ID, sizeof(CWIPABNLOG.CREATE_USER_ID), in_node, IN_USERID);
				CDB_insert_cwipabnlog(&CWIPABNLOG);

			}

			/* STORE Lot */
			tran_in_node = TRS.create_node("STORE_LOT_IN");
			tran_out_node = TRS.create_node("STORE_LOT_OUT");

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_string(tran_in_node, "TO_OPER", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
			if (WIP_STORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
		}
		/*[23.05.11] 창고 이동 조건 수정*/
	}
	/* - [GERP PROJECT] 끝***********************************************************************************************/
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}