/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_measuring_result_registration_list.c
    Description : View Measuring_Result_Registration List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Measuring_Result_Registration_List()
            + View Measuring_Result_Registration definition List
        - CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST()
            + Main sub function of CMMS_View_Measuring_Result_Registration_List function
            + View Measuring_Result_Registration definition List
        - CMMS_View_Measuring_Result_Registration_List_Validation()
            + Main sub function of CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST function
            + Check the condition for view Measuring_Result_Registration list
    Detail Description
        - CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST()
            + h_proc_step
                + 1 : View Measuring_Result_Registration definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-12             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Measuring_Result_Registration_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Measuring_Result_Registration_List()
        - View Measuring_Result_Registration definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Measuring_Result_Registration_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST", out_node);

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
    CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST()
        - Main sub function of "CMMS_View_Measuring_Result_Registration_List" function
        - View Measuring_Result_Registration definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANARST_TAG CMMSANARST;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_id", MP_NSTR, TRS.get_string(in_node, "ANA_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Measuring_Result_Registration_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Measuring_Result_Registration_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_cmmsanarst(&CMMSANARST);
    TRS.copy(CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID), in_node, "ANA_ID");
    TRS.copy(CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE), in_node, "ITEM_CODE");
    TRS.copy(CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID), in_node, "NEXT_ANA_ID");
    TRS.copy(CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE), in_node, "NEXT_ITEM_CODE");
    CDB_open_cmmsanarst(i_case, &CMMSANARST);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSANARST OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cmmsanarst(i_case, &CMMSANARST);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmsanarst(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSANARST FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
            TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmsanarst(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_ANA_ID", CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID));
            TRS.set_string(out_node, "NEXT_ITEM_CODE", CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE));
            CDB_close_cmmsanarst(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "MEASURING_RESULT_REGISTRATION_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY));
        TRS.add_string(list_item, "ANA_ID", CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID));
        TRS.add_string(list_item, "ITEM_CODE", CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE));
        TRS.add_string(list_item, "ANA_DATE", CMMSANARST.ANA_DATE, sizeof(CMMSANARST.ANA_DATE));
        TRS.add_char(list_item, "ANA_RESULT", CMMSANARST.ANA_RESULT);
        TRS.add_string(list_item, "ANA_DESC", CMMSANARST.ANA_DESC, sizeof(CMMSANARST.ANA_DESC));
        TRS.add_double(list_item, "ANA_VALUE", CMMSANARST.ANA_VALUE);
        TRS.add_double(list_item, "SUM", CMMSANARST.SUM);
        TRS.add_double(list_item, "RANGE", CMMSANARST.RANGE);
        TRS.add_double(list_item, "AVERAGE", CMMSANARST.AVERAGE);
        TRS.add_double(list_item, "AVG_DIFF", CMMSANARST.AVG_DIFF);
        TRS.add_double(list_item, "RANGE_AVG", CMMSANARST.RANGE_AVG);
        TRS.add_double(list_item, "RP", CMMSANARST.RP);
        TRS.add_double(list_item, "TOL", CMMSANARST.TOL);
        TRS.add_double(list_item, "EV", CMMSANARST.EV);
        TRS.add_double(list_item, "AV", CMMSANARST.AV);
        TRS.add_double(list_item, "RR", CMMSANARST.RR);
        TRS.add_double(list_item, "PV", CMMSANARST.PV);
        TRS.add_double(list_item, "TV", CMMSANARST.TV);
        TRS.add_double(list_item, "CP", CMMSANARST.CP);
        TRS.add_double(list_item, "BIAS_R_STDEV", CMMSANARST.BIAS_R_STDEV);
        TRS.add_double(list_item, "BIAS_T_STDEV", CMMSANARST.BIAS_T_STDEV);
        TRS.add_double(list_item, "BIAS_AVG", CMMSANARST.BIAS_AVG);
        TRS.add_double(list_item, "BIAS_EV", CMMSANARST.BIAS_EV);
        TRS.add_char(list_item, "CONFIRM_FLAG", CMMSANARST.CONFIRM_FLAG);
        TRS.add_string(list_item, "CONFIRM_USER_ID", CMMSANARST.CONFIRM_USER_ID, sizeof(CMMSANARST.CONFIRM_USER_ID));
        TRS.add_string(list_item, "CONFIRM_TIME", CMMSANARST.CONFIRM_TIME, sizeof(CMMSANARST.CONFIRM_TIME));
        TRS.add_string(list_item, "CMF_1", CMMSANARST.CMF_1, sizeof(CMMSANARST.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMSANARST.CMF_2, sizeof(CMMSANARST.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMSANARST.CMF_3, sizeof(CMMSANARST.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMSANARST.CMF_4, sizeof(CMMSANARST.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMSANARST.CMF_5, sizeof(CMMSANARST.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMSANARST.CMF_6, sizeof(CMMSANARST.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMSANARST.CMF_7, sizeof(CMMSANARST.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMSANARST.CMF_8, sizeof(CMMSANARST.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMSANARST.CMF_9, sizeof(CMMSANARST.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMSANARST.CMF_10, sizeof(CMMSANARST.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMSANARST.CREATE_USER_ID, sizeof(CMMSANARST.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMSANARST.CREATE_TIME, sizeof(CMMSANARST.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMSANARST.UPDATE_USER_ID, sizeof(CMMSANARST.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMSANARST.UPDATE_TIME, sizeof(CMMSANARST.UPDATE_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Measuring_Result_Registration_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Measuring_Result_Registration_List_Validation()
        - Main sub function of "CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST" function
        - Check the condition for view Measuring_Result_Registration list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Measuring_Result_Registration_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANARST_TAG CMMSANARST;

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
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* ANA_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ANA_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "ANA_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
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
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsanarst(&CMMSANARST);
    TRS.copy(CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID), in_node, "ANA_ID");
    TRS.copy(CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cmmsanarst(1, &CMMSANARST);
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

        TRS.add_fieldmsg(out_node, "CMMSANARST SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

