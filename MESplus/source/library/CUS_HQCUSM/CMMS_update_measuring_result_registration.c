/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_measuring_result_registration.c
    Description : Measuring_Result_Registration Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Measuring_Result_Registration()
            + Create/Update/Delete Measuring_Result_Registration definition
        - CMMS_UPDATE_MEASURING_RESULT_REGISTRATION()
            + Main sub function of CMMS_Update_Measuring_Result_Registration function
            + Create/Update/Delete Measuring_Result_Registration definition
        - CMMS_Update_Measuring_Result_Registration_Validation()
            + Main sub function of CMMS_UPDATE_MEASURING_RESULT_REGISTRATION function
            + Check the condition for create/update/delete Measuring_Result_Registration
    Detail Description
        - CMMS_UPDATE_MEASURING_RESULT_REGISTRATION()
            + h_proc_step
                + MP_STEP_CREATE : Create Measuring_Result_Registration definition
                + MP_STEP_UPDATE : Update Measuring_Result_Registration definition
                + MP_STEP_DELETE : Delete Measuring_Result_Registration definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-12             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Measuring_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Measuring_Result_Registration()
        - Create/Update/Delete Measuring_Result_Registration definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Measuring_Result_Registration(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_MEASURING_RESULT_REGISTRATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_MEASURING_RESULT_REGISTRATION", out_node);

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
    CMMS_UPDATE_MEASURING_RESULT_REGISTRATION()
        - Main sub function of "CMMS_Update_Measuring_Result_Registration" function
        - Create/Update/Delete Measuring_Result_Registration definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_MEASURING_RESULT_REGISTRATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANARST_TAG CMMSANARST;
    struct CMMSANARST_TAG CMMSANARST_o;
	struct CMMSANADAT_TAG CMMSANADAT;
	struct CMMSANAPLN_TAG CMMSANAPLN;
	struct CMMSANACON_TAG CMMSANACON;
	struct CMMSANAITM_TAG CMMSANAITM;

    char   s_sys_time[14];
	int	   i_item_count;
	TRSNode **item_list;
	int	   i;

    LOG_head("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_id", MP_NSTR, TRS.get_string(in_node, "ANA_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    LOG_add("ana_date", MP_NSTR, TRS.get_string(in_node, "ANA_DATE"));
    LOG_add("ana_result", MP_CHR, TRS.get_char(in_node, "ANA_RESULT"));
    LOG_add("ana_desc", MP_NSTR, TRS.get_string(in_node, "ANA_DESC"));
    LOG_add("ana_value", MP_DBL, TRS.get_double(in_node, "ANA_VALUE"));
    LOG_add("sum", MP_DBL, TRS.get_double(in_node, "SUM"));
    LOG_add("range", MP_DBL, TRS.get_double(in_node, "RANGE"));
    LOG_add("average", MP_DBL, TRS.get_double(in_node, "AVERAGE"));
    LOG_add("avg_diff", MP_DBL, TRS.get_double(in_node, "AVG_DIFF"));
    LOG_add("range_avg", MP_DBL, TRS.get_double(in_node, "RANGE_AVG"));
    LOG_add("rp", MP_DBL, TRS.get_double(in_node, "RP"));
    LOG_add("tol", MP_DBL, TRS.get_double(in_node, "TOL"));
    LOG_add("ev", MP_DBL, TRS.get_double(in_node, "EV"));
    LOG_add("av", MP_DBL, TRS.get_double(in_node, "AV"));
    LOG_add("rr", MP_DBL, TRS.get_double(in_node, "RR"));
    LOG_add("pv", MP_DBL, TRS.get_double(in_node, "PV"));
    LOG_add("tv", MP_DBL, TRS.get_double(in_node, "TV"));
    LOG_add("cp", MP_DBL, TRS.get_double(in_node, "CP"));
    LOG_add("bias_r_stdev", MP_DBL, TRS.get_double(in_node, "BIAS_R_STDEV"));
    LOG_add("bias_t_stdev", MP_DBL, TRS.get_double(in_node, "BIAS_T_STDEV"));
    LOG_add("bias_avg", MP_DBL, TRS.get_double(in_node, "BIAS_AVG"));
    LOG_add("bias_ev", MP_DBL, TRS.get_double(in_node, "BIAS_EV"));
    LOG_add("confirm_flag", MP_CHR, TRS.get_char(in_node, "CONFIRM_FLAG"));
    LOG_add("confirm_user_id", MP_NSTR, TRS.get_string(in_node, "CONFIRM_USER_ID"));
    LOG_add("confirm_time", MP_NSTR, TRS.get_string(in_node, "CONFIRM_TIME"));
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
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Measuring_Result_Registration",
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

    if(CMMS_Update_Measuring_Result_Registration_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (TRS.get_procstep(in_node) == '2') //최종 결과만 UPDATE 하는 경우 
	{
		CDB_init_cmmsanarst(&CMMSANARST);
		TRS.copy(CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID), in_node, "ANA_ID");
		TRS.copy(CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE), in_node, "ITEM_CODE");
		CMMSANARST.ANA_RESULT = TRS.get_char(in_node, "ANA_RESULT");
		TRS.copy(CMMSANARST.ANA_DESC, sizeof(CMMSANARST.ANA_DESC), in_node, "ANA_DESC");
		TRS.copy(CMMSANARST.UPDATE_USER_ID, sizeof(CMMSANARST.UPDATE_USER_ID), in_node, IN_USERID);
		memcpy(CMMSANARST.UPDATE_TIME, s_sys_time, sizeof(CMMSANARST.UPDATE_TIME));
		CDB_update_cmmsanarst(2, &CMMSANARST);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSANARST UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
			TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
			TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//계획 Table Status Update
		CDB_init_cmmsanaitm(&CMMSANAITM);
		memcpy(CMMSANAITM.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANAITM.FACTORY));
		memcpy(CMMSANAITM.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
		if(CDB_select_cmmsanaitm_scalar(2, &CMMSANAITM) == 0)
		{
			CDB_init_cmmsanapln(&CMMSANAPLN);
			memcpy(CMMSANAPLN.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANAPLN.FACTORY));
			memcpy(CMMSANAPLN.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANAPLN.ANA_ID));
			TRS.copy(CMMSANAPLN.ANA_STATUS, sizeof(CMMSANAPLN.ANA_STATUS), in_node, "ANA_STATUS");
			TRS.copy(CMMSANAPLN.UPDATE_USER_ID, sizeof(CMMSANAPLN.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANAPLN.UPDATE_TIME, s_sys_time, sizeof(CMMSANAPLN.UPDATE_TIME));
			CDB_update_cmmsanapln(2, &CMMSANAPLN);
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
	}
	else
	{

		CDB_init_cmmsanarst(&CMMSANARST);
		TRS.copy(CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID), in_node, "ANA_ID");
		TRS.copy(CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE), in_node, "ITEM_CODE");
		TRS.copy(CMMSANARST.ANA_DATE, sizeof(CMMSANARST.ANA_DATE), in_node, "ANA_DATE");
		CMMSANARST.ANA_RESULT = TRS.get_char(in_node, "ANA_RESULT");
		TRS.copy(CMMSANARST.ANA_DESC, sizeof(CMMSANARST.ANA_DESC), in_node, "ANA_DESC");
		CMMSANARST.ANA_VALUE = TRS.get_double(in_node, "ANA_VALUE");
		CMMSANARST.SUM = TRS.get_double(in_node, "SUM");
		CMMSANARST.RANGE = TRS.get_double(in_node, "RANGE");
		CMMSANARST.AVERAGE = TRS.get_double(in_node, "AVERAGE");
		CMMSANARST.AVG_DIFF = TRS.get_double(in_node, "AVG_DIFF");
		CMMSANARST.RANGE_AVG = TRS.get_double(in_node, "RANGE_AVG");
		CMMSANARST.RP = TRS.get_double(in_node, "RP");
		CMMSANARST.TOL = TRS.get_double(in_node, "TOL");
		CMMSANARST.EV = TRS.get_double(in_node, "EV");
		CMMSANARST.AV = TRS.get_double(in_node, "AV");
		CMMSANARST.RR = TRS.get_double(in_node, "RR");
		CMMSANARST.PV = TRS.get_double(in_node, "PV");
		CMMSANARST.TV = TRS.get_double(in_node, "TV");
		CMMSANARST.CP = TRS.get_double(in_node, "CP");
		CMMSANARST.BIAS_R_STDEV = TRS.get_double(in_node, "BIAS_R_STDEV");
		CMMSANARST.BIAS_T_STDEV = TRS.get_double(in_node, "BIAS_T_STDEV");
		CMMSANARST.BIAS_AVG = TRS.get_double(in_node, "BIAS_AVG");
		CMMSANARST.BIAS_EV = TRS.get_double(in_node, "BIAS_EV");
		CMMSANARST.CONFIRM_FLAG = TRS.get_char(in_node, "CONFIRM_FLAG");
		TRS.copy(CMMSANARST.CONFIRM_USER_ID, sizeof(CMMSANARST.CONFIRM_USER_ID), in_node, "CONFIRM_USER_ID");
		TRS.copy(CMMSANARST.CONFIRM_TIME, sizeof(CMMSANARST.CONFIRM_TIME), in_node, "CONFIRM_TIME");
		TRS.copy(CMMSANARST.CMF_1, sizeof(CMMSANARST.CMF_1), in_node, "CMF_1");
		TRS.copy(CMMSANARST.CMF_2, sizeof(CMMSANARST.CMF_2), in_node, "CMF_2");
		TRS.copy(CMMSANARST.CMF_3, sizeof(CMMSANARST.CMF_3), in_node, "CMF_3");
		TRS.copy(CMMSANARST.CMF_4, sizeof(CMMSANARST.CMF_4), in_node, "CMF_4");
		TRS.copy(CMMSANARST.CMF_5, sizeof(CMMSANARST.CMF_5), in_node, "CMF_5");
		TRS.copy(CMMSANARST.CMF_6, sizeof(CMMSANARST.CMF_6), in_node, "CMF_6");
		TRS.copy(CMMSANARST.CMF_7, sizeof(CMMSANARST.CMF_7), in_node, "CMF_7");
		TRS.copy(CMMSANARST.CMF_8, sizeof(CMMSANARST.CMF_8), in_node, "CMF_8");
		TRS.copy(CMMSANARST.CMF_9, sizeof(CMMSANARST.CMF_9), in_node, "CMF_9");
		TRS.copy(CMMSANARST.CMF_10, sizeof(CMMSANARST.CMF_10), in_node, "CMF_10");
		TRS.copy(CMMSANARST.CREATE_USER_ID, sizeof(CMMSANARST.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		TRS.copy(CMMSANARST.CREATE_TIME, sizeof(CMMSANARST.CREATE_TIME), in_node, "CREATE_TIME");
		TRS.copy(CMMSANARST.UPDATE_USER_ID, sizeof(CMMSANARST.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
		TRS.copy(CMMSANARST.UPDATE_TIME, sizeof(CMMSANARST.UPDATE_TIME), in_node, "UPDATE_TIME");

		if(TRS.get_char(in_node, "PROC_STEP") == MP_STEP_CREATE)
		{
			//----[Addtional Logic for Create Case]----
			TRS.copy(CMMSANARST.CREATE_USER_ID, sizeof(CMMSANARST.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANARST.CREATE_TIME, s_sys_time, sizeof(CMMSANARST.CREATE_TIME));
			CDB_insert_cmmsanarst(&CMMSANARST);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANARST INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else if(TRS.get_char(in_node, "PROC_STEP") == MP_STEP_UPDATE)
		{
			CDB_init_cmmsanarst(&CMMSANARST_o);
			TRS.copy(CMMSANARST_o.FACTORY, sizeof(CMMSANARST_o.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CMMSANARST_o.ANA_ID, sizeof(CMMSANARST_o.ANA_ID), in_node, "ANA_ID");
			TRS.copy(CMMSANARST_o.ITEM_CODE, sizeof(CMMSANARST_o.ITEM_CODE), in_node, "ITEM_CODE");
			CDB_select_cmmsanarst_for_update(1, &CMMSANARST_o);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANARST SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST_o.FACTORY), CMMSANARST_o.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST_o.ANA_ID), CMMSANARST_o.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST_o.ITEM_CODE), CMMSANARST_o.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//----[Addtional Logic for Update Case]----

			memcpy(CMMSANARST.CREATE_USER_ID, CMMSANARST_o.CREATE_USER_ID, sizeof(CMMSANARST.CREATE_USER_ID));
			memcpy(CMMSANARST.CREATE_TIME, CMMSANARST_o.CREATE_TIME, sizeof(CMMSANARST.CREATE_TIME));
			TRS.copy(CMMSANARST.UPDATE_USER_ID, sizeof(CMMSANARST.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANARST.UPDATE_TIME, s_sys_time, sizeof(CMMSANARST.UPDATE_TIME));

			CDB_update_cmmsanarst(1, &CMMSANARST);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANARST UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		CDB_init_cmmsanaitm(&CMMSANAITM);
		memcpy(CMMSANAITM.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANAITM.FACTORY));
		memcpy(CMMSANAITM.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANAITM.ANA_ID));
		if(CDB_select_cmmsanaitm_scalar(2, &CMMSANAITM) == 0)
		{
			CDB_init_cmmsanapln(&CMMSANAPLN);
			memcpy(CMMSANAPLN.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANAPLN.FACTORY));
			memcpy(CMMSANAPLN.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANAPLN.ANA_ID));
			memcpy(CMMSANAPLN.ANA_STATUS, "1", strlen("1")); 
			TRS.copy(CMMSANAPLN.UPDATE_USER_ID, sizeof(CMMSANAPLN.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANAPLN.UPDATE_TIME, s_sys_time, sizeof(CMMSANAPLN.UPDATE_TIME));
			CDB_update_cmmsanapln(2, &CMMSANAPLN);
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

		// CMMSANADAT Data 삭제.
		CDB_init_cmmsanadat(&CMMSANADAT);
		memcpy(CMMSANADAT.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANADAT.FACTORY));
		memcpy(CMMSANADAT.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANADAT.ANA_ID));
		memcpy(CMMSANADAT.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(CMMSANADAT.ITEM_CODE));
		CDB_delete_cmmsanadat(2, &CMMSANADAT);

		i_item_count = TRS.get_item_count(in_node, "MEASURING_DATA_LIST");
		item_list = TRS.get_list(in_node, "MEASURING_DATA_LIST");

		for(i = 0; i < i_item_count; i++)
		{
			// Insert	
			CDB_init_cmmsanadat(&CMMSANADAT);
			memcpy(CMMSANADAT.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANADAT.FACTORY));
			memcpy(CMMSANADAT.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANADAT.ANA_ID));
			memcpy(CMMSANADAT.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(CMMSANADAT.ITEM_CODE));
			CMMSANADAT.USER_SEQ = TRS.get_int(item_list[i], "USER_SEQ");
			CMMSANADAT.REPEAT_SEQ = TRS.get_int(item_list[i], "REPEAT_SEQ");
			CMMSANADAT.SAMPLE_SEQ = TRS.get_int(item_list[i], "SAMPLE_SEQ");
			CMMSANADAT.VALUE = TRS.get_double(item_list[i], "VALUE");
			TRS.copy(CMMSANADAT.CHAR_VALUE, sizeof(CMMSANADAT.CHAR_VALUE), item_list[i], "CHAR_VALUE");
			TRS.copy(CMMSANADAT.CREATE_USER_ID, sizeof(CMMSANADAT.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSANADAT.CREATE_TIME, s_sys_time, sizeof(CMMSANADAT.CREATE_TIME));
		
			CDB_insert_cmmsanadat(&CMMSANADAT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANADAT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANADAT.FACTORY), CMMSANADAT.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANADAT.ANA_ID), CMMSANADAT.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANADAT.ITEM_CODE), CMMSANADAT.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		i_item_count = TRS.get_item_count(in_node, "MEASURING_CMMSANACON_LIST");
		item_list = TRS.get_list(in_node, "MEASURING_CMMSANACON_LIST");

		if (i_item_count > 0)
		{
			// CMMSANACON Data 삭제.
			CDB_init_cmmsanacon(&CMMSANACON);
			memcpy(CMMSANACON.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANACON.FACTORY));
			memcpy(CMMSANACON.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANACON.ANA_ID));
			memcpy(CMMSANACON.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(CMMSANACON.ITEM_CODE));
			CDB_delete_cmmsanacon(2, &CMMSANACON);

			for(i = 0; i < i_item_count; i++)
			{
				// Insert	
				CDB_init_cmmsanacon(&CMMSANACON);
				memcpy(CMMSANACON.FACTORY, CMMSANARST.FACTORY, sizeof(CMMSANACON.FACTORY));
				memcpy(CMMSANACON.ANA_ID, CMMSANARST.ANA_ID, sizeof(CMMSANACON.ANA_ID));
				memcpy(CMMSANACON.ITEM_CODE, CMMSANARST.ITEM_CODE, sizeof(CMMSANACON.ITEM_CODE));
				TRS.copy(CMMSANACON.CONST_CODE, sizeof(CMMSANACON.CONST_CODE), item_list[i], "CONST_CODE");
				CMMSANACON.CONST_VALUE = TRS.get_double(item_list[i], "CONST_VALUE");
				TRS.copy(CMMSANACON.CREATE_USER_ID, sizeof(CMMSANACON.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSANACON.CREATE_TIME, s_sys_time, sizeof(CMMSANACON.CREATE_TIME));
		
				CDB_insert_cmmsanacon(&CMMSANACON);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSANACON INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANACON.FACTORY), CMMSANACON.FACTORY);
					TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANACON.ANA_ID), CMMSANACON.ANA_ID);
					TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANACON.ITEM_CODE), CMMSANACON.ITEM_CODE);
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


	//DELETE는 없음.
    //else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    //{
    //    CDB_delete_cmmsanarst(1, &CMMSANARST);
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "MMS-0004");
    //        TRS.add_fieldmsg(out_node, "CMMSANARST DELETE", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
    //        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
    //        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Measuring_Result_Registration",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Measuring_Result_Registration_Validation()
        - Main sub function of "CMMS_UPDATE_MEASURING_RESULT_REGISTRATION" function
        - Check the condition for create/update/delete Measuring_Result_Registration
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Measuring_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANARST_TAG CMMSANARST;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD123") == MP_FALSE)
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
    /* ITEM_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsanarst(&CMMSANARST);
    TRS.copy(CMMSANARST.FACTORY, sizeof(CMMSANARST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSANARST.ANA_ID, sizeof(CMMSANARST.ANA_ID), in_node, "ANA_ID");
    TRS.copy(CMMSANARST.ITEM_CODE, sizeof(CMMSANARST.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cmmsanarst(1, &CMMSANARST);
	if(TRS.get_procstep(in_node) != MP_STEP_DELETE)
    {
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				TRS.add_char(in_node, "PROC_STEP", MP_STEP_CREATE);
			}
			else
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSANARST SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
				TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
				TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else 
		{
			TRS.add_char(in_node, "PROC_STEP", MP_STEP_UPDATE);
		}
	}
	

    //if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    //{
    //    if(DB_error_code == DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "MMS-XXXX");
    //        TRS.add_fieldmsg(out_node, "CMMSANARST SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
    //        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
    //        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}
    //else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    //{
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        if(DB_error_code == DB_NOT_FOUND)
    //        {
    //            strcpy(s_msg_code, "MMS-XXXX");
    //            gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        }
    //        else
    //        {
    //            strcpy(s_msg_code, "MMS-0004");
    //            TRS.add_dberrmsg(out_node, DB_error_msg);

    //            gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        }

    //        TRS.add_fieldmsg(out_node, "CMMSANARST SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANARST.FACTORY), CMMSANARST.FACTORY);
    //        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANARST.ANA_ID), CMMSANARST.ANA_ID);
    //        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSANARST.ITEM_CODE), CMMSANARST.ITEM_CODE);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;
    //        return MP_FALSE;
    //    }
    //}

    return MP_TRUE;
}

