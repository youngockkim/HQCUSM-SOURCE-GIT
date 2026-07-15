/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_Split_Lot.c
    Description : Split Lot transaction function module

    MES Version : 4.0.0

    Function List
        - TIV_Split_Lot()
            + Split Lot
        - TIV_Split_Lot()
            + Main sub function of "TIV_Split_Lot" function
            + Split Lot definition
        - TIV_Split_Lot_Validation()
            + Validation Check sub function of "TIV_Split_Lot" function
            + Check the conditions before Split Lot definition
        - TIV_check_lot_cmf_split_lot()
            + Check the Conditions before Create Child Lot CMF Definition
        - TIV_check_tran_cmf_split_lot()
            + Check the Conditions before Split Lot CMF Definition

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/14  Laverwon       Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
//
//#include "WIPCore_common.h"
#include <BASCore_common.h>
//
//#ifdef _RAS
//#include <RASCore_common.h>
//#endif /* _RAS */
//#ifdef _ALM
//#include <ALMCore_common.h>
//#endif
#include "TIVCore_common.h"

 


int TIV_Split_Lot_Fill_InTag(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node);

int TIV_Split_Lot_Validation(char *s_msg_code,
                             TRSNode *in_node,
                             TRSNode *out_node);

int TIV_check_lot_cmf_split_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node);

int TIV_check_tran_cmf_split_lot(char *s_msg_code,
                                 TRSNode *in_node,
                                 TRSNode *out_node);

int TIV_copy_attribute(char *s_msg_code,
                       TRSNode *in_node,
                       TRSNode *out_node);

/*******************************************************************************
    TIV_Split_Lot()
        - Split Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Split_Lot(TRSNode *in_node,
                 TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MATRNAMSTS_TAG MATRNAMSTS;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    LOG_head("TIV_Split_Lot");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") > 0)
    {
        DBC_init_mtivlotsts(&MTIVLOTSTS);
        TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "TIV_LOT_ID");        
		//TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");        

        DBC_select_mtivlotsts(20, &MTIVLOTSTS);
        if(DB_error_code != DB_SUCCESS) 
        {
            if(DB_error_code == DB_NOT_FOUND) 
            {
                strcpy(s_msg_code, "WIP-0044");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
            else 
            {
                strcpy(s_msg_code, "WIP-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }

            TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            COM_out_msg_log_write(s_msg_code, "TIV_Split_Lot", out_node);
            return MP_TRUE;
        }

        if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ)
        {
            strcpy(s_msg_code, "WIP-0113");
            TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
            TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            COM_out_msg_log_write(s_msg_code, "TIV_Split_Lot", out_node);
            return MP_TRUE;
        }
    }

    i_ret = TIV_SPLIT_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_SPLIT_LOT", out_node);

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
    TIV_Split_Lot()
        - Main sub function of "TIV_Split_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_SPLIT_LOT(char *s_msg_code,
                      TRSNode *in_node,
                      TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_CHILD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    //struct MWIPLOTSPL_TAG MWIPLOTSPL;

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
	//struct MATRNAMSTS_TAG MATRNAMSTS;

    char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];
	 
	int i_step;	 
	int i_last_active_hist_seq;


    LOG_head("TIV_Split_Lot");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("back_time", MP_NSTR, TRS.get_string(in_node, "BACK_TIME"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "lot_id"));
    LOG_add("LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
 
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
   
    LOG_add("move_qty_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
    LOG_add("move_qty_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
    LOG_add("move_qty_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));
    LOG_add("child_lot_id", MP_NSTR, TRS.get_string(in_node, "CHILD_LOT_ID"));
    LOG_add("child_lot_desc", MP_NSTR, TRS.get_string(in_node, "CHILD_LOT_DESC"));
    LOG_add("child_mat_id", MP_NSTR, TRS.get_string(in_node, "CHILD_MAT_ID"));
    LOG_add("child_mat_ver", MP_INT, TRS.get_int(in_node, "CHILD_MAT_VER"));
    LOG_add("child_flow", MP_NSTR, TRS.get_string(in_node, "CHILD_FLOW"));
    LOG_add("child_flow_seq_num", MP_INT, TRS.get_int(in_node, "CHILD_FLOW_SEQ_NUM"));
    LOG_add("child_oper", MP_NSTR, TRS.get_string(in_node, "CHILD_OPER"));
    LOG_add("child_crr_id", MP_NSTR, TRS.get_string(in_node, "CHILD_CRR_ID"));
  
    LOG_add("child_lot_type", MP_CHR, TRS.get_char(in_node, "CHILD_LOT_TYPE"));   
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
    if(TRS.get_list(in_node, "INPUT_ATTRIBUTE") != 0x00)
        LOG_add("INPUT_ATTRIBUTE", MP_CHR, 'Y');
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Split_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

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

	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}
	

	if(COM_isnullspace(TRS.get_string(in_node, "SHIP_FACTORY")) ==  MP_FALSE)
	{
		TRS.set_nstring(in_node, "FACTORY", TRS.get_string(in_node, "SHIP_FACTORY"));
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");	
	 
    if(TIV_Split_Lot_Fill_InTag(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Validation Check */
    if(TIV_Split_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");        
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
		TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_OLD.OPER), MTIVLOTSTS_OLD.OPER);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Select Lot Material infor ********************************************************/
    /*DBC_init_mtivmatdef(&MTIVMATDEF);
    memcpy(MTIVMATDEF.FACTORY, MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVMATDEF.FACTORY));
    memcpy(MTIVMATDEF.MAT_ID, MTIVLOTSTS_OLD.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
    MTIVMATDEF.MAT_VER = MTIVLOTSTS_OLD.MAT_VER;
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
    }*/

    /* Update Lot Status (Mother) **************************************************************/
    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));
    memcpy(&MTIVLOTSTS_CHILD, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS_CHILD));

	i_step = 10;
	i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS);

    MTIVLOTSTS.FROM_TO_FLAG = 'F';
    TRS.copy(MTIVLOTSTS.FROM_TO_LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID), in_node, "CHILD_LOT_ID");
	MTIVLOTSTS.FROM_TO_HIST_SEQ = 1;
    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_SPLIT, strlen(MP_INV_TRAN_CODE_SPLIT));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");  
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

	memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");


	MTIVLOTSTS.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
    //MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

    MTIVLOTSTS.QTY_1 = MTIVLOTSTS.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1");
    MTIVLOTSTS.QTY_2 = MTIVLOTSTS.QTY_2 - TRS.get_double(in_node, "MOVE_QTY_2");
    MTIVLOTSTS.QTY_3 = MTIVLOTSTS.QTY_3 - TRS.get_double(in_node, "MOVE_QTY_3");

    MTIVLOTSTS.IN_OUT_FLAG = ' ';

    /* 2018.04.23 JWLEE 
     * 증평 셀은 ERP에서 재고 정보가 넘어오지 않으므로 Validation 하지 않음
     */
    DBC_init_mwipmatdef(&MWIPMATDEF);
    memcpy(MWIPMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
    memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.LOT_ID));
    MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
    DBC_select_mwipmatdef(1, &MWIPMATDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        TRS.add_dberrmsg(out_node, DB_error_msg);
  
        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);        
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(memcmp(MWIPMATDEF.MAT_GRP_1,"PS",strlen("PS")) == 0)
    {
    }
    else
    {
        /* 전량 Split인 경우 처리 */
        if(MTIVLOTSTS.QTY_1 < 0.0005 && MTIVLOTSTS.QTY_2 < 0.0005)
        {
            if(TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT") != 'Y')
            {
                MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
                memcpy(MTIVLOTSTS.LOT_DEL_REASON, "QTY_ZERO", strlen("QTY_ZERO"));
                memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_tran_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
                TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, "PRC_USER");
            }
        }
    }

	if (TRS.get_char(in_node, "SHIP_RTN_FLAG") != 'Y')
	{
		/* Select Child Lot operation infor ********************************************************/
		DBC_init_mtivoprdef(&MTIVOPRDEF);
		TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "OPER");
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
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

	}
    

    /* Child Lot 관련 Update *******************************************************************/
    TRS.copy(MTIVLOTSTS_CHILD.LOT_ID, sizeof(MTIVLOTSTS_CHILD.LOT_ID), in_node, "CHILD_LOT_ID");
    TRS.copy(MTIVLOTSTS_CHILD.LOT_DESC, sizeof(MTIVLOTSTS_CHILD.LOT_DESC), in_node, "CHILD_LOT_DESC");
    TRS.copy(MTIVLOTSTS_CHILD.MAT_ID, sizeof(MTIVLOTSTS_CHILD.MAT_ID), in_node, "CHILD_MAT_ID");
    MTIVLOTSTS_CHILD.MAT_VER  = TRS.get_int(in_node, "CHILD_MAT_VER");
  
	if (COM_isnullspace(TRS.get_string(in_node, "CHILD_CREATE_CODE")) == MP_FALSE)
	{
		memset(MTIVLOTSTS_CHILD.CREATE_CODE, ' ', sizeof(MTIVLOTSTS_CHILD.CREATE_CODE));
		TRS.copy(MTIVLOTSTS_CHILD.CREATE_CODE, sizeof(MTIVLOTSTS_CHILD.CREATE_CODE), in_node, "CHILD_CREATE_CODE");
	}

    TRS.copy(MTIVLOTSTS_CHILD.OPER, sizeof(MTIVLOTSTS_CHILD.OPER), in_node, "CHILD_OPER");

    MTIVLOTSTS_CHILD.CREATE_QTY_1 = TRS.get_double(in_node, "MOVE_QTY_1");
    MTIVLOTSTS_CHILD.CREATE_QTY_2 = TRS.get_double(in_node, "MOVE_QTY_2");
    MTIVLOTSTS_CHILD.CREATE_QTY_3 = TRS.get_double(in_node, "MOVE_QTY_3");
    
    MTIVLOTSTS_CHILD.QTY_1 = TRS.get_double(in_node, "MOVE_QTY_1");
    MTIVLOTSTS_CHILD.QTY_2 = TRS.get_double(in_node, "MOVE_QTY_2");
    MTIVLOTSTS_CHILD.QTY_3 = TRS.get_double(in_node, "MOVE_QTY_3");

    MTIVLOTSTS_CHILD.LOT_TYPE  = TRS.get_char(in_node, "CHILD_LOT_TYPE");
  
    //TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_1, sizeof(MTIVLOTSTS_CHILD.INV_CMF_1), in_node, "INV_CMF_1");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_2, sizeof(MTIVLOTSTS_CHILD.INV_CMF_2), in_node, "INV_CMF_2");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_3, sizeof(MTIVLOTSTS_CHILD.INV_CMF_3), in_node, "INV_CMF_3");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_4, sizeof(MTIVLOTSTS_CHILD.INV_CMF_4), in_node, "INV_CMF_4");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_5, sizeof(MTIVLOTSTS_CHILD.INV_CMF_5), in_node, "INV_CMF_5");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_6, sizeof(MTIVLOTSTS_CHILD.INV_CMF_6), in_node, "INV_CMF_6");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_7, sizeof(MTIVLOTSTS_CHILD.INV_CMF_7), in_node, "INV_CMF_7");

	if (TRS.get_char(in_node, "IGNORE_INPUT_STS") == 'Y')
	{
		memset(MTIVLOTSTS_CHILD.INV_CMF_8, ' ', sizeof(MTIVLOTSTS_CHILD.INV_CMF_8));
		memset(MTIVLOTSTS_CHILD.INV_CMF_9, ' ', sizeof(MTIVLOTSTS_CHILD.INV_CMF_9));
	}
	else
	{
		TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_8, sizeof(MTIVLOTSTS_CHILD.INV_CMF_8), in_node, "INV_CMF_8");
		TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_9, sizeof(MTIVLOTSTS_CHILD.INV_CMF_9), in_node, "INV_CMF_9");
	}
    
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_10, sizeof(MTIVLOTSTS_CHILD.INV_CMF_10), in_node, "INV_CMF_10");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_11, sizeof(MTIVLOTSTS_CHILD.INV_CMF_11), in_node, "INV_CMF_11");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_12, sizeof(MTIVLOTSTS_CHILD.INV_CMF_12), in_node, "INV_CMF_12");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_13, sizeof(MTIVLOTSTS_CHILD.INV_CMF_13), in_node, "INV_CMF_13");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_14, sizeof(MTIVLOTSTS_CHILD.INV_CMF_14), in_node, "INV_CMF_14");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_15, sizeof(MTIVLOTSTS_CHILD.INV_CMF_15), in_node, "INV_CMF_15");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_16, sizeof(MTIVLOTSTS_CHILD.INV_CMF_16), in_node, "INV_CMF_16");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_17, sizeof(MTIVLOTSTS_CHILD.INV_CMF_17), in_node, "INV_CMF_17");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_18, sizeof(MTIVLOTSTS_CHILD.INV_CMF_18), in_node, "INV_CMF_18");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_19, sizeof(MTIVLOTSTS_CHILD.INV_CMF_19), in_node, "INV_CMF_19");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_20, sizeof(MTIVLOTSTS_CHILD.INV_CMF_20), in_node, "INV_CMF_20");
  
	TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_21, sizeof(MTIVLOTSTS_CHILD.INV_CMF_21), in_node, "INV_CMF_21");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_22, sizeof(MTIVLOTSTS_CHILD.INV_CMF_22), in_node, "INV_CMF_22");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_23, sizeof(MTIVLOTSTS_CHILD.INV_CMF_23), in_node, "INV_CMF_23");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_24, sizeof(MTIVLOTSTS_CHILD.INV_CMF_24), in_node, "INV_CMF_24");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_25, sizeof(MTIVLOTSTS_CHILD.INV_CMF_25), in_node, "INV_CMF_25");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_26, sizeof(MTIVLOTSTS_CHILD.INV_CMF_26), in_node, "INV_CMF_26");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_27, sizeof(MTIVLOTSTS_CHILD.INV_CMF_27), in_node, "INV_CMF_27");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_28, sizeof(MTIVLOTSTS_CHILD.INV_CMF_28), in_node, "INV_CMF_28");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_29, sizeof(MTIVLOTSTS_CHILD.INV_CMF_29), in_node, "INV_CMF_29");
    TRS.copy(MTIVLOTSTS_CHILD.INV_CMF_30, sizeof(MTIVLOTSTS_CHILD.INV_CMF_30), in_node, "INV_CMF_30");

    TRS.copy(MTIVLOTSTS_CHILD.OPER, sizeof(MTIVLOTSTS_CHILD.OPER), in_node, "TO_OPER");

    memcpy(MTIVLOTSTS_CHILD.CREATE_TIME, s_tran_time, sizeof(MTIVLOTSTS_CHILD.CREATE_TIME));

    MTIVLOTSTS_CHILD.FROM_TO_FLAG = 'T';
    memcpy(MTIVLOTSTS_CHILD.FROM_TO_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS_CHILD.FROM_TO_LOT_ID));
	MTIVLOTSTS_CHILD.FROM_TO_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

	if(COM_isspace(MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID))==MP_TRUE)
		memcpy(MTIVLOTSTS_CHILD.VENDOR_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS_CHILD.VENDOR_LOT_ID));

    memcpy(MTIVLOTSTS_CHILD.LAST_TRAN_CODE, MP_INV_TRAN_CODE_SPLIT, strlen(MP_INV_TRAN_CODE_SPLIT));
    TRS.copy(MTIVLOTSTS_CHILD.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_CHILD.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
    memcpy(MTIVLOTSTS_CHILD.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_CHILD.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS_CHILD.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS_CHILD.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

	memcpy(MTIVLOTSTS_CHILD.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	TRS.copy(MTIVLOTSTS_CHILD.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS_CHILD.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS_CHILD.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS_CHILD.LAST_TRAN_USER_ID), in_node, "PRC_USER");

    MTIVLOTSTS_CHILD.LAST_HIST_SEQ = 1;
    MTIVLOTSTS_CHILD.LAST_ACTIVE_HIST_SEQ = 1;

    MTIVLOTSTS_CHILD.IN_OUT_FLAG = ' ';


	////ATTRIBUTE VALUE를 얻어오기 위해 추가
	//DBU_init_matrnamsts(&MATRNAMSTS);
	////ATTRIBUTE SELECT IN_NODE(MATERIAL_ID), Get ATTR_VALUE; //Attribute가 필요할때마다 호출한다. 
	//TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	///*TRS.copy(MATRNAMSTS.ATTR_TYPE, sizeof(MATRNAMSTS.ATTR_TYPE), in_node, "ATTR_TYPE");*/
	//memcpy(MATRNAMSTS.ATTR_TYPE, "MATERIAL", strlen("MATERIAL"));
	//memcpy(MATRNAMSTS.ATTR_NAME, "LotGroupFlag", strlen("LotGroupFlag"));
	//TRS.copy(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY), in_node, "ATTR_KEY");

 //   if(TIV_View_Attribute_Value_For_Split(s_msg_code, 
 //                                           in_node,
 //                                           out_node,
 //                                           &MATRNAMSTS) == MP_FALSE)
 //   {
 //       COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
 //       return MP_FALSE;
 //   }
	//MTIVMATDEF.LOT_GROUP_FLAG == 'Y'

    /*if(strcmp(MATRNAMSTS.ATTR_VALUE, "Y") == 0 &&
        COM_isnullspace(MTIVLOTSTS.LOT_GROUP_ID) == MP_TRUE)
    {
        if(COM_isnullspace(TRS.get_string(in_node, "CHILD_LOT_GROUP_ID")) == MP_FALSE)
        {
            TRS.copy(MTIVLOTSTS_CHILD.LOT_GROUP_ID, sizeof(MTIVLOTSTS_CHILD.LOT_GROUP_ID), in_node, "CHILD_LOT_GROUP_ID");
        }
        else
        {
            memcpy(MTIVLOTSTS_CHILD.LOT_GROUP_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS_CHILD.LOT_GROUP_ID));
        }
    }*/

    /* History Insert (mother)************************************************************************/
    DBC_init_mtivlothis(&MTIVLOTHIS);
   
    memcpy(MTIVLOTHIS.FROM_TO_OPER, MTIVLOTSTS_CHILD.OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
    MTIVLOTHIS.FROM_TO_QTY_1 = MTIVLOTSTS_CHILD.QTY_1;
    MTIVLOTHIS.FROM_TO_QTY_2 = MTIVLOTSTS_CHILD.QTY_2;
    MTIVLOTHIS.FROM_TO_QTY_3 = MTIVLOTSTS_CHILD.QTY_3;
    //MTIVLOTHIS.FROM_TO_HIST_SEQ = MTIVLOTSTS_CHILD.LAST_HIST_SEQ;

	/*TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), in_node, "TRAN_CMF_1");		 
	TRS.copy(MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2), in_node, "TRAN_CMF_2");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_3, sizeof(MTIVLOTHIS.TRAN_CMF_3), in_node, "TRAN_CMF_3");*/
	TRS.copy(MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVLOTHIS.TRAN_CMF_4), in_node, "TRAN_CMF_4");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_5, sizeof(MTIVLOTHIS.TRAN_CMF_5), in_node, "TRAN_CMF_5");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6), in_node, "TRAN_CMF_6");		
	/*TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "TRAN_CMF_7");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "TRAN_CMF_8");*/
	TRS.copy(MTIVLOTHIS.TRAN_CMF_9, sizeof(MTIVLOTHIS.TRAN_CMF_9), in_node, "TRAN_CMF_9");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10), in_node, "TRAN_CMF_10");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11), in_node, "TRAN_CMF_11");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_12, sizeof(MTIVLOTHIS.TRAN_CMF_12), in_node, "TRAN_CMF_12");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_13, sizeof(MTIVLOTHIS.TRAN_CMF_13), in_node, "TRAN_CMF_13");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_14, sizeof(MTIVLOTHIS.TRAN_CMF_14), in_node, "TRAN_CMF_14");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_15, sizeof(MTIVLOTHIS.TRAN_CMF_15), in_node, "TRAN_CMF_15");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_16, sizeof(MTIVLOTHIS.TRAN_CMF_16), in_node, "TRAN_CMF_16");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_17, sizeof(MTIVLOTHIS.TRAN_CMF_17), in_node, "TRAN_CMF_17");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18), in_node, "TRAN_CMF_18");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19), in_node, "TRAN_CMF_19");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20), in_node, "TRAN_CMF_20");

	COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, MTIVLOTHIS.FROM_TO_QTY_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_2, MTIVLOTHIS.FROM_TO_QTY_2, sizeof(MTIVLOTHIS.TRAN_CMF_2));
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_3, MTIVLOTHIS.FROM_TO_QTY_3, sizeof(MTIVLOTHIS.TRAN_CMF_3));
	
	TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

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

    /* History Insert (child)************************************************************************/
    DBC_init_mtivlothis(&MTIVLOTHIS);

    memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS_CHILD, sizeof(MTIVLOTSTS_CHILD));

    MTIVLOTSTS_OLD.QTY_1 = 0;
    MTIVLOTSTS_OLD.QTY_2 = 0;
    MTIVLOTSTS_OLD.QTY_3 = 0;

    memcpy(MTIVLOTHIS.FROM_TO_OPER, MTIVLOTSTS.OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
    MTIVLOTHIS.FROM_TO_QTY_1 = MTIVLOTSTS.QTY_1;
    MTIVLOTHIS.FROM_TO_QTY_2 = MTIVLOTSTS.QTY_2;
    MTIVLOTHIS.FROM_TO_QTY_3 = MTIVLOTSTS.QTY_3;
    //MTIVLOTHIS.FROM_TO_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

	/*TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), in_node, "TRAN_CMF_1");		 
	TRS.copy(MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2), in_node, "TRAN_CMF_2");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_3, sizeof(MTIVLOTHIS.TRAN_CMF_3), in_node, "TRAN_CMF_3");*/
	TRS.copy(MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVLOTHIS.TRAN_CMF_4), in_node, "TRAN_CMF_4");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_5, sizeof(MTIVLOTHIS.TRAN_CMF_5), in_node, "TRAN_CMF_5");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6), in_node, "TRAN_CMF_6");		
	/*TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "TRAN_CMF_7");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "TRAN_CMF_8");*/
	TRS.copy(MTIVLOTHIS.TRAN_CMF_9, sizeof(MTIVLOTHIS.TRAN_CMF_9), in_node, "TRAN_CMF_9");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10), in_node, "TRAN_CMF_10");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11), in_node, "TRAN_CMF_11");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_12, sizeof(MTIVLOTHIS.TRAN_CMF_12), in_node, "TRAN_CMF_12");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_13, sizeof(MTIVLOTHIS.TRAN_CMF_13), in_node, "TRAN_CMF_13");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_14, sizeof(MTIVLOTHIS.TRAN_CMF_14), in_node, "TRAN_CMF_14");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_15, sizeof(MTIVLOTHIS.TRAN_CMF_15), in_node, "TRAN_CMF_15");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_16, sizeof(MTIVLOTHIS.TRAN_CMF_16), in_node, "TRAN_CMF_16");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_17, sizeof(MTIVLOTHIS.TRAN_CMF_17), in_node, "TRAN_CMF_17");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18), in_node, "TRAN_CMF_18");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19), in_node, "TRAN_CMF_19");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20), in_node, "TRAN_CMF_20");
	
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, MTIVLOTHIS.FROM_TO_QTY_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_2, MTIVLOTHIS.FROM_TO_QTY_2, sizeof(MTIVLOTHIS.TRAN_CMF_2));
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_3, MTIVLOTHIS.FROM_TO_QTY_3, sizeof(MTIVLOTHIS.TRAN_CMF_3));

	TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

    if(TIV_update_insert_lot_status_history(s_msg_code,
                                            in_node,
                                            out_node,                                            
                                            s_sys_time,
                                            &MTIVLOTSTS_OLD,
                                            &MTIVLOTSTS_CHILD,
                                            &MTIVLOTHIS) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    if(TIV_copy_attribute(s_msg_code,
                          in_node,
                          out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	TRS.set_string(in_node, "TO_LOT_ID", MTIVLOTSTS_CHILD.LOT_ID, sizeof(MTIVLOTSTS_CHILD.LOT_ID));
	TRS.set_string(in_node, "INPUT_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
 
	TRS.set_nstring(in_node, "USE_OPER", TRS.get_string(in_node, "OPER"));
	TRS.set_char(in_node, "WIP_OR_INV", 'I');
	TRS.set_string(in_node, "TRAN_CODE", MP_TIV_TRAN_CODE_SPLIT, strlen(MP_TIV_TRAN_CODE_SPLIT));
	TRS.set_double(in_node, "INPUT_QTY_1", MTIVLOTSTS_CHILD.QTY_1);
	TRS.set_double(in_node, "INPUT_QTY_2", 0);
	TRS.set_double(in_node, "INPUT_QTY_3", 0);
	TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
	
	if (TIV_Create_Material_Usage_Info(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Split_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;

}

/*******************************************************************************
    TIV_Split_Lot_Fill_InTag()
        - Validation Check sub function of "WIP_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/

int TIV_Split_Lot_Fill_InTag(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    TRSNode *member;

    if(COM_isnullspace(TRS.get_string(in_node, "TIV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.LOT_ID), in_node, "FROM_OPER");    
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "TIV_LOT_ID");    
    DBC_select_mtivlotsts(4, &MTIVLOTSTS);
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
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_string(in_node, "CHILD_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "CHILD_LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(TRS.get_double(in_node, "MOVE_QTY_1") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if((member = TRS.get_member(in_node, "CHILD_LOT_DESC")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "CHILD_LOT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));
    }
    if((member = TRS.get_member(in_node, "CHILD_MAT_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "CHILD_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
    }
    if((member = TRS.get_member(in_node, "CHILD_MAT_VER")) == 0x00 || member->NullFlag == 'Y' || member->Value.i4 < 1)
    {
        TRS.set_int(in_node, "CHILD_MAT_VER", MTIVLOTSTS.MAT_VER);
    }
   /* if((member = TRS.get_member(in_node, "CHILD_FLOW")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "CHILD_FLOW", MTIVLOTSTS.FLOW, sizeof(MTIVLOTSTS.FLOW));
    }*/
   /* if((member = TRS.get_member(in_node, "CHILD_FLOW_SEQ_NUM")) == 0x00 || member->NullFlag == 'Y' || member->Value.i4 < 1)
    {
        TRS.set_int(in_node, "CHILD_FLOW_SEQ_NUM", MTIVLOTSTS.FLOW_SEQ_NUM);
    }*/
    if((member = TRS.get_member(in_node, "CHILD_OPER")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "CHILD_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
    }
    /*if((member = TRS.get_member(in_node, "CHILD_CREATE_CODE")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "CHILD_CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
    }
    if((member = TRS.get_member(in_node, "CHILD_OWNER_CODE")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "CHILD_OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
    }*/
    if((member = TRS.get_member(in_node, "CHILD_LOT_TYPE")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "CHILD_LOT_TYPE") == ' ')
    {
        TRS.set_char(in_node, "CHILD_LOT_TYPE", MTIVLOTSTS.LOT_TYPE);
    }
    /*if((member = TRS.get_member(in_node, "CHILD_PRIORITY")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "CHILD_PRIORITY") == ' ')
    {
        TRS.set_char(in_node, "CHILD_PRIORITY", MTIVLOTSTS.LOT_PRIORITY);
    }
    if((member = TRS.get_member(in_node, "CHILD_DUE_TIME")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "CHILD_DUE_TIME", MTIVLOTSTS.SCH_DUE_TIME, sizeof(MTIVLOTSTS.SCH_DUE_TIME));
    }
*/
   /* if((member = TRS.get_member(in_node, "INV_CMF_1")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
    }*/
    if((member = TRS.get_member(in_node, "INV_CMF_2")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_3")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_4")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_5")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_6")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_7")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_8")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_9")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_10")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_11")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_12")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_13")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_14")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_15")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_16")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_17")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_18")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_19")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_20")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
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
    TIV_Split_Lot_Validation()
        - Validation Check sub function of "WIP_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Split_Lot_Validation(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_CHILD;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    //struct MWIPFLWDEF_TAG MWIPFLWDEF;
    //struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    //struct MWIPMATFLW_TAG MWIPMATFLW;

    //char c_unit_change;
    //int i_sublot_count;
    int i_count;
    //struct MWIPSLTSTS_TAG MWIPSLTSTS;

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
    if(TIV_lot_tran_validation(s_msg_code,
                               out_node,
                               in_node,
                               &MTIVLOTSTS,
                               &MWIPFACDEF,
                               &MWIPMATDEF,
                               &MTIVOPRDEF) == MP_FALSE)
    {
        return MP_FALSE;
    }

   /* if(MWIPMATDEF.DELETE_FLAG == 'Y')
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
    //if(TRS.get_char(in_node, MP_WIP_SUBLOT_FLAG) != 'Y')
    //{
    //    //Mother의 살아 있는 sublot 있는지 check..
    //    DBC_init_mwipsltsts(&MWIPSLTSTS);
    //    memcpy(MWIPSLTSTS.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MWIPSLTSTS.LOT_ID));
    //    MWIPSLTSTS.SUBLOT_DEL_FLAG = ' ';
    //    MWIPSLTSTS.UNIT_EXIST_FLAG = 'Y';
    //    i_sublot_count = (int) DBC_select_mwipsltsts_scalar(7, &MWIPSLTSTS);
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "WIP-0004");
    //        TRS.add_fieldmsg(out_node, "MWIPSLTSTS SELECT_SCALAR", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MWIPSLTSTS.LOT_ID), MWIPSLTSTS.LOT_ID);
    //        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPSLTSTS.OPER), MWIPSLTSTS.OPER);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //    //Sublot이 생성된적이 있으면 (mother)...
    //    if(i_sublot_count > 0)
    //    {
    //        strcpy(s_msg_code, "WIP-0191");
    //        TRS.add_fieldmsg(out_node, "IT HAS SUBLOT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MWIPSLTSTS.LOT_ID), MWIPSLTSTS.LOT_ID);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}

    /* Child Lot ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CHILD_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "CHILD_LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    else
    {       
        DBC_init_mtivlotsts(&MTIVLOTSTS_CHILD);
        TRS.copy(MTIVLOTSTS_CHILD.LOT_ID, sizeof(MTIVLOTSTS_CHILD.LOT_ID), in_node, "CHILD_LOT_ID");
		TRS.copy(MTIVLOTSTS_CHILD.OPER, sizeof(MTIVLOTSTS_CHILD.OPER), in_node, "TO_OPER");
        i_count = (int)DBC_select_mtivlotsts_scalar(4, &MTIVLOTSTS_CHILD);   
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "INV-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT_SCALAR", MP_NVST);
            TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_CHILD.LOT_ID), MTIVLOTSTS_CHILD.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
        if(i_count > 0)
        {
            strcpy(s_msg_code, "WIP-0045");
            TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_CHILD.LOT_ID), MTIVLOTSTS_CHILD.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }    
    }

    /* Mother Lot and Child Lot Validation */
    if(memcmp(MTIVLOTSTS.LOT_ID, MTIVLOTSTS_CHILD.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID)) == 0
		&& memcmp(MTIVLOTSTS.OPER, MTIVLOTSTS_CHILD.OPER, sizeof(MTIVLOTSTS.OPER)) == 0)
    {
        strcpy(s_msg_code, "WIP-0181"); 
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "CHILD_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_CHILD.LOT_ID), MTIVLOTSTS_CHILD.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* Child Lot Material Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CHILD_MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "CHILD_MAT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(TRS.get_int(in_node, "CHILD_MAT_VER") < 1)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "CHILD_MAT_VER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    ///* 다른 Material ID 로 Split이 가능한지 Check */
    //if(COM_compare_global_option(TRS.get_factory(in_node), 
    //                             MP_OPTION_SPLIT_DIFF_MAT_ID, 
    //                             'Y') != MP_TRUE)
    //{
    //    if(TRS.mem_cmp(in_node, "CHILD_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID)) != 0)
    //    {
    //        strcpy(s_msg_code, "WIP-0261");
    //        TRS.add_fieldmsg(out_node, "MOTHER LOT MAT_ID", MP_STR, sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);
    //        TRS.add_fieldmsg(out_node, "CHILD LOT MAT_ID", MP_NSTR, TRS.get_string(in_node, "CHILD_MAT_ID"));

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}

    ///* 다른 Material Version 로 Split이 가능한지 Check */
    //if(COM_compare_global_option(TRS.get_factory(in_node), 
    //                             MP_OPTION_SPLIT_DIFF_MAT_VERSION, 
    //                             'Y') != MP_TRUE)
    //{
    //    if(MTIVLOTSTS.MAT_VER != TRS.get_int(in_node, "CHILD_MAT_VER"))
    //    {
    //        strcpy(s_msg_code, "WIP-0261");
    //        TRS.add_fieldmsg(out_node, "MOTHER LOT MAT_VER", MP_INT, MTIVLOTSTS.MAT_VER);
    //        TRS.add_fieldmsg(out_node, "CHILD LOT MAT_VER", MP_INT, TRS.get_int(in_node, "CHILD_MAT_VER"));

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}

    /* Child Lot Oper Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CHILD_OPER")) == MP_TRUE)
    {
        TRS.set_nstring(in_node, "CHILD_OPER", TRS.get_string(in_node, "OPER"));
    }
    else
    {
        if(TRS.mem_cmp(in_node, "CHILD_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER)) != 0)
        {
            ///* 다른 Oper로 Split이 가능한지 Check */
            //if(COM_compare_global_option(TRS.get_factory(in_node), 
            //                             MP_OPTION_SPLIT_DIFF_OPER, 
            //                             'Y') != MP_TRUE)
            //{
                //strcpy(s_msg_code, "WIP-0090");
                //TRS.add_fieldmsg(out_node, "MOTHER LOT OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
                //TRS.add_fieldmsg(out_node, "CHILD LOT OPER", MP_NSTR, TRS.get_string(in_node, "CHILD_OPER"));

                //gs_log_type.type = MP_LOG_ERROR;
                //gs_log_type.e_type = MP_LOG_E_VALIDATION;
                //gs_log_type.category = MP_LOG_CATE_TRANS;
                //return MP_FALSE;
            //}

            ///* 2006.04.10. CM Koo. */
            ///* 다른 공정으로 SPLIT이 가능한 경우 현재 공정과 Split 공정의 Unit은 동일해야만 한다. */
            //c_unit_change = ' ';
            //if(COM_check_unit_diff_oper(s_msg_code,
            //                            out_node,
            //                            TRS.get_factory(in_node),
            //                            TRS.get_string(in_node, "OPER"),
            //                            TRS.get_factory(in_node),
            //                            TRS.get_string(in_node, "CHILD_OPER"),
            //                            &c_unit_change) == MP_FALSE)
            //{
            //    return MP_FALSE;
            //}
            //if(c_unit_change == 'Y')
            //{
            //    strcpy(s_msg_code, "WIP-0324");
            //    TRS.add_fieldmsg(out_node, "MOTHER LOT OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
            //    TRS.add_fieldmsg(out_node, "CHILD LOT OPER", MP_NSTR, TRS.get_string(in_node, "CHILD_OPER"));

            //    gs_log_type.type = MP_LOG_ERROR;
            //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
            //    gs_log_type.category = MP_LOG_CATE_TRANS;
            //    return MP_FALSE;
            //}

            ///* 2007.02.02. Aiden Koo */
            ///* 다른 공정으로 SPLIT 인 경우 Lot이 Start 되어 Resource가 있다면 child_oper 에도 Resource가 있어야 한다. 그렇지 않으면 에러 */
            //if(MTIVLOTSTS.START_FLAG == 'Y' &&
            //   COM_isspace(MTIVLOTSTS.START_RES_ID, sizeof(MTIVLOTSTS.START_RES_ID)) == MP_FALSE)
            //{
            //    /* Resource - MFO Relation Validation */
            //    if(COM_check_resource_mfo_relation(s_msg_code, 
            //                                       out_node,
            //                                       '1',
            //                                       MTIVLOTSTS.FACTORY,
            //                                       TRS.get_string(in_node, "CHILD_MAT_ID"),
            //                                       TRS.get_int(in_node, "CHILD_MAT_VER"),
            //                                       TRS.get_string(in_node, "CHILD_FLOW"),
            //                                       TRS.get_string(in_node, "CHILD_OPER"),
            //                                       MTIVLOTSTS.START_RES_ID) == MP_FALSE)
            //    {
            //        return MP_FALSE;
            //    }
            //}
        }
    }

    ///* Repair, Store 상태인 경우 child lot의 생성을 위한 MFO check하지 않도록 한다. */
    //if(MTIVLOTSTS.REP_FLAG != 'Y' && MTIVLOTSTS.TIV_FLAG != 'Y')
    //{
    //    /* Child Lot Oper Validation */
    //    if(COM_isnullspace(TRS.get_string(in_node, "CHILD_FLOW")) == MP_TRUE)
    //    {
    //        char s_child_flow[20];

    //        /* MFO Validation */
    //        /* 만약 M-F-O가 없으면 M-O의 첫번째 Flow를 찾는다. */
    //        memset(s_child_flow, ' ', sizeof(s_child_flow));
    //        if(COM_check_mfo_return_first_flow(s_msg_code, 
    //                                           out_node,
    //                                           '1',
    //                                           '1',
    //                                           TRS.get_factory(in_node),
    //                                           TRS.get_string(in_node, "CHILD_MAT_ID"),
    //                                           TRS.get_int(in_node, "CHILD_MAT_VER"),
    //                                           TRS.get_string(in_node, "FLOW"),
    //                                           TRS.get_string(in_node, "CHILD_OPER"),
    //                                           s_child_flow) == MP_FALSE)
    //        {
    //            return MP_FALSE;
    //        }

    //        TRS.set_string(in_node, "CHILD_FLOW", s_child_flow, sizeof(s_child_flow));
    //    }
    //    else
    //    {
    //        /* MFO Validation */
    //        // 2007.01.16. Aiden Koo.
    //        // Rework/NSTD Lot을 Split 하는 경우 Material의 Flow가 아닐수 있으므로 F-O만 Check
    //        if(MTIVLOTSTS.RWK_FLAG == 'Y' || MTIVLOTSTS.NSTD_FLAG == 'Y')
    //        {
    //            if(COM_check_mfo(s_msg_code, 
    //                             out_node,
    //                             '1',
    //                             '2',
    //                             TRS.get_factory(in_node),
    //                             TRS.get_string(in_node, "CHILD_MAT_ID"),
    //                             TRS.get_int(in_node, "CHILD_MAT_VER"),
    //                             TRS.get_string(in_node, "CHILD_FLOW"),
    //                             TRS.get_string(in_node, "CHILD_OPER")) == MP_FALSE)
    //            {
    //                return MP_FALSE;
    //            }
    //        }
    //        else
    //        {
    //            /* Material-Flow-Flow Sequence Validation */ // Add by inchury 2010-04-01
    //            DBC_init_mwipmatflw(&MWIPMATFLW);
    //            TRS.copy(MWIPMATFLW.FACTORY, sizeof(MWIPMATFLW.FACTORY), in_node, IN_FACTORY);
    //            TRS.copy(MWIPMATFLW.MAT_ID, sizeof(MWIPMATFLW.MAT_ID), in_node, "CHILD_MAT_ID");
    //            MWIPMATFLW.MAT_VER = TRS.get_int(in_node, "CHILD_MAT_VER");
    //            TRS.copy(MWIPMATFLW.FLOW, sizeof(MWIPMATFLW.FLOW), in_node, "CHILD_FLOW");
    //            MWIPMATFLW.FLOW_SEQ_NUM = TRS.get_int(in_node, "CHILD_FLOW_SEQ_NUM");

    //            DBC_select_mwipmatflw(1, &MWIPMATFLW);
    //            if(DB_error_code != DB_SUCCESS)
    //            {
    //                strcpy(s_msg_code, "WIP-0019");
    //                TRS.add_fieldmsg(out_node, "MWIPMATFLW SELECT", MP_NVST);
    //                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATFLW.FACTORY), MWIPMATFLW.FACTORY);
    //                TRS.add_fieldmsg(out_node, "CHILD_MAT_ID", MP_STR, sizeof(MWIPMATFLW.MAT_ID), MWIPMATFLW.MAT_ID);
    //                TRS.add_fieldmsg(out_node, "CHILD_MAT_VER", MP_INT, MWIPMATFLW.MAT_VER);
    //                TRS.add_fieldmsg(out_node, "CHILD_FLOW", MP_STR, sizeof(MWIPMATFLW.FLOW), MWIPMATFLW.FLOW);
    //                TRS.add_fieldmsg(out_node, "CHILD_FLOW_SEQ_NUM", MP_INT, MWIPMATFLW.FLOW_SEQ_NUM);
    //                TRS.add_dberrmsg(out_node, DB_error_msg);

    //                gs_log_type.type = MP_LOG_ERROR;
    //                gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //                gs_log_type.category = MP_LOG_CATE_TRANS;

    //                return MP_FALSE;
    //            }

    //            if(COM_check_mfo(s_msg_code, 
    //                             out_node,
    //                             '1',
    //                             '1',
    //                             TRS.get_factory(in_node),
    //                             TRS.get_string(in_node, "CHILD_MAT_ID"),
    //                             TRS.get_int(in_node, "CHILD_MAT_VER"),
    //                             TRS.get_string(in_node, "CHILD_FLOW"),
    //                             TRS.get_string(in_node, "CHILD_OPER")) == MP_FALSE)
    //            {
    //                return MP_FALSE;
    //            }
    //        }

    //    }
    //}


    if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y' && TRS.get_char(in_node, "SHIP_RTN_FLAG") != 'Y')
    {
        strcpy(s_msg_code, "WIP-0076");
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Lot Hold Validation */
    if(MTIVLOTSTS.HOLD_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0059");
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    ///* Lot Instrasit Validation */
    //if(MTIVLOTSTS.TRANSIT_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0060");
    //    TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    /* 2008.01.21. Aiden. 공정 이동에 대해서 다음 공정의 TIV_FLAG를 Status에 기록하지 못하게 변경. TIV_FLAG는 STORE TR에 의해서만 설정되도록 함. */
    /* Store 공정에서도 TR이 발생할 수 있도록 변경함. */
    /* 공정 이동에 대해서 다음 공정의 TRANSIT_FLAG를 Status에 기록하지 못하게 변경. TRANSIT_FLAG는 SHIP TR에 의해서만 설정되도록 함. */
    /* Lot Store Validation */
    //if(MTIVLOTSTS.TIV_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0061");
    //    sprintf(Cmn_Out->h_field_msg, "LOT_ID = [%.*s]",
    //        sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    /* Move Qty Validation */
    /* 2005.10.13. CM Koo. */
    //if(TRS.get_double(in_node, "MOVE_QTY_1") < 0)
    if(TRS.get_double(in_node, "MOVE_QTY_1") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    //if(TRS.get_double(in_node, "MOVE_QTY_2") < 0)
    if(TRS.get_double(in_node, "MOVE_QTY_2") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    //if(TRS.get_double(in_node, "MOVE_QTY_3") < 0)
    if(TRS.get_double(in_node, "MOVE_QTY_3") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2018.04.23 JWLEE 
     * 증평 셀은 ERP에서 재고 정보가 넘어오지 않으므로 Validation 하지 않음
     */
    if(memcmp(MWIPMATDEF.MAT_GRP_1,"PS",strlen("PS")) == 0)
    {
        return MP_TRUE;
    }

    /* 2005.10.13. CM Koo. */
    /* 소수점 4째 이하의 값은 무시함. */
    //if(TRS.get_double(in_node, "MOVE_QTY_1") > MTIVLOTSTS.QTY_1) 
    if(MTIVLOTSTS.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1") < -0.0005) 
    {
        strcpy(s_msg_code, "WIP-0092");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
        TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    /* 소수점 4째 이하의 값은 무시함. */
    //if(TRS.get_double(in_node, "MOVE_QTY_2") > MTIVLOTSTS.QTY_2) 
    if(MTIVLOTSTS.QTY_2 - TRS.get_double(in_node, "MOVE_QTY_2") < -0.0005) 
    {
        strcpy(s_msg_code, "WIP-0092");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
        TRS.add_fieldmsg(out_node, "QTY_2", MP_DBL, MTIVLOTSTS.QTY_2);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    /* 소수점 4째 이하의 값은 무시함. */
    //if(TRS.get_double(in_node, "MOVE_QTY_3") > MTIVLOTSTS.QTY_3) 
    if(MTIVLOTSTS.QTY_3 - TRS.get_double(in_node, "MOVE_QTY_3") < -0.0005) 
    {
        strcpy(s_msg_code, "WIP-0092");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));
        TRS.add_fieldmsg(out_node, "QTY_3", MP_DBL, MTIVLOTSTS.QTY_3);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */    
    if(TRS.get_double(in_node, "MOVE_QTY_1") < -0.0005 && 
       TRS.get_double(in_node, "MOVE_QTY_2") < -0.0005 && 
       TRS.get_double(in_node, "MOVE_QTY_3") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0264");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    ///* 2007.12.6. Aiden */
    ///* Able Zero Quantity Lot */
    //if(COM_compare_global_option(TRS.get_factory(in_node), 
    //                             MP_OPTION_PROCESS_ZERO_QTY_LOT, 
    //                             'Y') != MP_TRUE)
    //{
    //    /* 2005.10.13. CM Koo. */    
    //    if(TRS.get_double(in_node, "MOVE_QTY_1") < 0.0005 && 
    //       TRS.get_double(in_node, "MOVE_QTY_2") < 0.0005 && 
    //       TRS.get_double(in_node, "MOVE_QTY_3") < 0.0005)
    //    {
    //        strcpy(s_msg_code, "WIP-0264");
    //        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
    //        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
    //        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}


    /* Lot이 새로 생성, Create_Lot 처럼 Check */
    /* Create Code Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "CHILD_CREATE_CODE")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "WIP-0001");
    //    TRS.add_fieldmsg(out_node, "CHILD LOT CREATE_CODE", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}
    //else
    //{
    //    /* Create Code Validation */
    //    if(COM_check_gcm_data(s_msg_code,
    //                          out_node,
    //                          MP_WIP_CREATE_CODE,
    //                          TRS.get_factory(in_node),
    //                          TRS.get_string(in_node, "CHILD_CREATE_CODE"),
    //                          (int)strlen(TRS.get_string(in_node, "CHILD_CREATE_CODE"))) == MP_FALSE)
    //    {
    //        return MP_FALSE;
    //    }
    //}

    ///* Owner Code Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "CHILD_OWNER_CODE")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "WIP-0001");
    //    TRS.add_fieldmsg(out_node, "CHILD LOT OWNER_CODE", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}
    //else
    //{
    //    /* Owner Code Validation */
    //    if(COM_check_gcm_data(s_msg_code,
    //                          out_node,
    //                          MP_WIP_OWNER_CODE,
    //                          TRS.get_factory(in_node),
    //                          TRS.get_string(in_node, "CHILD_OWNER_CODE"),
    //                          (int)strlen(TRS.get_string(in_node, "CHILD_OWNER_CODE"))) == MP_FALSE)
    //    {
    //        return MP_FALSE;
    //    }
    //}

    //{
    //    char s_lot_type[2];

    //    s_lot_type[0] = TRS.get_char(in_node, "CHILD_LOT_TYPE");
    //    s_lot_type[1] = 0x00;

    //    if(COM_check_gcm_data(s_msg_code,
    //                          out_node,
    //                          MP_WIP_LOT_TYPE,
    //                          TRS.get_factory(in_node),
    //                          s_lot_type,
    //                          1) == MP_FALSE)  
    //    {
    //        return MP_FALSE;
    //    }
    //}

    /*if(COM_isnullspace(TRS.get_string(in_node, "CHILD_DUE_TIME")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "CHILD DUE_TIME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    {
        char s_tmp[8];
        COM_memcpy(s_tmp, TRS.get_string(in_node, "CHILD_DUE_TIME"), sizeof(s_tmp));

        if(COM_isdate(s_tmp) == MP_FALSE)
        {
            strcpy(s_msg_code, "WIP-0091");
            TRS.add_fieldmsg(out_node, "CHILD_DUE_TIME", MP_STR, sizeof(s_tmp), s_tmp);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }*/

    ///* Priority Validation */
    //if(TRS.get_char(in_node, "CHILD_PRIORITY") - 48 < 1 || TRS.get_char(in_node, "CHILD_PRIORITY") - 48 > 9)
    //{
    //    strcpy(s_msg_code, "WIP-0038");
    //    TRS.add_fieldmsg(out_node, "PRIORITY", MP_CHR, TRS.get_char(in_node, "CHILD_PRIORITY"));

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    //if(WIP_check_carrier_lot_relation(s_msg_code,
    //                                  out_node,
    //                                  in_node,
    //                                  TRS.get_double(in_node, "MOVE_QTY_1")) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    //if(WIP_check_lot_in_batch(MTIVLOTSTS.FACTORY, MTIVLOTSTS.LOT_ID) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "WIP-0417");
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
    //    TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    ///* Create CMF Validation */   
    //if(TIV_check_lot_cmf_split_lot(s_msg_code, in_node, out_node) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    ///* CMF Validation */
    //if(TIV_check_tran_cmf_split_lot(s_msg_code, in_node, out_node) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}


/*******************************************************************************
    TIV_check_lot_cmf_split_lot()
        - Check the Conditions before Create Child Lot CMF Definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_lot_cmf_split_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node)
{
    struct check_list s_check_list;

    COM_fill_check_list(&s_check_list, in_node, 20, "LOT_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_LOT, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}


/*******************************************************************************
    TIV_check_tran_cmf_split_lot()
        - Check the Conditions before Split Lot CMF Definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_tran_cmf_split_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node)
{
    struct check_list s_check_list;

    COM_fill_check_list(&s_check_list, in_node, 20, "TRAN_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_TRN_SPLIT, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

/*******************************************************************************
    TIV_copy_attribute()
        - Copy mother lot attribute to child lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_copy_attribute(char *s_msg_code,
                       TRSNode *in_node,
                       TRSNode *out_node)
{
    struct MATRNAMSTS_TAG MATRNAMSTS;
    TRSNode *update_attribute_value_in;
    TRSNode *attr_item;

    update_attribute_value_in = TRS.create_node("UPDATE_ATTRIBUTE_VALUE_IN");

    TRS.add_nstring(update_attribute_value_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
    TRS.add_nstring(update_attribute_value_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
    TRS.add_nstring(update_attribute_value_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
    TRS.add_char(update_attribute_value_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
    TRS.add_char(update_attribute_value_in, MP_NOTCHECK_PRIVILEGE, 'Y');

    TRS.add_char(update_attribute_value_in, IN_PROCSTEP, '1');
    TRS.add_nstring(update_attribute_value_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
    TRS.add_nstring(update_attribute_value_in, "ATTR_KEY", TRS.get_string(in_node, "CHILD_LOT_ID"));
    TRS.add_string(update_attribute_value_in, "ATTR_TYPE", MP_ATTR_TYPE_INV_LOT, strlen(MP_ATTR_TYPE_INV_LOT));

    DBC_init_matrnamsts(&MATRNAMSTS);
    TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY), in_node, "TIV_LOT_ID");
    memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_LOT, strlen(MP_ATTR_TYPE_LOT));

    DBC_open_matrnamsts(3, &MATRNAMSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MATRNAMSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
        TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        TRS.free_node(update_attribute_value_in);
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_matrnamsts(3, &MATRNAMSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_matrnamsts(3);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MATRNAMSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
            TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            DBC_close_matrnamsts(3);
            TRS.free_node(update_attribute_value_in);
            return MP_FALSE;
        }

        attr_item = TRS.add_node(update_attribute_value_in, "VALUE_LIST");

        TRS.add_string(attr_item, "ATTR_NAME", MATRNAMSTS.ATTR_NAME, sizeof(MATRNAMSTS.ATTR_NAME));
        TRS.add_string(attr_item, "ATTR_VALUE", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));
        TRS.add_int(attr_item, "LAST_HIST_SEQ", 0);
    }

    if(TRS.get_item_count(update_attribute_value_in, "VALUE_LIST") > 0)
    {
        if(BAS_UPDATE_ATTRIBUTE_VALUE(s_msg_code,
                                      update_attribute_value_in,
                                      out_node) == MP_FALSE)
        {
            TRS.free_node(update_attribute_value_in);
            return MP_FALSE;
        }
    }
    TRS.free_node(update_attribute_value_in);


    return MP_TRUE;
}





