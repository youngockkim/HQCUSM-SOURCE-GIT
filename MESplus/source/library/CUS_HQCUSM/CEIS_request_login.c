/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_request_login.c
    Description : EAPMES Request Login Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Request_Login()
            + Setup service interface function
        - EAPMES_REQUEST_LOGIN()
            + Main sub function of EAPMES_Request_Login function
            + Setup service main business function
        - EAPMES_Request_Login_Validation()
            + Main sub function of EAPMES_REQUEST_LOGIN function
    Detail Description
        - EAPMES_REQUEST_LOGIN()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Request_Login_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Request_Login()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Request_Login(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_REQUEST_LOGIN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_REQUEST_LOGIN", out_node);

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
    //COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));


    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

	LOG_head("EAPMES_REQUEST_LOGIN");
    TRS.log_add_all_members(out_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Request_Login", 
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
    EAPMES_REQUEST_LOGIN()
        - Main sub function of "EAPMES_Request_Login" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_REQUEST_LOGIN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
 	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    struct MGCMTBLDAT_TAG MGCMTBLDAT_A;
    struct CWIPUSRLOG_TAG CWIPUSRLOG;
    struct MRASRESDEF_TAG MRASRESDEF;

	char input_type = ' ';
    char   s_sys_time[14];
    
    int SIZE_OF_ID = 8; // Login ID size;
//    int i = 0;

    LOG_head("EAPMES_REQUEST_LOGIN");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Request_Login_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

	input_type = TRS.get_char(in_node,"INPUT_TYPE");
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
    TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
    memcpy(MGCMLAGDAT.TABLE_NAME, "@USER_GRADE", strlen("@USER_GRADE"));
    
    //memset(MGCMLAGDAT.KEY_1, ' ', sizeof(MGCMLAGDAT.KEY_1));
	TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1) ,in_node, "INPUT_CODE");
    
    /*
    for(i = 0; i < sizeof(MGCMLAGDAT.KEY_1); i++)
    {
        if( MGCMLAGDAT.KEY_1[i] == ' ')
        {
            SIZE_OF_ID = i;
            break;
        }
    }
    */
    
    MGCMLAGDAT.KEY_1[SIZE_OF_ID] = '\0';
	/*
	if(input_type == '1') // 1 : IC
	{
		MGCMLAGDAT.KEY_1[8] = '\0';
	}
	else  // 2 : 사번
	{
		MGCMLAGDAT.KEY_1[5] = 0;
	}
    */
    //Insert User Id regardless of the result.
    TRS.add_string(out_node, "USER_ID", MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1));

    DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        //send user level 1 if validation failed.
        TRS.add_char(out_node, "USER_LEVEL", '1');

        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "GCM-0008");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        else
        {
            strcpy(s_msg_code, "GCM-0004");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    //설비아이디 확인 Eagle1,2 구분 Validation((2023.12.28 kim han chang)
    DBC_init_mrasresdef(&MRASRESDEF);
    memcpy(MRASRESDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
    TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");

    DBC_select_mrasresdef(1, &MRASRESDEF);
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF select", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        return MP_FALSE;
    }

    DBC_init_mgcmtbldat(&MGCMTBLDAT_A);
    TRS.copy(MGCMTBLDAT_A.FACTORY, sizeof(MGCMTBLDAT_A.FACTORY), in_node, "FACTORY");
    memcpy(MGCMTBLDAT_A.TABLE_NAME, "@LINE_CODE", strlen("@LINE_CODE"));
    memcpy(MGCMTBLDAT_A.KEY_1, MRASRESDEF.RES_CMF_1, sizeof(MGCMTBLDAT_A.KEY_1));
     
    DBC_select_mgcmtbldat(1, &MGCMTBLDAT_A);
    if (DB_error_code != DB_SUCCESS) 
    {
        if (DB_error_code != DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "GCM-0004");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT_A.FACTORY), MGCMTBLDAT_A.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT_A.TABLE_NAME), MGCMTBLDAT_A.TABLE_NAME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else
    {
        //REID 요청 이글 구분 VALIDATION  E1 과 EGL1 를 비교
        if (memcmp(MGCMTBLDAT_A.DATA_7, HQCEL_M1_EAGLE_01, strlen(HQCEL_M1_EAGLE_01)) == 0)
        {
            if (memcmp(MGCMLAGDAT.DATA_6, "EGL1", strlen("EGL1")) != 0)
            {
                strcpy(s_msg_code, "EIS-0007");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT_A.FACTORY), MGCMTBLDAT_A.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT_A.TABLE_NAME), MGCMTBLDAT_A.TABLE_NAME);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

        }
        //REID 요청 이글 구분 VALIDATION  E2 과 EGL2 를 비교
        if (memcmp(MGCMTBLDAT_A.DATA_7, HQCEL_M1_EAGLE_02, strlen(HQCEL_M1_EAGLE_02)) == 0)
        {
            if (memcmp(MGCMLAGDAT.DATA_6, "EGL2", strlen("EGL2")) != 0)
            {
                strcpy(s_msg_code, "EIS-0007");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT_A.FACTORY), MGCMTBLDAT_A.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT_A.TABLE_NAME), MGCMTBLDAT_A.TABLE_NAME);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

        }
    }

	//2023.12.11 레벨 디스크립션을 User ID에 리턴하기로 함===> 주석된 부분은 이글2/3은 반영되었으나 이글1은 반영안된 부분임 일단 주석으로 처리함
/*	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
    memcpy(MGCMTBLDAT.TABLE_NAME, "@USER_GRADE_DESC", strlen("@USER_GRADE_DESC"));
	MGCMTBLDAT.KEY_1[0] = MGCMLAGDAT.DATA_1[0];
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "GCM-0008");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
			TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        else
        {
            strcpy(s_msg_code, "GCM-0004");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }*/
	TRS.add_string(out_node, "USER_ID", MGCMLAGDAT.KEY_1,sizeof(MGCMLAGDAT.KEY_1));
	TRS.add_char(out_node, "USER_LEVEL",MGCMLAGDAT.DATA_1[0]);

	//ISSUE-11-023	MES에서 RFID 카드 적용 시 로그 기록
	CDB_init_cwipusrlog(&CWIPUSRLOG);

	TRS.copy(CWIPUSRLOG.FACTORY, sizeof(CWIPUSRLOG.FACTORY), in_node, IN_FACTORY);
	memcpy(CWIPUSRLOG.TRAN_TIME, s_sys_time, sizeof(CWIPUSRLOG.TRAN_TIME));
	TRS.copy(CWIPUSRLOG.RES_ID , sizeof(CWIPUSRLOG.RES_ID) ,in_node, "RES_ID"); // EQ ID
	TRS.copy(CWIPUSRLOG.LINE_ID , sizeof(CWIPUSRLOG.LINE_ID) ,in_node, "LINE_ID"); // EQ ID
	TRS.copy(CWIPUSRLOG.CARD_ID , sizeof(CWIPUSRLOG.CARD_ID) ,in_node, "INPUT_CODE"); // RFID ID
	memcpy(CWIPUSRLOG.GRADE, MGCMLAGDAT.DATA_1, sizeof(CWIPUSRLOG.GRADE)); //User Level
	memcpy(CWIPUSRLOG.FULL_CARD_ID, MGCMLAGDAT.DATA_2, sizeof(CWIPUSRLOG.FULL_CARD_ID)); //Full Card Id

	CDB_insert_cwipusrlog(&CWIPUSRLOG);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO Nothing
	}
	
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Request_Login_Validation()
        - Main sub function of "EAPMES_REQUEST_LOGIN" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Request_Login_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
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

    return MP_TRUE;
}
