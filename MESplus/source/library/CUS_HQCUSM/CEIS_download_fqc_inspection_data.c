/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_download_fqc_inspection_data.c
    Description : EAPMES Download FQC Inspection Data for String Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Download_Fqc_Inspection_Data()
            + Setup service interface function
        - EAPMES_DOWNLOAD_FQC_INSPECTION_DATA()
            + Main sub function of EAPMES_Download_Fqc_Inspection_Data function
            + Setup service main business function
        - EAPMES_Download_Fqc_Inspection_Data_Validation()
            + Main sub function of EAPMES_DOWNLOAD_FQC_INSPECTION_DATA function
    Detail Description
        - EAPMES_DOWNLOAD_FQC_INSPECTION_DATA()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019/05/24  Hanchang       Created

    Copyright(C) 1998-2019 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Download_Fqc_Inspection_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Download_Fqc_Inspection_Data()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Download_Fqc_Inspection_Data(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;
	TRSNode *event_in_node;
	TRSNode *event_out_node;
	
	//TRSNode *empty_node;
	
    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");
	event_in_node = TRS.create_node("EVENT_IN_NODE");
	event_out_node = TRS.create_node("EVENT_OUT_NODE");
	//empty_node = TRS.create_node("EMPTY_NODE");
	CCOM_copy_in_node(in_node, event_in_node);

	TRS.add_nstring(out_node, OUT_MSGCODE, " ");
	TRS.add_nstring(out_node, OUT_MSG, " " );
	TRS.add_nstring(out_node, OUT_FIELDMSG, " ");
	TRS.add_nstring(out_node, OUT_DBERRMSG, " ");
	TRS.add_nstring(out_node, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
	
    i_ret = EAPMES_DOWNLOAD_FQC_INSPECTION_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_DOWNLOAD_FQC_INSPECTION_DATA", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    }
    else
    {
        DB_rollback();
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    }


    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

    /* Common Data */
    //CCOM_copy_in_node(in_node, out_node);
	

    /* Additional Data 
    TRS.set_nstring(out_node, "STRING_ID", TRS.get_string(in_node, "STRING_ID"));
    TRS.set_nstring(out_node, "RESULT", TRS.get_string(in_node, "RESULT"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));
    TRS.set_nstring(out_node, "INSP_ZONE", TRS.get_string(in_node, "INSP_ZONE"));
	*/
	/* MES to EAP */

	if(i_ret == MP_TRUE)
	{
		memset(s_channel, 0x00, sizeof(s_channel));
		sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
		//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
		strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
		COM_add_null(s_channel, sizeof(s_channel));
    
	 
		if(CallService(MODULE_EAP, 
			"MESEAP_Download_Fqc_Inspection_Data", 
			out_node, 
			0x00, 
			s_channel, 
			gi_default_ttl, 
			DM_UNICAST) != MP_TRUE)
		{
			// Error
		}
	}

	/* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    //CEIS_Save_Message_Log(in_node, out_node);
    CEIS_Save_Message_Log_For_List(in_node, out_node);

	TRS.free_node(out_node);
	
	TRS.set_nstring(event_in_node, "IN_SERVICE_NAME", "EAPMES_COLLECT_RESOURCE_EVENT");
	TRS.set_nstring(event_in_node, "CLIENT_TIME", TRS.get_string(in_node, "CLIENT_TIME"));
    TRS.set_nstring(event_in_node, "CLIENT_ID", TRS.get_string(in_node, "CLIENT_ID"));
    TRS.set_char(event_in_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(event_in_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(event_in_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.add_nstring(event_in_node, "CEID","210");
    TRS.set_nstring(event_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(event_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	TRS.set_nstring(event_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
  
	//후단 재작업 Count
	TRS.init_node(event_out_node);
	
	if (EAPMES_COLLECT_RESOURCE_EVENT(s_msg_code, event_in_node, event_out_node) == MP_FALSE)
	{
		//DO Nothing
	}

	TRS.free_node(event_in_node);
	TRS.free_node(event_out_node);
    return MP_TRUE;
}


/*******************************************************************************
    EAPMES_DOWNLOAD_FQC_INSPECTION_DATA()
        - Main sub function of "EAPMES_Download_Fqc_Inspection_Data" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_DOWNLOAD_FQC_INSPECTION_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CEDCLOTRLT_TAG CEDCLOTRLT; 
	struct CEDCLOTRLT_TAG CEDCLOTRLT_S; 
	struct CEDCLOTRLH_TAG CEDCLOTRLH_C;
	struct CEDCLOTFQC_TAG CEDCLOTFQC; 
	struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CWIPFQCDWN_TAG CWIPFQCDWN;

	char s_sys_time_stamp[20];  
    char s_sys_time[17];
	char cim_time[17];

	TRSNode *list_aoi_item;
	TRSNode *list_bel_item;

	TRSNode *param_item;

	LOG_head("EAPMES_COLLECT_INSPECTION_DATA_STRING");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  
	memset(cim_time, '0', sizeof(cim_time));  

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

	//fqc download history
	CDB_init_cwipfqcdwn(&CWIPFQCDWN);
	TRS.copy(CWIPFQCDWN.FACTORY, sizeof(CWIPFQCDWN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPFQCDWN.LOT_ID, sizeof(CWIPFQCDWN.LOT_ID), in_node, "LOT_ID");
	TRS.copy(CWIPFQCDWN.RES_ID, sizeof(CWIPFQCDWN.RES_ID), in_node, "RES_ID");
	TRS.copy(CWIPFQCDWN.CIM_ID, sizeof(CWIPFQCDWN.CIM_ID), in_node, "CIM_ID");
	TRS.copy(CWIPFQCDWN.SYS_TRAN_TIME, sizeof(CWIPFQCDWN.SYS_TRAN_TIME), in_node, "SYS_TRAN_TIME");
	TRS.copy(CWIPFQCDWN.CLIENT_TIME, sizeof(CWIPFQCDWN.CLIENT_TIME), in_node, "CLIENT_TIME");
	TRS.copy(CWIPFQCDWN.CLIENT_ID, sizeof(CWIPFQCDWN.CLIENT_ID), in_node, "CLIENT_ID");
	TRS.copy(CWIPFQCDWN.CREATE_USER_ID, sizeof(CWIPFQCDWN.CREATE_USER_ID), in_node, "CLIENT_ID");
	memcpy(CWIPFQCDWN.CREATE_TIME, s_sys_time, sizeof(CWIPFQCDWN.CREATE_TIME));
	TRS.copy(CWIPFQCDWN.UPDATE_USER_ID, sizeof(CWIPFQCDWN.UPDATE_USER_ID), in_node, "CLIENT_ID");
	memcpy(CWIPFQCDWN.UPDATE_TIME, s_sys_time, sizeof(CWIPFQCDWN.UPDATE_TIME));

	CDB_insert_cwipfqcdwn(&CWIPFQCDWN);

	/* Lot Information */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
            
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0573");
        TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
		
		gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
		COM_set_result(out_node, MP_FAIL_C, "WIP-0573", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/* Check Resource */
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
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

	// FQC 
	TRS.add_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	
	CDB_init_cedclotfqc(&CEDCLOTFQC);
	TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
    TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
	/*
SELECT * FROM CEDCLOTFQC WHERE LOT_ID = '203619214520401943'
                        AND INS_SEQ = (SELECT INS_CNT
                                       FROM CEDCLOTRLT 
                                       WHERE FACTORY = 'USGAM1' AND INS_TYPE = 'FC'
                                       AND LOT_ID = '203619214520401943' );
*/	
	
	CDB_select_cedclotfqc(2, &CEDCLOTFQC);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO Nothing

	    }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CEDCLOTFQC SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTFQC.FACTORY), CEDCLOTFQC.FACTORY);
            TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTFQC.INS_TYPE), CEDCLOTFQC.INS_TYPE);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTFQC.LOT_ID), CEDCLOTFQC.LOT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }


	if(CEDCLOTFQC.AOI_RESULT[0] == ' ')
	{
		CDB_init_cedclotrlt(&CEDCLOTRLT);
		TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_ET, strlen(HQCEL_INS_TYPE_CATEGORY_ET));
		TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");

		CDB_select_cedclotrlt(1, &CEDCLOTRLT);
		if(DB_error_code != DB_SUCCESS)
		{
		}

		TRS.add_string(out_node, "AOI_RES",   CEDCLOTRLT.RESULT_VALUE,sizeof(CEDCLOTRLT.RESULT_VALUE));  
	}
	else
	{
		TRS.add_string(out_node, "AOI_RES",   CEDCLOTFQC.AOI_RESULT,sizeof(CEDCLOTFQC.AOI_RESULT));  
	}
	
	//HIPOT
	CDB_init_cedclotrlt(&CEDCLOTRLT_S);
	TRS.copy(CEDCLOTRLT_S.FACTORY, sizeof(CEDCLOTRLT_S.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTRLT_S.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_HIPOT, strlen(HQCEL_INS_TYPE_CATEGORY_HIPOT));
    TRS.copy(CEDCLOTRLT_S.LOT_ID, sizeof(CEDCLOTRLT_S.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT_S);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO Nothing
	    }
	}
	TRS.add_string(out_node, "HV_RES",   CEDCLOTRLT_S.RESULT_VALUE,sizeof(CEDCLOTRLT_S.RESULT_VALUE));  

	//GROUND
	CDB_init_cedclotrlt(&CEDCLOTRLT_S);
	TRS.copy(CEDCLOTRLT_S.FACTORY, sizeof(CEDCLOTRLT_S.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTRLT_S.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_GROUND, strlen(HQCEL_INS_TYPE_CATEGORY_GROUND));
    TRS.copy(CEDCLOTRLT_S.LOT_ID, sizeof(CEDCLOTRLT_S.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT_S);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO Nothing
	    }
	}
	TRS.add_string(out_node, "GT_RES",    CEDCLOTRLT_S.RESULT_VALUE,sizeof(CEDCLOTRLT_S.RESULT_VALUE)); 

	//BEL_RES
	CDB_init_cedclotrlt(&CEDCLOTRLT_S);
	TRS.copy(CEDCLOTRLT_S.FACTORY, sizeof(CEDCLOTRLT_S.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTRLT_S.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_EL2, strlen(HQCEL_INS_TYPE_CATEGORY_EL2));
    TRS.copy(CEDCLOTRLT_S.LOT_ID, sizeof(CEDCLOTRLT_S.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT_S);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO Nothing
	    }
	}
	TRS.add_string(out_node, "BEL_RES",   CEDCLOTRLT_S.RESULT_VALUE,sizeof(CEDCLOTRLT_S.RESULT_VALUE)); 

	//SIMULATOR
	CDB_init_cedclotrlt(&CEDCLOTRLT_S);
	TRS.copy(CEDCLOTRLT_S.FACTORY, sizeof(CEDCLOTRLT_S.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTRLT_S.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_SIMULATOR, strlen(HQCEL_INS_TYPE_CATEGORY_SIMULATOR));
    TRS.copy(CEDCLOTRLT_S.LOT_ID, sizeof(CEDCLOTRLT_S.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT_S);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO Nothing
	    }
	}
	TRS.add_string(out_node, "FLASH_PMAX",CEDCLOTRLT_S.PMPP,sizeof(CEDCLOTRLT_S.PMPP));
	TRS.add_string(out_node, "FLASH_RES", CEDCLOTRLT_S.RESULT_VALUE,sizeof(CEDCLOTRLT_S.RESULT_VALUE));  
	TRS.add_string(out_node, "DIODERES", CEDCLOTRLT_S.ESC,sizeof(CEDCLOTRLT_S.ESC));  

	CDB_init_cedclotrlh(&CEDCLOTRLH_C);
	TRS.copy(CEDCLOTRLH_C.LOT_ID, sizeof(CEDCLOTRLH_C.LOT_ID), in_node, "LOT_ID");
	memcpy(CEDCLOTRLH_C.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_SIMULATOR, strlen(HQCEL_INS_TYPE_CATEGORY_SIMULATOR));
	CDB_select_cedclotrlh(6, &CEDCLOTRLH_C);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO NOTHING
	    }
	}

	TRS.add_int(out_node, "FlashResCount", CEDCLOTRLH_C.INS_CNT);    
	//MWIPLOTHIS
	/*
SELECT * FROM MWIPLOTHIS WHERE LOT_ID = '203619214520401943'`
AND HIST_SEQ = (SELECT MAX(HIST_SEQ) HIST_SEQ 
                FROM MWIPLOTHIS 
                WHERE LOT_ID = '203619214520401943' AND OLD_OPER = 'M3070' AND END_FLAG = 'Y' AND TRAN_CODE = 'END') 
AND ROWNUM = 1;
*/
	CDB_init_mwiplothis(&MWIPLOTHIS);
	TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");

	CDB_select_mwiplothis(4, &MWIPLOTHIS);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO NOTHING
	    }
	}
	/*20190712 요청 14자리를 17자리 라인시간으로 변경  이성배과장 긴급요청*/
	memset(cim_time, ' ', sizeof(cim_time));
	if(MWIPLOTHIS.END_TIME[0] != ' ')
	{
		memset(cim_time, '0', sizeof(cim_time));
		memcpy(cim_time,MWIPLOTHIS.END_TIME,sizeof(MWIPLOTHIS.END_TIME));
	}
	//TRS.add_string(out_node, "BEL_END_TIME", MWIPLOTHIS.END_TIME,sizeof(MWIPLOTHIS.END_TIME));
	TRS.add_string(out_node, "BEL_END_TIME", cim_time,sizeof(cim_time));

	//MWIPLOTHIS
/*
SELECT START_TIME FROM MWIPLOTHIS WHERE LOT_ID = '203619214520401943'
AND HIST_SEQ = (SELECT MIN(HIST_SEQ) HIST_SEQ 
                FROM MWIPLOTHIS 
                WHERE LOT_ID = '203619214520401943' AND OLD_OPER = 'M3100' AND TRAN_CODE = 'START') 
AND ROWNUM = 1;
*/
	CDB_init_mwiplothis(&MWIPLOTHIS);
	TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");

	CDB_select_mwiplothis(5, &MWIPLOTHIS);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
			//DO NOTHING
	    }
	}
	/*20190712 요청 14자리를 17자리 라인시간으로 변경  이성배과장 긴급요청*/
	memset(cim_time, ' ', sizeof(cim_time));
	if(MWIPLOTHIS.START_TIME[0] != ' ')
	{
		memset(cim_time, '0', sizeof(cim_time));
		memcpy(cim_time,MWIPLOTHIS.START_TIME,sizeof(MWIPLOTHIS.START_TIME));
	}
	
	//TRS.add_string(out_node, "GRT_START_TIME", MWIPLOTHIS.START_TIME,sizeof(MWIPLOTHIS.START_TIME));
	TRS.add_string(out_node, "GRT_START_TIME", cim_time,sizeof(cim_time));



	//AOI DEFECT_LIST
/* Cell정보를 주지 않는다 AOI는 OK,NG 만을 보내준다 따라서 Cell loss정보는 없다.
*/
	list_aoi_item = TRS.add_node(out_node, "AOI_DEFECT_LIST");
	
	
	//BEL_DEFECT_LIST
/*
SELECT * FROM CWIPCELLOS WHERE FACTORY = 'USGAM1' 
AND LOSS_CATEGORY = 'E2' 
AND LOT_ID = '203719215520400780' 
AND INS_CNT = (SELECT MAX(INS_CNT) INS_CNT
               FROM CEDCLOTRLH 
               WHERE FACTORY = 'USGAM1' AND INS_TYPE = 'E2'
               AND LOT_ID = '203719215520400780' AND RESULT_VALUE = 'NG'); 
*/
	list_bel_item = TRS.add_node(out_node, "BEL_DEFECT_LIST");
	
	CDB_init_cwipcellos(&CWIPCELLOS);
	TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, "FACTORY");
	memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_EL2, strlen(HQCEL_LOSS_CATEGORY_EL2));
	TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");

	CDB_open_cwipcellos(3, &CWIPCELLOS);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING

		// 20210810 MES Application Memory leak 점검 및 수정
		// close remove 
		//CDB_close_cwipcellos(3);
	}

	// 20210810 MES Application Memory leak 점검 및 수정
	// CUR open 성공시에만 처리하도록 수정.
	if(DB_error_code == DB_SUCCESS)
	{
		while(1)
		{
			CDB_fetch_cwipcellos(3, &CWIPCELLOS);
			if(DB_error_code != DB_SUCCESS)
			{
				CDB_close_cwipcellos(3);
				break;
			}
			param_item = TRS.add_node(list_bel_item, "DEFECT_ITEM");
			TRS.add_string(param_item, "LOC_ID", CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID));
			TRS.add_string(param_item, "REASON_CODE", CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));
			TRS.add_char(param_item, "CELL_IMAGE", ' ');
        
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    EAPMES_Download_Fqc_Inspection_Data_Validation()
        - Main sub function of "EAPMES_DOWNLOAD_FQC_INSPECTION_DATA" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Download_Fqc_Inspection_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

