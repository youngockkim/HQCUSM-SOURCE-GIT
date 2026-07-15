/********************************************************************************

System      : MESplus
Module      : CUS
File Name   : CSUM_BatchProcess_SummaryFunction.c
Description : TRASACTION º° SUMMARY FUNCTION

MES Version : 5.3.x

Function List

Detail Description
// MTMPLOTHIS ±âÁØµ¥ÀÌÅÍ¸¦ ÀÐ¾î¼­  SUMMARY ¹× ÇÊ¿äÇÑ µ¥ÀÌÅÍ Ã³¸® ÁøÇà.

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2018/11/27  Juhyeon.Jung       Crea	te        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include "WIPCore_common.h"


/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_ENDLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_ENDLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	char c_insertflag = 'N';
	char c_ignore_flag = 'N';
	char c_start_flag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		//º°µµ·Î Ã³¸®ÇÔ
		DLLH_VALUE = -1;
		return MP_TRUE;
	}
	else
	{
		DLLH_VALUE = 1;
	}

	//HISOTRY ¸¦ µÚÁ®¼­ ÇöÀç ½ÇÀûÀÌ ÇÑ¹øÀÌ¶óµµ ÀÖÀ¸¸é ´Ù½Ã ½ÇÀûÀ» ÇÏÁö ¾ÊÀ½.
	CDB_init_mwiplothis(&MWIPLOTHIS);
	memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
	memcpy(MWIPLOTHIS.TRAN_CODE, MTMPLOTHIS->TRAN_CODE, sizeof(MTMPLOTHIS->TRAN_CODE));
	memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
	if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) > 0)
	{
		c_ignore_flag = 'Y';
		return MP_TRUE;
	}
	//if (memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0)
	//{
	//	//FQC ÀÏ°æ¿ì µî±Þ / ÆÄ¿ö°¡ ³ª¿À´Â°ÍÀÌ FQC 2 ÀÌ¹Ç·Î FQC 2±âÁØÀ¸·Î ÀâÀ½.
	//}
	//else
	//{
	//	
	//}

	/* STRING ½ÇÀûÀÏ°æ¿ì LEFT/RIGHT °¡ ¾Æ´Ï¸é ¼ö¸®Ç°ÀÌ¹Ç·Î ½ÇÀû ´Ù½Ã ¾ÈÀâÀ½ */
	if (memcmp(MTMPLOTHIS->CREATE_CODE, HQCEL_LOT_CREATECODE_STRING, strlen(HQCEL_LOT_CREATECODE_STRING)) == 0)
	{
		//SUB-RESOURCE / LEFT - RIGHT
		if (MTMPLOTHIS->CM_KEY_4[0] != 'R'  && MTMPLOTHIS->CM_KEY_4[0] != 'L')
		{
			c_ignore_flag = 'Y';
			return MP_TRUE;
		}
	}

	//HISOTRY ¸¦ µÚÁ®¼­ ÇØ´ç °øÁ¤¿¡ START µÈ ½ÇÀûÀÌ ¾ø´Ù¸é END ½Ã °°ÀÌ Ã³¸®ÇÔ..
	CDB_init_mwiplothis(&MWIPLOTHIS);
	memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
	memcpy(MWIPLOTHIS.TRAN_CODE, "START", strlen("START"));
	memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
	if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) < 1)
	{
		c_start_flag = 'Y';  // START ½ÇÀûÀÌ ¾øÀ»°æ¿ì END ½ÇÀû ±âÁØÀ¸·Î °°ÀÌ Ã³¸®ÇÔ.
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	/* Current Operation END Transaction Summary */
	c_insertflag = 'N';

    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->OLD_FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->OLD_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->OLD_MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->OLD_FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->OLD_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->OLD_LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
	memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
	memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
	memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
	memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    
    if(cur_work_time.work_shift == 1)
    {
        RSUMWIPMOV.S1_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S1_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S1_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S1_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		
		if (c_start_flag == 'Y')
		{
			RSUMWIPMOV.S1_START_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S1_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S1_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S1_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

			RSUMWIPMOV.S1_OPER_IN_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S1_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S1_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S1_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
    }

    if(cur_work_time.work_shift == 2)
    {
        RSUMWIPMOV.S2_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S2_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S2_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S2_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		
		if (c_start_flag == 'Y')
		{
			RSUMWIPMOV.S2_START_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S2_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S2_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S2_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

			RSUMWIPMOV.S2_OPER_IN_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S2_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S2_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S2_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
		
    }

    if(cur_work_time.work_shift == 3)
    {
        RSUMWIPMOV.S3_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S3_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S3_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S3_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		
		if (c_start_flag == 'Y')
		{
			RSUMWIPMOV.S3_START_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S3_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S3_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S3_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

			RSUMWIPMOV.S3_OPER_IN_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S3_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S3_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S3_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
		
    }

    if(cur_work_time.work_shift == 4)
    {
        RSUMWIPMOV.S4_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S4_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S4_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S4_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		
		if (c_start_flag == 'Y')
		{
			RSUMWIPMOV.S4_START_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S4_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S4_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S4_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

			RSUMWIPMOV.S4_OPER_IN_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S4_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S4_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S4_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
		
    }

    if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT PRIVIOUS OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}



/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_STARTLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_STARTLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';
	char c_ignore_flag = 'N';
	
	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		//ÄÉÀÌ½º º°·Î ÇâÈÄ º°µµ Ã³¸®ÇÔ.
		DLLH_VALUE = -1;
		return MP_TRUE;
	}
	else
	{
		DLLH_VALUE = 1;
	}

	//HISOTRY ¸¦ µÚÁ®¼­ ÇöÀç °øÁ¤¿¡ START OR END °¡ ÇÑ¹øÀÌ¶óµµ ¾ø¾ú´Ù¸é ´Ù½Ã ½ÇÀûÀ» Ã³¸®ÇÏÁö ¾ÊÀ½.
	//START
	CDB_init_mwiplothis(&MWIPLOTHIS);
	memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
	memcpy(MWIPLOTHIS.TRAN_CODE, MTMPLOTHIS->TRAN_CODE, sizeof(MTMPLOTHIS->TRAN_CODE));
	memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
	if (CDB_select_mwiplothis_scalar(3, &MWIPLOTHIS) > 0)
	{
		c_ignore_flag = 'Y';
		return MP_TRUE;
	}

	//END
	CDB_init_mwiplothis(&MWIPLOTHIS);
	memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
	memcpy(MWIPLOTHIS.TRAN_CODE, "END", 3);
	memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
	if (CDB_select_mwiplothis_scalar(3, &MWIPLOTHIS) > 0)
	{
		c_ignore_flag = 'Y';
		return MP_TRUE;
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);
	
	
	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
		RSUMWIPMOV.S1_START_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S1_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S1_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S1_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

		RSUMWIPMOV.S1_OPER_IN_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S1_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S1_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S1_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 2)
    {
		RSUMWIPMOV.S2_START_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S2_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S2_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S2_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

		RSUMWIPMOV.S2_OPER_IN_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S2_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S2_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S2_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 3)
    {
		RSUMWIPMOV.S3_START_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S3_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S3_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S3_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

		RSUMWIPMOV.S3_OPER_IN_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S3_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S3_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S3_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 4)
    {
		RSUMWIPMOV.S4_START_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S4_START_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S4_START_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S4_START_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

		RSUMWIPMOV.S4_OPER_IN_LOT += (int)DLLH_VALUE * 1;
		RSUMWIPMOV.S4_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
		RSUMWIPMOV.S4_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
		RSUMWIPMOV.S4_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}

/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_CREATELOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_CREATELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	
	return MP_TRUE;
}

/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_ADAPTLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_ADAPTLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//Ç°¹øÀÌ Æ²·ÁÁö¸é
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
        RSUMWIPMOV.S1_CHG_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
		RSUMWIPMOV.S1_CHG_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
		RSUMWIPMOV.S1_CHG_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
    }

    if(cur_work_time.work_shift == 2)
    {
        RSUMWIPMOV.S2_CHG_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
        RSUMWIPMOV.S2_CHG_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
        RSUMWIPMOV.S2_CHG_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
    }

    if(cur_work_time.work_shift == 3)
    {
        RSUMWIPMOV.S3_CHG_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
        RSUMWIPMOV.S3_CHG_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
        RSUMWIPMOV.S3_CHG_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
    }

    if(cur_work_time.work_shift == 4)
    {
        RSUMWIPMOV.S4_CHG_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
        RSUMWIPMOV.S4_CHG_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);  
        RSUMWIPMOV.S4_CHG_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);  
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	/***********************************************************/
	/* Old Operation Value Change */
	/***********************************************************/
	c_insertflag = 'N';
	/* Process Previous Operation */
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->OLD_FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->OLD_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->OLD_MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->OLD_FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->OLD_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->OLD_LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->OLD_ORDER_ID, sizeof(MTMPLOTHIS->OLD_ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->OLD_CM_KEY_1, sizeof(MTMPLOTHIS->OLD_CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->OLD_CM_KEY_2, sizeof(MTMPLOTHIS->OLD_CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->OLD_CM_KEY_3, sizeof(MTMPLOTHIS->OLD_CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->OLD_CM_KEY_4, sizeof(MTMPLOTHIS->OLD_CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->OLD_CM_KEY_5, sizeof(MTMPLOTHIS->OLD_CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}
	
	if(cur_work_time.work_shift == 1)
    {
        RSUMWIPMOV.S1_CHG_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S1_CHG_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_2);
        RSUMWIPMOV.S1_CHG_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_3);
    }

    if(cur_work_time.work_shift == 2)
    {
        RSUMWIPMOV.S2_CHG_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S2_CHG_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_2);
        RSUMWIPMOV.S2_CHG_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_3);
    }

    if(cur_work_time.work_shift == 3)
    {
        RSUMWIPMOV.S3_CHG_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S3_CHG_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_2);
        RSUMWIPMOV.S3_CHG_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_3);
    }

    if(cur_work_time.work_shift == 4)
    {
        RSUMWIPMOV.S4_CHG_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S4_CHG_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_2);  
        RSUMWIPMOV.S4_CHG_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->OLD_QTY_3);  
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}


/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_SPLITLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_SPLITLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';
    int etc_qty = 0;

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	

	//SPLIT .MERGE --> FROM ±âÁØ À¸·Î¸¸ Ã³¸®ÇÔ. TO ´Â SKIP
	if (MTMPLOTHIS->FROM_TO_FLAG == 'T')
	{
		return MP_TRUE;
	}

	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	//Ç°¹ø/FLOW/°øÁ¤ÀÌ °°À¸¸é ¼ö·®º¯°æ ¾ÈÇÔ.
	if ((memcmp(MTMPLOTHIS->OPER, MTMPLOTHIS->FROM_TO_OPER, sizeof(MTMPLOTHIS->FROM_TO_OPER))  == 0) &&
		(memcmp(MTMPLOTHIS->FLOW, MTMPLOTHIS->FROM_TO_FLOW, sizeof(MTMPLOTHIS->FLOW))  == 0) &&
		(memcmp(MTMPLOTHIS->MAT_ID, MTMPLOTHIS->FROM_TO_MAT_ID, sizeof(MTMPLOTHIS->MAT_ID))  == 0))
	{
		return MP_TRUE;
	}

    
	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->FROM_TO_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->FROM_TO_MAT_VER;
	memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FROM_TO_FLOW, sizeof(RSUMWIPMOV.FLOW));
	RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FROM_TO_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->FROM_TO_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(etc_qty > 0)
    {
        if(cur_work_time.work_shift == 1)
        {
		    if(MTMPLOTHIS->RWK_FLAG!='Y')
            {
                RSUMWIPMOV.S1_LOSS_QTY_2 += DLLH_VALUE * etc_qty;
            }
            else
            {
                RSUMWIPMOV.S1_LOSS_RWK_QTY_2 += DLLH_VALUE * etc_qty;
            }
        }

        if(cur_work_time.work_shift == 2)
        {
		    if(MTMPLOTHIS->RWK_FLAG!='Y')
            {
                RSUMWIPMOV.S2_LOSS_QTY_2 += DLLH_VALUE * etc_qty;
            }
            else
            {
                RSUMWIPMOV.S2_LOSS_RWK_QTY_2 += DLLH_VALUE * etc_qty;
            }
        }

        if(cur_work_time.work_shift == 3)
        {
		    if(MTMPLOTHIS->RWK_FLAG!='Y')
            {
                RSUMWIPMOV.S3_LOSS_QTY_2 += DLLH_VALUE * etc_qty;
            }
            else
            {
                RSUMWIPMOV.S3_LOSS_RWK_QTY_2 += DLLH_VALUE * etc_qty;
            }
        }

        if(cur_work_time.work_shift == 4)
        {
		    if(MTMPLOTHIS->RWK_FLAG!='Y')
            {
                RSUMWIPMOV.S4_LOSS_QTY_2 += DLLH_VALUE * etc_qty;
            }
            else
            {
                RSUMWIPMOV.S4_LOSS_RWK_QTY_2 += DLLH_VALUE * etc_qty;
            } 
        }
    }

    if(cur_work_time.work_shift == 1)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S1_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S1_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S1_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S1_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 2)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S2_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S2_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S2_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S2_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 3)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S3_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S3_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S3_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S3_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 4)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S4_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S4_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S4_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S4_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	//if(MTMPLOTHIS->HIST_SEQ <=1)
	//{
	//	//½Å±Ô ·¹ÄÚµå´Â OLD_OPER °¡ ¾øÀ½. //FROM ±âÁØÀ¸·Î¸¸ Ã³¸®ÇÔ.
	//	return MP_TRUE;
	//}

	/***********************************************************/
	/* Old Operation Value Change */
	/***********************************************************/
	c_insertflag = 'N';

	/* Process Previous Operation */
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->OLD_FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->OLD_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->OLD_MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->OLD_FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->OLD_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->OLD_LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->OLD_ORDER_ID, sizeof(MTMPLOTHIS->OLD_ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->OLD_CM_KEY_1, sizeof(MTMPLOTHIS->OLD_CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->OLD_CM_KEY_2, sizeof(MTMPLOTHIS->OLD_CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->OLD_CM_KEY_3, sizeof(MTMPLOTHIS->OLD_CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->OLD_CM_KEY_4, sizeof(MTMPLOTHIS->OLD_CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->OLD_CM_KEY_5, sizeof(MTMPLOTHIS->OLD_CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}
	
	if(cur_work_time.work_shift == 1)
    {
		RSUMWIPMOV.S1_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S1_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S1_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 2)
    {
        RSUMWIPMOV.S2_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S2_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S2_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 3)
    {
        RSUMWIPMOV.S3_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S3_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S3_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 4)
    {
        RSUMWIPMOV.S4_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S4_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S4_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    } 

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}



/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_LOSSLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_LOSSLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';
    int etc_qty = 0;

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            //RSUMWIPMOV.S1_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S1_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1 - etc_qty);
            //RSUMWIPMOV.S1_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S1_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2 - etc_qty);
            RSUMWIPMOV.S1_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3 - etc_qty);
        }
        else
        {
            //RSUMWIPMOV.S1_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S1_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1 - etc_qty);
            //RSUMWIPMOV.S1_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S1_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2 - etc_qty);
            RSUMWIPMOV.S1_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3 - etc_qty);
        }
    }

    if(cur_work_time.work_shift == 2)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            //RSUMWIPMOV.S2_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S2_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1 - etc_qty);
            //RSUMWIPMOV.S2_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S2_LOSS_QTY_2+= DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2 - etc_qty);
            RSUMWIPMOV.S2_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3);
        }
        else
        {
            //RSUMWIPMOV.S2_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S2_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1 - etc_qty);
            //RSUMWIPMOV.S2_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S2_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2 - etc_qty);
            RSUMWIPMOV.S2_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3);
        }
    }

    if(cur_work_time.work_shift == 3)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            //RSUMWIPMOV.S3_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S3_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1 - etc_qty);
            //RSUMWIPMOV.S3_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S3_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2 - etc_qty);
            RSUMWIPMOV.S3_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3);
        }
        else
        {
            //RSUMWIPMOV.S3_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S3_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1 - etc_qty);
            //RSUMWIPMOV.S3_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S3_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2 - etc_qty);
            RSUMWIPMOV.S3_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3);
        }
    }

    if(cur_work_time.work_shift == 4)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            RSUMWIPMOV.S4_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S4_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S4_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3);
        }
        else
        {
            RSUMWIPMOV.S4_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_1 - MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S4_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_2 - MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S4_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->OLD_QTY_3 - MTMPLOTHIS->QTY_3);
        } 
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	/*if (c_insertflag == 'Y')
	{
	CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
	CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}

	if (DB_error_code != DB_SUCCESS) 
	{
	strcpy(s_msg_code, "WIP-0004"); 
	TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
	TRS.add_dberrmsg(out_node, DB_error_msg);
	TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
	TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

	gs_log_type.type = MP_LOG_ERROR;
	gs_log_type.e_type = MP_LOG_E_SYSTEM;
	gs_log_type.category = MP_LOG_CATE_TRANS;

	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	return MP_FALSE;
	}*/

	return MP_TRUE;
}



/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_MERGELOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_MERGELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;

	//SPLIT .MERGE --> FROM ±âÁØ À¸·Î¸¸ Ã³¸®ÇÔ. TO ´Â SKIP
	if (MTMPLOTHIS->FROM_TO_FLAG == 'T')
	{
		return MP_TRUE;
	}
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->FROM_TO_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->FROM_TO_MAT_VER;
	memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FROM_TO_FLOW, sizeof(RSUMWIPMOV.FLOW));
	RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FROM_TO_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->FROM_TO_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S1_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S1_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S1_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S1_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 2)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S2_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S2_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S2_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S2_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 3)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S3_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S3_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S3_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S3_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 4)
    {
		if(MTMPLOTHIS->HIST_SEQ == 1)
			RSUMWIPMOV.S4_MOVE_LOT += (int)DLLH_VALUE * 1;

        RSUMWIPMOV.S4_MOVE_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_1);
		RSUMWIPMOV.S4_MOVE_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_2);
		RSUMWIPMOV.S4_MOVE_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->FROM_TO_QTY_3);
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	//if(MTMPLOTHIS->HIST_SEQ <=1)
	//{
	//	//½Å±Ô ·¹ÄÚµå´Â OLD_OPER °¡ ¾øÀ½. //FROM ±âÁØÀ¸·Î¸¸ Ã³¸®ÇÔ.
	//	return MP_TRUE;
	//}

	/***********************************************************/
	/* Old Operation Value Change */
	/***********************************************************/
	c_insertflag = 'N';

	/* Process Previous Operation */
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->OLD_FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->OLD_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->OLD_MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->OLD_FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->OLD_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->OLD_LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->OLD_ORDER_ID, sizeof(MTMPLOTHIS->OLD_ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->OLD_CM_KEY_1, sizeof(MTMPLOTHIS->OLD_CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->OLD_CM_KEY_2, sizeof(MTMPLOTHIS->OLD_CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->OLD_CM_KEY_3, sizeof(MTMPLOTHIS->OLD_CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->OLD_CM_KEY_4, sizeof(MTMPLOTHIS->OLD_CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->OLD_CM_KEY_5, sizeof(MTMPLOTHIS->OLD_CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}
	
	if(cur_work_time.work_shift == 1)
    {
		RSUMWIPMOV.S1_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S1_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S1_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 2)
    {
        RSUMWIPMOV.S2_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S2_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S2_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 3)
    {
        RSUMWIPMOV.S3_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S3_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S3_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    }

    if(cur_work_time.work_shift == 4)
    {
        RSUMWIPMOV.S4_MOVE_QTY_1 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_1);
        RSUMWIPMOV.S4_MOVE_QTY_2 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_2);
        RSUMWIPMOV.S4_MOVE_QTY_3 += DLLH_VALUE * (-MTMPLOTHIS->FROM_TO_QTY_3);
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}


/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_CVLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_CVLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));

	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
		RSUMWIPMOV.S1_CV_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1 - MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S1_CV_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2 - MTMPLOTHIS->OLD_QTY_2);
        RSUMWIPMOV.S1_CV_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3 - MTMPLOTHIS->OLD_QTY_3);
    }

    if(cur_work_time.work_shift == 2)
    {
		RSUMWIPMOV.S2_CV_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1 - MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S2_CV_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2 - MTMPLOTHIS->OLD_QTY_2);
        RSUMWIPMOV.S2_CV_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3 - MTMPLOTHIS->OLD_QTY_3);
    }

    if(cur_work_time.work_shift == 3)
    {
		RSUMWIPMOV.S3_CV_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1 - MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S3_CV_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2 - MTMPLOTHIS->OLD_QTY_2);
        RSUMWIPMOV.S3_CV_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3 - MTMPLOTHIS->OLD_QTY_3);
    }

    if(cur_work_time.work_shift == 4)
    {
		RSUMWIPMOV.S4_CV_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1 - MTMPLOTHIS->OLD_QTY_1);
        RSUMWIPMOV.S4_CV_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2 - MTMPLOTHIS->OLD_QTY_2);
        RSUMWIPMOV.S4_CV_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3 - MTMPLOTHIS->OLD_QTY_3);    
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}



/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_COMBINELOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_COMBINELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	struct MWIPLOTCMB_TAG MWIPLOTCMB;
	struct CWIPLOTSTR_TAG CWIPLOTSTR;
	struct CWIPLOTMAT_TAG CWIPLOTMAT_STR;
	struct CWIPLOTMAT_TAG CWIPLOTMAT;
	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct CWIPLOTRPS_TAG CWIPLOTRPS;		//25.04.02 MRP (오토 모듈 리페어) 지난 모듈 CWIPLOTSTR 저장건


	double d_max_seq_num = 0;
	int i_openstep = 0;
	char c_vmag_update_flag = 'N';
	
	/* HALF CELL -> STRING À¸·Î COMBINE */
	if (memcmp(MTMPLOTHIS->CREATE_CODE, HQCEL_LOT_CREATECODE_STRING, strlen(HQCEL_LOT_CREATECODE_STRING)) == 0)
	{
		//STRING ÀÏ°æ¿ì Ã³¸® ( CELL BOX TRACE Á¤º¸ »ý¼º )
		CDB_init_cwipcelpak(&CWIPCELPAK);
		CWIPCELPAK.PACK_TYPE = 'H';
		memcpy(CWIPCELPAK.CMF_1, MTMPLOTHIS->FROM_TO_LOT_ID, sizeof(MTMPLOTHIS->FROM_TO_LOT_ID)); //CMF_1 ¿¡ HALFCELL BOX ¿¡ ´ëÇÑ °¡»óLOT
		CDB_select_cwipcelpak(6, &CWIPCELPAK);
		if(DB_error_code != DB_SUCCESS)
		{
			return MP_TRUE;
		} 

		//STRING ¿¡ »ç¿ëÇÑ µ¿ÀÏÇÑ CELL BOX ÀÚÀç ID °¡ ÀÖ´ÂÁö Ã¼Å©ÇÏ°í ¾øÀ¸¸é Ãß°¡ÇÔ
		d_max_seq_num = 0;
            
		CDB_init_cwiplotmat(&CWIPLOTMAT);
		memcpy(CWIPLOTMAT.FACTORY, MTMPLOTHIS->FACTORY, sizeof(CWIPLOTMAT.FACTORY));
		memcpy(CWIPLOTMAT.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(CWIPLOTMAT.LOT_ID));
		memcpy(CWIPLOTMAT.RES_ID, CWIPCELPAK.CMF_6, sizeof(CWIPLOTMAT.RES_ID));
		CWIPLOTMAT.POSITION_ID[0] = MTMPLOTHIS->LOT_ID[2];
		CWIPLOTMAT.HIST_SEQ = 1 ;
		memcpy(CWIPLOTMAT.INV_LOT_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID));
		memcpy(CWIPLOTMAT.MAT_TYPE, "CELL", 4);
		d_max_seq_num = CDB_select_cwiplotmat_scalar(100, &CWIPLOTMAT);
		CDB_select_cwiplotmat(2, &CWIPLOTMAT);
		if(DB_error_code == DB_SUCCESS)
		{ 
			return MP_TRUE;
		}

		//¾øÀ¸¸é »õ·Î µî·ÏÇÔ.
		memcpy(CWIPLOTMAT.INV_BARCODE_ID, CWIPCELPAK.CELLBOXBARCODE, sizeof(CWIPCELPAK.CELLBOXBARCODE));

		if (COM_isspace(CWIPLOTMAT.INV_BARCODE_ID, sizeof(CWIPLOTMAT.INV_BARCODE_ID)) == MP_TRUE)
		{
			memcpy(CWIPLOTMAT.INV_BARCODE_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID));
		}

		memcpy(CWIPLOTMAT.INV_MAT_ID, CWIPCELPAK.MAT_ID, sizeof(CWIPCELPAK.MAT_ID));
		memcpy(CWIPLOTMAT.INV_MAT_DESC,CWIPCELPAK.CELLTYPE, sizeof(CWIPCELPAK.CELLTYPE));
		memcpy(CWIPLOTMAT.UNIT, CWIPCELPAK.UNIT_ID, sizeof(CWIPCELPAK.UNIT_ID));
		memcpy(CWIPLOTMAT.USE_BATCH_ID, CWIPCELPAK.GR_BATCHNO, sizeof(CWIPLOTMAT.USE_BATCH_ID));
		memcpy(CWIPLOTMAT.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(MTMPLOTHIS->MAT_ID));
		memcpy(CWIPLOTMAT.FLOW, MTMPLOTHIS->FLOW, sizeof(MTMPLOTHIS->FLOW));
		CWIPLOTMAT.ATTACH_QTY = CWIPCELPAK.PACK_QTY;

		if (COM_isspace(MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3)) == MP_FALSE){
			CWIPLOTMAT.USED_QTY = COM_atoi(MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3)) / 12;
		}
		else {
			CWIPLOTMAT.USED_QTY = 12;
		}
		memcpy(CWIPLOTMAT.ATTACH_TIME, CWIPCELPAK.CMF_3, sizeof(CWIPLOTMAT.ATTACH_TIME));
		memcpy(CWIPLOTMAT.ATTACH_USER_ID, MTMPLOTHIS->TRAN_USER_ID, sizeof(MTMPLOTHIS->TRAN_USER_ID));
		memcpy(CWIPLOTMAT.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));

		CDB_insert_cwiplotmat(&CWIPLOTMAT);
		if(DB_error_code != DB_SUCCESS)
		{ 
			//DO NOTHING
		}

		return MP_TRUE;
	}
	
	if (memcmp(MTMPLOTHIS->CREATE_CODE, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE)) != 0)
	{
		//MODULE ÀÌ ¾Æ´Ï°Í Á¦¿Ü
		return MP_TRUE;
	}
	

	if (MTMPLOTHIS->FROM_TO_FLAG != 'T')
	{
		//MODULE - MOTHER LOT ±âÁØ¸¸ Ã³¸®.. È¤½Ã CREATE CODE °¡ ¾Èµé¾î¿Ã°æ¿ì ´ëºñ
		return MP_TRUE;
	}

	/*
	
	/* STRING -> MODULE À¸·Î COMBINE ÇÑ°æ¿ì */

	DBC_init_mwipmatdef(&MWIPMATDEF);
	memcpy(MWIPMATDEF.FACTORY, MTMPLOTHIS->FACTORY, sizeof(MTMPLOTHIS->FACTORY));
	memcpy(MWIPMATDEF.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	MWIPMATDEF.MAT_VER = 1;
	DBC_select_mwipmatdef(1, &MWIPMATDEF);
	{
		//DO NOTHING
	}
	//MAT_CMF_3 144 MAT_CMF_2 = 'N'
	//MAT_CMF_3 120	MAT_CMF_2 = 'Y'
	//MAT_CMF_3 156
	//MAT_CMF_3 132

	//i_openstep = 2; 
	if (memcmp(MWIPMATDEF.MAT_CMF_3, "120", strlen("120")) == 0)
	{
		i_openstep = 3;
	}
	else if (memcmp(MWIPMATDEF.MAT_CMF_3, "144", strlen("144")) == 0)
	{
		i_openstep = 2; 
	}
	else if (memcmp(MWIPMATDEF.MAT_CMF_3, "156", strlen("156")) == 0)
	{
		i_openstep = 4; 
	}
	else if (memcmp(MWIPMATDEF.MAT_CMF_3, "132", strlen("132")) == 0)
	{
		i_openstep = 5; 
	}
	else if (memcmp(MWIPMATDEF.MAT_CMF_3, "108", strlen("108")) == 0)
	{
		i_openstep = 6; 
	}

	//i_openstep = 2; 

	////120 CELL CHECK
	//if (MWIPMATDEF.MAT_CMF_2[0] == 'Y')
	//{
	//	i_openstep = 3;
	//}

	c_vmag_update_flag = 'N';
	
	if(DB_error_code != DB_SUCCESS)
	CDB_init_mwiplotcmb(&MWIPLOTCMB);
	memcpy(MWIPLOTCMB.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MTMPLOTHIS->LOT_ID));
	CDB_open_mwiplotcmb(i_openstep, &MWIPLOTCMB);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "MWIPLOTCMB OPEN", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		CDB_fetch_mwiplotcmb(i_openstep, &MWIPLOTCMB);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			CDB_close_mwiplotcmb(i_openstep);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "MWIPLOTCMB FETCH", MP_NVST);
			TRS.set_fieldmsg(out_node, "ITEM CODE", MP_STR, sizeof(MTMPLOTHIS->LOT_ID), MTMPLOTHIS->LOT_ID);				
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			CDB_close_mwiplotcmb(i_openstep);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CDB_init_cwiplotstr(&CWIPLOTSTR);
		memcpy(CWIPLOTSTR.FACTORY, MWIPLOTCMB.FACTORY, sizeof(MWIPLOTCMB.FACTORY));
		memcpy(CWIPLOTSTR.LOT_ID, MWIPLOTCMB.LOT_ID, sizeof(MWIPLOTCMB.LOT_ID));
		memcpy(CWIPLOTSTR.STRING_ID, MWIPLOTCMB.FROM_TO_LOT_ID, sizeof(MWIPLOTCMB.FROM_TO_LOT_ID));
		//CDB_select_cwiplotstr_for_update(1, &CWIPLOTSTR);//code 오류 로 보임
		CDB_select_cwiplotstr(1, &CWIPLOTSTR);

		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				//25.04.02 MRP (오토 모듈 리페어) 지난 모듈 CWIPLOTSTR 저장건
				// CWIPLOTRPS 테이블에 해당 모듈이 있으면 SKIP 한다
				CDB_init_cwiplotrps(&CWIPLOTRPS);
				memcpy(CWIPLOTRPS.FACTORY, CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY));
				memcpy(CWIPLOTRPS.LOT_ID, CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID));
				if (CDB_select_cwiplotrps_scalar(2, &CWIPLOTRPS) < 1)
				{
				
						memcpy(CWIPLOTSTR.STRING_LOC, MWIPLOTCMB.OPER, sizeof(CWIPLOTSTR.STRING_LOC)); //A01, A13 ÀÌ·±°ª µé¾î¿Å.
						CWIPLOTSTR.CMF_2[0] = MWIPLOTCMB.HIST_DEL_FLAG; //R OR L ÀÓ
						COM_itoa_left(CWIPLOTSTR.CMF_3, MWIPLOTCMB.HIST_SEQ, sizeof(CWIPLOTSTR.CMF_3));
						memcpy(CWIPLOTSTR.CREATE_TIME, MWIPLOTCMB.TRAN_TIME, sizeof(CWIPLOTSTR.CREATE_TIME));
						CDB_insert_cwiplotstr(&CWIPLOTSTR);
				}

				//25.04.02 MRP (오토 모듈 리페어) 지난 모듈 CWIPLOTSTR 저장건

			}
		}

		
		//STRING ÀÌ »ç¿ëÇÑ ÀÚÀç LIST
		CDB_init_cwiplotmat(&CWIPLOTMAT_STR);
		memcpy(CWIPLOTMAT_STR.FACTORY, CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY));
		memcpy(CWIPLOTMAT_STR.LOT_ID, CWIPLOTSTR.STRING_ID, sizeof(CWIPLOTSTR.STRING_ID));
		CDB_open_cwiplotmat(2, &CWIPLOTMAT_STR);
		if(DB_error_code != DB_SUCCESS)
		{ 		
			continue;
		}

		while(1)
		{
			CDB_fetch_cwiplotmat(2, &CWIPLOTMAT_STR);
			if(DB_error_code != DB_SUCCESS)
			{ 
				CDB_close_cwiplotmat(2);
				break; 
			}
			
			//MAIN LOT ¿¡ »ç¿ëÇÑ µ¿ÀÏÇÑ ÀÚÀç ID °¡ ÀÖ´ÂÁö Ã¼Å©ÇÏ°í ¾øÀ¸¸é Ãß°¡ÇÔ
			d_max_seq_num = 0;
            
			CDB_init_cwiplotmat(&CWIPLOTMAT);
			memcpy(CWIPLOTMAT.FACTORY, CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY));
			memcpy(CWIPLOTMAT.LOT_ID, CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID));
			memcpy(CWIPLOTMAT.RES_ID, CWIPLOTMAT_STR.RES_ID, sizeof(CWIPLOTMAT_STR.RES_ID));
			memcpy(CWIPLOTMAT.POSITION_ID, CWIPLOTMAT_STR.POSITION_ID, sizeof(CWIPLOTMAT_STR.POSITION_ID));
			memcpy(CWIPLOTMAT.INV_LOT_ID, CWIPLOTMAT_STR.INV_LOT_ID, sizeof(CWIPLOTMAT_STR.INV_LOT_ID));
			CWIPLOTMAT.HIST_SEQ = 1;
			d_max_seq_num = CDB_select_cwiplotmat_scalar(100, &CWIPLOTMAT);
			CDB_select_cwiplotmat(2, &CWIPLOTMAT);
			if(DB_error_code == DB_SUCCESS)
			{ 
				continue;
			}

			//¾øÀ¸¸é »õ·Î µî·ÏÇÔ.
			memcpy(CWIPLOTMAT.FACTORY, CWIPLOTMAT_STR.FACTORY, sizeof(struct CWIPLOTMAT_TAG)); //STRING Á¤º¸¸¦ LOT Á¤º¸·Î COPY
			memset(CWIPLOTMAT.LOT_ID, ' ', sizeof(CWIPLOTMAT.LOT_ID));
			memcpy(CWIPLOTMAT.LOT_ID, CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID)); //STRING LOTÀ» MAIN LOT ID ·Î º¯°æ
			CWIPLOTMAT.HIST_SEQ = 1 ; //TABER °øÁ¤Àº CREATE ÀüÀÓ.
			CWIPLOTMAT.USE_SEQ = (int) d_max_seq_num + 1;
			memset(CWIPLOTMAT.CMF_5, ' ', sizeof(CWIPLOTMAT.CMF_5));
			memcpy(CWIPLOTMAT.CMF_5, CWIPLOTSTR.STRING_ID, sizeof(CWIPLOTSTR.STRING_ID));

			if (COM_isspace(CWIPLOTMAT.OPER, sizeof(CWIPLOTMAT.OPER)) == MP_TRUE)
				memcpy(CWIPLOTMAT.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER));
			
			CDB_insert_cwiplotmat(&CWIPLOTMAT);
			if(DB_error_code != DB_SUCCESS)
			{ 
				continue;
			}

			//VMAGZINE LOT ¿¡ UPDATE
			if ((memcmp(CWIPLOTMAT.MAT_TYPE, "CELL", 4) == 0) && (c_vmag_update_flag == 'N'))
			{
				CDB_init_cwipcelpak(&CWIPCELPAK);
				memcpy(CWIPCELPAK.FACTORY, CWIPLOTMAT.FACTORY, sizeof(CWIPLOTMAT.FACTORY));
				CWIPCELPAK.PACK_TYPE = 'H';
				memcpy(CWIPCELPAK.CELL_BOX_ID, CWIPLOTMAT.INV_LOT_ID, sizeof(CWIPLOTMAT.INV_LOT_ID));
				CWIPCELPAK.STATUS_FLAG = 'C';
				CDB_select_cwipcelpak(3, &CWIPCELPAK);
				if((DB_error_code == DB_SUCCESS) &&(COM_isspace(CWIPCELPAK.CMF_9, sizeof(CWIPCELPAK.CMF_9)) == MP_FALSE))
				{ 
					//WIPLOTSTS VMAGAZINE UPDATE
					struct MWIPLOTSTS_TAG MWIPLOTSTS_L;
					CDB_init_mwiplotsts(&MWIPLOTSTS_L);
					memcpy(MWIPLOTSTS_L.LOT_ID, CWIPLOTMAT.LOT_ID, sizeof(CWIPLOTMAT.LOT_ID));
					memcpy(MWIPLOTSTS_L.LOT_CMF_7, CWIPCELPAK.CMF_8, sizeof(CWIPCELPAK.CMF_8)); //CLV VMAGAZINE
					memcpy(MWIPLOTSTS_L.LOT_CMF_8, CWIPCELPAK.CMF_9, sizeof(CWIPCELPAK.CMF_9)); //TB VMAGAZINE
					if (COM_isspace(MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3)) == MP_FALSE){
						memcpy(MWIPLOTSTS_L.LOT_CMF_9, MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));
					}
					else {
						COM_itoa(MWIPLOTSTS_L.LOT_CMF_9, (int) CWIPLOTMAT.USED_QTY * 12, sizeof(MWIPLOTSTS_L.LOT_CMF_9)); //CELL USED QTY
					}
					memcpy(MWIPLOTSTS_L.LOT_CMF_10, CWIPCELPAK.POWERGRADE, sizeof(MWIPLOTSTS_L.LOT_CMF_10)); //CELL POWER
					memcpy(MWIPLOTSTS_L.LOT_CMF_11, CWIPCELPAK.QUALITYGRADE, sizeof(MWIPLOTSTS_L.LOT_CMF_11)); //CELL GRADE
					memcpy(MWIPLOTSTS_L.LOT_CMF_12, CWIPCELPAK.GR_BATCHNO, sizeof(MWIPLOTSTS_L.LOT_CMF_12)); //BATCH ID
					memcpy(MWIPLOTSTS_L.LOT_CMF_13, CWIPCELPAK.CELL_BOX_ID, sizeof(MWIPLOTSTS_L.LOT_CMF_13)); //CELL_BOX_ID
					COM_dtoa(MWIPLOTSTS_L.LOT_CMF_14, CWIPCELPAK.AVG_NCELL, sizeof(MWIPLOTSTS_L.LOT_CMF_14)); //AVG NCELL

					CDB_update_mwiplotsts(9, &MWIPLOTSTS_L);
					c_vmag_update_flag = 'Y';
				}
			}
		}
	}
	
	return MP_TRUE;
}


/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_REWORKLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_REWORKLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));

	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
		if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S1_OPER_IN_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S1_OPER_IN_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S1_OPER_IN_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S1_OPER_IN_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        }
        else
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S1_OPER_IN_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S1_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S1_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S1_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        } 
    }

    if(cur_work_time.work_shift == 2)
    {
		if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S2_OPER_IN_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S2_OPER_IN_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S2_OPER_IN_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S2_OPER_IN_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        }
        else
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S2_OPER_IN_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S2_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S2_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S2_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        } 
    }

    if(cur_work_time.work_shift == 3)
    {
		if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S3_OPER_IN_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S3_OPER_IN_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S3_OPER_IN_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S3_OPER_IN_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        }
        else
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S3_OPER_IN_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S3_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S3_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S3_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        } 
    }

    if(cur_work_time.work_shift == 4)
    {
		if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S4_OPER_IN_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S4_OPER_IN_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S4_OPER_IN_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S4_OPER_IN_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        }
        else
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                RSUMWIPMOV.S4_OPER_IN_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S4_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S4_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S4_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
            }
        } 
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	/***********************************************************/
	/* Old Operation Value Change */
	/***********************************************************/
	c_insertflag = 'N';

	/* Process Previous Operation */
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->OLD_FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->OLD_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->OLD_MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->OLD_FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->OLD_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->OLD_LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->OLD_ORDER_ID, sizeof(MTMPLOTHIS->OLD_ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->OLD_CM_KEY_1, sizeof(MTMPLOTHIS->OLD_CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->OLD_CM_KEY_2, sizeof(MTMPLOTHIS->OLD_CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->OLD_CM_KEY_3, sizeof(MTMPLOTHIS->OLD_CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->OLD_CM_KEY_4, sizeof(MTMPLOTHIS->OLD_CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->OLD_CM_KEY_5, sizeof(MTMPLOTHIS->OLD_CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));

	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}
	
	if(cur_work_time.work_shift == 1)
    {
        RSUMWIPMOV.S1_TO_RWK_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S1_TO_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S1_TO_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S1_TO_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

        if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                /*RSUMWIPMOV.S1_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S1_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S1_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S1_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
        else
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                /*RSUMWIPMOV.S1_MOVE_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S1_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S1_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S1_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
    }

    if(cur_work_time.work_shift == 2)
    {
        RSUMWIPMOV.S2_TO_RWK_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S2_TO_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S2_TO_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S2_TO_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

        if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
               /* RSUMWIPMOV.S2_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S2_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S2_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S2_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
        else
        {

            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
             /*   RSUMWIPMOV.S2_MOVE_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S2_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S2_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S2_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
    }

    if(cur_work_time.work_shift == 3)
    {
        RSUMWIPMOV.S3_TO_RWK_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S3_TO_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S3_TO_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S3_TO_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

        if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
             /*   RSUMWIPMOV.S3_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S3_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S3_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S3_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
        else
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
              /*  RSUMWIPMOV.S3_MOVE_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S3_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S3_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S3_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
    }

    if(cur_work_time.work_shift == 4)
    {
        RSUMWIPMOV.S4_TO_RWK_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S4_TO_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S4_TO_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S4_TO_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;

        if(MTMPLOTHIS->RWK_FLAG=='Y')
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
                /*RSUMWIPMOV.S4_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S4_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S4_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S4_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
        else
        {
            if(memcmp(MTMPLOTHIS->OLD_FLOW,MTMPLOTHIS->FLOW,sizeof(MTMPLOTHIS->OLD_FLOW))==0 &&
                memcmp(MTMPLOTHIS->OLD_OPER,MTMPLOTHIS->OPER,sizeof(MTMPLOTHIS->OLD_OPER))==0 )
            {
                ;
            }
            else
            {
               /* RSUMWIPMOV.S4_MOVE_LOT += (int)DLLH_VALUE * 1;
                RSUMWIPMOV.S4_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
                RSUMWIPMOV.S4_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
                RSUMWIPMOV.S4_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;*/
            }
        }
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}

/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_SHIPLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_SHIPLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));

	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
		RSUMWIPMOV.S1_OPER_IN_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S1_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S1_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S1_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 2)
    {
		RSUMWIPMOV.S2_OPER_IN_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S2_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S2_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S2_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 3)
    {
		RSUMWIPMOV.S3_OPER_IN_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S3_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S3_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S3_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 4)
    {
		RSUMWIPMOV.S4_OPER_IN_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S4_OPER_IN_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S4_OPER_IN_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S4_OPER_IN_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	/***********************************************************/
	/* Old Operation Value Change */
	/***********************************************************/
	c_insertflag = 'N';

	/* Process Previous Operation */
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->OLD_FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->OLD_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->OLD_MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->OLD_FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->OLD_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->OLD_LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->OLD_ORDER_ID, sizeof(MTMPLOTHIS->OLD_ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->OLD_CM_KEY_1, sizeof(MTMPLOTHIS->OLD_CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->OLD_CM_KEY_2, sizeof(MTMPLOTHIS->OLD_CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->OLD_CM_KEY_3, sizeof(MTMPLOTHIS->OLD_CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->OLD_CM_KEY_4, sizeof(MTMPLOTHIS->OLD_CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->OLD_CM_KEY_5, sizeof(MTMPLOTHIS->OLD_CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));

	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}
	
	if(cur_work_time.work_shift == 1)
    {
        RSUMWIPMOV.S1_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S1_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S1_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S1_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 2)
    {
        RSUMWIPMOV.S2_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S2_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S2_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S2_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 3)
    {
        RSUMWIPMOV.S3_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S3_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S3_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S3_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

    if(cur_work_time.work_shift == 4)
    {
        RSUMWIPMOV.S4_END_LOT += (int)DLLH_VALUE * 1;
        RSUMWIPMOV.S4_END_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
        RSUMWIPMOV.S4_END_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
        RSUMWIPMOV.S4_END_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}


/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_SKIPLOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_SKIPLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	//¾Æ¹«Ã³¸® ¾ÈÇÔ.
	//¹Ýµå½Ã END ÀÌÈÄ SKIP ÇÒ°Í.
	return MP_TRUE;
}




/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_TERMINATELOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_TERMINATELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	char c_insertflag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		DLLH_VALUE = -1;
		//memcpy(s_actual_time, MTMPLOTHIS->HIST_DEL_TIME, sizeof(MTMPLOTHIS->HIST_DEL_TIME));
	}
	else
	{
		DLLH_VALUE = 1;
		//memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);

	/***********************************************************/
	/* Process New Operation */
	/***********************************************************/
    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
    memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
    memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
    memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
    memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    if(cur_work_time.work_shift == 1)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            RSUMWIPMOV.S1_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S1_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S1_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        }
        else
        {
            RSUMWIPMOV.S1_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S1_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S1_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        }
    }

    if(cur_work_time.work_shift == 2)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            RSUMWIPMOV.S2_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S2_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S2_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        }
        else
        {
            RSUMWIPMOV.S2_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S2_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S2_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        }
    }

    if(cur_work_time.work_shift == 3)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            RSUMWIPMOV.S3_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S3_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S3_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        }
        else
        {
            RSUMWIPMOV.S3_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S3_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S3_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        }
    }

    if(cur_work_time.work_shift == 4)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
            RSUMWIPMOV.S4_LOSS_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S4_LOSS_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S4_LOSS_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        }
        else
        {
            RSUMWIPMOV.S4_LOSS_RWK_QTY_1 += DLLH_VALUE * (MTMPLOTHIS->QTY_1);
            RSUMWIPMOV.S4_LOSS_RWK_QTY_2 += DLLH_VALUE * (MTMPLOTHIS->QTY_2);
            RSUMWIPMOV.S4_LOSS_RWK_QTY_3 += DLLH_VALUE * (MTMPLOTHIS->QTY_3);
        } 
    }

	if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT CURRENT OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}

/*******************************************************************************
CSUM_SUMMARY_WIP_TRAN_MOVELOT()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_MOVELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	char s_actual_time[15];
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	char c_insertflag = 'N';
	char c_ignore_flag = 'N';

	struct worktime_tag cur_work_time;

	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	
	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		//º°µµ·Î Ã³¸®ÇÔ
		DLLH_VALUE = -1;
		return MP_TRUE;
	}
	else
	{
		DLLH_VALUE = 1;
	}

	//HISOTRY ¸¦ µÚÁ®¼­ ÇöÀç ½ÇÀûÀÌ ÇÑ¹øÀÌ¶óµµ ÀÖÀ¸¸é ´Ù½Ã ½ÇÀûÀ» ÇÏÁö ¾ÊÀ½.
	CDB_init_mwiplothis(&MWIPLOTHIS);
	memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
	memcpy(MWIPLOTHIS.TRAN_CODE, MTMPLOTHIS->TRAN_CODE, sizeof(MTMPLOTHIS->TRAN_CODE));
	memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
	if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) > 0)
	{
		c_ignore_flag = 'Y';
		return MP_TRUE;
	}
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	/* Current Operation END Transaction Summary */
	c_insertflag = 'N';

    CDB_init_rsumwipmov(&RSUMWIPMOV);
    memcpy(RSUMWIPMOV.FACTORY, MTMPLOTHIS->OLD_FACTORY, sizeof(RSUMWIPMOV.FACTORY));
    memcpy(RSUMWIPMOV.MAT_ID, MTMPLOTHIS->OLD_MAT_ID, sizeof(RSUMWIPMOV.MAT_ID));
    RSUMWIPMOV.MAT_VER = MTMPLOTHIS->OLD_MAT_VER;
    memcpy(RSUMWIPMOV.FLOW, MTMPLOTHIS->OLD_FLOW, sizeof(RSUMWIPMOV.FLOW));
    RSUMWIPMOV.FLOW_SEQ_NUM = MTMPLOTHIS->OLD_FLOW_SEQ_NUM;
    memcpy(RSUMWIPMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMWIPMOV.OPER));
    RSUMWIPMOV.LOT_TYPE = MTMPLOTHIS->OLD_LOT_TYPE;
    memcpy(RSUMWIPMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));
	memcpy(RSUMWIPMOV.CM_KEY_1, MTMPLOTHIS->CM_KEY_1, sizeof(MTMPLOTHIS->CM_KEY_1));
	memcpy(RSUMWIPMOV.CM_KEY_2, MTMPLOTHIS->CM_KEY_2, sizeof(MTMPLOTHIS->CM_KEY_2));
	memcpy(RSUMWIPMOV.CM_KEY_3, MTMPLOTHIS->CM_KEY_3, sizeof(MTMPLOTHIS->CM_KEY_3));
	memcpy(RSUMWIPMOV.CM_KEY_4, MTMPLOTHIS->CM_KEY_4, sizeof(MTMPLOTHIS->CM_KEY_4));
	memcpy(RSUMWIPMOV.CM_KEY_5, MTMPLOTHIS->CM_KEY_5, sizeof(MTMPLOTHIS->CM_KEY_5));
    memcpy(RSUMWIPMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMWIPMOV.WORK_DATE));
	COM_itoa_left(RSUMWIPMOV.WORK_MONTH, cur_work_time.work_month, sizeof(RSUMWIPMOV.WORK_MONTH));
	COM_itoa_left(RSUMWIPMOV.WORK_WEEK, cur_work_time.work_week, sizeof(RSUMWIPMOV.WORK_WEEK));
	COM_itoa_left(RSUMWIPMOV.WORK_DAYS, cur_work_time.work_days, sizeof(RSUMWIPMOV.WORK_DAYS));
	RSUMWIPMOV.WORK_DAY_OF_WEEK = (char)(cur_work_time.work_day_of_week +  '0');
	CDB_select_rsumwipmov_for_update(1, &RSUMWIPMOV);
    if (DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_insertflag= 'Y';
		}
	}

    
    if(cur_work_time.work_shift == 1)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
			RSUMWIPMOV.S1_MOVE_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S1_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S1_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S1_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
		else
		{
			RSUMWIPMOV.S1_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S1_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S1_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S1_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
    }

    if(cur_work_time.work_shift == 2)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
			RSUMWIPMOV.S2_MOVE_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S2_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S2_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S2_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
		else
		{
			RSUMWIPMOV.S2_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S2_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S2_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S2_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
    }

    if(cur_work_time.work_shift == 3)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
			RSUMWIPMOV.S3_MOVE_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S3_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S3_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S3_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
		else
		{
			RSUMWIPMOV.S3_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S3_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S3_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S3_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
    }

    if(cur_work_time.work_shift == 4)
    {
		if(MTMPLOTHIS->RWK_FLAG!='Y')
        {
			RSUMWIPMOV.S4_MOVE_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S4_MOVE_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S4_MOVE_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S4_MOVE_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
		else
		{
			RSUMWIPMOV.S4_MOVE_RWK_LOT += (int)DLLH_VALUE * 1;
			RSUMWIPMOV.S4_MOVE_RWK_QTY_1 += DLLH_VALUE * MTMPLOTHIS->QTY_1;
			RSUMWIPMOV.S4_MOVE_RWK_QTY_2 += DLLH_VALUE * MTMPLOTHIS->QTY_2;
			RSUMWIPMOV.S4_MOVE_RWK_QTY_3 += DLLH_VALUE * MTMPLOTHIS->QTY_3;
		}
    }

    if (c_insertflag == 'Y')
	{
		CDB_insert_rsumwipmov(&RSUMWIPMOV);
	}
	else
	{
		CDB_update_rsumwipmov(1, &RSUMWIPMOV);
	}
    
    if (DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004"); 
		TRS.set_fieldmsg(out_node, "RSUMWIPMOV UPDATE/INSERT PRIVIOUS OPER", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	return MP_TRUE;
}

/*******************************************************************************
CSUM_SYNC_WIP_TRAN_STATUS()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_TRAN_HOUR(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	int	 DLLH_VALUE;
	int  i_qty;
	char s_actual_time[15];
	char c_ignore_flag = 'N';
	char c_el1_flag = 'N';
	char c_el1_loss_flag = 'N';
	int iFqcTmpQty = 0;
	char c_FqcTmpFlag = 'Y';

	struct worktime_tag cur_work_time;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;

	struct RSUMHORMOV_TAG RSUMHORMOV;
	struct RSUMHORLOS_TAG RSUMHORLOS;
	struct RSUMHORWRK_TAG RSUMHORWRK;

	struct CWIPLOTTRC_TAG CWIPLOTTRC;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPCALDEF_TAG MWIPCALDEF;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_TMP;

	/* DLLH CHECK */
	if(MTMPLOTHIS->HIST_DEL_FLAG == 'Y')
	{
		//º°µµ  CODING
		DLLH_VALUE = -1;
		return MP_TRUE;
	}
	else
	{
		DLLH_VALUE = 1;
	}
	
	c_el1_flag = 'N';  //Àü´Ü EL
	memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash ÃÊ±âÈ­ µÇÁö ¾ÊÀº º¯¼ö
	memcpy(s_actual_time, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	/* WORK CALENDAR : ÇØ´ç SHIFT ÀÇ Á¶¸¦ µî·ÏÇÔ. */
	DBC_init_mwipcaldef(&MWIPCALDEF);
	memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //ÇØ´ç Ä®·»´Ù·Î º¯°æÇÊ¿ä.
    MWIPCALDEF.CALENDAR_TYPE = 'F';
    MWIPCALDEF.SYS_YEAR = cur_work_time.work_year;
    MWIPCALDEF.SYS_MONTH = cur_work_time.work_month;
    MWIPCALDEF.SYS_DAY = COM_atoi(cur_work_time.work_date+6,2) ;
    DBC_select_mwipcaldef(1, &MWIPCALDEF);
    if (DB_error_code != DB_SUCCESS)
	{
		//DO NOTHGIN
	}
	
	if (COM_isspace(MWIPCALDEF.CAL_CMF_1, sizeof(MWIPCALDEF.CAL_CMF_1)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_1[0] = 'A';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_2, sizeof(MWIPCALDEF.CAL_CMF_2)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_2[0] = 'B';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_3, sizeof(MWIPCALDEF.CAL_CMF_3)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_3[0] = 'C';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_4, sizeof(MWIPCALDEF.CAL_CMF_4)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_4[0] = 'D';

	
	/* MWIPELTSTS TABLE */
	if (memcmp(MTMPLOTHIS->CREATE_CODE, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE)) == 0)
	{
		CDB_init_mwipeltsts(&MWIPELTSTS);
		memcpy(MWIPELTSTS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MTMPLOTHIS->LOT_ID));
		CDB_select_mwipeltsts(1, &MWIPELTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			MWIPELTSTS.HIST_SEQ = 1;
			memcpy(MWIPELTSTS.CURING_TIME, MTMPLOTHIS->CREATE_TIME, sizeof(MWIPELTSTS.CURING_TIME)) ;//ÆÄÆ¼¼ÇÅ°·Î »ç¿ëÇÏ°í ÀÖÀ¸¹Ç·Î ¾÷µ¥ÀÌÆ® ±ÝÁö
			CDB_insert_mwipeltsts(&MWIPELTSTS);
		}
	}

	DBC_init_mrasresdef(&MRASRESDEF);
	memcpy(MRASRESDEF.FACTORY, MTMPLOTHIS->FACTORY, sizeof(MTMPLOTHIS->FACTORY));
	memcpy(MRASRESDEF.RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
	if (COM_isspace(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID)) == MP_TRUE)
	{
		memcpy(MRASRESDEF.RES_ID, MTMPLOTHIS->START_RES_ID, sizeof(MTMPLOTHIS->START_RES_ID));
	}
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if (DB_error_code == DB_SUCCESS)
	{
		//DO NOTHING
	}

	
	/*************************************************************/
	//LOT TRACE TABLE CWIPLOTTRC UPDATE
	/*************************************************************/
	/* CWIPLOTTRC TABLE */
	CDB_init_cwiplottrc(&CWIPLOTTRC);
	memcpy(CWIPLOTTRC.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MTMPLOTHIS->LOT_ID));
	CDB_select_cwiplottrc_for_update(1, &CWIPLOTTRC);
	if (DB_error_code != DB_SUCCESS)
	{
		memcpy(CWIPLOTTRC.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date)); //ÆÄÆ¼¼ÇKEY ÀÌÈÄ ÀÓÀÇ ¾÷µ¥ÀÌÆ® ¸»°Í.
		CDB_insert_cwiplottrc(&CWIPLOTTRC);
	}

	if (COM_isspace(CWIPLOTTRC.WORK_ORDER, sizeof(CWIPLOTTRC.WORK_ORDER)) == MP_TRUE)
		memcpy(CWIPLOTTRC.WORK_ORDER, MTMPLOTHIS->ORDER_ID, sizeof(MTMPLOTHIS->ORDER_ID));

	if (COM_isspace(CWIPLOTTRC.WORK_DATE, sizeof(CWIPLOTTRC.WORK_DATE)) == MP_TRUE)
		memcpy(CWIPLOTTRC.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date)); //ÆÄÆ¼¼ÇKEY ÀÌÈÄ ÀÓÀÇ ¾÷µ¥ÀÌÆ® ¸»°Í.

	if (COM_isspace(CWIPLOTTRC.WORK_LINE, sizeof(CWIPLOTTRC.WORK_LINE)) == MP_TRUE)
		memcpy(CWIPLOTTRC.WORK_LINE, MTMPLOTHIS->LOT_CMF_1, sizeof(CWIPLOTTRC.WORK_LINE));
	
	
	memcpy(CWIPLOTTRC.FACTORY, MTMPLOTHIS->FACTORY, sizeof(MTMPLOTHIS->FACTORY));
	
	if (COM_isspace(CWIPLOTTRC.WORK_LINE, sizeof(CWIPLOTTRC.WORK_LINE)) == MP_TRUE)
	{
		if (cur_work_time.work_shift ==  1)
			CWIPLOTTRC.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
	
		if (cur_work_time.work_shift ==  2)
			CWIPLOTTRC.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		
		if (cur_work_time.work_shift ==  3)
			CWIPLOTTRC.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];

		if (cur_work_time.work_shift ==  4)
			CWIPLOTTRC.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];
	
	
	}
	
	memset(CWIPLOTTRC.MAT_ID, ' ' , sizeof(CWIPLOTTRC.MAT_ID));
	memset(CWIPLOTTRC.FLOW, ' ' , sizeof(CWIPLOTTRC.FLOW));
	memset(CWIPLOTTRC.OPER, ' ' , sizeof(CWIPLOTTRC.OPER));
	memcpy(CWIPLOTTRC.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(MTMPLOTHIS->MAT_ID));
	memcpy(CWIPLOTTRC.FLOW, MTMPLOTHIS->FLOW, sizeof(MTMPLOTHIS->FLOW));
	memcpy(CWIPLOTTRC.OPER, MTMPLOTHIS->OPER, sizeof(MTMPLOTHIS->OPER));

	
	//LAYUP END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_LAYUP_OPER, strlen(HQCEL_M1_LAYUP_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		struct CWIPLOTSTR_TAG CWIPLOTSTR;
		struct CWIPCELPAK_TAG CWIPCELPAK;

		memcpy(CWIPLOTTRC.LAY_RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(CWIPLOTTRC.EL1_RES_ID));
		memcpy(CWIPLOTTRC.LAY_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

		//TABBER ¼³ºñ±îÁö Ã³¸®ÇÔ
		memcpy(CWIPLOTTRC.TAB_RES_ID, MRASRESDEF.RES_CMF_6, sizeof(CWIPLOTTRC.TAB_RES_ID));
		memcpy(CWIPLOTTRC.TAB_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
		
		//¼ö¸®STRING »ç¿ë
		CDB_init_cwiplotstr(&CWIPLOTSTR);
		memcpy(CWIPLOTSTR.FACTORY, MTMPLOTHIS->FACTORY, sizeof(CWIPLOTSTR.FACTORY));
		memcpy(CWIPLOTSTR.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(CWIPLOTSTR.LOT_ID));
		
		if
		(
		(memcmp(MTMPLOTHIS->CM_KEY_1 ,"MDL04", 5) == 0)
		|| (memcmp(MTMPLOTHIS->CM_KEY_1 ,"MDL05", 5) == 0)
		|| (memcmp(MTMPLOTHIS->CM_KEY_1 ,"MDL06", 5) == 0)
		|| (memcmp(MTMPLOTHIS->CM_KEY_1 ,"MDL07", 5) == 0)
		)
		{
			CWIPLOTSTR.CMF_2[0] = 'F';;
		}
		else
		{
			CWIPLOTSTR.CMF_2[0] = '0';
		}

		if (CDB_select_cwiplotstr_scalar(3, &CWIPLOTSTR) > 0)
		{
			//¼ö¸®ÀÏ°æ¿ì REP·Î Ç¥½Ã
			memset(CWIPLOTTRC.CMF1, ' ', sizeof(CWIPLOTTRC.CMF1));
			memcpy(CWIPLOTTRC.CMF1, "REP",3);
		}
		
		//[26.02.26] MWIPLOTSTS.LOT_CMF_7 에 따른 RSUMHORMOV.CM_KEY_3 수정 요청 - 시작 
		if (CDB_select_cwiplotstr_scalar(4, &CWIPLOTSTR) > 0)
		{
			//¼ö¸®ÀÏ°æ¿ì REP·Î Ç¥½Ã
			memset(CWIPLOTTRC.CMF1, ' ', sizeof(CWIPLOTTRC.CMF1));
			memcpy(CWIPLOTTRC.CMF1, "OK",2);
		}
		//[26.02.26] MWIPLOTSTS.LOT_CMF_7 에 따른 RSUMHORMOV.CM_KEY_3 수정 요청 - 종료



		//CLEAVING ¼³ºñ ¹× CELL BOX
		CDB_init_cwipcelpak(&CWIPCELPAK);
		memcpy(CWIPCELPAK.CELL_BOX_ID, MTMPLOTHIS->LOT_ID, sizeof(MTMPLOTHIS->LOT_ID));
		CWIPCELPAK.PACK_TYPE = 'F';
		CDB_select_cwipcelpak(7, &CWIPCELPAK);
		if (DB_error_code == DB_SUCCESS)
		{
			memcpy(CWIPLOTTRC.CLV_RES_ID, CWIPCELPAK.CMF_4, sizeof(CWIPLOTTRC.CLV_RES_ID));
			memcpy(CWIPLOTTRC.CLV_TIME, CWIPCELPAK.CMF_2, 14);
			memcpy(CWIPLOTTRC.CELL_INVLOT_ID, CWIPCELPAK.RCV_CELLBOX_ID, sizeof(CWIPCELPAK.RCV_CELLBOX_ID));
			memcpy(CWIPLOTTRC.CELL_MAT_ID, CWIPCELPAK.MAT_ID, sizeof(CWIPCELPAK.MAT_ID));
			memcpy(CWIPLOTTRC.CLV_ORDER_ID, CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));
		}
		
	}

	//SOLDERING 
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_SOLDER_OPER, strlen(HQCEL_M1_SOLDER_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.BUS_RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.BUS_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//FEEDING 
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_FEEDING_OPER, strlen(HQCEL_M1_FEEDING_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.FEED_RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.FEED_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	
	//1ST EL END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.EL1_RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.EL1_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));

		//EL ½ÇÀûÀÏ °æ¿ì ELºÒ·® SUMMARY ±îÁö ¼öÇà.
		c_el1_flag = 'Y';
	}

	//LAMI END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_LAMI_OPER, strlen(HQCEL_M1_LAMI_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.LAM_RES_ID,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.LAM_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//TRIMMING END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_TRIMMING_OPER, strlen(HQCEL_M1_TRIMMING_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.EPE_RES_ID,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.EPE_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//AOI END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_AOI_OPER, strlen(HQCEL_M1_AOI_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.AOI_RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.AOI_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//ATTACH JUNCTION BOX END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_ATTCH_JBX_OPER, strlen(HQCEL_M1_ATTCH_JBX_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.JBX_INS_RES_ID ,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.JBX_INS_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//ASSEMBLY FRAME END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_ASSEMBLY_FRAME_OPER, strlen(HQCEL_M1_ASSEMBLY_FRAME_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.FRM_RES_ID ,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.FRM_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//SIMULATOR END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_SIMULATOR_OPER, strlen(HQCEL_M1_SIMULATOR_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.SIM_RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(CWIPLOTTRC.FQC1_RES_ID));
		memcpy(CWIPLOTTRC.SIM_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//HIPOT END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_HIPOT_OPER, strlen(HQCEL_M1_HIPOT_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.HIP_RES_ID ,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.HIP_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
		//23.07.19 E2/E3Àº HI-POT/GR Å×½ºÆ®¸¦ µ¿½Ã ÁøÇàÇÔ
       if (memcmp(MRASRESDEF.RES_LOCATION, "E2", strlen("E2")) == 0) {
			memcpy(CWIPLOTTRC.EXT_DATA_1, MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
			memcpy(CWIPLOTTRC.EXT_DATA_2, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
         }
	}
	
	//2ND EL END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.EL2_RES_ID ,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.EL2_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//PORTING END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_POTTING_OPER, strlen(HQCEL_M1_POTTING_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.JBX_POT_RES_ID ,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.JBX_POT_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//CURING END TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_CURING_OPER, strlen(HQCEL_M1_CURING_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.CUR_RES_ID ,MTMPLOTHIS->END_RES_ID, sizeof(MTMPLOTHIS->END_RES_ID));
		memcpy(CWIPLOTTRC.CUR_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//GROUND TEST TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_GROUND_TEST_OPER, strlen(HQCEL_M1_GROUND_TEST_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.EXT_DATA_1, MTMPLOTHIS->END_RES_ID, sizeof(CWIPLOTTRC.FQC1_RES_ID));
		memcpy(CWIPLOTTRC.EXT_DATA_2, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	
	//FQC TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.FQC1_RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(CWIPLOTTRC.FQC1_RES_ID));
		memcpy(CWIPLOTTRC.FQC1_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}

	//PACKING TIME
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_PACKING_OPER, strlen(HQCEL_M1_PACKING_OPER)) == 0)
		&& (c_ignore_flag == 'N'))
	{
		memcpy(CWIPLOTTRC.EXT_DATA_3, MTMPLOTHIS->END_RES_ID, sizeof(CWIPLOTTRC.FQC1_RES_ID));
		memcpy(CWIPLOTTRC.PACKING_TIME, MTMPLOTHIS->TRAN_TIME, sizeof(MTMPLOTHIS->TRAN_TIME));
	}
	
	CDB_update_cwiplottrc(1, &CWIPLOTTRC);
	if (DB_error_code != DB_SUCCESS)
	{

	}

	/*************************************************************/
	//Àü´Ü EL ÀÏ°æ¿ì LOSS ¼ö·®ÀÌ ÀÖ´ÂÁö ¸ÕÀú Ã¼Å©ÇÔ.
	/*************************************************************/
	if ( c_el1_flag == 'Y')
	{
		c_el1_loss_flag = 'N';
		CDB_init_cedclotrlt(&CEDCLOTRLT);
		memcpy(CEDCLOTRLT.FACTORY, CWIPLOTTRC.FACTORY, sizeof(CWIPLOTTRC.FACTORY));
		memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_LOSS_CATEGORY_EL1, strlen(HQCEL_LOSS_CATEGORY_EL1));
		memcpy(CEDCLOTRLT.LOT_ID, CWIPLOTTRC.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
		CDB_select_cedclotrlt(1, &CEDCLOTRLT);

		if (DB_error_code == DB_SUCCESS) 
		{
			if (memcmp(CEDCLOTRLT.RESULT_VALUE, "OK", 2) != 0)
				c_el1_loss_flag = 'Y';
		}
	}
	
	/*************************************************************/
	/*½Ã°£º° µ¥ÀÌÅÍ Ã³¸®.*/
	/*************************************************************/
	CDB_init_rsumhorwrk(&RSUMHORWRK); // ÀÛ¾÷±âÁØ
    CDB_init_rsumhormov(&RSUMHORMOV); // ÅõÀÔ±âÁØ
    memcpy(RSUMHORMOV.FACTORY, MTMPLOTHIS->FACTORY, sizeof(RSUMHORMOV.FACTORY));
	memcpy(RSUMHORMOV.WORK_DATE, cur_work_time.work_date, sizeof(RSUMHORMOV.WORK_DATE));
	
	if (cur_work_time.work_shift ==  1)
		RSUMHORMOV.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
	
	if (cur_work_time.work_shift ==  2)
		RSUMHORMOV.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		
	if (cur_work_time.work_shift ==  3)
		RSUMHORMOV.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];

	if (cur_work_time.work_shift ==  4)
		RSUMHORMOV.WORK_SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];

	memcpy(RSUMHORMOV.RES_ID, MTMPLOTHIS->END_RES_ID, sizeof(RSUMHORMOV.RES_ID));
	memcpy(RSUMHORMOV.MAT_ID, MTMPLOTHIS->MAT_ID, sizeof(RSUMHORMOV.MAT_ID));
	memcpy(RSUMHORMOV.OPER, MTMPLOTHIS->OLD_OPER, sizeof(RSUMHORMOV.OPER));
	memcpy(RSUMHORMOV.ORDER_ID, MTMPLOTHIS->ORDER_ID, sizeof(RSUMHORMOV.ORDER_ID));

	memcpy(RSUMHORMOV.FQC_GRADE, MTMPLOTHIS->CM_KEY_4, sizeof(RSUMHORMOV.FQC_GRADE));
	memcpy(RSUMHORMOV.FQC_POWER, MTMPLOTHIS->CM_KEY_2, sizeof(RSUMHORMOV.FQC_POWER));
	memcpy(RSUMHORMOV.CM_KEY_1, CWIPLOTTRC.TAB_RES_ID, sizeof(CWIPLOTTRC.TAB_RES_ID));

	/* STRING ½ÇÀûÀÏ°æ¿ì LEFT/RIGHT TABLE */
	if (memcmp(MTMPLOTHIS->CREATE_CODE, HQCEL_LOT_CREATECODE_STRING, strlen(HQCEL_LOT_CREATECODE_STRING)) == 0)
	{
		//SUB-RESOURCE / LEFT - RIGHT
		RSUMHORMOV.CM_KEY_2[0] = MTMPLOTHIS->LOT_ID[2] ;
	}

	//[기술검토]RSUMHORMOV.CM_KEY_2/ RSUMHORLOS.CM_KEY_1 추가 검토 문의]2025.10.23 START
	if (memcmp(RSUMHORMOV.OPER, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
	{
		//SUB-RESOURCE / LEFT - RIGHT
		memcpy(RSUMHORMOV.CM_KEY_2, CWIPLOTTRC.BUS_RES_ID , sizeof(CWIPLOTTRC.BUS_RES_ID));
	}
	//[기술검토]RSUMHORMOV.CM_KEY_2/ RSUMHORLOS.CM_KEY_1 추가 검토 문의]2025.10.23 END

	//CM_KEY_3 : ¼ö¸®STRING »ç¿ë¿©ºÎ
	memcpy(RSUMHORMOV.CM_KEY_3, CWIPLOTTRC.CMF1, sizeof(CWIPLOTTRC.CMF1));
	
	//DATA COPY (RSUMHORMOV ->RSUMHORWRK)
	memcpy(RSUMHORWRK.FACTORY, RSUMHORMOV.FACTORY, sizeof(struct RSUMHORWRK_TAG));

	//RSUNHORMOV ¿Í RSUMHORWRK ´Â ¶óÀÎ±âÁØ¸¸ Æ²¸²
	memcpy(RSUMHORMOV.LINE_ID, MTMPLOTHIS->LOT_CMF_1, sizeof(RSUMHORMOV.LINE_ID));
	memcpy(RSUMHORWRK.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(RSUMHORWRK.LINE_ID));

	c_ignore_flag = 'N';
	i_qty =  (int)MTMPLOTHIS->QTY_1;

	//RSUMHORMOV TABLE
	{
		CDB_select_rsumhormov_for_update(1, &RSUMHORMOV);
		if (DB_error_code != DB_SUCCESS)
		{
			CDB_insert_rsumhormov(&RSUMHORMOV);
		}
	}

	//RSUMHORWRK TABLE
	{
		CDB_select_rsumhorwrk_for_update(1, &RSUMHORWRK);
		if (DB_error_code != DB_SUCCESS)
		{
			CDB_insert_rsumhorwrk(&RSUMHORWRK);
		}
	}

	//HISOTRY ¸¦ µÚÁ®¼­ ÇöÀç ½ÇÀûÀÌ ÇÑ¹øÀÌ¶óµµ ÀÖÀ¸¸é ´Ù½Ã ½ÇÀûÀ» ÇÏÁö ¾ÊÀ½.
	if (memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0)
	{
		if (memcmp(MTMPLOTHIS->OPER, HQCEL_M1_PACKING_OPER, strlen(HQCEL_M1_PACKING_OPER)) == 0)
		{
			//FQC->PACKING ´ë±â À¸·Î °£°æ¿ì
			//°Ë»çµ¥ÀÌÅÍ°¡ ÀÖÀ¸¸é ½ÇÀûÀ» ÀâÀ½
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, MTMPLOTHIS->FACTORY, sizeof(CEDCLOTRLT.FACTORY));
			memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			memcpy(CEDCLOTRLT.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
			CDB_select_cedclotrlt(1, &CEDCLOTRLT);
			if (DB_error_code == DB_SUCCESS) 
			{
				CDB_init_mwiplothis(&MWIPLOTHIS);
				memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
				memcpy(MWIPLOTHIS.TRAN_CODE, MTMPLOTHIS->TRAN_CODE, sizeof(MTMPLOTHIS->TRAN_CODE));
				memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	
				MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
				if (CDB_select_mwiplothis_scalar(4, &MWIPLOTHIS) > 0)
				{
					c_ignore_flag = 'Y';
					i_qty = 0;
				}
			}
			else
			{
				//°Ë»çµ¥ÀÌÅÍ ¾øÀ¸¸é ½ÇÀûÀ» ¾ÈÀâÀ½
				c_ignore_flag = 'Y';
				i_qty = 0;
			}
		}
		else if (COM_isspace(MTMPLOTHIS->TRAN_CMF_2, sizeof(MTMPLOTHIS->TRAN_CMF_2)) == MP_TRUE)
		{
			//	FQC ÀÌ¸é ONLY °Ë»çµ¥ÀÌÅÍ¸¸ ½ÇÀûÀ» ÀâÀ½.
			c_ignore_flag = 'Y';
			i_qty = 0;
		}
		else
		{
			CDB_init_mwiplothis(&MWIPLOTHIS);
			memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
			memcpy(MWIPLOTHIS.TRAN_CODE, MTMPLOTHIS->TRAN_CODE, sizeof(MTMPLOTHIS->TRAN_CODE));
			memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	
			MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
			if (CDB_select_mwiplothis_scalar(4, &MWIPLOTHIS) > 0)
			{
				c_ignore_flag = 'Y';
				i_qty = 0;
			}
		}
		
	}
	else
	{
		CDB_init_mwiplothis(&MWIPLOTHIS);
		memcpy(MWIPLOTHIS.LOT_ID, MTMPLOTHIS->LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		memcpy(MWIPLOTHIS.TRAN_CODE, MTMPLOTHIS->TRAN_CODE, sizeof(MTMPLOTHIS->TRAN_CODE));
		memcpy(MWIPLOTHIS.OLD_OPER, MTMPLOTHIS->OLD_OPER, sizeof(MTMPLOTHIS->OLD_OPER));
	
		MWIPLOTHIS.HIST_SEQ = MTMPLOTHIS->HIST_SEQ;
		if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) > 0)
		{
			c_ignore_flag = 'Y';
			i_qty = 0;
		}
	}
	

	/* STRING ½ÇÀûÀÏ°æ¿ì LEFT/RIGHT °¡ ¾Æ´Ï¸é ¼ö¸®Ç°ÀÌ¹Ç·Î ½ÇÀû ´Ù½Ã ¾ÈÀâÀ½ */
	if (memcmp(MTMPLOTHIS->CREATE_CODE, HQCEL_LOT_CREATECODE_STRING, strlen(HQCEL_LOT_CREATECODE_STRING)) == 0)
	{
		//SUB-RESOURCE / LEFT - RIGHT
		if (RSUMHORMOV.CM_KEY_2[0] != 'R'  && RSUMHORMOV.CM_KEY_2[0] != 'L')
		{
			c_ignore_flag = 'Y';
			i_qty = 0;
		}
	}
	
	RSUMHORMOV.INPUT_QTY = RSUMHORMOV.INPUT_QTY + i_qty;
	RSUMHORWRK.INPUT_QTY = RSUMHORWRK.INPUT_QTY + i_qty;

	//½Ã°£º° ºÒ·® SUMMARY 
	CDB_init_rsumhorlos(&RSUMHORLOS);
	memcpy(RSUMHORLOS.FACTORY, CWIPLOTTRC.FACTORY, sizeof(RSUMHORLOS.FACTORY));
	memcpy(RSUMHORLOS.WORK_DATE, RSUMHORMOV.WORK_DATE, sizeof(RSUMHORMOV.WORK_DATE));
	memcpy(RSUMHORLOS.WORK_SHIFT, RSUMHORMOV.WORK_SHIFT, sizeof(RSUMHORMOV.WORK_SHIFT));
	memcpy(RSUMHORLOS.LINE_ID, RSUMHORMOV.LINE_ID, sizeof(RSUMHORMOV.LINE_ID));
	memcpy(RSUMHORLOS.RES_ID, RSUMHORMOV.RES_ID, sizeof(RSUMHORMOV.RES_ID));
	memcpy(RSUMHORLOS.MAT_ID, RSUMHORMOV.MAT_ID, sizeof(RSUMHORMOV.MAT_ID));
	memcpy(RSUMHORLOS.OPER, RSUMHORMOV.OPER, sizeof(RSUMHORMOV.OPER));
	memcpy(RSUMHORLOS.CAUSE_RES_ID, CWIPLOTTRC.TAB_RES_ID, sizeof(RSUMHORLOS.CAUSE_RES_ID));
	memcpy(RSUMHORLOS.ORDER_ID, CWIPLOTTRC.WORK_ORDER, sizeof(RSUMHORLOS.ORDER_ID));

	/* FQC ½Ã°£º° ½ÇÀûÀº CEDCLOTRLT (°Ë»ç½ÇÀû) ±âÁØÀ¸·Î ½ÇÀûÀ» º¸°í ÀÖ¾î ½ÇÀû µ¿±âÈ­ ÁøÇà */
	CDB_init_cedclotrlt(&CEDCLOTRLT_TMP);
	c_FqcTmpFlag = 'N';
	iFqcTmpQty = 0;
	if ((memcmp(MTMPLOTHIS->OLD_OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0) && (c_ignore_flag == 'N'))
	{
		//FQC ½Ã°£º° ½ÇÀûÀº °Ë»ç µ¥ÀÌÅÍ ±âÁØÀ¸·Î º°µµ·Î °è»êÇÔ.
		/* FQC º¸Á¤·ÎÁ÷ Àû¿ë¾ÈÇÔ . °Ë»çµ¥ÀÌÅÍ ¹Þ¾ÒÀ»¶§¸¸ END ÇÏ´Â°ÍÀ¸·Î º¯°æÇÔ */
		/*
		memcpy(CEDCLOTRLT_TMP.FACTORY, RSUMHORMOV.FACTORY, sizeof(RSUMHORMOV.FACTORY));
		memcpy(CEDCLOTRLT_TMP.ORDER_ID, RSUMHORMOV.ORDER_ID, sizeof(RSUMHORMOV.ORDER_ID));
		memcpy(CEDCLOTRLT_TMP.GRADE, RSUMHORMOV.FQC_GRADE, sizeof(CEDCLOTRLT_TMP.GRADE));
		memcpy(CEDCLOTRLT_TMP.POWER, RSUMHORMOV.FQC_POWER, sizeof(CEDCLOTRLT_TMP.POWER));
		memcpy(CEDCLOTRLT_TMP.CMF_1, cur_work_time.work_shift_start_time, 14);  //start time
		memcpy(CEDCLOTRLT_TMP.INS_TIME, cur_work_time.work_shift_end_time, 14);  //end time
		memcpy(CEDCLOTRLT_TMP.INS_TYPE, "FC", 2);
		CEDCLOTRLT_TMP.INS_CNT = 1;
		memcpy(CEDCLOTRLT_TMP.CMF_2, RSUMHORMOV.CM_KEY_3, sizeof(RSUMHORMOV.CM_KEY_3)); //rep
		memcpy(CEDCLOTRLT_TMP.CMF_3, RSUMHORMOV.CM_KEY_1, sizeof(RSUMHORMOV.CM_KEY_1)); //tabber
		memcpy(CEDCLOTRLT_TMP.RES_ID, RSUMHORMOV.RES_ID, sizeof(RSUMHORMOV.RES_ID));
		iFqcTmpQty = CDB_select_cedclotrlt_scalar(4, &CEDCLOTRLT_TMP); //TOTAL ½Ã°£

		//INPUT QTY
		RSUMHORMOV.ETC1_QTY = RSUMHORMOV.INPUT_QTY; //ORIGINAL ½ÇÀû QTY (FQC µ¿±âÈ­Àü)
		RSUMHORWRK.ETC1_QTY = RSUMHORMOV.INPUT_QTY; //ORIGINAL ½ÇÀû QTY (FQC µ¿±âÈ­Àü)
		RSUMHORMOV.INPUT_QTY = iFqcTmpQty;
		RSUMHORWRK.INPUT_QTY  = iFqcTmpQty;

		//½Ã°£º° QTY
		iFqcTmpQty = 0;
		memcpy(CEDCLOTRLT_TMP.CMF_4, MTMPLOTHIS->TRAN_TIME+8, 2);
		iFqcTmpQty = CDB_select_cedclotrlt_scalar(3, &CEDCLOTRLT_TMP);
		c_FqcTmpFlag = 'Y';
		*/

	}

	//00~01 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "000000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "010000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME01_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME01_QTY = iFqcTmpQty;
		}
		else
		{	
			RSUMHORMOV.TIME01_QTY = RSUMHORMOV.TIME01_QTY + i_qty;
			RSUMHORWRK.TIME01_QTY = RSUMHORWRK.TIME01_QTY + i_qty;
		}
		
	}
	//01~02 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "010000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "020000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME02_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME02_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME02_QTY = RSUMHORMOV.TIME02_QTY + i_qty;
			RSUMHORWRK.TIME02_QTY = RSUMHORWRK.TIME02_QTY + i_qty;
		}
	}
	//02~03 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "020000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "030000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME03_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME03_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME03_QTY = RSUMHORMOV.TIME03_QTY + i_qty;
			RSUMHORWRK.TIME03_QTY = RSUMHORWRK.TIME03_QTY + i_qty;
		}
	}
	//03~04 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "030000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "040000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME04_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME04_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME04_QTY = RSUMHORMOV.TIME04_QTY + i_qty;
			RSUMHORWRK.TIME04_QTY = RSUMHORWRK.TIME04_QTY + i_qty;
		}
	}
	//04~05 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "040000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "050000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME05_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME05_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME05_QTY = RSUMHORMOV.TIME05_QTY + i_qty;
			RSUMHORWRK.TIME05_QTY = RSUMHORWRK.TIME05_QTY + i_qty;
		}
	}
	//05~06 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "050000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "060000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME06_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME06_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME06_QTY = RSUMHORMOV.TIME06_QTY + i_qty;
			RSUMHORWRK.TIME06_QTY = RSUMHORWRK.TIME06_QTY + i_qty;
		}
	}
	//06~07 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "060000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "070000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME07_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME07_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME07_QTY = RSUMHORMOV.TIME07_QTY + i_qty;
			RSUMHORWRK.TIME07_QTY = RSUMHORWRK.TIME07_QTY + i_qty;
		}
	}
	//07~08 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "070000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "080000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME08_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME08_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME08_QTY = RSUMHORMOV.TIME08_QTY + i_qty;
			RSUMHORWRK.TIME08_QTY = RSUMHORWRK.TIME08_QTY + i_qty;
		}
	}
	//08~09 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "080000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "090000", 6) < 0))
	{
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME09_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME09_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME09_QTY = RSUMHORMOV.TIME09_QTY + i_qty;
			RSUMHORWRK.TIME09_QTY = RSUMHORWRK.TIME09_QTY + i_qty;
		}
	}
	//09~10 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "090000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "100000", 6) < 0))
	{

		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME10_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME10_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME10_QTY = RSUMHORMOV.TIME10_QTY + i_qty;
			RSUMHORWRK.TIME10_QTY = RSUMHORWRK.TIME10_QTY + i_qty;
		}
	}
	//10~11 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "100000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "110000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME11_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME11_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME11_QTY = RSUMHORMOV.TIME11_QTY + i_qty;
			RSUMHORWRK.TIME11_QTY = RSUMHORWRK.TIME11_QTY + i_qty;
		}
	}
	//11~12
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "110000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "120000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME12_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME12_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME12_QTY = RSUMHORMOV.TIME12_QTY + i_qty;
			RSUMHORWRK.TIME12_QTY = RSUMHORWRK.TIME12_QTY + i_qty;
		}
	}
	//12~13 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "120000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "130000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME13_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME13_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME13_QTY = RSUMHORMOV.TIME13_QTY + i_qty;
			RSUMHORWRK.TIME13_QTY = RSUMHORWRK.TIME13_QTY + i_qty;
		}
	}
	//13~14 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "130000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "140000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME14_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME14_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME14_QTY = RSUMHORMOV.TIME14_QTY + i_qty;
			RSUMHORWRK.TIME14_QTY = RSUMHORWRK.TIME14_QTY + i_qty;
		}
	}
	//14~15 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "140000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "150000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME15_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME15_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME15_QTY = RSUMHORMOV.TIME15_QTY + i_qty;
			RSUMHORWRK.TIME15_QTY = RSUMHORWRK.TIME15_QTY + i_qty;
		}
	}
	//15~16 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "150000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "160000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME16_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME16_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME16_QTY = RSUMHORMOV.TIME16_QTY + i_qty;
			RSUMHORWRK.TIME16_QTY = RSUMHORWRK.TIME16_QTY + i_qty;
		}
	}
	//16~17 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "160000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "170000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME17_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME17_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME17_QTY = RSUMHORMOV.TIME17_QTY + i_qty;
			RSUMHORWRK.TIME17_QTY = RSUMHORWRK.TIME17_QTY + i_qty;
		}
	}
	//17~18 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "170000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "180000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME18_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME18_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME18_QTY = RSUMHORMOV.TIME18_QTY + i_qty;
			RSUMHORWRK.TIME18_QTY = RSUMHORWRK.TIME18_QTY + i_qty;
		}
	}
	//18~19 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "180000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "190000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME19_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME19_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME19_QTY = RSUMHORMOV.TIME19_QTY + i_qty;
			RSUMHORWRK.TIME19_QTY = RSUMHORWRK.TIME19_QTY + i_qty;
		}
	}
	//19~20 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "190000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "200000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME20_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME20_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME20_QTY = RSUMHORMOV.TIME20_QTY + i_qty;
			RSUMHORWRK.TIME20_QTY = RSUMHORWRK.TIME20_QTY + i_qty;
		}
	}
	//20~21 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "200000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "210000", 6) < 0))
	{
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME21_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME21_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME21_QTY = RSUMHORMOV.TIME21_QTY + i_qty;
			RSUMHORWRK.TIME21_QTY = RSUMHORWRK.TIME21_QTY + i_qty;
		}
	}
	//21~22 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "210000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "220000", 6) < 0))
	{
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME22_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME22_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME22_QTY = RSUMHORMOV.TIME22_QTY + i_qty;
			RSUMHORWRK.TIME22_QTY = RSUMHORWRK.TIME22_QTY + i_qty;
		}
	}
	//22~23 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "220000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "230000", 6) < 0))
	{
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME23_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME23_QTY = iFqcTmpQty;
		}
		else
		{
			RSUMHORMOV.TIME23_QTY = RSUMHORMOV.TIME23_QTY + i_qty;
			RSUMHORWRK.TIME23_QTY = RSUMHORWRK.TIME23_QTY + i_qty;
		
		}
	}
	//23~24 
	if ((memcmp(MTMPLOTHIS->TRAN_TIME+8, "230000", 6) >= 0) && (memcmp(MTMPLOTHIS->TRAN_TIME+8, "240000", 6) < 0))
	{
		
		if (c_FqcTmpFlag == 'Y')
		{
			RSUMHORMOV.TIME24_QTY = iFqcTmpQty;
			RSUMHORWRK.TIME24_QTY = iFqcTmpQty;
		}else
		{
			RSUMHORMOV.TIME24_QTY = RSUMHORMOV.TIME24_QTY + i_qty;
			RSUMHORWRK.TIME24_QTY = RSUMHORWRK.TIME24_QTY + i_qty;
		}
	}

	
	//ÅõÀÔ±âÁØ ½Ã°£º° ½ÇÀû
	{
		CDB_update_rsumhormov(1, &RSUMHORMOV);
		if (DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}

	//½ÇÀû±âÁØ ½Ã°£º° ½ÇÀû
	{
		CDB_update_rsumhorwrk(1, &RSUMHORWRK);
		if (DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}

	return MP_TRUE;
}

/*******************************************************************************
CSUM_SYNC_WIP_TRAN_STATUS()
- TRANSACDTION SUMMARY RSUMWIPMOV
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SYNC_WIP_TRAN_STATUS(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	
	return MP_TRUE;
}




/*******************************************************************************
CSUM_SUMMARY_WIP_EOH()
- TRANSACDTION SUMMARY RSUMWIPEOH
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_WIP_EOH(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node)
{
	//ÇÊ¿ä½Ã SUMMARY
	return MP_TRUE;
}

