/*******************************************************************************

    System      : MESplus
    Module      : TIV
    File Name   : TIV_assign_lot_list_to_trs.c
    Description : 

    MES Version : 5.0.0

    Function List
        - TIV_Assign_Lot_List_To_TRS()
            + Main service
        - TIV_ASSIGN_LOT_LIST_TO_TRS()
            + Main sub function of "TIV_Assign_Lot_List_To_TRS" function
        - TIV_Assign_Lot_List_To_TRS_Validation()
            + Validation Check sub function of"TIV_ASSIGN_LOT_LIST_TO_TRS" function

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1      2015-11-03

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.


*******************************************************************************/
#include "TIVCore_common.h"

int TIV_Assign_Lot_List_To_TRS_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node);

/*******************************************************************************
    TIV_Assign_Lot_List_To_TRS()
        - Main service
    Return Value
        - Integer : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node :Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Assign_Lot_List_To_TRS(TRSNode *in_node, 
                        TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_ASSIGN_LOT_LIST_TO_TRS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_ASSIGN_LOT_LIST_TO_TRS", out_node);

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
    TIV_ASSIGN_LOT_LIST_TO_TRS()
        - Main sub function of "TIV_Assign_Lot_List_To_TRS" function
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_ASSIGN_LOT_LIST_TO_TRS(char *s_msg_code,
                             TRSNode *in_node, 
                             TRSNode *out_node)
{
    struct  MTIVTRSLOT_TAG  MTIVTRSLOT;
	struct  MTIVLOTSTS_TAG  MTIVLOTSTS;
	struct  MTIVTRSMST_TAG  MTIVTRSMST;
	struct	MTIVTRSDTL_TAG  MTIVTRSDTL;

    char    s_sys_time[14];

    int		i_step;
	
	int		i;
    int		i_item_count;
	
	double  d_sum_qty = 0;

	TRSNode **item_list;


    /* Log Generation */
    LOG_head("TIV_Assign_Lot_List_To_TRS");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("FACTORY", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
    LOG_add("TRS_NO", MP_NSTR, TRS.get_string(in_node, "TRS_NO"));
    LOG_add("ASSIGN_TYPE", MP_CHR, TRS.get_char(in_node, "ASSIGN_TYPE"));
    LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("OPER", MP_NSTR, TRS.get_string(in_node, "OPER"));
   
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    if(COM_proc_user_routine("TIV", "TIV_Assign_Lot_List_To_TRS",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    if(TIV_Assign_Lot_List_To_TRS_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}
	

    DBC_init_mtivtrsmst(&MTIVTRSMST);
	TRS.copy(MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
	DBC_select_mtivtrsmst_for_update(1, &MTIVTRSMST);
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
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;              
	}

	DBC_init_mtivtrsdtl(&MTIVTRSDTL);
	TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
	TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.TRS_NO), in_node, "MAT_ID");
	i_step = 3;
	DBC_select_mtivtrsdtl_for_update(i_step, &MTIVTRSDTL);	
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0714");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else 
		{
			strcpy(s_msg_code, "INV-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}

		TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT FOR UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
		TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
		TRS.add_fieldmsg(out_node, "MAT_ID", MP_CHR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

    if (TRS.get_procstep(in_node) == '1')
    {		
		i_item_count = TRS.get_item_count(in_node, "LOT_LIST");
		item_list = TRS.get_list(in_node, "LOT_LIST");

		d_sum_qty = 0;

		for (i = 0; i < i_item_count; i++)
		{
			DBC_init_mtivlotsts(&MTIVLOTSTS);
			TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
			TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), item_list[i], "LOT_ID");
			TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), item_list[i], "OPER");
			i_step = 4;

			DBC_select_mtivlotsts(i_step, &MTIVLOTSTS);
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

			if (MTIVLOTSTS.LOT_DEL_FLAG == 'Y' || MTIVLOTSTS.QTY_1 <= 0)
			{
				strcpy(s_msg_code, "INV-0023");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if (MTIVLOTSTS.QTY_1 < TRS.get_double(item_list[i], "ASSIGN_QTY"))
			{
				strcpy(s_msg_code, "WIP-0713");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
				TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);
				TRS.add_fieldmsg(out_node, "ASSIGN_QTY", MP_DBL, TRS.get_double(item_list[i], "ASSIGN_QTY"));

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			// Assign Lot to TRS 
			DBC_init_mtivtrslot(&MTIVTRSLOT);
			TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
			TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
			MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
			memcpy(MTIVTRSLOT.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
			memcpy(MTIVTRSLOT.OPER, MTIVLOTSTS.OPER, sizeof(MTIVTRSLOT.OPER));
			 
			i_step = 1;
			DBC_select_mtivtrslot(i_step, &MTIVTRSLOT);			
			if(DB_error_code != DB_SUCCESS) 
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					
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
				strcpy(s_msg_code, "WIP-0712");
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

			TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
			TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
			MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
			memcpy(MTIVTRSLOT.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
			memcpy(MTIVTRSLOT.OPER, MTIVLOTSTS.OPER, sizeof(MTIVTRSLOT.OPER));
			memcpy(MTIVTRSLOT.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVTRSLOT.MAT_ID));
			MTIVTRSLOT.MAT_VER = MTIVLOTSTS.MAT_VER;
			MTIVTRSLOT.ASSIGN_QTY = TRS.get_double(item_list[i], "ASSIGN_QTY");
			TRS.copy(MTIVTRSLOT.CREATE_USER_ID, sizeof(MTIVTRSLOT.CREATE_USER_ID), in_node, "PRC_USER");
			memcpy(MTIVTRSLOT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

			DBC_insert_mtivtrslot(&MTIVTRSLOT);        
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVTRSLOT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
				TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
				TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
            
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			d_sum_qty += TRS.get_double(item_list[i], "ASSIGN_QTY");
		}
	}
	else if (TRS.get_procstep(in_node) == '2')
	{
		i_item_count = TRS.get_item_count(in_node, "LOT_LIST");
		item_list = TRS.get_list(in_node, "LOT_LIST");

		d_sum_qty = 0;
		for (i = 0; i < i_item_count; i++)
		{		
			DBC_init_mtivtrslot(&MTIVTRSLOT);
			TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
			TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
			MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
			TRS.copy(MTIVTRSLOT.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID), item_list[i], "LOT_ID");
			TRS.copy(MTIVTRSLOT.OPER, sizeof(MTIVTRSLOT.OPER), item_list[i], "OPER");
 
			i_step = 1;
			DBC_select_mtivtrslot(i_step, &MTIVTRSLOT);			
			if(DB_error_code != DB_SUCCESS) 
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					
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
				i_step = 1;
				DBC_delete_mtivtrslot(i_step, &MTIVTRSLOT);        
				if(DB_error_code != DB_SUCCESS) 
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MTIVTRSLOT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
					TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);
            
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

			}

			d_sum_qty += MTIVTRSLOT.ASSIGN_QTY;
		}

	}

	TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, "PRC_USER");
	memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
	if (TRS.get_procstep(in_node) == '1')
	{
		MTIVTRSDTL.QTY_2 += d_sum_qty;
	}
	else
	{
		MTIVTRSDTL.QTY_2 -= d_sum_qty;
		if (MTIVTRSDTL.QTY_2 < 0)
			MTIVTRSDTL.QTY_2 = 0;
	}

	MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_PROCESSING;
	i_step = 5;
	DBC_update_mtivtrsdtl(i_step, &MTIVTRSDTL);	
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0714");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else 
		{
			strcpy(s_msg_code, "INV-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}

		TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT FOR UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
		TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
		TRS.add_fieldmsg(out_node, "MAT_ID", MP_CHR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	TRS.copy(MTIVTRSMST.UPDATE_USER_ID, sizeof(MTIVTRSMST.UPDATE_USER_ID), in_node, "PRC_USER");
	memcpy(MTIVTRSMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
	MTIVTRSMST.STATUS_FLAG = MP_INV_STATUS_PROCESSING;
	i_step = 3;
	DBC_update_mtivtrsmst(i_step, &MTIVTRSMST);
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
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;              
	}

    if(COM_proc_user_routine("TIV", "TIV_Assign_Lot_List_To_TRS",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Assign_Lot_List_To_TRS_Validation()
        - Validation Check sub function of "TIV_Assign_Lot_List_To_TRS" function
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Assign_Lot_List_To_TRS_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node)
{   
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation   */
    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    return MP_TRUE;
}
