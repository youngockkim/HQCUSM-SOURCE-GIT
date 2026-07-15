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
#include "UINV_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void INV_UserRoutine_add_service()
{
    COM_add_service("MES_UserINV", "INV_Consume_Before", REPLY, INV_Consume_Before_1);
    COM_add_service("MES_UserINV", "INV_Consume_After", REPLY, INV_Consume_After_1);
    COM_add_service("MES_UserINV", "INV_Update_Serial_List_Before", REPLY, INV_Update_Serial_List_Before_1);
    COM_add_service("MES_UserINV", "INV_Update_Serial_List_After", REPLY, INV_Update_Serial_List_After_1);
    COM_add_service("MES_UserINV", "INV_View_Inventory_History_Before", REPLY, INV_View_Inventory_History_Before_1);
    COM_add_service("MES_UserINV", "INV_View_Inventory_History_After", REPLY, INV_View_Inventory_History_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("INV_Consume_Before", 1);
    SLC_ADD_FUNCTION("INV_Consume_After", 1);
    SLC_ADD_FUNCTION("INV_Update_Serial_List_Before", 1);
    SLC_ADD_FUNCTION("INV_Update_Serial_List_After", 1);
    SLC_ADD_FUNCTION("INV_View_Inventory_History_Before", 1);
    SLC_ADD_FUNCTION("INV_View_Inventory_History_After", 1);

}

#endif

