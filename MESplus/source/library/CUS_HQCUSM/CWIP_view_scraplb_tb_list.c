/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_scraplb_tb_list.c
    Description : View Scraplb_Tb List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_ScrapLb_Tb_List()
            + View Scraplb_Tb definition List
        - CWIP_VIEW_SCRAPLB_TB_LIST()
            + Main sub function of CWIP_View_Scraplb_Tb_List function
            + View Scraplb_Tb definition List
    Detail Description
        - CWIP_VIEW_SCRAPLB_TB_LIST()
            + h_proc_step
                + 1 : View Scraplb_Tb definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-23             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_ScrapLb_Tb_List()
        - View Scraplb_Tb definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_ScrapLb_Tb_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_SCRAPLB_TB_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_SCRAPLB_TB_LIST", out_node);

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
    CWIP_VIEW_SCRAPLB_TB_LIST()
        - Main sub function of "CWIP_View_Scraplb_Tb_List" function
        - View Scraplb_Tb definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_SCRAPLB_TB_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOSTAB_TAG CWIPLOSTAB; 

    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_SCRAPLB_TB_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

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

    CDB_init_cwiplostab(&CWIPLOSTAB);
	TRS.copy(CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY), in_node, "FACTORY");
	TRS.copy(CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID), in_node, "LINE_ID");
	TRS.copy(CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT), in_node, "WORK_SHIFT") ;
	TRS.copy(CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID), in_node, "OPER_ID");
	TRS.copy(CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID), in_node, "RES_ID");
	TRS.copy(CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID), in_node, "OPERATOR_ID");
    CDB_open_cwiplostab(i_case, &CWIPLOSTAB);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPLOSTAB OPEN", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cwiplostab(i_case, &CWIPLOSTAB);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiplostab(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOSTAB FETCH", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwiplostab(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            CDB_close_cwiplostab(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "SCRAPLB_TB_LIST");

        //TRS.add_string(list_item, "RES_DESC", CWIPLOSTAB.RES_DESC, sizeof(CWIPLOSTAB.RES_DESC));
        //TRS.add_string(list_item, "OPER_SUB_NAME", CWIPLOSTAB.OPER_SUB_NAME, sizeof(CWIPLOSTAB.OPER_SUB_NAME));
        TRS.add_string(list_item, "WORK_DATE", CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE));
        TRS.add_string(list_item, "FACTORY", CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY));
        TRS.add_string(list_item, "LINE_ID", CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID));
        TRS.add_string(list_item, "RES_ID", CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID));
        TRS.add_string(list_item, "OPER_ID", CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID));
        TRS.add_string(list_item, "OPER_SUB_ID", CWIPLOSTAB.OPER_SUB_ID, sizeof(CWIPLOSTAB.OPER_SUB_ID));
        TRS.add_string(list_item, "WORK_SHIFT", CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT));
        TRS.add_string(list_item, "OPERATOR_ID", CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID));
        TRS.add_double(list_item, "LOSS_QTY", CWIPLOSTAB.LOSS_QTY);
        TRS.add_string(list_item, "LOSS_CAUSE", CWIPLOSTAB.LOSS_CAUSE, sizeof(CWIPLOSTAB.LOSS_CAUSE));
        TRS.add_string(list_item, "LOSS_COMMENT", CWIPLOSTAB.LOSS_COMMENT, sizeof(CWIPLOSTAB.LOSS_COMMENT));
        TRS.add_string(list_item, "LOSS_LB", CWIPLOSTAB.LOSS_LB, sizeof(CWIPLOSTAB.LOSS_LB));
        TRS.add_string(list_item, "LOSS_LB_CHECK", CWIPLOSTAB.LOSS_LB_CHECK, sizeof(CWIPLOSTAB.LOSS_LB_CHECK));
        TRS.add_string(list_item, "BOX_USE", CWIPLOSTAB.BOX_USE, sizeof(CWIPLOSTAB.BOX_USE));
        TRS.add_string(list_item, "CREATE_USER_ID", CWIPLOSTAB.CREATE_USER_ID, sizeof(CWIPLOSTAB.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CWIPLOSTAB.CREATE_TIME, sizeof(CWIPLOSTAB.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPLOSTAB.UPDATE_USER_ID, sizeof(CWIPLOSTAB.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CWIPLOSTAB.UPDATE_TIME, sizeof(CWIPLOSTAB.UPDATE_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_ScrapLb_Tb_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

