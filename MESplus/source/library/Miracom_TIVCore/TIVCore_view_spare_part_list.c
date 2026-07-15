/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_spare_part_list.c
    Description : View Spare Part List related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Spare_Part_List()
            + View Spare Part List
        - TIV_VIEW_SPARE_PART_LIST()
            + Main Sub function of "TIV_View_Spare_Part_List"
            + (called by "TIV_View_Spare_Part_List")
        - TIV_View_Spare_Part_List_Validation()
            + Validation Check sub function of "TIV_VIEW_SPARE_PART_LIST" function
            + (called by "TIV_VIEW_SPARE_PART_LIST")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/07/23  Patrick         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Spare_Part_List_Validation(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);


/*******************************************************************************
    TIV_View_Spare_Part_List()
        - View Inventory Lot Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Spare_Part_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_SPARE_PART_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_SPARE_PART_LIST", out_node);

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
    TIV_VIEW_SPARE_PART_LIST()
        - Main sub function of "TIV_View_Spare_Part_List" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_SPARE_PART_LIST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MTIVMATDEF_TAG MTIVMATDEF;
    TRSNode *list_item;

    int i_step;

    LOG_head("TIV_View_Spare_Part_List");
    COM_log_add_field_msg(in_node);
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Spare_Part_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(TIV_View_Spare_Part_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "NEXT_LOT_ID");

    TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");

    DB_init_condition(&DBC_Q_COND);
    DBC_Q_COND.KEY_1[0] = 'Y';
    TRS.copy(DBC_Q_COND.KEY_2, sizeof(DBC_Q_COND.KEY_2), in_node, "MODEL");
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

    i_step = 3;

    DBC_open_mtivlotsts(i_step, &MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);       
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1) 
    {
        DBC_fetch_mtivlotsts(i_step, &MTIVLOTSTS);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            DBC_close_mtivlotsts(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "INV-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);            
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mtivlotsts(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_string(out_node, "NEXT_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
            DBC_close_mtivlotsts(i_step);
            break;
        }

		//Get Material information        
		if (TIV_get_mat_ext(s_msg_code, out_node, TRS.get_factory(in_node), MTIVLOTSTS.MAT_ID,MTIVLOTSTS.MAT_VER,
							&MWIPMATDEF, &MTIVMATDEF) == MP_FALSE)
		{
            DBC_close_mtivlotsts(i_step);
			return MP_FALSE;
		}    

        list_item = TRS.add_node(out_node, "LIST");

        TRS.add_string(list_item, "FACTORY", MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
        TRS.add_string(list_item, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
        TRS.add_string(list_item, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
        TRS.add_string(list_item, "LOT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));    
        TRS.add_string(list_item, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
        TRS.add_int(list_item, "MAT_VER", MTIVLOTSTS.MAT_VER);
        TRS.add_char(list_item, "LOT_TYPE", MTIVLOTSTS.LOT_TYPE);
        TRS.add_double(list_item, "QTY_1", MTIVLOTSTS.QTY_1);
        TRS.add_double(list_item, "QTY_2", MTIVLOTSTS.QTY_2);
        TRS.add_double(list_item, "QTY_3", MTIVLOTSTS.QTY_3);
        TRS.add_double(list_item, "CREATE_QTY_1", MTIVLOTSTS.CREATE_QTY_1);
        TRS.add_double(list_item, "CREATE_QTY_2", MTIVLOTSTS.CREATE_QTY_2);
        TRS.add_double(list_item, "CREATE_QTY_3", MTIVLOTSTS.CREATE_QTY_3);
        TRS.add_string(list_item, "CREATE_TIME", MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME));
		TRS.add_string(list_item, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
		TRS.add_string(list_item, "OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));

        TRS.add_char(list_item, "IN_OUT_FLAG", MTIVLOTSTS.IN_OUT_FLAG);
        TRS.add_string(list_item, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
        TRS.add_string(list_item, "LINE_NO", MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO));
        TRS.add_string(list_item, "UNIT_1", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
        TRS.add_string(list_item, "UNIT_2", MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
        TRS.add_string(list_item, "UNIT_3", MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));
        TRS.add_char(list_item, "INSP_FLAG", MTIVLOTSTS.INSPECTION_FLAG);
        TRS.add_char(list_item, "INSPECTION_RESULT", MTIVLOTSTS.INSPECTION_RESULT);
        TRS.add_string(list_item, "LAST_TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
        TRS.add_string(list_item, "LAST_TRAN_TYPE", MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));
        TRS.add_string(list_item, "LAST_TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
        TRS.add_int(list_item, "LAST_HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);
        TRS.add_int(list_item, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);        
        TRS.add_string(list_item, "LAST_COMMENT", MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT));
        TRS.add_char(list_item, "LOT_DEL_FLAG", MTIVLOTSTS.LOT_DEL_FLAG);
        TRS.add_enc_string(list_item, "LOT_DEL_USER_ID", MTIVLOTSTS.LOT_DEL_USER_ID, sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
        TRS.add_string(list_item, "LOT_DEL_TIME", MTIVLOTSTS.LOT_DEL_TIME, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
        TRS.add_string(list_item, "LOT_DEL_REASON", MTIVLOTSTS.LOT_DEL_REASON, sizeof(MTIVLOTSTS.LOT_DEL_REASON));
        TRS.add_string(list_item, "LOCATION", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));    
        TRS.add_char(list_item, "HOLD_FLAG", MTIVLOTSTS.HOLD_FLAG);
        TRS.add_string(list_item, "HOLD_CODE", MTIVLOTSTS.HOLD_CODE, sizeof(MTIVLOTSTS.HOLD_CODE));
        TRS.add_string(list_item, "RELEASE_CODE", MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE));
        TRS.add_char(list_item, "PICK_FLAG", MTIVLOTSTS.PICK_FLAG);
        TRS.add_char(list_item, "SHIP_FLAG", MTIVLOTSTS.SHIP_FLAG);        
        TRS.add_string(list_item, "TIV_GRADE", MTIVLOTSTS.GRADE, sizeof(MTIVLOTSTS.GRADE));
        TRS.add_string(list_item, "ADD_ORDER_ID_1", MTIVLOTSTS.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS.ADD_ORDER_ID_1));
        TRS.add_string(list_item, "ADD_ORDER_LINE_1", MTIVLOTSTS.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_1));
        TRS.add_string(list_item, "ADD_ORDER_ID_2", MTIVLOTSTS.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS.ADD_ORDER_ID_2));
        TRS.add_string(list_item, "ADD_ORDER_LINE_2", MTIVLOTSTS.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_2));
        TRS.add_string(list_item, "ADD_ORDER_ID_3", MTIVLOTSTS.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS.ADD_ORDER_ID_3));
        TRS.add_string(list_item, "ADD_ORDER_LINE_3", MTIVLOTSTS.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_3));
        TRS.add_string(list_item, "VENDOR", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
        TRS.add_string(list_item, "PO_MAT_ID", MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID));
        TRS.add_int(list_item, "PO_SEQ_NUM", MTIVLOTSTS.PO_SEQ_NUM);
        TRS.add_string(list_item, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
        TRS.add_string(list_item, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
        TRS.add_string(list_item, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
        TRS.add_string(list_item, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
        TRS.add_string(list_item, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
        TRS.add_string(list_item, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
        TRS.add_string(list_item, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
        TRS.add_string(list_item, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
        TRS.add_string(list_item, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
        TRS.add_string(list_item, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
        TRS.add_string(list_item, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
        TRS.add_string(list_item, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
        TRS.add_string(list_item, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
        TRS.add_string(list_item, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
        TRS.add_string(list_item, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
        TRS.add_string(list_item, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
        TRS.add_string(list_item, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
        TRS.add_string(list_item, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
        TRS.add_string(list_item, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
        TRS.add_string(list_item, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
        TRS.add_string(list_item, "TIV_OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
        TRS.add_string(list_item, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
        TRS.add_string(list_item, "FROM_TO_LOT_ID", MTIVLOTSTS.FROM_TO_LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
		TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTSTS.FROM_TO_HIST_SEQ);
        TRS.add_char(list_item, "FROM_TO_FLAG", MTIVLOTSTS.FROM_TO_FLAG);
        TRS.add_string(list_item, "LOT_GROUP_ID", MTIVLOTSTS.LOT_GROUP_ID, sizeof(MTIVLOTSTS.LOT_GROUP_ID));

        DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
        MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
        DBC_select_mwipmatdef(1, &MWIPMATDEF);

        TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
        TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));

		//TRS.add_string(list_item, "SPARE_PART_TYPE", MTIVMATDEF.SPARE_PART_TYPE, sizeof(MTIVMATDEF.SPARE_PART_TYPE));
		//TRS.add_string(list_item, "SPARE_PART_MODEL", MTIVMATDEF.MODEL, sizeof(MTIVMATDEF.MODEL));
    }    


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Spare_Part_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Spare_Part_List_Validation()
        - Validation Check sub function of "TIV_VIEW_SPARE_PART_LIST" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Spare_Part_List_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;    

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }    

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);

    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0005");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }    

    return MP_TRUE;
}