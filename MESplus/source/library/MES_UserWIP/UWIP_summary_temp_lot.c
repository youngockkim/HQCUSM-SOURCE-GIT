/*******************************************************************************

    System      : MESplus
    Module      : UWIP
    File Name   : UWIP_summary_temp_lot.c
    Description : Summary temp lot

    MES Version : 4.0.0

    Function List
        - UWIP_SUMMARY_TEMP_LOT() 
            + Summary Temp Lot

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/01/06  Daniel Jeong   Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "UWIP_common.h"
#include <WIPCore_common.h>

int UWIP_SUMMARY_TEMP_LOT(char *s_msg_code,
                          TRSNode *in_node,
                          TRSNode *out_node);

int UWIP_Summary_Temp_Lot_1(TRSNode *in_node,
                            TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = UWIP_SUMMARY_TEMP_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "UWIP_SUMMARY_TEMP_LOT", out_node);

    return i_ret;
}

extern struct LOT_EXT_COL_INFO_TAG LOT_EXT_COL_INFO[500];
extern int    gi_lot_ext_col_count;
extern int    WIP_get_lot_ext_info();

int exthis_gen_insert(char *s_msg_code, TRSNode *in_node, TRSNode *out_node, char *s_dml)
{
    int    i;

    s_dml[0] = 0x00;

    if(WIP_get_lot_ext_info() == MP_FALSE)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "Fail to get Lot Extension in GCM", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    if(gi_lot_ext_col_count < 1)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "Fail to get Lot Extension information", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    for(i = 0; i < gi_lot_ext_col_count; i++)
    {
        if(i == 0)
        {
            sprintf(s_dml, "INSERT INTO MTMPELTHIS(TABLE_UPDATE_SEQ,CM_KEY_1,CM_KEY_2,CM_KEY_3,CM_KEY_4,CM_KEY_5,LOT_ID,HIST_SEQ,%s", LOT_EXT_COL_INFO[i].s_col_name);
        }
        else if(i == gi_lot_ext_col_count - 1)
        {
            sprintf(s_dml + strlen(s_dml), ",%s) SELECT MTMPELTHIS_SEQ.NEXTVAL", LOT_EXT_COL_INFO[i].s_col_name);
        }
        else
        {
            sprintf(s_dml + strlen(s_dml), ",%s", LOT_EXT_COL_INFO[i].s_col_name);
        }
    }

    return MP_TRUE;
}

int UWIP_SUMMARY_TEMP_LOT(char *s_msg_code,
                          TRSNode *in_node,
                          TRSNode *out_node)
{

    /* 
        Begin - Make Data for Standard WIP Loader
        This section could be modify for each site
    */
    struct MWIPLOTHIS_TAG MWIPLOTHIS;
    struct MWIPLOTHIS_TAG OLD_MWIPLOTHIS;
    struct MTMPLOTHIS_TAG MTMPLOTHIS;
    struct MWIPSLTHIS_TAG MWIPSLTHIS;
    struct MWIPSLTHIS_TAG OLD_MWIPSLTHIS;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    int    b_use_extlot;
	clock_t start_time;

    if(TRS.get_char(in_node, MP_WIP_SUBLOT_FLAG) != 'Y')
    {
        DBC_init_mwiplothis(&MWIPLOTHIS);
        TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
        MWIPLOTHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
        DBC_select_mwiplothis(1, &MWIPLOTHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0260");
            TRS.add_fieldmsg(out_node, "MWIPLOTHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MWIPLOTHIS.HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        DBC_init_mwiplothis(&OLD_MWIPLOTHIS);
        //Modify by J.S. 2009.03.10 remote shipping에서 transit을 지울 경우 이전 이력 없음.
        if(TRS.get_int(in_node, "HIST_SEQ") > 1 &&
           memcmp(MWIPLOTHIS.TRAN_CODE, MP_TRAN_CODE_TRANSIT, strlen(MP_TRAN_CODE_TRANSIT)) != 0)
        {
            TRS.copy(OLD_MWIPLOTHIS.LOT_ID, sizeof(OLD_MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
            OLD_MWIPLOTHIS.HIST_SEQ = MWIPLOTHIS.PREV_ACTIVE_HIST_SEQ;
            DBC_select_mwiplothis(1, &OLD_MWIPLOTHIS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0260");
                TRS.add_fieldmsg(out_node, "MWIPLOTHIS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(OLD_MWIPLOTHIS.LOT_ID), OLD_MWIPLOTHIS.LOT_ID);
                TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, OLD_MWIPLOTHIS.HIST_SEQ);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_COMMON;
            
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        memcpy(MGCMTBLDAT.FACTORY, CENTRAL_FACTORY, strlen(CENTRAL_FACTORY));
        memcpy(MGCMTBLDAT.TABLE_NAME, "SUMMARY_OPTION", strlen("SUMMARY_OPTION"));
        memcpy(MGCMTBLDAT.KEY_1, "SYSTEM" , strlen("SYSTEM"));

        DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "GCM-0008");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_COMMON;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
            else
            {
                strcpy(s_msg_code, "GCM-0004");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_COMMON;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
		start_time = STOPWATCH_START();
        DBC_init_mtmplothis(&MTMPLOTHIS);

        MTMPLOTHIS.TABLE_UPDATE_SEQ = DBC_select_mtmplothis_scalar(2, &MTMPLOTHIS);
        memcpy(MTMPLOTHIS.LOT_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
        MTMPLOTHIS.HIST_SEQ = MWIPLOTHIS.HIST_SEQ;
        memcpy(MTMPLOTHIS.TRAN_TIME, MWIPLOTHIS.TRAN_TIME, sizeof(MWIPLOTHIS.TRAN_TIME));
        memcpy(MTMPLOTHIS.SYS_TRAN_TIME, MWIPLOTHIS.SYS_TRAN_TIME, sizeof(MWIPLOTHIS.SYS_TRAN_TIME));
        memcpy(MTMPLOTHIS.TRAN_CODE, MWIPLOTHIS.TRAN_CODE, sizeof(MWIPLOTHIS.TRAN_CODE));
        memcpy(MTMPLOTHIS.LOT_DESC, MWIPLOTHIS.LOT_DESC, sizeof(MWIPLOTHIS.LOT_DESC));
        memcpy(MTMPLOTHIS.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
        if(MGCMTBLDAT.DATA_1[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.MAT_ID, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));
        }
        if(MGCMTBLDAT.DATA_2[0] == 'Y')
        {
            MTMPLOTHIS.MAT_VER = MWIPLOTHIS.MAT_VER;
        }
        if(MGCMTBLDAT.DATA_3[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.FLOW, MWIPLOTHIS.FLOW, sizeof(MWIPLOTHIS.FLOW));
        }
        if(MGCMTBLDAT.DATA_4[0] == 'Y')
        {
            MTMPLOTHIS.FLOW_SEQ_NUM = MWIPLOTHIS.FLOW_SEQ_NUM;
        }
        if(MGCMTBLDAT.DATA_5[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.OPER, MWIPLOTHIS.OPER, sizeof(MWIPLOTHIS.OPER));
        }
        if(MGCMTBLDAT.DATA_6[0] == 'Y')
        {
            MTMPLOTHIS.LOT_TYPE = MWIPLOTHIS.LOT_TYPE;
        }
        if(MGCMTBLDAT.DATA_7[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
            memcpy(MTMPLOTHIS.OLD_ORDER_ID, OLD_MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
        }
        if(MGCMTBLDAT.DATA_8[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.START_RES_ID, MWIPLOTHIS.START_RES_ID, sizeof(MWIPLOTHIS.START_RES_ID));
            memcpy(MTMPLOTHIS.END_RES_ID, MWIPLOTHIS.END_RES_ID, sizeof(MWIPLOTHIS.END_RES_ID));
            memcpy(MTMPLOTHIS.OLD_START_RES_ID, OLD_MWIPLOTHIS.START_RES_ID, sizeof(MWIPLOTHIS.START_RES_ID));
            memcpy(MTMPLOTHIS.OLD_END_RES_ID, OLD_MWIPLOTHIS.END_RES_ID, sizeof(MWIPLOTHIS.END_RES_ID));
        }
        /* Additional Field CM_KEY_1 ~ 5 */
		/* CM_KEY_1 : LINE , CM_KEY_2 : POWER(BATCH SERVER 에서 넣음) , CM_KEY_3 LOT_CREATE_CODE*/
		/* CM_KEY 는 BATCH PROCESS 에서 관리함 */
		memcpy(MTMPLOTHIS.CM_KEY_1, MWIPLOTHIS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));    
		//CM_KEY_2 : POWER
        memcpy(MTMPLOTHIS.CM_KEY_3, MWIPLOTHIS.CREATE_CODE, sizeof(MWIPLOTHIS.CREATE_CODE));    

        /*if(MGCMTBLDAT.DATA_9[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_1, MWIPLOTHIS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));    
        }
        if(MGCMTBLDAT.DATA_9[1] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_2, MWIPLOTHIS.LOT_CMF_2, sizeof(MWIPLOTHIS.LOT_CMF_2));    
        }*/
        /*if(MGCMTBLDAT.DATA_9[2] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_3, MWIPLOTHIS.LOT_CMF_3, sizeof(MWIPLOTHIS.LOT_CMF_3));    
        }*/
		/*
        if(MGCMTBLDAT.DATA_9[3] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_4, MWIPLOTHIS.LOT_CMF_4, sizeof(MWIPLOTHIS.LOT_CMF_4));    
        }
        if(MGCMTBLDAT.DATA_9[4] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_5, MWIPLOTHIS.LOT_CMF_5, sizeof(MWIPLOTHIS.LOT_CMF_5));    
        }
		*/
        MTMPLOTHIS.QTY_1 = MWIPLOTHIS.QTY_1;
        MTMPLOTHIS.QTY_2 = MWIPLOTHIS.QTY_2;
        MTMPLOTHIS.QTY_3 = MWIPLOTHIS.QTY_3;
        memcpy(MTMPLOTHIS.CRR_ID, MWIPLOTHIS.CRR_ID, sizeof(MWIPLOTHIS.CRR_ID));
        memcpy(MTMPLOTHIS.OWNER_CODE, MWIPLOTHIS.OWNER_CODE, sizeof(MWIPLOTHIS.OWNER_CODE));
        memcpy(MTMPLOTHIS.CREATE_CODE, MWIPLOTHIS.CREATE_CODE, sizeof(MWIPLOTHIS.CREATE_CODE));
        MTMPLOTHIS.LOT_PRIORITY = MWIPLOTHIS.LOT_PRIORITY;
        memcpy(MTMPLOTHIS.LOT_STATUS, MWIPLOTHIS.LOT_STATUS, sizeof(MWIPLOTHIS.LOT_STATUS));
        MTMPLOTHIS.HOLD_FLAG = MWIPLOTHIS.HOLD_FLAG;
        memcpy(MTMPLOTHIS.HOLD_CODE, MWIPLOTHIS.HOLD_CODE, sizeof(MWIPLOTHIS.HOLD_CODE));
        memcpy(MTMPLOTHIS.HOLD_PASSWORD, MWIPLOTHIS.HOLD_PASSWORD, sizeof(MWIPLOTHIS.HOLD_PASSWORD));
        memcpy(MTMPLOTHIS.HOLD_PRV_GRP_ID, MWIPLOTHIS.HOLD_PRV_GRP_ID, sizeof(MWIPLOTHIS.HOLD_PRV_GRP_ID));
        MTMPLOTHIS.OPER_IN_QTY_1 = MWIPLOTHIS.OPER_IN_QTY_1;
        MTMPLOTHIS.OPER_IN_QTY_2 = MWIPLOTHIS.OPER_IN_QTY_2;
        MTMPLOTHIS.OPER_IN_QTY_3 = MWIPLOTHIS.OPER_IN_QTY_3;
        MTMPLOTHIS.CREATE_QTY_1 = MWIPLOTHIS.CREATE_QTY_1;
        MTMPLOTHIS.CREATE_QTY_2 = MWIPLOTHIS.CREATE_QTY_2;
        MTMPLOTHIS.CREATE_QTY_3 = MWIPLOTHIS.CREATE_QTY_3;
        MTMPLOTHIS.START_QTY_1 = MWIPLOTHIS.START_QTY_1;
        MTMPLOTHIS.START_QTY_2 = MWIPLOTHIS.START_QTY_2;
        MTMPLOTHIS.START_QTY_3 = MWIPLOTHIS.START_QTY_3;
        MTMPLOTHIS.INV_FLAG = MWIPLOTHIS.INV_FLAG;
        MTMPLOTHIS.TRANSIT_FLAG = MWIPLOTHIS.TRANSIT_FLAG;
        MTMPLOTHIS.UNIT_EXIST_FLAG = MWIPLOTHIS.UNIT_EXIST_FLAG;
        memcpy(MTMPLOTHIS.INV_UNIT, MWIPLOTHIS.INV_UNIT, sizeof(MWIPLOTHIS.INV_UNIT));
        MTMPLOTHIS.RWK_FLAG = MWIPLOTHIS.RWK_FLAG;
        memcpy(MTMPLOTHIS.RWK_CODE, MWIPLOTHIS.RWK_CODE, sizeof(MWIPLOTHIS.RWK_CODE));
        MTMPLOTHIS.RWK_COUNT = MWIPLOTHIS.RWK_COUNT;
        memcpy(MTMPLOTHIS.RWK_RET_FLOW, MWIPLOTHIS.RWK_RET_FLOW, sizeof(MWIPLOTHIS.RWK_RET_FLOW));
        MTMPLOTHIS.RWK_RET_FLOW_SEQ_NUM = MWIPLOTHIS.RWK_RET_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.RWK_RET_OPER, MWIPLOTHIS.RWK_RET_OPER, sizeof(MWIPLOTHIS.RWK_RET_OPER));
        memcpy(MTMPLOTHIS.RWK_END_FLOW, MWIPLOTHIS.RWK_END_FLOW, sizeof(MWIPLOTHIS.RWK_END_FLOW));
        MTMPLOTHIS.RWK_END_FLOW_SEQ_NUM = MWIPLOTHIS.RWK_END_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.RWK_END_OPER, MWIPLOTHIS.RWK_END_OPER, sizeof(MWIPLOTHIS.RWK_END_OPER));
        MTMPLOTHIS.RWK_RET_CLEAR_FLAG = MWIPLOTHIS.RWK_RET_CLEAR_FLAG;
        memcpy(MTMPLOTHIS.RWK_TIME, MWIPLOTHIS.RWK_TIME, sizeof(MWIPLOTHIS.RWK_TIME));
        MTMPLOTHIS.NSTD_FLAG = MWIPLOTHIS.NSTD_FLAG;
        memcpy(MTMPLOTHIS.NSTD_RET_FLOW, MWIPLOTHIS.NSTD_RET_FLOW, sizeof(MWIPLOTHIS.NSTD_RET_FLOW));
        MTMPLOTHIS.NSTD_RET_FLOW_SEQ_NUM = MWIPLOTHIS.NSTD_RET_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.NSTD_RET_OPER, MWIPLOTHIS.NSTD_RET_OPER, sizeof(MWIPLOTHIS.NSTD_RET_OPER));
        memcpy(MTMPLOTHIS.NSTD_TIME, MWIPLOTHIS.NSTD_TIME, sizeof(MWIPLOTHIS.NSTD_TIME));
        MTMPLOTHIS.REP_FLAG = MWIPLOTHIS.REP_FLAG;
        memcpy(MTMPLOTHIS.REP_RET_OPER, MWIPLOTHIS.REP_RET_OPER, sizeof(MWIPLOTHIS.REP_RET_OPER));

        memcpy(MTMPLOTHIS.STR_RET_FLOW, MWIPLOTHIS.STR_RET_FLOW, sizeof(MWIPLOTHIS.STR_RET_FLOW));
        MTMPLOTHIS.STR_RET_FLOW_SEQ_NUM = MWIPLOTHIS.STR_RET_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.STR_RET_OPER, MWIPLOTHIS.STR_RET_OPER, sizeof(MWIPLOTHIS.STR_RET_OPER));

        MTMPLOTHIS.START_FLAG = MWIPLOTHIS.START_FLAG;
        memcpy(MTMPLOTHIS.START_TIME, MWIPLOTHIS.START_TIME, sizeof(MWIPLOTHIS.START_TIME));
        MTMPLOTHIS.END_FLAG = MWIPLOTHIS.END_FLAG;
        memcpy(MTMPLOTHIS.END_TIME, MWIPLOTHIS.END_TIME, sizeof(MWIPLOTHIS.END_TIME));
        MTMPLOTHIS.SAMPLE_FLAG = MWIPLOTHIS.SAMPLE_FLAG;
        MTMPLOTHIS.SAMPLE_WAIT_FLAG = MWIPLOTHIS.SAMPLE_WAIT_FLAG;
        MTMPLOTHIS.SAMPLE_RESULT = MWIPLOTHIS.SAMPLE_RESULT;
        MTMPLOTHIS.FROM_TO_FLAG = MWIPLOTHIS.FROM_TO_FLAG;
        memcpy(MTMPLOTHIS.FROM_TO_LOT_ID, MWIPLOTHIS.FROM_TO_LOT_ID, sizeof(MWIPLOTHIS.FROM_TO_LOT_ID));
        memcpy(MTMPLOTHIS.SHIP_CODE, MWIPLOTHIS.SHIP_CODE, sizeof(MWIPLOTHIS.SHIP_CODE));
        memcpy(MTMPLOTHIS.SHIP_TIME, MWIPLOTHIS.SHIP_TIME, sizeof(MWIPLOTHIS.SHIP_TIME));
        memcpy(MTMPLOTHIS.ORG_DUE_TIME, MWIPLOTHIS.ORG_DUE_TIME, sizeof(MWIPLOTHIS.ORG_DUE_TIME));
        memcpy(MTMPLOTHIS.SCH_DUE_TIME, MWIPLOTHIS.SCH_DUE_TIME, sizeof(MWIPLOTHIS.SCH_DUE_TIME));
        memcpy(MTMPLOTHIS.CREATE_TIME, MWIPLOTHIS.CREATE_TIME, sizeof(MWIPLOTHIS.CREATE_TIME));
        memcpy(MTMPLOTHIS.FAC_IN_TIME, MWIPLOTHIS.FAC_IN_TIME, sizeof(MWIPLOTHIS.FAC_IN_TIME));
        memcpy(MTMPLOTHIS.FLOW_IN_TIME, MWIPLOTHIS.FLOW_IN_TIME, sizeof(MWIPLOTHIS.FLOW_IN_TIME));
        memcpy(MTMPLOTHIS.OPER_IN_TIME, MWIPLOTHIS.OPER_IN_TIME, sizeof(MWIPLOTHIS.OPER_IN_TIME));
        memcpy(MTMPLOTHIS.RESERVE_RES_ID, MWIPLOTHIS.RESERVE_RES_ID, sizeof(MWIPLOTHIS.RESERVE_RES_ID));
        memcpy(MTMPLOTHIS.PORT_ID, MWIPLOTHIS.PORT_ID, sizeof(MWIPLOTHIS.PORT_ID));
        memcpy(MTMPLOTHIS.BATCH_ID, MWIPLOTHIS.BATCH_ID, sizeof(MWIPLOTHIS.BATCH_ID));
        MTMPLOTHIS.BATCH_SEQ = MWIPLOTHIS.BATCH_SEQ;
        memcpy(MTMPLOTHIS.ADD_ORDER_ID_1, MWIPLOTHIS.ADD_ORDER_ID_1, sizeof(MWIPLOTHIS.ADD_ORDER_ID_1));
        memcpy(MTMPLOTHIS.ADD_ORDER_ID_2, MWIPLOTHIS.ADD_ORDER_ID_2, sizeof(MWIPLOTHIS.ADD_ORDER_ID_2));
        memcpy(MTMPLOTHIS.ADD_ORDER_ID_3, MWIPLOTHIS.ADD_ORDER_ID_3, sizeof(MWIPLOTHIS.ADD_ORDER_ID_3));
        memcpy(MTMPLOTHIS.LOT_LOCATION_1, MWIPLOTHIS.LOT_LOCATION_1, sizeof(MWIPLOTHIS.LOT_LOCATION_1));
        memcpy(MTMPLOTHIS.LOT_LOCATION_2, MWIPLOTHIS.LOT_LOCATION_2, sizeof(MWIPLOTHIS.LOT_LOCATION_2));
        memcpy(MTMPLOTHIS.LOT_LOCATION_3, MWIPLOTHIS.LOT_LOCATION_3, sizeof(MWIPLOTHIS.LOT_LOCATION_3));
        memcpy(MTMPLOTHIS.LOT_CMF_1, MWIPLOTHIS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));
        memcpy(MTMPLOTHIS.LOT_CMF_2, MWIPLOTHIS.LOT_CMF_2, sizeof(MWIPLOTHIS.LOT_CMF_2));
        memcpy(MTMPLOTHIS.LOT_CMF_3, MWIPLOTHIS.LOT_CMF_3, sizeof(MWIPLOTHIS.LOT_CMF_3));
        memcpy(MTMPLOTHIS.LOT_CMF_4, MWIPLOTHIS.LOT_CMF_4, sizeof(MWIPLOTHIS.LOT_CMF_4));
        memcpy(MTMPLOTHIS.LOT_CMF_5, MWIPLOTHIS.LOT_CMF_5, sizeof(MWIPLOTHIS.LOT_CMF_5));
        memcpy(MTMPLOTHIS.LOT_CMF_6, MWIPLOTHIS.LOT_CMF_6, sizeof(MWIPLOTHIS.LOT_CMF_6));
        memcpy(MTMPLOTHIS.LOT_CMF_7, MWIPLOTHIS.LOT_CMF_7, sizeof(MWIPLOTHIS.LOT_CMF_7));
        memcpy(MTMPLOTHIS.LOT_CMF_8, MWIPLOTHIS.LOT_CMF_8, sizeof(MWIPLOTHIS.LOT_CMF_8));
        memcpy(MTMPLOTHIS.LOT_CMF_9, MWIPLOTHIS.LOT_CMF_9, sizeof(MWIPLOTHIS.LOT_CMF_9));
        memcpy(MTMPLOTHIS.LOT_CMF_10, MWIPLOTHIS.LOT_CMF_10, sizeof(MWIPLOTHIS.LOT_CMF_10));
        memcpy(MTMPLOTHIS.LOT_CMF_11, MWIPLOTHIS.LOT_CMF_11, sizeof(MWIPLOTHIS.LOT_CMF_11));
        memcpy(MTMPLOTHIS.LOT_CMF_12, MWIPLOTHIS.LOT_CMF_12, sizeof(MWIPLOTHIS.LOT_CMF_12));
        memcpy(MTMPLOTHIS.LOT_CMF_13, MWIPLOTHIS.LOT_CMF_13, sizeof(MWIPLOTHIS.LOT_CMF_13));
        memcpy(MTMPLOTHIS.LOT_CMF_14, MWIPLOTHIS.LOT_CMF_14, sizeof(MWIPLOTHIS.LOT_CMF_14));
        memcpy(MTMPLOTHIS.LOT_CMF_15, MWIPLOTHIS.LOT_CMF_15, sizeof(MWIPLOTHIS.LOT_CMF_15));
        memcpy(MTMPLOTHIS.LOT_CMF_16, MWIPLOTHIS.LOT_CMF_16, sizeof(MWIPLOTHIS.LOT_CMF_16));
        memcpy(MTMPLOTHIS.LOT_CMF_17, MWIPLOTHIS.LOT_CMF_17, sizeof(MWIPLOTHIS.LOT_CMF_17));
        memcpy(MTMPLOTHIS.LOT_CMF_18, MWIPLOTHIS.LOT_CMF_18, sizeof(MWIPLOTHIS.LOT_CMF_18));
        memcpy(MTMPLOTHIS.LOT_CMF_19, MWIPLOTHIS.LOT_CMF_19, sizeof(MWIPLOTHIS.LOT_CMF_19));
        memcpy(MTMPLOTHIS.LOT_CMF_20, MWIPLOTHIS.LOT_CMF_20, sizeof(MWIPLOTHIS.LOT_CMF_20));
        MTMPLOTHIS.LOT_DEL_FLAG = MWIPLOTHIS.LOT_DEL_FLAG;
        memcpy(MTMPLOTHIS.LOT_DEL_CODE, MWIPLOTHIS.LOT_DEL_CODE, sizeof(MWIPLOTHIS.LOT_DEL_CODE));
        memcpy(MTMPLOTHIS.LOT_DEL_TIME, MWIPLOTHIS.LOT_DEL_TIME, sizeof(MWIPLOTHIS.LOT_DEL_TIME));
        memcpy(MTMPLOTHIS.BOM_SET_ID, MWIPLOTHIS.BOM_SET_ID, sizeof(MWIPLOTHIS.BOM_SET_ID));
        MTMPLOTHIS.BOM_SET_VERSION = MWIPLOTHIS.BOM_SET_VERSION;
        MTMPLOTHIS.BOM_ACTIVE_HIST_SEQ = MWIPLOTHIS.BOM_ACTIVE_HIST_SEQ;
        MTMPLOTHIS.BOM_HIST_SEQ = MWIPLOTHIS.BOM_HIST_SEQ;
        memcpy(MTMPLOTHIS.CRITICAL_RES_ID, MWIPLOTHIS.CRITICAL_RES_ID, sizeof(MWIPLOTHIS.CRITICAL_RES_ID));
        memcpy(MTMPLOTHIS.CRITICAL_RES_GROUP_ID, MWIPLOTHIS.CRITICAL_RES_GROUP_ID, sizeof(MWIPLOTHIS.CRITICAL_RES_GROUP_ID));
        memcpy(MTMPLOTHIS.SAVE_RES_ID_1, MWIPLOTHIS.SAVE_RES_ID_1, sizeof(MWIPLOTHIS.SAVE_RES_ID_1));
        memcpy(MTMPLOTHIS.SAVE_RES_ID_2, MWIPLOTHIS.SAVE_RES_ID_2, sizeof(MWIPLOTHIS.SAVE_RES_ID_2));
        memcpy(MTMPLOTHIS.SUBRES_ID, MWIPLOTHIS.SUBRES_ID, sizeof(MWIPLOTHIS.SUBRES_ID));
        memcpy(MTMPLOTHIS.LOT_GROUP_ID_1, MWIPLOTHIS.LOT_GROUP_ID_1, sizeof(MWIPLOTHIS.LOT_GROUP_ID_1));
        memcpy(MTMPLOTHIS.LOT_GROUP_ID_2, MWIPLOTHIS.LOT_GROUP_ID_2, sizeof(MWIPLOTHIS.LOT_GROUP_ID_2));
        memcpy(MTMPLOTHIS.LOT_GROUP_ID_3, MWIPLOTHIS.LOT_GROUP_ID_3, sizeof(MWIPLOTHIS.LOT_GROUP_ID_3));

        MTMPLOTHIS.YIELD_1 = MWIPLOTHIS.YIELD_1;
        MTMPLOTHIS.YIELD_2 = MWIPLOTHIS.YIELD_2;
        MTMPLOTHIS.YIELD_3 = MWIPLOTHIS.YIELD_3;
        MTMPLOTHIS.GOOD_QTY = MWIPLOTHIS.GOOD_QTY;

        memcpy(MTMPLOTHIS.RESV_FIELD_1, MWIPLOTHIS.RESV_FIELD_1, sizeof(MWIPLOTHIS.RESV_FIELD_1));
        memcpy(MTMPLOTHIS.RESV_FIELD_2, MWIPLOTHIS.RESV_FIELD_2, sizeof(MWIPLOTHIS.RESV_FIELD_2));
        memcpy(MTMPLOTHIS.RESV_FIELD_3, MWIPLOTHIS.RESV_FIELD_3, sizeof(MWIPLOTHIS.RESV_FIELD_3));
        memcpy(MTMPLOTHIS.RESV_FIELD_4, MWIPLOTHIS.RESV_FIELD_4, sizeof(MWIPLOTHIS.RESV_FIELD_4));
        memcpy(MTMPLOTHIS.RESV_FIELD_5, MWIPLOTHIS.RESV_FIELD_5, sizeof(MWIPLOTHIS.RESV_FIELD_5));
        MTMPLOTHIS.RESV_FLAG_1 = MWIPLOTHIS.RESV_FLAG_1;
        MTMPLOTHIS.RESV_FLAG_2 = MWIPLOTHIS.RESV_FLAG_2;
        MTMPLOTHIS.RESV_FLAG_3 = MWIPLOTHIS.RESV_FLAG_3;
        MTMPLOTHIS.RESV_FLAG_4 = MWIPLOTHIS.RESV_FLAG_4;
        MTMPLOTHIS.RESV_FLAG_5 = MWIPLOTHIS.RESV_FLAG_5;
        memcpy(MTMPLOTHIS.FROM_TO_MAT_ID, MWIPLOTHIS.FROM_TO_MAT_ID, sizeof(MWIPLOTHIS.FROM_TO_MAT_ID));
        MTMPLOTHIS.FROM_TO_MAT_VER = MWIPLOTHIS.FROM_TO_MAT_VER;
        memcpy(MTMPLOTHIS.FROM_TO_FLOW, MWIPLOTHIS.FROM_TO_FLOW, sizeof(MWIPLOTHIS.FROM_TO_FLOW));
        MTMPLOTHIS.FROM_TO_FLOW_SEQ_NUM = MWIPLOTHIS.FROM_TO_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.FROM_TO_OPER, MWIPLOTHIS.FROM_TO_OPER, sizeof(MWIPLOTHIS.FROM_TO_OPER));
        MTMPLOTHIS.FROM_TO_QTY_1 = MWIPLOTHIS.FROM_TO_QTY_1;
        MTMPLOTHIS.FROM_TO_QTY_2 = MWIPLOTHIS.FROM_TO_QTY_2;
        MTMPLOTHIS.FROM_TO_QTY_3 = MWIPLOTHIS.FROM_TO_QTY_3;
        MTMPLOTHIS.FROM_TO_HIST_SEQ = MWIPLOTHIS.FROM_TO_HIST_SEQ;
        memcpy(MTMPLOTHIS.OLD_TRAN_TIME, OLD_MWIPLOTHIS.TRAN_TIME, sizeof(OLD_MWIPLOTHIS.TRAN_TIME));
        memcpy(MTMPLOTHIS.OLD_SYS_TRAN_TIME, OLD_MWIPLOTHIS.SYS_TRAN_TIME, sizeof(OLD_MWIPLOTHIS.SYS_TRAN_TIME));
        memcpy(MTMPLOTHIS.OLD_TRAN_CODE, OLD_MWIPLOTHIS.TRAN_CODE, sizeof(OLD_MWIPLOTHIS.TRAN_CODE));
        memcpy(MTMPLOTHIS.OLD_FACTORY, MWIPLOTHIS.OLD_FACTORY, sizeof(MWIPLOTHIS.OLD_FACTORY));
        memcpy(MTMPLOTHIS.OLD_MAT_ID, MWIPLOTHIS.OLD_MAT_ID, sizeof(MWIPLOTHIS.OLD_MAT_ID));
        MTMPLOTHIS.OLD_MAT_VER = MWIPLOTHIS.OLD_MAT_VER;
        memcpy(MTMPLOTHIS.OLD_FLOW, MWIPLOTHIS.OLD_FLOW, sizeof(MWIPLOTHIS.OLD_FLOW));
        MTMPLOTHIS.OLD_FLOW_SEQ_NUM = MWIPLOTHIS.OLD_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.OLD_OPER, MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
        MTMPLOTHIS.OLD_QTY_1 = MWIPLOTHIS.OLD_QTY_1;
        MTMPLOTHIS.OLD_QTY_2 = MWIPLOTHIS.OLD_QTY_2;
        MTMPLOTHIS.OLD_QTY_3 = MWIPLOTHIS.OLD_QTY_3;
        MTMPLOTHIS.OLD_LOT_TYPE = MWIPLOTHIS.OLD_LOT_TYPE;
        MTMPLOTHIS.OLD_LOT_PRIORITY = OLD_MWIPLOTHIS.LOT_PRIORITY;
        memcpy(MTMPLOTHIS.OLD_OWNER_CODE, MWIPLOTHIS.OLD_OWNER_CODE, sizeof(MWIPLOTHIS.OLD_OWNER_CODE));
        memcpy(MTMPLOTHIS.OLD_CREATE_CODE, MWIPLOTHIS.OLD_CREATE_CODE, sizeof(MWIPLOTHIS.OLD_CREATE_CODE));
        memcpy(MTMPLOTHIS.OLD_FAC_IN_TIME, MWIPLOTHIS.OLD_FAC_IN_TIME, sizeof(MWIPLOTHIS.OLD_FAC_IN_TIME));
        memcpy(MTMPLOTHIS.OLD_FLOW_IN_TIME, MWIPLOTHIS.OLD_FLOW_IN_TIME, sizeof(MWIPLOTHIS.OLD_FLOW_IN_TIME));
        memcpy(MTMPLOTHIS.OLD_OPER_IN_TIME, MWIPLOTHIS.OLD_OPER_IN_TIME, sizeof(MWIPLOTHIS.OLD_OPER_IN_TIME));
        MTMPLOTHIS.OLD_RWK_FLAG = OLD_MWIPLOTHIS.RWK_FLAG;
        MTMPLOTHIS.OLD_START_FLAG = OLD_MWIPLOTHIS.START_FLAG;
        memcpy(MTMPLOTHIS.OLD_START_TIME, OLD_MWIPLOTHIS.START_TIME, sizeof(MWIPLOTHIS.START_TIME));
        MTMPLOTHIS.OLD_END_FLAG = OLD_MWIPLOTHIS.END_FLAG;
        memcpy(MTMPLOTHIS.OLD_END_TIME, OLD_MWIPLOTHIS.END_TIME, sizeof(MWIPLOTHIS.END_TIME));
        memcpy(MTMPLOTHIS.TRAN_CMF_1, MWIPLOTHIS.TRAN_CMF_1, sizeof(MWIPLOTHIS.TRAN_CMF_1));
        memcpy(MTMPLOTHIS.TRAN_CMF_2, MWIPLOTHIS.TRAN_CMF_2, sizeof(MWIPLOTHIS.TRAN_CMF_2));
        memcpy(MTMPLOTHIS.TRAN_CMF_3, MWIPLOTHIS.TRAN_CMF_3, sizeof(MWIPLOTHIS.TRAN_CMF_3));
        memcpy(MTMPLOTHIS.TRAN_CMF_4, MWIPLOTHIS.TRAN_CMF_4, sizeof(MWIPLOTHIS.TRAN_CMF_4));
        memcpy(MTMPLOTHIS.TRAN_CMF_5, MWIPLOTHIS.TRAN_CMF_5, sizeof(MWIPLOTHIS.TRAN_CMF_5));
        memcpy(MTMPLOTHIS.TRAN_CMF_6, MWIPLOTHIS.TRAN_CMF_6, sizeof(MWIPLOTHIS.TRAN_CMF_6));
        memcpy(MTMPLOTHIS.TRAN_CMF_7, MWIPLOTHIS.TRAN_CMF_7, sizeof(MWIPLOTHIS.TRAN_CMF_7));
        memcpy(MTMPLOTHIS.TRAN_CMF_8, MWIPLOTHIS.TRAN_CMF_8, sizeof(MWIPLOTHIS.TRAN_CMF_8));
        memcpy(MTMPLOTHIS.TRAN_CMF_9, MWIPLOTHIS.TRAN_CMF_9, sizeof(MWIPLOTHIS.TRAN_CMF_9));
        memcpy(MTMPLOTHIS.TRAN_CMF_10, MWIPLOTHIS.TRAN_CMF_10, sizeof(MWIPLOTHIS.TRAN_CMF_10));
        memcpy(MTMPLOTHIS.TRAN_CMF_11, MWIPLOTHIS.TRAN_CMF_11, sizeof(MWIPLOTHIS.TRAN_CMF_11));
        memcpy(MTMPLOTHIS.TRAN_CMF_12, MWIPLOTHIS.TRAN_CMF_12, sizeof(MWIPLOTHIS.TRAN_CMF_12));
        memcpy(MTMPLOTHIS.TRAN_CMF_13, MWIPLOTHIS.TRAN_CMF_13, sizeof(MWIPLOTHIS.TRAN_CMF_13));
        memcpy(MTMPLOTHIS.TRAN_CMF_14, MWIPLOTHIS.TRAN_CMF_14, sizeof(MWIPLOTHIS.TRAN_CMF_14));
        memcpy(MTMPLOTHIS.TRAN_CMF_15, MWIPLOTHIS.TRAN_CMF_15, sizeof(MWIPLOTHIS.TRAN_CMF_15));
        memcpy(MTMPLOTHIS.TRAN_CMF_16, MWIPLOTHIS.TRAN_CMF_16, sizeof(MWIPLOTHIS.TRAN_CMF_16));
        memcpy(MTMPLOTHIS.TRAN_CMF_17, MWIPLOTHIS.TRAN_CMF_17, sizeof(MWIPLOTHIS.TRAN_CMF_17));
        memcpy(MTMPLOTHIS.TRAN_CMF_18, MWIPLOTHIS.TRAN_CMF_18, sizeof(MWIPLOTHIS.TRAN_CMF_18));
        memcpy(MTMPLOTHIS.TRAN_CMF_19, MWIPLOTHIS.TRAN_CMF_19, sizeof(MWIPLOTHIS.TRAN_CMF_19));
        memcpy(MTMPLOTHIS.TRAN_CMF_20, MWIPLOTHIS.TRAN_CMF_20, sizeof(MWIPLOTHIS.TRAN_CMF_20));
        memcpy(MTMPLOTHIS.TRAN_USER_ID, MWIPLOTHIS.TRAN_USER_ID, sizeof(MWIPLOTHIS.TRAN_USER_ID));
        memcpy(MTMPLOTHIS.TRAN_COMMENT, MWIPLOTHIS.TRAN_COMMENT, sizeof(MWIPLOTHIS.TRAN_COMMENT));
        MTMPLOTHIS.PREV_ACTIVE_HIST_SEQ = MWIPLOTHIS.PREV_ACTIVE_HIST_SEQ;
        memcpy(MTMPLOTHIS.MULTI_TR_KEY, MWIPLOTHIS.MULTI_TR_KEY, sizeof(MWIPLOTHIS.MULTI_TR_KEY));
        MTMPLOTHIS.MULTI_TR_SEQ = MWIPLOTHIS.MULTI_TR_SEQ;
        MTMPLOTHIS.EXT_HIST_SEQ = MWIPLOTHIS.EXT_HIST_SEQ;
        MTMPLOTHIS.HIST_DEL_FLAG = TRS.get_char(in_node, "HIST_DEL_FLAG");
        if(MTMPLOTHIS.HIST_DEL_FLAG == 'Y')
        {
            TRS.copy(MTMPLOTHIS.HIST_DEL_TIME, sizeof(MWIPLOTHIS.HIST_DEL_TIME), in_node, "HIST_DEL_TIME");
            TRS.copy(MTMPLOTHIS.HIST_DEL_USER_ID, sizeof(MWIPLOTHIS.HIST_DEL_USER_ID), in_node, "HIST_DEL_USER_ID");
        }
        memcpy(MTMPLOTHIS.HIST_DEL_COMMENT, MWIPLOTHIS.HIST_DEL_COMMENT, sizeof(MWIPLOTHIS.HIST_DEL_COMMENT));


        if(TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_ADD, strlen(MP_USUM_TRAN_CODE_EDC_ADD)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_DEL, strlen(MP_USUM_TRAN_CODE_EDC_DEL)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_USUM_TRAN_CODE_EDC_CHG, strlen(MP_USUM_TRAN_CODE_EDC_CHG)) == 0) 
        {
            memset(MTMPLOTHIS.TRAN_CODE, ' ', sizeof(MTMPLOTHIS.TRAN_CODE));
            memset(MTMPLOTHIS.TRAN_CMF_1, ' ', sizeof(MTMPLOTHIS.TRAN_CMF_1) * 20);

            TRS.copy(MTMPLOTHIS.TRAN_CODE, sizeof(MTMPLOTHIS.TRAN_CODE), in_node, "TRAN_CODE");
            TRS.copy(MTMPLOTHIS.TRAN_CMF_1, sizeof(MTMPLOTHIS.TRAN_CMF_1), in_node, "COL_SET_ID");
            COM_itoa_left(MTMPLOTHIS.TRAN_CMF_2, TRS.get_int(in_node, "COL_SEQ"), sizeof(MTMPLOTHIS.TRAN_CMF_2));
        }

        DBC_insert_mtmplothis(&MTMPLOTHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTMPLOTHIS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTHIS.FACTORY), MWIPLOTHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        
		STOPWATCH_END("MTMPLOTHIS_INSERT_ELAPSED_TIME", start_time);
        
		b_use_extlot = MP_FALSE;
        if(COM_compare_global_option(MWIPLOTHIS.FACTORY, 
                                     MP_OPTION_USE_LOTEXT, 
                                     'Y') == MP_TRUE)
        {
            b_use_extlot = MP_TRUE;
        }

        if(b_use_extlot == MP_TRUE && MWIPLOTHIS.EXT_HIST_SEQ > 0 && OLD_MWIPLOTHIS.EXT_HIST_SEQ != MWIPLOTHIS.EXT_HIST_SEQ)
        {
            char   s_ext_insert[100000];
            char   s_field_value[4001];
            char   s_select[1000];
            int    i_col_idx;

            memset(s_field_value, 0x00, sizeof(s_field_value));
            COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
            sprintf(s_select, "SELECT HIST_SEQ FROM MWIPELTHIS WHERE LOT_ID = '%s' AND HIST_SEQ > %d AND HIST_SEQ <= %d ORDER BY HIST_SEQ ASC", 
                              s_field_value, OLD_MWIPLOTHIS.EXT_HIST_SEQ, MWIPLOTHIS.EXT_HIST_SEQ);

            DBC_execute_query2(s_select);
            if(DB_error_code == DB_SUCCESS)
            {
                while(1)
                {
                    DBC_get_next();
                    if(DB_error_code != DB_SUCCESS)
                    {
                        DBC_close_dsql();
                        break;
                    }

                    if(exthis_gen_insert(s_msg_code, in_node, out_node, s_ext_insert) == MP_FALSE)
                    {
                        DBC_close_dsql();
                        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                        return MP_FALSE;
                    }

                    /* Additional Field CM_KEY_1 ~ 5 */
                    memset(s_field_value, 0x00, sizeof(s_field_value));
                    if(MGCMTBLDAT.DATA_9[0] == 'Y')
                    {
                        COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));
                        if(strlen(s_field_value) > 0)
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                    }
                    else
                    {
                        sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                    }
                    memset(s_field_value, 0x00, sizeof(s_field_value));
                    if(MGCMTBLDAT.DATA_9[1] == 'Y')
                    {
                        COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_2, sizeof(MWIPLOTHIS.LOT_CMF_2));
                        if(strlen(s_field_value) > 0)
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                    }
                    else
                    {
                        sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                    }
                    memset(s_field_value, 0x00, sizeof(s_field_value));
                    if(MGCMTBLDAT.DATA_9[2] == 'Y')
                    {
                        COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_3, sizeof(MWIPLOTHIS.LOT_CMF_3));
                        if(strlen(s_field_value) > 0)
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                    }
                    else
                    {
                        sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                    }
                    memset(s_field_value, 0x00, sizeof(s_field_value));
                    if(MGCMTBLDAT.DATA_9[3] == 'Y')
                    {
                        COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_4, sizeof(MWIPLOTHIS.LOT_CMF_4));
                        if(strlen(s_field_value) > 0)
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                    }
                    else
                    {
                        sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                    }
                    memset(s_field_value, 0x00, sizeof(s_field_value));
                    if(MGCMTBLDAT.DATA_9[4] == 'Y')
                    {
                        COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_5, sizeof(MWIPLOTHIS.LOT_CMF_5));
                        if(strlen(s_field_value) > 0)
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                    }
                    else
                    {
                        sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                    }

                    sprintf(s_ext_insert + strlen(s_ext_insert), ",LOT_ID,HIST_SEQ");

                    for(i_col_idx = 0; i_col_idx < gi_lot_ext_col_count; i_col_idx++)
                    {
                        sprintf(s_ext_insert + strlen(s_ext_insert), ",%s", LOT_EXT_COL_INFO[i_col_idx].s_col_name);
                    }//end for

                    memset(s_field_value, 0x00, sizeof(s_field_value));
                    COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
                    sprintf(s_ext_insert + strlen(s_ext_insert), " FROM MWIPELTHIS WHERE LOT_ID = '%s' AND HIST_SEQ = %d", s_field_value, DBC_get_int_cn("HIST_SEQ"));

                    DBC_execute_non_query(s_ext_insert);
                    if(DB_error_code != DB_SUCCESS)
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_fieldmsg(out_node, "INSERT MTMPELTHIS", MP_NVST);
                        TRS.add_fieldmsg(out_node, "QUERY", MP_NSTR, s_ext_insert);
                        TRS.add_dberrmsg(out_node, DB_error_msg);


                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_COMMON;

                        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                        DBC_close_dsql();
                        return MP_FALSE;
                    }
                }//end while
            }
            else
            {
                DBC_close_dsql();
            }
        }//end if(b_use_extlot == MP_TRUE)


        if(TRS.mem_cmp(in_node, "TRAN_CODE", MP_TRAN_CODE_SPLIT, strlen(MP_TRAN_CODE_SPLIT)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_TRAN_CODE_MERGE, strlen(MP_TRAN_CODE_MERGE)) == 0 ||
           TRS.mem_cmp(in_node, "TRAN_CODE", MP_TRAN_CODE_COMBINE, strlen(MP_TRAN_CODE_COMBINE)) == 0) 
        {
            DBC_init_mwiplothis(&MWIPLOTHIS);
            TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "FROM_TO_LOT_ID");
            MWIPLOTHIS.HIST_SEQ = TRS.get_int(in_node, "FROM_TO_HIST_SEQ");
            DBC_select_mwiplothis(1, &MWIPLOTHIS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0260");
                TRS.add_fieldmsg(out_node, "MWIPLOTHIS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
                TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MWIPLOTHIS.HIST_SEQ);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_COMMON;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            DBC_init_mwiplothis(&OLD_MWIPLOTHIS);
            if(TRS.get_int(in_node, "FROM_TO_HIST_SEQ") > 1)
            {
                TRS.copy(OLD_MWIPLOTHIS.LOT_ID, sizeof(OLD_MWIPLOTHIS.LOT_ID), in_node, "FROM_TO_LOT_ID");
                OLD_MWIPLOTHIS.HIST_SEQ = MWIPLOTHIS.PREV_ACTIVE_HIST_SEQ;
                DBC_select_mwiplothis(1, &OLD_MWIPLOTHIS);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0260");
                    TRS.add_fieldmsg(out_node, "MWIPLOTHIS SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
                    TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MWIPLOTHIS.HIST_SEQ);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    gs_log_type.category = MP_LOG_CATE_COMMON;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }

            DBC_init_mtmplothis(&MTMPLOTHIS);

            MTMPLOTHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmplothis_scalar(2, &MTMPLOTHIS);
            memcpy(MTMPLOTHIS.LOT_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
            MTMPLOTHIS.HIST_SEQ = MWIPLOTHIS.HIST_SEQ;
            memcpy(MTMPLOTHIS.TRAN_TIME, MWIPLOTHIS.TRAN_TIME, sizeof(MWIPLOTHIS.TRAN_TIME));
            memcpy(MTMPLOTHIS.SYS_TRAN_TIME, MWIPLOTHIS.SYS_TRAN_TIME, sizeof(MWIPLOTHIS.SYS_TRAN_TIME));
            memcpy(MTMPLOTHIS.TRAN_CODE, MWIPLOTHIS.TRAN_CODE, sizeof(MWIPLOTHIS.TRAN_CODE));
            memcpy(MTMPLOTHIS.LOT_DESC, MWIPLOTHIS.LOT_DESC, sizeof(MWIPLOTHIS.LOT_DESC));
            memcpy(MTMPLOTHIS.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
            if(MGCMTBLDAT.DATA_1[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.MAT_ID, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));
            }
            if(MGCMTBLDAT.DATA_2[0] == 'Y')
            {
                MTMPLOTHIS.MAT_VER = MWIPLOTHIS.MAT_VER;
            }
            if(MGCMTBLDAT.DATA_3[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.FLOW, MWIPLOTHIS.FLOW, sizeof(MWIPLOTHIS.FLOW));
            }
            if(MGCMTBLDAT.DATA_4[0] == 'Y')
            {
                MTMPLOTHIS.FLOW_SEQ_NUM = MWIPLOTHIS.FLOW_SEQ_NUM;
            }
            if(MGCMTBLDAT.DATA_5[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.OPER, MWIPLOTHIS.OPER, sizeof(MWIPLOTHIS.OPER));
            }
            if(MGCMTBLDAT.DATA_6[0] == 'Y')
            {
                MTMPLOTHIS.LOT_TYPE = MWIPLOTHIS.LOT_TYPE;
            }
            if(MGCMTBLDAT.DATA_7[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
                memcpy(MTMPLOTHIS.OLD_ORDER_ID, OLD_MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
            }
            if(MGCMTBLDAT.DATA_8[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.START_RES_ID, MWIPLOTHIS.START_RES_ID, sizeof(MWIPLOTHIS.START_RES_ID));
                memcpy(MTMPLOTHIS.END_RES_ID, MWIPLOTHIS.END_RES_ID, sizeof(MWIPLOTHIS.END_RES_ID));
                memcpy(MTMPLOTHIS.OLD_START_RES_ID, OLD_MWIPLOTHIS.START_RES_ID, sizeof(MWIPLOTHIS.START_RES_ID));
                memcpy(MTMPLOTHIS.OLD_END_RES_ID, OLD_MWIPLOTHIS.END_RES_ID, sizeof(MWIPLOTHIS.END_RES_ID));
            }
            /* Additional Field CM_KEY_1 ~ 5 */
            if(MGCMTBLDAT.DATA_9[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_1, MWIPLOTHIS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));    
            }
            if(MGCMTBLDAT.DATA_9[1] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_2, MWIPLOTHIS.LOT_CMF_2, sizeof(MWIPLOTHIS.LOT_CMF_2));    
            }
            if(MGCMTBLDAT.DATA_9[2] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_3, MWIPLOTHIS.LOT_CMF_3, sizeof(MWIPLOTHIS.LOT_CMF_3));    
            }
            if(MGCMTBLDAT.DATA_9[3] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_4, MWIPLOTHIS.LOT_CMF_4, sizeof(MWIPLOTHIS.LOT_CMF_4));    
            }
            if(MGCMTBLDAT.DATA_9[4] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_5, MWIPLOTHIS.LOT_CMF_5, sizeof(MWIPLOTHIS.LOT_CMF_5));    
            }
            MTMPLOTHIS.QTY_1 = MWIPLOTHIS.QTY_1;
            MTMPLOTHIS.QTY_2 = MWIPLOTHIS.QTY_2;
            MTMPLOTHIS.QTY_3 = MWIPLOTHIS.QTY_3;
            memcpy(MTMPLOTHIS.CRR_ID, MWIPLOTHIS.CRR_ID, sizeof(MWIPLOTHIS.CRR_ID));
            memcpy(MTMPLOTHIS.OWNER_CODE, MWIPLOTHIS.OWNER_CODE, sizeof(MWIPLOTHIS.OWNER_CODE));
            memcpy(MTMPLOTHIS.CREATE_CODE, MWIPLOTHIS.CREATE_CODE, sizeof(MWIPLOTHIS.CREATE_CODE));
            MTMPLOTHIS.LOT_PRIORITY = MWIPLOTHIS.LOT_PRIORITY;
            memcpy(MTMPLOTHIS.LOT_STATUS, MWIPLOTHIS.LOT_STATUS, sizeof(MWIPLOTHIS.LOT_STATUS));
            MTMPLOTHIS.HOLD_FLAG = MWIPLOTHIS.HOLD_FLAG;
            memcpy(MTMPLOTHIS.HOLD_CODE, MWIPLOTHIS.HOLD_CODE, sizeof(MWIPLOTHIS.HOLD_CODE));
            memcpy(MTMPLOTHIS.HOLD_PASSWORD, MWIPLOTHIS.HOLD_PASSWORD, sizeof(MWIPLOTHIS.HOLD_PASSWORD));
            memcpy(MTMPLOTHIS.HOLD_PRV_GRP_ID, MWIPLOTHIS.HOLD_PRV_GRP_ID, sizeof(MWIPLOTHIS.HOLD_PRV_GRP_ID));
            MTMPLOTHIS.OPER_IN_QTY_1 = MWIPLOTHIS.OPER_IN_QTY_1;
            MTMPLOTHIS.OPER_IN_QTY_2 = MWIPLOTHIS.OPER_IN_QTY_2;
            MTMPLOTHIS.OPER_IN_QTY_3 = MWIPLOTHIS.OPER_IN_QTY_3;
            MTMPLOTHIS.CREATE_QTY_1 = MWIPLOTHIS.CREATE_QTY_1;
            MTMPLOTHIS.CREATE_QTY_2 = MWIPLOTHIS.CREATE_QTY_2;
            MTMPLOTHIS.CREATE_QTY_3 = MWIPLOTHIS.CREATE_QTY_3;
            MTMPLOTHIS.START_QTY_1 = MWIPLOTHIS.START_QTY_1;
            MTMPLOTHIS.START_QTY_2 = MWIPLOTHIS.START_QTY_2;
            MTMPLOTHIS.START_QTY_3 = MWIPLOTHIS.START_QTY_3;
            MTMPLOTHIS.INV_FLAG = MWIPLOTHIS.INV_FLAG;
            MTMPLOTHIS.TRANSIT_FLAG = MWIPLOTHIS.TRANSIT_FLAG;
            MTMPLOTHIS.UNIT_EXIST_FLAG = MWIPLOTHIS.UNIT_EXIST_FLAG;
            memcpy(MTMPLOTHIS.INV_UNIT, MWIPLOTHIS.INV_UNIT, sizeof(MWIPLOTHIS.INV_UNIT));
            MTMPLOTHIS.RWK_FLAG = MWIPLOTHIS.RWK_FLAG;
            memcpy(MTMPLOTHIS.RWK_CODE, MWIPLOTHIS.RWK_CODE, sizeof(MWIPLOTHIS.RWK_CODE));
            MTMPLOTHIS.RWK_COUNT = MWIPLOTHIS.RWK_COUNT;
            memcpy(MTMPLOTHIS.RWK_RET_FLOW, MWIPLOTHIS.RWK_RET_FLOW, sizeof(MWIPLOTHIS.RWK_RET_FLOW));
            MTMPLOTHIS.RWK_RET_FLOW_SEQ_NUM = MWIPLOTHIS.RWK_RET_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.RWK_RET_OPER, MWIPLOTHIS.RWK_RET_OPER, sizeof(MWIPLOTHIS.RWK_RET_OPER));
            memcpy(MTMPLOTHIS.RWK_END_FLOW, MWIPLOTHIS.RWK_END_FLOW, sizeof(MWIPLOTHIS.RWK_END_FLOW));
            MTMPLOTHIS.RWK_END_FLOW_SEQ_NUM = MWIPLOTHIS.RWK_END_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.RWK_END_OPER, MWIPLOTHIS.RWK_END_OPER, sizeof(MWIPLOTHIS.RWK_END_OPER));
            MTMPLOTHIS.RWK_RET_CLEAR_FLAG = MWIPLOTHIS.RWK_RET_CLEAR_FLAG;
            memcpy(MTMPLOTHIS.RWK_TIME, MWIPLOTHIS.RWK_TIME, sizeof(MWIPLOTHIS.RWK_TIME));
            MTMPLOTHIS.NSTD_FLAG = MWIPLOTHIS.NSTD_FLAG;
            memcpy(MTMPLOTHIS.NSTD_RET_FLOW, MWIPLOTHIS.NSTD_RET_FLOW, sizeof(MWIPLOTHIS.NSTD_RET_FLOW));
            MTMPLOTHIS.NSTD_RET_FLOW_SEQ_NUM = MWIPLOTHIS.NSTD_RET_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.NSTD_RET_OPER, MWIPLOTHIS.NSTD_RET_OPER, sizeof(MWIPLOTHIS.NSTD_RET_OPER));
            memcpy(MTMPLOTHIS.NSTD_TIME, MWIPLOTHIS.NSTD_TIME, sizeof(MWIPLOTHIS.NSTD_TIME));
            MTMPLOTHIS.REP_FLAG = MWIPLOTHIS.REP_FLAG;
            memcpy(MTMPLOTHIS.REP_RET_OPER, MWIPLOTHIS.REP_RET_OPER, sizeof(MWIPLOTHIS.REP_RET_OPER));

            memcpy(MTMPLOTHIS.STR_RET_FLOW, MWIPLOTHIS.STR_RET_FLOW, sizeof(MWIPLOTHIS.STR_RET_FLOW));
            MTMPLOTHIS.STR_RET_FLOW_SEQ_NUM = MWIPLOTHIS.STR_RET_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.STR_RET_OPER, MWIPLOTHIS.STR_RET_OPER, sizeof(MWIPLOTHIS.STR_RET_OPER));

            MTMPLOTHIS.START_FLAG = MWIPLOTHIS.START_FLAG;
            memcpy(MTMPLOTHIS.START_TIME, MWIPLOTHIS.START_TIME, sizeof(MWIPLOTHIS.START_TIME));
            MTMPLOTHIS.END_FLAG = MWIPLOTHIS.END_FLAG;
            memcpy(MTMPLOTHIS.END_TIME, MWIPLOTHIS.END_TIME, sizeof(MWIPLOTHIS.END_TIME));
            MTMPLOTHIS.SAMPLE_FLAG = MWIPLOTHIS.SAMPLE_FLAG;
            MTMPLOTHIS.SAMPLE_WAIT_FLAG = MWIPLOTHIS.SAMPLE_WAIT_FLAG;
            MTMPLOTHIS.SAMPLE_RESULT = MWIPLOTHIS.SAMPLE_RESULT;
            MTMPLOTHIS.FROM_TO_FLAG = MWIPLOTHIS.FROM_TO_FLAG;
            memcpy(MTMPLOTHIS.FROM_TO_LOT_ID, MWIPLOTHIS.FROM_TO_LOT_ID, sizeof(MWIPLOTHIS.FROM_TO_LOT_ID));
            memcpy(MTMPLOTHIS.SHIP_CODE, MWIPLOTHIS.SHIP_CODE, sizeof(MWIPLOTHIS.SHIP_CODE));
            memcpy(MTMPLOTHIS.SHIP_TIME, MWIPLOTHIS.SHIP_TIME, sizeof(MWIPLOTHIS.SHIP_TIME));
            memcpy(MTMPLOTHIS.ORG_DUE_TIME, MWIPLOTHIS.ORG_DUE_TIME, sizeof(MWIPLOTHIS.ORG_DUE_TIME));
            memcpy(MTMPLOTHIS.SCH_DUE_TIME, MWIPLOTHIS.SCH_DUE_TIME, sizeof(MWIPLOTHIS.SCH_DUE_TIME));
            memcpy(MTMPLOTHIS.CREATE_TIME, MWIPLOTHIS.CREATE_TIME, sizeof(MWIPLOTHIS.CREATE_TIME));
            memcpy(MTMPLOTHIS.FAC_IN_TIME, MWIPLOTHIS.FAC_IN_TIME, sizeof(MWIPLOTHIS.FAC_IN_TIME));
            memcpy(MTMPLOTHIS.FLOW_IN_TIME, MWIPLOTHIS.FLOW_IN_TIME, sizeof(MWIPLOTHIS.FLOW_IN_TIME));
            memcpy(MTMPLOTHIS.OPER_IN_TIME, MWIPLOTHIS.OPER_IN_TIME, sizeof(MWIPLOTHIS.OPER_IN_TIME));
            memcpy(MTMPLOTHIS.RESERVE_RES_ID, MWIPLOTHIS.RESERVE_RES_ID, sizeof(MWIPLOTHIS.RESERVE_RES_ID));
            memcpy(MTMPLOTHIS.PORT_ID, MWIPLOTHIS.PORT_ID, sizeof(MWIPLOTHIS.PORT_ID));
            memcpy(MTMPLOTHIS.BATCH_ID, MWIPLOTHIS.BATCH_ID, sizeof(MWIPLOTHIS.BATCH_ID));
            MTMPLOTHIS.BATCH_SEQ = MWIPLOTHIS.BATCH_SEQ;
            memcpy(MTMPLOTHIS.ADD_ORDER_ID_1, MWIPLOTHIS.ADD_ORDER_ID_1, sizeof(MWIPLOTHIS.ADD_ORDER_ID_1));
            memcpy(MTMPLOTHIS.ADD_ORDER_ID_2, MWIPLOTHIS.ADD_ORDER_ID_2, sizeof(MWIPLOTHIS.ADD_ORDER_ID_2));
            memcpy(MTMPLOTHIS.ADD_ORDER_ID_3, MWIPLOTHIS.ADD_ORDER_ID_3, sizeof(MWIPLOTHIS.ADD_ORDER_ID_3));
            memcpy(MTMPLOTHIS.LOT_LOCATION_1, MWIPLOTHIS.LOT_LOCATION_1, sizeof(MWIPLOTHIS.LOT_LOCATION_1));
            memcpy(MTMPLOTHIS.LOT_LOCATION_2, MWIPLOTHIS.LOT_LOCATION_2, sizeof(MWIPLOTHIS.LOT_LOCATION_2));
            memcpy(MTMPLOTHIS.LOT_LOCATION_3, MWIPLOTHIS.LOT_LOCATION_3, sizeof(MWIPLOTHIS.LOT_LOCATION_3));
            memcpy(MTMPLOTHIS.LOT_CMF_1, MWIPLOTHIS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));
            memcpy(MTMPLOTHIS.LOT_CMF_2, MWIPLOTHIS.LOT_CMF_2, sizeof(MWIPLOTHIS.LOT_CMF_2));
            memcpy(MTMPLOTHIS.LOT_CMF_3, MWIPLOTHIS.LOT_CMF_3, sizeof(MWIPLOTHIS.LOT_CMF_3));
            memcpy(MTMPLOTHIS.LOT_CMF_4, MWIPLOTHIS.LOT_CMF_4, sizeof(MWIPLOTHIS.LOT_CMF_4));
            memcpy(MTMPLOTHIS.LOT_CMF_5, MWIPLOTHIS.LOT_CMF_5, sizeof(MWIPLOTHIS.LOT_CMF_5));
            memcpy(MTMPLOTHIS.LOT_CMF_6, MWIPLOTHIS.LOT_CMF_6, sizeof(MWIPLOTHIS.LOT_CMF_6));
            memcpy(MTMPLOTHIS.LOT_CMF_7, MWIPLOTHIS.LOT_CMF_7, sizeof(MWIPLOTHIS.LOT_CMF_7));
            memcpy(MTMPLOTHIS.LOT_CMF_8, MWIPLOTHIS.LOT_CMF_8, sizeof(MWIPLOTHIS.LOT_CMF_8));
            memcpy(MTMPLOTHIS.LOT_CMF_9, MWIPLOTHIS.LOT_CMF_9, sizeof(MWIPLOTHIS.LOT_CMF_9));
            memcpy(MTMPLOTHIS.LOT_CMF_10, MWIPLOTHIS.LOT_CMF_10, sizeof(MWIPLOTHIS.LOT_CMF_10));
            memcpy(MTMPLOTHIS.LOT_CMF_11, MWIPLOTHIS.LOT_CMF_11, sizeof(MWIPLOTHIS.LOT_CMF_11));
            memcpy(MTMPLOTHIS.LOT_CMF_12, MWIPLOTHIS.LOT_CMF_12, sizeof(MWIPLOTHIS.LOT_CMF_12));
            memcpy(MTMPLOTHIS.LOT_CMF_13, MWIPLOTHIS.LOT_CMF_13, sizeof(MWIPLOTHIS.LOT_CMF_13));
            memcpy(MTMPLOTHIS.LOT_CMF_14, MWIPLOTHIS.LOT_CMF_14, sizeof(MWIPLOTHIS.LOT_CMF_14));
            memcpy(MTMPLOTHIS.LOT_CMF_15, MWIPLOTHIS.LOT_CMF_15, sizeof(MWIPLOTHIS.LOT_CMF_15));
            memcpy(MTMPLOTHIS.LOT_CMF_16, MWIPLOTHIS.LOT_CMF_16, sizeof(MWIPLOTHIS.LOT_CMF_16));
            memcpy(MTMPLOTHIS.LOT_CMF_17, MWIPLOTHIS.LOT_CMF_17, sizeof(MWIPLOTHIS.LOT_CMF_17));
            memcpy(MTMPLOTHIS.LOT_CMF_18, MWIPLOTHIS.LOT_CMF_18, sizeof(MWIPLOTHIS.LOT_CMF_18));
            memcpy(MTMPLOTHIS.LOT_CMF_19, MWIPLOTHIS.LOT_CMF_19, sizeof(MWIPLOTHIS.LOT_CMF_19));
            memcpy(MTMPLOTHIS.LOT_CMF_20, MWIPLOTHIS.LOT_CMF_20, sizeof(MWIPLOTHIS.LOT_CMF_20));
            MTMPLOTHIS.LOT_DEL_FLAG = MWIPLOTHIS.LOT_DEL_FLAG;
            memcpy(MTMPLOTHIS.LOT_DEL_CODE, MWIPLOTHIS.LOT_DEL_CODE, sizeof(MWIPLOTHIS.LOT_DEL_CODE));
            memcpy(MTMPLOTHIS.LOT_DEL_TIME, MWIPLOTHIS.LOT_DEL_TIME, sizeof(MWIPLOTHIS.LOT_DEL_TIME));
            memcpy(MTMPLOTHIS.BOM_SET_ID, MWIPLOTHIS.BOM_SET_ID, sizeof(MWIPLOTHIS.BOM_SET_ID));
            MTMPLOTHIS.BOM_SET_VERSION = MWIPLOTHIS.BOM_SET_VERSION;
            MTMPLOTHIS.BOM_ACTIVE_HIST_SEQ = MWIPLOTHIS.BOM_ACTIVE_HIST_SEQ;
            MTMPLOTHIS.BOM_HIST_SEQ = MWIPLOTHIS.BOM_HIST_SEQ;
            memcpy(MTMPLOTHIS.CRITICAL_RES_ID, MWIPLOTHIS.CRITICAL_RES_ID, sizeof(MWIPLOTHIS.CRITICAL_RES_ID));
            memcpy(MTMPLOTHIS.CRITICAL_RES_GROUP_ID, MWIPLOTHIS.CRITICAL_RES_GROUP_ID, sizeof(MWIPLOTHIS.CRITICAL_RES_GROUP_ID));
            memcpy(MTMPLOTHIS.SAVE_RES_ID_1, MWIPLOTHIS.SAVE_RES_ID_1, sizeof(MWIPLOTHIS.SAVE_RES_ID_1));
            memcpy(MTMPLOTHIS.SAVE_RES_ID_2, MWIPLOTHIS.SAVE_RES_ID_2, sizeof(MWIPLOTHIS.SAVE_RES_ID_2));
            memcpy(MTMPLOTHIS.SUBRES_ID, MWIPLOTHIS.SUBRES_ID, sizeof(MWIPLOTHIS.SUBRES_ID));
            memcpy(MTMPLOTHIS.LOT_GROUP_ID_1, MWIPLOTHIS.LOT_GROUP_ID_1, sizeof(MWIPLOTHIS.LOT_GROUP_ID_1));
            memcpy(MTMPLOTHIS.LOT_GROUP_ID_2, MWIPLOTHIS.LOT_GROUP_ID_2, sizeof(MWIPLOTHIS.LOT_GROUP_ID_2));
            memcpy(MTMPLOTHIS.LOT_GROUP_ID_3, MWIPLOTHIS.LOT_GROUP_ID_3, sizeof(MWIPLOTHIS.LOT_GROUP_ID_3));

            MTMPLOTHIS.YIELD_1 = MWIPLOTHIS.YIELD_1;
            MTMPLOTHIS.YIELD_2 = MWIPLOTHIS.YIELD_2;
            MTMPLOTHIS.YIELD_3 = MWIPLOTHIS.YIELD_3;
            MTMPLOTHIS.GOOD_QTY = MWIPLOTHIS.GOOD_QTY;

            memcpy(MTMPLOTHIS.RESV_FIELD_1, MWIPLOTHIS.RESV_FIELD_1, sizeof(MWIPLOTHIS.RESV_FIELD_1));
            memcpy(MTMPLOTHIS.RESV_FIELD_2, MWIPLOTHIS.RESV_FIELD_2, sizeof(MWIPLOTHIS.RESV_FIELD_2));
            memcpy(MTMPLOTHIS.RESV_FIELD_3, MWIPLOTHIS.RESV_FIELD_3, sizeof(MWIPLOTHIS.RESV_FIELD_3));
            memcpy(MTMPLOTHIS.RESV_FIELD_4, MWIPLOTHIS.RESV_FIELD_4, sizeof(MWIPLOTHIS.RESV_FIELD_4));
            memcpy(MTMPLOTHIS.RESV_FIELD_5, MWIPLOTHIS.RESV_FIELD_5, sizeof(MWIPLOTHIS.RESV_FIELD_5));
            MTMPLOTHIS.RESV_FLAG_1 = MWIPLOTHIS.RESV_FLAG_1;
            MTMPLOTHIS.RESV_FLAG_2 = MWIPLOTHIS.RESV_FLAG_2;
            MTMPLOTHIS.RESV_FLAG_3 = MWIPLOTHIS.RESV_FLAG_3;
            MTMPLOTHIS.RESV_FLAG_4 = MWIPLOTHIS.RESV_FLAG_4;
            MTMPLOTHIS.RESV_FLAG_5 = MWIPLOTHIS.RESV_FLAG_5;
            memcpy(MTMPLOTHIS.FROM_TO_MAT_ID, MWIPLOTHIS.FROM_TO_MAT_ID, sizeof(MWIPLOTHIS.FROM_TO_MAT_ID));
            MTMPLOTHIS.FROM_TO_MAT_VER = MWIPLOTHIS.FROM_TO_MAT_VER;
            memcpy(MTMPLOTHIS.FROM_TO_FLOW, MWIPLOTHIS.FROM_TO_FLOW, sizeof(MWIPLOTHIS.FROM_TO_FLOW));
            MTMPLOTHIS.FROM_TO_FLOW_SEQ_NUM = MWIPLOTHIS.FROM_TO_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.FROM_TO_OPER, MWIPLOTHIS.FROM_TO_OPER, sizeof(MWIPLOTHIS.FROM_TO_OPER));
            MTMPLOTHIS.FROM_TO_QTY_1 = MWIPLOTHIS.FROM_TO_QTY_1;
            MTMPLOTHIS.FROM_TO_QTY_2 = MWIPLOTHIS.FROM_TO_QTY_2;
            MTMPLOTHIS.FROM_TO_QTY_3 = MWIPLOTHIS.FROM_TO_QTY_3;
            MTMPLOTHIS.FROM_TO_HIST_SEQ = MWIPLOTHIS.FROM_TO_HIST_SEQ;
            memcpy(MTMPLOTHIS.OLD_TRAN_TIME, OLD_MWIPLOTHIS.TRAN_TIME, sizeof(OLD_MWIPLOTHIS.TRAN_TIME));
            memcpy(MTMPLOTHIS.OLD_SYS_TRAN_TIME, OLD_MWIPLOTHIS.SYS_TRAN_TIME, sizeof(OLD_MWIPLOTHIS.SYS_TRAN_TIME));
            memcpy(MTMPLOTHIS.OLD_TRAN_CODE, OLD_MWIPLOTHIS.TRAN_CODE, sizeof(OLD_MWIPLOTHIS.TRAN_CODE));
            memcpy(MTMPLOTHIS.OLD_FACTORY, MWIPLOTHIS.OLD_FACTORY, sizeof(MWIPLOTHIS.OLD_FACTORY));
            memcpy(MTMPLOTHIS.OLD_MAT_ID, MWIPLOTHIS.OLD_MAT_ID, sizeof(MWIPLOTHIS.OLD_MAT_ID));
            MTMPLOTHIS.OLD_MAT_VER = MWIPLOTHIS.OLD_MAT_VER;
            memcpy(MTMPLOTHIS.OLD_FLOW, MWIPLOTHIS.OLD_FLOW, sizeof(MWIPLOTHIS.OLD_FLOW));
            MTMPLOTHIS.OLD_FLOW_SEQ_NUM = MWIPLOTHIS.OLD_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.OLD_OPER, MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
            MTMPLOTHIS.OLD_QTY_1 = MWIPLOTHIS.OLD_QTY_1;
            MTMPLOTHIS.OLD_QTY_2 = MWIPLOTHIS.OLD_QTY_2;
            MTMPLOTHIS.OLD_QTY_3 = MWIPLOTHIS.OLD_QTY_3;
            MTMPLOTHIS.OLD_LOT_TYPE = MWIPLOTHIS.OLD_LOT_TYPE;
            MTMPLOTHIS.OLD_LOT_PRIORITY = OLD_MWIPLOTHIS.LOT_PRIORITY;
            memcpy(MTMPLOTHIS.OLD_OWNER_CODE, MWIPLOTHIS.OLD_OWNER_CODE, sizeof(MWIPLOTHIS.OLD_OWNER_CODE));
            memcpy(MTMPLOTHIS.OLD_CREATE_CODE, MWIPLOTHIS.OLD_CREATE_CODE, sizeof(MWIPLOTHIS.OLD_CREATE_CODE));
            memcpy(MTMPLOTHIS.OLD_FAC_IN_TIME, MWIPLOTHIS.OLD_FAC_IN_TIME, sizeof(MWIPLOTHIS.OLD_FAC_IN_TIME));
            memcpy(MTMPLOTHIS.OLD_FLOW_IN_TIME, MWIPLOTHIS.OLD_FLOW_IN_TIME, sizeof(MWIPLOTHIS.OLD_FLOW_IN_TIME));
            memcpy(MTMPLOTHIS.OLD_OPER_IN_TIME, MWIPLOTHIS.OLD_OPER_IN_TIME, sizeof(MWIPLOTHIS.OLD_OPER_IN_TIME));
            MTMPLOTHIS.OLD_RWK_FLAG = OLD_MWIPLOTHIS.RWK_FLAG;
            MTMPLOTHIS.OLD_START_FLAG = OLD_MWIPLOTHIS.START_FLAG;
            memcpy(MTMPLOTHIS.OLD_START_TIME, OLD_MWIPLOTHIS.START_TIME, sizeof(MWIPLOTHIS.START_TIME));
            MTMPLOTHIS.OLD_END_FLAG = OLD_MWIPLOTHIS.END_FLAG;
            memcpy(MTMPLOTHIS.OLD_END_TIME, OLD_MWIPLOTHIS.END_TIME, sizeof(MWIPLOTHIS.END_TIME));
                    /* Additional Field CM_KEY_1 ~ 5 */
            if(MGCMTBLDAT.DATA_9[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_1, OLD_MWIPLOTHIS.LOT_CMF_1, sizeof(OLD_MWIPLOTHIS.LOT_CMF_1));    
            }
            if(MGCMTBLDAT.DATA_9[1] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_2, OLD_MWIPLOTHIS.LOT_CMF_2, sizeof(OLD_MWIPLOTHIS.LOT_CMF_2));    
            }
            if(MGCMTBLDAT.DATA_9[2] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_3, OLD_MWIPLOTHIS.LOT_CMF_3, sizeof(OLD_MWIPLOTHIS.LOT_CMF_3));    
            }
            if(MGCMTBLDAT.DATA_9[3] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_4, OLD_MWIPLOTHIS.LOT_CMF_4, sizeof(OLD_MWIPLOTHIS.LOT_CMF_4));    
            }
            if(MGCMTBLDAT.DATA_9[4] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_5, OLD_MWIPLOTHIS.LOT_CMF_5, sizeof(OLD_MWIPLOTHIS.LOT_CMF_5));    
            }
            memcpy(MTMPLOTHIS.TRAN_CMF_1, MWIPLOTHIS.TRAN_CMF_1, sizeof(MWIPLOTHIS.TRAN_CMF_1));
            memcpy(MTMPLOTHIS.TRAN_CMF_2, MWIPLOTHIS.TRAN_CMF_2, sizeof(MWIPLOTHIS.TRAN_CMF_2));
            memcpy(MTMPLOTHIS.TRAN_CMF_3, MWIPLOTHIS.TRAN_CMF_3, sizeof(MWIPLOTHIS.TRAN_CMF_3));
            memcpy(MTMPLOTHIS.TRAN_CMF_4, MWIPLOTHIS.TRAN_CMF_4, sizeof(MWIPLOTHIS.TRAN_CMF_4));
            memcpy(MTMPLOTHIS.TRAN_CMF_5, MWIPLOTHIS.TRAN_CMF_5, sizeof(MWIPLOTHIS.TRAN_CMF_5));
            memcpy(MTMPLOTHIS.TRAN_CMF_6, MWIPLOTHIS.TRAN_CMF_6, sizeof(MWIPLOTHIS.TRAN_CMF_6));
            memcpy(MTMPLOTHIS.TRAN_CMF_7, MWIPLOTHIS.TRAN_CMF_7, sizeof(MWIPLOTHIS.TRAN_CMF_7));
            memcpy(MTMPLOTHIS.TRAN_CMF_8, MWIPLOTHIS.TRAN_CMF_8, sizeof(MWIPLOTHIS.TRAN_CMF_8));
            memcpy(MTMPLOTHIS.TRAN_CMF_9, MWIPLOTHIS.TRAN_CMF_9, sizeof(MWIPLOTHIS.TRAN_CMF_9));
            memcpy(MTMPLOTHIS.TRAN_CMF_10, MWIPLOTHIS.TRAN_CMF_10, sizeof(MWIPLOTHIS.TRAN_CMF_10));
            memcpy(MTMPLOTHIS.TRAN_CMF_11, MWIPLOTHIS.TRAN_CMF_11, sizeof(MWIPLOTHIS.TRAN_CMF_11));
            memcpy(MTMPLOTHIS.TRAN_CMF_12, MWIPLOTHIS.TRAN_CMF_12, sizeof(MWIPLOTHIS.TRAN_CMF_12));
            memcpy(MTMPLOTHIS.TRAN_CMF_13, MWIPLOTHIS.TRAN_CMF_13, sizeof(MWIPLOTHIS.TRAN_CMF_13));
            memcpy(MTMPLOTHIS.TRAN_CMF_14, MWIPLOTHIS.TRAN_CMF_14, sizeof(MWIPLOTHIS.TRAN_CMF_14));
            memcpy(MTMPLOTHIS.TRAN_CMF_15, MWIPLOTHIS.TRAN_CMF_15, sizeof(MWIPLOTHIS.TRAN_CMF_15));
            memcpy(MTMPLOTHIS.TRAN_CMF_16, MWIPLOTHIS.TRAN_CMF_16, sizeof(MWIPLOTHIS.TRAN_CMF_16));
            memcpy(MTMPLOTHIS.TRAN_CMF_17, MWIPLOTHIS.TRAN_CMF_17, sizeof(MWIPLOTHIS.TRAN_CMF_17));
            memcpy(MTMPLOTHIS.TRAN_CMF_18, MWIPLOTHIS.TRAN_CMF_18, sizeof(MWIPLOTHIS.TRAN_CMF_18));
            memcpy(MTMPLOTHIS.TRAN_CMF_19, MWIPLOTHIS.TRAN_CMF_19, sizeof(MWIPLOTHIS.TRAN_CMF_19));
            memcpy(MTMPLOTHIS.TRAN_CMF_20, MWIPLOTHIS.TRAN_CMF_20, sizeof(MWIPLOTHIS.TRAN_CMF_20));
            memcpy(MTMPLOTHIS.TRAN_USER_ID, MWIPLOTHIS.TRAN_USER_ID, sizeof(MWIPLOTHIS.TRAN_USER_ID));
            memcpy(MTMPLOTHIS.TRAN_COMMENT, MWIPLOTHIS.TRAN_COMMENT, sizeof(MWIPLOTHIS.TRAN_COMMENT));
            MTMPLOTHIS.PREV_ACTIVE_HIST_SEQ = MWIPLOTHIS.PREV_ACTIVE_HIST_SEQ;
            memcpy(MTMPLOTHIS.MULTI_TR_KEY, MWIPLOTHIS.MULTI_TR_KEY, sizeof(MWIPLOTHIS.MULTI_TR_KEY));
            MTMPLOTHIS.MULTI_TR_SEQ = MWIPLOTHIS.MULTI_TR_SEQ;
            MTMPLOTHIS.EXT_HIST_SEQ = MWIPLOTHIS.EXT_HIST_SEQ;
            MTMPLOTHIS.HIST_DEL_FLAG = TRS.get_char(in_node, "HIST_DEL_FLAG");
            if(MTMPLOTHIS.HIST_DEL_FLAG == 'Y')
            {
                TRS.copy(MTMPLOTHIS.HIST_DEL_TIME, sizeof(MWIPLOTHIS.HIST_DEL_TIME), in_node, "HIST_DEL_TIME");
                TRS.copy(MTMPLOTHIS.HIST_DEL_USER_ID, sizeof(MWIPLOTHIS.HIST_DEL_USER_ID), in_node, "HIST_DEL_USER_ID");
            }
            memcpy(MTMPLOTHIS.HIST_DEL_COMMENT, MWIPLOTHIS.HIST_DEL_COMMENT, sizeof(MWIPLOTHIS.HIST_DEL_COMMENT));

            DBC_insert_mtmplothis(&MTMPLOTHIS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MTMPLOTHIS INSERT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTHIS.FACTORY), MWIPLOTHIS.FACTORY);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_TRANS;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            if(b_use_extlot == MP_TRUE && MWIPLOTHIS.EXT_HIST_SEQ > 0 && OLD_MWIPLOTHIS.EXT_HIST_SEQ != MWIPLOTHIS.EXT_HIST_SEQ)
            {
                char   s_ext_insert[100000];
                char   s_field_value[4001];
                char   s_select[1000];
                int    i_col_idx;

                memset(s_field_value, 0x00, sizeof(s_field_value));
                COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
                sprintf(s_select, "SELECT HIST_SEQ FROM MWIPELTHIS WHERE LOT_ID = '%s' AND HIST_SEQ > %d AND HIST_SEQ <= %d ORDER BY HIST_SEQ ASC", 
                                      s_field_value, OLD_MWIPLOTHIS.EXT_HIST_SEQ, MWIPLOTHIS.EXT_HIST_SEQ);
    
                DBC_execute_query2(s_select);
                if(DB_error_code == DB_SUCCESS)
                {
                    while(1)
                    {
                        DBC_get_next();
                        if(DB_error_code != DB_SUCCESS)
                        {
                            DBC_close_dsql();
                            break;
                        }
    
                        if(exthis_gen_insert(s_msg_code, in_node, out_node, s_ext_insert) == MP_FALSE)
                        {
                            DBC_close_dsql();
                            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                            return MP_FALSE;
                        }
    
                        /* Additional Field CM_KEY_1 ~ 5 */
                        memset(s_field_value, 0x00, sizeof(s_field_value));
                        if(MGCMTBLDAT.DATA_9[0] == 'Y')
                        {
                            COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_1, sizeof(MWIPLOTHIS.LOT_CMF_1));
                            if(strlen(s_field_value) > 0)
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                            }
                            else
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                            }
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                        memset(s_field_value, 0x00, sizeof(s_field_value));
                        if(MGCMTBLDAT.DATA_9[1] == 'Y')
                        {
                            COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_2, sizeof(MWIPLOTHIS.LOT_CMF_2));
                            if(strlen(s_field_value) > 0)
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                            }
                            else
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                            }
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                        memset(s_field_value, 0x00, sizeof(s_field_value));
                        if(MGCMTBLDAT.DATA_9[2] == 'Y')
                        {
                            COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_3, sizeof(MWIPLOTHIS.LOT_CMF_3));
                            if(strlen(s_field_value) > 0)
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                            }
                            else
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                            }
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                        memset(s_field_value, 0x00, sizeof(s_field_value));
                        if(MGCMTBLDAT.DATA_9[3] == 'Y')
                        {
                            COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_4, sizeof(MWIPLOTHIS.LOT_CMF_4));
                            if(strlen(s_field_value) > 0)
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                            }
                            else
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                            }
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
                        memset(s_field_value, 0x00, sizeof(s_field_value));
                        if(MGCMTBLDAT.DATA_9[4] == 'Y')
                        {
                            COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_CMF_5, sizeof(MWIPLOTHIS.LOT_CMF_5));
                            if(strlen(s_field_value) > 0)
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",'%s'", s_field_value);
                            }
                            else
                            {
                                sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                            }
                        }
                        else
                        {
                            sprintf(s_ext_insert + strlen(s_ext_insert), ",' '");
                        }
    
                	    sprintf(s_ext_insert + strlen(s_ext_insert), ",LOT_ID,HIST_SEQ");
    
                        for(i_col_idx = 0; i_col_idx < gi_lot_ext_col_count; i_col_idx++)
                        {
                    	    sprintf(s_ext_insert + strlen(s_ext_insert), ",%s", LOT_EXT_COL_INFO[i_col_idx].s_col_name);
                	    }//end for

                        memset(s_field_value, 0x00, sizeof(s_field_value));
                	    COM_memcpy_add_null(s_field_value, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
                	    sprintf(s_ext_insert + strlen(s_ext_insert), " FROM MWIPELTHIS WHERE LOT_ID = '%s' AND HIST_SEQ = %d", s_field_value, DBC_get_int_cn("HIST_SEQ"));

                        DBC_execute_non_query(s_ext_insert);
                        if(DB_error_code != DB_SUCCESS)
                        {
                            strcpy(s_msg_code, "WIP-0004");
                            TRS.add_fieldmsg(out_node, "INSERT MTMPELTHIS", MP_NVST);
                            TRS.add_fieldmsg(out_node, "QUERY", MP_NSTR, s_ext_insert);
                            TRS.add_dberrmsg(out_node, DB_error_msg);


                            gs_log_type.type = MP_LOG_ERROR;
                            gs_log_type.e_type = MP_LOG_E_SYSTEM;
                            gs_log_type.category = MP_LOG_CATE_COMMON;

                            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                            DBC_close_dsql();
                            return MP_FALSE;
                        }
                    }//end while
                }
                else
                {
                    DBC_close_dsql();
                }
            }//end if(b_use_extlot == MP_TRUE)

        }// case split, merge, combine

    } else  /* Wafer History */
    {
        DBC_init_mwipslthis(&MWIPSLTHIS);
        TRS.copy(MWIPSLTHIS.SUBLOT_ID, sizeof(MWIPSLTHIS.SUBLOT_ID), in_node, "SUBLOT_ID");
        MWIPSLTHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
        DBC_select_mwipslthis(1, &MWIPSLTHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0260");
            TRS.add_fieldmsg(out_node, "MWIPSLTHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTHIS.LOT_ID), MWIPSLTHIS.LOT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MWIPSLTHIS.HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        DBC_init_mwipslthis(&OLD_MWIPSLTHIS);
        if(TRS.get_int(in_node, "HIST_SEQ") > 1 &&
           memcmp(MWIPSLTHIS.TRAN_CODE, MP_TRAN_CODE_TRANSIT, sizeof(MWIPSLTHIS.TRAN_CODE)) != 0)
        {
            TRS.copy(OLD_MWIPSLTHIS.SUBLOT_ID, sizeof(OLD_MWIPSLTHIS.SUBLOT_ID), in_node, "SUBLOT_ID");
            OLD_MWIPSLTHIS.HIST_SEQ = MWIPSLTHIS.PREV_ACTIVE_HIST_SEQ;
            DBC_select_mwipslthis(1, &OLD_MWIPSLTHIS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0260");
                TRS.add_fieldmsg(out_node, "MWIPSLTHIS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(OLD_MWIPSLTHIS.LOT_ID), OLD_MWIPSLTHIS.LOT_ID);
                TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, OLD_MWIPSLTHIS.HIST_SEQ);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_COMMON;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        memcpy(MGCMTBLDAT.FACTORY, CENTRAL_FACTORY, strlen(CENTRAL_FACTORY));
        memcpy(MGCMTBLDAT.TABLE_NAME, "SUMMARY_OPTION", strlen("SUMMARY_OPTION"));
        memcpy(MGCMTBLDAT.KEY_1, "SYSTEM" , strlen("SYSTEM"));

        DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "GCM-0008");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_COMMON;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
            else
            {
                strcpy(s_msg_code, "GCM-0004");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "OPTION_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_COMMON;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        DBC_init_mtmplothis(&MTMPLOTHIS);

        MTMPLOTHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmplothis_scalar(2, &MTMPLOTHIS);
        memcpy(MTMPLOTHIS.LOT_ID, MWIPSLTHIS.LOT_ID, sizeof(MWIPSLTHIS.LOT_ID));
        memcpy(MTMPLOTHIS.SUB_LOT_ID, MWIPSLTHIS.SUBLOT_ID, sizeof(MWIPSLTHIS.SUBLOT_ID));
        MTMPLOTHIS.SUB_LOT_FLAG = 'Y';
        MTMPLOTHIS.HIST_SEQ = MWIPSLTHIS.HIST_SEQ;
        memcpy(MTMPLOTHIS.TRAN_TIME, MWIPSLTHIS.TRAN_TIME, sizeof(MWIPSLTHIS.TRAN_TIME));
        memcpy(MTMPLOTHIS.SYS_TRAN_TIME, MWIPSLTHIS.SYS_TRAN_TIME, sizeof(MWIPSLTHIS.SYS_TRAN_TIME));
        memcpy(MTMPLOTHIS.TRAN_CODE, MWIPSLTHIS.TRAN_CODE, sizeof(MWIPSLTHIS.TRAN_CODE));
        memcpy(MTMPLOTHIS.FACTORY, MWIPSLTHIS.FACTORY, sizeof(MWIPSLTHIS.FACTORY));
        if(MGCMTBLDAT.DATA_1[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.MAT_ID, MWIPSLTHIS.MAT_ID, sizeof(MWIPSLTHIS.MAT_ID));
        }
        if(MGCMTBLDAT.DATA_2[0] == 'Y')
        {
            MTMPLOTHIS.MAT_VER = MWIPSLTHIS.MAT_VER;
        }
        if(MGCMTBLDAT.DATA_3[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.FLOW, MWIPSLTHIS.FLOW, sizeof(MWIPSLTHIS.FLOW));
        }
        if(MGCMTBLDAT.DATA_4[0] == 'Y')
        {
            MTMPLOTHIS.FLOW_SEQ_NUM = MWIPSLTHIS.FLOW_SEQ_NUM;
        }
        if(MGCMTBLDAT.DATA_5[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.OPER, MWIPSLTHIS.OPER, sizeof(MWIPSLTHIS.OPER));
        }
        if(MGCMTBLDAT.DATA_8[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.START_RES_ID, MWIPSLTHIS.START_RES_ID, sizeof(MWIPSLTHIS.START_RES_ID));
            memcpy(MTMPLOTHIS.END_RES_ID, MWIPSLTHIS.END_RES_ID, sizeof(MWIPSLTHIS.END_RES_ID));
        }
        /* Additional Field CM_KEY_1 ~ 5 */
        if(MGCMTBLDAT.DATA_9[0] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_1, MWIPSLTHIS.SUBLOT_CMF_1, sizeof(MWIPSLTHIS.SUBLOT_CMF_1));    
        }
        if(MGCMTBLDAT.DATA_9[1] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_2, MWIPSLTHIS.SUBLOT_CMF_2, sizeof(MWIPSLTHIS.SUBLOT_CMF_2));    
        }
        if(MGCMTBLDAT.DATA_9[2] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_3, MWIPSLTHIS.SUBLOT_CMF_3, sizeof(MWIPSLTHIS.SUBLOT_CMF_3));    
        }
        if(MGCMTBLDAT.DATA_9[3] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_4, MWIPSLTHIS.SUBLOT_CMF_4, sizeof(MWIPSLTHIS.SUBLOT_CMF_4));    
        }
        if(MGCMTBLDAT.DATA_9[4] == 'Y')
        {
            memcpy(MTMPLOTHIS.CM_KEY_5, MWIPSLTHIS.SUBLOT_CMF_5, sizeof(MWIPSLTHIS.SUBLOT_CMF_5));    
        }
        MTMPLOTHIS.QTY_1 = 0;
        MTMPLOTHIS.QTY_2 = MWIPSLTHIS.QTY_2;
        MTMPLOTHIS.QTY_3 = MWIPSLTHIS.QTY_3;
        memcpy(MTMPLOTHIS.CRR_ID, MWIPSLTHIS.CRR_ID, sizeof(MWIPSLTHIS.CRR_ID));
        memcpy(MTMPLOTHIS.OWNER_CODE, MWIPSLTHIS.OWNER_CODE, sizeof(MWIPSLTHIS.OWNER_CODE));
        memcpy(MTMPLOTHIS.CREATE_CODE, MWIPSLTHIS.CREATE_CODE, sizeof(MWIPSLTHIS.CREATE_CODE));
        MTMPLOTHIS.LOT_PRIORITY = '5';

        memcpy(MTMPLOTHIS.LOT_STATUS, MWIPSLTHIS.SUBLOT_STATUS, sizeof(MWIPSLTHIS.SUBLOT_STATUS));
        MTMPLOTHIS.LOT_TYPE = MWIPSLTHIS.SUBLOT_TYPE;
        
        MTMPLOTHIS.HOLD_FLAG = MWIPSLTHIS.HOLD_FLAG;
        memcpy(MTMPLOTHIS.HOLD_CODE, MWIPSLTHIS.HOLD_CODE, sizeof(MWIPSLTHIS.HOLD_CODE));
        memcpy(MTMPLOTHIS.HOLD_PASSWORD, MWIPSLTHIS.HOLD_PASSWORD, sizeof(MWIPSLTHIS.HOLD_PASSWORD));
        memcpy(MTMPLOTHIS.HOLD_PRV_GRP_ID, MWIPSLTHIS.HOLD_PRV_GRP_ID, sizeof(MWIPSLTHIS.HOLD_PRV_GRP_ID));
        MTMPLOTHIS.OPER_IN_QTY_1 = 0;
        MTMPLOTHIS.OPER_IN_QTY_2 = MWIPSLTHIS.OPER_IN_QTY_2;
        MTMPLOTHIS.OPER_IN_QTY_3 = MWIPSLTHIS.OPER_IN_QTY_3;
        MTMPLOTHIS.CREATE_QTY_1 = 0;
        MTMPLOTHIS.CREATE_QTY_2 = MWIPSLTHIS.CREATE_QTY_2;
        MTMPLOTHIS.CREATE_QTY_3 = MWIPSLTHIS.CREATE_QTY_3;
        MTMPLOTHIS.START_QTY_1 = 0;
        MTMPLOTHIS.START_QTY_2 = MWIPSLTHIS.START_QTY_2;
        MTMPLOTHIS.START_QTY_3 = MWIPSLTHIS.START_QTY_3;
        MTMPLOTHIS.INV_FLAG = MWIPSLTHIS.INV_FLAG;
        MTMPLOTHIS.TRANSIT_FLAG = MWIPSLTHIS.TRANSIT_FLAG;
        MTMPLOTHIS.UNIT_EXIST_FLAG = MWIPSLTHIS.UNIT_EXIST_FLAG;
        memcpy(MTMPLOTHIS.INV_UNIT, MWIPSLTHIS.INV_UNIT, sizeof(MWIPSLTHIS.INV_UNIT));
        MTMPLOTHIS.RWK_FLAG = MWIPSLTHIS.RWK_FLAG;
        memcpy(MTMPLOTHIS.RWK_CODE, MWIPSLTHIS.RWK_CODE, sizeof(MWIPSLTHIS.RWK_CODE));
        MTMPLOTHIS.RWK_COUNT = MWIPSLTHIS.RWK_COUNT;
        memcpy(MTMPLOTHIS.RWK_RET_FLOW, MWIPSLTHIS.RWK_RET_FLOW, sizeof(MWIPSLTHIS.RWK_RET_FLOW));
        MTMPLOTHIS.RWK_RET_FLOW_SEQ_NUM = MWIPSLTHIS.RWK_RET_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.RWK_RET_OPER, MWIPSLTHIS.RWK_RET_OPER, sizeof(MWIPSLTHIS.RWK_RET_OPER));
        memcpy(MTMPLOTHIS.RWK_END_FLOW, MWIPSLTHIS.RWK_END_FLOW, sizeof(MWIPSLTHIS.RWK_END_FLOW));
        MTMPLOTHIS.RWK_END_FLOW_SEQ_NUM = MWIPSLTHIS.RWK_END_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.RWK_END_OPER, MWIPSLTHIS.RWK_END_OPER, sizeof(MWIPSLTHIS.RWK_END_OPER));
        MTMPLOTHIS.RWK_RET_CLEAR_FLAG = MWIPSLTHIS.RWK_RET_CLEAR_FLAG;
        memcpy(MTMPLOTHIS.RWK_TIME, MWIPSLTHIS.RWK_TIME, sizeof(MWIPSLTHIS.RWK_TIME));
        MTMPLOTHIS.NSTD_FLAG = MWIPSLTHIS.NSTD_FLAG;
        memcpy(MTMPLOTHIS.NSTD_RET_FLOW, MWIPSLTHIS.NSTD_RET_FLOW, sizeof(MWIPSLTHIS.NSTD_RET_FLOW));
        MTMPLOTHIS.NSTD_RET_FLOW_SEQ_NUM = MWIPSLTHIS.NSTD_RET_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.NSTD_RET_OPER, MWIPSLTHIS.NSTD_RET_OPER, sizeof(MWIPSLTHIS.NSTD_RET_OPER));
        memcpy(MTMPLOTHIS.NSTD_TIME, MWIPSLTHIS.NSTD_TIME, sizeof(MWIPSLTHIS.NSTD_TIME));
        MTMPLOTHIS.REP_FLAG = MWIPSLTHIS.REP_FLAG;
        memcpy(MTMPLOTHIS.REP_RET_OPER, MWIPSLTHIS.REP_RET_OPER, sizeof(MWIPSLTHIS.REP_RET_OPER));

        memcpy(MTMPLOTHIS.STR_RET_FLOW, MWIPSLTHIS.STR_RET_FLOW, sizeof(MWIPSLTHIS.STR_RET_FLOW));
        MTMPLOTHIS.STR_RET_FLOW_SEQ_NUM = MWIPSLTHIS.STR_RET_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.STR_RET_OPER, MWIPSLTHIS.STR_RET_OPER, sizeof(MWIPSLTHIS.STR_RET_OPER));

        MTMPLOTHIS.START_FLAG = MWIPSLTHIS.START_FLAG;
        memcpy(MTMPLOTHIS.START_TIME, MWIPSLTHIS.START_TIME, sizeof(MWIPSLTHIS.START_TIME));
        MTMPLOTHIS.END_FLAG = MWIPSLTHIS.END_FLAG;
        memcpy(MTMPLOTHIS.END_TIME, MWIPSLTHIS.END_TIME, sizeof(MWIPSLTHIS.END_TIME));
        MTMPLOTHIS.SAMPLE_FLAG = MWIPSLTHIS.SAMPLE_FLAG;
        MTMPLOTHIS.SAMPLE_WAIT_FLAG = MWIPSLTHIS.SAMPLE_WAIT_FLAG;
        MTMPLOTHIS.SAMPLE_RESULT = MWIPSLTHIS.SAMPLE_RESULT;
        memcpy(MTMPLOTHIS.RESERVE_RES_ID, MWIPSLTHIS.RESERVE_RES_ID, sizeof(MWIPSLTHIS.RESERVE_RES_ID));
        memcpy(MTMPLOTHIS.PORT_ID, MWIPSLTHIS.PORT_ID, sizeof(MWIPSLTHIS.PORT_ID));
        MTMPLOTHIS.BATCH_SEQ = 0;
        memcpy(MTMPLOTHIS.CREATE_TIME, MWIPSLTHIS.CREATE_TIME, sizeof(MWIPSLTHIS.CREATE_TIME));
        memcpy(MTMPLOTHIS.FAC_IN_TIME, MWIPSLTHIS.FAC_IN_TIME, sizeof(MWIPSLTHIS.FAC_IN_TIME));
        memcpy(MTMPLOTHIS.FLOW_IN_TIME, MWIPSLTHIS.FLOW_IN_TIME, sizeof(MWIPSLTHIS.FLOW_IN_TIME));
        memcpy(MTMPLOTHIS.OPER_IN_TIME, MWIPSLTHIS.OPER_IN_TIME, sizeof(MWIPSLTHIS.OPER_IN_TIME));
        memcpy(MTMPLOTHIS.LOT_CMF_1, MWIPSLTHIS.SUBLOT_CMF_1, sizeof(MWIPSLTHIS.SUBLOT_CMF_1));
        memcpy(MTMPLOTHIS.LOT_CMF_2, MWIPSLTHIS.SUBLOT_CMF_2, sizeof(MWIPSLTHIS.SUBLOT_CMF_2));
        memcpy(MTMPLOTHIS.LOT_CMF_3, MWIPSLTHIS.SUBLOT_CMF_3, sizeof(MWIPSLTHIS.SUBLOT_CMF_3));
        memcpy(MTMPLOTHIS.LOT_CMF_4, MWIPSLTHIS.SUBLOT_CMF_4, sizeof(MWIPSLTHIS.SUBLOT_CMF_4));
        memcpy(MTMPLOTHIS.LOT_CMF_5, MWIPSLTHIS.SUBLOT_CMF_5, sizeof(MWIPSLTHIS.SUBLOT_CMF_5));
        memcpy(MTMPLOTHIS.LOT_CMF_6, MWIPSLTHIS.SUBLOT_CMF_6, sizeof(MWIPSLTHIS.SUBLOT_CMF_6));
        memcpy(MTMPLOTHIS.LOT_CMF_7, MWIPSLTHIS.SUBLOT_CMF_7, sizeof(MWIPSLTHIS.SUBLOT_CMF_7));
        memcpy(MTMPLOTHIS.LOT_CMF_8, MWIPSLTHIS.SUBLOT_CMF_8, sizeof(MWIPSLTHIS.SUBLOT_CMF_8));
        memcpy(MTMPLOTHIS.LOT_CMF_9, MWIPSLTHIS.SUBLOT_CMF_9, sizeof(MWIPSLTHIS.SUBLOT_CMF_9));
        memcpy(MTMPLOTHIS.LOT_CMF_10, MWIPSLTHIS.SUBLOT_CMF_10, sizeof(MWIPSLTHIS.SUBLOT_CMF_10));
        memcpy(MTMPLOTHIS.LOT_CMF_11, MWIPSLTHIS.SUBLOT_CMF_11, sizeof(MWIPSLTHIS.SUBLOT_CMF_11));
        memcpy(MTMPLOTHIS.LOT_CMF_12, MWIPSLTHIS.SUBLOT_CMF_12, sizeof(MWIPSLTHIS.SUBLOT_CMF_12));
        memcpy(MTMPLOTHIS.LOT_CMF_13, MWIPSLTHIS.SUBLOT_CMF_13, sizeof(MWIPSLTHIS.SUBLOT_CMF_13));
        memcpy(MTMPLOTHIS.LOT_CMF_14, MWIPSLTHIS.SUBLOT_CMF_14, sizeof(MWIPSLTHIS.SUBLOT_CMF_14));
        memcpy(MTMPLOTHIS.LOT_CMF_15, MWIPSLTHIS.SUBLOT_CMF_15, sizeof(MWIPSLTHIS.SUBLOT_CMF_15));
        memcpy(MTMPLOTHIS.LOT_CMF_16, MWIPSLTHIS.SUBLOT_CMF_16, sizeof(MWIPSLTHIS.SUBLOT_CMF_16));
        memcpy(MTMPLOTHIS.LOT_CMF_17, MWIPSLTHIS.SUBLOT_CMF_17, sizeof(MWIPSLTHIS.SUBLOT_CMF_17));
        memcpy(MTMPLOTHIS.LOT_CMF_18, MWIPSLTHIS.SUBLOT_CMF_18, sizeof(MWIPSLTHIS.SUBLOT_CMF_18));
        memcpy(MTMPLOTHIS.LOT_CMF_19, MWIPSLTHIS.SUBLOT_CMF_19, sizeof(MWIPSLTHIS.SUBLOT_CMF_19));
        memcpy(MTMPLOTHIS.LOT_CMF_20, MWIPSLTHIS.SUBLOT_CMF_20, sizeof(MWIPSLTHIS.SUBLOT_CMF_20));
        MTMPLOTHIS.LOT_DEL_FLAG = MWIPSLTHIS.SUBLOT_DEL_FLAG;
        memcpy(MTMPLOTHIS.LOT_DEL_CODE, MWIPSLTHIS.SUBLOT_DEL_CODE, sizeof(MWIPSLTHIS.SUBLOT_DEL_CODE));
        memcpy(MTMPLOTHIS.LOT_DEL_TIME, MWIPSLTHIS.SUBLOT_DEL_TIME, sizeof(MWIPSLTHIS.SUBLOT_DEL_TIME));
        MTMPLOTHIS.BOM_SET_VERSION = 0;
        MTMPLOTHIS.BOM_ACTIVE_HIST_SEQ = 0;
        MTMPLOTHIS.BOM_HIST_SEQ = 0;
        memcpy(MTMPLOTHIS.SUBRES_ID, MWIPSLTHIS.SUBRES_ID, sizeof(MWIPSLTHIS.SUBRES_ID));

        MTMPLOTHIS.YIELD_1 = 0;
        MTMPLOTHIS.YIELD_2 = 0;
        MTMPLOTHIS.YIELD_3 = 0;
        if(MWIPSLTHIS.SUBLOT_DEL_FLAG != 'Y')
            MTMPLOTHIS.GOOD_QTY = 1;
        else
            MTMPLOTHIS.GOOD_QTY = 0;

        MTMPLOTHIS.FROM_TO_QTY_1 = 0;
        MTMPLOTHIS.FROM_TO_QTY_2 = 0;
        MTMPLOTHIS.FROM_TO_QTY_3 = 0;
        MTMPLOTHIS.FROM_TO_HIST_SEQ = 0;

        memcpy(MTMPLOTHIS.RESV_FIELD_1, MWIPSLTHIS.RESV_FIELD_1, sizeof(MWIPSLTHIS.RESV_FIELD_1));
        memcpy(MTMPLOTHIS.RESV_FIELD_2, MWIPSLTHIS.RESV_FIELD_2, sizeof(MWIPSLTHIS.RESV_FIELD_2));
        memcpy(MTMPLOTHIS.RESV_FIELD_3, MWIPSLTHIS.RESV_FIELD_3, sizeof(MWIPSLTHIS.RESV_FIELD_3));
        memcpy(MTMPLOTHIS.RESV_FIELD_4, MWIPSLTHIS.RESV_FIELD_4, sizeof(MWIPSLTHIS.RESV_FIELD_4));
        memcpy(MTMPLOTHIS.RESV_FIELD_5, MWIPSLTHIS.RESV_FIELD_5, sizeof(MWIPSLTHIS.RESV_FIELD_5));
        MTMPLOTHIS.RESV_FLAG_1 = MWIPSLTHIS.RESV_FLAG_1;
        MTMPLOTHIS.RESV_FLAG_2 = MWIPSLTHIS.RESV_FLAG_2;
        MTMPLOTHIS.RESV_FLAG_3 = MWIPSLTHIS.RESV_FLAG_3;
        MTMPLOTHIS.RESV_FLAG_4 = MWIPSLTHIS.RESV_FLAG_4;
        MTMPLOTHIS.RESV_FLAG_5 = MWIPSLTHIS.RESV_FLAG_5;

        memcpy(MTMPLOTHIS.OLD_TRAN_TIME, OLD_MWIPSLTHIS.TRAN_TIME, sizeof(OLD_MWIPSLTHIS.TRAN_TIME));
        memcpy(MTMPLOTHIS.OLD_SYS_TRAN_TIME, OLD_MWIPSLTHIS.SYS_TRAN_TIME, sizeof(OLD_MWIPSLTHIS.SYS_TRAN_TIME));
        memcpy(MTMPLOTHIS.OLD_TRAN_CODE, OLD_MWIPSLTHIS.TRAN_CODE, sizeof(OLD_MWIPSLTHIS.TRAN_CODE));
        memcpy(MTMPLOTHIS.OLD_FACTORY, MWIPSLTHIS.OLD_FACTORY, sizeof(MWIPSLTHIS.OLD_FACTORY));
        memcpy(MTMPLOTHIS.OLD_MAT_ID, MWIPSLTHIS.OLD_MAT_ID, sizeof(MWIPSLTHIS.OLD_MAT_ID));
        MTMPLOTHIS.OLD_MAT_VER = MWIPSLTHIS.OLD_MAT_VER;
        memcpy(MTMPLOTHIS.OLD_FLOW, MWIPSLTHIS.OLD_FLOW, sizeof(MWIPSLTHIS.OLD_FLOW));
        MTMPLOTHIS.OLD_FLOW_SEQ_NUM = MWIPSLTHIS.OLD_FLOW_SEQ_NUM;
        memcpy(MTMPLOTHIS.OLD_OPER, MWIPSLTHIS.OLD_OPER, sizeof(MWIPSLTHIS.OLD_OPER));
        MTMPLOTHIS.OLD_QTY_1 = 0;
        MTMPLOTHIS.OLD_QTY_2 = MWIPSLTHIS.OLD_QTY_2;
        MTMPLOTHIS.OLD_QTY_3 = MWIPSLTHIS.OLD_QTY_3;
        memcpy(MTMPLOTHIS.OLD_OWNER_CODE, MWIPSLTHIS.OLD_OWNER_CODE, sizeof(MWIPSLTHIS.OLD_OWNER_CODE));
        memcpy(MTMPLOTHIS.OLD_CREATE_CODE, MWIPSLTHIS.OLD_CREATE_CODE, sizeof(MWIPSLTHIS.OLD_CREATE_CODE));
        MTMPLOTHIS.OLD_RWK_FLAG = OLD_MWIPSLTHIS.RWK_FLAG;
        MTMPLOTHIS.OLD_START_FLAG = OLD_MWIPSLTHIS.START_FLAG;
        memcpy(MTMPLOTHIS.OLD_START_TIME, OLD_MWIPSLTHIS.START_TIME, sizeof(MWIPSLTHIS.START_TIME));
        MTMPLOTHIS.OLD_END_FLAG = OLD_MWIPSLTHIS.END_FLAG;
        memcpy(MTMPLOTHIS.OLD_FAC_IN_TIME, MWIPSLTHIS.OLD_FAC_IN_TIME, sizeof(MWIPSLTHIS.OLD_FAC_IN_TIME));
        memcpy(MTMPLOTHIS.OLD_FLOW_IN_TIME, MWIPSLTHIS.OLD_FLOW_IN_TIME, sizeof(MWIPSLTHIS.OLD_FLOW_IN_TIME));
        memcpy(MTMPLOTHIS.OLD_OPER_IN_TIME, MWIPSLTHIS.OLD_OPER_IN_TIME, sizeof(MWIPSLTHIS.OLD_OPER_IN_TIME));
        memcpy(MTMPLOTHIS.OLD_END_TIME, OLD_MWIPSLTHIS.END_TIME, sizeof(MWIPSLTHIS.END_TIME));
        memcpy(MTMPLOTHIS.TRAN_CMF_1, MWIPSLTHIS.TRAN_CMF_1, sizeof(MWIPSLTHIS.TRAN_CMF_1));
        memcpy(MTMPLOTHIS.TRAN_CMF_2, MWIPSLTHIS.TRAN_CMF_2, sizeof(MWIPSLTHIS.TRAN_CMF_2));
        memcpy(MTMPLOTHIS.TRAN_CMF_3, MWIPSLTHIS.TRAN_CMF_3, sizeof(MWIPSLTHIS.TRAN_CMF_3));
        memcpy(MTMPLOTHIS.TRAN_CMF_4, MWIPSLTHIS.TRAN_CMF_4, sizeof(MWIPSLTHIS.TRAN_CMF_4));
        memcpy(MTMPLOTHIS.TRAN_CMF_5, MWIPSLTHIS.TRAN_CMF_5, sizeof(MWIPSLTHIS.TRAN_CMF_5));
        memcpy(MTMPLOTHIS.TRAN_CMF_6, MWIPSLTHIS.TRAN_CMF_6, sizeof(MWIPSLTHIS.TRAN_CMF_6));
        memcpy(MTMPLOTHIS.TRAN_CMF_7, MWIPSLTHIS.TRAN_CMF_7, sizeof(MWIPSLTHIS.TRAN_CMF_7));
        memcpy(MTMPLOTHIS.TRAN_CMF_8, MWIPSLTHIS.TRAN_CMF_8, sizeof(MWIPSLTHIS.TRAN_CMF_8));
        memcpy(MTMPLOTHIS.TRAN_CMF_9, MWIPSLTHIS.TRAN_CMF_9, sizeof(MWIPSLTHIS.TRAN_CMF_9));
        memcpy(MTMPLOTHIS.TRAN_CMF_10, MWIPSLTHIS.TRAN_CMF_10, sizeof(MWIPSLTHIS.TRAN_CMF_10));
        memcpy(MTMPLOTHIS.TRAN_CMF_11, MWIPSLTHIS.TRAN_CMF_11, sizeof(MWIPSLTHIS.TRAN_CMF_11));
        memcpy(MTMPLOTHIS.TRAN_CMF_12, MWIPSLTHIS.TRAN_CMF_12, sizeof(MWIPSLTHIS.TRAN_CMF_12));
        memcpy(MTMPLOTHIS.TRAN_CMF_13, MWIPSLTHIS.TRAN_CMF_13, sizeof(MWIPSLTHIS.TRAN_CMF_13));
        memcpy(MTMPLOTHIS.TRAN_CMF_14, MWIPSLTHIS.TRAN_CMF_14, sizeof(MWIPSLTHIS.TRAN_CMF_14));
        memcpy(MTMPLOTHIS.TRAN_CMF_15, MWIPSLTHIS.TRAN_CMF_15, sizeof(MWIPSLTHIS.TRAN_CMF_15));
        memcpy(MTMPLOTHIS.TRAN_CMF_16, MWIPSLTHIS.TRAN_CMF_16, sizeof(MWIPSLTHIS.TRAN_CMF_16));
        memcpy(MTMPLOTHIS.TRAN_CMF_17, MWIPSLTHIS.TRAN_CMF_17, sizeof(MWIPSLTHIS.TRAN_CMF_17));
        memcpy(MTMPLOTHIS.TRAN_CMF_18, MWIPSLTHIS.TRAN_CMF_18, sizeof(MWIPSLTHIS.TRAN_CMF_18));
        memcpy(MTMPLOTHIS.TRAN_CMF_19, MWIPSLTHIS.TRAN_CMF_19, sizeof(MWIPSLTHIS.TRAN_CMF_19));
        memcpy(MTMPLOTHIS.TRAN_CMF_20, MWIPSLTHIS.TRAN_CMF_20, sizeof(MWIPSLTHIS.TRAN_CMF_20));
        memcpy(MTMPLOTHIS.TRAN_USER_ID, MWIPSLTHIS.TRAN_USER_ID, sizeof(MWIPSLTHIS.TRAN_USER_ID));
        memcpy(MTMPLOTHIS.TRAN_COMMENT, MWIPSLTHIS.TRAN_COMMENT, sizeof(MWIPSLTHIS.TRAN_COMMENT));
        MTMPLOTHIS.PREV_ACTIVE_HIST_SEQ = MWIPSLTHIS.PREV_ACTIVE_HIST_SEQ;
        memcpy(MTMPLOTHIS.MULTI_TR_KEY, MWIPSLTHIS.MULTI_TR_KEY, sizeof(MWIPSLTHIS.MULTI_TR_KEY));
        MTMPLOTHIS.MULTI_TR_SEQ = MWIPSLTHIS.MULTI_TR_SEQ;
        MTMPLOTHIS.EXT_HIST_SEQ = MWIPSLTHIS.EXT_HIST_SEQ;
        MTMPLOTHIS.HIST_DEL_FLAG = TRS.get_char(in_node, "HIST_DEL_FLAG");
        if(MTMPLOTHIS.HIST_DEL_FLAG == 'Y')
        {
            TRS.copy(MTMPLOTHIS.HIST_DEL_TIME, sizeof(MWIPSLTHIS.HIST_DEL_TIME), in_node, "HIST_DEL_TIME");
            TRS.copy(MTMPLOTHIS.HIST_DEL_USER_ID, sizeof(MWIPSLTHIS.HIST_DEL_USER_ID), in_node, "HIST_DEL_USER_ID");
        }
        memcpy(MTMPLOTHIS.HIST_DEL_COMMENT, MWIPSLTHIS.HIST_DEL_COMMENT, sizeof(MWIPSLTHIS.HIST_DEL_COMMENT));

        DBC_insert_mtmplothis(&MTMPLOTHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTMPLOTHIS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSLTHIS.FACTORY), MWIPSLTHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTHIS.LOT_ID), MWIPSLTHIS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(TRS.mem_cmp(in_node, "TRAN_CODE", MP_TRAN_CODE_SPLIT, strlen(MP_TRAN_CODE_SPLIT)) == 0 ||
                TRS.mem_cmp(in_node, "TRAN_CODE", MP_TRAN_CODE_MERGE, strlen(MP_TRAN_CODE_MERGE)) == 0 ||
                TRS.mem_cmp(in_node, "TRAN_CODE", MP_TRAN_CODE_COMBINE, strlen(MP_TRAN_CODE_COMBINE)) == 0) 
        {
            DBC_init_mwipslthis(&MWIPSLTHIS);
            TRS.copy(MWIPSLTHIS.LOT_ID, sizeof(MWIPSLTHIS.LOT_ID), in_node, "FROM_TO_LOT_ID");
            MWIPSLTHIS.HIST_SEQ = TRS.get_int(in_node, "FROM_TO_HIST_SEQ");
            DBC_select_mwipslthis(1, &MWIPSLTHIS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0260");
                TRS.add_fieldmsg(out_node, "MWIPSLTHIS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTHIS.LOT_ID), MWIPSLTHIS.LOT_ID);
                TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MWIPSLTHIS.HIST_SEQ);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_COMMON;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            DBC_init_mwipslthis(&OLD_MWIPSLTHIS);
            if(TRS.get_int(in_node, "FROM_TO_HIST_SEQ") > 1)
            {
                TRS.copy(OLD_MWIPSLTHIS.LOT_ID, sizeof(OLD_MWIPSLTHIS.LOT_ID), in_node, "FROM_TO_LOT_ID");
                OLD_MWIPSLTHIS.HIST_SEQ = MWIPSLTHIS.PREV_ACTIVE_HIST_SEQ;
                DBC_select_mwipslthis(1, &OLD_MWIPSLTHIS);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0260");
                    TRS.add_fieldmsg(out_node, "MWIPSLTHIS SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTHIS.LOT_ID), MWIPSLTHIS.LOT_ID);
                    TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MWIPSLTHIS.HIST_SEQ);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    gs_log_type.category = MP_LOG_CATE_COMMON;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }

            DBC_init_mtmplothis(&MTMPLOTHIS);

            MTMPLOTHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmplothis_scalar(2, &MTMPLOTHIS);
            memcpy(MTMPLOTHIS.LOT_ID, MWIPSLTHIS.LOT_ID, sizeof(MWIPSLTHIS.LOT_ID));
            MTMPLOTHIS.HIST_SEQ = MWIPSLTHIS.HIST_SEQ;
            memcpy(MTMPLOTHIS.TRAN_TIME, MWIPSLTHIS.TRAN_TIME, sizeof(MWIPSLTHIS.TRAN_TIME));
            memcpy(MTMPLOTHIS.SYS_TRAN_TIME, MWIPSLTHIS.SYS_TRAN_TIME, sizeof(MWIPSLTHIS.SYS_TRAN_TIME));
            memcpy(MTMPLOTHIS.TRAN_CODE, MWIPSLTHIS.TRAN_CODE, sizeof(MWIPSLTHIS.TRAN_CODE));
            memcpy(MTMPLOTHIS.FACTORY, MWIPSLTHIS.FACTORY, sizeof(MWIPSLTHIS.FACTORY));
            if(MGCMTBLDAT.DATA_1[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.MAT_ID, MWIPSLTHIS.MAT_ID, sizeof(MWIPSLTHIS.MAT_ID));
            }
            if(MGCMTBLDAT.DATA_2[0] == 'Y')
            {
                MTMPLOTHIS.MAT_VER = MWIPSLTHIS.MAT_VER;
            }
            if(MGCMTBLDAT.DATA_3[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.FLOW, MWIPSLTHIS.FLOW, sizeof(MWIPSLTHIS.FLOW));
            }
            if(MGCMTBLDAT.DATA_4[0] == 'Y')
            {
                MTMPLOTHIS.FLOW_SEQ_NUM = MWIPSLTHIS.FLOW_SEQ_NUM;
            }
            if(MGCMTBLDAT.DATA_5[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.OPER, MWIPSLTHIS.OPER, sizeof(MWIPSLTHIS.OPER));
            }
            if(MGCMTBLDAT.DATA_8[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.START_RES_ID, MWIPSLTHIS.START_RES_ID, sizeof(MWIPSLTHIS.START_RES_ID));
                memcpy(MTMPLOTHIS.END_RES_ID, MWIPSLTHIS.END_RES_ID, sizeof(MWIPSLTHIS.END_RES_ID));
                memcpy(MTMPLOTHIS.OLD_START_RES_ID, OLD_MWIPSLTHIS.START_RES_ID, sizeof(MWIPSLTHIS.START_RES_ID));
                memcpy(MTMPLOTHIS.OLD_END_RES_ID, OLD_MWIPSLTHIS.END_RES_ID, sizeof(MWIPSLTHIS.END_RES_ID));
            }
            /* Additional Field CM_KEY_1 ~ 5 */
            if(MGCMTBLDAT.DATA_9[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_1, MWIPSLTHIS.SUBLOT_CMF_1, sizeof(MWIPSLTHIS.SUBLOT_CMF_1));    
            }
            if(MGCMTBLDAT.DATA_9[1] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_2, MWIPSLTHIS.SUBLOT_CMF_2, sizeof(MWIPSLTHIS.SUBLOT_CMF_2));    
            }
            if(MGCMTBLDAT.DATA_9[2] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_3, MWIPSLTHIS.SUBLOT_CMF_3, sizeof(MWIPSLTHIS.SUBLOT_CMF_3));    
            }
            if(MGCMTBLDAT.DATA_9[3] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_4, MWIPSLTHIS.SUBLOT_CMF_4, sizeof(MWIPSLTHIS.SUBLOT_CMF_4));    
            }
            if(MGCMTBLDAT.DATA_9[4] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_5, MWIPSLTHIS.SUBLOT_CMF_5, sizeof(MWIPSLTHIS.SUBLOT_CMF_5));    
            }
            MTMPLOTHIS.QTY_1 = 0;
            MTMPLOTHIS.QTY_2 = MWIPSLTHIS.QTY_2;
            MTMPLOTHIS.QTY_3 = MWIPSLTHIS.QTY_3;
            memcpy(MTMPLOTHIS.CRR_ID, MWIPSLTHIS.CRR_ID, sizeof(MWIPSLTHIS.CRR_ID));
            memcpy(MTMPLOTHIS.OWNER_CODE, MWIPSLTHIS.OWNER_CODE, sizeof(MWIPSLTHIS.OWNER_CODE));
            memcpy(MTMPLOTHIS.CREATE_CODE, MWIPSLTHIS.CREATE_CODE, sizeof(MWIPSLTHIS.CREATE_CODE));
            MTMPLOTHIS.HOLD_FLAG = MWIPSLTHIS.HOLD_FLAG;
            memcpy(MTMPLOTHIS.HOLD_CODE, MWIPSLTHIS.HOLD_CODE, sizeof(MWIPSLTHIS.HOLD_CODE));
            memcpy(MTMPLOTHIS.HOLD_PASSWORD, MWIPSLTHIS.HOLD_PASSWORD, sizeof(MWIPSLTHIS.HOLD_PASSWORD));
            memcpy(MTMPLOTHIS.HOLD_PRV_GRP_ID, MWIPSLTHIS.HOLD_PRV_GRP_ID, sizeof(MWIPSLTHIS.HOLD_PRV_GRP_ID));
            MTMPLOTHIS.OPER_IN_QTY_1 = 0;
            MTMPLOTHIS.OPER_IN_QTY_2 = MWIPSLTHIS.OPER_IN_QTY_2;
            MTMPLOTHIS.OPER_IN_QTY_3 = MWIPSLTHIS.OPER_IN_QTY_3;
            MTMPLOTHIS.CREATE_QTY_1 = 0;
            MTMPLOTHIS.CREATE_QTY_2 = MWIPSLTHIS.CREATE_QTY_2;
            MTMPLOTHIS.CREATE_QTY_3 = MWIPSLTHIS.CREATE_QTY_3;
            MTMPLOTHIS.START_QTY_1 = 0;
            MTMPLOTHIS.START_QTY_2 = MWIPSLTHIS.START_QTY_2;
            MTMPLOTHIS.START_QTY_3 = MWIPSLTHIS.START_QTY_3;
            MTMPLOTHIS.INV_FLAG = MWIPSLTHIS.INV_FLAG;
            MTMPLOTHIS.TRANSIT_FLAG = MWIPSLTHIS.TRANSIT_FLAG;
            MTMPLOTHIS.UNIT_EXIST_FLAG = MWIPSLTHIS.UNIT_EXIST_FLAG;
            memcpy(MTMPLOTHIS.INV_UNIT, MWIPSLTHIS.INV_UNIT, sizeof(MWIPSLTHIS.INV_UNIT));
            MTMPLOTHIS.RWK_FLAG = MWIPSLTHIS.RWK_FLAG;
            memcpy(MTMPLOTHIS.RWK_CODE, MWIPSLTHIS.RWK_CODE, sizeof(MWIPSLTHIS.RWK_CODE));
            MTMPLOTHIS.RWK_COUNT = MWIPSLTHIS.RWK_COUNT;
            memcpy(MTMPLOTHIS.RWK_RET_FLOW, MWIPSLTHIS.RWK_RET_FLOW, sizeof(MWIPSLTHIS.RWK_RET_FLOW));
            MTMPLOTHIS.RWK_RET_FLOW_SEQ_NUM = MWIPSLTHIS.RWK_RET_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.RWK_RET_OPER, MWIPSLTHIS.RWK_RET_OPER, sizeof(MWIPSLTHIS.RWK_RET_OPER));
            memcpy(MTMPLOTHIS.RWK_END_FLOW, MWIPSLTHIS.RWK_END_FLOW, sizeof(MWIPSLTHIS.RWK_END_FLOW));
            MTMPLOTHIS.RWK_END_FLOW_SEQ_NUM = MWIPSLTHIS.RWK_END_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.RWK_END_OPER, MWIPSLTHIS.RWK_END_OPER, sizeof(MWIPSLTHIS.RWK_END_OPER));
            MTMPLOTHIS.RWK_RET_CLEAR_FLAG = MWIPSLTHIS.RWK_RET_CLEAR_FLAG;
            memcpy(MTMPLOTHIS.RWK_TIME, MWIPSLTHIS.RWK_TIME, sizeof(MWIPSLTHIS.RWK_TIME));
            MTMPLOTHIS.NSTD_FLAG = MWIPSLTHIS.NSTD_FLAG;
            memcpy(MTMPLOTHIS.NSTD_RET_FLOW, MWIPSLTHIS.NSTD_RET_FLOW, sizeof(MWIPSLTHIS.NSTD_RET_FLOW));
            MTMPLOTHIS.NSTD_RET_FLOW_SEQ_NUM = MWIPSLTHIS.NSTD_RET_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.NSTD_RET_OPER, MWIPSLTHIS.NSTD_RET_OPER, sizeof(MWIPSLTHIS.NSTD_RET_OPER));
            memcpy(MTMPLOTHIS.NSTD_TIME, MWIPSLTHIS.NSTD_TIME, sizeof(MWIPSLTHIS.NSTD_TIME));
            MTMPLOTHIS.REP_FLAG = MWIPSLTHIS.REP_FLAG;
            memcpy(MTMPLOTHIS.REP_RET_OPER, MWIPSLTHIS.REP_RET_OPER, sizeof(MWIPSLTHIS.REP_RET_OPER));

            memcpy(MTMPLOTHIS.STR_RET_FLOW, MWIPSLTHIS.STR_RET_FLOW, sizeof(MWIPSLTHIS.STR_RET_FLOW));
            MTMPLOTHIS.STR_RET_FLOW_SEQ_NUM = MWIPSLTHIS.STR_RET_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.STR_RET_OPER, MWIPSLTHIS.STR_RET_OPER, sizeof(MWIPSLTHIS.STR_RET_OPER));

            MTMPLOTHIS.START_FLAG = MWIPSLTHIS.START_FLAG;
            memcpy(MTMPLOTHIS.START_TIME, MWIPSLTHIS.START_TIME, sizeof(MWIPSLTHIS.START_TIME));
            MTMPLOTHIS.END_FLAG = MWIPSLTHIS.END_FLAG;
            memcpy(MTMPLOTHIS.END_TIME, MWIPSLTHIS.END_TIME, sizeof(MWIPSLTHIS.END_TIME));
            MTMPLOTHIS.SAMPLE_FLAG = MWIPSLTHIS.SAMPLE_FLAG;
            MTMPLOTHIS.SAMPLE_WAIT_FLAG = MWIPSLTHIS.SAMPLE_WAIT_FLAG;
            MTMPLOTHIS.SAMPLE_RESULT = MWIPSLTHIS.SAMPLE_RESULT;
            memcpy(MTMPLOTHIS.RESERVE_RES_ID, MWIPSLTHIS.RESERVE_RES_ID, sizeof(MWIPSLTHIS.RESERVE_RES_ID));
            memcpy(MTMPLOTHIS.PORT_ID, MWIPSLTHIS.PORT_ID, sizeof(MWIPSLTHIS.PORT_ID));
            MTMPLOTHIS.BATCH_SEQ = 0;
            memcpy(MTMPLOTHIS.LOT_CMF_1, MWIPSLTHIS.SUBLOT_CMF_1, sizeof(MWIPSLTHIS.SUBLOT_CMF_1));
            memcpy(MTMPLOTHIS.LOT_CMF_2, MWIPSLTHIS.SUBLOT_CMF_2, sizeof(MWIPSLTHIS.SUBLOT_CMF_2));
            memcpy(MTMPLOTHIS.LOT_CMF_3, MWIPSLTHIS.SUBLOT_CMF_3, sizeof(MWIPSLTHIS.SUBLOT_CMF_3));
            memcpy(MTMPLOTHIS.LOT_CMF_4, MWIPSLTHIS.SUBLOT_CMF_4, sizeof(MWIPSLTHIS.SUBLOT_CMF_4));
            memcpy(MTMPLOTHIS.LOT_CMF_5, MWIPSLTHIS.SUBLOT_CMF_5, sizeof(MWIPSLTHIS.SUBLOT_CMF_5));
            memcpy(MTMPLOTHIS.LOT_CMF_6, MWIPSLTHIS.SUBLOT_CMF_6, sizeof(MWIPSLTHIS.SUBLOT_CMF_6));
            memcpy(MTMPLOTHIS.LOT_CMF_7, MWIPSLTHIS.SUBLOT_CMF_7, sizeof(MWIPSLTHIS.SUBLOT_CMF_7));
            memcpy(MTMPLOTHIS.LOT_CMF_8, MWIPSLTHIS.SUBLOT_CMF_8, sizeof(MWIPSLTHIS.SUBLOT_CMF_8));
            memcpy(MTMPLOTHIS.LOT_CMF_9, MWIPSLTHIS.SUBLOT_CMF_9, sizeof(MWIPSLTHIS.SUBLOT_CMF_9));
            memcpy(MTMPLOTHIS.LOT_CMF_10, MWIPSLTHIS.SUBLOT_CMF_10, sizeof(MWIPSLTHIS.SUBLOT_CMF_10));
            memcpy(MTMPLOTHIS.LOT_CMF_11, MWIPSLTHIS.SUBLOT_CMF_11, sizeof(MWIPSLTHIS.SUBLOT_CMF_11));
            memcpy(MTMPLOTHIS.LOT_CMF_12, MWIPSLTHIS.SUBLOT_CMF_12, sizeof(MWIPSLTHIS.SUBLOT_CMF_12));
            memcpy(MTMPLOTHIS.LOT_CMF_13, MWIPSLTHIS.SUBLOT_CMF_13, sizeof(MWIPSLTHIS.SUBLOT_CMF_13));
            memcpy(MTMPLOTHIS.LOT_CMF_14, MWIPSLTHIS.SUBLOT_CMF_14, sizeof(MWIPSLTHIS.SUBLOT_CMF_14));
            memcpy(MTMPLOTHIS.LOT_CMF_15, MWIPSLTHIS.SUBLOT_CMF_15, sizeof(MWIPSLTHIS.SUBLOT_CMF_15));
            memcpy(MTMPLOTHIS.LOT_CMF_16, MWIPSLTHIS.SUBLOT_CMF_16, sizeof(MWIPSLTHIS.SUBLOT_CMF_16));
            memcpy(MTMPLOTHIS.LOT_CMF_17, MWIPSLTHIS.SUBLOT_CMF_17, sizeof(MWIPSLTHIS.SUBLOT_CMF_17));
            memcpy(MTMPLOTHIS.LOT_CMF_18, MWIPSLTHIS.SUBLOT_CMF_18, sizeof(MWIPSLTHIS.SUBLOT_CMF_18));
            memcpy(MTMPLOTHIS.LOT_CMF_19, MWIPSLTHIS.SUBLOT_CMF_19, sizeof(MWIPSLTHIS.SUBLOT_CMF_19));
            memcpy(MTMPLOTHIS.LOT_CMF_20, MWIPSLTHIS.SUBLOT_CMF_20, sizeof(MWIPSLTHIS.SUBLOT_CMF_20));
            MTMPLOTHIS.LOT_DEL_FLAG = MWIPSLTHIS.SUBLOT_DEL_FLAG;
            memcpy(MTMPLOTHIS.LOT_DEL_CODE, MWIPSLTHIS.SUBLOT_DEL_CODE, sizeof(MWIPSLTHIS.SUBLOT_DEL_CODE));
            memcpy(MTMPLOTHIS.LOT_DEL_TIME, MWIPSLTHIS.SUBLOT_DEL_TIME, sizeof(MWIPSLTHIS.SUBLOT_DEL_TIME));
            MTMPLOTHIS.BOM_SET_VERSION = 0;
            MTMPLOTHIS.BOM_ACTIVE_HIST_SEQ = 0;
            MTMPLOTHIS.BOM_HIST_SEQ = 0;
            memcpy(MTMPLOTHIS.SUBRES_ID, MWIPSLTHIS.SUBRES_ID, sizeof(MWIPSLTHIS.SUBRES_ID));

            MTMPLOTHIS.YIELD_1 = 0;
            MTMPLOTHIS.YIELD_2 = 0;
            MTMPLOTHIS.YIELD_3 = 0;
            if(MWIPSLTHIS.SUBLOT_DEL_FLAG != 'Y')
                MTMPLOTHIS.GOOD_QTY = 1;
            else
                MTMPLOTHIS.GOOD_QTY = 0;

            MTMPLOTHIS.FROM_TO_MAT_VER = 0;
            MTMPLOTHIS.FROM_TO_FLOW_SEQ_NUM = 0;
            MTMPLOTHIS.FROM_TO_QTY_1 = 0;
            MTMPLOTHIS.FROM_TO_QTY_2 = 0;
            MTMPLOTHIS.FROM_TO_QTY_3 = 0;
            MTMPLOTHIS.FROM_TO_HIST_SEQ = 0;
            memcpy(MTMPLOTHIS.OLD_TRAN_TIME, OLD_MWIPSLTHIS.TRAN_TIME, sizeof(OLD_MWIPSLTHIS.TRAN_TIME));
            memcpy(MTMPLOTHIS.OLD_SYS_TRAN_TIME, OLD_MWIPSLTHIS.SYS_TRAN_TIME, sizeof(OLD_MWIPSLTHIS.SYS_TRAN_TIME));
            memcpy(MTMPLOTHIS.OLD_TRAN_CODE, OLD_MWIPSLTHIS.TRAN_CODE, sizeof(OLD_MWIPSLTHIS.TRAN_CODE));
            memcpy(MTMPLOTHIS.OLD_FACTORY, MWIPSLTHIS.OLD_FACTORY, sizeof(MWIPSLTHIS.OLD_FACTORY));
            memcpy(MTMPLOTHIS.OLD_MAT_ID, MWIPSLTHIS.OLD_MAT_ID, sizeof(MWIPSLTHIS.OLD_MAT_ID));
            MTMPLOTHIS.OLD_MAT_VER = MWIPSLTHIS.OLD_MAT_VER;
            memcpy(MTMPLOTHIS.OLD_FLOW, MWIPSLTHIS.OLD_FLOW, sizeof(MWIPSLTHIS.OLD_FLOW));
            MTMPLOTHIS.OLD_FLOW_SEQ_NUM = MWIPSLTHIS.OLD_FLOW_SEQ_NUM;
            memcpy(MTMPLOTHIS.OLD_OPER, MWIPSLTHIS.OLD_OPER, sizeof(MWIPSLTHIS.OLD_OPER));
            MTMPLOTHIS.OLD_QTY_1 = 0;
            MTMPLOTHIS.OLD_QTY_2 = MWIPSLTHIS.OLD_QTY_2;
            MTMPLOTHIS.OLD_QTY_3 = MWIPSLTHIS.OLD_QTY_3;
            memcpy(MTMPLOTHIS.OLD_OWNER_CODE, MWIPSLTHIS.OLD_OWNER_CODE, sizeof(MWIPSLTHIS.OLD_OWNER_CODE));
            memcpy(MTMPLOTHIS.OLD_CREATE_CODE, MWIPSLTHIS.OLD_CREATE_CODE, sizeof(MWIPSLTHIS.OLD_CREATE_CODE));
            MTMPLOTHIS.OLD_RWK_FLAG = OLD_MWIPSLTHIS.RWK_FLAG;
            MTMPLOTHIS.OLD_START_FLAG = OLD_MWIPSLTHIS.START_FLAG;
            memcpy(MTMPLOTHIS.OLD_START_TIME, OLD_MWIPSLTHIS.START_TIME, sizeof(MWIPSLTHIS.START_TIME));
            MTMPLOTHIS.OLD_END_FLAG = OLD_MWIPSLTHIS.END_FLAG;
            memcpy(MTMPLOTHIS.OLD_END_TIME, OLD_MWIPSLTHIS.END_TIME, sizeof(MWIPSLTHIS.END_TIME));
                    /* Additional Field CM_KEY_1 ~ 5 */
            if(MGCMTBLDAT.DATA_9[0] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_1, OLD_MWIPSLTHIS.SUBLOT_CMF_1, sizeof(OLD_MWIPSLTHIS.SUBLOT_CMF_1));    
            }
            if(MGCMTBLDAT.DATA_9[1] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_2, OLD_MWIPSLTHIS.SUBLOT_CMF_2, sizeof(OLD_MWIPSLTHIS.SUBLOT_CMF_2));    
            }
            if(MGCMTBLDAT.DATA_9[2] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_3, OLD_MWIPSLTHIS.SUBLOT_CMF_3, sizeof(OLD_MWIPSLTHIS.SUBLOT_CMF_3));    
            }
            if(MGCMTBLDAT.DATA_9[3] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_4, OLD_MWIPSLTHIS.SUBLOT_CMF_4, sizeof(OLD_MWIPSLTHIS.SUBLOT_CMF_4));    
            }
            if(MGCMTBLDAT.DATA_9[4] == 'Y')
            {
                memcpy(MTMPLOTHIS.CM_KEY_5, OLD_MWIPSLTHIS.SUBLOT_CMF_5, sizeof(OLD_MWIPSLTHIS.SUBLOT_CMF_5));    
            }
            memcpy(MTMPLOTHIS.TRAN_CMF_1, MWIPSLTHIS.TRAN_CMF_1, sizeof(MWIPSLTHIS.TRAN_CMF_1));
            memcpy(MTMPLOTHIS.TRAN_CMF_2, MWIPSLTHIS.TRAN_CMF_2, sizeof(MWIPSLTHIS.TRAN_CMF_2));
            memcpy(MTMPLOTHIS.TRAN_CMF_3, MWIPSLTHIS.TRAN_CMF_3, sizeof(MWIPSLTHIS.TRAN_CMF_3));
            memcpy(MTMPLOTHIS.TRAN_CMF_4, MWIPSLTHIS.TRAN_CMF_4, sizeof(MWIPSLTHIS.TRAN_CMF_4));
            memcpy(MTMPLOTHIS.TRAN_CMF_5, MWIPSLTHIS.TRAN_CMF_5, sizeof(MWIPSLTHIS.TRAN_CMF_5));
            memcpy(MTMPLOTHIS.TRAN_CMF_6, MWIPSLTHIS.TRAN_CMF_6, sizeof(MWIPSLTHIS.TRAN_CMF_6));
            memcpy(MTMPLOTHIS.TRAN_CMF_7, MWIPSLTHIS.TRAN_CMF_7, sizeof(MWIPSLTHIS.TRAN_CMF_7));
            memcpy(MTMPLOTHIS.TRAN_CMF_8, MWIPSLTHIS.TRAN_CMF_8, sizeof(MWIPSLTHIS.TRAN_CMF_8));
            memcpy(MTMPLOTHIS.TRAN_CMF_9, MWIPSLTHIS.TRAN_CMF_9, sizeof(MWIPSLTHIS.TRAN_CMF_9));
            memcpy(MTMPLOTHIS.TRAN_CMF_10, MWIPSLTHIS.TRAN_CMF_10, sizeof(MWIPSLTHIS.TRAN_CMF_10));
            memcpy(MTMPLOTHIS.TRAN_CMF_11, MWIPSLTHIS.TRAN_CMF_11, sizeof(MWIPSLTHIS.TRAN_CMF_11));
            memcpy(MTMPLOTHIS.TRAN_CMF_12, MWIPSLTHIS.TRAN_CMF_12, sizeof(MWIPSLTHIS.TRAN_CMF_12));
            memcpy(MTMPLOTHIS.TRAN_CMF_13, MWIPSLTHIS.TRAN_CMF_13, sizeof(MWIPSLTHIS.TRAN_CMF_13));
            memcpy(MTMPLOTHIS.TRAN_CMF_14, MWIPSLTHIS.TRAN_CMF_14, sizeof(MWIPSLTHIS.TRAN_CMF_14));
            memcpy(MTMPLOTHIS.TRAN_CMF_15, MWIPSLTHIS.TRAN_CMF_15, sizeof(MWIPSLTHIS.TRAN_CMF_15));
            memcpy(MTMPLOTHIS.TRAN_CMF_16, MWIPSLTHIS.TRAN_CMF_16, sizeof(MWIPSLTHIS.TRAN_CMF_16));
            memcpy(MTMPLOTHIS.TRAN_CMF_17, MWIPSLTHIS.TRAN_CMF_17, sizeof(MWIPSLTHIS.TRAN_CMF_17));
            memcpy(MTMPLOTHIS.TRAN_CMF_18, MWIPSLTHIS.TRAN_CMF_18, sizeof(MWIPSLTHIS.TRAN_CMF_18));
            memcpy(MTMPLOTHIS.TRAN_CMF_19, MWIPSLTHIS.TRAN_CMF_19, sizeof(MWIPSLTHIS.TRAN_CMF_19));
            memcpy(MTMPLOTHIS.TRAN_CMF_20, MWIPSLTHIS.TRAN_CMF_20, sizeof(MWIPSLTHIS.TRAN_CMF_20));
            memcpy(MTMPLOTHIS.TRAN_USER_ID, MWIPSLTHIS.TRAN_USER_ID, sizeof(MWIPSLTHIS.TRAN_USER_ID));
            memcpy(MTMPLOTHIS.TRAN_COMMENT, MWIPSLTHIS.TRAN_COMMENT, sizeof(MWIPSLTHIS.TRAN_COMMENT));
            MTMPLOTHIS.PREV_ACTIVE_HIST_SEQ = MWIPSLTHIS.PREV_ACTIVE_HIST_SEQ;
            memcpy(MTMPLOTHIS.MULTI_TR_KEY, MWIPSLTHIS.MULTI_TR_KEY, sizeof(MWIPSLTHIS.MULTI_TR_KEY));
            MTMPLOTHIS.MULTI_TR_SEQ = MWIPSLTHIS.MULTI_TR_SEQ;
            MTMPLOTHIS.EXT_HIST_SEQ = MWIPSLTHIS.EXT_HIST_SEQ;
            MTMPLOTHIS.HIST_DEL_FLAG = TRS.get_char(in_node, "HIST_DEL_FLAG");
            if(MTMPLOTHIS.HIST_DEL_FLAG == 'Y')
            {
                TRS.copy(MTMPLOTHIS.HIST_DEL_TIME, sizeof(MWIPSLTHIS.HIST_DEL_TIME), in_node, "HIST_DEL_TIME");
                TRS.copy(MTMPLOTHIS.HIST_DEL_USER_ID, sizeof(MWIPSLTHIS.HIST_DEL_USER_ID), in_node, "HIST_DEL_USER_ID");
            }
            memcpy(MTMPLOTHIS.HIST_DEL_COMMENT, MWIPSLTHIS.HIST_DEL_COMMENT, sizeof(MWIPSLTHIS.HIST_DEL_COMMENT));

            DBC_insert_mtmplothis(&MTMPLOTHIS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MTMPLOTHIS INSERT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSLTHIS.FACTORY), MWIPSLTHIS.FACTORY);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPSLTHIS.LOT_ID), MWIPSLTHIS.LOT_ID);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_TRANS;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

        }
    }


    /* 
        End - Make Data for Standard WIP Loader
        This section could be modify for each site
    */

    return MP_TRUE;
}
