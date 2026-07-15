/*******************************************************************************

System      : MESplus
Module      : INVCore
File Name   : TIV_create_material_lot.c
Description : Transaction Lot Material In function module

MES Version : 5.2.0

Function List
- TIV_Create_Material_Lot()
+ Transaction In Lot Material Inventory
- TIV_CREATE_MATERIAL_LOT()
+ Main Sub function of "TIV_Create_Material_Lot"
+ (called by "TIV_In_Lot")
- TIV_Create_Material_Lot_Validation()
+ Validation Check sub function of "TIV_CREATE_MATERIAL_LOT" function
+ (called by "TIV_CREATE_MATERIAL_LOT")

Detail Description
- 

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2012/11/26  JJ.OH         Create        

Copyright(C) 1998-2004 Miracom,Inc.
All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

#include <WIPCore_common.h>
#include <RASCore_common.h>
 

#define MP_RULE_ID_DEFAULT_TOOL ("TOOL_ID")

int TIV_Create_Material_Lot_Validation(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node);

int TIV_check_lot_cmf_create_lot(char *s_msg_code,
	TRSNode *in_node,
	TRSNode *out_node);


/*******************************************************************************
TIV_Create_Material_Lot()
- Lot Material In Inventory
Return Value
- int : 0 (MP_TRUE)
Arguments
- TIV_Create_Material_Lot_In_Tag *TIV_Create_Material_Lot : Input Message structure
- Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Create_Material_Lot(TRSNode *in_node, 
	TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TIV_CREATE_MATERIAL_LOT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "TIV_CREATE_MATERIAL_LOT", out_node);

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

	return MP_TRUE;}

/*******************************************************************************
TIV_CREATE_MATERIAL_LOT()
- Main sub function of "TIV_Create_Material_Lot" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TIV_CREATE_MATERIAL_LOT_TAG *In_Lot_In : Input Message structure
- Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_CREATE_MATERIAL_LOT(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node)
{
	//struct MTIVMATDEF_TAG MTIVMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MTIVLOTSTS_TAG MTIVLOTSTS;
	struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
	struct MTIVLOTSTS_TAG MTIVLOTSTS_COMP;
	struct MTIVLOTHIS_TAG MTIVLOTHIS;
	struct MATRNAMSTS_TAG MATRNAMSTS;
//	struct CTMPLOTMIG_TAG CTMPLOTMIG;

	struct	MGCMTBLDAT_TAG MGCMTBLDAT; 
	 
	char c_to_oper_lot_exist = 'N';
	
	char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];

	/*char    s_winter_start_time[14];
	char    s_winter_end_time[14];
	 */
	int i;
	int	i_step;
	//int	i_cursor_step;

	int i_lot_count = 0;   
	int i_last_hist_seq = 0;
	//int i_mat_ver = 0;
	double d_cv_qty = 0;
	
	TRSNode * ID_gen_in;
	TRSNode * ID_gen_out;

	TRSNode *cv_lot_in;
	//TRSNode *transfer_lot_in;
	TRSNode** inv_lot_list;
	TRSNode *list_item;
	TRSNode * proc_item;
	TRSNode *cv_item;

	TRSNode * Attr_Value_In;
    TRSNode * attr_item;

	TRSNode * IF_node;

	char c_summur_or_winter = ' ';

	char s_mat_ver[10];
	char s_valid_day_def[4];
	char s_valid_day[4];
	 
	int i_valid_day;
	 
	//Tool
	//TRSNode *tool_item, *sts_item;
	//TRSNode *gen_id_in;

	LOG_head("TIV_IN_LOT");
	COM_log_add_field_msg(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(COM_proc_user_routine("MES_UserTIV", "TIV_Create_Material_Lot",
		MP_UPOINT_BEFORE,
		in_node,
		out_node) == MP_FALSE)     return MP_FALSE;
	if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

	memset(s_valid_day, ' ', sizeof(s_valid_day));
	memset(s_valid_day_def, ' ', sizeof(s_valid_day_def));
	/*memset(s_winter_start_time, ' ', sizeof(s_winter_start_time));
	memset(s_winter_end_time, ' ', sizeof(s_winter_end_time));*/
	memset(s_mat_ver, ' ', sizeof(s_mat_ver));
	
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

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
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
	

	//Block by Kelly Jung 20170308
	//no need to check
	//DBC_init_mgcmtbldat(&MGCMTBLDAT);
	//TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	//memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_TBL_MAT_VALID_MONTH, strlen(MP_GCM_TBL_MAT_VALID_MONTH));
	//memcpy(MGCMTBLDAT.KEY_1, MP_GCM_MAT_VALID_GROUP_EXP_DATE, strlen(MP_GCM_MAT_VALID_GROUP_EXP_DATE));
 // 
	//i_step = 1;
	//DBC_select_mgcmtbldat(i_step, &MGCMTBLDAT);
	//if(DB_error_code != DB_SUCCESS)
	//{
	//	if (DB_error_code == DB_NOT_FOUND)
	//	{	
	//		strcpy(s_msg_code,"GCM-0008");							
	//		gs_log_type.e_type = MP_LOG_E_SYSTEM;				
	//	}
	//	else
	//	{	
	//		strcpy(s_msg_code,"GCM-0004");			
	//		TRS.add_dberrmsg(out_node, DB_error_msg);	
	//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//	}

	//	TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
	//	TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
	//	TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
	//	TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
	//	gs_log_type.type = MP_LOG_ERROR;
	//	gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//	gs_log_type.category = MP_LOG_CATE_TRANS;
 //
	//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//	return MP_FALSE;
	//}

	////memcpy(s_winter_start_time, s_sys_time, 4);
	////memcpy(s_winter_start_time + 4, MGCMTBLDAT.DATA_3, 4);
	////memcpy(s_winter_start_time + 8, "000000", strlen("000000"));
	////	
	////COM_itoa_left(s_winter_end_time, COM_atoi(s_sys_time, 4) + 1, sizeof(s_winter_end_time));
	////memcpy(s_winter_end_time + 4, MGCMTBLDAT.DATA_4, 4);
	////memcpy(s_winter_end_time + 8, "000000", strlen("000000"));
	// 
	////memcpy(s_erp_tran_time, "20161101000000", sizeof(s_erp_tran_time));
	//if (memcmp(s_erp_tran_time + 4, MGCMTBLDAT.DATA_4, 4) >= 0 &&
	//	memcmp(s_erp_tran_time + 4, MGCMTBLDAT.DATA_3, 4) < 0)
	//{
	//	c_summur_or_winter = 'S';
	//	memcpy(s_valid_day_def, MGCMTBLDAT.DATA_1, sizeof(s_valid_day_def));
	//}
	//else
	//{
	//	c_summur_or_winter = 'W';
	//	memcpy(s_valid_day_def, MGCMTBLDAT.DATA_2, sizeof(s_valid_day_def));
	//}


	/*' Validation Check*/
	if(TIV_Create_Material_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	/* CMF Validation */
	if(TIV_check_lot_cmf_create_lot(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	 
	i_lot_count = TRS.get_item_count(in_node, "TIV_LOT_LIST");
	inv_lot_list = TRS.get_list(in_node, "TIV_LOT_LIST");

	for(i=0; i<i_lot_count; i++)
	{   
		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "TIV_LOT_ID")) == MP_TRUE)
		{
			if (TRS.get_char(inv_lot_list[i], "CREATE_ADJ_LOT_FLAG") != 'Y')
			{
				strcpy(s_msg_code, "INV-0001");
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			DBU_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_IDG_DATE_FORMAT, strlen(MP_GCM_IDG_DATE_FORMAT));
			memcpy(MGCMTBLDAT.KEY_1, "ADJ", strlen("ADJ"));
			memcpy(MGCMTBLDAT.KEY_2, "ADJ", strlen("ADJ"));
	 
			i_step = 1;
			DBU_select_mgcmtbldat(i_step, &MGCMTBLDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{	
					strcpy(s_msg_code,"GCM-0008");							
					gs_log_type.e_type = MP_LOG_E_SYSTEM;				
				}
				else
				{	
					strcpy(s_msg_code,"GCM-0004");			
					TRS.add_dberrmsg(out_node, DB_error_msg);	
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}

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

			ID_gen_in = TRS.create_node("ID_GEN_IN");
			ID_gen_out = TRS.create_node("ID_GEN_OUT");
			TRS.add_char(ID_gen_in, IN_PROCSTEP, '2');
			TRS.add_enc_nstring(ID_gen_in, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(ID_gen_in, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(ID_gen_in, IN_FACTORY, TRS.get_factory(in_node));
	 
			TRS.add_string(ID_gen_in, "RULE_ID", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		  
			if (COM_isnullspace(MGCMTBLDAT.DATA_2) == MP_FALSE)
			{		
				// When customized date format exists
				// generate date field info according to the format

				TRS.set_string(in_node, "SYS_TIME", s_erp_tran_time, sizeof(s_erp_tran_time));
 
				//if (CUS_Generate_Date_2(s_msg_code, &MGCMTBLDAT, in_node, out_node) == MP_FALSE)
				//{
				//	TRS.free_node(ID_gen_in);
				//	TRS.free_node(ID_gen_out);
				//	return MP_FALSE;
				//}

				TRS.add_nstring(ID_gen_in, "SEQ_KEY_1", TRS.get_string(out_node, "IDG_DATE"));
			}
		 
			TRS.set_int(ID_gen_in, "GEN_ID_COUNT", 1); 
			TRS.add_nstring(ID_gen_in, "KEY_FACTORY", TRS.get_factory(in_node));
		
			if(WIP_GENERATE_ID(s_msg_code, ID_gen_in, ID_gen_out) == MP_FALSE)
			{			
				TRS.free_node(ID_gen_in);
				TRS.free_node(ID_gen_out);
				return MP_FALSE;
			}

			TRS.set_nstring(inv_lot_list[i], "TIV_LOT_ID", TRS.get_string(ID_gen_out, "GEN_ID"));
			//TRS.set_nstring(inv_lot_list[i], "LOT_ID", TRS.get_string(ID_gen_out, "GEN_ID"));

			TRS.free_node(ID_gen_in);
			TRS.free_node(ID_gen_out);	
		}
 
		DBC_init_mwipmatdef(&MWIPMATDEF);
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), inv_lot_list[i], "MAT_ID");
		MWIPMATDEF.MAT_VER = TRS.get_int(inv_lot_list[i], "MAT_VER");
		 
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
				strcpy(s_msg_code, "INV-0004");            
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}
			TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		} 

		memset(s_valid_day, ' ', sizeof(s_valid_day));
		COM_itoa_left(s_mat_ver, MWIPMATDEF.MAT_VER, sizeof(s_mat_ver));

		DBC_init_matrnamsts(&MATRNAMSTS);
		TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
		memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_MATERIAL, strlen(MP_ATTR_TYPE_MATERIAL));
		
		memcpy(MATRNAMSTS.ATTR_KEY, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		memcpy(MATRNAMSTS.ATTR_KEY + COM_len_space(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY)), " : ", strlen(" : "));
		memcpy(MATRNAMSTS.ATTR_KEY + COM_len_space(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY)) + 3, s_mat_ver, COM_len_space(s_mat_ver, sizeof(s_mat_ver))); 
		  
		if (c_summur_or_winter == 'S')
		{
			memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_KEY_VALID_MONTH_SM, strlen(MP_ATTR_KEY_VALID_MONTH_SM));
		}
		else
		{
			memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_KEY_VALID_MONTH_WT, strlen(MP_ATTR_KEY_VALID_MONTH_WT));
		}
		i_step = 1;
    
		DBC_select_matrnamsts(i_step, &MATRNAMSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				memcpy(s_valid_day, s_valid_day_def, sizeof(s_valid_day));
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MATRNAMSTS OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR,  sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
				TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR,  sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
				TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR,  sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}			
		}
		else
		{
			memcpy(s_valid_day, MATRNAMSTS.ATTR_VALUE, sizeof(s_valid_day));
		}
		  
		i_valid_day = COM_atoi(s_valid_day, sizeof(s_valid_day));
		 
		/*DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), inv_lot_list[i], "TIV_LOT_ID");
		DBC_select_mtivlotsts(6, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
							 
			}
			else
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);

				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}
		else
		{
			strcpy(s_msg_code, "WIP-0045");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}*/
		 
		/* Lot Exist Check */
		DBC_init_mtivlotsts(&MTIVLOTSTS_COMP);
		TRS.copy(MTIVLOTSTS_COMP.FACTORY, sizeof(MTIVLOTSTS_COMP.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS_COMP.LOT_ID, sizeof(MTIVLOTSTS_COMP.LOT_ID), inv_lot_list[i], "TIV_LOT_ID");
		TRS.copy(MTIVLOTSTS_COMP.OPER, sizeof(MTIVLOTSTS_COMP.OPER), inv_lot_list[i], "TIV_OPER");

		DBC_select_mtivlotsts(4, &MTIVLOTSTS_COMP);
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				c_to_oper_lot_exist = 'N';//not exist.
			}
			else if(DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);

				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}
		else
		{
			c_to_oper_lot_exist = 'Y';//exist
		}
		 
		//c_to_oper_lot_exist = 'N';

		/* Get latest LAST_HIST_SEQ */
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), inv_lot_list[i], "TIV_LOT_ID");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), inv_lot_list[i], "TIV_OPER");
		DBC_select_mtivlotsts(103, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
		{
			strcpy(s_msg_code, "INV-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		i_last_hist_seq = MTIVLOTSTS.LAST_HIST_SEQ;//없으면 0으로 있음
		
		//i_last_hist_seq = 0;
		 
		if(c_to_oper_lot_exist == 'Y')
		{
			cv_lot_in = TRS.create_node("CV_LOT_IN");

			TRS.add_char(cv_lot_in, IN_PROCSTEP, '1');
			TRS.add_int(cv_lot_in, "MAT_VER", TRS.get_int(inv_lot_list[i], "MAT_VER"));
			TRS.add_nstring(cv_lot_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
			TRS.add_char(cv_lot_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
			TRS.add_nstring(cv_lot_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
			TRS.add_nstring(cv_lot_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
			TRS.add_nstring(cv_lot_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
			TRS.set_nstring(cv_lot_in, "MAT_ID", TRS.get_string(inv_lot_list[i], "MAT_ID"));
			
			TRS.set_nstring(cv_lot_in, "BACK_TIME", TRS.get_string(inv_lot_list[i], "BACK_TIME"));
 
			TRS.set_nstring(cv_lot_in, "CREATE_CODE", TRS.get_string(inv_lot_list[i], "CREATE_CODE"));
			TRS.set_nstring(cv_lot_in, "OWNER_CODE", TRS.get_string(inv_lot_list[i], "OWNER_CODE"));

			TRS.set_string(cv_lot_in, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.set_string(cv_lot_in, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.add_char(cv_lot_in, "REBIRTH_LOT", 'Y');
			list_item = TRS.add_node(cv_lot_in, "TIV_LOT_LIST");
			TRS.set_string(list_item, "TRAN_TYPE", MP_INV_TRAN_TYPE_MAT_IN, strlen(MP_INV_TRAN_TYPE_MAT_IN)); 
			TRS.set_string(list_item, "TIV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.set_string(list_item, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.set_nstring(list_item, "TRAN_COMMNET", TRS.get_string(inv_lot_list[i], "TIV_LOT_COMMENT"));										
			TRS.set_string(list_item, "TIV_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.set_string(list_item, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.set_string(list_item, "TIV_MAT_ID", MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			TRS.set_int(list_item, "TIV_MAT_VER", MWIPMATDEF.MAT_VER);

			cv_item = TRS.add_node(list_item, "UNIT1");
			TRS.set_string(cv_item, "CODE", "CV_CREATE", strlen("CV_CREATE"));
			//TRS.set_double(cv_item, "QTY", MTIVLOTSTS.QTY_1);

			d_cv_qty = TRS.get_double(inv_lot_list[i], "IN_QTY");

			TRS.set_double(cv_item, "QTY", d_cv_qty);

			TRS.set_char(cv_lot_in, "CREATE_FLAG", 'Y');
			TRS.set_char(cv_item, "CREATE_FLAG", 'Y');

			if(TIV_CV_LOT(s_msg_code, cv_lot_in, out_node) == MP_FALSE)
			{
				//TRS.free_node(transfer_lot_in);
				TRS.free_node(cv_lot_in);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			TRS.free_node(cv_lot_in);

			/*COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;*/

			continue;
		}	

		/*Not CV -> Process Continue*/
		TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), inv_lot_list[i], "MAT_ID");
		MTIVLOTSTS.MAT_VER = MWIPMATDEF.MAT_VER;

		if (TRS.get_char(in_node, "ADJUST_LOT_FLAG") == 'Y')
		{
			MTIVLOTSTS.LOT_TYPE = 'A';
		}
		else
		{
			MTIVLOTSTS.LOT_TYPE = 'P';
		}
		
		/*Basically, Lot Generate FROM_OPER And Transfer*/
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), inv_lot_list[i], "FROM_OPER");

		TRS.copy(MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE), inv_lot_list[i], "CREATE_CODE");
		TRS.copy(MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE), inv_lot_list[i], "OWNER_CODE");
 
		MTIVLOTSTS.IN_OUT_FLAG ='I';
		TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), inv_lot_list[i], "ORDER_ID");
		TRS.copy(MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO), inv_lot_list[i], "LINE_ID");
		TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), inv_lot_list[i], "ORDER_ID");    
		TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), inv_lot_list[i], "VENDOR_ID");

		TRS.copy(MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1), inv_lot_list[i], "UNIT");        		

		TRS.copy(MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC), inv_lot_list[i], "LOT_DESC");        

		if (TRS.get_char(inv_lot_list[i], "CREATE_ADJ_LOT_FLAG") == 'Y')
		{
			MTIVLOTSTS.LOT_TYPE = MP_TIV_LOT_TYPE_ADJUST;
		}
		else
		{
			if(TRS.get_char(inv_lot_list[i], "LOT_TYPE") == ' ')
			{
				MTIVLOTSTS.LOT_TYPE = MP_LOT_TYPE_PROD;
			}
			else
			{
				MTIVLOTSTS.LOT_TYPE = TRS.get_char(inv_lot_list[i], "LOT_TYPE");
			}
		}

		memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_IN, strlen(MP_INV_TRAN_CODE_IN));

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "TRAN_TYPE")) == MP_TRUE)
		{
			memcpy(MTIVLOTSTS.LAST_TRAN_TYPE, MP_INV_TRAN_TYPE_MAT_IN, strlen(MP_INV_TRAN_TYPE_MAT_IN));
		}
		else
		{
			TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), inv_lot_list[i], "TRAN_TYPE");
		}
		
		TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), inv_lot_list[i], "TIV_LOT_COMMENT");
		TRS.copy(MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID), inv_lot_list[i], "VENDOR_LOT_ID");		

		TRS.copy(MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID), inv_lot_list[i], "MAT_ID");
		MTIVLOTSTS.PO_SEQ_NUM = TRS.get_int(inv_lot_list[i], "ORDER_SEQ_NUM");


		//TRS.copy(MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE), inv_lot_list[i], "EXPIRE_DATE");
		 
		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "EXPIRE_DATE")) == MP_TRUE)
		{
			if (memcmp(MWIPMATDEF.MAT_GRP_2, MP_MAT_GRP_2_RUB, strlen(MP_MAT_GRP_2_RUB)) == 0 ||
				memcmp(MWIPMATDEF.MAT_GRP_2, MP_MAT_GRP_2_STL, strlen(MP_MAT_GRP_2_STL)) == 0)
			{
				COM_add_time_sec(MTIVLOTSTS.EXPIRE_DATE, s_erp_tran_time, i_valid_day * 24 * 60 * 60);
			}
			else
			{
				memcpy(MTIVLOTSTS.EXPIRE_DATE, "99981231235959", sizeof(MTIVLOTSTS.EXPIRE_DATE));
			}
		}
		else
		{
			TRS.copy(MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE), inv_lot_list[i], "EXPIRE_DATE");
		}

		if(TRS.get_procstep(in_node) == '2')
		{
			memcpy(MTIVLOTSTS.EXPIRE_DATE, s_sys_time, sizeof(MTIVLOTSTS.EXPIRE_DATE));
		}
		TRS.copy(MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO), inv_lot_list[i], "LOCATION_NO");
		TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), inv_lot_list[i], "VENDOR_ID");

		memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS, sizeof(MTIVLOTSTS));

		DBC_init_mtivlothis(&MTIVLOTHIS);         
		/*신규 생성이라도 2번째로 만들어지는 것은 HIST_SEQ를 받아와야함*/
		MTIVLOTSTS.CREATE_QTY_1 = TRS.get_double(inv_lot_list[i], "IN_QTY");
		MTIVLOTSTS.CREATE_QTY_2 = 0;
		MTIVLOTSTS.CREATE_QTY_3 = 0;
		MTIVLOTSTS.LAST_HIST_SEQ = i_last_hist_seq+1;
		MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = i_last_hist_seq+1;                          


		MTIVLOTSTS.QTY_1 = TRS.get_double(inv_lot_list[i], "IN_QTY");
		MTIVLOTSTS.QTY_2 = 0;
		MTIVLOTSTS.QTY_3 = 0;

		MTIVLOTSTS_OLD.QTY_1 = 0;
		MTIVLOTSTS_OLD.QTY_2 = 0;
		MTIVLOTSTS_OLD.QTY_3 = 0;

		memcpy(MTIVLOTSTS.UNIT_1, MWIPMATDEF.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
		memcpy(MTIVLOTSTS.UNIT_2, MWIPMATDEF.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
		memcpy(MTIVLOTSTS.UNIT_3, MWIPMATDEF.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));

		/*if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "INV_CMF_1")) == MP_TRUE)
			memcpy(MTIVLOTSTS.INV_CMF_1, s_tran_time, 8);
		else
			TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_1");*/

		memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

		TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2), inv_lot_list[i], "INV_CMF_2");
		TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3), inv_lot_list[i], "INV_CMF_3");
		TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4), inv_lot_list[i], "INV_CMF_4");
		TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5), inv_lot_list[i], "INV_CMF_5");
		TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6), inv_lot_list[i], "INV_CMF_6");
		
		TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7), inv_lot_list[i], "INV_CMF_7");


		TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8), inv_lot_list[i], "INV_CMF_8");
		TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9), inv_lot_list[i], "INV_CMF_9");
		TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10), inv_lot_list[i], "INV_CMF_10");
		TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11), inv_lot_list[i], "INV_CMF_11");
		TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12), inv_lot_list[i], "INV_CMF_12");

		if (TRS.get_char(in_node, "MIGRATION_FLAG") == 'Y' && 
			memcmp(MTIVLOTSTS.OPER, "P910", strlen("P910")) == 0)
		{
			if (MWIPMATDEF.MAT_CMF_12[0] != ' ')
			{
				memcpy(MTIVLOTSTS.INV_CMF_13, MWIPMATDEF.MAT_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_13));
			}
			else
			{
				memcpy(MTIVLOTSTS.INV_CMF_13, MWIPMATDEF.MAT_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_13));
			}
		}
		else
		{
			TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13), inv_lot_list[i], "INV_CMF_13");
		}
		
		TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14), inv_lot_list[i], "INV_CMF_14");
		TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15), inv_lot_list[i], "INV_CMF_15");
		TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16), inv_lot_list[i], "INV_CMF_16");
		TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17), inv_lot_list[i], "INV_CMF_17");
		TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18), inv_lot_list[i], "INV_CMF_18");
		TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19), inv_lot_list[i], "INV_CMF_19");
		TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20), inv_lot_list[i], "INV_CMF_20");
		 
		TRS.copy(MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21), in_node, IN_FACTORY);

		//TRS.copy(MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21), inv_lot_list[i], "INV_CMF_21");
		TRS.copy(MTIVLOTSTS.INV_CMF_22, sizeof(MTIVLOTSTS.INV_CMF_22), inv_lot_list[i], "INV_CMF_22");
		TRS.copy(MTIVLOTSTS.INV_CMF_23, sizeof(MTIVLOTSTS.INV_CMF_23), inv_lot_list[i], "INV_CMF_23");
		TRS.copy(MTIVLOTSTS.INV_CMF_24, sizeof(MTIVLOTSTS.INV_CMF_24), inv_lot_list[i], "INV_CMF_24");
		TRS.copy(MTIVLOTSTS.INV_CMF_25, sizeof(MTIVLOTSTS.INV_CMF_25), inv_lot_list[i], "INV_CMF_25");
		TRS.copy(MTIVLOTSTS.INV_CMF_26, sizeof(MTIVLOTSTS.INV_CMF_26), inv_lot_list[i], "INV_CMF_26");
		TRS.copy(MTIVLOTSTS.INV_CMF_27, sizeof(MTIVLOTSTS.INV_CMF_27), inv_lot_list[i], "INV_CMF_27");
		TRS.copy(MTIVLOTSTS.INV_CMF_28, sizeof(MTIVLOTSTS.INV_CMF_28), inv_lot_list[i], "INV_CMF_28");
		TRS.copy(MTIVLOTSTS.INV_CMF_29, sizeof(MTIVLOTSTS.INV_CMF_29), inv_lot_list[i], "INV_CMF_29");
		TRS.copy(MTIVLOTSTS.INV_CMF_30, sizeof(MTIVLOTSTS.INV_CMF_30), inv_lot_list[i], "INV_CMF_30");
		MTIVLOTSTS.INV_FLAG_1 = TRS.get_char(inv_lot_list[i], "INV_FLAG_1");
		MTIVLOTSTS.INV_FLAG_2 = TRS.get_char(inv_lot_list[i], "INV_FLAG_2");
		MTIVLOTSTS.INV_FLAG_3 = TRS.get_char(inv_lot_list[i], "INV_FLAG_3");
		MTIVLOTSTS.INV_FLAG_4 = TRS.get_char(inv_lot_list[i], "INV_FLAG_4");
		MTIVLOTSTS.INV_FLAG_5 = TRS.get_char(inv_lot_list[i], "INV_FLAG_5");

		if(MTIVLOTSTS.QTY_1 == 0)
		{
			MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
			TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, "PRC_USER");
			memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
			memcpy(MTIVLOTSTS.LOT_DEL_REASON, "QTY_ZERO", strlen("QTY_ZERO"));
		}
		else
		{
			MTIVLOTSTS.LOT_DEL_FLAG = ' ';
			memset(MTIVLOTSTS.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
			memset(MTIVLOTSTS.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS.LOT_DEL_TIME));
			memset(MTIVLOTSTS.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS.LOT_DEL_REASON));
		}

		TRS.set_char(in_node, "CREATE_FLAG", 'Y');

		
		
		//if (TRS.get_char(in_node, "IN_STOCK_FLAG") == 'Y')
		//{
		//	//memcpy(MTIVLOTSTS.INV_CMF_1, s_tran_time, sizeof(s_tran_time));
		//	memcpy(MTIVLOTSTS.INV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS.INV_IN_TIME));
		//	TRS.copy(MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE), in_node, "WORK_DATE");
		//}

		
		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "CREATE_TIME")) == MP_TRUE)
			memcpy(MTIVLOTSTS.CREATE_TIME, s_tran_time, sizeof(MTIVLOTSTS.CREATE_TIME));
		else
			TRS.copy(MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME), inv_lot_list[i], "CREATE_TIME");

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "ERP_CREATE_DATE")) == MP_TRUE)
			TRS.copy(MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE), in_node, "WORK_DATE");	
		else
			TRS.copy(MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE), inv_lot_list[i], "ERP_CREATE_DATE");
		 
		TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "INV_IN_TIME")) == MP_TRUE)
			memcpy(MTIVLOTSTS.INV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS.INV_IN_TIME));
		else
			TRS.copy(MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME), inv_lot_list[i], "INV_IN_TIME");

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "ERP_INV_IN_DATE")) == MP_TRUE)
			TRS.copy(MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE), in_node, "WORK_DATE");
		else
			TRS.copy(MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE), inv_lot_list[i], "ERP_INV_IN_DATE");

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "OINV_IN_TIME")) == MP_TRUE)
			memcpy(MTIVLOTSTS.OINV_IN_TIME, s_tran_time, sizeof(MTIVLOTSTS.OINV_IN_TIME));
		else
			TRS.copy(MTIVLOTSTS.OINV_IN_TIME, sizeof(MTIVLOTSTS.OINV_IN_TIME), inv_lot_list[i], "OINV_IN_TIME");
		 
		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "ERP_OINV_IN_DATE")) == MP_TRUE)
			TRS.copy(MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE), in_node, "WORK_DATE");
		else
			TRS.copy(MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE), inv_lot_list[i], "ERP_OINV_IN_DATE");

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "LAST_TRAN_TIME")) == MP_TRUE)
			memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
		else
			TRS.copy(MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME), inv_lot_list[i], "LAST_TRAN_TIME");

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "ERP_LAST_TRAN_DATE")) == MP_TRUE)
			TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
		else
			TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), inv_lot_list[i], "ERP_LAST_TRAN_DATE");

		

		/*TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), inv_lot_list[i], "TRAN_CMF_1");		 
		TRS.copy(MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2), inv_lot_list[i], "TRAN_CMF_2");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_3, sizeof(MTIVLOTHIS.TRAN_CMF_3), inv_lot_list[i], "TRAN_CMF_3");*/
		TRS.copy(MTIVLOTHIS.TRAN_CMF_4, sizeof(MTIVLOTHIS.TRAN_CMF_4), inv_lot_list[i], "TRAN_CMF_4");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_5, sizeof(MTIVLOTHIS.TRAN_CMF_5), inv_lot_list[i], "TRAN_CMF_5");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6), inv_lot_list[i], "TRAN_CMF_6");		
		/*TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), inv_lot_list[i], "TRAN_CMF_7");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), inv_lot_list[i], "TRAN_CMF_8");*/
		TRS.copy(MTIVLOTHIS.TRAN_CMF_9, sizeof(MTIVLOTHIS.TRAN_CMF_9), inv_lot_list[i], "TRAN_CMF_9");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10), inv_lot_list[i], "TRAN_CMF_10");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11), inv_lot_list[i], "TRAN_CMF_11");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_12, sizeof(MTIVLOTHIS.TRAN_CMF_12), inv_lot_list[i], "TRAN_CMF_12");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_13, sizeof(MTIVLOTHIS.TRAN_CMF_13), inv_lot_list[i], "TRAN_CMF_13");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_14, sizeof(MTIVLOTHIS.TRAN_CMF_14), inv_lot_list[i], "TRAN_CMF_14");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_15, sizeof(MTIVLOTHIS.TRAN_CMF_15), inv_lot_list[i], "TRAN_CMF_15");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_16, sizeof(MTIVLOTHIS.TRAN_CMF_16), inv_lot_list[i], "TRAN_CMF_16");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_17, sizeof(MTIVLOTHIS.TRAN_CMF_17), inv_lot_list[i], "TRAN_CMF_17");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18), inv_lot_list[i], "TRAN_CMF_18");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19), inv_lot_list[i], "TRAN_CMF_19");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20), inv_lot_list[i], "TRAN_CMF_20");

		COM_dtoa(MTIVLOTHIS.TRAN_CMF_1, MTIVLOTSTS.QTY_1, sizeof(MTIVLOTHIS.TRAN_CMF_3));
		COM_dtoa(MTIVLOTHIS.TRAN_CMF_2, MTIVLOTSTS.QTY_2, sizeof(MTIVLOTHIS.TRAN_CMF_4));
		COM_dtoa(MTIVLOTHIS.TRAN_CMF_3, MTIVLOTSTS.QTY_3, sizeof(MTIVLOTHIS.TRAN_CMF_5));


		TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
		TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

		if (COM_isnullspace(MTIVLOTSTS.INV_CMF_1) == MP_TRUE)
			memcpy(MTIVLOTSTS.INV_CMF_1, s_sys_time, sizeof(MTIVLOTSTS.INV_CMF_1));
		
		if (COM_isnullspace(MTIVLOTSTS.INV_CMF_6) == MP_TRUE)
			TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6), inv_lot_list[i], "TIV_LOT_ID");

		if(TIV_update_insert_lot_status_history_for_in_lot(s_msg_code, 
			in_node,
			out_node,
			s_sys_time,
			&MTIVLOTSTS_OLD,
			&MTIVLOTSTS,
			&MTIVLOTHIS) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			//TRS.free_node(transfer_lot_in);	
			return MP_FALSE;
		}

		proc_item = TRS.add_node(out_node, "PROC_LOT_LIST");
		TRS.add_string(proc_item, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		TRS.add_string(proc_item, "EXPIRE_DATE", MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE));
		TRS.add_string(proc_item, "CREATE_TIME", MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME));
		TRS.add_nstring(proc_item, "WORK_DATE", TRS.get_string(in_node, "WORK_DATE"));
		TRS.add_double(proc_item, "QTY_1", MTIVLOTSTS.QTY_1); 


		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "CUSTOMER_MAT_ID")) == MP_FALSE)
		{
			Attr_Value_In = TRS.create_node("UPDATE_ATTRIBUTE_VALUE_IN");
			TRS.add_nstring(Attr_Value_In, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
			TRS.add_nstring(Attr_Value_In, IN_USERID, TRS.get_string(in_node, IN_USERID));
			TRS.add_nstring(Attr_Value_In, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
			TRS.add_char(Attr_Value_In, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
			TRS.add_char(Attr_Value_In, MP_NOTCHECK_PRIVILEGE, 'Y');

			TRS.add_char(Attr_Value_In, IN_PROCSTEP, '1');
			TRS.add_nstring(Attr_Value_In, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
			TRS.add_string(Attr_Value_In, "ATTR_KEY", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.add_string(Attr_Value_In, "ATTR_TYPE", MP_ATTR_TYPE_INV_LOT, strlen(MP_ATTR_TYPE_INV_LOT));

			attr_item = TRS.add_node(Attr_Value_In, "VALUE_LIST");

			TRS.add_string(attr_item, "ATTR_NAME", MP_ATTR_NAME_CUSTOMER_MAT_ID, strlen(MP_ATTR_NAME_CUSTOMER_MAT_ID));
			TRS.add_nstring(attr_item, "ATTR_VALUE", TRS.get_string(inv_lot_list[i], "CUSTOMER_MAT_ID"));
			TRS.add_int(attr_item, "LAST_HIST_SEQ", 0);
			if(BAS_UPDATE_ATTRIBUTE_VALUE(s_msg_code, Attr_Value_In, out_node) == MP_FALSE)
			{
				TRS.free_node(Attr_Value_In);
				return MP_FALSE;
			}
			TRS.free_node(Attr_Value_In);

		}

		if (COM_isnullspace(TRS.get_string(inv_lot_list[i], "CUSTOMER_ID")) == MP_FALSE)
		{
			Attr_Value_In = TRS.create_node("UPDATE_ATTRIBUTE_VALUE_IN");
			TRS.add_nstring(Attr_Value_In, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
			TRS.add_nstring(Attr_Value_In, IN_USERID, TRS.get_string(in_node, IN_USERID));
			TRS.add_nstring(Attr_Value_In, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
			TRS.add_char(Attr_Value_In, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
			TRS.add_char(Attr_Value_In, MP_NOTCHECK_PRIVILEGE, 'Y');

			TRS.add_char(Attr_Value_In, IN_PROCSTEP, '1');
			TRS.add_nstring(Attr_Value_In, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
			TRS.add_string(Attr_Value_In, "ATTR_KEY", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.add_string(Attr_Value_In, "ATTR_TYPE", MP_ATTR_TYPE_INV_LOT, strlen(MP_ATTR_TYPE_INV_LOT));

			attr_item = TRS.add_node(Attr_Value_In, "VALUE_LIST");

			TRS.add_string(attr_item, "ATTR_NAME", MP_ATTR_NAME_CUSTOMER_ID, strlen(MP_ATTR_NAME_CUSTOMER_ID));
			TRS.add_nstring(attr_item, "ATTR_VALUE", TRS.get_string(inv_lot_list[i], "CUSTOMER_ID"));
			TRS.add_int(attr_item, "LAST_HIST_SEQ", 0);
			if(BAS_UPDATE_ATTRIBUTE_VALUE(s_msg_code, Attr_Value_In, out_node) == MP_FALSE)
			{
				TRS.free_node(Attr_Value_In);
				return MP_FALSE;
			}
			TRS.free_node(Attr_Value_In);

		}


		if (TRS.get_char(inv_lot_list[i], "SKIP_IF_INFO_FLAG") != 'Y' &&
			TRS.get_char(inv_lot_list[i], "MIGRATION_FLAG") != 'Y' &&
			(TRS.get_char(inv_lot_list[i], "ETC_FLAG") == 'Y' ||
			 TRS.get_char(inv_lot_list[i], "CUST_RETURN_FLAG") == 'Y'))
		{
			IF_node = TRS.create_node("INTERFACE_IN");
			TRS.add_char(IF_node, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(IF_node, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));
			TRS.add_char(IF_node, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(IF_node, IN_FACTORY, TRS.get_factory(in_node));

			TRS.add_nstring(IF_node, "WERKS", TRS.get_factory(in_node));
			TRS.add_nstring(IF_node, "WERKS1", TRS.get_factory(in_node));
			TRS.add_nstring(IF_node, "BUDAT", TRS.get_string(in_node, "WORK_DATE"));				 
			//TRS.add_nstring(IF_node, "AUFNR", TRS.get_string(in_node, "ORDER_ID"));	
			TRS.add_nstring(IF_node, "BWART", TRS.get_string(inv_lot_list[i], "MVT_CODE"));
	
			TRS.add_string(IF_node, "MATNR", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
			TRS.add_string(IF_node, "MATNR1", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));

			TRS.add_string(IF_node, "LGORT", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.add_string(IF_node, "LGORT1", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			//i_last_if_seq++; ?????
			//TRS.add_int(IF_node, "SEQNO", i_last_if_seq);
	 
			/*if (TRS.get_char(inv_lot_list[i], "MVT_PM") == 'P')
				TRS.add_double(IF_node, "MENGE", MTIVLOTSTS.QTY_1);
			else
				TRS.add_double(IF_node, "MENGE", -1 * MTIVLOTSTS.QTY_1);*/
			TRS.add_double(IF_node, "MENGE", MTIVLOTSTS.QTY_1);
			TRS.add_string(IF_node, "ERNAM", "MES", strlen("MES"));
			TRS.add_string(IF_node, "ERDAT", s_sys_time, 8);
			TRS.add_string(IF_node, "ERZET", s_sys_time + 8, 6);
				
			TRS.add_string(IF_node, "CREATE_TIME", s_sys_time, sizeof(s_sys_time));
				
			TRS.add_string(IF_node, "MEINS", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
			TRS.add_string(IF_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.add_int(IF_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

			TRS.add_int(IF_node, "MAT_VER", MTIVLOTSTS.MAT_VER);

			TRS.add_char(IF_node, "ERP_IN_OUT_FLAG", TRS.get_char(inv_lot_list[i], "MVT_IN_OUT_FLAG"));
			TRS.add_char(IF_node, "ONLY_MOVE_INFO_FLAG", TRS.get_char(inv_lot_list[i], "ONLY_MOVE_INFO_FLAG"));
			
			//if (CUS_MES_To_ERP_Move(s_msg_code, IF_node, out_node) == MP_FALSE)
			//{
			//	TRS.free_node(IF_node);
			//	return MP_FALSE;
			//}
			TRS.free_node(IF_node);
			 

		}


		if (TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG") == 'Y')
		{
//			TRS.set_nstring(inv_lot_list[i], IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
//			TRS.set_nstring(inv_lot_list[i], IN_USERID, TRS.get_string(in_node, IN_USERID));
//			TRS.set_nstring(inv_lot_list[i], "LOT_ID", TRS.get_string(inv_lot_list[i], "TIV_LOT_ID"));
//			TRS.set_nstring(inv_lot_list[i], "OPER", TRS.get_string(inv_lot_list[i], "TIV_OPER"));
//			TRS.set_nstring(inv_lot_list[i], "WORK_DATE", TRS.get_string(in_node, "WORK_DATE"));
//			TRS.set_nstring(inv_lot_list[i], "SHIFT", TRS.get_string(in_node, "SHIFT"));
//			TRS.set_nstring(inv_lot_list[i], "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
//			TRS.set_nstring(inv_lot_list[i], "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
///*
//			TRS.set_string(inv_lot_list[i], "TRAN_TIME", s_tran_time, sizeof(s_tran_time));
//			TRS.set_string(inv_lot_list[i], "CREATE_TIME", s_sys_time, sizeof(s_sys_time));*/
//			TRS.set_char(inv_lot_list[i], "IN_OUT_FLAG", 'I');
//			TRS.set_double(inv_lot_list[i], "ADJUST_QTY_1",  TRS.get_double(inv_lot_list[i], "IN_QTY"));
//
//			TRS.set_int(inv_lot_list[i], "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
//			if (TIV_Create_Inventory_Adjust_Info(s_msg_code, inv_lot_list[i], out_node) == MP_FALSE)
//			{
//				return MP_FALSE;
//			}
		}
		 
		if (TRS.get_char(in_node, "MIGRATION_FLAG") == 'Y')
		{
			// Migration Temporary Logic
			/*DBC_init_ctmplotmig(&CTMPLOTMIG);
			TRS.copy(CTMPLOTMIG.FACTORY, sizeof(CTMPLOTMIG.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CTMPLOTMIG.LOT_ID, sizeof(CTMPLOTMIG.LOT_ID), inv_lot_list[i], "LOT_ID");
			CTMPLOTMIG.APPLY_FLAG = 'Y';
			i_step = 2;
            DBC_update_ctmplotmig(i_step, &CTMPLOTMIG);
            if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "CTMPLOTMIG UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(CTMPLOTMIG.FACTORY), CTMPLOTMIG.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(CTMPLOTMIG.LOT_ID), CTMPLOTMIG.LOT_ID);
                
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }*/
			 
		}
	}
	//TRS.free_node(transfer_lot_in);	

	//TRS.add_string(in_node, "AFTER_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	//TRS.add_string(in_node, "AFTER_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));

	


	if(COM_proc_user_routine("MES_UserTIV", "TIV_Create_Material_Lot",
		MP_UPOINT_AFTER,
		in_node,
		out_node) == MP_FALSE)     return MP_FALSE;
	//if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
TIV_Create_Material_Lot_Validation()
- Validation Check sub function of "TIV_CREATE_MATERIAL_LOT" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TIV_CREATE_MATERIAL_LOT_TAG *Create_Material_Lot : Input Message structure
- Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Create_Material_Lot_Validation(char *s_msg_code,
	TRSNode *in_node, 
	TRSNode *out_node)
{
	struct MWIPFACDEF_TAG MWIPFACDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MTIVLOTSTS_TAG MTIVLOTSTS;

	//int i_mat_ver;
	int i;
	int i_lot_count = 0;   
	TRSNode** inv_lot_list;

	/* ProcStep Validation */
	if(COM_service_validation(s_msg_code,
		in_node,
		out_node,
		TRS.get_procstep(in_node),
		"12") == MP_FALSE)
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

	if (TRS.get_item_count(in_node, "TIV_LOT_LIST") < 1)
	{
		strcpy(s_msg_code, "INV-0001");
		TRS.add_fieldmsg(out_node, "TIV_LOT_LIST", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		return MP_FALSE;
	}

	i_lot_count = TRS.get_item_count(in_node, "TIV_LOT_LIST");
	inv_lot_list = TRS.get_list(in_node, "TIV_LOT_LIST");        

	for(i=0; i<i_lot_count; i++)
	{
		if(COM_isnullspace(TRS.get_string(inv_lot_list[i], "MAT_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "INV-0001");
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			return MP_FALSE;
		}


		DBC_init_mwipmatdef(&MWIPMATDEF);
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), inv_lot_list[i], "MAT_ID");
		MWIPMATDEF.MAT_VER = TRS.get_int(inv_lot_list[i], "MAT_VER");

		DBC_select_mwipmatdef(1, &MWIPMATDEF);
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0006");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");            
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}
			TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_NSTR, TRS.get_string(inv_lot_list[i], "LOT_ID"));

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			return MP_FALSE;
		}

		//Check Same Material exist
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), inv_lot_list[i], "LOT_ID");
		DBC_select_mtivlotsts(3, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
		{
			strcpy(s_msg_code, "INV-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else if(DB_error_code == DB_SUCCESS)
		{
			if(memcmp(MTIVLOTSTS.MAT_ID, TRS.get_string(inv_lot_list[i], "MAT_ID"), strlen(TRS.get_string(inv_lot_list[i],"MAT_ID")))!=0)
			{
				strcpy(s_msg_code, "INV-0035");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				return MP_FALSE;
			}
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
		gs_log_type.category = MP_LOG_CATE_TRANS;
		return MP_FALSE;
	}

	return MP_TRUE;
}


/*******************************************************************************
TIV_check_lot_cmf_create_lot()
- Check the Conditions before Create INV Lot CMF Definition
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_lot_cmf_create_lot(char *s_msg_code,
	TRSNode *in_node,
	TRSNode *out_node)
{
	struct check_list s_check_list;

	COM_fill_check_list(&s_check_list, in_node, 20, "INV_CMF");
	if(COM_check_cmf(s_msg_code, 
		out_node,
		MP_CMF_INV_LOT, 
		TRS.get_factory(in_node), 
		&s_check_list) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	return MP_TRUE;
}