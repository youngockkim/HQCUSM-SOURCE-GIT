/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_calibration_plan.c
    Description : Calibration_Plan Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Calibration_Plan()
            + Create/Update/Delete Calibration_Plan definition
        - CMMS_UPDATE_CALIBRATION_PLAN()
            + Main sub function of CMMS_Update_Calibration_Plan function
            + Create/Update/Delete Calibration_Plan definition
        - CMMS_Update_Calibration_Plan_Validation()
            + Main sub function of CMMS_UPDATE_CALIBRATION_PLAN function
            + Check the condition for create/update/delete Calibration_Plan
    Detail Description
        - CMMS_UPDATE_CALIBRATION_PLAN()
            + h_proc_step
                + MP_STEP_CREATE : Create Calibration_Plan definition
                + MP_STEP_UPDATE : Update Calibration_Plan definition
                + MP_STEP_DELETE : Delete Calibration_Plan definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-29             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Calibration_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Calibration_Plan()
        - Create/Update/Delete Calibration_Plan definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_Plan(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_CALIBRATION_PLAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_CALIBRATION_PLAN", out_node);

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
    CMMS_UPDATE_CALIBRATION_PLAN()
        - Main sub function of "CMMS_Update_Calibration_Plan" function
        - Create/Update/Delete Calibration_Plan definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_CALIBRATION_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALPLN_TAG CMMSCALPLN;
    struct CMMSCALPLN_TAG CMMSCALPLN_o;
    char   s_sys_time[14];

	char   file_path[100];
    MBLOB  m_blob;

    LOG_head("CMMS_UPDATE_CALIBRATION_PLAN");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    LOG_add("plan_date", MP_NSTR, TRS.get_string(in_node, "PLAN_DATE"));
    LOG_add("cali_date", MP_NSTR, TRS.get_string(in_node, "CALI_DATE"));
    LOG_add("cali_institute", MP_NSTR, TRS.get_string(in_node, "CALI_INSTITUTE"));
    LOG_add("cali_method", MP_NSTR, TRS.get_string(in_node, "CALI_METHOD"));
    LOG_add("cali_result", MP_CHR, TRS.get_char(in_node, "CALI_RESULT"));
    LOG_add("cali_cost", MP_DBL, TRS.get_double(in_node, "CALI_COST"));
    LOG_add("cali_status", MP_NSTR, TRS.get_string(in_node, "CALI_STATUS"));
    LOG_add("file_name", MP_NSTR, TRS.get_string(in_node, "FILE_NAME"));
    LOG_add("file_path", MP_NSTR, TRS.get_string(in_node, "FILE_PATH"));
    LOG_add("alarm_flag", MP_CHR, TRS.get_char(in_node, "ALARM_FLAG"));
    LOG_add("alarm_code", MP_NSTR, TRS.get_string(in_node, "ALARM_CODE"));
    LOG_add("alarm_period", MP_INT, TRS.get_int(in_node, "ALARM_PERIOD"));
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
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_Plan",
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

    if(CMMS_Update_Calibration_Plan_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// File 저장 처리 
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


    CDB_init_cmmscalpln(&CMMSCALPLN);
    TRS.copy(CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID), in_node, "EQUIP_ID");
    TRS.copy(CMMSCALPLN.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE), in_node, "PLAN_DATE");
    TRS.copy(CMMSCALPLN.CALI_DATE, sizeof(CMMSCALPLN.CALI_DATE), in_node, "CALI_DATE");
    TRS.copy(CMMSCALPLN.CALI_INSTITUTE, sizeof(CMMSCALPLN.CALI_INSTITUTE), in_node, "CALI_INSTITUTE");
    TRS.copy(CMMSCALPLN.CALI_METHOD, sizeof(CMMSCALPLN.CALI_METHOD), in_node, "CALI_METHOD");
    CMMSCALPLN.CALI_RESULT = TRS.get_char(in_node, "CALI_RESULT");
    CMMSCALPLN.CALI_COST = TRS.get_double(in_node, "CALI_COST");
    TRS.copy(CMMSCALPLN.CALI_STATUS, sizeof(CMMSCALPLN.CALI_STATUS), in_node, "CALI_STATUS");
    TRS.copy(CMMSCALPLN.FILE_NAME, sizeof(CMMSCALPLN.FILE_NAME), in_node, "FILE_NAME");
    TRS.copy(CMMSCALPLN.FILE_PATH, sizeof(CMMSCALPLN.FILE_PATH), in_node, "FILE_PATH");
    CMMSCALPLN.ALARM_FLAG = TRS.get_char(in_node, "ALARM_FLAG");
    TRS.copy(CMMSCALPLN.ALARM_CODE, sizeof(CMMSCALPLN.ALARM_CODE), in_node, "ALARM_CODE");
    CMMSCALPLN.ALARM_PERIOD = TRS.get_int(in_node, "ALARM_PERIOD");
    TRS.copy(CMMSCALPLN.CMF_1, sizeof(CMMSCALPLN.CMF_1), in_node, "CMF_1");
    TRS.copy(CMMSCALPLN.CMF_2, sizeof(CMMSCALPLN.CMF_2), in_node, "CMF_2");
    TRS.copy(CMMSCALPLN.CMF_3, sizeof(CMMSCALPLN.CMF_3), in_node, "CMF_3");
    TRS.copy(CMMSCALPLN.CMF_4, sizeof(CMMSCALPLN.CMF_4), in_node, "CMF_4");
    TRS.copy(CMMSCALPLN.CMF_5, sizeof(CMMSCALPLN.CMF_5), in_node, "CMF_5");
    TRS.copy(CMMSCALPLN.CMF_6, sizeof(CMMSCALPLN.CMF_6), in_node, "CMF_6");
    TRS.copy(CMMSCALPLN.CMF_7, sizeof(CMMSCALPLN.CMF_7), in_node, "CMF_7");
    TRS.copy(CMMSCALPLN.CMF_8, sizeof(CMMSCALPLN.CMF_8), in_node, "CMF_8");
    TRS.copy(CMMSCALPLN.CMF_9, sizeof(CMMSCALPLN.CMF_9), in_node, "CMF_9");
    TRS.copy(CMMSCALPLN.CMF_10, sizeof(CMMSCALPLN.CMF_10), in_node, "CMF_10");
    TRS.copy(CMMSCALPLN.CREATE_USER_ID, sizeof(CMMSCALPLN.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSCALPLN.CREATE_TIME, sizeof(CMMSCALPLN.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSCALPLN.UPDATE_USER_ID, sizeof(CMMSCALPLN.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSCALPLN.UPDATE_TIME, sizeof(CMMSCALPLN.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_char(in_node, "PROC_STEP") == MP_STEP_CREATE)
    {
        //----[Addtional Logic for Create Case]----
        TRS.copy(CMMSCALPLN.CREATE_USER_ID, sizeof(CMMSCALPLN.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSCALPLN.CREATE_TIME, s_sys_time, sizeof(CMMSCALPLN.CREATE_TIME));
        CDB_insert_cmmscalpln(&CMMSCALPLN);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALPLN INSERT", MP_NVST);
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
    else if(TRS.get_char(in_node, "PROC_STEP") == MP_STEP_UPDATE)
    {
        CDB_init_cmmscalpln(&CMMSCALPLN_o);
        TRS.copy(CMMSCALPLN_o.FACTORY, sizeof(CMMSCALPLN_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSCALPLN_o.EQUIP_ID, sizeof(CMMSCALPLN_o.EQUIP_ID), in_node, "EQUIP_ID");
        CDB_select_cmmscalpln_for_update(1, &CMMSCALPLN_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALPLN SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN_o.FACTORY), CMMSCALPLN_o.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN_o.EQUIP_ID), CMMSCALPLN_o.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CMMSCALPLN.CREATE_USER_ID, CMMSCALPLN_o.CREATE_USER_ID, sizeof(CMMSCALPLN.CREATE_USER_ID));
        memcpy(CMMSCALPLN.CREATE_TIME, CMMSCALPLN_o.CREATE_TIME, sizeof(CMMSCALPLN.CREATE_TIME));
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
    else if(TRS.get_char(in_node, "PROC_STEP") == MP_STEP_DELETE)
    {
        CDB_delete_cmmscalpln(1, &CMMSCALPLN);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALPLN DELETE", MP_NVST);
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

	

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Calibration_Plan",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Calibration_Plan_Validation()
        - Main sub function of "CMMS_UPDATE_CALIBRATION_PLAN" function
        - Check the condition for create/update/delete Calibration_Plan
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Calibration_Plan_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALPLN_TAG CMMSCALPLN;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    ///* ProcStep Validation */
    //if(COM_service_validation(s_msg_code,
    //                          in_node,
    //                          out_node,
    //                          TRS.get_procstep(in_node),
    //                          "1IUD") == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

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

    /* EQUIP_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "EQUIP_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmscalpln(&CMMSCALPLN);
    TRS.copy(CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID), in_node, "EQUIP_ID");
    CDB_select_cmmscalpln(1, &CMMSCALPLN);
	if(DB_error_code == DB_SUCCESS)
    {
		TRS.add_char(in_node, "PROC_STEP", MP_STEP_UPDATE);
	}
	else
	{
		if(DB_error_code == DB_NOT_FOUND)
        {
			TRS.add_char(in_node, "PROC_STEP", MP_STEP_CREATE);
		}
		else
		{
			strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALPLN SELECT", MP_NVST);
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

    return MP_TRUE;
}

