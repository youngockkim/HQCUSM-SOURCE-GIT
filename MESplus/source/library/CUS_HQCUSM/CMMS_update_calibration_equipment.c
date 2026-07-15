/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_calibration_equipment.c
    Description : Calibration_Equipment Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Calibration_Equipment()
            + Create/Update/Delete Calibration_Equipment definition
        - CMMS_UPDATE_CALIBRATION_EQUIPMENT()
            + Main sub function of CMMS_Update_Calibration_Equipment function
            + Create/Update/Delete Calibration_Equipment definition
        - CMMS_Update_Calibration_Equipment_Validation()
            + Main sub function of CMMS_UPDATE_CALIBRATION_EQUIPMENT function
            + Check the condition for create/update/delete Calibration_Equipment
    Detail Description
        - CMMS_UPDATE_CALIBRATION_EQUIPMENT()
            + h_proc_step
                + MP_STEP_CREATE : Create Calibration_Equipment definition
                + MP_STEP_UPDATE : Update Calibration_Equipment definition
                + MP_STEP_DELETE : Delete Calibration_Equipment definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-04             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Calibration_Equipment_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Calibration_Equipment()
        - Create/Update/Delete Calibration_Equipment definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_Equipment(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_CALIBRATION_EQUIPMENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_CALIBRATION_EQUIPMENT", out_node);

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
    CMMS_UPDATE_CALIBRATION_EQUIPMENT()
        - Main sub function of "CMMS_Update_Calibration_Equipment" function
        - Create/Update/Delete Calibration_Equipment definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_CALIBRATION_EQUIPMENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALEQP_TAG CMMSCALEQP;
    struct CMMSCALEQP_TAG CMMSCALEQP_o;
    char   s_sys_time[14];

    LOG_head("CMMS_UPDATE_CALIBRATION_EQUIPMENT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("cali_id", MP_NSTR, TRS.get_string(in_node, "CALI_ID"));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_Equipment",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(CMMS_Update_Calibration_Equipment_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmscaleqp(&CMMSCALEQP);
    TRS.copy(CMMSCALEQP.FACTORY, sizeof(CMMSCALEQP.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID), in_node, "CALI_ID");
    TRS.copy(CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID), in_node, "EQUIP_ID");
    TRS.copy(CMMSCALEQP.CMF_1, sizeof(CMMSCALEQP.CMF_1), in_node, "CMF_1");
    TRS.copy(CMMSCALEQP.CMF_2, sizeof(CMMSCALEQP.CMF_2), in_node, "CMF_2");
    TRS.copy(CMMSCALEQP.CMF_3, sizeof(CMMSCALEQP.CMF_3), in_node, "CMF_3");
    TRS.copy(CMMSCALEQP.CMF_4, sizeof(CMMSCALEQP.CMF_4), in_node, "CMF_4");
    TRS.copy(CMMSCALEQP.CMF_5, sizeof(CMMSCALEQP.CMF_5), in_node, "CMF_5");
    TRS.copy(CMMSCALEQP.CMF_6, sizeof(CMMSCALEQP.CMF_6), in_node, "CMF_6");
    TRS.copy(CMMSCALEQP.CMF_7, sizeof(CMMSCALEQP.CMF_7), in_node, "CMF_7");
    TRS.copy(CMMSCALEQP.CMF_8, sizeof(CMMSCALEQP.CMF_8), in_node, "CMF_8");
    TRS.copy(CMMSCALEQP.CMF_9, sizeof(CMMSCALEQP.CMF_9), in_node, "CMF_9");
    TRS.copy(CMMSCALEQP.CMF_10, sizeof(CMMSCALEQP.CMF_10), in_node, "CMF_10");
    TRS.copy(CMMSCALEQP.CREATE_USER_ID, sizeof(CMMSCALEQP.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSCALEQP.CREATE_TIME, sizeof(CMMSCALEQP.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSCALEQP.UPDATE_USER_ID, sizeof(CMMSCALEQP.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSCALEQP.UPDATE_TIME, sizeof(CMMSCALEQP.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMSCALEQP.CREATE_USER_ID, sizeof(CMMSCALEQP.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSCALEQP.CREATE_TIME, s_sys_time, sizeof(CMMSCALEQP.CREATE_TIME));
        CDB_insert_cmmscaleqp(&CMMSCALEQP);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALEQP INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        CDB_init_cmmscaleqp(&CMMSCALEQP_o);
        TRS.copy(CMMSCALEQP_o.FACTORY, sizeof(CMMSCALEQP_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSCALEQP_o.CALI_ID, sizeof(CMMSCALEQP_o.CALI_ID), in_node, "CALI_ID");
        TRS.copy(CMMSCALEQP_o.EQUIP_ID, sizeof(CMMSCALEQP_o.EQUIP_ID), in_node, "EQUIP_ID");
        CDB_select_cmmscaleqp_for_update(1, &CMMSCALEQP_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALEQP SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP_o.FACTORY), CMMSCALEQP_o.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP_o.CALI_ID), CMMSCALEQP_o.CALI_ID);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP_o.EQUIP_ID), CMMSCALEQP_o.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CMMSCALEQP.CREATE_USER_ID, CMMSCALEQP_o.CREATE_USER_ID, sizeof(CMMSCALEQP.CREATE_USER_ID));
        memcpy(CMMSCALEQP.CREATE_TIME, CMMSCALEQP_o.CREATE_TIME, sizeof(CMMSCALEQP.CREATE_TIME));
        TRS.copy(CMMSCALEQP.UPDATE_USER_ID, sizeof(CMMSCALEQP.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSCALEQP.UPDATE_TIME, s_sys_time, sizeof(CMMSCALEQP.UPDATE_TIME));

        CDB_update_cmmscaleqp(1, &CMMSCALEQP);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALEQP UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        CDB_delete_cmmscaleqp(1, &CMMSCALEQP);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALEQP DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_Equipment",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Calibration_Equipment_Validation()
        - Main sub function of "CMMS_UPDATE_CALIBRATION_EQUIPMENT" function
        - Check the condition for create/update/delete Calibration_Equipment
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_Equipment_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALEQP_TAG CMMSCALEQP;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    /* CALI_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CALI_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "CALI_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
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
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmscaleqp(&CMMSCALEQP);
    TRS.copy(CMMSCALEQP.FACTORY, sizeof(CMMSCALEQP.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID), in_node, "CALI_ID");
    TRS.copy(CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID), in_node, "EQUIP_ID");
    CDB_select_cmmscaleqp(1, &CMMSCALEQP);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0010");
            TRS.add_fieldmsg(out_node, "CMMSCALEQP SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "MMS-0011");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "MMS-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CMMSCALEQP SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

