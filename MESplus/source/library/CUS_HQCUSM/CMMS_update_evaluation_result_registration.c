/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_evaluation_result_registration.c
    Description : Evaluation_Result_Registration Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Evaluation_Result_Registration()
            + Create/Update/Delete Evaluation_Result_Registration definition
        - CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION()
            + Main sub function of CMMS_Update_Evaluation_Result_Registration function
            + Create/Update/Delete Evaluation_Result_Registration definition
        - CMMS_Update_Evaluation_Result_Registration_Validation()
            + Main sub function of CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION function
            + Check the condition for create/update/delete Evaluation_Result_Registration
    Detail Description
        - CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION()
            + h_proc_step
                + MP_STEP_CREATE : Create Evaluation_Result_Registration definition
                + MP_STEP_UPDATE : Update Evaluation_Result_Registration definition
                + MP_STEP_DELETE : Delete Evaluation_Result_Registration definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-03             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Evaluation_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Evaluation_Result_Registration()
        - Create/Update/Delete Evaluation_Result_Registration definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Evaluation_Result_Registration(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION", out_node);

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
    CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION()
        - Main sub function of "CMMS_Update_Evaluation_Result_Registration" function
        - Create/Update/Delete Evaluation_Result_Registration definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMYEARES_TAG CMMYEARES;
    struct CMMYEARES_TAG CMMYEARES_o;
    char   s_sys_time[14];

	char   file_path[100];
    MBLOB  m_blob;

    LOG_head("CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("doc_id", MP_NSTR, TRS.get_string(in_node, "DOC_ID"));
    LOG_add("result_year", MP_INT, TRS.get_int(in_node, "RESULT_YEAR"));
    LOG_add("result_type", MP_NSTR, TRS.get_string(in_node, "RESULT_TYPE"));
    LOG_add("ana_div", MP_CHR, TRS.get_char(in_node, "ANA_DIV"));
    LOG_add("dept_code", MP_CHR, TRS.get_string(in_node, "DEPT_CODE"));
    LOG_add("file_name", MP_NSTR, TRS.get_string(in_node, "FILE_NAME"));
    LOG_add("file_path", MP_NSTR, TRS.get_string(in_node, "FILE_PATH"));
    LOG_add("pf_flag", MP_CHR, TRS.get_char(in_node, "PF_FLAG"));
    LOG_add("comments", MP_NSTR, TRS.get_string(in_node, "COMMENTS"));
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
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Evaluation_Result_Registration",
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

    if(CMMS_Update_Evaluation_Result_Registration_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmyeares(&CMMYEARES);
    TRS.copy(CMMYEARES.FACTORY, sizeof(CMMYEARES.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMYEARES.DOC_ID, sizeof(CMMYEARES.DOC_ID), in_node, "DOC_ID");
    CMMYEARES.RESULT_YEAR = TRS.get_int(in_node, "RESULT_YEAR");
    TRS.copy(CMMYEARES.RESULT_TYPE, sizeof(CMMYEARES.RESULT_TYPE), in_node, "RESULT_TYPE");
    CMMYEARES.ANA_DIV = TRS.get_char(in_node, "ANA_DIV");
	TRS.copy(CMMYEARES.DEPT_CODE, sizeof(CMMYEARES.DEPT_CODE), in_node, "DEPT_CODE");
    TRS.copy(CMMYEARES.FILE_NAME, sizeof(CMMYEARES.FILE_NAME), in_node, "FILE_NAME");
    TRS.copy(CMMYEARES.FILE_PATH, sizeof(CMMYEARES.FILE_PATH), in_node, "FILE_PATH");
    CMMYEARES.PF_FLAG = TRS.get_char(in_node, "PF_FLAG");
    TRS.copy(CMMYEARES.COMMENTS, sizeof(CMMYEARES.COMMENTS), in_node, "COMMENTS");
    TRS.copy(CMMYEARES.CMF_1, sizeof(CMMYEARES.CMF_1), in_node, "CMF_1");
    TRS.copy(CMMYEARES.CMF_2, sizeof(CMMYEARES.CMF_2), in_node, "CMF_2");
    TRS.copy(CMMYEARES.CMF_3, sizeof(CMMYEARES.CMF_3), in_node, "CMF_3");
    TRS.copy(CMMYEARES.CMF_4, sizeof(CMMYEARES.CMF_4), in_node, "CMF_4");
    TRS.copy(CMMYEARES.CMF_5, sizeof(CMMYEARES.CMF_5), in_node, "CMF_5");
    TRS.copy(CMMYEARES.CMF_6, sizeof(CMMYEARES.CMF_6), in_node, "CMF_6");
    TRS.copy(CMMYEARES.CMF_7, sizeof(CMMYEARES.CMF_7), in_node, "CMF_7");
    TRS.copy(CMMYEARES.CMF_8, sizeof(CMMYEARES.CMF_8), in_node, "CMF_8");
    TRS.copy(CMMYEARES.CMF_9, sizeof(CMMYEARES.CMF_9), in_node, "CMF_9");
    TRS.copy(CMMYEARES.CMF_10, sizeof(CMMYEARES.CMF_10), in_node, "CMF_10");
    TRS.copy(CMMYEARES.CREATE_USER_ID, sizeof(CMMYEARES.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMYEARES.CREATE_TIME, sizeof(CMMYEARES.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMYEARES.UPDATE_USER_ID, sizeof(CMMYEARES.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMYEARES.UPDATE_TIME, sizeof(CMMYEARES.UPDATE_TIME), in_node, "UPDATE_TIME");

	// File 저장 선 처리 
	if (TRS.get_char(in_node, "PROC_STEP") == MP_STEP_CREATE || TRS.get_char(in_node, "PROC_STEP") == MP_STEP_UPDATE)
	{
		if(COM_isnullspace(TRS.get_string(in_node, "FILE_NAME")) != MP_TRUE)
		{	
			m_blob = TRSN.get_blob(in_node, MP_BIN_DATA_1);
			if (m_blob.IS_NULL != 'Y')
			{
				memset(file_path, 0x00, sizeof(file_path));
				if (CMMS_set_attached_file(s_msg_code, "CMMSCALPLN", TRS.get_string(in_node, "EQUIP_ID"), TRS.get_string(in_node, "FILE_NAME"), m_blob, file_path) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				TRS.set_string(in_node, "FILE_PATH", file_path, sizeof(file_path));
			}
		}
	}

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMYEARES.CREATE_USER_ID, sizeof(CMMYEARES.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMYEARES.CREATE_TIME, s_sys_time, sizeof(CMMYEARES.CREATE_TIME));
        CDB_insert_cmmyeares(&CMMYEARES);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMYEARES INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES.FACTORY), CMMYEARES.FACTORY);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES.DOC_ID), CMMYEARES.DOC_ID);
            TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES.RESULT_YEAR);
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
        CDB_init_cmmyeares(&CMMYEARES_o);
        TRS.copy(CMMYEARES_o.FACTORY, sizeof(CMMYEARES_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMYEARES_o.DOC_ID, sizeof(CMMYEARES_o.DOC_ID), in_node, "DOC_ID");
        CMMYEARES_o.RESULT_YEAR = TRS.get_int(in_node, "RESULT_YEAR");
        CDB_select_cmmyeares_for_update(1, &CMMYEARES_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMYEARES SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES_o.FACTORY), CMMYEARES_o.FACTORY);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES_o.DOC_ID), CMMYEARES_o.DOC_ID);
            TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES_o.RESULT_YEAR);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CMMYEARES.CREATE_USER_ID, CMMYEARES_o.CREATE_USER_ID, sizeof(CMMYEARES.CREATE_USER_ID));
        memcpy(CMMYEARES.CREATE_TIME, CMMYEARES_o.CREATE_TIME, sizeof(CMMYEARES.CREATE_TIME));
        TRS.copy(CMMYEARES.UPDATE_USER_ID, sizeof(CMMYEARES.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMYEARES.UPDATE_TIME, s_sys_time, sizeof(CMMYEARES.UPDATE_TIME));

        CDB_update_cmmyeares(1, &CMMYEARES);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMYEARES UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES.FACTORY), CMMYEARES.FACTORY);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES.DOC_ID), CMMYEARES.DOC_ID);
            TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES.RESULT_YEAR);
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
        CDB_delete_cmmyeares(1, &CMMYEARES);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMYEARES DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES.FACTORY), CMMYEARES.FACTORY);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES.DOC_ID), CMMYEARES.DOC_ID);
            TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES.RESULT_YEAR);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Evaluation_Result_Registration",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Evaluation_Result_Registration_Validation()
        - Main sub function of "CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION" function
        - Check the condition for create/update/delete Evaluation_Result_Registration
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Evaluation_Result_Registration_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMYEARES_TAG CMMYEARES;
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

    /* DOC_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "DOC_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "DOC_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* RESULT_YEAR Validation */
    if(TRS.get_int(in_node, "RESULT_YEAR") == 0)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmyeares(&CMMYEARES);
    TRS.copy(CMMYEARES.FACTORY, sizeof(CMMYEARES.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMYEARES.DOC_ID, sizeof(CMMYEARES.DOC_ID), in_node, "DOC_ID");
    CMMYEARES.RESULT_YEAR = TRS.get_int(in_node, "RESULT_YEAR");
    CDB_select_cmmyeares(1, &CMMYEARES);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMYEARES SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES.FACTORY), CMMYEARES.FACTORY);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES.DOC_ID), CMMYEARES.DOC_ID);
            TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES.RESULT_YEAR);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
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

            TRS.add_fieldmsg(out_node, "CMMYEARES SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES.FACTORY), CMMYEARES.FACTORY);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES.DOC_ID), CMMYEARES.DOC_ID);
            TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES.RESULT_YEAR);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

