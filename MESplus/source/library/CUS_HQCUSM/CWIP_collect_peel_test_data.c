/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_collect_peel_test_data.c
    Description : Collect_Peel_Test_Data Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Collect_Peel_Test_Data()
            + Create/Update/Delete Collect_Peel_Test_Data definition
        - CWIP_COLLECT_PEEL_TEST_DATA()
            + Main sub function of CWIP_Collect_Peel_Test_Data function
            + Create/Update/Delete Collect_Peel_Test_Data definition
        - CWIP_Collect_Peel_Test_Data_Validation()
            + Main sub function of CWIP_COLLECT_PEEL_TEST_DATA function
            + Check the condition for create/update/delete Collect_Peel_Test_Data
    Detail Description
        - CWIP_COLLECT_PEEL_TEST_DATA()
            + h_proc_step
                + MP_STEP_CREATE : Create Collect_Peel_Test_Data definition
                + MP_STEP_UPDATE : Update Collect_Peel_Test_Data definition
                + MP_STEP_DELETE : Delete Collect_Peel_Test_Data definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-09-27             °­º´Ã¤

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Collect_Peel_Test_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Collect_Peel_Test_Data()
        - Create/Update/Delete Collect_Peel_Test_Data definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Collect_Peel_Test_Data(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_LONG_STRING];
    int i_ret = MP_TRUE;
	int inx;
	int last_hist_seq = 0;
	TRSNode** peelList;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	peelList = TRS.get_list(in_node, "PEEL_LIST");
	
	if ( peelList ) 
		last_hist_seq = CWIP_Get_Last_Seq(peelList[0]);

	for ( inx = 0; inx < TRS.get_item_count( in_node, "PEEL_LIST") && i_ret; inx++ ) 
	{	
		i_ret = CWIP_COLLECT_PEEL_TEST_DATA(s_msg_code, last_hist_seq, peelList[inx], out_node);
	}	

	if(i_ret == MP_TRUE)
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		DB_commit();
	}
	else
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		DB_rollback();
	}

	COM_out_msg_log_write(s_msg_code, "CWIP_COLLECT_PEEL_TEST_DATA", out_node);

    return MP_TRUE;
}

/*******************************************************************************
    CWIP_Get_Last_Seq()
        - Main sub function of "CWIP_Get_Last_Seq" function
        - select last_hist_seq
    Return Value
        - int : 0 if no sequence else last_hist_seq
    Arguments
        - TRSNode *in_node : Input Message structure
*******************************************************************************/
int CWIP_Get_Last_Seq(TRSNode *in_node ) 
{
	struct CWIPCTWPFT_TAG CWIPCTWPFT_u;

	CDB_init_cwipctwpft(&CWIPCTWPFT_u);
	TRS.copy(CWIPCTWPFT_u.FACTORY, sizeof(CWIPCTWPFT_u.FACTORY), in_node, "FACTORY");
	TRS.copy(CWIPCTWPFT_u.WORK_DATE, sizeof(CWIPCTWPFT_u.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(CWIPCTWPFT_u.WORK_TIME, sizeof(CWIPCTWPFT_u.WORK_TIME), in_node, "WORK_TIME");
	TRS.copy(CWIPCTWPFT_u.TYPE, sizeof(CWIPCTWPFT_u.TYPE), in_node, "TYPE");
	TRS.copy(CWIPCTWPFT_u.LINE_ID, sizeof(CWIPCTWPFT_u.LINE_ID), in_node, "LINE_ID");
	CWIPCTWPFT_u.TAB_NO = TRS.get_int(in_node, "TAB_NO");
	TRS.copy(CWIPCTWPFT_u.LR, sizeof(CWIPCTWPFT_u.LR), in_node, "LR");
	CWIPCTWPFT_u.POS = TRS.get_int(in_node, "POS");

	CDB_select_cwipctwpft(1, &CWIPCTWPFT_u);

	if(DB_error_code != DB_SUCCESS)
	{
		return 0;
	}

	return CWIPCTWPFT_u.LAST_HIST_SEQ + 1;
}
/*******************************************************************************
    CWIP_COLLECT_PEEL_TEST_DATA()
        - Main sub function of "CWIP_Collect_Peel_Test_Data" function
        - Create/Update/Delete Collect_Peel_Test_Data definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_COLLECT_PEEL_TEST_DATA(char *s_msg_code, int last_hist_seq, TRSNode *in_node, TRSNode *out_node)
{
	double d_max_seq_num;
    
	struct CWIPCTWPFT_TAG CWIPCTWPFT;
    struct CWIPCTWPFT_TAG CWIPCTWPFT_u;
	struct CWIPCTWHIS_TAG CWIPCTWHIS;

    char   s_sys_time[14];

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

    if(CWIP_Collect_Peel_Test_Data_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    } 

	CDB_init_cwipctwpft(&CWIPCTWPFT);
	TRS.copy(CWIPCTWPFT.FACTORY, sizeof(CWIPCTWPFT.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPCTWPFT.WORK_DATE, sizeof(CWIPCTWPFT.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(CWIPCTWPFT.WORK_TIME, sizeof(CWIPCTWPFT.WORK_TIME), in_node, "WORK_TIME");
	TRS.copy(CWIPCTWPFT.TYPE, sizeof(CWIPCTWPFT.TYPE), in_node, "TYPE");
	TRS.copy(CWIPCTWPFT.LINE_ID, sizeof(CWIPCTWPFT.LINE_ID), in_node, "LINE_ID");
	CWIPCTWPFT.TAB_NO = TRS.get_int(in_node, "TAB_NO");
	TRS.copy(CWIPCTWPFT.LR, sizeof(CWIPCTWPFT.LR), in_node, "LR");
	CWIPCTWPFT.POS = TRS.get_int(in_node, "POS");
	TRS.copy(CWIPCTWPFT.POS_FR_1, sizeof(CWIPCTWPFT.POS_FR_1), in_node, "POS_FR_1");
	TRS.copy(CWIPCTWPFT.POS_FR_2, sizeof(CWIPCTWPFT.POS_FR_2), in_node, "POS_FR_2");
	TRS.copy(CWIPCTWPFT.POS_FR_3, sizeof(CWIPCTWPFT.POS_FR_3), in_node, "POS_FR_3");
	TRS.copy(CWIPCTWPFT.POS_FR_4, sizeof(CWIPCTWPFT.POS_FR_4), in_node, "POS_FR_4");
	TRS.copy(CWIPCTWPFT.POS_FR_5, sizeof(CWIPCTWPFT.POS_FR_5), in_node, "POS_FR_5");
	TRS.copy(CWIPCTWPFT.POS_FR_6, sizeof(CWIPCTWPFT.POS_FR_6), in_node, "POS_FR_6");
	TRS.copy(CWIPCTWPFT.POS_FR_7, sizeof(CWIPCTWPFT.POS_FR_7), in_node, "POS_FR_7");
	TRS.copy(CWIPCTWPFT.POS_FR_8, sizeof(CWIPCTWPFT.POS_FR_8), in_node, "POS_FR_8");
	TRS.copy(CWIPCTWPFT.POS_FR_9, sizeof(CWIPCTWPFT.POS_FR_9), in_node, "POS_FR_9");
	TRS.copy(CWIPCTWPFT.POS_FR_10, sizeof(CWIPCTWPFT.POS_FR_10), in_node, "POS_FR_10");
	TRS.copy(CWIPCTWPFT.POS_FR_11, sizeof(CWIPCTWPFT.POS_FR_11), in_node, "POS_FR_11");
	TRS.copy(CWIPCTWPFT.POS_FR_12, sizeof(CWIPCTWPFT.POS_FR_12), in_node, "POS_FR_12");
	TRS.copy(CWIPCTWPFT.POS_RE_1, sizeof(CWIPCTWPFT.POS_RE_1), in_node, "POS_RE_1");
	TRS.copy(CWIPCTWPFT.POS_RE_2, sizeof(CWIPCTWPFT.POS_RE_2), in_node, "POS_RE_2");
	TRS.copy(CWIPCTWPFT.POS_RE_3, sizeof(CWIPCTWPFT.POS_RE_3), in_node, "POS_RE_3");
	TRS.copy(CWIPCTWPFT.POS_RE_4, sizeof(CWIPCTWPFT.POS_RE_4), in_node, "POS_RE_4");
	TRS.copy(CWIPCTWPFT.POS_RE_5, sizeof(CWIPCTWPFT.POS_RE_5), in_node, "POS_RE_5");
	TRS.copy(CWIPCTWPFT.POS_RE_6, sizeof(CWIPCTWPFT.POS_RE_6), in_node, "POS_RE_6");
	TRS.copy(CWIPCTWPFT.POS_RE_7, sizeof(CWIPCTWPFT.POS_RE_7), in_node, "POS_RE_7");
	TRS.copy(CWIPCTWPFT.POS_RE_8, sizeof(CWIPCTWPFT.POS_RE_8), in_node, "POS_RE_8");
	TRS.copy(CWIPCTWPFT.POS_RE_9, sizeof(CWIPCTWPFT.POS_RE_9), in_node, "POS_RE_9");
	TRS.copy(CWIPCTWPFT.POS_RE_10, sizeof(CWIPCTWPFT.POS_RE_10), in_node, "POS_RE_10");
	TRS.copy(CWIPCTWPFT.POS_RE_11, sizeof(CWIPCTWPFT.POS_RE_11), in_node, "POS_RE_11");
	TRS.copy(CWIPCTWPFT.POS_RE_12, sizeof(CWIPCTWPFT.POS_RE_12), in_node, "POS_RE_12");
	TRS.copy(CWIPCTWPFT.INS_USER_ID, sizeof(CWIPCTWPFT.INS_USER_ID), in_node, "INS_USER_ID");
	CWIPCTWPFT.LAST_HIST_SEQ = last_hist_seq + 1;
	TRS.copy(CWIPCTWPFT.CMF_1, sizeof(CWIPCTWPFT.CMF_1), in_node, "CMF_1");
	TRS.copy(CWIPCTWPFT.CMF_2, sizeof(CWIPCTWPFT.CMF_2), in_node, "CMF_2");
	TRS.copy(CWIPCTWPFT.CMF_3, sizeof(CWIPCTWPFT.CMF_3), in_node, "CMF_3");
	TRS.copy(CWIPCTWPFT.CMF_4, sizeof(CWIPCTWPFT.CMF_4), in_node, "CMF_4");
	TRS.copy(CWIPCTWPFT.CMF_5, sizeof(CWIPCTWPFT.CMF_5), in_node, "CMF_5");
	TRS.copy(CWIPCTWPFT.CMF_6, sizeof(CWIPCTWPFT.CMF_6), in_node, "CMF_6");
	TRS.copy(CWIPCTWPFT.CMF_7, sizeof(CWIPCTWPFT.CMF_7), in_node, "CMF_7");
	TRS.copy(CWIPCTWPFT.CMF_8, sizeof(CWIPCTWPFT.CMF_8), in_node, "CMF_8");
	TRS.copy(CWIPCTWPFT.CMF_9, sizeof(CWIPCTWPFT.CMF_9), in_node, "CMF_9");
	TRS.copy(CWIPCTWPFT.CMF_10, sizeof(CWIPCTWPFT.CMF_10), in_node, "CMF_10");
	CWIPCTWPFT.INS_CNT = TRS.get_int(in_node, "INS_CNT");

	//----[Addtional Logic for Create Case]----
	memcpy(CWIPCTWPFT.INS_TIME, s_sys_time, sizeof(CWIPCTWPFT.INS_TIME));

	CDB_insert_cwipctwpft(&CWIPCTWPFT);
	if(DB_error_code != DB_SUCCESS)
	{
		if ( DB_error_code == DB_DUPLICATE ) {
			CDB_init_cwipctwpft(&CWIPCTWPFT_u);
			memcpy(CWIPCTWPFT_u.FACTORY, CWIPCTWPFT.FACTORY, sizeof(CWIPCTWPFT.FACTORY));
			memcpy(CWIPCTWPFT_u.WORK_DATE, CWIPCTWPFT.WORK_DATE, sizeof(CWIPCTWPFT.WORK_DATE));
			memcpy(CWIPCTWPFT_u.WORK_TIME, CWIPCTWPFT.WORK_TIME, sizeof(CWIPCTWPFT.WORK_TIME));
			memcpy(CWIPCTWPFT_u.TYPE, CWIPCTWPFT.TYPE, sizeof(CWIPCTWPFT.TYPE));
			memcpy(CWIPCTWPFT_u.LINE_ID, CWIPCTWPFT.LINE_ID, sizeof(CWIPCTWPFT.LINE_ID));
			CWIPCTWPFT_u.TAB_NO = CWIPCTWPFT.TAB_NO;
			CWIPCTWPFT_u.POS = CWIPCTWPFT.POS;
			memcpy(CWIPCTWPFT_u.LR, CWIPCTWPFT.LR, sizeof(CWIPCTWPFT.LR));
			CDB_select_cwipctwpft(1, &CWIPCTWPFT_u);

			CWIPCTWPFT.LAST_HIST_SEQ = last_hist_seq;

			CDB_update_cwipctwpft(1, &CWIPCTWPFT);
		} else {
			strcpy(s_msg_code, "CWIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPCTWPFT INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTWPFT.FACTORY), CWIPCTWPFT.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTWPFT.WORK_DATE), CWIPCTWPFT.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CWIPCTWPFT.WORK_TIME), CWIPCTWPFT.WORK_TIME);
			TRS.add_fieldmsg(out_node, "TYPE", MP_STR, sizeof(CWIPCTWPFT.TYPE), CWIPCTWPFT.TYPE);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTWPFT.LINE_ID), CWIPCTWPFT.LINE_ID);
			TRS.add_fieldmsg(out_node, "TAB_NO", MP_INT, CWIPCTWPFT.TAB_NO);
			TRS.add_fieldmsg(out_node, "LR", MP_STR, sizeof(CWIPCTWPFT.LR), CWIPCTWPFT.LR);
			TRS.add_fieldmsg(out_node, "POS", MP_INT, CWIPCTWPFT.POS);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

		
	/* History */
	CDB_init_cwipctwhis(&CWIPCTWHIS);
	memcpy(CWIPCTWHIS.FACTORY, CWIPCTWPFT.FACTORY, sizeof(CWIPCTWPFT.FACTORY));
	memcpy(CWIPCTWHIS.WORK_DATE, CWIPCTWPFT.WORK_DATE, sizeof(CWIPCTWPFT.WORK_DATE));
	memcpy(CWIPCTWHIS.WORK_TIME, CWIPCTWPFT.WORK_TIME, sizeof(CWIPCTWPFT.WORK_TIME));
	memcpy(CWIPCTWHIS.TYPE, CWIPCTWPFT.TYPE, sizeof(CWIPCTWPFT.TYPE));
	memcpy(CWIPCTWHIS.LINE_ID, CWIPCTWPFT.LINE_ID, sizeof(CWIPCTWPFT.LINE_ID));
	CWIPCTWHIS.TAB_NO = CWIPCTWPFT.TAB_NO;
	CWIPCTWHIS.POS = CWIPCTWPFT.POS;
	memcpy(CWIPCTWHIS.LR, CWIPCTWPFT.LR, sizeof(CWIPCTWPFT.LR));
	memcpy(CWIPCTWHIS.POS_FR_1, CWIPCTWPFT.POS_FR_1, sizeof(CWIPCTWPFT.POS_FR_1));
	memcpy(CWIPCTWHIS.POS_FR_2, CWIPCTWPFT.POS_FR_2, sizeof(CWIPCTWPFT.POS_FR_2));
	memcpy(CWIPCTWHIS.POS_FR_3, CWIPCTWPFT.POS_FR_3, sizeof(CWIPCTWPFT.POS_FR_3));
	memcpy(CWIPCTWHIS.POS_FR_4, CWIPCTWPFT.POS_FR_4, sizeof(CWIPCTWPFT.POS_FR_4));
	memcpy(CWIPCTWHIS.POS_FR_5, CWIPCTWPFT.POS_FR_5, sizeof(CWIPCTWPFT.POS_FR_5));
	memcpy(CWIPCTWHIS.POS_FR_6, CWIPCTWPFT.POS_FR_6, sizeof(CWIPCTWPFT.POS_FR_6));
	memcpy(CWIPCTWHIS.POS_FR_7, CWIPCTWPFT.POS_FR_7, sizeof(CWIPCTWPFT.POS_FR_7));
	memcpy(CWIPCTWHIS.POS_FR_8, CWIPCTWPFT.POS_FR_8, sizeof(CWIPCTWPFT.POS_FR_8));
	memcpy(CWIPCTWHIS.POS_FR_9, CWIPCTWPFT.POS_FR_9, sizeof(CWIPCTWPFT.POS_FR_9));
	memcpy(CWIPCTWHIS.POS_FR_10, CWIPCTWPFT.POS_FR_10, sizeof(CWIPCTWPFT.POS_FR_10));
	memcpy(CWIPCTWHIS.POS_FR_11, CWIPCTWPFT.POS_FR_11, sizeof(CWIPCTWPFT.POS_FR_11));
	memcpy(CWIPCTWHIS.POS_FR_12, CWIPCTWPFT.POS_FR_12, sizeof(CWIPCTWPFT.POS_FR_12));
	memcpy(CWIPCTWHIS.POS_RE_1, CWIPCTWPFT.POS_RE_1, sizeof(CWIPCTWPFT.POS_RE_1));
	memcpy(CWIPCTWHIS.POS_RE_2, CWIPCTWPFT.POS_RE_2, sizeof(CWIPCTWPFT.POS_RE_2));
	memcpy(CWIPCTWHIS.POS_RE_3, CWIPCTWPFT.POS_RE_3, sizeof(CWIPCTWPFT.POS_RE_3));
	memcpy(CWIPCTWHIS.POS_RE_4, CWIPCTWPFT.POS_RE_4, sizeof(CWIPCTWPFT.POS_RE_4));
	memcpy(CWIPCTWHIS.POS_RE_5, CWIPCTWPFT.POS_RE_5, sizeof(CWIPCTWPFT.POS_RE_5));
	memcpy(CWIPCTWHIS.POS_RE_6, CWIPCTWPFT.POS_RE_6, sizeof(CWIPCTWPFT.POS_RE_6));
	memcpy(CWIPCTWHIS.POS_RE_7, CWIPCTWPFT.POS_RE_7, sizeof(CWIPCTWPFT.POS_RE_7));
	memcpy(CWIPCTWHIS.POS_RE_8, CWIPCTWPFT.POS_RE_8, sizeof(CWIPCTWPFT.POS_RE_8));
	memcpy(CWIPCTWHIS.POS_RE_9, CWIPCTWPFT.POS_RE_9, sizeof(CWIPCTWPFT.POS_RE_9));
	memcpy(CWIPCTWHIS.POS_RE_10, CWIPCTWPFT.POS_RE_10, sizeof(CWIPCTWPFT.POS_RE_10));
	memcpy(CWIPCTWHIS.POS_RE_11, CWIPCTWPFT.POS_RE_11, sizeof(CWIPCTWPFT.POS_RE_11));
	memcpy(CWIPCTWHIS.POS_RE_12, CWIPCTWPFT.POS_RE_12, sizeof(CWIPCTWPFT.POS_RE_12));
	memcpy(CWIPCTWHIS.CMF_1, CWIPCTWPFT.CMF_1, sizeof(CWIPCTWPFT.CMF_1));
	memcpy(CWIPCTWHIS.CMF_2, CWIPCTWPFT.CMF_2, sizeof(CWIPCTWPFT.CMF_2));
	memcpy(CWIPCTWHIS.CMF_3, CWIPCTWPFT.CMF_3, sizeof(CWIPCTWPFT.CMF_3));
	memcpy(CWIPCTWHIS.CMF_4, CWIPCTWPFT.CMF_4, sizeof(CWIPCTWPFT.CMF_4));
	memcpy(CWIPCTWHIS.CMF_5, CWIPCTWPFT.CMF_5, sizeof(CWIPCTWPFT.CMF_5));
	memcpy(CWIPCTWHIS.CMF_6, CWIPCTWPFT.CMF_6, sizeof(CWIPCTWPFT.CMF_6));
	memcpy(CWIPCTWHIS.CMF_7, CWIPCTWPFT.CMF_7, sizeof(CWIPCTWPFT.CMF_7));
	memcpy(CWIPCTWHIS.CMF_8, CWIPCTWPFT.CMF_8, sizeof(CWIPCTWPFT.CMF_8));
	memcpy(CWIPCTWHIS.CMF_9, CWIPCTWPFT.CMF_9, sizeof(CWIPCTWPFT.CMF_9));
	memcpy(CWIPCTWHIS.CMF_10, CWIPCTWPFT.CMF_10, sizeof(CWIPCTWPFT.CMF_10));
	CWIPCTWHIS.INS_CNT = CWIPCTWPFT.INS_CNT + 1;
	memcpy(CWIPCTWHIS.INS_TIME, CWIPCTWPFT.INS_TIME, sizeof(CWIPCTWPFT.INS_TIME));
	memcpy(CWIPCTWHIS.INS_USER_ID, CWIPCTWPFT.INS_USER_ID, sizeof(CWIPCTWPFT.INS_USER_ID));
	CWIPCTWHIS.HIST_SEQ = CWIPCTWPFT.LAST_HIST_SEQ;
	memcpy(CWIPCTWHIS.TRAN_TIME, s_sys_time, sizeof(CWIPCTWPFT.INS_TIME));
	memcpy(CWIPCTWHIS.SYS_TRAN_TIME, s_sys_time, sizeof(CWIPCTWHIS.SYS_TRAN_TIME));


	CDB_insert_cwipctwhis(&CWIPCTWHIS);
	if(DB_error_code != DB_SUCCESS)
	{
		/*strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "CWIPCTWHIS INSERT", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
		*/
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Collect_Peel_Test_Data_Validation()
        - Main sub function of "CWIP_COLLECT_PEEL_TEST_DATA" function
        - Check the condition for create/update/delete Collect_Peel_Test_Data
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Collect_Peel_Test_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPCTWPFT_TAG CWIPCTWPFT;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

	/* Factory Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
	{
		strcpy(s_msg_code, "CWIP-0001");
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

	/* WORK_DATE Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
	{
		strcpy(s_msg_code, "CWIP-0001");
		TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* WORK_TIME Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "WORK_TIME")) == MP_TRUE)
	{
		strcpy(s_msg_code, "CWIP-0001");
		TRS.add_fieldmsg(out_node, "WORK_TIME", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* TYPE Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "TYPE")) == MP_TRUE)
	{
		strcpy(s_msg_code, "CWIP-0001");
		TRS.add_fieldmsg(out_node, "TYPE", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* LINE_ID Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "CWIP-0001");
		TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* TAB_NO Validation */
	if(TRS.get_string(in_node, "TAB_NO") == 0)
	{
		strcpy(s_msg_code, "CWIP-0001");
		TRS.add_fieldmsg(out_node, "TAB_NO", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* LR Validation */
	if(COM_isnullspace(TRS.get_string(in_node, "LR")) == MP_TRUE)
	{
		strcpy(s_msg_code, "CWIP-0001");
		TRS.add_fieldmsg(out_node, "LR", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* POS Validation */
	if(TRS.get_string(in_node, "POS") == 0)
	{
		strcpy(s_msg_code, "CWIP-0001");
		TRS.add_fieldmsg(out_node, "POS", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}


    CDB_init_cwipctwpft(&CWIPCTWPFT);
    TRS.copy(CWIPCTWPFT.FACTORY, sizeof(CWIPCTWPFT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPCTWPFT.WORK_DATE, sizeof(CWIPCTWPFT.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPCTWPFT.WORK_TIME, sizeof(CWIPCTWPFT.WORK_TIME), in_node, "WORK_TIME");
    TRS.copy(CWIPCTWPFT.TYPE, sizeof(CWIPCTWPFT.TYPE), in_node, "TYPE");
    TRS.copy(CWIPCTWPFT.LINE_ID, sizeof(CWIPCTWPFT.LINE_ID), in_node, "LINE_ID");
    CWIPCTWPFT.TAB_NO = TRS.get_int(in_node, "TAB_NO");
    TRS.copy(CWIPCTWPFT.LR, sizeof(CWIPCTWPFT.LR), in_node, "LR");
    CWIPCTWPFT.POS = TRS.get_int(in_node, "POS");
    CDB_select_cwipctwpft(1, &CWIPCTWPFT);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
/*            strcpy(s_msg_code, "CWIP-XXXX");
            TRS.add_fieldmsg(out_node, "CWIPCTWPFT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTWPFT.FACTORY), CWIPCTWPFT.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTWPFT.WORK_DATE), CWIPCTWPFT.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CWIPCTWPFT.WORK_TIME), CWIPCTWPFT.WORK_TIME);
            TRS.add_fieldmsg(out_node, "TYPE", MP_STR, sizeof(CWIPCTWPFT.TYPE), CWIPCTWPFT.TYPE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTWPFT.LINE_ID), CWIPCTWPFT.LINE_ID);
            TRS.add_fieldmsg(out_node, "TAB_NO", MP_INT, CWIPCTWPFT.TAB_NO);
            TRS.add_fieldmsg(out_node, "LR", MP_STR, sizeof(CWIPCTWPFT.LR), CWIPCTWPFT.LR);
            TRS.add_fieldmsg(out_node, "POS", MP_INT, CWIPCTWPFT.POS);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;*/
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
/*            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "CWIP-XXXX");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CWIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CWIPCTWPFT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCTWPFT.FACTORY), CWIPCTWPFT.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCTWPFT.WORK_DATE), CWIPCTWPFT.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CWIPCTWPFT.WORK_TIME), CWIPCTWPFT.WORK_TIME);
            TRS.add_fieldmsg(out_node, "TYPE", MP_STR, sizeof(CWIPCTWPFT.TYPE), CWIPCTWPFT.TYPE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCTWPFT.LINE_ID), CWIPCTWPFT.LINE_ID);
            TRS.add_fieldmsg(out_node, "TAB_NO", MP_INT, CWIPCTWPFT.TAB_NO);
            TRS.add_fieldmsg(out_node, "LR", MP_STR, sizeof(CWIPCTWPFT.LR), CWIPCTWPFT.LR);
            TRS.add_fieldmsg(out_node, "POS", MP_INT, CWIPCTWPFT.POS);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE; */
        }
    }

    return MP_TRUE;
}

