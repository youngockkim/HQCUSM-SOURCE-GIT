/*******************************************************************************

    System      : MESplus
    Module      : VIEW_Productivity_By_Order_List
    File Name   : CRPT_view_productivity_by_period.c

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

int CRPT_VIEW_PRODUCTIVITY_BY_PERIOD(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);

/*******************************************************************************
    CRPT_View_Productivity_By_Period()
        - Productivity By Period
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_View_Productivity_By_Period(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRPT_VIEW_PRODUCTIVITY_BY_PERIOD(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRPT_View_Productivity_By_Period", out_node);

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
    CRPT_VIEW_PRODUCTIVITY_BY_PERIOD()
        - VIEW_PRODUCTIVITY_BY_PERIOD
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_VIEW_PRODUCTIVITY_BY_PERIOD(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	char s_sys_time[14];
	TRSNode *list_item;
	double v_pass_qty = 0;
	double v_loss_qty = 0;

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

	CDB_init_rsumwipmov(&RSUMWIPMOV);

	memcpy(RSUMWIPMOV.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));

	if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
	{
		memcpy(RSUMWIPMOV.CM_KEY_1, "%", strlen("%"));

	}
	else
	{
		TRS.copy(RSUMWIPMOV.CM_KEY_1 , sizeof(RSUMWIPMOV.CM_KEY_1), in_node, "LINE_ID");
	}

	if(COM_isnullspace(TRS.get_string(in_node, "OPER")) == MP_TRUE)
	{
		memcpy(RSUMWIPMOV.OPER, "%", strlen("%"));

	}
	else
	{
		TRS.copy(RSUMWIPMOV.OPER, sizeof(RSUMWIPMOV.OPER), in_node, "OPER");
	}

	if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
	{
		memcpy(RSUMWIPMOV.MAT_ID, "%", strlen("%"));

	}
	else
	{
		TRS.copy(RSUMWIPMOV.MAT_ID, sizeof(RSUMWIPMOV.MAT_ID), in_node, "MAT_ID");
	}
	

	TRS.copy(RSUMWIPMOV.CM_KEY_3, strlen("99991231"), in_node, "FROM_TIME");
    TRS.copy(RSUMWIPMOV.CM_KEY_4, strlen("99991231"), in_node, "TO_TIME");
			

	CDB_open_rsumwipmov(2,&RSUMWIPMOV);		//IS-20-09-222 
	if(DB_error_code != DB_SUCCESS)
    {
        //strcpy(s_msg_code, "WIP-0005");
        //TRS.add_fieldmsg(out_node, "RSUMWIPMOV SELECT", MP_NVST);

		// 20210810 MES Application Memory leak 점검 및 수정
		// log edit
		strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "RSUMWIPMOV OPEN", MP_NVST);

		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPMOV.FACTORY), RSUMWIPMOV.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPMOV.MAT_ID), RSUMWIPMOV.MAT_ID);
		TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(RSUMWIPMOV.OPER), RSUMWIPMOV.OPER);
		TRS.add_fieldmsg(out_node, "CM_KEY_1", MP_STR, sizeof(RSUMWIPMOV.CM_KEY_1), RSUMWIPMOV.CM_KEY_1);
		TRS.add_fieldmsg(out_node, "CM_KEY_3", MP_STR, sizeof(RSUMWIPMOV.CM_KEY_3), RSUMWIPMOV.CM_KEY_3);
		TRS.add_fieldmsg(out_node, "CM_KEY_4", MP_STR, sizeof(RSUMWIPMOV.CM_KEY_4), RSUMWIPMOV.CM_KEY_4);

        TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

		// 20210810 MES Application Memory leak 점검 및 수정
		// log edit
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        return MP_FALSE;
    }

	while(1)
	{
		CDB_fetch_rsumwipmov(2,&RSUMWIPMOV); //IS-20-09-222 
		if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_rsumwipmov(2);
            break;
        }
		// 20210810 MES Application Memory leak 점검 및 수정
		// DB Close 추가
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "RSUMWIPMOV FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPMOV.FACTORY), RSUMWIPMOV.FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPMOV.MAT_ID), RSUMWIPMOV.MAT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(RSUMWIPMOV.OPER), RSUMWIPMOV.OPER);
			TRS.add_fieldmsg(out_node, "CM_KEY_1", MP_STR, sizeof(RSUMWIPMOV.CM_KEY_1), RSUMWIPMOV.CM_KEY_1);
			TRS.add_fieldmsg(out_node, "CM_KEY_3", MP_STR, sizeof(RSUMWIPMOV.CM_KEY_3), RSUMWIPMOV.CM_KEY_3);
			TRS.add_fieldmsg(out_node, "CM_KEY_4", MP_STR, sizeof(RSUMWIPMOV.CM_KEY_4), RSUMWIPMOV.CM_KEY_4);

			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			CDB_close_rsumwipmov(2);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "VIEW_PRODUCTIVITY_BY_PERIOD_OUT");
		TRS.add_string(list_item, "WORK_DATE", RSUMWIPMOV.WORK_DATE, sizeof(RSUMWIPMOV.WORK_DATE));
		TRS.add_string(list_item, "ORDER_ID", RSUMWIPMOV.ORDER_ID, sizeof(RSUMWIPMOV.ORDER_ID));
		TRS.add_string(list_item, "LINE_ID", RSUMWIPMOV.CM_KEY_1, sizeof(RSUMWIPMOV.CM_KEY_1));
		
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, RSUMWIPMOV.ORDER_ID, sizeof(RSUMWIPMOV.ORDER_ID));
		
		DBC_select_mwipordsts(1,&MWIPORDSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			TRS.add_dberrmsg(out_node,DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "ORD-0002");
				TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_rsumwipmov(2);

				return MP_FALSE;
			}
			
		}
		
		TRS.add_string(list_item, "BOM_KEY", MWIPORDSTS.ORD_CMF_7, sizeof(MWIPORDSTS.ORD_CMF_7));
		TRS.add_string(list_item, "OPER", RSUMWIPMOV.OPER, sizeof(RSUMWIPMOV.OPER));
		
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		memcpy(MWIPOPRDEF.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPOPRDEF.OPER, RSUMWIPMOV.OPER, sizeof(MWIPOPRDEF.OPER));
		
		DBC_select_mwipoprdef(1,&MWIPOPRDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			TRS.add_dberrmsg(out_node,DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0010");
				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_rsumwipmov(2);

				return MP_FALSE;
			}
		}
		
		TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
		TRS.add_string(list_item, "MAT_ID", RSUMWIPMOV.MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
		
		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, RSUMWIPMOV.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATDEF.MAT_VER = 1;
		
		DBC_select_mwipmatdef(1,&MWIPMATDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			TRS.add_dberrmsg(out_node,DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0006");
				TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_rsumwipmov(2);

				return MP_FALSE;
			}
		}
		
		TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		TRS.add_int(list_item, "PASS_QTY", (int)(RSUMWIPMOV.S1_END_QTY_1 + RSUMWIPMOV.S2_END_QTY_1 + RSUMWIPMOV.S3_END_QTY_1 + RSUMWIPMOV.S4_END_QTY_1 + RSUMWIPMOV.S1_END_QTY_2 + RSUMWIPMOV.S2_END_QTY_2 + RSUMWIPMOV.S3_END_QTY_2 + RSUMWIPMOV.S4_END_QTY_2 + RSUMWIPMOV.S1_END_QTY_3 + RSUMWIPMOV.S2_END_QTY_3 + RSUMWIPMOV.S3_END_QTY_3 + RSUMWIPMOV.S4_END_QTY_3));
		TRS.add_int(list_item, "LOSS_QTY", (int)(RSUMWIPMOV.S1_LOSS_QTY_1 + RSUMWIPMOV.S2_LOSS_QTY_1 + RSUMWIPMOV.S3_LOSS_QTY_1 + RSUMWIPMOV.S4_LOSS_QTY_1 + RSUMWIPMOV.S1_LOSS_QTY_2 + RSUMWIPMOV.S2_LOSS_QTY_2 + RSUMWIPMOV.S3_LOSS_QTY_2 + RSUMWIPMOV.S4_LOSS_QTY_2 + RSUMWIPMOV.S1_LOSS_QTY_3 + RSUMWIPMOV.S2_LOSS_QTY_3 + RSUMWIPMOV.S3_LOSS_QTY_3 + RSUMWIPMOV.S4_LOSS_QTY_3));

		v_pass_qty = (RSUMWIPMOV.S1_END_QTY_1 + RSUMWIPMOV.S2_END_QTY_1 + RSUMWIPMOV.S3_END_QTY_1 + RSUMWIPMOV.S4_END_QTY_1 + RSUMWIPMOV.S1_END_QTY_2 + RSUMWIPMOV.S2_END_QTY_2 + RSUMWIPMOV.S3_END_QTY_2 + RSUMWIPMOV.S4_END_QTY_2 + RSUMWIPMOV.S1_END_QTY_3 + RSUMWIPMOV.S2_END_QTY_3 + RSUMWIPMOV.S3_END_QTY_3 + RSUMWIPMOV.S4_END_QTY_3);
		v_loss_qty = (RSUMWIPMOV.S1_LOSS_QTY_1 + RSUMWIPMOV.S2_LOSS_QTY_1 + RSUMWIPMOV.S3_LOSS_QTY_1 + RSUMWIPMOV.S4_LOSS_QTY_1 + RSUMWIPMOV.S1_LOSS_QTY_2 + RSUMWIPMOV.S2_LOSS_QTY_2 + RSUMWIPMOV.S3_LOSS_QTY_2 + RSUMWIPMOV.S4_LOSS_QTY_2 + RSUMWIPMOV.S1_LOSS_QTY_3 + RSUMWIPMOV.S2_LOSS_QTY_3 + RSUMWIPMOV.S3_LOSS_QTY_3 + RSUMWIPMOV.S4_LOSS_QTY_3);

		TRS.add_double(list_item, "YIELD", ((v_pass_qty - v_loss_qty)/v_pass_qty)*100);		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}