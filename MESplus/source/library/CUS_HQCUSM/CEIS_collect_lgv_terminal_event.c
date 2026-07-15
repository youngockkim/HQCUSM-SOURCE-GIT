/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_lgv_terminal_event.c
    Description : EAPMES_Collect_LGV_Terminal_Event Setup function module

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_LGV_Terminal_Event()
            + Create/Update/Delete EAPMES_Collect_LGV_Terminal_Event definition
        - EAPMES_COLLECT_LGV_TERMINAL_EVENT()
            + Main sub function of EAPMES_Collect_LGV_Terminal_Event function
            + Create/Update/Delete EAPMES_Collect_LGV_Terminal_Event definition
        - EAPMES_Collect_LGV_Terminal_Event_Validation()
            + Main sub function of EAPMES_COLLECT_LGV_TERMINAL_EVENT function
            + Check the condition for create/update/delete EAPMES_Collect_LGV_Terminal_Event
    Detail Description
        - EAPMES_COLLECT_LGV_TERMINAL_EVENT()
            + h_proc_step
                + MP_STEP_CREATE : Create EAPMES_Collect_LGV_Terminal_Event definition
                + MP_STEP_UPDATE : Update EAPMES_Collect_LGV_Terminal_Event definition
                + MP_STEP_DELETE : Delete EAPMES_Collect_LGV_Terminal_Event definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-11-24             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_LGV_Terminal_Event_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_LGV_Terminal_Event()
        - Create/Update/Delete EAPMES_Collect_LGV_Terminal_Event definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
//int EAPMES_Collect_LGV_Terminal_Event(TRSNode *in_node, TRSNode *out_node)
int EAPMES_Collect_LGV_Terminal_Event(TRSNode *in_node)
{
	char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_LGV_TERMINAL_EVENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_LGV_TERMINAL_EVENT", out_node);

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
    TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
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
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_LGV_Terminal_Event", 
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
    EAPMES_COLLECT_LGV_TERMINAL_EVENT()
        - Main sub function of "EAPMES_Collect_LGV_Terminal_Event" function
        - Create/Update/Delete EAPMES_Collect_LGV_Terminal_Event definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_LGV_TERMINAL_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASLGVDAT_TAG CRASLGVDAT;
	struct MRASRESDEF_TAG MRASRESDEF;
    char   s_sys_time[14];

	TRSNode ** LGV_LIST;
    TRSNode ** LGV_ITEM_LIST;
	TRSNode * LGV_ITEM_EQPID;

	int i,j;
	int i_lgv_list_count;
	int i_lgv_Item_list_count;

    LOG_head("EAPMES_COLLECT_LGV_TERMINAL_EVENT");
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

    if(EAPMES_Collect_LGV_Terminal_Event_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/* 1. LGV List */
    LGV_LIST = TRS.get_list(in_node, "LGV_LIST");
    i_lgv_list_count = TRS.get_item_count(in_node, "LGV_LIST");

	for(i = 0; i < i_lgv_list_count; i++)
    {
		/* 2. LGV Item List */
		LGV_ITEM_LIST = TRS.get_list(LGV_LIST[i], "LGV_ITEM");
        i_lgv_Item_list_count = TRS.get_item_count(LGV_LIST[i], "LGV_ITEM");

        for(j = 0; j < i_lgv_Item_list_count; j++)
        {
			/* 3. LGV Item */
			LGV_ITEM_EQPID = LGV_ITEM_LIST[j];
			
			// 설비 ID GET
			DBC_init_mrasresdef(&MRASRESDEF);
			TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
			TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), LGV_ITEM_EQPID, "LGV_EQPID");
			DBC_select_mrasresdef(1, &MRASRESDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0003");
				TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				LOG_head("EAPMES_COLLECT_LGV_TERMINAL_EVENT RES_ID NOT FOUND");
				LOG_add("FACTORY", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
				LOG_add("RES_ID(LGV_EQPID)", MP_NSTR,  TRS.get_string(LGV_ITEM_EQPID, "LGV_EQPID"));
				LOG_add("MSG_CODE", MP_STR, sizeof(s_msg_code), s_msg_code);
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_EXISTENCE, MP_LOG_CATE_SETUP);

				continue;
			}

			CDB_init_craslgvdat(&CRASLGVDAT);
			TRS.copy(CRASLGVDAT.FACTORY, sizeof(CRASLGVDAT.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CRASLGVDAT.LINE_ID, sizeof(CRASLGVDAT.LINE_ID), in_node, "LINE_ID");
			//TRS.copy(CRASLGVDAT.TRAN_TIME, sizeof(CRASLGVDAT.TRAN_TIME), in_node, "TRAN_TIME"); // 설비에서 전송한 시간
			memcpy(CRASLGVDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time)); //  MES DB 시간 기준

			TRS.copy(CRASLGVDAT.LGV_MAIN_EQPID, sizeof(CRASLGVDAT.LGV_MAIN_EQPID), in_node, "RES_ID");
			CRASLGVDAT.LGV_STD_WAIT_SEC = TRS.get_int(in_node, "LGV_STD_WAIT_SEC");
			CRASLGVDAT.LGV_STD_WAIT_COUNT = TRS.get_int(in_node, "LGV_STD_WAIT_COUNT");
			
			TRS.copy(CRASLGVDAT.RES_ID, sizeof(CRASLGVDAT.RES_ID), LGV_ITEM_EQPID, "LGV_EQPID");
			CRASLGVDAT.LGV_WAIT_TIME = TRS.get_int(LGV_ITEM_EQPID, "LGV_WAIT_TIME");
			
			TRS.copy(CRASLGVDAT.CREATE_USER_ID, sizeof(CRASLGVDAT.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CRASLGVDAT.CREATE_TIME, s_sys_time, sizeof(CRASLGVDAT.CREATE_TIME));
			CDB_insert_craslgvdat(&CRASLGVDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "EIS-0004");
				TRS.add_fieldmsg(out_node, "CRASLGVDAT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASLGVDAT.FACTORY), CRASLGVDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASLGVDAT.LINE_ID), CRASLGVDAT.LINE_ID);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASLGVDAT.RES_ID), CRASLGVDAT.RES_ID);
				TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CRASLGVDAT.TRAN_TIME), CRASLGVDAT.TRAN_TIME);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_LGV_Terminal_Event_Validation()
        - Main sub function of "EAPMES_COLLECT_LGV_TERMINAL_EVENT" function
        - Check the condition for create/update/delete EAPMES_Collect_LGV_Terminal_Event
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_LGV_Terminal_Event_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

