/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_repair_insentive.c
    Description : View Repair_Insentive function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Repair_Insentive()
            + View Repair_Insentive definition
        - CWIP_VIEW_REPAIR_INSENTIVE()
            + Main sub function of CWIP_View_Repair_Insentive function
            + View Repair_Insentive definition
    Detail Description
        - CWIP_VIEW_REPAIR_INSENTIVE()
            + h_proc_step
                + 1 : View Repair_Insentive definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-06-28             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Repair_Insentive()
        - View Repair_Insentive definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Repair_Insentive(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_REPAIR_INSENTIVE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_REPAIR_INSENTIVE", out_node);

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
    CWIP_VIEW_REPAIR_INSENTIVE()
        - Main sub function of "CWIP_View_Repair_Insentive" function
        - View Repair_Insentive definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_REPAIR_INSENTIVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPREPOIT_TAG CWIPREPOIT;

	LOG_head("CWIP_VIEW_REPAIR_INSENTIVE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

   

    CDB_init_cwiprepoit(&CWIPREPOIT);
    TRS.copy(CWIPREPOIT.FACTORY, sizeof(CWIPREPOIT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPREPOIT.WORKER, sizeof(CWIPREPOIT.WORKER), in_node, "WORKER");
    TRS.copy(CWIPREPOIT.LOCATION, sizeof(CWIPREPOIT.LOCATION), in_node, "LOCATION");
    //TRS.copy(CWIPREPOIT.START_TIME, sizeof(CWIPREPOIT.START_TIME), in_node, "START_TIME");
    //TRS.copy(CWIPREPOIT.END_TIME, sizeof(CWIPREPOIT.END_TIME), in_node, "END_TIME");
    CDB_select_cwiprepoit(2, &CWIPREPOIT);
    if(DB_error_code != DB_SUCCESS)	//데이터가 없으면 Start가 가능한 상태
    {
        TRS.add_string(out_node, "FACTORY", CWIPREPOIT.FACTORY, sizeof(CWIPREPOIT.FACTORY));
		TRS.add_string(out_node, "WORKER", CWIPREPOIT.WORKER, sizeof(CWIPREPOIT.WORKER));
		TRS.add_string(out_node, "LOCATION", CWIPREPOIT.LOCATION, sizeof(CWIPREPOIT.LOCATION));
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
    }

    TRS.add_string(out_node, "FACTORY", CWIPREPOIT.FACTORY, sizeof(CWIPREPOIT.FACTORY));
    TRS.add_string(out_node, "WORKER", CWIPREPOIT.WORKER, sizeof(CWIPREPOIT.WORKER));
    TRS.add_string(out_node, "LOCATION", CWIPREPOIT.LOCATION, sizeof(CWIPREPOIT.LOCATION));
    TRS.add_string(out_node, "START_TIME", CWIPREPOIT.START_TIME, sizeof(CWIPREPOIT.START_TIME));
    TRS.add_string(out_node, "END_TIME", CWIPREPOIT.END_TIME, sizeof(CWIPREPOIT.END_TIME));
    TRS.add_string(out_node, "STATUS", CWIPREPOIT.STATUS, sizeof(CWIPREPOIT.STATUS));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPREPOIT.CREATE_USER_ID, sizeof(CWIPREPOIT.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPREPOIT.CREATE_TIME, sizeof(CWIPREPOIT.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPREPOIT.UPDATE_USER_ID, sizeof(CWIPREPOIT.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPREPOIT.UPDATE_TIME, sizeof(CWIPREPOIT.UPDATE_TIME));
    TRS.add_string(out_node, "CMF_1", CWIPREPOIT.CMF_1, sizeof(CWIPREPOIT.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPREPOIT.CMF_2, sizeof(CWIPREPOIT.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPREPOIT.CMF_3, sizeof(CWIPREPOIT.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPREPOIT.CMF_4, sizeof(CWIPREPOIT.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPREPOIT.CMF_5, sizeof(CWIPREPOIT.CMF_5));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Repair_Insentive",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

