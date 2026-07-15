/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_view_order_list.c
    Description : View Order List function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_View_Order_List()
            + View Order definition List
        - CJCM_VIEW_ORDER_LIST()
            + Main sub function of CJCM_View_Order_List function
            + View Order definition List
    Detail Description
        - CJCM_VIEW_ORDER_LIST()
            + h_proc_step
                + 1 : View Order definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/08/15             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CJCM_View_Order_List()
        - View Order definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_View_Order_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_VIEW_ORDER_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_VIEW_ORDER_LIST", out_node);

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
    CJCM_VIEW_ORDER_LIST()
        - Main sub function of "CJCM_View_Order_List" function
        - View Order definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_VIEW_ORDER_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPORDSTS_TAG CWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MSECUSRDEF_TAG MSECUSRDEF;

    TRSNode *list_item;

    int i_case;
	char s_line_code[30];

    LOG_head("CJCM_VIEW_ORDER_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Order_List",
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
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
   

    i_case = 105;

    CDB_init_cwipordsts(&CWIPORDSTS);
    TRS.copy(CWIPORDSTS.FACTORY, sizeof(CWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
	TRS.copy(CWIPORDSTS.START_DATE, sizeof(CWIPORDSTS.START_DATE), in_node, "FROM_DATE");
	TRS.copy(CWIPORDSTS.FINISH_DATE, sizeof(CWIPORDSTS.FINISH_DATE), in_node, "TO_DATE");
	TRS.copy(CWIPORDSTS.WORK_CENTER, sizeof(CWIPORDSTS.WORK_CENTER), in_node, "LINE_ID");
	TRS.copy(CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.WORK_CENTER), in_node, "MAT_ID");
    CDB_open_cwipordsts(i_case, &CWIPORDSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
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
            strcpy(s_msg_code, "WIP-0004");
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

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //    TRS.set_string(out_node, "NEXT_ORDER_ID", CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
        //    CDB_close_cwipordsts(i_case);
        //    break;
        //}

        list_item = TRS.add_node(out_node, "ORDER_LIST");

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

		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY, CWIPORDSTS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, CWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		DBC_select_mwipmatdef(3, &MWIPMATDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		}

		memset(s_line_code, ' ', sizeof(s_line_code));
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CWIPORDSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		memcpy(MGCMTBLDAT.DATA_2, CWIPORDSTS.WORK_CENTER, sizeof(CWIPORDSTS.WORK_CENTER));
		DBC_select_mgcmtbldat(102, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			memcpy(s_line_code, MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
			TRS.add_string(list_item, "LINE_CODE", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
			TRS.add_string(list_item, "LINE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		////GCM 조회 @JCM_LINE_MANAGER
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CWIPORDSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_LINE_MANAGER", strlen("@JCM_LINE_MANAGER"));
		memcpy(MGCMTBLDAT.KEY_1, s_line_code, sizeof(s_line_code));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MANAGER_ID", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			TRS.add_string(list_item, "ALARM_CODE", MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3));

			DBC_init_msecusrdef(&MSECUSRDEF);
			memcpy(MSECUSRDEF.FACTORY, CWIPORDSTS.FACTORY, sizeof(MSECUSRDEF.FACTORY));
			memcpy(MSECUSRDEF.USER_ID, MGCMTBLDAT.DATA_1, sizeof(MSECUSRDEF.USER_ID));
			DBC_select_msecusrdef(1, &MSECUSRDEF);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "MANAGER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
			}
		}

		////GCM 조회 @JCM_USER_INFO
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CWIPORDSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@JCM_USER_INFO", strlen("@JCM_USER_INFO"));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), list_item, "MANAGER_ID");
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "DEPT_CODE", MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
		}

    }

    /* Not use in customizing
    if(COM_proc_user_routine("CJCM", "CJCM_View_Order_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

