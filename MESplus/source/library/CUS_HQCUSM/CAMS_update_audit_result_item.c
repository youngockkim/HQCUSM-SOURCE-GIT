/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_update_audit_result_item.c
    Description : Audit_Result_Item Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CAMS_Update_Audit_Result_Item()
            + Create/Update/Delete Audit_Result_Item definition
        - CAMS_UPDATE_AUDIT_RESULT_ITEM()
            + Main sub function of CAMS_Update_Audit_Result_Item function
            + Create/Update/Delete Audit_Result_Item definition
        - CAMS_Update_Audit_Result_Item_Validation()
            + Main sub function of CAMS_UPDATE_AUDIT_RESULT_ITEM function
            + Check the condition for create/update/delete Audit_Result_Item
    Detail Description
        - CAMS_UPDATE_AUDIT_RESULT_ITEM()
            + h_proc_step
                + MP_STEP_CREATE : Create Audit_Result_Item definition
                + MP_STEP_UPDATE : Update Audit_Result_Item definition
                + MP_STEP_DELETE : Delete Audit_Result_Item definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-26             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CAMS_Update_Audit_Result_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CAMS_Update_Audit_Result_Item()
        - Create/Update/Delete Audit_Result_Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_Update_Audit_Result_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_UPDATE_AUDIT_RESULT_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_UPDATE_AUDIT_RESULT_ITEM", out_node);

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
    CAMS_UPDATE_AUDIT_RESULT_ITEM()
        - Main sub function of "CAMS_Update_Audit_Result_Item" function
        - Create/Update/Delete Audit_Result_Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_UPDATE_AUDIT_RESULT_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTITM_TAG CAMSADTITM;
    struct CAMSADTITM_TAG CAMSADTITM_o;
    char   s_sys_time[14];

    LOG_head("CAMS_UPDATE_AUDIT_RESULT_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("audit_id", MP_NSTR, TRS.get_string(in_node, "AUDIT_ID"));
    LOG_add("sort_order", MP_INT, TRS.get_int(in_node, "SORT_ORDER"));
    LOG_add("item_division", MP_NSTR, TRS.get_string(in_node, "ITEM_DIVISION"));
    LOG_add("item_name", MP_NSTR, TRS.get_string(in_node, "ITEM_NAME"));
    LOG_add("check_detail", MP_NSTR, TRS.get_string(in_node, "CHECK_DETAIL"));
    LOG_add("check_result", MP_CHR, TRS.get_char(in_node, "CHECK_RESULT"));
    LOG_add("file_name", MP_NSTR, TRS.get_string(in_node, "FILE_NAME"));
    LOG_add("file_path", MP_NSTR, TRS.get_string(in_node, "FILE_PATH"));
    LOG_add("action_mgr_id", MP_NSTR, TRS.get_string(in_node, "ACTION_MGR_ID"));
    LOG_add("action_limit_date", MP_NSTR, TRS.get_string(in_node, "ACTION_LIMIT_DATE"));
    LOG_add("action_date", MP_NSTR, TRS.get_string(in_node, "ACTION_DATE"));
    LOG_add("action_user_id", MP_NSTR, TRS.get_string(in_node, "ACTION_USER_ID"));
    LOG_add("action_file_name", MP_NSTR, TRS.get_string(in_node, "ACTION_FILE_NAME"));
    LOG_add("action_file_path", MP_NSTR, TRS.get_string(in_node, "ACTION_FILE_PATH"));
    LOG_add("action_result", MP_CHR, TRS.get_char(in_node, "ACTION_RESULT"));
    LOG_add("remarks", MP_NSTR, TRS.get_string(in_node, "REMARKS"));
    LOG_add("status", MP_CHR, TRS.get_char(in_node, "STATUS"));
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
    if(COM_proc_user_routine("CAMS", "CAMS_Update_Audit_Result_Item",
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

    if(CAMS_Update_Audit_Result_Item_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_camsadtitm(&CAMSADTITM);
    TRS.copy(CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID), in_node, "AUDIT_ID");
    CAMSADTITM.SORT_ORDER = TRS.get_int(in_node, "SORT_ORDER");
    TRS.copy(CAMSADTITM.ITEM_DIVISION, sizeof(CAMSADTITM.ITEM_DIVISION), in_node, "ITEM_DIVISION");
    TRS.copy(CAMSADTITM.ITEM_NAME, sizeof(CAMSADTITM.ITEM_NAME), in_node, "ITEM_NAME");
    TRS.copy(CAMSADTITM.CHECK_DETAIL, sizeof(CAMSADTITM.CHECK_DETAIL), in_node, "CHECK_DETAIL");
	CAMSADTITM.CHECK_RESULT = TRS.get_char(in_node, "CHECK_RESULT");
    TRS.copy(CAMSADTITM.FILE_NAME, sizeof(CAMSADTITM.FILE_NAME), in_node, "FILE_NAME");
    TRS.copy(CAMSADTITM.FILE_PATH, sizeof(CAMSADTITM.FILE_PATH), in_node, "FILE_PATH");
    TRS.copy(CAMSADTITM.ACTION_USER_ID, sizeof(CAMSADTITM.ACTION_USER_ID), in_node, "ACTION_USER_ID");
    TRS.copy(CAMSADTITM.ACTION_LIMIT_DATE, sizeof(CAMSADTITM.ACTION_LIMIT_DATE), in_node, "ACTION_LIMIT_DATE");
    TRS.copy(CAMSADTITM.ACTION_DATE, sizeof(CAMSADTITM.ACTION_DATE), in_node, "ACTION_DATE");
    CAMSADTITM.STATUS = TRS.get_char(in_node, "STATUS");
    TRS.copy(CAMSADTITM.CMF_1, sizeof(CAMSADTITM.CMF_1), in_node, "CMF_1");
    TRS.copy(CAMSADTITM.CMF_2, sizeof(CAMSADTITM.CMF_2), in_node, "CMF_2");
    TRS.copy(CAMSADTITM.CMF_3, sizeof(CAMSADTITM.CMF_3), in_node, "CMF_3");
    TRS.copy(CAMSADTITM.CMF_4, sizeof(CAMSADTITM.CMF_4), in_node, "CMF_4");
    TRS.copy(CAMSADTITM.CMF_5, sizeof(CAMSADTITM.CMF_5), in_node, "CMF_5");
    TRS.copy(CAMSADTITM.CMF_6, sizeof(CAMSADTITM.CMF_6), in_node, "CMF_6");
    TRS.copy(CAMSADTITM.CMF_7, sizeof(CAMSADTITM.CMF_7), in_node, "CMF_7");
    TRS.copy(CAMSADTITM.CMF_8, sizeof(CAMSADTITM.CMF_8), in_node, "CMF_8");
    TRS.copy(CAMSADTITM.CMF_9, sizeof(CAMSADTITM.CMF_9), in_node, "CMF_9");
    TRS.copy(CAMSADTITM.CMF_10, sizeof(CAMSADTITM.CMF_10), in_node, "CMF_10");
    TRS.copy(CAMSADTITM.CREATE_USER_ID, sizeof(CAMSADTITM.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CAMSADTITM.CREATE_TIME, sizeof(CAMSADTITM.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CAMSADTITM.UPDATE_USER_ID, sizeof(CAMSADTITM.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CAMSADTITM.UPDATE_TIME, sizeof(CAMSADTITM.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CAMSADTITM.CREATE_USER_ID, sizeof(CAMSADTITM.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CAMSADTITM.CREATE_TIME, s_sys_time, sizeof(CAMSADTITM.CREATE_TIME));
        CDB_insert_camsadtitm(&CAMSADTITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTITM INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
            TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
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
        CDB_init_camsadtitm(&CAMSADTITM_o);
        TRS.copy(CAMSADTITM_o.FACTORY, sizeof(CAMSADTITM_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CAMSADTITM_o.AUDIT_ID, sizeof(CAMSADTITM_o.AUDIT_ID), in_node, "AUDIT_ID");
        CAMSADTITM_o.SORT_ORDER = TRS.get_int(in_node, "SORT_ORDER");
        CDB_select_camsadtitm_for_update(1, &CAMSADTITM_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTITM SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM_o.FACTORY), CAMSADTITM_o.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM_o.AUDIT_ID), CAMSADTITM_o.AUDIT_ID);
            TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM_o.SORT_ORDER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CAMSADTITM.CREATE_USER_ID, CAMSADTITM_o.CREATE_USER_ID, sizeof(CAMSADTITM.CREATE_USER_ID));
        memcpy(CAMSADTITM.CREATE_TIME, CAMSADTITM_o.CREATE_TIME, sizeof(CAMSADTITM.CREATE_TIME));
        TRS.copy(CAMSADTITM.UPDATE_USER_ID, sizeof(CAMSADTITM.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CAMSADTITM.UPDATE_TIME, s_sys_time, sizeof(CAMSADTITM.UPDATE_TIME));

        CDB_update_camsadtitm(1, &CAMSADTITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTITM UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
            TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
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
        CDB_delete_camsadtitm(1, &CAMSADTITM);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTITM DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
            TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_Update_Audit_Result_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CAMS_Update_Audit_Result_Item_Validation()
        - Main sub function of "CAMS_UPDATE_AUDIT_RESULT_ITEM" function
        - Check the condition for create/update/delete Audit_Result_Item
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_Update_Audit_Result_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
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
        strcpy(s_msg_code, "CMN-0002");
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

    /* AUDIT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "AUDIT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /*
    CDB_init_camsadtitm(&CAMSADTITM);
    TRS.copy(CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID), in_node, "AUDIT_ID");
    CAMSADTITM.SORT_ORDER = TRS.get_int(in_node, "SORT_ORDER");
    CDB_select_camsadtitm(1, &CAMSADTITM);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CAMS-XXXX");
            TRS.add_fieldmsg(out_node, "CAMSADTITM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
            TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_XXX, CAMSADTITM.SORT_ORDER);
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
                strcpy(s_msg_code, "CAMS-XXXX");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CAMS-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CAMSADTITM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
            TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_XXX, CAMSADTITM.SORT_ORDER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }*/

    return MP_TRUE;
}

