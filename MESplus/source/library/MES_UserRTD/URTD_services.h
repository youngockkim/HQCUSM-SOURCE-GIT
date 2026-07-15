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

#ifndef _RTD_SERVICES_H
#define _RTD_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void RTD_UserRoutine_add_service();

#endif

DllExport int RTD_Update_Rule_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Update_Rule_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Adjust_Lot_Priority_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Adjust_Lot_Priority_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_View_Dispatched_Lot_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_View_Dispatched_Lot_List_After_1(TRSNode *in_node, TRSNode *out_node);

#endif

