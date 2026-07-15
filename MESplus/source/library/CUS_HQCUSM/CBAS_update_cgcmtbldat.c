/******************************************************************************'

    System      : MESplus
    Module      : CBAS
    File Name   : CBAS_update_cgcmtbldat.c
    Description : CGCMTBLDAT Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CBAS_Update_CGCMTBLDAT()
            + Create/Update/Delete CGCMTBLDAT definition
        - CBAS_UPDATE_CGCMTBLDAT()
            + Main sub function of CBAS_Update_CGCMTBLDAT function
            + Create/Update/Delete CGCMTBLDAT definition
        - CBAS_Update_CGCMTBLDAT_Validation()
            + Main sub function of CBAS_UPDATE_CGCMTBLDAT function
            + Check the condition for create/update/delete CGCMTBLDAT
    Detail Description
        - CBAS_UPDATE_CGCMTBLDAT()
            + h_proc_step
                + MP_STEP_CREATE : Create CGCMTBLDAT definition
                + MP_STEP_UPDATE : Update CGCMTBLDAT definition
                + MP_STEP_DELETE : Delete CGCMTBLDAT definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-06-24             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#define MP_SIZE_MSG (10)
int CBAS_Update_CGCMTBLDAT_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CBAS_Update_CGCMTBLDAT()
        - Create/Update/Delete CGCMTBLDAT definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_Update_CGCMTBLDAT(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CBAS_UPDATE_CGCMTBLDAT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CBAS_UPDATE_CGCMTBLDAT", out_node);

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
    CBAS_UPDATE_CGCMTBLDAT()
        - Main sub function of "CBAS_Update_CGCMTBLDAT" function
        - Create/Update/Delete CGCMTBLDAT definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_UPDATE_CGCMTBLDAT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CGCMTBLDAT_TAG CGCMTBLDAT;
    struct CGCMTBLDAT_TAG CGCMTBLDAT_o;
    char   s_sys_time[14];

    LOG_head("CBAS_UPDATE_CGCMTBLDAT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("type_1", MP_NSTR, TRS.get_string(in_node, "TYPE_1"));
    LOG_add("type_2", MP_NSTR, TRS.get_string(in_node, "TYPE_2"));
    LOG_add("type_3", MP_NSTR, TRS.get_string(in_node, "TYPE_3"));
    LOG_add("type_4", MP_NSTR, TRS.get_string(in_node, "TYPE_4"));
    LOG_add("type_5", MP_NSTR, TRS.get_string(in_node, "TYPE_5"));
    LOG_add("type_6", MP_NSTR, TRS.get_string(in_node, "TYPE_6"));
    LOG_add("type_7", MP_NSTR, TRS.get_string(in_node, "TYPE_7"));
    LOG_add("type_8", MP_NSTR, TRS.get_string(in_node, "TYPE_8"));
    LOG_add("type_9", MP_NSTR, TRS.get_string(in_node, "TYPE_9"));
    LOG_add("data_1", MP_NSTR, TRS.get_string(in_node, "DATA_1"));
    LOG_add("data_2", MP_NSTR, TRS.get_string(in_node, "DATA_2"));
    LOG_add("data_3", MP_NSTR, TRS.get_string(in_node, "DATA_3"));
    LOG_add("data_4", MP_NSTR, TRS.get_string(in_node, "DATA_4"));
    LOG_add("data_5", MP_NSTR, TRS.get_string(in_node, "DATA_5"));
    LOG_add("data_6", MP_NSTR, TRS.get_string(in_node, "DATA_6"));
    LOG_add("data_7", MP_NSTR, TRS.get_string(in_node, "DATA_7"));
    LOG_add("data_8", MP_NSTR, TRS.get_string(in_node, "DATA_8"));
    LOG_add("data_9", MP_NSTR, TRS.get_string(in_node, "DATA_9"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CBAS", "CBAS_Update_CGCMTBLDAT",
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

    if(CBAS_Update_CGCMTBLDAT_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cgcmtbldat(&CGCMTBLDAT);
    TRS.copy(CGCMTBLDAT.FACTORY, sizeof(CGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CGCMTBLDAT.TYPE_1, sizeof(CGCMTBLDAT.TYPE_1), in_node, "TYPE_1");
    TRS.copy(CGCMTBLDAT.TYPE_2, sizeof(CGCMTBLDAT.TYPE_2), in_node, "TYPE_2");
    TRS.copy(CGCMTBLDAT.TYPE_3, sizeof(CGCMTBLDAT.TYPE_3), in_node, "TYPE_3");
    TRS.copy(CGCMTBLDAT.TYPE_4, sizeof(CGCMTBLDAT.TYPE_4), in_node, "TYPE_4");
    TRS.copy(CGCMTBLDAT.TYPE_5, sizeof(CGCMTBLDAT.TYPE_5), in_node, "TYPE_5");
    TRS.copy(CGCMTBLDAT.TYPE_6, sizeof(CGCMTBLDAT.TYPE_6), in_node, "TYPE_6");
    TRS.copy(CGCMTBLDAT.TYPE_7, sizeof(CGCMTBLDAT.TYPE_7), in_node, "TYPE_7");
    TRS.copy(CGCMTBLDAT.TYPE_8, sizeof(CGCMTBLDAT.TYPE_8), in_node, "TYPE_8");
    TRS.copy(CGCMTBLDAT.TYPE_9, sizeof(CGCMTBLDAT.TYPE_9), in_node, "TYPE_9");
    TRS.copy(CGCMTBLDAT.DATA_1, sizeof(CGCMTBLDAT.DATA_1), in_node, "DATA_1");
    TRS.copy(CGCMTBLDAT.DATA_2, sizeof(CGCMTBLDAT.DATA_2), in_node, "DATA_2");
    TRS.copy(CGCMTBLDAT.DATA_3, sizeof(CGCMTBLDAT.DATA_3), in_node, "DATA_3");
    TRS.copy(CGCMTBLDAT.DATA_4, sizeof(CGCMTBLDAT.DATA_4), in_node, "DATA_4");
    TRS.copy(CGCMTBLDAT.DATA_5, sizeof(CGCMTBLDAT.DATA_5), in_node, "DATA_5");
    TRS.copy(CGCMTBLDAT.DATA_6, sizeof(CGCMTBLDAT.DATA_6), in_node, "DATA_6");
    TRS.copy(CGCMTBLDAT.DATA_7, sizeof(CGCMTBLDAT.DATA_7), in_node, "DATA_7");
    TRS.copy(CGCMTBLDAT.DATA_8, sizeof(CGCMTBLDAT.DATA_8), in_node, "DATA_8");
    TRS.copy(CGCMTBLDAT.DATA_9, sizeof(CGCMTBLDAT.DATA_9), in_node, "DATA_9");
    TRS.copy(CGCMTBLDAT.CREATE_USER_ID, sizeof(CGCMTBLDAT.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CGCMTBLDAT.CREATE_TIME, sizeof(CGCMTBLDAT.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CGCMTBLDAT.UPDATE_USER_ID, sizeof(CGCMTBLDAT.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CGCMTBLDAT.UPDATE_TIME, sizeof(CGCMTBLDAT.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CGCMTBLDAT.CREATE_USER_ID, sizeof(CGCMTBLDAT.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CGCMTBLDAT.CREATE_TIME, s_sys_time, sizeof(CGCMTBLDAT.CREATE_TIME));
        CDB_insert_cgcmtbldat(&CGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CBAS-0004");
            TRS.add_fieldmsg(out_node, "CGCMTBLDAT INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CGCMTBLDAT.FACTORY), CGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TYPE_1", MP_STR, sizeof(CGCMTBLDAT.TYPE_1), CGCMTBLDAT.TYPE_1);
            TRS.add_fieldmsg(out_node, "TYPE_2", MP_STR, sizeof(CGCMTBLDAT.TYPE_2), CGCMTBLDAT.TYPE_2);
            TRS.add_fieldmsg(out_node, "TYPE_3", MP_STR, sizeof(CGCMTBLDAT.TYPE_3), CGCMTBLDAT.TYPE_3);
            TRS.add_fieldmsg(out_node, "TYPE_4", MP_STR, sizeof(CGCMTBLDAT.TYPE_4), CGCMTBLDAT.TYPE_4);
            TRS.add_fieldmsg(out_node, "TYPE_5", MP_STR, sizeof(CGCMTBLDAT.TYPE_5), CGCMTBLDAT.TYPE_5);
            TRS.add_fieldmsg(out_node, "TYPE_6", MP_STR, sizeof(CGCMTBLDAT.TYPE_6), CGCMTBLDAT.TYPE_6);
            TRS.add_fieldmsg(out_node, "TYPE_7", MP_STR, sizeof(CGCMTBLDAT.TYPE_7), CGCMTBLDAT.TYPE_7);
            TRS.add_fieldmsg(out_node, "TYPE_8", MP_STR, sizeof(CGCMTBLDAT.TYPE_8), CGCMTBLDAT.TYPE_8);
            TRS.add_fieldmsg(out_node, "TYPE_9", MP_STR, sizeof(CGCMTBLDAT.TYPE_9), CGCMTBLDAT.TYPE_9);
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
        CDB_init_cgcmtbldat(&CGCMTBLDAT_o);
        TRS.copy(CGCMTBLDAT_o.FACTORY, sizeof(CGCMTBLDAT_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CGCMTBLDAT_o.TYPE_1, sizeof(CGCMTBLDAT_o.TYPE_1), in_node, "TYPE_1");
        TRS.copy(CGCMTBLDAT_o.TYPE_2, sizeof(CGCMTBLDAT_o.TYPE_2), in_node, "TYPE_2");
        TRS.copy(CGCMTBLDAT_o.TYPE_3, sizeof(CGCMTBLDAT_o.TYPE_3), in_node, "TYPE_3");
        TRS.copy(CGCMTBLDAT_o.TYPE_4, sizeof(CGCMTBLDAT_o.TYPE_4), in_node, "TYPE_4");
        TRS.copy(CGCMTBLDAT_o.TYPE_5, sizeof(CGCMTBLDAT_o.TYPE_5), in_node, "TYPE_5");
        TRS.copy(CGCMTBLDAT_o.TYPE_6, sizeof(CGCMTBLDAT_o.TYPE_6), in_node, "TYPE_6");
        TRS.copy(CGCMTBLDAT_o.TYPE_7, sizeof(CGCMTBLDAT_o.TYPE_7), in_node, "TYPE_7");
        TRS.copy(CGCMTBLDAT_o.TYPE_8, sizeof(CGCMTBLDAT_o.TYPE_8), in_node, "TYPE_8");
        TRS.copy(CGCMTBLDAT_o.TYPE_9, sizeof(CGCMTBLDAT_o.TYPE_9), in_node, "TYPE_9");
        CDB_select_cgcmtbldat_for_update(1, &CGCMTBLDAT_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CBAS-0004");
            TRS.add_fieldmsg(out_node, "CGCMTBLDAT SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CGCMTBLDAT_o.FACTORY), CGCMTBLDAT_o.FACTORY);
            TRS.add_fieldmsg(out_node, "TYPE_1", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_1), CGCMTBLDAT_o.TYPE_1);
            TRS.add_fieldmsg(out_node, "TYPE_2", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_2), CGCMTBLDAT_o.TYPE_2);
            TRS.add_fieldmsg(out_node, "TYPE_3", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_3), CGCMTBLDAT_o.TYPE_3);
            TRS.add_fieldmsg(out_node, "TYPE_4", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_4), CGCMTBLDAT_o.TYPE_4);
            TRS.add_fieldmsg(out_node, "TYPE_5", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_5), CGCMTBLDAT_o.TYPE_5);
            TRS.add_fieldmsg(out_node, "TYPE_6", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_6), CGCMTBLDAT_o.TYPE_6);
            TRS.add_fieldmsg(out_node, "TYPE_7", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_7), CGCMTBLDAT_o.TYPE_7);
            TRS.add_fieldmsg(out_node, "TYPE_8", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_8), CGCMTBLDAT_o.TYPE_8);
            TRS.add_fieldmsg(out_node, "TYPE_9", MP_STR, sizeof(CGCMTBLDAT_o.TYPE_9), CGCMTBLDAT_o.TYPE_9);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CGCMTBLDAT.CREATE_USER_ID, CGCMTBLDAT_o.CREATE_USER_ID, sizeof(CGCMTBLDAT.CREATE_USER_ID));
        memcpy(CGCMTBLDAT.CREATE_TIME, CGCMTBLDAT_o.CREATE_TIME, sizeof(CGCMTBLDAT.CREATE_TIME));
        TRS.copy(CGCMTBLDAT.UPDATE_USER_ID, sizeof(CGCMTBLDAT.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CGCMTBLDAT.UPDATE_TIME, s_sys_time, sizeof(CGCMTBLDAT.UPDATE_TIME));

        CDB_update_cgcmtbldat(1, &CGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CBAS-0004");
            TRS.add_fieldmsg(out_node, "CGCMTBLDAT UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CGCMTBLDAT.FACTORY), CGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TYPE_1", MP_STR, sizeof(CGCMTBLDAT.TYPE_1), CGCMTBLDAT.TYPE_1);
            TRS.add_fieldmsg(out_node, "TYPE_2", MP_STR, sizeof(CGCMTBLDAT.TYPE_2), CGCMTBLDAT.TYPE_2);
            TRS.add_fieldmsg(out_node, "TYPE_3", MP_STR, sizeof(CGCMTBLDAT.TYPE_3), CGCMTBLDAT.TYPE_3);
            TRS.add_fieldmsg(out_node, "TYPE_4", MP_STR, sizeof(CGCMTBLDAT.TYPE_4), CGCMTBLDAT.TYPE_4);
            TRS.add_fieldmsg(out_node, "TYPE_5", MP_STR, sizeof(CGCMTBLDAT.TYPE_5), CGCMTBLDAT.TYPE_5);
            TRS.add_fieldmsg(out_node, "TYPE_6", MP_STR, sizeof(CGCMTBLDAT.TYPE_6), CGCMTBLDAT.TYPE_6);
            TRS.add_fieldmsg(out_node, "TYPE_7", MP_STR, sizeof(CGCMTBLDAT.TYPE_7), CGCMTBLDAT.TYPE_7);
            TRS.add_fieldmsg(out_node, "TYPE_8", MP_STR, sizeof(CGCMTBLDAT.TYPE_8), CGCMTBLDAT.TYPE_8);
            TRS.add_fieldmsg(out_node, "TYPE_9", MP_STR, sizeof(CGCMTBLDAT.TYPE_9), CGCMTBLDAT.TYPE_9);
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
        CDB_delete_cgcmtbldat(1, &CGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CBAS-0004");
            TRS.add_fieldmsg(out_node, "CGCMTBLDAT DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CGCMTBLDAT.FACTORY), CGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TYPE_1", MP_STR, sizeof(CGCMTBLDAT.TYPE_1), CGCMTBLDAT.TYPE_1);
            TRS.add_fieldmsg(out_node, "TYPE_2", MP_STR, sizeof(CGCMTBLDAT.TYPE_2), CGCMTBLDAT.TYPE_2);
            TRS.add_fieldmsg(out_node, "TYPE_3", MP_STR, sizeof(CGCMTBLDAT.TYPE_3), CGCMTBLDAT.TYPE_3);
            TRS.add_fieldmsg(out_node, "TYPE_4", MP_STR, sizeof(CGCMTBLDAT.TYPE_4), CGCMTBLDAT.TYPE_4);
            TRS.add_fieldmsg(out_node, "TYPE_5", MP_STR, sizeof(CGCMTBLDAT.TYPE_5), CGCMTBLDAT.TYPE_5);
            TRS.add_fieldmsg(out_node, "TYPE_6", MP_STR, sizeof(CGCMTBLDAT.TYPE_6), CGCMTBLDAT.TYPE_6);
            TRS.add_fieldmsg(out_node, "TYPE_7", MP_STR, sizeof(CGCMTBLDAT.TYPE_7), CGCMTBLDAT.TYPE_7);
            TRS.add_fieldmsg(out_node, "TYPE_8", MP_STR, sizeof(CGCMTBLDAT.TYPE_8), CGCMTBLDAT.TYPE_8);
            TRS.add_fieldmsg(out_node, "TYPE_9", MP_STR, sizeof(CGCMTBLDAT.TYPE_9), CGCMTBLDAT.TYPE_9);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CBAS", "CBAS_Update_CGCMTBLDAT",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CBAS_Update_CGCMTBLDAT_Validation()
        - Main sub function of "CBAS_UPDATE_CGCMTBLDAT" function
        - Check the condition for create/update/delete CGCMTBLDAT
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_Update_CGCMTBLDAT_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CGCMTBLDAT_TAG CGCMTBLDAT;
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
        strcpy(s_msg_code, "CBAS-0001");
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

    /* TYPE_1 Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "TYPE_1")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CBAS-0001");
        TRS.add_fieldmsg(out_node, "TYPE_1", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    return MP_TRUE;
}

