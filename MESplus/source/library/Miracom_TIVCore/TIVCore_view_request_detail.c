/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_request_detail.c
    Description : View Inventory Request Detail Information related function module

    MES Version : 5.2.0.0

    Function List
        - INV_View_Request_Detail()
            + View Inventory Request Detail Information
        - INV_VIEW_REQUEST_DETAIL()
            + Main Sub function of "INV_View_Request_Detail"
            + (called by "INV_View_Request_Detail")
        - INV_View_Request_Detail_Validation()
            + Validation Check sub function of "INV_VIEW_REQUEST_DETAIL" function
            + (called by "INV_VIEW_REQUEST_DETAIL")

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

int INV_View_Request_Detail_Validation(char *s_msg_code,
                                            TRSNode *in_node, 
                                            TRSNode *out_node);


/*******************************************************************************
    INV_View_Request_Detail()
        - View Inventory Request Detail Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int INV_View_Request_Detail(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = INV_VIEW_REQUEST_DETAIL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "INV_VIEW_REQUEST_DETAIL", out_node);

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
    INV_VIEW_REQUEST_DETAIL()
        - Main sub function of "INV_View_Request_Detail" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int INV_VIEW_REQUEST_DETAIL(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVREQDTL_TAG MTIVREQDTL;

    LOG_head("INV_View_Request_Detail");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("req_no", MP_NSTR, TRS.get_string(in_node, "REQ_NO"));
    LOG_add("req_seq", MP_INT, TRS.get_int(in_node, "REQ_SEQ"));

    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("INV", "INV_View_Request_Detail",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(INV_View_Request_Detail_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivreqdtl(&MTIVREQDTL);
    TRS.copy(MTIVREQDTL.FACTORY , sizeof(MTIVREQDTL.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVREQDTL.REQ_NO, sizeof(MTIVREQDTL.REQ_NO), in_node, "REQ_NO");
    MTIVREQDTL.REQ_SEQ = TRS.get_int(in_node, "REQ_SEQ");
    
    DBC_select_mtivreqdtl(1, &MTIVREQDTL);

    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0002");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }

        TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVREQDTL.FACTORY), MTIVREQDTL.FACTORY);
        TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(MTIVREQDTL.REQ_NO), MTIVREQDTL.REQ_NO);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_enc_string(out_node, "CREATE_USER_ID", MTIVREQDTL.CREATE_USER_ID, sizeof(MTIVREQDTL.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MTIVREQDTL.CREATE_TIME, sizeof(MTIVREQDTL.CREATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MTIVREQDTL.UPDATE_USER_ID, sizeof(MTIVREQDTL.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MTIVREQDTL.UPDATE_TIME, sizeof(MTIVREQDTL.UPDATE_TIME));
    TRS.add_string(out_node, "FACTORY", MTIVREQDTL.FACTORY, sizeof(MTIVREQDTL.FACTORY));
    TRS.add_string(out_node, "REQ_NO", MTIVREQDTL.REQ_NO, sizeof(MTIVREQDTL.REQ_NO));
    TRS.add_string(out_node, "MAT_ID", MTIVREQDTL.MAT_ID, sizeof(MTIVREQDTL.MAT_ID));
    TRS.add_int(out_node, "REQ_SEQ", MTIVREQDTL.REQ_SEQ);
    TRS.add_double(out_node, "REQ_QTY", MTIVREQDTL.REQ_QTY);
    TRS.add_double(out_node, "REMAIN_QTY", MTIVREQDTL.REMAIN_QTY);
    TRS.add_string(out_node, "UNIT", MTIVREQDTL.UNIT, sizeof(MTIVREQDTL.UNIT));
    TRS.add_string(out_node, "ORDER_ID", MTIVREQDTL.ORDER_ID, sizeof(MTIVREQDTL.ORDER_ID));
    TRS.add_double(out_node, "PLAN_QTY", MTIVREQDTL.PLAN_QTY);
    TRS.add_string(out_node, "FROM_OPER", MTIVREQDTL.FROM_OPER, sizeof(MTIVREQDTL.FROM_OPER));
    TRS.add_string(out_node, "TO_OPER", MTIVREQDTL.TO_OPER, sizeof(MTIVREQDTL.TO_OPER));
    TRS.add_char(out_node, "STATUS_FLAG", MTIVREQDTL.STATUS_FLAG);
    TRS.add_string(out_node, "REQ_CMF_1", MTIVREQDTL.REQ_CMF_1, sizeof(MTIVREQDTL.REQ_CMF_1));
    TRS.add_string(out_node, "REQ_CMF_2", MTIVREQDTL.REQ_CMF_2, sizeof(MTIVREQDTL.REQ_CMF_2));
    TRS.add_string(out_node, "REQ_CMF_3", MTIVREQDTL.REQ_CMF_3, sizeof(MTIVREQDTL.REQ_CMF_3));
    TRS.add_string(out_node, "REQ_CMF_4", MTIVREQDTL.REQ_CMF_4, sizeof(MTIVREQDTL.REQ_CMF_4));
    TRS.add_string(out_node, "REQ_CMF_5", MTIVREQDTL.REQ_CMF_5, sizeof(MTIVREQDTL.REQ_CMF_5));
    TRS.add_string(out_node, "REQ_CMF_6", MTIVREQDTL.REQ_CMF_6, sizeof(MTIVREQDTL.REQ_CMF_6));
    TRS.add_string(out_node, "REQ_CMF_7", MTIVREQDTL.REQ_CMF_7, sizeof(MTIVREQDTL.REQ_CMF_7));
    TRS.add_string(out_node, "REQ_CMF_8", MTIVREQDTL.REQ_CMF_8, sizeof(MTIVREQDTL.REQ_CMF_8));
    TRS.add_string(out_node, "REQ_CMF_9", MTIVREQDTL.REQ_CMF_9, sizeof(MTIVREQDTL.REQ_CMF_9));
    TRS.add_string(out_node, "REQ_CMF_10", MTIVREQDTL.REQ_CMF_10, sizeof(MTIVREQDTL.REQ_CMF_10));
    TRS.add_string(out_node, "DELETE_TIME", MTIVREQDTL.DELETE_TIME, sizeof(MTIVREQDTL.DELETE_TIME));
    TRS.add_enc_string(out_node, "DELETE_USER_ID", MTIVREQDTL.DELETE_USER_ID, sizeof(MTIVREQDTL.DELETE_USER_ID));

    if(COM_proc_user_routine("INV", "INV_View_Request_Detail",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    INV_View_Request_Detail_Validation()
        - Validation Check sub function of "INV_VIEW_REQUEST_DETAIL" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int INV_View_Request_Detail_Validation(char *s_msg_code,
                                            TRSNode *in_node, 
                                            TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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
    /* Request No Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "REQ_NO")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "REQ_NO", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }
    /* Request Seq Validation */
    if(TRS.get_int(in_node, "REQ_SEQ") < 1)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "REQ_SEQ", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
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