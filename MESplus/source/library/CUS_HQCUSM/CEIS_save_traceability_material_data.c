/*******************************************************************************

    System      : MESplus
    Module      : CRPT
    File Name   : CEIS_save_traceability_material_data.c

    MES Version : 5.0

    Function List
        -

    Detail Description
        - ÀÚÀç ÃßÀû¼º, CTM Áý°è¿ë µ¥ÀÌÅÍ »ý¼º
          : Report DB, Archive DB¿¡ ÀúÀåµÊ.

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024.02.23   hn.lee

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"

int CEIS_SAVE_TRACEABILITY_MATERIAL_DATA(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
    CEIS_Save_Traceability_Material_Data()
        - ÀÚÀç ÃßÀû¼º µ¥ÀÌÅÍ »ý¼º
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEIS_Save_Traceability_Material_Data(TRSNode* in_node, TRSNode* out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CEIS_SAVE_TRACEABILITY_MATERIAL_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CEIS_Save_Traceability_Material_Data", out_node);

    if (i_ret == MP_TRUE)
    {
        if (gb_multi_transaction == MP_FALSE)
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
    CEIS_SAVE_TRACEABILITY_MATERIAL_DATA()
        - CEIS_Save_Traceability_Material_Data
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEIS_SAVE_TRACEABILITY_MATERIAL_DATA(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
    struct CWIPCTMTRC_TAG CWIPCTMTRC;

    char s_sys_time[14];

    LOG_head("CEIS_SAVE_TRACEABILITY_MATERIAL_DATA");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if (COM_service_validation(s_msg_code,
        in_node,
        out_node,
        TRS.get_procstep(in_node),
        "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    DB_get_systime(s_sys_time);

    if (TRS.get_procstep(in_node) == '1')
    {
        // ÀÚÀç ÃßÀû¼º, CTM Áý°è¿ë µ¥ÀÌÅÍ ÀúÀå
        CDB_init_cwipctmtrc(&CWIPCTMTRC);

        TRS.copy(CWIPCTMTRC.FACTORY, sizeof(CWIPCTMTRC.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CWIPCTMTRC.LOT_ID, sizeof(CWIPCTMTRC.LOT_ID), in_node, "LOT_ID");
        TRS.copy(CWIPCTMTRC.INV_LOT_ID, sizeof(CWIPCTMTRC.INV_LOT_ID), in_node, "INV_LOT_ID");
        TRS.copy(CWIPCTMTRC.KIND, sizeof(CWIPCTMTRC.KIND), in_node, "KIND");
        CWIPCTMTRC.WIP_FLAG = TRS.get_char(in_node, "WIP_FLAG");

        CDB_select_cwipctmtrc(1, &CWIPCTMTRC);
        if (DB_error_code == DB_NOT_FOUND)
        {
            memcpy(CWIPCTMTRC.TRAN_TIME, s_sys_time, sizeof(CWIPCTMTRC.TRAN_TIME));

            CDB_insert_cwipctmtrc(1, &CWIPCTMTRC);
        }
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

    return MP_TRUE;
}
