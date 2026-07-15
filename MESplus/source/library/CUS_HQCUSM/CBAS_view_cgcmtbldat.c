/******************************************************************************'

    System      : MESplus
    Module      : CBAS
    File Name   : CBAS_view_cgcmtbldat.c
    Description : View CGCMTBLDAT function module

    MES Version : 5.3.4 ~

    Function List
        - CBAS_View_CGCMTBLDAT()
            + View CGCMTBLDAT definition
        - CBAS_VIEW_CGCMTBLDAT()
            + Main sub function of CBAS_View_CGCMTBLDAT function
            + View CGCMTBLDAT definition
        - CBAS_View_CGCMTBLDAT_Validation()
            + Main sub function of CBAS_VIEW_CGCMTBLDAT function
            + Check the condition for view CGCMTBLDAT
    Detail Description
        - CBAS_VIEW_CGCMTBLDAT()
            + h_proc_step
                + 1 : View CGCMTBLDAT definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-06-24             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#define MP_SIZE_MSG (10)

int CBAS_View_CGCMTBLDAT_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CBAS_View_CGCMTBLDAT()
        - View CGCMTBLDAT definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_CGCMTBLDAT(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CBAS_VIEW_CGCMTBLDAT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CBAS_VIEW_CGCMTBLDAT", out_node);

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
    CBAS_VIEW_CGCMTBLDAT()
        - Main sub function of "CBAS_View_CGCMTBLDAT" function
        - View CGCMTBLDAT definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_VIEW_CGCMTBLDAT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CGCMTBLDAT_TAG CGCMTBLDAT;

    LOG_head("CBAS_VIEW_CGCMTBLDAT");
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
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CBAS", "CBAS_View_CGCMTBLDAT",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CBAS_View_CGCMTBLDAT_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
    CDB_select_cgcmtbldat(1, &CGCMTBLDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CBAS-9999");
        TRS.add_fieldmsg(out_node, "CGCMTBLDAT SELECT", MP_NVST);
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
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CGCMTBLDAT.FACTORY, sizeof(CGCMTBLDAT.FACTORY));
    TRS.add_string(out_node, "TYPE_1", CGCMTBLDAT.TYPE_1, sizeof(CGCMTBLDAT.TYPE_1));
    TRS.add_string(out_node, "TYPE_2", CGCMTBLDAT.TYPE_2, sizeof(CGCMTBLDAT.TYPE_2));
    TRS.add_string(out_node, "TYPE_3", CGCMTBLDAT.TYPE_3, sizeof(CGCMTBLDAT.TYPE_3));
    TRS.add_string(out_node, "TYPE_4", CGCMTBLDAT.TYPE_4, sizeof(CGCMTBLDAT.TYPE_4));
    TRS.add_string(out_node, "TYPE_5", CGCMTBLDAT.TYPE_5, sizeof(CGCMTBLDAT.TYPE_5));
    TRS.add_string(out_node, "TYPE_6", CGCMTBLDAT.TYPE_6, sizeof(CGCMTBLDAT.TYPE_6));
    TRS.add_string(out_node, "TYPE_7", CGCMTBLDAT.TYPE_7, sizeof(CGCMTBLDAT.TYPE_7));
    TRS.add_string(out_node, "TYPE_8", CGCMTBLDAT.TYPE_8, sizeof(CGCMTBLDAT.TYPE_8));
    TRS.add_string(out_node, "TYPE_9", CGCMTBLDAT.TYPE_9, sizeof(CGCMTBLDAT.TYPE_9));
    TRS.add_string(out_node, "DATA_1", CGCMTBLDAT.DATA_1, sizeof(CGCMTBLDAT.DATA_1));
    TRS.add_string(out_node, "DATA_2", CGCMTBLDAT.DATA_2, sizeof(CGCMTBLDAT.DATA_2));
    TRS.add_string(out_node, "DATA_3", CGCMTBLDAT.DATA_3, sizeof(CGCMTBLDAT.DATA_3));
    TRS.add_string(out_node, "DATA_4", CGCMTBLDAT.DATA_4, sizeof(CGCMTBLDAT.DATA_4));
    TRS.add_string(out_node, "DATA_5", CGCMTBLDAT.DATA_5, sizeof(CGCMTBLDAT.DATA_5));
    TRS.add_string(out_node, "DATA_6", CGCMTBLDAT.DATA_6, sizeof(CGCMTBLDAT.DATA_6));
    TRS.add_string(out_node, "DATA_7", CGCMTBLDAT.DATA_7, sizeof(CGCMTBLDAT.DATA_7));
    TRS.add_string(out_node, "DATA_8", CGCMTBLDAT.DATA_8, sizeof(CGCMTBLDAT.DATA_8));
    TRS.add_string(out_node, "DATA_9", CGCMTBLDAT.DATA_9, sizeof(CGCMTBLDAT.DATA_9));
    TRS.add_string(out_node, "CREATE_USER_ID", CGCMTBLDAT.CREATE_USER_ID, sizeof(CGCMTBLDAT.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CGCMTBLDAT.CREATE_TIME, sizeof(CGCMTBLDAT.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CGCMTBLDAT.UPDATE_USER_ID, sizeof(CGCMTBLDAT.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CGCMTBLDAT.UPDATE_TIME, sizeof(CGCMTBLDAT.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CBAS", "CBAS_View_CGCMTBLDAT",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CBAS_View_CGCMTBLDAT_Validation()
        - Main sub function of "CBAS_VIEW_CGCMTBLDAT" function
        - Check the condition for view CGCMTBLDAT
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_CGCMTBLDAT_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CGCMTBLDAT_TAG CGCMTBLDAT;

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
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CBAS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* TYPE_1 Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "TYPE_1")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CBAS-0001");
        TRS.add_fieldmsg(out_node, "TYPE_1", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    return MP_TRUE;
}

