/******************************************************************************'

    System      : MESplus
    Module      : CBAS
    File Name   : CBAS_view_large_data_list.c
    Description : View All Large General Code Data Customized Version

    MES Version : 5.3.4 ~

    Function List

    Detail Description

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include "BASCore_common.h"

int CBAS_View_Large_Data_List_Validation(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node);

/*******************************************************************************
    CBAS_View_Large_Data_List()
        - View All Large General Code Data List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_Large_Data_List(TRSNode *in_node,
                       TRSNode *out_node) 
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CBAS_VIEW_LARGE_DATA_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CBAS_VIEW_LARGE_DATA_LIST", out_node);

    if(i_ret == MP_TRUE) 
    {
        DB_commit();
    }
    else 
    {
        DB_rollback();
    }

    return MP_TRUE;
}


/*******************************************************************************
    CBAS_VIEW_LARGE_DATA_LIST()
        - Main sub function of "CBAS_View_Large_Data_List" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_VIEW_LARGE_DATA_LIST(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{
    struct MGCMTBLDEF_TAG MGCMTBLDEF;
    struct MGCMLAGDAT_TAG MGCMLAGDAT;

    TRSNode *data_item;
	int i_step = 0;

    LOG_head("CBAS_View_Large_Data_List");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("table_name", MP_NSTR, TRS.get_string(in_node, "TABLE_NAME"));
    LOG_add("key_1", MP_NSTR,  TRS.get_string(in_node, "KEY_1"));
    LOG_add("key_2", MP_NSTR,  TRS.get_string(in_node, "KEY_2"));
    LOG_add("key_3", MP_NSTR,  TRS.get_string(in_node, "KEY_3"));
    LOG_add("key_4", MP_NSTR,  TRS.get_string(in_node, "KEY_4"));
    LOG_add("key_5", MP_NSTR,  TRS.get_string(in_node, "KEY_5"));
    LOG_add("key_6", MP_NSTR,  TRS.get_string(in_node, "KEY_6"));
    LOG_add("key_7", MP_NSTR,  TRS.get_string(in_node, "KEY_7"));
    LOG_add("key_8", MP_NSTR,  TRS.get_string(in_node, "KEY_8"));
    LOG_add("key_9", MP_NSTR,  TRS.get_string(in_node, "KEY_9"));
    LOG_add("key_10", MP_NSTR, TRS.get_string(in_node, "KEY_10"));
    LOG_add("next_key_1", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_1"));
    LOG_add("next_key_2", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_2"));
    LOG_add("next_key_3", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_3"));
    LOG_add("next_key_4", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_4"));
    LOG_add("next_key_5", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_5"));
    LOG_add("next_key_6", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_6"));
    LOG_add("next_key_7", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_7"));
    LOG_add("next_key_8", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_8"));
    LOG_add("next_key_9", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_9"));
    LOG_add("next_key_10", MP_NSTR, TRS.get_string(in_node, "NEXT_KEY_10"));
    LOG_add("next_row", MP_INT, TRS.get_int(in_node, "NEXT_ROW"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(CBAS_View_Large_Data_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mgcmtbldef(&MGCMTBLDEF);
    TRS.copy(MGCMTBLDEF.FACTORY, sizeof(MGCMTBLDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MGCMTBLDEF.TABLE_NAME, sizeof(MGCMTBLDEF.TABLE_NAME), in_node, "TABLE_NAME");
    DBC_select_mgcmtbldef(1, &MGCMTBLDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "GCM-0002");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "GCM-0007");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }

        TRS.add_fieldmsg(out_node, "MGCMTBLDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(MGCMTBLDEF.TABLE_TYPE == 'L') /* Large Table */
    {
        DBC_init_mgcmlagdat(&MGCMLAGDAT);
        TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MGCMLAGDAT.TABLE_NAME, sizeof(MGCMLAGDAT.TABLE_NAME), in_node, "TABLE_NAME");

        MGCMLAGDAT.KEY_1[0] = '%';
        MGCMLAGDAT.KEY_2[0] = '%';
        MGCMLAGDAT.KEY_3[0] = '%';
        MGCMLAGDAT.KEY_4[0] = '%';
        MGCMLAGDAT.KEY_5[0] = '%';
        MGCMLAGDAT.KEY_6[0] = '%';
        MGCMLAGDAT.KEY_7[0] = '%';
        MGCMLAGDAT.KEY_8[0] = '%';
        MGCMLAGDAT.KEY_9[0] = '%';
        MGCMLAGDAT.KEY_10[0] = '%';

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_1")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_1");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_2")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_2");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_3")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_3");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_4")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_4");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_5")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_5");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_6")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_6");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_7")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_7");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_8")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_8");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_9")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_9");
        }

        if(COM_isnullspace(TRS.get_string(in_node, "KEY_10")) == MP_FALSE)
        {
            TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_10");
        }

        if (TRS.get_procstep(in_node) == '1')
        {
            i_step = 104;
            MGCMLAGDAT.DATA_2[0] = 'Y';
        }
        else if (TRS.get_procstep(in_node) == '2')
        {
            i_step = 105;
            MGCMLAGDAT.DATA_2[0] = 'Y';
        }
		else if (TRS.get_procstep(in_node) == '3')
        {
            i_step = 106;
        }
        else
        {
            i_step = 0;
        }

        DBC_open_mgcmlagdat(i_step, &MGCMLAGDAT);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "GCM-0007");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        while(1)
        {
            DBC_fetch_mgcmlagdat(i_step, &MGCMLAGDAT);

            if(DB_error_code == DB_NOT_FOUND) 
            {
                DBC_close_mgcmlagdat(i_step);
                break;
            }
            else if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "GCM-0007");
                TRS.add_fieldmsg(out_node, "MGCMLAGDAT FETCH", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

                DBC_close_mgcmlagdat(i_step);
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            data_item = TRS.add_node(out_node, "DATA_LIST");

            TRS.add_string(data_item, "KEY_1", MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1));
            TRS.add_string(data_item, "KEY_2", MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2));
            TRS.add_string(data_item, "KEY_3", MGCMLAGDAT.KEY_3, sizeof(MGCMLAGDAT.KEY_3));
            TRS.add_string(data_item, "KEY_4", MGCMLAGDAT.KEY_4, sizeof(MGCMLAGDAT.KEY_4));
            TRS.add_string(data_item, "KEY_5", MGCMLAGDAT.KEY_5, sizeof(MGCMLAGDAT.KEY_5));
            TRS.add_string(data_item, "KEY_6", MGCMLAGDAT.KEY_6, sizeof(MGCMLAGDAT.KEY_6));
            TRS.add_string(data_item, "KEY_7", MGCMLAGDAT.KEY_7, sizeof(MGCMLAGDAT.KEY_7));
            TRS.add_string(data_item, "KEY_8", MGCMLAGDAT.KEY_8, sizeof(MGCMLAGDAT.KEY_8));
            TRS.add_string(data_item, "KEY_9", MGCMLAGDAT.KEY_9, sizeof(MGCMLAGDAT.KEY_9));
            TRS.add_string(data_item, "KEY_10", MGCMLAGDAT.KEY_10, sizeof(MGCMLAGDAT.KEY_10));
            TRS.add_string(data_item, "DATA_1", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
            TRS.add_string(data_item, "DATA_2", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
            TRS.add_string(data_item, "DATA_3", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));
            TRS.add_string(data_item, "DATA_4", MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));
            TRS.add_string(data_item, "DATA_5", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));
            TRS.add_string(data_item, "DATA_6", MGCMLAGDAT.DATA_6, sizeof(MGCMLAGDAT.DATA_6));
            TRS.add_string(data_item, "DATA_7", MGCMLAGDAT.DATA_7, sizeof(MGCMLAGDAT.DATA_7));
            TRS.add_string(data_item, "DATA_8", MGCMLAGDAT.DATA_8, sizeof(MGCMLAGDAT.DATA_8));
            TRS.add_string(data_item, "DATA_9", MGCMLAGDAT.DATA_9, sizeof(MGCMLAGDAT.DATA_9));
            TRS.add_string(data_item, "DATA_10", MGCMLAGDAT.DATA_10, sizeof(MGCMLAGDAT.DATA_10));
            TRS.add_enc_string(data_item, "CREATE_USER_ID", MGCMLAGDAT.CREATE_USER_ID, sizeof(MGCMLAGDAT.CREATE_USER_ID));
            TRS.add_string(data_item, "CREATE_TIME", MGCMLAGDAT.CREATE_TIME, sizeof(MGCMLAGDAT.CREATE_TIME));
            TRS.add_enc_string(data_item, "UPDATE_USER_ID", MGCMLAGDAT.UPDATE_USER_ID, sizeof(MGCMLAGDAT.UPDATE_USER_ID));
            TRS.add_string(data_item, "UPDATE_TIME", MGCMLAGDAT.UPDATE_TIME, sizeof(MGCMLAGDAT.UPDATE_TIME));
        }
    }
    else /* General Table */
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CBAS_View_Large_Data_List_Validation()
        - Validation check sub function of "CBAS_VIEW_DATA_LIST" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_Large_Data_List_Validation(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node) {

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "GCM-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    /* Table Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "TABLE_NAME")) == MP_TRUE)
    {
        strcpy(s_msg_code, "GCM-0001");
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}
