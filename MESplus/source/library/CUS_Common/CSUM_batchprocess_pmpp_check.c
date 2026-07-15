/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_pmpp_check.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// 검사결과이력(CEDCLOTRLH)을 라인별/주기별 저출력 체크하여 기준초과 시 ALARM발생 

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2019/10/03  JGCHOI.       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include "SPCCore_common.h"
#include "ALMCore_common.h"
#include <MessageCaster.h>
int CSUM_BATCHPROCESS_PMPP_CHECK(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CSUM_BatchProcess_PMPP_Check_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
CSUM_BatchProcess_PMPP_Check()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_PMPP_Check(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	
	i_ret = CSUM_BATCHPROCESS_PMPP_CHECK(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_PMPP_CHECK", out_node);

	if(i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	CUS_COM_BATCHPROCESS_STATUS_UPDATE('E', in_node, out_node);

	return MP_TRUE;
}


/*******************************************************************************
CSUM_BATCHPROCESS_PMPP_CHECK()
- Main sub function of "CSUM_BatchProcess_PMPP_Check" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_PMPP_CHECK(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
//	struct CTMPSPCDAT_TAG CTMPSPCDAT;
	struct MSPCCHTDEF_TAG MSPCCHTDEF;
//	struct RSUMHORMOV_TAG RSUMHORMOV;
//	struct RSUMHORLOS_TAG RSUMHORLOS;
	struct MEDCCHRDEF_TAG MEDCCHRDEF;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;

	TRSNode* tran_in_node;

	char s_tmpstr[1000];
	char s_line_id[10];
	char s_check_time[30];
	char s_over_rate[30];


	char w100_below_cnt[30];
	char w300_below_cnt[30];
	char w300_avove_cnt[200];

	double std_lower_spec = 0;	
	double ng_rate = 0;
	int ng_cnt = 0;
	int input_cnt = 0;
			
    LOG_head("CSUM_BATCHPROCESS_PMPP_CHECK");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}

	DBC_init_mspcchtdef(&MSPCCHTDEF);
	TRS.copy(MSPCCHTDEF.FACTORY, sizeof(MSPCCHTDEF.FACTORY), in_node, IN_FACTORY);
	memcpy(MSPCCHTDEF.CHT_CMF_1, "I_SIM_01_PMAX", strlen("I_SIM_01_PMAX"));
	DBC_open_mspcchtdef(18, &MSPCCHTDEF);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "MSPCCHTDEF OPEN", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		DBC_fetch_mspcchtdef(18, &MSPCCHTDEF);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			DBC_close_mspcchtdef(18);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "MSPCCHTDEF FETCH", MP_NVST);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			DBC_close_mspcchtdef(18);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//Simulator 저출력(PMPP) 체크 후 SPEC OUT시 Raise Alarm.  2019.10.03 JGCHOI.
		DBC_init_medcchrdef(&MEDCCHRDEF);
		memcpy(MEDCCHRDEF.FACTORY, MSPCCHTDEF.FACTORY, sizeof(MEDCCHRDEF.FACTORY));
		memcpy(MEDCCHRDEF.CHAR_ID, MSPCCHTDEF.CHAR_ID, sizeof(MEDCCHRDEF.CHAR_ID));
		DBC_select_medcchrdef(1, &MEDCCHRDEF);
		if(DB_error_code == DB_SUCCESS) 
		{
			CDB_init_cedclotrlh(&CEDCLOTRLH);
			memcpy(CEDCLOTRLH.FACTORY, MSPCCHTDEF.FACTORY, sizeof(MSPCCHTDEF.FACTORY));
			memcpy(CEDCLOTRLH.INS_TYPE, "SI", strlen("SI"));
			memcpy(CEDCLOTRLH.LINE_ID, MSPCCHTDEF.RES_ID, sizeof(CEDCLOTRLH.LINE_ID));

			memcpy(CEDCLOTRLH.CMF_1, MSPCCHTDEF.CHT_CMF_2, sizeof(CEDCLOTRLH.CMF_1));//Check Time(분)
			memcpy(CEDCLOTRLH.CMF_2, MSPCCHTDEF.CHT_CMF_3, sizeof(CEDCLOTRLH.CMF_2));//Over Rate(%)
			memcpy(CEDCLOTRLH.CMF_3, MEDCCHRDEF.LOWER_SPEC_LIMIT, sizeof(MEDCCHRDEF.LOWER_SPEC_LIMIT)); //Lower Spec

			CDB_select_cedclotrlh(5, &CEDCLOTRLH);
			if(DB_error_code != DB_SUCCESS)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(CEDCLOTRLH.RESULT_VALUE[0] == 'Y') //ALARM_FLAG
			{
				std_lower_spec = COM_atof(CEDCLOTRLH.CMF_3, sizeof(CEDCLOTRLH.CMF_3));
				ng_rate = COM_atof(CEDCLOTRLH.RLT_COMMENT, sizeof(CEDCLOTRLH.RLT_COMMENT));
				ng_cnt = CEDCLOTRLH.QTY;
				input_cnt = CEDCLOTRLH.HIST_SEQ;
				
				//strncpy(w100_below_cnt, CEDCLOTRLH.CMF_4, sizeof(CEDCLOTRLH.CMF_4));
				//w100_below_cnt[20] = 0x00;
				//strncpy(w300_below_cnt, CEDCLOTRLH.CMF_5, sizeof(CEDCLOTRLH.CMF_5));
				//w300_below_cnt[20] = 0x00;
				//strncpy(w300_avove_cnt, CEDCLOTRLH.INC_COMMENT, sizeof(CEDCLOTRLH.INC_COMMENT));
				//w300_avove_cnt[20] = 0x00;
				
				memset(w100_below_cnt, 0x00, sizeof(w100_below_cnt));
				memset(w300_below_cnt, 0x00, sizeof(w300_below_cnt));
				memset(w300_avove_cnt, 0x00, sizeof(w300_avove_cnt));

				memset(s_tmpstr, 0x00, sizeof(s_tmpstr));
				memset(s_line_id, 0x00, sizeof(s_line_id));
				memset(s_check_time, 0x00, sizeof(s_check_time));
				memset(s_over_rate, 0x00, sizeof(s_over_rate));

				COM_memcpy_add_null(s_line_id, CEDCLOTRLH.LINE_ID, sizeof(CEDCLOTRLH.LINE_ID));
				COM_memcpy_add_null(s_check_time, CEDCLOTRLH.CMF_1, sizeof(CEDCLOTRLH.CMF_1));
				COM_memcpy_add_null(s_over_rate, CEDCLOTRLH.CMF_2, sizeof(CEDCLOTRLH.CMF_2));

				COM_memcpy_add_null(w100_below_cnt, CEDCLOTRLH.CMF_4, sizeof(CEDCLOTRLH.CMF_4));
				COM_memcpy_add_null(w300_below_cnt, CEDCLOTRLH.CMF_5, sizeof(CEDCLOTRLH.CMF_5));
				COM_memcpy_add_null(w300_avove_cnt, CEDCLOTRLH.INC_COMMENT, sizeof(CEDCLOTRLH.INC_COMMENT));
				 
				sprintf(s_tmpstr + strlen(s_tmpstr), "#%s LOW POWER ALARM", s_line_id);	
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-Input Count = [%d]", input_cnt);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-Low Power Count = [%d]", ng_cnt);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-100W Below(0~99.999999) = [%s]", w100_below_cnt);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-300W Below(100~299.999999) = [%s]", w300_below_cnt);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-300W Above(300~%.6lf) = [%s]", std_lower_spec, w300_avove_cnt);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-<b>Spec Over Rate = [%.1lf]</b>%%", ng_rate);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-Standard Power = [%.6lf]", std_lower_spec);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-Standard Rate  = [%s]%%", s_over_rate);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n-Monitoring Time = [%s]Min.", s_check_time);
				sprintf(s_tmpstr + strlen(s_tmpstr), "\n%s", "The low power rate is out of spec.");				

				tran_in_node = TRS.create_node("alarm_in_node");
				CCOM_copy_in_node(in_node, tran_in_node);

				TRS.set_string(tran_in_node, IN_FACTORY, CEDCLOTRLH.FACTORY, sizeof(CEDCLOTRLH.FACTORY));
				TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
				TRS.set_nstring(tran_in_node, "ALARM_ID", "ALM_PMPP_SPEC_OUT");				
				TRS.set_string(tran_in_node, "RES_ID", MSPCCHTDEF.RES_ID, sizeof(MSPCCHTDEF.RES_ID));				
				TRS.set_nstring(tran_in_node, "ALARM_SUBJECT", "# LOW POWER ALARM #");
				TRS.set_nstring(tran_in_node, "ALARM_MSG", s_tmpstr);
				TRS.set_string(tran_in_node, "SOURCE_ID_1", CEDCLOTRLH.CMF_1, sizeof(CEDCLOTRLH.CMF_1));
				TRS.set_string(tran_in_node, "SOURCE_ID_2",CEDCLOTRLH.CMF_2, sizeof(CEDCLOTRLH.CMF_2));
				TRS.set_string(tran_in_node, "SOURCE_ID_3", MSPCCHTDEF.CHART_ID, sizeof(MSPCCHTDEF.CHART_ID));

				if(ALM_RAISE_ALARM(s_msg_code, tran_in_node, out_node) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					TRS.free_node(tran_in_node);
					return MP_FALSE;
				}
				TRS.free_node(tran_in_node);
			}
		}		
		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
CSUM_BatchProcess_PMPP_Check_Validation()
- Validation check sub function of "CSUM_BatchProcess_PMPP_Check" function
- Check the Conditions before Custom End Lot Function List
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_PMPP_Check_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	/* ProcStep Validation */
	if ((TRS.get_procstep(in_node) == ' ')  || (TRS.get_procstep(in_node) == '\0'))
	{
		//BATCH 에서 실행되므로 PROC STEP 은 1로 무조건 실행함.
		TRS.set_char(in_node, IN_PROCSTEP, '1');
	}
	if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
		strcpy(s_msg_code, "WIP-0001");
        TRS.set_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

	return MP_TRUE;
}

