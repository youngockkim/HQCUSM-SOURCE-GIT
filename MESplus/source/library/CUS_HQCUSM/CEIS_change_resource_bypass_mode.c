/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_change_resource_bypass_mode.c
    Description : EAPMES Change Resource Bypass Mode Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Change_Resource_Bypass_Mode()
            + Setup service interface function
        - EAPMES_CHANGE_RESOURCE_BYPASS_MODE()
            + Main sub function of EAPMES_Change_Resource_Bypass_Mode function
            + Setup service main business function
        - EAPMES_Change_Resource_Bypass_Mode_Validation()
            + Main sub function of EAPMES_CHANGE_RESOURCE_BYPASS_MODE function
    Detail Description
        - EAPMES_CHANGE_RESOURCE_BYPASS_MODE()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/04/01  Albert Kim     Created

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Change_Resource_Bypass_Mode_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Change_Resource_Bypass_Mode()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Change_Resource_Bypass_Mode(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_CHANGE_RESOURCE_BYPASS_MODE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_CHANGE_RESOURCE_BYPASS_MODE", out_node);

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
    TRS.set_nstring(out_node, "CONTROL_MODE", TRS.get_string(in_node, "CONTROL_MODE"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Change_Resource_Bypass_Mode", 
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
    EAPMES_CHANGE_RESOURCE_BYPASS_MODE()
        - Main sub function of "EAPMES_Change_Resource_Bypass_Mode" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_CHANGE_RESOURCE_BYPASS_MODE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MGCMTBLDEF_TAG MGCMTBLDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    struct MRASRESDEF_TAG MRASRESDEF;
    struct CRASRESBPS_TAG CRASRESBPS;

	TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    char s_sys_time_stamp[20];
    

    LOG_head("EAPMES_CHANGE_RESOURCE_BYPASS_MODE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));

    DB_get_systime_m(s_sys_time_stamp);
    if (DB_error_code != DB_SUCCESS)
    {
        TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    if(EAPMES_Change_Resource_Bypass_Mode_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

   
    /* Validate Resource ID */
    DBC_init_mrasresdef(&MRASRESDEF);
    TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");

	DBC_select_mrasresdef_for_update(1, &MRASRESDEF);//20190930 장애대응 
    //DBC_select_mrasresdef(1, &MRASRESDEF);
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

    /* Validate Resource ID */
    CDB_init_crasresbps(&CRASRESBPS);
    TRS.copy(CRASRESBPS.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(CRASRESBPS.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(CRASRESBPS.LINE_ID));
    TRS.copy(CRASRESBPS.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
    TRS.copy(CRASRESBPS.BR_TYPE, sizeof(CRASRESBPS.BR_TYPE), in_node, "BYPASS_TYPE");
    CDB_select_crasresbps(1, &CRASRESBPS);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            memcpy(CRASRESBPS.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(CRASRESBPS.LINE_ID));
            TRS.copy(CRASRESBPS.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
            TRS.copy(CRASRESBPS.BR_TYPE, sizeof(CRASRESBPS.BR_TYPE), in_node, "BYPASS_TYPE");
            TRS.copy(CRASRESBPS.BR_MODE, sizeof(CRASRESBPS.BR_MODE), in_node, "BYPASS_MODE");
            memcpy(CRASRESBPS.CREATE_TIME, s_sys_time_stamp, sizeof(CRASRESBPS.CREATE_TIME));
            CDB_insert_crasresbps(&CRASRESBPS);
            if (DB_error_code != DB_SUCCESS)
            {
                //Do nothing
            }
        }
    }
    else
    {
        memcpy(CRASRESBPS.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(CRASRESBPS.LINE_ID));
        TRS.copy(CRASRESBPS.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
        TRS.copy(CRASRESBPS.BR_TYPE, sizeof(CRASRESBPS.BR_TYPE), in_node, "BYPASS_TYPE");
        TRS.copy(CRASRESBPS.BR_MODE, sizeof(CRASRESBPS.BR_MODE), in_node, "BYPASS_MODE");
        memcpy(CRASRESBPS.UPDATE_TIME, s_sys_time_stamp, sizeof(CRASRESBPS.UPDATE_TIME));
        CDB_update_crasresbps(1, &CRASRESBPS);
        if (DB_error_code != DB_SUCCESS)
        {
            //Do nothing
        }
    }


    LOG_head("EAPMES_CHANGE_RESOURCE_BYPASS_MODE_DATA");
    LOG_add("bypass_type", MP_NSTR, TRS.get_string(in_node, "BYPASS_TYPE"));
    LOG_add("bypass_mode", MP_NSTR, TRS.get_string(in_node, "BYPASS_MODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    
	///* 설비 이베트 발생시킴 */
	////RESOURCE  EVNET
	//tran_in_node = TRS.create_node("TRAN_IN");
 //   tran_out_node = TRS.create_node("TRAN_OUT");

 //   CCOM_copy_in_node(in_node, tran_in_node);
 //   TRS.add_char(tran_in_node, "PROCSTEP", '1');
	//TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	//TRS.add_nstring(tran_in_node, "EVENT_ID", HQCEL_M1_EVENT_EQ_CHGMODE); // 설비 모드 변경 EVENT


	//TRS.add_nstring(tran_in_node, "TRAN_CMF_5", TRS.get_string( in_node, "CONTROL_MODE")); //CONTROL MODE

	//
	//if(RAS_RESOURCE_EVENT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	//{
 //       //DO NOTHING
	//}

 //   TRS.free_node(tran_in_node);
 //   TRS.free_node(tran_out_node);


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Change_Resource_Bypass_Mode_Validation()
        - Main sub function of "EAPMES_CHANGE_RESOURCE_BYPASS_MODE" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Change_Resource_Bypass_Mode_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

