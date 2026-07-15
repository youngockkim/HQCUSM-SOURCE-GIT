/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_resource_event.c
    Description : EAPMES Collect Resource Event Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Resource_Event()
            + Setup service interface function
        - EAPMES_COLLECT_RESOURCE_EVENT()
            + Main sub function of EAPMES_Collect_Resource_Event function
            + Setup service main business function
        - EAPMES_Collect_Resource_Event_Validation()
            + Main sub function of EAPMES_COLLECT_RESOURCE_EVENT function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_COLLECT_RESOURCE_EVENT()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Resource_Event_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Resource_Event()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Resource_Event(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_RESOURCE_EVENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_RESOURCE_EVENT", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

    /* Temp */
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "EVENT_NAME", TRS.get_string(in_node, "EVENT_NAME"));


	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Resource_Event", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    //CEIS_Save_Message_Log(in_node, out_node);
    CEIS_Save_Message_Log_For_List(in_node, out_node);


	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_RESOURCE_EVENT()
        - Main sub function of "EAPMES_Collect_Resource_Event" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_RESOURCE_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASLOTMOV_TAG CRASLOTMOV;

	char s_sys_time_stamp[20];
	char s_sys_time[17];
	char s_actual_time[15];
	struct worktime_tag cur_work_time;
	int i_step  = 2;
	int tan_seq = 0;
	
    LOG_head("EAPMES_COLLECT_RESOURCE_EVENT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Collect_Resource_Event_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  

    DB_get_systime_m(s_sys_time_stamp);
    if(DB_error_code != DB_SUCCESS)
    {
        TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash 초기화 되지 않은 변수
	memcpy(s_actual_time, s_sys_time_stamp, sizeof(s_actual_time));
		/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

    /* To Do 
	1. 모듈기준 CEID(배출 211)별 이력 확인 
	1.1 존재하면 현시점기록 하며 TRAN_SEQ 증가.
	1.2 신규 이면 TRAN_SEQ = 1 로 기록
	*/

	/* 1. 모듈기준 CEID별 이력 확인 */
	CDB_init_craslotmov(&CRASLOTMOV);
	TRS.copy(CRASLOTMOV.FACTORY, sizeof(CRASLOTMOV.FACTORY), in_node, "FACTORY");
	TRS.copy(CRASLOTMOV.RES_ID, sizeof(CRASLOTMOV.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASLOTMOV.CEID, sizeof(CRASLOTMOV.CEID), in_node, "CEID");
	TRS.copy(CRASLOTMOV.LOT_ID, sizeof(CRASLOTMOV.LOT_ID), in_node, "LOT_ID");
	
	tan_seq = CDB_select_craslotmov_scalar(i_step, &CRASLOTMOV) + 1;
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			//nothing
		}
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CRASLOTMOV SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASLOTMOV.FACTORY), CRASLOTMOV.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CRASLOTMOV.LOT_ID), CRASLOTMOV.LOT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}

	memcpy(CRASLOTMOV.WORK_DATE, cur_work_time.work_date, sizeof(CRASLOTMOV.WORK_DATE));
	memcpy(CRASLOTMOV.CREATE_TIME, s_actual_time, sizeof(CRASLOTMOV.CREATE_TIME));
	CRASLOTMOV.TRAN_SEQ = tan_seq;

	CDB_insert_craslotmov(&CRASLOTMOV);
	if(DB_error_code != DB_SUCCESS)
	{
                
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Resource_Event_Validation()
        - Main sub function of "EAPMES_COLLECT_RESOURCE_EVENT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Resource_Event_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASLOTMOV_TAG CRASLOTMOV;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
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

    CDB_init_craslotmov(&CRASLOTMOV);
    TRS.copy(CRASLOTMOV.CEID, sizeof(CRASLOTMOV.CEID), in_node, "CEID");
	TRS.copy(CRASLOTMOV.RES_ID, sizeof(CRASLOTMOV.RES_ID), in_node, "RES_ID");
    CRASLOTMOV.CEID[3] = 0;
	
	//투입일경우는 210 PCV-08 에서만 처리함
	if(strcmp(CRASLOTMOV.CEID, "210") == 0) 
	{
		if(strcmp(CRASLOTMOV.RES_ID, "US-E1-PCV-08") == 0)
		{
			return MP_TRUE;
		}
		if(strcmp(CRASLOTMOV.RES_ID, "US-E2-PCV-08") == 0)
		{
			return MP_TRUE;
		}
		if(strcmp(CRASLOTMOV.RES_ID, "US-E3-PCV-08") == 0)
		{
			return MP_TRUE;
		}

		return MP_FALSE;
	}
	
	//배출일경우는 211 PCV-08 에서만 처리함
	if(strcmp(CRASLOTMOV.CEID, "211") == 0) 
	{
		if(memcmp(CRASLOTMOV.RES_ID, "US-E1-PCV-03", strlen("US-E1-PCV-03") ) == 0)
		{
			return MP_TRUE;
		}
		if(memcmp(CRASLOTMOV.RES_ID, "US-E2-PCV-03", strlen("US-E2-PCV-03")) == 0)
		{
			return MP_TRUE;
		}
		if(memcmp(CRASLOTMOV.RES_ID, "US-E3-PCV-03", strlen("US-E3-PCV-03")) == 0)
		{
			return MP_TRUE;
		}
		if(memcmp(CRASLOTMOV.RES_ID, "US-E1-PCV-02", strlen("US-E1-PCV-02")) == 0)
		{
			return MP_TRUE;
		}
		if(memcmp(CRASLOTMOV.RES_ID, "US-E2-PCV-02", strlen("US-E2-PCV-02")) == 0)
		{
			return MP_TRUE;
		}
		if(memcmp(CRASLOTMOV.RES_ID, "US-E3-PCV-02", strlen("US-E3-PCV-02")) == 0)
		{
			return MP_TRUE;
		}
		return MP_FALSE;
	}

	/* Module Validation */

	/* EQ Validation*/

    if (strcmp(CRASLOTMOV.CEID, "210") != 0 && strcmp(CRASLOTMOV.CEID, "211") != 0) 
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

