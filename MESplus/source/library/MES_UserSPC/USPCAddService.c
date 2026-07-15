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
#include "USPC_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void SPC_UserRoutine_add_service()
{
    COM_add_service("MES_UserSPC", "SPC_Collect_ChartSet_Data_Before", REPLY, SPC_Collect_ChartSet_Data_Before_1);
    COM_add_service("MES_UserSPC", "SPC_Collect_ChartSet_Data_After", REPLY, SPC_Collect_ChartSet_Data_After_1);
    COM_add_service("MES_UserSPC", "SPC_Update_Chart_Before", REPLY, SPC_Update_Chart_Before_1);
    COM_add_service("MES_UserSPC", "SPC_Update_Chart_After", REPLY, SPC_Update_Chart_After_1);
    COM_add_service("MES_UserSPC", "SPC_View_Chart_Before", REPLY, SPC_View_Chart_Before_1);
    COM_add_service("MES_UserSPC", "SPC_View_Chart_After", REPLY, SPC_View_Chart_After_1);

}

#else


void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("SPC_Collect_ChartSet_Data_Before", 1);
    SLC_ADD_FUNCTION("SPC_Collect_ChartSet_Data_After", 1);
    SLC_ADD_FUNCTION("SPC_Update_Chart_Before", 1);
    SLC_ADD_FUNCTION("SPC_Update_Chart_After", 1);
    SLC_ADD_FUNCTION("SPC_View_Chart_Before", 1);
    SLC_ADD_FUNCTION("SPC_View_Chart_After", 1);

}

#endif


