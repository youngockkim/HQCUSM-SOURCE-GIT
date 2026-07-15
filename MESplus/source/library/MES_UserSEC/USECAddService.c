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
#include "USEC_services.h"


#if defined(_USE_STATIC_LIB)

//Use static library
void SEC_UserRoutine_add_service()
{
    COM_add_service("MES_UserSEC", "SEC_Login_Ext_Before", REPLY, SEC_Login_Ext_Before_1);
    COM_add_service("MES_UserSEC", "SEC_Login_Ext_After", REPLY, SEC_Login_Ext_After_1);
    COM_add_service("MES_UserSEC", "SEC_Update_User_Ext_Before", REPLY, SEC_Update_User_Ext_Before_1);
    COM_add_service("MES_UserSEC", "SEC_Update_User_Ext_After", REPLY, SEC_Update_User_Ext_After_1);
    COM_add_service("MES_UserSEC", "SEC_View_Function_List_Before", REPLY, SEC_View_Function_List_Before_1);
    COM_add_service("MES_UserSEC", "SEC_View_Function_List_After", REPLY, SEC_View_Function_List_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("SEC_Login_Ext_Before", 1);
    SLC_ADD_FUNCTION("SEC_Login_Ext_After", 1); 
    SLC_ADD_FUNCTION("SEC_Update_User_Ext_Before", 1);
    SLC_ADD_FUNCTION("SEC_Update_User_Ext_After", 1); 
    SLC_ADD_FUNCTION("SEC_View_Function_List_Before", 1);
    SLC_ADD_FUNCTION("SEC_View_Function_List_After", 1);

}

#endif


