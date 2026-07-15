/*******************************************************************************

    System      : MESplus
    Module      : Move HalfCell Cart
    File Name   : CWIP_move_halfcell_cart.c
    Description : SOI -> MES

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.22  SW.HWANG
					  JUHYEON.JUING  MODIFY
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"


/*******************************************************************************
    CWIP_Move_HalfCell_Cart()
        - SOI->MES Move HalfCell Cart
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Move_HalfCell_Cart(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_MOVE_HALFCELL_CART(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Move_HalfCell_Cart", out_node);

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
    CWIP_MOVE_HALFCELL_CART()
        - SOI->MES Move HalfCell Cart
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_MOVE_HALFCELL_CART(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
	//struct MWIPCRRLOT_TAG MWIPCRRLOT_C;
	char s_sys_time[14];
	int i_open_step = 101;

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CWIP_TRAN_MOVE_PACKING_HALFCELL");
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

	if(TRS.get_procstep(in_node) == '1') //CART단위 MOVE
	{
		// OPEN
		DBC_init_mwiplotsts(&MWIPLOTSTS);

		memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPLOTSTS.OPER, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		memcpy(MWIPLOTSTS.LOT_GROUP_ID_2, TRS.get_string(in_node,"LACK_ID"), sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
		//MWIPLOTSTS.LOT_DEL_FLAG = ' ';

		DBC_open_mwiplotsts(i_open_step, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// FETCH
		while(1)
		{
			DBC_fetch_mwiplotsts(i_open_step, &MWIPLOTSTS);
			if(DB_error_code == DB_NOT_FOUND)
			{
				DBC_close_mwiplotsts(i_open_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				DBC_close_mwiplotsts(i_open_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			tran_in_node = TRS.create_node("MOVE_LOT_IN");
			tran_out_node = TRS.create_node("CMN_OUT");

			// IN_NODE FOR WIP_MOVE_LOT
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.set_char(tran_in_node, "PROCSTEP", '1');
			TRS.set_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.set_string(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "LINE_ID"), strlen(TRS.get_string(in_node, "LINE_ID")));
			TRS.set_string(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "ORDER_ID"), strlen(TRS.get_string(in_node, "ORDER_ID")));
			//TRS.set_string(tran_in_node, "TRAN_CMF_3", TRS.get_string(in_node, "ORDER_EFFICIENCY"), strlen(TRS.get_string(in_node, "ORDER_EFFICIENCY")));
			//TRS.set_string(tran_in_node, "TRAN_CMF_4", TRS.get_string(in_node, "ORDER_GRADE"), strlen(TRS.get_string(in_node, "ORDER_GRADE")));

			if(WIP_MOVE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE){
				DBC_close_mwiplotsts(i_open_step);
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}

			//Cleaving Half Cell Confirm ERP Interface 수행
			TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '3'); 
			TRS.set_nstring(tran_in_node, "MAIN_ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
			if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
			{
				DBC_close_mwiplotsts(i_open_step);
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);

		}
	}
	else if(TRS.get_procstep(in_node) == '2') //LOT단위 MOVE
	{
		tran_in_node = TRS.create_node("MOVE_LOT_IN");
		tran_out_node = TRS.create_node("CMN_OUT");

		// IN_NODE FOR WIP_MOVE_LOT
		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.set_char(tran_in_node, "PROCSTEP", '1');
		TRS.set_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
		TRS.set_nstring(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "LINE_ID"));
		TRS.set_nstring(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "ORDER_ID"));

		if(WIP_MOVE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE){
			
			// 20210810 MES Application Memory leak 점검 및 수정
			// 불필요 부분 주석처리
			//DBC_close_mwiplotsts(i_open_step);

			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		//Cleaving Half Cell Confirm ERP Interface 수행
		TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '3'); 
		TRS.set_nstring(tran_in_node, "MAIN_ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
		TRS.set_char(tran_in_node, "CLEAVING_END_FLAG", TRS.get_char(in_node, "CLEAVING_END_FLAG"));
		TRS.set_nstring(tran_in_node, "MAGAZINE_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
		if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
		{
			// 20210810 MES Application Memory leak 점검 및 수정
			// 불필요 부분 주석처리
			//DBC_close_mwiplotsts(i_open_step);

			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}