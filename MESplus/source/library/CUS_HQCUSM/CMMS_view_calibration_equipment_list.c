/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_equipment_list.c
    Description : View Calibration_Equipment List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_Equipment_List()
            + View Calibration_Equipment definition List
        - CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST()
            + Main sub function of CMMS_View_Calibration_Equipment_List function
            + View Calibration_Equipment definition List
    Detail Description
        - CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST()
            + h_proc_step
                + 1 : View Calibration_Equipment definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-04             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Calibration_Equipment_List()
        - View Calibration_Equipment definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Equipment_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST", out_node);

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
    CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST()
        - Main sub function of "CMMS_View_Calibration_Equipment_List" function
        - View Calibration_Equipment definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALEQP_TAG CMMSCALEQP;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("cali_id", MP_NSTR, TRS.get_string(in_node, "CALI_ID"));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Equipment_List",
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

    i_case = 1;

    CDB_init_cmmscaleqp(&CMMSCALEQP);
    TRS.copy(CMMSCALEQP.FACTORY, sizeof(CMMSCALEQP.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID), in_node, "CALI_ID");
    TRS.copy(CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID), in_node, "EQUIP_ID");
    TRS.copy(CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID), in_node, "NEXT_CALI_ID");
    TRS.copy(CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID), in_node, "NEXT_EQUIP_ID");
    CDB_open_cmmscaleqp(i_case, &CMMSCALEQP);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSCALEQP OPEN", MP_NVST);
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


    while(1)
    {
        CDB_fetch_cmmscaleqp(i_case, &CMMSCALEQP);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmscaleqp(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALEQP FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmscaleqp(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_CALI_ID", CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID));
            TRS.set_string(out_node, "NEXT_EQUIP_ID", CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID));
            CDB_close_cmmscaleqp(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "CALIBRATION_EQUIPMENT_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSCALEQP.FACTORY, sizeof(CMMSCALEQP.FACTORY));
        TRS.add_string(list_item, "CALI_ID", CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID));
        TRS.add_string(list_item, "EQUIP_ID", CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID));
        TRS.add_string(list_item, "CMF_1", CMMSCALEQP.CMF_1, sizeof(CMMSCALEQP.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMSCALEQP.CMF_2, sizeof(CMMSCALEQP.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMSCALEQP.CMF_3, sizeof(CMMSCALEQP.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMSCALEQP.CMF_4, sizeof(CMMSCALEQP.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMSCALEQP.CMF_5, sizeof(CMMSCALEQP.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMSCALEQP.CMF_6, sizeof(CMMSCALEQP.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMSCALEQP.CMF_7, sizeof(CMMSCALEQP.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMSCALEQP.CMF_8, sizeof(CMMSCALEQP.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMSCALEQP.CMF_9, sizeof(CMMSCALEQP.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMSCALEQP.CMF_10, sizeof(CMMSCALEQP.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMSCALEQP.CREATE_USER_ID, sizeof(CMMSCALEQP.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMSCALEQP.CREATE_TIME, sizeof(CMMSCALEQP.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMSCALEQP.UPDATE_USER_ID, sizeof(CMMSCALEQP.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMSCALEQP.UPDATE_TIME, sizeof(CMMSCALEQP.UPDATE_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Equipment_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

