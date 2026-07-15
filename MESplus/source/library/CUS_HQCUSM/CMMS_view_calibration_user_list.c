/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_user_list.c
    Description : View Calibration_User List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_User_List()
            + View Calibration_User definition List
        - CMMS_VIEW_CALIBRATION_USER_LIST()
            + Main sub function of CMMS_View_Calibration_User_List function
            + View Calibration_User definition List
        - CMMS_View_Calibration_User_List_Validation()
            + Main sub function of CMMS_VIEW_CALIBRATION_USER_LIST function
            + Check the condition for view Calibration_User list
    Detail Description
        - CMMS_VIEW_CALIBRATION_USER_LIST()
            + h_proc_step
                + 1 : View Calibration_User definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Calibration_user_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Calibration_User_List()
        - View Calibration_User definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_user_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_USER_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_USER_LIST", out_node);

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
    CMMS_VIEW_CALIBRATION_USER_LIST()
        - Main sub function of "CMMS_View_Calibration_User_List" function
        - View Calibration_User definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_USER_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSUSRDEF_TAG CMMSUSRDEF;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_CALIBRATION_USER_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("user_id", MP_NSTR, TRS.get_string(in_node, "USER_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_User_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Calibration_user_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 2;
    CDB_init_cmmsusrdef(&CMMSUSRDEF);
	TRS.copy(CMMSUSRDEF.FACTORY, sizeof(CMMSUSRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID), in_node, "USER_ID");
    //TRS.copy(CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID), in_node, "NEXT_USER_ID"); 
	if (TRS.get_procstep(in_node) == '3')
	{
		i_case = 3;
		CMMSUSRDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
	}
    CDB_open_cmmsusrdef(i_case, &CMMSUSRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSUSRDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	if (TRS.get_procstep(in_node) == '3')
	{
		while(1)
		{
			CDB_fetch_cmmsusrdef(i_case, &CMMSUSRDEF);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmsusrdef(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSUSRDEF FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsusrdef(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "CALIBRATION_USER_LIST");
			TRS.add_string(list_item, "USER_ID", CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID));
			TRS.add_string(list_item, "USER_NAME", CMMSUSRDEF.USER_NAME, sizeof(CMMSUSRDEF.USER_NAME));
		}
	}
	else
	{
		while(1)
		{
			CDB_fetch_cmmsusrdef(i_case, &CMMSUSRDEF);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmsusrdef(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSUSRDEF FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmsusrdef(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//if(COM_check_node_length(out_node) == MP_FALSE)
			//{
			//    TRS.set_string(out_node, "NEXT_USER_ID", CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID));
			//    CDB_close_cmmsusrdef(i_case);
			//    break;
			//}

			list_item = TRS.add_node(out_node, "CALIBRATION_USER_LIST");

			TRS.add_string(list_item, "FACTORY", CMMSUSRDEF.FACTORY, sizeof(CMMSUSRDEF.FACTORY));
			TRS.add_string(list_item, "USER_ID", CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID));
			TRS.add_string(list_item, "USER_NAME", CMMSUSRDEF.USER_NAME, sizeof(CMMSUSRDEF.USER_NAME));
			TRS.add_string(list_item, "FILE_NAME", CMMSUSRDEF.FILE_NAME, sizeof(CMMSUSRDEF.FILE_NAME));
			TRS.add_string(list_item, "FILE_PATH", CMMSUSRDEF.FILE_PATH, sizeof(CMMSUSRDEF.FILE_PATH));
			TRS.add_string(list_item, "EXPIRY_DATE", CMMSUSRDEF.EXPIRY_DATE, sizeof(CMMSUSRDEF.EXPIRY_DATE));
			TRS.add_char(list_item, "CALI_FLAG", CMMSUSRDEF.CALI_FLAG);
			TRS.add_char(list_item, "MSA_FLAG", CMMSUSRDEF.MSA_FLAG);
			TRS.add_char(list_item, "USE_FLAG", CMMSUSRDEF.USE_FLAG);
			TRS.add_string(list_item, "CREATE_USER_ID", CMMSUSRDEF.CREATE_USER_ID, sizeof(CMMSUSRDEF.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CMMSUSRDEF.CREATE_TIME, sizeof(CMMSUSRDEF.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CMMSUSRDEF.UPDATE_USER_ID, sizeof(CMMSUSRDEF.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", CMMSUSRDEF.UPDATE_TIME, sizeof(CMMSUSRDEF.UPDATE_TIME));
		}
	}


    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_User_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Calibration_User_List_Validation()
        - Main sub function of "CMMS_VIEW_CALIBRATION_USER_LIST" function
        - Check the condition for view Calibration_User list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_user_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct CMMSUSRDEF_TAG CMMSUSRDEF;

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
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    ///* USER_ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "USER_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "MMS-0001");
    //    TRS.add_fieldmsg(out_node, "USER_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    //CDB_init_cmmsusrdef(&CMMSUSRDEF);
    //TRS.copy(CMMSUSRDEF.USER_ID, sizeof(CMMSUSRDEF.USER_ID), in_node, "USER_ID");
    //CDB_select_cmmsusrdef(1, &CMMSUSRDEF);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    if(DB_error_code == DB_NOT_FOUND)
    //    {
    //        strcpy(s_msg_code, "MMS-XXXX");
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    }
    //    else
    //    {
    //        strcpy(s_msg_code, "MMS-0004");
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    }

    //    TRS.add_fieldmsg(out_node, "CMMSUSRDEF SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(CMMSUSRDEF.USER_ID), CMMSUSRDEF.USER_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}

