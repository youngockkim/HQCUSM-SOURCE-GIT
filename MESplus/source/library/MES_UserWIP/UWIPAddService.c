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
#include "UWIP_services.h"

#if defined(_USE_STATIC_LIB)

//Use static library
void WIP_UserRoutine_add_service()
{
    COM_add_service("MES_UserWIP", "UWIP_Summary_Temp_Lot", REPLY, UWIP_Summary_Temp_Lot_1);
    COM_add_service("MES_UserWIP", "UWIP_Generate_Sublot_ID", REPLY, UWIP_Generate_Sublot_ID_1);

    COM_add_service("MES_UserWIP", "UWIP_Future_Action_Custom_Action", REPLY, UWIP_Future_Action_Custom_Action_1);
    COM_add_service("MES_UserWIP", "UWIP_Future_Action_Custom_Condition", REPLY, UWIP_Future_Action_Custom_Condition_1);

    COM_add_service("MES_UserWIP", "WIP_Adapt_Lot_Before", REPLY, WIP_Adapt_Lot_Before_1);
    COM_add_service("MES_UserWIP", "WIP_Adapt_Lot_After", REPLY, WIP_Adapt_Lot_After_1);
    COM_add_service("MES_UserWIP", "WIP_Terminate_Lot_Before", REPLY, WIP_Terminate_Lot_Before_1);
    COM_add_service("MES_UserWIP", "WIP_Terminate_Lot_After", REPLY, WIP_Terminate_Lot_After_1);
	COM_add_service("MES_UserWIP", "WIP_Create_Lot_Before", REPLY, WIP_Create_Lot_Before_1);
    COM_add_service("MES_UserWIP", "WIP_Create_Lot_After", REPLY, WIP_Create_Lot_After_1);
    COM_add_service("MES_UserWIP", "WIP_End_Lot_Before", REPLY, WIP_End_Lot_Before_1);
    COM_add_service("MES_UserWIP", "WIP_End_Lot_After", REPLY, WIP_End_Lot_After_1);
    COM_add_service("MES_UserWIP", "WIP_Start_Lot_Before", REPLY, WIP_Start_Lot_Before_1);
    COM_add_service("MES_UserWIP", "WIP_Start_Lot_After", REPLY, WIP_Start_Lot_After_1);
    COM_add_service("MES_UserWIP", "WIP_Update_Factory_Before", REPLY, WIP_Update_Factory_Before_1);
    COM_add_service("MES_UserWIP", "WIP_Update_Factory_After", REPLY, WIP_Update_Factory_After_1);
    COM_add_service("MES_UserWIP", "WIP_View_Hold_Lot_List_Before", REPLY, WIP_View_Hold_Lot_List_Before_1);
    COM_add_service("MES_UserWIP", "WIP_View_Hold_Lot_List_After", REPLY, WIP_View_Hold_Lot_List_After_1);
	/*—[ERP PROJECT]— 시작*/
	COM_add_service("MES_UserWIP", "WIP_Skip_Lot_Before", REPLY, WIP_Skip_Lot_Before_1);
	COM_add_service("MES_UserWIP", "WIP_Skip_Lot_After", REPLY, WIP_Skip_Lot_After_1);
	/*— [ERP PROJECT]—  끝*/
	//23.07.26[재공관리]REQUEST 번호 채번 오류
	COM_add_service("MES_UserWIP", "WIP_Generate_ID_Before", REPLY, WIP_Generate_ID_Before_1);
	COM_add_service("MES_UserWIP", "WIP_Generate_ID_After", REPLY, WIP_Generate_ID_After_1);
	//23.07.26[재공관리]REQUEST 번호 채번 오류

	

}

#else

void SLC_BIND_FUNCTION()
{
    SLC_SET_LIBRARY_MODE(UNLOADABLE);

    SLC_ADD_FUNCTION("UWIP_Summary_Temp_Lot", 1);
    SLC_ADD_FUNCTION("UWIP_Generate_Sublot_ID", 1);

    SLC_ADD_FUNCTION("UWIP_Future_Action_Custom_Action", 1);
    SLC_ADD_FUNCTION("UWIP_Future_Action_Custom_Condition", 1);

    SLC_ADD_FUNCTION("WIP_Adapt_Lot_Before", 1);
    SLC_ADD_FUNCTION("WIP_Adapt_Lot_After", 1);
    SLC_ADD_FUNCTION("WIP_Terminate_Lot_Before", 1);
    SLC_ADD_FUNCTION("WIP_Terminate_Lot_After", 1);
    SLC_ADD_FUNCTION("WIP_End_Lot_Before", 1);
    SLC_ADD_FUNCTION("WIP_End_Lot_After", 1);
    SLC_ADD_FUNCTION("WIP_Start_Lot_Before", 1);
    SLC_ADD_FUNCTION("WIP_Start_Lot_After", 1);
    SLC_ADD_FUNCTION("WIP_Update_Factory_Before", 1);
    SLC_ADD_FUNCTION("WIP_Update_Factory_After", 1); 
    SLC_ADD_FUNCTION("WIP_View_Hold_Lot_List_Before", 1);
    SLC_ADD_FUNCTION("WIP_View_Hold_Lot_List_After", 1);


}

#endif


