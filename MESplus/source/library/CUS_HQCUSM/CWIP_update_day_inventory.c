/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_day_inventory.c
    Description : Day_Inventory Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Day_Inventory()
            + Create/Update/Delete Day_Inventory definition
        - CWIP_UPDATE_DAY_INVENTORY()
            + Main sub function of CWIP_Update_Day_Inventory function
            + Create/Update/Delete Day_Inventory definition
        - CWIP_Update_Day_Inventory_Validation()
            + Main sub function of CWIP_UPDATE_DAY_INVENTORY function
            + Check the condition for create/update/delete Day_Inventory
    Detail Description
        - CWIP_UPDATE_DAY_INVENTORY()
            + h_proc_step
                + MP_STEP_CREATE : Create Day_Inventory definition
                + MP_STEP_UPDATE : Update Day_Inventory definition
                + MP_STEP_DELETE : Delete Day_Inventory definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2024-04-13             Create by Generator

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Day_Inventory_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Day_Inventory()
        - Create/Update/Delete Day_Inventory definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Day_Inventory(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG+1];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG+1);

    i_ret = CWIP_UPDATE_DAY_INVENTORY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_DAY_INVENTORY", out_node);

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
    CWIP_UPDATE_DAY_INVENTORY()
        - Main sub function of "CWIP_Update_Day_Inventory" function
        - Create/Update/Delete Day_Inventory definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_DAY_INVENTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPDAYINV_TAG CWIPDAYINV;
	struct MWIPMATDEF_TAG MWIPMATDEF;
    struct CWIPDAYINV_TAG CWIPDAYINV_o;
    char   s_sys_time[14]; 

    LOG_head("CWIP_UPDATE_DAY_INVENTORY");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("invt_seq", MP_INT, TRS.get_int(in_node, "INVT_SEQ"));
    LOG_add("oper_type", MP_NSTR, TRS.get_string(in_node, "OPER_TYPE"));
    LOG_add("oper_name", MP_NSTR, TRS.get_string(in_node, "OPER_NAME"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
	LOG_add("mat_qty", MP_INT, TRS.get_double(in_node, "MAT_QTY"));
    LOG_add("batch_no", MP_NSTR, TRS.get_string(in_node, "BATCH_NO"));
    LOG_add("tran_time", MP_NSTR, TRS.get_string(in_node, "TRAN_TIME"));
    LOG_add("invt_brcd", MP_NSTR, TRS.get_string(in_node, "INVT_BRCD"));
    LOG_add("invt_msgs", MP_NSTR, TRS.get_string(in_node, "INVT_MSGS"));
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
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Day_Inventory",
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

    if(CWIP_Update_Day_Inventory_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    CDB_init_cwipdayinv(&CWIPDAYINV);
    TRS.copy(CWIPDAYINV.WORK_DATE, sizeof(CWIPDAYINV.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPDAYINV.FACTORY, sizeof(CWIPDAYINV.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPDAYINV.LINE_ID, sizeof(CWIPDAYINV.LINE_ID), in_node, "LINE_ID");
    CWIPDAYINV.INVT_SEQ = TRS.get_int(in_node, "INVT_SEQ");
    TRS.copy(CWIPDAYINV.OPER_TYPE, sizeof(CWIPDAYINV.OPER_TYPE), in_node, "OPER_TYPE");
    TRS.copy(CWIPDAYINV.OPER_NAME, sizeof(CWIPDAYINV.OPER_NAME), in_node, "OPER_NAME");
    TRS.copy(CWIPDAYINV.MAT_ID, sizeof(CWIPDAYINV.MAT_ID), in_node, "MAT_ID");
	CWIPDAYINV.MAT_QTY = TRS.get_double(in_node, "MAT_QTY");
    TRS.copy(CWIPDAYINV.BATCH_NO, sizeof(CWIPDAYINV.BATCH_NO), in_node, "BATCH_NO");
    TRS.copy(CWIPDAYINV.TRAN_TIME, sizeof(CWIPDAYINV.TRAN_TIME), in_node, "TRAN_TIME");
    TRS.copy(CWIPDAYINV.INVT_BRCD, sizeof(CWIPDAYINV.INVT_BRCD), in_node, "INVT_BRCD");
    TRS.copy(CWIPDAYINV.INVT_MSGS, sizeof(CWIPDAYINV.INVT_MSGS), in_node, "INVT_MSGS");
    TRS.copy(CWIPDAYINV.CMF_1, sizeof(CWIPDAYINV.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPDAYINV.CMF_2, sizeof(CWIPDAYINV.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPDAYINV.CMF_3, sizeof(CWIPDAYINV.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPDAYINV.CMF_4, sizeof(CWIPDAYINV.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPDAYINV.CMF_5, sizeof(CWIPDAYINV.CMF_5), in_node, "CMF_5");
    TRS.copy(CWIPDAYINV.CMF_6, sizeof(CWIPDAYINV.CMF_6), in_node, "CMF_6");
    TRS.copy(CWIPDAYINV.CMF_7, sizeof(CWIPDAYINV.CMF_7), in_node, "CMF_7");
    TRS.copy(CWIPDAYINV.CMF_8, sizeof(CWIPDAYINV.CMF_8), in_node, "CMF_8");
    TRS.copy(CWIPDAYINV.CMF_9, sizeof(CWIPDAYINV.CMF_9), in_node, "CMF_9");
    TRS.copy(CWIPDAYINV.CMF_10, sizeof(CWIPDAYINV.CMF_10), in_node, "CMF_10");
    TRS.copy(CWIPDAYINV.CREATE_USER_ID, sizeof(CWIPDAYINV.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPDAYINV.CREATE_TIME, sizeof(CWIPDAYINV.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPDAYINV.UPDATE_USER_ID, sizeof(CWIPDAYINV.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPDAYINV.UPDATE_TIME, sizeof(CWIPDAYINV.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, CWIPDAYINV.MAT_ID, sizeof(CWIPDAYINV.MAT_ID));
		DBC_select_mwipmatdef(110, &MWIPMATDEF);
		if (DB_error_code != DB_SUCCESS)
        {
			memcpy(CWIPDAYINV.INVT_MSGS, "The material is not in the master.", strlen("The material is not in the master."));
		}

        //----[Addtional Logic for Create Case]----
		CWIPDAYINV.INVT_SEQ = (int) CDB_select_cwipdayinv_scalar(2, &CWIPDAYINV);
        memcpy(CWIPDAYINV.TRAN_TIME, s_sys_time, sizeof(CWIPDAYINV.TRAN_TIME));
        TRS.copy(CWIPDAYINV.CREATE_USER_ID, sizeof(CWIPDAYINV.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPDAYINV.CREATE_TIME, s_sys_time, sizeof(CWIPDAYINV.CREATE_TIME));
        CDB_insert_cwipdayinv(&CWIPDAYINV);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPDAYINV INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPDAYINV.WORK_DATE), CWIPDAYINV.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPDAYINV.FACTORY), CWIPDAYINV.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPDAYINV.LINE_ID), CWIPDAYINV.LINE_ID);
            TRS.add_fieldmsg(out_node, "INVT_SEQ", MP_INT, CWIPDAYINV.INVT_SEQ);
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
        CDB_init_cwipdayinv(&CWIPDAYINV_o);
        TRS.copy(CWIPDAYINV_o.WORK_DATE, sizeof(CWIPDAYINV_o.WORK_DATE), in_node, "WORK_DATE");
        TRS.copy(CWIPDAYINV_o.FACTORY, sizeof(CWIPDAYINV_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CWIPDAYINV_o.LINE_ID, sizeof(CWIPDAYINV_o.LINE_ID), in_node, "LINE_ID");
        CWIPDAYINV_o.INVT_SEQ = TRS.get_int(in_node, "INVT_SEQ");
        CDB_select_cwipdayinv_for_update(1, &CWIPDAYINV_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPDAYINV SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPDAYINV_o.WORK_DATE), CWIPDAYINV_o.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPDAYINV_o.FACTORY), CWIPDAYINV_o.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPDAYINV_o.LINE_ID), CWIPDAYINV_o.LINE_ID);
            TRS.add_fieldmsg(out_node, "INVT_SEQ", MP_INT, CWIPDAYINV_o.INVT_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----
        memcpy(CWIPDAYINV.TRAN_TIME, s_sys_time, sizeof(CWIPDAYINV.TRAN_TIME));
        //memcpy(CWIPDAYINV.CREATE_USER_ID, CWIPDAYINV_o.CREATE_USER_ID, sizeof(CWIPDAYINV.CREATE_USER_ID));
        //memcpy(CWIPDAYINV.CREATE_TIME, CWIPDAYINV_o.CREATE_TIME, sizeof(CWIPDAYINV.CREATE_TIME));
        TRS.copy(CWIPDAYINV.UPDATE_USER_ID, sizeof(CWIPDAYINV.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPDAYINV.UPDATE_TIME, s_sys_time, sizeof(CWIPDAYINV.UPDATE_TIME));

        CDB_update_cwipdayinv(1, &CWIPDAYINV);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPDAYINV UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPDAYINV.WORK_DATE), CWIPDAYINV.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPDAYINV.FACTORY), CWIPDAYINV.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPDAYINV.LINE_ID), CWIPDAYINV.LINE_ID);
            TRS.add_fieldmsg(out_node, "INVT_SEQ", MP_INT, CWIPDAYINV.INVT_SEQ);
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
        CDB_delete_cwipdayinv(1, &CWIPDAYINV);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPDAYINV DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPDAYINV.WORK_DATE), CWIPDAYINV.WORK_DATE);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPDAYINV.FACTORY), CWIPDAYINV.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPDAYINV.LINE_ID), CWIPDAYINV.LINE_ID);
            TRS.add_fieldmsg(out_node, "INVT_SEQ", MP_INT, CWIPDAYINV.INVT_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Day_Inventory",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_Day_Inventory_Validation()
        - Main sub function of "CWIP_UPDATE_DAY_INVENTORY" function
        - Check the condition for create/update/delete Day_Inventory
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Day_Inventory_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPDAYINV_TAG CWIPDAYINV;
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

    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
      

    return MP_TRUE;
}

