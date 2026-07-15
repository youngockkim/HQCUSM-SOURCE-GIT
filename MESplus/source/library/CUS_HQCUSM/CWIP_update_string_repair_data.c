/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_string_repair_data.c
    Description : String_Repair_Data Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_String_Repair_Data()
            + Create/Update/Delete String_Repair_Data definition
        - CWIP_UPDATE_STRING_REPAIR_DATA()
            + Main sub function of CWIP_Update_String_Repair_Data function
            + Create/Update/Delete String_Repair_Data definition
        - CWIP_Update_String_Repair_Data_Validation()
            + Main sub function of CWIP_UPDATE_STRING_REPAIR_DATA function
            + Check the condition for create/update/delete String_Repair_Data
    Detail Description
        - CWIP_UPDATE_STRING_REPAIR_DATA()
            + h_proc_step
                + MP_STEP_CREATE : Create String_Repair_Data definition
                + MP_STEP_UPDATE : Update String_Repair_Data definition
                + MP_STEP_DELETE : Delete String_Repair_Data definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-12-15             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_String_Repair_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_String_Repair_Data()
        - Create/Update/Delete String_Repair_Data definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_String_Repair_Data(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[10];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_STRING_REPAIR_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_STRING_REPAIR_DATA", out_node);

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
    CWIP_UPDATE_STRING_REPAIR_DATA()
        - Main sub function of "CWIP_Update_String_Repair_Data" function
        - Create/Update/Delete String_Repair_Data definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_STRING_REPAIR_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPSTRRED_TAG CWIPSTRRED;
    struct CWIPSTRRED_TAG CWIPSTRRED_o;
    char   s_sys_time[14];

    LOG_head("CWIP_UPDATE_STRING_REPAIR_DATA");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));    
    LOG_add("operator_name", MP_NSTR, TRS.get_string(in_node, "OPERATOR_NAME"));
    LOG_add("e1_qty", MP_INT, TRS.get_int(in_node, "E1_QTY"));
    LOG_add("e2_qty", MP_INT, TRS.get_int(in_node, "E2_QTY"));
    LOG_add("e3_qty", MP_INT, TRS.get_int(in_node, "E3_QTY"));
    LOG_add("taken_time", MP_INT, TRS.get_int(in_node, "TAKEN_TIME"));
    LOG_add("loss_weight", MP_DBL, TRS.get_double(in_node, "LOSS_WEIGHT"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("tran_time", MP_NSTR, TRS.get_string(in_node, "TRAN_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_String_Repair_Data",
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

    if(CWIP_Update_String_Repair_Data_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwipstrred(&CWIPSTRRED);
    TRS.copy(CWIPSTRRED.FACTORY, sizeof(CWIPSTRRED.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPSTRRED.WORK_DATE, sizeof(CWIPSTRRED.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPSTRRED.WORK_SHIFT, sizeof(CWIPSTRRED.WORK_SHIFT), in_node, "WORK_SHIFT");    
    TRS.copy(CWIPSTRRED.OPERATOR_NAME, sizeof(CWIPSTRRED.OPERATOR_NAME), in_node, "OPERATOR_NAME");
    CWIPSTRRED.E1_QTY = TRS.get_int(in_node, "E1_QTY");
    CWIPSTRRED.E2_QTY = TRS.get_int(in_node, "E2_QTY");
    CWIPSTRRED.E3_QTY = TRS.get_int(in_node, "E3_QTY");
    CWIPSTRRED.TAKEN_TIME = TRS.get_int(in_node, "TAKEN_TIME");
    CWIPSTRRED.LOSS_WEIGHT = TRS.get_double(in_node, "LOSS_WEIGHT");
    TRS.copy(CWIPSTRRED.CMF_1, sizeof(CWIPSTRRED.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPSTRRED.CMF_2, sizeof(CWIPSTRRED.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPSTRRED.CMF_3, sizeof(CWIPSTRRED.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPSTRRED.CMF_4, sizeof(CWIPSTRRED.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPSTRRED.CMF_5, sizeof(CWIPSTRRED.CMF_5), in_node, "CMF_5");
    TRS.copy(CWIPSTRRED.CREATE_USER_ID, sizeof(CWIPSTRRED.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPSTRRED.UPDATE_USER_ID, sizeof(CWIPSTRRED.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPSTRRED.TRAN_TIME, sizeof(CWIPSTRRED.TRAN_TIME), in_node, "TRAN_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CWIPSTRRED.CREATE_USER_ID, sizeof(CWIPSTRRED.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPSTRRED.TRAN_TIME, s_sys_time, sizeof(CWIPSTRRED.TRAN_TIME));  //CREATE TIME APPEND
		memcpy(CWIPSTRRED.CMF_1, s_sys_time, sizeof(s_sys_time));				 //UPDATE TIME APPEND

        CDB_insert_cwipstrred(&CWIPSTRRED);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPSTRRED INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED.FACTORY), CWIPSTRRED.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED.WORK_DATE), CWIPSTRRED.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED.WORK_SHIFT), CWIPSTRRED.WORK_SHIFT);            
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
        CDB_init_cwipstrred(&CWIPSTRRED_o);
        TRS.copy(CWIPSTRRED_o.FACTORY, sizeof(CWIPSTRRED_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CWIPSTRRED_o.WORK_DATE, sizeof(CWIPSTRRED_o.WORK_DATE), in_node, "WORK_DATE");
        TRS.copy(CWIPSTRRED_o.WORK_SHIFT, sizeof(CWIPSTRRED_o.WORK_SHIFT), in_node, "WORK_SHIFT");
		TRS.copy(CWIPSTRRED_o.OPERATOR_NAME, sizeof(CWIPSTRRED_o.OPERATOR_NAME), in_node, "OPERATOR_NAME");       
		
        CDB_select_cwipstrred_for_update(1, &CWIPSTRRED_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPSTRRED SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED_o.FACTORY), CWIPSTRRED_o.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED_o.WORK_DATE), CWIPSTRRED_o.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED_o.WORK_SHIFT), CWIPSTRRED_o.WORK_SHIFT);
            
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----
				
		memcpy(CWIPSTRRED.CMF_1, s_sys_time, sizeof(s_sys_time));				 //UPDATE TIME APPEND
        memcpy(CWIPSTRRED.CREATE_USER_ID, CWIPSTRRED_o.CREATE_USER_ID, sizeof(CWIPSTRRED.CREATE_USER_ID));
        memcpy(CWIPSTRRED.TRAN_TIME, CWIPSTRRED_o.TRAN_TIME, sizeof(CWIPSTRRED.TRAN_TIME));
        TRS.copy(CWIPSTRRED.UPDATE_USER_ID, sizeof(CWIPSTRRED.UPDATE_USER_ID), in_node, IN_USERID);
        //memcpy(CWIPSTRRED.TRAN_TIME, s_sys_time, sizeof(CWIPSTRRED.TRAN_TIME));  // TRAN CURRENT TIME DELETE 
		

        CDB_update_cwipstrred(1, &CWIPSTRRED);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPSTRRED UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED.FACTORY), CWIPSTRRED.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED.WORK_DATE), CWIPSTRRED.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED.WORK_SHIFT), CWIPSTRRED.WORK_SHIFT);            
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
        CDB_delete_cwipstrred(1, &CWIPSTRRED);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPSTRRED DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED.FACTORY), CWIPSTRRED.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED.WORK_DATE), CWIPSTRRED.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED.WORK_SHIFT), CWIPSTRRED.WORK_SHIFT);            
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_String_Repair_Data",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_String_Repair_Data_Validation()
        - Main sub function of "CWIP_UPDATE_STRING_REPAIR_DATA" function
        - Check the condition for create/update/delete String_Repair_Data
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_String_Repair_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPSTRRED_TAG CWIPSTRRED;
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
    /* WORK_SHIFT Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    

    CDB_init_cwipstrred(&CWIPSTRRED);
    TRS.copy(CWIPSTRRED.FACTORY, sizeof(CWIPSTRRED.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPSTRRED.WORK_DATE, sizeof(CWIPSTRRED.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPSTRRED.WORK_SHIFT, sizeof(CWIPSTRRED.WORK_SHIFT), in_node, "WORK_SHIFT");
	TRS.copy(CWIPSTRRED.OPERATOR_NAME, sizeof(CWIPSTRRED.OPERATOR_NAME), in_node, "OPERATOR_NAME");
	
    CDB_select_cwipstrred(1, &CWIPSTRRED);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-XXXX");
            TRS.add_fieldmsg(out_node, "CREATE DUPLICATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED.FACTORY), CWIPSTRRED.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED.WORK_DATE), CWIPSTRRED.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED.WORK_SHIFT), CWIPSTRRED.WORK_SHIFT);            
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

            TRS.add_fieldmsg(out_node, "CWIPSTRRED U/D", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED.FACTORY), CWIPSTRRED.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED.WORK_DATE), CWIPSTRRED.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED.WORK_SHIFT), CWIPSTRRED.WORK_SHIFT);
            
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}