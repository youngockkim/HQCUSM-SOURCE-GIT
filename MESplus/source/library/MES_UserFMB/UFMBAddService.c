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
#include "UFMB_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void FMB_UserRoutine_add_service()
{
    COM_add_service("MES_UserFMB", "FMB_Get_HelpURL_Before", REPLY, FMB_Get_HelpURL_Before_1);
    COM_add_service("MES_UserFMB", "FMB_Get_HelpURL_After", REPLY, FMB_Get_HelpURL_After_1);
    COM_add_service("MES_UserFMB", "FMB_Update_Environment_Before", REPLY, FMB_Update_Environment_Before_1);
    COM_add_service("MES_UserFMB", "FMB_Update_Environment_After", REPLY, FMB_Update_Environment_After_1);
    COM_add_service("MES_UserFMB", "FMB_View_LayOut_Before", REPLY, FMB_View_LayOut_Before_1);
    COM_add_service("MES_UserFMB", "FMB_View_LayOut_After", REPLY, FMB_View_LayOut_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("FMB_Get_HelpURL_Before", 1);
    SLC_ADD_FUNCTION("FMB_Get_HelpURL_After", 1);
    SLC_ADD_FUNCTION("FMB_Update_Environment_Before", 1);
    SLC_ADD_FUNCTION("FMB_Update_Environment_After", 1);
    SLC_ADD_FUNCTION("FMB_View_LayOut_Before", 1);
    SLC_ADD_FUNCTION("FMB_View_LayOut_After", 1);

}

#endif

