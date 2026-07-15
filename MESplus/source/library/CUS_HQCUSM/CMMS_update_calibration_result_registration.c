/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_calibration_result_registration.c
    Description : Calibration_Result_Registration Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Calibration_Result_Registration()
            + Create/Update/Delete Calibration_Result_Registration definition
        - CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION()
            + Main sub function of CMMS_Update_Calibration_Result_Registration function
            + Create/Update/Delete Calibration_Result_Registration definition
        - CMMS_Update_Calibration_Result_Registration_Validation()
            + Main sub function of CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION function
            + Check the condition for create/update/delete Calibration_Result_Registration
    Detail Description
        - CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION()
            + h_proc_step
                + MP_STEP_CREATE : Create Calibration_Result_Registration definition
                + MP_STEP_UPDATE : Update Calibration_Result_Registration definition
                + MP_STEP_DELETE : Delete Calibration_Result_Registration definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-31             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Calibration_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Calibration_Result_Registration()
        - Create/Update/Delete Calibration_Result_Registration definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_Result_Registration(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION", out_node);

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
    CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION()
        - Main sub function of "CMMS_Update_Calibration_Result_Registration" function
        - Create/Update/Delete Calibration_Result_Registration definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALRST_TAG CMMSCALRST;
    struct CMMSCALRST_TAG CMMSCALRST_o;
	struct CMMSCALPLN_TAG CMMSCALPLN;
	struct CMMSCALEQP_TAG CMMSCALEQP;
	struct CMMSCALFLE_TAG CMMSCALFLE;

    char	s_sys_time[14];
	char	file_path[100];

	int     i;
	int		i_item_count;
	TRSNode **item_list;
	MBLOB m_blob;

    LOG_head("CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("cali_id", MP_NSTR, TRS.get_string(in_node, "CALI_ID"));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    LOG_add("plan_date", MP_NSTR, TRS.get_string(in_node, "PLAN_DATE"));
    LOG_add("cali_date", MP_NSTR, TRS.get_string(in_node, "CALI_DATE"));
    LOG_add("cali_institute", MP_NSTR, TRS.get_string(in_node, "CALI_INSTITUTE"));
    LOG_add("cali_method", MP_NSTR, TRS.get_string(in_node, "CALI_METHOD"));
    LOG_add("cali_result", MP_CHR, TRS.get_char(in_node, "CALI_RESULT"));
    LOG_add("cali_cost", MP_DBL, TRS.get_double(in_node, "CALI_COST"));
    LOG_add("cali_desc", MP_NSTR, TRS.get_string(in_node, "CALI_DESC"));
    LOG_add("cali_user_id", MP_NSTR, TRS.get_string(in_node, "CALI_USER_ID"));
    LOG_add("file_name", MP_NSTR, TRS.get_string(in_node, "FILE_NAME"));
    LOG_add("file_path", MP_NSTR, TRS.get_string(in_node, "FILE_PATH"));
    LOG_add("result_file_name", MP_NSTR, TRS.get_string(in_node, "RESULT_FILE_NAME"));
    LOG_add("result_file_path", MP_NSTR, TRS.get_string(in_node, "RESULT_FILE_PATH"));
    LOG_add("confirm_flag", MP_CHR, TRS.get_char(in_node, "CONFIRM_FLAG"));
    LOG_add("confirm_user_id", MP_NSTR, TRS.get_string(in_node, "CONFIRM_USER_ID"));
    LOG_add("confirm_time", MP_NSTR, TRS.get_string(in_node, "CONFIRM_TIME"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_Result_Registration",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

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

    if(CMMS_Update_Calibration_Result_Registration_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	// Main 화면에서 저장 한 경우 (Create 만 존재)
	if (TRS.get_char(in_node, "TRAN_STEP") == '1')
	{
		
		i_item_count = TRS.get_item_count(in_node, "CALIBRATION_RESULT_LIST");
		item_list = TRS.get_list(in_node, "CALIBRATION_RESULT_LIST");

		for(i = 0; i < i_item_count; i++)
		{
			CDB_init_cmmscalrst(&CMMSCALRST);
			TRS.copy(CMMSCALRST.FACTORY, sizeof(CMMSCALRST.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CMMSCALRST.CALI_ID, sizeof(CMMSCALRST.CALI_ID), item_list[i], "CALI_ID");
			TRS.copy(CMMSCALRST.EQUIP_ID, sizeof(CMMSCALRST.EQUIP_ID), item_list[i], "EQUIP_ID");
			TRS.copy(CMMSCALRST.PLAN_DATE, sizeof(CMMSCALRST.PLAN_DATE), item_list[i], "PLAN_DATE");
			TRS.copy(CMMSCALRST.CALI_DATE, sizeof(CMMSCALRST.CALI_DATE), item_list[i], "CALI_DATE");
			TRS.copy(CMMSCALRST.CALI_INSTITUTE, sizeof(CMMSCALRST.CALI_INSTITUTE), item_list[i], "CALI_INSTITUTE");
			TRS.copy(CMMSCALRST.CALI_METHOD, sizeof(CMMSCALRST.CALI_METHOD), item_list[i], "CALI_METHOD");
			CMMSCALRST.CALI_RESULT = TRS.get_char(item_list[i], "CALI_RESULT");
			CMMSCALRST.CALI_COST = TRS.get_double(item_list[i], "CALI_COST");
			TRS.copy(CMMSCALRST.CALI_DESC, sizeof(CMMSCALRST.CALI_DESC), item_list[i], "CALI_DESC");
			TRS.copy(CMMSCALRST.CALI_USER_ID, sizeof(CMMSCALRST.CALI_USER_ID), item_list[i], "CALI_USER_ID");
			TRS.copy(CMMSCALRST.FILE_NAME, sizeof(CMMSCALRST.FILE_NAME), item_list[i], "FILE_NAME");
			TRS.copy(CMMSCALRST.FILE_PATH, sizeof(CMMSCALRST.FILE_PATH), item_list[i], "FILE_PATH");
			TRS.copy(CMMSCALRST.RESULT_FILE_NAME, sizeof(CMMSCALRST.RESULT_FILE_NAME), item_list[i], "RESULT_FILE_NAME");
			TRS.copy(CMMSCALRST.RESULT_FILE_PATH, sizeof(CMMSCALRST.RESULT_FILE_PATH), item_list[i], "RESULT_FILE_PATH");
			CMMSCALRST.CONFIRM_FLAG = TRS.get_char(item_list[i], "CONFIRM_FLAG");
			TRS.copy(CMMSCALRST.CONFIRM_USER_ID, sizeof(CMMSCALRST.CONFIRM_USER_ID), item_list[i], "CONFIRM_USER_ID");
			TRS.copy(CMMSCALRST.CONFIRM_TIME, sizeof(CMMSCALRST.CONFIRM_TIME), in_node, "CONFIRM_TIME");
			TRS.copy(CMMSCALRST.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID), in_node, "CREATE_USER_ID");
			TRS.copy(CMMSCALRST.CREATE_TIME, sizeof(CMMSCALRST.CREATE_TIME), in_node, "CREATE_TIME");
			TRS.copy(CMMSCALRST.UPDATE_USER_ID, sizeof(CMMSCALRST.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
			TRS.copy(CMMSCALRST.UPDATE_TIME, sizeof(CMMSCALRST.UPDATE_TIME), in_node, "UPDATE_TIME");

			if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
			{
				//----[Addtional Logic for Create Case]----
				TRS.copy(CMMSCALRST.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSCALRST.CREATE_TIME, s_sys_time, sizeof(CMMSCALRST.CREATE_TIME));
				CDB_insert_cmmscalrst(&CMMSCALRST);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALRST INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
			{
				CDB_init_cmmscalrst(&CMMSCALRST_o);
				TRS.copy(CMMSCALRST_o.FACTORY, sizeof(CMMSCALRST_o.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CMMSCALRST_o.CALI_ID, sizeof(CMMSCALRST_o.CALI_ID), in_node, "CALI_ID");
				CDB_select_cmmscalrst_for_update(1, &CMMSCALRST_o);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALRST SELECT FOR UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST_o.FACTORY), CMMSCALRST_o.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST_o.CALI_ID), CMMSCALRST_o.CALI_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				//----[Addtional Logic for Update Case]----

				memcpy(CMMSCALRST.CREATE_USER_ID, CMMSCALRST_o.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID));
				memcpy(CMMSCALRST.CREATE_TIME, CMMSCALRST_o.CREATE_TIME, sizeof(CMMSCALRST.CREATE_TIME));
				TRS.copy(CMMSCALRST.UPDATE_USER_ID, sizeof(CMMSCALRST.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSCALRST.UPDATE_TIME, s_sys_time, sizeof(CMMSCALRST.UPDATE_TIME));

				CDB_update_cmmscalrst(1, &CMMSCALRST);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALRST UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
			{
				CDB_delete_cmmscalrst(1, &CMMSCALRST);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALRST DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			if(TRS.get_procstep(in_node) == MP_STEP_CREATE || TRS.get_procstep(in_node) == MP_STEP_UPDATE)
			{
				CDB_init_cmmscalpln(&CMMSCALPLN);
				memcpy(CMMSCALPLN.FACTORY,  CMMSCALRST.FACTORY, sizeof(CMMSCALPLN.FACTORY));
				memcpy(CMMSCALPLN.EQUIP_ID,  CMMSCALRST.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID));
				TRS.copy(CMMSCALPLN.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE), item_list[i], "NEXT_PLAN_DATE");
				//memcpy(CMMSCALPLN.PLAN_DATE,  CMMSCALRST.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE));
				memcpy(CMMSCALPLN.CALI_DATE,  CMMSCALRST.CALI_DATE, sizeof(CMMSCALPLN.CALI_DATE));
				memcpy(CMMSCALPLN.CALI_INSTITUTE,  CMMSCALRST.CALI_INSTITUTE, sizeof(CMMSCALPLN.CALI_INSTITUTE));
				memcpy(CMMSCALPLN.CALI_METHOD,  CMMSCALRST.CALI_METHOD, sizeof(CMMSCALPLN.CALI_METHOD));
				CMMSCALPLN.CALI_RESULT = CMMSCALRST.CALI_RESULT;
				CMMSCALPLN.CALI_COST = CMMSCALRST.CALI_COST;
				if (CMMSCALRST.CALI_RESULT != ' ')
				{
					memcpy(CMMSCALPLN.CALI_STATUS,  "0", sizeof(CMMSCALPLN.CALI_STATUS));
				}
				else
				{
					memcpy(CMMSCALPLN.CALI_STATUS,  "1", sizeof(CMMSCALPLN.CALI_STATUS));
				}
				TRS.copy(CMMSCALPLN.UPDATE_USER_ID, sizeof(CMMSCALPLN.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSCALPLN.UPDATE_TIME, s_sys_time, sizeof(CMMSCALPLN.UPDATE_TIME));

				CDB_update_cmmscalpln(1, &CMMSCALPLN);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALPLN UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
	}
	else //Detail 화면에서 transaction이 발생 한 경우 (Create Or Update)
	{
		CDB_init_cmmscalrst(&CMMSCALRST);
		TRS.copy(CMMSCALRST.FACTORY, sizeof(CMMSCALRST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CMMSCALRST.CALI_ID, sizeof(CMMSCALRST.CALI_ID), in_node, "CALI_ID");
		TRS.copy(CMMSCALRST.EQUIP_ID, sizeof(CMMSCALRST.EQUIP_ID), in_node, "EQUIP_ID");
		TRS.copy(CMMSCALRST.PLAN_DATE, sizeof(CMMSCALRST.PLAN_DATE), in_node, "PLAN_DATE");
		TRS.copy(CMMSCALRST.CALI_DATE, sizeof(CMMSCALRST.CALI_DATE), in_node, "CALI_DATE");
		TRS.copy(CMMSCALRST.CALI_INSTITUTE, sizeof(CMMSCALRST.CALI_INSTITUTE), in_node, "CALI_INSTITUTE");
		TRS.copy(CMMSCALRST.CALI_METHOD, sizeof(CMMSCALRST.CALI_METHOD), in_node, "CALI_METHOD");
		CMMSCALRST.CALI_RESULT = TRS.get_char(in_node, "CALI_RESULT");
		CMMSCALRST.CALI_COST = TRS.get_double(in_node, "CALI_COST");
		TRS.copy(CMMSCALRST.CALI_DESC, sizeof(CMMSCALRST.CALI_DESC), in_node, "CALI_DESC");
		TRS.copy(CMMSCALRST.CALI_USER_ID, sizeof(CMMSCALRST.CALI_USER_ID), in_node, "CALI_USER_ID");
		TRS.copy(CMMSCALRST.FILE_NAME, sizeof(CMMSCALRST.FILE_NAME), in_node, "FILE_NAME");
		TRS.copy(CMMSCALRST.FILE_PATH, sizeof(CMMSCALRST.FILE_PATH), in_node, "FILE_PATH");
		TRS.copy(CMMSCALRST.RESULT_FILE_NAME, sizeof(CMMSCALRST.RESULT_FILE_NAME), in_node, "RESULT_FILE_NAME");
		TRS.copy(CMMSCALRST.RESULT_FILE_PATH, sizeof(CMMSCALRST.RESULT_FILE_PATH), in_node, "RESULT_FILE_PATH");
		CMMSCALRST.CONFIRM_FLAG = TRS.get_char(in_node, "CONFIRM_FLAG");
		TRS.copy(CMMSCALRST.CONFIRM_USER_ID, sizeof(CMMSCALRST.CONFIRM_USER_ID), in_node, "CONFIRM_USER_ID");
		TRS.copy(CMMSCALRST.CONFIRM_TIME, sizeof(CMMSCALRST.CONFIRM_TIME), in_node, "CONFIRM_TIME");
		TRS.copy(CMMSCALRST.CMF_1, sizeof(CMMSCALRST.CMF_1), in_node, "CMF_1");
		TRS.copy(CMMSCALRST.CMF_2, sizeof(CMMSCALRST.CMF_2), in_node, "CMF_2");
		TRS.copy(CMMSCALRST.CMF_3, sizeof(CMMSCALRST.CMF_3), in_node, "CMF_3");
		TRS.copy(CMMSCALRST.CMF_4, sizeof(CMMSCALRST.CMF_4), in_node, "CMF_4");
		TRS.copy(CMMSCALRST.CMF_5, sizeof(CMMSCALRST.CMF_5), in_node, "CMF_5");
		TRS.copy(CMMSCALRST.CMF_6, sizeof(CMMSCALRST.CMF_6), in_node, "CMF_6");
		TRS.copy(CMMSCALRST.CMF_7, sizeof(CMMSCALRST.CMF_7), in_node, "CMF_7");
		TRS.copy(CMMSCALRST.CMF_8, sizeof(CMMSCALRST.CMF_8), in_node, "CMF_8");
		TRS.copy(CMMSCALRST.CMF_9, sizeof(CMMSCALRST.CMF_9), in_node, "CMF_9");
		TRS.copy(CMMSCALRST.CMF_10, sizeof(CMMSCALRST.CMF_10), in_node, "CMF_10");
		TRS.copy(CMMSCALRST.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		TRS.copy(CMMSCALRST.CREATE_TIME, sizeof(CMMSCALRST.CREATE_TIME), in_node, "CREATE_TIME");
		TRS.copy(CMMSCALRST.UPDATE_USER_ID, sizeof(CMMSCALRST.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
		TRS.copy(CMMSCALRST.UPDATE_TIME, sizeof(CMMSCALRST.UPDATE_TIME), in_node, "UPDATE_TIME");

		if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
		{
			m_blob = TRSN.get_blob(in_node, "__BIN_DATA_1");
			if (m_blob.IS_NULL != 'Y')
			{
				memset(file_path, 0x00, sizeof(file_path));
				if (CMMS_set_attached_file(s_msg_code, "CMMSCALRST", TRS.get_string(in_node, "CALI_ID"), TRS.get_string(in_node, "FILE_NAME"), m_blob, file_path) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				memcpy(CMMSCALRST.FILE_PATH, file_path, sizeof(CMMSCALRST.FILE_PATH));
			}
		    //----[Addtional Logic for Create Case]----
		    TRS.copy(CMMSCALRST.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID), in_node, IN_USERID);
		    memcpy(CMMSCALRST.CREATE_TIME, s_sys_time, sizeof(CMMSCALRST.CREATE_TIME));
		    CDB_insert_cmmscalrst(&CMMSCALRST);
		    if(DB_error_code != DB_SUCCESS)
		    {
		        strcpy(s_msg_code, "MMS-0004");
		        TRS.add_fieldmsg(out_node, "CMMSCALRST INSERT", MP_NVST);
		        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
		        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
		        TRS.add_dberrmsg(out_node, DB_error_msg);

		        gs_log_type.type = MP_LOG_ERROR;
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        gs_log_type.category = MP_LOG_CATE_SETUP;

		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		        return MP_FALSE;
		    }
		}
		else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
		{
		    CDB_init_cmmscalrst(&CMMSCALRST_o);
		    TRS.copy(CMMSCALRST_o.FACTORY, sizeof(CMMSCALRST_o.FACTORY), in_node, IN_FACTORY);
		    TRS.copy(CMMSCALRST_o.CALI_ID, sizeof(CMMSCALRST_o.CALI_ID), in_node, "CALI_ID");
		    CDB_select_cmmscalrst_for_update(1, &CMMSCALRST_o);
		    if(DB_error_code != DB_SUCCESS)
		    {
		        strcpy(s_msg_code, "MMS-0004");
		        TRS.add_fieldmsg(out_node, "CMMSCALRST SELECT FOR UPDATE", MP_NVST);
		        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST_o.FACTORY), CMMSCALRST_o.FACTORY);
		        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST_o.CALI_ID), CMMSCALRST_o.CALI_ID);
		        TRS.add_dberrmsg(out_node, DB_error_msg);

		        gs_log_type.type = MP_LOG_ERROR;
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        gs_log_type.category = MP_LOG_CATE_SETUP;

		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		        return MP_FALSE;
		    }

		    //----[Addtional Logic for Update Case]----
			m_blob = TRSN.get_blob(in_node, "__BIN_DATA_1");
			if (m_blob.IS_NULL != 'Y')
			{
				memset(file_path, 0x00, sizeof(file_path));
				if (CMMS_set_attached_file(s_msg_code, "CMMSCALRST", TRS.get_string(in_node, "CALI_ID"), TRS.get_string(in_node, "FILE_NAME"), m_blob, file_path) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				memcpy(CMMSCALRST.FILE_PATH, file_path, sizeof(CMMSCALRST.FILE_PATH));
			}
		    memcpy(CMMSCALRST.CREATE_USER_ID, CMMSCALRST_o.CREATE_USER_ID, sizeof(CMMSCALRST.CREATE_USER_ID));
		    memcpy(CMMSCALRST.CREATE_TIME, CMMSCALRST_o.CREATE_TIME, sizeof(CMMSCALRST.CREATE_TIME));
		    TRS.copy(CMMSCALRST.UPDATE_USER_ID, sizeof(CMMSCALRST.UPDATE_USER_ID), in_node, IN_USERID);
		    memcpy(CMMSCALRST.UPDATE_TIME, s_sys_time, sizeof(CMMSCALRST.UPDATE_TIME));

		    CDB_update_cmmscalrst(1, &CMMSCALRST);
		    if(DB_error_code != DB_SUCCESS)
		    {
		        strcpy(s_msg_code, "MMS-0004");
		        TRS.add_fieldmsg(out_node, "CMMSCALRST UPDATE", MP_NVST);
		        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
		        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
		        TRS.add_dberrmsg(out_node, DB_error_msg);

		        gs_log_type.type = MP_LOG_ERROR;
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        gs_log_type.category = MP_LOG_CATE_SETUP;

		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		        return MP_FALSE;
		    }
		}
		else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
		{
		    CDB_delete_cmmscalrst(1, &CMMSCALRST);
		    if(DB_error_code != DB_SUCCESS)
		    {
		        strcpy(s_msg_code, "MMS-0004");
		        TRS.add_fieldmsg(out_node, "CMMSCALRST DELETE", MP_NVST);
		        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALRST.FACTORY), CMMSCALRST.FACTORY);
		        TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALRST.CALI_ID), CMMSCALRST.CALI_ID);
		        TRS.add_dberrmsg(out_node, DB_error_msg);

		        gs_log_type.type = MP_LOG_ERROR;
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        gs_log_type.category = MP_LOG_CATE_SETUP;

		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		        return MP_FALSE;
		    }
		}
	
		if(TRS.get_procstep(in_node) == MP_STEP_CREATE || TRS.get_procstep(in_node) == MP_STEP_UPDATE)
		{
			//측정 계획 Table UPDATE
			CDB_init_cmmscalpln(&CMMSCALPLN);
			memcpy(CMMSCALPLN.FACTORY,  CMMSCALRST.FACTORY, sizeof(CMMSCALPLN.FACTORY));
			memcpy(CMMSCALPLN.EQUIP_ID,  CMMSCALRST.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID));
			TRS.copy(CMMSCALPLN.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE), in_node, "NEXT_PLAN_DATE");
			//memcpy(CMMSCALPLN.PLAN_DATE,  CMMSCALRST.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE));
			memcpy(CMMSCALPLN.CALI_DATE,  CMMSCALRST.CALI_DATE, sizeof(CMMSCALPLN.CALI_DATE));
			memcpy(CMMSCALPLN.CALI_INSTITUTE,  CMMSCALRST.CALI_INSTITUTE, sizeof(CMMSCALPLN.CALI_INSTITUTE));
			memcpy(CMMSCALPLN.CALI_METHOD,  CMMSCALRST.CALI_METHOD, sizeof(CMMSCALPLN.CALI_METHOD));
			CMMSCALPLN.CALI_RESULT = CMMSCALRST.CALI_RESULT;
			CMMSCALPLN.CALI_COST = CMMSCALRST.CALI_COST;
			if (CMMSCALRST.CALI_RESULT != ' ')
			{
				memcpy(CMMSCALPLN.CALI_STATUS,  "0", sizeof(CMMSCALPLN.CALI_STATUS));
			}
			else
			{
				memcpy(CMMSCALPLN.CALI_STATUS,  "1", sizeof(CMMSCALPLN.CALI_STATUS));
			}
			TRS.copy(CMMSCALPLN.UPDATE_USER_ID, sizeof(CMMSCALPLN.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CMMSCALPLN.UPDATE_TIME, s_sys_time, sizeof(CMMSCALPLN.UPDATE_TIME));

			CDB_update_cmmscalpln(1, &CMMSCALPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSCALPLN UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		// 기준 측정기 처리 
		i_item_count = TRS.get_item_count(in_node, "CALIBRATION_EQUIP_LIST");
		item_list = TRS.get_list(in_node, "CALIBRATION_EQUIP_LIST");

		for(i = 0; i < i_item_count; i++)
        {
			CDB_init_cmmscaleqp(&CMMSCALEQP);
			memcpy(CMMSCALEQP.FACTORY, CMMSCALRST.FACTORY, sizeof(CMMSCALEQP.FACTORY));
			memcpy(CMMSCALEQP.CALI_ID, CMMSCALRST.CALI_ID, sizeof(CMMSCALEQP.CALI_ID));
			TRS.copy(CMMSCALEQP.EQUIP_ID, sizeof(CMMSCALEQP.EQUIP_ID), item_list[i], "STANDARD_EQUIP_ID");

			if (TRS.get_char(item_list[i], "IUD_FLAG") == MP_STEP_CREATE)
			{
				TRS.copy(CMMSCALEQP.CREATE_USER_ID, sizeof(CMMSCALEQP.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSCALEQP.CREATE_TIME, s_sys_time, sizeof(CMMSCALEQP.CREATE_TIME));
				CDB_insert_cmmscaleqp(&CMMSCALEQP);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALEQP INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else if (TRS.get_char(item_list[i], "IUD_FLAG") == MP_STEP_UPDATE)
			{
				TRS.copy(CMMSCALEQP.UPDATE_USER_ID, sizeof(CMMSCALEQP.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSCALEQP.UPDATE_TIME, s_sys_time, sizeof(CMMSCALEQP.UPDATE_TIME));
				CDB_update_cmmscaleqp(1, &CMMSCALEQP);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALEQP UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else if (TRS.get_char(item_list[i], "IUD_FLAG") == MP_STEP_DELETE)
			{
				CDB_delete_cmmscaleqp(1, &CMMSCALEQP);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALEQP DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALEQP.FACTORY), CMMSCALEQP.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALEQP.CALI_ID), CMMSCALEQP.CALI_ID);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALEQP.EQUIP_ID), CMMSCALEQP.EQUIP_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}

		//교정 결과 File 처리 
		i_item_count = TRS.get_item_count(in_node, "CALIBRATION_FILE_LIST");
		item_list = TRS.get_list(in_node, "CALIBRATION_FILE_LIST");

		for(i = 0; i < i_item_count; i++)
        {
			CDB_init_cmmscalfle(&CMMSCALFLE);
			memcpy(CMMSCALFLE.FACTORY, CMMSCALRST.FACTORY, sizeof(CMMSCALFLE.FACTORY));
			memcpy(CMMSCALFLE.CALI_ID, CMMSCALRST.CALI_ID, sizeof(CMMSCALFLE.CALI_ID));
			TRS.copy(CMMSCALFLE.FILE_NAME, sizeof(CMMSCALFLE.FILE_NAME), item_list[i], "FILE_NAME");

			if (TRS.get_int(item_list[i], "FILE_ORDER") < 1)
			{
				CMMSCALFLE.FILE_ORDER = (int)CDB_select_cmmscalfle_scalar(2, &CMMSCALFLE);
			}

			if (TRS.get_char(item_list[i], "IUD_FLAG") == MP_STEP_CREATE)
			{
				m_blob = TRSN.get_blob(in_node , TRS.get_string(item_list[i], "FILE_NAME"));
				if (m_blob.IS_NULL != 'Y')
				{
					memset(file_path, 0x00, sizeof(file_path));
					if (CMMS_set_attached_file(s_msg_code, "CMMSCALFLE", TRS.get_string(in_node, "CALI_ID"), TRS.get_string(item_list[i], "FILE_NAME"), m_blob, file_path) == MP_FALSE)
					{
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
					memcpy(CMMSCALFLE.FILE_PATH, file_path, sizeof(CMMSCALFLE.FILE_PATH));
				}

				TRS.copy(CMMSCALFLE.CREATE_USER_ID, sizeof(CMMSCALFLE.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSCALFLE.CREATE_TIME, s_sys_time, sizeof(CMMSCALFLE.CREATE_TIME));
				CDB_insert_cmmscalfle(&CMMSCALFLE);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALFLE INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALFLE.FACTORY), CMMSCALFLE.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALFLE.CALI_ID), CMMSCALFLE.CALI_ID);
					TRS.add_fieldmsg(out_node, "FILE_NAME", MP_STR, sizeof(CMMSCALFLE.FILE_NAME), CMMSCALFLE.FILE_NAME);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else if (TRS.get_char(item_list[i], "IUD_FLAG") == MP_STEP_UPDATE)
			{
				m_blob = TRSN.get_blob(item_list[i], TRS.get_string(item_list[i], "FILE_NAME"));
				if (m_blob.IS_NULL != 'Y')
				{
					memset(file_path, 0x00, sizeof(file_path));
					if (CMMS_set_attached_file(s_msg_code, "CMMSCALFLE", TRS.get_string(in_node, "CALI_ID"), TRS.get_string(item_list[i], "FILE_NAME"), m_blob, file_path) == MP_FALSE)
					{
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
					memcpy(CMMSCALFLE.FILE_PATH, file_path, sizeof(CMMSCALFLE.FILE_PATH));
				}

				TRS.copy(CMMSCALFLE.UPDATE_USER_ID, sizeof(CMMSCALFLE.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSCALFLE.UPDATE_TIME, s_sys_time, sizeof(CMMSCALFLE.UPDATE_TIME));
				CDB_update_cmmscalfle(1, &CMMSCALFLE);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALFLE UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALFLE.FACTORY), CMMSCALFLE.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALFLE.CALI_ID), CMMSCALFLE.CALI_ID);
					TRS.add_fieldmsg(out_node, "FILE_NAME", MP_STR, sizeof(CMMSCALFLE.FILE_NAME), CMMSCALFLE.FILE_NAME);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else if (TRS.get_char(item_list[i], "IUD_FLAG") == MP_STEP_DELETE)
			{
				CDB_delete_cmmscalfle(1, &CMMSCALFLE);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSCALFLE DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALFLE.FACTORY), CMMSCALFLE.FACTORY);
					TRS.add_fieldmsg(out_node, "CALI_ID", MP_STR, sizeof(CMMSCALFLE.CALI_ID), CMMSCALFLE.CALI_ID);
					TRS.add_fieldmsg(out_node, "FILE_NAME", MP_STR, sizeof(CMMSCALFLE.FILE_NAME), CMMSCALFLE.FILE_NAME);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
	}

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_Result_Registration",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Calibration_Result_Registration_Validation()
        - Main sub function of "CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION" function
        - Check the condition for create/update/delete Calibration_Result_Registration
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct CMMSCALRST_TAG CMMSCALRST;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
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

	if (TRS.get_char(in_node, "TRAN_STEP") != '1')
	{
		// * CALI_ID Validation */
		if(COM_isnullspace(TRS.get_string(in_node, "CALI_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "MMS-0001");
			TRS.add_fieldmsg(out_node, "CALI_ID", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

    return MP_TRUE;
}

