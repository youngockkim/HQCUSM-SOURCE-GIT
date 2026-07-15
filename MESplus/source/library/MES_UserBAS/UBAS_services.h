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

#ifndef _BAS_SERVICES_H
#define _BAS_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void BAS_UserRoutine_add_service();

#endif

DllExport int UBAS_Summary_Temp_Attribute_1(TRSNode *in_node, TRSNode *out_node);

DllExport int BAS_Check_Version_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int BAS_Check_Version_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int BAS_Update_Message_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int BAS_Update_Message_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int BAS_View_Data_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int BAS_View_Data_List_After_1(TRSNode *in_node, TRSNode *out_node);

#endif

