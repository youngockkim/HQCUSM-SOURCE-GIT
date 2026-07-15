/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_plan_list.c
    Description : View Calibration_Plan List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_Plan_List()
            + View Calibration_Plan definition List
        - CMMS_VIEW_CALIBRATION_PLAN_LIST()
            + Main sub function of CMMS_View_Calibration_Plan_List function
            + View Calibration_Plan definition List
    Detail Description
        - CMMS_VIEW_CALIBRATION_PLAN_LIST()
            + h_proc_step
                + 1 : View Calibration_Plan definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-29             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Calibration_Plan_List()
        - View Calibration_Plan definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Plan_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_PLAN_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_PLAN_LIST", out_node);

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
    CMMS_VIEW_CALIBRATION_PLAN_LIST()
        - Main sub function of "CMMS_View_Calibration_Plan_List" function
        - View Calibration_Plan definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_PLAN_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALPLN_TAG CMMSCALPLN;
	struct CMMSEQPDEF_TAG CMMSEQPDEF;

    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_CALIBRATION_PLAN_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Plan_List",
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
                              "12") == MP_FALSE)
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
   
	i_case = 1;

    CDB_init_cmmscalpln(&CMMSCALPLN);
    TRS.copy(CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY), in_node, IN_FACTORY);
	if (TRS.get_procstep(in_node) == '2')
	{
		i_case = 2;
		TRS.copy(CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID), in_node, "EQUIP_ID");
		TRS.copy(CMMSCALPLN.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE), in_node, "FROM_DATE");
		TRS.copy(CMMSCALPLN.CALI_DATE, sizeof(CMMSCALPLN.CALI_DATE), in_node, "TO_DATE");
		TRS.copy(CMMSCALPLN.CMF_1, sizeof(CMMSCALPLN.CMF_1), in_node, "EQUIP_TYPE");
		TRS.copy(CMMSCALPLN.CMF_2, sizeof(CMMSCALPLN.CMF_2), in_node, "MGT_DEPT_CODE");
		TRS.copy(CMMSCALPLN.CMF_3, sizeof(CMMSCALPLN.CMF_3), in_node, "USE_DEPT_CODE");
	}

    CDB_open_cmmscalpln(i_case, &CMMSCALPLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSCALPLN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cmmscalpln(i_case, &CMMSCALPLN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmscalpln(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALPLN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmscalpln(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_EQUIP_ID", CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID));
            CDB_close_cmmscalpln(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "CALIBRATION_PLAN_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY));
        TRS.add_string(list_item, "EQUIP_ID", CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID));
        TRS.add_string(list_item, "PLAN_DATE", CMMSCALPLN.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE));
        TRS.add_string(list_item, "CALI_DATE", CMMSCALPLN.CALI_DATE, sizeof(CMMSCALPLN.CALI_DATE));
        TRS.add_string(list_item, "CALI_INSTITUTE", CMMSCALPLN.CALI_INSTITUTE, sizeof(CMMSCALPLN.CALI_INSTITUTE));
        TRS.add_string(list_item, "CALI_METHOD", CMMSCALPLN.CALI_METHOD, sizeof(CMMSCALPLN.CALI_METHOD));
        TRS.add_char(list_item, "CALI_RESULT", CMMSCALPLN.CALI_RESULT);
        TRS.add_double(list_item, "CALI_COST", CMMSCALPLN.CALI_COST);
        TRS.add_string(list_item, "CALI_STATUS", CMMSCALPLN.CALI_STATUS, sizeof(CMMSCALPLN.CALI_STATUS));
        TRS.add_string(list_item, "FILE_NAME", CMMSCALPLN.FILE_NAME, sizeof(CMMSCALPLN.FILE_NAME));
        TRS.add_string(list_item, "FILE_PATH", CMMSCALPLN.FILE_PATH, sizeof(CMMSCALPLN.FILE_PATH));
        TRS.add_char(list_item, "ALARM_FLAG", CMMSCALPLN.ALARM_FLAG);
        TRS.add_string(list_item, "ALARM_CODE", CMMSCALPLN.ALARM_CODE, sizeof(CMMSCALPLN.ALARM_CODE));
        TRS.add_int(list_item, "ALARM_PERIOD", CMMSCALPLN.ALARM_PERIOD);
        TRS.add_string(list_item, "CMF_1", CMMSCALPLN.CMF_1, sizeof(CMMSCALPLN.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMSCALPLN.CMF_2, sizeof(CMMSCALPLN.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMSCALPLN.CMF_3, sizeof(CMMSCALPLN.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMSCALPLN.CMF_4, sizeof(CMMSCALPLN.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMSCALPLN.CMF_5, sizeof(CMMSCALPLN.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMSCALPLN.CMF_6, sizeof(CMMSCALPLN.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMSCALPLN.CMF_7, sizeof(CMMSCALPLN.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMSCALPLN.CMF_8, sizeof(CMMSCALPLN.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMSCALPLN.CMF_9, sizeof(CMMSCALPLN.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMSCALPLN.CMF_10, sizeof(CMMSCALPLN.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMSCALPLN.CREATE_USER_ID, sizeof(CMMSCALPLN.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMSCALPLN.CREATE_TIME, sizeof(CMMSCALPLN.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMSCALPLN.UPDATE_USER_ID, sizeof(CMMSCALPLN.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMSCALPLN.UPDATE_TIME, sizeof(CMMSCALPLN.UPDATE_TIME));

		if (TRS.get_procstep(in_node) == '2')
		{
			CDB_init_cmmseqpdef(&CMMSEQPDEF);
			memcpy(CMMSEQPDEF.FACTORY, CMMSCALPLN.FACTORY, sizeof(CMMSEQPDEF.FACTORY)); 
			memcpy(CMMSEQPDEF.EQUIP_ID, CMMSCALPLN.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
			CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSEQPDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF.FACTORY), CMMSEQPDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF.EQUIP_ID), CMMSEQPDEF.EQUIP_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			TRS.add_string(list_item, "EQUIP_ID", CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
			TRS.add_string(list_item, "EQUIP_CODE", CMMSEQPDEF.EQUIP_CODE, sizeof(CMMSEQPDEF.EQUIP_CODE));
			TRS.add_string(list_item, "EQUIP_NAME", CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));
			TRS.add_string(list_item, "EQUIP_NO", CMMSEQPDEF.EQUIP_NO, sizeof(CMMSEQPDEF.EQUIP_NO));
			//TRS.add_string(list_item, "MGT_DEPT_CODE", CMMSEQPDEF.MGT_DEPT_CODE, sizeof(CMMSEQPDEF.MGT_DEPT_CODE));
			//TRS.add_string(list_item, "MGT_USER_ID", CMMSEQPDEF.MGT_USER_ID, sizeof(CMMSEQPDEF.MGT_USER_ID));
			//TRS.add_string(list_item, "USE_DEPT_CODE", CMMSEQPDEF.USE_DEPT_CODE, sizeof(CMMSEQPDEF.USE_DEPT_CODE));
			//TRS.add_string(list_item, "USE_USER_ID", CMMSEQPDEF.USE_USER_ID, sizeof(CMMSEQPDEF.USE_USER_ID));
			//TRS.add_string(list_item, "USE_DIV", CMMSEQPDEF.USE_DIV, sizeof(CMMSEQPDEF.USE_DIV));
			//TRS.add_char(list_item, "CALI_DIV", CMMSEQPDEF.CALI_DIV);
			//TRS.add_string(list_item, "PARTNER_CODE", CMMSEQPDEF.PARTNER_CODE, sizeof(CMMSEQPDEF.PARTNER_CODE));
			TRS.add_string(list_item, "PROP_NO", CMMSEQPDEF.PROP_NO, sizeof(CMMSEQPDEF.PROP_NO));
			//TRS.add_string(list_item, "SUPPLY_CODE", CMMSEQPDEF.SUPPLY_CODE, sizeof(CMMSEQPDEF.SUPPLY_CODE));
			TRS.add_string(list_item, "EQUIP_MAKER", CMMSEQPDEF.EQUIP_MAKER, sizeof(CMMSEQPDEF.EQUIP_MAKER));
			TRS.add_string(list_item, "EQUIP_MODEL", CMMSEQPDEF.EQUIP_MODEL, sizeof(CMMSEQPDEF.EQUIP_MODEL));
			TRS.add_string(list_item, "EQUIP_PURPOSE", CMMSEQPDEF.EQUIP_PURPOSE, sizeof(CMMSEQPDEF.EQUIP_PURPOSE));
			TRS.add_string(list_item, "EQUIP_FEATURE", CMMSEQPDEF.EQUIP_FEATURE, sizeof(CMMSEQPDEF.EQUIP_FEATURE));
			TRS.add_string(list_item, "EQUIP_PLACE_CODE", CMMSEQPDEF.EQUIP_PLACE_CODE, sizeof(CMMSEQPDEF.EQUIP_PLACE_CODE));
			TRS.add_string(list_item, "SERIAL_NO", CMMSEQPDEF.SERIAL_NO, sizeof(CMMSEQPDEF.SERIAL_NO));
			TRS.add_string(list_item, "EQUIP_SPEC", CMMSEQPDEF.EQUIP_SPEC, sizeof(CMMSEQPDEF.EQUIP_SPEC));
			//TRS.add_string(list_item, "BUY_DATE", CMMSEQPDEF.BUY_DATE, sizeof(CMMSEQPDEF.BUY_DATE));
			//TRS.add_double(list_item, "BUY_COST", CMMSEQPDEF.BUY_COST);
			TRS.add_int(list_item, "CALI_CYCLE", CMMSEQPDEF.CALI_CYCLE);
			//TRS.add_int(list_item, "MSA_CYCLE", CMMSEQPDEF.MSA_CYCLE);
			TRS.add_string(list_item, "EQUIP_DESC", CMMSEQPDEF.EQUIP_DESC, sizeof(CMMSEQPDEF.EQUIP_DESC));
			//TRS.add_int(list_item, "LAST_EQUIP_SEQ", CMMSEQPDEF.LAST_EQUIP_SEQ);
			//TRS.add_string(list_item, "APPROVE_USER_ID", CMMSEQPDEF.APPROVE_USER_ID, sizeof(CMMSEQPDEF.APPROVE_USER_ID));
			//TRS.add_char(list_item, "APPROVE_FLAG", CMMSEQPDEF.APPROVE_FLAG);
			//TRS.add_char(list_item, "MSA_FLAG", CMMSEQPDEF.MSA_FLAG);
			//TRS.add_char(list_item, "SPC_FLAG", CMMSEQPDEF.SPC_FLAG);
			//TRS.add_char(list_item, "CALI_FLAG", CMMSEQPDEF.CALI_FLAG);
			//TRS.add_char(list_item, "CHECK_FLAG", CMMSEQPDEF.CHECK_FLAG);
			//TRS.add_char(list_item, "NONE_FLAG", CMMSEQPDEF.NONE_FLAG);
			//TRS.add_char(list_item, "STANDARD_FLAG", CMMSEQPDEF.STANDARD_FLAG);
		}
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Plan_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

