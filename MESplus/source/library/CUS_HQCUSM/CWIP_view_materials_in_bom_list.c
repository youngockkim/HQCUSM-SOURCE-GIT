/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_materials_in_bom_list.c
    Description : View Materials_In_Bom List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Materials_In_Bom_List()
            + View Materials_In_Bom definition List
        - CWIP_VIEW_MATERIALS_IN_BOM_LIST()
            + Main sub function of CWIP_View_Materials_In_Bom_List function
            + View Materials_In_Bom definition List
    Detail Description
        - CWIP_VIEW_MATERIALS_IN_BOM_LIST()
            + h_proc_step
                + 1 : View Materials_In_Bom definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024-05-07             Create by Generator

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Materials_In_Bom_List()
        - View Materials_In_Bom definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Materials_In_Bom_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_MATERIALS_IN_BOM_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_MATERIALS_IN_BOM_LIST", out_node);

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
    CWIP_VIEW_MATERIALS_IN_BOM_LIST()
        - Main sub function of "CWIP_View_Materials_In_Bom_List" function
        - View Materials_In_Bom definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_MATERIALS_IN_BOM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPORDBOM_TAG CWIPORDBOM;
    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_MATERIALS_IN_BOM_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    LOG_add("seq", MP_INT, TRS.get_int(in_node, "SEQ"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);


    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1A") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }   

    i_case = 101;

    CDB_init_cwipordbom(&CWIPORDBOM);
    TRS.copy(CWIPORDBOM.FACTORY, sizeof(CWIPORDBOM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPORDBOM.MAT_ID, sizeof(CWIPORDBOM.MAT_ID), in_node, "MAT_ID");
    CDB_open_cwipordbom(i_case, &CWIPORDBOM);

    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPORDBOM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDBOM.ORDER_ID), CWIPORDBOM.ORDER_ID);
        TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPORDBOM.SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwipordbom(i_case, &CWIPORDBOM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipordbom(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPORDBOM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDBOM.ORDER_ID), CWIPORDBOM.ORDER_ID);
            TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPORDBOM.SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwipordbom(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //    TRS.set_string(out_node, "NEXT_ORDER_ID", CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
        //    TRS.set_int(out_node, "NEXT_SEQ", CWIPORDBOM.SEQ);
        //    CDB_close_cwipordbom(i_case);
        //    break;
        //}

        list_item = TRS.add_node(out_node, "MATERIALS_IN_BOM_LIST");

        TRS.add_string(list_item, "FACTORY", CWIPORDBOM.FACTORY, sizeof(CWIPORDBOM.FACTORY));
        TRS.add_string(list_item, "ORDER_ID", CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
        TRS.add_int(list_item, "SEQ", CWIPORDBOM.SEQ);
        TRS.add_string(list_item, "RS_NUM", CWIPORDBOM.RS_NUM, sizeof(CWIPORDBOM.RS_NUM));
        TRS.add_string(list_item, "RS_POS", CWIPORDBOM.RS_POS, sizeof(CWIPORDBOM.RS_POS));
        TRS.add_string(list_item, "BOM_PJT_NO", CWIPORDBOM.BOM_PJT_NO, sizeof(CWIPORDBOM.BOM_PJT_NO));
        TRS.add_string(list_item, "BOM_PJT_CATE", CWIPORDBOM.BOM_PJT_CATE, sizeof(CWIPORDBOM.BOM_PJT_CATE));
        TRS.add_string(list_item, "MAT_ID", CWIPORDBOM.MAT_ID, sizeof(CWIPORDBOM.MAT_ID));
        TRS.add_string(list_item, "MATE_TYPE", CWIPORDBOM.MATE_TYPE, sizeof(CWIPORDBOM.MATE_TYPE));
        TRS.add_string(list_item, "MATE_NO_DESC", CWIPORDBOM.MATE_NO_DESC, sizeof(CWIPORDBOM.MATE_NO_DESC));
        TRS.add_double(list_item, "QTY", CWIPORDBOM.QTY);
        TRS.add_string(list_item, "UNIT_ID", CWIPORDBOM.UNIT_ID, sizeof(CWIPORDBOM.UNIT_ID));
        TRS.add_string(list_item, "BATCH_NO", CWIPORDBOM.BATCH_NO, sizeof(CWIPORDBOM.BATCH_NO));
        TRS.add_string(list_item, "VEN_BATCH_NO", CWIPORDBOM.VEN_BATCH_NO, sizeof(CWIPORDBOM.VEN_BATCH_NO));
        TRS.add_string(list_item, "LOC_ID", CWIPORDBOM.LOC_ID, sizeof(CWIPORDBOM.LOC_ID));
        TRS.add_char(list_item, "BACKFLUSH_YN", CWIPORDBOM.BACKFLUSH_YN);
        TRS.add_string(list_item, "HAND_BOOK", CWIPORDBOM.HAND_BOOK, sizeof(CWIPORDBOM.HAND_BOOK));
        TRS.add_string(list_item, "VENDOR", CWIPORDBOM.VENDOR, sizeof(CWIPORDBOM.VENDOR));
        TRS.add_string(list_item, "COMMENTS", CWIPORDBOM.COMMENTS, sizeof(CWIPORDBOM.COMMENTS));
        TRS.add_string(list_item, "CELL_PROD_TYPE", CWIPORDBOM.CELL_PROD_TYPE, sizeof(CWIPORDBOM.CELL_PROD_TYPE));
        TRS.add_string(list_item, "CELL_POWER_GRADE_1", CWIPORDBOM.CELL_POWER_GRADE_1, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
        TRS.add_string(list_item, "CELL_POWER_GRADE_2", CWIPORDBOM.CELL_POWER_GRADE_2, sizeof(CWIPORDBOM.CELL_POWER_GRADE_2));
        TRS.add_string(list_item, "CELL_CONVERSION_RATE", CWIPORDBOM.CELL_CONVERSION_RATE, sizeof(CWIPORDBOM.CELL_CONVERSION_RATE));
        TRS.add_string(list_item, "CELL_POWER_RATE", CWIPORDBOM.CELL_POWER_RATE, sizeof(CWIPORDBOM.CELL_POWER_RATE));
        TRS.add_char(list_item, "DEL_YN", CWIPORDBOM.DEL_YN);
        TRS.add_string(list_item, "CMF_1", CWIPORDBOM.CMF_1, sizeof(CWIPORDBOM.CMF_1));
        TRS.add_string(list_item, "CMF_2", CWIPORDBOM.CMF_2, sizeof(CWIPORDBOM.CMF_2));
        TRS.add_string(list_item, "CMF_3", CWIPORDBOM.CMF_3, sizeof(CWIPORDBOM.CMF_3));
        TRS.add_string(list_item, "CMF_4", CWIPORDBOM.CMF_4, sizeof(CWIPORDBOM.CMF_4));
        TRS.add_string(list_item, "CMF_5", CWIPORDBOM.CMF_5, sizeof(CWIPORDBOM.CMF_5));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Materials_In_Bom_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

