/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_tabber_jig_repair_list.c
    Description : View Tabber_Jig_Repair List function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_Tabber_Jig_Repair_List()
            + View Tabber_Jig_Repair definition List
        - CRAS_VIEW_TABBER_JIG_REPAIR_LIST()
            + Main sub function of CRAS_View_Tabber_Jig_Repair_List function
            + View Tabber_Jig_Repair definition List
    Detail Description
        - CRAS_VIEW_TABBER_JIG_REPAIR_LIST()
            + h_proc_step
                + 1 : View Tabber_Jig_Repair definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/10/08             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_Tabber_Jig_Repair_List()
        - View Tabber_Jig_Repair definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Tabber_Jig_Repair_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_TABBER_JIG_REPAIR_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_TABBER_JIG_REPAIR_LIST", out_node);

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
    CRAS_VIEW_TABBER_JIG_REPAIR_LIST()
        - Main sub function of "CRAS_View_Tabber_Jig_Repair_List" function
        - View Tabber_Jig_Repair definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_TABBER_JIG_REPAIR_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_1;
    struct CRASTBRJGR_TAG CRASTBRJGR;
    TRSNode *list_item;

    int i_case;

	LOG_head("CRAS_VIEW_TABBER_JIG_REPAIR_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strncpy(s_msg_code, "CRAS-0001", strlen("CRAS-0001"));
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CRAS-0001", strlen("CRAS-0001"));
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	i_case = 1;

    CDB_init_crastbrjgr(&CRASTBRJGR);
    TRS.copy(CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASTBRJGR.WORK_DATE, sizeof(CRASTBRJGR.WORK_DATE), in_node, "WORK_DATE");
    CDB_open_crastbrjgr(i_case, &CRASTBRJGR);
    if(DB_error_code != DB_SUCCESS)
    {
		strncpy(s_msg_code, "CRAS-0004", strlen("CRAS-0004"));
        TRS.add_fieldmsg(out_node, "CRASTBRJGR OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
        TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_crastbrjgr(i_case, &CRASTBRJGR);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_crastbrjgr(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CRAS-0004");
            TRS.add_fieldmsg(out_node, "CRASTBRJGR FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRJGR.FACTORY), CRASTBRJGR.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASTBRJGR.WORK_DATE), CRASTBRJGR.WORK_DATE);
            TRS.add_fieldmsg(out_node, "JGR_SEQ", MP_INT, CRASTBRJGR.JGR_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_crastbrjgr(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_WORK_DATE", CRASTBRJGR.WORK_DATE, sizeof(CRASTBRJGR.WORK_DATE));
            TRS.set_int(out_node, "NEXT_JGR_SEQ", CRASTBRJGR.JGR_SEQ);
            CDB_close_crastbrjgr(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "DATA_LIST");

        TRS.add_string(list_item, "FACTORY", CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY));
        TRS.add_string(list_item, "WORK_DATE", CRASTBRJGR.WORK_DATE, sizeof(CRASTBRJGR.WORK_DATE));
        TRS.add_int(list_item, "JGR_SEQ", CRASTBRJGR.JGR_SEQ);
        TRS.add_string(list_item, "JGR_PROC", CRASTBRJGR.JGR_PROC, sizeof(CRASTBRJGR.JGR_PROC));
		
		DBC_init_mgcmtbldat(&MGCMTBLDAT_1);
	    memcpy(MGCMTBLDAT_1.TABLE_NAME, "@JIG_REPAIR_PROCESS", strlen("@JIG_REPAIR_PROCESS"));
		memcpy(MGCMTBLDAT_1.FACTORY, CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY));
        memcpy(MGCMTBLDAT_1.KEY_1, CRASTBRJGR.JGR_PROC, sizeof(CRASTBRJGR.JGR_PROC));
	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT_1);
        if(DB_error_code == DB_SUCCESS)
        {
			TRS.add_string(list_item, "JGR_PROC_NAME", MGCMTBLDAT_1.DATA_1, sizeof(MGCMTBLDAT_1.DATA_1));
		}
		TRS.add_string(list_item, "LINE_ID", CRASTBRJGR.LINE_ID, sizeof(CRASTBRJGR.LINE_ID));
        TRS.add_string(list_item, "RES_ID", CRASTBRJGR.RES_ID, sizeof(CRASTBRJGR.RES_ID));
        TRS.add_string(list_item, "WORK_TIME", CRASTBRJGR.WORK_TIME, sizeof(CRASTBRJGR.WORK_TIME));
        TRS.add_string(list_item, "JIG_NO", CRASTBRJGR.JIG_NO, sizeof(CRASTBRJGR.JIG_NO));
        TRS.add_string(list_item, "WRKR_NAME", CRASTBRJGR.WRKR_NAME, sizeof(CRASTBRJGR.WRKR_NAME));
        TRS.add_string(list_item, "DEPT_CD", CRASTBRJGR.DEPT_CD, sizeof(CRASTBRJGR.DEPT_CD));

		DBC_init_mgcmtbldat(&MGCMTBLDAT_1);
	    memcpy(MGCMTBLDAT_1.TABLE_NAME, "@LINE_CODE", strlen("@LINE_CODE"));
		memcpy(MGCMTBLDAT_1.FACTORY, CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY));
        memcpy(MGCMTBLDAT_1.KEY_1, CRASTBRJGR.LINE_ID, sizeof(CRASTBRJGR.LINE_ID));
		memcpy(MGCMTBLDAT_1.KEY_3, " ", sizeof(" "));

	    DBC_select_mgcmtbldat(110, &MGCMTBLDAT_1);
        if(DB_error_code == DB_SUCCESS)
        {
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			memcpy(MGCMTBLDAT.TABLE_NAME, "@DEPT_CODE_LINE", strlen("@DEPT_CODE_LINE"));
			memcpy(MGCMTBLDAT.FACTORY, CRASTBRJGR.FACTORY, sizeof(CRASTBRJGR.FACTORY));
			memcpy(MGCMTBLDAT.KEY_1, MGCMTBLDAT_1.DATA_7, sizeof(MGCMTBLDAT_1.DATA_7));
			memcpy(MGCMTBLDAT.KEY_2, CRASTBRJGR.DEPT_CD, sizeof(CRASTBRJGR.DEPT_CD));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "DEPT_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			} 			
        }
        TRS.add_string(list_item, "JGR_RSN", CRASTBRJGR.JGR_RSN, sizeof(CRASTBRJGR.JGR_RSN));
		
        TRS.add_string(list_item, "JGR_REMARKS", CRASTBRJGR.JGR_REMARKS, sizeof(CRASTBRJGR.JGR_REMARKS));
        TRS.add_string(list_item, "CMF_1", CRASTBRJGR.CMF_1, sizeof(CRASTBRJGR.CMF_1));
        TRS.add_string(list_item, "CMF_2", CRASTBRJGR.CMF_2, sizeof(CRASTBRJGR.CMF_2));
        TRS.add_string(list_item, "CMF_3", CRASTBRJGR.CMF_3, sizeof(CRASTBRJGR.CMF_3));
        TRS.add_string(list_item, "CMF_4", CRASTBRJGR.CMF_4, sizeof(CRASTBRJGR.CMF_4));
        TRS.add_string(list_item, "CMF_5", CRASTBRJGR.CMF_5, sizeof(CRASTBRJGR.CMF_5));
        TRS.add_string(list_item, "CMF_6", CRASTBRJGR.CMF_6, sizeof(CRASTBRJGR.CMF_6));
        TRS.add_string(list_item, "CMF_7", CRASTBRJGR.CMF_7, sizeof(CRASTBRJGR.CMF_7));
        TRS.add_string(list_item, "CMF_8", CRASTBRJGR.CMF_8, sizeof(CRASTBRJGR.CMF_8));
        TRS.add_string(list_item, "CMF_9", CRASTBRJGR.CMF_9, sizeof(CRASTBRJGR.CMF_9));
        TRS.add_string(list_item, "CMF_10", CRASTBRJGR.CMF_10, sizeof(CRASTBRJGR.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CRASTBRJGR.CREATE_USER_ID, sizeof(CRASTBRJGR.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CRASTBRJGR.CREATE_TIME, sizeof(CRASTBRJGR.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CRASTBRJGR.UPDATE_USER_ID, sizeof(CRASTBRJGR.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CRASTBRJGR.UPDATE_TIME, sizeof(CRASTBRJGR.UPDATE_TIME));
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

