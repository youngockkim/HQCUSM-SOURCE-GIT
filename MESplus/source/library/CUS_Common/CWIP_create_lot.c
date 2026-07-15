/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_create_lot.c
    Description : Customized Create Lot Service

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Create_Lot()
            + Setup service interface function
        - CWIP_CREATE_LOT()
            + Main sub function of CWIP_Create_Lot function
            + Setup service main business function
        - CWIP_Create_Lot_Validation()
            + Main sub function of CWIP_CREATE_LOT function
            + Check the condition for create/update/delete
    Detail Description
        - CWIP_CREATE_LOT()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018-11-21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"

int CWIP_Create_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Create_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Create_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_CREATE_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_CREATE_LOT", out_node);

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
    CWIP_CREATE_LOT()
        - Main sub function of "CWIP_Create_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_CREATE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{

	TRSNode* tran_in_node;

	char c_create_type = 'N';

    LOG_head("CWIP_CREATE_LOT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_Create_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    tran_in_node = TRS.create_node("CREATE_LOT_IN");
    CCOM_copy_in_node(in_node, tran_in_node);
    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
    TRS.add_nstring(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.add_nstring(tran_in_node, "LOT_DESC", TRS.get_string(in_node, "LOT_DESC"));
	TRS.add_nstring(tran_in_node,  "MAT_ID", TRS.get_string(in_node, "MAT_ID")); 
    TRS.set_int(tran_in_node, "MAT_VER", TRS.get_int(in_node, "MAT_VER"));
    TRS.add_nstring(tran_in_node, "FLOW", TRS.get_string(in_node, "FLOW"));
    TRS.set_int(tran_in_node, "FLOW_SEQ_NUM", TRS.get_int(in_node, "FLOW_SEQ_NUM"));
    TRS.add_nstring(tran_in_node, "OPER", TRS.get_string(in_node, "OPER"));
    TRS.add_char(tran_in_node, "LOT_TYPE", TRS.get_char(in_node, "LOT_TYPE"));  
    TRS.set_double(tran_in_node, "QTY_1", TRS.get_double(in_node, "QTY_1"));
    TRS.set_double(tran_in_node, "QTY_2", TRS.get_double(in_node, "QTY_2"));
    TRS.set_double(tran_in_node, "QTY_3", TRS.get_double(in_node, "QTY_3"));
    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.add_nstring(tran_in_node, "CRR_ID", TRS.get_string(in_node, "CRR_ID"));
    TRS.add_nstring(tran_in_node, "CREATE_CODE", TRS.get_string(in_node, "CREATE_CODE"));
    TRS.add_nstring(tran_in_node, "OWNER_CODE", TRS.get_string(in_node, "OWNER_CODE"));
    TRS.add_char(tran_in_node, "LOT_PRIORITY", TRS.get_char(in_node, "LOT_PRIORITY"));  
    TRS.add_nstring(tran_in_node, "DUE_TIME", TRS.get_string(in_node, "DUE_TIME"));
    TRS.add_nstring(tran_in_node, "COMMENT", TRS.get_string(in_node, "COMMENT"));
    TRS.add_char(tran_in_node, "IN_CASE", TRS.get_char(in_node, "IN_CASE"));  
    TRS.add_nstring(tran_in_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
    TRS.add_nstring(tran_in_node, "ORDER_WORK_DATE", TRS.get_string(in_node, "ORDER_WORK_DATE"));
    TRS.add_nstring(tran_in_node, "ORDER_MAT_ID", TRS.get_string(in_node, "ORDER_MAT_ID"));
    TRS.set_int(tran_in_node, "ORDER_MAT_VER", TRS.get_int(in_node, "ORDER_MAT_VER"));
    TRS.add_nstring(tran_in_node, "ORDER_LOT_ID", TRS.get_string(in_node, "ORDER_LOT_ID"));

    TRS.add_nstring(tran_in_node, "LOT_CMF_1", TRS.get_string(in_node, "LOT_CMF_1"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_2", TRS.get_string(in_node, "LOT_CMF_2"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_3", TRS.get_string(in_node, "LOT_CMF_3"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_4", TRS.get_string(in_node, "LOT_CMF_4"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_5", TRS.get_string(in_node, "LOT_CMF_5"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_6", TRS.get_string(in_node, "LOT_CMF_6"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_7", TRS.get_string(in_node, "LOT_CMF_7"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_8", TRS.get_string(in_node, "LOT_CMF_8"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_9", TRS.get_string(in_node, "LOT_CMF_9"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_10", TRS.get_string(in_node, "LOT_CMF_10"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_11", TRS.get_string(in_node, "LOT_CMF_11"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_12", TRS.get_string(in_node, "LOT_CMF_12"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_13", TRS.get_string(in_node, "LOT_CMF_13"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_14", TRS.get_string(in_node, "LOT_CMF_14"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_15", TRS.get_string(in_node, "LOT_CMF_15"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_16", TRS.get_string(in_node, "LOT_CMF_16"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_17", TRS.get_string(in_node, "LOT_CMF_17"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_18", TRS.get_string(in_node, "LOT_CMF_18"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_19", TRS.get_string(in_node, "LOT_CMF_19"));
    TRS.add_nstring(tran_in_node, "LOT_CMF_20", TRS.get_string(in_node, "LOT_CMF_20"));

    TRS.add_nstring(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "TRAN_CMF_1"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "TRAN_CMF_2"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_3", TRS.get_string(in_node, "TRAN_CMF_3"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_4", TRS.get_string(in_node, "TRAN_CMF_4"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_5", TRS.get_string(in_node, "TRAN_CMF_5"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_6", TRS.get_string(in_node, "TRAN_CMF_6"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_7", TRS.get_string(in_node, "TRAN_CMF_7"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_8", TRS.get_string(in_node, "TRAN_CMF_8"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_9", TRS.get_string(in_node, "TRAN_CMF_9"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_10", TRS.get_string(in_node, "TRAN_CMF_10"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_11", TRS.get_string(in_node, "TRAN_CMF_11"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_12", TRS.get_string(in_node, "TRAN_CMF_12"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_13", TRS.get_string(in_node, "TRAN_CMF_13"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_14", TRS.get_string(in_node, "TRAN_CMF_14"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_15", TRS.get_string(in_node, "TRAN_CMF_15"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_16", TRS.get_string(in_node, "TRAN_CMF_16"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_17", TRS.get_string(in_node, "TRAN_CMF_17"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_18", TRS.get_string(in_node, "TRAN_CMF_18"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_19", TRS.get_string(in_node, "TRAN_CMF_19"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_20", TRS.get_string(in_node, "TRAN_CMF_20"));

	c_create_type = 'O' ;  // ±âº»Àº ORDRE BASE : O(ENGLISH O), NORMAL : N

	if (c_create_type == 'O')
	{
		if(ORD_CREATE_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}
	else
	{
		if(WIP_CREATE_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}

	TRS.free_node(tran_in_node);

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Create_Lot_Validation()
        - Main sub function of "CWIP_CREATE_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Create_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct MWIPLOTSTS_TAG MWIPLOTSTS;
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
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }


    return MP_TRUE;
}

