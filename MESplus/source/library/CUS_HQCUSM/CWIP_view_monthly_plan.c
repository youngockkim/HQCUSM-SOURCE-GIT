/*******************************************************************************

    System      : MESplus
    Module      : CWIP_View_Monthly_Plan
    File Name   : CWIP_View_Monthly_Plan.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.3.13  YS KIM

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include "CUS_HQCUSM_common.h"

int CWIP_View_Monthly_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_View_Monthly_Plan()
        - View_FullCell_Cart_Label
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Monthly_Plan(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_MONTHLY_PLAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Monthly_Plan", out_node);

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
    CWIP_VIEW_MONTHLY_PLAN()
        - VIEW_FULLCELL_CART_LABEL
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_MONTHLY_PLAN(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	struct MWIPLOTSTS_TAG MWIPLOTSTS;

	char s_sys_time[14];
	TRSNode *list_item;
    int i_step;
	  
	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_PACKING_LABEL_PRINT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Ordered by Magazine ID
    */

    if(CWIP_View_Monthly_Plan_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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
        return MP_FALSE;
    }
	
	if (TRS.get_procstep(in_node) == '1')
	{
		i_step = 100;
	}
	else
	{
		return MP_FALSE;
	}

	CDB_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);    
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "WORK_MONTH");

	CDB_open_mwiplotsts(i_step,&MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
            strcpy(s_msg_code, "BOM-0042");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_MONTH", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_MONTH", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

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
        CDB_fetch_mwiplotsts(i_step, &MWIPLOTSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_mgcmtbldat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        { 
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_MONTH", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_mgcmtbldat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		       
        /* Construct out node */
		
		list_item = TRS.add_node(out_node, "LIST");
		TRS.add_string(list_item, "MDL01_PLAN_EL_QTY", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(list_item, "MDL01_PLAN_FQC_QTY", MWIPLOTSTS.LOT_DESC, sizeof(MWIPLOTSTS.LOT_DESC));
		TRS.add_string(list_item, "MDL01_PLAN_FQC_MW", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		TRS.add_string(list_item, "MDL01_PLAN_YIELD", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_string(list_item, "MDL01_B_PLAN_EL_QTY", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_string(list_item, "MDL01_B_PLAN_FQC_QTY", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		TRS.add_string(list_item, "MDL01_B_PLAN_FQC_MW", MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
		TRS.add_string(list_item, "MDL01_B_PLAN_YIELD", MWIPLOTSTS.OWNER_CODE, sizeof(MWIPLOTSTS.OWNER_CODE));
		TRS.add_string(list_item, "MDL02_PLAN_EL_QTY", MWIPLOTSTS.CREATE_CODE, sizeof(MWIPLOTSTS.CREATE_CODE));
		TRS.add_string(list_item, "MDL02_PLAN_FQC_QTY", MWIPLOTSTS.LOT_STATUS, sizeof(MWIPLOTSTS.LOT_STATUS));
		TRS.add_string(list_item, "MDL02_PLAN_FQC_MW", MWIPLOTSTS.HOLD_CODE, sizeof(MWIPLOTSTS.HOLD_CODE));
		TRS.add_string(list_item, "MDL02_PLAN_YIELD", MWIPLOTSTS.HOLD_PASSWORD, sizeof(MWIPLOTSTS.HOLD_PASSWORD));
		TRS.add_string(list_item, "MDL02_B_PLAN_EL_QTY", MWIPLOTSTS.HOLD_PRV_GRP_ID, sizeof(MWIPLOTSTS.HOLD_PRV_GRP_ID));
		TRS.add_string(list_item, "MDL02_B_PLAN_FQC_QTY", MWIPLOTSTS.INV_UNIT, sizeof(MWIPLOTSTS.INV_UNIT));
		TRS.add_string(list_item, "MDL02_B_PLAN_FQC_MW", MWIPLOTSTS.RWK_CODE, sizeof(MWIPLOTSTS.RWK_CODE));
		TRS.add_string(list_item, "MDL02_B_PLAN_YIELD", MWIPLOTSTS.RWK_RET_FLOW, sizeof(MWIPLOTSTS.RWK_RET_FLOW));
		TRS.add_string(list_item, "MDL03_PLAN_EL_QTY", MWIPLOTSTS.RWK_RET_OPER, sizeof(MWIPLOTSTS.RWK_RET_OPER));
		TRS.add_string(list_item, "MDL03_PLAN_FQC_QTY", MWIPLOTSTS.RWK_END_FLOW, sizeof(MWIPLOTSTS.RWK_END_FLOW));
		TRS.add_string(list_item, "MDL03_PLAN_FQC_MW", MWIPLOTSTS.RWK_END_OPER, sizeof(MWIPLOTSTS.RWK_END_OPER));
		TRS.add_string(list_item, "MDL03_PLAN_YIELD", MWIPLOTSTS.RWK_TIME, sizeof(MWIPLOTSTS.RWK_TIME));
		TRS.add_string(list_item, "MDL03_B_PLAN_EL_QTY", MWIPLOTSTS.NSTD_RET_FLOW, sizeof(MWIPLOTSTS.NSTD_RET_FLOW));
		TRS.add_string(list_item, "MDL03_B_PLAN_FQC_QTY", MWIPLOTSTS.NSTD_RET_OPER, sizeof(MWIPLOTSTS.NSTD_RET_OPER));
		TRS.add_string(list_item, "MDL03_B_PLAN_FQC_MW", MWIPLOTSTS.NSTD_TIME, sizeof(MWIPLOTSTS.NSTD_TIME));
		TRS.add_string(list_item, "MDL03_B_PLAN_YIELD", MWIPLOTSTS.REP_RET_OPER, sizeof(MWIPLOTSTS.REP_RET_OPER));
		TRS.add_string(list_item, "SUM_PLAN_EL_QTY", MWIPLOTSTS.STR_RET_FLOW, sizeof(MWIPLOTSTS.STR_RET_FLOW));
		TRS.add_string(list_item, "SUM_PLAN_FQC_QTY", MWIPLOTSTS.STR_RET_OPER, sizeof(MWIPLOTSTS.STR_RET_OPER));
		TRS.add_string(list_item, "SUM_PLAN_FQC_MW", MWIPLOTSTS.START_TIME, sizeof(MWIPLOTSTS.START_TIME));
		TRS.add_string(list_item, "SUM_PLAN_YIELD", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
		TRS.add_string(list_item, "SUM_B_PLAN_EL_QTY", MWIPLOTSTS.END_TIME, sizeof(MWIPLOTSTS.END_TIME));
		TRS.add_string(list_item, "SUM_B_PLAN_FQC_QTY", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));
		TRS.add_string(list_item, "SUM_B_PLAN_FQC_MW", MWIPLOTSTS.FROM_TO_LOT_ID, sizeof(MWIPLOTSTS.FROM_TO_LOT_ID));
		TRS.add_string(list_item, "SUM_B_PLAN_YIELD", MWIPLOTSTS.SHIP_CODE, sizeof(MWIPLOTSTS.SHIP_CODE));
		TRS.add_string(list_item, "WORK_DAY", MWIPLOTSTS.ORG_DUE_TIME, sizeof(MWIPLOTSTS.ORG_DUE_TIME));
		TRS.add_string(list_item, "WORK_DATE", MWIPLOTSTS.SHIP_TIME, sizeof(MWIPLOTSTS.SHIP_TIME));

		
    }
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
	CWIP_View_Monthly_Plan_Validation()
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Monthly_Plan_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
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
        strcpy(s_msg_code, "WIP-0001");
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