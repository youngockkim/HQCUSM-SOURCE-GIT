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
#include "UPOP_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void POP_UserRoutine_add_service()
{
    COM_add_service("MES_UserPOP", "POP_Gen_Label_Before", REPLY, POP_Gen_Label_Before_1);
    COM_add_service("MES_UserPOP", "POP_Gen_Label_After", REPLY, POP_Gen_Label_After_1);
    COM_add_service("MES_UserPOP", "POP_Update_Label_Before", REPLY, POP_Update_Label_Before_1);
    COM_add_service("MES_UserPOP", "POP_Update_Label_After", REPLY, POP_Update_Label_After_1);
    COM_add_service("MES_UserPOP", "POP_View_Label_Before", REPLY, POP_View_Label_Before_1);
    COM_add_service("MES_UserPOP", "POP_View_Label_After", REPLY, POP_View_Label_After_1);

}

#else


void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("POP_Gen_Label_Before", 1);
    SLC_ADD_FUNCTION("POP_Gen_Label_After", 1);
    SLC_ADD_FUNCTION("POP_Update_Label_Before", 1);
    SLC_ADD_FUNCTION("POP_Update_Label_After", 1);
    SLC_ADD_FUNCTION("POP_View_Label_Before", 1);
    SLC_ADD_FUNCTION("POP_View_Label_After", 1);

}

#endif


