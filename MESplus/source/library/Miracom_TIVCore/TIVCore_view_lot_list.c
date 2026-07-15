/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot_list.c
    Description : View Inventory Lot List related function module

    MES Version : 5.2.0.0

    Function Listpr
        - TIV_View_Lot_List()
            + View Inventory Lot List
        - TIV_VIEW_LOT_LIST()
            + Main Sub function of "TIV_View_Lot_List"
            + (called by "TIV_View_Lot_List")
        - TIV_View_Lot_List_Validation()
            + Validation Check sub function of "TIV_VIEW_LOT_LIST" function
            + (called by "TIV_VIEW_LOT_LIST")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/29  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Lot_List_Validation(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);


/*******************************************************************************
    TIV_View_Lot_List()
        - View Inventory Lot Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT_LIST", out_node);

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
    TIV_VIEW_LOT_LIST()
        - Main sub function of "TIV_View_Lot_List" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT_LIST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
    //struct MTAPRESMLT_TAG MTAPRESMLT;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    struct MATRNAMSTS_TAG MATRNAMSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    TRSNode *list_item;
	int i_step = 0;
    LOG_head("TIV_View_Lot_List");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* Validation Check */
    if(TIV_View_Lot_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//시간을 가져오기 위해서 
	DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE), in_node, "FROM_DATE");    
	TRS.copy(DBC_Q_COND.TO_DATE, sizeof(DBC_Q_COND.TO_DATE), in_node, "TO_DATE");
	if(COM_isnullspace(DBC_Q_COND.TO_DATE) == MP_TRUE) memcpy(DBC_Q_COND.TO_DATE, DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE));
	TRS.copy(DBC_Q_COND.FROM_TIME, sizeof(DBC_Q_COND.FROM_TIME), in_node, "FROM_TIME");    
	TRS.copy(DBC_Q_COND.TO_TIME, sizeof(DBC_Q_COND.TO_TIME), in_node, "TO_TIME");    
	if(TRS.get_procstep(in_node)=='3')
	{
		DBC_Q_COND.KEY_1[0] ='Y';
		TRS.copy(DBC_Q_COND.KEY_2, sizeof(DBC_Q_COND.KEY_2), in_node, "LEAD_FRAME");  
	}

	if(COM_compare_global_option(TRS.get_factory(in_node), 
                                 "InventoryLocationSecurityCheck", 
                                 'Y') == MP_TRUE)
    {
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY , sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);    
		memcpy(MGCMTBLDAT.TABLE_NAME,"B@TIV_SEC", strlen("B@TIV_SEC"));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, IN_USERID);
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);

		if(memcmp(MGCMTBLDAT.DATA_1, "ALL", 3)!=0 && memcmp(MGCMTBLDAT.DATA_2, "ALL", 3)!=0 )
		{
			TRS.copy(DBC_Q_COND.KEY_3, sizeof(DBC_Q_COND.KEY_3), in_node, IN_USERID);
		}
		
	}

    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);
	
	
	if(TRS.get_procstep(in_node)=='1')
	{
		i_step = 3;
	}
	else if(TRS.get_procstep(in_node)=='2')
	{
		i_step = 4;
	}
	else if(TRS.get_procstep(in_node)=='3') // Added by hans(2013-03-29) -- Inventory Material List (Lead Frame)
	{
		i_step = 902;
	}
    else if(TRS.get_procstep(in_node)=='5')
    {
        i_step = 5;
    }
    else if(TRS.get_procstep(in_node)=='6')
    {
        i_step = 6;
    }
    else if(TRS.get_procstep(in_node)=='7')
    {
        i_step = 7;
    }
	else if(TRS.get_procstep(in_node)=='8')
    {
        i_step = 901;
    }
	else if(TRS.get_procstep(in_node)=='9')
    {
        i_step = 104;
    }

	if(TRS.get_procstep(in_node)=='1' || TRS.get_procstep(in_node) == '2'|| TRS.get_procstep(in_node) == '3'
		|| TRS.get_procstep(in_node) == '5'|| TRS.get_procstep(in_node) == '6'|| TRS.get_procstep(in_node) == '7'
		|| TRS.get_procstep(in_node) == '8'|| TRS.get_procstep(in_node) == '9')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
		TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), in_node, "ORDER_ID");
		TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), in_node, "VENDOR_ID");
        TRS.copy(MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO), in_node, "LOCATION_NO");
		MTIVLOTSTS.IN_OUT_FLAG = TRS.get_char(in_node, "IN_OUT_FLAG");
		TRS.copy(MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID), in_node, "PO_MAT_ID");
		MTIVLOTSTS.PO_SEQ_NUM = TRS.get_int(in_node, "PO_SEQ_NUM");
		MTIVLOTSTS.HOLD_FLAG = TRS.get_char(in_node, "HOLD_FLAG");
		MTIVLOTSTS.LOT_DEL_FLAG = TRS.get_char(in_node, "LOT_DEL_FLAG");
        MTIVLOTSTS.TERM_FLAG = TRS.get_char(in_node, "TERM_FLAG");
		TRS.copy(MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC), in_node, "LOT_ID");

        if(COM_isspace(MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC)) == MP_FALSE)
        {
            memset(MTIVLOTSTS.OPER, ' ', sizeof(MTIVLOTSTS.OPER));
        }

		TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_1");
		TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2), in_node, "INV_CMF_2");
        TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3), in_node, "INV_CMF_3");
		TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4), in_node, "INV_CMF_4");
        TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5), in_node, "INV_CMF_5");
		TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6), in_node, "INV_CMF_6");
        TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7), in_node, "INV_CMF_7");
		TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8), in_node, "INV_CMF_8");
        TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9), in_node, "INV_CMF_9");
		TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10), in_node, "INV_CMF_10");
        TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11), in_node, "INV_CMF_11");
		TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12), in_node, "INV_CMF_12");
        TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13), in_node, "INV_CMF_13");
        TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14), in_node, "INV_CMF_14");
        TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15), in_node, "INV_CMF_15");
        TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16), in_node, "INV_CMF_16");
        TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17), in_node, "INV_CMF_17");
        TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18), in_node, "INV_CMF_18");
        TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19), in_node, "INV_CMF_19");
        TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20), in_node, "INV_CMF_20");

		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "NEXT_LOT_ID");
	}
    else if(TRS.get_procstep(in_node)=='4')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");
		MTIVLOTSTS.MAT_VER = TRS.get_int(in_node,"MAT_VER");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "NEXT_LOT_ID");

		i_step = 103;
	}
	
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
		else if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
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
			DBC_close_mwiplotsts(i_step);
			break;
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
		TRS.add_int(list_item, "LAST_LOT_GRP_SEQ", MTIVLOTSTS.LAST_LOT_GRP_SEQ);
		TRS.add_int(list_item, "LAST_ACTIVE_LOT_GRP_SEQ", MTIVLOTSTS.LAST_ACTIVE_LOT_GRP_SEQ);
		TRS.add_int(list_item, "LAST_HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);
		TRS.add_int(list_item, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
		TRS.add_string(list_item, "LAST_COMMENT", MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT));
		TRS.add_char(list_item, "LOT_DEL_FLAG", MTIVLOTSTS.LOT_DEL_FLAG);
		TRS.add_enc_string(list_item, "LOT_DEL_USER_ID", MTIVLOTSTS.LOT_DEL_USER_ID, sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
		TRS.add_string(list_item, "LOT_DEL_TIME", MTIVLOTSTS.LOT_DEL_TIME, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
		TRS.add_string(list_item, "LOT_DEL_REASON", MTIVLOTSTS.LOT_DEL_REASON, sizeof(MTIVLOTSTS.LOT_DEL_REASON));
		TRS.add_string(list_item, "LOCATION", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));    
		TRS.add_string(list_item, "LOCATION_NO", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));    
		TRS.add_char(list_item, "HOLD_FLAG", MTIVLOTSTS.HOLD_FLAG);
		TRS.add_string(list_item, "HOLD_CODE", MTIVLOTSTS.HOLD_CODE, sizeof(MTIVLOTSTS.HOLD_CODE));
		TRS.add_string(list_item, "RELEASE_CODE", MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE));
		TRS.add_char(list_item, "PICK_FLAG", MTIVLOTSTS.PICK_FLAG);
		TRS.add_char(list_item, "SHIP_FLAG", MTIVLOTSTS.SHIP_FLAG);
		//TRS.add_string(list_item, "FROM_LOT_ID", MTIVLOTSTS.FROM_LOT_ID, sizeof(MTIVLOTSTS.FROM_LOT_ID));
		//TRS.add_string(list_item, "FROM_OPER", MTIVLOTSTS.FROM_OPER, sizeof(MTIVLOTSTS.FROM_OPER));
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
		TRS.add_string(list_item, "EXPIRE_DATE", MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE));
        TRS.add_string(list_item, "INV_IN_TIME", MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME));
		TRS.add_string(list_item, "INV_OUT_TIME", MTIVLOTSTS.INV_OUT_TIME, sizeof(MTIVLOTSTS.INV_OUT_TIME));
		TRS.add_string(list_item, "OINV_IN_TIME", MTIVLOTSTS.OINV_IN_TIME, sizeof(MTIVLOTSTS.OINV_IN_TIME));
		TRS.add_string(list_item, "OINV_OUT_TIME", MTIVLOTSTS.OINV_OUT_TIME, sizeof(MTIVLOTSTS.OINV_OUT_TIME));
		TRS.add_string(list_item, "WIP_IN_TIME", MTIVLOTSTS.WIP_IN_TIME, sizeof(MTIVLOTSTS.WIP_IN_TIME));
		TRS.add_string(list_item, "WIP_OUT_TIME", MTIVLOTSTS.WIP_OUT_TIME, sizeof(MTIVLOTSTS.WIP_OUT_TIME));

		TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTSTS.FROM_TO_HIST_SEQ);
        TRS.add_string(list_item, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
        TRS.add_string(list_item, "INV_CMF_21", MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21));
        TRS.add_string(list_item, "INV_CMF_22", MTIVLOTSTS.INV_CMF_22, sizeof(MTIVLOTSTS.INV_CMF_22));
        TRS.add_string(list_item, "INV_CMF_23", MTIVLOTSTS.INV_CMF_23, sizeof(MTIVLOTSTS.INV_CMF_23));
        TRS.add_string(list_item, "INV_CMF_24", MTIVLOTSTS.INV_CMF_24, sizeof(MTIVLOTSTS.INV_CMF_24));
        TRS.add_string(list_item, "INV_CMF_25", MTIVLOTSTS.INV_CMF_25, sizeof(MTIVLOTSTS.INV_CMF_25));
        TRS.add_string(list_item, "INV_CMF_26", MTIVLOTSTS.INV_CMF_26, sizeof(MTIVLOTSTS.INV_CMF_26));
        TRS.add_string(list_item, "INV_CMF_27", MTIVLOTSTS.INV_CMF_27, sizeof(MTIVLOTSTS.INV_CMF_27));
        TRS.add_string(list_item, "INV_CMF_28", MTIVLOTSTS.INV_CMF_28, sizeof(MTIVLOTSTS.INV_CMF_28));
        TRS.add_string(list_item, "INV_CMF_29", MTIVLOTSTS.INV_CMF_29, sizeof(MTIVLOTSTS.INV_CMF_29));
        TRS.add_string(list_item, "INV_CMF_30", MTIVLOTSTS.INV_CMF_30, sizeof(MTIVLOTSTS.INV_CMF_30));
        TRS.add_char(list_item, "INV_FLAG_1", MTIVLOTSTS.INV_FLAG_1);
        TRS.add_char(list_item, "INV_FLAG_2", MTIVLOTSTS.INV_FLAG_2);
        TRS.add_char(list_item, "INV_FLAG_3", MTIVLOTSTS.INV_FLAG_3);
        TRS.add_char(list_item, "INV_FLAG_4", MTIVLOTSTS.INV_FLAG_4);
        TRS.add_char(list_item, "INV_FLAG_5", MTIVLOTSTS.INV_FLAG_5);
        TRS.add_string(list_item, "ERP_CREATE_DATE", MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE));
        TRS.add_string(list_item, "ERP_INV_IN_DATE", MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE));
        TRS.add_string(list_item, "ERP_OINV_IN_DATE", MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE));
		TRS.add_string(list_item, "ERP_LAST_TRAN_DATE", MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE));



        if(DBC_select_mtivlotsts_scalar(1, &MTIVLOTSTS)>1)
        {
            TRS.add_char(list_item, "MULTY_LOT", 'Y');
        }

        ////View Attach Resource
        //DBC_init_mtapresmlt(&MTAPRESMLT);
        //TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, IN_FACTORY);
        //memcpy(MTAPRESMLT.MAT_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID));
        //memcpy(MTAPRESMLT.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTAPRESMLT.MAT_ID));
        //DBC_select_mtapresmlt(2, &MTAPRESMLT);
        //if(DB_error_code == DB_SUCCESS)
        //{
        //    TRS.add_string(list_item, "ATTACHED_RESOURCE", MTAPRESMLT.RES_ID, sizeof(MTAPRESMLT.RES_ID));
        //}

		DBC_init_mwipmatdef(&MWIPMATDEF);
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
		DBC_select_mwipmatdef(1, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);

                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
        }
		TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
        TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
        TRS.add_string(list_item, "BASE_MAT_ID", MWIPMATDEF.BASE_MAT_ID, sizeof(MWIPMATDEF.BASE_MAT_ID));
        TRS.add_string(list_item, "PACK_UNIT_1", MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1));//PACK_UNIT_1
        TRS.add_string(list_item, "PACK_UNIT_2", MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2));
        TRS.add_double(list_item, "DEF_QTY_1", MWIPMATDEF.DEF_QTY_1);
        TRS.add_double(list_item, "DEF_QTY_2", MWIPMATDEF.DEF_QTY_2);
        TRS.add_string(list_item, "MAT_TYPE", MWIPMATDEF.MAT_TYPE, sizeof(MWIPMATDEF.MAT_TYPE));

		TRS.add_string(list_item, "MAT_CMF_1", MWIPMATDEF.MAT_CMF_1, sizeof(MWIPMATDEF.MAT_CMF_1));
		TRS.add_string(list_item, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, sizeof(MWIPMATDEF.MAT_CMF_2));
		TRS.add_string(list_item, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));
		TRS.add_string(list_item, "MAT_CMF_4", MWIPMATDEF.MAT_CMF_4, sizeof(MWIPMATDEF.MAT_CMF_4));
		TRS.add_string(list_item, "MAT_CMF_5", MWIPMATDEF.MAT_CMF_5, sizeof(MWIPMATDEF.MAT_CMF_5));
		TRS.add_string(list_item, "MAT_CMF_6", MWIPMATDEF.MAT_CMF_6, sizeof(MWIPMATDEF.MAT_CMF_6));
		TRS.add_string(list_item, "MAT_CMF_7", MWIPMATDEF.MAT_CMF_7, sizeof(MWIPMATDEF.MAT_CMF_7));
		TRS.add_string(list_item, "MAT_CMF_8", MWIPMATDEF.MAT_CMF_8, sizeof(MWIPMATDEF.MAT_CMF_8));
		TRS.add_string(list_item, "MAT_CMF_9", MWIPMATDEF.MAT_CMF_9, sizeof(MWIPMATDEF.MAT_CMF_9));
		TRS.add_string(list_item, "MAT_CMF_10", MWIPMATDEF.MAT_CMF_10, sizeof(MWIPMATDEF.MAT_CMF_10));
		TRS.add_string(list_item, "MAT_CMF_11", MWIPMATDEF.MAT_CMF_11, sizeof(MWIPMATDEF.MAT_CMF_11));
		TRS.add_string(list_item, "MAT_CMF_12", MWIPMATDEF.MAT_CMF_12, sizeof(MWIPMATDEF.MAT_CMF_12));
		TRS.add_string(list_item, "MAT_CMF_13", MWIPMATDEF.MAT_CMF_13, sizeof(MWIPMATDEF.MAT_CMF_13));
		TRS.add_string(list_item, "MAT_CMF_14", MWIPMATDEF.MAT_CMF_14, sizeof(MWIPMATDEF.MAT_CMF_14));
		TRS.add_string(list_item, "MAT_CMF_15", MWIPMATDEF.MAT_CMF_15, sizeof(MWIPMATDEF.MAT_CMF_15));
		TRS.add_string(list_item, "MAT_CMF_16", MWIPMATDEF.MAT_CMF_16, sizeof(MWIPMATDEF.MAT_CMF_16));
		TRS.add_string(list_item, "MAT_CMF_17", MWIPMATDEF.MAT_CMF_17, sizeof(MWIPMATDEF.MAT_CMF_17));
		TRS.add_string(list_item, "MAT_CMF_18", MWIPMATDEF.MAT_CMF_18, sizeof(MWIPMATDEF.MAT_CMF_18));
		TRS.add_string(list_item, "MAT_CMF_19", MWIPMATDEF.MAT_CMF_19, sizeof(MWIPMATDEF.MAT_CMF_19));
		TRS.add_string(list_item, "MAT_CMF_20", MWIPMATDEF.MAT_CMF_20, sizeof(MWIPMATDEF.MAT_CMF_20));

		DBC_init_mtivoprdef(&MTIVOPRDEF);
		TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));
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

        DBC_init_mtivtrsdtl(&MTIVTRSDTL);
        TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
        memcpy(MTIVTRSDTL.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID));
        DBC_select_mtivtrsdtl(4, &MTIVTRSDTL);
        if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);

            TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
            TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);  
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);        
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
        }  
        TRS.add_string(list_item, "PACK_UNIT", MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3));
        TRS.add_double(list_item, "PACK_CHANGE_UNIT", MTIVTRSDTL.QTY_3);

         /*LotGroup*/
        DBC_init_matrnamsts(&MATRNAMSTS);
	    TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	    memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_MATERIAL, sizeof(MATRNAMSTS.ATTR_TYPE));
	    memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_TIV_LOT_GROUP, strlen(MP_ATTR_TIV_LOT_GROUP));
        COM_memcpy_add_null(MATRNAMSTS.ATTR_KEY, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
        sprintf(MATRNAMSTS.ATTR_KEY + strlen(MATRNAMSTS.ATTR_KEY), " : %d", MWIPMATDEF.MAT_VER);
        DBC_select_matrnamsts(1, &MATRNAMSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);

                TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
		        TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
                TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE; 
			}
        }

        if(memcmp(MATRNAMSTS.ATTR_VALUE, "Y", strlen("Y"))==0)
        {
            TRS.add_char(list_item, "LOT_GROUP", 'Y');
        }
	}
	
	
	if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Lot_List_Validation()
        - Validation Check sub function of "TIV_VIEW_LOT_LIST" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_List_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;    

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123456789") == MP_FALSE)
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
	
	
