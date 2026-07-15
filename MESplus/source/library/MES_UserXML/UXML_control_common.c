/*******************************************************************************

    System      : MESplus
    Module      : Tibrv System Control
    File Name   : SIL_TSC_common.c
    Description : Management the called services

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/02/10  Aiden          Create

    Copyright(C) 1998-2009 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#if defined(_H101)


#elif defined(_TIBRV)

#include "MESCore_common.h"
#include "UXML_common.h"

void addService(const char *s_name, const char *s_ver, const char *s_subject, const long i_time)
{
    int i;
    TRSNode *n_service;

    for(i = 0; i < TRS.get_item_count(g_node_var, "SERVICES"); i++)
    {
        n_service = TRS.get_list(g_node_var, "SERVICES")[i];

        if(TRS.str_cmp(n_service, "NAME", s_name) == 0 &&
           TRS.str_cmp(n_service, "VERSION", s_ver) == 0 &&
           TRS.str_cmp(n_service, "SUBJECT", s_subject) == 0)
        {
            TRS.set_long(n_service, "CALLS", TRS.get_long(n_service, "CALLS") + 1);
            TRS.set_long(n_service, "TIME", TRS.get_long(n_service, "TIME") + i_time);
            return ;
        }
    }

    n_service = TRS.add_node(g_node_var, "SERVICES");

    TRS.add_nstring(n_service, "NAME", s_name);
    TRS.add_nstring(n_service, "VERSION", s_ver);
    TRS.add_nstring(n_service, "SUBJECT", s_subject);

    TRS.add_long(n_service, "CALLS", 1);
    TRS.add_long(n_service, "TIME", i_time);
}

void calcServiceCount()
{
    char s_service_end_time[17];
    long i_service_time;
    double d_elapsed_time;

    char s_service_ver[10];
    struct MSVMSVCDEF_TAG MSVMSVCDEF;
    struct MSVMDFTVER_TAG MSVMDFTVER;

    i_service_time = 0;
    d_elapsed_time = 0;

    //COM_get_date_time_msec_utc(s_service_end_time);
    COM_get_date_time_msec(s_service_end_time);
    COM_diff_time_millisec(&d_elapsed_time, s_service_end_time, TRS.get_string(g_node_var, "SERVICE_START_TIME"));
    i_service_time = d_elapsed_time * 1000;

    TRS.set_long(g_node_var, "TOTAL_SERVICE_TIME", TRS.get_long(g_node_var, "TOTAL_SERVICE_TIME") + i_service_time);

    memset(s_service_ver, 0x00, sizeof(s_service_ver));

    if(gc_db_connected == 'Y')
    {
        DBC_init_msvmsvcdef(&MSVMSVCDEF);
        memcpy(MSVMSVCDEF.SERVICE_NAME, gs_msg_service_name, sizeof(MSVMSVCDEF.SERVICE_NAME));
        DBC_select_msvmsvcdef(1, &MSVMSVCDEF);
    
        if(COM_isspace(MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMSVCDEF.SHARED_LIB_NAME)) == MP_FALSE)
        {
            DBC_init_msvmdftver(&MSVMDFTVER);
            memcpy(MSVMDFTVER.LIB_NAME, MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMDFTVER.LIB_NAME));
            memcpy(MSVMDFTVER.SERVICE_NAME, MSVMSVCDEF.SERVICE_NAME, sizeof(MSVMDFTVER.SERVICE_NAME));
            DBC_select_msvmdftver(4, &MSVMDFTVER);
            if(DB_error_code == DB_SUCCESS)
            {
                DBC_select_msvmdftver(1, &MSVMDFTVER);
                if(DB_error_code == DB_SUCCESS)
                {
                    sprintf(s_service_ver, "%d", MSVMDFTVER.SERVICE_VER);
                }
            }
        }
    }

    addService(gs_msg_service_name, s_service_ver, gs_msg_send_subject, i_service_time);    
}

#endif

