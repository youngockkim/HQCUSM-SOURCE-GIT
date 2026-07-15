/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_oper.c
    Description : View Inventory Oper Information related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Oper()
            + View Inventory Oper Information
        - TIV_VIEW_OPER()
            + Main Sub function of "TIV_View_Oper"
            + (called by "TIV_View_Oper")
        - TIV_View_Oper_Validation()
            + Validation Check sub function of "TIV_VIEW_OPER" function
            + (called by "TIV_VIEW_OPER")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/31  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Oper_Validation(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);


/*******************************************************************************
    TIV_View_Oper()
        - View Inventory Oper Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Oper(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_OPER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_OPER", out_node);

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
    TIV_VIEW_OPER()
        - Main sub function of "TIV_View_Oper" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_OPER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
    //struct MWIPOPRDEF_TAG MWIPOPRDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    
	int i_step = 0;

    LOG_head("TIV_VIEW_OPER");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Oper",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* Validation Check */
    if(TIV_View_Oper_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

   /* DBC_init_mwipoprdef(&MWIPOPRDEF);
    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "OPER");
    DBC_select_mwipoprdef(1,&MWIPOPRDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }
        TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
*/
	if (TRS.get_procstep(in_node) == '1')
	{
		DBC_init_mtivoprdef(&MTIVOPRDEF);
		TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "OPER");
		i_step = 1;
	}
	else if (TRS.get_procstep(in_node) == '2')
	{
		DBC_init_mtivoprdef(&MTIVOPRDEF);
		TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
		MTIVOPRDEF.OPER_CMF_3[0] = TRS.get_char(in_node, "OPER_TYPE_FLAG");
		i_step = 4;
	}
    
    DBC_select_mtivoprdef(i_step, &MTIVOPRDEF);
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
    {
        //if(DB_error_code == DB_NOT_FOUND)
        //{
            //strcpy(s_msg_code, "INV-0010");
            //gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        //}
        //else 
        //{
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        //}
        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "OPER", MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER));
    TRS.add_string(out_node, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
	TRS.add_string(out_node, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));
    TRS.add_string(out_node, "OPER_GRP_1", MTIVOPRDEF.OPER_GRP_1, sizeof(MTIVOPRDEF.OPER_GRP_1));
    TRS.add_string(out_node, "OPER_GRP_2", MTIVOPRDEF.OPER_GRP_2, sizeof(MTIVOPRDEF.OPER_GRP_2));
    TRS.add_string(out_node, "OPER_GRP_3", MTIVOPRDEF.OPER_GRP_3, sizeof(MTIVOPRDEF.OPER_GRP_3));
    TRS.add_string(out_node, "OPER_GRP_4", MTIVOPRDEF.OPER_GRP_4, sizeof(MTIVOPRDEF.OPER_GRP_4));
    TRS.add_string(out_node, "OPER_GRP_5", MTIVOPRDEF.OPER_GRP_5, sizeof(MTIVOPRDEF.OPER_GRP_5));
    TRS.add_string(out_node, "OPER_GRP_6", MTIVOPRDEF.OPER_GRP_6, sizeof(MTIVOPRDEF.OPER_GRP_6));
    TRS.add_string(out_node, "OPER_GRP_7", MTIVOPRDEF.OPER_GRP_7, sizeof(MTIVOPRDEF.OPER_GRP_7));
    TRS.add_string(out_node, "OPER_GRP_8", MTIVOPRDEF.OPER_GRP_8, sizeof(MTIVOPRDEF.OPER_GRP_8));
    TRS.add_string(out_node, "OPER_GRP_9", MTIVOPRDEF.OPER_GRP_9, sizeof(MTIVOPRDEF.OPER_GRP_9));
    TRS.add_string(out_node, "OPER_GRP_10", MTIVOPRDEF.OPER_GRP_10, sizeof(MTIVOPRDEF.OPER_GRP_10));
    TRS.add_string(out_node, "OPER_CMF_1", MTIVOPRDEF.OPER_CMF_1, sizeof(MTIVOPRDEF.OPER_CMF_1));
    TRS.add_string(out_node, "OPER_CMF_2", MTIVOPRDEF.OPER_CMF_2, sizeof(MTIVOPRDEF.OPER_CMF_2));
    TRS.add_string(out_node, "OPER_CMF_3", MTIVOPRDEF.OPER_CMF_3, sizeof(MTIVOPRDEF.OPER_CMF_3));
    TRS.add_string(out_node, "OPER_CMF_4", MTIVOPRDEF.OPER_CMF_4, sizeof(MTIVOPRDEF.OPER_CMF_4));
    TRS.add_string(out_node, "OPER_CMF_5", MTIVOPRDEF.OPER_CMF_5, sizeof(MTIVOPRDEF.OPER_CMF_5));
    TRS.add_string(out_node, "OPER_CMF_6", MTIVOPRDEF.OPER_CMF_6, sizeof(MTIVOPRDEF.OPER_CMF_6));
    TRS.add_string(out_node, "OPER_CMF_7", MTIVOPRDEF.OPER_CMF_7, sizeof(MTIVOPRDEF.OPER_CMF_7));
    TRS.add_string(out_node, "OPER_CMF_8", MTIVOPRDEF.OPER_CMF_8, sizeof(MTIVOPRDEF.OPER_CMF_8));
    TRS.add_string(out_node, "OPER_CMF_9", MTIVOPRDEF.OPER_CMF_9, sizeof(MTIVOPRDEF.OPER_CMF_9));
    TRS.add_string(out_node, "OPER_CMF_10", MTIVOPRDEF.OPER_CMF_10, sizeof(MTIVOPRDEF.OPER_CMF_10));
    TRS.add_string(out_node, "OPER_CMF_11", MTIVOPRDEF.OPER_CMF_11, sizeof(MTIVOPRDEF.OPER_CMF_11));
    TRS.add_string(out_node, "OPER_CMF_12", MTIVOPRDEF.OPER_CMF_12, sizeof(MTIVOPRDEF.OPER_CMF_12));
    TRS.add_string(out_node, "OPER_CMF_13", MTIVOPRDEF.OPER_CMF_13, sizeof(MTIVOPRDEF.OPER_CMF_13));
    TRS.add_string(out_node, "OPER_CMF_14", MTIVOPRDEF.OPER_CMF_14, sizeof(MTIVOPRDEF.OPER_CMF_14));
    TRS.add_string(out_node, "OPER_CMF_15", MTIVOPRDEF.OPER_CMF_15, sizeof(MTIVOPRDEF.OPER_CMF_15));
    TRS.add_string(out_node, "OPER_CMF_16", MTIVOPRDEF.OPER_CMF_16, sizeof(MTIVOPRDEF.OPER_CMF_16));
    TRS.add_string(out_node, "OPER_CMF_17", MTIVOPRDEF.OPER_CMF_17, sizeof(MTIVOPRDEF.OPER_CMF_17));
    TRS.add_string(out_node, "OPER_CMF_18", MTIVOPRDEF.OPER_CMF_18, sizeof(MTIVOPRDEF.OPER_CMF_18));
    TRS.add_string(out_node, "OPER_CMF_19", MTIVOPRDEF.OPER_CMF_19, sizeof(MTIVOPRDEF.OPER_CMF_19));
    TRS.add_string(out_node, "OPER_CMF_20", MTIVOPRDEF.OPER_CMF_20, sizeof(MTIVOPRDEF.OPER_CMF_20));
    TRS.add_string(out_node, "UNIT_1", MTIVOPRDEF.UNIT_1, sizeof(MTIVOPRDEF.UNIT_1));
    TRS.add_string(out_node, "UNIT_2", MTIVOPRDEF.UNIT_2, sizeof(MTIVOPRDEF.UNIT_2));
    TRS.add_string(out_node, "UNIT_3", MTIVOPRDEF.UNIT_3, sizeof(MTIVOPRDEF.UNIT_3));
    TRS.add_char(out_node, "TRANSIT_FLAG", MTIVOPRDEF.TRANSIT_FLAG);
    TRS.add_char(out_node, "SHIP_FLAG", MTIVOPRDEF.SHIP_FLAG);
    TRS.add_char(out_node, "INV_FLAG", MTIVOPRDEF.INV_FLAG);
    TRS.add_char(out_node, "ERP_FLAG", MTIVOPRDEF.ERP_FLAG);
    TRS.add_char(out_node, "START_REQUIRE_FLAG", MTIVOPRDEF.START_REQUIRE_FLAG);
    TRS.add_char(out_node, "END_OPER_FLAG", MTIVOPRDEF.END_OPER_FLAG);
    TRS.add_char(out_node, "PUSH_PULL_FLAG", MTIVOPRDEF.PUSH_PULL_FLAG);
    TRS.add_string(out_node, "LOSS_TBL", MTIVOPRDEF.LOSS_TBL, sizeof(MTIVOPRDEF.LOSS_TBL));
    TRS.add_string(out_node, "BONUS_TBL", MTIVOPRDEF.BONUS_TBL, sizeof(MTIVOPRDEF.BONUS_TBL));
    TRS.add_string(out_node, "REWORK_TBL", MTIVOPRDEF.REWORK_TBL, sizeof(MTIVOPRDEF.REWORK_TBL));
    TRS.add_char(out_node, "SEC_CHK_FLAG", MTIVOPRDEF.SEC_CHK_FLAG);
    TRS.add_string(out_node, "AREA_ID", MTIVOPRDEF.AREA_ID, sizeof(MTIVOPRDEF.AREA_ID));
    TRS.add_string(out_node, "SUB_AREA_ID", MTIVOPRDEF.SUB_AREA_ID, sizeof(MTIVOPRDEF.SUB_AREA_ID));
    TRS.add_enc_string(out_node, "CREATE_USER_ID", MTIVOPRDEF.CREATE_USER_ID, sizeof(MTIVOPRDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MTIVOPRDEF.CREATE_TIME, sizeof(MTIVOPRDEF.CREATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MTIVOPRDEF.UPDATE_USER_ID, sizeof(MTIVOPRDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MTIVOPRDEF.UPDATE_TIME, sizeof(MTIVOPRDEF.UPDATE_TIME));
	
	/*TRS.add_char(out_node, "TIV_WH_FLAG", MTIVOPRDEF.TIV_WH_FLAG);
	TRS.add_char(out_node, "WIP_FLAG", MTIVOPRDEF.WIP_FLAG);
	TRS.add_char(out_node, "NG_FLAG", MTIVOPRDEF.NG_FLAG);
	TRS.add_char(out_node, "TRAN_IN_FLAG", MTIVOPRDEF.TRAN_IN_FLAG);
	TRS.add_char(out_node, "TRAN_OUT_FLAG", MTIVOPRDEF.TRAN_OUT_FLAG);
	TRS.add_char(out_node, "IN_OUT_FLAG", MTIVOPRDEF.IN_OUT_FLAG);
	TRS.add_char(out_node, "TIV_IN_WIP_FLAG", MTIVOPRDEF.TIV_IN_WIP_FLAG);
	TRS.add_char(out_node, "IQC_REQ_FLAG", MTIVOPRDEF.IQC_REQ_FLAG);
	TRS.add_char(out_node, "TIV_INTRANSIT_FLAG", MTIVOPRDEF.TIV_INTRANSIT_FLAG);
	TRS.add_char(out_node, "SPARE_FLAG", MTIVOPRDEF.SPARE_FLAG);
	TRS.add_char(out_node, "QC_FLAG", MTIVOPRDEF.QC_FLAG);*/

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Oper",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Oper_Validation()
        - Validation Check sub function of "TIV_VIEW_OPER" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Oper_Validation(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node)
{    
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
    /* Operation Validation */

	if (TRS.get_procstep(in_node) == '1')
	{
		if(COM_isnullspace(TRS.get_string(in_node, "OPER")) == MP_TRUE)
		{
			strcpy(s_msg_code, "INV-0001");
			TRS.add_fieldmsg(out_node, "OPER", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
    
    return MP_TRUE;
}