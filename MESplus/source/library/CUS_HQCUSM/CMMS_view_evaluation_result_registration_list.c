/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_evaluation_result_registration_list.c
    Description : View Evaluation_Result_Registration List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Evaluation_Result_Registration_List()
            + View Evaluation_Result_Registration definition List
        - CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST()
            + Main sub function of CMMS_View_Evaluation_Result_Registration_List function
            + View Evaluation_Result_Registration definition List
        - CMMS_View_Evaluation_Result_Registration_List_Validation()
            + Main sub function of CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST function
            + Check the condition for view Evaluation_Result_Registration list
    Detail Description
        - CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST()
            + h_proc_step
                + 1 : View Evaluation_Result_Registration definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-03             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Evaluation_Result_Registration_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Evaluation_Result_Registration_List()
        - View Evaluation_Result_Registration definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Evaluation_Result_Registration_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST", out_node);

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
    CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST()
        - Main sub function of "CMMS_View_Evaluation_Result_Registration_List" function
        - View Evaluation_Result_Registration definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMYEARES_TAG CMMYEARES;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("doc_id", MP_NSTR, TRS.get_string(in_node, "DOC_ID"));
    LOG_add("result_year", MP_INT, TRS.get_int(in_node, "RESULT_YEAR"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Evaluation_Result_Registration_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Evaluation_Result_Registration_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_cmmyeares(&CMMYEARES);
    TRS.copy(CMMYEARES.FACTORY, sizeof(CMMYEARES.FACTORY), in_node, IN_FACTORY);    
    CMMYEARES.RESULT_YEAR = TRS.get_int(in_node, "RESULT_YEAR");
	TRS.copy(CMMYEARES.RESULT_TYPE, sizeof(CMMYEARES.RESULT_TYPE), in_node, "RESULT_TYPE");
	CMMYEARES.ANA_DIV = TRS.get_char(in_node, "ANA_DIV");
	TRS.copy(CMMYEARES.DEPT_CODE, sizeof(CMMYEARES.DEPT_CODE), in_node, "DEPT_CODE");
    CDB_open_cmmyeares(i_case, &CMMYEARES);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMYEARES OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES.FACTORY), CMMYEARES.FACTORY);
        TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES.DOC_ID), CMMYEARES.DOC_ID);
        TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES.RESULT_YEAR);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cmmyeares(i_case, &CMMYEARES);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmyeares(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMYEARES FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMYEARES.FACTORY), CMMYEARES.FACTORY);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CMMYEARES.DOC_ID), CMMYEARES.DOC_ID);
            TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_INT, CMMYEARES.RESULT_YEAR);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmyeares(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //    TRS.set_string(out_node, "NEXT_DOC_ID", CMMYEARES.DOC_ID, sizeof(CMMYEARES.DOC_ID));
        //    TRS.set_int(out_node, "NEXT_RESULT_YEAR", CMMYEARES.RESULT_YEAR);
        //    CDB_close_cmmyeares(i_case);
        //    break;
        //}

        list_item = TRS.add_node(out_node, "EVALUATION_RESULT_REGISTRATION_LIST");

        TRS.add_string(list_item, "FACTORY", CMMYEARES.FACTORY, sizeof(CMMYEARES.FACTORY));
        TRS.add_string(list_item, "DOC_ID", CMMYEARES.DOC_ID, sizeof(CMMYEARES.DOC_ID));
        TRS.add_int(list_item, "RESULT_YEAR", CMMYEARES.RESULT_YEAR);
        TRS.add_string(list_item, "RESULT_TYPE", CMMYEARES.RESULT_TYPE, sizeof(CMMYEARES.RESULT_TYPE));
        TRS.add_char(list_item, "ANA_DIV", CMMYEARES.ANA_DIV);
		TRS.add_string(list_item, "DEPT_CODE", CMMYEARES.DEPT_CODE, sizeof(CMMYEARES.DEPT_CODE));
        TRS.add_string(list_item, "FILE_NAME", CMMYEARES.FILE_NAME, sizeof(CMMYEARES.FILE_NAME));
        TRS.add_string(list_item, "FILE_PATH", CMMYEARES.FILE_PATH, sizeof(CMMYEARES.FILE_PATH));
        TRS.add_char(list_item, "PF_FLAG", CMMYEARES.PF_FLAG);
        TRS.add_string(list_item, "COMMENTS", CMMYEARES.COMMENTS, sizeof(CMMYEARES.COMMENTS));
        TRS.add_string(list_item, "CMF_1", CMMYEARES.CMF_1, sizeof(CMMYEARES.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMYEARES.CMF_2, sizeof(CMMYEARES.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMYEARES.CMF_3, sizeof(CMMYEARES.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMYEARES.CMF_4, sizeof(CMMYEARES.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMYEARES.CMF_5, sizeof(CMMYEARES.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMYEARES.CMF_6, sizeof(CMMYEARES.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMYEARES.CMF_7, sizeof(CMMYEARES.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMYEARES.CMF_8, sizeof(CMMYEARES.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMYEARES.CMF_9, sizeof(CMMYEARES.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMYEARES.CMF_10, sizeof(CMMYEARES.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMYEARES.CREATE_USER_ID, sizeof(CMMYEARES.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMYEARES.CREATE_TIME, sizeof(CMMYEARES.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMYEARES.UPDATE_USER_ID, sizeof(CMMYEARES.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMYEARES.UPDATE_TIME, sizeof(CMMYEARES.UPDATE_TIME));

		//GCM 조회(ANA_DIV_DESC)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CMMYEARES.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ANA_MOTHOD, strlen(HQCEL_GCM_MMS_ANA_MOTHOD));
		MGCMTBLDAT.KEY_1[0] = CMMYEARES.ANA_DIV;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "ANA_DIV_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//GCM 조회(RESULT_TYPE_NAME)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CMMYEARES.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_RESULT_TYPE, strlen(HQCEL_GCM_MMS_RESULT_TYPE));
		//memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_RESULT_TYPE", strlen("MMS_RESULT_TYPE"));
		memcpy(MGCMTBLDAT.KEY_1, CMMYEARES.RESULT_TYPE, sizeof(CMMYEARES.RESULT_TYPE));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "RESULT_TYPE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//GCM 조회(DEPT_NAME)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CMMYEARES.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_DEPT_CODE, strlen(HQCEL_GCM_MMS_DEPT_CODE));
		memcpy(MGCMTBLDAT.KEY_1, CMMYEARES.DEPT_CODE, sizeof(CMMYEARES.DEPT_CODE));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "DEPT_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Evaluation_Result_Registration_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Evaluation_Result_Registration_List_Validation()
        - Main sub function of "CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST" function
        - Check the condition for view Evaluation_Result_Registration list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Evaluation_Result_Registration_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct CMMYEARES_TAG CMMYEARES;

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
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    ///* DOC_ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "DOC_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "MMS-0001");
    //    TRS.add_fieldmsg(out_node, "DOC_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    /* RESULT_YEAR Validation */
    if(TRS.get_int(in_node, "RESULT_YEAR") == 0)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "RESULT_YEAR", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /*CDB_init_cmmyeares(&CMMYEARES);
    TRS.copy(CMMYEARES.FACTORY, sizeof(CMMYEARES.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMYEARES.DOC_ID, sizeof(CMMYEARES.DOC_ID), in_node, "DOC_ID");
    CMMYEARES.RESULT_YEAR = TRS.get_int(in_node, "RESULT_YEAR");
    CDB_select_cmmyeares(1, &CMMYEARES);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "MMS-0004");
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
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }*/

    return MP_TRUE;
}

