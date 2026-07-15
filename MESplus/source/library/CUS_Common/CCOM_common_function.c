/********************************************************************************

System      : MESplus
Module      : CUS
File Name   : CCOM_common_function.c
Description : CUSTOM COMMON FUNCTION

MES Version : 5.3.x

Function List

Detail Description
// CUSTOM COMMON FUNCTION

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2018/11/27  Juhyeon.Jung       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <MESCore_common.h>
#include "WIPCore_common.h"
#include "ACTCore_common.h"
#include "MessageCaster.h"


/*******************************************************************************
    CCOM_copy_in_node()
        - In node �ʼ� ���� ����
    Return Value
        - int : MP_TRUE(1) or MP_FALSE 
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *target_node : output Message structure
*******************************************************************************/
void CCOM_copy_in_node(TRSNode *in_node, TRSNode *target_node)
{
    
    TRS.set_char(target_node, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
    TRS.set_nstring(target_node, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
    TRS.set_nstring(target_node, IN_USERID, TRS.get_string(in_node, IN_USERID));
    TRS.set_nstring(target_node, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
    //TRS.add_char(target_node, IN_PROCSTEP, TRS.get_char(in_node, IN_PROCSTEP));
    TRS.set_nstring(target_node, "_IN_TIME", TRS.get_string(in_node, "_IN_TIME"));
    TRS.set_nstring(target_node, "CLIENT_ID", TRS.get_string(in_node, "CLIENT_ID"));
    TRS.set_nstring(target_node, "CLIENT_TIME", TRS.get_string(in_node, "CLIENT_TIME"));
    TRS.set_nstring(target_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));  // 23.04.20 CIM DATA 확인용 추가

    return;
}



/*******************************************************************************
    RPT_get_work_shift()
        - Work Shift ( A, C , D , E ��..)
    Return Value
        - char : SHIFT
    Arguments  
        - char *s_tran_time : Tran Time(YYYYMMDDHH24MISS)
*******************************************************************************/
char RPT_get_work_shift(char *s_trantime)
{
	struct tm TM_P = {0};
	struct MWIPCALDEF_TAG MWIPCALDEF;
	char s_shift = ' ';

	memset(&TM_P,0,sizeof(TM_P));

	if(COM_isspace(s_trantime,sizeof(s_trantime)) == MP_TRUE)
	{
		return ' ';
	}

	TM_P.tm_year = COM_atoi(s_trantime+0 ,4) - 1900;
    TM_P.tm_mon  = COM_atoi(s_trantime+4 ,2) - 1;
    TM_P.tm_mday = COM_atoi(s_trantime+6 ,2);
	TM_P.tm_hour = COM_atoi(s_trantime+8 ,2);
	TM_P.tm_min  = COM_atoi(s_trantime+10,2);
	TM_P.tm_sec  = COM_atoi(s_trantime+12,2);

	TM_P.tm_sec = TM_P.tm_sec - (ONE_HOUR * 6);
	mktime(&TM_P);
	TM_P.tm_year += 1900;
    TM_P.tm_mon  += 1;
    
	DBC_init_mwipcaldef(&MWIPCALDEF);
    memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //�ش� Į���ٷ� �����ʿ�.
    MWIPCALDEF.CALENDAR_TYPE = 'F';
    MWIPCALDEF.SYS_YEAR = TM_P.tm_year;
    MWIPCALDEF.SYS_MONTH = TM_P.tm_mon;
    MWIPCALDEF.SYS_DAY = TM_P.tm_mday;
    DBC_select_mwipcaldef(1, &MWIPCALDEF);
    if (DB_error_code != DB_SUCCESS)
    {
        return ' ';
    }

	if(TM_P.tm_hour >= 0 && TM_P.tm_hour < 12 )
	{
		s_shift = MWIPCALDEF.CAL_CMF_1[0];
	}
	if(TM_P.tm_hour >= 12 && TM_P.tm_hour < 24 )
	{
		s_shift = MWIPCALDEF.CAL_CMF_2[0];
	}
	/*
	if(TM_P.tm_hour >= 0 && TM_P.tm_hour < 12 )
	{
		s_shift = MWIPCALDEF.CAL_CMF_3[0];
	}
	if(TM_P.tm_hour >= 0 && TM_P.tm_hour < 12 )
	{
		s_shift = MWIPCALDEF.CAL_CMF_4[0];
	}
	*/
	return s_shift;
}

/*******************************************************************************
    CCOM_get_work_shift()
        - Work Shift ( A, C , D , E ��..)
    Return Value
        - char : SHIFT
    Arguments  
        - char *s_tran_time : Tran Time(YYYYMMDDHH24MISS)
*******************************************************************************/
char CCOM_get_work_shift(char *s_trantime)
{
	char s_actual_time[15];
	struct MWIPCALDEF_TAG MWIPCALDEF;
	struct worktime_tag cur_work_time;
	char c_workshift;

	memset(s_actual_time, ' ', sizeof(s_actual_time));
	memcpy(s_actual_time, s_trantime, 14);

	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	/* WORK CALENDAR : �ش� SHIFT �� ���� �����. */
	DBC_init_mwipcaldef(&MWIPCALDEF);
	memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //�ش� Į���ٷ� �����ʿ�.
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
			MWIPCALDEF.CAL_CMF_1[0] = '1';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_2, sizeof(MWIPCALDEF.CAL_CMF_2)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_2[0] = '2';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_3, sizeof(MWIPCALDEF.CAL_CMF_3)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_3[0] = '3';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_4, sizeof(MWIPCALDEF.CAL_CMF_4)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_4[0] = '4';


	c_workshift = ' ';
	if (cur_work_time.work_shift ==  1)
			c_workshift = MWIPCALDEF.CAL_CMF_1[0];
	
	if (cur_work_time.work_shift ==  2)
			c_workshift = MWIPCALDEF.CAL_CMF_2[0];
		
	if (cur_work_time.work_shift ==  3)
			c_workshift = MWIPCALDEF.CAL_CMF_3[0];

	if (cur_work_time.work_shift ==  4)
			c_workshift = MWIPCALDEF.CAL_CMF_4[0];

	return c_workshift;
}
/*******************************************************************************
    COM_GET_WORK_DATE()
        - Work Date (08�� ����)
    Return Value
        - int : MP_TRUE(1) or MP_FALSE(0)
    Arguments  
        - char *s_tran_time : Tran Time(YYYYMMDDHH24MISS)
        - char *s_work_date : Work Date(YYYYMMDD)
*******************************************************************************/
void CCOM_get_work_date(char *s_tran_time,
                       char *s_work_date)
{  
    char        s_d_time[14]; 

    memset(s_d_time, ' ', sizeof(s_d_time));
    COM_sub_time_sec(s_d_time, s_tran_time, (int)gd_work_date_start_time * 60 * 60);

    memcpy(s_work_date, s_d_time, 8);

    return;

}

/*******************************************************************************
    CCOM_GET_FACTORY_SHIFT()
        - GET FACTORY SHIFT
    Return Value
        - int : MP_TRUE(1) or MP_FALSE 
    Arguments
        - TRSNode *factory : Input FACTORY
** SUMMARY �� COMMON FUNCTION **
*******************************************************************************/

int CCOM_get_factory_shift(char *factory)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    char s_msg_code[MP_SIZE_MSG];
    char s_error_msg[MP_SIZE_FIELD_MSG];
    char s_field_msg[MP_SIZE_FIELD_MSG];

	memset(gsShiftStartTime, ' ', sizeof(gsShiftStartTime));

    memset(s_msg_code, ' ', MP_SIZE_MSG);
    memset(s_error_msg, ' ', MP_SIZE_FIELD_MSG);
    memset(s_field_msg, ' ', MP_SIZE_FIELD_MSG);

    DBC_init_mwipfacdef(&MWIPFACDEF);
    memcpy(MWIPFACDEF.FACTORY, factory, sizeof(MWIPFACDEF.FACTORY));
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if (DB_error_code != DB_SUCCESS) 
    {
        return MP_FALSE;
    }

    if ((MWIPFACDEF.SHIFT_1_DAY_FLAG == ' ' && MWIPFACDEF.SHIFT_2_DAY_FLAG == ' ' &&
         MWIPFACDEF.SHIFT_3_DAY_FLAG == ' ' && MWIPFACDEF.SHIFT_4_DAY_FLAG == ' ') ||
        (COM_isspace(MWIPFACDEF.SHIFT_1_START, sizeof(MWIPFACDEF.SHIFT_1_START)) == MP_TRUE &&
         COM_isspace(MWIPFACDEF.SHIFT_2_START, sizeof(MWIPFACDEF.SHIFT_2_START)) == MP_TRUE &&
         COM_isspace(MWIPFACDEF.SHIFT_3_START, sizeof(MWIPFACDEF.SHIFT_3_START)) == MP_TRUE &&
         COM_isspace(MWIPFACDEF.SHIFT_4_START, sizeof(MWIPFACDEF.SHIFT_4_START)) == MP_TRUE)) 
    {
        DBC_init_mwipfacdef(&MWIPFACDEF);
        memcpy(MWIPFACDEF.FACTORY, CENTRAL_FACTORY, strlen(CENTRAL_FACTORY));
        DBC_select_mwipfacdef(1, &MWIPFACDEF);
        if (DB_error_code != DB_SUCCESS) 
        {
           return MP_FALSE;
        }
    }

    gsShiftDayFlag[0] = MWIPFACDEF.SHIFT_1_DAY_FLAG;
    if (COM_isspace(MWIPFACDEF.SHIFT_1_START, sizeof(MWIPFACDEF.SHIFT_1_START)) == MP_FALSE) 
    {
        memcpy(gsShiftStartTime[0], MWIPFACDEF.SHIFT_1_START, sizeof(MWIPFACDEF.SHIFT_1_START));
    }

    gsShiftDayFlag[1] = MWIPFACDEF.SHIFT_2_DAY_FLAG;
    if (COM_isspace(MWIPFACDEF.SHIFT_2_START, sizeof(MWIPFACDEF.SHIFT_2_START)) == MP_FALSE) 
    {
        memcpy(gsShiftStartTime[1], MWIPFACDEF.SHIFT_2_START, sizeof(MWIPFACDEF.SHIFT_2_START));
    }
    
	gsShiftDayFlag[2] = MWIPFACDEF.SHIFT_3_DAY_FLAG;
    if (COM_isspace(MWIPFACDEF.SHIFT_3_START, sizeof(MWIPFACDEF.SHIFT_3_START)) == MP_FALSE) 
    {
        memcpy(gsShiftStartTime[2], MWIPFACDEF.SHIFT_3_START, sizeof(MWIPFACDEF.SHIFT_3_START));
    }
    
	gsShiftDayFlag[3] = MWIPFACDEF.SHIFT_4_DAY_FLAG;
    if (COM_isspace(MWIPFACDEF.SHIFT_4_START, sizeof(MWIPFACDEF.SHIFT_4_START)) == MP_FALSE) 
    {
        memcpy(gsShiftStartTime[3], MWIPFACDEF.SHIFT_4_START, sizeof(MWIPFACDEF.SHIFT_4_START));
    }

    return MP_TRUE;
}


/*******************************************************************************
    CCOM_GET_FACTORY_SHIFT()
        - GET FACTORY SHIFT
    Return Value
        - int : MP_TRUE(1) or MP_FALSE 
    Arguments
        - TRSNode *factory : Input FACTORY
** SUMMARY �� COMMON FUNCTION **
*******************************************************************************/

int CCOM_get_factory_erp_shift(char *factory)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    char s_msg_code[MP_SIZE_MSG];
    char s_error_msg[MP_SIZE_FIELD_MSG];
    char s_field_msg[MP_SIZE_FIELD_MSG];

	memset(gsShiftStartTime, ' ', sizeof(gsShiftStartTime));

    memset(s_msg_code, ' ', MP_SIZE_MSG);
    memset(s_error_msg, ' ', MP_SIZE_FIELD_MSG);
    memset(s_field_msg, ' ', MP_SIZE_FIELD_MSG);

    DBC_init_mwipfacdef(&MWIPFACDEF);
    memcpy(MWIPFACDEF.FACTORY, factory, sizeof(MWIPFACDEF.FACTORY));
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if (DB_error_code != DB_SUCCESS) 
    {
        return MP_FALSE;
    }

    if ((MWIPFACDEF.SHIFT_1_DAY_FLAG == ' ' && MWIPFACDEF.SHIFT_2_DAY_FLAG == ' ' &&
         MWIPFACDEF.SHIFT_3_DAY_FLAG == ' ' && MWIPFACDEF.SHIFT_4_DAY_FLAG == ' ') ||
        (COM_isspace(MWIPFACDEF.SHIFT_1_START, sizeof(MWIPFACDEF.SHIFT_1_START)) == MP_TRUE &&
         COM_isspace(MWIPFACDEF.SHIFT_2_START, sizeof(MWIPFACDEF.SHIFT_2_START)) == MP_TRUE &&
         COM_isspace(MWIPFACDEF.SHIFT_3_START, sizeof(MWIPFACDEF.SHIFT_3_START)) == MP_TRUE &&
         COM_isspace(MWIPFACDEF.SHIFT_4_START, sizeof(MWIPFACDEF.SHIFT_4_START)) == MP_TRUE)) 
    {
        DBC_init_mwipfacdef(&MWIPFACDEF);
        memcpy(MWIPFACDEF.FACTORY, CENTRAL_FACTORY, strlen(CENTRAL_FACTORY));
        DBC_select_mwipfacdef(1, &MWIPFACDEF);
        if (DB_error_code != DB_SUCCESS) 
        {
           return MP_FALSE;
        }
    }

    gsShiftDayFlag[0] = 'T';
    if (COM_isspace(MWIPFACDEF.SHIFT_1_START, sizeof(MWIPFACDEF.SHIFT_1_START)) == MP_FALSE) 
    {
        memcpy(gsShiftStartTime[0], "0800", 4);
    }

    gsShiftDayFlag[1] = MWIPFACDEF.SHIFT_2_DAY_FLAG;
    if (COM_isspace(MWIPFACDEF.SHIFT_2_START, sizeof(MWIPFACDEF.SHIFT_2_START)) == MP_FALSE) 
    {
        memcpy(gsShiftStartTime[1], MWIPFACDEF.SHIFT_2_START, sizeof(MWIPFACDEF.SHIFT_2_START));
    }
    

    return MP_TRUE;
}



/*******************************************************************************
CCOM_GET_WORK_TIME()
- CSUMMARY �� COMMON FUNCTION
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- 
*******************************************************************************/
int CCOM_get_work_time(char *last_work_time, struct worktime_tag *work_time)
{
    struct MWIPCALDEF_TAG MWIPCALDEF;

    struct tm TM_P;
    char tmp_date_time[14];
    char tmp_date_time2[14];
	char sub_date_flag = ' ';
	char add_date_flag = ' ';

    int i;

    memset(work_time->work_date, ' ', sizeof(work_time->work_date));
    work_time->work_day_of_week = 0;
    work_time->work_days = 0;
    work_time->work_month = 0;
    work_time->work_shift = 0;
    work_time->work_week = 0;
    work_time->work_year = 0;
	//work_time->work_shift_flag = ' ';
	memset(tmp_date_time, 0x00, sizeof(tmp_date_time)); // Server Crash 190925 Chris Jung �ʱ�ȭ���� ���� ���� 
	memcpy(tmp_date_time, last_work_time, sizeof(tmp_date_time));

	if (memcmp(tmp_date_time+8, "060000", 6) == 0)
	{
		//memcpy(tmp_date_time+8, "055959", 6);
	}

	/* Factory�� Shift �ð� ������ ��´�. */
    if (CCOM_get_factory_shift(HQCEL_M1_DEFAULT_FACTORY) == MP_FALSE)
    {
		return MP_FALSE;
    }
	

    for (i = 0; i < 4; i++)
	{
		if(COM_isspace(gsShiftStartTime[i+1], sizeof(gsShiftStartTime[i+1])) == MP_TRUE)
		{
			if(memcmp(gsShiftStartTime[i], gsShiftStartTime[0], sizeof(gsShiftStartTime[0])) < 0)
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 && memcmp(last_work_time + 8, gsShiftStartTime[0], 4) < 0)
				{
					work_time->work_shift = i+1;

					if(gsShiftDayFlag[i] == 'N')
						sub_date_flag = 'Y';

					break;
				}
			} else
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 || memcmp(last_work_time + 8, gsShiftStartTime[0], 4) < 0)
				{
					work_time->work_shift = i+1;

					// Calculation Previous Day
					if(memcmp(last_work_time + 8, gsShiftStartTime[0], 4) < 0)
						sub_date_flag = 'Y';
					break;
				}
			}
		} else
		{
			if(memcmp(gsShiftStartTime[i], gsShiftStartTime[i+1], sizeof(gsShiftStartTime[0])) < 0)
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 && memcmp(last_work_time + 8, gsShiftStartTime[i + 1], 4) < 0)
				{
					work_time->work_shift = i+1;
					break;
				}
			} else
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 || memcmp(last_work_time + 8, gsShiftStartTime[i + 1], 4) < 0)
				{
					work_time->work_shift = i+1;

					// Calculation Previous Day
					if(gsShiftDayFlag[i] == 'P')
					{
						if(memcmp(last_work_time + 8, gsShiftStartTime[i], 4) > 0)
							add_date_flag = 'Y';
					}
					else if(gsShiftDayFlag[i] == 'N')
					{
						if(memcmp(last_work_time + 8, gsShiftStartTime[i], 4) < 0)
							sub_date_flag = 'Y';
					}
					else
					{
						if(memcmp(last_work_time + 8, gsShiftStartTime[i + 1], 4) < 0)
							sub_date_flag = 'Y';
					}
					break;
				}
			}
		}
	}

	//if(work_time->work_shift == 1)
	//	i = 1;
	//else if(work_time->work_shift == 2)
	//	i = 2;
	//else if(work_time->work_shift == 3)
	//	i = 3;
	//else if(work_time->work_shift == 4)
	//	i = 4;

	for(i = 0; i < 4; i++)
	{
		if(COM_isspace(gsShiftStartTime[i], sizeof(gsShiftStartTime[i])) == MP_TRUE)
			break;
	}

	work_time->last_shift = i;

	memset(tmp_date_time, ' ', sizeof(tmp_date_time));
	memcpy(tmp_date_time, last_work_time, sizeof(tmp_date_time));
	if (memcmp(tmp_date_time+8, "060000", 6) == 0)
	{
		//memcpy(tmp_date_time+8, "055959", 6);
	}
	if(sub_date_flag == 'Y')
    {
        //COM_calc_time(tmp_date_time, last_work_time, 3, -1);
		//���ϴ°���� �ȳ��� �Ʒ� �Լ��� ���ۼ�
		DB_get_calc_time(tmp_date_time, last_work_time, 3, -1);
    }

	if(add_date_flag == 'Y')
    {
        //COM_calc_time(tmp_date_time, last_work_time, 3, 1);
		//���ϴ°���� �ȳ��� �Ʒ� �Լ��� ���ۼ�
		DB_get_calc_time(tmp_date_time, last_work_time, 3, 1);

    }

	memcpy(work_time->work_date_time, tmp_date_time, 8);
	memcpy(work_time->work_date_time+8, gsShiftStartTime[work_time->work_shift-1], sizeof(gsShiftStartTime[0]));
	memcpy(work_time->work_date_time+12, "00", strlen("00"));

    if (COM_get_date_time_tm(&TM_P, tmp_date_time) == MP_FALSE)
    {
        return MP_FALSE;
    }

	//workdate ���۰� workdate �Ϸ�ð� (for QCELL 2shift )
	{
		memcpy(work_time->work_shift_start_time, work_time->work_date_time, sizeof(work_time->work_date_time));
		work_time->work_date_start_time[13] = '1';
		if(sub_date_flag == 'Y')
		{
			if (work_time->work_shift == 2)
			{
				memcpy(work_time->work_date_start_time, work_time->work_date_time, sizeof(work_time->work_date_time));
				work_time->work_date_start_time[13] = '1';
				DB_get_calc_time(work_time->work_shift_end_time, work_time->work_date_time, 3, 1);
		
				memcpy(work_time->work_shift_end_time+8, gsShiftStartTime[0], sizeof(gsShiftStartTime[0]));
				memcpy(work_time->work_shift_end_time+12, "00", strlen("00"));
			}
			else
			{
				memcpy(work_time->work_shift_end_time, last_work_time, 8);
				memcpy(work_time->work_shift_end_time+8, gsShiftStartTime[work_time->work_shift-1], sizeof(gsShiftStartTime[0]));
				memcpy(work_time->work_shift_end_time+12, "00", strlen("00"));
			}
		}
		else
		{
			if (work_time->work_shift == 2)
			{
				memcpy(work_time->work_date_start_time, work_time->work_date_time, sizeof(work_time->work_date_time));
				work_time->work_date_start_time[13] = '1';
				DB_get_calc_time(work_time->work_shift_end_time, work_time->work_date_time, 3, 1);
		
				memcpy(work_time->work_shift_end_time+8, gsShiftStartTime[0], sizeof(gsShiftStartTime[0]));
				memcpy(work_time->work_shift_end_time+12, "00", strlen("00"));
			}
			else
			{
				memcpy(work_time->work_shift_end_time, tmp_date_time, 8);
				memcpy(work_time->work_shift_end_time+8, gsShiftStartTime[work_time->work_shift], sizeof(gsShiftStartTime[0]));
				memcpy(work_time->work_shift_end_time+12, "00", strlen("00"));
			}
		}
		
		memcpy(work_time->work_date_start_time, work_time->work_date_time, sizeof(work_time->work_date_time));
		memcpy(work_time->work_date_start_time+8, "060001", 6);
		DB_get_calc_time(work_time->work_date_end_time, work_time->work_date_time, 3, 1);
		
		memcpy(work_time->work_date_end_time+8, gsShiftStartTime[0], sizeof(gsShiftStartTime[0]));
		memcpy(work_time->work_date_end_time+12, "00", strlen("00"));

	}

    TM_P.tm_year += 1900;
    TM_P.tm_mon += 1;
    TM_P.tm_yday += 1;

    DBC_init_mwipcaldef(&MWIPCALDEF);
    memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //�ش� Į���ٷ� �����ʿ�.
    MWIPCALDEF.CALENDAR_TYPE = 'F';
    MWIPCALDEF.SYS_YEAR = TM_P.tm_year;
    MWIPCALDEF.SYS_MONTH = TM_P.tm_mon;
    MWIPCALDEF.SYS_DAY = TM_P.tm_mday;
    DBC_select_mwipcaldef(1, &MWIPCALDEF);
    if (DB_error_code != DB_SUCCESS)
    {
        /* Default Date */
        work_time->work_year = TM_P.tm_year;
        work_time->work_month = TM_P.tm_mon;
        work_time->work_days = TM_P.tm_yday;
        work_time->work_week = (int)(((TM_P.tm_yday - 1) + TM_P.tm_wday) / 7) + 1;
        work_time->work_day_of_week = TM_P.tm_wday;
        memcpy(work_time->work_date, tmp_date_time, 8);
        return MP_TRUE;
    }

    work_time->work_year = MWIPCALDEF.PLAN_YEAR;
    work_time->work_month = MWIPCALDEF.PLAN_MONTH;
    work_time->work_week = MWIPCALDEF.PLAN_WEEK;
    work_time->work_days = MWIPCALDEF.JULIAN_DAY;

    if (MWIPCALDEF.PREV_DAY_FG == 'Y')
    {
        if (MWIPCALDEF.START_TIME > (TM_P.tm_hour * 100 + TM_P.tm_min))
        {
            work_time->work_day_of_week = TM_P.tm_wday;
            memcpy(work_time->work_date, tmp_date_time, 8);
        }
        else
        {
            memset(tmp_date_time2, ' ', sizeof(tmp_date_time2));
            //COM_calctime(tmp_date_time, 3, -1, tmp_date_time2, sizeof(tmp_date_time));
            COM_calc_time(tmp_date_time2, tmp_date_time, 3, -1);
            COM_get_date_time_tm(&TM_P, tmp_date_time2);
            work_time->work_day_of_week = TM_P.tm_wday;
            memcpy(work_time->work_date, tmp_date_time2, 8);
        }
    }
    else
    {
        //if (MWIPCALDEF.START_TIME > (TM_P.tm_hour * 100 + TM_P.tm_min))
        //{
        //    memset(tmp_date_time2, ' ', sizeof(tmp_date_time2));
        //    //COM_calctime(tmp_date_time, 3, -1, tmp_date_time2, sizeof(tmp_date_time));
        //    COM_calc_time(tmp_date_time2, tmp_date_time, 3, -1);
        //    COM_get_date_time_tm(&TM_P, tmp_date_time2);
        //    work_time->work_day_of_week = TM_P.tm_wday;
        //    memcpy(work_time->work_date, tmp_date_time2, 8);
        //}
        //else
        //{
            work_time->work_day_of_week = TM_P.tm_wday;
            memcpy(work_time->work_date, tmp_date_time, 8);
        //}
    }

	/*if (work_time->work_shift == 1)
	{
		work_time->work_shift_flag = 'A';
	}
	else if (work_time->work_shift == 2)
	{
		work_time->work_shift_flag = 'B';
	}
	else
	{
		work_time->work_shift_flag = 'C';
	}
*/
    return MP_TRUE;
}


/*******************************************************************************
CCOM_GET_WORK_TIME()
- CSUMMARY �� COMMON FUNCTION
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- 
*******************************************************************************/
int CCOM_get_work_erp_time(char *last_work_time, struct worktime_tag *work_time)
{
    struct MWIPCALDEF_TAG MWIPCALDEF;

    struct tm TM_P;
    char tmp_date_time[14];
    char tmp_date_time2[14];
	char sub_date_flag = ' ';
	char add_date_flag = ' ';

    int i;

    memset(work_time->work_date, ' ', sizeof(work_time->work_date));
    work_time->work_day_of_week = 0;
    work_time->work_days = 0;
    work_time->work_month = 0;
    work_time->work_shift = 0;
    work_time->work_week = 0;
    work_time->work_year = 0;
	//work_time->work_shift_flag = ' ';

	memcpy(tmp_date_time, last_work_time, sizeof(tmp_date_time));

	/* Factory�� Shift �ð� ������ ��´�. */
    if (CCOM_get_factory_erp_shift(HQCEL_M1_DEFAULT_FACTORY) == MP_FALSE)
    {
		return MP_FALSE;
    }
	

    for (i = 0; i < 4; i++)
	{
		if(COM_isspace(gsShiftStartTime[i+1], sizeof(gsShiftStartTime[i+1])) == MP_TRUE)
		{
			if(memcmp(gsShiftStartTime[i], gsShiftStartTime[0], sizeof(gsShiftStartTime[0])) < 0)
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 && memcmp(last_work_time + 8, gsShiftStartTime[0], 4) < 0)
				{
					work_time->work_shift = i+1;

					if(gsShiftDayFlag[i] == 'N')
						sub_date_flag = 'Y';

					break;
				}
			} else
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 || memcmp(last_work_time + 8, gsShiftStartTime[0], 4) < 0)
				{
					work_time->work_shift = i+1;

					// Calculation Previous Day
					if(memcmp(last_work_time + 8, gsShiftStartTime[0], 4) < 0)
						sub_date_flag = 'Y';
					break;
				}
			}
		} else
		{
			if(memcmp(gsShiftStartTime[i], gsShiftStartTime[i+1], sizeof(gsShiftStartTime[0])) < 0)
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 && memcmp(last_work_time + 8, gsShiftStartTime[i + 1], 4) < 0)
				{
					work_time->work_shift = i+1;
					break;
				}
			} else
			{
				if (memcmp(last_work_time + 8, gsShiftStartTime[i], 4) >= 0 || memcmp(last_work_time + 8, gsShiftStartTime[i + 1], 4) < 0)
				{
					work_time->work_shift = i+1;

					// Calculation Previous Day
					if(gsShiftDayFlag[i] == 'P')
					{
						if(memcmp(last_work_time + 8, gsShiftStartTime[i], 4) > 0)
							add_date_flag = 'Y';
					}
					else if(gsShiftDayFlag[i] == 'N')
					{
						if(memcmp(last_work_time + 8, gsShiftStartTime[i], 4) < 0)
							sub_date_flag = 'Y';
					}
					else
					{
						if(memcmp(last_work_time + 8, gsShiftStartTime[i + 1], 4) < 0)
							sub_date_flag = 'Y';
					}
					break;
				}
			}
		}
	}

	//if(work_time->work_shift == 1)
	//	i = 1;
	//else if(work_time->work_shift == 2)
	//	i = 2;
	//else if(work_time->work_shift == 3)
	//	i = 3;
	//else if(work_time->work_shift == 4)
	//	i = 4;

	for(i = 0; i < 4; i++)
	{
		if(COM_isspace(gsShiftStartTime[i], sizeof(gsShiftStartTime[i])) == MP_TRUE)
			break;
	}

	work_time->last_shift = i;

	memset(tmp_date_time, ' ', sizeof(tmp_date_time));
	memcpy(tmp_date_time, last_work_time, sizeof(tmp_date_time));

	if(sub_date_flag == 'Y')
    {
        COM_calc_time(tmp_date_time, last_work_time, 3, -1);
    }

	if(add_date_flag == 'Y')
    {
        COM_calc_time(tmp_date_time, last_work_time, 3, 1);
    }

	memcpy(work_time->work_date_time, tmp_date_time, 8);
	memcpy(work_time->work_date_time+8, gsShiftStartTime[work_time->work_shift-1], sizeof(gsShiftStartTime[0]));
	memcpy(work_time->work_date_time+12, "00", strlen("00"));

    if (COM_get_date_time_tm(&TM_P, tmp_date_time) == MP_FALSE)
    {
        return MP_FALSE;
    }

    TM_P.tm_year += 1900;
    TM_P.tm_mon += 1;
    TM_P.tm_yday += 1;

    DBC_init_mwipcaldef(&MWIPCALDEF);
    memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //�ش� Į���ٷ� �����ʿ�.
    MWIPCALDEF.CALENDAR_TYPE = 'F';
    MWIPCALDEF.SYS_YEAR = TM_P.tm_year;
    MWIPCALDEF.SYS_MONTH = TM_P.tm_mon;
    MWIPCALDEF.SYS_DAY = TM_P.tm_mday;
    DBC_select_mwipcaldef(1, &MWIPCALDEF);
    if (DB_error_code != DB_SUCCESS)
    {
        /* Default Date */
        work_time->work_year = TM_P.tm_year;
        work_time->work_month = TM_P.tm_mon;
        work_time->work_days = TM_P.tm_yday;
        work_time->work_week = (int)(((TM_P.tm_yday - 1) + TM_P.tm_wday) / 7) + 1;
        work_time->work_day_of_week = TM_P.tm_wday;
        memcpy(work_time->work_date, tmp_date_time, 8);
        return MP_TRUE;
    }

    work_time->work_year = MWIPCALDEF.PLAN_YEAR;
    work_time->work_month = MWIPCALDEF.PLAN_MONTH;
    work_time->work_week = MWIPCALDEF.PLAN_WEEK;
    work_time->work_days = MWIPCALDEF.JULIAN_DAY;

    if (MWIPCALDEF.PREV_DAY_FG == 'Y')
    {
        if (MWIPCALDEF.START_TIME > (TM_P.tm_hour * 100 + TM_P.tm_min))
        {
            work_time->work_day_of_week = TM_P.tm_wday;
            memcpy(work_time->work_date, tmp_date_time, 8);
        }
        else
        {
            memset(tmp_date_time2, ' ', sizeof(tmp_date_time2));
            //COM_calctime(tmp_date_time, 3, -1, tmp_date_time2, sizeof(tmp_date_time));
            COM_calc_time(tmp_date_time2, tmp_date_time, 3, -1);
            COM_get_date_time_tm(&TM_P, tmp_date_time2);
            work_time->work_day_of_week = TM_P.tm_wday;
            memcpy(work_time->work_date, tmp_date_time2, 8);
        }
    }
    else
    {
        //if (MWIPCALDEF.START_TIME > (TM_P.tm_hour * 100 + TM_P.tm_min))
        //{
        //    memset(tmp_date_time2, ' ', sizeof(tmp_date_time2));
        //    //COM_calctime(tmp_date_time, 3, -1, tmp_date_time2, sizeof(tmp_date_time));
        //    COM_calc_time(tmp_date_time2, tmp_date_time, 3, -1);
        //    COM_get_date_time_tm(&TM_P, tmp_date_time2);
        //    work_time->work_day_of_week = TM_P.tm_wday;
        //    memcpy(work_time->work_date, tmp_date_time2, 8);
        //}
        //else
        //{
            work_time->work_day_of_week = TM_P.tm_wday;
            memcpy(work_time->work_date, tmp_date_time, 8);
        //}
    }

	/*if (work_time->work_shift == 1)
	{
		work_time->work_shift_flag = 'A';
	}
	else if (work_time->work_shift == 2)
	{
		work_time->work_shift_flag = 'B';
	}
	else
	{
		work_time->work_shift_flag = 'C';
	}
*/
    return MP_TRUE;
}

/*******************************************************************************
    COM_Save_Service_Error_Log()
        - 
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/

int COM_Save_Service_Error_Log(TRSNode *in_node, TRSNode *out_node)
{ 
	struct MSVMERRLOG_TAG MSVMERRLOG;
    TRSNode **node;
	char s_temp[2000];
	char s_sys_time[14];

	int i;

    double d_tran_time;
	char s_tran_end_time[17];
	//char s_tran_start_time[17];

    char s_sys_time_stamp[20];  

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  
	    
    //End Add
	if(gc_collect_error_logging == 'Y')
    {

		if(in_node == 0x00 || out_node == 0x00)
		{
			return MP_FALSE;
		}

        DB_get_systime_m(s_sys_time_stamp);
        if(DB_error_code != DB_SUCCESS)
        {
            TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        memset(s_tran_end_time, ' ', sizeof(s_tran_end_time));
        memcpy(s_tran_end_time, s_sys_time_stamp, sizeof(s_tran_end_time));
        COM_diff_time_millisec(&d_tran_time, s_tran_end_time, TRS.get_string(in_node, "TRAN_START_TIME"));

        if(d_tran_time < 0)
        {
            d_tran_time = 0;
        } 

        memset(s_sys_time, ' ', sizeof(s_sys_time));
        memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));

        if (TRS.get_char(out_node, "STATUSVALUE") == MP_FAIL_C ||
		    TRS.get_char(out_node, "STATUSVALUE") == MP_WARN_C ||
		    TRS.get_char(out_node, "STATUSVALUE") == MP_TROUBLE_C)
		{

			DBC_init_msvmerrlog(&MSVMERRLOG);
			memcpy(MSVMERRLOG.TRAN_TIME, s_sys_time, sizeof(MSVMERRLOG.TRAN_TIME));
			memcpy(MSVMERRLOG.SYSTEM_NODE, gs_collect_node, sizeof(MSVMERRLOG.SYSTEM_NODE));
			memcpy(MSVMERRLOG.SERVER_NAME, gs_server_name, sizeof(MSVMERRLOG.SERVER_NAME));
			memcpy(MSVMERRLOG.SUBNO, gs_subno, sizeof(MSVMERRLOG.SUBNO));
			TRS.copy(MSVMERRLOG.SERVICE_NAME, sizeof(MSVMERRLOG.SERVICE_NAME), in_node, "_SERVICE_NAME");
			TRS.copy(MSVMERRLOG.FACTORY, sizeof(MSVMERRLOG.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MSVMERRLOG.RES_ID, sizeof(MSVMERRLOG.RES_ID), in_node, "RES_ID");
			TRS.copy(MSVMERRLOG.LOT_ID, sizeof(MSVMERRLOG.LOT_ID), in_node, "LOT_ID");

			MSVMERRLOG.STATUS_VALUE = TRS.get_char(out_node, OUT_STATUSVALUE);
			TRS.copy(MSVMERRLOG.MSG_ID, sizeof(MSVMERRLOG.MSG_ID), out_node, OUT_MSGCODE);
			TRS.copy(MSVMERRLOG.ERROR_MSG, sizeof(MSVMERRLOG.ERROR_MSG), out_node, OUT_MSG);
			TRS.copy(MSVMERRLOG.DB_ERROR_MSG, sizeof(MSVMERRLOG.DB_ERROR_MSG), out_node, OUT_DBERRMSG);

            TRS.copy(MSVMERRLOG.ERR_CMF_1, sizeof(MSVMERRLOG.ERR_CMF_1), in_node, "LINE_ID");
			TRS.copy(MSVMERRLOG.ERR_CMF_2, sizeof(MSVMERRLOG.ERR_CMF_2), in_node, "OPER"); 
            TRS.copy(MSVMERRLOG.ERR_CMF_3, sizeof(MSVMERRLOG.ERR_CMF_3), in_node, "MAT_ID");  

            if (TRS.mem_cmp(out_node, OUT_MSGCODE, "EDC-0016", strlen("EDC-0016")) == 0)
                TRS.copy(MSVMERRLOG.ERR_CMF_4, sizeof(MSVMERRLOG.ERR_CMF_4), in_node, "COL_SET_ID");  

            if (TRS.get_int(out_node, "CHAR_INDEX") > 0)
            {
                memset(s_temp, ' ', sizeof(s_temp));
                COM_itoa_left(MSVMERRLOG.ERR_CMF_5, TRS.get_int(out_node, "CHAR_INDEX"), sizeof(MSVMERRLOG.ERR_CMF_5)); 
                TRS.copy(MSVMERRLOG.ERR_CMF_6, sizeof(MSVMERRLOG.ERR_CMF_6), out_node, "VALUE");
            }

			MSVMERRLOG.CONSUME_SEC = d_tran_time;

			memset(s_temp, 0x0, sizeof(s_temp));
			node = TRS.get_list(out_node, OUT_FIELDMSG);
			if(node != 0x0)
			{
				for(i = 0; i < node[0]->MemberCount; i++)
				{
					if(node[0]->Members[i]->ValueType == DT_STRING ||
					   node[0]->Members[i]->ValueType == DT_NSTRING)
					{
						if(node[0]->Members[i]->Value.s != 0x0)
						{
							if((strlen(s_temp) + strlen(node[0]->Members[i]->Value.s)) > 900)
							{
								break;
							}

							sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.s);
						}
					}
					else if(node[0]->Members[i]->ValueType == DT_CHAR)
					{
						if(node[0]->Members[i]->Value.c != 0x0)
						{
							sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.c);
						}
					}
					else if(node[0]->Members[i]->ValueType == DT_INT)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i4);
					}
					else if(node[0]->Members[i]->ValueType == DT_LONG)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i8);
					}
					else if(node[0]->Members[i]->ValueType == DT_FLOAT)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f4);
					}
					else if(node[0]->Members[i]->ValueType == DT_DOUBLE)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f8);
					}

					if(strlen(s_temp) > 900)
					{
						break;
					}
				}
			}
			memcpy(MSVMERRLOG.ERROR_MSG_DETAIL, s_temp, strlen(s_temp));

			memset(s_temp, 0x0, sizeof(s_temp));
			if(in_node != 0x0)
			{
				for(i = 0; i < in_node->MemberCount; i++)
				{
					if(in_node->Members[i]->ValueType == DT_STRING ||
					   in_node->Members[i]->ValueType == DT_NSTRING)
					{
						if(in_node->Members[i]->Value.s != 0x0)
						{
							if((strlen(s_temp) + strlen(in_node->Members[i]->Value.s)) > 900)
							{
								break;
							}
                        
							if(strcmp(in_node->Members[i]->Name, "_SERVICE_NAME") == 0 ||
								strcmp(in_node->Members[i]->Name, "_MODULE_NAME") == 0||
								strcmp(in_node->Members[i]->Name, "PASSWORD") == 0)
							{
								//Do Nothing
							}
							else
							{
								sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.s);
							}
						}
					}
					else if(in_node->Members[i]->ValueType == DT_CHAR)
					{
						if(in_node->Members[i]->Value.c != 0x0)
						{
							sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.c);
						}
					}
					else if(in_node->Members[i]->ValueType == DT_INT)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i4);
					}
					else if(in_node->Members[i]->ValueType == DT_LONG)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i8);
					}
					else if(in_node->Members[i]->ValueType == DT_FLOAT)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f4);
					}
					else if(in_node->Members[i]->ValueType == DT_DOUBLE)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f8);
					}

					if(strlen(s_temp) > 900)
					{
						break;
					}
				}
			}
			memcpy(MSVMERRLOG.IN_MSG, s_temp, strlen(s_temp));

			TRS.copy(MSVMERRLOG.CREATE_USER_ID, sizeof(MSVMERRLOG.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(MSVMERRLOG.CREATE_TIME, s_sys_time, sizeof(MSVMERRLOG.CREATE_TIME));

			DBC_insert_msvmerrlog(&MSVMERRLOG);
			if(DB_error_code != DB_SUCCESS) 
			{
				LOG_head("MES_SVC_SAVE_ERROR");
				LOG_add("table", MP_NSTR, "MSVMERRLOG INSERT ERROR");
				LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
				COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

				DB_rollback();
				return MP_FALSE;
			}

			DB_commit();
		}
    }

    return MP_TRUE;
}
/*******************************************************************************
    COM_Guaranteed_CRASPRCDATA()
        - RPT DB�� �����Ķ���� Guaranteed �޼��� ����
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - TRSNode *in_node : Input Message structure
		- TRSNode *in_node : Input Message structure
*******************************************************************************/
int COM_Guaranteed_CRASPRCDATA(char *s_msg_code, TRSNode *in_node)
{
	char s_channel[100];
	
   /* LOG_head("COM_Guaranteed_CRASPRCDATA");
    COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW); */

	//memset(s_channel, 0x00, sizeof(s_channel));
	//sprintf(s_channel, "/%.*s/GTMServer", 4, gs_site_id);
	//
	////3600*1000*5. 5Hour
	//if(CallService("CEIS", 
	//				"EAPMES_Collect_Resource_Data", 
	//				in_node, 
	//				0x00, 
	//				s_channel, 
	//				18000000, //gi_default_ttl, 
	//				DM_GUNICAST) != MP_TRUE)
	//{
	//	/*Error Log ó��*/
	//	LOG_head("COM_Guaranteed_CRASPRCDATA Send Error");
	//	COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW); 
	//	return MP_FALSE;
	//}	

	memset(s_channel, 0x00, sizeof(s_channel));
    sprintf(s_channel, "/%.*s/ARCServer", 4, gs_site_id);

    LOG_head("COM_Guaranteed_CRASPRCDATA ARC");
    COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW); 

	if(CallService("CEIS", 
					"EAPMES_Collect_Resource_Data", 
					in_node, 
					0x00, 
					s_channel, 
					18000000, //gi_default_ttl, 
					DM_GUNICAST) != MP_TRUE)
	{
		/*Error Log ó��*/
		LOG_head("COM_Guaranteed_CRASPRCDATA Send Error");
		COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW); 
		//return MP_FALSE;
	}	

	
	return MP_TRUE;
}

/*******************************************************************************
    COM_Publish_Data()
        - Client�� ���� �޽��� ����
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
*******************************************************************************/
int COM_Publish_Data(char *s_msg_code,
                                 TRSNode *in_node)
{
    char s_channel[100];

    LOG_head("COM_Publish_Data");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID")); 
	LOG_add("in_service_name", MP_NSTR, TRS.get_string(in_node, "IN_SERVICE_NAME")); 
	//TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW); 


	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/MESCLI/", 4, gs_site_id);
	strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, IN_FACTORY));
	COM_add_null(s_channel, sizeof(s_channel));
	strcpy(s_channel + strlen(s_channel), "/");
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID")); 
	strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "PC_ID")); 
	COM_add_null(s_channel, sizeof(s_channel));

	if(CallService(MODULE_CLI, 
					"M_Publish_Data", 
					in_node, 
					0x00, 
					s_channel, 
					gi_default_ttl, 
					DM_MULTICAST) != MP_TRUE)
	{
		/*Error Log ó��*/
	}	

	
    return MP_TRUE;
}




/*******************************************************************************
CCOM_GET_WORK_TIME()
- CSUMMARY �� COMMON FUNCTION
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- 
*******************************************************************************/
int CCOM_COPY_FROM_PRCDATA_TO_LOTDATA (TRSNode *in_node, struct CRASPRCDAT_TAG *CRASPRCDAT)
{
    struct CEDCLOTDAT_TAG CEDCLOTDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	int icnt = 0;


	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@EQ_EDC_INSCONFIG", strlen("@EQ_EDC_INSCONFIG"));
	memcpy(MGCMLAGDAT.KEY_1, CRASPRCDAT->OPER, sizeof(CRASPRCDAT->OPER));
	memcpy(MGCMLAGDAT.KEY_2, CRASPRCDAT->PARAM_NAME, sizeof(CRASPRCDAT->PARAM_NAME));
	CDB_select_mgcmlagdat(1, &MGCMLAGDAT);
	if(DB_error_code != DB_SUCCESS)
	{
		return MP_TRUE;
	}

	CDB_init_cedclotdat(&CEDCLOTDAT);
	memcpy(CEDCLOTDAT.LOT_ID, CRASPRCDAT->LOT_ID, sizeof(CEDCLOTDAT.LOT_ID));
	memcpy(CEDCLOTDAT.PARAM_NAME, CRASPRCDAT->PARAM_NAME, sizeof(CEDCLOTDAT.PARAM_NAME));
	memcpy(CEDCLOTDAT.TRAN_TIME, CRASPRCDAT->TRAN_TIME, sizeof(CEDCLOTDAT.TRAN_TIME));
	icnt = (int) CDB_select_cedclotdat_scalar(2, &CEDCLOTDAT) + 1;
	CEDCLOTDAT.SEQ_NUM = icnt;
	memcpy(CEDCLOTDAT.RES_ID, CRASPRCDAT->RES_ID, sizeof(CEDCLOTDAT.RES_ID));
	memcpy(CEDCLOTDAT.LINE_ID, CRASPRCDAT->LINE_ID, sizeof(CEDCLOTDAT.LINE_ID));
	memcpy(CEDCLOTDAT.OPER, CRASPRCDAT->OPER, sizeof(CEDCLOTDAT.OPER));
	CEDCLOTDAT.LOT_HIST_SEQ = CRASPRCDAT->LOT_HIST_SEQ;
	memcpy(CEDCLOTDAT.PARAM_VALUE, CRASPRCDAT->PARAM_VALUE, sizeof(CEDCLOTDAT.PARAM_VALUE));
	CEDCLOTDAT.TYPE_FLAG = MGCMLAGDAT.DATA_3[0];
	memcpy(CEDCLOTDAT.CREATE_TIME, CRASPRCDAT->CREATE_TIME, sizeof(CEDCLOTDAT.CREATE_TIME));

	CDB_insert_cedclotdat(&CEDCLOTDAT);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

    return MP_TRUE;
}

/*******************************************************************************
    STOPWATCH_START()
        - Process start time log write function
    Return Value
        - clock_t
*******************************************************************************/
clock_t STOPWATCH_START()
{
	clock_t start_time;
	start_time = clock();
	return start_time;
}

/*******************************************************************************
    STOPWATCH_END()
        - Process end time log write function
    Return Value
        - void
	Arguments
	- char *s_id : Log message name 
	- clock_t : start time clock_t
*******************************************************************************/
void STOPWATCH_END(char *s_id,	clock_t  start_time)
{
	clock_t end_time;
	float res;
	char  msg[200];

	end_time = clock();
	res = (float)(end_time - start_time) / CLOCKS_PER_SEC;

	sprintf(msg,"ID:%s,%f",s_id,res);

	LOG_head("STOPWATCH_END");
	LOG_add("STOPWATCH ESTIMATE : ", MP_NSTR,msg); 
	COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

}

/*******************************************************************************
CUS_COM_BATCHPROCESS_STATUS_UPDATE()
- Get Data of Lot Extension by Column Names
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- char *s_msg_code  : Error Message Code
- in_node *Cmn_Out: Input Message structure   
- out_node *Cmn_Out: Output Message structure   
*******************************************************************************/
int CUS_COM_BATCHPROCESS_STATUS_UPDATE(char cStep, TRSNode *in_node, TRSNode *out_node)
{
	struct CTMPBATSTS_TAG CTMPBATSTS;

	char s_sys_time[14];
	
	memset(s_sys_time, 0x00, sizeof(s_sys_time));
    DB_get_systime(s_sys_time);

	CDB_init_ctmpbatsts(&CTMPBATSTS);
    TRS.copy(CTMPBATSTS.JOB_PROC_ID, sizeof(CTMPBATSTS.JOB_PROC_ID), in_node, "JOB_PROC_ID");

	if (cStep == 'S')
	{
		CDB_select_ctmpbatsts_for_update(1, &CTMPBATSTS);

		if(CTMPBATSTS.STATUS_FLAG == 'S')
			return MP_FALSE;

		memcpy(CTMPBATSTS.START_TIME, s_sys_time, sizeof(CTMPBATSTS.START_TIME));
		CTMPBATSTS.STATUS_FLAG = 'S';

		memset(CTMPBATSTS.END_TIME, ' ', sizeof(CTMPBATSTS.END_TIME));
		CTMPBATSTS.ELAPSED_TIME = 0;

		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_insert_ctmpbatsts(&CTMPBATSTS);
		}
		else
		{
			CDB_update_ctmpbatsts(1, &CTMPBATSTS);
		}
	}
	else if (cStep == 'E')
	{
		CDB_select_ctmpbatsts_for_update(1, &CTMPBATSTS);
		if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS) 
		{
			DB_commit();

			return MP_TRUE;
		}

		memcpy(CTMPBATSTS.END_TIME, s_sys_time, sizeof(CTMPBATSTS.END_TIME));
		CTMPBATSTS.ELAPSED_TIME = COM_interval_millisec(CTMPBATSTS.START_TIME);

		CTMPBATSTS.STATUS_FLAG = 'E';

		CDB_update_ctmpbatsts(1, &CTMPBATSTS);
	}

    DB_commit();

    return MP_TRUE;
}


/*******************************************************************************
	CWIP_update_lot_unstore()
		- Main sub function of "CWIP_update_lot_unstore" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_LOT_UNSTORE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node, struct MWIPLOTSTS_TAG *MWIPLOTSTS)
{
	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	/* UNSTORE Lot */
	tran_in_node = TRS.create_node("UNSTORE_LOT_IN");
	tran_out_node = TRS.create_node("UNSTORE_LOT_OUT");

	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');  
	TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS->FACTORY, sizeof(MWIPLOTSTS->FACTORY));
	TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS->LOT_ID, sizeof(MWIPLOTSTS->LOT_ID));
	TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS->MAT_ID, sizeof(MWIPLOTSTS->MAT_ID)); 
	//TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS->OPER, sizeof(MWIPLOTSTS->OPER)); 
	TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS->MAT_ID, sizeof(MWIPLOTSTS->MAT_ID));
	
	if (TRS.get_char(in_node, "PACK_FLAG") == HQCEL_FLAG_YES)
	{
		TRS.set_string(in_node, "OPER", HQCEL_M1_PACKING_OPER, strlen(HQCEL_M1_PACKING_OPER));
	}
	else
	{
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS->OPER, sizeof(MWIPLOTSTS->OPER));
	}

	if(COM_isnullspace(MWIPLOTSTS->STR_RET_FLOW) == MP_TRUE) 
	{
		TRS.add_string(tran_in_node,  "TO_FLOW", HQCEL_M1_FLOW_MDP100, strlen(HQCEL_M1_FLOW_MDP100));	
	}else{
		TRS.add_string(tran_in_node,  "TO_FLOW", MWIPLOTSTS->STR_RET_FLOW, sizeof(MWIPLOTSTS->STR_RET_FLOW));	
	}
	
	if(memcmp(MWIPLOTSTS->STR_RET_OPER, TRS.get_string(in_node, "OPER"), sizeof(MWIPLOTSTS->STR_RET_OPER)))
	{
		memcpy(MWIPLOTSTS->STR_RET_OPER, TRS.get_string(in_node, "OPER"), sizeof(MWIPLOTSTS->STR_RET_OPER));
		DBC_update_mwiplotsts(1, MWIPLOTSTS);
	}
	TRS.add_string(tran_in_node, "TO_OPER", MWIPLOTSTS->STR_RET_OPER, sizeof(MWIPLOTSTS->STR_RET_OPER));


	if(WIP_UNSTORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
		//DO NOTHING
		TRS.free_node(tran_in_node); //[ERP 23.05.23] Free Node
		TRS.free_node(tran_out_node);
		return MP_FALSE;
	}

	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);
	return MP_TRUE;
}