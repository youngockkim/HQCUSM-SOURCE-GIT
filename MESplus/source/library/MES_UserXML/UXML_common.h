/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : UXML_common.h
    Description : user function prototype of user defined shared library

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

#ifndef _UXML_COMMON_H
#define _UXML_COMMON_H

#include <SLCCore_common.h>
#include <MESCore_common.h>

#define MAXIMUM_STRING_VALUE_BYTES      24001

#define MSG_MODULE_NAME                 ("_MODULE_NAME")
#define MSG_SERVICE_NAME                ("_SERVICE_NAME")

#if defined(_H101)
    #include <transceiverx.h>

    DllExport int UCOM_parse_1(TRSNode *node, IOIMessage msg_1, IOIMessage *msg_2);
    DllExport int UCOM_generate_1(TRSNode *node, IOIMessage msg_1, IOIMessage *msg_2);

#elif defined(_TIBRV)
    #include <tibrv.h>

    #define EXT_XML_TAG_ARRAY           "Array"
    #define EXT_XML_TAG_ITEM            "item"
    #define EXT_XML_TAG_ARRAYTYPE       "arrayType"
    #define EXT_XML_VALUE_TYPE_STRING   "A"
    #define EXT_XML_TAG_TYPE            "type"
    #define EXT_XML_TAG_SIZE            "size"

    #define GCM_ECD_TABLE               "MESSAGE_GROUP"
    #define GCM_CALC_FILTER_MODULE      "CALC_FLT_MODULE"

    #define MSG_BIN_DATA_1              "__BIN_DATA_1"
    #define MSG_BIN_DATA_2              "__BIN_DATA_2"
    #define MSG_BIN_DATA_3              "__BIN_DATA_3"
    #define MSG_BIN_DATA_4              "__BIN_DATA_4"
    #define MSG_BIN_DATA_5              "__BIN_DATA_5"
    #define MSG_BIN_DATA_6              "__BIN_DATA_6"
    #define MSG_BIN_DATA_7              "__BIN_DATA_7"
    #define MSG_BIN_DATA_8              "__BIN_DATA_8"
    #define MSG_BIN_DATA_9              "__BIN_DATA_9"

    char *gs_msg_hdr_msg_id;
    char *gs_msg_hdr_taid;
    int  gi_msg_seq;
    char gs_msg_service_name[101];
    char gs_msg_send_subject[MP_SIZE_CHANNEL];
    char gs_factory_code[11];

    struct UXML_ECD_TAG
    {
        char s_module[30];
        char s_value[30];
    };

    struct UXML_ECD_TAG gt_ecd_header[100];
    int                 gi_ecd_header_count;

    DllExport int UCOM_parse_1(TRSNode *node, tibrvMsg msg_1, tibrvMsg *msg_2);
    DllExport int UCOM_generate_1(TRSNode *node, tibrvMsg msg_1, tibrvMsg *msg_2);
    DllExport int UCOM_send_error_msg_1(TRSNode *node, tibrvMsg msg_1, tibrvMsg *msg_2);
    DllExport int UCOM_set_user_channel_1(char *s_module_name, char *s_service_name, char *channel, int mode);
    DllExport int UCOM_prologue_msg_1(tibrvMsg msg);
    DllExport int UCOM_epilogue_msg_1(tibrvMsg msg, char *need_sending_message, int *send_type);
    DllExport int UXML_get_msg_code_1(TRSNode *in_node,TRSNode *out_node);

    void UXML_send_error_msg(int i_case, tibrvMsg msg_1, tibrvMsg *msg_2, char *s_err_msg);
    void UXML_get_service_from_subject(char *service_name, tibrvMsg msg);
    void UXML_get_object_from_subject(char *object_id, tibrvMsg msg);
    int  UXML_compare_service_from_subject(char *service_name, tibrvMsg msg);
    int  UXML_is_req_rep_service_from_subject(tibrvMsg msg);
    int  UXML_parse(TRSNode *node, const char* xmlString, const size_t len, char* s_err_msg);
    int  UXML_make_message(tibrvMsg *msg, char *s_xml);
    void UXML_gethostaddr(char* hostaddr, int len);
    int  UXML_check_service(TRSNode *in_node, char *s_msg);
    void UXML_get_msg_code(char *s_dest, char *s_src);

#endif

#endif

