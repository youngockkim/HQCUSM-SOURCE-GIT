/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_update_ctm.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CWIP_Update_Ctm()
			+ View Lot
		- CWIP_UPDATE_CTM()
			+ Main sub function of CWIP_Update_Ctm function
			+ View Operation List definition
		- CWIP_Update_Ctm_Validation()
			+ Main sub function of CWIP_Update_Ctm function
			+ Check the condition for view Operation List
	Detail Description
		- CWIP_Update_Ctm()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/10/17  JGCHOI          Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Ctm_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_Update_Ctm()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Ctm(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_CTM(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_Update_Ctm", out_node);

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
	CWIP_Update_Ctm()
		- Main sub function of "CWIP_Update_Ctm" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_CTM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CWIPCTMHIS_TAG CWIPCTMHIS;
    struct CWIPCTMHIS_TAG CWIPCTMHIS_U;

	TRSNode ** CTM_LIST;

    char   s_sys_time[14];
	int i_count = 0;
	int i;
	int i_update_flag = MP_FALSE;

    LOG_head("CWIP_UPDATE_CTM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("i_item_count", MP_INT, TRS.get_item_count(in_node, "CTM_LIST"));
    
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

    if(CWIP_Update_Ctm_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	CTM_LIST = TRS.get_list(in_node, "CTM_LIST");
	i_count = TRS.get_item_count(in_node, "CTM_LIST");

	for(i = 0; i < i_count; i++)
	{
		CDB_init_cwipctmhis(&CWIPCTMHIS);
		TRS.copy(CWIPCTMHIS.FACTORY, sizeof(CWIPCTMHIS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPCTMHIS.WORK_DATE, sizeof(CWIPCTMHIS.WORK_DATE), CTM_LIST[i], "WORK_DATE");
		TRS.copy(CWIPCTMHIS.LINE_ID, sizeof(CWIPCTMHIS.LINE_ID), CTM_LIST[i], "LINE_ID");
		TRS.copy(CWIPCTMHIS.FROM_TIME, sizeof(CWIPCTMHIS.FROM_TIME), CTM_LIST[i], "FROM_TIME");
		TRS.copy(CWIPCTMHIS.TO_TIME, sizeof(CWIPCTMHIS.TO_TIME), CTM_LIST[i], "TO_TIME");
		CDB_select_cwipctmhis(1, &CWIPCTMHIS);
		
		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			i_update_flag = MP_FALSE;
			if(DB_error_code == DB_SUCCESS)
			{
				i_update_flag = MP_TRUE;
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

				TRS.add_fieldmsg(out_node, "CWIPCTMHIS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTMHIS.FACTORY), CWIPCTMHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTMHIS.WORK_DATE), CWIPCTMHIS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTMHIS.LINE_ID), CWIPCTMHIS.LINE_ID);
				TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(CWIPCTMHIS.FROM_TIME), CWIPCTMHIS.FROM_TIME);
				TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR, sizeof(CWIPCTMHIS.TO_TIME), CWIPCTMHIS.TO_TIME);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				return MP_FALSE;
			}
		}
					
		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			CDB_init_cwipctmhis(&CWIPCTMHIS);
			TRS.copy(CWIPCTMHIS.FACTORY, sizeof(CWIPCTMHIS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPCTMHIS.WORK_DATE, sizeof(CWIPCTMHIS.WORK_DATE), CTM_LIST[i], "WORK_DATE");
			TRS.copy(CWIPCTMHIS.LINE_ID, sizeof(CWIPCTMHIS.LINE_ID), CTM_LIST[i], "LINE_ID");
			TRS.copy(CWIPCTMHIS.FROM_TIME, sizeof(CWIPCTMHIS.FROM_TIME), CTM_LIST[i], "FROM_TIME");
			TRS.copy(CWIPCTMHIS.TO_TIME, sizeof(CWIPCTMHIS.TO_TIME), CTM_LIST[i], "TO_TIME");

			if(TRS.str_cmp(CTM_LIST[i], "ITEM_NAME", "OFF_SET") == 0)
			{
				CWIPCTMHIS.OFF_SET = TRS.get_double(CTM_LIST[i], "OFF_SET");
			}
			else if(TRS.str_cmp(CTM_LIST[i], "ITEM_NAME", "AREA_CELL") == 0)
			{
				CWIPCTMHIS.AREA_CELL = TRS.get_double(CTM_LIST[i], "AREA_CELL");
			}
			else if(TRS.str_cmp(CTM_LIST[i], "ITEM_NAME", "BASE_CTM") == 0)
			{
				CWIPCTMHIS.BASE_CTM = TRS.get_double(CTM_LIST[i], "BASE_CTM");
			}
			else if(TRS.str_cmp(CTM_LIST[i], "ITEM_NAME", "HALF_CELL_MAT_ID") == 0)
			{
				TRS.copy(CWIPCTMHIS.HALF_CELL_MAT_ID, sizeof(CWIPCTMHIS.HALF_CELL_MAT_ID), CTM_LIST[i], "HALF_CELL_MAT_ID");
			}
			else if(TRS.str_cmp(CTM_LIST[i], "ITEM_NAME", "ORDER_ID") == 0)
			{
				TRS.copy(CWIPCTMHIS.ORDER_ID, sizeof(CWIPCTMHIS.ORDER_ID), CTM_LIST[i], "ORDER_ID");
			}
			else if(TRS.str_cmp(CTM_LIST[i], "ITEM_NAME", "PROD_MAT_ID") == 0)
			{
				TRS.copy(CWIPCTMHIS.PROD_MAT_ID, sizeof(CWIPCTMHIS.PROD_MAT_ID), CTM_LIST[i], "PROD_MAT_ID");
			}	

			TRS.copy(CWIPCTMHIS.CMF_1, sizeof(CWIPCTMHIS.CMF_1), CTM_LIST[i], "CMF_1");
			TRS.copy(CWIPCTMHIS.CMF_2, sizeof(CWIPCTMHIS.CMF_2), CTM_LIST[i], "CMF_2");
			TRS.copy(CWIPCTMHIS.CMF_3, sizeof(CWIPCTMHIS.CMF_3), CTM_LIST[i], "CMF_3");
			TRS.copy(CWIPCTMHIS.CMF_4, sizeof(CWIPCTMHIS.CMF_4), CTM_LIST[i], "CMF_4");
			TRS.copy(CWIPCTMHIS.CMF_5, sizeof(CWIPCTMHIS.CMF_5), CTM_LIST[i], "CMF_5");

			if(i_update_flag == MP_TRUE)
			{
				CDB_init_cwipctmhis(&CWIPCTMHIS_U);
				TRS.copy(CWIPCTMHIS_U.FACTORY, sizeof(CWIPCTMHIS_U.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPCTMHIS_U.WORK_DATE, sizeof(CWIPCTMHIS_U.WORK_DATE), CTM_LIST[i], "WORK_DATE");
				TRS.copy(CWIPCTMHIS_U.LINE_ID, sizeof(CWIPCTMHIS_U.LINE_ID), CTM_LIST[i], "LINE_ID");
				TRS.copy(CWIPCTMHIS_U.FROM_TIME, sizeof(CWIPCTMHIS_U.FROM_TIME), CTM_LIST[i], "FROM_TIME");
				TRS.copy(CWIPCTMHIS_U.TO_TIME, sizeof(CWIPCTMHIS_U.TO_TIME), CTM_LIST[i], "TO_TIME");

				CDB_select_cwipctmhis_for_update(1, &CWIPCTMHIS_U);			
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTMHIS.FACTORY), CWIPCTMHIS.FACTORY);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTMHIS.WORK_DATE), CWIPCTMHIS.WORK_DATE);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTMHIS.LINE_ID), CWIPCTMHIS.LINE_ID);
					TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(CWIPCTMHIS.FROM_TIME), CWIPCTMHIS.FROM_TIME);
					TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR, sizeof(CWIPCTMHIS.TO_TIME), CWIPCTMHIS.TO_TIME);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				memcpy(CWIPCTMHIS.CREATE_USER_ID, CWIPCTMHIS_U.CREATE_USER_ID, sizeof(CWIPCTMHIS.CREATE_USER_ID));
				memcpy(CWIPCTMHIS.CREATE_TIME, CWIPCTMHIS_U.CREATE_TIME, sizeof(CWIPCTMHIS.CREATE_TIME));
				TRS.copy(CWIPCTMHIS.UPDATE_USER_ID, sizeof(CWIPCTMHIS.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CWIPCTMHIS.UPDATE_TIME, s_sys_time, sizeof(CWIPCTMHIS.UPDATE_TIME));

				CDB_update_cwipctmhis(1, &CWIPCTMHIS);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPCTMHIS UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTMHIS.FACTORY), CWIPCTMHIS.FACTORY);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTMHIS.WORK_DATE), CWIPCTMHIS.WORK_DATE);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTMHIS.LINE_ID), CWIPCTMHIS.LINE_ID);
					TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(CWIPCTMHIS.FROM_TIME), CWIPCTMHIS.FROM_TIME);
					TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR, sizeof(CWIPCTMHIS.TO_TIME), CWIPCTMHIS.TO_TIME);
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
				TRS.copy(CWIPCTMHIS.CREATE_USER_ID, sizeof(CWIPCTMHIS.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CWIPCTMHIS.CREATE_TIME, s_sys_time, sizeof(CWIPCTMHIS.CREATE_TIME));
				CDB_insert_cwipctmhis(&CWIPCTMHIS);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPCTMHIS INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTMHIS.FACTORY), CWIPCTMHIS.FACTORY);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTMHIS.WORK_DATE), CWIPCTMHIS.WORK_DATE);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTMHIS.LINE_ID), CWIPCTMHIS.LINE_ID);
					TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(CWIPCTMHIS.FROM_TIME), CWIPCTMHIS.FROM_TIME);
					TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR, sizeof(CWIPCTMHIS.TO_TIME), CWIPCTMHIS.TO_TIME);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			
		}
		else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
		{
			CDB_init_cwipctmhis(&CWIPCTMHIS);
			TRS.copy(CWIPCTMHIS.FACTORY, sizeof(CWIPCTMHIS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPCTMHIS.WORK_DATE, sizeof(CWIPCTMHIS.WORK_DATE), CTM_LIST[i], "WORK_DATE");
			TRS.copy(CWIPCTMHIS.LINE_ID, sizeof(CWIPCTMHIS.LINE_ID), CTM_LIST[i], "LINE_ID");
			TRS.copy(CWIPCTMHIS.FROM_TIME, sizeof(CWIPCTMHIS.FROM_TIME), CTM_LIST[i], "FROM_TIME");
			TRS.copy(CWIPCTMHIS.TO_TIME, sizeof(CWIPCTMHIS.TO_TIME), CTM_LIST[i], "TO_TIME");
			TRS.copy(CWIPCTMHIS.ORDER_ID, sizeof(CWIPCTMHIS.ORDER_ID), CTM_LIST[i], "ORDER_ID");
			CWIPCTMHIS.OFF_SET = TRS.get_double(CTM_LIST[i], "OFF_SET");
			CWIPCTMHIS.BASE_CTM = TRS.get_double(CTM_LIST[i], "BASE_CTM");
			CWIPCTMHIS.AREA_CELL = TRS.get_double(CTM_LIST[i], "AREA_CELL");
			TRS.copy(CWIPCTMHIS.PROD_MAT_ID, sizeof(CWIPCTMHIS.PROD_MAT_ID), CTM_LIST[i], "PROD_MAT_ID");
			TRS.copy(CWIPCTMHIS.HALF_CELL_MAT_ID, sizeof(CWIPCTMHIS.HALF_CELL_MAT_ID), CTM_LIST[i], "HALF_CELL_MAT_ID");
			TRS.copy(CWIPCTMHIS.CMF_1, sizeof(CWIPCTMHIS.CMF_1), CTM_LIST[i], "CMF_1");
			TRS.copy(CWIPCTMHIS.CMF_2, sizeof(CWIPCTMHIS.CMF_2), CTM_LIST[i], "CMF_2");
			TRS.copy(CWIPCTMHIS.CMF_3, sizeof(CWIPCTMHIS.CMF_3), CTM_LIST[i], "CMF_3");
			TRS.copy(CWIPCTMHIS.CMF_4, sizeof(CWIPCTMHIS.CMF_4), CTM_LIST[i], "CMF_4");
			TRS.copy(CWIPCTMHIS.CMF_5, sizeof(CWIPCTMHIS.CMF_5), CTM_LIST[i], "CMF_5");

			CDB_init_cwipctmhis(&CWIPCTMHIS_U);
			TRS.copy(CWIPCTMHIS_U.FACTORY, sizeof(CWIPCTMHIS_U.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPCTMHIS_U.WORK_DATE, sizeof(CWIPCTMHIS_U.WORK_DATE), CTM_LIST[i], "WORK_DATE");
			TRS.copy(CWIPCTMHIS_U.LINE_ID, sizeof(CWIPCTMHIS_U.LINE_ID), CTM_LIST[i], "LINE_ID");
			TRS.copy(CWIPCTMHIS_U.FROM_TIME, sizeof(CWIPCTMHIS_U.FROM_TIME), CTM_LIST[i], "FROM_TIME");
			TRS.copy(CWIPCTMHIS_U.TO_TIME, sizeof(CWIPCTMHIS_U.TO_TIME), CTM_LIST[i], "TO_TIME");
			
			CDB_select_cwipctmhis_for_update(1, &CWIPCTMHIS_U);			
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTMHIS.FACTORY), CWIPCTMHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTMHIS.WORK_DATE), CWIPCTMHIS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTMHIS.LINE_ID), CWIPCTMHIS.LINE_ID);
				TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(CWIPCTMHIS.FROM_TIME), CWIPCTMHIS.FROM_TIME);
				TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR, sizeof(CWIPCTMHIS.TO_TIME), CWIPCTMHIS.TO_TIME);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			memcpy(CWIPCTMHIS.CREATE_USER_ID, CWIPCTMHIS_U.CREATE_USER_ID, sizeof(CWIPCTMHIS.CREATE_USER_ID));
			memcpy(CWIPCTMHIS.CREATE_TIME, CWIPCTMHIS_U.CREATE_TIME, sizeof(CWIPCTMHIS.CREATE_TIME));
			TRS.copy(CWIPCTMHIS.UPDATE_USER_ID, sizeof(CWIPCTMHIS.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CWIPCTMHIS.UPDATE_TIME, s_sys_time, sizeof(CWIPCTMHIS.UPDATE_TIME));

			CDB_update_cwipctmhis(1, &CWIPCTMHIS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPCTMHIS UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTMHIS.FACTORY), CWIPCTMHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTMHIS.WORK_DATE), CWIPCTMHIS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTMHIS.LINE_ID), CWIPCTMHIS.LINE_ID);
				TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(CWIPCTMHIS.FROM_TIME), CWIPCTMHIS.FROM_TIME);
				TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR, sizeof(CWIPCTMHIS.TO_TIME), CWIPCTMHIS.TO_TIME);
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
			CDB_delete_cwipctmhis(1, &CWIPCTMHIS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPCTMHIS DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTMHIS.FACTORY), CWIPCTMHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTMHIS.WORK_DATE), CWIPCTMHIS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTMHIS.LINE_ID), CWIPCTMHIS.LINE_ID);
				TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(CWIPCTMHIS.FROM_TIME), CWIPCTMHIS.FROM_TIME);
				TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR, sizeof(CWIPCTMHIS.TO_TIME), CWIPCTMHIS.TO_TIME);
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
	CWIP_Update_Ctm_Validation()
		- Main sub function of "CWIP_Update_Ctm" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Ctm_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
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