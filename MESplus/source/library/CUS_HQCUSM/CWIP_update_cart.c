/*******************************************************************************

    System      : MESplus
    Module      : Cleaving Operation Start Lot
    File Name   : CWIP_update_cart.c
    Description : Cleaving OPERATION start ( START / DETACH CARRier )
				  
    MES Version : 5.0

    Function List
        - START :  CELL BOX (FULLCELL MAGAZINE ) START + DETACH CAARRIER: EQUIPMENT 
		
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.03.07  YS KIM  CREATE
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <RASCore_common.h>

int CWIP_UPDATE_CART(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_update_cart_lot()
        - Tabber End Lot Service
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Cart(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_CART(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_update_cart_lot", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}


/*******************************************************************************
    CWIP_UPDATE_CART()
        - TABBER OPERATION END LOT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_CART(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct MRASCRRDEF_TAG MRASCRRDEF;
	struct MWIPCRRLOT_TAG MWIPCRRLOT;
	struct CWIPCELPAK_TAG CWIPCELPAK_o;
	struct CWIPCELMGZ_TAG CWIPCELMGZ;  // 자재 추적성

	char s_sys_time[14];

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;
	
	TRSNode* tran_in_node_1;
	TRSNode* tran_out_node_1;
	
	TRSNode* tran_in_node_2;
	TRSNode* tran_out_node_2;

    TRSNode* tran_in_node_3;
	TRSNode* tran_out_node_3;

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_CART");
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

	if(TRS.get_procstep(in_node) == '1')
	{
		// Clear
		if (COM_isnullspace(TRS.get_string(in_node, "LACK_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "WIP-0600");
			TRS.set_fieldmsg(out_node, "LINE NUMBER WRONG", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
		
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/* Validate the Carrier ID */
		DBC_init_mrascrrdef(&MRASCRRDEF);
		TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), in_node, "LACK_ID");
		DBC_select_mrascrrdef(1, &MRASCRRDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "RAS-0057");
				TRS.add_fieldmsg(out_node, "MRASCRRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MRASCRRDEF.CRR_ID), MRASCRRDEF.CRR_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "MRASCRRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MRASCRRDEF.CRR_ID), MRASCRRDEF.CRR_ID);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		//CART 조회
		CDB_init_cwipcelpak(&CWIPCELPAK);
		TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "LACK_ID");
		CWIPCELPAK.PACK_TYPE = TRS.get_char(in_node, "PACK_TYPE");

		// SELECT CWIPCELPAK
		CDB_open_cwipcelpak(104, &CWIPCELPAK);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0579");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);				
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		while(1)
		{
			CDB_fetch_cwipcelpak(104, &CWIPCELPAK);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwipcelpak(104);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				//TRS.add_fieldmsg(out_node, "CWIPORDBOM FETCH", MP_NVST);
				// 20210810 MES Application Memory leak 점검 및 수정
				// log edit
				TRS.add_fieldmsg(out_node, "CWIPCELPAK FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipcelpak(104);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			CDB_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0006");
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipcelpak(104);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipcelpak(104);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			CWIPCELPAK.STATUS_FLAG = 'C';
			//memcpy(CWIPCELPAK.LACK_ID, MWIPLOTSTS.LOT_GROUP_ID_1, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
			memcpy(CWIPCELPAK.CMF_2, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPCELPAK.BATCHNO	, sizeof(CWIPCELPAK.BATCHNO), in_node, "USER_ID");
			/* BACK TIME */
			if (memcmp(s_sys_time, TRS.get_string(in_node, "CLIENT_TIME"), 14) > 0)
			{
				//CLIENT TIME 이 시스템타임보다 빠른경우가 있음..
				if (memcmp(MWIPLOTSTS.LAST_TRAN_TIME, TRS.get_string(in_node, "CLIENT_TIME"), 14) <= 0) 
				{
					memset(CWIPCELPAK.CMF_2, ' ', sizeof(CWIPCELPAK.CMF_2));
					TRS.copy(CWIPCELPAK.CMF_2, sizeof(CWIPCELPAK.CMF_2), in_node, "CLIENT_TIME");
				}
			}

			CDB_init_cwipcelpak(&CWIPCELPAK_o); 
			memcpy(CWIPCELPAK_o.FACTORY, CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK_o.FACTORY));
			memcpy(CWIPCELPAK_o.PACK_ID, CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK_o.PACK_ID));
			memcpy(CWIPCELPAK_o.CELL_BOX_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK_o.CELL_BOX_ID));
			CDB_select_cwipcelpak_for_update(1, &CWIPCELPAK_o);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPCELPAK SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY); 
				TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELPAK.PACK_ID), CWIPCELPAK.PACK_ID); 
				TRS.add_fieldmsg(out_node, "CELL_BOX_ID", MP_STR, sizeof(CWIPCELPAK.CELL_BOX_ID), CWIPCELPAK.CELL_BOX_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipcelpak(104);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 

			CDB_update_cwipcelpak(1, &CWIPCELPAK); // C로 변경
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}

			//자재 추적성(2024.02.23) Start
			CDB_init_cwipcelmgz(&CWIPCELMGZ);
			memcpy(CWIPCELMGZ.FACTORY, CWIPCELPAK.FACTORY, sizeof(CWIPCELMGZ.FACTORY));
			memcpy(CWIPCELMGZ.CELL_BOX_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELMGZ.CELL_BOX_ID));
			memcpy(CWIPCELMGZ.PACK_ID, CWIPCELPAK.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID));
			CDB_select_cwipcelmgz(4, &CWIPCELMGZ);
			if(DB_error_code == DB_SUCCESS)
			{
				memcpy(CWIPCELMGZ.CMF_2, CWIPCELPAK.CMF_2, sizeof(CWIPCELPAK.CMF_2));
				CWIPCELPAK.CMF_1[0]= CWIPCELPAK.STATUS_FLAG;

				CDB_update_cwipcelmgz(1, &CWIPCELMGZ);
			}
			//자재 추적성(2024.02.23) End

			// LOTDML GROUP_ID_1 ALL CLEAR (FUCLL CELL CART ID)
			// 해당 LOT GROUP ID 를 가지고 있는 전체 FULL CART.CELL CLEAR
			// CART DOCK IN / OUT 이 잘되면 이부분 수정필요..
			// 현재는 DOCK IN / OUT 이 없어 너무 꼬임.. 처음 CART ID 가 있는 놈이 올라오면 해당 cart 를  dock in 으로 보고 cLEAR함
			memset(MWIPLOTSTS.LOT_GROUP_ID_1, ' ', sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
			CDB_update_mwiplotsts(2, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
            

		}

		
	}
	if(TRS.get_procstep(in_node) == '2')
	{
		//Cancel
		
		CDB_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "CELL_BOX_ID");
		CDB_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0006");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		if(MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ > 2)
		{
			strcpy(s_msg_code, "WIP-0581");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		

		//DETACH
		DBC_init_mwipcrrlot(&MWIPCRRLOT);
		memcpy(MWIPCRRLOT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(MWIPCRRLOT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		memcpy(MWIPCRRLOT.CRR_ID, MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));


        tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");
		//CRRID 가 있을경우 CARRIER DETACH
		TRS.init_node(tran_in_node);
		TRS.init_node(tran_out_node);

		if ( DBC_select_mwipcrrlot_scalar(1, &MWIPCRRLOT) > 0)
		{
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
		}
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		//CELLPACK DELETE
		CDB_init_cwipcelpak(&CWIPCELPAK);
		TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID), in_node, "CELL_BOX_ID");
		CWIPCELPAK.PACK_TYPE = TRS.get_char(in_node, "PACK_TYPE");

		CDB_select_cwipcelpak(4, &CWIPCELPAK); 
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0578"); 
				TRS.add_fieldmsg(out_node, "CWIPCELPAK SELECT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY); 
				TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELPAK.PACK_ID), CWIPCELPAK.PACK_ID); 
				TRS.add_fieldmsg(out_node, "CELL_BOX_ID", MP_STR, sizeof(CWIPCELPAK.CELL_BOX_ID), CWIPCELPAK.CELL_BOX_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			
		}
		CDB_delete_cwipcelpak(1, &CWIPCELPAK);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "DDD-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPCELPAK DELETE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY); 
			TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELPAK.PACK_ID), CWIPCELPAK.PACK_ID); 
			TRS.add_fieldmsg(out_node, "CELL_BOX_ID", MP_STR, sizeof(CWIPCELPAK.CELL_BOX_ID), CWIPCELPAK.CELL_BOX_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}

		//자재 추적성(2024.02.23) Start
		CDB_init_cwipcelmgz(&CWIPCELMGZ);
		TRS.copy(CWIPCELMGZ.FACTORY, sizeof(CWIPCELMGZ.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPCELMGZ.CELL_BOX_ID, sizeof(CWIPCELMGZ.CELL_BOX_ID), in_node, "CELL_BOX_ID");
		CWIPCELMGZ.PACK_TYPE = TRS.get_char(in_node, "PACK_TYPE");

		CDB_select_cwipcelmgz(5, &CWIPCELMGZ);
		if (DB_error_code == DB_SUCCESS)
		{
				CDB_delete_cwipcelmgz(1, &CWIPCELMGZ);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPCELMGZ DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELMGZ.FACTORY), CWIPCELMGZ.FACTORY);
					TRS.add_fieldmsg(out_node, "CELL_BOX_ID", MP_STR, sizeof(CWIPCELMGZ.CELL_BOX_ID), CWIPCELMGZ.CELL_BOX_ID);
					TRS.add_fieldmsg(out_node, "BOX_SEQ", MP_INT, CWIPCELMGZ.BOX_SEQ);
					TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELMGZ.PACK_ID), CWIPCELMGZ.PACK_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
		}
		//자재 추적성(2024.02.23) end

		tran_in_node_1 = TRS.create_node("TRAN_LOT_IN");
		tran_out_node_1 = TRS.create_node("TRAN_LOT_OUT");

		TRS.init_node(tran_in_node_1);
		TRS.init_node(tran_out_node_1);
			
		CCOM_copy_in_node(in_node, tran_in_node_1);
		TRS.add_char(tran_in_node_1, "PROCSTEP", '1');
        TRS.set_string(tran_in_node_1, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
        TRS.set_int(tran_in_node_1, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
		
		if(WIP_DELETE_LOT_HISTORY(s_msg_code,tran_in_node_1, tran_out_node_1) == MP_FALSE)
        {
			TRS.clone(out_node, tran_out_node_1);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node_1);
			TRS.free_node(tran_out_node_1);

			return MP_FALSE;
		}
		TRS.free_node(tran_in_node_1);
		TRS.free_node(tran_out_node_1);

		//재조회
		CDB_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "CELL_BOX_ID");
		CDB_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0006");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		tran_in_node_2 = TRS.create_node("TRAN_LOT_IN");
		tran_out_node_2 = TRS.create_node("TRAN_LOT_OUT");

		TRS.init_node(tran_in_node_2);
		TRS.init_node(tran_out_node_2);
			
		CCOM_copy_in_node(in_node, tran_in_node_2);
		TRS.add_char(tran_in_node_2, "PROCSTEP", '1');
        TRS.set_string(tran_in_node_2, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
        TRS.set_int(tran_in_node_2, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
		
		if(WIP_DELETE_LOT_HISTORY(s_msg_code,tran_in_node_2, tran_out_node_2) == MP_FALSE)
        {
			TRS.clone(out_node, tran_out_node_2);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node_2);
			TRS.free_node(tran_out_node_2);

			return MP_FALSE;
		}

		/* FREE NODE */
		TRS.free_node(tran_in_node_2);
		TRS.free_node(tran_out_node_2);

        //Erp Upload
        tran_in_node_3 = TRS.create_node("TRAN_LOT_IN");
		tran_out_node_3 = TRS.create_node("TRAN_LOT_OUT");
        
        TRS.init_node(tran_in_node_3);
		TRS.init_node(tran_out_node_3);

        CCOM_copy_in_node(in_node, tran_in_node_3);
		TRS.add_char(tran_in_node_3, "PROCSTEP", '1');
		TRS.add_string(tran_in_node_3, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
        TRS.add_string(tran_in_node_3, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
        TRS.add_string(tran_in_node_3, "ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
        TRS.add_string(tran_in_node_3, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
        TRS.add_int (tran_in_node_3, "QTY_1", MWIPLOTSTS.QTY_1, sizeof(MWIPLOTSTS.QTY_1));

        TRS.add_boolean (tran_in_node_3, "CANCEL", MP_TRUE );
        TRS.set_char(tran_in_node_3, "INF_UPLOAD_TYPE_FLAG", '1'); 
        if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node_3, tran_out_node_3 ) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node_3);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node_3);
			TRS.free_node(tran_out_node_3);
			return MP_FALSE;
		}
		
		TRS.free_node(tran_in_node_3);
		TRS.free_node(tran_out_node_3);
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}