
/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_resource_status_function.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// MTMPRESHIS 기준데이터를 읽어서  SUMMARY 및 필요한 데이터 처리 진행.

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


int CSUM_SUMMARY_RESOURCE_SHIFTCHANGE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
CSUM_BatchProcess_Summary_Resource()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Summary_ShiftChange(TRSNode *in_node, TRSNode *out_node)
{
	struct MBATPRCSTS_TAG MBATPRCSTS;
	struct MBATPRCDEF_TAG MBATPRCDEF;

	char s_msg_code[MP_SIZE_MSG];
	int i_ret;
	char c_job_flag = ' ';

	char s_sys_time[14];
	char s_target_time[14];

	//if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
	//	return MP_TRUE;

	//연관잡이 진행안되게 처리함.
	
	DBC_init_mbatprcdef(&MBATPRCDEF);
	memcpy(MBATPRCDEF.JOB_PROC_ID, "BAT00018", strlen("BAT00018"));
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
	DB_get_calc_time(s_target_time, s_sys_time, 1,5); //5분후의 시간을 s_target_time 에 저장

	DBC_init_mbatprcsts(&MBATPRCSTS);
	memcpy(MBATPRCSTS.JOB_PROC_ID, "BAT00018", strlen("BAT00018"));
	MBATPRCSTS.STATUS_FLAG = 'P';
	while(1)
	{
		if (DBC_select_mbatprcsts_scalar(1, &MBATPRCSTS) < 1)
			break;

		DB_get_systime(s_sys_time);
		
		//5분이상 대기시 더이상 대기 안함.
		if (memcmp(s_sys_time, s_target_time, sizeof(s_sys_time)) > 0)
			break;
	}

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_SUMMARY_RESOURCE_SHIFTCHANGE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_SUMMARY_RESOURCE", out_node);

	if(i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	//MBATPRCDEF.ACTIVATE_FLAG = c_job_flag; // 이전 값이 N 일경우 실행되지 않는 버그
	// IS-21-01-053 E10 Shift Job 체크 BAT00018 / BAT00023 번은 동시 수행되지 않도록 처리중 N으로 처리 후에 Y로 강제 설정
	MBATPRCDEF.ACTIVATE_FLAG = 'Y';
	DBC_update_mbatprcdef(1, &MBATPRCDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		//
	}
	DB_commit();

	//CUS_COM_BATCHPROCESS_STATUS_UPDATE('E', in_node, out_node);

	return MP_TRUE;
}


/*******************************************************************************
CSUM_SUMMARY_RESOURCE_SHIFTCHANGE()
- Main sub function of "CSUM_BatchProcess_Transaction" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_RESOURCE_SHIFTCHANGE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MRASRESDEF_TAG MRASRESDEF;
	struct RSUMRESDWH_TAG RSUMRESDWH;
	struct RSUMRESDWH_TAG RSUMRESDWH_LAST;
	

	char s_sys_time[14];
	char s_system_t[14];
	char s_tmp_time[14];
	char s_chk_time[14];
	char s_tmp_endtime_msec[16];
	int i_step  = 0;

	char s_system_workdate[8];
	int i_system_workshift;

	char c_process_flag = ' ';
	struct worktime_tag tmp_work_time;
	char c_shift_1 = ' ';
	char c_shift_2 = ' ';

	char c_skip_flag = 'N';

    LOG_head("CSUM_BATCHPROCESS_SUMMARY_RESOURCE");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_system_workdate, ' ', sizeof(s_system_workdate));
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
	memset(s_system_t, ' ', sizeof(s_system_t));
	memcpy(s_system_t, s_sys_time, sizeof(s_system_t));

	memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
	CCOM_get_work_time(s_sys_time, &tmp_work_time);
	memcpy(s_system_workdate, tmp_work_time.work_date, 8);
	i_system_workshift = tmp_work_time.work_shift;

	if(TRS.get_char(in_node, "PROCSTEP") != ' ')
	{
		c_process_flag = TRS.get_char(in_node, "PROCSTEP"); //MAINT 용
		TRS.copy(s_sys_time , 14, in_node,"BACK_TIME");
	}

	// SHIFT TIME GET
	memcpy(s_chk_time, s_sys_time, sizeof(s_chk_time));
	memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
	//당일
	memset(s_tmp_time, ' ', sizeof(s_tmp_time));
	memcpy(s_tmp_time, s_sys_time , 14);
	CCOM_get_work_time(s_tmp_time, &tmp_work_time);
	if (tmp_work_time.work_shift == 1)
	{
		//전일
		memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
		memset(s_tmp_time, ' ', sizeof(s_tmp_time));
		DB_get_calc_time(s_tmp_time, s_sys_time, 3, -1);
		memcpy(s_sys_time, s_tmp_time, sizeof(s_sys_time));
		CCOM_get_work_time(s_tmp_time, &tmp_work_time);
		memcpy(s_chk_time, s_system_t, sizeof(s_chk_time));
	}
	
	//0. 입력 일자 데이터중 12시간의 값이 없는것 ( 마지막 트랜잭션이 06까지 안온것 )
	i_step = 4;
	CDB_init_rsumresdwh(&RSUMRESDWH);
	memcpy(RSUMRESDWH.WORK_DATE, s_sys_time, 8);

	CDB_open_rsumresdwh(i_step, &RSUMRESDWH); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "RAS-0004"); 
		TRS.add_fieldmsg(out_node, "RSUMRESDWH OPEN", MP_NVST); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		CDB_fetch_rsumresdwh(i_step, &RSUMRESDWH); 
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_close_rsumresdwh(i_step); 
			break;
		}
		
		//RESOURCE SELECT
		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH.FACTORY));
		memcpy(MRASRESDEF.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		if (MRASRESDEF.RES_CMF_10[0] != 'Y')
		{
			//E10 대상설비가 아니면 집계안함.
			continue;
		}

		//부족한 시간대의 SHIFT TIME GET
		memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
		memset(s_tmp_time, ' ', sizeof(s_tmp_time));
		memcpy(s_tmp_time, RSUMRESDWH.TRAN_MSEC, 14);
		CCOM_get_work_time(s_tmp_time, &tmp_work_time);

		if (memcmp(s_chk_time, tmp_work_time.work_shift_end_time, sizeof(s_chk_time)) < 0)
		{
			//미래는 제외
			continue;
		}
		//현재 시간-SHIFT 이면 제외함
		if((memcmp(s_system_workdate, RSUMRESDWH.WORK_DATE, 8) == 0) && (i_system_workshift == tmp_work_time.work_shift))
		{
			//CONTINUE;
		}


		//RSUMRESDWH, 마지막 레코드 가지고옮.
		CDB_init_rsumresdwh(&RSUMRESDWH_LAST);

		memcpy(RSUMRESDWH_LAST.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH_LAST.FACTORY));
		memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
		memcpy(RSUMRESDWH_LAST.LINE_ID, RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWH_LAST.LINE_ID));
		memcpy(RSUMRESDWH_LAST.OPER, RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER));

		if (COM_isspace(RSUMRESDWH_LAST.OPER, sizeof(RSUMRESDWH_LAST.OPER)) == MP_TRUE)
			memcpy(RSUMRESDWH_LAST.OPER, "M9999", strlen("M9999"));
		
		memcpy(RSUMRESDWH_LAST.TRAN_TIME, tmp_work_time.work_shift_end_time, sizeof(s_sys_time));
		memset(RSUMRESDWH_LAST.TRAN_MSEC, '0', sizeof(RSUMRESDWH_LAST.TRAN_MSEC));
		memcpy(RSUMRESDWH_LAST.TRAN_MSEC, tmp_work_time.work_shift_end_time, sizeof(tmp_work_time.work_shift_end_time));
		memcpy(RSUMRESDWH_LAST.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH_LAST.FACTORY));
		RSUMRESDWH_LAST.WORK_SHIFT = RSUMRESDWH.WORK_SHIFT;
				
		memcpy(RSUMRESDWH_LAST.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		memcpy(RSUMRESDWH_LAST.SUB_RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH_LAST.SUB_RES_ID));
		//입력된 시간(TRAN_MSEC) 보다 작은것중 설비/서브설비의 마지막 DATA 를 가져옮.
		CDB_select_rsumresdwh_for_update(2, &RSUMRESDWH_LAST); // 해당 WORKDATE 의 마지막건수를 가지고 옮..
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		if (memcmp(RSUMRESDWH_LAST.END_MSEC, tmp_work_time.work_shift_end_time, sizeof(tmp_work_time.work_shift_end_time)) > 0)
		{
			//이벤트 발생한 케이스 이므로 제외
			continue;
		}

		
		// 이전 레코드 시간 UPDATE
		CDB_update_rsumresdwh(100, &RSUMRESDWH_LAST);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		if (memcmp(RSUMRESDWH_LAST.END_MSEC, RSUMRESDWH_LAST.TRAN_MSEC , sizeof(RSUMRESDWH_LAST.TRAN_MSEC)) <= 0)
		{
			CDB_update_rsumresdwh(101, &RSUMRESDWH_LAST);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}

		//시간값이 0이면 지우고 처리.
		if (memcmp(RSUMRESDWH_LAST.TRAN_MSEC, RSUMRESDWH_LAST.END_MSEC, sizeof(RSUMRESDWH_LAST.TRAN_MSEC)) == 0)
		{
			//동일한 시간에 다른 코드가 올라왓으면 해당 코드로 UPDATE위해 이전코드 지움.
			CDB_delete_rsumresdwh(1, &RSUMRESDWH_LAST);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}

		//마지막시간 ~ SHIFT END TIME INSERT
		memcpy(RSUMRESDWH_LAST.TRAN_MSEC, RSUMRESDWH_LAST.END_MSEC, sizeof(RSUMRESDWH_LAST.END_MSEC));
		memcpy(RSUMRESDWH_LAST.TRAN_TIME, RSUMRESDWH_LAST.TRAN_MSEC, sizeof(RSUMRESDWH_LAST.TRAN_TIME));
		RSUMRESDWH_LAST.STATE_TIME = 0;
		RSUMRESDWH_LAST.INPUT_FLAG = 'Y';
		memcpy(RSUMRESDWH_LAST.CTRL_MODE, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
		memcpy(RSUMRESDWH_LAST.CHANGE_MODE_TIME, MRASRESDEF.RES_CMF_18, sizeof(RSUMRESDWH_LAST.CHANGE_MODE_TIME));
		memcpy(RSUMRESDWH_LAST.OLD_CTRL_MODE, MRASRESDEF.RES_CMF_19, sizeof(RSUMRESDWH_LAST.OLD_CTRL_MODE));
		memcpy(RSUMRESDWH_LAST.CMF_1, MRASRESDEF.RES_CMF_20, sizeof(RSUMRESDWH_LAST.CMF_1));
		CDB_insert_rsumresdwh(&RSUMRESDWH_LAST);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		// 코드 시간 UPDATE
		memcpy(RSUMRESDWH_LAST.END_TIME, tmp_work_time.work_shift_end_time, sizeof(RSUMRESDWH_LAST.END_TIME));
		memset(RSUMRESDWH_LAST.END_MSEC, '0', sizeof(RSUMRESDWH_LAST.END_MSEC));
		memcpy(RSUMRESDWH_LAST.END_MSEC, tmp_work_time.work_shift_end_time, sizeof(tmp_work_time.work_shift_end_time));  
		CDB_update_rsumresdwh(100, &RSUMRESDWH_LAST);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		if (memcmp(RSUMRESDWH_LAST.END_MSEC, RSUMRESDWH_LAST.TRAN_MSEC , sizeof(RSUMRESDWH_LAST.TRAN_MSEC)) <= 0)
		{
			CDB_update_rsumresdwh(101, &RSUMRESDWH);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
		DB_commit(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
	}

	// SHIFT TIME GET
	memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
	memset(s_tmp_time, ' ', sizeof(s_tmp_time));
	memcpy(s_tmp_time, s_sys_time , 14);
	CCOM_get_work_time(s_tmp_time, &tmp_work_time);

	//0.1 선택 데이터중 값이 전혀업는것
	i_step = 5;
	CDB_init_rsumresdwh(&RSUMRESDWH);
	memcpy(RSUMRESDWH.WORK_DATE, s_sys_time, 8);
	memcpy(RSUMRESDWH.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	CDB_open_rsumresdwh(i_step, &RSUMRESDWH); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "RAS-0004"); 
		TRS.add_fieldmsg(out_node, "RSUMRESDWH OPEN", MP_NVST); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		CDB_fetch_rsumresdwh(i_step, &RSUMRESDWH); 
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_close_rsumresdwh(i_step); 
			break;
		}
		
		//RESOURCE SELECT
		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH.FACTORY));
		memcpy(MRASRESDEF.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		if (MRASRESDEF.RES_CMF_10[0] != 'Y')
		{
			//E10 대상설비가 아니면 집계안함.
			continue;
		}
		
		c_shift_1 = CCOM_get_work_shift(tmp_work_time.work_date_start_time);
		memset(s_tmp_time, ' ', sizeof(s_tmp_time));
		memcpy(s_tmp_time, tmp_work_time.work_date_start_time , 14);
		memcpy(s_tmp_time+8, "200000", 6); //2shift (제대로 계산이 아되어 18시로 계산)
		c_shift_2 = CCOM_get_work_shift(s_tmp_time);

		
		//1조(SHIFT DATA 1이 있는지 CHECK) - 1조인지 , 2조인지 CHECK!
		CDB_init_rsumresdwh(&RSUMRESDWH_LAST);

		memcpy(RSUMRESDWH_LAST.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH_LAST.FACTORY));
		memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
		memcpy(RSUMRESDWH_LAST.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(RSUMRESDWH_LAST.LINE_ID));
		memcpy(RSUMRESDWH_LAST.OPER, MRASRESDEF.RES_CMF_2, sizeof(RSUMRESDWH.OPER));

		if (COM_isspace(RSUMRESDWH_LAST.OPER, sizeof(RSUMRESDWH_LAST.OPER)) == MP_TRUE)
			memcpy(RSUMRESDWH_LAST.OPER, "M9999", strlen("M9999"));
		
		memcpy(RSUMRESDWH_LAST.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		memcpy(RSUMRESDWH_LAST.SUB_RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH_LAST.SUB_RES_ID));

		RSUMRESDWH_LAST.WORK_SHIFT = c_shift_1;

		c_skip_flag = 'N';
		if((memcmp(s_system_workdate, RSUMRESDWH_LAST.WORK_DATE, 8) == 0) && (i_system_workshift == 1))
		{
			c_skip_flag = 'Y'; //현재일의 같은SHIFT 이면 제외
		}
		
		
		//현재 시간-SHIFT 이면 제외함
		if((CDB_select_rsumresdwh_scalar(3, &RSUMRESDWH_LAST) < 1)  && (c_skip_flag == 'N'))
		{
			memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
			memcpy(RSUMRESDWH_LAST.TRAN_TIME, tmp_work_time.work_date_start_time, sizeof(s_sys_time));
			memcpy(RSUMRESDWH_LAST.TRAN_TIME+8, "180000", 6);
			memset(RSUMRESDWH_LAST.TRAN_MSEC, '0', sizeof(RSUMRESDWH_LAST.TRAN_MSEC));
			memcpy(RSUMRESDWH_LAST.TRAN_MSEC, tmp_work_time.work_date_start_time, sizeof(tmp_work_time.work_date_start_time));
			memcpy(RSUMRESDWH_LAST.TRAN_MSEC+13, "001", 3);
			
			memset(RSUMRESDWH_LAST.END_MSEC, '0', sizeof(RSUMRESDWH_LAST.END_MSEC));
			memcpy(RSUMRESDWH_LAST.END_MSEC, RSUMRESDWH_LAST.TRAN_TIME, sizeof(RSUMRESDWH_LAST.TRAN_TIME));
			RSUMRESDWH.STATE_TIME = 0;
			RSUMRESDWH_LAST.WORK_SHIFT = c_shift_1;

			memset(s_tmp_endtime_msec, ' ' , sizeof(s_tmp_endtime_msec));
			memcpy(s_tmp_endtime_msec, RSUMRESDWH_LAST.END_MSEC, sizeof(s_tmp_endtime_msec));

			if (memcmp(s_chk_time,s_tmp_endtime_msec, sizeof(s_chk_time)) > 0)
			{
				//입력된 시간(TRAN_MSEC) 보다 작은것중 설비/서브설비의 마지막 DATA 를 가져옮.
				CDB_select_rsumresdwh_for_update(2, &RSUMRESDWH_LAST); // 해당 WORKDATE 의 마지막건수를 가지고 옮..
				if((DB_error_code == DB_SUCCESS) &&
					(memcmp(RSUMRESDWH_LAST.END_MSEC, s_tmp_endtime_msec, sizeof(tmp_work_time.work_shift_end_time)) < 0))
				{
					memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
					memcpy(RSUMRESDWH_LAST.TRAN_TIME, tmp_work_time.work_date_start_time, sizeof(s_sys_time));
					memcpy(RSUMRESDWH_LAST.TRAN_TIME+8, "180000", 6);
					memset(RSUMRESDWH_LAST.TRAN_MSEC, '0', sizeof(RSUMRESDWH_LAST.TRAN_MSEC));
					memcpy(RSUMRESDWH_LAST.TRAN_MSEC, tmp_work_time.work_date_start_time, sizeof(tmp_work_time.work_date_start_time));
					memcpy(RSUMRESDWH_LAST.TRAN_MSEC+13, "001", 3);
				
					memset(RSUMRESDWH_LAST.END_MSEC, '0', sizeof(RSUMRESDWH_LAST.END_MSEC));
					memcpy(RSUMRESDWH_LAST.END_MSEC, RSUMRESDWH_LAST.TRAN_TIME, sizeof(RSUMRESDWH_LAST.TRAN_TIME));
					RSUMRESDWH_LAST.STATE_TIME = 0;
					RSUMRESDWH_LAST.WORK_SHIFT = c_shift_1;
					memcpy(RSUMRESDWH_LAST.TRAN_TIME, RSUMRESDWH_LAST.TRAN_MSEC, sizeof(RSUMRESDWH_LAST.TRAN_TIME));
					RSUMRESDWH_LAST.INPUT_FLAG = 'Y';
					memcpy(RSUMRESDWH_LAST.CTRL_MODE, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
					memcpy(RSUMRESDWH_LAST.CHANGE_MODE_TIME, MRASRESDEF.RES_CMF_18, sizeof(RSUMRESDWH_LAST.CHANGE_MODE_TIME));
					memcpy(RSUMRESDWH_LAST.OLD_CTRL_MODE, MRASRESDEF.RES_CMF_19, sizeof(RSUMRESDWH_LAST.OLD_CTRL_MODE));
					memcpy(RSUMRESDWH_LAST.CMF_1, MRASRESDEF.RES_CMF_20, sizeof(RSUMRESDWH_LAST.CMF_1));
					CDB_insert_rsumresdwh(&RSUMRESDWH_LAST);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}

					// 이전 레코드 시간 UPDATE
					CDB_update_rsumresdwh(100, &RSUMRESDWH_LAST);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}
			}
			
		}

		c_skip_flag = 'N';
		if((memcmp(s_system_workdate, RSUMRESDWH_LAST.WORK_DATE, 8) == 0) && (i_system_workshift == 2))
		{
			c_skip_flag = 'Y'; //현재일의 같은SHIFT 이면 제외
		}

		//2조 데이터가 있는지 CHECK
		memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
		RSUMRESDWH_LAST.WORK_SHIFT = c_shift_2;
		if ((CDB_select_rsumresdwh_scalar(3, &RSUMRESDWH_LAST) < 1) && (c_skip_flag == 'N'))
		{
			memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
			memcpy(RSUMRESDWH_LAST.TRAN_TIME, tmp_work_time.work_date_start_time, sizeof(s_sys_time));
			memcpy(RSUMRESDWH_LAST.TRAN_TIME+8, "180000", 6);
			memset(RSUMRESDWH_LAST.END_MSEC, '0', sizeof(RSUMRESDWH_LAST.END_MSEC));
			memcpy(RSUMRESDWH_LAST.END_MSEC, tmp_work_time.work_date_end_time, sizeof(tmp_work_time.work_date_end_time));
			memcpy(RSUMRESDWH_LAST.TRAN_MSEC, RSUMRESDWH_LAST.END_MSEC, sizeof(RSUMRESDWH_LAST.END_MSEC));
			
			RSUMRESDWH.STATE_TIME = 0;

			memset(s_tmp_endtime_msec, ' ' , sizeof(s_tmp_endtime_msec));
			memcpy(s_tmp_endtime_msec, RSUMRESDWH_LAST.END_MSEC, sizeof(s_tmp_endtime_msec));

			if (memcmp(s_chk_time,s_tmp_endtime_msec, sizeof(s_chk_time)) > 0)
			{
				//입력된 시간(TRAN_MSEC) 보다 작은것중 설비/서브설비의 마지막 DATA 를 가져옮.
				CDB_select_rsumresdwh_for_update(2, &RSUMRESDWH_LAST); // 해당 WORKDATE 의 마지막건수를 가지고 옮..
				if((DB_error_code == DB_SUCCESS) &&
					(memcmp(RSUMRESDWH_LAST.END_MSEC, s_tmp_endtime_msec, sizeof(tmp_work_time.work_shift_end_time)) < 0))
				{
					memcpy(RSUMRESDWH_LAST.TRAN_TIME, tmp_work_time.work_date_start_time, sizeof(s_sys_time));
					memcpy(RSUMRESDWH_LAST.TRAN_TIME+8, "180000", 6);
					memset(RSUMRESDWH_LAST.TRAN_MSEC, '0', sizeof(RSUMRESDWH_LAST.TRAN_MSEC));
					RSUMRESDWH_LAST.TRAN_MSEC[15] ='1';
					memcpy(RSUMRESDWH_LAST.TRAN_MSEC, RSUMRESDWH_LAST.TRAN_TIME, sizeof(RSUMRESDWH_LAST.TRAN_TIME));
					memset(RSUMRESDWH_LAST.END_MSEC, '0', sizeof(RSUMRESDWH_LAST.END_MSEC));
					memcpy(RSUMRESDWH_LAST.END_MSEC, tmp_work_time.work_date_end_time, sizeof(tmp_work_time.work_date_end_time));
					RSUMRESDWH_LAST.STATE_TIME = 0;
					RSUMRESDWH_LAST.WORK_SHIFT = c_shift_2;
					memcpy(RSUMRESDWH_LAST.TRAN_TIME, RSUMRESDWH_LAST.TRAN_MSEC, sizeof(RSUMRESDWH_LAST.TRAN_TIME));
					RSUMRESDWH_LAST.INPUT_FLAG = 'Y';
					memcpy(RSUMRESDWH_LAST.CTRL_MODE, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
					memcpy(RSUMRESDWH_LAST.CHANGE_MODE_TIME, MRASRESDEF.RES_CMF_18, sizeof(RSUMRESDWH_LAST.CHANGE_MODE_TIME));
					memcpy(RSUMRESDWH_LAST.OLD_CTRL_MODE, MRASRESDEF.RES_CMF_19, sizeof(RSUMRESDWH_LAST.OLD_CTRL_MODE));
					memcpy(RSUMRESDWH_LAST.CMF_1, MRASRESDEF.RES_CMF_20, sizeof(RSUMRESDWH_LAST.CMF_1));
					CDB_insert_rsumresdwh(&RSUMRESDWH_LAST);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}

					// 이전 레코드 시간 UPDATE
					CDB_update_rsumresdwh(100, &RSUMRESDWH_LAST);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}
				
			}
			
		}


		DB_commit(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
	}

	

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}




/*******************************************************************************
CSUM_SUMMARY_RESOURCE_SHIFTCHANGE_AUTO()
- Main sub function of "CSUM_BatchProcess_Transaction" function
- OLD (사용안함 , 두개로 나누어 각각 수행하도록 변경)
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_SUMMARY_RESOURCE_SHIFTCHANGE_AUTO(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MRASRESDEF_TAG MRASRESDEF;
	struct RSUMRESDWN_TAG RSUMRESDWN;
	struct RSUMRESDWH_TAG RSUMRESDWH;
	struct RSUMRESDWH_TAG RSUMRESDWH_LAST;
	struct MTMPRESHIS_TAG MTMPRESHIS;

	char s_sys_time[14];
	int i_step  = 0;

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
		c_process_flag = TRS.get_char(in_node, "PROCSTEP"); //MAINT 용
		TRS.copy(s_sys_time , 14, in_node,"BACK_TIME");
	}

	//0. 이전 일자 까지의 데이터중 12시간의 값이 없는것 ( 마지막 트랜잭션이 06까지 안온것 )
	i_step = 2;
	CDB_init_rsumresdwh(&RSUMRESDWH);
	memcpy(RSUMRESDWH.WORK_DATE, s_sys_time, 8);

	CDB_open_rsumresdwh(i_step, &RSUMRESDWH); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "RAS-0004"); 
		TRS.add_fieldmsg(out_node, "RSUMRESDWH OPEN", MP_NVST); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		CDB_fetch_rsumresdwh(i_step, &RSUMRESDWH); 
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_close_rsumresdwh(i_step); 
			break;
		}
		
		//현재시간 이후 설비의 이벤트가 발생한것이 없으면 현재시간 기준 이전이벤트 테이터를 MTMPRESHIS 에 넣어 SUMMARY
		//에서 처리함.

		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH.FACTORY));
		memcpy(MRASRESDEF.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		DBC_select_mrasresdef_for_update(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		if (MRASRESDEF.RES_CMF_10[0] != 'Y')
		{
			//E10 대상설비가 아니면 집계안함.
			continue;
		}

		//RSUMRESDWH, 마지막 레코드 가지고옮.
		CDB_init_rsumresdwh(&RSUMRESDWH_LAST);

		memcpy(RSUMRESDWH_LAST.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH_LAST.FACTORY));
		memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
		memcpy(RSUMRESDWH_LAST.LINE_ID, RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWH_LAST.LINE_ID));
		memcpy(RSUMRESDWH_LAST.OPER, RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER));

		if (COM_isspace(RSUMRESDWH_LAST.OPER, sizeof(RSUMRESDWH_LAST.OPER)) == MP_TRUE)
			memcpy(RSUMRESDWH_LAST.OPER, "M9999", strlen("M9999"));
		
		memcpy(RSUMRESDWH_LAST.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		memcpy(RSUMRESDWH_LAST.TRAN_MSEC, RSUMRESDWH.TRAN_MSEC, sizeof(RSUMRESDWH.TRAN_MSEC));
		memcpy(RSUMRESDWH_LAST.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH_LAST.FACTORY));
		RSUMRESDWH_LAST.WORK_SHIFT = RSUMRESDWH.WORK_SHIFT;
				
		memcpy(RSUMRESDWH_LAST.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		memcpy(RSUMRESDWH_LAST.SUB_RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH_LAST.SUB_RES_ID));
		//현재 설비/서브설비의 마지막 DATA 를 가져옮.
		CDB_select_rsumresdwh_for_update(2, &RSUMRESDWH_LAST); // 해당 WORKDATE 의 마지막건수를 가지고 옮..
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		//MTMPRESHIS 에 현재데이터로 INSERT 함. : 자동으로 RSUMRESDWH 에 쌓임.
		if (memcmp(MRASRESDEF.LAST_EVENT_TIME, RSUMRESDWH_LAST.END_MSEC, sizeof(MRASRESDEF.LAST_EVENT_TIME)) > 0)
		{
			//마지막 SUMMARY 시간이후에 설비 EVENT시간이 있다면 자동으로 계산되었으므로 SKIP
			//DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			//continue;
		}

		DBC_init_mtmpreshis(&MTMPRESHIS);

        MTMPRESHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmpreshis_scalar(2, &MTMPRESHIS);

        memcpy(MTMPRESHIS.FACTORY, RSUMRESDWH_LAST.FACTORY, sizeof(MTMPRESHIS.FACTORY));
        MTMPRESHIS.MAIN_SUB_FLAG = 'M';
        memcpy(MTMPRESHIS.RES_ID, RSUMRESDWH_LAST.RES_ID, sizeof(MTMPRESHIS.RES_ID));
		memcpy(MTMPRESHIS.NEW_STS_6, RSUMRESDWH_LAST.SUB_RES_ID, sizeof(RSUMRESDWH_LAST.SUB_RES_ID));

        MTMPRESHIS.HIST_SEQ =  MRASRESDEF.LAST_ACTIVE_HIST_SEQ ;
        memcpy(MTMPRESHIS.EVENT_ID, HQCEL_M1_EVENT_EQ_CHGSTATUS, strlen(HQCEL_M1_EVENT_EQ_CHGSTATUS));
        memcpy(MTMPRESHIS.TRAN_TIME, s_sys_time, sizeof(MTMPRESHIS.TRAN_TIME));
        memcpy(MTMPRESHIS.SYS_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
        memcpy(MTMPRESHIS.OLD_EVENT_ID, HQCEL_M1_EVENT_EQ_CHGSTATUS, strlen(HQCEL_M1_EVENT_EQ_CHGSTATUS));
		

		
		memcpy(MTMPRESHIS.OLD_PRI_STS, RSUMRESDWH.CURR_ACRO, sizeof(RSUMRESDWH.CURR_ACRO));
        memcpy(MTMPRESHIS.OLD_STS_3, RSUMRESDWH.CURR_CODE, sizeof( RSUMRESDWH.CURR_CODE));
		memcpy(MTMPRESHIS.OLD_STS_4, RSUMRESDWH.CURR_GROUP, sizeof( RSUMRESDWH.CURR_GROUP));
		memcpy(MTMPRESHIS.OLD_STS_5, s_sys_time, sizeof(s_sys_time));
		memcpy(MTMPRESHIS.OLD_STS_5+14, "00", 2);

		memcpy(MTMPRESHIS.NEW_PRI_STS, RSUMRESDWH.CURR_ACRO, sizeof(RSUMRESDWH.CURR_ACRO));
        memcpy(MTMPRESHIS.NEW_STS_3, RSUMRESDWH.CURR_CODE, sizeof( RSUMRESDWH.CURR_CODE));
		memcpy(MTMPRESHIS.NEW_STS_4, RSUMRESDWH.CURR_GROUP, sizeof( RSUMRESDWH.CURR_GROUP));
		memcpy(MTMPRESHIS.NEW_STS_5, s_sys_time, sizeof(s_sys_time));
		memcpy(MTMPRESHIS.NEW_STS_5+14, "00", 2);
		

		memcpy(MTMPRESHIS.TRAN_CMF_2, RSUMRESDWH.ALID, sizeof( RSUMRESDWH.ALID));
		memcpy(MTMPRESHIS.TRAN_CMF_3, RSUMRESDWH.ALCD, sizeof( RSUMRESDWH.ALCD));
		//memcpy(MTMPRESHIS.TRAN_CMF_4, RSUMRESDWH.ALTX, sizeof( RSUMRESDWH.ALTX)); // Server Crash 190925
		memcpy(MTMPRESHIS.TRAN_CMF_4, RSUMRESDWH.ALTX, sizeof( MTMPRESHIS.TRAN_CMF_4)); 

		MTMPRESHIS.PROCESS_FLAG = c_process_flag;
       
        DBC_insert_mtmpreshis(&MTMPRESHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		DB_commit(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
	}


	//0.1 이전 일자 까지의 데이터중 값이 전혀업는것
	i_step = 3;
	CDB_init_rsumresdwh(&RSUMRESDWH);
	memcpy(RSUMRESDWH.WORK_DATE, s_sys_time, 8);
	memcpy(RSUMRESDWH.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	CDB_open_rsumresdwh(i_step, &RSUMRESDWH); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "RAS-0004"); 
		TRS.add_fieldmsg(out_node, "RSUMRESDWH OPEN", MP_NVST); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		CDB_fetch_rsumresdwh(i_step, &RSUMRESDWH); 
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_close_rsumresdwh(i_step); 
			break;
		}
		
		//현재시간 이후 설비의 이벤트가 발생한것이 없으면 현재시간 기준 이전이벤트 테이터를 MTMPRESHIS 에 넣어 SUMMARY
		//에서 처리함.

		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH.FACTORY));
		memcpy(MRASRESDEF.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		DBC_select_mrasresdef_for_update(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		//RSUMRESDWH, 마지막 레코드 가지고옮.
		CDB_init_rsumresdwh(&RSUMRESDWH_LAST);

		memcpy(RSUMRESDWH_LAST.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH_LAST.FACTORY));
		memcpy(RSUMRESDWH_LAST.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMRESDWH_LAST.WORK_DATE));
		memcpy(RSUMRESDWH_LAST.LINE_ID, RSUMRESDWH.LINE_ID, sizeof(RSUMRESDWH_LAST.LINE_ID));
		memcpy(RSUMRESDWH_LAST.OPER, RSUMRESDWH.OPER, sizeof(RSUMRESDWH.OPER));

		if (COM_isspace(RSUMRESDWH_LAST.OPER, sizeof(RSUMRESDWH_LAST.OPER)) == MP_TRUE)
			memcpy(RSUMRESDWH_LAST.OPER, "M9999", strlen("M9999"));
		
		memcpy(RSUMRESDWH_LAST.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		memcpy(RSUMRESDWH_LAST.TRAN_MSEC, RSUMRESDWH.TRAN_MSEC, sizeof(RSUMRESDWH.TRAN_MSEC));
		memcpy(RSUMRESDWH_LAST.FACTORY, RSUMRESDWH.FACTORY, sizeof(RSUMRESDWH_LAST.FACTORY));
		RSUMRESDWH_LAST.WORK_SHIFT = RSUMRESDWH.WORK_SHIFT;
				
		memcpy(RSUMRESDWH_LAST.RES_ID, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
		memcpy(RSUMRESDWH_LAST.SUB_RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH_LAST.SUB_RES_ID));
		//현재 설비/서브설비의 마지막 DATA 를 가져옮.
		CDB_select_rsumresdwh_for_update(2, &RSUMRESDWH); // 해당 WORKDATE 의 마지막건수를 가지고 옮..
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		//MTMPRESHIS 에 현재데이터로 INSERT 함. : 자동으로 RSUMRESDWH 에 쌓임.
		if (memcmp(MRASRESDEF.LAST_EVENT_TIME, RSUMRESDWH.END_MSEC, sizeof(MRASRESDEF.LAST_EVENT_TIME)) > 0)
		{
			//마지막 SUMMARY 시간이후에 설비 EVENT시간이 있다면 자동으로 계산되었으므로 SKIP
			//DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			//continue;
		}

		DBC_init_mtmpreshis(&MTMPRESHIS);

        MTMPRESHIS.TABLE_UPDATE_SEQ = (int)DBC_select_mtmpreshis_scalar(2, &MTMPRESHIS);

        memcpy(MTMPRESHIS.FACTORY, RSUMRESDWH_LAST.FACTORY, sizeof(MTMPRESHIS.FACTORY));
        MTMPRESHIS.MAIN_SUB_FLAG = 'M';
        memcpy(MTMPRESHIS.RES_ID, RSUMRESDWH_LAST.RES_ID, sizeof(MTMPRESHIS.RES_ID));
		memcpy(MTMPRESHIS.NEW_STS_6, RSUMRESDWH_LAST.SUB_RES_ID, sizeof(RSUMRESDWH_LAST.SUB_RES_ID));

        MTMPRESHIS.HIST_SEQ =  MRASRESDEF.LAST_ACTIVE_HIST_SEQ ;
        memcpy(MTMPRESHIS.EVENT_ID, HQCEL_M1_EVENT_EQ_CHGSTATUS, strlen(HQCEL_M1_EVENT_EQ_CHGSTATUS));
        memcpy(MTMPRESHIS.TRAN_TIME, s_sys_time, sizeof(MTMPRESHIS.TRAN_TIME));
        memcpy(MTMPRESHIS.SYS_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
        memcpy(MTMPRESHIS.OLD_EVENT_ID, HQCEL_M1_EVENT_EQ_CHGSTATUS, strlen(HQCEL_M1_EVENT_EQ_CHGSTATUS));
		

		
		memcpy(MTMPRESHIS.OLD_PRI_STS, RSUMRESDWH.CURR_ACRO, sizeof(RSUMRESDWH.CURR_ACRO));
        memcpy(MTMPRESHIS.OLD_STS_3, RSUMRESDWH.CURR_CODE, sizeof( RSUMRESDWH.CURR_CODE));
		memcpy(MTMPRESHIS.OLD_STS_4, RSUMRESDWH.CURR_GROUP, sizeof( RSUMRESDWH.CURR_GROUP));
		memcpy(MTMPRESHIS.OLD_STS_5, s_sys_time, sizeof(s_sys_time));
		memcpy(MTMPRESHIS.OLD_STS_5+14, "00", 2);

		memcpy(MTMPRESHIS.NEW_PRI_STS, RSUMRESDWH.CURR_ACRO, sizeof(RSUMRESDWH.CURR_ACRO));
        memcpy(MTMPRESHIS.NEW_STS_3, RSUMRESDWH.CURR_CODE, sizeof( RSUMRESDWH.CURR_CODE));
		memcpy(MTMPRESHIS.NEW_STS_4, RSUMRESDWH.CURR_GROUP, sizeof( RSUMRESDWH.CURR_GROUP));
		memcpy(MTMPRESHIS.NEW_STS_5, s_sys_time, sizeof(s_sys_time));
		memcpy(MTMPRESHIS.NEW_STS_5+14, "00", 2);
		

		memcpy(MTMPRESHIS.TRAN_CMF_2, RSUMRESDWH.ALID, sizeof( RSUMRESDWH.ALID));
		memcpy(MTMPRESHIS.TRAN_CMF_3, RSUMRESDWH.ALCD, sizeof( RSUMRESDWH.ALCD));
		//memcpy(MTMPRESHIS.TRAN_CMF_4, RSUMRESDWH.ALTX, sizeof( RSUMRESDWH.ALTX)); // Server Crash 190925
		memcpy(MTMPRESHIS.TRAN_CMF_4, RSUMRESDWH.ALTX, sizeof( MTMPRESHIS.TRAN_CMF_4)); 

		MTMPRESHIS.PROCESS_FLAG = c_process_flag;
       
        DBC_insert_mtmpreshis(&MTMPRESHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			DB_rollback(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
			continue;
		}

		DB_commit(); //SUMMARY 이므로 LOCK 안잡기위해 처리.
	}

	
	//0. RSUMRESDWN -7일치의 데이터 삭제
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
	
	DB_commit(); //VOC-5496 [프로그램변경]RSUMRESDWH LOCK 으로 인한 긴급 이슈


	//1. RSUMRESDWN -7 ~ 현재 까지의 데이터 추가
	//0. RSUMRESDWN -7일치의 데이터 삭제
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
	DB_commit(); //VOC-5496 [프로그램변경]RSUMRESDWH LOCK 으로 인한 긴급 이슈


	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


