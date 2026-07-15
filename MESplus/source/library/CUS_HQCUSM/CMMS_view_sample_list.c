/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_sample_list.c
    Description : View Sample List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Sample_List()
            + View Sample definition List
        - CMMS_VIEW_SAMPLE_LIST()
            + Main sub function of CMMS_View_Sample_List function
            + View Sample definition List
        - CMMS_View_Sample_List_Validation()
            + Main sub function of CMMS_VIEW_SAMPLE_LIST function
            + Check the condition for view Sample list
    Detail Description
        - CMMS_VIEW_SAMPLE_LIST()
            + h_proc_step
                + 1 : View Sample definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Sample_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Sample_List()
        - View Sample definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Sample_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_SAMPLE_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_SAMPLE_LIST", out_node);

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
    CMMS_VIEW_SAMPLE_LIST()
        - Main sub function of "CMMS_View_Sample_List" function
        - View Sample definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_SAMPLE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSSAMDEF_TAG CMMSSAMDEF;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_SAMPLE_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("sample_code", MP_NSTR, TRS.get_string(in_node, "SAMPLE_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Sample_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Sample_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 2;
	

    CDB_init_cmmssamdef(&CMMSSAMDEF);
	TRS.copy(CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CMMSSAMDEF.SAMPLE_GROUP_CODE, sizeof(CMMSSAMDEF.SAMPLE_GROUP_CODE), in_node, "SAMPLE_GROUP_CODE");
	if(TRS.get_procstep(in_node) == '3')
	{
		i_case = 3;
		CMMSSAMDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
	}
    CDB_open_cmmssamdef(i_case, &CMMSSAMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSSAMDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cmmssamdef(i_case, &CMMSSAMDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmssamdef(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSSAMDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmssamdef(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        list_item = TRS.add_node(out_node, "SAMPLE_LIST");

		TRS.add_string(list_item, "FACTORY", CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY));
        TRS.add_string(list_item, "SAMPLE_CODE", CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE));
        TRS.add_string(list_item, "SAMPLE_NAME", CMMSSAMDEF.SAMPLE_NAME, sizeof(CMMSSAMDEF.SAMPLE_NAME));
		if(i_case != 3)
		{
			TRS.add_string(list_item, "SAMPLE_CLASS_CODE", CMMSSAMDEF.SAMPLE_CLASS_CODE, sizeof(CMMSSAMDEF.SAMPLE_CLASS_CODE));
			TRS.add_string(list_item, "SAMPLE_GROUP_CODE", CMMSSAMDEF.SAMPLE_GROUP_CODE, sizeof(CMMSSAMDEF.SAMPLE_GROUP_CODE));
			TRS.add_int(list_item, "SAMPLE_ID_CODE", CMMSSAMDEF.SAMPLE_ID_CODE);
			TRS.add_int(list_item, "UNIT_NO", CMMSSAMDEF.UNIT_NO);
			TRS.add_int(list_item, "SMP_POINT_NO", CMMSSAMDEF.SMP_POINT_NO);
			TRS.add_int(list_item, "PROD_CLASS_NO", CMMSSAMDEF.PROD_CLASS_NO);
			TRS.add_int(list_item, "PROD_NO", CMMSSAMDEF.PROD_NO);
			TRS.add_char(list_item, "AUTO_FLAG", CMMSSAMDEF.AUTO_FLAG);
			TRS.add_char(list_item, "PRIORITY", CMMSSAMDEF.PRIORITY);
			TRS.add_char(list_item, "DEAULT_SPEC_KIND", CMMSSAMDEF.DEAULT_SPEC_KIND);
			TRS.add_char(list_item, "CERTI_FLAG", CMMSSAMDEF.CERTI_FLAG);
			TRS.add_int(list_item, "REPORT_NO", CMMSSAMDEF.REPORT_NO);
			TRS.add_char(list_item, "RESERVE_FLAG", CMMSSAMDEF.RESERVE_FLAG);
			TRS.add_int(list_item, "RESERVE_DAY", CMMSSAMDEF.RESERVE_DAY);
			TRS.add_string(list_item, "RESERVE_CONDITION", CMMSSAMDEF.RESERVE_CONDITION, sizeof(CMMSSAMDEF.RESERVE_CONDITION));
			TRS.add_char(list_item, "CHECK_SMP_FLAG", CMMSSAMDEF.CHECK_SMP_FLAG);
			TRS.add_int(list_item, "STD_REF_NO", CMMSSAMDEF.STD_REF_NO);
			TRS.add_string(list_item, "SAMPLE_DESC", CMMSSAMDEF.SAMPLE_DESC, sizeof(CMMSSAMDEF.SAMPLE_DESC));
			TRS.add_int(list_item, "COST_PART_NO", CMMSSAMDEF.COST_PART_NO);
			TRS.add_char(list_item, "USE_FLAG", CMMSSAMDEF.USE_FLAG);
			TRS.add_string(list_item, "CREATE_USER_ID", CMMSSAMDEF.CREATE_USER_ID, sizeof(CMMSSAMDEF.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CMMSSAMDEF.CREATE_TIME, sizeof(CMMSSAMDEF.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CMMSSAMDEF.UPDATE_USER_ID, sizeof(CMMSSAMDEF.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", CMMSSAMDEF.UPDATE_TIME, sizeof(CMMSSAMDEF.UPDATE_TIME));
		}
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Sample_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Sample_List_Validation()
        - Main sub function of "CMMS_VIEW_SAMPLE_LIST" function
        - Check the condition for view Sample list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Sample_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct CMMSSAMDEF_TAG CMMSSAMDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123") == MP_FALSE)
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

    ///* SAMPLE_CODE Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "SAMPLE_CODE")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "MMS-0001");
    //    TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    //CDB_init_cmmssamdef(&CMMSSAMDEF);
    //TRS.copy(CMMSSAMDEF.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE), in_node, "SAMPLE_CODE");
    //CDB_select_cmmssamdef(1, &CMMSSAMDEF);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    if(DB_error_code == DB_NOT_FOUND)
    //    {
    //        strcpy(s_msg_code, "MMS-0011");
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    }
    //    else
    //    {
    //        strcpy(s_msg_code, "MMS-0004");
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    }

    //    TRS.add_fieldmsg(out_node, "CMMSSAMDEF SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "SAMPLE_CODE", MP_STR, sizeof(CMMSSAMDEF.SAMPLE_CODE), CMMSSAMDEF.SAMPLE_CODE);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}

