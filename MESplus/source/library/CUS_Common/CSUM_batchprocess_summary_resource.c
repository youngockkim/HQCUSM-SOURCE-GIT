
/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_resource_status_function.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// MTMPRESHIS ±âÁØµ¥ÀÌÅÍ¸¦ ÀÐ¾î¼­  SUMMARY ¹× ÇÊ¿äÇÑ µ¥ÀÌÅÍ Ã³¸® ÁøÇà.

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2019/02/01  YS KIM       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <MESCore_common.h>
#include "ACTCore_common.h"


int CSUM_BATCHPROCESS_SUMMARY_RESOURCE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
CSUM_BatchProcess_Summary_Resource()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Summary_Resource(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;


	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_BATCHPROCESS_SUMMARY_RESOURCE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_SUMMARY_RESOURCE", out_node);

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
CSUM_BATCHPROCESS_TRANSACTION()
- Main sub function of "CSUM_BatchProcess_Transaction" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_SUMMARY_RESOURCE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct RSUMRESDWN_TAG RSUMRESDWN;
	struct RSUMRESDWN_TAG RSUMRESDWN_DATA;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct RSUMRESDWH_TAG RSUMRESDWH;
	
	struct worktime_tag tmp_work_time;

	char s_sys_time[14];
	int i_step  = 0;

	double d_max_value = 0 ;
	char c_shift = ' ';

	char c_process_flag = ' ';


    LOG_head("CSUM_BATCHPROCESS_SUMMARY_RESOURCE");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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
	if(TRS.get_char(in_node, "PROCSTEP") != ' ')
	{
		c_process_flag = TRS.get_char(in_node, "PROCSTEP"); //MAINT ¿ë
		TRS.copy(s_sys_time , 14, in_node,"BACK_TIME");
	}
		
	//0. RSUMRESDWN -7ÀÏÄ¡ÀÇ µ¥ÀÌÅÍ »èÁ¦(¼Óµµ ÀÌ½´·Î º¯°æ)
	//0. RSUMRESDWN -2ÀÏÄ¡ÀÇ µ¥ÀÌÅÍ »èÁ¦
	CDB_init_rsumresdwn(&RSUMRESDWN);
	memcpy(RSUMRESDWN.WORK_DATE, s_sys_time, 8);
	CDB_delete_rsumresdwn(2, &RSUMRESDWN);
	if((DB_error_code != DB_SUCCESS) && (DB_error_code != DB_NOT_FOUND))
    {
		strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "RSUMRESDWN DELETE ERROR", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	else
	{
		DB_commit();		//22.11.30 RSUMRESDWN Å×ÀÌºí lock ¿ìÈ¸ÇÏ±â À§ÇØ
	}


	//1. RSUMRESDWN -2 ~ ÇöÀç ±îÁöÀÇ µ¥ÀÌÅÍ Ãß°¡(¼Óµµ ÀÌ½´·Î º¯°æ)
	//0. RSUMRESDWN -7ÀÏÄ¡ÀÇ µ¥ÀÌÅÍ »èÁ¦
	CDB_init_rsumresdwn(&RSUMRESDWN);
	memcpy(RSUMRESDWN.WORK_DATE, s_sys_time, 8);
	CDB_update_rsumresdwn(901, &RSUMRESDWN);
	if((DB_error_code != DB_SUCCESS) && (DB_error_code != DB_NOT_FOUND))
    {
		strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "RSUMRESDWN DELETE ERROR", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	else
	{
		DB_commit();		//22.11.30 RSUMRESDWN Å×ÀÌºí lock ¿ìÈ¸ÇÏ±â À§ÇØ
	}


	//ÇöÀç±âÁØ ÇöÀçÀÏÀÚÀÇ ÃÖ´ë°ª
	memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
	CCOM_get_work_time(s_sys_time, &tmp_work_time);
	c_shift = CCOM_get_work_shift(s_sys_time);
	CDB_init_rsumresdwn(&RSUMRESDWN);
	memcpy(RSUMRESDWN.WORK_DATE, tmp_work_time.work_date, sizeof(RSUMRESDWN.WORK_DATE));
	d_max_value = CDB_select_rsumresdwn_scalar(2, &RSUMRESDWN);

	//ÇöÀçÀÏÀÚ±âÁØ ÃÖ´ë°ª°ú Æ²¸°³ðµéÀº °ªÃß°¡
	i_step = 3;
	RSUMRESDWN.CMF_VAL_2 = d_max_value;

	CDB_open_rsumresdwn(i_step, &RSUMRESDWN); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "RAS-0004"); 
		TRS.add_fieldmsg(out_node, "RSUMRESDWN OPEN", MP_NVST); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		CDB_fetch_rsumresdwn(i_step, &RSUMRESDWN); 
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_close_rsumresdwn(i_step); 
			break;
		}
		
		//RESOURCE SELECT
		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, RSUMRESDWN.FACTORY, sizeof(RSUMRESDWN.FACTORY));
		memcpy(MRASRESDEF.RES_ID, RSUMRESDWN.RES_ID, sizeof(RSUMRESDWN.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			continue;
		}
		
		//RSUMRESDWN, ¸¶Áö¸· ·¹ÄÚµå °¡Áö°í¿Å.
		CDB_init_rsumresdwh(&RSUMRESDWH);

		memcpy(RSUMRESDWH.FACTORY, RSUMRESDWN.FACTORY, sizeof(RSUMRESDWH.FACTORY));
		memcpy(RSUMRESDWH.RES_ID, RSUMRESDWN.RES_ID, sizeof(RSUMRESDWN.RES_ID));
		memcpy(RSUMRESDWH.SUB_RES_ID, RSUMRESDWN.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID));
		CDB_select_rsumresdwh(5, &RSUMRESDWH); // ¸¶Áö¸· ·¹ÄÚµå(3->5·Î º¯°æ : 24.03.19)

		if(DB_error_code != DB_SUCCESS)//데이터가 없다면 한번더 찾는다.
		{
			CDB_init_rsumresdwh(&RSUMRESDWH);

			memcpy(RSUMRESDWH.FACTORY, RSUMRESDWN.FACTORY, sizeof(RSUMRESDWH.FACTORY));
			memcpy(RSUMRESDWH.RES_ID, RSUMRESDWN.RES_ID, sizeof(RSUMRESDWN.RES_ID));
			memcpy(RSUMRESDWH.SUB_RES_ID, RSUMRESDWN.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID));
			CDB_select_rsumresdwh(3, &RSUMRESDWH); // ¸¶Áö¸· ·¹ÄÚµå(3->5·Î º¯°æ : 24.03.19)

			if(DB_error_code != DB_SUCCESS)
			{
				continue;
			}
		}

		//µ¥ÀÌÅÍ º¸Á¤ (¸¶Áö¸· ÄÚµå¸¦ ÃÖ´ë°ªÀ¸·Î º¸Á¤ÇÏ¿© ±×·¡ÇÁ ¸ÂÃã)
		CDB_init_rsumresdwn(&RSUMRESDWN_DATA);
		memcpy(RSUMRESDWN_DATA.WORK_DATE, tmp_work_time.work_date, sizeof(RSUMRESDWN_DATA.WORK_DATE));
		RSUMRESDWN_DATA.WORK_SHIFT= c_shift;
		memcpy(RSUMRESDWN_DATA.LINE_ID, RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWN_DATA.WORK_DATE));
		memcpy(RSUMRESDWN_DATA.OPER, RSUMRESDWH.OPER, sizeof(RSUMRESDWN_DATA.OPER));
		memcpy(RSUMRESDWN_DATA.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWN_DATA.RES_ID));
		memcpy(RSUMRESDWN_DATA.SUB_RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWN_DATA.SUB_RES_ID));
		memcpy(RSUMRESDWN_DATA.CURR_CODE, RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWN_DATA.CURR_CODE));

		CDB_select_rsumresdwn(1, &RSUMRESDWN_DATA);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
			if(DB_error_code == DB_NOT_FOUND)
			{
				//Ãß°¡
				RSUMRESDWN_DATA.STATE_SUM = 0;
				CDB_insert_rsumresdwn(&RSUMRESDWN_DATA);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
				else
				{
					DB_commit();		//22.11.30 RSUMRESDWN Å×ÀÌºí lock ¿ìÈ¸ÇÏ±â À§ÇØ
				}

			}
		}
		RSUMRESDWN_DATA.CMF_VAL_1 = RSUMRESDWN_DATA.STATE_SUM;
		RSUMRESDWN_DATA.STATE_SUM = RSUMRESDWN_DATA.STATE_SUM + (int) RSUMRESDWN.CMF_VAL_1;
		RSUMRESDWN_DATA.CMF_VAL_2 = d_max_value;

		CDB_update_rsumresdwn(1, &RSUMRESDWN_DATA);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
			CDB_update_rsumresdwn(1, &RSUMRESDWN_DATA);
		}
		else
		{
			DB_commit();		//22.11.30 RSUMRESDWN Å×ÀÌºí lock ¿ìÈ¸ÇÏ±â À§ÇØ
		}

	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

