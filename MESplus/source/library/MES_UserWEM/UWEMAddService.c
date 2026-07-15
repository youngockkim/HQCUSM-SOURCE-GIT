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
    1     2012/11/13  Miracom        Create

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include <MESCore_service.h>
#include "UWEM_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void WEM_UserRoutine_add_service()
{
    COM_add_service("MES_UserWEM", "UWEM_Step_Action_Custom_Action", REPLY, UWEM_Step_Action_Custom_Action_1);
    COM_add_service("MES_UserWEM", "UWEM_Step_Action_Custom_Condition", REPLY, UWEM_Step_Action_Custom_Condition_1);

    COM_add_service("MES_UserWEM", "WEM_Update_Work_Process_Type_Before", REPLY, WEM_Update_Work_Process_Type_Before_1);
    COM_add_service("MES_UserWEM", "WEM_Update_Work_Process_Type_After", REPLY, WEM_Update_Work_Process_Type_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("UWEM_Step_Action_Custom_Action", 1);
    SLC_ADD_FUNCTION("UWEM_Step_Action_Custom_Condition", 1); 

    SLC_ADD_FUNCTION("WEM_Update_Work_Process_Type_Before", 1);
    SLC_ADD_FUNCTION("WEM_Update_Work_Process_Type_After", 1); 

}

#endif


