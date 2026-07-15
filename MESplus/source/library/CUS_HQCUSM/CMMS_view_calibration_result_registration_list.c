/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_result_registration_list.c
    Description : View Calibration_Result_Registration List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_Result_Registration_List()
            + View Calibration_Result_Registration definition List
        - CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST()
            + Main sub function of CMMS_View_Calibration_Result_Registration_List function
            + View Calibration_Result_Registration definition List
        - CMMS_View_Calibration_Result_Registration_List_Validation()
            + Main sub function of CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST function
            + Check the condition for view Calibration_Result_Registration list
    Detail Description
        - CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST()
            + h_proc_step
                + 1 : View Calibration_Result_Registration definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-31             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Calibration_Result_Registration_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Calibration_Result_Registration_List()
        - View Calibration_Result_Registration definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Result_Registration_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST", out_node);

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
    CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST()
        - Main sub function of "CMMS_View_Calibration_Result_Registration_List" function
        - View Calibration_Result_Registration definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALRST_TAG CMMSCALRST;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("cali_id", MP_NSTR, TRS.get_string(in_node, "CALI_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Result_Registration_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Calibration_Result_Registration_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_cmmscalrst(&CMMSCALRST);
    TRS.copy(CMMSCALRST.FACTORY, sizeof(CMMSCALRST.FACTORY), in_node, IN_FACTORY);
	if (TRS.get_procstep(in_node) == '3')
	{
		i_case = 3;
		TRS.copy(CMMSCALRST.EQUIP_ID, sizeof(CMMSCALRST.EQUIP_ID), in_node, "EQUIP_ID");
	}

    CDB_open_cmmscalrst(i_case, &CMMSCALRST);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSCALRST OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cmmscalrst(i_case, &CMMSCALRST);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmscalrst(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALRST FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
            TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmscalrst(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_CALI_ID", CMMSCALRST.CALI_ID, sizeof(CMMSCALRST.CALI_ID));
            CDB_close_cmmscalrst(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "CALIBRATION_RESULT_REGISTRATION_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSCALRST.FACTORY, sizeof(CMMSCALRST.FACTORY));
        TRS.add_string(list_item, "CALI_ID", CMMSCALRST.CALI_ID, sizeof(CMMSCALRST.CALI_ID));
        TRS.add_string(list_item, "EQUIP_ID", CMMSCALRST.EQUIP_ID, sizeof(CMMSCALRST.EQUIP_ID));
        TRS.add_string(list_item, "PLAN_DATE", CMMSCALRST.PLAN_DATE, sizeof(CMMSCALRST.PLAN_DATE));
        TRS.add_string(list_item, "CALI_DATE", CMMSCALRST.CALI_DATE, sizeof(CMMSCALRST.CALI_DATE));
        TRS.add_string(list_item, "CALI_INSTITUTE", CMMSCALRST.CALI_INSTITUTE, sizeof(CMMSCALRST.CALI_INSTITUTE));
        TRS.add_string(list_item, "CALI_METHOD", CMMSCALRST.CALI_METHOD, sizeof(CMMSCALRST.CALI_METHOD));
        TRS.add_char(list_item, "CALI_RESULT", CMMSCALRST.CALI_RESULT);
        TRS.add_double(list_item, "CALI_COST", CMMSCALRST.CALI_COST);
        TRS.add_string(list_item, "CALI_DESC", CMMSCALRST.CALI_DESC, sizeof(CMMSCALRST.CALI_DESC));
        TRS.add_string(list_item, "CALI_USER_ID", CMMSCALRST.CALI_USER_ID, sizeof(CMMSCALRST.CALI_USER_ID));
        TRS.add_string(list_item, "FILE_NAME", CMMSCALRST.FILE_NAME, sizeof(CMMSCALRST.FILE_NAME));
        TRS.add_string(list_item, "FILE_PATH", CMMSCALRST.FILE_PATH, sizeof(CMMSCALRST.FILE_PATH));
        TRS.add_string(list_item, "RESULT_FILE_NAME", CMMSCALRST.RESULT_FILE_NAME, sizeof(CMMSCALRST.RESULT_FILE_NAME));
        TRS.add_string(list_item, "RESULT_FILE_PATH", CMMSCALRST.RESULT_FILE_PATH, sizeof(CMMSCALRST.RESULT_FILE_PATH));
        TRS.add_char(list_item, "CONFIRM_FLAG", CMMSCALRST.CONFIRM_FLAG);
        TRS.add_string(list_item, "CONFIRM_USER_ID", CMMSCALRST.CONFIRM_USER_ID, sizeof(CMMSCALRST.CONFIRM_USER_ID));
        TRS.add_string(list_item, "CONFIRM_TIME", CMMSCALRST.CONFIRM_TIME, sizeof(CMMSCALRST.CONFIRM_TIME));
        TRS.add_string(list_item, "CMF_1", CMMSCALRST.CMF_1, sizeof(CMMSCALRST.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMSCALRST.CMF_2, sizeof(CMMSCALRST.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMSCALRST.CMF_3, sizeof(CMMSCALRST.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMSCALRST.CMF_4, sizeof(CMMSCALRST.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMSCALRST.CMF_5, sizeof(CMMSCALRST.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMSCALRST.CMF_6, sizeof(CMMSCALRST.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMSCALRST.CMF_7, sizeof(CMMSCALRST.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMSCALRST.CMF_8, sizeof(CMMSCALRST.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMSCALRST.CMF_9, sizeof(CMMSCALRST.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMSCALRST.CMF_10, sizeof(CMMSCALRST.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMSCALRST.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMSCALRST.CREATE_TIME, sizeof(CMMSCALRST.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMSCALRST.UPDATE_USER_ID, sizeof(CMMSCALRST.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMSCALRST.UPDATE_TIME, sizeof(CMMSCALRST.UPDATE_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Result_Registration_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Calibration_Result_Registration_List_Validation()
        - Main sub function of "CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST" function
        - Check the condition for view Calibration_Result_Registration list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Result_Registration_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    return MP_TRUE;
}

