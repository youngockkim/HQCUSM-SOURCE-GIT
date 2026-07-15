/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CRAS_multi_update_patrol_check_sheet.c
    Description : Direct_View_Header Setup function module

    MES Version : 5.2.0

    Function List
        - CRAS_Multi_Update_Patrol_Check_Sheet()
            + Create/Update/Delete Direct_View_Header definition
        - CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET()
            + Main sub function of CRAS_Multi_Update_Patrol_Check_Sheet function
            + Create/Update/Delete Direct_View_Header definition
        - CRAS_Multi_Update_Patrol_Check_Sheet_Validation()
            + Main sub function of CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET function
            + Check the condition for create/update/delete Direct_View_Header
    Detail Description
        - CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET()
            + h_proc_step
                + MP_STEP_CREATE : Create Direct_View_Header definition
                + MP_STEP_UPDATE : Update Direct_View_Header definition
                + MP_STEP_DELETE : Delete Direct_View_Header definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2012/08/01  YS Kim         Create by Generator

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_Multi_Update_Patrol_Check_Sheet()
        - Create/Update/Delete Direct_View_Header definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Multi_Update_Patrol_Check_Sheet(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code,"CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET", out_node);

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
    CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET()
        - Main sub function of "CRAS_Multi_Update_Patrol_Check_Sheet" function
        - Create/Update/Delete Direct_View_Header definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE) 
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure 
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    TRSNode **List;

    int i=0;

    LOG_head("CRAS_Multi_Update_Daily_Work_List");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    if(COM_proc_user_routine("CRAS", "CRAS_Multi_Update_Daily_Work_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 



    List =  TRS.get_list(in_node, "WORK_LIST");

    for(i=0;i<TRS.get_item_count(in_node, "WORK_LIST");i++)
    {
        TRS.set_char(List[i], "PROCSTEP", TRS.get_char(in_node, "PROCSTEP"));
        TRS.set_char(List[i], "LANGUAGE", TRS.get_language(in_node));
        TRS.set_nstring(List[i], "FACTORY", TRS.get_factory(in_node));
        TRS.set_nstring(List[i], "USERID", TRS.get_userid(in_node));
        if(CRAS_UPDATE_PATROL_CHECK_SHEET(s_msg_code, List[i], out_node)==MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    
    if(COM_proc_user_routine("CRAS", "CRAS_Multi_Update_Daily_Work_List",
                             MP_UPOINT_AFTER, 
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE; 
} 
