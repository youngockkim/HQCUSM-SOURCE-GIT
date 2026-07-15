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
    1     2012/11/13  Miracom        Create

    Copyright(C) 1998-2013 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#ifndef _SPM_SERVICES_H
#define _SPM_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void SPM_UserRoutine_add_service();

#endif

DllExport int SPM_Update_Spec_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SPM_Update_Spec_After_1(TRSNode *in_node, TRSNode *out_node); 


#endif

