/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : sl_common.c
    Description : Common function of user defined shared library

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

#include <MESCore_service.h>
#include "UALM_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void ALM_UserRoutine_add_service()
{
    COM_add_service("MES_UserALM", "UALM_Proc_Custom_Mail_Contents", REPLY, UALM_Proc_Custom_Mail_Contents_1);

    COM_add_service("MES_UserALM", "ALM_Ack_Alarm_Before", REPLY, ALM_Ack_Alarm_Before_1);
    COM_add_service("MES_UserALM", "ALM_Ack_Alarm_After", REPLY, ALM_Ack_Alarm_After_1);
    COM_add_service("MES_UserALM", "ALM_Raise_Alarm_Before", REPLY, ALM_Raise_Alarm_Before_1);
    COM_add_service("MES_UserALM", "ALM_Raise_Alarm_After", REPLY, ALM_Raise_Alarm_After_1);
    COM_add_service("MES_UserALM", "ALM_Update_Alarm_Msg_Before", REPLY, ALM_Update_Alarm_Msg_Before_1);
    COM_add_service("MES_UserALM", "ALM_Update_Alarm_Msg_After", REPLY, ALM_Update_Alarm_Msg_After_1);
    COM_add_service("MES_UserALM", "ALM_View_Alarm_Msg_Before", REPLY, ALM_View_Alarm_Msg_Before_1);
    COM_add_service("MES_UserALM", "ALM_View_Alarm_Msg_After", REPLY, ALM_View_Alarm_Msg_After_1);

}

#else

//Use Shared library
void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("UALM_Proc_Custom_Mail_Contents", 1);

    SLC_ADD_FUNCTION("ALM_Ack_Alarm_Before", 1);
    SLC_ADD_FUNCTION("ALM_Ack_Alarm_After", 1);
    SLC_ADD_FUNCTION("ALM_Raise_Alarm_Before", 1);
    SLC_ADD_FUNCTION("ALM_Raise_Alarm_After", 1);
    SLC_ADD_FUNCTION("ALM_Update_Alarm_Msg_Before", 1);
    SLC_ADD_FUNCTION("ALM_Update_Alarm_Msg_After", 1);
    SLC_ADD_FUNCTION("ALM_View_Alarm_Msg_Before", 1);
    SLC_ADD_FUNCTION("ALM_View_Alarm_Msg_After", 1);

}

#endif


