/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_update_audit_plan.c
    Description : Audit_Plan Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CAMS_Update_Audit_Plan()
            + Create/Update/Delete Audit_Plan definition
        - CAMS_UPDATE_AUDIT_PLAN()
            + Main sub function of CAMS_Update_Audit_Plan function
            + Create/Update/Delete Audit_Plan definition
        - CAMS_Update_Audit_Plan_Validation()
            + Main sub function of CAMS_UPDATE_AUDIT_PLAN function
            + Check the condition for create/update/delete Audit_Plan
    Detail Description
        - CAMS_UPDATE_AUDIT_PLAN()
            + h_proc_step
                + MP_STEP_CREATE : Create Audit_Plan definition
                + MP_STEP_UPDATE : Update Audit_Plan definition
                + MP_STEP_DELETE : Delete Audit_Plan definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-25             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CAMS_Update_Audit_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CAMS_Update_Audit_Plan()
        - Create/Update/Delete Audit_Plan definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_Update_Audit_Plan(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_UPDATE_AUDIT_PLAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_UPDATE_AUDIT_PLAN", out_node);

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
    CAMS_UPDATE_AUDIT_PLAN()
        - Main sub function of "CAMS_Update_Audit_Plan" function
        - Create/Update/Delete Audit_Plan definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_UPDATE_AUDIT_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTPLN_TAG CAMSADTPLN;
    struct CAMSADTPLN_TAG CAMSADTPLN_o;
    char   s_sys_time[14];
	int		i_item_count;
	int		i;
	TRSNode **item_list;

    LOG_head("CAMS_UPDATE_AUDIT_PLAN");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("audit_id", MP_NSTR, TRS.get_string(in_node, "AUDIT_ID"));
    LOG_add("audit_desc", MP_NSTR, TRS.get_string(in_node, "AUDIT_DESC"));
    LOG_add("plan_date", MP_NSTR, TRS.get_string(in_node, "PLAN_DATE"));
    LOG_add("audit_date", MP_NSTR, TRS.get_string(in_node, "AUDIT_DATE"));
    LOG_add("customer_code", MP_NSTR, TRS.get_string(in_node, "CUSTOMER_CODE"));
    LOG_add("auditor", MP_NSTR, TRS.get_string(in_node, "AUDITOR"));
    LOG_add("manager_id", MP_NSTR, TRS.get_string(in_node, "MANAGER_ID"));
    LOG_add("agenda", MP_NSTR, TRS.get_string(in_node, "AGENDA"));
    LOG_add("status", MP_CHR, TRS.get_char(in_node, "STATUS"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_Update_Audit_Plan",
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

    if(CAMS_Update_Audit_Plan_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if(TRS.get_procstep(in_node) == MP_STEP_DELETE  && TRS.get_char(in_node, "LIST_FLAG") == 'Y')
	{
		i_item_count = TRS.get_item_count(in_node, "AUDIT_DELETE_LIST");
		item_list = TRS.get_list(in_node, "AUDIT_DELETE_LIST");

		for(i = 0; i < i_item_count; i++)
        {
			CDB_init_camsadtpln(&CAMSADTPLN);
			TRS.copy(CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID), item_list[i], "AUDIT_ID");
			CDB_select_camsadtpln(1, &CAMSADTPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "CMN-0004"); //삭제할 데이터가 없습니다.
				}
				else
				{
					strcpy(s_msg_code, "CMN-0003");
				}
				TRS.add_fieldmsg(out_node, "CAMSADTPLN SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if (CAMSADTPLN.STATUS != '0')
			{
				strcpy(s_msg_code, "AMS-1001"); //상태를 확인하세요 메세지 변경 필요 
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			
			CDB_delete_camsadtpln(1, &CAMSADTPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTPLN DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}
	else
	{

		CDB_init_camsadtpln(&CAMSADTPLN);
		TRS.copy(CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID), in_node, "AUDIT_ID");
		TRS.copy(CAMSADTPLN.AUDIT_DESC, sizeof(CAMSADTPLN.AUDIT_DESC), in_node, "AUDIT_DESC");
		TRS.copy(CAMSADTPLN.PLAN_DATE, sizeof(CAMSADTPLN.PLAN_DATE), in_node, "PLAN_DATE");
		TRS.copy(CAMSADTPLN.AUDIT_DATE, sizeof(CAMSADTPLN.AUDIT_DATE), in_node, "AUDIT_DATE");
		TRS.copy(CAMSADTPLN.CUSTOMER_CODE, sizeof(CAMSADTPLN.CUSTOMER_CODE), in_node, "CUSTOMER_CODE");
		TRS.copy(CAMSADTPLN.AUDITOR, sizeof(CAMSADTPLN.AUDITOR), in_node, "AUDITOR");
		TRS.copy(CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID), in_node, "MANAGER_ID");
		TRS.copy(CAMSADTPLN.AGENDA, sizeof(CAMSADTPLN.AGENDA), in_node, "AGENDA");
		CAMSADTPLN.STATUS = TRS.get_char(in_node, "STATUS");
		TRS.copy(CAMSADTPLN.CMF_1, sizeof(CAMSADTPLN.CMF_1), in_node, "CMF_1");
		TRS.copy(CAMSADTPLN.CMF_2, sizeof(CAMSADTPLN.CMF_2), in_node, "CMF_2");
		TRS.copy(CAMSADTPLN.CMF_3, sizeof(CAMSADTPLN.CMF_3), in_node, "CMF_3");
		TRS.copy(CAMSADTPLN.CMF_4, sizeof(CAMSADTPLN.CMF_4), in_node, "CMF_4");
		TRS.copy(CAMSADTPLN.CMF_5, sizeof(CAMSADTPLN.CMF_5), in_node, "CMF_5");
		TRS.copy(CAMSADTPLN.CMF_6, sizeof(CAMSADTPLN.CMF_6), in_node, "CMF_6");
		TRS.copy(CAMSADTPLN.CMF_7, sizeof(CAMSADTPLN.CMF_7), in_node, "CMF_7");
		TRS.copy(CAMSADTPLN.CMF_8, sizeof(CAMSADTPLN.CMF_8), in_node, "CMF_8");
		TRS.copy(CAMSADTPLN.CMF_9, sizeof(CAMSADTPLN.CMF_9), in_node, "CMF_9");
		TRS.copy(CAMSADTPLN.CMF_10, sizeof(CAMSADTPLN.CMF_10), in_node, "CMF_10");
		TRS.copy(CAMSADTPLN.CREATE_USER_ID, sizeof(CAMSADTPLN.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		TRS.copy(CAMSADTPLN.CREATE_TIME, sizeof(CAMSADTPLN.CREATE_TIME), in_node, "CREATE_TIME");
		TRS.copy(CAMSADTPLN.UPDATE_USER_ID, sizeof(CAMSADTPLN.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
		TRS.copy(CAMSADTPLN.UPDATE_TIME, sizeof(CAMSADTPLN.UPDATE_TIME), in_node, "UPDATE_TIME");

		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{

			//----[Addtional Logic for Create Case]----

			TRS.copy(CAMSADTPLN.CREATE_USER_ID, sizeof(CAMSADTPLN.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CAMSADTPLN.CREATE_TIME, s_sys_time, sizeof(CAMSADTPLN.CREATE_TIME));
			CDB_insert_camsadtpln(&CAMSADTPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTPLN INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			TRS.add_string(out_node, "AUDIT_ID", CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
		}
		else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
		{
			CDB_init_camsadtpln(&CAMSADTPLN_o);
			TRS.copy(CAMSADTPLN_o.FACTORY, sizeof(CAMSADTPLN_o.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CAMSADTPLN_o.AUDIT_ID, sizeof(CAMSADTPLN_o.AUDIT_ID), in_node, "AUDIT_ID");
			CDB_select_camsadtpln_for_update(1, &CAMSADTPLN_o);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTPLN SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN_o.FACTORY), CAMSADTPLN_o.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN_o.AUDIT_ID), CAMSADTPLN_o.AUDIT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//----[Addtional Logic for Update Case]----

			memcpy(CAMSADTPLN.CREATE_USER_ID, CAMSADTPLN_o.CREATE_USER_ID, sizeof(CAMSADTPLN.CREATE_USER_ID));
			memcpy(CAMSADTPLN.CREATE_TIME, CAMSADTPLN_o.CREATE_TIME, sizeof(CAMSADTPLN.CREATE_TIME));
			TRS.copy(CAMSADTPLN.UPDATE_USER_ID, sizeof(CAMSADTPLN.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CAMSADTPLN.UPDATE_TIME, s_sys_time, sizeof(CAMSADTPLN.UPDATE_TIME));

			CDB_update_camsadtpln(1, &CAMSADTPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTPLN UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
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
			CDB_delete_camsadtpln(1, &CAMSADTPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTPLN DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}
    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_Update_Audit_Plan",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CAMS_Update_Audit_Plan_Validation()
        - Main sub function of "CAMS_UPDATE_AUDIT_PLAN" function
        - Check the condition for create/update/delete Audit_Plan
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_Update_Audit_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTPLN_TAG CAMSADTPLN;
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
        strcpy(s_msg_code, "CMN-0002");
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

	if (TRS.get_procstep(in_node) != MP_STEP_DELETE && TRS.get_char(in_node, "LIST_FLAG") != 'Y')
	{
		if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			CDB_init_camsadtpln(&CAMSADTPLN);
			TRS.copy(CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID), in_node, "AUDIT_ID");
			CDB_select_camsadtpln(2, &CAMSADTPLN);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.set_string(in_node, "AUDIT_ID", CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
			}
		}

		/* AUDIT_ID Validation */
		if(COM_isnullspace(TRS.get_string(in_node, "AUDIT_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "CMN-0002");
			TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CDB_init_camsadtpln(&CAMSADTPLN);
		TRS.copy(CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID), in_node, "AUDIT_ID");
		CDB_select_camsadtpln(1, &CAMSADTPLN);
		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			if(DB_error_code == DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0018");
				TRS.add_fieldmsg(out_node, "CAMSADTPLN SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
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
					strcpy(s_msg_code, "CMN-0004");
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
				}
				else
				{
					strcpy(s_msg_code, "CMN-0003");
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}

				TRS.add_fieldmsg(out_node, "CAMSADTPLN SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				return MP_FALSE;
			}
		}
	}
    return MP_TRUE;
}

