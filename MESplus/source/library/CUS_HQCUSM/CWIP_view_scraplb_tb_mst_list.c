/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_scraplb_tb_mst_list.c
    Description : View Scraplb_Tb_Mst List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Scraplb_Tb_Mst_List()
            + View Scraplb_Tb_Mst definition List
        - CWIP_VIEW_SCRAPLB_TB_MST_LIST()
            + Main sub function of CWIP_View_Scraplb_Tb_Mst_List function
            + View Scraplb_Tb_Mst definition List
    Detail Description
        - CWIP_VIEW_SCRAPLB_TB_MST_LIST()
            + h_proc_step
                + 1 : View Scraplb_Tb_Mst definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-06-29             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Scraplb_Tb_Mst_List()
        - View Scraplb_Tb_Mst definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Scraplb_Tb_Mst_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_SCRAPLB_TB_MST_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_SCRAPLB_TB_MST_LIST", out_node);

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
    CWIP_VIEW_SCRAPLB_TB_MST_LIST()
        - Main sub function of "CWIP_View_Scraplb_Tb_Mst_List" function
        - View Scraplb_Tb_Mst definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_SCRAPLB_TB_MST_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct VRSUMWIPLOSMST_TAG VRSUMWIPLOSMST;
    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_SCRAPLB_TB_MST_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Scraplb_Tb_Mst_List",
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

    CDB_init_vrsumwiplosmst(&VRSUMWIPLOSMST);
	TRS.copy(VRSUMWIPLOSMST.FACTORY, sizeof(VRSUMWIPLOSMST.FACTORY), in_node, "FACTORY");
	TRS.copy(VRSUMWIPLOSMST.LINE_ID, sizeof(VRSUMWIPLOSMST.LINE_ID), in_node, "LINE_ID");
	TRS.copy(VRSUMWIPLOSMST.OPER_ID, sizeof(VRSUMWIPLOSMST.OPER_ID), in_node, "OPER_ID");
    CDB_open_vrsumwiplosmst(i_case, &VRSUMWIPLOSMST);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "VRSUMWIPLOSMST OPEN", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_vrsumwiplosmst(i_case, &VRSUMWIPLOSMST);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_vrsumwiplosmst(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "VRSUMWIPLOSMST FETCH", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_vrsumwiplosmst(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            CDB_close_vrsumwiplosmst(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "SCRAPLB_TB_MST_LIST");

        TRS.add_string(list_item, "RES_DESC", VRSUMWIPLOSMST.RES_DESC, sizeof(VRSUMWIPLOSMST.RES_DESC));
        TRS.add_string(list_item, "OPER_SUB_NAME", VRSUMWIPLOSMST.OPER_SUB_NAME, sizeof(VRSUMWIPLOSMST.OPER_SUB_NAME));
        TRS.add_string(list_item, "FACTORY", VRSUMWIPLOSMST.FACTORY, sizeof(VRSUMWIPLOSMST.FACTORY));
        TRS.add_string(list_item, "LINE_ID", VRSUMWIPLOSMST.LINE_ID, sizeof(VRSUMWIPLOSMST.LINE_ID));
        TRS.add_string(list_item, "RES_ID", VRSUMWIPLOSMST.RES_ID, sizeof(VRSUMWIPLOSMST.RES_ID));
        TRS.add_string(list_item, "OPER_ID", VRSUMWIPLOSMST.OPER_ID, sizeof(VRSUMWIPLOSMST.OPER_ID));
        TRS.add_string(list_item, "OPER_SUB_ID", VRSUMWIPLOSMST.OPER_SUB_ID, sizeof(VRSUMWIPLOSMST.OPER_SUB_ID));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Scraplb_Tb_Mst_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

