/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_cmms_equip_list_list.c
    Description : View CMMS_Equip_List List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_CMMS_Equip_List_List()
            + View CMMS_Equip_List definition List
        - CMMS_VIEW_CMMS_EQUIP_LIST_LIST()
            + Main sub function of CMMS_View_CMMS_Equip_List_List function
            + View CMMS_Equip_List definition List
    Detail Description
        - CMMS_VIEW_CMMS_EQUIP_LIST_LIST()
            + h_proc_step
                + 1 : View CMMS_Equip_List definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/06/26             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_CMMS_Equip_List_List()
        - View CMMS_Equip_List definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_CMMS_Equip_List_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CMMS_EQUIP_LIST_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CMMS_EQUIP_LIST_LIST", out_node);

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
    CMMS_VIEW_CMMS_EQUIP_LIST_LIST()
        - Main sub function of "CMMS_View_CMMS_Equip_List_List" function
        - View CMMS_Equip_List definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CMMS_EQUIP_LIST_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSEQPLST_TAG CMMSEQPLST;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_CMMS_EQUIP_LIST_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
	LOG_add("next_equip_id", MP_NSTR, TRS.get_string(in_node, "NEXT_EQUIP_ID"));
	LOG_add("use_dept_code", MP_NSTR, TRS.get_string(in_node, "USE_DEPT_CODE"));
	LOG_add("equip_place_code", MP_NSTR, TRS.get_string(in_node, "EQUIP_PLACE_CODE"));
	LOG_add("use_div", MP_NSTR, TRS.get_string(in_node, "USE_DIV"));
	LOG_add("plan_fr_date", MP_NSTR, TRS.get_string(in_node, "PLAN_FR_DATE"));
	LOG_add("plan_to_date", MP_NSTR, TRS.get_string(in_node, "PLAN_TO_DATE"));
	LOG_add("remain_flag", MP_NSTR, TRS.get_string(in_node, "REMAIN_FLAG"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_CMMS_Equip_List_List",
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
    i_case = 1;

    CDB_init_cmmseqplst(&CMMSEQPLST);
	TRS.copy(CMMSEQPLST.FACTORY, sizeof(CMMSEQPLST.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CMMSEQPLST.EQUIP_ID, sizeof(CMMSEQPLST.EQUIP_ID), in_node, "EQUIP_ID");
	TRS.copy(CMMSEQPLST.EQUIP_TYPE, sizeof(CMMSEQPLST.EQUIP_TYPE), in_node, "EQUIP_TYPE");
	TRS.copy(CMMSEQPLST.NEXT_EQUIP_ID, sizeof(CMMSEQPLST.NEXT_EQUIP_ID), in_node, "NEXT_EQUIP_ID");
	TRS.copy(CMMSEQPLST.USE_DEPT_CODE, sizeof(CMMSEQPLST.USE_DEPT_CODE), in_node, "USE_DEPT_CODE");
    TRS.copy(CMMSEQPLST.EQUIP_PLACE_CODE, sizeof(CMMSEQPLST.EQUIP_PLACE_CODE), in_node, "EQUIP_PLACE_CODE");
	TRS.copy(CMMSEQPLST.USE_DIV, sizeof(CMMSEQPLST.USE_DIV), in_node, "USE_DIV");
	TRS.copy(CMMSEQPLST.LAST_CALI_DATE, sizeof(CMMSEQPLST.USE_DIV), in_node, "PLAN_FR_DATE");
	TRS.copy(CMMSEQPLST.NEXT_CALI_DATE, sizeof(CMMSEQPLST.USE_DIV), in_node, "PLAN_TO_DATE");
	TRS.copy(CMMSEQPLST.REMAIN_FLAG, sizeof(CMMSEQPLST.REMAIN_FLAG), in_node, "REMAIN_FLAG");
    CDB_open_cmmseqplst(i_case, &CMMSEQPLST);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSEQPLST OPEN", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cmmseqplst(i_case, &CMMSEQPLST);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmseqplst(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPLST FETCH", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmseqplst(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
			TRS.set_string(out_node, "NEXT_EQUIP_ID", CMMSEQPLST.EQUIP_ID, sizeof(CMMSEQPLST.EQUIP_ID));
            CDB_close_cmmseqplst(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "CMMS_EQUIP_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSEQPLST.FACTORY, sizeof(CMMSEQPLST.FACTORY));
        TRS.add_string(list_item, "EQUIP_ID", CMMSEQPLST.EQUIP_ID, sizeof(CMMSEQPLST.EQUIP_ID));
        TRS.add_string(list_item, "EQUIP_NAME", CMMSEQPLST.EQUIP_NAME, sizeof(CMMSEQPLST.EQUIP_NAME));
        TRS.add_string(list_item, "EQUIP_TYPE", CMMSEQPLST.EQUIP_TYPE, sizeof(CMMSEQPLST.EQUIP_TYPE));
        TRS.add_string(list_item, "EQUIP_TYPE_NAME", CMMSEQPLST.EQUIP_TYPE_NAME, sizeof(CMMSEQPLST.EQUIP_TYPE_NAME));
        TRS.add_string(list_item, "EQUIP_NO", CMMSEQPLST.EQUIP_NO, sizeof(CMMSEQPLST.EQUIP_NO));
        TRS.add_string(list_item, "USE_DEPT_CODE", CMMSEQPLST.USE_DEPT_CODE, sizeof(CMMSEQPLST.USE_DEPT_CODE));
        TRS.add_string(list_item, "USE_DEPT_NAME", CMMSEQPLST.USE_DEPT_NAME, sizeof(CMMSEQPLST.USE_DEPT_NAME));
        TRS.add_string(list_item, "EQUIP_PLACE_CODE", CMMSEQPLST.EQUIP_PLACE_CODE, sizeof(CMMSEQPLST.EQUIP_PLACE_CODE));
        TRS.add_string(list_item, "EQUIP_PLACE_NAME", CMMSEQPLST.EQUIP_PLACE_NAME, sizeof(CMMSEQPLST.EQUIP_PLACE_NAME));
        TRS.add_string(list_item, "USE_DIV", CMMSEQPLST.USE_DIV, sizeof(CMMSEQPLST.USE_DIV));
        TRS.add_string(list_item, "DIV_NAME", CMMSEQPLST.DIV_NAME, sizeof(CMMSEQPLST.DIV_NAME));
        TRS.add_string(list_item, "EQUIP_MAKER", CMMSEQPLST.EQUIP_MAKER, sizeof(CMMSEQPLST.EQUIP_MAKER));
        TRS.add_string(list_item, "EQUIP_MODEL", CMMSEQPLST.EQUIP_MODEL, sizeof(CMMSEQPLST.EQUIP_MODEL));
        TRS.add_string(list_item, "SERIAL_NO", CMMSEQPLST.SERIAL_NO, sizeof(CMMSEQPLST.SERIAL_NO));
		TRS.add_string(list_item, "LAST_CALI_DATE", CMMSEQPLST.LAST_CALI_DATE, sizeof(CMMSEQPLST.LAST_CALI_DATE));
		TRS.add_string(list_item, "LAST_CALI_RESULT", CMMSEQPLST.LAST_CALI_RESULT, sizeof(CMMSEQPLST.LAST_CALI_RESULT));
        TRS.add_string(list_item, "NEXT_CALI_DATE", CMMSEQPLST.NEXT_CALI_DATE, sizeof(CMMSEQPLST.NEXT_CALI_DATE));
        TRS.add_string(list_item, "CALI_INSTITUTE", CMMSEQPLST.CALI_INSTITUTE, sizeof(CMMSEQPLST.CALI_INSTITUTE));
        TRS.add_string(list_item, "CALI_INS_NAME", CMMSEQPLST.CALI_INS_NAME, sizeof(CMMSEQPLST.CALI_INS_NAME));
        TRS.add_string(list_item, "EQUIP_DESC", CMMSEQPLST.EQUIP_DESC, sizeof(CMMSEQPLST.EQUIP_DESC));
		TRS.add_string(list_item, "REMAIN_DAY", CMMSEQPLST.REMAIN_DAY, sizeof(CMMSEQPLST.REMAIN_DAY));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_CMMS_Equip_List_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

