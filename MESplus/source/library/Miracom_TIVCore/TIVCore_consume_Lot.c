/*******************************************************************************

		System      : MESplus
		Module      : TIVCore
		File Name   : TIVCore_consume_Lot.c
		Description : Transaction Lot Material cv function module

		MES Version : 5.2.0

		Function List
		- TIV_Consume_Lot()
		+ Transaction Out Lot Material Inventory
		- TIV_CONSUME_LOT()
		+ Main Sub function of "TIV_Consume_Lot"
		+ (called by "TIV_Consume_Lot")
		- TIV_Consume_Lot_Validation()
		+ Validation Check sub function of "TIV_CONSUME_LOT" function
		+ (called by "TIV_Consume_Lot")

		Detail Description
		- 

		History
		Seq   Date        Developer      Description                        
		---------------------------------------------------------------------------
		1     2014/09/25  HBLee         Create        

		Copyright(C) 1998-2014 Miracom,Inc.
		All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"
 

double d_total_consume_qty_1;
double d_total_consume_qty_2;
double d_total_consume_qty_3;

int i_consume_count_1;
int i_consume_count_2;
int i_consume_count_3;

int TIV_Consume_Lot_Validation(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node);

int TIV_Consume_Lot_Proc_Out(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node);

int TIV_insert_consume_code_qty(char *s_msg_code,
	TRSNode *in_node,
	TRSNode *out_node,
	char *s_unit_list_name,
struct MTIVLOTCVM_TAG *MTIVLOTCVM);

int TIV_check_consume_unit_value(char *s_msg_code,
	TRSNode *in_node,
	TRSNode *out_node,
	char *s_unit_list_name,
	double *d_total_consume_qty,
	int *i_consume_count);

/*******************************************************************************
TIV_Consume_Lot()
- Lot Material Consume Inventory
Return Value
- int : 0 (MP_TRUE)
Arguments
- TIV_Consume_Lot_In_Tag *TIV_Consume_Lot_In : Input Message structure
- Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Consume_Lot(TRSNode *in_node, 
	TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TIV_CONSUME_LOT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "TIV_CONSUME_LOT", out_node);

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
TIV_CONSUME_LOT()
- Main sub function of "TIV_Consume_Lot" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TIV_CONSUME_LOT_IN_TAG *Out_Lot_In : Input Message structure
- Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_CONSUME_LOT(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node)

{    
	struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MATRNAMSTS_TAG MATRNAMSTS;
	//struct MTIVMATDEF_TAG MTIVMATDEF;
	//struct MWIPMATDEF_TAG MWIPMATDEF;
	//struct MWIPLOTSTS_TAG MWIPLOTSTS;

	//int b_no_cv=MP_FALSE;
	 
	LOG_head("TIV_CONSUME_LOT");
	COM_log_add_field_msg(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(COM_proc_user_routine("MES_UserTIV", "TIV_Consume_Lot",
		MP_UPOINT_BEFORE,
		in_node,
		out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

	TRS.add_char(in_node, "__INSERT_OR_UPDATE", ' ');

	DBC_init_mtivlotsts(&MTIVLOTSTS);
	TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "TIV_LOT_ID");	
	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TIV_OPER");
	DBC_select_mtivlotsts(4, &MTIVLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0044");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}
		TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);				

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	//기본 정보 IN_NODE에 담는다.
	TRS.set_string(in_node, "TIV_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	TRS.set_int(in_node, "TIV_MAT_VER", MTIVLOTSTS.MAT_VER);

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}

	/*' Validation Check*/
	if(TIV_Consume_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	if(TIV_Consume_Lot_Proc_Out(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	TRS.set_char(in_node, "CONSUME_LOT", 'Y');

	if(COM_proc_user_routine("MES_UserTIV", "TIV_Consume_Lot",
		MP_UPOINT_AFTER,
		in_node,
		out_node) == MP_FALSE)     return MP_FALSE;
	//if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;    

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
TIV_Consume_Lot_Proc_Out()
- Validation Check sub function of "TIV_CONSUME_LOT" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TIV_CONSUME_LOT_IN_TAG *Out_Lot_In : Input Message structure
- Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Consume_Lot_Proc_Out(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node)
{
	struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
	struct MTIVLOTHIS_TAG MTIVLOTHIS;

	//int i;    
	double d_ConsumeQty = 0;
	
	char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];
	 
	int i_last_active_hist_seq;
	int i_step;

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
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
 
	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");
	
	TRS.set_string(in_node, "__TRAN_TIME", s_tran_time, sizeof(s_tran_time));
	TRS.set_string(in_node, "__SYS_TIME", s_sys_time, sizeof(s_sys_time));
	 
	TRS.set_char(in_node, "__INSERT_OR_UPDATE", 'U');

	DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
	TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);        
	TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");
	TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "TIV_OPER");
	DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_OLD);
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
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);            
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	 /* Back Time Check */
  /*  if(TIV_check_backtime(s_msg_code,
                            in_node,
                            out_node,
                            MTIVLOTSTS_OLD.LAST_TRAN_TIME) == MP_FALSE)
    {
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;        
    } */


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

	memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_TIV_TRAN_CODE_CONSUME, strlen(MP_TIV_TRAN_CODE_CONSUME));
	TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
	
	TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TIV_LOT_COMMENT");
	 
	d_ConsumeQty = TRS.get_double(in_node, "CONSUME_QTY");

	if(d_ConsumeQty > 0)
	{
		MTIVLOTSTS.QTY_1 -= d_ConsumeQty;

		MTIVLOTSTS.QTY_1 = COM_dbl_round(MTIVLOTSTS.QTY_1, 3, 'U');
		//MTIVLOTSTS.QTY_2 += d_total_consume_qty_2;
		//MTIVLOTSTS.QTY_3 += d_total_consume_qty_3;        
	}
	else
	{
		strcpy(s_msg_code, "INV-0004"); //메시지 등록하자 ( 소진 수량이 0보다 작습니다. )
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		TRS.add_fieldmsg(out_node, "Check Consume Qty", MP_NVST);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	
	TRS.set_double(in_node, "TOTAL_CONSUME_QTY_1", d_ConsumeQty);

	memset(MTIVLOTSTS.FROM_TO_LOT_ID, ' ', sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
	MTIVLOTSTS.FROM_TO_HIST_SEQ = 0;
	MTIVLOTSTS.FROM_TO_FLAG = ' ';

	if(MTIVLOTSTS.QTY_1 < 0.0005 && MTIVLOTSTS.QTY_2 < 0.0005)
	{
		if(TRS.get_char(in_node, "NO_AUTOMATIC_TERMINATE_LOT") != 'Y')
		{
			MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
			TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, "PRC_USER");
			memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
			memcpy(MTIVLOTSTS.LOT_DEL_REASON, MP_WIP_AUTO_TERMINATE_CODE, strlen(MP_WIP_AUTO_TERMINATE_CODE));
		}
	}             

	MTIVLOTSTS.IN_OUT_FLAG = 'O';
	/*if(MTIVLOTSTS.QTY_1 < 0 || MTIVLOTSTS.QTY_2 < 0 )
		MTIVLOTSTS.IN_OUT_FLAG = 'I';
	else
		MTIVLOTSTS.IN_OUT_FLAG = 'O';*/

	i_step = 10;
	i_last_active_hist_seq = (int)DBC_select_mtivlotsts_scalar(i_step, &MTIVLOTSTS);

	/*MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;*/
	MTIVLOTSTS.LAST_HIST_SEQ = i_last_active_hist_seq + 1;
	MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;        
	
	memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
	memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));
	 
	TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");


	//TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "PROD_LOT_ID");

	DBC_init_mtivlothis(&MTIVLOTHIS);
	COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, d_ConsumeQty, sizeof(MTIVLOTHIS.TRAN_CMF_1));

	TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");


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
	//}

	TRS.set_string(in_node, "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
	TRS.set_string(in_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));

	if (COM_isnullspace(TRS.get_string(in_node, "PROD_LOT_ID")) == MP_FALSE)
	{	
		TRS.set_nstring(in_node, "TO_LOT_ID", TRS.get_string(in_node, "PROD_LOT_ID"));
		TRS.set_nstring(in_node, "INPUT_LOT_ID", TRS.get_string(in_node, "TIV_LOT_ID"));
		TRS.set_nstring(in_node, "USE_OPER", TRS.get_string(in_node, "TIV_OPER"));
		//TRS.set_char(in_node, "WIP_OR_INV", 'W');
		TRS.set_string(in_node, "TRAN_CODE", MP_TIV_TRAN_CODE_CONSUME, strlen(MP_TIV_TRAN_CODE_CONSUME));
		TRS.set_double(in_node, "INPUT_QTY_1", d_ConsumeQty);
		TRS.set_double(in_node, "INPUT_QTY_2", 0);
		TRS.set_double(in_node, "INPUT_QTY_3", 0);


		if (TIV_Create_Material_Usage_Info(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			return MP_FALSE;
		}		
	}

	if (TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG") == 'Y')
	{
		/*TRS.set_nstring(in_node, "OPER", TRS.get_string(in_node, "TIV_OPER"));
		TRS.set_nstring(in_node, "LOT_ID", TRS.get_string(in_node, "TIV_LOT_ID"));
		TRS.set_nstring(in_node, "MAT_ID", TRS.get_string(in_node, "TIV_MAT_ID"));
		TRS.set_int(in_node, "MAT_VER", TRS.get_int(in_node, "TIV_MAT_VER"));
		TRS.set_char(in_node, "IN_OUT_FLAG", 'O');
		TRS.set_double(in_node, "ADJUST_QTY_1",  TRS.get_double(in_node, "CONSUME_QTY"));
		TRS.set_int(in_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
		if (TIV_Create_Inventory_Adjust_Info(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			return MP_FALSE;
		}*/
	}


	return MP_TRUE;
}

/*******************************************************************************
TIV_Consume_Lot_Validation()
- Validation Check sub function of "TIV_CONSUME_LOT" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TIV_CONSUME_LOT_IN_TAG *Out_Lot_In : Input Message structure
- Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Consume_Lot_Validation(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node)
{
	struct MWIPFACDEF_TAG MWIPFACDEF;   
	//struct MTIVMATDEF_TAG MTIVMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	//struct MTIVLOTSTS_TAG MTIVLOTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//int i_lot_count;    

	//TRSNode**    inv_lot_list;

	//int i;
	int i_step;

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

	if(COM_isnullspace(TRS.get_string(in_node, "TIV_LOT_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "INV-0001");
		TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		return MP_FALSE;
	}

	if(COM_isnullspace(TRS.get_string(in_node, "TRAN_TYPE")) == MP_TRUE)
	{
		strcpy(s_msg_code, "INV-0001");
		TRS.add_fieldmsg(out_node, "TRAN_TYPE", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		return MP_FALSE;
	}

	d_total_consume_qty_1 = 0;
	d_total_consume_qty_2 = 0;
	d_total_consume_qty_3 = 0;

	i_consume_count_1 = 0;
	i_consume_count_2 = 0;
	i_consume_count_3 = 0;		

	/*material exist*/
	DBC_init_mwipmatdef(&MWIPMATDEF);
	TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
	memcpy(MWIPMATDEF.MAT_ID, TRS.get_string(in_node, "TIV_MAT_ID") , sizeof(MWIPMATDEF.MAT_ID));
	MWIPMATDEF.MAT_VER = TRS.get_int(in_node, "TIV_MAT_VER"); 
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


	if(COM_isnullspace(TRS.get_string(in_node, "PROD_LOT_ID")) == MP_FALSE)
	{ 
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "PROD_LOT_ID");
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				DBC_init_mtivlotsts(&MTIVLOTSTS);
				TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
				memcpy(MTIVLOTSTS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
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

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				else
				{
					TRS.set_char(in_node, "WIP_OR_INV", 'I');
					TRS.set_int(in_node, "PROD_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
					TRS.set_double(in_node, "PROD_QTY_1", MTIVLOTSTS.QTY_1);
					TRS.set_double(in_node, "PROD_QTY_2", MTIVLOTSTS.QTY_2);
					TRS.set_double(in_node, "PROD_QTY_3", MTIVLOTSTS.QTY_3);
				}

			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_COMMON;
				return MP_FALSE;
			}     			
		}
		else
		{
			TRS.set_char(in_node, "WIP_OR_INV", 'W');
			TRS.set_int(in_node, "PROD_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
			TRS.set_double(in_node, "PROD_QTY_1", MWIPLOTSTS.QTY_1);
			TRS.set_double(in_node, "PROD_QTY_2", MWIPLOTSTS.QTY_2);
			TRS.set_double(in_node, "PROD_QTY_3", MWIPLOTSTS.QTY_3);
		}
	}

	return MP_TRUE;
}

