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
#include "UCMN_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void CMN_UserRoutine_add_service()
{
    COM_add_service("MES_UserCMN", "UCMN_prologue", REPLY, UCMN_prologue_1);
    COM_add_service("MES_UserCMN", "UCMN_epilogue", REPLY, UCMN_epilogue_1);
    COM_add_service("MES_UserCMN", "UCMN_server_start", REPLY, UCMN_server_start_1);
}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("UCMN_prologue", 1);
    SLC_ADD_FUNCTION("UCMN_epilogue", 1);
    SLC_ADD_FUNCTION("UCMN_server_start", 1);

}

#endif

