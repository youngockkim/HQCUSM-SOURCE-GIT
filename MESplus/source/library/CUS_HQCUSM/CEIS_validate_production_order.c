/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_validate_production_order.c
    Description : EAPMES Validate Production Order Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Validate_Production_Order()
            + Setup service interface function
        - EAPMES_VALIDATE_PRODUCTION_ORDER()
            + Main sub function of EAPMES_Validate_Production_Order function
            + Setup service main business function
        - EAPMES_Validate_Production_Order_Validation()
            + Main sub function of EAPMES_VALIDATE_PRODUCTION_ORDER function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_VALIDATE_PRODUCTION_ORDER()
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

int EAPMES_Validate_Production_Order_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Validate_Production_Order()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Production_Order(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_VALIDATE_PRODUCTION_ORDER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_VALIDATE_PRODUCTION_ORDER", out_node);

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
	/* 특정 에러처리를 무시할경우 사용 ERROR  */
	// VALIDATION 하라고 셋팅된 에러만 에러처리함.
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
	memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
	memcpy(MGCMLAGDAT.KEY_2, "VALIDATION", strlen("VALIDATION"));
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Validate_Production_Order", strlen("EAPMES_Validate_Production_Order"));
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
    //COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

    
    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
    TRS.set_nstring(out_node, "BOM_ID", TRS.get_string(in_node, "BOM_ID"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Validate_Production_Order",
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
    EAPMES_VALIDATE_PRODUCTION_ORDER()
        - Main sub function of "EAPMES_Validate_Production_Order" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_VALIDATE_PRODUCTION_ORDER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPORDSTS_TAG MWIPORDSTS;
	struct CRESORDSTS_TAG CRESORDSTS;
	struct CRESORDHIS_TAG CRESORDHIS;

//    struct CWIPORDSTS_TAG CWIPORDSTS;

 /*   TRSNode* tran_in_node;
    TRSNode* tran_out_node;*/

	char s_sys_time[14];
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

    LOG_head("EAPMES_VALIDATE_PRODUCTION_ORDER");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Validate_Production_Order_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Check whether the Order ID exists or not */
    DBC_init_mwipordsts(&MWIPORDSTS);
    TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
    DBC_select_mwipordsts(2, &MWIPORDSTS);
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

    /* Check whether the EPR BOM ID */
    if(TRS.str_cmp(in_node, "LINE_ID", HQCEL_M1_LINE_CVL01) != 0) /* Do not check ERP BOM ID for Cleaving Line */
    {
	    if(TRS.mem_cmp(in_node, "BOM_ID", MWIPORDSTS.ORD_CMF_7, sizeof(MWIPORDSTS.ORD_CMF_7)) != 0)
        {
		    strcpy(s_msg_code, "ORD-0027");
            TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

		    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
	    }
    }

    /* Change current order */
    /*
	Main Line 은 Match Matrix Pallet 에 현재 작업지시 정보 저장함.. 다른쪽 도 필요함 저장필요..~
    tran_in_node = TRS.create_node("CHANGE_ORDER_IN");
    tran_out_node = TRS.create_node("CHANGE_ORDER_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
	TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
    TRS.add_nstring(tran_in_node, "ORDER_ID", TRS.get_string(in_node,"ORDER_ID"));
  
    if(CORD_CHANGE_CURRENT_ORDER(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
        // Do Nothing
	}
    
	TRS.free_node(tran_in_node);
    TRS.free_node(tran_out_node);
    */

	//현재 설비의 진행 ORDER UPDATE
	{
		struct MRASRESDEF_TAG MRASRESDEF_ORD;
		DBC_init_mrasresdef(&MRASRESDEF_ORD);
		
		TRS.copy(MRASRESDEF_ORD.FACTORY, sizeof(MRASRESDEF_ORD.FACTORY), in_node, "FACTORY");
		TRS.copy(MRASRESDEF_ORD.RES_ID, sizeof(MRASRESDEF_ORD.RES_ID), in_node, "RES_ID");

		DBC_select_mrasresdef_for_update(1, &MRASRESDEF_ORD);//20190930 장애대응 
		//DBC_select_mrasresdef(1, &MRASRESDEF_ORD);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		
		if (memcmp(MRASRESDEF_ORD.RES_CMF_9, TRS.get_string(in_node, "ORDER_ID"), 
							strlen(TRS.get_string(in_node, "ORDER_ID")))  != 0 )
		{
			TRS.copy(MRASRESDEF_ORD.RES_CMF_9, sizeof(MRASRESDEF_ORD.RES_CMF_9), in_node, "ORDER_ID");
			DBC_update_mrasresdef(102, &MRASRESDEF_ORD);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
	}

	//Order Chage History
	CDB_init_cresordsts(&CRESORDSTS);
    TRS.copy(CRESORDSTS.RES_ID, sizeof(CRESORDSTS.RES_ID), in_node, "RES_ID");
    CDB_select_cresordsts(1, &CRESORDSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        //DO not thing
		if(DB_error_code == DB_NOT_FOUND)
		{
			CRESORDSTS.HIST_SEQ = 0;
		}
    }

	CRESORDSTS.HIST_SEQ = CRESORDSTS.HIST_SEQ + 1;	

	if(memcmp(CRESORDSTS.ORDER_ID, TRS.get_string(in_node, "ORDER_ID"), strlen(TRS.get_string(in_node, "ORDER_ID"))) != 0)
	{
		TRS.copy(CRESORDSTS.FACTORY, sizeof(CRESORDSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CRESORDSTS.RES_ID, sizeof(CRESORDSTS.RES_ID), in_node, "RES_ID");
		TRS.copy(CRESORDSTS.LINE_ID, sizeof(CRESORDSTS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CRESORDSTS.ORDER_ID, sizeof(CRESORDSTS.ORDER_ID), in_node, "ORDER_ID");
		TRS.copy(CRESORDSTS.BOM_ID, sizeof(CRESORDSTS.BOM_ID), in_node, "BOM_ID");
		memcpy(CRESORDSTS.ORDER_TIME, s_sys_time, sizeof(CRESORDSTS.ORDER_TIME)); 
		memcpy(CRESORDSTS.CREATE_TIME, s_sys_time, sizeof(CRESORDSTS.CREATE_TIME)); 
		TRS.copy(CRESORDSTS.CREATE_USER_ID, sizeof(CRESORDSTS.CREATE_USER_ID), in_node, IN_USERID);

		CDB_update_cresordsts(1,&CRESORDSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_insert_cresordsts(&CRESORDSTS);
			}
		}

		CDB_init_cresordhis(&CRESORDHIS);
		memcpy(CRESORDHIS.FACTORY, CRESORDSTS.FACTORY, sizeof(CRESORDSTS));

		CDB_insert_cresordhis(&CRESORDHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//do not
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Validate_Production_Order_Validation()
        - Main sub function of "EAPMES_VALIDATE_PRODUCTION_ORDER" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Production_Order_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

