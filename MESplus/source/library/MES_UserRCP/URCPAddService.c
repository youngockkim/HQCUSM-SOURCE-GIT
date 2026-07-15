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
#include "URCP_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void RCP_UserRoutine_add_service()
{
    COM_add_service("MES_UserRCP", "RCP_Copy_Recipe_Version_Before", REPLY, RCP_Copy_Recipe_Version_Before_1);
    COM_add_service("MES_UserRCP", "RCP_Copy_Recipe_Version_After", REPLY, RCP_Copy_Recipe_Version_After_1);
    COM_add_service("MES_UserRCP", "RCP_Update_Recipe_Before", REPLY, RCP_Update_Recipe_Before_1);
    COM_add_service("MES_UserRCP", "RCP_Update_Recipe_After", REPLY, RCP_Update_Recipe_After_1);
    COM_add_service("MES_UserRCP", "RCP_View_Lot_Recipe_Before", REPLY, RCP_View_Lot_Recipe_Before_1);
    COM_add_service("MES_UserRCP", "RCP_View_Lot_Recipe_After", REPLY, RCP_View_Lot_Recipe_After_1);
    COM_add_service("MES_UserRCP", "RCP_View_Para_Version_List_Before", REPLY, RCP_View_Para_Version_List_Before_1);
    COM_add_service("MES_UserRCP", "RCP_View_Para_Version_List_After", REPLY, RCP_View_Para_Version_List_After_1);
    COM_add_service("MES_UserRCP", "RCP_Update_Para_Version_Before", REPLY, RCP_Update_Para_Version_Before_1);
    COM_add_service("MES_UserRCP", "RCP_Update_Para_Version_After", REPLY, RCP_Update_Para_Version_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("RCP_Copy_Recipe_Version_Before", 1);
    SLC_ADD_FUNCTION("RCP_Copy_Recipe_Version_After", 1);
    SLC_ADD_FUNCTION("RCP_Update_Recipe_Before", 1);
    SLC_ADD_FUNCTION("RCP_Update_Recipe_After", 1);
    SLC_ADD_FUNCTION("RCP_View_Lot_Recipe_Before", 1);
    SLC_ADD_FUNCTION("RCP_View_Lot_Recipe_After", 1);
    SLC_ADD_FUNCTION("RCP_View_Para_Version_List_Before", 1);
    SLC_ADD_FUNCTION("RCP_View_Para_Version_List_After", 1);
    SLC_ADD_FUNCTION("RCP_Update_Para_Version_Before", 1);
    SLC_ADD_FUNCTION("RCP_Update_Para_Version_After", 1);

}

#endif


