/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_raise_alarm.c
    Description : EAPMES Raise Alarm Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Raise_Alarm()
            + Setup service interface function
        - EAPMES_RAISE_ALARM()
            + Main sub function of EAPMES_Raise_Alarm function
            + Setup service main business function
        - EAPMES_Raise_Alarm_Validation()
            + Main sub function of EAPMES_RAISE_ALARM function
    Detail Description
        - EAPMES_RAISE_ALARM()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "ALMCore_common.h"


int EAPMES_Raise_Alarm_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Raise_Alarm()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Raise_Alarm(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_RAISE_ALARM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_RAISE_ALARM", out_node);

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
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */



	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	/**
	if(CallService(MODULE_EAP, 
		"MESEAP_Raise_Alarm", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}
	**/

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
    EAPMES_RAISE_ALARM()
        - Main sub function of "EAPMES_Raise_Alarm" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_RAISE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	TRSNode	*action_in;	

	char s_tmpstr[200];
	struct MALMMSGDEF_TAG MALMMSGDEF;
	char c_level_flag;

	// IS-21-10-051 1초 이내 같은 알람 발생 시 MES 내 처리 로직 개발
	struct MALMMSGHIS_TAG MALMMSGHIS;
	char s_sys_time[14];

    LOG_head("EAPMES_RAISE_ALARM");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Raise_Alarm_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// IS-21-10-051 1초 이내 같은 알람 발생 시 MES 내 처리 로직 개발
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
        return MP_FALSE;
    }

    /* To Do */

	/*********************************************************************/
	/* 2. 장비 알람
	// 장비 ALARM 은 등록된 알람과 등록되지 않은 알람이 있으므로
	// - 알람 ID 를 장비 ID 로 해서 발생함 ( 사용자 지정가능  - 장비별 사용자 지정가능 ) (Normal Alarm 으로 등록)
	// - 알람 등록은 ( 설비 알람으로 등록 )
	*********************************************************************/
	memset(s_tmpstr, '\0', sizeof(s_tmpstr));

	//현재 등록된 ALARM ID 를 찿음
	DBC_init_malmmsgdef(&MALMMSGDEF);
	TRS.copy(MALMMSGDEF.FACTORY, sizeof(MALMMSGDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MALMMSGDEF.ALARM_ID, sizeof(MALMMSGDEF.ALARM_ID), in_node, "RES_ID");
	DBC_select_malmmsgdef(1, &MALMMSGDEF);
	if(DB_error_code != DB_SUCCESS)
	{         
		//ALARM ID 자동 INSERT 할려면 아래 쿼리 진행 
		/***
		INSERT INTO MALMMSGDEF(FACTORY, ALARM_ID, ALARM_DESC, ALARM_TYPE, ALARM_LEVEL_FLAG , ALARM_SUBJECT, ALARM_MSG_1, ALARM_MSG_2, ALARM_MSG_3 )
		SELECT FACTORY, RES_ID, RES_DESC, 'R', 'I', '-', '-','-','-' FROM MRASRESDEF
		WHERE ALARM_TYPE = 'R' AND ROWNUM = 1
		AND FACTORY = 'USGAM1';
		***/
	}

	if (strcmp(TRS.get_string(in_node, "ALCD"),"1") == 0)
		c_level_flag = 'W'; // 경알람
	else if (strcmp(TRS.get_string(in_node, "ALCD"),"2") == 0)
		c_level_flag = 'E'; // 중알람
	else
		c_level_flag = 'I'; // Information

	if (COM_isnullspace(TRS.get_string(in_node, "ALTX")) == MP_FALSE)
	{         
		//설비에서  알람 메세지를 준경우 제목  [ 장비 ID ] - [W(경알람) or E(중알람)] ALARM ID : Alarm Message 로 표시함
		//sprintf(s_tmpstr, "[%s]-[%c]%s : %s", TRS.get_string(in_node, "RES_ID"),c_level_flag, TRS.get_string(in_node, "ALID"),  TRS.get_string(in_node, "ALTX"));

		// 20210810 MES Application Memory leak 점검 및 수정
		// memcpy 메모리 침범 수정
		_snprintf_s(s_tmpstr, _countof(s_tmpstr), _countof(s_tmpstr)-1, "[%s]-[%c]%s : %s", TRS.get_string(in_node, "RES_ID"),c_level_flag, TRS.get_string(in_node, "ALID"),  TRS.get_string(in_node, "ALTX"));
	}
	else
	{
		//등록되지 않은 알람 메세지 일경우 처리 제목  [ 장비 ID ] - ALARM ID : Alarm Messagew
		//sprintf(s_tmpstr, "[%s]-[%c]%s : %s", TRS.get_string(in_node, "RES_ID"),c_level_flag, TRS.get_string(in_node, "ALID"),  " No Alarm Message");

		// 20210810 MES Application Memory leak 점검 및 수정
		// memcpy 메모리 침범 수정
		_snprintf_s(s_tmpstr, _countof(s_tmpstr), _countof(s_tmpstr)-1, "[%s]-[%c]%s : %s", TRS.get_string(in_node, "RES_ID"),c_level_flag, TRS.get_string(in_node, "ALID"),  " No Alarm Message");
	}
		
	//Alarm Transcation 발생 (Raise Alarm) 
	action_in = TRS.create_node("ACTION_IN");
	CCOM_copy_in_node(in_node, action_in);

	TRS.set_string(action_in, IN_FACTORY, MALMMSGDEF.FACTORY, sizeof(MALMMSGDEF.FACTORY));
	TRS.set_char(action_in, IN_PROCSTEP, '1');
	TRS.set_nstring(action_in, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	TRS.set_nstring(action_in, "ALARM_ID", TRS.get_string(in_node, "RES_ID"));
	TRS.set_nstring(action_in, "ALARM_SUBJECT", s_tmpstr);
	TRS.set_nstring(action_in, "ALARM_MSG", s_tmpstr);
	TRS.set_nstring(action_in, "SOURCE_ID_1", TRS.get_string(in_node,"ALID"));
	TRS.set_nstring(action_in, "SOURCE_ID_2", TRS.get_string(in_node, "ALCD"));

	// IS-21-10-051 1초 이내 같은 알람 발생 시 MES 내 처리 로직 개발
	DBC_init_malmmsghis(&MALMMSGHIS);
	TRS.copy(MALMMSGHIS.FACTORY, sizeof(MALMMSGHIS.FACTORY), in_node, "FACTORY");
	TRS.copy(MALMMSGHIS.ALARM_ID, sizeof(MALMMSGHIS.ALARM_ID), in_node, "RES_ID");
	TRS.copy(MALMMSGHIS.RES_ID, sizeof(MALMMSGHIS.ALARM_ID), in_node, "RES_ID");
	TRS.copy(MALMMSGHIS.SOURCE_ID_1, sizeof(MALMMSGHIS.SOURCE_ID_1), in_node, "ALID");
	TRS.copy(MALMMSGHIS.SOURCE_ID_2, sizeof(MALMMSGHIS.SOURCE_ID_2), in_node, "ALCD");
	memcpy(MALMMSGHIS.TRAN_TIME, s_sys_time, sizeof(MALMMSGHIS.TRAN_TIME));

	DBC_select_malmmsghis(1, &MALMMSGHIS);

	if(DB_error_code != DB_SUCCESS)
	{
		if(ALM_RAISE_ALARM(s_msg_code, action_in, out_node) == MP_FALSE)
		{
			//DO NOTHING
		}
	}
	else
	{
		// 로그 추가
		LOG_head("EAPMES_Raise_Alarm_Duplication");
		LOG_add("FACTORY", MP_NSTR, TRS.get_factory(in_node));
		LOG_add("ALARM_ID", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
		LOG_add("RES_ID", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
		LOG_add("SOURCE_ID_1", MP_NSTR, TRS.get_string(in_node, "ALID"));
		LOG_add("SOURCE_ID_2", MP_NSTR, TRS.get_string(in_node, "ALCD"));
		LOG_add("TRAN_TIME", MP_STR, sizeof(MALMMSGHIS.TRAN_TIME), MALMMSGHIS.TRAN_TIME);
		COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);
	}

		
	//if(ALM_RAISE_ALARM(s_msg_code, action_in, out_node) == MP_FALSE)
	//{
	//	//DO NOTHING
	//}
		

	TRS.free_node(action_in);
		
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Raise_Alarm_Validation()
        - Main sub function of "EAPMES_RAISE_ALARM" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Raise_Alarm_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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

