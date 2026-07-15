/*******************************************************************************

    System      : MESplus
    Module      : URAS
    File Name   : URAS_summary_temp_port.c
    Description : Summary temp Carrier

    MES Version : 4.0.0

    Function List
        - URAS_SUMMARY_TEMP_PORT() 
            + Summary Temp Port

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2017/08/09  IC.Bae         Create

    Copyright(C) 1998-2017 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "URAS_common.h"

int URAS_SUMMARY_TEMP_PORT(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node);

int URAS_Summary_Temp_Port_1(TRSNode *in_node,
                                TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = URAS_SUMMARY_TEMP_PORT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "URAS_SUMMARY_TEMP_PORT", out_node);

    return i_ret;
}


int URAS_SUMMARY_TEMP_PORT(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node)
{

    /* 
        Begin - Make Data for Standard Port Loader
        This section could be modify for each site
    */
    struct MRASPOTHIS_TAG MRASPOTHIS;
    struct MTMPPOTHIS_TAG MTMPPOTHIS;

    DBC_init_mraspothis(&MRASPOTHIS);
    TRS.copy(MRASPOTHIS.FACTORY, sizeof(MRASPOTHIS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRASPOTHIS.RES_ID, sizeof(MRASPOTHIS.RES_ID), in_node, "RES_ID");
    TRS.copy(MRASPOTHIS.SUBRES_ID, sizeof(MRASPOTHIS.SUBRES_ID), in_node, "SUBRES_ID");
    TRS.copy(MRASPOTHIS.PORT_ID, sizeof(MRASPOTHIS.PORT_ID), in_node, "PORT_ID");
    MRASPOTHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");

    DBC_select_mraspothis(1, &MRASPOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0319");
        TRS.add_fieldmsg(out_node, "MRASPOTHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASPOTHIS.RES_ID), MRASPOTHIS.RES_ID);
        TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRASPOTHIS.SUBRES_ID), MRASPOTHIS.SUBRES_ID);
        TRS.add_fieldmsg(out_node, "PORT_ID", MP_STR, sizeof(MRASPOTHIS.PORT_ID), MRASPOTHIS.PORT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MRASPOTHIS.HIST_SEQ);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtmppothis(&MTMPPOTHIS);
    MTMPPOTHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmppothis_scalar(2, &MTMPPOTHIS);

    memcpy(MTMPPOTHIS.FACTORY,  MRASPOTHIS.FACTORY,  sizeof(MRASPOTHIS.FACTORY ));
    memcpy(MTMPPOTHIS.RES_ID, MRASPOTHIS.RES_ID, sizeof(MRASPOTHIS.RES_ID));
    memcpy(MTMPPOTHIS.SUBRES_ID, MRASPOTHIS.SUBRES_ID, sizeof(MRASPOTHIS.SUBRES_ID));
    memcpy(MTMPPOTHIS.PORT_ID, MRASPOTHIS.PORT_ID, sizeof(MRASPOTHIS.PORT_ID));
    MTMPPOTHIS.HIST_SEQ = MRASPOTHIS.HIST_SEQ;
    memcpy(MTMPPOTHIS.TRAN_CODE, MRASPOTHIS.TRAN_CODE, sizeof(MRASPOTHIS.TRAN_CODE));
    memcpy(MTMPPOTHIS.TRAN_TIME, MRASPOTHIS.TRAN_TIME, sizeof(MRASPOTHIS.TRAN_TIME));
    memcpy(MTMPPOTHIS.SYS_TRAN_TIME, MRASPOTHIS.SYS_TRAN_TIME, sizeof(MRASPOTHIS.SYS_TRAN_TIME));
    memcpy(MTMPPOTHIS.TRS_STATE, MRASPOTHIS.TRS_STATE, sizeof(MRASPOTHIS.TRS_STATE));
    MTMPPOTHIS.ASC_STATE = MRASPOTHIS.ASC_STATE;
    memcpy(MTMPPOTHIS.ASC_OBJ_ID, MRASPOTHIS.ASC_OBJ_ID, sizeof(MRASPOTHIS.ASC_OBJ_ID));
    MTMPPOTHIS.ACC_STATE = MRASPOTHIS.ACC_STATE;
    MTMPPOTHIS.RSV_STATE = MRASPOTHIS.RSV_STATE;
    memcpy(MTMPPOTHIS.RSV_OBJ_ID, MRASPOTHIS.RSV_OBJ_ID, sizeof(MRASPOTHIS.RSV_OBJ_ID));
    memcpy(MTMPPOTHIS.LOT_ID, MRASPOTHIS.LOT_ID, sizeof(MRASPOTHIS.LOT_ID));
    memcpy(MTMPPOTHIS.CRR_ID, MRASPOTHIS.CRR_ID, sizeof(MRASPOTHIS.CRR_ID));
    MTMPPOTHIS.BCR_STATUS_FLAG = MRASPOTHIS.BCR_STATUS_FLAG;
    memcpy(MTMPPOTHIS.TRAN_CMF_1, MRASPOTHIS.TRAN_CMF_1, sizeof(MRASPOTHIS.TRAN_CMF_1));
    memcpy(MTMPPOTHIS.TRAN_CMF_2, MRASPOTHIS.TRAN_CMF_2, sizeof(MRASPOTHIS.TRAN_CMF_2));
    memcpy(MTMPPOTHIS.TRAN_CMF_3, MRASPOTHIS.TRAN_CMF_3, sizeof(MRASPOTHIS.TRAN_CMF_3));
    memcpy(MTMPPOTHIS.TRAN_CMF_4, MRASPOTHIS.TRAN_CMF_4, sizeof(MRASPOTHIS.TRAN_CMF_4));
    memcpy(MTMPPOTHIS.TRAN_CMF_5, MRASPOTHIS.TRAN_CMF_5, sizeof(MRASPOTHIS.TRAN_CMF_5));
    memcpy(MTMPPOTHIS.TRAN_CMF_6, MRASPOTHIS.TRAN_CMF_6, sizeof(MRASPOTHIS.TRAN_CMF_6));
    memcpy(MTMPPOTHIS.TRAN_CMF_7, MRASPOTHIS.TRAN_CMF_7, sizeof(MRASPOTHIS.TRAN_CMF_7));
    memcpy(MTMPPOTHIS.TRAN_CMF_8, MRASPOTHIS.TRAN_CMF_8, sizeof(MRASPOTHIS.TRAN_CMF_8));
    memcpy(MTMPPOTHIS.TRAN_CMF_9, MRASPOTHIS.TRAN_CMF_9, sizeof(MRASPOTHIS.TRAN_CMF_9));
    memcpy(MTMPPOTHIS.TRAN_CMF_10, MRASPOTHIS.TRAN_CMF_10, sizeof(MRASPOTHIS.TRAN_CMF_10));
    memcpy(MTMPPOTHIS.TRAN_CMF_11, MRASPOTHIS.TRAN_CMF_11, sizeof(MRASPOTHIS.TRAN_CMF_11));
    memcpy(MTMPPOTHIS.TRAN_CMF_12, MRASPOTHIS.TRAN_CMF_12, sizeof(MRASPOTHIS.TRAN_CMF_12));
    memcpy(MTMPPOTHIS.TRAN_CMF_13, MRASPOTHIS.TRAN_CMF_13, sizeof(MRASPOTHIS.TRAN_CMF_13));
    memcpy(MTMPPOTHIS.TRAN_CMF_14, MRASPOTHIS.TRAN_CMF_14, sizeof(MRASPOTHIS.TRAN_CMF_14));
    memcpy(MTMPPOTHIS.TRAN_CMF_15, MRASPOTHIS.TRAN_CMF_15, sizeof(MRASPOTHIS.TRAN_CMF_15));
    memcpy(MTMPPOTHIS.TRAN_CMF_16, MRASPOTHIS.TRAN_CMF_16, sizeof(MRASPOTHIS.TRAN_CMF_16));
    memcpy(MTMPPOTHIS.TRAN_CMF_17, MRASPOTHIS.TRAN_CMF_17, sizeof(MRASPOTHIS.TRAN_CMF_17));
    memcpy(MTMPPOTHIS.TRAN_CMF_18, MRASPOTHIS.TRAN_CMF_18, sizeof(MRASPOTHIS.TRAN_CMF_18));
    memcpy(MTMPPOTHIS.TRAN_CMF_19, MRASPOTHIS.TRAN_CMF_19, sizeof(MRASPOTHIS.TRAN_CMF_19));
    memcpy(MTMPPOTHIS.TRAN_CMF_20, MRASPOTHIS.TRAN_CMF_20, sizeof(MRASPOTHIS.TRAN_CMF_20));
    memcpy(MTMPPOTHIS.TRAN_USER_ID, MRASPOTHIS.TRAN_USER_ID, sizeof(MRASPOTHIS.TRAN_USER_ID));
    memcpy(MTMPPOTHIS.TRAN_COMMENT, MRASPOTHIS.TRAN_COMMENT, sizeof(MRASPOTHIS.TRAN_COMMENT));

    DBC_insert_mtmppothis(&MTMPPOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "MTMPPOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTMPPOTHIS.RES_ID), MTMPPOTHIS.RES_ID);
        TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MTMPPOTHIS.SUBRES_ID), MTMPPOTHIS.SUBRES_ID);
        TRS.add_fieldmsg(out_node, "PORT_ID", MP_STR, sizeof(MTMPPOTHIS.PORT_ID), MTMPPOTHIS.PORT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTMPPOTHIS.HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* 
        End - Make Data for Standard Port Loader
        This section could be modify for each site
    */

    return MP_TRUE;
}

