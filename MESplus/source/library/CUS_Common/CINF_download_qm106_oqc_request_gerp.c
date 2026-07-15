/*******************************************************************************

	System      : MESplus
	Module      : ERP Request Move Store
	File Name   : CINF_download_qm106_oqc_request_gerp.c
	Description : ERP IF Table -> MES Backup Table

	MES Version : 5.0

	Function List
		-

	Detail Description
		-

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2023.03.19  lake jang

	Copyright(C) 1998-2008 Miracom,Inc.
	All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_QM106_OQC_REQUEST(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node);


int CWIP_R_Create_Req_No(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
	CUS_Interface_Download_Qm106_Oqc_Request()
		- ERP->MES Move Store Data
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CUS_Interface_Download_Qm106_Oqc_Request(TRSNode* in_node, TRSNode* out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret = MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CUS_INTERFACE_DOWNLOAD_QM106_OQC_REQUEST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Qm106_Oqc_Request", out_node);

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
	CUS_INTERFACE_DOWNLOAD_QM106_OQC_REQUEST()
		- ERP->MES Move Store Data
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- char *s_msg_code : Error Msg Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_QM106_OQC_REQUEST(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{

	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
	struct IQCMSERDAT_TAG IQCMSERDAT;
	struct IBAKSERDAT_TAG IBAKSERDAT;

	struct CWIPREQMST_TAG CWIPREQMST;
	struct CWIPREQDTL_TAG CWIPREQDTL;
	struct worktime_tag cur_work_time;

	//TRSNode* hold_lot_in;
	TRSNode* release_lot_in;
	//TRSNode* tran_in_node;

	char s_sys_time[14];
	char s_sys_date[8];

	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_DOWNLOAD_QM106_OQC_REQUEST");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(s_sys_date, ' ', sizeof(s_sys_date));
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
	
	/* CURRENT TIME   */
	CCOM_get_work_time(s_sys_time, &cur_work_time);

	if (CWIP_R_Create_Req_No(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	// OPEN
	CDB_init_iqcmserdat(&IQCMSERDAT);
	CDB_open_iqcmserdat(3, &IQCMSERDAT); //'R', 'W'
	if (DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IQCMSERDAT OPEN(3)", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	// FETCH
	while (1)
	{
		CDB_fetch_iqcmserdat(3, &IQCMSERDAT);
		if (DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_iqcmserdat(3);
			break;
		}
		else if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IQCMSERDAT FETCH(3)", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			CDB_close_iqcmserdat(3);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		///ERP 에서 넘어온 LOT 조회
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPLOTSTS.LOT_ID, IQCMSERDAT.MODULE_ID, sizeof(MWIPLOTSTS.LOT_ID));
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				IQCMSERDAT.RETURN_TYPE = 'E';
				memcpy(IQCMSERDAT.RETURN_MSG, "The module does not exist.", strlen("The module does not exist."));
				CDB_update_iqcmserdat(1, &IQCMSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSERDAT UPDATE(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_iqcmserdat(3);
					return MP_FALSE;
				}
				DB_commit();
				continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				CDB_close_iqcmserdat(3);
				return MP_FALSE;
			}
		}

		//공정 확인 
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		memcpy(MWIPOPRDEF.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				IQCMSERDAT.RETURN_TYPE = 'E';
				memcpy(IQCMSERDAT.RETURN_MSG, "This store does not exist.", strlen("This store does not exist."));
				CDB_update_iqcmserdat(1, &IQCMSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPOPRDEF UPDATE(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_iqcmserdat(3);
					return MP_FALSE;
				}
				DB_commit();
				continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iqcmserdat(3);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		
		///반납 이동 요청 마스터 & DTL 생성 & 조회
		CDB_init_cwipreqmst(&CWIPREQMST);
		memcpy(CWIPREQMST.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPREQDTL.FACTORY));
		memcpy(CWIPREQMST.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(CWIPREQMST.REQ_NO));
		CDB_select_cwipreqmst(1, &CWIPREQMST);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				///반납 이동 요청 마스터 & DTL 생성
				CDB_init_cwipreqmst(&CWIPREQMST);
				memcpy(CWIPREQMST.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CWIPREQMST.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(CWIPREQMST.REQ_NO));
				memcpy(CWIPREQMST.REQ_TYPE, IQCMSERDAT.QC_INSPECTION, sizeof(CWIPREQMST.REQ_TYPE));
				memcpy(CWIPREQMST.REQ_TIME, s_sys_time, sizeof(s_sys_time));
				memcpy(CWIPREQMST.REQ_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
				memcpy(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_R, strlen(HQCEL_M1_REQ_STATUS_R));
				memcpy(CWIPREQMST.REQ_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
				memcpy(CWIPREQMST.FROM_OPER, HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER));
				memcpy(CWIPREQMST.TO_OPER, IQCMSERDAT.STORAGE_LOCATION, sizeof(IQCMSERDAT.STORAGE_LOCATION));
				memcpy(CWIPREQMST.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
				memcpy(CWIPREQMST.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
				CDB_insert_cwipreqmst(&CWIPREQMST);
				if (DB_error_code != DB_SUCCESS)
				{
					//NOTTHING
					IQCMSERDAT.RETURN_TYPE = 'E';
					memcpy(IQCMSERDAT.RETURN_MSG, "Unable to requested master information.", strlen("Unable to requested master information."));
					CDB_update_iqcmserdat(1, &IQCMSERDAT);
					if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "IQCMSERDAT UPDATE(1)", MP_NVST);
						TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
						TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						CDB_close_iqcmserdat(3);;
						return MP_FALSE;
					}
					DB_commit();
					continue;
				}
								
			}
		}

		CDB_init_cwipreqdtl(&CWIPREQDTL);
		memcpy(CWIPREQDTL.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPREQDTL.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(CWIPREQDTL.REQ_NO));
		memcpy(CWIPREQDTL.LOT_ID, IQCMSERDAT.MODULE_ID, sizeof(CWIPREQDTL.LOT_ID));
		CDB_select_cwipreqdtl(7, &CWIPREQDTL);

		if (DB_error_code != DB_SUCCESS)
		{
			///이동 요청 DTL 생성
			CDB_init_cwipreqdtl(&CWIPREQDTL);
			memcpy(CWIPREQDTL.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPREQDTL.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(CWIPREQDTL.REQ_NO));
			memcpy(CWIPREQDTL.LOT_ID, IQCMSERDAT.MODULE_ID, sizeof(CWIPREQDTL.LOT_ID));
			CWIPREQDTL.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
			memcpy(CWIPREQDTL.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(CWIPREQDTL.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
			CDB_insert_cwipreqdtl(&CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
			{
				//NOTTHING
				IQCMSERDAT.RETURN_TYPE = 'E';
				memcpy(IQCMSERDAT.RETURN_MSG, "Unable to requested information.", strlen("Unable to requested information."));
				CDB_update_iqcmserdat(1, &IQCMSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSERDAT INSERT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_iqcmserdat(3);
					return MP_FALSE;
				}
				DB_commit();
				continue;
			}
		}
		
		//OQC 반납요청 취소 
		if (memcmp(IQCMSERDAT.ACTION_TYPE, "D", strlen("D")) == 0)
		{
			///이동 요청 마스터 조회 CLOSE되지 않았으면 CLOSE
			CDB_init_cwipreqmst(&CWIPREQMST);
			memcpy(CWIPREQMST.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPREQMST.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(IQCMSERDAT.Z_GROUP));
			CDB_select_cwipreqmst(1, &CWIPREQMST);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					IQCMSERDAT.RETURN_TYPE = 'E';
					memcpy(IQCMSERDAT.RETURN_MSG, "The module in this request master info does not exist.", strlen("The module in this request master info does not exist."));
					CDB_update_iqcmserdat(1, &IQCMSERDAT);
					if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "IQCMSERDAT UPDATE(1)", MP_NVST);
						TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
						TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						CDB_close_iqcmserdat(3);
						return MP_FALSE;
					}
					DB_commit();
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPREQMST SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_iqcmserdat(3);
					return MP_FALSE;
				}
			}
			else
			{
				if (memcmp(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_C, strlen(HQCEL_M1_REQ_STATUS_C)) != 0)
				{
					memset(CWIPREQMST.REQ_STATUS, ' ', sizeof(CWIPREQMST.REQ_STATUS));
					memcpy(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_CL, strlen(HQCEL_M1_REQ_STATUS_CL));
					memcpy(CWIPREQMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
					memcpy(CWIPREQMST.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
					CDB_update_cwipreqmst(2, &CWIPREQMST);
					if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "CWIPREQMST UPDATE(2)", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
						TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;
						CDB_close_iqcmserdat(3);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
			}
		}

		if (MWIPLOTSTS.HOLD_FLAG == 'Y')
		{
			/*RELEASE LOT*/
			release_lot_in = TRS.create_node("RELEASE_LOT_IN");
			TRS.add_char(release_lot_in, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(release_lot_in, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(release_lot_in, IN_LANGUAGE, TRS.get_language(in_node));

			TRS.set_string(release_lot_in, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			TRS.set_string(release_lot_in, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.set_int(release_lot_in, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

			TRS.set_string(release_lot_in, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.set_int(release_lot_in, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.set_string(release_lot_in, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(release_lot_in, "FLOW_SEQ_NO", MWIPLOTSTS.FLOW_SEQ_NUM);

			TRS.set_string(release_lot_in, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_string(release_lot_in, "RELEASE_CODE", HQCEL_RELEASE_REQ_CANCEL, strlen(HQCEL_RELEASE_REQ_CANCEL));

			TRS.set_char(release_lot_in, "END_FLAG", 'Y');

			if (WIP_RELEASE_LOT(s_msg_code, release_lot_in, out_node) == MP_FALSE)
			{
				//PASS
				/*
				IQCMSERDAT.RETURN_TYPE = 'E';
				memcpy(IQCMSERDAT.RETURN_MSG, "This module cannot be lot release.", strlen("This module cannot be lot release."));
				CDB_update_iqcmserdat(1, &IQCMSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					TRS.free_node(release_lot_in);
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSERDAT UPDATE(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_iqcmserdat(3);
					return MP_FALSE;
				}
				TRS.free_node(release_lot_in);
				DB_commit();
				continue;
				*/
			}

			TRS.free_node(release_lot_in);
		}

		//TRANSACTION이  완료 되면 HIST_SEQ가 변경 되니 재조회 한다
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.FACTORY, CWIPREQDTL.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(MWIPLOTSTS.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);

		///이동 요청 상세 HIST_SEQ UPDATE
		CDB_init_cwipreqdtl(&CWIPREQDTL);
		memcpy(CWIPREQDTL.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPREQDTL.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(CWIPREQDTL.REQ_NO));
		memcpy(CWIPREQDTL.LOT_ID, IQCMSERDAT.MODULE_ID, sizeof(CWIPREQDTL.LOT_ID));
		CDB_select_cwipreqdtl(7, &CWIPREQDTL);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPREQDTL SELECT(7)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY);
			TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_iqcmserdat(3);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CWIPREQDTL.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
		memcpy(CWIPREQDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
		memcpy(CWIPREQDTL.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
		CDB_update_cwipreqdtl(2, &CWIPREQDTL);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPREQDTL UPDATE(2)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY);
			TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_iqcmserdat(3);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//BACK UP
		CDB_init_ibakserdat(&IBAKSERDAT);
		memcpy(IBAKSERDAT.DOC_ID, IQCMSERDAT.DOC_ID, sizeof(IBAKSERDAT.DOC_ID));
		memcpy(IBAKSERDAT.SITE_ID, IQCMSERDAT.SITE_ID, sizeof(IBAKSERDAT.SITE_ID));
		memcpy(IBAKSERDAT.MODULE_ID, IQCMSERDAT.MODULE_ID, sizeof(IBAKSERDAT.MODULE_ID));
		memcpy(IBAKSERDAT.Z_GROUP, IQCMSERDAT.Z_GROUP, sizeof(IBAKSERDAT.Z_GROUP));
		CDB_select_ibakserdat(1, &IBAKSERDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				memcpy(IBAKSERDAT.DOC_ID, IQCMSERDAT.DOC_ID, sizeof(IBAKSERDAT.DOC_ID));
				memcpy(IBAKSERDAT.SITE_ID, IQCMSERDAT.SITE_ID, sizeof(IBAKSERDAT.SITE_ID));
				memcpy(IBAKSERDAT.Z_GROUP, IQCMSERDAT.Z_GROUP, sizeof(IBAKSERDAT.Z_GROUP));
				memcpy(IBAKSERDAT.MODULE_ID, IQCMSERDAT.MODULE_ID, sizeof(IBAKSERDAT.MODULE_ID));
				memcpy(IBAKSERDAT.ACTION_TYPE, IQCMSERDAT.ACTION_TYPE, sizeof(IBAKSERDAT.ACTION_TYPE));
				memcpy(IBAKSERDAT.PROD_ORDER_NO, IQCMSERDAT.PROD_ORDER_NO, sizeof(IBAKSERDAT.PROD_ORDER_NO));
				memcpy(IBAKSERDAT.MATE_NO, IQCMSERDAT.MATE_NO, sizeof(IBAKSERDAT.MATE_NO));
				memcpy(IBAKSERDAT.QC_INSPECTION, IQCMSERDAT.QC_INSPECTION, sizeof(IBAKSERDAT.QC_INSPECTION));
				memcpy(IBAKSERDAT.STORAGE_LOCATION, IQCMSERDAT.STORAGE_LOCATION, sizeof(IBAKSERDAT.STORAGE_LOCATION));
				memcpy(IBAKSERDAT.LOCATION, IQCMSERDAT.LOCATION, sizeof(IBAKSERDAT.LOCATION));
				memcpy(IBAKSERDAT.SHIFT, IQCMSERDAT.SHIFT, sizeof(IBAKSERDAT.SHIFT));
				memcpy(IBAKSERDAT.QUALITY_GRADE, IQCMSERDAT.QUALITY_GRADE, sizeof(IBAKSERDAT.QUALITY_GRADE));
				memcpy(IBAKSERDAT.POWER_GRADE, IQCMSERDAT.POWER_GRADE, sizeof(IBAKSERDAT.POWER_GRADE));
				memcpy(IBAKSERDAT.FQC_DEFECTCODE, IQCMSERDAT.FQC_DEFECTCODE, sizeof(IBAKSERDAT.FQC_DEFECTCODE));
				memcpy(IBAKSERDAT.DIST_ID, IQCMSERDAT.DIST_ID, sizeof(IBAKSERDAT.DIST_ID));
				memcpy(IBAKSERDAT.CMF_1, IQCMSERDAT.CMF_1, sizeof(IBAKSERDAT.CMF_1));
				memcpy(IBAKSERDAT.CMF_2, IQCMSERDAT.CMF_2, sizeof(IBAKSERDAT.CMF_2));
				memcpy(IBAKSERDAT.CMF_3, IQCMSERDAT.CMF_3, sizeof(IBAKSERDAT.CMF_3));
				memcpy(IBAKSERDAT.CMF_4, IQCMSERDAT.CMF_4, sizeof(IBAKSERDAT.CMF_4));
				memcpy(IBAKSERDAT.CMF_5, IQCMSERDAT.CMF_5, sizeof(IBAKSERDAT.CMF_5));
				IBAKSERDAT.DATA_FLAG = IQCMSERDAT.DATA_FLAG;
				memcpy(IBAKSERDAT.UPDATE_COUNT, IQCMSERDAT.UPDATE_COUNT, sizeof(IBAKSERDAT.UPDATE_COUNT));
				memcpy(IBAKSERDAT.INSERT_COUNT, IQCMSERDAT.INSERT_COUNT, sizeof(IBAKSERDAT.INSERT_COUNT));
				memcpy(IBAKSERDAT.DELETE_COUNT, IQCMSERDAT.DELETE_COUNT, sizeof(IBAKSERDAT.DELETE_COUNT));
				memcpy(IBAKSERDAT.SQL_DML_COUNT, IQCMSERDAT.SQL_DML_COUNT, sizeof(IBAKSERDAT.SQL_DML_COUNT));
				IBAKSERDAT.RETURN_TYPE = 'S';
				memcpy(IBAKSERDAT.RETURN_MSG, IQCMSERDAT.RETURN_MSG, sizeof(IBAKSERDAT.RETURN_MSG));
				memcpy(IBAKSERDAT.ZPICODE, IQCMSERDAT.ZPICODE, sizeof(IBAKSERDAT.ZPICODE));
				memcpy(IBAKSERDAT.ZPIMSGID, IQCMSERDAT.ZPIMSGID, sizeof(IBAKSERDAT.ZPIMSGID));
				memcpy(IBAKSERDAT.ZIFERNAM, IQCMSERDAT.ZIFERNAM, sizeof(IBAKSERDAT.ZIFERNAM));
				memcpy(IBAKSERDAT.ZIFDATE, IQCMSERDAT.ZIFDATE, sizeof(IBAKSERDAT.ZIFDATE));
				memcpy(IBAKSERDAT.ZIFTIME, IQCMSERDAT.ZIFTIME, sizeof(IBAKSERDAT.ZIFTIME));
				IBAKSERDAT.ZPISTAT = IQCMSERDAT.ZPISTAT;
				memcpy(IBAKSERDAT.ZPIMSG, IQCMSERDAT.ZPIMSG, sizeof(IBAKSERDAT.ZPIMSG));
				CDB_insert_ibakserdat(&IBAKSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IBAKSERDAT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
					TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
					TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					CDB_close_iqcmserdat(3);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "IBAKSERDAT SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
				TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
				TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iqcmserdat(3);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			memcpy(IBAKSERDAT.DOC_ID, IQCMSERDAT.DOC_ID, sizeof(IBAKSERDAT.DOC_ID));
			memcpy(IBAKSERDAT.SITE_ID, IQCMSERDAT.SITE_ID, sizeof(IBAKSERDAT.SITE_ID));
			memcpy(IBAKSERDAT.Z_GROUP, IQCMSERDAT.Z_GROUP, sizeof(IBAKSERDAT.Z_GROUP));
			memcpy(IBAKSERDAT.MODULE_ID, IQCMSERDAT.MODULE_ID, sizeof(IBAKSERDAT.MODULE_ID));
			memcpy(IBAKSERDAT.ACTION_TYPE, IQCMSERDAT.ACTION_TYPE, sizeof(IBAKSERDAT.ACTION_TYPE));
			memcpy(IBAKSERDAT.PROD_ORDER_NO, IQCMSERDAT.PROD_ORDER_NO, sizeof(IBAKSERDAT.PROD_ORDER_NO));
			memcpy(IBAKSERDAT.MATE_NO, IQCMSERDAT.MATE_NO, sizeof(IBAKSERDAT.MATE_NO));
			memcpy(IBAKSERDAT.QC_INSPECTION, IQCMSERDAT.QC_INSPECTION, sizeof(IBAKSERDAT.QC_INSPECTION));
			memcpy(IBAKSERDAT.STORAGE_LOCATION, IQCMSERDAT.STORAGE_LOCATION, sizeof(IBAKSERDAT.STORAGE_LOCATION));
			memcpy(IBAKSERDAT.LOCATION, IQCMSERDAT.LOCATION, sizeof(IBAKSERDAT.LOCATION));
			memcpy(IBAKSERDAT.SHIFT, IQCMSERDAT.SHIFT, sizeof(IBAKSERDAT.SHIFT));
			memcpy(IBAKSERDAT.QUALITY_GRADE, IQCMSERDAT.QUALITY_GRADE, sizeof(IBAKSERDAT.QUALITY_GRADE));
			memcpy(IBAKSERDAT.POWER_GRADE, IQCMSERDAT.POWER_GRADE, sizeof(IBAKSERDAT.POWER_GRADE));
			memcpy(IBAKSERDAT.FQC_DEFECTCODE, IQCMSERDAT.FQC_DEFECTCODE, sizeof(IBAKSERDAT.FQC_DEFECTCODE));
			memcpy(IBAKSERDAT.DIST_ID, IQCMSERDAT.DIST_ID, sizeof(IBAKSERDAT.DIST_ID));
			memcpy(IBAKSERDAT.CMF_1, IQCMSERDAT.CMF_1, sizeof(IBAKSERDAT.CMF_1));
			memcpy(IBAKSERDAT.CMF_2, IQCMSERDAT.CMF_2, sizeof(IBAKSERDAT.CMF_2));
			memcpy(IBAKSERDAT.CMF_3, IQCMSERDAT.CMF_3, sizeof(IBAKSERDAT.CMF_3));
			memcpy(IBAKSERDAT.CMF_4, IQCMSERDAT.CMF_4, sizeof(IBAKSERDAT.CMF_4));
			memcpy(IBAKSERDAT.CMF_5, IQCMSERDAT.CMF_5, sizeof(IBAKSERDAT.CMF_5));
			IBAKSERDAT.DATA_FLAG = IQCMSERDAT.DATA_FLAG;
			memcpy(IBAKSERDAT.UPDATE_COUNT, IQCMSERDAT.UPDATE_COUNT, sizeof(IBAKSERDAT.UPDATE_COUNT));
			memcpy(IBAKSERDAT.INSERT_COUNT, IQCMSERDAT.INSERT_COUNT, sizeof(IBAKSERDAT.INSERT_COUNT));
			memcpy(IBAKSERDAT.DELETE_COUNT, IQCMSERDAT.DELETE_COUNT, sizeof(IBAKSERDAT.DELETE_COUNT));
			memcpy(IBAKSERDAT.SQL_DML_COUNT, IQCMSERDAT.SQL_DML_COUNT, sizeof(IBAKSERDAT.SQL_DML_COUNT));
			IBAKSERDAT.RETURN_TYPE = 'S';
			memcpy(IBAKSERDAT.RETURN_MSG, IQCMSERDAT.RETURN_MSG, sizeof(IBAKSERDAT.RETURN_MSG));
			memcpy(IBAKSERDAT.ZPICODE, IQCMSERDAT.ZPICODE, sizeof(IBAKSERDAT.ZPICODE));
			memcpy(IBAKSERDAT.ZPIMSGID, IQCMSERDAT.ZPIMSGID, sizeof(IBAKSERDAT.ZPIMSGID));
			memcpy(IBAKSERDAT.ZIFERNAM, IQCMSERDAT.ZIFERNAM, sizeof(IBAKSERDAT.ZIFERNAM));
			memcpy(IBAKSERDAT.ZIFDATE, IQCMSERDAT.ZIFDATE, sizeof(IBAKSERDAT.ZIFDATE));
			memcpy(IBAKSERDAT.ZIFTIME, IQCMSERDAT.ZIFTIME, sizeof(IBAKSERDAT.ZIFTIME));
			IBAKSERDAT.ZPISTAT = IQCMSERDAT.ZPISTAT;
			memcpy(IBAKSERDAT.ZPIMSG, IQCMSERDAT.ZPIMSG, sizeof(IBAKSERDAT.ZPIMSG));
			CDB_update_ibakserdat(1, &IBAKSERDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "IBAKSERDAT UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
				TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
				TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iqcmserdat(3);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}

		// DELETE
		CDB_delete_iqcmserdat(1, &IQCMSERDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IQCMSERDAT DELETE(1)", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
			TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
			TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
			TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_iqcmserdat(3);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		DB_commit();
	}

	return MP_TRUE;
}

int CWIP_R_Create_Req_No(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
	/*
	TRSNode* gen_id_in, * gen_id_out, * argument_list;

	char s_sys_time[14];
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);

	LOG_head("CWIP_R_Create_Req_No");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	gen_id_in = TRS.create_node("GEN_ID_IN");
	gen_id_out = TRS.create_node("GEN_ID_OUT");

	CCOM_copy_in_node(in_node, gen_id_in);
	TRS.add_char(gen_id_in, IN_PROCSTEP, '2');

	TRS.add_nstring(gen_id_in, "KEY_FACTORY", TRS.get_factory(in_node));
	TRS.add_string(gen_id_in, "RULE_ID", "MODULE_REQ_NO", strlen("MODULE_REQ_NO"));
	TRS.add_char(gen_id_in, "TRAN_SUCCESS_FLAG", 'Y');

	argument_list = TRS.add_node(gen_id_in, "ARGU_LIST");
	TRS.add_string(argument_list, "ARGUMENT", "R", strlen("R"));
	TRS.add_string(gen_id_in, "SEQ_KEY_1", "R", strlen("R"));

	argument_list = TRS.add_node(gen_id_in, "ARGU_LIST");
	TRS.add_string(argument_list, "ARGUMENT", s_sys_time, sizeof(s_sys_time));
	TRS.add_string(gen_id_in, "SEQ_KEY_2", s_sys_time, sizeof(s_sys_time));

	if (WIP_GENERATE_ID(s_msg_code, gen_id_in, gen_id_out) == MP_FALSE)
	{
		TRS.init_node(out_node);
		TRS.clone(out_node, gen_id_out);

		TRS.free_node(gen_id_in);
		TRS.free_node(gen_id_out);

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	TRS.set_nstring(in_node, "REQ_NO", TRS.get_string(gen_id_out, "GEN_ID"));
	TRS.free_node(gen_id_in);
	TRS.free_node(gen_id_out);
	*/
	return MP_TRUE;
}