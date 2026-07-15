/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_assign_magazine_to_cart.c
    Description : EAPMES Assign Magazine To Cart Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Assign_Magazine_To_Cart()
            + Setup service interface function
        - EAPMES_ASSIGN_MAGAZINE_TO_CART()
            + Main sub function of EAPMES_Assign_Magazine_To_Cart function
            + Setup service main business function
        - EAPMES_Assign_Magazine_To_Cart_Validation()
            + Main sub function of EAPMES_ASSIGN_MAGAZINE_TO_CART function
    Detail Description
        - EAPMES_ASSIGN_MAGAZINE_TO_CART()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created
	2     2024.02.23  BYUNGCHAE.KANG 자재추적성 반영
    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Assign_Magazine_To_Cart_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Assign_Magazine_To_Cart()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Assign_Magazine_To_Cart(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    
	 /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

	//2020-01-14 메세지가 설비까지 내려가는 timeout 문제로 먼저 보내고 처리한다.

	
    /* 특정 에러처리를 무시할경우 사용 ERROR  */
	// VALIDATION 하라고 셋팅된 에러만 에러처리함.
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
	memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
	memcpy(MGCMLAGDAT.KEY_2, "VALIDATION", strlen("VALIDATION"));
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Assign_Magazine_To_Cart", strlen("EAPMES_Assign_Magazine_To_Cart"));
	memcpy(MGCMLAGDAT.KEY_4, s_msg_code, 9);
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'Y'))
	{
		//VALIDATION SKIP 이 아닌경우 에러발생
		//MGCMLAGDAT TABLE (@FACTORY_OPTION)에서 DATA_1 = 'Y' 이면 에러발생
	}
	else
	{
		// MGCMLAGDAT.DATA_1[0] == 'N' 인 경우 무조건 성공으로 내려감
		//VALIDATION SKIP 일경우 무조건 성공 
        COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	}

       /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
	TRS.set_nstring(out_node, "VMAGAZINE_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));
    TRS.set_nstring(out_node, "MAGAZINE_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));

	/* MAX COUNT , 현재 COUNT 설비 쪽으로 다시 내려줌.*/
	//"MAX_LOT_COUNT"
	//"CURRENT_LOT_COUNT"
	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Assign_Magazine_To_Cart", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}

	// Return if VMAGAZINE is a duplicate
	if(DEDUPLICATION_BY_MAGAZINE(s_msg_code, in_node, out_node) == MP_TRUE)
	{
		TRS.free_node(out_node);
		DB_rollback();
		return MP_TRUE;
	}
	
	i_ret = EAPMES_ASSIGN_MAGAZINE_TO_CART(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_ASSIGN_MAGAZINE_TO_CART", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);
    //CEIS_Save_Message_Log_For_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_ASSIGN_MAGAZINE_TO_CART()
        - Main sub function of "EAPMES_Assign_Magazine_To_Cart" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_ASSIGN_MAGAZINE_TO_CART(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
	struct CWIPCELPAK_TAG CWIPCELPAK;

	//struct MRASCRRDEF_TAG MRASCRRDEF;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPCRRLOT_TAG MWIPCRRLOT;
	struct CWIPCELMGZ_TAG CWIPCELMGZ;

	TRSNode *list_item;

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;
    
	char   s_sys_time[14];
    double numMagazine = 0;
	char   c_cart_flag = 'N';
	int	   i_step;

    LOG_head("EAPMES_ASSIGN_MAGAZINE_TO_CART");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
	
	// SYSTEM TIME SETTING
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
	
	
	//0. 설비 ID GET
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
    
	/* CWIPCELPAK COUNT */

	//TABBER 에서는 UNLOAD EVENT 없음
	//CLEAVING 의 배출구 (HCELL UNLOAD 부분임...) HCELL 구성해야함.
		
	//대차ID : MRASRESDEF.RES_STS_2
	//MAGAZINE ID : 설비에서 올려줌
	//수량 : 설비에서 올려줌.

	//HALFCELL_PACK_LIST
	//LACK_ID : CART_ID
	//PACK_ID : 매거진 ID

	//TRS.add_item(in_node, "

	/* VMAGAZINE ID 를 START 시 TRAN_CMF_3  에 사용)*/
	if (COM_isnullspace(TRS.get_string(in_node, "VMAGAZINE_ID")) == MP_FALSE)
		TRS.set_nstring(in_node, "TRAN_CMF_3", TRS.get_string(in_node, "VMAGAZINE_ID"));
	
		
	list_item = TRS.add_node(in_node, "HALFCELL_PACK_LIST");

	if (COM_isspace(MRASRESDEF.RES_STS_2, sizeof(MRASRESDEF.RES_STS_2)) == MP_TRUE)
	{
		TRS.add_nstring(list_item, "LACK_ID", TRS.get_string(in_node, "MAGAZINE_ID")); //LACK 이없을시 MAGAZINE ID 로 진행함.
	}
	else
	{
		TRS.add_string(list_item, "LACK_ID", MRASRESDEF.RES_STS_2, sizeof(MRASRESDEF.RES_STS_2));
		c_cart_flag = 'Y';
	}
		
	TRS.add_nstring(list_item, "PACK_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
	TRS.add_int(list_item, "MAGAZINE_QTY", TRS.get_int(in_node, "MAGAZINE_QTY"));

	if (COM_isnullspace(TRS.get_string(in_node, "MAGAZINE_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "RAS-0057");
        TRS.add_fieldmsg(out_node, "MAGAZINE ID CHECK", MP_NVST);
       
		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	if ((strlen(TRS.get_string(in_node, "MAGAZINE_ID")) != 14) && 
			(strlen(TRS.get_string(in_node, "MAGAZINE_ID")) != 13)) 
	{
		strcpy(s_msg_code, "RAS-0057");
        TRS.add_fieldmsg(out_node, "MAGAZINE ID SIZE CHECK", MP_NVST);
       
		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

    /* Check whether magazine ID was already used or not */
    numMagazine = 0;

	CDB_init_cwipcelpak(&CWIPCELPAK);
    TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	if (COM_isspace(MRASRESDEF.RES_STS_2, sizeof(MRASRESDEF.RES_STS_2)) == MP_TRUE)
	{
        TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "MAGAZINE_ID");	
	}
	else
	{
		memcpy(CWIPCELPAK.LACK_ID, MRASRESDEF.RES_STS_2, sizeof(MRASRESDEF.RES_STS_2));
		c_cart_flag = 'Y';
	}
    TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), in_node, "MAGAZINE_ID");
    CWIPCELPAK.PACK_TYPE = 'H';
    CWIPCELPAK.STATUS_FLAG = 'I';

    numMagazine = CDB_select_cwipcelpak_scalar(5, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
        /*
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
		TRS.add_dberrmsg(out_node,DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
        */
    }

    if ((numMagazine >= 1) && (c_cart_flag == 'Y'))
    {
		/*	ISSUE No.	: ISSUE-07-046  
			요청자		: 이성배 과장
			내용		: Cleaving  클레빙 WIP - 오류메세지 처리 
					      / 라인모니터링을 통해 메시지 확인하여 처리, 
						  테버에서는 매거진 (validation,start) 2가지 보내는데 NG시에 local 모드로 메시지 전송하지 않을수 있음. 
						  클레빙에 투입되는 매거진은 무조건 클리어하고 처리할것 */
		i_step = 10;
		CDB_init_cwipcelpak(&CWIPCELPAK);
		TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);
		memcpy(CWIPCELPAK.LACK_ID, MRASRESDEF.RES_STS_2, sizeof(MRASRESDEF.RES_STS_2));
		TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), in_node, "MAGAZINE_ID");
		CWIPCELPAK.PACK_TYPE = 'H';
		CWIPCELPAK.STATUS_FLAG = 'I';
		CDB_open_cwipcelpak(i_step, &CWIPCELPAK);
		if(DB_error_code != DB_SUCCESS)
		{
			/*
			
			*/
		}

		while(1)
		{
			CDB_fetch_cwipcelpak(i_step, &CWIPCELPAK);
			if(DB_error_code != DB_SUCCESS)
			{
				CDB_close_cwipcelpak(i_step);
				break;
			}		

			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, CWIPCELPAK.CMF_1, sizeof(MWIPLOTSTS.LOT_ID));
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				/*
			
				*/
			}

			// Log
			LOG_head("NOT DETACH LOT - CARRIER (Before WIP-0584)");
			LOG_add("LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			LOG_add("CRR_ID", MP_STR, sizeof(MWIPLOTSTS.CRR_ID), MWIPLOTSTS.CRR_ID);
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			
			if(COM_isnullspace(MWIPLOTSTS.CRR_ID) == MP_FALSE)
			{
				/***************************************************/
				// DETACH 
				/***************************************************/
				DBC_init_mwipcrrlot(&MWIPCRRLOT);
				memcpy(MWIPCRRLOT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				memcpy(MWIPCRRLOT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				memcpy(MWIPCRRLOT.CRR_ID, MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
				if (DBC_select_mwipcrrlot_scalar(1, &MWIPCRRLOT) > 0)
				{
					//CRRID 가 있을경우 CARRIER DETACH
					tran_in_node = TRS.create_node("TRAN_LOT_IN");
					tran_out_node = TRS.create_node("TRAN_LOT_OUT");
			
					CCOM_copy_in_node(in_node, tran_in_node);
					TRS.add_char(tran_in_node, "PROCSTEP", '1');
					TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(tran_in_node, "CRR_ID", MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
					TRS.add_double(tran_in_node, "QTY_1", MWIPLOTSTS.QTY_1);

					//DETACH CARRIER LOT 진행
					if(RAS_DETACH_LOT_CARRIER(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
					{
						/*TRS.clone(out_node, tran_out_node);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						return MP_FALSE;*/
					}
			
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
				}
			}
				
			//CDB_init_cwipcelpak(&CWIPCELPAK);
			//memcpy(CWIPCELPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPCELPAK.FACTORY));
			//memcpy(CWIPCELPAK.LACK_ID, MWIPLOTSTS.LOT_GROUP_ID_2, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
			//CWIPCELPAK.PACK_TYPE = 'H';
			//CWIPCELPAK.STATUS_FLAG = 'I';
			memcpy(CWIPCELPAK.CMF_2, s_sys_time, sizeof(s_sys_time));

			// BACK TIME 
			if (memcmp(s_sys_time, TRS.get_string(in_node, "CLIENT_TIME"), 14) > 0)
			{
				//CLIENT TIME 이 시스템타임보다 빠른경우가 있음..
				if (memcmp(MWIPLOTSTS.LAST_TRAN_TIME, TRS.get_string(in_node, "CLIENT_TIME"), 14) <= 0) 
				{
					memset(CWIPCELPAK.CMF_2, ' ', sizeof(CWIPCELPAK.CMF_2));
					TRS.copy(CWIPCELPAK.CMF_2, 14, in_node, "CLIENT_TIME");
				}
			}
		
			TRS.copy(CWIPCELPAK.CMF_4, sizeof(CWIPCELPAK.CMF_4), in_node, "RES_ID");
			CDB_update_cwipcelpak(4, &CWIPCELPAK); // C로 상태변경 , CMF_4 설비
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			//자재 추적성(2024.02.23) Start
			CDB_init_cwipcelmgz(&CWIPCELMGZ);
			memcpy(CWIPCELMGZ.FACTORY, CWIPCELPAK.FACTORY, sizeof(CWIPCELMGZ.FACTORY));
			CWIPCELMGZ.PACK_TYPE = CWIPCELPAK.PACK_TYPE;
			memcpy(CWIPCELMGZ.CMF_3, CWIPCELPAK.LACK_ID, sizeof(CWIPCELMGZ.CMF_3));
			CWIPCELMGZ.CMF_1[0] = CWIPCELPAK.STATUS_FLAG;                                                                                                                                                                          

			memcpy(CWIPCELMGZ.CMF_2, CWIPCELPAK.CMF_2, sizeof(CWIPCELPAK.CMF_2));
			TRS.copy(CWIPCELMGZ.CMF_4, sizeof(CWIPCELMGZ.CMF_4), in_node, "RES_ID");

			CDB_update_cwipcelmgz(6, &CWIPCELMGZ); // C로 상태변경 , CMF_4 설비
            if (DB_error_code != DB_SUCCESS)
            {
                //DO NOTHING
            }
			//자재 추적성(2024.02.23) End
		}
    }
	TRS.set_int(in_node, "MAGAZINE_O_QTY", TRS.get_int(in_node, "MAGAZINE_QTY")); //IS-21-10-017 Half Cell 실제 수량 저장 되도록
	if (TRS.get_int(in_node, "MAGAZINE_QTY") < 300)
		TRS.set_int(in_node, "MAGAZINE_QTY", 300);

	if (CWIP_PACKING_HALFCELL(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 


int DEDUPLICATION_BY_MAGAZINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MRASCRRDEF_TAG MRASCRRDEF;

	if (COM_isnullspace(TRS.get_string(in_node, "VMAGAZINE_ID")) == MP_FALSE)
	{
		//0. GET VMAGAZINE ID by MAGAZINE
		DBC_init_mrascrrdef(&MRASCRRDEF);
		TRS.copy(MRASCRRDEF.FACTORY, sizeof(MRASCRRDEF.FACTORY), in_node, "FACTORY");
		TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), in_node, "MAGAZINE_ID");
		DBC_select_mrascrrdef_for_update(1, &MRASCRRDEF);

		if(DB_error_code == DB_SUCCESS)
		{
			// check duplication
			
			//if(memcmp(MRASCRRDEF.CRR_CMF_2, TRS.get_string(in_node, "VMAGAZINE_ID"), strlen(TRS.get_string(in_node, "VMAGAZINE_ID"))) == 0)
			if(TRS.mem_cmp(in_node, "VMAGAZINE_ID", MRASCRRDEF.CRR_CMF_2, sizeof(MRASCRRDEF.CRR_CMF_2)) == 0)
			{
				return MP_TRUE;
			}
			else
			{
				// update
				TRS.copy(MRASCRRDEF.CRR_CMF_2, sizeof(MRASCRRDEF.CRR_CMF_2), in_node, "VMAGAZINE_ID");
				DBC_update_mrascrrdef(1, &MRASCRRDEF);
			}
		}
	}
	
	return MP_FALSE;
}

/*******************************************************************************
    EAPMES_Assign_Magazine_To_Cart_Validation()
        - Main sub function of "EAPMES_ASSIGN_MAGAZINE_TO_CART" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Assign_Magazine_To_Cart_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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
