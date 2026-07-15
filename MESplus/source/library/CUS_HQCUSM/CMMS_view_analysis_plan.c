/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_analysis_plan.c
    Description : View Analysis_Plan function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Analysis_Plan()
            + View Analysis_Plan definition
        - CMMS_VIEW_ANALYSIS_PLAN()
            + Main sub function of CMMS_View_Analysis_Plan function
            + View Analysis_Plan definition
        - CMMS_View_Analysis_Plan_Validation()
            + Main sub function of CMMS_VIEW_ANALYSIS_PLAN function
            + Check the condition for view Analysis_Plan
    Detail Description
        - CMMS_VIEW_ANALYSIS_PLAN()
            + h_proc_step
                + 1 : View Analysis_Plan definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Analysis_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Analysis_Plan()
        - View Analysis_Plan definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_ANALYSIS_PLAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_ANALYSIS_PLAN", out_node);

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
    CMMS_VIEW_ANALYSIS_PLAN()
        - Main sub function of "CMMS_View_Analysis_Plan" function
        - View Analysis_Plan definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_ANALYSIS_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANAPLN_TAG CMMSANAPLN;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MSECUSRDEF_TAG MSECUSRDEF;
	struct CMMSANAITM_TAG CMMSANAITM;
	struct CMMSANAUSR_TAG CMMSANAUSR;
	struct CMMSANAVAL_TAG CMMSANAVAL;	
	struct CMMSSAMDEF_TAG CMMSSAMDEF;
	struct CMMSANADAT_TAG CMMSANADAT;

	TRSNode *list_item;
	int		i_case;
	char	s_chr_value_name[13];
	int		i_no;

    LOG_head("CMMS_VIEW_ANALYSIS_PLAN");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_id", MP_NSTR, TRS.get_string(in_node, "ANA_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Analysis_Plan",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Analysis_Plan_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsanapln(&CMMSANAPLN);
    TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID), in_node, "ANA_ID");
    CDB_select_cmmsanapln(1, &CMMSANAPLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSANAPLN SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY));
    TRS.add_string(out_node, "ANA_ID", CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID));
    TRS.add_string(out_node, "EQUIP_ID", CMMSANAPLN.EQUIP_ID, sizeof(CMMSANAPLN.EQUIP_ID));
    TRS.add_string(out_node, "PLAN_DATE", CMMSANAPLN.PLAN_DATE, sizeof(CMMSANAPLN.PLAN_DATE));
    TRS.add_char(out_node, "ANA_DIV", CMMSANAPLN.ANA_DIV);
    TRS.add_string(out_node, "ANA_STATUS", CMMSANAPLN.ANA_STATUS, sizeof(CMMSANAPLN.ANA_STATUS));
    TRS.add_string(out_node, "USE_DEPT_CODE", CMMSANAPLN.USE_DEPT_CODE, sizeof(CMMSANAPLN.USE_DEPT_CODE));
    TRS.add_string(out_node, "SAMPLE_CODE", CMMSANAPLN.SAMPLE_CODE, sizeof(CMMSANAPLN.SAMPLE_CODE));
    TRS.add_int(out_node, "SAMPLE_COUNT", CMMSANAPLN.SAMPLE_COUNT);
    TRS.add_int(out_node, "USER_COUNT", CMMSANAPLN.USER_COUNT);
    TRS.add_int(out_node, "REPEAT_COUNT", CMMSANAPLN.REPEAT_COUNT);
    TRS.add_string(out_node, "JUDGE_USER_ID", CMMSANAPLN.JUDGE_USER_ID, sizeof(CMMSANAPLN.JUDGE_USER_ID));
    TRS.add_char(out_node, "ALARM_FLAG", CMMSANAPLN.ALARM_FLAG);
    TRS.add_string(out_node, "ALARM_CODE", CMMSANAPLN.ALARM_CODE, sizeof(CMMSANAPLN.ALARM_CODE));
    TRS.add_int(out_node, "ALARM_PERIOD", CMMSANAPLN.ALARM_PERIOD);
    TRS.add_string(out_node, "CMF_1", CMMSANAPLN.CMF_1, sizeof(CMMSANAPLN.CMF_1));
    TRS.add_string(out_node, "CMF_2", CMMSANAPLN.CMF_2, sizeof(CMMSANAPLN.CMF_2));
    TRS.add_string(out_node, "CMF_3", CMMSANAPLN.CMF_3, sizeof(CMMSANAPLN.CMF_3));
    TRS.add_string(out_node, "CMF_4", CMMSANAPLN.CMF_4, sizeof(CMMSANAPLN.CMF_4));
    TRS.add_string(out_node, "CMF_5", CMMSANAPLN.CMF_5, sizeof(CMMSANAPLN.CMF_5));
    TRS.add_string(out_node, "CMF_6", CMMSANAPLN.CMF_6, sizeof(CMMSANAPLN.CMF_6));
    TRS.add_string(out_node, "CMF_7", CMMSANAPLN.CMF_7, sizeof(CMMSANAPLN.CMF_7));
    TRS.add_string(out_node, "CMF_8", CMMSANAPLN.CMF_8, sizeof(CMMSANAPLN.CMF_8));
    TRS.add_string(out_node, "CMF_9", CMMSANAPLN.CMF_9, sizeof(CMMSANAPLN.CMF_9));
    TRS.add_string(out_node, "CMF_10", CMMSANAPLN.CMF_10, sizeof(CMMSANAPLN.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSANAPLN.CREATE_USER_ID, sizeof(CMMSANAPLN.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSANAPLN.CREATE_TIME, sizeof(CMMSANAPLN.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSANAPLN.UPDATE_USER_ID, sizeof(CMMSANAPLN.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSANAPLN.UPDATE_TIME, sizeof(CMMSANAPLN.UPDATE_TIME));

	//GCM 조회( USE_DEPT_NAME )
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_DEPT_CODE, strlen(HQCEL_GCM_MMS_DEPT_CODE));
    memcpy(MGCMTBLDAT.KEY_1, CMMSANAPLN.USE_DEPT_CODE, sizeof(MGCMTBLDAT.KEY_1));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "USE_DEPT_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

    }

	//GCM 조회 (ALARM_CODE_NAME)
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ALARM_CODE, strlen(HQCEL_GCM_MMS_ALARM_CODE));
    memcpy(MGCMTBLDAT.KEY_1, CMMSANAPLN.ALARM_CODE, sizeof(CMMSANAPLN.ALARM_CODE));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "ALARM_CODE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	//GCM 조회(ANA_DIV_DESC)
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ANA_MOTHOD, strlen(HQCEL_GCM_MMS_ANA_MOTHOD));
	/*memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_ANALYSIS_METHOD", strlen("MMS_ANALYSIS_METHOD"));*/
	MGCMTBLDAT.KEY_1[0] = CMMSANAPLN.ANA_DIV;
   // memcpy(MGCMTBLDAT.KEY_1, CMMSANAPLN.ANA_DIV, sizeof(CMMSEQPDEF.MGT_DEPT_CODE));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "ANA_DIV_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		TRS.add_string(out_node, "MAX_SAMPLE_CODE", MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
		TRS.add_string(out_node, "MAX_REPEAT_COUNT", MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3));
		TRS.add_string(out_node, "VALUE_FLAG", MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4));
    }

	// User Name 조회 (JUDGE_USER_NAME)
	DBC_init_msecusrdef(&MSECUSRDEF);
    TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MSECUSRDEF.USER_ID, CMMSANAPLN.JUDGE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
	DBC_select_msecusrdef(1, &MSECUSRDEF);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "JUDGE_USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
    }

	//SAMPLE NAME 조회 (SAMPLE_NAME)
	CDB_init_cmmssamdef(&CMMSSAMDEF);
	TRS.copy(CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY), in_node, IN_FACTORY);
	memcpy(CMMSSAMDEF.SAMPLE_CODE, CMMSANAPLN.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE));
    CDB_select_cmmssamdef(1, &CMMSSAMDEF);
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.add_string(out_node, "SAMPLE_NAME", CMMSSAMDEF.SAMPLE_NAME, sizeof(CMMSSAMDEF.SAMPLE_NAME));
	}


	i_case = 1;
	//Rater(User) 정보 조회
	CDB_init_cmmsanausr(&CMMSANAUSR);
	memcpy(CMMSANAUSR.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAUSR.FACTORY));
	memcpy(CMMSANAUSR.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAUSR.ANA_ID));
	CDB_open_cmmsanausr(i_case, &CMMSANAUSR);
	if(DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code != DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSANAUSR OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAUSR.FACTORY), CMMSANAUSR.FACTORY);
			TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAUSR.ANA_ID), CMMSANAUSR.ANA_ID);
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
		CDB_fetch_cmmsanausr(i_case, &CMMSANAUSR);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_cmmsanausr(i_case);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSANAUSR FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAUSR.FACTORY), CMMSANAUSR.FACTORY);
			TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAUSR.ANA_ID), CMMSANAUSR.ANA_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			CDB_close_cmmsanausr(i_case);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "ANALYSIS_RATER_LIST");
		TRS.add_string(list_item, "ANA_ID", CMMSANAUSR.ANA_ID, sizeof(CMMSANAUSR.ANA_ID));
		TRS.add_int(list_item, "USER_SEQ", CMMSANAUSR.USER_SEQ);
		TRS.add_string(list_item, "USER_ID", CMMSANAUSR.USER_ID, sizeof(CMMSANAUSR.USER_ID));
		// User Name 조회 (USER_NAME)
		DBC_init_msecusrdef(&MSECUSRDEF);
		memcpy(MSECUSRDEF.FACTORY, CMMSANAUSR.FACTORY, sizeof(MSECUSRDEF.FACTORY));
		memcpy(MSECUSRDEF.USER_ID, CMMSANAUSR.USER_ID, sizeof(MSECUSRDEF.USER_ID));
		DBC_select_msecusrdef(1, &MSECUSRDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
		}
	}

	if (TRS.get_procstep(in_node) == '3')
	{
		//Item 정보 조회
		CDB_init_cmmsanaitm(&CMMSANAITM);
		memcpy(CMMSANAITM.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAITM.FACTORY));
		memcpy(CMMSANAITM.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
		TRS.copy(CMMSANAITM.ITEM_CODE, sizeof(CMMSANAITM.ITEM_CODE), in_node, "ITEM_CODE");
		CDB_select_cmmsanaitm(i_case, &CMMSANAITM);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(out_node, "ITEM_CODE", CMMSANAITM.ITEM_CODE, sizeof(CMMSANAITM.ITEM_CODE));
			TRS.add_string(out_node, "ITEM_NAME", CMMSANAITM.ITEM_NAME, sizeof(CMMSANAITM.ITEM_NAME));
			TRS.add_string(out_node, "ITEM_SPEC", CMMSANAITM.ITEM_SPEC, sizeof(CMMSANAITM.ITEM_SPEC));
			TRS.add_double(out_node, "LSL", CMMSANAITM.LSL);
			TRS.add_double(out_node, "USL", CMMSANAITM.USL);
			TRS.add_string(out_node, "UNIT_CODE", CMMSANAITM.UNIT_CODE, sizeof(CMMSANAITM.UNIT_CODE));
			TRS.add_int(out_node, "DECIMAL_PLACE", CMMSANAITM.DECIMAL_PLACE);
		}

		//Item Value 정보 조회
		CDB_init_cmmsanaval(&CMMSANAVAL);
		memcpy(CMMSANAVAL.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAVAL.FACTORY));
		memcpy(CMMSANAVAL.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
		TRS.copy(CMMSANAVAL.ITEM_CODE, sizeof(CMMSANAVAL.ITEM_CODE), in_node, "ITEM_CODE");
		CDB_open_cmmsanaval(i_case, &CMMSANAVAL);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAVAL OPEN", MP_NVST);
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
		while(1)
		{
			CDB_fetch_cmmsanaval(i_case, &CMMSANAVAL);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmsanaval(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAVAL FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAVAL.FACTORY), CMMSANAVAL.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAVAL.ANA_ID), CMMSANAVAL.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANAVAL.ITEM_CODE), CMMSANAVAL.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsanaval(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "ANALYSIS_ITEM_VALUE_LIST");
			TRS.add_string(list_item, "ANA_ID", CMMSANAVAL.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
			TRS.add_string(list_item, "ITEM_CODE", CMMSANAVAL.ITEM_CODE, sizeof(CMMSANAVAL.ITEM_CODE));
			TRS.add_int(list_item, "VAL_SEQ", CMMSANAVAL.VAL_SEQ);
			TRS.add_double(list_item, "VALUE", CMMSANAVAL.VALUE);
			TRS.add_string(list_item, "CHAR_VALUE", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
		}

		//기 등록 된 Value Data 정보 조회
		CDB_init_cmmsanadat(&CMMSANADAT);
		memcpy(CMMSANADAT.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANADAT.FACTORY));
		memcpy(CMMSANADAT.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANADAT.ANA_ID));
		TRS.copy(CMMSANADAT.ITEM_CODE, sizeof(CMMSANADAT.ITEM_CODE), in_node, "ITEM_CODE");
		CDB_open_cmmsanadat(i_case, &CMMSANADAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANADAT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANADAT.FACTORY), CMMSANADAT.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANADAT.ANA_ID), CMMSANADAT.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANADAT.ITEM_CODE), CMMSANADAT.ITEM_CODE);
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
			CDB_fetch_cmmsanadat(i_case, &CMMSANADAT);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmsanadat(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANADAT FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANADAT.FACTORY), CMMSANADAT.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANADAT.ANA_ID), CMMSANADAT.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANADAT.ITEM_CODE), CMMSANADAT.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsanadat(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "ANALYSIS_RESULT_VALUE_LIST");
			TRS.add_string(list_item, "ANA_ID", CMMSANADAT.ANA_ID, sizeof(CMMSANADAT.ANA_ID));
			TRS.add_string(list_item, "ITEM_CODE", CMMSANADAT.ITEM_CODE, sizeof(CMMSANADAT.ITEM_CODE));
			TRS.add_int(list_item, "USER_SEQ", CMMSANADAT.USER_SEQ);
			TRS.add_int(list_item, "REPEAT_SEQ", CMMSANADAT.REPEAT_SEQ);
			TRS.add_int(list_item, "SAMPLE_SEQ", CMMSANADAT.SAMPLE_SEQ);
			TRS.add_double(list_item, "VALUE", CMMSANADAT.VALUE);
			TRS.add_string(list_item, "CHAR_VALUE", CMMSANADAT.CHAR_VALUE, sizeof(CMMSANADAT.CHAR_VALUE));
		}
	}
	else
	{
		//Item 정보 조회
		CDB_init_cmmsanaitm(&CMMSANAITM);
		memcpy(CMMSANAITM.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAITM.FACTORY));
		memcpy(CMMSANAITM.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
		CDB_open_cmmsanaitm(i_case, &CMMSANAITM);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANAITM OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAITM.FACTORY), CMMSANAITM.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAITM.ANA_ID), CMMSANAITM.ANA_ID);
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
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsanaitm(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "ANALYSIS_ITEM_LIST");
			TRS.add_string(list_item, "ANA_ID", CMMSANAITM.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
			TRS.add_string(list_item, "ITEM_CODE", CMMSANAITM.ITEM_CODE, sizeof(CMMSANAITM.ITEM_CODE));
			TRS.add_string(list_item, "ITEM_NAME", CMMSANAITM.ITEM_NAME, sizeof(CMMSANAITM.ITEM_NAME));
			TRS.add_double(list_item, "LSL", CMMSANAITM.LSL);
			TRS.add_double(list_item, "USL", CMMSANAITM.USL);
			TRS.add_string(list_item, "UNIT_CODE", CMMSANAITM.UNIT_CODE, sizeof(CMMSANAITM.UNIT_CODE));
			TRS.add_int(list_item, "DECIMAL_PLACE", CMMSANAITM.DECIMAL_PLACE);

			// Item Value 조회
			CDB_init_cmmsanaval(&CMMSANAVAL);
			memcpy(CMMSANAVAL.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANAVAL.FACTORY));
			memcpy(CMMSANAVAL.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
			memcpy(CMMSANAVAL.ITEM_CODE, CMMSANAITM.ITEM_CODE, sizeof(CMMSANAVAL.ITEM_CODE));
			CDB_open_cmmsanaval(i_case, &CMMSANAVAL);
			if(DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSANAVAL OPEN", MP_NVST);
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
			while(1)
			{
				CDB_fetch_cmmsanaval(i_case, &CMMSANAVAL);
				if(DB_error_code == DB_NOT_FOUND)
				{
					CDB_close_cmmsanaval(i_case);
					break;
				}
				else if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSANAVAL FETCH", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAVAL.FACTORY), CMMSANAVAL.FACTORY);
					TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAVAL.ANA_ID), CMMSANAVAL.ANA_ID);
					TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANAVAL.ITEM_CODE), CMMSANAVAL.ITEM_CODE);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					CDB_close_cmmsanaval(i_case);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				i_no = CMMSANAVAL.VAL_SEQ; 
				//memset(s_value_no, 0x00, sizeof(s_value_no));
				memset(s_chr_value_name, 0x00, sizeof(s_chr_value_name));

				//COM_itoa_zero(s_value_no, i_no, 2);

				COM_itoa(s_chr_value_name, i_no, 2); //itoa -> COM_itoa로 변경 2023-07-04
				TRS.add_string(list_item, s_chr_value_name, CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));

				switch(i_no)
				{
					case 1:
						TRS.add_string(list_item, "CHAR_VALUE_01", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 2:
						TRS.add_string(list_item, "CHAR_VALUE_02", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 3:
						TRS.add_string(list_item, "CHAR_VALUE_03", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 4:
						TRS.add_string(list_item, "CHAR_VALUE_04", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 5:
						TRS.add_string(list_item, "CHAR_VALUE_05", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 6:
						TRS.add_string(list_item, "CHAR_VALUE_06", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 7:
						TRS.add_string(list_item, "CHAR_VALUE_07", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 8:
						TRS.add_string(list_item, "CHAR_VALUE_08", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 9:
						TRS.add_string(list_item, "CHAR_VALUE_09", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 10:
						TRS.add_string(list_item, "CHAR_VALUE_10", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 11:
						TRS.add_string(list_item, "CHAR_VALUE_11", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 12:
						TRS.add_string(list_item, "CHAR_VALUE_12", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 13:
						TRS.add_string(list_item, "CHAR_VALUE_13", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 14:
						TRS.add_string(list_item, "CHAR_VALUE_14", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 15:
						TRS.add_string(list_item, "CHAR_VALUE_15", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 16:
						TRS.add_string(list_item, "CHAR_VALUE_16", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 17:
						TRS.add_string(list_item, "CHAR_VALUE_17", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 18:
						TRS.add_string(list_item, "CHAR_VALUE_18", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 19:
						TRS.add_string(list_item, "CHAR_VALUE_19", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 20:
						TRS.add_string(list_item, "CHAR_VALUE_20", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 21:
						TRS.add_string(list_item, "CHAR_VALUE_21", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 22:
						TRS.add_string(list_item, "CHAR_VALUE_22", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 23:
						TRS.add_string(list_item, "CHAR_VALUE_23", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 24:
						TRS.add_string(list_item, "CHAR_VALUE_24", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 25:
						TRS.add_string(list_item, "CHAR_VALUE_25", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 26:
						TRS.add_string(list_item, "CHAR_VALUE_26", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 27:
						TRS.add_string(list_item, "CHAR_VALUE_27", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 28:
						TRS.add_string(list_item, "CHAR_VALUE_28", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 29:
						TRS.add_string(list_item, "CHAR_VALUE_29", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					case 30:
						TRS.add_string(list_item, "CHAR_VALUE_30", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
						break;
					default:
						break;
				}
			
			}
		}
	}

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Analysis_Plan",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Analysis_Plan_Validation()
        - Main sub function of "CMMS_VIEW_ANALYSIS_PLAN" function
        - Check the condition for view Analysis_Plan
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANAPLN_TAG CMMSANAPLN;

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
	
    CDB_init_cmmsanapln(&CMMSANAPLN);
    TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID), in_node, "ANA_ID");
    CDB_select_cmmsanapln(1, &CMMSANAPLN);
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
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

