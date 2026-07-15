/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_update_product_plan.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CWIP_Update_Product_Plan()
			+ View Lot
		- CWIP_UPDATE_PRODUCT_PLAN()
			+ Main sub function of CWIP_Update_Product_Plan function
			+ View Operation List definition
		- CWIP_Update_Product_Plan_Validation()
			+ Main sub function of CWIP_Update_Product_Plan function
			+ Check the condition for view Operation List
	Detail Description
		- CWIP_Update_Product_Plan()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/10/17  JGCHOI          Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Product_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_Update_Product_Plan()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Product_Plan(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_PRODUCT_PLAN(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_Update_Product_Plan", out_node);

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
	CWIP_Update_Product_Plan()
		- Main sub function of "CWIP_Update_Product_Plan" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_PRODUCT_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CFACPLNDAY_TAG CFACPLNDAY;
	struct CFACPLNDAY_TAG CFACPLNDAY_U;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	
	TRSNode ** PLAN_LIST;

	char   s_sys_time[14];
	int    i_count = 0;
	int    i = 0;

    LOG_head("CWIP_Update_Product_Plan");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CWIP_Update_Product_Plan_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

	PLAN_LIST = TRS.get_list(in_node, "PLAN_LIST");
	i_count = TRS.get_item_count(in_node, "PLAN_LIST");

	for(i = 0; i < i_count; i++)
	{
		CDB_init_cfacplnday(&CFACPLNDAY);
		TRS.copy(CFACPLNDAY.WORK, sizeof(CFACPLNDAY.WORK), PLAN_LIST[i], "WORK");
		TRS.copy(CFACPLNDAY.PLANT, sizeof(CFACPLNDAY.PLANT), PLAN_LIST[i], "PLANT");
		TRS.copy(CFACPLNDAY.LINE, sizeof(CFACPLNDAY.LINE), PLAN_LIST[i], "LINE");
		TRS.copy(CFACPLNDAY.PRODUCT, sizeof(CFACPLNDAY.PRODUCT), PLAN_LIST[i], "PRODUCT");

		CDB_select_cfacplnday(1, &CFACPLNDAY);
		
		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			if(DB_error_code == DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0600");//The production plan already exists.
				TRS.add_fieldmsg(out_node, "CFACPLNDAY SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK", MP_STR, sizeof(CFACPLNDAY.WORK), CFACPLNDAY.WORK);
				TRS.add_fieldmsg(out_node, "PLANT", MP_STR, sizeof(CFACPLNDAY.PLANT), CFACPLNDAY.PLANT);
				TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CFACPLNDAY.LINE), CFACPLNDAY.LINE);
				TRS.add_fieldmsg(out_node, "PRODUCT", MP_STR, sizeof(CFACPLNDAY.PRODUCT), CFACPLNDAY.PRODUCT);
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
					strcpy(s_msg_code, "SPC-0026");
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}

				TRS.add_fieldmsg(out_node, "CFACPLNDAY SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK", MP_STR, sizeof(CFACPLNDAY.WORK), CFACPLNDAY.WORK);
				TRS.add_fieldmsg(out_node, "PLANT", MP_STR, sizeof(CFACPLNDAY.PLANT), CFACPLNDAY.PLANT);
				TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CFACPLNDAY.LINE), CFACPLNDAY.LINE);
				TRS.add_fieldmsg(out_node, "PRODUCT", MP_STR, sizeof(CFACPLNDAY.PRODUCT), CFACPLNDAY.PRODUCT);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				return MP_FALSE;
			}
		}

		CDB_init_cfacplnday(&CFACPLNDAY);
		TRS.copy(CFACPLNDAY.WORK, sizeof(CFACPLNDAY.WORK), PLAN_LIST[i], "WORK");
		TRS.copy(CFACPLNDAY.PLANT, sizeof(CFACPLNDAY.PLANT), PLAN_LIST[i], "PLANT");
		TRS.copy(CFACPLNDAY.LINE, sizeof(CFACPLNDAY.LINE), PLAN_LIST[i], "LINE");

		// Execl Upload 한 MAT_ID를 MWIPMATDEF 에서 조회해서 MAT_ID, MAT_SHORT_DESC 넣도록 수정
		DBC_init_mwipmatdef(&MWIPMATDEF);
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), PLAN_LIST[i], "PRODUCT");
		MWIPMATDEF.MAT_VER = 1;
		DBC_select_mwipmatdef(1, &MWIPMATDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		memcpy(CFACPLNDAY.PRODUCT, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		memcpy(CFACPLNDAY.PRODUCT_DESC, MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));

		//TRS.copy(CFACPLNDAY.PRODUCT, sizeof(CFACPLNDAY.PRODUCT), PLAN_LIST[i], "PRODUCT");
		//TRS.copy(CFACPLNDAY.PRODUCT_DESC, sizeof(CFACPLNDAY.PRODUCT_DESC), PLAN_LIST[i], "PRODUCT_DESC");

		CFACPLNDAY.EXP_WATT_PER_PC = TRS.get_double(PLAN_LIST[i], "EXP_WATT_PER_PC");
		CFACPLNDAY.PLN_OUTPUT = TRS.get_double(PLAN_LIST[i], "PLN_OUTPUT");
		CFACPLNDAY.PLN_YIELD = TRS.get_double(PLAN_LIST[i], "PLN_YIELD");
		CFACPLNDAY.PLN_OUTPUT_GOOD_WATT = TRS.get_double(PLAN_LIST[i], "PLN_OUTPUT_GOOD_WATT");
		CFACPLNDAY.PLN_FEL_DEFECT_RATE = TRS.get_double(PLAN_LIST[i], "PLN_FEL_DEFECT_RATE");
		CFACPLNDAY.PLN_CELL_LOSS_IN_MODULE = TRS.get_double(PLAN_LIST[i], "PLN_CELL_LOSS_IN_MODULE");
		CFACPLNDAY.PLN_CELL_LOSS_IN_CELL = TRS.get_double(PLAN_LIST[i], "PLN_CELL_LOSS_IN_CELL");
		/*TRS.copy(CFACPLNDAY.CREATE_USER_ID, sizeof(CFACPLNDAY.CREATE_USER_ID), PLAN_LIST[i], "CREATE_USER_ID");
		TRS.copy(CFACPLNDAY.CREATE_TIME, sizeof(CFACPLNDAY.CREATE_TIME), PLAN_LIST[i], "CREATE_TIME");
		TRS.copy(CFACPLNDAY.UPDATE_USER_ID, sizeof(CFACPLNDAY.UPDATE_USER_ID), PLAN_LIST[i], "UPDATE_USER_ID");
		TRS.copy(CFACPLNDAY.UPDATE_TIME, sizeof(CFACPLNDAY.UPDATE_TIME), PLAN_LIST[i], "UPDATE_TIME");*/
			
		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			TRS.copy(CFACPLNDAY.CREATE_USER_ID, sizeof(CFACPLNDAY.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CFACPLNDAY.CREATE_TIME, s_sys_time, sizeof(CFACPLNDAY.CREATE_TIME));
			CDB_insert_cfacplnday(&CFACPLNDAY);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CFACPLNDAY INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK", MP_STR, sizeof(CFACPLNDAY.WORK), CFACPLNDAY.WORK);
				TRS.add_fieldmsg(out_node, "PLANT", MP_STR, sizeof(CFACPLNDAY.PLANT), CFACPLNDAY.PLANT);
				TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CFACPLNDAY.LINE), CFACPLNDAY.LINE);
				TRS.add_fieldmsg(out_node, "PRODUCT", MP_STR, sizeof(CFACPLNDAY.PRODUCT), CFACPLNDAY.PRODUCT);
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
			CDB_init_cfacplnday(&CFACPLNDAY_U);
			TRS.copy(CFACPLNDAY_U.WORK, sizeof(CFACPLNDAY_U.WORK), PLAN_LIST[i], "WORK");
			TRS.copy(CFACPLNDAY_U.PLANT, sizeof(CFACPLNDAY_U.PLANT), PLAN_LIST[i], "PLANT");
			TRS.copy(CFACPLNDAY_U.LINE, sizeof(CFACPLNDAY_U.LINE), PLAN_LIST[i], "LINE");
			TRS.copy(CFACPLNDAY_U.PRODUCT, sizeof(CFACPLNDAY_U.PRODUCT), PLAN_LIST[i], "PRODUCT");
			CDB_select_cfacplnday_for_update(1, &CFACPLNDAY_U);			
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CFACPLNDAY SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK", MP_STR, sizeof(CFACPLNDAY_U.WORK), CFACPLNDAY_U.WORK);
				TRS.add_fieldmsg(out_node, "PLANT", MP_STR, sizeof(CFACPLNDAY_U.PLANT), CFACPLNDAY_U.PLANT);
				TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CFACPLNDAY_U.LINE), CFACPLNDAY_U.LINE);
				TRS.add_fieldmsg(out_node, "PRODUCT", MP_STR, sizeof(CFACPLNDAY_U.PRODUCT), CFACPLNDAY_U.PRODUCT);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//----[Addtional Logic for Update Case]----

			memcpy(CFACPLNDAY.CREATE_USER_ID, CFACPLNDAY_U.CREATE_USER_ID, sizeof(CFACPLNDAY.CREATE_USER_ID));
			memcpy(CFACPLNDAY.CREATE_TIME, CFACPLNDAY_U.CREATE_TIME, sizeof(CFACPLNDAY.CREATE_TIME));
			TRS.copy(CFACPLNDAY.UPDATE_USER_ID, sizeof(CFACPLNDAY.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CFACPLNDAY.UPDATE_TIME, s_sys_time, sizeof(CFACPLNDAY.UPDATE_TIME));

			CDB_update_cfacplnday(1, &CFACPLNDAY);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CFACPLNDAY UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK", MP_STR, sizeof(CFACPLNDAY.WORK), CFACPLNDAY.WORK);
				TRS.add_fieldmsg(out_node, "PLANT", MP_STR, sizeof(CFACPLNDAY.PLANT), CFACPLNDAY.PLANT);
				TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CFACPLNDAY.LINE), CFACPLNDAY.LINE);
				TRS.add_fieldmsg(out_node, "PRODUCT", MP_STR, sizeof(CFACPLNDAY.PRODUCT), CFACPLNDAY.PRODUCT);
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
			CDB_delete_cfacplnday(1, &CFACPLNDAY);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CFACPLNDAY DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK", MP_STR, sizeof(CFACPLNDAY.WORK), CFACPLNDAY.WORK);
				TRS.add_fieldmsg(out_node, "PLANT", MP_STR, sizeof(CFACPLNDAY.PLANT), CFACPLNDAY.PLANT);
				TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CFACPLNDAY.LINE), CFACPLNDAY.LINE);
				TRS.add_fieldmsg(out_node, "PRODUCT", MP_STR, sizeof(CFACPLNDAY.PRODUCT), CFACPLNDAY.PRODUCT);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_Update_Product_Plan_Validation()
		- Main sub function of "CWIP_Update_Product_Plan" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Product_Plan_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct CFACPLNDAY_TAG CFACPLNDAY;
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

	return MP_TRUE;
}