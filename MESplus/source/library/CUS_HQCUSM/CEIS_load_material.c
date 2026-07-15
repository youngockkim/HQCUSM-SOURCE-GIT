/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_load_material.c
    Description : EAPMES Load Material Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Load_Material()
            + Setup service interface function
        - EAPMES_LOAD_MATERIAL()
            + Main sub function of EAPMES_Load_Material function
            + Setup service main business function
        - EAPMES_Load_Material_Validation()
            + Main sub function of EAPMES_LOAD_MATERIAL function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_LOAD_MATERIAL()
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

int EAPMES_Load_Material_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CRAS_UPDATE_ATTACHED_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);


/*******************************************************************************
    EAPMES_Load_Material()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Load_Material(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
	char s_order_id[25];				//[25.10.09][MES] 자재 검증 결과 저장 테이블 생성 및 로직 개발 요청의 건
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CWIPMATVAL_TAG CWIPMATVAL;	//[25.10.09][MES] 자재 검증 결과 저장 테이블 생성 및 로직 개발 요청의 건
    char s_channel[100]; 
	char s_sys_time[14];				//[25.10.09][MES] 자재 검증 결과 저장 테이블 생성 및 로직 개발 요청의 건
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	memset(s_order_id, 0x00, 25);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_LOAD_MATERIAL(s_order_id,s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_LOAD_MATERIAL", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
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
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Load_Material", strlen("EAPMES_Load_Material"));
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

	//[25.10.09][MES] 자재 검증 결과 저장 테이블 생성 및 로직 개발 요청의 건 - START
	CDB_init_cwipmatval(&CWIPMATVAL);
	TRS.copy(CWIPMATVAL.FACTORY, sizeof(CWIPMATVAL.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPMATVAL.RES_ID, sizeof(CWIPMATVAL.RES_ID), in_node, "RES_ID");
	memcpy(CWIPMATVAL.ORDER_ID, s_order_id, 12);
	//TRS.copy(CWIPMATVAL.MAT_ID, sizeof(CWIPMATVAL.MAT_ID), in_node, "MAT_ID");
	TRS.copy(CWIPMATVAL.MAT_TYPE, sizeof(CWIPMATVAL.MAT_TYPE), in_node, "MAT_TYPE");
	TRS.copy(CWIPMATVAL.VENDOR_BARCODE_ID, sizeof(CWIPMATVAL.VENDOR_BARCODE_ID), in_node, "MAT_ID");
	TRS.copy(CWIPMATVAL.SUP_BARCODE_ID, sizeof(CWIPMATVAL.SUP_BARCODE_ID), in_node, "VENDOR_BARCODE");
	
	if(i_ret == MP_TRUE)
    {
        CWIPMATVAL.RESULT_VALUE[0] = 'O';
		CWIPMATVAL.RESULT_VALUE[1] = 'K';
    }
    else
    {
        CWIPMATVAL.RESULT_VALUE[0] = 'N';
		CWIPMATVAL.RESULT_VALUE[1] = 'G';
		memcpy(CWIPMATVAL.ERROR_VALUE, s_msg_code, 9);
    }
	
	memcpy(CWIPMATVAL.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
	memcpy(CWIPMATVAL.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	
	CDB_insert_cwipmatval(&CWIPMATVAL);
	if(DB_error_code == DB_SUCCESS)
	{
		DB_commit();
	}
	//[25.10.09][MES] 자재 검증 결과 저장 테이블 생성 및 로직 개발 요청의 건 - END

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
    TRS.set_nstring(out_node, "MAT_ID", TRS.get_string(in_node, "MAT_ID"));
    TRS.set_nstring(out_node, "MAT_TYPE", TRS.get_string(in_node, "MAT_TYPE"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Load_Material", 
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
    EAPMES_LOAD_MATERIAL()
        - Main sub function of "EAPMES_Load_Material" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_LOAD_MATERIAL(char *s_order_id,char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CWIPORDBOM_TAG CWIPORDBOM;
	struct CWIPORDBOM_TAG CWIPORDBOM_MAT;

	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CINVLOTSTS_TAG CINVLOTSTS;

	int barcode_lenth ;
	char barcode_data[40] ;
	int i;
	int j;
	int min_lenth_po;
	int max_lenth_po;
	int start_len_lo;
	char chk_ng = ' ';




	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

    char   s_sys_time[14];
	char   c_validation_flag = 'N';
	
    LOG_head("EAPMES_LOAD_MATERIAL");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Load_Material_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
	/* Get order information */
	DBC_init_mwipordsts(&MWIPORDSTS);
	TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
	
	//ORDER GET
	if (COM_isspace(MRASRESDEF.RES_CMF_9, sizeof(MRASRESDEF.RES_CMF_9)) == MP_FALSE)
	{
		//¼³ºñ¿¡¼­ VALIDATION ÇÑ ORDER : CLAVING/TABBER
		memcpy(MWIPORDSTS.ORDER_ID, MRASRESDEF.RES_CMF_9, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(s_order_id, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));	

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
			memcpy(s_order_id, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));	

		}
	}

	DBC_select_mwipordsts(1, &MWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			/*return MP_FALSE;*/
		}
		else
		{
			strcpy(s_msg_code, "ORD-0002");
			TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	tran_in_node = TRS.create_node("ATTACH_MATERIAL_IN");
    CCOM_copy_in_node(in_node, tran_in_node);

	TRS.add_char(tran_in_node, "PROCSTEP", 'I');
	TRS.add_nstring(tran_in_node, "FACTORY", TRS.get_string(in_node, "FACTORY"));
	TRS.add_nstring(tran_in_node, "USERID", TRS.get_string(in_node, "USERID"));
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	TRS.add_string(tran_in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2));
	TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
	TRS.add_string(tran_in_node, "FLOW", MWIPORDSTS.FLOW, sizeof(MWIPORDSTS.FLOW));
	TRS.add_string(tran_in_node, "MAT_ID",  MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
	TRS.add_nstring(tran_in_node, "INV_BARCODE_ID", TRS.get_string(in_node, "MAT_ID"));
	TRS.add_nstring(tran_in_node, "POSITION_ID", TRS.get_string(in_node, "LOC_ID"));
	TRS.add_nstring(tran_in_node, "CMF_1", TRS.get_string(in_node, "LINE_ID"));	
	TRS.add_nstring(tran_in_node, "INV_TYPE", TRS.get_string(in_node, "MAT_TYPE"));

	if(CRAS_UPDATE_ATTACHED_MATERIAL_LIST(s_msg_code, tran_in_node, out_node)== MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		TRS.free_node(tran_in_node);
		return MP_FALSE;
	}

	TRS.free_node(tran_in_node);

	c_validation_flag = 'N';
	//자재 Validation 체크 
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@VALIDATION_MAT", strlen("@VALIDATION_MAT"));
	TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node,  "MAT_TYPE"); //MATERIAL TYPE
	memcpy(MGCMLAGDAT.KEY_2, MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2)); //OPERATION
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_2[0] == 'Y'))
	{
		//VALIDATION CHECK
		//MGCMLAGDAT TABLE (@VALIDATION_MAT)¿¡¼­ DATA21 = 'Y' ÀÌ¸é ¿¡·¯¹ß»ý
		c_validation_flag = 'Y';
	}

	if (c_validation_flag == 'Y')
	{
		//[Eagle1 공정별 자재 Validation - 10.07]
		//아래 순서대로  데이터가 존재하면 OK, 없으면 NG
		//--1.MAT_ID[CIM]기준으로 BOM[CWIPORDBOM]의 VENDOR 가 존재 하는지 점검[기존 로직]
		//--2.MAT_ID[CIM]기준으로 자재 바코드가 존재 하면 점검[기존 로직]
		//		- CINVLOTSTS.VENDOR_BARCD 기준으로 조회	[기존 로직]
		//		- MAT_ID[CIM] 가 40자리가 넘는 경우 40자까지만 잘라서 조회[변경 로직]
		//--3.GCM에 시작/종료 자릿수가 저장 되어 있지 않다면 2번 까지만 진행

		//--4.MAT_ID[CIM]기준으로 GCM에 등록 되어 있는 시작/종료 자릿수를 조합 하여 바코드 넘버를 생성하여[신규 로직]
		//	 BOM 정보를 조회함
		//		-EX]7600006307100001200036103000482507210100 ->000000000012000361
		//--4.1]자재 타입이 TPT인 경우 / BS로 한번더 BOM 정보를 조회함

		CDB_init_cwipordbom(&CWIPORDBOM);
		memcpy(CWIPORDBOM.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		memcpy(CWIPORDBOM.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		TRS.copy(CWIPORDBOM.VENDOR, sizeof(CWIPORDBOM.VENDOR), in_node, "MAT_ID");  //BARCODE ID
		TRS.copy(CWIPORDBOM.MATE_TYPE, sizeof(CWIPORDBOM.MATE_TYPE), in_node, "MAT_TYPE");  //BARCODE TYPE
	
	
		//1.MAT_ID[CIM]기준으로 BOM[CWIPORDBOM]의 VENDOR 가 존재 하는지 점검[기존 로직]
		if ( CDB_select_cwipordbom_scalar(8, &CWIPORDBOM) < 1)
		{	

			
			CDB_init_cinvlotsts(&CINVLOTSTS);
			memcpy(CINVLOTSTS.FACTORY, CWIPORDBOM.FACTORY, sizeof(CWIPORDBOM.FACTORY));
			TRS.copy(CINVLOTSTS.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID), in_node, "MAT_ID");  //BARCODE ID
			//CIM-> 보내주는 바코드가 40자리보다 크면 40자리까지만 저장
			if(strlen(TRS.get_string(in_node, "MAT_ID")) > 40)
			{
				TRS.copy(CINVLOTSTS.VENDOR_BARCD, 40, in_node, "MAT_ID");  //BARCODE ID
			}
			else
			{
				TRS.copy(CINVLOTSTS.VENDOR_BARCD, sizeof(CINVLOTSTS.VENDOR_BARCD), in_node, "MAT_ID");  //BARCODE ID
			}

			//--2.MAT_ID[CIM]기준으로 자재 바코드가 존재 하면 점검[기존 로직]
			if ( CDB_select_cinvlotsts_scalar(2, &CINVLOTSTS) < 1)
		{		//3.GCM에 등록되어 있지 않으면 아래 로직은 타지 않음
				if (COM_isspace(MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4)) == MP_TRUE ||
					COM_isspace(MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5)) == MP_TRUE
					)
				{
					chk_ng = 'X';
					strcpy(s_msg_code, "INV-0018");
					TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
					TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

	
				///--4.MAT_ID[CIM]기준으로 GCM에 등록 되어 있는 시작/종료 자릿수를 조합 하여 바코드 넘버를 생성하여[신규 로직]
				barcode_lenth = 0;
				barcode_lenth = strlen(TRS.get_string(in_node, "MAT_ID"));
				
				if(memcmp(TRS.get_string(in_node, "MAT_TYPE"), "TPT", strlen("TPT")) == 0)
				{
					if(barcode_lenth < 39)
					{
						chk_ng = 'X';
						strcpy(s_msg_code, "INV-0018");
					}
				}
				else
				{
					if(barcode_lenth < 40)
					{
						chk_ng = 'X';
						strcpy(s_msg_code, "INV-0018");
					}
				}


				if(barcode_lenth > 40)		//40자리보다 크면 40자리까지만 저장한다.
				{
					memset(barcode_data, ' ', sizeof(barcode_data));		//초기화
					TRS.copy(barcode_data, sizeof(barcode_data), in_node, "MAT_ID");
				}
					
					memset(barcode_data, ' ', sizeof(barcode_data));		//초기화
					TRS.copy(barcode_data, sizeof(barcode_data), in_node, "MAT_ID");

				
					//한번더 체크
					CDB_init_cinvlotsts(&CINVLOTSTS);
					memcpy(CINVLOTSTS.FACTORY, CWIPORDBOM.FACTORY, sizeof(CWIPORDBOM.FACTORY));
					min_lenth_po = 0;
					max_lenth_po = 0;
					start_len_lo = 1;

					min_lenth_po = COM_atoi(MGCMLAGDAT.DATA_4,sizeof(MGCMLAGDAT.DATA_4));
					max_lenth_po = COM_atoi(MGCMLAGDAT.DATA_5,sizeof(MGCMLAGDAT.DATA_5));
					
					CDB_init_cwipordbom(&CWIPORDBOM_MAT);
					memcpy(CWIPORDBOM_MAT.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
					memcpy(CWIPORDBOM_MAT.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
					
					TRS.copy(CWIPORDBOM_MAT.MATE_TYPE, sizeof(CWIPORDBOM_MAT.MATE_TYPE), in_node,  "MAT_TYPE"); //MATERIAL TYPE
					
					j = 10;
					for (i = 0; i < 40; i++)
					{	if(i < 10)		//1~10 자리 까지는 0으로 채움
						{
							CWIPORDBOM_MAT.MAT_ID[i] = '0';
						}
						if( i > 0)		//자릿수 사이의 값을 넣어준다
						{
							if (
								
								(min_lenth_po  <= start_len_lo)
															&& 
								(max_lenth_po >= start_len_lo)
								)

							{	
								
								CWIPORDBOM_MAT.MAT_ID[j] = barcode_data[start_len_lo-1];
								j = j + 1;

							}
						}

						start_len_lo = start_len_lo + 1;

					}
					
					if(memcmp(CWIPORDBOM_MAT.MATE_TYPE, "TPT", strlen("TPT")) == 0)
					{
						memset(CWIPORDBOM_MAT.MATE_TYPE, ' ', sizeof(CWIPORDBOM_MAT.MATE_TYPE));
						memcpy(CWIPORDBOM_MAT.MATE_TYPE, "BS", 2);
					}

					if(memcmp(CWIPORDBOM_MAT.MATE_TYPE, "FLX", strlen("FLX")) == 0)
					{
						memset(CWIPORDBOM_MAT.MATE_TYPE, ' ', sizeof(CWIPORDBOM_MAT.MATE_TYPE));
						memcpy(CWIPORDBOM_MAT.MATE_TYPE, "FLUX", 4);
					}

					if ( CDB_select_cwipordbom_scalar(7, &CWIPORDBOM_MAT) < 1)
					{ 

						chk_ng = 'X';
						strcpy(s_msg_code, "INV-0018");
					}
			}
			else
			{	
		
				chk_ng = 'X';
				//오더가 없는경우
				strcpy(s_msg_code, "INV-0017");
			}
			if(chk_ng == 'X')
			{
				TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Load_Material_Validation()
        - Main sub function of "EAPMES_LOAD_MATERIAL" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Load_Material_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

