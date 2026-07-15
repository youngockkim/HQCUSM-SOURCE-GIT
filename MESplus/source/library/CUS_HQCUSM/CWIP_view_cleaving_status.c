/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_cleaving_status.c
    Description : View Cleaving_Status function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Cleaving_Status()
            + View Cleaving_Status definition
        - CWIP_VIEW_CLEAVING_STATUS()
            + Main sub function of CWIP_View_Cleaving_Status function
            + View Cleaving_Status definition
    Detail Description
        - CWIP_VIEW_CLEAVING_STATUS()
            + h_proc_step
                + 1 : View Cleaving_Status definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-02-09             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
/*******************************************************************************
    CWIP_View_Cleaving_Status()
        - View Cleaving_Status definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Cleaving_Status(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_CLEAVING_STATUS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_CLEAVING_STATUS", out_node);

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
    CWIP_VIEW_CLEAVING_STATUS()
        - Main sub function of "CWIP_View_Cleaving_Status" function
        - View Cleaving_Status definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_CLEAVING_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPCLVSTS_TAG CWIPCLVSTS;

    TRSNode *list_item;
    int i_step;

    LOG_head("CWIP_VIEW_CLEAVING_STATUS");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	i_step = 2;

    CDB_init_cwipclvsts(&CWIPCLVSTS);
    TRS.copy(CWIPCLVSTS.FACTORY, sizeof(CWIPCLVSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPCLVSTS.LINE_ID, sizeof(CWIPCLVSTS.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPCLVSTS.TRAN_DATE, sizeof(CWIPCLVSTS.TRAN_DATE), in_node, "TRAN_DATE");
    TRS.copy(CWIPCLVSTS.TRAN_TIME, sizeof(CWIPCLVSTS.TRAN_TIME), in_node, "TRAN_TIME");
    //CWIPCLVSTS.SEQ = TRS.get_int(in_node, "SEQ");
    //CDB_select_cwipclvsts(2, &CWIPCLVSTS);
	CDB_open_cwipclvsts(i_step, &CWIPCLVSTS);


	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "RAS-0004");
		TRS.add_fieldmsg(out_node, "CWIPCLVSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVSTS.FACTORY), CWIPCLVSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVSTS.LINE_ID), CWIPCLVSTS.LINE_ID);
        TRS.add_fieldmsg(out_node, "TRAN_DATE", MP_STR, sizeof(CWIPCLVSTS.TRAN_DATE), CWIPCLVSTS.TRAN_DATE);
        TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CWIPCLVSTS.TRAN_TIME), CWIPCLVSTS.TRAN_TIME);
		TRS.add_dberrmsg(out_node, DB_error_msg);
			
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
    while(1)
		{
			CDB_fetch_cwipclvsts(i_step, &CWIPCLVSTS);

			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwipclvsts(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "CWIPCLVSTS FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVSTS.FACTORY), CWIPCLVSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVSTS.LINE_ID), CWIPCLVSTS.LINE_ID);
				TRS.add_fieldmsg(out_node, "TRAN_DATE", MP_STR, sizeof(CWIPCLVSTS.TRAN_DATE), CWIPCLVSTS.TRAN_DATE);
				TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CWIPCLVSTS.TRAN_TIME), CWIPCLVSTS.TRAN_TIME);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cwipclvsts(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				
				CDB_close_cwipclvsts(i_step);
				break;
			}

			list_item = TRS.add_node(out_node, "LIST");

			TRS.add_string(list_item, "FACTORY", CWIPCLVSTS.FACTORY, sizeof(CWIPCLVSTS.FACTORY));
			TRS.add_string(list_item, "LINE_ID", CWIPCLVSTS.LINE_ID, sizeof(CWIPCLVSTS.LINE_ID));
			TRS.add_string(list_item, "RES_ID", CWIPCLVSTS.RES_ID, sizeof(CWIPCLVSTS.RES_ID));
			TRS.add_string(list_item, "TRAN_DATE", CWIPCLVSTS.TRAN_DATE, sizeof(CWIPCLVSTS.TRAN_DATE));
			TRS.add_string(list_item, "TRAN_TIME", CWIPCLVSTS.TRAN_TIME, sizeof(CWIPCLVSTS.TRAN_TIME));
			TRS.add_int(list_item, "SEQ", CWIPCLVSTS.SEQ);
			TRS.add_string(list_item, "COMMENT_1", CWIPCLVSTS.COMMENT_1, sizeof(CWIPCLVSTS.COMMENT_1));
			TRS.add_int(list_item, "HALF_CELL_SAP", CWIPCLVSTS.HALF_CELL_SAP);
			TRS.add_int(list_item, "HALF_CELL_LINE", CWIPCLVSTS.HALF_CELL_LINE);
			TRS.add_int(list_item, "FULL_CELL_SAP", CWIPCLVSTS.FULL_CELL_SAP);
			TRS.add_int(list_item, "CELL_UNPACK", CWIPCLVSTS.CELL_UNPACK);
			TRS.add_string(list_item, "CMF_1", CWIPCLVSTS.CMF_1, sizeof(CWIPCLVSTS.CMF_1));
			TRS.add_string(list_item, "CMF_2", CWIPCLVSTS.CMF_2, sizeof(CWIPCLVSTS.CMF_2));
			TRS.add_string(list_item, "CMF_3", CWIPCLVSTS.CMF_3, sizeof(CWIPCLVSTS.CMF_3));
			TRS.add_string(list_item, "CMF_4", CWIPCLVSTS.CMF_4, sizeof(CWIPCLVSTS.CMF_4));
			TRS.add_string(list_item, "CMF_5", CWIPCLVSTS.CMF_5, sizeof(CWIPCLVSTS.CMF_5));
			TRS.add_string(list_item, "CREATE_USER_ID", CWIPCLVSTS.CREATE_USER_ID, sizeof(CWIPCLVSTS.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CWIPCLVSTS.CREATE_TIME, sizeof(CWIPCLVSTS.CREATE_TIME));
		}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

