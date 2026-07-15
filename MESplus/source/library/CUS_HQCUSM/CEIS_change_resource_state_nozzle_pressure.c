/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_change_resource_state_nozzle_pressure.c
    Description : EAPMES Change Resource State for Nozzle pressure Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Change_Resource_State_Nozzle_Pressure()
            + Setup service interface function
        - EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE()
            + Main sub function of EAPMES_Change_Resource_State_Nozzle_Pressure function
            + Setup service main business function
        - EAPMES_Change_Resource_State_Nozzle_Pressure_Validation()
            + Main sub function of EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE function
    Detail Description
        - EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025-04-01  Albert Kim     Created

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/
#include "CUS_common.h"
#include "CUS_HQCUSM_common.h"

#include <MESCore_common.h>
#include "ACTCore_common.h"

int EAPMES_Change_Resource_State_Nozzle_Pressure_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Change_Resource_State_Nozzle_Pressure()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Change_Resource_State_Nozzle_Pressure(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE", out_node);

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

    if (CallService(MODULE_EAP,
        "MESEAP_Change_Resource_State_Nozzle_Pressure",
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
    EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE()
        - Main sub function of "EAPMES_Change_Resource_State_Nozzle_Pressure" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
    struct CRASPRCDAT_TAG CRASPRCDAT;

    char s_sys_time_stamp[20];  
    char s_sys_time[17];
	char s_actual_time[15];
    char s_param_name[100];

    double d_max_seq_num;

	/*
	char message[130];
	*/
    struct worktime_tag cur_work_time;

	//TRSNode* tran_in_node;
 //   TRSNode* tran_out_node;  


	/* Lot Information */
    LOG_head("EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Change_Resource_State_Nozzle_Pressure_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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


    
    memset(s_param_name, ' ', sizeof(s_param_name));
    if (TRS.str_cmp(in_node, "TYPE", "1") == 0)
        memcpy(s_param_name, "PRESSURE_NOZZLE_L_MIN", strlen("PRESSURE_NOZZLE_L_MIN"));
    else if (TRS.str_cmp(in_node, "TYPE", "2") == 0)
        memcpy(s_param_name, "PRESSURE_NOZZLE_R_MIN", strlen("PRESSURE_NOZZLE_R_MIN"));
    else if (TRS.str_cmp(in_node, "TYPE", "3") == 0)
        memcpy(s_param_name, "PRESSURE_HEAD_L_MIN", strlen("PRESSURE_HEAD_L_MIN"));
    else if (TRS.str_cmp(in_node, "TYPE", "4") == 0)
        memcpy(s_param_name, "PRESSURE_HEAD_R_MIN", strlen("PRESSURE_HEAD_R_MIN"));


    /* Get Max Sequence */
    d_max_seq_num = 0;
    CDB_init_crasprcdat(&CRASPRCDAT);
    TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "STRING_ID");
    TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
    memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
    memcpy(CRASPRCDAT.PARAM_NAME, s_param_name, sizeof(CRASPRCDAT.PARAM_NAME));
    


   
    d_max_seq_num = CDB_select_crasprcdat_scalar(2, &CRASPRCDAT);
    if (DB_error_code != DB_SUCCESS)
    {
        //return MP_TRUE;
    }

    /* Insert */
    CDB_init_crasprcdat(&CRASPRCDAT);
    TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
    memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
    
    CRASPRCDAT.SEQ_NUM = (int)++d_max_seq_num; //형변환 2023-07-04
    TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), in_node, "LINE_ID");
    memcpy(CRASPRCDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CRASPRCDAT.OPER));
    CRASPRCDAT.LOT_HIST_SEQ = 0;

    memcpy(CRASPRCDAT.PARAM_NAME, s_param_name, sizeof(CRASPRCDAT.PARAM_NAME));

    TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), in_node, "MIN");
    memcpy(CRASPRCDAT.CREATE_TIME, CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.CREATE_TIME));

    //값이 없으면 저장안함. 데이터가 너무많음.
    if (COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) != MP_TRUE)
    {
        //CEDCLOTDAT INSERT: 레포트에서 설비데이터 조회용 
        if (CCOM_COPY_FROM_PRCDATA_TO_LOTDATA(in_node, &CRASPRCDAT) == MP_FALSE)
        {
            //DO NOTHING
        }
    }


    memset(s_param_name, ' ', sizeof(s_param_name));
    if (TRS.str_cmp(in_node, "TYPE", "1") == 0)
        memcpy(s_param_name, "PRESSURE_NOZZLE_L_MAX", strlen("PRESSURE_NOZZLE_L_MAX"));
    else if (TRS.str_cmp(in_node, "TYPE", "2") == 0)
        memcpy(s_param_name, "PRESSURE_NOZZLE_R_MAX", strlen("PRESSURE_NOZZLE_R_MAX"));
    else if (TRS.str_cmp(in_node, "TYPE", "3") == 0)
        memcpy(s_param_name, "PRESSURE_HEAD_L_MAX", strlen("PRESSURE_HEAD_L_MAX"));
    else if (TRS.str_cmp(in_node, "TYPE", "4") == 0)
        memcpy(s_param_name, "PRESSURE_HEAD_R_MAX", strlen("PRESSURE_HEAD_R_MAX"));

    /* Get Max Sequence */
    d_max_seq_num = 0;
    CDB_init_crasprcdat(&CRASPRCDAT);
    TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "STRING_ID");
    TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
    memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));

    
    memcpy(CRASPRCDAT.PARAM_NAME, s_param_name, sizeof(CRASPRCDAT.PARAM_NAME));

    d_max_seq_num = CDB_select_crasprcdat_scalar(2, &CRASPRCDAT);
    if (DB_error_code != DB_SUCCESS)
    {
        //return MP_TRUE;
    }

    /* Insert */
    CDB_init_crasprcdat(&CRASPRCDAT);
    TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
    memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
    //TRS.copy(CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.TRAN_TIME), in_node, "CLIENT_TIME");
    CRASPRCDAT.SEQ_NUM = (int)++d_max_seq_num; //형변환 2023-07-04
    TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), in_node, "LINE_ID");
    memcpy(CRASPRCDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CRASPRCDAT.OPER));
    CRASPRCDAT.LOT_HIST_SEQ = 0;

    memcpy(CRASPRCDAT.PARAM_NAME, s_param_name, sizeof(CRASPRCDAT.PARAM_NAME));

    TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), in_node, "MAX");
    memcpy(CRASPRCDAT.CREATE_TIME, CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.CREATE_TIME));

    //값이 없으면 저장안함. 데이터가 너무많음.
    if (COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) != MP_TRUE)
    {

        //CEDCLOTDAT INSERT: 레포트에서 설비데이터 조회용 
        if (CCOM_COPY_FROM_PRCDATA_TO_LOTDATA(in_node, &CRASPRCDAT) == MP_FALSE)
        {
            //DO NOTHING
        }
    }


   

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Change_Resource_State_Nozzle_Pressure_Validation()
        - Main sub function of "EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Change_Resource_State_Nozzle_Pressure_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
  
    return MP_TRUE;
}

