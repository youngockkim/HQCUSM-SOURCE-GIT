/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_tabber_clean.c
    Description : TABBER_CLEAN Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_TABBER_CLEAN()
            + Create/Update/Delete TABBER_CLEAN definition
        - CRAS_UPDATE_TABBER_CLEAN()
            + Main sub function of CRAS_Update_TABBER_CLEAN function
            + Create/Update/Delete TABBER_CLEAN definition
        - CRAS_Update_TABBER_CLEAN_Validation()
            + Main sub function of CRAS_UPDATE_TABBER_CLEAN function
            + Check the condition for create/update/delete TABBER_CLEAN
    Detail Description
        - CRAS_UPDATE_TABBER_CLEAN()
            + h_proc_step
                + MP_STEP_CREATE : Create TABBER_CLEAN definition
                + MP_STEP_UPDATE : Update TABBER_CLEAN definition
                + MP_STEP_DELETE : Delete TABBER_CLEAN definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-11-17             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_TABBER_CLEAN_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_TABBER_CLEAN()
        - Create/Update/Delete TABBER_CLEAN definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_TABBER_CLEAN(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_UPDATE_TABBER_CLEAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_TABBER_CLEAN", out_node);

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
    CRAS_UPDATE_TABBER_CLEAN()
        - Main sub function of "CRAS_Update_TABBER_CLEAN" function
        - Create/Update/Delete TABBER_CLEAN definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_TABBER_CLEAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASCLNPLN_TAG CRASCLNPLN;
	struct MWIPCALDEF_TAG MWIPCALDEF;

    char   s_sys_time[14];
	char   varday;
	int i_tran_count;
	int i;

	
	TRSNode ** Tran_List;

    LOG_head("CRAS_UPDATE_TABBER_CLEAN");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* Not use in customizing
    if(COM_proc_user_routine("CRAS", "CRAS_Update_TABBER_CLEAN",
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
	
	



	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");
	
	//1.WORK_DATE 기준으로 년.월.WEEK를 구한다.
	DBC_init_mwipcaldef(&MWIPCALDEF);
	memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); 
    MWIPCALDEF.CALENDAR_TYPE = 'F';
	TRS.copy(MWIPCALDEF.SYS_DATE, sizeof(MWIPCALDEF.SYS_DATE), in_node, "WORK_DATE");
	   
    DBC_select_mwipcaldef(5, &MWIPCALDEF);


	for(i = 0; i < i_tran_count; i++)
	{
		if (TRS.get_procstep(in_node) == MP_STEP_CREATE )
        {
			CDB_init_crasclnpln(&CRASCLNPLN);
			TRS.copy(CRASCLNPLN.FACTORY, sizeof(CRASCLNPLN.FACTORY), in_node, IN_FACTORY);
			
			CRASCLNPLN.PLAN_YEAR = MWIPCALDEF.PLAN_YEAR;
			CRASCLNPLN.PLAN_WEEK = MWIPCALDEF.PLAN_WEEK;

			TRS.copy(CRASCLNPLN.WORK_SHIFT, sizeof(CRASCLNPLN.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASCLNPLN.LINE_ID, sizeof(CRASCLNPLN.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASCLNPLN.RES_ID, sizeof(CRASCLNPLN.RES_ID), Tran_List[i], "RES_ID");

			TRS.copy(CRASCLNPLN.CMF_1, sizeof(CRASCLNPLN.CMF_1), in_node, IN_USERID);
			memcpy(CRASCLNPLN.CREATE_TIME, s_sys_time, sizeof(CRASCLNPLN.CREATE_TIME));

			CDB_insert_crasclnpln(&CRASCLNPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASCLNPLN INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
				TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASCLNPLN.RES_ID), CRASCLNPLN.RES_ID);
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


			CDB_init_crasclnpln(&CRASCLNPLN);
			TRS.copy(CRASCLNPLN.FACTORY, sizeof(CRASCLNPLN.FACTORY), in_node, IN_FACTORY);
			CRASCLNPLN.PLAN_YEAR = MWIPCALDEF.PLAN_YEAR;
			CRASCLNPLN.PLAN_WEEK = MWIPCALDEF.PLAN_WEEK;
			
			TRS.copy(CRASCLNPLN.WORK_SHIFT, sizeof(CRASCLNPLN.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASCLNPLN.LINE_ID, sizeof(CRASCLNPLN.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASCLNPLN.RES_ID, sizeof(CRASCLNPLN.RES_ID), Tran_List[i], "RES_ID");

			CDB_select_crasclnpln(1, &CRASCLNPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASCLNPLN SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
				TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASCLNPLN.RES_ID), CRASCLNPLN.RES_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			
			varday= TRS.get_char(Tran_List[i], "CLEAN_DAY");
			TRS.copy(CRASCLNPLN.CMF_2, sizeof(CRASCLNPLN.CMF_2), Tran_List[i], "CMF_2");
			if(varday == '1')
			{
				TRS.copy(CRASCLNPLN.CLEAN1_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN1_PLAN_TIME), Tran_List[i], "CLEAN_TIME");
				CRASCLNPLN.CLEAN1_FLAG = TRS.get_char(Tran_List[i], "COM_FLAG");
				if(CRASCLNPLN.CLEAN1_FLAG == 'Y')
				{
					memcpy(CRASCLNPLN.CLEAN1_COM_DT, s_sys_time, sizeof(CRASCLNPLN.CLEAN1_COM_DT));
				}
				else
				{
					memset(CRASCLNPLN.CLEAN1_COM_DT, 0x00, sizeof(CRASCLNPLN.CLEAN1_COM_DT));
				}


			}
			else if(varday == '2')
			{
				TRS.copy(CRASCLNPLN.CLEAN2_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN2_PLAN_TIME), Tran_List[i], "CLEAN_TIME");
				CRASCLNPLN.CLEAN2_FLAG = TRS.get_char(Tran_List[i], "COM_FLAG");
				if(CRASCLNPLN.CLEAN2_FLAG == 'Y')
				{
					memcpy(CRASCLNPLN.CLEAN2_COM_DT, s_sys_time, sizeof(CRASCLNPLN.CLEAN2_COM_DT));
				}
				else
				{
					memset(CRASCLNPLN.CLEAN2_COM_DT, 0x00, sizeof(CRASCLNPLN.CLEAN2_COM_DT));
				}
			}
			else if(varday == '3')
			{
				TRS.copy(CRASCLNPLN.CLEAN3_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN3_PLAN_TIME), Tran_List[i], "CLEAN_TIME");
				CRASCLNPLN.CLEAN3_FLAG = TRS.get_char(Tran_List[i], "COM_FLAG");

				if(CRASCLNPLN.CLEAN3_FLAG == 'Y')
				{
					memcpy(CRASCLNPLN.CLEAN3_COM_DT, s_sys_time, sizeof(CRASCLNPLN.CLEAN3_COM_DT));
				}
				else
				{
					memset(CRASCLNPLN.CLEAN3_COM_DT, 0x00, sizeof(CRASCLNPLN.CLEAN3_COM_DT));
				}
			}
			else if(varday == '4')
			{
				TRS.copy(CRASCLNPLN.CLEAN4_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN4_PLAN_TIME), Tran_List[i], "CLEAN_TIME");
				CRASCLNPLN.CLEAN4_FLAG = TRS.get_char(Tran_List[i], "COM_FLAG");
				if(CRASCLNPLN.CLEAN4_FLAG == 'Y')
				{
					memcpy(CRASCLNPLN.CLEAN4_COM_DT, s_sys_time, sizeof(CRASCLNPLN.CLEAN4_COM_DT));
				}
				else
				{
					memset(CRASCLNPLN.CLEAN4_COM_DT, 0x00, sizeof(CRASCLNPLN.CLEAN4_COM_DT));
				}

			}
			else if(varday == '5')
			{
				TRS.copy(CRASCLNPLN.CLEAN5_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN5_PLAN_TIME), Tran_List[i], "CLEAN_TIME");
				CRASCLNPLN.CLEAN5_FLAG = TRS.get_char(Tran_List[i], "COM_FLAG");
				if(CRASCLNPLN.CLEAN5_FLAG == 'Y')
				{
					memcpy(CRASCLNPLN.CLEAN5_COM_DT, s_sys_time, sizeof(CRASCLNPLN.CLEAN5_COM_DT));
				}
				else
				{
					memset(CRASCLNPLN.CLEAN5_COM_DT, 0x00, sizeof(CRASCLNPLN.CLEAN5_COM_DT));
				}
			}
			else if(varday == '6')
			{
				TRS.copy(CRASCLNPLN.CLEAN6_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN6_PLAN_TIME), Tran_List[i], "CLEAN_TIME");
				CRASCLNPLN.CLEAN6_FLAG = TRS.get_char(Tran_List[i], "COM_FLAG");
				if(CRASCLNPLN.CLEAN6_FLAG == 'Y')
				{
					memcpy(CRASCLNPLN.CLEAN6_COM_DT, s_sys_time, sizeof(CRASCLNPLN.CLEAN6_COM_DT));
				}
				else
				{
					memset(CRASCLNPLN.CLEAN6_COM_DT, 0x00, sizeof(CRASCLNPLN.CLEAN6_COM_DT));
				}


			}
			else if(varday == '7')
			{
				TRS.copy(CRASCLNPLN.CLEAN7_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN7_PLAN_TIME), Tran_List[i], "CLEAN_TIME");
				CRASCLNPLN.CLEAN7_FLAG = TRS.get_char(Tran_List[i], "COM_FLAG");

				if(CRASCLNPLN.CLEAN7_FLAG == 'Y')
				{
					memcpy(CRASCLNPLN.CLEAN7_COM_DT, s_sys_time, sizeof(CRASCLNPLN.CLEAN7_COM_DT));
				}
				else
				{
					memset(CRASCLNPLN.CLEAN7_COM_DT, 0x00, sizeof(CRASCLNPLN.CLEAN7_COM_DT));
				}

			}
			else
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "Please Check Date Time", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
				TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASCLNPLN.RES_ID), CRASCLNPLN.RES_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}


			CDB_update_crasclnpln(1, &CRASCLNPLN);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASCLNPLN UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
				TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASCLNPLN.RES_ID), CRASCLNPLN.RES_ID);
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
    CRAS_Update_TABBER_CLEAN_Validation()
        - Main sub function of "CRAS_UPDATE_TABBER_CLEAN" function
        - Check the condition for create/update/delete TABBER_CLEAN
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_TABBER_CLEAN_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct CRASCLNPLN_TAG CRASCLNPLN;
    //struct MWIPFACDEF_TAG MWIPFACDEF;

    ///* ProcStep Validation */
    //if(COM_service_validation(s_msg_code,
    //                          in_node,
    //                          out_node,
    //                          TRS.get_procstep(in_node),
    //                          "IUD") == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    ///* Factory Validation */
    //if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "RAS-0001");
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    return MP_FALSE;
    //}

    //DBC_init_mwipfacdef(&MWIPFACDEF);
    //TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    //DBC_select_mwipfacdef(1, &MWIPFACDEF);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    strcpy(s_msg_code, "WIP-0005");
    //    TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
    //    TRS.add_dberrmsg(out_node, DB_error_msg);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    return MP_FALSE;
    //}

    ///* PLAN_YEAR Validation */
    //if(TRS.get_int(in_node, "PLAN_YEAR") == 0)
    //{
    //    strcpy(s_msg_code, "RAS-0001");
    //    TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* PLAN_WEEK Validation */
    //if(TRS.get_int(in_node, "PLAN_WEEK") == 0)
    //{
    //    strcpy(s_msg_code, "RAS-0001");
    //    TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* WORK_SHIFT Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "RAS-0001");
    //    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* LINE_ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "RAS-0001");
    //    TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* RES_ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "RAS-0001");
    //    TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    //CDB_init_crasclnpln(&CRASCLNPLN);
    //TRS.copy(CRASCLNPLN.FACTORY, sizeof(CRASCLNPLN.FACTORY), in_node, IN_FACTORY);
    //CRASCLNPLN.PLAN_YEAR = TRS.get_int(in_node, "PLAN_YEAR");
    //CRASCLNPLN.PLAN_WEEK = TRS.get_int(in_node, "PLAN_WEEK");
    //TRS.copy(CRASCLNPLN.WORK_SHIFT, sizeof(CRASCLNPLN.WORK_SHIFT), in_node, "WORK_SHIFT");
    //TRS.copy(CRASCLNPLN.LINE_ID, sizeof(CRASCLNPLN.LINE_ID), in_node, "LINE_ID");
    //TRS.copy(CRASCLNPLN.RES_ID, sizeof(CRASCLNPLN.RES_ID), in_node, "RES_ID");
    //CDB_select_crasclnpln(1, &CRASCLNPLN);
    //if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    //{
    //    if(DB_error_code == DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "RAS-XXXX");
    //        TRS.add_fieldmsg(out_node, "CRASCLNPLN SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
    //        TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
    //        TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
    //        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
    //        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
    //        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASCLNPLN.RES_ID), CRASCLNPLN.RES_ID);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}
    //else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    //{
    //    if(DB_error_code != DB_SUCCESS)
    //    {
    //        if(DB_error_code == DB_NOT_FOUND)
    //        {
    //            strcpy(s_msg_code, "RAS-XXXX");
    //            gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        }
    //        else
    //        {
    //            strcpy(s_msg_code, "RAS-0004");
    //            TRS.add_dberrmsg(out_node, DB_error_msg);

    //            gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        }

    //        TRS.add_fieldmsg(out_node, "CRASCLNPLN SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
    //        TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
    //        TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
    //        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
    //        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
    //        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASCLNPLN.RES_ID), CRASCLNPLN.RES_ID);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.category = MP_LOG_CATE_SETUP;
    //        return MP_FALSE;
    //    }
    //}

    //return MP_TRUE;
}

