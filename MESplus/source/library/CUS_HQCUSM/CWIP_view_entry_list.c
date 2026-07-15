/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_entry_list.c
    Description : View Entry List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Entry_List()
            + View Entry definition List
        - CWIP_VIEW_ENTRY_LIST()
            + Main sub function of CWIP_View_Entry_List function
            + View Entry definition List
    Detail Description
        - CWIP_VIEW_ENTRY_LIST()
            + h_proc_step
                + 1 : View Entry definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-09-07             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Entry_List()
        - View Entry definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Entry_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_ENTRY_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_ENTRY_LIST", out_node);

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
    CWIP_VIEW_ENTRY_LIST()
        - Main sub function of "CWIP_View_Entry_List" function
        - View Entry definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_ENTRY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPTSCLOS_TAG CWIPTSCLOS;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    TRSNode *list_item;

    int i_step;

    LOG_head("CWIP_VIEW_ENTRY_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Scrap List
    */

    if (TRS.get_procstep(in_node) == '1')
    {
        i_step = 2;
    }
    else
    {
        i_step = 0;
    }

	DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE), in_node, "FROM_DATE");
    TRS.copy(DBC_Q_COND.TO_DATE, sizeof(DBC_Q_COND.TO_DATE), in_node, "TO_DATE");
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

    CDB_init_cwiptsclos(&CWIPTSCLOS);
    TRS.copy(CWIPTSCLOS.LINE_ID, sizeof(CWIPTSCLOS.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPTSCLOS.WORK_SHIFT, sizeof(CWIPTSCLOS.WORK_SHIFT), in_node, "WORK_SHIFT");
  
    CDB_open_cwiptsclos(i_step, &CWIPTSCLOS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPTSCLOS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cwiptsclos(i_step, &CWIPTSCLOS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiptsclos(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTSCLOS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_cwiptsclos(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "ENTRY_LIST");
        TRS.add_string(list_item, "WORK_DATE", CWIPTSCLOS.WORK_DATE, sizeof(CWIPTSCLOS.WORK_DATE));
        TRS.add_string(list_item, "CREATE_TIME", CWIPTSCLOS.CREATE_TIME, sizeof(CWIPTSCLOS.CREATE_TIME));
        
		TRS.add_string(list_item, "LINE_ID", CWIPTSCLOS.LINE_ID, sizeof(CWIPTSCLOS.LINE_ID));
		TRS.add_string(list_item, "WORK_SHIFT", CWIPTSCLOS.WORK_SHIFT, sizeof(CWIPTSCLOS.WORK_SHIFT));
		TRS.add_string(list_item, "TABBER", CWIPTSCLOS.TABBER, sizeof(CWIPTSCLOS.TABBER));
		TRS.add_string(list_item, "SIDE", CWIPTSCLOS.SIDE, sizeof(CWIPTSCLOS.SIDE));
		TRS.add_string(list_item, "TYPE_RECOVERY", CWIPTSCLOS.TYPE_RECOVERY, sizeof(CWIPTSCLOS.TYPE_RECOVERY));

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME,"@LINE_CODE", strlen("@LINE_CODE"));
		memcpy(MGCMTBLDAT.KEY_1,CWIPTSCLOS.LINE_ID, sizeof(CWIPTSCLOS.LINE_ID));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cwiptsclos(i_step);
			return MP_FALSE;
		}
		
		TRS.add_string(list_item, "LINE_ID_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME,"@SHIFT", strlen("@SHIFT"));
		memcpy(MGCMTBLDAT.KEY_1,CWIPTSCLOS.WORK_SHIFT, sizeof(CWIPTSCLOS.WORK_SHIFT));
		DBC_select_mgcmtbldat(1,&MGCMTBLDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cwiptsclos(i_step);
			return MP_FALSE;
		}

		TRS.add_string(list_item, "WORK_SHIFT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, "@TABBER", strlen("@TABBER"));
		memcpy(MGCMTBLDAT.KEY_1, CWIPTSCLOS.TABBER, sizeof(CWIPTSCLOS.TABBER));

	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cwiptsclos(i_step);
			return MP_FALSE;
        }

		TRS.add_string(list_item, "TABBER_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, "@TABBER_SIDE", strlen("@TABBER_SIDE"));
		memcpy(MGCMTBLDAT.KEY_1, CWIPTSCLOS.SIDE, sizeof(CWIPTSCLOS.SIDE));

	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cwiptsclos(i_step);
			return MP_FALSE;
        }

		TRS.add_string(list_item, "SIDE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, "@TABBER_RECOV_TYPE", strlen("@TABBER_RECOV_TYPE"));
        memcpy(MGCMTBLDAT.KEY_1, CWIPTSCLOS.TYPE_RECOVERY, sizeof(MGCMTBLDAT.KEY_1));

	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cwiptsclos(i_step);
			return MP_FALSE;
        }

		TRS.add_string(list_item, "TYPE_RECOVERY_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        
        TRS.add_string(list_item, "ADD_COMMENTS", CWIPTSCLOS.ADD_COMMENTS, sizeof(CWIPTSCLOS.ADD_COMMENTS));

		// IS-21-09-055 Tabber String Cell Loss OI Client - Update
		TRS.add_string(list_item, "CMF_1", CWIPTSCLOS.CMF_1, sizeof(CWIPTSCLOS.CMF_1));
		TRS.add_string(list_item, "CMF_2", CWIPTSCLOS.CMF_2, sizeof(CWIPTSCLOS.CMF_2));
		TRS.add_string(list_item, "CMF_3", CWIPTSCLOS.CMF_3, sizeof(CWIPTSCLOS.CMF_3));
		TRS.add_string(list_item, "CMF_4", CWIPTSCLOS.CMF_4, sizeof(CWIPTSCLOS.CMF_4));
		TRS.add_string(list_item, "CMF_5", CWIPTSCLOS.CMF_5, sizeof(CWIPTSCLOS.CMF_5));

        TRS.add_string(list_item, "CREATE_USER_ID", CWIPTSCLOS.CREATE_USER_ID, sizeof(CWIPTSCLOS.CREATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPTSCLOS.UPDATE_USER_ID, sizeof(CWIPTSCLOS.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CWIPTSCLOS.UPDATE_TIME, sizeof(CWIPTSCLOS.UPDATE_TIME));
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

