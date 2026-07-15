/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_update_inv_material.c.c
    Description : Create/Update/Delete Material definition

    MES Version : 4.0.0

    Function List
        - TIV_Update_Inv_Material()
            + Create/Update/Delete Material definition
        - TIV_UPDATE_TIV_MATERIAL()
            + Main sub function of "WIP_Update_Material" function
            + Create/Update/Delete Material definition
        - TIV_Update_Inv_Material_Validation()
            + check condition before Create/Update/Delete Material definition

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1    2012/12/13		bs.kwak			create

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_Update_Inv_Material_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node);

int TIV_Check_Inv_Material_GRPCMF(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node);

int Process_Inv_Material_VersionUp(char *s_msg_code,
                               TRSNode *out_node,
                               int i_from_ver,
                               struct MTIVMATDEF_TAG *MTIVMATDEF);


/*******************************************************************************
    TIV_Update_Inv_Material()
        - Create/Update/Delete Material definition
    Return Value
        - Integer : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node :Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_Inv_Material(TRSNode *in_node, 
                        TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_UPDATE_INV_MATERIAL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_UPDATE_TIV_MATERIAL", out_node);

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
    TIV_UPDATE_TIV_MATERIAL()
        - Main sub function of "TIV_Update_Inv_Material" function
        - Create/Update/Delete Material definition
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_UPDATE_INV_MATERIAL(char *s_msg_code,
                             TRSNode *in_node, 
                             TRSNode *out_node)
{
    struct  MTIVMATDEF_TAG  MTIVMATDEF;
    struct  MTIVMATDEF_TAG  MTIVMATDEF_T;
    char    s_sys_time[14];

    LOG_head("TIV_UPDATE_TIV_MATERIAL");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    LOG_add("mat_desc", MP_NSTR, TRS.get_string(in_node, "MAT_DESC"));
	LOG_add("mat_short_desc", MP_NSTR, TRS.get_string(in_node, "MAT_SHORT_DESC"));
    LOG_add("mat_type", MP_NSTR, TRS.get_string(in_node, "MAT_TYPE"));
    LOG_add("mat_grp_1", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_1"));
    LOG_add("mat_grp_2", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_2"));
    LOG_add("mat_grp_3", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_3"));
    LOG_add("mat_grp_4", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_4"));
    LOG_add("mat_grp_5", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_5"));
    LOG_add("mat_grp_6", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_6"));
    LOG_add("mat_grp_7", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_7"));
    LOG_add("mat_grp_8", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_8"));
    LOG_add("mat_grp_9", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_9"));
    LOG_add("mat_grp_10", MP_NSTR, TRS.get_string(in_node, "MAT_GRP_10"));
    LOG_add("mat_cmf_1", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_1"));
    LOG_add("mat_cmf_2", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_2"));
    LOG_add("mat_cmf_3", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_3"));
    LOG_add("mat_cmf_4", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_4"));
    LOG_add("mat_cmf_5", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_5"));
    LOG_add("mat_cmf_6", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_6"));
    LOG_add("mat_cmf_7", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_7"));
    LOG_add("mat_cmf_8", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_8"));
    LOG_add("mat_cmf_9", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_9"));
    LOG_add("mat_cmf_10", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_10"));
    LOG_add("mat_cmf_11", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_11"));
    LOG_add("mat_cmf_12", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_12"));
    LOG_add("mat_cmf_13", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_13"));
    LOG_add("mat_cmf_14", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_14"));
    LOG_add("mat_cmf_15", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_15"));
    LOG_add("mat_cmf_16", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_16"));
    LOG_add("mat_cmf_17", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_17"));
    LOG_add("mat_cmf_18", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_18"));
    LOG_add("mat_cmf_19", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_19"));
    LOG_add("mat_cmf_20", MP_NSTR, TRS.get_string(in_node, "MAT_CMF_20"));
    LOG_add("mfg_devision", MP_NSTR, TRS.get_string(in_node, "MFG_DEVISION"));
    LOG_add("subcontract_flag", MP_CHR, TRS.get_char(in_node, "SUBCONTRACT_FLAG"));
    LOG_add("base_mat_id", MP_NSTR, TRS.get_string(in_node, "BASE_MAT_ID"));
    LOG_add("vendor_id", MP_NSTR, TRS.get_string(in_node, "VENDOR_ID"));
    LOG_add("vendor_mat_id", MP_NSTR, TRS.get_string(in_node, "VENDOR_MAT_ID"));
    LOG_add("customer_id", MP_NSTR, TRS.get_string(in_node, "CUSTOMER_ID"));
    LOG_add("customer_mat_id", MP_NSTR, TRS.get_string(in_node, "CUSTOMER_MAT_ID"));
    LOG_add("def_qty_1", MP_DBL, TRS.get_double(in_node, "DEF_QTY_1"));
    LOG_add("def_qty_2", MP_DBL, TRS.get_double(in_node, "DEF_QTY_2"));
    LOG_add("def_qty_3", MP_DBL, TRS.get_double(in_node, "DEF_QTY_3"));
    LOG_add("unit1", MP_NSTR, TRS.get_string(in_node, "UNIT1"));
    LOG_add("unit2", MP_NSTR, TRS.get_string(in_node, "UNIT2"));
    LOG_add("unit3", MP_NSTR, TRS.get_string(in_node, "UNIT3"));
    LOG_add("weight_net", MP_DBL, TRS.get_double(in_node, "WEIGHT_NET"));
    LOG_add("weight_gross", MP_DBL, TRS.get_double(in_node, "WEIGHT_GROSS"));
    LOG_add("weight_unit", MP_NSTR, TRS.get_string(in_node, "WEIGHT_UNIT"));
    LOG_add("volume", MP_DBL, TRS.get_double(in_node, "VOLUME"));
    LOG_add("volume_unit", MP_NSTR, TRS.get_string(in_node, "VOLUME_UNIT"));
    LOG_add("dimension_hr", MP_DBL, TRS.get_double(in_node, "DIMENSION_HR"));
    LOG_add("dimension_hr_unit", MP_NSTR, TRS.get_string(in_node, "DIMENSION_HR_UNIT"));
    LOG_add("dimension_vt", MP_DBL, TRS.get_double(in_node, "DIMENSION_VT"));
    LOG_add("dimension_vt_unit", MP_NSTR, TRS.get_string(in_node, "DIMENSION_VT_UNIT"));
    LOG_add("dimension_ht", MP_DBL, TRS.get_double(in_node, "DIMENSION_HT"));
    LOG_add("dimension_ht_unit", MP_NSTR, TRS.get_string(in_node, "DIMENSION_HT_UNIT"));
    LOG_add("bom_set_id", MP_NSTR, TRS.get_string(in_node, "BOM_SET_ID"));
    LOG_add("def_inv_oper", MP_NSTR, TRS.get_string(in_node, "DEF_INV_OPER"));
    LOG_add("pack_type", MP_CHR, TRS.get_char(in_node, "PACK_TYPE"));
    LOG_add("pack_lot_count", MP_INT, TRS.get_int(in_node, "PACK_LOT_COUNT"));
    LOG_add("pack_qty", MP_DBL, TRS.get_double(in_node, "PACK_QTY"));
    LOG_add("le_stock_level", MP_DBL, TRS.get_double(in_node, "LE_STOCK_LEVEL"));
    LOG_add("lw_stock_level", MP_DBL, TRS.get_double(in_node, "LW_STOCK_LEVEL"));
    LOG_add("hw_stock_level", MP_DBL, TRS.get_double(in_node, "HW_STOCK_LEVEL"));
    LOG_add("he_stock_level", MP_DBL, TRS.get_double(in_node, "HE_STOCK_LEVEL"));
    LOG_add("iqc_flag", MP_CHR, TRS.get_char(in_node, "IQC_FLAG"));
    LOG_add("iqc_sample_flag", MP_CHR, TRS.get_char(in_node, "IQC_SAMPLE_FLAG"));
    LOG_add("iqc_sample_rule", MP_CHR, TRS.get_char(in_node, "IQC_SAMPLE_RULE"));
    LOG_add("oqc_flag", MP_CHR, TRS.get_char(in_node, "OQC_FLAG"));
    LOG_add("oqc_sample_flag", MP_CHR, TRS.get_char(in_node, "OQC_SAMPLE_FLAG"));
    LOG_add("oqc_sample_rule", MP_CHR, TRS.get_char(in_node, "OQC_SAMPLE_RULE"));
    LOG_add("target_yield", MP_DBL, TRS.get_double(in_node, "TARGET_YIELD"));
    LOG_add("target_due_day", MP_DBL, TRS.get_double(in_node, "TARGET_DUE_DAY"));
    LOG_add("target_qty_1", MP_DBL, TRS.get_double(in_node, "TARGET_QTY_1"));
    LOG_add("target_qty_2", MP_DBL, TRS.get_double(in_node, "TARGET_QTY_2"));
    LOG_add("target_qty_3", MP_DBL, TRS.get_double(in_node, "TARGET_QTY_3"));
    LOG_add("apply_start_time", MP_NSTR, TRS.get_string(in_node, "APPLY_START_TIME"));
    LOG_add("apply_end_time", MP_NSTR, TRS.get_string(in_node, "APPLY_END_TIME"));
    LOG_add("approval_flag", MP_CHR, TRS.get_char(in_node, "APPROVAL_FLAG"));
    LOG_add("release_flag", MP_CHR, TRS.get_char(in_node, "RELEASE_FLAG"));
    LOG_add("deactive_flag", MP_CHR, TRS.get_char(in_node, "DEACTIVE_FLAG"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Update_Inv_Material",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;



    if(TIV_Update_Inv_Material_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
    MTIVMATDEF.MAT_VER  = TRS.get_int(in_node, "MAT_VER");
    DBC_select_mtivmatdef_for_update(1, &MTIVMATDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            if(TRS.get_procstep(in_node) == MP_STEP_UPDATE ||
               TRS.get_procstep(in_node) == MP_STEP_DELETE ||
               TRS.get_procstep(in_node) == MP_STEP_UNDELETE ||
               TRS.get_procstep(in_node) == MP_STEP_VERSION_UP) 
            {
                strcpy(s_msg_code, "WIP-0006");
                TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT FOR UPDATE", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;              
            }
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
    }
    else
    {
        if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
            strcpy(s_msg_code, "WIP-0007");
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
        else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || 
                TRS.get_procstep(in_node) == MP_STEP_DELETE)
        {
            if(MTIVMATDEF.DELETE_FLAG == 'Y')
            {
                strcpy(s_msg_code, "WIP-0276");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;              
            }
        }
        else if(TRS.get_procstep(in_node) == MP_STEP_UNDELETE)
        {
            if(MTIVMATDEF.DELETE_FLAG != 'Y')
            {
                strcpy(s_msg_code, "WIP-0007");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;              
            }
        }
    }

    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
    MTIVMATDEF.MAT_VER  = TRS.get_int(in_node, "MAT_VER");
    TRS.copy(MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC), in_node, "MAT_DESC");
	TRS.copy(MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC), in_node, "MAT_SHORT_DESC");
    TRS.copy(MTIVMATDEF.MAT_TYPE, sizeof(MTIVMATDEF.MAT_TYPE), in_node, "MAT_TYPE");
    TRS.copy(MTIVMATDEF.MAT_GRP_1, sizeof(MTIVMATDEF.MAT_GRP_1), in_node, "MAT_GRP_1");
    TRS.copy(MTIVMATDEF.MAT_GRP_2, sizeof(MTIVMATDEF.MAT_GRP_2), in_node, "MAT_GRP_2");
    TRS.copy(MTIVMATDEF.MAT_GRP_3, sizeof(MTIVMATDEF.MAT_GRP_3), in_node, "MAT_GRP_3");
    TRS.copy(MTIVMATDEF.MAT_GRP_4, sizeof(MTIVMATDEF.MAT_GRP_4), in_node, "MAT_GRP_4");
    TRS.copy(MTIVMATDEF.MAT_GRP_5, sizeof(MTIVMATDEF.MAT_GRP_5), in_node, "MAT_GRP_5");
    TRS.copy(MTIVMATDEF.MAT_GRP_6, sizeof(MTIVMATDEF.MAT_GRP_6), in_node, "MAT_GRP_6");
    TRS.copy(MTIVMATDEF.MAT_GRP_7, sizeof(MTIVMATDEF.MAT_GRP_7), in_node, "MAT_GRP_7");
    TRS.copy(MTIVMATDEF.MAT_GRP_8, sizeof(MTIVMATDEF.MAT_GRP_8), in_node, "MAT_GRP_8");
    TRS.copy(MTIVMATDEF.MAT_GRP_9, sizeof(MTIVMATDEF.MAT_GRP_9), in_node, "MAT_GRP_9");
    TRS.copy(MTIVMATDEF.MAT_GRP_10, sizeof(MTIVMATDEF.MAT_GRP_10), in_node, "MAT_GRP_10");
    TRS.copy(MTIVMATDEF.MAT_CMF_1, sizeof(MTIVMATDEF.MAT_CMF_1), in_node, "MAT_CMF_1");
    TRS.copy(MTIVMATDEF.MAT_CMF_2, sizeof(MTIVMATDEF.MAT_CMF_2), in_node, "MAT_CMF_2");
    TRS.copy(MTIVMATDEF.MAT_CMF_3, sizeof(MTIVMATDEF.MAT_CMF_3), in_node, "MAT_CMF_3");
    TRS.copy(MTIVMATDEF.MAT_CMF_4, sizeof(MTIVMATDEF.MAT_CMF_4), in_node, "MAT_CMF_4");
    TRS.copy(MTIVMATDEF.MAT_CMF_5, sizeof(MTIVMATDEF.MAT_CMF_5), in_node, "MAT_CMF_5");
    TRS.copy(MTIVMATDEF.MAT_CMF_6, sizeof(MTIVMATDEF.MAT_CMF_6), in_node, "MAT_CMF_6");
    TRS.copy(MTIVMATDEF.MAT_CMF_7, sizeof(MTIVMATDEF.MAT_CMF_7), in_node, "MAT_CMF_7");
    TRS.copy(MTIVMATDEF.MAT_CMF_8, sizeof(MTIVMATDEF.MAT_CMF_8), in_node, "MAT_CMF_8");
    TRS.copy(MTIVMATDEF.MAT_CMF_9, sizeof(MTIVMATDEF.MAT_CMF_9), in_node, "MAT_CMF_9");
    TRS.copy(MTIVMATDEF.MAT_CMF_10, sizeof(MTIVMATDEF.MAT_CMF_10), in_node, "MAT_CMF_10");
    TRS.copy(MTIVMATDEF.MAT_CMF_11, sizeof(MTIVMATDEF.MAT_CMF_11), in_node, "MAT_CMF_11");
    TRS.copy(MTIVMATDEF.MAT_CMF_12, sizeof(MTIVMATDEF.MAT_CMF_12), in_node, "MAT_CMF_12");
    TRS.copy(MTIVMATDEF.MAT_CMF_13, sizeof(MTIVMATDEF.MAT_CMF_13), in_node, "MAT_CMF_13");
    TRS.copy(MTIVMATDEF.MAT_CMF_14, sizeof(MTIVMATDEF.MAT_CMF_14), in_node, "MAT_CMF_14");
    TRS.copy(MTIVMATDEF.MAT_CMF_15, sizeof(MTIVMATDEF.MAT_CMF_15), in_node, "MAT_CMF_15");
    TRS.copy(MTIVMATDEF.MAT_CMF_16, sizeof(MTIVMATDEF.MAT_CMF_16), in_node, "MAT_CMF_16");
    TRS.copy(MTIVMATDEF.MAT_CMF_17, sizeof(MTIVMATDEF.MAT_CMF_17), in_node, "MAT_CMF_17");
    TRS.copy(MTIVMATDEF.MAT_CMF_18, sizeof(MTIVMATDEF.MAT_CMF_18), in_node, "MAT_CMF_18");
    TRS.copy(MTIVMATDEF.MAT_CMF_19, sizeof(MTIVMATDEF.MAT_CMF_19), in_node, "MAT_CMF_19");
    TRS.copy(MTIVMATDEF.MAT_CMF_20, sizeof(MTIVMATDEF.MAT_CMF_20), in_node, "MAT_CMF_20");

    TRS.copy(MTIVMATDEF.MFG_DEVISION, sizeof(MTIVMATDEF.MFG_DEVISION), in_node, "MFG_DEVISION");
    MTIVMATDEF.SUBCONTRACT_FLAG  = TRS.get_char(in_node, "SUBCONTRACT_FLAG");

    TRS.copy(MTIVMATDEF.BASE_MAT_ID, sizeof(MTIVMATDEF.BASE_MAT_ID), in_node, "BASE_MAT_ID");

    TRS.copy(MTIVMATDEF.VENDOR_ID, sizeof(MTIVMATDEF.VENDOR_ID), in_node, "VENDOR_ID");
    TRS.copy(MTIVMATDEF.VENDOR_MAT_ID, sizeof(MTIVMATDEF.VENDOR_MAT_ID), in_node, "VENDOR_MAT_ID");

    TRS.copy(MTIVMATDEF.CUSTOMER_ID, sizeof(MTIVMATDEF.CUSTOMER_ID), in_node, "CUSTOMER_ID");
    TRS.copy(MTIVMATDEF.CUSTOMER_MAT_ID, sizeof(MTIVMATDEF.CUSTOMER_MAT_ID), in_node, "CUSTOMER_MAT_ID");

    MTIVMATDEF.DEF_QTY_1  = TRS.get_double(in_node, "DEF_QTY_1");
    MTIVMATDEF.DEF_QTY_2  = TRS.get_double(in_node, "DEF_QTY_2");
    MTIVMATDEF.DEF_QTY_3  = TRS.get_double(in_node, "DEF_QTY_3");

    TRS.copy(MTIVMATDEF.UNIT_1, sizeof(MTIVMATDEF.UNIT_1), in_node, "UNIT1");
    TRS.copy(MTIVMATDEF.UNIT_2, sizeof(MTIVMATDEF.UNIT_2), in_node, "UNIT2");
    TRS.copy(MTIVMATDEF.UNIT_3, sizeof(MTIVMATDEF.UNIT_3), in_node, "UNIT3");

    MTIVMATDEF.WEIGHT_NET  = TRS.get_double(in_node, "WEIGHT_NET");
    MTIVMATDEF.WEIGHT_GROSS  = TRS.get_double(in_node, "WEIGHT_GROSS");
    TRS.copy(MTIVMATDEF.WEIGHT_UNIT, sizeof(MTIVMATDEF.WEIGHT_UNIT), in_node, "WEIGHT_UNIT");

    MTIVMATDEF.VOLUME  = TRS.get_double(in_node, "VOLUME");
    TRS.copy(MTIVMATDEF.VOLUME_UNIT, sizeof(MTIVMATDEF.VOLUME_UNIT), in_node, "VOLUME_UNIT");

    MTIVMATDEF.DIMENSION_HR  = TRS.get_double(in_node, "DIMENSION_HR");
    TRS.copy(MTIVMATDEF.DIMENSION_HR_UNIT, sizeof(MTIVMATDEF.DIMENSION_HR_UNIT), in_node, "DIMENSION_HR_UNIT");
    MTIVMATDEF.DIMENSION_VT  = TRS.get_double(in_node, "DIMENSION_VT");
    TRS.copy(MTIVMATDEF.DIMENSION_VT_UNIT, sizeof(MTIVMATDEF.DIMENSION_VT_UNIT), in_node, "DIMENSION_VT_UNIT");
    MTIVMATDEF.DIMENSION_HT  = TRS.get_double(in_node, "DIMENSION_HT");
    TRS.copy(MTIVMATDEF.DIMENSION_HT_UNIT, sizeof(MTIVMATDEF.DIMENSION_HT_UNIT), in_node, "DIMENSION_HT_UNIT");

    TRS.copy(MTIVMATDEF.BOM_SET_ID, sizeof(MTIVMATDEF.BOM_SET_ID), in_node, "BOM_SET_ID");
    TRS.copy(MTIVMATDEF.DEF_INV_OPER, sizeof(MTIVMATDEF.DEF_INV_OPER), in_node, "DEF_INV_OPER");

    MTIVMATDEF.PACK_TYPE  = TRS.get_char(in_node, "PACK_TYPE");
    MTIVMATDEF.PACK_LOT_COUNT  = TRS.get_int(in_node, "PACK_LOT_COUNT");
    MTIVMATDEF.PACK_QTY  = TRS.get_double(in_node, "PACK_QTY");

    MTIVMATDEF.LE_STOCK_LEVEL  = TRS.get_double(in_node, "LE_STOCK_LEVEL");
    MTIVMATDEF.LW_STOCK_LEVEL  = TRS.get_double(in_node, "LW_STOCK_LEVEL");
    MTIVMATDEF.HE_STOCK_LEVEL  = TRS.get_double(in_node, "HE_STOCK_LEVEL");
    MTIVMATDEF.HW_STOCK_LEVEL  = TRS.get_double(in_node, "HW_STOCK_LEVEL");

    MTIVMATDEF.IQC_FLAG  = TRS.get_char(in_node, "IQC_FLAG");
    MTIVMATDEF.IQC_SAMPLE_FLAG  = TRS.get_char(in_node, "IQC_SAMPLE_FLAG");
    MTIVMATDEF.IQC_SAMPLE_RULE  = TRS.get_char(in_node, "IQC_SAMPLE_RULE");

    MTIVMATDEF.OQC_FLAG  = TRS.get_char(in_node, "OQC_FLAG");
    MTIVMATDEF.OQC_SAMPLE_FLAG  = TRS.get_char(in_node, "OQC_SAMPLE_FLAG");
    MTIVMATDEF.OQC_SAMPLE_RULE  = TRS.get_char(in_node, "OQC_SAMPLE_RULE");

    MTIVMATDEF.TARGET_YIELD  = TRS.get_double(in_node, "TARGET_YIELD");
    MTIVMATDEF.TARGET_DUE_DAY  = TRS.get_double(in_node, "TARGET_DUE_DAY");
    MTIVMATDEF.TARGET_QTY_1  = TRS.get_double(in_node, "TARGET_QTY_1");
    MTIVMATDEF.TARGET_QTY_2  = TRS.get_double(in_node, "TARGET_QTY_2");
    MTIVMATDEF.TARGET_QTY_3  = TRS.get_double(in_node, "TARGET_QTY_3");

    TRS.copy(MTIVMATDEF.APPLY_START_TIME, sizeof(MTIVMATDEF.APPLY_START_TIME), in_node, "APPLY_START_TIME");
    TRS.copy(MTIVMATDEF.APPLY_END_TIME, sizeof(MTIVMATDEF.APPLY_END_TIME), in_node, "APPLY_END_TIME");

    MTIVMATDEF.APPROVAL_FLAG  = TRS.get_char(in_node, "APPROVAL_FLAG");
    if(MTIVMATDEF.APPROVAL_FLAG == 'Y')
    {
        TRS.copy(MTIVMATDEF.APPROVAL_USER_ID, sizeof(MTIVMATDEF.APPROVAL_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.APPROVAL_TIME, s_sys_time, sizeof(MTIVMATDEF.APPROVAL_TIME));
    }
    else
    {
        MTIVMATDEF.APPROVAL_FLAG = ' ';
        memset(MTIVMATDEF.APPROVAL_USER_ID, ' ', sizeof(MTIVMATDEF.APPROVAL_USER_ID));
        memset(MTIVMATDEF.APPROVAL_TIME, ' ', sizeof(MTIVMATDEF.APPROVAL_TIME));
    }

    MTIVMATDEF.RELEASE_FLAG  = TRS.get_char(in_node, "RELEASE_FLAG");
    if(MTIVMATDEF.RELEASE_FLAG == 'Y')
    {
        TRS.copy(MTIVMATDEF.RELEASE_USER_ID, sizeof(MTIVMATDEF.RELEASE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.RELEASE_TIME , s_sys_time, sizeof(MTIVMATDEF.RELEASE_TIME));
    }
    else
    {
        MTIVMATDEF.RELEASE_FLAG = ' ';
        memset(MTIVMATDEF.RELEASE_USER_ID, ' ', sizeof(MTIVMATDEF.RELEASE_USER_ID));
        memset(MTIVMATDEF.RELEASE_TIME, ' ', sizeof(MTIVMATDEF.RELEASE_TIME));
    }

    MTIVMATDEF.DEACTIVE_FLAG  = TRS.get_char(in_node, "DEACTIVE_FLAG");
    if(MTIVMATDEF.DEACTIVE_FLAG == 'Y')
    {
        TRS.copy(MTIVMATDEF.DEACTIVE_USER_ID, sizeof(MTIVMATDEF.DEACTIVE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.DEACTIVE_TIME , s_sys_time, sizeof(MTIVMATDEF.DEACTIVE_TIME));
    }
    else
    {
        MTIVMATDEF.DEACTIVE_FLAG = ' ';
        memset(MTIVMATDEF.DEACTIVE_USER_ID, ' ', sizeof(MTIVMATDEF.DEACTIVE_USER_ID));
        memset(MTIVMATDEF.DEACTIVE_TIME, ' ', sizeof(MTIVMATDEF.DEACTIVE_TIME));
    }

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE) 
    {
        TRS.copy(MTIVMATDEF.CREATE_USER_ID, sizeof(MTIVMATDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.CREATE_TIME, s_sys_time, sizeof(MTIVMATDEF.CREATE_TIME));

        DBC_insert_mtivmatdef(&MTIVMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        TRS.copy(MTIVMATDEF.UPDATE_USER_ID, sizeof(MTIVMATDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.UPDATE_TIME, s_sys_time, sizeof(MTIVMATDEF.UPDATE_TIME));

        DBC_update_mtivmatdef(1, &MTIVMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        MTIVMATDEF.DELETE_FLAG = 'Y';
        TRS.copy(MTIVMATDEF.DELETE_USER_ID, sizeof(MTIVMATDEF.DELETE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.DELETE_TIME, s_sys_time, sizeof(MTIVMATDEF.DELETE_TIME));

        DBC_update_mtivmatdef(2, &MTIVMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UNDELETE)
    {
        MTIVMATDEF.DELETE_FLAG = ' ';
        memset(MTIVMATDEF.DELETE_USER_ID, ' ', sizeof(MTIVMATDEF.DELETE_USER_ID));
        memset(MTIVMATDEF.DELETE_TIME, ' ', sizeof(MTIVMATDEF.DELETE_TIME));

        TRS.copy(MTIVMATDEF.UPDATE_USER_ID, sizeof(MTIVMATDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.UPDATE_TIME, s_sys_time, sizeof(MTIVMATDEF.UPDATE_TIME));

        DBC_update_mtivmatdef(3, &MTIVMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_VERSION_UP) 
    {
        // 현재 Material의 마지막 버전을 가져와서 + 1 시킨다.
        // 삭제된것까지 모두 포함함.
        DBC_init_mtivmatdef(&MTIVMATDEF_T);
        TRS.copy(MTIVMATDEF_T.FACTORY, sizeof(MTIVMATDEF_T.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVMATDEF_T.MAT_ID, sizeof(MTIVMATDEF_T.MAT_ID), in_node, "MAT_ID");
        MTIVMATDEF_T.MAT_VER = (int)DBC_select_mtivmatdef_scalar(2, &MTIVMATDEF_T);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT_SCALAR", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF_T.FACTORY), MTIVMATDEF_T.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF_T.MAT_ID), MTIVMATDEF_T.MAT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
        MTIVMATDEF_T.MAT_VER = MTIVMATDEF_T.MAT_VER + 1;

        // 입력된 메시지 셋의 정보를 가지고 새로운 버전을 생성한다.
        MTIVMATDEF.MAT_VER = MTIVMATDEF_T.MAT_VER;
        TRS.copy(MTIVMATDEF.CREATE_USER_ID, sizeof(MTIVMATDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVMATDEF.CREATE_TIME, s_sys_time, sizeof(MTIVMATDEF.CREATE_TIME));
        memset(MTIVMATDEF.UPDATE_USER_ID, ' ', sizeof(MTIVMATDEF.UPDATE_USER_ID));
        memset(MTIVMATDEF.UPDATE_TIME, ' ', sizeof(MTIVMATDEF.UPDATE_TIME));

        DBC_insert_mtivmatdef(&MTIVMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        // 관련 테이블을 복사한다.
        if(Process_Inv_Material_VersionUp(s_msg_code, 
                                      out_node, 
                                      TRS.get_int(in_node, "MAT_VER"), 
                                      &MTIVMATDEF) == MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        TRS.add_int(out_node, "MAT_VER", MTIVMATDEF.MAT_VER);
    }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_Update_Inv_Material",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Update_Inv_Material_Validation()
        - Validation Check sub function of "WIP_Update_Material" function
        - Check the conditions before Create/Update/Delete Material Definition
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_Inv_Material_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node)
{
    struct MTIVMATDEF_TAG  MTIVMATDEF;
    //Attach가 된 Flow가 있는지 Check하는 로직이 빠졌으므로 불필요
    //struct MWIPMATFLW_TAG  MWIPMATFLW;
    struct MWIPLOTSTS_TAG  MWIPLOTSTS;
#ifdef _BOM
    struct MBOMSETDEF_TAG  MBOMSETDEF;
#endif /* _BOM */
    int i_count;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUDRV") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation   */
    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "MATERIAL_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }
    if(TRS.get_int(in_node, "MAT_VER") < 1) 
    {
        strcpy(s_msg_code, "WIP-0401");
        TRS.add_fieldmsg(out_node, "MATERIAL_VERSION", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    i_count = 0;
    DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
    i_count = (int)DBC_select_mtivmatdef_scalar(1, &MTIVMATDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT_SCALAR", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE && i_count > 0)
    {
        strcpy(s_msg_code, "WIP-0007");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "COUNT", MP_INT, i_count);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
    MTIVMATDEF.MAT_VER  = TRS.get_int(in_node, "MAT_VER");
    DBC_select_mtivmatdef(1, &MTIVMATDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || 
               TRS.get_procstep(in_node) == MP_STEP_DELETE || 
               TRS.get_procstep(in_node) == MP_STEP_UNDELETE ||
               TRS.get_procstep(in_node) == MP_STEP_VERSION_UP) 
            {
                strcpy(s_msg_code, "WIP-0006");
                TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;              
            }
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;              
        }
    }
    else
    {
        if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
            strcpy(s_msg_code, "WIP-0007");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;              
        }
        else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || 
                TRS.get_procstep(in_node) == MP_STEP_DELETE)
        {
            if(MTIVMATDEF.DELETE_FLAG == 'Y')
            {
                strcpy(s_msg_code, "WIP-0276");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;              
            }
        }
        else if(TRS.get_procstep(in_node) == MP_STEP_UNDELETE)
        {
            if(MTIVMATDEF.DELETE_FLAG != 'Y')
            {
                strcpy(s_msg_code, "WIP-0007");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;              
            }
        }
    }    
    if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        /* Undelete 기능으로 Attach 된 Flow가 있는지 Check 불필요 - 그냥 남겨둠
        i_count = 0;
        DBC_init_mwipmatflw(&MWIPMATFLW);
        memcpy(MWIPMATFLW.FACTORY, Update_Material_In->h_factory, sizeof(MWIPMATFLW.FACTORY));
        memcpy(MWIPMATFLW.MAT_ID, Update_Material_In->mat_id, sizeof(MWIPMATFLW.MAT_ID));
        i_count = (int)DBC_select_mwipmatflw_scalar(1, &MWIPMATFLW);   
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPMATFLW SELECT_SCALAR", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATFLW.FACTORY), MWIPMATFLW.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATFLW.MAT_ID), MWIPMATFLW.MAT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
        if(i_count > 0)
        {
            strcpy(s_msg_code, "WIP-0027");
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATFLW.FACTORY), MWIPMATFLW.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATFLW.MAT_ID), MWIPMATFLW.MAT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
        */

        i_count = 0;
        DBC_init_mwiplotsts(&MWIPLOTSTS);
        TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID), in_node, "MAT_ID");
        MWIPLOTSTS.MAT_VER  = TRS.get_int(in_node, "MAT_VER");
        i_count = (int)DBC_select_mwiplotsts_scalar(1, &MWIPLOTSTS);   
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT_SCALAR", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPLOTSTS.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
        if(i_count > 0)
        {
            strcpy(s_msg_code, "WIP-0230");
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPLOTSTS.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }    
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UNDELETE)
    {
    }
    else
    {
        if(COM_isnullspace(TRS.get_string(in_node, "MAT_TYPE")) == MP_TRUE)
        {
            strcpy(s_msg_code, "WIP-0001");
            TRS.add_fieldmsg(out_node, "MAT_TYPE", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }

        if(COM_check_gcm_data(s_msg_code, 
                              out_node,
                              MP_TIV_MATERIAL_TYPE,
                              TRS.get_factory(in_node),
                              TRS.get_string(in_node, "MAT_TYPE"),
                              (int)strlen(TRS.get_string(in_node, "MAT_TYPE"))) == MP_FALSE)
        {
            return MP_FALSE;
        }

        if(COM_isnullspace(TRS.get_string(in_node, "UNIT1")) == MP_TRUE &&
           COM_isnullspace(TRS.get_string(in_node, "UNIT2")) == MP_TRUE &&
           COM_isnullspace(TRS.get_string(in_node, "UNIT3")) == MP_TRUE )
        {
            strcpy(s_msg_code, "WIP-0077");
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }

        if(COM_isnullspace(TRS.get_string(in_node, "UNIT1")) == MP_FALSE)
        {
            if(COM_check_gcm_data(s_msg_code, 
                                    out_node,
                                    MP_INV_UNIT_TABLE,
                                    TRS.get_factory(in_node),
                                    TRS.get_string(in_node, "UNIT1"),
                                    (int)strlen(TRS.get_string(in_node, "UNIT1"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
        if(COM_isnullspace(TRS.get_string(in_node, "UNIT2")) == MP_FALSE)
        {
            if(COM_check_gcm_data(s_msg_code, 
                                    out_node,
                                    MP_INV_UNIT_TABLE,
                                    TRS.get_factory(in_node),
                                    TRS.get_string(in_node, "UNIT2"),
                                    (int)strlen(TRS.get_string(in_node, "UNIT2"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
        if(COM_isnullspace(TRS.get_string(in_node, "UNIT3")) == MP_FALSE)
        {
            if(COM_check_gcm_data(s_msg_code, 
                                    out_node,
                                    MP_INV_UNIT_TABLE,
                                    TRS.get_factory(in_node),
                                    TRS.get_string(in_node, "UNIT3"),
                                    (int)strlen(TRS.get_string(in_node, "UNIT3"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }

        if(TRS.get_char(in_node, "PACK_TYPE") != ' ') 
        {
            char s_temp[2];

            s_temp[0] = TRS.get_char(in_node, "PACK_TYPE");
            s_temp[1] = 0x00;

            if(COM_check_gcm_data(s_msg_code,
                                    out_node,
                                    MP_WIP_MATERIAL_PACKTYPE,
                                    TRS.get_factory(in_node),
                                    s_temp,
                                    1) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }

#ifdef _BOM
        if(COM_isnullspace(TRS.get_string(in_node, "BOM_SET_ID")) == MP_FALSE)
        {
            DBC_init_mbomsetdef(&MBOMSETDEF);
            TRS.copy(MBOMSETDEF.FACTORY, sizeof(MBOMSETDEF.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MBOMSETDEF.BOM_SET_ID, sizeof(MBOMSETDEF.BOM_SET_ID), in_node, "BOM_SET_ID");
            DBC_select_mbomsetdef(1, &MBOMSETDEF);
            if(DB_error_code != DB_SUCCESS) 
            {
                if(DB_error_code == DB_NOT_FOUND) 
                {
                    strcpy(s_msg_code, "BOM-0003");
                    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                }
                else if(DB_error_code != DB_SUCCESS) 
                {
                    strcpy(s_msg_code, "WIP-0004");
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                }
                TRS.add_fieldmsg(out_node, "MBOMSETDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MBOMSETDEF.FACTORY), MBOMSETDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "BOM_SET_ID", MP_STR, sizeof(MBOMSETDEF.BOM_SET_ID), MBOMSETDEF.BOM_SET_ID);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;              
            }
        }
#endif /* _BOM */

       if(TIV_Check_Inv_Material_GRPCMF(s_msg_code, in_node, out_node) == MP_FALSE) 
       {
           return MP_FALSE;
       }
    } 

    return MP_TRUE;
}


/*******************************************************************************
    TIV_Check_Inv_Material_GRPCMF()
        - Check the conditions before Create/Update/Delete Material GRP/CMF Definition
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Check_Inv_Material_GRPCMF(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct check_list s_check_list;

    COM_fill_check_list(&s_check_list, in_node, 10, "MAT_GRP");
    memcpy(s_check_list.list_tbl[0].table_name, MP_GCM_INV_MATERIAL_GRP_1, strlen(MP_GCM_INV_MATERIAL_GRP_1));
    memcpy(s_check_list.list_tbl[1].table_name, MP_GCM_INV_MATERIAL_GRP_2, strlen(MP_GCM_INV_MATERIAL_GRP_2));
    memcpy(s_check_list.list_tbl[2].table_name, MP_GCM_INV_MATERIAL_GRP_3, strlen(MP_GCM_INV_MATERIAL_GRP_3));
    memcpy(s_check_list.list_tbl[3].table_name, MP_GCM_INV_MATERIAL_GRP_4, strlen(MP_GCM_INV_MATERIAL_GRP_4));
    memcpy(s_check_list.list_tbl[4].table_name, MP_GCM_INV_MATERIAL_GRP_5, strlen(MP_GCM_INV_MATERIAL_GRP_5));
    memcpy(s_check_list.list_tbl[5].table_name, MP_GCM_INV_MATERIAL_GRP_6, strlen(MP_GCM_INV_MATERIAL_GRP_6));
    memcpy(s_check_list.list_tbl[6].table_name, MP_GCM_INV_MATERIAL_GRP_7, strlen(MP_GCM_INV_MATERIAL_GRP_7));
    memcpy(s_check_list.list_tbl[7].table_name, MP_GCM_INV_MATERIAL_GRP_8, strlen(MP_GCM_INV_MATERIAL_GRP_8));
    memcpy(s_check_list.list_tbl[8].table_name, MP_GCM_INV_MATERIAL_GRP_9, strlen(MP_GCM_INV_MATERIAL_GRP_9));
    memcpy(s_check_list.list_tbl[9].table_name, MP_GCM_INV_MATERIAL_GRP_10, strlen(MP_GCM_INV_MATERIAL_GRP_10));
    if(COM_check_grp(s_msg_code, 
                     out_node, 
                     MP_GRP_INV_MATERIAL, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* CMF Validation Check */
    COM_fill_check_list(&s_check_list, in_node, 20, "MAT_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_INV_MATERIAL, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

int Process_Inv_Material_VersionUp(char *s_msg_code,
                               TRSNode *out_node,
                               int i_from_ver,
                               struct MTIVMATDEF_TAG *MTIVMATDEF)
{
    struct MWIPRWKDEF_TAG MWIPRWKDEF;   // MFO rework setup
    struct MWIPCYTDEF_TAG MWIPCYTDEF;   // MFO cycle time setup
    struct MWIPSLTDEF_TAG MWIPSLTDEF;   // MFO sublot option setup
    struct MWIPYLDDEF_TAG MWIPYLDDEF;   // MFO yield setup
    struct MWIPCOLDEF_TAG MWIPCOLDEF;   // MFO collection set attach setup
    struct MWIPFATDEF_TAG MWIPFATDEF;   // MFO future action setup
    struct MWIPQTMDEF_TAG MWIPQTMDEF;   // MFO queue time setup
    struct MWIPBAKDEF_TAG MWIPBAKDEF;   // MFO batch keep setup
    struct MWIPGRDDEF_TAG MWIPGRDDEF;   // MFO sublot grade rule setup
    struct MWIPIDGREL_TAG MWIPIDGREL;   // MFO id generation rule relation setup 
    struct MWIPSTPMFO_TAG MWIPSTPMFO;   // MFO step relation setup

    struct MPOPMATLBL_TAG MPOPMATLBL;   // Label material setup
    struct MRCPMFODEF_TAG MRCPMFODEF;   // MFO recipe setup
    struct MALMMFORES_TAG MALMMFORES;   // Attached alarm to MFO
    struct MRASCGRREL_TAG MRASCGRREL;   // Carrier Group Relation
    struct MRASCRRMFO_TAG MRASCRRMFO;   // Carrier MFO Option
    struct MRASRESMFO_TAG MRASRESMFO;   // Resource & Resource Group MFO Relation
    struct MBASSCRREL_TAG MBASSCRREL;   // Screen relation setup

#ifdef _SPM
    struct MSPMRELDEF_TAG MSPMRELDEF;   // Specification setup
#endif
#ifdef _SPC
    struct MSPCCHTMFO_TAG MSPCCHTMFO;   // SPC Chart & MFO relation setup
#endif

    // 각각의 테이블에서 from_version에 해당하는 값을 to_version으로 복사한다.

    /* MWIPRWKDEF ************************************************************************************************/

    DBC_init_mwiprwkdef(&MWIPRWKDEF);
    memcpy(MWIPRWKDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPRWKDEF.FACTORY));
    memcpy(MWIPRWKDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPRWKDEF.MAT_ID));
    MWIPRWKDEF.MAT_VER = i_from_ver;
    DBC_open_mwiprwkdef(5, &MWIPRWKDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPRWKDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPRWKDEF.FACTORY), MWIPRWKDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPRWKDEF.MAT_ID), MWIPRWKDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPRWKDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwiprwkdef(5, &MWIPRWKDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwiprwkdef(5);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPRWKDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPRWKDEF.FACTORY), MWIPRWKDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPRWKDEF.MAT_ID), MWIPRWKDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPRWKDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwiprwkdef(5);
            return MP_FALSE;              
        }

        MWIPRWKDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPRWKDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPRWKDEF.CREATE_TIME));
        memcpy(MWIPRWKDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPRWKDEF.CREATE_USER_ID));
        memcpy(MWIPRWKDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPRWKDEF.UPDATE_TIME));
        memcpy(MWIPRWKDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPRWKDEF.UPDATE_USER_ID));

        DBC_insert_mwiprwkdef(&MWIPRWKDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPRWKDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPRWKDEF.FACTORY), MWIPRWKDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPRWKDEF.MAT_ID), MWIPRWKDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPRWKDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwiprwkdef(5);
            return MP_FALSE;              
        }
    }

    /* MWIPCYTDEF ************************************************************************************************/

    DBC_init_mwipcytdef(&MWIPCYTDEF);
    memcpy(MWIPCYTDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPCYTDEF.FACTORY));
    memcpy(MWIPCYTDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPCYTDEF.MAT_ID));
    MWIPCYTDEF.MAT_VER = i_from_ver;
    DBC_open_mwipcytdef(2, &MWIPCYTDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPCYTDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCYTDEF.FACTORY), MWIPCYTDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPCYTDEF.MAT_ID), MWIPCYTDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPCYTDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipcytdef(2, &MWIPCYTDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipcytdef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPCYTDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCYTDEF.FACTORY), MWIPCYTDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPCYTDEF.MAT_ID), MWIPCYTDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPCYTDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipcytdef(2);
            return MP_FALSE;              
        }

        MWIPCYTDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPCYTDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPCYTDEF.CREATE_TIME));
        memcpy(MWIPCYTDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPCYTDEF.CREATE_USER_ID));
        memcpy(MWIPCYTDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPCYTDEF.UPDATE_TIME));
        memcpy(MWIPCYTDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPCYTDEF.UPDATE_USER_ID));

        DBC_insert_mwipcytdef(&MWIPCYTDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPCYTDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCYTDEF.FACTORY), MWIPCYTDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPCYTDEF.MAT_ID), MWIPCYTDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPCYTDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipcytdef(2);
            return MP_FALSE;              
        }
    }

    /* MWIPSLTDEF ************************************************************************************************/

    DBC_init_mwipsltdef(&MWIPSLTDEF);
    memcpy(MWIPSLTDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPSLTDEF.FACTORY));
    memcpy(MWIPSLTDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPSLTDEF.MAT_ID));
    MWIPSLTDEF.MAT_VER = i_from_ver;
    DBC_open_mwipsltdef(2, &MWIPSLTDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPSLTDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSLTDEF.FACTORY), MWIPSLTDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPSLTDEF.MAT_ID), MWIPSLTDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPSLTDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipsltdef(2, &MWIPSLTDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipsltdef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPSLTDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSLTDEF.FACTORY), MWIPSLTDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPSLTDEF.MAT_ID), MWIPSLTDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPSLTDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipsltdef(2);
            return MP_FALSE;              
        }

        MWIPSLTDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPSLTDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPSLTDEF.CREATE_TIME));
        memcpy(MWIPSLTDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPSLTDEF.CREATE_USER_ID));
        memcpy(MWIPSLTDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPSLTDEF.UPDATE_TIME));
        memcpy(MWIPSLTDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPSLTDEF.UPDATE_USER_ID));

        DBC_insert_mwipsltdef(&MWIPSLTDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPSLTDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSLTDEF.FACTORY), MWIPSLTDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPSLTDEF.MAT_ID), MWIPSLTDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPSLTDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipsltdef(2);
            return MP_FALSE;              
        }
    }

    /* MWIPYLDDEF ************************************************************************************************/

    DBC_init_mwipylddef(&MWIPYLDDEF);
    memcpy(MWIPYLDDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPYLDDEF.FACTORY));
    memcpy(MWIPYLDDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPYLDDEF.MAT_ID));
    MWIPYLDDEF.MAT_VER = i_from_ver;
    DBC_open_mwipylddef(2, &MWIPYLDDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPYLDDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPYLDDEF.FACTORY), MWIPYLDDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPYLDDEF.MAT_ID), MWIPYLDDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPYLDDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipylddef(2, &MWIPYLDDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipylddef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPYLDDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPYLDDEF.FACTORY), MWIPYLDDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPYLDDEF.MAT_ID), MWIPYLDDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPYLDDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipylddef(2);
            return MP_FALSE;              
        }

        MWIPYLDDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPYLDDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPYLDDEF.CREATE_TIME));
        memcpy(MWIPYLDDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPYLDDEF.CREATE_USER_ID));
        memcpy(MWIPYLDDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPYLDDEF.UPDATE_TIME));
        memcpy(MWIPYLDDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPYLDDEF.UPDATE_USER_ID));

        DBC_insert_mwipylddef(&MWIPYLDDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPYLDDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPYLDDEF.FACTORY), MWIPYLDDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPYLDDEF.MAT_ID), MWIPYLDDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPYLDDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipylddef(2);
            return MP_FALSE;              
        }
    }

    /* MWIPCOLDEF ************************************************************************************************/

    DBC_init_mwipcoldef(&MWIPCOLDEF);
    memcpy(MWIPCOLDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPCOLDEF.FACTORY));
    memcpy(MWIPCOLDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPCOLDEF.MAT_ID));
    MWIPCOLDEF.MAT_VER = i_from_ver;
    DBC_open_mwipcoldef(2, &MWIPCOLDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPCOLDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCOLDEF.FACTORY), MWIPCOLDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPCOLDEF.MAT_ID), MWIPCOLDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPCOLDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipcoldef(2, &MWIPCOLDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipcoldef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPCOLDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCOLDEF.FACTORY), MWIPCOLDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPCOLDEF.MAT_ID), MWIPCOLDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPCOLDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipcoldef(2);
            return MP_FALSE;              
        }

        MWIPCOLDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPCOLDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPCOLDEF.CREATE_TIME));
        memcpy(MWIPCOLDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPCOLDEF.CREATE_USER_ID));
        memcpy(MWIPCOLDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPCOLDEF.UPDATE_TIME));
        memcpy(MWIPCOLDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPCOLDEF.UPDATE_USER_ID));

        DBC_insert_mwipcoldef(&MWIPCOLDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPCOLDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPCOLDEF.FACTORY), MWIPCOLDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPCOLDEF.MAT_ID), MWIPCOLDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPCOLDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipcoldef(2);
            return MP_FALSE;              
        }
    }

    /* MWIPFATDEF ************************************************************************************************/

    {
        struct MWIPFATACT_TAG MWIPFATACT;
        struct MWIPFATSVC_TAG MWIPFATSVC;
        struct MWIPFATCND_TAG MWIPFATCND;
        int i_point_seq;
        int i_action_seq;
        char s_point_key[20];
        char s_action_key[20];

        memset(s_point_key, ' ', sizeof(s_point_key));
        memset(s_action_key, ' ', sizeof(s_action_key));

        DBC_init_mwipfatdef(&MWIPFATDEF);
        memcpy(MWIPFATDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPFATDEF.FACTORY));
        memcpy(MWIPFATDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPFATDEF.MAT_ID));
        MWIPFATDEF.MAT_VER = i_from_ver;
        DBC_open_mwipfatdef(3, &MWIPFATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPFATDEF OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFATDEF.FACTORY), MWIPFATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPFATDEF.MAT_ID), MWIPFATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPFATDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;              
        }

        i_point_seq = 0;
        while(1)
        {
            DBC_fetch_mwipfatdef(3, &MWIPFATDEF);
            if(DB_error_code == DB_NOT_FOUND)
            {
                DBC_close_mwipfatdef(3);
                break;
            }
            else if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);
                TRS.add_fieldmsg(out_node, "MWIPFATDEF FETCH", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFATDEF.FACTORY), MWIPFATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPFATDEF.MAT_ID), MWIPFATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPFATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                DBC_close_mwipfatdef(3);
                return MP_FALSE;              
            }

            i_point_seq++;
            memset(s_point_key, ' ', sizeof(s_point_key));
            memcpy(s_point_key, MTIVMATDEF->CREATE_TIME, 14);
            COM_itoa_zero(s_point_key + 14, i_point_seq, 3);


            DBC_init_mwipfatact(&MWIPFATACT);
            memcpy(MWIPFATACT.POINT_KEY, MWIPFATDEF.POINT_KEY, sizeof(MWIPFATACT.POINT_KEY));
            DBC_open_mwipfatact(1, &MWIPFATACT);
            if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);
                TRS.add_fieldmsg(out_node, "MWIPFATACT OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "POINT_KEY", MP_STR, sizeof(MWIPFATACT.POINT_KEY), MWIPFATACT.POINT_KEY);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                DBC_close_mwipfatdef(3);
                return MP_FALSE;              
            }

            i_action_seq = 0;
            while(1)
            {
                DBC_fetch_mwipfatact(1, &MWIPFATACT);
                if(DB_error_code == DB_NOT_FOUND)
                {
                    DBC_close_mwipfatact(1);
                    break;
                }
                else if(DB_error_code != DB_SUCCESS) 
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                    TRS.add_fieldmsg(out_node, "MWIPFATACT FETCH", MP_NVST);
                    TRS.add_fieldmsg(out_node, "POINT_KEY", MP_STR, sizeof(MWIPFATACT.POINT_KEY), MWIPFATACT.POINT_KEY);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_SETUP;

                    DBC_close_mwipfatact(1);
                    DBC_close_mwipfatdef(3);
                    return MP_FALSE;              
                }

                i_action_seq++;
                memset(s_action_key, ' ', sizeof(s_action_key));
                memcpy(s_action_key, s_point_key, 17);
                COM_itoa_zero(s_action_key + 17, i_action_seq, 3);


                DBC_init_mwipfatsvc(&MWIPFATSVC);
                memcpy(MWIPFATSVC.ACTION_KEY, MWIPFATACT.ACTION_KEY, sizeof(MWIPFATSVC.ACTION_KEY));
                DBC_open_mwipfatsvc(1, &MWIPFATSVC);
                if(DB_error_code != DB_SUCCESS) 
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                    TRS.add_fieldmsg(out_node, "MWIPFATSVC OPEN", MP_NVST);
                    TRS.add_fieldmsg(out_node, "ACTION_KEY", MP_STR, sizeof(MWIPFATSVC.ACTION_KEY), MWIPFATSVC.ACTION_KEY);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_SETUP;

                    DBC_close_mwipfatact(1);
                    DBC_close_mwipfatdef(3);
                    return MP_FALSE;              
                }

                while(1)
                {
                    DBC_fetch_mwipfatsvc(1, &MWIPFATSVC);
                    if(DB_error_code == DB_NOT_FOUND)
                    {
                        DBC_close_mwipfatsvc(1);
                        break;
                    }
                    else if(DB_error_code != DB_SUCCESS) 
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_dberrmsg(out_node, DB_error_msg);
                        TRS.add_fieldmsg(out_node, "MWIPFATSVC FETCH", MP_NVST);
                        TRS.add_fieldmsg(out_node, "ACTION_KEY", MP_STR, sizeof(MWIPFATSVC.ACTION_KEY), MWIPFATSVC.ACTION_KEY);

                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_SETUP;

                        DBC_close_mwipfatsvc(1);
                        DBC_close_mwipfatact(1);
                        DBC_close_mwipfatdef(3);
                        return MP_FALSE;              
                    }

                    memcpy(MWIPFATSVC.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPFATSVC.CREATE_TIME));
                    memcpy(MWIPFATSVC.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPFATSVC.CREATE_USER_ID));

                    memcpy(MWIPFATSVC.ACTION_KEY, s_action_key, sizeof(MWIPFATSVC.ACTION_KEY));

                    DBC_insert_mwipfatsvc(&MWIPFATSVC);
                    if(DB_error_code != DB_SUCCESS) 
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_dberrmsg(out_node, DB_error_msg);
                        TRS.add_fieldmsg(out_node, "MWIPFATSVC INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "ACTION_KEY", MP_STR, sizeof(MWIPFATSVC.ACTION_KEY), MWIPFATSVC.ACTION_KEY);

                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_SETUP;

                        DBC_close_mwipfatsvc(1);
                        DBC_close_mwipfatact(1);
                        DBC_close_mwipfatdef(3);
                        return MP_FALSE;              
                    }
                }//end MWIPFATSVC LOOP


                DBC_init_mwipfatcnd(&MWIPFATCND);
                memcpy(MWIPFATCND.ACTION_KEY, MWIPFATACT.ACTION_KEY, sizeof(MWIPFATCND.ACTION_KEY));
                DBC_open_mwipfatcnd(1, &MWIPFATCND);
                if(DB_error_code != DB_SUCCESS) 
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                    TRS.add_fieldmsg(out_node, "MWIPFATCND OPEN", MP_NVST);
                    TRS.add_fieldmsg(out_node, "ACTION_KEY", MP_STR, sizeof(MWIPFATCND.ACTION_KEY), MWIPFATCND.ACTION_KEY);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_SETUP;

                    DBC_close_mwipfatact(1);
                    DBC_close_mwipfatdef(3);
                    return MP_FALSE;              
                }

                while(1)
                {
                    DBC_fetch_mwipfatcnd(1, &MWIPFATCND);
                    if(DB_error_code == DB_NOT_FOUND)
                    {
                        DBC_close_mwipfatcnd(1);
                        break;
                    }
                    else if(DB_error_code != DB_SUCCESS) 
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_dberrmsg(out_node, DB_error_msg);
                        TRS.add_fieldmsg(out_node, "MWIPFATCND FETCH", MP_NVST);
                        TRS.add_fieldmsg(out_node, "ACTION_KEY", MP_STR, sizeof(MWIPFATCND.ACTION_KEY), MWIPFATCND.ACTION_KEY);

                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_SETUP;

                        DBC_close_mwipfatcnd(1);
                        DBC_close_mwipfatact(1);
                        DBC_close_mwipfatdef(3);
                        return MP_FALSE;              
                    }

                    memset(MWIPFATCND.UPDATE_TIME, ' ', sizeof(MWIPFATCND.UPDATE_TIME));
                    memset(MWIPFATCND.UPDATE_USER_ID, ' ', sizeof(MWIPFATCND.UPDATE_USER_ID));

                    memcpy(MWIPFATCND.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPFATCND.CREATE_TIME));
                    memcpy(MWIPFATCND.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPFATCND.CREATE_USER_ID));

                    memcpy(MWIPFATCND.ACTION_KEY, s_action_key, sizeof(MWIPFATCND.ACTION_KEY));

                    DBC_insert_mwipfatcnd(&MWIPFATCND);
                    if(DB_error_code != DB_SUCCESS) 
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_dberrmsg(out_node, DB_error_msg);
                        TRS.add_fieldmsg(out_node, "MWIPFATCND INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "ACTION_KEY", MP_STR, sizeof(MWIPFATCND.ACTION_KEY), MWIPFATCND.ACTION_KEY);

                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_SETUP;

                        DBC_close_mwipfatcnd(1);
                        DBC_close_mwipfatact(1);
                        DBC_close_mwipfatdef(3);
                        return MP_FALSE;              
                    }
                }//end MWIPFATCND LOOP


                memset(MWIPFATACT.UPDATE_TIME, ' ', sizeof(MWIPFATACT.UPDATE_TIME));
                memset(MWIPFATACT.UPDATE_USER_ID, ' ', sizeof(MWIPFATACT.UPDATE_USER_ID));

                memcpy(MWIPFATACT.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPFATACT.CREATE_TIME));
                memcpy(MWIPFATACT.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPFATACT.CREATE_USER_ID));

                memcpy(MWIPFATACT.ACTION_KEY, s_action_key, sizeof(MWIPFATACT.ACTION_KEY));

                DBC_insert_mwipfatact(&MWIPFATACT);
                if(DB_error_code != DB_SUCCESS) 
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                    TRS.add_fieldmsg(out_node, "MWIPFATACT INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "POINT_KEY", MP_STR, sizeof(MWIPFATACT.POINT_KEY), MWIPFATACT.POINT_KEY);
                    TRS.add_fieldmsg(out_node, "ACTION_KEY", MP_STR, sizeof(MWIPFATACT.ACTION_KEY), MWIPFATACT.ACTION_KEY);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_SETUP;

                    DBC_close_mwipfatact(1);
                    DBC_close_mwipfatdef(3);
                    return MP_FALSE;              
                }
            }//end MWIPFATACT LOOP


            MWIPFATDEF.MAT_VER = MTIVMATDEF->MAT_VER;
            memcpy(MWIPFATDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPFATDEF.CREATE_TIME));
            memcpy(MWIPFATDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPFATDEF.CREATE_USER_ID));

            memcpy(MWIPFATDEF.POINT_KEY, s_point_key, sizeof(MWIPFATDEF.POINT_KEY));

            DBC_insert_mwipfatdef(&MWIPFATDEF);
            if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);
                TRS.add_fieldmsg(out_node, "MWIPFATDEF INSERT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFATDEF.FACTORY), MWIPFATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPFATDEF.MAT_ID), MWIPFATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPFATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                DBC_close_mwipfatdef(3);
                return MP_FALSE;              
            }
        }//end MWIPFATDEF LOOP
    }

    /* MWIPQTMDEF ************************************************************************************************/

    DBC_init_mwipqtmdef(&MWIPQTMDEF);
    memcpy(MWIPQTMDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPQTMDEF.FACTORY));
    memcpy(MWIPQTMDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPQTMDEF.MAT_ID));
    MWIPQTMDEF.MAT_VER = i_from_ver;
    DBC_open_mwipqtmdef(3, &MWIPQTMDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPQTMDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPQTMDEF.FACTORY), MWIPQTMDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPQTMDEF.MAT_ID), MWIPQTMDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPQTMDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipqtmdef(3, &MWIPQTMDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipqtmdef(3);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPQTMDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPQTMDEF.FACTORY), MWIPQTMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPQTMDEF.MAT_ID), MWIPQTMDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPQTMDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipqtmdef(3);
            return MP_FALSE;              
        }

        MWIPQTMDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPQTMDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPQTMDEF.CREATE_TIME));
        memcpy(MWIPQTMDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPQTMDEF.CREATE_USER_ID));
        memcpy(MWIPQTMDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPQTMDEF.UPDATE_TIME));
        memcpy(MWIPQTMDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPQTMDEF.UPDATE_USER_ID));

        DBC_insert_mwipqtmdef(&MWIPQTMDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPQTMDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPQTMDEF.FACTORY), MWIPQTMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPQTMDEF.MAT_ID), MWIPQTMDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPQTMDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipqtmdef(3);
            return MP_FALSE;              
        }
    }

    /* MWIPBAKDEF ************************************************************************************************/

    DBC_init_mwipbakdef(&MWIPBAKDEF);
    memcpy(MWIPBAKDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPBAKDEF.FACTORY));
    memcpy(MWIPBAKDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPBAKDEF.MAT_ID));
    MWIPBAKDEF.MAT_VER = i_from_ver;
    DBC_open_mwipbakdef(2, &MWIPBAKDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPBAKDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPBAKDEF.FACTORY), MWIPBAKDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPBAKDEF.MAT_ID), MWIPBAKDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPBAKDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipbakdef(2, &MWIPBAKDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipbakdef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPBAKDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPBAKDEF.FACTORY), MWIPBAKDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPBAKDEF.MAT_ID), MWIPBAKDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPBAKDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipbakdef(2);
            return MP_FALSE;              
        }

        MWIPBAKDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPBAKDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPBAKDEF.CREATE_TIME));
        memcpy(MWIPBAKDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPBAKDEF.CREATE_USER_ID));
        memcpy(MWIPBAKDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPBAKDEF.UPDATE_TIME));
        memcpy(MWIPBAKDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPBAKDEF.UPDATE_USER_ID));

        DBC_insert_mwipbakdef(&MWIPBAKDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPBAKDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPBAKDEF.FACTORY), MWIPBAKDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPBAKDEF.MAT_ID), MWIPBAKDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPBAKDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipbakdef(2);
            return MP_FALSE;              
        }
    }

    /* MWIPGRDDEF ************************************************************************************************/

    DBC_init_mwipgrddef(&MWIPGRDDEF);
    memcpy(MWIPGRDDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPGRDDEF.FACTORY));
    memcpy(MWIPGRDDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPGRDDEF.MAT_ID));
    MWIPGRDDEF.MAT_VER = i_from_ver;
    DBC_open_mwipgrddef(2, &MWIPGRDDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPGRDDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPGRDDEF.FACTORY), MWIPGRDDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPGRDDEF.MAT_ID), MWIPGRDDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPGRDDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipgrddef(2, &MWIPGRDDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipgrddef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPGRDDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPGRDDEF.FACTORY), MWIPGRDDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPGRDDEF.MAT_ID), MWIPGRDDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPGRDDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipgrddef(2);
            return MP_FALSE;              
        }

        MWIPGRDDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPGRDDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPGRDDEF.CREATE_TIME));
        memcpy(MWIPGRDDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPGRDDEF.CREATE_USER_ID));

        DBC_insert_mwipgrddef(&MWIPGRDDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPGRDDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPGRDDEF.FACTORY), MWIPGRDDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPGRDDEF.MAT_ID), MWIPGRDDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPGRDDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipgrddef(2);
            return MP_FALSE;              
        }
    }
    

    /* MWIPIDGREL ************************************************************************************************/

    DBC_init_mwipidgrel(&MWIPIDGREL);
    memcpy(MWIPIDGREL.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPIDGREL.FACTORY));
    memcpy(MWIPIDGREL.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPIDGREL.MAT_ID));
    MWIPIDGREL.MAT_VER = i_from_ver;
    DBC_open_mwipidgrel(3, &MWIPIDGREL);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPIDGREL OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPIDGREL.FACTORY), MWIPIDGREL.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPIDGREL.MAT_ID), MWIPIDGREL.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPIDGREL.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipidgrel(3, &MWIPIDGREL);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipidgrel(3);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPIDGREL FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPIDGREL.FACTORY), MWIPIDGREL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPIDGREL.MAT_ID), MWIPIDGREL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPIDGREL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipidgrel(3);
            return MP_FALSE;              
        }

        MWIPIDGREL.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPIDGREL.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPIDGREL.CREATE_TIME));
        memcpy(MWIPIDGREL.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPIDGREL.CREATE_USER_ID));
        memcpy(MWIPIDGREL.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPIDGREL.UPDATE_TIME));
        memcpy(MWIPIDGREL.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPIDGREL.UPDATE_USER_ID));

        DBC_insert_mwipidgrel(&MWIPIDGREL);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPIDGREL INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPIDGREL.FACTORY), MWIPIDGREL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPIDGREL.MAT_ID), MWIPIDGREL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPIDGREL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipidgrel(3);
            return MP_FALSE;              
        }
    }

    /* MWIPSTPMFO ************************************************************************************************/

    DBC_init_mwipstpmfo(&MWIPSTPMFO);
    memcpy(MWIPSTPMFO.FACTORY, MTIVMATDEF->FACTORY, sizeof(MWIPSTPMFO.FACTORY));
    memcpy(MWIPSTPMFO.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MWIPSTPMFO.MAT_ID));
    MWIPSTPMFO.MAT_VER = i_from_ver;
    DBC_open_mwipstpmfo(7, &MWIPSTPMFO);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MWIPSTPMFO OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSTPMFO.FACTORY), MWIPSTPMFO.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPSTPMFO.MAT_ID), MWIPSTPMFO.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPSTPMFO.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mwipstpmfo(7, &MWIPSTPMFO);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipstpmfo(7);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPSTPMFO FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSTPMFO.FACTORY), MWIPSTPMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPSTPMFO.MAT_ID), MWIPSTPMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPSTPMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipstpmfo(7);
            return MP_FALSE;              
        }

        MWIPSTPMFO.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MWIPSTPMFO.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MWIPSTPMFO.CREATE_TIME));
        memcpy(MWIPSTPMFO.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MWIPSTPMFO.CREATE_USER_ID));
        memcpy(MWIPSTPMFO.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MWIPSTPMFO.UPDATE_TIME));
        memcpy(MWIPSTPMFO.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MWIPSTPMFO.UPDATE_USER_ID));

        DBC_insert_mwipstpmfo(&MWIPSTPMFO);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MWIPSTPMFO INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPSTPMFO.FACTORY), MWIPSTPMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPSTPMFO.MAT_ID), MWIPSTPMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPSTPMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwipstpmfo(7);
            return MP_FALSE;              
        }
    }

    /* MPOPMATLBL ************************************************************************************************/

    DBC_init_mpopmatlbl(&MPOPMATLBL);
    memcpy(MPOPMATLBL.FACTORY, MTIVMATDEF->FACTORY, sizeof(MPOPMATLBL.FACTORY));
    memcpy(MPOPMATLBL.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MPOPMATLBL.MAT_ID));
    MPOPMATLBL.MAT_VER = i_from_ver;
    DBC_open_mpopmatlbl(2, &MPOPMATLBL);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MPOPMATLBL OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MPOPMATLBL.FACTORY), MPOPMATLBL.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MPOPMATLBL.MAT_ID), MPOPMATLBL.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MPOPMATLBL.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mpopmatlbl(2, &MPOPMATLBL);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mpopmatlbl(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MPOPMATLBL FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MPOPMATLBL.FACTORY), MPOPMATLBL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MPOPMATLBL.MAT_ID), MPOPMATLBL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MPOPMATLBL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mpopmatlbl(2);
            return MP_FALSE;              
        }

        MPOPMATLBL.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MPOPMATLBL.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MPOPMATLBL.CREATE_TIME));
        memcpy(MPOPMATLBL.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MPOPMATLBL.CREATE_USER_ID));
        memcpy(MPOPMATLBL.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MPOPMATLBL.UPDATE_TIME));
        memcpy(MPOPMATLBL.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MPOPMATLBL.UPDATE_USER_ID));

        DBC_insert_mpopmatlbl(&MPOPMATLBL);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MPOPMATLBL INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MPOPMATLBL.FACTORY), MPOPMATLBL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MPOPMATLBL.MAT_ID), MPOPMATLBL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MPOPMATLBL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mpopmatlbl(2);
            return MP_FALSE;              
        }
    }

    /* MRCPMFODEF ************************************************************************************************/

    DBC_init_mrcpmfodef(&MRCPMFODEF);
    memcpy(MRCPMFODEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MRCPMFODEF.FACTORY));
    memcpy(MRCPMFODEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MRCPMFODEF.MAT_ID));
    MRCPMFODEF.MAT_VER = i_from_ver;
    DBC_open_mrcpmfodef(2, &MRCPMFODEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MRCPMFODEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPMFODEF.FACTORY), MRCPMFODEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRCPMFODEF.MAT_ID), MRCPMFODEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRCPMFODEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mrcpmfodef(2, &MRCPMFODEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mrcpmfodef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRCPMFODEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPMFODEF.FACTORY), MRCPMFODEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRCPMFODEF.MAT_ID), MRCPMFODEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRCPMFODEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrcpmfodef(2);
            return MP_FALSE;              
        }

        MRCPMFODEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MRCPMFODEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MRCPMFODEF.CREATE_TIME));
        memcpy(MRCPMFODEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MRCPMFODEF.CREATE_USER_ID));
        memcpy(MRCPMFODEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MRCPMFODEF.UPDATE_TIME));
        memcpy(MRCPMFODEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MRCPMFODEF.UPDATE_USER_ID));

        DBC_insert_mrcpmfodef(&MRCPMFODEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRCPMFODEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPMFODEF.FACTORY), MRCPMFODEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRCPMFODEF.MAT_ID), MRCPMFODEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRCPMFODEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrcpmfodef(2);
            return MP_FALSE;              
        }
    }

    /* MALMMFORES ************************************************************************************************/

    DBC_init_malmmfores(&MALMMFORES);
    memcpy(MALMMFORES.FACTORY, MTIVMATDEF->FACTORY, sizeof(MALMMFORES.FACTORY));
    memcpy(MALMMFORES.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MALMMFORES.MAT_ID));
    MALMMFORES.MAT_VER = i_from_ver;
    DBC_open_malmmfores(4, &MALMMFORES);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MALMMFORES OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MALMMFORES.FACTORY), MALMMFORES.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MALMMFORES.MAT_ID), MALMMFORES.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MALMMFORES.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_malmmfores(4, &MALMMFORES);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_malmmfores(4);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MALMMFORES FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MALMMFORES.FACTORY), MALMMFORES.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MALMMFORES.MAT_ID), MALMMFORES.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MALMMFORES.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_malmmfores(4);
            return MP_FALSE;              
        }

        MALMMFORES.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MALMMFORES.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MALMMFORES.CREATE_TIME));
        memcpy(MALMMFORES.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MALMMFORES.CREATE_USER_ID));
        memcpy(MALMMFORES.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MALMMFORES.UPDATE_TIME));
        memcpy(MALMMFORES.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MALMMFORES.UPDATE_USER_ID));

        DBC_insert_malmmfores(&MALMMFORES);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MALMMFORES INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MALMMFORES.FACTORY), MALMMFORES.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MALMMFORES.MAT_ID), MALMMFORES.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MALMMFORES.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_malmmfores(4);
            return MP_FALSE;              
        }
    }

    /* MRASCGRREL ************************************************************************************************/

    DBC_init_mrascgrrel(&MRASCGRREL);
    memcpy(MRASCGRREL.FACTORY, MTIVMATDEF->FACTORY, sizeof(MRASCGRREL.FACTORY));
    memcpy(MRASCGRREL.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MRASCGRREL.MAT_ID));
    MRASCGRREL.MAT_VER = i_from_ver;
    DBC_open_mrascgrrel(3, &MRASCGRREL);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MRASCGRREL OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCGRREL.FACTORY), MRASCGRREL.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASCGRREL.MAT_ID), MRASCGRREL.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASCGRREL.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mrascgrrel(3, &MRASCGRREL);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mrascgrrel(3);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRASCGRREL FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCGRREL.FACTORY), MRASCGRREL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASCGRREL.MAT_ID), MRASCGRREL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASCGRREL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrascgrrel(3);
            return MP_FALSE;              
        }

        MRASCGRREL.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MRASCGRREL.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MRASCGRREL.CREATE_TIME));
        memcpy(MRASCGRREL.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MRASCGRREL.CREATE_USER_ID));
        memcpy(MRASCGRREL.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MRASCGRREL.UPDATE_TIME));
        memcpy(MRASCGRREL.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MRASCGRREL.UPDATE_USER_ID));

        DBC_insert_mrascgrrel(&MRASCGRREL);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRASCGRREL INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCGRREL.FACTORY), MRASCGRREL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASCGRREL.MAT_ID), MRASCGRREL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASCGRREL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrascgrrel(3);
            return MP_FALSE;              
        }
    }

    /* MRASCRRMFO ************************************************************************************************/

    DBC_init_mrascrrmfo(&MRASCRRMFO);
    memcpy(MRASCRRMFO.FACTORY, MTIVMATDEF->FACTORY, sizeof(MRASCRRMFO.FACTORY));
    memcpy(MRASCRRMFO.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MRASCRRMFO.MAT_ID));
    MRASCRRMFO.MAT_VER = i_from_ver;
    DBC_open_mrascrrmfo(2, &MRASCRRMFO);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MRASCRRMFO OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCRRMFO.FACTORY), MRASCRRMFO.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASCRRMFO.MAT_ID), MRASCRRMFO.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASCRRMFO.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mrascrrmfo(2, &MRASCRRMFO);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mrascrrmfo(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRASCRRMFO FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCRRMFO.FACTORY), MRASCRRMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASCRRMFO.MAT_ID), MRASCRRMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASCRRMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrascrrmfo(2);
            return MP_FALSE;              
        }

        MRASCRRMFO.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MRASCRRMFO.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MRASCRRMFO.CREATE_TIME));
        memcpy(MRASCRRMFO.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MRASCRRMFO.CREATE_USER_ID));
        memcpy(MRASCRRMFO.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MRASCRRMFO.UPDATE_TIME));
        memcpy(MRASCRRMFO.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MRASCRRMFO.UPDATE_USER_ID));

        DBC_insert_mrascrrmfo(&MRASCRRMFO);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRASCRRMFO INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCRRMFO.FACTORY), MRASCRRMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASCRRMFO.MAT_ID), MRASCRRMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASCRRMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrascrrmfo(2);
            return MP_FALSE;              
        }
    }

    /* MRASRESMFO ************************************************************************************************/

    DBC_init_mrasresmfo(&MRASRESMFO);
    memcpy(MRASRESMFO.FACTORY, MTIVMATDEF->FACTORY, sizeof(MRASRESMFO.FACTORY));
    memcpy(MRASRESMFO.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MRASRESMFO.MAT_ID));
    MRASRESMFO.MAT_VER = i_from_ver;
    DBC_open_mrasresmfo(5, &MRASRESMFO);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MRASRESMFO OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESMFO.FACTORY), MRASRESMFO.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASRESMFO.MAT_ID), MRASRESMFO.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASRESMFO.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mrasresmfo(5, &MRASRESMFO);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mrasresmfo(5);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRASRESMFO FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESMFO.FACTORY), MRASRESMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASRESMFO.MAT_ID), MRASRESMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASRESMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrasresmfo(5);
            return MP_FALSE;              
        }

        MRASRESMFO.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MRASRESMFO.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MRASRESMFO.CREATE_TIME));
        memcpy(MRASRESMFO.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MRASRESMFO.CREATE_USER_ID));
        memcpy(MRASRESMFO.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MRASRESMFO.UPDATE_TIME));
        memcpy(MRASRESMFO.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MRASRESMFO.UPDATE_USER_ID));

        DBC_insert_mrasresmfo(&MRASRESMFO);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MRASRESMFO INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESMFO.FACTORY), MRASRESMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MRASRESMFO.MAT_ID), MRASRESMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MRASRESMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrasresmfo(5);
            return MP_FALSE;              
        }
    }

    /* MBASSCRREL ************************************************************************************************/

    DBC_init_mbasscrrel(&MBASSCRREL);
    memcpy(MBASSCRREL.FACTORY, MTIVMATDEF->FACTORY, sizeof(MBASSCRREL.FACTORY));
    memcpy(MBASSCRREL.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MBASSCRREL.MAT_ID));
    MBASSCRREL.MAT_VER = i_from_ver;
    DBC_open_mbasscrrel(4, &MBASSCRREL);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MBASSCRREL OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MBASSCRREL.FACTORY), MBASSCRREL.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MBASSCRREL.MAT_ID), MBASSCRREL.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MBASSCRREL.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mbasscrrel(4, &MBASSCRREL);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mbasscrrel(4);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MBASSCRREL FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MBASSCRREL.FACTORY), MBASSCRREL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MBASSCRREL.MAT_ID), MBASSCRREL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MBASSCRREL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mbasscrrel(4);
            return MP_FALSE;              
        }

        MBASSCRREL.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MBASSCRREL.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MBASSCRREL.CREATE_TIME));
        memcpy(MBASSCRREL.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MBASSCRREL.CREATE_USER_ID));
        memcpy(MBASSCRREL.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MBASSCRREL.UPDATE_TIME));
        memcpy(MBASSCRREL.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MBASSCRREL.UPDATE_USER_ID));

        DBC_insert_mbasscrrel(&MBASSCRREL);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MBASSCRREL INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MBASSCRREL.FACTORY), MBASSCRREL.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MBASSCRREL.MAT_ID), MBASSCRREL.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MBASSCRREL.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mbasscrrel(4);
            return MP_FALSE;              
        }
    }

#ifdef _SPM
    /* MSPMRELDEF ************************************************************************************************/

    DBC_init_mspmreldef(&MSPMRELDEF);
    memcpy(MSPMRELDEF.FACTORY, MTIVMATDEF->FACTORY, sizeof(MSPMRELDEF.FACTORY));
    memcpy(MSPMRELDEF.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MSPMRELDEF.MAT_ID));
    MSPMRELDEF.MAT_VER = i_from_ver;
    DBC_open_mspmreldef(5, &MSPMRELDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MSPMRELDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSPMRELDEF.FACTORY), MSPMRELDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MSPMRELDEF.MAT_ID), MSPMRELDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MSPMRELDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mspmreldef(5, &MSPMRELDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mspmreldef(5);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MSPMRELDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSPMRELDEF.FACTORY), MSPMRELDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MSPMRELDEF.MAT_ID), MSPMRELDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MSPMRELDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mspmreldef(5);
            return MP_FALSE;              
        }

        MSPMRELDEF.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MSPMRELDEF.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MSPMRELDEF.CREATE_TIME));
        memcpy(MSPMRELDEF.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MSPMRELDEF.CREATE_USER_ID));
        memcpy(MSPMRELDEF.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MSPMRELDEF.UPDATE_TIME));
        memcpy(MSPMRELDEF.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MSPMRELDEF.UPDATE_USER_ID));

        DBC_insert_mspmreldef(&MSPMRELDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MSPMRELDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSPMRELDEF.FACTORY), MSPMRELDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MSPMRELDEF.MAT_ID), MSPMRELDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MSPMRELDEF.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mspmreldef(5);
            return MP_FALSE;              
        }
    }
#endif

#ifdef _SPC
    /* MSPCCHTMFO ************************************************************************************************/

    DBC_init_mspcchtmfo(&MSPCCHTMFO);
    memcpy(MSPCCHTMFO.FACTORY, MTIVMATDEF->FACTORY, sizeof(MSPCCHTMFO.FACTORY));
    memcpy(MSPCCHTMFO.MAT_ID, MTIVMATDEF->MAT_ID, sizeof(MSPCCHTMFO.MAT_ID));
    MSPCCHTMFO.MAT_VER = i_from_ver;
    DBC_open_mspcchtmfo(2, &MSPCCHTMFO);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MSPCCHTMFO OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSPCCHTMFO.FACTORY), MSPCCHTMFO.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MSPCCHTMFO.MAT_ID), MSPCCHTMFO.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MSPCCHTMFO.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mspcchtmfo(2, &MSPCCHTMFO);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mspcchtmfo(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MSPCCHTMFO FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSPCCHTMFO.FACTORY), MSPCCHTMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MSPCCHTMFO.MAT_ID), MSPCCHTMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MSPCCHTMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mspcchtmfo(2);
            return MP_FALSE;              
        }

        MSPCCHTMFO.MAT_VER = MTIVMATDEF->MAT_VER;
        memcpy(MSPCCHTMFO.CREATE_TIME, MTIVMATDEF->CREATE_TIME, sizeof(MSPCCHTMFO.CREATE_TIME));
        memcpy(MSPCCHTMFO.CREATE_USER_ID, MTIVMATDEF->CREATE_USER_ID, sizeof(MSPCCHTMFO.CREATE_USER_ID));
        memcpy(MSPCCHTMFO.UPDATE_TIME, MTIVMATDEF->UPDATE_TIME, sizeof(MSPCCHTMFO.UPDATE_TIME));
        memcpy(MSPCCHTMFO.UPDATE_USER_ID, MTIVMATDEF->UPDATE_USER_ID, sizeof(MSPCCHTMFO.UPDATE_USER_ID));

        DBC_insert_mspcchtmfo(&MSPCCHTMFO);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "MSPCCHTMFO INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSPCCHTMFO.FACTORY), MSPCCHTMFO.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MSPCCHTMFO.MAT_ID), MSPCCHTMFO.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MSPCCHTMFO.MAT_VER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mspcchtmfo(2);
            return MP_FALSE;              
        }
    }

#endif

    return MP_TRUE;
}

