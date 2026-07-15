#if defined(_TIBRV)

#include "UXML_common.h"
#include <TRSCore_functions.h>
#include <expat.h>
#include <errno.h>

XML_Parser  mes_parser;
TRSNode *p_prev_node;
char    s_prev_node_name[_TRS_NAME_SIZE];
char    c_proc_step;

char        s_error_message[400];

ParseData* UXML_create_parser_input() 
{ 
    ParseData* userData = (ParseData*)malloc(sizeof(ParseData)); 
    memset(userData, 0, sizeof(ParseData)); 
    userData->Tag = NONE;
    userData->Part = MESMSG;
    return userData; 
} 

TRSDataType UXML_get_data_type(const char* type)
{
    size_t len = 0;
    char t = type[0];

    switch(t)
    {
        case 'A':
            len = strlen(type);
            if(len == 1)
                return DT_NSTRING;
            else
                return DT_ARRAY;
        case 'C':
            return DT_CHAR;
        case 'B':
            len = strlen(type);
            t = type[1];
            if(len == 1)
                return DT_BINARY;
            else if(t == 'L')
                return DT_BOOLEAN;
            else if(t == 'O')
                return DT_BLOB;
            break;
        case 'U':
            t = type[1];
            switch(t)
            {
            case '1':
                return DT_UBYTE;
            case '2':
                return DT_USHORT;
            case '4':
                return DT_UINT;
            case '8':
                return DT_ULONG;
            }
            break;
        case 'F':
            t = type[1];
            switch(t)
            {
            case '4':
                return DT_FLOAT;
            case '8':
                return DT_DOUBLE;
            }
            break;
        case 'I':
            t = type[1];
            switch(t)
            {
            case '1':
                return DT_BYTE;
            case '2':
                return DT_SHORT;
            case '4':
                return DT_INT;
            case '8':
                return DT_LONG;
            }
            break;
        case 'D':
            return DT_DATETIME;
        case 'L':
            return DT_LIST;
    }

    return DT_NOVALUESTRING;
}

void UXML_extract_namespace(char *s_namespace, char *s_name, const char *s_value)
{
    int i;
    int i_value_len;
    int i_separator;
    char s_namespace_t[255];
    char s_name_t[255];

    memset(s_namespace_t, 0x00, sizeof(s_namespace_t));
    memset(s_name_t, 0x00, sizeof(s_name_t));
    strcpy(s_namespace, s_namespace_t);
    strcpy(s_name, s_name_t);

    if(s_value == 0x00)
        return;

    i_value_len = (int)strlen(s_value);
    if(i_value_len < 1)
        return;

    i_separator = 0;
    for(i = i_value_len - 1; i > 0; i--)
    {
        if(s_value[i] == XML_NAMESPACE_SEPARATOR)
        {
            i_separator = i;
            break;
        }
    }

    if(i_separator > 0)
    {
        memcpy(s_namespace_t, s_value, i_separator);
        memcpy(s_name_t, s_value + i_separator + 1, i_value_len - i_separator - 1);
        strcpy(s_namespace, s_namespace_t);
        strcpy(s_name, s_name_t);

        return;
    }

    i_separator = 0;
    for(i = i_value_len - 1; i > 0; i--)
    {
        if(s_value[i] == ':')
        {
            i_separator = i;
            break;
        }
    }

    if(i_separator > 0)
    {
        memcpy(s_name_t, s_value + i_separator + 1, i_value_len - i_separator - 1);
        strcpy(s_name, s_name_t);

        return;
    }

    strcpy(s_name, s_value);
}

char* UXML_get_attr_value(const char **attr, const char *s_name)
{
    int i;
    char *s_value;
    char s_namespace_t[255];
    char s_name_t[255];

    memset(s_namespace_t, 0x00, sizeof(s_namespace_t));
    memset(s_name_t, 0x00, sizeof(s_name_t));

    s_value = 0x00;
    for(i = 0; i < 100; i += 2)
    {
        if(attr[i] == 0x00)
            break;

        UXML_extract_namespace(s_namespace_t, s_name_t, attr[i]);
        if(strcmp(s_name_t, s_name) == 0)
        {
            s_value = attr[i + 1];
            break;
        }
    }

    return s_value;
}

int UXML_validate_xml_value(ParseData* userData, TRSDataType type, const char *text, int len)
{
    int b_valid_value;
    char s_text[MAXIMUM_STRING_VALUE_BYTES];

    b_valid_value = 1;

    if(userData->NullFlag == 'Y')
    {
        return b_valid_value;
    }

    memset(s_text, 0x00, sizeof(s_text));
    if(len < MAXIMUM_STRING_VALUE_BYTES)
    {
        memcpy(s_text, text, len);
    }

    switch(type)
    {
    case DT_NSTRING:
        if(len > MAXIMUM_STRING_VALUE_BYTES - 1)
        {
            sprintf(s_error_message, "STRING value can not over %d bytes. Member Name=[%s]",
                    (MAXIMUM_STRING_VALUE_BYTES - 1),
                                     userData->ValueName);
            b_valid_value = 0;
        }
        break;
    case DT_BOOLEAN:
        if(TRS_strcmp_toupper(s_text, "TRUE") != 0 && TRS_strcmp_toupper(s_text, "FALSE") != 0)
        {
            sprintf(s_error_message, "Can not convert to BOOLEAN. Member Name=[%s], Value=[%s]",
                                     userData->ValueName, s_text);
            b_valid_value = 0;
        }
        break;
    case DT_CHAR:
        if(len > 1)
        {
            sprintf(s_error_message, "CHAR value must be only one character. Member Name=[%s], Value=[%s], Length = [%d]",
                                     userData->ValueName, s_text, len);
            b_valid_value = 0;
        }
        else if(s_text[0] < 0 || s_text[0] > 127)
        {
            sprintf(s_error_message, "CHAR value out of range. Range is 0 ~ 127. Member Name=[%s], Value=[%d]",
                                     userData->ValueName, s_text[0]);
            b_valid_value = 0;
        }
        break;
    case DT_BINARY:
    case DT_BYTE:
    case DT_SHORT:
    case DT_INT:
    case DT_LONG:
        {
            long l_val;
            char *s_stop;
            char s_type_string[100];

            memset(s_type_string, 0x00, sizeof(s_type_string));
            TRS_get_type_string(s_type_string, type);

            s_stop = 0x00;
            errno = 0;
            l_val = strtol(s_text, &s_stop, 10);
            if(errno != 0 || s_text[0] == 0x00 || (s_stop != 0x00 && s_stop[0] != 0x00))
            {
                sprintf(s_error_message, "Can not convert to %s. Member Name=[%s], Value=[%s]",
                                         s_type_string, userData->ValueName, s_text);
                b_valid_value = 0;
                break;
            }

            switch(type)
            {
            case DT_BINARY:
                if(l_val < 0 || l_val > 255)
                {
                    sprintf(s_error_message, "BINARY value out of range. Range is 0 ~ 255. Member Name=[%s], Value=[%s]",
                                             userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            case DT_BYTE:
                if(l_val < -128 || l_val > 127)
                {
                    sprintf(s_error_message, "BYTE value out of range. Range is -128 ~ 127. Member Name=[%s], Value=[%s]",
                                             userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            case DT_SHORT:
                if(l_val < SHRT_MIN || l_val > SHRT_MAX)
                {
                    sprintf(s_error_message, "SHORT value out of range. Range is %d ~ %d. Member Name=[%s], Value=[%s]",
                                             SHRT_MIN, SHRT_MAX, userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            case DT_INT:
                if(l_val < INT_MIN || l_val > INT_MAX)
                {
                    sprintf(s_error_message, "INT value out of range. Range is %d ~ %d. Member Name=[%s], Value=[%s]",
                                             INT_MIN, INT_MAX, userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            case DT_LONG:
                if(l_val < LONG_MIN || l_val > LONG_MAX)
                {
                    sprintf(s_error_message                          , "LONG value out of range. Range is %ld", LONG_MIN);
                    sprintf(s_error_message + strlen(s_error_message), " ~ %ld", LONG_MAX);
                    sprintf(s_error_message + strlen(s_error_message), ". Member Name=[%s], Value=[%s]", userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            default:
                break;
            }
        }
        break;
    case DT_UBYTE:
    case DT_USHORT:
    case DT_UINT:
    case DT_ULONG:
        {
            unsigned long ul_val;
            char *s_stop;
            char s_type_string[100];

            memset(s_type_string, 0x00, sizeof(s_type_string));
            TRS_get_type_string(s_type_string, type);

            s_stop = 0x00;
            errno = 0;
            ul_val = strtoul(s_text, &s_stop, 10);
            if(errno != 0 || s_text[0] == 0x00 || (s_stop != 0x00 && s_stop[0] != 0x00))
            {
                sprintf(s_error_message, "Can not convert to %s. Member Name=[%s], Value=[%s]",
                                         s_type_string, userData->ValueName, s_text);
                b_valid_value = 0;
                break;
            }

            if(s_text[0] == '-')
            {
                sprintf(s_error_message, "This %s type requires a positive number. Member Name=[%s], Value=[%s]",
                                         s_type_string, userData->ValueName, s_text);
                b_valid_value = 0;
                break;
            }

            switch(type)
            {
            case DT_UBYTE:
                if(ul_val < 0 || ul_val > 255)
                {
                    sprintf(s_error_message, "UNSIGNED BYTE value out of range. Range is 0 ~ 255. Member Name=[%s], Value=[%s]",
                                             userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            case DT_USHORT:
                if(ul_val < 0 || ul_val > USHRT_MAX)
                {
                    sprintf(s_error_message, "UNSIGNED SHORT value out of range. Range is 0 ~ %d. Member Name=[%s], Value=[%s]",
                                             USHRT_MAX, userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            case DT_UINT:
                if(ul_val < 0 || ul_val > UINT_MAX)
                {
                    sprintf(s_error_message, "UNSIGNED INT value out of range. Range is 0 ~ %ld. Member Name=[%s], Value=[%s]",
                                             UINT_MAX, userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            case DT_ULONG:
                if(ul_val < 0 || ul_val > ULONG_MAX)
                {
                    sprintf(s_error_message                          , "UNSIGNED LONG value out of range. Range is 0 ~ %lu", ULONG_MAX);
                    sprintf(s_error_message + strlen(s_error_message), ". Member Name=[%s], Value=[%s]", userData->ValueName, s_text);
                    b_valid_value = 0;
                }
                break;
            default:
                break;
            }
        }
        break;
    case DT_FLOAT:
    case DT_DOUBLE:
        {
            double d_val;
            char *s_stop;
            char s_type_string[100];

            memset(s_type_string, 0x00, sizeof(s_type_string));
            TRS_get_type_string(s_type_string, type);

            s_stop = 0x00;
            errno = 0;
            d_val = strtod(s_text, &s_stop);
            if(errno != 0 || s_text[0] == 0x00 || (s_stop != 0x00 && s_stop[0] != 0x00))
            {
                sprintf(s_error_message, "Can not convert to %s. Member Name=[%s], Value=[%s]",
                                         s_type_string, userData->ValueName, s_text);
                b_valid_value = 0;
            }
        }
        break;
    case DT_DATETIME:
        {
            char s_datetime[23];

            memset(s_datetime, 0x00, sizeof(s_datetime));
            if(TRS_convert_datetime(s_datetime, s_text) < 1)
            {
                sprintf(s_error_message, "Can not convert to DATETIME. Member Name=[%s], Value=[%s]",
                                         userData->ValueName, s_text);
                b_valid_value = 0;
            }
        }
        break;
    case DT_BLOB:
        break;
    default:
        break;
    }

    if(b_valid_value == 0)
    {
        XML_StopParser(mes_parser, XML_FALSE);
    }

    return b_valid_value;
}

void UXML_start_element_body_part(ParseData *userData, const char *element, const char **attr)
{
    TRSDataType type = 0x00;
    char itemName[10];
    char *s_attr_value;

    if(strcmp(element, EXT_XML_TAG_ITEM) == 0)
    {
        type = DT_ITEM;
    }
    else
    {
        type = DT_NSTRING;
        if((s_attr_value = UXML_get_attr_value(attr, EXT_XML_TAG_TYPE)) != 0x00)
        {
            type = UXML_get_data_type(s_attr_value);
        }
    }

    if(element != 0x00)
    {
        c_proc_step = 'R'; // Read

        if(type == DT_LIST)
        {
            userData->Tag = LIST;
            userData->ValueType = DT_LIST;

            if(strcmp(userData->ValueName, element) == 0 && userData->LastMember != 0x00)
            {
                userData->Current = userData->LastMember;
            }
            else
            {
                userData->Current = TRS.add_node(userData->Current, element);
            }
        }
        else if(type == DT_ARRAY)
        {
            userData->Tag = ARRAY;
            userData->ValueType = DT_ARRAY;

            s_attr_value = UXML_get_attr_value(attr, EXT_XML_TAG_ARRAYTYPE);
            userData->ArrayType = UXML_get_data_type(s_attr_value);
            userData->Current = TRS.add_array(userData->Current, element, userData->ArrayType);
        }
        else if(type == DT_ITEM) // Array Item
        {
            c_proc_step = 'S'; // attribute Start

            p_prev_node = 0x00;
            userData->Tag = ITEM;
            userData->EncryptFlag = 0;
            userData->NullFlag = 0;

            memset(itemName, 0x00, sizeof(itemName));
            sprintf(itemName, "%d", userData->ItemCount);
            strcpy(userData->ValueName, itemName); // Item Name
            userData->ItemCount++;

            if((s_attr_value = UXML_get_attr_value(attr, "nil")) != 0x00)
            {
                if(memcmp(s_attr_value, "true", 4) == 0)
                {
                    userData->NullFlag = 'Y';
                }
            }
        }
        else
        {
            c_proc_step = 'S'; // attribute Start

            p_prev_node = 0x00;
            userData->Tag = DATA;
            userData->EncryptFlag = 0;
            userData->NullFlag = 0;

            strcpy(userData->ValueName, element);       // Name
            if(userData->Depth == 2)
            {
                if(strcmp(element, "MODULE") == 0)
                    strcpy(userData->ValueName, "_MODULE_NAME");
                else if(strcmp(element, "CMD") == 0)
                    strcpy(userData->ValueName, "_SERVICE_NAME");
            }
            userData->ValueType = type;             // Type

            if((s_attr_value = UXML_get_attr_value(attr, "nil")) != 0x00)
            {
                if(memcmp(s_attr_value, "true", 4) == 0)
                {
                    userData->NullFlag = 'Y';
                }
            }

            if(type == DT_NSTRING)
            {
                if((s_attr_value = UXML_get_attr_value(attr, "encrypt")) != 0x00)
                {
                    if(memcmp(s_attr_value, "true", 4) == 0)
                    {
                        userData->EncryptFlag = 'Y';
                    }
                }
            }
            else if(type == DT_DATETIME)
            {
                memset(userData->DateTimeFormat, 0x00, sizeof(userData->DateTimeFormat));

                if((s_attr_value = UXML_get_attr_value(attr, "Format")) != 0x00)
                {
                    strcpy(userData->DateTimeFormat, s_attr_value);
                }
            } //end if type
        } //end if type
    } //end if element
}

void UXML_process_data(ParseData* userData, TRSDataType type, const char *text, int len)
{
    TRSNode *node;
    char s_text[MAXIMUM_STRING_VALUE_BYTES];

    c_proc_step = 'P'; // attribute Process

    node = 0x00;
    memset(s_text, 0x00, sizeof(s_text));

    if(len < MAXIMUM_STRING_VALUE_BYTES)
    {
        memcpy(s_text, text, len);
    }

    if(UXML_validate_xml_value(userData, type, text, len) == 0)
    {
        return ;
    }

    switch(type)
    {
    case DT_NSTRING:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_nstring(userData->Current, userData->ValueName, 0x00);
        }
        else
        {
            char s_buff[MAXIMUM_STRING_VALUE_BYTES];
            char s_buff_2[MAXIMUM_STRING_VALUE_BYTES];
            int i_len;

            memset(s_buff, 0x00, sizeof(s_buff));
            memset(s_buff_2, 0x00, sizeof(s_buff_2));

            if(userData->EncryptFlag == 'Y')
            {
                memcpy(s_buff, s_text, len);
                TRS_decrypt(s_buff_2, s_buff);
                i_len = (int)strlen(s_buff_2);
            }
            else
            {
                memcpy(s_buff_2, s_text, len);
                i_len = (int)strlen(s_buff_2);
            }

            memset(s_buff, 0x00, sizeof(s_buff));
            UTF8ToAnsi(s_buff, (unsigned char*)s_buff_2, i_len);
            i_len = (int)strlen(s_buff);

            if(i_len == 1 && s_buff[0] == 0x0A)
            {
                s_buff[0] = 0x0D;
                s_buff[1] = 0x0A;
                s_buff[2] = 0x00;
                i_len = 2;
            }

            if(userData->Current == p_prev_node &&
               memcmp(userData->ValueName, s_prev_node_name, _TRS_NAME_SIZE) == 0)
            {
                char s_buff_1[MAXIMUM_STRING_VALUE_BYTES];

                strcpy(s_buff_1, TRS.get_string(userData->Current, userData->ValueName));
                strcat(s_buff_1, s_buff);

                node = TRS.set_nstring(userData->Current, userData->ValueName, s_buff_1);
            }
            else
            {
                node = TRS.add_nstring(userData->Current, userData->ValueName, s_buff);
            }

            p_prev_node = userData->Current;
            memcpy(s_prev_node_name, userData->ValueName, _TRS_NAME_SIZE);
        }
        break;

    case DT_CHAR:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, DT_CHAR, 0x00);
        }
        else
        {
            node = TRS_add_member(userData->Current, userData->ValueName, DT_CHAR, s_text[0]);
        }
        break;
    case DT_BINARY:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, DT_BINARY, 0);
            if(node != 0x00)
                node->NullFlag = 'Y';
        }
        else
        {
            int i_val;
            unsigned char c_val;

            i_val = atoi(s_text);
            c_val = (unsigned char)i_val;
            
            node = TRS_add_member(userData->Current, userData->ValueName, DT_BINARY, c_val);
        }
        break;
    case DT_BOOLEAN:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, DT_BOOLEAN, 0);
            if(node != 0x00)
                node->NullFlag = 'Y';
        }
        else
        {
            if(s_text[0] == 'T' || s_text[0] == 't')
                node = TRS_add_member(userData->Current, userData->ValueName, DT_BOOLEAN, 1);
            else
                node = TRS_add_member(userData->Current, userData->ValueName, DT_BOOLEAN, 0);
        }
        break;
    case DT_UBYTE:
    case DT_USHORT:
    case DT_UINT:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, type, 0);
            if(node != 0x00)
                node->NullFlag = 'Y';
        }
        else
        {
            char **ptr = 0x00;
            unsigned long l_val = strtoul(s_text, ptr, 10);
            node = TRS_add_member(userData->Current, userData->ValueName, type, l_val);
        }
        break;
    case DT_ULONG:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, type, 0);
            if(node != 0x00)
                node->NullFlag = 'Y';
        }
        else
        {
            char **ptr = 0x00;
            unsigned long l_val = strtoul(s_text, ptr, 10);
            node = TRS_add_member(userData->Current, userData->ValueName, type, l_val);
        }
        break;
    case DT_BYTE:
    case DT_SHORT:
    case DT_INT:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, type, 0);
            if(node != 0x00)
                node->NullFlag = 'Y';
        }
        else
        {
            int i_val = atoi(s_text);
            node = TRS_add_member(userData->Current, userData->ValueName, type, i_val);
        }
        break;
    case DT_LONG:                
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, type, 0);
            if(node != 0x00)
                node->NullFlag = 'Y';
        }
        else
        {
            long l_val = atol(s_text);
            node = TRS_add_member(userData->Current, userData->ValueName, type, l_val);
        }
        break;
    case DT_FLOAT:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, type, 0);
            if(node != 0x00)
            {
                node->NullFlag = 'Y';
                node->Value.f4 = 0;
            }
        }
        else
        {
            double d_val = atof(s_text);
            node = TRS_add_member(userData->Current, userData->ValueName, type, d_val);
        }
        break;
    case DT_DOUBLE:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, type, 0);
            if(node != 0x00)
            {
                node->NullFlag = 'Y';
                node->Value.f8 = 0;
            }
        }
        else
        {
            double d_val = atof(s_text);
            node = TRS_add_member(userData->Current, userData->ValueName, type, d_val);
        }
        break;
    case DT_DATETIME:
        if(userData->NullFlag == 'Y')
        {
            node = TRS.add_datetime(userData->Current, userData->ValueName, 0x00);
        }
        else
        {
            if(userData->DateTimeFormat[0] == 0x00)
            {
                node = TRS.add_datetime(userData->Current, userData->ValueName, s_text);
            }
            else
            {
                node = TRS.add_datetime_f(userData->Current, userData->ValueName, s_text, userData->DateTimeFormat);
            }
        }
        break;
    case DT_BLOB:
        if(userData->NullFlag == 'Y')
        {
            node = TRS_add_member(userData->Current, userData->ValueName, DT_BLOB, 0, 0x00);
        }
        else
        {
            unsigned char* us_buff;
            size_t out_len = 0;

            us_buff = base64_decode((unsigned char*)text, len, &out_len);

            node = TRS_add_member(userData->Current, userData->ValueName, DT_BLOB, out_len, us_buff);
        }
        break;
    default:
        break;
    } //end switch

    userData->LastMember = node;
    userData->LastMemberDepth = userData->Depth;
}

void UXML_start_element(ParseData *userData, const char *element, const char **attr)
{
    char s_namespace[255];
    char s_element[255];

    userData->Depth++;    

    memset(s_namespace, 0x00, sizeof(s_namespace));
    memset(s_element, 0x00, sizeof(s_element));

    UXML_extract_namespace(s_namespace, s_element, element);

    if(userData->Depth <= 1)
    {
        if(attr[1] != 0x00)
        {
            strcpy(userData->Body->Name, s_element);
        }
    }
    else
    {
        UXML_start_element_body_part(userData, s_element, attr);
    }    
}

void UXML_get_text_data(ParseData* userData, const char *text, int len)
{
    if(c_proc_step == 'E')
        return ;

    if(userData->Depth > 0)
    {
        if(userData->Tag == DATA)
        {
            UXML_process_data(userData, userData->ValueType, text, len);
        }        
        else if(userData->Tag == ITEM)
        {
            UXML_process_data(userData, userData->ArrayType, text, len);
        }
    }
}

void UXML_end_element(ParseData *userData, const char *element)
{
    char s_namespace[255];
    char s_element[255];

    userData->Depth--;

    memset(s_namespace, 0x00, sizeof(s_namespace));
    memset(s_element, 0x00, sizeof(s_element));

    UXML_extract_namespace(s_namespace, s_element, element);

    if(userData->Current->Parent != 0x00 && strcmp(userData->Current->Name, s_element) == 0)
    {
        if(userData->Current->MemberCount > 0 &&
           userData->Depth + 1 == userData->LastMemberDepth &&
           strcmp(userData->LastMember->Name, s_element) == 0)
        {
            ;
        }
        else
        {
        if(userData->Current->ValueType == DT_ARRAY)
        {
            userData->ItemCount = 0;
        }

        userData->Current = userData->Current->Parent;
    }
    }
    else
    {
        /* <STRING type="A" nil="true"/> */
        /* <STRING type="A"/> */
        /* <item nil="true"/> */
        /* In this case don't process UXML_process_data(). */
        /* So have to process UXML_process_data(). */
        if(c_proc_step == 'S')
        {
            UXML_process_data(userData, userData->ValueType, "", 0);
        }
    }

    c_proc_step = 'E';
}

void UXML_start_namespace(ParseData *userData, const char *prefix, const char *uri)
{
}

void UXML_end_namespace(ParseData *userData, const char *prefix)
{
}

int UXML_parse(TRSNode *node, const char* xmlString, const size_t len, char* s_err_msg)
{
    ParseData* userData = UXML_create_parser_input();     

    if(xmlString == 0x00)
    {
        sprintf(s_err_msg, "Empty xml string.");
        return 0;
    }

    memset(s_error_message, 0x00, sizeof(s_error_message));
    userData->Body = node;
    userData->Current = userData->Body;     

    mes_parser = XML_ParserCreateNS(0x00, XML_NAMESPACE_SEPARATOR);

    XML_SetUserData(mes_parser, userData);
    XML_SetElementHandler(mes_parser, UXML_start_element, UXML_end_element);
    XML_SetCharacterDataHandler(mes_parser, UXML_get_text_data);
    XML_SetNamespaceDeclHandler(mes_parser, UXML_start_namespace, UXML_end_namespace);

    if (!XML_Parse(mes_parser, xmlString, (int)len, 0))
    { 
        sprintf(s_err_msg, "%s at line %lu\n%s",
                            XML_ErrorString(XML_GetErrorCode(mes_parser)),
                            XML_GetCurrentLineNumber(mes_parser),
                            s_error_message);

        XML_ParserFree(mes_parser);
        free(userData);

        return 0;
    } 

    XML_ParserFree(mes_parser);
    free(userData);

    return 1;
}

#endif
