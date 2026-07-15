/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_equipment_Ledger_list.c
    Description : View Equipment_Ledger List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Equipment_Ledger_List()
            + View Equipment_Ledger definition List
        - CMMS_VIEW_EQUIPMENT_LEDGER_LIST()
            + Main sub function of CMMS_View_Equipment_Ledger_List function
            + View Equipment_Ledger definition List
    Detail Description
        - CMMS_VIEW_EQUIPMENT_LEDGER_LIST()
            + h_proc_step
                + 1 : View Equipment_Ledger definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-04-17             Create by yyk

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Equipment_Ledger_List()
        - View Equipment_Ledger definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Equipment_Ledger_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_EQUIPMENT_LEDGER_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_EQUIPMENT_LEDGER_LIST", out_node);

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
    CMMS_VIEW_EQUIPMENT_LEDGER_LIST()
        - Main sub function of "CMMS_View_Equipment_Ledger_List" function
        - View Equipment_Ledger definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_EQUIPMENT_LEDGER_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMS_JOIN_TAG CMMS_JOIN;
	struct CALI_JOIN_TAG CALI_JOIN;
	struct ANA_JOIN_TAG ANA_JOIN;
    TRSNode *list_item;
	TRSNode *cali_item;
	TRSNode *ana_item;

	int i_case;
	int i_max_count;

    LOG_head("CMMS_VIEW_EQUIPMENT_LEDGER_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("prev_year", MP_NSTR, TRS.get_string(in_node, "PREV_YEAR"));
	LOG_add("plan_year", MP_NSTR, TRS.get_string(in_node, "PLAN_YEAR"));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
	LOG_add("mgt_dept_code", MP_NSTR, TRS.get_string(in_node, "MGT_DEPT_CODE"));
	LOG_add("equip_place_code", MP_NSTR, TRS.get_string(in_node, "EQUIP_PLACE_CODE"));
	LOG_add("msa_flag", MP_CHR, TRS.get_char(in_node, "MSA_FLAG"));
    LOG_add("spc_flag", MP_CHR, TRS.get_char(in_node, "SPC_FLAG"));
    LOG_add("cali_flag", MP_CHR, TRS.get_char(in_node, "CALI_FLAG"));
    LOG_add("check_flag", MP_CHR, TRS.get_char(in_node, "CHECK_FLAG"));
    LOG_add("none_flag", MP_CHR, TRS.get_char(in_node, "NONE_FLAG"));
    LOG_add("standard_flag", MP_CHR, TRS.get_char(in_node, "STANDARD_FLAG"));

    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Equipment_Ledger_List",
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

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    //* PREV_YEAR Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "PREV_YEAR")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "PREV_YEAR", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//* PLAN_YEAR Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "PLAN_YEAR")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	i_max_count = 1;
	i_case = 1;
    CDB_init_cmms_join(&CMMS_JOIN);
    TRS.copy(CMMS_JOIN.FACTORY, sizeof(CMMS_JOIN.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CMMS_JOIN.PREV_YEAR, sizeof(CMMS_JOIN.PREV_YEAR), in_node, "PREV_YEAR");
	TRS.copy(CMMS_JOIN.PLAN_YEAR, sizeof(CMMS_JOIN.PLAN_YEAR), in_node, "PLAN_YEAR");
	TRS.copy(CMMS_JOIN.EQUIP_ID, sizeof(CMMS_JOIN.EQUIP_ID), in_node, "EQUIP_ID");
	TRS.copy(CMMS_JOIN.EQUIP_TYPE, sizeof(CMMS_JOIN.EQUIP_TYPE), in_node, "EQUIP_TYPE");
	TRS.copy(CMMS_JOIN.NEXT_EQUIP_ID, sizeof(CMMS_JOIN.NEXT_EQUIP_ID), in_node, "NEXT_EQUIP_ID");
	TRS.copy(CMMS_JOIN.MGT_DEPT_CODE, sizeof(CMMS_JOIN.MGT_DEPT_CODE), in_node, "MGT_DEPT_CODE");
    TRS.copy(CMMS_JOIN.EQUIP_PLACE_CODE, sizeof(CMMS_JOIN.EQUIP_PLACE_CODE), in_node, "EQUIP_PLACE_CODE");
	CMMS_JOIN.MSA_FLAG = TRS.get_char(in_node, "MSA_FLAG");
	CMMS_JOIN.SPC_FLAG = TRS.get_char(in_node, "SPC_FLAG");
	CMMS_JOIN.CALI_FLAG = TRS.get_char(in_node, "CALI_FLAG");
	CMMS_JOIN.CHECK_FLAG = TRS.get_char(in_node, "CHECK_FLAG");
	CMMS_JOIN.NONE_FLAG = TRS.get_char(in_node, "NONE_FLAG");
	CMMS_JOIN.STANDARD_FLAG = TRS.get_char(in_node, "STANDARD_FLAG");
	TRS.copy(CMMS_JOIN.USE_DIV, sizeof(CMMS_JOIN.USE_DIV), in_node, "USE_DIV");

    CDB_open_cmms_join(i_case, &CMMS_JOIN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMS_JOIN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMS_JOIN.FACTORY), CMMS_JOIN.FACTORY);
		TRS.add_fieldmsg(out_node, "PREV_YEAR", MP_STR, sizeof(CMMS_JOIN.PREV_YEAR), CMMS_JOIN.PREV_YEAR);
		TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_STR, sizeof(CMMS_JOIN.PLAN_YEAR), CMMS_JOIN.PLAN_YEAR);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMS_JOIN.EQUIP_ID), CMMS_JOIN.EQUIP_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cmms_join(i_case, &CMMS_JOIN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmms_join(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMS_JOIN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMS_JOIN.FACTORY), CMMS_JOIN.FACTORY);
            TRS.add_fieldmsg(out_node, "PREV_YEAR", MP_STR, sizeof(CMMS_JOIN.PREV_YEAR), CMMS_JOIN.PREV_YEAR);
			TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_STR, sizeof(CMMS_JOIN.PLAN_YEAR), CMMS_JOIN.PLAN_YEAR);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMS_JOIN.EQUIP_ID), CMMS_JOIN.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmms_join(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //    TRS.set_string(out_node, "NEXT_EQUIP_ID", CMMS_JOIN.EQUIP_ID, sizeof(CMMS_JOIN.EQUIP_ID));
        //    CDB_close_cmms_join(i_case);
        //    break;
        //}

		if(i_max_count >= 100)
        {
            TRS.set_string(out_node, "NEXT_EQUIP_ID", CMMS_JOIN.EQUIP_ID, sizeof(CMMS_JOIN.EQUIP_ID));
            CDB_close_cmms_join(i_case);
            break;
        }
		

        list_item = TRS.add_node(out_node, "EQUIPMENT_LEDGER_LIST");

        TRS.add_string(list_item, "FACTORY", CMMS_JOIN.FACTORY, sizeof(CMMS_JOIN.FACTORY));        
		TRS.add_string(list_item, "EQUIP_ID", CMMS_JOIN.EQUIP_ID, sizeof(CMMS_JOIN.EQUIP_ID));
		TRS.add_string(list_item, "EQUIP_NAME", CMMS_JOIN.EQUIP_NAME, sizeof(CMMS_JOIN.EQUIP_NAME));
		TRS.add_string(list_item, "MGT_DEPT_CODE", CMMS_JOIN.MGT_DEPT_CODE, sizeof(CMMS_JOIN.MGT_DEPT_CODE));
		TRS.add_string(list_item, "EQUIP_PLACE_CODE", CMMS_JOIN.EQUIP_PLACE_CODE, sizeof(CMMS_JOIN.EQUIP_PLACE_CODE));
		TRS.add_string(list_item, "CLASS_IDEN", CMMS_JOIN.CLASS_IDEN, sizeof(CMMS_JOIN.CLASS_IDEN));
		TRS.add_char(list_item, "MSA_FLAG", CMMS_JOIN.MSA_FLAG);
		TRS.add_char(list_item, "SPC_FLAG", CMMS_JOIN.SPC_FLAG);
		TRS.add_char(list_item, "CALI_FLAG", CMMS_JOIN.CALI_FLAG);
		TRS.add_char(list_item, "CHECK_FLAG", CMMS_JOIN.CHECK_FLAG);
		TRS.add_char(list_item, "NONE_FLAG", CMMS_JOIN.NONE_FLAG);
		TRS.add_char(list_item, "STANDARD_FLAG", CMMS_JOIN.STANDARD_FLAG);
		TRS.add_int(list_item, "CALI_CYCLE", CMMS_JOIN.CALI_CYCLE);		
		TRS.add_char(list_item, "CALI_DIV", CMMS_JOIN.CALI_DIV);
		TRS.add_int(list_item, "MSA_CYCLE", CMMS_JOIN.MSA_CYCLE);
		
		//Calibration 정보 조회 	
		CDB_init_cali_join(&CALI_JOIN);		
		memcpy(CALI_JOIN.FACTORY, CMMS_JOIN.FACTORY, sizeof(CALI_JOIN.FACTORY));
		TRS.copy(CALI_JOIN.PREV_YEAR, sizeof(CALI_JOIN.PREV_YEAR), in_node, "PREV_YEAR");
		TRS.copy(CALI_JOIN.PLAN_YEAR, sizeof(CALI_JOIN.PLAN_YEAR), in_node, "PLAN_YEAR");
		memcpy(CALI_JOIN.EQUIP_ID, CMMS_JOIN.EQUIP_ID, sizeof(CALI_JOIN.EQUIP_ID));
		CDB_open_cali_join(i_case, &CALI_JOIN);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CALI_JOIN OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALI_JOIN.FACTORY), CALI_JOIN.FACTORY);
			TRS.add_fieldmsg(out_node, "PREV_YEAR", MP_STR, sizeof(CALI_JOIN.PREV_YEAR), CALI_JOIN.PREV_YEAR);
			TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_STR, sizeof(CALI_JOIN.PLAN_YEAR), CALI_JOIN.PLAN_YEAR);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CALI_JOIN.EQUIP_ID), CALI_JOIN.EQUIP_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_cali_join(i_case, &CALI_JOIN);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cali_join(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CALI_JOIN FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALI_JOIN.FACTORY), CALI_JOIN.FACTORY);
				TRS.add_fieldmsg(out_node, "PREV_YEAR", MP_STR, sizeof(CALI_JOIN.PREV_YEAR), CALI_JOIN.PREV_YEAR);
				TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_STR, sizeof(CALI_JOIN.PLAN_YEAR), CALI_JOIN.PLAN_YEAR);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CALI_JOIN.EQUIP_ID), CALI_JOIN.EQUIP_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cali_join(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			cali_item = TRS.add_node(list_item, "CALI_JOIN_LIST");
			TRS.add_string(cali_item, "RST_PLAN_DATE", CALI_JOIN.RST_PLAN_DATE, sizeof(CALI_JOIN.RST_PLAN_DATE));
			TRS.add_string(cali_item, "RST_CALI_DATE", CALI_JOIN.RST_CALI_DATE, sizeof(CALI_JOIN.RST_CALI_DATE));
			TRS.add_string(cali_item, "RST_CALI_RESULT", CALI_JOIN.RST_CALI_RESULT, sizeof(CALI_JOIN.RST_CALI_RESULT));
			TRS.add_string(cali_item, "PLAN_DATE", CALI_JOIN.PLAN_DATE, sizeof(CALI_JOIN.PLAN_DATE));
			TRS.add_string(cali_item, "CALI_DATE", CALI_JOIN.CALI_DATE, sizeof(CALI_JOIN.CALI_DATE));
			TRS.add_string(cali_item, "CALI_RESULT", CALI_JOIN.CALI_RESULT, sizeof(CALI_JOIN.CALI_RESULT));
		}
		
		//Analysis 정보 조회 	
		CDB_init_ana_join(&ANA_JOIN);		
		memcpy(ANA_JOIN.FACTORY, CMMS_JOIN.FACTORY, sizeof(ANA_JOIN.FACTORY));
		TRS.copy(ANA_JOIN.PREV_YEAR, sizeof(CALI_JOIN.PREV_YEAR), in_node, "PREV_YEAR");
		TRS.copy(ANA_JOIN.PLAN_YEAR, sizeof(CALI_JOIN.PLAN_YEAR), in_node, "PLAN_YEAR");
		memcpy(ANA_JOIN.EQUIP_ID, CMMS_JOIN.EQUIP_ID, sizeof(ANA_JOIN.EQUIP_ID));
		CDB_open_ana_join(i_case, &ANA_JOIN);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "ANA_JOIN OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(ANA_JOIN.FACTORY), ANA_JOIN.FACTORY);
			TRS.add_fieldmsg(out_node, "PREV_YEAR", MP_STR, sizeof(ANA_JOIN.PREV_YEAR), ANA_JOIN.PREV_YEAR);
			TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_STR, sizeof(ANA_JOIN.PLAN_YEAR), ANA_JOIN.PLAN_YEAR);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(ANA_JOIN.EQUIP_ID), ANA_JOIN.EQUIP_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		while(1)
		{
			CDB_fetch_ana_join(i_case, &ANA_JOIN);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_ana_join(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "ANA_JOIN FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(ANA_JOIN.FACTORY), ANA_JOIN.FACTORY);
				TRS.add_fieldmsg(out_node, "PREV_YEAR", MP_STR, sizeof(ANA_JOIN.PREV_YEAR), ANA_JOIN.PREV_YEAR);
				TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_STR, sizeof(ANA_JOIN.PLAN_YEAR), ANA_JOIN.PLAN_YEAR);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(ANA_JOIN.EQUIP_ID), ANA_JOIN.EQUIP_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_ana_join(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			ana_item = TRS.add_node(list_item, "ANA_JOIN_LIST");
			TRS.add_string(ana_item, "RST_VARI_DATE", ANA_JOIN.RST_VARI_DATE, sizeof(ANA_JOIN.RST_VARI_DATE));
			TRS.add_string(ana_item, "RST_VARI_VALUES", ANA_JOIN.RST_VARI_VALUES, sizeof(ANA_JOIN.RST_VARI_VALUES));
			TRS.add_string(ana_item, "RST_LINE_DATE", ANA_JOIN.RST_LINE_DATE, sizeof(ANA_JOIN.RST_LINE_DATE));
			TRS.add_string(ana_item, "RST_LINE_VALUES", ANA_JOIN.RST_LINE_VALUES, sizeof(ANA_JOIN.RST_LINE_VALUES));
			TRS.add_string(ana_item, "RST_BIAS_DATE", ANA_JOIN.RST_BIAS_DATE, sizeof(ANA_JOIN.RST_BIAS_DATE));
			TRS.add_string(ana_item, "RST_BIAS_VALUES", ANA_JOIN.RST_BIAS_VALUES, sizeof(ANA_JOIN.RST_BIAS_VALUES));
			TRS.add_string(ana_item, "ANA_VARI_PLAN_DATE", ANA_JOIN.ANA_VARI_PLAN_DATE, sizeof(ANA_JOIN.ANA_VARI_PLAN_DATE));
			TRS.add_string(ana_item, "ANA_VARI_DATE", ANA_JOIN.ANA_VARI_DATE, sizeof(ANA_JOIN.ANA_VARI_DATE));
			TRS.add_string(ana_item, "ANA_VARI_VALUES", ANA_JOIN.ANA_VARI_VALUES, sizeof(ANA_JOIN.ANA_VARI_VALUES));
			TRS.add_string(ana_item, "ANA_LINE_PLAN_DATE", ANA_JOIN.ANA_LINE_PLAN_DATE, sizeof(ANA_JOIN.ANA_LINE_PLAN_DATE));
			TRS.add_string(ana_item, "ANA_LINE_DATE", ANA_JOIN.ANA_LINE_DATE, sizeof(ANA_JOIN.ANA_LINE_DATE));
			TRS.add_string(ana_item, "ANA_LINE_VALUES", ANA_JOIN.ANA_LINE_VALUES, sizeof(ANA_JOIN.ANA_LINE_VALUES));
			TRS.add_string(ana_item, "ANA_BIAS_PLAN_DATE", ANA_JOIN.ANA_BIAS_PLAN_DATE, sizeof(ANA_JOIN.ANA_BIAS_PLAN_DATE));
			TRS.add_string(ana_item, "ANA_BIAS_DATE", ANA_JOIN.ANA_BIAS_DATE, sizeof(ANA_JOIN.ANA_BIAS_DATE));
			TRS.add_string(ana_item, "ANA_BIAS_VALUES", ANA_JOIN.ANA_BIAS_VALUES, sizeof(ANA_JOIN.ANA_BIAS_VALUES));
		}
		i_max_count++;
    }


    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Equipment_Ledger_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

