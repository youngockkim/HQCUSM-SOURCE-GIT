/******************************************************************************'

    System      : MESplus
    Module      : CPSM
    File Name   : CPSM_update_prod_monitoring.c
    Description : Prod_Monitoring Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CPSM_Update_Prod_Monitoring()
            + Create/Update/Delete Prod_Monitoring definition
        - CPSM_UPDATE_PROD_MONITORING()
            + Main sub function of CPSM_Update_Prod_Monitoring function
            + Create/Update/Delete Prod_Monitoring definition
        - CPSM_Update_Prod_Monitoring_Validation()
            + Main sub function of CPSM_UPDATE_PROD_MONITORING function
            + Check the condition for create/update/delete Prod_Monitoring
    Detail Description
        - CPSM_UPDATE_PROD_MONITORING()
            + h_proc_step
                + MP_STEP_CREATE : Create Prod_Monitoring definition
                + MP_STEP_UPDATE : Update Prod_Monitoring definition
                + MP_STEP_DELETE : Delete Prod_Monitoring definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/09/25             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CPSM_Update_Prod_Monitoring_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CPSM_Update_Prod_Monitoring()
        - Create/Update/Delete Prod_Monitoring definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_Update_Prod_Monitoring(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CPSM_UPDATE_PROD_MONITORING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CPSM_UPDATE_PROD_MONITORING", out_node);

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
    CPSM_UPDATE_PROD_MONITORING()
        - Main sub function of "CPSM_Update_Prod_Monitoring" function
        - Create/Update/Delete Prod_Monitoring definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_UPDATE_PROD_MONITORING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CPSMMNTSTS_TAG CPSMMNTSTS;
    struct CPSMMNTSTS_TAG CPSMMNTSTS_o;
    char   s_sys_time[14];

    LOG_head("CPSM_UPDATE_PROD_MONITORING");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("category", MP_NSTR, TRS.get_string(in_node, "CATEGORY"));
    LOG_add("base_code", MP_NSTR, TRS.get_string(in_node, "BASE_CODE"));
    LOG_add("sub_code", MP_NSTR, TRS.get_string(in_node, "SUB_CODE"));
    LOG_add("description", MP_NSTR, TRS.get_string(in_node, "DESCRIPTION"));
    LOG_add("print_check", MP_CHR, TRS.get_char(in_node, "PRINT_CHECK"));
    LOG_add("base_dt_time", MP_INT, TRS.get_int(in_node, "BASE_DT_TIME"));
    LOG_add("option_1", MP_NSTR, TRS.get_string(in_node, "OPTION_1"));
    LOG_add("option_2", MP_NSTR, TRS.get_string(in_node, "OPTION_2"));
    LOG_add("option_3", MP_NSTR, TRS.get_string(in_node, "OPTION_3"));
    LOG_add("option_4", MP_NSTR, TRS.get_string(in_node, "OPTION_4"));
    LOG_add("option_5", MP_NSTR, TRS.get_string(in_node, "OPTION_5"));
    LOG_add("last_tran_time", MP_NSTR, TRS.get_string(in_node, "LAST_TRAN_TIME"));
    LOG_add("tran_user_id", MP_NSTR, TRS.get_string(in_node, "TRAN_USER_ID"));
    LOG_add("status", MP_NSTR, TRS.get_string(in_node, "STATUS"));
    LOG_add("status_msg", MP_NSTR, TRS.get_string(in_node, "STATUS_MSG"));
    LOG_add("client_version", MP_NSTR, TRS.get_string(in_node, "CLIENT_VERSION"));
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
    if(COM_proc_user_routine("CPSM", "CPSM_Update_Prod_Monitoring",
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

    if(CPSM_Update_Prod_Monitoring_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cpsmmntsts(&CPSMMNTSTS);
    TRS.copy(CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY), in_node, "CATEGORY");
    TRS.copy(CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE), in_node, "BASE_CODE");
    TRS.copy(CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE), in_node, "SUB_CODE");
    TRS.copy(CPSMMNTSTS.DESCRIPTION, sizeof(CPSMMNTSTS.DESCRIPTION), in_node, "DESCRIPTION");
    CPSMMNTSTS.PRINT_CHECK = TRS.get_char(in_node, "PRINT_CHECK");
    CPSMMNTSTS.BASE_DT_TIME = TRS.get_int(in_node, "BASE_DT_TIME");
    TRS.copy(CPSMMNTSTS.OPTION_1, sizeof(CPSMMNTSTS.OPTION_1), in_node, "OPTION_1");
    TRS.copy(CPSMMNTSTS.OPTION_2, sizeof(CPSMMNTSTS.OPTION_2), in_node, "OPTION_2");
    TRS.copy(CPSMMNTSTS.OPTION_3, sizeof(CPSMMNTSTS.OPTION_3), in_node, "OPTION_3");
    TRS.copy(CPSMMNTSTS.OPTION_4, sizeof(CPSMMNTSTS.OPTION_4), in_node, "OPTION_4");
    TRS.copy(CPSMMNTSTS.OPTION_5, sizeof(CPSMMNTSTS.OPTION_5), in_node, "OPTION_5");
    TRS.copy(CPSMMNTSTS.LAST_TRAN_TIME, sizeof(CPSMMNTSTS.LAST_TRAN_TIME), in_node, "LAST_TRAN_TIME");
    TRS.copy(CPSMMNTSTS.TRAN_USER_ID, sizeof(CPSMMNTSTS.TRAN_USER_ID), in_node, "TRAN_USER_ID");
    TRS.copy(CPSMMNTSTS.STATUS, sizeof(CPSMMNTSTS.STATUS), in_node, "STATUS");
    TRS.copy(CPSMMNTSTS.STATUS_MSG, sizeof(CPSMMNTSTS.STATUS_MSG), in_node, "STATUS_MSG");
    TRS.copy(CPSMMNTSTS.CLIENT_VERSION, sizeof(CPSMMNTSTS.CLIENT_VERSION), in_node, "CLIENT_VERSION");
    TRS.copy(CPSMMNTSTS.CMF_1, sizeof(CPSMMNTSTS.CMF_1), in_node, "CMF_1");
    TRS.copy(CPSMMNTSTS.CMF_2, sizeof(CPSMMNTSTS.CMF_2), in_node, "CMF_2");
    TRS.copy(CPSMMNTSTS.CMF_3, sizeof(CPSMMNTSTS.CMF_3), in_node, "CMF_3");
    TRS.copy(CPSMMNTSTS.CMF_4, sizeof(CPSMMNTSTS.CMF_4), in_node, "CMF_4");
    TRS.copy(CPSMMNTSTS.CMF_5, sizeof(CPSMMNTSTS.CMF_5), in_node, "CMF_5");
    TRS.copy(CPSMMNTSTS.CMF_6, sizeof(CPSMMNTSTS.CMF_6), in_node, "CMF_6");
    TRS.copy(CPSMMNTSTS.CMF_7, sizeof(CPSMMNTSTS.CMF_7), in_node, "CMF_7");
    TRS.copy(CPSMMNTSTS.CMF_8, sizeof(CPSMMNTSTS.CMF_8), in_node, "CMF_8");
    TRS.copy(CPSMMNTSTS.CMF_9, sizeof(CPSMMNTSTS.CMF_9), in_node, "CMF_9");
    TRS.copy(CPSMMNTSTS.CMF_10, sizeof(CPSMMNTSTS.CMF_10), in_node, "CMF_10");
    TRS.copy(CPSMMNTSTS.CREATE_USER_ID, sizeof(CPSMMNTSTS.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CPSMMNTSTS.CREATE_TIME, sizeof(CPSMMNTSTS.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CPSMMNTSTS.UPDATE_USER_ID, sizeof(CPSMMNTSTS.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CPSMMNTSTS.UPDATE_TIME, sizeof(CPSMMNTSTS.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CPSMMNTSTS.CREATE_USER_ID, sizeof(CPSMMNTSTS.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CPSMMNTSTS.CREATE_TIME, s_sys_time, sizeof(CPSMMNTSTS.CREATE_TIME));
        CDB_insert_cpsmmntsts(&CPSMMNTSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CPSM-0004");
            TRS.add_fieldmsg(out_node, "CPSMMNTSTS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
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
        CDB_init_cpsmmntsts(&CPSMMNTSTS_o);
        TRS.copy(CPSMMNTSTS_o.FACTORY, sizeof(CPSMMNTSTS_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CPSMMNTSTS_o.CATEGORY, sizeof(CPSMMNTSTS_o.CATEGORY), in_node, "CATEGORY");
        TRS.copy(CPSMMNTSTS_o.BASE_CODE, sizeof(CPSMMNTSTS_o.BASE_CODE), in_node, "BASE_CODE");
        TRS.copy(CPSMMNTSTS_o.SUB_CODE, sizeof(CPSMMNTSTS_o.SUB_CODE), in_node, "SUB_CODE");
        CDB_select_cpsmmntsts_for_update(1, &CPSMMNTSTS_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CPSM-0004");
            TRS.add_fieldmsg(out_node, "CPSMMNTSTS SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS_o.FACTORY), CPSMMNTSTS_o.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS_o.CATEGORY), CPSMMNTSTS_o.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS_o.BASE_CODE), CPSMMNTSTS_o.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS_o.SUB_CODE), CPSMMNTSTS_o.SUB_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CPSMMNTSTS.CREATE_USER_ID, CPSMMNTSTS_o.CREATE_USER_ID, sizeof(CPSMMNTSTS.CREATE_USER_ID));
        memcpy(CPSMMNTSTS.CREATE_TIME, CPSMMNTSTS_o.CREATE_TIME, sizeof(CPSMMNTSTS.CREATE_TIME));
        TRS.copy(CPSMMNTSTS.UPDATE_USER_ID, sizeof(CPSMMNTSTS.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CPSMMNTSTS.UPDATE_TIME, s_sys_time, sizeof(CPSMMNTSTS.UPDATE_TIME));

        CDB_update_cpsmmntsts(1, &CPSMMNTSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CPSMMNTSTS UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
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
        CDB_delete_cpsmmntsts(1, &CPSMMNTSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CPSMMNTSTS DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CPSM", "CPSM_Update_Prod_Monitoring",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CPSM_Update_Prod_Monitoring_Validation()
        - Main sub function of "CPSM_UPDATE_PROD_MONITORING" function
        - Check the condition for create/update/delete Prod_Monitoring
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_Update_Prod_Monitoring_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CPSMMNTSTS_TAG CPSMMNTSTS;
    //struct MWIPFACDEF_TAG MWIPFACDEF;

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

    //DBC_init_mwipfacdef(&MWIPFACDEF);
    //TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    //DBC_select_mwipfacdef(1, &MWIPFACDEF);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    strcpy(s_msg_code, "WIP-0005");
    //    TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
    //    TRS.add_dberrmsg(out_node, DB_error_msg);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    return MP_FALSE;
    //}

    /* CATEGORY Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CATEGORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "CATEGORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* BASE_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "BASE_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "BASE_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* SUB_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SUB_CODE")) == MP_TRUE)
    {
		TRS.set_nstring(in_node, "SUB_CODE", " ");
        /*strcpy(s_msg_code, "CPSM-0001");
        TRS.add_fieldmsg(out_node, "SUB_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;*/
    }

    CDB_init_cpsmmntsts(&CPSMMNTSTS);
    TRS.copy(CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY), in_node, "CATEGORY");
    TRS.copy(CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE), in_node, "BASE_CODE");
    TRS.copy(CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE), in_node, "SUB_CODE");
    CDB_select_cpsmmntsts(1, &CPSMMNTSTS);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0018");
            TRS.add_fieldmsg(out_node, "CPSMMNTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
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
                strcpy(s_msg_code, "CMN-0004");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CMN-0003");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CPSMMNTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

