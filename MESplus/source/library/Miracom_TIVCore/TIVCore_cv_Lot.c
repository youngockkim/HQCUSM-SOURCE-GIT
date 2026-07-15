/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_cv_lot.c
    Description : Transaction Lot Material cv function module

    MES Version : 5.2.0

    Function List
        - TIV_CV_Lot()
            + Transaction Out Lot Material Inventory
        - TIV_CV_LOT()
            + Main Sub function of "TIV_CV_Lot"
            + (called by "TIV_CV_Lot")
        - TIV_CV_Lot_Validation()
            + Validation Check sub function of "TIV_CV_LOT" function
            + (called by "TIV_CV_Lot")
       
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/07/25  patrick         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"
 
    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
//#include "TIVCore_common.h"

double d_total_cv_qty_1;
double d_total_cv_qty_2;
double d_total_cv_qty_3;

int i_cv_count_1;
int i_cv_count_2;
int i_cv_count_3;

int TIV_CV_Lot_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node);

int TIV_CV_Lot_Proc_Out(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node);

int TIV_insert_cv_code_qty(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node,
                           char *s_unit_list_name,
                           struct MTIVLOTCVM_TAG *MTIVLOTCVM);

int TIV_check_cv_unit_value(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node,
                            char *s_unit_list_name,
                            double *d_total_cv_qty,
                            int *i_cv_count);

/*******************************************************************************
    TIV_CV_Lot()
        - Lot Material CV Inventory
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TIV_CV_Lot_In_Tag *TIV_CV_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_CV_Lot(TRSNode *in_node, 
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_CV_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_CV_LOT", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    TIV_CV_LOT()
        - Main sub function of "TIV_CV_Lot" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_CV_LOT_IN_TAG *Out_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_CV_LOT(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node)

{    
	//struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MATRNAMSTS_TAG MATRNAMSTS;
	//struct MTIVMATDEF_TAG MTIVMATDEF;
	//struct MWIPMATDEF_TAG MWIPMATDEF;

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
	//struct MTAPRESMLT_TAG MTAPRESMLT;

	//TRSNode *assign_in;
	//TRSNode *assign_mat_in;
	//TRSNode *transfer_lot_in;

	//int i_mat_ver=0;
	int b_no_cv=MP_FALSE;
	//double d_count=0;
	
	//int is;
	//int ist;

    LOG_head("TIV_CV_LOT");
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_CV_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    TRS.add_char(in_node, "__INSERT_OR_UPDATE", ' ');
	
	if(TRS.get_char(in_node, "DETTACH_FROM_RES")=='Y')
	{
		/*assign_in = TRS.create_node("ASSGIN_IN");
		TRS.init_node(assign_in);
		TRS.set_char(assign_in, IN_PROCSTEP, MP_STEP_DELETE);
		TRS.set_nstring(assign_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
		TRS.set_nstring(assign_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
		TRS.set_nstring(assign_in, "RES_ID", TRS.get_string(in_node, "RES_ID"));
		TRS.set_nstring(assign_in, "OPER", TRS.get_string(in_node, "OPER"));
		assign_mat_in = TRS.add_node(assign_in, "MAT_LIST");
		TRS.set_nstring(assign_mat_in, "MAT_LOT_ID", TRS.get_string(in_node, "LOT_ID"));
		TRS.set_nstring(assign_mat_in, "MAT_ID", TRS.get_string(in_node, "MAT_ID"));
		TRS.set_nstring(assign_mat_in, "OPER", TRS.get_string(in_node, "OPER"));

		if(TAP_ASSIGN_MATERIAL_TO_RESOURCE(s_msg_code, assign_in, out_node)==MP_FALSE)
			return MP_FALSE;

		TRS.free_node(assign_in);

		if(TRS.get_char(in_node, "DETTACH_ONLY")=='Y')
		{
			 COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}

		DBC_init_mtapresmlt(&MTAPRESMLT);
		TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID), in_node, "LOT_ID");
		d_count=DBC_select_mtapresmlt_scalar(2, &MTAPRESMLT);

		if(d_count > 0)
			b_no_cv=MP_TRUE;*/
	}
	
	//DBC_init_mtivlotsts(&MTIVLOTSTS);
	//TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
	//TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");	
	//TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
	//DBC_select_mtivlotsts(4, &MTIVLOTSTS);
	//if(DB_error_code != DB_SUCCESS)
	//{
	//	if(DB_error_code == DB_NOT_FOUND)
	//	{
	//		strcpy(s_msg_code, "WIP-0044");
	//		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
	//	}
	//	else
	//	{
	//		strcpy(s_msg_code, "WIP-0004");
	//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//		TRS.add_dberrmsg(out_node, DB_error_msg);
	//	}
	//	TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
	//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
	//	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);				

	//	gs_log_type.type = MP_LOG_ERROR;
	//	gs_log_type.category = MP_LOG_CATE_TRANS;
	//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//	return MP_FALSE;
	//}

	//if(b_no_cv==MP_FALSE && MTIVLOTSTS.QTY_1!=TRS.get_double(in_node, "OUT_QTY"))
	if(b_no_cv==MP_FALSE)
	{
		/*if(TRS.get_char(in_node,"RETURN_FLAG") == 'Y')
		{
			DBC_init_mtivlotsts(&MTIVLOTSTS);
			TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
			TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
			DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS);
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
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			MTIVLOTSTS.LOT_DEL_FLAG='Y';
			DBC_update_mtivlotsts(3, &MTIVLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "INV-0004");
				TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "EXPIRE_DATE", MP_STR, sizeof(MTIVLOTSTS.EXPIRE_DATE), MTIVLOTSTS.EXPIRE_DATE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_COMMON;
				return MP_FALSE;
			}
		}*/

		/*' Validation Check*/

		if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
		{
			TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
		}

		if(TIV_CV_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if(TIV_CV_Lot_Proc_Out(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
    
		TRS.set_char(in_node, "CV_LOT", 'Y');
	}


	//if(TRS.get_char(in_node, "TRANSFER_AFTER_CV")=='Y')
	//{
	//	DBC_init_mtivlotsts(&MTIVLOTSTS);
	//	TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
	//	TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
	//	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
	//	DBC_select_mtivlotsts(4, &MTIVLOTSTS);
	//	if(DB_error_code != DB_SUCCESS)
	//	{
	//		if(DB_error_code == DB_NOT_FOUND)
	//		{
	//			strcpy(s_msg_code, "WIP-0044");
	//			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
	//		}
	//		else
	//		{
	//			strcpy(s_msg_code, "WIP-0004");
	//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//			TRS.add_dberrmsg(out_node, DB_error_msg);
	//		}
	//		TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
	//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
	//		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);				

	//		gs_log_type.type = MP_LOG_ERROR;
	//		gs_log_type.category = MP_LOG_CATE_TRANS;
	//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		return MP_FALSE;
	//	}

	//	DBC_init_mwipmatdef(&MWIPMATDEF);
 //       memcpy(MWIPMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
 //       memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
 //       MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
 //       DBC_select_mwipmatdef(1, &MWIPMATDEF);
 //       if(DB_error_code != DB_SUCCESS) 
 //       {
 //           if(DB_error_code == DB_NOT_FOUND)
 //           {
 //               strcpy(s_msg_code, "INV-0006");
 //               gs_log_type.e_type = MP_LOG_E_EXISTENCE;
 //           }
 //           else 
 //           {
 //               strcpy(s_msg_code, "INV-0004");            
 //               gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //           }
 //           TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
 //           TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
 //           TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);

 //           gs_log_type.type = MP_LOG_ERROR;
 //           gs_log_type.category = MP_LOG_CATE_TRANS;
 //           return MP_FALSE;
 //       }


	//	transfer_lot_in = TRS.create_node("TRANSFER_LOT");
 //               
	//	TRS.add_char(transfer_lot_in, IN_PROCSTEP, TRS.get_procstep(in_node));
	//	TRS.add_enc_nstring(transfer_lot_in, IN_USERID, TRS.get_userid(in_node));
	//	TRS.add_enc_nstring(transfer_lot_in, IN_PASSWORD, TRS.get_password(in_node));
	//	TRS.add_char(transfer_lot_in, IN_LANGUAGE, TRS.get_language(in_node));
	//	TRS.add_nstring(transfer_lot_in, IN_FACTORY, TRS.get_factory(in_node));

	//	TRS.set_string(transfer_lot_in, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
 //       TRS.set_string(transfer_lot_in, "FROM_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
	//	TRS.set_string(transfer_lot_in, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
 //       TRS.set_string(transfer_lot_in, "TIV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	//	TRS.set_string(transfer_lot_in, "TIV_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	//	TRS.set_int(transfer_lot_in, "TIV_MAT_VER", MTIVLOTSTS.MAT_VER);			
	//	TRS.set_nstring(transfer_lot_in, "TO_OPER", TRS.get_string(in_node, "RETURN_OPER"));
	//	TRS.set_nstring(transfer_lot_in, "TO_LOCATION_NO", TRS.get_string(in_node, "RETURN_LOCATION_NO"));		
	//	TRS.set_nstring(transfer_lot_in, "TRAN_CODE", "TRANSFER"); 
	//	TRS.set_nstring(transfer_lot_in, "TRAN_TYPE", "MAT_TRN"); 
	//	TRS.set_nstring(transfer_lot_in, "TRAN_COMMNET", TRS.get_string(in_node, "TRAN_COMMENT"));
	//	//TRS.set_string(transfer_lot_in, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
	//	TRS.add_int(transfer_lot_in, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
 //       TRS.set_double(transfer_lot_in, "MOVE_QTY_1",  TRS.get_double(in_node, "OUT_QTY"));
	//	TRS.add_nstring(transfer_lot_in, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_1", TRS.get_string(in_node, "INV_CMF_1"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_2", TRS.get_string(in_node, "INV_CMF_2"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_3", TRS.get_string(in_node, "INV_CMF_3"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_4", TRS.get_string(in_node, "INV_CMF_4"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_5", TRS.get_string(in_node, "INV_CMF_5"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_6", TRS.get_string(in_node, "INV_CMF_6"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_7", TRS.get_string(in_node, "INV_CMF_7"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_8", TRS.get_string(in_node, "INV_CMF_8"));
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_9", TRS.get_string(in_node, "INV_CMF_9"));
	//	//TRS.add_string(transfer_lot_in, "INV_CMF_10", MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO));	
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_11", TRS.get_string(in_node, "INV_CMF_11"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_12", TRS.get_string(in_node, "INV_CMF_12"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_13", TRS.get_string(in_node, "INV_CMF_13"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_14", TRS.get_string(in_node, "INV_CMF_14"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_15", TRS.get_string(in_node, "INV_CMF_15"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_16", TRS.get_string(in_node, "INV_CMF_16"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_17", TRS.get_string(in_node, "INV_CMF_17"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_18", TRS.get_string(in_node, "INV_CMF_18"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_19", TRS.get_string(in_node, "INV_CMF_19"));				
	//	TRS.add_nstring(transfer_lot_in, "INV_CMF_20", TRS.get_string(in_node, "INV_CMF_20"));		

 //    //   /*LotGroup*/
 //    //   DBC_init_matrnamsts(&MATRNAMSTS);
	//    //TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	//    //memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_MATERIAL, sizeof(MATRNAMSTS.ATTR_TYPE));
	//    //memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_TIV_LOT_GROUP, strlen(MP_ATTR_TIV_LOT_GROUP));
 //    //   memcpy(MATRNAMSTS.ATTR_KEY, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
 //    //   i_mat_ver = MTIVMATDEF.MAT_VER;
 //    //   memcpy(MATRNAMSTS.ATTR_KEY + COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))," : ", 3);
 //    //   MATRNAMSTS.ATTR_KEY[COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))+1]=i_mat_ver + 48;
 //    //   DBC_select_matrnamsts(1, &MATRNAMSTS);
 //    //   if(DB_error_code == DB_SUCCESS)
 //    //   {
 //    //       TRS.add_string(transfer_lot_in, "LOT_GROUP_FLAG", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));
 //    //   }

	//	if(TIV_TRANSFER_LOT(s_msg_code, transfer_lot_in, out_node) == MP_FALSE)
	//	{
	//		TRS.free_node(transfer_lot_in);
	//		return MP_FALSE;
	//	}
	//	TRS.free_node(transfer_lot_in);
	//}

    if(COM_proc_user_routine("MES_UserTIV", "TIV_CV_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;    

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_CV_Lot_Proc_Out()
        - Validation Check sub function of "TIV_CV_LOT" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_CV_LOT_IN_TAG *Out_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_CV_Lot_Proc_Out(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
	struct MTIVLOTCVH_TAG MTIVLOTCVH;
	struct MTIVLOTCVM_TAG MTIVLOTCVM;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	//struct MGCMTBLDAT_TAG MGCMTBLDAT;

    int i;    
    int i_lot_count;
	int i_step;	 
	int i_last_active_hist_seq;

	int b_only_one_live_inv_lot = MP_FALSE;
	 
    char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];
	 
    TRSNode**    inv_lot_list;
	TRSNode**    inv_cv_list;

	TRSNode * tran_in_node;
	TRSNode * create_lot_list;
	TRSNode * Create_INV_Lot_In;
	TRSNode * tiv_lot_list;

	TRSNode * IF_node;

    memset(s_erp_tran_time, ' ', sizeof(s_erp_tran_time));
	memset(s_tran_time, ' ', sizeof(s_tran_time));
	memset(s_sys_time, ' ', sizeof(s_sys_time));

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        
        return MP_FALSE;
    }

	
	b_only_one_live_inv_lot = TIV_Check_Factory(s_msg_code, "MP_OnlyOneLiveINVLot", TRS.get_string(in_node, IN_FACTORY));
	 
	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");
	 
	//list
    i_lot_count = TRS.get_item_count(in_node, "TIV_LOT_LIST");
    inv_lot_list = TRS.get_list(in_node, "TIV_LOT_LIST");
       
    TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U');

    for(i=0; i< i_lot_count; i++)
    { 
		d_total_cv_qty_1 = 0;
		d_total_cv_qty_2 = 0;
		d_total_cv_qty_3 = 0;

		i_cv_count_1 = 0;
		i_cv_count_2 = 0;
		i_cv_count_3 = 0;		
        
        /*material exist*/
		DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPMATDEF.MAT_ID, TRS.get_string(inv_lot_list[i], "TIV_MAT_ID") , sizeof(MWIPMATDEF.MAT_ID));
        MWIPMATDEF.MAT_VER = TRS.get_int(inv_lot_list[i], "TIV_MAT_VER"); 
        DBC_select_mwipmatdef(1, &MWIPMATDEF);
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

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_COMMON;
			
            return MP_FALSE;
        }    

		//UNIT을 넣음에 따라 UNIT1,2,3적용
		if(COM_isspace(MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1)) == MP_FALSE)
		{
            TRS.set_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_factory(in_node));
			if(TIV_check_cv_unit_value(s_msg_code,
									   inv_lot_list[i],
									   out_node,
									   "UNIT1",
									   &d_total_cv_qty_1,
									   &i_cv_count_1) == MP_FALSE)
			{
				
				return MP_FALSE;
			}
		}

		if(COM_isspace(MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2)) == MP_FALSE)
		{
            TRS.set_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_factory(in_node));
			if(TIV_check_cv_unit_value(s_msg_code,
									   inv_lot_list[i],
									   out_node,
									   "UNIT2",
									   &d_total_cv_qty_2,
									   &i_cv_count_2) == MP_FALSE)
			{
				
				return MP_FALSE;
			}
		}

		if(COM_isspace(MWIPMATDEF.UNIT_3, sizeof(MWIPMATDEF.UNIT_3)) == MP_FALSE)
		{
            TRS.set_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_factory(in_node));
			if(TIV_check_cv_unit_value(s_msg_code,
									   inv_lot_list[i],
									   out_node,
									   "UNIT3",
									   &d_total_cv_qty_3,
									   &i_cv_count_3) == MP_FALSE)
			{
				
				return MP_FALSE;
			}
		}

        DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
        TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);        
        TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), inv_lot_list[i], "TIV_LOT_ID");
		TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), inv_lot_list[i], "TIV_OPER");

        DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_OLD);
        if(DB_error_code != DB_SUCCESS)
        {
			//해당 랏이 없을 경우 LOT생성
            if(DB_error_code == DB_NOT_FOUND)
            {   
				tran_in_node = TRS.create_node("CREATE_INV_LOT_ID");
				TRS.add_char(tran_in_node, IN_PROCSTEP, '1');
		        COM_Set_In_Node(in_node, tran_in_node);

                TRS.set_string(tran_in_node, "FROM_OPER", MP_INV_OPER_REPAIR, sizeof(MP_INV_OPER_REPAIR));
                TRS.set_string(tran_in_node, "TO_OPER", MP_INV_OPER_REPAIR, sizeof(MP_INV_OPER_REPAIR));
				
				create_lot_list = TRS.add_node(tran_in_node, "TIV_LOT_LIST");
		        TRS.set_nstring(create_lot_list, "LOT_ID",  TRS.get_string(inv_lot_list[i], "INV_LOT_ID"));
				TRS.set_nstring(create_lot_list, "INV_LOT_ID",  TRS.get_string(inv_lot_list[i], "INV_LOT_ID"));
				TRS.set_nstring(create_lot_list, "TIV_LOT_ID",  TRS.get_string(inv_lot_list[i], "INV_LOT_ID"));								
                TRS.set_string(create_lot_list, "TIV_OPER", MP_INV_OPER_REPAIR, sizeof(MP_INV_OPER_REPAIR));
                TRS.set_string(create_lot_list, "FROM_OPER", MP_INV_OPER_REPAIR, sizeof(MP_INV_OPER_REPAIR));
                TRS.set_string(create_lot_list, "TO_OPER", MP_INV_OPER_REPAIR, sizeof(MP_INV_OPER_REPAIR));
                TRS.set_nstring(create_lot_list, "MAT_ID",  TRS.get_string(inv_lot_list[i], "TIV_MAT_ID"));
		        TRS.set_double(create_lot_list, "IN_QTY", TRS.get_double(inv_lot_list[i], "OUT_QTY"));
                TRS.set_int(create_lot_list, "MAT_VER", 1);
				TRS.set_string(create_lot_list, "CREATE_CODE", MP_DTR_WIP_LOT_CREATE_CODE_PROD, sizeof(MP_DTR_WIP_LOT_CREATE_CODE_PROD));
                TRS.set_string(create_lot_list, "OWNER_CODE", MP_DTR_WIP_LOT_CREATE_CODE_PROD, sizeof(MP_DTR_WIP_LOT_CREATE_CODE_PROD));
                TRS.set_char(create_lot_list, "IN_OUT_FLAG", '1');
                TRS.set_char(create_lot_list, "LOT_TYPE", MP_LOT_TYPE_PROD);
                TRS.set_string(create_lot_list, "LAST_TRAN_TYPE", MP_INV_TRAN_TYPE_MAT_IN, sizeof(MP_INV_TRAN_TYPE_MAT_IN));                
                TRS.set_string(create_lot_list, "EXPIRE_DATE", "99981231235959", sizeof("99981231235959"));

			    if(TIV_CREATE_MATERIAL_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
			    {			
				    TRS.free_node(tran_in_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				    return MP_FALSE;
			    }
				TRS.free_node(tran_in_node);

				return MP_TRUE;
            }
            else 
            {
                strcpy(s_msg_code, "INV-0004");            
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);            
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
			
				return MP_FALSE;
            }
        }   

		/* Back Time Check */
		if(TIV_check_backtime(s_msg_code,
								in_node,
								out_node,
								MTIVLOTSTS_OLD.LAST_TRAN_TIME) == MP_FALSE)
		{
			
			return MP_FALSE;        
		} 

        if(TRS.get_char(in_node, "REBIRTH_LOT") != 'Y')
        {
            if(MTIVLOTSTS_OLD.LOT_DEL_FLAG == 'Y')
            {
                strcpy(s_msg_code, "WIP-0076");
                TRS.add_fieldmsg(out_node, "LOT_DEL_FLAG", MP_CHR, MTIVLOTSTS_OLD.LOT_DEL_FLAG);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
				
                return MP_FALSE;
            }
        }
		else
		{
			if (b_only_one_live_inv_lot == MP_TRUE)
			{
				if (TIV_Get_Lot_Count_In_Other_Oper(s_msg_code, MTIVLOTSTS_OLD.FACTORY, MTIVLOTSTS_OLD.LOT_ID, MTIVLOTSTS_OLD.OPER) > 0)
				{
					strcpy(s_msg_code, "WIP-0724");             
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);            
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					return MP_FALSE;
				}
			}
		}
        
        if(MTIVLOTSTS_OLD.HOLD_FLAG == 'Y')
        {
            strcpy(s_msg_code, "WIP-0059");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }

        memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));          
        
		
		i_step = 10; //104를 새로 만들었으나 그냥 10 사용 
		i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS);


        memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_TIV_TRAN_CODE_CV, strlen(MP_TIV_TRAN_CODE_CV));
        TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), inv_lot_list[i], "TRAN_TYPE");
        memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
        TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), inv_lot_list[i], "TIV_LOT_COMMENT");

		memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));
		
		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "ORDER_ID")) == MP_FALSE)
			TRS.copy(MTIVLOTSTS.ORDER_ID,  sizeof(MTIVLOTSTS.ORDER_ID), inv_lot_list[i], "ORDER_ID");

		MTIVLOTSTS.QTY_1 += d_total_cv_qty_1;
		MTIVLOTSTS.QTY_2 += d_total_cv_qty_2;
		MTIVLOTSTS.QTY_3 += d_total_cv_qty_3;        
        
        TRS.set_double(in_node, "TOTAL_CV_QTY_1",d_total_cv_qty_1);
        TRS.set_double(in_node, "TOTAL_CV_QTY_2",d_total_cv_qty_2);
        TRS.set_double(in_node, "TOTAL_CV_QTY_3",d_total_cv_qty_3);

        memset(MTIVLOTSTS.FROM_TO_LOT_ID, ' ', sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
		MTIVLOTSTS.FROM_TO_HIST_SEQ = 0;
        MTIVLOTSTS.FROM_TO_FLAG = ' ';

       /* 2018.04.23 JWLEE 
        * 증평 셀은 ERP에서 재고 정보가 넘어오지 않으므로 Validation 하지 않음
        */
        if(memcmp(MWIPMATDEF.MAT_GRP_1,"PS",strlen("PS")) == 0)
        {
        }
        else
        {
            if(MTIVLOTSTS.QTY_1 < 0.0005 && MTIVLOTSTS.QTY_2 < 0.0005)
            {
			    MTIVLOTSTS.QTY_1 = 0;

			    if(TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT") != 'Y')
			    {
				    MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
				    TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, "PRC_USER");
				    memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
				    memcpy(MTIVLOTSTS.LOT_DEL_REASON, MP_WIP_AUTO_TERMINATE_CODE, strlen(MP_WIP_AUTO_TERMINATE_CODE));
			    }
            }
        }             
    
		/*if(MTIVLOTSTS.QTY_1 < 0 || MTIVLOTSTS.QTY_2 < 0 )
			MTIVLOTSTS.IN_OUT_FLAG = 'I';
		else
			MTIVLOTSTS.IN_OUT_FLAG = 'O';*/

		if (d_total_cv_qty_1 > 0)
			MTIVLOTSTS.IN_OUT_FLAG = 'I';
		else
			MTIVLOTSTS.IN_OUT_FLAG = 'O';

		MTIVLOTSTS.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
        //MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
		MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;        
    
        if(TRS.get_char(in_node, "REBIRTH_LOT") == 'Y' && MTIVLOTSTS.QTY_1 > 0.0005)
        {
            MTIVLOTSTS.LOT_DEL_FLAG = ' ';
            memset(MTIVLOTSTS.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
            memset(MTIVLOTSTS.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS.LOT_DEL_TIME));
            memset(MTIVLOTSTS.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS.LOT_DEL_REASON));
        }

		TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");

        DBC_init_mtivlothis(&MTIVLOTHIS);
		
		COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, fabs(d_total_cv_qty_1), sizeof(MTIVLOTHIS.TRAN_CMF_3));
		COM_dtoa(MTIVLOTHIS.TRAN_CMF_2, fabs(d_total_cv_qty_2), sizeof(MTIVLOTHIS.TRAN_CMF_4));
		COM_dtoa(MTIVLOTHIS.TRAN_CMF_3, fabs(d_total_cv_qty_3), sizeof(MTIVLOTHIS.TRAN_CMF_5));
	 
		TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");
		 
		inv_cv_list = TRS.get_list(inv_lot_list[i], "UNIT1");
		if(TRS.get_item_count(inv_lot_list[i], "UNIT1")>0)
		{
			TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), inv_cv_list[0], "CODE");

			/*DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_TBL_INV_CV_CODE, strlen(MP_GCM_TBL_INV_CV_CODE));
			TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), inv_cv_list[0], "CODE");
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				memcpy(MTIVLOTHIS.TRAN_CMF_7, MGCMTBLDAT.DATA_1, sizeof(MTIVLOTHIS.TRAN_CMF_7));
			}*/
		}

        if(TIV_update_insert_lot_status_history_2(s_msg_code, 
                                                in_node,
                                                out_node,
                                                s_sys_time,
                                                &MTIVLOTSTS_OLD,
                                                &MTIVLOTSTS,
                                                &MTIVLOTHIS) == MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		/* CV Table Insert */
		DBC_init_mtivlotcvh(&MTIVLOTCVH);
		memcpy(MTIVLOTCVH.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTCVH.LOT_ID));
		MTIVLOTCVH.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;

		memcpy(MTIVLOTCVH.TRAN_TIME, MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTCVH.TRAN_TIME));
		MTIVLOTCVH.HIST_DEL_FLAG = MTIVLOTHIS.HIST_DEL_FLAG;

		memcpy(MTIVLOTCVH.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVLOTCVH.FACTORY));
		memcpy(MTIVLOTCVH.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTCVH.MAT_ID));
		MTIVLOTCVH.MAT_VER = MTIVLOTHIS.MAT_VER;		
		memcpy(MTIVLOTCVH.OPER, MTIVLOTHIS.OPER, sizeof(MTIVLOTCVH.OPER));		

		if(i_cv_count_1 > 0)
		{
			MTIVLOTCVH.QTY_FLAG = '1';
			MTIVLOTCVH.NEW_QTY = MTIVLOTSTS.QTY_1;
			MTIVLOTCVH.OLD_QTY = MTIVLOTSTS_OLD.QTY_1;
			MTIVLOTCVH.TOTAL_CV_QTY = d_total_cv_qty_1;

			TRS.copy(MTIVLOTCVH.CV_COMMENT_1, sizeof(MTIVLOTCVH.CV_COMMENT_1), in_node, "CV_COMMENT");

			DBC_insert_mtivlotcvh(&MTIVLOTCVH);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVLOTCVH INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTCVH.LOT_ID), MTIVLOTCVH.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		if(i_cv_count_2 > 0)
		{
			MTIVLOTCVH.QTY_FLAG = '2';
			MTIVLOTCVH.NEW_QTY = MTIVLOTSTS.QTY_2;
			MTIVLOTCVH.OLD_QTY = MTIVLOTSTS_OLD.QTY_2;
			MTIVLOTCVH.TOTAL_CV_QTY = d_total_cv_qty_2;

			TRS.copy(MTIVLOTCVH.CV_COMMENT_1, sizeof(MTIVLOTCVH.CV_COMMENT_1), in_node, "CV_COMMENT");

			DBC_insert_mtivlotcvh(&MTIVLOTCVH);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVLOTCVH INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTCVH.LOT_ID), MTIVLOTCVH.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		if(i_cv_count_3 > 0)
		{
			MTIVLOTCVH.QTY_FLAG = '3';
			MTIVLOTCVH.NEW_QTY = MTIVLOTSTS.QTY_3;
			MTIVLOTCVH.OLD_QTY = MTIVLOTSTS_OLD.QTY_3;
			MTIVLOTCVH.TOTAL_CV_QTY = d_total_cv_qty_3;

			TRS.copy(MTIVLOTCVH.CV_COMMENT_1, sizeof(MTIVLOTCVH.CV_COMMENT_1), in_node, "CV_COMMENT");

			DBC_insert_mtivlotcvh(&MTIVLOTCVH);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVLOTCVH INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTCVH.LOT_ID), MTIVLOTCVH.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}


		DBC_init_mtivlotcvm(&MTIVLOTCVM);
		memcpy(MTIVLOTCVM.LOT_ID, MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTCVM.LOT_ID));
		MTIVLOTCVM.HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
		memcpy(MTIVLOTCVM.TRAN_TIME, MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTCVM.TRAN_TIME));

		memcpy(MTIVLOTCVM.FACTORY, MTIVLOTHIS.FACTORY, sizeof(MTIVLOTCVM.FACTORY));
		memcpy(MTIVLOTCVM.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTCVM.MAT_ID));
		MTIVLOTCVM.MAT_VER = MTIVLOTHIS.MAT_VER;		
		memcpy(MTIVLOTCVM.OPER, MTIVLOTHIS.OPER, sizeof(MTIVLOTCVM.OPER));		

		if(i_cv_count_1 > 0)
		{
			MTIVLOTCVM.QTY_FLAG = '1';
			MTIVLOTCVM.SEQ_NUM = 0;

			if(TIV_insert_cv_code_qty(s_msg_code,
									  inv_lot_list[i],
									  out_node,
									  "UNIT1",
									  &MTIVLOTCVM) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		if(i_cv_count_2 > 0)
		{
			MTIVLOTCVM.QTY_FLAG = '2';
			MTIVLOTCVM.SEQ_NUM = 0;

			if(TIV_insert_cv_code_qty(s_msg_code,
									  inv_lot_list[i],
									  out_node,
									  "UNIT2",
									  &MTIVLOTCVM) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		if(i_cv_count_3 > 0)
		{
			MTIVLOTCVM.QTY_FLAG = '3';
			MTIVLOTCVM.SEQ_NUM = 0;

			if(TIV_insert_cv_code_qty(s_msg_code,
									  inv_lot_list[i],
									  out_node,
									  "UNIT3",
									  &MTIVLOTCVM) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		if (TRS.get_char(in_node, "CREATE_ADJUST_LOT_FLAG") == 'Y')
		{
			// 실적등록에서 자동으로 수량보정이 발생하는 경우 증가 수량만큼의 보정 Lot을 생성

			Create_INV_Lot_In = TRS.create_node("CREATE_INV_LOT_ID");
			TRS.add_char(Create_INV_Lot_In, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(Create_INV_Lot_In, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(Create_INV_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(Create_INV_Lot_In, IN_FACTORY, TRS.get_factory(in_node));
			
			TRS.add_nstring(Create_INV_Lot_In, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));

			if (COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_FALSE)
			{
				TRS.add_nstring(Create_INV_Lot_In, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
			}		
			TRS.add_nstring(Create_INV_Lot_In, "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
			TRS.add_nstring(Create_INV_Lot_In, "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
			TRS.add_nstring(Create_INV_Lot_In, "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
			TRS.add_nstring(Create_INV_Lot_In, "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
			TRS.add_nstring(Create_INV_Lot_In, "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
			TRS.add_char(Create_INV_Lot_In, "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));		
			TRS.add_char(Create_INV_Lot_In, "__GET_TIME_INFO_FLAG", 'Y');


			TRS.set_char(Create_INV_Lot_In, "IN_STOCK_FLAG", 'Y');
	  
			tiv_lot_list = TRS.add_node(Create_INV_Lot_In, "TIV_LOT_LIST");
			TRS.set_char(tiv_lot_list, "CREATE_ADJ_LOT_FLAG", 'Y');
	
			TRS.set_string(tiv_lot_list, "CREATE_CODE", MP_DTR_WIP_LOT_CREATE_CODE_PROD, strlen(MP_DTR_WIP_LOT_CREATE_CODE_PROD));
			TRS.set_string(tiv_lot_list, "OWNER_CODE", MP_DTR_WIP_LOT_CREATE_CODE_PROD, strlen(MP_DTR_WIP_LOT_CREATE_CODE_PROD));
			TRS.set_char(tiv_lot_list, "LOT_TYPE", MP_TIV_LOT_TYPE_ADJUST);
				 
			TRS.set_string(tiv_lot_list, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
			TRS.set_int(tiv_lot_list, "MAT_VER", MTIVLOTSTS.MAT_VER);
			TRS.set_string(tiv_lot_list, "TRAN_TYPE", "MAT_IN", strlen("MAT_IN"));
  
			TRS.set_string(tiv_lot_list, "TIV_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.set_string(tiv_lot_list, "FROM_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.set_string(tiv_lot_list, "TO_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
 
			TRS.set_double(tiv_lot_list, "IN_QTY", d_total_cv_qty_1 * -1);
			TRS.set_nstring(tiv_lot_list, "VENDOR_ID", TRS.get_factory(in_node));
			 
			if(TIV_CREATE_MATERIAL_LOT(s_msg_code, Create_INV_Lot_In, out_node) == MP_FALSE)
			{			
				TRS.free_node(Create_INV_Lot_In);
				return MP_FALSE;
			}
			TRS.free_node(Create_INV_Lot_In);

		}

		if (TRS.get_char(in_node, "SKIP_IF_INFO_FLAG") != 'Y' && 
			COM_isnullspace(TRS.get_string(in_node, "MVT_CODE")) == MP_FALSE &&
			TRS.get_char(in_node, "CREATE_ADJUST_LOT_FLAG") != 'Y')
		{
			IF_node = TRS.create_node("INTERFACE_IN");
			TRS.add_char(IF_node, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(IF_node, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(IF_node, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(IF_node, IN_FACTORY, TRS.get_factory(in_node));
					
			TRS.add_nstring(IF_node, "WERKS", TRS.get_factory(in_node));
			TRS.add_nstring(IF_node, "WERKS1", TRS.get_factory(in_node));
			TRS.add_nstring(IF_node, "BUDAT", TRS.get_string(in_node, "WORK_DATE"));				 
			//TRS.add_nstring(IF_node, "AUFNR", TRS.get_string(in_node, "ORDER_ID"));	
			TRS.add_nstring(IF_node, "BWART", TRS.get_string(in_node, "MVT_CODE"));
	
			TRS.add_string(IF_node, "MATNR", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
			TRS.add_string(IF_node, "MATNR1", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));

			TRS.add_string(IF_node, "LGORT", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.add_string(IF_node, "LGORT1", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			//i_last_if_seq++; ?????
			//TRS.add_int(IF_node, "SEQNO", i_last_if_seq);
	 
			/*if (TRS.get_char(in_node, "MVT_PM") == 'P')
				TRS.add_double(IF_node, "MENGE", d_total_cv_qty_1);
			else
				TRS.add_double(IF_node, "MENGE", -1 * d_total_cv_qty_1);*/

			//if (TRS.get_char(in_node, "MVT_IN_OUT_FLAG") == 
			TRS.add_double(IF_node, "MENGE", d_total_cv_qty_1);
			TRS.add_string(IF_node, "ERNAM", "MES", strlen("MES"));
			TRS.add_string(IF_node, "ERDAT", s_sys_time, 8);
			TRS.add_string(IF_node, "ERZET", s_sys_time + 8, 6);
				
			TRS.add_string(IF_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));

			TRS.add_string(IF_node, "MEINS", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
			TRS.add_string(IF_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.add_int(IF_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

			TRS.add_int(IF_node, "MAT_VER", MTIVLOTSTS.MAT_VER);

			TRS.add_char(IF_node, "ERP_IN_OUT_FLAG", TRS.get_char(in_node, "MVT_IN_OUT_FLAG"));


			//if (CUS_MES_To_ERP_Move(s_msg_code, IF_node, out_node) == MP_FALSE)
			//{
			//	TRS.free_node(IF_node);
			//	return MP_FALSE;
			//}
			TRS.free_node(IF_node);

		}

		if (TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG") == 'Y')
		{			
			//TRS.set_nstring(in_node, "LOT_ID", TRS.get_string(inv_lot_list[i], "TIV_LOT_ID"));		
			//TRS.set_nstring(in_node, "OPER", TRS.get_string(inv_lot_list[i], "TIV_OPER"));
			//TRS.set_nstring(in_node, "MAT_ID", TRS.get_string(inv_lot_list[i], "TIV_MAT_ID"));
			//TRS.set_int(in_node, "MAT_VER", TRS.get_int(inv_lot_list[i], "TIV_MAT_VER"));

			///*TRS.set_nstring(in_node, "TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
			//TRS.set_nstring(in_node, "CREATE_TIME", TRS.get_string(in_node, "__SYS_TIME"));
			//TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
			//TRS.set_string(in_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));*/

			//if (d_total_cv_qty_1 > 0)
			//	TRS.set_char(in_node, "IN_OUT_FLAG", 'I');
			//else
			//	TRS.set_char(in_node, "IN_OUT_FLAG", 'O');
 
			//TRS.set_double(in_node, "ADJUST_QTY_1",  fabs(d_total_cv_qty_1));
			//TRS.set_int(in_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
			//if (TIV_Create_Inventory_Adjust_Info(s_msg_code, in_node, out_node) == MP_FALSE)
			//{
			//	return MP_FALSE;
			//}
		}

    }
   
    return MP_TRUE;
}

/*******************************************************************************
    TIV_CV_Lot_Validation()
        - Validation Check sub function of "TIV_CV_LOT" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_CV_LOT_IN_TAG *Out_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_CV_Lot_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;   
    //struct MTIVMATDEF_TAG MTIVMATDEF;
	//struct MWIPMATDEF_TAG MWIPMATDEF;
	//struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MTIVERPORD_TAG MTIVERPORD;
	int i_lot_count;    

	
    TRSNode**    inv_lot_list;

    int i;
    
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Proc Step validation */
    if(COM_check_value(s_msg_code,
                       in_node,
                       out_node,
                       IN_PROCSTEP,
                       'Y',
                       ' ',
                       0x00,
                       0x00,
                       0x00) == MP_FALSE)
    {
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
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
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	i_lot_count = TRS.get_item_count(in_node, "TIV_LOT_LIST");
    inv_lot_list = TRS.get_list(in_node, "TIV_LOT_LIST");
        
    for(i=0; i< i_lot_count; i++)
    {                
		inv_lot_list = TRS.get_list(in_node, "TIV_LOT_LIST");

        if(COM_isnullspace(TRS.get_string(inv_lot_list[i], "TIV_LOT_ID")) == MP_TRUE)
        {
            strcpy(s_msg_code, "INV-0001");
            TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }

        if(COM_isnullspace(TRS.get_string(inv_lot_list[i], "TRAN_TYPE")) == MP_TRUE)
        {
            strcpy(s_msg_code, "INV-0001");
            TRS.add_fieldmsg(out_node, "TRAN_TYPE", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }

		//d_total_cv_qty_1 = 0;
		//d_total_cv_qty_2 = 0;
		//d_total_cv_qty_3 = 0;

		//i_cv_count_1 = 0;
		//i_cv_count_2 = 0;
		//i_cv_count_3 = 0;		
  //      
  //      /*material exist*/
		//DBC_init_mwipmatdef(&MWIPMATDEF);
  //      TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
  //      memcpy(MWIPMATDEF.MAT_ID, TRS.get_string(inv_lot_list[i], "TIV_MAT_ID") , sizeof(MWIPMATDEF.MAT_ID));
  //      MWIPMATDEF.MAT_VER = TRS.get_int(inv_lot_list[i], "TIV_MAT_VER"); 
  //      DBC_select_mwipmatdef(1, &MWIPMATDEF);
  //      if(DB_error_code != DB_SUCCESS) 
  //      {
  //          if(DB_error_code == DB_NOT_FOUND)
  //          {
  //              strcpy(s_msg_code, "WIP-0006");
  //              gs_log_type.e_type = MP_LOG_E_EXISTENCE;
  //          }
  //          else
  //          {
  //              strcpy(s_msg_code, "WIP-0004");
  //              gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //              TRS.add_dberrmsg(out_node, DB_error_msg);
  //          }
  //          TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
  //          TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
  //          TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
  //          TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.category = MP_LOG_CATE_COMMON;
  //          return MP_FALSE;
  //      }    

		////UNIT을 넣음에 따라 UNIT1,2,3적용
		//if(COM_isspace(MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1)) == MP_FALSE)
		//{
  //          TRS.set_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_factory(in_node));
		//	if(TIV_check_cv_unit_value(s_msg_code,
		//							   inv_lot_list[i],
		//							   out_node,
		//							   "UNIT1",
		//							   &d_total_cv_qty_1,
		//							   &i_cv_count_1) == MP_FALSE)
		//	{
		//		return MP_FALSE;
		//	}
		//}

		//if(COM_isspace(MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2)) == MP_FALSE)
		//{
  //          TRS.set_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_factory(in_node));
		//	if(TIV_check_cv_unit_value(s_msg_code,
		//							   inv_lot_list[i],
		//							   out_node,
		//							   "UNIT2",
		//							   &d_total_cv_qty_2,
		//							   &i_cv_count_2) == MP_FALSE)
		//	{
		//		return MP_FALSE;
		//	}
		//}

		//if(COM_isspace(MWIPMATDEF.UNIT_3, sizeof(MWIPMATDEF.UNIT_3)) == MP_FALSE)
		//{
  //          TRS.set_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_factory(in_node));
		//	if(TIV_check_cv_unit_value(s_msg_code,
		//							   inv_lot_list[i],
		//							   out_node,
		//							   "UNIT3",
		//							   &d_total_cv_qty_3,
		//							   &i_cv_count_3) == MP_FALSE)
		//	{
		//		return MP_FALSE;
		//	}
		//}
 
    }   
   
    return MP_TRUE;
}

/*******************************************************************************
    TIV_check_cv_unit_value()
        - Check unit value before CV Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_insert_cv_code_qty(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node,
                           char *s_unit_list_name,
                           struct MTIVLOTCVM_TAG *MTIVLOTCVM)
{
    int i;
    int i_item_count;
    TRSNode **cv_items;

    char *s_cv_code;
    double d_cv_qty;

    i_item_count = TRS.get_item_count(in_node, s_unit_list_name);
    if(i_item_count > 0)
    {
        cv_items = TRS.get_list(in_node, s_unit_list_name);
        for(i = 0; i < i_item_count; i++)
        {
            s_cv_code = TRS.get_string(cv_items[i], "CODE");
            d_cv_qty = TRS.get_double(cv_items[i], "QTY");

            if(COM_isnullspace(s_cv_code) == MP_FALSE && d_cv_qty != 0)
            {
                MTIVLOTCVM->SEQ_NUM ++;
                memset(MTIVLOTCVM->CV_CODE, ' ', sizeof(MTIVLOTCVM->CV_CODE));
                memcpy(MTIVLOTCVM->CV_CODE, s_cv_code, strlen(s_cv_code));
                MTIVLOTCVM->CV_QTY = d_cv_qty;

                DBC_insert_mtivlotcvm(MTIVLOTCVM);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MTIVLOTCVM INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTCVM->LOT_ID), MTIVLOTCVM->LOT_ID);
                    TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTCVM->HIST_SEQ);
                    TRS.add_fieldmsg(out_node, "QTY_FLAG", MP_CHR, MTIVLOTCVM->QTY_FLAG);
                    TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, MTIVLOTCVM->SEQ_NUM);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_TRANS;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }//endif COM_isnullspace(s_cv_code) == MP_FALSE && d_cv_qty != 0
        }//endfor
    }//endif i_item_count > 0

    return MP_TRUE;
}

/*******************************************************************************
    TIV_check_cv_unit_value()
        - Check unit value before CV Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_cv_unit_value(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node,
                            char *s_unit_list_name,
                            double *d_total_cv_qty,
                            int *i_cv_count)
{
    int i;
    int i_item_count;
    TRSNode **cv_items;

    char *s_cv_code;
    char *s_cv_code_next;
    double d_cv_qty;
    int j;

    i_item_count = TRS.get_item_count(in_node, s_unit_list_name);
    if(i_item_count > 0)
    {
        cv_items = TRS.get_list(in_node, s_unit_list_name);
        for(i = 0; i < i_item_count; i++)
        {
            s_cv_code = TRS.get_string(cv_items[i], "CODE");
            d_cv_qty = TRS.get_double(cv_items[i], "QTY");

            if(COM_isnullspace(s_cv_code) == MP_FALSE && d_cv_qty != 0)
            {
                if(COM_check_gcm_data(s_msg_code, 
                                      out_node,
                                      MP_GCM_TBL_INV_CV_CODE,
                                      TRS.get_factory(in_node),
                                      s_cv_code,
                                      (int)strlen(s_cv_code)) == MP_FALSE)
                {
                    return MP_FALSE;
                }

                for (j = i + 1; j < i_item_count; j++)
                {
                    s_cv_code_next = TRS.get_string(cv_items[j], "CODE");

                    if(COM_isnullspace(s_cv_code_next) == MP_FALSE)
                    {
                        if(strcmp(s_cv_code_next, s_cv_code) == 0)
                        {
                            strcpy(s_msg_code, "WIP-0430");
                            TRS.add_fieldmsg(out_node, "CV_UNIT", MP_NSTR, s_unit_list_name);
                            TRS.add_fieldmsg(out_node, "CV_CODE_1", MP_NSTR, s_cv_code);
                            TRS.add_fieldmsg(out_node, "CV_CODE_2", MP_NSTR, s_cv_code_next);

                            gs_log_type.type = MP_LOG_ERROR;
                            gs_log_type.e_type = MP_LOG_E_VALIDATION;
                            gs_log_type.category = MP_LOG_CATE_TRANS;
                            return MP_FALSE;
                        }
                    }
                }

                *d_total_cv_qty += d_cv_qty;
                *i_cv_count += 1;

            }//endif COM_isnullspace(s_cv_code) == MP_FALSE && d_cv_qty != 0
        }//endfor
    }//endif i_item_count > 0

    return MP_TRUE;
}