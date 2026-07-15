/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_batch_ctm_n_trace.c
    Description : CTM and lot tracking data processing batch

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Batch_CTM_N_Trace()
            + Create/Update/Delete Entry definition
        - CWIP_BATCH_CTM_N_TRACE()
            + Main sub function of CWIP_Update_Entry_List function
            + Create/Update/Delete Entry definition

    Detail Description

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-12-08             HN.Lee

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_BATCH_CTM_N_TRACE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
    CWIP_Batch_CTM_N_Trace()
        - Create/Update/Delete Entry definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Batch_CTM_N_Trace(TRSNode* in_node, TRSNode* out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

  //  i_ret = CWIP_BATCH_CTM_N_TRACE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Batch_CTM_N_Trace", out_node);

    if (i_ret == MP_TRUE)
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
    CWIP_BATCH_CTM_N_TRACE()
        - Main sub function of "CWIP_Batch_CTM_N_Trace" function
        - Create/Update/Delete Entry definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_BATCH_CTM_N_TRACE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
    struct CWIPCTMTRC_TAG CWIPCTMTRC;
    struct CWIPLOTINV_TAG CWIPLOTINV;  // 자재 추적성
    struct RSUMMDLNCL_TAG RSUMMDLNCL;  // CTM용 집계

    int iCnt = 0;

    LOG_head("CWIP_BATCH_CTM_N_TRACE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    // RPT DB Procedure로 로직 이동
    // 2023-12-15

    CDB_init_cwipctmtrc(&CWIPCTMTRC);

    CDB_open_cwipctmtrc(1, &CWIPCTMTRC);
    if(DB_error_code != DB_SUCCESS)
    {
        LOG_head("CWIPCTMTRC Open 1 Error");
        LOG_add("MSG_CODE", MP_NSTR, "WIP-0004");
        LOG_add("DB_ERROR_MSG", MP_NSTR, DB_error_msg);

        COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        return MP_FALSE;
    }

    while(1)
    {
        DB_init_condition(&DBC_Q_COND);        

        CDB_fetch_cwipctmtrc(1, &CWIPCTMTRC);
        if (DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipctmtrc(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            LOG_head("CWIPCTMTRC Fetch 1 Error");
            LOG_add("MSG_CODE", MP_NSTR, "WIP-0004");
            LOG_add("DB_ERROR_MSG", MP_NSTR, DB_error_msg);

            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

            //strcpy(s_msg_code, "WIP-0004");
            //TRS.add_dberrmsg(out_node, DB_error_msg);

            //gs_log_type.type = MP_LOG_ERROR;
            //gs_log_type.e_type = MP_LOG_E_SYSTEM;
            //gs_log_type.category = MP_LOG_CATE_SETUP;

            //COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

            //return MP_FALSE;
        }

        // Eagle 1
        if(memcmp(DBC_Q_COND_N.KEY_2, "E1", 2) == 0)
        {

        }
        // Eagle 2
        else if (memcmp(DBC_Q_COND_N.KEY_2, "E2", 2) == 0)
        {
            CDB_init_cwiplotinv(&CWIPLOTINV);
            memcpy(CWIPLOTINV.FACTORY, CWIPCTMTRC.FACTORY, sizeof(CWIPLOTINV.FACTORY));
            memcpy(CWIPLOTINV.MODULE_ID, CWIPCTMTRC.LOT_ID, sizeof(CWIPLOTINV.MODULE_ID));

            // Half finished Goods
            if (memcmp(CWIPCTMTRC.KIND, "TRACE", strlen("TRACE")) == 0)
            {
                if (CWIPCTMTRC.WIP_FLAG == 'W')
                {
                    // Module - String - Cell - VMagazine - CellBox 구성
                    // 2회 이상 전송되는 것을 대비해서 먼저 삭제 후 저장
                    CWIPLOTINV.RAW_FLAG = ' ';
                    CDB_delete_cwiplotinv(2, &CWIPLOTINV);

                    CWIPLOTINV.OFF_SET = 0; // CWIPCTMHIS.OFF_SET;

                    // Module
                    CDB_insert_cwiplotinv(2, &CWIPLOTINV);

                    // Module - String
                    CDB_insert_cwiplotinv(3, &CWIPLOTINV);

                    // String - Cell
                    CDB_insert_cwiplotinv(4, &CWIPLOTINV);

                    // Cell - Virtual Magazine
                    CDB_insert_cwiplotinv(5, &CWIPLOTINV);

                    // Virtual Magazine - Cell Box
                    CDB_insert_cwiplotinv(6, &CWIPLOTINV);
                }
                else if(CWIPCTMTRC.WIP_FLAG == 'R')
                {
                    memcpy(CWIPLOTINV.INV_LOT_ID, CWIPCTMTRC.INV_LOT_ID, sizeof(CWIPLOTINV.INV_LOT_ID));
                    CWIPLOTINV.RAW_FLAG = 'Y';
                    CDB_delete_cwiplotinv(3, &CWIPLOTINV);

                    // Used Material
                    CDB_insert_cwiplotinv(10, &CWIPLOTINV);
                }
            }
            else if(memcmp(CWIPCTMTRC.KIND, "CTM", strlen("CTM")) == 0)
            {
                // CTM 용 집계
                CDB_init_rsummdlncl(&RSUMMDLNCL);
                memcpy(RSUMMDLNCL.FACTORY, CWIPCTMTRC.FACTORY, sizeof(RSUMMDLNCL.FACTORY));
                memcpy(RSUMMDLNCL.MODULE_ID, CWIPCTMTRC.LOT_ID, sizeof(RSUMMDLNCL.MODULE_ID));

                iCnt = (int)CDB_select_rsummdlncl_scalar(2, &RSUMMDLNCL);
                if (iCnt > 0)
                {
                    CDB_delete_rsummdlncl(2, &RSUMMDLNCL);
                }

                TRS.copy(RSUMMDLNCL.CREATE_USER_ID, sizeof(RSUMMDLNCL.CREATE_USER_ID), in_node, IN_USERID);
                CDB_insert_rsummdlncl(2, &RSUMMDLNCL);
                if (DB_error_code != DB_SUCCESS)
                {
                    LOG_head("RSUMMDLNCL Insert Error");
                    LOG_add("Oracle ErrMsg : ", MP_NSTR, DB_error_msg);
                    LOG_add("FACTORY", MP_STR, sizeof(RSUMMDLNCL.FACTORY), RSUMMDLNCL.FACTORY);
                    LOG_add("LOT_ID", MP_STR, sizeof(RSUMMDLNCL.MODULE_ID), RSUMMDLNCL.MODULE_ID);
                    LOG_add("KIND", MP_STR, sizeof(CWIPCTMTRC.KIND), CWIPCTMTRC.KIND);
                    LOG_add("__FILE__", MP_NSTR, __FILE__);
                    LOG_add("__LINE__", MP_INT, __LINE__);

                    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);
                }
            }
        }

        CDB_delete_cwipctmtrc(1, &CWIPCTMTRC);
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}
