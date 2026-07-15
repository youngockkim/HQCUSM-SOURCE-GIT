/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : SLIB_services.h
    Description : user function prototype of user defined shared library

    MES Version : 5.1

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/11/09  Miracom        Create

    Copyright(C) 1998-2009 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#ifndef _SLIB_SERVICES_H
#define _SLIB_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void SLIB_UserRoutine_add_service();

#endif

DllExport int RTD_Point_Type_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Point_Type_Qty_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Number_Type_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Number_Type_2(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Time_Type_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Queue_Time_Over_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Rule_Lot_Qty_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RTD_Scheduled_Lot_Start_Time_1(TRSNode *in_node, TRSNode *out_node);

DllExport int View_Lot_List_1(TRSNode *in_node, TRSNode *out_node);
DllExport int Multi_Transaction_1(TRSNode *in_node, TRSNode *out_node);
DllExport int Multi_Transaction_2(TRSNode *in_node, TRSNode *out_node);
DllExport int Start_Lot_1(TRSNode *in_node, TRSNode *out_node);
DllExport int End_Lot_1(TRSNode *in_node, TRSNode *out_node);


#endif

