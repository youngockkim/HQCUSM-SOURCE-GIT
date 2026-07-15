/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_update_fmb_notice.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CWIP_Update_Fmb_Notice()
			+ View Lot
		- CWIP_UPDATE_FMB_NOTICE()
			+ Main sub function of CWIP_Update_Fmb_Notice function
			+ View Operation List definition
		- CWIP_Update_Fmb_Notice_Validation()
			+ Main sub function of CWIP_Update_Fmb_Notice function
			+ Check the condition for view Operation List
	Detail Description
		- CWIP_Update_Fmb_Notice()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/10/18  JGCHOI          Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Fmb_Notice_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_Update_Fmb_Notice()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Fmb_Notice(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_FMB_NOTICE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_Update_Fmb_Notice", out_node);

	if (i_ret == MP_TRUE)
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
	CWIP_Update_Fmb_Notice()
		- Main sub function of "CWIP_Update_Fmb_Notice" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_FMB_NOTICE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CALMFMBNTC_TAG CALMFMBNTC;
	struct CALMFMBHIS_TAG CALMFMBHIS;
	struct CALMFMBNTC_TAG CALMFMBNTC_O;
	
	TRSNode ** PLAN_LIST;

	char   s_sys_time[14];
	int    i_count = 0;
	int    i = 0;

    LOG_head("CWIP_Update_Fmb_Notice");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CWIP_Update_Fmb_Notice_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// SYSTEM TIME SETTING
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

	LOG_head("CWIP_UPDATE_FMB_NOTICE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("department", MP_NSTR, TRS.get_string(in_node, "DEPARTMENT"));
    LOG_add("line_1", MP_NSTR, TRS.get_string(in_node, "LINE_1"));
    LOG_add("line_2", MP_NSTR, TRS.get_string(in_node, "LINE_2"));
    LOG_add("line_3", MP_NSTR, TRS.get_string(in_node, "LINE_3"));
    LOG_add("line_4", MP_NSTR, TRS.get_string(in_node, "LINE_4"));
    LOG_add("line_5", MP_NSTR, TRS.get_string(in_node, "LINE_5"));
    LOG_add("font_size_1", MP_INT, TRS.get_int(in_node, "FONT_SIZE_1"));
    LOG_add("font_size_2", MP_INT, TRS.get_int(in_node, "FONT_SIZE_2"));
    LOG_add("font_size_3", MP_INT, TRS.get_int(in_node, "FONT_SIZE_3"));
    LOG_add("font_size_4", MP_INT, TRS.get_int(in_node, "FONT_SIZE_4"));
    LOG_add("font_size_5", MP_INT, TRS.get_int(in_node, "FONT_SIZE_5"));
    LOG_add("loc_x_1", MP_INT, TRS.get_int(in_node, "LOC_X_1"));
    LOG_add("loc_x_2", MP_INT, TRS.get_int(in_node, "LOC_X_2"));
    LOG_add("loc_x_3", MP_INT, TRS.get_int(in_node, "LOC_X_3"));
    LOG_add("loc_x_4", MP_INT, TRS.get_int(in_node, "LOC_X_4"));
    LOG_add("loc_x_5", MP_INT, TRS.get_int(in_node, "LOC_X_5"));
    LOG_add("loc_y_1", MP_INT, TRS.get_int(in_node, "LOC_Y_1"));
    LOG_add("loc_y_2", MP_INT, TRS.get_int(in_node, "LOC_Y_2"));
    LOG_add("loc_y_3", MP_INT, TRS.get_int(in_node, "LOC_Y_3"));
    LOG_add("loc_y_4", MP_INT, TRS.get_int(in_node, "LOC_Y_4"));
    LOG_add("loc_y_5", MP_INT, TRS.get_int(in_node, "LOC_Y_5"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

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

    if(CWIP_Update_Fmb_Notice_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
	{
		CDB_init_calmfmbntc(&CALMFMBNTC);
		TRS.copy(CALMFMBNTC.FACTORY, sizeof(CALMFMBNTC.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CALMFMBNTC.DEPARTMENT, sizeof(CALMFMBNTC.DEPARTMENT), in_node, "DEPARTMENT");
		TRS.copy(CALMFMBNTC.LINE_1, sizeof(CALMFMBNTC.LINE_1), in_node, "LINE_1");
		TRS.copy(CALMFMBNTC.LINE_2, sizeof(CALMFMBNTC.LINE_2), in_node, "LINE_2");
		TRS.copy(CALMFMBNTC.LINE_3, sizeof(CALMFMBNTC.LINE_3), in_node, "LINE_3");
		TRS.copy(CALMFMBNTC.LINE_4, sizeof(CALMFMBNTC.LINE_4), in_node, "LINE_4");
		TRS.copy(CALMFMBNTC.LINE_5, sizeof(CALMFMBNTC.LINE_5), in_node, "LINE_5");
		CALMFMBNTC.FONT_SIZE_1 = TRS.get_int(in_node, "FONT_SIZE_1");
		CALMFMBNTC.FONT_SIZE_2 = TRS.get_int(in_node, "FONT_SIZE_2");
		CALMFMBNTC.FONT_SIZE_3 = TRS.get_int(in_node, "FONT_SIZE_3");
		CALMFMBNTC.FONT_SIZE_4 = TRS.get_int(in_node, "FONT_SIZE_4");
		CALMFMBNTC.FONT_SIZE_5 = TRS.get_int(in_node, "FONT_SIZE_5");
		CALMFMBNTC.LOC_X_1 = TRS.get_int(in_node, "LOC_X_1");
		CALMFMBNTC.LOC_X_2 = TRS.get_int(in_node, "LOC_X_2");
		CALMFMBNTC.LOC_X_3 = TRS.get_int(in_node, "LOC_X_3");
		CALMFMBNTC.LOC_X_4 = TRS.get_int(in_node, "LOC_X_4");
		CALMFMBNTC.LOC_X_5 = TRS.get_int(in_node, "LOC_X_5");
		CALMFMBNTC.LOC_Y_1 = TRS.get_int(in_node, "LOC_Y_1");
		CALMFMBNTC.LOC_Y_2 = TRS.get_int(in_node, "LOC_Y_2");
		CALMFMBNTC.LOC_Y_3 = TRS.get_int(in_node, "LOC_Y_3");
		CALMFMBNTC.LOC_Y_4 = TRS.get_int(in_node, "LOC_Y_4");
		CALMFMBNTC.LOC_Y_5 = TRS.get_int(in_node, "LOC_Y_5");
		TRS.copy(CALMFMBNTC.CMF_1, sizeof(CALMFMBNTC.CMF_1), in_node, "CMF_1");
		TRS.copy(CALMFMBNTC.CMF_2, sizeof(CALMFMBNTC.CMF_2), in_node, "CMF_2");
		TRS.copy(CALMFMBNTC.CMF_3, sizeof(CALMFMBNTC.CMF_3), in_node, "CMF_3");
		TRS.copy(CALMFMBNTC.CMF_4, sizeof(CALMFMBNTC.CMF_4), in_node, "CMF_4");
		TRS.copy(CALMFMBNTC.CMF_5, sizeof(CALMFMBNTC.CMF_5), in_node, "CMF_5");
		TRS.copy(CALMFMBNTC.CREATE_USER_ID, sizeof(CALMFMBNTC.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		TRS.copy(CALMFMBNTC.CREATE_TIME, sizeof(CALMFMBNTC.CREATE_TIME), in_node, "CREATE_TIME");
		TRS.copy(CALMFMBNTC.UPDATE_USER_ID, sizeof(CALMFMBNTC.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
		TRS.copy(CALMFMBNTC.UPDATE_TIME, sizeof(CALMFMBNTC.UPDATE_TIME), in_node, "UPDATE_TIME");

		CDB_init_calmfmbntc(&CALMFMBNTC_O);
		TRS.copy(CALMFMBNTC_O.FACTORY, sizeof(CALMFMBNTC_O.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CALMFMBNTC_O.DEPARTMENT, sizeof(CALMFMBNTC_O.DEPARTMENT), in_node, "DEPARTMENT");
		CDB_select_calmfmbntc_for_update(1, &CALMFMBNTC_O);
		
		if(DB_error_code == DB_SUCCESS)//UPDATE
		{
			memcpy(CALMFMBNTC.CREATE_USER_ID, CALMFMBNTC_O.CREATE_USER_ID, sizeof(CALMFMBNTC.CREATE_USER_ID));
			memcpy(CALMFMBNTC.CREATE_TIME, CALMFMBNTC_O.CREATE_TIME, sizeof(CALMFMBNTC.CREATE_TIME));
			TRS.copy(CALMFMBNTC.UPDATE_USER_ID, sizeof(CALMFMBNTC.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CALMFMBNTC.UPDATE_TIME, s_sys_time, sizeof(CALMFMBNTC.UPDATE_TIME));

			//HISTORY 테이블 백업
			CDB_init_calmfmbhis(&CALMFMBHIS);
			memcpy(&CALMFMBHIS, &CALMFMBNTC, sizeof(CALMFMBHIS));
			CDB_insert_calmfmbhis(&CALMFMBHIS);
			if(DB_error_code != DB_SUCCESS)
			{

			}

			CDB_update_calmfmbntc(1, &CALMFMBNTC);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CALMFMBNTC UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALMFMBNTC.FACTORY), CALMFMBNTC.FACTORY);
				TRS.add_fieldmsg(out_node, "DEPARTMENT", MP_STR, sizeof(CALMFMBNTC.DEPARTMENT), CALMFMBNTC.DEPARTMENT);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else if(DB_error_code == DB_NOT_FOUND)//CREATE
		{
			TRS.copy(CALMFMBNTC.CREATE_USER_ID, sizeof(CALMFMBNTC.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CALMFMBNTC.CREATE_TIME, s_sys_time, sizeof(CALMFMBNTC.CREATE_TIME));

			//HISTORY 테이블 백업
			CDB_init_calmfmbhis(&CALMFMBHIS);
			memcpy(&CALMFMBHIS, &CALMFMBNTC, sizeof(CALMFMBHIS));
			CDB_insert_calmfmbhis(&CALMFMBHIS);
			if(DB_error_code != DB_SUCCESS)
			{

			}

			CDB_insert_calmfmbntc(&CALMFMBNTC);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CALMFMBNTC INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALMFMBNTC.FACTORY), CALMFMBNTC.FACTORY);
				TRS.add_fieldmsg(out_node, "DEPARTMENT", MP_STR, sizeof(CALMFMBNTC.DEPARTMENT), CALMFMBNTC.DEPARTMENT);
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
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CALMFMBNTC SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALMFMBNTC.FACTORY), CALMFMBNTC.FACTORY);
			TRS.add_fieldmsg(out_node, "DEPARTMENT", MP_STR, sizeof(CALMFMBNTC.DEPARTMENT), CALMFMBNTC.DEPARTMENT);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
		
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_Update_Fmb_Notice_Validation()
		- Main sub function of "CWIP_Update_Fmb_Notice" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Fmb_Notice_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct CALMFMBNTC_TAG CALMFMBNTC;
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
		strcpy(s_msg_code, "WIP-0001");
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

	/* DEPARTMENT Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "DEPARTMENT")) == MP_TRUE)
	{
		strcpy(s_msg_code, "WIP-0001");
		TRS.add_fieldmsg(out_node, "DEPARTMENT", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	return MP_TRUE;
}