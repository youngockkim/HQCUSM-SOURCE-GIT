/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_analysis_plan_list.c
    Description : View Analysis_Plan List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Analysis_Plan_List()
            + View Analysis_Plan definition List
        - CMMS_VIEW_ANALYSIS_PLAN_LIST()
            + Main sub function of CMMS_View_Analysis_Plan_List function
            + View Analysis_Plan definition List
        - CMMS_View_Analysis_Plan_List_Validation()
            + Main sub function of CMMS_VIEW_ANALYSIS_PLAN_LIST function
            + Check the condition for view Analysis_Plan list
    Detail Description
        - CMMS_VIEW_ANALYSIS_PLAN_LIST()
            + h_proc_step
                + 1 : View Analysis_Plan definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-10             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Analysis_Plan_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Analysis_Plan_List()
        - View Analysis_Plan definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_ANALYSIS_PLAN_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_ANALYSIS_PLAN_LIST", out_node);

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
    CMMS_VIEW_ANALYSIS_PLAN_LIST()
        - Main sub function of "CMMS_View_Analysis_Plan_List" function
        - View Analysis_Plan definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_ANALYSIS_PLAN_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSANAPLN_TAG CMMSANAPLN;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CMMSEQPDEF_TAG CMMSEQPDEF;
	struct CMMSANARST_TAG CMMSANARST;

    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_ANALYSIS_PLAN_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_id", MP_NSTR, TRS.get_string(in_node, "ANA_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Analysis_Plan_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Analysis_Plan_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_cmmsanapln(&CMMSANAPLN);
    TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSANAPLN.EQUIP_ID, sizeof(CMMSANAPLN.EQUIP_ID), in_node, "EQUIP_ID");
	if(TRS.get_procstep(in_node) == '2')
	{
		i_case = 2;
		TRS.copy(CMMSANAPLN.PLAN_DATE, sizeof(CMMSANAPLN.PLAN_DATE), in_node, "FROM_DATE");
		TRS.copy(CMMSANAPLN.CMF_1, sizeof(CMMSANAPLN.PLAN_DATE), in_node, "TO_DATE");
		CMMSANAPLN.ANA_DIV = TRS.get_char(in_node, "ANA_DIV");
		TRS.copy(CMMSANAPLN.USE_DEPT_CODE, sizeof(CMMSANAPLN.USE_DEPT_CODE), in_node, "USE_DEPT_CODE");
	}

    CDB_open_cmmsanapln(i_case, &CMMSANAPLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSANAPLN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cmmsanapln(i_case, &CMMSANAPLN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmsanapln(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSANAPLN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
            TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmsanapln(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //    TRS.set_string(out_node, "NEXT_ANA_ID", CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID));
        //    CDB_close_cmmsanapln(i_case);
        //    break;
        //}

        list_item = TRS.add_node(out_node, "ANALYSIS_PLAN_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY));
        TRS.add_string(list_item, "ANA_ID", CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID));
        TRS.add_string(list_item, "EQUIP_ID", CMMSANAPLN.EQUIP_ID, sizeof(CMMSANAPLN.EQUIP_ID));
        TRS.add_string(list_item, "PLAN_DATE", CMMSANAPLN.PLAN_DATE, sizeof(CMMSANAPLN.PLAN_DATE));
        TRS.add_char(list_item, "ANA_DIV", CMMSANAPLN.ANA_DIV);
        TRS.add_string(list_item, "ANA_STATUS", CMMSANAPLN.ANA_STATUS, sizeof(CMMSANAPLN.ANA_STATUS));
        TRS.add_string(list_item, "USE_DEPT_CODE", CMMSANAPLN.USE_DEPT_CODE, sizeof(CMMSANAPLN.USE_DEPT_CODE));
        TRS.add_string(list_item, "SAMPLE_CODE", CMMSANAPLN.SAMPLE_CODE, sizeof(CMMSANAPLN.SAMPLE_CODE));
        TRS.add_int(list_item, "SAMPLE_COUNT", CMMSANAPLN.SAMPLE_COUNT);
        TRS.add_int(list_item, "USER_COUNT", CMMSANAPLN.USER_COUNT);
        TRS.add_int(list_item, "REPEAT_COUNT", CMMSANAPLN.REPEAT_COUNT);
        TRS.add_string(list_item, "JUDGE_USER_ID", CMMSANAPLN.JUDGE_USER_ID, sizeof(CMMSANAPLN.JUDGE_USER_ID));
        TRS.add_char(list_item, "ALARM_FLAG", CMMSANAPLN.ALARM_FLAG);
        TRS.add_string(list_item, "ALARM_CODE", CMMSANAPLN.ALARM_CODE, sizeof(CMMSANAPLN.ALARM_CODE));
        TRS.add_int(list_item, "ALARM_PERIOD", CMMSANAPLN.ALARM_PERIOD);
        TRS.add_string(list_item, "CMF_1", CMMSANAPLN.CMF_1, sizeof(CMMSANAPLN.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMSANAPLN.CMF_2, sizeof(CMMSANAPLN.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMSANAPLN.CMF_3, sizeof(CMMSANAPLN.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMSANAPLN.CMF_4, sizeof(CMMSANAPLN.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMSANAPLN.CMF_5, sizeof(CMMSANAPLN.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMSANAPLN.CMF_6, sizeof(CMMSANAPLN.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMSANAPLN.CMF_7, sizeof(CMMSANAPLN.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMSANAPLN.CMF_8, sizeof(CMMSANAPLN.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMSANAPLN.CMF_9, sizeof(CMMSANAPLN.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMSANAPLN.CMF_10, sizeof(CMMSANAPLN.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMSANAPLN.CREATE_USER_ID, sizeof(CMMSANAPLN.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMSANAPLN.CREATE_TIME, sizeof(CMMSANAPLN.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMSANAPLN.UPDATE_USER_ID, sizeof(CMMSANAPLN.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMSANAPLN.UPDATE_TIME, sizeof(CMMSANAPLN.UPDATE_TIME));

		CDB_init_cmmseqpdef(&CMMSEQPDEF);
		memcpy(CMMSEQPDEF.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSEQPDEF.FACTORY));
		memcpy(CMMSEQPDEF.EQUIP_ID, CMMSANAPLN.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
		CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "EQUIP_NAME", CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));
		}
		
		//GCM 조회(ANA_DIV_DESC)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ANA_MOTHOD, strlen(HQCEL_GCM_MMS_ANA_MOTHOD));
		//memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_ANALYSIS_METHOD", strlen("MMS_ANALYSIS_METHOD"));
		MGCMTBLDAT.KEY_1[0] = CMMSANAPLN.ANA_DIV;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "ANA_DIV_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//GCM 조회(ANA_DIV_DESC)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ANA_STATUS, strlen(HQCEL_GCM_MMS_ANA_STATUS));
		//memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_ANALYSIS_STATUS", strlen("MMS_ANALYSIS_STATUS"));
		memcpy(MGCMTBLDAT.KEY_1, CMMSANAPLN.ANA_STATUS, sizeof(CMMSANAPLN.ANA_STATUS));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "ANA_STATUS_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		if (TRS.get_procstep(in_node) =='2')
		{
			CDB_init_cmmsanarst(&CMMSANARST);
			memcpy(CMMSANARST.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSANARST.FACTORY));
			memcpy(CMMSANARST.ANA_ID, CMMSANAPLN.ANA_ID, sizeof(CMMSANARST.ANA_ID));
			CDB_select_cmmsanarst(2, &CMMSANARST);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "ANA_DATE", CMMSANARST.ANA_DATE, sizeof(CMMSANARST.ANA_DATE));
			}
		}
    } 

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Analysis_Plan_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Analysis_Plan_List_Validation()
        - Main sub function of "CMMS_VIEW_ANALYSIS_PLAN_LIST" function
        - Check the condition for view Analysis_Plan list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
 //   struct CMMSANAPLN_TAG CMMSANAPLN;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
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

	if(TRS.get_procstep(in_node) =='1')
	{
		/* EQUIP_ID Validation */
		if(COM_isnullspace(TRS.get_string(in_node, "EQUIP_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "MMS-0001");
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

    //CDB_init_cmmsanapln(&CMMSANAPLN);
    //TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);
    //TRS.copy(CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID), in_node, "ANA_ID");
    //CDB_select_cmmsanapln(1, &CMMSANAPLN);
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

    //    TRS.add_fieldmsg(out_node, "CMMSANAPLN SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
    //    TRS.add_fieldmsg(out_node, "ANA_ID", MP_STR, sizeof(CMMSANAPLN.ANA_ID), CMMSANAPLN.ANA_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}

