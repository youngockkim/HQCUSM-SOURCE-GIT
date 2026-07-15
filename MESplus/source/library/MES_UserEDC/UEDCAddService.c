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
#include "UEDC_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void EDC_UserRoutine_add_service()
{
    COM_add_service("MES_UserEDC", "EDC_Collect_Lot_Data_Before", REPLY, EDC_Collect_Lot_Data_Before_1);
    COM_add_service("MES_UserEDC", "EDC_Collect_Lot_Data_After", REPLY, EDC_Collect_Lot_Data_After_1);
    COM_add_service("MES_UserEDC", "EDC_Update_Character_Before", REPLY, EDC_Update_Character_Before_1);
    COM_add_service("MES_UserEDC", "EDC_Update_Character_After", REPLY, EDC_Update_Character_After_1);
    COM_add_service("MES_UserEDC", "EDC_View_Lot_Data_Before", REPLY, EDC_View_Lot_Data_Before_1);
    COM_add_service("MES_UserEDC", "EDC_View_Lot_Data_After", REPLY, EDC_View_Lot_Data_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("EDC_Collect_Lot_Data_Before", 1);
    SLC_ADD_FUNCTION("EDC_Collect_Lot_Data_After", 1);
    SLC_ADD_FUNCTION("EDC_Update_Character_Before", 1);
    SLC_ADD_FUNCTION("EDC_Update_Character_After", 1);
    SLC_ADD_FUNCTION("EDC_View_Lot_Data_Before", 1);
    SLC_ADD_FUNCTION("EDC_View_Lot_Data_After", 1);

}

#endif

