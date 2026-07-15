/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_rework_list.c
    Description : View Rework List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Rework_List()
            + View rework definition List

                + 1 : View lot_extention definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-05-19             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Rework_List()
        - View lot_extention definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Rework_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_REWORK_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_REWORK_LIST", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CWIP_VIEW_REWORK_LIST()
        - Main sub function of "CWIP_View_Rework_List" function
        - View lot_extention definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_REWORK_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct CWIPRWKDAT_TAG CWIPRWKDAT;
	//struct CEDCLOTFQC_TAG CEDCLOTFQC;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct CWIPRWKDAT_TAG CWIPRWKDAT;
    TRSNode *list_item;

    int i_case;

	double d_prod_qty;
	double d_in_qty;
	double d_rate;

	char   s_prod_order_no[40];

    LOG_head("CWIP_VIEW_REWORK_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "MODULE_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

	//TRS.set_string(in_node, "MODULE_ID", "903322522468300552", strlen("903322522468300552"));

    /* MODULE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "MODULE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "MODULE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// PROD ORDER ID 조회
	CDB_init_cwiprwkdat(&CWIPRWKDAT);
	TRS.copy(CWIPRWKDAT.FACTORY, sizeof(CWIPRWKDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "MODULE_ID");
	
	CDB_select_cwiprwkdat(3,&CWIPRWKDAT);
	if(DB_error_code != DB_SUCCESS) 
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0613");				//모듈ID의 재작업 정보가 존재하지 않습니다.
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.e_type = MP_LOG_E_SYSTEM;
		}

		TRS.add_fieldmsg(out_node, "CWIPRWKDAT SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	memset(s_prod_order_no, ' ', sizeof(s_prod_order_no));
	memcpy(s_prod_order_no, CWIPRWKDAT.PROD_ORDER_NO, sizeof(s_prod_order_no));
	

	//CDB_init_cwiprwkdat(&CWIPRWKDAT);
	TRS.copy(CWIPRWKDAT.FACTORY, sizeof(CWIPRWKDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(CWIPRWKDAT.PROD_ORDER_NO, s_prod_order_no, sizeof(s_prod_order_no));
    	
	//ord qty
	d_prod_qty = CDB_select_cwiprwkdat_scalar(4,&CWIPRWKDAT);
	    
	// in qty
	d_in_qty = CDB_select_cwiprwkdat_scalar(5,&CWIPRWKDAT);

	d_rate =0;
	if(d_prod_qty > 0) 
	{
		d_rate = (d_in_qty / d_prod_qty) * 100;
	}
	
	//TRS.set_string(out_node, "PROD_ORDER_NO", s_prod_order_no, sizeof(s_prod_order_no));
	TRS.set_string(out_node, "PROD_ORDER_NO", CWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPRWKDAT.PROD_ORDER_NO));  // Module Id 로 변경
	TRS.set_double(out_node, "ORD_QTY", d_prod_qty);
	TRS.set_double(out_node, "IN_QTY", d_in_qty);
	TRS.set_double(out_node, "RATE", d_rate);
	
    i_case = 4;

    //CDB_init_cwiprwkdat(&CWIPRWKDAT);
	//TRS.copy(CWIPRWKDAT.FACTORY, sizeof(CWIPRWKDAT.FACTORY), in_node, IN_FACTORY);
	//memcpy(CWIPRWKDAT.MODULE_ID, s_prod_order_no, sizeof(s_prod_order_no));		// 04.02 Module 조회 변경
    //memcpy(CWIPRWKDAT.PROD_ORDER_NO, s_prod_order_no, sizeof(s_prod_order_no));  
    CDB_open_cwiprwkdat(i_case, &CWIPRWKDAT);
    if(DB_error_code != DB_SUCCESS)
    {
		 CDB_close_cwiprwkdat(i_case);
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPRWKDAT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRWKDAT.FACTORY), CWIPRWKDAT.FACTORY);
		TRS.add_fieldmsg(out_node, "PROD_ORDER_NO", MP_STR, sizeof(CWIPRWKDAT.PROD_ORDER_NO), CWIPRWKDAT.PROD_ORDER_NO);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cwiprwkdat(i_case, &CWIPRWKDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiprwkdat(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPRWKDAT FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRWKDAT.FACTORY), CWIPRWKDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "PROD_ORDER_NO", MP_STR, sizeof(CWIPRWKDAT.PROD_ORDER_NO), CWIPRWKDAT.PROD_ORDER_NO);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwiprwkdat(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		CDB_init_mwipeltsts(&MWIPELTSTS);
		memcpy(MWIPELTSTS.LOT_ID, CWIPRWKDAT.MODULE_ID, sizeof(MWIPELTSTS.LOT_ID));
		CDB_select_mwipeltsts(1, &MWIPELTSTS); 

        list_item = TRS.add_node(out_node, "REWORK_LIST");
        //TRS.add_string(list_item, "FACTORY", CWIPRWKDAT.FACTORY, sizeof(CWIPRWKDAT.FACTORY));
        TRS.add_string(list_item, "MODULE_ID", CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID));
		TRS.add_string(list_item, "PROD_NO", CWIPRWKDAT.MAT_ID, sizeof(CWIPRWKDAT.MAT_ID));
		TRS.add_string(list_item, "CMF_1", MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE)); // GRADE
		
		TRS.add_string(list_item, "CMF_2", MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER)); // POWER

    }
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

