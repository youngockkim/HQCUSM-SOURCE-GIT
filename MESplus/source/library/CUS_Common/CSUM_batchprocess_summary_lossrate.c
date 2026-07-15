/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_spc_function.c.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// CTMPSPCDAT 기준데이터를 읽어서  SPC 호출

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2018/11/27  Juhyeon.Jung       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include "SPCCore_common.h"
#include <MessageCaster.h>
int CSUM_BATCHPROCESS_LOSS_RATE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CSUM_BatchProcess_Summary_LossRate_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
CSUM_BatchProcess_Summary_LossRate()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Summary_LossRate(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_BATCHPROCESS_LOSS_RATE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_LOSS_RATE", out_node);

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
CSUM_BATCHPROCESS_LOSS_RATE()
- Main sub function of "CSUM_BatchProcess_Summary_LossRate" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_LOSS_RATE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CTMPSPCDAT_TAG CTMPSPCDAT;
	struct MSPCCHTDEF_TAG MSPCCHTDEF;
	struct RSUMHORMOV_TAG RSUMHORMOV;
	struct RSUMHORLOS_TAG RSUMHORLOS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct RSUMHORLOS_TAG RSUMHORLOS_B1;

	char s_sys_time[14];
	char s_target_time[14];
	int iStep  = 0;
	
	double iOutQty = 0;
	double iLossQty = 0;
	double dLossRate = 0;
	
	int icnt = 0;

	struct worktime_tag tmp_work_time;
		
    LOG_head("CSUM_BATCHPROCESS_LOSS_RATE");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time, ' ', sizeof(s_sys_time));
	
	DB_get_systime(s_target_time);
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
	
	DB_get_calc_time(s_sys_time, s_target_time, 1,-5); //5분전의 시간을 s_target_time 에 저장 ( 매시 1분에 1시간전의 타임을 계산하기 위해) 

	memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
	CCOM_get_work_time(s_sys_time, &tmp_work_time);

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}
	iStep = 2;
	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@SPC_LOSSRATE", strlen("@SPC_LOSSRATE"));
	CDB_open_mgcmlagdat(iStep, &MGCMLAGDAT);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		CDB_fetch_mgcmlagdat(iStep, &MGCMLAGDAT);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			CDB_close_mgcmlagdat(iStep);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "MGCMLAGDAT FETCH", MP_NVST);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			CDB_close_mgcmlagdat(iStep);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if (COM_isspace(MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1)) == MP_TRUE)
		{
			continue;
		}

		iOutQty = 0;
		iLossQty = 0;
		dLossRate = 0;

		CDB_init_rsumhormov(&RSUMHORMOV);
		//WORK DATE
		memcpy(RSUMHORMOV.WORK_DATE, tmp_work_time.work_date, 8);

		//LINE 
		if (memcmp(MGCMLAGDAT.KEY_1, "TOTAL", 5) ==0 )
		{
			memset(RSUMHORMOV.LINE_ID, ' ', sizeof(RSUMHORMOV.LINE_ID));
		}
		else
		{
			memcpy(RSUMHORMOV.LINE_ID, MGCMLAGDAT.KEY_1, sizeof(RSUMHORMOV.LINE_ID));
		}

		//OPER
		memcpy(RSUMHORMOV.OPER, MGCMLAGDAT.KEY_2, sizeof(RSUMHORMOV.OPER));

		//DEFECT TYPE
		CDB_init_rsumhorlos(&RSUMHORLOS);
		memcpy(RSUMHORLOS.WORK_DATE, RSUMHORMOV.WORK_DATE, sizeof(RSUMHORLOS.WORK_DATE));
		memcpy(RSUMHORLOS.LINE_ID, RSUMHORMOV.LINE_ID, sizeof(RSUMHORLOS.LINE_ID));
		memcpy(RSUMHORLOS.OPER, RSUMHORMOV.OPER, sizeof(RSUMHORMOV.OPER));
        //LOSS RATE에서 후단 EL DEFECT CODE E19 검색 조건에서 제외.
        if (memcmp(RSUMHORMOV.OPER, "M3070", 5) ==0 )
        {
		    CDB_select_rsumhormov(3, &RSUMHORMOV);
        }else if (memcmp(RSUMHORMOV.OPER, "M2040", 5) ==0 ) //include Defect M2040, M2035 
        {
		    CDB_select_rsumhormov(4, &RSUMHORMOV);
        }
		else if (memcmp(RSUMHORMOV.OPER, "M3110", 5) ==0 ) //FQC 22.04.12 IS-22-04-001[프로그램_변경]Telegram SPC Alert 수치 현행화
        {
		    CDB_select_rsumhormov(5, &RSUMHORMOV);
        }
		else
        {
            CDB_select_rsumhormov(2, &RSUMHORMOV);
        }
		
		
		if(DB_error_code != DB_SUCCESS) 
		{
			continue;
		}
		if (RSUMHORMOV.INPUT_QTY < 1)
		{
			continue;
		}

		
		
		if (memcmp(MGCMLAGDAT.KEY_3, "TOTAL", 5) ==0 )
		{
			//LOSS RATE에서 후단 EL DEFECT CODE E19 검색 조건에서 제외.
            if (memcmp(RSUMHORLOS.OPER, "M3070", 5) ==0 )
            {
                CDB_select_rsumhorlos(7, &RSUMHORLOS);
            }
            else if (memcmp(RSUMHORLOS.OPER, "M2040", 5) ==0 ) //include Defect M2040, M2035 
            {
                CDB_select_rsumhorlos(8, &RSUMHORLOS);
            }
			 else if (memcmp(RSUMHORLOS.OPER, "M3110", 5) ==0 )  //FQC 22.04.12 IS-22-04-001[프로그램_변경]Telegram SPC Alert 수치 현행화
            {
                CDB_select_rsumhorlos(9, &RSUMHORLOS);
            }
			else
            {
                CDB_select_rsumhorlos(4, &RSUMHORLOS);
            }
			iOutQty = RSUMHORMOV.INPUT_QTY;
			iLossQty = RSUMHORLOS.LOSS_QTY;

		}
		else if (memcmp(MGCMLAGDAT.KEY_3, "CRACK", 5) ==0 )
		{
			//LOSS RATE에서 후단 EL DEFECT CODE E19 검색 조건에서 제외.
            if(memcmp(RSUMHORLOS.OPER, "M3070", 5) ==0 )
            {
                CDB_select_rsumhorlos(5, &RSUMHORLOS);
            }
            else
            {
                CDB_select_rsumhorlos(2, &RSUMHORLOS);
            }
			iOutQty = RSUMHORMOV.INPUT_QTY;
			iLossQty = RSUMHORLOS.LOSS_QTY;
		}
		else if (memcmp(MGCMLAGDAT.KEY_3, "OTHER", 5) ==0 )
		{
			//LOSS RATE에서 후단 EL DEFECT CODE E19 검색 조건에서 제외.
            if(memcmp(RSUMHORLOS.OPER, "M3070", 5) ==0 )
            {
                CDB_select_rsumhorlos(6, &RSUMHORLOS);
            }else
            {
                CDB_select_rsumhorlos(3, &RSUMHORLOS);
            }
			iOutQty = RSUMHORMOV.INPUT_QTY;
			iLossQty = RSUMHORLOS.LOSS_QTY;
		}

		//SUM TYPE
		if (memcmp(MGCMLAGDAT.KEY_4, "TOTAL", 5) ==0 )
		{
			//그일자의 전체수량
		}
		else if (memcmp(MGCMLAGDAT.KEY_4, "HOUR", 4) ==0 )
		{
			//해당 시간의 수량
			//00~01 
			if ((memcmp(s_sys_time+8, "000000", 6) >= 0) && (memcmp(s_sys_time+8, "010000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME01_QTY ;
				iLossQty = RSUMHORLOS.TIME01_LOSS_QTY;
			}
			//01~02 
			if ((memcmp(s_sys_time+8, "010000", 6) >= 0) && (memcmp(s_sys_time+8, "020000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME02_QTY ;
				iLossQty = RSUMHORLOS.TIME02_LOSS_QTY;
			}
			//02~03 
			if ((memcmp(s_sys_time+8, "020000", 6) >= 0) && (memcmp(s_sys_time+8, "030000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME03_QTY ;
				iLossQty = RSUMHORLOS.TIME03_LOSS_QTY;
			}
			//03~04 
			if ((memcmp(s_sys_time+8, "030000", 6) >= 0) && (memcmp(s_sys_time+8, "040000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME04_QTY ;
				iLossQty = RSUMHORLOS.TIME04_LOSS_QTY;
			}
			//04~05 
			if ((memcmp(s_sys_time+8, "040000", 6) >= 0) && (memcmp(s_sys_time+8, "050000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME05_QTY ;
				iLossQty = RSUMHORLOS.TIME05_LOSS_QTY;
			}
			//05~06 
			if ((memcmp(s_sys_time+8, "050000", 6) >= 0) && (memcmp(s_sys_time+8, "060000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME06_QTY ;
				iLossQty = RSUMHORLOS.TIME06_LOSS_QTY;
			}
			//06~07 
			if ((memcmp(s_sys_time+8, "060000", 6) >= 0) && (memcmp(s_sys_time+8, "070000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME07_QTY ;
				iLossQty = RSUMHORLOS.TIME07_LOSS_QTY;
			}
			//07~08 
			if ((memcmp(s_sys_time+8, "070000", 6) >= 0) && (memcmp(s_sys_time+8, "080000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME08_QTY ;
				iLossQty = RSUMHORLOS.TIME08_LOSS_QTY;
			}
			//08~09 
			if ((memcmp(s_sys_time+8, "080000", 6) >= 0) && (memcmp(s_sys_time+8, "090000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME09_QTY ;
				iLossQty = RSUMHORLOS.TIME09_LOSS_QTY;
			}
			//09~10 
			if ((memcmp(s_sys_time+8, "090000", 6) >= 0) && (memcmp(s_sys_time+8, "100000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME10_QTY ;
				iLossQty = RSUMHORLOS.TIME10_LOSS_QTY;
			}
			//10~11 
			if ((memcmp(s_sys_time+8, "100000", 6) >= 0) && (memcmp(s_sys_time+8, "110000", 6) < 0))
			{
		
				iOutQty = RSUMHORMOV.TIME11_QTY ;
				iLossQty = RSUMHORLOS.TIME11_LOSS_QTY;
			}
			//11~12
			if ((memcmp(s_sys_time+8, "110000", 6) >= 0) && (memcmp(s_sys_time+8, "120000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME12_QTY ;
				iLossQty = RSUMHORLOS.TIME12_LOSS_QTY;
			}
			//12~13 
			if ((memcmp(s_sys_time+8, "120000", 6) >= 0) && (memcmp(s_sys_time+8, "130000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME13_QTY ;
				iLossQty = RSUMHORLOS.TIME13_LOSS_QTY;
			}
			//13~14 
			if ((memcmp(s_sys_time+8, "130000", 6) >= 0) && (memcmp(s_sys_time+8, "140000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME14_QTY ;
				iLossQty = RSUMHORLOS.TIME14_LOSS_QTY;
			}
			//14~15 
			if ((memcmp(s_sys_time+8, "140000", 6) >= 0) && (memcmp(s_sys_time+8, "150000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME15_QTY ;
				iLossQty = RSUMHORLOS.TIME15_LOSS_QTY;
			}
			//15~16 
			if ((memcmp(s_sys_time+8, "150000", 6) >= 0) && (memcmp(s_sys_time+8, "160000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME16_QTY ;
				iLossQty = RSUMHORLOS.TIME16_LOSS_QTY;
			}
			//16~17 
			if ((memcmp(s_sys_time+8, "160000", 6) >= 0) && (memcmp(s_sys_time+8, "170000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME17_QTY ;
				iLossQty = RSUMHORLOS.TIME17_LOSS_QTY;
			}
			//17~18 
			if ((memcmp(s_sys_time+8, "170000", 6) >= 0) && (memcmp(s_sys_time+8, "180000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME18_QTY ;
				iLossQty = RSUMHORLOS.TIME18_LOSS_QTY;
			}
			//18~19 
			if ((memcmp(s_sys_time+8, "180000", 6) >= 0) && (memcmp(s_sys_time+8, "190000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME19_QTY ;
				iLossQty = RSUMHORLOS.TIME19_LOSS_QTY;
			}
			//19~20 
			if ((memcmp(s_sys_time+8, "190000", 6) >= 0) && (memcmp(s_sys_time+8, "200000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME20_QTY ;
				iLossQty = RSUMHORLOS.TIME20_LOSS_QTY;
			}
			//20~21 
			if ((memcmp(s_sys_time+8, "200000", 6) >= 0) && (memcmp(s_sys_time+8, "210000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME21_QTY ;
				iLossQty = RSUMHORLOS.TIME21_LOSS_QTY;
			}
			//21~22 
			if ((memcmp(s_sys_time+8, "210000", 6) >= 0) && (memcmp(s_sys_time+8, "220000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME22_QTY ;
				iLossQty = RSUMHORLOS.TIME22_LOSS_QTY;
			}
			//22~23 
			if ((memcmp(s_sys_time+8, "220000", 6) >= 0) && (memcmp(s_sys_time+8, "230000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME23_QTY ;
				iLossQty = RSUMHORLOS.TIME23_LOSS_QTY;
			}
			//23~24 
			if ((memcmp(s_sys_time+8, "230000", 6) >= 0) && (memcmp(s_sys_time+8, "240000", 6) < 0))
			{
				iOutQty = RSUMHORMOV.TIME24_QTY ;
				iLossQty = RSUMHORLOS.TIME24_LOSS_QTY;
			}
		}

		//ROSSRATE
		dLossRate = (iLossQty / iOutQty) * 100;

		//SAMPLE SIZE
		if (iOutQty < COM_atoi(MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3)))
			continue;

		if (dLossRate <= 0)
			dLossRate = 0;

		

		//SPC 데이터 생성 
		DBC_init_mspcchtdef(&MSPCCHTDEF);
		memcpy(MSPCCHTDEF.FACTORY, MGCMLAGDAT.FACTORY, sizeof(MSPCCHTDEF.FACTORY));
		memcpy(MSPCCHTDEF.CHART_ID, MGCMLAGDAT.DATA_1, sizeof(MSPCCHTDEF.CHART_ID));
		DBC_select_mspcchtdef(1, &MSPCCHTDEF);
		if(DB_error_code != DB_SUCCESS) 
		{
			continue;
		}

		if (MSPCCHTDEF.DELETE_FLAG == 'Y')
		{
			continue;
		}

				
		CDB_init_ctmpspcdat(&CTMPSPCDAT);
		memcpy(CTMPSPCDAT.LOT_ID, s_sys_time, 14);
		memcpy(CTMPSPCDAT.RES_ID, MSPCCHTDEF.RES_ID, sizeof(MSPCCHTDEF.RES_ID));
		memcpy(CTMPSPCDAT.TRAN_TIME,  s_sys_time, 14);
		CTMPSPCDAT.SEQ_NUM = ++icnt;
		memcpy(CTMPSPCDAT.FACTORY, MSPCCHTDEF.FACTORY, sizeof(CTMPSPCDAT.FACTORY));
		memcpy(CTMPSPCDAT.LINE_ID, MGCMLAGDAT.KEY_1, sizeof(CTMPSPCDAT.LINE_ID));
		memcpy(CTMPSPCDAT.OPER, MGCMLAGDAT.KEY_2, sizeof(CTMPSPCDAT.OPER));
		CTMPSPCDAT.LOT_HIST_SEQ =0;
		memcpy(CTMPSPCDAT.PARAM_NAME, MSPCCHTDEF.CHAR_ID, sizeof(MSPCCHTDEF.CHAR_ID));
		COM_dtoa(CTMPSPCDAT.PARAM_VALUE, COM_dbl_round(dLossRate, 3, 'U'), sizeof(CTMPSPCDAT.PARAM_VALUE));
		memcpy(CTMPSPCDAT.CHART_ID, MSPCCHTDEF.CHART_ID, sizeof(MSPCCHTDEF.CHART_ID));

		COM_itoa_left(CTMPSPCDAT.CMF_2, (int)iOutQty, sizeof(CTMPSPCDAT.CMF_2));
		COM_itoa_left(CTMPSPCDAT.CMF_3, (int)iLossQty, sizeof(CTMPSPCDAT.CMF_3));
		CDB_insert_ctmpspcdat(&CTMPSPCDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NTOHING
		}
		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
CSUM_BatchProcess_Summary_LossRate_Validation()
- Validation check sub function of "CSUM_BatchProcess_Summary_LossRate" function
- Check the Conditions before Custom End Lot Function List
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Summary_LossRate_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

