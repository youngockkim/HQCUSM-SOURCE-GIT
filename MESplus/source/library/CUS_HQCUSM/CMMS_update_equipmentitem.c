/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_equipmentitem.c
    Description : EquipmentItem Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_EquipmentItem()
            + Create/Update/Delete EquipmentItem definition
        - CMMS_UPDATE_EQUIPMENTITEM()
            + Main sub function of CMMS_Update_EquipmentItem function
            + Create/Update/Delete EquipmentItem definition
        - CMMS_Update_EquipmentItem_Validation()
            + Main sub function of CMMS_UPDATE_EQUIPMENTITEM function
            + Check the condition for create/update/delete EquipmentItem
    Detail Description
        - CMMS_UPDATE_EQUIPMENTITEM()
            + h_proc_step
                + MP_STEP_CREATE : Create EquipmentItem definition
                + MP_STEP_UPDATE : Update EquipmentItem definition
                + MP_STEP_DELETE : Delete EquipmentItem definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-21             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_EquipmentItem_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_EquipmentItem()
        - Create/Update/Delete EquipmentItem definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_EquipmentItem(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_EQUIPMENTITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_EQUIPMENTITEM", out_node);

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
    CMMS_UPDATE_EQUIPMENTITEM()
        - Main sub function of "CMMS_Update_EquipmentItem" function
        - Create/Update/Delete EquipmentItem definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_EQUIPMENTITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSINSDEF_TAG CMMSINSDEF;
    struct CMMSINSDEF_TAG CMMSINSDEF_o;
    char   s_sys_time[14];

    LOG_head("CMMS_UPDATE_EQUIPMENTITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("insti_code", MP_NSTR, TRS.get_string(in_node, "INSTI_CODE"));
    LOG_add("insti_name", MP_NSTR, TRS.get_string(in_node, "INSTI_NAME"));
    LOG_add("cali_div", MP_CHR, TRS.get_char(in_node, "CALI_DIV"));
    LOG_add("address", MP_NSTR, TRS.get_string(in_node, "ADDRESS"));
    LOG_add("certificate_name", MP_NSTR, TRS.get_string(in_node, "CERTIFICATE_NAME"));
    LOG_add("certificate_no", MP_NSTR, TRS.get_string(in_node, "CERTIFICATE_NO"));
    LOG_add("certificate_part", MP_NSTR, TRS.get_string(in_node, "CERTIFICATE_PART"));
    LOG_add("certificate_agency", MP_NSTR, TRS.get_string(in_node, "CERTIFICATE_AGENCY"));
    LOG_add("issue_date", MP_NSTR, TRS.get_string(in_node, "ISSUE_DATE"));
    LOG_add("first_issue_date", MP_NSTR, TRS.get_string(in_node, "FIRST_ISSUE_DATE"));
    LOG_add("expire_start_date", MP_NSTR, TRS.get_string(in_node, "EXPIRE_START_DATE"));
    LOG_add("expire_end_date", MP_NSTR, TRS.get_string(in_node, "EXPIRE_END_DATE"));
    LOG_add("file_name", MP_NSTR, TRS.get_string(in_node, "FILE_NAME"));
    LOG_add("file_path", MP_NSTR, TRS.get_string(in_node, "FILE_PATH"));
    LOG_add("use_flag", MP_CHR, TRS.get_char(in_node, "USE_FLAG"));
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
    if(COM_proc_user_routine("CMMS", "CMMS_Update_EquipmentItem",
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

    if(CMMS_Update_EquipmentItem_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsinsdef(&CMMSINSDEF);
    TRS.copy(CMMSINSDEF.FACTORY, sizeof(CMMSINSDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE), in_node, "INSTI_CODE");
    TRS.copy(CMMSINSDEF.INSTI_NAME, sizeof(CMMSINSDEF.INSTI_NAME), in_node, "INSTI_NAME");
    CMMSINSDEF.CALI_DIV = TRS.get_char(in_node, "CALI_DIV");
    TRS.copy(CMMSINSDEF.ADDRESS, sizeof(CMMSINSDEF.ADDRESS), in_node, "ADDRESS");
    TRS.copy(CMMSINSDEF.CERTIFICATE_NAME, sizeof(CMMSINSDEF.CERTIFICATE_NAME), in_node, "CERTIFICATE_NAME");
    TRS.copy(CMMSINSDEF.CERTIFICATE_NO, sizeof(CMMSINSDEF.CERTIFICATE_NO), in_node, "CERTIFICATE_NO");
    TRS.copy(CMMSINSDEF.CERTIFICATE_PART, sizeof(CMMSINSDEF.CERTIFICATE_PART), in_node, "CERTIFICATE_PART");
    TRS.copy(CMMSINSDEF.CERTIFICATE_AGENCY, sizeof(CMMSINSDEF.CERTIFICATE_AGENCY), in_node, "CERTIFICATE_AGENCY");
    TRS.copy(CMMSINSDEF.ISSUE_DATE, sizeof(CMMSINSDEF.ISSUE_DATE), in_node, "ISSUE_DATE");
    TRS.copy(CMMSINSDEF.FIRST_ISSUE_DATE, sizeof(CMMSINSDEF.FIRST_ISSUE_DATE), in_node, "FIRST_ISSUE_DATE");
    TRS.copy(CMMSINSDEF.EXPIRE_START_DATE, sizeof(CMMSINSDEF.EXPIRE_START_DATE), in_node, "EXPIRE_START_DATE");
    TRS.copy(CMMSINSDEF.EXPIRE_END_DATE, sizeof(CMMSINSDEF.EXPIRE_END_DATE), in_node, "EXPIRE_END_DATE");
    TRS.copy(CMMSINSDEF.FILE_NAME, sizeof(CMMSINSDEF.FILE_NAME), in_node, "FILE_NAME");
    TRS.copy(CMMSINSDEF.FILE_PATH, sizeof(CMMSINSDEF.FILE_PATH), in_node, "FILE_PATH");
    CMMSINSDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
    TRS.copy(CMMSINSDEF.CMF_1, sizeof(CMMSINSDEF.CMF_1), in_node, "CMF_1");
    TRS.copy(CMMSINSDEF.CMF_2, sizeof(CMMSINSDEF.CMF_2), in_node, "CMF_2");
    TRS.copy(CMMSINSDEF.CMF_3, sizeof(CMMSINSDEF.CMF_3), in_node, "CMF_3");
    TRS.copy(CMMSINSDEF.CMF_4, sizeof(CMMSINSDEF.CMF_4), in_node, "CMF_4");
    TRS.copy(CMMSINSDEF.CMF_5, sizeof(CMMSINSDEF.CMF_5), in_node, "CMF_5");
    TRS.copy(CMMSINSDEF.CMF_6, sizeof(CMMSINSDEF.CMF_6), in_node, "CMF_6");
    TRS.copy(CMMSINSDEF.CMF_7, sizeof(CMMSINSDEF.CMF_7), in_node, "CMF_7");
    TRS.copy(CMMSINSDEF.CMF_8, sizeof(CMMSINSDEF.CMF_8), in_node, "CMF_8");
    TRS.copy(CMMSINSDEF.CMF_9, sizeof(CMMSINSDEF.CMF_9), in_node, "CMF_9");
    TRS.copy(CMMSINSDEF.CMF_10, sizeof(CMMSINSDEF.CMF_10), in_node, "CMF_10");
    TRS.copy(CMMSINSDEF.CREATE_USER_ID, sizeof(CMMSINSDEF.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSINSDEF.CREATE_TIME, sizeof(CMMSINSDEF.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSINSDEF.UPDATE_USER_ID, sizeof(CMMSINSDEF.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSINSDEF.UPDATE_TIME, sizeof(CMMSINSDEF.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMSINSDEF.CREATE_USER_ID, sizeof(CMMSINSDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSINSDEF.CREATE_TIME, s_sys_time, sizeof(CMMSINSDEF.CREATE_TIME));
        CDB_insert_cmmsinsdef(&CMMSINSDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSINSDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
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
        CDB_init_cmmsinsdef(&CMMSINSDEF_o);
        TRS.copy(CMMSINSDEF_o.FACTORY, sizeof(CMMSINSDEF_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSINSDEF_o.INSTI_CODE, sizeof(CMMSINSDEF_o.INSTI_CODE), in_node, "INSTI_CODE");
        CDB_select_cmmsinsdef_for_update(1, &CMMSINSDEF_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSINSDEF SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF_o.FACTORY), CMMSINSDEF_o.FACTORY);
            TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF_o.INSTI_CODE), CMMSINSDEF_o.INSTI_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CMMSINSDEF.CREATE_USER_ID, CMMSINSDEF_o.CREATE_USER_ID, sizeof(CMMSINSDEF.CREATE_USER_ID));
        memcpy(CMMSINSDEF.CREATE_TIME, CMMSINSDEF_o.CREATE_TIME, sizeof(CMMSINSDEF.CREATE_TIME));
        TRS.copy(CMMSINSDEF.UPDATE_USER_ID, sizeof(CMMSINSDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSINSDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSINSDEF.UPDATE_TIME));

        CDB_update_cmmsinsdef(1, &CMMSINSDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSINSDEF UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
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
        CDB_delete_cmmsinsdef(1, &CMMSINSDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSINSDEF DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_EquipmentItem",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_EquipmentItem_Validation()
        - Main sub function of "CMMS_UPDATE_EQUIPMENTITEM" function
        - Check the condition for create/update/delete EquipmentItem
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_EquipmentItem_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSINSDEF_TAG CMMSINSDEF;
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
        strcpy(s_msg_code, "CMMS-0001");
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

    /* INSTI_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "INSTI_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMMS-0001");
        TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsinsdef(&CMMSINSDEF);
    TRS.copy(CMMSINSDEF.FACTORY, sizeof(CMMSINSDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE), in_node, "INSTI_CODE");
    CDB_select_cmmsinsdef(1, &CMMSINSDEF);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMMS-XXXX");
            TRS.add_fieldmsg(out_node, "CMMSINSDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
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
                strcpy(s_msg_code, "CMMS-XXXX");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CMMS-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CMMSINSDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

