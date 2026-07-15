/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_Layup_Repair_Tray_Input_Data.c
    Description : EAPMES Layup Repair Tray Input Data Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Layup_Repair_Tray_Input_Data()
            + Setup service interface function
        - EAPMES_Layup_Repair_Tray_Input_Data()
            + Main sub function of EAPMES_Layup_Repair_Tray_Input_Data function
            + Setup service main business function
        - EAPMES_Layup_Repair_Tray_Input_Data_Validation()
            + Main sub function of EAPMES_Layup_Repair_Tray_Input_Data function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_Layup_Repair_Tray_Input_Data()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2020/1/10  hyunjun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Layup_Repair_Tray_Input_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Layup_Repair_Tray_Input_Data()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Layup_Repair_Tray_Input_Data(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_LAYUP_REPAIR_TRAY_INPUT_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_Layup_Repair_Tray_Input_Data", out_node);

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

    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "TRAY_ID", TRS.get_string(in_node, "TRAY_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_LAYUP_REPAIR_TRAY_INPUT_DATA()
        - Main sub function of "EAPMES_Layup_Repair_Tray_Input_Data" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_LAYUP_REPAIR_TRAY_INPUT_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CWIPTRYSTS_TAG CWIPTRYSTS;
	struct CWIPTRYHIS_TAG CWIPTRYHIS;
	struct MRASRESDEF_TAG MRASRESDEF;

	char s_sys_time_stamp[20];  
	char s_sys_time[14];


	LOG_head("EAPMES_LAYUP_REPAIR_TRAY_INPUT_DATA");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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


	if(EAPMES_Layup_Repair_Tray_Input_Data_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//0. 설비 ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	memcpy(MRASRESDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
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


	// SELECT CWIPTRYSTS
	CDB_init_cwiptrysts(&CWIPTRYSTS);
	memcpy(CWIPTRYSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID), in_node, "TRAY_ID");

	CDB_select_cwiptrysts(1, &CWIPTRYSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			// 이력 없으면 CWIPTRYSTS 입력 후 진행
			CWIPTRYSTS.SEQ = 1;
			memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT));
			TRS.copy(CWIPTRYSTS.CREATE_USER_ID, sizeof(CWIPTRYSTS.CREATE_USER_ID), in_node, "USERID");
			memcpy(CWIPTRYSTS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

			CDB_insert_cwiptrysts(&CWIPTRYSTS);
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPTRYSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYSTS.TRAY_ID), CWIPTRYSTS.TRAY_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	else if(DB_error_code == DB_SUCCESS)
	{
		// 상태 체크해서 "I" 상태가 다시 들어오면 SEQ 1 올린다.
		//if(memcmp(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, sizeof(CWIPTRYSTS.STATUS)) == 0)
		//{
		//	CWIPTRYSTS.SEQ++;
		//}
		memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT));
		TRS.copy(CWIPTRYSTS.UPDATE_USER_ID, sizeof(CWIPTRYSTS.UPDATE_USER_ID), in_node, "USERID");
		memcpy(CWIPTRYSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

		CDB_update_cwiptrysts(1, &CWIPTRYSTS);
	}

	// UPDATE CWIPTRYHIS
	CDB_init_cwiptryhis(&CWIPTRYHIS);
	memcpy(CWIPTRYHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(CWIPTRYHIS.TRAY_ID, CWIPTRYSTS.TRAY_ID, strlen(CWIPTRYHIS.TRAY_ID));
	CWIPTRYHIS.SEQ = CWIPTRYSTS.SEQ;
	
	CDB_select_cwiptryhis(1, &CWIPTRYHIS);
	
	memcpy(CWIPTRYHIS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT));
	memcpy(CWIPTRYHIS.RES_ID, MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
	CWIPTRYHIS.INPUT_QTY = COM_atoi(TRS.get_string(in_node, "QTY"),strlen(TRS.get_string(in_node, "QTY")));
	memcpy(CWIPTRYHIS.INPUT_TIME, s_sys_time, sizeof(s_sys_time));

	if(DB_error_code != DB_SUCCESS)
    {
		if(DB_error_code == DB_NOT_FOUND)
		{
			// 이력 없으면 CWIPTRYHIS 입력 후 진행
			TRS.copy(CWIPTRYHIS.CREATE_USER_ID, sizeof(CWIPTRYHIS.CREATE_USER_ID), in_node, "USERID");
			memcpy(CWIPTRYHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			
			CDB_insert_cwiptryhis(&CWIPTRYHIS);	
		} 
		else 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "CWIPTRYHIS INSERT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTRYHIS.FACTORY), CWIPTRYHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS.TRAY_ID), CWIPTRYHIS.TRAY_ID);
			TRS.add_fieldmsg(out_node, "SEQ", MP_STR, sizeof(CWIPTRYHIS.SEQ), CWIPTRYHIS.SEQ);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			
			return MP_FALSE;
		}
	} 
	else if(DB_error_code == DB_SUCCESS)
	{
		// 상태 체크해서 "I" 상태가 다시 들어오면 insert 한다.
		//if(memcmp(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, sizeof(CWIPTRYSTS.STATUS)) == 0)
		//{
		//	TRS.copy(CWIPTRYHIS.CREATE_USER_ID, sizeof(CWIPTRYHIS.CREATE_USER_ID), in_node, "USERID");
		//	memcpy(CWIPTRYHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		//	
		//	CDB_insert_cwiptryhis(&CWIPTRYHIS);	
		//}
		//else
		
		TRS.copy(CWIPTRYHIS.UPDATE_USER_ID, sizeof(CWIPTRYHIS.UPDATE_USER_ID), in_node, "USERID");
		memcpy(CWIPTRYHIS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

		CDB_update_cwiptryhis(1, &CWIPTRYHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "CWIPTRYHIS UPDATE", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTRYHIS.FACTORY), CWIPTRYHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "TRAY_ID", MP_STR, sizeof(CWIPTRYHIS.TRAY_ID), CWIPTRYHIS.TRAY_ID);
			TRS.add_fieldmsg(out_node, "SEQ", MP_STR, sizeof(CWIPTRYHIS.SEQ), CWIPTRYHIS.SEQ);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			
			return MP_FALSE;
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 
	
/*******************************************************************************
    EAPMES_Layup_Repair_Tray_Input_Data_Validation()
        - Main sub function of "EAPMES_Layup_Repair_Tray_Input_Data" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Layup_Repair_Tray_Input_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

