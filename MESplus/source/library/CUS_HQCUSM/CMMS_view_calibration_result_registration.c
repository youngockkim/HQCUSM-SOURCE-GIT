/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_result_registration.c
    Description : View Calibration_Result_Registration function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_Result_Registration()
            + View Calibration_Result_Registration definition
        - CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION()
            + Main sub function of CMMS_View_Calibration_Result_Registration function
            + View Calibration_Result_Registration definition
        - CMMS_View_Calibration_Result_Registration_Validation()
            + Main sub function of CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION function
            + Check the condition for view Calibration_Result_Registration
    Detail Description
        - CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION()
            + h_proc_step
                + 1 : View Calibration_Result_Registration definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-31             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Calibration_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Calibration_Result_Registration()
        - View Calibration_Result_Registration definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Result_Registration(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION", out_node);

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
    CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION()
        - Main sub function of "CMMS_View_Calibration_Result_Registration" function
        - View Calibration_Result_Registration definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALRST_TAG CMMSCALRST;
	struct CMMSCALEQP_TAG CMMSCALEQP;
	struct CMMSCALFLE_TAG CMMSCALFLE;
	struct CMMSEQPDEF_TAG CMMSEQPDEF;
	struct CMMSINSDEF_TAG CMMSINSDEF;
	struct CMMSUSRDEF_TAG CMMSUSRDEF;

	TRSNode *list_item;
	int i_case;

    LOG_head("CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("cali_id", MP_NSTR, TRS.get_string(in_node, "CALI_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Result_Registration",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Calibration_Result_Registration_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmscalrst(&CMMSCALRST);
    TRS.copy(CMMSCALRST.FACTORY, sizeof(CMMSCALRST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALRST.CALI_ID, sizeof(CMMSCALRST.CALI_ID), in_node, "CALI_ID");
    CDB_select_cmmscalrst(1, &CMMSCALRST);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSCALRST SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CMMSCALRST.FACTORY, sizeof(CMMSCALRST.FACTORY));
    TRS.add_string(out_node, "CALI_ID", CMMSCALRST.CALI_ID, sizeof(CMMSCALRST.CALI_ID));
    TRS.add_string(out_node, "EQUIP_ID", CMMSCALRST.EQUIP_ID, sizeof(CMMSCALRST.EQUIP_ID));
    TRS.add_string(out_node, "PLAN_DATE", CMMSCALRST.PLAN_DATE, sizeof(CMMSCALRST.PLAN_DATE));
    TRS.add_string(out_node, "CALI_DATE", CMMSCALRST.CALI_DATE, sizeof(CMMSCALRST.CALI_DATE));
    TRS.add_string(out_node, "CALI_INSTITUTE", CMMSCALRST.CALI_INSTITUTE, sizeof(CMMSCALRST.CALI_INSTITUTE));
    TRS.add_string(out_node, "CALI_METHOD", CMMSCALRST.CALI_METHOD, sizeof(CMMSCALRST.CALI_METHOD));
    TRS.add_char(out_node, "CALI_RESULT", CMMSCALRST.CALI_RESULT);
    TRS.add_double(out_node, "CALI_COST", CMMSCALRST.CALI_COST);
    TRS.add_string(out_node, "CALI_DESC", CMMSCALRST.CALI_DESC, sizeof(CMMSCALRST.CALI_DESC));
    TRS.add_string(out_node, "CALI_USER_ID", CMMSCALRST.CALI_USER_ID, sizeof(CMMSCALRST.CALI_USER_ID));
    TRS.add_string(out_node, "FILE_NAME", CMMSCALRST.FILE_NAME, sizeof(CMMSCALRST.FILE_NAME));
    TRS.add_string(out_node, "FILE_PATH", CMMSCALRST.FILE_PATH, sizeof(CMMSCALRST.FILE_PATH));
    TRS.add_string(out_node, "RESULT_FILE_NAME", CMMSCALRST.RESULT_FILE_NAME, sizeof(CMMSCALRST.RESULT_FILE_NAME));
    TRS.add_string(out_node, "RESULT_FILE_PATH", CMMSCALRST.RESULT_FILE_PATH, sizeof(CMMSCALRST.RESULT_FILE_PATH));
    TRS.add_char(out_node, "CONFIRM_FLAG", CMMSCALRST.CONFIRM_FLAG);
    TRS.add_string(out_node, "CONFIRM_USER_ID", CMMSCALRST.CONFIRM_USER_ID, sizeof(CMMSCALRST.CONFIRM_USER_ID));
    TRS.add_string(out_node, "CONFIRM_TIME", CMMSCALRST.CONFIRM_TIME, sizeof(CMMSCALRST.CONFIRM_TIME));
    TRS.add_string(out_node, "CMF_1", CMMSCALRST.CMF_1, sizeof(CMMSCALRST.CMF_1));
    TRS.add_string(out_node, "CMF_2", CMMSCALRST.CMF_2, sizeof(CMMSCALRST.CMF_2));
    TRS.add_string(out_node, "CMF_3", CMMSCALRST.CMF_3, sizeof(CMMSCALRST.CMF_3));
    TRS.add_string(out_node, "CMF_4", CMMSCALRST.CMF_4, sizeof(CMMSCALRST.CMF_4));
    TRS.add_string(out_node, "CMF_5", CMMSCALRST.CMF_5, sizeof(CMMSCALRST.CMF_5));
    TRS.add_string(out_node, "CMF_6", CMMSCALRST.CMF_6, sizeof(CMMSCALRST.CMF_6));
    TRS.add_string(out_node, "CMF_7", CMMSCALRST.CMF_7, sizeof(CMMSCALRST.CMF_7));
    TRS.add_string(out_node, "CMF_8", CMMSCALRST.CMF_8, sizeof(CMMSCALRST.CMF_8));
    TRS.add_string(out_node, "CMF_9", CMMSCALRST.CMF_9, sizeof(CMMSCALRST.CMF_9));
    TRS.add_string(out_node, "CMF_10", CMMSCALRST.CMF_10, sizeof(CMMSCALRST.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSCALRST.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSCALRST.CREATE_TIME, sizeof(CMMSCALRST.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSCALRST.UPDATE_USER_ID, sizeof(CMMSCALRST.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSCALRST.UPDATE_TIME, sizeof(CMMSCALRST.UPDATE_TIME));

	if (COM_isspace(CMMSCALRST.FILE_PATH, sizeof(CMMSCALRST.FILE_PATH)) == MP_FALSE)
    {
        if(CMMS_get_attached_file(s_msg_code, out_node, CMMSCALRST.FILE_PATH, MP_BIN_DATA_1, 'Y') == MP_FALSE)
        {
            COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
        }
    }

	
	//교정 기관명 조회
	CDB_init_cmmsinsdef(&CMMSINSDEF);
	memcpy(CMMSINSDEF.FACTORY, CMMSCALRST.FACTORY, sizeof(CMMSINSDEF.FACTORY));
	memcpy(CMMSINSDEF.INSTI_CODE, CMMSCALRST.CALI_INSTITUTE, sizeof(CMMSINSDEF.INSTI_CODE));
    CDB_select_cmmsinsdef(1, &CMMSINSDEF);
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.add_string(out_node, "CALI_INSTITUTE_NAME", CMMSINSDEF.INSTI_NAME, sizeof(CMMSINSDEF.INSTI_NAME));	
	}

	//교정자 명 조회
	CDB_init_cmmsusrdef(&CMMSUSRDEF);
	memcpy(CMMSUSRDEF.FACTORY, CMMSCALRST.FACTORY, sizeof(CMMSUSRDEF.FACTORY));
	memcpy(CMMSUSRDEF.USER_ID, CMMSCALRST.CALI_USER_ID, sizeof(CMMSUSRDEF.USER_ID));
    CDB_select_cmmsusrdef(1, &CMMSUSRDEF);
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.add_string(out_node, "CALI_USER_NAME", CMMSUSRDEF.USER_NAME, sizeof(CMMSUSRDEF.USER_NAME));
	}


	if(TRS.get_procstep(in_node) == '2')
	{
		//기준 계측기 정보 조회
		i_case = 1;

		CDB_init_cmmscaleqp(&CMMSCALEQP);
		memcpy(CMMSCALEQP.FACTORY, CMMSCALRST.FACTORY, sizeof(CMMSCALEQP.FACTORY));
		memcpy(CMMSCALEQP.CALI_ID, CMMSCALRST.CALI_ID, sizeof(CMMSCALEQP.CALI_ID));
		CDB_open_cmmscaleqp(i_case, &CMMSCALEQP);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSCALEQP OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
			TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_cmmscaleqp(i_case, &CMMSCALEQP);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmsinsdef(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSCALEQP FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
				TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
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
				CDB_close_cmmscaleqp(i_case);
				break;
			}

			list_item = TRS.add_node(out_node, "CALIBRATION_EQUIP_LIST");
			TRS.add_string(list_item, "CALI_ID", CMMSCALEQP.CALI_ID, sizeof(CMMSCALEQP.CALI_ID));
			TRS.add_string(list_item, "EQUIP_ID", CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID));	
			
			CDB_init_cmmseqpdef(&CMMSEQPDEF);
			memcpy(CMMSEQPDEF.FACTORY, CMMSCALEQP.FACTORY, sizeof(CMMSEQPDEF.FACTORY));
			memcpy(CMMSEQPDEF.EQUIP_ID, CMMSCALEQP.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
			CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "EQUIP_NAME", CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));	
			}
		}

		//File 정보 조회
		CDB_init_cmmscalfle(&CMMSCALFLE);
		memcpy(CMMSCALFLE.FACTORY, CMMSCALRST.FACTORY, sizeof(CMMSCALFLE.FACTORY));
		memcpy(CMMSCALFLE.CALI_ID, CMMSCALRST.CALI_ID, sizeof(CMMSCALFLE.CALI_ID));
		CDB_open_cmmscalfle(i_case, &CMMSCALFLE);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSCALFLE OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALFLE.FACTORY), CMMSCALFLE.FACTORY);
			TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALFLE.CALI_ID), CMMSCALFLE.CALI_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_cmmscalfle(i_case, &CMMSCALFLE);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmscalfle(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSCALFLE FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALFLE.FACTORY), CMMSCALFLE.FACTORY);
				TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALFLE.CALI_ID), CMMSCALFLE.CALI_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsinsdef(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "CALIBRATION_FILE_LIST");
			TRS.add_string(list_item, "CALI_ID", CMMSCALFLE.CALI_ID, sizeof(CMMSCALFLE.CALI_ID));
			TRS.add_int(list_item, "FILE_ORDER", CMMSCALFLE.FILE_ORDER);
			TRS.add_string(list_item, "FILE_NAME", CMMSCALFLE.FILE_NAME, sizeof(CMMSCALFLE.FILE_NAME));
			TRS.add_string(list_item, "FILE_PATH", CMMSCALFLE.FILE_PATH, sizeof(CMMSCALFLE.FILE_PATH));

			if (COM_isspace(CMMSCALFLE.FILE_PATH, sizeof(CMMSCALFLE.FILE_PATH)) == MP_FALSE)
			{
				if(CMMS_get_attached_file(s_msg_code, out_node, CMMSCALFLE.FILE_PATH, TRS.get_string(list_item, "FILE_NAME"), 'Y') == MP_FALSE)
				{
					COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
				}
			}
		}
	}


    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Result_Registration",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Calibration_Result_Registration_Validation()
        - Main sub function of "CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION" function
        - Check the condition for view Calibration_Result_Registration
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALRST_TAG CMMSCALRST;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CALI_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CALI_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "CALI_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmscalrst(&CMMSCALRST);
    TRS.copy(CMMSCALRST.FACTORY, sizeof(CMMSCALRST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALRST.CALI_ID, sizeof(CMMSCALRST.CALI_ID), in_node, "CALI_ID");
    CDB_select_cmmscalrst(1, &CMMSCALRST);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "MMS-0011");
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "CMMSCALRST SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

