/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CRAS_view_patrol_check_sheet.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CRAS_View_Patrol_Check_Sheet()
			+ View Lot
		- CRAS_VIEW_PATROL_CHECK_SHEET()
			+ Main sub function of CRAS_View_Patrol_Check_Sheet function
			+ View Operation List definition
		- CRAS_View_Patrol_Check_Sheet_Validation()
			+ Main sub function of CRAS_View_Patrol_Check_Sheet function
			+ Check the condition for view Operation List
	Detail Description
		- CRAS_View_Patrol_Check_Sheet()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/08  YS KIM           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_View_Patrol_Check_Sheet_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CRAS_View_Patrol_Check_Sheet()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Patrol_Check_Sheet(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CRAS_VIEW_PATROL_CHECK_SHEET(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CRAS_View_Patrol_Check_Sheet", out_node);

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
	CRAS_View_Patrol_Check_Sheet()
		- Main sub function of "CRAS_View_Patrol_Check_Sheet" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_PATROL_CHECK_SHEET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPPTRCHK_TAG CWIPPTRCHK;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MSECUSRDEF_TAG MSECUSRDEF;

    TRSNode *list_item;

    int i_step;

    LOG_head("CRAS_View_Patrol_Check_Sheet");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CRAS_View_Patrol_Check_Sheet_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	i_step = 100;

    CDB_init_cwipptrchk(&CWIPPTRCHK);
	TRS.copy(CWIPPTRCHK.FACTORY, sizeof(CWIPPTRCHK.FACTORY), in_node, "FACTORY");
	TRS.copy(CWIPPTRCHK.WORK_DATE, sizeof(CWIPPTRCHK.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(CWIPPTRCHK.LINE_ID, sizeof(CWIPPTRCHK.LINE_ID), in_node, "LINE_ID");
	TRS.copy(CWIPPTRCHK.CMF_1, sizeof(CWIPPTRCHK.CMF_1), in_node, "OPER");
	CDB_open_cwipptrchk(i_step, &CWIPPTRCHK); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		//strcpy(s_msg_code, "DD-0004"); 
		// 20210810 MES Application Memory leak 점검 및 수정
		strcpy(s_msg_code, "WIP-0004"); 
		TRS.add_fieldmsg(out_node, "CWIPPTRCHK OPEN", MP_NVST); 
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTRCHK.FACTORY), CWIPPTRCHK.FACTORY); 
		TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPTRCHK.WORK_DATE), CWIPPTRCHK.WORK_DATE); 
		TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTRCHK.LINE_ID), CWIPPTRCHK.LINE_ID); 
		//TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPTRCHK.RES_ID), CWIPPTRCHK.RES_ID); 
		//TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPPTRCHK.SEQ_NUM); 
		// 20210810 MES Application Memory leak 점검 및 수정
		TRS.add_fieldmsg(out_node, "CMF_1", MP_STR, sizeof(CWIPPTRCHK.CMF_1), CWIPPTRCHK.CMF_1);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		CDB_fetch_cwipptrchk(i_step, &CWIPPTRCHK); 
		/*
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_close_cwipptrchk(i_step); 
			break;
		}
		*/
		// 20210810 MES Application Memory leak 점검 및 수정
		// DB Error and log
		if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_cwipptrchk(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004"); 
			TRS.add_fieldmsg(out_node, "CWIPPTRCHK FETCH", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTRCHK.FACTORY), CWIPPTRCHK.FACTORY); 
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPTRCHK.WORK_DATE), CWIPPTRCHK.WORK_DATE); 
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTRCHK.LINE_ID), CWIPPTRCHK.LINE_ID); 
			TRS.add_fieldmsg(out_node, "CMF_1", MP_STR, sizeof(CWIPPTRCHK.CMF_1), CWIPPTRCHK.CMF_1);
			TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_cwipptrchk(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		list_item = TRS.add_node(out_node, "LIST");
		TRS.add_string(list_item, "FACTORY", CWIPPTRCHK.FACTORY, sizeof(CWIPPTRCHK.FACTORY));
		TRS.add_string(list_item, "WORK_DATE", CWIPPTRCHK.WORK_DATE, sizeof(CWIPPTRCHK.WORK_DATE));
		TRS.add_string(list_item, "LINE_ID", CWIPPTRCHK.LINE_ID, sizeof(CWIPPTRCHK.LINE_ID));
		
		TRS.add_string(list_item, "RES_ID", CWIPPTRCHK.RES_ID, sizeof(CWIPPTRCHK.RES_ID));
		
		DBC_init_mrasresdef(&MRASRESDEF);
		TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
		memcpy(MRASRESDEF.RES_ID, CWIPPTRCHK.RES_ID, sizeof(CWIPPTRCHK.RES_ID));
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
			CDB_close_cwipptrchk(i_step);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));

		TRS.add_int(list_item, "SEQ_NUM", CWIPPTRCHK.SEQ_NUM);
		TRS.add_string(list_item, "OPERATION_POINT", CWIPPTRCHK.OPERATION_POINT, sizeof(CWIPPTRCHK.OPERATION_POINT));
		TRS.add_string(list_item, "PTR_CHECK_POINT", CWIPPTRCHK.PTR_CHECK_POINT, sizeof(CWIPPTRCHK.PTR_CHECK_POINT));

		
		CDB_init_mgcmlagdat(&MGCMLAGDAT);
		TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
		memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_PATROL_CHECK, strlen(HQCEL_M1_GCM_PATROL_CHECK));
		memcpy(MGCMLAGDAT.KEY_1, CWIPPTRCHK.PTR_CHECK_POINT, sizeof(CWIPPTRCHK.PTR_CHECK_POINT));
		CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			//TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
			// 20210810 MES Application Memory leak 점검 및 수정
			// log edit
			TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT (@PATROL_CHECK)", MP_NVST);
			//TRS.add_fieldmsg(out_node, "PTR_CHECK_POINT", MP_STR, strlen(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);  // Server Crash
			TRS.add_fieldmsg(out_node, "PTR_CHECK_POINT", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);  // Server Crash
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Close 추가
			CDB_close_cwipptrchk(i_step);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;     
		}
		TRS.add_string(list_item, "PTR_CHECK_POINT_NAME", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
		TRS.add_string(list_item, "PTR_CHECK_POINT_DESC", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));

		TRS.add_string(list_item, "FRONT_END_USER_ID", CWIPPTRCHK.FRONT_END_USER_ID, sizeof(CWIPPTRCHK.FRONT_END_USER_ID));

		DBC_init_msecusrdef(&MSECUSRDEF);
		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
		memcpy(MSECUSRDEF.USER_ID,CWIPPTRCHK.FRONT_END_USER_ID, sizeof(MSECUSRDEF.USER_ID));
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
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (FRONT_END_USER_ID)", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipptrchk(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

		}
		TRS.add_string(list_item, "FRONT_END_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

		TRS.add_string(list_item, "BACK_END_USER_ID", CWIPPTRCHK.BACK_END_USER_ID, sizeof(CWIPPTRCHK.BACK_END_USER_ID));

		DBC_init_msecusrdef(&MSECUSRDEF);
		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, "FACTORY");
		memcpy(MSECUSRDEF.USER_ID,CWIPPTRCHK.BACK_END_USER_ID, sizeof(MSECUSRDEF.USER_ID));
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
				TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT (BACK_END_USER_ID)", MP_NVST); 

				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY); 
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				
				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipptrchk(i_step);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}

		}
		TRS.add_string(list_item, "BACK_END_USER_DESC", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));

		TRS.add_string(list_item, "CREATE_USER_ID", CWIPPTRCHK.CREATE_USER_ID, sizeof(CWIPPTRCHK.CREATE_USER_ID));
		TRS.add_string(list_item, "CREATE_TIME", CWIPPTRCHK.CREATE_TIME, sizeof(CWIPPTRCHK.CREATE_TIME));
		TRS.add_string(list_item, "UPDATE_USER_ID", CWIPPTRCHK.UPDATE_USER_ID, sizeof(CWIPPTRCHK.UPDATE_USER_ID));
		TRS.add_string(list_item, "UPDATE_TIME", CWIPPTRCHK.UPDATE_TIME, sizeof(CWIPPTRCHK.UPDATE_TIME));
		TRS.add_string(list_item, "CMF_1", CWIPPTRCHK.CMF_1, sizeof(CWIPPTRCHK.CMF_1));
		TRS.add_string(list_item, "CMF_2", CWIPPTRCHK.CMF_2, sizeof(CWIPPTRCHK.CMF_2));
		TRS.add_string(list_item, "CMF_3", CWIPPTRCHK.CMF_3, sizeof(CWIPPTRCHK.CMF_3));
		TRS.add_string(list_item, "CMF_4", CWIPPTRCHK.CMF_4, sizeof(CWIPPTRCHK.CMF_4));
		TRS.add_string(list_item, "CMF_5", CWIPPTRCHK.CMF_5, sizeof(CWIPPTRCHK.CMF_5));
		TRS.add_string(list_item, "CMF_6", CWIPPTRCHK.CMF_6, sizeof(CWIPPTRCHK.CMF_6));
		TRS.add_string(list_item, "CMF_7", CWIPPTRCHK.CMF_7, sizeof(CWIPPTRCHK.CMF_7));
		TRS.add_string(list_item, "CMF_8", CWIPPTRCHK.CMF_8, sizeof(CWIPPTRCHK.CMF_8));
		TRS.add_string(list_item, "CMF_9", CWIPPTRCHK.CMF_9, sizeof(CWIPPTRCHK.CMF_9));
		TRS.add_string(list_item, "CMF_10", CWIPPTRCHK.CMF_10, sizeof(CWIPPTRCHK.CMF_10));
	}

    

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CRAS_View_Patrol_Check_Sheet_Validation()
		- Main sub function of "CRAS_View_Patrol_Check_Sheet" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Patrol_Check_Sheet_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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