/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : sl_common.h
    Description : user function prototype of user defined shared library

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/11/10  Miracom        Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#ifndef _INV_SERVICES_H
#define _INV_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void INV_UserRoutine_add_service();

#endif


DllExport int INV_Consume_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int INV_Consume_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int INV_Update_Serial_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int INV_Update_Serial_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int INV_View_Inventory_History_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int INV_View_Inventory_History_After_1(TRSNode *in_node, TRSNode *out_node);


#endif

