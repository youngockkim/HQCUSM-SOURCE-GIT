/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_start_lot.c
    Description : EAPMES Start Lot Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Start_Lot()
            + Setup service interface function
        - EAPMES_START_LOT()
            + Main sub function of EAPMES_Start_Lot function
            + Setup service main business function
        - EAPMES_Start_Lot_Validation()
            + Main sub function of EAPMES_START_LOT function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_START_LOT()
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

int EAPMES_Start_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Start_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Start_Lot(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_START_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_START_LOT", out_node);

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
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Start_Lot", strlen("EAPMES_Start_Lot"));
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
		"MESEAP_Start_Lot", 
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
    EAPMES_START_LOT()
        - Main sub function of "EAPMES_Start_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_START_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    
    char   s_sys_time[14];
	char   s_due_time[14];
	char   c_create_flag ;
    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("EAPMES_START_LOT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


	c_create_flag = ' '; // Server Crash 190925 ¹ÌÃÊ±âÈ­

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


    
    if(EAPMES_Start_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
			//LOT °­Á¦ ¿É¼Ç ¼³Á¤ÀÌ ÀÖÀ¸¸é LOT À» »ý¼º½ÃÅ´.
			DBC_init_mgcmlagdat(&MGCMLAGDAT);
			TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
			memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
			memcpy(MGCMLAGDAT.KEY_2, "AUTO_LOT_CREATE", strlen("AUTO_LOT_CREATE"));
			memcpy(MGCMLAGDAT.KEY_3, MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2));
			memcpy(MGCMLAGDAT.KEY_4, "AUTO", strlen("AUTO"));
			DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
			if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'Y'))
			{
				c_create_flag = 'Y';
			}
			else
			{
				strcpy(s_msg_code, "WIP-0044");
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;	
			}
        }
    }
	

	//
	if (c_create_flag == 'Y')
	{
		
		//ÇöÀç LINE ÀÇ ÀÛ¾÷Áö½Ã  GET
		/* Get current order by line ID */
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");

		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0601");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/* Get order information */
		DBC_init_mwipordsts(&MWIPORDSTS);
		TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID));

		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "ORD-0002");
			TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/* Get material(PRODUCT) information */
		DBC_init_mwipmatdef(&MWIPMATDEF);
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPMATDEF.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATDEF.MAT_VER = 1;

		DBC_select_mwipmatdef(1, &MWIPMATDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0006");
			TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
			TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		//MODULE ID SIZE CHECK
		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			strcpy(s_msg_code, "WIP-0583");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SIZE CHECK", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/****************************************************************************/
		// 1. MAIN LOT CREATION (MODULE ID)
		/****************************************************************************/
		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');

		//LOT_ID ´Â STRING ID ·Î »ý¼º.
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", 1);
		TRS.add_string(tran_in_node, "FLOW", MWIPMATDEF.FIRST_FLOW, sizeof(MWIPMATDEF.FIRST_FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", 1); 
		//TRS.add_string(tran_in_node, "OPER", MRASRESDEF.RES_CMF_2, strlen( MRASRESDEF.RES_CMF_2)); // Server Crash
		TRS.add_string(tran_in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof( MRASRESDEF.RES_CMF_2)); // Server Crash
		TRS.add_char(tran_in_node, "LOT_TYPE", 'P');   
		TRS.add_string(tran_in_node, "CREATE_CODE", HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE));
		TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
		TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
		TRS.add_double(tran_in_node, "QTY_1", 1);   
		TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		
		memset(s_due_time, ' ' , sizeof(s_due_time));
		COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time ÀÓ½Ã°è»ê

		TRS.add_string(tran_in_node, "DUE_TIME",s_due_time, sizeof(s_due_time));
		TRS.add_string(tran_in_node, "LOT_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));

		TRS.set_string(tran_in_node, "COLOR_CLASS", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
		TRS.set_string(tran_in_node, "LOC_ID", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
		TRS.set_string(tran_in_node, "LINE_ID", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		if(WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		//¸Þ¸ð¸®ÇØÁ¦ ÇÏÁö¾ÊÀº°Í Ãß°¡(04/26 JJH)
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
	}
	else
	{
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
	}

    tran_in_node = TRS.create_node("START_LOT_IN");
    tran_out_node = TRS.create_node("START_LOT_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
	TRS.add_string(tran_in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2)); // ¼³ºñ ±âÁØÀÇ OPERATION »ç¿ë
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
	TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID")); // LINE ID ÇÊ¼ö
  
    if(CWIP_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
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
    EAPMES_Start_Lot_Validation()
        - Main sub function of "EAPMES_START_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Start_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
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




