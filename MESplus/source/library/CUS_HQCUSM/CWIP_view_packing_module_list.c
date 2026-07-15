/*******************************************************************************

    System      : MESplus
    Module      : View packing module list
    File Name   : CWIP_update_packing_module_list.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.27  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_PACKING_MODULE_LIST(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Packing_Module_List()
        - Update Packing Module List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Packing_Module_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_PACKING_MODULE_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Packing_Module_List", out_node);

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
    CWIP_VIEW_PACKING_MODULE_LIST()
        - VIEW_PACKING_MODULE_LIST
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_PACKING_MODULE_LIST(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	char s_sys_time[14];
	int mgcmlagdat_flag = 2;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_PACKING_MODULE_LIST");
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

	// INIT MGCMLAGDAT @ARTICLE
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(MGCMLAGDAT.TABLE_NAME, "@ARTICLE", strlen("@ARTICLE"));
	memcpy(MGCMLAGDAT.KEY_1, TRS.get_string(in_node,"LOT_ID"), strlen(TRS.get_string(in_node,"LOT_ID")));	
	
	DBC_open_mgcmlagdat(mgcmlagdat_flag,&MGCMLAGDAT);
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
			TRS.add_fieldmsg(out_node, "MGCMLAGDAT @ARTICLE OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			
			// 20210810 MES Application Memory leak 점검 및 수정
			// 불필요 부분 주석처리
			//DBC_close_mgcmlagdat(mgcmlagdat_flag);
			return MP_FALSE;
		}
	}

	// FETCH
	while(1)
	{
		DBC_fetch_mgcmlagdat(mgcmlagdat_flag, &MGCMLAGDAT);
		if(DB_error_code == DB_NOT_FOUND)
		{
			DBC_close_mgcmlagdat(mgcmlagdat_flag);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			//TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
			//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
			// 20210810 MES Application Memory leak 점검 및 수정
			// DB error log edit
			TRS.add_fieldmsg(out_node, "MGCMLAGDAT @ARTICLE FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);

			TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
			//CDB_close_ibasartdef(mgcmlagdat_flag);

			// 20210810 MES Application Memory leak 점검 및 수정
			// 처리시 잘못된 close 함수 수정 및 return MP_FALSE 추가
			DBC_close_mgcmlagdat(mgcmlagdat_flag);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}
	}
	
	TRS.add_string(out_node, "PACKING_TYPE", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2)); // 수정이 필요함
	TRS.add_string(out_node, "PACKING_QTY", "1", strlen("1"));                              // 수정이 필요함
	TRS.add_string(out_node, "MODULE_TYPE", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
	TRS.add_string(out_node, "ARTICLE_DESC", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));
	TRS.add_string(out_node, "POWER", MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));
	TRS.add_string(out_node, "ARTICLE_NO", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
	TRS.add_string(out_node, "BATCH_NO", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}