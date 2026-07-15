/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_change_resource_state.c
    Description : EAPMES Change Resource State Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Change_Resource_State()
            + Setup service interface function
        - EAPMES_CHANGE_RESOURCE_STATE()
            + Main sub function of EAPMES_Change_Resource_State function
            + Setup service main business function
        - EAPMES_Change_Resource_State_Validation()
            + Main sub function of EAPMES_CHANGE_RESOURCE_STATE function
    Detail Description
        - EAPMES_CHANGE_RESOURCE_STATE()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/
#include "CUS_common.h"
#include "CUS_HQCUSM_common.h"

#include <MESCore_common.h>
#include "ACTCore_common.h"

int EAPMES_Change_Resource_State_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Change_Resource_State()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Change_Resource_State(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_CHANGE_RESOURCE_STATE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_CHANGE_RESOURCE_STATE", out_node);

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
		"MESEAP_Change_Resource_State", 
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
    EAPMES_CHANGE_RESOURCE_STATE()
        - Main sub function of "EAPMES_Change_Resource_State" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_CHANGE_RESOURCE_STATE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
	struct RSUMRESDWH_TAG RSUMRESDWH;
	struct MWIPCALDEF_TAG MWIPCALDEF;
	/*
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	
	struct CALMTLGHIS_TAG CALMTLGHIS;
	*/
    char s_sys_time_stamp[20];  
    char s_sys_time[17];
	char s_actual_time[15];
	/*
	char message[130];
	*/
    struct worktime_tag cur_work_time;
	/*
	char *resId = (char*)malloc(sizeof(char) * (12 + 1));
	char *statusCode = (char*)malloc(sizeof(char) * (2 + 1));
	char *eqpStatus = (char*)malloc(sizeof(char) * (50 + 1));
	*/
	TRSNode* tran_in_node;
    TRSNode* tran_out_node;  


	/* Lot Information */
    LOG_head("EAPMES_CHANGE_RESOURCE_STATE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Change_Resource_State_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

    
	//CLIENT_TIME»ç¿ëÇÒ°æ¿ì
	/*
	TRS.copy(s_sys_time, strlen("2019021610471455"), in_node, "CLIENT_TIME");
	if (COM_isspace(s_sys_time, strlen("2019021610471455")) == MP_TRUE)
	{
		memset(s_sys_time, ' ', sizeof(s_sys_time));
		memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));
		memcpy(s_actual_time, s_sys_time_stamp, sizeof(s_actual_time));
	}
	else
	{
		TRS.copy(s_actual_time, sizeof(s_actual_time), in_node, "CLIENT_TIME");
	}
	*/
	//¼­¹ö½Ã°£À» »ç¿ëÇÒ°æ¿ì
	
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, s_sys_time_stamp, sizeof(s_actual_time));
	

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);
	/* cueernt shift */
	//c_shift = CCOM_get_work_shift(s_actual_time);
	
	//0. ¼³ºñ ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//EQP ALIVE TELEGRAM ALARM
	//기준정보에서 포트정보 가져오기.
	/*
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "@EQP_STATUS", strlen("@EQP_STATUS"));
	TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "CURR_STATE_CODE");

	DBC_select_mgcmtbldat(2, &MGCMTBLDAT);
	
	strncpy(statusCode, MGCMTBLDAT.KEY_1, 2);
	statusCode[2] = 0x00;
	strncpy(eqpStatus, MGCMTBLDAT.DATA_1, 50);
	eqpStatus[50] = 0x00;
	
	CDB_init_calmtlghis(&CALMTLGHIS);
	memcpy(CALMTLGHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CALMTLGHIS.NOTIFY_SYSTEM, "HQcellUS_EQ_ALIVE", strlen("HQcellUS_EQ_ALIVE"));
	memcpy(CALMTLGHIS.TRAN_TIME, s_sys_time, sizeof(CALMTLGHIS.TRAN_TIME));
	TRS.copy(CALMTLGHIS.CMF_1, sizeof(CALMTLGHIS.CMF_1), in_node, "RES_ID");

	
	strncpy(resId, TRS.get_string(in_node, "RES_ID"), 12);
	resId[12] = 0x00;
	
	sprintf(message , "The status of the equipment has changed. \n-RES_ID : %s \n-Code%s : %s" , resId, statusCode, eqpStatus);
	memcpy(CALMTLGHIS.NOTIFY_MESSAGE, message, sizeof(message));

	CDB_insert_calmtlghis(&CALMTLGHIS); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "ALM-0004"); 
		TRS.add_fieldmsg(out_node, "CALMTLGHIS INSERT", MP_NVST); 
		TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CALMTLGHIS.SEQ_NUM); 
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALMTLGHIS.FACTORY), CALMTLGHIS.FACTORY); 
		TRS.add_fieldmsg(out_node, "NOTIFY_SYSTEM", MP_STR, sizeof(CALMTLGHIS.NOTIFY_SYSTEM), CALMTLGHIS.NOTIFY_SYSTEM); 
		TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CALMTLGHIS.TRAN_TIME), CALMTLGHIS.TRAN_TIME); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	
	free(resId);
	free(statusCode);
	free(eqpStatus);
	*/
	//RESOURCE  EVNET
	tran_in_node = TRS.create_node("TRAN_IN");
    tran_out_node = TRS.create_node("TRAN_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
    TRS.add_char(tran_in_node, "PROCSTEP", '1');
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	TRS.add_nstring(tran_in_node, "EVENT_ID", HQCEL_M1_EVENT_EQ_CHGSTATUS); // ¼³ºñ »óÅÂº¯°æ EVENT

	TRS.add_nstring(tran_in_node, "CHG_PRI_STS", TRS.get_string(in_node, "CURR_STATE_ACRO")); //PRIMARY STATUS

	//STATUS_3 : SATUS CODE 
	//10 : RUN, 20 :No WIP, 22 : Kaban Full @RES_STATE ÇÏ°í ¾È¸Â´Âµ¥ ÀÏ´Ü µ¥ÀÌÅÍ¹Þ¾Æº½. GCMÀº ÀÌÈÄ¿¡
	TRS.add_nstring(tran_in_node, "CHG_STS_3", TRS.get_string(in_node, "CURR_STATE_CODE"));

	//STATUS_4 : SATUS GROUP CODE ..GCM°ú EVENT Àº ÀÌÈÄ¿¡ ¼ÂÆÃ
	//1 : RUN , 2 : NO wip, 3 EE, EO, EP,  4, Order Change 5-> DOWN °ü·ÃÄÚµå
	TRS.add_nstring(tran_in_node, "CHG_STS_4", TRS.get_string(in_node, "CURR_STATE_GROUP")); 

	//CLIENT TIME
	TRS.add_nstring(tran_in_node, "CHG_STS_5", TRS.get_string(in_node, "CLIENT_TIME")); 

	//SUB RES ID
	TRS.add_nstring(tran_in_node, "CHG_STS_6", TRS.get_string(in_node, "SUB_RES_ID")); 

	//UP/DOWN Àº EVENT ¹Þ¾Æº¸°í EVENT ºÐ¸®ÇÏ¿© °è»ê 5¹ø¸¸ DOWNÀÎÁö? UP/DOWN Á¤ÀÇÇÊ¿ä

	TRS.add_string(tran_in_node, "TRAN_CMF_1",s_sys_time_stamp, sizeof(s_sys_time_stamp));  //SYSTEM TIME
	TRS.add_nstring(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "ALID"));  //AL ID
	TRS.add_nstring(tran_in_node, "TRAN_CMF_3", TRS.get_string(in_node, "ALCD"));  //AL CD
	TRS.add_nstring(tran_in_node, "TRAN_CMF_4", TRS.get_string(in_node, "ALTX"));  //AL TX

	
	if(RAS_RESOURCE_EVENT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
        //TRS.init_node(out_node);
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        TRS.free_node(tran_in_node);
        TRS.free_node(tran_out_node);
		return MP_FALSE;
	}

    TRS.free_node(tran_in_node);
    TRS.free_node(tran_out_node);


    /***************************************************************************/
	/* FMB ¿¡°Ô ¸Þ¼¼Áö º¸³¿ : BATCH ¼­¹ö·Î º¸³¿ , ¼­¹öºÐ¸®·Î ÇÑ°÷¿¡¼­ Ã³¸®ÇÏ±âÀ§ÇØ */
	/***************************************************************************/
	{
		//char s_channel[100]; 
		//TRSNode *node;

		////0. ¼³ºñ RESELECT
		//DBC_select_mrasresdef(1, &MRASRESDEF);
		//if(DB_error_code != DB_SUCCESS)
		//{
		//	//DO NOTHING
		//}

		///* Common Data */
		//node = TRS.create_node("RAS_Event_Publish_Msg_In");

		//CCOM_copy_in_node(in_node, node);
		//TRS.add_string(node, "RES_ID", MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
		//TRS.add_string(node, "RES_PRI_STS", MRASRESDEF.RES_PRI_STS, sizeof(MRASRESDEF.RES_PRI_STS));
		//TRS.add_string(node, "RES_STS_1", MRASRESDEF.RES_STS_1, sizeof(MRASRESDEF.RES_STS_1));
		//TRS.add_string(node, "RES_STS_2", MRASRESDEF.RES_STS_2, sizeof(MRASRESDEF.RES_STS_2));
		//TRS.add_string(node, "RES_STS_3", MRASRESDEF.RES_STS_3, sizeof(MRASRESDEF.RES_STS_3));
		//TRS.add_string(node, "RES_STS_4", MRASRESDEF.RES_STS_4, sizeof(MRASRESDEF.RES_STS_4));
		//TRS.add_string(node, "RES_STS_5", MRASRESDEF.RES_STS_5, sizeof(MRASRESDEF.RES_STS_5));
		//TRS.add_string(node, "RES_STS_6", MRASRESDEF.RES_STS_6, sizeof(MRASRESDEF.RES_STS_6));
		//TRS.add_string(node, "RES_STS_7", MRASRESDEF.RES_STS_7, sizeof(MRASRESDEF.RES_STS_7));
		//TRS.add_string(node, "RES_STS_8", MRASRESDEF.RES_STS_8, sizeof(MRASRESDEF.RES_STS_9));
		//TRS.add_string(node, "RES_STS_9", MRASRESDEF.RES_STS_9, sizeof(MRASRESDEF.RES_STS_9));
		//TRS.add_string(node, "RES_STS_10", MRASRESDEF.RES_STS_10, sizeof(MRASRESDEF.RES_STS_10));
		//TRS.add_string(node, "LOT_ID", MRASRESDEF.LOT_ID, sizeof(MRASRESDEF.LOT_ID));
		//TRS.add_string(node, "RES_CTRL_MODE", MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
		//TRS.add_string(node, "RES_PROC_MODE", MRASRESDEF.RES_PROC_MODE, sizeof(MRASRESDEF.RES_PROC_MODE));
		//TRS.add_string(node, "LAST_DOWN_TIME", MRASRESDEF.LAST_DOWN_TIME, sizeof(MRASRESDEF.LAST_DOWN_TIME));
		//
		///* MES to EAP */
		//memset(s_channel, 0x00, sizeof(s_channel));
		//sprintf(s_channel, "/%.*s/FMB/*", 4, gs_site_id);
		//COM_add_null(s_channel, sizeof(s_channel));
  //  
		//if(MOA.call_service("FMB", 
  //                  "RAS_Event_Publish", 
  //                  node, 
  //                  0x00, 
  //                  s_channel, 
  //                  gi_default_ttl, 
  //                  DM_MULTICAST) != MP_TRUE)
		//{
		//	//DO NTOHING
		//}
		//TRS.free_node(node);
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Change_Resource_State_Validation()
        - Main sub function of "EAPMES_CHANGE_RESOURCE_STATE" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Change_Resource_State_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
  
    return MP_TRUE;
}

