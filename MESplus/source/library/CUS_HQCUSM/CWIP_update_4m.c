/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_update_4m.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CWIP_Update_4m()
			+ View Lot
		- CWIP_UPDATE_4M()
			+ Main sub function of CWIP_Update_4m function
			+ View Operation List definition
		- CWIP_Update_4m_Validation()
			+ Main sub function of CWIP_Update_4m function
			+ Check the condition for view Operation List
	Detail Description
		- CWIP_Update_4m()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/08  YS KIM           Created
	2     2019/11/25  sy cha		 CUD : 4m form, 123 : 4m Process Team form

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_4m_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_Update_4m()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_4m(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_4M(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_Update_4m", out_node);

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
	CWIP_Update_4m()
		- Main sub function of "CWIP_Update_4m" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_4M(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
 	struct CWIPFMIHIS_TAG CWIPFMIHIS;
 	struct CWIPFMIHIS_TAG CWIPFMIHIS_SEQ;

    char   s_sys_time[14];

    LOG_head("CWIP_Update_4m");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CWIP_Update_4m_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{
		CDB_init_cwipfmihis(&CWIPFMIHIS);
		TRS.copy(CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPFMIHIS.FM_TYPE, sizeof(CWIPFMIHIS.FM_TYPE), in_node, "FM_TYPE");
		TRS.copy(CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID), in_node, "LINE_ID");
		//CWIPFMIHIS.SEQ_NUM  = TRS.get_int(in_node, "SEQ_NUM"); 


		//create seq
		CDB_init_cwipfmihis(&CWIPFMIHIS_SEQ);
		TRS.copy(CWIPFMIHIS_SEQ.FACTORY, sizeof(CWIPFMIHIS_SEQ.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPFMIHIS_SEQ.FM_TYPE, sizeof(CWIPFMIHIS_SEQ.FM_TYPE), in_node, "FM_TYPE");
		TRS.copy(CWIPFMIHIS_SEQ.WORK_DATE, sizeof(CWIPFMIHIS_SEQ.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPFMIHIS_SEQ.LINE_ID, sizeof(CWIPFMIHIS_SEQ.LINE_ID), in_node, "LINE_ID");		
		CDB_select_cwipfmihis(100, &CWIPFMIHIS_SEQ);
		if(DB_error_code != DB_SUCCESS)
		{
			CWIPFMIHIS.SEQ_NUM = 1;
			
		}
		else
		{
			CWIPFMIHIS.SEQ_NUM = CWIPFMIHIS_SEQ.SEQ_NUM + 1;
		}

		TRS.copy(CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER), in_node, "OPER");
		TRS.copy(CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID), in_node, "RES_ID");
		//TRS.copy(CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME), in_node, "APPLY_TIME");
		TRS.copy(CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND), in_node, "KIND");
		TRS.copy(CWIPFMIHIS.BEFORE, sizeof(CWIPFMIHIS.BEFORE), in_node, "BEFORE");
		TRS.copy(CWIPFMIHIS.AFTER, sizeof(CWIPFMIHIS.AFTER), in_node, "AFTER");
		TRS.copy(CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT), in_node, "DEPARTMENT");
		TRS.copy(CWIPFMIHIS.CHARGE_USER_ID, sizeof(CWIPFMIHIS.CHARGE_USER_ID), in_node, "CHARGE_USER_ID");
		TRS.copy(CWIPFMIHIS.UNUSUAL_DESC, sizeof(CWIPFMIHIS.UNUSUAL_DESC), in_node, "UNUSUAL_DESC");

		// For Process Team 
		TRS.copy(CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER), in_node, "OPER1");
		TRS.copy(CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1), in_node, "OPER2");
		TRS.copy(CWIPFMIHIS.CMF_2, sizeof(CWIPFMIHIS.CMF_2), in_node, "NAME");
		TRS.copy(CWIPFMIHIS.CMF_3, sizeof(CWIPFMIHIS.CMF_3), in_node, "CMF_3");
		TRS.copy(CWIPFMIHIS.CMF_4, sizeof(CWIPFMIHIS.CMF_4), in_node, "CMF_4");

		TRS.copy(CWIPFMIHIS.CMF_5, sizeof(CWIPFMIHIS.CMF_5), in_node, "CMF_5");
		TRS.copy(CWIPFMIHIS.CMF_6, sizeof(CWIPFMIHIS.CMF_6), in_node, "CMF_6");
		TRS.copy(CWIPFMIHIS.CMF_7, sizeof(CWIPFMIHIS.CMF_7), in_node, "CMF_7");
		TRS.copy(CWIPFMIHIS.CMF_8, sizeof(CWIPFMIHIS.CMF_8), in_node, "CMF_8");
		TRS.copy(CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9), in_node, "CMF_9");
		TRS.copy(CWIPFMIHIS.CMF_10, sizeof(CWIPFMIHIS.CMF_10), in_node, "CMF_10");
		TRS.copy(CWIPFMIHIS.CREATE_USER_ID, sizeof(CWIPFMIHIS.CREATE_USER_ID), in_node, IN_USERID);
		DB_get_systime(CWIPFMIHIS.APPLY_TIME); 
		DB_get_systime(CWIPFMIHIS.CREATE_TIME);
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}

		CDB_insert_cwipfmihis(&CWIPFMIHIS); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPFMIHIS INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
			TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPFMIHIS.WORK_DATE), CWIPFMIHIS.WORK_DATE); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
			TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPFMIHIS.SEQ_NUM); 			
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
		CDB_init_cwipfmihis(&CWIPFMIHIS);
		TRS.copy(CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPFMIHIS.FM_TYPE, sizeof(CWIPFMIHIS.FM_TYPE), in_node, "FM_TYPE");
		TRS.copy(CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID), in_node, "LINE_ID");
		CWIPFMIHIS.SEQ_NUM  = TRS.get_int(in_node, "SEQ_NUM"); 		
		CDB_select_cwipfmihis(1, &CWIPFMIHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPFMIHIS INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
			TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPFMIHIS.WORK_DATE), CWIPFMIHIS.WORK_DATE); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
			TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPFMIHIS.SEQ_NUM); 			
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
		else
		{
			TRS.copy(CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER), in_node, "OPER1");
			TRS.copy(CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID), in_node, "RES_ID");
			TRS.copy(CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME), in_node, "APPLY_TIME");
			TRS.copy(CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND), in_node, "KIND");
			TRS.copy(CWIPFMIHIS.BEFORE, sizeof(CWIPFMIHIS.BEFORE), in_node, "BEFORE");
			TRS.copy(CWIPFMIHIS.AFTER, sizeof(CWIPFMIHIS.AFTER), in_node, "AFTER");
			TRS.copy(CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT), in_node, "DEPARTMENT");
			TRS.copy(CWIPFMIHIS.CHARGE_USER_ID, sizeof(CWIPFMIHIS.CHARGE_USER_ID), in_node, "CHARGE_USER_ID");
			TRS.copy(CWIPFMIHIS.UNUSUAL_DESC, sizeof(CWIPFMIHIS.UNUSUAL_DESC), in_node, "UNUSUAL_DESC");

			// For Process Team 
			TRS.copy(CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1), in_node, "OPER2");
			TRS.copy(CWIPFMIHIS.CMF_2, sizeof(CWIPFMIHIS.CMF_2), in_node, "NAME");
			TRS.copy(CWIPFMIHIS.CMF_3, sizeof(CWIPFMIHIS.CMF_3), in_node, "CMF_3");
			TRS.copy(CWIPFMIHIS.CMF_4, sizeof(CWIPFMIHIS.CMF_4), in_node, "CMF_4");

			TRS.copy(CWIPFMIHIS.CMF_5, sizeof(CWIPFMIHIS.CMF_5), in_node, "CMF_5");
			TRS.copy(CWIPFMIHIS.CMF_6, sizeof(CWIPFMIHIS.CMF_6), in_node, "CMF_6");
			TRS.copy(CWIPFMIHIS.CMF_7, sizeof(CWIPFMIHIS.CMF_7), in_node, "CMF_7");
			TRS.copy(CWIPFMIHIS.CMF_8, sizeof(CWIPFMIHIS.CMF_8), in_node, "CMF_8");
			TRS.copy(CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9), in_node, "CMF_9");
			TRS.copy(CWIPFMIHIS.CMF_10, sizeof(CWIPFMIHIS.CMF_10), in_node, "CMF_10");
			TRS.copy(CWIPFMIHIS.UPDATE_USER_ID, sizeof(CWIPFMIHIS.UPDATE_USER_ID), in_node, IN_USERID);
			DB_get_systime(CWIPFMIHIS.UPDATE_TIME); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 

			CDB_update_cwipfmihis(1, &CWIPFMIHIS);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPFMIHIS UPDATE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
				TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPFMIHIS.WORK_DATE), CWIPFMIHIS.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPFMIHIS.SEQ_NUM); 				
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 
		}
	}
	else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
	{
		CDB_init_cwipfmihis(&CWIPFMIHIS);
		TRS.copy(CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPFMIHIS.FM_TYPE, sizeof(CWIPFMIHIS.FM_TYPE), in_node, "FM_TYPE");
		TRS.copy(CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID), in_node, "LINE_ID");
		CWIPFMIHIS.SEQ_NUM  = TRS.get_int(in_node, "SEQ_NUM"); 
		CDB_select_cwipfmihis(1, &CWIPFMIHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPFMIHIS INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
			TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPFMIHIS.WORK_DATE), CWIPFMIHIS.WORK_DATE); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
			TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPFMIHIS.SEQ_NUM); 			
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
		else
		{
			CDB_delete_cwipfmihis(1, &CWIPFMIHIS);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPFMIHIS DELETE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
				TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPFMIHIS.WORK_DATE), CWIPFMIHIS.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPFMIHIS.SEQ_NUM); 				
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
	CWIP_Update_4m_Validation()
		- Main sub function of "CWIP_Update_4m" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_4m_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	char s_curr_time[14];
	char s_work_time[14];
	char s_calc_work_time[14];

	int i_diff_sec;

	struct CWIPFMIHIS_TAG CWIPFMIHIS;
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

	memset(s_curr_time, ' ', sizeof(s_curr_time));
	DB_get_systime(s_curr_time);

	CDB_init_cwipfmihis(&CWIPFMIHIS);
	TRS.copy(CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME), in_node, "APPLY_TIME");

	if ((TRS.get_procstep(in_node) == MP_STEP_UPDATE)  | (TRS.get_procstep(in_node) == MP_STEP_DELETE))
	{
		DB_get_calc_time(s_calc_work_time, CWIPFMIHIS.APPLY_TIME, 3, 3);		

		COM_diff_time_sec(&i_diff_sec, s_curr_time, s_calc_work_time);

		if (i_diff_sec > 0)
		{
			// 수정 가능한 시간이 지났습니다.
			strcpy(s_msg_code, "WIP-0601");
			TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
			TRS.add_fieldmsg(out_node, "LIMIT TIME", MP_STR, sizeof(s_calc_work_time), s_calc_work_time);
			TRS.add_fieldmsg(out_node, "CURRENT TIME", MP_STR, sizeof(s_curr_time), s_curr_time);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			return MP_FALSE;
		}
	}

    return MP_TRUE;
}