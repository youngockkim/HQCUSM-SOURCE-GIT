/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_scraplb_tb.c
    Description : ScrapLb_Tb Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_ScrapLb_Tb()
            + Create/Update/Delete ScrapLb_Tb definition
        - CWIP_UPDATE_SCRAPLB_TB()
            + Main sub function of CWIP_Update_ScrapLb_Tb function
            + Create/Update/Delete ScrapLb_Tb definition
        - CWIP_Update_ScrapLb_Tb_Validation()
            + Main sub function of CWIP_UPDATE_SCRAPLB_TB function
            + Check the condition for create/update/delete ScrapLb_Tb
    Detail Description
        - CWIP_UPDATE_SCRAPLB_TB()
            + h_proc_step
                + MP_STEP_CREATE : Create ScrapLb_Tb definition
                + MP_STEP_UPDATE : Update ScrapLb_Tb definition
                + MP_STEP_DELETE : Delete ScrapLb_Tb definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-11             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_ScrapLb_Tb_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_ScrapLb_Tb()
        - Create/Update/Delete ScrapLb_Tb definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_ScrapLb_Tb(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_SCRAPLB_TB(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_SCRAPLB_TB", out_node);

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
    CWIP_UPDATE_SCRAPLB_TB()
        - Main sub function of "CWIP_Update_ScrapLb_Tb" function
        - Create/Update/Delete ScrapLb_Tb definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_SCRAPLB_TB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOSTAB_TAG CWIPLOSTAB;
    struct CWIPLOSTAB_TAG CWIPLOSTAB_o;
    char   s_sys_time[14];

    LOG_head("CWIP_UPDATE_SCRAPLB_TB");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("oper_id", MP_NSTR, TRS.get_string(in_node, "OPER_ID"));
    LOG_add("oper_sub_id", MP_NSTR, TRS.get_string(in_node, "OPER_SUB_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("operator_id", MP_NSTR, TRS.get_string(in_node, "OPERATOR_ID"));
    LOG_add("loss_qty", MP_DBL, TRS.get_double(in_node, "LOSS_QTY"));
    LOG_add("loss_cause", MP_NSTR, TRS.get_string(in_node, "LOSS_CAUSE"));
    LOG_add("loss_comment", MP_NSTR, TRS.get_string(in_node, "LOSS_COMMENT"));
    LOG_add("loss_lb", MP_NSTR, TRS.get_string(in_node, "LOSS_LB"));
    LOG_add("loss_lb_check", MP_NSTR, TRS.get_string(in_node, "LOSS_LB_CHECK"));
    LOG_add("box_use", MP_NSTR, TRS.get_string(in_node, "BOX_USE"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_ScrapLb_Tb",
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

    if(CWIP_Update_ScrapLb_Tb_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplostab(&CWIPLOSTAB);
    TRS.copy(CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID), in_node, "RES_ID");
    TRS.copy(CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID), in_node, "OPER_ID");
    TRS.copy(CWIPLOSTAB.OPER_SUB_ID, sizeof(CWIPLOSTAB.OPER_SUB_ID), in_node, "OPER_SUB_ID");
    TRS.copy(CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID), in_node, "OPERATOR_ID");
    CWIPLOSTAB.LOSS_QTY = TRS.get_double(in_node, "LOSS_QTY");
    TRS.copy(CWIPLOSTAB.LOSS_CAUSE, sizeof(CWIPLOSTAB.LOSS_CAUSE), in_node, "LOSS_CAUSE");
    TRS.copy(CWIPLOSTAB.LOSS_COMMENT, sizeof(CWIPLOSTAB.LOSS_COMMENT), in_node, "LOSS_COMMENT");
    TRS.copy(CWIPLOSTAB.LOSS_LB, sizeof(CWIPLOSTAB.LOSS_LB), in_node, "LOSS_LB");
    TRS.copy(CWIPLOSTAB.LOSS_LB_CHECK, sizeof(CWIPLOSTAB.LOSS_LB_CHECK), in_node, "LOSS_LB_CHECK");
    TRS.copy(CWIPLOSTAB.BOX_USE, sizeof(CWIPLOSTAB.BOX_USE), in_node, "BOX_USE");
    TRS.copy(CWIPLOSTAB.CREATE_USER_ID, sizeof(CWIPLOSTAB.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPLOSTAB.CREATE_TIME, sizeof(CWIPLOSTAB.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPLOSTAB.UPDATE_USER_ID, sizeof(CWIPLOSTAB.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPLOSTAB.UPDATE_TIME, sizeof(CWIPLOSTAB.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CWIPLOSTAB.CREATE_USER_ID, sizeof(CWIPLOSTAB.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPLOSTAB.CREATE_TIME, s_sys_time, sizeof(CWIPLOSTAB.CREATE_TIME));
        CDB_insert_cwiplostab(&CWIPLOSTAB);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOSTAB INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
            TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_ID), CWIPLOSTAB.OPER_ID);
            TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_SUB_ID), CWIPLOSTAB.OPER_SUB_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_STR, sizeof(CWIPLOSTAB.OPERATOR_ID), CWIPLOSTAB.OPERATOR_ID);
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
        CDB_init_cwiplostab(&CWIPLOSTAB_o);
        TRS.copy(CWIPLOSTAB_o.WORK_DATE, sizeof(CWIPLOSTAB_o.WORK_DATE), in_node, "WORK_DATE");
        TRS.copy(CWIPLOSTAB_o.FACTORY, sizeof(CWIPLOSTAB_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CWIPLOSTAB_o.LINE_ID, sizeof(CWIPLOSTAB_o.LINE_ID), in_node, "LINE_ID");
        TRS.copy(CWIPLOSTAB_o.RES_ID, sizeof(CWIPLOSTAB_o.RES_ID), in_node, "RES_ID");
        TRS.copy(CWIPLOSTAB_o.OPER_ID, sizeof(CWIPLOSTAB_o.OPER_ID), in_node, "OPER_ID");
        TRS.copy(CWIPLOSTAB_o.OPER_SUB_ID, sizeof(CWIPLOSTAB_o.OPER_SUB_ID), in_node, "OPER_SUB_ID");
        TRS.copy(CWIPLOSTAB_o.WORK_SHIFT, sizeof(CWIPLOSTAB_o.WORK_SHIFT), in_node, "WORK_SHIFT");
        TRS.copy(CWIPLOSTAB_o.OPERATOR_ID, sizeof(CWIPLOSTAB_o.OPERATOR_ID), in_node, "OPERATOR_ID");
        CDB_select_cwiplostab_for_update(1, &CWIPLOSTAB_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOSTAB SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB_o.WORK_DATE), CWIPLOSTAB_o.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB_o.FACTORY), CWIPLOSTAB_o.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB_o.LINE_ID), CWIPLOSTAB_o.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB_o.RES_ID), CWIPLOSTAB_o.RES_ID);
            TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(CWIPLOSTAB_o.OPER_ID), CWIPLOSTAB_o.OPER_ID);
            TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_STR, sizeof(CWIPLOSTAB_o.OPER_SUB_ID), CWIPLOSTAB_o.OPER_SUB_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB_o.WORK_SHIFT), CWIPLOSTAB_o.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_STR, sizeof(CWIPLOSTAB_o.OPERATOR_ID), CWIPLOSTAB_o.OPERATOR_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CWIPLOSTAB.CREATE_USER_ID, CWIPLOSTAB_o.CREATE_USER_ID, sizeof(CWIPLOSTAB.CREATE_USER_ID));
        memcpy(CWIPLOSTAB.CREATE_TIME, CWIPLOSTAB_o.CREATE_TIME, sizeof(CWIPLOSTAB.CREATE_TIME));
        TRS.copy(CWIPLOSTAB.UPDATE_USER_ID, sizeof(CWIPLOSTAB.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPLOSTAB.UPDATE_TIME, s_sys_time, sizeof(CWIPLOSTAB.UPDATE_TIME));

        CDB_update_cwiplostab(1, &CWIPLOSTAB);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOSTAB UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
            TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_ID), CWIPLOSTAB.OPER_ID);
            TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_SUB_ID), CWIPLOSTAB.OPER_SUB_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_STR, sizeof(CWIPLOSTAB.OPERATOR_ID), CWIPLOSTAB.OPERATOR_ID);
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
        CDB_delete_cwiplostab(1, &CWIPLOSTAB);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOSTAB DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
            TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_ID), CWIPLOSTAB.OPER_ID);
            TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_SUB_ID), CWIPLOSTAB.OPER_SUB_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_STR, sizeof(CWIPLOSTAB.OPERATOR_ID), CWIPLOSTAB.OPERATOR_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_ScrapLb_Tb",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_ScrapLb_Tb_Validation()
        - Main sub function of "CWIP_UPDATE_SCRAPLB_TB" function
        - Check the condition for create/update/delete ScrapLb_Tb
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_ScrapLb_Tb_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOSTAB_TAG CWIPLOSTAB;
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
        strcpy(s_msg_code, "CWIP-0001");
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

    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* RES_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* OPER_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "OPER_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "OPER_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* OPER_SUB_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "OPER_SUB_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_SHIFT Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* OPERATOR_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "OPERATOR_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplostab(&CWIPLOSTAB);
    TRS.copy(CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID), in_node, "RES_ID");
    TRS.copy(CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID), in_node, "OPER_ID");
    TRS.copy(CWIPLOSTAB.OPER_SUB_ID, sizeof(CWIPLOSTAB.OPER_SUB_ID), in_node, "OPER_SUB_ID");
    TRS.copy(CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID), in_node, "OPERATOR_ID");
    CDB_select_cwiplostab(1, &CWIPLOSTAB);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-XXXX");
            TRS.add_fieldmsg(out_node, "CWIPLOSTAB SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
            TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_ID), CWIPLOSTAB.OPER_ID);
            TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_SUB_ID), CWIPLOSTAB.OPER_SUB_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_STR, sizeof(CWIPLOSTAB.OPERATOR_ID), CWIPLOSTAB.OPERATOR_ID);
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
                strcpy(s_msg_code, "CWIP-XXXX");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CWIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CWIPLOSTAB SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
            TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_ID), CWIPLOSTAB.OPER_ID);
            TRS.add_fieldmsg(out_node, "OPER_SUB_ID", MP_STR, sizeof(CWIPLOSTAB.OPER_SUB_ID), CWIPLOSTAB.OPER_SUB_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "OPERATOR_ID", MP_STR, sizeof(CWIPLOSTAB.OPERATOR_ID), CWIPLOSTAB.OPERATOR_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

