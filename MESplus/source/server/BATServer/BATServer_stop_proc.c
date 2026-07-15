/*******************************************************************************

    System      : MESplus
    Module      : BAT Server
    File Name   : BATServer_stop_proc.c
    Description : BAT Server Stop Process

    MES Version : 5.3.0

    Function List
        - MES_Stop_Process()

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

int MES_Stop_Process(TRSNode *in_node)
{
    gc_stop_process = 'N';

    if(TRS.mem_cmp(in_node, "SUBNO", gs_subno, MP_SIZE_SUBNO) == 0 || 
       COM_isnullspace(TRS.get_string(in_node, "SUBNO")) == MP_TRUE)
    {
        // Write log
        LOG_head("Receive Stop Message !!!");
        LOG_add("Sub No", MP_NSTR, TRS.get_string(in_node, "SUBNO"));
        LOG_add("Message", MP_NSTR, TRS.get_string(in_node, "MSG"));
        COM_log_write(MP_LOG_CATE_SYSTEM, MP_LOG_E_SYSTEM, MP_LOG_INFORMATION);

        gc_stop_process = 'Y';
    }

    DB_commit();

    return MP_TRUE;
}
