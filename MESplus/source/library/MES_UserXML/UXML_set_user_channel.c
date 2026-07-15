/*******************************************************************************

    System      : MESplus
    Module      : User Routine for Custom XML
    File Name   : UXML_set_user_channel.c
    Description : User Routine for set user channel

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/11/10  Aiden          Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#if defined(_TIBRV)

#include "UXML_common.h"

int UCOM_set_user_channel_1(char *s_module_name, char *s_service_name, char *channel, int mode)
{
    int i_len;
    int i_ret;
    char s_value[256];
    char s_key[256];

    int i;
    int i_count;
    char s_temp[256];

    sprintf(s_key, "%sChannelPreFix", s_module_name);

    memset(s_value, 0x00, sizeof(s_value));

    if(TRS.get_member(g_node_var, s_key) == 0x00)
    {
        /* Get Channel Prefix String */
        i_ret = COM_get_init_value(gs_svr_file, "StartOption", s_key, s_value, &i_len);
        if(i_ret == MP_FALSE) 
        {
            LOG_head("UCOM_set_user_channel : COM_get_init_value");
            LOG_add("gs_svr_file", MP_NSTR, gs_svr_file);
            LOG_add("s_key", MP_NSTR, s_key);
            COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

            TRS.set_nstring(g_node_var, s_key, "");

            return MP_TRUE;
        }

        TRS.set_nstring(g_node_var, s_key, s_value);
    }
    else
    {
        TRS.get_string_param(g_node_var, s_key, s_value);
    }

    if     (strcmp(s_module_name, "ADM") == 0)
    {
        // Core Channel Rule
        // Site ID.ADM => MPP1.ADM
        // So change request channel to siltronic subject format

        sprintf(channel, "%s.%s", s_value, s_service_name);
    }
    else if(strcmp(s_module_name, "ALM") == 0)
    {
        // Core Channel Rule
        // Site ID.ALM.FACTORY.USER_ID => MPP1.ALM.FABBLW.ADMIN
        // So change request channel to siltronic subject format
        
        i_count = 0;
        memset(s_temp, 0x00, sizeof(s_temp));

        for(i = (int)strlen(channel) - 1; i >= 0; i--)
        {
            if(channel[i] == '.') i_count++;
            if(i_count > 1)
            {
                memcpy(s_temp, channel + i + 1, strlen(channel) - i);
                break;
            }
        }

        sprintf(channel, "%s.%s.%s", s_value, s_service_name, s_temp);
    }
    else if(strcmp(s_module_name, "FMB") == 0)
    {
        // Core Channel Rule
        // Site ID.FMB.* => MPP1.FMB.*
        // So change request channel to siltronic subject format
        
        sprintf(channel, "%s.%s.*", s_value, s_service_name);
    }
    else if(strcmp(s_module_name, "SPC") == 0)
    {
        if(strcmp(s_service_name, "SPC_Publish_Data") == 0)
        {
            // Core Channel Rule
            // Site ID.SPC.FACTORY.CHART_ID.* => MPP1.SPC.FABBLW.PRESS.*
            // So change request channel to siltronic subject format
            
            i_count = 0;
            memset(s_temp, 0x00, sizeof(s_temp));

            for(i = (int)strlen(channel) - 1; i >= 0; i--)
            {
                if(channel[i] == '.') i_count++;
                if(i_count > 2)
                {
                    memcpy(s_temp, channel + i + 1, strlen(channel) - i);
                    break;
                }
            }

            sprintf(channel, "%s.%s.%s", s_value, s_service_name, s_temp);
        }
        else if(strcmp(s_service_name, "SPC_Display_Message") == 0)
        {
            // Core Channel Rule
            // Site ID.SPC.FACTORY.SEC_GRP_ID.USER_ID => MPP1.SPC.FABBLW.ADMIN_GRP.ADMIN
            // So change request channel to siltronic subject format
            
            i_count = 0;
            memset(s_temp, 0x00, sizeof(s_temp));

            for(i = (int)strlen(channel) - 1; i >= 0; i--)
            {
                if(channel[i] == '.') i_count++;
                if(i_count > 2)
                {
                    memcpy(s_temp, channel + i + 1, strlen(channel) - i);
                    break;
                }
            }

            sprintf(channel, "%s.%s.%s", s_value, s_service_name, s_temp);
        }
    }
    else if(strcmp(s_module_name, "RTD") == 0)
    {
        // Core Channel Rule
        // MainChannel => MPP1.MESServer
        // So change request channel to siltronic subject format
        
        sprintf(channel, "%s.%s", s_value, s_service_name);
    }


    return MP_TRUE;
}

#endif