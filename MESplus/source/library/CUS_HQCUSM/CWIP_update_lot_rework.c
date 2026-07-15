/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_lot_rework.c
    Description : lot_rework Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_lot_rework()
            + Create/Update/Delete lot_rework definition
        - CWIP_UPDATE_LOT_REWORK()
            + Main sub function of CWIP_Update_lot_rework function
            + Create/Update/Delete lot_rework definition
        - CWIP_Update_lot_rework_Validation()
            + Main sub function of CWIP_UPDATE_LOT_REWORK function
            + Check the condition for create/update/delete lot_rework
    Detail Description
        - CWIP_UPDATE_LOT_REWORK()
            + h_proc_step
                + MP_STEP_CREATE : Create lot_rework definition
                + MP_STEP_UPDATE : Update lot_rework definition
                + MP_STEP_DELETE : Delete lot_rework definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-01-09             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_lot_rework_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_lot_rework()
        - Create/Update/Delete lot_rework definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Lot_Rework(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_LOT_REWORK(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_LOT_REWORK", out_node);

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
    CWIP_UPDATE_LOT_REWORK()
        - Main sub function of "CWIP_Update_lot_rework" function
        - Create/Update/Delete lot_rework definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_LOT_REWORK(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTRWK_TAG CWIPLOTRWK;
    char   s_sys_time[14];
	int i;
	int i_tran_count;


	TRSNode ** Tran_List;

	LOG_head("CWIP_UPDATE_LOT_REWORK");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(CWIP_Update_lot_rework_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");

    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

	for(i = 0; i < i_tran_count; i++)
    {	
	

		CDB_init_cwiplotrwk(&CWIPLOTRWK);	
	    
		TRS.copy(CWIPLOTRWK.LOT_ID, sizeof(CWIPLOTRWK.LOT_ID), Tran_List[i], "LOT_ID");
		TRS.copy(CWIPLOTRWK.REASON_CODE, sizeof(CWIPLOTRWK.REASON_CODE), Tran_List[i], "REASON_CODE");
		TRS.copy(CWIPLOTRWK.LINE_ID, sizeof(CWIPLOTRWK.LINE_ID), Tran_List[i], "LINE_ID");		
		TRS.copy(CWIPLOTRWK.CREATE_USER_ID, sizeof(CWIPLOTRWK.CREATE_USER_ID), in_node, IN_USERID);

		TRS.copy(CWIPLOTRWK.CELL_INFO, sizeof(CWIPLOTRWK.CELL_INFO), Tran_List[i], "CELL_INFO");
		TRS.copy(CWIPLOTRWK.DEFECT_CODE, sizeof(CWIPLOTRWK.DEFECT_CODE), Tran_List[i], "DEFECT_CODE");
		TRS.copy(CWIPLOTRWK.DEFECT_DESC, sizeof(CWIPLOTRWK.DEFECT_DESC), Tran_List[i], "DEFECT_DESC");
		TRS.copy(CWIPLOTRWK.OLD_OPER, sizeof(CWIPLOTRWK.OLD_OPER), Tran_List[i], "OLD_OPER");
		TRS.copy(CWIPLOTRWK.OLD_OPER_DESC, sizeof(CWIPLOTRWK.OLD_OPER_DESC), Tran_List[i], "OLD_OPER_DESC");
		TRS.copy(CWIPLOTRWK.OLD_OPER_TRAN_TIME, sizeof(CWIPLOTRWK.OLD_OPER_TRAN_TIME), Tran_List[i], "OLD_OPER_TRAN_TIME");
		memcpy(CWIPLOTRWK.TRAN_TIME, s_sys_time, sizeof(CWIPLOTRWK.TRAN_TIME));
		TRS.copy(CWIPLOTRWK.CMF_1, sizeof(CWIPLOTRWK.CMF_1), Tran_List[i], "OPERATOR_NAME"); // IS-21-05-007 Rework Log MES OI Update Request

		CDB_insert_cwiplotrwk(&CWIPLOTRWK);
		if(DB_error_code != DB_SUCCESS)
        {

			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPLOTRWK INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTRWK.LOT_ID), CWIPLOTRWK.LOT_ID);
			TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CWIPLOTRWK.TRAN_TIME), CWIPLOTRWK.TRAN_TIME);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOTRWK.LINE_ID), CWIPLOTRWK.LINE_ID);
			TRS.add_fieldmsg(out_node, "REASON_CODE", MP_STR, sizeof(CWIPLOTRWK.REASON_CODE), CWIPLOTRWK.REASON_CODE);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
						       

		}
	
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_lot_rework_Validation()
        - Main sub function of "CWIP_UPDATE_LOT_REWORK" function
        - Check the condition for create/update/delete lot_rework
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_lot_rework_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

	return MP_TRUE;

}

