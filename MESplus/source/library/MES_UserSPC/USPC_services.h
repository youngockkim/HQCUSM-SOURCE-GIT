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

#ifndef _SPC_SERVICES_H
#define _SPC_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void SPC_UserRoutine_add_service();

#endif

DllExport int SPC_Collect_ChartSet_Data_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SPC_Collect_ChartSet_Data_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SPC_Update_Chart_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SPC_Update_Chart_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SPC_View_Chart_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SPC_View_Chart_After_1(TRSNode *in_node, TRSNode *out_node);


#endif

