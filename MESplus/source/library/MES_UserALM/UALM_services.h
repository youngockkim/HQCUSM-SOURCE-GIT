/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : UALM_services.h
    Description : user function prototype of user defined shared library

    MES Version : 5.1

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

#ifndef _ALM_SERVICES_H
#define _ALM_SERVICES_H

#include <SLCCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void ALM_UserRoutine_add_service();

#endif

DllExport int UALM_Proc_Custom_Mail_Contents_1(TRSNode *in_node, TRSNode *out_node);

DllExport int ALM_Ack_Alarm_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int ALM_Ack_Alarm_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int ALM_Raise_Alarm_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int ALM_Raise_Alarm_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int ALM_Update_Alarm_Msg_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int ALM_Update_Alarm_Msg_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int ALM_View_Alarm_Msg_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int ALM_View_Alarm_Msg_After_1(TRSNode *in_node, TRSNode *out_node);


#endif

