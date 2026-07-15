/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_transfer_request.c
    Description : Lot Transfer Request Transaction

    MES Version : 5.2.0.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/06/04   DM KIM          Modified

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"
#include "ALMCore_common.h"
#include "WIPCore_common.h"

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
//#include "TIVCore_common.h"
#include "TIVCore_common.h"


int TIV_Transfer_Request_Validation(char *s_msg_code,
                                         TRSNode *in_node, 
                                         TRSNode *out_node);



/*******************************************************************************
    TIV_Transfer_Request()
        - Transfer Request Transaction
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_Transfer_Request(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_TRANSFER_REQUEST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_Transfer_Request", out_node);

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
    TIV_TRANSFER_REQUEST()
        - Transfer Request Transaction
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_TRANSFER_REQUEST(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    //struct MTIVTRSDTL_TAG MTIVTRSDTL_o;
	struct MWIPFACDEF_TAG MWIPFACDEF;
    //struct MTIVTRSDTL_TAG MTIVTRSDTL_AFTER;
    /*struct MTIVMATDEF_TAG MTIVMATDEF;*/
	struct MWIPMATDEF_TAG MWIPMATDEF;
    //struct MTIVOPRDEF_TAG MTIVOPRDEF;
    //struct MATRNAMSTS_TAG MATRNAMSTS;
    //struct MTIVTRSHIS_TAG MTIVTRSHIS;
	struct  MGCMTBLDAT_TAG  MGCMTBLDAT;

	struct  MTIVMLSTRS_TAG  MTIVMLSTRS;

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
	//struct MTAPRESMLT_TAG MTAPRESMLT;
	//TRSNode * Mat_List_In;
	TRSNode * ID_gen_in;
	//TRSNode * arg_node;
	//TRSNode **id_list;

	TRSNode **mat_list;
    TRSNode **lot_list;
    TRSNode *action_in;

	//TRSNode ** dest_list;

    //TRSNode **trans_mat_list;
    //TRSNode **trans_lot_list;
    //TRSNode *transfer_lot_in;

	//TRSNode *assign_in;
	//TRSNode *assign_mat_in;
	int b_exist=MP_FALSE;

    int i = 0;
	//int j = 0;
    //int i_mat_ver = 0;
	int i_step;
	//int	i_id_count;
	//int	i_desc_count;

    char s_sys_time[14];
	char s_work_date[8];
	char s_temp[14];

	char c_proc_step;

	char s_num[10];

	char s_trs_no[30];

	char c_dml_flag = ' ';

	int i_list_count;
	//int i_node_idx;

    LOG_head("TIV_Transfer_Request");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Request",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    // get the system time
	
	memset(s_num, ' ', sizeof(s_num));
	memset(s_trs_no, ' ', sizeof(s_trs_no));
	memset(s_work_date, ' ', sizeof(s_work_date));
	memset(s_temp, ' ', sizeof(s_temp));

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime()", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

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

	DBC_init_mwipfacdef(&MWIPFACDEF);
	TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
	DBC_select_mwipfacdef(1, &MWIPFACDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	// Get Current Work Date based on Sys time
	if(memcmp(MWIPFACDEF.SHIFT_1_START, s_sys_time+8, 4)>0)
	{
		COM_sub_time_sec(s_temp, s_sys_time, 60*60*24);
		memcpy(s_work_date, s_temp, 8);
	}
	else
		memcpy(s_work_date, s_sys_time, 8);

    if(TIV_Transfer_Request_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/*if(TRS.get_char(in_node, "SPLIT_FIRST_FLAG")=='Y')
	{
		if(TIV_MULTI_SPLIT_LOT(s_msg_code, in_node, out_node) == MP_FALSE) 
		{
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}
	}*/
    
	if(TRS.get_procstep(in_node) == '1')
	{
		if (TRS.get_char(in_node, "DOC_TYPE") == MP_TIV_DOC_TYPE_BY_MATERIAL)
		{
			if (TRS.get_char(in_node, "TRS_SUB_TYPE") == 'U')
			{
				c_proc_step = TRS.get_procstep(in_node);
				TRS.set_char(in_node, IN_PROCSTEP, '2');

				if (TIV_UPDATE_MATERIAL_LIST_FOR_TRS(s_msg_code, in_node, out_node) == MP_FALSE)
				{
					return MP_FALSE;
				}
				TRS.set_char(in_node, IN_PROCSTEP, c_proc_step);

				TRS.set_int(in_node, "GEN_SEQ_NUM", TRS.get_int(out_node, "GEN_SEQ_NUM"));			
				COM_itoa_left(s_num, TRS.get_int(out_node, "GEN_SEQ_NUM"), sizeof(s_num));
				TRS.set_string(in_node, "TRS_CMF_3", s_num, sizeof(s_num));
			}
			else
			{
				TRS.set_int(in_node, "GEN_SEQ_NUM", 0);			 
				TRS.set_string(in_node, "TRS_CMF_3", "0", strlen("0"));
			}
		}
		
		ID_gen_in = TRS.create_node("ID_GEN_IN");
		TRS.add_char(ID_gen_in, IN_PROCSTEP, '2');
		TRS.add_enc_nstring(ID_gen_in, IN_USERID, TRS.get_userid(in_node));
		TRS.add_char(ID_gen_in, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(ID_gen_in, IN_FACTORY, TRS.get_factory(in_node));
		 
		DBU_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_IDG_DATE_FORMAT, strlen(MP_GCM_IDG_DATE_FORMAT));
		memcpy(MGCMTBLDAT.KEY_1, "TRS", strlen("TRS"));
		if (TRS.get_char(in_node, "TRS_SUB_TYPE") == 'T')
		{
			memcpy(MGCMTBLDAT.KEY_2, "MAT_REQ", strlen("MAT_REQ"));
		}
		else if (TRS.get_char(in_node, "TRS_SUB_TYPE") == 'R')
		{
			memcpy(MGCMTBLDAT.KEY_2, "MAT_RET", strlen("MAT_RET"));
		}
		else if (TRS.get_char(in_node, "TRS_SUB_TYPE") == 'U')
		{
			memcpy(MGCMTBLDAT.KEY_2, "URG_REQ", strlen("URG_REQ"));
		}
		else
		{
			strcpy(s_msg_code,"GCM-0004");			
			TRS.add_dberrmsg(out_node, DB_error_msg);	
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			TRS.free_node(ID_gen_in);
				 
 
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		} 

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

			TRS.free_node(ID_gen_in);
 
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if (COM_isnullspace(MGCMTBLDAT.DATA_1) == MP_TRUE)
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
 
			TRS.free_node(ID_gen_in);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.add_string(ID_gen_in, "RULE_ID", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

		if (COM_isnullspace(MGCMTBLDAT.DATA_2) == MP_FALSE)
		{		
			// When customized date format exists
			// generate date field info according to the format

			if (COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
			{
				 TRS.set_string(in_node, "SYS_TIME", s_work_date, sizeof(s_work_date));
			}
			else
			{
				 TRS.set_string(in_node, "SYS_TIME", s_sys_time, sizeof(s_sys_time));
			}
			 
			//if (CUS_Generate_Date_2(s_msg_code, &MGCMTBLDAT, in_node, out_node) == MP_FALSE)
			//{
			//	TRS.free_node(ID_gen_in);
			//	return MP_FALSE;
			//}

			TRS.set_nstring(ID_gen_in, "SEQ_KEY_1", TRS.get_string(out_node, "IDG_DATE"));
		}
		 
		//TRS.add_nstring(ID_gen_in, "RULE_ID", TRS.get_string(in_node, "ID_RULE_ID"));

		//TRS.set_int(ID_gen_in, "GEN_ID_COUNT", TRS.get_int(in_node, "TRS_COUNT")); 
		TRS.set_int(ID_gen_in, "GEN_ID_COUNT", 1); 
		TRS.add_nstring(ID_gen_in, "KEY_FACTORY", TRS.get_factory(in_node));

		if (COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
		{
			//TRS.add_string(ID_gen_in, "SEQ_KEY_1", s_work_date, sizeof(s_work_date));
			TRS.add_string(in_node, "WORK_DATE", s_work_date, sizeof(s_work_date));
			TRS.add_string(in_node, "TRS_CMF_1", s_work_date, sizeof(s_work_date));
		}
		
		/*arg_node = TRS.add_node(ID_gen_in, "ARGU_LIST");
		TRS.add_nstring(arg_node, "ARGUMENT", TRS.get_string(in_node, "DLV_NOTE_ID"));*/

		if(WIP_GENERATE_ID(s_msg_code, ID_gen_in, out_node) == MP_FALSE)
		{			
			TRS.free_node(ID_gen_in);
			return MP_FALSE;
		}
		TRS.free_node(ID_gen_in);

		/*id_list = TRS.get_list(out_node, "GEN_ID_LIST");
		i_id_count = TRS.get_item_count(out_node, "GEN_ID_LIST");*/
		TRS.set_nstring(in_node, "TRS_NO", TRS.get_string(out_node, "GEN_ID"));

		/*dest_list = TRS.get_list(in_node, "DEST_LIST");
		i_desc_count = TRS.get_item_count(out_node, "DEST_LIST");*/

		if(TIV_Update_TRS_Master(s_msg_code,  MP_STEP_CREATE, TRS.get_string(in_node, "TRS_NO"),
									 in_node, out_node) == MP_FALSE) 
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//for (i = 0; i < i_id_count; i++)
		//{
		//	// Request Master Insert			
		//	TRS.set_nstring(in_node, "TRS_CMF_3", TRS.get_string(dest_list[i], "FROM_OPER"));
		//	TRS.set_nstring(in_node, "TRS_CMF_4", TRS.get_string(dest_list[i], "TO_OPER"));

		//	if(TIV_Update_TRS_Master(s_msg_code,  MP_STEP_CREATE, TRS.get_string(id_list[i], "GEN_ID"),
		//							 in_node, out_node) == MP_FALSE) 
		//	{
		//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//		return MP_FALSE;
		//	}
		//}
		
		if (TRS.get_char(in_node, "DOC_TYPE") == MP_TIV_DOC_TYPE_BY_MATERIAL)
		{
			mat_list = TRS.get_list(in_node, "MAT_LIST");
			i_list_count = TRS.get_item_count(in_node, "MAT_LIST");

			for (i = 0; i < i_list_count; i++)
			{
				DBC_init_mtivmlstrs(&MTIVMLSTRS);   
				TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
				TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
				MTIVMLSTRS.GEN_SEQ_NUM = TRS.get_int(in_node, "GEN_SEQ_NUM");
				TRS.copy(MTIVMLSTRS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), mat_list[i], "MAT_ID");
				MTIVMLSTRS.MAT_VER  = TRS.get_int(mat_list[i], "MAT_VER");
				i_step = 1;

				DBC_select_mtivmlstrs_for_update(i_step, &MTIVMLSTRS); 
				if(DB_error_code != DB_SUCCESS) 
				{
					if(DB_error_code == DB_NOT_FOUND)
					{
						
					}
					else 
					{
						strcpy(s_msg_code, "INV-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);
						TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
						TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
						TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}					
				}
				else
				{
					MTIVMLSTRS.TRS_COUNT += 1;
					MTIVMLSTRS.TOTAL_TRS_QTY_1 += TRS.get_double(mat_list[i], "REQ_QTY");
					i_step = 2;
					DBC_update_mtivmlstrs(i_step, &MTIVMLSTRS); 
					if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
					{
						strcpy(s_msg_code, "INV-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);
						TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
						TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
						TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}


				memset(s_trs_no, ' ', sizeof(s_trs_no));
				//i_node_idx = TRS.get_int(mat_list[i], "TRS_IDX");
				TRS.copy(s_trs_no, sizeof(s_trs_no), in_node, "TRS_NO");
				
				DBC_init_mwipmatdef(&MWIPMATDEF);
				TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), mat_list[i], "MAT_ID");
				MWIPMATDEF.MAT_VER  = TRS.get_int(mat_list[i], "MAT_VER");
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
						TRS.add_dberrmsg(out_node, DB_error_msg);
					}
					TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				 
				//inspection detail information insert
				DBC_init_mtivtrsdtl(&MTIVTRSDTL);
				TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
				//TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), id_list[i_node_idx], "GEN_ID");
				memcpy(MTIVTRSDTL.TRS_NO, s_trs_no, sizeof(MTIVTRSDTL.TRS_NO));

				MTIVTRSDTL.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");
				TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID), mat_list[i], "MAT_ID");
				MTIVTRSDTL.MAT_VER = TRS.get_int(mat_list[i], "MAT_VER");
				//TRS.copy(MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID), lot_list[j], "LOT_ID");

				DBC_select_mtivtrsdtl_for_update(1, &MTIVTRSDTL);
				if(DB_error_code == DB_SUCCESS) //만약 동일한 것이 있다면 UPDATE시키도록 한다. 
				{
					b_exist=MP_TRUE;
					/*strcpy(s_msg_code, "INV-0034");
					TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
					TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;  */
				}

				/* Equal to Master Data */
				TRS.copy(MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE), in_node, "TRS_TYPE");
				MTIVTRSDTL.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
				MTIVTRSDTL.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");

				memcpy(MTIVTRSDTL.TRS_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));

				/* Each Detail Data */
				MTIVTRSDTL.TRS_SEQ = i + 1;

				TRS.copy(MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER), mat_list[i], "FROM_OPER");
				//TRS.copy(MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSDTL.FROM_LOCATION_NO), mat_list[i], "FROM_LOCATION_NO");			
				TRS.copy(MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER), mat_list[i], "TO_OPER");
				//TRS.copy(MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO), mat_list[i], "TO_LOCATION_NO");
                
				MTIVTRSDTL.REQ_QTY = TRS.get_double(mat_list[i], "REQ_QTY");
				MTIVTRSDTL.REMAIN_QTY = TRS.get_double(mat_list[i], "REQ_QTY");
				//MTIVTRSDTL.BOM_QTY = TRS.get_double(mat_list[i], "BOM_QTY");

				memcpy(MTIVTRSDTL.UNIT_1, MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1));
				memcpy(MTIVTRSDTL.UNIT_2, MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2));
				memcpy(MTIVTRSDTL.UNIT_3, MWIPMATDEF.UNIT_3, sizeof(MWIPMATDEF.UNIT_3));
                
				/*MTIVTRSDTL.QTY_3 = TRS.get_double(mat_list[i], "QTY_3"); 
				TRS.copy(MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSDTL.UNIT_1), mat_list[i], "UNIT_1");
				TRS.copy(MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3), mat_list[i], "UNIT_3");*/

				if(MTIVTRSDTL.STATUS_FLAG == ' ')
				{
					MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_OPEN;
				}

				TRS.copy(MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVTRSDTL.TRS_CMF_1), in_node, "TRS_CMF_1");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVTRSDTL.TRS_CMF_2), in_node, "TRS_CMF_2");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3), in_node, "TRS_CMF_3");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_4, sizeof(MTIVTRSDTL.TRS_CMF_4), in_node, "TRS_CMF_4");
				TRS.copy(MTIVTRSDTL.TRS_CMF_5, sizeof(MTIVTRSDTL.TRS_CMF_5), in_node, "TRS_CMF_5");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_6, sizeof(MTIVTRSDTL.TRS_CMF_6), in_node, "TRS_CMF_6");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_7, sizeof(MTIVTRSDTL.TRS_CMF_7), in_node, "TRS_CMF_7");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_8, sizeof(MTIVTRSDTL.TRS_CMF_8), in_node, "TRS_CMF_8");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_9, sizeof(MTIVTRSDTL.TRS_CMF_9), in_node, "TRS_CMF_9");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_10, sizeof(MTIVTRSDTL.TRS_CMF_10), in_node, "TRS_CMF_10");    

				memcpy(MTIVTRSDTL.CREATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.CREATE_TIME));
				TRS.copy(MTIVTRSDTL.CREATE_USER_ID, sizeof(MTIVTRSDTL.CREATE_USER_ID), in_node, "PRC_USER");                    
				 
				//memcpy(&MTIVTRSDTL_AFTER, &MTIVTRSDTL, sizeof(MTIVTRSDTL));

				//if(TRS.get_char(in_node, "REQUEST_AFTER_CONFIRM")=='Y')
				//{
				//	MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_COMPLETE;
				//	MTIVTRSDTL.REMAIN_QTY = 0;
				//	MTIVTRSDTL.QTY_1 = TRS.get_double(mat_list[i], "REQ_QTY");

				//	if (TRS.get_double(mat_list[i], "QTY_3") > 0)
				//	{
				//		//juhyeon.jung 2013.02.19 : NFME
				//		MTIVTRSDTL.QTY_2 = TRS.get_double(mat_list[i], "REQ_QTY")/TRS.get_double(mat_list[i], "QTY_3");
				//	}
                //                
				//}

				if(b_exist==MP_TRUE)
				{
					DBC_update_mtivtrsdtl(1, &MTIVTRSDTL);
					if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSDTL INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
						TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				else
				{
					DBC_insert_mtivtrsdtl(&MTIVTRSDTL);
					if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSDTL INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
						TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}

			}
		}
		else
		{
			lot_list = TRS.get_list(in_node, "LOT_LIST");
			i_list_count = TRS.get_item_count(in_node, "LOT_LIST");

			for (i = 0; i < i_list_count; i++)
			{
				memset(s_trs_no, ' ', sizeof(s_trs_no));
				//i_node_idx = TRS.get_int(lot_list[i], "TRS_IDX");
				TRS.copy(s_trs_no, sizeof(s_trs_no), in_node, "TRS_NO");

				DBC_init_mtivlotsts(&MTIVLOTSTS);
				TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), lot_list[i], "LOT_ID"); 
				TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), lot_list[i], "FROM_OPER"); 

				i_step = 2;

				DBC_select_mtivlotsts_for_update(i_step, &MTIVLOTSTS);
				if(DB_error_code != DB_SUCCESS) 
				{
					if(DB_error_code == DB_NOT_FOUND)
					{
						strcpy(s_msg_code, "INV-0030");
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
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				//inspection detail information insert
				DBC_init_mtivtrsdtl(&MTIVTRSDTL);
				TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
				//TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
				memcpy(MTIVTRSDTL.TRS_NO, s_trs_no, sizeof(MTIVTRSDTL.TRS_NO));

				MTIVTRSDTL.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");
				TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID), lot_list[i], "MAT_ID");
				MTIVTRSDTL.MAT_VER = TRS.get_int(lot_list[i], "MAT_VER");
				TRS.copy(MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID), lot_list[i], "LOT_ID");

				DBC_select_mtivtrsdtl_for_update(1, &MTIVTRSDTL);
				if(DB_error_code == DB_SUCCESS) //만약 동일한 것이 있다면 UPDATE시키도록 한다. 
				{
					b_exist=MP_TRUE;
					/*strcpy(s_msg_code, "INV-0034");
					TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
					TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;  */
				}

				/* Equal to Master Data */
				TRS.copy(MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE), in_node, "TRS_TYPE");
				MTIVTRSDTL.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
				MTIVTRSDTL.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");

				memcpy(MTIVTRSDTL.TRS_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));

				/* Each Detail Data */
				MTIVTRSDTL.TRS_SEQ = i + 1;

				TRS.copy(MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER), lot_list[i], "FROM_OPER");
				//TRS.copy(MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSDTL.FROM_LOCATION_NO), lot_list[i], "FROM_LOCATION_NO");			
				TRS.copy(MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER), lot_list[i], "TO_OPER");
				//TRS.copy(MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO), lot_list[i], "TO_LOCATION_NO");
                
				MTIVTRSDTL.REQ_QTY = TRS.get_double(lot_list[i], "REQ_QTY");
				MTIVTRSDTL.REMAIN_QTY = TRS.get_double(lot_list[i], "REQ_QTY");
				//MTIVTRSDTL.BOM_QTY = TRS.get_double(lot_list[i], "BOM_QTY");

				memcpy(MTIVTRSDTL.UNIT_1, MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
				memcpy(MTIVTRSDTL.UNIT_2, MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
				memcpy(MTIVTRSDTL.UNIT_3, MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));
                
				/*MTIVTRSDTL.QTY_3 = TRS.get_double(lot_list[i], "QTY_3"); 
				TRS.copy(MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSDTL.UNIT_1), lot_list[i], "UNIT_1");
				TRS.copy(MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3), lot_list[i], "UNIT_3");*/

				if(MTIVTRSDTL.STATUS_FLAG == ' ')
				{
					MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_OPEN;
				}

				TRS.copy(MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVTRSDTL.TRS_CMF_1), in_node, "TRS_CMF_1");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVTRSDTL.TRS_CMF_2), in_node, "TRS_CMF_2");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3), in_node, "TRS_CMF_3");             
				TRS.copy(MTIVTRSDTL.TRS_CMF_4, sizeof(MTIVTRSDTL.TRS_CMF_4), in_node, "TRS_CMF_4");    
				TRS.copy(MTIVTRSDTL.TRS_CMF_5, sizeof(MTIVTRSDTL.TRS_CMF_5), in_node, "TRS_CMF_5");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_6, sizeof(MTIVTRSDTL.TRS_CMF_6), in_node, "TRS_CMF_6");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_7, sizeof(MTIVTRSDTL.TRS_CMF_7), in_node, "TRS_CMF_7");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_8, sizeof(MTIVTRSDTL.TRS_CMF_8), in_node, "TRS_CMF_8");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_9, sizeof(MTIVTRSDTL.TRS_CMF_9), in_node, "TRS_CMF_9");                    
				TRS.copy(MTIVTRSDTL.TRS_CMF_10, sizeof(MTIVTRSDTL.TRS_CMF_10), in_node, "TRS_CMF_10");    

				memcpy(MTIVTRSDTL.CREATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.CREATE_TIME));
				TRS.copy(MTIVTRSDTL.CREATE_USER_ID, sizeof(MTIVTRSDTL.CREATE_USER_ID), in_node, "PRC_USER");                    
				 
				//memcpy(&MTIVTRSDTL_AFTER, &MTIVTRSDTL, sizeof(MTIVTRSDTL));

				//if(TRS.get_char(in_node, "REQUEST_AFTER_CONFIRM")=='Y')
				//{
				//	MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_COMPLETE;
				//	MTIVTRSDTL.REMAIN_QTY = 0;
				//	MTIVTRSDTL.QTY_1 = TRS.get_double(lot_list[i], "REQ_QTY");

				//	if (TRS.get_double(lot_list[i], "QTY_3") > 0)
				//	{
				//		//juhyeon.jung 2013.02.19 : NFME
				//		MTIVTRSDTL.QTY_2 = TRS.get_double(lot_list[i], "REQ_QTY")/TRS.get_double(lot_list[i], "QTY_3");
				//	}
                //                
				//}

				if(b_exist==MP_TRUE)
				{
					DBC_update_mtivtrsdtl(1, &MTIVTRSDTL);
					if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSDTL INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
						TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				else
				{
					DBC_insert_mtivtrsdtl(&MTIVTRSDTL);
					if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSDTL INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
						TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
			}
		}		
	}

	// Update Material
    if(TRS.get_procstep(in_node) == '2')
	{
        if(TIV_Update_TRS_Master(s_msg_code,  MP_STEP_UPDATE, TRS.get_string(in_node, "TRS_NO"),
								 in_node, out_node) == MP_FALSE) 
		{
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}

		if (TRS.get_char(in_node, "DOC_TYPE") == MP_TIV_DOC_TYPE_BY_MATERIAL)
		{ 
			mat_list = TRS.get_list(in_node, "MAT_LIST");

			for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
			{
				DBC_init_mtivmlstrs(&MTIVMLSTRS);   
				TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
				TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
				MTIVMLSTRS.GEN_SEQ_NUM = TRS.get_int(in_node, "GEN_SEQ_NUM");
				TRS.copy(MTIVMLSTRS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), mat_list[i], "MAT_ID");
				MTIVMLSTRS.MAT_VER  = TRS.get_int(mat_list[i], "MAT_VER");
				i_step = 1;

				DBC_select_mtivmlstrs_for_update(i_step, &MTIVMLSTRS); 
				if(DB_error_code != DB_SUCCESS) 
				{
					if(DB_error_code == DB_NOT_FOUND)
					{
						
					}
					else 
					{
						strcpy(s_msg_code, "INV-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);
						TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
						TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
						TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}					
				}
				else
				{
					//MTIVMLSTRS.TRS_COUNT += 1;
					MTIVMLSTRS.TOTAL_TRS_QTY_1 += (TRS.get_double(mat_list[i], "REQ_QTY") - TRS.get_double(mat_list[i], "OLD_REQ_QTY"));
					
					if (MTIVMLSTRS.TOTAL_TRS_QTY_1 < 0)
						MTIVMLSTRS.TOTAL_TRS_QTY_1 = 0;

					i_step = 2;
					DBC_update_mtivmlstrs(i_step, &MTIVMLSTRS); 
					if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
					{
						strcpy(s_msg_code, "INV-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);
						TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
						TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
						TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}

				DBC_init_mtivtrsdtl(&MTIVTRSDTL);
				TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");			
				TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID), mat_list[i], "MAT_ID");
				MTIVTRSDTL.MAT_VER = TRS.get_int(mat_list[i], "MAT_VER");
				 
				DBC_select_mtivtrsdtl_for_update(1, &MTIVTRSDTL);
				if(DB_error_code != DB_SUCCESS) 
				{
					if (DB_error_code == DB_NOT_FOUND)
					{
						c_dml_flag = 'C';
					}
					else
					{
						strcpy(s_msg_code, "INV-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);

						TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVTRSDTL.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}					
				}
				else
				{	
					c_dml_flag = 'U';	
				}

				if (c_dml_flag == 'C')
				{
					DBC_init_mwipmatdef(&MWIPMATDEF);
					TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
					TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), mat_list[i], "MAT_ID");
					MWIPMATDEF.MAT_VER  = TRS.get_int(mat_list[i], "MAT_VER");
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
							TRS.add_dberrmsg(out_node, DB_error_msg);
						}
						TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					DBC_init_mtivtrsdtl(&MTIVTRSDTL);
					TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
					TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");			
					 
					MTIVTRSDTL.TRS_SEQ = (int)DBC_select_mtivtrsdtl_scalar(8, &MTIVTRSDTL) + 1;
					
					MTIVTRSDTL.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");
					TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID), mat_list[i], "MAT_ID");
					MTIVTRSDTL.MAT_VER = TRS.get_int(mat_list[i], "MAT_VER");

					TRS.copy(MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE), in_node, "TRS_TYPE");
					MTIVTRSDTL.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
					MTIVTRSDTL.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");

					memcpy(MTIVTRSDTL.TRS_CODE, MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER));
					 
					TRS.copy(MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER), mat_list[i], "FROM_OPER");
					//TRS.copy(MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSDTL.FROM_LOCATION_NO), mat_list[i], "FROM_LOCATION_NO");			
					TRS.copy(MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER), mat_list[i], "TO_OPER");
					//TRS.copy(MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO), mat_list[i], "TO_LOCATION_NO");
                
					MTIVTRSDTL.REQ_QTY = TRS.get_double(mat_list[i], "REQ_QTY");
					MTIVTRSDTL.REMAIN_QTY = TRS.get_double(mat_list[i], "REQ_QTY");
					//MTIVTRSDTL.BOM_QTY = TRS.get_double(mat_list[i], "BOM_QTY");

					memcpy(MTIVTRSDTL.UNIT_1, MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1));
					memcpy(MTIVTRSDTL.UNIT_2, MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2));
					memcpy(MTIVTRSDTL.UNIT_3, MWIPMATDEF.UNIT_3, sizeof(MWIPMATDEF.UNIT_3));
                
					/*MTIVTRSDTL.QTY_3 = TRS.get_double(mat_list[i], "QTY_3"); 
					TRS.copy(MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSDTL.UNIT_1), mat_list[i], "UNIT_1");
					TRS.copy(MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3), mat_list[i], "UNIT_3");*/

					if(MTIVTRSDTL.STATUS_FLAG == ' ')
					{
						MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_OPEN;
					}

					TRS.copy(MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVTRSDTL.TRS_CMF_1), in_node, "TRS_CMF_1");                    
					TRS.copy(MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVTRSDTL.TRS_CMF_2), in_node, "TRS_CMF_2");                    
					/*TRS.copy(MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3), in_node, "TRS_CMF_3");                    
					TRS.copy(MTIVTRSDTL.TRS_CMF_4, sizeof(MTIVTRSDTL.TRS_CMF_4), in_node, "TRS_CMF_4"); */
					TRS.copy(MTIVTRSDTL.TRS_CMF_5, sizeof(MTIVTRSDTL.TRS_CMF_5), in_node, "TRS_CMF_5");                    
					TRS.copy(MTIVTRSDTL.TRS_CMF_6, sizeof(MTIVTRSDTL.TRS_CMF_6), in_node, "TRS_CMF_6");                    
					TRS.copy(MTIVTRSDTL.TRS_CMF_7, sizeof(MTIVTRSDTL.TRS_CMF_7), in_node, "TRS_CMF_7");                    
					TRS.copy(MTIVTRSDTL.TRS_CMF_8, sizeof(MTIVTRSDTL.TRS_CMF_8), in_node, "TRS_CMF_8");                    
					TRS.copy(MTIVTRSDTL.TRS_CMF_9, sizeof(MTIVTRSDTL.TRS_CMF_9), in_node, "TRS_CMF_9");                    
					TRS.copy(MTIVTRSDTL.TRS_CMF_10, sizeof(MTIVTRSDTL.TRS_CMF_10), in_node, "TRS_CMF_10");    

					memcpy(MTIVTRSDTL.CREATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.CREATE_TIME));
					TRS.copy(MTIVTRSDTL.CREATE_USER_ID, sizeof(MTIVTRSDTL.CREATE_USER_ID), in_node, "PRC_USER");  

					DBC_insert_mtivtrsdtl(&MTIVTRSDTL);
					if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSDTL INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
						TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);

						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				else
				{
					if (TRS.get_member(mat_list[i], "TRS_SEQ") != NULL)
					{
						MTIVTRSDTL.TRS_SEQ = TRS.get_int(mat_list[i], "TRS_SEQ");
					}
					if (TRS.get_member(mat_list[i], "TRS_TYPE") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE), mat_list[i], "TRS_TYPE");
					}
					if (TRS.get_member(mat_list[i], "TRS_CODE") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CODE, sizeof(MTIVTRSDTL.TRS_CODE), mat_list[i], "TRS_CODE");
					}
					if (TRS.get_member(mat_list[i], "STATUS_FLAG") != NULL)
					{
						MTIVTRSDTL.STATUS_FLAG = TRS.get_char(mat_list[i], "STATUS_FLAG");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_1") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVTRSDTL.TRS_CMF_1), mat_list[i], "TRS_CMF_1");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_2") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVTRSDTL.TRS_CMF_2), mat_list[i], "TRS_CMF_2");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_3") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3), mat_list[i], "TRS_CMF_3");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_4") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_4, sizeof(MTIVTRSDTL.TRS_CMF_4), mat_list[i], "TRS_CMF_4");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_5") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_5, sizeof(MTIVTRSDTL.TRS_CMF_5), mat_list[i], "TRS_CMF_5");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_6") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_6, sizeof(MTIVTRSDTL.TRS_CMF_6), mat_list[i], "TRS_CMF_6");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_7") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_7, sizeof(MTIVTRSDTL.TRS_CMF_7), mat_list[i], "TRS_CMF_7");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_8") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_8, sizeof(MTIVTRSDTL.TRS_CMF_8), mat_list[i], "TRS_CMF_8");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_9") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_9, sizeof(MTIVTRSDTL.TRS_CMF_9), mat_list[i], "TRS_CMF_9");
					}
					if (TRS.get_member(mat_list[i], "TRS_CMF_10") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_10, sizeof(MTIVTRSDTL.TRS_CMF_10), mat_list[i], "TRS_CMF_10");
					}
					if (TRS.get_member(mat_list[i], "DELETE_TIME") != NULL)
					{
						TRS.copy(MTIVTRSDTL.DELETE_TIME, sizeof(MTIVTRSDTL.DELETE_TIME), mat_list[i], "DELETE_TIME");
					}
					if (TRS.get_member(mat_list[i], "DELETE_USER_ID") != NULL)
					{
						TRS.copy(MTIVTRSDTL.DELETE_USER_ID, sizeof(MTIVTRSDTL.DELETE_USER_ID), mat_list[i], "DELETE_USER_ID");
					}
					if (TRS.get_member(mat_list[i], "REQ_QTY") != NULL)
					{
						MTIVTRSDTL.REQ_QTY = TRS.get_double(mat_list[i], "REQ_QTY");
					}
					if (TRS.get_member(mat_list[i], "FROM_OPER") != NULL)
					{
						TRS.copy(MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER), mat_list[i], "FROM_OPER");
					}
					if (TRS.get_member(mat_list[i], "TO_OPER") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER), mat_list[i], "TO_OPER");
					}
					if (TRS.get_member(mat_list[i], "DOC_TYPE") != NULL)
					{
						MTIVTRSDTL.DOC_TYPE = TRS.get_char(mat_list[i], "DOC_TYPE");
					}
					if (TRS.get_member(mat_list[i], "REMAIN_QTY") != NULL)
					{
						MTIVTRSDTL.REMAIN_QTY = TRS.get_double(mat_list[i], "REMAIN_QTY");
					}
					if (TRS.get_member(mat_list[i], "UNIT_1") != NULL)
					{
						TRS.copy(MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSDTL.UNIT_1), mat_list[i], "UNIT_1");
					}
					if (TRS.get_member(mat_list[i], "UNIT_2") != NULL)
					{
						TRS.copy(MTIVTRSDTL.UNIT_2, sizeof(MTIVTRSDTL.UNIT_2), mat_list[i], "UNIT_2");
					}
					if (TRS.get_member(mat_list[i], "UNIT_3") != NULL)
					{
						TRS.copy(MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3), mat_list[i], "UNIT_3");
					}
					if (TRS.get_member(mat_list[i], "QTY_1") != NULL)
					{
						MTIVTRSDTL.QTY_1 = TRS.get_double(mat_list[i], "QTY_1");
					}
					if (TRS.get_member(mat_list[i], "QTY_2") != NULL)
					{
						MTIVTRSDTL.QTY_2 = TRS.get_double(mat_list[i], "QTY_2");
					}
					if (TRS.get_member(mat_list[i], "QTY_3") != NULL)
					{
						MTIVTRSDTL.QTY_3 = TRS.get_double(mat_list[i], "QTY_3");
					}
					if (TRS.get_member(mat_list[i], "FROM_LOCATION_NO") != NULL)
					{
						TRS.copy(MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSDTL.FROM_LOCATION_NO), mat_list[i], "FROM_LOCATION_NO");
					}
					if (TRS.get_member(mat_list[i], "TO_LOCATION_NO") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO), mat_list[i], "TO_LOCATION_NO");
					}
					if (TRS.get_member(mat_list[i], "BOM_QTY") != NULL)
					{
						MTIVTRSDTL.BOM_QTY = TRS.get_double(mat_list[i], "BOM_QTY");
					}
					
					memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.UPDATE_TIME));
					TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, "TRS_USER");

					i_step = 1;
					DBC_update_mtivtrsdtl(i_step, &MTIVTRSDTL);
					if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSDTL UPDATE", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVTRSDTL.MAT_VER);
                
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

				}
			}
		}
		else
		{
			lot_list = TRS.get_list(in_node, "LOT_LIST");
			i_list_count = TRS.get_item_count(in_node, "LOT_LIST");

			for (i = 0; i < i_list_count; i++)
			{ 
				DBC_init_mtivtrsdtl(&MTIVTRSDTL);
				TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");			
				TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID), lot_list[i], "MAT_ID");
				MTIVTRSDTL.MAT_VER = TRS.get_int(lot_list[i], "MAT_VER");
				TRS.copy(MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID), lot_list[i], "LOT_ID");

				DBC_select_mtivtrsdtl_for_update(1, &MTIVTRSDTL);
				if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
				{                                
					strcpy(s_msg_code, "INV-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);

					TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVTRSDTL.MAT_VER);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				else
				{										
					if (TRS.get_member(lot_list[i], "TRS_SEQ") != NULL)
					{
						MTIVTRSDTL.TRS_SEQ = TRS.get_int(lot_list[i], "TRS_SEQ");
					}
					if (TRS.get_member(lot_list[i], "TRS_TYPE") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE), lot_list[i], "TRS_TYPE");
					}
					if (TRS.get_member(lot_list[i], "TRS_CODE") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CODE, sizeof(MTIVTRSDTL.TRS_CODE), lot_list[i], "TRS_CODE");
					}
					if (TRS.get_member(lot_list[i], "STATUS_FLAG") != NULL)
					{
						MTIVTRSDTL.STATUS_FLAG = TRS.get_char(lot_list[i], "STATUS_FLAG");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_1") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVTRSDTL.TRS_CMF_1), lot_list[i], "TRS_CMF_1");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_2") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVTRSDTL.TRS_CMF_2), lot_list[i], "TRS_CMF_2");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_3") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3), lot_list[i], "TRS_CMF_3");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_4") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_4, sizeof(MTIVTRSDTL.TRS_CMF_4), lot_list[i], "TRS_CMF_4");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_5") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_5, sizeof(MTIVTRSDTL.TRS_CMF_5), lot_list[i], "TRS_CMF_5");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_6") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_6, sizeof(MTIVTRSDTL.TRS_CMF_6), lot_list[i], "TRS_CMF_6");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_7") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_7, sizeof(MTIVTRSDTL.TRS_CMF_7), lot_list[i], "TRS_CMF_7");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_8") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_8, sizeof(MTIVTRSDTL.TRS_CMF_8), lot_list[i], "TRS_CMF_8");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_9") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_9, sizeof(MTIVTRSDTL.TRS_CMF_9), lot_list[i], "TRS_CMF_9");
					}
					if (TRS.get_member(lot_list[i], "TRS_CMF_10") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TRS_CMF_10, sizeof(MTIVTRSDTL.TRS_CMF_10), lot_list[i], "TRS_CMF_10");
					}
					if (TRS.get_member(lot_list[i], "DELETE_TIME") != NULL)
					{
						TRS.copy(MTIVTRSDTL.DELETE_TIME, sizeof(MTIVTRSDTL.DELETE_TIME), lot_list[i], "DELETE_TIME");
					}
					if (TRS.get_member(lot_list[i], "DELETE_USER_ID") != NULL)
					{
						TRS.copy(MTIVTRSDTL.DELETE_USER_ID, sizeof(MTIVTRSDTL.DELETE_USER_ID), lot_list[i], "DELETE_USER_ID");
					}
					if (TRS.get_member(lot_list[i], "REQ_QTY") != NULL)
					{
						MTIVTRSDTL.REQ_QTY = TRS.get_double(lot_list[i], "REQ_QTY");
					}
					if (TRS.get_member(lot_list[i], "FROM_OPER") != NULL)
					{
						TRS.copy(MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER), lot_list[i], "FROM_OPER");
					}
					if (TRS.get_member(lot_list[i], "TO_OPER") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER), lot_list[i], "TO_OPER");
					}
					if (TRS.get_member(lot_list[i], "DOC_TYPE") != NULL)
					{
						MTIVTRSDTL.DOC_TYPE = TRS.get_char(lot_list[i], "DOC_TYPE");
					}
					if (TRS.get_member(lot_list[i], "REMAIN_QTY") != NULL)
					{
						MTIVTRSDTL.REMAIN_QTY = TRS.get_double(lot_list[i], "REMAIN_QTY");
					}
					if (TRS.get_member(lot_list[i], "UNIT_1") != NULL)
					{
						TRS.copy(MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSDTL.UNIT_1), lot_list[i], "UNIT_1");
					}
					if (TRS.get_member(lot_list[i], "UNIT_2") != NULL)
					{
						TRS.copy(MTIVTRSDTL.UNIT_2, sizeof(MTIVTRSDTL.UNIT_2), lot_list[i], "UNIT_2");
					}
					if (TRS.get_member(lot_list[i], "UNIT_3") != NULL)
					{
						TRS.copy(MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3), lot_list[i], "UNIT_3");
					}
					if (TRS.get_member(lot_list[i], "QTY_1") != NULL)
					{
						MTIVTRSDTL.QTY_1 = TRS.get_double(lot_list[i], "QTY_1");
					}
					if (TRS.get_member(lot_list[i], "QTY_2") != NULL)
					{
						MTIVTRSDTL.QTY_2 = TRS.get_double(lot_list[i], "QTY_2");
					}
					if (TRS.get_member(lot_list[i], "QTY_3") != NULL)
					{
						MTIVTRSDTL.QTY_3 = TRS.get_double(lot_list[i], "QTY_3");
					}
					if (TRS.get_member(lot_list[i], "FROM_LOCATION_NO") != NULL)
					{
						TRS.copy(MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSDTL.FROM_LOCATION_NO), lot_list[i], "FROM_LOCATION_NO");
					}
					if (TRS.get_member(lot_list[i], "TO_LOCATION_NO") != NULL)
					{
						TRS.copy(MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO), lot_list[i], "TO_LOCATION_NO");
					}
					if (TRS.get_member(lot_list[i], "BOM_QTY") != NULL)
					{
						MTIVTRSDTL.BOM_QTY = TRS.get_double(lot_list[i], "BOM_QTY");
					}
					
					memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.UPDATE_TIME));
					TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, "TRS_USER");

					i_step = 1;
					DBC_update_mtivtrsdtl(i_step, &MTIVTRSDTL);
					if(DB_error_code != DB_SUCCESS) 
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MTIVTRSDTL UPDATE", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
						TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVTRSDTL.MAT_VER);
                
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

				}	

			}
		}
	}

	if(TRS.get_procstep(in_node) == '3')
	{
		if (TRS.get_char(in_node, "DELETE_ALL_FLAG") == 'Y')
		{
			if(TIV_Update_TRS_Master(s_msg_code,  MP_STEP_DELETE, TRS.get_string(in_node, "TRS_NO"),
								 in_node, out_node) == MP_FALSE) 
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			
			// 긴급성은 MTIVMLSTRS 도 삭제 처리 필요



		}

		if (TRS.get_char(in_node, "DOC_TYPE") == MP_TIV_DOC_TYPE_BY_MATERIAL)
		{
			mat_list = TRS.get_list(in_node, "MAT_LIST");
			for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
			{
				DBC_init_mtivmlstrs(&MTIVMLSTRS);   
				TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
				TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
				MTIVMLSTRS.GEN_SEQ_NUM = TRS.get_int(in_node, "GEN_SEQ_NUM");
				TRS.copy(MTIVMLSTRS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), mat_list[i], "MAT_ID");
				MTIVMLSTRS.MAT_VER  = TRS.get_int(mat_list[i], "MAT_VER");
				i_step = 1;

				DBC_select_mtivmlstrs_for_update(i_step, &MTIVMLSTRS); 
				if(DB_error_code != DB_SUCCESS) 
				{
					if(DB_error_code == DB_NOT_FOUND)
					{
						
					}
					else 
					{
						strcpy(s_msg_code, "INV-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);
						TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
						TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
						TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}					
				}
				else
				{
					MTIVMLSTRS.TRS_COUNT -= 1;
					if (MTIVMLSTRS.TRS_COUNT < 0)
						MTIVMLSTRS.TRS_COUNT = 0;

					MTIVMLSTRS.TOTAL_TRS_QTY_1 -= TRS.get_double(mat_list[i], "OLD_REQ_QTY");

					if (MTIVMLSTRS.TOTAL_TRS_QTY_1 < 0)
						MTIVMLSTRS.TOTAL_TRS_QTY_1 = 0;

					i_step = 2;
					DBC_update_mtivmlstrs(i_step, &MTIVMLSTRS); 
					if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
					{
						strcpy(s_msg_code, "INV-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);
						TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
						TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
						TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
						TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}

				DBC_init_mtivtrsdtl(&MTIVTRSDTL);
				TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
				TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID), mat_list[i], "MAT_ID");
				MTIVTRSDTL.MAT_VER = TRS.get_int(mat_list[i], "MAT_VER");

				i_step = 3;
				DBC_delete_mtivtrsdtl(i_step, &MTIVTRSDTL);
				if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MTIVTRSDTL DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVTRSDTL.MAT_VER);
                
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
		else
		{
			lot_list = TRS.get_list(in_node, "LOT_LIST");
			for (i = 0; i < TRS.get_item_count(in_node, "LOT_LIST"); i++)
			{
				DBC_init_mtivtrsdtl(&MTIVTRSDTL);
				TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
				TRS.copy(MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID), lot_list[i], "LOT_ID");
				 
				i_step = 4;
				DBC_delete_mtivtrsdtl(i_step, &MTIVTRSDTL);
				if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MTIVTRSDTL DELETE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVTRSDTL.MAT_VER);
                
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
	}

	if(TRS.get_procstep(in_node) == '4')
	{
		TRS.set_string(in_node, "TRS_CMF_4", s_sys_time, sizeof(s_sys_time));
        if(TIV_Update_TRS_Master(s_msg_code,  MP_STEP_UPDATE, TRS.get_string(in_node, "TRS_NO"),
								 in_node, out_node) == MP_FALSE) 
		{
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}

		DBC_init_mtivtrsdtl(&MTIVTRSDTL);
		TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
		MTIVTRSDTL.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
		memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.UPDATE_TIME));
		TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, "PRC_USER");
		i_step = 3;
		DBC_update_mtivtrsdtl(i_step, &MTIVTRSDTL);
		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MTIVTRSDTL DELETE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
			TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVTRSDTL.MAT_VER);
                
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

    //Alarm 
    action_in = TRS.create_node("ACTION_IN");
    TRS.add_char(action_in, IN_PROCSTEP, '1');
    TRS.set_int(action_in, "LAST_ACTIVE_HIST_SEQ", 0);

    TRS.set_string(action_in, "ALARM_ID", TRS.get_string(in_node, "ALARM_ID"), strlen(TRS.get_string(in_node, "ALARM_ID")));
    TRS.set_string(action_in, "ALARM_SUBJECT", TRS.get_string(in_node, "ALARM_SUBJECT"), strlen(TRS.get_string(in_node, "ALARM_SUBJECT")));
    TRS.set_string(action_in, "ALARM_MSG", TRS.get_string(in_node, "ALARM_MSG"), strlen(TRS.get_string(in_node, "ALARM_MSG")));
    TRS.set_string(action_in, "SOURCE_ID_1", TRS.get_string(in_node, "SOURCE_ID_1"), strlen(TRS.get_string(in_node, "SOURCE_ID_1")));
    TRS.set_string(action_in, "SOURCE_ID_2", TRS.get_string(in_node, "SOURCE_ID_2"), strlen(TRS.get_string(in_node, "SOURCE_ID_2")));
    TRS.set_string(action_in, "SOURCE_ID_3", TRS.get_string(in_node, "SOURCE_ID_3"), strlen(TRS.get_string(in_node, "SOURCE_ID_3")));

    TRS.set_char(action_in, "SKIP_ACTION", 'Y');
    TRS.add_string(action_in, IN_FACTORY, TRS.get_string(in_node, "FACTORY"), strlen(TRS.get_string(in_node, "FACTORY")));
    //TRS.add_string(action_in, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

    if(TRS.get_item_count(in_node, "MAT_LIST")!=0)
    {
        if(TRS.get_char(in_node, "NO_ALARM")!='Y')
        {
           /* if(ALM_RAISE_ALARM(s_msg_code, action_in, out_node) == MP_FALSE)
            {
                TRS.free_node(action_in);
                return MP_FALSE;
            }*/
        }
    }

    TRS.free_node(action_in);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Request",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Transfer_Request_Validation()
        - Validation Check sub function of "TIV_IQC_Request" function
        - View Future Action
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - ALM_in_node_Tag *in_node : Input Message structure
        - out_node_Tag *out_node : Output Message structure
*******************************************************************************/
int TIV_Transfer_Request_Validation(char *s_msg_code,
                                         TRSNode *in_node, 
                                         TRSNode *out_node)
{
    //struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVTRSMST_TAG MTIVTRSMST;
    struct MSECUSRDEF_TAG MSECUSRDEF;
    //struct MATRNAMSTS_TAG MATRNAMSTS_FROM;
    //struct MATRNAMSTS_TAG MATRNAMSTS_TO;
	//struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MTIVMATDEF_TAG MTIVMATDEF;
	//struct MATRNAMSTS_TAG MATRNAMSTS;
	//struct MWIPMATDEF_TAG MWIPMATDEF;

	TRSNode **mat_list;
    //TRSNode **lot_list;
	//int j;
	//int i;
	//int b_partial_flag;
    
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1234") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Validation for factory */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, IN_FACTORY, MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;        
        return MP_FALSE;
    }

	mat_list = TRS.get_list(in_node, "MAT_LIST");

	//for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
 //   {
 //      /* if(TRS.get_item_count(mat_list[i], "LOT_LIST") == 0)
 //       {
 //           TRS.add_node(mat_list[i], "LOT_LIST");
 //       }*/

	//	/* Validation for Oper */
	//	if(COM_isnullspace(TRS.get_string(mat_list[i], "FROM_OPER")) == MP_TRUE)
	//	{
	//		strcpy(s_msg_code, "WIP-0001");
	//		TRS.add_fieldmsg(out_node, "FROM_OPER", MP_NVST);

	//		gs_log_type.type = MP_LOG_ERROR;
	//		gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//		gs_log_type.category = MP_LOG_CATE_TRANS;        
	//		return MP_FALSE;
	//	}

	//	if(COM_isnullspace(TRS.get_string(mat_list[i], "TO_OPER")) == MP_TRUE)
	//	{
	//		strcpy(s_msg_code, "WIP-0001");
	//		TRS.add_fieldmsg(out_node, "TO_OPER", MP_NVST);

	//		gs_log_type.type = MP_LOG_ERROR;
	//		gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//		gs_log_type.category = MP_LOG_CATE_TRANS;        
	//		return MP_FALSE;
	//	}	
	//}

	//lot_list = TRS.get_list(in_node, "LOT_LIST");

	//for (i = 0; i < TRS.get_item_count(in_node, "LOT_LIST"); i++)
 //   {
 //      /* if(TRS.get_item_count(mat_list[i], "LOT_LIST") == 0)
 //       {
 //           TRS.add_node(mat_list[i], "LOT_LIST");
 //       }*/

	//	/* Validation for Oper */
	//	if(COM_isnullspace(TRS.get_string(lot_list[i], "FROM_OPER")) == MP_TRUE)
	//	{
	//		strcpy(s_msg_code, "WIP-0001");
	//		TRS.add_fieldmsg(out_node, "FROM_OPER", MP_NVST);

	//		gs_log_type.type = MP_LOG_ERROR;
	//		gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//		gs_log_type.category = MP_LOG_CATE_TRANS;        
	//		return MP_FALSE;
	//	}

	//	if(COM_isnullspace(TRS.get_string(lot_list[i], "TO_OPER")) == MP_TRUE)
	//	{
	//		strcpy(s_msg_code, "WIP-0001");
	//		TRS.add_fieldmsg(out_node, "TO_OPER", MP_NVST);

	//		gs_log_type.type = MP_LOG_ERROR;
	//		gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//		gs_log_type.category = MP_LOG_CATE_TRANS;        
	//		return MP_FALSE;
	//	}	
	//}

    /*MTIVTRSMST Exist Validation(When Update and Delete)*/
    if(TRS.get_procstep(in_node) == '2' || TRS.get_procstep(in_node) == '3' || TRS.get_procstep(in_node) == '4')
    {
        DBC_init_mtivtrsmst(&MTIVTRSMST);
        TRS.copy(MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
        DBC_select_mtivtrsmst(1, &MTIVTRSMST);
        if(DB_error_code != DB_SUCCESS)
        {
			if (DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0015");
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
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            return MP_FALSE;
        }

		if (TRS.get_procstep(in_node) != '4')
		{
			if (MTIVTRSMST.STATUS_FLAG != MP_INV_STATUS_OPEN)
			{
				strcpy(s_msg_code, "INV-0033");
				TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
				TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				return MP_FALSE;
			}
		}
		
    }

	//TRS_USER VALIDATION
    /*validation user*/
	if(COM_isnullspace(TRS.get_string(in_node, "TRS_USER")) == MP_FALSE)
	{
		DBC_init_msecusrdef(&MSECUSRDEF);
		TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MSECUSRDEF.USER_ID, sizeof(MSECUSRDEF.USER_ID), in_node, "TRS_USER");
		DBC_select_msecusrdef(1, &MSECUSRDEF);
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "SEC-0006");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "SEC-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node,DB_error_msg);
			}
			TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}	

/*
    DBC_init_mtivtrsmst(&MTIVTRSMST);
    TRS.copy(MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
    DBC_select_mtivtrsmst(1, &MTIVTRSMST);
    if(DB_error_code == DB_SUCCESS)
    {
        if(MTIVTRSMST.STATUS_FLAG != 'O')
        {
            strcpy(s_msg_code, "INV-0033");
            TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
            TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
    }
*/
    return MP_TRUE;
}

