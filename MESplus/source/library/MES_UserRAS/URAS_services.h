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

#ifndef _RAS_SERVICES_H
#define _RAS_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void RAS_UserRoutine_add_service();

#endif

DllExport int URAS_Summary_Temp_Res_1(TRSNode *in_node, TRSNode *out_node);
DllExport int URAS_Summary_Temp_Carrier_1(TRSNode *in_node, TRSNode *out_node);
DllExport int URAS_Summary_Temp_Port_1(TRSNode *in_node, TRSNode *out_node);

DllExport int RAS_Resource_Event_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RAS_Resource_Event_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RAS_Update_Carrier_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RAS_Update_Carrier_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RAS_View_Carrier_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int RAS_View_Carrier_After_1(TRSNode *in_node, TRSNode *out_node);


#endif

