/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_view_cjcm_join_list.c
    Description : View CJCM_Join List function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_view_cjcm_join_list()
            + View CJCM_Join definition List
        - CJCM_view_cjcm_join_list()
            + Main sub function of CJCM_view_cjcm_join_list function
            + View CJCM_Join definition List
    Detail Description
        - CJCM_view_cjcm_join_list()
            + h_proc_step
                + 1 : View CJCM_Join definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/06/20             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CJCM_view_cjcm_join_list()
        - View CJCM_Join definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Cjcm_Join_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_VIEW_CJCM_JOIN_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_view_cjcm_join_list", out_node);

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
    CJCM_VIEW_CJCM_JOIN_LIST()
        - Main sub function of "CJCM_view_cjcm_join_list" function
        - View CJCM_Join definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_VIEW_CJCM_JOIN_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCM_JOIN_TAG CJCM_JOIN;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
    TRSNode *list_item;
	char   s_sys_time[14];
    int i_case;

    LOG_head("CJCM_view_cjcm_join_list");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_view_cjcm_join_list",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

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

    i_case = 1;

    CDB_init_cjcm_join(&CJCM_JOIN);
	TRS.copy(CJCM_JOIN.FACTORY, sizeof(CJCM_JOIN.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CJCM_JOIN.PLAN_START_DATE, sizeof(CJCM_JOIN.PLAN_START_DATE), in_node, "FROM_DATE");
	TRS.copy(CJCM_JOIN.PLAN_END_DATE, sizeof(CJCM_JOIN.PLAN_END_DATE), in_node, "TO_DATE");	
	TRS.copy(CJCM_JOIN.ORDER_ID, sizeof(CJCM_JOIN.ORDER_ID), in_node, "ORDER_ID");
	TRS.copy(CJCM_JOIN.MAT_ID, sizeof(CJCM_JOIN.MAT_ID), in_node, "MAT_ID");
	TRS.copy(CJCM_JOIN.LINE_ID, sizeof(CJCM_JOIN.LINE_ID), in_node, "LINE_ID");
    CDB_open_cjcm_join(i_case, &CJCM_JOIN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CJCM_JOIN OPEN", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cjcm_join(i_case, &CJCM_JOIN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cjcm_join(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CJCM_JOIN FETCH", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cjcm_join(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            CDB_close_cjcm_join(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "CJCM_JOIN_LIST");
		
        TRS.add_string(list_item, "FACTORY", CJCM_JOIN.FACTORY, sizeof(CJCM_JOIN.FACTORY));
        TRS.add_string(list_item, "ORDER_ID", CJCM_JOIN.ORDER_ID, sizeof(CJCM_JOIN.ORDER_ID));
        TRS.add_string(list_item, "MAT_ID", CJCM_JOIN.MAT_ID, sizeof(CJCM_JOIN.MAT_ID));
        TRS.add_string(list_item, "MAT_DESC", CJCM_JOIN.MAT_DESC, sizeof(CJCM_JOIN.MAT_DESC));
        TRS.add_string(list_item, "LINE_ID", CJCM_JOIN.LINE_ID, sizeof(CJCM_JOIN.LINE_ID));
        TRS.add_string(list_item, "LINE_NAME", CJCM_JOIN.LINE_NAME, sizeof(CJCM_JOIN.LINE_NAME));
        TRS.add_string(list_item, "ORD_START_DATE", CJCM_JOIN.ORD_START_DATE, sizeof(CJCM_JOIN.ORD_START_DATE));
		TRS.add_char(list_item, "STATUS", CJCM_JOIN.STATUS);
        TRS.add_string(list_item, "ITEM_CODE", CJCM_JOIN.ITEM_CODE, sizeof(CJCM_JOIN.ITEM_CODE));
        TRS.add_string(list_item, "ITEM_NAME", CJCM_JOIN.ITEM_NAME, sizeof(CJCM_JOIN.ITEM_NAME));
		TRS.add_char(list_item, "AUTO_FLAG", CJCM_JOIN.AUTO_FLAG);
        TRS.add_string(list_item, "RESPONSIBILITY", CJCM_JOIN.RESPONSIBILITY, sizeof(CJCM_JOIN.RESPONSIBILITY));
        TRS.add_string(list_item, "PLAN_START_DATE", CJCM_JOIN.PLAN_START_DATE, sizeof(CJCM_JOIN.PLAN_START_DATE));
        TRS.add_string(list_item, "PLAN_END_DATE", CJCM_JOIN.PLAN_END_DATE, sizeof(CJCM_JOIN.PLAN_END_DATE));        
        TRS.add_string(list_item, "START_TIME", CJCM_JOIN.START_TIME, sizeof(CJCM_JOIN.START_TIME));
        TRS.add_string(list_item, "END_TIME", CJCM_JOIN.END_TIME, sizeof(CJCM_JOIN.END_TIME));
		TRS.add_int(list_item, "WORK_TIME", CJCM_JOIN.WORK_TIME);
		TRS.add_char(list_item, "CHECK_FLAG", CJCM_JOIN.CHECK_FLAG);
        TRS.add_string(list_item, "ERR_MSG", CJCM_JOIN.ERR_MSG, sizeof(CJCM_JOIN.ERR_MSG));
		TRS.add_string(list_item, "SYS_TIME", s_sys_time, sizeof(s_sys_time));

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CJCM_JOIN.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_ITEM_STATUS", strlen("@JCM_ITEM_STATUS"));
		MGCMTBLDAT.KEY_1[0] = CJCM_JOIN.STATUS;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "STATUS_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CJCM_JOIN.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_ITEM_STATUS", strlen("@JCM_ITEM_STATUS"));
		MGCMTBLDAT.KEY_1[0] = CJCM_JOIN.CHECK_FLAG;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "ITEM_STATUS", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		TRS.add_string(list_item, "SYS_DATE", s_sys_time, sizeof(s_sys_time));

    }

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_view_cjcm_join_list",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

