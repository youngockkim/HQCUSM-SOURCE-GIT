/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : SLIBAddService.c
    Description : Common function of user defined shared library

    MES Version : 5.1

    Function List
        - 

    Detail Description
        - 
		=
    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/11/09  Miracom        Create

    Copyright(C) 1998-2009 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include <MESCore_service.h>
#include "SLIB_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void SLIB_UserRoutine_add_service()
{
    COM_add_service("MES_SampleLib", "RTD_Point_Type", REPLY, RTD_Point_Type_1);
    COM_add_service("MES_SampleLib", "RTD_Point_Type_Qty", REPLY, RTD_Point_Type_Qty_1);
    COM_add_service("MES_SampleLib", "RTD_Number_Type", REPLY, RTD_Number_Type_2);
    COM_add_service("MES_SampleLib", "RTD_Time_Type", REPLY, RTD_Time_Type_1);
    COM_add_service("MES_SampleLib", "RTD_Queue_Time_Over", REPLY, RTD_Queue_Time_Over_1);
    COM_add_service("MES_SampleLib", "RTD_Rule_Lot_Qty", REPLY, RTD_Rule_Lot_Qty_1);
    COM_add_service("MES_SampleLib", "RTD_Scheduled_Lot_Start_Time", REPLY, RTD_Scheduled_Lot_Start_Time_1);

    COM_add_service("MES_SampleLib", "View_Lot_List", REPLY, View_Lot_List_1);
    COM_add_service("MES_SampleLib", "Multi_Transaction", REPLY, Multi_Transaction_2);
    COM_add_service("MES_SampleLib", "Start_Lot", REPLY, Start_Lot_1);
    COM_add_service("MES_SampleLib", "End_Lot", REPLY, End_Lot_1);
}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("RTD_Point_Type", 1);
    SLC_ADD_FUNCTION("RTD_Number_Type", 1);
    SLC_ADD_FUNCTION("RTD_Time_Type", 1);
    SLC_ADD_FUNCTION("RTD_Queue_Time_Over", 1);
    SLC_ADD_FUNCTION("RTD_Rule_Lot_Qty", 1);
    SLC_ADD_FUNCTION("RTD_Scheduled_Lot_Start_Time", 1);

    SLC_ADD_FUNCTION("View_Lot_List", 1);
    SLC_ADD_FUNCTION("Multi_Transaction", 1);
    SLC_ADD_FUNCTION("Start_Lot", 1);
    SLC_ADD_FUNCTION("End_Lot", 1);
}

#endif

