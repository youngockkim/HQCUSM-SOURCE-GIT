/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_lot.c
	Description : View Lot Information

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Lot()
			+ View Lot
		- CWIP_VIEW_LOT()
			+ Main sub function of CWIP_View_Lot function
			+ View Lot definition
		- CWIP_View_Lot_Validation()
			+ Main sub function of CWIP_VIEW_LOT function
			+ Check the condition for view Lot
	Detail Description
		- CWIP_VIEW_LOT()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Lot()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Lot(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_LOT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_LOT", out_node);

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
	CWIP_VIEW_LOT()
		- Main sub function of "CWIP_View_Lot" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MWIPFLWDEF_TAG MWIPFLWDEF;
    struct MWIPOPRDEF_TAG MWIPOPRDEF;

    LOG_head("CWIP_VIEW_LOT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_View_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Get a Lot ID for current order, oper, and resource */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID), in_node, "ORDER_ID");
    TRS.copy(MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER), in_node, "OPER");
    TRS.copy(MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID), in_node, "RES_ID");
    TRS.copy(MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID), in_node, "RES_ID");

    DBC_select_mwiplotsts(101, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0044");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPLOTSTS.ORDER_ID), MWIPLOTSTS.ORDER_ID);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
            TRS.add_fieldmsg(out_node, "START_RES_ID", MP_STR, sizeof(MWIPLOTSTS.START_RES_ID), MWIPLOTSTS.START_RES_ID);
            TRS.add_fieldmsg(out_node, "END_RES_ID", MP_STR, sizeof(MWIPLOTSTS.END_RES_ID), MWIPLOTSTS.END_RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPLOTSTS.ORDER_ID), MWIPLOTSTS.ORDER_ID);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
            TRS.add_fieldmsg(out_node, "START_RES_ID", MP_STR, sizeof(MWIPLOTSTS.START_RES_ID), MWIPLOTSTS.START_RES_ID);
            TRS.add_fieldmsg(out_node, "END_RES_ID", MP_STR, sizeof(MWIPLOTSTS.END_RES_ID), MWIPLOTSTS.END_RES_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Get material data */
    DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
    MWIPMATDEF.MAT_VER = MWIPLOTSTS.MAT_VER;
    DBC_select_mwipmatdef(1, &MWIPMATDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        /* Error */
    }

    /* Get flow data */
    DBC_init_mwipflwdef(&MWIPFLWDEF);
    TRS.copy(MWIPFLWDEF.FACTORY, sizeof(MWIPFLWDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPFLWDEF.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPFLWDEF.FLOW));
    DBC_select_mwipflwdef(1, &MWIPFLWDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        /* Error */
    }

    /* Get operation data */
    DBC_init_mwipoprdef(&MWIPOPRDEF);
    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPOPRDEF.OPER));
    DBC_select_mwipoprdef(1, &MWIPOPRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        /* Error */
    }

    /* Construct out node */
    TRS.add_string(out_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    TRS.add_string(out_node, "LOT_DESC", MWIPLOTSTS.LOT_DESC, sizeof(MWIPLOTSTS.LOT_DESC));
    TRS.add_string(out_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
    TRS.add_string(out_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    TRS.add_int(out_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
    TRS.add_string(out_node, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
    TRS.add_string(out_node, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
    TRS.add_string(out_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
    TRS.add_int(out_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
    TRS.add_string(out_node, "FLOW_DESC", MWIPFLWDEF.FLOW_DESC, sizeof(MWIPFLWDEF.FLOW_DESC));
    TRS.add_string(out_node, "FLOW_SHORT_DESC", MWIPFLWDEF.FLOW_SHORT_DESC, sizeof(MWIPFLWDEF.FLOW_SHORT_DESC));
    TRS.add_string(out_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
    TRS.add_string(out_node, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
    TRS.add_string(out_node, "OPER_SHORT_DESC", MWIPOPRDEF.OPER_SHORT_DESC, sizeof(MWIPOPRDEF.OPER_SHORT_DESC));
    TRS.add_double(out_node, "QTY_1", MWIPLOTSTS.QTY_1);
    TRS.add_double(out_node, "QTY_2", MWIPLOTSTS.QTY_2);
    TRS.add_double(out_node, "QTY_3", MWIPLOTSTS.QTY_3);
    TRS.add_string(out_node, "CRR_ID", MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));

    TRS.add_char(out_node, "LOT_TYPE", MWIPLOTSTS.LOT_TYPE);
    TRS.add_string(out_node, "OWNER_CODE", MWIPLOTSTS.OWNER_CODE, sizeof(MWIPLOTSTS.OWNER_CODE));
    TRS.add_string(out_node, "CREATE_CODE", MWIPLOTSTS.CREATE_CODE, sizeof(MWIPLOTSTS.CREATE_CODE));
    TRS.add_char(out_node, "LOT_PRIORITY", MWIPLOTSTS.LOT_PRIORITY);
    TRS.add_string(out_node, "LOT_STATUS", MWIPLOTSTS.LOT_STATUS, sizeof(MWIPLOTSTS.LOT_STATUS));
    TRS.add_char(out_node, "HOLD_FLAG", MWIPLOTSTS.HOLD_FLAG);
    TRS.add_string(out_node, "HOLD_CODE", MWIPLOTSTS.HOLD_CODE, sizeof(MWIPLOTSTS.HOLD_CODE));
    TRS.add_string(out_node, "HOLD_PRV_GRP_ID", MWIPLOTSTS.HOLD_PRV_GRP_ID, sizeof(MWIPLOTSTS.HOLD_PRV_GRP_ID));
    TRS.add_enc_string(out_node, "HOLD_PASSWORD", MWIPLOTSTS.HOLD_PASSWORD, sizeof(MWIPLOTSTS.HOLD_PASSWORD));
    TRS.add_double(out_node, "OPER_IN_QTY_1", MWIPLOTSTS.OPER_IN_QTY_1);
    TRS.add_double(out_node, "OPER_IN_QTY_2", MWIPLOTSTS.OPER_IN_QTY_2);
    TRS.add_double(out_node, "OPER_IN_QTY_3", MWIPLOTSTS.OPER_IN_QTY_3);
    TRS.add_double(out_node, "CREATE_QTY_1", MWIPLOTSTS.CREATE_QTY_1);
    TRS.add_double(out_node, "CREATE_QTY_2", MWIPLOTSTS.CREATE_QTY_2);
    TRS.add_double(out_node, "CREATE_QTY_3", MWIPLOTSTS.CREATE_QTY_3);
    TRS.add_double(out_node, "START_QTY_1", MWIPLOTSTS.START_QTY_1);
    TRS.add_double(out_node, "START_QTY_2", MWIPLOTSTS.START_QTY_2);
    TRS.add_double(out_node, "START_QTY_3", MWIPLOTSTS.START_QTY_3);
    TRS.add_char(out_node, "INV_FLAG", MWIPLOTSTS.INV_FLAG);
    TRS.add_char(out_node, "TRANSIT_FLAG", MWIPLOTSTS.TRANSIT_FLAG);
    TRS.add_char(out_node, "UNIT_EXIST_FLAG", MWIPLOTSTS.UNIT_EXIST_FLAG);
    TRS.add_string(out_node, "INV_UNIT", MWIPLOTSTS.INV_UNIT, sizeof(MWIPLOTSTS.INV_UNIT));

    TRS.add_char(out_node, "RWK_FLAG", MWIPLOTSTS.RWK_FLAG);
    TRS.add_string(out_node, "RWK_CODE", MWIPLOTSTS.RWK_CODE, sizeof(MWIPLOTSTS.RWK_CODE));
    TRS.add_int(out_node, "RWK_COUNT", MWIPLOTSTS.RWK_COUNT);
    TRS.add_string(out_node, "RWK_RET_FLOW", MWIPLOTSTS.RWK_RET_FLOW, sizeof(MWIPLOTSTS.RWK_RET_FLOW));
    TRS.add_int(out_node, "RWK_RET_FLOW_SEQ_NUM", MWIPLOTSTS.RWK_RET_FLOW_SEQ_NUM);
    TRS.add_string(out_node, "RWK_RET_OPER", MWIPLOTSTS.RWK_RET_OPER, sizeof(MWIPLOTSTS.RWK_RET_OPER));
    TRS.add_string(out_node, "RWK_END_FLOW", MWIPLOTSTS.RWK_END_FLOW, sizeof(MWIPLOTSTS.RWK_END_FLOW));
    TRS.add_int(out_node, "RWK_END_FLOW_SEQ_NUM", MWIPLOTSTS.RWK_END_FLOW_SEQ_NUM);
    TRS.add_string(out_node, "RWK_END_OPER", MWIPLOTSTS.RWK_END_OPER, sizeof(MWIPLOTSTS.RWK_END_OPER));
    TRS.add_char(out_node, "RWK_RET_CLEAR_FLAG", MWIPLOTSTS.RWK_RET_CLEAR_FLAG);
    TRS.add_string(out_node, "RWK_TIME", MWIPLOTSTS.RWK_TIME, sizeof(MWIPLOTSTS.RWK_TIME));

    TRS.add_char(out_node, "NSTD_FLAG", MWIPLOTSTS.NSTD_FLAG);
    TRS.add_string(out_node, "NSTD_RET_FLOW", MWIPLOTSTS.NSTD_RET_FLOW, sizeof(MWIPLOTSTS.NSTD_RET_FLOW));
    TRS.add_int(out_node, "NSTD_RET_FLOW_SEQ_NUM", MWIPLOTSTS.NSTD_RET_FLOW_SEQ_NUM);
    TRS.add_string(out_node, "NSTD_RET_OPER", MWIPLOTSTS.NSTD_RET_OPER, sizeof(MWIPLOTSTS.NSTD_RET_OPER));
    TRS.add_string(out_node, "NSTD_TIME", MWIPLOTSTS.NSTD_TIME, sizeof(MWIPLOTSTS.NSTD_TIME));
    TRS.add_char(out_node, "REP_FLAG", MWIPLOTSTS.REP_FLAG);
    TRS.add_string(out_node, "REP_RET_OPER", MWIPLOTSTS.REP_RET_OPER, sizeof(MWIPLOTSTS.REP_RET_OPER));

    TRS.add_string(out_node, "STR_RET_FLOW", MWIPLOTSTS.STR_RET_FLOW, sizeof(MWIPLOTSTS.STR_RET_FLOW));
    TRS.add_int(out_node, "STR_RET_FLOW_SEQ_NUM", MWIPLOTSTS.STR_RET_FLOW_SEQ_NUM);
    TRS.add_string(out_node, "STR_RET_OPER", MWIPLOTSTS.STR_RET_OPER, sizeof(MWIPLOTSTS.STR_RET_OPER));

    TRS.add_char(out_node, "START_FLAG", MWIPLOTSTS.START_FLAG);
    TRS.add_string(out_node, "START_TIME", MWIPLOTSTS.START_TIME, sizeof(MWIPLOTSTS.START_TIME));
    TRS.add_string(out_node, "START_RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
    TRS.add_char(out_node, "END_FLAG", MWIPLOTSTS.END_FLAG);
    TRS.add_string(out_node, "END_TIME", MWIPLOTSTS.END_TIME, sizeof(MWIPLOTSTS.END_TIME));
    TRS.add_string(out_node, "END_RES_ID", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));

    TRS.add_char(out_node, "SAMPLE_FLAG", MWIPLOTSTS.SAMPLE_FLAG);
    TRS.add_char(out_node, "SAMPLE_WAIT_FLAG", MWIPLOTSTS.SAMPLE_WAIT_FLAG);
    TRS.add_char(out_node, "SAMPLE_RESULT", MWIPLOTSTS.SAMPLE_RESULT);
    TRS.add_char(out_node, "FROM_TO_FLAG", MWIPLOTSTS.FROM_TO_FLAG);
    TRS.add_string(out_node, "FROM_TO_LOT_ID", MWIPLOTSTS.FROM_TO_LOT_ID, sizeof(MWIPLOTSTS.FROM_TO_LOT_ID));
    TRS.add_string(out_node, "SHIP_CODE", MWIPLOTSTS.SHIP_CODE, sizeof(MWIPLOTSTS.SHIP_CODE));
    TRS.add_string(out_node, "SHIP_TIME", MWIPLOTSTS.SHIP_TIME, sizeof(MWIPLOTSTS.SHIP_TIME));
    TRS.add_string(out_node, "ORG_DUE_TIME", MWIPLOTSTS.ORG_DUE_TIME, sizeof(MWIPLOTSTS.ORG_DUE_TIME));
    TRS.add_string(out_node, "SCH_DUE_TIME", MWIPLOTSTS.SCH_DUE_TIME, sizeof(MWIPLOTSTS.SCH_DUE_TIME));
    TRS.add_string(out_node, "CREATE_TIME", MWIPLOTSTS.CREATE_TIME, sizeof(MWIPLOTSTS.CREATE_TIME));
    TRS.add_string(out_node, "FAC_IN_TIME", MWIPLOTSTS.FAC_IN_TIME, sizeof(MWIPLOTSTS.FAC_IN_TIME));
    TRS.add_string(out_node, "FLOW_IN_TIME", MWIPLOTSTS.FLOW_IN_TIME, sizeof(MWIPLOTSTS.FLOW_IN_TIME));
    TRS.add_string(out_node, "OPER_IN_TIME", MWIPLOTSTS.OPER_IN_TIME, sizeof(MWIPLOTSTS.OPER_IN_TIME));
    TRS.add_string(out_node, "RESERVE_RES_ID", MWIPLOTSTS.RESERVE_RES_ID, sizeof(MWIPLOTSTS.RESERVE_RES_ID));
    TRS.add_string(out_node, "PORT_ID", MWIPLOTSTS.PORT_ID, sizeof(MWIPLOTSTS.PORT_ID));

    TRS.add_string(out_node, "ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
    TRS.add_string(out_node, "ADD_ORDER_ID_1", MWIPLOTSTS.ADD_ORDER_ID_1, sizeof(MWIPLOTSTS.ADD_ORDER_ID_1));
    TRS.add_string(out_node, "ADD_ORDER_ID_2", MWIPLOTSTS.ADD_ORDER_ID_2, sizeof(MWIPLOTSTS.ADD_ORDER_ID_2));
    TRS.add_string(out_node, "ADD_ORDER_ID_3", MWIPLOTSTS.ADD_ORDER_ID_3, sizeof(MWIPLOTSTS.ADD_ORDER_ID_3));
    TRS.add_string(out_node, "LOT_LOCATION_1", MWIPLOTSTS.LOT_LOCATION_1, sizeof(MWIPLOTSTS.LOT_LOCATION_1));
    TRS.add_string(out_node, "LOT_LOCATION_2", MWIPLOTSTS.LOT_LOCATION_2, sizeof(MWIPLOTSTS.LOT_LOCATION_2));
    TRS.add_string(out_node, "LOT_LOCATION_3", MWIPLOTSTS.LOT_LOCATION_3, sizeof(MWIPLOTSTS.LOT_LOCATION_3));
    TRS.add_string(out_node, "LOT_CMF_1", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
    TRS.add_string(out_node, "LOT_CMF_2", MWIPLOTSTS.LOT_CMF_2, sizeof(MWIPLOTSTS.LOT_CMF_2));
    TRS.add_string(out_node, "LOT_CMF_3", MWIPLOTSTS.LOT_CMF_3, sizeof(MWIPLOTSTS.LOT_CMF_3));
    TRS.add_string(out_node, "LOT_CMF_4", MWIPLOTSTS.LOT_CMF_4, sizeof(MWIPLOTSTS.LOT_CMF_4));
    TRS.add_string(out_node, "LOT_CMF_5", MWIPLOTSTS.LOT_CMF_5, sizeof(MWIPLOTSTS.LOT_CMF_5));
    TRS.add_string(out_node, "LOT_CMF_6", MWIPLOTSTS.LOT_CMF_6, sizeof(MWIPLOTSTS.LOT_CMF_6));
    TRS.add_string(out_node, "LOT_CMF_7", MWIPLOTSTS.LOT_CMF_7, sizeof(MWIPLOTSTS.LOT_CMF_7));
    TRS.add_string(out_node, "LOT_CMF_8", MWIPLOTSTS.LOT_CMF_8, sizeof(MWIPLOTSTS.LOT_CMF_8));
    TRS.add_string(out_node, "LOT_CMF_9", MWIPLOTSTS.LOT_CMF_9, sizeof(MWIPLOTSTS.LOT_CMF_9));
    TRS.add_string(out_node, "LOT_CMF_10", MWIPLOTSTS.LOT_CMF_10, sizeof(MWIPLOTSTS.LOT_CMF_10));
    TRS.add_string(out_node, "LOT_CMF_11", MWIPLOTSTS.LOT_CMF_11, sizeof(MWIPLOTSTS.LOT_CMF_11));
    TRS.add_string(out_node, "LOT_CMF_12", MWIPLOTSTS.LOT_CMF_12, sizeof(MWIPLOTSTS.LOT_CMF_12));
    TRS.add_string(out_node, "LOT_CMF_13", MWIPLOTSTS.LOT_CMF_13, sizeof(MWIPLOTSTS.LOT_CMF_13));
    TRS.add_string(out_node, "LOT_CMF_14", MWIPLOTSTS.LOT_CMF_14, sizeof(MWIPLOTSTS.LOT_CMF_14));
    TRS.add_string(out_node, "LOT_CMF_15", MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
    TRS.add_string(out_node, "LOT_CMF_16", MWIPLOTSTS.LOT_CMF_16, sizeof(MWIPLOTSTS.LOT_CMF_16));
    TRS.add_string(out_node, "LOT_CMF_17", MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17));
    TRS.add_string(out_node, "LOT_CMF_18", MWIPLOTSTS.LOT_CMF_18, sizeof(MWIPLOTSTS.LOT_CMF_18));
    TRS.add_string(out_node, "LOT_CMF_19", MWIPLOTSTS.LOT_CMF_19, sizeof(MWIPLOTSTS.LOT_CMF_19));
    TRS.add_string(out_node, "LOT_CMF_20", MWIPLOTSTS.LOT_CMF_20, sizeof(MWIPLOTSTS.LOT_CMF_20));
    TRS.add_char(out_node, "LOT_DEL_FLAG", MWIPLOTSTS.LOT_DEL_FLAG);
    TRS.add_string(out_node, "LOT_DEL_CODE", MWIPLOTSTS.LOT_DEL_CODE, sizeof(MWIPLOTSTS.LOT_DEL_CODE));
    TRS.add_string(out_node, "LOT_DEL_TIME", MWIPLOTSTS.LOT_DEL_TIME, sizeof(MWIPLOTSTS.LOT_DEL_TIME));
    TRS.add_string(out_node, "LAST_TRAN_CODE", MWIPLOTSTS.LAST_TRAN_CODE, sizeof(MWIPLOTSTS.LAST_TRAN_CODE));
    TRS.add_string(out_node, "LAST_TRAN_TIME", MWIPLOTSTS.LAST_TRAN_TIME, sizeof(MWIPLOTSTS.LAST_TRAN_TIME));
    TRS.add_string(out_node, "LAST_COMMENT", MWIPLOTSTS.LAST_COMMENT, sizeof(MWIPLOTSTS.LAST_COMMENT));
    TRS.add_int(out_node, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
    TRS.add_int(out_node, "LAST_HIST_SEQ", MWIPLOTSTS.LAST_HIST_SEQ);
    TRS.add_string(out_node, "BOM_SET_ID", MWIPLOTSTS.BOM_SET_ID, sizeof(MWIPLOTSTS.BOM_SET_ID));
    TRS.add_int(out_node, "BOM_SET_VERSION", MWIPLOTSTS.BOM_SET_VERSION);
    TRS.add_int(out_node, "BOM_HIST_SEQ", MWIPLOTSTS.BOM_HIST_SEQ);
    TRS.add_int(out_node, "BOM_ACTIVE_HIST_SEQ", MWIPLOTSTS.BOM_ACTIVE_HIST_SEQ);

    TRS.add_string(out_node, "CRITICAL_RES_ID", MWIPLOTSTS.CRITICAL_RES_ID, sizeof(MWIPLOTSTS.CRITICAL_RES_ID));
    TRS.add_string(out_node, "CRITICAL_RES_GROUP_ID", MWIPLOTSTS.CRITICAL_RES_GROUP_ID, sizeof(MWIPLOTSTS.CRITICAL_RES_GROUP_ID));
    TRS.add_string(out_node, "SAVE_RES_ID_1", MWIPLOTSTS.SAVE_RES_ID_1, sizeof(MWIPLOTSTS.SAVE_RES_ID_1));
    TRS.add_string(out_node, "SAVE_RES_ID_2", MWIPLOTSTS.SAVE_RES_ID_2, sizeof(MWIPLOTSTS.SAVE_RES_ID_2));
    TRS.add_string(out_node, "SUBRES_ID", MWIPLOTSTS.SUBRES_ID, sizeof(MWIPLOTSTS.SUBRES_ID));
    TRS.add_string(out_node, "LOT_GROUP_ID_1", MWIPLOTSTS.LOT_GROUP_ID_1, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
    TRS.add_string(out_node, "LOT_GROUP_ID_2", MWIPLOTSTS.LOT_GROUP_ID_2, sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
    TRS.add_string(out_node, "LOT_GROUP_ID_3", MWIPLOTSTS.LOT_GROUP_ID_3, sizeof(MWIPLOTSTS.LOT_GROUP_ID_3));

    TRS.add_double(out_node, "YIELD_1", MWIPLOTSTS.YIELD_1);
    TRS.add_double(out_node, "YIELD_2", MWIPLOTSTS.YIELD_2);
    TRS.add_double(out_node, "YIELD_3", MWIPLOTSTS.YIELD_3);
    TRS.add_double(out_node, "GOOD_QTY", MWIPLOTSTS.GOOD_QTY);

    TRS.add_string(out_node, "RESV_FIELD_1", MWIPLOTSTS.RESV_FIELD_1, sizeof(MWIPLOTSTS.RESV_FIELD_1));
    TRS.add_string(out_node, "RESV_FIELD_2", MWIPLOTSTS.RESV_FIELD_2, sizeof(MWIPLOTSTS.RESV_FIELD_2));
    TRS.add_string(out_node, "RESV_FIELD_3", MWIPLOTSTS.RESV_FIELD_3, sizeof(MWIPLOTSTS.RESV_FIELD_3));
    TRS.add_string(out_node, "RESV_FIELD_4", MWIPLOTSTS.RESV_FIELD_4, sizeof(MWIPLOTSTS.RESV_FIELD_4));
    TRS.add_string(out_node, "RESV_FIELD_5", MWIPLOTSTS.RESV_FIELD_5, sizeof(MWIPLOTSTS.RESV_FIELD_5));
    TRS.add_char(out_node, "RESV_FLAG_1", MWIPLOTSTS.RESV_FLAG_1);
    TRS.add_char(out_node, "RESV_FLAG_2", MWIPLOTSTS.RESV_FLAG_2);
    TRS.add_char(out_node, "RESV_FLAG_3", MWIPLOTSTS.RESV_FLAG_3);
    TRS.add_char(out_node, "RESV_FLAG_4", MWIPLOTSTS.RESV_FLAG_4);
    TRS.add_char(out_node, "RESV_FLAG_5", MWIPLOTSTS.RESV_FLAG_5);

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Lot_Validation()
		- Main sub function of "CWIP_VIEW_LOT" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Lot_Validation(char *s_msg_code,
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