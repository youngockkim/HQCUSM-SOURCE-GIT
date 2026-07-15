///*******************************************************************************
//
//    System      : MESplus
//    Module      : User Defined Shared Library
//    File Name   : MES_null_db_sample.c
//    Description : user function of user defined shared library
//
//    MES Version : 5.0
//
//    Function List
//        - 
//
//    Detail Description
//        - 
//
//    History
//    Seq   Date        Developer      Description                        
//    ---------------------------------------------------------------------------
//    1     2009/03/10  Phillip Shin          Create
//
//    Copyright(C) 1998-2009 Miracom,Inc.
//    All rights reserved.
//
//*******************************************************************************/
//
//#include <MESCore_common.h>
//#include "TSDB_common.h"  /* Added By Phillip Shin (2009 . 02. 26) */
//
//
//extern int DEV_UPDATE_MEMBER(char *s_msg_code,
//                             TRSNode *In_node, 
//                             TRSNode *out_node);
//
//void DEV_encode_datetime(char *dest, char *src, int i_size);
//void DEV_decode_datetime(char *dest, char *src, int i_size);
//
///*******************************************************************************
//    BAS_Update_Attribute()
//        - Create/Update/Delete Test Field Value
//    return Value
//        - int : 0 (MP_TRUE)
//    Arguments
//        - BAS_in_node_Tag *in_node : Input Test Field structure
//        - out_node_Tag *out_node : Output Test Field structure
//*******************************************************************************/
//
//int DEV_Update_Member(TRSNode *in_node, TRSNode *out_node)
//{
//     char s_msg_code[MP_SIZE_MSG];
//    int i_ret;
//
//    memset(s_msg_code, 0x00, MP_SIZE_MSG);
//
//    i_ret = DEV_UPDATE_MEMBER(s_msg_code, in_node, out_node);
//
//    COM_out_msg_log_write(s_msg_code, "DEV_UPDATE_MEMBER", out_node);
//
//    if(i_ret == MP_TRUE) 
//    {
//        DB_commit();
//    }
//    else 
//    {
//        DB_rollback();
//    }
//
//    return MP_TRUE;
//}
//
///*******************************************************************************
//    BAS_UPDATE_ATTRIBUTE()
//        - Main sub function of "BAS_Update_Attribute" function
//        - Create/Update/Delete Attribute definition 
//    return Value
//        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
//    Arguments
//        - char *s_msg_code : Error Test Field Code
//        - TRSNode *in_node : Input Test Field structure
//        - TRSNode *out_node : Output Test Field structure
//*******************************************************************************/
//int DEV_UPDATE_MEMBER(char *s_msg_code,
//                      TRSNode *in_node, 
//                      TRSNode *out_node)
//{
//    struct MTSTDEVMBR_TAG   MTSTDEVMBR;
//    MDATETIME               date;
//    int                     i;
//    int                     i_list_count;
//    TRSNode                 **lst;
//    TRSNode                 *itm;
//    TRSNode                 *ary;
//    char                    s_tmp[10];
//    MSTRING                 s_item;
//
//    FILE                    *blob_file;
//    char                    *test_file_name;
//    MBLOB                   test_blob;
//
//    LOG_head("DEV_UPDATE_MEMBER");
//    /* Add value of member in TRSNode into log buffer */
//    TRSN.log_add(in_node, IN_LANGUAGE);
//    TRSN.log_add(in_node, IN_FACTORY);
//    TRSN.log_add(in_node, IN_USERID);
//    TRSN.log_add(in_node, IN_PROCSTEP);
//    TRSN.log_add(in_node, "TEST_ID");
//    
//    TRSN.log_add(in_node, "TEST_INT");
//    TRSN.log_add(in_node, "TEST_FLOAT");
//    TRSN.log_add(in_node, "TEST_DOUBLE");
//    TRSN.log_add(in_node, "TEST_LONG");
//    TRSN.log_add(in_node, "TEST_CHAR");
//    TRSN.log_add(in_node, "TEST_STRING");
//    TRSN.log_add(in_node, "TEST_BOOL");
//    TRSN.log_add(in_node, "TEST_BINARY");
//    TRSN.log_add(in_node, "TEST_DATETIME");
//    TRSN.log_add(in_node, "TEST_FILE_NAME");
//    TRSN.log_add(in_node, "TEST_BLOB");
//    TRSN.log_add(in_node, "TEST_LIST");
//    TRSN.log_add(in_node, "TEST_ARRAY");
//
//    TRSN.log_add(in_node, "NEXT_TEST_ID");
//
//    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
//
//    /* ProcStep Validation */
//    if(COM_service_validation(s_msg_code,
//                              in_node,
//                              out_node,
//                              TRS.get_procstep(in_node),
//                              "IUD1") == MP_FALSE)
//    {
//        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//        return MP_FALSE;
//    }
//   
//    /* MTSTDEVMBR Structure Initialize */
//    TSDB_init_mtstdevmbr(&MTSTDEVMBR);
//
//    /* Set Not Null Column From Field of Function Tester */
//    TRS.copy(MTSTDEVMBR.TEST_ID, sizeof(MTSTDEVMBR.TEST_ID), in_node, "TEST_ID");
//
//    /* SQL SELECT function For DB Sucess or DB Fail */
//    TSDB_select_mtstdevmbr(1, &MTSTDEVMBR);
//
//    if(DB_error_code != DB_SUCCESS) 
//    {
//        if(DB_error_code == DB_NOT_FOUND) 
//        {
//            if(TRSN.get_procstep(in_node) == MP_STEP_UPDATE || TRSN.get_procstep(in_node) == MP_STEP_DELETE)
//            {
//                strcpy(s_msg_code, "BAS-0002");
//                
//                TRSN.add_fieldmsg(out_node, "MTSTDEVMBR SELECT", MP_NVST);
//                TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//                TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//                gs_log_type.type = MP_LOG_ERROR;
//                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//                gs_log_type.category = MP_LOG_CATE_SETUP;
//
//                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//                return MP_FALSE;              
//            }
//        }
//        else
//        {
//            strcpy(s_msg_code, "BAS-0004");
//                
//            TRSN.add_fieldmsg(out_node, "MTSTDEVMBR SELECT", MP_NVST);
//            TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//            TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//            return MP_FALSE;              
//        }
//    }
//    else
//    {
//        if(TRSN.get_procstep(in_node) == MP_STEP_CREATE)
//        {
//            strcpy(s_msg_code, "BAS-0003");
//
//            TRSN.add_fieldmsg(out_node, "MTSTDEVMBR SELECT", MP_NVST);
//            TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//            return MP_FALSE;              
//        }
//    }
//    
//    if(TRSN.get_procstep(in_node) == MP_STEP_CREATE)
//    {
//        /* Assign value into nullable data type using TRS common functions */
//        MTSTDEVMBR.TEST_INT = TRSN.get_int(in_node, "TEST_INT");
//        MTSTDEVMBR.TEST_FLOAT = TRSN.get_float(in_node, "TEST_FLOAT");
//        MTSTDEVMBR.TEST_DOUBLE = TRSN.get_double(in_node, "TEST_DOUBLE");
//        MTSTDEVMBR.TEST_LONG = TRSN.get_long(in_node, "TEST_LONG");
//        MTSTDEVMBR.TEST_CHAR = TRSN.get_char(in_node, "TEST_CHAR");
//        MTSTDEVMBR.TEST_STRING = TRSN.get_string(in_node, "TEST_STRING");
//
//        MTSTDEVMBR.TEST_BOOL = TRSN.get_boolean(in_node, "TEST_BOOL");
//        MTSTDEVMBR.TEST_BINARY = TRSN.get_binary(in_node, "TEST_BINARY");
//
//        /* In case of datetime data type */
//        /* Received datetime value is ISO8601 formatted value. */
//        /* But DB date column does not recognize this value. */
//        /* So need ISO8601 formatted value to DB formatted value */
//        date = TRSN.get_datetime(in_node, "TEST_DATETIME");
//        if(date.IS_NULL != 'Y')
//        {
//            MTSTDEVMBR.TEST_DATETIME.IS_NULL = ' ';
//            DEV_decode_datetime(MTSTDEVMBR.TEST_DATETIME.VALUE, date.VALUE, sizeof(date.VALUE));
//        }
//
//        TSDB_insert_mtstdevmbr(&MTSTDEVMBR);
//
//        if(DB_error_code != DB_SUCCESS) 
//        {
//            strcpy(s_msg_code, "BAS-0004");
//
//            /* Normal data type for add field message */
//            TRSN.add_fieldmsg(out_node, "MTSTDEVMBR INSERT", MP_NVST);
//            TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//            /* Nullable data type for add field message */
//            TRSN.add_fieldmsg(out_node, "TEST_INT", MP_MINT, &MTSTDEVMBR.TEST_INT);
//            TRSN.add_fieldmsg(out_node, "TEST_FLOAT", MP_MFLT, &MTSTDEVMBR.TEST_FLOAT);
//            TRSN.add_fieldmsg(out_node, "TEST_DOUBLE", MP_MDBL, &MTSTDEVMBR.TEST_DOUBLE);
//            TRSN.add_fieldmsg(out_node, "TEST_LONG", MP_MLNG, &MTSTDEVMBR.TEST_LONG);
//            TRSN.add_fieldmsg(out_node, "TEST_CHAR", MP_MCHR, &MTSTDEVMBR.TEST_CHAR);
//            TRSN.add_fieldmsg(out_node, "TEST_STRING", MP_MSTR, &MTSTDEVMBR.TEST_STRING);
//            TRSN.add_fieldmsg(out_node, "TEST_BOOL", MP_MBOOL, &MTSTDEVMBR.TEST_BOOL);
//            TRSN.add_fieldmsg(out_node, "TEST_BINARY", MP_MBIN, &MTSTDEVMBR.TEST_BINARY);
//            TRSN.add_fieldmsg(out_node, "TEST_DATETIME", MP_MDATE, &MTSTDEVMBR.TEST_DATETIME);
//            TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//            return MP_FALSE;
//        }
//
//        /* In case of list */
//        /* First way, Extract TRSNode structure */
//        lst = TRSN.get_list(in_node, "TEST_LIST");
//        i_list_count = TRSN.get_item_count(in_node, "TEST_LIST");
//
//        for(i = 0; i < i_list_count; i++)
//        {
//            itm = lst[i];
//
//            TSDB_init_mtstdevmbr(&MTSTDEVMBR);
//            TRS.copy(MTSTDEVMBR.TEST_ID, sizeof(MTSTDEVMBR.TEST_ID), itm, "TEST_ID");
//
//            MTSTDEVMBR.TEST_INT = TRSN.get_int(itm, "LIST_INT");
//            MTSTDEVMBR.TEST_DOUBLE = TRSN.get_double(itm, "LIST_DOUBLE");
//            MTSTDEVMBR.TEST_STRING = TRSN.get_string(itm, "LIST_STRING");
//
//            TSDB_insert_mtstdevmbr(&MTSTDEVMBR);
//
//            if(DB_error_code != DB_SUCCESS) 
//            {
//                strcpy(s_msg_code, "BAS-0004");
//
//                TRSN.add_fieldmsg(out_node, "MTSTDEVMBR INSERT", MP_NVST);
//                TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//                TRSN.add_fieldmsg(out_node, "LIST_INT", MP_MINT, &MTSTDEVMBR.TEST_INT);
//                TRSN.add_fieldmsg(out_node, "LIST_DOUBLE", MP_MDBL, &MTSTDEVMBR.TEST_DOUBLE);
//                TRSN.add_fieldmsg(out_node, "LIST_STRING", MP_MSTR, &MTSTDEVMBR.TEST_STRING);
//                TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//                gs_log_type.type = MP_LOG_ERROR;
//                gs_log_type.e_type = MP_LOG_E_SYSTEM;
//                gs_log_type.category = MP_LOG_CATE_SETUP;
//
//                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//                return MP_FALSE;
//            }        
//        }
//
//        /* In case of list */
//        /* Second way, Using single list properties */
//        /* The same result, if use only one list */
//        for(i = 0; i < in_node->SCount; i++)
//        {
//            itm = in_node->SItems[i];
//
//            TSDB_init_mtstdevmbr(&MTSTDEVMBR);
//            TRS.copy(MTSTDEVMBR.TEST_ID, sizeof(MTSTDEVMBR.TEST_ID), itm, "TEST_ID");
//
//            MTSTDEVMBR.TEST_INT = TRSN.get_int(itm, "LIST_INT");
//            MTSTDEVMBR.TEST_DOUBLE = TRSN.get_double(itm, "LIST_DOUBLE");
//            MTSTDEVMBR.TEST_STRING = TRSN.get_string(itm, "LIST_STRING");
//
//            LOG_head("TEST_LIST items");
//
//            LOG_add("TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//            LOG_add("LIST_INT", MP_MINT, &MTSTDEVMBR.TEST_INT);
//            LOG_add("LIST_DOUBLE", MP_MDBL, &MTSTDEVMBR.TEST_DOUBLE);
//            LOG_add("LIST_STRING", MP_MSTR, &MTSTDEVMBR.TEST_STRING);
//
//            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
//        }
//
//        /* In case of array */
//        memset(s_tmp, 0x00, sizeof(s_tmp));
//        ary = TRSN.get_array(in_node, "TEST_ARRAY");
//        
//        LOG_head("TEST_ARRAY items");
//
//        if (ary != 0x00)
//        {
//            for(i = 0; i < ary->MemberCount; i++)
//            {
//                /* Array item is also one of the TRSNode. So array item should have own name. */
//                /* To get value of array item, have to use this name. */
//                sprintf(s_tmp, "%d", i);
//                s_item = TRSN.get_string(ary, s_tmp);
//                
//                LOG_add(s_tmp, MP_MSTR, &s_item);
//            }
//            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
//        }
//
//        test_file_name = TRS.get_string(in_node, "TEST_FILE_NAME");
//        test_blob = TRSN.get_blob(in_node, "TEST_BLOB");
//        
//        if(test_blob.IS_NULL != 'Y')
//        {
//            blob_file = fopen(test_file_name, "wb");
//            fwrite(test_blob.VALUE, sizeof(unsigned char), test_blob.SIZE, blob_file);
//            fclose(blob_file);
//        }
//
//    }
//    else if(TRSN.get_procstep(in_node) == MP_STEP_UPDATE)
//    {
//        MTSTDEVMBR.TEST_INT = TRSN.get_int(in_node, "TEST_INT");
//        MTSTDEVMBR.TEST_FLOAT = TRSN.get_float(in_node, "TEST_FLOAT");
//        MTSTDEVMBR.TEST_DOUBLE = TRSN.get_double(in_node, "TEST_DOUBLE");
//        MTSTDEVMBR.TEST_LONG = TRSN.get_long(in_node, "TEST_LONG");
//        MTSTDEVMBR.TEST_CHAR = TRSN.get_char(in_node, "TEST_CHAR");
//        MTSTDEVMBR.TEST_STRING = TRSN.get_string(in_node, "TEST_STRING");
//
//        MTSTDEVMBR.TEST_BOOL = TRSN.get_boolean(in_node, "TEST_BOOL");
//        MTSTDEVMBR.TEST_BINARY = TRSN.get_binary(in_node, "TEST_BINARY");
//        date = TRSN.get_datetime(in_node, "TEST_DATETIME");
//        if(date.IS_NULL != 'Y')
//            DEV_decode_datetime(MTSTDEVMBR.TEST_DATETIME.VALUE, date.VALUE, sizeof(date.VALUE));
//
//       TSDB_update_mtstdevmbr(1, &MTSTDEVMBR);
//       if(DB_error_code != DB_SUCCESS) 
//       {
//            strcpy(s_msg_code, "BAS-0004");
//
//            TRSN.add_fieldmsg(out_node, "MTSTDEVMBR UPDATE", MP_NVST);
//            TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//            TRSN.add_fieldmsg(out_node, "TEST_INT", MP_MINT, &MTSTDEVMBR.TEST_INT);
//            TRSN.add_fieldmsg(out_node, "TEST_FLOAT", MP_MFLT, &MTSTDEVMBR.TEST_FLOAT);
//            TRSN.add_fieldmsg(out_node, "TEST_DOUBLE", MP_MDBL, &MTSTDEVMBR.TEST_DOUBLE);
//            TRSN.add_fieldmsg(out_node, "TEST_LONG", MP_MLNG, &MTSTDEVMBR.TEST_LONG);
//            TRSN.add_fieldmsg(out_node, "TEST_CHAR", MP_MCHR, &MTSTDEVMBR.TEST_CHAR);
//            TRSN.add_fieldmsg(out_node, "TEST_STRING", MP_MSTR, &MTSTDEVMBR.TEST_STRING);
//            TRSN.add_fieldmsg(out_node, "TEST_BOOL", MP_MBOOL, &MTSTDEVMBR.TEST_BOOL);
//            TRSN.add_fieldmsg(out_node, "TEST_BINARY", MP_MBIN, &MTSTDEVMBR.TEST_BINARY);
//            TRSN.add_fieldmsg(out_node, "TEST_DATETIME", MP_MDATE, &MTSTDEVMBR.TEST_DATETIME);
//            TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//            return MP_FALSE;
//       }
//    }
//    else if(TRSN.get_procstep(in_node) == MP_STEP_DELETE)
//    {
//        TSDB_delete_mtstdevmbr(1, &MTSTDEVMBR);
//        if(DB_error_code != DB_SUCCESS) 
//        {
//            strcpy(s_msg_code, "BAS-0004");
//
//            TRSN.add_fieldmsg(out_node, "MTSTDEVMBR DELETE", MP_NVST);            
//            TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);
//            TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_SETUP;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//            return MP_FALSE;
//        }
//    }
//    else if(TRSN.get_procstep(in_node) == '1')
//    {
//        TRS.copy(MTSTDEVMBR.TEST_ID, sizeof(MTSTDEVMBR.TEST_ID), in_node, "NEXT_TEST_ID");
//
//        TSDB_open_mtstdevmbr(1, &MTSTDEVMBR);
//        if(DB_error_code != DB_SUCCESS) 
//        {
//            strcpy(s_msg_code, "BAS-0004");
//
//            TRSN.add_fieldmsg(in_node, "MTSTDEVMBR OPEN", MP_NVST);            
//            TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);            
//            TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            gs_log_type.category = MP_LOG_CATE_VIEW;
//
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//            return MP_FALSE;
//        }
//
//        while(1) 
//        {
//            TSDB_fetch_mtstdevmbr(1, &MTSTDEVMBR);
//
//            if(DB_error_code == DB_NOT_FOUND) 
//            {
//                TSDB_close_mtstdevmbr(1);
//                break;
//            }
//            else if(DB_error_code != DB_SUCCESS) 
//            {
//                strcpy(s_msg_code, "BAS-0004");
//
//                TRSN.add_fieldmsg(out_node, "MTSTDEVMBR FETCH", MP_NVST);
//                TRSN.add_fieldmsg(out_node, "TEST_ID", MP_STR, sizeof(MTSTDEVMBR.TEST_ID), MTSTDEVMBR.TEST_ID);               
//                TRSN.add_dberrmsg(out_node, DB_error_msg);
//
//                gs_log_type.type = MP_LOG_ERROR;
//                gs_log_type.e_type = MP_LOG_E_SYSTEM;
//                gs_log_type.category = MP_LOG_CATE_VIEW;
//
//                TSDB_close_mtstdevmbr(1);
//                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRSN.get_language(in_node));
//                return MP_FALSE;
//            }
//            if(COM_check_node_length(out_node) == MP_FALSE)
//            {
//                TRS.add_string(out_node, "NEXT_TEST_ID", MTSTDEVMBR.TEST_ID, sizeof(MTSTDEVMBR.TEST_ID));
//                TSDB_close_mtstdevmbr(1);
//                break;
//            }
//
//            itm = TRSN.add_node(out_node, "TEST_LIST");
//            
//            TRS.add_string(itm, "TEST_ID", MTSTDEVMBR.TEST_ID, sizeof(MTSTDEVMBR.TEST_ID));
//
//            TRSN.add_int(itm, "TEST_INT", MTSTDEVMBR.TEST_INT);
//            TRSN.add_float(itm, "TEST_FLOAT", MTSTDEVMBR.TEST_FLOAT);
//            TRSN.add_double(itm, "TEST_DOUBLE", MTSTDEVMBR.TEST_DOUBLE);
//            TRSN.add_long(itm, "TEST_LONG", MTSTDEVMBR.TEST_LONG);
//            TRSN.add_char(itm, "TEST_CHAR", MTSTDEVMBR.TEST_CHAR);
//            TRSN.add_string(itm, "TEST_STRING", MTSTDEVMBR.TEST_STRING);
//            TRSN.add_boolean(itm, "TEST_BOOL", MTSTDEVMBR.TEST_BOOL);
//            TRSN.add_binary(itm, "TEST_BINARY", MTSTDEVMBR.TEST_BINARY);
//
//            date = MTSTDEVMBR.TEST_DATETIME;
//            DEV_encode_datetime(date.VALUE, MTSTDEVMBR.TEST_DATETIME.VALUE, sizeof(MTSTDEVMBR.TEST_DATETIME.VALUE));
//            TRSN.add_datetime(itm, "TEST_DATETIME", date);
//        }
//    }
//
//   COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRSN.get_language(in_node));
//   return MP_TRUE;
//}
//
//void DEV_decode_datetime(char *dest, char *src, int i_size)
//{
//    int i_len;
//    int i;
//
//    i_len = COM_string_length(src, i_size);
//    if(i_len < 1)
//        return ;
//
//    i = 0;
//    sprintf(dest + i, "%.*s", 4, src     ); i += 4; // Year
//    sprintf(dest + i, "%.*s", 2, src + 5 ); i += 2; // Month
//    sprintf(dest + i, "%.*s", 2, src + 8 ); i += 2; // Day
//    sprintf(dest + i, "%.*s", 2, src + 11); i += 2; // Hour
//    sprintf(dest + i, "%.*s", 2, src + 14); i += 2; // Minute
//    sprintf(dest + i, "%.*s", 2, src + 17); i += 2; // Second
//}
//
//void DEV_encode_datetime(char *dest, char *src, int i_size)
//{
//    int i_len;
//    int i;
//
//    i_len = COM_string_length(src, i_size);
//    if(i_len < 14)
//        return ;
//
//    i = 0;
//    sprintf(dest + i, "%.*s-", 4, src     ); i += 5; // Year
//    sprintf(dest + i, "%.*s-", 2, src + 4 ); i += 3; // Month
//    sprintf(dest + i, "%.*sT", 2, src + 6 ); i += 3; // Day
//    sprintf(dest + i, "%.*s:", 2, src + 8 ); i += 3; // Hour
//    sprintf(dest + i, "%.*s:", 2, src + 10); i += 3; // Minute
//    sprintf(dest + i, "%.*sZ", 2, src + 12); i += 3; // Second
//}
//
