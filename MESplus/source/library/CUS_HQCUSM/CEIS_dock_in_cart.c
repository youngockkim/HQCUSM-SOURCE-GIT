/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_dock_in_cart.c
    Description : EAPMES Dock In Cart Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Dock_In_Cart()
            + Setup service interface function
        - EAPMES_DOCK_IN_CART()
            + Main sub function of EAPMES_Dock_In_Cart function
            + Setup service main business function
        - EAPMES_Dock_In_Cart_Validation()
            + Main sub function of EAPMES_DOCK_IN_CART function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_DOCK_IN_CART()
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

int EAPMES_Dock_In_Cart_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Dock_In_Cart()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Dock_In_Cart(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_DOCK_IN_CART(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_DOCK_IN_CART", out_node);

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
    TRS.set_nstring(out_node, "CART_ID", TRS.get_string(in_node, "CART_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));
    TRS.set_nstring(out_node, "EQP_TYPE", TRS.get_string(in_node, "EQP_TYPE"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Dock_In_Cart", 
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
    EAPMES_DOCK_IN_CART()
        - Main sub function of "EAPMES_Dock_In_Cart" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_DOCK_IN_CART(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
	struct MRASCRRDEF_TAG MRASCRRDEF;

	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;

	TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

	int i_cartcnt = 0;

    char   s_sys_time[14];

    LOG_head("EAPMES_DOCK_IN_CART");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Dock_In_Cart_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "ULD") == 0)
	{
		TRS.set_nstring(out_node, "MAX_LOT_COUNT", "50");
		TRS.set_nstring(out_node, "CURRENT_LOT_COUNT", "0");
	}

    //0. 설비 ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef_for_update(1, &MRASRESDEF);
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

	//1. CART ID GET
	DBC_init_mrascrrdef(&MRASCRRDEF);
	TRS.copy(MRASCRRDEF.FACTORY, sizeof(MRASCRRDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), in_node, "CART_ID");
	DBC_select_mrascrrdef(1, &MRASCRRDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "RAS-0057");
        TRS.add_fieldmsg(out_node, "MRASCRRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCRRDEF.FACTORY), MRASCRRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MRASCRRDEF.CRR_ID), MRASCRRDEF.CRR_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//DOCK IN EVNET
	tran_in_node = TRS.create_node("TRAN_IN");
    tran_out_node = TRS.create_node("TRAN_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
    TRS.add_char(tran_in_node, "PROCSTEP", '1');
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "LD") == 0)
	{
		//LOAD 부 CART IN (STS_1 사용)
		TRS.add_nstring(tran_in_node, "EVENT_ID", HQCEL_M1_EVENT_LD_CART_IN);
		TRS.add_nstring(tran_in_node, "CHG_STS_1", TRS.get_string(in_node, "CART_ID"));
	}
	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "ULD") == 0)
	{
		//UNLOAD 부 CART IN (STS_2 사용)
		TRS.add_nstring(tran_in_node, "EVENT_ID", HQCEL_M1_EVENT_ULD_CART_IN);
		TRS.add_nstring(tran_in_node, "CHG_STS_2", TRS.get_string(in_node, "CART_ID"));

		//'
		TRS.set_nstring(out_node, "MAX_LOT_COUNT", "50");
		TRS.set_nstring(out_node, "CURRENT_LOT_COUNT", "0");
	}
	
	if(RAS_RESOURCE_EVENT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
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

	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "ULD") == 0)
	{
		//UNLOAD 부 CART IN 에서 카트 최대수량, 현재수량(0) 으로 무조건 보냄.
		TRS.set_nstring(out_node, "MAX_LOT_COUNT", "50");

		
		CDB_init_cwipcelpak(&CWIPCELPAK);
		memcpy(CWIPCELPAK.LACK_ID, MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID));
		i_cartcnt = CDB_select_cwipcelpak_scalar(4, &CWIPCELPAK); // 현재수량.


		TRS.set_nstring(out_node, "CURRENT_LOT_COUNT", "0");   //현재수량. 
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Dock_In_Cart_Validation()
        - Main sub function of "EAPMES_DOCK_IN_CART" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Dock_In_Cart_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

