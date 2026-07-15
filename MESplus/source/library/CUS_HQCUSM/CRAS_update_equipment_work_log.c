/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_equipment_work_log.c
    Description : equipment_work_log Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_equipment_work_log()
            + Create/Update/Delete equipment_work_log definition
        - CRAS_UPDATE_EQUIPMENT_WORK_LOG()
            + Main sub function of CRAS_Update_equipment_work_log function
            + Create/Update/Delete equipment_work_log definition
        - CRAS_Update_equipment_work_log_Validation()
            + Main sub function of CRAS_UPDATE_EQUIPMENT_WORK_LOG function
            + Check the condition for create/update/delete equipment_work_log
    Detail Description
        - CRAS_UPDATE_EQUIPMENT_WORK_LOG()
            + h_proc_step
                + MP_STEP_CREATE : Create equipment_work_log definition
                + MP_STEP_UPDATE : Update equipment_work_log definition
                + MP_STEP_DELETE : Delete equipment_work_log definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-06-15             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_equipment_work_log_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_equipment_work_log()
        - Create/Update/Delete equipment_work_log definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_equipment_work_log(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_UPDATE_EQUIPMENT_WORK_LOG(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_EQUIPMENT_WORK_LOG", out_node);

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
    CRAS_UPDATE_EQUIPMENT_WORK_LOG()
        - Main sub function of "CRAS_Update_equipment_work_log" function
        - Create/Update/Delete equipment_work_log definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_EQUIPMENT_WORK_LOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASWRKLOG_TAG CRASWRKLOG;
    struct CRASWRKLOG_TAG CRASWRKLOG_o;
	char s_work_time[14];
	char s_calc_work_time[14];
	char s_curr_time[14];

    char   s_sys_time[14];
	int ihisSeq = 0;
	int i_tran_count;
	int i;
	int i_diff_sec;

	// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
	int i_copy_heck=0;

	TRSNode ** Tran_List;

	LOG_head("CRAS_UPDATE_EQUIPMENT_WORK_LOG");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(CRAS_Update_equipment_work_log_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

	ihisSeq = 0 ;

    for(i = 0; i < i_tran_count; i++)
	{
		// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
		if(TRS.get_procstep(in_node) == MP_STEP_COPY)
		{
			CDB_init_craswrklog(&CRASWRKLOG_o);
			TRS.copy(CRASWRKLOG_o.WORK_DATE, sizeof(CRASWRKLOG_o.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG_o.LINE_ID, sizeof(CRASWRKLOG_o.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG_o.HOUR_TYPE, sizeof(CRASWRKLOG_o.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG_o.WORK_SHIFT, sizeof(CRASWRKLOG_o.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASWRKLOG_o.WORK_TIME, sizeof(CRASWRKLOG_o.WORK_TIME), Tran_List[i], "WORK_TIME");
			CRASWRKLOG_o.HIST_SEQ = 1;
			ihisSeq = (int) CDB_select_craswrklog_scalar(4,&CRASWRKLOG_o);

			if(ihisSeq > 0)
			{
				i_copy_heck = 1; // MP_STEP_APPROVAL
			}
			else
			{
				TRS.add_int(Tran_List[i],"HIST_SEQ", 1);

				i_copy_heck = 2; // MP_STEP_UPDATE
			}
		}

		if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
			CDB_init_craswrklog(&CRASWRKLOG);

			TRS.copy(CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT), in_node, "WORK_SHIFT");

			TRS.copy(CRASWRKLOG.WORK_TIME, sizeof(CRASWRKLOG.WORK_TIME), Tran_List[i], "WORK_TIME");

			CDB_init_craswrklog(&CRASWRKLOG_o);
			TRS.copy(CRASWRKLOG_o.WORK_DATE, sizeof(CRASWRKLOG_o.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG_o.LINE_ID, sizeof(CRASWRKLOG_o.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG_o.HOUR_TYPE, sizeof(CRASWRKLOG_o.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG_o.WORK_SHIFT, sizeof(CRASWRKLOG_o.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASWRKLOG_o.WORK_TIME, sizeof(CRASWRKLOG_o.WORK_TIME), Tran_List[i], "WORK_TIME");
			ihisSeq = 0 ;
			ihisSeq = (int) CDB_select_craswrklog_scalar(2,&CRASWRKLOG_o);
			ihisSeq = ihisSeq + 1;
			CRASWRKLOG.HIST_SEQ = ihisSeq;

			TRS.copy(CRASWRKLOG.MACHINE, sizeof(CRASWRKLOG.MACHINE), in_node, "MACHINE");
			TRS.copy(CRASWRKLOG.MACHINE_NUMBER, sizeof(CRASWRKLOG.MACHINE_NUMBER), in_node, "MACHINE_NUMBER");
			TRS.copy(CRASWRKLOG.CMF_2, sizeof(CRASWRKLOG.CMF_2), in_node, "PM");
			TRS.copy(CRASWRKLOG.START_TIME, sizeof(CRASWRKLOG.START_TIME), in_node, "START_TIME");
			TRS.copy(CRASWRKLOG.END_TIME, sizeof(CRASWRKLOG.END_TIME), in_node, "END_TIME");
			TRS.copy(CRASWRKLOG.REPAIR_TIME, sizeof(CRASWRKLOG.REPAIR_TIME), in_node, "REPAIR_TIME");
			TRS.copy(CRASWRKLOG.ISSUES, sizeof(CRASWRKLOG.ISSUES), in_node, "ISSUES");
			TRS.copy(CRASWRKLOG.ISSUES_DETAILS, sizeof(CRASWRKLOG.ISSUES_DETAILS), in_node, "ISSUES_DETAILS");
			TRS.copy(CRASWRKLOG.ROOT_CAUSES, sizeof(CRASWRKLOG.ROOT_CAUSES), in_node, "ROOT_CAUSES");
			TRS.copy(CRASWRKLOG.PART_REPLACEMENT, sizeof(CRASWRKLOG.PART_REPLACEMENT), in_node, "PART_REPLACEMENT");
            TRS.copy(CRASWRKLOG.CMF_1, sizeof(CRASWRKLOG.CMF_1), in_node, "ENG_TEC_NAME");//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
			CRASWRKLOG.PART_REPLACEMENT_QUANTITIES = TRS.get_int(in_node, "PART_REPLACEMENT_QUANTITIES");
			TRS.copy(CRASWRKLOG.CMF_3, sizeof(CRASWRKLOG.CMF_3), in_node, "REQUEST");   // [2024.01.10]
			TRS.copy(CRASWRKLOG.CMF_4, sizeof(CRASWRKLOG.CMF_4), in_node, "PITCHBELT"); // [2024.01.10]
			
			memcpy(CRASWRKLOG.TRAN_TIME, s_sys_time, sizeof(CRASWRKLOG.TRAN_TIME));
			TRS.copy(CRASWRKLOG.CREATE_USER_ID, sizeof(CRASWRKLOG.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CRASWRKLOG.CREATE_TIME, s_sys_time, sizeof(CRASWRKLOG.CREATE_TIME));

			CDB_insert_craswrklog(&CRASWRKLOG);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASWRKLOG INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASWRKLOG.LINE_ID), CRASWRKLOG.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASWRKLOG.HOUR_TYPE), CRASWRKLOG.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASWRKLOG.WORK_SHIFT), CRASWRKLOG.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASWRKLOG.WORK_TIME), CRASWRKLOG.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASWRKLOG.HIST_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		//else if (TRS.get_procstep(in_node) == MP_STEP_APPROVAL)
		// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
		else if (TRS.get_procstep(in_node) == MP_STEP_APPROVAL || i_copy_heck == 1)
        {
			CDB_init_craswrklog(&CRASWRKLOG);
			TRS.copy(CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT), in_node, "WORK_SHIFT");
	
			TRS.copy(CRASWRKLOG.WORK_TIME, sizeof(CRASWRKLOG.WORK_TIME), Tran_List[i], "WORK_TIME");

			CDB_init_craswrklog(&CRASWRKLOG_o);
			TRS.copy(CRASWRKLOG_o.WORK_DATE, sizeof(CRASWRKLOG_o.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG_o.LINE_ID, sizeof(CRASWRKLOG_o.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG_o.HOUR_TYPE, sizeof(CRASWRKLOG_o.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG_o.WORK_SHIFT, sizeof(CRASWRKLOG_o.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASWRKLOG_o.WORK_TIME, sizeof(CRASWRKLOG_o.WORK_TIME), Tran_List[i], "WORK_TIME");

			//2019 11 11 일에 입력하면
			//2019 11 13 일 05:59:59 까지는 수정 삭제가 가능해야 한다.
			//현재 시간이 SCRAP_DATE + 2일 05:59:59 보다 크면 에러 
			memset(s_curr_time, ' ', sizeof(s_curr_time));
			DB_get_systime(s_curr_time);
			if(DB_error_code != DB_SUCCESS)
			{
				TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_COMMON;

				COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		
			memset(s_work_time, ' ', sizeof(s_work_time));
			TRS.copy(s_work_time, sizeof(s_work_time), Tran_List[i], "START_TIME");
			memcpy(s_work_time+8, "055959", strlen("055959"));

			// 입력받은 scrap date + 2일 한 값의 05:59:59 까지 수정가능		
			// work_time 에 +2일 하여 수정가능한 최종 시간 구한다.
			DB_get_calc_time(s_calc_work_time, s_work_time, 3, 4);		
			COM_diff_time_sec(&i_diff_sec, s_curr_time, s_calc_work_time);
			if(memcmp("OI_EQ_WORKLOG_2", TRS.get_string(Tran_List[i], "LOGIN_USER"), strlen(TRS.get_string(Tran_List[i], "LOGIN_USER"))) == 0)
			{
				if (i_diff_sec > 0)
				{
						// 수정 가능한 시간이 지났습니다.
						strcpy(s_msg_code, "WIP-0601");
						TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
						TRS.add_fieldmsg(out_node, "LIMIT TIME", MP_STR, sizeof(s_calc_work_time), s_calc_work_time);
						TRS.add_fieldmsg(out_node, "CURRENT TIME", MP_STR, sizeof(s_curr_time), s_curr_time);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
				}
			}

	

			ihisSeq = 0 ;
			ihisSeq = (int) CDB_select_craswrklog_scalar(2,&CRASWRKLOG_o);
			ihisSeq = ihisSeq + 1;
			CRASWRKLOG.HIST_SEQ = ihisSeq;

			TRS.copy(CRASWRKLOG.MACHINE, sizeof(CRASWRKLOG.MACHINE), Tran_List[i], "MACHINE");
			TRS.copy(CRASWRKLOG.MACHINE_NUMBER, sizeof(CRASWRKLOG.MACHINE_NUMBER), Tran_List[i], "MACHINE_NUMBER");
			TRS.copy(CRASWRKLOG.CMF_2, sizeof(CRASWRKLOG.CMF_2), Tran_List[i], "PM");
			TRS.copy(CRASWRKLOG.CMF_3, sizeof(CRASWRKLOG.CMF_3), Tran_List[i], "REQUEST");
			TRS.copy(CRASWRKLOG.CMF_4, sizeof(CRASWRKLOG.CMF_4), Tran_List[i], "PITCHBELT");
			TRS.copy(CRASWRKLOG.START_TIME, sizeof(CRASWRKLOG.START_TIME), Tran_List[i], "START_TIME");
			TRS.copy(CRASWRKLOG.END_TIME, sizeof(CRASWRKLOG.END_TIME), Tran_List[i], "END_TIME");
			TRS.copy(CRASWRKLOG.REPAIR_TIME, sizeof(CRASWRKLOG.REPAIR_TIME), Tran_List[i], "REPAIR_TIME");
			TRS.copy(CRASWRKLOG.ISSUES, sizeof(CRASWRKLOG.ISSUES), Tran_List[i], "ISSUES");
			TRS.copy(CRASWRKLOG.ISSUES_DETAILS, sizeof(CRASWRKLOG.ISSUES_DETAILS), Tran_List[i], "ISSUES_DETAILS");
			TRS.copy(CRASWRKLOG.ROOT_CAUSES, sizeof(CRASWRKLOG.ROOT_CAUSES), Tran_List[i], "ROOT_CAUSES");
			TRS.copy(CRASWRKLOG.PART_REPLACEMENT, sizeof(CRASWRKLOG.PART_REPLACEMENT), Tran_List[i], "PART_REPLACEMENT");
            TRS.copy(CRASWRKLOG.CMF_1, sizeof(CRASWRKLOG.CMF_1), Tran_List[i], "ENG_TEC_NAME");//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
			CRASWRKLOG.PART_REPLACEMENT_QUANTITIES = TRS.get_int(Tran_List[i], "PART_REPLACEMENT_QUANTITIES");
			
			memcpy(CRASWRKLOG.TRAN_TIME, s_sys_time, sizeof(CRASWRKLOG.TRAN_TIME));
			TRS.copy(CRASWRKLOG.CREATE_USER_ID, sizeof(CRASWRKLOG.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CRASWRKLOG.CREATE_TIME, s_sys_time, sizeof(CRASWRKLOG.CREATE_TIME));

			CDB_insert_craswrklog(&CRASWRKLOG);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASWRKLOG INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASWRKLOG.LINE_ID), CRASWRKLOG.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASWRKLOG.HOUR_TYPE), CRASWRKLOG.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASWRKLOG.WORK_SHIFT), CRASWRKLOG.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASWRKLOG.WORK_TIME), CRASWRKLOG.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASWRKLOG.HIST_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		//else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
		// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
		else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || i_copy_heck == 2)
		{
			CDB_init_craswrklog(&CRASWRKLOG);
			TRS.copy(CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASWRKLOG.WORK_TIME, sizeof(CRASWRKLOG.WORK_TIME), Tran_List[i], "WORK_TIME");
			
			CRASWRKLOG.HIST_SEQ = TRS.get_int(Tran_List[i], "HIST_SEQ");
			
            CDB_init_craswrklog(&CRASWRKLOG_o);
			TRS.copy(CRASWRKLOG_o.WORK_DATE, sizeof(CRASWRKLOG_o.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG_o.LINE_ID, sizeof(CRASWRKLOG_o.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG_o.HOUR_TYPE, sizeof(CRASWRKLOG_o.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG_o.WORK_SHIFT, sizeof(CRASWRKLOG_o.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASWRKLOG_o.WORK_TIME, sizeof(CRASWRKLOG_o.WORK_TIME), Tran_List[i], "WORK_TIME");
            CRASWRKLOG_o.HIST_SEQ = TRS.get_int(Tran_List[i], "HIST_SEQ");
            CDB_select_craswrklog(1, &CRASWRKLOG_o);
			


			TRS.copy(CRASWRKLOG.MACHINE, sizeof(CRASWRKLOG.MACHINE), Tran_List[i], "MACHINE");
			TRS.copy(CRASWRKLOG.MACHINE_NUMBER, sizeof(CRASWRKLOG.MACHINE_NUMBER), Tran_List[i], "MACHINE_NUMBER");
			TRS.copy(CRASWRKLOG.CMF_2, sizeof(CRASWRKLOG.CMF_2), Tran_List[i], "PM");
			TRS.copy(CRASWRKLOG.CMF_3, sizeof(CRASWRKLOG.CMF_3), Tran_List[i], "REQUEST");
			TRS.copy(CRASWRKLOG.CMF_4, sizeof(CRASWRKLOG.CMF_4), Tran_List[i], "PITCHBELT");
			TRS.copy(CRASWRKLOG.START_TIME, sizeof(CRASWRKLOG.START_TIME), Tran_List[i], "START_TIME");

			//2019 11 11 일에 입력하면
			//2019 11 13 일 05:59:59 까지는 수정 삭제가 가능해야 한다.
			//현재 시간이 SCRAP_DATE + 2일 05:59:59 보다 크면 에러 
			memset(s_curr_time, ' ', sizeof(s_curr_time));
			DB_get_systime(s_curr_time);
			if(DB_error_code != DB_SUCCESS)
			{
				TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_COMMON;

				COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		
			memset(s_work_time, ' ', sizeof(s_work_time));
			TRS.copy(s_work_time, sizeof(s_work_time), Tran_List[i], "START_TIME");
			memcpy(s_work_time+8, "055959", strlen("055959"));

			// 입력받은 scrap date + 2일 한 값의 05:59:59 까지 수정가능		
			// work_time 에 +2일 하여 수정가능한 최종 시간 구한다.
			DB_get_calc_time(s_calc_work_time, s_work_time, 3, 4);		
			COM_diff_time_sec(&i_diff_sec, s_curr_time, s_calc_work_time);


			if(memcmp("OI_EQ_WORKLOG_2", TRS.get_string(Tran_List[i], "LOGIN_USER"), strlen(TRS.get_string(Tran_List[i], "LOGIN_USER"))) == 0)
			{
			if (i_diff_sec > 0)
				{
					// 수정 가능한 시간이 지났습니다.
					strcpy(s_msg_code, "WIP-0601");
					TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
					TRS.add_fieldmsg(out_node, "LIMIT TIME", MP_STR, sizeof(s_calc_work_time), s_calc_work_time);
					TRS.add_fieldmsg(out_node, "CURRENT TIME", MP_STR, sizeof(s_curr_time), s_curr_time);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}	
			}

			TRS.copy(CRASWRKLOG.END_TIME, sizeof(CRASWRKLOG.END_TIME), Tran_List[i], "END_TIME");
			TRS.copy(CRASWRKLOG.REPAIR_TIME, sizeof(CRASWRKLOG.REPAIR_TIME), Tran_List[i], "REPAIR_TIME");
			TRS.copy(CRASWRKLOG.ISSUES, sizeof(CRASWRKLOG.ISSUES), Tran_List[i], "ISSUES");
			TRS.copy(CRASWRKLOG.ISSUES_DETAILS, sizeof(CRASWRKLOG.ISSUES_DETAILS), Tran_List[i], "ISSUES_DETAILS");
			TRS.copy(CRASWRKLOG.ROOT_CAUSES, sizeof(CRASWRKLOG.ROOT_CAUSES), Tran_List[i], "ROOT_CAUSES");
			TRS.copy(CRASWRKLOG.PART_REPLACEMENT, sizeof(CRASWRKLOG.PART_REPLACEMENT), Tran_List[i], "PART_REPLACEMENT");
            TRS.copy(CRASWRKLOG.CMF_1, sizeof(CRASWRKLOG.CMF_1), Tran_List[i], "ENG_TEC_NAME");//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
			CRASWRKLOG.PART_REPLACEMENT_QUANTITIES = TRS.get_int(Tran_List[i], "PART_REPLACEMENT_QUANTITIES");
			
			memcpy(CRASWRKLOG.CREATE_USER_ID, CRASWRKLOG_o.CREATE_USER_ID, sizeof(CRASWRKLOG.CREATE_USER_ID));
			memcpy(CRASWRKLOG.CREATE_TIME, CRASWRKLOG_o.CREATE_TIME, sizeof(CRASWRKLOG.CREATE_TIME));
			TRS.copy(CRASWRKLOG.UPDATE_USER_ID, sizeof(CRASWRKLOG.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CRASWRKLOG.UPDATE_TIME, s_sys_time, sizeof(CRASWRKLOG.UPDATE_TIME));

			CDB_update_craswrklog(1, &CRASWRKLOG);

			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASWRKLOG UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASWRKLOG.LINE_ID), CRASWRKLOG.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASWRKLOG.HOUR_TYPE), CRASWRKLOG.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASWRKLOG.WORK_SHIFT), CRASWRKLOG.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASWRKLOG.WORK_TIME), CRASWRKLOG.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASWRKLOG.HIST_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
		{
			CDB_init_craswrklog(&CRASWRKLOG);
			TRS.copy(CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASWRKLOG.WORK_TIME, sizeof(CRASWRKLOG.WORK_TIME), Tran_List[i], "WORK_TIME");
	
			CRASWRKLOG.HIST_SEQ = TRS.get_int(Tran_List[i], "HIST_SEQ");

			if(CRASWRKLOG.HIST_SEQ == 1)
			{
				TRS.copy(CRASWRKLOG.MACHINE, sizeof(CRASWRKLOG.MACHINE), in_node, "MACHINE");
				TRS.copy(CRASWRKLOG.MACHINE_NUMBER, sizeof(CRASWRKLOG.MACHINE_NUMBER), in_node, "MACHINE_NUMBER");
				TRS.copy(CRASWRKLOG.CMF_2, sizeof(CRASWRKLOG.CMF_2), in_node, "PM");
				TRS.copy(CRASWRKLOG.CMF_3, sizeof(CRASWRKLOG.CMF_3), in_node, "REQUEST");
				TRS.copy(CRASWRKLOG.CMF_4, sizeof(CRASWRKLOG.CMF_4), in_node, "PITCHBELT");
				TRS.copy(CRASWRKLOG.START_TIME, sizeof(CRASWRKLOG.START_TIME), in_node, "START_TIME");
				TRS.copy(CRASWRKLOG.END_TIME, sizeof(CRASWRKLOG.END_TIME), in_node, "END_TIME");
				TRS.copy(CRASWRKLOG.REPAIR_TIME, sizeof(CRASWRKLOG.REPAIR_TIME), in_node, "REPAIR_TIME");
				TRS.copy(CRASWRKLOG.ISSUES, sizeof(CRASWRKLOG.ISSUES), in_node, "ISSUES");
				TRS.copy(CRASWRKLOG.ISSUES_DETAILS, sizeof(CRASWRKLOG.ISSUES_DETAILS), in_node, "ISSUES_DETAILS");
				TRS.copy(CRASWRKLOG.ROOT_CAUSES, sizeof(CRASWRKLOG.ROOT_CAUSES), in_node, "ROOT_CAUSES");
				TRS.copy(CRASWRKLOG.PART_REPLACEMENT, sizeof(CRASWRKLOG.PART_REPLACEMENT), in_node, "PART_REPLACEMENT");
                TRS.copy(CRASWRKLOG.CMF_1, sizeof(CRASWRKLOG.CMF_1), in_node, "ENG_TEC_NAME");//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
				CRASWRKLOG.PART_REPLACEMENT_QUANTITIES = TRS.get_int(in_node, "PART_REPLACEMENT_QUANTITIES");
			
                CDB_init_craswrklog(&CRASWRKLOG_o);
			    TRS.copy(CRASWRKLOG_o.WORK_DATE, sizeof(CRASWRKLOG_o.WORK_DATE), in_node, "WORK_DATE");
			    TRS.copy(CRASWRKLOG_o.LINE_ID, sizeof(CRASWRKLOG_o.LINE_ID), in_node, "LINE_ID");
			    TRS.copy(CRASWRKLOG_o.HOUR_TYPE, sizeof(CRASWRKLOG_o.HOUR_TYPE), in_node, "HOUR_TYPE");
			    TRS.copy(CRASWRKLOG_o.WORK_SHIFT, sizeof(CRASWRKLOG_o.WORK_SHIFT), in_node, "WORK_SHIFT");
			    TRS.copy(CRASWRKLOG_o.WORK_TIME, sizeof(CRASWRKLOG_o.WORK_TIME), Tran_List[i], "WORK_TIME");
                CRASWRKLOG_o.HIST_SEQ = TRS.get_int(Tran_List[i], "HIST_SEQ");
                CDB_select_craswrklog(1, &CRASWRKLOG_o);

				memcpy(CRASWRKLOG.CREATE_USER_ID, CRASWRKLOG_o.CREATE_USER_ID, sizeof(CRASWRKLOG.CREATE_USER_ID));
				memcpy(CRASWRKLOG.CREATE_TIME, CRASWRKLOG_o.CREATE_TIME, sizeof(CRASWRKLOG.CREATE_TIME));
				TRS.copy(CRASWRKLOG.UPDATE_USER_ID, sizeof(CRASWRKLOG.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CRASWRKLOG.UPDATE_TIME, s_sys_time, sizeof(CRASWRKLOG.UPDATE_TIME));

				CDB_update_craswrklog(1, &CRASWRKLOG);
			}
			else
			{
				CDB_delete_craswrklog(1, &CRASWRKLOG);
			}

			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASWRKLOG DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASWRKLOG.LINE_ID), CRASWRKLOG.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASWRKLOG.HOUR_TYPE), CRASWRKLOG.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASWRKLOG.WORK_SHIFT), CRASWRKLOG.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASWRKLOG.WORK_TIME), CRASWRKLOG.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASWRKLOG.HIST_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    CRAS_Update_equipment_work_log_Validation()
        - Main sub function of "CRAS_UPDATE_EQUIPMENT_WORK_LOG" function
        - Check the condition for create/update/delete equipment_work_log
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_equipment_work_log_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
//    struct CRASWRKLOG_TAG CRASWRKLOG;
//    struct MWIPFACDEF_TAG MWIPFACDEF;

	int i;
	int i_tran_count;
	int i_timehour;

	char s_sys_time[14];
	char tmp_sys_date[14];
	char s_sys_next_time[14];
	char sys_time[10];
	char sys_time_cal[10];
	char tmp_yyyymmdd[8];
	char tmp_worktime[2];

	char sys_time_shift_end[10];
	
	TRSNode ** Tran_List;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
    //                          "IUDA") == MP_FALSE)
	// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
	                          "IUDAC") == MP_FALSE)
    {
        return MP_FALSE;
    }

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

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

	strncpy(sys_time,s_sys_time,10);
	//get next day
	memset(s_sys_next_time, ' ', sizeof(s_sys_next_time));
	memset(tmp_sys_date, ' ', sizeof(tmp_sys_date));
	
	if(i_tran_count > 0)
	{
		TRS.copy(s_sys_next_time, sizeof(s_sys_next_time), in_node, "WORK_DATE");
	}
	s_sys_next_time[8] = '0';
	s_sys_next_time[9] = '1';
	s_sys_next_time[10] = '0';
	s_sys_next_time[11] = '1';
	s_sys_next_time[12] = '0';
	s_sys_next_time[13] = '1';

	COM_add_time_sec(tmp_sys_date, s_sys_next_time,60*60*24);

	// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
	strncpy(sys_time_shift_end,s_sys_time,10);
	
	tmp_worktime[0] = sys_time_shift_end[8];
	tmp_worktime[1] = sys_time_shift_end[9];
	i_timehour = COM_atoi(tmp_worktime, 2);
	if(06 <= i_timehour && i_timehour < 18)
	{
		sys_time_shift_end[8] = '1';
		sys_time_shift_end[9] = '8';
	}
	else
	{
		strncpy(sys_time_shift_end,tmp_sys_date,10);
		sys_time_shift_end[8] = '0';
		sys_time_shift_end[9] = '5';
	}
	

	for(i = 0; i < i_tran_count; i++)
	{
		if ((TRS.get_procstep(in_node) == MP_STEP_APPROVAL)  | (TRS.get_procstep(in_node) == MP_STEP_UPDATE))
		{
			memset(tmp_yyyymmdd, ' ', sizeof(tmp_yyyymmdd));
			memset(tmp_worktime, ' ', sizeof(tmp_worktime));
			
			TRS.copy(tmp_yyyymmdd, sizeof(tmp_yyyymmdd), in_node, "WORK_DATE");
			TRS.copy(tmp_worktime, sizeof(tmp_worktime), Tran_List[i], "WORK_TIME");
			
			/*
			if(TRS.get_procstep(in_node) == MP_STEP_APPROVAL)
			{
				//Start Validation data check if not update first data.
				chk_count = 0;
				
				CDB_init_craswrklog(&CRASWRKLOG);
				TRS.copy(CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE), in_node, "WORK_DATE");
				TRS.copy(CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID), in_node, "LINE_ID");
				TRS.copy(CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE), in_node, "HOUR_TYPE");
				TRS.copy(CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT), in_node, "WORK_SHIFT");
				TRS.copy(CRASWRKLOG.WORK_TIME, sizeof(CRASWRKLOG.WORK_TIME), Tran_List[i], "WORK_TIME");

				chk_count = (int) CDB_select_craswrklog_scalar(4,&CRASWRKLOG);
				if(chk_count > 0)
				{
					strcpy(s_msg_code, "RAS-0328");
					TRS.add_fieldmsg(out_node, "UPDATE FEL QTY", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					return MP_FALSE; 
				}
			}
			*/

			if (memcmp(tmp_worktime, "01", strlen("01")) == 0 || memcmp(tmp_worktime, "02", strlen("02")) == 0 || memcmp(tmp_worktime, "03", strlen("03")) == 0
					|| memcmp(tmp_worktime, "04", strlen("04")) == 0 || memcmp(tmp_worktime, "05", strlen("05")) == 0 )
			{
					memset(sys_time_cal, ' ', sizeof(sys_time_cal));
					memcpy(sys_time_cal, tmp_sys_date, 8);
					COM_add_null(sys_time_cal, sizeof(sys_time_cal));
					sys_time_cal[8] = tmp_worktime[0];
					sys_time_cal[9] = tmp_worktime[1];
			}
			else if(memcmp(tmp_worktime, "24", strlen("24")) == 0)
			{		memset(sys_time_cal, ' ', sizeof(sys_time_cal));
					memcpy(sys_time_cal, tmp_sys_date, 8);
					COM_add_null(sys_time_cal, sizeof(sys_time_cal));
					sys_time_cal[8] = '0';
					sys_time_cal[9] = '0';
			}
			else
			{
				memset(sys_time_cal, ' ', sizeof(sys_time));
				memcpy(sys_time_cal, tmp_yyyymmdd, sizeof(tmp_yyyymmdd));
				COM_add_null(sys_time_cal, sizeof(sys_time_cal));
			
				sys_time_cal[8] = tmp_worktime[0];
				sys_time_cal[9] = tmp_worktime[1];
			}

			//if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) >= COM_atoi(sys_time,sizeof(sys_time)))

			// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
			//if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) >= COM_atoi(sys_time_shift_end,sizeof(sys_time_shift_end)))
			//{
			//	strcpy(s_msg_code, "RAS-0326");
			//	TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
			//	TRS.add_dberrmsg(out_node, DB_error_msg);

			//	gs_log_type.type = MP_LOG_ERROR;
			//	gs_log_type.e_type = MP_LOG_E_VALIDATION;
			//	gs_log_type.category = MP_LOG_CATE_SETUP;
			//	return MP_FALSE;          
			//}

			//Start Validation Time Check End
		}
	}

    return MP_TRUE;
}