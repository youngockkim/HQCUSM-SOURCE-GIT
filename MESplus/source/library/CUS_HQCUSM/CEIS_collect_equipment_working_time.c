/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_equipment_working_time.c
    Description : 

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Equipment_Working_time()
            + Setup service interface function
        - EAPMES_COLLECT_EQUIPMENT_WORKING_TIME()
            + Main sub function of EAPMES_Collect_Equipment_Working_time function
            + Setup service main business function
    Detail Description
        - EAPMES_COLLECT_EQUIPMENT_WORKING_TIME()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019/07/19  sy7.kwon       Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    EAPMES_Collect_Equipment_Working_time()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Equipment_Working_Time(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_EQUIPMENT_WORKING_TIME(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_EQUIPMENT_WORKING_TIME", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log : CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_EQUIPMENT_WORKING_TIME()
        - Main sub function of "EAPMES_Collect_Equipment_Working_time" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_EQUIPMENT_WORKING_TIME(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
    struct CRASWRKTIM_TAG CRASWRKTIM;

	char   s_sys_time_17[17];
	double d_work_time;

	// in_node 값 로그 작성
    LOG_head("EAPMES_COLLECT_EQUIPMENT_WORKING_TIME");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_sys_time_17, ' ', sizeof(s_sys_time_17));
	if(COM_isnullspace(TRS.get_string(in_node, "CLIENT_TIME")) == MP_FALSE)
	{
		TRS.copy(s_sys_time_17, sizeof(s_sys_time_17), in_node, "CLIENT_TIME");
		s_sys_time_17[16] = '0';
	}
	else
	{
		return MP_TRUE;
	}
	
    // 1. 설비 ID 확인
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "RAS-0003");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}

	// 2. 도착 시간이 없는 데이터 확인
	CDB_init_craswrktim(&CRASWRKTIM);
	TRS.copy(CRASWRKTIM.FACTORY, sizeof(CRASWRKTIM.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CRASWRKTIM.RES_ID, sizeof(CRASWRKTIM.RES_ID), in_node, "RES_ID");
	CDB_select_craswrktim(2, &CRASWRKTIM);

	// 3. 컨베이어 출발/도착에 따라 데이터 처리
	// 3-1. PROCSTEP = 1 : 컨베이어 투입 (출발)
	if(TRS.get_char(in_node, "PROCSTEP") == '1')
	{
		// 3-1-1. DB에 도착시간이 없는 데이터가 없으면 신규 출발 시간 데이터 Insert
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_init_craswrktim(&CRASWRKTIM);
			TRS.copy(CRASWRKTIM.FACTORY, sizeof(CRASWRKTIM.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CRASWRKTIM.RES_ID, sizeof(CRASWRKTIM.RES_ID), in_node, "RES_ID");
			memcpy(CRASWRKTIM.TRAN_TIME, s_sys_time_17, sizeof(CRASWRKTIM.TRAN_TIME));
			memcpy(CRASWRKTIM.ARRIVAL_TIME, s_sys_time_17, sizeof(CRASWRKTIM.ARRIVAL_TIME));
			CDB_insert_craswrktim(&CRASWRKTIM);
			if(DB_error_code != DB_SUCCESS)
			{

			}
		}
		// 3-1-2. DB에 도착시간이 없는 데이터가 있으면 기존 데이터에 update
		//		  (출발시간은 도착시간이 없으면 계속 update해줌)
		else if(DB_error_code == DB_SUCCESS)
		{
			memcpy(CRASWRKTIM.ARRIVAL_TIME, s_sys_time_17, sizeof(CRASWRKTIM.ARRIVAL_TIME));
			CDB_update_craswrktim(1, &CRASWRKTIM);
			if(DB_error_code != DB_SUCCESS)
			{

			}
		}
		else
		{

		}
	}
	// 3-2.PROCSTEP =  2 : 컨베이어 종료 (도착)
	else if(TRS.get_char(in_node, "PROCSTEP") == '2')
	{
		// 3-2-1. 도착시간이 없는 데이터가 있으면 도착시간 및 working time(초) 계산해서 update
		if(DB_error_code == DB_SUCCESS)
		{
			memcpy(CRASWRKTIM.DEPARTURE_TIME, s_sys_time_17, sizeof(CRASWRKTIM.DEPARTURE_TIME));
			COM_diff_time_millisec(&d_work_time, CRASWRKTIM.DEPARTURE_TIME, CRASWRKTIM.ARRIVAL_TIME);
			CRASWRKTIM.WORK_TIME = d_work_time;
			CDB_update_craswrktim(1, &CRASWRKTIM);
			if(DB_error_code != DB_SUCCESS)
			{

			}
		}
		// 3-2-2. 도착시간이 없는 데이터가 없으면 그 메시지는 처리하지 않음
		else
		{

		}
	}
	
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}