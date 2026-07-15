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
#include "USPM_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void SPM_UserRoutine_add_service()
{
    COM_add_service("MES_UserSPM", "SPM_Update_Spec_Before", REPLY, SPM_Update_Spec_Before_1);
    COM_add_service("MES_UserSPM", "SPM_Update_Spec_After", REPLY, SPM_Update_Spec_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("SPM_Update_Spec_Before", 1);
    SLC_ADD_FUNCTION("SPM_Update_Spec_After", 1); 

}

#endif


