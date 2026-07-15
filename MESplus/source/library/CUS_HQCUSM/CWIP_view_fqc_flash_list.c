/*******************************************************************************

    System      : MESplus
    Module      : VIEW_FQC_FLASH_LIST
    File Name   : CWIP_view_fqc_flash_list.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.22  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_FQC_FLASH_LIST(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Fqc_Flash_List()
        - FQC Flash List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Fqc_Flash_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_FQC_FLASH_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Fqc_Flash_List", out_node);

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
    CWIP_VIEW_FQC_FLASH_LIST()
        - VIEW_FQC_FLASH_LIST
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_FQC_FLASH_LIST(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;

	char s_sys_time[14];
	TRSNode *list_item;
	int mwipeltsts_flag = 2;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_FQC_FLASH_LIST");
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

	// OPEN MWIPELTSTS
	CDB_init_mwipeltsts(&MWIPELTSTS);
	TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_open_mwipeltsts(mwipeltsts_flag, &MWIPELTSTS);
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
			TRS.add_fieldmsg(out_node, "MWIPELTSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
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
		CDB_fetch_mwipeltsts(mwipeltsts_flag,&MWIPELTSTS);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_mwipeltsts(mwipeltsts_flag);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPELTSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_mwipeltsts(mwipeltsts_flag);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "VIEW_INSP_OUT");

		//IF ESC EMPTY , SET CEDCLOTRLT.ESC 
		if (COM_isspace(MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC)) == MP_TRUE)
		{
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_SIMULATOR, strlen(HQCEL_INS_TYPE_CATEGORY_SIMULATOR));
			TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
			CDB_select_cedclotrlt(1,&CEDCLOTRLT);
			if(DB_error_code != DB_SUCCESS)
			{
				// DO Nothing
			}
			memcpy(MWIPELTSTS.ESC, CEDCLOTRLT.ESC, sizeof(MWIPELTSTS.ESC));

		}

		TRS.add_string(list_item, "LOT_ID", MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
		TRS.add_string(list_item, "VOC", MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC));
		TRS.add_string(list_item, "OSC", MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC));
		TRS.add_string(list_item, "ISC", MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC));
		TRS.add_string(list_item, "VMPP", MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP));
		TRS.add_string(list_item, "IMPP", MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP));
		TRS.add_string(list_item, "FF", MWIPELTSTS.FF, sizeof(MWIPELTSTS.FF));
		TRS.add_string(list_item, "EFF", MWIPELTSTS.EFF, sizeof(MWIPELTSTS.EFF));
		TRS.add_string(list_item, "PMPP", MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));
		TRS.add_string(list_item, "ESC", MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC));
		TRS.add_string(list_item, "TSC", MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC));
		TRS.add_string(list_item, "EL", MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL));
		TRS.add_string(list_item, "POWER", MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
		TRS.add_string(list_item, "GRADE", MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}