/*******************************************************************************

    System      : MESplus
    Module      : View Inspection List
    File Name   : CWIP_view_inspection_list.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.3  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_INSPECTION_LIST(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Inspection_List()
        - View_Inspection_List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Inspection_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_INSPECTION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Inspection_List", out_node);

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
    CWIP_VIEW_INSPECTION_LIST()
        - VIEW_INSPECTION_LIST
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_INSPECTION_LIST(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{

	// INIT
	struct MWIPELTSTS_TAG MWIPELTSTS;
	char s_sys_time[14];
	int mwipeltsts_flag = 1;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_INSPECTION_LIST");
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
	CDB_init_mwipeltsts(&MWIPELTSTS);
	TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwipeltsts(mwipeltsts_flag, &MWIPELTSTS);
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
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
	
	TRS.add_string(out_node, "LOT_ID", MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	TRS.add_string(out_node, "ARTICLE_EXT_NO", MWIPELTSTS.ARTICLE_EXT_NO, sizeof(MWIPELTSTS.ARTICLE_EXT_NO));
	TRS.add_string(out_node, "ARTICLE_NO", MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO));
	TRS.add_string(out_node, "COLOR_CLASS", MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS));
	TRS.add_string(out_node, "EFF", MWIPELTSTS.EFF, sizeof(MWIPELTSTS.EFF));
	TRS.add_string(out_node, "EL", MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL));
	TRS.add_string(out_node, "EL_IMAGE_PATH", MWIPELTSTS.EL_IMAGE_PATH, sizeof(MWIPELTSTS.EL_IMAGE_PATH));
	TRS.add_string(out_node, "ESC", MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC));
	TRS.add_string(out_node, "FF", MWIPELTSTS.FF, sizeof(MWIPELTSTS.FF));
	TRS.add_string(out_node, "FLASHER_CODE", MWIPELTSTS.FLASHER_CODE, sizeof(MWIPELTSTS.FLASHER_CODE));
	TRS.add_string(out_node, "FQC_TIME", MWIPELTSTS.FQC_TIME, sizeof(MWIPELTSTS.FQC_TIME));
	TRS.add_string(out_node, "GRADE", MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));	
	TRS.add_int(out_node, "HIST_SEQ", MWIPELTSTS.HIST_SEQ);	
	TRS.add_string(out_node, "IMPP", MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP));
	TRS.add_string(out_node, "ISC", MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC));
	TRS.add_string(out_node, "LINE_ID", MWIPELTSTS.LINE_ID, sizeof(MWIPELTSTS.LINE_ID));
	TRS.add_string(out_node, "LOC_ID", MWIPELTSTS.LOC_ID, sizeof(MWIPELTSTS.LOC_ID));
	TRS.add_string(out_node, "OSC", MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC));
	TRS.add_string(out_node, "PAK_BAR_INFO", MWIPELTSTS.PAK_BAR_INFO, sizeof(MWIPELTSTS.PAK_BAR_INFO));
	TRS.add_string(out_node, "PAK_GROUP", MWIPELTSTS.PAK_GROUP, sizeof(MWIPELTSTS.PAK_GROUP));
	TRS.add_string(out_node, "PAK_MOD_TYPE", MWIPELTSTS.PAK_MOD_TYPE, sizeof(MWIPELTSTS.PAK_MOD_TYPE));
	TRS.add_string(out_node, "PALLET_ID", MWIPELTSTS.PALLET_ID, sizeof(MWIPELTSTS.PALLET_ID));
	TRS.add_string(out_node, "PMPP", MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));
	TRS.add_string(out_node, "POWER", MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
	TRS.add_string(out_node, "RS", MWIPELTSTS.RS, sizeof(MWIPELTSTS.RS));
	TRS.add_string(out_node, "RSH", MWIPELTSTS.RSH, sizeof(MWIPELTSTS.RSH));
	TRS.add_string(out_node, "SUN", MWIPELTSTS.SUN, sizeof(MWIPELTSTS.SUN));
	TRS.add_string(out_node, "SURFTEMP", MWIPELTSTS.SURFTEMP, sizeof(MWIPELTSTS.SURFTEMP));
	TRS.add_string(out_node, "TEMP", MWIPELTSTS.TEMP, sizeof(MWIPELTSTS.TEMP));
	TRS.add_string(out_node, "TREF", MWIPELTSTS.TREF, sizeof(MWIPELTSTS.TREF));
	TRS.add_string(out_node, "VMPP", MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP));
	TRS.add_string(out_node, "VOC", MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC));
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;

}