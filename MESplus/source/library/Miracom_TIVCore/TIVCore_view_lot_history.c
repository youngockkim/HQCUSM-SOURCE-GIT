/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot_history.c
    Description : View Inventory Lot History related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Lot_History()
            + View Inventory Lot History
        - TIV_VIEW_LOT_HISTORY()
            + Main Sub function of "TIV_View_Lot_History"
            + (called by "TIV_View_Lot_History")
        - TIV_View_Lot_History_Validation()
            + Validation Check sub function of "TIV_VIEW_LOT_HISTORY" function
            + (called by "TIV_VIEW_LOT_HISTORY")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/24  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Lot_History_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


/*******************************************************************************
    TIV_View_Lot_History()
        - View Inventory Lot History
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_History(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT_HISTORY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT_HISTORY", out_node);

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
    TIV_VIEW_LOT_HISTORY()
        - Main sub function of "TIV_View_Lot_History" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT_HISTORY(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MTIVMATUSE_TAG MTIVMATUSE;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
//	struct CTIVISPHIS_TAG CTIVISPHIS;

	struct MTIVLOTLSM_TAG MTIVLOTLSM;
	struct MTIVLOTCVM_TAG MTIVLOTCVM;

	//struct CWIPWRKDAT_TAG CWIPWRKDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MTIVSHPLOT_TAG MTIVSHPLOT;
	//struct CWIPORDDEF_TAG CWIPORDDEF;

    TRSNode * list_item;
	TRSNode * sub_item;

    int		i_step = 0;
    int		i_his_step = 0;
	int		i_sub_step = 0;

	char	s_oper_id[10];
	char	s_oper_desc[200];

	char	s_mat_id[30];
	char	s_mat_short_desc[50];
	char	s_mat_desc[200];
	 
	char	s_res_id[20];
	char	s_res_short_desc[50];
	char	s_res_desc[200];
	 
	char	s_wip_oper_id[10];
	char	s_wip_oper_desc[200];

	char	c_wip_or_inv = ' ';

    LOG_head("TIV_View_Lot_History");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("hist_seq", MP_INT, TRS.get_int(in_node, "HIST_SEQ"));
    LOG_add("next_hist_seq", MP_INT, TRS.get_int(in_node, "NEXT_HIST_SEQ"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_History",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
	 
	memset(s_mat_id, ' ', sizeof(s_mat_id));	
	memset(s_mat_short_desc, ' ', sizeof(s_mat_short_desc));
	memset(s_mat_desc, ' ', sizeof(s_mat_desc));
	
	memset(s_oper_id, ' ', sizeof(s_oper_id));	
	memset(s_oper_desc, ' ', sizeof(s_oper_desc));

	memset(s_res_id, ' ', sizeof(s_res_id));	
	memset(s_res_short_desc, ' ', sizeof(s_res_short_desc));
	memset(s_res_desc, ' ', sizeof(s_res_desc));

	memset(s_wip_oper_id, ' ', sizeof(s_wip_oper_id));	
	memset(s_wip_oper_desc, ' ', sizeof(s_wip_oper_desc));

    /* Validation Check */
    if(TIV_View_Lot_History_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(TRS.get_procstep(in_node)=='1')
    {
        DBC_init_mtivlothis(&MTIVLOTHIS);
        TRS.copy(MTIVLOTHIS.FACTORY , sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);    
        TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "LOT_ID");
        MTIVLOTHIS.HIST_DEL_FLAG = TRS.get_char(in_node, "INCLUDE_DEL_HIST");
        MTIVLOTHIS.HIST_SEQ = TRS.get_int(in_node, "NEXT_HIST_SEQ");    

		TRS.copy(MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME), in_node, "FROM_TIME");
		TRS.copy(MTIVLOTHIS.SYS_TRAN_TIME, sizeof(MTIVLOTHIS.SYS_TRAN_TIME), in_node, "TO_TIME");
		 
		i_his_step = 7;

		DBC_open_mtivlothis(i_his_step, &MTIVLOTHIS);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "INV-0011");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
            TRS.add_fieldmsg(out_node, "MTIVLOTHIS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTHIS.OPER), MTIVLOTHIS.OPER);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS.HIST_SEQ);
            
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        while(1)
        {
            DBC_fetch_mtivlothis(i_his_step, &MTIVLOTHIS);
            if(DB_error_code == DB_NOT_FOUND) 
            {
                DBC_close_mtivlothis(i_his_step);
                break;
            }
            else if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "INV-0004");
                TRS.add_fieldmsg(out_node, "MTIVLOTHIS OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
                TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTHIS.OPER), MTIVLOTHIS.OPER);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);
                TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS.HIST_SEQ);

				TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

                DBC_close_mtivlothis(i_his_step);
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            if(COM_check_node_length(out_node) == MP_FALSE)
            {
	    		TRS.set_int(out_node, "NEXT_HIST_SEQ", MTIVLOTHIS.HIST_SEQ);

                DBC_close_mtivlothis(i_his_step);
                break;
            }
            else
            {
                list_item = TRS.add_node(out_node, "HIST_LIST");
				TRS.add_string(list_item, "FACTORY", MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY));
				TRS.add_string(list_item, "LOT_ID", MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID));
				TRS.add_int(list_item, "LOT_GRP_SEQ", MTIVLOTHIS.LOT_GRP_SEQ);
				TRS.add_string(list_item, "TRAN_CODE", MTIVLOTHIS.TRAN_CODE, sizeof(MTIVLOTHIS.TRAN_CODE));
				TRS.add_string(list_item, "TRAN_TYPE", MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE));
				TRS.add_string(list_item, "TRAN_TIME", MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME));
				TRS.add_string(list_item, "SYS_TRAN_TIME", MTIVLOTHIS.SYS_TRAN_TIME, sizeof(MTIVLOTHIS.SYS_TRAN_TIME));
				TRS.add_string(list_item, "MAT_ID", MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID));
				TRS.add_int(list_item, "MAT_VER", MTIVLOTHIS.MAT_VER);
				TRS.add_string(list_item, "OPER", MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER));
				TRS.add_char(list_item, "LOT_TYPE", MTIVLOTHIS.LOT_TYPE);
				TRS.add_double(list_item, "QTY_1", MTIVLOTHIS.QTY_1);
				TRS.add_double(list_item, "QTY_2", MTIVLOTHIS.QTY_2);
				TRS.add_double(list_item, "QTY_3", MTIVLOTHIS.QTY_3);
				TRS.add_double(list_item, "CREATE_QTY_1", MTIVLOTHIS.CREATE_QTY_1);
				TRS.add_double(list_item, "CREATE_QTY_2", MTIVLOTHIS.CREATE_QTY_2);
				TRS.add_double(list_item, "CREATE_QTY_3", MTIVLOTHIS.CREATE_QTY_3);
				TRS.add_string(list_item, "CREATE_TIME", MTIVLOTHIS.CREATE_TIME, sizeof(MTIVLOTHIS.CREATE_TIME));
				TRS.add_char(list_item, "IN_OUT_FLAG", MTIVLOTHIS.IN_OUT_FLAG);
				TRS.add_string(list_item, "FROM_TO_LOT_ID", MTIVLOTHIS.FROM_TO_LOT_ID, sizeof(MTIVLOTHIS.FROM_TO_LOT_ID));
				TRS.add_int(list_item, "FROM_TO_LOT_GRP_SEQ", MTIVLOTHIS.FROM_TO_LOT_GRP_SEQ);
				TRS.add_char(list_item, "FROM_TO_FLAG", MTIVLOTHIS.FROM_TO_FLAG);
				TRS.add_double(list_item, "FROM_TO_QTY_1", MTIVLOTHIS.FROM_TO_QTY_1);
				TRS.add_double(list_item, "FROM_TO_QTY_2", MTIVLOTHIS.FROM_TO_QTY_2);
				TRS.add_double(list_item, "FROM_TO_QTY_3", MTIVLOTHIS.FROM_TO_QTY_3);
				TRS.add_string(list_item, "PROD_LOT_ID", MTIVLOTHIS.PROD_LOT_ID, sizeof(MTIVLOTHIS.PROD_LOT_ID));
				TRS.add_int(list_item, "PROD_HIST_SEQ", MTIVLOTHIS.PROD_HIST_SEQ);
				TRS.add_double(list_item, "PROD_QTY_1", MTIVLOTHIS.PROD_QTY_1);
				TRS.add_double(list_item, "PROD_QTY_2", MTIVLOTHIS.PROD_QTY_2);
				TRS.add_double(list_item, "PROD_QTY_3", MTIVLOTHIS.PROD_QTY_3);
				TRS.add_string(list_item, "ORDER_ID", MTIVLOTHIS.ORDER_ID, sizeof(MTIVLOTHIS.ORDER_ID));
				/*TRS.add_string(list_item, "LINE_NO", MTIVLOTHIS.LINE_NO, sizeof(MTIVLOTHIS.LINE_NO));*/
				TRS.add_string(list_item, "OLD_FACTORY", MTIVLOTHIS.OLD_FACTORY, sizeof(MTIVLOTHIS.OLD_FACTORY));
				TRS.add_string(list_item, "OLD_OPER", MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER));
				TRS.add_double(list_item, "OLD_QTY_1", MTIVLOTHIS.OLD_QTY_1);
				TRS.add_double(list_item, "OLD_QTY_2", MTIVLOTHIS.OLD_QTY_2);
				TRS.add_double(list_item, "OLD_QTY_3", MTIVLOTHIS.OLD_QTY_3);
				TRS.add_string(list_item, "UNIT_1", MTIVLOTHIS.UNIT_1, sizeof(MTIVLOTHIS.UNIT_1));
				TRS.add_string(list_item, "UNIT_2", MTIVLOTHIS.UNIT_2, sizeof(MTIVLOTHIS.UNIT_2));
				TRS.add_string(list_item, "UNIT_3", MTIVLOTHIS.UNIT_3, sizeof(MTIVLOTHIS.UNIT_3));
				TRS.add_char(list_item, "INSPECTION_FLAG", MTIVLOTHIS.INSPECTION_FLAG);
				TRS.add_char(list_item, "INSPECTION_RESULT", MTIVLOTHIS.INSPECTION_RESULT);
				TRS.add_string(list_item, "TRAN_COMMENT", MTIVLOTHIS.TRAN_COMMENT, sizeof(MTIVLOTHIS.TRAN_COMMENT));
				TRS.add_string(list_item, "TRAN_USER_ID", MTIVLOTHIS.TRAN_USER_ID, sizeof(MTIVLOTHIS.TRAN_USER_ID));
				TRS.add_char(list_item, "LOT_DEL_FLAG", MTIVLOTHIS.LOT_DEL_FLAG);
				TRS.add_string(list_item, "LOT_DEL_USER_ID", MTIVLOTHIS.LOT_DEL_USER_ID, sizeof(MTIVLOTHIS.LOT_DEL_USER_ID));
				TRS.add_string(list_item, "LOT_DEL_TIME", MTIVLOTHIS.LOT_DEL_TIME, sizeof(MTIVLOTHIS.LOT_DEL_TIME));
				TRS.add_string(list_item, "LOT_DEL_REASON", MTIVLOTHIS.LOT_DEL_REASON, sizeof(MTIVLOTHIS.LOT_DEL_REASON));
				TRS.add_char(list_item, "HIST_DEL_FLAG", MTIVLOTHIS.HIST_DEL_FLAG);
				TRS.add_string(list_item, "HIST_DEL_USER_ID", MTIVLOTHIS.HIST_DEL_USER_ID, sizeof(MTIVLOTHIS.HIST_DEL_USER_ID));
				TRS.add_string(list_item, "HIST_DEL_TIME", MTIVLOTHIS.HIST_DEL_TIME, sizeof(MTIVLOTHIS.HIST_DEL_TIME));
				TRS.add_string(list_item, "LOCATION_NO", MTIVLOTHIS.LOCATION_NO, sizeof(MTIVLOTHIS.LOCATION_NO));
				TRS.add_char(list_item, "HOLD_FLAG", MTIVLOTHIS.HOLD_FLAG);
				TRS.add_string(list_item, "HOLD_CODE", MTIVLOTHIS.HOLD_CODE, sizeof(MTIVLOTHIS.HOLD_CODE));
				TRS.add_string(list_item, "RELEASE_CODE", MTIVLOTHIS.RELEASE_CODE, sizeof(MTIVLOTHIS.RELEASE_CODE));
				TRS.add_char(list_item, "PICK_FLAG", MTIVLOTHIS.PICK_FLAG);
				TRS.add_char(list_item, "SHIP_FLAG", MTIVLOTHIS.SHIP_FLAG);
				TRS.add_string(list_item, "GRADE", MTIVLOTHIS.GRADE, sizeof(MTIVLOTHIS.GRADE));
				TRS.add_string(list_item, "ADD_ORDER_ID_1", MTIVLOTHIS.ADD_ORDER_ID_1, sizeof(MTIVLOTHIS.ADD_ORDER_ID_1));
				TRS.add_string(list_item, "ADD_ORDER_LINE_1", MTIVLOTHIS.ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_1));
				TRS.add_string(list_item, "ADD_ORDER_ID_2", MTIVLOTHIS.ADD_ORDER_ID_2, sizeof(MTIVLOTHIS.ADD_ORDER_ID_2));
				TRS.add_string(list_item, "ADD_ORDER_LINE_2", MTIVLOTHIS.ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_2));
				TRS.add_string(list_item, "ADD_ORDER_ID_3", MTIVLOTHIS.ADD_ORDER_ID_3, sizeof(MTIVLOTHIS.ADD_ORDER_ID_3));
				TRS.add_string(list_item, "ADD_ORDER_LINE_3", MTIVLOTHIS.ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_3));
				TRS.add_string(list_item, "VENDOR_LOT_ID", MTIVLOTHIS.VENDOR_LOT_ID, sizeof(MTIVLOTHIS.VENDOR_LOT_ID));
				TRS.add_string(list_item, "PO_MAT_ID", MTIVLOTHIS.PO_MAT_ID, sizeof(MTIVLOTHIS.PO_MAT_ID));
				TRS.add_int(list_item, "PO_SEQ_NUM", MTIVLOTHIS.PO_SEQ_NUM);
				TRS.add_string(list_item, "INV_CMF_1", MTIVLOTHIS.INV_CMF_1, sizeof(MTIVLOTHIS.INV_CMF_1));
				TRS.add_string(list_item, "INV_CMF_2", MTIVLOTHIS.INV_CMF_2, sizeof(MTIVLOTHIS.INV_CMF_2));
				TRS.add_string(list_item, "INV_CMF_3", MTIVLOTHIS.INV_CMF_3, sizeof(MTIVLOTHIS.INV_CMF_3));
				TRS.add_string(list_item, "INV_CMF_4", MTIVLOTHIS.INV_CMF_4, sizeof(MTIVLOTHIS.INV_CMF_4));
				TRS.add_string(list_item, "INV_CMF_5", MTIVLOTHIS.INV_CMF_5, sizeof(MTIVLOTHIS.INV_CMF_5));
				TRS.add_string(list_item, "INV_CMF_6", MTIVLOTHIS.INV_CMF_6, sizeof(MTIVLOTHIS.INV_CMF_6));
				TRS.add_string(list_item, "INV_CMF_7", MTIVLOTHIS.INV_CMF_7, sizeof(MTIVLOTHIS.INV_CMF_7));
				TRS.add_string(list_item, "INV_CMF_8", MTIVLOTHIS.INV_CMF_8, sizeof(MTIVLOTHIS.INV_CMF_8));
				TRS.add_string(list_item, "INV_CMF_9", MTIVLOTHIS.INV_CMF_9, sizeof(MTIVLOTHIS.INV_CMF_9));
				TRS.add_string(list_item, "INV_CMF_10", MTIVLOTHIS.INV_CMF_10, sizeof(MTIVLOTHIS.INV_CMF_10));
				TRS.add_string(list_item, "INV_CMF_11", MTIVLOTHIS.INV_CMF_11, sizeof(MTIVLOTHIS.INV_CMF_11));
				TRS.add_string(list_item, "INV_CMF_12", MTIVLOTHIS.INV_CMF_12, sizeof(MTIVLOTHIS.INV_CMF_12));
				TRS.add_string(list_item, "INV_CMF_13", MTIVLOTHIS.INV_CMF_13, sizeof(MTIVLOTHIS.INV_CMF_13));
				TRS.add_string(list_item, "INV_CMF_14", MTIVLOTHIS.INV_CMF_14, sizeof(MTIVLOTHIS.INV_CMF_14));
				TRS.add_string(list_item, "INV_CMF_15", MTIVLOTHIS.INV_CMF_15, sizeof(MTIVLOTHIS.INV_CMF_15));
				TRS.add_string(list_item, "INV_CMF_16", MTIVLOTHIS.INV_CMF_16, sizeof(MTIVLOTHIS.INV_CMF_16));
				TRS.add_string(list_item, "INV_CMF_17", MTIVLOTHIS.INV_CMF_17, sizeof(MTIVLOTHIS.INV_CMF_17));
				TRS.add_string(list_item, "INV_CMF_18", MTIVLOTHIS.INV_CMF_18, sizeof(MTIVLOTHIS.INV_CMF_18));
				TRS.add_string(list_item, "INV_CMF_19", MTIVLOTHIS.INV_CMF_19, sizeof(MTIVLOTHIS.INV_CMF_19));
				TRS.add_string(list_item, "INV_CMF_20", MTIVLOTHIS.INV_CMF_20, sizeof(MTIVLOTHIS.INV_CMF_20));
				TRS.add_string(list_item, "OWNER_CODE", MTIVLOTHIS.OWNER_CODE, sizeof(MTIVLOTHIS.OWNER_CODE));
				TRS.add_string(list_item, "VENDOR_ID", MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID));
				TRS.add_string(list_item, "FROM_TO_OPER", MTIVLOTHIS.FROM_TO_OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
				TRS.add_string(list_item, "OLD_LOCATION_NO", MTIVLOTHIS.OLD_LOCATION_NO, sizeof(MTIVLOTHIS.OLD_LOCATION_NO));
				TRS.add_int(list_item, "HIST_SEQ", MTIVLOTHIS.HIST_SEQ);
				TRS.add_string(list_item, "LOT_GROUP_ID", MTIVLOTHIS.LOT_GROUP_ID, sizeof(MTIVLOTHIS.LOT_GROUP_ID));
				TRS.add_string(list_item, "EXPIRE_DATE", MTIVLOTHIS.EXPIRE_DATE, sizeof(MTIVLOTHIS.EXPIRE_DATE));
				TRS.add_string(list_item, "INV_IN_TIME", MTIVLOTHIS.INV_IN_TIME, sizeof(MTIVLOTHIS.INV_IN_TIME));
				TRS.add_string(list_item, "INV_OUT_TIME", MTIVLOTHIS.INV_OUT_TIME, sizeof(MTIVLOTHIS.INV_OUT_TIME));
				TRS.add_string(list_item, "OINV_IN_TIME", MTIVLOTHIS.OINV_IN_TIME, sizeof(MTIVLOTHIS.OINV_IN_TIME));
				TRS.add_string(list_item, "OINV_OUT_TIME", MTIVLOTHIS.OINV_OUT_TIME, sizeof(MTIVLOTHIS.OINV_OUT_TIME));
				TRS.add_string(list_item, "WIP_IN_TIME", MTIVLOTHIS.WIP_IN_TIME, sizeof(MTIVLOTHIS.WIP_IN_TIME));
				TRS.add_string(list_item, "WIP_OUT_TIME", MTIVLOTHIS.WIP_OUT_TIME, sizeof(MTIVLOTHIS.WIP_OUT_TIME));
				TRS.add_string(list_item, "TRAN_CMF_1", MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
				TRS.add_string(list_item, "TRAN_CMF_2", MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2));
				TRS.add_string(list_item, "TRAN_CMF_3", MTIVLOTHIS.TRAN_CMF_3, sizeof(MTIVLOTHIS.TRAN_CMF_3));
				TRS.add_string(list_item, "TRAN_CMF_4", MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVLOTHIS.TRAN_CMF_4));
				TRS.add_string(list_item, "TRAN_CMF_5", MTIVLOTHIS.TRAN_CMF_5, sizeof(MTIVLOTHIS.TRAN_CMF_5));
				TRS.add_string(list_item, "TRAN_CMF_6", MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6));
				TRS.add_string(list_item, "TRAN_CMF_7", MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7));
				TRS.add_string(list_item, "TRAN_CMF_8", MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8));
				TRS.add_string(list_item, "TRAN_CMF_9", MTIVLOTHIS.TRAN_CMF_9, sizeof(MTIVLOTHIS.TRAN_CMF_9));
				TRS.add_string(list_item, "TRAN_CMF_10", MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10));
				TRS.add_string(list_item, "TRAN_CMF_11", MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11));
				TRS.add_string(list_item, "TRAN_CMF_12", MTIVLOTHIS.TRAN_CMF_12, sizeof(MTIVLOTHIS.TRAN_CMF_12));
				TRS.add_string(list_item, "TRAN_CMF_13", MTIVLOTHIS.TRAN_CMF_13, sizeof(MTIVLOTHIS.TRAN_CMF_13));
				TRS.add_string(list_item, "TRAN_CMF_14", MTIVLOTHIS.TRAN_CMF_14, sizeof(MTIVLOTHIS.TRAN_CMF_14));
				TRS.add_string(list_item, "TRAN_CMF_15", MTIVLOTHIS.TRAN_CMF_15, sizeof(MTIVLOTHIS.TRAN_CMF_15));
				TRS.add_string(list_item, "TRAN_CMF_16", MTIVLOTHIS.TRAN_CMF_16, sizeof(MTIVLOTHIS.TRAN_CMF_16));
				TRS.add_string(list_item, "TRAN_CMF_17", MTIVLOTHIS.TRAN_CMF_17, sizeof(MTIVLOTHIS.TRAN_CMF_17));
				TRS.add_string(list_item, "TRAN_CMF_18", MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18));
				TRS.add_string(list_item, "TRAN_CMF_19", MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19));
				TRS.add_string(list_item, "TRAN_CMF_20", MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20));
				TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTHIS.FROM_TO_HIST_SEQ);
				TRS.add_string(list_item, "CREATE_CODE", MTIVLOTHIS.CREATE_CODE, sizeof(MTIVLOTHIS.CREATE_CODE));

				TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTHIS.FROM_TO_HIST_SEQ);
				TRS.add_string(list_item, "CREATE_CODE", MTIVLOTHIS.CREATE_CODE, sizeof(MTIVLOTHIS.CREATE_CODE));
				TRS.add_string(list_item, "INV_CMF_21", MTIVLOTHIS.INV_CMF_21, sizeof(MTIVLOTHIS.INV_CMF_21));
				TRS.add_string(list_item, "INV_CMF_22", MTIVLOTHIS.INV_CMF_22, sizeof(MTIVLOTHIS.INV_CMF_22));
				TRS.add_string(list_item, "INV_CMF_23", MTIVLOTHIS.INV_CMF_23, sizeof(MTIVLOTHIS.INV_CMF_23));
				TRS.add_string(list_item, "INV_CMF_24", MTIVLOTHIS.INV_CMF_24, sizeof(MTIVLOTHIS.INV_CMF_24));
				TRS.add_string(list_item, "INV_CMF_25", MTIVLOTHIS.INV_CMF_25, sizeof(MTIVLOTHIS.INV_CMF_25));
				TRS.add_string(list_item, "INV_CMF_26", MTIVLOTHIS.INV_CMF_26, sizeof(MTIVLOTHIS.INV_CMF_26));
				TRS.add_string(list_item, "INV_CMF_27", MTIVLOTHIS.INV_CMF_27, sizeof(MTIVLOTHIS.INV_CMF_27));
				TRS.add_string(list_item, "INV_CMF_28", MTIVLOTHIS.INV_CMF_28, sizeof(MTIVLOTHIS.INV_CMF_28));
				TRS.add_string(list_item, "INV_CMF_29", MTIVLOTHIS.INV_CMF_29, sizeof(MTIVLOTHIS.INV_CMF_29));
				TRS.add_string(list_item, "INV_CMF_30", MTIVLOTHIS.INV_CMF_30, sizeof(MTIVLOTHIS.INV_CMF_30));
				TRS.add_char(list_item, "INV_FLAG_1", MTIVLOTHIS.INV_FLAG_1);
				TRS.add_char(list_item, "INV_FLAG_2", MTIVLOTHIS.INV_FLAG_2);
				TRS.add_char(list_item, "INV_FLAG_3", MTIVLOTHIS.INV_FLAG_3);
				TRS.add_char(list_item, "INV_FLAG_4", MTIVLOTHIS.INV_FLAG_4);
				TRS.add_char(list_item, "INV_FLAG_5", MTIVLOTHIS.INV_FLAG_5);
				TRS.add_string(list_item, "ERP_CREATE_DATE", MTIVLOTHIS.ERP_CREATE_DATE, sizeof(MTIVLOTHIS.ERP_CREATE_DATE));
				TRS.add_string(list_item, "ERP_INV_IN_DATE", MTIVLOTHIS.ERP_INV_IN_DATE, sizeof(MTIVLOTHIS.ERP_INV_IN_DATE));
				TRS.add_string(list_item, "ERP_OINV_IN_DATE", MTIVLOTHIS.ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS.ERP_OINV_IN_DATE));
				TRS.add_string(list_item, "ERP_TRAN_DATE", MTIVLOTHIS.ERP_TRAN_DATE, sizeof(MTIVLOTHIS.ERP_TRAN_DATE));

				 
				if (memcmp(MTIVLOTHIS.MAT_ID, s_mat_id, sizeof(s_mat_id)) != 0)
				{
					DBC_init_mwipmatdef(&MWIPMATDEF);
					//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
					
					if (memcmp(MTIVLOTHIS.TRAN_CODE, MP_TRAN_CODE_SHIP, strlen(MP_TRAN_CODE_SHIP)) == 0 &&
						memcmp(MTIVLOTHIS.FACTORY, "CUSTOMER", strlen("CUSTOMER")) == 0)
					{
						TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
						//memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.OLD_FACTORY, sizeof(MWIPMATDEF.FACTORY));
					}
					else
					{
						memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
					}
					memcpy(MWIPMATDEF.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
					MWIPMATDEF.MAT_VER  = 1;
					i_step = 1;
					DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
					if(DB_error_code != DB_SUCCESS) 
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							strcpy(s_msg_code, "WIP-0006");
							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						}
						else 
						{
							strcpy(s_msg_code, "WIP-0004");
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							TRS.add_dberrmsg(out_node, DB_error_msg);
						}

						TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
 
						DBC_close_mtivlothis(i_his_step);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					memcpy(s_mat_id, MWIPMATDEF.MAT_ID, sizeof(s_mat_id));
					memcpy(s_mat_short_desc, MWIPMATDEF.MAT_SHORT_DESC, sizeof(s_mat_short_desc));
					memcpy(s_mat_desc, MWIPMATDEF.MAT_DESC, sizeof(s_mat_desc));					
				}
				TRS.add_string(list_item, "MAT_SHORT_DESC", s_mat_short_desc, sizeof(s_mat_short_desc));
				TRS.add_string(list_item, "MAT_DESC", s_mat_desc, sizeof(s_mat_desc));
				 
				if (COM_isnullspace(MTIVLOTHIS.OPER) == MP_FALSE &&
					memcmp(MTIVLOTHIS.OPER, s_oper_id, sizeof(s_oper_id)) != 0)
				{
					DBC_init_mtivoprdef(&MTIVOPRDEF);
					memcpy(MTIVOPRDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
					//TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
					memcpy(MTIVOPRDEF.OPER, MTIVLOTHIS.OPER, sizeof(MTIVOPRDEF.OPER));

					i_step = 1;
					DBC_select_mtivoprdef(i_step, &MTIVOPRDEF);
					if(DB_error_code != DB_SUCCESS) 
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							strcpy(s_msg_code, "WIP-0010");
							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						}
						else 
						{
							strcpy(s_msg_code, "WIP-0004");
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							TRS.add_dberrmsg(out_node, DB_error_msg);
						}
						TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
						TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

						DBC_close_mtivlothis(i_his_step);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					memcpy(s_oper_id, MTIVOPRDEF.OPER, sizeof(s_oper_id));
					memcpy(s_oper_desc, MTIVOPRDEF.OPER_DESC, sizeof(s_oper_desc));
				}
				TRS.add_string(list_item, "OPER_DESC", s_oper_desc, sizeof(s_oper_desc));

				if (COM_isnullspace(MTIVLOTHIS.OLD_OPER) == MP_FALSE && 
					memcmp(MTIVLOTHIS.OLD_OPER, s_oper_id, sizeof(s_oper_id)) != 0)
				{
					DBC_init_mtivoprdef(&MTIVOPRDEF);
					//TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
					memcpy(MTIVOPRDEF.FACTORY, MTIVLOTHIS.OLD_FACTORY, sizeof(MTIVOPRDEF.FACTORY));
					memcpy(MTIVOPRDEF.OPER, MTIVLOTHIS.OLD_OPER, sizeof(MTIVOPRDEF.OPER));
					i_step = 1;
					DBC_select_mtivoprdef(i_step, &MTIVOPRDEF);
					if(DB_error_code != DB_SUCCESS) 
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							strcpy(s_msg_code, "WIP-0010");
							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						}
						else 
						{
							strcpy(s_msg_code, "WIP-0004");
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							TRS.add_dberrmsg(out_node, DB_error_msg);
						}
						TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
						TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

						DBC_close_mtivlothis(i_his_step);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					memcpy(s_oper_id, MTIVOPRDEF.OPER, sizeof(s_oper_id));
					memcpy(s_oper_desc, MTIVOPRDEF.OPER_DESC, sizeof(s_oper_desc));
				}
				TRS.add_string(list_item, "OLD_OPER_DESC", s_oper_desc, sizeof(s_oper_desc));

				TRS.set_string(list_item, "RES_ID", " ", strlen(" "));
				TRS.set_string(list_item, "RES_SHORT_DESC", " ", strlen(" "));
				TRS.set_string(list_item, "RES_DESC", " ", strlen(" "));

				if (COM_isnullspace(MTIVLOTHIS.INV_CMF_15) == MP_FALSE)
				{
					if (memcmp(MTIVLOTHIS.INV_CMF_15, s_res_id, sizeof(s_res_id)) != 0)
					{
						DBC_init_mrasresdef(&MRASRESDEF);
						memcpy(MRASRESDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MRASRESDEF.FACTORY));
						//TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
						memcpy(MRASRESDEF.RES_ID, MTIVLOTHIS.INV_CMF_15, sizeof(MRASRESDEF.RES_ID));

						i_step = 1;
						DBC_select_mrasresdef(i_step, &MRASRESDEF);
						if(DB_error_code != DB_SUCCESS) 
						{
							if(DB_error_code == DB_NOT_FOUND)
							{
							}
							else 
							{
								strcpy(s_msg_code, "RAS-0004");
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								TRS.add_dberrmsg(out_node, DB_error_msg);

								TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
								TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
 
								DBC_close_mtivlothis(i_his_step);

								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.category = MP_LOG_CATE_VIEW;
								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
								return MP_FALSE;
							}								
						}

						memcpy(s_res_id, MRASRESDEF.RES_ID, sizeof(s_res_id));
						memcpy(s_res_short_desc, MRASRESDEF.RES_SHORT_DESC, sizeof(s_res_short_desc));
						memcpy(s_res_desc, MRASRESDEF.RES_DESC, sizeof(s_res_desc));
					}					
				}
				
				TRS.set_string(list_item, "RES_ID", s_res_id, sizeof(s_res_id));
				TRS.set_string(list_item, "RES_SHORT_DESC", s_res_short_desc, sizeof(s_res_short_desc));
				TRS.set_string(list_item, "RES_DESC", s_res_desc, sizeof(s_res_desc));	
		 
				if (COM_isnullspace(MTIVLOTHIS.INV_CMF_22) == MP_FALSE)
				{
					if (memcmp(MTIVLOTHIS.INV_CMF_22, s_wip_oper_id, sizeof(s_wip_oper_id)) != 0)
					{
						DBC_init_mwipoprdef(&MWIPOPRDEF);
						memcpy(MWIPOPRDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPOPRDEF.FACTORY));
						memcpy(MWIPOPRDEF.OPER, MTIVLOTHIS.INV_CMF_22, sizeof(MWIPOPRDEF.OPER));
						DBC_select_mwipoprdef(1, &MWIPOPRDEF);
						if(DB_error_code != DB_SUCCESS) 
						{
							if(DB_error_code == DB_NOT_FOUND) 
							{								
							}
							else 
							{
								strcpy(s_msg_code, "WIP-0004");
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								TRS.add_dberrmsg(out_node, DB_error_msg);
								
								DBC_close_mtivlothis(i_his_step);

								TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
								TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

								gs_log_type.type = MP_LOG_ERROR;    
								gs_log_type.category = MP_LOG_CATE_VIEW;
								return MP_FALSE;
							}     
						}
					}	
					memcpy(s_wip_oper_id, MWIPOPRDEF.OPER, sizeof(s_wip_oper_id));
					memcpy(s_wip_oper_desc, MWIPOPRDEF.OPER_DESC, sizeof(s_wip_oper_desc));

				}
				TRS.set_string(list_item, "WIP_OPER", s_wip_oper_id, sizeof(s_wip_oper_id));
				TRS.set_string(list_item, "WIP_OPER_DESC", s_wip_oper_desc, sizeof(s_wip_oper_desc));

				 
				if (memcmp(MTIVLOTHIS.TRAN_CODE, MP_TIV_TRAN_CODE_CONSUME, sizeof(MTIVLOTHIS.TRAN_CODE)) == 0 &&
					COM_isnullspace(MTIVLOTHIS.PROD_LOT_ID) == MP_FALSE)
				{
					DBC_init_mwiplotsts(&MWIPLOTSTS);  
					memcpy(MWIPLOTSTS.LOT_ID, MTIVLOTHIS.PROD_LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					
					i_step = 1;
					DBC_select_mwiplotsts(i_step, &MWIPLOTSTS);
					if(DB_error_code != DB_SUCCESS) 
					{
						if (DB_error_code == DB_NOT_FOUND)
						{
							DBC_init_mtivlotsts(&MTIVLOTSTS);
							TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
							memcpy(MTIVLOTSTS.LOT_ID, MTIVLOTHIS.PROD_LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		 
							i_step = 6;
							DBC_select_mtivlotsts(i_step, &MTIVLOTSTS);
							if(DB_error_code != DB_SUCCESS)
							{
								if(DB_error_code == DB_NOT_FOUND)
								{
									strcpy(s_msg_code, "INV-0022");             
									gs_log_type.e_type = MP_LOG_E_EXISTENCE;
								}
								else 
								{
									strcpy(s_msg_code, "INV-0004");            
									gs_log_type.e_type = MP_LOG_E_SYSTEM;
								}

								TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
								TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
								TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
								TRS.add_dberrmsg(out_node, DB_error_msg);

								DBC_close_mtivlothis(i_his_step);

								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.category = MP_LOG_CATE_TRANS;

								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
								return MP_FALSE;
							}
							c_wip_or_inv = 'I';
						}
						else
						{
							strcpy(s_msg_code, "WIP-0004");
							TRS.add_dberrmsg(out_node, DB_error_msg);
							TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_SETUP;

							DBC_close_mtivlothis(i_his_step);

							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}										
					}
					else
					{
						c_wip_or_inv = 'W';											 
					}

					if (c_wip_or_inv == 'W')
					{
						TRS.set_string(list_item, "WIP_MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
						TRS.set_int(list_item, "WIP_MAT_VER", MWIPLOTSTS.MAT_VER);
						TRS.set_double(list_item, "WIP_QTY_1", MWIPLOTSTS.QTY_1);
						TRS.set_string(list_item, "WIP_ORDER_NO", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
						TRS.set_string(list_item, "WIP_OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

						if (COM_isnullspace(MWIPLOTSTS.END_RES_ID) == MP_FALSE)
							TRS.set_string(list_item, "RES_ID", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));
						else
							TRS.set_string(list_item, "RES_ID", MTIVLOTHIS.INV_CMF_15, sizeof(MTIVLOTHIS.INV_CMF_15));

						DBC_init_mwipmatdef(&MWIPMATDEF);
						memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
						//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
						memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
						MWIPMATDEF.MAT_VER  = 1;
						i_step = 1;
						DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
						if(DB_error_code != DB_SUCCESS) 
						{
							if(DB_error_code == DB_NOT_FOUND)
							{
								strcpy(s_msg_code, "WIP-0006");
								gs_log_type.e_type = MP_LOG_E_EXISTENCE;
							}
							else 
							{
								strcpy(s_msg_code, "WIP-0004");
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								TRS.add_dberrmsg(out_node, DB_error_msg);
							}

							TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
							TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
							TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
  
							DBC_close_mtivlothis(i_his_step);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
						TRS.set_string(list_item, "WIP_MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
						TRS.set_string(list_item, "WIP_MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));

						DBC_init_mwipoprdef(&MWIPOPRDEF);
						memcpy(MWIPOPRDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPOPRDEF.FACTORY));
						//TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
						memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPOPRDEF.OPER));
						DBC_select_mwipoprdef(1, &MWIPOPRDEF);
						if(DB_error_code != DB_SUCCESS) 
						{
							if(DB_error_code == DB_NOT_FOUND) 
							{
								strcpy(s_msg_code, "WIP-0010");
								gs_log_type.e_type = MP_LOG_E_EXISTENCE;
							}
							else 
							{
								strcpy(s_msg_code, "WIP-0004");
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								TRS.add_dberrmsg(out_node, DB_error_msg);
							}     

							DBC_close_mtivlothis(i_his_step);

							TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
							TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

							gs_log_type.type = MP_LOG_ERROR;    
							gs_log_type.category = MP_LOG_CATE_VIEW;
							return MP_FALSE;
						}
						TRS.set_string(list_item, "WIP_OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));

						if (memcmp(MWIPLOTSTS.END_RES_ID, s_res_id, sizeof(s_res_id)) != 0)
						{
							DBC_init_mrasresdef(&MRASRESDEF);
							memcpy(MRASRESDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MRASRESDEF.FACTORY));
							//TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
							memcpy(MRASRESDEF.RES_ID, MWIPLOTSTS.END_RES_ID, sizeof(MRASRESDEF.RES_ID));

							i_step = 1;
							DBC_select_mrasresdef(i_step, &MRASRESDEF);
							if(DB_error_code != DB_SUCCESS) 
							{
								if(DB_error_code == DB_NOT_FOUND)
								{
								}
								else 
								{
									strcpy(s_msg_code, "RAS-0004");
									gs_log_type.e_type = MP_LOG_E_SYSTEM;
									TRS.add_dberrmsg(out_node, DB_error_msg);

									TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
									TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
									TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
 
									DBC_close_mtivlothis(i_his_step);

									gs_log_type.type = MP_LOG_ERROR;
									gs_log_type.category = MP_LOG_CATE_VIEW;
									COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
									return MP_FALSE;
								}								
							}

							memcpy(s_res_id, MRASRESDEF.RES_ID, sizeof(s_res_id));
							memcpy(s_res_short_desc, MRASRESDEF.RES_SHORT_DESC, sizeof(s_res_short_desc));
							memcpy(s_res_desc, MRASRESDEF.RES_DESC, sizeof(s_res_desc));

						}
						else if (memcmp(MTIVLOTHIS.INV_CMF_15, s_res_id, sizeof(s_res_id)) != 0)
						{
							DBC_init_mrasresdef(&MRASRESDEF);
							memcpy(MRASRESDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MRASRESDEF.FACTORY));
							//TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
							memcpy(MRASRESDEF.RES_ID, MTIVLOTHIS.INV_CMF_15, sizeof(MRASRESDEF.RES_ID));

							i_step = 1;
							DBC_select_mrasresdef(i_step, &MRASRESDEF);
							if(DB_error_code != DB_SUCCESS) 
							{
								if(DB_error_code == DB_NOT_FOUND)
								{
								}
								else 
								{
									strcpy(s_msg_code, "RAS-0004");
									gs_log_type.e_type = MP_LOG_E_SYSTEM;
									TRS.add_dberrmsg(out_node, DB_error_msg);

									TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
									TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
									TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
 
									DBC_close_mtivlothis(i_his_step);

									gs_log_type.type = MP_LOG_ERROR;
									gs_log_type.category = MP_LOG_CATE_VIEW;
									COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
									return MP_FALSE;
								}								
							}

							memcpy(s_res_id, MRASRESDEF.RES_ID, sizeof(s_res_id));
							memcpy(s_res_short_desc, MRASRESDEF.RES_SHORT_DESC, sizeof(s_res_short_desc));
							memcpy(s_res_desc, MRASRESDEF.RES_DESC, sizeof(s_res_desc));
						}
						TRS.set_string(list_item, "RES_SHORT_DESC", s_res_short_desc, sizeof(s_res_short_desc));
						TRS.set_string(list_item, "RES_DESC", s_res_desc, sizeof(s_res_desc));	
					}
					else
					{	
						TRS.set_string(list_item, "WIP_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
						TRS.set_int(list_item, "WIP_MAT_VER", MTIVLOTSTS.MAT_VER);
						TRS.set_double(list_item, "WIP_QTY_1", MTIVLOTSTS.QTY_1);

						memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
						//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
						memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
						MWIPMATDEF.MAT_VER  = 1;
						i_step = 1;
						DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
						if(DB_error_code != DB_SUCCESS) 
						{
							if(DB_error_code == DB_NOT_FOUND)
							{
								strcpy(s_msg_code, "WIP-0006");
								gs_log_type.e_type = MP_LOG_E_EXISTENCE;
							}
							else 
							{
								strcpy(s_msg_code, "WIP-0004");
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								TRS.add_dberrmsg(out_node, DB_error_msg);
							}

							TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
							TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
							TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
 							
							DBC_close_mtivlothis(i_his_step);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
						TRS.set_string(list_item, "WIP_MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
						TRS.set_string(list_item, "WIP_MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));

						//DBC_init_cwipwrkdat(&CWIPWRKDAT);
						//memcpy(CWIPWRKDAT.FACTORY, MTIVLOTHIS.FACTORY, sizeof(CWIPWRKDAT.FACTORY));
						//memcpy(CWIPWRKDAT.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(CWIPWRKDAT.LOT_ID)); 

						//i_step = 3;
						//DBC_select_cwipwrkdat(i_step, &CWIPWRKDAT);
						//if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
						//{ 
						//	strcpy(s_msg_code, "WIP-0004");
						//	TRS.add_dberrmsg(out_node, DB_error_msg);

						//	TRS.add_fieldmsg(out_node, "CWIPWRKDAT SELECT", MP_NVST);
						//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAT.FACTORY), CWIPWRKDAT.FACTORY);
						//	TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPWRKDAT.ORDER_ID), CWIPWRKDAT.ORDER_ID);
			
						//	DBC_close_mtivlothis(i_his_step);

						//	gs_log_type.type = MP_LOG_ERROR;
						//	gs_log_type.category = MP_LOG_CATE_VIEW;
						//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						//	return MP_FALSE;	
						//}
						//else if (DB_error_code == DB_SUCCESS)
						//{
						//	/*DBC_init_cwiporddef(&CWIPORDDEF);
						//	memcpy(CWIPORDDEF.FACTORY, CWIPWRKDAT.FACTORY, sizeof(CWIPORDDEF.FACTORY));
						//	memcpy(CWIPORDDEF.ORDER_ID, CWIPWRKDAT.ORDER_ID, sizeof(CWIPORDDEF.ORDER_ID)); 
						//	 
						//	i_step = 1;
						//	DBC_select_cwiporddef(i_step, &CWIPORDDEF);
						//	if(DB_error_code != DB_SUCCESS) 
						//	{
						//		if(DB_error_code == DB_NOT_FOUND)
						//		{
						//			strcpy(s_msg_code, "ORD-0002");
						//			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						//		}
						//		else 
						//		{
						//			strcpy(s_msg_code, "WIP-0004");
						//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
						//			TRS.add_dberrmsg(out_node, DB_error_msg);
						//		}

						//		DBC_close_mtivlothis(i_his_step);

						//		TRS.add_fieldmsg(out_node, "CWIPORDDEF SELECT", MP_NVST);
						//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDDEF.FACTORY), CWIPORDDEF.FACTORY);
						//		TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDDEF.ORDER_ID), CWIPORDDEF.ORDER_ID);

						//		gs_log_type.type = MP_LOG_ERROR;
						//		gs_log_type.category = MP_LOG_CATE_VIEW;
						//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						//		return MP_FALSE;
						//	}*/
						//	 
						//	TRS.set_string(list_item, "WIP_ORDER_NO", CWIPWRKDAT.ORDER_ID, sizeof(CWIPWRKDAT.ORDER_ID));
						//	TRS.set_string(list_item, "WIP_OPER", CWIPWRKDAT.OPER, sizeof(CWIPWRKDAT.OPER));
						//	TRS.set_string(list_item, "RES_ID", CWIPWRKDAT.RES_ID, sizeof(CWIPWRKDAT.RES_ID));
						//	 
						//	DBC_init_mwipoprdef(&MWIPOPRDEF);
						//	memcpy(MWIPOPRDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPOPRDEF.FACTORY));
						//	//TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
						//	memcpy(MWIPOPRDEF.OPER, CWIPWRKDAT.OPER, sizeof(MWIPOPRDEF.OPER));
						//	DBC_select_mwipoprdef(1, &MWIPOPRDEF);
						//	if(DB_error_code != DB_SUCCESS) 
						//	{
						//		if(DB_error_code == DB_NOT_FOUND) 
						//		{
						//			strcpy(s_msg_code, "WIP-0010");
						//			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						//		}
						//		else 
						//		{
						//			strcpy(s_msg_code, "WIP-0004");
						//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
						//			TRS.add_dberrmsg(out_node, DB_error_msg);
						//		}     

						//		DBC_close_mtivlothis(i_his_step);

						//		TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
						//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
						//		TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

						//		gs_log_type.type = MP_LOG_ERROR;    
						//		gs_log_type.category = MP_LOG_CATE_VIEW;
						//		return MP_FALSE;
						//	}
						//	TRS.set_string(list_item, "WIP_OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));

						//	if (memcmp(CWIPWRKDAT.RES_ID, s_res_id, sizeof(s_res_id)) != 0)
						//	{
						//		DBC_init_mrasresdef(&MRASRESDEF);
						//		memcpy(MRASRESDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MRASRESDEF.FACTORY));
						//		//TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
						//		memcpy(MRASRESDEF.RES_ID, CWIPWRKDAT.RES_ID, sizeof(MRASRESDEF.RES_ID));

						//		i_step = 1;
						//		DBC_select_mrasresdef(i_step, &MRASRESDEF);
						//		if(DB_error_code != DB_SUCCESS) 
						//		{
						//			if(DB_error_code == DB_NOT_FOUND)
						//			{
						//			}
						//			else 
						//			{
						//				strcpy(s_msg_code, "RAS-0004");
						//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
						//				TRS.add_dberrmsg(out_node, DB_error_msg);

						//				TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
						//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
						//				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
 
						//				DBC_close_mtivlothis(i_his_step);

						//				gs_log_type.type = MP_LOG_ERROR;
						//				gs_log_type.category = MP_LOG_CATE_VIEW;
						//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						//				return MP_FALSE;
						//			}								
						//		}

						//		memcpy(s_res_id, MRASRESDEF.RES_ID, sizeof(s_res_id));
						//		memcpy(s_res_short_desc, MRASRESDEF.RES_SHORT_DESC, sizeof(s_res_short_desc));
						//		memcpy(s_res_desc, MRASRESDEF.RES_DESC, sizeof(s_res_desc));

						//	}
						//	TRS.set_string(list_item, "RES_SHORT_DESC", s_res_short_desc, sizeof(s_res_short_desc));
						//	TRS.set_string(list_item, "RES_DESC", s_res_desc, sizeof(s_res_desc));	
						//}						
					}
				}

//				c_wip_or_inv = ' ';
//				if (memcmp(MTIVLOTHIS.TRAN_CODE, MP_TIV_TRAN_CODE_IN, sizeof(MTIVLOTHIS.TRAN_CODE)) == 0)
//				{
//					//COM_isnullspace(MTIVLOTHIS.INV_CMF_10) == MP_FALSE
//					DBC_init_mwiplotsts(&MWIPLOTSTS);  
//					memcpy(MWIPLOTSTS.LOT_ID, MTIVLOTHIS.INV_CMF_10, sizeof(MWIPLOTSTS.LOT_ID));
//			 
//					i_step = 1;
//					DBC_select_mwiplotsts(i_step, &MWIPLOTSTS);
//					if(DB_error_code != DB_SUCCESS) 
//					{
//						if (DB_error_code == DB_NOT_FOUND)
//						{
//							 c_wip_or_inv = ' ';
//						}
//						else
//						{
//							strcpy(s_msg_code, "WIP-0004");
//							TRS.add_dberrmsg(out_node, DB_error_msg);
//							TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
//							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
//							gs_log_type.type = MP_LOG_ERROR;
//							gs_log_type.e_type = MP_LOG_E_SYSTEM;
//							gs_log_type.category = MP_LOG_CATE_SETUP;
//
//							DBC_close_mtivlothis(i_his_step);
//
//							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//							return MP_FALSE;
//						}										
//					}
//					else
//					{
//						c_wip_or_inv = 'W';
//					}
//
//					if (c_wip_or_inv == 'W')
//					{
//						TRS.set_string(list_item, "WIP_MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
//						TRS.set_int(list_item, "WIP_MAT_VER", MWIPLOTSTS.MAT_VER);
//						TRS.set_double(list_item, "WIP_QTY_1", MWIPLOTSTS.QTY_1);
//						TRS.set_string(list_item, "WIP_ORDER_NO", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
//						TRS.set_string(list_item, "WIP_OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
//						//TRS.set_string(list_item, "RES_ID", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));
//
//						if (COM_isnullspace(MWIPLOTSTS.END_RES_ID) == MP_FALSE)
//							TRS.set_string(list_item, "RES_ID", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));
//						else
//							TRS.set_string(list_item, "RES_ID", MTIVLOTHIS.INV_CMF_15, sizeof(MTIVLOTHIS.INV_CMF_15));
//
//						DBC_init_mwipmatdef(&MWIPMATDEF);
//
//						memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
//						//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
//						memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
//						MWIPMATDEF.MAT_VER  = 1;
//						i_step = 1;
//						DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
//						if(DB_error_code != DB_SUCCESS) 
//						{
//							if(DB_error_code == DB_NOT_FOUND)
//							{
//								strcpy(s_msg_code, "WIP-0006");
//								gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//							}
//							else 
//							{
//								strcpy(s_msg_code, "WIP-0004");
//								gs_log_type.e_type = MP_LOG_E_SYSTEM;
//								TRS.add_dberrmsg(out_node, DB_error_msg);
//							}
//
//							TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
//							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
//							TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
//							TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
// /*
//							DBC_close_mtivmatuse(i_sub_step);*/
//							DBC_close_mtivlothis(i_his_step);
//
//							gs_log_type.type = MP_LOG_ERROR;
//							gs_log_type.category = MP_LOG_CATE_VIEW;
//							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//							return MP_FALSE;
//						}
//						TRS.set_string(list_item, "WIP_MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
//						TRS.set_string(list_item, "WIP_MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
//
//						DBC_init_mwipoprdef(&MWIPOPRDEF);
//						memcpy(MWIPOPRDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPOPRDEF.FACTORY));
//						//TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
//						memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPOPRDEF.OPER));
//						DBC_select_mwipoprdef(1, &MWIPOPRDEF);
//						if(DB_error_code != DB_SUCCESS) 
//						{
//							if(DB_error_code == DB_NOT_FOUND) 
//							{
//								strcpy(s_msg_code, "WIP-0010");
//								gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//							}
//							else 
//							{
//								strcpy(s_msg_code, "WIP-0004");
//								gs_log_type.e_type = MP_LOG_E_SYSTEM;
//								TRS.add_dberrmsg(out_node, DB_error_msg);
//							}     
//
//							DBC_close_mtivlothis(i_his_step);
//
//							TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
//							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
//							TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
//
//							gs_log_type.type = MP_LOG_ERROR;    
//							gs_log_type.category = MP_LOG_CATE_VIEW;
//							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//							return MP_FALSE;
//						}
//						TRS.set_string(list_item, "WIP_OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
//
//						if (memcmp(MWIPLOTSTS.END_RES_ID, s_res_id, sizeof(s_res_id)) != 0)
//						{
//							DBC_init_mrasresdef(&MRASRESDEF);
//
//							memcpy(MRASRESDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MRASRESDEF.FACTORY));
//							//TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
//							memcpy(MRASRESDEF.RES_ID, MWIPLOTSTS.END_RES_ID, sizeof(MRASRESDEF.RES_ID));
//
//							i_step = 1;
//							DBC_select_mrasresdef(i_step, &MRASRESDEF);
//							if(DB_error_code != DB_SUCCESS) 
//							{
//								if(DB_error_code == DB_NOT_FOUND)
//								{
//								}
//								else 
//								{
//									strcpy(s_msg_code, "RAS-0004");
//									gs_log_type.e_type = MP_LOG_E_SYSTEM;
//									TRS.add_dberrmsg(out_node, DB_error_msg);
//
//									TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
//									TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
//									TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
// 
//									DBC_close_mtivlothis(i_his_step);
//
//									gs_log_type.type = MP_LOG_ERROR;
//									gs_log_type.category = MP_LOG_CATE_VIEW;
//									COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//									return MP_FALSE;
//								}								
//							}
//
//							memcpy(s_res_id, MRASRESDEF.RES_ID, sizeof(s_res_id));
//							memcpy(s_res_short_desc, MRASRESDEF.RES_SHORT_DESC, sizeof(s_res_short_desc));
//							memcpy(s_res_desc, MRASRESDEF.RES_DESC, sizeof(s_res_desc));
//
//						}
//						else if (memcmp(MTIVLOTHIS.INV_CMF_15, s_res_id, sizeof(s_res_id)) != 0)
//						{
//							DBC_init_mrasresdef(&MRASRESDEF);
//							memcpy(MRASRESDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MRASRESDEF.FACTORY));
//							//TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
//							memcpy(MRASRESDEF.RES_ID, MTIVLOTHIS.INV_CMF_15, sizeof(MRASRESDEF.RES_ID));
//
//							i_step = 1;
//							DBC_select_mrasresdef(i_step, &MRASRESDEF);
//							if(DB_error_code != DB_SUCCESS) 
//							{
//								if(DB_error_code == DB_NOT_FOUND)
//								{
//								}
//								else 
//								{
//									strcpy(s_msg_code, "RAS-0004");
//									gs_log_type.e_type = MP_LOG_E_SYSTEM;
//									TRS.add_dberrmsg(out_node, DB_error_msg);
//
//									TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
//									TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
//									TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
// 
//									DBC_close_mtivlothis(i_his_step);
//
//									gs_log_type.type = MP_LOG_ERROR;
//									gs_log_type.category = MP_LOG_CATE_VIEW;
//									COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//									return MP_FALSE;
//								}								
//							}
//
//							memcpy(s_res_id, MRASRESDEF.RES_ID, sizeof(s_res_id));
//							memcpy(s_res_short_desc, MRASRESDEF.RES_SHORT_DESC, sizeof(s_res_short_desc));
//							memcpy(s_res_desc, MRASRESDEF.RES_DESC, sizeof(s_res_desc));
//						}
//
//						TRS.set_string(list_item, "RES_SHORT_DESC", s_res_short_desc, sizeof(s_res_short_desc));
//						TRS.set_string(list_item, "RES_DESC", s_res_desc, sizeof(s_res_desc));
//
//						//DBC_init_mtivmatuse(&MTIVMATUSE);
//
//						//memcpy(MTIVMATUSE.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVMATUSE.FACTORY));
//						////memcpy(MTIVMATUSE.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MTIVMATUSE.FACTORY));
//						//memcpy(MTIVMATUSE.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MTIVMATUSE.LOT_ID));
//						//MTIVMATUSE.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
//						//MTIVMATUSE.HIST_DEL_FLAG = ' ';
//						//i_sub_step = 2;
//
//						//DBC_open_mtivmatuse(i_sub_step, &MTIVMATUSE);
//						//if(DB_error_code != DB_SUCCESS)
//						//{
//						//	strcpy(s_msg_code, "WIP-0004");
//						//	TRS.add_fieldmsg(out_node, "MTIVMATUSE OPEN", MP_NVST);
//						//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
//						//	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
//						//	TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVMATUSE.HIST_SEQ);
//						//	TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR,  sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);
//
//						//	TRS.add_dberrmsg(out_node, DB_error_msg);
//						//	
//						//	DBC_close_mtivlothis(i_his_step);
//
//						//	gs_log_type.type = MP_LOG_ERROR;
//						//	gs_log_type.e_type = MP_LOG_E_SYSTEM;
//						//	gs_log_type.category = MP_LOG_CATE_VIEW;
//						//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//						//	return MP_FALSE;
//						//}
//
//						//while(1)
//						//{
//						//	DBC_fetch_mtivmatuse(i_sub_step, &MTIVMATUSE);
//						//	if(DB_error_code == DB_NOT_FOUND)
//						//	{
//						//		DBC_close_mtivmatuse(i_sub_step);
//						//		break;
//						//	}
//						//	else if(DB_error_code != DB_SUCCESS) 
//						//	{
//						//		strcpy(s_msg_code, "WIP-0004");
//						//		TRS.add_fieldmsg(out_node, "MTIVMATUSE FETCH", MP_NVST);
//						//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
//						//		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
//						//		TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVMATUSE.HIST_SEQ);
//						//		TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR,  sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);
//
//						//		TRS.add_dberrmsg(out_node, DB_error_msg);
//
//						//		DBC_close_mtivmatuse(i_sub_step);
//						//		DBC_close_mtivlothis(i_his_step);
//
//						//		gs_log_type.type = MP_LOG_ERROR;
//						//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
//						//		gs_log_type.category = MP_LOG_CATE_VIEW;
//						//		DBC_close_mtivmatuse(i_sub_step);
//
//						//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//						//		return MP_FALSE;
//						//	}
//
//						//	if(COM_check_node_length(out_node) == MP_FALSE)
//						//	{
//						//		/* Add Next Value Here */
//						//		DBC_close_mtivmatuse(i_sub_step);
//						//		break;
//						//	}
//
//						//	sub_item = TRS.add_node(list_item, "USE_LIST");
//						//	
//						//	TRS.add_char(sub_item, "WIP_OR_INV", MTIVMATUSE.WIP_OR_INV);
//						//	TRS.add_string(sub_item, "INPUT_LOT_ID", MTIVMATUSE.INPUT_LOT_ID, sizeof(MTIVMATUSE.INPUT_LOT_ID));
//						//	TRS.add_int(sub_item, "INPUT_HIST_SEQ", MTIVMATUSE.INPUT_HIST_SEQ);							
//						//	TRS.add_string(sub_item, "OPER", MTIVMATUSE.OPER, sizeof(MTIVMATUSE.OPER));						
//						//	TRS.add_char(sub_item, "INPUT_TYPE", MTIVMATUSE.INPUT_TYPE);
//						//	TRS.add_string(sub_item, "INPUT_MAT_ID", MTIVMATUSE.INPUT_MAT_ID, sizeof(MTIVMATUSE.INPUT_MAT_ID));
//						//	TRS.add_int(sub_item, "INPUT_MAT_VER", MTIVMATUSE.INPUT_MAT_VER);
//						//	TRS.add_string(sub_item, "INPUT_MAT_TYPE", MTIVMATUSE.INPUT_MAT_TYPE, sizeof(MTIVMATUSE.INPUT_MAT_TYPE));							
//						//	TRS.add_string(sub_item, "INPUT_OPER", MTIVMATUSE.INPUT_OPER, sizeof(MTIVMATUSE.INPUT_OPER));
//						//	TRS.add_double(sub_item, "INPUT_QTY_1", MTIVMATUSE.INPUT_QTY_1);
//						//	TRS.add_double(sub_item, "INPUT_QTY_2", MTIVMATUSE.INPUT_QTY_2);
//						//	TRS.add_double(sub_item, "INPUT_QTY_3", MTIVMATUSE.INPUT_QTY_3);
//
//						//	DBC_init_mwipmatdef(&MWIPMATDEF);
//
//						//	memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
//						//	//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
//						//	memcpy(MWIPMATDEF.MAT_ID, MTIVMATUSE.INPUT_MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
//						//	MWIPMATDEF.MAT_VER  = 1;
//						//	i_step = 1;
//						//	DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
//						//	if(DB_error_code != DB_SUCCESS) 
//						//	{
//						//		if(DB_error_code == DB_NOT_FOUND)
//						//		{
//						//			strcpy(s_msg_code, "WIP-0006");
//						//			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//						//		}
//						//		else 
//						//		{
//						//			strcpy(s_msg_code, "WIP-0004");
//						//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//						//			TRS.add_dberrmsg(out_node, DB_error_msg);
//						//		}
//
//						//		TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
//						//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
//						//		TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
//						//		TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
// 
//						//		DBC_close_mtivmatuse(i_sub_step);
//						//		DBC_close_mtivlothis(i_his_step);
//
//						//		gs_log_type.type = MP_LOG_ERROR;
//						//		gs_log_type.category = MP_LOG_CATE_VIEW;
//						//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//						//		return MP_FALSE;
//						//	}
//						//	TRS.set_string(sub_item, "INPUT_MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
//						//	TRS.set_string(sub_item, "INPUT_MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
//						// 
//							
//						//}
//					}
//					else
//					{
//						DBC_init_cwipwrkdat(&CWIPWRKDAT);
//						memcpy(CWIPWRKDAT.FACTORY, MTIVLOTHIS.FACTORY, sizeof(CWIPWRKDAT.FACTORY));
//						memcpy(CWIPWRKDAT.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(CWIPWRKDAT.LOT_ID)); 
//
//						i_step = 3;
//						DBC_select_cwipwrkdat(i_step, &CWIPWRKDAT);
//						if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
//						{ 
//							strcpy(s_msg_code, "WIP-0004");
//							TRS.add_dberrmsg(out_node, DB_error_msg);
//
//							TRS.add_fieldmsg(out_node, "CWIPWRKDAT SELECT", MP_NVST);
//							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPWRKDAT.FACTORY), CWIPWRKDAT.FACTORY);
//							TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPWRKDAT.ORDER_ID), CWIPWRKDAT.ORDER_ID);
//			 
//							DBC_close_mtivlothis(i_his_step);
//
//							gs_log_type.type = MP_LOG_ERROR;
//							gs_log_type.category = MP_LOG_CATE_VIEW;
//							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//							return MP_FALSE;	
//						}
//						else if (DB_error_code == DB_SUCCESS)
//						{
//							/*DBC_init_cwiporddef(&CWIPORDDEF);
//							memcpy(CWIPORDDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(CWIPORDDEF.FACTORY));
//							memcpy(CWIPORDDEF.ORDER_ID, CWIPWRKDAT.ORDER_ID, sizeof(CWIPORDDEF.ORDER_ID)); 
//							 
//							i_step = 1;
//							DBC_select_cwiporddef(i_step, &CWIPORDDEF);
//							if(DB_error_code != DB_SUCCESS) 
//							{
//								if(DB_error_code == DB_NOT_FOUND)
//								{
//									strcpy(s_msg_code, "ORD-0002");
//									gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//								}
//								else 
//								{
//									strcpy(s_msg_code, "WIP-0004");
//									gs_log_type.e_type = MP_LOG_E_SYSTEM;
//									TRS.add_dberrmsg(out_node, DB_error_msg);
//								}
//;
//								DBC_close_mtivlothis(i_his_step);
//
//								TRS.add_fieldmsg(out_node, "CWIPORDDEF SELECT", MP_NVST);
//								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDDEF.FACTORY), CWIPORDDEF.FACTORY);
//								TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDDEF.ORDER_ID), CWIPORDDEF.ORDER_ID);
//
//								gs_log_type.type = MP_LOG_ERROR;
//								gs_log_type.category = MP_LOG_CATE_VIEW;
//								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//								return MP_FALSE;
//							}*/
//
//							TRS.set_string(list_item, "WIP_MAT_ID", CWIPWRKDAT.MAT_ID, sizeof(CWIPWRKDAT.MAT_ID));
//							TRS.set_int(list_item, "WIP_MAT_VER", CWIPWRKDAT.MAT_VER);
//							//TRS.set_double(list_item, "WIP_QTY_1", MWIPLOTSTS.QTY_1);
//							TRS.set_string(list_item, "WIP_ORDER_NO", CWIPWRKDAT.ORDER_ID, sizeof(CWIPWRKDAT.ORDER_ID));
//							TRS.set_string(list_item, "WIP_OPER", CWIPWRKDAT.OPER, sizeof(CWIPWRKDAT.OPER));
//							TRS.set_string(list_item, "RES_ID", CWIPWRKDAT.RES_ID, sizeof(CWIPWRKDAT.RES_ID));
//
//							DBC_init_mwipmatdef(&MWIPMATDEF);
//
//							memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
//							//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
//							memcpy(MWIPMATDEF.MAT_ID, CWIPWRKDAT.MAT_ID, sizeof(CWIPWRKDAT.MAT_ID));
//							MWIPMATDEF.MAT_VER  = 1;
//							i_step = 1;
//							DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
//							if(DB_error_code != DB_SUCCESS) 
//							{
//								if(DB_error_code == DB_NOT_FOUND)
//								{
//									strcpy(s_msg_code, "WIP-0006");
//									gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//								}
//								else 
//								{
//									strcpy(s_msg_code, "WIP-0004");
//									gs_log_type.e_type = MP_LOG_E_SYSTEM;
//									TRS.add_dberrmsg(out_node, DB_error_msg);
//								}
//
//								TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
//								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
//								TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
//								TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
// 
//								DBC_close_mtivlothis(i_his_step);
//
//								gs_log_type.type = MP_LOG_ERROR;
//								gs_log_type.category = MP_LOG_CATE_VIEW;
//								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//								return MP_FALSE;
//							}
//							TRS.set_string(list_item, "WIP_MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
//							TRS.set_string(list_item, "WIP_MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
//
//							DBC_init_mwipoprdef(&MWIPOPRDEF);
//							memcpy(MWIPOPRDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPOPRDEF.FACTORY));
//							//TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
//							memcpy(MWIPOPRDEF.OPER, CWIPWRKDAT.OPER, sizeof(MWIPOPRDEF.OPER));
//							DBC_select_mwipoprdef(1, &MWIPOPRDEF);
//							if(DB_error_code != DB_SUCCESS) 
//							{
//								if(DB_error_code == DB_NOT_FOUND) 
//								{
//									strcpy(s_msg_code, "WIP-0010");
//									gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//								}
//								else 
//								{
//									strcpy(s_msg_code, "WIP-0004");
//									gs_log_type.e_type = MP_LOG_E_SYSTEM;
//									TRS.add_dberrmsg(out_node, DB_error_msg);
//								}     
//
//								DBC_close_mtivlothis(i_his_step);
//
//								TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
//								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
//								TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
//
//								gs_log_type.type = MP_LOG_ERROR;    
//								gs_log_type.category = MP_LOG_CATE_VIEW;
//								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//								return MP_FALSE;
//							}
//							TRS.set_string(list_item, "WIP_OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
//
//							if (memcmp(CWIPWRKDAT.RES_ID, s_res_id, sizeof(s_res_id)) != 0)
//							{
//								DBC_init_mrasresdef(&MRASRESDEF);
//
//								memcpy(MRASRESDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MRASRESDEF.FACTORY));
//								//TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
//								memcpy(MRASRESDEF.RES_ID, CWIPWRKDAT.RES_ID, sizeof(MRASRESDEF.RES_ID));
//
//								i_step = 1;
//								DBC_select_mrasresdef(i_step, &MRASRESDEF);
//								if(DB_error_code != DB_SUCCESS) 
//								{
//									if(DB_error_code == DB_NOT_FOUND)
//									{
//									}
//									else 
//									{
//										strcpy(s_msg_code, "RAS-0004");
//										gs_log_type.e_type = MP_LOG_E_SYSTEM;
//										TRS.add_dberrmsg(out_node, DB_error_msg);
//
//										TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
//										TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
//										TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
// 
//										DBC_close_mtivlothis(i_his_step);
//
//										gs_log_type.type = MP_LOG_ERROR;
//										gs_log_type.category = MP_LOG_CATE_VIEW;
//										COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//										return MP_FALSE;
//									}								
//								}
//
//								memcpy(s_res_id, MRASRESDEF.RES_ID, sizeof(s_res_id));
//								memcpy(s_res_short_desc, MRASRESDEF.RES_SHORT_DESC, sizeof(s_res_short_desc));
//								memcpy(s_res_desc, MRASRESDEF.RES_DESC, sizeof(s_res_desc));
//
//							}
//							TRS.set_string(list_item, "RES_SHORT_DESC", s_res_short_desc, sizeof(s_res_short_desc));
//							TRS.set_string(list_item, "RES_DESC", s_res_desc, sizeof(s_res_desc));
//
//							
//						}
//						 
//					}
//
//					//DBC_init_mtivmatuse(&MTIVMATUSE);
//
//					//if (c_wip_or_inv == 'W')
//					//{
//					//	memcpy(MTIVMATUSE.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVMATUSE.FACTORY));						
//					//	memcpy(MTIVMATUSE.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MTIVMATUSE.LOT_ID));
//					//	MTIVMATUSE.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
//					//}
//					//else
//					//{
//					//	memcpy(MTIVMATUSE.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVMATUSE.FACTORY));
//					//	memcpy(MTIVMATUSE.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVMATUSE.LOT_ID));
//					//	MTIVMATUSE.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
//					//}
//					// 
//					//MTIVMATUSE.HIST_DEL_FLAG = ' ';
//					//i_sub_step = 2;
//
//					//DBC_open_mtivmatuse(i_sub_step, &MTIVMATUSE);
//					//if(DB_error_code != DB_SUCCESS)
//					//{
//					//	strcpy(s_msg_code, "WIP-0004");
//					//	TRS.add_fieldmsg(out_node, "MTIVMATUSE OPEN", MP_NVST);
//					//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
//					//	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
//					//	TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVMATUSE.HIST_SEQ);
//					//	TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR,  sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);
//
//					//	TRS.add_dberrmsg(out_node, DB_error_msg);
//					//		
//					//	DBC_close_mtivlothis(i_his_step);
//
//					//	gs_log_type.type = MP_LOG_ERROR;
//					//	gs_log_type.e_type = MP_LOG_E_SYSTEM;
//					//	gs_log_type.category = MP_LOG_CATE_VIEW;
//					//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//					//	return MP_FALSE;
//					//}
//
//					//while(1)
//					//{
//					//	DBC_fetch_mtivmatuse(i_sub_step, &MTIVMATUSE);
//					//	if(DB_error_code == DB_NOT_FOUND)
//					//	{
//					//		DBC_close_mtivmatuse(i_sub_step);
//					//		break;
//					//	}
//					//	else if(DB_error_code != DB_SUCCESS) 
//					//	{
//					//		strcpy(s_msg_code, "WIP-0004");
//					//		TRS.add_fieldmsg(out_node, "MTIVMATUSE FETCH", MP_NVST);
//					//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
//					//		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
//					//		TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVMATUSE.HIST_SEQ);
//					//		TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR,  sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);
//
//					//		TRS.add_dberrmsg(out_node, DB_error_msg);
//
//					//		DBC_close_mtivmatuse(i_sub_step);
//					//		DBC_close_mtivlothis(i_his_step);
//
//					//		gs_log_type.type = MP_LOG_ERROR;
//					//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
//					//		gs_log_type.category = MP_LOG_CATE_VIEW;
//					//		DBC_close_mtivmatuse(i_sub_step);
//
//					//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//					//		return MP_FALSE;
//					//	}
//
//					//	if(COM_check_node_length(out_node) == MP_FALSE)
//					//	{
//					//		/* Add Next Value Here */
//					//		DBC_close_mtivmatuse(i_sub_step);
//					//		break;
//					//	}
//
//					//	sub_item = TRS.add_node(list_item, "USE_LIST");
//					//		
//					//	TRS.add_char(sub_item, "WIP_OR_INV", MTIVMATUSE.WIP_OR_INV);
//					//	TRS.add_string(sub_item, "INPUT_LOT_ID", MTIVMATUSE.INPUT_LOT_ID, sizeof(MTIVMATUSE.INPUT_LOT_ID));
//					//	TRS.add_int(sub_item, "INPUT_HIST_SEQ", MTIVMATUSE.INPUT_HIST_SEQ);							
//					//	TRS.add_string(sub_item, "OPER", MTIVMATUSE.OPER, sizeof(MTIVMATUSE.OPER));						
//					//	TRS.add_char(sub_item, "INPUT_TYPE", MTIVMATUSE.INPUT_TYPE);
//					//	TRS.add_string(sub_item, "INPUT_MAT_ID", MTIVMATUSE.INPUT_MAT_ID, sizeof(MTIVMATUSE.INPUT_MAT_ID));
//					//	TRS.add_int(sub_item, "INPUT_MAT_VER", MTIVMATUSE.INPUT_MAT_VER);
//					//	TRS.add_string(sub_item, "INPUT_MAT_TYPE", MTIVMATUSE.INPUT_MAT_TYPE, sizeof(MTIVMATUSE.INPUT_MAT_TYPE));							
//					//	TRS.add_string(sub_item, "INPUT_OPER", MTIVMATUSE.INPUT_OPER, sizeof(MTIVMATUSE.INPUT_OPER));
//					//	TRS.add_double(sub_item, "INPUT_QTY_1", MTIVMATUSE.INPUT_QTY_1);
//					//	TRS.add_double(sub_item, "INPUT_QTY_2", MTIVMATUSE.INPUT_QTY_2);
//					//	TRS.add_double(sub_item, "INPUT_QTY_3", MTIVMATUSE.INPUT_QTY_3);
//
//					//	DBC_init_mwipmatdef(&MWIPMATDEF);
//
//					//	memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
//					//	//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
//					//	memcpy(MWIPMATDEF.MAT_ID, MTIVMATUSE.INPUT_MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
//					//	MWIPMATDEF.MAT_VER  = 1;
//					//	i_step = 1;
//					//	DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
//					//	if(DB_error_code != DB_SUCCESS) 
//					//	{
//					//		if(DB_error_code == DB_NOT_FOUND)
//					//		{
//					//			strcpy(s_msg_code, "WIP-0006");
//					//			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//					//		}
//					//		else 
//					//		{
//					//			strcpy(s_msg_code, "WIP-0004");
//					//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
//					//			TRS.add_dberrmsg(out_node, DB_error_msg);
//					//		}
//
//					//		TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
//					//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
//					//		TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
//					//		TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
// 
//					//		DBC_close_mtivmatuse(i_sub_step);
//					//		DBC_close_mtivlothis(i_his_step);
//
//					//		gs_log_type.type = MP_LOG_ERROR;
//					//		gs_log_type.category = MP_LOG_CATE_VIEW;
//					//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//					//		return MP_FALSE;
//					//	}
//					//	TRS.set_string(sub_item, "INPUT_MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
//					//	TRS.set_string(sub_item, "INPUT_MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
//					//}
//					
//				}

				if (memcmp(MTIVLOTHIS.TRAN_CODE, MP_TIV_TRAN_CODE_CV, sizeof(MTIVLOTHIS.TRAN_CODE)) == 0)
				{
					DBC_init_mtivlotcvm(&MTIVLOTCVM);
					memcpy(MTIVLOTCVM.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTCVM.LOT_ID));
					MTIVLOTCVM.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
					 
					i_sub_step = 3;

					DBC_open_mtivlotcvm(i_sub_step, &MTIVLOTCVM);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVLOTCVM OPEN", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTCVM.LOT_ID), MTIVLOTCVM.LOT_ID);
						TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTCVM.HIST_SEQ);
						TRS.add_fieldmsg(out_node, "QTY_FLAG", MP_CHR, MTIVLOTCVM.QTY_FLAG);
						TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, MTIVLOTCVM.SEQ_NUM);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						DBC_close_mtivlothis(i_his_step);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					while(1)
					{
						DBC_fetch_mtivlotcvm(i_sub_step, &MTIVLOTCVM);
						if(DB_error_code == DB_NOT_FOUND)
						{
							DBC_close_mtivlotcvm(i_sub_step);
							break;
						}
						else if(DB_error_code != DB_SUCCESS) 
						{
							strcpy(s_msg_code, "WIP-0004");
							TRS.add_fieldmsg(out_node, "MTIVLOTCVM FETCH", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTCVM.LOT_ID), MTIVLOTCVM.LOT_ID);
							TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTCVM.HIST_SEQ);
							TRS.add_fieldmsg(out_node, "QTY_FLAG", MP_CHR, MTIVLOTCVM.QTY_FLAG);
							TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, MTIVLOTCVM.SEQ_NUM);

							TRS.add_dberrmsg(out_node, DB_error_msg);

							DBC_close_mtivlothis(i_his_step);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							DBC_close_mtivlotcvm(i_sub_step);

							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}

						if(COM_check_node_length(out_node) == MP_FALSE)
						{
							/* Add Next Value Here */
							DBC_close_mtivlotcvm(i_sub_step);
							break;
						}

						sub_item = TRS.add_node(list_item, "CV_LIST");
						TRS.add_string(sub_item, "CV_CODE", MTIVLOTCVM.CV_CODE, sizeof(MTIVLOTCVM.CV_CODE));
						TRS.add_string(sub_item, "CV_DESC", MTIVLOTCVM.MAT_ID, sizeof(MTIVLOTCVM.MAT_ID));
						TRS.add_double(sub_item, "CV_QTY", MTIVLOTCVM.CV_QTY);

						/*TRS.add_string(sub_item, "LOT_ID", MTIVLOTCVM.LOT_ID, sizeof(MTIVLOTCVM.LOT_ID));
						TRS.add_int(sub_item, "HIST_SEQ", MTIVLOTCVM.HIST_SEQ);
						TRS.add_char(sub_item, "QTY_FLAG", MTIVLOTCVM.QTY_FLAG);
						TRS.add_string(sub_item, "TRAN_TIME", MTIVLOTCVM.TRAN_TIME, sizeof(MTIVLOTCVM.TRAN_TIME));
						TRS.add_char(sub_item, "HIST_DEL_FLAG", MTIVLOTCVM.HIST_DEL_FLAG);
						TRS.add_string(sub_item, "FACTORY", MTIVLOTCVM.FACTORY, sizeof(MTIVLOTCVM.FACTORY));
						TRS.add_string(sub_item, "MAT_ID", MTIVLOTCVM.MAT_ID, sizeof(MTIVLOTCVM.MAT_ID));
						TRS.add_int(sub_item, "MAT_VER", MTIVLOTCVM.MAT_VER);
						TRS.add_string(sub_item, "OPER", MTIVLOTCVM.OPER, sizeof(MTIVLOTCVM.OPER));
						TRS.add_int(sub_item, "SEQ_NUM", MTIVLOTCVM.SEQ_NUM);*/
						 
					}
				}
				 
				if (memcmp(MTIVLOTHIS.TRAN_CODE, MP_TIV_TRAN_CODE_LOSS, sizeof(MTIVLOTHIS.TRAN_CODE)) == 0)
				{
					DBC_init_mtivlotlsm(&MTIVLOTLSM);
					memcpy(MTIVLOTLSM.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTLSM.LOT_ID));
					MTIVLOTLSM.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
					MTIVLOTLSM.QTY_FLAG = '1';
					i_sub_step = 3;

					DBC_open_mtivlotlsm(i_sub_step, &MTIVLOTLSM);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVLOTLSM OPEN", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTLSM.LOT_ID), MTIVLOTLSM.LOT_ID);
						TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTLSM.HIST_SEQ);
						TRS.add_fieldmsg(out_node, "QTY_FLAG", MP_CHR, MTIVLOTLSM.QTY_FLAG);
						TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, MTIVLOTLSM.SEQ_NUM);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						DBC_close_mtivlothis(i_his_step);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					while(1)
					{
						DBC_fetch_mtivlotlsm(i_sub_step, &MTIVLOTLSM);
						if(DB_error_code == DB_NOT_FOUND)
						{
							DBC_close_mtivlotlsm(i_sub_step);
							break;
						}
						else if(DB_error_code != DB_SUCCESS) 
						{
							strcpy(s_msg_code, "WIP-0004");
							TRS.add_fieldmsg(out_node, "MTIVLOTLSM FETCH", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTLSM.LOT_ID), MTIVLOTLSM.LOT_ID);
							TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTLSM.HIST_SEQ);
							TRS.add_fieldmsg(out_node, "QTY_FLAG", MP_CHR, MTIVLOTLSM.QTY_FLAG);
							TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, MTIVLOTLSM.SEQ_NUM);

							TRS.add_dberrmsg(out_node, DB_error_msg);

							

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;

							DBC_close_mtivlothis(i_his_step);
							DBC_close_mtivlotcvm(i_sub_step);

							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}

						if(COM_check_node_length(out_node) == MP_FALSE)
						{
							/* Add Next Value Here */
							DBC_close_mtivlotlsm(i_sub_step);
							break;
						}

						DBU_init_mgcmtbldat(&MGCMTBLDAT);
						TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
						memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_LOSS_CODE, strlen(MP_GCM_LOSS_CODE));
						memcpy(MGCMTBLDAT.KEY_1, MTIVLOTLSM.LOSS_CODE, sizeof(MTIVLOTLSM.LOSS_CODE));
			
						i_step = 1;
						DBU_select_mgcmtbldat(i_step, &MGCMTBLDAT);
						if(DB_error_code != DB_SUCCESS)
						{
							if (DB_error_code == DB_NOT_FOUND)
							{	
					 
							}
							else
							{	
								strcpy(s_msg_code,"GCM-0004");			
								TRS.add_dberrmsg(out_node, DB_error_msg);	
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
					
								DBC_close_mtivlotlsm(i_sub_step);

								TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
								TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
								TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
								TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								gs_log_type.category = MP_LOG_CATE_TRANS;
 
								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
								return MP_FALSE;
							}
						}
							
						sub_item = TRS.add_node(list_item, "LOSS_LIST");
						TRS.add_string(sub_item, "LOSS_CODE", MTIVLOTLSM.LOSS_CODE, sizeof(MTIVLOTLSM.LOSS_CODE));
						//TRS.add_string(sub_item, "LOSS_DESC", MTIVLOTLSM.MAT_ID, sizeof(MTIVLOTLSM.MAT_ID));
						TRS.add_string(sub_item, "LOSS_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
						TRS.add_double(sub_item, "LOSS_QTY", MTIVLOTLSM.LOSS_QTY);

						/*TRS.add_string(sub_item, "LOT_ID", MTIVLOTCVM.LOT_ID, sizeof(MTIVLOTCVM.LOT_ID));
						TRS.add_int(sub_item, "HIST_SEQ", MTIVLOTCVM.HIST_SEQ);
						TRS.add_char(sub_item, "QTY_FLAG", MTIVLOTCVM.QTY_FLAG);
						TRS.add_string(sub_item, "TRAN_TIME", MTIVLOTCVM.TRAN_TIME, sizeof(MTIVLOTCVM.TRAN_TIME));
						TRS.add_char(sub_item, "HIST_DEL_FLAG", MTIVLOTCVM.HIST_DEL_FLAG);
						TRS.add_string(sub_item, "FACTORY", MTIVLOTCVM.FACTORY, sizeof(MTIVLOTCVM.FACTORY));
						TRS.add_string(sub_item, "MAT_ID", MTIVLOTCVM.MAT_ID, sizeof(MTIVLOTCVM.MAT_ID));
						TRS.add_int(sub_item, "MAT_VER", MTIVLOTCVM.MAT_VER);
						TRS.add_string(sub_item, "OPER", MTIVLOTCVM.OPER, sizeof(MTIVLOTCVM.OPER));
						TRS.add_int(sub_item, "SEQ_NUM", MTIVLOTCVM.SEQ_NUM);*/
						 
					}
				}

				TRS.set_string(list_item, "INSPECTION_FLAG_DESC", " ", strlen(" "));
				TRS.set_string(list_item, "INSPECTION_RESULT_DESC", " ", strlen(" "));
				TRS.set_string(list_item, "QC_LOT_ID", " ", strlen(" "));
				TRS.set_int(list_item, "EDC_HIST_SEQ", 0);

				if (memcmp(MTIVLOTHIS.TRAN_CODE, MP_TIV_TRAN_CODE_INSPECTION, sizeof(MTIVLOTHIS.TRAN_CODE)) == 0)
				{
					//DBC_init_ctivisphis(&CTIVISPHIS);

					//memcpy(CTIVISPHIS.FACTORY, MTIVLOTHIS.FACTORY, sizeof(CTIVISPHIS.FACTORY));
					////memcpy(CTIVISPHIS.FACTORY, MTIVLOTHIS.FACTORY, sizeof(CTIVISPHIS.FACTORY));    
					//memcpy(CTIVISPHIS.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(CTIVISPHIS.LOT_ID));
					//CTIVISPHIS.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
					//i_step = 1;

					//DBC_select_ctivisphis(i_step, &CTIVISPHIS);
					//if(DB_error_code != DB_SUCCESS)
					//{
					//	if (DB_error_code == DB_NOT_FOUND)
					//	{													
					//	}
					//	else
					//	{	
					//		strcpy(s_msg_code,"GCM-0004");			
					//		TRS.add_dberrmsg(out_node, DB_error_msg);	
					//		gs_log_type.e_type = MP_LOG_E_SYSTEM;

					//		TRS.add_fieldmsg(out_node, "CTIVISPHIS SELECT FACTORY", MP_STR, sizeof(CTIVISPHIS.FACTORY), CTIVISPHIS.FACTORY);
					//		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CTIVISPHIS.LOT_ID), CTIVISPHIS.LOT_ID);

					//		gs_log_type.type = MP_LOG_ERROR;
					//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
					//		gs_log_type.category = MP_LOG_CATE_TRANS;

					//		DBC_close_mtivlothis(i_his_step);
 
					//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					//		return MP_FALSE;
					//	} 
					//}

					//TRS.set_string(list_item, "QC_LOT_ID", CTIVISPHIS.QC_LOT_ID, sizeof(CTIVISPHIS.QC_LOT_ID));
					//TRS.set_int(list_item, "EDC_HIST_SEQ", CTIVISPHIS.EDC_HIST_SEQ);

					if (MTIVLOTHIS.INSPECTION_FLAG != ' ')
					{
						DBU_init_mgcmtbldat(&MGCMTBLDAT);

						memcpy(MGCMTBLDAT.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
						//TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
						memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_TYPE, strlen(MP_GCM_INSP_TYPE));
						MGCMTBLDAT.KEY_1[0] = MTIVLOTHIS.INSPECTION_FLAG;
			 
						i_step = 1;
						DBU_select_mgcmtbldat(i_step, &MGCMTBLDAT);
						if(DB_error_code != DB_SUCCESS)
						{
							if (DB_error_code == DB_NOT_FOUND)
							{													
							}
							else
							{	
								strcpy(s_msg_code,"GCM-0004");			
								TRS.add_dberrmsg(out_node, DB_error_msg);	
								gs_log_type.e_type = MP_LOG_E_SYSTEM;

								TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
								TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
								TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
								TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								gs_log_type.category = MP_LOG_CATE_TRANS;

								DBC_close_mtivlothis(i_his_step);
 
								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
								return MP_FALSE;
							} 
						}

						TRS.set_string(list_item, "INSPECTION_FLAG_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));						 
					}
					
					if (MTIVLOTHIS.INSPECTION_RESULT != ' ')
					{
						DBU_init_mgcmtbldat(&MGCMTBLDAT);

						memcpy(MGCMTBLDAT.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
						//TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
						memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_RESULT, strlen(MP_GCM_INSP_RESULT));
						MGCMTBLDAT.KEY_1[0] = MTIVLOTHIS.INSPECTION_RESULT;
			 
						i_step = 1;
						DBU_select_mgcmtbldat(i_step, &MGCMTBLDAT);
						if(DB_error_code != DB_SUCCESS)
						{
							if (DB_error_code == DB_NOT_FOUND)
							{													
							}
							else
							{	
								strcpy(s_msg_code,"GCM-0004");			
								TRS.add_dberrmsg(out_node, DB_error_msg);	
								gs_log_type.e_type = MP_LOG_E_SYSTEM;

								TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
								TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
								TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
								TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								gs_log_type.category = MP_LOG_CATE_TRANS;

								DBC_close_mtivlothis(i_his_step);
 
								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
								return MP_FALSE;
							} 
						}
						TRS.set_string(list_item, "INSPECTION_RESULT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));	
					}
				}

				if (memcmp(MTIVLOTHIS.TRAN_CODE, MP_TIV_TRAN_CODE_SHIP, sizeof(MTIVLOTHIS.TRAN_CODE)) == 0 &&
					MTIVLOTHIS.IN_OUT_FLAG == 'I' &&
					memcmp(MTIVLOTHIS.FACTORY, MP_WIP_CUSTOMER_FACTORY, strlen(MP_WIP_CUSTOMER_FACTORY)) == 0)
				{
					DBC_init_mtivshplot(&MTIVSHPLOT);
					TRS.copy(MTIVSHPLOT.FACTORY, sizeof(MTIVSHPLOT.FACTORY), in_node, IN_FACTORY);
					memcpy(MTIVSHPLOT.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVSHPLOT.LOT_ID));
					MTIVSHPLOT.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
    
					i_step = 1;
					DBC_select_mtivshplot(i_step, &MTIVSHPLOT);
					if(DB_error_code != DB_SUCCESS) 
					{
						if (DB_error_code == DB_NOT_FOUND)
						{

						}
						else
						{
							strcpy(s_msg_code, "WIP-0004");
							TRS.add_fieldmsg(out_node, "MTIVSHPLOT OPEN", MP_NVST);        
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVSHPLOT.FACTORY), MTIVSHPLOT.FACTORY);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVSHPLOT.LOT_ID), MTIVSHPLOT.LOT_ID);
							TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVSHPLOT.HIST_SEQ);


							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
					}
					else
					{					
						DBC_init_mgcmlagdat(&MGCMLAGDAT);
						TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
						memcpy(MGCMLAGDAT.TABLE_NAME, MP_GCM_TBL_CUSTOMER_CODE_LAG, strlen(MP_GCM_TBL_CUSTOMER_CODE_LAG));
						memcpy(MGCMLAGDAT.KEY_1, MTIVSHPLOT.CUSTOMER_CODE, sizeof(MTIVSHPLOT.CUSTOMER_CODE));

						DBC_select_mgcmlagdat(1, &MGCMLAGDAT);

						TRS.add_string(list_item, "CUSTOMER_CODE", MTIVSHPLOT.CUSTOMER_CODE, sizeof(MTIVSHPLOT.CUSTOMER_CODE));
						TRS.add_string(list_item, "CUSTOMER_DESC", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
						 
					}
				}


				DBC_init_mtivmatuse(&MTIVMATUSE);

				memcpy(MTIVMATUSE.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVMATUSE.FACTORY));
				memcpy(MTIVMATUSE.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVMATUSE.LOT_ID));
				MTIVMATUSE.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
					 
				MTIVMATUSE.HIST_DEL_FLAG = ' ';
				i_sub_step = 2;

				DBC_open_mtivmatuse(i_sub_step, &MTIVMATUSE);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MTIVMATUSE OPEN", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
					TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVMATUSE.HIST_SEQ);
					TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR,  sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);

					TRS.add_dberrmsg(out_node, DB_error_msg);
							
					DBC_close_mtivlothis(i_his_step);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				while(1)
				{
					DBC_fetch_mtivmatuse(i_sub_step, &MTIVMATUSE);
					if(DB_error_code == DB_NOT_FOUND)
					{
						DBC_close_mtivmatuse(i_sub_step);
						break;
					}
					else if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVMATUSE FETCH", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
						TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVMATUSE.HIST_SEQ);
						TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR,  sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						DBC_close_mtivmatuse(i_sub_step);
						DBC_close_mtivlothis(i_his_step);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						DBC_close_mtivmatuse(i_sub_step);

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					if(COM_check_node_length(out_node) == MP_FALSE)
					{
						/* Add Next Value Here */
						DBC_close_mtivmatuse(i_sub_step);
						break;
					}

					sub_item = TRS.add_node(list_item, "USE_LIST");
							
					TRS.add_char(sub_item, "WIP_OR_INV", MTIVMATUSE.WIP_OR_INV);
					TRS.add_string(sub_item, "INPUT_LOT_ID", MTIVMATUSE.INPUT_LOT_ID, sizeof(MTIVMATUSE.INPUT_LOT_ID));
					TRS.add_int(sub_item, "INPUT_HIST_SEQ", MTIVMATUSE.INPUT_HIST_SEQ);							
					TRS.add_string(sub_item, "OPER", MTIVMATUSE.OPER, sizeof(MTIVMATUSE.OPER));						
					TRS.add_char(sub_item, "INPUT_TYPE", MTIVMATUSE.INPUT_TYPE);
					TRS.add_string(sub_item, "INPUT_MAT_ID", MTIVMATUSE.INPUT_MAT_ID, sizeof(MTIVMATUSE.INPUT_MAT_ID));
					TRS.add_int(sub_item, "INPUT_MAT_VER", MTIVMATUSE.INPUT_MAT_VER);
					TRS.add_string(sub_item, "INPUT_MAT_TYPE", MTIVMATUSE.INPUT_MAT_TYPE, sizeof(MTIVMATUSE.INPUT_MAT_TYPE));							
					TRS.add_string(sub_item, "INPUT_OPER", MTIVMATUSE.INPUT_OPER, sizeof(MTIVMATUSE.INPUT_OPER));
					TRS.add_double(sub_item, "INPUT_QTY_1", MTIVMATUSE.INPUT_QTY_1);
					TRS.add_double(sub_item, "INPUT_QTY_2", MTIVMATUSE.INPUT_QTY_2);
					TRS.add_double(sub_item, "INPUT_QTY_3", MTIVMATUSE.INPUT_QTY_3);

					DBC_init_mwipmatdef(&MWIPMATDEF);

					memcpy(MWIPMATDEF.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
					//TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
					memcpy(MWIPMATDEF.MAT_ID, MTIVMATUSE.INPUT_MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
					MWIPMATDEF.MAT_VER  = 1;
					i_step = 1;
					DBC_select_mwipmatdef(i_step, &MWIPMATDEF);
					if(DB_error_code != DB_SUCCESS) 
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							strcpy(s_msg_code, "WIP-0006");
							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						}
						else 
						{
							strcpy(s_msg_code, "WIP-0004");
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							TRS.add_dberrmsg(out_node, DB_error_msg);
						}

						TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
 
						DBC_close_mtivmatuse(i_sub_step);
						DBC_close_mtivlothis(i_his_step);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
					TRS.set_string(sub_item, "INPUT_MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
					TRS.set_string(sub_item, "INPUT_MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
				}
			}

		}
    }
	 

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_History",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Lot_History_Validation()
        - Validation Check sub function of "TIV_VIEW_LOT_HISTORY" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_History_Validation(char *s_msg_code,
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
    ///* Lot ID Validation */
    //if(TRS.get_procstep(in_node)!='2' && TRS.get_char(in_node, "NO_LOT_VALIDATION")!='Y')
    //{
    //    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    //    {
    //        strcpy(s_msg_code, "INV-0001");
    //        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //        gs_log_type.category = MP_LOG_CATE_VIEW;
    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}

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