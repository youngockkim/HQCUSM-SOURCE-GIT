/*******************************************************************************

	System      : MESplus
	Module      : Update Tray 
	File Name   : CWIP_Update_Tray_Management.c

	MES Version : 5.0

	Function View
		-

	Detail Description
		-

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2020.01.15  Hyunjun.Jo

	Copyright(C) 1998-2008 Miracom,Inc.
	All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_UPDATE_TRAY_MANAGEMENT(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node);


/*******************************************************************************
	CWIP_View_Tray()
		- View Tray
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Tray_Management(TRSNode* in_node, TRSNode* out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret = MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_TRAY_MANAGEMENT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_Update_Tray_Management", out_node);

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
	CWIP_UPDATE_TRAY_MANAGEMENT()
		- UPDATE TRAY
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- char *s_msg_code : Error Msg Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_TRAY_MANAGEMENT(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	// INIT
	struct CWIPTRYSTS_TAG CWIPTRYSTS;
	struct CWIPTRYHIS_TAG CWIPTRYHIS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CWIPTRYUSH_TAG CWIPTRYUSH;

	char s_sys_time[14];

	int i_diff_sec;
	//char msg[256], sec[6];
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
	//TRSNode *list_item;

	//int i_step;

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_TRAY_MANAGEMENT");
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


	if (TRS.get_procstep(in_node) == '1')
	{

		CDB_init_cwiptrysts(&CWIPTRYSTS);
		TRS.copy(CWIPTRYSTS.FACTORY, sizeof(CWIPTRYSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID), in_node, "TRAY_ID");

		// SELECT Master Table
		CDB_select_cwiptrysts(1, &CWIPTRYSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPTRYSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYSTS.TRAY_ID), CWIPTRYSTS.TRAY_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		

		CDB_init_cwiptryhis(&CWIPTRYHIS);
		TRS.copy(CWIPTRYHIS.FACTORY, sizeof(CWIPTRYHIS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPTRYHIS.TRAY_ID, sizeof(CWIPTRYHIS.TRAY_ID), in_node, "TRAY_ID");
		CWIPTRYHIS.SEQ = CWIPTRYSTS.SEQ;

		CDB_select_cwiptryhis(1, &CWIPTRYHIS);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPTRYHIS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS.TRAY_ID), CWIPTRYHIS.TRAY_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// data set
		TRS.add_string(out_node, "TRAY_ID", CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID));
		TRS.add_string(out_node, "USER_ID", CWIPTRYHIS.USER_ID, sizeof(CWIPTRYHIS.USER_ID));
		TRS.add_string(out_node, "START_TIME", CWIPTRYHIS.START_TIME, sizeof(CWIPTRYHIS.START_TIME));
		if (memcmp(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT)) == 0)
		{
			TRS.add_string(out_node, "ENT_TIME", " ", sizeof(" "));
		}
		else
		{
			TRS.add_string(out_node, "ENT_TIME", CWIPTRYHIS.END_TIME, sizeof(CWIPTRYHIS.END_TIME));
		}
	}
	else if (TRS.get_procstep(in_node) == '2')
	{

		CDB_init_cwiptrysts(&CWIPTRYSTS);
		TRS.copy(CWIPTRYSTS.FACTORY, sizeof(CWIPTRYSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID), in_node, "TRAY_ID");


		// SELECT Master Table
		CDB_select_cwiptrysts(1, &CWIPTRYSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPTRYSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS.TRAY_ID), CWIPTRYHIS.TRAY_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
			//NOTHING
		}


		/*CDB_init_cwiptryhis(&CWIPTRYHIS);
		TRS.copy(CWIPTRYHIS.FACTORY, sizeof(CWIPTRYHIS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPTRYHIS.TRAY_ID, sizeof(CWIPTRYHIS.TRAY_ID), in_node, "TRAY_ID");
		CWIPTRYHIS.SEQ = CWIPTRYSTS.SEQ;*/

		CDB_init_cwiptryush(&CWIPTRYUSH);
		TRS.copy(CWIPTRYUSH.FACTORY, sizeof(CWIPTRYUSH.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPTRYUSH.TRAY_ID, sizeof(CWIPTRYUSH.TRAY_ID), in_node, "TRAY_ID");
		CWIPTRYUSH.SEQ = (int)CDB_select_cwiptryush_scalar(2, &CWIPTRYUSH);;
		CDB_select_cwiptryush(1, &CWIPTRYUSH);
		if (DB_error_code != DB_SUCCESS)
		{
			// Master Table 에 등록된 Tray가 없으면 insert
			if (DB_error_code == DB_NOT_FOUND)
			{
				CWIPTRYUSH.SEQ = 1;
				TRS.copy(CWIPTRYUSH.USER_ID, sizeof(CWIPTRYUSH.USER_ID), in_node, "USER_ID");
				TRS.copy(CWIPTRYUSH.RES_ID, sizeof(CWIPTRYUSH.RES_ID), in_node, "RES_ID");
				TRS.copy(CWIPTRYUSH.TRAY_TYPE, sizeof(CWIPTRYUSH.TRAY_TYPE), in_node, "TRAY_TYPE");
				TRS.copy(CWIPTRYUSH.CREATE_USER_ID, sizeof(CWIPTRYUSH.CREATE_USER_ID), in_node, "USERID");
				memcpy(CWIPTRYUSH.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

				CDB_insert_cwiptryush(&CWIPTRYUSH);
			}
		}
		else
		{
			CWIPTRYUSH.SEQ++;
			TRS.copy(CWIPTRYUSH.USER_ID, sizeof(CWIPTRYUSH.USER_ID), in_node, "USER_ID");
			TRS.copy(CWIPTRYUSH.RES_ID, sizeof(CWIPTRYUSH.RES_ID), in_node, "RES_ID");
			TRS.copy(CWIPTRYUSH.TRAY_TYPE, sizeof(CWIPTRYUSH.TRAY_TYPE), in_node, "TRAY_TYPE");
			TRS.copy(CWIPTRYUSH.CREATE_USER_ID, sizeof(CWIPTRYUSH.CREATE_USER_ID), in_node, "USERID");
			memcpy(CWIPTRYUSH.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			CDB_insert_cwiptryush(&CWIPTRYUSH);
		}

		// data set
		TRS.add_string(out_node, "TRAY_ID", CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID));
		TRS.add_string(out_node, "USER_ID", CWIPTRYUSH.USER_ID, sizeof(CWIPTRYUSH.USER_ID));
		TRS.add_string(out_node, "START_TIME", CWIPTRYUSH.CREATE_TIME, sizeof(CWIPTRYUSH.CREATE_TIME));
		TRS.add_string(out_node, "ENT_TIME", s_sys_time, sizeof(s_sys_time));
		
	}


	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}