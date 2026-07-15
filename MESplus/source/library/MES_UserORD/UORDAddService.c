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
#include "UORD_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void ORD_UserRoutine_add_service()
{
    COM_add_service("MES_UserORD", "ORD_Create_Lot_Before", REPLY, ORD_Create_Lot_Before_1);
    COM_add_service("MES_UserORD", "ORD_Create_Lot_After", REPLY, ORD_Create_Lot_After_1);
    COM_add_service("MES_UserORD", "ORD_Update_Order_Before", REPLY, ORD_Update_Order_Before_1);
    COM_add_service("MES_UserORD", "ORD_Update_Order_After", REPLY, ORD_Update_Order_After_1);
    COM_add_service("MES_UserORD", "ORD_View_Order_Before", REPLY, ORD_View_Order_Before_1);
    COM_add_service("MES_UserORD", "ORD_View_Order_After", REPLY, ORD_View_Order_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("ORD_Create_Lot_Before", 1);
    SLC_ADD_FUNCTION("ORD_Create_Lot_After", 1);
    SLC_ADD_FUNCTION("ORD_Update_Order_Before", 1);
    SLC_ADD_FUNCTION("ORD_Update_Order_After", 1);
    SLC_ADD_FUNCTION("ORD_View_Order_Before", 1);
    SLC_ADD_FUNCTION("ORD_View_Order_After", 1);

}

#endif

