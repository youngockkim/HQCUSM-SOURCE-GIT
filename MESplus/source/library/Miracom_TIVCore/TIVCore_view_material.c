/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_material.c
    Description : View Inventory Material Information related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Material()
            + View Inventory Material Information
        - TIV_VIEW_MATERIAL()
            + Main Sub function of "TIV_View_Material"
            + (called by "TIV_View_Material")
        - TIV_View_Material_Validation()
            + Validation Check sub function of "TIV_VIEW_MATERIAL" function
            + (called by "TIV_VIEW_MATERIAL")

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

int TIV_View_Material_Validation(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);


/*******************************************************************************
    TIV_View_Material()
        - View Inventory Material Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_MATERIAL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_MATERIAL", out_node);

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
    TIV_VIEW_MATERIAL()
        - Main sub function of "TIV_View_Material" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_MATERIAL(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node)
{
    struct MTIVMATDEF_TAG MTIVMATDEF;

	char s_sys_time[14];

    LOG_head("TIV_VIEW_MATERIAL");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* Validation Check */
    if(TIV_View_Material_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	TRS.set_string(out_node, "SYS_TIME", s_sys_time, sizeof(s_sys_time));


	if(TRS.get_procstep(in_node)=='2')
	DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
    TRS.set_int(in_node, "MAT_VER", (int)DBC_select_mtivmatdef_scalar(1, &MTIVMATDEF));
    

    DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
    MTIVMATDEF.MAT_VER  = TRS.get_int(in_node, "MAT_VER");
    DBC_select_mtivmatdef(1, &MTIVMATDEF);
    if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0006");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }
        TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    TRS.add_string(out_node, "MAT_ID", MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
    TRS.add_int(out_node, "MAT_VER", MTIVMATDEF.MAT_VER);
    TRS.add_string(out_node, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));
    TRS.add_string(out_node, "MAT_SHORT_DESC", MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC));
    TRS.add_string(out_node, "MAT_TYPE", MTIVMATDEF.MAT_TYPE, sizeof(MTIVMATDEF.MAT_TYPE));

    TRS.add_string(out_node, "MAT_GRP_1", MTIVMATDEF.MAT_GRP_1, sizeof(MTIVMATDEF.MAT_GRP_1));
    TRS.add_string(out_node, "MAT_GRP_2", MTIVMATDEF.MAT_GRP_2, sizeof(MTIVMATDEF.MAT_GRP_2));
    TRS.add_string(out_node, "MAT_GRP_3", MTIVMATDEF.MAT_GRP_3, sizeof(MTIVMATDEF.MAT_GRP_3));
    TRS.add_string(out_node, "MAT_GRP_4", MTIVMATDEF.MAT_GRP_4, sizeof(MTIVMATDEF.MAT_GRP_4));
    TRS.add_string(out_node, "MAT_GRP_5", MTIVMATDEF.MAT_GRP_5, sizeof(MTIVMATDEF.MAT_GRP_5));
    TRS.add_string(out_node, "MAT_GRP_6", MTIVMATDEF.MAT_GRP_6, sizeof(MTIVMATDEF.MAT_GRP_6));
    TRS.add_string(out_node, "MAT_GRP_7", MTIVMATDEF.MAT_GRP_7, sizeof(MTIVMATDEF.MAT_GRP_7));
    TRS.add_string(out_node, "MAT_GRP_8", MTIVMATDEF.MAT_GRP_8, sizeof(MTIVMATDEF.MAT_GRP_8));
    TRS.add_string(out_node, "MAT_GRP_9", MTIVMATDEF.MAT_GRP_9, sizeof(MTIVMATDEF.MAT_GRP_9));
    TRS.add_string(out_node, "MAT_GRP_10", MTIVMATDEF.MAT_GRP_10, sizeof(MTIVMATDEF.MAT_GRP_10));

    TRS.add_string(out_node, "MAT_CMF_1", MTIVMATDEF.MAT_CMF_1, sizeof(MTIVMATDEF.MAT_CMF_1));
    TRS.add_string(out_node, "MAT_CMF_2", MTIVMATDEF.MAT_CMF_2, sizeof(MTIVMATDEF.MAT_CMF_2));
    TRS.add_string(out_node, "MAT_CMF_3", MTIVMATDEF.MAT_CMF_3, sizeof(MTIVMATDEF.MAT_CMF_3));
    TRS.add_string(out_node, "MAT_CMF_4", MTIVMATDEF.MAT_CMF_4, sizeof(MTIVMATDEF.MAT_CMF_4));
    TRS.add_string(out_node, "MAT_CMF_5", MTIVMATDEF.MAT_CMF_5, sizeof(MTIVMATDEF.MAT_CMF_5));
    TRS.add_string(out_node, "MAT_CMF_6", MTIVMATDEF.MAT_CMF_6, sizeof(MTIVMATDEF.MAT_CMF_6));
    TRS.add_string(out_node, "MAT_CMF_7", MTIVMATDEF.MAT_CMF_7, sizeof(MTIVMATDEF.MAT_CMF_7));
    TRS.add_string(out_node, "MAT_CMF_8", MTIVMATDEF.MAT_CMF_8, sizeof(MTIVMATDEF.MAT_CMF_8));
    TRS.add_string(out_node, "MAT_CMF_9", MTIVMATDEF.MAT_CMF_9, sizeof(MTIVMATDEF.MAT_CMF_9));
    TRS.add_string(out_node, "MAT_CMF_10", MTIVMATDEF.MAT_CMF_10, sizeof(MTIVMATDEF.MAT_CMF_10));
    TRS.add_string(out_node, "MAT_CMF_11", MTIVMATDEF.MAT_CMF_11, sizeof(MTIVMATDEF.MAT_CMF_11));
    TRS.add_string(out_node, "MAT_CMF_12", MTIVMATDEF.MAT_CMF_12, sizeof(MTIVMATDEF.MAT_CMF_12));
    TRS.add_string(out_node, "MAT_CMF_13", MTIVMATDEF.MAT_CMF_13, sizeof(MTIVMATDEF.MAT_CMF_13));
    TRS.add_string(out_node, "MAT_CMF_14", MTIVMATDEF.MAT_CMF_14, sizeof(MTIVMATDEF.MAT_CMF_14));
    TRS.add_string(out_node, "MAT_CMF_15", MTIVMATDEF.MAT_CMF_15, sizeof(MTIVMATDEF.MAT_CMF_15));
    TRS.add_string(out_node, "MAT_CMF_16", MTIVMATDEF.MAT_CMF_16, sizeof(MTIVMATDEF.MAT_CMF_16));
    TRS.add_string(out_node, "MAT_CMF_17", MTIVMATDEF.MAT_CMF_17, sizeof(MTIVMATDEF.MAT_CMF_17));
    TRS.add_string(out_node, "MAT_CMF_18", MTIVMATDEF.MAT_CMF_18, sizeof(MTIVMATDEF.MAT_CMF_18));
    TRS.add_string(out_node, "MAT_CMF_19", MTIVMATDEF.MAT_CMF_19, sizeof(MTIVMATDEF.MAT_CMF_19));
    TRS.add_string(out_node, "MAT_CMF_20", MTIVMATDEF.MAT_CMF_20, sizeof(MTIVMATDEF.MAT_CMF_20));

    TRS.add_string(out_node, "MFG_DEVISION", MTIVMATDEF.MFG_DEVISION, sizeof(MTIVMATDEF.MFG_DEVISION));
    TRS.add_char(out_node, "SUBCONTRACT_FLAG", MTIVMATDEF.SUBCONTRACT_FLAG);
    TRS.add_string(out_node, "BASE_MAT_ID", MTIVMATDEF.BASE_MAT_ID, sizeof(MTIVMATDEF.BASE_MAT_ID));
    TRS.add_string(out_node, "VENDOR_ID", MTIVMATDEF.VENDOR_ID, sizeof(MTIVMATDEF.VENDOR_ID));
    TRS.add_string(out_node, "VENDOR_MAT_ID", MTIVMATDEF.VENDOR_MAT_ID, sizeof(MTIVMATDEF.VENDOR_MAT_ID));
    TRS.add_string(out_node, "CUSTOMER_ID", MTIVMATDEF.CUSTOMER_ID, sizeof(MTIVMATDEF.CUSTOMER_ID));
    TRS.add_string(out_node, "CUSTOMER_MAT_ID", MTIVMATDEF.CUSTOMER_MAT_ID, sizeof(MTIVMATDEF.CUSTOMER_MAT_ID));
    TRS.add_double(out_node, "DEF_QTY_1", MTIVMATDEF.DEF_QTY_1);
    TRS.add_double(out_node, "DEF_QTY_2", MTIVMATDEF.DEF_QTY_2);
    TRS.add_double(out_node, "DEF_QTY_3", MTIVMATDEF.DEF_QTY_3);

    TRS.add_string(out_node, "UNIT1", MTIVMATDEF.UNIT_1, sizeof(MTIVMATDEF.UNIT_1));
    TRS.add_string(out_node, "UNIT2", MTIVMATDEF.UNIT_2, sizeof(MTIVMATDEF.UNIT_2));
    TRS.add_string(out_node, "UNIT3", MTIVMATDEF.UNIT_3, sizeof(MTIVMATDEF.UNIT_3));

    TRS.add_double(out_node, "WEIGHT_NET", MTIVMATDEF.WEIGHT_NET);
    TRS.add_double(out_node, "WEIGHT_GROSS", MTIVMATDEF.WEIGHT_GROSS);
    TRS.add_string(out_node, "WEIGHT_UNIT", MTIVMATDEF.WEIGHT_UNIT, sizeof(MTIVMATDEF.WEIGHT_UNIT));

    TRS.add_double(out_node, "VOLUME", MTIVMATDEF.VOLUME);
    TRS.add_string(out_node, "VOLUME_UNIT", MTIVMATDEF.VOLUME_UNIT, sizeof(MTIVMATDEF.VOLUME_UNIT));

    TRS.add_double(out_node, "DIMENSION_HR", MTIVMATDEF.DIMENSION_HR);
    TRS.add_string(out_node, "DIMENSION_HR_UNIT", MTIVMATDEF.DIMENSION_HR_UNIT, sizeof(MTIVMATDEF.DIMENSION_HR_UNIT));
    TRS.add_double(out_node, "DIMENSION_VT", MTIVMATDEF.DIMENSION_VT);
    TRS.add_string(out_node, "DIMENSION_VT_UNIT", MTIVMATDEF.DIMENSION_VT_UNIT, sizeof(MTIVMATDEF.DIMENSION_VT_UNIT));
    TRS.add_double(out_node, "DIMENSION_HT", MTIVMATDEF.DIMENSION_HT);
    TRS.add_string(out_node, "DIMENSION_HT_UNIT", MTIVMATDEF.DIMENSION_HT_UNIT, sizeof(MTIVMATDEF.DIMENSION_HT_UNIT));

    TRS.add_string(out_node, "BOM_SET_ID", MTIVMATDEF.BOM_SET_ID, sizeof(MTIVMATDEF.BOM_SET_ID));
    TRS.add_string(out_node, "DEF_TIV_OPER", MTIVMATDEF.DEF_INV_OPER, sizeof(MTIVMATDEF.DEF_INV_OPER));

    TRS.add_char(out_node, "PACK_TYPE", MTIVMATDEF.PACK_TYPE);
    TRS.add_int(out_node, "PACK_LOT_COUNT", MTIVMATDEF.PACK_LOT_COUNT);
    TRS.add_double(out_node, "PACK_QTY", MTIVMATDEF.PACK_QTY);

    TRS.add_double(out_node, "LE_STOCK_LEVEL", MTIVMATDEF.LE_STOCK_LEVEL);
    TRS.add_double(out_node, "LW_STOCK_LEVEL", MTIVMATDEF.LW_STOCK_LEVEL);
    TRS.add_double(out_node, "HE_STOCK_LEVEL", MTIVMATDEF.HE_STOCK_LEVEL);
    TRS.add_double(out_node, "HW_STOCK_LEVEL", MTIVMATDEF.HW_STOCK_LEVEL);

    TRS.add_char(out_node, "IQC_FLAG", MTIVMATDEF.IQC_FLAG);
    TRS.add_char(out_node, "IQC_SAMPLE_FLAG", MTIVMATDEF.IQC_SAMPLE_FLAG);
    TRS.add_char(out_node, "IQC_SAMPLE_RULE", MTIVMATDEF.IQC_SAMPLE_RULE);

    TRS.add_char(out_node, "OQC_FLAG", MTIVMATDEF.OQC_FLAG);
    TRS.add_char(out_node, "OQC_SAMPLE_FLAG", MTIVMATDEF.OQC_SAMPLE_FLAG);
    TRS.add_char(out_node, "OQC_SAMPLE_RULE", MTIVMATDEF.OQC_SAMPLE_RULE);

    TRS.add_double(out_node, "TARGET_YIELD", MTIVMATDEF.TARGET_YIELD);
    TRS.add_double(out_node, "TARGET_DUE_DAY", MTIVMATDEF.TARGET_DUE_DAY);
    TRS.add_double(out_node, "TARGET_QTY_1", MTIVMATDEF.TARGET_QTY_1);
    TRS.add_double(out_node, "TARGET_QTY_2", MTIVMATDEF.TARGET_QTY_2);
    TRS.add_double(out_node, "TARGET_QTY_3", MTIVMATDEF.TARGET_QTY_3);

    TRS.add_string(out_node, "APPLY_START_TIME", MTIVMATDEF.APPLY_START_TIME, sizeof(MTIVMATDEF.APPLY_START_TIME));
    TRS.add_string(out_node, "APPLY_END_TIME", MTIVMATDEF.APPLY_END_TIME, sizeof(MTIVMATDEF.APPLY_END_TIME));
    TRS.add_char(out_node, "APPROVAL_FLAG", MTIVMATDEF.APPROVAL_FLAG);
    TRS.add_enc_string(out_node, "APPROVAL_USER_ID", MTIVMATDEF.APPROVAL_USER_ID, sizeof(MTIVMATDEF.APPROVAL_USER_ID));
    TRS.add_string(out_node, "APPROVAL_TIME", MTIVMATDEF.APPROVAL_TIME, sizeof(MTIVMATDEF.APPROVAL_TIME));
    TRS.add_char(out_node, "RELEASE_FLAG", MTIVMATDEF.RELEASE_FLAG);
    TRS.add_enc_string(out_node, "RELEASE_USER_ID", MTIVMATDEF.RELEASE_USER_ID, sizeof(MTIVMATDEF.RELEASE_USER_ID));
    TRS.add_string(out_node, "RELEASE_TIME", MTIVMATDEF.RELEASE_TIME, sizeof(MTIVMATDEF.RELEASE_TIME));
    TRS.add_char(out_node, "DEACTIVE_FLAG", MTIVMATDEF.DEACTIVE_FLAG);
    TRS.add_enc_string(out_node, "DEACTIVE_USER_ID", MTIVMATDEF.DEACTIVE_USER_ID, sizeof(MTIVMATDEF.DEACTIVE_USER_ID));
    TRS.add_string(out_node, "DEACTIVE_TIME", MTIVMATDEF.DEACTIVE_TIME, sizeof(MTIVMATDEF.DEACTIVE_TIME));

    TRS.add_char(out_node, "DELETE_FLAG", MTIVMATDEF.DELETE_FLAG);

    TRS.add_enc_string(out_node, "DELETE_USER_ID", MTIVMATDEF.DELETE_USER_ID, sizeof(MTIVMATDEF.DELETE_USER_ID));
    TRS.add_string(out_node, "DELETE_TIME", MTIVMATDEF.DELETE_TIME, sizeof(MTIVMATDEF.DELETE_TIME));
    TRS.add_enc_string(out_node, "CREATE_USER_ID", MTIVMATDEF.CREATE_USER_ID, sizeof(MTIVMATDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MTIVMATDEF.CREATE_TIME, sizeof(MTIVMATDEF.CREATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MTIVMATDEF.UPDATE_USER_ID, sizeof(MTIVMATDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MTIVMATDEF.UPDATE_TIME, sizeof(MTIVMATDEF.UPDATE_TIME));


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Material_Validation()
        - Validation Check sub function of "TIV_VIEW_MATERIAL" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material_Validation(char *s_msg_code,
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
    /* Material ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* Material Version Validation */
    if(TRS.get_int(in_node, "MAT_VER") < 1)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    return MP_TRUE;
}