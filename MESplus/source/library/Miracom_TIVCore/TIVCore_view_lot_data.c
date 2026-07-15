/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot_data.c
    Description : Lot Data Inquiry related function module

    MES Version : 4.0.0

    Function List
        - TIV_View_Lot_Data() 
            + View Lot Data List of the Lot history
        - TIV_VIEW_LOT_DATA() 
            + Main sub function of "TIV_View_Lot_Data" function
            + View Lot Data List of the Lot history

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/06/29  Aiden          Create

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"
#ifdef _SPM
#include <SPMCore_common.h>
#endif

/*******************************************************************************
    TIV_View_Lot_Data()
        - View Lot Data List of the Lot history
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_Data(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT_DATA", out_node);

    if(i_ret == MP_TRUE) 
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
    TIV_VIEW_LOT_DATA()
        - Main sub function of "TIV_View_Lot_Data" function
        - View Lot Data List of the Lot history
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
     Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MEDCLOTDAT_TAG MEDCLOTDAT;
    struct MEDCCOLUNT_TAG MEDCCOLUNT;
    struct MEDCCOLCHR_TAG MEDCCOLCHR;
    struct MEDCCOLCHE_TAG MEDCCOLCHE;
    struct MEDCCHRDEF_TAG MEDCCHRDEF;
    int i_select = 0;

    TRSNode *data_item;

    LOG_head("TIV_View_Lot_Data");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("hist_seq", MP_INT, TRS.get_int(in_node, "HIST_SEQ"));
    LOG_add("include_del_hist", MP_CHR, TRS.get_char(in_node, "INCLUDE_DEL_HIST"));
    LOG_add("next_col_set_id", MP_NSTR, TRS.get_string(in_node, "NEXT_COL_SET_ID"));
    LOG_add("next_char_seq_num", MP_INT, TRS.get_int(in_node, "NEXT_CHAR_SEQ_NUM"));
    LOG_add("next_unit_seq_num", MP_INT, TRS.get_int(in_node, "NEXT_UNIT_SEQ_NUM"));
    LOG_add("next_value_seq_num", MP_INT, TRS.get_int(in_node, "NEXT_VALUE_SEQ_NUM"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("EDC", "TIV_View_Lot_Data",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EDC-0001");
        TRS.add_fieldmsg(out_node, IN_FACTORY, MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Lot ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "EDC-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }    

    if(TRS.get_int(in_node, "HIST_SEQ") < 1)
    {
        strcpy(s_msg_code, "EDC-0001");
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
    DBC_select_mtivlotsts(4, &MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "EDC-0050");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "EDC-0004");
            TRS.add_dberrmsg(out_node,DB_error_msg);
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_medclotdat(&MEDCLOTDAT);
    TRS.copy(MEDCLOTDAT.LOT_ID, sizeof(MEDCLOTDAT.LOT_ID), in_node, "LOT_ID");
    MEDCLOTDAT.HIST_SEQ  = TRS.get_int(in_node, "HIST_SEQ");


    if (TRS.get_char(in_node, "INCLUDE_DEL_HIST") == 'Y')
    {
        MEDCLOTDAT.HIST_DEL_FLAG = 'Y';
    }

    MEDCLOTDAT.COL_SEQ  = TRS.get_int(in_node, "NEXT_COL_SEQ");
    TRS.copy(MEDCLOTDAT.COL_SET_ID, sizeof(MEDCLOTDAT.COL_SET_ID), in_node, "NEXT_COL_SET_ID");
    MEDCLOTDAT.CHAR_SEQ_NUM  = TRS.get_int(in_node, "NEXT_CHAR_SEQ_NUM");
    MEDCLOTDAT.UNIT_SEQ_NUM  = TRS.get_int(in_node, "NEXT_UNIT_SEQ_NUM");
    MEDCLOTDAT.VALUE_SEQ_NUM  = TRS.get_int(in_node, "NEXT_VALUE_SEQ_NUM");

    // È®Àå¿ë
    i_select = 2;

    DBC_open_medclotdat(i_select, &MEDCLOTDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "EDC-0004");
        TRS.add_fieldmsg(out_node, "MEDCLOTDAT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MEDCLOTDAT.LOT_ID), MEDCLOTDAT.LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MEDCLOTDAT.HIST_SEQ);
        TRS.add_fieldmsg(out_node, "HIST_DEL_FLAG", MP_CHR, MEDCLOTDAT.HIST_DEL_FLAG);
        TRS.add_fieldmsg(out_node, "CHAR_SEQ_NUM", MP_INT, MEDCLOTDAT.CHAR_SEQ_NUM);
        TRS.add_fieldmsg(out_node, "UNIT_SEQ_NUM", MP_INT, MEDCLOTDAT.UNIT_SEQ_NUM);
        TRS.add_fieldmsg(out_node, "VALUE_SEQ_NUM", MP_INT, MEDCLOTDAT.VALUE_SEQ_NUM);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_medclotdat(i_select, &MEDCLOTDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                DBC_close_medclotdat(i_select);
                break;
            }
            else
            {
                strcpy(s_msg_code, "EDC-0004");
                TRS.add_fieldmsg(out_node, "MEDCLOTDAT FETCH", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MEDCLOTDAT.LOT_ID), MEDCLOTDAT.LOT_ID);
                TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MEDCLOTDAT.HIST_SEQ);
                TRS.add_fieldmsg(out_node, "HIST_DEL_FLAG", MP_CHR, MEDCLOTDAT.HIST_DEL_FLAG);
                TRS.add_fieldmsg(out_node, "CHAR_SEQ_NUM", MP_INT, MEDCLOTDAT.CHAR_SEQ_NUM);
                TRS.add_fieldmsg(out_node, "UNIT_SEQ_NUM", MP_INT, MEDCLOTDAT.UNIT_SEQ_NUM);
                TRS.add_fieldmsg(out_node, "VALUE_SEQ_NUM", MP_INT, MEDCLOTDAT.VALUE_SEQ_NUM);
                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                DBC_close_medclotdat(i_select);
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        if(COM_check_node_length(in_node) == MP_FALSE)
        {
            TRS.add_int(out_node, "NEXT_COL_SEQ", MEDCLOTDAT.COL_SEQ);
            TRS.add_string(out_node, "NEXT_COL_SET_ID", MEDCLOTDAT.COL_SET_ID, sizeof(MEDCLOTDAT.COL_SET_ID));
            TRS.add_int(out_node, "NEXT_CHAR_SEQ_NUM", MEDCLOTDAT.CHAR_SEQ_NUM);
            TRS.add_int(out_node, "NEXT_UNIT_SEQ_NUM", MEDCLOTDAT.UNIT_SEQ_NUM);
            TRS.add_int(out_node, "NEXT_VALUE_SEQ_NUM", MEDCLOTDAT.VALUE_SEQ_NUM);

            DBC_close_medclotdat(i_select);
            break;
        }

        data_item = TRS.add_node(out_node, "DATA_LIST");

        TRS.add_string(data_item, "LOT_ID", MEDCLOTDAT.LOT_ID, sizeof(MEDCLOTDAT.LOT_ID));
        TRS.add_int(data_item, "HIST_SEQ", MEDCLOTDAT.HIST_SEQ);
        TRS.add_int(data_item, "COL_SEQ", MEDCLOTDAT.COL_SEQ);
        TRS.add_string(data_item, "TRAN_TIME", MEDCLOTDAT.TRAN_TIME, sizeof(MEDCLOTDAT.TRAN_TIME));
        TRS.add_char(data_item, "HIS_DEL_FLAG", MEDCLOTDAT.HIST_DEL_FLAG);
        TRS.add_string(data_item, "FACTORY", MEDCLOTDAT.FACTORY, sizeof(MEDCLOTDAT.FACTORY));
        TRS.add_string(data_item, "MAT_ID", MEDCLOTDAT.MAT_ID, sizeof(MEDCLOTDAT.MAT_ID));
        TRS.add_int(data_item, "MAT_VER", MEDCLOTDAT.MAT_VER /* Add for V42 */);
        TRS.add_string(data_item, "FLOW", MEDCLOTDAT.FLOW, sizeof(MEDCLOTDAT.FLOW));
        TRS.add_string(data_item, "OPER", MEDCLOTDAT.OPER, sizeof(MEDCLOTDAT.OPER));
        TRS.add_string(data_item, "MEAS_RES_ID", MEDCLOTDAT.MEAS_RES_ID, sizeof(MEDCLOTDAT.MEAS_RES_ID));
        TRS.add_string(data_item, "PROC_FLOW", MEDCLOTDAT.PROC_FLOW, sizeof(MEDCLOTDAT.PROC_FLOW));
        TRS.add_string(data_item, "PROC_OPER", MEDCLOTDAT.PROC_OPER, sizeof(MEDCLOTDAT.PROC_OPER));
        TRS.add_string(data_item, "PROC_RES_ID", MEDCLOTDAT.PROC_RES_ID, sizeof(MEDCLOTDAT.PROC_RES_ID));
        TRS.add_string(data_item, "COL_SET_ID", MEDCLOTDAT.COL_SET_ID, sizeof(MEDCLOTDAT.COL_SET_ID));
        TRS.add_int(data_item, "COL_SET_VERSION", MEDCLOTDAT.COL_SET_VERSION);
        TRS.add_int(data_item, "CHAR_SEQ_NUM", MEDCLOTDAT.CHAR_SEQ_NUM);
        TRS.add_string(data_item, "CHAR_ID", MEDCLOTDAT.CHAR_ID, sizeof(MEDCLOTDAT.CHAR_ID));
        TRS.add_int(data_item, "UNIT_SEQ_NUM", MEDCLOTDAT.UNIT_SEQ_NUM);
        TRS.add_string(data_item, "UNIT_ID", MEDCLOTDAT.UNIT_ID, sizeof(MEDCLOTDAT.UNIT_ID));
        TRS.add_int(data_item, "VALUE_SEQ_NUM", MEDCLOTDAT.VALUE_SEQ_NUM);
        TRS.add_char(data_item, "VALUE_TYPE", MEDCLOTDAT.VALUE_TYPE);
        TRS.add_int(data_item, "VALUE_COUNT", MEDCLOTDAT.VALUE_COUNT);
        TRS.add_string(data_item, "VALUE_1", MEDCLOTDAT.VALUE_1, sizeof(MEDCLOTDAT.VALUE_1));
        TRS.add_string(data_item, "VALUE_2", MEDCLOTDAT.VALUE_2, sizeof(MEDCLOTDAT.VALUE_2));
        TRS.add_string(data_item, "VALUE_3", MEDCLOTDAT.VALUE_3, sizeof(MEDCLOTDAT.VALUE_3));
        TRS.add_string(data_item, "VALUE_4", MEDCLOTDAT.VALUE_4, sizeof(MEDCLOTDAT.VALUE_4));
        TRS.add_string(data_item, "VALUE_5", MEDCLOTDAT.VALUE_5, sizeof(MEDCLOTDAT.VALUE_5));
        TRS.add_string(data_item, "VALUE_6", MEDCLOTDAT.VALUE_6, sizeof(MEDCLOTDAT.VALUE_6));
        TRS.add_string(data_item, "VALUE_7", MEDCLOTDAT.VALUE_7, sizeof(MEDCLOTDAT.VALUE_7));
        TRS.add_string(data_item, "VALUE_8", MEDCLOTDAT.VALUE_8, sizeof(MEDCLOTDAT.VALUE_8));
        TRS.add_string(data_item, "VALUE_9", MEDCLOTDAT.VALUE_9, sizeof(MEDCLOTDAT.VALUE_9));
        TRS.add_string(data_item, "VALUE_10", MEDCLOTDAT.VALUE_10, sizeof(MEDCLOTDAT.VALUE_10));
        TRS.add_string(data_item, "VALUE_11", MEDCLOTDAT.VALUE_11, sizeof(MEDCLOTDAT.VALUE_11));
        TRS.add_string(data_item, "VALUE_12", MEDCLOTDAT.VALUE_12, sizeof(MEDCLOTDAT.VALUE_12));
        TRS.add_string(data_item, "VALUE_13", MEDCLOTDAT.VALUE_13, sizeof(MEDCLOTDAT.VALUE_13));
        TRS.add_string(data_item, "VALUE_14", MEDCLOTDAT.VALUE_14, sizeof(MEDCLOTDAT.VALUE_14));
        TRS.add_string(data_item, "VALUE_15", MEDCLOTDAT.VALUE_15, sizeof(MEDCLOTDAT.VALUE_15));
        TRS.add_string(data_item, "VALUE_16", MEDCLOTDAT.VALUE_16, sizeof(MEDCLOTDAT.VALUE_16));
        TRS.add_string(data_item, "VALUE_17", MEDCLOTDAT.VALUE_17, sizeof(MEDCLOTDAT.VALUE_17));
        TRS.add_string(data_item, "VALUE_18", MEDCLOTDAT.VALUE_18, sizeof(MEDCLOTDAT.VALUE_18));
        TRS.add_string(data_item, "VALUE_19", MEDCLOTDAT.VALUE_19, sizeof(MEDCLOTDAT.VALUE_19));
        TRS.add_string(data_item, "VALUE_20", MEDCLOTDAT.VALUE_20, sizeof(MEDCLOTDAT.VALUE_20));
        TRS.add_string(data_item, "VALUE_21", MEDCLOTDAT.VALUE_21, sizeof(MEDCLOTDAT.VALUE_21));
        TRS.add_string(data_item, "VALUE_22", MEDCLOTDAT.VALUE_22, sizeof(MEDCLOTDAT.VALUE_22));
        TRS.add_string(data_item, "VALUE_23", MEDCLOTDAT.VALUE_23, sizeof(MEDCLOTDAT.VALUE_23));
        TRS.add_string(data_item, "VALUE_24", MEDCLOTDAT.VALUE_24, sizeof(MEDCLOTDAT.VALUE_24));
        TRS.add_string(data_item, "VALUE_25", MEDCLOTDAT.VALUE_25, sizeof(MEDCLOTDAT.VALUE_25));
        TRS.add_string(data_item, "SPEC_OUT_MASK", MEDCLOTDAT.SPEC_OUT_MASK, sizeof(MEDCLOTDAT.SPEC_OUT_MASK));

        if(COM_isspace(MEDCLOTDAT.UPDATE_TIME, sizeof(MEDCLOTDAT.UPDATE_TIME)) == MP_FALSE)
        {
            TRS.add_enc_string(data_item, "UPDATE_USER_ID", MEDCLOTDAT.UPDATE_USER_ID, sizeof(MEDCLOTDAT.UPDATE_USER_ID));
            TRS.add_string(data_item, "UPDATE_TIME", MEDCLOTDAT.UPDATE_TIME, sizeof(MEDCLOTDAT.UPDATE_TIME));
        }
        else
        {
            TRS.add_enc_string(data_item, "UPDATE_USER_ID", MEDCLOTDAT.CREATE_USER_ID, sizeof(MEDCLOTDAT.CREATE_USER_ID));
            TRS.add_string(data_item, "UPDATE_TIME", MEDCLOTDAT.CREATE_TIME, sizeof(MEDCLOTDAT.CREATE_TIME));
        }

        DBC_init_medccolchr(&MEDCCOLCHR);
        memcpy(MEDCCOLCHR.FACTORY, MEDCLOTDAT.FACTORY, sizeof(MEDCCOLCHR.FACTORY));
        memcpy(MEDCCOLCHR.COL_SET_ID, MEDCLOTDAT.COL_SET_ID, sizeof(MEDCCOLCHR.COL_SET_ID));
        MEDCCOLCHR.COL_SET_VERSION = MEDCLOTDAT.COL_SET_VERSION;
        memcpy(MEDCCOLCHR.CHAR_ID, MEDCLOTDAT.CHAR_ID, sizeof(MEDCCOLCHR.CHAR_ID));

        DBC_select_medccolchr(1, &MEDCCOLCHR);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND) 
            {
                strcpy(s_msg_code, "EDC-0005");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else 
            {
                strcpy(s_msg_code, "EDC-0004");
                TRS.add_dberrmsg(out_node,DB_error_msg);
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
            TRS.add_fieldmsg(out_node, "MEDCCOLCHR SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MEDCCOLCHR.FACTORY), MEDCCOLCHR.FACTORY);
            TRS.add_fieldmsg(out_node, "COL_SET_ID", MP_STR, sizeof(MEDCCOLCHR.COL_SET_ID), MEDCCOLCHR.COL_SET_ID);
            TRS.add_fieldmsg(out_node, "COL_SET_VERSION", MP_INT, MEDCCOLCHR.COL_SET_VERSION);
            TRS.add_fieldmsg(out_node, "CHAR_ID", MP_STR, sizeof(MEDCCOLCHR.CHAR_ID), MEDCCOLCHR.CHAR_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_medclotdat(i_select);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        DBC_init_medcchrdef(&MEDCCHRDEF);
        memcpy(MEDCCHRDEF.FACTORY, MEDCLOTDAT.FACTORY, sizeof(MEDCCHRDEF.FACTORY));
        memcpy(MEDCCHRDEF.CHAR_ID, MEDCLOTDAT.CHAR_ID, sizeof(MEDCCHRDEF.CHAR_ID));

        DBC_select_medcchrdef(1, &MEDCCHRDEF);

        TRS.add_string(data_item, "CHAR_DESC", MEDCCHRDEF.CHAR_DESC, sizeof(MEDCCHRDEF.CHAR_DESC));
        TRS.add_int(data_item, "UNIT_COUNT", MEDCCOLCHR.UNIT_COUNT);
        TRS.add_char(data_item, "VALUE_TYPE_2", MEDCCHRDEF.VALUE_TYPE);
        TRS.add_int(data_item, "VALUE_COUNT_2",MEDCCOLCHR.VALUE_COUNT);
        TRS.add_char(data_item, "OPT_INPUT_FLAG",MEDCCOLCHR.OPT_INPUT_FLAG);
        TRS.add_char(data_item, "BLANK_REC_SAVE_FLAG",MEDCCOLCHR.BLANK_REC_SAVE_FLAG);
        TRS.add_int(data_item, "DISPLAY_PRECISION", MEDCCOLCHR.DISPLAY_PRECISION);
        TRS.add_char(data_item, "DEF_UNIT_FLAG", MEDCCOLCHR.DEF_UNIT_FLAG);
        TRS.add_char(data_item, "DEF_UNIT_OVR_FLAG",MEDCCOLCHR.DEF_UNIT_OVR_FLAG);
        TRS.add_string(data_item, "DEF_VALUE", MEDCCOLCHR.DEF_VALUE, sizeof(MEDCCOLCHR.DEF_VALUE));
        TRS.add_string(data_item, "UNIT_TBL", MEDCCOLCHR.UNIT_TBL, sizeof(MEDCCOLCHR.UNIT_TBL));
        TRS.add_string(data_item, "VALUE_TBL", MEDCCOLCHR.VALUE_TBL, sizeof(MEDCCOLCHR.VALUE_TBL));
        TRS.add_char(data_item, "SPEC_TYPE", MEDCCOLCHR.SPEC_TYPE);
        TRS.add_string(data_item, "TARGET_VALUE", MEDCCOLCHR.TARGET_VALUE, sizeof(MEDCCOLCHR.TARGET_VALUE));
        TRS.add_string(data_item, "UPPER_SPEC_LIMIT", MEDCCOLCHR.UPPER_SPEC_LIMIT, sizeof(MEDCCOLCHR.UPPER_SPEC_LIMIT));
        TRS.add_string(data_item, "LOWER_SPEC_LIMIT", MEDCCOLCHR.LOWER_SPEC_LIMIT, sizeof(MEDCCOLCHR.LOWER_SPEC_LIMIT));
        TRS.add_string(data_item, "UPPER_WARN_LIMIT", MEDCCOLCHR.UPPER_WARN_LIMIT, sizeof(MEDCCOLCHR.UPPER_WARN_LIMIT));
        TRS.add_string(data_item, "LOWER_WARN_LIMIT", MEDCCOLCHR.LOWER_WARN_LIMIT, sizeof(MEDCCOLCHR.LOWER_WARN_LIMIT));
        TRS.add_char(data_item, "NO_USE_SPM_VALUE_FLAG", MEDCCOLCHR.NO_USE_SPM_VALUE_FLAG);
        TRS.add_char(data_item, "DERIVED_PARAM_FLAG", MEDCCOLCHR.DERIVED_PARAM_FLAG);

        DBC_init_medccolche(&MEDCCOLCHE);
        memcpy(MEDCCOLCHE.FACTORY, MEDCCOLCHR.FACTORY, sizeof(MEDCCOLCHE.FACTORY));
        memcpy(MEDCCOLCHE.COL_SET_ID, MEDCCOLCHR.COL_SET_ID, sizeof(MEDCCOLCHE.COL_SET_ID));
        MEDCCOLCHE.COL_SET_VERSION  = MEDCCOLCHR.COL_SET_VERSION;
        memcpy(MEDCCOLCHE.CHAR_ID, MEDCCOLCHR.CHAR_ID, sizeof(MEDCCOLCHE.CHAR_ID));

        DBC_select_medccolche(1, &MEDCCOLCHE);
        if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "EDC-0004");
            TRS.add_fieldmsg(out_node, "MEDCCOLCHE SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MEDCCOLCHE.FACTORY), MEDCCOLCHE.FACTORY);
            TRS.add_fieldmsg(out_node, "COL_SET_ID", MP_STR, sizeof(MEDCCOLCHE.COL_SET_ID), MEDCCOLCHE.COL_SET_ID);
            TRS.add_fieldmsg(out_node, "COL_SET_VERSION", MP_INT, MEDCCOLCHE.COL_SET_VERSION);
            TRS.add_fieldmsg(out_node, "CHAR_ID", MP_STR, sizeof(MEDCCOLCHE.CHAR_ID), MEDCCOLCHE.CHAR_ID);        
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        TRS.add_char(data_item, "OPT_UNIT_FLAG", MEDCCOLCHE.OPT_UNIT_FLAG);
        TRS.add_int(data_item, "MIN_UNIT_COUNT", MEDCCOLCHE.MIN_UNIT_COUNT);
        TRS.add_int(data_item, "MIN_VALUE_COUNT", MEDCCOLCHE.MIN_VALUE_COUNT);
        TRS.add_char(data_item, "MIN_UNIT_BY_LOT_QTY", MEDCCOLCHE.MIN_UNIT_BY_LOT_QTY);
        TRS.add_char(data_item, "MIN_VALUE_BY_LOT_QTY", MEDCCOLCHE.MIN_VALUE_BY_LOT_QTY);

        
        DBC_init_medccolunt(&MEDCCOLUNT);
        memcpy(MEDCCOLUNT.FACTORY, MEDCLOTDAT.FACTORY, sizeof(MEDCCOLUNT.FACTORY));
        memcpy(MEDCCOLUNT.COL_SET_ID, MEDCLOTDAT.COL_SET_ID, sizeof(MEDCCOLUNT.COL_SET_ID));
        MEDCCOLUNT.COL_SET_VERSION = MEDCLOTDAT.COL_SET_VERSION;
        memcpy(MEDCCOLUNT.CHAR_ID, MEDCLOTDAT.CHAR_ID, sizeof(MEDCCOLUNT.CHAR_ID));
        MEDCCOLUNT.UNIT_SEQ_NUM = MEDCLOTDAT.UNIT_SEQ_NUM;

        DBC_select_medccolunt(1, &MEDCCOLUNT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND) 
            {
                strcpy(s_msg_code, "EDC-0004");
                TRS.add_dberrmsg(out_node,DB_error_msg);
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_fieldmsg(out_node, "MEDCCOLUNT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MEDCCOLUNT.FACTORY), MEDCCOLUNT.FACTORY);
                TRS.add_fieldmsg(out_node, "COL_SET_ID", MP_STR, sizeof(MEDCCOLUNT.COL_SET_ID), MEDCCOLUNT.COL_SET_ID);
                TRS.add_fieldmsg(out_node, "COL_SET_VERSION", MP_INT, MEDCCOLUNT.COL_SET_VERSION);
                TRS.add_fieldmsg(out_node, "CHAR_ID", MP_STR, sizeof(MEDCCOLUNT.CHAR_ID), MEDCCOLUNT.CHAR_ID);
                TRS.add_fieldmsg(out_node, "UNIT_SEQ_NUM", MP_INT, MEDCCOLUNT.UNIT_SEQ_NUM);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                DBC_close_medclotdat(i_select);
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else
        {
            TRS.add_char(data_item, "NULL_FLAG",MEDCCOLUNT.NULL_FLAG);
            TRS.add_string(data_item, "DEF_UNIT_ID", MEDCCOLUNT.DEF_UNIT_ID, sizeof(MEDCCOLUNT.DEF_UNIT_ID));
        }


#ifdef _SPM
        if(MEDCCOLCHR.NO_USE_SPM_VALUE_FLAG != 'Y')
        {
            struct MSPMRELCHR_TAG   MSPMRELCHR;
            struct MSPMCHRDSV_TAG   MSPMCHRDSV;

            DB_init_condition(&DBC_Q_COND);
            memcpy(DBC_Q_COND.KEY_1, MEDCLOTDAT.FACTORY, sizeof(MEDCLOTDAT.FACTORY));
            memcpy(DBC_Q_COND.KEY_2, MEDCLOTDAT.LOT_ID, sizeof(MEDCLOTDAT.LOT_ID));
            DBC_Q_COND.NUM_1 = MEDCLOTDAT.HIST_SEQ;
            memcpy(DBC_Q_COND.KEY_3, MEDCLOTDAT.COL_SET_ID, sizeof(MEDCLOTDAT.COL_SET_ID));
            DBC_Q_COND.NUM_2 = MEDCLOTDAT.COL_SET_VERSION;
            DBC_Q_COND.NUM_3 = MEDCLOTDAT.COL_SEQ;
            memcpy(DBC_Q_COND.KEY_4, MEDCLOTDAT.CHAR_ID, sizeof(MEDCLOTDAT.CHAR_ID));
            DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

            DBC_init_mspmrelchr(&MSPMRELCHR);
            DBC_select_mspmrelchr(3, &MSPMRELCHR);
            if(DB_error_code == DB_SUCCESS)
            {
                TRS.set_char(data_item, "SPEC_TYPE", MSPMRELCHR.SPEC_TYPE);
                if(MEDCCHRDEF.VALUE_TYPE == 'N')
                {
                    if(MSPMRELCHR.SPEC_REF_TYPE == 'M')
                    {
                        TRS.set_string(data_item, "TARGET_VALUE", MSPMRELCHR.TARGET_VALUE, sizeof(MSPMRELCHR.TARGET_VALUE));
                        TRS.set_string(data_item, "UPPER_SPEC_LIMIT", MSPMRELCHR.UPPER_SPEC_LIMIT, sizeof(MSPMRELCHR.UPPER_SPEC_LIMIT));
                        TRS.set_string(data_item, "LOWER_SPEC_LIMIT", MSPMRELCHR.LOWER_SPEC_LIMIT, sizeof(MSPMRELCHR.LOWER_SPEC_LIMIT));
                        TRS.set_string(data_item, "UPPER_WARN_LIMIT", MSPMRELCHR.UPPER_WARN_LIMIT, sizeof(MSPMRELCHR.UPPER_WARN_LIMIT));
                        TRS.set_string(data_item, "LOWER_WARN_LIMIT", MSPMRELCHR.LOWER_WARN_LIMIT, sizeof(MSPMRELCHR.LOWER_WARN_LIMIT));
                    }
                    else
                    {
                        TRS.set_string(data_item, "TARGET_VALUE", MSPMRELCHR.CUST_TARGET_VALUE, sizeof(MSPMRELCHR.CUST_TARGET_VALUE));
                        TRS.set_string(data_item, "UPPER_SPEC_LIMIT", MSPMRELCHR.CUST_UPPER_SPEC_LIMIT, sizeof(MSPMRELCHR.CUST_UPPER_SPEC_LIMIT));
                        TRS.set_string(data_item, "LOWER_SPEC_LIMIT", MSPMRELCHR.CUST_LOWER_SPEC_LIMIT, sizeof(MSPMRELCHR.CUST_LOWER_SPEC_LIMIT));
                        TRS.set_string(data_item, "UPPER_WARN_LIMIT", MSPMRELCHR.CUST_UPPER_WARN_LIMIT, sizeof(MSPMRELCHR.CUST_UPPER_WARN_LIMIT));
                        TRS.set_string(data_item, "LOWER_WARN_LIMIT", MSPMRELCHR.CUST_LOWER_WARN_LIMIT, sizeof(MSPMRELCHR.CUST_LOWER_WARN_LIMIT));
                    }
                }
                else
                {
                    if(MSPMRELCHR.SPEC_TYPE == 'T')
                    {
                        char    s_target_value_temp[10000];
                        char    s_target_value[50];

                        DBC_init_mspmchrdsv(&MSPMCHRDSV);
                        memcpy(MSPMCHRDSV.SPEC_REL_ID, MSPMRELCHR.SPEC_REL_ID, sizeof(MSPMCHRDSV.SPEC_REL_ID));
                        MSPMCHRDSV.SPEC_REL_VER = MSPMRELCHR.SPEC_REL_VER;
                        memcpy(MSPMCHRDSV.CHAR_ID, MSPMRELCHR.CHAR_ID, sizeof(MSPMCHRDSV.CHAR_ID));
                        MSPMCHRDSV.SPEC_REF_TYPE = MSPMRELCHR.SPEC_REF_TYPE;

                        DBC_open_mspmchrdsv(2, &MSPMCHRDSV);
                        if(DB_error_code != DB_SUCCESS)
                        {
                            strcpy(s_msg_code, "SPM-0004");
                            TRS.add_fieldmsg(out_node, "MSPMCHRDSV OPEN", MP_NVST);
                            TRS.add_fieldmsg(out_node, "SPEC_REL_ID", MP_STR, sizeof(MSPMCHRDSV.SPEC_REL_ID), MSPMCHRDSV.SPEC_REL_ID);
                            TRS.add_fieldmsg(out_node, "SPEC_REL_VER", MP_INT, MSPMCHRDSV.SPEC_REL_VER);
                            TRS.add_fieldmsg(out_node, "CHAR_ID", MP_STR, sizeof(MSPMCHRDSV.CHAR_ID), MSPMCHRDSV.CHAR_ID);
                            TRS.add_fieldmsg(out_node, "SPEC_REF_TYPE", MP_CHR, MSPMCHRDSV.SPEC_REF_TYPE);
                            TRS.add_dberrmsg(out_node,DB_error_msg);

                            gs_log_type.type = MP_LOG_ERROR;
                            gs_log_type.e_type = MP_LOG_E_SYSTEM;
                            gs_log_type.category = MP_LOG_CATE_VIEW;

                            DBC_close_medclotdat(i_select);
                            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                            return MP_FALSE;
                        }

                        memset(s_target_value_temp, 0x00, sizeof(s_target_value_temp));

                        while(1)
                        {
                            DBC_fetch_mspmchrdsv(2, &MSPMCHRDSV);
                            if(DB_error_code == DB_NOT_FOUND)
                            {
                                DBC_close_mspmchrdsv(2);
                                break;
                            }
                            else if(DB_error_code != DB_SUCCESS)
                            {
                                strcpy(s_msg_code, "SPM-0004");
                                TRS.add_fieldmsg(out_node, "MSPMCHRDSV FETCH", MP_NVST);
                                TRS.add_fieldmsg(out_node, "SPEC_REL_ID", MP_STR, sizeof(MSPMCHRDSV.SPEC_REL_ID), MSPMCHRDSV.SPEC_REL_ID);
                                TRS.add_fieldmsg(out_node, "SPEC_REL_VER", MP_INT, MSPMCHRDSV.SPEC_REL_VER);
                                TRS.add_fieldmsg(out_node, "CHAR_ID", MP_STR, sizeof(MSPMCHRDSV.CHAR_ID), MSPMCHRDSV.CHAR_ID);
                                TRS.add_fieldmsg(out_node, "SPEC_REF_TYPE", MP_CHR, MSPMCHRDSV.SPEC_REF_TYPE);
                                TRS.add_dberrmsg(out_node,DB_error_msg);

                                gs_log_type.type = MP_LOG_ERROR;
                                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                                gs_log_type.category = MP_LOG_CATE_VIEW;

                                DBC_close_mspmchrdsv(2);
                                DBC_close_medclotdat(i_select);
                                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                                return MP_FALSE;
                            }

                            if(MSPMCHRDSV.LIMIT_TYPE == 'T')
                            {
                                COM_memcpy_add_null(s_target_value, MSPMCHRDSV.VALUE, sizeof(MSPMCHRDSV.VALUE));
                                if(strlen(s_target_value_temp) < 1)
                                {
                                    sprintf(s_target_value_temp, "%s", s_target_value);
                                }
                                else
                                {
                                    sprintf(s_target_value_temp + strlen(s_target_value_temp), ", %s", s_target_value);
                                }
                            }
                        }//end while

                        TRS.set_nstring(data_item, "TARGET_VALUE", s_target_value_temp);
                    }
                    else
                    {
                        if(MSPMRELCHR.SPEC_REF_TYPE == 'M')
                        {
                            TRS.set_string(data_item, "TARGET_VALUE", MSPMRELCHR.TARGET_VALUE, sizeof(MSPMRELCHR.TARGET_VALUE));
                        }
                        else
                        {
                            TRS.set_string(data_item, "TARGET_VALUE", MSPMRELCHR.CUST_TARGET_VALUE, sizeof(MSPMRELCHR.CUST_TARGET_VALUE));
                        }
                    }
                }
            }
        }
#endif //_SPM

    }//end while


    if(COM_proc_user_routine("EDC", "TIV_View_Lot_Data",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}
