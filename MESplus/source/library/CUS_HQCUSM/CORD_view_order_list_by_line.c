/******************************************************************************'

	System      : MESplus
	Module      : CORD
	File Name   : CORD_view_order_list_by_line.c
	Description : View Order List by Line

    MES Version : 5.3.6.4

	Function List  
		- CORD_View_Order_List_By_Line()
			+ View Lot
		- CORD_VIEW_ORDER_LIST_BY_LINE()
			+ Main sub function of CORD_View_Order_List_By_Line function
			+ View Order List definition
		- CORD_View_Order_List_By_Line_Validation()
			+ Main sub function of CORD_VIEW_ORDER_LIST_BY_LINE function
			+ Check the condition for view Order List
	Detail Description
		- CORD_VIEW_ORDER_LIST_BY_LINE()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CORD_View_Order_List_By_Line_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CORD_View_Order_List_By_Line()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CORD_View_Order_List_By_Line(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CORD_VIEW_ORDER_LIST_BY_LINE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CORD_VIEW_ORDER_LIST_BY_LINE", out_node);

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
	CORD_VIEW_ORDER_LIST_BY_LINE()
		- Main sub function of "CORD_View_Order_List_By_Line" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CORD_VIEW_ORDER_LIST_BY_LINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MWIPORDSTS_TAG MWIPORDSTS;
    struct MWIPMATDEF_TAG MWIPMATDEF;
	struct CWIPORDBOM_TAG CWIPORDBOM;
    TRSNode *list_item;

    int i_step;

    LOG_head("CORD_VIEW_ORDER_LIST_BY_LINE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Order List by Line ID
        Step 2: Order List by Line ID and Work Period
        Step 3: Order List by Line ID, Work Period, and Material ID
        Step 4: Order List by Line ID (display 5 latest Order IDs)
        Step 5: Order List by Line ID including BOM
        Step 6: Order List by Line ID and Order ID including BOM
    */

    if(CORD_View_Order_List_By_Line_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if (TRS.get_procstep(in_node) == '1')
    {
        i_step = 101;
    }
    else if (TRS.get_procstep(in_node) == '2')
    {
        i_step = 102;
    }
    else if (TRS.get_procstep(in_node) == '3')
    {
        i_step = 103;
    }
    else if (TRS.get_procstep(in_node) == '5')
    {
        i_step = 101;
    }
    else if (TRS.get_procstep(in_node) == '6')
    {
        i_step = 105;
    }
    else /* default */
    {
        i_step = 101;
    }

    DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE), in_node, "FROM_DATE");
    TRS.copy(DBC_Q_COND.TO_DATE, sizeof(DBC_Q_COND.TO_DATE), in_node, "TO_DATE");
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

    DBC_init_mwipordsts(&MWIPORDSTS);
    TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.MAT_ID), in_node, "ORDER_ID");
    TRS.copy(MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID), in_node, "MAT_ID");
    TRS.copy(MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1), in_node, "LINE_ID");

    DBC_open_mwipordsts(i_step, &MWIPORDSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "ORD-0004");
        TRS.add_fieldmsg(out_node, "MWIPORDSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "ORD_CMF_1", MP_STR, sizeof(MWIPORDSTS.ORD_CMF_1), MWIPORDSTS.ORD_CMF_1);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mwipordsts(i_step, &MWIPORDSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
			/*
            strcpy(s_msg_code, "ORD-0002");
            TRS.add_fieldmsg(out_node, "MWIPORDSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORD_CMF_1", MP_STR, sizeof(MWIPORDSTS.ORD_CMF_1), MWIPORDSTS.ORD_CMF_1);

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;

            DBC_close_mwipordsts(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			*/

			// 20210810 MES Application Memory leak 점검 및 수정
			// DB_NOT_FOUND is only db close
			DBC_close_mwipordsts(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "ORD-0004");
            TRS.add_fieldmsg(out_node, "MWIPORDSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORD_CMF_1", MP_STR, sizeof(MWIPORDSTS.ORD_CMF_1), MWIPORDSTS.ORD_CMF_1);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipordsts(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Get material data */
        DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPMATDEF.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
        MWIPMATDEF.MAT_VER = 1;
        DBC_select_mwipmatdef(1, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
                TRS.add_dberrmsg(out_node,DB_error_msg);
            }
        }

		/* Get grade & efficiency data */
        /*
		CDB_init_cwipordbom(&CWIPORDBOM);
		memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPORDBOM.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
		memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
        CDB_select_cwipordbom(4, &CWIPORDBOM);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDBOM.ORDER_ID), CWIPORDBOM.ORDER_ID);
                TRS.add_fieldmsg(out_node, "MATE_TYPE", MP_INT, CWIPORDBOM.MATE_TYPE);
                TRS.add_dberrmsg(out_node,DB_error_msg);
            }
        }
        */

        /* Construct out node */
        if (TRS.get_procstep(in_node) == '5' || TRS.get_procstep(in_node) == '6') /* including BOM */
        {
		    /* Efficiency & Grade */
		    CDB_init_cwipordbom(&CWIPORDBOM);
		    memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		    memcpy(CWIPORDBOM.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
		    memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
		    CDB_open_cwipordbom(6, &CWIPORDBOM);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    //DO NOTHING
		    }

		    while(1)
		    {
			    CDB_fetch_cwipordbom(6, &CWIPORDBOM);
			    if(DB_error_code != DB_SUCCESS)
			    {
				    CDB_close_cwipordbom(6);
				    break;
			    }
				
                list_item = TRS.add_node(out_node, "LIST");
                TRS.add_string(list_item, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
                TRS.add_string(list_item, "ORDER_DESC", MWIPORDSTS.ORDER_DESC, sizeof(MWIPORDSTS.ORDER_DESC));
                TRS.add_string(list_item, "MAT_ID", MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
                TRS.add_int(list_item, "MAT_VER", MWIPORDSTS.MAT_VER); 
                TRS.add_string(list_item, "FLOW", MWIPORDSTS.FLOW, sizeof(MWIPORDSTS.FLOW));
                TRS.add_int(list_item, "FLOW_SEQ_NUM", MWIPORDSTS.FLOW_SEQ_NUM);
                TRS.add_double(list_item, "ORD_QTY", MWIPORDSTS.ORD_QTY);
                TRS.add_string(list_item, "RES_ID", MWIPORDSTS.RES_ID, sizeof(MWIPORDSTS.RES_ID));
                TRS.add_string(list_item, "BOM_SET_ID", MWIPORDSTS.BOM_SET_ID, sizeof(MWIPORDSTS.BOM_SET_ID));
                TRS.add_int(list_item, "BOM_SET_VERSION", MWIPORDSTS.BOM_SET_VERSION);
                TRS.add_string(list_item, "CUSTOMER_ID", MWIPORDSTS.CUSTOMER_ID, sizeof(MWIPORDSTS.CUSTOMER_ID));
                TRS.add_string(list_item, "CUSTOMER_MAT_ID", MWIPORDSTS.CUSTOMER_MAT_ID, sizeof(MWIPORDSTS.CUSTOMER_MAT_ID));
                TRS.add_string(list_item, "WORK_DATE", MWIPORDSTS.WORK_DATE, sizeof(MWIPORDSTS.WORK_DATE));
                TRS.add_string(list_item, "PLAN_DUE_TIME", MWIPORDSTS.PLAN_DUE_TIME, sizeof(MWIPORDSTS.PLAN_DUE_TIME));
                TRS.add_string(list_item, "PLAN_START_TIME", MWIPORDSTS.PLAN_START_TIME, sizeof(MWIPORDSTS.PLAN_START_TIME));
                TRS.add_string(list_item, "PLAN_END_TIME", MWIPORDSTS.PLAN_END_TIME, sizeof(MWIPORDSTS.PLAN_END_TIME));
                TRS.add_string(list_item, "ORD_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
                TRS.add_string(list_item, "ORD_CMF_2", MWIPORDSTS.ORD_CMF_2, sizeof(MWIPORDSTS.ORD_CMF_2));
                TRS.add_string(list_item, "ORD_CMF_3", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
                TRS.add_string(list_item, "ORD_CMF_4", MWIPORDSTS.ORD_CMF_4, sizeof(MWIPORDSTS.ORD_CMF_4));
                TRS.add_string(list_item, "ORD_CMF_5", MWIPORDSTS.ORD_CMF_5, sizeof(MWIPORDSTS.ORD_CMF_5));
                TRS.add_string(list_item, "ORD_CMF_6", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
                TRS.add_string(list_item, "ORD_CMF_7", MWIPORDSTS.ORD_CMF_7, sizeof(MWIPORDSTS.ORD_CMF_7));
                TRS.add_string(list_item, "ORD_CMF_8", MWIPORDSTS.ORD_CMF_8, sizeof(MWIPORDSTS.ORD_CMF_8));
                TRS.add_string(list_item, "ORD_CMF_9", MWIPORDSTS.ORD_CMF_9, sizeof(MWIPORDSTS.ORD_CMF_9));
                TRS.add_string(list_item, "ORD_CMF_10", MWIPORDSTS.ORD_CMF_10, sizeof(MWIPORDSTS.ORD_CMF_10));
                TRS.add_double(list_item, "QTY", MWIPORDSTS.QTY);
                TRS.add_char(list_item, "LOT_TYPE", MWIPORDSTS.LOT_TYPE);
                TRS.add_string(list_item, "CREATE_CODE", MWIPORDSTS.CREATE_CODE, sizeof(MWIPORDSTS.CREATE_CODE));
                TRS.add_string(list_item, "OWNER_CODE", MWIPORDSTS.OWNER_CODE, sizeof(MWIPORDSTS.OWNER_CODE));
                TRS.add_char(list_item, "LOT_PRIORITY", MWIPORDSTS.LOT_PRIORITY);
                TRS.add_string(list_item, "ORG_DUE_TIME", MWIPORDSTS.ORG_DUE_TIME, sizeof(MWIPORDSTS.ORG_DUE_TIME));
                TRS.add_char(list_item, "ORDER_STATUS_FLAG", MWIPORDSTS.ORD_STATUS_FLAG);
                TRS.add_char(list_item, "ORDER_SHIP_FLAG", MWIPORDSTS.ORD_SHIP_FLAG);
                TRS.add_string(list_item, "ORDER_START_TIME", MWIPORDSTS.ORD_START_TIME, sizeof(MWIPORDSTS.ORD_START_TIME));
                TRS.add_string(list_item, "ORDER_END_TIME", MWIPORDSTS.ORD_END_TIME, sizeof(MWIPORDSTS.ORD_END_TIME));
                TRS.add_double(list_item, "ORD_IN_QTY", MWIPORDSTS.ORD_IN_QTY);
                TRS.add_double(list_item, "ORD_OUT_QTY", MWIPORDSTS.ORD_OUT_QTY);
                TRS.add_double(list_item, "ORD_LOSS_QTY", MWIPORDSTS.ORD_LOSS_QTY);
                TRS.add_double(list_item, "ORD_RWK_QTY", MWIPORDSTS.ORD_RWK_QTY);
                TRS.add_string(list_item, "CREATE_TIME", MWIPORDSTS.CREATE_TIME, sizeof(MWIPORDSTS.CREATE_TIME));
                TRS.add_string(list_item, "CREATE_USER_ID", MWIPORDSTS.CREATE_USER_ID, sizeof(MWIPORDSTS.CREATE_USER_ID));
                TRS.add_string(list_item, "UPDATE_TIME", MWIPORDSTS.UPDATE_TIME, sizeof(MWIPORDSTS.UPDATE_TIME));
                TRS.add_string(list_item, "UPDATE_USER_ID", MWIPORDSTS.UPDATE_USER_ID, sizeof(MWIPORDSTS.UPDATE_USER_ID));
		        TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		        TRS.add_double(list_item, "USED_QTY", MWIPORDSTS.ORD_IN_QTY);
		        TRS.add_double(list_item, "REMAIN_QTY", MWIPORDSTS.ORD_QTY-MWIPORDSTS.ORD_IN_QTY);

                TRS.add_string(list_item, "EFFICIENCY", CWIPORDBOM.CELL_POWER_GRADE_1, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
		        TRS.add_string(list_item, "GRADE", CWIPORDBOM.CELL_POWER_GRADE_2, sizeof(CWIPORDBOM.CELL_POWER_GRADE_2));
		    }
        }
        else
        {
            list_item = TRS.add_node(out_node, "LIST");
            TRS.add_string(list_item, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
            TRS.add_string(list_item, "ORDER_DESC", MWIPORDSTS.ORDER_DESC, sizeof(MWIPORDSTS.ORDER_DESC));
            TRS.add_string(list_item, "MAT_ID", MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
            TRS.add_int(list_item, "MAT_VER", MWIPORDSTS.MAT_VER); 
            TRS.add_string(list_item, "FLOW", MWIPORDSTS.FLOW, sizeof(MWIPORDSTS.FLOW));
            TRS.add_int(list_item, "FLOW_SEQ_NUM", MWIPORDSTS.FLOW_SEQ_NUM);
            TRS.add_double(list_item, "ORD_QTY", MWIPORDSTS.ORD_QTY);
            TRS.add_string(list_item, "RES_ID", MWIPORDSTS.RES_ID, sizeof(MWIPORDSTS.RES_ID));
            TRS.add_string(list_item, "BOM_SET_ID", MWIPORDSTS.BOM_SET_ID, sizeof(MWIPORDSTS.BOM_SET_ID));
            TRS.add_int(list_item, "BOM_SET_VERSION", MWIPORDSTS.BOM_SET_VERSION);
            TRS.add_string(list_item, "CUSTOMER_ID", MWIPORDSTS.CUSTOMER_ID, sizeof(MWIPORDSTS.CUSTOMER_ID));
            TRS.add_string(list_item, "CUSTOMER_MAT_ID", MWIPORDSTS.CUSTOMER_MAT_ID, sizeof(MWIPORDSTS.CUSTOMER_MAT_ID));
            TRS.add_string(list_item, "WORK_DATE", MWIPORDSTS.WORK_DATE, sizeof(MWIPORDSTS.WORK_DATE));
            TRS.add_string(list_item, "PLAN_DUE_TIME", MWIPORDSTS.PLAN_DUE_TIME, sizeof(MWIPORDSTS.PLAN_DUE_TIME));
            TRS.add_string(list_item, "PLAN_START_TIME", MWIPORDSTS.PLAN_START_TIME, sizeof(MWIPORDSTS.PLAN_START_TIME));
            TRS.add_string(list_item, "PLAN_END_TIME", MWIPORDSTS.PLAN_END_TIME, sizeof(MWIPORDSTS.PLAN_END_TIME));
            TRS.add_string(list_item, "ORD_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
            TRS.add_string(list_item, "ORD_CMF_2", MWIPORDSTS.ORD_CMF_2, sizeof(MWIPORDSTS.ORD_CMF_2));
            TRS.add_string(list_item, "ORD_CMF_3", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
            TRS.add_string(list_item, "ORD_CMF_4", MWIPORDSTS.ORD_CMF_4, sizeof(MWIPORDSTS.ORD_CMF_4));
            TRS.add_string(list_item, "ORD_CMF_5", MWIPORDSTS.ORD_CMF_5, sizeof(MWIPORDSTS.ORD_CMF_5));
            TRS.add_string(list_item, "ORD_CMF_6", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
            TRS.add_string(list_item, "ORD_CMF_7", MWIPORDSTS.ORD_CMF_7, sizeof(MWIPORDSTS.ORD_CMF_7));
            TRS.add_string(list_item, "ORD_CMF_8", MWIPORDSTS.ORD_CMF_8, sizeof(MWIPORDSTS.ORD_CMF_8));
            TRS.add_string(list_item, "ORD_CMF_9", MWIPORDSTS.ORD_CMF_9, sizeof(MWIPORDSTS.ORD_CMF_9));
            TRS.add_string(list_item, "ORD_CMF_10", MWIPORDSTS.ORD_CMF_10, sizeof(MWIPORDSTS.ORD_CMF_10));
            TRS.add_double(list_item, "QTY", MWIPORDSTS.QTY);
            TRS.add_char(list_item, "LOT_TYPE", MWIPORDSTS.LOT_TYPE);
            TRS.add_string(list_item, "CREATE_CODE", MWIPORDSTS.CREATE_CODE, sizeof(MWIPORDSTS.CREATE_CODE));
            TRS.add_string(list_item, "OWNER_CODE", MWIPORDSTS.OWNER_CODE, sizeof(MWIPORDSTS.OWNER_CODE));
            TRS.add_char(list_item, "LOT_PRIORITY", MWIPORDSTS.LOT_PRIORITY);
            TRS.add_string(list_item, "ORG_DUE_TIME", MWIPORDSTS.ORG_DUE_TIME, sizeof(MWIPORDSTS.ORG_DUE_TIME));
            TRS.add_char(list_item, "ORDER_STATUS_FLAG", MWIPORDSTS.ORD_STATUS_FLAG);
            TRS.add_char(list_item, "ORDER_SHIP_FLAG", MWIPORDSTS.ORD_SHIP_FLAG);
            TRS.add_string(list_item, "ORDER_START_TIME", MWIPORDSTS.ORD_START_TIME, sizeof(MWIPORDSTS.ORD_START_TIME));
            TRS.add_string(list_item, "ORDER_END_TIME", MWIPORDSTS.ORD_END_TIME, sizeof(MWIPORDSTS.ORD_END_TIME));
            TRS.add_double(list_item, "ORD_IN_QTY", MWIPORDSTS.ORD_IN_QTY);
            TRS.add_double(list_item, "ORD_OUT_QTY", MWIPORDSTS.ORD_OUT_QTY);
            TRS.add_double(list_item, "ORD_LOSS_QTY", MWIPORDSTS.ORD_LOSS_QTY);
            TRS.add_double(list_item, "ORD_RWK_QTY", MWIPORDSTS.ORD_RWK_QTY);
            TRS.add_string(list_item, "CREATE_TIME", MWIPORDSTS.CREATE_TIME, sizeof(MWIPORDSTS.CREATE_TIME));
            TRS.add_string(list_item, "CREATE_USER_ID", MWIPORDSTS.CREATE_USER_ID, sizeof(MWIPORDSTS.CREATE_USER_ID));
            TRS.add_string(list_item, "UPDATE_TIME", MWIPORDSTS.UPDATE_TIME, sizeof(MWIPORDSTS.UPDATE_TIME));
            TRS.add_string(list_item, "UPDATE_USER_ID", MWIPORDSTS.UPDATE_USER_ID, sizeof(MWIPORDSTS.UPDATE_USER_ID));
		    TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		    TRS.add_double(list_item, "USED_QTY", MWIPORDSTS.ORD_IN_QTY);
		    TRS.add_double(list_item, "REMAIN_QTY", MWIPORDSTS.ORD_QTY-MWIPORDSTS.ORD_IN_QTY);
        }

        /*
		//GRADE / EFFICENCY MULTI 로 가져와서 , 로 구분함 JH.JUNG
		{
			char tmp_str[40];
			int i_tmp_cnt = 0;

			
			memset(tmp_str, '\0', sizeof(tmp_str));
			
			//POWER
			CDB_init_cwipordbom(&CWIPORDBOM);
			memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPORDBOM.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
			memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
			CDB_open_cwipordbom(4, &CWIPORDBOM);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}

			while(1)
			{
				CDB_fetch_cwipordbom(4, &CWIPORDBOM);
				if(DB_error_code != DB_SUCCESS)
				{
					CDB_close_cwipordbom(4);
					break;
				}
				
				if (strlen(tmp_str) > 39)
				{
					break;
				}

				if(i_tmp_cnt==0)
				{
					TRS.set_string(in_node, "T_TMP", CWIPORDBOM.CELL_POWER_GRADE_1, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
					sprintf(tmp_str + strlen(tmp_str), "%s", TRS.get_string(in_node, "T_TMP"));
					} else
				{ 
					TRS.set_string(in_node, "T_TMP", CWIPORDBOM.CELL_POWER_GRADE_1, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
					sprintf(tmp_str + strlen(tmp_str), ", %s", TRS.get_string(in_node, "T_TMP"));
				}
				i_tmp_cnt++;
			}
			
			if (i_tmp_cnt > 0)
			{
				TRS.set_nstring(list_item, "EFFICIENCY", tmp_str);
			}

			i_tmp_cnt =0;
			//GRADE
			memset(tmp_str, '\0', sizeof(tmp_str));
			CDB_init_cwipordbom(&CWIPORDBOM);
			memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPORDBOM.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
			memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
			CDB_open_cwipordbom(5, &CWIPORDBOM);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}

			while(1)
			{
				CDB_fetch_cwipordbom(5, &CWIPORDBOM);
				if(DB_error_code != DB_SUCCESS)
				{
					CDB_close_cwipordbom(5);
					break;
				}
				
				if (strlen(tmp_str) > 39)
				{
					break;
				}

				if(i_tmp_cnt==0)
				{
					TRS.set_string(in_node, "T_TMP", CWIPORDBOM.CELL_POWER_GRADE_2, sizeof(CWIPORDBOM.CELL_POWER_GRADE_2));
					sprintf(tmp_str + strlen(tmp_str), "%s", TRS.get_string(in_node, "T_TMP"));
					} else
				{ 
					TRS.set_string(in_node, "T_TMP", CWIPORDBOM.CELL_POWER_GRADE_2, sizeof(CWIPORDBOM.CELL_POWER_GRADE_2));
					sprintf(tmp_str + strlen(tmp_str), ", %s", TRS.get_string(in_node, "T_TMP"));
				}
				i_tmp_cnt++;
			}
			
			if (i_tmp_cnt > 0)
			{
				TRS.set_nstring(list_item, "GRADE", tmp_str);
			}
		}
        */
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CORD_View_Order_List_By_Line_Validation()
		- Main sub function of "CORD_VIEW_ORDER_LIST_BY_LINE" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CORD_View_Order_List_By_Line_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12356") == MP_FALSE)
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