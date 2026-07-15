/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_laminator_pull_test_list.c
    Description : View Laminator_Pull_Test List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Laminator_Pull_Test_List()
            + View Laminator_Pull_Test definition List
        - CWIP_VIEW_LAMINATOR_PULL_TEST_LIST()
            + Main sub function of CWIP_View_Laminator_Pull_Test_List function
            + View Laminator_Pull_Test definition List
    Detail Description
        - CWIP_VIEW_LAMINATOR_PULL_TEST_LIST()
            + h_proc_step
                + 1 : View Laminator_Pull_Test definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025-04-14             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>


int CWIP_View_Laminator_Pull_Test_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_View_Laminator_Pull_Test_List()
        - View Laminator_Pull_Test definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Laminator_Pull_Test_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_LAMINATOR_PULL_TEST_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_LAMINATOR_PULL_TEST_LIST", out_node);

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
    CWIP_VIEW_LAMINATOR_PULL_TEST_LIST()
        - Main sub function of "CWIP_View_Laminator_Pull_Test_List" function
        - View Laminator_Pull_Test definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LAMINATOR_PULL_TEST_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    int i_step;
	char s_sys_time[14];
	TRSNode *list_item;
    struct CWIPLAMPTS_TAG CWIPLAMPTS;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_LAMINATOR_PULL_TEST_LIST");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Ordered by Magazine ID
    */

    if(CWIP_View_Laminator_Pull_Test_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
	
	if (TRS.get_procstep(in_node) == '1')
	{
		i_step = 100;
	}
	else
	{
		return MP_FALSE;
	}


    CDB_init_cwiplampts(&CWIPLAMPTS);
	TRS.copy(CWIPLAMPTS.FACTORY, sizeof(CWIPLAMPTS.FACTORY), in_node, "FACTORY");
    TRS.copy(CWIPLAMPTS.MSMT_DATE, sizeof(CWIPLAMPTS.MSMT_DATE), in_node, "MSMT_DATE");
    TRS.copy(CWIPLAMPTS.LINE_ID, sizeof(CWIPLAMPTS.LINE_ID), in_node, "LINE_ID");

	CDB_open_cwiplampts(i_step, &CWIPLAMPTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPLAMPTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_STR, sizeof(CWIPLAMPTS.MSMT_DATE), CWIPLAMPTS.MSMT_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMPTS.LINE_ID), CWIPLAMPTS.LINE_ID);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMPTS.RES_ID), CWIPLAMPTS.RES_ID);
        TRS.add_fieldmsg(out_node, "MODULE_NO", MP_INT, CWIPLAMPTS.MODULE_NO);
        TRS.add_fieldmsg(out_node, "PART_TYPE", MP_STR, sizeof(CWIPLAMPTS.PART_TYPE), CWIPLAMPTS.PART_TYPE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwiplampts(i_step, &CWIPLAMPTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiplampts(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLAMPTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_STR, sizeof(CWIPLAMPTS.MSMT_DATE), CWIPLAMPTS.MSMT_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMPTS.LINE_ID), CWIPLAMPTS.LINE_ID);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMPTS.RES_ID), CWIPLAMPTS.RES_ID);
            TRS.add_fieldmsg(out_node, "MODULE_NO", MP_INT, CWIPLAMPTS.MODULE_NO);
            TRS.add_fieldmsg(out_node, "PART_TYPE", MP_STR, sizeof(CWIPLAMPTS.PART_TYPE), CWIPLAMPTS.PART_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwiplampts(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_MSMT_DATE", CWIPLAMPTS.MSMT_DATE, sizeof(CWIPLAMPTS.MSMT_DATE));
            TRS.set_string(out_node, "NEXT_LINE_ID", CWIPLAMPTS.LINE_ID, sizeof(CWIPLAMPTS.LINE_ID));
            TRS.set_string(out_node, "NEXT_RES_ID", CWIPLAMPTS.RES_ID, sizeof(CWIPLAMPTS.RES_ID));
            TRS.set_int(out_node, "NEXT_MODULE_NO", CWIPLAMPTS.MODULE_NO);
            TRS.set_string(out_node, "NEXT_PART_TYPE", CWIPLAMPTS.PART_TYPE, sizeof(CWIPLAMPTS.PART_TYPE));
            CDB_close_cwiplampts(i_step);
            break;
        }

        list_item = TRS.add_node(out_node, "LAMINATOR_PULL_TEST_LIST");

        TRS.add_string(list_item, "MSMT_DATE", CWIPLAMPTS.MSMT_DATE, sizeof(CWIPLAMPTS.MSMT_DATE));
        TRS.add_string(list_item, "LINE_ID", CWIPLAMPTS.LINE_ID, sizeof(CWIPLAMPTS.LINE_ID));
        TRS.add_string(list_item, "RES_ID", CWIPLAMPTS.RES_ID, sizeof(CWIPLAMPTS.RES_ID));
        TRS.add_int(list_item, "MODULE_NO", CWIPLAMPTS.MODULE_NO);
        TRS.add_string(list_item, "PART_TYPE", CWIPLAMPTS.PART_TYPE, sizeof(CWIPLAMPTS.PART_TYPE));
        TRS.add_string(list_item, "SMPL_DATE", CWIPLAMPTS.SMPL_DATE, sizeof(CWIPLAMPTS.SMPL_DATE));
        TRS.add_double(list_item, "MSMT_POS1", CWIPLAMPTS.MSMT_POS1);
        TRS.add_double(list_item, "MSMT_POS2", CWIPLAMPTS.MSMT_POS2);
        TRS.add_double(list_item, "MSMT_POS3", CWIPLAMPTS.MSMT_POS3);
        TRS.add_double(list_item, "MSMT_POS4", CWIPLAMPTS.MSMT_POS4);
        TRS.add_double(list_item, "MSMT_POS5", CWIPLAMPTS.MSMT_POS5);
        TRS.add_double(list_item, "MSMT_POS6", CWIPLAMPTS.MSMT_POS6);
        TRS.add_double(list_item, "MSMT_POS7", CWIPLAMPTS.MSMT_POS7);
        TRS.add_double(list_item, "MSMT_POS8", CWIPLAMPTS.MSMT_POS8);
        TRS.add_double(list_item, "MSMT_POS9", CWIPLAMPTS.MSMT_POS9);
        TRS.add_double(list_item, "MSMT_POS10", CWIPLAMPTS.MSMT_POS10);
        TRS.add_string(list_item, "CMF_1", CWIPLAMPTS.CMF_1, sizeof(CWIPLAMPTS.CMF_1));
        TRS.add_string(list_item, "CMF_2", CWIPLAMPTS.CMF_2, sizeof(CWIPLAMPTS.CMF_2));
        TRS.add_string(list_item, "CMF_3", CWIPLAMPTS.CMF_3, sizeof(CWIPLAMPTS.CMF_3));
        TRS.add_string(list_item, "CMF_4", CWIPLAMPTS.CMF_4, sizeof(CWIPLAMPTS.CMF_4));
        TRS.add_string(list_item, "CMF_5", CWIPLAMPTS.CMF_5, sizeof(CWIPLAMPTS.CMF_5));
        TRS.add_string(list_item, "CMF_6", CWIPLAMPTS.CMF_6, sizeof(CWIPLAMPTS.CMF_6));
        TRS.add_string(list_item, "CMF_7", CWIPLAMPTS.CMF_7, sizeof(CWIPLAMPTS.CMF_7));
        TRS.add_string(list_item, "CMF_8", CWIPLAMPTS.CMF_8, sizeof(CWIPLAMPTS.CMF_8));
        TRS.add_string(list_item, "CMF_9", CWIPLAMPTS.CMF_9, sizeof(CWIPLAMPTS.CMF_9));
        TRS.add_string(list_item, "CMF_10", CWIPLAMPTS.CMF_10, sizeof(CWIPLAMPTS.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CWIPLAMPTS.CREATE_USER_ID, sizeof(CWIPLAMPTS.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CWIPLAMPTS.CREATE_TIME, sizeof(CWIPLAMPTS.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPLAMPTS.UPDATE_USER_ID, sizeof(CWIPLAMPTS.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CWIPLAMPTS.UPDATE_TIME, sizeof(CWIPLAMPTS.UPDATE_TIME));
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
	CWIP_View_Monthly_Plan_Validation()
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Laminator_Pull_Test_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

     
    return MP_TRUE;
}