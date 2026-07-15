/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_lot_to_inv.c
    Description : Convert Lot To Inventory related function module

    MES Version : 4.0.0

    Function List
        - INV_Lot_To_Inv()
            + Convert Lot To Inventory
        - INV_Lot_To_Inv_Main()
            + Main Sub function of "INV_Lot_To_Inv"
            + (called by "INV_Lot_To_Inv")
        - INV_Lot_To_Inv_Validation()
            + Validation Check sub function of "INV_Lot_To_Inv_Main" function
            + (called by "INV_Lot_To_Inv_Main")
        - INV_Lot_To_Inv_Check_Cmf()
            + Check the Conditions before Convert Lot To Inventory CMF Definition
            + (called by "INV_Lot_To_Inv_Validation")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/13  HS Kim         Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int INV_Lot_To_Inv_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node);

int INV_Lot_To_Inv_Check_Cmf(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node);

int INV_delete_dispatch_list_LTI(char *s_msg_code,
                             TRSNode *out_node,
                             char c_proc_step,
                             char *s_lot_id_t);

/*******************************************************************************
    INV_Lot_To_Inv()
        - Convert Lot To Inventory
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - INV_Lot_To_Inv_In_Tag *Conv_To_Inv_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int INV_Lot_To_Inv(TRSNode *in_node, 
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = INV_LOT_TO_INV(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "INV_LOT_TO_INV", out_node);

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
    INV_LOT_TO_INV()
        - Main sub function of "INV_Lot_To_Inv" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - INV_LOT_TO_INV_IN_TAG *Conv_To_Inv_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int INV_LOT_TO_INV(char *s_msg_code,
                         TRSNode *in_node, 
                         TRSNode *out_node) 
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MWIPLOTSTS_TAG MWIPLOTSTS_OLD;
    struct MWIPLOTHIS_TAG MWIPLOTHIS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;

    char s_sys_time[14];
    char s_tran_time[14];
    int iInvExistFlag;

    LOG_head("INV_LOT_TO_INV");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("back_time", MP_NSTR, TRS.get_string(in_node, "BACK_TIME"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("last_active_hist_seq", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    LOG_add("to_inv_lot_id", MP_NSTR, TRS.get_string(in_node, "TO_INV_LOT_ID"));
    LOG_add("to_lot_desc", MP_NSTR, TRS.get_string(in_node, "TO_LOT_DESC"));
    LOG_add("to_mat_id", MP_NSTR, TRS.get_string(in_node, "TO_MAT_ID"));
    LOG_add("to_mat_ver", MP_INT, TRS.get_int(in_node, "TO_MAT_VER"));
    LOG_add("to_oper", MP_NSTR, TRS.get_string(in_node, "TO_OPER"));
    LOG_add("to_lot_type", MP_CHR, TRS.get_char(in_node, "TO_LOT_TYPE"));
    LOG_add("convert_qty_1", MP_DBL, TRS.get_double(in_node, "CONVERT_QTY_1"));
    LOG_add("convert_qty_2", MP_DBL, TRS.get_double(in_node, "CONVERT_QTY_2"));
    LOG_add("convert_qty_3", MP_DBL, TRS.get_double(in_node, "CONVERT_QTY_3"));
    LOG_add("alloc_qty", MP_DBL, TRS.get_double(in_node, "ALLOC_QTY"));
    LOG_add("tran_cmf_1", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_1"));
    LOG_add("tran_cmf_2", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_2"));
    LOG_add("tran_cmf_3", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_3"));
    LOG_add("tran_cmf_4", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_4"));
    LOG_add("tran_cmf_5", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_5"));
    LOG_add("tran_cmf_6", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_6"));
    LOG_add("tran_cmf_7", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_7"));
    LOG_add("tran_cmf_8", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_8"));
    LOG_add("tran_cmf_9", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_9"));
    LOG_add("tran_cmf_10", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_10"));
	LOG_add("inv_cmf_1", MP_NSTR, TRS.get_string(in_node, "INV_CMF_1"));
    LOG_add("inv_cmf_2", MP_NSTR, TRS.get_string(in_node, "INV_CMF_2"));
	LOG_add("inv_cmf_3", MP_NSTR, TRS.get_string(in_node, "INV_CMF_3"));
	LOG_add("inv_cmf_4", MP_NSTR, TRS.get_string(in_node, "INV_CMF_4"));
	LOG_add("inv_cmf_5", MP_NSTR, TRS.get_string(in_node, "INV_CMF_5"));
	LOG_add("inv_cmf_6", MP_NSTR, TRS.get_string(in_node, "INV_CMF_6"));
	LOG_add("inv_cmf_7", MP_NSTR, TRS.get_string(in_node, "INV_CMF_7"));
	LOG_add("inv_cmf_8", MP_NSTR, TRS.get_string(in_node, "INV_CMF_8"));
	LOG_add("inv_cmf_9", MP_NSTR, TRS.get_string(in_node, "INV_CMF_9"));
	LOG_add("inv_cmf_10", MP_NSTR, TRS.get_string(in_node, "INV_CMF_10"));
	LOG_add("inv_cmf_11", MP_NSTR, TRS.get_string(in_node, "INV_CMF_11"));
    LOG_add("inv_cmf_12", MP_NSTR, TRS.get_string(in_node, "INV_CMF_12"));
	LOG_add("inv_cmf_13", MP_NSTR, TRS.get_string(in_node, "INV_CMF_13"));
	LOG_add("inv_cmf_14", MP_NSTR, TRS.get_string(in_node, "INV_CMF_14"));
	LOG_add("inv_cmf_15", MP_NSTR, TRS.get_string(in_node, "INV_CMF_15"));
	LOG_add("inv_cmf_16", MP_NSTR, TRS.get_string(in_node, "INV_CMF_16"));
	LOG_add("inv_cmf_17", MP_NSTR, TRS.get_string(in_node, "INV_CMF_17"));
	LOG_add("inv_cmf_18", MP_NSTR, TRS.get_string(in_node, "INV_CMF_18"));
	LOG_add("inv_cmf_19", MP_NSTR, TRS.get_string(in_node, "INV_CMF_19"));
	LOG_add("inv_cmf_20", MP_NSTR, TRS.get_string(in_node, "INV_CMF_20"));
    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
    LOG_add("no_automatic_terminate_lot", MP_CHR, TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("INV", "INV_Lot_To_Inv",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    iInvExistFlag = 0;

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /*' Validation Check*/
    if(INV_Lot_To_Inv_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {        
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);    
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TO_INV_LOT_ID");    
    DBC_select_mtivlotsts_for_update(1, &MTIVLOTSTS_OLD);
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
    {
        strcpy(s_msg_code, "INV-0004");
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT FOR UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;            
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    else if(DB_error_code == DB_SUCCESS)
    {
        iInvExistFlag = MP_TRUE;        
    }    

    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

    memset(s_tran_time, ' ', sizeof(s_tran_time));
    
    if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
    {
        memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
    }
    else
    {
        TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS_OLD);
    TRS.copy(MWIPLOTSTS_OLD.LOT_ID, sizeof(MWIPLOTSTS_OLD.LOT_ID), in_node, "LOT_ID");

    DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS_OLD);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0044");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;            
        }
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS_OLD SELECT FOR UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS_OLD.LOT_ID), MWIPLOTSTS_OLD.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;            
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_TRAN_CODE_ALT_TO_INV, strlen(MP_TRAN_CODE_ALT_TO_INV));
    memset(MTIVLOTSTS.LAST_TRAN_TYPE, ' ', sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));    
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

    MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

    /*MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;*/

    MTIVLOTSTS.FROM_TO_FLAG = 'T';
    TRS.copy(MTIVLOTSTS.FROM_TO_LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID), in_node, "LOT_ID");

    if(iInvExistFlag == MP_TRUE)
    {
        MTIVLOTSTS.QTY_1 += TRS.get_double(in_node, "CONVERT_QTY_1");
        MTIVLOTSTS.QTY_2 += TRS.get_double(in_node, "CONVERT_QTY_2");
        MTIVLOTSTS.QTY_3 += TRS.get_double(in_node, "CONVERT_QTY_3");
    }
    else
    {
        TRS.copy(MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.MAT_ID), in_node, "TO_LOT_DESC");
        TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "TO_MAT_ID");
        MTIVLOTSTS.MAT_VER = TRS.get_int(in_node, "TO_MAT_VER");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TO_OPER");
        MTIVLOTSTS.LOT_TYPE = TRS.get_char(in_node, "TO_LOT_TYPE");
        memcpy(MTIVLOTSTS.CREATE_TIME, s_sys_time, sizeof(MTIVLOTSTS.CREATE_TIME));
        MTIVLOTSTS.IN_OUT_FLAG = ' ';
        TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), in_node, "PO_ID");
        TRS.copy(MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1), in_node, "UNIT");        
        TRS.copy(MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID), in_node, "VENDOR_LOT_ID");

        //memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS, sizeof(MTIVLOTSTS));

        DBC_init_mtivlothis(&MTIVLOTHIS);
        
        MTIVLOTSTS.CREATE_QTY_1 = TRS.get_double(in_node, "CONVERT_QTY_1");
        MTIVLOTSTS.CREATE_QTY_2 = TRS.get_double(in_node, "CONVERT_QTY_2");
        MTIVLOTSTS.CREATE_QTY_3 = TRS.get_double(in_node, "CONVERT_QTY_3");
        MTIVLOTSTS.QTY_1  = TRS.get_double(in_node, "CONVERT_QTY_1");
        MTIVLOTSTS.QTY_2  = TRS.get_double(in_node, "CONVERT_QTY_2");
        MTIVLOTSTS.QTY_3  = TRS.get_double(in_node, "CONVERT_QTY_3");
        MTIVLOTSTS.LAST_HIST_SEQ = 1;
        MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = 1;
    }

	TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_1");
	TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2), in_node, "INV_CMF_2");
	TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3), in_node, "INV_CMF_3");
	TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4), in_node, "INV_CMF_4");
	TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5), in_node, "INV_CMF_5");
	TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6), in_node, "INV_CMF_6");
	TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7), in_node, "INV_CMF_7");
	TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8), in_node, "INV_CMF_8");
	TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9), in_node, "INV_CMF_9");
	TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10), in_node, "INV_CMF_10");
	TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11), in_node, "INV_CMF_11");
	TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12), in_node, "INV_CMF_12");
	TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13), in_node, "INV_CMF_13");
	TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14), in_node, "INV_CMF_14");
	TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15), in_node, "INV_CMF_15");
	TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16), in_node, "INV_CMF_16");
	TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17), in_node, "INV_CMF_17");
	TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18), in_node, "INV_CMF_18");
	TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19), in_node, "INV_CMF_19");
	TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20), in_node, "INV_CMF_20");

    DBC_init_mtivlothis(&MTIVLOTHIS);

    memcpy(MTIVLOTHIS.FROM_TO_OPER, MWIPLOTSTS_OLD.OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));    
    MTIVLOTHIS.FROM_TO_QTY_1 = MWIPLOTSTS_OLD.QTY_1 - TRS.get_double(in_node, "CONVERT_QTY_1");
    MTIVLOTHIS.FROM_TO_QTY_2 = MWIPLOTSTS_OLD.QTY_2 - TRS.get_double(in_node, "CONVERT_QTY_2");
    MTIVLOTHIS.FROM_TO_QTY_3 = MWIPLOTSTS_OLD.QTY_3 - TRS.get_double(in_node, "CONVERT_QTY_3");
    MTIVLOTHIS.FROM_TO_HIST_SEQ = MWIPLOTSTS_OLD.LAST_HIST_SEQ + 1;

    if(INV_update_insert_lot_status_history(s_msg_code, 
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
   
    DBC_init_mwiplotsts(&MWIPLOTSTS);

    memcpy(&MWIPLOTSTS, &MWIPLOTSTS_OLD, sizeof(MWIPLOTSTS));
    if(COM_isspace(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS COPY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    //Modify by J.S. 2012.01.19 수량이 줄어야 하는데 정상적으로 처리 되지 않음.
    MWIPLOTSTS.QTY_1  = MWIPLOTSTS.QTY_1 - TRS.get_double(in_node, "CONVERT_QTY_1");
    MWIPLOTSTS.QTY_2  = MWIPLOTSTS.QTY_2 - TRS.get_double(in_node, "CONVERT_QTY_2");
    MWIPLOTSTS.QTY_3  = MWIPLOTSTS.QTY_2 - TRS.get_double(in_node, "CONVERT_QTY_3");

    memcpy(MWIPLOTSTS.LAST_TRAN_CODE, MP_TRAN_CODE_ALT_TO_INV, strlen(MP_TRAN_CODE_ALT_TO_INV));
    memcpy(MWIPLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MWIPLOTSTS.LAST_TRAN_TIME));
    MWIPLOTSTS.LAST_HIST_SEQ = MWIPLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ = MWIPLOTSTS_OLD.LAST_HIST_SEQ + 1;
    TRS.copy(MWIPLOTSTS.LAST_COMMENT, sizeof(MWIPLOTSTS.LAST_COMMENT), in_node, "TRAN_COMMENT");

    MWIPLOTSTS.FROM_TO_FLAG = 'F';
    memcpy(MWIPLOTSTS.FROM_TO_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.FROM_TO_LOT_ID));

    /*'전량 Convert인 경우 처리*/
    if(MWIPLOTSTS.QTY_1 < 0.00009 && MWIPLOTSTS.QTY_2 < 0.00009)
    {
        if(TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT") != 'Y')
        {
            MWIPLOTSTS.LOT_DEL_FLAG = 'Y';
            memcpy(MWIPLOTSTS.LOT_DEL_CODE, MP_WIP_AUTO_TERMINATE_CODE, sizeof(MWIPLOTSTS.LOT_DEL_CODE));
            memcpy(MWIPLOTSTS.LOT_DEL_TIME, s_tran_time, sizeof(MWIPLOTSTS.LOT_DEL_TIME));
        }
    }

    DBC_update_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /*'History Insert*/
    DBC_init_mwiplothis(&MWIPLOTHIS);

    memcpy(MWIPLOTHIS.OLD_FACTORY, MWIPLOTSTS_OLD.FACTORY, sizeof(MWIPLOTHIS.OLD_FACTORY));
    memcpy(MWIPLOTHIS.OLD_MAT_ID, MWIPLOTSTS_OLD.MAT_ID, sizeof(MWIPLOTHIS.OLD_MAT_ID));
    MWIPLOTHIS.OLD_MAT_VER = MWIPLOTSTS_OLD.MAT_VER; /* Add for V42 */

    memcpy(MWIPLOTHIS.OLD_FLOW, MWIPLOTSTS_OLD.FLOW, sizeof(MWIPLOTHIS.OLD_FLOW));
    memcpy(MWIPLOTHIS.OLD_OPER, MWIPLOTSTS_OLD.OPER, sizeof(MWIPLOTHIS.OLD_OPER));
    MWIPLOTHIS.OLD_LOT_TYPE = MWIPLOTSTS_OLD.LOT_TYPE;
    memcpy(MWIPLOTHIS.OLD_CREATE_CODE, MWIPLOTSTS_OLD.CREATE_CODE, sizeof(MWIPLOTHIS.OLD_CREATE_CODE));
    memcpy(MWIPLOTHIS.OLD_OWNER_CODE, MWIPLOTSTS_OLD.OWNER_CODE, sizeof(MWIPLOTHIS.OLD_OWNER_CODE));
    MWIPLOTHIS.OLD_QTY_1 = MWIPLOTSTS_OLD.QTY_1;
    MWIPLOTHIS.OLD_QTY_2 = MWIPLOTSTS_OLD.QTY_2;
    MWIPLOTHIS.OLD_QTY_3 = MWIPLOTSTS_OLD.QTY_3;
    MWIPLOTHIS.PREV_ACTIVE_HIST_SEQ = MWIPLOTSTS_OLD.LAST_ACTIVE_HIST_SEQ;

    memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
    MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
    memcpy(MWIPLOTHIS.TRAN_TIME, MWIPLOTSTS.LAST_TRAN_TIME, sizeof(MWIPLOTHIS.TRAN_TIME));
    memcpy(MWIPLOTHIS.SYS_TRAN_TIME, s_sys_time, sizeof(MWIPLOTHIS.SYS_TRAN_TIME));
    memcpy(MWIPLOTHIS.TRAN_CODE, MWIPLOTSTS.LAST_TRAN_CODE, sizeof(MWIPLOTHIS.TRAN_CODE));
    memcpy(MWIPLOTHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));

    memcpy(MWIPLOTHIS.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));
    MWIPLOTHIS.MAT_VER = MWIPLOTSTS.MAT_VER; /* Add for V42 */
    memcpy(MWIPLOTHIS.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTHIS.FLOW));
    MWIPLOTHIS.FLOW_SEQ_NUM = MWIPLOTSTS.FLOW_SEQ_NUM;
    memcpy(MWIPLOTHIS.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTHIS.OPER));

    MWIPLOTHIS.QTY_1 = MWIPLOTSTS.QTY_1;
    MWIPLOTHIS.QTY_2 = MWIPLOTSTS.QTY_2;
    MWIPLOTHIS.QTY_3 = MWIPLOTSTS.QTY_3;

    MWIPLOTHIS.CREATE_QTY_1 = MWIPLOTSTS.CREATE_QTY_1;
    MWIPLOTHIS.CREATE_QTY_2 = MWIPLOTSTS.CREATE_QTY_2;
    MWIPLOTHIS.CREATE_QTY_3 = MWIPLOTSTS.CREATE_QTY_3;

    MWIPLOTHIS.START_QTY_1 = MWIPLOTSTS.START_QTY_1;
    MWIPLOTHIS.START_QTY_2 = MWIPLOTSTS.START_QTY_2;
    MWIPLOTHIS.START_QTY_3 = MWIPLOTSTS.START_QTY_3;

    MWIPLOTHIS.LOT_TYPE = MWIPLOTSTS.LOT_TYPE;
    memcpy(MWIPLOTHIS.CREATE_CODE, MWIPLOTSTS.CREATE_CODE, sizeof(MWIPLOTHIS.CREATE_CODE));
    memcpy(MWIPLOTHIS.OWNER_CODE, MWIPLOTSTS.OWNER_CODE, sizeof(MWIPLOTHIS.OWNER_CODE));
    MWIPLOTHIS.LOT_PRIORITY = MWIPLOTSTS.LOT_PRIORITY;
    memcpy(MWIPLOTHIS.LOT_STATUS, MWIPLOTSTS.LOT_STATUS, sizeof(MWIPLOTHIS.LOT_STATUS));

    memcpy(MWIPLOTHIS.HOLD_CODE, MWIPLOTSTS.HOLD_CODE, sizeof(MWIPLOTHIS.HOLD_CODE));
    MWIPLOTHIS.HOLD_FLAG = MWIPLOTSTS.HOLD_FLAG;
    memcpy(MWIPLOTHIS.HOLD_PASSWORD, MWIPLOTSTS.HOLD_PASSWORD, sizeof(MWIPLOTHIS.HOLD_PASSWORD));
    /*'MWIPLOTHIS.RELEASE_CODE =*/

    MWIPLOTHIS.OPER_IN_QTY_1 = MWIPLOTSTS.OPER_IN_QTY_1;
    MWIPLOTHIS.OPER_IN_QTY_2 = MWIPLOTSTS.OPER_IN_QTY_2;
    MWIPLOTHIS.OPER_IN_QTY_3 = MWIPLOTSTS.OPER_IN_QTY_3;

    MWIPLOTHIS.INV_FLAG = MWIPLOTSTS.INV_FLAG;
    MWIPLOTHIS.TRANSIT_FLAG = MWIPLOTSTS.TRANSIT_FLAG;
    MWIPLOTHIS.START_FLAG = MWIPLOTSTS.START_FLAG;
    MWIPLOTHIS.END_FLAG = MWIPLOTSTS.END_FLAG;
    /*'MWIPLOTHIS.UNIT_TRACE_FLAG = MWIPLOTSTS*/
    memcpy(MWIPLOTHIS.INV_UNIT, MWIPLOTSTS.INV_UNIT, sizeof(MWIPLOTHIS.INV_UNIT));

    MWIPLOTHIS.RWK_FLAG = MWIPLOTSTS.RWK_FLAG;
    MWIPLOTHIS.RWK_RET_CLEAR_FLAG = MWIPLOTSTS.RWK_RET_CLEAR_FLAG;
    memcpy(MWIPLOTHIS.RWK_CODE, MWIPLOTSTS.RWK_CODE, sizeof(MWIPLOTHIS.RWK_CODE));
    MWIPLOTHIS.RWK_COUNT = MWIPLOTSTS.RWK_COUNT;
    memcpy(MWIPLOTHIS.RWK_RET_FLOW, MWIPLOTSTS.RWK_RET_FLOW, sizeof(MWIPLOTHIS.RWK_RET_FLOW));
    memcpy(MWIPLOTHIS.RWK_RET_OPER, MWIPLOTSTS.RWK_RET_OPER, sizeof(MWIPLOTHIS.RWK_RET_OPER));
    memcpy(MWIPLOTHIS.RWK_END_FLOW, MWIPLOTSTS.RWK_END_FLOW, sizeof(MWIPLOTHIS.RWK_END_FLOW));
    memcpy(MWIPLOTHIS.RWK_END_OPER, MWIPLOTSTS.RWK_END_OPER, sizeof(MWIPLOTHIS.RWK_END_OPER));

    MWIPLOTHIS.NSTD_FLAG = MWIPLOTSTS.NSTD_FLAG;
    memcpy(MWIPLOTHIS.NSTD_RET_FLOW, MWIPLOTSTS.NSTD_RET_FLOW, sizeof(MWIPLOTHIS.NSTD_RET_FLOW));
    memcpy(MWIPLOTHIS.NSTD_RET_OPER, MWIPLOTSTS.NSTD_RET_OPER, sizeof(MWIPLOTHIS.NSTD_RET_OPER));

    /*'MWIPLOTHIS.EVENT_ID = MRASRESDEF*/
    memcpy(MWIPLOTHIS.END_RES_ID, MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTHIS.END_RES_ID));
    /*'MWIPLOTHIS.RES_HIST_SEQ = MRASRESDEF*/

    /*'MWIPLOTHIS.COL_SET_ID = MWIPLOTSTS
    'MWIPLOTHIS.COL_SET_VERSION = MWIPLOTSTS*/

    MWIPLOTHIS.FROM_TO_FLAG = 'F';
    memcpy(MWIPLOTHIS.FROM_TO_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MWIPLOTHIS.FROM_TO_LOT_ID));
    memcpy(MWIPLOTHIS.FROM_TO_MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPLOTHIS.FROM_TO_MAT_ID));
    MWIPLOTHIS.FROM_TO_MAT_VER = MTIVLOTSTS.MAT_VER; /* ADD for V42 */
    memset(MWIPLOTHIS.FROM_TO_FLOW, ' ', sizeof(MWIPLOTHIS.FROM_TO_FLOW));
    memcpy(MWIPLOTHIS.FROM_TO_OPER, MTIVLOTSTS.OPER, sizeof(MWIPLOTHIS.FROM_TO_OPER));
    MWIPLOTHIS.FROM_TO_QTY_1 = MTIVLOTSTS.QTY_1;
    MWIPLOTHIS.FROM_TO_QTY_2 = MTIVLOTSTS.QTY_2;
    MWIPLOTHIS.FROM_TO_QTY_3 = MTIVLOTSTS.QTY_3;
    MWIPLOTHIS.FROM_TO_HIST_SEQ = MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ;

    memcpy(MWIPLOTHIS.CREATE_TIME, MWIPLOTSTS.CREATE_TIME, sizeof(MWIPLOTHIS.CREATE_TIME));

    memcpy(MWIPLOTHIS.SHIP_CODE, MWIPLOTSTS.SHIP_CODE, sizeof(MWIPLOTHIS.SHIP_CODE));
    memcpy(MWIPLOTHIS.SHIP_TIME, MWIPLOTSTS.SHIP_TIME, sizeof(MWIPLOTHIS.SHIP_TIME));

    memcpy(MWIPLOTHIS.ORG_DUE_TIME, MWIPLOTSTS.ORG_DUE_TIME, sizeof(MWIPLOTHIS.ORG_DUE_TIME));
    memcpy(MWIPLOTHIS.SCH_DUE_TIME, MWIPLOTSTS.SCH_DUE_TIME, sizeof(MWIPLOTHIS.SCH_DUE_TIME));

    memcpy(MWIPLOTHIS.FAC_IN_TIME, MWIPLOTSTS.FAC_IN_TIME, sizeof(MWIPLOTHIS.FAC_IN_TIME));
    memcpy(MWIPLOTHIS.FLOW_IN_TIME, MWIPLOTSTS.FLOW_IN_TIME, sizeof(MWIPLOTHIS.FLOW_IN_TIME));
    memcpy(MWIPLOTHIS.OPER_IN_TIME, MWIPLOTSTS.OPER_IN_TIME, sizeof(MWIPLOTHIS.OPER_IN_TIME));

    memcpy(MWIPLOTHIS.OLD_FAC_IN_TIME, MWIPLOTSTS_OLD.FAC_IN_TIME, sizeof(MWIPLOTHIS.FAC_IN_TIME));
    memcpy(MWIPLOTHIS.OLD_FLOW_IN_TIME, MWIPLOTSTS_OLD.FLOW_IN_TIME, sizeof(MWIPLOTHIS.FLOW_IN_TIME));
    memcpy(MWIPLOTHIS.OLD_OPER_IN_TIME, MWIPLOTSTS_OLD.OPER_IN_TIME, sizeof(MWIPLOTHIS.OPER_IN_TIME));

    memcpy(MWIPLOTHIS.LOT_CMF_1, MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));
    memcpy(MWIPLOTHIS.LOT_CMF_2, MWIPLOTSTS.LOT_CMF_2, sizeof(MWIPLOTHIS.LOT_CMF_2));
    memcpy(MWIPLOTHIS.LOT_CMF_3, MWIPLOTSTS.LOT_CMF_3, sizeof(MWIPLOTHIS.LOT_CMF_3));
    memcpy(MWIPLOTHIS.LOT_CMF_4, MWIPLOTSTS.LOT_CMF_4, sizeof(MWIPLOTHIS.LOT_CMF_4));
    memcpy(MWIPLOTHIS.LOT_CMF_5, MWIPLOTSTS.LOT_CMF_5, sizeof(MWIPLOTHIS.LOT_CMF_5));
    memcpy(MWIPLOTHIS.LOT_CMF_6, MWIPLOTSTS.LOT_CMF_6, sizeof(MWIPLOTHIS.LOT_CMF_6));
    memcpy(MWIPLOTHIS.LOT_CMF_7, MWIPLOTSTS.LOT_CMF_7, sizeof(MWIPLOTHIS.LOT_CMF_7));
    memcpy(MWIPLOTHIS.LOT_CMF_8, MWIPLOTSTS.LOT_CMF_8, sizeof(MWIPLOTHIS.LOT_CMF_8));
    memcpy(MWIPLOTHIS.LOT_CMF_9, MWIPLOTSTS.LOT_CMF_9, sizeof(MWIPLOTHIS.LOT_CMF_9));
    memcpy(MWIPLOTHIS.LOT_CMF_10, MWIPLOTSTS.LOT_CMF_10, sizeof(MWIPLOTHIS.LOT_CMF_10));

    MWIPLOTHIS.LOT_DEL_FLAG = MWIPLOTSTS.LOT_DEL_FLAG;
    memcpy(MWIPLOTHIS.LOT_DEL_CODE, MWIPLOTSTS.LOT_DEL_CODE, sizeof(MWIPLOTHIS.LOT_DEL_CODE));

    TRS.copy(MWIPLOTHIS.TRAN_CMF_1, sizeof(MWIPLOTHIS.TRAN_CMF_1), in_node, "TRAN_CMF_1");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_2, sizeof(MWIPLOTHIS.TRAN_CMF_2), in_node, "TRAN_CMF_2");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_3, sizeof(MWIPLOTHIS.TRAN_CMF_3), in_node, "TRAN_CMF_3");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_4, sizeof(MWIPLOTHIS.TRAN_CMF_4), in_node, "TRAN_CMF_4");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_5, sizeof(MWIPLOTHIS.TRAN_CMF_5), in_node, "TRAN_CMF_5");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_6, sizeof(MWIPLOTHIS.TRAN_CMF_6), in_node, "TRAN_CMF_6");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_7, sizeof(MWIPLOTHIS.TRAN_CMF_7), in_node, "TRAN_CMF_7");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_8, sizeof(MWIPLOTHIS.TRAN_CMF_8), in_node, "TRAN_CMF_8");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_9, sizeof(MWIPLOTHIS.TRAN_CMF_9), in_node, "TRAN_CMF_9");
    TRS.copy(MWIPLOTHIS.TRAN_CMF_10, sizeof(MWIPLOTHIS.TRAN_CMF_10), in_node, "TRAN_CMF_10");
    TRS.copy(MWIPLOTHIS.TRAN_COMMENT, sizeof(MWIPLOTHIS.TRAN_COMMENT), in_node, "TRAN_COMMENT");
    TRS.copy(MWIPLOTHIS.TRAN_USER_ID, sizeof(MWIPLOTHIS.TRAN_USER_ID), in_node, IN_USERID);

    /*'MWIPLOTHIS.HIST_DEL_FLAG = MWIPLOTSTS
    'MWIPLOTHIS.HIST_DEL_TIME = MWIPLOTSTS
    'MWIPLOTHIS.HIST_DEL_USER_ID = MWIPLOTSTS
    'MWIPLOTHIS.HIST_DEL_COMMENT = MWIPLOTSTS*/

    DBC_insert_mwiplothis(&MWIPLOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTHIS.FACTORY), MWIPLOTHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

 
//Add J.S. 2008.09.03
#ifdef _RTD
    //Dispath된 리스트를 삭제
    if(INV_delete_dispatch_list_LTI(s_msg_code,
                                out_node,
                               '1',
                               MWIPLOTSTS.LOT_ID) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
#endif /* _RTD */


    if(COM_proc_user_routine("INV", "INV_Lot_To_Inv",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    INV_Lot_To_Inv_Validation()
        - Validation Check sub function of "INV_Lot_To_Inv_Main" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - INV_LOT_TO_INV_IN_TAG *Conv_To_Inv_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int INV_Lot_To_Inv_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node) 
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    //struct MTIVLOTSTS_TAG MTIVLOTSTS;    
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MWIPOPRDEF_TAG MWIPOPRDEF;    
    struct MTIVOPRDEF_TAG MTIVOPRDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* WIP Check */
    TRS.set_nstring(in_node, "WIP_LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_int(in_node, "WIP_LAST_ACTIVE_HIST_SEQ", TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    /* validation input value */
    if(INV_lot_tran_validation_wip(s_msg_code,
                                out_node,
                                in_node,
                                &MWIPLOTSTS,
                                &MWIPFACDEF,
                                &MWIPMATDEF,
                                &MWIPOPRDEF) == MP_FALSE)
    {
        return MP_FALSE;
    }

     /*'Lot Hold Validation*/
    if(MWIPLOTSTS.HOLD_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0059");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /*'Lot Instrasit Validation*/
    if(MWIPLOTSTS.TRANSIT_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0060");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }


    /* INV Check */
    if(COM_isnullspace(TRS.get_string(in_node, "TO_INV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TO TO_INV_LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(COM_isnullspace(TRS.get_string(in_node, "TO_MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TO MAT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(COM_isnullspace(TRS.get_string(in_node, "TO_OPER")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TO INV_OPER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
   
    DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "TO_MAT_ID");
    MWIPMATDEF.MAT_VER  = TRS.get_int(in_node, "TO_MAT_VER"); /* Add for V42 */

    DBC_select_mwipmatdef(1, &MWIPMATDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0006");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "TO_MAT_ID");
    MTIVMATDEF.MAT_VER = TRS.get_int(in_node, "TO_MAT_VER");
    DBC_select_mtivmatdef(1, &MTIVMATDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0006");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }     
        TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    DBC_init_mwipoprdef(&MWIPOPRDEF);
    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "TO_OPER");
    DBC_select_mwipoprdef(1, &MWIPOPRDEF);
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
        }
        TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
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
            strcpy(s_msg_code, "WIP-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
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

    /*'Qty1/2/3 Validation*/
    if(TRS.get_double(in_node, "CONVERT_QTY_1") < 0)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(TRS.get_double(in_node, "CONVERT_QTY_2") < 0)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(TRS.get_double(in_node, "CONVERT_QTY_3") < 0)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(TRS.get_double(in_node, "CONVERT_QTY_1") > MWIPLOTSTS.QTY_1)
    {
        strcpy(s_msg_code, "WIP-0078");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);        
        TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MWIPLOTSTS.QTY_1);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(TRS.get_double(in_node, "CONVERT_QTY_2")  > MWIPLOTSTS.QTY_2)
    {
        strcpy(s_msg_code, "WIP-0078");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);        
        TRS.add_fieldmsg(out_node, "QTY_2", MP_DBL, MWIPLOTSTS.QTY_2);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(TRS.get_double(in_node, "CONVERT_QTY_3") > MWIPLOTSTS.QTY_3)
    {
        strcpy(s_msg_code, "WIP-0078");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);        
        TRS.add_fieldmsg(out_node, "QTY_3", MP_DBL, MWIPLOTSTS.QTY_3);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    //DBC_init_mtivlotsts(&MTIVLOTSTS);
    //TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
 //   TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "INV_LOT_ID");
    //TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TO_OPER");
    //DBC_select_mtivlotsts_for_update(1, &MTIVLOTSTS);
 //   if(DB_error_code != DB_SUCCESS)
 //   {
 //       if(DB_error_code == DB_NOT_FOUND)
 //       {
    //        // Continue            
 //       }
 //       else
 //       {
 //           strcpy(s_msg_code, "WIP-0004");
 //           gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //           TRS.add_dberrmsg(out_node, DB_error_msg);
    //        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.category = MP_LOG_CATE_COMMON;
    //        return MP_FALSE;
 //       }             
 //   }
    //else
    //{
    //    strcpy(s_msg_code, "WIP-0045");
 //       gs_log_type.e_type = MP_LOG_E_EXISTENCE;
    //    TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.category = MP_LOG_CATE_COMMON;
    //    return MP_FALSE;
    //}


    ///*'CMF Validation*/
    //if(INV_Lot_To_Inv_Check_Cmf(s_msg_code, in_node, out_node) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}
    return MP_TRUE;
}


/*******************************************************************************
    INV_Lot_To_Inv_Check_Cmf()
        - Check the Conditions before Conv To Inventory CMF Definition
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - INV_LOT_TO_INV_IN_TAG *Conv_To_Inv_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int INV_Lot_To_Inv_Check_Cmf(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct check_list s_check_list;

    /* CMF Validation Check */
    COM_fill_check_list(&s_check_list, in_node, 10, "TRAN_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_TRN_CONV_TO_INV, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }
    return MP_TRUE;
}

//
////Add by J.S. 2008.09.03
#ifdef _RTD
///*******************************************************************************
//    INV_delete_dispatch_list_LTI()
//        - 미리 Dispath된 리스트를 삭제한다.
//    Return Value
//        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
//    Arguments
//        - char *s_msg_code : Error Message Code 
//        - char *s_field_msg : Field Error Message
//        - char *s_db_err_msg : DB Error Message
//        - char c_proc_step
//        - char *s_lot_id : Lot ID
//*******************************************************************************/
int INV_delete_dispatch_list_LTI(char *s_msg_code,
                             TRSNode *out_node,
                             char c_proc_step,
                             char *s_lot_id_t)
{
    struct MRTDLOTPDS_TAG MRTDLOTPDS;
    struct MWIPLOTSTS_TAG MWIPLOTSTS;

    char s_lot_id[25];

    COM_memcpy(s_lot_id, s_lot_id_t, sizeof(s_lot_id));

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    memcpy(MWIPLOTSTS.LOT_ID, s_lot_id, sizeof(MWIPLOTSTS.LOT_ID));
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    //CREATE를 삭제한 경우나, SPLIT MERGE시 LOT이 삭제된 경우 Dispatch 정보를 지운다.
    //Receive가 DLLH되는 경우도 삭제한다.
    if(DB_error_code == DB_NOT_FOUND || MWIPLOTSTS.LOT_DEL_FLAG == 'Y' || ( MWIPLOTSTS.QTY_1 < 0.0005 && MWIPLOTSTS.QTY_2 < 0.0005 ) )
    {
        DBC_init_mrtdlotpds(&MRTDLOTPDS);
        memcpy(MRTDLOTPDS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MRTDLOTPDS.FACTORY));
        memcpy(MRTDLOTPDS.LOT_ID, s_lot_id, sizeof(MRTDLOTPDS.LOT_ID));
        DBC_delete_mrtdlotpds(2, &MRTDLOTPDS);
        if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MRTDLOTPDS DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRTDLOTPDS.FACTORY), MRTDLOTPDS.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MRTDLOTPDS.LOT_ID), MRTDLOTPDS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

#endif /* _RTD */

