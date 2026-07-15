/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_analysis_plan_item_list.c
    Description : View Analysis_Plan_Item List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Analysis_Plan_Item_List()
            + View Analysis_Plan_Item definition List
        - CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST()
            + Main sub function of CMMS_View_Analysis_Plan_Item_List function
            + View Analysis_Plan_Item definition List
        - CMMS_View_Analysis_Plan_Item_List_Validation()
            + Main sub function of CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST function
            + Check the condition for view Analysis_Plan_Item list
    Detail Description
        - CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST()
            + h_proc_step
                + 1 : View Analysis_Plan_Item definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-13             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Analysis_Plan_Item_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Analysis_Plan_Item_List()
        - View Analysis_Plan_Item definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan_Item_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST", out_node);

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
    CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST()
        - Main sub function of "CMMS_View_Analysis_Plan_Item_List" function
        - View Analysis_Plan_Item definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANAITM_TAG CMMSANAITM;
	struct CMMSANARST_TAG CMMSANARST;

    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_id", MP_NSTR, TRS.get_string(in_node, "ANA_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Analysis_Plan_Item_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Analysis_Plan_Item_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_cmmsanaitm(&CMMSANAITM);
    TRS.copy(CMMSANAITM.FACTORY, sizeof(CMMSANAITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSANAITM.ANA_ID, sizeof(CMMSANAITM.ANA_ID), in_node, "ANA_ID");
    CDB_open_cmmsanaitm(i_case, &CMMSANAITM);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSANAITM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAITM.FACTORY), CMMSANAITM.FACTORY);
        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAITM.ANA_ID), CMMSANAITM.ANA_ID);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANAITM.ITEM_CODE), CMMSANAITM.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cmmsanaitm(i_case, &CMMSANAITM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmsanaitm(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSANAITM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAITM.FACTORY), CMMSANAITM.FACTORY);
            TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAITM.ANA_ID), CMMSANAITM.ANA_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANAITM.ITEM_CODE), CMMSANAITM.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmsanaitm(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		list_item = TRS.add_node(out_node, "ANALYSIS_PLAN_ITEM_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSANAITM.FACTORY, sizeof(CMMSANAITM.FACTORY));
        TRS.add_string(list_item, "ANA_ID", CMMSANAITM.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
        TRS.add_string(list_item, "ITEM_CODE", CMMSANAITM.ITEM_CODE, sizeof(CMMSANAITM.ITEM_CODE));
        TRS.add_string(list_item, "ITEM_NAME", CMMSANAITM.ITEM_NAME, sizeof(CMMSANAITM.ITEM_NAME));
        TRS.add_string(list_item, "ITEM_SPEC", CMMSANAITM.ITEM_SPEC, sizeof(CMMSANAITM.ITEM_SPEC));
        TRS.add_int(list_item, "ITEM_ORDER", CMMSANAITM.ITEM_ORDER);
        TRS.add_double(list_item, "LSL", CMMSANAITM.LSL);
        TRS.add_double(list_item, "USL", CMMSANAITM.USL);
        TRS.add_string(list_item, "UNIT_CODE", CMMSANAITM.UNIT_CODE, sizeof(CMMSANAITM.UNIT_CODE));
        TRS.add_int(list_item, "DECIMAL_PLACE", CMMSANAITM.DECIMAL_PLACE);
        TRS.add_string(list_item, "CMF_1", CMMSANAITM.CMF_1, sizeof(CMMSANAITM.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMSANAITM.CMF_2, sizeof(CMMSANAITM.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMSANAITM.CMF_3, sizeof(CMMSANAITM.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMSANAITM.CMF_4, sizeof(CMMSANAITM.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMSANAITM.CMF_5, sizeof(CMMSANAITM.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMSANAITM.CMF_6, sizeof(CMMSANAITM.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMSANAITM.CMF_7, sizeof(CMMSANAITM.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMSANAITM.CMF_8, sizeof(CMMSANAITM.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMSANAITM.CMF_9, sizeof(CMMSANAITM.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMSANAITM.CMF_10, sizeof(CMMSANAITM.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMSANAITM.CREATE_USER_ID, sizeof(CMMSANAITM.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMSANAITM.CREATE_TIME, sizeof(CMMSANAITM.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMSANAITM.UPDATE_USER_ID, sizeof(CMMSANAITM.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMSANAITM.UPDATE_TIME, sizeof(CMMSANAITM.UPDATE_TIME));

		CDB_init_cmmsanarst(&CMMSANARST);
		memcpy(CMMSANARST.FACTORY, CMMSANAITM.FACTORY, sizeof(CMMSANARST.FACTORY));
		memcpy(CMMSANARST.ANA_ID, CMMSANAITM.ANA_ID, sizeof(CMMSANARST.ANA_ID));
		memcpy(CMMSANARST.ITEM_CODE, CMMSANAITM.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE));
		CDB_select_cmmsanarst(3, &CMMSANARST);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "ANA_DATE", CMMSANARST.ANA_DATE, sizeof(CMMSANARST.ANA_DATE));
		}
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Analysis_Plan_Item_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Analysis_Plan_Item_List_Validation()
        - Main sub function of "CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST" function
        - Check the condition for view Analysis_Plan_Item list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan_Item_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
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

    return MP_TRUE;
}

