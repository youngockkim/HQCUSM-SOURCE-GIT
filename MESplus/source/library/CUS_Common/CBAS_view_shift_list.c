/******************************************************************************'

    System      : MESplus
    Module      : CBAS
    File Name   : CBAS_view_shift_list.c
    Description : View Shift List

    MES Version : 5.3.4 ~

    Function List

    Detail Description

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include "BASCore_common.h"

int CBAS_View_Shift_List_Validation(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node);

/*******************************************************************************
    CBAS_View_Shift_List()
        - View Shift List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_Shift_List(TRSNode *in_node,
                       TRSNode *out_node) 
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CBAS_VIEW_SHIFT_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CBAS_VIEW_SHIFT_LIST", out_node);

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
    CBAS_VIEW_SHIFT_LIST()
        - Main sub function of "CBAS_View_Shift_List" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_VIEW_SHIFT_LIST(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{

    struct MWIPCALDEF_TAG MWIPCALDEF;
    TRSNode *list_item;

    LOG_head("CBAS_View_Shift_List");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(CBAS_View_Shift_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwipcaldef(&MWIPCALDEF);
    TRS.copy(MWIPCALDEF.CALENDAR_ID, sizeof(MWIPCALDEF.CALENDAR_ID), in_node, IN_FACTORY); /* USGAM1 */
    TRS.copy(MWIPCALDEF.SYS_DATE, sizeof(MWIPCALDEF.SYS_DATE), in_node, "SYS_DATE");

    DBC_select_mwipcaldef(5, &MWIPCALDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
	    {
		    strcpy(s_msg_code, "WIP-0044");
            TRS.add_fieldmsg(out_node, "MWIPCALDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "CALENDAR_ID", MP_STR, sizeof(MWIPCALDEF.CALENDAR_ID), MWIPCALDEF.CALENDAR_ID);
            TRS.add_fieldmsg(out_node, "SYS_DATE", MP_STR, sizeof(MWIPCALDEF.SYS_DATE), MWIPCALDEF.SYS_DATE);

		    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
	    }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPCALDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "CALENDAR_ID", MP_STR, sizeof(MWIPCALDEF.CALENDAR_ID), MWIPCALDEF.CALENDAR_ID);
            TRS.add_fieldmsg(out_node, "SYS_DATE", MP_STR, sizeof(MWIPCALDEF.SYS_DATE), MWIPCALDEF.SYS_DATE);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    list_item = TRS.add_node(out_node, "LIST");
    TRS.add_string(list_item, "SHIFT", MWIPCALDEF.CAL_CMF_1, sizeof(MWIPCALDEF.CAL_CMF_1));

    list_item = TRS.add_node(out_node, "LIST");
    TRS.add_string(list_item, "SHIFT", MWIPCALDEF.CAL_CMF_2, sizeof(MWIPCALDEF.CAL_CMF_2));

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CBAS_View_Shift_List_Validation()
        - Validation check sub function of "CBAS_VIEW_DATA_LIST" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_Shift_List_Validation(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node) {

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "GCM-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}
