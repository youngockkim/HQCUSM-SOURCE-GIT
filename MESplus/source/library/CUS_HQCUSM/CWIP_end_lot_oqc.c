/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_end_lot.c
    Description : EAPMES End Lot Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_End_Lot()
            + Setup service interface function
        - EAPMES_END_LOT()
            + Main sub function of EAPMES_End_Lot function
            + Setup service main business function
        - EAPMES_End_Lot_Validation()
            + Main sub function of EAPMES_END_LOT function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_END_LOT()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_End_Lot_Oqc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_End_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_End_Lot_Oqc(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100];
    int i_ret;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
    
    i_ret = CWIP_END_LOT_OQC(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_END_LOT_OQC", out_node);

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
    EAPMES_END_LOT()
        - Main sub function of "EAPMES_End_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_END_LOT_OQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;

	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
	struct CEDCINSDAT_TAG CEDCINSDAT;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_G;
	struct CWIPGRTAVG_TAG CWIPGRTAVG;

	int d_max_seq_num;
	char res_id[20];
	char s_sys_time[14];

	TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("CWIP_END_LOT_OQC");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

	if(CWIP_End_Lot_Oqc_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//0. 설비 ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//Generate Grount Test Data at the End of FQC-01
	if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0 && memcmp(MRASRESDEF.RES_CMF_16, "518", strlen("518")) == 0)
	{
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0044");
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}

			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

//		memset(s_sys_time, ' ', sizeof(s_sys_time));
//		DB_get_systime(s_sys_time);

		// Check Ground Test
		// CEDCLOTRLT.INS_TYPE = GR
		CDB_init_cedclotrlt(&CEDCLOTRLT);
		memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CEDCLOTRLT.INS_TYPE, "GR", strlen("GR"));
		TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
		
		CDB_select_cedclotrlt(2,&CEDCLOTRLT);
		
		if(DB_error_code != DB_SUCCESS)
		{
			//if GR does not exist, create one.
			if(DB_error_code == DB_NOT_FOUND)
			{
				//change OPER = M3100
				memcpy(MWIPLOTSTS.OPER, "M3100", strlen("M3100"));
				DBC_update_mwiplotsts(1, &MWIPLOTSTS);
				
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "EDC-0004");
					TRS.set_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				TRS.copy(res_id, sizeof(res_id), in_node, "RES_ID");//US-E#-FQC-02
				//strcpy(res_id, TRS.get_string(in_node,"RES_ID"));	

				//US-E#-GRT-01
				res_id[6] = 'G';
				res_id[7] = 'R';
				res_id[8] = 'T';
				res_id[11] = '1';

				/* Start Lot */
				tran_in_node = TRS.create_node("START_LOT_IN");
				tran_out_node = TRS.create_node("START_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');  
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
				TRS.add_string(tran_in_node, "OPER", "M3100", strlen("M3100")); 
				TRS.add_nstring(tran_in_node, "RES_ID", res_id);
				TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
				
				if(CWIP_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					// Do Nothing
				}
    
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);

				CDB_init_cedclotrlt(&CEDCLOTRLT);

				memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CEDCLOTRLT.INS_TYPE, "GR", strlen("GR"));
				memcpy(CEDCLOTRLT.OPER, "M3100", strlen("M3100"));
				memcpy(CEDCLOTRLT.RES_ID, res_id, sizeof(res_id));
				
				TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
				TRS.copy(CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID), in_node, "LINE_ID");

				TRS.copy(CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID), in_node, "CLIENT_ID");
				memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));

				memcpy(CEDCLOTRLT.RESULT_VALUE, "OK", strlen("OK"));
				TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "CLIENT_ID");
				memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));

				CEDCLOTRLT.TYPE_FLAG = TRS.get_char(in_node, "TYPE_FLAG");
				CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ + 1;
				CEDCLOTRLT.QTY = 1;
				CEDCLOTRLT.INS_CNT = 1;

				memcpy(CEDCLOTRLT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				memcpy(CEDCLOTRLT.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				memcpy(CEDCLOTRLT.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
				TRS.copy(CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLT.LOC_ID), in_node, "LOC_ID");

				CDB_insert_cedclotrlt(&CEDCLOTRLT);	
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "EDC-0004");
					TRS.set_fieldmsg(out_node, "CEDCLOTRLT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				/* History */
				CDB_init_cedclotrlh(&CEDCLOTRLH);
				memcpy(CEDCLOTRLH.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLH.FACTORY));
				memcpy(CEDCLOTRLH.INS_TYPE, CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLH.INS_TYPE));
				memcpy(CEDCLOTRLH.OPER, CEDCLOTRLT.OPER, sizeof(CEDCLOTRLH.OPER));
				memcpy(CEDCLOTRLH.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLH.RES_ID));
				memcpy(CEDCLOTRLH.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID));
				memcpy(CEDCLOTRLH.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLH.LINE_ID));
				memcpy(CEDCLOTRLH.INS_USER_ID, CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLH.INS_USER_ID));
				memcpy(CEDCLOTRLH.INS_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLH.INS_TIME));
				memcpy(CEDCLOTRLH.RESULT_VALUE, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE));
				memcpy(CEDCLOTRLH.RESULT_USER_ID, CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID));
				memcpy(CEDCLOTRLH.RESULT_TIME, CEDCLOTRLT.RESULT_TIME, sizeof(CEDCLOTRLH.RESULT_TIME));
				memcpy(CEDCLOTRLH.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLH.MAT_ID));
				memcpy(CEDCLOTRLH.FLOW, CEDCLOTRLT.FLOW, sizeof(CEDCLOTRLH.FLOW));
				memcpy(CEDCLOTRLH.ORDER_ID, CEDCLOTRLT.ORDER_ID, sizeof(CEDCLOTRLH.ORDER_ID));
				memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1));
				memcpy(CEDCLOTRLH.LOC_ID, CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLH.LOC_ID));
				CEDCLOTRLH.TYPE_FLAG = CEDCLOTRLT.TYPE_FLAG;
				CEDCLOTRLH.HIST_SEQ = 1;
				CEDCLOTRLH.QTY = 1;
				CEDCLOTRLH.INS_CNT = 1;

				CDB_insert_cedclotrlh(&CEDCLOTRLH);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "EDC-0004");
					TRS.set_fieldmsg(out_node, "CEDCLOTRLH INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLH.FACTORY), CEDCLOTRLH.FACTORY);
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLH.INS_TYPE), CEDCLOTRLH.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
					TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CEDCLOTRLH.HIST_SEQ);
					TRS.add_fieldmsg(out_node, "INS_CNT", MP_INT, CEDCLOTRLH.INS_CNT);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				// Get Max Sequence Number
				d_max_seq_num = 0;
				CDB_init_cedcinsdat(&CEDCINSDAT);
				memcpy(CEDCINSDAT.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID));
				memcpy(CEDCINSDAT.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCINSDAT.RES_ID));
				//memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCINSDAT.TRAN_TIME));IS-21-01-094 MES logic 개선
				memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));

				d_max_seq_num = CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);

				// Common
				CDB_init_cedcinsdat(&CEDCINSDAT);
				memcpy(CEDCINSDAT.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID));
				memcpy(CEDCINSDAT.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCINSDAT.RES_ID));
				memcpy(CEDCINSDAT.TRAN_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));
				memcpy(CEDCINSDAT.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCINSDAT.LINE_ID));
				memcpy(CEDCINSDAT.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCINSDAT.FACTORY));
				memcpy(CEDCINSDAT.OPER, CEDCLOTRLT.OPER, sizeof(CEDCINSDAT.OPER));
				CEDCINSDAT.LOT_HIST_SEQ = CEDCLOTRLT.LAST_HIST_SEQ;

				//GET AVG GRT VALUES BY THE MAT_ID
				CDB_init_cedclotrlt(&CEDCLOTRLT_G);
				memcpy(CEDCLOTRLT_G.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT_G.MAT_ID));

				//20201002 HCHKIM CWIPGRTAVG CHECK
				CDB_init_cwipgrtavg(&CWIPGRTAVG);
				memcpy(CWIPGRTAVG.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(CWIPGRTAVG.MAT_ID));
			
				CDB_select_cwipgrtavg(1, &CWIPGRTAVG);
				if(DB_error_code != DB_SUCCESS)
				{
					if(DB_error_code == DB_NOT_FOUND)
					{
						CDB_select_cedclotrlt(3, &CEDCLOTRLT_G);
						if(DB_error_code != DB_SUCCESS)
						{
							//DO NOTHING
						}
					}
				}
				else
				{
					memcpy(CEDCLOTRLT_G.CMF_1, CWIPGRTAVG.STEP_1_MEASURE, sizeof(CEDCLOTRLT_G.CMF_1));
					memcpy(CEDCLOTRLT_G.CMF_2, CWIPGRTAVG.STEP_2_MEASURE, sizeof(CEDCLOTRLT_G.CMF_2));
					memcpy(CEDCLOTRLT_G.CMF_3, CWIPGRTAVG.STEP_3_MEASURE, sizeof(CEDCLOTRLT_G.CMF_3));
					memcpy(CEDCLOTRLT_G.CMF_4, CWIPGRTAVG.STEP_4_MEASURE, sizeof(CEDCLOTRLT_G.CMF_4));
				}
				//CDB_select_cedclotrlt(3, &CEDCLOTRLT_G);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_MODULE_ID", strlen("I_GRD_01_MODULE_ID"));
				TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.LOT_ID), in_node, "LOT_ID");
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_1_MEASURE_OHM", strlen("I_GRD_01_STEP_1_MEASURE_OHM"));
				memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_1, sizeof(CEDCLOTRLT_G.CMF_1));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_1_RESULT", strlen("I_GRD_01_STEP_1_RESULT"));
				CEDCINSDAT.PARAM_VALUE[0] = '0';
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_2_MEASURE_OHM", strlen("I_GRD_01_STEP_2_MEASURE_OHM"));
				memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_2, sizeof(CEDCLOTRLT_G.CMF_2));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_2_RESULT", strlen("I_GRD_01_STEP_2_RESULT"));
				CEDCINSDAT.PARAM_VALUE[0] = '0';
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_3_MEASURE_OHM", strlen("I_GRD_01_STEP_3_MEASURE_OHM"));
				memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_3, sizeof(CEDCLOTRLT_G.CMF_3));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_3_RESULT", strlen("I_GRD_01_STEP_3_RESULT"));
				CEDCINSDAT.PARAM_VALUE[0] = '0';
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_4_MEASURE_OHM", strlen("I_GRD_01_STEP_4_MEASURE_OHM"));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				if(memcmp(CEDCLOTRLT_G.CMF_4, "0.00000", 1) == 0)
				{
					memset(CEDCINSDAT.PARAM_VALUE, ' ', sizeof(CEDCINSDAT.PARAM_VALUE));
				}
				else
				{
					memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_G.CMF_4, sizeof(CEDCLOTRLT_G.CMF_4));
				}
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				memcpy(CEDCINSDAT.PARAM_NAME, "I_GRD_01_STEP_4_RESULT", strlen("I_GRD_01_STEP_4_RESULT"));
				CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
				if(memcmp(CEDCLOTRLT_G.CMF_4, "0.00000", 1) == 0)
				{
					memset(CEDCINSDAT.PARAM_VALUE, ' ', sizeof(CEDCINSDAT.PARAM_VALUE));
				}
				else
				{
					CEDCINSDAT.PARAM_VALUE[0] = '0';
				}
				CDB_insert_cedcinsdat(&CEDCINSDAT);

				/* End Lot */
				tran_in_node = TRS.create_node("END_LOT_IN");
				tran_out_node = TRS.create_node("END_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');  
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
				TRS.add_string(tran_in_node, "OPER", "M3100", strlen("M3100")); 
				TRS.add_nstring(tran_in_node, "RES_ID", res_id);
				TRS.add_string(tran_in_node, "TRAN_CMF_2", s_sys_time, sizeof(s_sys_time)); //TRAN_CMF_2 에 검사데이터 처리후 END 했을경우 해당 시간 넣음.
				TRS.add_char(tran_in_node, "INSPECT_FLAG", 'Y');
				if(CWIP_END_LOT_OQC(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					// Do Nothing
				}
    
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
			}
			else
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
		}
	}

	//현재 장비가 TRANSACIOTN 발생 장비가 아니면 Return True;
	if (MRASRESDEF.RES_CMF_4[0] != 'Y')
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}

    /* get material ID and  operation */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0044");
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (TRS.get_char(in_node, "INSPECT_FLAG") == 'Y')
	{
		//검사공정 검사결과를 받았을떄 END 하는 경우임.
		//이곳이외에는 일반 END임.
	}
	else if ((memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0) ||
				(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0))
	{
		//EL1 END 이면서 마지막 END 가 검사결과로 END 된 이력이면 END 하지 않음.
		DBC_init_mwiplothis(&MWIPLOTHIS);
		memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		DBC_select_mwiplothis(1, &MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DONOTHING
		}	
		//LOT 의 마지막 HISOTRY 를 뒤져서 TRAN_CMF_2(검사시간) 에 값이 있으면 검사완료후 자동으로 END 한것임.
		//LOT 의 검사데이터로 END 했을경우 다음 END 신호 무시
		if((COM_isspace(MWIPLOTHIS.TRAN_CMF_2, sizeof(MWIPLOTHIS.TRAN_CMF_2)) == MP_FALSE) &&
			(memcmp(MWIPLOTHIS.OLD_OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTHIS.OLD_OPER)) == 0) &&
			(memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) == 0)
		  )
		{
			//END 처리하지 않고 끝냄.
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}

		//EL 라인에서는 LOT END 하지 않음 ( 검사결과 받았을시만 END 하는것으로 변경함 (2019/01/24 JUHYEON)
		//COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		//return MP_TRUE;
	}
	else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0) 
	{
		//FQC Normal Operation End
		DBC_init_mwiplothis(&MWIPLOTHIS);
		memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		DBC_select_mwiplothis(1, &MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DONOTHING
		}	
		//LOT 의 마지막 HISOTRY 를 뒤져서 TRAN_CMF_2(검사시간) 에 값이 있으면 검사완료후 자동으로 END 한것임.2번 END 안함.
		//LOT 의 검사데이터로 END 했을경우 다음 END 신호 무시
		if((COM_isspace(MWIPLOTHIS.TRAN_CMF_2, sizeof(MWIPLOTHIS.TRAN_CMF_2)) == MP_FALSE) &&
			(memcmp(MWIPLOTHIS.OLD_OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTHIS.OLD_OPER)) == 0) &&
			(memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) == 0)
		  )
		{
			//END 처리하지 않고 끝냄.
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}

		//FQC 라인에서는 LOT END 하지 않음 ( 검사결과 받았을시만 END 하는것으로 변경함 (2019/05/02 JUHYEON)
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;

	}

	//LOT 이 현재공정이 아니면 현재공정까지 END 시킴.
	if (memcmp(MWIPLOTSTS.OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTSTS.OPER)) != 0)
	{
		/***************************************************/
		//END LOT -> 강제로
		/***************************************************/
		tran_in_node = TRS.create_node("START_LOT_IN");
		tran_out_node = TRS.create_node("START_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
		TRS.add_string(tran_in_node, "FLOW",MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM); 
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			
		//ERP Interface 를 위해 임시COCE ( M3000, M3040, M3110 ) 데이터 자동생김
		TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		TRS.set_string(tran_in_node, "TO_OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_3));
	
		TRS.add_nstring(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "TRAN_TIME"));


		if (MWIPLOTSTS.START_FLAG == 'Y')
		{
			TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
			if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
			}
		}
		else
		{
			if(WIP_SKIP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
			}
		}
			

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DONOTHING
		}		
	}

    tran_in_node = TRS.create_node("END_LOT_IN");
    tran_out_node = TRS.create_node("END_LOT_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
	TRS.set_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	TRS.set_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

	TRS.add_nstring(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "TRAN_CMF_1"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "TRAN_CMF_2"));
	TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", TRS.get_char(in_node, "INF_UPLOAD_TYPE_FLAG"));

	TRS.add_nstring(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "TRAN_TIME"));

    if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
        //TRS.init_node(out_node);
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        TRS.free_node(tran_in_node);
        TRS.free_node(tran_out_node);
		return MP_FALSE;
	}

    TRS.free_node(tran_in_node);
    TRS.free_node(tran_out_node);

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_End_Lot_Validation()
        - Main sub function of "EAPMES_END_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_End_Lot_Oqc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
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


    return MP_TRUE;
}

