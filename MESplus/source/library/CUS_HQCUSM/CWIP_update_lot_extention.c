/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_lot_extention.c
    Description : lot_extention Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_lot_extention()
            + Create/Update/Delete lot_extention definition
        - CWIP_UPDATE_LOT_EXTENTION()
            + Main sub function of CWIP_Update_lot_extention function
            + Create/Update/Delete lot_extention definition
        - CWIP_Update_lot_extention_Validation()
            + Main sub function of CWIP_UPDATE_LOT_EXTENTION function
            + Check the condition for create/update/delete lot_extention
    Detail Description
        - CWIP_UPDATE_LOT_EXTENTION()
            + h_proc_step
                + MP_STEP_CREATE : Create lot_extention definition
                + MP_STEP_UPDATE : Update lot_extention definition
                + MP_STEP_DELETE : Delete lot_extention definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-05-19             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_lot_extention_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_lot_extention()
        - Create/Update/Delete lot_extention definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_lot_extention(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_LOT_EXTENTION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_LOT_EXTENTION", out_node);

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
    CWIP_UPDATE_LOT_EXTENTION()
        - Main sub function of "CWIP_Update_lot_extention" function
        - Create/Update/Delete lot_extention definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_LOT_EXTENTION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTEXT_TAG CWIPLOTEXT;
    struct CWIPLOTEXT_TAG CWIPLOTEXT_o;
    char   s_sys_time[14];

    LOG_head("CWIP_UPDATE_LOT_EXTENTION");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
    LOG_add("cmf_11", MP_NSTR, TRS.get_string(in_node, "CMF_11"));
    LOG_add("cmf_12", MP_NSTR, TRS.get_string(in_node, "CMF_12"));
    LOG_add("cmf_13", MP_NSTR, TRS.get_string(in_node, "CMF_13"));
    LOG_add("cmf_14", MP_NSTR, TRS.get_string(in_node, "CMF_14"));
    LOG_add("cmf_15", MP_NSTR, TRS.get_string(in_node, "CMF_15"));
    LOG_add("cmf_16", MP_NSTR, TRS.get_string(in_node, "CMF_16"));
    LOG_add("cmf_17", MP_NSTR, TRS.get_string(in_node, "CMF_17"));
    LOG_add("cmf_18", MP_NSTR, TRS.get_string(in_node, "CMF_18"));
    LOG_add("cmf_19", MP_NSTR, TRS.get_string(in_node, "CMF_19"));
    LOG_add("cmf_20", MP_NSTR, TRS.get_string(in_node, "CMF_20"));
    LOG_add("cmf_21", MP_NSTR, TRS.get_string(in_node, "CMF_21"));
    LOG_add("cmf_22", MP_NSTR, TRS.get_string(in_node, "CMF_22"));
    LOG_add("cmf_23", MP_NSTR, TRS.get_string(in_node, "CMF_23"));
    LOG_add("cmf_24", MP_NSTR, TRS.get_string(in_node, "CMF_24"));
    LOG_add("cmf_25", MP_NSTR, TRS.get_string(in_node, "CMF_25"));
    LOG_add("cmf_26", MP_NSTR, TRS.get_string(in_node, "CMF_26"));
    LOG_add("cmf_27", MP_NSTR, TRS.get_string(in_node, "CMF_27"));
    LOG_add("cmf_28", MP_NSTR, TRS.get_string(in_node, "CMF_28"));
    LOG_add("cmf_29", MP_NSTR, TRS.get_string(in_node, "CMF_29"));
    LOG_add("cmf_30", MP_NSTR, TRS.get_string(in_node, "CMF_30"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_lot_extention",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(CWIP_Update_lot_extention_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplotext(&CWIPLOTEXT);
    TRS.copy(CWIPLOTEXT.LOT_ID, sizeof(CWIPLOTEXT.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPLOTEXT.CMF_4, sizeof(CWIPLOTEXT.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPLOTEXT.CMF_5, sizeof(CWIPLOTEXT.CMF_5), in_node, "CMF_5");
    TRS.copy(CWIPLOTEXT.CMF_6, sizeof(CWIPLOTEXT.CMF_6), in_node, "CMF_6");
    TRS.copy(CWIPLOTEXT.CMF_7, sizeof(CWIPLOTEXT.CMF_7), in_node, "CMF_7");
    TRS.copy(CWIPLOTEXT.CMF_8, sizeof(CWIPLOTEXT.CMF_8), in_node, "CMF_8");
    TRS.copy(CWIPLOTEXT.CMF_9, sizeof(CWIPLOTEXT.CMF_9), in_node, "CMF_9");
    TRS.copy(CWIPLOTEXT.CMF_10, sizeof(CWIPLOTEXT.CMF_10), in_node, "CMF_10");
    TRS.copy(CWIPLOTEXT.CMF_11, sizeof(CWIPLOTEXT.CMF_11), in_node, "CMF_11");
    TRS.copy(CWIPLOTEXT.CMF_12, sizeof(CWIPLOTEXT.CMF_12), in_node, "CMF_12");
    TRS.copy(CWIPLOTEXT.CMF_13, sizeof(CWIPLOTEXT.CMF_13), in_node, "CMF_13");
    TRS.copy(CWIPLOTEXT.CMF_14, sizeof(CWIPLOTEXT.CMF_14), in_node, "CMF_14");
    TRS.copy(CWIPLOTEXT.CMF_15, sizeof(CWIPLOTEXT.CMF_15), in_node, "CMF_15");
    TRS.copy(CWIPLOTEXT.CMF_16, sizeof(CWIPLOTEXT.CMF_16), in_node, "CMF_16");
    TRS.copy(CWIPLOTEXT.CMF_17, sizeof(CWIPLOTEXT.CMF_17), in_node, "CMF_17");
    TRS.copy(CWIPLOTEXT.CMF_18, sizeof(CWIPLOTEXT.CMF_18), in_node, "CMF_18");
    TRS.copy(CWIPLOTEXT.CMF_19, sizeof(CWIPLOTEXT.CMF_19), in_node, "CMF_19");
    TRS.copy(CWIPLOTEXT.CMF_20, sizeof(CWIPLOTEXT.CMF_20), in_node, "CMF_20");
    TRS.copy(CWIPLOTEXT.CMF_21, sizeof(CWIPLOTEXT.CMF_21), in_node, "CMF_21");
    TRS.copy(CWIPLOTEXT.CMF_22, sizeof(CWIPLOTEXT.CMF_22), in_node, "CMF_22");
    TRS.copy(CWIPLOTEXT.CMF_23, sizeof(CWIPLOTEXT.CMF_23), in_node, "CMF_23");
    TRS.copy(CWIPLOTEXT.CMF_24, sizeof(CWIPLOTEXT.CMF_24), in_node, "CMF_24");
    TRS.copy(CWIPLOTEXT.CMF_25, sizeof(CWIPLOTEXT.CMF_25), in_node, "CMF_25");
    TRS.copy(CWIPLOTEXT.CMF_26, sizeof(CWIPLOTEXT.CMF_26), in_node, "CMF_26");
    TRS.copy(CWIPLOTEXT.CMF_27, sizeof(CWIPLOTEXT.CMF_27), in_node, "CMF_27");
    TRS.copy(CWIPLOTEXT.CMF_28, sizeof(CWIPLOTEXT.CMF_28), in_node, "CMF_28");
    TRS.copy(CWIPLOTEXT.CMF_29, sizeof(CWIPLOTEXT.CMF_29), in_node, "CMF_29");
    TRS.copy(CWIPLOTEXT.CMF_30, sizeof(CWIPLOTEXT.CMF_30), in_node, "CMF_30");
    TRS.copy(CWIPLOTEXT.CREATE_USER_ID, sizeof(CWIPLOTEXT.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPLOTEXT.CREATE_TIME, sizeof(CWIPLOTEXT.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPLOTEXT.UPDATE_USER_ID, sizeof(CWIPLOTEXT.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPLOTEXT.UPDATE_TIME, sizeof(CWIPLOTEXT.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CWIPLOTEXT.CREATE_USER_ID, sizeof(CWIPLOTEXT.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPLOTEXT.CREATE_TIME, s_sys_time, sizeof(CWIPLOTEXT.CREATE_TIME));
        CDB_insert_cwiplotext(&CWIPLOTEXT);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTEXT INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTEXT.LOT_ID), CWIPLOTEXT.LOT_ID);
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
        CDB_init_cwiplotext(&CWIPLOTEXT_o);
        TRS.copy(CWIPLOTEXT_o.LOT_ID, sizeof(CWIPLOTEXT_o.LOT_ID), in_node, "LOT_ID");
        CDB_select_cwiplotext_for_update(1, &CWIPLOTEXT_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTEXT SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTEXT_o.LOT_ID), CWIPLOTEXT_o.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CWIPLOTEXT.CREATE_USER_ID, CWIPLOTEXT_o.CREATE_USER_ID, sizeof(CWIPLOTEXT.CREATE_USER_ID));
        memcpy(CWIPLOTEXT.CREATE_TIME, CWIPLOTEXT_o.CREATE_TIME, sizeof(CWIPLOTEXT.CREATE_TIME));
        TRS.copy(CWIPLOTEXT.UPDATE_USER_ID, sizeof(CWIPLOTEXT.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPLOTEXT.UPDATE_TIME, s_sys_time, sizeof(CWIPLOTEXT.UPDATE_TIME));

        CDB_update_cwiplotext(1, &CWIPLOTEXT);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTEXT UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTEXT.LOT_ID), CWIPLOTEXT.LOT_ID);
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
        CDB_delete_cwiplotext(1, &CWIPLOTEXT);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTEXT DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTEXT.LOT_ID), CWIPLOTEXT.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_lot_extention",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_lot_extention_Validation()
        - Main sub function of "CWIP_UPDATE_LOT_EXTENTION" function
        - Check the condition for create/update/delete lot_extention
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_lot_extention_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTEXT_TAG CWIPLOTEXT;
    struct MWIPFACDEF_TAG MWIPFACDEF;

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
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
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

    /* LOT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplotext(&CWIPLOTEXT);
    TRS.copy(CWIPLOTEXT.LOT_ID, sizeof(CWIPLOTEXT.LOT_ID), in_node, "LOT_ID");
    CDB_select_cwiplotext(1, &CWIPLOTEXT);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-XXXX");
            TRS.add_fieldmsg(out_node, "CWIPLOTEXT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTEXT.LOT_ID), CWIPLOTEXT.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "CWIP-XXXX");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CWIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CWIPLOTEXT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTEXT.LOT_ID), CWIPLOTEXT.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

