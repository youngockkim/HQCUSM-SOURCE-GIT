/*******************************************************************************

    System      : MESplus
    Module      : View Packing FullCell List
    File Name   : CWIP_packing_fullcell_list.c
    Description : SOI -> MES

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.05  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Packing_Fullcell_List()
        - View Packing FullCell List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Packing_Fullcell_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_PACKING_FULLCELL_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Packing_Fullcell_List", out_node);

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
    CWIP_View_Packing_Fullcell_List()
        - View Packing FullCell List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_PACKING_FULLCELL_LIST(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct CWIPCELPAK_TAG CWIPCELPAK;
	char s_sys_time[14];
	TRSNode *list_item;
	int cwipcelpak_flag = 2;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_PACKING_FULLCELL_LIST");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// INIT CWIPCELPAK
	CDB_init_cwipcelpak(&CWIPCELPAK);
	memcpy(CWIPCELPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(CWIPCELPAK.PACK_ID, TRS.get_string(in_node,"PACK_ID"), sizeof(CWIPCELPAK.PACK_ID));
	CWIPCELPAK.PACK_TYPE = TRS.get_char(in_node, "PACK_TYPE");
	memcpy(CWIPCELPAK.OPER, TRS.get_string(in_node,"OPER"), sizeof(CWIPCELPAK.OPER));
	memcpy(CWIPCELPAK.ORDER_ID, TRS.get_string(in_node,"ORDER_ID"), sizeof(CWIPCELPAK.ORDER_ID));
	CDB_open_cwipcelpak(cwipcelpak_flag,&CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}
		else 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELPAK.PACK_ID), CWIPCELPAK.PACK_ID);			
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPCELPAK.ORDER_ID), CWIPCELPAK.ORDER_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(CWIPCELPAK.OPER), CWIPCELPAK.OPER);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	// FETCH
	while(1)
	{
		CDB_fetch_cwipcelpak(cwipcelpak_flag, &CWIPCELPAK);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_cwipcelpak(cwipcelpak_flag);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELPAK.PACK_ID), CWIPCELPAK.PACK_ID);			
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPCELPAK.ORDER_ID), CWIPCELPAK.ORDER_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(CWIPCELPAK.OPER), CWIPCELPAK.OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_cwipcelpak(cwipcelpak_flag);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "VIEW_CRR_OUT");

		TRS.add_string(list_item, "PACK_ID", CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID));
		TRS.add_string(list_item, "LACK_ID", CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID));
		TRS.add_string(list_item, "CELL_BOX_ID", CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID));
		TRS.add_int(list_item,  "PACK_QTY", CWIPCELPAK.PACK_QTY);
		TRS.add_string(list_item, "PACK_QTY", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));
		TRS.add_string(list_item, "OPER", CWIPCELPAK.OPER, sizeof(CWIPCELPAK.OPER));
		TRS.add_string(list_item, "MAT_ID", CWIPCELPAK.MAT_ID, sizeof(CWIPCELPAK.MAT_ID));
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}