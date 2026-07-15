/*******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : TIV_view_lot_list_detail.c
    Description : View Lot List Detail related function module

    MES Version : 4.0.0

    Function List
        - TIV_View_Lot_List_Detail()
            + View Lot List Detail By Lots  
        - TIV_VIEW_LOT_LIST_DETAIL()
            + Main Sub function of "TIV_View_Lot_List_Detail"
            + (called by "TIV_View_Lot_List_Detail")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/14  HS Kim         Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

/*******************************************************************************
    TIV_View_Lot_List_Detail()                                                          
        - View Lot List Detail By Lots                                               
    Return Value                                                                  
        - int : 0 (MP_TRUE)                                            
    Arguments                                                                     
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure                       
*******************************************************************************/
int TIV_View_Lot_List_Detail(TRSNode *in_node, 
                             TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT_LIST_DETAIL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT_LIST_DETAIL", out_node);

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
    TIV_VIEW_LOT_LIST_DETAIL()                                                     
        - Main sub function of "TIV_View_Lot_List_Detail" function 
        - View Lot List Detail
    Return Value                                                                  
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)                                  
    Arguments                                                                     
        - char *s_msg_code : Error Message Code                                   
        - TRSNode *in_node : Input Message structure
        - TIV_View_Lot_List_Detail_Out_tag *View_Lot_List_Detail_Out : Output Message structure                       
*******************************************************************************/
int TIV_VIEW_LOT_LIST_DETAIL(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node) 
{
    struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct GET_INVLOTDETAIL_TAG GET_INVLOTDETAIL;
    struct inv_lot_list s_lot_list;
    int  i_seq = 0;
    int  i;
    int  i_lot;
    int  i_next;
    int  b_go_next;
    TRSNode *list_item;


    int i_lot_count;
    TRSNode** inv_lot_list;

    LOG_head("TIV_VIEW_LOT_LIST_DETAIL");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("next_lot_id", MP_NSTR, TRS.get_string(in_node, "NEXT_LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_List_Detail",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_lot_count = TRS.get_item_count(in_node, "LIST");
    inv_lot_list = TRS.get_list(in_node, "LIST");

    DBC_init_get_invlotdetail(&GET_INVLOTDETAIL);

    if(TRS.get_procstep(in_node) == '1')
    {
        i_seq = 1;

        if(i_lot_count < 1)
        {
            strcpy(s_msg_code, "WIP-0001");
            TRS.add_fieldmsg(out_node, "LOT_LIST", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == '2')
    {
        i_seq = 2;

        if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
        {
            strcpy(s_msg_code, "INV-0001");
            TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    TRS.copy(GET_INVLOTDETAIL.FACTORY, sizeof(GET_INVLOTDETAIL.FACTORY), in_node, IN_FACTORY);
    //TRS.copy(GET_INVLOTDETAIL.START_RES_ID, sizeof(GET_INVLOTDETAIL.START_RES_ID), in_node, "RES_ID");
    TRS.copy(GET_INVLOTDETAIL.LOT_ID, sizeof(GET_INVLOTDETAIL.LOT_ID), in_node, "NEXT_LOT_ID");
    TRS.copy(GET_INVLOTDETAIL.OPER, sizeof(GET_INVLOTDETAIL.OPER), in_node, "OPER");
    i_next = 0;
    while(1)
    {
        memset(&s_lot_list, ' ', sizeof(struct inv_lot_list));
        s_lot_list.count = 0;
        i_lot = 0;
        b_go_next = MP_FALSE;

        if(TRS.get_procstep(in_node) == '1')
        {
            for (i = i_next ; i < i_lot_count ; i++)
            {
                TRS.copy(s_lot_list.list_tbl[i_lot].lot_id, sizeof(s_lot_list.list_tbl[i_lot].lot_id), inv_lot_list[i], "LOT_ID");
                i_lot++;

                if(i_lot >= 50)
                {
                    break;
                }
            }
            s_lot_list.count = i_lot;
            i_next += i_lot;
        }

        DBC_open_get_invlotdetail(i_seq, &GET_INVLOTDETAIL, &s_lot_list);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "INV-0004");
            TRS.add_fieldmsg(out_node, "GET_INVLOTDETAIL OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(GET_INVLOTDETAIL.FACTORY), GET_INVLOTDETAIL.FACTORY);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        while(1)
        {
            DBC_fetch_get_invlotdetail(i_seq, &GET_INVLOTDETAIL);
            if(DB_error_code == DB_NOT_FOUND) 
            {
                DBC_close_get_invlotdetail(i_seq);
                b_go_next = MP_TRUE;
                break;
            }
            else if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "INV-0004");
                TRS.add_fieldmsg(out_node, "GET_INVLOTDETAIL FETCH", MP_NVST);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                DBC_close_get_invlotdetail(i_seq);
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            if(COM_check_node_length(out_node) == MP_FALSE)
            {
                TRS.add_string(out_node, "NEXT_LOT_ID", GET_INVLOTDETAIL.LOT_ID, sizeof(GET_INVLOTDETAIL.LOT_ID));
                DBC_close_get_invlotdetail(i_seq);
                break;
            }

            list_item = TRS.add_node(out_node, "LIST");

            TRS.add_string(list_item, "FACTORY", GET_INVLOTDETAIL.FACTORY, sizeof(GET_INVLOTDETAIL.FACTORY));
		    TRS.add_string(list_item, "OPER", GET_INVLOTDETAIL.OPER, sizeof(GET_INVLOTDETAIL.OPER));
		    TRS.add_string(list_item, "LOT_ID", GET_INVLOTDETAIL.LOT_ID, sizeof(GET_INVLOTDETAIL.LOT_ID));
		    TRS.add_string(list_item, "LOT_DESC", GET_INVLOTDETAIL.LOT_DESC, sizeof(GET_INVLOTDETAIL.LOT_DESC));    
		    TRS.add_string(list_item, "MAT_ID", GET_INVLOTDETAIL.MAT_ID, sizeof(GET_INVLOTDETAIL.MAT_ID));
		    TRS.add_int(list_item, "MAT_VER", GET_INVLOTDETAIL.MAT_VER);
		    TRS.add_char(list_item, "LOT_TYPE", GET_INVLOTDETAIL.LOT_TYPE);
            TRS.add_string(list_item, "OWNER_CODE", GET_INVLOTDETAIL.OWNER_CODE, sizeof(GET_INVLOTDETAIL.OWNER_CODE));
		    TRS.add_double(list_item, "QTY_1", GET_INVLOTDETAIL.QTY_1);
		    TRS.add_double(list_item, "QTY_2", GET_INVLOTDETAIL.QTY_2);
		    TRS.add_double(list_item, "QTY_3", GET_INVLOTDETAIL.QTY_3);
		    TRS.add_double(list_item, "CREATE_QTY_1", GET_INVLOTDETAIL.CREATE_QTY_1);
		    TRS.add_double(list_item, "CREATE_QTY_2", GET_INVLOTDETAIL.CREATE_QTY_2);
		    TRS.add_double(list_item, "CREATE_QTY_3", GET_INVLOTDETAIL.CREATE_QTY_3);
		    TRS.add_string(list_item, "CREATE_TIME", GET_INVLOTDETAIL.CREATE_TIME, sizeof(GET_INVLOTDETAIL.CREATE_TIME));
		    TRS.add_char(list_item, "IN_OUT_FLAG", GET_INVLOTDETAIL.IN_OUT_FLAG);
		    TRS.add_string(list_item, "ORDER_ID", GET_INVLOTDETAIL.ORDER_ID, sizeof(GET_INVLOTDETAIL.ORDER_ID));
		    TRS.add_string(list_item, "LINE_NO", GET_INVLOTDETAIL.LINE_NO, sizeof(GET_INVLOTDETAIL.LINE_NO));
		    TRS.add_string(list_item, "UNIT_1", GET_INVLOTDETAIL.UNIT_1, sizeof(GET_INVLOTDETAIL.UNIT_1));
		    TRS.add_string(list_item, "UNIT_2", GET_INVLOTDETAIL.UNIT_2, sizeof(GET_INVLOTDETAIL.UNIT_2));
		    TRS.add_string(list_item, "UNIT_3", GET_INVLOTDETAIL.UNIT_3, sizeof(GET_INVLOTDETAIL.UNIT_3));
		    TRS.add_char(list_item, "INSP_FLAG", GET_INVLOTDETAIL.INSPECTION_FLAG);
		    TRS.add_char(list_item, "INSPECTION_RESULT", GET_INVLOTDETAIL.INSPECTION_RESULT);
		    TRS.add_string(list_item, "LAST_TRAN_CODE", GET_INVLOTDETAIL.LAST_TRAN_CODE, sizeof(GET_INVLOTDETAIL.LAST_TRAN_CODE));
		    TRS.add_string(list_item, "LAST_TRAN_TYPE", GET_INVLOTDETAIL.LAST_TRAN_TYPE, sizeof(GET_INVLOTDETAIL.LAST_TRAN_TYPE));
		    TRS.add_string(list_item, "LAST_TRAN_TIME", GET_INVLOTDETAIL.LAST_TRAN_TIME, sizeof(GET_INVLOTDETAIL.LAST_TRAN_TIME));
		    TRS.add_int(list_item, "LAST_HIST_SEQ", GET_INVLOTDETAIL.LAST_HIST_SEQ);
		    TRS.add_int(list_item, "LAST_ACTIVE_HIST_SEQ", GET_INVLOTDETAIL.LAST_ACTIVE_HIST_SEQ);
		    TRS.add_string(list_item, "LAST_COMMENT", GET_INVLOTDETAIL.LAST_TRAN_COMMENT, sizeof(GET_INVLOTDETAIL.LAST_TRAN_COMMENT));
		    TRS.add_char(list_item, "LOT_DEL_FLAG", GET_INVLOTDETAIL.LOT_DEL_FLAG);
		    TRS.add_enc_string(list_item, "LOT_DEL_USER_ID", GET_INVLOTDETAIL.LOT_DEL_USER_ID, sizeof(GET_INVLOTDETAIL.LOT_DEL_USER_ID));
		    TRS.add_string(list_item, "LOT_DEL_TIME", GET_INVLOTDETAIL.LOT_DEL_TIME, sizeof(GET_INVLOTDETAIL.LOT_DEL_TIME));
		    TRS.add_string(list_item, "LOT_DEL_REASON", GET_INVLOTDETAIL.LOT_DEL_REASON, sizeof(GET_INVLOTDETAIL.LOT_DEL_REASON));
		    TRS.add_string(list_item, "LOCATION", GET_INVLOTDETAIL.LOCATION_NO, sizeof(GET_INVLOTDETAIL.LOCATION_NO));    
		    TRS.add_string(list_item, "LOCATION_NO", GET_INVLOTDETAIL.LOCATION_NO, sizeof(GET_INVLOTDETAIL.LOCATION_NO));    
		    TRS.add_char(list_item, "HOLD_FLAG", GET_INVLOTDETAIL.HOLD_FLAG);
		    TRS.add_string(list_item, "HOLD_CODE", GET_INVLOTDETAIL.HOLD_CODE, sizeof(GET_INVLOTDETAIL.HOLD_CODE));
		    TRS.add_string(list_item, "RELEASE_CODE", GET_INVLOTDETAIL.RELEASE_CODE, sizeof(GET_INVLOTDETAIL.RELEASE_CODE));
		    TRS.add_char(list_item, "PICK_FLAG", GET_INVLOTDETAIL.PICK_FLAG);
		    TRS.add_char(list_item, "SHIP_FLAG", GET_INVLOTDETAIL.SHIP_FLAG);
		    //TRS.add_string(list_item, "FROM_LOT_ID", GET_INVLOTDETAIL.FROM_LOT_ID, sizeof(GET_INVLOTDETAIL.FROM_LOT_ID));
		    //TRS.add_string(list_item, "FROM_OPER", GET_INVLOTDETAIL.FROM_OPER, sizeof(GET_INVLOTDETAIL.FROM_OPER));
		    TRS.add_string(list_item, "TIV_GRADE", GET_INVLOTDETAIL.GRADE, sizeof(GET_INVLOTDETAIL.GRADE));
		    TRS.add_string(list_item, "ADD_ORDER_ID_1", GET_INVLOTDETAIL.ADD_ORDER_ID_1, sizeof(GET_INVLOTDETAIL.ADD_ORDER_ID_1));
		    TRS.add_string(list_item, "ADD_ORDER_LINE_1", GET_INVLOTDETAIL.ADD_ORDER_LINE_1, sizeof(GET_INVLOTDETAIL.ADD_ORDER_LINE_1));
		    TRS.add_string(list_item, "ADD_ORDER_ID_2", GET_INVLOTDETAIL.ADD_ORDER_ID_2, sizeof(GET_INVLOTDETAIL.ADD_ORDER_ID_2));
		    TRS.add_string(list_item, "ADD_ORDER_LINE_2", GET_INVLOTDETAIL.ADD_ORDER_LINE_2, sizeof(GET_INVLOTDETAIL.ADD_ORDER_LINE_2));
		    TRS.add_string(list_item, "ADD_ORDER_ID_3", GET_INVLOTDETAIL.ADD_ORDER_ID_3, sizeof(GET_INVLOTDETAIL.ADD_ORDER_ID_3));
		    TRS.add_string(list_item, "ADD_ORDER_LINE_3", GET_INVLOTDETAIL.ADD_ORDER_LINE_3, sizeof(GET_INVLOTDETAIL.ADD_ORDER_LINE_3));
		    TRS.add_string(list_item, "VENDOR", GET_INVLOTDETAIL.VENDOR_LOT_ID, sizeof(GET_INVLOTDETAIL.VENDOR_LOT_ID));
		    TRS.add_string(list_item, "PO_MAT_ID", GET_INVLOTDETAIL.PO_MAT_ID, sizeof(GET_INVLOTDETAIL.PO_MAT_ID));
		    TRS.add_int(list_item, "PO_SEQ_NUM", GET_INVLOTDETAIL.PO_SEQ_NUM);
		    TRS.add_string(list_item, "INV_CMF_1", GET_INVLOTDETAIL.INV_CMF_1, sizeof(GET_INVLOTDETAIL.INV_CMF_1));
		    TRS.add_string(list_item, "INV_CMF_2", GET_INVLOTDETAIL.INV_CMF_2, sizeof(GET_INVLOTDETAIL.INV_CMF_2));
		    TRS.add_string(list_item, "INV_CMF_3", GET_INVLOTDETAIL.INV_CMF_3, sizeof(GET_INVLOTDETAIL.INV_CMF_3));
		    TRS.add_string(list_item, "INV_CMF_4", GET_INVLOTDETAIL.INV_CMF_4, sizeof(GET_INVLOTDETAIL.INV_CMF_4));
		    TRS.add_string(list_item, "INV_CMF_5", GET_INVLOTDETAIL.INV_CMF_5, sizeof(GET_INVLOTDETAIL.INV_CMF_5));
		    TRS.add_string(list_item, "INV_CMF_6", GET_INVLOTDETAIL.INV_CMF_6, sizeof(GET_INVLOTDETAIL.INV_CMF_6));
		    TRS.add_string(list_item, "INV_CMF_7", GET_INVLOTDETAIL.INV_CMF_7, sizeof(GET_INVLOTDETAIL.INV_CMF_7));
		    TRS.add_string(list_item, "INV_CMF_8", GET_INVLOTDETAIL.INV_CMF_8, sizeof(GET_INVLOTDETAIL.INV_CMF_8));
		    TRS.add_string(list_item, "INV_CMF_9", GET_INVLOTDETAIL.INV_CMF_9, sizeof(GET_INVLOTDETAIL.INV_CMF_9));
		    TRS.add_string(list_item, "INV_CMF_10", GET_INVLOTDETAIL.INV_CMF_10, sizeof(GET_INVLOTDETAIL.INV_CMF_10));
		    TRS.add_string(list_item, "INV_CMF_11", GET_INVLOTDETAIL.INV_CMF_11, sizeof(GET_INVLOTDETAIL.INV_CMF_11));
		    TRS.add_string(list_item, "INV_CMF_12", GET_INVLOTDETAIL.INV_CMF_12, sizeof(GET_INVLOTDETAIL.INV_CMF_12));
		    TRS.add_string(list_item, "INV_CMF_13", GET_INVLOTDETAIL.INV_CMF_13, sizeof(GET_INVLOTDETAIL.INV_CMF_13));
		    TRS.add_string(list_item, "INV_CMF_14", GET_INVLOTDETAIL.INV_CMF_14, sizeof(GET_INVLOTDETAIL.INV_CMF_14));
		    TRS.add_string(list_item, "INV_CMF_15", GET_INVLOTDETAIL.INV_CMF_15, sizeof(GET_INVLOTDETAIL.INV_CMF_15));
		    TRS.add_string(list_item, "INV_CMF_16", GET_INVLOTDETAIL.INV_CMF_16, sizeof(GET_INVLOTDETAIL.INV_CMF_16));
		    TRS.add_string(list_item, "INV_CMF_17", GET_INVLOTDETAIL.INV_CMF_17, sizeof(GET_INVLOTDETAIL.INV_CMF_17));
		    TRS.add_string(list_item, "INV_CMF_18", GET_INVLOTDETAIL.INV_CMF_18, sizeof(GET_INVLOTDETAIL.INV_CMF_18));
		    TRS.add_string(list_item, "INV_CMF_19", GET_INVLOTDETAIL.INV_CMF_19, sizeof(GET_INVLOTDETAIL.INV_CMF_19));
		    TRS.add_string(list_item, "INV_CMF_20", GET_INVLOTDETAIL.INV_CMF_20, sizeof(GET_INVLOTDETAIL.INV_CMF_20));
		    TRS.add_string(list_item, "TIV_OWNER_CODE", GET_INVLOTDETAIL.OWNER_CODE, sizeof(GET_INVLOTDETAIL.OWNER_CODE));
		    TRS.add_string(list_item, "VENDOR_ID", GET_INVLOTDETAIL.VENDOR_ID, sizeof(GET_INVLOTDETAIL.VENDOR_ID));
		    TRS.add_string(list_item, "FROM_TO_LOT_ID", GET_INVLOTDETAIL.FROM_TO_LOT_ID, sizeof(GET_INVLOTDETAIL.FROM_TO_LOT_ID));
			TRS.add_int(list_item, "FROM_TO_HIST_SEQ", GET_INVLOTDETAIL.FROM_TO_HIST_SEQ);
		    TRS.add_char(list_item, "FROM_TO_FLAG", GET_INVLOTDETAIL.FROM_TO_FLAG);
		    TRS.add_string(list_item, "LOT_GROUP_ID", GET_INVLOTDETAIL.LOT_GROUP_ID, sizeof(GET_INVLOTDETAIL.LOT_GROUP_ID));
            

            DBC_init_mtivoprdef(&MTIVOPRDEF);
		    TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
		    memcpy(MTIVOPRDEF.OPER, GET_INVLOTDETAIL.OPER, sizeof(MTIVOPRDEF.OPER));
		    DBC_select_mtivoprdef(1, &MTIVOPRDEF);
            if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
            {
                strcpy(s_msg_code, "WIP-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);

                TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);        
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }  
		    TRS.add_string(list_item, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
	        TRS.add_string(list_item, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));

            DBC_init_mtivmatdef(&MTIVMATDEF);
		    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
		    memcpy(MTIVMATDEF.MAT_ID, GET_INVLOTDETAIL.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
		    MTIVMATDEF.MAT_VER = GET_INVLOTDETAIL.MAT_VER;
		    DBC_select_mtivmatdef(1, &MTIVMATDEF);
            if(DB_error_code != DB_SUCCESS) 
            {
                if(DB_error_code != DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "INV-0004");
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                    TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                    TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.category = MP_LOG_CATE_COMMON;
                    return MP_FALSE;
                }
            }
		    TRS.add_string(list_item, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));
            TRS.add_string(list_item, "MAT_SHORT_DESC", MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC));
            TRS.add_string(list_item, "BASE_MAT_ID", MTIVMATDEF.BASE_MAT_ID, sizeof(MTIVMATDEF.BASE_MAT_ID));
            TRS.add_string(list_item, "MAT_TYPE", MTIVMATDEF.MAT_TYPE, sizeof(MTIVMATDEF.MAT_TYPE));
        }

        if(TRS.get_procstep(in_node) == '2')
        {
            break;
        }

        if(b_go_next == MP_FALSE)
        {
            break;
        }

        if(i_next >= i_lot_count)
        {
            break;
        }
    }

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_List_Detail",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

