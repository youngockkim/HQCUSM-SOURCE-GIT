/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_oper_list.c
    Description : View Inventory Oper List related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Oper_List()
            + View Inventory Oper List
        - TIV_VIEW_OPER_LIST()
            + Main Sub function of "TIV_View_Oper_List"
            + (called by "TIV_View_Oper_List")
        - TIV_View_Oper_List_Validation()
            + Validation Check sub function of "TIV_VIEW_OPER_LIST" function
            + (called by "TIV_VIEW_OPER_LIST")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/29  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Operation_List_Validation(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);


/*******************************************************************************
    TIV_View_Oper_List()
        - View Inventory Oper List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Operation_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_OPERATION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_OPERATION_LIST", out_node);

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
    TIV_VIEW_OPER_LIST()
        - Main sub function of "TIV_View_Oper_List" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_OPERATION_LIST(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node)
{
    struct MWIPOPRDEF_TAG MWIPOPRDEF;
    struct MATRNAMSTS_TAG MATRNAMSTS;

    int i_step = 0;
    TRSNode *list_item;

    LOG_head("TIV_VIEW_OPERATION_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    LOG_add("flow", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    LOG_add("next_oper", MP_NSTR, TRS.get_string(in_node, "NEXT_OPER"));
    LOG_add("filter", MP_NSTR, TRS.get_string(in_node, "FILTER"));
    LOG_add("sec_chk_flag", MP_CHR, TRS.get_char(in_node, "SEC_CHK_FLAG"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Operation_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* Validation Check */
    if(TIV_View_Operation_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwipoprdef(&MWIPOPRDEF);
    
    if(TRS.get_char(in_node, "SEC_CHK_FLAG") == 'Y')
    {
        i_step = 7;
    }
    else
    {
        i_step = 1;
    }
    
    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "NEXT_OPER");
    TRS.copy(MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC), in_node, "FILTER");
    MWIPOPRDEF.SEC_CHK_FLAG = TRS.get_char(in_node, "SEC_CHK_FLAG"); 

    DBC_open_mwipoprdef(i_step, &MWIPOPRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPOPRDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    while(1)
    {
        DBC_fetch_mwipoprdef(i_step, &MWIPOPRDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipoprdef(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPOPRDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mwipoprdef(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_string(out_node, "NEXT_OPER", MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER));
            DBC_close_mwipoprdef(i_step);
            break;
        }

        DBC_init_matrnamsts(&MATRNAMSTS);
        TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
        memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_OPER, strlen(MP_ATTR_TYPE_OPER));
        memcpy(MATRNAMSTS.ATTR_NAME, "RawMaterialOper", strlen("RawMaterialOper"));
        memcpy(MATRNAMSTS.ATTR_KEY, MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER));
        DBC_select_matrnamsts(1, &MATRNAMSTS);
        if(TRS.get_procstep(in_node)=='1')
        {
            if(MATRNAMSTS.ATTR_VALUE[0]=='Y')
                continue;
        }
        else if(TRS.get_procstep(in_node)=='2')
        {
            if(MATRNAMSTS.ATTR_VALUE[0]!='Y')
                continue;
        }
        else
        {
            if(MATRNAMSTS.ATTR_VALUE[0]=='Y')
                continue;
        }
        list_item = TRS.add_node(out_node, "LIST");

        TRS.add_string(list_item, "OPER", MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER));
        TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
	    TRS.add_string(list_item, "OPER_SHORT_DESC", MWIPOPRDEF.OPER_SHORT_DESC, sizeof(MWIPOPRDEF.OPER_SHORT_DESC));
    }


    if(COM_proc_user_routine("WIP", "TIV_View_Operation_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Oper_List_Validation()
        - Validation Check sub function of "TIV_VIEW_OPER_LIST" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Operation_List_Validation(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);

    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0005");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}