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

#ifndef _QCM_SERVICES_H
#define _QCM_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void QCM_UserRoutine_add_service();

#endif

DllExport int QCM_Approval_And_Release_to_Version_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int QCM_Approval_And_Release_to_Version_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int QCM_Update_Inspection_Item_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int QCM_Update_Inspection_Item_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int QCM_View_Attach_Insp_Item_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int QCM_View_Attach_Insp_Item_After_1(TRSNode *in_node, TRSNode *out_node);


#endif

