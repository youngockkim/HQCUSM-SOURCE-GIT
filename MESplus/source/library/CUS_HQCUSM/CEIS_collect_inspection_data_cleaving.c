/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_inspection_data_cleaving.c
    Description : EAPMES Collect Inspection Data for Cleaving Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Inspection_Data_Cleaving()
            + Setup service interface function
        - EAPMES_COLLECT_INSPECTION_DATA_CLEAVING()
            + Main sub function of EAPMES_Collect_Inspection_Data_Cleaving function
            + Setup service main business function
        - EAPMES_Collect_Inspection_Data_Cleaving_Validation()
            + Main sub function of EAPMES_COLLECT_INSPECTION_DATA_CLEAVING function
    Detail Description
        - EAPMES_COLLECT_INSPECTION_DATA_CLEAVING()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Inspection_Data_Cleaving_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Cleaving()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Cleaving(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_INSPECTION_DATA_CLEAVING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_INSPECTION_DATA_CLEAVING", out_node);

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
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Inspection_Data_Cleaving", 
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
    //CEIS_Save_Message_Log_For_List(in_node, out_node);
    CEIS_Save_Message_Log_For_Single_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_INSPECTION_DATA_CLEAVING()
        - Main sub function of "EAPMES_Collect_Inspection_Data_Cleaving" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_INSPECTION_DATA_CLEAVING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct RSUMHORCLV_TAG RSUMHORCLV;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPORDSTS_TAG MWIPORDSTS;

    char s_sys_time_stamp[20];  
    char s_sys_time[17];
    char s_actual_time[14];
	struct worktime_tag cur_work_time;
	char c_shift;

	int i_cnt = 0;
    
    LOG_head("EAPMES_COLLECT_INSPECTION_DATA_CLEAVING");
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

	/* CURRENT TIME   */
	memset(s_actual_time, ' ', sizeof(s_actual_time));
	TRS.copy(s_actual_time, sizeof(s_actual_time), in_node, "CLIENT_TIME");
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	/* CURRENT SHIFT GET */
	c_shift = CCOM_get_work_shift(s_sys_time);

	//RESOURCE SELECT
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "RAS-0044");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "RES ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
	}

	/* ORDER ID */
    DBC_init_mwipordsts(&MWIPORDSTS);
    TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");

	if (COM_isspace(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID)) == MP_TRUE)
	{
		memcpy(MWIPORDSTS.ORDER_ID, MRASRESDEF.RES_CMF_9, sizeof(MWIPORDSTS.ORDER_ID));
	}
    DBC_select_mwipordsts(1, &MWIPORDSTS);
    if(DB_error_code != DB_SUCCESS)
	{
		//작업지시 없으면 에러처리함.
		strcpy(s_msg_code, "ORD-0002");
		TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
		TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	if (strcmp(TRS.get_string(in_node, "RESULT"), "NG") != 0)
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}
	

    /* CLEAVING 의 INSPECTION DATA : NG 만 올라옮 -> QTY_1 에 저장함.*/
	CDB_init_rsumhorclv(&RSUMHORCLV);
	/*************************************************************/
	/*시간별 데이터 처리.*/
	/*************************************************************/
    TRS.copy(RSUMHORCLV.FACTORY, sizeof(RSUMHORCLV.FACTORY), in_node, "FACTORY");
	memcpy(RSUMHORCLV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMHORCLV.WORK_DATE));
	RSUMHORCLV.WORK_SHIFT[0] = c_shift;
	memcpy(RSUMHORCLV.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(RSUMHORCLV.LINE_ID));
	if (COM_isspace(RSUMHORCLV.LINE_ID, sizeof(RSUMHORCLV.LINE_ID)) == MP_TRUE)
		TRS.copy(RSUMHORCLV.LINE_ID, sizeof(RSUMHORCLV.FACTORY), in_node, "LINE_ID");

	memcpy(RSUMHORCLV.RES_ID, MRASRESDEF.RES_ID, sizeof(RSUMHORCLV.RES_ID));
	
	//TODO.신규 클리빙 VISION INSPECTION
	//LD, ULD, MP(?), ULDV(신규 VISION 으로 올라올 SUB RES ID) 
	TRS.copy(RSUMHORCLV.SUB_RES_ID, sizeof(RSUMHORCLV.SUB_RES_ID), in_node, "EQP_TYPE");

	if (COM_isspace(RSUMHORCLV.SUB_RES_ID, sizeof(RSUMHORCLV.SUB_RES_ID)) == MP_TRUE)
		memcpy(RSUMHORCLV.SUB_RES_ID, MRASRESDEF.RES_ID, sizeof(RSUMHORCLV.RES_ID));

	memcpy(RSUMHORCLV.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(RSUMHORCLV.MAT_ID));
	memcpy(RSUMHORCLV.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(RSUMHORCLV.ORDER_ID));

	memcpy(RSUMHORCLV.OPER, MRASRESDEF.RES_CMF_2, sizeof(RSUMHORCLV.OPER));
	TRS.copy(RSUMHORCLV.CELL_GRADE, sizeof(RSUMHORCLV.CELL_GRADE), in_node, "QUALIFY_GRADE");
	TRS.copy(RSUMHORCLV.CELL_POWER, sizeof(RSUMHORCLV.CELL_POWER), in_node, "POWER_GRADE");
	TRS.copy(RSUMHORCLV.CM_KEY_1, sizeof(RSUMHORCLV.CELL_POWER), in_node, "TOOL_MODE");

	//TODO.신규 클리빙 VISION INSPECTION
	//DEFECT CODE 아래처럼 키값으로 넣어주면 집계로직 해결될걸로 예상됨.
	//TRS.copy(RSUMHORCLV.CM_KEY_2, sizeof(RSUMHORCLV.CM_KEY_2), in_node, "DEFECT_CODE");
	
	CDB_select_rsumhorclv(1, &RSUMHORCLV);
	if (DB_error_code != DB_SUCCESS)
	{
		CDB_insert_rsumhorclv(&RSUMHORCLV);
	}
	
	i_cnt = 1;
	RSUMHORCLV.TOT_QTY_1 = RSUMHORCLV.TOT_QTY_1 + i_cnt;

	//00~01 
	if ((memcmp(s_actual_time+8, "000000", 6) >= 0) && (memcmp(s_actual_time+8, "010000", 6) < 0))
	{
		RSUMHORCLV.TIME01_QTY_1 = RSUMHORCLV.TIME01_QTY_1 + i_cnt;
	}
	//01~02 
	if ((memcmp(s_actual_time+8, "010000", 6) >= 0) && (memcmp(s_actual_time+8, "020000", 6) < 0))
	{
		RSUMHORCLV.TIME02_QTY_1 = RSUMHORCLV.TIME02_QTY_1 + i_cnt;
	}
	//02~03 
	if ((memcmp(s_actual_time+8, "020000", 6) >= 0) && (memcmp(s_actual_time+8, "030000", 6) < 0))
	{
		RSUMHORCLV.TIME03_QTY_1 = RSUMHORCLV.TIME03_QTY_1 + i_cnt;
	}
	//03~04 
	if ((memcmp(s_actual_time+8, "030000", 6) >= 0) && (memcmp(s_actual_time+8, "040000", 6) < 0))
	{
		RSUMHORCLV.TIME04_QTY_1 = RSUMHORCLV.TIME04_QTY_1 + i_cnt;
	}
	//04~05 
	if ((memcmp(s_actual_time+8, "040000", 6) >= 0) && (memcmp(s_actual_time+8, "050000", 6) < 0))
	{
		RSUMHORCLV.TIME05_QTY_1 = RSUMHORCLV.TIME05_QTY_1 + i_cnt;
	}
	//05~06 
	if ((memcmp(s_actual_time+8, "050000", 6) >= 0) && (memcmp(s_actual_time+8, "060000", 6) < 0))
	{
		RSUMHORCLV.TIME06_QTY_1 = RSUMHORCLV.TIME06_QTY_1 + i_cnt;
	}
	//06~07 
	if ((memcmp(s_actual_time+8, "060000", 6) >= 0) && (memcmp(s_actual_time+8, "070000", 6) < 0))
	{
		RSUMHORCLV.TIME07_QTY_1 = RSUMHORCLV.TIME07_QTY_1 + i_cnt;
	}
	//07~08 
	if ((memcmp(s_actual_time+8, "070000", 6) >= 0) && (memcmp(s_actual_time+8, "080000", 6) < 0))
	{
		RSUMHORCLV.TIME08_QTY_1 = RSUMHORCLV.TIME08_QTY_1 + i_cnt;
	}
	//08~09 
	if ((memcmp(s_actual_time+8, "080000", 6) >= 0) && (memcmp(s_actual_time+8, "090000", 6) < 0))
	{
		RSUMHORCLV.TIME09_QTY_1 = RSUMHORCLV.TIME09_QTY_1 + i_cnt;
	}
	//09~10 
	if ((memcmp(s_actual_time+8, "090000", 6) >= 0) && (memcmp(s_actual_time+8, "100000", 6) < 0))
	{
		RSUMHORCLV.TIME10_QTY_1 = RSUMHORCLV.TIME10_QTY_1 + i_cnt;
	}
	//10~11 
	if ((memcmp(s_actual_time+8, "100000", 6) >= 0) && (memcmp(s_actual_time+8, "110000", 6) < 0))
	{
		RSUMHORCLV.TIME11_QTY_1 = RSUMHORCLV.TIME11_QTY_1 + i_cnt;
	}
	//11~12
	if ((memcmp(s_actual_time+8, "110000", 6) >= 0) && (memcmp(s_actual_time+8, "120000", 6) < 0))
	{
		RSUMHORCLV.TIME12_QTY_1 = RSUMHORCLV.TIME12_QTY_1 + i_cnt;
	}
	//12~13 
	if ((memcmp(s_actual_time+8, "120000", 6) >= 0) && (memcmp(s_actual_time+8, "130000", 6) < 0))
	{
		RSUMHORCLV.TIME13_QTY_1 = RSUMHORCLV.TIME13_QTY_1 + i_cnt;
	}
	//13~14 
	if ((memcmp(s_actual_time+8, "130000", 6) >= 0) && (memcmp(s_actual_time+8, "140000", 6) < 0))
	{
		RSUMHORCLV.TIME14_QTY_1 = RSUMHORCLV.TIME14_QTY_1 + i_cnt;
	}
	//14~15 
	if ((memcmp(s_actual_time+8, "140000", 6) >= 0) && (memcmp(s_actual_time+8, "150000", 6) < 0))
	{
		RSUMHORCLV.TIME15_QTY_1 = RSUMHORCLV.TIME15_QTY_1 + i_cnt;
	}
	//15~16 
	if ((memcmp(s_actual_time+8, "150000", 6) >= 0) && (memcmp(s_actual_time+8, "160000", 6) < 0))
	{
		RSUMHORCLV.TIME16_QTY_1 = RSUMHORCLV.TIME16_QTY_1 + i_cnt;
	}
	//16~17 
	if ((memcmp(s_actual_time+8, "160000", 6) >= 0) && (memcmp(s_actual_time+8, "170000", 6) < 0))
	{
		RSUMHORCLV.TIME17_QTY_1 = RSUMHORCLV.TIME17_QTY_1 + i_cnt;
	}
	//17~18 
	if ((memcmp(s_actual_time+8, "170000", 6) >= 0) && (memcmp(s_actual_time+8, "180000", 6) < 0))
	{
		RSUMHORCLV.TIME18_QTY_1 = RSUMHORCLV.TIME18_QTY_1 + i_cnt;
	}
	//18~19 
	if ((memcmp(s_actual_time+8, "180000", 6) >= 0) && (memcmp(s_actual_time+8, "190000", 6) < 0))
	{
		RSUMHORCLV.TIME19_QTY_1 = RSUMHORCLV.TIME19_QTY_1 + i_cnt;
	}
	//19~20 
	if ((memcmp(s_actual_time+8, "190000", 6) >= 0) && (memcmp(s_actual_time+8, "200000", 6) < 0))
	{
		RSUMHORCLV.TIME20_QTY_1 = RSUMHORCLV.TIME20_QTY_1 + i_cnt;
	}
	//20~21 
	if ((memcmp(s_actual_time+8, "200000", 6) >= 0) && (memcmp(s_actual_time+8, "210000", 6) < 0))
	{
		RSUMHORCLV.TIME21_QTY_1 = RSUMHORCLV.TIME21_QTY_1 + i_cnt;
	}
	//21~22 
	if ((memcmp(s_actual_time+8, "210000", 6) >= 0) && (memcmp(s_actual_time+8, "220000", 6) < 0))
	{
		RSUMHORCLV.TIME22_QTY_1 = RSUMHORCLV.TIME22_QTY_1 + i_cnt;
	}
	//22~23 
	if ((memcmp(s_actual_time+8, "220000", 6) >= 0) && (memcmp(s_actual_time+8, "230000", 6) < 0))
	{
		RSUMHORCLV.TIME23_QTY_1 = RSUMHORCLV.TIME23_QTY_1 + i_cnt;
	}
	//23~24 
	if ((memcmp(s_actual_time+8, "230000", 6) >= 0) && (memcmp(s_actual_time+8, "240000", 6) < 0))
	{
		RSUMHORCLV.TIME24_QTY_1 = RSUMHORCLV.TIME24_QTY_1 + i_cnt;
	}

	CDB_update_rsumhorclv(1, &RSUMHORCLV);
	if (DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Cleaving_Validation()
        - Main sub function of "EAPMES_COLLECT_INSPECTION_DATA_CLEAVING" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Cleaving_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    
    return MP_TRUE;
}

