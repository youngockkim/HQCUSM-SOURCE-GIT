/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_tabber_jig_repair.c
    Description : Tabber_Jig_Repair Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_Tabber_Jig_Repair()
            + Create/Update/Delete Tabber_Jig_Repair definition
        - CRAS_UPDATE_TABBER_JIG_REPAIR()
            + Main sub function of CRAS_Update_Tabber_Jig_Repair function
            + Create/Update/Delete Tabber_Jig_Repair definition
        - CRAS_Update_Tabber_Jig_Repair_Validation()
            + Main sub function of CRAS_UPDATE_TABBER_JIG_REPAIR function
            + Check the condition for create/update/delete Tabber_Jig_Repair
    Detail Description
        - CRAS_UPDATE_TABBER_JIG_REPAIR()
            + h_proc_step
                + MP_STEP_CREATE : Create Tabber_Jig_Repair definition
                + MP_STEP_UPDATE : Update Tabber_Jig_Repair definition
                + MP_STEP_DELETE : Delete Tabber_Jig_Repair definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/10/08             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_Tabber_Jig_Repair_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_Tabber_Jig_Repair()
        - Create/Update/Delete Tabber_Jig_Repair definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Tabber_Jig_Repair(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_UPDATE_TABBER_JIG_REPAIR(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_TABBER_JIG_REPAIR", out_node);

    if(i_ret == MP_TRUE)
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
    CRAS_UPDATE_TABBER_JIG_REPAIR()
        - Main sub function of "CRAS_Update_Tabber_Jig_Repair" function
        - Create/Update/Delete Tabber_Jig_Repair definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_TABBER_JIG_REPAIR(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	int inx;
    int i_tran_count;
    TRSNode ** Tran_List;

	struct CRASTBRJGR_TAG CRASTBRJGR;
    struct CRASTBRJGR_TAG CRASTBRJGR_o;
    char   s_sys_time[14];

	LOG_head("CRAS_UPDATE_TABBER_JIG_REPAIR");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CRAS_Update_Tabber_Jig_Repair_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strncpy(s_msg_code, "CMN-0003", strlen("CMN-0003"));
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    Tran_List = TRS.get_list(in_node, "DATA_LIST");
    i_tran_count = TRS.get_item_count(in_node, "DATA_LIST");

    for(inx = 0; inx < i_tran_count; inx++)
    {
		CDB_init_crastbrjgr(&CRASTBRJGR);
		TRS.copy(CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY), Tran_List[inx], IN_FACTORY);
		TRS.copy(CRASTBRJGR.WORK_DATE, sizeof(CRASTBRJGR.WORK_DATE), Tran_List[inx], "WORK_DATE");
		CRASTBRJGR.JGR_SEQ = TRS.get_int(Tran_List[inx], "JGR_SEQ");
		TRS.copy(CRASTBRJGR.JGR_PROC, sizeof(CRASTBRJGR.JGR_PROC), Tran_List[inx], "JGR_PROC");
		TRS.copy(CRASTBRJGR.LINE_ID, sizeof(CRASTBRJGR.LINE_ID), Tran_List[inx], "LINE_ID");
		TRS.copy(CRASTBRJGR.RES_ID, sizeof(CRASTBRJGR.RES_ID), Tran_List[inx], "RES_ID");
		TRS.copy(CRASTBRJGR.WORK_TIME, sizeof(CRASTBRJGR.WORK_TIME), Tran_List[inx], "WORK_TIME");
		TRS.copy(CRASTBRJGR.JIG_NO, sizeof(CRASTBRJGR.JIG_NO), Tran_List[inx], "JIG_NO");
		TRS.copy(CRASTBRJGR.WRKR_NAME, sizeof(CRASTBRJGR.WRKR_NAME), Tran_List[inx], "WRKR_NAME");
		TRS.copy(CRASTBRJGR.DEPT_CD, sizeof(CRASTBRJGR.DEPT_CD), Tran_List[inx], "DEPT_CD");
		TRS.copy(CRASTBRJGR.JGR_RSN, sizeof(CRASTBRJGR.JGR_RSN), Tran_List[inx], "JGR_RSN");
		TRS.copy(CRASTBRJGR.JGR_REMARKS, sizeof(CRASTBRJGR.JGR_REMARKS), Tran_List[inx], "JGR_REMARKS");
		TRS.copy(CRASTBRJGR.CMF_1, sizeof(CRASTBRJGR.CMF_1), Tran_List[inx], "CMF_1");
		TRS.copy(CRASTBRJGR.CMF_2, sizeof(CRASTBRJGR.CMF_2), Tran_List[inx], "CMF_2");
		TRS.copy(CRASTBRJGR.CMF_3, sizeof(CRASTBRJGR.CMF_3), Tran_List[inx], "CMF_3");
		TRS.copy(CRASTBRJGR.CMF_4, sizeof(CRASTBRJGR.CMF_4), Tran_List[inx], "CMF_4");
		TRS.copy(CRASTBRJGR.CMF_5, sizeof(CRASTBRJGR.CMF_5), Tran_List[inx], "CMF_5");
		TRS.copy(CRASTBRJGR.CMF_6, sizeof(CRASTBRJGR.CMF_6), Tran_List[inx], "CMF_6");
		TRS.copy(CRASTBRJGR.CMF_7, sizeof(CRASTBRJGR.CMF_7), Tran_List[inx], "CMF_7");
		TRS.copy(CRASTBRJGR.CMF_8, sizeof(CRASTBRJGR.CMF_8), Tran_List[inx], "CMF_8");
		TRS.copy(CRASTBRJGR.CMF_9, sizeof(CRASTBRJGR.CMF_9), Tran_List[inx], "CMF_9");
		TRS.copy(CRASTBRJGR.CMF_10, sizeof(CRASTBRJGR.CMF_10), Tran_List[inx], "CMF_10");

		if(TRS.get_procstep(Tran_List[inx]) == MP_STEP_CREATE)
		{
            CDB_select_crastbrjgr(1,&CRASTBRJGR);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
					//----[Addtional Logic for Create Case]----

					CRASTBRJGR.JGR_SEQ = CDB_select_crastbrjgr_scalar(2, &CRASTBRJGR);
					if(DB_error_code != DB_SUCCESS)
					{
						strncpy(s_msg_code, "CRAS-0004",strlen("CRAS-0004"));
						TRS.add_fieldmsg(out_node, "CRASTBRJGR INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
						TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE; 
					}

					TRS.copy(CRASTBRJGR.CREATE_USER_ID, sizeof(CRASTBRJGR.CREATE_USER_ID), in_node, IN_USERID);
					memcpy(CRASTBRJGR.CREATE_TIME, s_sys_time, sizeof(CRASTBRJGR.CREATE_TIME));
					CDB_insert_crastbrjgr(&CRASTBRJGR);
					if(DB_error_code != DB_SUCCESS)
					{
						strncpy(s_msg_code, "CRAS-0004",strlen("CRAS-0004"));
						TRS.add_fieldmsg(out_node, "CRASTBRJGR INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
						TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
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
					strncpy(s_msg_code, "CRAS-0004", strlen("CRAS-0004"));
					TRS.add_fieldmsg(out_node, "CRASTBRJGR SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
					TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
					TRS.add_dberrmsg(out_node,DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}			
		}
		else if(TRS.get_procstep(Tran_List[inx]) == MP_STEP_UPDATE)
		{
			CDB_init_crastbrjgr(&CRASTBRJGR_o);
			TRS.copy(CRASTBRJGR_o.FACTORY, sizeof(CRASTBRJGR_o.FACTORY), Tran_List[inx], IN_FACTORY);
			TRS.copy(CRASTBRJGR_o.WORK_DATE, sizeof(CRASTBRJGR_o.WORK_DATE), Tran_List[inx], "WORK_DATE");
			CRASTBRJGR_o.JGR_SEQ = TRS.get_int(Tran_List[inx], "JGR_SEQ");
			CDB_select_crastbrjgr(1, &CRASTBRJGR_o);
			if(DB_error_code != DB_SUCCESS)
			{
				strncpy(s_msg_code, "CRAS-0004",strlen("CRAS-0004"));
				TRS.add_fieldmsg(out_node, "CRASTBRJGR SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR_o.FACTORY), CRASTBRJGR_o.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR_o.WORK_DATE), CRASTBRJGR_o.WORK_DATE);
				TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR_o.JGR_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//----[Addtional Logic for Update Case]----

			TRS.copy(CRASTBRJGR.UPDATE_USER_ID, sizeof(CRASTBRJGR.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CRASTBRJGR.UPDATE_TIME, s_sys_time, sizeof(CRASTBRJGR.UPDATE_TIME));

			CDB_update_crastbrjgr(1, &CRASTBRJGR);
			if(DB_error_code != DB_SUCCESS)
			{
				strncpy(s_msg_code, "CRAS-0004",strlen("CRAS-0004"));
				TRS.add_fieldmsg(out_node, "CRASTBRJGR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
				TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else if(TRS.get_procstep(Tran_List[inx]) == MP_STEP_DELETE)
		{
			CDB_delete_crastbrjgr(1, &CRASTBRJGR);
			if(DB_error_code != DB_SUCCESS)
			{
				strncpy(s_msg_code, "CRAS-0004",strlen("CRAS-0004"));
				TRS.add_fieldmsg(out_node, "CRASTBRJGR DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
				TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
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
    CRAS_Update_Tabber_Jig_Repair_Validation()
        - Main sub function of "CRAS_UPDATE_TABBER_JIG_REPAIR" function
        - Check the condition for create/update/delete Tabber_Jig_Repair
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Tabber_Jig_Repair_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASTBRJGR_TAG CRASTBRJGR;
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
		strncpy(s_msg_code, "CRAS-0001",strlen("CRAS-0001"));
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }
	 
    return MP_TRUE;
}

