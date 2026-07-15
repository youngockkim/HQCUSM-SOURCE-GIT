/*******************************************************************************

    System      : MESplus
    Module      : Update Tray
    File Name   : CWIP_update_tray.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.01.17  Hyunjun.Jo

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_UPDATE_TRAY(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Update_Tray()
        - View FQC List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Tray(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_TRAY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_update_tray", out_node);

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
    CWIP_update_tray()
        - Update Tray
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_TRAY(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPTRYSTS_TAG CWIPTRYSTS;
	struct CWIPTRYHIS_TAG CWIPTRYHIS_CUR;
	struct CWIPTRYEXT_TAG CWIPTRYEXT;

	char s_sys_time[14];

	
    int i_step;

	// PROCESS LOG PRINT
	LOG_head("CWIP_update_tray");
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

	if (TRS.get_procstep(in_node) == '2')
    {
        i_step = 2;
    }
    else
    {
        i_step = 1;
    }
	

	// Master Table select
	CDB_init_cwiptrysts(&CWIPTRYSTS);
	TRS.copy(CWIPTRYSTS.FACTORY, sizeof(CWIPTRYSTS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID), in_node, "TRAY_ID");
	
	CDB_select_cwiptrysts(1, &CWIPTRYSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		// Master Table 에 등록된 Tray가 없으면 return
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPTRYHIS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS_CUR.TRAY_ID), CWIPTRYHIS_CUR.TRAY_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}
	}


	CDB_init_cwiptryhis(&CWIPTRYHIS_CUR);
    TRS.copy(CWIPTRYHIS_CUR.FACTORY, sizeof(CWIPTRYHIS_CUR.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPTRYHIS_CUR.TRAY_ID, sizeof(CWIPTRYHIS_CUR.TRAY_ID), in_node, "TRAY_ID");
	CWIPTRYHIS_CUR.SEQ = CWIPTRYSTS.SEQ;

	CDB_select_cwiptryhis(1, &CWIPTRYHIS_CUR);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPTRYHIS OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS_CUR.TRAY_ID), CWIPTRYHIS_CUR.TRAY_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	
	//VOC-5516 Management String Repair 확장 테이블 추가에 따른 수정(2023/1/24)
	CDB_init_cwiptryext(&CWIPTRYEXT);
    TRS.copy(CWIPTRYEXT.FACTORY, sizeof(CWIPTRYEXT.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPTRYEXT.TRAY_ID, sizeof(CWIPTRYEXT.TRAY_ID), in_node, "TRAY_ID");
	CWIPTRYEXT.SEQ = CWIPTRYSTS.SEQ;

	CDB_select_cwiptryext(1, &CWIPTRYEXT);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPTRYEXT OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYEXT.TRAY_ID), CWIPTRYEXT.TRAY_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	
	if(i_step == 2)
	{
		// Restart 버튼 클릭 시 Start 상태로 변경
		memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
		TRS.copy(CWIPTRYSTS.UPDATE_USER_ID, sizeof(CWIPTRYSTS.UPDATE_USER_ID), in_node, "USERID");
		memcpy(CWIPTRYSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

		CDB_update_cwiptrysts(1, &CWIPTRYSTS);

		// Restart 버튼 클릭 시 Start 상태로 변경
		//VOC-5516 Management String Repair 확장 테이블 추가에 따른 수정(2023/1/24)
		memcpy(CWIPTRYEXT.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
		TRS.copy(CWIPTRYEXT.UPDATE_USER_ID, sizeof(CWIPTRYEXT.UPDATE_USER_ID), in_node, "USERID");
		memcpy(CWIPTRYEXT.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
		CWIPTRYEXT.REPAIR_QTY = 0;
		CWIPTRYEXT.INPUT_QTY = 0;
		memcpy(CWIPTRYEXT.START_TIME, s_sys_time, sizeof(s_sys_time));
		memset(CWIPTRYEXT.END_TIME, 0x00, sizeof(CWIPTRYEXT.END_TIME));
		memset(CWIPTRYEXT.INPUT_TIME, 0x00, sizeof(CWIPTRYEXT.INPUT_TIME));
		memset(CWIPTRYEXT.ORDER_ID, 0x00, sizeof(CWIPTRYEXT.ORDER_ID));

		// History 테이블 초기화
		memcpy(CWIPTRYHIS_CUR.STATUS, HQCEL_M1_TRAY_STATUS_START, strlen(HQCEL_M1_TRAY_STATUS_START));
		memset(CWIPTRYHIS_CUR.RES_ID, 0x00, sizeof(CWIPTRYHIS_CUR.RES_ID));
		memset(CWIPTRYHIS_CUR.USER_ID, 0x00, sizeof(CWIPTRYHIS_CUR.USER_ID));
		CWIPTRYHIS_CUR.REPAIR_QTY = 0;
		CWIPTRYHIS_CUR.INPUT_QTY = 0;
		memcpy(CWIPTRYHIS_CUR.START_TIME, s_sys_time, sizeof(s_sys_time));
		memset(CWIPTRYHIS_CUR.END_TIME, 0x00, sizeof(CWIPTRYHIS_CUR.END_TIME));
		memset(CWIPTRYHIS_CUR.INPUT_TIME, 0x00, sizeof(CWIPTRYHIS_CUR.INPUT_TIME));
		memset(CWIPTRYHIS_CUR.ORDER_ID, 0x00, sizeof(CWIPTRYHIS_CUR.ORDER_ID));
	} 
	else
	{
		memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_END, strlen(HQCEL_M1_TRAY_STATUS_END));
		TRS.copy(CWIPTRYSTS.UPDATE_USER_ID, sizeof(CWIPTRYSTS.UPDATE_USER_ID), in_node, "USERID");
		memcpy(CWIPTRYSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
		CDB_update_cwiptrysts(1, &CWIPTRYSTS);

		TRS.copy(CWIPTRYEXT.LINE_ID, sizeof(CWIPTRYEXT.LINE_ID), in_node, "LINE_ID");
		memcpy(CWIPTRYEXT.STATUS, HQCEL_M1_TRAY_STATUS_END, strlen(HQCEL_M1_TRAY_STATUS_END));
		CWIPTRYEXT.REPAIR_QTY = TRS.get_int(in_node, "REPAIR_QTY");
		memcpy(CWIPTRYEXT.END_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CWIPTRYEXT.USER_ID, sizeof(CWIPTRYEXT.USER_ID), in_node, "USER_ID");

		CWIPTRYHIS_CUR.REPAIR_QTY = TRS.get_int(in_node, "REPAIR_QTY");	
		memcpy(CWIPTRYHIS_CUR.END_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CWIPTRYHIS_CUR.USER_ID, sizeof(CWIPTRYHIS_CUR.USER_ID), in_node, "USER_ID");
		memcpy(CWIPTRYHIS_CUR.STATUS, HQCEL_M1_TRAY_STATUS_END, strlen(HQCEL_M1_TRAY_STATUS_END));
	}

	TRS.copy(CWIPTRYHIS_CUR.UPDATE_USER_ID, sizeof(CWIPTRYHIS_CUR.UPDATE_USER_ID), in_node, "USERID");
	memcpy(CWIPTRYHIS_CUR.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));	

	CDB_update_cwiptryhis(1, &CWIPTRYHIS_CUR);

	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPTRYHIS OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS_CUR.TRAY_ID), CWIPTRYHIS_CUR.TRAY_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	
	//VOC-5516 Management String Repair 확장 테이블 추가에 따른 수정(2023/1/24)
	TRS.copy(CWIPTRYEXT.UPDATE_USER_ID, sizeof(CWIPTRYEXT.UPDATE_USER_ID), in_node, "USERID");
	memcpy(CWIPTRYEXT.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));	
	CDB_update_cwiptryext(1, &CWIPTRYEXT);

	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");

		TRS.add_fieldmsg(out_node, "CWIPTRYEXT OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYEXT.TRAY_ID), CWIPTRYEXT.TRAY_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}