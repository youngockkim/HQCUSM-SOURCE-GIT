/******************************************************************************'

    System      : MESplus
    Module      : CAMS
    File Name   : CAMS_update_audit_result.c
    Description : Audit_Result Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CAMS_Update_Audit_Result()
            + Create/Update/Delete Audit_Result definition
        - CAMS_UPDATE_AUDIT_RESULT()
            + Main sub function of CAMS_Update_Audit_Result function
            + Create/Update/Delete Audit_Result definition
        - CAMS_Update_Audit_Result_Validation()
            + Main sub function of CAMS_UPDATE_AUDIT_RESULT function
            + Check the condition for create/update/delete Audit_Result
    Detail Description
        - CAMS_UPDATE_AUDIT_RESULT()
            + h_proc_step
                + MP_STEP_CREATE : Create Audit_Result definition
                + MP_STEP_UPDATE : Update Audit_Result definition
                + MP_STEP_DELETE : Delete Audit_Result definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-06-06             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CAMS_Update_Audit_Result_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CAMS_Update_Audit_Result()
        - Create/Update/Delete Audit_Result definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_Update_Audit_Result(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CAMS_UPDATE_AUDIT_RESULT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CAMS_UPDATE_AUDIT_RESULT", out_node);

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
    CAMS_UPDATE_AUDIT_RESULT()
        - Main sub function of "CAMS_Update_Audit_Result" function
        - Create/Update/Delete Audit_Result definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_UPDATE_AUDIT_RESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTRST_TAG CAMSADTRST;
    struct CAMSADTRST_TAG CAMSADTRST_o;
	struct CAMSADTPLN_TAG CAMSADTPLN;
	struct CAMSADTITM_TAG CAMSADTITM;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    char	s_sys_time[14];
	char	file_path[100];
	int		i;
	int		i_item_count;
	TRSNode **item_list;
	MBLOB	m_blob;

	char	c_status_flag = '2';
	char	c_action_flag = 'F';
	int		i_step;

	TRSNode* tran_in_node;
	char s_mail_user[2000];
	char s_tmp_mail[50];
	char s_mail_content[150];
	char s_tmp_content1[50];
	char s_tmp_audit_id[20];

    LOG_head("CAMS_UPDATE_CAMSCORE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("audit_id", MP_NSTR, TRS.get_string(in_node, "AUDIT_ID"));
    LOG_add("plan_date", MP_NSTR, TRS.get_string(in_node, "PLAN_DATE"));
    LOG_add("audit_date", MP_NSTR, TRS.get_string(in_node, "AUDIT_DATE"));
    LOG_add("result", MP_CHR, TRS.get_char(in_node, "RESULT"));
    LOG_add("status", MP_CHR, TRS.get_char(in_node, "STATUS"));
    LOG_add("action_date", MP_NSTR, TRS.get_string(in_node, "ACTION_DATE"));
    LOG_add("action_user_id", MP_NSTR, TRS.get_string(in_node, "ACTION_USER_ID"));
    LOG_add("action_result", MP_CHR, TRS.get_char(in_node, "ACTION_RESULT"));
    LOG_add("action_remark", MP_NSTR, TRS.get_string(in_node, "ACTION_REMARK"));
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
    if(COM_proc_user_routine("CAMS", "CAMS_Update_Audit_Result",
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

    if(CAMS_Update_Audit_Result_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	memset(s_tmp_audit_id, 0x00, sizeof(s_tmp_audit_id)); 

	// 감사 처리 결과 등록 시 CAMSADTRST Table의 STATUS_UPDATE를 위하여 ITEM 먼저 선 등록 
	if (TRS.get_procstep(in_node) == MP_STEP_UPDATE && TRS.get_char(in_node, "STEP_FLAG") == '3')
	{
		i_item_count = TRS.get_item_count(in_node, "ACTION_RESULT_ITEM");
		item_list = TRS.get_list(in_node, "ACTION_RESULT_ITEM");
		memset(s_mail_user, 0x00, sizeof(s_mail_user)); //2023.07.20 - Mail 기능 추가로 인한 수정
		for(i = 0; i < i_item_count; i++)
        {
			CDB_init_camsadtitm(&CAMSADTITM);
			TRS.copy(CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID), in_node, "AUDIT_ID");
			CAMSADTITM.SORT_ORDER = TRS.get_int(item_list[i], "SORT_ORDER");
			TRS.copy(CAMSADTITM.ACTION_DATE, sizeof(CAMSADTITM.ACTION_DATE), item_list[i], "ACTION_DATE");
			TRS.copy(CAMSADTITM.ACTION_USER_ID, sizeof(CAMSADTITM.ACTION_USER_ID), item_list[i], "ACTION_USER_ID");
			TRS.copy(CAMSADTITM.ACTION_FILE_NAME, sizeof(CAMSADTITM.ACTION_FILE_NAME), item_list[i], "ACTION_FILE_NAME");
			CAMSADTITM.ACTION_RESULT = TRS.get_char(item_list[i], "ACTION_RESULT");
			TRS.copy(CAMSADTITM.REMARKS, sizeof(CAMSADTITM.REMARKS), item_list[i], "REMARKS");
			CAMSADTITM.STATUS = TRS.get_char(in_node, "STATUS");
			//이미지 파일 저장 
			m_blob = TRSN.get_blob(item_list[i], TRS.get_string(item_list[i], "ACTION_FILE_NAME"));
			if (m_blob.IS_NULL != 'Y')
			{
				memset(file_path, 0x00, sizeof(file_path));
				if (CMMS_set_attached_file(s_msg_code, "CAMSACTITM", TRS.get_string(in_node, "AUDIT_ID"), TRS.get_string(item_list[i], "ACTION_FILE_NAME"), m_blob, file_path) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				memcpy(CAMSADTITM.ACTION_FILE_PATH, file_path, sizeof(CAMSADTITM.ACTION_FILE_PATH));
			}

			CDB_update_camsadtitm(2, &CAMSADTITM);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTITM UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
				TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		
		CDB_init_camsadtitm(&CAMSADTITM);
		TRS.copy(CAMSADTITM.FACTORY, sizeof(CAMSADTITM.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID), in_node, "AUDIT_ID");
		if(CDB_select_camsadtitm_scalar(2, &CAMSADTITM) == 0)
		{
			c_status_flag = '3';
			c_action_flag = 'P';
 		}	

		//2023.07.20 메일 전송 기능 추가
		//Action 등록일 경우에는 Managger에게 메일 발송
		CDB_init_camsadtpln(&CAMSADTPLN);
		memcpy(CAMSADTPLN.FACTORY, CAMSADTITM.FACTORY, sizeof(CAMSADTPLN.FACTORY));
		memcpy(CAMSADTPLN.AUDIT_ID, CAMSADTITM.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
		CDB_select_camsadtpln(1, &CAMSADTPLN);
		if(DB_error_code != DB_SUCCESS)
        {
			if(DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "CMN-0002");
			}
			else
			{
				strcpy(s_msg_code, "CMN-0003");			
			}
			
            TRS.add_fieldmsg(out_node, "CAMSADTPLN SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		memset(s_tmp_mail, 0x00, sizeof(s_tmp_mail)); 
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_MANAGER", strlen("AMS_MANAGER"));
		memcpy(MGCMTBLDAT.KEY_1, CAMSADTPLN.MANAGER_ID, sizeof(CAMSADTPLN.MANAGER_ID));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			COM_memcpy_add_null(s_tmp_mail, MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
			sprintf(s_mail_user + strlen(s_mail_user), "%s", s_tmp_mail);
		}
		COM_memcpy_add_null(s_tmp_audit_id, CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
	}
	
    CDB_init_camsadtrst(&CAMSADTRST);
    TRS.copy(CAMSADTRST.FACTORY, sizeof(CAMSADTRST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTRST.AUDIT_ID, sizeof(CAMSADTRST.AUDIT_ID), in_node, "AUDIT_ID");
    TRS.copy(CAMSADTRST.PLAN_DATE, sizeof(CAMSADTRST.PLAN_DATE), in_node, "PLAN_DATE");
    TRS.copy(CAMSADTRST.AUDIT_DATE, sizeof(CAMSADTRST.AUDIT_DATE), in_node, "AUDIT_DATE");
	CAMSADTRST.RESULT = TRS.get_char(in_node, "RESULT");
    CAMSADTRST.STATUS = TRS.get_char(in_node, "STATUS");
	TRS.copy(CAMSADTRST.ACTION_DATE, sizeof(CAMSADTRST.ACTION_DATE), in_node, "ACTION_DATE");
    TRS.copy(CAMSADTRST.ACTION_USER_ID, sizeof(CAMSADTRST.ACTION_USER_ID), in_node, "ACTION_USER_ID");
    CAMSADTRST.ACTION_RESULT = TRS.get_char(in_node, "ACTION_RESULT");
    TRS.copy(CAMSADTRST.ACTION_REMARK, sizeof(CAMSADTRST.ACTION_REMARK), in_node, "ACTION_REMARK");
    TRS.copy(CAMSADTRST.CMF_1, sizeof(CAMSADTRST.CMF_1), in_node, "CMF_1");
    TRS.copy(CAMSADTRST.CMF_2, sizeof(CAMSADTRST.CMF_2), in_node, "CMF_2");
    TRS.copy(CAMSADTRST.CMF_3, sizeof(CAMSADTRST.CMF_3), in_node, "CMF_3");
    TRS.copy(CAMSADTRST.CMF_4, sizeof(CAMSADTRST.CMF_4), in_node, "CMF_4");
    TRS.copy(CAMSADTRST.CMF_5, sizeof(CAMSADTRST.CMF_5), in_node, "CMF_5");
    TRS.copy(CAMSADTRST.CMF_6, sizeof(CAMSADTRST.CMF_6), in_node, "CMF_6");
    TRS.copy(CAMSADTRST.CMF_7, sizeof(CAMSADTRST.CMF_7), in_node, "CMF_7");
    TRS.copy(CAMSADTRST.CMF_8, sizeof(CAMSADTRST.CMF_8), in_node, "CMF_8");
    TRS.copy(CAMSADTRST.CMF_9, sizeof(CAMSADTRST.CMF_9), in_node, "CMF_9");
    TRS.copy(CAMSADTRST.CMF_10, sizeof(CAMSADTRST.CMF_10), in_node, "CMF_10");
    TRS.copy(CAMSADTRST.CREATE_USER_ID, sizeof(CAMSADTRST.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CAMSADTRST.CREATE_TIME, sizeof(CAMSADTRST.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CAMSADTRST.UPDATE_USER_ID, sizeof(CAMSADTRST.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CAMSADTRST.UPDATE_TIME, sizeof(CAMSADTRST.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----
        TRS.copy(CAMSADTRST.CREATE_USER_ID, sizeof(CAMSADTRST.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CAMSADTRST.CREATE_TIME, s_sys_time, sizeof(CAMSADTRST.CREATE_TIME));
        CDB_insert_camsadtrst(&CAMSADTRST);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CAMS-0004");
            TRS.add_fieldmsg(out_node, "CAMSADTRST INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);
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
        CDB_init_camsadtrst(&CAMSADTRST_o);
        TRS.copy(CAMSADTRST_o.FACTORY, sizeof(CAMSADTRST_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CAMSADTRST_o.AUDIT_ID, sizeof(CAMSADTRST_o.AUDIT_ID), in_node, "AUDIT_ID");
        CDB_select_camsadtrst_for_update(1, &CAMSADTRST_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTRST SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST_o.FACTORY), CAMSADTRST_o.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST_o.AUDIT_ID), CAMSADTRST_o.AUDIT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----
		CAMSADTRST.STATUS = c_status_flag;
		CAMSADTRST.ACTION_RESULT = c_action_flag;
		//TRS.copy(CAMSADTRST.ACTION_DATE, sizeof(CAMSADTRST.ACTION_DATE), in_node, "ACTION_DATE");
		TRS.copy(CAMSADTRST.ACTION_USER_ID, sizeof(CAMSADTRST.ACTION_USER_ID), in_node, IN_USERID);
        memcpy(CAMSADTRST.CREATE_USER_ID, CAMSADTRST_o.CREATE_USER_ID, sizeof(CAMSADTRST.CREATE_USER_ID));
        memcpy(CAMSADTRST.CREATE_TIME, CAMSADTRST_o.CREATE_TIME, sizeof(CAMSADTRST.CREATE_TIME));
        TRS.copy(CAMSADTRST.UPDATE_USER_ID, sizeof(CAMSADTRST.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CAMSADTRST.UPDATE_TIME, s_sys_time, sizeof(CAMSADTRST.UPDATE_TIME));
		
		//이미지 파일 저장 
		m_blob = TRSN.get_blob(in_node, MP_BIN_DATA_1);
		if (m_blob.IS_NULL != 'Y')
		{
			memset(file_path, 0x00, sizeof(file_path));
			if (CMMS_set_attached_file(s_msg_code, "CAMSADTRST", TRS.get_string(in_node, "AUDIT_ID"), TRS.get_string(in_node, "CMF_1"), m_blob, file_path) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			memcpy(CAMSADTRST.CMF_2, file_path, sizeof(CAMSADTRST.CMF_2));
		}
		else
		{
			memcpy(CAMSADTRST.CMF_1, CAMSADTRST_o.CMF_1, sizeof(CAMSADTRST.CMF_1));
			memcpy(CAMSADTRST.CMF_2, CAMSADTRST_o.CMF_2, sizeof(CAMSADTRST.CMF_2));
		}

		if(TRS.get_char(in_node, "STEP_FLAG") == '3')
		{
			CDB_update_camsadtrst(2, &CAMSADTRST);
		}
		else if(TRS.get_char(in_node, "STEP_FLAG") == '4')
		{
			CDB_update_camsadtrst(3, &CAMSADTRST);
		}
		else
		{
			CDB_update_camsadtrst(1, &CAMSADTRST);
		}
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTRST UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		if (TRS.get_char(in_node, "STEP_FLAG") != '3' && TRS.get_char(in_node, "STEP_FLAG") != '4') //완료시 파일 첨부 기능 추가로 인한 수정
		{
			/* Delete Audit Items */
			CDB_init_camsadtitm(&CAMSADTITM);
			memcpy(CAMSADTITM.FACTORY, CAMSADTRST.FACTORY, sizeof(CAMSADTITM.FACTORY));
			memcpy(CAMSADTITM.AUDIT_ID, CAMSADTRST.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
			CDB_delete_camsadtitm(1, &CAMSADTITM);
			if(DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "CMN-0003");
					TRS.add_fieldmsg(out_node, "CAMSADTITM DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
					TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
					TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
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
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        CDB_delete_camsadtrst(1, &CAMSADTRST);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CAMSADTRST DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		/* Plan Teble Recovery  */
		CDB_init_camsadtpln(&CAMSADTPLN);
		memcpy(CAMSADTPLN.FACTORY, CAMSADTRST.FACTORY, sizeof(CAMSADTPLN.FACTORY));
		memcpy(CAMSADTPLN.AUDIT_ID, CAMSADTRST.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
		memset(CAMSADTPLN.AUDIT_DATE, ' ', sizeof(CAMSADTPLN.AUDIT_DATE));
		CAMSADTPLN.STATUS = '0';
		TRS.copy(CAMSADTPLN.UPDATE_USER_ID, sizeof(CAMSADTPLN.UPDATE_USER_ID), in_node, IN_USERID);
		memcpy(CAMSADTPLN.UPDATE_TIME, s_sys_time, sizeof(CAMSADTPLN.UPDATE_TIME));

		CDB_update_camsadtpln(2, &CAMSADTPLN);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "CMN-0003");
			TRS.add_fieldmsg(out_node, "CAMSADTPLN UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
			TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/* Delete Audit Items */
		CDB_init_camsadtitm(&CAMSADTITM);
		memcpy(CAMSADTITM.FACTORY, CAMSADTRST.FACTORY, sizeof(CAMSADTITM.FACTORY));
		memcpy(CAMSADTITM.AUDIT_ID, CAMSADTRST.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
		CDB_delete_camsadtitm(1, &CAMSADTITM);
        if(DB_error_code != DB_SUCCESS)
        {
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTITM DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
				TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
				TRS.add_fieldmsg(out_node, "SORT_ORDER", MP_INT, CAMSADTITM.SORT_ORDER);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
        }
    }

	if (TRS.get_procstep(in_node) != MP_STEP_DELETE && TRS.get_char(in_node, "STEP_FLAG") != '4')  //완료시 파일 첨부 기능 추가로 인한 수정)
	{
		/* Plan Teble Update  */
		CDB_init_camsadtpln(&CAMSADTPLN);
		memcpy(CAMSADTPLN.FACTORY, CAMSADTRST.FACTORY, sizeof(CAMSADTPLN.FACTORY));
		memcpy(CAMSADTPLN.AUDIT_ID, CAMSADTRST.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID));
		memcpy(CAMSADTPLN.AUDIT_DATE, CAMSADTRST.AUDIT_DATE, sizeof(CAMSADTPLN.AUDIT_DATE));
		CAMSADTPLN.STATUS = CAMSADTRST.STATUS;
		TRS.copy(CAMSADTPLN.UPDATE_USER_ID, sizeof(CAMSADTPLN.UPDATE_USER_ID), in_node, IN_USERID);
		memcpy(CAMSADTPLN.UPDATE_TIME, s_sys_time, sizeof(CAMSADTPLN.UPDATE_TIME));

		if(TRS.get_char(in_node, "STEP_FLAG") == '3')
		{
			CDB_update_camsadtpln(3, &CAMSADTPLN);
		}
		else
		{
			CDB_update_camsadtpln(2, &CAMSADTPLN);
		}		
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "CMN-0003");
			TRS.add_fieldmsg(out_node, "CAMSADTPLN UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
			TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	if(TRS.get_procstep(in_node) != MP_STEP_DELETE && TRS.get_char(in_node, "STEP_FLAG") != '3' && TRS.get_char(in_node, "STEP_FLAG") != '4')  //완료시 파일 첨부 기능 추가로 인한 수정)
	{
		i_item_count = TRS.get_item_count(in_node, "AUDIT_RESULT_ITEM");
		item_list = TRS.get_list(in_node, "AUDIT_RESULT_ITEM");
		memset(s_mail_user, 0x00, sizeof(s_mail_user)); //2023.07.20 - Mail 기능 추가로 인한 수정

		for(i = 0; i < i_item_count; i++)
        {
            CDB_init_camsadtitm(&CAMSADTITM);
			memcpy(CAMSADTITM.FACTORY, CAMSADTRST.FACTORY, sizeof(CAMSADTITM.FACTORY));
			memcpy(CAMSADTITM.AUDIT_ID, CAMSADTRST.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
			CAMSADTITM.SORT_ORDER = TRS.get_int(item_list[i], "SORT_ORDER");
			TRS.copy(CAMSADTITM.ITEM_DIVISION, sizeof(CAMSADTITM.ITEM_DIVISION), item_list[i], "ITEM_DIVISION");
			TRS.copy(CAMSADTITM.ITEM_NAME, sizeof(CAMSADTITM.ITEM_NAME), item_list[i], "ITEM_NAME");		
			TRS.copy(CAMSADTITM.CHECK_DETAIL, sizeof(CAMSADTITM.CHECK_DETAIL), item_list[i], "CHECK_DETAIL");
			CAMSADTITM.CHECK_RESULT = TRS.get_char(item_list[i], "CHECK_RESULT");
			TRS.copy(CAMSADTITM.FILE_NAME, sizeof(CAMSADTITM.FILE_NAME), item_list[i], "FILE_NAME");
			TRS.copy(CAMSADTITM.ACTION_MGR_ID, sizeof(CAMSADTITM.ACTION_MGR_ID), item_list[i], "ACTION_MGR_ID");
			TRS.copy(CAMSADTITM.ACTION_LIMIT_DATE, sizeof(CAMSADTITM.ACTION_LIMIT_DATE), item_list[i], "ACTION_LIMIT_DATE");
			CAMSADTITM.STATUS = TRS.get_char(in_node, "STATUS");
			
			//이미지 파일 저장 
			m_blob = TRSN.get_blob(item_list[i], TRS.get_string(item_list[i], "FILE_NAME"));
			if (m_blob.IS_NULL != 'Y')
			{
				memset(file_path, 0x00, sizeof(file_path));
				if (CMMS_set_attached_file(s_msg_code, "CAMSADTITM", TRS.get_string(in_node, "AUDIT_ID"), TRS.get_string(item_list[i], "FILE_NAME"), m_blob, file_path) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				memcpy(CAMSADTITM.FILE_PATH, file_path, sizeof(CAMSADTITM.FILE_PATH));
			}
			CDB_insert_camsadtitm(&CAMSADTITM);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CMN-0003");
				TRS.add_fieldmsg(out_node, "CAMSADTITM INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTITM.FACTORY), CAMSADTITM.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CAMSADTITM.AUDIT_ID), CAMSADTITM.AUDIT_ID);
				TRS.add_fieldmsg(out_node, "FILE_NAME", MP_STR, sizeof(CAMSADTITM.FILE_NAME), CAMSADTITM.FILE_NAME);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//2023.07.20 - Mail 기능 추가로 인한 수정
			memset(s_tmp_mail, 0x00, sizeof(s_tmp_mail)); 
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_USER", strlen("AMS_USER"));
			memcpy(MGCMTBLDAT.KEY_1, CAMSADTITM.ACTION_MGR_ID, sizeof(CAMSADTITM.ACTION_MGR_ID));
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				COM_memcpy_add_null(s_tmp_mail, MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
				sprintf(s_mail_user + strlen(s_mail_user), "%s;", s_tmp_mail);
			}
			COM_memcpy_add_null(s_tmp_audit_id, CAMSADTITM.AUDIT_ID, sizeof(CAMSADTITM.AUDIT_ID));
		}
	}

	//2023.07.20 - Mail 보내기 추가 
	if (COM_isnullspace(s_mail_user) == MP_FALSE && TRS.get_char(in_node, "STEP_FLAG") != '4')  //완료시 파일 첨부 기능 추가로 인한 수정)
	{
		
		memset(s_mail_content, 0x00, sizeof(s_mail_content)); 
		memset(s_tmp_content1, 0x00, sizeof(s_tmp_content1)); 
		
		tran_in_node = TRS.create_node("SEND_MAIL_IN");
		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", 'I');
		//TRS.add_string(tran_in_node,  "CREATE_TIME", s_sys_time, sizeof(s_sys_time)); 
		TRS.add_string(tran_in_node, "ALARM_USER",s_mail_user, strlen(s_mail_user));

		i_step = 110;
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "AMS_MAIL_INFO", strlen("AMS_MAIL_INFO"));		
		if(TRS.get_char(in_node, "STEP_FLAG") == '3')
		{
			memcpy(MGCMTBLDAT.KEY_1, "ACTION", strlen("ACTION"));
		}
		else
		{
			memcpy(MGCMTBLDAT.KEY_1, "RESULT", strlen("RESULT"));
		}

		DBC_open_mgcmtbldat(i_step, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "CMN-0003");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			TRS.free_node(tran_in_node);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			DBC_fetch_mgcmtbldat(i_step, &MGCMTBLDAT);
			if(DB_error_code == DB_NOT_FOUND)
			{
				DBC_close_mgcmtbldat(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				DBC_close_mgcmtbldat(i_step);

				TRS.free_node(tran_in_node);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			if (memcmp(MGCMTBLDAT.KEY_2, "ALARM_ID", strlen("ALARM_ID")) == 0)
			{
				TRS.add_string(tran_in_node, "ALARM_ID", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
			else if(memcmp(MGCMTBLDAT.KEY_2, "SUBJECT", strlen("SUBJECT")) == 0)
			{
				TRS.add_string(tran_in_node, "ALARM_SUBJECT", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
			else if (memcmp(MGCMTBLDAT.KEY_2, "CONTENT", strlen("CONTENT")) == 0)
			{
				COM_memcpy_add_null(s_mail_content, MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

				sprintf(s_tmp_content1, "<br>&nbsp;Please check the audit id : %s", s_tmp_audit_id);

				strcat(s_mail_content, s_tmp_content1);				

				TRS.add_nstring(tran_in_node, "ALARM_MSG", s_mail_content);
			}
			else
			{
				TRS.add_string(tran_in_node, "ALARM_COMMENT_1", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
		}

		if(CBAS_SEND_MAIL_MANUAL(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

        TRS.free_node(tran_in_node);
	}

    /* Not use in customizing
    if(COM_proc_user_routine("CAMS", "CAMS_Update_Audit_Result",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CAMS_Update_Audit_Result_Validation()
        - Main sub function of "CAMS_UPDATE_AUDIT_RESULT" function
        - Check the condition for create/update/delete Audit_Result
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CAMS_Update_Audit_Result_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CAMSADTRST_TAG CAMSADTRST;
    struct MWIPFACDEF_TAG MWIPFACDEF;
	struct CAMSADTPLN_TAG CAMSADTPLN;

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
        strcpy(s_msg_code, "CMN-0002");
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

    /* AUDIT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "AUDIT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_camsadtrst(&CAMSADTRST);
    TRS.copy(CAMSADTRST.FACTORY, sizeof(CAMSADTRST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CAMSADTRST.AUDIT_ID, sizeof(CAMSADTRST.AUDIT_ID), in_node, "AUDIT_ID");
    CDB_select_camsadtrst(1, &CAMSADTRST);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0018");
            TRS.add_fieldmsg(out_node, "CAMSADTRST SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		CDB_init_camsadtpln(&CAMSADTPLN);
		TRS.copy(CAMSADTPLN.FACTORY, sizeof(CAMSADTPLN.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CAMSADTPLN.AUDIT_ID, sizeof(CAMSADTPLN.AUDIT_ID), in_node, "AUDIT_ID");
		CDB_select_camsadtpln(1, &CAMSADTPLN);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "CMN-0018");
			}
			else
			{
				strcpy(s_msg_code, "CMN-0003");
			}			
			TRS.add_fieldmsg(out_node, "CAMSADTPLN SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTPLN.FACTORY), CAMSADTPLN.FACTORY);
			TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTPLN.AUDIT_ID), CAMSADTPLN.AUDIT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		TRS.set_string(in_node, "PLAN_DATE", CAMSADTPLN.PLAN_DATE, sizeof(CAMSADTPLN.PLAN_DATE));

    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "CMN-0004");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CMN-0003");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CAMSADTRST SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CAMSADTRST.FACTORY), CAMSADTRST.FACTORY);
            TRS.add_fieldmsg(out_node, "AUDIT_ID", MP_STR, sizeof(CAMSADTRST.AUDIT_ID), CAMSADTRST.AUDIT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

