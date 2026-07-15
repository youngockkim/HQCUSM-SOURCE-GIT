/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot_history.c
    Description : View Inventory Lot History related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Lot_History_N()
            + View Inventory Lot History
        - TIV_View_Lot_History_N()
            + Main Sub function of "TIV_View_Lot_History_N"
            + (called by "TIV_View_Lot_History_N")
        - TIV_View_Lot_History_N_Validation()
            + Validation Check sub function of "TIV_View_Lot_History_N" function
            + (called by "TIV_View_Lot_History_N")

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

int TIV_View_Lot_History_N_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


/*******************************************************************************
    TIV_View_Lot_History_N()
        - View Inventory Lot History
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_History_N(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT_HISTORY_N(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT_HISTORY_N", out_node);

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
    TIV_VIEW_LOT_HISTORY_N()
        - Main sub function of "TIV_View_Lot_History_N" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT_HISTORY_N(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MATRNAMSTS_TAG MATRNAMSTS;
    struct MTIVIQCHIS_TAG MTIVIQCHIS;

    TRSNode *hist_item;

    int i_step = 0;
    int i_his_step = 0;

    LOG_head("TIV_View_Lot_History_N");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("hist_seq", MP_INT, TRS.get_int(in_node, "HIST_SEQ"));
    LOG_add("next_hist_seq", MP_INT, TRS.get_int(in_node, "NEXT_HIST_SEQ"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_History_N",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    TRS.add_int(out_node, "NEXT_HIST_SEQ", 0);

    /* Validation Check */
    if(TIV_View_Lot_History_N_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(TRS.get_procstep(in_node)=='1')
    {
        i_step = 101;

        DBC_init_mtivlotsts(&MTIVLOTSTS);   
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY); 
        TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
        TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
        DBC_select_mtivlotsts(i_step, &MTIVLOTSTS);

        if(DB_error_code != DB_SUCCESS) 
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "INV-0002");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else 
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }

            TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);        
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    if(TRS.get_procstep(in_node)=='1' || TRS.get_procstep(in_node)=='2'||TRS.get_procstep(in_node)=='4'||TRS.get_procstep(in_node)=='6')
    {
        DBC_init_mtivlothis(&MTIVLOTHIS);
        TRS.copy(MTIVLOTHIS.FACTORY , sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);    
        TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "LOT_ID");

        DB_init_condition(&DBC_Q_COND);
        TRS.copy(DBC_Q_COND.FROM_TIME, sizeof(DBC_Q_COND.FROM_TIME), in_node, "FROM_TIME");
        TRS.copy(DBC_Q_COND.TO_TIME, sizeof(DBC_Q_COND.TO_TIME), in_node, "TO_TIME");
        DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);
        
        if(TRS.get_procstep(in_node)=='1'||TRS.get_procstep(in_node)=='4')
        {
            i_his_step = 4;
            TRS.copy(MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID), in_node, "MAT_ID");
            TRS.copy(MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE),in_node, "TRAN_TYPE");
        }
        else if(TRS.get_procstep(in_node)=='2')
        {
            i_his_step = 5;
            TRS.copy(MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER), in_node, "OPER");
            MTIVLOTHIS.HIST_DEL_FLAG = TRS.get_char(in_node, "HIST_DEL_FLAG"); 

            /*Add. 2013.11 JJ.OH  
	        IQC OPERATION VALIDATION*/
            //out_node로 IQC Oper인지 전해 줄 수 있도록
	        DBC_init_matrnamsts(&MATRNAMSTS);
	        TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	        memcpy(MATRNAMSTS.ATTR_TYPE, "TIV_OPER", strlen("TIV_OPER")); 
	        memcpy(MATRNAMSTS.ATTR_NAME, "IQCOper", strlen("IQCOper"));
	        TRS.copy(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY), in_node, "OPER");
            DBC_select_matrnamsts(1, &MATRNAMSTS);//ATTR_VALUE만 가지고온다. 
            if(DB_error_code != DB_SUCCESS)
            {
	        	if(DB_error_code != DB_NOT_FOUND)
	        	{
	        		strcpy(s_msg_code, "WIP-0004");
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);
	        		
                    TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
	        	    TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
	        	    TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
	        	    TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.category = MP_LOG_CATE_COMMON;
                    return MP_FALSE;
	        	}
            }
            /*if Selected Operation is IQC Operation Then out_node IQC_OPER = 'Y'*/
	        if(memcmp(MATRNAMSTS.ATTR_VALUE, "Y", strlen("Y"))==0)
	        {
                TRS.add_char(out_node, "IQC_OPER", 'Y');
	        }
        }
        else if(TRS.get_procstep(in_node)=='6')
        {
            i_his_step = 6;
            TRS.copy(MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID), in_node, "MAT_ID");
            TRS.copy(MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE),in_node, "TRAN_TYPE");
        }

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
            /*TRS.add_fieldmsg(out_node, "MTIVLOTHIS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTHIS.OPER), MTIVLOTHIS.OPER);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS.HIST_SEQ);*/
            
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
                /*TRS.add_fieldmsg(out_node, "MTIVLOTHIS OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
                TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTHIS.OPER), MTIVLOTHIS.OPER);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);
                TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS.HIST_SEQ);*/

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
                hist_item = TRS.add_node(out_node, "LIST");

                TRS.add_string(hist_item, "FACTORY", MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY));
                TRS.add_string(hist_item, "OPER", MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER));
                TRS.add_string(hist_item, "LOT_ID", MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID));
                TRS.add_int(hist_item, "HIST_SEQ", MTIVLOTHIS.HIST_SEQ);
                TRS.add_string(hist_item, "TRAN_CODE", MTIVLOTHIS.TRAN_CODE, sizeof(MTIVLOTHIS.TRAN_CODE));
                TRS.add_string(hist_item, "TRAN_TYPE", MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE));
                TRS.add_string(hist_item, "TRAN_TIME", MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME));
                TRS.add_string(hist_item, "SYS_TRAN_TIME", MTIVLOTHIS.SYS_TRAN_TIME, sizeof(MTIVLOTHIS.SYS_TRAN_TIME));            
                TRS.add_string(hist_item, "MAT_ID", MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID));
                TRS.add_int(hist_item, "MAT_VER", MTIVLOTHIS.MAT_VER); /* Add for V42 */
                TRS.add_char(hist_item, "LOT_TYPE", MTIVLOTHIS.LOT_TYPE);
                TRS.add_double(hist_item, "QTY_1", MTIVLOTHIS.QTY_1);
                TRS.add_double(hist_item, "QTY_2", MTIVLOTHIS.QTY_2);
                TRS.add_double(hist_item, "QTY_3", MTIVLOTHIS.QTY_3);            
                TRS.add_double(hist_item, "CREATE_QTY_1", MTIVLOTHIS.CREATE_QTY_1);
                TRS.add_double(hist_item, "CREATE_QTY_2", MTIVLOTHIS.CREATE_QTY_2);
                TRS.add_double(hist_item, "CREATE_QTY_3", MTIVLOTHIS.CREATE_QTY_3);
                TRS.add_string(hist_item, "CREATE_TIME", MTIVLOTHIS.CREATE_TIME, sizeof(MTIVLOTHIS.CREATE_TIME));
                TRS.add_char(hist_item, "IN_OUT_FLAG", MTIVLOTHIS.IN_OUT_FLAG);
                TRS.add_string(hist_item, "FROM_TO_LOT_ID", MTIVLOTHIS.FROM_TO_LOT_ID, sizeof(MTIVLOTHIS.FROM_TO_LOT_ID));
                TRS.add_int(hist_item, "FROM_TO_HIST_SEQ", MTIVLOTHIS.FROM_TO_HIST_SEQ);
                TRS.add_char(hist_item, "FROM_TO_FLAG", MTIVLOTHIS.FROM_TO_FLAG);
                TRS.add_double(hist_item, "FROM_TO_QTY_1", MTIVLOTHIS.FROM_TO_QTY_1);
                TRS.add_double(hist_item, "FROM_TO_QTY_2", MTIVLOTHIS.FROM_TO_QTY_2);
                TRS.add_double(hist_item, "FROM_TO_QTY_3", MTIVLOTHIS.FROM_TO_QTY_3);
                TRS.add_string(hist_item, "PROD_LOT_ID", MTIVLOTHIS.PROD_LOT_ID, sizeof(MTIVLOTHIS.PROD_LOT_ID));
                TRS.add_int(hist_item, "PROD_HIST_SEQ", MTIVLOTHIS.PROD_HIST_SEQ);
                TRS.add_double(hist_item, "PROD_QTY_1", MTIVLOTHIS.PROD_QTY_1);
                TRS.add_double(hist_item, "PROD_QTY_2", MTIVLOTHIS.PROD_QTY_2);
                TRS.add_double(hist_item, "PROD_QTY_3", MTIVLOTHIS.PROD_QTY_3);
                TRS.add_string(hist_item, "ORDER_ID", MTIVLOTHIS.ORDER_ID, sizeof(MTIVLOTHIS.ORDER_ID));
                TRS.add_string(hist_item, "LINE_NO", MTIVLOTHIS.LINE_NO, sizeof(MTIVLOTHIS.LINE_NO));
                TRS.add_string(hist_item, "OLD_FACTORY", MTIVLOTHIS.OLD_FACTORY, sizeof(MTIVLOTHIS.OLD_FACTORY));
                TRS.add_string(hist_item, "OLD_OPER", MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER));
                TRS.add_double(hist_item, "OLD_QTY_1", MTIVLOTHIS.OLD_QTY_1);
                TRS.add_double(hist_item, "OLD_QTY_2", MTIVLOTHIS.OLD_QTY_2);
                TRS.add_double(hist_item, "OLD_QTY_3", MTIVLOTHIS.OLD_QTY_3);
                TRS.add_string(hist_item, "UNIT_1", MTIVLOTHIS.UNIT_1, sizeof(MTIVLOTHIS.UNIT_1));
                TRS.add_string(hist_item, "UNIT_2", MTIVLOTHIS.UNIT_2, sizeof(MTIVLOTHIS.UNIT_2));
                TRS.add_string(hist_item, "UNIT_3", MTIVLOTHIS.UNIT_3, sizeof(MTIVLOTHIS.UNIT_3));
                TRS.add_char(hist_item, "INSP_FLAG", MTIVLOTHIS.INSPECTION_FLAG);
                TRS.add_char(hist_item, "INSPECTION_RESULT", MTIVLOTHIS.INSPECTION_RESULT);
                TRS.add_string(hist_item, "TRAN_COMMENT", MTIVLOTHIS.TRAN_COMMENT, sizeof(MTIVLOTHIS.TRAN_COMMENT));
                TRS.add_enc_string(hist_item, "TRAN_USER_ID", MTIVLOTHIS.TRAN_USER_ID, sizeof(MTIVLOTHIS.TRAN_USER_ID));
                TRS.add_char(hist_item, "LOT_DEL_FLAG", MTIVLOTHIS.LOT_DEL_FLAG);
                TRS.add_enc_string(hist_item, "LOT_DEL_USER_ID", MTIVLOTHIS.LOT_DEL_USER_ID, sizeof(MTIVLOTHIS.LOT_DEL_USER_ID));
                TRS.add_string(hist_item, "LOT_DEL_TIME", MTIVLOTHIS.LOT_DEL_TIME, sizeof(MTIVLOTHIS.LOT_DEL_TIME));
                TRS.add_string(hist_item, "LOT_DEL_REASON", MTIVLOTHIS.LOT_DEL_REASON, sizeof(MTIVLOTHIS.LOT_DEL_REASON));
                TRS.add_char(hist_item, "HIST_DEL_FLAG", MTIVLOTHIS.HIST_DEL_FLAG);
                TRS.add_enc_string(hist_item, "HIST_DEL_USER_ID", MTIVLOTHIS.HIST_DEL_USER_ID, sizeof(MTIVLOTHIS.HIST_DEL_USER_ID));
                TRS.add_string(hist_item, "HIST_DEL_TIME", MTIVLOTHIS.HIST_DEL_TIME, sizeof(MTIVLOTHIS.HIST_DEL_TIME));            
                TRS.add_string(hist_item, "LOCATION", MTIVLOTHIS.LOCATION_NO, sizeof(MTIVLOTHIS.LOCATION_NO));
                TRS.add_char(hist_item, "HOLD_FLAG", MTIVLOTHIS.HOLD_FLAG);
                TRS.add_string(hist_item, "HOLD_CODE", MTIVLOTHIS.HOLD_CODE, sizeof(MTIVLOTHIS.HOLD_CODE));
                TRS.add_string(hist_item, "RELEASE_CODE", MTIVLOTHIS.RELEASE_CODE, sizeof(MTIVLOTHIS.RELEASE_CODE));
                TRS.add_char(hist_item, "PICK_FLAG", MTIVLOTHIS.PICK_FLAG);
                TRS.add_char(hist_item, "SHIP_FLAG", MTIVLOTHIS.SHIP_FLAG);
                //TRS.add_string(hist_item, "FROM_LOT_ID", MTIVLOTHIS.FROM_LOT_ID, sizeof(MTIVLOTHIS.FROM_LOT_ID));
                //TRS.add_string(hist_item, "FROM_OPER", MTIVLOTHIS.FROM_OPER, sizeof(MTIVLOTHIS.FROM_OPER));
                TRS.add_string(hist_item, "TIV_GRADE", MTIVLOTHIS.GRADE, sizeof(MTIVLOTHIS.GRADE));
                TRS.add_string(hist_item, "ADD_ORDER_ID_1", MTIVLOTHIS.ADD_ORDER_ID_1, sizeof(MTIVLOTHIS.ADD_ORDER_ID_1));
                TRS.add_string(hist_item, "ADD_ORDER_LINE_1", MTIVLOTHIS.ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_1));
                TRS.add_string(hist_item, "ADD_ORDER_ID_2", MTIVLOTHIS.ADD_ORDER_ID_2, sizeof(MTIVLOTHIS.ADD_ORDER_ID_2));
                TRS.add_string(hist_item, "ADD_ORDER_LINE_2", MTIVLOTHIS.ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_2));
                TRS.add_string(hist_item, "ADD_ORDER_ID_3", MTIVLOTHIS.ADD_ORDER_ID_3, sizeof(MTIVLOTHIS.ADD_ORDER_ID_3));
                TRS.add_string(hist_item, "ADD_ORDER_LINE_3", MTIVLOTHIS.ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_3));
                TRS.add_string(hist_item, "VENDOR", MTIVLOTHIS.VENDOR_LOT_ID, sizeof(MTIVLOTHIS.VENDOR_LOT_ID));
                TRS.add_string(hist_item, "PO_MAT_ID", MTIVLOTHIS.PO_MAT_ID, sizeof(MTIVLOTHIS.PO_MAT_ID));
                TRS.add_int(hist_item, "PO_SEQ_NUM", MTIVLOTHIS.PO_SEQ_NUM);
                TRS.add_string(hist_item, "INV_CMF_1", MTIVLOTHIS.INV_CMF_1, sizeof(MTIVLOTHIS.INV_CMF_1));
                TRS.add_string(hist_item, "INV_CMF_2", MTIVLOTHIS.INV_CMF_2, sizeof(MTIVLOTHIS.INV_CMF_2));
                TRS.add_string(hist_item, "INV_CMF_3", MTIVLOTHIS.INV_CMF_3, sizeof(MTIVLOTHIS.INV_CMF_3));
                TRS.add_string(hist_item, "INV_CMF_4", MTIVLOTHIS.INV_CMF_4, sizeof(MTIVLOTHIS.INV_CMF_4));
                TRS.add_string(hist_item, "INV_CMF_5", MTIVLOTHIS.INV_CMF_5, sizeof(MTIVLOTHIS.INV_CMF_5));
                TRS.add_string(hist_item, "INV_CMF_6", MTIVLOTHIS.INV_CMF_6, sizeof(MTIVLOTHIS.INV_CMF_6));
                TRS.add_string(hist_item, "INV_CMF_7", MTIVLOTHIS.INV_CMF_7, sizeof(MTIVLOTHIS.INV_CMF_7));
                TRS.add_string(hist_item, "INV_CMF_8", MTIVLOTHIS.INV_CMF_8, sizeof(MTIVLOTHIS.INV_CMF_8));
                TRS.add_string(hist_item, "INV_CMF_9", MTIVLOTHIS.INV_CMF_9, sizeof(MTIVLOTHIS.INV_CMF_9));
                TRS.add_string(hist_item, "INV_CMF_10", MTIVLOTHIS.INV_CMF_10, sizeof(MTIVLOTHIS.INV_CMF_10));
                TRS.add_string(hist_item, "INV_CMF_11", MTIVLOTHIS.INV_CMF_11, sizeof(MTIVLOTHIS.INV_CMF_11));
                TRS.add_string(hist_item, "INV_CMF_12", MTIVLOTHIS.INV_CMF_12, sizeof(MTIVLOTHIS.INV_CMF_12));
                TRS.add_string(hist_item, "INV_CMF_13", MTIVLOTHIS.INV_CMF_13, sizeof(MTIVLOTHIS.INV_CMF_13));
                TRS.add_string(hist_item, "INV_CMF_14", MTIVLOTHIS.INV_CMF_14, sizeof(MTIVLOTHIS.INV_CMF_14));
                TRS.add_string(hist_item, "INV_CMF_15", MTIVLOTHIS.INV_CMF_15, sizeof(MTIVLOTHIS.INV_CMF_15));
                TRS.add_string(hist_item, "INV_CMF_16", MTIVLOTHIS.INV_CMF_16, sizeof(MTIVLOTHIS.INV_CMF_16));
                TRS.add_string(hist_item, "INV_CMF_17", MTIVLOTHIS.INV_CMF_17, sizeof(MTIVLOTHIS.INV_CMF_17));
                TRS.add_string(hist_item, "INV_CMF_18", MTIVLOTHIS.INV_CMF_18, sizeof(MTIVLOTHIS.INV_CMF_18));
                TRS.add_string(hist_item, "INV_CMF_19", MTIVLOTHIS.INV_CMF_19, sizeof(MTIVLOTHIS.INV_CMF_19));
                TRS.add_string(hist_item, "INV_CMF_20", MTIVLOTHIS.INV_CMF_20, sizeof(MTIVLOTHIS.INV_CMF_20));
                TRS.add_string(hist_item, "OWNER_CODE", MTIVLOTHIS.OWNER_CODE, sizeof(MTIVLOTHIS.OWNER_CODE));
                TRS.add_string(hist_item, "VENDOR_ID", MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID));
                TRS.add_string(hist_item, "FROM_TO_OPER", MTIVLOTHIS.FROM_TO_OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
	    		TRS.add_string(hist_item, "OLD_LOCATION_NO", MTIVLOTHIS.OLD_LOCATION_NO, sizeof(MTIVLOTHIS.OLD_LOCATION_NO));
	    		TRS.add_string(hist_item, "LOT_GROUP_ID", MTIVLOTHIS.LOT_GROUP_ID, sizeof(MTIVLOTHIS.LOT_GROUP_ID));
                TRS.add_string(hist_item, "EXPIRE_DATE", MTIVLOTHIS.EXPIRE_DATE, sizeof(MTIVLOTHIS.EXPIRE_DATE));
		        TRS.add_string(hist_item, "INV_IN_TIME", MTIVLOTHIS.INV_IN_TIME, sizeof(MTIVLOTHIS.INV_IN_TIME));
		        TRS.add_string(hist_item, "INV_OUT_TIME", MTIVLOTHIS.INV_OUT_TIME, sizeof(MTIVLOTHIS.INV_OUT_TIME));
		        TRS.add_string(hist_item, "OINV_IN_TIME", MTIVLOTHIS.OINV_IN_TIME, sizeof(MTIVLOTHIS.OINV_IN_TIME));
		        TRS.add_string(hist_item, "OINV_OUT_TIME", MTIVLOTHIS.OINV_OUT_TIME, sizeof(MTIVLOTHIS.OINV_OUT_TIME));
		        TRS.add_string(hist_item, "WIP_IN_TIME", MTIVLOTHIS.WIP_IN_TIME, sizeof(MTIVLOTHIS.WIP_IN_TIME));
		        TRS.add_string(hist_item, "WIP_OUT_TIME", MTIVLOTHIS.WIP_OUT_TIME, sizeof(MTIVLOTHIS.WIP_OUT_TIME));
		        TRS.add_string(hist_item, "TRAN_CMF_1", MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
		        TRS.add_string(hist_item, "TRAN_CMF_2", MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2));
		        TRS.add_string(hist_item, "TRAN_CMF_3", MTIVLOTHIS.TRAN_CMF_3, sizeof(MTIVLOTHIS.TRAN_CMF_3));
		        TRS.add_string(hist_item, "TRAN_CMF_4", MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVLOTHIS.TRAN_CMF_4));
		        TRS.add_string(hist_item, "TRAN_CMF_5", MTIVLOTHIS.TRAN_CMF_5, sizeof(MTIVLOTHIS.TRAN_CMF_5));
		        TRS.add_string(hist_item, "TRAN_CMF_6", MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6));
		        TRS.add_string(hist_item, "TRAN_CMF_7", MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7));
		        TRS.add_string(hist_item, "TRAN_CMF_8", MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8));
		        TRS.add_string(hist_item, "TRAN_CMF_9", MTIVLOTHIS.TRAN_CMF_9, sizeof(MTIVLOTHIS.TRAN_CMF_9));
		        TRS.add_string(hist_item, "TRAN_CMF_10", MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10));
		        TRS.add_string(hist_item, "TRAN_CMF_11", MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11));
		        TRS.add_string(hist_item, "TRAN_CMF_12", MTIVLOTHIS.TRAN_CMF_12, sizeof(MTIVLOTHIS.TRAN_CMF_12));
		        TRS.add_string(hist_item, "TRAN_CMF_13", MTIVLOTHIS.TRAN_CMF_13, sizeof(MTIVLOTHIS.TRAN_CMF_13));
		        TRS.add_string(hist_item, "TRAN_CMF_14", MTIVLOTHIS.TRAN_CMF_14, sizeof(MTIVLOTHIS.TRAN_CMF_14));
		        TRS.add_string(hist_item, "TRAN_CMF_15", MTIVLOTHIS.TRAN_CMF_15, sizeof(MTIVLOTHIS.TRAN_CMF_15));
		        TRS.add_string(hist_item, "TRAN_CMF_16", MTIVLOTHIS.TRAN_CMF_16, sizeof(MTIVLOTHIS.TRAN_CMF_16));
		        TRS.add_string(hist_item, "TRAN_CMF_17", MTIVLOTHIS.TRAN_CMF_17, sizeof(MTIVLOTHIS.TRAN_CMF_17));
		        TRS.add_string(hist_item, "TRAN_CMF_18", MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18));
		        TRS.add_string(hist_item, "TRAN_CMF_19", MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19));
		        TRS.add_string(hist_item, "TRAN_CMF_20", MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20));

                DBC_init_mtivmatdef(&MTIVMATDEF);
                TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
                memcpy(MTIVMATDEF.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
				MTIVMATDEF.MAT_VER = MTIVLOTHIS.MAT_VER;
                DBC_select_mtivmatdef(1, &MTIVMATDEF);
                if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "INV-0004"); 
	    	        TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST); 
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                    TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                    TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
	    	        TRS.add_dberrmsg(out_node, DB_error_msg);

	    	        gs_log_type.type = MP_LOG_ERROR;
	    	        gs_log_type.e_type = MP_LOG_E_SYSTEM;
	    	        gs_log_type.category = MP_LOG_CATE_SETUP;

	    	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
	    	        return MP_FALSE; 
                }

                TRS.add_string(hist_item, "BASE_MAT_ID", MTIVMATDEF.BASE_MAT_ID, sizeof(MTIVMATDEF.BASE_MAT_ID));
                TRS.add_string(hist_item, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));


                if(TRS.get_procstep(in_node) == '4')
                {
                    if(memcmp(MTIVLOTHIS.TRAN_CODE, "DEFECT", strlen("DEFECT"))==0)
                    {
                        //Get Defect Code & Defect Qty
                        DBC_init_mtiviqchis(&MTIVIQCHIS);
                        TRS.copy(MTIVIQCHIS.FACTORY, sizeof(MTIVIQCHIS.FACTORY), in_node, IN_FACTORY);
                        MTIVIQCHIS.LOT_HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
                        memcpy(MTIVIQCHIS.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVIQCHIS.LOT_ID));
                        DBC_select_mtiviqchis(3, &MTIVIQCHIS);
                        if(DB_error_code == DB_SUCCESS)
                        {
                            TRS.add_int(hist_item, "SAMPLE_SIZE", MTIVIQCHIS.SAMPLE_SIZE);
                            TRS.add_double(hist_item, "TOTAL_DEF_QTY", MTIVIQCHIS.TOTAL_DEF_QTY);
                        }
                    }
                }
            }
        }
    }

    if(TRS.get_procstep(in_node)=='3')
    {
        DBC_init_mtivlothis(&MTIVLOTHIS);
        TRS.copy(MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "LOT_ID");
        TRS.copy(MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER), in_node, "OPER");
        MTIVLOTHIS.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");

	    DBC_select_mtivlothis(5, &MTIVLOTHIS); 
	    if(DB_error_code != DB_SUCCESS)
	    { 
	    	strcpy(s_msg_code, "INV-0004"); 
	    	TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST); 
	    	TRS.add_dberrmsg(out_node, DB_error_msg);

	    	gs_log_type.type = MP_LOG_ERROR;
	    	gs_log_type.e_type = MP_LOG_E_SYSTEM;
	    	gs_log_type.category = MP_LOG_CATE_SETUP;

	    	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
	    	return MP_FALSE; 
	    }
	    TRS.add_string(out_node, "FACTORY", MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY));
	    TRS.add_string(out_node, "LOT_ID", MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID));
	    TRS.add_int(out_node, "LOT_GRP_SEQ", MTIVLOTHIS.LOT_GRP_SEQ);
	    TRS.add_string(out_node, "TRAN_CODE", MTIVLOTHIS.TRAN_CODE, sizeof(MTIVLOTHIS.TRAN_CODE));
	    TRS.add_string(out_node, "TRAN_TYPE", MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE));
	    TRS.add_string(out_node, "TRAN_TIME", MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME));
	    TRS.add_string(out_node, "SYS_TRAN_TIME", MTIVLOTHIS.SYS_TRAN_TIME, sizeof(MTIVLOTHIS.SYS_TRAN_TIME));
	    TRS.add_string(out_node, "MAT_ID", MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID));
	    TRS.add_int(out_node, "MAT_VER", MTIVLOTHIS.MAT_VER);
	    TRS.add_string(out_node, "OPER", MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER));
	    TRS.add_char(out_node, "LOT_TYPE", MTIVLOTHIS.LOT_TYPE);

        //Current QTY - Old QTY 
        TRS.add_double(out_node, "QTY_1", MTIVLOTHIS.QTY_1 - MTIVLOTHIS.OLD_QTY_1);

	    TRS.add_double(out_node, "QTY_2", MTIVLOTHIS.QTY_2);
	    TRS.add_double(out_node, "QTY_3", MTIVLOTHIS.QTY_3);
	    TRS.add_double(out_node, "CREATE_QTY_1", MTIVLOTHIS.CREATE_QTY_1);
	    TRS.add_double(out_node, "CREATE_QTY_2", MTIVLOTHIS.CREATE_QTY_2);
	    TRS.add_double(out_node, "CREATE_QTY_3", MTIVLOTHIS.CREATE_QTY_3);
	    TRS.add_string(out_node, "CREATE_TIME", MTIVLOTHIS.CREATE_TIME, sizeof(MTIVLOTHIS.CREATE_TIME));
	    TRS.add_char(out_node, "IN_OUT_FLAG", MTIVLOTHIS.IN_OUT_FLAG);
	    TRS.add_string(out_node, "FROM_TO_LOT_ID", MTIVLOTHIS.FROM_TO_LOT_ID, sizeof(MTIVLOTHIS.FROM_TO_LOT_ID));
		TRS.add_int(out_node, "FROM_TO_HIST_SEQ", MTIVLOTHIS.FROM_TO_HIST_SEQ);
	    TRS.add_int(out_node, "FROM_TO_LOT_GRP_SEQ", MTIVLOTHIS.FROM_TO_LOT_GRP_SEQ);

	    TRS.add_char(out_node, "FROM_TO_FLAG", MTIVLOTHIS.FROM_TO_FLAG);
	    TRS.add_double(out_node, "FROM_TO_QTY_1", MTIVLOTHIS.FROM_TO_QTY_1);
	    TRS.add_double(out_node, "FROM_TO_QTY_2", MTIVLOTHIS.FROM_TO_QTY_2);
	    TRS.add_double(out_node, "FROM_TO_QTY_3", MTIVLOTHIS.FROM_TO_QTY_3);
	    TRS.add_string(out_node, "PROD_LOT_ID", MTIVLOTHIS.PROD_LOT_ID, sizeof(MTIVLOTHIS.PROD_LOT_ID));
	    TRS.add_int(out_node, "PROD_HIST_SEQ", MTIVLOTHIS.PROD_HIST_SEQ);
	    TRS.add_double(out_node, "PROD_QTY_1", MTIVLOTHIS.PROD_QTY_1);
	    TRS.add_double(out_node, "PROD_QTY_2", MTIVLOTHIS.PROD_QTY_2);
	    TRS.add_double(out_node, "PROD_QTY_3", MTIVLOTHIS.PROD_QTY_3);
	    TRS.add_string(out_node, "ORDER_ID", MTIVLOTHIS.ORDER_ID, sizeof(MTIVLOTHIS.ORDER_ID));
	    TRS.add_string(out_node, "LINE_NO", MTIVLOTHIS.LINE_NO, sizeof(MTIVLOTHIS.LINE_NO));
	    TRS.add_string(out_node, "OLD_FACTORY", MTIVLOTHIS.OLD_FACTORY, sizeof(MTIVLOTHIS.OLD_FACTORY));
	    TRS.add_string(out_node, "OLD_OPER", MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER));
	    TRS.add_double(out_node, "OLD_QTY_1", MTIVLOTHIS.OLD_QTY_1);
	    TRS.add_double(out_node, "OLD_QTY_2", MTIVLOTHIS.OLD_QTY_2);
	    TRS.add_double(out_node, "OLD_QTY_3", MTIVLOTHIS.OLD_QTY_3);
	    TRS.add_string(out_node, "UNIT_1", MTIVLOTHIS.UNIT_1, sizeof(MTIVLOTHIS.UNIT_1));
	    TRS.add_string(out_node, "UNIT_2", MTIVLOTHIS.UNIT_2, sizeof(MTIVLOTHIS.UNIT_2));
	    TRS.add_string(out_node, "UNIT_3", MTIVLOTHIS.UNIT_3, sizeof(MTIVLOTHIS.UNIT_3));
	    TRS.add_char(out_node, "INSPECTION_FLAG", MTIVLOTHIS.INSPECTION_FLAG);
	    TRS.add_char(out_node, "INSPECTION_RESULT", MTIVLOTHIS.INSPECTION_RESULT);
	    TRS.add_string(out_node, "TRAN_COMMENT", MTIVLOTHIS.TRAN_COMMENT, sizeof(MTIVLOTHIS.TRAN_COMMENT));
	    TRS.add_string(out_node, "TRAN_USER_ID", MTIVLOTHIS.TRAN_USER_ID, sizeof(MTIVLOTHIS.TRAN_USER_ID));
	    TRS.add_char(out_node, "LOT_DEL_FLAG", MTIVLOTHIS.LOT_DEL_FLAG);
	    TRS.add_string(out_node, "LOT_DEL_USER_ID", MTIVLOTHIS.LOT_DEL_USER_ID, sizeof(MTIVLOTHIS.LOT_DEL_USER_ID));
	    TRS.add_string(out_node, "LOT_DEL_TIME", MTIVLOTHIS.LOT_DEL_TIME, sizeof(MTIVLOTHIS.LOT_DEL_TIME));
	    TRS.add_string(out_node, "LOT_DEL_REASON", MTIVLOTHIS.LOT_DEL_REASON, sizeof(MTIVLOTHIS.LOT_DEL_REASON));
	    TRS.add_char(out_node, "HIST_DEL_FLAG", MTIVLOTHIS.HIST_DEL_FLAG);
	    TRS.add_string(out_node, "HIST_DEL_USER_ID", MTIVLOTHIS.HIST_DEL_USER_ID, sizeof(MTIVLOTHIS.HIST_DEL_USER_ID));
	    TRS.add_string(out_node, "HIST_DEL_TIME", MTIVLOTHIS.HIST_DEL_TIME, sizeof(MTIVLOTHIS.HIST_DEL_TIME));
	    TRS.add_string(out_node, "LOCATION_NO", MTIVLOTHIS.LOCATION_NO, sizeof(MTIVLOTHIS.LOCATION_NO));
	    TRS.add_char(out_node, "HOLD_FLAG", MTIVLOTHIS.HOLD_FLAG);
	    TRS.add_string(out_node, "HOLD_CODE", MTIVLOTHIS.HOLD_CODE, sizeof(MTIVLOTHIS.HOLD_CODE));
	    TRS.add_string(out_node, "RELEASE_CODE", MTIVLOTHIS.RELEASE_CODE, sizeof(MTIVLOTHIS.RELEASE_CODE));
	    TRS.add_char(out_node, "PICK_FLAG", MTIVLOTHIS.PICK_FLAG);
	    TRS.add_char(out_node, "SHIP_FLAG", MTIVLOTHIS.SHIP_FLAG);
	    TRS.add_string(out_node, "GRADE", MTIVLOTHIS.GRADE, sizeof(MTIVLOTHIS.GRADE));
	    TRS.add_string(out_node, "ADD_ORDER_ID_1", MTIVLOTHIS.ADD_ORDER_ID_1, sizeof(MTIVLOTHIS.ADD_ORDER_ID_1));
	    TRS.add_string(out_node, "ADD_ORDER_LINE_1", MTIVLOTHIS.ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_1));
	    TRS.add_string(out_node, "ADD_ORDER_ID_2", MTIVLOTHIS.ADD_ORDER_ID_2, sizeof(MTIVLOTHIS.ADD_ORDER_ID_2));
	    TRS.add_string(out_node, "ADD_ORDER_LINE_2", MTIVLOTHIS.ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_2));
	    TRS.add_string(out_node, "ADD_ORDER_ID_3", MTIVLOTHIS.ADD_ORDER_ID_3, sizeof(MTIVLOTHIS.ADD_ORDER_ID_3));
	    TRS.add_string(out_node, "ADD_ORDER_LINE_3", MTIVLOTHIS.ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS.ADD_ORDER_LINE_3));
	    TRS.add_string(out_node, "VENDOR_LOT_ID", MTIVLOTHIS.VENDOR_LOT_ID, sizeof(MTIVLOTHIS.VENDOR_LOT_ID));
	    TRS.add_string(out_node, "PO_MAT_ID", MTIVLOTHIS.PO_MAT_ID, sizeof(MTIVLOTHIS.PO_MAT_ID));
	    TRS.add_int(out_node, "PO_SEQ_NUM", MTIVLOTHIS.PO_SEQ_NUM);
	    TRS.add_string(out_node, "INV_CMF_1", MTIVLOTHIS.INV_CMF_1, sizeof(MTIVLOTHIS.INV_CMF_1));
	    TRS.add_string(out_node, "INV_CMF_2", MTIVLOTHIS.INV_CMF_2, sizeof(MTIVLOTHIS.INV_CMF_2));
	    TRS.add_string(out_node, "INV_CMF_3", MTIVLOTHIS.INV_CMF_3, sizeof(MTIVLOTHIS.INV_CMF_3));
	    TRS.add_string(out_node, "INV_CMF_4", MTIVLOTHIS.INV_CMF_4, sizeof(MTIVLOTHIS.INV_CMF_4));
	    TRS.add_string(out_node, "INV_CMF_5", MTIVLOTHIS.INV_CMF_5, sizeof(MTIVLOTHIS.INV_CMF_5));
	    TRS.add_string(out_node, "INV_CMF_6", MTIVLOTHIS.INV_CMF_6, sizeof(MTIVLOTHIS.INV_CMF_6));
	    TRS.add_string(out_node, "INV_CMF_7", MTIVLOTHIS.INV_CMF_7, sizeof(MTIVLOTHIS.INV_CMF_7));
	    TRS.add_string(out_node, "INV_CMF_8", MTIVLOTHIS.INV_CMF_8, sizeof(MTIVLOTHIS.INV_CMF_8));
	    TRS.add_string(out_node, "INV_CMF_9", MTIVLOTHIS.INV_CMF_9, sizeof(MTIVLOTHIS.INV_CMF_9));
	    TRS.add_string(out_node, "INV_CMF_10", MTIVLOTHIS.INV_CMF_10, sizeof(MTIVLOTHIS.INV_CMF_10));
	    TRS.add_string(out_node, "INV_CMF_11", MTIVLOTHIS.INV_CMF_11, sizeof(MTIVLOTHIS.INV_CMF_11));
	    TRS.add_string(out_node, "INV_CMF_12", MTIVLOTHIS.INV_CMF_12, sizeof(MTIVLOTHIS.INV_CMF_12));
	    TRS.add_string(out_node, "INV_CMF_13", MTIVLOTHIS.INV_CMF_13, sizeof(MTIVLOTHIS.INV_CMF_13));
	    TRS.add_string(out_node, "INV_CMF_14", MTIVLOTHIS.INV_CMF_14, sizeof(MTIVLOTHIS.INV_CMF_14));
	    TRS.add_string(out_node, "INV_CMF_15", MTIVLOTHIS.INV_CMF_15, sizeof(MTIVLOTHIS.INV_CMF_15));
	    TRS.add_string(out_node, "INV_CMF_16", MTIVLOTHIS.INV_CMF_16, sizeof(MTIVLOTHIS.INV_CMF_16));
	    TRS.add_string(out_node, "INV_CMF_17", MTIVLOTHIS.INV_CMF_17, sizeof(MTIVLOTHIS.INV_CMF_17));
	    TRS.add_string(out_node, "INV_CMF_18", MTIVLOTHIS.INV_CMF_18, sizeof(MTIVLOTHIS.INV_CMF_18));
	    TRS.add_string(out_node, "INV_CMF_19", MTIVLOTHIS.INV_CMF_19, sizeof(MTIVLOTHIS.INV_CMF_19));
	    TRS.add_string(out_node, "INV_CMF_20", MTIVLOTHIS.INV_CMF_20, sizeof(MTIVLOTHIS.INV_CMF_20));
	    TRS.add_string(out_node, "OWNER_CODE", MTIVLOTHIS.OWNER_CODE, sizeof(MTIVLOTHIS.OWNER_CODE));
	    TRS.add_string(out_node, "VENDOR_ID", MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID));
	    TRS.add_string(out_node, "FROM_TO_OPER", MTIVLOTHIS.FROM_TO_OPER, sizeof(MTIVLOTHIS.FROM_TO_OPER));
	    TRS.add_string(out_node, "OLD_LOCATION_NO", MTIVLOTHIS.OLD_LOCATION_NO, sizeof(MTIVLOTHIS.OLD_LOCATION_NO));
	    TRS.add_int(out_node, "HIST_SEQ", MTIVLOTHIS.HIST_SEQ);
	    TRS.add_string(out_node, "LOT_GROUP_ID", MTIVLOTHIS.LOT_GROUP_ID, sizeof(MTIVLOTHIS.LOT_GROUP_ID));
	    TRS.add_string(out_node, "EXPIRE_DATE", MTIVLOTHIS.EXPIRE_DATE, sizeof(MTIVLOTHIS.EXPIRE_DATE));
	    TRS.add_string(out_node, "INV_IN_TIME", MTIVLOTHIS.INV_IN_TIME, sizeof(MTIVLOTHIS.INV_IN_TIME));
	    TRS.add_string(out_node, "INV_OUT_TIME", MTIVLOTHIS.INV_OUT_TIME, sizeof(MTIVLOTHIS.INV_OUT_TIME));
	    TRS.add_string(out_node, "OINV_IN_TIME", MTIVLOTHIS.OINV_IN_TIME, sizeof(MTIVLOTHIS.OINV_IN_TIME));
	    TRS.add_string(out_node, "OINV_OUT_TIME", MTIVLOTHIS.OINV_OUT_TIME, sizeof(MTIVLOTHIS.OINV_OUT_TIME));
	    TRS.add_string(out_node, "WIP_IN_TIME", MTIVLOTHIS.WIP_IN_TIME, sizeof(MTIVLOTHIS.WIP_IN_TIME));
	    TRS.add_string(out_node, "WIP_OUT_TIME", MTIVLOTHIS.WIP_OUT_TIME, sizeof(MTIVLOTHIS.WIP_OUT_TIME));
	    TRS.add_string(out_node, "TRAN_CMF_1", MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
	    TRS.add_string(out_node, "TRAN_CMF_2", MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2));
	    TRS.add_string(out_node, "TRAN_CMF_3", MTIVLOTHIS.TRAN_CMF_3, sizeof(MTIVLOTHIS.TRAN_CMF_3));
	    TRS.add_string(out_node, "TRAN_CMF_4", MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVLOTHIS.TRAN_CMF_4));
	    TRS.add_string(out_node, "TRAN_CMF_5", MTIVLOTHIS.TRAN_CMF_5, sizeof(MTIVLOTHIS.TRAN_CMF_5));
	    TRS.add_string(out_node, "TRAN_CMF_6", MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6));
	    TRS.add_string(out_node, "TRAN_CMF_7", MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7));
	    TRS.add_string(out_node, "TRAN_CMF_8", MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8));
	    TRS.add_string(out_node, "TRAN_CMF_9", MTIVLOTHIS.TRAN_CMF_9, sizeof(MTIVLOTHIS.TRAN_CMF_9));
	    TRS.add_string(out_node, "TRAN_CMF_10", MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10));
	    TRS.add_string(out_node, "TRAN_CMF_11", MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11));
	    TRS.add_string(out_node, "TRAN_CMF_12", MTIVLOTHIS.TRAN_CMF_12, sizeof(MTIVLOTHIS.TRAN_CMF_12));
	    TRS.add_string(out_node, "TRAN_CMF_13", MTIVLOTHIS.TRAN_CMF_13, sizeof(MTIVLOTHIS.TRAN_CMF_13));
	    TRS.add_string(out_node, "TRAN_CMF_14", MTIVLOTHIS.TRAN_CMF_14, sizeof(MTIVLOTHIS.TRAN_CMF_14));
	    TRS.add_string(out_node, "TRAN_CMF_15", MTIVLOTHIS.TRAN_CMF_15, sizeof(MTIVLOTHIS.TRAN_CMF_15));
	    TRS.add_string(out_node, "TRAN_CMF_16", MTIVLOTHIS.TRAN_CMF_16, sizeof(MTIVLOTHIS.TRAN_CMF_16));
	    TRS.add_string(out_node, "TRAN_CMF_17", MTIVLOTHIS.TRAN_CMF_17, sizeof(MTIVLOTHIS.TRAN_CMF_17));
	    TRS.add_string(out_node, "TRAN_CMF_18", MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18));
	    TRS.add_string(out_node, "TRAN_CMF_19", MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19));
	    TRS.add_string(out_node, "TRAN_CMF_20", MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20));

        /*Get OPER Description*/
        DBC_init_mtivoprdef(&MTIVOPRDEF);
		TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MTIVOPRDEF.OPER, MTIVLOTHIS.OPER, sizeof(MTIVOPRDEF.OPER));
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
		TRS.add_string(out_node, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
	    TRS.add_string(out_node, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));

        /*Get Mat Info*/
        DBC_init_mtivmatdef(&MTIVMATDEF);
		TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MTIVMATDEF.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
		MTIVMATDEF.MAT_VER = MTIVLOTHIS.MAT_VER;
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
		TRS.add_string(out_node, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));
        TRS.add_string(out_node, "MAT_SHORT_DESC", MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC));
        TRS.add_string(out_node, "BASE_MAT_ID", MTIVMATDEF.BASE_MAT_ID, sizeof(MTIVMATDEF.BASE_MAT_ID));
        TRS.add_string(out_node, "MAT_TYPE", MTIVMATDEF.MAT_TYPE, sizeof(MTIVMATDEF.MAT_TYPE));

    }




    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_History_N",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Lot_History_N_Validation()
        - Validation Check sub function of "TIV_View_Lot_History_N" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_History_N_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123456") == MP_FALSE)
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
    /* Lot ID Validation */
    if(TRS.get_procstep(in_node)!='2' && TRS.get_char(in_node, "NO_LOT_VALIDATION")!='Y')
    {
        if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
        {
            strcpy(s_msg_code, "INV-0001");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
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