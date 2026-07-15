/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : sl_common.h
    Description : user function prototype of user defined shared library

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

#ifndef _SEC_SL_COMMON_H
#define _SEC_SL_COMMON_H

#include <SLCCore_common.h>
#include <MESCore_common.h>

#if defined(_USE_STATIC_LIB)

extern void SEC_UserRoutine_add_service();

#endif


DllExport int SEC_Login_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Login_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_Login_Ext_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Login_Ext_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_Change_Password_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Change_Password_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_Change_Password_Ext_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Change_Password_Ext_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Copy_Privilege_Group_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Copy_Privilege_Group_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Copy_SecGrp_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Copy_SecGrp_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Favorites_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Favorites_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Function_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Function_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_GrpFunc_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_GrpFunc_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Privilege_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Privilege_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Privilege_Group_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Privilege_Group_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Privilege_Group_User_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Privilege_Group_User_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_SecGrp_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_SecGrp_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_Update_User_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_User_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_Update_User_Ext_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_User_Ext_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_Update_Flexible_Header_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Update_Flexible_Header_After_1(TRSNode *in_node, TRSNode *out_node);

DllExport int SEC_Get_HelpURL_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_Get_HelpURL_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Favorites_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Favorites_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Function_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Function_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Function_Detail_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Function_Detail_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Function_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Function_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_GrpFunc_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_GrpFunc_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_Group_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_Group_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_Group_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_Group_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_Group_User_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_Group_User_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Privilege_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_SecGrp_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_SecGrp_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_SecGrp_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_SecGrp_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_User_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_User_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_User_Ext_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_User_Ext_After_1(TRSNode *in_node, TRSNode *out_node); 
DllExport int SEC_View_User_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_User_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Flexible_Header_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Flexible_Header_List_After_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Group_By_Type_Privilege_List_Before_1(TRSNode *in_node, TRSNode *out_node);
DllExport int SEC_View_Group_By_Type_Privilege_List_After_1(TRSNode *in_node, TRSNode *out_node);



#endif

