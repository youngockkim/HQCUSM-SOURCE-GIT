/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_defect_lot.c
    Description : Defect Transaction Process

    MES Version : 5.2.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/21  Patrick        Create

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"

int TIV_defect_Lot_Validation(char *Msg_Code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    TIV_Defect_Lot()
        - Defect Lot Transaction Process
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_Defect_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_DEFECT_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_DEFECT_LOT", out_node);

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
    TIV_DEFECT_LOT()
        - Defect Lot
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_DEFECT_LOT(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    //struct MTIVINSDFT_TAG MTIVINSDFT;
    struct MTIVLOTDEF_TAG MTIVLOTDEF;
    struct MTIVLOTDEF_TAG MTIVLOTDEF_LOT;
    //struct MTIVIQCHIS_TAG MTIVIQCHIS;


    TRSNode **defect_list;

    int i;
    int i_lot_def_seq;
    double d_total_def_count;
    //int i_max_hist_seq;
    char s_sys_time[14];
    char s_tran_time[14];

    LOG_head("TIV_DEFECT_LOT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Defect_Lot",
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

     /* Get TransTime */
    if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
    {
        memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
    }
    else
    {
        TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
    }
    
    if(TIV_defect_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    
    TRS.set_nstring(in_node, "__FACTORY", TRS.get_string(in_node, IN_FACTORY));    
    if(TIV_Lot_Fill_InTag_Cmf(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");  
    TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "OPER");
    DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_OLD);
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
        }

        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT FOR UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);        
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS_OLD.OPER), MTIVLOTSTS_OLD.OPER);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

    MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_DEFECT, strlen(MP_INV_TRAN_CODE_DEFECT));
    memset(MTIVLOTSTS.LAST_TRAN_TYPE, ' ', sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "COMMENT");
    MTIVLOTSTS.IN_OUT_FLAG = ' ';

    /*TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_1");
    TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_2");
    TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_3");
    TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_4");
    TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_5");
    TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_6");
    TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_7");
    TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_8");
    TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_9");
    TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_10");
    TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_11");
    TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_12");
    TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_13");
    TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_14");
    TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_15");
    TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_16");
    TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_17");
    TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_18");
    TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_19");
    TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_20");*/

    DBC_init_mtivlothis(&MTIVLOTHIS);

    /* Lot Status & History Update Insert */
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

    if(TRS.get_item_count(in_node, "DEFECT_LIST") > 0)
    {
        //For Get the lastest hist_seq
        DBC_init_mtivlotdef(&MTIVLOTDEF);
        memcpy(MTIVLOTDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVLOTDEF.FACTORY));
        DBC_select_mtivlotdef(2, &MTIVLOTDEF);
        if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTDEF DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTDEF.FACTORY), MTIVLOTDEF.FACTORY);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //For Get the latest seq_num of Lot
        DBC_init_mtivlotdef(&MTIVLOTDEF_LOT);
        memcpy(MTIVLOTDEF_LOT.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVLOTDEF_LOT.FACTORY));
        memcpy(MTIVLOTDEF_LOT.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTDEF_LOT.LOT_ID));
        DBC_select_mtivlotdef(3, &MTIVLOTDEF_LOT);
        if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTDEF DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTDEF_LOT.FACTORY), MTIVLOTDEF_LOT.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTDEF_LOT.LOT_ID), MTIVLOTDEF_LOT.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        defect_list = TRS.get_list(in_node, "DEFECT_LIST");
        
        /*DBC_init_mtivlotdef(&MTIVLOTDEF);*/
        memcpy(MTIVLOTDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVLOTDEF.FACTORY));
        memcpy(MTIVLOTDEF.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTDEF.LOT_ID));
        memcpy(MTIVLOTDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTDEF.MAT_ID));
        MTIVLOTDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
        memcpy(MTIVLOTDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVLOTDEF.OPER));
        memcpy(MTIVLOTDEF.TRAN_TIME, s_tran_time, sizeof(MTIVLOTDEF.TRAN_TIME));

        MTIVLOTDEF.LOT_HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
        i_lot_def_seq = MTIVLOTDEF_LOT.SEQ_NUM;

		d_total_def_count = 0;

        for(i = 0; i < TRS.get_item_count(in_node, "DEFECT_LIST"); i++)
        {
            MTIVLOTDEF.HIST_SEQ = MTIVLOTDEF.HIST_SEQ + 1;
            i_lot_def_seq++;
            MTIVLOTDEF.SEQ_NUM =  i_lot_def_seq;
            TRS.copy(MTIVLOTDEF.DEF_CODE, sizeof(MTIVLOTDEF.DEF_CODE), defect_list[i], "DEF_CODE"); 
            MTIVLOTDEF.DEF_QTY = TRS.get_double(defect_list[i], "DEF_QTY");

            DBC_insert_mtivlotdef(&MTIVLOTDEF);
            if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "INV-0004");
                TRS.add_fieldmsg(out_node, "MTIVLOTDEF INSERT", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTDEF.LOT_ID), MTIVLOTDEF.LOT_ID);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_TRANS;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
            d_total_def_count += MTIVLOTDEF.DEF_QTY;
        }
    
       // //MTIVIQCHIS
       // 
       //DBC_init_mtiviqchis(&MTIVIQCHIS);
       //TRS.copy(MTIVIQCHIS.FACTORY, sizeof(MTIVIQCHIS.FACTORY), in_node, IN_FACTORY);
       //DBC_select_mtiviqchis(2, &MTIVIQCHIS);//단순히 HIST_SEQ얻기 위해 
       //{
       //    memcpy(MTIVIQCHIS.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVIQCHIS.FACTORY));
       //    memcpy(MTIVIQCHIS.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVIQCHIS.LOT_ID));
       //    MTIVIQCHIS.LOT_HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
       //    MTIVIQCHIS.HIST_SEQ++;
       //    memcpy(MTIVIQCHIS.TRAN_TIME, s_tran_time, sizeof(MTIVIQCHIS.TRAN_TIME));
       //    MTIVIQCHIS.PASS_FAIL_FLAG = TRS.get_char(in_node, "PASS_FLAG");
       //    MTIVIQCHIS.SAMPLE_SIZE = TRS.get_int(in_node, "SAMPLE_SIZE");
       //    MTIVIQCHIS.TOTAL_DEF_QTY = d_total_def_count;
       //    DBC_insert_mtiviqchis(&MTIVIQCHIS);
       //    if(DB_error_code != DB_SUCCESS) 
       //     {
       //         strcpy(s_msg_code, "INV-0004");
       //         TRS.add_fieldmsg(out_node, "MTIVIQCHIS INSERT", MP_NVST);
       //         TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTDEF.LOT_ID), MTIVLOTDEF.LOT_ID);
       //         TRS.add_dberrmsg(out_node, DB_error_msg);

       //         gs_log_type.type = MP_LOG_ERROR;
       //         gs_log_type.e_type = MP_LOG_E_SYSTEM;
       //         gs_log_type.category = MP_LOG_CATE_TRANS;
       //         COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
       //         return MP_FALSE;
       //     }
       //}

       
           
     
    }

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Defect_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_defect_Lot_Validation()
        - Lot Transaction Validation Check
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_defect_Lot_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    //struct MWIPFLWDEF_TAG MWIPFLWDEF;  
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    //struct MWIPMHDSTS_TAG MWIPMHDSTS;

     /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    ///* validation input value */
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
   
    if(TRS.get_item_count(in_node, "DEFECT_LIST") <= 0)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "DEFECT_LIST_COUNT", MP_INT, TRS.get_item_count(in_node, "DEFECT_LIST"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Lot Delete Validation */
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
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    return MP_TRUE;
}
