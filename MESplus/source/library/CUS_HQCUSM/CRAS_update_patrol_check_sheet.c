/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CRAS_update_patrol_check_sheet.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CRAS_Update_Patrol_Check_Sheet()
			+ View Lot
		- CRAS_UPDATE_PATROL_CHECK_SHEET()
			+ Main sub function of CRAS_Update_Patrol_Check_Sheet function
			+ View Operation List definition
		- CRAS_Update_Patrol_Check_Sheet_Validation()
			+ Main sub function of CRAS_Update_Patrol_Check_Sheet function
			+ Check the condition for view Operation List
	Detail Description
		- CRAS_Update_Patrol_Check_Sheet()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/08  YS KIM           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_Patrol_Check_Sheet_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CRAS_Update_Patrol_Check_Sheet()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Patrol_Check_Sheet(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CRAS_UPDATE_PATROL_CHECK_SHEET(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CRAS_Update_Patrol_Check_Sheet", out_node);

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
	CRAS_Update_Patrol_Check_Sheet()
		- Main sub function of "CRAS_Update_Patrol_Check_Sheet" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_PATROL_CHECK_SHEET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
 	struct CWIPPTRCHK_TAG CWIPPTRCHK;
 	struct CWIPPTRCHK_TAG CWIPPTRCHK_SEQ;

    char   s_sys_time[14];

    LOG_head("CRAS_Update_Patrol_Check_Sheet");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CRAS_Update_Patrol_Check_Sheet_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
		CDB_init_cwipptrchk(&CWIPPTRCHK);
		TRS.copy(CWIPPTRCHK.FACTORY, sizeof(CWIPPTRCHK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPPTRCHK.WORK_DATE, sizeof(CWIPPTRCHK.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPPTRCHK.LINE_ID, sizeof(CWIPPTRCHK.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPPTRCHK.RES_ID, sizeof(CWIPPTRCHK.RES_ID), in_node, "RES_ID");

		if(TRS.get_int(in_node, "SEQ_NUM") == 0)
		{
			//create seq
			CDB_init_cwipptrchk(&CWIPPTRCHK_SEQ);
			TRS.copy(CWIPPTRCHK_SEQ.FACTORY, sizeof(CWIPPTRCHK_SEQ.FACTORY), in_node, "FACTORY");
			TRS.copy(CWIPPTRCHK_SEQ.WORK_DATE, sizeof(CWIPPTRCHK_SEQ.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CWIPPTRCHK_SEQ.LINE_ID, sizeof(CWIPPTRCHK_SEQ.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CWIPPTRCHK_SEQ.RES_ID, sizeof(CWIPPTRCHK_SEQ.RES_ID), in_node, "RES_ID");
			CDB_select_cwipptrchk(100, &CWIPPTRCHK_SEQ);
			if(DB_error_code != DB_SUCCESS)
			{
				CWIPPTRCHK.SEQ_NUM = 1;
			
			}
			else
			{
				CWIPPTRCHK.SEQ_NUM = CWIPPTRCHK_SEQ.SEQ_NUM + 1;
			}

		}
		else
		{
			CWIPPTRCHK.SEQ_NUM  = TRS.get_int(in_node, "SEQ_NUM"); 
		}
		CDB_select_cwipptrchk(1, &CWIPPTRCHK); 
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				TRS.copy(CWIPPTRCHK.OPERATION_POINT, sizeof(CWIPPTRCHK.OPERATION_POINT), in_node, "OPERATION_POINT");
				TRS.copy(CWIPPTRCHK.PTR_CHECK_POINT, sizeof(CWIPPTRCHK.PTR_CHECK_POINT), in_node, "PTR_CHECK_POINT");
				TRS.copy(CWIPPTRCHK.FRONT_END_USER_ID, sizeof(CWIPPTRCHK.FRONT_END_USER_ID), in_node, "FRONT_END_USER_ID");
				TRS.copy(CWIPPTRCHK.BACK_END_USER_ID, sizeof(CWIPPTRCHK.BACK_END_USER_ID), in_node, "BACK_END_USER_ID");
				TRS.copy(CWIPPTRCHK.CMF_1, sizeof(CWIPPTRCHK.CMF_1), in_node, "OPER");
				TRS.copy(CWIPPTRCHK.CMF_2, sizeof(CWIPPTRCHK.CMF_2), in_node, "CMF_2");
				TRS.copy(CWIPPTRCHK.CMF_3, sizeof(CWIPPTRCHK.CMF_3), in_node, "CMF_3");
				TRS.copy(CWIPPTRCHK.CMF_4, sizeof(CWIPPTRCHK.CMF_4), in_node, "CMF_4");
				TRS.copy(CWIPPTRCHK.CMF_5, sizeof(CWIPPTRCHK.CMF_5), in_node, "CMF_5");
				TRS.copy(CWIPPTRCHK.CMF_6, sizeof(CWIPPTRCHK.CMF_6), in_node, "CMF_6");
				TRS.copy(CWIPPTRCHK.CMF_7, sizeof(CWIPPTRCHK.CMF_7), in_node, "CMF_7");
				TRS.copy(CWIPPTRCHK.CMF_8, sizeof(CWIPPTRCHK.CMF_8), in_node, "CMF_8");
				TRS.copy(CWIPPTRCHK.CMF_9, sizeof(CWIPPTRCHK.CMF_9), in_node, "CMF_9");
				TRS.copy(CWIPPTRCHK.CMF_10, sizeof(CWIPPTRCHK.CMF_10), in_node, "CMF_10");


				TRS.copy(CWIPPTRCHK.CREATE_USER_ID, sizeof(CWIPPTRCHK.CREATE_USER_ID), in_node, IN_USERID);
				DB_get_systime(CWIPPTRCHK.CREATE_TIME); 
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


				CDB_insert_cwipptrchk(&CWIPPTRCHK); 
				if(DB_error_code != DB_SUCCESS)
				{ 
					strcpy(s_msg_code, "RAS-0004"); 
					TRS.add_fieldmsg(out_node, "CWIPPTRCHK INSERT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTRCHK.FACTORY), CWIPPTRCHK.FACTORY); 
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPTRCHK.WORK_DATE), CWIPPTRCHK.WORK_DATE); 
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTRCHK.LINE_ID), CWIPPTRCHK.LINE_ID); 
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPTRCHK.RES_ID), CWIPPTRCHK.RES_ID); 
					TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPPTRCHK.SEQ_NUM); 
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
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTRCHK.FACTORY), CWIPPTRCHK.FACTORY); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTRCHK.LINE_ID), CWIPPTRCHK.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPTRCHK.RES_ID), CWIPPTRCHK.RES_ID); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPPTRCHK.SEQ_NUM); 
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
			TRS.copy(CWIPPTRCHK.OPERATION_POINT, sizeof(CWIPPTRCHK.OPERATION_POINT), in_node, "OPERATION_POINT");
			TRS.copy(CWIPPTRCHK.PTR_CHECK_POINT, sizeof(CWIPPTRCHK.PTR_CHECK_POINT), in_node, "PTR_CHECK_POINT");
			TRS.copy(CWIPPTRCHK.FRONT_END_USER_ID, sizeof(CWIPPTRCHK.FRONT_END_USER_ID), in_node, "FRONT_END_USER_ID");
			TRS.copy(CWIPPTRCHK.BACK_END_USER_ID, sizeof(CWIPPTRCHK.BACK_END_USER_ID), in_node, "BACK_END_USER_ID");
			TRS.copy(CWIPPTRCHK.CMF_1, sizeof(CWIPPTRCHK.CMF_1), in_node, "OPER");
			TRS.copy(CWIPPTRCHK.CMF_2, sizeof(CWIPPTRCHK.CMF_2), in_node, "CMF_2");
			TRS.copy(CWIPPTRCHK.CMF_3, sizeof(CWIPPTRCHK.CMF_3), in_node, "CMF_3");
			TRS.copy(CWIPPTRCHK.CMF_4, sizeof(CWIPPTRCHK.CMF_4), in_node, "CMF_4");
			TRS.copy(CWIPPTRCHK.CMF_5, sizeof(CWIPPTRCHK.CMF_5), in_node, "CMF_5");
			TRS.copy(CWIPPTRCHK.CMF_6, sizeof(CWIPPTRCHK.CMF_6), in_node, "CMF_6");
			TRS.copy(CWIPPTRCHK.CMF_7, sizeof(CWIPPTRCHK.CMF_7), in_node, "CMF_7");
			TRS.copy(CWIPPTRCHK.CMF_8, sizeof(CWIPPTRCHK.CMF_8), in_node, "CMF_8");
			TRS.copy(CWIPPTRCHK.CMF_9, sizeof(CWIPPTRCHK.CMF_9), in_node, "CMF_9");
			TRS.copy(CWIPPTRCHK.CMF_10, sizeof(CWIPPTRCHK.CMF_10), in_node, "CMF_10");

			TRS.copy(CWIPPTRCHK.UPDATE_USER_ID, sizeof(CWIPPTRCHK.UPDATE_USER_ID), in_node, IN_USERID);
			DB_get_systime(CWIPPTRCHK.UPDATE_TIME); 
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
			CDB_update_cwipptrchk(1, &CWIPPTRCHK);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "RAS-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPPTRCHK UPDATE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTRCHK.FACTORY), CWIPPTRCHK.FACTORY); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPTRCHK.WORK_DATE), CWIPPTRCHK.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTRCHK.LINE_ID), CWIPPTRCHK.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPTRCHK.RES_ID), CWIPPTRCHK.RES_ID); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPPTRCHK.SEQ_NUM); 
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
		CDB_init_cwipptrchk(&CWIPPTRCHK);
		TRS.copy(CWIPPTRCHK.FACTORY, sizeof(CWIPPTRCHK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPPTRCHK.WORK_DATE, sizeof(CWIPPTRCHK.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPPTRCHK.LINE_ID, sizeof(CWIPPTRCHK.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPPTRCHK.RES_ID, sizeof(CWIPPTRCHK.RES_ID), in_node, "RES_ID");
		CWIPPTRCHK.SEQ_NUM = TRS.get_int(in_node, "SEQ_NUM");
		
		CDB_select_cwipptrchk(1, &CWIPPTRCHK); 
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
			CDB_delete_cwipptrchk(1, &CWIPPTRCHK);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "RAS-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPPTRCHK DELETE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTRCHK.FACTORY), CWIPPTRCHK.FACTORY); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPTRCHK.WORK_DATE), CWIPPTRCHK.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTRCHK.LINE_ID), CWIPPTRCHK.LINE_ID); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPTRCHK.RES_ID), CWIPPTRCHK.RES_ID); 
				TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CWIPPTRCHK.SEQ_NUM); 
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
	CRAS_Update_Patrol_Check_Sheet_Validation()
		- Main sub function of "CRAS_Update_Patrol_Check_Sheet" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Patrol_Check_Sheet_Validation(char *s_msg_code,
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