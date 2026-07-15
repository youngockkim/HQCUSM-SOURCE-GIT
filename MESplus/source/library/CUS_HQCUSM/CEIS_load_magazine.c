/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_load_magazine.c
    Description : EAPMES Load Magazine Service

    MES Version : 5.3.4 ~
	25.12

    Function List
        - EAPMES_Load_Magazine()
            + Setup service interface function
        - EAPMES_LOAD_MAGAZINE()
            + Main sub function of EAPMES_Load_Magazine function
            + Setup service main business function
        - EAPMES_Load_Magazine_Validation()
            + Main sub function of EAPMES_LOAD_MAGAZINE function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_LOAD_MAGAZINE()
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

int EAPMES_Load_Magazine_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Load_Magazine()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Load_Magazine(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_LOAD_MAGAZINE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_LOAD_MAGAZINE", out_node);

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
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Load_Magazine", strlen("EAPMES_Load_Magazine"));
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
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.set_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
	TRS.set_nstring(out_node, "VMAGAZINE_ID",  TRS.get_string(in_node, "VMAGAZINE_ID"));
    TRS.set_nstring(out_node, "ORDER_ID",  TRS.get_string(in_node, "ORDER_ID"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));
    TRS.set_nstring(out_node, "EQP_TYPE", TRS.get_string(in_node, "EQP_TYPE"));
    TRS.set_nstring(out_node, "MAGAZINE_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
    TRS.set_int(out_node, "MAGAZINE_QTY", TRS.get_int(in_node, "MAGAZINE_QTY"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if (TRS.get_char(out_node, "PRE_SEND_FLAG") != 'Y')
	{
		if(CallService(MODULE_EAP, 
			"MESEAP_Load_Magazine", 
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

	/* Save magazine log */
	TRS.set_string(in_node, "ACTION", "LOAD", strlen("LOAD")); //200 Load, 201 Unload
	CEIS_Save_Load_Unload_Magazine(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_LOAD_MAGAZINE()
        - Main sub function of "EAPMES_Load_Magazine" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_LOAD_MAGAZINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MRASRESDEF_TAG	MRASRESDEF;
	struct MWIPORDSTS_TAG   MWIPORDSTS;
	struct MRASCRRDEF_TAG   MRASCRRDEF;
	struct CCLVMAGCHK_TAG   CCLVMAGCHK;

	clock_t start_time;
    char   s_sys_time[14];
	char   c_create_crr_flag = 'N';

	LOG_head("EAPMES_LOAD_MAGAZINE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Load_Magazine_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

	 /* Check whether the Order ID exists or not */
    DBC_init_mwipordsts(&MWIPORDSTS);
    TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
    DBC_select_mwipordsts(1, &MWIPORDSTS);
    if(DB_error_code != DB_SUCCESS)
	{
		//ÀÛ¾÷Áö½Ã ¾øÀ¸¸é ¿¡·¯Ã³¸®ÇÔ.
		strcpy(s_msg_code, "ORD-0002");
		TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
		TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }
	//25.10.24 - START
	// CLEAVING 클링 오더와 풀셀 오더가 다른 경우
	//테버/클리빙 오더 Validation 사항 테스트 및 개발 완료건(10/24 Update)
	//LD만 되도록 변경함
	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "LD") == 0)
	{
		if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER)) == 0)
		{
			if(memcmp(MRASRESDEF.RES_CMF_9, TRS.get_string(in_node, "ORDER_ID"), strlen(TRS.get_string(in_node, "ORDER_ID"))) != 0)
			{
				CDB_init_cclvmagchk(&CCLVMAGCHK);
				TRS.copy(CCLVMAGCHK.RES_ID, sizeof(MWIPORDSTS.RES_ID), in_node, "RES_ID");
				memcpy(CCLVMAGCHK.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
				TRS.copy(CCLVMAGCHK.VMAGAZINE_ID, sizeof(CCLVMAGCHK.VMAGAZINE_ID), in_node, "VMAGAZINE_ID");
				TRS.copy(CCLVMAGCHK.MAGAZINE_ORDER_ID, sizeof(CCLVMAGCHK.MAGAZINE_ORDER_ID), in_node, "ORDER_ID");
				TRS.copy(CCLVMAGCHK.MAGAZINE_ID, sizeof(CCLVMAGCHK.MAGAZINE_ID), in_node, "MAGAZINE_ID");
				memcpy(CCLVMAGCHK.ORDER_ID, MRASRESDEF.RES_CMF_9, sizeof(CCLVMAGCHK.ORDER_ID));
			
				CDB_insert_cclvmagchk(&CCLVMAGCHK);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO Nothing
				}
				else
				{
					DB_commit();
				}

				//[25.01.14]WIP-0580: 클리빙 오더와 풀셀 오더가 다른 경우
				if (strcmp(TRS.get_string(in_node, "RES_ID"), "US-E0-CV-01") == 0)
				{
					strcpy(s_msg_code, "ORD-0028");
					return MP_TRUE;
				}
				//[25.01.14]WIP-0580: 클리빙 오더와 풀셀 오더가 다른 경우
			}
		}
	}
	//25.10.24 - END

	// CLEAVING ÀÇ °æ¿ì ÀÛ¾÷Áö½Ã¼­ ´Ù¸£¸é ¿¡·¯Ã³¸®ÇÔ
	/*if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER)) == 0)
	{
		if(memcmp(MRASRESDEF.RES_CMF_9, TRS.get_string(in_node, "ORDER_ID"), strlen(TRS.get_string(in_node, "ORDER_ID"))) != 0)
		{
			strcpy(s_msg_code, "WIP-0582");
			TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_CMF_9", MP_STR, sizeof(MRASRESDEF.RES_CMF_9), MRASRESDEF.RES_CMF_9);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}*/
	
	//CARRIER ID SELECT
	DBC_init_mrascrrdef(&MRASCRRDEF);
	memcpy(MRASCRRDEF.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
	TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), in_node, "MAGAZINE_ID");
	DBC_select_mrascrrdef(1, &MRASCRRDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
		c_create_crr_flag = 'Y';
	}

	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "LD") == 0)
	{
		start_time = STOPWATCH_START();
		/*******************************************************************************/
		//LOAD PORT ºÎºÐ
		/* CLEAVING MAGAZINE LOAD ¿Í TABBER MAGAZINE LOAD EVENT °¡ ¿Ã¶ó¿Å */
		// µÎÀÛ¾÷ÀÌ MAGAZINE ´ÜÀ§·Î START ÇÏ´Â°ÍÀÌ¹Ç·Î CWIP_START_LOT ¸¸ È£ÃâÇÔ 
		// CWIP_START_LOT ¾È¿¡¼­ ½ÇÁ¦ MAGAZINE À» ÀÐ¾î¼­ ½ÃÀÛÇÔ
		/*******************************************************************************/
		TRS.set_string(in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2));
		TRS.set_nstring(in_node, "LOT_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
		TRS.set_char(in_node, "MAGAZINE_INPUT_FLAG", 'Y'); //LOT ÇÊµå¿¡ MAGAZINE »ç¿ë

		//TABBER ÀÇ °æ¿ì Ä«Æ®Ã³¸®·Î ÀÎÇØ ¼Óµµ°¡ ´Ê¾îÁú¼ö ÀÖÀ¸¹Ç·Î ¼³ºñ¿¡ ¸ÕÀú ¸Þ¼¼Áö¸¦ ´øÁü
		// CLEAVING °æ¿ìµµ timeout ¹®Á¦·Î Ãß°¡
		if (strcmp(TRS.get_string(in_node, "OPER"), HQCEL_M1_TABBER_OPER) == 0 ||
			strcmp(TRS.get_string(in_node, "OPER"), HQCEL_M1_CLEAVING_OPER) == 0)
		{
			char s_channel[100]; 

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
			TRS.set_nstring(out_node, "VMAGAZINE_ID",  TRS.get_string(in_node, "VMAGAZINE_ID"));
			TRS.set_nstring(out_node, "ORDER_ID",  TRS.get_string(in_node, "ORDER_ID"));
			TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));
			TRS.set_nstring(out_node, "EQP_TYPE", TRS.get_string(in_node, "EQP_TYPE"));
			TRS.set_nstring(out_node, "MAGAZINE_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
			TRS.set_int(out_node, "MAGAZINE_QTY", TRS.get_int(in_node, "MAGAZINE_QTY"));

			/* MES to EAP */
			memset(s_channel, 0x00, sizeof(s_channel));
			sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
			//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
			strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
			COM_add_null(s_channel, sizeof(s_channel));
   
			if(CallService(MODULE_EAP, 
				"MESEAP_Load_Magazine", 
				out_node, 
				0x00, 
				s_channel, 
				gi_default_ttl, 
				DM_UNICAST) != MP_TRUE)
			{
				// Error
			}
			
			TRS.set_char(out_node, "PRE_SEND_FLAG", 'Y');
		}

		
		/* 복원
		if(CWIP_START_LOT(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		*/
		STOPWATCH_END("LOT_START_ELAPSED_TIME", start_time);
	}
	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "ULD") == 0)
	{
		start_time = STOPWATCH_START();
		//CLEAVING ÀÇ UNLOAD ºÎºÐÀÓ...
		//Æ¯º°È÷ ÇÒ°Å ¾øÀ½.. 
		//UNLOAD EVENT ¿¡¼­ HCELL ±¸¼ºÇÏ´Â ·ÎÁ÷¸¸ ÇÏ¸éµÊ.

		//UNLOAD EVENT ¿¡¼­ ¾ø´Â ¸Å°ÅÁøÀÌ ¿Ã¶ó¿À¸é MAGAZINE »ý¼ºÇÏ´Â ·ÎÁ÷Ãß°¡ÇÔ.

		/* MAGAZINE SIZE CHECK */
		if ((strlen(TRS.get_string(in_node, "MAGAZINE_ID")) != 14) && 
			(strlen(TRS.get_string(in_node, "MAGAZINE_ID")) != 13)) 
		{
			c_create_crr_flag = 'N';
		}

		if(c_create_crr_flag == 'Y')
		{
			//¸Å°ÅÁø ÀÚµ¿ »ý¼º.
			memcpy(MRASCRRDEF.CRR_DESC, MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID));
			memcpy(MRASCRRDEF.CRR_GROUP, "US_H_M", strlen("US_H_M"));
			memcpy(MRASCRRDEF.CRR_STATUS, "WAIT", strlen("WAIT"));
			MRASCRRDEF.CRR_STATUS_FLAG = 'W';
			MRASCRRDEF.CRR_TYPE1[0] = 'M';
			MRASCRRDEF.CRR_SIZE = 100000;
			memcpy(MRASCRRDEF.USE_AREA_ID, "CV", strlen("CV"));
			memcpy(MRASCRRDEF.USE_SUB_AREA_ID, "CV1", strlen("CV1"));
			memcpy(MRASCRRDEF.LAST_TRAN_CODE, "CREATE", strlen("CREATE"));
			memcpy(MRASCRRDEF.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
			
			memcpy(MRASCRRDEF.CREATE_USER_ID, "AUTO", strlen("AUTO"));
			memcpy(MRASCRRDEF.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

			DBC_insert_mrascrrdef(&MRASCRRDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			STOPWATCH_END("MAGAZINE_CREATE_ELAPSED_TIME", start_time);
		}
		STOPWATCH_END("MAGAZINE_UL_ELAPSED_TIME", start_time);
      
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Load_Magazine_Validation()
        - Main sub function of "EAPMES_LOAD_MAGAZINE" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Load_Magazine_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

