/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_view_audit_plan_list.c
    Description : View Audit_Plan List function module

    MES Version : 5.3.4 ~

    Function List
        - ASM_View_Audit_Plan_List()
            + View Audit_Plan definition List
        - ASM_VIEW_AUDIT_PLAN_LIST()
            + Main sub function of ASM_View_Audit_Plan_List function
            + View Audit_Plan definition List
    Detail Description
        - ASM_VIEW_AUDIT_PLAN_LIST()
            + h_proc_step
                + 1 : View Audit_Plan definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-25             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CAMS_View_Audit_Plan_List()
        - View Audit_Plan definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_View_Audit_Plan_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_VIEW_AUDIT_PLAN_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_VIEW_AUDIT_PLAN_LIST", out_node);

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
    CAMS_VIEW_AUDIT_PLAN_LIST()
        - Main sub function of "CAMS_View_Audit_Plan_List" function
        - View Audit_Plan definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_VIEW_AUDIT_PLAN_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTPLN_TAG CAMSADTPLN;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	//struct MSECUSRDEF_TAG MSECUSRDEF;

    TRSNode *list_item;

    int i_case;

    LOG_head("CAMS_VIEW_AUDIT_PLAN_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("audit_id", MP_NSTR, TRS.get_string(in_node, "AUDIT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("ASM", "ASM_View_Audit_Plan_List",
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
    //    strcpy(s_msg_code, "ASM-0001");
    //    TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    i_case = 1;

    CDB_init_camsadtpln(&CAMSADTPLN);
    TRS.copy(CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID), in_node, "NEXT_AUDIT_ID");
	TRS.copy(CAMSADTPLN.PLAN_DATE, sizeof(CAMSADTPLN.PLAN_DATE), in_node, "FROM_DATE");
	TRS.copy(CAMSADTPLN.AUDIT_DATE, sizeof(CAMSADTPLN.AUDIT_DATE), in_node, "TO_DATE");
	TRS.copy(CAMSADTPLN.CUSTOMER_CODE, sizeof(CAMSADTPLN.CUSTOMER_CODE), in_node, "CUSTOMER_CODE");
	CAMSADTPLN.STATUS = TRS.get_char(in_node, "STATUS");
	TRS.copy(CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID), in_node, "MANAGER_ID");
    CDB_open_camsadtpln(i_case, &CAMSADTPLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CAMSADTPLN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_camsadtpln(i_case, &CAMSADTPLN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_camsadtpln(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTPLN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_camsadtpln(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_AUDIT_ID", CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
            CDB_close_camsadtpln(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "AUDIT_PLAN_LIST");

        TRS.add_string(list_item, "FACTORY", CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY));
        TRS.add_string(list_item, "AUDIT_ID", CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
        TRS.add_string(list_item, "AUDIT_DESC", CAMSADTPLN.AUDIT_DESC, sizeof(CAMSADTPLN.AUDIT_DESC));
        TRS.add_string(list_item, "PLAN_DATE", CAMSADTPLN.PLAN_DATE, sizeof(CAMSADTPLN.PLAN_DATE));
        TRS.add_string(list_item, "AUDIT_DATE", CAMSADTPLN.AUDIT_DATE, sizeof(CAMSADTPLN.AUDIT_DATE));
        TRS.add_string(list_item, "CUSTOMER_CODE", CAMSADTPLN.CUSTOMER_CODE, sizeof(CAMSADTPLN.CUSTOMER_CODE));
        TRS.add_string(list_item, "AUDITOR", CAMSADTPLN.AUDITOR, sizeof(CAMSADTPLN.AUDITOR));
        TRS.add_string(list_item, "MANAGER_ID", CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID));
        TRS.add_string(list_item, "AGENDA", CAMSADTPLN.AGENDA, sizeof(CAMSADTPLN.AGENDA));
        TRS.add_char(list_item, "STATUS", CAMSADTPLN.STATUS);
        TRS.add_string(list_item, "CMF_1", CAMSADTPLN.CMF_1, sizeof(CAMSADTPLN.CMF_1));
        TRS.add_string(list_item, "CMF_2", CAMSADTPLN.CMF_2, sizeof(CAMSADTPLN.CMF_2));
        TRS.add_string(list_item, "CMF_3", CAMSADTPLN.CMF_3, sizeof(CAMSADTPLN.CMF_3));
        TRS.add_string(list_item, "CMF_4", CAMSADTPLN.CMF_4, sizeof(CAMSADTPLN.CMF_4));
        TRS.add_string(list_item, "CMF_5", CAMSADTPLN.CMF_5, sizeof(CAMSADTPLN.CMF_5));
        TRS.add_string(list_item, "CMF_6", CAMSADTPLN.CMF_6, sizeof(CAMSADTPLN.CMF_6));
        TRS.add_string(list_item, "CMF_7", CAMSADTPLN.CMF_7, sizeof(CAMSADTPLN.CMF_7));
        TRS.add_string(list_item, "CMF_8", CAMSADTPLN.CMF_8, sizeof(CAMSADTPLN.CMF_8));
        TRS.add_string(list_item, "CMF_9", CAMSADTPLN.CMF_9, sizeof(CAMSADTPLN.CMF_9));
        TRS.add_string(list_item, "CMF_10", CAMSADTPLN.CMF_10, sizeof(CAMSADTPLN.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CAMSADTPLN.CREATE_USER_ID, sizeof(CAMSADTPLN.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CAMSADTPLN.CREATE_TIME, sizeof(CAMSADTPLN.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CAMSADTPLN.UPDATE_USER_ID, sizeof(CAMSADTPLN.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CAMSADTPLN.UPDATE_TIME, sizeof(CAMSADTPLN.UPDATE_TIME));

		//GCM 조회	
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_AMS_CUSTOMER, strlen(HQCEL_GCM_AMS_CUSTOMER));
		memcpy(MGCMTBLDAT.KEY_1, CAMSADTPLN.CUSTOMER_CODE, sizeof(CAMSADTPLN.CUSTOMER_CODE));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "CUSTOMER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//GCM 조회	
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_AMS_AUDIT_STATUS, strlen(HQCEL_GCM_AMS_AUDIT_STATUS));
		MGCMTBLDAT.KEY_1[0] = CAMSADTPLN.STATUS;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "STATUS_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//Manager Name
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_MANAGER", strlen("AMS_MANAGER"));
		memcpy(MGCMTBLDAT.KEY_1, CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MANAGER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
		/*DBC_init_msecusrdef(&MSECUSRDEF);
		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MSECUSRDEF.USER_ID, CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID));
		DBC_select_msecusrdef(1, &MSECUSRDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MANAGER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
		}*/

    }

    /* Not use in customizing
    if(COM_proc_user_routine("ASM", "CAMS_View_Audit_Plan_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

