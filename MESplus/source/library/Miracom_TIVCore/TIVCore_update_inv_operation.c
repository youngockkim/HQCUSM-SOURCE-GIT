/******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : INVCore_update_inv_operation.c.c
    Description : Operation Setup function module

    MES Version : 4.0.0

    Function List
        - TIV_Update_Inv_Operation()
            + Create/Update/Delete Operation definition
        - TIV_UPDATE_TIV_OPERATION()
            + Main sub function of "TIV_Update_Inv_Operation" function
            + Create/Update/Delete Operation definition
        - TIV_Update_Inv_Operation_Validation()
            + Main sub function of "TIV_UPDATE_TIV_OPERATION" function
            + Check the condition for create/update/delete Operation
        - TIV_Check_Inv_Operation_GRPCMF()
            + Main sub function of "TIV_Update_Inv_Operation_Validation" function
            + Check the Group/Cmf Field condition for create/update Operation

    Detail Description
        - TIV_UPDATE_TIV_OPERATION() 
            + h_proc_step
                + MP_STEP_CREATE : Create Operation definition
                + MP_STEP_UPDATE : Update Operation definition
                + MP_STEP_DELETE : Delete Operation definition

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/01  Laverwon       Create

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "WIPCore_common.h"
#include "TIVCore_common.h"

int TIV_Update_Inv_Operation_Validation(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node);

int TIV_Check_Inv_Operation_GRPCMF(char *s_msg_code,
                               TRSNode *in_node,
                               TRSNode *out_node);

/*******************************************************************************
    TIV_Update_Inv_Operation()
        - Create/Update/Delete Operation definition 
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_Inv_Operation(TRSNode *in_node,
                         TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_UPDATE_INV_OPERATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_UPDATE_TIV_OPERATION", out_node);

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
    TIV_UPDATE_TIV_OPERATION()
        - Main sub function of "TIV_Update_Inv_Operation" function
        - Create/Update/Delete Operation definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_UPDATE_INV_OPERATION(char *s_msg_code,
                              TRSNode *in_node,
                              TRSNode *out_node)
{
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF_o;


    LOG_head("TIV_Update_Inv_Operation");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("oper_desc", MP_NSTR, TRS.get_string(in_node, "OPER_DESC"));
	LOG_add("oper_short_desc", MP_NSTR, TRS.get_string(in_node, "OPER_SHORT_DESC"));
    LOG_add("oper_grp_1", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_1"));
    LOG_add("oper_grp_2", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_2"));
    LOG_add("oper_grp_3", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_3"));
    LOG_add("oper_grp_4", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_4"));
    LOG_add("oper_grp_5", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_5"));
    LOG_add("oper_grp_6", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_6"));
    LOG_add("oper_grp_7", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_7"));
    LOG_add("oper_grp_8", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_8"));
    LOG_add("oper_grp_9", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_9"));
    LOG_add("oper_grp_10", MP_NSTR, TRS.get_string(in_node, "OPER_GRP_10"));
    LOG_add("oper_cmf_1", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_1"));
    LOG_add("oper_cmf_2", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_2"));
    LOG_add("oper_cmf_3", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_3"));
    LOG_add("oper_cmf_4", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_4"));
    LOG_add("oper_cmf_5", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_5"));
    LOG_add("oper_cmf_6", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_6"));
    LOG_add("oper_cmf_7", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_7"));
    LOG_add("oper_cmf_8", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_8"));
    LOG_add("oper_cmf_9", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_9"));
    LOG_add("oper_cmf_10", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_10"));
    LOG_add("oper_cmf_11", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_11"));
    LOG_add("oper_cmf_12", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_12"));
    LOG_add("oper_cmf_13", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_13"));
    LOG_add("oper_cmf_14", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_14"));
    LOG_add("oper_cmf_15", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_15"));
    LOG_add("oper_cmf_16", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_16"));
    LOG_add("oper_cmf_17", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_17"));
    LOG_add("oper_cmf_18", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_18"));
    LOG_add("oper_cmf_19", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_19"));
    LOG_add("oper_cmf_20", MP_NSTR, TRS.get_string(in_node, "OPER_CMF_20"));
    LOG_add("unit_1", MP_NSTR, TRS.get_string(in_node, "UNIT_1"));
    LOG_add("unit_2", MP_NSTR, TRS.get_string(in_node, "UNIT_2"));
    LOG_add("unit_3", MP_NSTR, TRS.get_string(in_node, "UNIT_3"));
    LOG_add("transit_flag", MP_CHR, TRS.get_char(in_node, "TRANSIT_FLAG"));
    LOG_add("ship_flag", MP_CHR, TRS.get_char(in_node, "SHIP_FLAG"));
    LOG_add("inv_flag", MP_CHR, TRS.get_char(in_node, "TIV_FLAG"));
    LOG_add("erp_flag", MP_CHR, TRS.get_char(in_node, "ERP_FLAG"));
    LOG_add("start_require_flag", MP_CHR, TRS.get_char(in_node, "START_REQUIRE_FLAG"));
    LOG_add("end_oper_flag", MP_CHR, TRS.get_char(in_node, "END_OPER_FLAG"));
    LOG_add("push_pull_flag", MP_CHR, TRS.get_char(in_node, "PUSH_PULL_FLAG"));
    LOG_add("bonus_tbl", MP_NSTR, TRS.get_string(in_node, "BONUS_TBL"));
    LOG_add("loss_tbl", MP_NSTR, TRS.get_string(in_node, "LOSS_TBL"));
    LOG_add("rework_tbl", MP_NSTR, TRS.get_string(in_node, "REWORK_TBL"));
    LOG_add("sec_chk_flag", MP_CHR, TRS.get_char(in_node, "SEC_CHK_FLAG"));
    LOG_add("area_id", MP_NSTR, TRS.get_string(in_node, "AREA_ID"));
    LOG_add("sub_area_id", MP_NSTR, TRS.get_string(in_node, "SUB_AREA_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Update_Inv_Operation",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    if(TIV_Update_Inv_Operation_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    { 
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivoprdef(&MTIVOPRDEF);
    TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "OPER");
    TRS.copy(MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC), in_node, "OPER_DESC");
	TRS.copy(MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC), in_node, "OPER_SHORT_DESC");
    TRS.copy(MTIVOPRDEF.OPER_GRP_1, sizeof(MTIVOPRDEF.OPER_GRP_1), in_node, "OPER_GRP_1");
    TRS.copy(MTIVOPRDEF.OPER_GRP_2, sizeof(MTIVOPRDEF.OPER_GRP_2), in_node, "OPER_GRP_2");
    TRS.copy(MTIVOPRDEF.OPER_GRP_3, sizeof(MTIVOPRDEF.OPER_GRP_3), in_node, "OPER_GRP_3");
    TRS.copy(MTIVOPRDEF.OPER_GRP_4, sizeof(MTIVOPRDEF.OPER_GRP_4), in_node, "OPER_GRP_4");
    TRS.copy(MTIVOPRDEF.OPER_GRP_5, sizeof(MTIVOPRDEF.OPER_GRP_5), in_node, "OPER_GRP_5");
    TRS.copy(MTIVOPRDEF.OPER_GRP_6, sizeof(MTIVOPRDEF.OPER_GRP_6), in_node, "OPER_GRP_6");
    TRS.copy(MTIVOPRDEF.OPER_GRP_7, sizeof(MTIVOPRDEF.OPER_GRP_7), in_node, "OPER_GRP_7");
    TRS.copy(MTIVOPRDEF.OPER_GRP_8, sizeof(MTIVOPRDEF.OPER_GRP_8), in_node, "OPER_GRP_8");
    TRS.copy(MTIVOPRDEF.OPER_GRP_9, sizeof(MTIVOPRDEF.OPER_GRP_9), in_node, "OPER_GRP_9");
    TRS.copy(MTIVOPRDEF.OPER_GRP_10, sizeof(MTIVOPRDEF.OPER_GRP_10), in_node, "OPER_GRP_10");
    TRS.copy(MTIVOPRDEF.OPER_CMF_1, sizeof(MTIVOPRDEF.OPER_CMF_1), in_node, "OPER_CMF_1");
    TRS.copy(MTIVOPRDEF.OPER_CMF_2, sizeof(MTIVOPRDEF.OPER_CMF_2), in_node, "OPER_CMF_2");
    TRS.copy(MTIVOPRDEF.OPER_CMF_3, sizeof(MTIVOPRDEF.OPER_CMF_3), in_node, "OPER_CMF_3");
    TRS.copy(MTIVOPRDEF.OPER_CMF_4, sizeof(MTIVOPRDEF.OPER_CMF_4), in_node, "OPER_CMF_4");
    TRS.copy(MTIVOPRDEF.OPER_CMF_5, sizeof(MTIVOPRDEF.OPER_CMF_5), in_node, "OPER_CMF_5");
    TRS.copy(MTIVOPRDEF.OPER_CMF_6, sizeof(MTIVOPRDEF.OPER_CMF_6), in_node, "OPER_CMF_6");
    TRS.copy(MTIVOPRDEF.OPER_CMF_7, sizeof(MTIVOPRDEF.OPER_CMF_7), in_node, "OPER_CMF_7");
    TRS.copy(MTIVOPRDEF.OPER_CMF_8, sizeof(MTIVOPRDEF.OPER_CMF_8), in_node, "OPER_CMF_8");
    TRS.copy(MTIVOPRDEF.OPER_CMF_9, sizeof(MTIVOPRDEF.OPER_CMF_9), in_node, "OPER_CMF_9");
    TRS.copy(MTIVOPRDEF.OPER_CMF_10, sizeof(MTIVOPRDEF.OPER_CMF_10), in_node, "OPER_CMF_10");
    TRS.copy(MTIVOPRDEF.OPER_CMF_11, sizeof(MTIVOPRDEF.OPER_CMF_11), in_node, "OPER_CMF_11");
    TRS.copy(MTIVOPRDEF.OPER_CMF_12, sizeof(MTIVOPRDEF.OPER_CMF_12), in_node, "OPER_CMF_12");
    TRS.copy(MTIVOPRDEF.OPER_CMF_13, sizeof(MTIVOPRDEF.OPER_CMF_13), in_node, "OPER_CMF_13");
    TRS.copy(MTIVOPRDEF.OPER_CMF_14, sizeof(MTIVOPRDEF.OPER_CMF_14), in_node, "OPER_CMF_14");
    TRS.copy(MTIVOPRDEF.OPER_CMF_15, sizeof(MTIVOPRDEF.OPER_CMF_15), in_node, "OPER_CMF_15");
    TRS.copy(MTIVOPRDEF.OPER_CMF_16, sizeof(MTIVOPRDEF.OPER_CMF_16), in_node, "OPER_CMF_16");
    TRS.copy(MTIVOPRDEF.OPER_CMF_17, sizeof(MTIVOPRDEF.OPER_CMF_17), in_node, "OPER_CMF_17");
    TRS.copy(MTIVOPRDEF.OPER_CMF_18, sizeof(MTIVOPRDEF.OPER_CMF_18), in_node, "OPER_CMF_18");
    TRS.copy(MTIVOPRDEF.OPER_CMF_19, sizeof(MTIVOPRDEF.OPER_CMF_19), in_node, "OPER_CMF_19");
    //Modify by J.S bug fix CMF20이 CMF10으로 잘못되어 있었음
    TRS.copy(MTIVOPRDEF.OPER_CMF_20, sizeof(MTIVOPRDEF.OPER_CMF_10), in_node, "OPER_CMF_20");
    TRS.copy(MTIVOPRDEF.UNIT_1, sizeof(MTIVOPRDEF.UNIT_1), in_node, "UNIT_1");
    TRS.copy(MTIVOPRDEF.UNIT_2, sizeof(MTIVOPRDEF.UNIT_2), in_node, "UNIT_2");
    TRS.copy(MTIVOPRDEF.UNIT_3, sizeof(MTIVOPRDEF.UNIT_3), in_node, "UNIT_3");
    MTIVOPRDEF.TRANSIT_FLAG  = TRS.get_char(in_node, "TRANSIT_FLAG");
    MTIVOPRDEF.SHIP_FLAG  = TRS.get_char(in_node, "SHIP_FLAG");
    MTIVOPRDEF.INV_FLAG  = TRS.get_char(in_node, "TIV_FLAG");
    MTIVOPRDEF.ERP_FLAG  = TRS.get_char(in_node, "ERP_FLAG");
    MTIVOPRDEF.START_REQUIRE_FLAG  = TRS.get_char(in_node, "START_REQUIRE_FLAG");
    MTIVOPRDEF.END_OPER_FLAG  = TRS.get_char(in_node, "END_OPER_FLAG");
    MTIVOPRDEF.PUSH_PULL_FLAG  = TRS.get_char(in_node, "PUSH_PULL_FLAG");
    TRS.copy(MTIVOPRDEF.LOSS_TBL, sizeof(MTIVOPRDEF.LOSS_TBL), in_node, "LOSS_TBL");
    TRS.copy(MTIVOPRDEF.BONUS_TBL, sizeof(MTIVOPRDEF.BONUS_TBL), in_node, "BONUS_TBL");
    TRS.copy(MTIVOPRDEF.REWORK_TBL, sizeof(MTIVOPRDEF.REWORK_TBL), in_node, "REWORK_TBL");
    MTIVOPRDEF.SEC_CHK_FLAG  = TRS.get_char(in_node, "SEC_CHK_FLAG");
    TRS.copy(MTIVOPRDEF.AREA_ID, sizeof(MTIVOPRDEF.AREA_ID), in_node, "AREA_ID");
    TRS.copy(MTIVOPRDEF.SUB_AREA_ID, sizeof(MTIVOPRDEF.SUB_AREA_ID), in_node, "SUB_AREA_ID");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE) 
    {
        TRS.copy(MTIVOPRDEF.CREATE_USER_ID, sizeof(MTIVOPRDEF.CREATE_USER_ID), in_node, IN_USERID);
        DB_get_systime(MTIVOPRDEF.CREATE_TIME);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        DBC_insert_mtivoprdef(&MTIVOPRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);
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
        DBC_init_mtivoprdef(&MTIVOPRDEF_o);
        TRS.copy(MTIVOPRDEF_o.FACTORY, sizeof(MTIVOPRDEF_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVOPRDEF_o.OPER, sizeof(MTIVOPRDEF_o.OPER), in_node, "OPER");
        DBC_select_mtivoprdef_for_update(1, &MTIVOPRDEF_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF_o.FACTORY), MTIVOPRDEF_o.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF_o.OPER), MTIVOPRDEF_o.OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        memcpy(MTIVOPRDEF.CREATE_USER_ID, MTIVOPRDEF_o.CREATE_USER_ID, sizeof(MTIVOPRDEF.CREATE_USER_ID));
        memcpy(MTIVOPRDEF.CREATE_TIME, MTIVOPRDEF_o.CREATE_TIME, sizeof(MTIVOPRDEF.CREATE_TIME));
        TRS.copy(MTIVOPRDEF.UPDATE_USER_ID, sizeof(MTIVOPRDEF.UPDATE_USER_ID), in_node, IN_USERID);
        DB_get_systime(MTIVOPRDEF.UPDATE_TIME);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        DBC_update_mtivoprdef(1, &MTIVOPRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);
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
        DBC_delete_mtivoprdef(1, &MTIVOPRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* 추가로 지워져야 할 부분 */

    }

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Update_Inv_Operation",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_Update_Inv_Operation_Validation()
        - Main sub function of "TIV_UPDATE_TIV_OPERATION" function
        - Check the condition for create/update/delete Operation
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_Inv_Operation_Validation(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node)
{
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    //struct MWIPFLWOPR_TAG MWIPFLWOPR;
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MGCMTBLDEF_TAG MGCMTBLDEF;
    int i_count = 0;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }
    else
    {
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
    }

    /* Operation Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "OPER")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "OPER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mtivoprdef(&MTIVOPRDEF);

    TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "OPER");
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        DBC_select_mtivoprdef(1, &MTIVOPRDEF);
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0011");
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE ||
            TRS.get_procstep(in_node) == MP_STEP_DELETE) 
    {
        DBC_select_mtivoprdef(1, &MTIVOPRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0010");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    DBC_init_mwiplotsts(&MWIPLOTSTS);

    /* Delete가 아닌 경우 조건 체크 후 return MP_TRUE */
    /* Delete의 경우 Delete 가능한 조건인지 체크 후 return MP_TRUE */
    if(TRS.get_procstep(in_node) != MP_STEP_DELETE)
    {
        /* Update Case Condition Check */
        if(TRS.get_procstep(in_node) == MP_STEP_UPDATE) 
        {
            /* Transit flag : ' ' --> 'Y'로 바뀌는 경우 flow에 붙어 있는지 check */
            if(MTIVOPRDEF.TRANSIT_FLAG == ' ' && TRS.get_char(in_node, "TRANSIT_FLAG") == 'Y')
            {
               
            }

            /* WIP이 존재하는지 Check */
            if((MTIVOPRDEF.TRANSIT_FLAG == ' ' && TRS.get_char(in_node, "TRANSIT_FLAG") == 'Y') ||
               (MTIVOPRDEF.TRANSIT_FLAG == 'Y' && TRS.get_char(in_node, "TRANSIT_FLAG") == ' '))
            {
                DBC_init_mwiplotsts(&MWIPLOTSTS);
                i_count = 0;
                TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
                TRS.copy(MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER), in_node, "OPER");
                i_count = (int)DBC_select_mwiplotsts_scalar(3, &MWIPLOTSTS);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
                    TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
                    TRS.add_dberrmsg(out_node, DB_error_msg);


                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_SETUP;
                    return MP_FALSE;
                }
                if(i_count > 0) 
                {
                    strcpy(s_msg_code, "WIP-0249");
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
                    TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                    gs_log_type.category = MP_LOG_CATE_SETUP;
                    return MP_FALSE;
                }
            }
        }

        if(TRS.get_char(in_node, "TRANSIT_FLAG") == 'Y') 
        {
            if(TRS.get_char(in_node, "SHIP_FLAG") == 'Y' ||
               TRS.get_char(in_node, "START_REQUIRE_FLAG") == 'Y' ||
               TRS.get_char(in_node, "END_OPER_FLAG") == 'Y' ||
               TRS.get_char(in_node, "TIV_FLAG") == 'Y')
            {
                strcpy(s_msg_code, "WIP-0248");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;
            }
        }

        if(COM_isnullspace(TRS.get_string(in_node, "UNIT_1")) == MP_TRUE &&
           COM_isnullspace(TRS.get_string(in_node, "UNIT_2")) == MP_TRUE &&
           COM_isnullspace(TRS.get_string(in_node, "UNIT_3")) == MP_TRUE)
        {
            strcpy(s_msg_code, "WIP-0077");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
        if(COM_isnullspace(TRS.get_string(in_node, "UNIT_1")) == MP_FALSE)
        {
            if(COM_check_gcm_data(s_msg_code, 
                                  out_node,
                                  MP_INV_UNIT_TABLE,
                                  TRS.get_factory(in_node),
                                  TRS.get_string(in_node, "UNIT_1"),
                                  (int)strlen(TRS.get_string(in_node, "UNIT_1"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
        if(COM_isnullspace(TRS.get_string(in_node, "UNIT_2")) == MP_FALSE)
        {
            if(COM_check_gcm_data(s_msg_code, 
                                  out_node,
                                  MP_INV_UNIT_TABLE,
                                  TRS.get_factory(in_node),
                                  TRS.get_string(in_node, "UNIT_2"),
                                  (int)strlen(TRS.get_string(in_node, "UNIT_2"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
        if(COM_isnullspace(TRS.get_string(in_node, "UNIT_3")) == MP_FALSE)
        {
            if(COM_check_gcm_data(s_msg_code, 
                                  out_node,
                                  MP_INV_UNIT_TABLE,
                                  TRS.get_factory(in_node),
                                  TRS.get_string(in_node, "UNIT_3"),
                                  (int)strlen(TRS.get_string(in_node, "UNIT_3"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
        if(COM_isnullspace(TRS.get_string(in_node, "AREA_ID")) == MP_FALSE)
        {
            if(COM_check_gcm_data(s_msg_code, 
                                  out_node,
                                  MP_RAS_AREA_CODE,
                                  TRS.get_factory(in_node),
                                  TRS.get_string(in_node, "AREA_ID"),
                                  (int)strlen(TRS.get_string(in_node, "AREA_ID"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
        if(COM_isnullspace(TRS.get_string(in_node, "SUB_AREA_ID")) == MP_FALSE)
        {
            //Modify by J.S. 2008.12.23 for check area, subarea relatationship
            if(COM_isnullspace(TRS.get_string(in_node, "AREA_ID")) == MP_FALSE)
            {
                if(COM_check_gcm_data_area(s_msg_code, 
                                        out_node,
                                        MP_RAS_SUBAREA_CODE,
                                        TRS.get_factory(in_node),
                                        TRS.get_string(in_node, "SUB_AREA_ID"),
                                        (int)strlen(TRS.get_string(in_node, "SUB_AREA_ID")),
                                        TRS.get_string(in_node, "AREA_ID"),
                                        (int)strlen(TRS.get_string(in_node, "AREA_ID"))) == MP_FALSE)
                {
                    return MP_FALSE;
                }
            }
            else
            {
                if(COM_check_gcm_data(s_msg_code, 
                                      out_node,
                                      MP_RAS_SUBAREA_CODE,
                                      TRS.get_factory(in_node),
                                      TRS.get_string(in_node, "SUB_AREA_ID"),
                                      (int)strlen(TRS.get_string(in_node, "SUB_AREA_ID"))) == MP_FALSE)
                {
                    return MP_FALSE;
                }
            }
        }

        DBC_init_mgcmtbldef(&MGCMTBLDEF);
        if(COM_isnullspace(TRS.get_string(in_node, "LOSS_TBL")) == MP_FALSE)
        {
            TRS.copy(MGCMTBLDEF.FACTORY, sizeof(MGCMTBLDEF.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MGCMTBLDEF.TABLE_NAME, sizeof(MGCMTBLDEF.TABLE_NAME), in_node, "LOSS_TBL");
            DBC_select_mgcmtbldef(1, &MGCMTBLDEF);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "WIP-0025");
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                }
                else
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                }

                TRS.add_fieldmsg(out_node, "MGCMTBLDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;               
            }
        }
        DBC_init_mgcmtbldef(&MGCMTBLDEF);
        if(COM_isnullspace(TRS.get_string(in_node, "BONUS_TBL")) == MP_FALSE)
        {
            TRS.copy(MGCMTBLDEF.FACTORY, sizeof(MGCMTBLDEF.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MGCMTBLDEF.TABLE_NAME, sizeof(MGCMTBLDEF.TABLE_NAME), in_node, "BONUS_TBL");
            DBC_select_mgcmtbldef(1, &MGCMTBLDEF);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "WIP-0025");
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                }
                else
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                }
                TRS.add_fieldmsg(out_node, "MGCMTBLDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;               
            }
        }
        DBC_init_mgcmtbldef(&MGCMTBLDEF);
        if(COM_isnullspace(TRS.get_string(in_node, "REWORK_TBL")) == MP_FALSE)
        {
            TRS.copy(MGCMTBLDEF.FACTORY, sizeof(MGCMTBLDEF.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MGCMTBLDEF.TABLE_NAME, sizeof(MGCMTBLDEF.TABLE_NAME), in_node, "REWORK_TBL");
            DBC_select_mgcmtbldef(1, &MGCMTBLDEF);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "WIP-0025");
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                }
                else
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                }
                TRS.add_fieldmsg(out_node, "MGCMTBLDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDEF.FACTORY), MGCMTBLDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDEF.TABLE_NAME), MGCMTBLDEF.TABLE_NAME);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_SETUP;
                return MP_FALSE;               
            }
        }

        if(TIV_Check_Inv_Operation_GRPCMF(s_msg_code, in_node, out_node) == MP_FALSE) 
        { 
            return MP_FALSE;
        }

        return MP_TRUE;
    }


    DBC_init_mwiplotsts(&MWIPLOTSTS);
    i_count = 0;
    TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER), in_node, "OPER");
    i_count = (int)DBC_select_mwiplotsts_scalar(3, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);
        TRS.add_dberrmsg(out_node, DB_error_msg);


        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }
    if(i_count > 0) 
    {
        strcpy(s_msg_code, "WIP-0245");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPLOTSTS.OPER), MWIPLOTSTS.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    if(COM_check_use_mfo_id(s_msg_code,
                            out_node,
                            'O',
                            MWIPLOTSTS.FACTORY,
                            MWIPLOTSTS.OPER,
                            sizeof(MWIPLOTSTS.OPER),
                            0) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}


/*******************************************************************************
    TIV_Check_Inv_Operation_GRPCMF()
        - Main sub function of "TIV_Update_Inv_Operation_Validation" function
        - Check the Group/Cmf Field condition for create/update operation
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Check_Inv_Operation_GRPCMF(char *s_msg_code,
                               TRSNode *in_node,
                               TRSNode *out_node)
{
    struct check_list s_check_list;

    COM_fill_check_list(&s_check_list, in_node, 10, "OPER_GRP");
    memcpy(s_check_list.list_tbl[0].table_name, MP_GCM_OPER_GRP_1, strlen(MP_GCM_OPER_GRP_1));
    memcpy(s_check_list.list_tbl[1].table_name, MP_GCM_OPER_GRP_2, strlen(MP_GCM_OPER_GRP_2));
    memcpy(s_check_list.list_tbl[2].table_name, MP_GCM_OPER_GRP_3, strlen(MP_GCM_OPER_GRP_3));
    memcpy(s_check_list.list_tbl[3].table_name, MP_GCM_OPER_GRP_4, strlen(MP_GCM_OPER_GRP_4));
    memcpy(s_check_list.list_tbl[4].table_name, MP_GCM_OPER_GRP_5, strlen(MP_GCM_OPER_GRP_5));
    memcpy(s_check_list.list_tbl[5].table_name, MP_GCM_OPER_GRP_6, strlen(MP_GCM_OPER_GRP_6));
    memcpy(s_check_list.list_tbl[6].table_name, MP_GCM_OPER_GRP_7, strlen(MP_GCM_OPER_GRP_7));
    memcpy(s_check_list.list_tbl[7].table_name, MP_GCM_OPER_GRP_8, strlen(MP_GCM_OPER_GRP_8));
    memcpy(s_check_list.list_tbl[8].table_name, MP_GCM_OPER_GRP_9, strlen(MP_GCM_OPER_GRP_9));
    memcpy(s_check_list.list_tbl[9].table_name, MP_GCM_OPER_GRP_10, strlen(MP_GCM_OPER_GRP_10));
    if(COM_check_grp(s_msg_code, 
                     out_node, 
                     MP_GRP_INV_OPERATION, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* CMF Validation Check */
    COM_fill_check_list(&s_check_list, in_node, 20, "OPER_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_INV_OPERATION, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}

