/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_tb_cleaning_schedule.c
    Description : Tb_Cleaning_Schedule Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Tb_Cleaning_Schedule()
            + Create/Update/Delete Tb_Cleaning_Schedule definition
        - CWIP_UPDATE_TB_CLEANING_SCHEDULE()
            + Main sub function of CWIP_Update_Tb_Cleaning_Schedule function
            + Create/Update/Delete Tb_Cleaning_Schedule definition
        - CWIP_Update_Tb_Cleaning_Schedule_Validation()
            + Main sub function of CWIP_UPDATE_TB_CLEANING_SCHEDULE function
            + Check the condition for create/update/delete Tb_Cleaning_Schedule
    Detail Description
        - CWIP_UPDATE_TB_CLEANING_SCHEDULE()
            + h_proc_step
                + MP_STEP_CREATE : Create Tb_Cleaning_Schedule definition
                + MP_STEP_UPDATE : Update Tb_Cleaning_Schedule definition
                + MP_STEP_DELETE : Delete Tb_Cleaning_Schedule definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/08/27             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_Update_Tb_Cleaning_Schedule_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Tb_Cleaning_Schedule()
        - Create/Update/Delete Tb_Cleaning_Schedule definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Tb_Cleaning_Schedule(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_TB_CLEANING_SCHEDULE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_TB_CLEANING_SCHEDULE", out_node);

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
    CWIP_UPDATE_TB_CLEANING_SCHEDULE()
        - Main sub function of "CWIP_Update_Tb_Cleaning_Schedule" function
        - Create/Update/Delete Tb_Cleaning_Schedule definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_TB_CLEANING_SCHEDULE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASTBRCLN_TAG CRASTBRCLN;
    struct CRASTBRCLN_TAG CRASTBRCLN_o;
    char   s_sys_time[14];

    LOG_head("CWIP_UPDATE_TB_CLEANING_SCHEDULE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("clng_date", MP_NSTR, TRS.get_string(in_node, "CLNG_DATE"));
    LOG_add("clng_time", MP_NSTR, TRS.get_string(in_node, "CLNG_TIME"));
    LOG_add("clng_type", MP_NSTR, TRS.get_string(in_node, "CLNG_TYPE"));
    LOG_add("rqst_dpmt", MP_NSTR, TRS.get_string(in_node, "RQST_DPMT"));
    LOG_add("clng_plan", MP_NSTR, TRS.get_string(in_node, "CLNG_PLAN"));
    LOG_add("clng_cmmt", MP_NSTR, TRS.get_string(in_node, "CLNG_CMMT"));
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
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Tb_Cleaning_Schedule",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
		strncpy(s_msg_code, "CWIP-0003", strlen("CWIP-0003"));
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(CWIP_Update_Tb_Cleaning_Schedule_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_crastbrcln(&CRASTBRCLN);
    TRS.copy(CRASTBRCLN.FACTORY, sizeof(CRASTBRCLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASTBRCLN.LINE_ID, sizeof(CRASTBRCLN.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CRASTBRCLN.WORK_SHIFT, sizeof(CRASTBRCLN.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CRASTBRCLN.RES_ID, sizeof(CRASTBRCLN.RES_ID), in_node, "RES_ID");
    TRS.copy(CRASTBRCLN.CLNG_DATE, sizeof(CRASTBRCLN.CLNG_DATE), in_node, "CLNG_DATE");
    TRS.copy(CRASTBRCLN.CLNG_TIME, sizeof(CRASTBRCLN.CLNG_TIME), in_node, "CLNG_TIME");
    TRS.copy(CRASTBRCLN.CLNG_TYPE, sizeof(CRASTBRCLN.CLNG_TYPE), in_node, "CLNG_TYPE");
    TRS.copy(CRASTBRCLN.RQST_DPMT, sizeof(CRASTBRCLN.RQST_DPMT), in_node, "RQST_DPMT");
    TRS.copy(CRASTBRCLN.CLNG_PLAN, sizeof(CRASTBRCLN.CLNG_PLAN), in_node, "CLNG_PLAN");
    TRS.copy(CRASTBRCLN.CLNG_CMMT, sizeof(CRASTBRCLN.CLNG_CMMT), in_node, "CLNG_CMMT");
    TRS.copy(CRASTBRCLN.CMF_1, sizeof(CRASTBRCLN.CMF_1), in_node, "CMF_1");
    TRS.copy(CRASTBRCLN.CMF_2, sizeof(CRASTBRCLN.CMF_2), in_node, "CMF_2");
    TRS.copy(CRASTBRCLN.CMF_3, sizeof(CRASTBRCLN.CMF_3), in_node, "CMF_3");
    TRS.copy(CRASTBRCLN.CMF_4, sizeof(CRASTBRCLN.CMF_4), in_node, "CMF_4");
    TRS.copy(CRASTBRCLN.CMF_5, sizeof(CRASTBRCLN.CMF_5), in_node, "CMF_5");
    TRS.copy(CRASTBRCLN.CMF_6, sizeof(CRASTBRCLN.CMF_6), in_node, "CMF_6");
    TRS.copy(CRASTBRCLN.CMF_7, sizeof(CRASTBRCLN.CMF_7), in_node, "CMF_7");
    TRS.copy(CRASTBRCLN.CMF_8, sizeof(CRASTBRCLN.CMF_8), in_node, "CMF_8");
    TRS.copy(CRASTBRCLN.CMF_9, sizeof(CRASTBRCLN.CMF_9), in_node, "CMF_9");
    TRS.copy(CRASTBRCLN.CMF_10, sizeof(CRASTBRCLN.CMF_10), in_node, "CMF_10");
    TRS.copy(CRASTBRCLN.CREATE_USER_ID, sizeof(CRASTBRCLN.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CRASTBRCLN.CREATE_TIME, sizeof(CRASTBRCLN.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CRASTBRCLN.UPDATE_USER_ID, sizeof(CRASTBRCLN.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CRASTBRCLN.UPDATE_TIME, sizeof(CRASTBRCLN.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CRASTBRCLN.CREATE_USER_ID, sizeof(CRASTBRCLN.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CRASTBRCLN.CREATE_TIME, s_sys_time, sizeof(CRASTBRCLN.CREATE_TIME));
        CDB_insert_crastbrcln(&CRASTBRCLN);
        if(DB_error_code != DB_SUCCESS)
        {
            strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CRASTBRCLN INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRCLN.FACTORY), CRASTBRCLN.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASTBRCLN.LINE_ID), CRASTBRCLN.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASTBRCLN.WORK_SHIFT), CRASTBRCLN.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTBRCLN.RES_ID), CRASTBRCLN.RES_ID);
            TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_STR, sizeof(CRASTBRCLN.CLNG_DATE), CRASTBRCLN.CLNG_DATE);
            TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_STR, sizeof(CRASTBRCLN.CLNG_TIME), CRASTBRCLN.CLNG_TIME);
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
        CDB_init_crastbrcln(&CRASTBRCLN_o);
        TRS.copy(CRASTBRCLN_o.FACTORY, sizeof(CRASTBRCLN_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CRASTBRCLN_o.LINE_ID, sizeof(CRASTBRCLN_o.LINE_ID), in_node, "LINE_ID");
        TRS.copy(CRASTBRCLN_o.WORK_SHIFT, sizeof(CRASTBRCLN_o.WORK_SHIFT), in_node, "WORK_SHIFT");
        TRS.copy(CRASTBRCLN_o.RES_ID, sizeof(CRASTBRCLN_o.RES_ID), in_node, "RES_ID");
        TRS.copy(CRASTBRCLN_o.CLNG_DATE, sizeof(CRASTBRCLN_o.CLNG_DATE), in_node, "CLNG_DATE");
        TRS.copy(CRASTBRCLN_o.CLNG_TIME, sizeof(CRASTBRCLN_o.CLNG_TIME), in_node, "CLNG_TIME");
        CDB_select_crastbrcln_for_update(1, &CRASTBRCLN_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CRASTBRCLN SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRCLN_o.FACTORY), CRASTBRCLN_o.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASTBRCLN_o.LINE_ID), CRASTBRCLN_o.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASTBRCLN_o.WORK_SHIFT), CRASTBRCLN_o.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTBRCLN_o.RES_ID), CRASTBRCLN_o.RES_ID);
            TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_STR, sizeof(CRASTBRCLN_o.CLNG_DATE), CRASTBRCLN_o.CLNG_DATE);
            TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_STR, sizeof(CRASTBRCLN_o.CLNG_TIME), CRASTBRCLN_o.CLNG_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        TRS.copy(CRASTBRCLN.UPDATE_USER_ID, sizeof(CRASTBRCLN.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CRASTBRCLN.UPDATE_TIME, s_sys_time, sizeof(CRASTBRCLN.UPDATE_TIME));

        CDB_update_crastbrcln(1, &CRASTBRCLN);
        if(DB_error_code != DB_SUCCESS)
        {
			strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CRASTBRCLN UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRCLN.FACTORY), CRASTBRCLN.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASTBRCLN.LINE_ID), CRASTBRCLN.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASTBRCLN.WORK_SHIFT), CRASTBRCLN.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTBRCLN.RES_ID), CRASTBRCLN.RES_ID);
            TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_STR, sizeof(CRASTBRCLN.CLNG_DATE), CRASTBRCLN.CLNG_DATE);
            TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_STR, sizeof(CRASTBRCLN.CLNG_TIME), CRASTBRCLN.CLNG_TIME);
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
        CDB_delete_crastbrcln(1, &CRASTBRCLN);
        if(DB_error_code != DB_SUCCESS)
        {
			strncpy(s_msg_code, "CWIP-0004", strlen("CWIP-0004"));
            TRS.add_fieldmsg(out_node, "CRASTBRCLN DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRCLN.FACTORY), CRASTBRCLN.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASTBRCLN.LINE_ID), CRASTBRCLN.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASTBRCLN.WORK_SHIFT), CRASTBRCLN.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTBRCLN.RES_ID), CRASTBRCLN.RES_ID);
            TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_STR, sizeof(CRASTBRCLN.CLNG_DATE), CRASTBRCLN.CLNG_DATE);
            TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_STR, sizeof(CRASTBRCLN.CLNG_TIME), CRASTBRCLN.CLNG_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Tb_Cleaning_Schedule",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_Tb_Cleaning_Schedule_Validation()
        - Main sub function of "CWIP_UPDATE_TB_CLEANING_SCHEDULE" function
        - Check the condition for create/update/delete Tb_Cleaning_Schedule
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Tb_Cleaning_Schedule_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASTBRCLN_TAG CRASTBRCLN;
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
	 
    return MP_TRUE;
}