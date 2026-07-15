/*******************************************************************************

    System      : MESplus
    Module      : User Routine for RAS
    File Name   : URAS_Summary_Temp_Res.c
    Description : User Routine for URAS_Summary_Temp_Res

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/11/10  Miracom        Create
    2     2009/03/13  James Kwon     Modify

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "URAS_common.h"

int URAS_SUMMARY_TEMP_RES(char *s_msg_code,
                          TRSNode *in_node,
                          TRSNode *out_node);

int URAS_Summary_Temp_Res_1(TRSNode *in_node,
                            TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = URAS_SUMMARY_TEMP_RES(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "URAS_SUMMARY_TEMP_RES", out_node);

    return i_ret;
}

int URAS_SUMMARY_TEMP_RES(char *s_msg_code,
                          TRSNode *in_node,
                          TRSNode *out_node)
{

    /* 
        Begin - Make Data for Standard RAS Loader
        This section could be modify for each site
    */
    struct MRASRESHIS_TAG MRASRESHIS;
    struct MRASSRSHIS_TAG MRASSRSHIS;
    struct MTMPRESHIS_TAG MTMPRESHIS;

    if(TRS.get_char(in_node, "SUBRES_FLAG") != 'S')
    {
        DBC_init_mrasreshis(&MRASRESHIS);
        TRS.copy(MRASRESHIS.FACTORY, sizeof(MRASRESHIS.FACTORY), in_node, "FACTORY");
        TRS.copy(MRASRESHIS.RES_ID, sizeof(MRASRESHIS.RES_ID), in_node, "RES_ID");
        MRASRESHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
        DBC_select_mrasreshis(1, &MRASRESHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0076");
            TRS.add_fieldmsg(out_node, "MRASRESHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESHIS.FACTORY), MRASRESHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESHIS.RES_ID), MRASRESHIS.RES_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MRASRESHIS.HIST_SEQ);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        DBC_init_mtmpreshis(&MTMPRESHIS);

        MTMPRESHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmpreshis_scalar(2, &MTMPRESHIS);

        memcpy(MTMPRESHIS.FACTORY, MRASRESHIS.FACTORY, sizeof(MTMPRESHIS.FACTORY));
        MTMPRESHIS.MAIN_SUB_FLAG = 'M';
        memcpy(MTMPRESHIS.RES_ID, MRASRESHIS.RES_ID, sizeof(MTMPRESHIS.RES_ID));
        MTMPRESHIS.HIST_SEQ = MRASRESHIS.HIST_SEQ;
        memcpy(MTMPRESHIS.EVENT_ID, MRASRESHIS.EVENT_ID, sizeof(MTMPRESHIS.EVENT_ID));
        memcpy(MTMPRESHIS.TRAN_TIME, MRASRESHIS.TRAN_TIME, sizeof(MTMPRESHIS.TRAN_TIME));
        memcpy(MTMPRESHIS.SYS_TRAN_TIME, MRASRESHIS.SYS_TRAN_TIME, sizeof(MTMPRESHIS.SYS_TRAN_TIME));
        memcpy(MTMPRESHIS.OLD_EVENT_ID, MRASRESHIS.OLD_EVENT_ID, sizeof(MTMPRESHIS.OLD_EVENT_ID));
        MTMPRESHIS.OLD_HIST_SEQ = MRASRESHIS.OLD_HIST_SEQ;
        memcpy(MTMPRESHIS.OLD_TRAN_TIME, MRASRESHIS.OLD_TRAN_TIME, sizeof(MTMPRESHIS.OLD_TRAN_TIME));
        memcpy(MTMPRESHIS.OLD_SYS_TRAN_TIME, MRASRESHIS.OLD_SYS_TRAN_TIME, sizeof(MTMPRESHIS.OLD_SYS_TRAN_TIME));
        MTMPRESHIS.OLD_UP_DOWN_FLAG = MRASRESHIS.OLD_UP_DOWN_FLAG;
        memcpy(MTMPRESHIS.OLD_PRI_STS, MRASRESHIS.OLD_PRI_STS, sizeof(MTMPRESHIS.OLD_PRI_STS));
        memcpy(MTMPRESHIS.OLD_STS_1, MRASRESHIS.OLD_STS_1, sizeof(MTMPRESHIS.OLD_STS_1));
        memcpy(MTMPRESHIS.OLD_STS_2, MRASRESHIS.OLD_STS_2, sizeof(MTMPRESHIS.OLD_STS_2));
        memcpy(MTMPRESHIS.OLD_STS_3, MRASRESHIS.OLD_STS_3, sizeof(MTMPRESHIS.OLD_STS_3));
        memcpy(MTMPRESHIS.OLD_STS_4, MRASRESHIS.OLD_STS_4, sizeof(MTMPRESHIS.OLD_STS_4));
        memcpy(MTMPRESHIS.OLD_STS_5, MRASRESHIS.OLD_STS_5, sizeof(MTMPRESHIS.OLD_STS_5));
        memcpy(MTMPRESHIS.OLD_STS_6, MRASRESHIS.OLD_STS_6, sizeof(MTMPRESHIS.OLD_STS_6));
        memcpy(MTMPRESHIS.OLD_STS_7, MRASRESHIS.OLD_STS_7, sizeof(MTMPRESHIS.OLD_STS_7));
        memcpy(MTMPRESHIS.OLD_STS_8, MRASRESHIS.OLD_STS_8, sizeof(MTMPRESHIS.OLD_STS_8));
        memcpy(MTMPRESHIS.OLD_STS_9, MRASRESHIS.OLD_STS_9, sizeof(MTMPRESHIS.OLD_STS_9));
        memcpy(MTMPRESHIS.OLD_STS_10, MRASRESHIS.OLD_STS_10, sizeof(MTMPRESHIS.OLD_STS_10));
        MTMPRESHIS.NEW_UP_DOWN_FLAG = MRASRESHIS.NEW_UP_DOWN_FLAG;
        memcpy(MTMPRESHIS.NEW_PRI_STS, MRASRESHIS.NEW_PRI_STS, sizeof(MTMPRESHIS.NEW_PRI_STS));
        memcpy(MTMPRESHIS.NEW_STS_1, MRASRESHIS.NEW_STS_1, sizeof(MTMPRESHIS.NEW_STS_1));
        memcpy(MTMPRESHIS.NEW_STS_2, MRASRESHIS.NEW_STS_2, sizeof(MTMPRESHIS.NEW_STS_2));
        memcpy(MTMPRESHIS.NEW_STS_3, MRASRESHIS.NEW_STS_3, sizeof(MTMPRESHIS.NEW_STS_3));
        memcpy(MTMPRESHIS.NEW_STS_4, MRASRESHIS.NEW_STS_4, sizeof(MTMPRESHIS.NEW_STS_4));
        memcpy(MTMPRESHIS.NEW_STS_5, MRASRESHIS.NEW_STS_5, sizeof(MTMPRESHIS.NEW_STS_5));
        memcpy(MTMPRESHIS.NEW_STS_6, MRASRESHIS.NEW_STS_6, sizeof(MTMPRESHIS.NEW_STS_6));
        memcpy(MTMPRESHIS.NEW_STS_7, MRASRESHIS.NEW_STS_7, sizeof(MTMPRESHIS.NEW_STS_7));
        memcpy(MTMPRESHIS.NEW_STS_8, MRASRESHIS.NEW_STS_8, sizeof(MTMPRESHIS.NEW_STS_8));
        memcpy(MTMPRESHIS.NEW_STS_9, MRASRESHIS.NEW_STS_9, sizeof(MTMPRESHIS.NEW_STS_9));
        memcpy(MTMPRESHIS.NEW_STS_10, MRASRESHIS.NEW_STS_10, sizeof(MTMPRESHIS.NEW_STS_10));
        memcpy(MTMPRESHIS.LOT_ID, MRASRESHIS.LOT_ID, sizeof(MTMPRESHIS.LOT_ID));
        memcpy(MTMPRESHIS.SUBLOT_ID, MRASRESHIS.SUBLOT_ID, sizeof(MTMPRESHIS.SUBLOT_ID));
        memcpy(MTMPRESHIS.CRR_ID, MRASRESHIS.CRR_ID, sizeof(MTMPRESHIS.CRR_ID));
        memcpy(MTMPRESHIS.RES_CTRL_MODE, MRASRESHIS.RES_CTRL_MODE, sizeof(MTMPRESHIS.RES_CTRL_MODE));
        memcpy(MTMPRESHIS.RES_PROC_MODE, MRASRESHIS.RES_PROC_MODE, sizeof(MTMPRESHIS.RES_PROC_MODE));
        MTMPRESHIS.LOT_EXIST_FLAG = MRASRESHIS.LOT_EXIST_FLAG;
        memcpy(MTMPRESHIS.COL_SET_ID, MRASRESHIS.COL_SET_ID, sizeof(MTMPRESHIS.COL_SET_ID));
        MTMPRESHIS.COL_SET_VERSION = MRASRESHIS.COL_SET_VERSION;
        memcpy(MTMPRESHIS.TRAN_CMF_1, MRASRESHIS.TRAN_CMF_1, sizeof(MTMPRESHIS.TRAN_CMF_1));
        memcpy(MTMPRESHIS.TRAN_CMF_2, MRASRESHIS.TRAN_CMF_2, sizeof(MTMPRESHIS.TRAN_CMF_2));
        memcpy(MTMPRESHIS.TRAN_CMF_3, MRASRESHIS.TRAN_CMF_3, sizeof(MTMPRESHIS.TRAN_CMF_3));
        memcpy(MTMPRESHIS.TRAN_CMF_4, MRASRESHIS.TRAN_CMF_4, sizeof(MTMPRESHIS.TRAN_CMF_4));
        memcpy(MTMPRESHIS.TRAN_CMF_5, MRASRESHIS.TRAN_CMF_5, sizeof(MTMPRESHIS.TRAN_CMF_5));
        memcpy(MTMPRESHIS.TRAN_CMF_6, MRASRESHIS.TRAN_CMF_6, sizeof(MTMPRESHIS.TRAN_CMF_6));
        memcpy(MTMPRESHIS.TRAN_CMF_7, MRASRESHIS.TRAN_CMF_7, sizeof(MTMPRESHIS.TRAN_CMF_7));
        memcpy(MTMPRESHIS.TRAN_CMF_8, MRASRESHIS.TRAN_CMF_8, sizeof(MTMPRESHIS.TRAN_CMF_8));
        memcpy(MTMPRESHIS.TRAN_CMF_9, MRASRESHIS.TRAN_CMF_9, sizeof(MTMPRESHIS.TRAN_CMF_9));
        memcpy(MTMPRESHIS.TRAN_CMF_10, MRASRESHIS.TRAN_CMF_10, sizeof(MTMPRESHIS.TRAN_CMF_10));
        memcpy(MTMPRESHIS.TRAN_CMF_11, MRASRESHIS.TRAN_CMF_11, sizeof(MTMPRESHIS.TRAN_CMF_11));
        memcpy(MTMPRESHIS.TRAN_CMF_12, MRASRESHIS.TRAN_CMF_12, sizeof(MTMPRESHIS.TRAN_CMF_12));
        memcpy(MTMPRESHIS.TRAN_CMF_13, MRASRESHIS.TRAN_CMF_13, sizeof(MTMPRESHIS.TRAN_CMF_13));
        memcpy(MTMPRESHIS.TRAN_CMF_14, MRASRESHIS.TRAN_CMF_14, sizeof(MTMPRESHIS.TRAN_CMF_14));
        memcpy(MTMPRESHIS.TRAN_CMF_15, MRASRESHIS.TRAN_CMF_15, sizeof(MTMPRESHIS.TRAN_CMF_15));
        memcpy(MTMPRESHIS.TRAN_CMF_16, MRASRESHIS.TRAN_CMF_16, sizeof(MTMPRESHIS.TRAN_CMF_16));
        memcpy(MTMPRESHIS.TRAN_CMF_17, MRASRESHIS.TRAN_CMF_17, sizeof(MTMPRESHIS.TRAN_CMF_17));
        memcpy(MTMPRESHIS.TRAN_CMF_18, MRASRESHIS.TRAN_CMF_18, sizeof(MTMPRESHIS.TRAN_CMF_18));
        memcpy(MTMPRESHIS.TRAN_CMF_19, MRASRESHIS.TRAN_CMF_19, sizeof(MTMPRESHIS.TRAN_CMF_19));
        memcpy(MTMPRESHIS.TRAN_CMF_20, MRASRESHIS.TRAN_CMF_20, sizeof(MTMPRESHIS.TRAN_CMF_20));
        memcpy(MTMPRESHIS.TRAN_USER_ID, MRASRESHIS.TRAN_USER_ID, sizeof(MTMPRESHIS.TRAN_USER_ID));
        memcpy(MTMPRESHIS.TRAN_COMMENT, MRASRESHIS.TRAN_COMMENT, sizeof(MTMPRESHIS.TRAN_COMMENT));
        memcpy(MTMPRESHIS.LAST_DOWN_TIME, MRASRESHIS.LAST_DOWN_TIME, sizeof(MTMPRESHIS.LAST_DOWN_TIME));
        MTMPRESHIS.LAST_DOWN_HIST_SEQ = MRASRESHIS.LAST_DOWN_HIST_SEQ;
        MTMPRESHIS.HIST_START_SEQ = MRASRESHIS.HIST_START_SEQ;
        MTMPRESHIS.HIST_DEL_FLAG = MRASRESHIS.HIST_DEL_FLAG;
        memcpy(MTMPRESHIS.HIST_DEL_TIME, MRASRESHIS.HIST_DEL_TIME, sizeof(MTMPRESHIS.HIST_DEL_TIME));
        memcpy(MTMPRESHIS.HIST_DEL_USER_ID, MRASRESHIS.HIST_DEL_USER_ID, sizeof(MTMPRESHIS.HIST_DEL_USER_ID));
        memcpy(MTMPRESHIS.HIST_DEL_COMMENT, MRASRESHIS.HIST_DEL_COMMENT, sizeof(MTMPRESHIS.HIST_DEL_COMMENT));

        if(TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_ADD, strlen(MP_USUM_TRAN_CODE_EDC_ADD)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_DEL, strlen(MP_USUM_TRAN_CODE_EDC_DEL)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_CHG, strlen(MP_USUM_TRAN_CODE_EDC_CHG)) == 0) 
        {
            memset(MTMPRESHIS.EVENT_ID, ' ', sizeof(MTMPRESHIS.EVENT_ID));
            memset(MTMPRESHIS.TRAN_CMF_1, ' ', sizeof(MTMPRESHIS.TRAN_CMF_1) * 20);

            TRS.copy(MTMPRESHIS.EVENT_ID, sizeof(MTMPRESHIS.EVENT_ID), in_node, "TRAN_CODE");
            TRS.copy(MTMPRESHIS.TRAN_CMF_1, sizeof(MTMPRESHIS.TRAN_CMF_1), in_node, "COL_SET_ID");
            COM_itoa_left(MTMPRESHIS.TRAN_CMF_2, TRS.get_int(in_node, "COL_SEQ"), sizeof(MTMPRESHIS.TRAN_CMF_2));
        }

        DBC_insert_mtmpreshis(&MTMPRESHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "MTMPRESHIS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTMPRESHIS.FACTORY), MTMPRESHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTMPRESHIS.RES_ID), MTMPRESHIS.RES_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    } else  /* Sub Rasource History */
    {
        DBC_init_mrassrshis(&MRASSRSHIS);
        TRS.copy(MRASSRSHIS.FACTORY, sizeof(MRASSRSHIS.FACTORY), in_node, "FACTORY");
        TRS.copy(MRASSRSHIS.RES_ID, sizeof(MRASSRSHIS.RES_ID), in_node, "RES_ID");
        TRS.copy(MRASSRSHIS.SUBRES_ID, sizeof(MRASSRSHIS.SUBRES_ID), in_node, "SUBRES_ID");
        MRASSRSHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
        DBC_select_mrassrshis(1, &MRASSRSHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0076");
            TRS.add_fieldmsg(out_node, "MRASSRSHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASSRSHIS.FACTORY), MRASSRSHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASSRSHIS.RES_ID), MRASSRSHIS.RES_ID);
            TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRASSRSHIS.SUBRES_ID), MRASSRSHIS.SUBRES_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MRASSRSHIS.HIST_SEQ);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        DBC_init_mtmpreshis(&MTMPRESHIS);

        MTMPRESHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmpreshis_scalar(2, &MTMPRESHIS);
        memcpy(MTMPRESHIS.FACTORY, MRASSRSHIS.FACTORY, sizeof(MRASSRSHIS.FACTORY));
        MTMPRESHIS.MAIN_SUB_FLAG = 'S';
        memcpy(MTMPRESHIS.RES_ID, MRASSRSHIS.RES_ID, sizeof(MRASSRSHIS.RES_ID));
        memcpy(MTMPRESHIS.SUBRES_ID, MRASSRSHIS.SUBRES_ID, sizeof(MRASSRSHIS.SUBRES_ID));
        MTMPRESHIS.HIST_SEQ = MRASSRSHIS.HIST_SEQ;
        memcpy(MTMPRESHIS.EVENT_ID, MRASSRSHIS.EVENT_ID, sizeof(MTMPRESHIS.EVENT_ID));
        memcpy(MTMPRESHIS.TRAN_TIME, MRASSRSHIS.TRAN_TIME, sizeof(MTMPRESHIS.TRAN_TIME));
        memcpy(MTMPRESHIS.PARENTS_SUBRES_ID, MRASSRSHIS.PARENTS_SUBRES_ID, sizeof(MTMPRESHIS.PARENTS_SUBRES_ID));
        MTMPRESHIS.MAIN_HIST_SEQ = MRASSRSHIS.MAIN_HIST_SEQ;
        memcpy(MTMPRESHIS.SYS_TRAN_TIME, MRASSRSHIS.SYS_TRAN_TIME, sizeof(MTMPRESHIS.SYS_TRAN_TIME));
        memcpy(MTMPRESHIS.OLD_EVENT_ID, MRASSRSHIS.OLD_EVENT_ID, sizeof(MTMPRESHIS.OLD_EVENT_ID));
        MTMPRESHIS.OLD_HIST_SEQ = MRASSRSHIS.OLD_HIST_SEQ;
        memcpy(MTMPRESHIS.OLD_TRAN_TIME, MRASSRSHIS.OLD_TRAN_TIME, sizeof(MTMPRESHIS.OLD_TRAN_TIME));
        memcpy(MTMPRESHIS.OLD_SYS_TRAN_TIME, MRASSRSHIS.OLD_SYS_TRAN_TIME, sizeof(MTMPRESHIS.OLD_SYS_TRAN_TIME));
        MTMPRESHIS.OLD_UP_DOWN_FLAG = MRASSRSHIS.OLD_UP_DOWN_FLAG;
        memcpy(MTMPRESHIS.OLD_PRI_STS, MRASSRSHIS.OLD_PRI_STS, sizeof(MTMPRESHIS.OLD_PRI_STS));
        memcpy(MTMPRESHIS.OLD_STS_1, MRASSRSHIS.OLD_STS_1, sizeof(MTMPRESHIS.OLD_STS_1));
        memcpy(MTMPRESHIS.OLD_STS_2, MRASSRSHIS.OLD_STS_2, sizeof(MTMPRESHIS.OLD_STS_2));
        memcpy(MTMPRESHIS.OLD_STS_3, MRASSRSHIS.OLD_STS_3, sizeof(MTMPRESHIS.OLD_STS_3));
        memcpy(MTMPRESHIS.OLD_STS_4, MRASSRSHIS.OLD_STS_4, sizeof(MTMPRESHIS.OLD_STS_4));
        memcpy(MTMPRESHIS.OLD_STS_5, MRASSRSHIS.OLD_STS_5, sizeof(MTMPRESHIS.OLD_STS_5));
        memcpy(MTMPRESHIS.OLD_STS_6, MRASSRSHIS.OLD_STS_6, sizeof(MTMPRESHIS.OLD_STS_6));
        memcpy(MTMPRESHIS.OLD_STS_7, MRASSRSHIS.OLD_STS_7, sizeof(MTMPRESHIS.OLD_STS_7));
        memcpy(MTMPRESHIS.OLD_STS_8, MRASSRSHIS.OLD_STS_8, sizeof(MTMPRESHIS.OLD_STS_8));
        memcpy(MTMPRESHIS.OLD_STS_9, MRASSRSHIS.OLD_STS_9, sizeof(MTMPRESHIS.OLD_STS_9));
        memcpy(MTMPRESHIS.OLD_STS_10, MRASSRSHIS.OLD_STS_10, sizeof(MTMPRESHIS.OLD_STS_10));
        MTMPRESHIS.NEW_UP_DOWN_FLAG = MRASSRSHIS.NEW_UP_DOWN_FLAG;
        memcpy(MTMPRESHIS.NEW_PRI_STS, MRASSRSHIS.NEW_PRI_STS, sizeof(MTMPRESHIS.NEW_PRI_STS));
        memcpy(MTMPRESHIS.NEW_STS_1, MRASSRSHIS.NEW_STS_1, sizeof(MTMPRESHIS.NEW_STS_1));
        memcpy(MTMPRESHIS.NEW_STS_2, MRASSRSHIS.NEW_STS_2, sizeof(MTMPRESHIS.NEW_STS_2));
        memcpy(MTMPRESHIS.NEW_STS_3, MRASSRSHIS.NEW_STS_3, sizeof(MTMPRESHIS.NEW_STS_3));
        memcpy(MTMPRESHIS.NEW_STS_4, MRASSRSHIS.NEW_STS_4, sizeof(MTMPRESHIS.NEW_STS_4));
        memcpy(MTMPRESHIS.NEW_STS_5, MRASSRSHIS.NEW_STS_5, sizeof(MTMPRESHIS.NEW_STS_5));
        memcpy(MTMPRESHIS.NEW_STS_6, MRASSRSHIS.NEW_STS_6, sizeof(MTMPRESHIS.NEW_STS_6));
        memcpy(MTMPRESHIS.NEW_STS_7, MRASSRSHIS.NEW_STS_7, sizeof(MTMPRESHIS.NEW_STS_7));
        memcpy(MTMPRESHIS.NEW_STS_8, MRASSRSHIS.NEW_STS_8, sizeof(MTMPRESHIS.NEW_STS_8));
        memcpy(MTMPRESHIS.NEW_STS_9, MRASSRSHIS.NEW_STS_9, sizeof(MTMPRESHIS.NEW_STS_9));
        memcpy(MTMPRESHIS.NEW_STS_10, MRASSRSHIS.NEW_STS_10, sizeof(MTMPRESHIS.NEW_STS_10));
        MTMPRESHIS.LOT_EXIST_FLAG = MRASSRSHIS.LOT_EXIST_FLAG;
        memcpy(MTMPRESHIS.TRAN_CMF_1, MRASSRSHIS.TRAN_CMF_1, sizeof(MTMPRESHIS.TRAN_CMF_1));
        memcpy(MTMPRESHIS.TRAN_CMF_2, MRASSRSHIS.TRAN_CMF_2, sizeof(MTMPRESHIS.TRAN_CMF_2));
        memcpy(MTMPRESHIS.TRAN_CMF_3, MRASSRSHIS.TRAN_CMF_3, sizeof(MTMPRESHIS.TRAN_CMF_3));
        memcpy(MTMPRESHIS.TRAN_CMF_4, MRASSRSHIS.TRAN_CMF_4, sizeof(MTMPRESHIS.TRAN_CMF_4));
        memcpy(MTMPRESHIS.TRAN_CMF_5, MRASSRSHIS.TRAN_CMF_5, sizeof(MTMPRESHIS.TRAN_CMF_5));
        memcpy(MTMPRESHIS.TRAN_CMF_6, MRASSRSHIS.TRAN_CMF_6, sizeof(MTMPRESHIS.TRAN_CMF_6));
        memcpy(MTMPRESHIS.TRAN_CMF_7, MRASSRSHIS.TRAN_CMF_7, sizeof(MTMPRESHIS.TRAN_CMF_7));
        memcpy(MTMPRESHIS.TRAN_CMF_8, MRASSRSHIS.TRAN_CMF_8, sizeof(MTMPRESHIS.TRAN_CMF_8));
        memcpy(MTMPRESHIS.TRAN_CMF_9, MRASSRSHIS.TRAN_CMF_9, sizeof(MTMPRESHIS.TRAN_CMF_9));
        memcpy(MTMPRESHIS.TRAN_CMF_10, MRASSRSHIS.TRAN_CMF_10, sizeof(MTMPRESHIS.TRAN_CMF_10));
        memcpy(MTMPRESHIS.TRAN_CMF_11, MRASSRSHIS.TRAN_CMF_11, sizeof(MTMPRESHIS.TRAN_CMF_11));
        memcpy(MTMPRESHIS.TRAN_CMF_12, MRASSRSHIS.TRAN_CMF_12, sizeof(MTMPRESHIS.TRAN_CMF_12));
        memcpy(MTMPRESHIS.TRAN_CMF_13, MRASSRSHIS.TRAN_CMF_13, sizeof(MTMPRESHIS.TRAN_CMF_13));
        memcpy(MTMPRESHIS.TRAN_CMF_14, MRASSRSHIS.TRAN_CMF_14, sizeof(MTMPRESHIS.TRAN_CMF_14));
        memcpy(MTMPRESHIS.TRAN_CMF_15, MRASSRSHIS.TRAN_CMF_15, sizeof(MTMPRESHIS.TRAN_CMF_15));
        memcpy(MTMPRESHIS.TRAN_CMF_16, MRASSRSHIS.TRAN_CMF_16, sizeof(MTMPRESHIS.TRAN_CMF_16));
        memcpy(MTMPRESHIS.TRAN_CMF_17, MRASSRSHIS.TRAN_CMF_17, sizeof(MTMPRESHIS.TRAN_CMF_17));
        memcpy(MTMPRESHIS.TRAN_CMF_18, MRASSRSHIS.TRAN_CMF_18, sizeof(MTMPRESHIS.TRAN_CMF_18));
        memcpy(MTMPRESHIS.TRAN_CMF_19, MRASSRSHIS.TRAN_CMF_19, sizeof(MTMPRESHIS.TRAN_CMF_19));
        memcpy(MTMPRESHIS.TRAN_CMF_20, MRASSRSHIS.TRAN_CMF_20, sizeof(MTMPRESHIS.TRAN_CMF_20));
        memcpy(MTMPRESHIS.LOT_ID, MRASSRSHIS.LOT_ID, sizeof(MTMPRESHIS.LOT_ID));
        memcpy(MTMPRESHIS.SUBLOT_ID, MRASSRSHIS.SUBLOT_ID, sizeof(MTMPRESHIS.SUBLOT_ID));
        memcpy(MTMPRESHIS.CRR_ID, MRASSRSHIS.CRR_ID, sizeof(MTMPRESHIS.CRR_ID));
        memcpy(MTMPRESHIS.TRAN_USER_ID, MRASSRSHIS.TRAN_USER_ID, sizeof(MTMPRESHIS.TRAN_USER_ID));
        memcpy(MTMPRESHIS.TRAN_COMMENT, MRASSRSHIS.TRAN_COMMENT, sizeof(MTMPRESHIS.TRAN_COMMENT));
        memcpy(MTMPRESHIS.LAST_DOWN_TIME, MRASSRSHIS.LAST_DOWN_TIME, sizeof(MTMPRESHIS.LAST_DOWN_TIME));
        MTMPRESHIS.LAST_DOWN_HIST_SEQ = MRASSRSHIS.LAST_DOWN_HIST_SEQ;
        MTMPRESHIS.HIST_START_SEQ = MRASSRSHIS.HIST_START_SEQ;
        MTMPRESHIS.HIST_DEL_FLAG = MRASSRSHIS.HIST_DEL_FLAG;
        memcpy(MTMPRESHIS.HIST_DEL_TIME, MRASSRSHIS.HIST_DEL_TIME, sizeof(MTMPRESHIS.HIST_DEL_TIME));
        memcpy(MTMPRESHIS.HIST_DEL_USER_ID, MRASSRSHIS.HIST_DEL_USER_ID, sizeof(MTMPRESHIS.HIST_DEL_USER_ID));
        memcpy(MTMPRESHIS.HIST_DEL_COMMENT, MRASSRSHIS.HIST_DEL_COMMENT, sizeof(MRASSRSHIS.HIST_DEL_COMMENT));

        if(TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_ADD, strlen(MP_USUM_TRAN_CODE_EDC_ADD)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_DEL, strlen(MP_USUM_TRAN_CODE_EDC_DEL)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_CHG, strlen(MP_USUM_TRAN_CODE_EDC_CHG)) == 0) 
        {
            memset(MTMPRESHIS.EVENT_ID, ' ', sizeof(MTMPRESHIS.EVENT_ID));
            memset(MTMPRESHIS.TRAN_CMF_1, ' ', sizeof(MTMPRESHIS.TRAN_CMF_1) * 20);

            TRS.copy(MTMPRESHIS.EVENT_ID, sizeof(MTMPRESHIS.EVENT_ID), in_node, "TRAN_CODE");
            TRS.copy(MTMPRESHIS.TRAN_CMF_1, sizeof(MTMPRESHIS.TRAN_CMF_1), in_node, "COL_SET_ID");
            COM_itoa_left(MTMPRESHIS.TRAN_CMF_2, TRS.get_int(in_node, "COL_SEQ"), sizeof(MTMPRESHIS.TRAN_CMF_2));
        }

        DBC_insert_mtmpreshis(&MTMPRESHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTMPRESHIS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASSRSHIS.FACTORY), MRASSRSHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASSRSHIS.RES_ID), MRASSRSHIS.RES_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }


    /* 
        End - Make Data for Standard RAS Loader
        This section could be modify for each site
    */

    return MP_TRUE;
}
