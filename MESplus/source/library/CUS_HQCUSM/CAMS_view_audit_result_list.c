/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_view_audit_result_list.c
    Description : View Audit_Result List function module

    MES Version : 5.3.4 ~

    Function List
        - CAMS_View_Audit_Result_List()
            + View Audit_Result definition List
        - CAMS_VIEW_AUDIT_RESULT_LIST()
            + Main sub function of CAMS_View_Audit_Result_List function
            + View Audit_Result definition List
        - CAMS_View_Audit_Result_List_Validation()
            + Main sub function of CAMS_VIEW_AUDIT_RESULT_LIST function
            + Check the condition for view Audit_Result list
    Detail Description
        - CAMS_VIEW_AUDIT_RESULT_LIST()
            + h_proc_step
                + 1 : View Audit_Result definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-06-06             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CAMS_View_Audit_Result_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CAMS_View_Audit_Result_List()
        - View Audit_Result definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_View_Audit_Result_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_VIEW_AUDIT_RESULT_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_VIEW_AUDIT_RESULT_LIST", out_node);

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
    CAMS_VIEW_AUDIT_RESULT_LIST()
        - Main sub function of "CAMS_View_Audit_Result_List" function
        - View Audit_Result definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_VIEW_AUDIT_RESULT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTRST_TAG CAMSADTRST;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	//struct MSECUSRDEF_TAG MSECUSRDEF;

    TRSNode *list_item;

    int i_case;

    LOG_head("CAMS_VIEW_AUDIT_RESULT_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("audit_id", MP_NSTR, TRS.get_string(in_node, "AUDIT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Audit_Result_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CAMS_View_Audit_Result_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 2;

    CDB_init_camsadtrst(&CAMSADTRST);
    TRS.copy(CAMSADTRST.FACTORY, sizeof(CAMSADTRST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTRST.AUDIT_ID, sizeof(CAMSADTRST.AUDIT_ID), in_node, "NEXT_AUDIT_ID");
	TRS.copy(CAMSADTRST.PLAN_DATE, sizeof(CAMSADTRST.PLAN_DATE), in_node, "FROM_DATE");
	TRS.copy(CAMSADTRST.AUDIT_DATE, sizeof(CAMSADTRST.AUDIT_DATE), in_node, "TO_DATE");
	TRS.copy(CAMSADTRST.CMF_1, sizeof(CAMSADTRST.CMF_1), in_node, "CUSTOMER_CODE");
	TRS.copy(CAMSADTRST.CMF_2, sizeof(CAMSADTRST.CMF_2), in_node, "MANAGER_ID");
	CAMSADTRST.STATUS = TRS.get_char(in_node, "STATUS");	
    CDB_open_camsadtrst(i_case, &CAMSADTRST);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CAMSADTRST OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_camsadtrst(i_case, &CAMSADTRST);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_camsadtrst(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTRST FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_camsadtrst(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_AUDIT_ID", CAMSADTRST.AUDIT_ID, sizeof(CAMSADTRST.AUDIT_ID));
            CDB_close_camsadtrst(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "AUDIT_RESULT_LIST");

        TRS.add_string(list_item, "FACTORY", CAMSADTRST.FACTORY, sizeof(CAMSADTRST.FACTORY));
        TRS.add_string(list_item, "AUDIT_ID", CAMSADTRST.AUDIT_ID, sizeof(CAMSADTRST.AUDIT_ID));
        TRS.add_string(list_item, "PLAN_DATE", CAMSADTRST.PLAN_DATE, sizeof(CAMSADTRST.PLAN_DATE));
        TRS.add_string(list_item, "AUDIT_DATE", CAMSADTRST.AUDIT_DATE, sizeof(CAMSADTRST.AUDIT_DATE));
        TRS.add_char(list_item, "RESULT", CAMSADTRST.RESULT);
        TRS.add_char(list_item, "STATUS", CAMSADTRST.STATUS);
		TRS.add_string(list_item, "ACTION_DATE", CAMSADTRST.ACTION_DATE, sizeof(CAMSADTRST.ACTION_DATE));
        TRS.add_string(list_item, "ACTION_USER_ID", CAMSADTRST.ACTION_USER_ID, sizeof(CAMSADTRST.ACTION_USER_ID));
        TRS.add_char(list_item, "ACTION_RESULT", CAMSADTRST.ACTION_RESULT);
        TRS.add_string(list_item, "ACTION_REMARK", CAMSADTRST.ACTION_REMARK, sizeof(CAMSADTRST.ACTION_REMARK));
        TRS.add_string(list_item, "AUDIT_DESC", CAMSADTRST.CMF_1, sizeof(CAMSADTRST.CMF_1));
        TRS.add_string(list_item, "CUSTOMER_CODE", CAMSADTRST.CMF_2, sizeof(CAMSADTRST.CMF_2));
        TRS.add_string(list_item, "AUDITOR", CAMSADTRST.CMF_3, sizeof(CAMSADTRST.CMF_3));
        TRS.add_string(list_item, "MANAGER_ID", CAMSADTRST.CMF_4, sizeof(CAMSADTRST.CMF_4));
        TRS.add_string(list_item, "CMF_5", CAMSADTRST.CMF_5, sizeof(CAMSADTRST.CMF_5));
        TRS.add_string(list_item, "CMF_6", CAMSADTRST.CMF_6, sizeof(CAMSADTRST.CMF_6));
        TRS.add_string(list_item, "CMF_7", CAMSADTRST.CMF_7, sizeof(CAMSADTRST.CMF_7));
        TRS.add_string(list_item, "CMF_8", CAMSADTRST.CMF_8, sizeof(CAMSADTRST.CMF_8));
        TRS.add_string(list_item, "CMF_9", CAMSADTRST.CMF_9, sizeof(CAMSADTRST.CMF_9));
        TRS.add_string(list_item, "CMF_10", CAMSADTRST.CMF_10, sizeof(CAMSADTRST.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CAMSADTRST.CREATE_USER_ID, sizeof(CAMSADTRST.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CAMSADTRST.CREATE_TIME, sizeof(CAMSADTRST.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CAMSADTRST.UPDATE_USER_ID, sizeof(CAMSADTRST.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CAMSADTRST.UPDATE_TIME, sizeof(CAMSADTRST.UPDATE_TIME));

		
		//GCM 조회	
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_AMS_CUSTOMER, strlen(HQCEL_GCM_AMS_CUSTOMER));
		memcpy(MGCMTBLDAT.KEY_1, CAMSADTRST.CMF_2, sizeof(MGCMTBLDAT.KEY_1));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "CUSTOMER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//GCM 조회	
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_AMS_AUDIT_STATUS, strlen(HQCEL_GCM_AMS_AUDIT_STATUS));
		MGCMTBLDAT.KEY_1[0] = CAMSADTRST.STATUS;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "STATUS_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//Manager Name
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_MANAGER", strlen("AMS_MANAGER"));
		memcpy(MGCMTBLDAT.KEY_1, CAMSADTRST.CMF_4, sizeof(MGCMTBLDAT.KEY_1));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MANAGER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//DBC_init_msecusrdef(&MSECUSRDEF);
		//TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
		//memcpy(MSECUSRDEF.USER_ID, CAMSADTRST.CMF_4, sizeof(MSECUSRDEF.USER_ID));
		//DBC_select_msecusrdef(1, &MSECUSRDEF);
		//if(DB_error_code == DB_SUCCESS)
		//{
		//	TRS.add_string(list_item, "MANAGER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
		//}

    }

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Audit_Result_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CAMS_View_Audit_Result_List_Validation()
        - Main sub function of "CAMS_VIEW_AUDIT_RESULT_LIST" function
        - Check the condition for view Audit_Result list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_View_Audit_Result_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    ///* AUDIT_ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "AUDIT_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CAMS-0001");
    //    TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    //CDB_init_camsadtrst(&CAMSADTRST);
    //TRS.copy(CAMSADTRST.FACTORY, sizeof(CAMSADTRST.FACTORY), in_node, IN_FACTORY);
    //TRS.copy(CAMSADTRST.AUDIT_ID, sizeof(CAMSADTRST.AUDIT_ID), in_node, "AUDIT_ID");
    //CDB_select_camsadtrst(1, &CAMSADTRST);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    if(DB_error_code == DB_NOT_FOUND)
    //    {
    //        strcpy(s_msg_code, "CAMS-XXXX");
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    }
    //    else
    //    {
    //        strcpy(s_msg_code, "CAMS-0004");
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    }

    //    TRS.add_fieldmsg(out_node, "CAMSADTRST SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
    //    TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}

