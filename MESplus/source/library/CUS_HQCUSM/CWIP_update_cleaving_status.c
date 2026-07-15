/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_cleaving_status.c
    Description : Cleaving_Status Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Cleaving_Status()
            + Create/Update/Delete Cleaving_Status definition
        - CWIP_UPDATE_CLEAVING_STATUS()
            + Main sub function of CWIP_Update_Cleaving_Status function
            + Create/Update/Delete Cleaving_Status definition
        - CWIP_Update_Cleaving_Status_Validation()
            + Main sub function of CWIP_UPDATE_CLEAVING_STATUS function
            + Check the condition for create/update/delete Cleaving_Status
    Detail Description
        - CWIP_UPDATE_CLEAVING_STATUS()
            + h_proc_step
                + MP_STEP_CREATE : Create Cleaving_Status definition
                + MP_STEP_UPDATE : Update Cleaving_Status definition
                + MP_STEP_DELETE : Delete Cleaving_Status definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-02-09             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Cleaving_Status_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Cleaving_Status()
        - Create/Update/Delete Cleaving_Status definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Cleaving_Status(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_CLEAVING_STATUS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_CLEAVING_STATUS", out_node);

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
    CWIP_UPDATE_CLEAVING_STATUS()
        - Main sub function of "CWIP_Update_Cleaving_Status" function
        - Create/Update/Delete Cleaving_Status definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_CLEAVING_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{

	// INIT
	struct CWIPCLVSTS_TAG CWIPCLVSTS;
	struct CWIPCLVSTS_TAG CWIPCLVSTS_EXIST;
	struct CWIPCLVSTS_TAG CWIPCLVSTS_SEQ;

	TRSNode ** Tran_List;

	char s_sys_time[14];
	int    i_tran_count = 0;
	int i_max_ins_seq;
	int    i = 0;

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_CLEAVING_STATUS");
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
	
    Tran_List = TRS.get_list(in_node, "WORK_LIST");
    i_tran_count = TRS.get_item_count(in_node, "WORK_LIST");

	for(i = 0; i < i_tran_count; i++)
	{

		CDB_init_cwipclvsts(&CWIPCLVSTS);
		TRS.copy(CWIPCLVSTS.FACTORY, sizeof(CWIPCLVSTS.FACTORY), Tran_List[i], "FACTORY");
		TRS.copy(CWIPCLVSTS.LINE_ID, sizeof(CWIPCLVSTS.LINE_ID), Tran_List[i], "LINE_ID");
		TRS.copy(CWIPCLVSTS.RES_ID, sizeof(CWIPCLVSTS.RES_ID), Tran_List[i], "RES_ID");
		TRS.copy(CWIPCLVSTS.TRAN_DATE, sizeof(CWIPCLVSTS.TRAN_DATE), Tran_List[i], "TRAN_DATE");
		TRS.copy(CWIPCLVSTS.TRAN_TIME, sizeof(CWIPCLVSTS.TRAN_TIME), Tran_List[i], "TRAN_TIME");
		TRS.copy(CWIPCLVSTS.COMMENT_1, sizeof(CWIPCLVSTS.COMMENT_1), Tran_List[i], "COMMENT_1");

		CWIPCLVSTS.HALF_CELL_SAP = TRS.get_int(Tran_List[i], "HALF_CELL_SAP");
		CWIPCLVSTS.HALF_CELL_LINE = TRS.get_int(Tran_List[i], "HALF_CELL_LINE");
		CWIPCLVSTS.FULL_CELL_SAP = TRS.get_int(Tran_List[i], "FULL_CELL_SAP");
		CWIPCLVSTS.CELL_UNPACK = TRS.get_int(Tran_List[i], "CELL_UNPACK");

		TRS.copy(CWIPCLVSTS.CMF_1, sizeof(CWIPCLVSTS.CMF_1), Tran_List[i], "CMF_1");
		TRS.copy(CWIPCLVSTS.CMF_2, sizeof(CWIPCLVSTS.CMF_2), Tran_List[i], "CMF_2");
		TRS.copy(CWIPCLVSTS.CMF_3, sizeof(CWIPCLVSTS.CMF_3), Tran_List[i], "CMF_3");
		TRS.copy(CWIPCLVSTS.CMF_4, sizeof(CWIPCLVSTS.CMF_4), Tran_List[i], "CMF_4");
		TRS.copy(CWIPCLVSTS.CMF_5, sizeof(CWIPCLVSTS.CMF_5), Tran_List[i], "CMF_5");

		memcpy(CWIPCLVSTS.CREATE_USER_ID, MODULE_CLI, strlen(MODULE_CLI));
		memcpy(CWIPCLVSTS.CREATE_TIME, s_sys_time, sizeof(CWIPCLVSTS.CREATE_TIME));



		/* 1. Save All Tracking and Defect Data */
		i_max_ins_seq = 0;
		CDB_init_cwipclvsts(&CWIPCLVSTS_SEQ);
		TRS.copy(CWIPCLVSTS_SEQ.FACTORY, sizeof(CWIPCLVSTS_SEQ.FACTORY), Tran_List[i], "FACTORY");
		TRS.copy(CWIPCLVSTS_SEQ.LINE_ID, sizeof(CWIPCLVSTS_SEQ.LINE_ID), Tran_List[i], "LINE_ID");
		TRS.copy(CWIPCLVSTS_SEQ.RES_ID, sizeof(CWIPCLVSTS_SEQ.RES_ID), Tran_List[i], "RES_ID");
		TRS.copy(CWIPCLVSTS_SEQ.TRAN_DATE, sizeof(CWIPCLVSTS_SEQ.TRAN_DATE), Tran_List[i], "TRAN_DATE");
		TRS.copy(CWIPCLVSTS_SEQ.TRAN_TIME, sizeof(CWIPCLVSTS_SEQ.TRAN_TIME), Tran_List[i], "TRAN_TIME");

		i_max_ins_seq = CDB_select_cwipclvsts_scalar(2, &CWIPCLVSTS_SEQ);
		if(DB_error_code != DB_SUCCESS)
		{
			//return MP_TRUE;
		}

		//데이터 변경여부 체크 start
		CDB_init_cwipclvsts(&CWIPCLVSTS_EXIST);
		TRS.copy(CWIPCLVSTS_EXIST.FACTORY, sizeof(CWIPCLVSTS_EXIST.FACTORY), Tran_List[i], "FACTORY");
		TRS.copy(CWIPCLVSTS_EXIST.LINE_ID, sizeof(CWIPCLVSTS_EXIST.LINE_ID), Tran_List[i], "LINE_ID");
		TRS.copy(CWIPCLVSTS_EXIST.RES_ID, sizeof(CWIPCLVSTS_EXIST.RES_ID), Tran_List[i], "RES_ID");
		TRS.copy(CWIPCLVSTS_SEQ.TRAN_DATE, sizeof(CWIPCLVSTS_SEQ.TRAN_DATE), Tran_List[i], "TRAN_DATE");
		TRS.copy(CWIPCLVSTS_SEQ.TRAN_TIME, sizeof(CWIPCLVSTS_SEQ.TRAN_TIME), Tran_List[i], "TRAN_TIME");
		CWIPCLVSTS_EXIST.SEQ = i_max_ins_seq;
		TRS.copy(CWIPCLVSTS_EXIST.COMMENT_1, sizeof(CWIPCLVSTS_EXIST.COMMENT_1), Tran_List[i], "COMMENT_1");
		CWIPCLVSTS.HALF_CELL_SAP = TRS.get_int(Tran_List[i], "HALF_CELL_SAP");
		CWIPCLVSTS.HALF_CELL_LINE = TRS.get_int(Tran_List[i], "HALF_CELL_LINE");
		CWIPCLVSTS.FULL_CELL_SAP = TRS.get_int(Tran_List[i], "FULL_CELL_SAP");
		CWIPCLVSTS.CELL_UNPACK = TRS.get_int(Tran_List[i], "CELL_UNPACK");

		if(CDB_select_cwipclvsts_scalar(3, &CWIPCLVSTS_EXIST) > 0){
			continue;
		}
		//데이터 변경여부 체크 end

		CWIPCLVSTS.SEQ = ++i_max_ins_seq;
		
		CDB_insert_cwipclvsts(&CWIPCLVSTS);
	}
	
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 