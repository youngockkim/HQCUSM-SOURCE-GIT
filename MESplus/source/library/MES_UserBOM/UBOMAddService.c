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
#include "UBOM_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void BOM_UserRoutine_add_service()
{
    COM_add_service("MES_UserBOM","BOM_Assembly_Lot_Before", REPLY,BOM_Assembly_Lot_Before_1);
    COM_add_service("MES_UserBOM","BOM_Assembly_Lot_After", REPLY,BOM_Assembly_Lot_After_1);
    COM_add_service("MES_UserBOM","BOM_Update_Attach_Material_Before", REPLY,BOM_Update_Attach_Material_Before_1);
    COM_add_service("MES_UserBOM","BOM_Update_Attach_Material_After", REPLY,BOM_Update_Attach_Material_After_1);
    COM_add_service("MES_UserBOM","BOM_View_Attach_Material_List_Before", REPLY,BOM_View_Attach_Material_List_Before_1);
    COM_add_service("MES_UserBOM","BOM_View_Attach_Material_List_After", REPLY,BOM_View_Attach_Material_List_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("BOM_Assembly_Lot_Before", 1);
    SLC_ADD_FUNCTION("BOM_Assembly_Lot_After", 1);
    SLC_ADD_FUNCTION("BOM_Update_Attach_Material_Before", 1);
    SLC_ADD_FUNCTION("BOM_Update_Attach_Material_After", 1);
    SLC_ADD_FUNCTION("BOM_View_Attach_Material_List_Before", 1);
    SLC_ADD_FUNCTION("BOM_View_Attach_Material_List_After", 1);

}

#endif

