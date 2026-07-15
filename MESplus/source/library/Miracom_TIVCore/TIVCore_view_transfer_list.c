/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_transfer_list.c
    Description : View Inventory Transfer List related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Transfer_List()
            + View Inventory Transfer List
        - TIV_VIEW_TRANSFER_LIST()
            + Main Sub function of "TIV_View_Transfer_List"
            + (called by "TIV_View_Transfer_List")
        - TIV_View_Transfer_List_Validation()
            + Validation Check sub function of "TIV_VIEW_TRANSFER_LIST" function
            + (called by "TIV_VIEW_TRANSFER_LIST")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/30  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Transfer_List_Validation(char *s_msg_code,
                                            TRSNode *in_node, 
                                            TRSNode *out_node);


/*******************************************************************************
    TIV_View_Transfer_List()
        - View Inventory Transfer List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Transfer_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_TRANSFER_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_TRANSFER_LIST", out_node);

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
    TIV_VIEW_TRANSFER_LIST()
        - Main sub function of "TIV_View_Transfer_List" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_TRANSFER_LIST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVTRSMST_TAG MTIVTRSMST;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    //struct MATRNAMSTS_TAG MATRNAMSTS;
    TRSNode *list_item;
    //TRSNode *list_item2;

    int istep=0;

    LOG_head("TIV_View_Transfer_List");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(TIV_View_Transfer_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	

    DBC_init_mtivtrsmst(&MTIVTRSMST);
    TRS.copy(MTIVTRSMST.FACTORY , sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
	TRS.copy(MTIVTRSMST.TRS_CMF_3, sizeof(MTIVTRSMST.TRS_CMF_3), in_node, "TRS_CMF_3");
	TRS.copy(MTIVTRSMST.TRS_CMF_4, sizeof(MTIVTRSMST.TRS_CMF_4), in_node, "TRS_CMF_4");
	MTIVTRSMST.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");
	MTIVTRSMST.RT_FLAG = TRS.get_char(in_node, "RT_FLAG");
    MTIVTRSMST.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");

    DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE), in_node, "FROM_DATE");    
	TRS.copy(DBC_Q_COND.TO_DATE, sizeof(DBC_Q_COND.TO_DATE), in_node, "TO_DATE");
	if(COM_isnullspace(DBC_Q_COND.TO_DATE) == MP_TRUE) memcpy(DBC_Q_COND.TO_DATE, DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE));
	TRS.copy(DBC_Q_COND.FROM_TIME, sizeof(DBC_Q_COND.FROM_TIME), in_node, "FROM_TIME");    
	TRS.copy(DBC_Q_COND.TO_TIME, sizeof(DBC_Q_COND.TO_TIME), in_node, "TO_TIME");    
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

    if(TRS.get_procstep(in_node)=='1')
        istep = 2;
    else if(TRS.get_procstep(in_node)=='2')
        istep = 4;

	DBC_open_mtivtrsmst(istep, &MTIVTRSMST);
	if(DB_error_code != DB_SUCCESS)
	{
	    strcpy(s_msg_code, "INV-0004");
	    TRS.add_fieldmsg(out_node, "MTIVTRSMST OPEN", MP_NVST);
	    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
	    TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
	    TRS.add_dberrmsg(out_node, DB_error_msg);

	    gs_log_type.type = MP_LOG_ERROR;
	    gs_log_type.e_type = MP_LOG_E_SYSTEM;
	    gs_log_type.category = MP_LOG_CATE_VIEW;
	    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	    return MP_FALSE;
	}

	while(1)
	{
	    DBC_fetch_mtivtrsmst(istep, &MTIVTRSMST);
	    if(DB_error_code == DB_NOT_FOUND)
	    {
	        DBC_close_mtivtrsmst(istep);
	        break;
	    }
	    else if(DB_error_code != DB_SUCCESS) 
	    {
	        strcpy(s_msg_code, "INV-0004");
	        TRS.add_fieldmsg(out_node, "MTIVTRSMST FETCH", MP_NVST);
	        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
	        TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
	        TRS.add_dberrmsg(out_node, DB_error_msg);

	        gs_log_type.type = MP_LOG_ERROR;
	        gs_log_type.e_type = MP_LOG_E_SYSTEM;
	        gs_log_type.category = MP_LOG_CATE_VIEW;
	        DBC_close_mtivtrsmst(istep);
	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	        return MP_FALSE;
	    }
	    if(COM_check_node_length(out_node) == MP_FALSE)
	    {
	        TRS.add_string(out_node, "NEXT_TRS_NO", MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO));
	        DBC_close_mtivtrsmst(istep);
	        break;
	    }
	    
	    list_item = TRS.add_node(out_node, "LIST");

	    TRS.add_enc_string(list_item, "CREATE_USER_ID", MTIVTRSMST.CREATE_USER_ID, sizeof(MTIVTRSMST.CREATE_USER_ID));
	    TRS.add_string(list_item, "CREATE_TIME", MTIVTRSMST.CREATE_TIME, sizeof(MTIVTRSMST.CREATE_TIME));
	    TRS.add_enc_string(list_item, "UPDATE_USER_ID", MTIVTRSMST.UPDATE_USER_ID, sizeof(MTIVTRSMST.UPDATE_USER_ID));
	    TRS.add_string(list_item, "UPDATE_TIME", MTIVTRSMST.UPDATE_TIME, sizeof(MTIVTRSMST.UPDATE_TIME));
	    TRS.add_string(list_item, "FACTORY", MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY));
	    TRS.add_string(list_item, "TRS_NO", MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO));
	    TRS.add_string(list_item, "TRS_USER", MTIVTRSMST.TRS_USER, sizeof(MTIVTRSMST.TRS_USER));
	    TRS.add_string(list_item, "INV_USER", MTIVTRSMST.INV_USER, sizeof(MTIVTRSMST.INV_USER));
	    TRS.add_string(list_item, "TRS_DATE_TIME", MTIVTRSMST.TRS_DATE_TIME, sizeof(MTIVTRSMST.TRS_DATE_TIME));
	    TRS.add_char(list_item, "TRS_PRIORITY", MTIVTRSMST.TRS_PRIORITY);
	    TRS.add_char(list_item, "STATUS_FLAG", MTIVTRSMST.STATUS_FLAG);
		TRS.add_char(list_item, "DOC_TYPE", MTIVTRSMST.DOC_TYPE);
		TRS.add_char(list_item, "INV_FLAG", MTIVTRSMST.INV_FLAG);
	    TRS.add_string(list_item, "TRS_COMMENT", MTIVTRSMST.TRS_COMMENT, sizeof(MTIVTRSMST.TRS_COMMENT));
	    TRS.add_string(list_item, "TRS_CMF_1", MTIVTRSMST.TRS_CMF_1, sizeof(MTIVTRSMST.TRS_CMF_1));
	    TRS.add_string(list_item, "TRS_CMF_2", MTIVTRSMST.TRS_CMF_2, sizeof(MTIVTRSMST.TRS_CMF_2));
	    TRS.add_string(list_item, "TRS_CMF_3", MTIVTRSMST.TRS_CMF_3, sizeof(MTIVTRSMST.TRS_CMF_3));
	    TRS.add_string(list_item, "TRS_CMF_4", MTIVTRSMST.TRS_CMF_4, sizeof(MTIVTRSMST.TRS_CMF_4));
	    TRS.add_string(list_item, "TRS_CMF_5", MTIVTRSMST.TRS_CMF_5, sizeof(MTIVTRSMST.TRS_CMF_5));
	    TRS.add_string(list_item, "TRS_CMF_6", MTIVTRSMST.TRS_CMF_6, sizeof(MTIVTRSMST.TRS_CMF_6));
	    TRS.add_string(list_item, "TRS_CMF_7", MTIVTRSMST.TRS_CMF_7, sizeof(MTIVTRSMST.TRS_CMF_7));
	    TRS.add_string(list_item, "TRS_CMF_8", MTIVTRSMST.TRS_CMF_8, sizeof(MTIVTRSMST.TRS_CMF_8));
	    TRS.add_string(list_item, "TRS_CMF_9", MTIVTRSMST.TRS_CMF_9, sizeof(MTIVTRSMST.TRS_CMF_9));
	    TRS.add_string(list_item, "TRS_CMF_10", MTIVTRSMST.TRS_CMF_10, sizeof(MTIVTRSMST.TRS_CMF_10));
	    TRS.add_string(list_item, "DELETE_TIME", MTIVTRSMST.DELETE_TIME, sizeof(MTIVTRSMST.DELETE_TIME));
	    TRS.add_enc_string(list_item, "DELETE_USER_ID", MTIVTRSMST.DELETE_USER_ID, sizeof(MTIVTRSMST.DELETE_USER_ID));		
		TRS.add_char(list_item, "OSP_FLAG", MTIVTRSMST.OSP_FLAG);
		TRS.add_char(list_item, "RT_FLAG", MTIVTRSMST.RT_FLAG);
		TRS.add_enc_string(list_item, "RT_REASON", MTIVTRSMST.RT_REASON, sizeof(MTIVTRSMST.RT_REASON));

        DBC_init_mtivtrsdtl(&MTIVTRSDTL);
        TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
        memcpy(MTIVTRSDTL.TRS_NO, MTIVTRSMST.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO));
        TRS.copy(MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER), in_node, "TO_OPER");
        if((int)DBC_select_mtivtrsdtl_scalar(6, &MTIVTRSDTL)>0)
            TRS.add_char(list_item, "TO_OPER_EXIST", 'Y');

        DBC_init_mtivtrsdtl(&MTIVTRSDTL);
        TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
        memcpy(MTIVTRSDTL.TRS_NO, MTIVTRSMST.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO));
        TRS.copy(MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER), in_node, "FROM_OPER");
        if((int)DBC_select_mtivtrsdtl_scalar(7, &MTIVTRSDTL)>0)
            TRS.add_char(list_item, "FROM_OPER_EXIST", 'Y');
	
        //GET FROM_OPER exist
        DBC_init_mtivtrsdtl(&MTIVTRSDTL);
        memcpy(MTIVTRSDTL.FACTORY, MTIVTRSMST.FACTORY, sizeof(MTIVTRSDTL.FACTORY));
        TRS.copy(MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER), in_node, "FROM_OPER");
        memcpy(MTIVTRSDTL.TRS_NO, MTIVTRSMST.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO));
        if((int)DBC_select_mtivtrsdtl_scalar(7, &MTIVTRSDTL)>=1)
        {
            TRS.add_char(list_item, "EXIST_FROM_OPER", 'Y');
        }
        /*if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0004");
	        TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT SCALAR", MP_NVST);
	        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
	        TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
            TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR, sizeof(MTIVTRSDTL.FROM_OPER), MTIVTRSDTL.FROM_OPER);
	        TRS.add_dberrmsg(out_node, DB_error_msg);

	        gs_log_type.type = MP_LOG_ERROR;
	        gs_log_type.e_type = MP_LOG_E_SYSTEM;
	        gs_log_type.category = MP_LOG_CATE_VIEW;
	        DBC_close_mtivtrsmst(istep);
	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	        return MP_FALSE;
        }*/

    }
	


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Transfer_List_Validation()
        - Validation Check sub function of "TIV_VIEW_TRANSFER_LIST" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Transfer_List_Validation(char *s_msg_code,
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