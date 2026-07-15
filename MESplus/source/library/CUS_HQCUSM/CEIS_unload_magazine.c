/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_unload_magazine.c
    Description : EAPMES Unload Magazine Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Unload_Magazine()
            + Setup service interface function
        - EAPMES_UNLOAD_MAGAZINE()
            + Main sub function of EAPMES_Unload_Magazine function
            + Setup service main business function
        - EAPMES_Unload_Magazine_Validation()
            + Main sub function of EAPMES_UNLOAD_MAGAZINE function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_UNLOAD_MAGAZINE()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created
	2     2024.02.23  BYUNGCHAE.KANG 자재추적성 반영
    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Unload_Magazine_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Unload_Magazine()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Unload_Magazine(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_UNLOAD_MAGAZINE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_UNLOAD_MAGAZINE", out_node);

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
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "VMAGAZINE_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
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
		"MESEAP_Unload_Magazine", 
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

	/* Save magazine log */
	TRS.set_string(in_node, "ACTION", "UNLOAD", strlen("UNLOAD")); //200 Load, 201 Unload
	CEIS_Save_Load_Unload_Magazine(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_UNLOAD_MAGAZINE()
        - Main sub function of "EAPMES_Unload_Magazine" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_UNLOAD_MAGAZINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CWIPCELPAK_TAG CWIPCELPAK;

	struct MRASCRRDEF_TAG MRASCRRDEF;
	struct MWIPCRRLOT_TAG MWIPCRRLOT;

	struct CWIPCELMGZ_TAG CWIPCELMGZ; // 2024.02.03 자재추적성 반영
	struct CCLVMAGCHK_TAG   CCLVMAGCHK;
	char   s_sys_time[14];

	//TRSNode *list_item;
    //char   s_sys_time[14];

	
	


	TRSNode* tran_in_node;
	TRSNode* tran_out_node;
    
    LOG_head("EAPMES_UNLOAD_MAGAZINE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Unload_Magazine_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
				TRS.copy(CCLVMAGCHK.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
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
			}
		}
	}
	//25.10.24 - END

    if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "LD") == 0)
	{
		if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER)) == 0)
		{
			int i_tmpcnt = 1;
			//LOAD PORT 부분 CLEAVING
			//매거진 1개에 CELL BOX 가 2개 들어가는게 있으므로 해당 COUNT 만큼 나누어 저장함.
			CDB_init_cwipcelpak(&CWIPCELPAK);
			memcpy(CWIPCELPAK.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
			CWIPCELPAK.PACK_TYPE = 'F';
			TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), in_node, "MAGAZINE_ID");
			CWIPCELPAK.STATUS_FLAG = 'C';
			i_tmpcnt = (int)CDB_select_cwipcelpak_scalar(13, &CWIPCELPAK);

			if (i_tmpcnt < 1)
				i_tmpcnt = 1;

			//해당 매거진의 UNLOAD MAGAZINE 수량을 CWIPCELPAK TABLE 에 저장함. CWIPCELPAK.CMF_7 에 값을 저장함 VMAGAZINE : CMF_8
			CDB_init_cwipcelpak(&CWIPCELPAK);
			memcpy(CWIPCELPAK.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
			CWIPCELPAK.PACK_TYPE = 'F';
			TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), in_node, "MAGAZINE_ID");
			CWIPCELPAK.STATUS_FLAG = 'C';
			CDB_select_cwipcelpak(8, &CWIPCELPAK);
			if(DB_error_code == DB_SUCCESS)
			{
				if (TRS.get_int(in_node, "MAGAZINE_QTY") > 0)
					COM_itoa_left(CWIPCELPAK.CMF_7, (TRS.get_int(in_node, "MAGAZINE_QTY") / i_tmpcnt), sizeof(CWIPCELPAK.CMF_7));
				else
					COM_itoa_left(CWIPCELPAK.CMF_7, CWIPCELPAK.PACK_QTY, sizeof(CWIPCELPAK.CMF_7));

				COM_itoa_left(CWIPCELPAK.CMF_5, TRS.get_int(in_node, "MAGAZINE_QTY"), sizeof(CWIPCELPAK.CMF_5));
				TRS.copy(CWIPCELPAK.CMF_8, sizeof(CWIPCELPAK.CMF_8), in_node, "VMAGAZINE_ID"); //CLEAVING VMAGAZINE
				CDB_update_cwipcelpak(6, &CWIPCELPAK);
				if(DB_error_code == DB_SUCCESS)
				{
					//DO NOTHING
				}

				//자재 추적성(2024.02.23) Start
                CDB_init_cwipcelmgz(&CWIPCELMGZ);
                memcpy(CWIPCELMGZ.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
                CWIPCELMGZ.PACK_TYPE = 'F';
                TRS.copy(CWIPCELMGZ.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID), in_node, "MAGAZINE_ID");
				CWIPCELMGZ.CMF_1[0] = 'C';
                CDB_select_cwipcelmgz(2, &CWIPCELMGZ);
                if (DB_error_code == DB_SUCCESS)
                {
                    TRS.copy(CWIPCELMGZ.VMAGAZINE_ID, sizeof(CWIPCELMGZ.VMAGAZINE_ID), in_node, "VMAGAZINE_ID"); //CLEAVING VMAGAZINE
                    CDB_update_cwipcelmgz(3, &CWIPCELMGZ);
                    if (DB_error_code == DB_SUCCESS)
                    {
                        //DO NOTHING
                    }
                }
				//자재 추적성(2024.02.23) End
			}

			/***************************************************/
			// DETACH LOT - CARRIER
			/***************************************************/
			
			/*
			
			LD 클리빙에서 매거진 수량이 남아있으면 detach 20200115
			
			*/

			DBC_init_mrascrrdef(&MRASCRRDEF);
			TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), in_node, "MAGAZINE_ID");
			DBC_select_mrascrrdef(1, &MRASCRRDEF);
			if(DB_error_code == DB_SUCCESS 
				&& memcmp(MRASCRRDEF.CRR_GROUP, "US_F_M", strlen("US_F_M")) == 0
				&& MRASCRRDEF.QTY_1 > 0)
			{

				//MWIPCRRLOT 테이블을 조회해서 하나씩 DETACH

				DBC_init_mwipcrrlot(&MWIPCRRLOT);
				memcpy(MWIPCRRLOT.FACTORY, MRASCRRDEF.FACTORY, sizeof(MWIPCRRLOT.FACTORY));
				memcpy(MWIPCRRLOT.CRR_ID, MRASCRRDEF.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID));
				
				DBC_open_mwipcrrlot(101, &MWIPCRRLOT);
				if (DB_error_code != DB_SUCCESS)
				{
					LOG_head("CEIS_unload_magazine_RAS_DETACH_LOT_CARRIER1");
					COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
				}

				
				tran_in_node = TRS.create_node("TRAN_LOT_IN");
				tran_out_node = TRS.create_node("TRAN_LOT_OUT");

				while(1)
				{
					DBC_fetch_mwipcrrlot(101, &MWIPCRRLOT);
					if (DB_error_code == DB_NOT_FOUND)
					{
						DBC_close_mwipcrrlot(101);
						break;
					}
					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Error and log
					else if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MWIPCRRLOT FETCH", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCRRLOT.FACTORY), MWIPCRRLOT.FACTORY);
						TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						DBC_close_mwipcrrlot(101);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);

						return MP_FALSE;
					}

					// 정상처리시로 분류
					//else
					{	
						//CRRID 가 있을경우 CARRIER DETACH
						TRS.init_node(tran_in_node);
						TRS.init_node(tran_out_node);
			
						CCOM_copy_in_node(in_node, tran_in_node);
						TRS.add_char(tran_in_node, "PROCSTEP", '1');
						TRS.add_string(tran_in_node, "LOT_ID", MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID));
						TRS.add_string(tran_in_node, "CRR_ID", MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID));
						TRS.add_double(tran_in_node, "QTY_1", MWIPCRRLOT.QTY_1);
				
						//DETACH CARRIER LOT 진행
						if(RAS_DETACH_LOT_CARRIER(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
						{
							LOG_head("CEIS_unload_magazine_RAS_DETACH_LOT_CARRIER2");
							COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
						}

					}
				}

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);

			}

		}

		if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)) == 0)
		{
			//LOAD PORT 부분 TABBER
			//해당 매거진의 UNLOAD MAGAZINE 수량을 CWIPCELPAK TABLE 에 저장함. CWIPCELPAK.CMF_7 에 값을 저장함 VMAGAZINE : CMF_8
			CDB_init_cwipcelpak(&CWIPCELPAK);
			memcpy(CWIPCELPAK.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
			CWIPCELPAK.PACK_TYPE = 'H';
			TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), in_node, "MAGAZINE_ID");
			CWIPCELPAK.STATUS_FLAG = 'C';
			CDB_select_cwipcelpak(8, &CWIPCELPAK);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.copy(CWIPCELPAK.CMF_9, sizeof(CWIPCELPAK.CMF_9), in_node, "VMAGAZINE_ID"); //TABBER VMAGZINE
				CDB_update_cwipcelpak(6, &CWIPCELPAK);
				if(DB_error_code == DB_SUCCESS)
				{
					//DO NOTHING
				}

				//자재 추적성(2024.02.23) Start
                CDB_init_cwipcelmgz(&CWIPCELMGZ);
                memcpy(CWIPCELMGZ.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
                CWIPCELMGZ.PACK_TYPE = CWIPCELPAK.PACK_TYPE;
                TRS.copy(CWIPCELMGZ.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID), in_node, "MAGAZINE_ID");
				CWIPCELMGZ.CMF_1[0] = 'C';
                CDB_select_cwipcelmgz(2, &CWIPCELMGZ);
                if (DB_error_code == DB_SUCCESS)
                {
                    TRS.copy(CWIPCELMGZ.VMAGAZINE_ID, sizeof(CWIPCELMGZ.VMAGAZINE_ID), in_node, "VMAGAZINE_ID"); // TABBER VMAGAZINE
                    CDB_update_cwipcelmgz(3, &CWIPCELMGZ);
                    if (DB_error_code == DB_SUCCESS)
                    {
                        //DO NOTHING
                    }
                }
				//자재 추적성(2024.02.23) End
			}
		}
	}

	if (strcmp(TRS.get_string(in_node, "EQP_TYPE"), "ULD") == 0)
	{
		// HCELL UNLOAD 의 매거진 구성은 -> ASSIGN MAGAZINE TO CART 로 변경함
		// VMAGAZINE 과 UNLOAD 수량만 UPDATE 함.
		// TABBER 에서는 UNLOAD EVENT 없음
		if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER)) == 0)
		{
			//UNLOAD PORT 부분 CLEAVING
			//해당 매거진의 UNLOAD MAGAZINE 수량을 CWIPCELPAK TABLE 에 저장함. CWIPCELPAK.CMF_7 에 값을 저장함 VMAGAZINE : CMF_8
			CDB_init_cwipcelpak(&CWIPCELPAK);
			memcpy(CWIPCELPAK.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
			CWIPCELPAK.PACK_TYPE = 'H';
			TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), in_node, "MAGAZINE_ID");
			CWIPCELPAK.STATUS_FLAG = 'C';
			CDB_select_cwipcelpak(8, &CWIPCELPAK);
			if(DB_error_code == DB_SUCCESS)
			{
				if (TRS.get_int(in_node, "MAGAZINE_QTY") > 0)
					COM_itoa_left(CWIPCELPAK.CMF_7, TRS.get_int(in_node, "MAGAZINE_QTY"), sizeof(CWIPCELPAK.CMF_7));
				else
					COM_itoa_left(CWIPCELPAK.CMF_7, CWIPCELPAK.PACK_QTY, sizeof(CWIPCELPAK.CMF_7));

				COM_itoa_left(CWIPCELPAK.CMF_5, TRS.get_int(in_node, "MAGAZINE_QTY"), sizeof(CWIPCELPAK.CMF_5));	
				TRS.copy(CWIPCELPAK.CMF_8, sizeof(CWIPCELPAK.CMF_8), in_node, "VMAGAZINE_ID"); //CLEAVING VMAGAZINE
				CDB_update_cwipcelpak(6, &CWIPCELPAK);
				if(DB_error_code == DB_SUCCESS)
				{
					//DO NOTHING
				}

                // 자재 추적성(2024.02.03)
                //CDB_init_cwipcelmgz(&CWIPCELMGZ);
                //memcpy(CWIPCELMGZ.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
                //CWIPCELMGZ.PACK_TYPE = CWIPCELPAK.PACK_TYPE;
                //TRS.copy(CWIPCELMGZ.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID), in_node, "MAGAZINE_ID");
                //CDB_select_cwipcelmgz(2, &CWIPCELMGZ);
                //if (DB_error_code == DB_SUCCESS)
                //{
                //    TRS.copy(CWIPCELMGZ.CVMAGAZINE_ID, sizeof(CWIPCELMGZ.CVMAGAZINE_ID), in_node, "VMAGAZINE_ID"); //CLEAVING VMAGAZINE
                //    CDB_update_cwipcelmgz(4, &CWIPCELMGZ);
                //    if (DB_error_code == DB_SUCCESS)
                //    {
                //        //DO NOTHING
                //    }
                //}

			}
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Unload_Magazine_Validation()
        - Main sub function of "EAPMES_UNLOAD_MAGAZINE" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Unload_Magazine_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

