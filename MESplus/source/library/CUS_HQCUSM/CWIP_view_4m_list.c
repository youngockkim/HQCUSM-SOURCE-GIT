/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_4m_list.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_4m_List()
			+ View Lot
		- CWIP_VIEW_4M_LIST()
			+ Main sub function of CWIP_View_4m_List function
			+ View Operation List definition
		- CWIP_View_4m_List_Validation()
			+ Main sub function of CWIP_View_4m_List function
			+ Check the condition for view Operation List
	Detail Description
		- CWIP_View_4m_List()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/08  YS KIM           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_4m_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_4m_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_4m_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_4M_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_View_4m_List", out_node);

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
	CWIP_View_4m_List()
		- Main sub function of "CWIP_View_4m_List" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_4M_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPFMIHIS_TAG CWIPFMIHIS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
	struct MSECUSRDEF_TAG MSECUSRDEF;


    TRSNode *list_item;

    int i_step;
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
	//char s_line[5];

    LOG_head("CWIP_View_4m_List");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
    
    if(CWIP_View_4m_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	if(TRS.get_procstep(in_node) == '1')
	{
		i_step = 100;

		CDB_init_cwipfmihis(&CWIPFMIHIS);
		TRS.copy(CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPFMIHIS.FM_TYPE, sizeof(CWIPFMIHIS.FM_TYPE), in_node, "FM_TYPE");
		TRS.copy(CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE), in_node, "FROM_DATE");
		TRS.copy(CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME), in_node, "TO_DATE");
		CDB_open_cwipfmihis(i_step, &CWIPFMIHIS); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPFMIHIS OPEN", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
			TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPFMIHIS.WORK_DATE), CWIPFMIHIS.WORK_DATE); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
		while(1)
		{
			CDB_fetch_cwipfmihis(i_step, &CWIPFMIHIS); 
			/*
			if(DB_error_code != DB_SUCCESS)
			{				
				CDB_close_cwipfmihis(i_step); 
				break;
			}
			*/
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Error and log
			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwipfmihis(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPFMIHIS FETCH", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
				TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPFMIHIS.WORK_DATE), CWIPFMIHIS.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_cwipfmihis(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "FACTORY", CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY));
			TRS.add_string(list_item, "WORK_DATE", CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE));
			TRS.add_string(list_item, "LINE_ID", CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));

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
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "LINE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_int(list_item, "SEQ_NUM", CWIPFMIHIS.SEQ_NUM);
			TRS.add_string(list_item, "OPER", CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));

			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPOPRDEF.OPER, CWIPFMIHIS.OPER, sizeof(MWIPOPRDEF.OPER));
            
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "ORD-0004");
					//TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					// 20210810 MES Application Memory leak 점검 및 수정
					// DB error log edit
					TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);

					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));

			TRS.add_string(list_item, "RES_ID", CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID));

			DBC_init_mrasresdef(&MRASRESDEF);
			TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
			memcpy(MRASRESDEF.RES_ID, CWIPFMIHIS.RES_ID, sizeof(MRASRESDEF.RES_ID));
			DBC_select_mrasresdef(1, &MRASRESDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "RAS-0003");
					TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));

			TRS.add_string(list_item, "APPLY_TIME", CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME));

			TRS.add_string(list_item, "KIND", CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND));
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_4M_KIND, strlen(HQCEL_M1_GCM_4M_KIND));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND));

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
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "KIND_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}



			TRS.add_string(list_item, "BEFORE", CWIPFMIHIS.BEFORE, sizeof(CWIPFMIHIS.BEFORE));
			TRS.add_string(list_item, "AFTER", CWIPFMIHIS.AFTER, sizeof(CWIPFMIHIS.AFTER));
			TRS.add_string(list_item, "DEPARTMENT", CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT));
			TRS.add_string(list_item, "CHARGE_USER_ID", CWIPFMIHIS.CHARGE_USER_ID, sizeof(CWIPFMIHIS.CHARGE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPFMIHIS.CHARGE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}

			}
			TRS.add_string(list_item, "CHARGE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

			TRS.add_string(list_item, "UNUSUAL_DESC", CWIPFMIHIS.UNUSUAL_DESC, sizeof(CWIPFMIHIS.UNUSUAL_DESC));
			TRS.add_string(list_item, "CREATE_USER_ID", CWIPFMIHIS.CREATE_USER_ID, sizeof(CWIPFMIHIS.CREATE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPFMIHIS.CREATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}

			}
			TRS.add_string(list_item, "CREATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

			TRS.add_string(list_item, "CREATE_TIME", CWIPFMIHIS.CREATE_TIME, sizeof(CWIPFMIHIS.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CWIPFMIHIS.UPDATE_USER_ID, sizeof(CWIPFMIHIS.UPDATE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPFMIHIS.UPDATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}

			}
			TRS.add_string(list_item, "UPDATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

			TRS.add_string(list_item, "UPDATE_TIME", CWIPFMIHIS.UPDATE_TIME, sizeof(CWIPFMIHIS.UPDATE_TIME));
			TRS.add_string(list_item, "CMF_1", CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
			TRS.add_string(list_item, "CMF_2", CWIPFMIHIS.CMF_2, sizeof(CWIPFMIHIS.CMF_2));
			TRS.add_string(list_item, "CMF_3", CWIPFMIHIS.CMF_3, sizeof(CWIPFMIHIS.CMF_3));
			TRS.add_string(list_item, "CMF_4", CWIPFMIHIS.CMF_4, sizeof(CWIPFMIHIS.CMF_4));
			TRS.add_string(list_item, "CMF_5", CWIPFMIHIS.CMF_5, sizeof(CWIPFMIHIS.CMF_5));
			TRS.add_string(list_item, "CMF_6", CWIPFMIHIS.CMF_6, sizeof(CWIPFMIHIS.CMF_6));
			TRS.add_string(list_item, "CMF_7", CWIPFMIHIS.CMF_7, sizeof(CWIPFMIHIS.CMF_7));
			TRS.add_string(list_item, "CMF_8", CWIPFMIHIS.CMF_8, sizeof(CWIPFMIHIS.CMF_8));
			TRS.add_string(list_item, "CMF_9", CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9));
			TRS.add_string(list_item, "CMF_10", CWIPFMIHIS.CMF_10, sizeof(CWIPFMIHIS.CMF_10));
		}
	}
	else if(TRS.get_procstep(in_node) == '2')
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
			TRS.add_fieldmsg(out_node, "CWIPFMIHIS SELECT", MP_NVST); 
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
		TRS.add_string(out_node, "FACTORY", CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY));
		TRS.add_string(out_node, "WORK_DATE", CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE));
		TRS.add_string(out_node, "LINE_ID", CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));
		TRS.add_int(out_node, "SEQ_NUM", CWIPFMIHIS.SEQ_NUM);
		TRS.add_string(out_node, "OPER", CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));
		TRS.add_string(out_node, "RES_ID", CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID));
		TRS.add_string(out_node, "APPLY_TIME", CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME));
		TRS.add_string(out_node, "KIND", CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND));
		TRS.add_string(out_node, "BEFORE", CWIPFMIHIS.BEFORE, sizeof(CWIPFMIHIS.BEFORE));
		TRS.add_string(out_node, "AFTER", CWIPFMIHIS.AFTER, sizeof(CWIPFMIHIS.AFTER));
		TRS.add_string(out_node, "DEPARTMENT", CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT));
		TRS.add_string(out_node, "CHARGE_USER_ID", CWIPFMIHIS.CHARGE_USER_ID, sizeof(CWIPFMIHIS.CHARGE_USER_ID));
		TRS.add_string(out_node, "UNUSUAL_DESC", CWIPFMIHIS.UNUSUAL_DESC, sizeof(CWIPFMIHIS.UNUSUAL_DESC));
		TRS.add_string(out_node, "CREATE_USER_ID", CWIPFMIHIS.CREATE_USER_ID, sizeof(CWIPFMIHIS.CREATE_USER_ID));
		TRS.add_string(out_node, "CREATE_TIME", CWIPFMIHIS.CREATE_TIME, sizeof(CWIPFMIHIS.CREATE_TIME));
		TRS.add_string(out_node, "UPDATE_USER_ID", CWIPFMIHIS.UPDATE_USER_ID, sizeof(CWIPFMIHIS.UPDATE_USER_ID));
		TRS.add_string(out_node, "UPDATE_TIME", CWIPFMIHIS.UPDATE_TIME, sizeof(CWIPFMIHIS.UPDATE_TIME));
		TRS.add_string(out_node, "CMF_1", CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
		TRS.add_string(out_node, "CMF_2", CWIPFMIHIS.CMF_2, sizeof(CWIPFMIHIS.CMF_2));
		TRS.add_string(out_node, "CMF_3", CWIPFMIHIS.CMF_3, sizeof(CWIPFMIHIS.CMF_3));
		TRS.add_string(out_node, "CMF_4", CWIPFMIHIS.CMF_4, sizeof(CWIPFMIHIS.CMF_4));
		TRS.add_string(out_node, "CMF_5", CWIPFMIHIS.CMF_5, sizeof(CWIPFMIHIS.CMF_5));
		TRS.add_string(out_node, "CMF_6", CWIPFMIHIS.CMF_6, sizeof(CWIPFMIHIS.CMF_6));
		TRS.add_string(out_node, "CMF_7", CWIPFMIHIS.CMF_7, sizeof(CWIPFMIHIS.CMF_7));
		TRS.add_string(out_node, "CMF_8", CWIPFMIHIS.CMF_8, sizeof(CWIPFMIHIS.CMF_8));
		TRS.add_string(out_node, "CMF_9", CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9));
		TRS.add_string(out_node, "CMF_10", CWIPFMIHIS.CMF_10, sizeof(CWIPFMIHIS.CMF_10));

	}
	// For Process Team
	else if(TRS.get_procstep(in_node) == '3')
	{
		i_step = 102;

		CDB_init_cwipfmihis(&CWIPFMIHIS);
		TRS.copy(CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPFMIHIS.FM_TYPE, sizeof(CWIPFMIHIS.FM_TYPE), in_node, "FM_TYPE");
		TRS.copy(CWIPFMIHIS.CMF_10, 14, in_node, "FROM_DATE");
		TRS.copy(CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID), in_node, "RES_ID");
		TRS.copy(CWIPFMIHIS.APPLY_TIME, 14, in_node, "TO_DATE");
		TRS.copy(CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER), in_node, "OPER1");
		TRS.copy(CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1), in_node, "OPER2");
		TRS.copy(CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT), in_node, "DEPARTMENT");
		TRS.copy(CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND), in_node, "KIND");
		TRS.copy(CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9), in_node, "FACTORY_NO");
		
		if(COM_isnullspace(CWIPFMIHIS.CMF_9) == MP_FALSE)
		{
			memcpy(CWIPFMIHIS.CMF_8, CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9));
		} else {
			memcpy(CWIPFMIHIS.CMF_8, "E1", strlen("E1"));
			memcpy(CWIPFMIHIS.CMF_9, "E2", strlen("E2"));
		}

		CDB_open_cwipfmihis(i_step, &CWIPFMIHIS); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPFMIHIS OPEN", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
			TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPFMIHIS.RES_ID), CWIPFMIHIS.RES_ID); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
			TRS.add_fieldmsg(out_node, "OPER2", MP_STR, sizeof(CWIPFMIHIS.CMF_1), CWIPFMIHIS.CMF_1); 
			TRS.add_fieldmsg(out_node, "NAME", MP_STR, sizeof(CWIPFMIHIS.CMF_2), CWIPFMIHIS.CMF_2); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
		while(1)
		{
			CDB_fetch_cwipfmihis(i_step, &CWIPFMIHIS); 
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Error and log
			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwipfmihis(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPFMIHIS FETCH", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPFMIHIS.FACTORY), CWIPFMIHIS.FACTORY); 
				TRS.add_fieldmsg(out_node, "FM_TYPE", MP_STR, sizeof(CWIPFMIHIS.FM_TYPE), CWIPFMIHIS.FM_TYPE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPFMIHIS.LINE_ID), CWIPFMIHIS.LINE_ID); 
				TRS.add_fieldmsg(out_node, "MACHINE", MP_STR, sizeof(CWIPFMIHIS.CMF_1), CWIPFMIHIS.CMF_1); 
				TRS.add_fieldmsg(out_node, "MACHINE_DETAIL", MP_STR, sizeof(CWIPFMIHIS.CMF_2), CWIPFMIHIS.CMF_2); 
				TRS.add_fieldmsg(out_node, "ISSUE", MP_STR, sizeof(CWIPFMIHIS.CMF_3), CWIPFMIHIS.CMF_3); 
				TRS.add_fieldmsg(out_node, "PERSON", MP_STR, sizeof(CWIPFMIHIS.CMF_4), CWIPFMIHIS.CMF_4); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_cwipfmihis(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "FACTORY", CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY));
			TRS.add_string(list_item, "WORK_DATE", CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE));
			TRS.add_string(list_item, "LINE_ID", CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));

			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));

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
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "LINE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_int(list_item, "SEQ_NUM", CWIPFMIHIS.SEQ_NUM);			
			TRS.add_string(list_item, "APPLY_TIME", CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME));

			TRS.add_string(list_item, "OPER1", CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "@4M_OPERATION", strlen("@4M_OPERATION"));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));
			memcpy(MGCMTBLDAT.KEY_2, "000000", strlen("000000"));

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
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "OPER1_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_string(list_item, "OPER2", CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "@4M_OPERATION", strlen("@4M_OPERATION"));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
			memcpy(MGCMTBLDAT.KEY_2, CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));

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
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "OPER2_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_string(list_item, "RES_ID", CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID));
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "@4M_EQ", strlen("@4M_EQ"));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));
			memcpy(MGCMTBLDAT.KEY_2, CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));
			memcpy(MGCMTBLDAT.KEY_3, CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
			memcpy(MGCMTBLDAT.KEY_4, CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID));

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
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가 
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "EQ_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_string(list_item, "APPLY_TIME", CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME));

			TRS.add_string(list_item, "KIND", CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND));
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_4M_KIND, strlen(HQCEL_M1_GCM_4M_KIND));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND));

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
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "KIND_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}



			TRS.add_string(list_item, "BEFORE", CWIPFMIHIS.BEFORE, sizeof(CWIPFMIHIS.BEFORE));
			TRS.add_string(list_item, "AFTER", CWIPFMIHIS.AFTER, sizeof(CWIPFMIHIS.AFTER));
			TRS.add_string(list_item, "DEPARTMENT", CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT));
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "@DEPARTMENT", strlen("@DEPARTMENT"));
			memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT));

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
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				TRS.add_string(list_item, "DEPT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}

			TRS.add_string(list_item, "UNUSUAL_DESC", CWIPFMIHIS.UNUSUAL_DESC, sizeof(CWIPFMIHIS.UNUSUAL_DESC));
			TRS.add_string(list_item, "CREATE_USER_ID", CWIPFMIHIS.CREATE_USER_ID, sizeof(CWIPFMIHIS.CREATE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPFMIHIS.CREATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}

			}
			TRS.add_string(list_item, "CREATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

			TRS.add_string(list_item, "CREATE_TIME", CWIPFMIHIS.CREATE_TIME, sizeof(CWIPFMIHIS.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CWIPFMIHIS.UPDATE_USER_ID, sizeof(CWIPFMIHIS.UPDATE_USER_ID));

			DBC_init_msecusrdef(&MSECUSRDEF);
			TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MSECUSRDEF.USER_ID,CWIPFMIHIS.UPDATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "SEC-0004"); 
					TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
					TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					CDB_close_cwipfmihis(i_step);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}

			}
			TRS.add_string(list_item, "UPDATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

			TRS.add_string(list_item, "UPDATE_TIME", CWIPFMIHIS.UPDATE_TIME, sizeof(CWIPFMIHIS.UPDATE_TIME));
			TRS.add_string(list_item, "CMF_1", CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
			TRS.add_string(list_item, "CMF_2", CWIPFMIHIS.CMF_2, sizeof(CWIPFMIHIS.CMF_2));
			TRS.add_string(list_item, "CMF_3", CWIPFMIHIS.CMF_3, sizeof(CWIPFMIHIS.CMF_3));
			TRS.add_string(list_item, "CMF_4", CWIPFMIHIS.CMF_4, sizeof(CWIPFMIHIS.CMF_4));
			TRS.add_string(list_item, "CMF_5", CWIPFMIHIS.CMF_5, sizeof(CWIPFMIHIS.CMF_5));
			TRS.add_string(list_item, "CMF_6", CWIPFMIHIS.CMF_6, sizeof(CWIPFMIHIS.CMF_6));
			TRS.add_string(list_item, "CMF_7", CWIPFMIHIS.CMF_7, sizeof(CWIPFMIHIS.CMF_7));
			TRS.add_string(list_item, "CMF_8", CWIPFMIHIS.CMF_8, sizeof(CWIPFMIHIS.CMF_8));
			TRS.add_string(list_item, "CMF_9", CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9));
			TRS.add_string(list_item, "CMF_10", CWIPFMIHIS.CMF_10, sizeof(CWIPFMIHIS.CMF_10));
		}
	}
	// For Process Team
	else if(TRS.get_procstep(in_node) == '4')
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
			TRS.add_fieldmsg(out_node, "CWIPFMIHIS SELECT", MP_NVST); 
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
		TRS.add_string(out_node, "FACTORY", CWIPFMIHIS.FACTORY, sizeof(CWIPFMIHIS.FACTORY));
		TRS.add_string(out_node, "WORK_DATE", CWIPFMIHIS.WORK_DATE, sizeof(CWIPFMIHIS.WORK_DATE));
		TRS.add_string(out_node, "LINE_ID", CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));
		TRS.add_int(out_node, "SEQ_NUM", CWIPFMIHIS.SEQ_NUM);
		TRS.add_string(out_node, "APPLY_TIME", CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME));
		TRS.add_string(out_node, "BEFORE", CWIPFMIHIS.BEFORE, sizeof(CWIPFMIHIS.BEFORE));
		TRS.add_string(out_node, "AFTER", CWIPFMIHIS.AFTER, sizeof(CWIPFMIHIS.AFTER));
		TRS.add_string(out_node, "CHARGE_USER_ID", CWIPFMIHIS.CHARGE_USER_ID, sizeof(CWIPFMIHIS.CHARGE_USER_ID));
		TRS.add_string(out_node, "UNUSUAL_DESC", CWIPFMIHIS.UNUSUAL_DESC, sizeof(CWIPFMIHIS.UNUSUAL_DESC));
		TRS.add_string(out_node, "CREATE_USER_ID", CWIPFMIHIS.CREATE_USER_ID, sizeof(CWIPFMIHIS.CREATE_USER_ID));
		TRS.add_string(out_node, "CREATE_TIME", CWIPFMIHIS.CREATE_TIME, sizeof(CWIPFMIHIS.CREATE_TIME));
		TRS.add_string(out_node, "UPDATE_USER_ID", CWIPFMIHIS.UPDATE_USER_ID, sizeof(CWIPFMIHIS.UPDATE_USER_ID));
		TRS.add_string(out_node, "UPDATE_TIME", CWIPFMIHIS.UPDATE_TIME, sizeof(CWIPFMIHIS.UPDATE_TIME));
		TRS.add_string(out_node, "OPER1", CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@4M_OPERATION", strlen("@4M_OPERATION"));
		memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));
		memcpy(MGCMTBLDAT.KEY_2, "000000", strlen("000000"));

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
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			TRS.add_string(out_node, "OPER1_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		TRS.add_string(out_node, "OPER2", CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@4M_OPERATION", strlen("@4M_OPERATION"));
		memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
		memcpy(MGCMTBLDAT.KEY_2, CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));

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
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			TRS.add_string(out_node, "OPER2_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}


		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));

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
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			TRS.add_string(out_node, "LINE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		TRS.add_string(out_node, "RES_ID", CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID));
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@4M_EQ", strlen("@4M_EQ"));
		memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.LINE_ID, sizeof(CWIPFMIHIS.LINE_ID));
		memcpy(MGCMTBLDAT.KEY_2, CWIPFMIHIS.OPER, sizeof(CWIPFMIHIS.OPER));
		memcpy(MGCMTBLDAT.KEY_3, CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
		memcpy(MGCMTBLDAT.KEY_4, CWIPFMIHIS.RES_ID, sizeof(CWIPFMIHIS.RES_ID));

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
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			TRS.add_string(out_node, "EQ_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		TRS.add_string(out_node, "APPLY_TIME", CWIPFMIHIS.APPLY_TIME, sizeof(CWIPFMIHIS.APPLY_TIME));

		TRS.add_string(out_node, "KIND", CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND));
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_4M_KIND, strlen(HQCEL_M1_GCM_4M_KIND));
		memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.KIND, sizeof(CWIPFMIHIS.KIND));

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
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			TRS.add_string(out_node, "KIND_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}



		TRS.add_string(out_node, "BEFORE", CWIPFMIHIS.BEFORE, sizeof(CWIPFMIHIS.BEFORE));
		TRS.add_string(out_node, "AFTER", CWIPFMIHIS.AFTER, sizeof(CWIPFMIHIS.AFTER));
		TRS.add_string(out_node, "DEPARTMENT", CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT));
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@DEPARTMENT", strlen("@DEPARTMENT"));
		memcpy(MGCMTBLDAT.KEY_1, CWIPFMIHIS.DEPARTMENT, sizeof(CWIPFMIHIS.DEPARTMENT));

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
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			TRS.add_string(out_node, "DEPT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		TRS.add_string(out_node, "UNUSUAL_DESC", CWIPFMIHIS.UNUSUAL_DESC, sizeof(CWIPFMIHIS.UNUSUAL_DESC));
		TRS.add_string(out_node, "CREATE_USER_ID", CWIPFMIHIS.CREATE_USER_ID, sizeof(CWIPFMIHIS.CREATE_USER_ID));

		DBC_init_msecusrdef(&MSECUSRDEF);
		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
		memcpy(MSECUSRDEF.USER_ID,CWIPFMIHIS.CREATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
		DBC_select_msecusrdef(1, &MSECUSRDEF); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			if(DB_error_code == DB_NOT_FOUND)
			{
			}
			else
			{
				strcpy(s_msg_code, "SEC-0004"); 
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

		}
		TRS.add_string(out_node, "CREATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

		TRS.add_string(out_node, "CREATE_TIME", CWIPFMIHIS.CREATE_TIME, sizeof(CWIPFMIHIS.CREATE_TIME));
		TRS.add_string(out_node, "UPDATE_USER_ID", CWIPFMIHIS.UPDATE_USER_ID, sizeof(CWIPFMIHIS.UPDATE_USER_ID));

		DBC_init_msecusrdef(&MSECUSRDEF);
		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
		memcpy(MSECUSRDEF.USER_ID,CWIPFMIHIS.UPDATE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
		DBC_select_msecusrdef(1, &MSECUSRDEF); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			if(DB_error_code == DB_NOT_FOUND)
			{
			}
			else
			{
				strcpy(s_msg_code, "SEC-0004"); 
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipfmihis(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

		}
		TRS.add_string(out_node, "UPDATE_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

		TRS.add_string(out_node, "UPDATE_TIME", CWIPFMIHIS.UPDATE_TIME, sizeof(CWIPFMIHIS.UPDATE_TIME));
		TRS.add_string(out_node, "CMF_1", CWIPFMIHIS.CMF_1, sizeof(CWIPFMIHIS.CMF_1));
		TRS.add_string(out_node, "CMF_2", CWIPFMIHIS.CMF_2, sizeof(CWIPFMIHIS.CMF_2));
		TRS.add_string(out_node, "CMF_3", CWIPFMIHIS.CMF_3, sizeof(CWIPFMIHIS.CMF_3));
		TRS.add_string(out_node, "CMF_4", CWIPFMIHIS.CMF_4, sizeof(CWIPFMIHIS.CMF_4));
		TRS.add_string(out_node, "CMF_5", CWIPFMIHIS.CMF_5, sizeof(CWIPFMIHIS.CMF_5));
		TRS.add_string(out_node, "CMF_6", CWIPFMIHIS.CMF_6, sizeof(CWIPFMIHIS.CMF_6));
		TRS.add_string(out_node, "CMF_7", CWIPFMIHIS.CMF_7, sizeof(CWIPFMIHIS.CMF_7));
		TRS.add_string(out_node, "CMF_8", CWIPFMIHIS.CMF_8, sizeof(CWIPFMIHIS.CMF_8));
		TRS.add_string(out_node, "CMF_9", CWIPFMIHIS.CMF_9, sizeof(CWIPFMIHIS.CMF_9));
		TRS.add_string(out_node, "CMF_10", CWIPFMIHIS.CMF_10, sizeof(CWIPFMIHIS.CMF_10));
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_4m_List_Validation()
		- Main sub function of "CWIP_View_4m_List" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_4m_List_Validation(char *s_msg_code,
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