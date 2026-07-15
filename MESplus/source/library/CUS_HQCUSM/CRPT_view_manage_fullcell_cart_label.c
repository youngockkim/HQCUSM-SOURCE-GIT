/*******************************************************************************

    System      : MESplus
    Module      : CRPT_View_Manage_FullCell_Cart_Label
    File Name   : CRPT_View_Manage_Fullcell_Cart_Label.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.15  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"

int CRPT_View_Manage_Fullcell_Cart_Label_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRPT_View_Manage_FullCell_Cart_Label()
        - View_FullCell_Cart_Label
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_View_Manage_Fullcell_Cart_Label(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRPT_VIEW_MANAGE_FULLCELL_CART_LABEL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRPT_View_Manage_Fullcell_Cart_Label", out_node);

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
    CRPT_VIEW_MANAGE_FULLCELL_CART_LABEL()
        - VIEW_FULLCELL_CART_LABEL
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_VIEW_MANAGE_FULLCELL_CART_LABEL(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	struct CWIPCELPAK_TAG CWIPCELPAK;

	char s_sys_time[14];
	TRSNode *list_item;
	  
	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_PACKING_LABEL_PRINT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Ordered by Magazine ID
        Step 2: Ordered by Scanning Time
    */

    if(CRPT_View_Manage_Fullcell_Cart_Label_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	if(TRS.get_procstep(in_node) == '3')
	{
		//CART
		CDB_init_cwipcelpak(&CWIPCELPAK);
		TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "LACK_ID");
		CWIPCELPAK.PACK_TYPE = TRS.get_char(in_node, "PACK_TYPE");

		// SELECT CWIPCELPAK
		CDB_open_cwipcelpak(104, &CWIPCELPAK);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0579");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);				
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		while(1)
		{
			CDB_fetch_cwipcelpak(104, &CWIPCELPAK);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwipcelpak(104);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				//TRS.add_fieldmsg(out_node, "CWIPORDBOM FETCH", MP_NVST);
				// 20210810 MES Application Memory leak 점검 및 수정
				// log edit
				TRS.add_fieldmsg(out_node, "CWIPCELPAK FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipcelpak(104);

				return MP_FALSE;
			}
			list_item = TRS.add_node(out_node, "VIEW_OUT");
			TRS.add_string(list_item, "MAGAZINE", CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID));             
			TRS.add_int(list_item, "CNT", CWIPCELPAK.PACK_QTY);                                                
			TRS.add_string(list_item, "SMALLBOX_ID", CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID));  
			TRS.add_string(list_item, "BATCH_NO", CWIPCELPAK.GR_BATCHNO, sizeof(CWIPCELPAK.GR_BATCHNO));             
			TRS.add_string(list_item, "CARRIER_ID", CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID));           
			TRS.add_string(list_item, "EFFICIENCY", CWIPCELPAK.POWERGRADE, sizeof(CWIPCELPAK.POWERGRADE));     
			TRS.add_string(list_item, "GRADE", CWIPCELPAK.QUALITYGRADE, sizeof(CWIPCELPAK.QUALITYGRADE));      
			TRS.add_string(list_item, "MODULE_PO", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));          
			TRS.add_string(list_item, "CLEAVING_PO", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));        
			TRS.add_double(list_item, "STOCK_CELL",0);                                                         
			TRS.add_string(list_item, "DATE_TIME", s_sys_time, sizeof(s_sys_time));                            
		}

		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}
	else if(TRS.get_procstep(in_node) == '4')
	{
		// SELECT CWIPCELPAK
		CDB_init_cwipcelpak(&CWIPCELPAK);
		TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
		TRS.copy(CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID), in_node, "CELL_BOX_ID");
		CWIPCELPAK.PACK_TYPE = TRS.get_char(in_node, "PACK_TYPE");

		CDB_select_cwipcelpak(4, &CWIPCELPAK); 
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0578"); 
				TRS.add_fieldmsg(out_node, "CWIPCELPAK SELECT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY); 
				TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELPAK.PACK_ID), CWIPCELPAK.PACK_ID); 
				TRS.add_fieldmsg(out_node, "CELL_BOX_ID", MP_STR, sizeof(CWIPCELPAK.CELL_BOX_ID), CWIPCELPAK.CELL_BOX_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			
		}

		TRS.add_string(out_node, "MAGAZINE", CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID));             
		TRS.add_int(out_node, "CNT", CWIPCELPAK.PACK_QTY);                                                
		TRS.add_string(out_node, "SMALLBOX_ID", CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID));  
		TRS.add_string(out_node, "BATCH_NO", CWIPCELPAK.GR_BATCHNO, sizeof(CWIPCELPAK.GR_BATCHNO));             
		TRS.add_string(out_node, "CARRIER_ID", CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID));           
		TRS.add_string(out_node, "EFFICIENCY", CWIPCELPAK.POWERGRADE, sizeof(CWIPCELPAK.POWERGRADE));     
		TRS.add_string(out_node, "GRADE", CWIPCELPAK.QUALITYGRADE, sizeof(CWIPCELPAK.QUALITYGRADE));      
		TRS.add_string(out_node, "MODULE_PO", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));          
		TRS.add_string(out_node, "CLEAVING_PO", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));        
		TRS.add_double(out_node, "STOCK_CELL",0);                                                         
		TRS.add_string(out_node, "DATE_TIME", s_sys_time, sizeof(s_sys_time));  

		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

/*******************************************************************************
	CRPT_View_Manage_Fullcell_Cart_Label_Validation()
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRPT_View_Manage_Fullcell_Cart_Label_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MRASCRRDEF_TAG MRASCRRDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1234") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

	if(TRS.get_procstep(in_node) != '4')
	{
		/* Check whether Cart ID exits or not */
		DBC_init_mrascrrdef(&MRASCRRDEF);
		TRS.copy(MRASCRRDEF.FACTORY, sizeof(MRASCRRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), in_node,"LACK_ID");

		DBC_select_mrascrrdef(1, &MRASCRRDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "RAS-0321");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "RAS-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}


			TRS.add_fieldmsg(out_node, "MRASCRRDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCRRDEF.FACTORY), MRASCRRDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MRASCRRDEF.CRR_ID), MRASCRRDEF.CRR_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

    return MP_TRUE;
}