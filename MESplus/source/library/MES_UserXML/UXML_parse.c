/*******************************************************************************

    System      : MESplus
    Module      : User Routine for Custom XML
    File Name   : UXML_generate.c
    Description : User Routine for generate Custom XML format

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

#include "UXML_common.h"
#include <TRSCore_functions.h>

#if defined(_H101)

int UCOM_parse_1(TRSNode *node, IOIMessage msg_1, IOIMessage *msg_2)
{
    /* Insert your code */
    return MP_TRUE;
}

#elif defined(_TIBRV)

void UXML_get_in_binary_data(TRSNode *node, tibrvMsg msg);

int UCOM_parse_1(TRSNode *node, tibrvMsg msg_1, tibrvMsg *msg_2)
{
    tibrv_status    status;
    int             i_ret;

    char            *s_msg_requestor;
    char            *s_msg_account;
    char            *s_msg_password;
    char            *s_xml_string;
    char            *s_tmp;
    tibrv_u32       i_length;
    char            s_err_msg[400];
    char            s_obj_id[10];

    char            s_buff[255];
    char            s_buff_2[255];


    gs_msg_hdr_msg_id = 0x00;
    gs_msg_hdr_taid = 0x00;
    s_msg_requestor = 0x00;
    s_msg_account = 0x00;
    s_tmp = 0x00;
    s_msg_password = 0x00;
    s_xml_string = 0x00;
    i_length = 0;

    /* Request by Kinz, Roland 2009/05/13 */
    /* Modify to the "MsgHdrMsgID" field in Publish Reply messages has to be filled  with the INBOX. */
    //status = tibrvMsg_GetString(msg_1, "MsgHdrMsgId", &gs_msg_hdr_msg_id);

    //Modify by J.S. 2011.11.09 change log level
    status = tibrvMsg_GetReplySubject(msg_1, &gs_msg_hdr_msg_id);
    LOG_head("UCOM_parse_1");
    LOG_add("tibrv_status", MP_INT, status);
    LOG_add("MsgHdrMsgId", MP_NSTR, gs_msg_hdr_msg_id);
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    status = tibrvMsg_GetString(msg_1, "MsgHdrTAID", &gs_msg_hdr_taid);
    LOG_head("UCOM_parse_1");
    LOG_add("tibrv_status", MP_INT, status);
    LOG_add("MsgHdrTAID", MP_NSTR, gs_msg_hdr_taid);
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    status = tibrvMsg_GetString(msg_1, "MsgHdrRequestor", &s_msg_requestor);
    LOG_head("UCOM_parse_1");
    LOG_add("tibrv_status", MP_INT, status);
    LOG_add("MsgHdrRequestor", MP_NSTR, s_msg_requestor);
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    if(status != TIBRV_OK)
    {
        UXML_send_error_msg(1, msg_1, msg_2, "");
        return MP_FALSE;
    }

    memset(gs_client_id, 0x00, sizeof(gs_client_id));
    strcpy(gs_client_id, s_msg_requestor);

    status = tibrvMsg_GetString(msg_1, "MsgHdrUserAccount", &s_msg_account);
    if(status != TIBRV_OK)
    {
        UXML_send_error_msg(2, msg_1, msg_2, "");
        return MP_FALSE;
    }
    status = tibrvMsg_GetOpaque(msg_1, "MsgHdrPassword", &s_tmp, &i_length);
    if(status != TIBRV_OK)
    {
        UXML_send_error_msg(3, msg_1, msg_2, "");
        return MP_FALSE;
    }

    // Add decrypt logic for MsgHdrPassword
    memset(s_buff, 0x00, sizeof(s_buff));
    memset(s_buff_2, 0x00, sizeof(s_buff_2));

    memcpy(s_buff, s_tmp, i_length);
    TRS_decrypt(s_buff_2, s_buff);
    i_length = (int)strlen(s_buff_2);


    s_msg_password = (char*)malloc(i_length + 1);
    memset(s_msg_password, 0x00, i_length + 1);
    memcpy(s_msg_password, s_buff_2, i_length);


    status = tibrvMsg_GetXml   (msg_1, "XMLData", &s_tmp, &i_length);
    if(status != TIBRV_OK)
    {
        UXML_send_error_msg(4, msg_1, msg_2, "");
        free(s_msg_password);
        return MP_FALSE;
    }

    memset(s_obj_id, 0x00, sizeof(s_obj_id));
    UXML_get_object_from_subject(s_obj_id, msg_1);

    if(s_obj_id[0] != 0x00)
    {
        if(memcmp(s_obj_id, gs_subno, MP_SIZE_SUBNO) != 0)
        {
            free(s_msg_password);
            return MP_FALSE;
        }
    }

    s_xml_string = (char*)malloc(i_length + 1);
    memset(s_xml_string, 0x00, i_length + 1);
    memcpy(s_xml_string, s_tmp, i_length);

    memset(s_err_msg, 0x00, sizeof(s_err_msg));
    i_ret = UXML_parse(node, s_xml_string, strlen(s_xml_string), s_err_msg);
    if(i_ret < 1)
    {
        UXML_send_error_msg(999, msg_1, msg_2, s_err_msg);

        free(s_msg_password);
        free(s_xml_string);
        return MP_FALSE;
    }

    memset(gs_factory_code, 0x00, sizeof(gs_factory_code));
    memset(gs_msg_service_name, 0x00, sizeof(gs_msg_service_name));

    TRS.copy(gs_factory_code, sizeof(gs_factory_code) - 1, node, IN_FACTORY);
    TRS.copy(gs_msg_service_name, sizeof(gs_msg_service_name) - 1, node, MSG_SERVICE_NAME);

    COM_add_null(gs_factory_code, sizeof(gs_factory_code));
    COM_add_null(gs_msg_service_name, sizeof(gs_msg_service_name));

    if(TRS.get_member(node, IN_USERID) == 0x00)
        TRS.add_nstring(node, IN_USERID, s_msg_account);

    if(TRS.get_member(node, IN_PASSWORD) == 0x00)
        TRS.add_nstring(node, IN_PASSWORD, s_msg_password);

    if(TRS.get_member(node, IN_LANGUAGE) == 0x00)
        TRS.add_char(node, IN_LANGUAGE, gc_language_type);

    free(s_msg_password);
    free(s_xml_string);

    //if(UXML_is_req_rep_service_from_subject(msg_1) == MP_TRUE)
    //{
    //    TRS.add_char(node, "__REPLY_EXPECTED", 'Y');
    //}

    if(UXML_compare_service_from_subject(gs_msg_service_name, msg_1) == MP_FALSE)
    {
        UXML_send_error_msg(6, msg_1, msg_2, "");
        return MP_FALSE;
    }

    memset(s_err_msg, 0x00, sizeof(s_err_msg));
    if(UXML_check_service(node, s_err_msg) == MP_FALSE)
    {
        UXML_send_error_msg(999, msg_1, msg_2, s_err_msg);
        return MP_FALSE;
    }
    if(COM_isspace(s_err_msg, sizeof(s_err_msg)) == MP_FALSE)
    {
        LOG_head("UCOM_parse_1");
        LOG_add("Message", MP_STR, sizeof(s_err_msg), s_err_msg);
        COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
    }

    if(TRS.str_cmp(node, MSG_SERVICE_NAME, "getActivity") == 0 && TRS.str_cmp(node, MSG_MODULE_NAME, "getActivity") == 0)
    {
        return MP_FALSE;
    }

    UXML_get_in_binary_data(node, msg_1);

    return MP_TRUE;
}

void UXML_get_in_binary_data(TRSNode *node, tibrvMsg msg)
{
    tibrv_status    status;
    unsigned char   *s_tmp;
    tibrv_u32       i_length;

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData1", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_1, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData2", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_2, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData3", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_3, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData4", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_4, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData5", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_5, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData6", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_6, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData7", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_7, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData8", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_8, s_tmp, i_length);
    }

    s_tmp = 0x00;
    i_length = 0;
    status = tibrvMsg_GetOpaque(msg, "BinaryData9", &s_tmp, &i_length);
    if(status == TIBRV_OK)
    {
        TRS.add_blob(node, MSG_BIN_DATA_9, s_tmp, i_length);
    }
}

#endif
