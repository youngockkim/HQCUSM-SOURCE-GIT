/*******************************************************************************

    System      : MESplus
    Module      : UBAS
    File Name   : UBAS_summary_temp_attribute.c
    Description : Summary temp Attribute

    MES Version : 4.0.0

    Function List
        - UBAS_SUMMARY_TEMP_ATTRIBUTE() 
            + Summary Temp Attribute

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/03/13  James Kwon     Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "UBAS_common.h"
int UBAS_SUMMARY_TEMP_ATTRIBUTE(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node);

int UBAS_Summary_Temp_Attribute_1(TRSNode *in_node,
                                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = UBAS_SUMMARY_TEMP_ATTRIBUTE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "UBAS_SUMMARY_TEMP_ATTRIBUTE", out_node);

    return i_ret;
}

int UBAS_SUMMARY_TEMP_ATTRIBUTE(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node)
{

    /* 
        Begin - Make Data for Standard Attribute Loader
        This section could be modify for each site
    */
    struct MATRNAMHIS_TAG MATRNAMHIS;
    struct MTMPATRHIS_TAG MTMPATRHIS;

    DBC_init_matrnamhis(&MATRNAMHIS);
    TRS.copy(MATRNAMHIS.FACTORY, sizeof(MATRNAMHIS.FACTORY), in_node, "FACTORY");
    TRS.copy(MATRNAMHIS.ATTR_TYPE, sizeof(MATRNAMHIS.ATTR_TYPE), in_node, "ATTR_TYPE");
    TRS.copy(MATRNAMHIS.ATTR_NAME, sizeof(MATRNAMHIS.ATTR_NAME), in_node, "ATTR_NAME");
    TRS.copy(MATRNAMHIS.ATTR_KEY, sizeof(MATRNAMHIS.ATTR_KEY), in_node, "ATTR_KEY");
    MATRNAMHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
    DBC_select_matrnamhis(1, &MATRNAMHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "BAS-0004");
        TRS.add_fieldmsg(out_node, "MATRNAMHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMHIS.FACTORY), MATRNAMHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMHIS.ATTR_TYPE), MATRNAMHIS.ATTR_TYPE);
        TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMHIS.ATTR_NAME), MATRNAMHIS.ATTR_NAME);
        TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMHIS.ATTR_KEY), MATRNAMHIS.ATTR_KEY);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MATRNAMHIS.HIST_SEQ);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtmpatrhis(&MTMPATRHIS);

    MTMPATRHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmpatrhis_scalar(2, &MTMPATRHIS);

    memcpy(MTMPATRHIS.FACTORY, MATRNAMHIS.FACTORY, sizeof(MATRNAMHIS.FACTORY));
    memcpy(MTMPATRHIS.ATTR_TYPE, MATRNAMHIS.ATTR_TYPE, sizeof(MATRNAMHIS.ATTR_TYPE));
    memcpy(MTMPATRHIS.ATTR_NAME, MATRNAMHIS.ATTR_NAME, sizeof(MATRNAMHIS.ATTR_NAME));
    memcpy(MTMPATRHIS.ATTR_KEY, MATRNAMHIS.ATTR_KEY, sizeof(MATRNAMHIS.ATTR_KEY));
    MTMPATRHIS.HIST_SEQ = MATRNAMHIS.HIST_SEQ;
    memcpy(MTMPATRHIS.ATTR_OLD_VALUE, MATRNAMHIS.ATTR_OLD_VALUE, sizeof(MATRNAMHIS.ATTR_OLD_VALUE));
    memcpy(MTMPATRHIS.ATTR_NEW_VALUE, MATRNAMHIS.ATTR_NEW_VALUE, sizeof(MATRNAMHIS.ATTR_NEW_VALUE));
    MTMPATRHIS.NULL_FLAG = MATRNAMHIS.NULL_FLAG;
    memcpy(MTMPATRHIS.TRAN_TIME, MATRNAMHIS.TRAN_TIME, sizeof(MATRNAMHIS.TRAN_TIME));
    memcpy(MTMPATRHIS.SYS_TRAN_TIME, MATRNAMHIS.SYS_TRAN_TIME, sizeof(MATRNAMHIS.SYS_TRAN_TIME));
    MTMPATRHIS.KEY_HIST_SEQ = MATRNAMHIS.KEY_HIST_SEQ;
    MTMPATRHIS.PREV_ACTIVE_HIST_SEQ = MATRNAMHIS.PREV_ACTIVE_HIST_SEQ;
    MTMPATRHIS.HIST_START_SEQ = MATRNAMHIS.HIST_START_SEQ;
    MTMPATRHIS.HIST_DEL_FLAG = MATRNAMHIS.HIST_DEL_FLAG;
    memcpy(MTMPATRHIS.HIST_DEL_TIME, MATRNAMHIS.HIST_DEL_TIME, sizeof(MATRNAMHIS.HIST_DEL_TIME));
    memcpy(MTMPATRHIS.HIST_DEL_USER_ID, MATRNAMHIS.HIST_DEL_USER_ID, sizeof(MATRNAMHIS.HIST_DEL_USER_ID));
    memcpy(MTMPATRHIS.HIST_DEL_COMMENT, MATRNAMHIS.HIST_DEL_COMMENT, sizeof(MATRNAMHIS.HIST_DEL_COMMENT));

    // Add by DM KIM 2013.09.03 TRAN_USER_ID  Field Ãß°¡
    memcpy(MTMPATRHIS.TRAN_USER_ID, MATRNAMHIS.TRAN_USER_ID, sizeof(MATRNAMHIS.TRAN_USER_ID));

    DBC_insert_mtmpatrhis(&MTMPATRHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTMPATRHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMHIS.FACTORY), MATRNAMHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMHIS.ATTR_TYPE), MATRNAMHIS.ATTR_TYPE);
        TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMHIS.ATTR_NAME), MATRNAMHIS.ATTR_NAME);
        TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMHIS.ATTR_KEY), MATRNAMHIS.ATTR_KEY);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MATRNAMHIS.HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    /* 
        End - Make Data for Standard Attribute Loader
        This section could be modify for each site
    */

    return MP_TRUE;
}
