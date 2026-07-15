/*******************************************************************************

	System      : MESplus
	Module      : Update Move Request
	File Name   : CWIP_update_move_request.c

	MES Version : 5.0

	Function List
		-

	Detail Description
		-

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2023.03.30  jhji

	Copyright(C) 1998-2008 Miracom,Inc.
	All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"
#include "BASCore_common.h"
#include "CUS_common.h"

int CWIP_Update_Move_Request_Validation(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node);

int CWIP_Create_Req_No(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
int CWIP_Create_Move_Req_No(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
int CWIP_Check_Request_History(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
int CWIP_UPDATE_MOVE_REQUEST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
/*******************************************************************************
	CWIP_Update_Move_Request()
		- Move Request
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Move_Request(TRSNode* in_node, TRSNode* out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret = MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_MOVE_REQUEST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_Update_Move_Request", out_node);

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
	CWIP_Update_Move_Request()
		- Update Tray
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- char *s_msg_code : Error Msg Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_MOVE_REQUEST(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	// INIT
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MSECUSRDEF_TAG MSECUSRDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CWIPREQMST_TAG CWIPREQMST;
	struct CWIPREQDTL_TAG CWIPREQDTL;
	struct IQCMSAMDAT_TAG IQCMSAMDAT;
	struct IQCMSAMDAT_TAG IQCMSAMDAT_D;
	struct IQCMSAMDAT_TAG IQCMSAMDAT_B;
	//struct CWIPTRPHIS_TAG CWIPTRPHIS;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	struct MWIPORDSTS_TAG MWIPORDSTS;	//23.05.31 추가
	struct CWIPLOTPAK_TAG CWIPLOTPAK;

	char c_shift = ' ';
	char s_sys_time[14];
	int i;
	int i_list_count;
	int i_del_count;
		
	TRSNode** lot_list;
	TRSNode* hold_lot_In;
	TRSNode* release_lot_in;
	TRSNode* hold_lot_out;
	TRSNode* release_lot_out;
	TRSNode* req_no_in;
	TRSNode* req_no_out;

	// PROCESS LOG PRINT
	LOG_head("CWIP_Update_Move_Request");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

	if (CWIP_Update_Move_Request_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	///이동 요청 Transation : OQC
	if (TRS.get_procstep(in_node) == '1')
	{
		///ERP 와 연계 공정인지 체크 한다.
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "TO_OPER");
		DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0010");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}

			TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		i_list_count = TRS.get_item_count(in_node, "REQ_LOT_LIST");
		lot_list = TRS.get_list(in_node, "REQ_LOT_LIST");

		for (i = 0; i < i_list_count; i++)
		{

			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0631");	
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}
				
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
						
			//PACKING 여부 확인 
			CDB_init_cwiplotpak(&CWIPLOTPAK);
			TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CWIPLOTPAK.STATUS_FLAG = 'C';
			//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈 Request 안되게 
			if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
			{
				strcpy(s_msg_code, "WIP-0564");		
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SCALAR(3)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if (MWIPLOTSTS.HOLD_FLAG == 'Y')
			{
				strcpy(s_msg_code, "WIP-0632");		
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "HOLD_FLAG", MP_CHR, MWIPLOTSTS.HOLD_FLAG);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
			{
				strcpy(s_msg_code, "WIP-0637");		
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);
				TRS.add_fieldmsg(out_node, "LOT_DEL_FLAG", MP_CHR, MWIPLOTSTS.LOT_DEL_FLAG);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//사용자 정보 조회
			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MSECUSRDEF.USER_ID, sizeof(MSECUSRDEF.USER_ID), in_node, IN_USERID);
			DBC_select_msecusrdef(1, &MSECUSRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					///SEC-0006 : 이 사용자는 존재하지 않읍니다. 다시 확인하여 주십시요.
					strcpy(s_msg_code, "SEC-0006");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID);
				
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;

			}

			/*GRADE 또는 POWER 없으면*/
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			CDB_select_cedclotrlt(1, &CEDCLOTRLT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
					
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_SL_MAPPING_PRV, strlen(HQCEL_M1_GCM_SL_MAPPING_PRV));
			memcpy(MGCMTBLDAT.KEY_1, MSECUSRDEF.USER_CMF_3, sizeof(MGCMTBLDAT.KEY_1));
			memcpy(MGCMTBLDAT.KEY_2, "FR", strlen("FR"));
			memcpy(MGCMTBLDAT.KEY_3, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			memcpy(MGCMTBLDAT.DATA_1, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
			DBC_select_mgcmtbldat(107, &MGCMTBLDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0531");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");	
					gs_log_type.e_type = MP_LOG_E_SYSTEM;					
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT(107)", MP_NVST);
				TRS.add_fieldmsg(out_node, "USER_MOVE_GRP", MP_STR, sizeof(MSECUSRDEF.USER_CMF_3), MSECUSRDEF.USER_CMF_3);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
				TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(CEDCLOTRLT.GRADE), CEDCLOTRLT.GRADE);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			/*LOT HOLD*/
			hold_lot_In = TRS.create_node("HOLD_LOT_IN");
			hold_lot_out = TRS.create_node("HOLD_LOT_Out");
			TRS.add_char(hold_lot_In, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(hold_lot_In, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(hold_lot_In, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(hold_lot_In, IN_FACTORY, TRS.get_factory(in_node));

			TRS.set_string(hold_lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.set_int(hold_lot_In, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
			TRS.set_char(hold_lot_In, "END_FLAG", MWIPLOTSTS.END_FLAG);
			TRS.set_string(hold_lot_In, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.set_int(hold_lot_In, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.set_string(hold_lot_In, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(hold_lot_In, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);

			TRS.set_string(hold_lot_In, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_string(hold_lot_In, "HOLD_CODE", "REQ_MOVE", strlen("REQ_MOVE"));

			if (WIP_HOLD_LOT(s_msg_code, hold_lot_In, hold_lot_out) == MP_FALSE)
			{
				strcpy(s_msg_code, "WIP-0634");
				TRS.add_fieldmsg(out_node, "WIP_HOLD_LOT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(hold_lot_In);
				TRS.free_node(hold_lot_out);
				return MP_FALSE;
			}

			TRS.free_node(hold_lot_In);
			TRS.free_node(hold_lot_out);

			//요청 중인 Request 확인 
			TRS.set_string(in_node, "INS_LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

			if (CWIP_Check_Request_History(s_msg_code, in_node, out_node) == MP_FALSE)
			{				
				strcpy(s_msg_code, "WIP-0641");
				TRS.add_fieldmsg(out_node, "CWIP_Check_Request_History", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				
				return MP_FALSE;
			}

			//Create REQ NO
			req_no_in = TRS.create_node("REQ_LOT_IN");
			req_no_out = TRS.create_node("REQ_LOT_OUT");
			TRS.add_char(req_no_in, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(req_no_in, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(req_no_in, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(req_no_in, IN_FACTORY, TRS.get_factory(in_node));
			TRS.add_string(req_no_in, "FROM_OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_nstring(req_no_in, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));

			if (CWIP_Create_Req_No(s_msg_code, req_no_in, req_no_out) == MP_FALSE)
			{				
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(req_no_in);
				TRS.free_node(req_no_out);
				return MP_FALSE;
			}

			CDB_init_cwipreqdtl(&CWIPREQDTL);
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO), req_no_in, "REQ_NO");
			memcpy(CWIPREQDTL.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CWIPREQDTL.LOT_ID));
			memcpy(CWIPREQDTL.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQDTL.CREATE_USER_ID, sizeof(CWIPREQDTL.CREATE_USER_ID), in_node, IN_USERID);
			CDB_insert_cwipreqdtl(&CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQDTL INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				
				TRS.free_node(req_no_in);
				TRS.free_node(req_no_out);
				return MP_FALSE;
			}

			TRS.free_node(req_no_in);
			TRS.free_node(req_no_out);

			TRS.set_string(in_node, "REQ_NO", CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO));
			///ERP IF 공정의 경우 ERP Data 생성
			if (MWIPOPRDEF.ERP_FLAG == 'Y')
			{
				/*[GRTP PROJECT] 추가 */
				DBC_init_mwipordsts(&MWIPORDSTS);
				TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
				memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				DBC_select_mwipordsts(1, &MWIPORDSTS);
				/*[GRTP PROJECT] 끝 */

				///IF 테이블
				CDB_init_iqcmsamdat(&IQCMSAMDAT);
				CDB_select_iqcmsamdat(2, &IQCMSAMDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT SELECT(2)", MP_NVST);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				TRS.add_string(in_node, "DOC_ID", IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID));
				TRS.copy(IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID), in_node, "DOC_ID");
				memcpy(IQCMSAMDAT.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
				memcpy(IQCMSAMDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				memcpy(IQCMSAMDAT.ACTION_TYPE, "I", strlen("I"));
				memcpy(IQCMSAMDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(IQCMSAMDAT.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				memcpy(IQCMSAMDAT.QC_INSPECTION, "Q", strlen("Q"));
				memcpy(IQCMSAMDAT.STORAGE_LOCATION, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));
				memcpy(IQCMSAMDAT.LOCATION, MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
				memcpy(IQCMSAMDAT.QUALITY_GRADE, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
				memcpy(IQCMSAMDAT.POWER_GRADE, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
				TRS.copy(IQCMSAMDAT.Z_GROUP, sizeof(IQCMSAMDAT.Z_GROUP), in_node, "REQ_NO");

				CDB_init_cedclotfqc(&CEDCLOTFQC);
				TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
				memcpy(CEDCLOTFQC.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				memcpy(CEDCLOTFQC.INS_TYPE, "FC", sizeof("FC"));
				memcpy(CEDCLOTFQC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				CDB_select_cedclotfqc(2, &CEDCLOTFQC);
				if (DB_error_code == DB_SUCCESS)
				{
					memcpy(IQCMSAMDAT.FQC_DEFECTCODE, CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE));
				}

				c_shift = CCOM_get_work_shift(s_sys_time);
				IQCMSAMDAT.SHIFT[0] = c_shift;

				IQCMSAMDAT.ZPISTAT = 'R';
				CDB_insert_iqcmsamdat(&IQCMSAMDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSAMDAT.DOC_ID), IQCMSAMDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSAMDAT.Z_GROUP), IQCMSAMDAT.Z_GROUP);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
	}
	//이동 요청 취소 Transaction 
	else if (TRS.get_procstep(in_node) == '2')
	{
		#pragma region SELECT CWIPREQMST
		CDB_init_cwipreqmst(&CWIPREQMST);
		TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO), in_node, "REQ_NO");
		CDB_select_cwipreqmst(1, &CWIPREQMST);
		if (DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0643"); 
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");	
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}
			TRS.add_fieldmsg(out_node, "CWIPREQMST SELECT(1)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
			TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
			

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		#pragma endregion SELECT CWIPREQMST

		if (memcmp(CWIPREQMST.TO_OPER, HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER)) &&
			memcmp(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_RJ, strlen(HQCEL_M1_REQ_STATUS_RJ)) == 0)
		{
			#pragma region REJECT 된 이동요청 이었다면 창고<->창고 : DTL LOT 이력 넣어주기 
			CDB_init_cwipreqdtl(&CWIPREQDTL);
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO), in_node, "REQ_NO");
			TRS.copy(CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID), in_node, "LOT_ID");
			CDB_select_cwipreqdtl(5, &CWIPREQDTL);

			if (DB_error_code == DB_SUCCESS)
			{
				memcpy(CWIPREQDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
				TRS.copy(CWIPREQDTL.UPDATE_USER_ID, sizeof(CWIPREQDTL.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CWIPREQDTL.REQ_DTL_CMF_1, HQCEL_M1_REQ_STATUS_CL, strlen(HQCEL_M1_REQ_STATUS_CL));
				CDB_update_cwipreqdtl(1, &CWIPREQDTL);
			}
			#pragma endregion 
		}
		else
		{

			#pragma region ERP 연계 공정 확인 
			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPOPRDEF.OPER, CWIPREQMST.TO_OPER, sizeof(CWIPREQMST.TO_OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0010");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;					
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_COMMON;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			#pragma endregion  ERP 연계 공정 확인 

			#pragma region 권한 체크 
			//사용자 정보 조회
			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MSECUSRDEF.USER_ID, sizeof(MSECUSRDEF.USER_ID), in_node, IN_USERID);
			DBC_select_msecusrdef(1, &MSECUSRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					///SEC-0006 : 이 사용자는 존재하지 않읍니다. 다시 확인하여 주십시요.
					strcpy(s_msg_code, "SEC-0006");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);

				}
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID);
				
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//CWIPREQDTL 에서 LOT 조회 
			CDB_init_cwipreqdtl(&CWIPREQDTL);
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO), in_node, "REQ_NO");
			TRS.copy(CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID), in_node, "LOT_ID");
			CDB_select_cwipreqdtl(1, &CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0044");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}
				TRS.add_fieldmsg(out_node, "CWIPREQDTL SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			}

			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPLOTSTS.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0006");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}
				TRS.add_fieldmsg(out_node, "CWIPREQDTL SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			
			/*GRADE 또는 POWER 없으면*/
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			CDB_select_cedclotrlt(1, &CEDCLOTRLT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
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
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_SL_MAPPING_PRV, strlen(HQCEL_M1_GCM_SL_MAPPING_PRV));
			memcpy(MGCMTBLDAT.KEY_1, MSECUSRDEF.USER_CMF_3, sizeof(MGCMTBLDAT.KEY_1));
			memcpy(MGCMTBLDAT.KEY_2, "FR", strlen("FR"));
			memcpy(MGCMTBLDAT.KEY_3, CWIPREQMST.FROM_OPER, sizeof(MWIPOPRDEF.OPER));
			memcpy(MGCMTBLDAT.DATA_1, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
			DBC_select_mgcmtbldat(107, &MGCMTBLDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0531");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");	
					gs_log_type.e_type = MP_LOG_E_SYSTEM;					
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT(107)", MP_NVST);
				TRS.add_fieldmsg(out_node, "USER_MOVE_GRP", MP_STR, sizeof(MSECUSRDEF.USER_CMF_3), MSECUSRDEF.USER_CMF_3);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
				TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(CEDCLOTRLT.GRADE), CEDCLOTRLT.GRADE);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;

			}
			#pragma endregion  권한 체크 

			#pragma region RELEASE LOT/ INSERT ERP DATA 
			///HOLD 상태이면 RELEASE를 한다.
			if (MWIPLOTSTS.HOLD_FLAG == 'Y')
			{
				release_lot_in = TRS.create_node("RELEASE_LOT_IN");
				release_lot_out = TRS.create_node("RELEASE_LOT_OUT");
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
				TRS.set_char(release_lot_in, "END_FLAG", MWIPLOTSTS.END_FLAG);

				if (WIP_RELEASE_LOT(s_msg_code, release_lot_in, release_lot_out) == MP_FALSE)
				{
					strcpy(s_msg_code, "WIP-0642");		
					TRS.add_fieldmsg(out_node, "WIP_RELEASE_LOT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(release_lot_in);
					TRS.free_node(release_lot_out);
					return MP_FALSE;					
				}

				TRS.free_node(release_lot_in);
				TRS.free_node(release_lot_out);
			}

			#pragma region ERP IF 공정의 경우 ERP Data 생성
			if (MWIPOPRDEF.ERP_FLAG == 'Y')
			{
				CDB_init_iqcmsamdat(&IQCMSAMDAT_B); 
				memcpy(IQCMSAMDAT_B.Z_GROUP, CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO));
				memcpy(IQCMSAMDAT_B.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
				memcpy(IQCMSAMDAT_B.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				memcpy(IQCMSAMDAT_B.ACTION_TYPE, "D", strlen("D"));
				//취소 이력이 있는지 확인 
				i_del_count = (int)CDB_select_iqcmsamdat_scalar(2, &IQCMSAMDAT_B);

				if (i_del_count > 0)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT SCALAR(2)", MP_NVST);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSAMDAT_B.Z_GROUP), IQCMSAMDAT_B.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				//모듈 별 취소 기존 데이터 조회
				CDB_select_iqcmsamdat(3, &IQCMSAMDAT_B);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN(2)", MP_NVST);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSAMDAT.Z_GROUP), IQCMSAMDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				/*[GRTP PROJECT] 추가 */
				DBC_init_mwipordsts(&MWIPORDSTS);
				TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
				memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				DBC_select_mwipordsts(1, &MWIPORDSTS);
				/*[GRTP PROJECT] 끝 */

				#pragma region INSERT IQCMSAMDAT ACTION_TYPE = 'D'
				CDB_init_iqcmsamdat(&IQCMSAMDAT);
				// SELECT NEW DOC ID
				CDB_init_iqcmsamdat(&IQCMSAMDAT_D);
				CDB_select_iqcmsamdat(2, &IQCMSAMDAT_D);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004"); //DOC ID 를 생성 할 수 없습니다. 
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT SELECT(2)", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				memcpy(IQCMSAMDAT.DOC_ID, IQCMSAMDAT_D.DOC_ID, sizeof(IQCMSAMDAT_D.DOC_ID));
				memcpy(IQCMSAMDAT.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
				memcpy(IQCMSAMDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				memcpy(IQCMSAMDAT.MATE_NO, IQCMSAMDAT_B.MATE_NO, sizeof(IQCMSAMDAT_B.MATE_NO));
				memcpy(IQCMSAMDAT.ACTION_TYPE, "D", strlen("D"));
				memcpy(IQCMSAMDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(IQCMSAMDAT.QC_INSPECTION, "Q", strlen("Q"));
				memcpy(IQCMSAMDAT.STORAGE_LOCATION, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));
				memcpy(IQCMSAMDAT.LOCATION, MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
				memcpy(IQCMSAMDAT.QUALITY_GRADE, IQCMSAMDAT_B.QUALITY_GRADE, sizeof(IQCMSAMDAT_B.QUALITY_GRADE));
				memcpy(IQCMSAMDAT.POWER_GRADE, IQCMSAMDAT_B.POWER_GRADE, sizeof(IQCMSAMDAT_B.POWER_GRADE));
				memcpy(IQCMSAMDAT.Z_GROUP, IQCMSAMDAT_B.Z_GROUP, sizeof(IQCMSAMDAT_B.Z_GROUP));

				CDB_init_cedclotfqc(&CEDCLOTFQC);
				TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
				memcpy(CEDCLOTFQC.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				memcpy(CEDCLOTFQC.INS_TYPE, "FC", sizeof("FC"));
				memcpy(CEDCLOTFQC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

				CDB_select_cedclotfqc(2, &CEDCLOTFQC);
				if (DB_error_code == DB_SUCCESS)
				{
					memcpy(IQCMSAMDAT.FQC_DEFECTCODE, CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE));
				}

				c_shift = CCOM_get_work_shift(s_sys_time);
				IQCMSAMDAT.SHIFT[0] = c_shift;

				IQCMSAMDAT.ZPISTAT = 'R';
				CDB_insert_iqcmsamdat(&IQCMSAMDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSAMDAT.DOC_ID), IQCMSAMDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSAMDAT.Z_GROUP), IQCMSAMDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				#pragma endregion INSERT IQCMSAMDAT ACTION_TYPE = 'D' END
			}
			#pragma endregion RELEASE LOT/ INSERT ERP DATA 

			#pragma region 이동 요청 마스터 CANCLE	
			//CLOSE된 요청이면 X 
			if (memcmp(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_C, strlen(HQCEL_M1_REQ_STATUS_C)) == 0)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQMST SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
				TRS.add_fieldmsg(out_node, "REQ_STATUS", MP_STR, sizeof(CWIPREQMST.REQ_STATUS), CWIPREQMST.REQ_STATUS);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			memcpy(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_CL, strlen(HQCEL_M1_REQ_STATUS_CL));
			memcpy(CWIPREQMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQMST.UPDATE_USER_ID, sizeof(CWIPREQMST.UPDATE_USER_ID), in_node, IN_USERID);
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

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			#pragma endregion  이동 요청 마스터 CLOSE
		}


	}
	//이동 요청 Transation : 창고 <-> 창고
	else if (TRS.get_procstep(in_node) == '3')
	{
		#pragma region 공정 확인 
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "TO_OPER");
		DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0010");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}

			TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		#pragma endregion 공정 확인 

		#pragma region 창고 이동 Request Lot List
		i_list_count = TRS.get_item_count(in_node, "REQ_LOT_LIST");
		lot_list = TRS.get_list(in_node, "REQ_LOT_LIST");
		for (i = 0; i < i_list_count; i++)
		{
			#pragma region LOT 조회
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0631");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");					
					TRS.add_dberrmsg(out_node, DB_error_msg);					
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}
				
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//PACKING 여부 확인 
			CDB_init_cwiplotpak(&CWIPLOTPAK);
			TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CWIPLOTPAK.STATUS_FLAG = 'C';
			//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈 Request 안되게 
			if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
			{
				strcpy(s_msg_code, "WIP-0564");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK SCALAR(3)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			// 이동 LOT HOLD 상태면 X
			if (MWIPLOTSTS.HOLD_FLAG == 'Y')
			{
				strcpy(s_msg_code, "WIP-0632");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "HOLD_FLAG", MP_CHR,MWIPLOTSTS.HOLD_FLAG);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
			{
				strcpy(s_msg_code, "WIP-0637");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "LOT_DEL_FLAG", MP_CHR,MWIPLOTSTS.LOT_DEL_FLAG);
				
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			#pragma endregion LOT 조회		

			#pragma region 권한 확인
			//사용자 정보 조회
			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MSECUSRDEF.USER_ID, sizeof(MSECUSRDEF.USER_ID), in_node, IN_USERID);
			DBC_select_msecusrdef(1, &MSECUSRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					///SEC-0006 : 이 사용자는 존재하지 않읍니다. 다시 확인하여 주십시요.
					strcpy(s_msg_code, "SEC-0006");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);

				}
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID);
				
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;

			}

			/*GRADE 또는 POWER 없으면*/
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			CDB_select_cedclotrlt(1, &CEDCLOTRLT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
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
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_SL_MAPPING_PRV, strlen(HQCEL_M1_GCM_SL_MAPPING_PRV));
			memcpy(MGCMTBLDAT.KEY_1, MSECUSRDEF.USER_CMF_3, sizeof(MGCMTBLDAT.KEY_1));
			memcpy(MGCMTBLDAT.KEY_2, "FR", strlen("FR"));
			memcpy(MGCMTBLDAT.KEY_3, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			memcpy(MGCMTBLDAT.DATA_1, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
			DBC_select_mgcmtbldat(107, &MGCMTBLDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0531");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");	
					gs_log_type.e_type = MP_LOG_E_SYSTEM;					
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT(107)", MP_NVST);
				TRS.add_fieldmsg(out_node, "USER_MOVE_GRP", MP_STR, sizeof(MSECUSRDEF.USER_CMF_3), MSECUSRDEF.USER_CMF_3);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
				TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(CEDCLOTRLT.GRADE), CEDCLOTRLT.GRADE);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));			

				return MP_FALSE;
			}
			#pragma endregion LOT 확인	
			
			/*LOT HOLD*/
			hold_lot_In = TRS.create_node("HOLD_LOT_IN");
			hold_lot_out = TRS.create_node("HOLD_LOT_OUT");
			TRS.add_char(hold_lot_In, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(hold_lot_In, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(hold_lot_In, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(hold_lot_In, IN_FACTORY, TRS.get_factory(in_node));

			TRS.set_string(hold_lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.set_int(hold_lot_In, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
			TRS.set_char(hold_lot_In, "END_FLAG", MWIPLOTSTS.END_FLAG);
			TRS.set_string(hold_lot_In, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.set_int(hold_lot_In, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.set_string(hold_lot_In, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(hold_lot_In, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);

			TRS.set_string(hold_lot_In, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_string(hold_lot_In, "HOLD_CODE", "REQ_MOVE", strlen("REQ_MOVE"));

			if (WIP_HOLD_LOT(s_msg_code, hold_lot_In, hold_lot_out) == MP_FALSE)
			{
				strcpy(s_msg_code, "WIP-0634");
				TRS.add_fieldmsg(out_node, "WIP_HOLD_LOT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(hold_lot_In);
				TRS.free_node(hold_lot_out);
				return MP_FALSE;
			}

			TRS.free_node(hold_lot_In);
			TRS.free_node(hold_lot_out);


			//요청 중인 Request 확인 
			TRS.set_string(in_node, "INS_LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

			if (CWIP_Check_Request_History(s_msg_code, in_node, out_node) == MP_FALSE)
			{
				strcpy(s_msg_code, "WIP-0641");
				TRS.add_fieldmsg(out_node, "CWIP_Check_Request_History", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
				return MP_FALSE;
			}

			//Create REQ NO
			req_no_in = TRS.create_node("REQ_LOT_IN");
			req_no_out = TRS.create_node("REQ_LOT_OUT");
			TRS.add_char(req_no_in, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(req_no_in, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(req_no_in, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(req_no_in, IN_FACTORY, TRS.get_factory(in_node));
			TRS.add_string(req_no_in, "FROM_OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_nstring(req_no_in, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));

			if (CWIP_Create_Move_Req_No(s_msg_code, req_no_in, req_no_out) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(req_no_in));
				TRS.free_node(req_no_in);
				TRS.free_node(req_no_out);
				return MP_FALSE;
			}

			/* REJECT 된 이동요청이 있었다면 REQ_DTL_CMF_1 = 'REQUEST' */
			CDB_init_cwipreqdtl(&CWIPREQDTL);
			memcpy(CWIPREQDTL.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPREQDTL.FACTORY));
			memcpy(CWIPREQDTL.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CWIPREQDTL.LOT_ID));
			CDB_select_cwipreqdtl(5, &CWIPREQDTL);

			if (DB_error_code == DB_SUCCESS)
			{
				memcpy(CWIPREQDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
				TRS.copy(CWIPREQDTL.UPDATE_USER_ID, sizeof(CWIPREQDTL.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CWIPREQDTL.REQ_DTL_CMF_1, HQCEL_M1_REQ_STATUS_R, strlen(HQCEL_M1_REQ_STATUS_R));
				CDB_update_cwipreqdtl(1, &CWIPREQDTL);
			}
			/***************************************/

			CDB_init_cwipreqdtl(&CWIPREQDTL);
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO), req_no_in, "REQ_NO");
			memcpy(CWIPREQDTL.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CWIPREQDTL.LOT_ID));
			memcpy(CWIPREQDTL.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQDTL.CREATE_USER_ID, sizeof(CWIPREQDTL.CREATE_USER_ID), in_node, IN_USERID);
			CDB_insert_cwipreqdtl(&CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQDTL INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;				
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(req_no_in);
				TRS.free_node(req_no_out);

				return MP_FALSE;
			}

			TRS.free_node(req_no_in);
			TRS.free_node(req_no_out);

		}
	}
	#pragma endregion 창고 이동 Request Lot List

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
	CWIP_Update_Move_Request_Validation()
		- Main sub function of "CWIP_Update_Move_Request" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Move_Request_Validation(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	struct MWIPFACDEF_TAG MWIPFACDEF;

	/* ProcStep Validation */
	if (COM_service_validation(s_msg_code,
		in_node,
		out_node,
		TRS.get_procstep(in_node),
		"123") == MP_FALSE)
	{
		return MP_FALSE;
	}

	/* Factory Validation */
	if (COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
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
	if (DB_error_code != DB_SUCCESS)
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

int CWIP_Create_Req_No(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
	struct CWIPREQMST_TAG CWIPREQMST;
	struct worktime_tag cur_work_time;

	TRSNode* gen_id_in, * gen_id_out, * argument_list;

	char s_sys_time[14];
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);

	/* CURRENT TIME   */
	CCOM_get_work_time(s_sys_time, &cur_work_time);

	LOG_head("CWIP_Create_Req_No");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	/*REQ NO GENERATE */
	gen_id_in = TRS.create_node("GEN_ID_IN");
	gen_id_out = TRS.create_node("GEN_ID_OUT");

	CCOM_copy_in_node(in_node, gen_id_in);
	TRS.add_char(gen_id_in, IN_PROCSTEP, '2');

	TRS.add_nstring(gen_id_in, "KEY_FACTORY", TRS.get_factory(in_node));
	TRS.add_string(gen_id_in, "RULE_ID", "MODULE_REQ_NO", strlen("MODULE_REQ_NO"));
	TRS.add_char(gen_id_in, "TRAN_SUCCESS_FLAG", 'Y');

	argument_list = TRS.add_node(gen_id_in, "ARGU_LIST");
	TRS.add_string(argument_list, "ARGUMENT", "Q", strlen("Q"));
	TRS.add_string(gen_id_in, "SEQ_KEY_1", "Q", strlen("Q"));

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

	CDB_init_cwipreqmst(&CWIPREQMST);
	TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO), in_node, "REQ_NO");
	memcpy(CWIPREQMST.REQ_TYPE, "Q", strlen("Q"));
	memcpy(CWIPREQMST.REQ_STATUS, "REQUEST", strlen("REQUEST"));
	memcpy(CWIPREQMST.REQ_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
	TRS.copy(CWIPREQMST.FROM_OPER, sizeof(CWIPREQMST.FROM_OPER), in_node, "FROM_OPER");
	TRS.copy(CWIPREQMST.TO_OPER, sizeof(CWIPREQMST.TO_OPER), in_node, "TO_OPER");
	TRS.copy(CWIPREQMST.REQ_USER_ID, sizeof(CWIPREQMST.REQ_USER_ID), in_node, IN_USERID);
	memcpy(CWIPREQMST.REQ_TIME, s_sys_time, sizeof(s_sys_time));
	memcpy(CWIPREQMST.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
	TRS.copy(CWIPREQMST.CREATE_USER_ID, sizeof(CWIPREQMST.CREATE_USER_ID), in_node, IN_USERID);
	CDB_insert_cwipreqmst(&CWIPREQMST);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPREQMST INSERT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
		TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
		TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(CWIPREQMST.FROM_OPER), CWIPREQMST.FROM_OPER);
		TRS.add_fieldmsg(out_node, "TO_OPER", MP_STR, sizeof(CWIPREQMST.TO_OPER), CWIPREQMST.TO_OPER);

		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	return MP_TRUE;
}

int CWIP_Create_Move_Req_No(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
	struct CWIPREQMST_TAG CWIPREQMST;
	struct worktime_tag cur_work_time;
	TRSNode* gen_id_in, * gen_id_out, * argument_list;

	char s_sys_time[14];
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);

	LOG_head("CWIP_Create_Move_Req_No");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	/* CURRENT TIME   */
	CCOM_get_work_time(s_sys_time, &cur_work_time);

	/*REQ NO GENERATE */
	gen_id_in = TRS.create_node("GEN_ID_IN");
	gen_id_out = TRS.create_node("GEN_ID_OUT");

	CCOM_copy_in_node(in_node, gen_id_in);
	TRS.add_char(gen_id_in, IN_PROCSTEP, '2');

	TRS.add_nstring(gen_id_in, "KEY_FACTORY", TRS.get_factory(in_node));
	TRS.add_string(gen_id_in, "RULE_ID", "MODULE_REQ_NO", strlen("MODULE_REQ_NO"));
	TRS.add_char(gen_id_in, "TRAN_SUCCESS_FLAG", 'Y');

	argument_list = TRS.add_node(gen_id_in, "ARGU_LIST");
	TRS.add_string(argument_list, "ARGUMENT", "M", strlen("M"));
	TRS.add_string(gen_id_in, "SEQ_KEY_1", "M", strlen("M"));

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

	CDB_init_cwipreqmst(&CWIPREQMST);
	TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO), in_node, "REQ_NO");
	memcpy(CWIPREQMST.REQ_TYPE, "M", strlen("M"));
	memcpy(CWIPREQMST.REQ_STATUS, "REQUEST", strlen("REQUEST"));
	memcpy(CWIPREQMST.REQ_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
	TRS.copy(CWIPREQMST.FROM_OPER, sizeof(CWIPREQMST.FROM_OPER), in_node, "FROM_OPER");
	TRS.copy(CWIPREQMST.TO_OPER, sizeof(CWIPREQMST.TO_OPER), in_node, "TO_OPER");
	TRS.copy(CWIPREQMST.REQ_USER_ID, sizeof(CWIPREQMST.REQ_USER_ID), in_node, IN_USERID);
	memcpy(CWIPREQMST.REQ_TIME, s_sys_time, sizeof(s_sys_time));
	memcpy(CWIPREQMST.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
	TRS.copy(CWIPREQMST.CREATE_USER_ID, sizeof(CWIPREQMST.CREATE_USER_ID), in_node, IN_USERID);
	CDB_insert_cwipreqmst(&CWIPREQMST);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPREQMST INSERT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
		TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
		TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(CWIPREQMST.FROM_OPER), CWIPREQMST.FROM_OPER);
		TRS.add_fieldmsg(out_node, "TO_OPER", MP_STR, sizeof(CWIPREQMST.TO_OPER), CWIPREQMST.TO_OPER);

		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	return MP_TRUE;
}
/*******************************************************************************
	CWIP_Check_OQC_History()
		- Main sub function of "CWIP_Update_Move_Request" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Check_Request_History(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
	struct CWIPREQMST_TAG CWIPREQMST;
	int i_move_return = 0;

	//이동 요청 확인 
	CDB_init_cwipreqmst(&CWIPREQMST);
	TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPREQMST.REQ_CMF_1, sizeof(CWIPREQMST.REQ_CMF_1), in_node, "INS_LOT_ID"); // 임시 LOT
	i_move_return = (int)CDB_select_cwipreqmst_scalar(4, &CWIPREQMST);

	if (i_move_return > 0)
	{
		return MP_FALSE;
	}

	return MP_TRUE;
}
