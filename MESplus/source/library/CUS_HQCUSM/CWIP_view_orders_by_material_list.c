/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_orders_by_material_list.c
    Description : View Orders_By_Material List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Orders_By_Material_List()
            + View Orders_By_Material definition List
        - CWIP_VIEW_ORDERS_BY_MATERIAL_LIST()
            + Main sub function of CWIP_View_Orders_By_Material_List function
            + View Orders_By_Material definition List
    Detail Description
        - CWIP_VIEW_ORDERS_BY_MATERIAL_LIST()
            + h_proc_step
                + 1 : View Orders_By_Material definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024-05-08             Create by Generator

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Orders_By_Material_List()
        - View Orders_By_Material definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Orders_By_Material_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_ORDERS_BY_MATERIAL_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_ORDERS_BY_MATERIAL_LIST", out_node);

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
    CWIP_VIEW_ORDERS_BY_MATERIAL_LIST()
        - Main sub function of "CWIP_View_Orders_By_Material_List" function
        - View Orders_By_Material definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_ORDERS_BY_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPORDSTS_TAG CWIPORDSTS;
    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_ORDERS_BY_MATERIAL_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1G") == MP_FALSE)
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
    

    i_case = 106;

    CDB_init_cwipordsts(&CWIPORDSTS);
    TRS.copy(CWIPORDSTS.FACTORY, sizeof(CWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.MAT_ID), in_node, "MAT_ID");
    
	CDB_open_cwipordsts(i_case, &CWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPORDSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDSTS.FACTORY), CWIPORDSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwipordsts(i_case, &CWIPORDSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipordsts(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPORDSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDSTS.FACTORY), CWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwipordsts(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        list_item = TRS.add_node(out_node, "ORDERS_BY_MATERIAL_LIST");

        TRS.add_string(list_item, "FACTORY", CWIPORDSTS.FACTORY, sizeof(CWIPORDSTS.FACTORY));
        TRS.add_string(list_item, "ORDER_ID", CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
        TRS.add_string(list_item, "MAT_ID", CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.MAT_ID));
        TRS.add_string(list_item, "PROD_ORDER_VER", CWIPORDSTS.PROD_ORDER_VER, sizeof(CWIPORDSTS.PROD_ORDER_VER));
        TRS.add_string(list_item, "PROD_NO_DESC", CWIPORDSTS.PROD_NO_DESC, sizeof(CWIPORDSTS.PROD_NO_DESC));
        TRS.add_string(list_item, "PROD_ORDER_TYPE", CWIPORDSTS.PROD_ORDER_TYPE, sizeof(CWIPORDSTS.PROD_ORDER_TYPE));
        TRS.add_string(list_item, "PROD_ORDER_SUBTYPE", CWIPORDSTS.PROD_ORDER_SUBTYPE, sizeof(CWIPORDSTS.PROD_ORDER_SUBTYPE));
        TRS.add_double(list_item, "PROD_QTY", CWIPORDSTS.PROD_QTY);
        TRS.add_string(list_item, "PROD_UNIT", CWIPORDSTS.PROD_UNIT, sizeof(CWIPORDSTS.PROD_UNIT));
        TRS.add_string(list_item, "START_DATE", CWIPORDSTS.START_DATE, sizeof(CWIPORDSTS.START_DATE));
        TRS.add_string(list_item, "FINISH_DATE", CWIPORDSTS.FINISH_DATE, sizeof(CWIPORDSTS.FINISH_DATE));
        TRS.add_string(list_item, "WORK_SHOP", CWIPORDSTS.WORK_SHOP, sizeof(CWIPORDSTS.WORK_SHOP));
        TRS.add_char(list_item, "BLOCK_YN", CWIPORDSTS.BLOCK_YN);
        TRS.add_string(list_item, "ROUTE_GRP", CWIPORDSTS.ROUTE_GRP, sizeof(CWIPORDSTS.ROUTE_GRP));
        TRS.add_string(list_item, "ROUTE", CWIPORDSTS.ROUTE, sizeof(CWIPORDSTS.ROUTE));
        TRS.add_string(list_item, "BOM_KEY", CWIPORDSTS.BOM_KEY, sizeof(CWIPORDSTS.BOM_KEY));
        TRS.add_string(list_item, "OPT_BOM", CWIPORDSTS.OPT_BOM, sizeof(CWIPORDSTS.OPT_BOM));
        TRS.add_string(list_item, "COMMENTS", CWIPORDSTS.COMMENTS, sizeof(CWIPORDSTS.COMMENTS));
        TRS.add_string(list_item, "CRE_ID", CWIPORDSTS.CRE_ID, sizeof(CWIPORDSTS.CRE_ID));
        TRS.add_string(list_item, "CRE_DATE", CWIPORDSTS.CRE_DATE, sizeof(CWIPORDSTS.CRE_DATE));
        TRS.add_string(list_item, "MOD_ID", CWIPORDSTS.MOD_ID, sizeof(CWIPORDSTS.MOD_ID));
        TRS.add_string(list_item, "MOD_DATE", CWIPORDSTS.MOD_DATE, sizeof(CWIPORDSTS.MOD_DATE));
        TRS.add_string(list_item, "EX_BATCH_NO", CWIPORDSTS.EX_BATCH_NO, sizeof(CWIPORDSTS.EX_BATCH_NO));
        TRS.add_char(list_item, "PROD_ORDER_STATE", CWIPORDSTS.PROD_ORDER_STATE);
        TRS.add_string(list_item, "SALES_ORDER_GRP", CWIPORDSTS.SALES_ORDER_GRP, sizeof(CWIPORDSTS.SALES_ORDER_GRP));
        TRS.add_string(list_item, "HAND_BOOK", CWIPORDSTS.HAND_BOOK, sizeof(CWIPORDSTS.HAND_BOOK));
        TRS.add_string(list_item, "CO_PROD_NO_1", CWIPORDSTS.CO_PROD_NO_1, sizeof(CWIPORDSTS.CO_PROD_NO_1));
        TRS.add_string(list_item, "CO_PROD_NO_2", CWIPORDSTS.CO_PROD_NO_2, sizeof(CWIPORDSTS.CO_PROD_NO_2));
        TRS.add_string(list_item, "CO_PROD_NO_3", CWIPORDSTS.CO_PROD_NO_3, sizeof(CWIPORDSTS.CO_PROD_NO_3));
        TRS.add_string(list_item, "CO_PROD_NO_4", CWIPORDSTS.CO_PROD_NO_4, sizeof(CWIPORDSTS.CO_PROD_NO_4));
        TRS.add_string(list_item, "CO_PROD_NO_5", CWIPORDSTS.CO_PROD_NO_5, sizeof(CWIPORDSTS.CO_PROD_NO_5));
        TRS.add_string(list_item, "CO_PROD_NO_6", CWIPORDSTS.CO_PROD_NO_6, sizeof(CWIPORDSTS.CO_PROD_NO_6));
        TRS.add_string(list_item, "CO_PROD_NUMBER_1", CWIPORDSTS.CO_PROD_NUMBER_1, sizeof(CWIPORDSTS.CO_PROD_NUMBER_1));
        TRS.add_string(list_item, "CO_PROD_NUMBER_2", CWIPORDSTS.CO_PROD_NUMBER_2, sizeof(CWIPORDSTS.CO_PROD_NUMBER_2));
        TRS.add_string(list_item, "CO_PROD_NUMBER_3", CWIPORDSTS.CO_PROD_NUMBER_3, sizeof(CWIPORDSTS.CO_PROD_NUMBER_3));
        TRS.add_string(list_item, "CO_PROD_NUMBER_4", CWIPORDSTS.CO_PROD_NUMBER_4, sizeof(CWIPORDSTS.CO_PROD_NUMBER_4));
        TRS.add_string(list_item, "CO_PROD_NUMBER_5", CWIPORDSTS.CO_PROD_NUMBER_5, sizeof(CWIPORDSTS.CO_PROD_NUMBER_5));
        TRS.add_string(list_item, "CO_PROD_NUMBER_6", CWIPORDSTS.CO_PROD_NUMBER_6, sizeof(CWIPORDSTS.CO_PROD_NUMBER_6));
        TRS.add_string(list_item, "CELL_RATE", CWIPORDSTS.CELL_RATE, sizeof(CWIPORDSTS.CELL_RATE));
        TRS.add_string(list_item, "BCR_POWER", CWIPORDSTS.BCR_POWER, sizeof(CWIPORDSTS.BCR_POWER));
        TRS.add_string(list_item, "BCR_LIST_CODE", CWIPORDSTS.BCR_LIST_CODE, sizeof(CWIPORDSTS.BCR_LIST_CODE));
        TRS.add_string(list_item, "BCR_PROD_BATCH_NO", CWIPORDSTS.BCR_PROD_BATCH_NO, sizeof(CWIPORDSTS.BCR_PROD_BATCH_NO));
        TRS.add_string(list_item, "BCR_MOD_CLASS", CWIPORDSTS.BCR_MOD_CLASS, sizeof(CWIPORDSTS.BCR_MOD_CLASS));
        TRS.add_string(list_item, "BCR_MOD_TYPE", CWIPORDSTS.BCR_MOD_TYPE, sizeof(CWIPORDSTS.BCR_MOD_TYPE));
        TRS.add_string(list_item, "BCR_MOD_SUBTYPE", CWIPORDSTS.BCR_MOD_SUBTYPE, sizeof(CWIPORDSTS.BCR_MOD_SUBTYPE));
        TRS.add_char(list_item, "CUST_ISC_YN", CWIPORDSTS.CUST_ISC_YN);
        TRS.add_string(list_item, "OPER_NO", CWIPORDSTS.OPER_NO, sizeof(CWIPORDSTS.OPER_NO));
        TRS.add_string(list_item, "WORK_CENTER", CWIPORDSTS.WORK_CENTER, sizeof(CWIPORDSTS.WORK_CENTER));
        TRS.add_string(list_item, "WORK_CENTER_DESC", CWIPORDSTS.WORK_CENTER_DESC, sizeof(CWIPORDSTS.WORK_CENTER_DESC));
        TRS.add_string(list_item, "STD_TEXT_KEY", CWIPORDSTS.STD_TEXT_KEY, sizeof(CWIPORDSTS.STD_TEXT_KEY));
        TRS.add_string(list_item, "OPER_SHORT_DESC", CWIPORDSTS.OPER_SHORT_DESC, sizeof(CWIPORDSTS.OPER_SHORT_DESC));
        TRS.add_char(list_item, "DEL_YN", CWIPORDSTS.DEL_YN);
        TRS.add_string(list_item, "VALUATION_TYPE", CWIPORDSTS.VALUATION_TYPE, sizeof(CWIPORDSTS.VALUATION_TYPE));
        TRS.add_string(list_item, "ZZBOMID", CWIPORDSTS.ZZBOMID, sizeof(CWIPORDSTS.ZZBOMID));
        TRS.add_string(list_item, "ZSHIPNO", CWIPORDSTS.ZSHIPNO, sizeof(CWIPORDSTS.ZSHIPNO));
        TRS.add_string(list_item, "ZARTCOR", CWIPORDSTS.ZARTCOR, sizeof(CWIPORDSTS.ZARTCOR));
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

