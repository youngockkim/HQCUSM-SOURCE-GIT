/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_analysis_plan.c
    Description : Analysis_Plan Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Analysis_Plan()
            + Create/Update/Delete Analysis_Plan definition
        - CMMS_UPDATE_ANALYSIS_PLAN()
            + Main sub function of CMMS_Update_Analysis_Plan function
            + Create/Update/Delete Analysis_Plan definition
        - CMMS_Update_Analysis_Plan_Validation()
            + Main sub function of CMMS_UPDATE_ANALYSIS_PLAN function
            + Check the condition for create/update/delete Analysis_Plan
    Detail Description
        - CMMS_UPDATE_ANALYSIS_PLAN()
            + h_proc_step
                + MP_STEP_CREATE : Create Analysis_Plan definition
                + MP_STEP_UPDATE : Update Analysis_Plan definition
                + MP_STEP_DELETE : Delete Analysis_Plan definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Analysis_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Analysis_Plan()
        - Create/Update/Delete Analysis_Plan definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Analysis_Plan(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_ANALYSIS_PLAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_ANALYSIS_PLAN", out_node);

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
    CMMS_UPDATE_ANALYSIS_PLAN()
        - Main sub function of "CMMS_Update_Analysis_Plan" function
        - Create/Update/Delete Analysis_Plan definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_ANALYSIS_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANAPLN_TAG CMMSANAPLN;
    struct CMMSANAPLN_TAG CMMSANAPLN_o;
	struct CMMSANAITM_TAG CMMSANAITM;
	struct CMMSANAUSR_TAG CMMSANAUSR;
	struct CMMSANAVAL_TAG CMMSANAVAL;
    
	char   s_sys_time[14];
	int		i;
	int		i_item_count;
	TRSNode **item_list;

    LOG_head("CMMS_UPDATE_ANALYSIS_PLAN");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_id", MP_NSTR, TRS.get_string(in_node, "ANA_ID"));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    LOG_add("plan_date", MP_NSTR, TRS.get_string(in_node, "PLAN_DATE"));
    LOG_add("ana_div", MP_CHR, TRS.get_char(in_node, "ANA_DIV"));
    LOG_add("ana_status", MP_NSTR, TRS.get_string(in_node, "ANA_STATUS"));
    LOG_add("use_dept_code", MP_NSTR, TRS.get_string(in_node, "USE_DEPT_CODE"));
    LOG_add("sample_code", MP_NSTR, TRS.get_string(in_node, "SAMPLE_CODE"));
    LOG_add("sample_count", MP_INT, TRS.get_int(in_node, "SAMPLE_COUNT"));
    LOG_add("user_count", MP_INT, TRS.get_int(in_node, "USER_COUNT"));
    LOG_add("repeat_count", MP_INT, TRS.get_int(in_node, "REPEAT_COUNT"));
    LOG_add("judge_user_id", MP_NSTR, TRS.get_string(in_node, "JUDGE_USER_ID"));
    LOG_add("alarm_flag", MP_CHR, TRS.get_char(in_node, "ALARM_FLAG"));
    LOG_add("alarm_code", MP_NSTR, TRS.get_string(in_node, "ALARM_CODE"));
    LOG_add("alarm_period", MP_INT, TRS.get_int(in_node, "ALARM_PERIOD"));
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
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Analysis_Plan",
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

    if(CMMS_Update_Analysis_Plan_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (TRS.get_procstep(in_node) == MP_STEP_DELETE)
	{
		i_item_count = TRS.get_item_count(in_node, "DELETE_PLAN_LIST");
		item_list = TRS.get_list(in_node, "DELETE_PLAN_LIST");

		CDB_init_cmmsanapln(&CMMSANAPLN);
		TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);
		for(i = 0; i < i_item_count; i++)
        {
            TRS.copy(CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID), item_list[i], "ANA_ID");
			CDB_delete_cmmsanapln(1, &CMMSANAPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAPLN DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//RATER 삭제 
			CDB_init_cmmsanausr(&CMMSANAUSR);
			memcpy(CMMSANAUSR.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAUSR.FACTORY));
			memcpy(CMMSANAUSR.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAUSR.ANA_ID));
			CDB_delete_cmmsanausr(2, &CMMSANAUSR);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSANAUSR DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAUSR.FACTORY), CMMSANAUSR.FACTORY);
					TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAUSR.ANA_ID), CMMSANAUSR.ANA_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}	

			//ITEM 삭제
			CDB_init_cmmsanaitm(&CMMSANAITM);
			memcpy(CMMSANAITM.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAITM.FACTORY));
			memcpy(CMMSANAITM.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
			CDB_delete_cmmsanaitm(2, &CMMSANAITM);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSANAITM DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAITM.FACTORY), CMMSANAITM.FACTORY);
					TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAITM.ANA_ID), CMMSANAITM.ANA_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			//ITEM VALUE 삭제
			CDB_init_cmmsanaval(&CMMSANAVAL);
			memcpy(CMMSANAVAL.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAVAL.FACTORY));
			memcpy(CMMSANAVAL.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
			CDB_delete_cmmsanaval(2, &CMMSANAVAL);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSANAVAL DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAVAL.FACTORY), CMMSANAVAL.FACTORY);
					TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAVAL.ANA_ID), CMMSANAVAL.ANA_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
	}
	else
	{

		CDB_init_cmmsanapln(&CMMSANAPLN);
		TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID), in_node, "ANA_ID");
		TRS.copy(CMMSANAPLN.EQUIP_ID, sizeof(CMMSANAPLN.EQUIP_ID), in_node, "EQUIP_ID");
		TRS.copy(CMMSANAPLN.PLAN_DATE, sizeof(CMMSANAPLN.PLAN_DATE), in_node, "PLAN_DATE");
		CMMSANAPLN.ANA_DIV = TRS.get_char(in_node, "ANA_DIV");
		TRS.copy(CMMSANAPLN.ANA_STATUS, sizeof(CMMSANAPLN.ANA_STATUS), in_node, "ANA_STATUS");
		TRS.copy(CMMSANAPLN.USE_DEPT_CODE, sizeof(CMMSANAPLN.USE_DEPT_CODE), in_node, "USE_DEPT_CODE");
		TRS.copy(CMMSANAPLN.SAMPLE_CODE, sizeof(CMMSANAPLN.SAMPLE_CODE), in_node, "SAMPLE_CODE");
		CMMSANAPLN.SAMPLE_COUNT = TRS.get_int(in_node, "SAMPLE_COUNT");
		CMMSANAPLN.USER_COUNT = TRS.get_int(in_node, "USER_COUNT");
		CMMSANAPLN.REPEAT_COUNT = TRS.get_int(in_node, "REPEAT_COUNT");
		TRS.copy(CMMSANAPLN.JUDGE_USER_ID, sizeof(CMMSANAPLN.JUDGE_USER_ID), in_node, "JUDGE_USER_ID");
		CMMSANAPLN.ALARM_FLAG = TRS.get_char(in_node, "ALARM_FLAG");
		TRS.copy(CMMSANAPLN.ALARM_CODE, sizeof(CMMSANAPLN.ALARM_CODE), in_node, "ALARM_CODE");
		CMMSANAPLN.ALARM_PERIOD = TRS.get_int(in_node, "ALARM_PERIOD");
		TRS.copy(CMMSANAPLN.CMF_1, sizeof(CMMSANAPLN.CMF_1), in_node, "CMF_1");
		TRS.copy(CMMSANAPLN.CMF_2, sizeof(CMMSANAPLN.CMF_2), in_node, "CMF_2");
		TRS.copy(CMMSANAPLN.CMF_3, sizeof(CMMSANAPLN.CMF_3), in_node, "CMF_3");
		TRS.copy(CMMSANAPLN.CMF_4, sizeof(CMMSANAPLN.CMF_4), in_node, "CMF_4");
		TRS.copy(CMMSANAPLN.CMF_5, sizeof(CMMSANAPLN.CMF_5), in_node, "CMF_5");
		TRS.copy(CMMSANAPLN.CMF_6, sizeof(CMMSANAPLN.CMF_6), in_node, "CMF_6");
		TRS.copy(CMMSANAPLN.CMF_7, sizeof(CMMSANAPLN.CMF_7), in_node, "CMF_7");
		TRS.copy(CMMSANAPLN.CMF_8, sizeof(CMMSANAPLN.CMF_8), in_node, "CMF_8");
		TRS.copy(CMMSANAPLN.CMF_9, sizeof(CMMSANAPLN.CMF_9), in_node, "CMF_9");
		TRS.copy(CMMSANAPLN.CMF_10, sizeof(CMMSANAPLN.CMF_10), in_node, "CMF_10");
		TRS.copy(CMMSANAPLN.CREATE_USER_ID, sizeof(CMMSANAPLN.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		TRS.copy(CMMSANAPLN.CREATE_TIME, sizeof(CMMSANAPLN.CREATE_TIME), in_node, "CREATE_TIME");
		TRS.copy(CMMSANAPLN.UPDATE_USER_ID, sizeof(CMMSANAPLN.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
		TRS.copy(CMMSANAPLN.UPDATE_TIME, sizeof(CMMSANAPLN.UPDATE_TIME), in_node, "UPDATE_TIME");

		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			TRS.copy(CMMSANAPLN.CREATE_USER_ID, sizeof(CMMSANAPLN.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANAPLN.CREATE_TIME, s_sys_time, sizeof(CMMSANAPLN.CREATE_TIME));
			CDB_insert_cmmsanapln(&CMMSANAPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAPLN INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
		{
			CDB_init_cmmsanapln(&CMMSANAPLN_o);
			TRS.copy(CMMSANAPLN_o.FACTORY, sizeof(CMMSANAPLN_o.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CMMSANAPLN_o.ANA_ID, sizeof(CMMSANAPLN_o.ANA_ID), in_node, "ANA_ID");
			CDB_select_cmmsanapln_for_update(1, &CMMSANAPLN_o);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAPLN SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN_o.FACTORY), CMMSANAPLN_o.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN_o.ANA_ID), CMMSANAPLN_o.ANA_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//----[Addtional Logic for Update Case]----

			memcpy(CMMSANAPLN.CREATE_USER_ID, CMMSANAPLN_o.CREATE_USER_ID, sizeof(CMMSANAPLN.CREATE_USER_ID));
			memcpy(CMMSANAPLN.CREATE_TIME, CMMSANAPLN_o.CREATE_TIME, sizeof(CMMSANAPLN.CREATE_TIME));
			TRS.copy(CMMSANAPLN.UPDATE_USER_ID, sizeof(CMMSANAPLN.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANAPLN.UPDATE_TIME, s_sys_time, sizeof(CMMSANAPLN.UPDATE_TIME));

			CDB_update_cmmsanapln(1, &CMMSANAPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAPLN UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		

		//RATER 삭제 
		CDB_init_cmmsanausr(&CMMSANAUSR);
		memcpy(CMMSANAUSR.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAUSR.FACTORY));
		memcpy(CMMSANAUSR.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAUSR.ANA_ID));
		CDB_delete_cmmsanausr(2, &CMMSANAUSR);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAUSR DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAUSR.FACTORY), CMMSANAUSR.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAUSR.ANA_ID), CMMSANAUSR.ANA_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}	

		//ITEM 삭제
		CDB_init_cmmsanaitm(&CMMSANAITM);
		memcpy(CMMSANAITM.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAITM.FACTORY));
		memcpy(CMMSANAITM.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
		CDB_delete_cmmsanaitm(2, &CMMSANAITM);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAITM DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAITM.FACTORY), CMMSANAITM.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAITM.ANA_ID), CMMSANAITM.ANA_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		//ITEM VALUE 삭제
		CDB_init_cmmsanaval(&CMMSANAVAL);
		memcpy(CMMSANAVAL.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAVAL.FACTORY));
		memcpy(CMMSANAVAL.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
		CDB_delete_cmmsanaval(2, &CMMSANAVAL);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAVAL DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAVAL.FACTORY), CMMSANAVAL.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAVAL.ANA_ID), CMMSANAVAL.ANA_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}


		//Rater 재 등록
		i_item_count = TRS.get_item_count(in_node, "ANALYSIS_RATER_LIST");
		item_list = TRS.get_list(in_node, "ANALYSIS_RATER_LIST");

		for(i = 0; i < i_item_count; i++)
        {
            CDB_init_cmmsanausr(&CMMSANAUSR);
			memcpy(CMMSANAUSR.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAUSR.FACTORY));
			memcpy(CMMSANAUSR.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAUSR.ANA_ID));
			CMMSANAUSR.USER_SEQ = TRS_get_int(item_list[i], "USER_SEQ");
			TRS.copy(CMMSANAUSR.USER_ID, sizeof(CMMSANAUSR.USER_ID), item_list[i], "USER_ID");
			TRS.copy(CMMSANAUSR.CREATE_USER_ID, sizeof(CMMSANAUSR.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANAUSR.CREATE_TIME, s_sys_time, sizeof(CMMSANAUSR.CREATE_TIME));
			CDB_insert_cmmsanausr(&CMMSANAUSR);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAUSR INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAUSR.FACTORY), CMMSANAUSR.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAUSR.ANA_ID), CMMSANAUSR.ANA_ID);
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSANAUSR.USER_ID), CMMSANAUSR.USER_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
        }

		//Item 재 등록
		i_item_count = TRS.get_item_count(in_node, "ANALYSIS_ITEM_LIST");
		item_list = TRS.get_list(in_node, "ANALYSIS_ITEM_LIST");

		for(i = 0; i < i_item_count; i++)
        {
            CDB_init_cmmsanaitm(&CMMSANAITM);
			memcpy(CMMSANAITM.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAITM.FACTORY));
			memcpy(CMMSANAITM.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
			CMMSANAITM.ITEM_ORDER = TRS_get_int(item_list[i], "ITEM_ORDER");
			TRS.copy(CMMSANAITM.ITEM_CODE, sizeof(CMMSANAITM.ITEM_CODE), item_list[i], "ITEM_CODE");
			TRS.copy(CMMSANAITM.ITEM_NAME, sizeof(CMMSANAITM.ITEM_NAME), item_list[i], "ITEM_NAME");
			TRS.copy(CMMSANAITM.UNIT_CODE, sizeof(CMMSANAITM.UNIT_CODE), item_list[i], "UNIT_CODE");
			CMMSANAITM.LSL = TRS_get_double(item_list[i], "LSL");
			CMMSANAITM.USL = TRS_get_double(item_list[i], "USL");
			CMMSANAITM.DECIMAL_PLACE = TRS_get_int(item_list[i], "DECIMAL_PLACE");
			TRS.copy(CMMSANAITM.CREATE_USER_ID, sizeof(CMMSANAITM.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANAITM.CREATE_TIME, s_sys_time, sizeof(CMMSANAITM.CREATE_TIME));
			CDB_insert_cmmsanaitm(&CMMSANAITM);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAITM INSERT", MP_NVST);
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
        }

		//Item Value 재 등록
		i_item_count = TRS.get_item_count(in_node, "ANALYSIS_VALUE_LIST");
		item_list = TRS.get_list(in_node, "ANALYSIS_VALUE_LIST");

		for(i = 0; i < i_item_count; i++)
        {
            CDB_init_cmmsanaval(&CMMSANAVAL);
			memcpy(CMMSANAVAL.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAVAL.FACTORY));
			memcpy(CMMSANAVAL.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
			CMMSANAVAL.VAL_SEQ = TRS_get_int(item_list[i], "VAL_SEQ");
			TRS.copy(CMMSANAVAL.ITEM_CODE, sizeof(CMMSANAVAL.ITEM_CODE), item_list[i], "ITEM_CODE");
			CMMSANAVAL.VALUE = TRS_get_double(item_list[i], "VALUE");
			TRS.copy(CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE), item_list[i], "CHAR_VALUE");
			TRS.copy(CMMSANAVAL.CREATE_USER_ID, sizeof(CMMSANAVAL.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANAVAL.CREATE_TIME, s_sys_time, sizeof(CMMSANAVAL.CREATE_TIME));
			CDB_insert_cmmsanaval(&CMMSANAVAL);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAVAL INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAVAL.FACTORY), CMMSANAVAL.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAVAL.ANA_ID), CMMSANAVAL.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANAVAL.ITEM_CODE), CMMSANAVAL.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
        }

	}


    
    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Analysis_Plan",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Analysis_Plan_Validation()
        - Main sub function of "CMMS_UPDATE_ANALYSIS_PLAN" function
        - Check the condition for create/update/delete Analysis_Plan
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Analysis_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANAPLN_TAG CMMSANAPLN;
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
        strcpy(s_msg_code, "MMS-0001");
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

	//삭제는 하위노드에 일괄로 넘어오므로 여기서는 pass
	if(TRS.get_procstep(in_node) != MP_STEP_DELETE)
    {
		/* ANA_ID Validation */
		if(COM_isnullspace(TRS.get_string(in_node, "ANA_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "MMS-0001");
			TRS.add_fieldmsg(out_node, "ANA_ID", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CDB_init_cmmsanapln(&CMMSANAPLN);
		TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID), in_node, "ANA_ID");
		CDB_select_cmmsanapln(1, &CMMSANAPLN);
		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			if(DB_error_code == DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0010");
				TRS.add_fieldmsg(out_node, "CMMSANAPLN SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);
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
					strcpy(s_msg_code, "MMS-0011");
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
				}
				else
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}

				TRS.add_fieldmsg(out_node, "CMMSANAPLN SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				return MP_FALSE;
			}
		}
	}
    return MP_TRUE;
}

