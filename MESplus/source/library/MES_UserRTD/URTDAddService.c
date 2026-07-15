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
#include "URTD_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void RTD_UserRoutine_add_service()
{
    COM_add_service("MES_UserRTD", "RTD_Update_Rule_Before", REPLY, RTD_Update_Rule_Before_1);
    COM_add_service("MES_UserRTD", "RTD_Update_Rule_After", REPLY, RTD_Update_Rule_After_1);
    COM_add_service("MES_UserRTD", "RTD_Adjust_Lot_Priority_Before", REPLY, RTD_Adjust_Lot_Priority_Before_1);
    COM_add_service("MES_UserRTD", "RTD_Adjust_Lot_Priority_After", REPLY, RTD_Adjust_Lot_Priority_After_1);
    COM_add_service("MES_UserRTD", "RTD_View_Dispatched_Lot_List_Before", REPLY, RTD_View_Dispatched_Lot_List_Before_1);
    COM_add_service("MES_UserRTD", "RTD_View_Dispatched_Lot_List_After", REPLY, RTD_View_Dispatched_Lot_List_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("RTD_Update_Rule_Before", 1);
    SLC_ADD_FUNCTION("RTD_Update_Rule_After", 1);
    SLC_ADD_FUNCTION("RTD_Adjust_Lot_Priority_Before", 1);
    SLC_ADD_FUNCTION("RTD_Adjust_Lot_Priority_After", 1);
    SLC_ADD_FUNCTION("RTD_View_Dispatched_Lot_List_Before", 1);
    SLC_ADD_FUNCTION("RTD_View_Dispatched_Lot_List_After", 1);

}

#endif


