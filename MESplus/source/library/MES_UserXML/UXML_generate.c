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

#if defined(_H101)

int UCOM_generate_1(TRSNode *node, IOIMessage msg_1, IOIMessage *msg_2)
{
    /* Insert your code */
    return MP_TRUE;
}

#elif defined(_TIBRV)

void UXML_to_xml_string(char* xmlString, const TRSNode *node);
void UXML_set_out_binary_data(tibrvMsg *msg, TRSNode *node);

void handleMissingMsgCode(TRSNode *node)
{
    int language;
    char *msgCode;

    // If this check is "true", then node is a reply.
    if (TRS.get_member(node, OUT_STATUSVALUE) != NULL)
    {
        msgCode = TRS.get_string(node, OUT_MSGCODE);

        if (msgCode == 0 || strcmp(msgCode, "") == 0)
        {
            // Usually the name of the node is the core service.
            TRS.add_fieldmsg(node, "CORE_SERVICE_WITHOUT_MSGCODE", MP_STR, sizeof(node->Name), node->Name);

            language = TRS.get_language(node);
            if (language < '1' || language > '3')
            {
                language = '1';
            }

            COM_set_result(node, MP_FAIL_C, "SIL-0099", MP_MSG_CATE_ERROR, language);
        }
    }
}

int UCOM_generate_1(TRSNode *node, tibrvMsg msg_1, tibrvMsg *msg_2)
{
    char xml_string[MP_MAX_MSG_LENGTH];
    //char *xml_string = malloc(MP_MAX_MSG_LENGTH);

    // TODO use a smarter xml_string buffer in general (with dynamic size)
    // this is correct but fills 20MB fixed size for each request and reply 
    // memset(xml_string, '\0', MP_MAX_MSG_LENGTH);
    // this is wrong but fast ;-) fills only 4 or 8 bytes with zero
    memset(xml_string, '\0', 8);
    xml_string[sizeof(xml_string) - 1] = '\0';

    UXML_to_xml_string(xml_string, node);
    UXML_make_message(msg_2, xml_string);

    UXML_set_out_binary_data(msg_2, node);

    //free(xml_string);

    return MP_TRUE;
}

void UXML_set_out_binary_data(tibrvMsg *msg, TRSNode *node)
{
    unsigned char   *s_tmp;
    long            i_length;

    TRS.get_blob(node, MSG_BIN_DATA_1, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData1", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_2, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData2", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_3, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData3", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_4, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData4", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_5, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData5", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_6, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData6", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_7, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData7", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_8, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData8", s_tmp, i_length);
    }

    TRS.get_blob(node, MSG_BIN_DATA_9, &s_tmp, &i_length);
    if(s_tmp != 0x00)
    {
        tibrvMsg_AddOpaque(*msg, "BinaryData9", s_tmp, i_length);
    }
}

#endif
