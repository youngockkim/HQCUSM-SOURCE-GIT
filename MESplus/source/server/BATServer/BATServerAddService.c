/*******************************************************************************

    System      : MESplus
    Module      : BATServer Module
    File Name   : BATServerAddService.c
    Description : register services of BATServer module

    MES Version : 4.2.0

    Function List
        - 
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2013/01/15  Aiden          Create        

    Copyright(C) 1998-2013 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include <MESCore_common.h>

extern int MES_Stop_Process(TRSNode *in_node);
extern int ADM_Check_Process(TRSNode *in_node);

extern void BATCore_add_service();

void BATServer_add_service()
{
    COM_add_service("MESplus", "Stop_Process", NO_REPLY, MES_Stop_Process);
    COM_add_service("ADM", "ADM_Check_Process", NO_REPLY, ADM_Check_Process);

    BATCore_add_service();

}
