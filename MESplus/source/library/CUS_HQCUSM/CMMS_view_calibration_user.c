/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_user.c
    Description : View Calibration_User function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_User()
            + View Calibration_User definition
        - CMMS_VIEW_CALIBRATION_USER()
            + Main sub function of CMMS_View_Calibration_User function
            + View Calibration_User definition
        - CMMS_View_Calibration_User_Validation()
            + Main sub function of CMMS_VIEW_CALIBRATION_USER function
            + Check the condition for view Calibration_User
    Detail Description
        - CMMS_VIEW_CALIBRATION_USER()
            + h_proc_step
                + 1 : View Calibration_User definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Calibration_user_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Calibration_User()
        - View Calibration_User definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_user(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_USER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_USER", out_node);

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
    CMMS_VIEW_CALIBRATION_USER()
        - Main sub function of "CMMS_View_Calibration_User" function
        - View Calibration_User definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_USER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSUSRDEF_TAG CMMSUSRDEF;

    LOG_head("CMMS_VIEW_CALIBRATION_USER");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("user_id", MP_NSTR, TRS.get_string(in_node, "USER_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_User",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Calibration_user_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsusrdef(&CMMSUSRDEF);
	TRS.copy(CMMSUSRDEF.FACTORY, sizeof(CMMSUSRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID), in_node, "USER_ID");
    CDB_select_cmmsusrdef(1, &CMMSUSRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSUSRDEF SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSUSRDEF.FACTORY), CMMSUSRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	TRS.add_string(out_node, "FACTORY", CMMSUSRDEF.FACTORY, sizeof(CMMSUSRDEF.FACTORY));
    TRS.add_string(out_node, "USER_ID", CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID));
    TRS.add_string(out_node, "USER_NAME", CMMSUSRDEF.USER_NAME, sizeof(CMMSUSRDEF.USER_NAME));
    TRS.add_string(out_node, "FILE_NAME", CMMSUSRDEF.FILE_NAME, sizeof(CMMSUSRDEF.FILE_NAME));
    TRS.add_string(out_node, "FILE_PATH", CMMSUSRDEF.FILE_PATH, sizeof(CMMSUSRDEF.FILE_PATH));
    TRS.add_string(out_node, "EXPIRY_DATE", CMMSUSRDEF.EXPIRY_DATE, sizeof(CMMSUSRDEF.EXPIRY_DATE));
    TRS.add_char(out_node, "CALI_FLAG", CMMSUSRDEF.CALI_FLAG);
    TRS.add_char(out_node, "MSA_FLAG", CMMSUSRDEF.MSA_FLAG);
    TRS.add_char(out_node, "USE_FLAG", CMMSUSRDEF.USE_FLAG);
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSUSRDEF.CREATE_USER_ID, sizeof(CMMSUSRDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSUSRDEF.CREATE_TIME, sizeof(CMMSUSRDEF.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSUSRDEF.UPDATE_USER_ID, sizeof(CMMSUSRDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSUSRDEF.UPDATE_TIME, sizeof(CMMSUSRDEF.UPDATE_TIME));

	if (COM_isspace(CMMSUSRDEF.FILE_PATH, sizeof(CMMSUSRDEF.FILE_PATH)) == MP_FALSE)
    {
        if(CMMS_get_attached_file(s_msg_code, out_node, CMMSUSRDEF.FILE_PATH, MP_BIN_DATA_1, 'Y') == MP_FALSE)
        {
            COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_User",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Calibration_User_Validation()
        - Main sub function of "CMMS_VIEW_CALIBRATION_USER" function
        - Check the condition for view Calibration_User
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_user_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSUSRDEF_TAG CMMSUSRDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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

    /* USER_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "USER_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "USER_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsusrdef(&CMMSUSRDEF);
	TRS.copy(CMMSUSRDEF.FACTORY, sizeof(CMMSUSRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID), in_node, "USER_ID");
    CDB_select_cmmsusrdef(1, &CMMSUSRDEF);
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

        TRS.add_fieldmsg(out_node, "CMMSUSRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

