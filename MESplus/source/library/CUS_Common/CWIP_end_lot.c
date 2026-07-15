/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_end_lot.c
    Description : Customized End Lot Service

    MES Version : 5.3.4 ~

    Function List
        - CWIP_End_Lot()
            + Setup service interface function
        - CWIP_END_LOT()
            + Main sub function of CWIP_End_Lot function
            + Setup service main business function
        - CWIP_End_Lot_Validation()
            + Main sub function of CWIP_END_LOT function
            + Check the condition for create/update/delete
    Detail Description
        - CWIP_END_LOT()
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

int CWIP_End_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_End_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_End_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_END_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_END_LOT", out_node);

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
    CWIP_END_LOT()
        - Main sub function of "CWIP_End_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_END_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    TRSNode* tran_in_node;

    LOG_head("CWIP_END_LOT");
    TRS.log_add_all_members(in_node);
	    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_End_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    tran_in_node = TRS.create_node("END_LOT_IN");
    CCOM_copy_in_node(in_node, tran_in_node);
    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
    TRS.add_nstring(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_int(tran_in_node, "LAST_ACTIVE_HIST_SEQ", TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
	TRS.add_nstring(tran_in_node,  "MAT_ID", TRS.get_string(in_node, "MAT_ID")); 
    TRS.set_int(tran_in_node, "MAT_VER", TRS.get_int(in_node, "MAT_VER"));

    TRS.add_nstring(tran_in_node, "FLOW", TRS.get_string(in_node, "FLOW"));
    TRS.set_int(tran_in_node, "FLOW_SEQ_NUM", TRS.get_int(in_node, "FLOW_SEQ_NUM"));
    TRS.add_nstring(tran_in_node, "OPER", TRS.get_string(in_node, "OPER"));

    TRS.set_double(tran_in_node, "QTY_1", TRS.get_double(in_node, "QTY_1"));
    TRS.set_double(tran_in_node, "QTY_2", TRS.get_double(in_node, "QTY_2"));
    TRS.set_double(tran_in_node, "QTY_3", TRS.get_double(in_node, "QTY_3"));

    TRS.add_nstring(tran_in_node, "TO_FLOW", TRS.get_string(in_node, "TO_FLOW"));
    TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", TRS.get_int(in_node, "TO_FLOW_SEQ_NUM"));
    TRS.add_nstring(tran_in_node, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));

    TRS.add_nstring(tran_in_node, "RET_FLOW", TRS.get_string(in_node, "RET_FLOW"));
    TRS.set_int(tran_in_node, "RET_FLOW_SEQ_NUM", TRS.get_int(in_node, "RET_FLOW_SEQ_NUM"));
    TRS.add_nstring(tran_in_node, "RET_OPER", TRS.get_string(in_node, "RET_OPER"));

    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.add_nstring(tran_in_node, "COMMENT", TRS.get_string(in_node, "COMMENT"));

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

	//CUSTOM 추가
	TRS.add_nstring(tran_in_node, "CLIENT_TIME", TRS.get_string(in_node, "CLIENT_TIME"));
	TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
	TRS.add_nstring(tran_in_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
	//Carrier Input Flag
	TRS.add_char(tran_in_node, "MAGAZINE_INPUT_FLAG", TRS.get_char(in_node, "MAGAZINE_INPUT_FLAG") );

	TRS.add_char(tran_in_node, "_SKIP_ERP_IF", TRS.get_char(in_node, "_SKIP_ERP_IF"));
	TRS.add_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", TRS.get_char(in_node, "INF_UPLOAD_TYPE_FLAG"));

	//공정에 따른 분기 
	//#define HQCEL_M1_CLEAVING_OPER                            ("M1000")
	//#define HQCEL_M1_LAYUP_OPER                               ("M2010")
	//#define HQCEL_M1_TABBER_OPER                              ("M2000")
	if (strcmp(TRS.get_string(tran_in_node, "OPER"), HQCEL_M1_CLEAVING_OPER) == 0)
	{
		if(CWIP_CLEAVING_END_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}
	else if (strcmp(TRS.get_string(tran_in_node, "OPER"), HQCEL_M1_LAYUP_OPER) == 0)
	{
		//LAYUP END 시 가상 모듈 ID-> INTO MODULE ID 로 바뀜.: 만일 다르면 틀린값을 넣어주어야함.
		//TRS.set_nstring(tran_in_node, "F_MODULE_ID", "L494359304394390999");
		TRS.set_nstring(tran_in_node, "F_MODULE_ID", TRS.get_string(in_node, "V_LOT_ID"));
		TRS.set_nstring(tran_in_node, "T_MODULE_ID", TRS.get_string(in_node, "LOT_ID"));

		if(CWIP_LAYUP_END_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}
	else if (strcmp(TRS.get_string(tran_in_node, "OPER"), HQCEL_M1_TABBER_OPER) == 0)
	{
		//Tabber End 시 STRING ID 는 
		TRS.set_nstring(tran_in_node, "STRING_ID", TRS.get_string(in_node, "LOT_ID"));
		if(CWIP_TABBER_END_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}
	else
	{
		if(WIP_END_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
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
    CWIP_End_Lot_Validation()
        - Main sub function of "CWIP_END_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_End_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

