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
#include "URAS_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void RAS_UserRoutine_add_service()
{
    COM_add_service("MES_UserRAS", "URAS_Summary_Temp_Res", REPLY, URAS_Summary_Temp_Res_1);
    COM_add_service("MES_UserRAS", "URAS_Summary_Temp_Carrier", REPLY, URAS_Summary_Temp_Carrier_1);
    COM_add_service("MES_UserRAS", "URAS_Summary_Temp_Port", REPLY, URAS_Summary_Temp_Port_1);

    COM_add_service("MES_UserRAS", "RAS_Resource_Event_Before", REPLY, RAS_Resource_Event_Before_1);
    COM_add_service("MES_UserRAS", "RAS_Resource_Event_After", REPLY, RAS_Resource_Event_After_1);
    COM_add_service("MES_UserRAS", "RAS_Update_Carrier_Before", REPLY, RAS_Update_Carrier_Before_1);
    COM_add_service("MES_UserRAS", "RAS_Update_Carrier_After", REPLY, RAS_Update_Carrier_After_1);
    COM_add_service("MES_UserRAS", "RAS_View_Carrier_Before", REPLY, RAS_View_Carrier_Before_1);
    COM_add_service("MES_UserRAS", "RAS_View_Carrier_After", REPLY, RAS_View_Carrier_After_1);

}

#else


void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("URAS_Summary_Temp_Res", 1);
    SLC_ADD_FUNCTION("URAS_Summary_Temp_Carrier", 1);
    SLC_ADD_FUNCTION("URAS_Summary_Temp_Port", 1);

    SLC_ADD_FUNCTION("RAS_Resource_Event_Before", 1);
    SLC_ADD_FUNCTION("RAS_Resource_Event_After", 1);
    SLC_ADD_FUNCTION("RAS_Update_Carrier_Before", 1);
    SLC_ADD_FUNCTION("RAS_Update_Carrier_After", 1);
    SLC_ADD_FUNCTION("RAS_View_Carrier_Before", 1);
    SLC_ADD_FUNCTION("RAS_View_Carrier_After", 1);

}

#endif


