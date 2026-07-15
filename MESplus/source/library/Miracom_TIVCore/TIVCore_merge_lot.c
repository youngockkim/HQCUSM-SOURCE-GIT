/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_merge_lot.c
    Description : Merge Lot transaction function module

    MES Version : 4.0.0

    Function Lis
        - TIV_Merge_Lot()
            + Merge Lot
        - TIV_MERGE_LOT()
            + Main sub function of "TIV_Merge_Lot" function
            + Merge Lot definition
        - TIV_Merge_Lot_Validation()
            + Validation Check sub function of "TIV_MERGE_LOT" function
            + Check the conditions before Merge Lot definition
        - TIV_check_lot_cmf_merge_lot()
            + Check the Conditions before Merge Lot CMF Definition

    Detail Description
        - TIV_Merge_Lot() 
            + h_proc_step
                + 1 : Merge Lot definition
                + 2 : Merge-Merge Lot definition

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/14  Laverwon       Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"
#ifdef _RAS
#include <RASCore_common.h>
#endif //_RAS
 

int TIV_Merge_Lot_Validation(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node);

int TIV_check_lot_cmf_merge_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node);

/*******************************************************************************
    TIV_Merge_Lot()
        - Merge Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Merge_Lot(TRSNode *in_node,
                 TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

//#ifdef _ALM
//    /* Save Factory, res_id, lot_id , ...for alarm */
//    TRS.copy(gs_alm_factory, sizeof(gs_alm_factory), in_node, IN_FACTORY);
//    TRS.copy(gs_alm_user_id, sizeof(gs_alm_user_id), in_node, IN_USERID);
//    TRS.copy(gs_alm_lot_id, sizeof(gs_alm_lot_id), in_node, "LOT_ID");
////    TRS.copy(gs_alm_res_id, sizeof(gs_alm_res_id), in_node, "RES_ID");
//    TRS.copy(gs_alm_source_id, sizeof(gs_alm_source_id), in_node, "LOT_ID");
//    memcpy(gs_alm_module, MP_TRAN_CODE_MERGE, strlen(MP_TRAN_CODE_MERGE));
//#endif /* _ALM */

    i_ret = TIV_MERGE_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_MERGE_LOT", out_node);

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
    TIV_MERGE_LOT()
        - Main sub function of "TIV_Merge_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_MERGE_LOT(char *s_msg_code,
                      TRSNode *in_node,
                      TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_INTO;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_INTO_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    //struct MWIPLOTMRG_TAG MWIPLOTMRG;

	char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];
	 
	int i_step;	 
	int i_last_active_hist_seq_from;
	int i_last_active_hist_seq_into;

    LOG_head("TIV_Merge_Lot");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("back_time", MP_NSTR, TRS.get_string(in_node, "BACK_TIME"));
    LOG_add("inv_lot_id", MP_NSTR, TRS.get_string(in_node, "TIV_LOT_ID"));
    LOG_add("LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    //LOG_add("flow", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    //LOG_add("flow_seq_num", MP_INT, TRS.get_int(in_node, "FLOW_SEQ_NUM"));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    //LOG_add("crr_id", MP_NSTR, TRS.get_string(in_node, "CRR_ID"));
    /*if(TRS.get_list(in_node, "CRR_LIST") != 0x00)
    {
        LOG_add("crr_list_count", MP_INT, TRS.get_item_count(in_node, "CRR_LIST"));
    }*/    
    LOG_add("into_inv_lot_id", MP_NSTR, TRS.get_string(in_node, "INTO_TIV_LOT_ID"));
    /*LOG_add("into_crr_id", MP_NSTR, TRS.get_string(in_node, "INTO_CRR_ID"));
    if(TRS.get_list(in_node, "INTO_CRR_LIST") != 0x00)
    {
        LOG_add("into_crr_list_count", MP_INT, TRS.get_item_count(in_node, "INTO_CRR_LIST"));
    }*/
    
    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
    LOG_add("no_automatic_terminate_lot", MP_CHR, TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT"));
    /*LOG_add("into_res_id", MP_NSTR, TRS.get_string(in_node, "INTO_RES_ID"));
    LOG_add("into_port_id", MP_NSTR, TRS.get_string(in_node, "INTO_PORT_ID"));*/
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Merge_Lot",
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
    if(TIV_Merge_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

//#ifdef _CRR
//    /* Carrier 관련 Update */
//    if(TIV_decrease_carrier_lot_qty(s_msg_code,
//                                    out_node,
//                                    in_node,
//                                    TRS.get_double(in_node, "MOVE_QTY_1"),
//                                    TRS.get_double(in_node, "MOVE_QTY_2"),
//                                    TRS.get_double(in_node, "MOVE_QTY_3")) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//#endif /* _CRR */
	 
    /* Get TransTime */
   /* if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
    {
        memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
    }
    else
    {
        TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
    }*/

    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");
	TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "FROM_OPER"); 
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

	 /* Back Time Check */
    if(TIV_check_backtime(s_msg_code,
                            in_node,
                            out_node,
                            MTIVLOTSTS_OLD.LAST_TRAN_TIME) == MP_FALSE)
    {
        return MP_FALSE;
        
    } 


    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

	i_step = 10;
	i_last_active_hist_seq_from = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS);

    DBC_init_mtivlotsts(&MTIVLOTSTS_INTO_OLD);
    TRS.copy(MTIVLOTSTS_INTO_OLD.FACTORY, sizeof(MTIVLOTSTS_INTO_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_INTO_OLD.LOT_ID, sizeof(MTIVLOTSTS_INTO_OLD.LOT_ID), in_node, "INTO_TIV_LOT_ID");
	TRS.copy(MTIVLOTSTS_INTO_OLD.OPER, sizeof(MTIVLOTSTS_INTO_OLD.OPER), in_node, "TO_OPER"); 
	//DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_INTO_OLD);
    DBC_select_mtivlotsts(4, &MTIVLOTSTS_INTO_OLD);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_INTO_OLD.FACTORY), MTIVLOTSTS_INTO_OLD.FACTORY);
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_INTO_OLD.LOT_ID), MTIVLOTSTS_INTO_OLD.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	 if(TIV_check_backtime(s_msg_code,
                            in_node,
                            out_node,
                            MTIVLOTSTS_INTO_OLD.LAST_TRAN_TIME) == MP_FALSE)
    {
        return MP_FALSE;
        
    } 


    memcpy(&MTIVLOTSTS_INTO, &MTIVLOTSTS_INTO_OLD, sizeof(MTIVLOTSTS_INTO));

	i_step = 10;
	i_last_active_hist_seq_into = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS_INTO);

    /* Update mother lot status */
    MTIVLOTSTS.FROM_TO_FLAG = 'F';
    memcpy(MTIVLOTSTS.FROM_TO_LOT_ID, MTIVLOTSTS_INTO.LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
	MTIVLOTSTS.FROM_TO_HIST_SEQ = i_last_active_hist_seq_into + 1;
    /*TRS.copy(MTIVLOTSTS.CRR_ID, sizeof(MTIVLOTSTS.CRR_ID), in_node, "CRR_ID");
    if(TRS.get_list(in_node, "CRR_LIST") != 0x00)
    {
        TRS.copy(MTIVLOTSTS.CRR_ID, sizeof(MTIVLOTSTS.CRR_ID), TRS.get_list(in_node, "CRR_LIST")[0], "CRR_ID");
    }*/

    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_MERGE, strlen(MP_INV_TRAN_CODE_MERGE));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");
	memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	MTIVLOTSTS.LAST_HIST_SEQ = i_last_active_hist_seq_from + 1;
    //MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

    /*MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;*/

    MTIVLOTSTS.QTY_1 = MTIVLOTSTS_OLD.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1");
    MTIVLOTSTS.QTY_2 = MTIVLOTSTS_OLD.QTY_2 - TRS.get_double(in_node, "MOVE_QTY_2");
    MTIVLOTSTS.QTY_3 = MTIVLOTSTS_OLD.QTY_3 - TRS.get_double(in_node, "MOVE_QTY_3");

	TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");

    MTIVLOTSTS.IN_OUT_FLAG = ' ';

    /* 전량 Merge인 경우 처리 */
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

	if(TRS.get_char(in_node, "_FORCE_TO_TERMINATE")=='Y')
	{
		MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
        TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, "PRC_USER");
        memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
        memcpy(MTIVLOTSTS.LOT_DEL_REASON, "QTY_ZERO", strlen("QTY_ZERO"));
	}

    /* Into Lot 관련 Update */
    MTIVLOTSTS_INTO.FROM_TO_FLAG = 'T';
    memcpy(MTIVLOTSTS_INTO.FROM_TO_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS_INTO.FROM_TO_LOT_ID));
	
	MTIVLOTSTS_INTO.FROM_TO_HIST_SEQ = i_last_active_hist_seq_from + 1;
	//MTIVLOTSTS_INTO.FROM_TO_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;
    //TRS.copy(MTIVLOTSTS_INTO.CRR_ID, sizeof(MTIVLOTSTS_INTO.CRR_ID), in_node, "INTO_CRR_ID");
    //if(TRS.get_list(in_node, "INTO_CRR_LIST") != 0x00)
    //{
    //    TRS.copy(MTIVLOTSTS_INTO.CRR_ID, sizeof(MTIVLOTSTS_INTO.CRR_ID), TRS.get_list(in_node, "INTO_CRR_LIST")[0], "CRR_ID");
    //}

    memcpy(MTIVLOTSTS_INTO.LAST_TRAN_CODE, MP_INV_TRAN_CODE_MERGE, strlen(MP_INV_TRAN_CODE_MERGE));
    //memset(MTIVLOTSTS_INTO.LAST_TRAN_TYPE, ' ', sizeof(MTIVLOTSTS_INTO.LAST_TRAN_TYPE));
	TRS.copy(MTIVLOTSTS_INTO.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS_INTO.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
    memcpy(MTIVLOTSTS_INTO.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS_INTO.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS_INTO.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS_INTO.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

	TRS.copy(MTIVLOTSTS_INTO.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS_INTO.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS_INTO.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS_INTO.LAST_TRAN_USER_ID), in_node, "PRC_USER");

	memcpy(MTIVLOTSTS_INTO.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

	MTIVLOTSTS_INTO.LAST_HIST_SEQ = i_last_active_hist_seq_into + 1;
	//MTIVLOTSTS_INTO.LAST_HIST_SEQ = MTIVLOTSTS_INTO_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS_INTO.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_INTO.LAST_HIST_SEQ;

   /* MTIVLOTSTS_INTO.LAST_HIST_SEQ = MTIVLOTSTS_INTO_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS_INTO.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_INTO_OLD.LAST_HIST_SEQ + 1;*/

    MTIVLOTSTS_INTO.QTY_1 = MTIVLOTSTS_INTO_OLD.QTY_1 + TRS.get_double(in_node, "MOVE_QTY_1");
    MTIVLOTSTS_INTO.QTY_2 = MTIVLOTSTS_INTO_OLD.QTY_2 + TRS.get_double(in_node, "MOVE_QTY_2");
    MTIVLOTSTS_INTO.QTY_3 = MTIVLOTSTS_INTO_OLD.QTY_3 + TRS.get_double(in_node, "MOVE_QTY_3");

    MTIVLOTSTS_INTO.IN_OUT_FLAG = ' ';

    if(MTIVLOTSTS_INTO.QTY_1 < 0.0005)
    {
        MTIVLOTSTS_INTO.LOT_DEL_FLAG = 'Y';
        TRS.copy(MTIVLOTSTS_INTO.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS_INTO.LOT_DEL_USER_ID), in_node, "PRC_USER");
        memcpy(MTIVLOTSTS_INTO.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS_INTO.LOT_DEL_TIME));
        memcpy(MTIVLOTSTS_INTO.LOT_DEL_REASON, "QTY_ZERO", strlen("QTY_ZERO"));
    }
    else
    {
        MTIVLOTSTS_INTO.LOT_DEL_FLAG = ' ';
        memset(MTIVLOTSTS_INTO.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS_INTO.LOT_DEL_USER_ID));
        memset(MTIVLOTSTS_INTO.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS_INTO.LOT_DEL_TIME));
        memset(MTIVLOTSTS_INTO.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS_INTO.LOT_DEL_REASON));
    }

	

    /* History Insert (source lot)************************************************************************/
    DBC_init_mtivlothis(&MTIVLOTHIS);

    //memcpy(MTIVLOTHIS.FROM_TO_MAT_ID, MTIVLOTSTS_INTO.MAT_ID, sizeof(MTIVLOTHIS.FROM_TO_MAT_ID));
    //MTIVLOTHIS.FROM_TO_MAT_VER = MTIVLOTSTS_INTO.MAT_VER;
    //memcpy(MTIVLOTHIS.FROM_TO_FLOW, MTIVLOTSTS_INTO.FLOW, sizeof(MTIVLOTHIS.FROM_TO_FLOW));
    //MTIVLOTHIS.FROM_TO_FLOW_SEQ_NUM = MTIVLOTSTS_INTO.FLOW_SEQ_NUM;
    memcpy(MTIVLOTHIS.FROM_TO_OPER, MTIVLOTSTS_INTO.OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
    MTIVLOTHIS.FROM_TO_QTY_1 = MTIVLOTSTS_INTO.QTY_1;
    MTIVLOTHIS.FROM_TO_QTY_2 = MTIVLOTSTS_INTO.QTY_2;
    MTIVLOTHIS.FROM_TO_QTY_3 = MTIVLOTSTS_INTO.QTY_3;
    //MTIVLOTHIS.FROM_TO_HIST_SEQ = MTIVLOTSTS_INTO.LAST_HIST_SEQ;

	COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, TRS.get_double(in_node, "MOVE_QTY_1"), sizeof(MTIVLOTHIS.TRAN_CMF_3));
  
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

    /*DBC_init_mwiplotmrg(&MWIPLOTMRG);

    memcpy(MWIPLOTMRG.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MWIPLOTMRG.LOT_ID));
    MWIPLOTMRG.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
    memcpy(MWIPLOTMRG.TRAN_TIME, MTIVLOTHIS.TRAN_TIME, sizeof(MWIPLOTMRG.TRAN_TIME));

    memcpy(MWIPLOTMRG.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPLOTMRG.FACTORY));
    memcpy(MWIPLOTMRG.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MWIPLOTMRG.MAT_ID));
    MWIPLOTMRG.MAT_VER = MTIVLOTHIS.MAT_VER;
    memcpy(MWIPLOTMRG.FLOW, MTIVLOTHIS.FLOW, sizeof(MWIPLOTMRG.FLOW));
    MWIPLOTMRG.FLOW_SEQ_NUM = MTIVLOTHIS.FLOW_SEQ_NUM;
    memcpy(MWIPLOTMRG.OPER, MTIVLOTHIS.OPER, sizeof(MWIPLOTMRG.OPER));

    MWIPLOTMRG.FROM_TO_FLAG = MTIVLOTHIS.FROM_TO_FLAG;
    memcpy(MWIPLOTMRG.FROM_TO_LOT_ID, MTIVLOTHIS.FROM_TO_LOT_ID, sizeof(MWIPLOTMRG.FROM_TO_LOT_ID));
    memcpy(MWIPLOTMRG.FROM_TO_MAT_ID, MTIVLOTHIS.FROM_TO_MAT_ID, sizeof(MWIPLOTMRG.FROM_TO_MAT_ID));
    MWIPLOTMRG.FROM_TO_MAT_VER = MTIVLOTHIS.FROM_TO_MAT_VER;
    memcpy(MWIPLOTMRG.FROM_TO_FLOW, MTIVLOTHIS.FROM_TO_FLOW, sizeof(MWIPLOTMRG.FROM_TO_FLOW));
    MWIPLOTMRG.FROM_TO_FLOW_SEQ_NUM = MTIVLOTHIS.FROM_TO_FLOW_SEQ_NUM;
    memcpy(MWIPLOTMRG.FROM_TO_OPER, MTIVLOTHIS.FROM_TO_OPER, sizeof(MWIPLOTMRG.FROM_TO_OPER));

    MWIPLOTMRG.FROM_TO_QTY_1 = MTIVLOTHIS.FROM_TO_QTY_1;
    MWIPLOTMRG.FROM_TO_QTY_2 = MTIVLOTHIS.FROM_TO_QTY_2;
    MWIPLOTMRG.FROM_TO_QTY_3 = MTIVLOTHIS.FROM_TO_QTY_3;
    MWIPLOTMRG.FROM_TO_HIST_SEQ = MTIVLOTHIS.FROM_TO_HIST_SEQ;

    MWIPLOTMRG.HIST_DEL_FLAG = MTIVLOTHIS.HIST_DEL_FLAG;

    DBC_insert_mwiplotmrg(&MWIPLOTMRG);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTMRG INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTMRG.LOT_ID), MWIPLOTMRG.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);


        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
*/
    /* History Insert (into lot)************************************************************************/
    DBC_init_mtivlothis(&MTIVLOTHIS);

    //memcpy(MTIVLOTHIS.FROM_TO_MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTHIS.FROM_TO_MAT_ID));
    //MTIVLOTHIS.FROM_TO_MAT_VER = MTIVLOTSTS.MAT_VER;
    //memcpy(MTIVLOTHIS.FROM_TO_FLOW, MTIVLOTSTS.FLOW, sizeof(MTIVLOTHIS.FROM_TO_FLOW));
    //MTIVLOTHIS.FROM_TO_FLOW_SEQ_NUM = MTIVLOTSTS.FLOW_SEQ_NUM;
    memcpy(MTIVLOTHIS.FROM_TO_OPER, MTIVLOTSTS.OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
    MTIVLOTHIS.FROM_TO_QTY_1 = MTIVLOTSTS.QTY_1;
    MTIVLOTHIS.FROM_TO_QTY_2 = MTIVLOTSTS.QTY_2;
    MTIVLOTHIS.FROM_TO_QTY_3 = MTIVLOTSTS.QTY_3;
    //MTIVLOTHIS.FROM_TO_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

	COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, TRS.get_double(in_node, "MOVE_QTY_1"), sizeof(MTIVLOTHIS.TRAN_CMF_3));
  
	TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

    if(TIV_update_insert_lot_status_history(s_msg_code, 
                                            in_node,
                                            out_node,
                                            s_sys_time,
                                            &MTIVLOTSTS_INTO_OLD,
                                            &MTIVLOTSTS_INTO,
                                            &MTIVLOTHIS) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	TRS.set_string(in_node, "TO_LOT_ID", MTIVLOTSTS_INTO.LOT_ID, sizeof(MTIVLOTSTS_INTO.LOT_ID));
	TRS.set_string(in_node, "INPUT_LOT_ID", MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID));
 
	TRS.set_nstring(in_node, "USE_OPER", TRS.get_string(in_node, "OPER"));
	TRS.set_char(in_node, "WIP_OR_INV", 'I');
	TRS.set_string(in_node, "TRAN_CODE", MP_TIV_TRAN_CODE_MERGE, strlen(MP_TIV_TRAN_CODE_MERGE));
	TRS.set_double(in_node, "INPUT_QTY_1", TRS.get_double(in_node, "MOVE_QTY_1"));
	TRS.set_double(in_node, "INPUT_QTY_2", 0);
	TRS.set_double(in_node, "INPUT_QTY_3", 0);
	TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));

	if (TIV_Create_Material_Usage_Info(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

    /*DBC_init_mwiplotmrg(&MWIPLOTMRG);

    memcpy(MWIPLOTMRG.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MWIPLOTMRG.LOT_ID));
    MWIPLOTMRG.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
    memcpy(MWIPLOTMRG.TRAN_TIME, MTIVLOTHIS.TRAN_TIME, sizeof(MWIPLOTMRG.TRAN_TIME));

    memcpy(MWIPLOTMRG.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPLOTMRG.FACTORY));
    memcpy(MWIPLOTMRG.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MWIPLOTMRG.MAT_ID));
    MWIPLOTMRG.MAT_VER = MTIVLOTHIS.MAT_VER;
    memcpy(MWIPLOTMRG.FLOW, MTIVLOTHIS.FLOW, sizeof(MWIPLOTMRG.FLOW));
    MWIPLOTMRG.FLOW_SEQ_NUM = MTIVLOTHIS.FLOW_SEQ_NUM;
    memcpy(MWIPLOTMRG.OPER, MTIVLOTHIS.OPER, sizeof(MWIPLOTMRG.OPER));

    MWIPLOTMRG.FROM_TO_FLAG = MTIVLOTHIS.FROM_TO_FLAG;
    memcpy(MWIPLOTMRG.FROM_TO_LOT_ID, MTIVLOTHIS.FROM_TO_LOT_ID, sizeof(MWIPLOTMRG.FROM_TO_LOT_ID));
    memcpy(MWIPLOTMRG.FROM_TO_MAT_ID, MTIVLOTHIS.FROM_TO_MAT_ID, sizeof(MWIPLOTMRG.FROM_TO_MAT_ID));
    MWIPLOTMRG.FROM_TO_MAT_VER = MTIVLOTHIS.FROM_TO_MAT_VER;
    memcpy(MWIPLOTMRG.FROM_TO_FLOW, MTIVLOTHIS.FROM_TO_FLOW, sizeof(MWIPLOTMRG.FROM_TO_FLOW));
    MWIPLOTMRG.FROM_TO_FLOW_SEQ_NUM = MTIVLOTHIS.FROM_TO_FLOW_SEQ_NUM;
    memcpy(MWIPLOTMRG.FROM_TO_OPER, MTIVLOTHIS.FROM_TO_OPER, sizeof(MWIPLOTMRG.FROM_TO_OPER));

    MWIPLOTMRG.FROM_TO_QTY_1 = MTIVLOTHIS.FROM_TO_QTY_1;
    MWIPLOTMRG.FROM_TO_QTY_2 = MTIVLOTHIS.FROM_TO_QTY_2;
    MWIPLOTMRG.FROM_TO_QTY_3 = MTIVLOTHIS.FROM_TO_QTY_3;
    MWIPLOTMRG.FROM_TO_HIST_SEQ = MTIVLOTHIS.FROM_TO_HIST_SEQ;

    MWIPLOTMRG.HIST_DEL_FLAG = MTIVLOTHIS.HIST_DEL_FLAG;

    DBC_insert_mwiplotmrg(&MWIPLOTMRG);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTMRG INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTMRG.LOT_ID), MWIPLOTMRG.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);


        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }*/


    ////Add by J.S 2006/01/17
    ////merge에서는 into lot이 생성되는 경우는 없음으로 source lot만 확인하면됨.
    //if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y' && 
    //   MTIVLOTSTS.START_FLAG == 'Y' && COM_isspace(MTIVLOTSTS.START_RES_ID, sizeof(MTIVLOTSTS.START_RES_ID)) == MP_FALSE)
    //{
    //    if(RAS_recount_proc_lot_resource(s_msg_code,
    //                                     out_node,
    //                                     MTIVLOTSTS.FACTORY,
    //                                     MTIVLOTSTS.START_RES_ID,
    //                                     EVENT_END_LOT) == MP_FALSE)
    //    {
    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}


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
//#ifdef _CRR
//    if(COM_isnullspace(TRS.get_string(in_node, "INTO_CRR_ID")) == MP_FALSE || TRS.get_list(in_node, "INTO_CRR_LIST") != 0x00)
//    {
//        TRSNode *crr_in;
//        TRSNode **crr_list;
//        TRSNode *crr_item;
//        int i_idx;
//        int i_crr_count;
//
//        crr_in = TRS.create_node("CRR_IN");
//        TRS.add_char(crr_in, IN_LANGUAGE, TRS.get_language(in_node));
//        TRS.add_nstring(crr_in, IN_FACTORY, TRS.get_factory(in_node));
//        TRS.add_nstring(crr_in, IN_USERID, TRS.get_userid(in_node));
//        TRS.add_nstring(crr_in, "LOT_ID", TRS.get_string(in_node, "INTO_LOT_ID"));
//        TRS.add_nstring(crr_in, "CRR_ID", TRS.get_string(in_node, "INTO_CRR_ID"));
//
//        crr_list = TRS.get_list(in_node, "INTO_CRR_LIST");
//        if(crr_list != 0x00)
//        {
//            i_crr_count = TRS.get_item_count(in_node, "INTO_CRR_LIST");
//            for(i_idx = 0; i_idx < i_crr_count; i_idx++)
//            {
//                crr_item = TRS.add_node(crr_in, "CRR_LIST");
//                TRS.add_nstring(crr_item, "CRR_ID", TRS.get_string(crr_list[i_idx], "CRR_ID"));
//                TRS.add_double(crr_item, "CRR_QTY_1", TRS.get_double(crr_list[i_idx], "CRR_QTY_1"));
//                TRS.add_double(crr_item, "CRR_QTY_2", TRS.get_double(crr_list[i_idx], "CRR_QTY_2"));
//                TRS.add_double(crr_item, "CRR_QTY_3", TRS.get_double(crr_list[i_idx], "CRR_QTY_3"));
//            }
//        }
//        
//        /* Carrier 관련 Update */
//        if(TIV_increase_carrier_lot_qty(s_msg_code,
//                                        out_node,
//                                        crr_in,
//                                        TRS.get_double(in_node, "MOVE_QTY_1"),
//                                        TRS.get_double(in_node, "MOVE_QTY_2"),
//                                        TRS.get_double(in_node, "MOVE_QTY_3")) == MP_FALSE)
//        {
//            TRS.free_node(crr_in);
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//            return MP_FALSE;
//        }
//
//        TRS.free_node(crr_in);
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
//    if(TIV_copy_merge_lot_queue_time(s_msg_code, in_node, out_node) == MP_FALSE)
//    {
//        return MP_FALSE;
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
//
//#ifdef _CRR
//    if(TIV_make_carrier_lot_history(s_msg_code, 
//                                    out_node, 
//                                    MTIVLOTSTS_INTO.LOT_ID) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//#endif /* _CRR */

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Merge_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /*************************************************************************************************************/
    /* Summary Temp Lot Routine Start */
   /* if(COM_compare_global_option(TRS.get_factory(in_node), 
                                 MP_OPTION_MAKE_SUM_TEMP_HISTORY, 
                                 'Y') == MP_TRUE)
    {
        TRSNode* sum_in_node;

        sum_in_node = TRS.create_node("SUMMARY_LOT_IN");
         
        TRS.add_string(sum_in_node, "TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
        TRS.add_string(sum_in_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
        TRS.add_int(sum_in_node, "HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);

        TRS.add_char(sum_in_node, "FROM_TO_FLAG", 'F');
        TRS.add_string(sum_in_node, "FROM_TO_LOT_ID", MTIVLOTSTS_INTO.LOT_ID, sizeof(MTIVLOTSTS_INTO.LOT_ID));
        TRS.add_int(sum_in_node, "FROM_TO_HIST_SEQ", MTIVLOTSTS_INTO.LAST_HIST_SEQ);

        if(COM_proc_user_routine("MES_UserTIV", "TIV_Merge_Lot",
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
    TIV_Merge_Lot_Validation()
        - Validation Check sub function of "TIV_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Merge_Lot_Validation(char *s_msg_code,
                             TRSNode *in_node,
                             TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_INTO;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    //struct MWIPFLWDEF_TAG MWIPFLWDEF;
    //struct MWIPOPRDEF_TAG MWIPOPRDEF;    
    struct MTIVOPRDEF_TAG MTIVOPRDEF;

    //int i_sublot_count;
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
    //if(TRS.get_char(in_node, MP_INV_SUBLOT_FLAG) != 'Y')
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
    //        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTSTS.LOT_ID), MWIPSLTSTS.LOT_ID);
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
    //        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTSTS.LOT_ID), MWIPSLTSTS.LOT_ID);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}

    if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0076");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Into Lot ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "INTO_TIV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "INTO_TIV_LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    else
    {
        DBC_init_mtivlotsts(&MTIVLOTSTS_INTO);
        TRS.copy(MTIVLOTSTS_INTO.FACTORY, sizeof(MTIVLOTSTS_INTO.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVLOTSTS_INTO.LOT_ID, sizeof(MTIVLOTSTS_INTO.LOT_ID), in_node, "INTO_TIV_LOT_ID");
		TRS.copy(MTIVLOTSTS_INTO.OPER, sizeof(MTIVLOTSTS_INTO.OPER), in_node, "TO_OPER");    
        DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_INTO);
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
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_INTO.FACTORY), MTIVLOTSTS_INTO.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_INTO.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);            

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }

    /* Mother Lot and Into Lot Validation */
    if(TRS.str_tcmp(in_node, "TIV_LOT_ID", in_node, "INTO_TIV_LOT_ID") == 0
		&& TRS.str_tcmp(in_node, "FROM_OPER", in_node, "TO_OPER") == 0)
    {
        strcpy(s_msg_code, "WIP-0183"); 
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "INTO_TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_INTO.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
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
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

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
    //        sizeof(MTIVLOTSTS_INTO.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);

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

    /* 2009.04.07. James kwon */
    /* Move qty has to over zero when lot qty is over zero*/
    if(TRS.get_double(in_node, "MOVE_QTY_1") < 0.0005 && MTIVLOTSTS.QTY_1 > 0.0005)
    {
        strcpy(s_msg_code, "WIP-0342");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
        TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
/* Grade 가 'G'가 아닌 경우 Qty2의 수량을 0일 수 있다.
    if(TRS.get_double(in_node, "MOVE_QTY_2") < 0.0005 && MTIVLOTSTS.QTY_2 > 0.0005)
    {
        strcpy(s_msg_code, "WIP-0342");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
        TRS.add_fieldmsg(out_node, "QTY_2", MP_DBL, MTIVLOTSTS.QTY_2);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(TRS.get_double(in_node, "MOVE_QTY_3") < 0.0005 && MTIVLOTSTS.QTY_3 > 0.0005)
    {
        strcpy(s_msg_code, "WIP-0342");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));
        TRS.add_fieldmsg(out_node, "QTY_3", MP_DBL, MTIVLOTSTS.QTY_3);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
*/
    if(TRS.get_double(in_node, "MOVE_QTY_1") < -0.0005 && 
       TRS.get_double(in_node, "MOVE_QTY_2") < -0.0005 && 
       TRS.get_double(in_node, "MOVE_QTY_3") < -0.0005)
    {
        strcpy(s_msg_code, "WIP-0041");
        TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_1"));
        TRS.add_fieldmsg(out_node, "MOVE_QTY_2", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_2"));
        TRS.add_fieldmsg(out_node, "MOVE_QTY_3", MP_DBL, TRS.get_double(in_node, "MOVE_QTY_3"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* 2005.10.13. CM Koo. */
    /* 소수점 4째 이하의 값은 무시함. */
    //if(TRS.get_double(in_node, "MOVE_QTY_1") > MTIVLOTSTS.QTY_1) 
    if(MTIVLOTSTS.QTY_1 - TRS.get_double(in_node, "MOVE_QTY_1") < -0.0005 ) 
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

    ///* 다른 Material ID 로 Merge 가능한지 Check */
    //if(COM_compare_global_option(TRS.get_factory(in_node), 
    //                             MP_OPTION_MERGE_DIFF_MAT_ID, 
    //                             'Y') != MP_TRUE)
    //{
    //    if(memcmp(MTIVLOTSTS.MAT_ID, MTIVLOTSTS_INTO.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID)) != 0)
    //    {
    //        strcpy(s_msg_code, "WIP-0261");
    //        TRS.add_fieldmsg(out_node, "SOURCE LOT MAT_ID", MP_STR, sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);
    //        TRS.add_fieldmsg(out_node, "INTO LOT MAT_ID", MP_STR, sizeof(MTIVLOTSTS_INTO.MAT_ID), MTIVLOTSTS_INTO.MAT_ID);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}

    ///* 다른 Material Version 로 Merge 가능한지 Check */
    //if(COM_compare_global_option(TRS.get_factory(in_node), 
    //                             MP_OPTION_MERGE_DIFF_MAT_VERSION, 
    //                             'Y') != MP_TRUE)
    //{
    //    if(MTIVLOTSTS.MAT_VER != MTIVLOTSTS_INTO.MAT_VER)
    //    {
    //        strcpy(s_msg_code, "WIP-0261");
    //        TRS.add_fieldmsg(out_node, "SOURCE LOT MAT_VER", MP_INT, MTIVLOTSTS.MAT_VER);
    //        TRS.add_fieldmsg(out_node, "INTO LOT MAT_VER", MP_INT, MTIVLOTSTS_INTO.MAT_VER);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}

    //if(COM_compare_global_option(TRS.get_factory(in_node), 
    //                             MP_OPTION_MERGE_DIFF_OPER, 
    //                             'Y') == MP_FALSE)
    //{
    //    if(memcmp(MTIVLOTSTS.OPER, MTIVLOTSTS_INTO.OPER, sizeof(MTIVLOTSTS.OPER)) != 0)
    //    {
    //        strcpy(s_msg_code, "WIP-0090");
    //        TRS.add_fieldmsg(out_node, "SOURCE LOT OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
    //        TRS.add_fieldmsg(out_node, "INTO LOT OPER", MP_STR, sizeof(MTIVLOTSTS_INTO.OPER), MTIVLOTSTS_INTO.OPER);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}
    //
    ///* 2006.04.10. CM Koo. */
    ///* 다른 공정으로 MERGE 가능한 경우 현재 공정과 Merge 공정의 Unit은 동일해야만 한다. */
    //else
    //{
    //    char c_unit_change;

    //    c_unit_change = ' ';
    //    if(COM_check_unit_diff_oper(s_msg_code,
    //                                out_node,
    //                                MTIVLOTSTS.FACTORY,
    //                                MTIVLOTSTS.OPER,
    //                                MTIVLOTSTS.FACTORY,
    //                                MTIVLOTSTS_INTO.OPER,
    //                                &c_unit_change) == MP_FALSE)
    //    {
    //        return MP_FALSE;
    //    }

    //    if(c_unit_change == 'Y')
    //    {
    //        strcpy(s_msg_code, "WIP-0324");
    //        TRS.add_fieldmsg(out_node, "SOURCE LOT OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
    //        TRS.add_fieldmsg(out_node, "INTO LOT OPER", MP_STR, sizeof(MTIVLOTSTS_INTO.OPER), MTIVLOTSTS_INTO.OPER);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;
    //        return MP_FALSE;
    //    }
    //}

    /* Start Flag Validation */
    // Add by J.S. 2011.04.07  Start flag가 달라도 Merge 허용하는 옵션 추가
    // Merge_ext에 check routine추가, merge_ext는 옵션에 상관없이 허용하지 않는다
   /* if(COM_compare_global_option(TRS.get_factory(in_node), 
                                 MP_OPTION_MERGE_DIFF_PROCESS_STATUS, 
                                 'Y') != MP_TRUE)
    {
        if(MTIVLOTSTS.START_FLAG != MTIVLOTSTS_INTO.START_FLAG) 
        {
            strcpy(s_msg_code, "WIP-0093");
            TRS.add_fieldmsg(out_node, "SOURCE LOT LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
            TRS.add_fieldmsg(out_node, "INTO LOT LOT_ID", MP_STR, sizeof(MTIVLOTSTS_INTO.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }*/

    ///* Into Lot Delete Validation */
    //if(MTIVLOTSTS_INTO.LOT_DEL_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0076");
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    ///* Into Lot Hold Validation */
    //if(MTIVLOTSTS_INTO.HOLD_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0059");
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_INTO.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    ///* Into Lot Instrasit Validation */
    //if(MTIVLOTSTS_INTO.TRANSIT_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0060");
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_INTO.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    /*if(TIV_check_carrier_lot_relation(s_msg_code,
                                      out_node,
                                      in_node,
                                      TRS.get_double(in_node, "MOVE_QTY_1")) == MP_FALSE)
    {
        return MP_FALSE;
    }*/

    /* 2011.07.05. Aiden. Merge 시 새로운 Carrier 가 Attach 되는 경우가 있으므로 아래 부분 주석 */
    //{
    //    TRSNode *crr_in;
    //    TRSNode **crr_list;
    //    TRSNode *crr_item;
    //    int i_idx;
    //    int i_crr_count;

    //    crr_in = TRS.create_node("CRR_IN");
    //    TRS.add_char(crr_in, IN_LANGUAGE, TRS.get_language(in_node));
    //    TRS.add_nstring(crr_in, IN_FACTORY, TRS.get_factory(in_node));
    //    TRS.add_nstring(crr_in, IN_USERID, TRS.get_userid(in_node));
    //    TRS.add_nstring(crr_in, "LOT_ID", TRS.get_string(in_node, "INTO_LOT_ID"));
    //    TRS.add_nstring(crr_in, "CRR_ID", TRS.get_string(in_node, "INTO_CRR_ID"));

    //    crr_list = TRS.get_list(in_node, "INTO_CRR_LIST");
    //    if(crr_list != 0x00)
    //    {
    //        i_crr_count = TRS.get_item_count(in_node, "INTO_CRR_LIST");
    //        for(i_idx = 0; i_idx < i_crr_count; i_idx++)
    //        {
    //            crr_item = TRS.add_node(crr_in, "CRR_LIST");
    //            TRS.add_nstring(crr_item, "CRR_ID", TRS.get_string(crr_list[i_idx], "CRR_ID"));
    //            TRS.add_double(crr_item, "CRR_QTY_1", TRS.get_double(crr_list[i_idx], "CRR_QTY_1"));
    //            TRS.add_double(crr_item, "CRR_QTY_2", TRS.get_double(crr_list[i_idx], "CRR_QTY_2"));
    //            TRS.add_double(crr_item, "CRR_QTY_3", TRS.get_double(crr_list[i_idx], "CRR_QTY_3"));
    //        }
    //    }

    //    if(TIV_check_carrier_lot_relation(s_msg_code,
    //                                      out_node,
    //                                      crr_in,
    //                                      0) == MP_FALSE)
    //    {
    //        TRS.free_node(crr_in);
    //        return MP_FALSE;
    //    }

    //    TRS.free_node(crr_in);
    //}

    /* 2008.01.21. Aiden. 공정 이동에 대해서 다음 공정의 TIV_FLAG를 Status에 기록하지 못하게 변경. TIV_FLAG는 STORE TR에 의해서만 설정되도록 함. */
    /* Store 공정에서도 TR이 발생할 수 있도록 변경함. */
    /* 공정 이동에 대해서 다음 공정의 TRANSIT_FLAG를 Status에 기록하지 못하게 변경. TRANSIT_FLAG는 SHIP TR에 의해서만 설정되도록 함. */
    /* Into Lot Store Validation */
    //if(MTIVLOTSTS_INTO.TIV_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0061");
    //    sprintf(Cmn_Out->h_field_msg, "LOT_ID = [%.*s]",
    //        sizeof(MTIVLOTSTS_INTO.LOT_ID), MTIVLOTSTS_INTO.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

   /* if(TIV_check_lot_in_batch(MTIVLOTSTS.FACTORY, MTIVLOTSTS.LOT_ID) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0417");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }*/

    ///* CMF Validation */
    //if(TIV_check_lot_cmf_merge_lot(s_msg_code, in_node, out_node) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}


/*******************************************************************************
    TIV_check_lot_cmf_merge_lot()
        - Check the Conditions before Merge Lot CMF Definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_lot_cmf_merge_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node)
{
    struct check_list s_check_list;

    COM_fill_check_list(&s_check_list, in_node, 20, "TRAN_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_TRN_MERGE, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

