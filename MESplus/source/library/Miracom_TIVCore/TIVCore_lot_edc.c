/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_lot_edc.c
    Description : Lot Edc transaction function module

    MES Version : 5.2.0

    Function List
        - INV_Lot_Edc()
            + Lot Edc
        - INV_LOT_EDC()
            + Main sub function of "INV_Lot_Edc" function
            + Lot Edc definition
        - INV_Lot_Edc_Validation()
            + Validation Check sub function of "INV_LOT_EDC" function
            + Check the conditions before Lot Edc definition
        - INV_check_lot_cmf_lot_edc()
            + Check the Conditions before Lot Edc CMF Definition

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/06/28  Aiden          Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"

int INV_Lot_Edc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    INV_Lot_Edc()
        - Lot Edc
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int INV_Lot_Edc(TRSNode *in_node, TRSNode *out_node)
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
    memcpy(gs_alm_module, MP_INV_TRAN_CODE_EDC, strlen(MP_INV_TRAN_CODE_EDC));
#endif /* _ALM */

    i_ret = INV_LOT_EDC(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "INV_LOT_EDC", out_node);

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
    INV_LOT_EDC()
        - Main sub function of "INV_Lot_Edc" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int INV_LOT_EDC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    char s_sys_time[14];
    char s_tran_time[14];


    LOG_head("INV_Lot_EDC");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("back_time", MP_NSTR, TRS.get_string(in_node, "BACK_TIME"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("last_active_lot_grp_seq", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    //LOG_add("flow", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    //LOG_add("flow_seq_num", MP_INT, TRS.get_int(in_node, "FLOW_SEQ_NUM"));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("col_set_id", MP_NSTR, TRS.get_string(in_node, "COL_SET_ID"));
    LOG_add("col_set_version", MP_INT, TRS.get_int(in_node, "COL_SET_VERSION"));
    LOG_add("select_mfo_flag", MP_CHR, TRS.get_char(in_node, "SELECT_MFO_FLAG"));
    //LOG_add("tran_cmf_1", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_1"));
    //LOG_add("tran_cmf_2", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_2"));
    //LOG_add("tran_cmf_3", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_3"));
    //LOG_add("tran_cmf_4", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_4"));
    //LOG_add("tran_cmf_5", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_5"));
    //LOG_add("tran_cmf_6", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_6"));
    //LOG_add("tran_cmf_7", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_7"));
    //LOG_add("tran_cmf_8", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_8"));
    //LOG_add("tran_cmf_9", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_9"));
    //LOG_add("tran_cmf_10", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_10"));
    //LOG_add("tran_cmf_11", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_11"));
    //LOG_add("tran_cmf_12", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_12"));
    //LOG_add("tran_cmf_13", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_13"));
    //LOG_add("tran_cmf_14", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_14"));
    //LOG_add("tran_cmf_15", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_15"));
    //LOG_add("tran_cmf_16", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_16"));
    //LOG_add("tran_cmf_17", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_17"));
    //LOG_add("tran_cmf_18", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_18"));
    //LOG_add("tran_cmf_19", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_19"));
    //LOG_add("tran_cmf_20", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_20"));
    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("INV", "INV_Lot_Edc",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memset(s_tran_time, ' ', sizeof(s_tran_time));

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

    /* Validation Check */
    if(INV_Lot_Edc_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, "FACTORY");
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "LOT_ID");    
    DBC_select_mtivlotsts(1, &MTIVLOTSTS_OLD);
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
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_EDC, strlen(MP_INV_TRAN_CODE_EDC));
    memset(MTIVLOTSTS.LAST_TRAN_TYPE, ' ', sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));    
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

    MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

    //MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    //MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;

    /* History Insert */
    DBC_init_mtivlothis(&MTIVLOTHIS);

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

//#ifdef _CRR
//    if(WIP_make_carrier_lot_history(s_msg_code, 
//                                    out_node, 
//                                    MTIVLOTSTS.LOT_ID) == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//#endif /* _CRR */

    if(COM_proc_user_routine("INV", "INV_Lot_Edc",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    ///*************************************************************************************************************/
    ///* Summary Temp Lot Routine Start */
    //if(COM_compare_global_option(TRS.get_factory(in_node), 
    //                             MP_OPTION_MAKE_SUM_TEMP_HISTORY, 
    //                             'Y') == MP_TRUE)
    //{
    //      TRSNode* sum_in_node;
    //      sum_in_node = TRS.create_node("SUMMARY_LOT_IN");
    //       
    //      TRS.add_string(sum_in_node, "TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
    //      TRS.add_string(sum_in_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
    //      TRS.add_int(sum_in_node, "HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);

    //      if(COM_proc_user_routine("WIP", "WIP_Lot_EDC",
    //                               MP_UPOINT_SUMMARY_LOT,
    //                               sum_in_node,
    //                               out_node) == MP_FALSE)     
    //                               
    //      {
    //          TRS.free_node(sum_in_node);
    //          return MP_FALSE;
    //      }
    //      TRS.free_node(sum_in_node);
    //}
    ///* Summary Temp Lot Routine End */
    ///*************************************************************************************************************/

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    INV_Lot_Edc_Validation()
        - Validation Check sub function of "WIP_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int INV_Lot_Edc_Validation(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;    
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MWIPOPRDEF_TAG MWIPOPRDEF;    

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Lot ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    else
    {
        DBC_init_mtivlotsts(&MTIVLOTSTS);
        TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");        
        DBC_select_mtivlotsts_for_update(1, &MTIVLOTSTS);
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
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);            

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }

    /* Lot Delete Validation */
    if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0076");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* Lot Hold Validation */
    if(MTIVLOTSTS.HOLD_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0059");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    ///* Lot Instrasit Validation */
    //if(MTIVLOTSTS.TRANSIT_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0060");
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
    //    TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(TRS.mem_cmp(in_node, IN_FACTORY, MTIVLOTSTS.FACTORY, strlen(TRS.get_string(in_node, IN_FACTORY))) != 0)
    {
        strcpy(s_msg_code, "WIP-0063");
        TRS.add_fieldmsg(out_node, "FACTORY 1", MP_NSTR, TRS.get_string(in_node, IN_FACTORY));
        TRS.add_fieldmsg(out_node, "FACTORY 2", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") < 1)
    {
        TRS.set_int(in_node, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

        if(TRS.get_char(in_node, "SELECT_MFO_FLAG") != 'Y')
        {
            TRS.set_string(in_node, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
            TRS.set_int(in_node, "MAT_VER", MTIVLOTSTS.MAT_VER);
            //TRS.set_string(in_node, "FLOW", MTIVLOTSTS.FLOW, sizeof(MTIVLOTSTS.FLOW));
            //TRS.set_int(in_node, "FLOW_SEQ_NUM", MTIVLOTSTS.FLOW_SEQ_NUM);
            TRS.set_string(in_node, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
        }
    }
    else
    {
        /* Hist Seq Validation */
        if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ) 
        {
            strcpy(s_msg_code, "WIP-0113");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
            TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }

        /* Material Validation */
        if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
        {
            strcpy(s_msg_code, "WIP-0001");
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
        else
        {
            if(TRS.get_char(in_node, "SELECT_MFO_FLAG") != 'Y')
            {
                if(TRS.mem_cmp(in_node, "MAT_ID", MTIVLOTSTS.MAT_ID, strlen(TRS.get_string(in_node, "MAT_ID"))) != 0)
                {
                    strcpy(s_msg_code, "WIP-0064");
                    TRS.add_fieldmsg(out_node, "MAT_ID 1", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
                    TRS.add_fieldmsg(out_node, "MAT_ID 2", MP_STR, sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                    gs_log_type.category = MP_LOG_CATE_TRANS;
                    return MP_FALSE;
                }
                if(TRS.get_int(in_node, "MAT_VER") != MTIVLOTSTS.MAT_VER)
                {
                    strcpy(s_msg_code, "WIP-0331");
                    TRS.add_fieldmsg(out_node, "MAT_VER 1", MP_INT, TRS.get_int(in_node, "MAT_VER"));
                    TRS.add_fieldmsg(out_node, "MAT_VER 2", MP_INT, MTIVLOTSTS.MAT_VER);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                    gs_log_type.category = MP_LOG_CATE_TRANS;
                    return MP_FALSE;
                }
            }
        }

        ///* Store 상태이면 Flow 체크하지 않음. */
        //if(MTIVLOTSTS.INV_FLAG != 'Y')
        //{
        //    /* Flow Validation */
        //    if(COM_isnullspace(TRS.get_string(in_node, "FLOW")) == MP_TRUE)
        //    {
        //        strcpy(s_msg_code, "WIP-0001");
        //        TRS.add_fieldmsg(out_node, "FLOW", MP_NVST);

        //        gs_log_type.type = MP_LOG_ERROR;
        //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        //        gs_log_type.category = MP_LOG_CATE_TRANS;
        //        return MP_FALSE;
        //    }
        //    else
        //    {
        //        if(TRS.get_char(in_node, "SELECT_MFO_FLAG") != 'Y')
        //        {
        //            if(TRS.mem_cmp(in_node, "FLOW", MTIVLOTSTS.FLOW, sizeof(MTIVLOTSTS.FLOW)) != 0)
        //            {
        //                strcpy(s_msg_code, "WIP-0065");
        //                TRS.add_fieldmsg(out_node, "FLOW 1", MP_NSTR, TRS.get_string(in_node, "FLOW"));
        //                TRS.add_fieldmsg(out_node, "FLOW 2", MP_STR, sizeof(MTIVLOTSTS.FLOW), MTIVLOTSTS.FLOW);

        //                gs_log_type.type = MP_LOG_ERROR;
        //                gs_log_type.e_type = MP_LOG_E_VALIDATION;
        //                gs_log_type.category = MP_LOG_CATE_TRANS;
        //                return MP_FALSE;
        //            }
        //        }
        //    }
        //}

        /* Operation Validation */
        if(COM_isnullspace(TRS.get_string(in_node, "OPER")) == MP_TRUE)
        {
            strcpy(s_msg_code, "WIP-0001");
            TRS.add_fieldmsg(out_node, "OPER", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
        else
        {
            if(TRS.get_char(in_node, "SELECT_MFO_FLAG") != 'Y')
            {
                if(TRS.mem_cmp(in_node, "OPER", MTIVLOTSTS.OPER, strlen(TRS.get_string(in_node, "OPER"))) != 0)
                {
                    strcpy(s_msg_code, "WIP-0066");
                    TRS.add_fieldmsg(out_node, "OPER 1", MP_NSTR, TRS.get_string(in_node, "OPER"));
                    TRS.add_fieldmsg(out_node, "OPER 2", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                    gs_log_type.category = MP_LOG_CATE_TRANS;
                    return MP_FALSE;
                }
            }
        }
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0005");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }     
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "MAT_ID");
    MWIPMATDEF.MAT_VER = TRS.get_int(in_node, "MAT_VER");
    DBC_select_mwipmatdef(1, &MWIPMATDEF);
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
        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(MWIPMATDEF.DELETE_FLAG == 'Y')
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

    DBC_init_mwipoprdef(&MWIPOPRDEF);
    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "OPER");
    DBC_select_mwipoprdef(1, &MWIPOPRDEF);
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
        TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(MWIPOPRDEF.SEC_CHK_FLAG == 'Y')
    {
        if(TRS.get_char(in_node, MP_NOTCHECK_PRIVILEGE) != 'Y')
        {
            /* Privilege Validation */
            if(COM_check_privilege(s_msg_code, 
                                   out_node, 
                                   '2',
                                   MWIPOPRDEF.FACTORY, 
                                   MP_PRV_TYPE_OPER,
                                   MWIPOPRDEF.OPER,
                                   sizeof(MWIPOPRDEF.OPER),
                                   "",
                                   0,
                                   "",
                                   0,
                                   TRS.get_userid(in_node)) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
    }

    if(COM_isnullspace(TRS.get_string(in_node, "COL_SET_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "COL_SET_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if(TRS.get_int(in_node, "COL_SET_VERSION") < 1)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "COL_SET_VERSION", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }    

    ///* CMF Validation */
    //if(WIP_check_cmf_lot_edc(s_msg_code, in_node, out_node) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    /* Back Time Check */
    if(COM_check_backtime(s_msg_code,
                          in_node,
                          out_node,
                          MTIVLOTSTS.LAST_TRAN_TIME) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

///*******************************************************************************
//    WIP_check_cmf_lot_edc()
//        - Check the Conditions before Lot EDC TRAN_CMF Definition
//    Return Value
//        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
//    Arguments
//        - char *s_msg_code : Error Message Code
//        - TRSNode *in_node : Input Message structure
//        - TRSNode *out_node : Output Message structure
//*******************************************************************************/
//int WIP_check_cmf_lot_edc(char *s_msg_code,
//                          TRSNode *in_node,
//                          TRSNode *out_node)
//{
//    struct check_list s_check_list;
//
//    COM_fill_check_list(&s_check_list, in_node, 20, "TRAN_CMF");
//    if(COM_check_cmf(s_msg_code, 
//                     out_node, 
//                     MP_CMF_TRN_LOTEDC, 
//                     TRS.get_factory(in_node), 
//                     &s_check_list) == MP_FALSE)
//    {
//        return MP_FALSE;
//    }
//
//    return MP_TRUE;
//}

