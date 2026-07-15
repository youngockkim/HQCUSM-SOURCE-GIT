/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_laminator_pull_test.c
    Description : Laminator_Pull_Test Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Laminator_Pull_Test()
            + Create/Update/Delete Laminator_Pull_Test definition
        - CWIP_UPDATE_LAMINATOR_PULL_TEST()
            + Main sub function of CWIP_Update_Laminator_Pull_Test function
            + Create/Update/Delete Laminator_Pull_Test definition
        - CWIP_Update_Laminator_Pull_Test_Validation()
            + Main sub function of CWIP_UPDATE_LAMINATOR_PULL_TEST function
            + Check the condition for create/update/delete Laminator_Pull_Test
    Detail Description
        - CWIP_UPDATE_LAMINATOR_PULL_TEST()
            + h_proc_step
                + MP_STEP_CREATE : Create Laminator_Pull_Test definition
                + MP_STEP_UPDATE : Update Laminator_Pull_Test definition
                + MP_STEP_DELETE : Delete Laminator_Pull_Test definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025-04-14             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_Update_Laminator_Pull_Test_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Laminator_Pull_Test()
        - Create/Update/Delete Laminator_Pull_Test definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Laminator_Pull_Test(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_LAMINATOR_PULL_TEST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_LAMINATOR_PULL_TEST", out_node);

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
    CWIP_UPDATE_LAMINATOR_PULL_TEST()
        - Main sub function of "CWIP_Update_Laminator_Pull_Test" function
        - Create/Update/Delete Laminator_Pull_Test definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_LAMINATOR_PULL_TEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLAMPTS_TAG CWIPLAMPTS;
    struct CWIPLAMPTS_TAG CWIPLAMPTS_o;
    char   s_sys_time[14];
	int inx;
	int i_tran_count;
	TRSNode ** Tran_List;

    LOG_head("CWIP_UPDATE_LAMINATOR_PULL_TEST");    
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

	if(CWIP_Update_Laminator_Pull_Test_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
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

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");

    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

	for ( inx =0; inx < i_tran_count; inx++ )
	{
		CDB_init_cwiplampts(&CWIPLAMPTS);
		TRS.copy(CWIPLAMPTS.FACTORY, sizeof(CWIPLAMPTS.FACTORY), Tran_List[inx], "FACTORY");
		TRS.copy(CWIPLAMPTS.MSMT_DATE, sizeof(CWIPLAMPTS.MSMT_DATE), Tran_List[inx], "MSMT_DATE");
		TRS.copy(CWIPLAMPTS.LINE_ID, sizeof(CWIPLAMPTS.LINE_ID), Tran_List[inx], "LINE_ID");
		TRS.copy(CWIPLAMPTS.RES_ID, sizeof(CWIPLAMPTS.RES_ID), Tran_List[inx], "RES_ID");
		CWIPLAMPTS.MODULE_NO = TRS.get_int(Tran_List[inx], "MODULE_NO");
		TRS.copy(CWIPLAMPTS.SMPL_DATE, sizeof(CWIPLAMPTS.MSMT_DATE), Tran_List[inx], "SMPL_DATE");
		TRS.copy(CWIPLAMPTS.PART_TYPE, sizeof(CWIPLAMPTS.PART_TYPE), Tran_List[inx], "PART_TYPE");
		CWIPLAMPTS.MSMT_POS1 = TRS.get_double(Tran_List[inx], "MSMT_POS1");
		CWIPLAMPTS.MSMT_POS2 = TRS.get_double(Tran_List[inx], "MSMT_POS2");
		CWIPLAMPTS.MSMT_POS3 = TRS.get_double(Tran_List[inx], "MSMT_POS3");
		CWIPLAMPTS.MSMT_POS4 = TRS.get_double(Tran_List[inx], "MSMT_POS4");
		CWIPLAMPTS.MSMT_POS5 = TRS.get_double(Tran_List[inx], "MSMT_POS5");
		CWIPLAMPTS.MSMT_POS6 = TRS.get_double(Tran_List[inx], "MSMT_POS6");
		CWIPLAMPTS.MSMT_POS7 = TRS.get_double(Tran_List[inx], "MSMT_POS7");
		CWIPLAMPTS.MSMT_POS8 = TRS.get_double(Tran_List[inx], "MSMT_POS8");
		CWIPLAMPTS.MSMT_POS9 = TRS.get_double(Tran_List[inx], "MSMT_POS9");
		CWIPLAMPTS.MSMT_POS10 = TRS.get_double(Tran_List[inx], "MSMT_POS10");
		TRS.copy(CWIPLAMPTS.CMF_1, sizeof(CWIPLAMPTS.CMF_1), Tran_List[inx], "CMF_1");
		TRS.copy(CWIPLAMPTS.CMF_2, sizeof(CWIPLAMPTS.CMF_2), Tran_List[inx], "CMF_2");
		TRS.copy(CWIPLAMPTS.CMF_3, sizeof(CWIPLAMPTS.CMF_3), Tran_List[inx], "CMF_3");
		TRS.copy(CWIPLAMPTS.CMF_4, sizeof(CWIPLAMPTS.CMF_4), Tran_List[inx], "CMF_4");
		TRS.copy(CWIPLAMPTS.CMF_5, sizeof(CWIPLAMPTS.CMF_5), Tran_List[inx], "CMF_5");
		TRS.copy(CWIPLAMPTS.CMF_6, sizeof(CWIPLAMPTS.CMF_6), Tran_List[inx], "CMF_6");
		TRS.copy(CWIPLAMPTS.CMF_7, sizeof(CWIPLAMPTS.CMF_7), Tran_List[inx], "CMF_7");
		TRS.copy(CWIPLAMPTS.CMF_8, sizeof(CWIPLAMPTS.CMF_8), Tran_List[inx], "CMF_8");
		TRS.copy(CWIPLAMPTS.CMF_9, sizeof(CWIPLAMPTS.CMF_9), Tran_List[inx], "CMF_9");
		TRS.copy(CWIPLAMPTS.CMF_10, sizeof(CWIPLAMPTS.CMF_10), Tran_List[inx], "CMF_10");

		if(TRS.get_procstep(in_node) == MP_STEP_CREATE || TRS.get_procstep(in_node) == MP_STEP_UPDATE ) 
		{
			CDB_init_cwiplampts(&CWIPLAMPTS_o);
			TRS.copy(CWIPLAMPTS_o.FACTORY, sizeof(CWIPLAMPTS_o.FACTORY), Tran_List[inx], "FACTORY");
			TRS.copy(CWIPLAMPTS_o.MSMT_DATE, sizeof(CWIPLAMPTS_o.MSMT_DATE), Tran_List[inx], "MSMT_DATE");
			TRS.copy(CWIPLAMPTS_o.LINE_ID, sizeof(CWIPLAMPTS_o.LINE_ID), Tran_List[inx], "LINE_ID");
			TRS.copy(CWIPLAMPTS_o.RES_ID, sizeof(CWIPLAMPTS_o.RES_ID), Tran_List[inx], "RES_ID");
			CWIPLAMPTS_o.MODULE_NO = TRS.get_int(Tran_List[inx], "MODULE_NO");
			TRS.copy(CWIPLAMPTS_o.PART_TYPE, sizeof(CWIPLAMPTS_o.PART_TYPE), Tran_List[inx], "PART_TYPE");
			CDB_select_cwiplampts_for_update(1, &CWIPLAMPTS_o);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					TRS.copy(CWIPLAMPTS.CREATE_USER_ID, sizeof(CWIPLAMPTS.CREATE_USER_ID), in_node, IN_USERID);
					memcpy(CWIPLAMPTS.CREATE_TIME, s_sys_time, sizeof(CWIPLAMPTS.CREATE_TIME));
					CDB_insert_cwiplampts(&CWIPLAMPTS);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "CWIP-0004");
						TRS.add_fieldmsg(out_node, "CWIPLAMPTS INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_STR, sizeof(CWIPLAMPTS.MSMT_DATE), CWIPLAMPTS.MSMT_DATE);
						TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMPTS.LINE_ID), CWIPLAMPTS.LINE_ID);
						TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMPTS.RES_ID), CWIPLAMPTS.RES_ID);
						TRS.add_fieldmsg(out_node, "MODULE_NO", MP_INT, CWIPLAMPTS.MODULE_NO);
						TRS.add_fieldmsg(out_node, "PART_TYPE", MP_STR, sizeof(CWIPLAMPTS.PART_TYPE), CWIPLAMPTS.PART_TYPE);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				} else {
					strcpy(s_msg_code, "CWIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPLAMPTS SELECT FOR UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_STR, sizeof(CWIPLAMPTS_o.MSMT_DATE), CWIPLAMPTS_o.MSMT_DATE);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMPTS_o.LINE_ID), CWIPLAMPTS_o.LINE_ID);
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMPTS_o.RES_ID), CWIPLAMPTS_o.RES_ID);
					TRS.add_fieldmsg(out_node, "MODULE_NO", MP_INT, CWIPLAMPTS_o.MODULE_NO);
					TRS.add_fieldmsg(out_node, "PART_TYPE", MP_STR, sizeof(CWIPLAMPTS_o.PART_TYPE), CWIPLAMPTS_o.PART_TYPE);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			} else {
				//----[Addtional Logic for Update Case]----

				TRS.copy(CWIPLAMPTS.UPDATE_USER_ID, sizeof(CWIPLAMPTS.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CWIPLAMPTS.UPDATE_TIME, s_sys_time, sizeof(CWIPLAMPTS.UPDATE_TIME));

				CDB_update_cwiplampts(1, &CWIPLAMPTS);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "CWIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPLAMPTS UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_STR, sizeof(CWIPLAMPTS.MSMT_DATE), CWIPLAMPTS.MSMT_DATE);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMPTS.LINE_ID), CWIPLAMPTS.LINE_ID);
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMPTS.RES_ID), CWIPLAMPTS.RES_ID);
					TRS.add_fieldmsg(out_node, "MODULE_NO", MP_INT, CWIPLAMPTS.MODULE_NO);
					TRS.add_fieldmsg(out_node, "PART_TYPE", MP_STR, sizeof(CWIPLAMPTS.PART_TYPE), CWIPLAMPTS.PART_TYPE);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
		if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
		{
			CDB_delete_cwiplampts(1, &CWIPLAMPTS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CWIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLAMPTS DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "MSMT_DATE", MP_STR, sizeof(CWIPLAMPTS.MSMT_DATE), CWIPLAMPTS.MSMT_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMPTS.LINE_ID), CWIPLAMPTS.LINE_ID);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMPTS.RES_ID), CWIPLAMPTS.RES_ID);
				TRS.add_fieldmsg(out_node, "MODULE_NO", MP_INT, CWIPLAMPTS.MODULE_NO);
				TRS.add_fieldmsg(out_node, "PART_TYPE", MP_STR, sizeof(CWIPLAMPTS.PART_TYPE), CWIPLAMPTS.PART_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	} 

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_Laminator_Pull_Test_Validation()
        - Main sub function of "CWIP_UPDATE_LAMINATOR_PULL_TEST" function
        - Check the condition for create/update/delete Laminator_Pull_Test
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Laminator_Pull_Test_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLAMPTS_TAG CWIPLAMPTS; 

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

