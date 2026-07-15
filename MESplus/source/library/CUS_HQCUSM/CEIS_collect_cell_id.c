/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_cell_id.c
    Description : EAPMES Collect Cell ID Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Cell_ID()
            + Setup service interface function
        - EAPMES_COLLECT_CELL_ID()
            + Main sub function of EAPMES_Collect_Cell_ID function
            + Setup service main business function
        - EAPMES_Collect_Cell_ID_Validation()
            + Main sub function of EAPMES_COLLECT_CELL_ID function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_COLLECT_CELL_ID()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Cell_ID_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Cell_ID()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Cell_ID(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_CELL_ID(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_CELL_ID", out_node);

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
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "CELL_ID", TRS.get_string(in_node, "CELL_ID"));
    TRS.set_nstring(out_node, "LAMA_ID", TRS.get_string(in_node, "LAMA_ID"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));
    TRS.set_nstring(out_node, "VMAGAZINE_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));
    TRS.set_nstring(out_node, "WORK_TYPE", TRS.get_string(in_node, "WORK_TYPE"));
    //TRS.set_char(out_node, "WORK_TYPE", TRS.get_char(in_node, "WORK_TYPE"));

    /* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Cell_ID", 
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
    EAPMES_COLLECT_CELL_ID()
        - Main sub function of "EAPMES_Collect_Cell_ID" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_CELL_ID(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    
	//TABBER 의 CELL ID - LAMA ID 올려주는 부분 저장

    char s_sys_time[14];
	struct CWIPCELLAM_TAG CWIPCELLAM;

    LOG_head("EAPMES_COLLECT_CELL_ID");
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

    if(EAPMES_Collect_Cell_ID_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* To Do */
	CDB_init_cwipcellam(&CWIPCELLAM);
	TRS.copy(CWIPCELLAM.FACTORY, sizeof(CWIPCELLAM.FACTORY), in_node, "FACTORY");
	TRS.copy(CWIPCELLAM.CELL_ID, sizeof(CWIPCELLAM.CELL_ID), in_node, "CELL_ID");
	TRS.copy(CWIPCELLAM.LAMA_ID, sizeof(CWIPCELLAM.LAMA_ID), in_node, "LAMA_ID");
	CDB_select_cwipcellam(1, &CWIPCELLAM);
	if(DB_error_code != DB_SUCCESS)
    {
		//데이터가 없으면 INSERT 
		TRS.copy(CWIPCELLAM.CREATE_TIME, 14, in_node, "CLIENT_TIME");
		memcpy(CWIPCELLAM.CMF_1, "COLLECT", strlen("COLLECT"));

		if (COM_isspace(CWIPCELLAM.CREATE_TIME, sizeof(CWIPCELLAM.CREATE_TIME)) == MP_TRUE)
		{
			memcpy(CWIPCELLAM.CREATE_TIME, s_sys_time, sizeof(s_sys_time)); //PARTITION KEY
		}

		CDB_insert_cwipcellam(&CWIPCELLAM);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}
	
	TRS.copy(CWIPCELLAM.LINE_ID, sizeof(CWIPCELLAM.LINE_ID), in_node, "LINE_ID");
	TRS.copy(CWIPCELLAM.RES_ID, sizeof(CWIPCELLAM.RES_ID), in_node, "RES_ID");
	TRS.copy(CWIPCELLAM.LOCATION_ID, sizeof(CWIPCELLAM.LOCATION_ID), in_node, "LOC_ID");

	TRS.copy(CWIPCELLAM.VMAGAZINE_ID, sizeof(CWIPCELLAM.VMAGAZINE_ID), in_node, "VMAGAZINE_ID");
	TRS.copy(CWIPCELLAM.WORK_TYPE, sizeof(CWIPCELLAM.WORK_TYPE), in_node, "WORK_TYPE");

	CDB_update_cwipcellam(1, &CWIPCELLAM);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Cell_ID_Validation()
        - Main sub function of "EAPMES_COLLECT_CELL_ID" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Cell_ID_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
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


    return MP_TRUE;
}

