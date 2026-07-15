/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_view_audit_plan.c
    Description : View Audit_Plan function module

    MES Version : 5.3.4 ~

    Function List
        - CAMS_View_Audit_Plan()
            + View Audit_Plan definition
        - CAMS_VIEW_AUDIT_PLAN()
            + Main sub function of CAMS_View_Audit_Plan function
            + View Audit_Plan definition
    Detail Description
        - CAMS_VIEW_AUDIT_PLAN()
            + h_proc_step
                + 1 : View Audit_Plan definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-25             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CAMS_View_Audit_Plan()
        - View Audit_Plan definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_View_Audit_Plan(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_VIEW_AUDIT_PLAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_VIEW_AUDIT_PLAN", out_node);

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
    CAMS_VIEW_AUDIT_PLAN()
        - Main sub function of "CAMS_View_Audit_Plan" function
        - View Audit_Plan definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_VIEW_AUDIT_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTPLN_TAG CAMSADTPLN;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	//struct MSECUSRDEF_TAG MSECUSRDEF;
	struct CAMSADTITM_TAG CAMSADTITM;
	struct CAMSADTRST_TAG CAMSADTRST;

	int		i_case;
	TRSNode *list_item;

    LOG_head("CAMS_VIEW_AUDIT_PLAN");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("audit_id", MP_NSTR, TRS.get_string(in_node, "AUDIT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Audit_Plan",
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
                              "123") == MP_FALSE)
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
    /* AUDIT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "AUDIT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_camsadtpln(&CAMSADTPLN);
    TRS.copy(CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID), in_node, "AUDIT_ID");
    CDB_select_camsadtpln(1, &CAMSADTPLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CAMSADTPLN SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY));
    TRS.add_string(out_node, "AUDIT_ID", CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
    TRS.add_string(out_node, "AUDIT_DESC", CAMSADTPLN.AUDIT_DESC, sizeof(CAMSADTPLN.AUDIT_DESC));
    TRS.add_string(out_node, "PLAN_DATE", CAMSADTPLN.PLAN_DATE, sizeof(CAMSADTPLN.PLAN_DATE));
    TRS.add_string(out_node, "AUDIT_DATE", CAMSADTPLN.AUDIT_DATE, sizeof(CAMSADTPLN.AUDIT_DATE));
    TRS.add_string(out_node, "CUSTOMER_CODE", CAMSADTPLN.CUSTOMER_CODE, sizeof(CAMSADTPLN.CUSTOMER_CODE));
    TRS.add_string(out_node, "AUDITOR", CAMSADTPLN.AUDITOR, sizeof(CAMSADTPLN.AUDITOR));
    TRS.add_string(out_node, "MANAGER_ID", CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID));
    TRS.add_string(out_node, "AGENDA", CAMSADTPLN.AGENDA, sizeof(CAMSADTPLN.AGENDA));
    TRS.add_char(out_node, "STATUS", CAMSADTPLN.STATUS);
    TRS.add_string(out_node, "CMF_1", CAMSADTPLN.CMF_1, sizeof(CAMSADTPLN.CMF_1));
    TRS.add_string(out_node, "CMF_2", CAMSADTPLN.CMF_2, sizeof(CAMSADTPLN.CMF_2));
    TRS.add_string(out_node, "CMF_3", CAMSADTPLN.CMF_3, sizeof(CAMSADTPLN.CMF_3));
    TRS.add_string(out_node, "CMF_4", CAMSADTPLN.CMF_4, sizeof(CAMSADTPLN.CMF_4));
    TRS.add_string(out_node, "CMF_5", CAMSADTPLN.CMF_5, sizeof(CAMSADTPLN.CMF_5));
    TRS.add_string(out_node, "CMF_6", CAMSADTPLN.CMF_6, sizeof(CAMSADTPLN.CMF_6));
    TRS.add_string(out_node, "CMF_7", CAMSADTPLN.CMF_7, sizeof(CAMSADTPLN.CMF_7));
    TRS.add_string(out_node, "CMF_8", CAMSADTPLN.CMF_8, sizeof(CAMSADTPLN.CMF_8));
    TRS.add_string(out_node, "CMF_9", CAMSADTPLN.CMF_9, sizeof(CAMSADTPLN.CMF_9));
    TRS.add_string(out_node, "CMF_10", CAMSADTPLN.CMF_10, sizeof(CAMSADTPLN.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CAMSADTPLN.CREATE_USER_ID, sizeof(CAMSADTPLN.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CAMSADTPLN.CREATE_TIME, sizeof(CAMSADTPLN.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CAMSADTPLN.UPDATE_USER_ID, sizeof(CAMSADTPLN.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CAMSADTPLN.UPDATE_TIME, sizeof(CAMSADTPLN.UPDATE_TIME));

	//GCM 조회	
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_AMS_CUSTOMER, strlen(HQCEL_GCM_AMS_CUSTOMER));
	memcpy(MGCMTBLDAT.KEY_1, CAMSADTPLN.CUSTOMER_CODE, sizeof(CAMSADTPLN.CUSTOMER_CODE));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "CUSTOMER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}

	//GCM 조회	
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_AMS_AUDIT_STATUS, strlen(HQCEL_GCM_AMS_AUDIT_STATUS));
	MGCMTBLDAT.KEY_1[0] = CAMSADTPLN.STATUS;
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "STATUS_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}

	//Manager Name
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_MANAGER", strlen("AMS_MANAGER"));
	memcpy(MGCMTBLDAT.KEY_1, CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "MANAGER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}

	//DBC_init_msecusrdef(&MSECUSRDEF);
	//TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
	//memcpy(MSECUSRDEF.USER_ID, CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID));
	//DBC_select_msecusrdef(1, &MSECUSRDEF);
	//if(DB_error_code == DB_SUCCESS)
	//{
	//	TRS.add_string(out_node, "MANAGER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
	//}

	if(TRS.get_procstep(in_node) == '3')
	{
		CDB_init_camsadtrst(&CAMSADTRST);
		memcpy(CAMSADTRST.FACTORY, CAMSADTPLN.FACTORY, sizeof(CAMSADTRST.FACTORY));
		memcpy(CAMSADTRST.AUDIT_ID, CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTRST.AUDIT_ID));
		CDB_select_camsadtrst(1, &CAMSADTRST);
		if(DB_error_code == DB_SUCCESS)
		{
			//TRS.add_string(out_node, "AUDIT_DATE", CAMSADTRST.AUDIT_DATE, sizeof(CAMSADTRST.AUDIT_DATE));
			TRS.add_char(out_node, "RESULT", CAMSADTRST.RESULT);
			TRS.add_string(out_node, "ACTION_DATE", CAMSADTRST.ACTION_DATE, sizeof(CAMSADTRST.ACTION_DATE));
			TRS.add_string(out_node, "ACTION_REMARK", CAMSADTRST.ACTION_REMARK, sizeof(CAMSADTRST.ACTION_REMARK));
			TRS.add_char(out_node, "ACTION_RESULT", CAMSADTRST.ACTION_RESULT);
			TRS.add_string(out_node, "ACTION_USER_ID", CAMSADTRST.ACTION_USER_ID, sizeof(CAMSADTRST.ACTION_USER_ID));
		}
	}

	//Step이 2 또는 3 이고 Status가 0이 아니면 ITEM 조회
	if((TRS.get_procstep(in_node) == '2' || TRS.get_procstep(in_node) == '3') && CAMSADTPLN.STATUS != '0')
	{
		i_case = 1;
		//이미지 정보 조회
		CDB_init_camsadtitm(&CAMSADTITM);
		memcpy(CAMSADTITM.FACTORY, CAMSADTPLN.FACTORY, sizeof(CAMSADTITM.FACTORY));
		memcpy(CAMSADTITM.AUDIT_ID, CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
		CDB_open_camsadtitm(i_case, &CAMSADTITM);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTITM OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		while(1)
		{
			CDB_fetch_camsadtitm(i_case, &CAMSADTITM);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_camsadtitm(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTITM FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_camsadtitm(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "AUDIT_ITEM_LIST");
			TRS.add_string(list_item, "FACTORY", CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY));
			TRS.add_string(list_item, "AUDIT_ID", CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
			TRS.add_int(list_item, "SORT_ORDER", CAMSADTITM.SORT_ORDER);
			TRS.add_string(list_item, "ITEM_DIVISION", CAMSADTITM.ITEM_DIVISION, sizeof(CAMSADTITM.ITEM_DIVISION));
			TRS.add_string(list_item, "ITEM_NAME", CAMSADTITM.ITEM_NAME, sizeof(CAMSADTITM.ITEM_NAME));
			TRS.add_string(list_item, "CHECK_DETAIL", CAMSADTITM.CHECK_DETAIL, sizeof(CAMSADTITM.CHECK_DETAIL));
			TRS.add_char(list_item, "CHECK_RESULT", CAMSADTITM.CHECK_RESULT);
			TRS.add_string(list_item, "FILE_NAME", CAMSADTITM.FILE_NAME, sizeof(CAMSADTITM.FILE_NAME));
			TRS.add_string(list_item, "FILE_PATH", CAMSADTITM.FILE_PATH, sizeof(CAMSADTITM.FILE_PATH));
			TRS.add_string(list_item, "ACTION_MGR_ID", CAMSADTITM.ACTION_MGR_ID, sizeof(CAMSADTITM.ACTION_MGR_ID));
			TRS.add_string(list_item, "ACTION_LIMIT_DATE", CAMSADTITM.ACTION_LIMIT_DATE, sizeof(CAMSADTITM.ACTION_LIMIT_DATE));
			TRS.add_string(list_item, "ACTION_DATE", CAMSADTITM.ACTION_DATE, sizeof(CAMSADTITM.ACTION_DATE));
			TRS.add_string(list_item, "ACTION_USER_ID", CAMSADTITM.ACTION_USER_ID, sizeof(CAMSADTITM.ACTION_USER_ID));
			TRS.add_string(list_item, "ACTION_FILE_NAME", CAMSADTITM.ACTION_FILE_NAME, sizeof(CAMSADTITM.ACTION_FILE_NAME));
			TRS.add_string(list_item, "ACTION_FILE_PATH", CAMSADTITM.ACTION_FILE_PATH, sizeof(CAMSADTITM.ACTION_FILE_PATH));
			TRS.add_char(list_item, "ACTION_RESULT", CAMSADTITM.ACTION_RESULT);
			TRS.add_string(list_item, "REMARKS", CAMSADTITM.REMARKS, sizeof(CAMSADTITM.REMARKS));
			TRS.add_char(list_item, "STATUS", CAMSADTITM.STATUS);
			TRS.add_string(list_item, "CMF_1", CAMSADTITM.CMF_1, sizeof(CAMSADTITM.CMF_1));
			TRS.add_string(list_item, "CMF_2", CAMSADTITM.CMF_2, sizeof(CAMSADTITM.CMF_2));
			TRS.add_string(list_item, "CMF_3", CAMSADTITM.CMF_3, sizeof(CAMSADTITM.CMF_3));
			TRS.add_string(list_item, "CMF_4", CAMSADTITM.CMF_4, sizeof(CAMSADTITM.CMF_4));
			TRS.add_string(list_item, "CMF_5", CAMSADTITM.CMF_5, sizeof(CAMSADTITM.CMF_5));
			TRS.add_string(list_item, "CMF_6", CAMSADTITM.CMF_6, sizeof(CAMSADTITM.CMF_6));
			TRS.add_string(list_item, "CMF_7", CAMSADTITM.CMF_7, sizeof(CAMSADTITM.CMF_7));
			TRS.add_string(list_item, "CMF_8", CAMSADTITM.CMF_8, sizeof(CAMSADTITM.CMF_8));
			TRS.add_string(list_item, "CMF_9", CAMSADTITM.CMF_9, sizeof(CAMSADTITM.CMF_9));
			TRS.add_string(list_item, "CMF_10", CAMSADTITM.CMF_10, sizeof(CAMSADTITM.CMF_10));
			TRS.add_string(list_item, "CREATE_USER_ID", CAMSADTITM.CREATE_USER_ID, sizeof(CAMSADTITM.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CAMSADTITM.CREATE_TIME, sizeof(CAMSADTITM.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CAMSADTITM.UPDATE_USER_ID, sizeof(CAMSADTITM.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", CAMSADTITM.UPDATE_TIME, sizeof(CAMSADTITM.UPDATE_TIME));

			//GCM 조회	
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			memcpy(MGCMTBLDAT.FACTORY, CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY));
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_AMS_ITEM_DIV, strlen(HQCEL_GCM_AMS_ITEM_DIV));
			memcpy(MGCMTBLDAT.KEY_1, CAMSADTITM.ITEM_DIVISION, sizeof(CAMSADTITM.ITEM_DIVISION));
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "ITEM_DIV_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(out_node, "CUSTOMER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			//Action Manager Name
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_USER", strlen("AMS_USER"));
			memcpy(MGCMTBLDAT.KEY_1, CAMSADTITM.ACTION_MGR_ID, sizeof(CAMSADTITM.ACTION_MGR_ID));
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "ACTION_MGR_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
			/*DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MSECUSRDEF.USER_ID, CAMSADTITM.ACTION_MGR_ID, sizeof(CAMSADTITM.ACTION_MGR_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "ACTION_MGR_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
			}*/

			//  Audit File 
			if (COM_isspace(CAMSADTITM.FILE_PATH, sizeof(CAMSADTITM.FILE_PATH)) == MP_FALSE)
			{
				if(CMMS_get_attached_file(s_msg_code, out_node, CAMSADTITM.FILE_PATH, TRS.get_string(list_item, "FILE_NAME"), 'Y') == MP_FALSE)
				{
					COM_set_result(list_item, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
				}
			}

			if(TRS.get_procstep(in_node) == '3')
			{
				//Action User Name
				DBC_init_mgcmtbldat(&MGCMTBLDAT);
				TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_USER", strlen("AMS_USER"));
				memcpy(MGCMTBLDAT.KEY_1, CAMSADTITM.ACTION_USER_ID, sizeof(CAMSADTITM.ACTION_USER_ID));
				DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
				if(DB_error_code == DB_SUCCESS)
				{
					TRS.add_string(list_item, "ACTION_USER_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
				}

				//DBC_init_msecusrdef(&MSECUSRDEF);
				//TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
				//memcpy(MSECUSRDEF.USER_ID, CAMSADTITM.ACTION_USER_ID, sizeof(CAMSADTITM.ACTION_USER_ID));
				//DBC_select_msecusrdef(1, &MSECUSRDEF);
				//if(DB_error_code == DB_SUCCESS)
				//{
				//	TRS.add_string(list_item, "ACTION_USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
				//}

				// Action File 정보 
				if (COM_isspace(CAMSADTITM.ACTION_FILE_PATH, sizeof(CAMSADTITM.ACTION_FILE_PATH)) == MP_FALSE)
				{
					if(CMMS_get_attached_file(s_msg_code, out_node, CAMSADTITM.ACTION_FILE_PATH, TRS.get_string(list_item, "ACTION_FILE_NAME"), 'Y') == MP_FALSE)
					{
						COM_set_result(list_item, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
					}
				}
			}

		}
	}


    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_View_Audit_Plan",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

