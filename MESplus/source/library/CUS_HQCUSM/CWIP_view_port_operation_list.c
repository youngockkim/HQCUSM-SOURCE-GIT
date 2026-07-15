/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_port_operation_list.c
	Description : View Operation List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Port_Operation_list()
			+ View Lot
		- CWIP_View_Port_Operation_list()
			+ Main sub function of CWIP_View_Port_Operation_list function
			+ View Operation List definition
		- CWIP_View_Port_Operation_list_Validation()
			+ Main sub function of CWIP_View_Port_Operation_list function
			+ Check the condition for View Operation List
	Detail Description
		- CWIP_View_Port_Operation_list()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/
#include "CUS_HQCUSM_common.h"
#include "CUS_common.h"

int CWIP_View_Port_Operation_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Port_Operation_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Port_Operation_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_PORT_OPERATION_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_View_Port_Operation_List", out_node);

	TRS.log_add_all_members(out_node);

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
	CWIP_View_Port_Operation_list()
		- Main sub function of "CWIP_View_Port_Operation_list" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_PORT_OPERATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MGCMTBLDEF_TAG MGCMTBLDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    struct MWIPOPRDEF_TAG MWIPOPRDEF;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	//struct MWIPLOTHIS_TAG MWIPLOTHIS;
	//struct MWIPMATFLW_TAG MWIPMATFLW;
    struct MWIPORDSTS_TAG MWIPORDSTS;	//23.05.31 추가
	struct MSECUSRDEF_TAG MSECUSRDEF;
	
	struct CWIPREQMST_TAG CWIPREQMST;
	struct CWIPREQDTL_TAG CWIPREQDTL;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CWIPTRPHIS_TAG CWIPTRPHIS;

	struct IQCMSAMDAT_TAG IQCMSAMDAT;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;

    TRSNode *list_item;
	TRSNode **lot_list;
	TRSNode *Release_Lot_In;
	TRSNode *tran_in_node;
	TRSNode *tran_out_node;

	int i,i_step;
	int i_list_count;
	int i_diff_sec;

	char s_sys_time[14];

    LOG_head("CWIP_View_Port_Operation_List");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
    /* 
        Step 1: PORT 재공 관리의 FROM or To Oper를 조회 한다.
		Step 2: PORT 정보를 조회 한다.
		Step 3: 파워 정보를 조회 한다.
		Step 4: 요청 리스트 조회 - 창고간 이동 : Request/ Reject
		Step 5: FROM 공정 Confirm 대상 조회 
		Step 6: 이동 요청 확정 로직
		Step 7: 원래 공정으로 이동
		Step 8: TO 공정 Confirm 대상 조회 (HOLD_CODE 유무로 구분 함)
		Step A/B: 창고간 이동 요청 리스트 조회  
    */

    if(CWIP_View_Port_Operation_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if(TRS.get_procstep(in_node) == '1')
	{
		///GCM TABLE 체크
		DBC_init_mgcmtbldef(&MGCMTBLDEF);
		TRS.copy(MGCMTBLDEF.FACTORY, sizeof(MGCMTBLDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDEF.TABLE_NAME, HQCEL_M1_GCM_SL_MAPPING_PRV, strlen(HQCEL_M1_GCM_SL_MAPPING_PRV));
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

			TRS.add_fieldmsg(out_node, "MGCMTBLDEF SELECT(1)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}	

		//사용자 정보 조회
		DBC_init_msecusrdef(&MSECUSRDEF);
		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MSECUSRDEF.USER_ID, sizeof(MSECUSRDEF.USER_ID), in_node, IN_USERID);
		DBC_select_msecusrdef(1,&MSECUSRDEF);
		if(DB_error_code != DB_SUCCESS)
		{ 
			if(DB_error_code == DB_NOT_FOUND)
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
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 

		}

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_SL_MAPPING_PRV, strlen(HQCEL_M1_GCM_SL_MAPPING_PRV));
		memcpy(MGCMTBLDAT.KEY_1, MSECUSRDEF.USER_CMF_3, sizeof(MGCMTBLDAT.KEY_1));
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_2");
		DBC_open_mgcmtbldat(106, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN(106)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
			TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			DBC_fetch_mgcmtbldat(106, &MGCMTBLDAT);
			if(DB_error_code == DB_NOT_FOUND)
			{
				DBC_close_mgcmtbldat(106);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				DBC_close_mgcmtbldat(106);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			///OPER 정보 조회
			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MWIPOPRDEF.OPER, MGCMTBLDAT.KEY_3, sizeof(MWIPOPRDEF.OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT(1)", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY); 
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				DBC_close_mgcmtbldat(106);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "OPER", MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER));
			TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));	
			//[ERP.05.28] SHOT DESC 추가
			TRS.add_string(list_item, "OPER_SHORT_DESC", MWIPOPRDEF.OPER_SHORT_DESC, sizeof(MWIPOPRDEF.OPER_SHORT_DESC));
		}
	}
	/// PORT 정보 조회
	else if(TRS.get_procstep(in_node) == '2')
	{
		if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
		{
			i_step = 105;
		}
		else
		{
			i_step = 104;
		}

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_TR_RES_PORT, strlen(HQCEL_M1_GCM_TR_RES_PORT));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "RES_ID");
		DBC_open_mgcmtbldat(i_step, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
			TRS.add_dberrmsg(out_node,DB_error_msg);

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
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				DBC_close_mgcmtbldat(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "PORT", MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2));
		}
	}
	/// POWER 정보 조회
	else if(TRS.get_procstep(in_node) == '3')
	{

		i_step = 104;
		
		DBC_init_mgcmlagdat(&MGCMLAGDAT);
		TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_POWER_RANGE, strlen(HQCEL_M1_GCM_POWER_RANGE));
		CDB_open_mgcmlagdat(i_step, &MGCMLAGDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN(104)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_mgcmlagdat(i_step, &MGCMLAGDAT);
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "GCM-0008");
				TRS.add_fieldmsg(out_node, "MGCMLAGDAT FETCH(104)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				CDB_close_mgcmlagdat(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "MGCMLAGDAT FETCH(104)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				CDB_close_mgcmlagdat(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "POWER", MGCMLAGDAT.KEY_3, sizeof(MGCMLAGDAT.KEY_3));
		}
	}
	///요청 리스트 조회
	else if(TRS.get_procstep(in_node) == '4')
	{
		i_step = 2;
		CDB_init_cwipreqmst(&CWIPREQMST);
		TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPREQMST.FROM_OPER, sizeof(CWIPREQMST.FROM_OPER), in_node, "FROM_OPER");
		TRS.copy(CWIPREQMST.TO_OPER, sizeof(CWIPREQMST.TO_OPER), in_node, "TO_OPER");
		TRS.copy(CWIPREQMST.REQ_CMF_1, sizeof(CWIPREQMST.REQ_CMF_1), in_node, "GRADE");
		TRS.copy(CWIPREQMST.REQ_CMF_2, sizeof(CWIPREQMST.REQ_CMF_2), in_node, "POWER");
		TRS.copy(CWIPREQMST.REQ_DATE, sizeof(CWIPREQMST.REQ_DATE), in_node, "FROM_DATE");
		TRS.copy(CWIPREQMST.REQ_CMF_3, sizeof(CWIPREQMST.REQ_CMF_3), in_node, "LOT_ID");
		CDB_open_cwipreqmst(i_step, &CWIPREQMST);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPREQMST OPEN(2)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
			TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(CWIPREQMST.FROM_OPER), CWIPREQMST.FROM_OPER);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		while(1)
		{
			CDB_fetch_cwipreqmst(i_step, &CWIPREQMST);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwipreqmst(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQMST FETCH(2)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
				TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(CWIPREQMST.FROM_OPER), CWIPREQMST.FROM_OPER);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_cwipreqmst(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}	
			
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "REQ_NO", CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO));
			TRS.add_string(list_item, "REQ_DATE", CWIPREQMST.REQ_DATE, sizeof(CWIPREQMST.REQ_DATE));
			TRS.add_string(list_item, "REQ_TIME", CWIPREQMST.REQ_TIME, sizeof(CWIPREQMST.REQ_TIME));			
			TRS.add_string(list_item, "REQ_STATUS", CWIPREQMST.REQ_STATUS, sizeof(CWIPREQMST.REQ_STATUS));
			TRS.add_string(list_item, "FROM_OPER", CWIPREQMST.FROM_OPER, sizeof(CWIPREQMST.FROM_OPER));
			TRS.add_string(list_item, "FROM_OPER_DESC", CWIPREQMST.REQ_CMF_1, sizeof(CWIPREQMST.REQ_CMF_1));
			TRS.add_string(list_item, "TO_OPER", CWIPREQMST.TO_OPER, sizeof(CWIPREQMST.TO_OPER));
			TRS.add_string(list_item, "TO_OPER_DESC", CWIPREQMST.REQ_CMF_2, sizeof(CWIPREQMST.REQ_CMF_2));
			TRS.add_string(list_item, "REQ_USER_ID", CWIPREQMST.REQ_USER_ID, sizeof(CWIPREQMST.REQ_USER_ID));
			TRS.add_string(list_item, "REQ_USER_DESC", CWIPREQMST.REQ_CMF_3, sizeof(CWIPREQMST.REQ_CMF_3));
			TRS.add_string(list_item, "LOT_ID", CWIPREQMST.REQ_CMF_4, sizeof(CWIPREQMST.REQ_CMF_4));
		}
	}
	///FROM 창고 모듈 ID LIST 조회
	else if(TRS.get_procstep(in_node) == '5')
	{
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER), in_node, "FROM_OPER");
		TRS.copy(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID), in_node, "MAT_ID");
		TRS.copy(MWIPLOTSTS.LOT_CMF_6, sizeof(MWIPLOTSTS.OPER), in_node, "GRADE");
		TRS.copy(MWIPLOTSTS.LOT_CMF_7, sizeof(MWIPLOTSTS.LOT_CMF_7), in_node, "POWER");
		//DBC_open_mwiplotsts(107, &MWIPLOTSTS);
		CDB_open_mwiplotsts(101, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN(107)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		while(1)
		{
			CDB_fetch_mwiplotsts(101, &MWIPLOTSTS);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_mwiplotsts(101);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS FETCH(107)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				CDB_close_mwiplotsts(101);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_string(list_item, "OPER_DESC", MWIPLOTSTS.LOT_CMF_8, sizeof(MWIPLOTSTS.LOT_CMF_8));
			TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_string(list_item, "MAT_DESC", MWIPLOTSTS.LOT_CMF_2, sizeof(MWIPLOTSTS.LOT_CMF_2));
			TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(list_item, "GRADE", MWIPLOTSTS.LOT_CMF_6, sizeof(MWIPLOTSTS.LOT_CMF_6));
			TRS.add_string(list_item, "POWER", MWIPLOTSTS.LOT_CMF_7, sizeof(MWIPLOTSTS.LOT_CMF_7));
		}
	}
	///이동 요청 Transation (검사공정으로)
	else if(TRS.get_procstep(in_node) == '6')
	{
		/////ERP 와 연계 공정인지 체크 한다.
		//DBC_init_mwipoprdef(&MWIPOPRDEF);
		//TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
		//TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "TO_OPER");
		//DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		//if(DB_error_code != DB_SUCCESS) 
		//{   
		//	if(DB_error_code == DB_NOT_FOUND)
		//	{
		//		strcpy(s_msg_code, "WIP-0010");
		//		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	}
		//	else 
		//	{
		//		strcpy(s_msg_code, "WIP-0004");
		//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//	}
		//	TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
		//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
		//	TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
		//	TRS.add_dberrmsg(out_node, DB_error_msg);

		//	gs_log_type.type = MP_LOG_ERROR;
		//	gs_log_type.category = MP_LOG_CATE_COMMON;
		//	CDB_close_iqcmserdat(2);
		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		//	return MP_FALSE;
		//}

		/////Q14로 이동하는 공정이면 REQ_NO 와 REQMST를 생성 한다.
		//if (MWIPOPRDEF.ERP_FLAG == 'Y')
		//{
		//	if(CWIP_Create_Req_No(s_msg_code, in_node, out_node) == MP_FALSE)
		//	{
		//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//		return MP_FALSE;
		//	}
		//}

		//i_list_count = TRS.get_item_count(in_node, "REQ_LOT_LIST");
		//lot_list = TRS.get_list(in_node, "REQ_LOT_LIST");
		//for( i = 0; i < i_list_count; i++)
		//{
		//	
		//	DBC_init_mwiplotsts(&MWIPLOTSTS);
		//	TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
		//	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
		//	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		//	if(DB_error_code != DB_SUCCESS)
		//	{
		//		if(DB_error_code == DB_NOT_FOUND)
		//		{
		//			strcpy(s_msg_code, "WIP-0044");
		//			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//		}
		//		else 
		//		{
		//			strcpy(s_msg_code, "WIP-0004");
		//			TRS.add_dberrmsg(out_node, DB_error_msg);
		//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		}
		//		TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
		//		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

		//		gs_log_type.type = MP_LOG_ERROR;
		//		gs_log_type.category = MP_LOG_CATE_TRANS;
		//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		//		return MP_FALSE;
		//	} 

		//	///등급공정간의 이동일 경우
		//	if (MWIPOPRDEF.ERP_FLAG != 'Y')
		//	{
		//		/* UNSTORE Lot */
		//		tran_in_node = TRS.create_node("UNSTORE_LOT_IN");
		//		tran_out_node = TRS.create_node("UNSTORE_LOT_OUT");

		//		CCOM_copy_in_node(in_node, tran_in_node);
		//		TRS.add_char(tran_in_node, "PROCSTEP", '1');  
		//		TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		//		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		//		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
		//		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER)); 
		//	
		//		TRS.add_string(tran_in_node,  "TO_FLOW", MWIPLOTSTS.STR_RET_FLOW, sizeof(MWIPLOTSTS.STR_RET_FLOW));
		//		TRS.add_string(tran_in_node,  "TO_OPER", MWIPLOTSTS.STR_RET_OPER, sizeof(MWIPLOTSTS.STR_RET_OPER));
		//		//TRS.add_nstring(tran_in_node, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));
		//		if(WIP_UNSTORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		//		{
		//			TRS.clone(out_node, tran_out_node);

		//			TRS.free_node(tran_in_node);
		//			TRS.free_node(tran_out_node);

		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//			return MP_FALSE;
		//		}
  //  
		//		TRS.free_node(tran_in_node);
		//		TRS.free_node(tran_out_node);

		//		/* STORE Lot */
		//		tran_in_node = TRS.create_node("STORE_LOT_IN");
		//		tran_out_node = TRS.create_node("STORE_LOT_OUT");

		//		CCOM_copy_in_node(in_node, tran_in_node);
		//		TRS.add_char(tran_in_node, "PROCSTEP", '1');  
		//		TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		//		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		//		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
		//		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER)); 
		//		TRS.add_nstring(tran_in_node, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));
		//	
		//		if(WIP_STORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		//		{
		//			TRS.clone(out_node, tran_out_node);

		//			TRS.free_node(tran_in_node);
		//			TRS.free_node(tran_out_node);

		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//			return MP_FALSE;
		//		}
  //  
		//		TRS.free_node(tran_in_node);
		//		TRS.free_node(tran_out_node);
		//	}

		//	///Q14로 이동일 경우
		//	else
		//	{
		//		//사용자 정보 조회
		//		DBC_init_msecusrdef(&MSECUSRDEF);
		//		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
		//		TRS.copy(MSECUSRDEF.USER_ID, sizeof(MSECUSRDEF.USER_ID), in_node, IN_USERID);
		//		DBC_select_msecusrdef(1,&MSECUSRDEF);
		//		if(DB_error_code != DB_SUCCESS)
		//		{ 
		//			if(DB_error_code == DB_NOT_FOUND)
		//			{
		//				///SEC-0006 : 이 사용자는 존재하지 않읍니다. 다시 확인하여 주십시요.
		//				strcpy(s_msg_code, "SEC-0006");
		//				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//			}
		//			else
		//			{
		//				strcpy(s_msg_code, "SEC-0004"); 
		//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//				TRS.add_dberrmsg(out_node, DB_error_msg);
		//	
		//			}
		//			TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (1)", MP_NVST); 
		//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
		//			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
		//			TRS.add_dberrmsg(out_node, DB_error_msg);

		//			gs_log_type.type = MP_LOG_ERROR;
		//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//			gs_log_type.category = MP_LOG_CATE_SETUP;

		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		//			return MP_FALSE; 

		//		}

		//		///GCM GRADE별 권한 DATA 조회
		//		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		//		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		//		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_SL_MAPPING_PRV, strlen(HQCEL_M1_GCM_SL_MAPPING_PRV));
		//		memcpy(MGCMTBLDAT.KEY_1, MSECUSRDEF.USER_CMF_3, sizeof(MGCMTBLDAT.KEY_1));
		//		memcpy(MGCMTBLDAT.KEY_2, "FR", strlen("FR"));
		//		TRS.copy(MGCMTBLDAT.KEY_3, sizeof(MGCMTBLDAT.KEY_3), in_node, "FROM_OPER");
		//		DBC_select_mgcmtbldat(106, &MGCMTBLDAT);
		//		if(DB_error_code != DB_SUCCESS)
		//		{

		//			///부여된 권한으로 이동 요청 할 수 없는 GRADE 입니다.
		//			strcpy(s_msg_code, "GCM-0035");
		//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//			TRS.add_dberrmsg(out_node, DB_error_msg);
		//			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT(106)", MP_NVST);
		//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
		//			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
		//			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
		//			TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
		//			TRS.add_fieldmsg(out_node, "KEY_3", MP_STR, sizeof(MGCMTBLDAT.KEY_3), MGCMTBLDAT.KEY_3);
		//			TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(MGCMTBLDAT.DATA_1), MGCMTBLDAT.DATA_1);
		//			gs_log_type.type = MP_LOG_ERROR;
		//			gs_log_type.category = MP_LOG_CATE_TRANS;
		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		//			return MP_FALSE;
		//		
		//		} 
		//		///부여된 등급 권한이 있을경우
		//		if(COM_isnullspace(MGCMTBLDAT.DATA_1) == MP_FALSE)
		//		{
		//			if (memcmp(TRS.get_string(lot_list[i], "GRADE"), MGCMTBLDAT.DATA_1,strlen("XXX"))  != 0)
		//			{
		//				///부여된 권한으로 이동 요청 할 수 없는 GRADE 입니다.
		//				strcpy(s_msg_code, "GCM-0035");
		//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//				TRS.add_dberrmsg(out_node, DB_error_msg);
		//				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT(106)", MP_NVST);
		//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
		//				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
		//				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
		//				TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
		//				TRS.add_fieldmsg(out_node, "KEY_3", MP_STR, sizeof(MGCMTBLDAT.KEY_3), MGCMTBLDAT.KEY_3);
		//				TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(MGCMTBLDAT.DATA_1), MGCMTBLDAT.DATA_1);
		//				gs_log_type.type = MP_LOG_ERROR;
		//				gs_log_type.category = MP_LOG_CATE_TRANS;
		//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		//				return MP_FALSE;
		//			}
		//		}

		//
		//		
		//		if(MWIPLOTSTS.HOLD_FLAG == 'Y')
		//		{
		//			///WIP-0059 : 이 LOT은 HOLD 중입니다. RELEASE 후 사용 하세요.
		//			strcpy(s_msg_code, "WIP-0059");
		//			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
		//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
		//			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
		//			TRS.add_dberrmsg(out_node, DB_error_msg);

		//			gs_log_type.type = MP_LOG_ERROR;
		//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//			gs_log_type.category = MP_LOG_CATE_VIEW;


		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//			return MP_FALSE;
		//		}

		//		/*LOT HOLD*/
		//		Hold_Lot_In = TRS.create_node("HOLD_LOT_IN");
		//		TRS.add_char(Hold_Lot_In, IN_PROCSTEP, '1');
		//		TRS.add_enc_nstring(Hold_Lot_In, IN_USERID, TRS.get_userid(in_node));
		//		TRS.add_char(Hold_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
		//		TRS.add_nstring(Hold_Lot_In, IN_FACTORY, TRS.get_factory(in_node));
  // 
		//		TRS.set_string(Hold_Lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		//		TRS.set_int(Hold_Lot_In, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
		//		TRS.set_char(Hold_Lot_In, "END_FLAG", MWIPLOTSTS.END_FLAG);
		//		TRS.set_string(Hold_Lot_In, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		//		TRS.set_int(Hold_Lot_In, "MAT_VER", MWIPLOTSTS.MAT_VER);
		//		TRS.set_string(Hold_Lot_In, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		//		TRS.set_int(Hold_Lot_In, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		//		
		//		TRS.set_string(Hold_Lot_In, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		//		TRS.set_string(Hold_Lot_In, "HOLD_CODE", "REQ_MOVE", strlen("REQ_MOVE"));

		//		if(WIP_HOLD_LOT(s_msg_code, Hold_Lot_In, out_node) == MP_FALSE)
		//		{			
		//			TRS.free_node(Hold_Lot_In);
		//			return MP_FALSE;
		//		}
		//
		//		TRS.free_node(Hold_Lot_In);

		//		CDB_init_cwipreqdtl(&CWIPREQDTL);
		//		TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
		//		TRS.copy(CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO), in_node, "REQ_NO");
		//		memcpy(CWIPREQDTL.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CWIPREQDTL.LOT_ID));
		//		memcpy(CWIPREQDTL.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		//		TRS.copy(CWIPREQDTL.CREATE_USER_ID, sizeof(CWIPREQDTL.CREATE_USER_ID), in_node, IN_USERID);
		//		CDB_insert_cwipreqdtl(&CWIPREQDTL);
		//		if(DB_error_code != DB_SUCCESS)
		//		{ 
		//			strcpy(s_msg_code, "WIP-0004"); 
		//			TRS.add_fieldmsg(out_node, "CWIPREQDTL INSERT", MP_NVST); 
		//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY); 
		//			TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO); 
		//			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID); 
	
		//			TRS.add_dberrmsg(out_node, DB_error_msg);

		//			gs_log_type.type = MP_LOG_ERROR;
		//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//			gs_log_type.category = MP_LOG_CATE_SETUP;

		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		//			return MP_FALSE; 
		//		} 

		//		///IF 테이블
		//		CDB_init_iqcmsamdat(&IQCMSAMDAT);
		//		CDB_select_iqcmsamdat(2,&IQCMSAMDAT);
		//		if(DB_error_code != DB_SUCCESS)
		//		{ 
		//			strcpy(s_msg_code, "WIP-0004"); 
		//			TRS.add_fieldmsg(out_node, "IQCMSAMDAT SELECT(2)", MP_NVST); 
	
		//			TRS.add_dberrmsg(out_node, DB_error_msg);

		//			gs_log_type.type = MP_LOG_ERROR;
		//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//			gs_log_type.category = MP_LOG_CATE_SETUP;

		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		//			return MP_FALSE; 
		//		} 

		//		TRS.add_string(in_node, "DOC_ID", IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID));


		//		TRS.copy(IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID), in_node, "DOC_ID");
		//		memcpy(IQCMSAMDAT.SITE_ID, "P300", strlen("P300"));
		//		memcpy(IQCMSAMDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		//		memcpy(IQCMSAMDAT.ACTION_TYPE, "I", strlen("I"));
		//		memcpy(IQCMSAMDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		//		memcpy(IQCMSAMDAT.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		//		memcpy(IQCMSAMDAT.QC_INSPECTION, "Q", strlen("Q"));

		//		TRS.copy(IQCMSAMDAT.STORAGE_LOCATION, sizeof(IQCMSAMDAT.STORAGE_LOCATION), in_node, "TO_OPER");
		//		memcpy(IQCMSAMDAT.LOCATION, MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));


		//		TRS.copy(IQCMSAMDAT.QUALITY_GRADE, sizeof(IQCMSAMDAT.QUALITY_GRADE), in_node, "GRADE");
		//		TRS.copy(IQCMSAMDAT.POWER_GRADE, sizeof(IQCMSAMDAT.POWER_GRADE), in_node, "POWER");
		//		TRS.copy(IQCMSAMDAT.Z_GROUP, sizeof(IQCMSAMDAT.Z_GROUP), in_node, "REQ_NO");
		//		CDB_insert_iqcmsamdat(&IQCMSAMDAT);
		//		if(DB_error_code != DB_SUCCESS)
		//		{ 
		//			strcpy(s_msg_code, "WIP-0004"); 
		//			TRS.add_fieldmsg(out_node, "IQCMSAMDAT INSERT", MP_NVST); 
		//			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSAMDAT.DOC_ID), IQCMSAMDAT.DOC_ID); 
		//			TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSAMDAT.DOC_ID_R), IQCMSAMDAT.DOC_ID_R); 
	
		//			TRS.add_dberrmsg(out_node, DB_error_msg);

		//			gs_log_type.type = MP_LOG_ERROR;
		//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//			gs_log_type.category = MP_LOG_CATE_SETUP;

		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		//			return MP_FALSE; 
		//		}
		//	}
		//		
		//}
		
	}

	///이동 요청 Transation (원래 공정으로)
	else if(TRS.get_procstep(in_node) == '7')
	{
		i_list_count = TRS.get_item_count(in_node, "REQ_LOT_LIST");
		lot_list = TRS.get_list(in_node, "REQ_LOT_LIST");
		for( i = 0; i < i_list_count; i++)
		{
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
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
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			} 

			///HOLD 상태이면 RELEASE를 한다.
			if(MWIPLOTSTS.HOLD_FLAG == 'Y')
			{
				Release_Lot_In = TRS.create_node("RELEASE_LOT_IN");
				TRS.add_char(Release_Lot_In, IN_PROCSTEP, '1');
				TRS.add_enc_nstring(Release_Lot_In, IN_USERID, TRS.get_userid(in_node));
				TRS.add_char(Release_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
				
				TRS.set_string(Release_Lot_In, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				TRS.set_string(Release_Lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.set_int(Release_Lot_In, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

				TRS.set_string(Release_Lot_In, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.set_int(Release_Lot_In, "MAT_VER", MWIPLOTSTS.MAT_VER);
				TRS.set_string(Release_Lot_In, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.set_int(Release_Lot_In, "FLOW_SEQ_NO", MWIPLOTSTS.FLOW_SEQ_NUM);
				
				TRS.set_string(Release_Lot_In, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				TRS.set_string(Release_Lot_In, "RELEASE_CODE", "REQ_MOVE", strlen("REQ_MOVE"));
				TRS.set_char(Release_Lot_In, "END_FLAG", MWIPLOTSTS.END_FLAG);
				//TRS.set_nstring(Release_Lot_In, "COMMENT", "REQ_MOVE RELEASE");

				if(WIP_RELEASE_LOT(s_msg_code, Release_Lot_In, out_node) == MP_FALSE)
				{			
					TRS.free_node(Release_Lot_In);
					return MP_FALSE;
				}
		
				TRS.free_node(Release_Lot_In);
			}

			CDB_init_cwipreqmst(&CWIPREQMST);
			TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO), lot_list[i], "REQ_NO");
			CDB_select_cwipreqmst(1,&CWIPREQMST);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPREQMST SELECT(1)", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY); 
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

			///이동 요청 마스터 CLOSE
			memcpy(CWIPREQMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQMST.UPDATE_USER_ID, sizeof(CWIPREQMST.UPDATE_USER_ID), in_node, IN_USERID);
			CDB_update_cwipreqmst(2,&CWIPREQMST);
			if(DB_error_code != DB_SUCCESS)
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

			//TO 공정의 정의 조회
			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "TO_OPER");
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//To 공정이 창고 공정이면 Store 생산 공정이면 End 처리 한다.
			if (MWIPOPRDEF.INV_FLAG == 'Y') {

				/* STORE Lot */
				tran_in_node = TRS.create_node("STORE_LOT_IN");
				tran_out_node = TRS.create_node("STORE_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				TRS.add_nstring(tran_in_node, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));

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
			else {

				tran_in_node = TRS.create_node("END_LOT_IN");
				tran_out_node = TRS.create_node("END_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
				TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
				TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

				if (WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					TRS.clone(out_node, tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					return MP_FALSE;
				}

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
			}			

			///TRANSATION이 완료 되면 HIST_SEQ가 변경 되니 재조회 한다
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
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
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			} 


			///이동 요청 상세 HIST_SEQ UPDATE
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPREQDTL.REQ_NO, CWIPREQMST.REQ_NO, sizeof(CWIPREQDTL.REQ_NO));
			TRS.copy(CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID), lot_list[i], "LOT_ID");
			CWIPREQDTL.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ; 
			memcpy(CWIPREQDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQDTL.UPDATE_USER_ID, sizeof(CWIPREQDTL.UPDATE_USER_ID), in_node, IN_USERID);
			CDB_update_cwipreqdtl(2, &CWIPREQDTL);
			if(DB_error_code != DB_SUCCESS)
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

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

			///ERP IF
			CDB_init_iqcmsamdat(&IQCMSAMDAT);
			CDB_select_iqcmsamdat(2,&IQCMSAMDAT);
			if(DB_error_code != DB_SUCCESS)
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
			/*[GRTP PROJECT] 추가 */
			DBC_init_mwipordsts(&MWIPORDSTS);
			TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			DBC_select_mwipordsts(1, &MWIPORDSTS);
			/*[GRTP PROJECT] 끝 */

			TRS.add_string(in_node, "DOC_ID", IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID));

			TRS.copy(IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID), in_node, "DOC_ID");
			memcpy(IQCMSAMDAT.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
			memcpy(IQCMSAMDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(IQCMSAMDAT.ACTION_TYPE, "I", strlen("I"));
			memcpy(IQCMSAMDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(IQCMSAMDAT.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			memcpy(IQCMSAMDAT.QC_INSPECTION, "R", strlen("R"));

			TRS.copy(IQCMSAMDAT.STORAGE_LOCATION, sizeof(IQCMSAMDAT.STORAGE_LOCATION), in_node, "TO_OPER");
			memcpy(IQCMSAMDAT.LOCATION, MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));


			TRS.copy(IQCMSAMDAT.QUALITY_GRADE, sizeof(IQCMSAMDAT.QUALITY_GRADE), lot_list[i], "GRADE");
			TRS.copy(IQCMSAMDAT.POWER_GRADE, sizeof(IQCMSAMDAT.POWER_GRADE), lot_list[i], "POWER");
			TRS.copy(IQCMSAMDAT.Z_GROUP, sizeof(IQCMSAMDAT.Z_GROUP), lot_list[i], "REQ_NO");
			//memcpy(IQCMSAMDAT.ZPISTAT, "R", strlen("R"));
			IQCMSAMDAT.ZPISTAT = 'R';

			CDB_insert_iqcmsamdat(&IQCMSAMDAT);
			if(DB_error_code != DB_SUCCESS)
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
	///모듈 재공 반납에서 반납 리스트 조회
	else if(TRS.get_procstep(in_node) == '8')
	{
		CDB_init_cwipreqdtl(&CWIPREQDTL);
		TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO), in_node, "REQ_NO");

		CDB_open_cwipreqdtl(2, &CWIPREQDTL);
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
				TRS.add_fieldmsg(out_node, "CWIPREQDTL OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO);
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
			CDB_fetch_cwipreqdtl(2, &CWIPREQDTL);
			if (DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwipreqdtl(2);
				break;
			}
			else if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQDTL OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cwipreqdtl(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//Get Lot Data
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0044");
				TRS.add_fieldmsg(out_node, "FROM MODULE ID  ERROR", MP_NVST);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				CDB_close_cwipreqdtl(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//Get Oper Definition
			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPOPRDEF.OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0010");
				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				CDB_close_cwipreqdtl(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			/* Get material data */
			DBC_init_mwipmatdef(&MWIPMATDEF);
			TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPMATDEF.MAT_VER = 1;
			DBC_select_mwipmatdef(1, &MWIPMATDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					CDB_close_cwipreqdtl(2);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			//Get FQC Data
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, "FACTORY");
			memcpy(CEDCLOTRLT.INS_TYPE, "FC", strlen("FC"));
			memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_cedclotrlt(1, &CEDCLOTRLT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					CDB_close_cwipreqdtl(2);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			/*Get Port Data*/
			CDB_init_cwiptrphis(&CWIPTRPHIS);
			memcpy(CWIPTRPHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_cwiptrphis(2, &CWIPTRPHIS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPTRPHIS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPTRPHIS.LOT_ID), CWIPTRPHIS.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					CDB_close_cwipreqdtl(2);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			if(COM_isnullspace(CWIPTRPHIS.TRAN_TIME) != MP_TRUE){
				COM_diff_time_sec(&i_diff_sec, s_sys_time, CWIPTRPHIS.TRAN_TIME);
			}			

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
			TRS.add_string(list_item, "LINE", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
			TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
			TRS.add_string(list_item, "RES_ID", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));
			TRS.add_string(list_item, "PORT", CWIPTRPHIS.GRANDING_PORT_NO, sizeof(CWIPTRPHIS.GRANDING_PORT_NO));
			TRS.add_string(list_item, "TRAN_TIME", MWIPLOTSTS.LAST_TRAN_TIME, sizeof(MWIPLOTSTS.LAST_TRAN_TIME));
			TRS.add_string(list_item, "DT_TIME", MWIPLOTSTS.LOT_CMF_4, sizeof(MWIPLOTSTS.LOT_CMF_4));
			TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(list_item, "FQC_TIME", CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));
			TRS.add_string(list_item, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
			TRS.add_string(list_item, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
			TRS.add_string(list_item, "HOLD_CODE", MWIPLOTSTS.HOLD_CODE, sizeof(MWIPLOTSTS.HOLD_CODE));
			TRS.add_string(list_item, "REQ_NO", CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO));
		}
	}
	///이동 모듈 조회	
	else if (TRS.get_procstep(in_node) == '9')
	{
		i_list_count = TRS.get_item_count(in_node, "REQ_LOT_LIST");
		lot_list = TRS.get_list(in_node, "REQ_LOT_LIST");
		for (i = 0; i < i_list_count; i++)
		{
			// LOT ID 조회 
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');
					TRS.add_string(list_item, "ERR_DESC", "Module ID not found.", strlen("Module ID not found."));
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			//PACKING 여부 확인 
			CDB_init_cwiplotpak(&CWIPLOTPAK);
			TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CWIPLOTPAK.STATUS_FLAG = 'C';
			//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 이동 금지
			if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
			{
				list_item = TRS.add_node(out_node, "LIST");
				TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.add_char(list_item, "ERR_FLAG", 'Y');
				TRS.add_string(list_item, "ERR_DESC", "This module was already packed. Please check the module ID.", strlen("This module was already packed. Please check the module ID."));
				continue;
			}

			DBC_init_mwipmatdef(&MWIPMATDEF);
			TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPMATDEF.MAT_VER = 1;
			DBC_select_mwipmatdef(1, &MWIPMATDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');
					TRS.add_string(list_item, "ERR_DESC", "Material not found.", strlen("Module ID not found."));
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPOPRDEF.OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
					TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');
					TRS.add_string(list_item, "ERR_DESC", "Oper not found.", strlen("Oper not found."));
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
			TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));

			if (COM_isnullspace(TRS.get_string(lot_list[i], "TO_OPER")) == MP_FALSE)
			{
				CDB_init_cwipreqdtl(&CWIPREQDTL);
				TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID), lot_list[i], "LOT_ID");
				TRS.copy(CWIPREQDTL.REQ_DTL_CMF_1, sizeof(CWIPREQDTL.REQ_DTL_CMF_1), lot_list[i], "TO_OPER");
				CDB_select_cwipreqdtl(4, &CWIPREQDTL);
				if (DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{
						//list_item = TRS.add_node(out_node, "LIST");
						//TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						TRS.add_string(list_item, "TO_OPER", CWIPREQDTL.REQ_DTL_CMF_1, sizeof(CWIPREQDTL.REQ_DTL_CMF_1));
						TRS.add_char(list_item, "ERR_FLAG", 'Y');
						TRS.add_string(list_item, "ERR_DESC", "Module ID not found in the to operation.", strlen("Module ID not found in the to operation."));
						continue;
					}
					else
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_dberrmsg(out_node, DB_error_msg);
						TRS.add_fieldmsg(out_node, "CWIPREQDTL SELECT(4)", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				else
				{
					TRS.add_string(list_item, "REQ_NO", CWIPREQDTL.REQ_DTL_CMF_1, sizeof(CWIPREQDTL.REQ_DTL_CMF_1));
					TRS.add_string(list_item, "REQ_DATE", CWIPREQDTL.REQ_DTL_CMF_2, sizeof(CWIPREQDTL.REQ_DTL_CMF_2));
					TRS.add_string(list_item, "REQ_TIME", CWIPREQDTL.REQ_DTL_CMF_3, sizeof(CWIPREQDTL.REQ_DTL_CMF_3));
					TRS.add_string(list_item, "FROM_OPER", CWIPREQDTL.REQ_DTL_CMF_4, sizeof(CWIPREQDTL.REQ_DTL_CMF_4));
					TRS.add_string(list_item, "FROM_OPER_DESC", CWIPREQDTL.REQ_DTL_CMF_5, sizeof(CWIPREQDTL.REQ_DTL_CMF_5));
				}
			}

			/*
			CDB_init_cwiptrphis(&CWIPTRPHIS);
			memcpy(CWIPTRPHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_cwiptrphis(2, &CWIPTRPHIS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPTRPHIS SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPTRPHIS.LOT_ID), CWIPTRPHIS.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "GRADE", CWIPTRPHIS.CMF_4, sizeof(CWIPTRPHIS.CMF_4));
				TRS.add_string(list_item, "POWER", CWIPTRPHIS.CMF_5, sizeof(CWIPTRPHIS.CMF_5));
			}
			*/
			//CEDCLOTRLT
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
			else
			{
				//23.06.21 Pallet 적재 후 FQC 진행가능.. 
				/*
				if (COM_isnullspace(CWIPTRPHIS.CMF_4) == MP_TRUE)
				{
					TRS.set_string(list_item, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
				}
				if (COM_isnullspace(CWIPTRPHIS.CMF_5) == MP_TRUE)
				{
					TRS.set_string(list_item, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
				}*/
				TRS.add_string(list_item, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
				TRS.add_string(list_item, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
			
			}

			/*이동 확인이 아니고 HOLD */
			if (TRS.get_char(in_node, "RECV_OPER") != 'Y' && MWIPLOTSTS.HOLD_FLAG == 'Y')
			{
				TRS.add_char(list_item, "ERR_FLAG", 'Y');
				TRS.add_string(list_item, "ERR_DESC", "This lot is on hold. Release it first.", strlen("This lot is on hold. Release it first."));
			}

			if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
			{
				TRS.add_char(list_item, "ERR_FLAG", 'Y');
				TRS.add_string(list_item, "ERR_DESC", "This lot is on terminate.", strlen("This lot is on terminate."));
			}
		}
	}
	// 이동 확인시 요청 리스트 조회 
	else if (TRS.get_procstep(in_node) == 'A')
	{
		CDB_init_cwipreqmst(&CWIPREQMST);
		TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPREQMST.TO_OPER, sizeof(CWIPREQMST.TO_OPER), in_node, "TO_OPER");
		TRS.copy(CWIPREQMST.REQ_CMF_1, sizeof(CWIPREQMST.REQ_CMF_1), in_node, "GRADE");
		TRS.copy(CWIPREQMST.REQ_CMF_2, sizeof(CWIPREQMST.REQ_CMF_2), in_node, "POWER");
		TRS.copy(CWIPREQMST.REQ_CMF_3, sizeof(CWIPREQMST.REQ_CMF_3), in_node, "LOT_ID");
		TRS.copy(CWIPREQMST.REQ_CMF_4, sizeof(CWIPREQMST.REQ_CMF_4), in_node, "FROM_DATE");

		CDB_open_cwipreqmst(3, &CWIPREQMST);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPREQMST OPEN(2)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
			TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(CWIPREQMST.FROM_OPER), CWIPREQMST.FROM_OPER);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		while (1)
		{
			CDB_fetch_cwipreqmst(3, &CWIPREQMST);
			if (DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwipreqmst(3);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				break;
			}
			else if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQMST FETCH(2)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
				TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(CWIPREQMST.FROM_OPER), CWIPREQMST.FROM_OPER);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				CDB_close_cwipreqmst(3);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			
			CDB_init_cwipreqdtl(&CWIPREQDTL);
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPREQDTL.REQ_NO, CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO));
			CDB_select_cwipreqdtl(3, &CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQDTL SELECT(3)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				CDB_close_cwipreqmst(3);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			CDB_init_cwiplotpak(&CWIPLOTPAK);
			TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPLOTPAK.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID));
			CWIPLOTPAK.STATUS_FLAG = 'C';
			//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈 조회 x
			if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
			{
				continue;
			}

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "REQ_NO", CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO));
			TRS.add_string(list_item, "REQ_DATE", CWIPREQMST.REQ_DATE, sizeof(CWIPREQMST.REQ_DATE));
			TRS.add_string(list_item, "LOT_ID", CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID));

			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY));
			memcpy(CEDCLOTRLT.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID));
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
					CDB_close_cwipreqmst(3);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
				TRS.add_string(list_item, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
			}

			TRS.add_string(list_item, "REQ_STATUS", CWIPREQMST.REQ_STATUS, sizeof(CWIPREQMST.REQ_STATUS));
			TRS.add_string(list_item, "FROM_OPER", CWIPREQMST.FROM_OPER, sizeof(CWIPREQMST.FROM_OPER));
			TRS.add_string(list_item, "FROM_OPER_DESC", CWIPREQMST.REQ_CMF_1, sizeof(CWIPREQMST.REQ_CMF_1));
			TRS.add_string(list_item, "TO_OPER", CWIPREQMST.TO_OPER, sizeof(CWIPREQMST.TO_OPER));
			TRS.add_string(list_item, "TO_OPER_DESC", CWIPREQMST.REQ_CMF_2, sizeof(CWIPREQMST.REQ_CMF_2));
			TRS.add_string(list_item, "REQ_TIME", CWIPREQMST.REQ_TIME, sizeof(CWIPREQMST.REQ_TIME));
			TRS.add_string(list_item, "REQ_USER_ID", CWIPREQMST.REQ_USER_ID, sizeof(CWIPREQMST.REQ_USER_ID));
			TRS.add_string(list_item, "REQ_USER_DESC", CWIPREQMST.REQ_CMF_3, sizeof(CWIPREQMST.REQ_CMF_3));
			TRS.add_string(list_item, "REQ_QTY", CWIPREQMST.REQ_CMF_4, sizeof(CWIPREQMST.REQ_CMF_4));
		}
	}
	// 이동 확인시 요청 리스트 LOT 
	else if (TRS.get_procstep(in_node) == 'B')
	{
		i_list_count = TRS.get_item_count(in_node, "REQ_LOT_LIST");
		lot_list = TRS.get_list(in_node, "REQ_LOT_LIST");
		for (i = 0; i < i_list_count; i++)
		{
			// LOT ID 조회 
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');
					TRS.add_string(list_item, "ERR_DESC", "Module ID not found.", strlen("Module ID not found."));
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			DBC_init_mwipmatdef(&MWIPMATDEF);
			TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPMATDEF.MAT_VER = 1;
			DBC_select_mwipmatdef(1, &MWIPMATDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');
					TRS.add_string(list_item, "ERR_DESC", "Material not found.", strlen("Module ID not found."));
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPOPRDEF.OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
					TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');
					TRS.add_string(list_item, "ERR_DESC", "Oper not found.", strlen("Oper not found."));
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			CDB_init_cwipreqdtl(&CWIPREQDTL);
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID), lot_list[i], "LOT_ID");
			TRS.copy(CWIPREQDTL.REQ_DTL_CMF_1, sizeof(CWIPREQDTL.REQ_DTL_CMF_1), lot_list[i], "TO_OPER");
			memcpy(CWIPREQDTL.REQ_DTL_CMF_2, "R", strlen("R")); // R : OQC 반납 요청 제외
			CDB_select_cwipreqdtl(6, &CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "TO_OPER", CWIPREQDTL.REQ_DTL_CMF_1, sizeof(CWIPREQDTL.REQ_DTL_CMF_1));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');
					TRS.add_string(list_item, "ERR_DESC", "Module ID not found in the to operation.", strlen("Module ID not found in the to operation."));
					continue;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					TRS.add_fieldmsg(out_node, "CWIPREQDTL SELECT(4)", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
			TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
			TRS.add_string(list_item, "REQ_NO", CWIPREQDTL.REQ_DTL_CMF_1, sizeof(CWIPREQDTL.REQ_DTL_CMF_1));
			TRS.add_string(list_item, "REQ_DATE", CWIPREQDTL.REQ_DTL_CMF_2, sizeof(CWIPREQDTL.REQ_DTL_CMF_2));
			TRS.add_string(list_item, "REQ_TIME", CWIPREQDTL.REQ_DTL_CMF_3, sizeof(CWIPREQDTL.REQ_DTL_CMF_3));
			TRS.add_string(list_item, "FROM_OPER", CWIPREQDTL.REQ_DTL_CMF_4, sizeof(CWIPREQDTL.REQ_DTL_CMF_4));
			TRS.add_string(list_item, "FROM_OPER_DESC", CWIPREQDTL.REQ_DTL_CMF_5, sizeof(CWIPREQDTL.REQ_DTL_CMF_5));

			/*
			CDB_init_cwiptrphis(&CWIPTRPHIS);
			memcpy(CWIPTRPHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_cwiptrphis(2, &CWIPTRPHIS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPTRPHIS SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPTRPHIS.LOT_ID), CWIPTRPHIS.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "GRADE", CWIPTRPHIS.CMF_4, sizeof(CWIPTRPHIS.CMF_4));
				TRS.add_string(list_item, "POWER", CWIPTRPHIS.CMF_5, sizeof(CWIPTRPHIS.CMF_5));
			}
			*/
			//CEDCLOTRLT
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
			else
			{
				//23.06.21 Pallet 적재 후 FQC 진행가능.. 
				/*
				if (COM_isnullspace(CWIPTRPHIS.CMF_4) == MP_TRUE)
				{
					memcpy(CWIPTRPHIS.CMF_4, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
				}
				if (COM_isnullspace(CWIPTRPHIS.CMF_5) == MP_TRUE)
				{
					memcpy(CWIPTRPHIS.CMF_5, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
				}
				*/
				TRS.add_string(list_item, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
				TRS.add_string(list_item, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
			}

			if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
			{
				TRS.add_char(list_item, "ERR_FLAG", 'Y');
				TRS.add_string(list_item, "ERR_DESC", "This lot is on terminate.", strlen("This lot is on terminate."));
			}
		}
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Port_Operation_List_Validation()
		- Main sub function of "CWIP_View_Port_Operation_list" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Port_Operation_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123456789AB") == MP_FALSE)
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
