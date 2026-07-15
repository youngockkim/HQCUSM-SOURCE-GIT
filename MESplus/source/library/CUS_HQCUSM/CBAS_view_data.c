/******************************************************************************'

    System      : MESplus
    Module      : CBAS
    File Name   : CBAS_view_data.c
    Description : View Data function module

    MES Version : 5.3.4 ~

    Function List
        - CBAS_View_Data()
            + View Data definition
        - CBAS_VIEW_DATA()
            + Main sub function of CBAS_View_Data function
            + View Data definition
    Detail Description
        - CBAS_VIEW_DATA()
            + h_proc_step
                + 1 : View Data definition  by Primary Key
    History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2023/04/11  KangByungChae  Created

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CBAS_View_Data()
        - View Data definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_Data(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CBAS_VIEW_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CBAS_VIEW_DATA", out_node);

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
    CBAS_VIEW_DATA()
        - Main sub function of "CBAS_View_Data" function
        - View Data definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_VIEW_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	int i_step = 0;
    struct MGCMLAGDAT_TAG MGCMLAGDAT;

    LOG_head("CBAS_VIEW_DATA");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("table_name", MP_NSTR, TRS.get_string(in_node, "TABLE_NAME"));
    LOG_add("key_1", MP_NSTR, TRS.get_string(in_node, "KEY_1"));
    LOG_add("key_2", MP_NSTR, TRS.get_string(in_node, "KEY_2"));
    LOG_add("key_3", MP_NSTR, TRS.get_string(in_node, "KEY_3"));
    LOG_add("key_4", MP_NSTR, TRS.get_string(in_node, "KEY_4"));
    LOG_add("key_5", MP_NSTR, TRS.get_string(in_node, "KEY_5"));
    LOG_add("key_6", MP_NSTR, TRS.get_string(in_node, "KEY_6"));
    LOG_add("key_7", MP_NSTR, TRS.get_string(in_node, "KEY_7"));
    LOG_add("key_8", MP_NSTR, TRS.get_string(in_node, "KEY_8"));
    LOG_add("key_9", MP_NSTR, TRS.get_string(in_node, "KEY_9"));
    LOG_add("key_10", MP_NSTR, TRS.get_string(in_node, "KEY_10"));
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
        strcpy(s_msg_code, "CBAS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    DBC_init_mgcmlagdat(&MGCMLAGDAT);

	/* TABLE_NAME Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "TABLE_NAME")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CBAS-0001");
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/* KEY_1 Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "KEY_1")) == MP_FALSE)
    {
		TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_1");
    } 
	if (TRS.get_procstep(in_node) == '1')
	{
		i_step = 2;
	}
    TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MGCMLAGDAT.TABLE_NAME, sizeof(MGCMLAGDAT.TABLE_NAME), in_node, "TABLE_NAME");
    DBC_select_mgcmlagdat(i_step, &MGCMLAGDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CBAS-9999");
        TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
        TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
        TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMLAGDAT.KEY_2), MGCMLAGDAT.KEY_2);
        TRS.add_fieldmsg(out_node, "KEY_3", MP_STR, sizeof(MGCMLAGDAT.KEY_3), MGCMLAGDAT.KEY_3);
        TRS.add_fieldmsg(out_node, "KEY_4", MP_STR, sizeof(MGCMLAGDAT.KEY_4), MGCMLAGDAT.KEY_4);
        TRS.add_fieldmsg(out_node, "KEY_5", MP_STR, sizeof(MGCMLAGDAT.KEY_5), MGCMLAGDAT.KEY_5);
        TRS.add_fieldmsg(out_node, "KEY_6", MP_STR, sizeof(MGCMLAGDAT.KEY_6), MGCMLAGDAT.KEY_6);
        TRS.add_fieldmsg(out_node, "KEY_7", MP_STR, sizeof(MGCMLAGDAT.KEY_7), MGCMLAGDAT.KEY_7);
        TRS.add_fieldmsg(out_node, "KEY_8", MP_STR, sizeof(MGCMLAGDAT.KEY_8), MGCMLAGDAT.KEY_8);
        TRS.add_fieldmsg(out_node, "KEY_9", MP_STR, sizeof(MGCMLAGDAT.KEY_9), MGCMLAGDAT.KEY_9);
        TRS.add_fieldmsg(out_node, "KEY_10", MP_STR, sizeof(MGCMLAGDAT.KEY_10), MGCMLAGDAT.KEY_10);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY));
    TRS.add_string(out_node, "TABLE_NAME", MGCMLAGDAT.TABLE_NAME, sizeof(MGCMLAGDAT.TABLE_NAME));
    TRS.add_string(out_node, "KEY_1", MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1));
    TRS.add_string(out_node, "KEY_2", MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2));
    TRS.add_string(out_node, "KEY_3", MGCMLAGDAT.KEY_3, sizeof(MGCMLAGDAT.KEY_3));
    TRS.add_string(out_node, "KEY_4", MGCMLAGDAT.KEY_4, sizeof(MGCMLAGDAT.KEY_4));
    TRS.add_string(out_node, "KEY_5", MGCMLAGDAT.KEY_5, sizeof(MGCMLAGDAT.KEY_5));
    TRS.add_string(out_node, "KEY_6", MGCMLAGDAT.KEY_6, sizeof(MGCMLAGDAT.KEY_6));
    TRS.add_string(out_node, "KEY_7", MGCMLAGDAT.KEY_7, sizeof(MGCMLAGDAT.KEY_7));
    TRS.add_string(out_node, "KEY_8", MGCMLAGDAT.KEY_8, sizeof(MGCMLAGDAT.KEY_8));
    TRS.add_string(out_node, "KEY_9", MGCMLAGDAT.KEY_9, sizeof(MGCMLAGDAT.KEY_9));
    TRS.add_string(out_node, "KEY_10", MGCMLAGDAT.KEY_10, sizeof(MGCMLAGDAT.KEY_10));
    TRS.add_string(out_node, "DATA_1", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
    TRS.add_string(out_node, "DATA_2", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
    TRS.add_string(out_node, "DATA_3", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));
    TRS.add_string(out_node, "DATA_4", MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));
    TRS.add_string(out_node, "DATA_5", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));
    TRS.add_string(out_node, "DATA_6", MGCMLAGDAT.DATA_6, sizeof(MGCMLAGDAT.DATA_6));
    TRS.add_string(out_node, "DATA_7", MGCMLAGDAT.DATA_7, sizeof(MGCMLAGDAT.DATA_7));
    TRS.add_string(out_node, "DATA_8", MGCMLAGDAT.DATA_8, sizeof(MGCMLAGDAT.DATA_8));
    TRS.add_string(out_node, "DATA_9", MGCMLAGDAT.DATA_9, sizeof(MGCMLAGDAT.DATA_9));
    TRS.add_string(out_node, "DATA_10", MGCMLAGDAT.DATA_10, sizeof(MGCMLAGDAT.DATA_10));
    TRS.add_string(out_node, "CREATE_USER_ID", MGCMLAGDAT.CREATE_USER_ID, sizeof(MGCMLAGDAT.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MGCMLAGDAT.CREATE_TIME, sizeof(MGCMLAGDAT.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", MGCMLAGDAT.UPDATE_USER_ID, sizeof(MGCMLAGDAT.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MGCMLAGDAT.UPDATE_TIME, sizeof(MGCMLAGDAT.UPDATE_TIME));

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

