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

#ifndef _SEC_SERVICES_H
#define _SEC_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void SEC_UserRoutine_add_service();

#endif


DllExport int SEC_Login_Ext_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Login_Ext_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_Update_User_Ext_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_User_Ext_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_View_Function_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Function_List_After_1(TRSNode *in_node, TRSNode *out_node);


#endif

