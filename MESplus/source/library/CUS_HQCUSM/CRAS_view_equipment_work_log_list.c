/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_equipment_work_log_list.c
    Description : View equipment_work_log List function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_equipment_work_log_List()
            + View equipment_work_log definition List
        - CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST()
            + Main sub function of CRAS_View_equipment_work_log_List function
            + View equipment_work_log definition List
    Detail Description
        - CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST()
            + h_proc_step
                + 1 : View equipment_work_log definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-06-15             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_equipment_work_log_List()
        - View equipment_work_log definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_equipment_work_log_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST", out_node);

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
    CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST()
        - Main sub function of "CRAS_View_equipment_work_log_List" function
        - View equipment_work_log definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASWRKLOG_TAG CRASWRKLOG;
    struct MWIPCALDEF_TAG MWIPCALDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	int i;
	int icnt = 0;

	char ctime[2];
	char yyyy[4];
	char mm[2];
	char dd[2];
	char tmp_sys_date[14];
	char s_sys_time[14];
	char s_sys_next_time[14];
	char sys_time[10];
	char sys_time_cal[10];
	char int_chk;

    TRSNode *list_item;

	LOG_head("CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    CDB_init_craswrklog(&CRASWRKLOG);
    TRS.copy(CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE), in_node, "HOUR_TYPE");
    TRS.copy(CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT), in_node, "WORK_SHIFT");
  
	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	strncpy(sys_time,s_sys_time,10);

	//get next day
	memset(s_sys_next_time, ' ', sizeof(s_sys_next_time));
	memset(tmp_sys_date, ' ', sizeof(tmp_sys_date));
	memcpy(s_sys_next_time, CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE));
	s_sys_next_time[8] = '0';
	s_sys_next_time[9] = '1';
	s_sys_next_time[10] = '0';
	s_sys_next_time[11] = '1';
	s_sys_next_time[12] = '0';
	s_sys_next_time[13] = '1';

	COM_add_time_sec(tmp_sys_date, s_sys_next_time,60*60*24);
	
	icnt = (int) CDB_select_craswrklog_scalar(3,&CRASWRKLOG);

	//저장이 안된 경우 달력을 조회한다.
	if(icnt == 0)
	{
		int_chk = 'I';
		
		DBC_init_mwipcaldef(&MWIPCALDEF);
		memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //해당 칼렌다로 변경필요.
		MWIPCALDEF.CALENDAR_TYPE = 'F';

		strncpy(yyyy,CRASWRKLOG.WORK_DATE,4);
		strncpy(mm,CRASWRKLOG.WORK_DATE+4,2);
		strncpy(dd,CRASWRKLOG.WORK_DATE+6,2);
		MWIPCALDEF.SYS_YEAR = COM_atoi(yyyy,sizeof(yyyy));
		MWIPCALDEF.SYS_MONTH = COM_atoi(mm,sizeof(mm));
		MWIPCALDEF.SYS_DAY = COM_atoi(dd,sizeof(dd));
		DBC_select_mwipcaldef(1, &MWIPCALDEF);
		if (DB_error_code != DB_SUCCESS)
		{
		    strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "MWIPCALDEF OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if (memcmp(MWIPCALDEF.CAL_CMF_1, CRASWRKLOG.WORK_SHIFT, strlen(CRASWRKLOG.WORK_SHIFT)) == 0)
		{
			for(i=1;i<=12;i++)
			{	
				memset(ctime, 0x00, sizeof(ctime));
				if (i == 1)
				{ memcpy(ctime,"06", sizeof(ctime));}			else if (i == 2)			{ memcpy(ctime,"07", sizeof(ctime));}
				else if (i == 3)			{ memcpy(ctime,"08", sizeof(ctime));}			else if (i == 4)
				{ memcpy(ctime,"09", sizeof(ctime));}			else if (i == 5)			{ memcpy(ctime,"10", sizeof(ctime));}			else if (i == 6)
				{ memcpy(ctime,"11", sizeof(ctime));}			else if (i == 7)			{ memcpy(ctime,"12", sizeof(ctime));}			else if (i == 8)
				{ memcpy(ctime,"13", sizeof(ctime));}			else if (i == 9)			{ memcpy(ctime,"14", sizeof(ctime));}			else if (i == 10)
				{ memcpy(ctime,"15", sizeof(ctime));}			else if (i == 11)			{ memcpy(ctime,"16", sizeof(ctime));}			else if (i == 12)
				{ memcpy(ctime,"17", sizeof(ctime));}

				memset(sys_time_cal, ' ', sizeof(sys_time));
				memcpy(sys_time_cal, CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE));
				COM_add_null(sys_time_cal, sizeof(sys_time_cal));
				sys_time_cal[8] = ctime[0];
				sys_time_cal[9] = ctime[1];
				
				if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) >= COM_atoi(sys_time,sizeof(sys_time)))
				{
					//memset(sys_time_cal, ' ', sizeof(sys_time_cal));
					//continue;              
				}
				int_chk = 'C';
					
				list_item = TRS.add_node(out_node, "EQUIPMENT_WORK_LOG_LIST");
				TRS.add_string(list_item, "WORK_TIME", ctime, sizeof(ctime));
				TRS.add_string(list_item, "WORK_DATE", CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE));
				TRS.add_string(list_item, "LINE_ID", CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID));
				TRS.add_string(list_item, "HOUR_TYPE", CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE));
				TRS.add_string(list_item, "WORK_SHIFT", CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT));
				TRS.add_int(list_item, "HIST_SEQ", 0);
					
				TRS.add_string(list_item, "MACHINE", " ", strlen(" "));
				TRS.add_string(list_item, "MACHINE_NUMBER", " ", strlen(" "));
				TRS.add_string(list_item, "PM", " ", strlen(" "));
				TRS.add_string(list_item, "REQUEST", " ", strlen(" "));
				TRS.add_string(list_item, "PITCHBELT", " ", strlen(" "));
				TRS.add_string(list_item, "START_TIME", " ", strlen(" "));
				TRS.add_string(list_item, "END_TIME", " ", strlen(" "));
				TRS.add_string(list_item, "REPAIR_TIME", " ", strlen(" "));
				TRS.add_string(list_item, "ISSUES", " ", strlen(" "));
				TRS.add_string(list_item, "ISSUES_DETAILS", " ", strlen(" "));
				TRS.add_string(list_item, "ROOT_CAUSES", " ", strlen(" "));
				TRS.add_string(list_item, "PART_REPLACEMENT", " ", strlen(" "));
				TRS.add_int(list_item, "PART_REPLACEMENT_QUANTITIES", 0);
                TRS.add_string(list_item, "ENG_TEC_NAME", " ", strlen(" "));//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
			}

			if(int_chk == 'I')
			{
				COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
				return MP_TRUE;
			}
			else
			{
				COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
				return MP_TRUE;
			}
		}

		else if (memcmp(MWIPCALDEF.CAL_CMF_2, CRASWRKLOG.WORK_SHIFT, strlen(CRASWRKLOG.WORK_SHIFT)) == 0)
		{
			for(i=1;i<=12;i++)
			{	
				memset(ctime, 0x00, sizeof(ctime));
				/*
				if (i == 1)
				{ memcpy(ctime,"18", sizeof(ctime));}			else if (i == 2)			{ memcpy(ctime,"19", sizeof(ctime));}
				else if (i == 3)			{ memcpy(ctime,"20", sizeof(ctime));}			else if (i == 4)
				{ memcpy(ctime,"21", sizeof(ctime));}			else if (i == 5)			{ memcpy(ctime,"22", sizeof(ctime));}			else if (i == 6)
				{ memcpy(ctime,"23", sizeof(ctime));}			else if (i == 7)			{ memcpy(ctime,"24", sizeof(ctime));}			else if (i == 8)
				{ memcpy(ctime,"01", sizeof(ctime));}			else if (i == 9)			{ memcpy(ctime,"02", sizeof(ctime));}			else if (i == 10)
				{ memcpy(ctime,"03", sizeof(ctime));}			else if (i == 11)			{ memcpy(ctime,"04", sizeof(ctime));}			else if (i == 12)
				{ memcpy(ctime,"05", sizeof(ctime));}
				*/

				//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
				if (i == 1)	{ memcpy(ctime,"18", sizeof(ctime));}
				else if (i == 2){ memcpy(ctime,"19", sizeof(ctime));}
				else if (i == 3){ memcpy(ctime,"20", sizeof(ctime));}
				else if (i == 4){ memcpy(ctime,"21", sizeof(ctime));}
				else if (i == 5){ memcpy(ctime,"22", sizeof(ctime));}
				else if (i == 6){ memcpy(ctime,"23", sizeof(ctime));}
				//else if (i == 7){ memcpy(ctime,"24", sizeof(ctime));}
				else if (i == 7){ memcpy(ctime,"00", sizeof(ctime));} //IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
				else if (i == 8){ memcpy(ctime,"01", sizeof(ctime));}
				else if (i == 9){ memcpy(ctime,"02", sizeof(ctime));}
				else if (i == 10){ memcpy(ctime,"03", sizeof(ctime));}
				else if (i == 11){ memcpy(ctime,"04", sizeof(ctime));}
				else if (i == 12){ memcpy(ctime,"05", sizeof(ctime));}
				
				//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                if (memcmp(ctime, "00", strlen("00")) == 0 || 
					memcmp(ctime, "01", strlen("01")) == 0 || memcmp(ctime, "02", strlen("02")) == 0 || memcmp(ctime, "03", strlen("03")) == 0
					|| memcmp(ctime, "04", strlen("04")) == 0 || memcmp(ctime, "05", strlen("05")) == 0 )
				{
					memset(sys_time_cal, ' ', sizeof(sys_time_cal));
					memcpy(sys_time_cal, tmp_sys_date, 8);
					COM_add_null(sys_time_cal, sizeof(sys_time_cal));
					sys_time_cal[8] = ctime[0];
					sys_time_cal[9] = ctime[1];
				}
				//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
				// 24 hour remove
				/*
				else if(memcmp(ctime, "24", strlen("24")) == 0)
				{	memset(sys_time_cal, ' ', sizeof(sys_time_cal));
					memcpy(sys_time_cal, tmp_sys_date, 8);
					COM_add_null(sys_time_cal, sizeof(sys_time_cal));
					sys_time_cal[8] = '0';
					sys_time_cal[9] = '0';
				}
				*/
				else
				{
					memset(sys_time_cal, ' ', sizeof(sys_time));
					memcpy(sys_time_cal, CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE));
					COM_add_null(sys_time_cal, sizeof(sys_time_cal));
					sys_time_cal[8] = ctime[0];
					sys_time_cal[9] = ctime[1];
				}

				if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) >= COM_atoi(sys_time,sizeof(sys_time)))
				{
					//memset(sys_time_cal, ' ', sizeof(sys_time_cal));
					//continue;
				}
				int_chk = 'C';

				list_item = TRS.add_node(out_node, "EQUIPMENT_WORK_LOG_LIST");
				TRS.add_string(list_item, "WORK_TIME", ctime, sizeof(ctime));
				TRS.add_string(list_item, "WORK_DATE", CRASWRKLOG.WORK_DATE, sizeof(CRASWRKLOG.WORK_DATE));
				TRS.add_string(list_item, "LINE_ID", CRASWRKLOG.LINE_ID, sizeof(CRASWRKLOG.LINE_ID));
				TRS.add_string(list_item, "HOUR_TYPE", CRASWRKLOG.HOUR_TYPE, sizeof(CRASWRKLOG.HOUR_TYPE));
				TRS.add_string(list_item, "WORK_SHIFT", CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT));
				TRS.add_int(list_item, "HIST_SEQ", 0);

				TRS.add_string(list_item, "MACHINE", " ", strlen(" "));
				TRS.add_string(list_item, "MACHINE_NUMBER", " ", strlen(" "));
				TRS.add_string(list_item, "PM", " ", strlen(" "));
				TRS.add_string(list_item, "REQUEST", " ", strlen(" "));
				TRS.add_string(list_item, "PITCHBELT", " ", strlen(" "));
				TRS.add_string(list_item, "START_TIME", " ", strlen(" "));
				TRS.add_string(list_item, "END_TIME", " ", strlen(" "));
				TRS.add_string(list_item, "REPAIR_TIME", " ", strlen(" "));
				TRS.add_string(list_item, "ISSUES", " ", strlen(" "));
				TRS.add_string(list_item, "ISSUES_DETAILS", " ", strlen(" "));
				TRS.add_string(list_item, "ROOT_CAUSES", " ", strlen(" "));
				TRS.add_string(list_item, "PART_REPLACEMENT", " ", strlen(" "));
				TRS.add_int(list_item, "PART_REPLACEMENT_QUANTITIES", 0);
                TRS.add_string(list_item, "ENG_TEC_NAME", " ", strlen(" "));//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
			}
			if(int_chk == 'I')
			{
				COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
				return MP_TRUE;
			}
			else
			{
				COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
				return MP_TRUE;
			}
		}
		else
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "MWIPCALDEF OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASWRKLOG.WORK_SHIFT), CRASWRKLOG.WORK_SHIFT);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	CDB_open_craswrklog(2, &CRASWRKLOG);
    if(DB_error_code != DB_SUCCESS)
    {	
        strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "CRASWRKLOG OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASWRKLOG.LINE_ID), CRASWRKLOG.LINE_ID);
        TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASWRKLOG.HOUR_TYPE), CRASWRKLOG.HOUR_TYPE);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASWRKLOG.WORK_SHIFT), CRASWRKLOG.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASWRKLOG.WORK_TIME), CRASWRKLOG.WORK_TIME);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASWRKLOG.HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_craswrklog(2, &CRASWRKLOG);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_craswrklog(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "CRASWRKLOG FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASWRKLOG.WORK_DATE), CRASWRKLOG.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASWRKLOG.LINE_ID), CRASWRKLOG.LINE_ID);
            TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASWRKLOG.HOUR_TYPE), CRASWRKLOG.HOUR_TYPE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASWRKLOG.WORK_SHIFT), CRASWRKLOG.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASWRKLOG.WORK_TIME), CRASWRKLOG.WORK_TIME);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASWRKLOG.HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_craswrklog(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		
        list_item = TRS.add_node(out_node, "EQUIPMENT_WORK_LOG_LIST");

		TRS.add_string(list_item, "WORK_SHIFT", CRASWRKLOG.WORK_SHIFT, sizeof(CRASWRKLOG.WORK_SHIFT));
		TRS.add_string(list_item, "WORK_TIME", CRASWRKLOG.WORK_TIME, sizeof(CRASWRKLOG.WORK_TIME));
		TRS.add_int(list_item, "HIST_SEQ", CRASWRKLOG.HIST_SEQ);

		// list data
		TRS.add_string(list_item, "MACHINE", CRASWRKLOG.MACHINE, sizeof(CRASWRKLOG.MACHINE));
		TRS.add_string(list_item, "MACHINE_NUMBER", CRASWRKLOG.MACHINE_NUMBER, sizeof(CRASWRKLOG.MACHINE_NUMBER));
		TRS.add_string(list_item, "PM", CRASWRKLOG.CMF_2, sizeof(CRASWRKLOG.CMF_2));
		TRS.add_string(list_item, "REQUEST", CRASWRKLOG.CMF_3, sizeof(CRASWRKLOG.CMF_3));
		TRS.add_string(list_item, "PITCHBELT", CRASWRKLOG.CMF_4, sizeof(CRASWRKLOG.CMF_4));
		TRS.add_string(list_item, "START_TIME", CRASWRKLOG.START_TIME, sizeof(CRASWRKLOG.START_TIME));
		TRS.add_string(list_item, "END_TIME", CRASWRKLOG.END_TIME, sizeof(CRASWRKLOG.END_TIME));
		TRS.add_string(list_item, "REPAIR_TIME", CRASWRKLOG.REPAIR_TIME, sizeof(CRASWRKLOG.REPAIR_TIME));
		TRS.add_string(list_item, "ISSUES", CRASWRKLOG.ISSUES, sizeof(CRASWRKLOG.ISSUES));
		TRS.add_string(list_item, "ISSUES_DETAILS", CRASWRKLOG.ISSUES_DETAILS, sizeof(CRASWRKLOG.ISSUES_DETAILS));
		TRS.add_string(list_item, "ROOT_CAUSES", CRASWRKLOG.ROOT_CAUSES, sizeof(CRASWRKLOG.ROOT_CAUSES));
		TRS.add_string(list_item, "PART_REPLACEMENT", CRASWRKLOG.PART_REPLACEMENT, sizeof(CRASWRKLOG.PART_REPLACEMENT));
		TRS.add_int(list_item, "PART_REPLACEMENT_QUANTITIES", CRASWRKLOG.PART_REPLACEMENT_QUANTITIES);
        TRS.add_string(list_item, "ENG_TEC_NAME", CRASWRKLOG.CMF_1, sizeof(CRASWRKLOG.CMF_1));//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog

		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
		memcpy(MGCMTBLDAT.TABLE_NAME, "@EQLOG_REQUEST", sizeof("@EQLOG_REQUEST")); 
		memcpy(MGCMTBLDAT.KEY_1, CRASWRKLOG.CMF_3, sizeof(CRASWRKLOG.CMF_3)); 
		CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "REQUEST_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
		memcpy(MGCMTBLDAT.TABLE_NAME, "@EQLOG_PITCHBELT", sizeof("@EQLOG_PITCHBELT")); 
		memcpy(MGCMTBLDAT.KEY_1, CRASWRKLOG.CMF_4, sizeof(CRASWRKLOG.CMF_4)); 
		CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "PITCHBELT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

