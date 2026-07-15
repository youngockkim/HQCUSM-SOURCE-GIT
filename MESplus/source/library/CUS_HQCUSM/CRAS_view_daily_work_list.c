/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CRAS_view_daily_work_list.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CRAS_View_Daily_Work_List()
			+ View Lot
		- CRAS_VIEW_DAILY_WORK_LIST()
			+ Main sub function of CRAS_View_Daily_Work_List function
			+ View Operation List definition
		- CRAS_View_Daily_Work_List_Validation()
			+ Main sub function of CRAS_View_Daily_Work_List function
			+ Check the condition for view Operation List
	Detail Description
		- CRAS_View_Daily_Work_List()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/08  YS KIM           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_View_Daily_Work_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CRAS_View_Daily_Work_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Daily_Work_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CRAS_VIEW_DAILY_WORK_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CRAS_View_Daily_Work_List", out_node);

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
	CRAS_View_Daily_Work_List()
		- Main sub function of "CRAS_View_Daily_Work_List" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_DAILY_WORK_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct RSUMRESDWH_TAG RSUMRESDWH;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CWIPWRKDAY_TAG CWIPWRKDAY;
	struct MSECUSRDEF_TAG MSECUSRDEF;

    TRSNode *list_item;

    int i_step;
	int iCnt = 0;

    LOG_head("CRAS_View_Daily_Work_List");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CRAS_View_Daily_Work_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
    

    if (TRS.get_procstep(in_node) == '1')
    {
        i_step = 100;
		CDB_init_rsumresdwh(&RSUMRESDWH);
		TRS.copy(RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH.FACTORY), in_node, IN_FACTORY);
		TRS.copy(RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWH.LINE_ID), in_node, "LINE_ID");
		TRS.copy(RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER), in_node, "OPER");
		TRS.copy(RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID), in_node, "RES_ID");
		RSUMRESDWH.STATE_TIME = TRS.get_double(in_node, "LEAD_TIME");

		CDB_open_rsumresdwh(i_step, &RSUMRESDWH);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "RSUMRESDWH OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMRESDWH.FACTORY), RSUMRESDWH.FACTORY);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMRESDWH.LINE_ID), RSUMRESDWH.LINE_ID);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMRESDWH.WORK_DATE), RSUMRESDWH.WORK_DATE);

			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		while(1)
		{
			CDB_fetch_rsumresdwh(i_step, &RSUMRESDWH);
			if(DB_error_code == DB_NOT_FOUND)
			{
				DBC_close_mrasresdef(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "RSUMRESDWH FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMRESDWH.FACTORY), RSUMRESDWH.FACTORY);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMRESDWH.LINE_ID), RSUMRESDWH.LINE_ID);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMRESDWH.WORK_DATE), RSUMRESDWH.WORK_DATE);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				DBC_close_mrasresdef(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(iCnt > 1000)
			{
				DBC_close_mrasresdef(i_step);
				break;
			}

			/* Construct out node */
			list_item = TRS.add_node(out_node, "TROUBLE_LIST");
			TRS.add_string(list_item, "FACTORY", RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH.FACTORY));
			TRS.add_string(list_item, "WORK_DATE", RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH.WORK_DATE));
			TRS.add_string(list_item, "LINE_ID", RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWH.LINE_ID));

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
			memcpy(MGCMTBLDAT.KEY_1, RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWH.LINE_ID));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "GCM-0008");
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
					//TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					DBC_close_mrasresdef(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "LINE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_string(list_item, "OPER", RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER));
			TRS.add_string(list_item, "RES_ID", RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));

			DBC_init_mrasresdef(&MRASRESDEF);
			TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
			memcpy(MRASRESDEF.RES_ID, RSUMRESDWH.RES_ID, sizeof(MRASRESDEF.RES_ID));
			DBC_select_mrasresdef(1, &MRASRESDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0003");
				TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				DBC_close_mrasresdef(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));

			TRS.add_string(list_item, "E10_TROUBLE_TYPE", RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE));

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_EQ_STATUS, strlen(HQCEL_M1_GCM_EQ_STATUS));
			memcpy(MGCMTBLDAT.KEY_1, RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "GCM-0008");
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
					//TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					DBC_close_mrasresdef(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "E10_TROUBLE_TYPE_DESC", MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3));
			}

			TRS.add_string(list_item, "TRAN_TIME", RSUMRESDWH.TRAN_TIME, sizeof(RSUMRESDWH.TRAN_TIME));

			TRS.add_string(list_item, "END_TIME", RSUMRESDWH.END_TIME, sizeof(RSUMRESDWH.END_TIME));
			TRS.add_double(list_item, "STATE_TIME", RSUMRESDWH.STATE_TIME);
			TRS.add_string(list_item, "LINE_ID", RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWH.LINE_ID));
			iCnt++;
		}
    }
	else if (TRS.get_procstep(in_node) == '2')
    {
        i_step = 100;
		CDB_init_cwipwrkday(&CWIPWRKDAY);
		TRS.copy(CWIPWRKDAY.FACTORY, sizeof(CWIPWRKDAY.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPWRKDAY.WORK_DATE, sizeof(CWIPWRKDAY.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPWRKDAY.LINE_ID, sizeof(CWIPWRKDAY.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPWRKDAY.OPER, sizeof(CWIPWRKDAY.OPER), in_node, "OPER");
		TRS.copy(CWIPWRKDAY.RES_ID, sizeof(CWIPWRKDAY.RES_ID), in_node, "RES_ID");
		TRS.copy(CWIPWRKDAY.EQ_STATUS_CODE, sizeof(CWIPWRKDAY.EQ_STATUS_CODE), in_node, "EQ_STATUS_CODE");
		TRS.copy(CWIPWRKDAY.EQ_TROUBLE_CODE, sizeof(CWIPWRKDAY.EQ_TROUBLE_CODE), in_node, "EQ_TROUBLE_CODE");
		TRS.copy(CWIPWRKDAY.CMF_1, sizeof(CWIPWRKDAY.CMF_1), in_node, "END_FLAG");
		CDB_open_cwipwrkday(i_step, &CWIPWRKDAY); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			/*
			strcpy(s_msg_code, "CRAS-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPWRKDAY OPEN", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAY.FACTORY), CWIPWRKDAY.FACTORY); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPWRKDAY.LINE_ID), CWIPWRKDAY.LINE_ID); 
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPWRKDAY.RES_ID), CWIPWRKDAY.RES_ID); 
			TRS.add_fieldmsg(out_node, "START_TIME", MP_STR, sizeof(CWIPWRKDAY.START_TIME), CWIPWRKDAY.START_TIME); 
			TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPWRKDAY.SEQ_NUM); 
			*/
			// 20210810 MES Application Memory leak 점검 및 수정
			// log edit
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CWIPWRKDAY OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAY.FACTORY), CWIPWRKDAY.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPWRKDAY.WORK_DATE), CWIPWRKDAY.WORK_DATE);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPWRKDAY.LINE_ID), CWIPWRKDAY.LINE_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(CWIPWRKDAY.OPER), CWIPWRKDAY.OPER);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPWRKDAY.RES_ID), CWIPWRKDAY.RES_ID);
			TRS.add_fieldmsg(out_node, "EQ_STATUS_CODE", MP_STR, sizeof(CWIPWRKDAY.EQ_STATUS_CODE), CWIPWRKDAY.EQ_STATUS_CODE);
			TRS.add_fieldmsg(out_node, "EQ_TROUBLE_CODE", MP_STR, sizeof(CWIPWRKDAY.EQ_TROUBLE_CODE), CWIPWRKDAY.EQ_TROUBLE_CODE);
			TRS.add_fieldmsg(out_node, "CMF_1", MP_STR, sizeof(CWIPWRKDAY.CMF_1), CWIPWRKDAY.CMF_1);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
		while(1)
		{
			CDB_fetch_cwipwrkday(i_step, &CWIPWRKDAY); 
			/*
			if(DB_error_code != DB_SUCCESS)
			{
				CDB_close_cwipwrkday(i_step);
				break;
			}
			*/
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Error and log
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwipwrkday(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CWIPWRKDAY FETCH", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAY.FACTORY), CWIPWRKDAY.FACTORY); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPWRKDAY.WORK_DATE), CWIPWRKDAY.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPWRKDAY.LINE_ID), CWIPWRKDAY.LINE_ID); 
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(CWIPWRKDAY.OPER), CWIPWRKDAY.OPER); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPWRKDAY.RES_ID), CWIPWRKDAY.RES_ID); 
				TRS.add_fieldmsg(out_node, "EQ_STATUS_CODE", MP_STR, sizeof(CWIPWRKDAY.EQ_STATUS_CODE), CWIPWRKDAY.EQ_STATUS_CODE); 
				TRS.add_fieldmsg(out_node, "EQ_TROUBLE_CODE", MP_STR, sizeof(CWIPWRKDAY.EQ_TROUBLE_CODE), CWIPWRKDAY.EQ_TROUBLE_CODE); 
				TRS.add_fieldmsg(out_node, "CMF_1", MP_STR, sizeof(CWIPWRKDAY.CMF_1), CWIPWRKDAY.CMF_1); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_cwipwrkday(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "FACTORY", CWIPWRKDAY.FACTORY, sizeof(CWIPWRKDAY.FACTORY));
			TRS.add_string(list_item, "LINE_ID", CWIPWRKDAY.LINE_ID, sizeof(CWIPWRKDAY.LINE_ID));

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
			memcpy(MGCMTBLDAT.KEY_1, CWIPWRKDAY.LINE_ID, sizeof(CWIPWRKDAY.LINE_ID));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "GCM-0008");
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
					//TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipwrkday(i_step);

					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "LINE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_string(list_item, "RES_ID", CWIPWRKDAY.RES_ID, sizeof(CWIPWRKDAY.RES_ID));

			DBC_init_mrasresdef(&MRASRESDEF);
			TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
			memcpy(MRASRESDEF.RES_ID, CWIPWRKDAY.RES_ID, sizeof(MRASRESDEF.RES_ID));
			DBC_select_mrasresdef(1, &MRASRESDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0003");
				TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				
				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipwrkday(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));

			TRS.add_string(list_item, "START_TIME", CWIPWRKDAY.START_TIME, sizeof(CWIPWRKDAY.START_TIME));
			TRS.add_int(list_item, "SEQ_NUM", CWIPWRKDAY.SEQ_NUM);
			TRS.add_string(list_item, "END_TIME", CWIPWRKDAY.END_TIME, sizeof(CWIPWRKDAY.END_TIME));
			TRS.add_double(list_item, "STATE_TIME", CWIPWRKDAY.STATE_TIME);
			TRS.add_double(list_item, "LOSS_QTY", CWIPWRKDAY.LOSS_QTY);
			TRS.add_double(list_item, "DEFECT_QTY", CWIPWRKDAY.DEFECT_QTY);
			TRS.add_string(list_item, "EQ_STATUS_CODE", CWIPWRKDAY.EQ_STATUS_CODE, sizeof(CWIPWRKDAY.EQ_STATUS_CODE));

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_EQ_STATUS, strlen(HQCEL_M1_GCM_EQ_STATUS));
			memcpy(MGCMTBLDAT.KEY_1, CWIPWRKDAY.EQ_STATUS_CODE, sizeof(CWIPWRKDAY.EQ_STATUS_CODE));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "GCM-0008");
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
					//TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					
					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipwrkday(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "EQ_STATUS_DESC", MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3));
			}

			TRS.add_char(list_item, "EQ_STATUS_FLAG", CWIPWRKDAY.EQ_STATUS_FLAG);
			TRS.add_string(list_item, "EQ_TROUBLE_CODE", CWIPWRKDAY.EQ_TROUBLE_CODE, sizeof(CWIPWRKDAY.EQ_TROUBLE_CODE));

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_EQ_TROUBLE, strlen(HQCEL_M1_GCM_EQ_TROUBLE));
			memcpy(MGCMTBLDAT.KEY_1, CWIPWRKDAY.EQ_TROUBLE_CODE, sizeof(CWIPWRKDAY.EQ_TROUBLE_CODE));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "GCM-0008");
					TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
					//TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
										
					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipwrkday(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "EQ_TROUBLE_DESC", MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3));
			}

			TRS.add_string(list_item, "OPER", CWIPWRKDAY.OPER, sizeof(CWIPWRKDAY.OPER));

			/*DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MWIPOPRDEF.OPER, MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY); 
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}
			TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));*/

			TRS.add_string(list_item, "WORK_DATE", CWIPWRKDAY.WORK_DATE, sizeof(CWIPWRKDAY.WORK_DATE));
			TRS.add_char(list_item, "WORK_SHIFT", CWIPWRKDAY.WORK_SHIFT);
			TRS.add_string(list_item, "RES_GROUP", CWIPWRKDAY.RES_GROUP, sizeof(CWIPWRKDAY.RES_GROUP));
			TRS.add_string(list_item, "RES_CONFIGURE", CWIPWRKDAY.RES_CONFIGURE, sizeof(CWIPWRKDAY.RES_CONFIGURE));
			TRS.add_string(list_item, "DETAIL_CATEGORY", CWIPWRKDAY.DETAIL_CATEGORY, sizeof(CWIPWRKDAY.DETAIL_CATEGORY));
			TRS.add_string(list_item, "CHARGE_USER_ID", CWIPWRKDAY.CHARGE_USER_ID, sizeof(CWIPWRKDAY.CHARGE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPWRKDAY.CHARGE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					//TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (CWIPWRKDAY CHARGE_USER_ID)", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipwrkday(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}

			}
			TRS.add_string(list_item, "CHARGE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));


			TRS.add_string(list_item, "TROUBLE_STATUS", CWIPWRKDAY.TROUBLE_STATUS, sizeof(CWIPWRKDAY.TROUBLE_STATUS));
			TRS.add_string(list_item, "CAUSE_ANALYSIS", CWIPWRKDAY.CAUSE_ANALYSIS, sizeof(CWIPWRKDAY.CAUSE_ANALYSIS));
			TRS.add_string(list_item, "CORRECTIVE_MEASURE", CWIPWRKDAY.CORRECTIVE_MEASURE, sizeof(CWIPWRKDAY.CORRECTIVE_MEASURE));
			TRS.add_string(list_item, "CREATE_USER_ID", CWIPWRKDAY.CREATE_USER_ID, sizeof(CWIPWRKDAY.CREATE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPWRKDAY.CREATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					//TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (CWIPWRKDAY CREATE_USER_ID)", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipwrkday(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}
			}
			TRS.add_string(list_item, "CREATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

			TRS.add_string(list_item, "CREATE_TIME", CWIPWRKDAY.CREATE_TIME, sizeof(CWIPWRKDAY.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CWIPWRKDAY.UPDATE_USER_ID, sizeof(CWIPWRKDAY.UPDATE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPWRKDAY.UPDATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					//TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					// 20210810 MES Application Memory leak 점검 및 수정
					// log edit
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (CWIPWRKDAY UPDATE_USER_ID)", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipwrkday(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}
			}
			TRS.add_string(list_item, "UPDATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

			TRS.add_string(list_item, "UPDATE_TIME", CWIPWRKDAY.UPDATE_TIME, sizeof(CWIPWRKDAY.UPDATE_TIME));
			TRS.add_string(list_item, "CMF_1", CWIPWRKDAY.CMF_1, sizeof(CWIPWRKDAY.CMF_1));
			TRS.add_string(list_item, "CMF_2", CWIPWRKDAY.CMF_2, sizeof(CWIPWRKDAY.CMF_2));
			TRS.add_string(list_item, "CMF_3", CWIPWRKDAY.CMF_3, sizeof(CWIPWRKDAY.CMF_3));
			TRS.add_string(list_item, "CMF_4", CWIPWRKDAY.CMF_4, sizeof(CWIPWRKDAY.CMF_4));
			TRS.add_string(list_item, "CMF_5", CWIPWRKDAY.CMF_5, sizeof(CWIPWRKDAY.CMF_5));
			TRS.add_string(list_item, "CMF_6", CWIPWRKDAY.CMF_6, sizeof(CWIPWRKDAY.CMF_6));
			TRS.add_string(list_item, "CMF_7", CWIPWRKDAY.CMF_7, sizeof(CWIPWRKDAY.CMF_7));
			TRS.add_string(list_item, "CMF_8", CWIPWRKDAY.CMF_8, sizeof(CWIPWRKDAY.CMF_8));
			TRS.add_string(list_item, "CMF_9", CWIPWRKDAY.CMF_9, sizeof(CWIPWRKDAY.CMF_9));
			TRS.add_string(list_item, "CMF_10", CWIPWRKDAY.CMF_10, sizeof(CWIPWRKDAY.CMF_10));
		}

    }
    

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CRAS_View_Daily_Work_List_Validation()
		- Main sub function of "CRAS_View_Daily_Work_List" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Daily_Work_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1234") == MP_FALSE)
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