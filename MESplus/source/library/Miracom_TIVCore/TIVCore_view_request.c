/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_request.c
    Description : View Inventory Request Information related function module

    MES Version : 5.2.0.0

    Function List
        - INV_View_Request()
            + View Inventory Lot Information
        - INV_VIEW_REQUEST()
            + Main Sub function of "INV_View_Request"
            + (called by "INV_View_Request")
        - INV_View_Request_Validation()
            + Validation Check sub function of "INV_VIEW_REQUEST" function
            + (called by "INV_VIEW_REQUEST")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/25  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int INV_View_Request_Validation(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);


/*******************************************************************************
    INV_View_Request()
        - View Inventory Request Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int INV_View_Request(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = INV_VIEW_REQUEST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "INV_VIEW_REQUEST", out_node);

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
    INV_VIEW_REQUEST()
        - Main sub function of "INV_View_Request" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int INV_VIEW_REQUEST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVREQMST_TAG MTIVREQMST;

    LOG_head("INV_View_Request");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("req_no", MP_NSTR, TRS.get_string(in_node, "REQ_NO"));

    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("INV", "INV_View_Request",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(INV_View_Request_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivreqmst(&MTIVREQMST);
    TRS.copy(MTIVREQMST.FACTORY , sizeof(MTIVREQMST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVREQMST.REQ_NO, sizeof(MTIVREQMST.REQ_NO), in_node, "REQ_NO");
    
    DBC_select_mtivreqmst(1, &MTIVREQMST);

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

        TRS.add_fieldmsg(out_node, "MTIVREQMST SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVREQMST.FACTORY), MTIVREQMST.FACTORY);
        TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(MTIVREQMST.REQ_NO), MTIVREQMST.REQ_NO);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_enc_string(out_node, "CREATE_USER_ID", MTIVREQMST.CREATE_USER_ID, sizeof(MTIVREQMST.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MTIVREQMST.CREATE_TIME, sizeof(MTIVREQMST.CREATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MTIVREQMST.UPDATE_USER_ID, sizeof(MTIVREQMST.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MTIVREQMST.UPDATE_TIME, sizeof(MTIVREQMST.UPDATE_TIME));
    TRS.add_string(out_node, "FACTORY", MTIVREQMST.FACTORY, sizeof(MTIVREQMST.FACTORY));
    TRS.add_string(out_node, "REQ_NO", MTIVREQMST.REQ_NO, sizeof(MTIVREQMST.REQ_NO));
    TRS.add_string(out_node, "REQ_USER", MTIVREQMST.REQ_USER, sizeof(MTIVREQMST.REQ_USER));
    TRS.add_string(out_node, "INV_USER", MTIVREQMST.INV_USER, sizeof(MTIVREQMST.INV_USER));
    TRS.add_string(out_node, "REQ_DATE_TIME", MTIVREQMST.REQ_DATE_TIME, sizeof(MTIVREQMST.REQ_DATE_TIME));
    TRS.add_char(out_node, "REQ_PRIORITY", MTIVREQMST.REQ_PRIORITY);
    TRS.add_char(out_node, "STATUS_FLAG", MTIVREQMST.STATUS_FLAG);
    TRS.add_string(out_node, "REQ_CMF_1", MTIVREQMST.REQ_CMF_1, sizeof(MTIVREQMST.REQ_CMF_1));
    TRS.add_string(out_node, "REQ_CMF_2", MTIVREQMST.REQ_CMF_2, sizeof(MTIVREQMST.REQ_CMF_2));
    TRS.add_string(out_node, "REQ_CMF_3", MTIVREQMST.REQ_CMF_3, sizeof(MTIVREQMST.REQ_CMF_3));
    TRS.add_string(out_node, "REQ_CMF_4", MTIVREQMST.REQ_CMF_4, sizeof(MTIVREQMST.REQ_CMF_4));
    TRS.add_string(out_node, "REQ_CMF_5", MTIVREQMST.REQ_CMF_5, sizeof(MTIVREQMST.REQ_CMF_5));
    TRS.add_string(out_node, "REQ_CMF_6", MTIVREQMST.REQ_CMF_6, sizeof(MTIVREQMST.REQ_CMF_6));
    TRS.add_string(out_node, "REQ_CMF_7", MTIVREQMST.REQ_CMF_7, sizeof(MTIVREQMST.REQ_CMF_7));
    TRS.add_string(out_node, "REQ_CMF_8", MTIVREQMST.REQ_CMF_8, sizeof(MTIVREQMST.REQ_CMF_8));
    TRS.add_string(out_node, "REQ_CMF_9", MTIVREQMST.REQ_CMF_9, sizeof(MTIVREQMST.REQ_CMF_9));
    TRS.add_string(out_node, "REQ_CMF_10", MTIVREQMST.REQ_CMF_10, sizeof(MTIVREQMST.REQ_CMF_10));
    TRS.add_string(out_node, "DELETE_TIME", MTIVREQMST.DELETE_TIME, sizeof(MTIVREQMST.DELETE_TIME));
    TRS.add_enc_string(out_node, "DELETE_USER_ID", MTIVREQMST.DELETE_USER_ID, sizeof(MTIVREQMST.DELETE_USER_ID));
    
    if(COM_proc_user_routine("INV", "INV_View_Request",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    INV_View_Request_Validation()
        - Validation Check sub function of "INV_VIEW_REQUEST" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int INV_View_Request_Validation(char *s_msg_code,
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