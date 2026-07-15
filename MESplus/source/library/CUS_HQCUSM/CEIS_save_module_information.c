/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_save_module_information.c.c
    Description : EAPMES Save Module Information Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Save_Module_Information()
            + Setup service interface function
        - EAPMES_SAVE_MODULE_INFORMATION()
            + Main sub function of EAPMES_Save_Module_Information function
            + Setup service main business function
        - EAPMES_Save_Module_Information_Validation()
            + Main sub function of EAPMES_SAVE_MODULE_INFORMATION function
    Detail Description
        - EAPMES_SAVE_MODULE_INFORMATION()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Save_Module_Information_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int EAPMES_SAVE_MODULE_INFORMATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Save_Module_Information()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Save_Module_Information(TRSNode *in_node)
{
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_SAVE_MODULE_INFORMATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_SAVE_MODULE_INFORMATION", out_node);

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

    
	/* 특정 에러처리를 무시할경우 사용 ERROR  */
	// VALIDATION 하라고 셋팅된 에러만 에러처리함.
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
	memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
	memcpy(MGCMLAGDAT.KEY_2, "VALIDATION", strlen("VALIDATION"));
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Save_Module_Information", strlen("EAPMES_Save_Module_Information"));
	memcpy(MGCMLAGDAT.KEY_4, s_msg_code, 9);
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'Y'))
	{
		//VALIDATION SKIP 이 아닌경우 에러발생
		//MGCMLAGDAT TABLE (@FACTORY_OPTION)에서 DATA_1 = 'Y' 이면 에러발생
	}
	else
	{
		//VALIDATION SKIP 일경우 무조건 성공 
        COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	}

    
    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
	TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_nstring(out_node, "PALLET_ID", TRS.get_string(in_node, "PALLET_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));


	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Save_Module_Information", 
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
    EAPMES_SAVE_MODULE_INFORMATION()
        - Main sub function of "EAPMES_Save_Module_Information" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_SAVE_MODULE_INFORMATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CPOPLBLHIS_TAG CPOPLBLHIS;
    char   s_sys_time[14];

    LOG_head("EAPMES_SAVE_MODULE_INFORMATION");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(EAPMES_Save_Module_Information_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	 /* To Do */
	CDB_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
    {
       //DO NOTHING
    }

    /* To Do */
	CDB_init_cpoplblhis(&CPOPLBLHIS);
	memcpy(CPOPLBLHIS.LABEL_ID, HQCEL_M1_LABEL_TYPE_MODULEID, strlen(HQCEL_M1_LABEL_TYPE_MODULEID));
	TRS.copy(CPOPLBLHIS.PRINTED_ID, sizeof(CPOPLBLHIS.PRINTED_ID), in_node, "LOT_ID");
	if (CDB_select_cpoplblhis_scalar(2, &CPOPLBLHIS) > 0)
	{
		//INSERT LABEL HISTORY
		CPOPLBLHIS.PRINT_QTY = 1;
		memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		memcpy(CPOPLBLHIS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		memcpy(CPOPLBLHIS.OPERATION, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		memcpy(CPOPLBLHIS.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		memcpy(CPOPLBLHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		CPOPLBLHIS.PRINTED_TYPE = 'A';

		TRS.copy(CPOPLBLHIS.DATA_1, sizeof(CPOPLBLHIS.DATA_1), in_node, "ORDER_ID");
		TRS.copy(CPOPLBLHIS.DATA_2, sizeof(CPOPLBLHIS.DATA_2), in_node, "PALLET_ID");
		TRS.copy(CPOPLBLHIS.DATA_3, sizeof(CPOPLBLHIS.DATA_3), in_node, "RES_ID");
		TRS.copy(CPOPLBLHIS.DATA_4, sizeof(CPOPLBLHIS.DATA_4), in_node, "LINE_ID");
		TRS.copy(CPOPLBLHIS.DATA_5, sizeof(CPOPLBLHIS.DATA_5), in_node, "CLIENT_TIME");

		memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CPOPLBLHIS.TRAN_USER_ID, sizeof(CPOPLBLHIS.TRAN_USER_ID), in_node, "CIM_ID");
		memcpy(CPOPLBLHIS.DATA_20, "ERROR", strlen("ERROR"));

		CDB_insert_cpoplblhis(&CPOPLBLHIS);
		if(DB_error_code == DB_SUCCESS)
		{
			//발행이력은 insert 함.
			DB_commit();
		}
		//이미 발행된 이력이 있으므로 ERROR!
		strcpy(s_msg_code, "POP-0002");
        TRS.add_fieldmsg(out_node, "CPOPLBLHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LABEL_ID", MP_STR, sizeof(CPOPLBLHIS.LABEL_ID), CPOPLBLHIS.LABEL_ID);
        TRS.add_fieldmsg(out_node, "PRINTED_ID", MP_STR, sizeof(CPOPLBLHIS.PRINTED_ID), CPOPLBLHIS.PRINTED_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//INSERT LABEL HISTORY
	CPOPLBLHIS.PRINT_QTY = 1;
	memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	memcpy(CPOPLBLHIS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
	memcpy(CPOPLBLHIS.OPERATION, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
	memcpy(CPOPLBLHIS.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(CPOPLBLHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
	CPOPLBLHIS.PRINTED_TYPE = 'A';

	TRS.copy(CPOPLBLHIS.DATA_1, sizeof(CPOPLBLHIS.DATA_1), in_node, "ORDER_ID");
	TRS.copy(CPOPLBLHIS.DATA_2, sizeof(CPOPLBLHIS.DATA_2), in_node, "PALLET_ID");
	TRS.copy(CPOPLBLHIS.DATA_3, sizeof(CPOPLBLHIS.DATA_3), in_node, "RES_ID");
	TRS.copy(CPOPLBLHIS.DATA_4, sizeof(CPOPLBLHIS.DATA_4), in_node, "LINE_ID");
	TRS.copy(CPOPLBLHIS.DATA_5, sizeof(CPOPLBLHIS.DATA_5), in_node, "CLIENT_TIME");

	memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	TRS.copy(CPOPLBLHIS.TRAN_USER_ID, sizeof(CPOPLBLHIS.TRAN_USER_ID), in_node, "CIM_ID");

	CDB_insert_cpoplblhis(&CPOPLBLHIS);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "CPOPLBLHIS INSERT", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Save_Module_Information_Validation()
        - Main sub function of "EAPMES_SAVE_MODULE_INFORMATION" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Save_Module_Information_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

