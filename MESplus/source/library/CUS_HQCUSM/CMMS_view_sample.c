/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_sample.c
    Description : View Sample function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Sample()
            + View Sample definition
        - CMMS_VIEW_SAMPLE()
            + Main sub function of CMMS_View_Sample function
            + View Sample definition
        - CMMS_View_Sample_Validation()
            + Main sub function of CMMS_VIEW_SAMPLE function
            + Check the condition for view Sample
    Detail Description
        - CMMS_VIEW_SAMPLE()
            + h_proc_step
                + 1 : View Sample definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Sample_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Sample()
        - View Sample definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Sample(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_SAMPLE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_SAMPLE", out_node);

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
    CMMS_VIEW_SAMPLE()
        - Main sub function of "CMMS_View_Sample" function
        - View Sample definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_SAMPLE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSSAMDEF_TAG CMMSSAMDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    LOG_head("CMMS_VIEW_SAMPLE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("sample_code", MP_NSTR, TRS.get_string(in_node, "SAMPLE_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Sample",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Sample_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmssamdef(&CMMSSAMDEF);
	TRS.copy(CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE), in_node, "SAMPLE_CODE");
    CDB_select_cmmssamdef(1, &CMMSSAMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSSAMDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	TRS.add_string(out_node, "FACTORY", CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY));
    TRS.add_string(out_node, "SAMPLE_CODE", CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE));
    TRS.add_string(out_node, "SAMPLE_NAME", CMMSSAMDEF.SAMPLE_NAME, sizeof(CMMSSAMDEF.SAMPLE_NAME));
    TRS.add_string(out_node, "SAMPLE_CLASS_CODE", CMMSSAMDEF.SAMPLE_CLASS_CODE, sizeof(CMMSSAMDEF.SAMPLE_CLASS_CODE));
    TRS.add_string(out_node, "SAMPLE_GROUP_CODE", CMMSSAMDEF.SAMPLE_GROUP_CODE, sizeof(CMMSSAMDEF.SAMPLE_GROUP_CODE));
    TRS.add_int(out_node, "SAMPLE_ID_CODE", CMMSSAMDEF.SAMPLE_ID_CODE);
    TRS.add_int(out_node, "UNIT_NO", CMMSSAMDEF.UNIT_NO);
    TRS.add_int(out_node, "SMP_POINT_NO", CMMSSAMDEF.SMP_POINT_NO);
    TRS.add_int(out_node, "PROD_CLASS_NO", CMMSSAMDEF.PROD_CLASS_NO);
    TRS.add_int(out_node, "PROD_NO", CMMSSAMDEF.PROD_NO);
    TRS.add_char(out_node, "AUTO_FLAG", CMMSSAMDEF.AUTO_FLAG);
    TRS.add_char(out_node, "PRIORITY", CMMSSAMDEF.PRIORITY);
    TRS.add_char(out_node, "DEAULT_SPEC_KIND", CMMSSAMDEF.DEAULT_SPEC_KIND);
    TRS.add_char(out_node, "CERTI_FLAG", CMMSSAMDEF.CERTI_FLAG);
    TRS.add_int(out_node, "REPORT_NO", CMMSSAMDEF.REPORT_NO);
    TRS.add_char(out_node, "RESERVE_FLAG", CMMSSAMDEF.RESERVE_FLAG);
    TRS.add_int(out_node, "RESERVE_DAY", CMMSSAMDEF.RESERVE_DAY);
    TRS.add_string(out_node, "RESERVE_CONDITION", CMMSSAMDEF.RESERVE_CONDITION, sizeof(CMMSSAMDEF.RESERVE_CONDITION));
    TRS.add_char(out_node, "CHECK_SMP_FLAG", CMMSSAMDEF.CHECK_SMP_FLAG);
    TRS.add_int(out_node, "STD_REF_NO", CMMSSAMDEF.STD_REF_NO);
    TRS.add_string(out_node, "SAMPLE_DESC", CMMSSAMDEF.SAMPLE_DESC, sizeof(CMMSSAMDEF.SAMPLE_DESC));
    TRS.add_int(out_node, "COST_PART_NO", CMMSSAMDEF.COST_PART_NO);
    TRS.add_char(out_node, "USE_FLAG", CMMSSAMDEF.USE_FLAG);
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSSAMDEF.CREATE_USER_ID, sizeof(CMMSSAMDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSSAMDEF.CREATE_TIME, sizeof(CMMSSAMDEF.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSSAMDEF.UPDATE_USER_ID, sizeof(CMMSSAMDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSSAMDEF.UPDATE_TIME, sizeof(CMMSSAMDEF.UPDATE_TIME));

	//Sample Group Description Á¶È¸
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_SAMPLE_GROUP, strlen(HQCEL_GCM_MMS_SAMPLE_GROUP));
	//memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_SAMPLE_GROUP", strlen("MMS_SAMPLE_GROUP"));
    memcpy(MGCMTBLDAT.KEY_1, CMMSSAMDEF.SAMPLE_GROUP_CODE, sizeof(MGCMTBLDAT.KEY_1));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "SAMPLE_GROUP_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Sample",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Sample_Validation()
        - Main sub function of "CMMS_VIEW_SAMPLE" function
        - Check the condition for view Sample
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Sample_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSSAMDEF_TAG CMMSSAMDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

	/* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* SAMPLE_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SAMPLE_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmssamdef(&CMMSSAMDEF);
	TRS.copy(CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE), in_node, "SAMPLE_CODE");
    CDB_select_cmmssamdef(1, &CMMSSAMDEF);
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
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSSAMDEF.FACTORY), CMMSSAMDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

