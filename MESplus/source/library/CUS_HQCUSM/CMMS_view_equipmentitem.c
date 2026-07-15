/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_equipmentitem.c
    Description : View EquipmentItem function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_EquipmentItem()
            + View EquipmentItem definition
        - CMMS_VIEW_EQUIPMENTITEM()
            + Main sub function of CMMS_View_EquipmentItem function
            + View EquipmentItem definition
    Detail Description
        - CMMS_VIEW_EQUIPMENTITEM()
            + h_proc_step
                + 1 : View EquipmentItem definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-21             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_EquipmentItem()
        - View EquipmentItem definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_EquipmentItem(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_EQUIPMENTITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_EQUIPMENTITEM", out_node);

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
    CMMS_VIEW_EQUIPMENTITEM()
        - Main sub function of "CMMS_View_EquipmentItem" function
        - View EquipmentItem definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_EQUIPMENTITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSINSDEF_TAG CMMSINSDEF;

    LOG_head("CMMS_VIEW_EQUIPMENTITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("insti_code", MP_NSTR, TRS.get_string(in_node, "INSTI_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_EquipmentItem",
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
        strcpy(s_msg_code, "CMMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* INSTI_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "INSTI_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMMS-0001");
        TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsinsdef(&CMMSINSDEF);
    TRS.copy(CMMSINSDEF.FACTORY, sizeof(CMMSINSDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE), in_node, "INSTI_CODE");
    CDB_select_cmmsinsdef(1, &CMMSINSDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMMS-9999");
        TRS.add_fieldmsg(out_node, "CMMSINSDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CMMSINSDEF.FACTORY, sizeof(CMMSINSDEF.FACTORY));
    TRS.add_string(out_node, "INSTI_CODE", CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE));
    TRS.add_string(out_node, "INSTI_NAME", CMMSINSDEF.INSTI_NAME, sizeof(CMMSINSDEF.INSTI_NAME));
    TRS.add_char(out_node, "CALI_DIV", CMMSINSDEF.CALI_DIV);
    TRS.add_string(out_node, "ADDRESS", CMMSINSDEF.ADDRESS, sizeof(CMMSINSDEF.ADDRESS));
    TRS.add_string(out_node, "CERTIFICATE_NAME", CMMSINSDEF.CERTIFICATE_NAME, sizeof(CMMSINSDEF.CERTIFICATE_NAME));
    TRS.add_string(out_node, "CERTIFICATE_NO", CMMSINSDEF.CERTIFICATE_NO, sizeof(CMMSINSDEF.CERTIFICATE_NO));
    TRS.add_string(out_node, "CERTIFICATE_PART", CMMSINSDEF.CERTIFICATE_PART, sizeof(CMMSINSDEF.CERTIFICATE_PART));
    TRS.add_string(out_node, "CERTIFICATE_AGENCY", CMMSINSDEF.CERTIFICATE_AGENCY, sizeof(CMMSINSDEF.CERTIFICATE_AGENCY));
    TRS.add_string(out_node, "ISSUE_DATE", CMMSINSDEF.ISSUE_DATE, sizeof(CMMSINSDEF.ISSUE_DATE));
    TRS.add_string(out_node, "FIRST_ISSUE_DATE", CMMSINSDEF.FIRST_ISSUE_DATE, sizeof(CMMSINSDEF.FIRST_ISSUE_DATE));
    TRS.add_string(out_node, "EXPIRE_START_DATE", CMMSINSDEF.EXPIRE_START_DATE, sizeof(CMMSINSDEF.EXPIRE_START_DATE));
    TRS.add_string(out_node, "EXPIRE_END_DATE", CMMSINSDEF.EXPIRE_END_DATE, sizeof(CMMSINSDEF.EXPIRE_END_DATE));
    TRS.add_string(out_node, "FILE_NAME", CMMSINSDEF.FILE_NAME, sizeof(CMMSINSDEF.FILE_NAME));
    TRS.add_string(out_node, "FILE_PATH", CMMSINSDEF.FILE_PATH, sizeof(CMMSINSDEF.FILE_PATH));
    TRS.add_char(out_node, "USE_FLAG", CMMSINSDEF.USE_FLAG);
    TRS.add_string(out_node, "CMF_1", CMMSINSDEF.CMF_1, sizeof(CMMSINSDEF.CMF_1));
    TRS.add_string(out_node, "CMF_2", CMMSINSDEF.CMF_2, sizeof(CMMSINSDEF.CMF_2));
    TRS.add_string(out_node, "CMF_3", CMMSINSDEF.CMF_3, sizeof(CMMSINSDEF.CMF_3));
    TRS.add_string(out_node, "CMF_4", CMMSINSDEF.CMF_4, sizeof(CMMSINSDEF.CMF_4));
    TRS.add_string(out_node, "CMF_5", CMMSINSDEF.CMF_5, sizeof(CMMSINSDEF.CMF_5));
    TRS.add_string(out_node, "CMF_6", CMMSINSDEF.CMF_6, sizeof(CMMSINSDEF.CMF_6));
    TRS.add_string(out_node, "CMF_7", CMMSINSDEF.CMF_7, sizeof(CMMSINSDEF.CMF_7));
    TRS.add_string(out_node, "CMF_8", CMMSINSDEF.CMF_8, sizeof(CMMSINSDEF.CMF_8));
    TRS.add_string(out_node, "CMF_9", CMMSINSDEF.CMF_9, sizeof(CMMSINSDEF.CMF_9));
    TRS.add_string(out_node, "CMF_10", CMMSINSDEF.CMF_10, sizeof(CMMSINSDEF.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSINSDEF.CREATE_USER_ID, sizeof(CMMSINSDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSINSDEF.CREATE_TIME, sizeof(CMMSINSDEF.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSINSDEF.UPDATE_USER_ID, sizeof(CMMSINSDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSINSDEF.UPDATE_TIME, sizeof(CMMSINSDEF.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_EquipmentItem",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

