/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_get_process_tack_time.c
    Description : EAPMES Get Process Tack Time Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Get_Process_Tack_Time()
            + Setup service interface function
        - EAPMES_GET_PROCESS_TACK_TIME()
            + Main sub function of EAPMES_Get_Process_Tack_Time function
            + Setup service main business function
        - EAPMES_Get_Process_Tack_Time_Validation()
            + Main sub function of EAPMES_GET_PROCESS_TACK_TIME function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_GET_PROCESS_TACK_TIME()
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

int EAPMES_Get_Process_Tack_Time_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Get_Process_Tack_Time()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Get_Process_Tack_Time(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
	

    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_GET_PROCESS_TACK_TIME(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_GET_PROCESS_TACK_TIME", out_node);

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
    TRS.set_nstring(out_node, "TACK_TIME", TRS.get_string(in_node, "TACK_TIME"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));

    /* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	/***
	if(CallService(MODULE_EAP, 
		"MESEAP_Get_Process_Tack_Time", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}
	***/

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
    EAPMES_GET_PROCESS_TACK_TIME()
        - Main sub function of "EAPMES_Get_Process_Tack_Time" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_GET_PROCESS_TACK_TIME(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    char s_actual_time[15];
	char c_ignore_flag = 'N';
	char c_shift;
	char c_value_keep;
	int  i_cnt = 0;
	int  i_collect_count = 0;
	int  filter_max = 0;
	int  filter_min = 0;

	double d_data_count = 0;
	double d_total_data_count = 0;
	double dTime = 0;
	double dtack_filter_value = 0;		//tack_time_filter
	
	struct worktime_tag cur_work_time;
	char s_sys_time_stamp[20];  
    char s_sys_time_17[17];

	struct RSUMHOREQP_TAG RSUMHOREQP;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CTMPTCKTIM_TAG CTMPTCKTIM;
	struct CWIPTCKTIM_TAG CWIPTCKTIM;
	struct CWIPTCKTIM_TAG CWIPTCKTIM_DEL;
		
    //char   s_sys_time[14];
	memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  
    DB_get_systime_m(s_sys_time_stamp);
    

    LOG_head("EAPMES_GET_PROCESS_TACK_TIME");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Get_Process_Tack_Time_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_actual_time, ' ', sizeof(s_actual_time));
	//TRS.copy(s_actual_time, sizeof(s_actual_time), in_node, "CLIENT_TIME");
	memcpy(s_actual_time, s_sys_time_stamp, sizeof(s_actual_time));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	/* CURRENT SHIFT GET */
	c_shift = CCOM_get_work_shift(s_actual_time);

	if (COM_atof(TRS.get_string(in_node, "TACK_TIME"), strlen(TRS.get_string(in_node, "TACK_TIME"))) < 0)
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}


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

	/* Get order information */
	DBC_init_mwipordsts(&MWIPORDSTS);
	TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
	
	//ORDER GET
	if (COM_isspace(MRASRESDEF.RES_CMF_9, sizeof(MRASRESDEF.RES_CMF_9)) == MP_FALSE)
	{
		//¼³ºñ¿¡¼­ VALIDATION ÇÑ ORDER : CLAVING/TABBER
		memcpy(MWIPORDSTS.ORDER_ID, MRASRESDEF.RES_CMF_9, sizeof(MWIPORDSTS.ORDER_ID));
	}
	else
	{
		//ÇöÀç LINE ÀÇ ¿À´õ»ç¿ë.
		//ÇöÀç LINE ÀÇ ÀÛ¾÷Áö½Ã  GET
		/* Get current order by line ID */
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");

		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			memcpy(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID));
		}
	}
	DBC_select_mwipordsts(1, &MWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	/*************************************************************/
	/*½Ã°£º° µ¥ÀÌÅÍ Ã³¸®.*/
	/*************************************************************/
    CDB_init_rsumhoreqp(&RSUMHOREQP);
    TRS.copy(RSUMHOREQP.FACTORY, sizeof(RSUMHOREQP.FACTORY), in_node, "FACTORY");
	memcpy(RSUMHOREQP.WORK_DATE, cur_work_time.work_date, sizeof(RSUMHOREQP.WORK_DATE));
	RSUMHOREQP.WORK_SHIFT[0] = c_shift;
	memcpy(RSUMHOREQP.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(RSUMHOREQP.LINE_ID));
	if (COM_isspace(RSUMHOREQP.LINE_ID, sizeof(RSUMHOREQP.LINE_ID)) == MP_TRUE)
		TRS.copy(RSUMHOREQP.LINE_ID, sizeof(RSUMHOREQP.FACTORY), in_node, "LINE_ID");

	memcpy(RSUMHOREQP.RES_ID, MRASRESDEF.RES_ID, sizeof(RSUMHOREQP.RES_ID));
	
	TRS.copy(RSUMHOREQP.SUB_RES_ID, sizeof(RSUMHOREQP.SUB_RES_ID), in_node, "LOC_ID");

	if(COM_isspace(TRS.get_string(in_node, "LOC_ID"), strlen(TRS.get_string(in_node, "LOC_ID"))) == MP_TRUE)
	{
		TRS.set_string(in_node, "LOC_ID",MRASRESDEF.RES_ID,sizeof(MRASRESDEF.RES_ID));
	}

	if (COM_isspace(RSUMHOREQP.SUB_RES_ID, sizeof(RSUMHOREQP.SUB_RES_ID)) == MP_TRUE)
		memcpy(RSUMHOREQP.SUB_RES_ID, MRASRESDEF.RES_ID, sizeof(RSUMHOREQP.RES_ID));

	memcpy(RSUMHOREQP.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(RSUMHOREQP.MAT_ID));
	memcpy(RSUMHOREQP.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(RSUMHOREQP.ORDER_ID));

	memcpy(RSUMHOREQP.OPER, MRASRESDEF.RES_CMF_2, sizeof(RSUMHOREQP.OPER));

	//25.11.11[이글23]은 Filter에 걸리지 않은 데이터는 아예 저장 조차 안함[시작]
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "@TACK_TIME_FILTER", strlen("@TACK_TIME_FILTER"));
	memcpy(MGCMTBLDAT.KEY_1, RSUMHOREQP.RES_ID, sizeof(RSUMHOREQP.RES_ID));
	memcpy(MGCMTBLDAT.KEY_2, RSUMHOREQP.LINE_ID, sizeof(RSUMHOREQP.LINE_ID));
	memcpy(MGCMTBLDAT.KEY_3, RSUMHOREQP.OPER, sizeof(RSUMHOREQP.OPER));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	
	c_value_keep = 'X';
		
	if(DB_error_code == DB_SUCCESS && COM_isnullspace(MGCMTBLDAT.DATA_1) == MP_FALSE && COM_isnullspace(MGCMTBLDAT.DATA_2) == MP_FALSE)
	{
		dtack_filter_value = 0;
		dtack_filter_value  = COM_atof(TRS.get_string(in_node, "TACK_TIME"), (int)strlen(TRS.get_string(in_node, "TACK_TIME")));


		filter_max = 0 ;
		filter_min = 0;
		filter_min = COM_atoi(MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		filter_max = COM_atoi(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));

		if((int)dtack_filter_value >=filter_min && (int)dtack_filter_value <=filter_max)
		{
			c_value_keep = ' ';
		}	
		else
		{
			c_value_keep = 'X';
		}

	}

	if(c_value_keep == 'X')	//이글23는 구간에 존재하지 않는 답이 오면 저장 하지 않는다(CWIPTCKTIM/RSUMHOREQP)
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}

	c_value_keep = ' ';
	filter_max = 0 ;
	filter_min = 0;
	dtack_filter_value = 0;
		


	//25.11.11[이글23]은 Filter에 걸리지 않은 데이터는 아예 저장 조차 안함[종료]
	
	CDB_select_rsumhoreqp(1, &RSUMHOREQP);
	if (DB_error_code != DB_SUCCESS)
	{
		CDB_insert_rsumhoreqp(&RSUMHOREQP);
	}
	c_ignore_flag = 'N';

	CDB_init_ctmptcktim(&CTMPTCKTIM);
	TRS.copy(CTMPTCKTIM.FACTORY, sizeof(CTMPTCKTIM.FACTORY), in_node, "FACTORY");
	TRS.copy(CTMPTCKTIM.RES_ID, sizeof(CTMPTCKTIM.RES_ID), in_node, "RES_ID");
	TRS.copy(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID), in_node, "LOC_ID");

	if (COM_isspace(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID)) == MP_TRUE)
		memcpy(CTMPTCKTIM.SUB_RES_ID, MRASRESDEF.RES_ID, sizeof(CTMPTCKTIM.RES_ID));
	

	if(CDB_select_ctmptcktim_scalar(2, &CTMPTCKTIM)< 10)
	{
		//INSERT
		CTMPTCKTIM.TACK_TIME  = COM_atof(TRS.get_string(in_node, "TACK_TIME"), strlen(TRS.get_string(in_node, "TACK_TIME"))); 
		DB_get_systime(CTMPTCKTIM.CREATE_TIME); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}

		CDB_insert_ctmptcktim(&CTMPTCKTIM); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "RAS-0004"); 
			TRS.add_fieldmsg(out_node, "CTMPTCKTIM INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPTCKTIM.FACTORY), CTMPTCKTIM.FACTORY); 
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CTMPTCKTIM.RES_ID), CTMPTCKTIM.RES_ID); 
			TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CTMPTCKTIM.SUB_RES_ID), CTMPTCKTIM.SUB_RES_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 

	}
	else
	{
		//Maintain 9
		CDB_init_ctmptcktim(&CTMPTCKTIM);
		TRS.copy(CTMPTCKTIM.FACTORY, sizeof(CTMPTCKTIM.FACTORY), in_node, "FACTORY");
		TRS.copy(CTMPTCKTIM.RES_ID, sizeof(CTMPTCKTIM.RES_ID), in_node, "RES_ID");
		TRS.copy(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID), in_node, "LOC_ID");

		if (COM_isspace(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID)) == MP_TRUE)
			memcpy(CTMPTCKTIM.SUB_RES_ID, CTMPTCKTIM.RES_ID, sizeof(CTMPTCKTIM.RES_ID));
		CDB_open_ctmptcktim(2, &CTMPTCKTIM); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "CTMPTCKTIM OPEN", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPTCKTIM.FACTORY), CTMPTCKTIM.FACTORY); 
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CTMPTCKTIM.RES_ID), CTMPTCKTIM.RES_ID); 
			TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CTMPTCKTIM.SUB_RES_ID), CTMPTCKTIM.SUB_RES_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
		while(1)
		{
			CDB_fetch_ctmptcktim(2, &CTMPTCKTIM); 
			if(DB_error_code != DB_SUCCESS)
			{
				CDB_close_ctmptcktim(2); 
				break;
			}

			//DELETE
			CDB_delete_ctmptcktim(1, &CTMPTCKTIM);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CTMPTCKTIM DELETE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPTCKTIM.FACTORY), CTMPTCKTIM.FACTORY); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CTMPTCKTIM.RES_ID), CTMPTCKTIM.RES_ID); 
				TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CTMPTCKTIM.SUB_RES_ID), CTMPTCKTIM.SUB_RES_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
				// DB Close Ãß°¡
				CDB_close_ctmptcktim(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 

		}

		//INSERT
		CDB_init_ctmptcktim(&CTMPTCKTIM);
		TRS.copy(CTMPTCKTIM.FACTORY, sizeof(CTMPTCKTIM.FACTORY), in_node, "FACTORY");
		TRS.copy(CTMPTCKTIM.RES_ID, sizeof(CTMPTCKTIM.RES_ID), in_node, "RES_ID");
		TRS.copy(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID), in_node, "LOC_ID");
		
		if (COM_isspace(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID)) == MP_TRUE)
			memcpy(CTMPTCKTIM.SUB_RES_ID, CTMPTCKTIM.RES_ID, sizeof(CTMPTCKTIM.RES_ID));

		CTMPTCKTIM.TACK_TIME  = COM_atof(TRS.get_string(in_node, "TACK_TIME"), strlen(TRS.get_string(in_node, "TACK_TIME"))); 
		DB_get_systime(CTMPTCKTIM.CREATE_TIME); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE;
		}

		CDB_insert_ctmptcktim(&CTMPTCKTIM); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "RAS-0004"); 
			TRS.add_fieldmsg(out_node, "CTMPTCKTIM INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPTCKTIM.FACTORY), CTMPTCKTIM.FACTORY); 
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CTMPTCKTIM.RES_ID), CTMPTCKTIM.RES_ID); 
			TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CTMPTCKTIM.SUB_RES_ID), CTMPTCKTIM.SUB_RES_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 

		CDB_init_ctmptcktim(&CTMPTCKTIM);
		TRS.copy(CTMPTCKTIM.FACTORY, sizeof(CTMPTCKTIM.FACTORY), in_node, "FACTORY");
		TRS.copy(CTMPTCKTIM.RES_ID, sizeof(CTMPTCKTIM.RES_ID), in_node, "RES_ID");
		TRS.copy(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID), in_node, "LOC_ID");

		if (COM_isspace(CTMPTCKTIM.SUB_RES_ID, sizeof(CTMPTCKTIM.SUB_RES_ID)) == MP_TRUE)
			memcpy(CTMPTCKTIM.SUB_RES_ID, CTMPTCKTIM.RES_ID, sizeof(CTMPTCKTIM.RES_ID));

		dTime = CDB_select_ctmptcktim_scalar(3, &CTMPTCKTIM);
		i_cnt = 1;
		RSUMHOREQP.TOT_TACK_TIME = RSUMHOREQP.TOT_TACK_TIME + dTime;
		RSUMHOREQP.TOT_PROC_TIME = RSUMHOREQP.TOT_PROC_TIME + 1;

		//00~01 
		if ((memcmp(s_actual_time+8, "000000", 6) >= 0) && (memcmp(s_actual_time+8, "010000", 6) < 0))
		{
			RSUMHOREQP.TIME01_TACK = RSUMHOREQP.TIME01_TACK + dTime;
			RSUMHOREQP.TIME01_PROCESS_TIME = RSUMHOREQP.TIME01_PROCESS_TIME + i_cnt;
		}
		//01~02 
		if ((memcmp(s_actual_time+8, "010000", 6) >= 0) && (memcmp(s_actual_time+8, "020000", 6) < 0))
		{
			RSUMHOREQP.TIME02_TACK = RSUMHOREQP.TIME02_TACK + dTime;
			RSUMHOREQP.TIME02_PROCESS_TIME = RSUMHOREQP.TIME02_PROCESS_TIME + i_cnt;
		}
		//02~03 
		if ((memcmp(s_actual_time+8, "020000", 6) >= 0) && (memcmp(s_actual_time+8, "030000", 6) < 0))
		{
			RSUMHOREQP.TIME03_TACK = RSUMHOREQP.TIME03_TACK + dTime;
			RSUMHOREQP.TIME03_PROCESS_TIME = RSUMHOREQP.TIME03_PROCESS_TIME + i_cnt;
		}
		//03~04 
		if ((memcmp(s_actual_time+8, "030000", 6) >= 0) && (memcmp(s_actual_time+8, "040000", 6) < 0))
		{
			RSUMHOREQP.TIME04_TACK = RSUMHOREQP.TIME04_TACK + dTime;
			RSUMHOREQP.TIME04_PROCESS_TIME = RSUMHOREQP.TIME04_PROCESS_TIME + i_cnt;
		}
		//04~05 
		if ((memcmp(s_actual_time+8, "040000", 6) >= 0) && (memcmp(s_actual_time+8, "050000", 6) < 0))
		{
			RSUMHOREQP.TIME05_TACK = RSUMHOREQP.TIME05_TACK + dTime;
			RSUMHOREQP.TIME05_PROCESS_TIME = RSUMHOREQP.TIME05_PROCESS_TIME + i_cnt;
		}
		//05~06 
		if ((memcmp(s_actual_time+8, "050000", 6) >= 0) && (memcmp(s_actual_time+8, "060000", 6) < 0))
		{
			RSUMHOREQP.TIME06_TACK = RSUMHOREQP.TIME06_TACK + dTime;
			RSUMHOREQP.TIME06_PROCESS_TIME = RSUMHOREQP.TIME06_PROCESS_TIME + i_cnt;
		}
		//06~07 
		if ((memcmp(s_actual_time+8, "060000", 6) >= 0) && (memcmp(s_actual_time+8, "070000", 6) < 0))
		{
			RSUMHOREQP.TIME07_TACK = RSUMHOREQP.TIME07_TACK + dTime;
			RSUMHOREQP.TIME07_PROCESS_TIME = RSUMHOREQP.TIME07_PROCESS_TIME + i_cnt;
		}
		//07~08 
		if ((memcmp(s_actual_time+8, "070000", 6) >= 0) && (memcmp(s_actual_time+8, "080000", 6) < 0))
		{
			RSUMHOREQP.TIME08_TACK = RSUMHOREQP.TIME08_TACK + dTime;
			RSUMHOREQP.TIME08_PROCESS_TIME = RSUMHOREQP.TIME08_PROCESS_TIME + i_cnt;
		}
		//08~09 
		if ((memcmp(s_actual_time+8, "080000", 6) >= 0) && (memcmp(s_actual_time+8, "090000", 6) < 0))
		{
			RSUMHOREQP.TIME09_TACK = RSUMHOREQP.TIME09_TACK + dTime;
			RSUMHOREQP.TIME09_PROCESS_TIME = RSUMHOREQP.TIME09_PROCESS_TIME + i_cnt;
		}
		//09~10 
		if ((memcmp(s_actual_time+8, "090000", 6) >= 0) && (memcmp(s_actual_time+8, "100000", 6) < 0))
		{
			RSUMHOREQP.TIME10_TACK = RSUMHOREQP.TIME10_TACK + dTime;
			RSUMHOREQP.TIME10_PROCESS_TIME = RSUMHOREQP.TIME10_PROCESS_TIME + i_cnt;
		}
		//10~11 
		if ((memcmp(s_actual_time+8, "100000", 6) >= 0) && (memcmp(s_actual_time+8, "110000", 6) < 0))
		{
			RSUMHOREQP.TIME11_TACK = RSUMHOREQP.TIME11_TACK + dTime;
			RSUMHOREQP.TIME11_PROCESS_TIME = RSUMHOREQP.TIME11_PROCESS_TIME + i_cnt;
		}
		//11~12
		if ((memcmp(s_actual_time+8, "110000", 6) >= 0) && (memcmp(s_actual_time+8, "120000", 6) < 0))
		{
			RSUMHOREQP.TIME12_TACK = RSUMHOREQP.TIME12_TACK + dTime;
			RSUMHOREQP.TIME12_PROCESS_TIME = RSUMHOREQP.TIME12_PROCESS_TIME + i_cnt;
		}
		//12~13 
		if ((memcmp(s_actual_time+8, "120000", 6) >= 0) && (memcmp(s_actual_time+8, "130000", 6) < 0))
		{
			RSUMHOREQP.TIME13_TACK = RSUMHOREQP.TIME13_TACK + dTime;
			RSUMHOREQP.TIME13_PROCESS_TIME = RSUMHOREQP.TIME13_PROCESS_TIME + i_cnt;
		}
		//13~14 
		if ((memcmp(s_actual_time+8, "130000", 6) >= 0) && (memcmp(s_actual_time+8, "140000", 6) < 0))
		{
			RSUMHOREQP.TIME14_TACK = RSUMHOREQP.TIME14_TACK + dTime;
			RSUMHOREQP.TIME14_PROCESS_TIME = RSUMHOREQP.TIME14_PROCESS_TIME + i_cnt;
		}
		//14~15 
		if ((memcmp(s_actual_time+8, "140000", 6) >= 0) && (memcmp(s_actual_time+8, "150000", 6) < 0))
		{
			RSUMHOREQP.TIME15_TACK = RSUMHOREQP.TIME15_TACK + dTime;
			RSUMHOREQP.TIME15_PROCESS_TIME = RSUMHOREQP.TIME15_PROCESS_TIME + i_cnt;
		}
		//15~16 
		if ((memcmp(s_actual_time+8, "150000", 6) >= 0) && (memcmp(s_actual_time+8, "160000", 6) < 0))
		{
			RSUMHOREQP.TIME16_TACK = RSUMHOREQP.TIME16_TACK + dTime;
			RSUMHOREQP.TIME16_PROCESS_TIME = RSUMHOREQP.TIME16_PROCESS_TIME + i_cnt;
		}
		//16~17 
		if ((memcmp(s_actual_time+8, "160000", 6) >= 0) && (memcmp(s_actual_time+8, "170000", 6) < 0))
		{
			RSUMHOREQP.TIME17_TACK = RSUMHOREQP.TIME17_TACK + dTime;
			RSUMHOREQP.TIME17_PROCESS_TIME = RSUMHOREQP.TIME17_PROCESS_TIME + i_cnt;
		}
		//17~18 
		if ((memcmp(s_actual_time+8, "170000", 6) >= 0) && (memcmp(s_actual_time+8, "180000", 6) < 0))
		{
			RSUMHOREQP.TIME18_TACK = RSUMHOREQP.TIME18_TACK + dTime;
			RSUMHOREQP.TIME18_PROCESS_TIME = RSUMHOREQP.TIME18_PROCESS_TIME + i_cnt;
		}
		//18~19 
		if ((memcmp(s_actual_time+8, "180000", 6) >= 0) && (memcmp(s_actual_time+8, "190000", 6) < 0))
		{
			RSUMHOREQP.TIME19_TACK = RSUMHOREQP.TIME19_TACK + dTime;
			RSUMHOREQP.TIME19_PROCESS_TIME = RSUMHOREQP.TIME19_PROCESS_TIME + i_cnt;
		}
		//19~20 
		if ((memcmp(s_actual_time+8, "190000", 6) >= 0) && (memcmp(s_actual_time+8, "200000", 6) < 0))
		{
			RSUMHOREQP.TIME20_TACK = RSUMHOREQP.TIME20_TACK + dTime;
			RSUMHOREQP.TIME20_PROCESS_TIME = RSUMHOREQP.TIME20_PROCESS_TIME + i_cnt;
		}
		//20~21 
		if ((memcmp(s_actual_time+8, "200000", 6) >= 0) && (memcmp(s_actual_time+8, "210000", 6) < 0))
		{
			RSUMHOREQP.TIME21_TACK = RSUMHOREQP.TIME21_TACK + dTime;
			RSUMHOREQP.TIME21_PROCESS_TIME = RSUMHOREQP.TIME21_PROCESS_TIME + i_cnt;
		}
		//21~22 
		if ((memcmp(s_actual_time+8, "210000", 6) >= 0) && (memcmp(s_actual_time+8, "220000", 6) < 0))
		{
			RSUMHOREQP.TIME22_TACK = RSUMHOREQP.TIME22_TACK + dTime;
			RSUMHOREQP.TIME22_PROCESS_TIME = RSUMHOREQP.TIME22_PROCESS_TIME + i_cnt;
		}
		//22~23 
		if ((memcmp(s_actual_time+8, "220000", 6) >= 0) && (memcmp(s_actual_time+8, "230000", 6) < 0))
		{
			RSUMHOREQP.TIME23_TACK = RSUMHOREQP.TIME23_TACK + dTime;
			RSUMHOREQP.TIME23_PROCESS_TIME = RSUMHOREQP.TIME23_PROCESS_TIME + i_cnt;
		}
		//23~24 
		if ((memcmp(s_actual_time+8, "230000", 6) >= 0) && (memcmp(s_actual_time+8, "240000", 6) < 0))
		{
			RSUMHOREQP.TIME24_TACK = RSUMHOREQP.TIME24_TACK + dTime;
			RSUMHOREQP.TIME24_PROCESS_TIME = RSUMHOREQP.TIME24_PROCESS_TIME + i_cnt;
		}

		CDB_update_rsumhoreqp(1, &RSUMHOREQP);
		if (DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}

	//ISSUE-11-086	Tack Time ¼öÁý Table Ãß°¡
	// Top 5 µ¥ÀÌÅÍ¸¸ ¼öÁýÇÏ°í ÇØ´ç µ¥ÀÌÅÍ ¼øÀ§°¡ °»½ÅµÇ¸é ÀÌÀü µ¥ÀÌÅÍ´Â »èÁ¦ÇÏ°í ½Å±Ô µ¥ÀÌÅÍ INSERT
	// DELETE ¸ÕÀúÇÏ°í INSERT ÇØ¾ß DB¿ë·® Áõ°¡ÇÏÁö ¾Ê´Â´Ù.

	// ¼öÁý °¹¼ö Áõ°¡ÇÏ·Á¸é ¼ýÀÚ º¯°æÇÑ´Ù. GCM¿¡ ³ÖÀ»°¡ ÇßÁö¸¸ ÀÏ´Ü ¿©±â¿¡ ¼Â¾÷ÇÔ.
	i_collect_count = 5;
	
	CDB_init_cwiptcktim(&CWIPTCKTIM);
	memcpy(CWIPTCKTIM.FACTORY, RSUMHOREQP.FACTORY, sizeof(CWIPTCKTIM.FACTORY));
	memcpy(CWIPTCKTIM.WORK_DATE, cur_work_time.work_date, sizeof(CWIPTCKTIM.WORK_DATE));
	CWIPTCKTIM.WORK_SHIFT[0] = c_shift;	
	memcpy(CWIPTCKTIM.LINE_ID, RSUMHOREQP.LINE_ID, sizeof(CWIPTCKTIM.LINE_ID));
	memcpy(CWIPTCKTIM.RES_ID, RSUMHOREQP.RES_ID, sizeof(CWIPTCKTIM.RES_ID));
	memcpy(CWIPTCKTIM.SUB_RES_ID, RSUMHOREQP.SUB_RES_ID, sizeof(CWIPTCKTIM.SUB_RES_ID));
	memcpy(CWIPTCKTIM.MAT_ID, RSUMHOREQP.MAT_ID, sizeof(CWIPTCKTIM.MAT_ID));
	memcpy(CWIPTCKTIM.ORDER_ID, RSUMHOREQP.ORDER_ID, sizeof(CWIPTCKTIM.ORDER_ID));
	memcpy(CWIPTCKTIM.TRAN_TIME, s_sys_time_stamp, sizeof(CWIPTCKTIM.TRAN_TIME));
	CWIPTCKTIM.TACK_TIME = COM_atof(TRS.get_string(in_node, "TACK_TIME"), strlen(TRS.get_string(in_node, "TACK_TIME"))); 

	//21.03.15 IS-21-03-025 EAPMES_Get_Process_Tack_Time - Request Update 
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "@TACK_TIME_FILTER", strlen("@TACK_TIME_FILTER"));
	memcpy(MGCMTBLDAT.KEY_1, RSUMHOREQP.RES_ID, sizeof(RSUMHOREQP.RES_ID));
	memcpy(MGCMTBLDAT.KEY_2, RSUMHOREQP.LINE_ID, sizeof(RSUMHOREQP.LINE_ID));
	memcpy(MGCMTBLDAT.KEY_3, RSUMHOREQP.OPER, sizeof(RSUMHOREQP.OPER));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	
	c_value_keep = ' ';
		
    if(DB_error_code == DB_SUCCESS && COM_isnullspace(MGCMTBLDAT.DATA_1) == MP_FALSE && COM_isnullspace(MGCMTBLDAT.DATA_2) == MP_FALSE)
	{
		dtack_filter_value = 0;
		/*
		if(RSUMHOREQP.TOT_TACK_TIME > 0 && RSUMHOREQP.TOT_PROC_TIME > 0)
		{
			dtack_filter_value = RSUMHOREQP.TOT_TACK_TIME / RSUMHOREQP.TOT_PROC_TIME;
		}
		*/

		// IS-21-03-080 EAPMES_Get_Process_Tack_Time Ãß°¡¿äÃ» ´ëÀÀ
		dtack_filter_value = CWIPTCKTIM.TACK_TIME;

		filter_max = 0 ;
		filter_min = 0;
		filter_min = COM_atoi(MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		filter_max = COM_atoi(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));

		if((int)dtack_filter_value >=filter_min && (int)dtack_filter_value <=filter_max)
		{
			c_value_keep = ' ';
		}	
		else
		{
			c_value_keep = 'X';
		}

	}

	if(c_value_keep == 'X')	//ÇØ´ç °ªÀÌ ±¸°£¿¡ Á¸Àç ÇÏÁö ¾ÊÀ¸¸é CWIPTCKTIM Å×ÀÌºí¿¡ µ¥ÀÌÅÍ°¡ ÀúÀåµÇÁö ¾ÊÀ½
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}



	
		

	//21.03.15 
	
	// FACTORY, WORK_DATE, WORK_SHIFT, LINE_ID, RES_ID, SUB_RES_ID, MAT_ID, ORDER_ID ±âÁØÀ¸·Î ÇöÀç ÀúÀåµÈ DATA COUNT Á¶È¸ÇÑ´Ù.
	d_total_data_count = CDB_select_cwiptcktim_scalar(2, &CWIPTCKTIM);


	// Á¶È¸µÈ °¹¼ö°¡ collect count º¸´Ù ÀÛÀº °æ¿ì.
	// ÀÌ¶§ insert µÈ total count °¡ collect count º¸´Ù ÀÛÀ¸¸é »èÁ¦ ÇÏÁö ¾Ê°í insert¸¸,
	// ±×·¸Áö ¾Ê°í ¼öÁý °¹¼ö ÀÌ»óÀÌ¸é ¸¶Áö¸· MAX °ªÀ» »èÁ¦ ÇÑ´Ù.
	if (d_total_data_count < i_collect_count)
	{
		CDB_insert_cwiptcktim(&CWIPTCKTIM);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "RAS-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPTCKTIM INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTCKTIM.FACTORY), CWIPTCKTIM.FACTORY); 
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTCKTIM.WORK_DATE), CWIPTCKTIM.WORK_DATE); 
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTCKTIM.WORK_SHIFT), CWIPTCKTIM.WORK_SHIFT); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTCKTIM.LINE_ID), CWIPTCKTIM.LINE_ID); 
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPTCKTIM.RES_ID), CWIPTCKTIM.RES_ID); 
			TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CWIPTCKTIM.SUB_RES_ID), CWIPTCKTIM.SUB_RES_ID); 
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPTCKTIM.MAT_ID), CWIPTCKTIM.MAT_ID); 
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPTCKTIM.ORDER_ID), CWIPTCKTIM.ORDER_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
	}
	else
	{
		// ¼öÁý °¹¼ö ÀÌ»óÀÏ¶§ ±âÁ¸¿¡ ÀÔ·Â ¹ÞÀº TACK_TIME °ªÀ» ºñ±³ÇÏ¿© Ã³¸®ÇÑ´Ù.
		d_data_count = CDB_select_cwiptcktim_scalar(3, &CWIPTCKTIM);

		if (d_data_count < i_collect_count)
		{			
			CDB_init_cwiptcktim(&CWIPTCKTIM_DEL);
			memcpy(CWIPTCKTIM_DEL.FACTORY, CWIPTCKTIM.FACTORY, sizeof(CWIPTCKTIM_DEL.FACTORY));
			memcpy(CWIPTCKTIM_DEL.WORK_DATE, CWIPTCKTIM.WORK_DATE, sizeof(CWIPTCKTIM_DEL.WORK_DATE));
			memcpy(CWIPTCKTIM_DEL.WORK_SHIFT, CWIPTCKTIM.WORK_SHIFT, sizeof(CWIPTCKTIM_DEL.WORK_SHIFT));
			memcpy(CWIPTCKTIM_DEL.LINE_ID, CWIPTCKTIM.LINE_ID, sizeof(CWIPTCKTIM_DEL.LINE_ID));
			memcpy(CWIPTCKTIM_DEL.RES_ID, CWIPTCKTIM.RES_ID, sizeof(CWIPTCKTIM_DEL.RES_ID));
			memcpy(CWIPTCKTIM_DEL.SUB_RES_ID, CWIPTCKTIM.SUB_RES_ID, sizeof(CWIPTCKTIM_DEL.SUB_RES_ID));
			memcpy(CWIPTCKTIM_DEL.MAT_ID, CWIPTCKTIM.MAT_ID, sizeof(CWIPTCKTIM_DEL.MAT_ID));
			memcpy(CWIPTCKTIM_DEL.ORDER_ID, CWIPTCKTIM.ORDER_ID, sizeof(CWIPTCKTIM_DEL.ORDER_ID));						

			// ÇöÀç ÀÔ·ÂµÈ °ª Áß TACK TIME ÀÌ Á¦ÀÏ Å« µ¥ÀÌÅÍ Á¶È¸
			CDB_select_cwiptcktim(2, &CWIPTCKTIM_DEL);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "RAS-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPTCKTIM DELETE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTCKTIM.FACTORY), CWIPTCKTIM.FACTORY); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTCKTIM.WORK_DATE), CWIPTCKTIM.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTCKTIM.WORK_SHIFT), CWIPTCKTIM.WORK_SHIFT); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTCKTIM.LINE_ID), CWIPTCKTIM.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPTCKTIM.RES_ID), CWIPTCKTIM.RES_ID); 
				TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CWIPTCKTIM.SUB_RES_ID), CWIPTCKTIM.SUB_RES_ID); 
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPTCKTIM.MAT_ID), CWIPTCKTIM.MAT_ID); 
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPTCKTIM.ORDER_ID), CWIPTCKTIM.ORDER_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

			// ¸ÕÀú MAX°ª »èÁ¦ºÎÅÍ ÇÏ°í
			CDB_delete_cwiptcktim(1, &CWIPTCKTIM_DEL);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "RAS-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPTCKTIM DELETE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTCKTIM.FACTORY), CWIPTCKTIM.FACTORY); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTCKTIM.WORK_DATE), CWIPTCKTIM.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTCKTIM.WORK_SHIFT), CWIPTCKTIM.WORK_SHIFT); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTCKTIM.LINE_ID), CWIPTCKTIM.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPTCKTIM.RES_ID), CWIPTCKTIM.RES_ID); 
				TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CWIPTCKTIM.SUB_RES_ID), CWIPTCKTIM.SUB_RES_ID); 
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPTCKTIM.MAT_ID), CWIPTCKTIM.MAT_ID); 
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPTCKTIM.ORDER_ID), CWIPTCKTIM.ORDER_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

			// ½Å±Ô °ª ÀÔ·Â
			CDB_insert_cwiptcktim(&CWIPTCKTIM);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "RAS-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPTCKTIM INSERT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPTCKTIM.FACTORY), CWIPTCKTIM.FACTORY); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTCKTIM.WORK_DATE), CWIPTCKTIM.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTCKTIM.WORK_SHIFT), CWIPTCKTIM.WORK_SHIFT); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTCKTIM.LINE_ID), CWIPTCKTIM.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPTCKTIM.RES_ID), CWIPTCKTIM.RES_ID); 
				TRS.add_fieldmsg(out_node, "SUB_RES_ID", MP_STR, sizeof(CWIPTCKTIM.SUB_RES_ID), CWIPTCKTIM.SUB_RES_ID); 
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPTCKTIM.MAT_ID), CWIPTCKTIM.MAT_ID); 
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPTCKTIM.ORDER_ID), CWIPTCKTIM.ORDER_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}
		}
		else
		{
			// ±âÁ¸ °ªµéº¸´Ù Å©¸é Ã³¸® ¾ÈÇÔ
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Get_Process_Tack_Time_Validation()
        - Main sub function of "EAPMES_GET_PROCESS_TACK_TIME" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Get_Process_Tack_Time_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

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

