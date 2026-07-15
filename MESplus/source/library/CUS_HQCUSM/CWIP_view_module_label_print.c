/*******************************************************************************

    System      : MESplus
    Module      : View Module Label Print
    File Name   : CWIP_view_module_label_print.c
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

int CWIP_VIEW_MODULE_LABEL_PRINT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Module_Label_Print()
        - View Module Label Print
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Module_Label_Print(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_MODULE_LABEL_PRINT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Module_Label_Print", out_node);

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
    CWIP_VIEW_MODULE_LABEL_PRINT()
        - View Module Label Print
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_MODULE_LABEL_PRINT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	char s_sys_time[14];
	TRSNode *list_item;	

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_MODULE_LABEL_PRINT");
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
	CDB_select_mwipeltsts(1,&MWIPELTSTS);
	if (DB_error_code != DB_SUCCESS)
	{
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;            
	}

	list_item = TRS.add_node(out_node, "VIEW_OUT");	
	TRS.add_string(list_item, "PMPP", MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
	TRS.add_string(list_item, "ISC", MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC));
	TRS.add_string(list_item, "VOC", MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC));
	TRS.add_string(list_item, "IMPP", MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP));
	TRS.add_string(list_item, "VMPP", MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP));

	// INIT
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.LOT_ID,  MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID));			
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if (DB_error_code != DB_SUCCESS)
	{
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
	}

	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(MGCMLAGDAT.TABLE_NAME, "@POWER_RANGE", strlen("@POWER_RANGE"));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(MGCMLAGDAT.KEY_2, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
	memcpy(MGCMLAGDAT.KEY_3, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
	CDB_select_mgcmlagdat(3, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
	}
	TRS.add_string(list_item, "VSYS", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));

	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(MGCMLAGDAT.TABLE_NAME, "@ARTICLE", strlen("@ARTICLE"));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(MGCMLAGDAT.KEY_2, MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO));
	CDB_select_mgcmlagdat(6, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;            
	}
	TRS.add_string(list_item, "LOT_ID", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));
			
	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;            
	}

	TRS.add_string(list_item, "KGLBS1", MGCMLAGDAT.DATA_7, sizeof(MGCMLAGDAT.DATA_7));
	TRS.add_string(list_item, "KGLBS2", MGCMLAGDAT.DATA_8, sizeof(MGCMLAGDAT.DATA_8));
	TRS.add_string(list_item, "BARCODE", MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}