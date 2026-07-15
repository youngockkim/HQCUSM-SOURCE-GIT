/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_crasdwntim.c
    Description : Crasdwntim Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_Crasdwntim()
            + Create/Update/Delete Crasdwntim definition
        - CRAS_UPDATE_CRASDWNTIM()
            + Main sub function of CRAS_Update_Crasdwntim function
            + Create/Update/Delete Crasdwntim definition
        - CRAS_Update_Crasdwntim_Validation()
            + Main sub function of CRAS_UPDATE_CRASDWNTIM function
            + Check the condition for create/update/delete Crasdwntim
    Detail Description
        - CRAS_UPDATE_CRASDWNTIM()
            + h_proc_step
                + MP_STEP_CREATE : Create Crasdwntim definition
                + MP_STEP_UPDATE : Update Crasdwntim definition
                + MP_STEP_DELETE : Delete Crasdwntim definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-04-20             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_Crasdwntim_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_Crasdwntim()
        - Create/Update/Delete Crasdwntim definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Crasdwntim(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_UPDATE_CRASDWNTIM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_CRASDWNTIM", out_node);

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
    CRAS_UPDATE_CRASDWNTIM()
        - Main sub function of "CRAS_Update_Crasdwntim" function
        - Create/Update/Delete Crasdwntim definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_CRASDWNTIM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASDWNTIM_TAG CRASDWNTIM;
    char   s_sys_time[14];
	int chk_count = 0;
	int i_tran_count;
	int i;

	TRSNode ** Tran_List;


	LOG_head("CRAS_UPDATE_CRASDWNTIM");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

    if(CRAS_Update_Crasdwntim_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

	for(i = 0; i < i_tran_count; i++)
	{
		CDB_init_crasdwntim(&CRASDWNTIM);
		TRS.copy(CRASDWNTIM.WORK_DATE, sizeof(CRASDWNTIM.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CRASDWNTIM.WORK_SHIFT, sizeof(CRASDWNTIM.WORK_SHIFT), in_node, "WORK_SHIFT");
		TRS.copy(CRASDWNTIM.LINE_ID, sizeof(CRASDWNTIM.LINE_ID), Tran_List[i], "LINE_ID");
		TRS.copy(CRASDWNTIM.PROCESS_TYPE, sizeof(CRASDWNTIM.PROCESS_TYPE), Tran_List[i], "PROCESS_TYPE");
		memcpy(CRASDWNTIM.TRAN_TIME, s_sys_time, sizeof(CRASDWNTIM.TRAN_TIME));
		TRS.copy(CRASDWNTIM.REMARK, sizeof(CRASDWNTIM.REMARK), Tran_List[i], "REMARK");
		CRASDWNTIM.EFF_TIME = TRS.get_int(Tran_List[i], "EFF_TIME");

		chk_count = (int) CDB_select_crasdwntim_scalar(1,&CRASDWNTIM);
		if(chk_count > 0)
		{
			TRS.copy(CRASDWNTIM.UPDATE_USER_ID, sizeof(CRASDWNTIM.UPDATE_USER_ID), in_node,IN_USERID);
			CDB_update_crasdwntim(2, &CRASDWNTIM);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASDWNTIM UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM.WORK_DATE), CRASDWNTIM.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM.LINE_ID), CRASDWNTIM.LINE_ID);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM.WORK_SHIFT), CRASDWNTIM.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "PROCESS_TYPE", MP_STR, sizeof(CRASDWNTIM.PROCESS_TYPE), CRASDWNTIM.PROCESS_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}
		else
		{
			TRS.copy(CRASDWNTIM.CREATE_USER_ID, sizeof(CRASDWNTIM.CREATE_USER_ID), in_node, IN_USERID);
			CDB_insert_crasdwntim(&CRASDWNTIM);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASDWNTIM INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM.WORK_DATE), CRASDWNTIM.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM.LINE_ID), CRASDWNTIM.LINE_ID);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM.WORK_SHIFT), CRASDWNTIM.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "PROCESS_TYPE", MP_STR, sizeof(CRASDWNTIM.PROCESS_TYPE), CRASDWNTIM.PROCESS_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}






	}



//    CDB_init_crasdwntim(&CRASDWNTIM);
//    TRS.copy(CRASDWNTIM.WORK_DATE, sizeof(CRASDWNTIM.WORK_DATE), in_node, "WORK_DATE");
//    TRS.copy(CRASDWNTIM.LINE_ID, sizeof(CRASDWNTIM.LINE_ID), in_node, "LINE_ID");
//    TRS.copy(CRASDWNTIM.WORK_SHIFT, sizeof(CRASDWNTIM.WORK_SHIFT), in_node, "WORK_SHIFT");
//    TRS.copy(CRASDWNTIM.PROCESS_TYPE, sizeof(CRASDWNTIM.PROCESS_TYPE), in_node, "PROCESS_TYPE");
//    CRASDWNTIM.EFF_TIME = TRS.get_int(in_node, "EFF_TIME");
//    TRS.copy(CRASDWNTIM.CREATE_USER_ID, sizeof(CRASDWNTIM.CREATE_USER_ID), in_node, "CREATE_USER_ID");
//    TRS.copy(CRASDWNTIM.UPDATE_USER_ID, sizeof(CRASDWNTIM.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
//    TRS.copy(CRASDWNTIM.TRAN_TIME, sizeof(CRASDWNTIM.TRAN_TIME), in_node, "TRAN_TIME");
//    TRS.copy(CRASDWNTIM.REMARK, sizeof(CRASDWNTIM.REMARK), in_node, "REMARK");
//    TRS.copy(CRASDWNTIM.CMF_1, sizeof(CRASDWNTIM.CMF_1), in_node, "CMF_1");
//    TRS.copy(CRASDWNTIM.CMF_2, sizeof(CRASDWNTIM.CMF_2), in_node, "CMF_2");
//    TRS.copy(CRASDWNTIM.CMF_3, sizeof(CRASDWNTIM.CMF_3), in_node, "CMF_3");
//    TRS.copy(CRASDWNTIM.CMF_4, sizeof(CRASDWNTIM.CMF_4), in_node, "CMF_4");
//    TRS.copy(CRASDWNTIM.CMF_5, sizeof(CRASDWNTIM.CMF_5), in_node, "CMF_5");
//
//    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
//    {
//
//        //----[Addtional Logic for Create Case]----
//
//        /*TRS.copy(CRASDWNTIM.CREATE_USER_ID, sizeof(CRASDWNTIM.CREATE_USER_ID), in_node, IN_USERID);
//        memcpy(CRASDWNTIM.CREATE_TIME, s_sys_time, sizeof(CRASDWNTIM.CREATE_TIME));*/
//        CDB_insert_crasdwntim(&CRASDWNTIM);
//        if(DB_error_code != DB_SUCCESS)
//        {
//            strcpy(s_msg_code, "RAS-0004");
//            TRS.add_fieldmsg(out_node, "CRASDWNTIM INSERT", MP_NVST);
//            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM.WORK_DATE), CRASDWNTIM.WORK_DATE);
//            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM.LINE_ID), CRASDWNTIM.LINE_ID);
//            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM.WORK_SHIFT), CRASDWNTIM.WORK_SHIFT);
//            TRS.add_fieldmsg(out_node, "PROCESS_TYPE", MP_STR, sizeof(CRASDWNTIM.PROCESS_TYPE), CRASDWNTIM.PROCESS_TYPE);
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//            return MP_FALSE;
//        }
//    }
//    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
//    {
//        CDB_init_crasdwntim(&CRASDWNTIM_o);
//        TRS.copy(CRASDWNTIM_o.WORK_DATE, sizeof(CRASDWNTIM_o.WORK_DATE), in_node, "WORK_DATE");
//        TRS.copy(CRASDWNTIM_o.LINE_ID, sizeof(CRASDWNTIM_o.LINE_ID), in_node, "LINE_ID");
//        TRS.copy(CRASDWNTIM_o.WORK_SHIFT, sizeof(CRASDWNTIM_o.WORK_SHIFT), in_node, "WORK_SHIFT");
//        TRS.copy(CRASDWNTIM_o.PROCESS_TYPE, sizeof(CRASDWNTIM_o.PROCESS_TYPE), in_node, "PROCESS_TYPE");
//        CDB_select_crasdwntim_for_update(1, &CRASDWNTIM_o);
//        if(DB_error_code != DB_SUCCESS)
//        {
//            strcpy(s_msg_code, "RAS-0004");
//            TRS.add_fieldmsg(out_node, "CRASDWNTIM SELECT FOR UPDATE", MP_NVST);
//            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM_o.WORK_DATE), CRASDWNTIM_o.WORK_DATE);
//            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM_o.LINE_ID), CRASDWNTIM_o.LINE_ID);
//            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM_o.WORK_SHIFT), CRASDWNTIM_o.WORK_SHIFT);
//            TRS.add_fieldmsg(out_node, "PROCESS_TYPE", MP_STR, sizeof(CRASDWNTIM_o.PROCESS_TYPE), CRASDWNTIM_o.PROCESS_TYPE);
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//            return MP_FALSE;
//        }
//
//        //----[Addtional Logic for Update Case]----
//
//    /*    memcpy(CRASDWNTIM.CREATE_USER_ID, CRASDWNTIM_o.CREATE_USER_ID, sizeof(CRASDWNTIM.CREATE_USER_ID));
//        memcpy(CRASDWNTIM.CREATE_TIME, CRASDWNTIM_o.CREATE_TIME, sizeof(CRASDWNTIM.CREATE_TIME));
//        TRS.copy(CRASDWNTIM.UPDATE_USER_ID, sizeof(CRASDWNTIM.UPDATE_USER_ID), in_node, IN_USERID);
//        memcpy(CRASDWNTIM.UPDATE_TIME, s_sys_time, sizeof(CRASDWNTIM.UPDATE_TIME));
//*/
//        CDB_update_crasdwntim(1, &CRASDWNTIM);
//        if(DB_error_code != DB_SUCCESS)
//        {
//            strcpy(s_msg_code, "RAS-0004");
//            TRS.add_fieldmsg(out_node, "CRASDWNTIM UPDATE", MP_NVST);
//            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM.WORK_DATE), CRASDWNTIM.WORK_DATE);
//            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM.LINE_ID), CRASDWNTIM.LINE_ID);
//            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM.WORK_SHIFT), CRASDWNTIM.WORK_SHIFT);
//            TRS.add_fieldmsg(out_node, "PROCESS_TYPE", MP_STR, sizeof(CRASDWNTIM.PROCESS_TYPE), CRASDWNTIM.PROCESS_TYPE);
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//            return MP_FALSE;
//        }
//    }
//    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
//    {
//        CDB_delete_crasdwntim(1, &CRASDWNTIM);
//        if(DB_error_code != DB_SUCCESS)
//        {
//            strcpy(s_msg_code, "RAS-0004");
//            TRS.add_fieldmsg(out_node, "CRASDWNTIM DELETE", MP_NVST);
//            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM.WORK_DATE), CRASDWNTIM.WORK_DATE);
//            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM.LINE_ID), CRASDWNTIM.LINE_ID);
//            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM.WORK_SHIFT), CRASDWNTIM.WORK_SHIFT);
//            TRS.add_fieldmsg(out_node, "PROCESS_TYPE", MP_STR, sizeof(CRASDWNTIM.PROCESS_TYPE), CRASDWNTIM.PROCESS_TYPE);
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//            return MP_FALSE;
//        }
//    }

    /* Not use in customizing
    if(COM_proc_user_routine("CRAS", "CRAS_Update_Crasdwntim",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CRAS_Update_Crasdwntim_Validation()
        - Main sub function of "CRAS_UPDATE_CRASDWNTIM" function
        - Check the condition for create/update/delete Crasdwntim
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Crasdwntim_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
   

    return MP_TRUE;
}

