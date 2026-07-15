/*******************************************************************************

    System      : MESplus
    Module      : BATServer
    File Name   : BATServer_check_process.c
    Description : Check Process is alive

    MES Version : 5.3.0

    Function List
        - ADM_Check_Process()
            + Check Process is alive
   
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2013/01/16  Aiden          Create        

    Copyright(C) 1998-2013 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include <MESCore_common.h>
#include <MessageCaster.h>

int ADM_Publish_Process_Status(int check_seq);

/*******************************************************************************
    ADM_Check_Process()
        - Create/Update/Delete Security Function Definition 
    return Value
        - int : 0 (IOI_SUCCESS)
    Arguments
        - TRSNode *in_node : Input Message structure
*******************************************************************************/
int ADM_Check_Process(TRSNode *in_node)
{
     ADM_Publish_Process_Status(TRS.get_int(in_node, "CHECK_SEQ"));

     DB_commit();

     return MP_TRUE;
}

/*******************************************************************************
    ADM_Publish_Process_Status()
        - Publish Process Status
    Return Value
        - int : 0 (IOI_SUCCESS)
    Arguments
        - ADM_Publish_Process_Status_In_Tag *Publish_Process_Status_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int ADM_Publish_Process_Status(int check_seq)
{
    TRSNode *in_node;
    char s_publish_process_channel[MP_SIZE_CHANNEL];
    char s_tmp[MP_SIZE_CHANNEL];

    memset(s_publish_process_channel, 0x00, sizeof(s_publish_process_channel));

    in_node = TRS.create_node("Publish_Process_Status_In");

    TRS.add_string(in_node, "SERVER_NAME", gs_server_name, sizeof(gs_server_name));
    sprintf(s_tmp , "%s - %s %s", gs_server_name, gs_main_channel, gs_subno);
    TRS.add_nstring(in_node, "PROCESS_NAME", s_tmp);
    TRS.add_string(in_node, "CHANNEL", gs_main_channel, MP_SIZE_CHANNEL);
    TRS.add_string(in_node, "SUB_NO", gs_subno, MP_SIZE_SUBNO);
    TRS.add_int(in_node, "CHECK_SEQ", check_seq);

    sprintf(s_publish_process_channel, "/%.*s/ADM", 4, gs_site_id);

    if(CallService("ADM", 
                   "Publish_Process_Status", 
                   in_node, 
                   0x00,
                   s_publish_process_channel,
                   gi_default_ttl,
                   DM_MULTICAST) != MP_TRUE)
    {
        TRS.free_node(in_node);

        LOG_head("ADM_Publish_Process_Status");
        LOG_add("field_msg", MP_NSTR, "Fail to Publish Process Status");

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SYSTEM;

        COM_log_write(gs_log_type.type, gs_log_type.e_type, gs_log_type.category);
        return MP_FALSE;
    }

    TRS.free_node(in_node);
    return MP_TRUE;
}


