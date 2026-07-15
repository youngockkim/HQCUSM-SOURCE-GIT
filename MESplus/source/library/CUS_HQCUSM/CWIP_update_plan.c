/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_update_plan.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CWIP_Update_Plan()
			+ View Lot
		- CWIP_UPDATE_PLAN()
			+ Main sub function of CWIP_Update_Plan function
			+ View Operation List definition
		- CWIP_Update_Plan_Validation()
			+ Main sub function of CWIP_Update_Plan function
			+ Check the condition for view Operation List
	Detail Description
		- CWIP_Update_Plan()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/08  YS KIM           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_Update_Plan()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Plan(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_PLAN(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_Update_Plan", out_node);

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
	CWIP_Update_Plan()
		- Main sub function of "CWIP_Update_Plan" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
 	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    char   s_sys_time[14];

    LOG_head("CWIP_Update_Plan");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CWIP_Update_Plan_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

	if(TRS.get_procstep(in_node) == '1')
	{
		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "WORK_DATE");
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "LINE_ID");

		CDB_select_mgcmtbldat(1, &MGCMTBLDAT); 
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				TRS.copy(MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1), in_node, "PLAN_EL_QTY");
				TRS.copy(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2), in_node, "PLAN_FQC_QTY");
				TRS.copy(MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3), in_node, "PLAN_FQC_MW");
				TRS.copy(MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4), in_node, "PLAN_YIELD");
				TRS.copy(MGCMTBLDAT.DATA_5, sizeof(MGCMTBLDAT.DATA_5), in_node, "B_PLAN_EL_QTY");
				TRS.copy(MGCMTBLDAT.DATA_6, sizeof(MGCMTBLDAT.DATA_6), in_node, "B_PLAN_FQC_QTY");
				TRS.copy(MGCMTBLDAT.DATA_7, sizeof(MGCMTBLDAT.DATA_7), in_node, "B_PLAN_FQC_MW");
				TRS.copy(MGCMTBLDAT.DATA_8, sizeof(MGCMTBLDAT.DATA_8), in_node, "B_PLAN_YIELD");

				TRS.copy(MGCMTBLDAT.CREATE_USER_ID, sizeof(MGCMTBLDAT.CREATE_USER_ID), in_node, IN_USERID);
				DB_get_systime(MGCMTBLDAT.CREATE_TIME); 
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


				CDB_insert_mgcmtbldat(&MGCMTBLDAT); 
				if(DB_error_code != DB_SUCCESS)
				{ 
					strcpy(s_msg_code, "WIP-0004"); 
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT INSERT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY); 
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME); 
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1); 
					TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2); 
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
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT INSERT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY); 
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME); 
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1); 
				TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2); 
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
			TRS.copy(MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1), in_node, "PLAN_EL_QTY");
			TRS.copy(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2), in_node, "PLAN_FQC_QTY");
			TRS.copy(MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3), in_node, "PLAN_FQC_MW");
			TRS.copy(MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4), in_node, "PLAN_YIELD");
			TRS.copy(MGCMTBLDAT.DATA_5, sizeof(MGCMTBLDAT.DATA_5), in_node, "B_PLAN_EL_QTY");
			TRS.copy(MGCMTBLDAT.DATA_6, sizeof(MGCMTBLDAT.DATA_6), in_node, "B_PLAN_FQC_QTY");
			TRS.copy(MGCMTBLDAT.DATA_7, sizeof(MGCMTBLDAT.DATA_7), in_node, "B_PLAN_FQC_MW");
			TRS.copy(MGCMTBLDAT.DATA_8, sizeof(MGCMTBLDAT.DATA_8), in_node, "B_PLAN_YIELD");

			TRS.copy(MGCMTBLDAT.UPDATE_USER_ID, sizeof(MGCMTBLDAT.UPDATE_USER_ID), in_node, IN_USERID);
			DB_get_systime(MGCMTBLDAT.UPDATE_TIME); 
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
			CDB_update_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT INSERT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY); 
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME); 
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1); 
				TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2); 
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
	CWIP_Update_Plan_Validation()
		- Main sub function of "CWIP_Update_Plan" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Plan_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
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