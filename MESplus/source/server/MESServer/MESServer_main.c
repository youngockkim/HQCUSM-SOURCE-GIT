/*******************************************************************************

    System      : MESplus
    Module      : MESServer.exe
    File Name   : MESServer_main.c
    Description : MESplus Main Application Server

    MES Version : 5.1.0

    Entry Point           : None
    Input Parameters      : None
        + Server No.

    Exit Values           : None

    Input Files           : None
        + Common INI File - MESplus.ini
        + Server INI File - MESServer.ini

    Output Files          :
        + MESServer.exe

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/11/09  Aiden          Create

    Copyright(C) 1998-2009 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#define MESServerVersion        "MES_V5.3.7"

char s_app_name[30];

#if defined(WIN32) || defined(WIN64)
#include <windows.h>
#include "resource.h"
#endif

#include <COMCore_defines.h>
#include <MANCore_common.h>
#include <MESCore_common.h>
#include <CUS_common.h>

/*******************************************************************************
    initialize_server()
        - Initialize Server
    Return Value
        - int : TRUE or FALSE
    Arguments
        - 
*******************************************************************************/
int initialize_server()
{
    memset(gs_server_version, 0x00, sizeof(gs_server_version));
    strcpy(gs_server_version, MESServerVersion);

    if(MAIN_initialize_server(s_app_name) == MP_FALSE)
        return MP_FALSE;

    return MP_TRUE;
}

/*******************************************************************************
    Windows MES Server Code
*******************************************************************************/
#if defined(WIN32) || defined(WIN64)

/* Function Prototype */
int  WinInitApplication(HINSTANCE hInst);
void WinInitInstance(HINSTANCE hInst);
LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);

/*******************************************************************************
    WinMain()
        - Main Function
    Return Value
        - int : MSG.wParam
    Arguments
        - HINSTANCE hInstance : Handle to an instance, Instance of itself
        - HINSTANCE hInstance : Handle to an instance, Instance of Prev Window
        - LPSTR lpszCmdLine : Command-Line argument
        - int nCmdShow : Show Style
*******************************************************************************/

//void gen_sql_3(char *s_sql)
//{
//    sprintf(s_sql, "SELECT LOT_ID, HIST_SEQ, TRAN_TIME, SYS_TRAN_TIME, TRAN_CODE, LOT_DESC, FACTORY, MAT_ID, MAT_VER, FLOW, FLOW_SEQ_NUM, OPER,QTY_1, QTY_2, QTY_3, CRR_ID, LOT_TYPE, OWNER_CODE, CREATE_CODE, LOT_PRIORITY, LOT_STATUS, HOLD_FLAG, HOLD_CODE, HOLD_PASSWORD, HOLD_PRV_GRP_ID, OPER_IN_QTY_1, OPER_IN_QTY_2, OPER_IN_QTY_3, CREATE_QTY_1, ");
//    sprintf(s_sql + strlen(s_sql), "CREATE_QTY_2, CREATE_QTY_3, START_QTY_1, START_QTY_2, START_QTY_3, INV_FLAG, TRANSIT_FLAG, UNIT_EXIST_FLAG, INV_UNIT, RWK_FLAG, RWK_CODE, RWK_COUNT, RWK_RET_FLOW, RWK_RET_FLOW_SEQ_NUM, RWK_RET_OPER, RWK_END_FLOW, RWK_END_FLOW_SEQ_NUM, RWK_END_OPER, RWK_RET_CLEAR_FLAG, RWK_TIME, NSTD_FLAG, NSTD_RET_FLOW, NSTD_RET_FLOW_SEQ_NUM, NSTD_RET_OPER, NSTD_TIME, REP_FLAG,REP_RET_OPER, ");
//    sprintf(s_sql + strlen(s_sql), "STR_RET_FLOW, STR_RET_FLOW_SEQ_NUM, STR_RET_OPER, START_FLAG, START_TIME, START_RES_ID, END_FLAG, END_TIME, END_RES_ID, SAMPLE_FLAG, SAMPLE_WAIT_FLAG, SAMPLE_RESULT, FROM_TO_FLAG, FROM_TO_LOT_ID, SHIP_CODE, SHIP_TIME, ORG_DUE_TIME, SCH_DUE_TIME, CREATE_TIME, FAC_IN_TIME, FLOW_IN_TIME, OPER_IN_TIME, RESERVE_RES_ID, PORT_ID, BATCH_ID, BATCH_SEQ, ORDER_ID,ADD_ORDER_ID_1, ");
//    sprintf(s_sql + strlen(s_sql), "ADD_ORDER_ID_2, ADD_ORDER_ID_3, LOT_LOCATION_1, LOT_LOCATION_2, LOT_LOCATION_3, LOT_CMF_1, LOT_CMF_2, LOT_CMF_3, LOT_CMF_4, LOT_CMF_5, LOT_CMF_6, LOT_CMF_7, LOT_CMF_8, LOT_CMF_9, LOT_CMF_10, LOT_CMF_11, LOT_CMF_12, LOT_CMF_13, LOT_CMF_14, LOT_CMF_15, LOT_CMF_16, LOT_CMF_17, LOT_CMF_18, LOT_CMF_19, LOT_CMF_20, LOT_DEL_FLAG, LOT_DEL_CODE, LOT_DEL_TIME, ");
//    sprintf(s_sql + strlen(s_sql), "BOM_SET_ID, BOM_SET_VERSION, BOM_ACTIVE_HIST_SEQ, BOM_HIST_SEQ, CRITICAL_RES_ID, CRITICAL_RES_GROUP_ID, SAVE_RES_ID_1, SAVE_RES_ID_2, SUBRES_ID, LOT_GROUP_ID_1, LOT_GROUP_ID_2, LOT_GROUP_ID_3, YIELD_1, YIELD_2, YIELD_3, GOOD_QTY, RESV_FIELD_1, RESV_FIELD_2, RESV_FIELD_3, RESV_FIELD_4, RESV_FIELD_5, RESV_FLAG_1, RESV_FLAG_2, RESV_FLAG_3, RESV_FLAG_4, RESV_FLAG_5, FROM_TO_MAT_ID, ");
//    sprintf(s_sql + strlen(s_sql), "FROM_TO_MAT_VER, FROM_TO_FLOW, FROM_TO_FLOW_SEQ_NUM, FROM_TO_OPER, FROM_TO_QTY_1, FROM_TO_QTY_2, FROM_TO_QTY_3, FROM_TO_HIST_SEQ, OLD_FACTORY, OLD_MAT_ID, OLD_MAT_VER, OLD_FLOW, OLD_FLOW_SEQ_NUM, OLD_OPER, OLD_QTY_1, OLD_QTY_2, OLD_QTY_3, OLD_LOT_TYPE, OLD_OWNER_CODE, OLD_CREATE_CODE, OLD_FAC_IN_TIME, OLD_FLOW_IN_TIME, OLD_OPER_IN_TIME, TRAN_CMF_1, TRAN_CMF_2, TRAN_CMF_3, TRAN_CMF_4, ");
//    sprintf(s_sql + strlen(s_sql), "TRAN_CMF_5, TRAN_CMF_6, TRAN_CMF_7, TRAN_CMF_8, TRAN_CMF_9, TRAN_CMF_10, TRAN_CMF_11, TRAN_CMF_12, TRAN_CMF_13, TRAN_CMF_14, TRAN_CMF_15, TRAN_CMF_16, TRAN_CMF_17, TRAN_CMF_18, TRAN_CMF_19, TRAN_CMF_20, TRAN_USER_ID, TRAN_COMMENT, PREV_ACTIVE_HIST_SEQ, MULTI_TR_KEY, MULTI_TR_SEQ, EXT_HIST_SEQ, HIST_DEL_FLAG, HIST_DEL_TIME, HIST_DEL_USER_ID, HIST_DEL_COMMENT ");
//    sprintf(s_sql + strlen(s_sql), "FROM MWIPLOTHIS WHERE LOT_ID = 'Y007T' AND HIST_SEQ = 1 ");
//}
//
//void gen_sql_2(char *s_sql)
//{
//    sprintf(s_sql, "UNION ALL SELECT LOT_ID, HIST_SEQ, TRAN_TIME, SYS_TRAN_TIME, TRAN_CODE, LOT_DESC, FACTORY, MAT_ID, MAT_VER, FLOW, FLOW_SEQ_NUM, OPER,QTY_1, QTY_2, QTY_3, CRR_ID, LOT_TYPE, OWNER_CODE, CREATE_CODE, LOT_PRIORITY, LOT_STATUS, HOLD_FLAG, HOLD_CODE, HOLD_PASSWORD, HOLD_PRV_GRP_ID, OPER_IN_QTY_1, OPER_IN_QTY_2, OPER_IN_QTY_3, CREATE_QTY_1, ");
//    sprintf(s_sql + strlen(s_sql), "CREATE_QTY_2, CREATE_QTY_3, START_QTY_1, START_QTY_2, START_QTY_3, INV_FLAG, TRANSIT_FLAG, UNIT_EXIST_FLAG, INV_UNIT, RWK_FLAG, RWK_CODE, RWK_COUNT, RWK_RET_FLOW, RWK_RET_FLOW_SEQ_NUM, RWK_RET_OPER, RWK_END_FLOW, RWK_END_FLOW_SEQ_NUM, RWK_END_OPER, RWK_RET_CLEAR_FLAG, RWK_TIME, NSTD_FLAG, NSTD_RET_FLOW, NSTD_RET_FLOW_SEQ_NUM, NSTD_RET_OPER, NSTD_TIME, REP_FLAG,REP_RET_OPER, ");
//    sprintf(s_sql + strlen(s_sql), "STR_RET_FLOW, STR_RET_FLOW_SEQ_NUM, STR_RET_OPER, START_FLAG, START_TIME, START_RES_ID, END_FLAG, END_TIME, END_RES_ID, SAMPLE_FLAG, SAMPLE_WAIT_FLAG, SAMPLE_RESULT, FROM_TO_FLAG, FROM_TO_LOT_ID, SHIP_CODE, SHIP_TIME, ORG_DUE_TIME, SCH_DUE_TIME, CREATE_TIME, FAC_IN_TIME, FLOW_IN_TIME, OPER_IN_TIME, RESERVE_RES_ID, PORT_ID, BATCH_ID, BATCH_SEQ, ORDER_ID,ADD_ORDER_ID_1, ");
//    sprintf(s_sql + strlen(s_sql), "ADD_ORDER_ID_2, ADD_ORDER_ID_3, LOT_LOCATION_1, LOT_LOCATION_2, LOT_LOCATION_3, LOT_CMF_1, LOT_CMF_2, LOT_CMF_3, LOT_CMF_4, LOT_CMF_5, LOT_CMF_6, LOT_CMF_7, LOT_CMF_8, LOT_CMF_9, LOT_CMF_10, LOT_CMF_11, LOT_CMF_12, LOT_CMF_13, LOT_CMF_14, LOT_CMF_15, LOT_CMF_16, LOT_CMF_17, LOT_CMF_18, LOT_CMF_19, LOT_CMF_20, LOT_DEL_FLAG, LOT_DEL_CODE, LOT_DEL_TIME, ");
//    sprintf(s_sql + strlen(s_sql), "BOM_SET_ID, BOM_SET_VERSION, BOM_ACTIVE_HIST_SEQ, BOM_HIST_SEQ, CRITICAL_RES_ID, CRITICAL_RES_GROUP_ID, SAVE_RES_ID_1, SAVE_RES_ID_2, SUBRES_ID, LOT_GROUP_ID_1, LOT_GROUP_ID_2, LOT_GROUP_ID_3, YIELD_1, YIELD_2, YIELD_3, GOOD_QTY, RESV_FIELD_1, RESV_FIELD_2, RESV_FIELD_3, RESV_FIELD_4, RESV_FIELD_5, RESV_FLAG_1, RESV_FLAG_2, RESV_FLAG_3, RESV_FLAG_4, RESV_FLAG_5, FROM_TO_MAT_ID, ");
//    sprintf(s_sql + strlen(s_sql), "FROM_TO_MAT_VER, FROM_TO_FLOW, FROM_TO_FLOW_SEQ_NUM, FROM_TO_OPER, FROM_TO_QTY_1, FROM_TO_QTY_2, FROM_TO_QTY_3, FROM_TO_HIST_SEQ, OLD_FACTORY, OLD_MAT_ID, OLD_MAT_VER, OLD_FLOW, OLD_FLOW_SEQ_NUM, OLD_OPER, OLD_QTY_1, OLD_QTY_2, OLD_QTY_3, OLD_LOT_TYPE, OLD_OWNER_CODE, OLD_CREATE_CODE, OLD_FAC_IN_TIME, OLD_FLOW_IN_TIME, OLD_OPER_IN_TIME, TRAN_CMF_1, TRAN_CMF_2, TRAN_CMF_3, TRAN_CMF_4, ");
//    sprintf(s_sql + strlen(s_sql), "TRAN_CMF_5, TRAN_CMF_6, TRAN_CMF_7, TRAN_CMF_8, TRAN_CMF_9, TRAN_CMF_10, TRAN_CMF_11, TRAN_CMF_12, TRAN_CMF_13, TRAN_CMF_14, TRAN_CMF_15, TRAN_CMF_16, TRAN_CMF_17, TRAN_CMF_18, TRAN_CMF_19, TRAN_CMF_20, TRAN_USER_ID, TRAN_COMMENT, PREV_ACTIVE_HIST_SEQ, MULTI_TR_KEY, MULTI_TR_SEQ, EXT_HIST_SEQ, HIST_DEL_FLAG, HIST_DEL_TIME, HIST_DEL_USER_ID, HIST_DEL_COMMENT ");
//    sprintf(s_sql + strlen(s_sql), "FROM MWIPLOTHIS WHERE LOT_ID = 'Y007T' AND HIST_SEQ = 1 ");
//}
//
//void gen_sql(char *s_sql, int i_count, int b_add_null_flag)
//{
//    int i;
//    int i_pos = 0;
//    char s_tmp[10000];
//    char *sp_sql = s_sql;
//
//    gen_sql_3(s_tmp); i_pos = strlen(s_tmp); memcpy(sp_sql, s_tmp, i_pos);
//
//    for(i = 0; i < i_count; i++)
//    {
//        sp_sql = sp_sql + i_pos; gen_sql_2(s_tmp); i_pos = strlen(s_tmp); memcpy(sp_sql, s_tmp, i_pos);
//    }
//
//    if(b_add_null_flag == MP_TRUE)
//    {
//        sp_sql[i_pos] = 0x00;
//    }
//}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInstance, 
                   LPSTR lpszCmdLine, int nCmdShow)
{
    MSG msg;
    LPTSTR lpCmd;
    int i_pos = 0;
    int i_pos2 = 0;
    int i_count = 0;

    /* Get s_app_name */
    /* Get Application Name without extension(.exe). The value is used to find out INI File for the application */
    memset(s_app_name, '\0', sizeof(s_app_name));
    lpCmd = GetCommandLine();
    i_pos = (int)strlen(lpCmd);
    for (i_count = i_pos; i_count > 0; i_count--)
    {
        if(lpCmd[i_count] == '\\') 
        {
            break;
        }
        if(lpCmd[i_count] == '.') 
        {
            i_pos2 = i_count;
        }
    }
    if(i_count > 0)
    {
        memcpy(s_app_name, lpCmd + i_count + 1, i_pos2 - i_count - 1);
    }
    else
    {
        memcpy(s_app_name, lpCmd, i_pos2);
    }

    /* 같은 어플리케이션 인스턴스가 존재하는가? */
    if(!hPrevInstance)
    {
        /* 인스턴스의 서로 공유 가능한 자원의 초기화 */
        if(!WinInitApplication(hInst)) 
        {
            return MP_FALSE;
        }

        WinInitInstance(hInst);
    }

    /* Get Subno */
    if(lpszCmdLine[0] != '\0') 
    {
        memcpy(gs_subno, lpszCmdLine , MP_SIZE_SUBNO);
    } 
    else 
    {
        memcpy(gs_subno, "00", MP_SIZE_SUBNO);
    }


    if(initialize_server() == FALSE)
        return FALSE;

    //{
    //    extern int COM_collect_concurrent_user_info(TRSNode *in_node, TRSNode *out_node, char c_finish_flag, char *s_ip_address);
    //    extern int i_update_delay_time_sec;

    //    TRSNode *in_node, *out_node;
    //    int i, k, m, p;
    //    char s_adr[200];
    //    char s_usr[200];

    //    char m_start_time[21];
    //    double d_elpased_time = 0;

    //    in_node = TRS.create_node("IN");
    //    out_node = TRS.create_node("OUT");

    //    p = COM_atoi(gs_subno, 2);

    //    Sleep( (p-1) * 1000 * 3 );

    //    for(m = 0; m < 10; m++)
    //    {
    //        k = ((rand() * p) % 300) + 10;
    //        i_update_delay_time_sec = k;

    //        COM_get_date_time_msec(m_start_time);

    //        for(i = 0; i < 2000; i++)
    //        {
    //            k = rand() % 100 + 1;

    //            sprintf(s_adr, "100.100.100.%d", k);
    //            sprintf(s_usr, "USER_%d", k);

    //            TRS.set_nstring(in_node, IN_USERID, s_usr);

    //            COM_collect_concurrent_user_info(in_node, out_node, 'N', s_adr);
    //        }

    //        d_elpased_time = COM_interval_millisec(m_start_time);

    //        LOG_head("Collect Concurrent User Elapsed Time");
    //        LOG_printf("Update Delay %d Sec. Elapsed Time = [%f]", i_update_delay_time_sec, d_elpased_time);
    //        COM_log_write('S', 'L', 'Y');
    //    }
    //}

    //// ##### Long Log Test ######
    //{
    //    char s_log[10000];
    //    int i;

    //    s_log[0] = 0x00;
    //    for(i = 0; i < 50; i++)
    //    {   // 100 bytes
    //        sprintf(s_log + strlen(s_log), "123456789112345678921234567893123456789412345678951234567896123456789712345678981234567899123456789A");
    //    }
    //    COM_long_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM,
    //        "##### Header #####", "Title", s_log);

    //    s_log[0] = 0x00;
    //    for(i = 0; i < 8; i++)
    //    {   // 100 bytes
    //        sprintf(s_log + strlen(s_log), "123456789112345678921234567893123456789412345678951234567896123456789712345678981234567899123456789A");
    //    }
    //    COM_long_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM,
    //        "##### Header #####", "Title", s_log);
    //}

    //// ##### COM_interval_millisec Test ######
    //{
    //    char s_from_time_17[18];
    //    char s_from_time_14[15];
    //    char s_from_time_8[9];

    //    LOG_head("##### COM_interval_millisec #####################################");

    //    strcpy(s_from_time_17, "20140523070101000");
    //    strcpy(s_from_time_14, "20140523070101");
    //    strcpy(s_from_time_8,  "20140523");

    //    LOG_printf("%s [%f]", s_from_time_17, COM_interval_millisec(s_from_time_17));
    //    LOG_printf("%s [%f]", s_from_time_14, COM_interval_millisec(s_from_time_14));
    //    LOG_printf("%s [%f]", s_from_time_8, COM_interval_millisec(s_from_time_8));

    //    strcpy(s_from_time_17, "20150523070101000");
    //    strcpy(s_from_time_14, "20150523070101");
    //    strcpy(s_from_time_8,  "20150523");

    //    LOG_printf("%s [%f]", s_from_time_17, COM_interval_millisec(s_from_time_17));
    //    LOG_printf("%s [%f]", s_from_time_14, COM_interval_millisec(s_from_time_14));
    //    LOG_printf("%s [%f]", s_from_time_8, COM_interval_millisec(s_from_time_8));

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //    LOG_head("##### COM_interval_sec #####################################");

    //    strcpy(s_from_time_17, "20140523070101000");
    //    strcpy(s_from_time_14, "20140523070101");
    //    strcpy(s_from_time_8,  "20140523");

    //    LOG_printf("%s [%d]", s_from_time_17, COM_interval_sec(s_from_time_17));
    //    LOG_printf("%s [%d]", s_from_time_14, COM_interval_sec(s_from_time_14));
    //    LOG_printf("%s [%d]", s_from_time_8, COM_interval_sec(s_from_time_8));

    //    strcpy(s_from_time_17, "20150523070101000");
    //    strcpy(s_from_time_14, "20150523070101");
    //    strcpy(s_from_time_8,  "20150523");

    //    LOG_printf("%s [%d]", s_from_time_17, COM_interval_sec(s_from_time_17));
    //    LOG_printf("%s [%d]", s_from_time_14, COM_interval_sec(s_from_time_14));
    //    LOG_printf("%s [%d]", s_from_time_8, COM_interval_sec(s_from_time_8));

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //}

    //// ##### CDB_execute_query Test ######
    //{
    //    char s_sql_short[1000];
    //    char s_sql[20000];
    //    char s_sql_big[550100];
    //    int i_col;

    //    char s_data[100];

    //    LOG_head("##### CDB_execute_query Null Terminate #####################################");

    //    sprintf(s_sql_short, "SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'");

    //    LOG_add("sql size", MP_INT, strlen(s_sql_short));
    //    CDB_execute_query(s_sql_short, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 1, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query(s_sql, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 5, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query(s_sql, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    // 190 ==> 500101
    //    gen_sql(s_sql_big, 188, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query(s_sql_big, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql_big, 207, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query(s_sql_big, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);
    //    /*****************************/
    //    LOG_head("##### CDB_execute_query Not Null Terminate #####################################");

    //    memset(s_sql_short, ' ', sizeof(s_sql_short));
    //    memcpy(s_sql_short, "SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'", strlen("SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'"));

    //    LOG_add("sql size", MP_INT, strlen(s_sql_short));
    //    CDB_execute_query(s_sql_short, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 2, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query(s_sql, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 6, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query(s_sql, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    // 190 ==> 500101
    //    gen_sql(s_sql_big, 189, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query(s_sql_big, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql_big, 208, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query(s_sql_big, &i_col);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);
    //    /*****************************/
    //    LOG_head("##### CDB_execute_query2 Null Terminate #####################################");

    //    sprintf(s_sql_short, "SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'");

    //    LOG_add("sql size", MP_INT, strlen(s_sql_short));
    //    CDB_execute_query2(s_sql_short);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 1, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query2(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 5, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query2(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    // 190 ==> 500101
    //    gen_sql(s_sql_big, 188, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query2(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql_big, 207, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query2(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);
    //    /*****************************/
    //    LOG_head("##### CDB_execute_query2 Not Null Terminate #####################################");

    //    memset(s_sql_short, ' ', sizeof(s_sql_short));
    //    memcpy(s_sql_short, "SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'", strlen("SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'"));

    //    LOG_add("sql size", MP_INT, strlen(s_sql_short));
    //    CDB_execute_query2(s_sql_short);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 2, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query2(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 6, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query2(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    // 190 ==> 500101
    //    gen_sql(s_sql_big, 189, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query2(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql_big, 208, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query2(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);
    //    /*****************************/
    //    LOG_head("##### CDB_execute_query3 Null Terminate #####################################");

    //    sprintf(s_sql_short, "SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'");

    //    LOG_add("sql size", MP_INT, strlen(s_sql_short));
    //    CDB_execute_query3(s_sql_short);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 1, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query3(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 5, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query3(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    // 190 ==> 500101
    //    gen_sql(s_sql_big, 188, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query3(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql_big, 207, MP_TRUE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query3(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);
    //    /*****************************/
    //    LOG_head("##### CDB_execute_query3 Not Null Terminate #####################################");

    //    memset(s_sql_short, ' ', sizeof(s_sql_short));
    //    memcpy(s_sql_short, "SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'", strlen("SELECT MSG_ID FROM MMSGMSGDEF WHERE MSG_ID = 'WIP-0001'"));

    //    LOG_add("sql size", MP_INT, strlen(s_sql_short));
    //    CDB_execute_query3(s_sql_short);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 2, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query3(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql, 6, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql));
    //    CDB_execute_query3(s_sql);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    // 190 ==> 500101
    //    gen_sql(s_sql_big, 189, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query3(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    gen_sql(s_sql_big, 208, MP_FALSE); LOG_add("sql size", MP_INT, strlen(s_sql_big));
    //    CDB_execute_query3(s_sql_big);
    //    if(DB_error_code == DB_SUCCESS)
    //    {   memset(s_data, 0x00, sizeof(s_data)); CDB_get_next(); CDB_get_value(0, s_data, sizeof(s_data));
    //        LOG_add("sql data", MP_STR, sizeof(s_data), s_data); } else { LOG_add("DB_ERR", MP_STR, sizeof(DB_error_msg), DB_error_msg); }
    //    CDB_close_dsql();

    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //}


    //{
    //    extern void DB_dtoa(double data_f, char *d_p, int size_i);

    //    char s_dbl_value[50];

    //    LOG_head("##### DB_dtoa TEST #####");

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(0.123456789012345, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("0.123456789012345 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(123456789012345.123456789012345, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("123456789012345.123456789012345 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(123456789012345.0000000000, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("123456789012345.0000000000 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(123456789012345, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("123456789012345 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(12345.12345, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("12345.12345 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(12345.123456, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("12345.123456 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(12345.123456789, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("12345.123456789 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(123456789012345.12345, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("123456789012345.12345 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(123456789012345.123456, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("123456789012345.123456 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(123456789012345.123456789, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("123456789012345.123456789 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(12345.00000, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("12345.00000 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(0.12345, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("0.12345 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(0.123456, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("0.123456 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);

    //    memset(s_dbl_value, 0x00, sizeof(s_dbl_value));
    //    DB_dtoa(0.123456789, s_dbl_value, sizeof(s_dbl_value));
    //    LOG_add("0.123456789 string_value", MP_STR, sizeof(s_dbl_value), s_dbl_value);


    //    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //}

    ///* DATETIME TEST */
    //{
    //    TRSNode *a;

    //    a = TRS.create_node("AA");

    //    //TRS.set_datetime(a, "AA", "2010-06-08T12:13:14");

    //    //LOG_head("2010-06-08T12:13:14");
    //    //LOG_add("AA", MP_NSTR, TRS.get_datetime(a, "AA"));
    //    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //    //TRS.set_datetime(a, "AA", "20100802");

    //    //LOG_head("20100802");
    //    //LOG_add("AA", MP_NSTR, TRS.get_datetime(a, "AA"));
    //    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //    //TRS.set_datetime(a, "AA", "20100802115500");

    //    //LOG_head("20100802115500");
    //    //LOG_add("AA", MP_NSTR, TRS.get_datetime(a, "AA"));
    //    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //    //TRS.set_datetime(a, "AA", "20100802115500000");

    //    //LOG_head("20100802115500000");
    //    //LOG_add("AA", MP_NSTR, TRS.get_datetime(a, "AA"));
    //    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //    //TRS.set_datetime(a, "AA", "2009-07-23T10:29:01.876");

    //    //LOG_head("2009-07-23T10:29:01.876");
    //    //LOG_add("AA", MP_NSTR, TRS.get_datetime(a, "AA"));
    //    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //    //TRS.set_datetime(a, "AA", "2009-07-23T10:29:01,912");

    //    //LOG_head("2009-07-23T10:29:01,912");
    //    //LOG_add("AA", MP_NSTR, TRS.get_datetime(a, "AA"));
    //    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    //    //printf("aa");
    //}

    ////// TRSNode TEST CODE
    ////{
    ////    MINT        a1, b1;
    ////    MFLOAT      a2, b2;
    ////    MCHAR       a3, b3;
    ////    MSTRING     a4, b4;
    ////    MDOUBLE     a5, b5;
    ////    MLONG       a6, b6;
    ////    MBOOLEAN    a7, b7;
    ////    MBINARY     a8, b8;
    ////    MSHORT      a9, b9;
    ////    MBYTE       a10, b10;
    ////    MUBYTE      a11, b11;
    ////    MUSHORT     a12, b12;
    ////    MUINT       a13, b13;
    ////    MULONG      a14, b14;
    ////    MDATETIME   a15, b15;
    ////    MBLOB       a16, b16;
    ////    char        str[20000];
    ////    char        xml1[20000000];
    ////    char        xml2[20000000];

    ////    TRSNode     *n1;
    ////    TRSNode     *n2;
    ////    TRSNode     *lst;
    ////    TRSNode     *ary;

    ////    int         i_cmp;

    ////    a1.IS_NULL = ' ';
    ////    a1.VALUE = 9;

    ////    a2.IS_NULL = ' ';
    ////    a2.VALUE = 9.999999f;

    ////    a3.IS_NULL = ' ';
    ////    a3.VALUE = 'M';

    ////    memset(&a4, ' ', sizeof(a4));
    ////    a4.IS_NULL = ' ';
    ////    memcpy(a4.VALUE, "abcde한글", strlen("abcde한글"));

    ////    a5.IS_NULL = ' ';
    ////    a5.VALUE = 0.0000009;

    ////    a6.IS_NULL = ' ';
    ////    a6.VALUE = 123456;

    ////    a7.IS_NULL = ' ';
    ////    a7.VALUE = MP_TRUE;

    ////    a8.IS_NULL = ' ';
    ////    a8.VALUE = 8;

    ////    a9.IS_NULL = ' ';
    ////    a9.VALUE = 99;

    ////    a10.IS_NULL = ' ';
    ////    a10.VALUE = 19;

    ////    a11.IS_NULL = ' ';
    ////    a11.VALUE = 91;

    ////    a12.IS_NULL = ' ';
    ////    a12.VALUE = 129;

    ////    a13.IS_NULL = ' ';
    ////    a13.VALUE = 1234569;

    ////    a14.IS_NULL = ' ';
    ////    a14.VALUE = 1123456789;

    ////    memset(&a15, ' ', sizeof(a15));
    ////    a15.IS_NULL = ' ';
    ////    memcpy(a15.VALUE, "2009-03-09T20:05:34Z", strlen("2009-03-09T20:05:34Z"));


    ////    memset(str, 0x00, sizeof(str));
    ////    strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");

    ////    memset(&a16, 0x00, sizeof(a16));
    ////    a16.IS_NULL = ' ';
    ////    a16.VALUE = str;
    ////    a16.SIZE = strlen(str);

    ////    LOG_head("TEST LOG");
    ////    LOG_add("MINT"     , MP_MINT, &a1);
    ////    LOG_add("MFLOAT"   , MP_MFLT, &a2);
    ////    LOG_add("MCHAR"    , MP_MCHR, &a3);
    ////    LOG_add("MSTRING"  , MP_MSTR, &a4);
    ////    LOG_add("MDOUBLE"  , MP_MDBL, &a5);
    ////    LOG_add("MLONG"    , MP_MLNG, &a6);
    ////    LOG_add("MBOOL"    , MP_MBOOL, &a7);
    ////    LOG_add("MBINARY"  , MP_MBIN, &a8);
    ////    LOG_add("MSHORT"   , MP_MSHT, &a9);
    ////    LOG_add("MBYTE"    , MP_MBYT, &a10);
    ////    LOG_add("MUBYTE"   , MP_MUBYT, &a11);
    ////    LOG_add("MUSHORT"  , MP_MUSHT, &a12);
    ////    LOG_add("MUINT"    , MP_MUINT, &a13);
    ////    LOG_add("MULONG"   , MP_MULNG, &a14);
    ////    LOG_add("MDATE"    , MP_MDATE, &a15);
    ////    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);


    ////    n1 = TRSN.create_node("test1");

    ////    TRSN.add_int        (n1, "MINT"     , a1);
    ////    TRSN.add_float      (n1, "MFLOAT"   , a2);
    ////    TRSN.add_char       (n1, "MCHAR"    , a3);
    ////    TRSN.add_string     (n1, "MSTRING"  , a4);
    ////    TRSN.add_double     (n1, "MDOUBLE"  , a5);
    ////    TRSN.add_long       (n1, "MLONG"    , a6);
    ////    TRSN.add_boolean    (n1, "MBOOL"    , a7);
    ////    TRSN.add_binary     (n1, "MBINARY"  , a8);
    ////    TRSN.add_short      (n1, "MSHORT"   , a9);
    ////    TRSN.add_byte       (n1, "MBYTE"    , a10);
    ////    TRSN.add_ubyte      (n1, "MUBYTE"   , a11);
    ////    TRSN.add_ushort     (n1, "MUSHORT"  , a12);
    ////    TRSN.add_uint       (n1, "MUINT"    , a13);
    ////    TRSN.add_ulong      (n1, "MULONG"   , a14);
    ////    TRSN.add_datetime   (n1, "MDATE"    , a15);
    ////    TRSN.add_blob       (n1, "MBLOB"    , a16);

    ////    lst = TRSN.add_node(n1, "LIST");

    ////    TRSN.add_int        (lst, "MINT"     , a1);
    ////    TRSN.add_float      (lst, "MFLOAT"   , a2);
    ////    TRSN.add_char       (lst, "MCHAR"    , a3);
    ////    TRSN.add_string     (lst, "MSTRING"  , a4);
    ////    TRSN.add_double     (lst, "MDOUBLE"  , a5);
    ////    TRSN.add_long       (lst, "MLONG"    , a6);
    ////    TRSN.add_boolean    (lst, "MBOOL"    , a7);
    ////    TRSN.add_binary     (lst, "MBINARY"  , a8);
    ////    TRSN.add_short      (lst, "MSHORT"   , a9);
    ////    TRSN.add_byte       (lst, "MBYTE"    , a10);
    ////    TRSN.add_ubyte      (lst, "MUBYTE"   , a11);
    ////    TRSN.add_ushort     (lst, "MUSHORT"  , a12);
    ////    TRSN.add_uint       (lst, "MUINT"    , a13);
    ////    TRSN.add_ulong      (lst, "MULONG"   , a14);
    ////    TRSN.add_datetime   (lst, "MDATE"    , a15);
    ////    TRSN.add_blob       (lst, "MBLOB"    , a16);

    ////    lst = TRSN.add_node(n1, "LIST");

    ////    TRSN.add_int        (lst, "MINT"     , a1);
    ////    TRSN.add_float      (lst, "MFLOAT"   , a2);
    ////    TRSN.add_char       (lst, "MCHAR"    , a3);
    ////    TRSN.add_string     (lst, "MSTRING"  , a4);
    ////    TRSN.add_double     (lst, "MDOUBLE"  , a5);
    ////    TRSN.add_long       (lst, "MLONG"    , a6);
    ////    TRSN.add_boolean    (lst, "MBOOL"    , a7);
    ////    TRSN.add_binary     (lst, "MBINARY"  , a8);
    ////    TRSN.add_short      (lst, "MSHORT"   , a9);
    ////    TRSN.add_byte       (lst, "MBYTE"    , a10);
    ////    TRSN.add_ubyte      (lst, "MUBYTE"   , a11);
    ////    TRSN.add_ushort     (lst, "MUSHORT"  , a12);
    ////    TRSN.add_uint       (lst, "MUINT"    , a13);
    ////    TRSN.add_ulong      (lst, "MULONG"   , a14);
    ////    TRSN.add_datetime   (lst, "MDATE"    , a15);
    ////    TRSN.add_blob       (lst, "MBLOB"    , a16);

    ////    lst = TRSN.add_node(n1, "LIST");

    ////    TRSN.add_int        (lst, "MINT"     , a1);
    ////    TRSN.add_float      (lst, "MFLOAT"   , a2);
    ////    TRSN.add_char       (lst, "MCHAR"    , a3);
    ////    TRSN.add_string     (lst, "MSTRING"  , a4);
    ////    TRSN.add_double     (lst, "MDOUBLE"  , a5);
    ////    TRSN.add_long       (lst, "MLONG"    , a6);
    ////    TRSN.add_boolean    (lst, "MBOOL"    , a7);
    ////    TRSN.add_binary     (lst, "MBINARY"  , a8);
    ////    TRSN.add_short      (lst, "MSHORT"   , a9);
    ////    TRSN.add_byte       (lst, "MBYTE"    , a10);
    ////    TRSN.add_ubyte      (lst, "MUBYTE"   , a11);
    ////    TRSN.add_ushort     (lst, "MUSHORT"  , a12);
    ////    TRSN.add_uint       (lst, "MUINT"    , a13);
    ////    TRSN.add_ulong      (lst, "MULONG"   , a14);
    ////    TRSN.add_datetime   (lst, "MDATE"    , a15);
    ////    TRSN.add_blob       (lst, "MBLOB"    , a16);

    ////    ary = TRSN.add_array(lst, "ARRAY", DT_NSTRING);

    ////    TRSN.add_item(ary, &a4);
    ////    TRSN.add_item(ary, &a4);
    ////    TRSN.add_item(ary, &a4);
    ////    TRSN.add_item(ary, &a4);
    ////    TRSN.add_item(ary, &a4);

    ////    TRSN.add_object(n1, "LOGH", LOG_head);

    ////    LOG_head("TEST LOG_2");
    ////    TRSN.log_add(n1, "MINT"     );
    ////    TRSN.log_add(n1, "MFLOAT"   );
    ////    TRSN.log_add(n1, "MCHAR"    );
    ////    TRSN.log_add(n1, "MSTRING"  );
    ////    TRSN.log_add(n1, "MDOUBLE"  );
    ////    TRSN.log_add(n1, "MLONG"    );
    ////    TRSN.log_add(n1, "MBOOL"    );
    ////    TRSN.log_add(n1, "MBINARY"  );
    ////    TRSN.log_add(n1, "MSHORT"   );
    ////    TRSN.log_add(n1, "MBYTE"    );
    ////    TRSN.log_add(n1, "MUBYTE"   );
    ////    TRSN.log_add(n1, "MUSHORT"  );
    ////    TRSN.log_add(n1, "MUINT"    );
    ////    TRSN.log_add(n1, "MULONG"   );
    ////    TRSN.log_add(n1, "MDATE"    );
    ////    TRSN.log_add(n1, "MBLOB"    );
    ////    TRSN.log_add(n1, "LIST"     );
    ////    TRSN.log_add(lst, "ARRAY"     );
    ////    TRSN.log_add(ary, "1"    );
    ////    TRSN.log_add(n1, "LOGH"    );
    ////    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    ////    LOG_head("TEST LOG_3");
    ////    TRSN.log_add_all_members(n1);
    ////    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    ////    LOG_head("TEST LOG_4");
    ////    TRSN.log_add_all_members(lst);
    ////    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    ////    memset(xml1, 0x00, sizeof(xml1));
    ////    TRSN.to_xml_string(xml1, n1);

    ////    n2 = TRSN.create_node("test2");

    ////    TRSN.parse(n2, xml1, strlen(xml1));

    ////    b1 = TRSN.get_int       (n2, "MINT");
    ////    b2 = TRSN.get_float     (n2, "MFLOAT");
    ////    b3 = TRSN.get_char      (n2, "MCHAR");
    ////    b4 = TRSN.get_string    (n2, "MSTRING");
    ////    b5 = TRSN.get_double    (n2, "MDOUBLE");
    ////    b6 = TRSN.get_long      (n2, "MLONG");
    ////    b7 = TRSN.get_boolean   (n2, "MBOOL");
    ////    b8 = TRSN.get_binary    (n2, "MBINARY");
    ////    b9 = TRSN.get_short     (n2, "MSHORT");
    ////    b10 = TRSN.get_byte     (n2, "MBYTE");
    ////    b11 = TRSN.get_ubyte    (n2, "MUBYTE");
    ////    b12 = TRSN.get_ushort   (n2, "MUSHORT");
    ////    b13 = TRSN.get_uint     (n2, "MUINT");
    ////    b14 = TRSN.get_ulong    (n2, "MULONG");
    ////    b15 = TRSN.get_datetime (n2, "MDATE");
    ////    b16 = TRSN.get_blob     (n2, "MBLOB");

    ////    memset(xml2, 0x00, sizeof(xml2));
    ////    TRSN.to_xml_string(xml2, n2);

    ////    i_cmp = 0;
    ////    i_cmp = strcmp(xml1, xml2);

    ////    TRSN.free_node(n1);
    ////    TRSN.free_node(n2);

    ////}


    ////{
    ////    int             a1, b1;
    ////    float           a2, b2;
    ////    char            a3, b3;
    ////    char            a4[20], *b4;
    ////    double          a5, b5;
    ////    long            a6, b6;
    ////    int             a7, b7;
    ////    unsigned char   a8, b8;
    ////    short           a9, b9;
    ////    char            a10, b10;
    ////    unsigned char   a11, b11;
    ////    unsigned short  a12, b12;
    ////    unsigned int    a13, b13;
    ////    unsigned long   a14, b14;
    ////    char            a15[30], *b15;
    ////    char            *a16, *b16;
    ////    char        str[20000];
    ////    char        xml1[20000000];
    ////    char        xml2[20000000];
    ////    long        blob_size;

    ////    TRSNode     *n1;
    ////    TRSNode     *n2;
    ////    TRSNode     *lst;
    ////    TRSNode     *ary;

    ////    int         i_cmp;


    ////    blob_size = 0;

    ////    a1 = 9;
    ////    a2 = 9.999999f;
    ////    //a3 = 'M';
    ////    a3 = 0x00;

    ////    //memset(a4, ' ', sizeof(a4));
    ////    //memcpy(a4, "abcde한글", strlen("abcde한글"));

    ////    memset(a4, 0x00, sizeof(a4));

    ////    a5 = 0.0000009;
    ////    a6 = 123456;
    ////    a7 = MP_TRUE;
    ////    a8 = 8;
    ////    a9 = 99;
    ////    a10 = 19;
    ////    a11 = 91;
    ////    a12 = 129;
    ////    a13 = 1234569;
    ////    a14 = 1123456789;

    ////    memset(a15, 0x00, sizeof(a15));
    ////    //memcpy(a15, "2009-03-09T20:05:34Z", strlen("2009-03-09T20:05:34Z"));

    ////    memset(str, 0x00, sizeof(str));
    ////    //strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    //strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    //strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    //strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");
    ////    //strcpy(str + strlen(str), "[12/05/08,08:26:15] 대한민국%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()");

    ////    a16 = str;

    ////    n1 = TRS.create_node("test1");

    ////    TRS.add_int        (n1, "MINT"     , a1);
    ////    TRS.add_float      (n1, "MFLOAT"   , a2);
    ////    TRS.add_char       (n1, "MCHAR"    , a3);
    ////    TRS.add_string     (n1, "MSTRING"  , a4, sizeof(a4));
    ////    TRS.add_double     (n1, "MDOUBLE"  , a5);
    ////    TRS.add_long       (n1, "MLONG"    , a6);
    ////    TRS.add_boolean    (n1, "MBOOL"    , a7);
    ////    TRS.add_binary     (n1, "MBINARY"  , a8);
    ////    TRS.add_short      (n1, "MSHORT"   , a9);
    ////    TRS.add_byte       (n1, "MBYTE"    , a10);
    ////    TRS.add_ubyte      (n1, "MUBYTE"   , a11);
    ////    TRS.add_ushort     (n1, "MUSHORT"  , a12);
    ////    TRS.add_uint       (n1, "MUINT"    , a13);
    ////    TRS.add_ulong      (n1, "MULONG"   , a14);
    ////    TRS.add_datetime   (n1, "MDATE"    , a15);
    ////    TRS.add_blob       (n1, "MBLOB"    , a16, strlen(a16));

    ////    lst = TRS.add_node(n1, "LIST");

    ////    TRS.add_int        (lst, "MINT"     , a1);
    ////    TRS.add_float      (lst, "MFLOAT"   , a2);
    ////    TRS.add_char       (lst, "MCHAR"    , a3);
    ////    TRS.add_string     (lst, "MSTRING"  , a4, sizeof(a4));
    ////    TRS.add_double     (lst, "MDOUBLE"  , a5);
    ////    TRS.add_long       (lst, "MLONG"    , a6);
    ////    TRS.add_boolean    (lst, "MBOOL"    , a7);
    ////    TRS.add_binary     (lst, "MBINARY"  , a8);
    ////    TRS.add_short      (lst, "MSHORT"   , a9);
    ////    TRS.add_byte       (lst, "MBYTE"    , a10);
    ////    TRS.add_ubyte      (lst, "MUBYTE"   , a11);
    ////    TRS.add_ushort     (lst, "MUSHORT"  , a12);
    ////    TRS.add_uint       (lst, "MUINT"    , a13);
    ////    TRS.add_ulong      (lst, "MULONG"   , a14);
    ////    TRS.add_datetime   (lst, "MDATE"    , a15);
    ////    TRS.add_blob       (lst, "MBLOB"    , a16, strlen(a16));

    ////    lst = TRS.add_node(n1, "LIST");

    ////    TRS.add_int        (lst, "MINT"     , a1);
    ////    TRS.add_float      (lst, "MFLOAT"   , a2);
    ////    TRS.add_char       (lst, "MCHAR"    , a3);
    ////    TRS.add_string     (lst, "MSTRING"  , a4, sizeof(a4));
    ////    TRS.add_double     (lst, "MDOUBLE"  , a5);
    ////    TRS.add_long       (lst, "MLONG"    , a6);
    ////    TRS.add_boolean    (lst, "MBOOL"    , a7);
    ////    TRS.add_binary     (lst, "MBINARY"  , a8);
    ////    TRS.add_short      (lst, "MSHORT"   , a9);
    ////    TRS.add_byte       (lst, "MBYTE"    , a10);
    ////    TRS.add_ubyte      (lst, "MUBYTE"   , a11);
    ////    TRS.add_ushort     (lst, "MUSHORT"  , a12);
    ////    TRS.add_uint       (lst, "MUINT"    , a13);
    ////    TRS.add_ulong      (lst, "MULONG"   , a14);
    ////    TRS.add_datetime   (lst, "MDATE"    , a15);
    ////    TRS.add_blob       (lst, "MBLOB"    , a16, strlen(a16));

    ////    lst = TRS.add_node(n1, "LIST");

    ////    TRS.add_int        (lst, "MINT"     , a1);
    ////    TRS.add_float      (lst, "MFLOAT"   , a2);
    ////    TRS.add_char       (lst, "MCHAR"    , a3);
    ////    TRS.add_string     (lst, "MSTRING"  , a4, sizeof(a4));
    ////    TRS.add_double     (lst, "MDOUBLE"  , a5);
    ////    TRS.add_long       (lst, "MLONG"    , a6);
    ////    TRS.add_boolean    (lst, "MBOOL"    , a7);
    ////    TRS.add_binary     (lst, "MBINARY"  , a8);
    ////    TRS.add_short      (lst, "MSHORT"   , a9);
    ////    TRS.add_byte       (lst, "MBYTE"    , a10);
    ////    TRS.add_ubyte      (lst, "MUBYTE"   , a11);
    ////    TRS.add_ushort     (lst, "MUSHORT"  , a12);
    ////    TRS.add_uint       (lst, "MUINT"    , a13);
    ////    TRS.add_ulong      (lst, "MULONG"   , a14);
    ////    TRS.add_datetime   (lst, "MDATE"    , a15);
    ////    TRS.add_blob       (lst, "MBLOB"    , a16, strlen(a16));

    ////    ary = TRS.add_array(lst, "ARRAY", DT_STRING);

    ////    TRS.add_item(ary, sizeof(a4), a4);
    ////    TRS.add_item(ary, sizeof(a4), a4);
    ////    TRS.add_item(ary, sizeof(a4), a4);
    ////    TRS.add_item(ary, sizeof(a4), a4);
    ////    TRS.add_item(ary, sizeof(a4), a4);


    ////    memset(xml1, 0x00, sizeof(xml1));
    ////    TRS.to_xml_string(xml1, n1);

    ////    n2 = TRS.create_node("test2");

    ////    TRS.parse(n2, xml1, strlen(xml1));

    ////    b1 = TRS.get_int       (n2, "MINT");
    ////    b2 = TRS.get_float     (n2, "MFLOAT");
    ////    b3 = TRS.get_char      (n2, "MCHAR");
    ////    b4 = TRS.get_string    (n2, "MSTRING");
    ////    b5 = TRS.get_double    (n2, "MDOUBLE");
    ////    b6 = TRS.get_long      (n2, "MLONG");
    ////    b7 = TRS.get_boolean   (n2, "MBOOL");
    ////    b8 = TRS.get_binary    (n2, "MBINARY");
    ////    b9 = TRS.get_short     (n2, "MSHORT");
    ////    b10 = TRS.get_byte     (n2, "MBYTE");
    ////    b11 = TRS.get_ubyte    (n2, "MUBYTE");
    ////    b12 = TRS.get_ushort   (n2, "MUSHORT");
    ////    b13 = TRS.get_uint     (n2, "MUINT");
    ////    b14 = TRS.get_ulong    (n2, "MULONG");
    ////    b15 = TRS.get_datetime (n2, "MDATE");

    ////    b16 = 0x00;
    ////    TRS.get_blob           (n2, "MBLOB", &b16, &blob_size);

    ////    memset(xml2, 0x00, sizeof(xml2));
    ////    TRS.to_xml_string(xml2, n2);

    ////    i_cmp = 0;
    ////    i_cmp = strcmp(xml1, xml2);

    ////    TRS.free_node(n1);
    ////    TRS.free_node(n2);

    ////}

    /**** Dispatch for PULL ****/

    MAIN_dispatch_message();

    /* Message Loop */
    while(GetMessage(&msg, NULL, 0, 0)) 
    {
        /* 가상키(virtual key)를 문자(character)로 바꾼다. */
        TranslateMessage(&msg);
        /* 메세지를 MainWndPorc에 전달한다. */
        DispatchMessage(&msg);
    }

    return (int)msg.wParam;
}

/*******************************************************************************
    WinInitApplication(HINSTANCE hInst)
        - Initialize and register window class
    Return Value
        - int : RegisterClassEx(&wndclass)
    Arguments
        - HINSTANCE hInstance : Handle to an instance
*******************************************************************************/
int WinInitApplication(HINSTANCE hInst)
{
    WNDCLASSEX wndclass;

    wndclass.cbSize = sizeof(WNDCLASSEX);
    wndclass.style = CS_HREDRAW | CS_VREDRAW;
    wndclass.lpfnWndProc = WndProc;
    wndclass.cbClsExtra = 0;
    wndclass.cbWndExtra = 0;
    wndclass.hInstance = hInst;
    wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);
    wndclass.hbrBackground = (HBRUSH)(COLOR_BTNFACE + 1);
    wndclass.lpszMenuName = NULL;
    wndclass.lpszClassName = s_app_name;
    wndclass.hIcon = 0;
    wndclass.hIconSm = 0;

    if(strcmp(s_app_name, MP_MESServer) == 0)
    {
        wndclass.hIcon = LoadIcon(hInst, (LPCTSTR)IDI_MESServer);
        wndclass.hIconSm = LoadIcon(hInst, (LPCTSTR)IDI_MESServer);
    }
    else if(strcmp(s_app_name, MP_RTDServer) == 0)
    {
        wndclass.hIcon = LoadIcon(hInst, (LPCTSTR)IDI_RTDServer);
        wndclass.hIconSm = LoadIcon(hInst, (LPCTSTR)IDI_RTDServer);
    }
    else if(strcmp(s_app_name, MP_ADMServer) == 0)
    {
        wndclass.hIcon = LoadIcon(hInst, (LPCTSTR)IDI_ADMServer);
        wndclass.hIconSm = LoadIcon(hInst, (LPCTSTR)IDI_ADMServer);
    }

    return RegisterClassEx(&wndclass);
}


/*******************************************************************************
    End of Windows MES Server Code
*******************************************************************************/

#else

/*******************************************************************************
    Unix MES Server Code
*******************************************************************************/

/*******************************************************************************
    main()
        - main function
    Return Value
        - MP_TRUE or MP_FALSE
    Arguments
        - int argc, char *argv[]
*******************************************************************************/
int main(int argc, char *argv[])
{
    int i;
    int i_len;

    if(argc != 2)
    {
        // Error
        printf( "Wrong argument!\n" );
        printf( "   Usage : Server [\"Sub No\"]\n" );
        return FALSE;
    }

    /* Get s_app_name */
    /* Get Application Name without extension(.exe). The value is used to find out INI File for the application */
    memset(s_app_name, '\0', sizeof(s_app_name));    
    i_len = strlen(argv[0]);
    for (i = i_len; i > 0; i--)
    {
        if(argv[0][i] == '/') 
            break;
        if(argv[0][i] == '.') 
            i_len = i;
    }
    if(i > 0)
    {
        memcpy(s_app_name, argv[0] + i + 1, i_len - i -1);
    }
    else
    {
        memcpy(s_app_name, argv[0], i_len);
    }

    /* Get Subno */
    if(argv[1][0] != '\0')
        memcpy(gs_subno, argv[1] , MP_SIZE_SUBNO);
    else 
        memcpy(gs_subno, "00", MP_SIZE_SUBNO);

    /* Initialize Server */
    if(initialize_server() == FALSE)
        return FALSE;

    /**** Message Loop ****/
    MAIN_dispatch_message();

    return TRUE;
}

/*******************************************************************************
    End of Unix MES Server Code
*******************************************************************************/

#endif
