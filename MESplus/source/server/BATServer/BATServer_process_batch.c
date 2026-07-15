#include <MESCore_common.h>
#include <MessageCaster.h>
#include "BATServer_common.h"

#if defined(WIN32) || defined(WIN64)
void MAIN_display_status(char *);
#endif

struct PROC_CYCLE_INFO
{
    unsigned short min[60];
    unsigned short hour[24];
    unsigned short day[31];
    unsigned short month[12];
    unsigned short week[7];
} PCI;

void init_proc_cycle_info()
{
    int i;

    for(i = 0; i < 60; i++)
    {
        PCI.min[i] = 0;
    }
    for(i = 0; i < 24; i++)
    {
        PCI.hour[i] = 0;
    }
    for(i = 0; i < 31; i++)
    {
        PCI.day[i] = 0;
    }
    for(i = 0; i < 12; i++)
    {
        PCI.month[i] = 0;
    }
    for(i = 0; i < 7; i++)
    {
        PCI.week[i] = 0;
    }
}

void parse_time_unit_info(char *s_proc_cycle, char c_unit_type)
{
    int  i, k;
    int  i_idx;
    int  i_data_flag;
    int  i_length;
    int  i_r_pos;
    int  i_d_pos;
    int  i_range_s;
    int  i_range_e;
    int  i_divid;

    char s_time_unit[31][100];
    int  i_unit_count;

    unsigned short *time_unit;
    int  i_time_unit_count;

    i_time_unit_count = 0;
    time_unit = 0x00;

    switch(c_unit_type)
    {
    case 'm':
        i_time_unit_count = 60; // 0 ~ 59
        time_unit = PCI.min;
        break;
    case 'H':
        i_time_unit_count = 24; // 0 ~ 23
        time_unit = PCI.hour;
        break;
    case 'D':
        i_time_unit_count = 31; // 1 ~ 31
        time_unit = PCI.day;
        break;
    case 'M':
        i_time_unit_count = 12; // 1 ~ 12
        time_unit = PCI.month;
        break;
    case 'W':
        i_time_unit_count = 7; // 1 ~ 7
        time_unit = PCI.week;
        break;
    }

    if(s_proc_cycle[0] == '*' && strlen(s_proc_cycle) == 1)
    {
        for(i = 0; i < i_time_unit_count; i++)
        {
            time_unit[i] = 1;
        }
    }
    else
    {
        memset(s_time_unit, 0x00, sizeof(s_time_unit));
        i_unit_count = 0;
        i_idx = 0;
        i_data_flag = 0;

        i_length = (int)strlen(s_proc_cycle);
        for(i = 0; i < i_length; i++)
        {
            if(s_proc_cycle[i] == ',')
            {
                if(i_data_flag == 0)
                {
                    continue;
                }

                i_unit_count++;
                i_idx = 0;
                i_data_flag = 0;
                continue;
            }

            s_time_unit[i_unit_count][i_idx++] = s_proc_cycle[i];
            i_data_flag = 1;
        }
        if(i_data_flag == 1)
        {
            i_unit_count++;
        }

        for(i = 0; i < i_unit_count; i++)
        {
            i_length = (int)strlen(s_time_unit[i]);
            i_r_pos = COM_search_string(s_time_unit[i], i_length, "-", 1);
            i_d_pos = COM_search_string(s_time_unit[i], i_length, "/", 1);

            if(i_r_pos < 0 && i_d_pos < 0)
            {// 5, 6, 12
                i_idx = COM_atoi(s_time_unit[i], i_length);
                if(c_unit_type == 'D' || c_unit_type == 'M' || c_unit_type == 'W')
                {
                    i_idx--;
                }
                time_unit[i_idx] = 1;
            }
            else if(i_r_pos > 0 && i_d_pos < 0)
            {// 5-8, 1-9
                i_range_s = COM_atoi(s_time_unit[i], i_r_pos);
                i_range_e = COM_atoi(s_time_unit[i] + i_r_pos + 1, i_length - i_r_pos - 1);

                if(c_unit_type == 'D' || c_unit_type == 'M' || c_unit_type == 'W')
                {
                    i_range_s--;
                    i_range_e--;
                }

                for(k = i_range_s; k <= i_range_e; k++)
                {
                    time_unit[k] = 1;
                }
            }
            else if(i_r_pos < 0 && i_d_pos > 0)
            {// */2, */3
                i_divid = COM_atoi(s_time_unit[i] + i_d_pos + 1, i_length - i_d_pos - 1);
                i_idx = 0;
                for(k = 0; k < i_time_unit_count; k++)
                {
                    if(i_idx == 0)
                    {
                        time_unit[k] = 1;
                    }
                    i_idx++;

                    if(i_idx == i_divid)
                    {
                        i_idx = 0;
                    }
                }
            }
            else if(i_r_pos > 0 && i_d_pos > 0)
            {// 5-8/2, 1-9/3
                i_range_s = COM_atoi(s_time_unit[i], i_r_pos);
                i_range_e = COM_atoi(s_time_unit[i] + i_r_pos + 1, i_d_pos - i_r_pos - 1);

                if(c_unit_type == 'D' || c_unit_type == 'M' || c_unit_type == 'W')
                {
                    i_range_s--;
                    i_range_e--;
                }

                i_divid = COM_atoi(s_time_unit[i] + i_d_pos + 1, i_length - i_d_pos - 1);
                i_idx = 0;
                for(k = i_range_s; k <= i_range_e; k++)
                {
                    if(i_idx == 0)
                    {
                        time_unit[k] = 1;
                    }
                    i_idx++;

                    if(i_idx == i_divid)
                    {
                        i_idx = 0;
                    }
                }
            }
        }
    }
}

void parse_proc_cycle_info(char *s_cycle)
{
    char s_proc_cycle[5][1000];
    int  i;
    int  i_idx;
    int  i_data_flag;

    memset(s_proc_cycle, 0x00, sizeof(s_proc_cycle));

    // Minute
    i_idx = 0;
    i_data_flag = 0;
    for(i = 0; i < 1000; i++)
    {
        if(s_cycle[i] == ' ')
        {
            if(i_data_flag == 0)
            {
                continue;
            }

            break;
        }
        s_proc_cycle[0][i_idx++] = s_cycle[i];
        i_data_flag = 1;
    }

    // Hour
    i_idx = 0;
    i_data_flag = 0;
    for(; i < 1000; i++)
    {
        if(s_cycle[i] == ' ')
        {
            if(i_data_flag == 0)
            {
                continue;
            }

            break;
        }
        s_proc_cycle[1][i_idx++] = s_cycle[i];
        i_data_flag = 1;
    }

    // Day
    i_idx = 0;
    i_data_flag = 0;
    for(; i < 1000; i++)
    {
        if(s_cycle[i] == ' ')
        {
            if(i_data_flag == 0)
            {
                continue;
            }

            break;
        }
        s_proc_cycle[2][i_idx++] = s_cycle[i];
        i_data_flag = 1;
    }

    // Month
    i_idx = 0;
    i_data_flag = 0;
    for(; i < 1000; i++)
    {
        if(s_cycle[i] == ' ')
        {
            if(i_data_flag == 0)
            {
                continue;
            }

            break;
        }
        s_proc_cycle[3][i_idx++] = s_cycle[i];
        i_data_flag = 1;
    }

    // Week
    i_idx = 0;
    i_data_flag = 0;
    for(; i < 1000; i++)
    {
        if(s_cycle[i] == ' ' || s_cycle[i] == 0x00)
        {
            if(i_data_flag == 0)
            {
                continue;
            }

            break;
        }
        s_proc_cycle[4][i_idx++] = s_cycle[i];
        i_data_flag = 1;
    }

    parse_time_unit_info(s_proc_cycle[0], 'm');
    parse_time_unit_info(s_proc_cycle[1], 'H');
    parse_time_unit_info(s_proc_cycle[2], 'D');
    parse_time_unit_info(s_proc_cycle[3], 'M');
    parse_time_unit_info(s_proc_cycle[4], 'W');
}

/*******************************************************************************
    BAT_check_process_batch()
        - Check batch process and trigger service to running batch
    Return Value
        - int : MP_TRUE / MP_FALSE
    Arguments
        - 
*******************************************************************************/
int BAT_check_process_batch()
{
    char s_error_msg[MP_SIZE_FIELD_MSG];

    struct MBATPRCDEF_TAG MBATPRCDEF;
    struct MBATPRCSTS_TAG MBATPRCSTS;
    char s_sys_time[14];
    char c_sys_week;
    unsigned int i_idx;

    TRSNode *node;
    char s_module_name[31];
    char s_service_name[101];
	char s_channel_name[256];

    memset(s_error_msg, 0x00, MP_SIZE_FIELD_MSG);

    memset(s_sys_time, 0x00, sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        COM_get_message('1', "CMN-0003", s_error_msg);
        LOG_head("BAT_check_process_batch");
        LOG_add("DB_get_systime", MP_NVST);
        LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
        LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
        COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        return MP_FALSE;
    }
    c_sys_week = 0;
    DB_get_day_of_week(&c_sys_week);
    if(DB_error_code != DB_SUCCESS)
    {
        COM_get_message('1', "CMN-0003", s_error_msg);
        LOG_head("BAT_check_process_batch");
        LOG_add("DB_get_day_of_week", MP_NVST);
        LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
        LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
        COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        return MP_FALSE;
    }


    DBC_init_mbatprcdef(&MBATPRCDEF);
    MBATPRCDEF.ACTIVATE_FLAG = 'Y';
    memcpy(MBATPRCDEF.APPLY_START_TIME, s_sys_time, sizeof(MBATPRCDEF.APPLY_START_TIME));

    DBC_open_mbatprcdef(1, &MBATPRCDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        COM_get_message('1', "CMN-0003", s_error_msg);
        LOG_head("BAT_check_process_batch");
        LOG_add("table", MP_NSTR, "MBATPRCDEF OPEN");
        LOG_add("SYSTEM_TIME", MP_STR, sizeof(MBATPRCDEF.APPLY_START_TIME), MBATPRCDEF.APPLY_START_TIME);
        LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
        LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
        COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mbatprcdef(1, &MBATPRCDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mbatprcdef(1);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("BAT_check_process_batch");
            LOG_add("table", MP_NSTR, "MBATPRCDEF FETCH");
            LOG_add("SYSTEM_TIME", MP_STR, sizeof(MBATPRCDEF.APPLY_START_TIME), MBATPRCDEF.APPLY_START_TIME);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

            DBC_close_mbatprcdef(1);
            return MP_FALSE;
        }

        if(MBATPRCDEF.PROC_METHOD == 'S' && MBATPRCDEF.JOB_RUN_FLAG == 'Y')
        {
            DBC_init_mbatprcsts(&MBATPRCSTS);
            memcpy(MBATPRCSTS.JOB_PROC_ID, MBATPRCDEF.JOB_PROC_ID, sizeof(MBATPRCSTS.JOB_PROC_ID));
            MBATPRCSTS.STATUS_FLAG = 'P';
            DBC_select_mbatprcsts(3, &MBATPRCSTS);
            if(DB_error_code == DB_SUCCESS) 
            {
                int    i_last_proc_time;
                double d_avg_elapsed_time;

                i_last_proc_time = 0;
                d_avg_elapsed_time = 0;

                COM_diff_time_sec(&i_last_proc_time, s_sys_time, MBATPRCSTS.START_TIME);

                MBATPRCSTS.STATUS_FLAG = 'S';
                d_avg_elapsed_time = DBC_select_mbatprcsts_scalar(3, &MBATPRCSTS);

                /*
                    Job 이 실행한 마지막 시간 이후의 경과 시간이 평균 처리시간 + 1분 이내라면
                    아직 다른 프로세스가 처리중이라고 판단함.
                    만약 평균 처리시간 + 1분을 초과하면 다른 프로세스에 뭔가 문제가 발생하여 처리 종료를 실행하지 못한 것이라 판단.
                */
                if(i_last_proc_time < (d_avg_elapsed_time + (60 * 1)) )
                {
                    continue;
                }
            }
        }//end if

        init_proc_cycle_info();

		//Process Cycle  --> allways process
		if (memcmp(MBATPRCDEF.PROC_CYCLE, "ALWAYS", strlen("ALWAYS")) == 0)
		{
			// Process at each one minute always
		}
		else 
		{
            parse_proc_cycle_info(MBATPRCDEF.PROC_CYCLE);
            i_idx = COM_atoi(s_sys_time + 4, 2);  if(PCI.month[i_idx - 1] == 0) continue;
            i_idx = COM_atoi(s_sys_time + 6, 2);  if(PCI.day[i_idx - 1] == 0) continue;
            i_idx = COM_atoi(s_sys_time + 8, 2);  if(PCI.hour[i_idx] == 0) continue;
            i_idx = COM_atoi(s_sys_time + 10, 2); if(PCI.min[i_idx] == 0) continue;
            i_idx = c_sys_week - 49;              if(PCI.week[i_idx] == 0) continue;
		}

		memset(s_module_name, 0x00, sizeof(s_module_name));
        memset(s_service_name, 0x00, sizeof(s_service_name));
		memset(s_channel_name, 0x00, sizeof(s_channel_name));

        COM_memcpy_add_null(s_module_name, MBATPRCDEF.SERVICE_MODULE, sizeof(MBATPRCDEF.SERVICE_MODULE));
        COM_memcpy_add_null(s_service_name, MBATPRCDEF.SERVICE_NAME, sizeof(MBATPRCDEF.SERVICE_NAME));
		COM_memcpy_add_null(s_channel_name, MBATPRCDEF.MES_CHANNEL, 255);
		
		if (COM_isspace(MBATPRCDEF.MES_CHANNEL, sizeof(MBATPRCDEF.MES_CHANNEL)) == MP_TRUE)
		{
			//BAT Process Check! (BATCH SERVER 여러개를 운영)
            DBC_init_mbatprcsts(&MBATPRCSTS);
            memcpy(MBATPRCSTS.JOB_PROC_ID, MBATPRCDEF.JOB_PROC_ID, sizeof(MBATPRCSTS.JOB_PROC_ID));
            MBATPRCSTS.STATUS_FLAG = 'P';
    
            i_idx = (int)DBC_select_mbatprcsts_scalar(2, &MBATPRCSTS);
            if(DB_error_code != DB_SUCCESS) 
            {
                COM_get_message('1', "CMN-0003", s_error_msg);
                LOG_head("BAT_check_process_batch");
                LOG_add("table", MP_NSTR, "MBATPRCSTS SELECT SCALAR");
                LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCSTS.JOB_PROC_ID), MBATPRCSTS.JOB_PROC_ID);
                LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
                LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
                COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
    
                DBC_close_mbatprcdef(1);
                return MP_FALSE;
            }
            if(i_idx >= gi_batch_server_count) continue;

			//set batch server channel
			strcpy(s_channel_name, gs_main_channel);
		}

        node = TRS.create_node("BATSERVER_IN");
		TRS.add_string(node, "JOB_PROC_ID", MBATPRCDEF.JOB_PROC_ID, sizeof(MBATPRCDEF.JOB_PROC_ID));
		TRS.set_char(node, IN_LANGUAGE, '1');
		TRS.set_nstring(node, IN_USERID, MP_BATSERVER_USER);

        if(CallService(s_module_name, 
                       s_service_name, 
                       node, 
                       0x00, 
                       s_channel_name, 
                       gi_default_ttl, 
                       DM_UNICAST) != MP_TRUE)
        {
            DBC_close_mbatprcdef(1);
            TRS.free_node(node);
            return MP_FALSE;
        }
        TRS.free_node(node);

        LOG_head("Trigger Batch Process...");
        LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCDEF.JOB_PROC_ID), MBATPRCDEF.JOB_PROC_ID);
        LOG_add("MODULE_NAME", MP_NSTR, s_module_name);
        LOG_add("SERVICE_NAME", MP_NSTR, s_service_name);
        LOG_add("CHANNEL", MP_NSTR, s_channel_name);
        COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

#if defined(WIN32) || defined(WIN64)
        {
            char s_win_msg[200];

            sprintf(s_win_msg, "<:%s", s_service_name);
            MAIN_display_status(s_win_msg);
        }
#endif
    }//end while
    
    return MP_TRUE;
}
