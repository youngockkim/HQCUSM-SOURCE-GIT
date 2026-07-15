/*******************************************************************************

    System      : MESplus
    Module      : View Tray
    File Name   : CWIP_view_tray.c

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

int CWIP_VIEW_TRAY(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Tray()
        - View Tray 
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Tray(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_TRAY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Tray", out_node);

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
    CWIP_VIEW_TRAY()
        - VIEW TRAY
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_TRAY(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPTRYSTS_TAG CWIPTRYSTS;
	struct CWIPTRYHIS_TAG CWIPTRYHIS;
	struct CWIPTRYHIS_TAG CWIPTRYHIS_CUR;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CWIPTRYEXT_TAG CWIPTRYEXT;
	char s_sys_time[14];

	int i_diff_sec;
	char msg[256], sec[6];
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
	//TRSNode *list_item;
	
    //int i_step;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_TRAY");
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

	// Master Table select
    // i_step = 1;

	CDB_init_cwiptrysts(&CWIPTRYSTS);
	TRS.copy(CWIPTRYSTS.FACTORY, sizeof(CWIPTRYSTS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID), in_node, "TRAY_ID");
	

	// SELECT Master Table
	CDB_select_cwiptrysts(1, &CWIPTRYSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		// Master Table 에 등록된 Tray가 없으면 insert
		if(DB_error_code == DB_NOT_FOUND)
		{
			CWIPTRYSTS.SEQ = 1;
			memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
			TRS.copy(CWIPTRYSTS.CREATE_USER_ID, sizeof(CWIPTRYSTS.CREATE_USER_ID), in_node, "USERID");
			memcpy(CWIPTRYSTS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(CWIPTRYSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

			CDB_insert_cwiptrysts(&CWIPTRYSTS);
		}
	}
	else
	{
		// 투입(I) 상태이면 SEQ 증가, STATUS 변경
		if(memcmp(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT)) == 0)
		{
			CWIPTRYSTS.SEQ++;
			memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
			TRS.copy(CWIPTRYSTS.UPDATE_USER_ID, sizeof(CWIPTRYSTS.UPDATE_USER_ID), in_node, "USERID");
			memcpy(CWIPTRYSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

			CDB_update_cwiptrysts(1, &CWIPTRYSTS);
		}
		else if(memcmp(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_END, strlen(HQCEL_M1_TRAY_STATUS_END)) == 0)
		{//투입(I) 상태가 아니지만, 트레이가 올라온 경우 GCM 시간 설정 값에 따라 히스토리 추가 또는 Warnning 메세지 여부 결정

			//GCM 시간 설정값 조회
			struct MGCMTBLDAT_TAG MGCMTBLDAT;
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			memcpy(MGCMTBLDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT.TABLE_NAME, "@REPAIR_STRING", strlen("@REPAIR_STRING"));
			memcpy(MGCMTBLDAT.KEY_1, "REPAIR_TRAY_PERIOD", strlen("REPAIR_TRAY_PERIOD"));
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "BAS-9999");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			i_diff_sec = 0;
			COM_diff_time_sec(&i_diff_sec, s_sys_time, CWIPTRYSTS.UPDATE_TIME);
			if( i_diff_sec > COM_atoi(MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1)))
			{
				CWIPTRYSTS.SEQ++;
				memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
				TRS.copy(CWIPTRYSTS.UPDATE_USER_ID, sizeof(CWIPTRYSTS.UPDATE_USER_ID), in_node, "USERID");
				memcpy(CWIPTRYSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

				CDB_update_cwiptrysts(1, &CWIPTRYSTS);
			}
			else
			{
				//Warnning 메세지 보내기.
				//memset(msg, 0, 256);
				//memset(sec, 0, 6);
				//COM_itoa(sec, i_diff_sec, sizeof(i_diff_sec));
				//sprintf(msg, "Tray was not inserted after %s sec.", sec);
				//TRS.add_msgcate(out_node, MP_MSG_CATE_WARN);
				//TRS.add_msgcode(out_node, "TRAY-001");
				//TRS.add_message(out_node, msg);
			}

		}

	}
	
	CDB_init_cwiptryhis(&CWIPTRYHIS_CUR);
    TRS.copy(CWIPTRYHIS_CUR.FACTORY, sizeof(CWIPTRYHIS_CUR.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPTRYHIS_CUR.TRAY_ID, sizeof(CWIPTRYHIS_CUR.TRAY_ID), in_node, "TRAY_ID");
	CWIPTRYHIS_CUR.SEQ = CWIPTRYSTS.SEQ;

	CDB_select_cwiptryhis(1, &CWIPTRYHIS_CUR);
	if(DB_error_code != DB_SUCCESS)
	{
		// History Table 에 등록된 Tray 와 SEQ 가 없으면 START 상태로 insert
		if(DB_error_code == DB_NOT_FOUND)
		{
			memcpy(CWIPTRYHIS_CUR.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
			memcpy(CWIPTRYHIS_CUR.START_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPTRYHIS_CUR.CREATE_USER_ID, sizeof(CWIPTRYHIS_CUR.CREATE_USER_ID), in_node, "USERID");
			memcpy(CWIPTRYHIS_CUR.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

			CDB_insert_cwiptryhis(&CWIPTRYHIS_CUR);
		}
		else
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
	}

	//VOC-5516 Management String Repair 확장 테이블 추가에 따른 수정(2023/1/24)
	CDB_init_cwiptryext(&CWIPTRYEXT);
    TRS.copy(CWIPTRYEXT.FACTORY, sizeof(CWIPTRYEXT.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPTRYEXT.TRAY_ID, sizeof(CWIPTRYEXT.TRAY_ID), in_node, "TRAY_ID");
	CWIPTRYEXT.SEQ = CWIPTRYSTS.SEQ;

	CDB_select_cwiptryext(1, &CWIPTRYEXT);
	if(DB_error_code != DB_SUCCESS)
	{
		// Master Table 에 등록된 Tray가 없으면 return
		if(DB_error_code == DB_NOT_FOUND)
		{
			memcpy(CWIPTRYEXT.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
			memcpy(CWIPTRYEXT.START_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPTRYEXT.CREATE_USER_ID, sizeof(CWIPTRYEXT.CREATE_USER_ID), in_node, "USERID");
			memcpy(CWIPTRYEXT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPTRYEXT.LINE_ID, sizeof(CWIPTRYEXT.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CWIPTRYEXT.USER_ID, sizeof(CWIPTRYEXT.USER_ID), in_node, "USER_ID");
			
			CDB_insert_cwiptryext(&CWIPTRYEXT);

		} else {
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPTRYHIS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYEXT.TRAY_ID), CWIPTRYEXT.TRAY_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}


	// Repairman
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(CWIPTRYSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@WORKER_MASTER", sizeof("@WORKER_MASTER"));
	memcpy(MGCMLAGDAT.KEY_1, CWIPTRYHIS_CUR.USER_ID, sizeof(CWIPTRYHIS_CUR.USER_ID));

	DBC_select_mgcmlagdat(2, &MGCMLAGDAT);
	
	// data set
	TRS.add_string(out_node, "TRAY_ID", CWIPTRYHIS_CUR.TRAY_ID, sizeof(CWIPTRYHIS_CUR.TRAY_ID));
    TRS.add_string(out_node, "USER_ID", CWIPTRYHIS_CUR.USER_ID, sizeof(CWIPTRYHIS_CUR.USER_ID));
	TRS.add_string(out_node, "USER_NAME", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
    TRS.add_int(out_node, "REPAIR_QTY", CWIPTRYHIS_CUR.REPAIR_QTY);
	TRS.add_string(out_node, "START_TIME", CWIPTRYHIS_CUR.START_TIME, sizeof(CWIPTRYHIS_CUR.START_TIME));
    TRS.add_string(out_node, "ENT_TIME", CWIPTRYHIS_CUR.END_TIME, sizeof(CWIPTRYHIS_CUR.END_TIME));

	// Tray History
/*
	CDB_init_cwiptryhis(&CWIPTRYHIS);
    TRS.copy(CWIPTRYHIS.FACTORY, sizeof(CWIPTRYHIS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPTRYHIS.TRAY_ID, sizeof(CWIPTRYHIS.TRAY_ID), in_node, "TRAY_ID");

	CDB_open_cwiptryhis(101, &CWIPTRYHIS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			
		}
		else
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
	}

	// FETCH
	while(1)
	{
		CDB_fetch_cwiptryhis(101, &CWIPTRYHIS);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_cwiptryhis(101);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTRYHIS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS.TRAY_ID), CWIPTRYHIS.TRAY_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_cwiptryhis(101);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "VIEW_TRAYHIS_OUT");
		TRS.add_int(list_item, "SEQ", CWIPTRYHIS.SEQ);
        //TRS.add_string(list_item, "USER_ID", CWIPTRYHIS.USER_ID, sizeof(CWIPTRYHIS.USER_ID));
		TRS.add_string(list_item, "RES_ID", CWIPTRYHIS.RES_ID, sizeof(CWIPTRYHIS.RES_ID));
		TRS.add_int(list_item, "REPAIR_QTY", CWIPTRYHIS.REPAIR_QTY);
		TRS.add_int(list_item, "INPUT_QTY", CWIPTRYHIS.INPUT_QTY);
		TRS.add_string(list_item, "ORDER_ID", CWIPTRYHIS.ORDER_ID, sizeof(CWIPTRYHIS.ORDER_ID));
        TRS.add_string(list_item, "START_TIME", CWIPTRYHIS.START_TIME, sizeof(CWIPTRYHIS.START_TIME));
        TRS.add_string(list_item, "ENT_TIME", CWIPTRYHIS.END_TIME, sizeof(CWIPTRYHIS.END_TIME));
        TRS.add_string(list_item, "INPUT_TIME", CWIPTRYHIS.INPUT_TIME, sizeof(CWIPTRYHIS.INPUT_TIME));
	}
*/

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}