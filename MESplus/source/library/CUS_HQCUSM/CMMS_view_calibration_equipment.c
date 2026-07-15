/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_equipment.c
    Description : View Calibration_Equipment function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_Equipment()
            + View Calibration_Equipment definition
        - CMMS_VIEW_CALIBRATION_EQUIPMENT()
            + Main sub function of CMMS_View_Calibration_Equipment function
            + View Calibration_Equipment definition
    Detail Description
        - CMMS_VIEW_CALIBRATION_EQUIPMENT()
            + h_proc_step
                + 1 : View Calibration_Equipment definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-04             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Calibration_Equipment()
        - View Calibration_Equipment definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Equipment(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_EQUIPMENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_EQUIPMENT", out_node);

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
    CMMS_VIEW_CALIBRATION_EQUIPMENT()
        - Main sub function of "CMMS_View_Calibration_Equipment" function
        - View Calibration_Equipment definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_EQUIPMENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALEQP_TAG CMMSCALEQP;

    LOG_head("CMMS_VIEW_CALIBRATION_EQUIPMENT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("cali_id", MP_NSTR, TRS.get_string(in_node, "CALI_ID"));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Equipment",
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
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CALI_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CALI_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "CALI_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* EQUIP_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "EQUIP_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmscaleqp(&CMMSCALEQP);
    TRS.copy(CMMSCALEQP.FACTORY, sizeof(CMMSCALEQP.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID), in_node, "CALI_ID");
    TRS.copy(CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID), in_node, "EQUIP_ID");
    CDB_select_cmmscaleqp(1, &CMMSCALEQP);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSCALEQP SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CMMSCALEQP.FACTORY, sizeof(CMMSCALEQP.FACTORY));
    TRS.add_string(out_node, "CALI_ID", CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID));
    TRS.add_string(out_node, "EQUIP_ID", CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID));
    TRS.add_string(out_node, "CMF_1", CMMSCALEQP.CMF_1, sizeof(CMMSCALEQP.CMF_1));
    TRS.add_string(out_node, "CMF_2", CMMSCALEQP.CMF_2, sizeof(CMMSCALEQP.CMF_2));
    TRS.add_string(out_node, "CMF_3", CMMSCALEQP.CMF_3, sizeof(CMMSCALEQP.CMF_3));
    TRS.add_string(out_node, "CMF_4", CMMSCALEQP.CMF_4, sizeof(CMMSCALEQP.CMF_4));
    TRS.add_string(out_node, "CMF_5", CMMSCALEQP.CMF_5, sizeof(CMMSCALEQP.CMF_5));
    TRS.add_string(out_node, "CMF_6", CMMSCALEQP.CMF_6, sizeof(CMMSCALEQP.CMF_6));
    TRS.add_string(out_node, "CMF_7", CMMSCALEQP.CMF_7, sizeof(CMMSCALEQP.CMF_7));
    TRS.add_string(out_node, "CMF_8", CMMSCALEQP.CMF_8, sizeof(CMMSCALEQP.CMF_8));
    TRS.add_string(out_node, "CMF_9", CMMSCALEQP.CMF_9, sizeof(CMMSCALEQP.CMF_9));
    TRS.add_string(out_node, "CMF_10", CMMSCALEQP.CMF_10, sizeof(CMMSCALEQP.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSCALEQP.CREATE_USER_ID, sizeof(CMMSCALEQP.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSCALEQP.CREATE_TIME, sizeof(CMMSCALEQP.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSCALEQP.UPDATE_USER_ID, sizeof(CMMSCALEQP.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSCALEQP.UPDATE_TIME, sizeof(CMMSCALEQP.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Equipment",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

