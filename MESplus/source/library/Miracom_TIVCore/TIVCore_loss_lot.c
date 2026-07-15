/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_loss_lot.c
    Description : Loss Lot transaction function module

    MES Version : 4.0.0

    Function List
        - TIV_Loss_Lot()
            + Loss Lot
        - TIV_LOSS_LOT()
            + Main sub function of "TIV_Loss_Lot" function
            + Loss Lot definition
        - TIV_Loss_Lot_Validation()
            + Validation Check sub function of "TIV_LOSS_LOT" function
            + Check the conditions before Loss Lot definition
        - TIV_check_lot_cmf_create_loss_lot()
            + Check the Conditions before Create Child Lot CMF Definition
        - TIV_check_lot_cmf_loss_lot()
            + Check the Conditions before Loss Lot CMF Definition

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/15  Laverwon       Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"
 

//#ifdef _RAS
//#include <RASCore_common.h>
//#endif /* _RAS */

double d_total_loss_qty_1;
double d_total_loss_qty_2;
double d_total_loss_qty_3;

struct UnitInfo
{
    char code[10];
    double qty;
};

struct UnitInfo objUnit1Info[10];
struct UnitInfo objUnit2Info[10];
struct UnitInfo objUnit3Info[10];

int TIV_Loss_Lot_Validation(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node);

int TIV_check_lot_cmf_loss_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node);

int TIV_check_loss_unit_value(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node,
                            char *s_unit_list_name,
                            char *s_loss_code_table,
                            double *d_total_loss_qty, 
                            struct UnitInfo objUnitInfo[]);

int TIV_insert_loss_code_qty(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node,
                           char *s_unit_list_name,
                           struct MTIVLOTLSM_TAG *MTIVLOTLSM);

/*******************************************************************************
    TIV_Loss_Lot()
        - Loss Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Loss_Lot(TRSNode *in_node,
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
    TRS.copy(gs_alm_res_id, sizeof(gs_alm_res_id), in_node, "RES_ID");
    TRS.copy(gs_alm_source_id, sizeof(gs_alm_source_id), in_node, "LOT_ID");
    memcpy(gs_alm_module, MP_TRAN_CODE_LOSS, strlen(MP_TRAN_CODE_LOSS));
#endif /* _ALM */

    i_ret = TIV_LOSS_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_LOSS_LOT", out_node);

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
    TIV_LOSS_LOT()
        - Main sub function of "TIV_Loss_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_LOSS_LOT(char *s_msg_code,
                      TRSNode *in_node,
                      TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    struct MTIVLOTLOS_TAG MTIVLOTLOS;
    struct MTIVLOTLSM_TAG MTIVLOTLSM;
    //struct MWIPLOTLNR_TAG MWIPLOTLNR;
    //struct MGCMTBLDAT_TAG MGCMTBLDAT;
    //struct MTAPOPRTIV_TAG MTAPOPRINV;
	struct MTIVOPRDEF_TAG MTIVOPRDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
    
    char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];
	 
    int i, i_index;
    // Added by LAVERWON (2006/05/11)
    // Loss Qty가 0인 경우에도 MTIVLOTLOS Table에 Loss 정보를 추가
    int i_code_count;
    int b_exist_unit_list = MP_FALSE;

	int i_step;	 
	int i_last_active_hist_seq;

	TRSNode * IF_node;

    LOG_head("TIV_Loss_Lot");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("back_time", MP_NSTR, TRS.get_string(in_node, "BACK_TIME"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "TIV_LOT_ID"));
    LOG_add("LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    //LOG_add("flow", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    //LOG_add("flow_seq_num", MP_INT, TRS.get_int(in_node, "FLOW_SEQ_NUM"));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    /*LOG_add("crr_id", MP_NSTR, TRS.get_string(in_node, "CRR_ID"));
    if(TRS.get_list(in_node, "CRR_LIST") != 0x00)
    {
        LOG_add("crr_list_count", MP_INT, TRS.get_item_count(in_node, "CRR_LIST"));
    }*/
    LOG_add("out_qty_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY_1"));
    LOG_add("out_qty_2", MP_DBL, TRS.get_double(in_node, "OUT_QTY_2"));
    LOG_add("out_qty_3", MP_DBL, TRS.get_double(in_node, "OUT_QTY_3"));
    //LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("loss_type_flag", MP_CHR, TRS.get_char(in_node, "LOSS_TYPE_FLAG"));
    //LOG_add("cause_flow", MP_NSTR, TRS.get_string(in_node, "CAUSE_FLOW"));
    LOG_add("cause_oper", MP_NSTR, TRS.get_string(in_node, "CAUSE_OPER"));
    //LOG_add("cause_res_id", MP_NSTR, TRS.get_string(in_node, "CAUSE_RES_ID"));
    LOG_add("check_user_1", MP_NSTR, TRS.get_string(in_node, "CHECK_USER_1"));
    LOG_add("check_user_2", MP_NSTR, TRS.get_string(in_node, "CHECK_USER_2"));
    LOG_add("check_user_3", MP_NSTR, TRS.get_string(in_node, "CHECK_USER_3"));
   /* LOG_add("unit1_code_1", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_1"));
    LOG_add("unit1_code_2", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_2"));
    LOG_add("unit1_code_3", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_3"));
    LOG_add("unit1_code_4", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_4"));
    LOG_add("unit1_code_5", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_5"));
    LOG_add("unit1_code_6", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_6"));
    LOG_add("unit1_code_7", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_7"));
    LOG_add("unit1_code_8", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_8"));
    LOG_add("unit1_code_9", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_9"));
    LOG_add("unit1_code_10", MP_NSTR, TRS.get_string(in_node, "UNIT1_CODE_10"));
    LOG_add("unit1_qty_1", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_1"));
    LOG_add("unit1_qty_2", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_2"));
    LOG_add("unit1_qty_3", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_3"));
    LOG_add("unit1_qty_4", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_4"));
    LOG_add("unit1_qty_5", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_5"));
    LOG_add("unit1_qty_6", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_6"));
    LOG_add("unit1_qty_7", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_7"));
    LOG_add("unit1_qty_8", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_8"));
    LOG_add("unit1_qty_9", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_9"));
    LOG_add("unit1_qty_10", MP_DBL, TRS.get_double(in_node, "UNIT1_QTY_10"));
    LOG_add("unit2_code_1", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_1"));
    LOG_add("unit2_code_2", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_2"));
    LOG_add("unit2_code_3", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_3"));
    LOG_add("unit2_code_4", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_4"));
    LOG_add("unit2_code_5", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_5"));
    LOG_add("unit2_code_6", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_6"));
    LOG_add("unit2_code_7", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_7"));
    LOG_add("unit2_code_8", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_8"));
    LOG_add("unit2_code_9", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_9"));
    LOG_add("unit2_code_10", MP_NSTR, TRS.get_string(in_node, "UNIT2_CODE_10"));
    LOG_add("unit2_qty_1", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_1"));
    LOG_add("unit2_qty_2", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_2"));
    LOG_add("unit2_qty_3", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_3"));
    LOG_add("unit2_qty_4", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_4"));
    LOG_add("unit2_qty_5", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_5"));
    LOG_add("unit2_qty_6", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_6"));
    LOG_add("unit2_qty_7", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_7"));
    LOG_add("unit2_qty_8", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_8"));
    LOG_add("unit2_qty_9", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_9"));
    LOG_add("unit2_qty_10", MP_DBL, TRS.get_double(in_node, "UNIT2_QTY_10"));*/

    LOG_add("unit1_item_count", MP_INT, TRS.get_item_count(in_node, "UNIT1"));
    LOG_add("unit2_item_count", MP_INT, TRS.get_item_count(in_node, "UNIT2"));
    LOG_add("unit3_item_count", MP_INT, TRS.get_item_count(in_node, "UNIT3"));

   /* LOG_add("tran_cmf_1", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_1"));
    LOG_add("tran_cmf_2", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_2"));
    LOG_add("tran_cmf_3", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_3"));
    LOG_add("tran_cmf_4", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_4"));
    LOG_add("tran_cmf_5", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_5"));
    LOG_add("tran_cmf_6", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_6"));
    LOG_add("tran_cmf_7", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_7"));
    LOG_add("tran_cmf_8", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_8"));
    LOG_add("tran_cmf_9", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_9"));
    LOG_add("tran_cmf_10", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_10"));
    LOG_add("tran_cmf_11", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_11"));
    LOG_add("tran_cmf_12", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_12"));
    LOG_add("tran_cmf_13", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_13"));
    LOG_add("tran_cmf_14", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_14"));
    LOG_add("tran_cmf_15", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_15"));
    LOG_add("tran_cmf_16", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_16"));
    LOG_add("tran_cmf_17", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_17"));
    LOG_add("tran_cmf_18", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_18"));
    LOG_add("tran_cmf_19", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_19"));
    LOG_add("tran_cmf_20", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_20"));*/
    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
    LOG_add("loss_comment", MP_NSTR, TRS.get_string(in_node, "LOSS_COMMENT"));
    LOG_add("no_automatic_terminate_lot", MP_CHR, TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Loss_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    d_total_loss_qty_1 = 0;
    d_total_loss_qty_2 = 0;
    d_total_loss_qty_3 = 0;

    memset(s_erp_tran_time, ' ', sizeof(s_erp_tran_time));
	memset(s_tran_time, ' ', sizeof(s_tran_time));
	memset(s_sys_time, ' ', sizeof(s_sys_time));

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

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}

	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");
	 
    /* Validation Check */
    if(TIV_Loss_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    ///* Get TransTime */
    //if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
    //{
    //    memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
    //}
    //else
    //{
    //    TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
    //}


    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);    
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "INV_LOT_ID"); 
    TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "OPER");
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

	

    /* Update Status */
    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

	i_step = 10;
	i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS);

   /* TRS.copy(MTIVLOTSTS.CRR_ID, sizeof(MTIVLOTSTS.CRR_ID), in_node, "CRR_ID");
    if(TRS.get_list(in_node, "CRR_LIST") != 0x00)
    {
        TRS.copy(MTIVLOTSTS.CRR_ID, sizeof(MTIVLOTSTS.CRR_ID), TRS.get_list(in_node, "CRR_LIST")[0], "CRR_ID");
    }*/

    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_LOSS, strlen(MP_INV_TRAN_CODE_LOSS));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

	MTIVLOTSTS.IN_OUT_FLAG = 'O';
	MTIVLOTSTS.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
    //MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

    /*MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;*/

    MTIVLOTSTS.QTY_1  = TRS.get_double(in_node, "OUT_QTY_1");
    MTIVLOTSTS.QTY_2  = TRS.get_double(in_node, "OUT_QTY_2");
    MTIVLOTSTS.QTY_3  = TRS.get_double(in_node, "OUT_QTY_3");

    /* 전량 Loss인 경우 처리 */
    /* 2005.10.13. CM Koo. */
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
    
    //MTIVLOTSTS.IN_OUT_FLAG = ' ';

	d_total_loss_qty_1 = MTIVLOTSTS_OLD.QTY_1 - MTIVLOTSTS.QTY_1;
	d_total_loss_qty_2 = MTIVLOTSTS_OLD.QTY_2 - MTIVLOTSTS.QTY_2;
	d_total_loss_qty_3 = MTIVLOTSTS_OLD.QTY_3 - MTIVLOTSTS.QTY_3;

	TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");

    /* Insert History */
    DBC_init_mtivlothis(&MTIVLOTHIS);

	memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, d_total_loss_qty_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_2, d_total_loss_qty_1, sizeof(MTIVLOTHIS.TRAN_CMF_2));
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_3, d_total_loss_qty_3, sizeof(MTIVLOTHIS.TRAN_CMF_3));

	TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

	//memcpy(MTIVLOTSTS.LAST_TRAN_TYPE, objUnit1Info[0].code, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));

	DBC_init_mtivoprdef(&MTIVOPRDEF);
    TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "OPER");
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
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, MTIVOPRDEF.LOSS_TBL, sizeof(MGCMTBLDAT.TABLE_NAME));
    memcpy(MGCMTBLDAT.KEY_1,objUnit1Info[0].code,  strlen(objUnit1Info[0].code));
    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
       // memcpy(MTIVLOTHIS.TRAN_CMF_7, MGCMTBLDAT.DATA_1, sizeof(MTIVLOTHIS.TRAN_CMF_7));
    }


    if(TIV_update_insert_lot_status_history(s_msg_code, 
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



    /* Loss Table Insert */
    DBC_init_mtivlotlos(&MTIVLOTLOS);
    memcpy(MTIVLOTLOS.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTLOS.LOT_ID));
    MTIVLOTLOS.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;

    memcpy(MTIVLOTLOS.TRAN_TIME, MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTLOS.TRAN_TIME));
    MTIVLOTLOS.HIST_DEL_FLAG = MTIVLOTHIS.HIST_DEL_FLAG;

    memcpy(MTIVLOTLOS.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVLOTLOS.FACTORY));
    memcpy(MTIVLOTLOS.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTLOS.MAT_ID));
    MTIVLOTLOS.MAT_VER = MTIVLOTHIS.MAT_VER;
   /* memcpy(MTIVLOTLOS.FLOW, MTIVLOTHIS.FLOW, sizeof(MTIVLOTLOS.FLOW));
    MTIVLOTLOS.FLOW_SEQ_NUM = MTIVLOTHIS.FLOW_SEQ_NUM;*/
    memcpy(MTIVLOTLOS.OPER, MTIVLOTHIS.OPER, sizeof(MTIVLOTLOS.OPER));
    /*TRS.copy(MTIVLOTLOS.RES_ID, sizeof(MTIVLOTLOS.RES_ID), in_node, "RES_ID");

    TRS.copy(MTIVLOTLOS.CAUSE_FLOW, sizeof(MTIVLOTLOS.CAUSE_FLOW), in_node, "CAUSE_FLOW");
    TRS.copy(MTIVLOTLOS.CAUSE_OPER, sizeof(MTIVLOTLOS.CAUSE_OPER), in_node, "CAUSE_OPER");
    TRS.copy(MTIVLOTLOS.CAUSE_RES_ID, sizeof(MTIVLOTLOS.CAUSE_RES_ID), in_node, "CAUSE_RES_ID");*/

    // Added by LAVERWON (2006/05/11)
    // Bonus Qty가 0인 경우에도 MWIPLOTBNS Table에 Bonus 정보를 추가
    i_code_count = 0;    
    for (i = 0; i < 10; i++)
    {
        if(COM_isspace(objUnit1Info[i].code, sizeof(objUnit1Info[i].code)) == MP_FALSE) 
        {
            i_code_count ++;
        }
    }

    if(i_code_count > 0)
    {
        MTIVLOTLOS.QTY_FLAG = '1';
        MTIVLOTLOS.NEW_QTY = MTIVLOTSTS.QTY_1;
        MTIVLOTLOS.OLD_QTY = MTIVLOTSTS_OLD.QTY_1;
        MTIVLOTLOS.TOTAL_LOSS_QTY = d_total_loss_qty_1;

        memcpy(MTIVLOTLOS.LOSS_CODE_1, objUnit1Info[0].code, sizeof(MTIVLOTLOS.LOSS_CODE_1));
        memcpy(MTIVLOTLOS.LOSS_CODE_2, objUnit1Info[1].code, sizeof(MTIVLOTLOS.LOSS_CODE_2));
        memcpy(MTIVLOTLOS.LOSS_CODE_3, objUnit1Info[2].code, sizeof(MTIVLOTLOS.LOSS_CODE_3));
        memcpy(MTIVLOTLOS.LOSS_CODE_4, objUnit1Info[3].code, sizeof(MTIVLOTLOS.LOSS_CODE_4));
        memcpy(MTIVLOTLOS.LOSS_CODE_5, objUnit1Info[4].code, sizeof(MTIVLOTLOS.LOSS_CODE_5));
        memcpy(MTIVLOTLOS.LOSS_CODE_6, objUnit1Info[5].code, sizeof(MTIVLOTLOS.LOSS_CODE_6));
        memcpy(MTIVLOTLOS.LOSS_CODE_7, objUnit1Info[6].code, sizeof(MTIVLOTLOS.LOSS_CODE_7));
        memcpy(MTIVLOTLOS.LOSS_CODE_8, objUnit1Info[7].code, sizeof(MTIVLOTLOS.LOSS_CODE_8));
        memcpy(MTIVLOTLOS.LOSS_CODE_9, objUnit1Info[8].code, sizeof(MTIVLOTLOS.LOSS_CODE_9));
        memcpy(MTIVLOTLOS.LOSS_CODE_10, objUnit1Info[9].code, sizeof(MTIVLOTLOS.LOSS_CODE_10));
        MTIVLOTLOS.LOSS_QTY_1 = objUnit1Info[0].qty;
        MTIVLOTLOS.LOSS_QTY_2 = objUnit1Info[1].qty;
        MTIVLOTLOS.LOSS_QTY_3 = objUnit1Info[2].qty;
        MTIVLOTLOS.LOSS_QTY_4 = objUnit1Info[3].qty;
        MTIVLOTLOS.LOSS_QTY_5 = objUnit1Info[4].qty;
        MTIVLOTLOS.LOSS_QTY_6 = objUnit1Info[5].qty;
        MTIVLOTLOS.LOSS_QTY_7 = objUnit1Info[6].qty;
        MTIVLOTLOS.LOSS_QTY_8 = objUnit1Info[7].qty;
        MTIVLOTLOS.LOSS_QTY_9 = objUnit1Info[8].qty;
        MTIVLOTLOS.LOSS_QTY_10 = objUnit1Info[9].qty;

        TRS.copy(MTIVLOTLOS.LOSS_COMMENT_1, sizeof(MTIVLOTLOS.LOSS_COMMENT_1), in_node, "LOSS_COMMENT");

        DBC_insert_mtivlotlos(&MTIVLOTLOS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTLOS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTLOS.LOT_ID), MTIVLOTLOS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    // Added by LAVERWON (2006/05/11)
    // Bonus Qty가 0인 경우에도 MWIPLOTBNS Table에 Bonus 정보를 추가
    i_code_count = 0;    
    for (i = 0; i < 10; i++)
    {
        if(COM_isspace(objUnit2Info[i].code, sizeof(objUnit2Info[i].code)) == MP_FALSE) 
        {
            i_code_count ++;
        }
    }
    if(i_code_count > 0)
    {
        MTIVLOTLOS.QTY_FLAG = '2';
        MTIVLOTLOS.NEW_QTY = MTIVLOTSTS.QTY_2;
        MTIVLOTLOS.OLD_QTY = MTIVLOTSTS_OLD.QTY_2;
        MTIVLOTLOS.TOTAL_LOSS_QTY = d_total_loss_qty_2;

        memcpy(MTIVLOTLOS.LOSS_CODE_1, objUnit2Info[0].code, sizeof(MTIVLOTLOS.LOSS_CODE_1));
        memcpy(MTIVLOTLOS.LOSS_CODE_2, objUnit2Info[1].code, sizeof(MTIVLOTLOS.LOSS_CODE_2));
        memcpy(MTIVLOTLOS.LOSS_CODE_3, objUnit2Info[2].code, sizeof(MTIVLOTLOS.LOSS_CODE_3));
        memcpy(MTIVLOTLOS.LOSS_CODE_4, objUnit2Info[3].code, sizeof(MTIVLOTLOS.LOSS_CODE_4));
        memcpy(MTIVLOTLOS.LOSS_CODE_5, objUnit2Info[4].code, sizeof(MTIVLOTLOS.LOSS_CODE_5));
        memcpy(MTIVLOTLOS.LOSS_CODE_6, objUnit2Info[5].code, sizeof(MTIVLOTLOS.LOSS_CODE_6));
        memcpy(MTIVLOTLOS.LOSS_CODE_7, objUnit2Info[6].code, sizeof(MTIVLOTLOS.LOSS_CODE_7));
        memcpy(MTIVLOTLOS.LOSS_CODE_8, objUnit2Info[7].code, sizeof(MTIVLOTLOS.LOSS_CODE_8));
        memcpy(MTIVLOTLOS.LOSS_CODE_9, objUnit2Info[8].code, sizeof(MTIVLOTLOS.LOSS_CODE_9));
        memcpy(MTIVLOTLOS.LOSS_CODE_10, objUnit2Info[9].code, sizeof(MTIVLOTLOS.LOSS_CODE_10));
        MTIVLOTLOS.LOSS_QTY_1 = objUnit2Info[0].qty;
        MTIVLOTLOS.LOSS_QTY_2 = objUnit2Info[1].qty;
        MTIVLOTLOS.LOSS_QTY_3 = objUnit2Info[2].qty;
        MTIVLOTLOS.LOSS_QTY_4 = objUnit2Info[3].qty;
        MTIVLOTLOS.LOSS_QTY_5 = objUnit2Info[4].qty;
        MTIVLOTLOS.LOSS_QTY_6 = objUnit2Info[5].qty;
        MTIVLOTLOS.LOSS_QTY_7 = objUnit2Info[6].qty;
        MTIVLOTLOS.LOSS_QTY_8 = objUnit2Info[7].qty;
        MTIVLOTLOS.LOSS_QTY_9 = objUnit2Info[8].qty;
        MTIVLOTLOS.LOSS_QTY_10 = objUnit2Info[9].qty;

        TRS.copy(MTIVLOTLOS.LOSS_COMMENT_1, sizeof(MTIVLOTLOS.LOSS_COMMENT_1), in_node, "LOSS_COMMENT");

        DBC_insert_mtivlotlos(&MTIVLOTLOS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTLOS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTLOS.LOT_ID), MTIVLOTLOS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

    }
    i_code_count = 0;    
    for (i = 0; i < 10; i++)
    {
        if(COM_isspace(objUnit3Info[i].code, sizeof(objUnit3Info[i].code)) == MP_FALSE) 
        {
            i_code_count ++;
        }
    }
    if(i_code_count > 0)
    {
        MTIVLOTLOS.QTY_FLAG = '3';
        MTIVLOTLOS.NEW_QTY = MTIVLOTSTS.QTY_3;
        MTIVLOTLOS.OLD_QTY = MTIVLOTSTS_OLD.QTY_3;
        MTIVLOTLOS.TOTAL_LOSS_QTY = d_total_loss_qty_3;

        memcpy(MTIVLOTLOS.LOSS_CODE_1, objUnit3Info[0].code, sizeof(MTIVLOTLOS.LOSS_CODE_1));
        memcpy(MTIVLOTLOS.LOSS_CODE_2, objUnit3Info[1].code, sizeof(MTIVLOTLOS.LOSS_CODE_2));
        memcpy(MTIVLOTLOS.LOSS_CODE_3, objUnit3Info[2].code, sizeof(MTIVLOTLOS.LOSS_CODE_3));
        memcpy(MTIVLOTLOS.LOSS_CODE_4, objUnit3Info[3].code, sizeof(MTIVLOTLOS.LOSS_CODE_4));
        memcpy(MTIVLOTLOS.LOSS_CODE_5, objUnit3Info[4].code, sizeof(MTIVLOTLOS.LOSS_CODE_5));
        memcpy(MTIVLOTLOS.LOSS_CODE_6, objUnit3Info[5].code, sizeof(MTIVLOTLOS.LOSS_CODE_6));
        memcpy(MTIVLOTLOS.LOSS_CODE_7, objUnit3Info[6].code, sizeof(MTIVLOTLOS.LOSS_CODE_7));
        memcpy(MTIVLOTLOS.LOSS_CODE_8, objUnit3Info[7].code, sizeof(MTIVLOTLOS.LOSS_CODE_8));
        memcpy(MTIVLOTLOS.LOSS_CODE_9, objUnit3Info[8].code, sizeof(MTIVLOTLOS.LOSS_CODE_9));
        memcpy(MTIVLOTLOS.LOSS_CODE_10, objUnit3Info[9].code, sizeof(MTIVLOTLOS.LOSS_CODE_10));
        MTIVLOTLOS.LOSS_QTY_1 = objUnit3Info[0].qty;
        MTIVLOTLOS.LOSS_QTY_2 = objUnit3Info[1].qty;
        MTIVLOTLOS.LOSS_QTY_3 = objUnit3Info[2].qty;
        MTIVLOTLOS.LOSS_QTY_4 = objUnit3Info[3].qty;
        MTIVLOTLOS.LOSS_QTY_5 = objUnit3Info[4].qty;
        MTIVLOTLOS.LOSS_QTY_6 = objUnit3Info[5].qty;
        MTIVLOTLOS.LOSS_QTY_7 = objUnit3Info[6].qty;
        MTIVLOTLOS.LOSS_QTY_8 = objUnit3Info[7].qty;
        MTIVLOTLOS.LOSS_QTY_9 = objUnit3Info[8].qty;
        MTIVLOTLOS.LOSS_QTY_10 = objUnit3Info[9].qty;

        TRS.copy(MTIVLOTLOS.LOSS_COMMENT_1, sizeof(MTIVLOTLOS.LOSS_COMMENT_1), in_node, "LOSS_COMMENT");

        DBC_insert_mtivlotlos(&MTIVLOTLOS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTLOS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTLOS.LOT_ID), MTIVLOTLOS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    DBC_init_mtivlotlsm(&MTIVLOTLSM);
    memcpy(MTIVLOTLSM.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTLSM.LOT_ID));
    MTIVLOTLSM.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
    memcpy(MTIVLOTLSM.TRAN_TIME, MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTLSM.TRAN_TIME));

    memcpy(MTIVLOTLSM.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVLOTLSM.FACTORY));
    memcpy(MTIVLOTLSM.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTLSM.MAT_ID));
    MTIVLOTLSM.MAT_VER = MTIVLOTHIS.MAT_VER;
    /*memcpy(MTIVLOTLSM.FLOW, MTIVLOTHIS.FLOW, sizeof(MTIVLOTLSM.FLOW));
    MTIVLOTLSM.FLOW_SEQ_NUM = MTIVLOTHIS.FLOW_SEQ_NUM;*/
    memcpy(MTIVLOTLSM.OPER, MTIVLOTHIS.OPER, sizeof(MTIVLOTLSM.OPER));
    /*TRS.copy(MTIVLOTLSM.RES_ID, sizeof(MTIVLOTLSM.RES_ID), in_node, "RES_ID");*/

    /*DBC_init_mwiplotlnr(&MWIPLOTLNR);
    memcpy(MWIPLOTLNR.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MWIPLOTLNR.LOT_ID));
    MWIPLOTLNR.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
    memcpy(MWIPLOTLNR.TRAN_TIME, MTIVLOTHIS.TRAN_TIME, sizeof(MWIPLOTLNR.TRAN_TIME));

    memcpy(MWIPLOTLNR.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPLOTLNR.FACTORY));
    memcpy(MWIPLOTLNR.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MWIPLOTLNR.MAT_ID));
    MWIPLOTLNR.MAT_VER = MTIVLOTHIS.MAT_VER;
    memcpy(MWIPLOTLNR.FLOW, MTIVLOTHIS.FLOW, sizeof(MWIPLOTLNR.FLOW));
    MWIPLOTLNR.FLOW_SEQ_NUM = MTIVLOTHIS.FLOW_SEQ_NUM;
    memcpy(MWIPLOTLNR.OPER, MTIVLOTHIS.OPER, sizeof(MWIPLOTLNR.OPER));
    TRS.copy(MWIPLOTLNR.RES_ID, sizeof(MWIPLOTLNR.RES_ID), in_node, "RES_ID");*/

    for(i = 0; i < in_node->ListCount; i++)
    {
        if(memcmp(in_node->List[i]->Name, "UNIT", strlen("UNIT")) == 0)
        {
            b_exist_unit_list = MP_TRUE;
            break;
        }
    }
    if(b_exist_unit_list == MP_TRUE)
    {
        if(TRS.get_item_count(in_node, "UNIT1") > 0)
        {
            MTIVLOTLSM.QTY_FLAG = '1';
            MTIVLOTLSM.SEQ_NUM = 0;

            /*MWIPLOTLNR.QTY_FLAG = '1';
            MWIPLOTLNR.SEQ_NUM = 0;*/

            if(TIV_insert_loss_code_qty(s_msg_code,
                                      in_node,
                                      out_node,
                                      "UNIT1",
                                      &MTIVLOTLSM) == MP_FALSE)
            {
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        if(TRS.get_item_count(in_node, "UNIT2") > 0)
        {
            MTIVLOTLSM.QTY_FLAG = '2';
            MTIVLOTLSM.SEQ_NUM = 0;

            /*MWIPLOTLNR.QTY_FLAG = '2';
            MWIPLOTLNR.SEQ_NUM = 0;*/

            if(TIV_insert_loss_code_qty(s_msg_code,
                                      in_node,
                                      out_node,
                                      "UNIT2",
                                      &MTIVLOTLSM) == MP_FALSE)
            {
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        if(TRS.get_item_count(in_node, "UNIT3") > 0)
        {
            MTIVLOTLSM.QTY_FLAG = '3';
            MTIVLOTLSM.SEQ_NUM = 0;

       /*     MWIPLOTLNR.QTY_FLAG = '3';
            MWIPLOTLNR.SEQ_NUM = 0;*/

            if(TIV_insert_loss_code_qty(s_msg_code,
                                      in_node,
                                      out_node,
                                      "UNIT3",
                                      &MTIVLOTLSM) == MP_FALSE)
            {
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
    }
    else
    {        

        MTIVLOTLSM.QTY_FLAG = '1';
        i_index = 0;
        for (i = 0; i < 10; i++)
        {
            if(COM_isspace(objUnit1Info[i].code, sizeof(objUnit1Info[i].code)) == MP_FALSE) 
            {
                MTIVLOTLSM.SEQ_NUM = i_index + 1;
                memcpy(MTIVLOTLSM.LOSS_CODE, objUnit1Info[i].code, sizeof(MTIVLOTLSM.LOSS_CODE));
                MTIVLOTLSM.LOSS_QTY = objUnit1Info[i].qty;

                DBC_insert_mtivlotlsm(&MTIVLOTLSM);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MTIVLOTLSM INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTLSM.LOT_ID), MTIVLOTLSM.LOT_ID);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_TRANS;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                i_index ++;
            }
        }

        MTIVLOTLSM.QTY_FLAG = '2';
        i_index = 0;
        for (i = 0; i < 10; i++)
        {
            if(COM_isspace(objUnit2Info[i].code, sizeof(objUnit2Info[i].code)) == MP_FALSE) 
            {
                MTIVLOTLSM.SEQ_NUM = i_index + 1;
                memcpy(MTIVLOTLSM.LOSS_CODE, objUnit2Info[i].code, sizeof(MTIVLOTLSM.LOSS_CODE));
                MTIVLOTLSM.LOSS_QTY = objUnit2Info[i].qty;

                DBC_insert_mtivlotlsm(&MTIVLOTLSM);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MTIVLOTLSM INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTLSM.LOT_ID), MTIVLOTLSM.LOT_ID);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_TRANS;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                i_index ++;
            }
        }

        MTIVLOTLSM.QTY_FLAG = '3';
        i_index = 0;
        for (i = 0; i < 10; i++)
        {
            if(COM_isspace(objUnit3Info[i].code, sizeof(objUnit3Info[i].code)) == MP_FALSE) 
            {
                MTIVLOTLSM.SEQ_NUM = i_index + 1;
                memcpy(MTIVLOTLSM.LOSS_CODE, objUnit3Info[i].code, sizeof(MTIVLOTLSM.LOSS_CODE));
                MTIVLOTLSM.LOSS_QTY = objUnit3Info[i].qty;

                DBC_insert_mtivlotlsm(&MTIVLOTLSM);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MTIVLOTLSM INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTLSM.LOT_ID), MTIVLOTLSM.LOT_ID);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_TRANS;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                i_index ++;
            }
        }
    }

	if (TRS.get_char(in_node, "SKIP_IF_INFO_FLAG") != 'Y' && 
		COM_isnullspace(TRS.get_string(in_node, "MVT_CODE")) == MP_FALSE)
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
		TRS.add_nstring(IF_node, "BWART", TRS.get_string(in_node, "MVT_CODE"));
		TRS.add_nstring(IF_node, "ANLN1", TRS.get_string(in_node, "ANLN1"));
		TRS.add_string(IF_node, "MATNR", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
		TRS.add_string(IF_node, "MATNR1", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
 
		TRS.add_string(IF_node, "LGORT", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		TRS.add_string(IF_node, "LGORT1", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		//i_last_if_seq++; ?????
		//TRS.add_int(IF_node, "SEQNO", i_last_if_seq);
	 
		/*if (TRS.get_char(in_node, "MVT_PM") == 'P')
			TRS.add_double(IF_node, "MENGE", d_total_loss_qty_1);
		else
			TRS.add_double(IF_node, "MENGE", -1 * d_total_loss_qty_1);*/
		TRS.add_double(IF_node, "MENGE", d_total_loss_qty_1);
		TRS.add_string(IF_node, "ERNAM", "MES", strlen("MES"));
		TRS.add_string(IF_node, "ERDAT", s_sys_time, 8);
		TRS.add_string(IF_node, "ERZET", s_sys_time + 8, 6);
				
		TRS.add_string(IF_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));
		TRS.add_string(IF_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		TRS.add_int(IF_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
		TRS.add_string(IF_node, "MEINS", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));

		TRS.add_int(IF_node, "MAT_VER", MTIVLOTSTS.MAT_VER);

		TRS.add_char(IF_node, "ERP_IN_OUT_FLAG", TRS.get_char(in_node, "MVT_IN_OUT_FLAG"));
		TRS.add_char(IF_node, "ONLY_MOVE_INFO_FLAG", TRS.get_char(in_node, "ONLY_MOVE_INFO_FLAG"));
		
		//if (CUS_MES_To_ERP_Move(s_msg_code, IF_node, out_node) == MP_FALSE)
		//{
		//	TRS.free_node(IF_node);
		//	return MP_FALSE;
		//}
		TRS.free_node(IF_node);

	}

	if (TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG") == 'Y')
	{			
//		TRS.set_nstring(in_node, "LOT_ID", TRS.get_string(in_node, "TIV_LOT_ID"));		
//		//TRS.set_nstring(in_node, "OPER", TRS.get_string(in_node, "OPER"));
//		TRS.set_nstring(in_node, "MAT_ID", TRS.get_string(in_node, "TIV_MAT_ID"));
//		TRS.set_int(in_node, "MAT_VER", TRS.get_int(in_node, "TIV_MAT_VER"));
//		/*TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
//		TRS.set_string(in_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));
//*/
//		TRS.set_char(in_node, "IN_OUT_FLAG", 'O');
// 
//		TRS.set_double(in_node, "ADJUST_QTY_1",  d_total_loss_qty_1);
//
//		TRS.set_int(in_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
//
//		if (TIV_Create_Inventory_Adjust_Info(s_msg_code, in_node, out_node) == MP_FALSE)
//		{
//			return MP_FALSE;
//		}
	}

    /*if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y' && 
       MTIVLOTSTS.START_FLAG == 'Y' && COM_isspace(MTIVLOTSTS.START_RES_ID, sizeof(MTIVLOTSTS.START_RES_ID)) == MP_FALSE)
    {
        if(RAS_recount_proc_lot_resource(s_msg_code,
                                         out_node,
                                         MTIVLOTSTS.FACTORY,
                                         MTIVLOTSTS.START_RES_ID,
                                         EVENT_END_LOT) == MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }*/


//#ifdef _RCP
//    //레시피 삭제
//    if(TIV_delete_lot_recipe(s_msg_code,
//                             out_node,
//                             '1',
//                             MTIVLOTSTS.LOT_ID) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//#endif /* _RCP */
//
//
////Add J.S. 2008.09.03
//#ifdef _RTD
//    //Dispath된 리스트를 삭제
//    if(TIV_delete_dispatch_list(s_msg_code,
//                                out_node,
//                               '1',
//                               MTIVLOTSTS.LOT_ID) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//#endif /* _RTD */
//
//
//#ifdef _CRR
//    if(TIV_decrease_carrier_lot_qty(s_msg_code,
//                                    out_node,
//                                    in_node,
//                                    d_total_loss_qty_1,
//                                    d_total_loss_qty_2,
//                                    d_total_loss_qty_3) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//#endif /* _CRR */
//
//    /*batch 정보 삭제*/
//    if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
//    {
//        if(TIV_delete_lot_batch(s_msg_code,
//                            out_node,
//                            MTIVLOTSTS.FACTORY, 
//                            MTIVLOTSTS.LOT_ID) == MP_FALSE)
//        {
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//            return MP_FALSE;
//        }
//    }
//
//#ifdef _CRR
//    if(TIV_make_carrier_lot_history(s_msg_code, 
//                                    out_node, 
//                                    MTIVLOTSTS.LOT_ID) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//#endif /* _CRR */

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Loss_Lot",
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
         
        TRS.add_string(sum_in_node, "TRANC_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
        TRS.add_string(sum_in_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
        TRS.add_int(sum_in_node, "HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);

        if(COM_proc_user_routine("MES_UserTIV", "TIV_Loss_Lot",
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
    TIV_Loss_Lot_Validation()
        - Validation Check sub function of "TIV_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Loss_Lot_Validation(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{

    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;  
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    //struct MWIPFLWDEF_TAG MWIPFLWDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
    //int i_sublot_count;
    //struct MWIPSLTSTS_TAG MWIPSLTSTS;

    int i, j;
    char s_loss_code_table[20];
    int b_exist_unit_list = MP_FALSE;

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

    /*if(MWIPMATDEF.DELETE_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0276");
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
        strcpy(s_msg_code, "WIP-0330");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_LOGIC;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
*/
    if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0076");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Lot Hold Validation */
    if(MTIVLOTSTS.HOLD_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0059");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* Lot Instrasit Validation */
    /*if(MTIVLOTSTS.TRANSIT_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0060");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }*/
    
    /* Out Qty Validation */
    /* 2005.10.13. CM Koo. */
    //if(TRS.get_double(in_node, "OUT_QTY_1") < -0.00009)
    if(TRS.get_double(in_node, "OUT_QTY_1") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "OUT_QTY_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY_1"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    //if(TRS.get_double(in_node, "OUT_QTY_2") < -0.00009)
    if(TRS.get_double(in_node, "OUT_QTY_2") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "OUT_QTY_2", MP_DBL, TRS.get_double(in_node, "OUT_QTY_2"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    //if(TRS.get_double(in_node, "OUT_QTY_3") < -0.00009)
    if(TRS.get_double(in_node, "OUT_QTY_3") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "OUT_QTY_3", MP_DBL, TRS.get_double(in_node, "OUT_QTY_3"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    /* 소수점 4째 이하의 값은 무시 */
    //if(TRS.get_double(in_node, "OUT_QTY_1") > MTIVLOTSTS.QTY_1) 
    if(MTIVLOTSTS.QTY_1 - TRS.get_double(in_node, "OUT_QTY_1") < -0.0005) 
    {
        strcpy(s_msg_code, "WIP-0078");
        TRS.add_fieldmsg(out_node, "OUT_QTY_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY_1"));
        TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    memset(s_loss_code_table, ' ', sizeof(s_loss_code_table));
    //memcpy(s_loss_code_table, MTIVOPRDEF.LOSS_TBL, sizeof(MTIVOPRDEF.LOSS_TBL));	

	memcpy(s_loss_code_table, "C@LOSS_CODE", strlen("C@LOSS_CODE"));

    /* Modify by CM Koo. 2005.09.12. */
    /* 공정 LOSS Table이 정의되지 않았다면 에러 */
    if(COM_isspace(s_loss_code_table, sizeof(s_loss_code_table)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0303");
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVLOTSTS.MAT_VER);
        //TRS.add_fieldmsg(out_node, "FLOW", MP_STR, sizeof(MTIVLOTSTS.FLOW), MTIVLOTSTS.FLOW);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    memset(objUnit1Info, ' ', sizeof(objUnit1Info));
    memset(objUnit2Info, ' ', sizeof(objUnit2Info));
    memset(objUnit3Info, ' ', sizeof(objUnit3Info));

    for(i = 0; i < in_node->ListCount; i++)
    {
        if(memcmp(in_node->List[i]->Name, "UNIT", strlen("UNIT")) == 0)
        {
            b_exist_unit_list = MP_TRUE;
            break;
        }
    }
    if(b_exist_unit_list == MP_TRUE)
    {
        if(COM_isspace(MTIVOPRDEF.UNIT_1, sizeof(MTIVOPRDEF.UNIT_1)) == MP_FALSE)
        {
            d_total_loss_qty_1 = 0;
            if(TIV_check_loss_unit_value(s_msg_code,
                                       in_node,
                                       out_node,
                                       "UNIT1",
                                       s_loss_code_table,
                                       &d_total_loss_qty_1, 
                                       objUnit1Info) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }

        if(COM_isspace(MTIVOPRDEF.UNIT_2, sizeof(MTIVOPRDEF.UNIT_2)) == MP_FALSE)
        {
            d_total_loss_qty_2 = 0;
            if(TIV_check_loss_unit_value(s_msg_code,
                                       in_node,
                                       out_node,
                                       "UNIT2",
                                       s_loss_code_table,
                                       &d_total_loss_qty_2, 
                                       objUnit2Info) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }

        if(COM_isspace(MTIVOPRDEF.UNIT_3, sizeof(MTIVOPRDEF.UNIT_3)) == MP_FALSE)
        {
            d_total_loss_qty_3 = 0;
            if(TIV_check_loss_unit_value(s_msg_code,
                                       in_node,
                                       out_node,
                                       "UNIT3",
                                       s_loss_code_table,
                                       &d_total_loss_qty_3, 
                                       objUnit3Info) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }        
    }
    else
    {
        for(i = 0; i < 10; i ++)
        {
            char s_code_name[20];
            char s_qty_name[20];

            objUnit1Info[i].qty = 0;

            memset(s_code_name, 0x00, sizeof(s_code_name));
            memset(s_qty_name, 0x00, sizeof(s_qty_name));

            sprintf(s_code_name, "UNIT1_CODE_%d", i + 1);
            sprintf(s_qty_name, "UNIT1_QTY_%d", i + 1);

            if(COM_isnullspace(TRS.get_string(in_node, s_code_name)) == MP_FALSE)
            {
                TRS.copy(objUnit1Info[i].code, sizeof(objUnit1Info[i].code), in_node, s_code_name);
                objUnit1Info[i].qty  = TRS.get_double(in_node, s_qty_name);
            }
        }

        d_total_loss_qty_1 = 0;
        for (i = 0; i < 10; i++)
        {
            if(COM_isspace(objUnit1Info[i].code, sizeof(objUnit1Info[i].code)) == MP_FALSE)
            {
                d_total_loss_qty_1 = d_total_loss_qty_1 + objUnit1Info[i].qty;
                if(COM_check_gcm_data(s_msg_code, 
                                      out_node,
                                      s_loss_code_table,
                                      TRS.get_factory(in_node),
                                      objUnit1Info[i].code,
                                      sizeof(objUnit1Info[i].code)) == MP_FALSE)
                {
                    return MP_FALSE;
                }

                for (j = 0; j < i; j++)
                {
                    if(COM_isspace(objUnit1Info[j].code, sizeof(objUnit1Info[j].code)) == MP_FALSE)
                    {
                        if(memcmp(objUnit1Info[i].code, objUnit1Info[j].code, sizeof(objUnit1Info[i].code)) == 0)
                        {
                            strcpy(s_msg_code, "WIP-0079");
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_1", MP_STR, sizeof(objUnit1Info[i].code), objUnit1Info[i].code);
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_2", MP_STR, sizeof(objUnit1Info[j].code), objUnit1Info[j].code);

                            gs_log_type.type = MP_LOG_ERROR;
                            gs_log_type.e_type = MP_LOG_E_VALIDATION;
                            gs_log_type.category = MP_LOG_CATE_TRANS;
                            return MP_FALSE;
                        }
                    }
                }
            }
        }
        for(i = 0; i < 10; i ++)
        {
            char s_code_name[20];
            char s_qty_name[20];

            objUnit2Info[i].qty = 0;

            memset(s_code_name, 0x00, sizeof(s_code_name));
            memset(s_qty_name, 0x00, sizeof(s_qty_name));

            sprintf(s_code_name, "UNIT2_CODE_%d", i + 1);
            sprintf(s_qty_name, "UNIT2_QTY_%d", i + 1);

            if(COM_isnullspace(TRS.get_string(in_node, s_code_name)) == MP_FALSE)
            {
                TRS.copy(objUnit2Info[i].code, sizeof(objUnit2Info[i].code), in_node, s_code_name);
                objUnit2Info[i].qty  = TRS.get_double(in_node, s_qty_name);
            }
        }
        d_total_loss_qty_2 = 0;
        for (i = 0; i < 10; i++)
        {
            if(COM_isspace(objUnit2Info[i].code, sizeof(objUnit2Info[i].code)) == MP_FALSE)
            {
                d_total_loss_qty_2 = d_total_loss_qty_2 + objUnit2Info[i].qty;
                if(COM_check_gcm_data(s_msg_code, 
                                      out_node,
                                      s_loss_code_table,
                                      TRS.get_factory(in_node),
                                      objUnit2Info[i].code,
                                      sizeof(objUnit2Info[i].code)) == MP_FALSE)
                {
                    return MP_FALSE;
                }

                for (j = 0; j < i; j++)
                {
                    if(COM_isspace(objUnit2Info[j].code, sizeof(objUnit2Info[j].code)) == MP_FALSE)
                    {
                        if(memcmp(objUnit2Info[i].code, objUnit2Info[j].code, sizeof(objUnit2Info[i].code)) == 0)
                        {
                            strcpy(s_msg_code, "WIP-0079");
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_1", MP_STR, sizeof(objUnit2Info[i].code), objUnit2Info[i].code);
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_2", MP_STR, sizeof(objUnit2Info[j].code), objUnit2Info[j].code);

                            gs_log_type.type = MP_LOG_ERROR;
                            gs_log_type.e_type = MP_LOG_E_VALIDATION;
                            gs_log_type.category = MP_LOG_CATE_TRANS;
                            return MP_FALSE;
                        }
                    }
                }
            }
        }

        for(i = 0; i < 10; i ++)
        {
            char s_code_name[20];
            char s_qty_name[20];

            objUnit3Info[i].qty = 0;

            memset(s_code_name, 0x00, sizeof(s_code_name));
            memset(s_qty_name, 0x00, sizeof(s_qty_name));

            sprintf(s_code_name, "UNIT3_CODE_%d", i + 1);
            sprintf(s_qty_name, "UNIT3_QTY_%d", i + 1);

            if(COM_isnullspace(TRS.get_string(in_node, s_code_name)) == MP_FALSE)
            {
                TRS.copy(objUnit3Info[i].code, sizeof(objUnit3Info[i].code), in_node, s_code_name);
                objUnit3Info[i].qty  = TRS.get_double(in_node, s_qty_name);
            }
        }
        d_total_loss_qty_3 = 0;
        for (i = 0; i < 10; i++)
        {
            if(COM_isspace(objUnit3Info[i].code, sizeof(objUnit3Info[i].code)) == MP_FALSE)
            {
                d_total_loss_qty_3 = d_total_loss_qty_3 + objUnit3Info[i].qty;
                if(COM_check_gcm_data(s_msg_code, 
                                      out_node,
                                      s_loss_code_table,
                                      TRS.get_factory(in_node),
                                      objUnit3Info[i].code,
                                      sizeof(objUnit3Info[i].code)) == MP_FALSE)
                {
                    return MP_FALSE;
                }

                for (j = 0; j < i; j++)
                {
                    if(COM_isspace(objUnit3Info[j].code, sizeof(objUnit3Info[j].code)) == MP_FALSE)
                    {
                        if(memcmp(objUnit3Info[i].code, objUnit3Info[j].code, sizeof(objUnit3Info[i].code)) == 0)
                        {
                            strcpy(s_msg_code, "WIP-0079");
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_1", MP_STR, sizeof(objUnit3Info[i].code), objUnit3Info[i].code);
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_2", MP_STR, sizeof(objUnit3Info[j].code), objUnit3Info[j].code);

                            gs_log_type.type = MP_LOG_ERROR;
                            gs_log_type.e_type = MP_LOG_E_VALIDATION;
                            gs_log_type.category = MP_LOG_CATE_TRANS;
                            return MP_FALSE;
                        }
                    }
                }
            }
        }
    }
    /* 2009.02.24. Aiden. Loss 수량이 있는데 공정에 Unit 이 존재하는지 확인 */
    if(d_total_loss_qty_1 > 0 && COM_isspace(MTIVOPRDEF.UNIT_1, sizeof(MTIVOPRDEF.UNIT_1)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0382");
        TRS.add_fieldmsg(out_node, "UNIT_1", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOSS", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	if (d_total_loss_qty_1 <= 0 && d_total_loss_qty_2 <= 0 && d_total_loss_qty_3 <= 0 )
	{
		strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOSS_QTY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;    
	}

    /* 2005.10.13. CM Koo. */
    //if( fabs( (TRS.get_double(in_node, "OUT_QTY_1") + d_total_loss_qty_1) - MTIVLOTSTS.QTY_1 ) >= 0.00009 )
    
    if(TRS.get_char(in_node, "IQC_LOT")=='Y')
    {
        //Get History Qty
        DBC_init_mtivlothis(&MTIVLOTHIS);
        TRS.copy(MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "TIV_LOT_ID");
        MTIVLOTHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
        DBC_select_mtivlothis(3, &MTIVLOTHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "INV-0030");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);

            return MP_FALSE;
        }

        if(fabs((TRS.get_double(in_node, "OUT_QTY_1") + d_total_loss_qty_1) - MTIVLOTHIS.QTY_1) > 0)
        {
            strcpy(s_msg_code, "WIP-0080");
            TRS.add_fieldmsg(out_node, "UNIT1", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_QTY_1", MP_DBL, MTIVLOTHIS.QTY_1);
            TRS.add_fieldmsg(out_node, "OUT_QTY_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY_1"));
            TRS.add_fieldmsg(out_node, "TOTAL_LOSS_QTY_1", MP_DBL, d_total_loss_qty_1);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }
	else
	{
		if(TRS.get_char(in_node, "TERMINATE_FLAG") != 'Y')
		{
			if( fabs( (TRS.get_double(in_node, "OUT_QTY_1") + d_total_loss_qty_1) - MTIVLOTSTS.QTY_1 ) > 0.0005 )
			{
				strcpy(s_msg_code, "WIP-0080");
				TRS.add_fieldmsg(out_node, "UNIT1", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);
				TRS.add_fieldmsg(out_node, "OUT_QTY_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY_1"));
				TRS.add_fieldmsg(out_node, "TOTAL_LOSS_QTY_1", MP_DBL, d_total_loss_qty_1);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				return MP_FALSE;
			}
		}
	}

    /* 2009.02.24. Aiden. Loss 수량이 있는데 공정에 Unit 이 존재하는지 확인 */
    if(d_total_loss_qty_2 > 0 && COM_isspace(MTIVOPRDEF.UNIT_2, sizeof(MTIVOPRDEF.UNIT_2)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0382");
        TRS.add_fieldmsg(out_node, "UNIT_2", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOSS", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    //if( fabs( (TRS.get_double(in_node, "OUT_QTY_2") + d_total_loss_qty_2) - MTIVLOTSTS.QTY_2 ) >= 0.00009 )
    if( fabs( (TRS.get_double(in_node, "OUT_QTY_2") + d_total_loss_qty_2) - MTIVLOTSTS.QTY_2 ) > 0.0005 )
    {
        strcpy(s_msg_code, "WIP-0080");
        TRS.add_fieldmsg(out_node, "UNIT2", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_QTY_2", MP_DBL, MTIVLOTSTS.QTY_2);
        TRS.add_fieldmsg(out_node, "OUT_QTY_2", MP_DBL, TRS.get_double(in_node, "OUT_QTY_2"));
        TRS.add_fieldmsg(out_node, "TOTAL_LOSS_QTY_2", MP_DBL, d_total_loss_qty_2);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(d_total_loss_qty_3 > 0 && COM_isspace(MTIVOPRDEF.UNIT_3, sizeof(MTIVOPRDEF.UNIT_3)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0382");
        TRS.add_fieldmsg(out_node, "UNIT_3", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOSS", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    //if( fabs( (TRS.get_double(in_node, "OUT_QTY_2") + d_total_loss_qty_2) - MTIVLOTSTS.QTY_2 ) >= 0.00009 )
    if( fabs( (TRS.get_double(in_node, "OUT_QTY_3") + d_total_loss_qty_3) - MTIVLOTSTS.QTY_3 ) > 0.0005 )
    {
        strcpy(s_msg_code, "WIP-0080");
        TRS.add_fieldmsg(out_node, "UNIT3", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_QTY_3", MP_DBL, MTIVLOTSTS.QTY_3);
        TRS.add_fieldmsg(out_node, "OUT_QTY_3", MP_DBL, TRS.get_double(in_node, "OUT_QTY_3"));
        TRS.add_fieldmsg(out_node, "TOTAL_LOSS_QTY_3", MP_DBL, d_total_loss_qty_3);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

   /* if(TIV_check_carrier_lot_relation(s_msg_code,
                                      out_node,
                                      in_node,
                                      d_total_loss_qty_1) == MP_FALSE)
    {
        return MP_FALSE;
    }*/

    //if(TIV_check_lot_in_batch(MTIVLOTSTS.FACTORY, MTIVLOTSTS.LOT_ID) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "WIP-0417");
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    ///* CMF Validation */
    //if(TIV_check_lot_cmf_loss_lot(s_msg_code, in_node, out_node) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}


/*******************************************************************************
    TIV_check_lot_cmf_loss_lot()
        - Check the Conditions before Loss Lot CMF Definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_lot_cmf_loss_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node)
{
    struct check_list s_check_list;

    COM_fill_check_list(&s_check_list, in_node, 20, "TRAN_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_TRN_LOSS, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

/*******************************************************************************
    TIV_check_loss_unit_value()
        - Check unit value before LOSS Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_loss_unit_value(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node,
                            char *s_unit_list_name,
                            char *s_loss_code_table,
                            double *d_total_loss_qty, 
                            struct UnitInfo objUnitInfo[])
{
    int i;
    int i_item_count;
    TRSNode **loss_items;

    char *s_loss_code;
    char *s_loss_code_next;
    double d_loss_qty;
    double d_loss_qty_10;
    char c_no_scrap_flag;
    int j;

    d_loss_qty_10 = 0;
    i_item_count = TRS.get_item_count(in_node, s_unit_list_name);
    if(i_item_count > 0)
    {
        loss_items = TRS.get_list(in_node, s_unit_list_name);
        for(i = 0; i < i_item_count; i++)
        {
            s_loss_code = TRS.get_string(loss_items[i], "CODE");
            d_loss_qty = TRS.get_double(loss_items[i], "QTY");
            c_no_scrap_flag = TRS.get_char(loss_items[i], "NO_SCRAP_FLAG");

            if(COM_isnullspace(s_loss_code) == MP_FALSE && d_loss_qty != 0)
            {
                if(COM_check_gcm_data(s_msg_code, 
                                      out_node,
                                      s_loss_code_table,
                                      TRS.get_factory(in_node),
                                      s_loss_code,
                                      (int)strlen(s_loss_code)) == MP_FALSE)
                {
                    return MP_FALSE;
                }

                for (j = i + 1; j < i_item_count; j++)
                {
                    s_loss_code_next = TRS.get_string(loss_items[j], "CODE");

                    if(COM_isnullspace(s_loss_code_next) == MP_FALSE)
                    {
                        if(strcmp(s_loss_code_next, s_loss_code) == 0)
                        {
                            strcpy(s_msg_code, "WIP-0430");
                            TRS.add_fieldmsg(out_node, "UNIT", MP_NSTR, s_unit_list_name);
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_1", MP_NSTR, s_loss_code);
                            TRS.add_fieldmsg(out_node, "LOSS_CODE_2", MP_NSTR, s_loss_code_next);

                            gs_log_type.type = MP_LOG_ERROR;
                            gs_log_type.e_type = MP_LOG_E_VALIDATION;
                            gs_log_type.category = MP_LOG_CATE_TRANS;
                            return MP_FALSE;
                        }
                    }
                }

                if(c_no_scrap_flag == 'Y')
                {
                    d_loss_qty = 0;
                }

                *d_total_loss_qty += d_loss_qty;
                if(i < 9)
                {
                    strcpy(objUnitInfo[i].code, s_loss_code);
                    objUnitInfo[i].qty = d_loss_qty;
                }
                else
                {
                    d_loss_qty_10 += d_loss_qty;
                }

            }//endif COM_isnullspace(s_loss_code) == MP_FALSE && d_loss_qty != 0
        }//endfor
        if(d_loss_qty_10 > 0)
        {
            TRS.copy(objUnitInfo[9].code, sizeof(objUnitInfo[i].code), loss_items[9], "CODE");
            objUnitInfo[9].qty  = d_loss_qty_10;
        }
    }//endif i_item_count > 0

    return MP_TRUE;
}
/*******************************************************************************
    TIV_check_loss_unit_value()
        - Check unit value before LOSS Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_insert_loss_code_qty(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node,
                           char *s_unit_list_name,
                           struct MTIVLOTLSM_TAG *MTIVLOTLSM)
{
    int i;
    int i_item_count;
    TRSNode **loss_items;

    char *s_loss_code;
    double d_loss_qty;
    char c_no_scrap_flag;

    i_item_count = TRS.get_item_count(in_node, s_unit_list_name);
    if(i_item_count > 0)
    {
        loss_items = TRS.get_list(in_node, s_unit_list_name);
        for(i = 0; i < i_item_count; i++)
        {
            s_loss_code = TRS.get_string(loss_items[i], "CODE");
            d_loss_qty = TRS.get_double(loss_items[i], "QTY");
            c_no_scrap_flag = TRS.get_char(loss_items[i], "NO_SCRAP_FLAG");

            if(COM_isnullspace(s_loss_code) == MP_FALSE && d_loss_qty != 0)
            {
                if(c_no_scrap_flag == 'Y')
                {
                    /*MWIPLOTLNR->SEQ_NUM ++;
                    memset(MWIPLOTLNR->REASON_CODE, ' ', sizeof(MWIPLOTLNR->REASON_CODE));
                    memcpy(MWIPLOTLNR->REASON_CODE, s_loss_code, strlen(s_loss_code));
                    MWIPLOTLNR->REASON_QTY = d_loss_qty;

                    DBC_insert_mtivlotlnr(MWIPLOTLNR);
                    if(DB_error_code != DB_SUCCESS)
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_fieldmsg(out_node, "MWIPLOTLNR INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTLNR->LOT_ID), MWIPLOTLNR->LOT_ID);
                        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MWIPLOTLNR->HIST_SEQ);
                        TRS.add_fieldmsg(out_node, "QTY_FLAG", MP_CHR, MWIPLOTLNR->QTY_FLAG);
                        TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, MWIPLOTLNR->SEQ_NUM);
                        TRS.add_dberrmsg(out_node, DB_error_msg);

                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_TRANS;

                        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                        return MP_FALSE;
                    }*/

                    d_loss_qty = 0;
                }

                MTIVLOTLSM->SEQ_NUM ++;
                memset(MTIVLOTLSM->LOSS_CODE, ' ', sizeof(MTIVLOTLSM->LOSS_CODE));
                memcpy(MTIVLOTLSM->LOSS_CODE, s_loss_code, strlen(s_loss_code));
                MTIVLOTLSM->LOSS_QTY = d_loss_qty;

                DBC_insert_mtivlotlsm(MTIVLOTLSM);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MTIVLOTLSM INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTLSM->LOT_ID), MTIVLOTLSM->LOT_ID);
                    TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTLSM->HIST_SEQ);
                    TRS.add_fieldmsg(out_node, "QTY_FLAG", MP_CHR, MTIVLOTLSM->QTY_FLAG);
                    TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, MTIVLOTLSM->SEQ_NUM);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_TRANS;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }//endif COM_isnullspace(s_loss_code) == MP_FALSE && d_loss_qty != 0
        }//endfor
    }//endif i_item_count > 0

    return MP_TRUE;
}

