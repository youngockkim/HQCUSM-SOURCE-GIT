#if defined(_TIBRV)

#include "UXML_common.h"
#include <TRSCore_functions.h>
#include <MESCore_common.h>

void UXML_remove_escape_char(char *dest, const char *src)
{
    int i_length;
    int i;
    char s_tmp[100];

    i_length = (int)strlen(src);
    memset(s_tmp, 0x00, sizeof(s_tmp));
    memset(dest, 0x00, sizeof(s_tmp));

    for(i = 0; i < i_length; i++)
    {
        if(
            (src[i] >= '0' && src[i] <= '9') || 
            (src[i] >= 'A' && src[i] <= 'Z') ||
            (src[i] >= 'a' && src[i] <= 'z') ||
            src[i] == '-' || src[i] == '_' || src[i] == '.'
            )
        {
            s_tmp[i] = src[i];
        }
        else
        {
            s_tmp[i] = '_';
        }
    }

    memcpy(dest, s_tmp, i_length);
}

int UXML_get_msg_code_in_gcm()
{
    struct MGCMTBLDEF_TAG MGCMTBLDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;

    memset(gt_ecd_header, ' ', sizeof(gt_ecd_header));
    gi_ecd_header_count = 0;

    DBC_init_mgcmtbldef(&MGCMTBLDEF);
    memcpy(MGCMTBLDEF.FACTORY, gs_factory_code, sizeof(MGCMTBLDEF.FACTORY));
    memcpy(MGCMTBLDEF.TABLE_NAME, GCM_ECD_TABLE, strlen(GCM_ECD_TABLE));
    DBC_select_mgcmtbldef(1, &MGCMTBLDEF);
    if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS) 
    {
        LOG_head("ERROR : UXML_get_msg_code_in_gcm");
        LOG_add("FUNCTION", MP_NSTR, "DBC_select_mgcmtbldef()");
        LOG_add("FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
        LOG_add("TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);
        LOG_add("DB_ERR_MSG", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg);
        COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        return MP_FALSE;
    }
    else if(DB_error_code == DB_NOT_FOUND) 
    {
        memset(MGCMTBLDEF.FACTORY, ' ', sizeof(MGCMTBLDEF.FACTORY));                
        memcpy(MGCMTBLDEF.FACTORY, CENTRAL_FACTORY, strlen(CENTRAL_FACTORY));

        DBC_select_mgcmtbldef(1, &MGCMTBLDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            LOG_head("ERROR : UXML_get_msg_code_in_gcm");
            LOG_add("FUNCTION", MP_NSTR, "DBC_select_mgcmtbldef()");
            LOG_add("FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
            LOG_add("TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);
            LOG_add("DB_ERR_MSG", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg);
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }
        if(MGCMTBLDEF.CENTRAL_FLAG != 'Y')
        {
            LOG_head("ERROR : UXML_get_msg_code_in_gcm");
            LOG_add("REASON", MP_NSTR, "MGCMTBLDEF.CENTRAL_FLAG != 'Y'");
            LOG_add("FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
            LOG_add("TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }
    }

    DBC_init_mgcmtbldat(&MGCMTBLDAT);
    memcpy(MGCMTBLDAT.FACTORY, MGCMTBLDEF.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
    memcpy(MGCMTBLDAT.TABLE_NAME, MGCMTBLDEF.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME));
    DBC_open_mgcmtbldat(2, &MGCMTBLDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        LOG_head("ERROR : UXML_get_msg_code_in_gcm");
        LOG_add("FUNCTION", MP_NSTR, "DBC_open_mgcmtbldat()");
        LOG_add("FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
        LOG_add("TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
        LOG_add("DB_ERR_MSG", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg);
        COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mgcmtbldat(2, &MGCMTBLDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mgcmtbldat(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            LOG_head("ERROR : UXML_get_msg_code_in_gcm");
            LOG_add("FUNCTION", MP_NSTR, "DBC_fetch_mgcmtbldat()");
            LOG_add("FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            LOG_add("TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            LOG_add("DB_ERR_MSG", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg);
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

            DBC_close_mgcmtbldat(2);
            return MP_FALSE;
        }

        if(COM_isspace(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2)) == MP_FALSE)
        {
            memcpy(gt_ecd_header[gi_ecd_header_count].s_module, MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
            memcpy(gt_ecd_header[gi_ecd_header_count].s_value, MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
            COM_add_null(gt_ecd_header[gi_ecd_header_count].s_value, sizeof(gt_ecd_header[gi_ecd_header_count].s_value));
            gi_ecd_header_count++;
        }
    }

    return MP_TRUE;
}

void UXML_get_module_version(char *s_module, char *s_version, const char *s_service)
{
    struct MSVMSVCDEF_TAG MSVMSVCDEF;
    struct MSVMDFTVER_TAG MSVMDFTVER;
    char s_mod[sizeof(MSVMSVCDEF.MODULE_NAME) + 1];
    char s_ver[sizeof(MSVMDFTVER.LIB_VER) + 1];

    memset(s_mod, 0x00, sizeof(s_mod));
    memset(s_ver, 0x00, sizeof(s_ver));

    if(gc_db_connected != 'Y')
    {
        return ;
    }

    DBC_init_msvmsvcdef(&MSVMSVCDEF);
    strcpy(MSVMSVCDEF.SERVICE_NAME, s_service);

    DBC_select_msvmsvcdef(1, &MSVMSVCDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        return ;
    }

    memcpy(s_mod, MSVMSVCDEF.MODULE_NAME, sizeof(MSVMSVCDEF.MODULE_NAME));
    COM_add_null(s_mod, sizeof(s_mod));
    strcpy(s_module, s_mod);

    DBC_init_msvmdftver(&MSVMDFTVER);
    memcpy(MSVMDFTVER.LIB_NAME, MSVMSVCDEF.MODULE_NAME, sizeof(MSVMDFTVER.LIB_NAME));
    DBC_select_msvmdftver(2, &MSVMDFTVER);
    if(DB_error_code != DB_SUCCESS) 
    {
        memcpy(MSVMDFTVER.LIB_NAME, MSVMSVCDEF.SHARED_LIB_NAME, sizeof(MSVMDFTVER.LIB_NAME));
        DBC_select_msvmdftver(2, &MSVMDFTVER);
        if(DB_error_code != DB_SUCCESS) 
        {
            return ;
        }
    }

    memcpy(s_ver, MSVMDFTVER.LIB_VER, sizeof(MSVMDFTVER.LIB_VER));
    COM_add_null(s_ver, sizeof(s_ver));
    strcpy(s_version, s_ver);
}

void UXML_get_msg_code(char *s_dest, char *s_src)
{
    int i;

    if(gi_ecd_header_count < 1 && gc_db_connected == 'Y')
    {
        UXML_get_msg_code_in_gcm();
    }

    if(gi_ecd_header_count > 0)
    {
        for(i = 0; i < gi_ecd_header_count; i++)
        {
            if(memcmp(gt_ecd_header[i].s_module, s_src, 3) == 0)
            {
                sprintf(s_dest, "%s%s", gt_ecd_header[i].s_value, s_src + 4);
                return;
            }
        }

        UXML_get_msg_code_in_gcm();

        for(i = 0; i < gi_ecd_header_count; i++)
        {
            if(memcmp(gt_ecd_header[i].s_module, s_src, 3) == 0)
            {
                sprintf(s_dest, "%s%s", gt_ecd_header[i].s_value, s_src + 4);
                return;
            }
        }
    }

    if(memcmp(s_src, "ADM", 3) == 0)
        sprintf(s_dest, "999%s", s_src + 4);
    else if(memcmp(s_src, "ALM", 3) == 0)
        sprintf(s_dest, "998%s", s_src + 4);
    else if(memcmp(s_src, "ARC", 3) == 0)
        sprintf(s_dest, "997%s", s_src + 4);
    else if(memcmp(s_src, "BAS", 3) == 0)
        sprintf(s_dest, "996%s", s_src + 4);
    else if(memcmp(s_src, "BOM", 3) == 0)
        sprintf(s_dest, "995%s", s_src + 4);
    else if(memcmp(s_src, "CMN", 3) == 0)
        sprintf(s_dest, "994%s", s_src + 4);
    else if(memcmp(s_src, "EDC", 3) == 0)
        sprintf(s_dest, "993%s", s_src + 4);
    else if(memcmp(s_src, "EIS", 3) == 0)
        sprintf(s_dest, "992%s", s_src + 4);
    else if(memcmp(s_src, "ETC", 3) == 0)
        sprintf(s_dest, "991%s", s_src + 4);
    else if(memcmp(s_src, "FMB", 3) == 0)
        sprintf(s_dest, "990%s", s_src + 4);
    else if(memcmp(s_src, "GCM", 3) == 0)
        sprintf(s_dest, "989%s", s_src + 4);
    else if(memcmp(s_src, "INV", 3) == 0)
        sprintf(s_dest, "988%s", s_src + 4);
    else if(memcmp(s_src, "MSG", 3) == 0)
        sprintf(s_dest, "987%s", s_src + 4);
    else if(memcmp(s_src, "ORD", 3) == 0)
        sprintf(s_dest, "986%s", s_src + 4);
    else if(memcmp(s_src, "PLN", 3) == 0)
        sprintf(s_dest, "985%s", s_src + 4);
    else if(memcmp(s_src, "POP", 3) == 0)
        sprintf(s_dest, "984%s", s_src + 4);
    else if(memcmp(s_src, "QCM", 3) == 0)
        sprintf(s_dest, "983%s", s_src + 4);
    else if(memcmp(s_src, "RAS", 3) == 0)
        sprintf(s_dest, "982%s", s_src + 4);
    else if(memcmp(s_src, "RCP", 3) == 0)
        sprintf(s_dest, "981%s", s_src + 4);
    else if(memcmp(s_src, "RMS", 3) == 0)
        sprintf(s_dest, "980%s", s_src + 4);
    else if(memcmp(s_src, "RTD", 3) == 0)
        sprintf(s_dest, "979%s", s_src + 4);
    else if(memcmp(s_src, "SEC", 3) == 0)
        sprintf(s_dest, "978%s", s_src + 4);
    else if(memcmp(s_src, "SPC", 3) == 0)
        sprintf(s_dest, "977%s", s_src + 4);
    else if(memcmp(s_src, "SVM", 3) == 0)
        sprintf(s_dest, "976%s", s_src + 4);
    else if(memcmp(s_src, "WIP", 3) == 0)
        sprintf(s_dest, "975%s", s_src + 4);
    else
        sprintf(s_dest, "974%s", s_src + 4);
}

void UXML_to_xml_string_type(char* type, TRSDataType valueType)
{
    switch(valueType)
    {
        case DT_STRING:
            strcpy(type, EXT_XML_VALUE_TYPE_STRING);
            break;
        case DT_NSTRING:
            strcpy(type, EXT_XML_VALUE_TYPE_STRING);
            break;
        case DT_CHAR:
            strcpy(type, EXT_XML_VALUE_TYPE_STRING);
            break;
        case DT_BINARY:
            strcpy(type, XML_VALUE_TYPE_BINARY);
            break;
        case DT_BOOLEAN:        
            strcpy(type, XML_VALUE_TYPE_BOOLEAN);
            break;
        case DT_UBYTE:
            strcpy(type, XML_VALUE_TYPE_UBYTE);
            break;
        case DT_USHORT:
            strcpy(type, XML_VALUE_TYPE_USHORT);
            break;
        case DT_UINT:
            strcpy(type, XML_VALUE_TYPE_UINT);
            break;
        case DT_ULONG:
            strcpy(type, XML_VALUE_TYPE_ULONG);
            break;
        case DT_FLOAT:
            strcpy(type, XML_VALUE_TYPE_FLOAT);
            break;
        case DT_DOUBLE:
            strcpy(type, XML_VALUE_TYPE_DOUBLE);
            break;
        case DT_BYTE:
            strcpy(type, XML_VALUE_TYPE_BYTE);
            break;
        case DT_SHORT:
            strcpy(type, XML_VALUE_TYPE_SHORT);
            break;
        case DT_INT:
            strcpy(type, XML_VALUE_TYPE_INT);
            break;
        case DT_LONG:
            strcpy(type, XML_VALUE_TYPE_LONG);
            break;
        case DT_DATETIME:
            strcpy(type, XML_VALUE_TYPE_DATETIME);
            break;
        case DT_BLOB:
            strcpy(type, XML_VALUE_TYPE_BLOB);
            break;
        case DT_LIST:
            strcpy(type, XML_TAG_LIST);
            break;
        case DT_ARRAY:
            strcpy(type, EXT_XML_TAG_ARRAY);
            break;
        default:
            type[0] = 0x00;
            break;
    }
}

void UXML_write_xml_string_for_node(XmlStrData* data ,const TRSNode *node, char b_xsi_namespace_defined)
{
    char s_tag_name[100];
    TRSDataType type = 0;
    char s_type_string[10];

    if(node == 0x00) return;
    if(node->InternalFlag == 'Y') return;
    if(node->ValueType == DT_ARRAY) return;
    if(node->ValueType == DT_OBJECT) return;
    if(node->Name == 0x00) return;

    if(node->NodeType == ATTRIBUTE || (node->NodeType == ELEMENT && node->ConvertedFromAttrFlag == 'Y'))
    {
        memset(s_type_string, 0x00, sizeof(s_type_string));
        memset(s_tag_name, 0x00, sizeof(s_tag_name));

        UXML_to_xml_string_type(s_type_string, node->ValueType);        

        if(node->Parent != 0x00 && node->Parent->ValueType == DT_ARRAY)
        {
            type = node->Parent->ArrayType;
            strcpy(s_tag_name, EXT_XML_TAG_ITEM);

            sprintf(data->Current, "<%s", EXT_XML_TAG_ITEM);
        }
        else
        {
            type = node->ValueType;
            UXML_remove_escape_char(s_tag_name, node->Name);

            if(node->Parent != 0x00 && node->Parent->Parent == 0x00)
            {
                if(strcmp(node->Name, MSG_MODULE_NAME) == 0)
                    strcpy(s_tag_name, "MODULE");
                else if(strcmp(node->Name, MSG_SERVICE_NAME) == 0)
                    strcpy(s_tag_name, "CMD");
            }

            sprintf(data->Current, "<%s %s=\"%s\"", s_tag_name, EXT_XML_TAG_TYPE, s_type_string);

        }

        data->Current += strlen(data->Current);

        if(node->NullFlag == 'Y')
        {
            sprintf(data->Current, " %snil=\"true\"/>",
                                   (b_xsi_namespace_defined == 'Y') ? "xsi:" : "");
        }
        else
        {
            switch(type)
            {
            case DT_STRING:
            case DT_NSTRING:
                if(node->Value.s == 0x00 || strlen(node->Value.s) < 1)
                {
                    sprintf(data->Current, "/>");
                }
                else
                {
                    char s_buff_1[MAXIMUM_STRING_VALUE_BYTES];
                    unsigned char s_buff_2[MAXIMUM_STRING_VALUE_BYTES];

                    memset(s_buff_1, 0x00, sizeof(s_buff_1));
                    memset(s_buff_2, 0x00, sizeof(s_buff_2));

                    TRS_convert_escape(s_buff_1, node->Value.s);
                    AnsiToUTF8(s_buff_2, s_buff_1, (int)strlen(s_buff_1));

                    if(node->EncryptFlag == 'Y')
                    {
                        if(COM_search_string(s_tag_name, (int)strlen(s_tag_name), "USERID", 6) < 0 &&
                           COM_search_string(s_tag_name, (int)strlen(s_tag_name), "USER_ID", 7) < 0)
                        {
                            char s_buff[MAXIMUM_STRING_VALUE_BYTES];
                            memset(s_buff, 0x00, sizeof(s_buff));
                            TRS_encrypt(s_buff, s_buff_2);
                            sprintf(data->Current, " encrypt=\"true\">%s</%s>", s_buff, s_tag_name);
                        }
                        else
                        {
                            sprintf(data->Current, ">%s</%s>", s_buff_2, s_tag_name);
                        }
                    }
                    else
                    {
                        sprintf(data->Current, ">%s</%s>", s_buff_2, s_tag_name);
                    }
                }
                break;
            case DT_CHAR:
                if(node->Value.c == 0x00)
                {
                    sprintf(data->Current, "/>");
                }
                else
                {
                    char s_buff_1[2];
                    char s_buff_2[10];

                    memset(s_buff_1, 0x00, sizeof(s_buff_1));
                    memset(s_buff_2, 0x00, sizeof(s_buff_2));

                    s_buff_1[0] = node->Value.c;
                    TRS_convert_escape(s_buff_2, s_buff_1);

                    sprintf(data->Current, ">%s</%s>", s_buff_2, s_tag_name);
                }
                break;
            case DT_BINARY:
                sprintf(data->Current, ">%d</%s>", node->Value.u1, s_tag_name);
                break;
            case DT_BOOLEAN:
                if(node->Value.i4 == 1)
                    sprintf(data->Current, ">true</%s>", s_tag_name);
                else
                    sprintf(data->Current, ">false</%s>", s_tag_name);
                break;
            case DT_UBYTE:
                sprintf(data->Current, ">%d</%s>", node->Value.u1, s_tag_name);
                break;
            case DT_USHORT:
                sprintf(data->Current, ">%d</%s>", node->Value.u2, s_tag_name);
                break;
            case DT_UINT:
                sprintf(data->Current, ">%u</%s>", node->Value.u4, s_tag_name);
                break;
            case DT_ULONG:
                sprintf(data->Current, ">%lu", node->Value.u8);
                data->Current += strlen(data->Current);
                sprintf(data->Current, "</%s>", s_tag_name);
                break;
            case DT_FLOAT:
                sprintf(data->Current, ">%f</%s>", node->Value.f4, s_tag_name);
                break;
            case DT_DOUBLE:
                sprintf(data->Current, ">%.10f</%s>", node->Value.f8, s_tag_name);
                break;
            case DT_BYTE:
                sprintf(data->Current, ">%d</%s>", node->Value.c, s_tag_name);
                break;
            case DT_SHORT:
                sprintf(data->Current, ">%d</%s>", node->Value.i2, s_tag_name);
                break;
            case DT_INT:
                sprintf(data->Current, ">%d</%s>", node->Value.i4, s_tag_name);
                break;
            case DT_LONG:
                sprintf(data->Current, ">%ld", node->Value.i8);
                data->Current += strlen(data->Current);
                sprintf(data->Current, "</%s>", s_tag_name);
                break;
            case DT_DATETIME:
                if(node->Value.s == 0x00 || strlen(node->Value.s) < 1)
                {
                    sprintf(data->Current, "/>");
                }
                else
                {
                    char s_format[100];
                    char s_value[100];

                    memset(s_format, 0x00, sizeof(s_format));
                    memset(s_value, 0x00, sizeof(s_value));

                    memcpy(s_value, node->OriginDateTime, 4); // year
                    s_value[4] = '-';
                    memcpy(s_value + 5, node->OriginDateTime + 4, 2); // month
                    s_value[7] = '-';
                    memcpy(s_value + 8, node->OriginDateTime + 6, 2); // day
                    s_value[10] = 'T';
                    memcpy(s_value + 11, node->OriginDateTime + 8, 2); // hour
                    s_value[13] = ':';
                    memcpy(s_value + 14, node->OriginDateTime + 10, 2); // minute
                    s_value[16] = ':';
                    memcpy(s_value + 17, node->OriginDateTime + 12, 2); // second

					//Add by J.S. 2011.11.22 c_short_XML_date_format = 'Y'인경우 millisecond, time zone은 넣지 않음.
					if(gc_short_XML_date_format != 'Y')
					{
						s_value[19] = '.';
						memcpy(s_value + 20, node->OriginDateTime + 14, 3); // millisecond
						s_value[23] = node->OriginDateTime[17];
						memcpy(s_value + 24, node->OriginDateTime + 18, 2); // time zone hour
						s_value[26] = ':';
						memcpy(s_value + 27, node->OriginDateTime + 20, 2); // time zone minute
					}

                    if(node->DateTimeFormat != 0x00)
                    {
                        TRS_convert_escape(s_format, node->DateTimeFormat);

                        sprintf(data->Current, " Format=\"%s\">%s</%s>", s_format, s_value, s_tag_name);
                    }
                    else
                    {
                        sprintf(data->Current, ">%s</%s>", s_value, s_tag_name);
                    }
                }
                break;
            case DT_BLOB:
                if(node->Value.bo == 0x00)
                {
                    sprintf(data->Current, "/>");
                }
                else
                {
                    size_t out_len = 0;
                    unsigned char *us_buff = base64_encode(node->Value.bo, node->BlobSize, &out_len);

                    sprintf(data->Current, ">%s</%s>", us_buff, s_tag_name);
                    free(us_buff);
                }
                break;
            default:
                break;
            }
        }

        data->Current += strlen(data->Current);
    }
}

void UXML_write_xml_string_sub(XmlStrData* data ,const TRSNode *node, char b_xsi_namespace_defined)
{
    int i;
    int i1;
    int i_list_size;
    char s_type_string[10];
    char s_tag_name[100];
    memset(s_type_string, 0x00, sizeof(s_type_string));

    if(node->InternalFlag == 'Y')   return;

    UXML_write_xml_string_for_node(data, node, b_xsi_namespace_defined);

    if(node->NodeType == ELEMENT)
    {
        if(node->ValueType == DT_ARRAY)
        {
            UXML_to_xml_string_type(s_type_string, node->ArrayType);

            UXML_remove_escape_char(s_tag_name, node->Name);
            sprintf(data->Current, "<%s %s=\"%s\" %s=\"%s\" %s=\"%d\">", s_tag_name,
                                                                         EXT_XML_TAG_TYPE, 
                                                                         EXT_XML_TAG_ARRAY, 
                                                                         EXT_XML_TAG_ARRAYTYPE, 
                                                                         s_type_string,  
                                                                         EXT_XML_TAG_SIZE, 
                                                                         node->MemberCount);

            data->Current += strlen(data->Current);

            for(i = 0; i < node->MemberCount; i++)
            {
                UXML_write_xml_string_for_node(data, node->Members[i], b_xsi_namespace_defined);
            }
        }
        else if(node->ValueType == DT_LIST)
        {
            UXML_to_xml_string_type(s_type_string, node->ValueType);

            if(node->ListCount > 0 || node->MemberCount > 0)
            {
                i_list_size = 0;
                for(i = 0; i < node->MemberCount; i++)
                {
                    if(node->Members[i]->InternalFlag != 'Y')
                    {
                        i_list_size++;
                    }
                }
                for(i = 0; i < node->ListCount; i++)
                {
                    i_list_size += node->List[i]->Count;
                }

                UXML_remove_escape_char(s_tag_name, node->Name);
                sprintf(data->Current, "<%s %s=\"%s\" %s=\"%d\">", s_tag_name,
                                                                   EXT_XML_TAG_TYPE, 
                                                                   XML_TAG_LIST, 
                                                                   EXT_XML_TAG_SIZE, 
                                                                   i_list_size);
            }
            else
            {
                UXML_remove_escape_char(s_tag_name, node->Name);
                sprintf(data->Current, "<%s %s=\"%s\">", s_tag_name, EXT_XML_TAG_TYPE, s_type_string);
            }

            data->Current += strlen(data->Current);

            for(i = 0; i < node->MemberCount; i++)
            {
                UXML_write_xml_string_sub(data, node->Members[i], b_xsi_namespace_defined);
            }

            for(i = 0; i < node->ListCount; i++)
            {
                for(i1 = 0; i1 < node->List[i]->Count; i1++)
                {
                    UXML_write_xml_string_sub(data, node->List[i]->Items[i1], b_xsi_namespace_defined);
                }
            }
        }

        UXML_remove_escape_char(s_tag_name, node->Name);
        sprintf(data->Current, "</%s>", s_tag_name);

        data->Current += strlen(data->Current);
    }
    else if(node->NodeType == EMPTY)
    {
        if(node->ValueType == DT_LIST && node->ListCount < 1)
        {
            UXML_to_xml_string_type(s_type_string, node->ValueType);

            UXML_remove_escape_char(s_tag_name, node->Name);
            sprintf(data->Current, "<%s %s=\"%s\" %s=\"%d\"/>", s_tag_name,
                                                                EXT_XML_TAG_TYPE, 
                                                                XML_TAG_LIST, 
                                                                EXT_XML_TAG_SIZE, 
                                                                node->ListCount);

            data->Current += strlen(data->Current);
        }
        else if(node->ValueType == DT_ARRAY && node->MemberCount < 1)
        {
            UXML_to_xml_string_type(s_type_string, node->ArrayType);

            UXML_remove_escape_char(s_tag_name, node->Name);
            sprintf(data->Current, "<%s %s=\"%s\" %s=\"%s\" %s=\"%d\"/>", s_tag_name,
                                                                          EXT_XML_TAG_TYPE, 
                                                                          EXT_XML_TAG_ARRAY, 
                                                                          EXT_XML_TAG_ARRAYTYPE, 
                                                                          s_type_string,  
                                                                          EXT_XML_TAG_SIZE, 
                                                                          node->MemberCount);

            data->Current += strlen(data->Current);
        }
    }
}

void UXML_write_xml_string(XmlStrData* data, const TRSNode *node, char b_xsi_namespace_defined)
{
    int i;
    int i1;
    char b_exist_attribute;
    char b_skip_member;
    char s_type_string[10];
    char s_tag_name[100];
    memset(s_type_string, 0x00, sizeof(s_type_string));

    b_exist_attribute = ' ';
    b_skip_member = ' ';
    i = (int)strlen(data->Current);

    UXML_write_xml_string_for_node(data, node, b_xsi_namespace_defined);

    if(i < (int)strlen(data->Current))
    {
        b_exist_attribute = 'Y';
    }

    if(node->NodeType == ELEMENT)
    {
        if(b_exist_attribute == 'Y')
        {
            UXML_to_xml_string_type(s_type_string, node->ValueType);

            if(node->ListCount > 0 || node->MemberCount > 0)
            {
                i1 = 0;
                for(i = 0; i < node->ListCount; i++)
                {
                    i1 += node->List[i]->Count;
                }

                UXML_remove_escape_char(s_tag_name, node->Name);
                sprintf(data->Current, "<%s %s=\"%s\" %s=\"%d\">", s_tag_name,
                                                                   EXT_XML_TAG_TYPE, 
                                                                   XML_TAG_LIST, 
                                                                   EXT_XML_TAG_SIZE, 
                                                                   i1 + node->MemberCount);
            }
            else
            {
                UXML_remove_escape_char(s_tag_name, node->Name);
                sprintf(data->Current, "<%s %s=\"%s\">", s_tag_name, EXT_XML_TAG_TYPE, s_type_string);
            }

            data->Current += strlen(data->Current);
        }

        if(node->Parent == 0x00)
        {
            if(TRS.get_member(node, OUT_STATUSVALUE) != 0x00)
            {
                char *s_msg_code_1;
                char s_msg_code_2[10];
                char s_buff[MAXIMUM_STRING_VALUE_BYTES];
                unsigned char s_buff_t[MAXIMUM_STRING_VALUE_BYTES];
                char c_status_value;

                memset(s_msg_code_2, 0x00, sizeof(s_msg_code_2));

                s_msg_code_1 = TRS.get_string(node, OUT_MSGCODE);
                if(COM_isnullspace(s_msg_code_1) == MP_FALSE)
                {
                    if(strcmp(s_msg_code_1, "-1") == 0)
                    {
                        strcpy(s_msg_code_2, s_msg_code_1);
                    }
                    else
                    {
                        UXML_get_msg_code(s_msg_code_2, s_msg_code_1);
                    }
                }

                sprintf(data->Current, "<CMD type=\"A\">Reply.%s</CMD>", node->Name); data->Current += strlen(data->Current);

                c_status_value = TRS.get_char(node, OUT_STATUSVALUE);
                if(c_status_value == MP_SUCCESS_C || c_status_value == MP_WARN_C)
                {
                    sprintf(data->Current, "<ECD type=\"I4\">0</ECD>"); data->Current += strlen(data->Current);

                    if(TRS.get_char(node, OUT_MSGCATE) == MP_MSG_CATE_SUCCESS)
                    {
                        memset(s_buff, 0x00, sizeof(s_buff));
                        memset(s_buff_t, 0x00, sizeof(s_buff_t));
                        TRS_convert_escape(s_buff, TRS.get_string(node, OUT_MSG));
                        AnsiToUTF8(s_buff_t, s_buff, (int)strlen(s_buff));

                        sprintf(data->Current, "<ETX type=\"A\">%s</ETX>", s_buff_t); data->Current += strlen(data->Current);
                    }
                    else if(TRS.get_char(node, OUT_MSGCATE) == MP_MSG_CATE_WARN)
                    {
                        sprintf(data->Current, "<ETX type=\"A\"></ETX>"); data->Current += strlen(data->Current);

                        memset(s_buff, 0x00, sizeof(s_buff));
                        TRS_convert_escape(s_buff, s_msg_code_2);
                        sprintf(data->Current, "<WCD type=\"I4\">%s</WCD>", s_buff); data->Current += strlen(data->Current);

                        memset(s_buff, 0x00, sizeof(s_buff));
                        memset(s_buff_t, 0x00, sizeof(s_buff_t));
                        TRS_convert_escape(s_buff, TRS.get_string(node, OUT_MSG));
                        AnsiToUTF8(s_buff_t, s_buff, (int)strlen(s_buff));

                        sprintf(data->Current, "<WTX type=\"A\">%s</WTX>", s_buff_t); data->Current += strlen(data->Current);
                    }
                }
                else
                {
                    memset(s_buff, 0x00, sizeof(s_buff));
                    TRS_convert_escape(s_buff, s_msg_code_2);
                    sprintf(data->Current, "<ECD type=\"I4\">%s</ECD>", s_buff); data->Current += strlen(data->Current);

                    memset(s_buff, 0x00, sizeof(s_buff));
                    memset(s_buff_t, 0x00, sizeof(s_buff_t));
                    TRS_convert_escape(s_buff, TRS.get_string(node, OUT_MSG));
                    AnsiToUTF8(s_buff_t, s_buff, (int)strlen(s_buff));

                    sprintf(data->Current, "<ETX type=\"A\">%s</ETX>", s_buff_t); data->Current += strlen(data->Current);

                    if(c_status_value == MP_TROUBLE_C)
                    {
                        sprintf(data->Current, "<%s type=\"A\">%c</%s>", OUT_STATUSVALUE, MP_TROUBLE_C, OUT_STATUSVALUE);
                        data->Current += strlen(data->Current);
                        sprintf(data->Current, "<%s type=\"A\">%c</%s>", OUT_MSGCATE, TRS.get_char(node, OUT_MSGCATE), OUT_MSGCATE);
                        data->Current += strlen(data->Current);
                    }
                }

                sprintf(data->Current, "<APPLICATION type=\"A\">%s</APPLICATION>", gs_server_name); data->Current += strlen(data->Current);

                {
                    char s_module[31];
                    char s_version[31];

                    memset(s_module, 0x00, sizeof(s_module));
                    memset(s_version, 0x00, sizeof(s_version));

                    UXML_get_module_version(s_module, s_version, node->Name);

                    if(s_module[0] == 0x00)
                    {
                        strcpy(s_module, TRS.get_string(node, "__MODULE"));
                    }

                    sprintf(data->Current, "<MODULE type=\"A\">%s</MODULE>", s_module); data->Current += strlen(data->Current);
                    sprintf(data->Current, "<MODULE_VERSION type=\"A\">%s</MODULE_VERSION>", s_version); data->Current += strlen(data->Current);
                }

                b_skip_member = 'Y';
            }
        }

        if(TRS.get_member(node, OUT_STATUSVALUE) != 0x00 && TRS.get_char(node, OUT_STATUSVALUE) == MP_FAIL_C)
        {
            for(i = 0; i < node->MemberCount; i++)
            {
                if(strcmp(node->Members[i]->Name, OUT_DBERRMSG) == 0)
                {
                    UXML_write_xml_string_sub(data, node->Members[i], b_xsi_namespace_defined);
                    break;
                }
            }

            for(i = 0; i < node->ListCount; i++)
            {
                if(strcmp(node->List[i]->Name, OUT_FIELDMSG) == 0)
                {
                    for(i1 = 0; i1 < node->List[i]->Count; i1++)
                    {
                        UXML_write_xml_string_sub(data, node->List[i]->Items[i1], b_xsi_namespace_defined);
                    }
                    break;
                }
            }
        }
        else
        {
            for(i = 0; i < node->MemberCount; i++)
            {
                if(b_skip_member == 'Y')
                {
                    if(strcmp(node->Members[i]->Name, OUT_STATUSVALUE) == 0) continue;
                    if(strcmp(node->Members[i]->Name, OUT_MSGCODE) == 0)     continue;
                    if(strcmp(node->Members[i]->Name, OUT_MSGCATE) == 0)     continue;
                    if(strcmp(node->Members[i]->Name, OUT_MSG) == 0)         continue;
                }

                UXML_write_xml_string_sub(data, node->Members[i], b_xsi_namespace_defined);
            }

            for(i = 0; i < node->ListCount; i++)
            {
                for(i1 = 0; i1 < node->List[i]->Count; i1++)
                {
                    UXML_write_xml_string_sub(data, node->List[i]->Items[i1], b_xsi_namespace_defined);
                }
            }
        }

        if(b_exist_attribute == 'Y')
        {
            UXML_remove_escape_char(s_tag_name, node->Name);
            sprintf(data->Current, "</%s>", s_tag_name);
            data->Current += strlen(data->Current);
        }
    }
}

void UXML_to_xml_string(char* xmlString, const TRSNode *node)
{
    char            s_value[1000];
    int             i_ret;
    int             i_len;

    char            s_user_xml_namespace_url[256];
    char            s_user_xml_namespace_xsi[256];
    char            b_xsi_namespace_defined;

    XmlStrData* data = (XmlStrData*)malloc(sizeof(XmlStrData));

    data->String = xmlString;
    data->Current = xmlString;

    b_xsi_namespace_defined = ' ';

    if(TRS.get_member(node, OUT_STATUSVALUE) != 0x00)
    {
        /* In case of Reply */

        memset(s_user_xml_namespace_url, 0x00, sizeof(s_user_xml_namespace_url));
        memset(s_user_xml_namespace_xsi, 0x00, sizeof(s_user_xml_namespace_xsi));

        memset(s_value, 0x00, sizeof(s_value));
        if(TRS.get_member(g_node_var, "UserXMLNamespaceUrl") == 0x00)
        {
            i_ret = COM_get_init_value(gs_svr_file, "CustomOptions", "UserXMLNamespaceUrl", s_value, &i_len);
            if(i_ret == MP_FALSE) 
            {
                LOG_head("UXML_to_xml_string : COM_get_init_value");
                LOG_add("gs_svr_file", MP_NSTR, gs_svr_file);
                LOG_add("s_key", MP_NSTR, "UserXMLNamespaceUrl");
                COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
            }

            TRS.set_nstring(g_node_var, "UserXMLNamespaceUrl", s_value);
        }
        else
        {
            TRS.get_string_param(g_node_var, "UserXMLNamespaceUrl", s_value);
        }
        strcpy(s_user_xml_namespace_url, s_value);

        memset(s_value, 0x00, sizeof(s_value));
        if(TRS.get_member(g_node_var, "UserXMLNamespaceXsi") == 0x00)
        {
            i_ret = COM_get_init_value(gs_svr_file, "CustomOptions", "UserXMLNamespaceXsi", s_value, &i_len);
            if(i_ret == MP_FALSE) 
            {
                LOG_head("UXML_to_xml_string : COM_get_init_value");
                LOG_add("gs_svr_file", MP_NSTR, gs_svr_file);
                LOG_add("s_key", MP_NSTR, "UserXMLNamespaceXsi");
                COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
            }

            TRS.set_nstring(g_node_var, "UserXMLNamespaceXsi", s_value);
        }
        else
        {
            TRS.get_string_param(g_node_var, "UserXMLNamespaceXsi", s_value);
        }
        strcpy(s_user_xml_namespace_xsi, s_value);


        if(COM_isnullspace(s_user_xml_namespace_url) == MP_TRUE || COM_isnullspace(s_user_xml_namespace_xsi) == MP_TRUE)
        {
            sprintf(data->Current, "<?xml version=\"1.0\" encoding=\"UTF-8\"?><%s>", XML_TAG_MSG);
        }
        else
        {
            memset(s_value, 0x00, sizeof(s_value));
            sprintf(s_value, "%s/MES/%s/%s/%sReply", s_user_xml_namespace_url,
                gs_server_name,
                gs_msg_service_name,
                gs_msg_service_name);

            sprintf(data->Current, "<?xml version=\"1.0\" encoding=\"UTF-8\"?><%s ", XML_TAG_MSG);
            data->Current += strlen(data->Current);

            sprintf(data->Current, "xmlns:xsi=\"%s\" xmlns=\"%s\" xsi:schemaLocation=\"%s %s.xsd\">", s_user_xml_namespace_xsi,
                s_value,
                s_value,
                s_value);
            b_xsi_namespace_defined = 'Y';
        }
    }
    else
    {
        /* No Reply case */
        sprintf(data->Current, "<?xml version=\"1.0\" encoding=\"UTF-8\"?><%s>", XML_TAG_MSG);
    }

    data->Current += strlen(data->Current);

    UXML_write_xml_string(data, node, b_xsi_namespace_defined);

    sprintf(data->Current, "</%s>", XML_TAG_MSG);

    data->String = 0x00;
    data->Current = 0x00;

    free(data);
}

#endif
