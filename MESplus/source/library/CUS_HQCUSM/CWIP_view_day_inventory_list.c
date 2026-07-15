/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_day_inventory_list.c
    Description : View Day_Inventory List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Day_Inventory_List()
            + View Day_Inventory definition List
        - CWIP_VIEW_DAY_INVENTORY_LIST()
            + Main sub function of CWIP_View_Day_Inventory_List function
            + View Day_Inventory definition List
    Detail Description
        - CWIP_VIEW_DAY_INVENTORY_LIST()
            + h_proc_step
                + 1 : View Day_Inventory definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024-04-13             Create by Generator

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Day_Inventory_List()
        - View Day_Inventory definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Day_Inventory_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_DAY_INVENTORY_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_DAY_INVENTORY_LIST", out_node);

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
    CWIP_VIEW_DAY_INVENTORY_LIST()
        - Main sub function of "CWIP_View_Day_Inventory_List" function
        - View Day_Inventory definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_DAY_INVENTORY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPDAYINV_TAG CWIPDAYINV;
	struct MWIPMATDEF_TAG MWIPMATDEF;
    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_DAY_INVENTORY_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("invt_seq", MP_INT, TRS.get_int(in_node, "INVT_SEQ"));
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

    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
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
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    

    i_case = 1;

    CDB_init_cwipdayinv(&CWIPDAYINV);
    TRS.copy(CWIPDAYINV.WORK_DATE, sizeof(CWIPDAYINV.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPDAYINV.FACTORY, sizeof(CWIPDAYINV.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPDAYINV.LINE_ID, sizeof(CWIPDAYINV.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPDAYINV.OPER_TYPE, sizeof(CWIPDAYINV.OPER_TYPE), in_node, "OPER_TYPE");
    TRS.copy(CWIPDAYINV.OPER_NAME, sizeof(CWIPDAYINV.OPER_NAME), in_node, "OPER_NAME");
    CDB_open_cwipdayinv(i_case, &CWIPDAYINV);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPDAYINV OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPDAYINV.WORK_DATE), CWIPDAYINV.WORK_DATE);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPDAYINV.FACTORY), CWIPDAYINV.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPDAYINV.LINE_ID), CWIPDAYINV.LINE_ID);
        TRS.add_fieldmsg(out_node, "INVT_SEQ", MP_INT, CWIPDAYINV.INVT_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwipdayinv(i_case, &CWIPDAYINV);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipdayinv(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPDAYINV FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPDAYINV.WORK_DATE), CWIPDAYINV.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPDAYINV.FACTORY), CWIPDAYINV.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPDAYINV.LINE_ID), CWIPDAYINV.LINE_ID);
            TRS.add_fieldmsg(out_node, "INVT_SEQ", MP_INT, CWIPDAYINV.INVT_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwipdayinv(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_WORK_DATE", CWIPDAYINV.WORK_DATE, sizeof(CWIPDAYINV.WORK_DATE));
            TRS.set_string(out_node, "NEXT_LINE_ID", CWIPDAYINV.LINE_ID, sizeof(CWIPDAYINV.LINE_ID));
            TRS.set_int(out_node, "NEXT_INVT_SEQ", CWIPDAYINV.INVT_SEQ);
            CDB_close_cwipdayinv(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "DAY_INVENTORY_LIST");

        TRS.add_string(list_item, "WORK_DATE", CWIPDAYINV.WORK_DATE, sizeof(CWIPDAYINV.WORK_DATE));
        TRS.add_string(list_item, "FACTORY", CWIPDAYINV.FACTORY, sizeof(CWIPDAYINV.FACTORY));
        TRS.add_string(list_item, "LINE_ID", CWIPDAYINV.LINE_ID, sizeof(CWIPDAYINV.LINE_ID));
        TRS.add_int(list_item, "INVT_SEQ", CWIPDAYINV.INVT_SEQ);
        TRS.add_string(list_item, "OPER_TYPE", CWIPDAYINV.OPER_TYPE, sizeof(CWIPDAYINV.OPER_TYPE));
        TRS.add_string(list_item, "OPER_NAME", CWIPDAYINV.OPER_NAME, sizeof(CWIPDAYINV.OPER_NAME));
        TRS.add_string(list_item, "MAT_ID", CWIPDAYINV.MAT_ID, sizeof(CWIPDAYINV.MAT_ID));
		TRS.add_double(list_item, "MAT_QTY", CWIPDAYINV.MAT_QTY);
        TRS.add_string(list_item, "BATCH_NO", CWIPDAYINV.BATCH_NO, sizeof(CWIPDAYINV.BATCH_NO));
        TRS.add_string(list_item, "TRAN_TIME", CWIPDAYINV.TRAN_TIME, sizeof(CWIPDAYINV.TRAN_TIME));
        TRS.add_string(list_item, "INVT_BRCD", CWIPDAYINV.INVT_BRCD, sizeof(CWIPDAYINV.INVT_BRCD));
        TRS.add_string(list_item, "INVT_MSGS", CWIPDAYINV.INVT_MSGS, sizeof(CWIPDAYINV.INVT_MSGS));
        TRS.add_string(list_item, "CMF_1", CWIPDAYINV.CMF_1, sizeof(CWIPDAYINV.CMF_1));
        TRS.add_string(list_item, "CMF_2", CWIPDAYINV.CMF_2, sizeof(CWIPDAYINV.CMF_2));
        TRS.add_string(list_item, "CMF_3", CWIPDAYINV.CMF_3, sizeof(CWIPDAYINV.CMF_3));
        TRS.add_string(list_item, "CMF_4", CWIPDAYINV.CMF_4, sizeof(CWIPDAYINV.CMF_4));
        TRS.add_string(list_item, "CMF_5", CWIPDAYINV.CMF_5, sizeof(CWIPDAYINV.CMF_5));
        TRS.add_string(list_item, "CMF_6", CWIPDAYINV.CMF_6, sizeof(CWIPDAYINV.CMF_6));
        TRS.add_string(list_item, "CMF_7", CWIPDAYINV.CMF_7, sizeof(CWIPDAYINV.CMF_7));
        TRS.add_string(list_item, "CMF_8", CWIPDAYINV.CMF_8, sizeof(CWIPDAYINV.CMF_8));
        TRS.add_string(list_item, "CMF_9", CWIPDAYINV.CMF_9, sizeof(CWIPDAYINV.CMF_9));
        TRS.add_string(list_item, "CMF_10", CWIPDAYINV.CMF_10, sizeof(CWIPDAYINV.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CWIPDAYINV.CREATE_USER_ID, sizeof(CWIPDAYINV.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CWIPDAYINV.CREATE_TIME, sizeof(CWIPDAYINV.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPDAYINV.UPDATE_USER_ID, sizeof(CWIPDAYINV.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CWIPDAYINV.UPDATE_TIME, sizeof(CWIPDAYINV.UPDATE_TIME));

		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, CWIPDAYINV.MAT_ID, sizeof(CWIPDAYINV.MAT_ID));
		DBC_select_mwipmatdef(110, &MWIPMATDEF);
		if (DB_error_code == DB_SUCCESS)
        {
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		} else {
			TRS.add_string(list_item, "MAT_DESC", " ", sizeof(MWIPMATDEF.MAT_DESC));
			TRS.set_string(list_item, "INVT_MSGS", "The material is not in the master.", sizeof(CWIPDAYINV.INVT_MSGS));
		} 
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Day_Inventory_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

