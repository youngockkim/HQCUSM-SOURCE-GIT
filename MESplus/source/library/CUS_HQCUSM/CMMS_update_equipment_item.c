/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_equipment_item.c
    Description : Equipment_Item Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Equipment_Item()
            + Create/Update/Delete Equipment_Item definition
        - CMMS_UPDATE_EQUIPMENT_ITEM()
            + Main sub function of CMMS_Update_Equipment_Item function
            + Create/Update/Delete Equipment_Item definition
        - CMMS_Update_Equipment_Item_Validation()
            + Main sub function of CMMS_UPDATE_EQUIPMENT_ITEM function
            + Check the condition for create/update/delete Equipment_Item
    Detail Description
        - CMMS_UPDATE_EQUIPMENT_ITEM()
            + h_proc_step
                + MP_STEP_CREATE : Create Equipment_Item definition
                + MP_STEP_UPDATE : Update Equipment_Item definition
                + MP_STEP_DELETE : Delete Equipment_Item definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-21             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Equipment_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Equipment_Item()
        - Create/Update/Delete Equipment_Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Equipment_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_EQUIPMENT_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_EQUIPMENT_ITEM", out_node);

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
    CMMS_UPDATE_EQUIPMENT_ITEM()
        - Main sub function of "CMMS_Update_Equipment_Item" function
        - Create/Update/Delete Equipment_Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_EQUIPMENT_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSEQPITM_TAG CMMSEQPITM;
    struct CMMSEQPITM_TAG CMMSEQPITM_o;
    char   s_sys_time[14];

    LOG_head("CMMS_UPDATE_EQUIPMENT_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    LOG_add("item_name", MP_NSTR, TRS.get_string(in_node, "ITEM_NAME"));
    LOG_add("item_spec", MP_NSTR, TRS.get_string(in_node, "ITEM_SPEC"));
    LOG_add("item_order", MP_INT, TRS.get_int(in_node, "ITEM_ORDER"));
    LOG_add("lsl", MP_DBL, TRS.get_double(in_node, "LSL"));
    LOG_add("usl", MP_DBL, TRS.get_double(in_node, "USL"));
    LOG_add("unit_code", MP_NSTR, TRS.get_string(in_node, "UNIT_CODE"));
    LOG_add("decimal_place", MP_INT, TRS.get_int(in_node, "DECIMAL_PLACE"));
    LOG_add("use_grr_cont_flag", MP_CHR, TRS.get_char(in_node, "USE_GRR_CONT_FLAG"));
    LOG_add("use_grr_disc_flag", MP_CHR, TRS.get_char(in_node, "USE_GRR_DISC_FLAG"));
    LOG_add("use_bias_flag", MP_CHR, TRS.get_char(in_node, "USE_BIAS_FLAG"));
    LOG_add("use_line_flag", MP_CHR, TRS.get_char(in_node, "USE_LINE_FLAG"));
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
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Equipment_Item",
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

    if(CMMS_Update_Equipment_Item_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmseqpitm(&CMMSEQPITM);
    TRS.copy(CMMSEQPITM.FACTORY, sizeof(CMMSEQPITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSEQPITM.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID), in_node, "EQUIP_ID");
    TRS.copy(CMMSEQPITM.ITEM_CODE, sizeof(CMMSEQPITM.ITEM_CODE), in_node, "ITEM_CODE");
    TRS.copy(CMMSEQPITM.ITEM_NAME, sizeof(CMMSEQPITM.ITEM_NAME), in_node, "ITEM_NAME");
    TRS.copy(CMMSEQPITM.ITEM_SPEC, sizeof(CMMSEQPITM.ITEM_SPEC), in_node, "ITEM_SPEC");
    CMMSEQPITM.ITEM_ORDER = TRS.get_int(in_node, "ITEM_ORDER");
    CMMSEQPITM.LSL = TRS.get_double(in_node, "LSL");
    CMMSEQPITM.USL = TRS.get_double(in_node, "USL");
    TRS.copy(CMMSEQPITM.UNIT_CODE, sizeof(CMMSEQPITM.UNIT_CODE), in_node, "UNIT_CODE");
    CMMSEQPITM.DECIMAL_PLACE = TRS.get_int(in_node, "DECIMAL_PLACE");
    CMMSEQPITM.USE_GRR_CONT_FLAG = TRS.get_char(in_node, "USE_GRR_CONT_FLAG");
    CMMSEQPITM.USE_GRR_DISC_FLAG = TRS.get_char(in_node, "USE_GRR_DISC_FLAG");
    CMMSEQPITM.USE_BIAS_FLAG = TRS.get_char(in_node, "USE_BIAS_FLAG");
    CMMSEQPITM.USE_LINE_FLAG = TRS.get_char(in_node, "USE_LINE_FLAG");
    TRS.copy(CMMSEQPITM.CMF_1, sizeof(CMMSEQPITM.CMF_1), in_node, "CMF_1");
    TRS.copy(CMMSEQPITM.CMF_2, sizeof(CMMSEQPITM.CMF_2), in_node, "CMF_2");
    TRS.copy(CMMSEQPITM.CMF_3, sizeof(CMMSEQPITM.CMF_3), in_node, "CMF_3");
    TRS.copy(CMMSEQPITM.CMF_4, sizeof(CMMSEQPITM.CMF_4), in_node, "CMF_4");
    TRS.copy(CMMSEQPITM.CMF_5, sizeof(CMMSEQPITM.CMF_5), in_node, "CMF_5");
    TRS.copy(CMMSEQPITM.CMF_6, sizeof(CMMSEQPITM.CMF_6), in_node, "CMF_6");
    TRS.copy(CMMSEQPITM.CMF_7, sizeof(CMMSEQPITM.CMF_7), in_node, "CMF_7");
    TRS.copy(CMMSEQPITM.CMF_8, sizeof(CMMSEQPITM.CMF_8), in_node, "CMF_8");
    TRS.copy(CMMSEQPITM.CMF_9, sizeof(CMMSEQPITM.CMF_9), in_node, "CMF_9");
    TRS.copy(CMMSEQPITM.CMF_10, sizeof(CMMSEQPITM.CMF_10), in_node, "CMF_10");
    TRS.copy(CMMSEQPITM.CREATE_USER_ID, sizeof(CMMSEQPITM.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSEQPITM.CREATE_TIME, sizeof(CMMSEQPITM.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSEQPITM.UPDATE_USER_ID, sizeof(CMMSEQPITM.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSEQPITM.UPDATE_TIME, sizeof(CMMSEQPITM.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMSEQPITM.CREATE_USER_ID, sizeof(CMMSEQPITM.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSEQPITM.CREATE_TIME, s_sys_time, sizeof(CMMSEQPITM.CREATE_TIME));
        CDB_insert_cmmseqpitm(&CMMSEQPITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPITM INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
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
        CDB_init_cmmseqpitm(&CMMSEQPITM_o);
        TRS.copy(CMMSEQPITM_o.FACTORY, sizeof(CMMSEQPITM_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSEQPITM_o.EQUIP_ID, sizeof(CMMSEQPITM_o.EQUIP_ID), in_node, "EQUIP_ID");
        TRS.copy(CMMSEQPITM_o.ITEM_CODE, sizeof(CMMSEQPITM_o.ITEM_CODE), in_node, "ITEM_CODE");
        CDB_select_cmmseqpitm_for_update(1, &CMMSEQPITM_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPITM SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM_o.FACTORY), CMMSEQPITM_o.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM_o.EQUIP_ID), CMMSEQPITM_o.EQUIP_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM_o.ITEM_CODE), CMMSEQPITM_o.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CMMSEQPITM.CREATE_USER_ID, CMMSEQPITM_o.CREATE_USER_ID, sizeof(CMMSEQPITM.CREATE_USER_ID));
        memcpy(CMMSEQPITM.CREATE_TIME, CMMSEQPITM_o.CREATE_TIME, sizeof(CMMSEQPITM.CREATE_TIME));
        TRS.copy(CMMSEQPITM.UPDATE_USER_ID, sizeof(CMMSEQPITM.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSEQPITM.UPDATE_TIME, s_sys_time, sizeof(CMMSEQPITM.UPDATE_TIME));

        CDB_update_cmmseqpitm(1, &CMMSEQPITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPITM UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
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
        CDB_delete_cmmseqpitm(1, &CMMSEQPITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPITM DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Equipment_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Equipment_Item_Validation()
        - Main sub function of "CMMS_UPDATE_EQUIPMENT_ITEM" function
        - Check the condition for create/update/delete Equipment_Item
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Equipment_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSEQPITM_TAG CMMSEQPITM;
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
    /* ITEM_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmseqpitm(&CMMSEQPITM);
    TRS.copy(CMMSEQPITM.FACTORY, sizeof(CMMSEQPITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSEQPITM.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID), in_node, "EQUIP_ID");
    TRS.copy(CMMSEQPITM.ITEM_CODE, sizeof(CMMSEQPITM.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cmmseqpitm(1, &CMMSEQPITM);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0010");
            TRS.add_fieldmsg(out_node, "CMMSEQPITM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
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

            TRS.add_fieldmsg(out_node, "CMMSEQPITM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

