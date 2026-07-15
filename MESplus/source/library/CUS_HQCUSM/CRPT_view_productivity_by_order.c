/*******************************************************************************

    System      : MESplus
    Module      : VIEW_Productivity_By_Order_List
    File Name   : CRPT_view_productivity_by_order.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.15  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CRPT_VIEW_PRODUCTIVITY_BY_ORDER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);

/*******************************************************************************
    CRPT_View_Productivity_By_Order()
        - FQC Flash List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_View_Productivity_By_Order(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRPT_VIEW_PRODUCTIVITY_BY_ORDER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRPT_View_Productivity_By_Order", out_node);

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
    CRPT_VIEW_PRODUCTIVITY_BY_ORDER()
        - VIEW_PRODUCTIVITY_BY_ORDER
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_VIEW_PRODUCTIVITY_BY_ORDER(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPORDSTS_TAG CWIPORDSTS;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	char s_sys_time[14];
	TRSNode *list_item;

	// PROCESS LOG PRINT
	LOG_head("RPT_View_Productivity_By_Order");
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

	CDB_init_cwipordsts(&CWIPORDSTS);
	memcpy(CWIPORDSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
	TRS.copy(CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.MAT_ID), in_node, "MAT_ID");
	TRS.copy(CWIPORDSTS.START_DATE, sizeof(CWIPORDSTS.START_DATE), in_node, "FROM_TIME");
	TRS.copy(CWIPORDSTS.FINISH_DATE, sizeof(CWIPORDSTS.FINISH_DATE), in_node, "TO_TIME");

	CDB_open_cwipordsts(1,&CWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
    {
        //strcpy(s_msg_code, "WIP-0005");
		//TRS.add_fieldmsg(out_node, "CWIPORDSTS SELECT", MP_NVST);
		//TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
		
		// 20210810 MES Application Memory leak 점검 및 수정
		// DB error log edit
		strcpy(s_msg_code, "ORD-0004");
		TRS.add_fieldmsg(out_node, "CWIPORDSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
		TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPORDSTS.MAT_ID), CWIPORDSTS.MAT_ID);
		TRS.add_fieldmsg(out_node, "START_DATE", MP_STR, sizeof(CWIPORDSTS.START_DATE), CWIPORDSTS.START_DATE);
		TRS.add_fieldmsg(out_node, "FINISH_DATE", MP_STR, sizeof(CWIPORDSTS.FINISH_DATE), CWIPORDSTS.FINISH_DATE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
		
		// 20210810 MES Application Memory leak 점검 및 수정
		// Result Set
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        return MP_FALSE;
    }

	while(1)
	{
		CDB_fetch_cwipordsts(1,&CWIPORDSTS);
		if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipordsts(1);
            break;
        }
		// 20210810 MES Application Memory leak 점검 및 수정
		// DB Close 추가
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "ORD-0004");
			TRS.add_fieldmsg(out_node, "CWIPORDSTS FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPORDSTS.MAT_ID), CWIPORDSTS.MAT_ID);
			TRS.add_fieldmsg(out_node, "START_DATE", MP_STR, sizeof(CWIPORDSTS.START_DATE), CWIPORDSTS.START_DATE);
			TRS.add_fieldmsg(out_node, "FINISH_DATE", MP_STR, sizeof(CWIPORDSTS.FINISH_DATE), CWIPORDSTS.FINISH_DATE);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			CDB_close_cwipordsts(1);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "VIEW_PRODUCTIVITY_BY_ORDER_OUT");
		TRS.add_string(list_item, "WORK_DATE", CWIPORDSTS.CRE_DATE, sizeof(CWIPORDSTS.CRE_DATE));
		TRS.add_string(list_item, "WORK_LINE", CWIPORDSTS.WORK_CENTER, sizeof(CWIPORDSTS.WORK_CENTER));
		TRS.add_string(list_item, "ORDER_ID", CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
		TRS.add_string(list_item, "MAT_ID", CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.MAT_ID));
		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.MAT_ID));
		MWIPMATDEF.MAT_VER = 1;
		DBC_select_mwipmatdef(1,&MWIPMATDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			TRS.add_dberrmsg(out_node,DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
		}

		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
		DBC_select_mwipordsts(1,&MWIPORDSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			TRS.add_dberrmsg(out_node,DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
		}

		TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		TRS.add_string(list_item, "BOM_KEY", MWIPORDSTS.ORD_CMF_7, sizeof(MWIPORDSTS.ORD_CMF_7));
		TRS.add_string(list_item, "PLAN_START_TIME", CWIPORDSTS.START_DATE, sizeof(CWIPORDSTS.START_DATE));
		TRS.add_string(list_item, "PLAN_END_TIME", CWIPORDSTS.FINISH_DATE, sizeof(CWIPORDSTS.FINISH_DATE));
		TRS.add_char(list_item,"ORD_STATUS_FLAG",MWIPORDSTS.ORD_STATUS_FLAG);
		TRS.add_double(list_item,"ORD_QTY",CWIPORDSTS.PROD_QTY);
		TRS.add_int(list_item,"IN_QTY",(int)MWIPORDSTS.ORD_IN_QTY);
		TRS.add_int(list_item,"OUT_QTY",(int)MWIPORDSTS.ORD_OUT_QTY);
		TRS.add_int(list_item,"LOSS_QTY",(int)MWIPORDSTS.ORD_LOSS_QTY);
		TRS.add_int(list_item,"REPAIR_QTY",(int)MWIPORDSTS.ORD_RWK_QTY);
		TRS.add_int(list_item,"ACHIEVE",0);
		TRS.add_int(list_item,"YIELD",0);
		TRS.add_int(list_item,"LOSS_RATE",0);
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}