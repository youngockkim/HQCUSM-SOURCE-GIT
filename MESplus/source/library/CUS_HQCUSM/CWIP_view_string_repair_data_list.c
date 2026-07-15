/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_string_repair_data_list.c
    Description : View String_Repair_Data List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_String_Repair_Data_List()
            + View String_Repair_Data definition List
        - CWIP_VIEW_STRING_REPAIR_DATA_LIST()
            + Main sub function of CWIP_View_String_Repair_Data_List function
            + View String_Repair_Data definition List
    Detail Description
        - CWIP_VIEW_STRING_REPAIR_DATA_LIST()
            + h_proc_step
                + 1 : View String_Repair_Data definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-12-15             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_String_Repair_Data_List()
        - View String_Repair_Data definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_String_Repair_Data_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[10];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_STRING_REPAIR_DATA_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_STRING_REPAIR_DATA_LIST", out_node);

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
    CWIP_VIEW_STRING_REPAIR_DATA_LIST()
        - Main sub function of "CWIP_View_String_Repair_Data_List" function
        - View String_Repair_Data definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_STRING_REPAIR_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPSTRRED_TAG CWIPSTRRED;
    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_STRING_REPAIR_DATA_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_String_Repair_Data_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    ///* WORK_SHIFT Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CWIP-0001");
    //    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    CDB_init_cwipstrred(&CWIPSTRRED);
    TRS.copy(CWIPSTRRED.FACTORY, sizeof(CWIPSTRRED.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPSTRRED.WORK_DATE, sizeof(CWIPSTRRED.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPSTRRED.WORK_SHIFT, sizeof(CWIPSTRRED.WORK_SHIFT), in_node, "WORK_SHIFT");
	
	i_case = 1;
	if(COM_isnullspace(CWIPSTRRED.WORK_SHIFT)== MP_TRUE)
	{
		i_case = 2;
	}

    CDB_open_cwipstrred(i_case, &CWIPSTRRED);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPSTRRED OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED.FACTORY), CWIPSTRRED.FACTORY);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED.WORK_DATE), CWIPSTRRED.WORK_DATE);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED.WORK_SHIFT), CWIPSTRRED.WORK_SHIFT);        
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwipstrred(i_case, &CWIPSTRRED);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipstrred(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPSTRRED FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSTRRED.FACTORY), CWIPSTRRED.FACTORY);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPSTRRED.WORK_DATE), CWIPSTRRED.WORK_DATE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPSTRRED.WORK_SHIFT), CWIPSTRRED.WORK_SHIFT);            
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwipstrred(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        list_item = TRS.add_node(out_node, "STRING_REPAIR_DATA_LIST");

        TRS.add_string(list_item, "FACTORY", CWIPSTRRED.FACTORY, sizeof(CWIPSTRRED.FACTORY));
        TRS.add_string(list_item, "WORK_DATE", CWIPSTRRED.WORK_DATE, sizeof(CWIPSTRRED.WORK_DATE));
        TRS.add_string(list_item, "WORK_SHIFT", CWIPSTRRED.WORK_SHIFT, sizeof(CWIPSTRRED.WORK_SHIFT));        
        TRS.add_string(list_item, "OPERATOR_NAME", CWIPSTRRED.OPERATOR_NAME, sizeof(CWIPSTRRED.OPERATOR_NAME));
        TRS.add_int(list_item, "E1_QTY", CWIPSTRRED.E1_QTY);
        TRS.add_int(list_item, "E2_QTY", CWIPSTRRED.E2_QTY);
        TRS.add_int(list_item, "E3_QTY", CWIPSTRRED.E3_QTY);
        TRS.add_int(list_item, "TAKEN_TIME", CWIPSTRRED.TAKEN_TIME);
        TRS.add_double(list_item, "LOSS_WEIGHT", CWIPSTRRED.LOSS_WEIGHT);
        TRS.add_string(list_item, "CMF_1", CWIPSTRRED.CMF_1, sizeof(CWIPSTRRED.CMF_1));
        TRS.add_string(list_item, "CMF_2", CWIPSTRRED.CMF_2, sizeof(CWIPSTRRED.CMF_2));
        TRS.add_string(list_item, "CMF_3", CWIPSTRRED.CMF_3, sizeof(CWIPSTRRED.CMF_3));
        TRS.add_string(list_item, "CMF_4", CWIPSTRRED.CMF_4, sizeof(CWIPSTRRED.CMF_4));
        TRS.add_string(list_item, "CMF_5", CWIPSTRRED.CMF_5, sizeof(CWIPSTRRED.CMF_5));
        TRS.add_string(list_item, "CREATE_USER_ID", CWIPSTRRED.CREATE_USER_ID, sizeof(CWIPSTRRED.CREATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPSTRRED.UPDATE_USER_ID, sizeof(CWIPSTRRED.UPDATE_USER_ID));
        TRS.add_string(list_item, "TRAN_TIME", CWIPSTRRED.TRAN_TIME, sizeof(CWIPSTRRED.TRAN_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_String_Repair_Data_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

