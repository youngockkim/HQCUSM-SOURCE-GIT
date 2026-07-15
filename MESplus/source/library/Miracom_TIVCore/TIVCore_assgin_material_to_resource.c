/******************************************************************************'

	System      : MESplus
	Module      : TIVCore
	File Name   : TIVCore_Assign_material_to_resource.c
	Description : Assgin Raw Material to Resource. (Raw Material Kitting)

	MES Version : 5.2.0

	Function List
		- TIV_Update_Tap_assign_material_to_resource()
			+ Create/Update/Delete Tap_assign_material_to_resource definition
		- TIV_UPDATE_TIV_ASSIGN_MATERIAL_TO_RESOURCE()
			+ Main sub function of TAP_Update_Tap_assign_material_to_resource function
			+ Create/Update/Delete Tap_assign_material_to_resource definition
		- TIV_Update_Tap_assign_material_to_resource_Validation()
			+ Main sub function of TAP_UPDATE_TIV_ASSIGN_MATERIAL_TO_RESOURCE function
			+ Check the condition for create/update/delete Tap_assign_material_to_resource
	Detail Description
		- TAP_UPDATE_TIV_ASSIGN_MATERIAL_TO_RESOURCE()
			+ h_proc_step
				+ MP_STEP_CREATE : Create Tap_assign_material_to_resource definition
				+ MP_STEP_DELETE : Delete Tap_assign_material_to_resource definition

	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
	1     2012/11/14  Kelly Jung     Create by Generator

	Copyright(C) 1998-2012 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "TIVCore_common.h"
#include "INVCore_common.h"

int TIV_Assign_Material_To_Resource_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node);
int TIV_ASSIGN_MATERIAL_TO_RESOURCE(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node);

/*******************************************************************************
	Tap_assign_material_to_resource()
		- Create/Update/Delete Tap_assign_material_to_resource definition
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Assign_Material_To_Resource(TRSNode *in_node,
						TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = TIV_ASSIGN_MATERIAL_TO_RESOURCE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"TIV_ASSIGN_MATERIAL_TO_RESOURCE", out_node);

	if(i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	return MP_TRUE;
}
/*******************************************************************************
	TIV_ASSIGN_MATERIAL_TO_RESOURCE()
		- Main sub function of "Tap_assign_material_to_resource" function
		- Create/Update/Delete Tap_assign_material_to_resource definition
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_ASSIGN_MATERIAL_TO_RESOURCE(char *s_msg_code,
							  TRSNode *in_node, 
							  TRSNode *out_node)
{ 
	//struct MTAPRESMLT_TAG MTAPRESMLT;
 //   struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MTAPRESMLT_TAG MTAPRESMLT_T;
	//struct MTIVOPRDEF_TAG MTIVOPRDEF;
 //   struct CINVMRRREL_TAG CINVMRRREL;
 //   struct MTIVLOTSTS_TAG MTIVLOTSTS_O;

	//TRSNode **mat_list;
	//int i;

	//char s_sys_time[14];

	//LOG_head("TIV_Assign_Material_To_Resource");
	//LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
	//LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node)); 
	//LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
	//LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
	//LOG_add("factory", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
	//LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
	//LOG_add("mat_lot_id", MP_NSTR, TRS.get_string(in_node, "MAT_LOT_ID"));
	//LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
	//LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER "));
 //   LOG_add("input_qty", MP_DBL, TRS.get_double(in_node, "INPUT_QTY"));
	//LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
	//LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
	//LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
	//LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
	//COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);



	//if(COM_proc_user_routine("TAP", "TIV_Assign_Material_To_Resource",
	//						 MP_UPOINT_BEFORE,
	//						 in_node,
	//						 out_node) == MP_FALSE)     return MP_FALSE;
	//if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE; 

	//	// get the system time
 //   memset(s_sys_time, ' ', sizeof(s_sys_time));
 //   DB_get_systime(s_sys_time);
 //   if(DB_error_code != DB_SUCCESS)
 //   {
 //       strcpy(s_msg_code, "WIP-0004");
 //       TRS.add_fieldmsg(out_node, "DB_get_systime()", MP_NVST);
 //       TRS.add_dberrmsg(out_node, DB_error_msg);

 //       gs_log_type.type = MP_LOG_ERROR;
 //       gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //       gs_log_type.category = MP_LOG_CATE_TRANS;
 //       COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
 //       return MP_FALSE;
 //   }    

	//if(TIV_Assign_Material_To_Resource_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
	//{
	//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//	return MP_FALSE;
	//}

	//
	//if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	//{
	//	mat_list = TRS.get_list(in_node, "MAT_LIST");
	//	for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
	//	{
 //           /*Exist Check*/
 //           DBC_init_mtapresmlt(&MTAPRESMLT);
 //           TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, IN_FACTORY);
 //           TRS.copy(MTAPRESMLT.RES_ID, sizeof(MTAPRESMLT.RES_ID), in_node, "RES_ID");
 //           TRS.copy(MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID), mat_list[i], "MAT_LOT_ID");
	//		TRS.copy(MTAPRESMLT.MAT_ID, sizeof(MTAPRESMLT.MAT_ID), mat_list[i], "MAT_ID");
 //           DBC_select_mtapresmlt(1, &MTAPRESMLT);
 //           if(DB_error_code == DB_NOT_FOUND)//존재하지 않는다면
 //           {                
 //               TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, IN_FACTORY);
	//		    TRS.copy(MTAPRESMLT.RES_ID, sizeof(MTAPRESMLT.RES_ID), in_node, "RES_ID");
	//		    TRS.copy(MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID), mat_list[i], "MAT_LOT_ID");
	//		    TRS.copy(MTAPRESMLT.MAT_ID, sizeof(MTAPRESMLT.MAT_ID), mat_list[i], "MAT_ID");
	//		    MTAPRESMLT.MAT_VER = 1;
	//			TRS.copy(MTAPRESMLT.CREATE_USER_ID, sizeof(MTAPRESMLT.CREATE_USER_ID), in_node, IN_USERID);
	//			DB_get_systime(MTAPRESMLT.CREATE_TIME);
	//			TRS.copy(MTAPRESMLT.UPDATE_USER_ID, sizeof(MTAPRESMLT.UPDATE_USER_ID), in_node, IN_USERID);
	//			DB_get_systime(MTAPRESMLT.UPDATE_TIME);
 //               TRS.copy(MTAPRESMLT.QTY_1_UNIT, sizeof(MTAPRESMLT.QTY_1_UNIT), mat_list[i], "QTY_1_UNIT");
 //               MTAPRESMLT.INPUT_QTY  = TRS.get_double(mat_list[i], "INPUT_QTY"); /* Add for V42 */
 //               MTAPRESMLT.DEFAULT_QTY = TRS.get_double(mat_list[i], "DEFAULT_QTY");
 //               TRS.copy(MTAPRESMLT.DEFAULT_UNIT, sizeof(MTAPRESMLT.DEFAULT_UNIT), mat_list[i], "DEFAULT_UNIT");


	//		    DBC_insert_mtapresmlt(&MTAPRESMLT);
	//		    if(DB_error_code != DB_SUCCESS)
	//		    { 
	//		    	strcpy(s_msg_code, "TAP-0004"); 
	//		    	TRS.add_fieldmsg(out_node, "MTAPRESMLT INSERT", MP_NVST); 
	//		    	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPRESMLT.FACTORY), MTAPRESMLT.FACTORY); 
	//		    	TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTAPRESMLT.RES_ID), MTAPRESMLT.RES_ID); 
	//		    	TRS.add_fieldmsg(out_node, "MAT_LOT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_LOT_ID), MTAPRESMLT.MAT_LOT_ID); 
	//		    	TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_ID), MTAPRESMLT.MAT_ID); 
	//		    	TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTAPRESMLT.MAT_VER); 
	//		    	TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(MTAPRESMLT.CREATE_TIME), MTAPRESMLT.CREATE_TIME); 
	//		    	TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(MTAPRESMLT.CREATE_USER_ID), MTAPRESMLT.CREATE_USER_ID); 
	//		    	TRS.add_fieldmsg(out_node, "UPDATE_TIME", MP_STR, sizeof(MTAPRESMLT.UPDATE_TIME), MTAPRESMLT.UPDATE_TIME); 
	//		    	TRS.add_fieldmsg(out_node, "UPDATE_USER_ID", MP_STR, sizeof(MTAPRESMLT.UPDATE_USER_ID), MTAPRESMLT.UPDATE_USER_ID); 
	//		    	TRS.add_dberrmsg(out_node, DB_error_msg);

	//		    	gs_log_type.type = MP_LOG_ERROR;
	//		    	gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//		    	gs_log_type.category = MP_LOG_CATE_SETUP;

	//		    	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
	//		    	return MP_FALSE; 
	//		    } 
 //           }
 //           else if(DB_error_code == DB_SUCCESS && DB_error_code != DB_NOT_FOUND)//존재한다면
 //           {
 //               DBC_init_mtapresmlt(&MTAPRESMLT); 
	//	        TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, "FACTORY");
	//	        TRS.copy(MTAPRESMLT.RES_ID, sizeof(MTAPRESMLT.RES_ID), in_node, "RES_ID");
	//	        TRS.copy(MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID), mat_list[i], "MAT_LOT_ID");
	//	        TRS.copy(MTAPRESMLT.MAT_ID, sizeof(MTAPRESMLT.MAT_ID), mat_list[i], "MAT_ID");
	//	        MTAPRESMLT.MAT_VER = 1;
	//	        DBC_select_mtapresmlt_for_update(1, &MTAPRESMLT);
	//	        if(DB_error_code != DB_SUCCESS)
	//	        { 
	//	        	strcpy(s_msg_code, "TAP-0004"); 
	//	        	TRS.add_fieldmsg(out_node, "MTAPRESMLT SELECT FOR UPDATE", MP_NVST);
	//	        	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPRESMLT.FACTORY), MTAPRESMLT.FACTORY); 
	//	        	TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTAPRESMLT.RES_ID), MTAPRESMLT.RES_ID); 
	//	        	TRS.add_fieldmsg(out_node, "MAT_LOT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_LOT_ID), MTAPRESMLT.MAT_LOT_ID); 
	//	        	TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_ID), MTAPRESMLT.MAT_ID); 
	//	        	TRS.add_dberrmsg(out_node, DB_error_msg);

	//	        	gs_log_type.type = MP_LOG_ERROR;
	//	        	gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//	        	gs_log_type.category = MP_LOG_CATE_SETUP;

	//	        	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
	//	        	return MP_FALSE; 
	//	        } 

 //               TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, "FACTORY");
 //               TRS.copy(MTAPRESMLT.RES_ID, sizeof(MTAPRESMLT.RES_ID), in_node, "RES_ID");
	//	        TRS.copy(MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID), mat_list[i], "MAT_LOT_ID");
	//	        TRS.copy(MTAPRESMLT.MAT_ID, sizeof(MTAPRESMLT.MAT_ID), mat_list[i], "MAT_ID");
 //               MTAPRESMLT.INPUT_QTY  = TRS.get_double(mat_list[i], "INPUT_QTY");
	//	        TRS.copy(MTAPRESMLT.UPDATE_USER_ID, sizeof(MTAPRESMLT.UPDATE_USER_ID), in_node, IN_USERID);
	//	        DB_get_systime(MTAPRESMLT.UPDATE_TIME);
 //               MTAPRESMLT.DEFAULT_QTY = TRS.get_double(mat_list[i], "DEFAULT_QTY");
 //               TRS.copy(MTAPRESMLT.DEFAULT_UNIT, sizeof(MTAPRESMLT.DEFAULT_UNIT), mat_list[i], "DEFAULT_UNIT");
 //               TRS.copy(MTAPRESMLT.QTY_1_UNIT, sizeof(MTAPRESMLT.QTY_1_UNIT), mat_list[i], "QTY_1_UNIT");

	//	        DBC_update_mtapresmlt(1, &MTAPRESMLT);
	//	        if(DB_error_code != DB_SUCCESS)
	//	        { 
	//	        	strcpy(s_msg_code, "TAP-0004"); 
	//	        	TRS.add_fieldmsg(out_node, "MTAPRESMLT UPDATE", MP_NVST); 
	//	        	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPRESMLT.FACTORY), MTAPRESMLT.FACTORY); 
	//	        	TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTAPRESMLT.RES_ID), MTAPRESMLT.RES_ID); 
	//	        	TRS.add_fieldmsg(out_node, "MAT_LOT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_LOT_ID), MTAPRESMLT.MAT_LOT_ID); 
	//	        	TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_ID), MTAPRESMLT.MAT_ID); 
	//	        	TRS.add_dberrmsg(out_node, DB_error_msg);

	//	        	gs_log_type.type = MP_LOG_ERROR;
	//	        	gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//	        	gs_log_type.category = MP_LOG_CATE_SETUP;

	//	        	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
	//	        	return MP_FALSE; 
	//	        } 
 //           }

 //           /*added by liwei 20131126 to set the new attached inv lot's oinv_out_time 
 //                  to the exsting one based on setup (Aging Time, Queue Time only) */
 //           DBU_init_cinvmrrrel(&CINVMRRREL);
 //           TRS.copy(CINVMRRREL.FACTORY, sizeof(CINVMRRREL.FACTORY), in_node, IN_FACTORY);
 //           TRS.copy(CINVMRRREL.MAT_ID, sizeof(CINVMRRREL.MAT_ID), mat_list[i], "MAT_ID");
 //           CINVMRRREL.MAT_VER = 1;
 //           TRS.copy(CINVMRRREL.RES_ID, sizeof(CINVMRRREL.RES_ID), in_node, "RES_ID");
 //           memcpy(CINVMRRREL.SET_TYPE, "Aging Time", strlen("Aging Time"));
 //           memcpy(CINVMRRREL.REL_CMF_10, "Queue Time", strlen("Queue Time"));  //query condition for the set_type
 //           memcpy(CINVMRRREL.REL_CMF_1, "Y", strlen("Y"));
 //           CINVMRRREL.REL_LEVEL = '1';
 //           DBU_select_cinvmrrrel(2,&CINVMRRREL);
 //           if(DB_error_code == DB_SUCCESS)
 //           {
 //               /*relation found, try to get existing inv lot on res with the oldest oinv_out_time*/
 //               DBC_init_mtivlotsts(&MTIVLOTSTS_O);
 //               TRS.copy(MTIVLOTSTS_O.FACTORY, sizeof(MTIVLOTSTS_O.FACTORY), in_node, IN_FACTORY);
 //               TRS.copy(MTIVLOTSTS_O.ADD_ORDER_ID_1, sizeof(MTAPRESMLT.RES_ID), in_node, "RES_ID");
 //               TRS.copy(MTIVLOTSTS_O.INV_CMF_19, sizeof(MTIVLOTSTS_O.INV_CMF_19), in_node, "RES_TANK");
 //               TRS.copy(MTIVLOTSTS_O.MAT_ID, sizeof(MTIVLOTSTS_O.MAT_ID), mat_list[i], "MAT_ID");
 //               memcpy(MTIVLOTSTS_O.OPER, "M0050", strlen("M0050"));
 //               DBC_select_mtivlotsts(904, &MTIVLOTSTS_O);
 //               if(DB_error_code == DB_SUCCESS)
 //               {
 //                   /*updating the new attached inv lot's oinv_out_time and tank*/
 //                   DBC_init_mtivlotsts(&MTIVLOTSTS);
 //                   memcpy(MTIVLOTSTS.FACTORY, MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY));
 //                   memcpy(MTIVLOTSTS.LOT_ID, MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID));
 //                   memcpy(MTIVLOTSTS.OPER, "M0050", strlen("M0050"));
 //                   DBC_select_mtivlotsts(4, &MTIVLOTSTS);
 //                   if(DB_error_code == DB_SUCCESS)
 //                   {
 //                       memcpy(MTIVLOTSTS.INV_CMF_19, MTIVLOTSTS_O.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
 //                       memcpy(MTIVLOTSTS.OINV_OUT_TIME, MTIVLOTSTS_O.OINV_OUT_TIME, sizeof(MTIVLOTSTS.OINV_OUT_TIME));
 //                       DBC_update_mtivlotsts(3, &MTIVLOTSTS);
 //                       if(DB_error_code != DB_SUCCESS)
 //                       { 
 //                           strcpy(s_msg_code, "TAP-0004"); 
 //                           TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT", MP_NVST); 
 //                           TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY); 
 //                           TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);                                
 //                           TRS.add_fieldmsg(out_node, "OINV_OUT_TIME", MP_STR, sizeof(MTIVLOTSTS.OINV_OUT_TIME), MTIVLOTSTS.OINV_OUT_TIME); 
 //                           TRS.add_dberrmsg(out_node, DB_error_msg);

 //                           gs_log_type.type = MP_LOG_ERROR;
 //                           gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //                           gs_log_type.category = MP_LOG_CATE_SETUP;

 //                           COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
 //                           return MP_FALSE; 
 //                       } 
 //                   }
 //               }
 //               else if (DB_error_code == DB_NOT_FOUND && COM_isnullspace(MTIVLOTSTS_O.INV_CMF_19) == MP_FALSE)
 //               {
 //                   /*updating the new attached inv lot's tank*/
 //                   DBC_init_mtivlotsts(&MTIVLOTSTS);
 //                   memcpy(MTIVLOTSTS.FACTORY, MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY));
 //                   memcpy(MTIVLOTSTS.LOT_ID, MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID));
 //                   memcpy(MTIVLOTSTS.OPER, "M0050", strlen("M0050"));
 //                   DBC_select_mtivlotsts(4, &MTIVLOTSTS);
 //                   if(DB_error_code == DB_SUCCESS)
 //                   {
 //                       memcpy(MTIVLOTSTS.INV_CMF_19, MTIVLOTSTS_O.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
 //                       DBC_update_mtivlotsts(3, &MTIVLOTSTS);
 //                       if(DB_error_code != DB_SUCCESS)
 //                       { 
 //                           strcpy(s_msg_code, "TAP-0004"); 
 //                           TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT", MP_NVST); 
 //                           TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY); 
 //                           TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);                                
 //                           TRS.add_fieldmsg(out_node, "OINV_OUT_TIME", MP_STR, sizeof(MTIVLOTSTS.OINV_OUT_TIME), MTIVLOTSTS.OINV_OUT_TIME); 
 //                           TRS.add_dberrmsg(out_node, DB_error_msg);

 //                           gs_log_type.type = MP_LOG_ERROR;
 //                           gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //                           gs_log_type.category = MP_LOG_CATE_SETUP;

 //                           COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
 //                           return MP_FALSE; 
 //                       } 
 //                   }
 //               }
 //           }
	//	}
	//}
	//else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
	//{
	//	mat_list = TRS.get_list(in_node, "MAT_LIST");
	//	for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
	//	{
	//		TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, IN_FACTORY);
	//		TRS.copy(MTAPRESMLT.RES_ID, sizeof(MTAPRESMLT.RES_ID), in_node, "RES_ID");
	//		TRS.copy(MTAPRESMLT.MAT_LOT_ID, sizeof(MTAPRESMLT.MAT_LOT_ID), mat_list[i], "MAT_LOT_ID");
	//		TRS.copy(MTAPRESMLT.MAT_ID, sizeof(MTAPRESMLT.MAT_ID), mat_list[i], "MAT_ID");

	//		//[Add by Aaron 2013-8-3]
	//		DBC_select_mtapresmlt(1, &MTAPRESMLT);
	//		if(DB_error_code != DB_SUCCESS)
	//		{
	//			if(DB_error_code == DB_NOT_FOUND)
	//			{
	//				strcpy(s_msg_code, "INV-0022");             
	//				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
	//			}
	//			else 
	//			{
	//				strcpy(s_msg_code, "INV-0004");            
	//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//			}

	//			TRS.add_fieldmsg(out_node, "MTAPRESMLT SELECT", MP_NVST);
	//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPRESMLT.FACTORY), MTAPRESMLT.FACTORY);
	//			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTAPRESMLT.RES_ID), MTAPRESMLT.RES_ID);
	//			TRS.add_fieldmsg(out_node, "MAT_LOT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_LOT_ID), MTAPRESMLT.MAT_LOT_ID);
	//			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_ID), MTAPRESMLT.MAT_ID);
	//			TRS.add_dberrmsg(out_node, DB_error_msg);

	//			gs_log_type.type = MP_LOG_ERROR;
	//			gs_log_type.category = MP_LOG_CATE_TRANS;
	//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//			return MP_FALSE;
	//		}

	//		if(MTAPRESMLT.INPUT_QTY >= TRS.get_double(in_node, "OUT_QTY"))
	//		{
	//			DBC_delete_mtapresmlt(1, &MTAPRESMLT);
	//			if(DB_error_code != DB_SUCCESS)
	//			{ 
	//				strcpy(s_msg_code, "TAP-0004"); 
	//				TRS.add_fieldmsg(out_node, "MTAPRESMLT DELETE", MP_NVST); 
	//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPRESMLT.FACTORY), MTAPRESMLT.FACTORY); 
	//				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTAPRESMLT.RES_ID), MTAPRESMLT.RES_ID); 
	//				TRS.add_fieldmsg(out_node, "MAT_LOT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_LOT_ID), MTAPRESMLT.MAT_LOT_ID); 
	//				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_ID), MTAPRESMLT.MAT_ID); 
	//				TRS.add_dberrmsg(out_node, DB_error_msg);

	//				gs_log_type.type = MP_LOG_ERROR;
	//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//				gs_log_type.category = MP_LOG_CATE_SETUP;

	//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
	//				return MP_FALSE; 
	//			}
	//		}
	//		else
	//		{
	//			strcpy(s_msg_code, "INV-0062");
	//			TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);
	//			TRS.add_fieldmsg(out_node, "MOVE_QTY_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY"));

	//			gs_log_type.type = MP_LOG_ERROR;
	//			gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//			gs_log_type.category = MP_LOG_CATE_TRANS;
	//			return MP_FALSE;
	//		}

	//		//[Delete by Aaron 2013-8-3]
	//		//DBC_delete_mtapresmlt(1, &MTAPRESMLT);
	//		//[Delete by Aaron 2013-8-3]
	//		/*if(DB_error_code != DB_SUCCESS)
	//		{ 
	//			strcpy(s_msg_code, "TAP-0004"); 
	//			TRS.add_fieldmsg(out_node, "MTAPRESMLT DELETE", MP_NVST); 
	//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTAPRESMLT.FACTORY), MTAPRESMLT.FACTORY); 
	//			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MTAPRESMLT.RES_ID), MTAPRESMLT.RES_ID); 
	//			TRS.add_fieldmsg(out_node, "MAT_LOT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_LOT_ID), MTAPRESMLT.MAT_LOT_ID); 
	//			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTAPRESMLT.MAT_ID), MTAPRESMLT.MAT_ID); 
	//			TRS.add_dberrmsg(out_node, DB_error_msg);

	//			gs_log_type.type = MP_LOG_ERROR;
	//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//			gs_log_type.category = MP_LOG_CATE_SETUP;

	//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
	//			return MP_FALSE; 
	//		}*/

	//		DBC_init_mtapresmlt(&MTAPRESMLT_T);
	//		TRS.copy(MTAPRESMLT_T.FACTORY, sizeof(MTAPRESMLT_T.FACTORY), in_node, IN_FACTORY);
	//		TRS.copy(MTAPRESMLT_T.MAT_LOT_ID, sizeof(MTAPRESMLT_T.MAT_LOT_ID), mat_list[i], "MAT_LOT_ID");

	//		if(DBC_select_mtapresmlt_scalar(2, &MTAPRESMLT_T)==0)
	//		{
	//			DBC_init_mtivoprdef(&MTIVOPRDEF);
	//			memcpy(MTIVOPRDEF.FACTORY, MTAPRESMLT.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
	//			memcpy(MTIVOPRDEF.OPER_GRP_1, "Y", 1);
	//			DBC_select_mtivoprdef(901,&MTIVOPRDEF);

	//			//UPDATE Inventory LotID Terminate Flag = 'Y';
	//			DBC_init_mtivlotsts(&MTIVLOTSTS);
	//			memcpy(MTIVLOTSTS.FACTORY, MTAPRESMLT.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
	//			memcpy(MTIVLOTSTS.LOT_ID, MTAPRESMLT.MAT_LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	//			//TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
	//			memcpy(MTIVLOTSTS.OPER, MTIVOPRDEF.OPER, sizeof(MTIVLOTSTS.OPER));
	//			DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS);
	//			if(DB_error_code != DB_SUCCESS)
	//			{
	//				if(DB_error_code == DB_NOT_FOUND)
	//				{
	//					strcpy(s_msg_code, "INV-0022");             
	//					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
	//				}
	//				else 
	//				{
	//					strcpy(s_msg_code, "INV-0004");            
	//					gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//				}

	//				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
	//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
	//				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
	//				TRS.add_dberrmsg(out_node, DB_error_msg);

	//				gs_log_type.type = MP_LOG_ERROR;
	//				gs_log_type.category = MP_LOG_CATE_TRANS;
	//        		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//				return MP_FALSE;
	//			}
	//			//MTIVLOTSTS.TERM_FLAG = 'Y';//Detach = Terminate
	//			MTIVLOTSTS.LOT_DEL_FLAG='Y';
 //               memset(MTIVLOTSTS.INV_CMF_19, ' ', sizeof(MTIVLOTSTS.INV_CMF_19));  //clear the tank info
	//			DBC_update_mtivlotsts(3, &MTIVLOTSTS);
	//			if(DB_error_code != DB_SUCCESS)
	//			{
	//				strcpy(s_msg_code, "INV-0004");
	//				TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
	//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
	//				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
	//        		TRS.add_fieldmsg(out_node, "EXPIRE_DATE", MP_STR, sizeof(MTIVLOTSTS.EXPIRE_DATE), MTIVLOTSTS.EXPIRE_DATE);
	//				TRS.add_dberrmsg(out_node, DB_error_msg);

	//				gs_log_type.type = MP_LOG_ERROR;
	//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//				gs_log_type.category = MP_LOG_CATE_COMMON;
	//				return MP_FALSE;
	//			}
	//		}
	//	}
	//}

	//if(COM_proc_user_routine("TAP", "TIV_Assign_Material_To_Resource",
	//						 MP_UPOINT_AFTER, 
	//						 in_node,
	//						 out_node) == MP_FALSE)     return MP_FALSE;

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	Tap_assign_material_to_resource_Validation()
		- Main sub function of "TAP_UPDATE_TIV_ASSIGN_MATERIAL_TO_RESOURCE" function
		- Check the condition for create/update/delete Tap_assign_material_to_resource & vbCrLf	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Assign_Material_To_Resource_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	//struct MWIPFACDEF_TAG MWIPFACDEF;
 //   struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MATRNAMSTS_TAG MATRNAMSTS;
	//struct MWIPMATDEF_TAG MWIPMATDEF;
	//struct MWIPMATDEF_TAG MWIPMATDEF;
	////struct MTAPRESMLT_TAG MTAPRESMLT;
	//struct MTIVOPRDEF_TAG MTIVOPRDEF;
	//struct MRASRESDEF_TAG MRASRESDEF;
	//struct MTIVLOTSTS_TAG MTIVLOTSTS_T;

 //   TRSNode **mat_list;

 //   int i;
	//char s_sys_time[14];
	//char s_attr_value[1000];

	///* ProcStep Validation */
	//if(COM_service_validation(s_msg_code,
	//						in_node,
	//						out_node,
	//						TRS.get_procstep(in_node),
	//						"IUD") == MP_FALSE)
	//{
	//	return MP_FALSE;
	//}

	///* Factory Validation */
	//if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	//{
	//	strcpy(s_msg_code, "TAP-0001");
	//	TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

	//	gs_log_type.type = MP_LOG_ERROR;
	//	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//	gs_log_type.category = MP_LOG_CATE_SETUP;
	//	return MP_FALSE;
	//}
	//else
	//{
	//	DBC_init_mwipfacdef(&MWIPFACDEF);
	//	TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
	//	DBC_select_mwipfacdef(1, &MWIPFACDEF);
	//	if(DB_error_code != DB_SUCCESS)
	//	{
	//		strcpy(s_msg_code, "WIP-0005");
	//		TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
	//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
	//		TRS.add_dberrmsg(out_node, DB_error_msg);

	//		gs_log_type.type = MP_LOG_ERROR;
	//		gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//		gs_log_type.category = MP_LOG_CATE_SETUP;
	//		return MP_FALSE;
	//	}
	//}

	///* Res_id Validation */
	//if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
	//{
	//	strcpy(s_msg_code, "TAP-0001");
	//	TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

	//	gs_log_type.type = MP_LOG_ERROR;
	//	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//	gs_log_type.category = MP_LOG_CATE_VIEW;
	//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//	return MP_FALSE;
	//}

	//memset(s_sys_time, ' ', sizeof(s_sys_time));
	// DB_get_systime(s_sys_time);
 //   if(DB_error_code != DB_SUCCESS)
 //   {
 //       strcpy(s_msg_code, "WIP-0004");
 //       TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
 //       TRS.add_dberrmsg(out_node, DB_error_msg);

 //       gs_log_type.type = MP_LOG_ERROR;
 //       gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //       gs_log_type.category = MP_LOG_CATE_TRANS;

 //       COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
 //       return MP_FALSE;
 //   }   

 //   mat_list = TRS.get_list(in_node, "MAT_LIST");
	//for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
	//{
 //       /* INV_lot_id Validation */
	//    if(COM_isnullspace(TRS.get_string(mat_list[i], "MAT_LOT_ID")) == MP_TRUE)
	//    {
	//    	strcpy(s_msg_code, "TAP-0001");
	//    	TRS.add_fieldmsg(out_node, "MAT_LOT_ID", MP_NVST);

	//    	gs_log_type.type = MP_LOG_ERROR;
	//    	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//    	gs_log_type.category = MP_LOG_CATE_VIEW;
	//    	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//    	return MP_FALSE;
	//    }

 //       /* Mat_id Validation */
	//    if(COM_isnullspace(TRS.get_string(mat_list[i], "MAT_ID")) == MP_TRUE)
	//    {
	//    	strcpy(s_msg_code, "TAP-0001");
	//    	TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);

	//    	gs_log_type.type = MP_LOG_ERROR;
	//    	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//    	gs_log_type.category = MP_LOG_CATE_VIEW;
	//    	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//    	return MP_FALSE;
	//    }

 //       if(TRS.get_char(in_node, "DETACH_FLAG")!='Y')
 //       {
	//		if(COM_isnullspace(TRS.get_string(mat_list[i],"OPER"))==MP_TRUE)
	//			TRS.set_string(mat_list[i],"OPER", MP_INV_OPER_WOPR);
	//		
 //           /*Lot Validation*/
 //           DBC_init_mtivlotsts(&MTIVLOTSTS);
 //           TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
 //           TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), mat_list[i],"MAT_LOT_ID");
	//		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), mat_list[i],"OPER");
	//		
 //           DBC_select_mtivlotsts(9, &MTIVLOTSTS);
	//	    if(DB_error_code != DB_SUCCESS) 
	//	    {
	//	        if(DB_error_code == DB_NOT_FOUND)
	//	        {
	//	            strcpy(s_msg_code, "INV-0030");
	//	            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
	//	        }
	//	        else 
	//	        {
	//	            strcpy(s_msg_code, "INV-0004");
	//	            gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//	            TRS.add_dberrmsg(out_node, DB_error_msg);
	//	        }

	//	        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
	//	        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
	//	        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
	//	        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

	//	        gs_log_type.type = MP_LOG_ERROR;
	//	        gs_log_type.category = MP_LOG_CATE_VIEW;

	//	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//	        return MP_FALSE;
	//	    }


	//		//==============================================================================================================
	//		//Block by Kelly Jung 20170310
	//		//possible to use.....remain...don't remove
	//		//==============================================================================================================
	//		//if(INV_Check_Factory(s_msg_code,"MP_CheckINVMaterialValidation",TRS.get_factory(in_node)) == MP_TRUE)
	//		//{
	//		//	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//		//	// Assgin 되는 Inv_Lot에 대해서 Validation 추가 (Aging Time, QTime, Expire Date) bs.kwak 20130525
	//		//	// Adapt Bs.kwak
	//		//	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//		//	DBC_init_mrasresdef(&MRASRESDEF);
	//		//	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
	//		//	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID),in_node, "RES_ID");
	//		//	DBC_select_mrasresdef(1,&MRASRESDEF);
	//		//	if(DB_error_code != DB_SUCCESS)
	//		//	{
	//		//		strcpy(s_msg_code, "TAP-0004");
	//		//		TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
	//		//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
	//		//		TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

	//		//		TRS.add_dberrmsg(out_node, DB_error_msg);

	//		//		gs_log_type.type = MP_LOG_ERROR;
	//		//		gs_log_type.e_type = MP_LOG_E_SYSTEM; 
	//		//		gs_log_type.category = MP_LOG_CATE_TRANS;
	//		//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//		return MP_FALSE;
	//		//	}

	//		//	DBC_init_mwipmatdef(&MWIPMATDEF);
	//		//	memcpy(MWIPMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MWIPMATDEF.FACTORY));
	//		//	memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	//		//	MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
	//		//	DBC_select_mwipmatdef(1,&MWIPMATDEF);
	//		//	if(DB_error_code != DB_SUCCESS) 
	//		//	{
	//		//		strcpy(s_msg_code, "TAP-0004");
	//		//		TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
	//		//		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
	//		//		TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
	//		//		TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT,MWIPMATDEF.MAT_VER);

	//		//		gs_log_type.type = MP_LOG_ERROR;
	//		//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//		//		gs_log_type.category = MP_LOG_CATE_TRANS;
	//		//		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//		return MP_FALSE;
	//		//	}

	//		//	// Check inherit the Queue Time
	//		//	GetAttributeValue('1',MTIVLOTSTS.FACTORY, "INV_MATERIAL_TYPE", "QTime", MWIPMATDEF.MAT_TYPE, s_attr_value);

	//		//	if(memcmp(s_attr_value,"Y",1) == 0)
	//		//	{
	//		//		DBC_init_mtivlotsts(&MTIVLOTSTS_T);
	//		//		memcpy(MTIVLOTSTS_T.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS_T.FACTORY));
 //  //                 memcpy(MTIVLOTSTS_T.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS_T.MAT_ID));
	//		//		memcpy(MTIVLOTSTS_T.OPER, MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS_T.OPER));
	//		//		memcpy(MTIVLOTSTS_T.ADD_ORDER_LINE_1, MRASRESDEF.RES_ID, sizeof(MTIVLOTSTS_T.ADD_ORDER_LINE_1)); // ADD_ORDER_LINE_1 필드에 Resource 값 넣어줌.
	//		//		DBC_select_mtivlotsts(901,&MTIVLOTSTS_T);
	//		//	    if(DB_error_code == DB_SUCCESS) 
	//		//	    {
	//		//			if(INV_Check_QTime(s_msg_code,in_node,out_node,"Queue Time",'1',&MRASRESDEF,&MTIVLOTSTS_T,MTIVLOTSTS_T.OINV_OUT_TIME,s_sys_time) == MP_FALSE)
	//		//		    {
	//		//			    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//			    return MP_FALSE;
	//		//		    }
	//		//	    }
	//		//		else
	//		//	    {
 //  //                     if(INV_Check_QTime(s_msg_code,in_node,out_node,"Queue Time",'1',&MRASRESDEF,&MTIVLOTSTS,"",s_sys_time) == MP_FALSE)
	//		//		    {
	//		//			    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//			    return MP_FALSE;
	//		//		    }
	//		//	    }
 //  //                 DBC_init_mtivlotsts(&MTIVLOTSTS_T);
	//		//		memcpy(MTIVLOTSTS_T.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS_T.FACTORY));
 //  //                 memcpy(MTIVLOTSTS_T.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS_T.MAT_ID));
	//		//		memcpy(MTIVLOTSTS_T.OPER, MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS_T.OPER));
	//		//		memcpy(MTIVLOTSTS_T.ADD_ORDER_LINE_1, MRASRESDEF.RES_ID, sizeof(MTIVLOTSTS_T.ADD_ORDER_LINE_1)); // ADD_ORDER_LINE_1 필드에 Resource 값 넣어줌.
	//		//		DBC_select_mtivlotsts(902,&MTIVLOTSTS_T);
	//		//	    if(DB_error_code == DB_SUCCESS) 
	//		//	    {
	//		//			if(INV_Check_Aging_Time(s_msg_code,in_node,out_node,"Aging Time",'1',&MRASRESDEF,&MTIVLOTSTS_T,s_sys_time) == MP_FALSE)
	//		//	        {
	//		//		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//		        return MP_FALSE;
	//		//	        }
	//		//	    }
	//		//		else
	//		//	    {
 //  //                     if(INV_Check_Aging_Time(s_msg_code,in_node,out_node,"Aging Time",'1',&MRASRESDEF,&MTIVLOTSTS,s_sys_time) == MP_FALSE)
	//		//	        {
	//		//		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//		        return MP_FALSE;
	//		//	        }
	//		//	    }
	//		//	}
	//		//	else
	//		//	{
	//		//		if(INV_Check_QTime(s_msg_code,in_node,out_node,"Queue Time",'1',&MRASRESDEF,&MTIVLOTSTS,"",s_sys_time) == MP_FALSE)
	//		//		{
	//		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//			return MP_FALSE;
	//		//		}
 //  //                 if(INV_Check_Aging_Time(s_msg_code,in_node,out_node,"Aging Time",'1',&MRASRESDEF,&MTIVLOTSTS,s_sys_time) == MP_FALSE)
	//		//	    {
	//		//		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//		    return MP_FALSE;
	//		//	    }
	//		//	}

	//		//	

	//		//	if(COM_isnullspace(MTIVLOTSTS.EXPIRE_DATE) == MP_FALSE)
	//		//	{
	//		//		if(INV_Check_Expire_Date(s_msg_code,in_node,out_node,&MTIVLOTSTS,s_sys_time) == MP_FALSE)
	//		//		{
	//		//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//		//			return MP_FALSE;
	//		//		}
	//		//	}
	//		//}
	//		//==============================================================================================================
	//		//Block by Kelly Jung 20170310
	//		//possible to use.....remain...don't remove
	//		//==============================================================================================================
	//	}

 //       /*Lot Qty Validation*/
 //       if(TRS.get_procstep(in_node)==MP_STEP_CREATE)
 //       {
 //           if(MTIVLOTSTS.QTY_1 < TRS.get_double(mat_list[i], "INPUT_QTY"))
 //           {
 //               strcpy(s_msg_code, "TAP-0032");
	//        	TRS.add_fieldmsg(out_node, "INPUT_QTY", MP_NVST);

	//        	gs_log_type.type = MP_LOG_ERROR;
	//        	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//        	gs_log_type.category = MP_LOG_CATE_VIEW;
	//        	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//        	return MP_FALSE;
 //           }
 //           else if(TRS.get_double(mat_list[i], "INPUT_QTY") <= 0)
 //           {
 //               strcpy(s_msg_code, "TAP-0033");
	//        	TRS.add_fieldmsg(out_node, "INPUT_QTY", MP_NVST);

	//        	gs_log_type.type = MP_LOG_ERROR;
	//        	gs_log_type.e_type = MP_LOG_E_VALIDATION;
	//        	gs_log_type.category = MP_LOG_CATE_VIEW;
	//        	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//        	return MP_FALSE;
 //           }
 //       }

	//	// 기존로직 
	//	// 같은 Material Type중 수량이 제일 큰 자재 Lot을 가지고 Validation하는 로직 이었음 
	//	// 자재 Validation이 변경되면서 사용하지 않음
	//	
	//	/*if(INV_Check_Factory(s_msg_code,"MP_CheckINVMaterialValidation",TRS.get_factory(in_node)) == MP_TRUE)
	//	{
	//		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//		// 기존에 Assgin 되어있는 Inv_Lot에 대해서 Validation 추가 (Window Time, Expire Date) bs.kwak 20130525
	//		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//		DBC_init_mwipmatdef(&MWIPMATDEF);
	//		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
	//		TRS.copy(MWIPMATDEF.MAT_GRP_1, sizeof(MWIPMATDEF.MAT_GRP_1), in_node, "RES_ID"); // RES_ID를 넣어줌.
	//		DBC_open_mwipmatdef(903, &MWIPMATDEF);
	//		if(DB_error_code != DB_SUCCESS)
	//		{
	//			strcpy(s_msg_code, "TAP-0004");
	//			TRS.add_fieldmsg(out_node, "MWIPMATDEF OPEN", MP_NVST);
	//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
	//			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MWIPMATDEF.MAT_GRP_1), MWIPMATDEF.MAT_GRP_1);
	//			TRS.add_dberrmsg(out_node, DB_error_msg);

	//			gs_log_type.type = MP_LOG_ERROR;
	//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//			gs_log_type.category = MP_LOG_CATE_VIEW;
	//			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//			return MP_FALSE;
	//		}

	//		while(1)
	//		{
	//			DBC_fetch_mwipmatdef(903, &MWIPMATDEF);
	//			if(DB_error_code == DB_NOT_FOUND)
	//			{
	//				DBC_close_mwipmatdef(903);
	//				break;
	//			}
	//			else if(DB_error_code != DB_SUCCESS)
	//			{
	//				strcpy(s_msg_code, "BOM-0004");
	//				TRS.add_fieldmsg(out_node, "MWIPMATFLW FETCH", MP_NVST);
	//				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
	//				TRS.add_dberrmsg(out_node, DB_error_msg);

	//				gs_log_type.type = MP_LOG_ERROR;
	//				gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//				gs_log_type.category = MP_LOG_CATE_VIEW;
	//				DBC_close_mwipmatdef(903);
	//				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//				return MP_FALSE;
	//			}

	//			DBC_init_mtapresmlt(&MTAPRESMLT);
	//			TRS.copy(MTAPRESMLT.FACTORY, sizeof(MTAPRESMLT.FACTORY), in_node, IN_FACTORY);
	//			TRS.copy(MTAPRESMLT.RES_ID, sizeof(MTAPRESMLT.RES_ID), in_node, "RES_ID");
	//			memcpy(MTAPRESMLT.CREATE_USER_ID,MWIPMATDEF.MAT_TYPE, sizeof(MTAPRESMLT.CREATE_USER_ID)); // 해당 필드에 mat_type넣어줌.
	//			DBC_select_mtapresmlt(901,&MTAPRESMLT);
	//			if(DB_error_code == DB_SUCCESS)
	//			{
	//				DBC_init_mtivoprdef(&MTIVOPRDEF);
	//				memcpy(MTIVOPRDEF.FACTORY, MTAPRESMLT.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
	//				memcpy(MTIVOPRDEF.OPER_GRP_1, "Y", 1);
	//				DBC_select_mtivoprdef(901,&MTIVOPRDEF);

	//				DBC_init_mtivlotsts(&MTIVLOTSTS);
	//				memcpy(MTIVLOTSTS.FACTORY, MTAPRESMLT.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
	//				memcpy(MTIVLOTSTS.LOT_ID, MTAPRESMLT.MAT_LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	//				memcpy(MTIVLOTSTS.OPER, MTIVOPRDEF.OPER, sizeof(MTIVLOTSTS.OPER));
	//				DBC_select_mtivlotsts(4,&MTIVLOTSTS);
	//				if(DB_error_code != DB_SUCCESS)
	//				{
	//					strcpy(s_msg_code, "TAP-0004");
	//					TRS.add_fieldmsg(out_node, "MTIVLOTSTS FETCH", MP_NVST);
	//					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
	//					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
	//					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
	//					TRS.add_dberrmsg(out_node, DB_error_msg);

	//					gs_log_type.type = MP_LOG_ERROR;
	//					gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//					gs_log_type.category = MP_LOG_CATE_VIEW;
	//					DBC_close_mwipmatdef(903);
	//					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//					return MP_FALSE;
	//				}

	//				DBC_init_matrnamsts(&MATRNAMSTS);
	//				memcpy(MATRNAMSTS.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY));
	//				memcpy(MATRNAMSTS.ATTR_TYPE, "INV_MATERIAL_TYPE", strlen("INV_MATERIAL_TYPE"));
	//				memcpy(MATRNAMSTS.ATTR_NAME, "AgingTime", strlen("AgingTime"));
	//				memcpy(MATRNAMSTS.ATTR_KEY, MWIPMATDEF.MAT_TYPE, sizeof(MWIPMATDEF.MAT_TYPE));
	//				DBC_select_matrnamsts(1,&MATRNAMSTS);
	//				if(DB_error_code == DB_SUCCESS) 
	//				{
	//					if(INV_Check_Aging_Time(s_msg_code,in_node,out_node,&MTIVLOTSTS,&MATRNAMSTS,s_sys_time) == MP_FALSE)
	//					{
	//						DBC_close_mwipmatdef(903);
	//						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//						return MP_FALSE;
	//					}
	//				}

	//				if(COM_isnullspace(MTIVLOTSTS.EXPIRE_DATE) == MP_FALSE)
	//				{
	//					if(INV_Check_Expire_Date(s_msg_code,in_node,out_node,&MTIVLOTSTS,s_sys_time) == MP_FALSE)
	//					{
	//						DBC_close_mwipmatdef(903);
	//						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//						return MP_FALSE;
	//					}
	//				}
	//			}
	//		}
	//	}*/
 //   }

	return MP_TRUE;
}