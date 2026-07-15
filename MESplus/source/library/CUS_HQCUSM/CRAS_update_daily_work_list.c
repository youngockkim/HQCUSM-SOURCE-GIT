/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CRAS_update_daily_work_list.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CRAS_Update_Daily_Work_List()
			+ View Lot
		- CRAS_UPDATE_DAILY_WORK_LIST()
			+ Main sub function of CRAS_Update_Daily_Work_List function
			+ View Operation List definition
		- CRAS_Update_Daily_Work_List_Validation()
			+ Main sub function of CRAS_Update_Daily_Work_List function
			+ Check the condition for view Operation List
	Detail Description
		- CRAS_Update_Daily_Work_List()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/08  YS KIM           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_Daily_Work_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CRAS_Update_Daily_Work_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Daily_Work_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CRAS_UPDATE_DAILY_WORK_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CRAS_Update_Daily_Work_List", out_node);

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
	CRAS_Update_Daily_Work_List()
		- Main sub function of "CRAS_Update_Daily_Work_List" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_DAILY_WORK_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
 	struct CWIPWRKDAY_TAG CWIPWRKDAY;
 	struct CWIPWRKDAY_TAG CWIPWRKDAY_SEQ;

    char   s_sys_time[14];

    LOG_head("CRAS_Update_Daily_Work_List");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CRAS_Update_Daily_Work_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
		CDB_init_cwipwrkday(&CWIPWRKDAY);
		TRS.copy(CWIPWRKDAY.FACTORY, sizeof(CWIPWRKDAY.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPWRKDAY.WORK_DATE, sizeof(CWIPWRKDAY.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPWRKDAY.LINE_ID, sizeof(CWIPWRKDAY.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPWRKDAY.RES_ID, sizeof(CWIPWRKDAY.RES_ID), in_node, "RES_ID");
		if(TRS.get_int(in_node, "SEQ_NUM") == 0)
		{
			//create seq
			CDB_init_cwipwrkday(&CWIPWRKDAY_SEQ);
			TRS.copy(CWIPWRKDAY_SEQ.FACTORY, sizeof(CWIPWRKDAY_SEQ.FACTORY), in_node, "FACTORY");
			TRS.copy(CWIPWRKDAY_SEQ.WORK_DATE, sizeof(CWIPWRKDAY_SEQ.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CWIPWRKDAY_SEQ.LINE_ID, sizeof(CWIPWRKDAY_SEQ.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CWIPWRKDAY_SEQ.RES_ID, sizeof(CWIPWRKDAY_SEQ.RES_ID), in_node, "RES_ID");
			CDB_select_cwipwrkday(100, &CWIPWRKDAY_SEQ);
			if(DB_error_code != DB_SUCCESS)
			{
				CWIPWRKDAY.SEQ_NUM = 1;
			
			}
			else
			{
				CWIPWRKDAY.SEQ_NUM = CWIPWRKDAY_SEQ.SEQ_NUM + 1;
			}

		}
		else
		{
			CWIPWRKDAY.SEQ_NUM  = TRS.get_int(in_node, "SEQ_NUM"); 
		}
		CDB_select_cwipwrkday(1, &CWIPWRKDAY); 
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				TRS.copy(CWIPWRKDAY.START_TIME, sizeof(CWIPWRKDAY.START_TIME), in_node, "START_TIME");
				TRS.copy(CWIPWRKDAY.END_TIME, sizeof(CWIPWRKDAY.END_TIME), in_node, "END_TIME");
				CWIPWRKDAY.STATE_TIME  = TRS.get_double(in_node, "STATE_TIME"); 
				CWIPWRKDAY.LOSS_QTY  = TRS.get_double(in_node, "LOSS_QTY"); 
				CWIPWRKDAY.DEFECT_QTY  = TRS.get_double(in_node, "DEFECT_QTY"); 
				TRS.copy(CWIPWRKDAY.EQ_STATUS_CODE, sizeof(CWIPWRKDAY.EQ_STATUS_CODE), in_node, "EQ_STATUS_CODE");
				CWIPWRKDAY.EQ_STATUS_FLAG = TRS.get_char(in_node, "EQ_STATUS_FLAG");
				TRS.copy(CWIPWRKDAY.EQ_TROUBLE_CODE, sizeof(CWIPWRKDAY.EQ_TROUBLE_CODE), in_node, "EQ_TROUBLE_CODE");
				TRS.copy(CWIPWRKDAY.OPER, sizeof(CWIPWRKDAY.OPER), in_node, "OPER");
				CWIPWRKDAY.WORK_SHIFT  = TRS.get_char(in_node, "WORK_SHIFT"); 
				TRS.copy(CWIPWRKDAY.RES_GROUP, sizeof(CWIPWRKDAY.RES_GROUP), in_node, "RES_GROUP");
				TRS.copy(CWIPWRKDAY.RES_CONFIGURE, sizeof(CWIPWRKDAY.RES_CONFIGURE), in_node, "RES_CONFIGURE");
				TRS.copy(CWIPWRKDAY.DETAIL_CATEGORY, sizeof(CWIPWRKDAY.DETAIL_CATEGORY), in_node, "DETAIL_CATEGORY");
				TRS.copy(CWIPWRKDAY.CHARGE_USER_ID, sizeof(CWIPWRKDAY.CHARGE_USER_ID), in_node, "CHARGE_USER_ID");
				TRS.copy(CWIPWRKDAY.TROUBLE_STATUS, sizeof(CWIPWRKDAY.TROUBLE_STATUS), in_node, "TROUBLE_STATUS");
				TRS.copy(CWIPWRKDAY.CAUSE_ANALYSIS, sizeof(CWIPWRKDAY.CAUSE_ANALYSIS), in_node, "CAUSE_ANALYSIS");
				TRS.copy(CWIPWRKDAY.CORRECTIVE_MEASURE, sizeof(CWIPWRKDAY.CORRECTIVE_MEASURE), in_node, "CORRECTIVE_MEASURE");
				TRS.copy(CWIPWRKDAY.CMF_1, sizeof(CWIPWRKDAY.CMF_1), in_node, "END_FLAG");
				TRS.copy(CWIPWRKDAY.CMF_2, sizeof(CWIPWRKDAY.CMF_2), in_node, "CMF_2");
				TRS.copy(CWIPWRKDAY.CMF_3, sizeof(CWIPWRKDAY.CMF_3), in_node, "CMF_3");
				TRS.copy(CWIPWRKDAY.CMF_4, sizeof(CWIPWRKDAY.CMF_4), in_node, "CMF_4");
				TRS.copy(CWIPWRKDAY.CMF_5, sizeof(CWIPWRKDAY.CMF_5), in_node, "CMF_5");
				TRS.copy(CWIPWRKDAY.CMF_6, sizeof(CWIPWRKDAY.CMF_6), in_node, "CMF_6");
				TRS.copy(CWIPWRKDAY.CMF_7, sizeof(CWIPWRKDAY.CMF_7), in_node, "CMF_7");
				TRS.copy(CWIPWRKDAY.CMF_8, sizeof(CWIPWRKDAY.CMF_8), in_node, "CMF_8");
				TRS.copy(CWIPWRKDAY.CMF_9, sizeof(CWIPWRKDAY.CMF_9), in_node, "CMF_9");
				TRS.copy(CWIPWRKDAY.CMF_10, sizeof(CWIPWRKDAY.CMF_10), in_node, "CMF_10");

				TRS.copy(CWIPWRKDAY.CREATE_USER_ID, sizeof(CWIPWRKDAY.CREATE_USER_ID), in_node, IN_USERID);
				DB_get_systime(CWIPWRKDAY.CREATE_TIME); 
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


				CDB_insert_cwipwrkday(&CWIPWRKDAY); 
				if(DB_error_code != DB_SUCCESS)
				{ 
					strcpy(s_msg_code, "RAS-0004"); 
					TRS.add_fieldmsg(out_node, "CWIPWRKDAY INSERT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAY.FACTORY), CWIPWRKDAY.FACTORY); 
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPWRKDAY.LINE_ID), CWIPWRKDAY.LINE_ID); 
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPWRKDAY.RES_ID), CWIPWRKDAY.RES_ID); 
					TRS.add_fieldmsg(out_node, "START_TIME", MP_STR, sizeof(CWIPWRKDAY.START_TIME), CWIPWRKDAY.START_TIME); 
					TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPWRKDAY.SEQ_NUM); 
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
				TRS.add_fieldmsg(out_node, "CWIPWRKDAY SELECT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAY.FACTORY), CWIPWRKDAY.FACTORY); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPWRKDAY.LINE_ID), CWIPWRKDAY.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPWRKDAY.RES_ID), CWIPWRKDAY.RES_ID); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPWRKDAY.SEQ_NUM); 
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
			TRS.copy(CWIPWRKDAY.START_TIME, sizeof(CWIPWRKDAY.START_TIME), in_node, "START_TIME");
			TRS.copy(CWIPWRKDAY.END_TIME, sizeof(CWIPWRKDAY.END_TIME), in_node, "END_TIME");
			CWIPWRKDAY.STATE_TIME  = TRS.get_double(in_node, "STATE_TIME"); 
			CWIPWRKDAY.LOSS_QTY  = TRS.get_double(in_node, "LOSS_QTY"); 
			CWIPWRKDAY.DEFECT_QTY  = TRS.get_double(in_node, "DEFECT_QTY"); 
			TRS.copy(CWIPWRKDAY.EQ_STATUS_CODE, sizeof(CWIPWRKDAY.EQ_STATUS_CODE), in_node, "EQ_STATUS_CODE");
			CWIPWRKDAY.EQ_STATUS_FLAG = TRS.get_char(in_node, "EQ_STATUS_FLAG");
			TRS.copy(CWIPWRKDAY.EQ_TROUBLE_CODE, sizeof(CWIPWRKDAY.EQ_TROUBLE_CODE), in_node, "EQ_TROUBLE_CODE");
			TRS.copy(CWIPWRKDAY.OPER, sizeof(CWIPWRKDAY.OPER), in_node, "OPER");
			CWIPWRKDAY.WORK_SHIFT  = TRS.get_char(in_node, "WORK_SHIFT"); 
			TRS.copy(CWIPWRKDAY.RES_GROUP, sizeof(CWIPWRKDAY.RES_GROUP), in_node, "RES_GROUP");
			TRS.copy(CWIPWRKDAY.RES_CONFIGURE, sizeof(CWIPWRKDAY.RES_CONFIGURE), in_node, "RES_CONFIGURE");
			TRS.copy(CWIPWRKDAY.DETAIL_CATEGORY, sizeof(CWIPWRKDAY.DETAIL_CATEGORY), in_node, "DETAIL_CATEGORY");
			TRS.copy(CWIPWRKDAY.CHARGE_USER_ID, sizeof(CWIPWRKDAY.CHARGE_USER_ID), in_node, "CHARGE_USER_ID");
			TRS.copy(CWIPWRKDAY.TROUBLE_STATUS, sizeof(CWIPWRKDAY.TROUBLE_STATUS), in_node, "TROUBLE_STATUS");
			TRS.copy(CWIPWRKDAY.CAUSE_ANALYSIS, sizeof(CWIPWRKDAY.CAUSE_ANALYSIS), in_node, "CAUSE_ANALYSIS");
			TRS.copy(CWIPWRKDAY.CORRECTIVE_MEASURE, sizeof(CWIPWRKDAY.CORRECTIVE_MEASURE), in_node, "CORRECTIVE_MEASURE");
			TRS.copy(CWIPWRKDAY.CMF_1, sizeof(CWIPWRKDAY.CMF_1), in_node, "END_FLAG");
			TRS.copy(CWIPWRKDAY.CMF_2, sizeof(CWIPWRKDAY.CMF_2), in_node, "CMF_2");
			TRS.copy(CWIPWRKDAY.CMF_3, sizeof(CWIPWRKDAY.CMF_3), in_node, "CMF_3");
			TRS.copy(CWIPWRKDAY.CMF_4, sizeof(CWIPWRKDAY.CMF_4), in_node, "CMF_4");
			TRS.copy(CWIPWRKDAY.CMF_5, sizeof(CWIPWRKDAY.CMF_5), in_node, "CMF_5");
			TRS.copy(CWIPWRKDAY.CMF_6, sizeof(CWIPWRKDAY.CMF_6), in_node, "CMF_6");
			TRS.copy(CWIPWRKDAY.CMF_7, sizeof(CWIPWRKDAY.CMF_7), in_node, "CMF_7");
			TRS.copy(CWIPWRKDAY.CMF_8, sizeof(CWIPWRKDAY.CMF_8), in_node, "CMF_8");
			TRS.copy(CWIPWRKDAY.CMF_9, sizeof(CWIPWRKDAY.CMF_9), in_node, "CMF_9");
			TRS.copy(CWIPWRKDAY.CMF_10, sizeof(CWIPWRKDAY.CMF_10), in_node, "CMF_10");

			TRS.copy(CWIPWRKDAY.UPDATE_USER_ID, sizeof(CWIPWRKDAY.UPDATE_USER_ID), in_node, IN_USERID);
			DB_get_systime(CWIPWRKDAY.UPDATE_TIME); 
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
			CDB_update_cwipwrkday(1, &CWIPWRKDAY);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "RAS-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPWRKDAY UPDATE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAY.FACTORY), CWIPWRKDAY.FACTORY); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPWRKDAY.LINE_ID), CWIPWRKDAY.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPWRKDAY.RES_ID), CWIPWRKDAY.RES_ID); 
				TRS.add_fieldmsg(out_node, "START_TIME", MP_STR, sizeof(CWIPWRKDAY.START_TIME), CWIPWRKDAY.START_TIME); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPWRKDAY.SEQ_NUM); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 
		}
	}
	else if(TRS.get_procstep(in_node) == '2')
	{
		CDB_init_cwipwrkday(&CWIPWRKDAY);
		TRS.copy(CWIPWRKDAY.FACTORY, sizeof(CWIPWRKDAY.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPWRKDAY.WORK_DATE, sizeof(CWIPWRKDAY.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPWRKDAY.LINE_ID, sizeof(CWIPWRKDAY.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPWRKDAY.RES_ID, sizeof(CWIPWRKDAY.RES_ID), in_node, "RES_ID");
		CWIPWRKDAY.SEQ_NUM = TRS.get_int(in_node, "SEQ_NUM");
		
		CDB_select_cwipwrkday(1, &CWIPWRKDAY); 
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
			}
			else
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
		}
		else
		{
			CDB_delete_cwipwrkday(1, &CWIPWRKDAY);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPWRKDAY DELETE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAY.FACTORY), CWIPWRKDAY.FACTORY); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPWRKDAY.WORK_DATE), CWIPWRKDAY.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPWRKDAY.LINE_ID), CWIPWRKDAY.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPWRKDAY.RES_ID), CWIPWRKDAY.RES_ID); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPWRKDAY.SEQ_NUM); 
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
	CRAS_Update_Daily_Work_List_Validation()
		- Main sub function of "CRAS_Update_Daily_Work_List" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Daily_Work_List_Validation(char *s_msg_code,
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