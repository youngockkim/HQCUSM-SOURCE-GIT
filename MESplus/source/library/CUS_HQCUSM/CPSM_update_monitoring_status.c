/******************************************************************************'

    System      : MESplus
    Module      : CPSM
    File Name   : CPSM_update_monitoring_status.c
    Description : Monitoring_Status Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CPSM_Update_Monitoring_Status()
            + Create/Update/Delete Monitoring_Status definition
        - CPSM_UPDATE_MONITORING_STATUS()
            + Main sub function of CPSM_Update_Monitoring_Status function
            + Create/Update/Delete Monitoring_Status definition
        - CPSM_Update_Monitoring_Status_Validation()
            + Main sub function of CPSM_UPDATE_MONITORING_STATUS function
            + Check the condition for create/update/delete Monitoring_Status
    Detail Description
        - CPSM_UPDATE_MONITORING_STATUS()
            + h_proc_step
                + MP_STEP_CREATE : Create Monitoring_Status definition
                + MP_STEP_UPDATE : Update Monitoring_Status definition
                + MP_STEP_DELETE : Delete Monitoring_Status definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/10/02             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CPSM_Update_Monitoring_Status_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CPSM_Update_Monitoring_Status()
        - Create/Update/Delete Monitoring_Status definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_Update_Monitoring_Status(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CPSM_UPDATE_MONITORING_STATUS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CPSM_UPDATE_MONITORING_STATUS", out_node);

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
    CPSM_UPDATE_MONITORING_STATUS()
        - Main sub function of "CPSM_Update_Monitoring_Status" function
        - Create/Update/Delete Monitoring_Status definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_UPDATE_MONITORING_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CPSMMNTSTS_TAG CPSMMNTSTS;
    //struct CPSMMNTSTS_TAG CPSMMNTSTS_o;
    char   s_sys_time[14];
	int	   i_case;

    LOG_head("CPSM_UPDATE_MONITORING_STATUS");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("category", MP_NSTR, TRS.get_string(in_node, "CATEGORY"));
    LOG_add("base_code", MP_NSTR, TRS.get_string(in_node, "BASE_CODE"));
    LOG_add("sub_code", MP_NSTR, TRS.get_string(in_node, "SUB_CODE"));
    LOG_add("description", MP_NSTR, TRS.get_string(in_node, "DESCRIPTION"));
    LOG_add("print_check", MP_CHR, TRS.get_char(in_node, "PRINT_CHECK"));
    LOG_add("tran_user_id", MP_NSTR, TRS.get_string(in_node, "TRAN_USER_ID"));
    LOG_add("status", MP_NSTR, TRS.get_string(in_node, "STATUS"));
    LOG_add("status_msg", MP_NSTR, TRS.get_string(in_node, "STATUS_MSG"));
    LOG_add("client_version", MP_NSTR, TRS.get_string(in_node, "CLIENT_VERSION"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CPSM", "CPSM_Update_Monitoring_Status",
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

    if(CPSM_Update_Monitoring_Status_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	i_case = 1;

    CDB_init_cpsmmntsts(&CPSMMNTSTS);
    TRS.copy(CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY), in_node, "CATEGORY");
    TRS.copy(CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE), in_node, "BASE_CODE");
    TRS.copy(CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE), in_node, "SUB_CODE");
    CDB_select_cpsmmntsts(1, &CPSMMNTSTS);
	if(DB_error_code == DB_SUCCESS)
    {
		if(TRS.get_procstep(in_node) == '1') //OI Client 인 경우
		{
			i_case = 2;
			TRS.copy(CPSMMNTSTS.TRAN_USER_ID, sizeof(CPSMMNTSTS.TRAN_USER_ID), in_node, IN_USERID);
			TRS.copy(CPSMMNTSTS.CLIENT_VERSION, sizeof(CPSMMNTSTS.CLIENT_VERSION), in_node, "CLIENT_VERSION");
			//Printer Status에 값이 존재하는 경우 
			if(COM_isnullspace(TRS.get_string(in_node, "STATUS")) == MP_FALSE)
			{
				TRS.copy(CPSMMNTSTS.STATUS, sizeof(CPSMMNTSTS.STATUS), in_node, "STATUS");
				TRS.copy(CPSMMNTSTS.STATUS_MSG, sizeof(CPSMMNTSTS.STATUS_MSG), in_node, "STATUS_MSG");
			}

			//Setup Date Return 
			TRS.add_string(out_node, "FACTORY", CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY));
			TRS.add_string(out_node, "CATEGORY", CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY));
			TRS.add_string(out_node, "BASE_CODE", CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE));
			TRS.add_string(out_node, "SUB_CODE", CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE));
			TRS.add_string(out_node, "DESCRIPTION", CPSMMNTSTS.DESCRIPTION, sizeof(CPSMMNTSTS.DESCRIPTION));
			TRS.add_char(out_node, "PRINT_CHECK", CPSMMNTSTS.PRINT_CHECK);
			TRS.add_char(out_node, "STATUS_CHECK", 'Y');
		}

		//Last Tran Time Update
		memcpy(CPSMMNTSTS.LAST_TRAN_TIME, s_sys_time, sizeof(CPSMMNTSTS.LAST_TRAN_TIME));
		TRS.copy(CPSMMNTSTS.UPDATE_USER_ID, sizeof(CPSMMNTSTS.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CPSMMNTSTS.UPDATE_TIME, s_sys_time, sizeof(CPSMMNTSTS.UPDATE_TIME));
		CDB_update_cpsmmntsts(i_case, &CPSMMNTSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CPSMMNTSTS UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}

    /* Not use in customizing
    if(COM_proc_user_routine("CPSM", "CPSM_Update_Monitoring_Status",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CPSM_Update_Monitoring_Status_Validation()
        - Main sub function of "CPSM_UPDATE_MONITORING_STATUS" function
        - Check the condition for create/update/delete Monitoring_Status
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_Update_Monitoring_Status_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123") == MP_FALSE)
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

    /* CATEGORY Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CATEGORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "CATEGORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* BASE_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "BASE_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "BASE_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* SUB_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SUB_CODE")) == MP_TRUE)
    {
       TRS.set_nstring(in_node, "SUB_CODE", " ");
    }
	
    return MP_TRUE;
}

