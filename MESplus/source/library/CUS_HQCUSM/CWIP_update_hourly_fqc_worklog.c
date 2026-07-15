/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_hourly_fqc_worklog.c
    Description : Hourly_Fqc_Worklog Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Hourly_Fqc_Worklog()
            + Create/Update/Delete Hourly_Fqc_Worklog definition
        - CWIP_UPDATE_HOURLY_FQC_WORKLOG()
            + Main sub function of CWIP_Update_Hourly_Fqc_Worklog function
            + Create/Update/Delete Hourly_Fqc_Worklog definition
        - CWIP_Update_Hourly_Fqc_Worklog_Validation()
            + Main sub function of CWIP_UPDATE_HOURLY_FQC_WORKLOG function
            + Check the condition for create/update/delete Hourly_Fqc_Worklog
    Detail Description
        - CWIP_UPDATE_HOURLY_FQC_WORKLOG()
            + h_proc_step
                + MP_STEP_CREATE : Create Hourly_Fqc_Worklog definition
                + MP_STEP_UPDATE : Update Hourly_Fqc_Worklog definition
                + MP_STEP_DELETE : Delete Hourly_Fqc_Worklog definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024-01-17             Create by Generator

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Hourly_Fqc_Worklog_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Hourly_Fqc_Worklog()
        - Create/Update/Delete Hourly_Fqc_Worklog definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Hourly_Fqc_Worklog(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_HOURLY_FQC_WORKLOG(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_HOURLY_FQC_WORKLOG", out_node);

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
    CWIP_UPDATE_HOURLY_FQC_WORKLOG()
        - Main sub function of "CWIP_Update_Hourly_Fqc_Worklog" function
        - Create/Update/Delete Hourly_Fqc_Worklog definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_HOURLY_FQC_WORKLOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPHURFQC_TAG CWIPHURFQC;
    struct CWIPHURFQC_TAG CWIPHURFQC_o;
    char   s_sys_time[14];
	int    i_step = 1;
	int    iSeq = 0;
	int    iHisSeq = 0;

    LOG_head("CWIP_UPDATE_HOURLY_FQC_WORKLOG");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("factory", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("befe_type", MP_NSTR, TRS.get_string(in_node, "BEFE_TYPE"));
    LOG_add("siml_type", MP_NSTR, TRS.get_string(in_node, "SIML_TYPE"));
    LOG_add("work_time", MP_NSTR, TRS.get_string(in_node, "WORK_TIME"));
    LOG_add("hist_seq", MP_INT, TRS.get_int(in_node, "HIST_SEQ"));
    LOG_add("pic_name", MP_NSTR, TRS.get_string(in_node, "PIC_NAME"));
    LOG_add("machine_no", MP_NSTR, TRS.get_string(in_node, "MACHINE_NO"));
    LOG_add("defect_code", MP_NSTR, TRS.get_string(in_node, "DEFECT_CODE"));
    LOG_add("defect_detail", MP_NSTR, TRS.get_string(in_node, "DEFECT_DETAIL"));
    LOG_add("root_cause", MP_NSTR, TRS.get_string(in_node, "ROOT_CAUSE"));
    LOG_add("action_plan", MP_NSTR, TRS.get_string(in_node, "ACTION_PLAN"));
    LOG_add("monitoring_result", MP_NSTR, TRS.get_string(in_node, "MONITORING_RESULT"));
    //LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    //LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    //LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    //LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    //LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    //LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    //LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    //LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    //LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    //LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strncpy(s_msg_code, "CMN-0003", strlen("CMN-0003"));
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(CWIP_Update_Hourly_Fqc_Worklog_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiphurfqc(&CWIPHURFQC);
    TRS.copy(CWIPHURFQC.FACTORY, sizeof(CWIPHURFQC.FACTORY), in_node, "FACTORY");
    TRS.copy(CWIPHURFQC.LINE_ID, sizeof(CWIPHURFQC.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPHURFQC.WORK_SHIFT, sizeof(CWIPHURFQC.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPHURFQC.WORK_DATE, sizeof(CWIPHURFQC.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPHURFQC.BEFE_TYPE, sizeof(CWIPHURFQC.BEFE_TYPE), in_node, "BEFE_TYPE");
    TRS.copy(CWIPHURFQC.SIML_TYPE, sizeof(CWIPHURFQC.SIML_TYPE), in_node, "SIML_TYPE");
    TRS.copy(CWIPHURFQC.WORK_TIME, sizeof(CWIPHURFQC.WORK_TIME), in_node, "WORK_TIME");
    TRS.copy(CWIPHURFQC.PIC_NAME, sizeof(CWIPHURFQC.PIC_NAME), in_node, "PIC_NAME");
    TRS.copy(CWIPHURFQC.MACHINE_NO, sizeof(CWIPHURFQC.MACHINE_NO), in_node, "MACHINE_NO");
    TRS.copy(CWIPHURFQC.DEFECT_CODE, sizeof(CWIPHURFQC.DEFECT_CODE), in_node, "DEFECT_CODE");
    TRS.copy(CWIPHURFQC.DEFECT_DETAIL, sizeof(CWIPHURFQC.DEFECT_DETAIL), in_node, "DEFECT_DETAIL");
    TRS.copy(CWIPHURFQC.ROOT_CAUSE, sizeof(CWIPHURFQC.ROOT_CAUSE), in_node, "ROOT_CAUSE");
    TRS.copy(CWIPHURFQC.ACTION_PLAN, sizeof(CWIPHURFQC.ACTION_PLAN), in_node, "ACTION_PLAN");
    TRS.copy(CWIPHURFQC.ACTION_STTM, sizeof(CWIPHURFQC.ACTION_STTM), in_node, "ACTION_STTM");
    TRS.copy(CWIPHURFQC.ACTION_EDTM, sizeof(CWIPHURFQC.ACTION_EDTM), in_node, "ACTION_EDTM");
    TRS.copy(CWIPHURFQC.MONITORING_RESULT, sizeof(CWIPHURFQC.MONITORING_RESULT), in_node, "MONITORING_RESULT");
    TRS.copy(CWIPHURFQC.CMF_1, sizeof(CWIPHURFQC.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPHURFQC.CMF_2, sizeof(CWIPHURFQC.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPHURFQC.CMF_3, sizeof(CWIPHURFQC.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPHURFQC.CMF_4, sizeof(CWIPHURFQC.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPHURFQC.CMF_5, sizeof(CWIPHURFQC.CMF_5), in_node, "CMF_5");
    TRS.copy(CWIPHURFQC.CMF_6, sizeof(CWIPHURFQC.CMF_6), in_node, "CMF_6");
    TRS.copy(CWIPHURFQC.CMF_7, sizeof(CWIPHURFQC.CMF_7), in_node, "CMF_7");
    TRS.copy(CWIPHURFQC.CMF_8, sizeof(CWIPHURFQC.CMF_8), in_node, "CMF_8");
    TRS.copy(CWIPHURFQC.CMF_9, sizeof(CWIPHURFQC.CMF_9), in_node, "CMF_9");
    TRS.copy(CWIPHURFQC.CMF_10, sizeof(CWIPHURFQC.CMF_10), in_node, "CMF_10");
    TRS.copy(CWIPHURFQC.CREATE_USER_ID, sizeof(CWIPHURFQC.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPHURFQC.CREATE_TIME, sizeof(CWIPHURFQC.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPHURFQC.UPDATE_USER_ID, sizeof(CWIPHURFQC.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPHURFQC.UPDATE_TIME, sizeof(CWIPHURFQC.UPDATE_TIME), in_node, "UPDATE_TIME");
	
	if ( TRS.get_int(in_node, "HIST_SEQ") != 0x00 ) 
	{
		CWIPHURFQC.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
	} else {
		CWIPHURFQC.HIST_SEQ = 0;
	}


	i_step = 2;
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
		iHisSeq = CDB_select_cwiphurfqc_scalar(i_step, &CWIPHURFQC);
		if(DB_error_code != DB_SUCCESS)
		{
            strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CWIPHURFQC INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPHURFQC.FACTORY), CWIPHURFQC.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPHURFQC.LINE_ID), CWIPHURFQC.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPHURFQC.WORK_SHIFT), CWIPHURFQC.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPHURFQC.WORK_DATE), CWIPHURFQC.WORK_DATE);
			TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_STR, sizeof(CWIPHURFQC.HIST_SEQ), CWIPHURFQC.HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
		CWIPHURFQC.HIST_SEQ = iHisSeq + 1;

        TRS.copy(CWIPHURFQC.CREATE_USER_ID, sizeof(CWIPHURFQC.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPHURFQC.CREATE_TIME, s_sys_time, sizeof(CWIPHURFQC.CREATE_TIME));
        CDB_insert_cwiphurfqc(&CWIPHURFQC);
        if(DB_error_code != DB_SUCCESS)
        {
            strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CWIPHURFQC INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPHURFQC.FACTORY), CWIPHURFQC.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPHURFQC.LINE_ID), CWIPHURFQC.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPHURFQC.WORK_SHIFT), CWIPHURFQC.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPHURFQC.WORK_DATE), CWIPHURFQC.WORK_DATE);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPHURFQC.HIST_SEQ);
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
		i_step = 1;
        CDB_init_cwiphurfqc(&CWIPHURFQC_o);
        TRS.copy(CWIPHURFQC_o.FACTORY, sizeof(CWIPHURFQC_o.FACTORY), in_node, "FACTORY");
        TRS.copy(CWIPHURFQC_o.LINE_ID, sizeof(CWIPHURFQC_o.LINE_ID), in_node, "LINE_ID");
        TRS.copy(CWIPHURFQC_o.WORK_SHIFT, sizeof(CWIPHURFQC_o.WORK_SHIFT), in_node, "WORK_SHIFT");
        TRS.copy(CWIPHURFQC_o.WORK_DATE, sizeof(CWIPHURFQC_o.WORK_DATE), in_node, "WORK_DATE");
        CWIPHURFQC_o.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
        CDB_select_cwiphurfqc_for_update(1, &CWIPHURFQC_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CWIPHURFQC SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPHURFQC_o.FACTORY), CWIPHURFQC_o.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPHURFQC_o.LINE_ID), CWIPHURFQC_o.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPHURFQC_o.WORK_SHIFT), CWIPHURFQC_o.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPHURFQC_o.WORK_DATE), CWIPHURFQC_o.WORK_DATE);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPHURFQC_o.HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        } 
		
		TRS.copy(CWIPHURFQC.UPDATE_USER_ID, sizeof(CWIPHURFQC.UPDATE_USER_ID), in_node, IN_USERID);
		memcpy(CWIPHURFQC.UPDATE_TIME, s_sys_time, sizeof(CWIPHURFQC.UPDATE_TIME));

		CDB_update_cwiphurfqc(1, &CWIPHURFQC);
		if(DB_error_code != DB_SUCCESS)
		{
			strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
			TRS.add_fieldmsg(out_node, "CWIPHURFQC UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPHURFQC_o.FACTORY), CWIPHURFQC_o.FACTORY);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPHURFQC.LINE_ID), CWIPHURFQC.LINE_ID);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPHURFQC.WORK_SHIFT), CWIPHURFQC.WORK_SHIFT);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPHURFQC.WORK_DATE), CWIPHURFQC.WORK_DATE);
			TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPHURFQC.HIST_SEQ);
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
        CDB_delete_cwiphurfqc(1, &CWIPHURFQC);
        if(DB_error_code != DB_SUCCESS)
        {
            strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CWIPHURFQC DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPHURFQC_o.FACTORY), CWIPHURFQC_o.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPHURFQC.LINE_ID), CWIPHURFQC.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPHURFQC.WORK_SHIFT), CWIPHURFQC.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPHURFQC.WORK_DATE), CWIPHURFQC.WORK_DATE);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPHURFQC.HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Hourly_Fqc_Worklog",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_Hourly_Fqc_Worklog_Validation()
        - Main sub function of "CWIP_UPDATE_HOURLY_FQC_WORKLOG" function
        - Check the condition for create/update/delete Hourly_Fqc_Worklog
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Hourly_Fqc_Worklog_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPHURFQC_TAG CWIPHURFQC;
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
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
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
        strncpy(s_msg_code, "WIP-0005",strlen("WIP-0005"));
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_SHIFT Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* BEFE_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "BEFE_TYPE")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "BEFE_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* SIML_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SIML_TYPE")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "SIML_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_TIME Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_TIME")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "WORK_TIME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
 

    return MP_TRUE;
}

