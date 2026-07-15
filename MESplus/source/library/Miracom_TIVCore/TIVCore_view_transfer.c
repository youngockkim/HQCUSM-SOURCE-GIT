/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_transfer.c
    Description : View Inventory Request Information related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Transfer()
            + View Inventory Lot Transfer Information
        - TIV_VIEW_TRANSFER()
            + Main Sub function of "TIV_View_Transfer"
            + (called by "TIV_View_Transfer")
        - TIV_View_Request_Validation()
            + Validation Check sub function of "TIV_VIEW_TRANSFER" function
            + (called by "TIV_VIEW_TRANSFER")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/25  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Transfer_Validation(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);


/*******************************************************************************
    TIV_View_Transfer()
        - View Inventory Transfer Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Transfer(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_TRANSFER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_TRANSFER", out_node);

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
    TIV_VIEW_TRANSFER()
        - Main sub function of "TIV_View_Transfer" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_TRANSFER(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node)
{
    struct MTIVTRSMST_TAG MTIVTRSMST;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MTIVTRSLOT_TAG MTIVTRSLOT;

	//struct MBOMSETMAT_TAG MBOMSETMAT;

    TRSNode *list_item;
	int i_step;

    LOG_head("TIV_View_Transfer");
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(TIV_View_Transfer_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivtrsmst(&MTIVTRSMST);
    TRS.copy(MTIVTRSMST.FACTORY , sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
    
    DBC_select_mtivtrsmst(1, &MTIVTRSMST);

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

        TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
        TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_enc_string(out_node, "CREATE_USER_ID", MTIVTRSMST.CREATE_USER_ID, sizeof(MTIVTRSMST.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MTIVTRSMST.CREATE_TIME, sizeof(MTIVTRSMST.CREATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MTIVTRSMST.UPDATE_USER_ID, sizeof(MTIVTRSMST.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MTIVTRSMST.UPDATE_TIME, sizeof(MTIVTRSMST.UPDATE_TIME));
    TRS.add_string(out_node, "FACTORY", MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY));
    TRS.add_string(out_node, "TRS_NO", MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO));
    TRS.add_string(out_node, "TRS_USER", MTIVTRSMST.TRS_USER, sizeof(MTIVTRSMST.TRS_USER));
    TRS.add_string(out_node, "INV_USER", MTIVTRSMST.INV_USER, sizeof(MTIVTRSMST.INV_USER));
    TRS.add_string(out_node, "TRS_DATE_TIME", MTIVTRSMST.TRS_DATE_TIME, sizeof(MTIVTRSMST.TRS_DATE_TIME));
    TRS.add_char(out_node, "TRS_PRIORITY", MTIVTRSMST.TRS_PRIORITY);
    TRS.add_char(out_node, "STATUS_FLAG", MTIVTRSMST.STATUS_FLAG);
    TRS.add_string(out_node, "TRS_COMMENT", MTIVTRSMST.TRS_COMMENT, sizeof(MTIVTRSMST.TRS_COMMENT));
    TRS.add_string(out_node, "TRS_CMF_1", MTIVTRSMST.TRS_CMF_1, sizeof(MTIVTRSMST.TRS_CMF_1));
    TRS.add_string(out_node, "TRS_CMF_2", MTIVTRSMST.TRS_CMF_2, sizeof(MTIVTRSMST.TRS_CMF_2));
    TRS.add_string(out_node, "TRS_CMF_3", MTIVTRSMST.TRS_CMF_3, sizeof(MTIVTRSMST.TRS_CMF_3));
    TRS.add_string(out_node, "TRS_CMF_4", MTIVTRSMST.TRS_CMF_4, sizeof(MTIVTRSMST.TRS_CMF_4));
    TRS.add_string(out_node, "TRS_CMF_5", MTIVTRSMST.TRS_CMF_5, sizeof(MTIVTRSMST.TRS_CMF_5));
    TRS.add_string(out_node, "TRS_CMF_6", MTIVTRSMST.TRS_CMF_6, sizeof(MTIVTRSMST.TRS_CMF_6));
    TRS.add_string(out_node, "TRS_CMF_7", MTIVTRSMST.TRS_CMF_7, sizeof(MTIVTRSMST.TRS_CMF_7));
    TRS.add_string(out_node, "TRS_CMF_8", MTIVTRSMST.TRS_CMF_8, sizeof(MTIVTRSMST.TRS_CMF_8));
    TRS.add_string(out_node, "TRS_CMF_9", MTIVTRSMST.TRS_CMF_9, sizeof(MTIVTRSMST.TRS_CMF_9));
    TRS.add_string(out_node, "TRS_CMF_10", MTIVTRSMST.TRS_CMF_10, sizeof(MTIVTRSMST.TRS_CMF_10));
    TRS.add_string(out_node, "DELETE_TIME", MTIVTRSMST.DELETE_TIME, sizeof(MTIVTRSMST.DELETE_TIME));
    TRS.add_enc_string(out_node, "DELETE_USER_ID", MTIVTRSMST.DELETE_USER_ID, sizeof(MTIVTRSMST.DELETE_USER_ID));
	TRS.add_char(out_node, "DOC_TYPE", MTIVTRSMST.DOC_TYPE);
	TRS.add_char(out_node, "INV_FLAG", MTIVTRSMST.INV_FLAG);
	TRS.add_char(out_node, "OSP_FLAG", MTIVTRSMST.OSP_FLAG);
	TRS.add_char(out_node, "RT_FLAG", MTIVTRSMST.RT_FLAG);
	TRS.add_enc_string(out_node, "RT_REASON", MTIVTRSMST.RT_REASON, sizeof(MTIVTRSMST.RT_REASON));

    DBC_init_mtivtrsdtl(&MTIVTRSDTL);
    TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
    DBC_open_mtivtrsdtl(1, &MTIVTRSDTL);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVREQDTL OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
        TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
		TRS.add_fieldmsg(out_node, "STATUS_FLAG", MP_CHR, MTIVTRSDTL.STATUS_FLAG);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mtivtrsdtl(1, &MTIVTRSDTL);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mtivtrsdtl(1);
            break;
        }


        list_item = TRS.add_node(out_node, "REQ_LIST");

        TRS.add_enc_string(list_item, "CREATE_USER_ID", MTIVTRSDTL.CREATE_USER_ID, sizeof(MTIVTRSDTL.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", MTIVTRSDTL.CREATE_TIME, sizeof(MTIVTRSDTL.CREATE_TIME));
        TRS.add_enc_string(list_item, "UPDATE_USER_ID", MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", MTIVTRSDTL.UPDATE_TIME, sizeof(MTIVTRSDTL.UPDATE_TIME));
        TRS.add_string(list_item, "FACTORY", MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY));
        TRS.add_string(list_item, "TRS_NO", MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO));
        TRS.add_int(list_item, "TRS_SEQ", MTIVTRSDTL.TRS_SEQ);
        TRS.add_string(list_item, "LOT_ID", MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID));
        TRS.add_string(list_item, "TRS_TYPE", MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE));
        TRS.add_string(list_item, "TRS_CODE", MTIVTRSDTL.TRS_CODE, sizeof(MTIVTRSDTL.TRS_CODE));
        TRS.add_char(list_item, "STATUS_FLAG", MTIVTRSDTL.STATUS_FLAG);    
        TRS.add_string(list_item, "TRS_CMF_1", MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVTRSDTL.TRS_CMF_1));
        TRS.add_string(list_item, "TRS_CMF_2", MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVTRSDTL.TRS_CMF_2));
        TRS.add_string(list_item, "TRS_CMF_3", MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3));
        TRS.add_string(list_item, "TRS_CMF_4", MTIVTRSDTL.TRS_CMF_4, sizeof(MTIVTRSDTL.TRS_CMF_4));
        TRS.add_string(list_item, "TRS_CMF_5", MTIVTRSDTL.TRS_CMF_5, sizeof(MTIVTRSDTL.TRS_CMF_5));
        TRS.add_string(list_item, "TRS_CMF_6", MTIVTRSDTL.TRS_CMF_6, sizeof(MTIVTRSDTL.TRS_CMF_6));
        TRS.add_string(list_item, "TRS_CMF_7", MTIVTRSDTL.TRS_CMF_7, sizeof(MTIVTRSDTL.TRS_CMF_7));
        TRS.add_string(list_item, "TRS_CMF_8", MTIVTRSDTL.TRS_CMF_8, sizeof(MTIVTRSDTL.TRS_CMF_8));
        TRS.add_string(list_item, "TRS_CMF_9", MTIVTRSDTL.TRS_CMF_9, sizeof(MTIVTRSDTL.TRS_CMF_9));
        TRS.add_string(list_item, "TRS_CMF_10", MTIVTRSDTL.TRS_CMF_10, sizeof(MTIVTRSDTL.TRS_CMF_10));
        TRS.add_string(list_item, "DELETE_TIME", MTIVTRSDTL.DELETE_TIME, sizeof(MTIVTRSDTL.DELETE_TIME));
        TRS.add_enc_string(list_item, "DELETE_USER_ID", MTIVTRSDTL.DELETE_USER_ID, sizeof(MTIVTRSDTL.DELETE_USER_ID));
        TRS.add_double(list_item, "REQ_QTY", MTIVTRSDTL.REQ_QTY);
         

		TRS.add_char(list_item, "DOC_TYPE", MTIVTRSDTL.DOC_TYPE);
		TRS.add_string(list_item, "MAT_ID", MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID));
        TRS.add_int(list_item, "MAT_VER", MTIVTRSDTL.MAT_VER);
		TRS.add_double(list_item, "REMAIN_QTY", MTIVTRSDTL.REMAIN_QTY);
		TRS.add_string(list_item, "UNIT_1", MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSDTL.UNIT_1));
		TRS.add_string(list_item, "UNIT_2", MTIVTRSDTL.UNIT_2, sizeof(MTIVTRSDTL.UNIT_2));
		TRS.add_string(list_item, "UNIT_3", MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3));
		TRS.add_double(list_item, "QTY_1", MTIVTRSDTL.QTY_1);
		TRS.add_double(list_item, "QTY_2", MTIVTRSDTL.QTY_2);
		TRS.add_double(list_item, "QTY_3", MTIVTRSDTL.QTY_3);

		TRS.add_string(list_item, "FROM_LOCATION_NO", MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSDTL.FROM_LOCATION_NO));
        TRS.add_string(list_item, "TO_LOCATION_NO", MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO));

        TRS.add_double(list_item, "BOM_QTY", MTIVTRSDTL.BOM_QTY);

		if (MTIVTRSDTL.DOC_TYPE == MP_TIV_DOC_TYPE_BY_LOT)
		{
			DBC_init_mtivlotsts(&MTIVLOTSTS);
			memcpy(MTIVLOTSTS.FACTORY, MTIVTRSDTL.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
			memcpy(MTIVLOTSTS.LOT_ID, MTIVTRSDTL.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			DBC_select_mtivlotsts(1, &MTIVLOTSTS);
        
			TRS.add_int(list_item, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

			if (TRS.get_char(in_node, "SUB_STEP") == '1')
			{
				DBC_init_mtivtrslot(&MTIVTRSLOT);
				TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
				TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
				MTIVTRSLOT.ASSIGN_TYPE = MP_TIV_TRS_ASSIGN_TYPE_TRANSFER;
				memcpy(MTIVTRSLOT.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
				//memcpy(MTIVTRSLOT.OPER, MTIVLOTSTS.OPER, sizeof(MTIVTRSLOT.OPER));
			 
				i_step = 2;
				DBC_select_mtivtrslot(i_step, &MTIVTRSLOT);			
				if(DB_error_code != DB_SUCCESS) 
				{
					if (DB_error_code == DB_NOT_FOUND)
					{
						TRS.add_char(list_item, "TRANSFER_FLAG", 'N');
					}
					else
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSLOT OPEN", MP_NVST);        
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
						TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
						TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}				
				}
				else
				{
					TRS.add_char(list_item, "TRANSFER_FLAG", 'Y');
					TRS.add_double(list_item, "TRANSFER_QTY", MTIVTRSLOT.ASSIGN_QTY);
				}				
			}
		}
        
        DBC_init_mwipmatdef(&MWIPMATDEF);
        memcpy(MWIPMATDEF.FACTORY, MTIVTRSDTL.FACTORY, sizeof(MWIPMATDEF.FACTORY));
        memcpy(MWIPMATDEF.MAT_ID, MTIVTRSDTL.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
        MWIPMATDEF.MAT_VER = MTIVTRSDTL.MAT_VER;
        DBC_select_mwipmatdef(1, &MWIPMATDEF);

        TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
        TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
        TRS.set_string(list_item, "PACK_UNIT_1", MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1));
        TRS.set_string(list_item, "PACK_UNIT_2", MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2));
        TRS.set_string(list_item, "PACK_UNIT_3", MWIPMATDEF.UNIT_3, sizeof(MWIPMATDEF.UNIT_3));
        TRS.set_double(list_item, "DEF_QTY_1", MWIPMATDEF.DEF_QTY_1);
        TRS.set_double(list_item, "DEF_QTY_2", MWIPMATDEF.DEF_QTY_2);
        TRS.set_double(list_item, "DEF_QTY_3", MWIPMATDEF.DEF_QTY_3);

		TRS.set_double(list_item, "PACK_QTY", MWIPMATDEF.PACK_QTY);

			//TRS.add_string(list_item, "FROM_OPER", MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER));
        
		if (MTIVTRSMST.RT_FLAG == 'Y')
		{
			TRS.add_string(list_item, "FROM_OPER", MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER));

			if (COM_isnullspace(MWIPMATDEF.MAT_CMF_2) == MP_FALSE)
				TRS.add_string(list_item, "TO_OPER", MWIPMATDEF.MAT_CMF_2, sizeof(MWIPMATDEF.MAT_CMF_2));
			else
				TRS.add_string(list_item, "TO_OPER", MWIPMATDEF.MAT_CMF_12, sizeof(MWIPMATDEF.MAT_CMF_12));
		}
		else
		{
			if (COM_isnullspace(MWIPMATDEF.MAT_CMF_2) == MP_FALSE)
				TRS.add_string(list_item, "FROM_OPER", MWIPMATDEF.MAT_CMF_2, sizeof(MWIPMATDEF.MAT_CMF_2));
			else
				TRS.add_string(list_item, "FROM_OPER", MWIPMATDEF.MAT_CMF_12, sizeof(MWIPMATDEF.MAT_CMF_12));

			TRS.add_string(list_item, "TO_OPER", MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER));
		}
		
    }

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Transfer_Validation()
        - Validation Check sub function of "TIV_VIEW_TRANSFER" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Transfer_Validation(char *s_msg_code,
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
    /* Transfer No Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "TRS_NO")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TRS_NO", MP_NVST);

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