/*******************************************************************************

    System      : MESplus
    Module      : User Routine for Common
    File Name   : UCMN_server_start.c
    Description : User Routine for UCMN_server_start

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2015/08/28  Miracom        Create

    Copyright(C) 1998-2015 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "UALM_common.h"

#define MP_MAX_CONTENTS_SIZE            100100
#define MP_CONTENTS_TEMPLATE_FILE_NAME  "mail_contents_template.html"

/*
    // reference members for this file
    TRS.add_object(in_node, "MALMMSGHIS_TAG", MALMMSGHIS);
    TRS.add_object(in_node, "MALMMSGDEF_TAG", MALMMSGDEF);
    TRS.add_object(in_node, "ALARM_USER_TAGS", ALARM_USER);
    TRS.add_int(in_node, "USER_COUNT", i_user_count);
    
    // reference members in caller function
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    char *s_contents = TRS.get_string(out_node, "MAIL_CONTENTS");
*/

int UALM_generate_custom_contents(TRSNode *in_node, TRSNode *out_node);
int UALM_load_custom_contents_by_template(TRSNode *in_node, char *s_contents);
int UALM_load_custom_contents_by_logic(TRSNode *in_node, char *s_contents);
void UALM_fill_custom_value_to_node(struct MALMMSGHIS_TAG *MALMMSGHIS, struct MALMMSGDEF_TAG *MALMMSGDEF, TRSNode *node);

int UALM_Proc_Custom_Mail_Contents_1(TRSNode *in_node, TRSNode *out_node)
{
    if(UALM_generate_custom_contents(in_node, out_node) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

int UALM_generate_custom_contents(TRSNode *in_node, TRSNode *out_node)
{
    char s_contents[MP_MAX_CONTENTS_SIZE];
    
    if(UALM_load_custom_contents_by_template(in_node, s_contents) == MP_TRUE)
    {
        TRS.add_nstring(out_node, "MAIL_CONTENTS", s_contents);
        return MP_TRUE;
    }

    if(UALM_load_custom_contents_by_logic(in_node, s_contents) == MP_TRUE)
    {
        TRS.add_nstring(out_node, "MAIL_CONTENTS", s_contents);
        return MP_TRUE;
    }

    LOG_head("UALM_generate_custom_contents : Error Generate Custom Contents for Mail");
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
    return MP_FALSE;
}

int UALM_read_template_file(struct MALMMSGDEF_TAG *MALMMSGDEF, char *s_contents)
{
    if(TRS.get_member(g_node_var, "AlarmMailContentsTemplate") == 0x00)
    {
        FILE *fp;
        char *s_point;

        char s_template_path[1000];
        char s_template_file[1000];
        char s_template_file_name[31];
        char s_buffer[1024];
        int  i_ret;
        int  i_len;

        memset(s_template_path, 0x00, sizeof(s_template_path));
        i_ret = COM_get_init_value(gs_com_file, "Alarm", "MESplusCustomContentsTemplateDir", s_template_path, &i_len);
        if(i_ret == MP_FALSE) 
        {
            LOG_head("UALM_read_template_file : COM_get_init_value");
            LOG_add("gs_com_file", MP_NSTR, gs_com_file);
            LOG_add("s_key", MP_NSTR, "MESplusCustomContentsTemplateDir");
            COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        strcpy(s_template_file_name, MP_CONTENTS_TEMPLATE_FILE_NAME);
        if(COM_isnullspace(MALMMSGDEF->ALARM_CMF_10) == MP_FALSE)
        {
            char s_tmp[31];
             // Template file name for the alarm id
			memset(s_tmp, 0x00, sizeof(s_tmp));
            COM_memcpy_add_null(s_tmp, MALMMSGDEF->ALARM_CMF_10, sizeof(MALMMSGDEF->ALARM_CMF_10));
            strcpy(s_template_file_name, s_tmp);
        }

#if defined(WIN32) || defined(WIN64)
        sprintf(s_template_file, "%s\\%s", s_template_path, s_template_file_name);
#else
        sprintf(s_template_file, "%s/%s", s_template_path, s_template_file_name);
#endif

        fp = fopen(s_template_file, "r");
        if(fp == NULL)
        {
            LOG_head("UALM_read_template_file : Can not open the template file...");
            LOG_add("template file", MP_NSTR, s_template_file);
            COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        s_point = s_contents;

        while(!feof(fp))
        {
            fgets(s_buffer, sizeof(s_buffer) - 1, fp);

            strcpy(s_point, s_buffer);
            s_point += strlen(s_buffer);
        }
        fclose(fp);

        TRS.set_nstring(g_node_var, "AlarmMailContentsTemplate", s_contents);
    }
    else
    {
        strcpy(s_contents, TRS.get_string(g_node_var, "AlarmMailContentsTemplate"));
    }

    return MP_TRUE;
}

void UALM_fill_alarm_value_to_node(struct MALMMSGHIS_TAG *MALMMSGHIS, struct MALMMSGDEF_TAG *MALMMSGDEF, TRSNode *node)
{
    TRS.add_string(node, "ALARM_ID", MALMMSGDEF->ALARM_ID, sizeof(MALMMSGDEF->ALARM_ID));
    TRS.add_string(node, "ALARM_DESC", MALMMSGDEF->ALARM_DESC, sizeof(MALMMSGDEF->ALARM_DESC));

    TRS.add_char  (node, "ALARM_TYPE", MALMMSGDEF->ALARM_TYPE);
    TRS.add_char  (node, "ALARM_LEVEL_FLAG", MALMMSGDEF->ALARM_LEVEL_FLAG);
    TRS.add_char  (node, "SEND_TO_USER_FLAG", MALMMSGDEF->SEND_TO_USER_FLAG);
    TRS.add_char  (node, "ACTION_DISPLAY_FLAG", MALMMSGDEF->ACTION_DISPLAY_FLAG);
    TRS.add_char  (node, "ACTION_MAIL_FLAG", MALMMSGDEF->ACTION_MAIL_FLAG);
    TRS.add_char  (node, "ACTION_MSG_FLAG", MALMMSGDEF->ACTION_MSG_FLAG);
    TRS.add_string(node, "ALARM_LOT_ACTION", MALMMSGDEF->ALARM_LOT_ACTION, sizeof(MALMMSGDEF->ALARM_LOT_ACTION));

    TRS.add_string(node, "HOLD_CODE", MALMMSGDEF->HOLD_CODE, sizeof(MALMMSGDEF->HOLD_CODE));

    TRS.add_string(node, "MAT_ID", MALMMSGDEF->MAT_ID, sizeof(MALMMSGDEF->MAT_ID));
    TRS.add_string(node, "FLOW", MALMMSGDEF->FLOW, sizeof(MALMMSGDEF->FLOW));
    TRS.add_int   (node, "FLOW_SEQ_NUM", MALMMSGDEF->FLOW_SEQ_NUM);
    TRS.add_string(node, "OPER", MALMMSGDEF->OPER, sizeof(MALMMSGDEF->OPER));

    TRS.add_string(node, "RWK_CODE", MALMMSGDEF->RWK_CODE, sizeof(MALMMSGDEF->RWK_CODE));
    TRS.add_string(node, "RWK_FLOW", MALMMSGDEF->RWK_FLOW, sizeof(MALMMSGDEF->RWK_FLOW));
    TRS.add_int   (node, "RWK_FLOW_SEQ_NUM", MALMMSGDEF->RWK_FLOW_SEQ_NUM);
    TRS.add_string(node, "RWK_OPER", MALMMSGDEF->RWK_OPER, sizeof(MALMMSGDEF->RWK_OPER));
    TRS.add_string(node, "RWK_STOP_OPER", MALMMSGDEF->RWK_STOP_OPER, sizeof(MALMMSGDEF->RWK_STOP_OPER));
    TRS.add_string(node, "RET_FLOW", MALMMSGDEF->RET_FLOW, sizeof(MALMMSGDEF->RET_FLOW));
    TRS.add_int   (node, "RET_FLOW_SEQ_NUM", MALMMSGDEF->RET_FLOW_SEQ_NUM);
    TRS.add_string(node, "RET_OPER", MALMMSGDEF->RET_OPER, sizeof(MALMMSGDEF->RET_OPER));
    TRS.add_char  (node, "RET_CLEAR_FLAG", MALMMSGDEF->RET_CLEAR_FLAG);

    TRS.add_string(node, "CMF_1", MALMMSGDEF->CMF_1, sizeof(MALMMSGDEF->CMF_1));
    TRS.add_string(node, "CMF_2", MALMMSGDEF->CMF_2, sizeof(MALMMSGDEF->CMF_2));
    TRS.add_string(node, "CMF_3", MALMMSGDEF->CMF_3, sizeof(MALMMSGDEF->CMF_3));
    TRS.add_string(node, "CMF_4", MALMMSGDEF->CMF_4, sizeof(MALMMSGDEF->CMF_4));
    TRS.add_string(node, "CMF_5", MALMMSGDEF->CMF_5, sizeof(MALMMSGDEF->CMF_5));
    TRS.add_string(node, "CMF_6", MALMMSGDEF->CMF_6, sizeof(MALMMSGDEF->CMF_6));
    TRS.add_string(node, "CMF_7", MALMMSGDEF->CMF_7, sizeof(MALMMSGDEF->CMF_7));
    TRS.add_string(node, "CMF_8", MALMMSGDEF->CMF_8, sizeof(MALMMSGDEF->CMF_8));
    TRS.add_string(node, "CMF_9", MALMMSGDEF->CMF_9, sizeof(MALMMSGDEF->CMF_9));
    TRS.add_string(node, "CMF_10", MALMMSGDEF->CMF_10, sizeof(MALMMSGDEF->CMF_10));
    TRS.add_string(node, "LOT_COMMENT", MALMMSGDEF->LOT_COMMENT, sizeof(MALMMSGDEF->LOT_COMMENT));
    TRS.add_string(node, "EVENT_ID", MALMMSGDEF->EVENT_ID, sizeof(MALMMSGDEF->EVENT_ID));
    TRS.add_string(node, "CHG_STS_1", MALMMSGDEF->CHG_STS_1, sizeof(MALMMSGDEF->CHG_STS_1));
    TRS.add_string(node, "CHG_STS_2", MALMMSGDEF->CHG_STS_2, sizeof(MALMMSGDEF->CHG_STS_2));
    TRS.add_string(node, "CHG_STS_3", MALMMSGDEF->CHG_STS_3, sizeof(MALMMSGDEF->CHG_STS_3));
    TRS.add_string(node, "CHG_STS_4", MALMMSGDEF->CHG_STS_4, sizeof(MALMMSGDEF->CHG_STS_4));
    TRS.add_string(node, "CHG_STS_5", MALMMSGDEF->CHG_STS_5, sizeof(MALMMSGDEF->CHG_STS_5));
    TRS.add_string(node, "CHG_STS_6", MALMMSGDEF->CHG_STS_6, sizeof(MALMMSGDEF->CHG_STS_6));
    TRS.add_string(node, "CHG_STS_7", MALMMSGDEF->CHG_STS_7, sizeof(MALMMSGDEF->CHG_STS_7));
    TRS.add_string(node, "CHG_STS_8", MALMMSGDEF->CHG_STS_8, sizeof(MALMMSGDEF->CHG_STS_8));
    TRS.add_string(node, "CHG_STS_9", MALMMSGDEF->CHG_STS_9, sizeof(MALMMSGDEF->CHG_STS_9));
    TRS.add_string(node, "CHG_STS_10", MALMMSGDEF->CHG_STS_10, sizeof(MALMMSGDEF->CHG_STS_10));
    TRS.add_string(node, "RES_COMMENT", MALMMSGDEF->RES_COMMENT, sizeof(MALMMSGDEF->RES_COMMENT));
    TRS.add_string(node, "CLEAR_EVENT_ID", MALMMSGDEF->CLEAR_EVENT_ID, sizeof(MALMMSGDEF->CLEAR_EVENT_ID));
    TRS.add_string(node, "CLEAR_CHG_STS_1", MALMMSGDEF->CLEAR_CHG_STS_1, sizeof(MALMMSGDEF->CLEAR_CHG_STS_1));
    TRS.add_string(node, "CLEAR_CHG_STS_2", MALMMSGDEF->CLEAR_CHG_STS_2, sizeof(MALMMSGDEF->CLEAR_CHG_STS_2));
    TRS.add_string(node, "CLEAR_CHG_STS_3", MALMMSGDEF->CLEAR_CHG_STS_3, sizeof(MALMMSGDEF->CLEAR_CHG_STS_3));
    TRS.add_string(node, "CLEAR_CHG_STS_4", MALMMSGDEF->CLEAR_CHG_STS_4, sizeof(MALMMSGDEF->CLEAR_CHG_STS_4));
    TRS.add_string(node, "CLEAR_CHG_STS_5", MALMMSGDEF->CLEAR_CHG_STS_5, sizeof(MALMMSGDEF->CLEAR_CHG_STS_5));
    TRS.add_string(node, "CLEAR_CHG_STS_6", MALMMSGDEF->CLEAR_CHG_STS_6, sizeof(MALMMSGDEF->CLEAR_CHG_STS_6));
    TRS.add_string(node, "CLEAR_CHG_STS_7", MALMMSGDEF->CLEAR_CHG_STS_7, sizeof(MALMMSGDEF->CLEAR_CHG_STS_7));
    TRS.add_string(node, "CLEAR_CHG_STS_8", MALMMSGDEF->CLEAR_CHG_STS_8, sizeof(MALMMSGDEF->CLEAR_CHG_STS_8));
    TRS.add_string(node, "CLEAR_CHG_STS_9", MALMMSGDEF->CLEAR_CHG_STS_9, sizeof(MALMMSGDEF->CLEAR_CHG_STS_9));
    TRS.add_string(node, "CLEAR_CHG_STS_10", MALMMSGDEF->CLEAR_CHG_STS_10, sizeof(MALMMSGDEF->CLEAR_CHG_STS_10));
    TRS.add_string(node, "CLEAR_RES_COMMENT", MALMMSGDEF->CLEAR_RES_COMMENT, sizeof(MALMMSGDEF->CLEAR_RES_COMMENT));

    TRS.add_string(node, "ALARM_CMF_1", MALMMSGDEF->ALARM_CMF_1, sizeof(MALMMSGDEF->ALARM_CMF_1));
    TRS.add_string(node, "ALARM_CMF_2", MALMMSGDEF->ALARM_CMF_2, sizeof(MALMMSGDEF->ALARM_CMF_2));
    TRS.add_string(node, "ALARM_CMF_3", MALMMSGDEF->ALARM_CMF_3, sizeof(MALMMSGDEF->ALARM_CMF_3));
    TRS.add_string(node, "ALARM_CMF_4", MALMMSGDEF->ALARM_CMF_4, sizeof(MALMMSGDEF->ALARM_CMF_4));
    TRS.add_string(node, "ALARM_CMF_5", MALMMSGDEF->ALARM_CMF_5, sizeof(MALMMSGDEF->ALARM_CMF_5));
    TRS.add_string(node, "ALARM_CMF_6", MALMMSGDEF->ALARM_CMF_6, sizeof(MALMMSGDEF->ALARM_CMF_6));
    TRS.add_string(node, "ALARM_CMF_7", MALMMSGDEF->ALARM_CMF_7, sizeof(MALMMSGDEF->ALARM_CMF_7));
    TRS.add_string(node, "ALARM_CMF_8", MALMMSGDEF->ALARM_CMF_8, sizeof(MALMMSGDEF->ALARM_CMF_8));
    TRS.add_string(node, "ALARM_CMF_9", MALMMSGDEF->ALARM_CMF_9, sizeof(MALMMSGDEF->ALARM_CMF_9));
    TRS.add_string(node, "ALARM_CMF_10", MALMMSGDEF->ALARM_CMF_10, sizeof(MALMMSGDEF->ALARM_CMF_10));
    TRS.add_string(node, "ALARM_CMF_11", MALMMSGDEF->ALARM_CMF_11, sizeof(MALMMSGDEF->ALARM_CMF_11));
    TRS.add_string(node, "ALARM_CMF_12", MALMMSGDEF->ALARM_CMF_12, sizeof(MALMMSGDEF->ALARM_CMF_12));
    TRS.add_string(node, "ALARM_CMF_13", MALMMSGDEF->ALARM_CMF_13, sizeof(MALMMSGDEF->ALARM_CMF_13));
    TRS.add_string(node, "ALARM_CMF_14", MALMMSGDEF->ALARM_CMF_14, sizeof(MALMMSGDEF->ALARM_CMF_14));
    TRS.add_string(node, "ALARM_CMF_15", MALMMSGDEF->ALARM_CMF_15, sizeof(MALMMSGDEF->ALARM_CMF_15));
    TRS.add_string(node, "ALARM_CMF_16", MALMMSGDEF->ALARM_CMF_16, sizeof(MALMMSGDEF->ALARM_CMF_16));
    TRS.add_string(node, "ALARM_CMF_17", MALMMSGDEF->ALARM_CMF_17, sizeof(MALMMSGDEF->ALARM_CMF_17));
    TRS.add_string(node, "ALARM_CMF_18", MALMMSGDEF->ALARM_CMF_18, sizeof(MALMMSGDEF->ALARM_CMF_18));
    TRS.add_string(node, "ALARM_CMF_19", MALMMSGDEF->ALARM_CMF_19, sizeof(MALMMSGDEF->ALARM_CMF_19));
    TRS.add_string(node, "ALARM_CMF_20", MALMMSGDEF->ALARM_CMF_20, sizeof(MALMMSGDEF->ALARM_CMF_20));
    
    TRS.add_string(node, "ALARM_GRP_1", MALMMSGDEF->ALARM_GRP_1, sizeof(MALMMSGDEF->ALARM_GRP_1));
    TRS.add_string(node, "ALARM_GRP_2", MALMMSGDEF->ALARM_GRP_2, sizeof(MALMMSGDEF->ALARM_GRP_2));
    TRS.add_string(node, "ALARM_GRP_3", MALMMSGDEF->ALARM_GRP_3, sizeof(MALMMSGDEF->ALARM_GRP_3));
    TRS.add_string(node, "ALARM_GRP_4", MALMMSGDEF->ALARM_GRP_4, sizeof(MALMMSGDEF->ALARM_GRP_4));
    TRS.add_string(node, "ALARM_GRP_5", MALMMSGDEF->ALARM_GRP_5, sizeof(MALMMSGDEF->ALARM_GRP_5));
    TRS.add_string(node, "ALARM_GRP_6", MALMMSGDEF->ALARM_GRP_6, sizeof(MALMMSGDEF->ALARM_GRP_6));
    TRS.add_string(node, "ALARM_GRP_7", MALMMSGDEF->ALARM_GRP_7, sizeof(MALMMSGDEF->ALARM_GRP_7));
    TRS.add_string(node, "ALARM_GRP_8", MALMMSGDEF->ALARM_GRP_8, sizeof(MALMMSGDEF->ALARM_GRP_8));
    TRS.add_string(node, "ALARM_GRP_9", MALMMSGDEF->ALARM_GRP_9, sizeof(MALMMSGDEF->ALARM_GRP_9));
    TRS.add_string(node, "ALARM_GRP_10", MALMMSGDEF->ALARM_GRP_10, sizeof(MALMMSGDEF->ALARM_GRP_10));

    TRS.add_string(node, "CREATE_USER_ID", MALMMSGDEF->CREATE_USER_ID, sizeof(MALMMSGDEF->CREATE_USER_ID));
    TRS.add_string(node, "CREATE_TIME", MALMMSGDEF->CREATE_TIME, sizeof(MALMMSGDEF->CREATE_TIME));
    TRS.add_string(node, "UPDATE_USER_ID", MALMMSGDEF->UPDATE_USER_ID, sizeof(MALMMSGDEF->UPDATE_USER_ID));
    TRS.add_string(node, "UPDATE_TIME", MALMMSGDEF->UPDATE_TIME, sizeof(MALMMSGDEF->UPDATE_TIME));


    TRS.add_string(node, "FACTORY", MALMMSGHIS->FACTORY, sizeof(MALMMSGHIS->FACTORY));
    TRS.add_string(node, "TRAN_TIME", MALMMSGHIS->TRAN_TIME, sizeof(MALMMSGHIS->TRAN_TIME));
    TRS.add_string(node, "LOT_ID", MALMMSGHIS->LOT_ID, sizeof(MALMMSGHIS->LOT_ID));
    TRS.add_int   (node, "LOT_HIST_SEQ", MALMMSGHIS->LOT_HIST_SEQ);
    TRS.add_string(node, "RES_ID", MALMMSGHIS->RES_ID, sizeof(MALMMSGHIS->RES_ID));
    TRS.add_int   (node, "RES_HIST_SEQ", MALMMSGHIS->RES_HIST_SEQ);
    TRS.add_string(node, "AREA_ID", MALMMSGHIS->AREA_ID, sizeof(MALMMSGHIS->AREA_ID));
    TRS.add_string(node, "SUB_AREA_ID", MALMMSGHIS->SUB_AREA_ID, sizeof(MALMMSGHIS->SUB_AREA_ID));
    TRS.add_string(node, "SOURCE_ID_1", MALMMSGHIS->SOURCE_ID_1, sizeof(MALMMSGHIS->SOURCE_ID_1));
    TRS.add_string(node, "SOURCE_DESC_1", MALMMSGHIS->SOURCE_DESC_1, sizeof(MALMMSGHIS->SOURCE_DESC_1));
    TRS.add_string(node, "SOURCE_ID_2", MALMMSGHIS->SOURCE_ID_2, sizeof(MALMMSGHIS->SOURCE_ID_2));
    TRS.add_string(node, "SOURCE_DESC_2", MALMMSGHIS->SOURCE_DESC_2, sizeof(MALMMSGHIS->SOURCE_DESC_2));
    TRS.add_string(node, "SOURCE_ID_3", MALMMSGHIS->SOURCE_ID_3, sizeof(MALMMSGHIS->SOURCE_ID_3));
    TRS.add_string(node, "SOURCE_DESC_3", MALMMSGHIS->SOURCE_DESC_3, sizeof(MALMMSGHIS->SOURCE_DESC_3));
    TRS.add_string(node, "ALARM_SUBJECT", MALMMSGHIS->ALARM_SUBJECT, sizeof(MALMMSGHIS->ALARM_SUBJECT));
    TRS.add_string(node, "ALARM_MSG", MALMMSGHIS->ALARM_MSG, sizeof(MALMMSGHIS->ALARM_MSG));
    TRS.add_string(node, "ALARM_COMMENT_1", MALMMSGHIS->ALARM_COMMENT_1, sizeof(MALMMSGHIS->ALARM_COMMENT_1));
    TRS.add_string(node, "ALARM_COMMENT_2", MALMMSGHIS->ALARM_COMMENT_2, sizeof(MALMMSGHIS->ALARM_COMMENT_2));
    TRS.add_string(node, "ALARM_COMMENT_3", MALMMSGHIS->ALARM_COMMENT_3, sizeof(MALMMSGHIS->ALARM_COMMENT_3));
    TRS.add_string(node, "ALARM_COMMENT_4", MALMMSGHIS->ALARM_COMMENT_4, sizeof(MALMMSGHIS->ALARM_COMMENT_4));
    TRS.add_string(node, "ALARM_COMMENT_5", MALMMSGHIS->ALARM_COMMENT_5, sizeof(MALMMSGHIS->ALARM_COMMENT_5));
    TRS.add_string(node, "PDF_FILE_NAME", MALMMSGHIS->PDF_FILE_NAME, sizeof(MALMMSGHIS->PDF_FILE_NAME));
    TRS.add_string(node, "IMAGE_FILE_NAME", MALMMSGHIS->IMAGE_FILE_NAME, sizeof(MALMMSGHIS->IMAGE_FILE_NAME));
}

char *UALM_add_contents(char *s_container, char *s_string)
{
    size_t i_len;

	sprintf(s_container, "%s", s_string);
    i_len = strlen(s_string);

    return s_container + i_len;
}

int UALM_replace_value_in_template(struct MALMMSGHIS_TAG *MALMMSGHIS, struct MALMMSGDEF_TAG *MALMMSGDEF, char *s_contents)
{
    char s_contents_temp[MP_MAX_CONTENTS_SIZE];
    char *s_point;
    int  i, i_contents_len;
    int  b_start;

    char s_key[100];
    char s_str[4001];
    int  i_key_idx;

    TRSNode *alm_value_node;
    TRSNode *member;

    alm_value_node = TRS.create_node("ALARM_VALUE_NODE");
    UALM_fill_alarm_value_to_node(MALMMSGHIS, MALMMSGDEF, alm_value_node);
    UALM_fill_custom_value_to_node(MALMMSGHIS, MALMMSGDEF, alm_value_node);

    s_point = s_contents_temp;
    i_contents_len = (int)strlen(s_contents);
    b_start = MP_FALSE;

    for(i = 0; i < i_contents_len; i++)
    {
        if(s_contents[i] == '%' && i + 1 < i_contents_len && s_contents[i + 1] == '%')
        {
            if(b_start == MP_FALSE)
            {
                b_start = MP_TRUE;
                memset(s_key, 0x00, sizeof(s_key));
                i_key_idx = 0;
            }
            else
            {
                s_str[0] = 0x00;
                member = TRS.get_member(alm_value_node, s_key);

                if(member != 0x00)
                {
                    switch(member->ValueType)
                    {
                    case DT_STRING:
                    case DT_NSTRING:
                        strcpy(s_str, member->Value.s);
                        break;
                    case DT_CHAR:
                        sprintf(s_str, "%c", member->Value.c);
                        break;
                    case DT_BINARY:
                        sprintf(s_str, "%d", member->Value.u1);
                        break;
                    case DT_BOOLEAN:
                        if(member->Value.i4 == 1)
                            sprintf(s_str, "TRUE");
                        else
                            sprintf(s_str, "FALSE");
                        break;
                    case DT_UBYTE:
                        sprintf(s_str, "%d", member->Value.u1);
                        break;
                    case DT_USHORT:
                        sprintf(s_str, "%d", member->Value.u2);
                        break;
                    case DT_UINT:
                        sprintf(s_str, "%lu", member->Value.u4);
                        break;
                    case DT_ULONG:
                        sprintf(s_str, "%lu", member->Value.u8);
                        break;
                    case DT_FLOAT:
                        sprintf(s_str, "%f", member->Value.f4);
                        break;
                    case DT_DOUBLE:
                        sprintf(s_str, "%f", member->Value.f8);
                        break;
                    case DT_BYTE:
                        sprintf(s_str, "%d", member->Value.c);
                        break;
                    case DT_SHORT:
                        sprintf(s_str, "%d", member->Value.i2);
                        break;
                    case DT_INT:
                        sprintf(s_str, "%d", member->Value.i4);
                        break;
                    case DT_LONG:
                        sprintf(s_str, "%ld", member->Value.i8);
                        break;
                    default:
                        break;
                    }
                }

                s_point = UALM_add_contents(s_point, s_str);
                b_start = MP_FALSE;
            }

            i++;
        }
        else if(b_start == MP_TRUE)
        {
            s_key[i_key_idx++] = s_contents[i];
        }
        else
        {
            s_point[0] = s_contents[i];
            s_point += 1;
        }
    }
    s_point[0] = 0x00;
    TRS.free_node(alm_value_node);

    strcpy(s_contents, s_contents_temp);

    return MP_TRUE;
}

int UALM_load_custom_contents_by_template(TRSNode *in_node, char *s_contents)
{
    struct MALMMSGHIS_TAG *MALMMSGHIS;
    struct MALMMSGDEF_TAG *MALMMSGDEF;

    MALMMSGHIS = (struct MALMMSGHIS_TAG *)TRS.get_object(in_node, "MALMMSGHIS_TAG");
    MALMMSGDEF = (struct MALMMSGDEF_TAG *)TRS.get_object(in_node, "MALMMSGDEF_TAG");

    LOG_head("UALM_load_custom_contents_by_template : Start Logic");
    LOG_add("FACTORY", MP_STR, sizeof(MALMMSGHIS->FACTORY), MALMMSGHIS->FACTORY);
    LOG_add("ALARM_ID", MP_STR, sizeof(MALMMSGHIS->ALARM_ID), MALMMSGHIS->ALARM_ID);
    LOG_add("SOURCE_ID_1", MP_STR, sizeof(MALMMSGHIS->SOURCE_ID_1), MALMMSGHIS->SOURCE_ID_1);
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    if(UALM_read_template_file(MALMMSGDEF, s_contents) == MP_FALSE)
    {
        return MP_FALSE;
    }

    if(COM_isnullspace(s_contents) == MP_TRUE && strlen(s_contents) < 1)
    {
        return MP_FALSE;
    }

    if(UALM_replace_value_in_template(MALMMSGHIS, MALMMSGDEF, s_contents) == MP_FALSE)
    {
        return MP_FALSE;
    }

    LOG_head("UALM_load_custom_contents_by_template : Finish Logic");
    LOG_add("FACTORY", MP_STR, sizeof(MALMMSGHIS->FACTORY), MALMMSGHIS->FACTORY);
    LOG_add("ALARM_ID", MP_STR, sizeof(MALMMSGHIS->ALARM_ID), MALMMSGHIS->ALARM_ID);
    LOG_add("SOURCE_ID_1", MP_STR, sizeof(MALMMSGHIS->SOURCE_ID_1), MALMMSGHIS->SOURCE_ID_1);
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    COM_long_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM, "UALM_load_custom_contents_by_template", "Contents", s_contents);
    
    return MP_TRUE;
}

int UALM_load_custom_contents_by_logic(TRSNode *in_node, char *s_contents)
{
    struct MALMMSGHIS_TAG *MALMMSGHIS;
    struct MALMMSGDEF_TAG *MALMMSGDEF;
    char *s_point;

    MALMMSGHIS = (struct MALMMSGHIS_TAG *)TRS.get_object(in_node, "MALMMSGHIS_TAG");
    MALMMSGDEF = (struct MALMMSGDEF_TAG *)TRS.get_object(in_node, "MALMMSGDEF_TAG");
    s_point = s_contents;
    
    LOG_head("UALM_load_custom_contents_by_logic : Start Logic");
    LOG_add("FACTORY", MP_STR, sizeof(MALMMSGHIS->FACTORY), MALMMSGHIS->FACTORY);
    LOG_add("ALARM_ID", MP_STR, sizeof(MALMMSGHIS->ALARM_ID), MALMMSGHIS->ALARM_ID);
    LOG_add("SOURCE_ID_1", MP_STR, sizeof(MALMMSGHIS->SOURCE_ID_1), MALMMSGHIS->SOURCE_ID_1);
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

	/* Sample case : Exceed expire date of the product */
	if(memcmp(MALMMSGHIS->ALARM_ID, "EXPIRED_PRODUCT", strlen("EXPIRED_PRODUCT")) == 0)
	{
        struct MWIPLOTSTS_TAG MWIPLOTSTS;
        int i_expired_product_cnt;
        char s_tmp[1500];
        char s_tmp2[1500];

        s_point = UALM_add_contents(s_point, "<html> ");
		s_point = UALM_add_contents(s_point, "<head> ");
		s_point = UALM_add_contents(s_point, "<meta content=\"text/html; charset=utf-8\" http-equiv=Content-Type> ");
		s_point = UALM_add_contents(s_point, "<style type='text/css'> ");
		s_point = UALM_add_contents(s_point, "</style> ");
		s_point = UALM_add_contents(s_point, "</head> ");
		s_point = UALM_add_contents(s_point, "<body>");

        s_point = UALM_add_contents(s_point, "Please check follow products that expired date.");

		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.FACTORY, MALMMSGHIS->FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(MWIPLOTSTS.ORDER_ID, MALMMSGHIS->SOURCE_ID_1, sizeof(MWIPLOTSTS.ORDER_ID));
		DBC_open_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
            LOG_head("UALM_load_custom_contents_by_logic : DBC_open_mwiplotsts(1)");
            LOG_add("FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            LOG_add("ORDER_ID", MP_STR, sizeof(MWIPLOTSTS.ORDER_ID), MWIPLOTSTS.ORDER_ID);
            COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
		}

        i_expired_product_cnt = 0;
		while(1)
		{
			DBC_fetch_mwiplotsts(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				DBC_close_mwiplotsts(1);
				break;
			} 

			if (i_expired_product_cnt < 1)
			{
				s_point = UALM_add_contents(s_point, "<TABLE style=\"BORDER-COLLAPSE: collapse; FONT-SIZE: 12px\" border=1 cellSpacing=0 borderColor=#88bcd1 cellPadding=0>");
				s_point = UALM_add_contents(s_point, "<TBODY><TR bgColor=#d2d2d2><TD>Product</TD><TD>Lot ID</TD><TD>Order</TD><TD>Create Time</TD><TD>Ship Time</TD><TD>Due Date</TD></TR>");
			}

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); //Product
			sprintf(s_tmp2, "<TD>%s</TD>", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID)); //Lot ID
			sprintf(s_tmp2, "<TD>%s</TD>", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID)); //Order
			sprintf(s_tmp2, "<TD>%s</TD>", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MWIPLOTSTS.CREATE_TIME, sizeof(MWIPLOTSTS.CREATE_TIME)); //Create Time
			sprintf(s_tmp2, "<TD>%s</TD>", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MWIPLOTSTS.SHIP_TIME, sizeof(MWIPLOTSTS.SHIP_TIME)); //Ship Time
			sprintf(s_tmp2, "<TD>%s</TD>", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MWIPLOTSTS.SCH_DUE_TIME, sizeof(MWIPLOTSTS.SCH_DUE_TIME)); //Due Date
			sprintf(s_tmp2, "<TD>%s</TD>", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

			s_point = UALM_add_contents(s_point, "</TR>");

            i_expired_product_cnt++;
		}

		if (i_expired_product_cnt > 0)
		{
			s_point = UALM_add_contents(s_point, "</TBODY></TABLE>");
		}

		s_point = UALM_add_contents(s_point, "</body> ");
		s_point = UALM_add_contents(s_point, "</html> ");
	}

	/* Other case : Default */
	else
	{
        char s_tmp[1500];
        char s_tmp2[1500];

        s_point = UALM_add_contents(s_point, "<html> ");
		s_point = UALM_add_contents(s_point, "<head> ");
		s_point = UALM_add_contents(s_point, "<meta content=\"text/html; charset=utf-8\" http-equiv=Content-Type> ");
		s_point = UALM_add_contents(s_point, "<style type='text/css'> ");
		s_point = UALM_add_contents(s_point, ".tbl { border-top:1px solid #bbbbbb; } ");
		s_point = UALM_add_contents(s_point, ".tbl tr td { ");
		s_point = UALM_add_contents(s_point, "    height: 25px; ");
		s_point = UALM_add_contents(s_point, "	font-family: 'Arial'; ");
		s_point = UALM_add_contents(s_point, "	font-size: 11px; ");
		s_point = UALM_add_contents(s_point, "    color: #666666; ");
		s_point = UALM_add_contents(s_point, "	text-align: center; ");
		s_point = UALM_add_contents(s_point, "	border-bottom:1px solid #bbbbbb; ");
		s_point = UALM_add_contents(s_point, "	border-left:1px solid #bbbbbb; ");
		s_point = UALM_add_contents(s_point, "} ");
		s_point = UALM_add_contents(s_point, ".tbl tr th { ");
		s_point = UALM_add_contents(s_point, "    height: 25px; ");
		s_point = UALM_add_contents(s_point, "	font-family: 'Arial'; ");
		s_point = UALM_add_contents(s_point, "	font-size: 11px; ");
		s_point = UALM_add_contents(s_point, "    color: red; ");
		s_point = UALM_add_contents(s_point, "	font-weight: bold; ");
		s_point = UALM_add_contents(s_point, "	text-align: center; ");
		s_point = UALM_add_contents(s_point, "	border-bottom:1px solid #bbbbbb; ");
		s_point = UALM_add_contents(s_point, "	border-left:1px solid #bbbbbb; ");
		s_point = UALM_add_contents(s_point, "	border-right:1px solid #bbbbbb; ");
		s_point = UALM_add_contents(s_point, "	background-color: #f3f3f3; ");
		s_point = UALM_add_contents(s_point, "} ");
		s_point = UALM_add_contents(s_point, ".border_last { border-right:1px solid #bbbbbb; } ");
		s_point = UALM_add_contents(s_point, "</style> ");
		s_point = UALM_add_contents(s_point, "</head> ");
		s_point = UALM_add_contents(s_point, "<body><table class=tbl cellspacing=0 cellpadding=0> ");
		s_point = UALM_add_contents(s_point, "<tr><th width=448 colspan=2> ");

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGDEF->ALARM_DESC, sizeof(MALMMSGDEF->ALARM_DESC));
		sprintf(s_tmp2, "<p align=left>&nbsp;%s ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGDEF->ALARM_ID, sizeof(MALMMSGDEF->ALARM_ID));
		sprintf(s_tmp2, "[%s]</span></p></th></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

		s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Factory</p></td><td class='border_last' width=360> ");
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGDEF->FACTORY, sizeof(MALMMSGDEF->FACTORY));
        sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

		s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm ID</p></td><td class='border_last' width=360> "); 
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGDEF->ALARM_ID, sizeof(MALMMSGDEF->ALARM_ID));
        sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

		s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Type</p></td><td class='border_last' width=360> ");
		sprintf(s_tmp2, "<p align=left>&nbsp;%c</p></td></tr> ", MALMMSGDEF->ALARM_TYPE); s_point = UALM_add_contents(s_point, s_tmp2);

		s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Level</p></td><td class='border_last' width=360> ");
		sprintf(s_tmp2, "<p align=left>&nbsp;%c</p></td></tr> ", MALMMSGDEF->ALARM_LEVEL_FLAG); s_point = UALM_add_contents(s_point, s_tmp2);

		s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Tran Time</p></td><td class='border_last' width=360> ");
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->TRAN_TIME, sizeof(MALMMSGHIS->TRAN_TIME));
        sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->ALARM_SUBJECT, sizeof(MALMMSGHIS->ALARM_SUBJECT));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Subject</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->ALARM_MSG, sizeof(MALMMSGHIS->ALARM_MSG));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Msg</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->ALARM_COMMENT_1, sizeof(MALMMSGHIS->ALARM_COMMENT_1));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Comment 1</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->ALARM_COMMENT_2, sizeof(MALMMSGHIS->ALARM_COMMENT_2));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Comment 2</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->ALARM_COMMENT_3, sizeof(MALMMSGHIS->ALARM_COMMENT_3));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Comment 3</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->ALARM_COMMENT_4, sizeof(MALMMSGHIS->ALARM_COMMENT_4));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Comment 4</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->ALARM_COMMENT_5, sizeof(MALMMSGHIS->ALARM_COMMENT_5));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Alarm Comment 5</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->LOT_ID, sizeof(MALMMSGHIS->LOT_ID));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Lot ID</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->RES_ID, sizeof(MALMMSGHIS->RES_ID));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Resource ID</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->SOURCE_ID_1, sizeof(MALMMSGHIS->SOURCE_ID_1));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Source ID 1</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->SOURCE_DESC_1, sizeof(MALMMSGHIS->SOURCE_DESC_1));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Source Desc 1</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->SOURCE_ID_2, sizeof(MALMMSGHIS->SOURCE_ID_2));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Source ID 2</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->SOURCE_DESC_2, sizeof(MALMMSGHIS->SOURCE_DESC_2));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Source Desc 2</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->SOURCE_ID_3, sizeof(MALMMSGHIS->SOURCE_ID_3));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Source ID 3</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGHIS->SOURCE_DESC_3, sizeof(MALMMSGHIS->SOURCE_DESC_3));
		if(COM_isnullspace(s_tmp) == MP_FALSE)
		{
			s_point = UALM_add_contents(s_point, "<tr><td width=88><p align=center>Source Desc 3</p></td><td class='border_last' width=360> ");
            sprintf(s_tmp2, "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); s_point = UALM_add_contents(s_point, s_tmp2);
		}

        s_point = UALM_add_contents(s_point, "</table></body> ");
		s_point = UALM_add_contents(s_point, "</html> ");
	}

    LOG_head("UALM_load_custom_contents_by_logic : Finish Logic");
    LOG_add("FACTORY", MP_STR, sizeof(MALMMSGHIS->FACTORY), MALMMSGHIS->FACTORY);
    LOG_add("ALARM_ID", MP_STR, sizeof(MALMMSGHIS->ALARM_ID), MALMMSGHIS->ALARM_ID);
    LOG_add("SOURCE_ID_1", MP_STR, sizeof(MALMMSGHIS->SOURCE_ID_1), MALMMSGHIS->SOURCE_ID_1);
    COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    COM_long_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM, "UALM_load_custom_contents_by_logic", "Contents", s_contents);

    return MP_TRUE;
}

void UALM_fill_custom_value_to_node(struct MALMMSGHIS_TAG *MALMMSGHIS, struct MALMMSGDEF_TAG *MALMMSGDEF, TRSNode *node)
{
    // Sample for filling custom value to node....
    //
    //struct MWIPLOTSTS_TAG MWIPLOTSTS;
    //struct MRASRESDEF_TAG MRASRESDEF;

    //DBC_init_mwiplotsts(&MWIPLOTSTS);
    //memcpy(MWIPLOTSTS.LOT_ID, MALMMSGHIS->LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    //DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    //if(DB_error_code == DB_SUCCESS)
    //{
    //    TRS.add_string(node, "LOT_MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    //    TRS.add_char(node, "LOT_TYPE", MWIPLOTSTS.LOT_TYPE);
    //    TRS.add_double(node, "LOT_QTY", MWIPLOTSTS.QTY_1);
    //}

    //DBC_init_mrasresdef(&MRASRESDEF);
    //memcpy(MRASRESDEF.FACTORY, MALMMSGHIS->FACTORY, sizeof(MRASRESDEF.FACTORY));
    //memcpy(MRASRESDEF.RES_ID, MALMMSGHIS->RES_ID, sizeof(MRASRESDEF.RES_ID));
    //DBC_select_mrasresdef(1, &MRASRESDEF);
    //if(DB_error_code == DB_SUCCESS)
    //{
    //    TRS.add_string(node, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));
    //    TRS.add_char(node, "RES_UP_DOWN_FLAG", MRASRESDEF.RES_UP_DOWN_FLAG);
    //    TRS.add_string(node, "RES_PRI_STS", MRASRESDEF.RES_PRI_STS, sizeof(MRASRESDEF.RES_PRI_STS));
    //    TRS.add_string(node, "RES_CMF_1", MRASRESDEF.RES_CMF_1, sizeof(MRASRESDEF.RES_CMF_1));
    //}

}

