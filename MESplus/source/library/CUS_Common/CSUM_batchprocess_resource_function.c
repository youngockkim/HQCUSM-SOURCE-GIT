
/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_BatchProcess_resource_function.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// MTMPRESHIS ±âÁØµ¥ÀÌÅÍ¸¦ ÀÐ¾î¼­  SUMMARY ¹× ÇÊ¿äÇÑ µ¥ÀÌÅÍ Ã³¸® ÁøÇà.

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2019/02/01  HANCHANG       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <MESCore_common.h>
#include "ACTCore_common.h"


int CSUM_BATCHPROCESS_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
CSUM_BatchProcess_Event()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Event(TRSNode *in_node, TRSNode *out_node)
{
	struct MBATPRCDEF_TAG MBATPRCDEF;
	struct MBATPRCSTS_TAG MBATPRCSTS;

	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	char c_job_flag = ' ';
	char s_sys_time[14];
	char s_target_time[14];

	//if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
	//	return MP_TRUE;
	//¿¬°üÀâÀÌ ÁøÇà¾ÈµÇ°Ô Ã³¸®ÇÔ.

	//IS-21-06-038 E10 ¹èÄ¡ ·ÎÁ÷ º¯°æ °³¹ß
	/*
	DBC_init_mbatprcdef(&MBATPRCDEF);
	memcpy(MBATPRCDEF.JOB_PROC_ID, "BAT00023", strlen("BAT00023"));
	DBC_select_mbatprcdef(1, &MBATPRCDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		//
	}
	c_job_flag = MBATPRCDEF.ACTIVATE_FLAG;
	MBATPRCDEF.ACTIVATE_FLAG = 'N';
	DBC_update_mbatprcdef(1, &MBATPRCDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		//
	}
	DB_commit();

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(s_target_time, ' ', sizeof(s_target_time));

	DB_get_systime(s_sys_time);
	DB_get_calc_time(s_target_time, s_sys_time, 1,5); //5ºÐÈÄÀÇ ½Ã°£À» s_target_time ¿¡ ÀúÀå

	DBC_init_mbatprcsts(&MBATPRCSTS);
	memcpy(MBATPRCSTS.JOB_PROC_ID, "BAT00023", strlen("BAT00023"));
	MBATPRCSTS.STATUS_FLAG = 'P';
	while(1)
	{
		if (DBC_select_mbatprcsts_scalar(1, &MBATPRCSTS) < 1)
			break;

		DB_get_systime(s_sys_time);
		
		//5ºÐÀÌ»ó ´ë±â½Ã ´õÀÌ»ó ´ë±â ¾ÈÇÔ.
		if (memcmp(s_sys_time, s_target_time, sizeof(s_sys_time)) > 0)
			break;
	}
	*/

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_BATCHPROCESS_EVENT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_EVENT", out_node);

	if(i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	//IS-21-06-038 E10 ¹èÄ¡ ·ÎÁ÷ º¯°æ °³¹ß
	/*
	//MBATPRCDEF.ACTIVATE_FLAG = c_job_flag; // ÀÌÀü °ªÀÌ N ÀÏ°æ¿ì ½ÇÇàµÇÁö ¾Ê´Â ¹ö±×
	// IS-21-01-053 E10 Shift Job Ã¼Å© BAT00018 / BAT00023 ¹øÀº µ¿½Ã ¼öÇàµÇÁö ¾Êµµ·Ï Ã³¸®Áß NÀ¸·Î Ã³¸® ÈÄ¿¡ Y·Î °­Á¦ ¼³Á¤
	MBATPRCDEF.ACTIVATE_FLAG = 'Y';
	DBC_update_mbatprcdef(1, &MBATPRCDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		//
	}
	DB_commit();
	*/

	//CUS_COM_BATCHPROCESS_STATUS_UPDATE('E', in_node, out_node);

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
int CSUM_BATCHPROCESS_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MTMPRESHIS_TAG MTMPRESHIS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPCALDEF_TAG MWIPCALDEF;

	struct MGCMTBLDAT_TAG MGCMTBLDAT; //IS-21-06-038 E10 ¹èÄ¡ ·ÎÁ÷ º¯°æ °³¹ß

	struct worktime_tag cur_work_time;
	struct worktime_tag old_work_time;
	struct worktime_tag tmp_work_time;

	struct RSUMRESDWH_TAG RSUMRESDWH;
	struct RSUMRESDWH_TAG RSUMRESDWH_CNT;
	
	char cIUDFlag ;
	char s_sys_time[14];
	char s_tmp_time[14];
	int iStep  = 0;
	char c_shift = ' ';
	char c_old_shift = ' ';
	char s_old_end_timem[17];
	char s_new_start_timem[17];

	char c_new_record_flag = 'N';
	char c_new_shiftday_change_flag = 'N';

	int iCalCnt = 0;

	//IS-21-06-038 E10 ¹èÄ¡ ·ÎÁ÷ º¯°æ °³¹ß
	TRSNode* tran_in_node;

    LOG_head("CSUM_BATCHPROCESS_EVENT");
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

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}

	//IS-21-06-038 E10 ¹èÄ¡ ·ÎÁ÷ º¯°æ °³¹ß
	// GCM Read (BATCH_PRC_RES/EXECUTE_USE_YN) : Shift Change Use Info
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "BATCH_PRC_RES", strlen("BATCH_PRC_RES"));
	memcpy(MGCMTBLDAT.KEY_1, "EXECUTE_USE_YN", sizeof("EXECUTE_USE_YN"));

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		// GCM Read (BATCH_PRC_RES/EXECUTE_USE_YN) : Shift Change Use Info
		if (MGCMTBLDAT.DATA_1[0] == 'Y')
		{
			// GCM Read (BATCH_PRC_RES/EXECUTE_TIME) : Function Run Time(Hour)
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMTBLDAT.TABLE_NAME, "BATCH_PRC_RES", strlen("BATCH_PRC_RES"));
			memcpy(MGCMTBLDAT.KEY_1, "EXECUTE_TIME", sizeof("EXECUTE_TIME"));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				memset(s_tmp_time, ' ', sizeof(s_tmp_time));
				memcpy(s_tmp_time,&s_sys_time[8], 2); // 0123 45 67 89(HOUR)
				
				// GCM Read (BATCH_PRC_RES/EXECUTE_TIME) : Function Run Time(Hour)
				if (memcmp(MGCMTBLDAT.DATA_1, s_tmp_time , 2) == 0)
				{
					// GCM Read (BATCH_PRC_RES/EXECUTE_CHECK) : Function Run check(Day)
					DBC_init_mgcmtbldat(&MGCMTBLDAT);
					TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
					memcpy(MGCMTBLDAT.TABLE_NAME, "BATCH_PRC_RES", strlen("BATCH_PRC_RES"));
					memcpy(MGCMTBLDAT.KEY_1, "EXECUTE_CHECK", sizeof("EXECUTE_CHECK"));

					DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
					if(DB_error_code == DB_SUCCESS)
					{
						memset(s_tmp_time, ' ', sizeof(s_tmp_time));
						memcpy(s_tmp_time,s_sys_time, 8);

						// GCM Read (BATCH_PRC_RES/EXECUTE_CHECK) : Function Run check(Day)
						if (memcmp(MGCMTBLDAT.DATA_1, s_tmp_time , 8) != 0)
						{
							tran_in_node = TRS.create_node("TRAN_RESOURCE_SHIFTCHANGE_IN");

							TRS.clone(tran_in_node, in_node);
							if(CSUM_SUMMARY_RESOURCE_SHIFTCHANGE(s_msg_code, tran_in_node, out_node) == MP_FALSE)
							{
								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

								TRS.free_node(tran_in_node);
								return MP_FALSE;
							}

							TRS.free_node(tran_in_node);

							// GCM Update (BATCH_PRC_RES/EXECUTE_CHECK) : Function Run check(Day)
							TRS.copy(MGCMTBLDAT.UPDATE_USER_ID, sizeof(MGCMTBLDAT.UPDATE_USER_ID), in_node, IN_USERID);
							memcpy(MGCMTBLDAT.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

							memcpy(MGCMTBLDAT.DATA_1, s_sys_time, sizeof(s_sys_time));

							CDB_update_mgcmtbldat(1, &MGCMTBLDAT);
							if(DB_error_code != DB_SUCCESS)
							{
								strcpy(s_msg_code, "WIP-0004"); 
								TRS.add_fieldmsg(out_node, "MGCMTBLDAT INSERT", MP_NVST); 
								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY); 
								TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME); 
								TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1); 
								TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2); 
								TRS.add_dberrmsg(out_node, DB_error_msg);

								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								gs_log_type.category = MP_LOG_CATE_SETUP;

								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
								return MP_FALSE; 
							}
						}
					}
				}
			}
		}
	}


	//SUMMARY TEMP TABLE OPEN
	iStep = 101;
	DBC_init_mtmpreshis(&MTMPRESHIS);

	if(TRS.get_char(in_node, "PROCSTEP") != ' ')
		MTMPRESHIS.PROCESS_FLAG = TRS.get_char(in_node, "PROCSTEP"); //MAINT ¿ë
	
	DBC_open_mtmpreshis(iStep, &MTMPRESHIS);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "MTMPRESHIS OPEN", MP_NVST);
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
		DBC_fetch_mtmpreshis(iStep, &MTMPRESHIS);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			DBC_close_mtmpreshis(iStep);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "MTMPRESHIS FETCH", MP_NVST);
			TRS.set_fieldmsg(out_node, "ITEM CODE", MP_STR, sizeof(MTMPRESHIS.LOT_ID), MTMPRESHIS.LOT_ID);				
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			DBC_close_mtmpreshis(iStep);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//PROCESS FLAG (처리중이거나/ 삭제/ MAINT 등인 레코드이면 처리안함.
		if(MTMPRESHIS.PROCESS_FLAG != ' ')
		{
			if (TRS.get_char(in_node, "PROCSTEP") !=  MTMPRESHIS.PROCESS_FLAG)
				continue;
		}

		//0. ¼³ºñ ID GET
		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, MTMPRESHIS.FACTORY, sizeof(MTMPRESHIS.FACTORY));
		memcpy(MRASRESDEF.RES_ID, MTMPRESHIS.RES_ID, sizeof(MTMPRESHIS.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0003");
			TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			DBC_close_mtmpreshis(iStep);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if (MRASRESDEF.RES_CMF_10[0] != 'Y')
		{
			//E10 ´ë»ó¼³ºñ°¡ ¾Æ´Ï¸é Áý°è¾ÈÇÔ.

			//IS-21-06-038 E10 ¹èÄ¡ ·ÎÁ÷ º¯°æ °³¹ß
			DBC_delete_mtmpreshis(1, &MTMPRESHIS);
			DB_commit();

			continue;
		}

		//SUB RES 기준으로 SUMMARY 를 하므로 없는경우는 MAIN 설비넣어줌.
		if (COM_isspace(MTMPRESHIS.NEW_STS_6, sizeof(MTMPRESHIS.NEW_STS_6)) == MP_TRUE)
		{
			memcpy(MTMPRESHIS.NEW_STS_6, MTMPRESHIS.RES_ID, sizeof(MTMPRESHIS.RES_ID));
		}


		//WORK TIME GET.(NEW)
		memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_time(MTMPRESHIS.TRAN_TIME, &cur_work_time);
		c_shift = CCOM_get_work_shift(MTMPRESHIS.TRAN_TIME);
		
		//DELETE  HISTORY 인경우 별도 처리함.
		if(MTMPRESHIS.HIST_DEL_FLAG == 'Y')
		{
			//ÇÊ¿ä½Ã º°µµ ÄÚµùÇÊ¿ä
			DBC_delete_mtmpreshis(1, &MTMPRESHIS);
			DB_commit();
			continue;
		}

		/*********************************************************************/
		//0 .EVENT  별 처리 옵션 
		/*********************************************************************/
		if (memcmp(MTMPRESHIS.EVENT_ID,HQCEL_M1_EVENT_EQ_CHGSTATUS, strlen(HQCEL_M1_EVENT_EQ_CHGSTATUS)) != 0)
		{
			//´Ù¸¥ ÀÌº¥Æ® ÇÊ¿ä½Ã º°µµ·Î ÇÔ¼ö»©¼­ ÇÏ¼Á..
			DBC_delete_mtmpreshis(1, &MTMPRESHIS);
			DB_commit();
			continue;
		}

		c_new_shiftday_change_flag= 'N';
		c_new_record_flag = 'N';

		CDB_init_rsumresdwh(&RSUMRESDWH);

		memcpy(RSUMRESDWH.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
		memcpy(RSUMRESDWH.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
		//memcpy(RSUMRESDWH.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(MRASRESDEF.RES_CMF_1));  // Server Crash
		memcpy(RSUMRESDWH.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(RSUMRESDWH.LINE_ID));  // Server Crash
		memcpy(RSUMRESDWH.OPER, MRASRESDEF.RES_CMF_2, sizeof(RSUMRESDWH.OPER));

		if (COM_isspace(RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER)) == MP_TRUE)
			memcpy(RSUMRESDWH.OPER, "M9999", strlen("M9999"));
		
		memcpy(RSUMRESDWH.TRAN_TIME, MTMPRESHIS.TRAN_TIME, sizeof(RSUMRESDWH.TRAN_TIME));
		memcpy(RSUMRESDWH.TRAN_MSEC, MTMPRESHIS.NEW_STS_5, sizeof(RSUMRESDWH.TRAN_MSEC));
		memcpy(RSUMRESDWH.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
		RSUMRESDWH.WORK_SHIFT = c_shift;
				
		memcpy(RSUMRESDWH.RES_ID, MRASRESDEF.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		memcpy(RSUMRESDWH.SUB_RES_ID, MTMPRESHIS.NEW_STS_6, sizeof(RSUMRESDWH.SUB_RES_ID));
		//현재 설비/서브설비의 마지막 DATA 를 가져옮.
		CDB_select_rsumresdwh_for_update(2, &RSUMRESDWH); // 해당 WORKDATE 의 마지막건수를 가지고 옮..
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				memcpy(RSUMRESDWH.CURR_CODE, MTMPRESHIS.NEW_STS_3, sizeof(RSUMRESDWH.CURR_CODE));
				memcpy(RSUMRESDWH.CURR_ACRO, MTMPRESHIS.NEW_PRI_STS, sizeof(RSUMRESDWH.CURR_ACRO));
				memcpy(RSUMRESDWH.CURR_GROUP, MTMPRESHIS.NEW_STS_4, sizeof(RSUMRESDWH.CURR_GROUP));
				memcpy(RSUMRESDWH.PREV_CODE, MTMPRESHIS.OLD_STS_3, sizeof(RSUMRESDWH.CURR_ACRO));
				memcpy(RSUMRESDWH.ALID, MTMPRESHIS.TRAN_CMF_2, sizeof(RSUMRESDWH.ALID));
				memcpy(RSUMRESDWH.ALCD, MTMPRESHIS.TRAN_CMF_3, sizeof(RSUMRESDWH.ALCD));
				memcpy(RSUMRESDWH.ALTX, MTMPRESHIS.TRAN_CMF_4, sizeof(MTMPRESHIS.TRAN_CMF_4));
				memcpy(RSUMRESDWH.TRAN_TIME, MTMPRESHIS.TRAN_TIME, sizeof(MTMPRESHIS.TRAN_TIME));
				memcpy(RSUMRESDWH.WORK_DATE, cur_work_time.work_date, sizeof(RSUMRESDWH.WORK_DATE));
				RSUMRESDWH.WORK_SHIFT = c_shift;
				memcpy(RSUMRESDWH.CTRL_MODE, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
				memcpy(RSUMRESDWH.CHANGE_MODE_TIME, MRASRESDEF.RES_CMF_18, sizeof(RSUMRESDWH.CHANGE_MODE_TIME));
				memcpy(RSUMRESDWH.OLD_CTRL_MODE, MRASRESDEF.RES_CMF_19, sizeof(RSUMRESDWH.OLD_CTRL_MODE));
				memcpy(RSUMRESDWH.CMF_1, MRASRESDEF.RES_CMF_20, sizeof(RSUMRESDWH.CMF_1));

				//24.02.15 19년 데이터 재 생성 방지
				if(memcmp(RSUMRESDWH.WORK_DATE, "2026", 4) != 0  &&  (memcmp(RSUMRESDWH.WORK_DATE, "2025", 4) != 0))
				{
					continue;
				}
				else
				{
					CDB_insert_rsumresdwh(&RSUMRESDWH);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}



			}
			else
			{
				strcpy(s_msg_code, "RAS-0000");
				TRS.set_fieldmsg(out_node, "RSUMRESDWH LAST DATA SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMRESDWH.RES_ID), RSUMRESDWH.RES_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				DBC_close_mtmpreshis(iStep);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}
		
		
		//OLD WORK TIME GET.(NEW)
		memset(&old_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_time(RSUMRESDWH.TRAN_TIME, &old_work_time);
		c_old_shift = CCOM_get_work_shift(RSUMRESDWH.TRAN_TIME);
		memset(s_old_end_timem, '0', sizeof(s_old_end_timem));
		memset(s_new_start_timem, '0', sizeof(s_new_start_timem));
		//일자가 , SHIFT 가 틀리면
		if ((memcmp(old_work_time.work_date,  cur_work_time.work_date, sizeof(  cur_work_time.work_date)) != 0) ||
			(old_work_time.work_shift != cur_work_time.work_shift))
		{
			//OLD : 이전데이터의 SHIFT 의 마지막 시간으로 UPDATE
			memcpy(s_old_end_timem, old_work_time.work_shift_end_time, 14);

			//NEW : 현재데이터의 SHIFT 시작시간으로 UPDATE
			memcpy(s_new_start_timem, cur_work_time.work_shift_start_time, 14);
			s_new_start_timem[15] = '1';
			c_new_shiftday_change_flag = 'Y';
		}
		else
		{
			//일자 SHIFT 가 같으면 OLD END -> NEW 시작 시간
			memcpy(s_old_end_timem, MTMPRESHIS.NEW_STS_5 , sizeof(s_old_end_timem));
			memcpy(s_new_start_timem, MTMPRESHIS.NEW_STS_5 , sizeof(s_old_end_timem));
			
		}
		
		//1. 마지막 데이터가 현재 데이터와 틀린가 CHECK (CURR_CODE)
		//2. 일자나 틀려지면 새로운 레코드
		//3. SHIFT 가 틀려지면 새로운 레코드
		if ((memcmp(RSUMRESDWH.CURR_CODE, MTMPRESHIS.NEW_STS_3, sizeof(RSUMRESDWH.CURR_CODE)) != 0) ||
			 (memcmp(RSUMRESDWH.WORK_DATE, cur_work_time.work_date, sizeof(RSUMRESDWH.WORK_DATE)) != 0) ||
			  (RSUMRESDWH.WORK_SHIFT != c_shift))
		{
			c_new_record_flag = 'Y';
		}

		// ÀÌÀü ·¹ÄÚµå ½Ã°£ UPDATE
		memcpy(RSUMRESDWH.END_TIME, s_old_end_timem, sizeof(RSUMRESDWH.END_TIME));
		memcpy(RSUMRESDWH.END_MSEC, s_old_end_timem, sizeof(RSUMRESDWH.END_MSEC));  
		CDB_update_rsumresdwh(102, &RSUMRESDWH);	//24.11.15 INDEX 힌드 추가
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		if (memcmp(RSUMRESDWH.END_MSEC, RSUMRESDWH.TRAN_MSEC , sizeof(RSUMRESDWH.TRAN_MSEC)) <= 0)
		{
			CDB_update_rsumresdwh(101, &RSUMRESDWH);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}

		/*****************************************************************/
		//shift change 와 일자가 변경되엇을경우 해당 시간의 데이터를 처리
		//일자 / 혹은 shift 가 바꼈을경우.
		/*****************************************************************/
		if (c_new_shiftday_change_flag =='Y')
		{
			char c_data_1_flag = 'N';
			char c_data_2_flag = 'N';

			//OLD EVENT -> NEW EVENT 일자가 바뀌었을경우 데이터 처리
			DBC_init_mwipcaldef(&MWIPCALDEF);
			memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //해당 칼렌다로 변경필요..
			memcpy(MWIPCALDEF.CREATE_TIME, s_old_end_timem, 8);
			memcpy(MWIPCALDEF.UPDATE_TIME, s_new_start_timem, 8);
			DBC_open_mwipcaldef(101,&MWIPCALDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPCALDEF OPEN", MP_NVST);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			while(1) 
			{
				DBC_fetch_mwipcaldef(101, &MWIPCALDEF);
				if(DB_error_code == DB_NOT_FOUND)
				{
					DBC_close_mwipcaldef(101);
					break;
				}
				else if(DB_error_code != DB_SUCCESS)
				{ 
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPCALDEF FETCH", MP_NVST);
					TRS.add_dberrmsg(out_node,DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					// IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
					// DB OPEN / FETCH CASE CURSOR CLOSE
					DBC_close_mwipcaldef(101);
					DBC_close_mtmpreshis(iStep);

					return MP_FALSE;
				}

				c_data_1_flag = 'N'; //1조 데이터
				c_data_2_flag = 'N'; //2조 데이터Í

				//현재시간 get
				memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
				memset(s_tmp_time, ' ', sizeof(s_tmp_time));
				memcpy(s_tmp_time,s_sys_time, 14);
				CCOM_get_work_time(s_tmp_time, &tmp_work_time);

				//일자의 DATA GET
				CDB_init_rsumresdwh(&RSUMRESDWH_CNT);
				memcpy(RSUMRESDWH_CNT.WORK_DATE, MWIPCALDEF.SYS_DATE, 8);
				memcpy(RSUMRESDWH_CNT.LINE_ID, RSUMRESDWH.LINE_ID,sizeof(RSUMRESDWH.LINE_ID));
				memcpy(RSUMRESDWH_CNT.OPER, RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER));
				memcpy(RSUMRESDWH_CNT.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
				memcpy(RSUMRESDWH_CNT.SUB_RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID));
				//22.03.28 Factory ÄÚµå¸¦ ÁÖÁö ¾Ê¾Æ index¸¦ Å¸Áö ¾ÊÀ½
				memcpy(RSUMRESDWH_CNT.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH.FACTORY));


				CDB_select_rsumresdwh(2, &RSUMRESDWH_CNT) ;
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
				iCalCnt = RSUMRESDWH_CNT.WORK_SHIFT - '0'; // 0 ~9 까지의 숫자

				
				//해당 일자에 SHIFT 별 데이터가 1건도 없을경우
				if (iCalCnt < 1) 
				{
					//만일 현재일자와 같은날이고  현재시간이 2조시간이면 1조까지만 생성
					if (memcmp(tmp_work_time.work_date , MWIPCALDEF.SYS_DATE, 8) == 0)
					{
						if (tmp_work_time.work_shift == 2)
						{
							c_data_1_flag = 'Y'; //1Á¶ µ¥ÀÌÅÍ
							c_data_2_flag = 'N'; //2Á¶ µ¥ÀÌÅÍ
						}
					}
					else
					{
						//해당일자의 데이터가 한개도 없으므로 1~2조 모두 데이터 생성
						c_data_1_flag = 'Y'; //1Á¶ µ¥ÀÌÅÍ
						c_data_2_flag = 'Y'; //2Á¶ µ¥ÀÌÅÍ
					}
				}

				//해당 일자에 SHIFT 1개만 있을경우
				if (iCalCnt == 1) 
				{
					if (memcmp(tmp_work_time.work_date , MWIPCALDEF.SYS_DATE, 8) == 0)
					{
						//만일 현재일자와 같은날이고  시간이 2조시간이면 1조까지만 생성한것이므로 데이터 생성안함
						if (tmp_work_time.work_shift == 2)
						{
							c_data_1_flag = 'N'; //1조 데이터
							c_data_2_flag = 'N';//2조 데이터Í
						}
					}
					else
					{
						//ÇØ´çÀÏÀÚÀÇ shift ½Ã°£À» °¡Á®¿Å
						memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
						memset(s_tmp_time, ' ', sizeof(s_tmp_time));
						memcpy(s_tmp_time,RSUMRESDWH_CNT.TRAN_MSEC , 14);
						CCOM_get_work_time(s_tmp_time, &tmp_work_time);

						if (tmp_work_time.work_shift == 1)
						{
							c_data_1_flag = 'N'; //1Á¶ µ¥ÀÌÅÍ
							c_data_2_flag = 'Y'; //2Á¶ µ¥ÀÌÅÍ
						}
						else
						{
							c_data_1_flag = 'Y'; //1Á¶ µ¥ÀÌÅÍ
							c_data_2_flag = 'N'; //2Á¶ µ¥ÀÌÅÍ
						}
					}
				}

				//해당일자의 shift 시간계산
				memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
				memset(s_tmp_time, ' ', sizeof(s_tmp_time));
				memcpy(s_tmp_time, MWIPCALDEF.SYS_DATE, 8);
				memcpy(s_tmp_time+8, "090000", 6);
				CCOM_get_work_time(s_tmp_time, &tmp_work_time);
				
				//1조 데이터 생성 (1조의 마지막시간이 발생한 데이터의 시작시간 보다 작을경우만)
				if ((c_data_1_flag == 'Y') && 
					(memcmp(tmp_work_time.work_shift_end_time, s_new_start_timem, 14) <= 0))
				{
					memcpy(RSUMRESDWH.WORK_DATE, tmp_work_time.work_date, sizeof(RSUMRESDWH.WORK_DATE));
					memcpy(RSUMRESDWH.TRAN_MSEC, tmp_work_time.work_date_start_time, 14);
					memcpy(RSUMRESDWH.TRAN_MSEC+8, "06000001", 8);
					memcpy(RSUMRESDWH.TRAN_TIME, RSUMRESDWH.TRAN_MSEC,14);
					RSUMRESDWH.WORK_SHIFT = CCOM_get_work_shift(tmp_work_time.work_date_start_time);
					
					memcpy(RSUMRESDWH.END_MSEC, tmp_work_time.work_shift_end_time, 14);
					memcpy(RSUMRESDWH.END_MSEC+14, "00", 2);
					RSUMRESDWH.INPUT_FLAG = c_data_1_flag;
					memcpy(RSUMRESDWH.CTRL_MODE, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
					memcpy(RSUMRESDWH.CHANGE_MODE_TIME, MRASRESDEF.RES_CMF_18, sizeof(RSUMRESDWH.CHANGE_MODE_TIME));
					memcpy(RSUMRESDWH.OLD_CTRL_MODE, MRASRESDEF.RES_CMF_19, sizeof(RSUMRESDWH.OLD_CTRL_MODE));
					memcpy(RSUMRESDWH.CMF_1, MRASRESDEF.RES_CMF_20, sizeof(RSUMRESDWH.CMF_1));
					//24.02.15 19년 데이터 재 생성 방지
					if(memcmp(RSUMRESDWH.WORK_DATE, "2026", 4) != 0  &&  (memcmp(RSUMRESDWH.WORK_DATE, "2025", 4) != 0))
					{
						continue;
					}
					else
					{
						CDB_insert_rsumresdwh(&RSUMRESDWH);
					}
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
					// 시간 UPDATE
					CDB_update_rsumresdwh(100, &RSUMRESDWH);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
					if (memcmp(RSUMRESDWH.END_MSEC, RSUMRESDWH.TRAN_MSEC , sizeof(RSUMRESDWH.TRAN_MSEC)) <= 0)
					{
						CDB_update_rsumresdwh(101, &RSUMRESDWH);
						if(DB_error_code != DB_SUCCESS)
						{
							//DO NOTHING
						}
					}
				}

				//2조 데이터 생성 (2조의 마지막시간이 발생한 데이터의 시작시간 보다 작을경우만)
				if ((c_data_2_flag == 'Y') && 
					(memcmp(tmp_work_time.work_date_end_time, s_new_start_timem, 14) <= 0))
				{
					//2Á¶ µ¥ÀÌÅÍ »ý¼º
					memcpy(RSUMRESDWH.WORK_DATE, tmp_work_time.work_date, sizeof(RSUMRESDWH.WORK_DATE));
					RSUMRESDWH.WORK_SHIFT = MWIPCALDEF.CAL_CMF_2[0];
					memcpy(RSUMRESDWH.TRAN_MSEC, tmp_work_time.work_shift_end_time, 14);
					memcpy(RSUMRESDWH.TRAN_MSEC+14, "00", 2);
					memcpy(RSUMRESDWH.TRAN_TIME, RSUMRESDWH.TRAN_MSEC,14);
					memcpy(RSUMRESDWH.END_MSEC, tmp_work_time.work_date_end_time, 14);
					memcpy(RSUMRESDWH.END_MSEC+14, "00", 2);
					RSUMRESDWH.INPUT_FLAG = c_data_2_flag;
					memcpy(RSUMRESDWH.CTRL_MODE, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
					memcpy(RSUMRESDWH.CHANGE_MODE_TIME, MRASRESDEF.RES_CMF_18, sizeof(RSUMRESDWH.CHANGE_MODE_TIME));
					memcpy(RSUMRESDWH.OLD_CTRL_MODE, MRASRESDEF.RES_CMF_19, sizeof(RSUMRESDWH.OLD_CTRL_MODE));
					memcpy(RSUMRESDWH.CMF_1, MRASRESDEF.RES_CMF_20, sizeof(RSUMRESDWH.CMF_1));
					//24.02.15 19년 데이터 재 생성 방지
					if(memcmp(RSUMRESDWH.WORK_DATE, "2026", 4) != 0  &&  (memcmp(RSUMRESDWH.WORK_DATE, "2025", 4) != 0))
					{
						continue;
					}
					else
					{
						CDB_insert_rsumresdwh(&RSUMRESDWH);
					}
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
					// ½Ã°£ UPDATE
					CDB_update_rsumresdwh(100, &RSUMRESDWH);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
					if (memcmp(RSUMRESDWH.END_MSEC, RSUMRESDWH.TRAN_MSEC , sizeof(RSUMRESDWH.TRAN_MSEC)) <= 0)
					{
						CDB_update_rsumresdwh(101, &RSUMRESDWH);
						if(DB_error_code != DB_SUCCESS)
						{
							//DO NOTHING
						}
					}
				}
			}
		}

		// 신규레코드 INSERT
		if (c_new_record_flag == 'Y')
		{
			if (memcmp(RSUMRESDWH.TRAN_MSEC, s_new_start_timem, sizeof(RSUMRESDWH.TRAN_MSEC)) == 0)
			{
				//동일한 시간에 다른 코드가 올라왓으면 해당 코드로 UPDATE위해 이전코드 지움.
				CDB_delete_rsumresdwh(1, &RSUMRESDWH);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}
			memcpy(RSUMRESDWH.CURR_CODE, MTMPRESHIS.NEW_STS_3, sizeof(RSUMRESDWH.CURR_CODE));
			memcpy(RSUMRESDWH.CURR_ACRO, MTMPRESHIS.NEW_PRI_STS, sizeof(RSUMRESDWH.CURR_ACRO));
			memcpy(RSUMRESDWH.CURR_GROUP, MTMPRESHIS.NEW_STS_4, sizeof(RSUMRESDWH.CURR_GROUP));
			memcpy(RSUMRESDWH.PREV_CODE, MTMPRESHIS.OLD_STS_3, sizeof(RSUMRESDWH.CURR_ACRO));  //  ¿ÀÅ¸
			memcpy(RSUMRESDWH.ALID, MTMPRESHIS.TRAN_CMF_2, sizeof(RSUMRESDWH.ALID));
			memcpy(RSUMRESDWH.ALCD, MTMPRESHIS.TRAN_CMF_3, sizeof(RSUMRESDWH.ALCD));
			memcpy(RSUMRESDWH.ALTX, MTMPRESHIS.TRAN_CMF_4, sizeof(MTMPRESHIS.TRAN_CMF_4));
			memcpy(RSUMRESDWH.TRAN_MSEC, s_new_start_timem, sizeof(RSUMRESDWH.TRAN_MSEC));
			memcpy(RSUMRESDWH.TRAN_TIME, MTMPRESHIS.TRAN_TIME, sizeof(MTMPRESHIS.TRAN_TIME));
			memcpy(RSUMRESDWH.WORK_DATE, cur_work_time.work_date, sizeof(RSUMRESDWH.WORK_DATE));

			RSUMRESDWH.WORK_SHIFT = c_shift;
			if (COM_isspace(RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER)) == MP_TRUE)
				memcpy(RSUMRESDWH.OPER, "M9999", strlen("M9999"));
			
			RSUMRESDWH.STATE_TIME = 0;
			RSUMRESDWH.INPUT_FLAG = c_new_shiftday_change_flag;
			memcpy(RSUMRESDWH.CTRL_MODE, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
			memcpy(RSUMRESDWH.CHANGE_MODE_TIME, MRASRESDEF.RES_CMF_18, sizeof(RSUMRESDWH.CHANGE_MODE_TIME));
			memcpy(RSUMRESDWH.OLD_CTRL_MODE, MRASRESDEF.RES_CMF_19, sizeof(RSUMRESDWH.OLD_CTRL_MODE));
			memcpy(RSUMRESDWH.CMF_1, MRASRESDEF.RES_CMF_20, sizeof(RSUMRESDWH.CMF_1));
			
			//24.02.15 19년 데이터 재 생성 방지
			if(memcmp(RSUMRESDWH.WORK_DATE, "2026", 4) != 0  &&  (memcmp(RSUMRESDWH.WORK_DATE, "2025", 4) != 0))
			{
				continue;
			}
			else
			{
				CDB_insert_rsumresdwh(&RSUMRESDWH);

				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}

			if (c_new_shiftday_change_flag == 'Y')
			{
				// 이전 레코드 시간 UPDATE
				memcpy(RSUMRESDWH.END_TIME, MTMPRESHIS.NEW_STS_5, sizeof(RSUMRESDWH.END_TIME));
				memcpy(RSUMRESDWH.END_MSEC, MTMPRESHIS.NEW_STS_5, sizeof(RSUMRESDWH.END_MSEC));  
				CDB_update_rsumresdwh(100, &RSUMRESDWH);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
				if (memcmp(RSUMRESDWH.END_MSEC, RSUMRESDWH.TRAN_MSEC , sizeof(RSUMRESDWH.TRAN_MSEC)) <= 0)
				{
					CDB_update_rsumresdwh(101, &RSUMRESDWH);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}
			}
		}
		

		// Delete MTMPRESHIS Data
		cIUDFlag = 'D';
		
		if (cIUDFlag == 'D')
		{
			DBC_delete_mtmpreshis(1, &MTMPRESHIS);
		//	CSUM_insert_cbaklothis(&CBAKLOTHIS);
		}
		
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.set_fieldmsg(out_node, "MTMPRESHIS UPDATE", MP_NVST);
				TRS.set_fieldmsg(out_node, "RES ID", MP_STR, sizeof(MTMPRESHIS.RES_ID), MTMPRESHIS.RES_ID);				
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				continue;
			}
		}

		DB_commit();

	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}
