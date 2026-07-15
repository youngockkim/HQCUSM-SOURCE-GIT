/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_institute_list.c
    Description : View Calibration_Institute List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_Institute_List()
            + View Calibration_Institute definition List
        - CMMS_VIEW_CALIBRATION_INSTITUTE_LIST()
            + Main sub function of CMMS_View_Calibration_Institute_List function
            + View Calibration_Institute definition List
    Detail Description
        - CMMS_VIEW_CALIBRATION_INSTITUTE_LIST()
            + h_proc_step
                + 1 : View Calibration_Institute definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-17             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Calibration_Institute_List()
        - View Calibration_Institute definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Institute_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_INSTITUTE_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_INSTITUTE_LIST", out_node);

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
    CMMS_VIEW_CALIBRATION_INSTITUTE_LIST()
        - Main sub function of "CMMS_View_Calibration_Institute_List" function
        - View Calibration_Institute definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_INSTITUTE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSINSDEF_TAG CMMSINSDEF;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_CALIBRATION_INSTITUTE_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("insti_code", MP_NSTR, TRS.get_string(in_node, "INSTI_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Institute_List",
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
                              "123") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 2;
    CDB_init_cmmsinsdef(&CMMSINSDEF);
    TRS.copy(CMMSINSDEF.FACTORY, sizeof(CMMSINSDEF.FACTORY), in_node, IN_FACTORY);
    CMMSINSDEF.CALI_DIV = TRS.get_char(in_node, "CALI_DIV");
    //TRS.copy(CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE), in_node, "NEXT_INSTI_CODE");
	if (TRS.get_procstep(in_node) == '3')
	{
		i_case = 3;
		CMMSINSDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
	}
    CDB_open_cmmsinsdef(i_case, &CMMSINSDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSINSDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (TRS.get_procstep(in_node) == '3')
	{
		while(1)
		{
			CDB_fetch_cmmsinsdef(i_case, &CMMSINSDEF);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmsinsdef(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSINSDEF FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsinsdef(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				TRS.set_string(out_node, "NEXT_INSTI_CODE", CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE));
				CDB_close_cmmsinsdef(i_case);
				break;
			}

			list_item = TRS.add_node(out_node, "CALIBRATION_INSTITUTE_LIST");
			TRS.add_string(list_item, "INSTI_CODE", CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE));
			TRS.add_string(list_item, "INSTI_NAME", CMMSINSDEF.INSTI_NAME, sizeof(CMMSINSDEF.INSTI_NAME));			
		}
	}
	else
	{
		while(1)
		{
			CDB_fetch_cmmsinsdef(i_case, &CMMSINSDEF);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmsinsdef(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSINSDEF FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSINSDEF.FACTORY), CMMSINSDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "INSTI_CODE", MP_STR, sizeof(CMMSINSDEF.INSTI_CODE), CMMSINSDEF.INSTI_CODE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsinsdef(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				TRS.set_string(out_node, "NEXT_INSTI_CODE", CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE));
				CDB_close_cmmsinsdef(i_case);
				break;
			}

			list_item = TRS.add_node(out_node, "CALIBRATION_INSTITUTE_LIST");

			TRS.add_string(list_item, "FACTORY", CMMSINSDEF.FACTORY, sizeof(CMMSINSDEF.FACTORY));
			TRS.add_string(list_item, "INSTI_CODE", CMMSINSDEF.INSTI_CODE, sizeof(CMMSINSDEF.INSTI_CODE));
			TRS.add_string(list_item, "INSTI_NAME", CMMSINSDEF.INSTI_NAME, sizeof(CMMSINSDEF.INSTI_NAME));
			TRS.add_char(list_item, "CALI_DIV", CMMSINSDEF.CALI_DIV);
			TRS.add_string(list_item, "ADDRESS", CMMSINSDEF.ADDRESS, sizeof(CMMSINSDEF.ADDRESS));
			TRS.add_string(list_item, "CERTIFICATE_NAME", CMMSINSDEF.CERTIFICATE_NAME, sizeof(CMMSINSDEF.CERTIFICATE_NAME));
			TRS.add_string(list_item, "CERTIFICATE_NO", CMMSINSDEF.CERTIFICATE_NO, sizeof(CMMSINSDEF.CERTIFICATE_NO));
			TRS.add_string(list_item, "CERTIFICATE_PART", CMMSINSDEF.CERTIFICATE_PART, sizeof(CMMSINSDEF.CERTIFICATE_PART));
			TRS.add_string(list_item, "CERTIFICATE_AGENCY", CMMSINSDEF.CERTIFICATE_AGENCY, sizeof(CMMSINSDEF.CERTIFICATE_AGENCY));
			TRS.add_string(list_item, "ISSUE_DATE", CMMSINSDEF.ISSUE_DATE, sizeof(CMMSINSDEF.ISSUE_DATE));
			TRS.add_string(list_item, "FIRST_ISSUE_DATE", CMMSINSDEF.FIRST_ISSUE_DATE, sizeof(CMMSINSDEF.FIRST_ISSUE_DATE));
			TRS.add_string(list_item, "EXPIRE_START_DATE", CMMSINSDEF.EXPIRE_START_DATE, sizeof(CMMSINSDEF.EXPIRE_START_DATE));
			TRS.add_string(list_item, "EXPIRE_END_DATE", CMMSINSDEF.EXPIRE_END_DATE, sizeof(CMMSINSDEF.EXPIRE_END_DATE));
			TRS.add_string(list_item, "FILE_NAME", CMMSINSDEF.FILE_NAME, sizeof(CMMSINSDEF.FILE_NAME));
			TRS.add_string(list_item, "FILE_PATH", CMMSINSDEF.FILE_PATH, sizeof(CMMSINSDEF.FILE_PATH));
			TRS.add_char(list_item, "USE_FLAG", CMMSINSDEF.USE_FLAG);
			TRS.add_string(list_item, "CMF_1", CMMSINSDEF.CMF_1, sizeof(CMMSINSDEF.CMF_1));
			TRS.add_string(list_item, "CMF_2", CMMSINSDEF.CMF_2, sizeof(CMMSINSDEF.CMF_2));
			TRS.add_string(list_item, "CMF_3", CMMSINSDEF.CMF_3, sizeof(CMMSINSDEF.CMF_3));
			TRS.add_string(list_item, "CMF_4", CMMSINSDEF.CMF_4, sizeof(CMMSINSDEF.CMF_4));
			TRS.add_string(list_item, "CMF_5", CMMSINSDEF.CMF_5, sizeof(CMMSINSDEF.CMF_5));
			TRS.add_string(list_item, "CMF_6", CMMSINSDEF.CMF_6, sizeof(CMMSINSDEF.CMF_6));
			TRS.add_string(list_item, "CMF_7", CMMSINSDEF.CMF_7, sizeof(CMMSINSDEF.CMF_7));
			TRS.add_string(list_item, "CMF_8", CMMSINSDEF.CMF_8, sizeof(CMMSINSDEF.CMF_8));
			TRS.add_string(list_item, "CMF_9", CMMSINSDEF.CMF_9, sizeof(CMMSINSDEF.CMF_9));
			TRS.add_string(list_item, "CMF_10", CMMSINSDEF.CMF_10, sizeof(CMMSINSDEF.CMF_10));
			TRS.add_string(list_item, "CREATE_USER_ID", CMMSINSDEF.CREATE_USER_ID, sizeof(CMMSINSDEF.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CMMSINSDEF.CREATE_TIME, sizeof(CMMSINSDEF.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CMMSINSDEF.UPDATE_USER_ID, sizeof(CMMSINSDEF.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", CMMSINSDEF.UPDATE_TIME, sizeof(CMMSINSDEF.UPDATE_TIME));
		}
	}

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Institute_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

