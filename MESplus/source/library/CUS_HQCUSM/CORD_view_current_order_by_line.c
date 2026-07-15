/******************************************************************************'

	System      : MESplus
	Module      : CORD
	File Name   : CORD_view_current_order_by_line.c
	Description : View Current Order by Line

    MES Version : 5.3.6.4

	Function List  
		- CORD_View_Current_Order_By_Line()
			+ View Work Order
		- CORD_VIEW_CURRENT_ORDER_BY_LINE()
			+ Main sub function of CORD_View_Current_Order_By_Line function
			+ View Work Order definition
		- CORD_View_Current_Order_By_Line_Validation()
			+ Main sub function of CORD_VIEW_CURRENT_ORDER_BY_LINE function
			+ Check the condition for view Work Order
	Detail Description
		- CORD_VIEW_CURRENT_ORDER_BY_LINE()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CORD_View_Current_Order_By_Line_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CORD_View_Current_Order_By_Line()
		- View Work Order
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CORD_View_Current_Order_By_Line(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CORD_VIEW_CURRENT_ORDER_BY_LINE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CORD_VIEW_CURRENT_ORDER_BY_LINE", out_node);

	if (i_ret == MP_TRUE)
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
	CORD_VIEW_CURRENT_ORDER_BY_LINE()
		- Main sub function of "CORD_View_Current_Order_By_Line" function
		- View Work Order
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CORD_VIEW_CURRENT_ORDER_BY_LINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MWIPORDSTS_TAG MWIPORDSTS;
    //struct CWIPORDSTS_TAG CWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
    struct MWIPMATDEF_TAG MWIPMATDEF;
	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct CWIPCELPAK_TAG CWIPCELPAK;

    LOG_head("CORD_VIEW_CURRENT_ORDER_BY_LINE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CORD_View_Current_Order_By_Line_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Get current order by line ID */
    DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
    TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "GCM-0007");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Get order information */
    DBC_init_mwipordsts(&MWIPORDSTS);
    TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID));

    DBC_select_mwipordsts(1, &MWIPORDSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "ORD-0002");
            TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "ORD-0004");
            TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Get material information */
    DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPMATDEF.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
    MWIPMATDEF.MAT_VER = 1;

    DBC_select_mwipmatdef(1, &MWIPMATDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0006");
            TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Construct out node */
    TRS.add_string(out_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
    TRS.add_string(out_node, "ORDER_DESC", MWIPORDSTS.ORDER_DESC, sizeof(MWIPORDSTS.ORDER_DESC));
    TRS.add_string(out_node, "MAT_ID", MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
    TRS.add_int(out_node, "MAT_VER", MWIPORDSTS.MAT_VER); 
    TRS.add_string(out_node, "FLOW", MWIPORDSTS.FLOW, sizeof(MWIPORDSTS.FLOW));
    TRS.add_int(out_node, "FLOW_SEQ_NUM", MWIPORDSTS.FLOW_SEQ_NUM);
    TRS.add_double(out_node, "ORD_QTY", MWIPORDSTS.ORD_QTY);
    TRS.add_string(out_node, "RES_ID", MWIPORDSTS.RES_ID, sizeof(MWIPORDSTS.RES_ID));
    TRS.add_string(out_node, "BOM_SET_ID", MWIPORDSTS.BOM_SET_ID, sizeof(MWIPORDSTS.BOM_SET_ID));
    TRS.add_int(out_node, "BOM_SET_VERSION", MWIPORDSTS.BOM_SET_VERSION);
    TRS.add_string(out_node, "CUSTOMER_ID", MWIPORDSTS.CUSTOMER_ID, sizeof(MWIPORDSTS.CUSTOMER_ID));
    TRS.add_string(out_node, "CUSTOMER_MAT_ID", MWIPORDSTS.CUSTOMER_MAT_ID, sizeof(MWIPORDSTS.CUSTOMER_MAT_ID));
    TRS.add_string(out_node, "WORK_DATE", MWIPORDSTS.WORK_DATE, sizeof(MWIPORDSTS.WORK_DATE));
    TRS.add_string(out_node, "PLAN_DUE_TIME", MWIPORDSTS.PLAN_DUE_TIME, sizeof(MWIPORDSTS.PLAN_DUE_TIME));
    TRS.add_string(out_node, "PLAN_START_TIME", MWIPORDSTS.PLAN_START_TIME, sizeof(MWIPORDSTS.PLAN_START_TIME));
    TRS.add_string(out_node, "PLAN_END_TIME", MWIPORDSTS.PLAN_END_TIME, sizeof(MWIPORDSTS.PLAN_END_TIME));
    TRS.add_string(out_node, "ORD_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
    TRS.add_string(out_node, "ORD_CMF_2", MWIPORDSTS.ORD_CMF_2, sizeof(MWIPORDSTS.ORD_CMF_2));
    TRS.add_string(out_node, "ORD_CMF_3", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
    TRS.add_string(out_node, "ORD_CMF_4", MWIPORDSTS.ORD_CMF_4, sizeof(MWIPORDSTS.ORD_CMF_4));
    TRS.add_string(out_node, "ORD_CMF_5", MWIPORDSTS.ORD_CMF_5, sizeof(MWIPORDSTS.ORD_CMF_5));
    TRS.add_string(out_node, "ORD_CMF_6", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
    TRS.add_string(out_node, "ORD_CMF_7", MWIPORDSTS.ORD_CMF_7, sizeof(MWIPORDSTS.ORD_CMF_7));
    TRS.add_string(out_node, "ORD_CMF_8", MWIPORDSTS.ORD_CMF_8, sizeof(MWIPORDSTS.ORD_CMF_8));
    TRS.add_string(out_node, "ORD_CMF_9", MWIPORDSTS.ORD_CMF_9, sizeof(MWIPORDSTS.ORD_CMF_9));
    TRS.add_string(out_node, "ORD_CMF_10", MWIPORDSTS.ORD_CMF_10, sizeof(MWIPORDSTS.ORD_CMF_10));
    TRS.add_double(out_node, "QTY", MWIPORDSTS.QTY);
    TRS.add_char(out_node, "LOT_TYPE", MWIPORDSTS.LOT_TYPE);
    TRS.add_string(out_node, "CREATE_CODE", MWIPORDSTS.CREATE_CODE, sizeof(MWIPORDSTS.CREATE_CODE));
    TRS.add_string(out_node, "OWNER_CODE", MWIPORDSTS.OWNER_CODE, sizeof(MWIPORDSTS.OWNER_CODE));
    TRS.add_char(out_node, "LOT_PRIORITY", MWIPORDSTS.LOT_PRIORITY);
    TRS.add_string(out_node, "ORG_DUE_TIME", MWIPORDSTS.ORG_DUE_TIME, sizeof(MWIPORDSTS.ORG_DUE_TIME));
    TRS.add_char(out_node, "ORDER_STATUS_FLAG", MWIPORDSTS.ORD_STATUS_FLAG);
    TRS.add_char(out_node, "ORDER_SHIP_FLAG", MWIPORDSTS.ORD_SHIP_FLAG);
    TRS.add_string(out_node, "ORDER_START_TIME", MWIPORDSTS.ORD_START_TIME, sizeof(MWIPORDSTS.ORD_START_TIME));
    TRS.add_string(out_node, "ORDER_END_TIME", MWIPORDSTS.ORD_END_TIME, sizeof(MWIPORDSTS.ORD_END_TIME));
    TRS.add_double(out_node, "ORD_IN_QTY", MWIPORDSTS.ORD_IN_QTY);
    TRS.add_double(out_node, "ORD_OUT_QTY", MWIPORDSTS.ORD_OUT_QTY);
    TRS.add_double(out_node, "ORD_LOSS_QTY", MWIPORDSTS.ORD_LOSS_QTY);
    TRS.add_double(out_node, "ORD_RWK_QTY", MWIPORDSTS.ORD_RWK_QTY);
    TRS.add_string(out_node, "CREATE_TIME", MWIPORDSTS.CREATE_TIME, sizeof(MWIPORDSTS.CREATE_TIME));
    TRS.add_enc_string(out_node, "CREATE_USER_ID", MWIPORDSTS.CREATE_USER_ID, sizeof(MWIPORDSTS.CREATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MWIPORDSTS.UPDATE_TIME, sizeof(MWIPORDSTS.UPDATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MWIPORDSTS.UPDATE_USER_ID, sizeof(MWIPORDSTS.UPDATE_USER_ID));

    TRS.add_string(out_node, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));

	//ORDER 수량
	if (memcmp(MWIPORDSTS.ORD_CMF_1, "CVL", 3) == 0)
	{
		double dPackQty = 0;
		//CLEAVING ORDER
		//CLEAVING 투입수량 / 완료수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		memcpy(RSUMWIPMOV.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_FCELBX, strlen(HQCEL_LOT_CREATECODE_FCELBX));
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_IN_QTY", RSUMWIPMOV.S1_OPER_IN_QTY_1);
			
		}

		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		memcpy(RSUMWIPMOV.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_HCELBX, strlen(HQCEL_LOT_CREATECODE_HCELBX));
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_OUT_QTY", RSUMWIPMOV.S1_END_QTY_1);
		}

		CDB_init_cwipcelpak(&CWIPCELPAK);
		TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);
		memcpy(RSUMWIPMOV.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		CWIPCELPAK.PACK_TYPE = 'F';
		dPackQty = CDB_select_cwipcelpak_scalar(11, &CWIPCELPAK);

		TRS.set_double(out_node, "ORD_PACK_QTY",dPackQty);
		
	}
	else if (memcmp(MWIPORDSTS.ORD_CMF_1, "MDL", 3) == 0)
	{
		//MAIN 투입수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		memcpy(RSUMWIPMOV.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_LAYUP_OPER, strlen(HQCEL_M1_LAYUP_OPER));
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_IN_QTY", RSUMWIPMOV.S1_OPER_IN_QTY_1);
		}

		//MAIN 완료수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		memcpy(RSUMWIPMOV.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER));
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_OUT_QTY", RSUMWIPMOV.S1_END_QTY_1);
		}

		//MAIN 불량수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		memcpy(RSUMWIPMOV.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE));
		CDB_select_rsumwipmov(3, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_LOSS_QTY", RSUMWIPMOV.S1_LOSS_QTY_1);
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CORD_View_Current_Order_By_Line_Validation()
		- Main sub function of "CORD_VIEW_CURRENT_ORDER_BY_LINE" function
		- Check the condition for view Work Order
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CORD_View_Current_Order_By_Line_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
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