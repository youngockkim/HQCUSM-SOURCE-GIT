/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_adapt_lot.c
    Description : Adapt Lot transaction function module

    MES Version : 4.0.0

    Function List
        - TIV_ADAPT_LOT()
            + Adapt Lot
        - TIV_ADAPT_LOT()
            + Main sub function of "TIV_ADAPT_LOT" function
            + Adapt Lot definition
        - TIV_Adapt_Lot_Validation()
            + Validation Check sub function of "TIV_ADAPT_LOT" function
            + Check the conditions before Adapt Lot definition
        - TIV_check_lot_cmf_adapt_lot()
            + Check the Conditions before Adapt Lot CMF Definition

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/16  Laverwon       Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"
 

#ifdef _RAS
#include <RASCore_common.h>
#endif /* _RAS */

int TIV_Adapt_Lot_Fill_InTag(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node);

int TIV_Adapt_Lot_Validation(char *s_msg_code,
                             TRSNode *in_node,
                             TRSNode *out_node);

int TIV_check_lot_cmf_adapt_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node);

int TIV_Adapt_Sublot_Proc(char *s_msg_code,
                          TRSNode *in_node,
                          TRSNode *out_node);

int TIV_call_adapt_sublot(char *s_msg_code,
                          TRSNode *Sublot_In,
                          TRSNode *out_node);

#ifdef _CRR
int TIV_Adapt_Carrier_Proc(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node,
                           struct MTIVLOTHIS_TAG *MTIVLOTHIS);

int TIV_Adapt_Lot_Terminate_Carrier(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node);
#endif /* _CRR */

int TIV_Adapt_Change_Port_Status(char *s_msg_code,
                                 TRSNode *in_node,
                                 struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                 struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                 TRSNode *out_node);

/*******************************************************************************
    TIV_Adapt_Lot()
        - Adapt Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_ADAPT_LOT_IN_TAG *Adapt_Lot_In : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Adapt_Lot(TRSNode *in_node,
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

#ifdef _ALM
    /* Save Factory, res_id, lot_id , ...for alarm */
    TRS.copy(gs_alm_factory, sizeof(gs_alm_factory), in_node, IN_FACTORY);
    TRS.copy(gs_alm_user_id, sizeof(gs_alm_user_id), in_node, IN_USERID);
    TRS.copy(gs_alm_lot_id, sizeof(gs_alm_lot_id), in_node, "LOT_ID");
    /* TRS.copy(gs_alm_res_id, sizeof(gs_alm_res_id), in_node, "RES_ID"); */
    TRS.copy(gs_alm_source_id, sizeof(gs_alm_source_id), in_node, "LOT_ID");
    memcpy(gs_alm_module, MP_TRAN_CODE_ADAPT, strlen(MP_TRAN_CODE_ADAPT));
#endif /* _ALM */

    i_ret = TIV_ADAPT_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_ADAPT_LOT", out_node);

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
    TIV_ADAPT_LOT()
        - Main sub function of "TIV_ADAPT_LOT" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_ADAPT_LOT(char *s_msg_code,
                     TRSNode *in_node,
                     TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;

    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    //struct MWIPLOTRDS_TAG MWIPLOTRDS;

    char s_sys_time[14];
    char s_tran_time[14];
	char s_erp_tran_time[14];

	int i_last_active_hist_seq;
	int i_step;
    
	TRSNode * IF_node;

    //Add by J.S. 2011.05.18
    //char c_rework_insert_flag;
    //struct MWIPLOTRWK_TAG MWIPLOTRWK;
    //End Add

    LOG_head("TIV_ADAPT_LOT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("back_time", MP_NSTR, TRS.get_string(in_node, "BACK_TIME"));
    LOG_add("inv_lot_id", MP_NSTR, TRS.get_string(in_node, "TIV_LOT_ID"));
    LOG_add("last_active_lot_qrp_seq", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    
    LOG_add("lot_desc", MP_NSTR, TRS.get_string(in_node,"LOT_DESC"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node,"MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node,"MAT_VER"));
    LOG_add("to_mat_id", MP_NSTR, TRS.get_string(in_node,"TO_MAT_ID"));
    LOG_add("to_mat_ver", MP_INT, TRS.get_int(in_node,"TO_MAT_VER"));
    LOG_add("lot_type", MP_CHR, TRS.get_char(in_node,"LOT_TYPE"));
    LOG_add("qty_1", MP_DBL, TRS.get_double(in_node,"QTY_1"));
    LOG_add("qty_2", MP_DBL, TRS.get_double(in_node,"QTY_2"));
    LOG_add("qty_3", MP_DBL, TRS.get_double(in_node,"QTY_3"));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node,"ORDER_ID"));
    LOG_add("line_no", MP_NSTR, TRS.get_string(in_node,"LINE_NO"));
    LOG_add("location_no", MP_NSTR, TRS.get_string(in_node,"LOCATION_NO"));
    LOG_add("grade", MP_NSTR, TRS.get_string(in_node,"GRADE_CODE"));
    LOG_add("add_order_id_1", MP_NSTR, TRS.get_string(in_node,"ADD_ORDER_ID_1"));
    LOG_add("add_order_line_1", MP_NSTR, TRS.get_string(in_node,"ADD_ORDER_LINE_1"));
    LOG_add("add_order_id_2", MP_NSTR, TRS.get_string(in_node,"ADD_ORDER_ID_2"));
    LOG_add("add_order_line_2", MP_NSTR, TRS.get_string(in_node,"ADD_ORDER_LINE_2"));
    LOG_add("add_order_id_3", MP_NSTR, TRS.get_string(in_node,"ADD_ORDER_ID_3"));
    LOG_add("add_order_line_3", MP_NSTR, TRS.get_string(in_node,"ADD_ORDER_LINE_3"));
    LOG_add("vendor_lot_id", MP_NSTR, TRS.get_string(in_node,"VENDOR_LOT_ID"));
    LOG_add("po_mat_id", MP_NSTR, TRS.get_string(in_node,"PO_MAT_ID"));
    LOG_add("po_seq_num", MP_INT, TRS.get_int(in_node,"PO_SEQ_NUM"));
    LOG_add("inv_cmf_1", MP_NSTR, TRS.get_string(in_node,"INV_CMF_1"));
    LOG_add("inv_cmf_2", MP_NSTR, TRS.get_string(in_node,"INV_CMF_2"));
    LOG_add("inv_cmf_3", MP_NSTR, TRS.get_string(in_node,"INV_CMF_3"));
    LOG_add("inv_cmf_4", MP_NSTR, TRS.get_string(in_node,"INV_CMF_4"));
    LOG_add("inv_cmf_5", MP_NSTR, TRS.get_string(in_node,"INV_CMF_5"));
    LOG_add("inv_cmf_6", MP_NSTR, TRS.get_string(in_node,"INV_CMF_6"));
    LOG_add("inv_cmf_7", MP_NSTR, TRS.get_string(in_node,"INV_CMF_7"));
    LOG_add("inv_cmf_8", MP_NSTR, TRS.get_string(in_node,"INV_CMF_8"));
    LOG_add("inv_cmf_9", MP_NSTR, TRS.get_string(in_node,"INV_CMF_9"));
    LOG_add("inv_cmf_10", MP_NSTR, TRS.get_string(in_node,"INV_CMF_10"));
    LOG_add("inv_cmf_11", MP_NSTR, TRS.get_string(in_node,"INV_CMF_11"));
    LOG_add("inv_cmf_12", MP_NSTR, TRS.get_string(in_node,"INV_CMF_12"));
    LOG_add("inv_cmf_13", MP_NSTR, TRS.get_string(in_node,"INV_CMF_13"));
    LOG_add("inv_cmf_14", MP_NSTR, TRS.get_string(in_node,"INV_CMF_14"));
    LOG_add("inv_cmf_15", MP_NSTR, TRS.get_string(in_node,"INV_CMF_15"));
    LOG_add("inv_cmf_16", MP_NSTR, TRS.get_string(in_node,"INV_CMF_16"));
    LOG_add("inv_cmf_17", MP_NSTR, TRS.get_string(in_node,"INV_CMF_17"));
    LOG_add("inv_cmf_18", MP_NSTR, TRS.get_string(in_node,"INV_CMF_18"));
    LOG_add("inv_cmf_19", MP_NSTR, TRS.get_string(in_node,"INV_CMF_19"));
    LOG_add("inv_cmf_20", MP_NSTR, TRS.get_string(in_node,"INV_CMF_20"));
    LOG_add("owner_code", MP_NSTR, TRS.get_string(in_node,"OWNER_CODE"));
    LOG_add("vendor_id", MP_NSTR, TRS.get_string(in_node,"VENDOR_ID"));
    
    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
    LOG_add("no_automatic_terminate_lot", MP_CHR, TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Adapt_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memset(s_tran_time, ' ', sizeof(s_tran_time));
	memset(s_erp_tran_time, ' ', sizeof(s_erp_tran_time));
	
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    } 

	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");

    if(TIV_Adapt_Lot_Fill_InTag(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Validation Check */
    if(TIV_Adapt_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Get TransTime */
    if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
    {
        memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
    }
    else
    {
        TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");    
	TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "TIV_OPER");
    DBC_select_mtivlotsts(4, &MTIVLOTSTS_OLD);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0044");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }     
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

    TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "TO_MAT_ID");
    MTIVLOTSTS.MAT_VER = TRS.get_int(in_node, "TO_MAT_VER");
    TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TO_OPER");
    MTIVLOTSTS.LOT_TYPE = TRS.get_char(in_node, "LOT_TYPE");
    TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), in_node,"ORDER_ID");
    TRS.copy(MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO), in_node,"LINE_NO");   
    //TRS.copy(MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO), in_node,"LOCATION_NO");   
    //TRS.copy(MTIVLOTSTS.GRADE, sizeof(MTIVLOTSTS.GRADE), in_node,"GRADE_CODE");
    //TRS.copy(MTIVLOTSTS.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS.ADD_ORDER_ID_1), in_node,"ADD_ORDER_ID_1");
    //TRS.copy(MTIVLOTSTS.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_1), in_node,"ADD_ORDER_LINE_1");   
    //TRS.copy(MTIVLOTSTS.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS.ADD_ORDER_ID_2), in_node,"ADD_ORDER_ID_2");   
    //TRS.copy(MTIVLOTSTS.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_2), in_node,"ADD_ORDER_LINE_2");   
    //TRS.copy(MTIVLOTSTS.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS.ADD_ORDER_ID_3), in_node,"ADD_ORDER_ID_3");   
    //TRS.copy(MTIVLOTSTS.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_3), in_node,"ADD_ORDER_LINE_3");   
    //TRS.copy(MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID), in_node,"VENDOR_LOT_ID");   
    //TRS.copy(MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID), in_node,"PO_MAT_ID");   
    //MTIVLOTSTS.PO_SEQ_NUM = TRS.get_int(in_node, "PO_SEQ_NUM");

    TRS.copy(MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1), in_node, "UNIT_1");
    /*TRS.copy(MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2), in_node, "UNIT_2");
    TRS.copy(MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3), in_node, "UNIT_3");*/

    //TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node,"INV_CMF_1");
    TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2), in_node,"INV_CMF_2");   
    TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3), in_node,"INV_CMF_3");   
    TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4), in_node,"INV_CMF_4");   
    TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5), in_node,"INV_CMF_5");
    TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6), in_node,"INV_CMF_6");   
    TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7), in_node,"INV_CMF_7");   
    TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8), in_node,"INV_CMF_8");   
    TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9), in_node,"INV_CMF_9");   
    TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10), in_node,"INV_CMF_10");   
    TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11), in_node,"INV_CMF_11");   
    TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12), in_node,"INV_CMF_12");   
    TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13), in_node,"INV_CMF_13");   
    TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14), in_node,"INV_CMF_14");   
    TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15), in_node,"INV_CMF_15");   
    TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16), in_node,"INV_CMF_16");   
    TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17), in_node,"INV_CMF_17");   
    TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18), in_node,"INV_CMF_18");   
    TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19), in_node,"INV_CMF_19");   
    TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20), in_node,"INV_CMF_20");   
    TRS.copy(MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE), in_node,"OWNER_CODE");   
	TRS.copy(MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE), in_node,"EXPIRE_DATE");  

	TRS.copy(MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE), in_node, "CREATE_CODE");
    TRS.copy(MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21), in_node, "INV_CMF_21");
    TRS.copy(MTIVLOTSTS.INV_CMF_22, sizeof(MTIVLOTSTS.INV_CMF_22), in_node, "INV_CMF_22");
    TRS.copy(MTIVLOTSTS.INV_CMF_23, sizeof(MTIVLOTSTS.INV_CMF_23), in_node, "INV_CMF_23");
    TRS.copy(MTIVLOTSTS.INV_CMF_24, sizeof(MTIVLOTSTS.INV_CMF_24), in_node, "INV_CMF_24");
    TRS.copy(MTIVLOTSTS.INV_CMF_25, sizeof(MTIVLOTSTS.INV_CMF_25), in_node, "INV_CMF_25");
    TRS.copy(MTIVLOTSTS.INV_CMF_26, sizeof(MTIVLOTSTS.INV_CMF_26), in_node, "INV_CMF_26");
    TRS.copy(MTIVLOTSTS.INV_CMF_27, sizeof(MTIVLOTSTS.INV_CMF_27), in_node, "INV_CMF_27");
    TRS.copy(MTIVLOTSTS.INV_CMF_28, sizeof(MTIVLOTSTS.INV_CMF_28), in_node, "INV_CMF_28");
    TRS.copy(MTIVLOTSTS.INV_CMF_29, sizeof(MTIVLOTSTS.INV_CMF_29), in_node, "INV_CMF_29");
    TRS.copy(MTIVLOTSTS.INV_CMF_30, sizeof(MTIVLOTSTS.INV_CMF_30), in_node, "INV_CMF_30");
    MTIVLOTSTS.INV_FLAG_1 = TRS.get_char(in_node, "INV_FLAG_1");
    MTIVLOTSTS.INV_FLAG_2 = TRS.get_char(in_node, "INV_FLAG_2");
    MTIVLOTSTS.INV_FLAG_3 = TRS.get_char(in_node, "INV_FLAG_3");
    MTIVLOTSTS.INV_FLAG_4 = TRS.get_char(in_node, "INV_FLAG_4");
    MTIVLOTSTS.INV_FLAG_5 = TRS.get_char(in_node, "INV_FLAG_5");
    TRS.copy(MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE), in_node, "ERP_CREATE_DATE");
    TRS.copy(MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE), in_node, "ERP_INV_IN_DATE");
    TRS.copy(MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE), in_node, "ERP_OINV_IN_DATE");
    TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "ERP_LAST_TRAN_DATE");
    TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");


    //TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), in_node,"VENDOR_ID"); 
    
    MTIVLOTSTS.QTY_1 = 0;
    MTIVLOTSTS.QTY_2 = 0;
    MTIVLOTSTS.QTY_3 = 0;

    DBC_init_mtivoprdef(&MTIVOPRDEF);
    memcpy(MTIVOPRDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
    memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));
    DBC_select_mtivoprdef(1, &MTIVOPRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }     
        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

   
    /* Qty1 Check */
    if(COM_isspace(MTIVOPRDEF.UNIT_1, sizeof(MTIVOPRDEF.UNIT_1)) == MP_FALSE)
    {
        if(TRS.get_double(in_node, "QTY_1") < -0.0005)
        {
            strcpy(s_msg_code, "WIP-0041");
            TRS.add_fieldmsg(out_node, "QTY_1_UNIT", MP_STR, sizeof(MTIVOPRDEF.UNIT_1), MTIVOPRDEF.UNIT_1);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        MTIVLOTSTS.QTY_1 = TRS.get_double(in_node, "QTY_1");
    }

    /* Qty2 Check */
    if(COM_isspace(MTIVOPRDEF.UNIT_2, sizeof(MTIVOPRDEF.UNIT_2)) == MP_FALSE)
    {
        if(TRS.get_double(in_node, "QTY_2") < -0.0005)
        {
            strcpy(s_msg_code, "WIP-0041");
            TRS.add_fieldmsg(out_node, "QTY_2_UNIT", MP_STR, sizeof(MTIVOPRDEF.UNIT_2), MTIVOPRDEF.UNIT_2);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        MTIVLOTSTS.QTY_2 = TRS.get_double(in_node, "QTY_2");
    }

    /* Qty3 Check */
    if(COM_isspace(MTIVOPRDEF.UNIT_3, sizeof(MTIVOPRDEF.UNIT_3)) == MP_FALSE)
    {
        if(TRS.get_double(in_node, "QTY_3") < -0.0005)
        {
            strcpy(s_msg_code, "WIP-0041");
            TRS.add_fieldmsg(out_node, "QTY_3_UNIT", MP_STR, sizeof(MTIVOPRDEF.UNIT_3), MTIVOPRDEF.UNIT_3);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        MTIVLOTSTS.QTY_3 = TRS.get_double(in_node, "QTY_3");
    }

    /* 2005.10.13. CM Koo. 0.00009에서 0.0005로 범위를 확대함. */
    //if(MTIVLOTSTS.QTY_1 < 0.00009 && MTIVLOTSTS.QTY_2 < 0.00009)
    if(MTIVLOTSTS.QTY_1 < 0.0005 && MTIVLOTSTS.QTY_2 < 0.0005)
    {
        if(TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT") != 'Y')
        {
            MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
            TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, "PRC_USER");
            memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
            memcpy(MTIVLOTSTS.LOT_DEL_REASON, "QTY_ZERO", strlen("QTY_ZERO"));
        }
    }
    else
    {
        MTIVLOTSTS.LOT_DEL_FLAG = ' ';
        memset(MTIVLOTSTS.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
        memset(MTIVLOTSTS.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS.LOT_DEL_TIME));
        memset(MTIVLOTSTS.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS.LOT_DEL_REASON));
    }

    if(TRS.get_char(in_node, "LOT_DEL_FLAG")=='Y')
    {
        MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
        TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, "PRC_USER");
        memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
        memcpy(MTIVLOTSTS.LOT_DEL_REASON, "QTY_ZERO", strlen("QTY_ZERO"));
    }

    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_ADAPT, strlen(MP_INV_TRAN_CODE_ADAPT));

	if (COM_isnullspace(TRS.get_string(in_node, "TRAN_TYPE")) == MP_TRUE)
		memset(MTIVLOTSTS.LAST_TRAN_TYPE, ' ', sizeof(MTIVLOTSTS.LAST_TRAN_TYPE)); 
	else
		TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");       

    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");       
	memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	i_step = 10;
	i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS);
	 
	MTIVLOTSTS.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

    memcpy(MTIVLOTSTS.OPER,TRS.get_string(in_node, "TO_OPER"),strlen(TRS.get_string(in_node, "TO_OPER")));
    memcpy(MTIVLOTSTS.LOCATION_NO, TRS.get_string(in_node, "LOCATION_NO"), strlen(TRS.get_string(in_node, "LOCATION_NO")));

    TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");


	/* History Insert */
    DBC_init_mtivlothis(&MTIVLOTHIS);

	TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

	


    if(TIV_update_insert_lot_status_history_for_adapt(s_msg_code,
                                            in_node,
                                            out_node,                                            
                                            s_sys_time,
                                            &MTIVLOTSTS_OLD,
                                            &MTIVLOTSTS,
                                            &MTIVLOTHIS) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }   
	
	if (TRS.mem_cmp(in_node, "TRAN_TYPE", MP_TIV_TRAN_TYPE_MAT_CHG, strlen(MP_TIV_TRAN_TYPE_MAT_CHG)) == 0 &&
		TRS.get_char(in_node, "SKIP_IF_INFO_FLAG") != 'Y')
	{
		IF_node = TRS.create_node("INTERFACE_IN");
		TRS.add_char(IF_node, IN_PROCSTEP, '1');
		TRS.add_enc_nstring(IF_node, IN_USERID, TRS.get_userid(in_node));
		TRS.add_char(IF_node, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(IF_node, IN_FACTORY, TRS.get_factory(in_node));
					
		TRS.add_nstring(IF_node, "WERKS", TRS.get_factory(in_node));
		TRS.add_nstring(IF_node, "WERKS1", TRS.get_factory(in_node));
		TRS.add_nstring(IF_node, "BUDAT", TRS.get_string(in_node, "WORK_DATE"));				 
		//TRS.add_nstring(IF_node, "AUFNR", TRS.get_string(in_node, "ORDER_ID"));	
		TRS.add_string(IF_node, "BWART", MP_TIV_ERP_MVT_309, strlen(MP_TIV_ERP_MVT_309));
	
		TRS.add_string(IF_node, "MATNR", MTIVLOTSTS_OLD.MAT_ID, sizeof(MTIVLOTSTS_OLD.MAT_ID));
		TRS.add_string(IF_node, "MATNR1", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));

		TRS.add_string(IF_node, "LGORT", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		TRS.add_string(IF_node, "LGORT1", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		//i_last_if_seq++; ?????
		//TRS.add_int(IF_node, "SEQNO", i_last_if_seq);
	 
		/*if (TRS.get_char(in_node, "MVT_PM") == 'P')
			TRS.add_double(IF_node, "MENGE", d_total_cv_qty_1);
		else
			TRS.add_double(IF_node, "MENGE", -1 * d_total_cv_qty_1);*/
		TRS.add_double(IF_node, "MENGE", MTIVLOTSTS.QTY_1);
		TRS.add_string(IF_node, "ERNAM", "MES", strlen("MES"));
		TRS.add_string(IF_node, "ERDAT", s_sys_time, 8);
		TRS.add_string(IF_node, "ERZET", s_sys_time + 8, 6);
				
		TRS.add_string(IF_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));

		TRS.add_string(IF_node, "MEINS", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
		TRS.add_string(IF_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		TRS.add_int(IF_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

		TRS.add_int(IF_node, "MAT_VER", MTIVLOTSTS.MAT_VER);

		TRS.add_char(IF_node, "ERP_IN_OUT_FLAG", MP_MVT_IN_OUT_FLAG_BOTH);

		//if (CUS_MES_To_ERP_Move(s_msg_code, IF_node, out_node) == MP_FALSE)
		//{
		//	TRS.free_node(IF_node);
		//	return MP_FALSE;
		//}
		TRS.free_node(IF_node);
		 
	}

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Adapt_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /*************************************************************************************************************/
    /* Summary Temp Lot Routine Start */
    /*if(COM_compare_global_option(TRS.get_factory(in_node), 
                                 MP_OPTION_MAKE_SUM_TEMP_HISTORY, 
                                 'Y') == MP_TRUE)
    {
          TRSNode* sum_in_node;
          sum_in_node = TRS.create_node("SUMMARY_LOT_IN");
           
          TRS.add_string(sum_in_node, "TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
          TRS.add_string(sum_in_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
          TRS.add_int(sum_in_node, "HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);

          if(COM_proc_user_routine("MES_UserTIV", "TIV_Adapt_Lot",
                                   MP_UPOINT_SUMMARY_LOT,
                                   sum_in_node,
                                   out_node) == MP_FALSE)     
                                   
          {
              TRS.free_node(sum_in_node);
              return MP_FALSE;
          }
          TRS.free_node(sum_in_node);
    }*/
    /* Summary Temp Lot Routine End */
    /*************************************************************************************************************/

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Adapt_Lot_Fill_InTag()
        - Validation Check sub function of "TIV_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Adapt_Lot_Fill_InTag(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    TRSNode *member;

    if(COM_isnullspace(TRS.get_string(in_node, "TIV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "TIV_LOT_ID"); 
	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TIV_OPER");
    DBC_select_mtivlotsts(4, &MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0030");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }     
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);    
		TRS.add_fieldmsg(out_node, "TIV_OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if((member = TRS.get_member(in_node, "LOT_DESC")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "LOT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));
    }
    if((member = TRS.get_member(in_node, "MAT_ID")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
    }
    if((member = TRS.get_member(in_node, "MAT_VER")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_int(in_node, "MAT_VER", MTIVLOTSTS.MAT_VER);
    }    
    if((member = TRS.get_member(in_node, "OPER")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
    }
	if((member = TRS.get_member(in_node, "TO_OPER")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "TO_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
    }
    if((member = TRS.get_member(in_node, "TO_MAT_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "TO_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
    }
    if((member = TRS.get_member(in_node, "TO_MAT_VER")) == 0x00 || member->NullFlag == 'Y' || member->Value.i4 < 1)
    {
        TRS.set_int(in_node, "TO_MAT_VER", MTIVLOTSTS.MAT_VER);
    }    
    if((member = TRS.get_member(in_node, "LOT_TYPE")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "LOT_TYPE") == ' ')
    {
        TRS.set_char(in_node, "LOT_TYPE", MTIVLOTSTS.LOT_TYPE);
    }
    if((member = TRS.get_member(in_node, "QTY_1")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_double(in_node, "QTY_1", MTIVLOTSTS.QTY_1);
    }
    if((member = TRS.get_member(in_node, "QTY_2")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_double(in_node, "QTY_2", MTIVLOTSTS.QTY_2);
    }
    if((member = TRS.get_member(in_node, "QTY_3")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_double(in_node, "QTY_3", MTIVLOTSTS.QTY_3);
    }
    if((member = TRS.get_member(in_node, "ORDER_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
    }
    if((member = TRS.get_member(in_node, "LINE_NO")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "LINE_NO", MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO));
    }
    if((member = TRS.get_member(in_node, "LOCATION_NO")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "LOCATION_NO", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));
    }
    if((member = TRS.get_member(in_node, "GRADE_CODE")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "GRADE_CODE", MTIVLOTSTS.GRADE, sizeof(MTIVLOTSTS.GRADE));
    }
    if((member = TRS.get_member(in_node, "ADD_ORDER_ID_1")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ADD_ORDER_ID_1", MTIVLOTSTS.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS.ADD_ORDER_ID_1));
    }
    if((member = TRS.get_member(in_node, "ADD_ORDER_LINE_1")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ADD_ORDER_LINE_1", MTIVLOTSTS.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_1));
    }
    if((member = TRS.get_member(in_node, "ADD_ORDER_ID_2")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ADD_ORDER_ID_2", MTIVLOTSTS.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS.ADD_ORDER_ID_2));
    }
    if((member = TRS.get_member(in_node, "ADD_ORDER_LINE_2")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ADD_ORDER_LINE_2", MTIVLOTSTS.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_2));
    }
    if((member = TRS.get_member(in_node, "ADD_ORDER_ID_3")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ADD_ORDER_ID_3", MTIVLOTSTS.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS.ADD_ORDER_ID_3));
    }
    if((member = TRS.get_member(in_node, "ADD_ORDER_LINE_3")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ADD_ORDER_LINE_3", MTIVLOTSTS.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_3));
    }
    if((member = TRS.get_member(in_node, "VENDOR_LOT_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "VENDOR_LOT_ID", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
    }
    if((member = TRS.get_member(in_node, "PO_MAT_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "PO_MAT_ID", MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID));
    }
    if((member = TRS.get_member(in_node, "PO_SEQ_NUM")) == 0x00 || member->NullFlag == 'Y' || member->Value.i4 < 1)
    {
        TRS.set_int(in_node, "PO_SEQ_NUM", MTIVLOTSTS.PO_SEQ_NUM);
    } 
    if((member = TRS.get_member(in_node, "INV_CMF_1")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_2")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_3")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_4")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_5")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_6")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_7")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_8")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_9")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_10")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_11")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_12")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_13")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_14")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_15")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_16")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_17")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_18")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_19")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_20")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
    }
    if((member = TRS.get_member(in_node, "OWNER_CODE")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
    }
    if((member = TRS.get_member(in_node, "VENDOR_ID")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
    }

	if((member = TRS.get_member(in_node, "CREATE_QTY_1")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_double(in_node, "CREATE_QTY_1", MTIVLOTSTS.CREATE_QTY_1);
    }
    if((member = TRS.get_member(in_node, "CREATE_QTY_2")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_double(in_node, "CREATE_QTY_2", MTIVLOTSTS.CREATE_QTY_2);
    }
    if((member = TRS.get_member(in_node, "CREATE_QTY_3")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_double(in_node, "CREATE_QTY_3", MTIVLOTSTS.CREATE_QTY_3);
    }
 	
 	if((member = TRS.get_member(in_node, "UNIT_1")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "UNIT_1", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
    }
    if((member = TRS.get_member(in_node, "UNIT_2")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "UNIT_2", MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
    }
    if((member = TRS.get_member(in_node, "UNIT_3")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "UNIT_3", MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));
    }

	if((member = TRS.get_member(in_node, "EXPIRE_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "EXPIRE_DATE", MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE));
    }


	if((member = TRS.get_member(in_node, "INV_FLAG_1")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_1") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_1", MTIVLOTSTS.INV_FLAG_1);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_2")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_2") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_2", MTIVLOTSTS.INV_FLAG_2);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_3")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_3") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_3", MTIVLOTSTS.INV_FLAG_3);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_4")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_4") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_4", MTIVLOTSTS.INV_FLAG_4);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_5")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_5") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_5", MTIVLOTSTS.INV_FLAG_5);
    }

	if((member = TRS.get_member(in_node, "INV_CMF_21")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_21", MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_22")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_22", MTIVLOTSTS.INV_CMF_22, sizeof(MTIVLOTSTS.INV_CMF_22));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_23")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_23", MTIVLOTSTS.INV_CMF_23, sizeof(MTIVLOTSTS.INV_CMF_23));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_24")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_24", MTIVLOTSTS.INV_CMF_24, sizeof(MTIVLOTSTS.INV_CMF_24));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_25")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_25", MTIVLOTSTS.INV_CMF_25, sizeof(MTIVLOTSTS.INV_CMF_25));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_26")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_26", MTIVLOTSTS.INV_CMF_26, sizeof(MTIVLOTSTS.INV_CMF_26));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_27")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_27", MTIVLOTSTS.INV_CMF_27, sizeof(MTIVLOTSTS.INV_CMF_27));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_28")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_28", MTIVLOTSTS.INV_CMF_28, sizeof(MTIVLOTSTS.INV_CMF_28));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_29")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_29", MTIVLOTSTS.INV_CMF_29, sizeof(MTIVLOTSTS.INV_CMF_29));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_30")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_30", MTIVLOTSTS.INV_CMF_30, sizeof(MTIVLOTSTS.INV_CMF_30));
    }

	if((member = TRS.get_member(in_node, "ERP_CREATE_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_CREATE_DATE", MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE));
    }
	if((member = TRS.get_member(in_node, "ERP_INV_IN_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_INV_IN_DATE", MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE));
    }
	if((member = TRS.get_member(in_node, "ERP_OINV_IN_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_OINV_IN_DATE", MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE));
    }
	if((member = TRS.get_member(in_node, "ERP_LAST_TRAN_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_LAST_TRAN_DATE", MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE));
    }
	if((member = TRS.get_member(in_node, "LAST_TRAN_USER_ID")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "LAST_TRAN_USER_ID", MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID));
    }

    return MP_TRUE;
}

/*******************************************************************************
    TIV_Adapt_Lot_Validation()
        - Validation Check sub function of "TIV_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Adapt_Lot_Validation(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    //struct MTIVMATDEF_TAG MTIVMATDEF;  
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;  

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                                 "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Proc Step validation */
    if(COM_check_value(s_msg_code,
                       in_node,
                       out_node,
                       IN_PROCSTEP,
                       'Y',
                       ' ',
                       0x00,
                       0x00,
                       0x00) == MP_FALSE)
    {
        return MP_FALSE;
    }

     /* validation input value */
    if(TIV_lot_tran_validation_for_inv(s_msg_code,
                               out_node,
                               in_node,
                               &MTIVLOTSTS,
                               &MWIPFACDEF,
                               &MWIPMATDEF,
                               &MTIVOPRDEF) == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Lot Delete Validation */
    /*if(TRS.get_char(in_node, "REBIRTH_ZERO_QTY_LOT")!='Y' && TRS.get_double(in_node, "AFTER_QTY_1")!=0)
    {
        if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
        {
            strcpy(s_msg_code, "WIP-0076");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
        }
    }*/

    if(COM_isnullspace(TRS.get_string(in_node, "TO_MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "TO_MAT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(TRS.get_int(in_node, "TO_MAT_VER") < 1)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "TO_MAT_VER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(TRS.mem_cmp(in_node, "TO_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID)) == 0 &&
       TRS.get_int(in_node, "TO_MAT_VER") == MTIVLOTSTS.MAT_VER)
    {
        if(MWIPMATDEF.DELETE_FLAG == 'Y')
        {
            strcpy(s_msg_code, "INV-0036");
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_LOGIC;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
        if(MWIPMATDEF.DEACTIVE_FLAG == 'Y')
        {
            strcpy(s_msg_code, "INV-0037");
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_LOGIC;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }

    /*if(COM_isnullspace(TRS.get_string(in_node, "TO_OPER")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TO_OPER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mtivoprdef(&MTIVOPRDEF);
    TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "TO_OPER");
    DBC_select_mtivoprdef(1, &MTIVOPRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }     
        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "TO_OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

*/
     /* Lot_Type Check */
    if(TRS.get_char(in_node, "LOT_TYPE") == ' ')
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "LOT_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    else
    {
        char s_lot_type[2];

        s_lot_type[0] = TRS.get_char(in_node, "LOT_TYPE");
        s_lot_type[1] = 0x00;

        if(COM_check_gcm_data(s_msg_code,
                              out_node,
                              MP_WIP_LOT_TYPE,
                              TRS.get_factory(in_node),
                              s_lot_type,
                              1) == MP_FALSE)
        {
            return MP_FALSE;
        }
    }

    /* Lot Hold Validation */
    if(MTIVLOTSTS.HOLD_FLAG == 'Y')
    {
        strcpy(s_msg_code, "INV-0038");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    ////Lot이 여러개 존재하는 경우 Lot의 정보를 변경할 수 없다. 
    //DBC_init_mtivlotsts(&MTIVLOTSTS);
    //TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
    //TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "TIV_LOT_ID");
    //if((int)DBC_select_mtivlotsts_scalar(1, &MTIVLOTSTS)>1)
    //{
    //    strcpy(s_msg_code, "INV-0040");
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}


    /* CMF Validation */
    if(TIV_check_lot_cmf_adapt_lot(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

/*******************************************************************************
    TIV_check_lot_cmf_adapt_lot()
        - Check the Conditions before Create Lot CMF Definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - Adapt_Lot_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_check_lot_cmf_adapt_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node)
{
    struct check_list s_check_list;

    /*COM_fill_check_list(&s_check_list, in_node, 20, "TRAN_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_TIV_TRN_ADAPT, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }*/

    COM_fill_check_list(&s_check_list, in_node, 20, "INV_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_INV_LOT, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

/*******************************************************************************
    TIV_Adapt_Sublot_Proc()
        - Main sub function of "TIV_ADAPT_LOT" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Adapt_Sublot_Proc(char *s_msg_code,
                          TRSNode *in_node,
                          TRSNode *out_node)
{
////    struct MWIPSLTSTS_TAG MWIPSLTSTS;
////    TRSNode **crr_list;
////    int i_crr_count;
////    int i;
////
////    TRSNode **sublot_list;
////    int i_sublot_count;
////    int k;
////
////    TRSNode *adapt_sublot_in = TRS.create_node("ADAPT_SUBLOT_IN");
////
////    TRS.add_char(adapt_sublot_in, IN_PROCSTEP, '1');
////    TRS.add_nstring(adapt_sublot_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
////    TRS.add_char(adapt_sublot_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
////    TRS.add_nstring(adapt_sublot_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
////    TRS.add_nstring(adapt_sublot_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
////    TRS.add_nstring(adapt_sublot_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
////    TRS.add_nstring(adapt_sublot_in, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
////    TRS.add_char(adapt_sublot_in, MP_TIV_LOT_BASE_FLAG, 'Y');
////
////    TRS.add_nstring(adapt_sublot_in, "TO_MAT_ID", TRS.get_string(in_node, "TO_MAT_ID"));
////    TRS.add_int(adapt_sublot_in, "TO_MAT_VER", TRS.get_int(in_node, "TO_MAT_VER"));
////    TRS.add_nstring(adapt_sublot_in, "TO_FLOW", TRS.get_string(in_node, "TO_FLOW"));
////    TRS.add_int(adapt_sublot_in, "TO_FLOW_SEQ_NUM", TRS.get_int(in_node, "TO_FLOW_SEQ_NUM"));
////    TRS.add_nstring(adapt_sublot_in, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));
////
////    TRS.add_nstring(adapt_sublot_in, "CREATE_CODE", TRS.get_string(in_node, "CREATE_CODE"));
////    TRS.add_nstring(adapt_sublot_in, "OWNER_CODE", TRS.get_string(in_node, "OWNER_CODE"));
////
////    TRS.add_char(adapt_sublot_in, "RWK_FLAG", TRS.get_char(in_node, "RWK_FLAG"));
////
////    //Add by J.S. 2011.05.17 Rework 관련 항목 Adapt에 포함
////    //실제 Sublot별로 Adapt되는 경우는 없음으로 내부 코딩은 수정하지 않음.
////    //만약 SUBLOT별로 ADAPT되는 경우가 있으면 추가 코딩 할것
////    TRS.add_nstring(adapt_sublot_in, "RWK_CODE", TRS.get_string(in_node, "RWK_CODE"));
////    TRS.add_nstring(adapt_sublot_in, "RWK_STOP_OPER", TRS.get_string(in_node, "RWK_STOP_OPER"));
////    TRS.add_nstring(adapt_sublot_in, "RWK_RET_FLOW", TRS.get_string(in_node, "RWK_RET_FLOW"));
////    TRS.add_int(adapt_sublot_in, "RWK_RET_FLOW_SEQ_NUM", TRS.get_int(in_node, "RWK_RET_FLOW_SEQ_NUM"));
////    TRS.add_nstring(adapt_sublot_in, "RWK_RET_OPER", TRS.get_string(in_node, "RWK_RET_OPER"));
////    TRS.add_nstring(adapt_sublot_in, "RWK_END_FLOW", TRS.get_string(in_node, "RWK_END_FLOW"));
////    TRS.add_int(adapt_sublot_in, "RWK_END_FLOW_SEQ_NUM", TRS.get_int(in_node, "RWK_END_FLOW_SEQ_NUM"));
////    TRS.add_nstring(adapt_sublot_in, "RWK_END_OPER", TRS.get_string(in_node, "RWK_END_OPER"));
////    TRS.add_char(adapt_sublot_in, "RWK_RET_CLEAR_FLAG", TRS.get_char(in_node, "RWK_RET_CLEAR_FLAG"));
////    TRS.add_int(adapt_sublot_in, "RWK_COUNT", TRS.get_int(in_node, "RWK_COUNT"));
////    TRS.add_nstring(adapt_sublot_in, "RWK_TIME", TRS.get_string(in_node, "RWK_TIME"));
////    TRS.add_char(adapt_sublot_in, "LOCAL_REWORK_FLAG", TRS.get_char(in_node, "LOCAL_REWORK_FLAG"));
////    //End Add
////
////    TRS.add_char(adapt_sublot_in, "NSTD_FLAG", TRS.get_char(in_node, "NSTD_FLAG"));
////    TRS.add_nstring(adapt_sublot_in, "NSTD_RET_FLOW", TRS.get_string(in_node, "NSTD_RET_FLOW"));
////    TRS.add_int(adapt_sublot_in, "NSTD_RET_FLOW_SEQ_NUM", TRS.get_int(in_node, "NSTD_RET_FLOW_SEQ_NUM"));
////    TRS.add_nstring(adapt_sublot_in, "NSTD_RET_OPER", TRS.get_string(in_node, "NSTD_RET_OPER"));
////    TRS.add_nstring(adapt_sublot_in, "NSTD_TIME", TRS.get_string(in_node, "NSTD_TIME"));
////
////    TRS.add_char(adapt_sublot_in, "REP_FLAG", TRS.get_char(in_node, "REP_FLAG"));
////    TRS.add_nstring(adapt_sublot_in, "REP_RET_OPER", TRS.get_string(in_node, "REP_RET_OPER"));
////
////    TRS.add_char(adapt_sublot_in, "SAMPLE_FLAG", TRS.get_char(in_node, "SAMPLE_FLAG"));
////    TRS.add_char(adapt_sublot_in, "SAMPLE_RESULT", TRS.get_char(in_node, "SAMPLE_RESULT"));
////
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_1", TRS.get_string(in_node, "TRAN_CMF_1"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_2", TRS.get_string(in_node, "TRAN_CMF_2"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_3", TRS.get_string(in_node, "TRAN_CMF_3"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_4", TRS.get_string(in_node, "TRAN_CMF_4"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_5", TRS.get_string(in_node, "TRAN_CMF_5"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_6", TRS.get_string(in_node, "TRAN_CMF_6"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_7", TRS.get_string(in_node, "TRAN_CMF_7"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_8", TRS.get_string(in_node, "TRAN_CMF_8"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_9", TRS.get_string(in_node, "TRAN_CMF_9"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_10", TRS.get_string(in_node, "TRAN_CMF_10"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_11", TRS.get_string(in_node, "TRAN_CMF_11"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_12", TRS.get_string(in_node, "TRAN_CMF_12"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_13", TRS.get_string(in_node, "TRAN_CMF_13"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_14", TRS.get_string(in_node, "TRAN_CMF_14"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_15", TRS.get_string(in_node, "TRAN_CMF_15"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_16", TRS.get_string(in_node, "TRAN_CMF_16"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_17", TRS.get_string(in_node, "TRAN_CMF_17"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_18", TRS.get_string(in_node, "TRAN_CMF_18"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_19", TRS.get_string(in_node, "TRAN_CMF_19"));
////    TRS.add_nstring(adapt_sublot_in, "TRAN_CMF_20", TRS.get_string(in_node, "TRAN_CMF_20"));
////    TRS.add_nstring(adapt_sublot_in, "COMMENT", TRS.get_string(in_node, "COMMENT"));
////
////    /* Select Sublot Info */
////    DBC_init_mwipsltsts(&MWIPSLTSTS);
////    TRS.copy(MWIPSLTSTS.LOT_ID, sizeof(MWIPSLTSTS.LOT_ID), in_node, "LOT_ID");
////    MWIPSLTSTS.SUBLOT_DEL_FLAG = ' ';
////    DBC_open_mwipsltsts(2, &MWIPSLTSTS);
////    if(DB_error_code != DB_SUCCESS)
////    {
////        strcpy(s_msg_code, "WIP-0004");
////        TRS.add_fieldmsg(out_node, "MWIPSLTSTS OPEN", MP_NVST);
////        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTSTS.LOT_ID), MWIPSLTSTS.LOT_ID);
////        TRS.add_dberrmsg(out_node, DB_error_msg);
////
////        gs_log_type.type = MP_LOG_ERROR;
////        gs_log_type.e_type = MP_LOG_E_SYSTEM;
////        gs_log_type.category = MP_LOG_CATE_TRANS;
////
////        TRS.free_node(adapt_sublot_in);
////        return MP_FALSE;
////    }
////
////    crr_list = TRS.get_list(in_node, "CRR_LIST");
////    i_crr_count = TRS.get_item_count(in_node, "CRR_LIST");
////
////#ifdef _CRR
////    TIV_crr_slot_init();
////#endif
////
////    while(1)
////    {
////        DBC_fetch_mwipsltsts(2, &MWIPSLTSTS);
////        if(DB_error_code == DB_NOT_FOUND)
////        {
////            DBC_close_mwipsltsts(2);
////            break;
////        }
////        else if(DB_error_code != DB_SUCCESS)
////        {
////            strcpy(s_msg_code, "WIP-0004");
////            TRS.add_fieldmsg(out_node, "MWIPSLTSTS FETCH", MP_NVST);
////            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTSTS.LOT_ID), MWIPSLTSTS.LOT_ID);
////            TRS.add_dberrmsg(out_node, DB_error_msg);
////
////            gs_log_type.type = MP_LOG_ERROR;
////            gs_log_type.e_type = MP_LOG_E_SYSTEM;
////            gs_log_type.category = MP_LOG_CATE_TRANS;
////
////            DBC_close_mwipsltsts(2);
////            TRS.free_node(adapt_sublot_in);
////            return MP_FALSE;
////        }
////
////        /* Validation Logic */
////        if(TRS.mem_cmp(in_node, "MAT_ID", MWIPSLTSTS.MAT_ID, sizeof(MWIPSLTSTS.MAT_ID)) != 0 ||
////           MWIPSLTSTS.MAT_VER != TRS.get_int(in_node, "MAT_VER") ||
////           TRS.mem_cmp(in_node, "FLOW", MWIPSLTSTS.FLOW, sizeof(MWIPSLTSTS.FLOW)) != 0 ||
////           MWIPSLTSTS.FLOW_SEQ_NUM != TRS.get_int(in_node, "FLOW_SEQ_NUM") ||
////           TRS.mem_cmp(in_node, "OPER", MWIPSLTSTS.OPER, sizeof(MWIPSLTSTS.OPER)) != 0 )
////        {
////            continue;
////        }
////
////        /* 기존 캐리어와 변경 캐리어가 다르면서 기존 캐리어가 있으면 기존 캐리어에 있는 서브랏만, 기존 캐리어가 없으면 모든 서브랏을 새로운 캐리어로 변경 */
////        if(crr_list == 0x00)
////        {
////            if(TRS.str_tcmp(in_node, "CRR_ID", in_node, "TO_CRR_ID") != 0)
////            {
////                if(COM_isnullspace(TRS.get_string(in_node, "CRR_ID")) == MP_FALSE)
////                {
////                    if(TRS.mem_cmp(in_node, "CRR_ID", MWIPSLTSTS.CRR_ID, sizeof(MWIPSLTSTS.CRR_ID)) == 0)
////                    {
////                        TRS.set_nstring(adapt_sublot_in, "CRR_ID", TRS.get_string(in_node, "TO_CRR_ID"));
////                    }
////                    else
////                    {
////                        TRS.set_string(adapt_sublot_in, "CRR_ID", MWIPSLTSTS.CRR_ID, sizeof(MWIPSLTSTS.CRR_ID));
////                    }
////                }
////                else
////                {
////                    TRS.set_nstring(adapt_sublot_in, "CRR_ID", TRS.get_string(in_node, "TO_CRR_ID"));
////                }
////            }
////            else
////            {
////                TRS.set_string(adapt_sublot_in, "CRR_ID", MWIPSLTSTS.CRR_ID, sizeof(MWIPSLTSTS.CRR_ID));
////            }
////        }
////        else
////        {
////            for(i = 0; i < i_crr_count; i++)
////            {
////                sublot_list = TRS.get_list(crr_list[i], "SUBLOT_LIST");
////                i_sublot_count = TRS.get_item_count(crr_list[i], "SUBLOT_LIST");
////
////                if(i_sublot_count > 0)
////                {
////                    for(k = 0; k < i_sublot_count; k++)
////                    {
////                        if(TRS.mem_cmp(sublot_list[k], "SUBLOT_ID", MWIPSLTSTS.SUBLOT_ID, sizeof(MWIPSLTSTS.SUBLOT_ID)) == 0)
////                        {
////                            TRS.set_nstring(adapt_sublot_in, "CRR_ID", TRS.get_string(crr_list[i], "TO_CRR_ID"));
////                            break;
////                        }
////                    }
////                    if(k < i_sublot_count)
////                    {
////                        break;
////                    }
////                }
////            }//end for
////
////            if(i >= i_crr_count)
////            {
////                TRS.set_string(adapt_sublot_in, "CRR_ID", MWIPSLTSTS.CRR_ID, sizeof(MWIPSLTSTS.CRR_ID));
////            }
////        }
////
////        TRS.set_string(adapt_sublot_in, "LOT_ID", MWIPSLTSTS.LOT_ID, sizeof(MWIPSLTSTS.LOT_ID));
////
////        TRS.set_string(adapt_sublot_in, "MAT_ID", MWIPSLTSTS.MAT_ID, sizeof(MWIPSLTSTS.MAT_ID));
////        TRS.set_int(adapt_sublot_in, "MAT_VER", MWIPSLTSTS.MAT_VER);
////        TRS.set_string(adapt_sublot_in, "FLOW", MWIPSLTSTS.FLOW, sizeof(MWIPSLTSTS.FLOW));
////        TRS.set_int(adapt_sublot_in, "FLOW_SEQ_NUM", MWIPSLTSTS.FLOW_SEQ_NUM);
////        TRS.set_string(adapt_sublot_in, "OPER", MWIPSLTSTS.OPER, sizeof(MWIPSLTSTS.OPER));
////
////        TRS.set_string(adapt_sublot_in, "SUBLOT_ID", MWIPSLTSTS.SUBLOT_ID, sizeof(MWIPSLTSTS.SUBLOT_ID));
////        TRS.set_int(adapt_sublot_in, "LAST_ACTIVE_HIST_SEQ", MWIPSLTSTS.LAST_ACTIVE_HIST_SEQ);
////
////        TRS.set_int(adapt_sublot_in, "SLOT_NO", MWIPSLTSTS.SLOT_NO);
////        TRS.set_char(adapt_sublot_in, "GRADE", MWIPSLTSTS.GRADE);
////        TRS.set_string(adapt_sublot_in, "GRADE_CODE", MWIPSLTSTS.GRADE_CODE, sizeof(MWIPSLTSTS.GRADE_CODE));
////        TRS.set_string(adapt_sublot_in, "CELL_GRADE", MWIPSLTSTS.CELL_GRADE, sizeof(MWIPSLTSTS.CELL_GRADE));
////
////        //Add by J.S. 2009.02.18 for ADD CELL_JUDGE.
////        TRS.set_string(adapt_sublot_in, "CELL_JUDGE", MWIPSLTSTS.CELL_JUDGE, sizeof(MWIPSLTSTS.CELL_JUDGE));
////        TRS.set_char(adapt_sublot_in, "SUBLOT_TYPE", MWIPSLTSTS.SUBLOT_TYPE);
////
////        TRS.set_double(adapt_sublot_in, "QTY_2", MWIPSLTSTS.QTY_2);
////        TRS.set_double(adapt_sublot_in, "QTY_3", MWIPSLTSTS.QTY_3);
////
////        if(TIV_ADAPT_SUBLOT(s_msg_code, adapt_sublot_in, out_node) == MP_FALSE)
////        {
////            DBC_close_mwipsltsts(2);
////            TRS.free_node(adapt_sublot_in);
////            return MP_FALSE;
////        }  
////    }
////    TRS.free_node(adapt_sublot_in);
////
////#ifdef _CRR
////    if(TIV_crr_slot_save(s_msg_code, out_node, in_node) == MP_FALSE)
////    {
////        return MP_FALSE;
////    }
////#endif
////
////    /* 공정 변경으로 인해 Sublot을 제거해야 하는 경우가 발생할 수 있으므로 호출. 그외의 경우는 아무동작 안하고 그냥 빠져나옴. */
////    if(TIV_process_sublot_tracking(s_msg_code,
////                                   out_node,
////                                   in_node,
////                                   TRS.get_factory(in_node),
////                                   TRS.get_string(in_node, "LOT_ID"),
////                                   TRS.get_string(in_node, "OPER"),
////                                   "",
////                                   'N',
////                                   ' ') == MP_FALSE)
////    {
////        return MP_FALSE;
////    }

    return MP_TRUE;
}

#ifdef _CRR
/*******************************************************************************
    TIV_Adapt_Carrier_Proc()
        - Main sub function of "TIV_ADAPT_LOT" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Adapt_Carrier_Proc(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node,
                           struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{
    //struct MWIPCRRLOT_TAG MWIPCRRLOT;
    //char carrier_flag;
    //TRSNode **crr_list;
    //int i_crr_count;
    //int i;

    //carrier_flag = ' ';
    //if(RAS_check_carrier_exist(s_msg_code, 
    //                           out_node, 
    //                           '2', 
    //                           TRS.get_factory(in_node), 
    //                           " ", 
    //                           &carrier_flag) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}
    //if(carrier_flag != 'Y')
    //{
    //    return MP_TRUE; // Factory에 Carrier가 없으므로 그냥 Return 한다.
    //}

    //carrier_flag = ' ';
    //if(RAS_check_lot_in_carrier(s_msg_code, 
    //                            out_node, 
    //                            TRS.get_factory(in_node), 
    //                            TRS.get_string(in_node, "LOT_ID"), 
    //                            &carrier_flag) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    ///* 현재도 앞으로도 캐리어 사용하지 않으면 리턴 */
    //crr_list = TRS.get_list(in_node, "CRR_LIST");
    //if(carrier_flag != 'Y' && COM_isnullspace(TRS.get_string(in_node, "TO_CRR_ID")) == MP_TRUE && crr_list == 0x00)
    //{
    //    return MP_TRUE; 
    //}

    //if(crr_list == 0x00)
    //{
    //    /* Carrier 가 변경되는 경우 */
    //    if(TRS.str_tcmp(in_node, "CRR_ID", in_node, "TO_CRR_ID") != 0)
    //    {
    //        DBC_init_mwipcrrlot(&MWIPCRRLOT);

    //        if(COM_isnullspace(TRS.get_string(in_node, "CRR_ID")) == MP_FALSE)
    //        {
    //            TRS.copy(MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID), in_node, "LOT_ID");
    //            TRS.copy(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID), in_node, "CRR_ID");

    //            DBC_select_mwipcrrlot(1, &MWIPCRRLOT);
    //            if (DB_error_code != DB_SUCCESS)
    //            {
    //                strcpy(s_msg_code, "RAS-0238");
    //                TRS.add_fieldmsg(out_node, "MWIPCRRLOT SELECT", MP_NVST);
    //                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
    //                TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
    //                TRS.add_dberrmsg(out_node, DB_error_msg);

    //                gs_log_type.type = MP_LOG_ERROR;
    //                gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //                gs_log_type.category = MP_LOG_CATE_TRANS;
    //                return MP_FALSE;
    //            }

    //            if(TIV_carrier_detach_only_crrlot_qty(s_msg_code,
    //                                                  out_node,
    //                                                  in_node,
    //                                                  TRS.get_string(in_node, "LOT_ID"),
    //                                                  TRS.get_string(in_node, "CRR_ID"),
    //                                                  MWIPCRRLOT.QTY_1,
    //                                                  MWIPCRRLOT.QTY_2,
    //                                                  MWIPCRRLOT.QTY_3) == MP_FALSE)
    //            {
    //                return MP_FALSE;
    //            }
    //        }

    //        if(COM_isnullspace(TRS.get_string(in_node, "TO_CRR_ID")) == MP_FALSE)
    //        {
    //            if(COM_isspace(MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID)) == MP_TRUE)
    //            {
    //                if(TIV_carrier_attach_only_crrlot_qty(s_msg_code,
    //                                                      out_node,
    //                                                      in_node,
    //                                                      TRS.get_string(in_node, "LOT_ID"),
    //                                                      TRS.get_string(in_node, "TO_CRR_ID"),
    //                                                      TRS.get_double(in_node, "QTY_1"),
    //                                                      TRS.get_double(in_node, "QTY_2"),
    //                                                      TRS.get_double(in_node, "QTY_3")) == MP_FALSE)
    //                {
    //                    return MP_FALSE;
    //                }
    //            }
    //            else
    //            {
    //                if(TIV_carrier_attach_only_crrlot_qty(s_msg_code,
    //                                                      out_node,
    //                                                      in_node,
    //                                                      TRS.get_string(in_node, "LOT_ID"),
    //                                                      TRS.get_string(in_node, "TO_CRR_ID"),
    //                                                      MWIPCRRLOT.QTY_1,
    //                                                      MWIPCRRLOT.QTY_2,
    //                                                      MWIPCRRLOT.QTY_3) == MP_FALSE)
    //                {
    //                    return MP_FALSE;
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        /* Carrier 의 변경은 없는 경우 */
    //        /* 단 수량이 변경되는 경우에는 변경을 해 주어야 함. */
    //        if(fabs(MTIVLOTHIS->OLD_QTY_1 - MTIVLOTHIS->QTY_1) > 0.0005 ||
    //           fabs(MTIVLOTHIS->OLD_QTY_2 - MTIVLOTHIS->QTY_2) > 0.0005 ||
    //           fabs(MTIVLOTHIS->OLD_QTY_3 - MTIVLOTHIS->QTY_3) > 0.0005)
    //        {
    //            if(COM_isnullspace(TRS.get_string(in_node, "CRR_ID")) == MP_FALSE)
    //            {
    //                DBC_init_mwipcrrlot(&MWIPCRRLOT);
    //                TRS.copy(MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID), in_node, "LOT_ID");
    //                TRS.copy(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID), in_node, "CRR_ID");
    //                DBC_select_mwipcrrlot(1, &MWIPCRRLOT);
    //                if (DB_error_code != DB_SUCCESS)
    //                {
    //                    strcpy(s_msg_code, "RAS-0238");
    //                    TRS.add_fieldmsg(out_node, "MWIPCRRLOT SELECT", MP_NVST);
    //                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
    //                    TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
    //                    TRS.add_dberrmsg(out_node, DB_error_msg);

    //                    gs_log_type.type = MP_LOG_ERROR;
    //                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //                    gs_log_type.category = MP_LOG_CATE_TRANS;
    //                    return MP_FALSE;
    //                }

    //                if(MTIVLOTHIS->OLD_QTY_1 < MTIVLOTHIS->QTY_1)
    //                {
    //                    if(TIV_carrier_attach_only_crrlot_qty(s_msg_code,
    //                                                          out_node,
    //                                                          in_node,
    //                                                          MWIPCRRLOT.LOT_ID,
    //                                                          MWIPCRRLOT.CRR_ID,
    //                                                          MTIVLOTHIS->QTY_1 - MTIVLOTHIS->OLD_QTY_1,
    //                                                          MTIVLOTHIS->QTY_2 - MTIVLOTHIS->OLD_QTY_2,
    //                                                          MTIVLOTHIS->QTY_3 - MTIVLOTHIS->OLD_QTY_3) == MP_FALSE)
    //                    {
    //                        return MP_FALSE;
    //                    }
    //                }
    //                else if(MTIVLOTHIS->OLD_QTY_1 > MTIVLOTHIS->QTY_1)
    //                {
    //                    if(TIV_carrier_detach_only_crrlot_qty(s_msg_code,
    //                                                          out_node,
    //                                                          in_node,
    //                                                          MWIPCRRLOT.LOT_ID,
    //                                                          MWIPCRRLOT.CRR_ID,
    //                                                          MTIVLOTHIS->OLD_QTY_1 - MTIVLOTHIS->QTY_1,
    //                                                          MTIVLOTHIS->OLD_QTY_2 - MTIVLOTHIS->QTY_2,
    //                                                          MTIVLOTHIS->OLD_QTY_3 - MTIVLOTHIS->QTY_3) == MP_FALSE)
    //                    {
    //                        return MP_FALSE;
    //                    }
    //                }
    //            }

    //        }
    //    }
    //}
    //else
    //{
    //    i_crr_count = TRS.get_item_count(in_node, "CRR_LIST");
    //    for(i = 0; i < i_crr_count; i++)
    //    {
    //        /* Carrier 가 변경되는 경우 */
    //        if(TRS.str_tcmp(crr_list[i], "CRR_ID", crr_list[i], "TO_CRR_ID") != 0)
    //        {
    //            if(COM_isnullspace(TRS.get_string(crr_list[i], "CRR_ID")) == MP_FALSE)
    //            {
    //                DBC_init_mwipcrrlot(&MWIPCRRLOT);
    //                TRS.copy(MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID), in_node, "LOT_ID");
    //                TRS.copy(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID), crr_list[i], "CRR_ID");

    //                DBC_select_mwipcrrlot(1, &MWIPCRRLOT);
    //                if (DB_error_code != DB_SUCCESS)
    //                {
    //                    strcpy(s_msg_code, "RAS-0238");
    //                    TRS.add_fieldmsg(out_node, "MWIPCRRLOT SELECT", MP_NVST);
    //                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
    //                    TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
    //                    TRS.add_dberrmsg(out_node, DB_error_msg);

    //                    gs_log_type.type = MP_LOG_ERROR;
    //                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //                    gs_log_type.category = MP_LOG_CATE_TRANS;
    //                    return MP_FALSE;
    //                }

    //                if(MWIPCRRLOT.QTY_1 - TRS.get_double(crr_list[i], "CRR_QTY_1") > 0)
    //                {
    //                    if(TIV_carrier_detach_only_crrlot_qty(s_msg_code,
    //                                                          out_node,
    //                                                          in_node,
    //                                                          TRS.get_string(in_node, "LOT_ID"),
    //                                                          TRS.get_string(crr_list[i], "CRR_ID"),
    //                                                          MWIPCRRLOT.QTY_1 - TRS.get_double(crr_list[i], "CRR_QTY_1"),
    //                                                          MWIPCRRLOT.QTY_2 - TRS.get_double(crr_list[i], "CRR_QTY_2"),
    //                                                          MWIPCRRLOT.QTY_3 - TRS.get_double(crr_list[i], "CRR_QTY_3")) == MP_FALSE)
    //                    {
    //                        return MP_FALSE;
    //                    }
    //                }
    //                else
    //                {
    //                    if(TIV_carrier_detach_only_crrlot_qty(s_msg_code,
    //                                                          out_node,
    //                                                          in_node,
    //                                                          TRS.get_string(in_node, "LOT_ID"),
    //                                                          TRS.get_string(crr_list[i], "CRR_ID"),
    //                                                          MWIPCRRLOT.QTY_1,
    //                                                          MWIPCRRLOT.QTY_2,
    //                                                          MWIPCRRLOT.QTY_3) == MP_FALSE)
    //                    {
    //                        return MP_FALSE;
    //                    }
    //                }
    //            }

    //            if(COM_isnullspace(TRS.get_string(crr_list[i], "TO_CRR_ID")) == MP_FALSE)
    //            {
    //                DBC_init_mwipcrrlot(&MWIPCRRLOT);
    //                TRS.copy(MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID), in_node, "LOT_ID");
    //                TRS.copy(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID), crr_list[i], "TO_CRR_ID");

    //                DBC_select_mwipcrrlot(1, &MWIPCRRLOT);
    //                if (DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS)
    //                {
    //                    strcpy(s_msg_code, "RAS-0238");
    //                    TRS.add_fieldmsg(out_node, "MWIPCRRLOT SELECT", MP_NVST);
    //                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
    //                    TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
    //                    TRS.add_dberrmsg(out_node, DB_error_msg);

    //                    gs_log_type.type = MP_LOG_ERROR;
    //                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //                    gs_log_type.category = MP_LOG_CATE_TRANS;
    //                    return MP_FALSE;
    //                }

    //                if(TRS.get_double(crr_list[i], "CRR_QTY_1") - MWIPCRRLOT.QTY_1 > 0)
    //                {
    //                    if(TIV_carrier_attach_only_crrlot_qty(s_msg_code,
    //                                                            out_node,
    //                                                            in_node,
    //                                                            TRS.get_string(in_node, "LOT_ID"),
    //                                                            TRS.get_string(crr_list[i], "TO_CRR_ID"),
    //                                                            TRS.get_double(crr_list[i], "CRR_QTY_1") - MWIPCRRLOT.QTY_1,
    //                                                            TRS.get_double(crr_list[i], "CRR_QTY_2") - MWIPCRRLOT.QTY_2,
    //                                                            TRS.get_double(crr_list[i], "CRR_QTY_3") - MWIPCRRLOT.QTY_3) == MP_FALSE)
    //                    {
    //                        return MP_FALSE;
    //                    }
    //                }
    //                else if(TRS.get_double(crr_list[i], "CRR_QTY_1") - MWIPCRRLOT.QTY_1 < 0)
    //                {
    //                    if(TIV_carrier_detach_only_crrlot_qty(s_msg_code,
    //                                                            out_node,
    //                                                            in_node,
    //                                                            TRS.get_string(in_node, "LOT_ID"),
    //                                                            TRS.get_string(crr_list[i], "TO_CRR_ID"),
    //                                                            MWIPCRRLOT.QTY_1 - TRS.get_double(crr_list[i], "CRR_QTY_1"),
    //                                                            MWIPCRRLOT.QTY_2 - TRS.get_double(crr_list[i], "CRR_QTY_2"),
    //                                                            MWIPCRRLOT.QTY_3 - TRS.get_double(crr_list[i], "CRR_QTY_3")) == MP_FALSE)
    //                     {
    //                        return MP_FALSE;
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            /* Carrier 의 변경은 없는 경우 */
    //            /* 단 수량이 변경되는 경우에는 변경을 해 주어야 함. */
    //            if(COM_isnullspace(TRS.get_string(crr_list[i], "CRR_ID")) == MP_FALSE)
    //            {
    //                DBC_init_mwipcrrlot(&MWIPCRRLOT);
    //                TRS.copy(MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID), in_node, "LOT_ID");
    //                TRS.copy(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID), crr_list[i], "CRR_ID");
    //                DBC_select_mwipcrrlot(1, &MWIPCRRLOT);
    //                if (DB_error_code != DB_SUCCESS)
    //                {
    //                    strcpy(s_msg_code, "RAS-0238");
    //                    TRS.add_fieldmsg(out_node, "MWIPCRRLOT SELECT", MP_NVST);
    //                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
    //                    TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
    //                    TRS.add_dberrmsg(out_node, DB_error_msg);

    //                    gs_log_type.type = MP_LOG_ERROR;
    //                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //                    gs_log_type.category = MP_LOG_CATE_TRANS;
    //                    return MP_FALSE;
    //                }

    //                if(TRS.get_double(crr_list[i], "CRR_QTY_1") - MWIPCRRLOT.QTY_1 > 0)
    //                {
    //                    if(TIV_carrier_attach_only_crrlot_qty(s_msg_code,
    //                                                            out_node,
    //                                                            in_node,
    //                                                            MWIPCRRLOT.LOT_ID,
    //                                                            MWIPCRRLOT.CRR_ID,
    //                                                            TRS.get_double(crr_list[i], "CRR_QTY_1") - MWIPCRRLOT.QTY_1,
    //                                                            TRS.get_double(crr_list[i], "CRR_QTY_2") - MWIPCRRLOT.QTY_2,
    //                                                            TRS.get_double(crr_list[i], "CRR_QTY_3") - MWIPCRRLOT.QTY_3) == MP_FALSE)
    //                    {
    //                        return MP_FALSE;
    //                    }
    //                }
    //                else if(TRS.get_double(crr_list[i], "CRR_QTY_1") - MWIPCRRLOT.QTY_1 < 0)
    //                {
    //                    if(TIV_carrier_detach_only_crrlot_qty(s_msg_code,
    //                                                            out_node,
    //                                                            in_node,
    //                                                            MWIPCRRLOT.LOT_ID,
    //                                                            MWIPCRRLOT.CRR_ID,
    //                                                            MWIPCRRLOT.QTY_1 - TRS.get_double(crr_list[i], "CRR_QTY_1"),
    //                                                            MWIPCRRLOT.QTY_2 - TRS.get_double(crr_list[i], "CRR_QTY_2"),
    //                                                            MWIPCRRLOT.QTY_3 - TRS.get_double(crr_list[i], "CRR_QTY_3")) == MP_FALSE)
    //                    {
    //                        return MP_FALSE;
    //                    }
    //                }
    //            }
    //        }
    //    }//end for
    //}//end if

    return MP_TRUE;
}

/*******************************************************************************
    TIV_Terminate_Carrier_Proc()
        - Main sub function of "TIV_Terminate_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Adapt_Lot_Terminate_Carrier(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node)
{
    //struct MWIPCRRLOT_TAG MWIPCRRLOT;
    //char carrier_flag;

    //carrier_flag = ' ';
    //if(RAS_check_carrier_exist(s_msg_code, 
    //                           out_node, 
    //                           '2', 
    //                           TRS.get_factory(in_node), 
    //                           " ", 
    //                           &carrier_flag) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    //if(carrier_flag != 'Y')
    //{
    //    return MP_TRUE; // Factory에 Carrier가 없으므로 그냥 Return 한다.
    //}

    //carrier_flag = ' ';
    //if(RAS_check_lot_in_carrier(s_msg_code, 
    //                            out_node, 
    //                            TRS.get_factory(in_node), 
    //                            TRS.get_string(in_node, "LOT_ID"), 
    //                            &carrier_flag) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    //if(carrier_flag != 'Y')
    //{
    //    return MP_TRUE; // Carrier에 없으므로 그냥 Return 한다.
    //}


    //DBC_init_mwipcrrlot(&MWIPCRRLOT);
    //TRS.copy(MWIPCRRLOT.FACTORY, sizeof(MWIPCRRLOT.FACTORY), in_node, IN_FACTORY);
    //TRS.copy(MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID), in_node, "LOT_ID");
    ///* Carrier List */
    //DBC_open_mwipcrrlot(3, &MWIPCRRLOT);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    strcpy(s_msg_code, "WIP-0004");
    //    TRS.add_fieldmsg(out_node, "MWIPCRRLOT OPEN", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCRRLOT.FACTORY), MWIPCRRLOT.FACTORY);
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
    //    TRS.add_dberrmsg(out_node, DB_error_msg);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    //while(1)
    //{
    //    DBC_fetch_mwipcrrlot(3, &MWIPCRRLOT);
    //    if(DB_error_code == DB_NOT_FOUND)
    //    {
    //        DBC_close_mwipcrrlot(3);
    //        break;
    //    }
    //    else if(DB_error_code != DB_SUCCESS) 
    //    {
    //        strcpy(s_msg_code, "WIP-0004");
    //        TRS.add_fieldmsg(out_node, "MWIPCRRLOT FETCH", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCRRLOT.FACTORY), MWIPCRRLOT.FACTORY);
    //        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;

    //        DBC_close_mwipcrrlot(3);
    //        return MP_FALSE;
    //    }

    //    if(TIV_carrier_detach_only_crrlot_qty(s_msg_code,
    //                                          out_node,
    //                                          in_node,
    //                                          MWIPCRRLOT.LOT_ID,
    //                                          MWIPCRRLOT.CRR_ID,
    //                                          MWIPCRRLOT.QTY_1,
    //                                          MWIPCRRLOT.QTY_2,
    //                                          MWIPCRRLOT.QTY_3) == MP_FALSE)
    //    {
    //        DBC_close_mwipcrrlot(3);
    //        return MP_FALSE;
    //    }
    //}

    return MP_TRUE;
}

#endif /* _CRR */

/*******************************************************************************
    TIV_Adapt_Change_Port_Status()
        - Main sub function of "TIV_ADAPT_LOT" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Adapt_Change_Port_Status(char *s_msg_code,
                                 TRSNode *in_node,
                                 struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                 struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                 TRSNode *out_node)
{
    /*TRSNode *change_port_in;

    if(MTIVLOTSTS_OLD->START_FLAG == 'Y' && COM_isspace(MTIVLOTSTS_OLD->START_RES_ID, sizeof(MTIVLOTSTS_OLD->START_RES_ID)) == MP_FALSE)
    {
        if(COM_isspace(MTIVLOTSTS_OLD->PORT_ID, sizeof(MTIVLOTSTS_OLD->PORT_ID)) == MP_FALSE)
        {
            if(memcmp(MTIVLOTSTS_OLD->START_RES_ID, MTIVLOTSTS->START_RES_ID, sizeof(MTIVLOTSTS_OLD->START_RES_ID)) == 0 &&
               TRS.mem_cmp(in_node, "PORT_ID", MTIVLOTSTS_OLD->PORT_ID, sizeof(MTIVLOTSTS_OLD->PORT_ID)) == 0)
            {
                return MP_TRUE;
            }

            change_port_in = TRS.create_node("CHANGE_PORT_IN");

            TRS.add_nstring(change_port_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
            TRS.add_char(change_port_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
            TRS.add_nstring(change_port_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
            TRS.add_nstring(change_port_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
            TRS.add_nstring(change_port_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
            TRS.add_nstring(change_port_in, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
            TRS.add_char(change_port_in, IN_PROCSTEP, '1');

            TRS.add_string(change_port_in, "LOT_ID", MTIVLOTSTS_OLD->LOT_ID, sizeof(MTIVLOTSTS_OLD->LOT_ID));
            TRS.add_nstring(change_port_in, "CRR_ID", TRS.get_string(in_node, "CRR_ID"));
            TRS.add_string(change_port_in, "RES_ID", MTIVLOTSTS_OLD->START_RES_ID, sizeof(MTIVLOTSTS_OLD->START_RES_ID));
            TRS.add_string(change_port_in, "PORT_ID", MTIVLOTSTS_OLD->PORT_ID, sizeof(MTIVLOTSTS_OLD->PORT_ID));
            TRS.add_string(change_port_in, "TRS_STATE", "RTL", strlen("RTL"));

            if(RAS_CHANGE_TRANSFER_STATE(s_msg_code, change_port_in, out_node) == MP_FALSE)
            {
                TRS.free_node(change_port_in);
                return MP_FALSE;
            }

            TRS.free_node(change_port_in);
        }
    }

    if(MTIVLOTSTS->LOT_DEL_FLAG == 'Y')
    {
        return MP_TRUE;
    }

    if(MTIVLOTSTS->START_FLAG == 'Y' && 
       COM_isspace(MTIVLOTSTS->START_RES_ID, sizeof(MTIVLOTSTS->START_RES_ID)) == MP_FALSE &&
       COM_isspace(MTIVLOTSTS->PORT_ID, sizeof(MTIVLOTSTS->PORT_ID)) == MP_FALSE)
    {
        change_port_in = TRS.create_node("CHANGE_PORT_IN");

        TRS.add_nstring(change_port_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
        TRS.add_char(change_port_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
        TRS.add_nstring(change_port_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
        TRS.add_nstring(change_port_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
        TRS.add_nstring(change_port_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
        TRS.add_nstring(change_port_in, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
        TRS.add_char(change_port_in, IN_PROCSTEP, '1');

        TRS.add_string(change_port_in, "LOT_ID", MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID));
        TRS.add_nstring(change_port_in, "CRR_ID", TRS.get_string(in_node, "TO_CRR_ID"));
        TRS.add_string(change_port_in, "RES_ID", MTIVLOTSTS->START_RES_ID, sizeof(MTIVLOTSTS->START_RES_ID));
        TRS.add_string(change_port_in, "PORT_ID", MTIVLOTSTS->PORT_ID, sizeof(MTIVLOTSTS->PORT_ID));
        TRS.add_nstring(change_port_in, "TRS_STATE", "TB");

        if(RAS_CHANGE_TRANSFER_STATE(s_msg_code, change_port_in, out_node) == MP_FALSE)
        {
            TRS.free_node(change_port_in);
            return MP_FALSE;
        }

        TRS.free_node(change_port_in);
    }
*/
    return MP_TRUE;
}

