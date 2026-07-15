/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_end_lot.c
    Description : EAPMES End Lot Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_End_Lot()
            + Setup service interface function
        - EAPMES_END_LOT()
            + Main sub function of EAPMES_End_Lot function
            + Setup service main business function
        - EAPMES_End_Lot_Validation()
            + Main sub function of EAPMES_END_LOT function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_END_LOT()
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

int EAPMES_End_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_End_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_End_Lot(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100];
    int i_ret;
    TRSNode *out_node;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
    
    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_END_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_END_LOT", out_node);

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

      /* Æ¯Á¤ ¿¡·¯Ã³¸®¸¦ ¹«½ÃÇÒ°æ¿ì »ç¿ë ERROR  */
	// VALIDATION ÇÏ¶ó°í ¼ÂÆÃµÈ ¿¡·¯¸¸ ¿¡·¯Ã³¸®ÇÔ.
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
	memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
	memcpy(MGCMLAGDAT.KEY_2, "VALIDATION", strlen("VALIDATION"));
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_End_Lot", strlen("EAPMES_End_Lot"));
	memcpy(MGCMLAGDAT.KEY_4, s_msg_code, 9);
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'Y'))
	{
		//VALIDATION SKIP ÀÌ ¾Æ´Ñ°æ¿ì ¿¡·¯¹ß»ý
		//MGCMLAGDAT TABLE (@FACTORY_OPTION)¿¡¼­ DATA_1 = 'Y' ÀÌ¸é ¿¡·¯¹ß»ý
	}
	else
	{
		//VALIDATION SKIP ÀÏ°æ¿ì ¹«Á¶°Ç ¼º°ø 
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	}

    
    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
    TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
    
	if(CallService(MODULE_EAP, 
		"MESEAP_End_Lot", 
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
    EAPMES_END_LOT()
        - Main sub function of "EAPMES_End_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_END_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;

	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
	struct CEDCINSDAT_TAG CEDCINSDAT;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_G;
	struct CWIPGRTAVG_TAG CWIPGRTAVG;

	int d_max_seq_num;
	char res_id[20];
	char s_sys_time[14];

    //char   s_sys_time[14];

    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("EAPMES_END_LOT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /*
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
    */

    if(EAPMES_End_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
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

	//Generate Grount Test Data at the End of FQC-01
	if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0 && memcmp(MRASRESDEF.RES_CMF_16, "518", strlen("518")) == 0)
	{
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0044");
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}

			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		memset(s_sys_time, ' ', sizeof(s_sys_time));
		DB_get_systime(s_sys_time);

		// Check Ground Test
		// CEDCLOTRLT.INS_TYPE = GR
		//23.11.22 품질 요청으로 GR이 없는 경우 GR넣는 로직 제외함
	//	CDB_init_cedclotrlt(&CEDCLOTRLT);
	//	memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	//	memcpy(CEDCLOTRLT.INS_TYPE, "GR", strlen("GR"));
	//	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	//	CDB_select_cedclotrlt(2,&CEDCLOTRLT);
	//	if(DB_error_code != DB_SUCCESS)
	//	{
	//		//if GR does not exist, create one.
	//		if(DB_error_code == DB_NOT_FOUND)
	//		{
	//			//change OPER = M3100
	//			memcpy(MWIPLOTSTS.OPER, "M3100", strlen("M3100"));
	//			DBC_update_mwiplotsts(1, &MWIPLOTSTS);
	//			if(DB_error_code != DB_SUCCESS)
	//			{
	//				strcpy(s_msg_code, "EDC-0004");
	//				TRS.set_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
	//				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
	//				TRS.add_dberrmsg(out_node, DB_error_msg);

	//				gs_log_type.type = MP_LOG_ERROR;
	//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//				gs_log_type.category = MP_LOG_CATE_TRANS;

	//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//				return MP_FALSE;
	//			}

	//			strcpy(res_id, TRS.get_string(in_node,"RES_ID"));	//US-E#-FQC-02

	//			//US-E#-GRT-01
	//			res_id[6] = 'G';
	//			res_id[7] = 'R';
	//			res_id[8] = 'T';
	//			res_id[11] = '1';

	//			/* Start Lot */
	//			tran_in_node = TRS.create_node("START_LOT_IN");
	//			tran_out_node = TRS.create_node("START_LOT_OUT");

	//			CCOM_copy_in_node(in_node, tran_in_node);
	//			TRS.add_char(tran_in_node, "PROCSTEP", '1');  
	//			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	//			TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
	//			TRS.add_string(tran_in_node, "OPER", "M3100", strlen("M3100")); 
	//			TRS.add_nstring(tran_in_node, "RES_ID", res_id);
	//			TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
	//			if(CWIP_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	//			{
	//				// Do Nothing
	//			}
 //   
	//			TRS.free_node(tran_in_node);
	//			TRS.free_node(tran_out_node);

	//			CDB_init_cedclotrlt(&CEDCLOTRLT);

	//			memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	//			memcpy(CEDCLOTRLT.INS_TYPE, "GR", strlen("GR"));
	//			memcpy(CEDCLOTRLT.OPER, "M3100", strlen("M3100"));
	//			memcpy(CEDCLOTRLT.RES_ID, res_id, strlen(res_id));
	//			
	//			TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	//			TRS.copy(CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID), in_node, "LINE_ID");

	//			TRS.copy(CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID), in_node, "CLIENT_ID");
	//			memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));

	//			memcpy(CEDCLOTRLT.RESULT_VALUE, "OK", strlen("OK"));
	//			TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "CLIENT_ID");
	//			memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));

	//			CEDCLOTRLT.TYPE_FLAG = TRS.get_char(in_node, "TYPE_FLAG");
	//			CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ + 1;
	//			CEDCLOTRLT.QTY = 1;
	//			CEDCLOTRLT.INS_CNT = 1;

	//			memcpy(CEDCLOTRLT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	//			memcpy(CEDCLOTRLT.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
	//			memcpy(CEDCLOTRLT.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
	//			memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
	//			TRS.copy(CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLT.LOC_ID), in_node, "LOC_ID");

	//			CDB_insert_cedclotrlt(&CEDCLOTRLT);	
	//			if(DB_error_code != DB_SUCCESS)
	//			{
	//				strcpy(s_msg_code, "EDC-0004");
	//				TRS.set_fieldmsg(out_node, "CEDCLOTRLT INSERT", MP_NVST);
	//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
	//				TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
	//				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
	//				TRS.add_dberrmsg(out_node, DB_error_msg);

	//				gs_log_type.type = MP_LOG_ERROR;
	//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//				gs_log_type.category = MP_LOG_CATE_TRANS;

	//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//				return MP_FALSE;
	//			}

	//			/* History */
	//			CDB_init_cedclotrlh(&CEDCLOTRLH);
	//			memcpy(CEDCLOTRLH.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLH.FACTORY));
	//			memcpy(CEDCLOTRLH.INS_TYPE, CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLH.INS_TYPE));
	//			memcpy(CEDCLOTRLH.OPER, CEDCLOTRLT.OPER, sizeof(CEDCLOTRLH.OPER));
	//			memcpy(CEDCLOTRLH.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLH.RES_ID));
	//			memcpy(CEDCLOTRLH.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID));
	//			memcpy(CEDCLOTRLH.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLH.LINE_ID));
	//			memcpy(CEDCLOTRLH.INS_USER_ID, CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLH.INS_USER_ID));
	//			memcpy(CEDCLOTRLH.INS_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLH.INS_TIME));
	//			memcpy(CEDCLOTRLH.RESULT_VALUE, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE));
	//			memcpy(CEDCLOTRLH.RESULT_USER_ID, CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID));
	//			memcpy(CEDCLOTRLH.RESULT_TIME, CEDCLOTRLT.RESULT_TIME, sizeof(CEDCLOTRLH.RESULT_TIME));
	//			memcpy(CEDCLOTRLH.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLH.MAT_ID));
	//			memcpy(CEDCLOTRLH.FLOW, CEDCLOTRLT.FLOW, sizeof(CEDCLOTRLH.FLOW));
	//			memcpy(CEDCLOTRLH.ORDER_ID, CEDCLOTRLT.ORDER_ID, sizeof(CEDCLOTRLH.ORDER_ID));
	//			memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1));
	//			memcpy(CEDCLOTRLH.LOC_ID, CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLH.LOC_ID));
	//			CEDCLOTRLH.TYPE_FLAG = CEDCLOTRLT.TYPE_FLAG;
	//			CEDCLOTRLH.HIST_SEQ = 1;
	//			CEDCLOTRLH.QTY = 1;
	//			CEDCLOTRLH.INS_CNT = 1;

	//			CDB_insert_cedclotrlh(&CEDCLOTRLH);
	//			if(DB_error_code != DB_SUCCESS)
	//			{
	//				strcpy(s_msg_code, "EDC-0004");
	//				TRS.set_fieldmsg(out_node, "CEDCLOTRLH INSERT", MP_NVST);
	//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLH.FACTORY), CEDCLOTRLH.FACTORY);
	//				TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLH.INS_TYPE), CEDCLOTRLH.INS_TYPE);
	//				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
	//				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CEDCLOTRLH.HIST_SEQ);
	//				TRS.add_fieldmsg(out_node, "INS_CNT", MP_INT, CEDCLOTRLH.INS_CNT);
	//				TRS.add_dberrmsg(out_node, DB_error_msg);

	//				gs_log_type.type = MP_LOG_ERROR;
	//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//				gs_log_type.category = MP_LOG_CATE_TRANS;

	//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//				return MP_FALSE;
	//			}

	//			// Get Max Sequence Number
	//			d_max_seq_num = 0;
	//			CDB_init_cedcinsdat(&CEDCINSDAT);
	//			memcpy(CEDCINSDAT.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID));
	//			memcpy(CEDCINSDAT.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCINSDAT.RES_ID));
	//			//memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCINSDAT.TRAN_TIME));IS-21-01-094 MES logic °³¼±
	//			memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));

	//			d_max_seq_num = CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);

	//			// Common
	//			CDB_init_cedcinsdat(&CEDCINSDAT);
	//			memcpy(CEDCINSDAT.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID));
	//			memcpy(CEDCINSDAT.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCINSDAT.RES_ID));
	//			memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));
	//			memcpy(CEDCINSDAT.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCINSDAT.LINE_ID));
	//			memcpy(CEDCINSDAT.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCINSDAT.FACTORY));
	//			memcpy(CEDCINSDAT.OPER, CEDCLOTRLT.OPER, sizeof(CEDCINSDAT.OPER));
	//			CEDCINSDAT.LOT_HIST_SEQ = CEDCLOTRLT.LAST_HIST_SEQ;

	//			//GET AVG GRT VALUES BY THE MAT_ID
	//			CDB_init_cedclotrlt(&CEDCLOTRLT_G);
	//			memcpy(CEDCLOTRLT_G.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT_G.MAT_ID));

	//			//20201002 HCHKIM CWIPGRTAVG CHECK
	//			CDB_init_cwipgrtavg(&CWIPGRTAVG);
	//			memcpy(CWIPGRTAVG.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(CWIPGRTAVG.MAT_ID));
	//		
	//			CDB_select_cwipgrtavg(1, &CWIPGRTAVG);
	//			if(DB_error_code != DB_SUCCESS)
	//			{
	//				if(DB_error_code == DB_NOT_FOUND)
	//				{
	//					CDB_select_cedclotrlt(3, &CEDCLOTRLT_G);
	//					if(DB_error_code != DB_SUCCESS)
	//					{
	//						//DO NOTHING
	//					}
	//				}
	//			}
	//			else
	//			{
	//				memcpy(CEDCLOTRLT_G.CMF_1, CWIPGRTAVG.STEP_1_MEASURE, sizeof(CEDCLOTRLT_G.CMF_1));
	//				memcpy(CEDCLOTRLT_G.CMF_2, CWIPGRTAVG.STEP_2_MEASURE, sizeof(CEDCLOTRLT_G.CMF_2));
	//				memcpy(CEDCLOTRLT_G.CMF_3, CWIPGRTAVG.STEP_3_MEASURE, sizeof(CEDCLOTRLT_G.CMF_3));
	//				memcpy(CEDCLOTRLT_G.CMF_4, CWIPGRTAVG.STEP_4_MEASURE, sizeof(CEDCLOTRLT_G.CMF_4));
	//			}
	//			//CDB_select_cedclotrlt(3, &CEDCLOTRLT_G);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_MODULE_ID", sizeof("I_GRD_01_MODULE_ID"));
	//			TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.LOT_ID), in_node, "LOT_ID");
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_1_MEASURE_OHM", sizeof("I_GRD_01_STEP_1_MEASURE_OHM"));
	//			memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_1, sizeof(CEDCLOTRLT_G.CMF_1));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_1_RESULT", sizeof("I_GRD_01_STEP_1_RESULT"));
	//			memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_2_MEASURE_OHM", sizeof("I_GRD_01_STEP_2_MEASURE_OHM"));
	//			memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_2, sizeof(CEDCLOTRLT_G.CMF_2));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_2_RESULT", sizeof("I_GRD_01_STEP_2_RESULT"));
	//			memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_3_MEASURE_OHM", sizeof("I_GRD_01_STEP_3_MEASURE_OHM"));
	//			memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_3, sizeof(CEDCLOTRLT_G.CMF_3));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_3_RESULT", sizeof("I_GRD_01_STEP_3_RESULT"));
	//			memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_4_MEASURE_OHM", sizeof("I_GRD_01_STEP_4_MEASURE_OHM"));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			if(memcmp(CEDCLOTRLT_G.CMF_4, "0.00000", 1) == 0)
	//			{
	//				memcpy(CEDCINSDAT.PARAM_VALUE, " ", sizeof(" "));
	//			}
	//			else
	//			{
	//				memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_4, sizeof(CEDCLOTRLT_G.CMF_4));
	//			}
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_4_RESULT", sizeof("I_GRD_01_STEP_4_RESULT"));
	//			CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
	//			if(memcmp(CEDCLOTRLT_G.CMF_4, "0.00000", 1) == 0)
	//			{
	//				memcpy(CEDCINSDAT.PARAM_VALUE, " ", sizeof(" "));
	//			}
	//			else
	//			{
	//				memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
	//			}
	//			CDB_insert_cedcinsdat(&CEDCINSDAT);

	//			/* End Lot */
	//			tran_in_node = TRS.create_node("END_LOT_IN");
	//			tran_out_node = TRS.create_node("END_LOT_OUT");

	//			CCOM_copy_in_node(in_node, tran_in_node);
	//			TRS.add_char(tran_in_node, "PROCSTEP", '1');  
	//			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	//			TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
	//			TRS.add_string(tran_in_node, "OPER", "M3100", strlen("M3100")); 
	//			TRS.add_nstring(tran_in_node, "RES_ID", res_id);
	//			TRS.add_string(tran_in_node, "TRAN_CMF_2", s_sys_time, sizeof(s_sys_time)); //TRAN_CMF_2 ¿¡ °Ë»çµ¥ÀÌÅÍ Ã³¸®ÈÄ END ÇßÀ»°æ¿ì ÇØ´ç ½Ã°£ ³ÖÀ½.
	//			TRS.add_char(tran_in_node, "INSPECT_FLAG", 'Y');
	//			if(EAPMES_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	//			{
	//				// Do Nothing
	//			}
 //   
	//			TRS.free_node(tran_in_node);
	//			TRS.free_node(tran_out_node);
	//		}
	//		else
	//		{
	//			strcpy(s_msg_code, "WIP-0004");
	//			TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
	//			TRS.add_dberrmsg(out_node, DB_error_msg);
	//			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
	//			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
	//			gs_log_type.type = MP_LOG_ERROR;
	//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//			gs_log_type.category = MP_LOG_CATE_TRANS;
	//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//			return MP_FALSE;
	//		}
	//	}
	}

	//ÇöÀç Àåºñ°¡ TRANSACIOTN ¹ß»ý Àåºñ°¡ ¾Æ´Ï¸é Return True;
	if (MRASRESDEF.RES_CMF_4[0] != 'Y')
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}

    /* get material ID and  operation */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0044");
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (TRS.get_char(in_node, "INSPECT_FLAG") == 'Y')
	{
		//°Ë»ç°øÁ¤ °Ë»ç°á°ú¸¦ ¹Þ¾ÒÀ»‹š END ÇÏ´Â °æ¿ìÀÓ.
		//ÀÌ°÷ÀÌ¿Ü¿¡´Â ÀÏ¹Ý ENDÀÓ.
	}
	else if ((memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0) ||
				(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0))
	{
		//EL1 END ÀÌ¸é¼­ ¸¶Áö¸· END °¡ °Ë»ç°á°ú·Î END µÈ ÀÌ·ÂÀÌ¸é END ÇÏÁö ¾ÊÀ½.
		DBC_init_mwiplothis(&MWIPLOTHIS);
		memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		DBC_select_mwiplothis(1, &MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DONOTHING
		}	
		//LOT ÀÇ ¸¶Áö¸· HISOTRY ¸¦ µÚÁ®¼­ TRAN_CMF_2(°Ë»ç½Ã°£) ¿¡ °ªÀÌ ÀÖÀ¸¸é °Ë»ç¿Ï·áÈÄ ÀÚµ¿À¸·Î END ÇÑ°ÍÀÓ.
		//LOT ÀÇ °Ë»çµ¥ÀÌÅÍ·Î END ÇßÀ»°æ¿ì ´ÙÀ½ END ½ÅÈ£ ¹«½Ã
		if((COM_isspace(MWIPLOTHIS.TRAN_CMF_2, sizeof(MWIPLOTHIS.TRAN_CMF_2)) == MP_FALSE) &&
			(memcmp(MWIPLOTHIS.OLD_OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTHIS.OLD_OPER)) == 0) &&
			(memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) == 0)
		  )
		{
			//END Ã³¸®ÇÏÁö ¾Ê°í ³¡³¿.
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}

		//EL ¶óÀÎ¿¡¼­´Â LOT END ÇÏÁö ¾ÊÀ½ ( °Ë»ç°á°ú ¹Þ¾ÒÀ»½Ã¸¸ END ÇÏ´Â°ÍÀ¸·Î º¯°æÇÔ (2019/01/24 JUHYEON)
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}
	else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0) 
	{
		//FQC Normal Operation End
		DBC_init_mwiplothis(&MWIPLOTHIS);
		memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		DBC_select_mwiplothis(1, &MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DONOTHING
		}	
		//LOT ÀÇ ¸¶Áö¸· HISOTRY ¸¦ µÚÁ®¼­ TRAN_CMF_2(°Ë»ç½Ã°£) ¿¡ °ªÀÌ ÀÖÀ¸¸é °Ë»ç¿Ï·áÈÄ ÀÚµ¿À¸·Î END ÇÑ°ÍÀÓ.2¹ø END ¾ÈÇÔ.
		//LOT ÀÇ °Ë»çµ¥ÀÌÅÍ·Î END ÇßÀ»°æ¿ì ´ÙÀ½ END ½ÅÈ£ ¹«½Ã
		if((COM_isspace(MWIPLOTHIS.TRAN_CMF_2, sizeof(MWIPLOTHIS.TRAN_CMF_2)) == MP_FALSE) &&
			(memcmp(MWIPLOTHIS.OLD_OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTHIS.OLD_OPER)) == 0) &&
			(memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) == 0)
		  )
		{
			//END Ã³¸®ÇÏÁö ¾Ê°í ³¡³¿.
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}

		//FQC ¶óÀÎ¿¡¼­´Â LOT END ÇÏÁö ¾ÊÀ½ ( °Ë»ç°á°ú ¹Þ¾ÒÀ»½Ã¸¸ END ÇÏ´Â°ÍÀ¸·Î º¯°æÇÔ (2019/05/02 JUHYEON)
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;

	}

	//LOT ÀÌ ÇöÀç°øÁ¤ÀÌ ¾Æ´Ï¸é ÇöÀç°øÁ¤±îÁö END ½ÃÅ´.
	if (memcmp(MWIPLOTSTS.OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTSTS.OPER)) != 0)
	{
		/***************************************************/
		//END LOT -> °­Á¦·Î
		/***************************************************/
		tran_in_node = TRS.create_node("START_LOT_IN");
		tran_out_node = TRS.create_node("START_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
		TRS.add_string(tran_in_node, "FLOW",MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM); 
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			
		//ERP Interface ¸¦ À§ÇØ ÀÓ½ÃCOCE ( M3000, M3040, M3110 ) µ¥ÀÌÅÍ ÀÚµ¿»ý±è
		TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		TRS.set_string(tran_in_node, "TO_OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_3));

		if (MWIPLOTSTS.START_FLAG == 'Y')
		{
			TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
			if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
			}
		}
		else
		{
			if(WIP_SKIP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
			}
		}
			

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DONOTHING
		}		
	}

    tran_in_node = TRS.create_node("END_LOT_IN");
    tran_out_node = TRS.create_node("END_LOT_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
	TRS.set_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	TRS.set_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

	TRS.add_nstring(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "TRAN_CMF_1"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "TRAN_CMF_2"));
	TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", TRS.get_char(in_node, "INF_UPLOAD_TYPE_FLAG"));
    if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
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

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_End_Lot_Validation()
        - Main sub function of "EAPMES_END_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_End_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
	struct CGCMTBLDAT_TAG CGCMTBLDAT;//Module Validation Check 25.05.19
	struct MWIPLOTSTS_TAG MWIPLOTSTS_VALIDATION;//Module Validation Check 25.05.19

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

	//Module Validation Check 25.05.19 -START
	//적용 로직 : 
	//1)모듈이 18자리인지 체크
	//2)모듈 2번째 자리가 0인지 체크
	//3)모든18자리면서 2번째 자리가 0이 아니면 MWIPLOTSTS 조회
	//4)MWIPLOTSTS에 없으면 PASS

	CDB_init_cgcmtbldat(&CGCMTBLDAT);
 	memcpy(CGCMTBLDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CGCMTBLDAT.TYPE_1, "LOT_VAL_CHK", strlen("LOT_VAL_CHK"));
	TRS.copy(CGCMTBLDAT.TYPE_2, sizeof(CGCMTBLDAT.TYPE_2), in_node, "RES_ID");//RES_ID

	CDB_select_cgcmtbldat(1, &CGCMTBLDAT);//등록 되지 않은 설비는 관련 로직 SKIP
	if(DB_error_code == DB_SUCCESS)
	{
		//1.모듈이 18 자리인지
		DBC_init_mwiplotsts(&MWIPLOTSTS_VALIDATION);
		TRS.copy(MWIPLOTSTS_VALIDATION.LOT_ID, sizeof(MWIPLOTSTS_VALIDATION.LOT_ID), in_node, "LOT_ID");

		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			strcpy(s_msg_code, "WIP-0655");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SIZE CHECK", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS_VALIDATION.LOT_ID), MWIPLOTSTS_VALIDATION.LOT_ID);
			gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		//2.모듈 2번째 자리가 0인지 체크

		if(MWIPLOTSTS_VALIDATION.LOT_ID[1] != '0')
		{
			strcpy(s_msg_code, "WIP-0656");
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS_VALIDATION.LOT_ID), MWIPLOTSTS_VALIDATION.LOT_ID);
			
			gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		//3.MWIPLOTSTS가 존재 하는지 체크
		DBC_select_mwiplotsts(1, &MWIPLOTSTS_VALIDATION);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0657");
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS_VALIDATION.LOT_ID), MWIPLOTSTS_VALIDATION.LOT_ID);
			
			gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

	}

	//Module Validation Check 25.05.19 -END
    return MP_TRUE;
}

