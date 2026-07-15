/*******************************************************************************

    System      : MESplus
    Module      : User Routine for ALM
    File Name   : UALM_Raise_Alarm.c
    Description : User Routine for ALM_Raise_Alarm

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/11/10  Miracom        Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "UALM_common.h"
#include "CUS_common.h"

int ALM_Raise_Alarm_Before_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
	char s_msg_code[MP_SIZE_MSG];

	memset(s_msg_code, ' ', sizeof(s_msg_code));

	LOG_head("ALM_Raise_Alarm_Before_1");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(CBAS_SEND_MAIL(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

    return MP_TRUE;
}

int ALM_Raise_Alarm_After_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */

	struct MALMMSGDEF_TAG MALMMSGDEF;
	struct CALMTLGHIS_TAG CALMTLGHIS;
	struct RSUMHORLOS_TAG RSUMHORLOS;
	struct IALMCTVDAT_TAG IALMCTVDAT;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;


	char s_sys_time[14];
	char s_system_workdate[8];
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
	//int i_system_workshift;
	//char c_shift = ' ';
	char s_def_rate[30];
	char s_def_input[30];
	char s_time_span[30];
	char tmp_str[2000];
	char tmp_top[2000];
	char tmp_list[2000];
	char tmp_item[2000];
	char s_msg_code[MP_SIZE_MSG];
	int top_cnt;
	
	memset(s_msg_code, ' ' , sizeof(s_msg_code));

	
	memset(s_system_workdate, ' ', sizeof(s_system_workdate));
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(tmp_str, '\0', sizeof(tmp_str));
	memset(tmp_top, '\0', sizeof(tmp_top));
	memset(tmp_item, '\0', sizeof(tmp_item));
	memset(tmp_list, '\0', sizeof(tmp_list));
	top_cnt = 0;

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

	DBC_init_malmmsgdef(&MALMMSGDEF);
	TRS.copy(MALMMSGDEF.FACTORY, sizeof(MALMMSGDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MALMMSGDEF.ALARM_ID, sizeof(MALMMSGDEF.ALARM_ID), in_node, "ALARM_ID");
	DBC_select_malmmsgdef(1, &MALMMSGDEF); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		return MP_TRUE;
	}

	if (memcmp(MALMMSGDEF.ALARM_ID, "ALM_PMPP_SPEC_OUT", strlen("ALM_PMPP_SPEC_OUT")) == 0)
	{
		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, sizeof(HQCEL_M1_GCM_LINE_CODE));
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "RES_ID");
		CDB_select_mgcmtbldat(1, &MGCMTBLDAT);
		if (DB_error_code == DB_SUCCESS)
		{
			if (memcmp(MGCMTBLDAT.DATA_7, "E2", strlen("E2")) == 0)
			{
				TRS.add_nstring(in_node, "NOTIFY_SYSTEM", "EG23_LOW_POWER");
			}
			else
			{
				TRS.add_nstring(in_node, "NOTIFY_SYSTEM", "LOW_POWER");
			}
		}
	}
	else if (memcmp(MALMMSGDEF.ALARM_CMF_1, "SPC", 3) == 0)
	{
		//SPC 메세지인경우 MESSAGE 조합.
		struct MSPCCHTDEF_TAG MSPCCHTDEF;
		struct MSPCCALDAT_TAG MSPCCALDAT;
		double dLossRate = 0, d_tmpval = 0;		

		DBC_init_mspcchtdef(&MSPCCHTDEF);
		TRS.copy(MSPCCHTDEF.FACTORY, sizeof(MSPCCHTDEF.FACTORY), in_node, "FACTORY");
		TRS.copy(MSPCCHTDEF.CHART_ID, sizeof(MSPCCHTDEF.CHART_ID), in_node, "SOURCE_ID_3");
		DBC_select_mspcchtdef(1, &MSPCCHTDEF); 
		if(DB_error_code == DB_SUCCESS)
		{
			//제목
			TRS.set_string(in_node, "ALARM_MSG", MSPCCHTDEF.CHART_DESC,  sizeof(MSPCCHTDEF.CHART_DESC));
			sprintf(tmp_str + strlen(tmp_str), "\n#%s", TRS.get_string(in_node, "ALARM_MSG"));

			//대상시간
			//sprintf(tmp_str + strlen(tmp_str), "(11~12)  \n", TRS.get_string(in_node, "ALARM_MSG"));
			
		}

		if (memcmp(MALMMSGDEF.ALARM_CMF_3, "LOSS_RATE", strlen("LOSS_RATE")) == 0)
		{
			if (MSPCCHTDEF.GRAPH_TYPE[0] == 'P')
			{
				DBC_init_mspccaldat(&MSPCCALDAT);
				TRS.copy(MSPCCALDAT.FACTORY, sizeof(MSPCCALDAT.FACTORY), in_node, "FACTORY");
				TRS.copy(MSPCCALDAT.CHART_ID, sizeof(MSPCCALDAT.CHART_ID), in_node, "SOURCE_ID_3");
				DBC_open_mspccaldat(12, &MSPCCALDAT); 
		
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "SPC-0026");
					TRS.add_fieldmsg(out_node, "MSPCCALDAT OPEN", MP_NVST);
					TRS.add_fieldmsg(out_node, "CHART_ID", MP_STR, sizeof(MSPCCALDAT.CHART_ID), MSPCCALDAT.CHART_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					// 20210810 MES Application Memory leak 점검 및 수정
					// DB error log edit
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					return MP_FALSE;
				}
				while(1)
				{
					DBC_fetch_mspccaldat(12, &MSPCCALDAT);
					if (DB_error_code == DB_NOT_FOUND)
					{
						DBC_close_mspccaldat(12);
						break;
					}
					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					else if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "SPC-0004");
						TRS.add_fieldmsg(out_node, "MSPCCALDAT FETCH", MP_NVST);
						TRS.add_fieldmsg(out_node, "CHART_ID", MP_STR, sizeof(MSPCCALDAT.CHART_ID), MSPCCALDAT.CHART_ID);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_VALIDATION;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						DBC_close_mspccaldat(12);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 

						return MP_FALSE;
					}

					/*- Defect Rate 11.00%, 11/100 (Time:17~18)
					- Defect Rate 19.00%, 11/90 (Time:18~19)
					- Defect Rate 10.00%, 8/80 (Time:20~21)*/

					memset(s_def_rate, 0x00, sizeof(s_def_rate));
					memset(s_def_input, 0x00, sizeof(s_def_input));
					memset(s_time_span, 0x00, sizeof(s_time_span));

					COM_memcpy_add_null(s_def_rate, MSPCCALDAT.RESV_FIELD1, sizeof(MSPCCALDAT.RESV_FIELD1));
					COM_memcpy_add_null(s_def_input, MSPCCALDAT.RESV_FIELD2, sizeof(MSPCCALDAT.RESV_FIELD2));
					COM_memcpy_add_null(s_time_span, MSPCCALDAT.RESV_FIELD3, sizeof(MSPCCALDAT.RESV_FIELD3));

					sprintf(tmp_str + strlen(tmp_str), "\n- Defect Rate %s, %s %s", s_def_rate, s_def_input, s_time_span);

				}

				if (   memcmp(MALMMSGDEF.ALARM_ID, "SPC-FQC-A", strlen("SPC-FQC-A")) == 0
					|| memcmp(MALMMSGDEF.ALARM_ID, "SPC-FQC-I", strlen("SPC-FQC-I")) == 0
					)
				{
					//TOP 3 DEFECT
					//SPC-FQC-A : The defect rate of FQC  is out of spec.
					//SPC-FQC-F : The defect rate of FQC  is consecutive 3 hours above the target.
                    CDB_init_rsumhorlos(&RSUMHORLOS);
					TRS.copy(RSUMHORLOS.FACTORY, sizeof(RSUMHORLOS.FACTORY), in_node, "FACTORY");
					//memcpy(RSUMHORLOS.LINE_ID,MSPCCHTDEF.RES_ID,sizeof(MSPCCHTDEF.RES_ID)); IS-21-01-094 MES logic 개선
					memcpy(RSUMHORLOS.LINE_ID,MSPCCHTDEF.RES_ID,sizeof(RSUMHORLOS.LINE_ID));
					memcpy(RSUMHORLOS.OPER,"M3110",strlen("M3110"));
					CDB_open_rsumhorlos(2, &RSUMHORLOS); 
		
					if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "SPC-0026");
						TRS.add_fieldmsg(out_node, "RSUMHORLOS OPEN", MP_NVST);
						//TRS.add_fieldmsg(out_node, "TOP 3 DEFECT", MP_STR, sizeof(RSUMHORLOS.FACTORY), RSUMHORLOS.FACTORY);

						// 20210810 MES Application Memory leak 점검 및 수정
						// DB error log edit
						TRS.add_fieldmsg(out_node, "TOP 3 DEFECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMHORLOS.FACTORY), RSUMHORLOS.FACTORY);
						TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMHORLOS.LINE_ID), RSUMHORLOS.LINE_ID);
						TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(RSUMHORLOS.OPER), RSUMHORLOS.OPER);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_VALIDATION;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						// 20210810 MES Application Memory leak 점검 및 수정
						// DB error log edit
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

						return MP_FALSE;
					}

					while(1)
					{
						CDB_fetch_rsumhorlos(2, &RSUMHORLOS);
						if (DB_error_code == DB_NOT_FOUND)
						{
							if(top_cnt > 0)
							{
								sprintf(tmp_top + strlen(tmp_top), "\n--------------------------------------------------------------\nTOP %d Defects for last hour : %s",top_cnt, tmp_item);
							}
						

							CDB_close_rsumhorlos(2);
							break;
						}
						// 20210810 MES Application Memory leak 점검 및 수정
						// DB Close 추가
						else if (DB_error_code != DB_SUCCESS)
						{
							strcpy(s_msg_code, "SPC-0004");
							TRS.add_fieldmsg(out_node, "RSUMHORLOS FETCH", MP_NVST);
							TRS.add_fieldmsg(out_node, "TOP 3 DEFECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMHORLOS.FACTORY), RSUMHORLOS.FACTORY);
							TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMHORLOS.LINE_ID), RSUMHORLOS.LINE_ID);
							TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(RSUMHORLOS.OPER), RSUMHORLOS.OPER);
							
							TRS.add_dberrmsg(out_node, DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_VALIDATION;
							gs_log_type.category = MP_LOG_CATE_SETUP;

							CDB_close_rsumhorlos(2);
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 

							return MP_FALSE;
						}

						memset(s_def_rate, 0x00, sizeof(s_def_rate));
						COM_memcpy_add_null(s_def_rate, RSUMHORLOS.CMF_1, sizeof(RSUMHORLOS.CMF_1));
						if(top_cnt > 0)
						{
							sprintf(tmp_item + strlen(tmp_item), ", %s", s_def_rate);
						}
						else
						{
							sprintf(tmp_item + strlen(tmp_item), "%s", s_def_rate);
						}
						

						top_cnt = top_cnt + 1;
						/*- Top 1:B35(3) 	J/B potting material
							Top 2:B46(1) 	B/S burnt marks
							Top 3:E03(1) 	Tree crack*/

						memset(s_def_rate, 0x00, sizeof(s_def_rate));
						memset(s_def_input, 0x00, sizeof(s_def_input));
						COM_memcpy_add_null(s_def_rate, RSUMHORLOS.CMF_2, sizeof(RSUMHORLOS.CMF_2));
						COM_memcpy_add_null(s_def_input, RSUMHORLOS.CMF_3, sizeof(RSUMHORLOS.CMF_3));
						
						sprintf(tmp_list + strlen(tmp_list), "\n- %s : %s", s_def_rate, s_def_input );

						memset(s_def_rate, 0x00, sizeof(s_def_rate));
						memset(s_def_input, 0x00, sizeof(s_def_input));
						COM_memcpy_add_null(s_def_rate, RSUMHORLOS.CMF_4, sizeof(RSUMHORLOS.CMF_4));
						COM_memcpy_add_null(s_def_input, RSUMHORLOS.CMF_5, sizeof(RSUMHORLOS.CMF_5));
						
						sprintf(tmp_list + strlen(tmp_list), " %s%s", s_def_rate, s_def_input );

					}
				}
				
			}
			
		}
		else
		{
			DBC_init_mspccaldat(&MSPCCALDAT);
			TRS.copy(MSPCCALDAT.FACTORY, sizeof(MSPCCALDAT.FACTORY), in_node, "FACTORY");
			TRS.copy(MSPCCALDAT.CHART_ID, sizeof(MSPCCALDAT.CHART_ID), in_node, "SOURCE_ID_3");
			DBC_select_mspccaldat(101, &MSPCCALDAT); 

			if ((DB_error_code == DB_SUCCESS) && (MSPCCHTDEF.GRAPH_TYPE[0] == 'P'))
			{

				DBC_init_mspccaldat(&MSPCCALDAT);
				TRS.copy(MSPCCALDAT.FACTORY, sizeof(MSPCCALDAT.FACTORY), in_node, "FACTORY");
				TRS.copy(MSPCCALDAT.CHART_ID, sizeof(MSPCCALDAT.CHART_ID), in_node, "SOURCE_ID_3");

				DBC_select_mspccaldat(101, &MSPCCALDAT); 

				TRS.set_string(in_node, "ALARM_MSG", MSPCCALDAT.MAX_VALUE,  sizeof(MSPCCALDAT.MAX_VALUE));
				sprintf(tmp_str + strlen(tmp_str), " \n-Input Count(n) = [%s] ", TRS.get_string(in_node, "ALARM_MSG"));
				TRS.set_string(in_node, "ALARM_MSG", MSPCCALDAT.MIN_VALUE,  sizeof(MSPCCALDAT.MIN_VALUE));
				sprintf(tmp_str + strlen(tmp_str), " \n-Defect Count(Pn) = [%s]  ", TRS.get_string(in_node, "ALARM_MSG"));

				d_tmpval = COM_atof(MSPCCALDAT.AVERAGE, sizeof(MSPCCALDAT.AVERAGE)) * 100;
				dLossRate = COM_dbl_round(d_tmpval, 3, 'U');
				sprintf(tmp_str + strlen(tmp_str), " \n-P = [%.2f%%] ", dLossRate);

				d_tmpval = COM_atof(MSPCCALDAT.USL, sizeof(MSPCCALDAT.USL)) * 100;
				dLossRate = COM_dbl_round(d_tmpval, 3, 'U');
				sprintf(tmp_str + strlen(tmp_str), " \n-USL = [%.2f%%] ", dLossRate);

				if (COM_isspace(MSPCCALDAT.CL, sizeof(MSPCCALDAT.CL)) == MP_FALSE)
				{
					d_tmpval = COM_atof(MSPCCALDAT.CL, sizeof(MSPCCALDAT.CL)) * 100;
					dLossRate = COM_dbl_round(d_tmpval, 3, 'U');
					sprintf(tmp_str + strlen(tmp_str), "  , CL = [%.2f%%] ", dLossRate);
				}
			}
		}

		TRS.set_string(in_node, "ALARM_MSG", MALMMSGDEF.ALARM_MSG_1,  sizeof( MALMMSGDEF.ALARM_MSG_1));
		sprintf(tmp_str + strlen(tmp_str), "\n%s ", TRS.get_string(in_node, "ALARM_MSG"));

		sprintf(tmp_str + strlen(tmp_str), "%s", tmp_top);
		sprintf(tmp_str + strlen(tmp_str), "%s", tmp_list);
		TRS.set_nstring(in_node, "ALARM_MSG",tmp_str);
	}

	if(MALMMSGDEF.ACTION_MSG_FLAG == 'Y')
	{
		CDB_init_calmtlghis(&CALMTLGHIS);
		TRS.copy(CALMTLGHIS.FACTORY, sizeof(CALMTLGHIS.FACTORY), in_node, "FACTORY");
		if(COM_isnullspace(TRS.get_string(in_node, "NOTIFY_SYSTEM")) == MP_FALSE)
		{
			TRS.copy(CALMTLGHIS.NOTIFY_SYSTEM, sizeof(CALMTLGHIS.NOTIFY_SYSTEM), in_node, "NOTIFY_SYSTEM");
		}
		else
		{
			memcpy(CALMTLGHIS.NOTIFY_SYSTEM, "HQcellUS_MES", strlen("HQcellUS_MES"));
		}
		
		memcpy(CALMTLGHIS.TRAN_TIME, s_sys_time, sizeof(CALMTLGHIS.TRAN_TIME));
		TRS.copy(CALMTLGHIS.NOTIFY_MESSAGE, sizeof(CALMTLGHIS.NOTIFY_MESSAGE), in_node, "ALARM_MSG");

		if (COM_isspace(CALMTLGHIS.NOTIFY_MESSAGE, sizeof(CALMTLGHIS.NOTIFY_MESSAGE)) == MP_TRUE)
		{
			memcpy(CALMTLGHIS.NOTIFY_MESSAGE, MALMMSGDEF.ALARM_MSG_1, sizeof( MALMMSGDEF.ALARM_MSG_1));
		}

		/*CALMTLGHIS.NOTIFY_FLAG  = TRS.get_char(in_node, "NOTIFY_FLAG"); 
		TRS.copy(CALMTLGHIS.NOTIFY_TIME, sizeof(CALMTLGHIS.NOTIFY_TIME), in_node, "NOTIFY_TIME");
		TRS.copy(CALMTLGHIS.CMF_1, sizeof(CALMTLGHIS.CMF_1), in_node, "CMF_1");
		TRS.copy(CALMTLGHIS.CMF_2, sizeof(CALMTLGHIS.CMF_2), in_node, "CMF_2");
		TRS.copy(CALMTLGHIS.CMF_3, sizeof(CALMTLGHIS.CMF_3), in_node, "CMF_3");
		TRS.copy(CALMTLGHIS.CMF_4, sizeof(CALMTLGHIS.CMF_4), in_node, "CMF_4");
		TRS.copy(CALMTLGHIS.CMF_5, sizeof(CALMTLGHIS.CMF_5), in_node, "CMF_5");
		TRS.copy(CALMTLGHIS.CMF_6, sizeof(CALMTLGHIS.CMF_6), in_node, "CMF_6");
		TRS.copy(CALMTLGHIS.CMF_7, sizeof(CALMTLGHIS.CMF_7), in_node, "CMF_7");
		TRS.copy(CALMTLGHIS.CMF_8, sizeof(CALMTLGHIS.CMF_8), in_node, "CMF_8");
		TRS.copy(CALMTLGHIS.CMF_9, sizeof(CALMTLGHIS.CMF_9), in_node, "CMF_9");
		TRS.copy(CALMTLGHIS.CMF_10, sizeof(CALMTLGHIS.CMF_10), in_node, "CMF_10");*/

		CDB_insert_calmtlghis(&CALMTLGHIS); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "ALM-0004"); 
			TRS.add_fieldmsg(out_node, "CALMTLGHIS INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CALMTLGHIS.SEQ_NUM); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALMTLGHIS.FACTORY), CALMTLGHIS.FACTORY); 
			TRS.add_fieldmsg(out_node, "NOTIFY_SYSTEM", MP_STR, sizeof(CALMTLGHIS.NOTIFY_SYSTEM), CALMTLGHIS.NOTIFY_SYSTEM); 
			TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CALMTLGHIS.TRAN_TIME), CALMTLGHIS.TRAN_TIME); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		} 


	}    
	
	if(COM_isnullspace(TRS.get_string(in_node, "ALARM_ID")) == MP_FALSE && TRS.get_char(in_node, "RECOVER_MAIL_FLAG") == 'Y')
	{
		DBC_init_malmmsgdef(&MALMMSGDEF);
		TRS.copy(MALMMSGDEF.FACTORY, sizeof(MALMMSGDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MALMMSGDEF.ALARM_ID, sizeof(MALMMSGDEF.ALARM_ID), in_node, "ALARM_ID");
		
		DBC_select_malmmsgdef(1, &MALMMSGDEF);
		if(DB_error_code == DB_SUCCESS) 
		{
			MALMMSGDEF.ACTION_MAIL_FLAG = 'Y';  // 임시로 지운 플래그 복구
			DBC_update_malmmsgdef(1, &MALMMSGDEF);
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "ALM-0004");
				TRS.add_fieldmsg(out_node, "MALMMSGDEF UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MALMMSGDEF.FACTORY), MALMMSGDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "ALARM_ID", MP_STR, sizeof(MALMMSGDEF.ALARM_ID), MALMMSGDEF.ALARM_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}

	//// 23.06.27 GCM @CCTV_ALARM_LIST 대상 ALARM_ID 일 경우 MES CCTV ALM I/F테이블 (IALMCTVDAT)에 Insert
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
	memcpy(MGCMTBLDAT.TABLE_NAME, "@CCTV_ALARM_LIST", sizeof(MGCMTBLDAT.TABLE_NAME));
	TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "ALARM_ID");
	TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "SOURCE_ID_1");
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if (DB_error_code == DB_SUCCESS) {

		CDB_init_ialmctvdat(&IALMCTVDAT);
		TRS.copy(IALMCTVDAT.ITEM_NO, sizeof(IALMCTVDAT.ITEM_NO), in_node, "RES_ID");
		memcpy(IALMCTVDAT.TRAN_TIME, s_sys_time, sizeof(IALMCTVDAT.TRAN_TIME));
		TRS.copy(IALMCTVDAT.ALARM_ID, sizeof(IALMCTVDAT.ALARM_ID), in_node, "ALARM_ID");
		TRS.copy(IALMCTVDAT.ALARM_SUBJECT, sizeof(IALMCTVDAT.ALARM_SUBJECT), in_node, "ALARM_SUBJECT");
		TRS.copy(IALMCTVDAT.ALARM_MSG, sizeof(IALMCTVDAT.ALARM_MSG), in_node, "ALARM_MSG");
		TRS.copy(IALMCTVDAT.ALARM_TYPE, sizeof(IALMCTVDAT.ALARM_TYPE), in_node, "SOURCE_ID_1");
		TRS.copy(IALMCTVDAT.ALARM_LEVEL, sizeof(IALMCTVDAT.ALARM_LEVEL), in_node, "SOURCE_ID_2");

		memcpy(IALMCTVDAT.CREATE_TIME, s_sys_time, sizeof(IALMCTVDAT.CREATE_TIME));
		CDB_insert_ialmctvdat(&IALMCTVDAT);
		if (DB_error_code != DB_SUCCESS) {
			//TO DO 
		}
	}

	return MP_TRUE;
}

