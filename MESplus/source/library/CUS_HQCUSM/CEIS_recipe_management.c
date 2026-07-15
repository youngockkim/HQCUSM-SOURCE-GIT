/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_validate_lot.c
    Description : EAPMES Validate Lot Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Management_Recipe()
            + Setup service interface function
        - EAPMES_MANAGEMENT_RECIPE()
            + Main sub function of EAPMES_Management_Recipe function
            + Setup service main business function
        - EAPMES_Management_Recipe_Validation()
            + Main sub function of EAPMES_MANAGEMENT_RECIPE function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_MANAGEMENT_RECIPE()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  jh.Jung           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "RCPCore_common.h"

int EAPMES_MANAGEMENT_RECIPE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int EAPMES_RECIPE_MANAGEMENT_HISTORY_INSERT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
    EAPMES_Management_Recipe()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Management_Recipe(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	out_node = TRS.create_node("OUT_NODE");
	//HISOTRY LOG INSERT
    i_ret = EAPMES_RECIPE_MANAGEMENT_HISTORY_INSERT(s_msg_code, in_node, out_node);

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	TRS.init_node(out_node);

    i_ret = EAPMES_MANAGEMENT_RECIPE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_MANAGEMENT_RECIPE", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }
	 /* Save message code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

	/* Temp */
	/* 특정 에러처리를 무시할경우 사용 ERROR  */
	// VALIDATION 하라고 셋팅된 에러만 에러처리함.
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
	memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
	memcpy(MGCMLAGDAT.KEY_2, "VALIDATION", strlen("VALIDATION"));
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Management_Recipe", strlen("EAPMES_Management_Recipe"));
	memcpy(MGCMLAGDAT.KEY_4, s_msg_code, 9);
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'Y'))
	{
		//VALIDATION SKIP 이 아닌경우 에러발생
		//MGCMLAGDAT TABLE (@FACTORY_OPTION)에서 DATA_1 = 'Y' 이면 에러발생
	}
	else
	{
		//VALIDATION SKIP 일경우 무조건 성공 
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	}
    
    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    
	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	/***
	if(CallService(MODULE_EAP, 
		"MES_Management_Recipe", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}
	***/

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    //CEIS_Save_Message_Log(in_node, out_node);
    CEIS_Save_Message_Log_For_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_MANAGEMENT_RECIPE()
        - Main sub function of "EAPMES_Management_Recipe" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_MANAGEMENT_RECIPE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    
	struct MRCPRCPDEF_TAG MRCPRCPDEF;
	struct MRCPRCPVER_TAG MRCPRCPVER;
	TRSNode *tran_in;

    char s_sys_time[14];
	char c_create_flag = 'N';

    LOG_head("EAPMES_RECIPEID_LIST");
	TRS.log_add_all_members(in_node);
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

	//RECIPE  CHECK AND SELECT
	DBC_init_mrcprcpdef(&MRCPRCPDEF);
	TRS.copy(MRCPRCPDEF.FACTORY, sizeof(MRCPRCPDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRCPRCPDEF.RES_ID, sizeof(MRCPRCPDEF.RES_ID), in_node, "RES_ID");
	TRS.copy(MRCPRCPDEF.SUBRES_ID, sizeof(MRCPRCPDEF.SUBRES_ID), in_node, "SUB_RES_ID");
	TRS.copy(MRCPRCPDEF.RECIPE, sizeof(MRCPRCPDEF.RECIPE), in_node, "RECIPE_ID");
	DBC_select_mrcprcpdef(1, &MRCPRCPDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		TRS.copy(MRCPRCPDEF.RECIPE_DESC, sizeof(MRCPRCPDEF.RECIPE), in_node, "RECIPE_DESCRIPTION");
		c_create_flag = 'Y';
	}
	

	if (c_create_flag == 'Y')
	{
		//RECIPE CREATE
		tran_in = TRS.create_node("RECIPE_UPDATE_IN");
		TRS.add_char(tran_in, IN_PROCSTEP, 'I');
		TRS.add_nstring(tran_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
		TRS.add_char(tran_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
		TRS.add_nstring(tran_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
		TRS.add_nstring(tran_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
		TRS.add_nstring(tran_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
		TRS.add_nstring(tran_in, "RES_ID", TRS.get_string(in_node, "RES_ID"));
		TRS.add_string(tran_in, "RECIPE", MRCPRCPDEF.RECIPE, sizeof(MRCPRCPDEF.RECIPE));
		TRS.add_nstring(tran_in, "RECIPE_DESC", TRS.get_string(in_node, "RECIPE_DESCRIPTION"));
		TRS.add_char(tran_in, "APPROVAL_REQUIRE_FLAG", 'Y');

		if(RCP_UPDATE_RECIPE(s_msg_code, tran_in, out_node) == MP_FALSE)
		{
			TRS.free_node(tran_in);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		TRS.free_node(tran_in);
	}

	c_create_flag = 'N';
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
		c_create_flag = 'Y';
	}

	if (c_create_flag == 'Y')
	{
		//RECIPE VERSION CREATE
		tran_in = TRS.create_node("RECIPE_UPDATE_VERSION_IN");
		TRS.add_char(tran_in, IN_PROCSTEP, 'I');
		TRS.add_nstring(tran_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
		TRS.add_char(tran_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
		TRS.add_nstring(tran_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
		TRS.add_nstring(tran_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
		TRS.add_nstring(tran_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
		TRS.add_nstring(tran_in, "RES_ID", TRS.get_string(in_node, "RES_ID"));
		TRS.add_string(tran_in, "RECIPE", MRCPRCPDEF.RECIPE, sizeof(MRCPRCPDEF.RECIPE));
		TRS.add_string(tran_in, "RECIPE_DESC", MRCPRCPDEF.RECIPE_DESC, sizeof(MRCPRCPDEF.RECIPE_DESC));
		TRS.add_nstring(tran_in, "PP_ID", TRS.get_string(in_node, "PP_ID"));
		TRS.add_int(tran_in, "RECIPE_VERSION", MRCPRCPVER.RECIPE_VERSION);
		TRS.add_char(tran_in, "MODIFY_FLAG", ' ');
		TRS.add_nstring(tran_in, "PROC_TIME", "000000");
		if(RCP_UPDATE_RECIPE_VERSION(s_msg_code, tran_in, out_node) == MP_FALSE)
		{
			TRS.free_node(tran_in);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		TRS.free_node(tran_in);
	}

	if (TRS.get_char(in_node, "IUD_FLAG") == 'D')
	{
		DBC_delete_mrcprcpver(1, &MRCPRCPVER);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

	}
	
	if (DBC_select_mrcprcpver_scalar(101, &MRCPRCPVER) < 1)
	{

		//RECIPE DELETE 
		MRCPRCPDEF.DELETE_FLAG = 'Y';
		memcpy(MRCPRCPDEF.DELETE_TIME, s_sys_time, sizeof(MRCPRCPDEF.DELETE_TIME));
		TRS.copy(MRCPRCPDEF.DELETE_USER_ID, sizeof(MRCPRCPDEF.UPDATE_USER_ID), in_node, "USERID");
		DBC_update_mrcprcpdef(102, &MRCPRCPDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_RECIPEID_LIST_HISTORY_INSERT()
        - Main sub function of "EAPMES_RecipeID_List" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_RECIPE_MANAGEMENT_HISTORY_INSERT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    
	struct CRASRCPHIS_TAG CRASRCPHIS;
	struct MRASRESDEF_TAG MRASRESDEF;

	int i_list_count;
	TRSNode ** ITEM_LIST;

    char s_sys_time[14];
	double d_value = 0;

	int i = 0;

    LOG_head("EAPMES_RECIPE_PARAMETER_LIST_HISTORY_INSERT");
	TRS.log_add_all_members(in_node);
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

	TRS.set_nstring(in_node, "EQ_RECIPE_ID", TRS.get_string(in_node, "RECIPE_ID"));
	TRS.set_nstring(in_node, "EQ_RECIPE_VERSION", TRS.get_string(in_node, "RECIPE_VERSION"));

	CDB_init_crasrcphis(&CRASRCPHIS);
	TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");
	
	//RECIPE_ID / VERSION GET -> PP ID = [RECIPE ID] + '_' + [VERSION ]
	{
		int x = 0, z = 0;
		for ( x = sizeof(CRASRCPHIS.PP_ID) -1; x >= 0; x--)
		{
			if (CRASRCPHIS.PP_ID[x] == '_')
			{
				memcpy(CRASRCPHIS.RECIPE_ID, CRASRCPHIS.PP_ID, x);

				if ((sizeof(CRASRCPHIS.PP_ID) - x +1) >= 10)
					memcpy(CRASRCPHIS.RECIPE_VERSION, CRASRCPHIS.PP_ID+(x+1), 9);
				else
					memcpy(CRASRCPHIS.RECIPE_VERSION, CRASRCPHIS.PP_ID+(x+1), sizeof(CRASRCPHIS.PP_ID)  -x +1);
					
				z = 1;
				break;
			}
		}
		if (z == 0)
		{
			memcpy(CRASRCPHIS.RECIPE_ID, CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID));
			CRASRCPHIS.RECIPE_VERSION[0] = '0';
		}

		TRS.set_string(in_node, "RECIPE_ID", CRASRCPHIS.RECIPE_ID, sizeof(CRASRCPHIS.RECIPE_ID));
		TRS.set_string(in_node, "RECIPE_VERSION", CRASRCPHIS.RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION));
		CRASRCPHIS.MES_RECIPE_VERSION = COM_atoi(CRASRCPHIS.RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION));
		TRS.set_int(in_node, "MES_RECIPE_VERSION", CRASRCPHIS.MES_RECIPE_VERSION);
	}


	ITEM_LIST = TRS.get_list(in_node, "PARAM_ITEM");
    i_list_count = TRS.get_item_count(in_node, "PARAM_ITEM");

    for(i = 0; i < i_list_count; i++)
    {
		CDB_init_crasrcphis(&CRASRCPHIS);
		memcpy(CRASRCPHIS.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
		memcpy(CRASRCPHIS.RES_ID, MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
		TRS.copy(CRASRCPHIS.SUB_RES_ID, sizeof(CRASRCPHIS.SUB_RES_ID), in_node, "SUB_RES_ID");
		TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");
		TRS.copy(CRASRCPHIS.RECIPE_ID, sizeof(CRASRCPHIS.RECIPE_ID), in_node, "RECIPE_ID");
		TRS.copy(CRASRCPHIS.RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION), in_node, "RECIPE_VERSION");

		TRS.copy(CRASRCPHIS.CMF_5, sizeof(CRASRCPHIS.CMF_5), in_node, "EQ_RECIPE_ID"); //EQ RECIPE
		TRS.copy(CRASRCPHIS.EQ_RECIPE_VERSION, sizeof(CRASRCPHIS.EQ_RECIPE_VERSION), in_node, "EQ_RECIPE_VERSION"); //EQ RECIPE VERSION
		TRS.copy(CRASRCPHIS.RECIPE_DESC, sizeof(CRASRCPHIS.RECIPE_DESC), in_node, "RECIPE_DESCRIPTION");
		
	
		d_value = CDB_select_crasrcphis_scalar(2, &CRASRCPHIS) + 1; // SEQUENCE VALUE

		//CRASRCPHIS DATA
		CRASRCPHIS.KEY_SEQ = (int)d_value;
		CRASRCPHIS.ACTION_FLAG =  TRS.get_char(in_node, "IUD_FLAG");
		memcpy(CRASRCPHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		CRASRCPHIS.UP_DOWN_FLAG = 'U';
		TRS.copy(CRASRCPHIS.CREATE_TIME, sizeof(CRASRCPHIS.CREATE_TIME), in_node, "CLIENT_TIME");
		if (COM_isspace(CRASRCPHIS.CREATE_TIME, sizeof(CRASRCPHIS.CREATE_TIME)) == MP_TRUE)
		{
			memcpy(CRASRCPHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		}
		memcpy(CRASRCPHIS.CMF_1, "MANAGEMENT",  strlen("MANAGEMENT"));
		TRS.copy(CRASRCPHIS.CMF_2, sizeof(CRASRCPHIS.CMF_2), in_node, "MSG_NO");
		TRS.copy(CRASRCPHIS.CMF_3, sizeof(CRASRCPHIS.CMF_3), in_node, "CIM_ID");
		TRS.copy(CRASRCPHIS.CMF_4, sizeof(CRASRCPHIS.CMF_4), in_node, "LINE_ID");
		
		TRS.copy(CRASRCPHIS.PARAM_ID, sizeof(CRASRCPHIS.PARAM_ID), ITEM_LIST[i], "PARAM_NAME");
		TRS.copy(CRASRCPHIS.PARAM_DESC, sizeof(CRASRCPHIS.PARAM_DESC), ITEM_LIST[i], "PARAM_DESC");
		TRS.copy(CRASRCPHIS.CMF_6, sizeof(CRASRCPHIS.CMF_6), ITEM_LIST[i], "UNIT_ID");
		TRS.copy(CRASRCPHIS.ETC, sizeof(CRASRCPHIS.ETC), ITEM_LIST[i], "ETC");

		CRASRCPHIS.PARAM_VALUE = COM_atoi(TRS.get_string(ITEM_LIST[i], "PARAM_VALUE"), (int)strlen(TRS.get_string(ITEM_LIST[i], "PARAM_VALUE")));
		CRASRCPHIS.USL_VAL = COM_atoi(TRS.get_string(ITEM_LIST[i], "SPEC_USL"), (int)strlen(TRS.get_string(ITEM_LIST[i], "SPEC_USL")));
		CRASRCPHIS.LSL_VAL = COM_atoi(TRS.get_string(ITEM_LIST[i], "SPEC_USL"), (int)strlen(TRS.get_string(ITEM_LIST[i], "SPEC_USL")));
		CRASRCPHIS.MES_RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		CDB_insert_crasrcphis(&CRASRCPHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

	}

	//list 없을경우 in node 기준으로 insert 함
	if ( i == 0)
	{
		CDB_init_crasrcphis(&CRASRCPHIS);
		memcpy(CRASRCPHIS.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
		memcpy(CRASRCPHIS.RES_ID, MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
		TRS.copy(CRASRCPHIS.SUB_RES_ID, sizeof(CRASRCPHIS.SUB_RES_ID), in_node, "SUB_RES_ID");
		TRS.copy(CRASRCPHIS.PP_ID, sizeof(CRASRCPHIS.PP_ID), in_node, "PP_ID");
		TRS.copy(CRASRCPHIS.RECIPE_ID, sizeof(CRASRCPHIS.RECIPE_ID), in_node, "RECIPE_ID");
		TRS.copy(CRASRCPHIS.RECIPE_VERSION, sizeof(CRASRCPHIS.RECIPE_VERSION), in_node, "RECIPE_VERSION");

		TRS.copy(CRASRCPHIS.CMF_5, sizeof(CRASRCPHIS.CMF_5), in_node, "EQ_RECIPE_ID"); //EQ RECIPE
		TRS.copy(CRASRCPHIS.EQ_RECIPE_VERSION, sizeof(CRASRCPHIS.EQ_RECIPE_VERSION), in_node, "EQ_RECIPE_VERSION"); //EQ RECIPE VERSION
		TRS.copy(CRASRCPHIS.RECIPE_DESC, sizeof(CRASRCPHIS.RECIPE_DESC), in_node, "RECIPE_DESCRIPTION");
		
	
		d_value = CDB_select_crasrcphis_scalar(2, &CRASRCPHIS) + 1; // SEQUENCE VALUE

		//CRASRCPHIS DATA
		CRASRCPHIS.KEY_SEQ = (int)d_value;
		CRASRCPHIS.ACTION_FLAG =  TRS.get_char(in_node, "IUD_FLAG");
		memcpy(CRASRCPHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		CRASRCPHIS.UP_DOWN_FLAG = 'U';
		TRS.copy(CRASRCPHIS.CREATE_TIME, sizeof(CRASRCPHIS.CREATE_TIME), in_node, "CLIENT_TIME");
		if (COM_isspace(CRASRCPHIS.CREATE_TIME, sizeof(CRASRCPHIS.CREATE_TIME)) == MP_TRUE)
		{
			memcpy(CRASRCPHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		}
		memcpy(CRASRCPHIS.CMF_1, "MANAGEMENT",  strlen("MANAGEMENT"));
		TRS.copy(CRASRCPHIS.CMF_2, sizeof(CRASRCPHIS.CMF_2), in_node, "MSG_NO");
		TRS.copy(CRASRCPHIS.CMF_3, sizeof(CRASRCPHIS.CMF_3), in_node, "CIM_ID");
		TRS.copy(CRASRCPHIS.CMF_4, sizeof(CRASRCPHIS.CMF_4), in_node, "LINE_ID");
		
		CRASRCPHIS.MES_RECIPE_VERSION = TRS.get_int(in_node, "MES_RECIPE_VERSION");
		CDB_insert_crasrcphis(&CRASRCPHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}
	
	DB_commit(); //무조건 저장
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 