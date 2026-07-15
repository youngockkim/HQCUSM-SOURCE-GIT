/*******************************************************************************

    System      : MESplus
    Module      : URAS
    File Name   : URAS_summary_temp_carrier.c
    Description : Summary temp Carrier

    MES Version : 4.0.0

    Function List
        - URAS_SUMMARY_TEMP_CARRIER() 
            + Summary Temp Carrier

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/03/13  James Kwon     Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "URAS_common.h"

int URAS_SUMMARY_TEMP_CARRIER(char *s_msg_code,
                              TRSNode *in_node,
                              TRSNode *out_node);

int URAS_Summary_Temp_Carrier_1(TRSNode *in_node,
                                TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = URAS_SUMMARY_TEMP_CARRIER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "URAS_SUMMARY_TEMP_CARRIER", out_node);

    return i_ret;
}

int URAS_SUMMARY_TEMP_CARRIER(char *s_msg_code,
                              TRSNode *in_node,
                              TRSNode *out_node)
{

    /* 
        Begin - Make Data for Standard Carrier Loader
        This section could be modify for each site
    */
    struct MRASCRRHIS_TAG MRASCRRHIS;
    struct MTMPCRRHIS_TAG MTMPCRRHIS;

    DBC_init_mrascrrhis(&MRASCRRHIS);
    TRS.copy(MRASCRRHIS.CRR_ID, sizeof(MRASCRRHIS.CRR_ID), in_node, "CRR_ID");
    MRASCRRHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
    DBC_select_mrascrrhis(1, &MRASCRRHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0076");
        TRS.add_fieldmsg(out_node, "MRASCRRHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MRASCRRHIS.CRR_ID), MRASCRRHIS.CRR_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MRASCRRHIS.HIST_SEQ);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtmpcrrhis(&MTMPCRRHIS);

    MTMPCRRHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmpcrrhis_scalar(2, &MTMPCRRHIS);

    memcpy(MTMPCRRHIS.CRR_ID, MRASCRRHIS.CRR_ID, sizeof(MTMPCRRHIS.CRR_ID));
    MTMPCRRHIS.HIST_SEQ = MRASCRRHIS.HIST_SEQ;
    memcpy(MTMPCRRHIS.TRAN_TIME, MRASCRRHIS.TRAN_TIME, sizeof(MTMPCRRHIS.TRAN_TIME));
    memcpy(MTMPCRRHIS.SYS_TRAN_TIME, MRASCRRHIS.SYS_TRAN_TIME, sizeof(MTMPCRRHIS.SYS_TRAN_TIME));
    memcpy(MTMPCRRHIS.TRAN_CODE, MRASCRRHIS.TRAN_CODE, sizeof(MTMPCRRHIS.TRAN_CODE));
    memcpy(MTMPCRRHIS.FACTORY, MRASCRRHIS.FACTORY, sizeof(MTMPCRRHIS.FACTORY));
    memcpy(MTMPCRRHIS.CRR_STATUS, MRASCRRHIS.CRR_STATUS, sizeof(MTMPCRRHIS.CRR_STATUS));
    MTMPCRRHIS.CRR_STATUS_FLAG = MRASCRRHIS.CRR_STATUS_FLAG;
    MTMPCRRHIS.USAGE_COUNT = MRASCRRHIS.USAGE_COUNT;
    MTMPCRRHIS.CLEAN_COUNT = MRASCRRHIS.CLEAN_COUNT;
    memcpy(MTMPCRRHIS.RES_ID, MRASCRRHIS.RES_ID, sizeof(MTMPCRRHIS.RES_ID));
    memcpy(MTMPCRRHIS.SUBRES_ID, MRASCRRHIS.SUBRES_ID, sizeof(MTMPCRRHIS.SUBRES_ID));
    memcpy(MTMPCRRHIS.PORT_ID, MRASCRRHIS.PORT_ID, sizeof(MTMPCRRHIS.PORT_ID));
    memcpy(MTMPCRRHIS.LOCATION_1, MRASCRRHIS.LOCATION_1, sizeof(MTMPCRRHIS.LOCATION_1));
    memcpy(MTMPCRRHIS.LOCATION_2, MRASCRRHIS.LOCATION_2, sizeof(MTMPCRRHIS.LOCATION_2));
    memcpy(MTMPCRRHIS.LOCATION_3, MRASCRRHIS.LOCATION_3, sizeof(MTMPCRRHIS.LOCATION_3));
    memcpy(MTMPCRRHIS.LOCATION_4, MRASCRRHIS.LOCATION_4, sizeof(MTMPCRRHIS.LOCATION_4));
    memcpy(MTMPCRRHIS.LOCATION_5, MRASCRRHIS.LOCATION_5, sizeof(MTMPCRRHIS.LOCATION_5));
    MTMPCRRHIS.FINISH_CLEAN_FLAG = MRASCRRHIS.FINISH_CLEAN_FLAG;
    memcpy(MTMPCRRHIS.LAST_CLEAN_TIME, MRASCRRHIS.LAST_CLEAN_TIME, sizeof(MTMPCRRHIS.LAST_CLEAN_TIME));
    memcpy(MTMPCRRHIS.LOT_ID, MRASCRRHIS.LOT_ID, sizeof(MTMPCRRHIS.LOT_ID));
    MTMPCRRHIS.LOT_HIST_SEQ = MRASCRRHIS.LOT_HIST_SEQ;
    MTMPCRRHIS.QTY_1 = MRASCRRHIS.QTY_1;
    MTMPCRRHIS.QTY_2 = MRASCRRHIS.QTY_2;
    MTMPCRRHIS.QTY_3 = MRASCRRHIS.QTY_3;
    memcpy(MTMPCRRHIS.TBL_SLOT, MRASCRRHIS.TBL_SLOT, sizeof(MTMPCRRHIS.TBL_SLOT));
    MTMPCRRHIS.MOVE_FLAG = MRASCRRHIS.MOVE_FLAG;
    MTMPCRRHIS.EMPTY_FLAG = MRASCRRHIS.EMPTY_FLAG;
    memcpy(MTMPCRRHIS.STOCK_IN_TIME, MRASCRRHIS.STOCK_IN_TIME, sizeof(MTMPCRRHIS.STOCK_IN_TIME));
    memcpy(MTMPCRRHIS.TRAN_CMF_1, MRASCRRHIS.TRAN_CMF_1, sizeof(MTMPCRRHIS.TRAN_CMF_1));
    memcpy(MTMPCRRHIS.TRAN_CMF_2, MRASCRRHIS.TRAN_CMF_2, sizeof(MTMPCRRHIS.TRAN_CMF_2));
    memcpy(MTMPCRRHIS.TRAN_CMF_3, MRASCRRHIS.TRAN_CMF_3, sizeof(MTMPCRRHIS.TRAN_CMF_3));
    memcpy(MTMPCRRHIS.TRAN_CMF_4, MRASCRRHIS.TRAN_CMF_4, sizeof(MTMPCRRHIS.TRAN_CMF_4));
    memcpy(MTMPCRRHIS.TRAN_CMF_5, MRASCRRHIS.TRAN_CMF_5, sizeof(MTMPCRRHIS.TRAN_CMF_5));
    memcpy(MTMPCRRHIS.TRAN_CMF_6, MRASCRRHIS.TRAN_CMF_6, sizeof(MTMPCRRHIS.TRAN_CMF_6));
    memcpy(MTMPCRRHIS.TRAN_CMF_7, MRASCRRHIS.TRAN_CMF_7, sizeof(MTMPCRRHIS.TRAN_CMF_7));
    memcpy(MTMPCRRHIS.TRAN_CMF_8, MRASCRRHIS.TRAN_CMF_8, sizeof(MTMPCRRHIS.TRAN_CMF_8));
    memcpy(MTMPCRRHIS.TRAN_CMF_9, MRASCRRHIS.TRAN_CMF_9, sizeof(MTMPCRRHIS.TRAN_CMF_9));
    memcpy(MTMPCRRHIS.TRAN_CMF_10, MRASCRRHIS.TRAN_CMF_10, sizeof(MTMPCRRHIS.TRAN_CMF_10));
    memcpy(MTMPCRRHIS.TRAN_CMF_11, MRASCRRHIS.TRAN_CMF_11, sizeof(MTMPCRRHIS.TRAN_CMF_11));
    memcpy(MTMPCRRHIS.TRAN_CMF_12, MRASCRRHIS.TRAN_CMF_12, sizeof(MTMPCRRHIS.TRAN_CMF_12));
    memcpy(MTMPCRRHIS.TRAN_CMF_13, MRASCRRHIS.TRAN_CMF_13, sizeof(MTMPCRRHIS.TRAN_CMF_13));
    memcpy(MTMPCRRHIS.TRAN_CMF_14, MRASCRRHIS.TRAN_CMF_14, sizeof(MTMPCRRHIS.TRAN_CMF_14));
    memcpy(MTMPCRRHIS.TRAN_CMF_15, MRASCRRHIS.TRAN_CMF_15, sizeof(MTMPCRRHIS.TRAN_CMF_15));
    memcpy(MTMPCRRHIS.TRAN_CMF_16, MRASCRRHIS.TRAN_CMF_16, sizeof(MTMPCRRHIS.TRAN_CMF_16));
    memcpy(MTMPCRRHIS.TRAN_CMF_17, MRASCRRHIS.TRAN_CMF_17, sizeof(MTMPCRRHIS.TRAN_CMF_17));
    memcpy(MTMPCRRHIS.TRAN_CMF_18, MRASCRRHIS.TRAN_CMF_18, sizeof(MTMPCRRHIS.TRAN_CMF_18));
    memcpy(MTMPCRRHIS.TRAN_CMF_19, MRASCRRHIS.TRAN_CMF_19, sizeof(MTMPCRRHIS.TRAN_CMF_19));
    memcpy(MTMPCRRHIS.TRAN_CMF_20, MRASCRRHIS.TRAN_CMF_20, sizeof(MTMPCRRHIS.TRAN_CMF_20));
    memcpy(MTMPCRRHIS.TRAN_USER_ID, MRASCRRHIS.TRAN_USER_ID, sizeof(MTMPCRRHIS.TRAN_USER_ID));
    memcpy(MTMPCRRHIS.TRAN_COMMENT, MRASCRRHIS.TRAN_COMMENT, sizeof(MTMPCRRHIS.TRAN_COMMENT));

    memcpy(MTMPCRRHIS.CRR_CMF_1, MRASCRRHIS.CRR_CMF_1, sizeof(MTMPCRRHIS.CRR_CMF_1));
    memcpy(MTMPCRRHIS.CRR_CMF_2, MRASCRRHIS.CRR_CMF_2, sizeof(MTMPCRRHIS.CRR_CMF_2));
    memcpy(MTMPCRRHIS.CRR_CMF_3, MRASCRRHIS.CRR_CMF_3, sizeof(MTMPCRRHIS.CRR_CMF_3));
    memcpy(MTMPCRRHIS.CRR_CMF_4, MRASCRRHIS.CRR_CMF_4, sizeof(MTMPCRRHIS.CRR_CMF_4));
    memcpy(MTMPCRRHIS.CRR_CMF_5, MRASCRRHIS.CRR_CMF_5, sizeof(MTMPCRRHIS.CRR_CMF_5));
    memcpy(MTMPCRRHIS.CRR_CMF_6, MRASCRRHIS.CRR_CMF_6, sizeof(MTMPCRRHIS.CRR_CMF_6));
    memcpy(MTMPCRRHIS.CRR_CMF_7, MRASCRRHIS.CRR_CMF_7, sizeof(MTMPCRRHIS.CRR_CMF_7));
    memcpy(MTMPCRRHIS.CRR_CMF_8, MRASCRRHIS.CRR_CMF_8, sizeof(MTMPCRRHIS.CRR_CMF_8));
    memcpy(MTMPCRRHIS.CRR_CMF_9, MRASCRRHIS.CRR_CMF_9, sizeof(MTMPCRRHIS.CRR_CMF_9));
    memcpy(MTMPCRRHIS.CRR_CMF_10, MRASCRRHIS.CRR_CMF_10, sizeof(MTMPCRRHIS.CRR_CMF_10));
    memcpy(MTMPCRRHIS.CRR_CMF_11, MRASCRRHIS.CRR_CMF_11, sizeof(MTMPCRRHIS.CRR_CMF_11));
    memcpy(MTMPCRRHIS.CRR_CMF_12, MRASCRRHIS.CRR_CMF_12, sizeof(MTMPCRRHIS.CRR_CMF_12));
    memcpy(MTMPCRRHIS.CRR_CMF_13, MRASCRRHIS.CRR_CMF_13, sizeof(MTMPCRRHIS.CRR_CMF_13));
    memcpy(MTMPCRRHIS.CRR_CMF_14, MRASCRRHIS.CRR_CMF_14, sizeof(MTMPCRRHIS.CRR_CMF_14));
    memcpy(MTMPCRRHIS.CRR_CMF_15, MRASCRRHIS.CRR_CMF_15, sizeof(MTMPCRRHIS.CRR_CMF_15));
    memcpy(MTMPCRRHIS.CRR_CMF_16, MRASCRRHIS.CRR_CMF_16, sizeof(MTMPCRRHIS.CRR_CMF_16));
    memcpy(MTMPCRRHIS.CRR_CMF_17, MRASCRRHIS.CRR_CMF_17, sizeof(MTMPCRRHIS.CRR_CMF_17));
    memcpy(MTMPCRRHIS.CRR_CMF_18, MRASCRRHIS.CRR_CMF_18, sizeof(MTMPCRRHIS.CRR_CMF_18));
    memcpy(MTMPCRRHIS.CRR_CMF_19, MRASCRRHIS.CRR_CMF_19, sizeof(MTMPCRRHIS.CRR_CMF_19));
    memcpy(MTMPCRRHIS.CRR_CMF_20, MRASCRRHIS.CRR_CMF_20, sizeof(MTMPCRRHIS.CRR_CMF_20));
    MTMPCRRHIS.REUSE_COUNT = MRASCRRHIS.REUSE_COUNT;

    //DBC_insert_mtmpcrrhis(&MTMPCRRHIS);
    if(DB_error_code != DB_SUCCESS)
    {
      /*  strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "MTMPCRRHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTMPCRRHIS.FACTORY), MTMPCRRHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTMPCRRHIS.RES_ID), MTMPCRRHIS.RES_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;*/
    }

    /* 
        End - Make Data for Standard Carrier Loader
        This section could be modify for each site
    */

    return MP_TRUE;
}
