/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_transfer_detail.c
    Description : View Inventory Transfer Detail Information related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Transfer_Detail()
            + View Inventory Transfer Detail Information
        - TIV_VIEW_TRANSFER_DETAIL()
            + Main Sub function of "TIV_View_Transfer_Detail"
            + (called by "TIV_View_Transfer_Detail")
        - TIV_View_Transfer_Detail_Validation()
            + Validation Check sub function of "TIV_VIEW_TRANSFER_DETAIL" function
            + (called by "TIV_VIEW_TRANSFER_DETAIL")

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

int TIV_View_Transfer_Detail_Validation(char *s_msg_code,
                                            TRSNode *in_node, 
                                            TRSNode *out_node);


/*******************************************************************************
    TIV_View_Transfer_Detail()
        - View Inventory Transfer Detail Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Transfer_Detail(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_TRANSFER_DETAIL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_TRANSFER_DETAIL", out_node);

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
    TIV_VIEW_TRANSFER_DETAIL()
        - Main sub function of "TIV_View_Transfer_Detail" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_TRANSFER_DETAIL(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node)
{
    struct MWIPOPRDEF_TAG MWIPOPRDEF;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;

    LOG_head("TIV_View_Transfer_Detail");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer_Detail",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check */
    if(TIV_View_Transfer_Detail_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivtrsdtl(&MTIVTRSDTL);
    TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
    MTIVTRSDTL.TRS_SEQ = TRS.get_int(in_node, "TRS_SEQ");
    TRS.copy(MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID), in_node, "LOT_ID");
	TRS.copy(MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID), in_node, "MAT_ID");
    MTIVTRSDTL.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");
    if(TRS.get_procstep(in_node) == '1')        //by PK(FACTORY,TRS_NO,MAT_ID,LOT_ID
    {
        DBC_select_mtivtrsdtl(1, &MTIVTRSDTL);
    }
    else if(TRS.get_procstep(in_node) == '2')        //(FACTORY,TRS_NO,MAT_ID,DOC_TYPE
    {
        if(MTIVTRSDTL.DOC_TYPE == ' ')
        {
            MTIVTRSDTL.DOC_TYPE = '%';
        }
        DBC_select_mtivtrsdtl(2, &MTIVTRSDTL);
    }

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

        TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
        TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
		TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_enc_string(out_node, "CREATE_USER_ID", MTIVTRSDTL.CREATE_USER_ID, sizeof(MTIVTRSDTL.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MTIVTRSDTL.CREATE_TIME, sizeof(MTIVTRSDTL.CREATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MTIVTRSDTL.UPDATE_TIME, sizeof(MTIVTRSDTL.UPDATE_TIME));
    TRS.add_string(out_node, "FACTORY", MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY));
    TRS.add_string(out_node, "TRS_NO", MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO));
    TRS.add_int(out_node, "TRS_SEQ", MTIVTRSDTL.TRS_SEQ);
    TRS.add_string(out_node, "LOT_ID", MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID));
    TRS.add_string(out_node, "TRS_TYPE", MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE));
    TRS.add_string(out_node, "TRS_CODE", MTIVTRSDTL.TRS_CODE, sizeof(MTIVTRSDTL.TRS_CODE));
    TRS.add_char(out_node, "STATUS_FLAG", MTIVTRSDTL.STATUS_FLAG);    
    TRS.add_string(out_node, "TRS_CMF_1", MTIVTRSDTL.TRS_CMF_1, sizeof(MTIVTRSDTL.TRS_CMF_1));
    TRS.add_string(out_node, "TRS_CMF_2", MTIVTRSDTL.TRS_CMF_2, sizeof(MTIVTRSDTL.TRS_CMF_2));
    TRS.add_string(out_node, "TRS_CMF_3", MTIVTRSDTL.TRS_CMF_3, sizeof(MTIVTRSDTL.TRS_CMF_3));
    TRS.add_string(out_node, "TRS_CMF_4", MTIVTRSDTL.TRS_CMF_4, sizeof(MTIVTRSDTL.TRS_CMF_4));
    TRS.add_string(out_node, "TRS_CMF_5", MTIVTRSDTL.TRS_CMF_5, sizeof(MTIVTRSDTL.TRS_CMF_5));
    TRS.add_string(out_node, "TRS_CMF_6", MTIVTRSDTL.TRS_CMF_6, sizeof(MTIVTRSDTL.TRS_CMF_6));
    TRS.add_string(out_node, "TRS_CMF_7", MTIVTRSDTL.TRS_CMF_7, sizeof(MTIVTRSDTL.TRS_CMF_7));
    TRS.add_string(out_node, "TRS_CMF_8", MTIVTRSDTL.TRS_CMF_8, sizeof(MTIVTRSDTL.TRS_CMF_8));
    TRS.add_string(out_node, "TRS_CMF_9", MTIVTRSDTL.TRS_CMF_9, sizeof(MTIVTRSDTL.TRS_CMF_9));
    TRS.add_string(out_node, "TRS_CMF_10", MTIVTRSDTL.TRS_CMF_10, sizeof(MTIVTRSDTL.TRS_CMF_10));
    TRS.add_string(out_node, "DELETE_TIME", MTIVTRSDTL.DELETE_TIME, sizeof(MTIVTRSDTL.DELETE_TIME));
    TRS.add_enc_string(out_node, "DELETE_USER_ID", MTIVTRSDTL.DELETE_USER_ID, sizeof(MTIVTRSDTL.DELETE_USER_ID));
    TRS.add_double(out_node, "REQ_QTY", MTIVTRSDTL.REQ_QTY);
    TRS.add_string(out_node, "FROM_OPER", MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSDTL.FROM_OPER));
    TRS.add_string(out_node, "TO_OPER", MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER));
	TRS.add_char(out_node, "DOC_TYPE", MTIVTRSDTL.DOC_TYPE);
	TRS.add_string(out_node, "MAT_ID", MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID));
	TRS.add_double(out_node, "REMAIN_QTY", MTIVTRSDTL.REMAIN_QTY);
	TRS.add_string(out_node, "UNIT_1", MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSDTL.UNIT_1));
	TRS.add_string(out_node, "UNIT_2", MTIVTRSDTL.UNIT_2, sizeof(MTIVTRSDTL.UNIT_2));
	TRS.add_string(out_node, "UNIT_3", MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3));
	TRS.add_double(out_node, "QTY_1", MTIVTRSDTL.QTY_1);
	TRS.add_double(out_node, "QTY_2", MTIVTRSDTL.QTY_2);
	TRS.add_double(out_node, "QTY_3", MTIVTRSDTL.QTY_3);

	TRS.add_string(out_node, "FROM_LOCATION_NO", MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSDTL.FROM_LOCATION_NO));
    TRS.add_string(out_node, "TO_LOCATION_NO", MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO));

	TRS.add_double(out_node, "BOM_QTY", MTIVTRSDTL.BOM_QTY);

    if(COM_isnullspace(MTIVTRSDTL.FROM_OPER) == MP_FALSE)
    {
        DBC_init_mwipoprdef(&MWIPOPRDEF);
        TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPOPRDEF.OPER, MTIVTRSDTL.FROM_OPER, sizeof(MWIPOPRDEF.OPER));
        DBC_select_mwipoprdef(1, &MWIPOPRDEF);

        TRS.add_string(out_node, "FROM_OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
    }

    if(COM_isnullspace(MTIVTRSDTL.TO_OPER) == MP_FALSE)
    {
        DBC_init_mwipoprdef(&MWIPOPRDEF);
        TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPOPRDEF.OPER, MTIVTRSDTL.TO_OPER, sizeof(MWIPOPRDEF.OPER));
        DBC_select_mwipoprdef(1, &MWIPOPRDEF);

        TRS.add_string(out_node, "TO_OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
    }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Transfer_Detail",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Transfer_Detail_Validation()
        - Validation Check sub function of "TIV_VIEW_TRANSFER_DETAIL" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Transfer_Detail_Validation(char *s_msg_code,
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
    /* Transfer No Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "TRS_NO")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TRS_NO", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }
    /* Transfer Seq Validation */
    //if(TRS.get_int(in_node, "TRS_SEQ") < 1)
    //{
    //    strcpy(s_msg_code, "WIP-0001");
    //    TRS.add_fieldmsg(out_node, "TRS_SEQ", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* Lot ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "WIP-0001");
    //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

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