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
#include "UQCM_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void QCM_UserRoutine_add_service()
{
    COM_add_service("MES_UserQCM", "QCM_Approval_And_Release_to_Version_Before", REPLY, QCM_Approval_And_Release_to_Version_Before_1);
    COM_add_service("MES_UserQCM", "QCM_Approval_And_Release_to_Version_After", REPLY, QCM_Approval_And_Release_to_Version_After_1);
    COM_add_service("MES_UserQCM", "QCM_Update_Inspection_Item_Before", REPLY, QCM_Update_Inspection_Item_Before_1);
    COM_add_service("MES_UserQCM", "QCM_Update_Inspection_Item_After", REPLY, QCM_Update_Inspection_Item_After_1);
    COM_add_service("MES_UserQCM", "QCM_View_Attach_Insp_Item_Before", REPLY, QCM_View_Attach_Insp_Item_Before_1);
    COM_add_service("MES_UserQCM", "QCM_View_Attach_Insp_Item_After", REPLY, QCM_View_Attach_Insp_Item_After_1);

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("QCM_Approval_And_Release_to_Version_Before", 1);
    SLC_ADD_FUNCTION("QCM_Approval_And_Release_to_Version_After", 1);
    SLC_ADD_FUNCTION("QCM_Update_Inspection_Item_Before", 1);
    SLC_ADD_FUNCTION("QCM_Update_Inspection_Item_After", 1);
    SLC_ADD_FUNCTION("QCM_View_Attach_Insp_Item_Before", 1);
    SLC_ADD_FUNCTION("QCM_View_Attach_Insp_Item_After", 1);

}

#endif


