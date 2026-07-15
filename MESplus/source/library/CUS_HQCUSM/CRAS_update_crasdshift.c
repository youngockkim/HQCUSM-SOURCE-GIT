/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_crasdshift.c
    Description : Crasdshift Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_Crasdshift()
            + Create/Update/Delete Crasdshift definition
        - CRAS_UPDATE_CRASDSHIFT()
            + Main sub function of CRAS_Update_Crasdshift function
            + Create/Update/Delete Crasdshift definition
        - CRAS_Update_Crasdshift_Validation()
            + Main sub function of CRAS_UPDATE_CRASDSHIFT function
            + Check the condition for create/update/delete Crasdshift
    Detail Description
        - CRAS_UPDATE_CRASDSHIFT()
            + h_proc_step
                + MP_STEP_CREATE : Create Crasdshift definition
                + MP_STEP_UPDATE : Update Crasdshift definition
                + MP_STEP_DELETE : Delete Crasdshift definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-04-20             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_Crasdshift_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_Crasdshift()
        - Create/Update/Delete Crasdshift definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Crasdshift(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_UPDATE_CRASDSHIFT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_CRASDSHIFT", out_node);

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
    CRAS_UPDATE_CRASDSHIFT()
        - Main sub function of "CRAS_Update_Crasdshift" function
        - Create/Update/Delete Crasdshift definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_CRASDSHIFT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASDSHIFT_TAG CRASDSHIFT;
	struct CRASSFTHIS_TAG CRASSFTHIS;

    char   s_sys_time[14];
	int i_tran_count;
	int i;
	int chk_count = 0;
	int chk_count_his = 0;

	TRSNode ** Tran_List;

	LOG_head("CRAS_UPDATE_CRASDSHIFT");
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

    if(CRAS_Update_Crasdshift_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

	for(i = 0; i < i_tran_count; i++)
	{


		CDB_init_crasdshift(&CRASDSHIFT);
		TRS.copy(CRASDSHIFT.WORK_DATE, sizeof(CRASDSHIFT.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CRASDSHIFT.WORK_SHIFT, sizeof(CRASDSHIFT.WORK_SHIFT), in_node, "WORK_SHIFT");
		TRS.copy(CRASDSHIFT.LINE_ID, sizeof(CRASDSHIFT.LINE_ID), Tran_List[i], "LINE_ID");
		memcpy(CRASDSHIFT.TRAN_TIME, s_sys_time, sizeof(CRASDSHIFT.TRAN_TIME));

		CRASDSHIFT.RW = TRS.get_int(Tran_List[i], "RW");
		CRASDSHIFT.FRA = TRS.get_int(Tran_List[i], "FRA");
		CRASDSHIFT.ETC = TRS.get_int(Tran_List[i], "ETC");
		CRASDSHIFT.OK = TRS.get_int(Tran_List[i], "OK");
		CRASDSHIFT.NG = TRS.get_int(Tran_List[i], "NG");
		COM_itoa_left(CRASDSHIFT.CMF_1, TRS.get_int(Tran_List[i], "Repair"), sizeof(CRASDSHIFT.CMF_1));
		//COM_itoa_left(CRASDSHIFT.CMF_2, TRS.get_int(Tran_List[i], "TABBERS"), sizeof(CRASDSHIFT.CMF_2));
		//COM_itoa_left(CRASDSHIFT.CMF_3, TRS.get_int(Tran_List[i], "AMR_CART"), sizeof(CRASDSHIFT.CMF_3));
		//COM_itoa_left(CRASDSHIFT.CMF_4, TRS.get_int(Tran_List[i], "STRING_REPAIR"), sizeof(CRASDSHIFT.CMF_4));
		//COM_itoa_left(CRASDSHIFT.CMF_5, TRS.get_int(Tran_List[i], "MODULE_REPAIR"), sizeof(CRASDSHIFT.CMF_5));
		
		chk_count = (int) CDB_select_crasdshift_scalar(1,&CRASDSHIFT);
		if(chk_count > 0)
		{
			TRS.copy(CRASDSHIFT.UPDATE_USER_ID, sizeof(CRASDSHIFT.UPDATE_USER_ID), in_node,IN_USERID);
			CDB_update_crasdshift(2, &CRASDSHIFT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CRAS-0004");
				TRS.add_fieldmsg(out_node, "CRASDSHIFT UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT.WORK_DATE), CRASDSHIFT.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT.LINE_ID), CRASDSHIFT.LINE_ID);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT.WORK_SHIFT), CRASDSHIFT.WORK_SHIFT);
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
			TRS.copy(CRASDSHIFT.CREATE_USER_ID, sizeof(CRASDSHIFT.CREATE_USER_ID), in_node, IN_USERID);
			CDB_insert_crasdshift(&CRASDSHIFT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASDSHIFT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT.WORK_DATE), CRASDSHIFT.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT.LINE_ID), CRASDSHIFT.LINE_ID);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT.WORK_SHIFT), CRASDSHIFT.WORK_SHIFT);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}	
		}




	}

	CDB_init_crassfthis(&CRASSFTHIS);
	TRS.copy(CRASSFTHIS.FACTORY, sizeof(CRASSFTHIS.FACTORY), in_node, "FACTORY");
	TRS.copy(CRASSFTHIS.WORK_DATE, sizeof(CRASSFTHIS.WORK_DATE), in_node, "WORK_DATE"); 
	TRS.copy(CRASSFTHIS.WORK_SHIFT, sizeof(CRASSFTHIS.WORK_SHIFT), in_node, "WORK_SHIFT");  
	TRS.copy(CRASSFTHIS.FACTORY_NO, sizeof(CRASSFTHIS.FACTORY_NO), in_node, "LINE_LOCATION");  
	TRS.copy(CRASSFTHIS.SHIFT_COMMENT, sizeof(CRASSFTHIS.SHIFT_COMMENT), in_node, "SHIFT_COMMENT");  

	chk_count_his = (int) CDB_select_crassfthis_scalar(1,&CRASSFTHIS);
	if(chk_count_his > 0)
	{
		TRS.copy(CRASSFTHIS.UPDATE_USER_ID, sizeof(CRASSFTHIS.UPDATE_USER_ID), in_node,IN_USERID);
		memcpy(CRASSFTHIS.UPDATE_TIME, s_sys_time, sizeof(CRASSFTHIS.UPDATE_TIME));
		CDB_update_crassfthis(1, &CRASSFTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "CRAS-0004");
			TRS.add_fieldmsg(out_node, "CRASSFTHIS UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASSFTHIS.WORK_DATE), CRASSFTHIS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASSFTHIS.WORK_SHIFT), CRASSFTHIS.WORK_SHIFT);
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
		TRS.copy(CRASSFTHIS.CREATE_USER_ID, sizeof(CRASSFTHIS.CREATE_USER_ID), in_node, IN_USERID);
		memcpy(CRASSFTHIS.CREATE_TIME, s_sys_time, sizeof(CRASSFTHIS.CREATE_TIME));
		CDB_insert_crassfthis(&CRASSFTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CRASSFTHIS INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASSFTHIS.WORK_DATE), CRASSFTHIS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASSFTHIS.WORK_SHIFT), CRASSFTHIS.WORK_SHIFT);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}	
	}

    //CDB_init_crasdshift(&CRASDSHIFT);
    //TRS.copy(CRASDSHIFT.WORK_DATE, sizeof(CRASDSHIFT.WORK_DATE), in_node, "WORK_DATE");
    //TRS.copy(CRASDSHIFT.LINE_ID, sizeof(CRASDSHIFT.LINE_ID), in_node, "LINE_ID");
    //TRS.copy(CRASDSHIFT.WORK_SHIFT, sizeof(CRASDSHIFT.WORK_SHIFT), in_node, "WORK_SHIFT");
    //CRASDSHIFT.RW = TRS.get_int(in_node, "RW");
    //CRASDSHIFT.FRA = TRS.get_int(in_node, "FRA");
    //CRASDSHIFT.ETC = TRS.get_int(in_node, "ETC");
    //CRASDSHIFT.OK = TRS.get_int(in_node, "OK");
    //CRASDSHIFT.NG = TRS.get_int(in_node, "NG");
    //TRS.copy(CRASDSHIFT.CREATE_USER_ID, sizeof(CRASDSHIFT.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    //TRS.copy(CRASDSHIFT.UPDATE_USER_ID, sizeof(CRASDSHIFT.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    //TRS.copy(CRASDSHIFT.TRAN_TIME, sizeof(CRASDSHIFT.TRAN_TIME), in_node, "TRAN_TIME");
    //TRS.copy(CRASDSHIFT.CMF_1, sizeof(CRASDSHIFT.CMF_1), in_node, "CMF_1");
    //TRS.copy(CRASDSHIFT.CMF_2, sizeof(CRASDSHIFT.CMF_2), in_node, "CMF_2");
    //TRS.copy(CRASDSHIFT.CMF_3, sizeof(CRASDSHIFT.CMF_3), in_node, "CMF_3");
    //TRS.copy(CRASDSHIFT.CMF_4, sizeof(CRASDSHIFT.CMF_4), in_node, "CMF_4");
    //TRS.copy(CRASDSHIFT.CMF_5, sizeof(CRASDSHIFT.CMF_5), in_node, "CMF_5");

    //if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    //{

    //    //----[Addtional Logic for Create Case]----

    //    TRS.copy(CRASDSHIFT.CREATE_USER_ID, sizeof(CRASDSHIFT.CREATE_USER_ID), in_node, IN_USERID);
    //    //memcpy(CRASDSHIFT.CREATE_TIME, s_sys_time, sizeof(CRASDSHIFT.CREATE_TIME));
    //    CDB_insert_crasdshift(&CRASDSHIFT);
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "CRAS-0004");
    //        TRS.add_fieldmsg(out_node, "CRASDSHIFT INSERT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT.WORK_DATE), CRASDSHIFT.WORK_DATE);
    //        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT.LINE_ID), CRASDSHIFT.LINE_ID);
    //        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT.WORK_SHIFT), CRASDSHIFT.WORK_SHIFT);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}
    //else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    //{
    //    CDB_init_crasdshift(&CRASDSHIFT_o);
    //    TRS.copy(CRASDSHIFT_o.WORK_DATE, sizeof(CRASDSHIFT_o.WORK_DATE), in_node, "WORK_DATE");
    //    TRS.copy(CRASDSHIFT_o.LINE_ID, sizeof(CRASDSHIFT_o.LINE_ID), in_node, "LINE_ID");
    //    TRS.copy(CRASDSHIFT_o.WORK_SHIFT, sizeof(CRASDSHIFT_o.WORK_SHIFT), in_node, "WORK_SHIFT");
    //    CDB_select_crasdshift_for_update(1, &CRASDSHIFT_o);
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "CRAS-0004");
    //        TRS.add_fieldmsg(out_node, "CRASDSHIFT SELECT FOR UPDATE", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT_o.WORK_DATE), CRASDSHIFT_o.WORK_DATE);
    //        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT_o.LINE_ID), CRASDSHIFT_o.LINE_ID);
    //        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT_o.WORK_SHIFT), CRASDSHIFT_o.WORK_SHIFT);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }

    //    //----[Addtional Logic for Update Case]----

    //   /* memcpy(CRASDSHIFT.CREATE_USER_ID, CRASDSHIFT_o.CREATE_USER_ID, sizeof(CRASDSHIFT.CREATE_USER_ID));
    //    memcpy(CRASDSHIFT.CREATE_TIME, CRASDSHIFT_o.CREATE_TIME, sizeof(CRASDSHIFT.CREATE_TIME));
    //    TRS.copy(CRASDSHIFT.UPDATE_USER_ID, sizeof(CRASDSHIFT.UPDATE_USER_ID), in_node, IN_USERID);
    //    memcpy(CRASDSHIFT.UPDATE_TIME, s_sys_time, sizeof(CRASDSHIFT.UPDATE_TIME));*/

    //    CDB_update_crasdshift(1, &CRASDSHIFT);
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "CRAS-0004");
    //        TRS.add_fieldmsg(out_node, "CRASDSHIFT UPDATE", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT.WORK_DATE), CRASDSHIFT.WORK_DATE);
    //        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT.LINE_ID), CRASDSHIFT.LINE_ID);
    //        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT.WORK_SHIFT), CRASDSHIFT.WORK_SHIFT);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}
    //else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    //{
    //    CDB_delete_crasdshift(1, &CRASDSHIFT);
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "CRAS-0004");
    //        TRS.add_fieldmsg(out_node, "CRASDSHIFT DELETE", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT.WORK_DATE), CRASDSHIFT.WORK_DATE);
    //        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT.LINE_ID), CRASDSHIFT.LINE_ID);
    //        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT.WORK_SHIFT), CRASDSHIFT.WORK_SHIFT);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}

    /* Not use in customizing
    if(COM_proc_user_routine("CRAS", "CRAS_Update_Crasdshift",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CRAS_Update_Crasdshift_Validation()
        - Main sub function of "CRAS_UPDATE_CRASDSHIFT" function
        - Check the condition for create/update/delete Crasdshift
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Crasdshift_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "RAS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

   

    return MP_TRUE;
}

