/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_measuring_result_registration.c
    Description : View Measuring_Result_Registration function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Measuring_Result_Registration()
            + View Measuring_Result_Registration definition
        - CMMS_VIEW_MEASURING_RESULT_REGISTRATION()
            + Main sub function of CMMS_View_Measuring_Result_Registration function
            + View Measuring_Result_Registration definition
        - CMMS_View_Measuring_Result_Registration_Validation()
            + Main sub function of CMMS_VIEW_MEASURING_RESULT_REGISTRATION function
            + Check the condition for view Measuring_Result_Registration
    Detail Description
        - CMMS_VIEW_MEASURING_RESULT_REGISTRATION()
            + h_proc_step
                + 1 : View Measuring_Result_Registration definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-12             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Measuring_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Measuring_Result_Registration()
        - View Measuring_Result_Registration definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Measuring_Result_Registration(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_MEASURING_RESULT_REGISTRATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_MEASURING_RESULT_REGISTRATION", out_node);

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
    CMMS_VIEW_MEASURING_RESULT_REGISTRATION()
        - Main sub function of "CMMS_View_Measuring_Result_Registration" function
        - View Measuring_Result_Registration definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_MEASURING_RESULT_REGISTRATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANARST_TAG CMMSANARST;
	struct CMMSANAPLN_TAG CMMSANAPLN;
	struct CMMSEQPDEF_TAG CMMSEQPDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MSECUSRDEF_TAG MSECUSRDEF;
	struct CMMSANAITM_TAG CMMSANAITM;
	struct CMMSANAUSR_TAG CMMSANAUSR;
	struct CMMSANAVAL_TAG CMMSANAVAL;	
	struct CMMSANADAT_TAG CMMSANADAT;
	struct ATTRIBUTES_TAG ATTRIBUTES;

	TRSNode *list_item;
	int		i_case;

    LOG_head("CMMS_VIEW_MEASURING_RESULT_REGISTRATION");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_id", MP_NSTR, TRS.get_string(in_node, "ANA_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Measuring_Result_Registration",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Measuring_Result_Registration_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
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
        strcpy(s_msg_code, "MMS-9999");
        TRS.add_fieldmsg(out_node, "CMMSANARST SELECT", MP_NVST);
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

    TRS.add_string(out_node, "FACTORY", CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY));
    TRS.add_string(out_node, "ANA_ID", CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID));
    TRS.add_string(out_node, "ITEM_CODE", CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE));
    TRS.add_string(out_node, "ANA_DATE", CMMSANARST.ANA_DATE, sizeof(CMMSANARST.ANA_DATE));
    TRS.add_char(out_node, "ANA_RESULT", CMMSANARST.ANA_RESULT);
    TRS.add_string(out_node, "ANA_DESC", CMMSANARST.ANA_DESC, sizeof(CMMSANARST.ANA_DESC));
    TRS.add_double(out_node, "ANA_VALUE", CMMSANARST.ANA_VALUE);
    TRS.add_double(out_node, "SUM", CMMSANARST.SUM);
    TRS.add_double(out_node, "RANGE", CMMSANARST.RANGE);
    TRS.add_double(out_node, "AVERAGE", CMMSANARST.AVERAGE);
    TRS.add_double(out_node, "AVG_DIFF", CMMSANARST.AVG_DIFF);
    TRS.add_double(out_node, "RANGE_AVG", CMMSANARST.RANGE_AVG);
    TRS.add_double(out_node, "RP", CMMSANARST.RP);
    TRS.add_double(out_node, "TOL", CMMSANARST.TOL);
    TRS.add_double(out_node, "EV", CMMSANARST.EV);
    TRS.add_double(out_node, "AV", CMMSANARST.AV);
    TRS.add_double(out_node, "RR", CMMSANARST.RR);
    TRS.add_double(out_node, "PV", CMMSANARST.PV);
    TRS.add_double(out_node, "TV", CMMSANARST.TV);
    TRS.add_double(out_node, "CP", CMMSANARST.CP);
    TRS.add_double(out_node, "BIAS_R_STDEV", CMMSANARST.BIAS_R_STDEV);
    TRS.add_double(out_node, "BIAS_T_STDEV", CMMSANARST.BIAS_T_STDEV);
    TRS.add_double(out_node, "BIAS_AVG", CMMSANARST.BIAS_AVG);
    TRS.add_double(out_node, "BIAS_EV", CMMSANARST.BIAS_EV);
    TRS.add_char(out_node, "CONFIRM_FLAG", CMMSANARST.CONFIRM_FLAG);
    TRS.add_string(out_node, "CONFIRM_USER_ID", CMMSANARST.CONFIRM_USER_ID, sizeof(CMMSANARST.CONFIRM_USER_ID));
    TRS.add_string(out_node, "CONFIRM_TIME", CMMSANARST.CONFIRM_TIME, sizeof(CMMSANARST.CONFIRM_TIME));
    TRS.add_string(out_node, "CMF_1", CMMSANARST.CMF_1, sizeof(CMMSANARST.CMF_1));
    TRS.add_string(out_node, "CMF_2", CMMSANARST.CMF_2, sizeof(CMMSANARST.CMF_2));
    TRS.add_string(out_node, "CMF_3", CMMSANARST.CMF_3, sizeof(CMMSANARST.CMF_3));
    TRS.add_string(out_node, "CMF_4", CMMSANARST.CMF_4, sizeof(CMMSANARST.CMF_4));
    TRS.add_string(out_node, "CMF_5", CMMSANARST.CMF_5, sizeof(CMMSANARST.CMF_5));
    TRS.add_string(out_node, "CMF_6", CMMSANARST.CMF_6, sizeof(CMMSANARST.CMF_6));
    TRS.add_string(out_node, "CMF_7", CMMSANARST.CMF_7, sizeof(CMMSANARST.CMF_7));
    TRS.add_string(out_node, "CMF_8", CMMSANARST.CMF_8, sizeof(CMMSANARST.CMF_8));
    TRS.add_string(out_node, "CMF_9", CMMSANARST.CMF_9, sizeof(CMMSANARST.CMF_9));
    TRS.add_string(out_node, "CMF_10", CMMSANARST.CMF_10, sizeof(CMMSANARST.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSANARST.CREATE_USER_ID, sizeof(CMMSANARST.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSANARST.CREATE_TIME, sizeof(CMMSANARST.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSANARST.UPDATE_USER_ID, sizeof(CMMSANARST.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSANARST.UPDATE_TIME, sizeof(CMMSANARST.UPDATE_TIME));

	//계획 정보 조회
	CDB_init_cmmsanapln(&CMMSANAPLN);
	memcpy(CMMSANAPLN.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANAPLN.FACTORY));
	memcpy(CMMSANAPLN.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANAPLN.ANA_ID));
    CDB_select_cmmsanapln(1, &CMMSANAPLN);
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.add_string(out_node, "PLAN_DATE", CMMSANAPLN.PLAN_DATE, sizeof(CMMSANAPLN.PLAN_DATE));
		TRS.add_char(out_node, "ANA_DIV", CMMSANAPLN.ANA_DIV);
		TRS.add_string(out_node, "ANA_STATUS", CMMSANAPLN.ANA_STATUS, sizeof(CMMSANAPLN.ANA_STATUS));
		TRS.add_string(out_node, "USE_DEPT_CODE", CMMSANAPLN.USE_DEPT_CODE, sizeof(CMMSANAPLN.USE_DEPT_CODE));
		TRS.add_string(out_node, "SAMPLE_CODE", CMMSANAPLN.SAMPLE_CODE, sizeof(CMMSANAPLN.SAMPLE_CODE));
		TRS.add_int(out_node, "SAMPLE_COUNT", CMMSANAPLN.SAMPLE_COUNT);
		TRS.add_int(out_node, "USER_COUNT", CMMSANAPLN.USER_COUNT);
		TRS.add_int(out_node, "REPEAT_COUNT", CMMSANAPLN.REPEAT_COUNT);
    }

	//EQUIP ID, NAME 조회
	CDB_init_cmmseqpdef(&CMMSEQPDEF);
	memcpy(CMMSEQPDEF.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSEQPDEF.FACTORY));
	memcpy(CMMSEQPDEF.EQUIP_ID, CMMSANAPLN.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
    CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.add_string(out_node, "EQUIP_ID", CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
		TRS.add_string(out_node, "EQUIP_NAME", CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));
	}


	//Item 정보 조회
	CDB_init_cmmsanaitm(&CMMSANAITM);
	memcpy(CMMSANAITM.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY));
	memcpy(CMMSANAITM.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID));
	memcpy(CMMSANAITM.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE));
	CDB_select_cmmsanaitm(1, &CMMSANAITM);
	if(DB_error_code == DB_SUCCESS)
	{
		//TRS.add_string(out_node, "ITEM_CODE", CMMSANAITM.ITEM_CODE, sizeof(CMMSANAITM.ITEM_CODE));
		TRS.add_string(out_node, "ITEM_NAME", CMMSANAITM.ITEM_NAME, sizeof(CMMSANAITM.ITEM_NAME));
		TRS.add_string(out_node, "ITEM_SPEC", CMMSANAITM.ITEM_SPEC, sizeof(CMMSANAITM.ITEM_SPEC));
		TRS.add_double(out_node, "LSL", CMMSANAITM.LSL);
		TRS.add_double(out_node, "USL", CMMSANAITM.USL);
		TRS.add_string(out_node, "UNIT_CODE", CMMSANAITM.UNIT_CODE, sizeof(CMMSANAITM.UNIT_CODE));
		TRS.add_int(out_node, "DECIMAL_PLACE", CMMSANAITM.DECIMAL_PLACE);
	}

	if(TRS.get_procstep(in_node) != '2') //계수형 제외 
	{

		i_case = 1;
		//Rater(User) 정보 조회
		CDB_init_cmmsanausr(&CMMSANAUSR);
		memcpy(CMMSANAUSR.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANAUSR.FACTORY));
		memcpy(CMMSANAUSR.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANAUSR.ANA_ID));
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


		//기 등록 된 Value Data 정보 조회
		CDB_init_cmmsanadat(&CMMSANADAT);
		memcpy(CMMSANADAT.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANADAT.FACTORY));
		memcpy(CMMSANADAT.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANADAT.ANA_ID));
		memcpy(CMMSANADAT.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(CMMSANADAT.ITEM_CODE));
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

		//기 등록 된 Value Data 정보 조회
		CDB_init_cmmsanaval(&CMMSANAVAL);
		memcpy(CMMSANAVAL.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANAVAL.FACTORY));
		memcpy(CMMSANAVAL.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
		memcpy(CMMSANAVAL.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(CMMSANAVAL.ITEM_CODE));
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

			list_item = TRS.add_node(out_node, "ANALYSIS_BASE_VALUE_LIST");
			TRS.add_string(list_item, "ANA_ID", CMMSANAVAL.ANA_ID, sizeof(CMMSANAVAL.ANA_ID));
			TRS.add_string(list_item, "ITEM_CODE", CMMSANAVAL.ITEM_CODE, sizeof(CMMSANAVAL.ITEM_CODE));
			TRS.add_int(list_item, "VAL_SEQ", CMMSANAVAL.VAL_SEQ);
			TRS.add_double(list_item, "VALUE", CMMSANAVAL.VALUE);
			TRS.add_string(list_item, "CHAR_VALUE", CMMSANAVAL.CHAR_VALUE, sizeof(CMMSANAVAL.CHAR_VALUE));
		}



		//GCM CONST Value Data 정보 조회
		i_case = 2;
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CMMSANARST.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_CONST_CODE, strlen(HQCEL_GCM_MMS_CONST_CODE));
		//memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_CONST_CODE", strlen("MMS_CONST_CODE"));
		DBC_open_mgcmtbldat(i_case, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
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
			DBC_fetch_mgcmtbldat(i_case, &MGCMTBLDAT);
			if(DB_error_code == DB_NOT_FOUND)
			{
				DBC_close_mgcmtbldat(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				DBC_close_mgcmtbldat(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "MMS_CONST_VALUE_LIST");
			TRS.add_string(list_item, "KEY_1", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
			TRS.add_string(list_item, "KEY_2", MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2));
			TRS.add_string(list_item, "DATA_1", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
	}
	else //계수형 Data 정보 조회 
	{
		i_case = 1;
		CDB_init_attributes_join(&ATTRIBUTES);
		memcpy(ATTRIBUTES.FACTORY, CMMSANARST.FACTORY, sizeof(ATTRIBUTES.FACTORY));
		memcpy(ATTRIBUTES.ANA_ID, CMMSANARST.ANA_ID, sizeof(ATTRIBUTES.ANA_ID));
		memcpy(ATTRIBUTES.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(ATTRIBUTES.ITEM_CODE));
		CDB_open_attributes_join(i_case, &ATTRIBUTES);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "ATTRIBUTES OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(ATTRIBUTES.FACTORY), ATTRIBUTES.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(ATTRIBUTES.ANA_ID), ATTRIBUTES.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(ATTRIBUTES.ITEM_CODE), ATTRIBUTES.ITEM_CODE);
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
			CDB_fetch_attributes_join(i_case, &ATTRIBUTES);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_attributes_join(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "ATTRIBUTES FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(ATTRIBUTES.FACTORY), ATTRIBUTES.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(ATTRIBUTES.ANA_ID), ATTRIBUTES.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(ATTRIBUTES.ITEM_CODE), ATTRIBUTES.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_attributes_join(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			list_item = TRS.add_node(out_node, "MMS_ATTRIBUTES_VALUE_LIST");
			TRS.add_string(list_item, "FACTORY", ATTRIBUTES.FACTORY, sizeof(ATTRIBUTES.FACTORY));
			TRS.add_string(list_item, "ANA_ID", ATTRIBUTES.ANA_ID, sizeof(ATTRIBUTES.ANA_ID));
			TRS.add_string(list_item, "ITEM_CODE", ATTRIBUTES.ITEM_CODE, sizeof(ATTRIBUTES.ITEM_CODE));
			TRS.add_string(list_item, "USER_ID", ATTRIBUTES.USER_ID, sizeof(ATTRIBUTES.USER_ID));
			TRS.add_int(list_item, "USER_SEQ", ATTRIBUTES.USER_SEQ);
			TRS.add_int(list_item, "GOOD_CORRECT", ATTRIBUTES.GOOD_CORRECT);
			TRS.add_int(list_item, "BAD_CORRECT", ATTRIBUTES.BAD_CORRECT);
			TRS.add_int(list_item, "NUMBER_FLASE", ATTRIBUTES.NUMBER_FLASE);
			TRS.add_int(list_item, "NUMBER_MISS", ATTRIBUTES.NUMBER_MISS);
			//User Name 조회
			DBC_init_msecusrdef(&MSECUSRDEF);
			memcpy(MSECUSRDEF.FACTORY, ATTRIBUTES.FACTORY, sizeof(MSECUSRDEF.FACTORY));
			memcpy(MSECUSRDEF.USER_ID, ATTRIBUTES.USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
			}

		}


	}

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Measuring_Result_Registration",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Measuring_Result_Registration_Validation()
        - Main sub function of "CMMS_VIEW_MEASURING_RESULT_REGISTRATION" function
        - Check the condition for view Measuring_Result_Registration
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Measuring_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANARST_TAG CMMSANARST;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
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
            strcpy(s_msg_code, "MMS-0010");
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

