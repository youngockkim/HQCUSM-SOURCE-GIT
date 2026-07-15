/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_entry.c
    Description : View Entry function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Entry()
            + View Entry definition
        - CWIP_VIEW_ENTRY()
            + Main sub function of CWIP_View_Entry function
            + View Entry definition
    Detail Description
        - CWIP_VIEW_ENTRY()
            + h_proc_step
                + 1 : View Entry definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-09-07             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Entry()
        - View Entry definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Entry(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_ENTRY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_ENTRY", out_node);

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
    CWIP_VIEW_ENTRY()
        - Main sub function of "CWIP_View_Entry" function
        - View Entry definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_ENTRY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPTSCLOS_TAG CWIPTSCLOS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    LOG_head("CWIP_VIEW_ENTRY");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Entry",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_SHIFT Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CREATE_TIME Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CREATE_TIME")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiptsclos(&CWIPTSCLOS);
    TRS.copy(CWIPTSCLOS.WORK_DATE, sizeof(CWIPTSCLOS.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPTSCLOS.LINE_ID, sizeof(CWIPTSCLOS.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPTSCLOS.WORK_SHIFT, sizeof(CWIPTSCLOS.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPTSCLOS.CREATE_TIME, sizeof(CWIPTSCLOS.CREATE_TIME), in_node, "CREATE_TIME");
    CDB_select_cwiptsclos(1, &CWIPTSCLOS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPTSCLOS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS.WORK_DATE), CWIPTSCLOS.WORK_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS.CREATE_TIME), CWIPTSCLOS.CREATE_TIME);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "WORK_DATE", CWIPTSCLOS.WORK_DATE, sizeof(CWIPTSCLOS.WORK_DATE));
    TRS.add_string(out_node, "LINE_ID", CWIPTSCLOS.LINE_ID, sizeof(CWIPTSCLOS.LINE_ID));
    TRS.add_string(out_node, "WORK_SHIFT", CWIPTSCLOS.WORK_SHIFT, sizeof(CWIPTSCLOS.WORK_SHIFT));
    TRS.add_string(out_node, "TABBER", CWIPTSCLOS.TABBER, sizeof(CWIPTSCLOS.TABBER));
    TRS.add_string(out_node, "SIDE", CWIPTSCLOS.SIDE, sizeof(CWIPTSCLOS.SIDE));
    TRS.add_string(out_node, "TYPE_RECOVERY", CWIPTSCLOS.TYPE_RECOVERY, sizeof(CWIPTSCLOS.TYPE_RECOVERY));
    TRS.add_string(out_node, "ADD_COMMENTS", CWIPTSCLOS.ADD_COMMENTS, sizeof(CWIPTSCLOS.ADD_COMMENTS));
    TRS.add_string(out_node, "CMF_1", CWIPTSCLOS.CMF_1, sizeof(CWIPTSCLOS.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPTSCLOS.CMF_2, sizeof(CWIPTSCLOS.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPTSCLOS.CMF_3, sizeof(CWIPTSCLOS.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPTSCLOS.CMF_4, sizeof(CWIPTSCLOS.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPTSCLOS.CMF_5, sizeof(CWIPTSCLOS.CMF_5));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPTSCLOS.CREATE_USER_ID, sizeof(CWIPTSCLOS.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPTSCLOS.CREATE_TIME, sizeof(CWIPTSCLOS.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPTSCLOS.UPDATE_USER_ID, sizeof(CWIPTSCLOS.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPTSCLOS.UPDATE_TIME, sizeof(CWIPTSCLOS.UPDATE_TIME));

	//==============================
	// add gcm data
	//==============================
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

		return MP_FALSE;
	}
	
	TRS.add_string(out_node, "LINE_ID_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

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

		return MP_FALSE;
	}

	TRS.add_string(out_node, "WORK_SHIFT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

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

		return MP_FALSE;
    }

	TRS.add_string(out_node, "TABBER_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        
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

		return MP_FALSE;
    }

	TRS.add_string(out_node, "SIDE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        
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

		return MP_FALSE;
    }

	TRS.add_string(out_node, "TYPE_RECOVERY_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    
    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Entry",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

