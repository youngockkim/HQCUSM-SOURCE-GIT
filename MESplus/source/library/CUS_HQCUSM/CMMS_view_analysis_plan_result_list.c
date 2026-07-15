/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_analysis_plan_result_list.c
    Description : View Analysis_Plan Result List function module

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

int CMMS_View_Analysis_Plan_Result_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Analysis_Plan_List()
        - View Analysis_Plan definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan_Result_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST(s_msg_code, in_node, out_node);

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
    CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST()
        - Main sub function of "CMMS_View_Analysis_Plan_ResultList" function
        - View Analysis_Plan definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct ANA_RST_TAG ANA_RST;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CMMSSAMDEF_TAG CMMSSAMDEF;

    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("ana_div", MP_CHR, TRS.get_char(in_node, "ANA_DIV"));
	LOG_add("plan_date", MP_NSTR, TRS.get_string(in_node, "PLAN_DATE"));
	LOG_add("ana_date", MP_NSTR, TRS.get_string(in_node, "ANA_DATE"));
	LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
	LOG_add("mgt_dept_code", MP_NSTR, TRS.get_string(in_node, "MGT_DEPT_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Analysis_Plan_Result_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Analysis_Plan_Result_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_ana_result_join(&ANA_RST);
    TRS.copy(ANA_RST.FACTORY, sizeof(ANA_RST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(ANA_RST.PLAN_DATE, sizeof(ANA_RST.PLAN_DATE), in_node, "PLAN_DATE");
	TRS.copy(ANA_RST.ANA_DATE, sizeof(ANA_RST.ANA_DATE), in_node, "ANA_DATE");
	TRS.copy(ANA_RST.EQUIP_ID, sizeof(ANA_RST.EQUIP_ID), in_node, "EQUIP_ID");
	TRS.copy(ANA_RST.MGT_DEPT_CODE, sizeof(ANA_RST.MGT_DEPT_CODE), in_node, "MGT_DEPT_CODE");
	ANA_RST.ANA_DIV = TRS.get_char(in_node, "ANA_DIV");

    CDB_open_ana_result_join(i_case, &ANA_RST);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "ANA_RESULT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(ANA_RST.FACTORY), ANA_RST.FACTORY);
        TRS.add_fieldmsg(out_node, "FROM_DATE", MP_STR, sizeof(ANA_RST.PLAN_DATE), ANA_RST.PLAN_DATE);
		TRS.add_fieldmsg(out_node, "TO_DATE", MP_STR, sizeof(ANA_RST.ANA_DATE), ANA_RST.ANA_DATE);
		TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(ANA_RST.EQUIP_ID), ANA_RST.EQUIP_ID);
		TRS.add_fieldmsg(out_node, "ANA_DIV", MP_CHR, ANA_RST.ANA_DIV);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_ana_result_join(i_case, &ANA_RST);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_ana_result_join(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "ANA_RESULT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(ANA_RST.FACTORY), ANA_RST.FACTORY);
			TRS.add_fieldmsg(out_node, "FROM_DATE", MP_STR, sizeof(ANA_RST.PLAN_DATE), ANA_RST.PLAN_DATE);
			TRS.add_fieldmsg(out_node, "TO_DATE", MP_STR, sizeof(ANA_RST.ANA_DATE), ANA_RST.ANA_DATE);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(ANA_RST.EQUIP_ID), ANA_RST.EQUIP_ID);
			TRS.add_fieldmsg(out_node, "ANA_DIV", MP_CHR, ANA_RST.ANA_DIV);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_ana_result_join(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //    TRS.set_string(out_node, "NEXT_ANA_ID", CMMSANAPLN.ANA_ID, sizeof(CMMSANAPLN.ANA_ID));
        //    CDB_close_cmmsanapln(i_case);
        //    break;
        //}

        list_item = TRS.add_node(out_node, "ANALYSIS_PLAN_RESULT_LIST");

        TRS.add_string(list_item, "FACTORY", ANA_RST.FACTORY, sizeof(ANA_RST.FACTORY));
        TRS.add_string(list_item, "ANA_ID", ANA_RST.ANA_ID, sizeof(ANA_RST.ANA_ID));
        TRS.add_string(list_item, "EQUIP_ID", ANA_RST.EQUIP_ID, sizeof(ANA_RST.EQUIP_ID));
		TRS.add_string(list_item, "EQUIP_NAME", ANA_RST.EQUIP_NAME, sizeof(ANA_RST.EQUIP_NAME));
        TRS.add_string(list_item, "PLAN_DATE", ANA_RST.PLAN_DATE, sizeof(ANA_RST.PLAN_DATE));
		TRS.add_string(list_item, "ANA_DATE", ANA_RST.ANA_DATE, sizeof(ANA_RST.ANA_DATE));
		TRS.add_char(list_item, "ANA_RESULT", ANA_RST.ANA_RESULT);
        TRS.add_string(list_item, "SAMPLE_CODE", ANA_RST.SAMPLE_CODE, sizeof(ANA_RST.SAMPLE_CODE));
        TRS.add_int(list_item, "SAMPLE_COUNT", ANA_RST.SAMPLE_COUNT);
        TRS.add_int(list_item, "USER_COUNT", ANA_RST.USER_COUNT);
        TRS.add_int(list_item, "REPEAT_COUNT", ANA_RST.REPEAT_COUNT);
		TRS.add_string(list_item, "ITEM_CODE", ANA_RST.ITEM_CODE, sizeof(ANA_RST.ITEM_CODE));
		TRS.add_string(list_item, "ITEM_NAME", ANA_RST.ITEM_NAME, sizeof(ANA_RST.ITEM_NAME));
		TRS.add_double(list_item, "LSL", ANA_RST.LSL);
		TRS.add_double(list_item, "USL", ANA_RST.USL);
		TRS.add_string(list_item, "UNIT_CODE", ANA_RST.ITEM_CODE, sizeof(ANA_RST.UNIT_CODE));
		TRS.add_int(list_item, "DECIMAL_PLACE", ANA_RST.DECIMAL_PLACE);
        TRS.add_string(list_item, "CREATE_USER_ID", ANA_RST.CREATE_USER_ID, sizeof(ANA_RST.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", ANA_RST.CREATE_TIME, sizeof(ANA_RST.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", ANA_RST.UPDATE_USER_ID, sizeof(ANA_RST.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", ANA_RST.UPDATE_TIME, sizeof(ANA_RST.UPDATE_TIME));

		
		//GCM Á¶È¸(UNIT_CODE)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(ANA_RST.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_UNIT, strlen(HQCEL_GCM_MMS_UNIT));
		//memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_UNIT", strlen("MMS_UNIT"));
		memcpy(MGCMTBLDAT.KEY_1, ANA_RST.UNIT_CODE, sizeof(MGCMTBLDAT.KEY_1));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "UNIT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		//SAMPLE_DESC
		CDB_init_cmmssamdef(&CMMSSAMDEF);
		TRS.copy(CMMSSAMDEF.FACTORY, sizeof(CMMSSAMDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(CMMSSAMDEF.SAMPLE_CODE, ANA_RST.SAMPLE_CODE, sizeof(CMMSSAMDEF.SAMPLE_CODE));
		CDB_select_cmmssamdef(1, &CMMSSAMDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "SAMPLE_NAME", CMMSSAMDEF.SAMPLE_NAME, sizeof(CMMSSAMDEF.SAMPLE_NAME));
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
    CMMS_View_Analysis_Plan_Result_List_Validation()
        - Main sub function of "CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST" function
        - Check the condition for view Analysis_Plan_Result list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Analysis_Plan_Result_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
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

	///* EQUIP_ID Validation */
	//if(COM_isnullspace(TRS.get_string(in_node, "PLAN_DATE")) == MP_TRUE)
	//{
	//	strcpy(s_msg_code, "MMS-0001");
	//	TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

	//	gs_log_type.type = MP_LOG_ERROR;
	//	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//	gs_log_type.category = MP_LOG_CATE_VIEW;
	//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//	return MP_FALSE;
	//}

	///* EQUIP_ID Validation */
	//if(COM_isnullspace(TRS.get_string(in_node, "ANA_DATE")) == MP_TRUE)
	//{
	//	strcpy(s_msg_code, "MMS-0001");
	//	TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

	//	gs_log_type.type = MP_LOG_ERROR;
	//	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//	gs_log_type.category = MP_LOG_CATE_VIEW;
	//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//	return MP_FALSE;
	//}

    return MP_TRUE;
}

