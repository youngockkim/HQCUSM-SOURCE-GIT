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
#include "UBAS_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void BAS_UserRoutine_add_service()
{
    COM_add_service("MES_UserBAS", "UBAS_Summary_Temp_Attribute", REPLY, UBAS_Summary_Temp_Attribute_1);

    COM_add_service("MES_UserBAS", "BAS_Check_Version_Before", REPLY, BAS_Check_Version_Before_1);
    COM_add_service("MES_UserBAS", "BAS_Check_Version_After", REPLY, BAS_Check_Version_After_1);
    COM_add_service("MES_UserBAS", "BAS_Update_Message_Before", REPLY, BAS_Update_Message_Before_1);
    COM_add_service("MES_UserBAS", "BAS_Update_Message_After", REPLY, BAS_Update_Message_After_1);
    COM_add_service("MES_UserBAS", "BAS_View_Data_List_Before", REPLY, BAS_View_Data_List_Before_1);
    COM_add_service("MES_UserBAS", "BAS_View_Data_List_After", REPLY, BAS_View_Data_List_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("UBAS_Summary_Temp_Attribute", 1);

    SLC_ADD_FUNCTION("BAS_Check_Version_Before", 1);
    SLC_ADD_FUNCTION("BAS_Check_Version_After", 1);
    SLC_ADD_FUNCTION("BAS_Update_Message_Before", 1);
    SLC_ADD_FUNCTION("BAS_Update_Message_After", 1);
    SLC_ADD_FUNCTION("BAS_View_Data_List_Before", 1);
    SLC_ADD_FUNCTION("BAS_View_Data_List_After", 1);

}

#endif



