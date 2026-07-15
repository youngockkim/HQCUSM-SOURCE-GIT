/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_sample.c
    Description : Sample Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Sample()
            + Create/Update/Delete Sample definition
        - CMMS_UPDATE_SAMPLE()
            + Main sub function of CMMS_Update_Sample function
            + Create/Update/Delete Sample definition
        - CMMS_Update_Sample_Validation()
            + Main sub function of CMMS_UPDATE_SAMPLE function
            + Check the condition for create/update/delete Sample
    Detail Description
        - CMMS_UPDATE_SAMPLE()
            + h_proc_step
                + MP_STEP_CREATE : Create Sample definition
                + MP_STEP_UPDATE : Update Sample definition
                + MP_STEP_DELETE : Delete Sample definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Sample_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Sample()
        - Create/Update/Delete Sample definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Sample(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_SAMPLE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_SAMPLE", out_node);

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
    CMMS_UPDATE_SAMPLE()
        - Main sub function of "CMMS_Update_Sample" function
        - Create/Update/Delete Sample definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_SAMPLE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSSAMDEF_TAG CMMSSAMDEF;
    struct CMMSSAMDEF_TAG CMMSSAMDEF_o;
	struct CMMSSAMHIS_TAG CMMSSAMHIS;
    char   s_sys_time[14];

    LOG_head("CMMS_UPDATE_SAMPLE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("sample_code", MP_NSTR, TRS.get_string(in_node, "SAMPLE_CODE"));
    LOG_add("sample_name", MP_NSTR, TRS.get_string(in_node, "SAMPLE_NAME"));
    LOG_add("sample_class_code", MP_NSTR, TRS.get_string(in_node, "SAMPLE_CLASS_CODE"));
    LOG_add("sample_group_code", MP_NSTR, TRS.get_string(in_node, "SAMPLE_GROUP_CODE"));
    LOG_add("sample_id_code", MP_INT, TRS.get_int(in_node, "SAMPLE_ID_CODE"));
    LOG_add("unit_no", MP_INT, TRS.get_int(in_node, "UNIT_NO"));
    LOG_add("smp_point_no", MP_INT, TRS.get_int(in_node, "SMP_POINT_NO"));
    LOG_add("prod_class_no", MP_INT, TRS.get_int(in_node, "PROD_CLASS_NO"));
    LOG_add("prod_no", MP_INT, TRS.get_int(in_node, "PROD_NO"));
    LOG_add("auto_flag", MP_CHR, TRS.get_char(in_node, "AUTO_FLAG"));
    LOG_add("priority", MP_CHR, TRS.get_char(in_node, "PRIORITY"));
    LOG_add("deault_spec_kind", MP_CHR, TRS.get_char(in_node, "DEAULT_SPEC_KIND"));
    LOG_add("certi_flag", MP_CHR, TRS.get_char(in_node, "CERTI_FLAG"));
    LOG_add("report_no", MP_INT, TRS.get_int(in_node, "REPORT_NO"));
    LOG_add("reserve_flag", MP_CHR, TRS.get_char(in_node, "RESERVE_FLAG"));
    LOG_add("reserve_day", MP_INT, TRS.get_int(in_node, "RESERVE_DAY"));
    LOG_add("reserve_condition", MP_NSTR, TRS.get_string(in_node, "RESERVE_CONDITION"));
    LOG_add("check_smp_flag", MP_CHR, TRS.get_char(in_node, "CHECK_SMP_FLAG"));
    LOG_add("std_ref_no", MP_INT, TRS.get_int(in_node, "STD_REF_NO"));
    LOG_add("sample_desc", MP_NSTR, TRS.get_string(in_node, "SAMPLE_DESC"));
    LOG_add("cost_part_no", MP_INT, TRS.get_int(in_node, "COST_PART_NO"));
    LOG_add("use_flag", MP_CHR, TRS.get_char(in_node, "USE_FLAG"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Sample",
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

    if(CMMS_Update_Sample_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmssamdef(&CMMSSAMDEF);
	TRS.copy(CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE), in_node, "SAMPLE_CODE");
    TRS.copy(CMMSSAMDEF.SAMPLE_NAME, sizeof(CMMSSAMDEF.SAMPLE_NAME), in_node, "SAMPLE_NAME");
    TRS.copy(CMMSSAMDEF.SAMPLE_CLASS_CODE, sizeof(CMMSSAMDEF.SAMPLE_CLASS_CODE), in_node, "SAMPLE_CLASS_CODE");
    TRS.copy(CMMSSAMDEF.SAMPLE_GROUP_CODE, sizeof(CMMSSAMDEF.SAMPLE_GROUP_CODE), in_node, "SAMPLE_GROUP_CODE");
    CMMSSAMDEF.SAMPLE_ID_CODE = TRS.get_int(in_node, "SAMPLE_ID_CODE");
    CMMSSAMDEF.UNIT_NO = TRS.get_int(in_node, "UNIT_NO");
    CMMSSAMDEF.SMP_POINT_NO = TRS.get_int(in_node, "SMP_POINT_NO");
    CMMSSAMDEF.PROD_CLASS_NO = TRS.get_int(in_node, "PROD_CLASS_NO");
    CMMSSAMDEF.PROD_NO = TRS.get_int(in_node, "PROD_NO");
    CMMSSAMDEF.AUTO_FLAG = TRS.get_char(in_node, "AUTO_FLAG");
    CMMSSAMDEF.PRIORITY = TRS.get_char(in_node, "PRIORITY");
    CMMSSAMDEF.DEAULT_SPEC_KIND = TRS.get_char(in_node, "DEAULT_SPEC_KIND");
    CMMSSAMDEF.CERTI_FLAG = TRS.get_char(in_node, "CERTI_FLAG");
    CMMSSAMDEF.REPORT_NO = TRS.get_int(in_node, "REPORT_NO");
    CMMSSAMDEF.RESERVE_FLAG = TRS.get_char(in_node, "RESERVE_FLAG");
    CMMSSAMDEF.RESERVE_DAY = TRS.get_int(in_node, "RESERVE_DAY");
    TRS.copy(CMMSSAMDEF.RESERVE_CONDITION, sizeof(CMMSSAMDEF.RESERVE_CONDITION), in_node, "RESERVE_CONDITION");
    CMMSSAMDEF.CHECK_SMP_FLAG = TRS.get_char(in_node, "CHECK_SMP_FLAG");
    CMMSSAMDEF.STD_REF_NO = TRS.get_int(in_node, "STD_REF_NO");
    TRS.copy(CMMSSAMDEF.SAMPLE_DESC, sizeof(CMMSSAMDEF.SAMPLE_DESC), in_node, "SAMPLE_DESC");
    CMMSSAMDEF.COST_PART_NO = TRS.get_int(in_node, "COST_PART_NO");
    CMMSSAMDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
    TRS.copy(CMMSSAMDEF.CREATE_USER_ID, sizeof(CMMSSAMDEF.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSSAMDEF.CREATE_TIME, sizeof(CMMSSAMDEF.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSSAMDEF.UPDATE_USER_ID, sizeof(CMMSSAMDEF.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSSAMDEF.UPDATE_TIME, sizeof(CMMSSAMDEF.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMSSAMDEF.CREATE_USER_ID, sizeof(CMMSSAMDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSSAMDEF.CREATE_TIME, s_sys_time, sizeof(CMMSSAMDEF.CREATE_TIME));
        CDB_insert_cmmssamdef(&CMMSSAMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSSAMDEF INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSSAMDEF.FACTORY), CMMSSAMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);
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
        CDB_init_cmmssamdef(&CMMSSAMDEF_o);
		TRS.copy(CMMSSAMDEF_o.FACTORY, sizeof(CMMSSAMDEF_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSSAMDEF_o.SAMPLE_CODE, sizeof(CMMSSAMDEF_o.SAMPLE_CODE), in_node, "SAMPLE_CODE");
        CDB_select_cmmssamdef_for_update(1, &CMMSSAMDEF_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSSAMDEF SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSSAMDEF_o.FACTORY), CMMSSAMDEF_o.FACTORY);
            TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF_o.SAMPLE_CODE), CMMSSAMDEF_o.SAMPLE_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CMMSSAMDEF.CREATE_USER_ID, CMMSSAMDEF_o.CREATE_USER_ID, sizeof(CMMSSAMDEF.CREATE_USER_ID));
        memcpy(CMMSSAMDEF.CREATE_TIME, CMMSSAMDEF_o.CREATE_TIME, sizeof(CMMSSAMDEF.CREATE_TIME));
        TRS.copy(CMMSSAMDEF.UPDATE_USER_ID, sizeof(CMMSSAMDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSSAMDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSSAMDEF.UPDATE_TIME));

        CDB_update_cmmssamdef(1, &CMMSSAMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSSAMDEF UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSSAMDEF.FACTORY), CMMSSAMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);
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
		//Log 기록을 위한 Update User/Time 바인딩 
		TRS.copy(CMMSSAMDEF.UPDATE_USER_ID, sizeof(CMMSSAMDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSSAMDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSSAMDEF.UPDATE_TIME));
        CDB_delete_cmmssamdef(1, &CMMSSAMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSSAMDEF DELETE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSSAMDEF.FACTORY), CMMSSAMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

	/*  Add History Log  */
	CDB_init_cmmssamhis(&CMMSSAMHIS);
	memcpy(CMMSSAMHIS.FACTORY, CMMSSAMDEF.FACTORY, sizeof(CMMSSAMHIS.FACTORY));
	memcpy(CMMSSAMHIS.SAMPLE_CODE, CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMHIS.SAMPLE_CODE));
	CMMSSAMHIS.HIST_SEQ = (int)CDB_select_cmmssamhis_scalar(2, &CMMSSAMHIS) + 1;
	memcpy(CMMSSAMHIS.SAMPLE_NAME, CMMSSAMDEF.SAMPLE_NAME, sizeof(CMMSSAMHIS.SAMPLE_NAME));
	memcpy(CMMSSAMHIS.SAMPLE_CLASS_CODE, CMMSSAMDEF.SAMPLE_CLASS_CODE, sizeof(CMMSSAMHIS.SAMPLE_CLASS_CODE));
	memcpy(CMMSSAMHIS.SAMPLE_GROUP_CODE, CMMSSAMDEF.SAMPLE_GROUP_CODE, sizeof(CMMSSAMHIS.SAMPLE_GROUP_CODE));
    CMMSSAMHIS.SAMPLE_ID_CODE = CMMSSAMDEF.SAMPLE_ID_CODE;
    CMMSSAMHIS.UNIT_NO = CMMSSAMDEF.UNIT_NO;
    CMMSSAMHIS.SMP_POINT_NO = CMMSSAMDEF.SMP_POINT_NO;
    CMMSSAMHIS.PROD_CLASS_NO = CMMSSAMDEF.PROD_CLASS_NO;
    CMMSSAMHIS.PROD_NO = CMMSSAMDEF.PROD_NO;
    CMMSSAMHIS.AUTO_FLAG = CMMSSAMDEF.AUTO_FLAG;
    CMMSSAMHIS.PRIORITY = CMMSSAMDEF.PRIORITY;
    CMMSSAMHIS.DEAULT_SPEC_KIND = CMMSSAMDEF.DEAULT_SPEC_KIND;
    CMMSSAMHIS.CERTI_FLAG = CMMSSAMDEF.CERTI_FLAG;
    CMMSSAMHIS.REPORT_NO = CMMSSAMDEF.REPORT_NO;
    CMMSSAMHIS.RESERVE_FLAG = CMMSSAMDEF.RESERVE_FLAG;
    CMMSSAMHIS.RESERVE_DAY = CMMSSAMDEF.RESERVE_DAY;
	memcpy(CMMSSAMHIS.RESERVE_CONDITION, CMMSSAMDEF.RESERVE_CONDITION, sizeof(CMMSSAMHIS.RESERVE_CONDITION));
    CMMSSAMHIS.CHECK_SMP_FLAG = CMMSSAMDEF.CHECK_SMP_FLAG;
    CMMSSAMHIS.STD_REF_NO = CMMSSAMDEF.STD_REF_NO;
	memcpy(CMMSSAMHIS.SAMPLE_DESC, CMMSSAMDEF.SAMPLE_DESC, sizeof(CMMSSAMHIS.SAMPLE_DESC));
    CMMSSAMHIS.COST_PART_NO = CMMSSAMDEF.COST_PART_NO;
    CMMSSAMHIS.USE_FLAG = CMMSSAMDEF.USE_FLAG;
	memcpy(CMMSSAMHIS.CREATE_USER_ID, CMMSSAMDEF.CREATE_USER_ID, sizeof(CMMSSAMHIS.CREATE_USER_ID));
	memcpy(CMMSSAMHIS.CREATE_TIME, CMMSSAMDEF.CREATE_TIME, sizeof(CMMSSAMDEF.CREATE_TIME));
	memcpy(CMMSSAMHIS.UPDATE_USER_ID, CMMSSAMDEF.UPDATE_USER_ID, sizeof(CMMSSAMHIS.UPDATE_USER_ID));
	memcpy(CMMSSAMHIS.UPDATE_TIME, CMMSSAMDEF.UPDATE_TIME, sizeof(CMMSSAMHIS.UPDATE_TIME));
	CDB_insert_cmmssamhis(&CMMSSAMHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSSAMHIS INSERT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSSAMHIS.FACTORY), CMMSSAMHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMHIS.SAMPLE_CODE), CMMSSAMHIS.SAMPLE_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Sample",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Sample_Validation()
        - Main sub function of "CMMS_UPDATE_SAMPLE" function
        - Check the condition for create/update/delete Sample
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Sample_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSSAMDEF_TAG CMMSSAMDEF;
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

    /* SAMPLE_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SAMPLE_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmssamdef(&CMMSSAMDEF);
	TRS.copy(CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE), in_node, "SAMPLE_CODE");
    CDB_select_cmmssamdef(1, &CMMSSAMDEF);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0010");
            TRS.add_fieldmsg(out_node, "CMMSSAMDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSSAMDEF.FACTORY), CMMSSAMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);
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

            TRS.add_fieldmsg(out_node, "CMMSSAMDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

