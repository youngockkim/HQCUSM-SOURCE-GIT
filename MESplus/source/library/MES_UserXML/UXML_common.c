/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : sl_common.c
    Description : Common function of user defined shared library

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/11/10  Miracom        Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#if defined(_HPUX_SOURCE)
    #include <arpa/inet.h>
#endif
#include "UXML_common.h"

void SLC_BIND_FUNCTION()
{
#if defined(_TIBRV)

    gs_msg_hdr_msg_id = 0x00;
    gs_msg_hdr_taid = 0x00;
    gi_msg_seq = 0;
    
    memset(gt_ecd_header, ' ', sizeof(gt_ecd_header));
    gi_ecd_header_count = 0;

#endif

    SLC_SET_LIBRARY_MODE(UNLOADABLE);
    
    SLC_ADD_FUNCTION("UCOM_parse", 1);
    SLC_ADD_FUNCTION("UCOM_generate", 1);
    SLC_ADD_FUNCTION("UCOM_send_error_msg", 1);
    SLC_ADD_FUNCTION("UCOM_set_user_channel", 1);
    SLC_ADD_FUNCTION("UCOM_prologue_msg", 1);
    SLC_ADD_FUNCTION("UCOM_epilogue_msg", 1);
    SLC_ADD_FUNCTION("UXML_get_msg_code",1);
}

#if defined(_H101)

#elif defined(_TIBRV)

extern void calcServiceCount();
void UXML_to_xml_string(char* xmlString, const TRSNode *node);
int UXML_filter_calculation(char *s_service_name);
void TRS_encrypt(char *dest, const unsigned char *src);

int UCOM_send_error_msg_1(TRSNode *node, tibrvMsg msg_1, tibrvMsg *msg_2)
{
    char *s_err_msg;

    s_err_msg = TRS.get_string(node, "__ERR_MSG");
    UXML_send_error_msg(999, msg_1, msg_2, s_err_msg);

    return MP_TRUE;
}

int UCOM_prologue_msg_1(tibrvMsg msg)
{
    char    *s_ignore = 0x00;
    char    *s_msg_requestor = 0x00;

    memset(gs_factory_code, 0x00, sizeof(gs_factory_code));
    memset(gs_msg_service_name, 0x00, sizeof(gs_msg_service_name));
    memset(gs_msg_send_subject, 0x00, sizeof(gs_msg_send_subject));

    UXML_get_service_from_subject(gs_msg_service_name, msg);

    //Add by J.S. 2011.11.08 Ignore some message
    //특정한 서비스가 호출될때 무시하게 하기 위한 코드임, message_callback과 연동되어 돌아 간다.
    tibrvMsg_GetString(msg, "_IS_IGNORE", &s_ignore);
    if(s_ignore != 0x00)
    {
        //Is called by message callback for preview
        if(strcmp(s_ignore, "?") == 0)
        {
            //Get Client ID
            memset(gs_client_id, 0x00, sizeof(gs_client_id));
            tibrvMsg_GetString(msg, "MsgHdrRequestor", &s_msg_requestor);
            if(s_msg_requestor != 0x00)
            {
                strcpy(gs_client_id, s_msg_requestor);
            }

            //Add ignore services here
            if(strcmp(gs_msg_service_name, "Activity") == 0)
            {
                tibrvMsg_UpdateString(msg, "_IS_IGNORE", "YES");
            }
            else
            {
                tibrvMsg_UpdateString(msg, "_IS_IGNORE", "NO");
            }

            return MP_TRUE;
        }
    }

    tibrvMsg_AddString(msg, MSG_SERVICE_NAME, gs_msg_service_name);

    //Except Activity service.
    if(strcmp(gs_msg_service_name, "Activity") == 0)
    {
        return MP_FALSE;
    }

    UXML_filter_calculation(gs_msg_service_name);

    return MP_TRUE;
}

int UCOM_epilogue_msg_1(tibrvMsg msg, char *need_sending_message, int *send_type)
{
    tibrv_status    status;
    char            *s_tmp;
    tibrv_u32       i_length;
    char            s_value[256];
    int             i_ret;
    int             i_len;

    *need_sending_message = 'N';
    *send_type = 0;

    if(msg != 0x00)
    {
        status = tibrvMsg_GetXml(msg, "XMLData", &s_tmp, &i_length);
        if(status == TIBRV_OK)
        {
            if(COM_search_string(s_tmp, i_length, "Reply.", 6) > 0)
            {
                /* Get subject to publish the reply message */
                memset(s_value, 0x00, sizeof(s_value));
                if(TRS.get_member(g_node_var, "PublishReplyChannel") == 0x00)
                {
                    /* Get Channel Prefix String */
                    i_ret = COM_get_init_value(gs_svr_file, "StartOption", "PublishReplyChannel", s_value, &i_len);
                    if(i_ret == MP_FALSE) 
                    {
                        LOG_head("UCOM_epilogue_msg : COM_get_init_value");
                        LOG_add("gs_svr_file", MP_NSTR, gs_svr_file);
                        LOG_add("s_key", MP_NSTR, "PublishReplyChannel");
                        COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
                    }

                    TRS.set_nstring(g_node_var, "PublishReplyChannel", s_value);
                }
                else
                {
                    TRS.get_string_param(g_node_var, "PublishReplyChannel", s_value);
                }

                if(COM_isnullspace(s_value) == MP_FALSE)
                {
                    if(COM_isnullspace(gs_msg_service_name) == MP_FALSE)
                    {
                        sprintf(s_value + strlen(s_value), ".%s", gs_msg_service_name);
                    }
                    else
                    {
                        sprintf(s_value + strlen(s_value), ".Unknown_Service");
                    }

                    if(TIBRV_OK == tibrvMsg_SetSendSubject(msg, s_value))
                    {
                        *need_sending_message = 'Y';
                        *send_type = 1;

                        /* send_type = 1 : publish */
                        /* send_type = 2 : request_no_reply */
                    }
                }
            }
        }
    }

    gs_msg_hdr_msg_id = 0x00;
    gs_msg_hdr_taid = 0x00;
    memset(gs_msg_service_name, 0x00, sizeof(gs_msg_service_name));

    return MP_TRUE;
}

void UXML_send_error_msg(int i_case, tibrvMsg msg_1, tibrvMsg *msg_2, char *s_err_msg)
{
    char            s_tmp[400];
    char            s_xml[10000];
    char            s_service[100];
    TRSNode         *p_reply;

    memset(s_tmp, 0x00, sizeof(s_tmp));

    switch(i_case)
    {
        case 1:
            sprintf(s_tmp, "Can't find MsgHdrRequestor");
            break;

        case 2:
            sprintf(s_tmp, "Can't find MsgHdrUserAccount");
            break;

        case 3:
            sprintf(s_tmp, "Can't find MsgHdrPassword");
            break;

        case 4:
            sprintf(s_tmp, "Can't find XMLData");
            break;

        case 5:
            sprintf(s_tmp, "Can't parse XML string");
            break;

        case 6:
            sprintf(s_tmp, "No match service name and sub type of the subject");
            break;


        case 999:
            sprintf(s_tmp, "%s", s_err_msg);
            break;
    }

    LOG_head("Custom XML : ERROR");
    LOG_add("message", MP_NSTR, s_tmp);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    memset(s_service, 0x00, sizeof(s_service));
    UXML_get_service_from_subject(s_service, msg_1);

    p_reply = TRS.create_node(s_service);
    
    TRS.add_status_value(p_reply, MP_FAIL_C);
    TRS.add_msgcode(p_reply, "-1");
    TRS.add_message(p_reply, s_tmp);
    TRS.add_msgcate(p_reply, MP_MSG_CATE_ERROR);

    UXML_to_xml_string(s_xml, p_reply);
    UXML_make_message(msg_2, s_xml);

    TRS.free_node(p_reply);
}

int UXML_make_message(tibrvMsg *msg, char *s_xml)
{
    char s_hostname[100];
    char s_requestor[255];
    char s_msg_id[255];
    char s_taid[255];

    memset(s_hostname, 0x00, sizeof(s_hostname));
    memset(s_requestor, 0x00, sizeof(s_requestor));
    memset(s_msg_id, 0x00, sizeof(s_msg_id));
    memset(s_taid, 0x00, sizeof(s_taid));

    UXML_gethostaddr(s_hostname, 100);
    sprintf(s_requestor, "MESplus/%s/%s/%.2s/%s", gs_server_name, gs_server_version, gs_subno, s_hostname);

    if(gs_msg_hdr_msg_id == 0x00)
    {
        sprintf(s_msg_id, "MES%d", gi_msg_seq++);
    }
    else
    {
        strcpy(s_msg_id, gs_msg_hdr_msg_id);
    }

    if(gs_msg_hdr_taid == 0x00)
    {
        sprintf(s_taid, "%s.%.2s.job01", gs_server_name, gs_subno);
    }
    else
    {
        if(COM_search_string(s_xml, (int)strlen(s_xml), "Reply.", 6) < 0)
        {
            sprintf(s_taid, "%s-%s.%.2s.job01", gs_msg_hdr_taid, gs_server_name, gs_subno);
        }
        else
        {
            strcpy(s_taid, gs_msg_hdr_taid);
        }
    }

    if (TIBRV_OK != tibrvMsg_Create(msg)) return MP_FALSE;
    if (TIBRV_OK == tibrvMsg_Reset(*msg))
    {
        char s_buff[255];

        tibrvMsg_AddString(*msg, "MsgHdrMsgId", s_msg_id);
        tibrvMsg_AddString(*msg, "MsgHdrTAID", s_taid);
        tibrvMsg_AddString(*msg, "MsgHdrRequestor", s_requestor);
        tibrvMsg_AddString(*msg, "MsgHdrUserAccount", "MESplus");

        memset(s_buff, 0x00, sizeof(s_buff));
        TRS_encrypt(s_buff, "MESplus");

        tibrvMsg_AddOpaque(*msg, "MsgHdrPassword", s_buff, (tibrv_u32)strlen(s_buff));
        tibrvMsg_AddXml   (*msg, "XMLData", s_xml, (tibrv_u32)strlen(s_xml));
    }

    if(COM_isnullspace(gs_msg_service_name) == MP_FALSE)
    {
        if(TRS.get_boolean(g_node_var, "SERVICE_CALCULATION") == MP_TRUE)
        {
            calcServiceCount();
        }
    }

    return MP_TRUE;
}

void UXML_get_object_from_subject(char *object_id, tibrvMsg msg)
{
    int i;
    int i_level;
    int i_start;
    int i_length;
    char *s_send_subject;

    tibrvMsg_GetSendSubject(msg, &s_send_subject);
    strcpy(gs_msg_send_subject, s_send_subject);

    i_level = 0;
    i_start = 0;
    i_length = 0;
    for(i = 0; i < (int)strlen(s_send_subject); i++)
    {
        if(s_send_subject[i] == '.')
            i_level++;

        if(i_level > 8)
        {
            break;
        }

        if(i_level > 7 && i_length == 1)
            i_start = i;

        if(i_level > 7)
            i_length++;
    }
    i_length -= 1;

    if(i_start > 0 && i_length > 0)
    {
        memcpy(object_id, s_send_subject + i_start, i_length);
    }
}

void UXML_get_service_from_subject(char *service_name, tibrvMsg msg)
{
    int i;
    int i_level;
    int i_start;
    int i_length;
    char *s_send_subject;

    tibrvMsg_GetSendSubject(msg, &s_send_subject);
    strcpy(gs_msg_send_subject, s_send_subject);

    i_level = 0;
    i_start = 0;
    i_length = 0;
    for(i = 0; i < (int)strlen(s_send_subject); i++)
    {
        if(s_send_subject[i] == '.')
            i_level++;

        if(i_level > 7)
        {
            break;
        }

        if(i_level > 6 && i_length == 1)
            i_start = i;

        if(i_level > 6)
            i_length++;
    }
    i_length -= 1;

    if(i_start > 0 && i_length > 0)
    {
        memcpy(service_name, s_send_subject + i_start, i_length);
    }
}

int UXML_is_req_rep_service_from_subject(tibrvMsg msg)
{
    int             i;
    int             i_level;
    int             i_start;
    int             i_length;
    char            s_msg_type[200];
    char            *s_send_subject;

    i_level = 0;
    i_start = 0;
    i_length = 0;
    memset(s_msg_type, 0x00, sizeof(s_msg_type));

    tibrvMsg_GetSendSubject(msg, &s_send_subject);

    for(i = 0; i < (int)strlen(s_send_subject); i++)
    {
        if(s_send_subject[i] == '.')
            i_level++;

        if(i_level > 6)
        {
            break;
        }

        if(i_level > 5 && i_length == 1)
            i_start = i;

        if(i_level > 5)
            i_length++;
    }
    i_length -= 1;

    if(i_start > 0 && i_length > 0)
    {
        memcpy(s_msg_type, s_send_subject + i_start, i_length);
    }

    if(memcmp(s_msg_type, "Command", strlen("Command")) == 0)
        return MP_TRUE;

    return MP_FALSE;
}

int UXML_compare_service_from_subject(char *service_name, tibrvMsg msg)
{
    char s_subtype[100];

    memset(s_subtype, 0x00, sizeof(s_subtype));
    UXML_get_service_from_subject(s_subtype, msg);

    if(strlen(s_subtype) > 0)
    {
        if(s_subtype[0] != '*' && s_subtype[0] != '>')
        {
            if(strcmp(s_subtype, service_name) != 0)
            {
                return MP_FALSE;
            }
        }
    }

    return MP_TRUE;
}


void UXML_gethostaddr(char* hostaddr, int len) 
{
    char s_hostname[128];
    struct in_addr addr;
    struct hostent* lpHostEnt;

    memset(s_hostname, 0x0, 128);
    memset(hostaddr, 0x0, len);
    gethostname(s_hostname, 128);
    lpHostEnt = gethostbyname(s_hostname);
    if(lpHostEnt)
    {
        if(0 != lpHostEnt->h_addr_list[0]) 
        {
            memcpy(&addr, lpHostEnt->h_addr_list[0], sizeof(struct in_addr));
            strcpy(hostaddr, inet_ntoa(addr)) ;
        }
    }
}

int UXML_check_allow_module(char *s_module)
{
    int i;
    int j;
    int k;
    int b_match;

    if(COM_isspace(gs_msg_send_subject, sizeof(gs_msg_send_subject)) == MP_TRUE)
        return MP_TRUE;

    b_match = MP_FALSE;
    for(i = 0; i < gi_channel_count; i++)
    {
        for(j = 0, k = 0; j < (int)strlen(ga_channel_mod[i].s_channel); j++, k++)
        {
            if(ga_channel_mod[i].s_channel[j] != gs_msg_send_subject[k])
            {
                if(ga_channel_mod[i].s_channel[j] == '>')
                {
                    b_match = MP_TRUE;
                    break;
                }
                else if(ga_channel_mod[i].s_channel[j] == '*')
                {
                    for( ;k < (int)strlen(gs_msg_send_subject); k++)
                    {
                        if(gs_msg_send_subject[k] == '.')
                        {
                            break;
                        }
                    }
                    k--;
                }
                else
                {
                    break;
                }
            }
        }

        if(b_match == MP_FALSE && j == (int)strlen(ga_channel_mod[i].s_channel))
        {
            b_match = MP_TRUE;
        }

        if(b_match == MP_TRUE)
        {
            break;
        }
    }

    if(b_match == MP_TRUE)
    {
        if(ga_channel_mod[i].i_allow_mod_count > 0)
        {
            for(j = 0; j < ga_channel_mod[i].i_allow_mod_count; j++)
            {
                if(strcmp(s_module, ga_channel_mod[i].s_allow_mod_list[j]) == 0)
                {
                    break;
                }
            }

            if(j == ga_channel_mod[i].i_allow_mod_count)
            {
                return MP_FALSE;
            }
        }
    }

    return MP_TRUE;
}

int UXML_check_service(TRSNode *in_node, char *s_msg)
{
    struct MSVMSVCDEF_TAG MSVMSVCDEF;
    char s_module[sizeof(MSVMSVCDEF.MODULE_NAME) + 1];
    char s_db_err_msg[MP_SIZE_DB_ERROR_MSG + 1];

    memset(s_db_err_msg, 0x00, sizeof(s_db_err_msg));

    //Except stop process service.
    if(strcmp(TRS.get_string(in_node, MSG_SERVICE_NAME), "Stop_Process") == 0)
    {
        if(TRS.get_member(in_node, MSG_MODULE_NAME) == 0x00)
        {
            TRS.add_nstring(in_node, MSG_MODULE_NAME, "MESplus");
        }
    }
    else
    {
        if(gc_db_connected == 'Y')
        {
            DBC_init_msvmsvcdef(&MSVMSVCDEF);
            TRS.copy(MSVMSVCDEF.SERVICE_NAME, sizeof(MSVMSVCDEF.SERVICE_NAME), in_node, MSG_SERVICE_NAME);
            
            DBC_select_msvmsvcdef(1, &MSVMSVCDEF);
            if(DB_error_code != DB_SUCCESS) 
            {
                memcpy(s_db_err_msg, DB_error_msg, MP_SIZE_DB_ERROR_MSG);
                COM_add_null(s_db_err_msg, MP_SIZE_DB_ERROR_MSG);

                sprintf(s_msg, "Can't find Service in the MSVMSVCDEF table. [%s], Error=[%s]", TRS.get_string(in_node, MSG_SERVICE_NAME), s_db_err_msg);

                if(gc_db_connected != 'Y')
                {
                    sprintf(s_msg, "Fatal database error is occured. Service=[%s], Error=[%s]", TRS.get_string(in_node, MSG_SERVICE_NAME), s_db_err_msg);
                }

                return MP_FALSE;
            }
        }
        else
        {
            memcpy(s_db_err_msg, DB_error_msg, MP_SIZE_DB_ERROR_MSG);
            COM_add_null(s_db_err_msg, MP_SIZE_DB_ERROR_MSG);
            sprintf(s_msg, "Fatal database error is occured. Service=[%s], Error=[%s]", TRS.get_string(in_node, MSG_SERVICE_NAME), s_db_err_msg);
            return MP_FALSE;
        }

        if(TRS.get_member(in_node, MSG_MODULE_NAME) == 0x00)
        {
            if(COM_isspace(MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMSVCDEF.SHARED_LIB_NAME)) == MP_TRUE)
            {
                TRS.add_string(in_node, MSG_MODULE_NAME, MSVMSVCDEF.MODULE_NAME, sizeof(MSVMSVCDEF.MODULE_NAME));
            }
            else
            {
                TRS.add_string(in_node, MSG_MODULE_NAME, MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMSVCDEF.SHARED_LIB_NAME));
            }
        }
        else if(TRS.mem_cmp(in_node, MSG_MODULE_NAME, MSVMSVCDEF.MODULE_NAME, sizeof(MSVMSVCDEF.MODULE_NAME)) == 0)
        {
            if(COM_isspace(MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMSVCDEF.SHARED_LIB_NAME)) == MP_FALSE)
            {
                TRS.set_string(in_node, MSG_MODULE_NAME, MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMSVCDEF.SHARED_LIB_NAME));
            }
        }
        else
        {
            if(COM_isspace(MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMSVCDEF.SHARED_LIB_NAME)) == MP_FALSE)
            {
                TRS.set_string(in_node, MSG_MODULE_NAME, MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMSVCDEF.SHARED_LIB_NAME));
            }
            else
            {
                TRS.set_string(in_node, MSG_MODULE_NAME, MSVMSVCDEF.MODULE_NAME, sizeof(MSVMSVCDEF.MODULE_NAME));
            }
        }

        if(TRS.get_member(in_node, "__REPLY_EXPECTED") == 0x00)
        {
            if(memcmp(MSVMSVCDEF.SERVICE_MODE, "RR", 2) == 0)
            {
                TRS.add_char(in_node, "__REPLY_EXPECTED", 'Y');
            }
        }
        else
        {
            if(TRS.get_char(in_node, "__REPLY_EXPECTED") == 'Y' && memcmp(MSVMSVCDEF.SERVICE_MODE, "RR", 2) != 0)
            {
                TRS.set_char(in_node, "__REPLY_EXPECTED", ' ');
                sprintf(s_msg, "No match service mode in the MSVMSVCDEF table.\nThis [%s] service is not Request-Reply mode, but called this mode.", 
                               TRS.get_string(in_node, MSG_SERVICE_NAME));
            }
        }

        memset(s_module, 0x00, sizeof(s_module));
        memcpy(s_module, MSVMSVCDEF.MODULE_NAME, sizeof(MSVMSVCDEF.MODULE_NAME));
        COM_add_null(s_module, sizeof(s_module));

        if(UXML_check_allow_module(s_module) == MP_FALSE)
        {
            sprintf(s_msg, "This service's module can't process in this server.\nService=[%s], Module=[%s]", 
                           TRS.get_string(in_node, MSG_SERVICE_NAME), s_module);
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

int UXML_filter_calculation(char *s_service_name)
{
    struct MSVMSVCDEF_TAG MSVMSVCDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    char s_service_start_time[18];

    TRS.set_boolean(g_node_var, "SERVICE_CALCULATION", MP_TRUE);

    if(gc_db_connected == 'Y')
    {
        DBC_init_msvmsvcdef(&MSVMSVCDEF);
        memcpy(MSVMSVCDEF.SERVICE_NAME, s_service_name, strlen(s_service_name));

        DBC_select_msvmsvcdef(1, &MSVMSVCDEF);
        if(DB_error_code == DB_SUCCESS) 
        {
            DBC_init_mgcmtbldat(&MGCMTBLDAT);
            memcpy(MGCMTBLDAT.FACTORY, CENTRAL_FACTORY, strlen(CENTRAL_FACTORY));
            memcpy(MGCMTBLDAT.TABLE_NAME, GCM_CALC_FILTER_MODULE, strlen(GCM_CALC_FILTER_MODULE));
            memcpy(MGCMTBLDAT.KEY_1, MSVMSVCDEF.MODULE_NAME, sizeof(MGCMTBLDAT.KEY_1));
    
            DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
            if(DB_error_code == DB_SUCCESS) 
            {
                /* Filter service count calculation */
                TRS.set_boolean(g_node_var, "SERVICE_CALCULATION", MP_FALSE);
                return MP_TRUE;
            }
        }
    }

    memset(s_service_start_time, 0x00, sizeof(s_service_start_time));
    //COM_get_date_time_msec_utc(s_service_start_time);
    COM_get_date_time_msec(s_service_start_time);
    TRS.set_nstring(g_node_var, "SERVICE_START_TIME", s_service_start_time);

    TRS.set_long(g_node_var, "TOTAL_SERVICE_CALL_COUNT", TRS.get_long(g_node_var, "TOTAL_SERVICE_CALL_COUNT") + 1);

    return MP_TRUE;
}

int UXML_get_msg_code_1(TRSNode *in_node,TRSNode *out_node)
{
    char dest[8] = {0};
    //char src[8] = {0};

    UXML_get_msg_code(dest,TRS.get_string(in_node,"src"));
    TRS.add_nstring(out_node,"dest",dest);
    return MP_TRUE;
}
#endif
