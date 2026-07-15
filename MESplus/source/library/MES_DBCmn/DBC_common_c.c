/* Add by J.S. 2011.11.25 */
#include <stdio.h>
#include <string.h>
#include <memory.h>
#include <stdlib.h>
#include <time.h>

/*
extern void LOG_head(const char *head);
extern void LOG_add(const char *title, const int type, ...);
extern void COM_log_write( char c_log_type, 
                           char c_log_error_type, 
                           char c_log_category);
*/

extern char gc_DB_DST_time_compress;
extern char gs_DB_DST_end_time[20];
extern char gs_DB_DST_end_time_hour[14]; /* DST End date time of this year - 1 hour */
extern char gs_DB_DST_end_time_year[14]; /* DST End date time of this year */
extern char gs_DB_time_zone_offset[6]; /* time zone +0000 */

int DB_add_time_sec_week(char *d_time_p, int *i_wday, char *s_time_p, int second);

#define DB_TRUE                 1
#define DB_FALSE                0

/* Add by J.S. 2011.11.25 for DST */
/*******************************************************************************
    DB_set_DST_option()
        - Set DST option
    Return Value
        - None
    Arguments
        - Use time compress, DST end time
*******************************************************************************/
void DB_set_DST_option(char c_DST_time_compress, char *s_DST_end_time, char *s_offset)
{
	gc_DB_DST_time_compress = c_DST_time_compress;
	memset(gs_DB_DST_end_time, ' ', sizeof(gs_DB_DST_end_time));
	memset(gs_DB_DST_end_time_hour, ' ', sizeof(gs_DB_DST_end_time_hour)); /* YYYYMMDDhhmmss */
	memset(gs_DB_DST_end_time_year, ' ', sizeof(gs_DB_DST_end_time_year)); /* YYYYMMDDhhmmss */
	if(gc_DB_DST_time_compress == 'Y')
	{
		memcpy(gs_DB_DST_end_time, s_DST_end_time, sizeof(gs_DB_DST_end_time)); /* MMLAST  MON 03 */
	}
	memcpy(gs_DB_time_zone_offset, s_offset, sizeof(gs_DB_time_zone_offset));
}

/*******************************************************************************
    DB_time_compress()
        - Calulate compressed time
    Return Value
        - None
    Arguments
        - current time
*******************************************************************************/
int DB_time_compress(char *s_currnet_time, char *s_offset, char *s_msec)
{
	char s_temp_time[14];
	char s_start_time[14];
	char s_last_time[14];
	char s_base_time[14];
	char s_temp[20];
	int  i_th;
	int  i_week;
	int  i_c_th;
	int  i_c_week;
	int  i_pass_sec;
	int  i;
	long i_pass_msec;
	char s_temp_msec[7];

	/*
    LOG_head("DB_time_compress");
    LOG_add("currenttime", 4, 14, s_currnet_time);
    LOG_add("offset", 4, 5, s_offset);
    LOG_add("s_msec", 4, 6, s_msec);
    COM_log_write('I', 'L', 'V');
	*/
	
	/* DST Time compress를 사용하지 않으면 바로 return */
	if(gc_DB_DST_time_compress  != 'Y')
	{
		return DB_TRUE;
	}

	/*현재 시간과 올해 DST END 시간의 연도가 다르면 홀해 DST END 시간을 새로 계산한다*/
	if(memcmp(s_currnet_time, gs_DB_DST_end_time_year, 4) != 0)
	{
		memset(s_start_time, ' ', sizeof(s_start_time));
		memcpy(s_start_time, s_currnet_time, 4); /* year */
		memcpy(s_start_time + 4, gs_DB_DST_end_time, 2); /* month */
		memcpy(s_start_time + 6, "0101060000", strlen("0101060000"));

		if(memcmp(gs_DB_DST_end_time + 3, "FIRST ", 6) == 0)
			i_th = 0;
	    else if(memcmp(gs_DB_DST_end_time + 3, "SECOND", 6) == 0)
			i_th = 1;
	    else if(memcmp(gs_DB_DST_end_time + 3, "THIRD ", 6) == 0)
			i_th = 2;
	    else if(memcmp(gs_DB_DST_end_time + 3, "FOURTH", 6) == 0)
			i_th = 3;
	    else if(memcmp(gs_DB_DST_end_time + 3, "LAST  ", 6) == 0)
			i_th = -1;
		else
			return -1;

		if(memcmp(gs_DB_DST_end_time + 10, "SUN", 3) == 0)
			i_week = 0;
		else if(memcmp(gs_DB_DST_end_time + 10, "MON", 3) == 0)
			i_week = 1;
		else if(memcmp(gs_DB_DST_end_time + 10, "TUE", 3) == 0)
			i_week = 2;
		else if(memcmp(gs_DB_DST_end_time + 10, "WED", 3) == 0)
			i_week = 3;
		else if(memcmp(gs_DB_DST_end_time + 10, "THU", 3) == 0)
			i_week = 4;
		else if(memcmp(gs_DB_DST_end_time + 10, "FRI", 3) == 0)
			i_week = 5;
		else if(memcmp(gs_DB_DST_end_time + 10, "SAT", 3) == 0)
			i_week = 6;			
		else
			return -2;

		i_c_th = 0;
		for( i = 0 ; i < 31 ; i++ )
		{
			if(DB_add_time_sec_week(s_temp_time, &i_c_week, s_start_time, 3600 * 24 * i ) == DB_FALSE)
			{
				return -3;
			}

			if(memcmp(s_start_time, s_temp_time, 6) != 0) /* 달이 바뀌면 */
			{
				return -4;
			}

			if(i_c_th == i_th && i_c_week ==  i_week) /* 찾은 경우 */
			{
				break;
			}

			if(i_c_week ==  i_week)
			{
				i_c_th++;
				memcpy(s_last_time, s_temp_time, sizeof(s_last_time)); /* LAST */
			}
		}

		if(i_th != -1)
		{
			memcpy(gs_DB_DST_end_time_year, s_temp_time, 8);
		}
		else
		{
			memcpy(gs_DB_DST_end_time_year, s_last_time, 8);
		}
		memcpy(gs_DB_DST_end_time_year + 8, gs_DB_DST_end_time + 14, 2); /* copy hour */
		memcpy(gs_DB_DST_end_time_year + 10, "0000", 4); /* copy min,sec */

		if(DB_add_time_sec_week(gs_DB_DST_end_time_hour, &i_c_week, gs_DB_DST_end_time_year, -3600) != DB_TRUE)
		{
			return -5;
		}

		/*
		LOG_head("DB_time_compress");
		LOG_add("gs_DB_DST_end_time_hour", 4, 14, gs_DB_DST_end_time_hour);
		LOG_add("gs_DB_DST_end_time_year", 4, 14, gs_DB_DST_end_time_year);
		COM_log_write('I', 'L', 'V');
		*/
	}

	if(memcmp(s_currnet_time, gs_DB_DST_end_time_hour, sizeof(gs_DB_DST_end_time_hour)) >= 0 &&
	   memcmp(s_currnet_time, gs_DB_DST_end_time_year, sizeof(gs_DB_DST_end_time_year)) < 0)
	{
		memset(s_temp, 0x0, sizeof(s_temp));
		memcpy(s_temp, s_currnet_time + 10, 2); 
		i_pass_sec = atoi(s_temp) * 60;

		memset(s_temp, 0x0, sizeof(s_temp));
		memcpy(s_temp, s_currnet_time + 12, 2); 
		i_pass_sec = i_pass_sec + atoi(s_temp);

		/* msec 계산 */
		if((i_pass_sec % 2) == 0)
		{
			memset(s_temp, 0x0, sizeof(s_temp));
			memcpy(s_temp, s_msec, 6);
			i_pass_msec = atol(s_temp);
		}
		else
		{
			memset(s_temp, 0x0, sizeof(s_temp));
			memcpy(s_temp, s_msec, 6);
			i_pass_msec = atol(s_temp);
			i_pass_msec = i_pass_msec + 1000000;
		}
		i_pass_msec = (long)(i_pass_msec/2);
		sprintf(s_temp_msec, "%06ld", i_pass_msec);
		memcpy(s_msec, s_temp_msec, 6);

		i_pass_sec = (int)(i_pass_sec / 2);


		if(memcmp(gs_DB_time_zone_offset, s_offset, 5) != 0) //use dst
		{
			memcpy(s_base_time, s_currnet_time, 10);
			memcpy(s_base_time + 10, "0000", strlen("0000")); /* XX:00:00 ~ XX:29:59 */

			/*
			LOG_head("DB_time_compress");
			LOG_add("s_base_time_1", 4, 14, s_base_time);
			LOG_add("gs_DB_time_zone_offset", 4, 5, gs_DB_time_zone_offset);
			LOG_add("s_offset", 4, 5, s_offset);
			COM_log_write('I', 'L', 'V');
			*/
		}
		else
		{
			memcpy(s_base_time, s_currnet_time, 10);
			memcpy(s_base_time + 10, "3000", strlen("3000")); /* XX:30:00 ~ XX:59:59 */

			/*
			LOG_head("DB_time_compress");
			LOG_add("s_base_time_2", 4, 14, s_base_time);
			LOG_add("gs_DB_time_zone_offset", 4, 5, gs_DB_time_zone_offset);
			LOG_add("s_offset", 4, 5, s_offset);
			COM_log_write('I', 'L', 'V');
			*/
		}

		if(DB_add_time_sec_week(s_currnet_time, &i_c_week, s_base_time, i_pass_sec) !=  DB_TRUE)
		{
			return -6;
		}

		/*
		LOG_head("DB_time_compress");
		LOG_add("s_currnet_time_final", 4, 14, s_currnet_time);
		LOG_add("s_msec_final", 4, 6, s_msec);
		COM_log_write('I', 'L', 'V');
		*/
	}

	return DB_TRUE;
}

/*******************************************************************************
    DB_add_time_sec_week()
        - Add seconds to date-time string
    Return Value
        - int : MP_TRUE or MP_FALSE
    Arguments
        - char *d_time_p : target date time string
        - char *s_time_p : source date time string
        - int second : time to be added to source date time
*******************************************************************************/
int DB_add_time_sec_week(char *d_time_p, int *i_wday, char *s_time_p, int second)
{
	struct tm from_stt;
	time_t from_i;
	int t_i32;
	int year_i32, mon_i32, day_i32;
	int hour_i32, min_i32, sec_i32;
	int f_date_f32, f_time_f32;
	char s_temp_time[14+1];
	char s_temp[20];

    /* Make Time Structure */
	memset(s_temp, 0x0, sizeof(s_temp));
	memcpy(s_temp, s_time_p, 8);
    f_date_f32 = atoi(s_temp);

	memset(s_temp, 0x0, sizeof(s_temp));
	memcpy(s_temp, s_time_p + 8, 6);
    f_time_f32 = atoi(s_temp);

    t_i32 = f_date_f32; 
    from_stt.tm_year = (t_i32 / 10000) - 1900;
    t_i32 = t_i32 - (from_stt.tm_year + 1900) * 10000;
    from_stt.tm_mon = (t_i32 / 100) - 1;
    t_i32 = t_i32 - (from_stt.tm_mon + 1) * 100;
    from_stt.tm_mday = t_i32;

    t_i32 = f_time_f32; 
    from_stt.tm_hour = (t_i32 / 10000);
    t_i32 = t_i32 - from_stt.tm_hour * 10000;
    from_stt.tm_min = (t_i32 / 100);
    t_i32 = t_i32 - from_stt.tm_min * 100;
    from_stt.tm_sec = t_i32;

    from_stt.tm_isdst = 0;  /* set as not use */

    /* Add Second */
    from_stt.tm_sec = from_stt.tm_sec + second;

    /* Make Destination Date-Time String */
    if((from_i = mktime(&from_stt)) == (time_t)-1)
    {
        return DB_FALSE;
    }

    year_i32 = from_stt.tm_year + 1900;
    mon_i32 = from_stt.tm_mon + 1;
    day_i32 = from_stt.tm_mday;

    hour_i32 = from_stt.tm_hour;
    min_i32 = from_stt.tm_min;    
    sec_i32 = from_stt.tm_sec;

	*i_wday = from_stt.tm_wday;

    sprintf(s_temp_time, "%04d%02d%02d%02d%02d%02d", 
        year_i32, mon_i32, day_i32, hour_i32, min_i32, sec_i32);

    memcpy(d_time_p, s_temp_time, 14);

    return DB_TRUE;
}

/* End Add */
