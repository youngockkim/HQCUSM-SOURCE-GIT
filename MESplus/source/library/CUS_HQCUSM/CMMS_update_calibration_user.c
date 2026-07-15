/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_calibration_user.c
    Description : Calibration_User Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Calibration_User()
            + Create/Update/Delete Calibration_User definition
        - CMMS_UPDATE_CALIBRATION_USER()
            + Main sub function of CMMS_Update_Calibration_User function
            + Create/Update/Delete Calibration_User definition
        - CMMS_Update_Calibration_User_Validation()
            + Main sub function of CMMS_UPDATE_CALIBRATION_USER function
            + Check the condition for create/update/delete Calibration_User
    Detail Description
        - CMMS_UPDATE_CALIBRATION_USER()
            + h_proc_step
                + MP_STEP_CREATE : Create Calibration_User definition
                + MP_STEP_UPDATE : Update Calibration_User definition
                + MP_STEP_DELETE : Delete Calibration_User definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Calibration_user_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Calibration_User()
        - Create/Update/Delete Calibration_User definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_user(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_CALIBRATION_USER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_CALIBRATION_USER", out_node);

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
    CMMS_UPDATE_CALIBRATION_USER()
        - Main sub function of "CMMS_Update_Calibration_User" function
        - Create/Update/Delete Calibration_User definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_CALIBRATION_USER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSUSRDEF_TAG CMMSUSRDEF;
    struct CMMSUSRDEF_TAG CMMSUSRDEF_o;
    char   s_sys_time[14];

	char   file_path[100];
    MBLOB  m_blob;

    LOG_head("CMMS_UPDATE_CALIBRATION_USER");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("user_id", MP_NSTR, TRS.get_string(in_node, "USER_ID"));
    LOG_add("user_name", MP_NSTR, TRS.get_string(in_node, "USER_NAME"));
    LOG_add("file_name", MP_NSTR, TRS.get_string(in_node, "FILE_NAME"));
    LOG_add("file_path", MP_NSTR, TRS.get_string(in_node, "FILE_PATH"));
    LOG_add("expiry_date", MP_NSTR, TRS.get_string(in_node, "EXPIRY_DATE"));
    LOG_add("cali_flag", MP_CHR, TRS.get_char(in_node, "CALI_FLAG"));
    LOG_add("msa_flag", MP_CHR, TRS.get_char(in_node, "MSA_FLAG"));
    LOG_add("use_flag", MP_CHR, TRS.get_char(in_node, "USE_FLAG"));
	LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_User",
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

    if(CMMS_Update_Calibration_user_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	if(TRS.get_procstep(in_node) == MP_STEP_CREATE || TRS.get_procstep(in_node) == MP_STEP_UPDATE)
	{
		if(COM_isnullspace(TRS.get_string(in_node, "FILE_NAME")) != MP_TRUE)
		{	
			m_blob = TRSN.get_blob(in_node, MP_BIN_DATA_1);
			if (m_blob.IS_NULL != 'Y')
			{
				memset(file_path, 0x00, sizeof(file_path));
				if (CMMS_set_attached_file(s_msg_code, "CMMSUSRDEF", TRS.get_string(in_node, "USER_ID"), TRS.get_string(in_node, "FILE_NAME"), m_blob, file_path) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				TRS.set_string(in_node, "FILE_PATH", file_path, sizeof(file_path));
			}
		}
	}
    CDB_init_cmmsusrdef(&CMMSUSRDEF);
	TRS.copy(CMMSUSRDEF.FACTORY, sizeof(CMMSUSRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID), in_node, "USER_ID");
    TRS.copy(CMMSUSRDEF.USER_NAME, sizeof(CMMSUSRDEF.USER_NAME), in_node, "USER_NAME");
    TRS.copy(CMMSUSRDEF.FILE_NAME, sizeof(CMMSUSRDEF.FILE_NAME), in_node, "FILE_NAME");
    TRS.copy(CMMSUSRDEF.FILE_PATH, sizeof(CMMSUSRDEF.FILE_PATH), in_node, "FILE_PATH");
    TRS.copy(CMMSUSRDEF.EXPIRY_DATE, sizeof(CMMSUSRDEF.EXPIRY_DATE), in_node, "EXPIRY_DATE");
    CMMSUSRDEF.CALI_FLAG = TRS.get_char(in_node, "CALI_FLAG");
    CMMSUSRDEF.MSA_FLAG = TRS.get_char(in_node, "MSA_FLAG");
    CMMSUSRDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
	 TRS.copy(CMMSUSRDEF.CMF_1, sizeof(CMMSUSRDEF.CMF_1), in_node, "CMF_1");
    TRS.copy(CMMSUSRDEF.CMF_2, sizeof(CMMSUSRDEF.CMF_2), in_node, "CMF_2");
    TRS.copy(CMMSUSRDEF.CMF_3, sizeof(CMMSUSRDEF.CMF_3), in_node, "CMF_3");
    TRS.copy(CMMSUSRDEF.CMF_4, sizeof(CMMSUSRDEF.CMF_4), in_node, "CMF_4");
    TRS.copy(CMMSUSRDEF.CMF_5, sizeof(CMMSUSRDEF.CMF_5), in_node, "CMF_5");
    TRS.copy(CMMSUSRDEF.CREATE_USER_ID, sizeof(CMMSUSRDEF.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSUSRDEF.CREATE_TIME, sizeof(CMMSUSRDEF.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSUSRDEF.UPDATE_USER_ID, sizeof(CMMSUSRDEF.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSUSRDEF.UPDATE_TIME, sizeof(CMMSUSRDEF.UPDATE_TIME), in_node, "UPDATE_TIME");
	
	//-- File 처리 부분 추가 해야 함.... 
    
	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMSUSRDEF.CREATE_USER_ID, sizeof(CMMSUSRDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSUSRDEF.CREATE_TIME, s_sys_time, sizeof(CMMSUSRDEF.CREATE_TIME));
        CDB_insert_cmmsusrdef(&CMMSUSRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSUSRDEF INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSUSRDEF.FACTORY), CMMSUSRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
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
        CDB_init_cmmsusrdef(&CMMSUSRDEF_o);
		TRS.copy(CMMSUSRDEF_o.FACTORY, sizeof(CMMSUSRDEF_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSUSRDEF_o.USER_ID, sizeof(CMMSUSRDEF_o.USER_ID), in_node, "USER_ID");
        CDB_select_cmmsusrdef_for_update(1, &CMMSUSRDEF_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSUSRDEF SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSUSRDEF_o.FACTORY), CMMSUSRDEF_o.FACTORY);
            TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF_o.USER_ID), CMMSUSRDEF_o.USER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CMMSUSRDEF.CREATE_USER_ID, CMMSUSRDEF_o.CREATE_USER_ID, sizeof(CMMSUSRDEF.CREATE_USER_ID));
        memcpy(CMMSUSRDEF.CREATE_TIME, CMMSUSRDEF_o.CREATE_TIME, sizeof(CMMSUSRDEF.CREATE_TIME));
        TRS.copy(CMMSUSRDEF.UPDATE_USER_ID, sizeof(CMMSUSRDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSUSRDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSUSRDEF.UPDATE_TIME));

        CDB_update_cmmsusrdef(1, &CMMSUSRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSUSRDEF UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSUSRDEF.FACTORY), CMMSUSRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
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
        CDB_delete_cmmsusrdef(1, &CMMSUSRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSUSRDEF DELETE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSUSRDEF.FACTORY), CMMSUSRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_User",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Calibration_user_Validation()
        - Main sub function of "CMMS_UPDATE_CALIBRATION_USER" function
        - Check the condition for create/update/delete Calibration_User
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_user_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSUSRDEF_TAG CMMSUSRDEF;
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

    /* USER_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "USER_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "USER_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsusrdef(&CMMSUSRDEF);
	TRS.copy(CMMSUSRDEF.FACTORY, sizeof(CMMSUSRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID), in_node, "USER_ID");
    CDB_select_cmmsusrdef(1, &CMMSUSRDEF);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0010");
            TRS.add_fieldmsg(out_node, "CMMSUSRDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSUSRDEF.FACTORY), CMMSUSRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
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

            TRS.add_fieldmsg(out_node, "CMMSUSRDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

