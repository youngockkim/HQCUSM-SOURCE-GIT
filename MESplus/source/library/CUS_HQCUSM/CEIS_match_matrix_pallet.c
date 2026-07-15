/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_match_matrix_pallet.c
    Description : EAPMES Match Matrix Pallet Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Match_Matrix_Pallet()
            + Setup service interface function
        - EAPMES_MATCH_MATRIX_PALLET()
            + Main sub function of EAPMES_Match_Matrix_Pallet function
            + Setup service main business function
        - EAPMES_Match_Matrix_Pallet_Validation()
            + Main sub function of EAPMES_MATCH_MATRIX_PALLET function
    Detail Description
        - EAPMES_MATCH_MATRIX_PALLET()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Match_Matrix_Pallet_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int Send_Material_Tracability_Data_Half_Product(char* s_msg_code, char* s_sys_time, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
    EAPMES_Match_Matrix_Pallet()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Match_Matrix_Pallet(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_MATCH_MATRIX_PALLET(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_MATCH_MATRIX_PALLET", out_node);

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
    TRS.set_nstring(out_node, "PALLET_ID", TRS.get_string(in_node, "PALLET_ID"));
    TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Match_Matrix_Pallet", 
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
    EAPMES_MATCH_MATRIX_PALLET()
        - Main sub function of "EAPMES_Match_Matrix_Pallet" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_MATCH_MATRIX_PALLET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTSTR_TAG CWIPLOTSTR;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_STR;
	struct CWIPTRYSTS_TAG CWIPTRYSTS;
	struct CWIPTRYHIS_TAG CWIPTRYHIS;
	struct CWIPCELLAM_TAG CWIPCELLAM;

    char s_sys_time[14];
    int i;
    int i_string_item_count;
    char c_create_flag = ' ';
	char   s_due_time[14];
	char c_combine_flag = 'N';
	clock_t start_time;

	TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    TRSNode ** STRING_ITEM;
   
    LOG_head("EAPMES_MATCH_MATRIX_PALLET");
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

    if(EAPMES_Match_Matrix_Pallet_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

	//¼³ºñ¿¡¼­ ¿Ã·ÁÁØ ÀÛ¾÷Áö½Ã·Î »ý¼º (ÀÛ¾÷Áö½Ã ´Ù½Ã Ã¼Å©ÇÒ·Á¸é ¿©±â¼­ Ã¼Å©)
	TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");

	if (COM_isspace(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID)) == MP_TRUE)
	{
		//memcpy(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID));
		//ÀÛ¾÷Áö½Ã ¾øÀ¸¸é ¿¡·¯¹ß»ýÇÔ, ¸¸ÀÏ ¿¡·¯¾øÀÌ ÇÒ·Á¸é ¸¶Áö¸· ÁøÇàÇÑ ÀÛ¾÷Áö½Ã MGCMTBLDAT.DATA_3 ·Î ÁøÇàÇÔ.

	}
	else
	{
		//¶óÀÎÀÇ ÁøÇàÀÛ¾÷Áö½Ã¸¦ ¼³ºñ¿¡¼­ ¿Ã·ÁÁØ ¸¶Áö¸· ÀÛ¾÷Áö½Ã¸¦ ÀúÀåÇØ³õÀ½
		if (memcmp(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID)) != 0)
		{
			//start_time = STOPWATCH_START();
			memset(MGCMTBLDAT.DATA_3, ' ', sizeof(MWIPORDSTS.ORDER_ID));
			memcpy(MGCMTBLDAT.DATA_3, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
			DBC_update_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			//STOPWATCH_END("MGCMTBLDAT_U_ELAPSED_TIME", start_time);
		}
	}

	//memcpy(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID));

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

	//ÇöÀç Àåºñ°¡ TRANSACIOTN ¹ß»ý Àåºñ°¡ ¾Æ´Ï¸é Return True; ¿©±ä ¹«Á¶°Ç ¹ß»õÇØ¾ßÇÔ.
	/*if (MRASRESDEF.RES_CMF_4[0] != 'Y')
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}*/

	/* get material ID and  operation */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
		c_create_flag = 'Y';
	}

	tran_in_node = TRS.create_node("TRAN_LOT_IN");
	tran_out_node = TRS.create_node("TRAN_LOT_OUT");

	if (c_create_flag == 'Y')
	{
		//MAIN LOT CREATE
		/****************************************************************************/
		// 1. MAIN LOT CREATION (MODULE ID)
		/****************************************************************************/
		//start_time = STOPWATCH_START();
		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');

		//MODULE ID SIZE CHECK
		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			strcpy(s_msg_code, "WIP-0583");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SIZE CHECK", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
			// free_node call
			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);

			return MP_FALSE;
		}

		//LOT_ID ´Â MODULE_ID ·Î »ý¼º.
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
		TRS.add_nstring(tran_in_node, "LOT_CMF_2", TRS.get_string(in_node, "PALLET_ID")); //LAYUP PALLET_ID
		
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
//		STOPWATCH_END("MAIN_LOT_CREATE_ELAPSED_TIME", start_time);

		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}











		//END¸¦ CREATEÈÄ ¹Ù·Î Ã³¸®ÇÏµµ·Ï º¯°æ
		//(¿ø·¡´Â COMBINE³¡³ª°í Çß¾úÀ½..RSÀåºñ°¡ ¼ÓµµÀÌ½´¶§¹®¿¡ END¸¦ ¸øÄ¡´Â°æ¿ì°¡ ÀÖÀ½ ±×·¡¼­À§·Î ¶¯±è) 20200212
		start_time = STOPWATCH_START();
		TRS.init_node(tran_in_node);
		TRS.init_node(tran_out_node);

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
		if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
		{
			//¼³ºñID °¡ ¾øÀ»°æ¿ì Ã³¸® -> CORE ¿¡·¯ Ã³¸®.
		
		}

		if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			//END ½ÇÆÐÇØµµ °è¼Ó ÁøÇàÇØ¾ß ÇØ¼­ ÁÖ¼®Ã³¸® 20200212
			//TRS.clone(out_node, tran_out_node);
			//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			//TRS.free_node(tran_in_node);
			//TRS.free_node(tran_out_node);
			//return MP_FALSE;
		}
		STOPWATCH_END("MAIN_LOT_END_ELAPSED_TIME", start_time);
	}

	//CWIPLOTSTR »ý¼º(»èÁ¦ÈÄ »ý¼º)
	CDB_init_cwiplotstr(&CWIPLOTSTR);
	TRS.copy(CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID), in_node, "LOT_ID");
	CDB_delete_cwiplotstr(2, &CWIPLOTSTR);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

    /* String Item */
    STRING_ITEM = TRS.get_list(in_node, "STRING_ITEM");
    i_string_item_count = TRS.get_item_count(in_node, "STRING_ITEM");

    for(i = 0; i < i_string_item_count; i++)
    {
		start_time = STOPWATCH_START();

        //STGRING COMBINE ÁøÇà
		c_combine_flag = 'Y';
		CDB_init_mwiplotsts(&MWIPLOTSTS_STR);
		TRS.copy(MWIPLOTSTS_STR.LOT_ID, sizeof(MWIPLOTSTS_STR.LOT_ID), STRING_ITEM[i], "STRING_ID");
		
		CDB_select_mwiplotsts(1, &MWIPLOTSTS_STR);
		if(DB_error_code != DB_SUCCESS)
		{
			/* TABBER ¿¡¼­ LOT ÀÌ ¾øÀ»°æ¿ì  LOT °­Á¦»ý¼º */
			//STRING º°, TABBER END LOT ¼öÇà
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
			TRS.set_string(tran_in_node, "RES_ID", MRASRESDEF.RES_CMF_6, sizeof(MRASRESDEF.RES_CMF_6));  //TABBER EQ
			TRS.set_string(tran_in_node, "OPER", HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER));    //TABBER OPER
			TRS.set_string(tran_in_node, "LOT_ID",MWIPLOTSTS_STR.LOT_ID, sizeof(MWIPLOTSTS_STR.LOT_ID)); //STRING ID
			TRS.set_string(tran_in_node, "STRING_ID",MWIPLOTSTS_STR.LOT_ID, sizeof(MWIPLOTSTS_STR.LOT_ID)); //STRING ID

			if(CWIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				c_combine_flag = 'N';
			}
			else
			{
				CDB_select_mwiplotsts(1, &MWIPLOTSTS_STR);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);
			
		}

		if ( c_combine_flag == 'Y')
		{
			//COMBINE ¼öÇà
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS_STR.LOT_ID, sizeof(MWIPLOTSTS_STR.LOT_ID));
			
			TRS.add_string(tran_in_node, "INTO_LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

			//STRING 1°³¸¸ Combine
			TRS.add_double(tran_in_node, "MOVE_QTY_1", 1);

			if(WIP_COMBINE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				/**
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
				**/
				//DO NOTHING -> COMBINE µÇÁö ¾Ê´õ¶óµµ ÀúÀåÁ¤º¸´Â ³²±è.
			}
		}
		STOPWATCH_END("STRING_COMBINE_ELAPSED_TIME", start_time);
		STOPWATCH_END(TRS.get_string(STRING_ITEM[i], "STRING_ID") , start_time);

		start_time = STOPWATCH_START();

		//CWIPLOTSTR »ý¼º
		CDB_init_cwiplotstr(&CWIPLOTSTR);

		// Tray Ãß°¡
		if (COM_isnullspace(TRS.get_string(STRING_ITEM[i], "TRAY_ID")) == MP_FALSE)
		{
			CDB_init_cwiptrysts(&CWIPTRYSTS);
			TRS.copy(CWIPTRYSTS.FACTORY, sizeof(CWIPTRYSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID), STRING_ITEM[i], "TRAY_ID");
			CDB_select_cwiptrysts(1, &CWIPTRYSTS);

			if(DB_error_code != DB_SUCCESS)
			{
				// Master Table ¿¡ µî·ÏµÈ Tray°¡ ¾øÀ¸¸é insert
				if(DB_error_code == DB_NOT_FOUND)
				{
					// master¿¡ insert
					CWIPTRYSTS.SEQ = 1;
					memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT));
					TRS.copy(CWIPTRYSTS.CREATE_USER_ID, sizeof(CWIPTRYSTS.CREATE_USER_ID), in_node, "USERID");
					memcpy(CWIPTRYSTS.CREATE_TIME, s_sys_time, sizeof(CWIPTRYSTS.CREATE_TIME));

					CDB_insert_cwiptrysts(&CWIPTRYSTS);
				}
			} 
			else if(DB_error_code == DB_SUCCESS)
			{
				// 1412 º¸°í¾øÀÌ 1411 º¸°íÇÒ ¼ö ÀÖ¾î "I" »óÅÂ·Î º¯°æ
				memcpy(CWIPTRYSTS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT));
				TRS.copy(CWIPTRYSTS.UPDATE_USER_ID, sizeof(CWIPTRYSTS.UPDATE_USER_ID), in_node, "USERID");
				memcpy(CWIPTRYSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

				CDB_update_cwiptrysts(1, &CWIPTRYSTS);

				// CWIPTRYHIS ¿¡ ORDER_ID ¾÷µ¥ÀÌÆ®
				CDB_init_cwiptryhis(&CWIPTRYHIS);
				TRS.copy(CWIPTRYHIS.FACTORY, sizeof(CWIPTRYHIS.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPTRYHIS.TRAY_ID, sizeof(CWIPTRYHIS.TRAY_ID), STRING_ITEM[i], "TRAY_ID");
				CWIPTRYHIS.SEQ = CWIPTRYSTS.SEQ;
				
				CDB_select_cwiptryhis(1, &CWIPTRYHIS);

				memcpy(CWIPTRYHIS.STATUS, HQCEL_M1_TRAY_STATUS_INPUT, strlen(HQCEL_M1_TRAY_STATUS_INPUT));
				memcpy(CWIPTRYHIS.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
				TRS.copy(CWIPTRYHIS.UPDATE_USER_ID, sizeof(CWIPTRYHIS.UPDATE_USER_ID), in_node, "USERID");
				memcpy(CWIPTRYHIS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

				CDB_update_cwiptryhis(1, &CWIPTRYHIS);
			}

			// CWIPLOTSTR ¿¡ Tray Id ¿Í SEQ ÀÔ·Â
			memcpy(CWIPLOTSTR.CMF_4, CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID));
			COM_itoa_left(CWIPLOTSTR.CMF_5, CWIPTRYSTS.SEQ, sizeof(CWIPLOTSTR.CMF_5));
		}

		TRS.copy(CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY), in_node, IN_FACTORY);
	    TRS.copy(CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID), in_node, "LOT_ID");
        TRS.copy(CWIPLOTSTR.STRING_ID, sizeof(CWIPLOTSTR.STRING_ID), STRING_ITEM[i], "STRING_ID");
	    /* Insert or Update */
        TRS.copy(CWIPLOTSTR.LINE_ID, sizeof(CWIPLOTSTR.LINE_ID), in_node, "LINE_ID");
        TRS.copy(CWIPLOTSTR.RES_ID, sizeof(CWIPLOTSTR.RES_ID), in_node, "RES_ID");
        TRS.copy(CWIPLOTSTR.ORDER_ID, sizeof(CWIPLOTSTR.ORDER_ID), in_node, "ORDER_ID");
        TRS.copy(CWIPLOTSTR.CMF_1, sizeof(CWIPLOTSTR.CMF_1), in_node, "PALLET_ID");
        memcpy(CWIPLOTSTR.CREATE_TIME, s_sys_time, sizeof(CWIPLOTSTR.CREATE_TIME));
        memcpy(CWIPLOTSTR.LAST_TRAN_TIME, s_sys_time, sizeof(CWIPLOTSTR.LAST_TRAN_TIME));

		CDB_insert_cwiplotstr(&CWIPLOTSTR);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		STOPWATCH_END("STRING_I_ELAPSED_TIME", start_time);
    }

	/***************************************************/
	//END LOT
	/***************************************************/

	/*
	//END¸¦ CREATEÈÄ ¹Ù·Î Ã³¸®ÇÏµµ·Ï À§ÂÊÀ¸·Î ÀÌµ¿ 20200212
	if (c_create_flag == 'Y')
	{
		start_time = STOPWATCH_START();
		TRS.init_node(tran_in_node);
		TRS.init_node(tran_out_node);

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
		if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
		{
			//¼³ºñID °¡ ¾øÀ»°æ¿ì Ã³¸® -> CORE ¿¡·¯ Ã³¸®.
		
		}
		if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			//END ½ÇÆÐÇØµµ °è¼Ó ÁøÇàÇØ¾ß ÇØ¼­ ÁÖ¼®Ã³¸® 20200212
			//TRS.clone(out_node, tran_out_node);
			//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			//TRS.free_node(tran_in_node);
			//TRS.free_node(tran_out_node);
			//return MP_FALSE;
		}
		STOPWATCH_END("MAIN_LOT_END_ELAPSED_TIME", start_time);
	}
	*/

	
	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);

	start_time = STOPWATCH_START();
	//CWIPLOTSTR Á¤º¸ ¾÷µ¥ÀÌÆ®
	{
		int i_repcnt = 0;
		int i_openstep = 0;
		struct MWIPLOTCMB_TAG MWIPLOTCMB;
		struct CWIPLOTSTR_TAG CWIPLOTSTR;

		i_openstep = 2; 

		////120 CELL CHECK
		//if (MWIPMATDEF.MAT_CMF_2[0] == 'Y')
		//{
		//	i_openstep = 3;
		//}

		//MAT_CMF_3 144 MAT_CMF_2 = 'N'
		//MAT_CMF_3 120	MAT_CMF_2 = 'Y'
		//MAT_CMF_3 156
		//MAT_CMF_3 132
		if (memcmp(MWIPMATDEF.MAT_CMF_3, "120", strlen("120")) == 0)
		{
			i_openstep = 3;
		}
		else if (memcmp(MWIPMATDEF.MAT_CMF_3, "144", strlen("144")) == 0)
		{
			i_openstep = 2; 
		}

		else if (memcmp(MWIPMATDEF.MAT_CMF_3, "156", strlen("156")) == 0)
		{
			i_openstep = 4; 
		}

		else if (memcmp(MWIPMATDEF.MAT_CMF_3, "132", strlen("132")) == 0)
		{
			i_openstep = 5; 
		}
		else if (memcmp(MWIPMATDEF.MAT_CMF_3, "108", strlen("108")) == 0)
		{
			i_openstep = 6; 
		}


		CDB_init_mwiplotcmb(&MWIPLOTCMB);
		memcpy(MWIPLOTCMB.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		CDB_open_mwiplotcmb(i_openstep, &MWIPLOTCMB);
		if(DB_error_code != DB_SUCCESS)
		{ 		
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "MWIPLOTCMB OPEN", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
        
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		while(1)
		{
			CDB_fetch_mwiplotcmb(i_openstep, &MWIPLOTCMB);
			if(DB_error_code == DB_NOT_FOUND)
			{ 
				CDB_close_mwiplotcmb(i_openstep);
				break; 
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.set_fieldmsg(out_node, "MWIPLOTCMB FETCH", MP_NVST);
				TRS.set_fieldmsg(out_node, "LOT ID", MP_STR, sizeof(MWIPLOTCMB.LOT_ID), MWIPLOTCMB.LOT_ID);				
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				CDB_close_mwiplotcmb(i_openstep);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			CDB_init_cwiplotstr(&CWIPLOTSTR);
			memcpy(CWIPLOTSTR.FACTORY, MWIPLOTCMB.FACTORY, sizeof(MWIPLOTCMB.FACTORY));
			memcpy(CWIPLOTSTR.LOT_ID, MWIPLOTCMB.LOT_ID, sizeof(MWIPLOTCMB.LOT_ID));
			memcpy(CWIPLOTSTR.STRING_ID, MWIPLOTCMB.FROM_TO_LOT_ID, sizeof(MWIPLOTCMB.FROM_TO_LOT_ID));
			CDB_select_cwiplotstr_for_update(1, &CWIPLOTSTR);
			if(DB_error_code != DB_SUCCESS) 
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					memcpy(CWIPLOTSTR.CREATE_TIME, MWIPLOTCMB.TRAN_TIME, sizeof(CWIPLOTSTR.CREATE_TIME));
					CDB_insert_cwiplotstr(&CWIPLOTSTR);
				}
			}

			memcpy(CWIPLOTSTR.STRING_LOC, MWIPLOTCMB.OPER, sizeof(CWIPLOTSTR.STRING_LOC)); //A01, A13 ÀÌ·±°ª µé¾î¿Å.
			CWIPLOTSTR.CMF_2[0] = MWIPLOTCMB.HIST_DEL_FLAG; //R OR L ÀÓ
			COM_itoa_left(CWIPLOTSTR.CMF_3, MWIPLOTCMB.HIST_SEQ, sizeof(CWIPLOTSTR.CMF_3));
			CDB_update_cwiplotstr(1, &CWIPLOTSTR);
			if(DB_error_code != DB_SUCCESS) 
			{
				continue;
			}

			if ( CWIPLOTSTR.CMF_2[0] != 'L' &&  CWIPLOTSTR.CMF_2[0] != 'R'  )
			{
				i_repcnt++;
			}
			

		}

		//REPAIR STRING »ç¿ë¼ö 
		COM_itoa_left(MWIPLOTSTS.LOT_CMF_6, i_repcnt, sizeof(MWIPLOTSTS.LOT_CMF_6));
		CDB_update_mwiplotsts(8, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
			//DO NOTHING
		}
	}
	STOPWATCH_END("STRING_LOT_U_ELAPSED_TIME", start_time);
    

	//CWIPCELLAM Á¤º¸ LOT ID ¾÷µ¥ÀÌÆ®
	{
		CDB_init_cwipcellam(&CWIPCELLAM);

		TRS.copy(CWIPCELLAM.FACTORY, sizeof(CWIPCELLAM.FACTORY), in_node, IN_FACTORY);
	    TRS.copy(CWIPCELLAM.CMF_2, sizeof(CWIPCELLAM.CMF_2), in_node, "LOT_ID");
		CDB_update_cwipcellam(100, &CWIPCELLAM);
		if(DB_error_code != DB_SUCCESS) 
		{
			//DO NOTHING
		}
	}

	// 2023.12.18 ÀÚÀç ÃßÀû¼º start
    // ÀÚÀç ÃßÀû¼º »ý¼º Procedure¿¡¼­ »ç¿ëÇÒ µ¥ÀÌÅÍ »ý¼º
    if (Send_Material_Tracability_Data_Half_Product(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
        return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_MATCH_MATRIX_PALLET()
        - Main sub function of "EAPMES_Match_Matrix_Pallet" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_MATCH_MATRIX_PALLET_OLD(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTSTR_TAG CWIPLOTSTR;

    char s_sys_time[14];
    int i, j;
    int i_string_item_count;
    int i_cell_item_count;

    TRSNode ** STRING_ITEM;
    TRSNode ** CELL_ITEM;

    LOG_head("EAPMES_MATCH_MATRIX_PALLET");
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

    if(EAPMES_Match_Matrix_Pallet_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* String Item */
    STRING_ITEM = TRS.get_list(in_node, "STRING_ITEM");
    i_string_item_count = TRS.get_item_count(in_node, "STRING_ITEM");

    for(i = 0; i < i_string_item_count; i++)
    {
        CELL_ITEM = TRS.get_list(STRING_ITEM[i], "CELL_ITEM");
        i_cell_item_count = TRS.get_item_count(STRING_ITEM[i], "CELL_ITEM");

        for(j = 0; j < i_cell_item_count; j++)
        {
            CDB_init_cwiplotstr(&CWIPLOTSTR);

            TRS.copy(CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID), in_node, "LOT_ID");
            TRS.copy(CWIPLOTSTR.STRING_ID, sizeof(CWIPLOTSTR.STRING_ID), STRING_ITEM[i], "STRING_ID");

            CDB_select_cwiplotstr_for_update(1, &CWIPLOTSTR);
            if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "CWIPLOTSTR SELECT FOR UPDATE", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTSTR.FACTORY), CWIPLOTSTR.FACTORY);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTSTR.LOT_ID), CWIPLOTSTR.LOT_ID);
                TRS.add_fieldmsg(out_node, "STRING_ID", MP_STR, sizeof(CWIPLOTSTR.STRING_ID), CWIPLOTSTR.STRING_ID);
                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            /* Insert or Update */
            TRS.copy(CWIPLOTSTR.LINE_ID, sizeof(CWIPLOTSTR.LINE_ID), in_node, "LINE_ID");
            TRS.copy(CWIPLOTSTR.RES_ID, sizeof(CWIPLOTSTR.RES_ID), in_node, "RES_ID");
            TRS.copy(CWIPLOTSTR.ORDER_ID, sizeof(CWIPLOTSTR.ORDER_ID), in_node, "ORDER_ID");
            TRS.copy(CWIPLOTSTR.CMF_1, sizeof(CWIPLOTSTR.CMF_1), in_node, "PALLET_ID");
            //TRS.copy(CWIPLOTSTR.CMF_2, sizeof(CWIPLOTSTR.CMF_2), CELL_ITEM[j], "LAMA_ID");
            //TRS.copy(CWIPLOTSTR.CMF_3, sizeof(CWIPLOTSTR.CMF_3), CELL_ITEM[j], "CELL_ID");


            if(DB_error_code == DB_SUCCESS)
            {
                /* Update */
                memcpy(CWIPLOTSTR.LAST_TRAN_TIME, s_sys_time, sizeof(CWIPLOTSTR.LAST_TRAN_TIME));

                CDB_update_cwiplotstr(1, &CWIPLOTSTR);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "CWIPLOTSTR INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTSTR.FACTORY), CWIPLOTSTR.FACTORY);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTSTR.LOT_ID), CWIPLOTSTR.LOT_ID);
                    TRS.add_fieldmsg(out_node, "STRING_ID", MP_STR, sizeof(CWIPLOTSTR.STRING_ID), CWIPLOTSTR.STRING_ID);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOTSTR.LINE_ID), CWIPLOTSTR.LINE_ID);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOTSTR.RES_ID), CWIPLOTSTR.RES_ID);
                    TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPLOTSTR.ORDER_ID), CWIPLOTSTR.ORDER_ID);
                    TRS.add_fieldmsg(out_node, "CMF_1", MP_STR, sizeof(CWIPLOTSTR.CMF_1), CWIPLOTSTR.CMF_1);
                    //TRS.add_fieldmsg(out_node, "CMF_2", MP_STR, sizeof(CWIPLOTSTR.CMF_2), CWIPLOTSTR.CMF_2);
                    //TRS.add_fieldmsg(out_node, "CMF_3", MP_STR, sizeof(CWIPLOTSTR.CMF_3), CWIPLOTSTR.CMF_3);
                    TRS.add_fieldmsg(out_node, "LAST_TRAN_TIME", MP_STR, sizeof(CWIPLOTSTR.LAST_TRAN_TIME), CWIPLOTSTR.LAST_TRAN_TIME);
                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }
            else if(DB_error_code == DB_NOT_FOUND)
            {
                /* Insert */
                memcpy(CWIPLOTSTR.CREATE_TIME, s_sys_time, sizeof(CWIPLOTSTR.CREATE_TIME));
                memcpy(CWIPLOTSTR.LAST_TRAN_TIME, s_sys_time, sizeof(CWIPLOTSTR.LAST_TRAN_TIME));

                CDB_insert_cwiplotstr(&CWIPLOTSTR);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "CWIPLOTSTR INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTSTR.FACTORY), CWIPLOTSTR.FACTORY);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTSTR.LOT_ID), CWIPLOTSTR.LOT_ID);
                    TRS.add_fieldmsg(out_node, "STRING_ID", MP_STR, sizeof(CWIPLOTSTR.STRING_ID), CWIPLOTSTR.STRING_ID);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOTSTR.LINE_ID), CWIPLOTSTR.LINE_ID);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOTSTR.RES_ID), CWIPLOTSTR.RES_ID);
                    TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPLOTSTR.ORDER_ID), CWIPLOTSTR.ORDER_ID);
                    TRS.add_fieldmsg(out_node, "CMF_1", MP_STR, sizeof(CWIPLOTSTR.CMF_1), CWIPLOTSTR.CMF_1);
                    //TRS.add_fieldmsg(out_node, "CMF_2", MP_STR, sizeof(CWIPLOTSTR.CMF_2), CWIPLOTSTR.CMF_2);
                    //TRS.add_fieldmsg(out_node, "CMF_3", MP_STR, sizeof(CWIPLOTSTR.CMF_3), CWIPLOTSTR.CMF_3);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPLOTSTR.CREATE_TIME), CWIPLOTSTR.CREATE_TIME);
                    TRS.add_fieldmsg(out_node, "LAST_TRAN_TIME", MP_STR, sizeof(CWIPLOTSTR.LAST_TRAN_TIME), CWIPLOTSTR.LAST_TRAN_TIME);
                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;

                }
            }


            
        }
    }


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Match_Matrix_Pallet_Validation()
        - Main sub function of "EAPMES_MATCH_MATRIX_PALLET" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Match_Matrix_Pallet_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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
/*******************************************************************************
  Send_Material_Tracability_Data_Half_Product()
    - Main sub function of "EAPMES_MATCH_MATRIX_PALLET_E23" function
  Return Value
    - int : 1 (MP_TRUE) or 0 (MP_FALSE)
  Arguments
    - char *s_msg_code : Error Message Code
    - char *s_sys_time : System Time
    - TRSNode *in_node : Input Message structure
    - TRSNode *out_node : Output Message structure
*******************************************************************************/
int Send_Material_Tracability_Data_Half_Product(char* s_msg_code, char* s_sys_time, TRSNode* in_node, TRSNode* out_node)
{
	return MP_TRUE;//24.10.09 RPT 데이터 저장 중지

/*
    struct CWIPCTMTRC_TAG CWIPCTMTRC;

    CDB_init_cwipctmtrc(&CWIPCTMTRC);
    TRS.copy(CWIPCTMTRC.FACTORY, sizeof(CWIPCTMTRC.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPCTMTRC.LOT_ID, sizeof(CWIPCTMTRC.LOT_ID), in_node, "LOT_ID");
    memcpy(CWIPCTMTRC.KIND, "TRACE", strlen("TRACE"));
    CWIPCTMTRC.WIP_FLAG = 'W';   // WIP

    CDB_select_cwipctmtrc(2, &CWIPCTMTRC);
    if (DB_error_code == DB_NOT_FOUND)
    {
        memcpy(CWIPCTMTRC.TRAN_TIME, s_sys_time, sizeof(CWIPCTMTRC.TRAN_TIME));
        CDB_insert_cwipctmtrc(2, &CWIPCTMTRC);  // RPT에 저장

        //CDB_insert_cwipctmtrc(3, &CWIPCTMTRC);  // ARC에 저장
    }
*/
 //   char s_channel[100];
 //   
 //   LOG_head("Send_Material_Tracability_Data_Half_Product");
 //   TRS.log_add_all_members(in_node);
 //   COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
 //   
	//memset(s_channel, 0x00, sizeof(s_channel));
 //   sprintf(s_channel, "/%.*s/GTMServer", 4, gs_site_id);

 //   // Report DB, Archive DB 에 자재 추적성 데이터 전송
 //   // FACTORY, LOT_ID, KIND, WIP_FLAG 전송
 //   TRS.set_char(in_node, IN_PROCSTEP, '1');
 //   TRS.set_nstring(in_node, "KIND", "TRACE");
 //   TRS.set_char(in_node, "WIP_FLAG", 'W');

 //   // Report DB 전송용
 //   if (CallService("CEIS",
 //       "CEIS_Save_Traceability_Material_Data_E23",
 //       in_node,
 //       0x00,
 //       s_channel,
 //       18000000, //gi_default_ttl, 
 //       DM_GUNICAST) != MP_TRUE)
 //   {
 //       // Error Log 생성
 //       LOG_head("CEIS_Save_Traceability_Material_Data_E23 W Send Error");
 //       COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
 //       return MP_FALSE;
 //   }

 //   // Archive DB 전송용
 //   memset(s_channel, 0x00, sizeof(s_channel));
 //   sprintf(s_channel, "/%.*s/ARCServer", 4, gs_site_id);

 //   LOG_head("Send_Material_Tracability_Data_Half_Product_ARC Channel");
 //   LOG_add("Channel", MP_STR, sizeof(s_channel), s_channel);
 //   LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
 //   COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
 //   
	//if (CallService("CEIS",
 //       "CEIS_Save_Traceability_Material_Data_ARC",
 //       in_node,
 //       0x00,
 //       s_channel,
 //       18000000, //gi_default_ttl, 
 //       DM_GUNICAST) != MP_TRUE)
 //   {
 //       // Error Log 생성
 //       LOG_head("CEIS_Save_Traceability_Material_Data_ARC W Send Error");
 //       COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
 //       return MP_FALSE;
 //   }

    return MP_TRUE;
}
