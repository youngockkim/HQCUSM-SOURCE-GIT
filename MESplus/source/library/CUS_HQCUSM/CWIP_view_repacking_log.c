/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_repacking_log.c
    Description : View Repacking_Log function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Repacking_Log()
            + View Repacking_Log definition
        - CWIP_VIEW_REPACKING_LOG()
            + Main sub function of CWIP_View_Repacking_Log function
            + View Repacking_Log definition
    Detail Description
        - CWIP_VIEW_REPACKING_LOG()
            + h_proc_step
                + 1 : View Repacking_Log definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/08/01             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "CUS_common.h"

/*******************************************************************************
    CWIP_View_Repacking_Log()
        - View Repacking_Log definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Repacking_Log(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_REPACKING_LOG(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_REPACKING_LOG", out_node);

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
    CWIP_VIEW_REPACKING_LOG()
        - Main sub function of "CWIP_View_Repacking_Log" function
        - View Repacking_Log definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_REPACKING_LOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPRPKHIS_TAG CWIPRPKHIS;

    LOG_head("CWIP_VIEW_REPACKING_LOG");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("pallet_id", MP_NSTR, TRS.get_string(in_node, "PALLET_ID"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Repacking_Log",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* PALLET_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "PALLET_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "PALLET_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* MAT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiprpkhis(&CWIPRPKHIS);
    TRS.copy(CWIPRPKHIS.FACTORY, sizeof(CWIPRPKHIS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPRPKHIS.PALLET_ID, sizeof(CWIPRPKHIS.PALLET_ID), in_node, "PALLET_ID");
    TRS.copy(CWIPRPKHIS.MAT_ID, sizeof(CWIPRPKHIS.MAT_ID), in_node, "MAT_ID");
    CDB_select_cwiprpkhis(1, &CWIPRPKHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPRPKHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRPKHIS.FACTORY), CWIPRPKHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPRPKHIS.PALLET_ID), CWIPRPKHIS.PALLET_ID);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPRPKHIS.MAT_ID), CWIPRPKHIS.MAT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CWIPRPKHIS.FACTORY, sizeof(CWIPRPKHIS.FACTORY));
    TRS.add_string(out_node, "PALLET_ID", CWIPRPKHIS.PALLET_ID, sizeof(CWIPRPKHIS.PALLET_ID));
    TRS.add_string(out_node, "MAT_ID", CWIPRPKHIS.MAT_ID, sizeof(CWIPRPKHIS.MAT_ID));
    TRS.add_string(out_node, "CAUSE_ID", CWIPRPKHIS.CAUSE_ID, sizeof(CWIPRPKHIS.CAUSE_ID));
    TRS.add_string(out_node, "PACK_TIME", CWIPRPKHIS.PACK_TIME, sizeof(CWIPRPKHIS.PACK_TIME));
    TRS.add_string(out_node, "CMF_1", CWIPRPKHIS.CMF_1, sizeof(CWIPRPKHIS.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPRPKHIS.CMF_2, sizeof(CWIPRPKHIS.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPRPKHIS.CMF_3, sizeof(CWIPRPKHIS.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPRPKHIS.CMF_4, sizeof(CWIPRPKHIS.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPRPKHIS.CMF_5, sizeof(CWIPRPKHIS.CMF_5));
    TRS.add_string(out_node, "CMF_6", CWIPRPKHIS.CMF_6, sizeof(CWIPRPKHIS.CMF_6));
    TRS.add_string(out_node, "CMF_7", CWIPRPKHIS.CMF_7, sizeof(CWIPRPKHIS.CMF_7));
    TRS.add_string(out_node, "CMF_8", CWIPRPKHIS.CMF_8, sizeof(CWIPRPKHIS.CMF_8));
    TRS.add_string(out_node, "CMF_9", CWIPRPKHIS.CMF_9, sizeof(CWIPRPKHIS.CMF_9));
    TRS.add_string(out_node, "CMF_10", CWIPRPKHIS.CMF_10, sizeof(CWIPRPKHIS.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPRPKHIS.CREATE_USER_ID, sizeof(CWIPRPKHIS.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPRPKHIS.CREATE_TIME, sizeof(CWIPRPKHIS.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPRPKHIS.UPDATE_USER_ID, sizeof(CWIPRPKHIS.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPRPKHIS.UPDATE_TIME, sizeof(CWIPRPKHIS.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Repacking_Log",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

