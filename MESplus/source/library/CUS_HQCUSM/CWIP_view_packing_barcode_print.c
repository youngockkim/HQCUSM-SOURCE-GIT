/*******************************************************************************

    System      : MESplus
    Module      : View Packing Barcode Print
    File Name   : CWIP_packing_barcode_print.c
    Description : SOI -> MES

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.10  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"

int CWIP_VIEW_PACKING_BARCODE_PRINT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Packing_Barcode_Print()
        - View Packing Barcode Print
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Packing_Barcode_Print(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_PACKING_BARCODE_PRINT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Packing_Barcode_Print", out_node);

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
    CWIP_VIEW_PACKING_BARCODE_PRINT()
        - View Packing Barcode Print
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_PACKING_BARCODE_PRINT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	char s_sys_time[14];
	char grade;
	TRSNode *list_item;
	int cwiplotpak_flag = 3;
	int mwipeltsts_flag = 1;
	
	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_PACKING_BARCODE_PRINT");
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

	// INIT
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID");		

	// OPEN
	CDB_open_cwiplotpak(cwiplotpak_flag,&CWIPLOTPAK);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "BOM-0042");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);				
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			CDB_close_cwiplotpak(cwiplotpak_flag);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else
		{
			strcpy(s_msg_code, "BOM-0004");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);
			TRS.add_dberrmsg(out_node,DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			CDB_close_cwiplotpak(cwiplotpak_flag);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	while(1)
	{
		CDB_fetch_cwiplotpak(cwiplotpak_flag, &CWIPLOTPAK);
		if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiplotpak(cwiplotpak_flag);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "BOM-0004");
            //TRS.add_fieldmsg(out_node, "CWIPORDBOM FETCH", MP_NVST);
			// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
			// DB error log edit
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK FETCH", MP_NVST); 
			
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            CDB_close_cwiplotpak(cwiplotpak_flag);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		TRS.add_string(out_node, "PALLET_ID", CWIPLOTPAK.POWER, sizeof(CWIPLOTPAK.POWER));
		
		// Get Article Information
		CDB_init_mwipeltsts(&MWIPELTSTS);		
		memcpy(MWIPELTSTS.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
		CDB_select_mwipeltsts(mwipeltsts_flag,&MWIPELTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
                TRS.add_dberrmsg(out_node,DB_error_msg);
                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

				// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
				// DB Close Ãß°¡
				CDB_close_cwiplotpak(cwiplotpak_flag);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

		if (memcmp(CWIPLOTPAK.GRADE, "G01", 3) == 0) {
			grade = 'A';
		}

		if (memcmp(CWIPLOTPAK.GRADE, "G02", 3) == 0) {
			grade = 'A';
		}
		if (memcmp(CWIPLOTPAK.GRADE, "G03", 3) == 0) {		//--[G03/G04 로직 추가]
			grade = 'A';
		}

		if (memcmp(CWIPLOTPAK.GRADE, "G04", 3) == 0) {		//--[G03/G04 로직 추가]
			grade = 'A';
		}


		if (memcmp(CWIPLOTPAK.GRADE, "G06", 3) == 0) {
			grade = 'Z';
		}

		if (memcmp(CWIPLOTPAK.GRADE, "B", 1) == 0) {
			grade = 'B';
		}
		
		if (memcmp(CWIPLOTPAK.GRADE, "C", 1) == 0) {
			grade = 'C';
		}
		
		list_item = TRS.add_node(out_node, "VIEW_OUT");

		TRS.add_int(list_item, "SEQ", CWIPLOTPAK.PAK_SEQ);
		TRS.add_string(list_item, "ARTICLE_NO", MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO));
		TRS.add_string(list_item, "GR_BATCHNO", MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS));
		TRS.add_string(list_item, "POWER_CLASS", MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
		TRS.add_char(list_item, "GRADE", grade);
		TRS.add_string(list_item, "MODULE_ID", CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}