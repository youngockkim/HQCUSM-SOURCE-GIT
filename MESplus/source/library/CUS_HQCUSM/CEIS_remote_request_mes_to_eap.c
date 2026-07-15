/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_validate_lot.c
    Description : EAPMES Validate Lot Service

    MES Version : 5.3.4 ~

    Function List
        - MESEAP_Remote_Request_MesToEap()
            + Setup service interface function
        - EAPMES_REMOTE_REQUEST()
            + Main sub function of MESEAP_Remote_Request_MesToEap function
            + Setup service main business function
        - MESEAP_Remote_Request_MesToEap_Validation()
            + Main sub function of EAPMES_REMOTE_REQUEST function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_REMOTE_REQUEST()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  jh.jung           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_REMOTE_REQUEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    MESEAP_Remote_Request_MesToEap()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int MESEAP_Remote_Request_MesToEap(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
	int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = EAPMES_REMOTE_REQUEST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_REMOTE_REQUEST", out_node);

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
    EAPMES_REMOTE_REQUEST()
        - Main sub function of "MESEAP_Remote_Request_MesToEap" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_REMOTE_REQUEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CRASRCPHIS_TAG CRASRCPHIS;
	struct MRCPPRAVER_TAG MRCPPRAVER;
	struct MRCPRCPVER_TAG MRCPRCPVER;
	struct MRCPRCPDEF_TAG MRCPRCPDEF;

	char   s_sys_time[14];
	char   c_action_type = ' ';
	char s_channel[100]; 
	char s_service_name[200];
	TRSNode *list_item;
	double d_value = 0;

	LOG_head("EAPMES_REMOTE_REQUEST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

	//0. 설비 ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	
	if (COM_isspace(MRASRESDEF.RES_CMF_13, sizeof(MRASRESDEF.RES_CMF_13)) == MP_TRUE)
	{
		strcpy(s_msg_code, "RAS-0324");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	/* IN MESSAGE */
	TRS.set_char(in_node, "PROCSTEP", '1');
	TRS.set_string(in_node, "CIM_ID", MRASRESDEF.RES_CMF_13, sizeof(MRASRESDEF.RES_CMF_13));
	TRS.set_string(in_node, "LINE_ID", MRASRESDEF.RES_CMF_1, sizeof(MRASRESDEF.RES_CMF_1));
	TRS.set_string(in_node, "CLIENT_TIME", s_sys_time, sizeof(s_sys_time));
	TRS.set_string(in_node, "CLIENT_ID", "MES", 3);
	TRS.set_string(in_node, "MSG_NO", s_sys_time+4, 10);
	/*TRS.set_nstring(in_node, "RECIPE_ID", TRS.get_string(in_node, "RECIPE_ID"));
	TRS.set_nstring(in_node, "PP_ID", TRS.get_string(in_node, "PP_ID"));
*/
	
	c_action_type = TRS.get_char(in_node, "ACTION_TYPE");
	
	memset(s_service_name, 0x00, sizeof(s_service_name));


	/* MES<->EQ RCIPE REMOTE CALL HISTORY */
	CDB_init_crasrcphis(&CRASRCPHIS);
	memcpy(CRASRCPHIS.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
	memcpy(CRASRCPHIS.RES_ID, MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));

	if (c_action_type == 'L')
	{
		//Request Recipe
		sprintf(s_service_name, "%.*s", strlen("MESEAP_Request_RecipeID_List"), "MESEAP_Request_RecipeID_List");
		COM_add_null(s_service_name, sizeof(s_service_name));

		//RECIPE ID : LOAD FIX , RECIPE_VER : YYYYMMDD
		memcpy(CRASRCPHIS.RECIPE_ID, "LOAD", strlen("LOAD"));
		memcpy(CRASRCPHIS.PP_ID, "LOAD", strlen("LOAD"));
		memcpy(CRASRCPHIS.RECIPE_VERSION, s_sys_time, 8);
		memcpy(CRASRCPHIS.CMF_1, "LOAD", strlen("LOAD"));
		
	}
	if (c_action_type == 'P')
	{
		//Reqeust Parameter List
		sprintf(s_service_name, "%.*s", strlen("MESEAP_Request_RecipeParameter_List"), "MESEAP_Request_RecipeParameter_List");
		COM_add_null(s_service_name, sizeof(s_service_name));

		TRS.copy(CRASRCPHIS.RECIPE_ID, sizeof(CRASRCPHIS.RECIPE_ID), in_node, "RECIPE_ID");
		TRS.copy(CRASRCPHIS.EQ_RECIPE_VERSION, sizeof(CRASRCPHIS.EQ_RECIPE_VERSION), in_node, "RECIPE_VERSION");
		CRASRCPHIS.MES_RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		
		COM_itoa_left(CRASRCPHIS.RECIPE_VERSION, CRASRCPHIS.MES_RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION));
		TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");
		memcpy(CRASRCPHIS.CMF_1, "PARAMETER", strlen("PARAMETER"));

	}
	if (c_action_type == 'A')
	{
		//Release Confirm Recipe
		sprintf(s_service_name, "%.*s", strlen("MESEAP_Reqeust_ReleaseConfirm_Recipe"), "MESEAP_Reqeust_ReleaseConfirm_Recipe");
		COM_add_null(s_service_name, sizeof(s_service_name));

		DBC_init_mrcprcpdef(&MRCPRCPDEF);
		TRS.copy(MRCPRCPDEF.FACTORY, sizeof(MRCPRCPDEF.FACTORY), in_node, "FACTORY");
		TRS.copy(MRCPRCPDEF.RES_ID, sizeof(MRCPRCPDEF.RES_ID), in_node, "RES_ID");
		TRS.copy(MRCPRCPDEF.SUBRES_ID, sizeof(MRCPRCPDEF.SUBRES_ID), in_node, "SUB_RES_ID");
		TRS.copy(MRCPRCPDEF.RECIPE, sizeof(MRCPRCPDEF.RECIPE), in_node, "RECIPE_ID");
		DBC_select_mrcprcpdef(1, &MRCPRCPDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RCP-0005");
			TRS.add_fieldmsg(out_node, "MRCPRCPVER SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "RECIPE_ID", MP_STR, sizeof(MRCPRCPDEF.RECIPE), MRCPRCPDEF.RECIPE);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//RECIPE  VERSION CHECK AND SELECT
		DBC_init_mrcprcpver(&MRCPRCPVER);
		memcpy(MRCPRCPVER.FACTORY, MRCPRCPDEF.FACTORY, sizeof(MRCPRCPVER.FACTORY));
		memcpy(MRCPRCPVER.RES_ID, MRCPRCPDEF.RES_ID, sizeof(MRCPRCPVER.RES_ID));
		memcpy(MRCPRCPVER.SUBRES_ID,MRCPRCPDEF.SUBRES_ID, sizeof(MRCPRCPVER.SUBRES_ID));
		memcpy(MRCPRCPVER.RECIPE, MRCPRCPDEF.RECIPE, sizeof(MRCPRCPVER.RECIPE));
		MRCPRCPVER.RECIPE_VERSION= TRS.get_int( in_node , "MES_RECIPE_VERSION");
		DBC_select_mrcprcpver(1, &MRCPRCPVER);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RCP-0029");
			TRS.add_fieldmsg(out_node, "MRCPRCPVER SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "RECIPE_ID", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
			TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPRCPVER.RECIPE_VERSION);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.copy(CRASRCPHIS.RECIPE_ID, sizeof(CRASRCPHIS.RECIPE_ID), in_node, "RECIPE_ID");
		TRS.copy(CRASRCPHIS.EQ_RECIPE_VERSION, sizeof(CRASRCPHIS.EQ_RECIPE_VERSION), in_node, "RECIPE_VERSION");
		CRASRCPHIS.MES_RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		
		COM_itoa_left(CRASRCPHIS.RECIPE_VERSION, CRASRCPHIS.MES_RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION));
		TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");

		if (COM_isspace(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID)) == MP_TRUE)
		{
			TRS.set_string(in_node, "PP_ID", MRCPRCPVER.PP_ID, sizeof(MRCPRCPVER.PP_ID));
			TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");
		}

		memcpy(CRASRCPHIS.CMF_1, "APPROVAL", strlen("APPROVAL"));

		//RECIPE VERSION PARAMETER OPEN
		DBC_init_mrcppraver(&MRCPPRAVER);
		/*
		TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.RES_ID), in_node, "FACTORY");
		TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
		TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "SUB_RES_ID");
		TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RES_ID), in_node, "RECIPE_ID");
		*/
		// 20210810 MES Application Memory leak 점검 및 수정
		// memcpy 메모리 침범 수정
		TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, "FACTORY");
		TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
		TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.SUBRES_ID), in_node, "SUB_RES_ID");
		TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "RECIPE_ID");

		MRCPPRAVER.RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		
		CDB_open_mrcppraver(2, &MRCPPRAVER);
		if(DB_error_code != DB_SUCCESS)
		{
			/*
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "MRCPPRAVER OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "RECIPE_ID", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			*/
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Error and log
			strcpy(s_msg_code, "RCP-0004");
			TRS.add_fieldmsg(out_node, "MRCPPRAVER OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
			TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRCPPRAVER.SUBRES_ID), MRCPPRAVER.SUBRES_ID);
			TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
			TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_mrcppraver(2, &MRCPPRAVER);
			//if(DB_error_code != DB_SUCCESS)
			// 20210810 MES Application Memory leak 점검 및 수정
			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_mrcppraver(2);
				// 20210810 MES Application Memory leak 점검 및 수정
				// break add
				break;
			}
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Close 추가
			// DB Error and log
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "RCP-0004");
				TRS.add_fieldmsg(out_node, "MRCPPRAVER FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
				TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRCPPRAVER.SUBRES_ID), MRCPPRAVER.SUBRES_ID);
				TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
				TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_mrcppraver(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(in_node, "PARAM_ITEM");
			TRS.add_string(list_item, "PARAM_VALUE", MRCPPRAVER.PARA_VALUE, sizeof(MRCPPRAVER.PARA_VALUE));
			TRS.add_string(list_item, "PARAM_DESC", MRCPPRAVER.PARA_DESC, sizeof(MRCPPRAVER.PARA_DESC));
			TRS.add_string(list_item, "UNIT_ID", MRCPPRAVER.CUS_UNIT, sizeof(MRCPPRAVER.CUS_UNIT));
			{
				char s_tmp[10];
				memset(s_tmp, ' ', 10);
				COM_itoa(s_tmp, MRCPPRAVER.CUS_MAX_VAL, 10);
				TRS.add_string(list_item, "SPEC_USL", s_tmp, 10);
				memset(s_tmp, ' ', 10);
				COM_itoa(s_tmp, MRCPPRAVER.CUS_MIN_VAL, 10);
				TRS.add_string(list_item, "SPEC_LSL", s_tmp, 10);
			}
		}
	}
	if (c_action_type == 'D')
	{
		//Management(Delete) Recipe
		sprintf(s_service_name, "%.*s", strlen("MESEAP_Reqeust_Management_Recipe"), "MESEAP_Reqeust_Management_Recipe");
		COM_add_null(s_service_name, sizeof(s_service_name));

		TRS.copy(CRASRCPHIS.RECIPE_ID, sizeof(CRASRCPHIS.RECIPE_ID), in_node, "RECIPE_ID");
		TRS.copy(CRASRCPHIS.EQ_RECIPE_VERSION, sizeof(CRASRCPHIS.EQ_RECIPE_VERSION), in_node, "RECIPE_VERSION");
		CRASRCPHIS.MES_RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		
		COM_itoa_left(CRASRCPHIS.RECIPE_VERSION, CRASRCPHIS.MES_RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION));
		TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");
		memcpy(CRASRCPHIS.CMF_1, "DELETE", strlen("DELETE"));
		TRS.set_char(in_node, "IUD_FLAG", 'D');
	}
	if (c_action_type == 'I')
	{
		//Management(Insert) Recipe
		sprintf(s_service_name, "%.*s", strlen("MESEAP_Reqeust_Management_Recipe"), "MESEAP_Reqeust_Management_Recipe");
		COM_add_null(s_service_name, sizeof(s_service_name));


		DBC_init_mrcprcpdef(&MRCPRCPDEF);
		TRS.copy(MRCPRCPDEF.FACTORY, sizeof(MRCPRCPDEF.FACTORY), in_node, "FACTORY");
		TRS.copy(MRCPRCPDEF.RES_ID, sizeof(MRCPRCPDEF.RES_ID), in_node, "RES_ID");
		TRS.copy(MRCPRCPDEF.SUBRES_ID, sizeof(MRCPRCPDEF.SUBRES_ID), in_node, "SUB_RES_ID");
		TRS.copy(MRCPRCPDEF.RECIPE, sizeof(MRCPRCPDEF.RECIPE), in_node, "RECIPE_ID");
		DBC_select_mrcprcpdef(1, &MRCPRCPDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RCP-0005");
			TRS.add_fieldmsg(out_node, "MRCPRCPVER SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "RECIPE_ID", MP_STR, sizeof(MRCPRCPDEF.RECIPE), MRCPRCPDEF.RECIPE);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//RECIPE  VERSION CHECK AND SELECT
		DBC_init_mrcprcpver(&MRCPRCPVER);
		memcpy(MRCPRCPVER.FACTORY, MRCPRCPDEF.FACTORY, sizeof(MRCPRCPVER.FACTORY));
		memcpy(MRCPRCPVER.RES_ID, MRCPRCPDEF.RES_ID, sizeof(MRCPRCPVER.RES_ID));
		memcpy(MRCPRCPVER.SUBRES_ID,MRCPRCPDEF.SUBRES_ID, sizeof(MRCPRCPVER.SUBRES_ID));
		memcpy(MRCPRCPVER.RECIPE, MRCPRCPDEF.RECIPE, sizeof(MRCPRCPVER.RECIPE));
		MRCPRCPVER.RECIPE_VERSION= TRS.get_int( in_node , "MES_RECIPE_VERSION");
		DBC_select_mrcprcpver(1, &MRCPRCPVER);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RCP-0029");
			TRS.add_fieldmsg(out_node, "MRCPRCPVER SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "RECIPE_ID", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
			TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPRCPVER.RECIPE_VERSION);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.copy(CRASRCPHIS.RECIPE_ID, sizeof(CRASRCPHIS.RECIPE_ID), in_node, "RECIPE_ID");
		TRS.copy(CRASRCPHIS.EQ_RECIPE_VERSION, sizeof(CRASRCPHIS.EQ_RECIPE_VERSION), in_node, "RECIPE_VERSION");
		CRASRCPHIS.MES_RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		
		COM_itoa_left(CRASRCPHIS.RECIPE_VERSION, CRASRCPHIS.MES_RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION));
		TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");

		if (COM_isspace(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID)) == MP_TRUE)
		{
			TRS.set_string(in_node, "PP_ID", MRCPRCPVER.PP_ID, sizeof(MRCPRCPVER.PP_ID));
			TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");
		}
		memcpy(CRASRCPHIS.CMF_1, "INSERT", strlen("INSERT"));
		TRS.set_char(in_node, "IUD_FLAG", 'I');

		//RECIPE VERSION PARAMETER OPEN
		DBC_init_mrcppraver(&MRCPPRAVER);
		/*
		TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.RES_ID), in_node, "FACTORY");
		TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
		TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "SUB_RES_ID");
		TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RES_ID), in_node, "RECIPE_ID");
		*/
		// 20210810 MES Application Memory leak 점검 및 수정
		// memcpy 메모리 침범 수정
		TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, "FACTORY");
		TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
		TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.SUBRES_ID), in_node, "SUB_RES_ID");
		TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "RECIPE_ID");

		MRCPPRAVER.RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		
		CDB_open_mrcppraver(2, &MRCPPRAVER);
		if(DB_error_code != DB_SUCCESS)
		{
			/*
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "MRCPPRAVER OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "RECIPE_ID", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			*/
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Error and log
			strcpy(s_msg_code, "RCP-0004");
			TRS.add_fieldmsg(out_node, "MRCPPRAVER OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
			TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRCPPRAVER.SUBRES_ID), MRCPPRAVER.SUBRES_ID);
			TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_mrcppraver(2, &MRCPPRAVER);
			//if(DB_error_code != DB_SUCCESS)
			// 20210810 MES Application Memory leak 점검 및 수정
			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_mrcppraver(2);
				// 20210810 MES Application Memory leak 점검 및 수정
				// break add
				break;
			}
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Close 추가
			// DB Error and log
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "RCP-0004");
				TRS.add_fieldmsg(out_node, "MRCPPRAVER FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
				TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRCPPRAVER.SUBRES_ID), MRCPPRAVER.SUBRES_ID);
				TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_mrcppraver(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(in_node, "PARAM_ITEM");
			TRS.add_string(list_item, "PARAM_VALUE", MRCPPRAVER.PARA_VALUE, sizeof(MRCPPRAVER.PARA_VALUE));
			TRS.add_string(list_item, "PARAM_DESC", MRCPPRAVER.PARA_DESC, sizeof(MRCPPRAVER.PARA_DESC));
			TRS.add_string(list_item, "UNIT_ID", MRCPPRAVER.CUS_UNIT, sizeof(MRCPPRAVER.CUS_UNIT));
			{
				char s_tmp[10];
				memset(s_tmp, ' ', 10);
				COM_itoa(s_tmp, MRCPPRAVER.CUS_MAX_VAL, 10);
				TRS.add_string(list_item, "SPEC_USL", s_tmp, 10);
				memset(s_tmp, ' ', 10);
				COM_itoa(s_tmp, MRCPPRAVER.CUS_MIN_VAL, 10);
				TRS.add_string(list_item, "SPEC_LSL", s_tmp, 10);
			}
		}
	}
	
	
	d_value = CDB_select_crasrcphis_scalar(2, &CRASRCPHIS) + 1; // SEQUENCE VALUE

	//CRASRCPHIS DATA
	CRASRCPHIS.KEY_SEQ = d_value;
	CRASRCPHIS.ACTION_FLAG =  c_action_type;
	memcpy(CRASRCPHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
	memcpy(CRASRCPHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	CRASRCPHIS.UP_DOWN_FLAG = 'D';
	TRS.copy(CRASRCPHIS.CMF_2, sizeof(CRASRCPHIS.CMF_2), in_node, "MSG_NO");
	TRS.copy(CRASRCPHIS.CMF_3, sizeof(CRASRCPHIS.CMF_3), in_node, "CIM_ID");
	TRS.copy(CRASRCPHIS.CMF_4, sizeof(CRASRCPHIS.CMF_4), in_node, "LINE_ID");

	CDB_insert_crasrcphis(&CRASRCPHIS);
	if(DB_error_code != DB_SUCCESS)
    {
		//DO NOTHING
	}

	/* MES to EAP SET CHANNEL*/
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
	 
	if(CallService(MODULE_EAP, 
		s_service_name,
		in_node, 
		out_node, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}

   	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

