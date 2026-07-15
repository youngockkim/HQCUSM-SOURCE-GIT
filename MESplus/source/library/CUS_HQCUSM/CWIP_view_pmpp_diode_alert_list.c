/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_View_Pmpp_Diode_Alert_List.c
	Description : View Pmpp/Diode Alert List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Pmpp_Diode_Alert_List()
		- CWIP_VIEW_PMPP_DIODE_ALERT_LIST()
	Detail Description
		- CWIP_VIEW_PMPP_DIODE_ALERT_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2020/08/05  Lim Yeon Keun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"


/*******************************************************************************
	CWIP_View_Pmpp_Diode_Alert_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Pmpp_Diode_Alert_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_PMPP_DIODE_ALERT_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_PMPP_DIODE_ALERT_LIST", out_node);

	if (i_ret == MP_TRUE)
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
	CWIP_VIEW_PMPP_DIODE_ALERT_LIST()
		- Main sub function of "CWIP_View_Pmpp_Diode_Alert_List" function
		- View Silicone List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_PMPP_DIODE_ALERT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPPMPHIS_TAG CWIPPMPHIS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_LINE;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_D_POSITION;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_SHIFT;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_M_ISSUE_TYPE;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_FRAME_EQ;

	struct MGCMTBLDAT_TAG MGCMTBLDAT_SOLDERING;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_M_DEFECT_TYPE;

    TRSNode *list_item;

    int i_step;

    LOG_head("CWIP_VIEW_PMPP_DIODE_ALERT_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(TRS.get_procstep(in_node) == '1') 
	{
		if(TRS.get_boolean(in_node, "UPDATE_YN") == MP_TRUE){
			//i_step = 2;
			i_step = 4;
		}else{
			//i_step = 1;
			i_step = 3;
		}

		/* Select Area by Line Code */
		CDB_init_cwippmphis(&CWIPPMPHIS);

		TRS.copy(CWIPPMPHIS.FACTORY, sizeof(CWIPPMPHIS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPPMPHIS.WORK_DATE, sizeof(CWIPPMPHIS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPPMPHIS.LINE_ID, sizeof(CWIPPMPHIS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION), in_node, "DEFECT_POSITION");
		TRS.copy(CWIPPMPHIS.RES_ID, sizeof(CWIPPMPHIS.RES_ID), in_node, "RES_ID");
		TRS.copy(CWIPPMPHIS.WORK_SHIFT, sizeof(CWIPPMPHIS.WORK_SHIFT), in_node, "WORK_SHIFT");
		TRS.copy(CWIPPMPHIS.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE), in_node, "MACHINE_ISSUE_TYPE");
		
		//IS-20-09-118 IS-20-09-118 
		//OI에서 SOLDERING 미 선택시 '%'로 보내주나 , OI와 서비스 반영 간격을 고려하여
		//SOLDERING 값이 NULL일 경우 '%'를 붙여 준다.
		if(COM_isnullspace(TRS.get_string(in_node, "SOLDERING")) == MP_TRUE)
		{
			memcpy(CWIPPMPHIS.CMF_1, "%", strlen("%"));

		}
		else
		{
			TRS.copy(CWIPPMPHIS.CMF_1, sizeof(CWIPPMPHIS.CMF_1), in_node, "SOLDERING"); //IS-20-09-118 IS-20-09-118 
		}

		
		//IS-20-09-118 IS-20-09-118 

		//CWIPPMPHIS 조회 기준 변경 : WORK_DATE->INS_TIME
		CDB_open_cwippmphis(i_step, &CWIPPMPHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CWIPPMPHIS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS.FACTORY), CWIPPMPHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPMPHIS.WORK_DATE), CWIPPMPHIS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPMPHIS.LINE_ID), CWIPPMPHIS.LINE_ID);
			TRS.add_fieldmsg(out_node, "DEFECT_POSITION", MP_STR, sizeof(CWIPPMPHIS.DEFECT_POSITION), CWIPPMPHIS.DEFECT_POSITION);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPMPHIS.RES_ID), CWIPPMPHIS.RES_ID);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPPMPHIS.WORK_SHIFT), CWIPPMPHIS.WORK_SHIFT);
			TRS.add_fieldmsg(out_node, "MACHINE_ISSUE_TYPE", MP_STR, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE), CWIPPMPHIS.MACHINE_ISSUE_TYPE);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		while(1)
		{
			CDB_fetch_cwippmphis(i_step, &CWIPPMPHIS);

			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwippmphis(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "CWIPPMPHIS FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS.FACTORY), CWIPPMPHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPMPHIS.WORK_DATE), CWIPPMPHIS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPMPHIS.LINE_ID), CWIPPMPHIS.LINE_ID);
				TRS.add_fieldmsg(out_node, "DEFECT_POSITION", MP_STR, sizeof(CWIPPMPHIS.DEFECT_POSITION), CWIPPMPHIS.DEFECT_POSITION);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPMPHIS.RES_ID), CWIPPMPHIS.RES_ID);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPPMPHIS.WORK_SHIFT), CWIPPMPHIS.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "MACHINE_ISSUE_TYPE", MP_STR, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE), CWIPPMPHIS.MACHINE_ISSUE_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cwippmphis(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				/*
				TRS.add_string(out_node, "NEXT_KEY_1", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
				TRS.add_string(out_node, "NEXT_KEY_2", MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2));
				TRS.add_string(out_node, "NEXT_KEY_3", MGCMTBLDAT.KEY_3, sizeof(MGCMTBLDAT.KEY_3));
				TRS.add_string(out_node, "NEXT_KEY_4", MGCMTBLDAT.KEY_4, sizeof(MGCMTBLDAT.KEY_4));
				TRS.add_string(out_node, "NEXT_KEY_5", MGCMTBLDAT.KEY_5, sizeof(MGCMTBLDAT.KEY_5));
				TRS.add_string(out_node, "NEXT_KEY_6", MGCMTBLDAT.KEY_6, sizeof(MGCMTBLDAT.KEY_6));
				TRS.add_string(out_node, "NEXT_KEY_7", MGCMTBLDAT.KEY_7, sizeof(MGCMTBLDAT.KEY_7));
				TRS.add_string(out_node, "NEXT_KEY_8", MGCMTBLDAT.KEY_8, sizeof(MGCMTBLDAT.KEY_8));
				TRS.add_string(out_node, "NEXT_KEY_9", MGCMTBLDAT.KEY_9, sizeof(MGCMTBLDAT.KEY_9));
				TRS.add_string(out_node, "NEXT_KEY_10", MGCMTBLDAT.KEY_10, sizeof(MGCMTBLDAT.KEY_10));
				*/
				CDB_close_cwippmphis(i_step);
				break;
			}
			
			DBC_init_mgcmtbldat(&MGCMTBLDAT_LINE);
			memcpy(MGCMTBLDAT_LINE.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_LINE.TABLE_NAME,"@LINE_CODE", strlen("@LINE_CODE"));
			memcpy(MGCMTBLDAT_LINE.KEY_1,CWIPPMPHIS.LINE_ID, sizeof(CWIPPMPHIS.LINE_ID));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT_LINE);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "GCM-0008");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT_LINE.FACTORY), MGCMTBLDAT_LINE.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT_LINE.TABLE_NAME), MGCMTBLDAT_LINE.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT_LINE.KEY_1), MGCMTBLDAT_LINE.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				CDB_close_cwippmphis(i_step);
				return MP_FALSE;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_D_POSITION);
			memcpy(MGCMTBLDAT_D_POSITION.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_D_POSITION.TABLE_NAME,"@DETECT_POSITION", strlen("@DETECT_POSITION"));
			memcpy(MGCMTBLDAT_D_POSITION.KEY_1,CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_D_POSITION);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_M_ISSUE_TYPE);
			memcpy(MGCMTBLDAT_M_ISSUE_TYPE.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_M_ISSUE_TYPE.TABLE_NAME,"@MACHINE_ISSUE_TYPE", strlen("@MACHINE_ISSUE_TYPE"));
			memcpy(MGCMTBLDAT_M_ISSUE_TYPE.KEY_1,CWIPPMPHIS.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_M_ISSUE_TYPE);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_SHIFT);
			memcpy(MGCMTBLDAT_SHIFT.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_SHIFT.TABLE_NAME,"@SHIFT", strlen("@SHIFT"));
			memcpy(MGCMTBLDAT_SHIFT.KEY_1,CWIPPMPHIS.WORK_SHIFT, sizeof(CWIPPMPHIS.WORK_SHIFT));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_SHIFT);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}
			
			DBC_init_mgcmtbldat(&MGCMTBLDAT_FRAME_EQ);
			memcpy(MGCMTBLDAT_FRAME_EQ.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_FRAME_EQ.TABLE_NAME,"@FRAME_EQUIPMENT", strlen("@FRAME_EQUIPMENT"));
			memcpy(MGCMTBLDAT_FRAME_EQ.KEY_1,CWIPPMPHIS.RES_ID, sizeof(CWIPPMPHIS.RES_ID));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_FRAME_EQ);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}
			
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "LINE", MGCMTBLDAT_LINE.DATA_1, sizeof(MGCMTBLDAT_LINE.DATA_1));
			TRS.add_string(list_item, "MODULE_ID", CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID));
			TRS.add_string(list_item, "PMPP", CWIPPMPHIS.PMPP, sizeof(CWIPPMPHIS.PMPP));
			TRS.add_string(list_item, "DIODE", CWIPPMPHIS.DIODE, sizeof(CWIPPMPHIS.DIODE));
			TRS.add_string(list_item, "RES_ID", MGCMTBLDAT_FRAME_EQ.DATA_1, sizeof(MGCMTBLDAT_FRAME_EQ.DATA_1));
			TRS.add_string(list_item, "INS_TIME", CWIPPMPHIS.INS_TIME, sizeof(CWIPPMPHIS.INS_TIME));
			TRS.add_string(list_item, "WORK_DATE", CWIPPMPHIS.WORK_DATE, sizeof(CWIPPMPHIS.WORK_DATE));
			TRS.add_string(list_item, "WORK_TIME", CWIPPMPHIS.WORK_TIME, sizeof(CWIPPMPHIS.WORK_TIME));
			TRS.add_string(list_item, "WORK_SHIFT", MGCMTBLDAT_SHIFT.DATA_1, sizeof(MGCMTBLDAT_SHIFT.DATA_1));
			TRS.add_string(list_item, "DEFECT_POSITION", MGCMTBLDAT_D_POSITION.KEY_1, sizeof(MGCMTBLDAT_D_POSITION.KEY_1));
			TRS.add_string(list_item, "MACHINE_ISSUE_TYPE", MGCMTBLDAT_M_ISSUE_TYPE.DATA_1, sizeof(MGCMTBLDAT_M_ISSUE_TYPE.DATA_1));
			TRS.add_string(list_item, "OPERATOR", CWIPPMPHIS.OPERATOR, sizeof(CWIPPMPHIS.OPERATOR));
			TRS.add_string(list_item, "MACHINE_TECHNICIAN", CWIPPMPHIS.MACHINE_TECHNICIAN, sizeof(CWIPPMPHIS.MACHINE_TECHNICIAN));
			TRS.add_string(list_item, "CREATE_USER_ID", CWIPPMPHIS.CREATE_USER_ID, sizeof(CWIPPMPHIS.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CWIPPMPHIS.CREATE_TIME, sizeof(CWIPPMPHIS.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CWIPPMPHIS.UPDATE_USER_ID, sizeof(CWIPPMPHIS.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", CWIPPMPHIS.UPDATE_TIME, sizeof(CWIPPMPHIS.UPDATE_TIME));

			TRS.add_string(list_item, "CMF_1", CWIPPMPHIS.CMF_1, sizeof(CWIPPMPHIS.CMF_1));  //IS-20-09-118 IS-20-09-118 
		}
	}

	if(TRS.get_procstep(in_node) == '2' || TRS.get_procstep(in_node) == '3') 
	{
		if(TRS.get_procstep(in_node) == '2') 
		{
			i_step = 5;
		}
		else
		{
			i_step = 7;
		}

		/* Select Area by Line Code */
		CDB_init_cwippmphis(&CWIPPMPHIS);

		

		TRS.copy(CWIPPMPHIS.FACTORY, sizeof(CWIPPMPHIS.FACTORY), in_node, IN_FACTORY);

		TRS.copy(CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID), in_node, "LOT_ID");
        if(i_step == 5)
        {
            memcpy(CWIPPMPHIS.LOT_ID, "%", strlen("%"));
        }

		TRS.copy(CWIPPMPHIS.WORK_DATE, sizeof(CWIPPMPHIS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CWIPPMPHIS.LINE_ID, sizeof(CWIPPMPHIS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CWIPPMPHIS.RES_ID, sizeof(CWIPPMPHIS.RES_ID), in_node, "RES_ID");
		TRS.copy(CWIPPMPHIS.WORK_SHIFT, sizeof(CWIPPMPHIS.WORK_SHIFT), in_node, "WORK_SHIFT");

		//TRS.copy(CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION), in_node, "DEFECT_POSITION");          // Defect Position
		//TRS.copy(CWIPPMPHIS.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE), in_node, "MACHINE_ISSUE_TYPE"); // Defect Type
		if(COM_isnullspace(TRS.get_string(in_node, "DEFECT_POSITION")) == MP_TRUE) // Defect Position
		{
			memcpy(CWIPPMPHIS.DEFECT_POSITION, "%", strlen("%"));
		}
		else
		{
			TRS.copy(CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION), in_node, "DEFECT_POSITION"); //IS-20-09-118 IS-20-09-118 
		}
		if(COM_isnullspace(TRS.get_string(in_node, "MACHINE_ISSUE_TYPE")) == MP_TRUE) // Defect Type
		{
			memcpy(CWIPPMPHIS.MACHINE_ISSUE_TYPE, "%", strlen("%"));
		}
		else
		{
			TRS.copy(CWIPPMPHIS.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE), in_node, "MACHINE_ISSUE_TYPE");
		}

		//IS-20-09-118 IS-20-09-118 
		//OI에서 SOLDERING 미 선택시 '%'로 보내주나 , OI와 서비스 반영 간격을 고려하여
		//SOLDERING 값이 NULL일 경우 '%'를 붙여 준다.
		if(COM_isnullspace(TRS.get_string(in_node, "SOLDERING")) == MP_TRUE) // Soldering Condition
		{
			memcpy(CWIPPMPHIS.CMF_1, "%", strlen("%"));
		}
		else
		{
			TRS.copy(CWIPPMPHIS.CMF_1, sizeof(CWIPPMPHIS.CMF_1), in_node, "SOLDERING"); //IS-20-09-118 IS-20-09-118 
		}

		
		//IS-20-09-118 IS-20-09-118 

		//CWIPPMPHIS 조회 기준 변경 : WORK_DATE->INS_TIME
		CDB_open_cwippmphis(i_step, &CWIPPMPHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CWIPPMPHIS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS.FACTORY), CWIPPMPHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPMPHIS.WORK_DATE), CWIPPMPHIS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPMPHIS.LINE_ID), CWIPPMPHIS.LINE_ID);
			TRS.add_fieldmsg(out_node, "DEFECT_POSITION", MP_STR, sizeof(CWIPPMPHIS.DEFECT_POSITION), CWIPPMPHIS.DEFECT_POSITION);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPMPHIS.RES_ID), CWIPPMPHIS.RES_ID);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPPMPHIS.WORK_SHIFT), CWIPPMPHIS.WORK_SHIFT);
			TRS.add_fieldmsg(out_node, "MACHINE_ISSUE_TYPE", MP_STR, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE), CWIPPMPHIS.MACHINE_ISSUE_TYPE);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		while(1)
		{
			CDB_fetch_cwippmphis(i_step, &CWIPPMPHIS);

			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwippmphis(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "CWIPPMPHIS FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS.FACTORY), CWIPPMPHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPPMPHIS.WORK_DATE), CWIPPMPHIS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPMPHIS.LINE_ID), CWIPPMPHIS.LINE_ID);
				TRS.add_fieldmsg(out_node, "DEFECT_POSITION", MP_STR, sizeof(CWIPPMPHIS.DEFECT_POSITION), CWIPPMPHIS.DEFECT_POSITION);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPPMPHIS.RES_ID), CWIPPMPHIS.RES_ID);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPPMPHIS.WORK_SHIFT), CWIPPMPHIS.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "MACHINE_ISSUE_TYPE", MP_STR, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE), CWIPPMPHIS.MACHINE_ISSUE_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cwippmphis(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				/*
				TRS.add_string(out_node, "NEXT_KEY_1", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
				TRS.add_string(out_node, "NEXT_KEY_2", MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2));
				TRS.add_string(out_node, "NEXT_KEY_3", MGCMTBLDAT.KEY_3, sizeof(MGCMTBLDAT.KEY_3));
				TRS.add_string(out_node, "NEXT_KEY_4", MGCMTBLDAT.KEY_4, sizeof(MGCMTBLDAT.KEY_4));
				TRS.add_string(out_node, "NEXT_KEY_5", MGCMTBLDAT.KEY_5, sizeof(MGCMTBLDAT.KEY_5));
				TRS.add_string(out_node, "NEXT_KEY_6", MGCMTBLDAT.KEY_6, sizeof(MGCMTBLDAT.KEY_6));
				TRS.add_string(out_node, "NEXT_KEY_7", MGCMTBLDAT.KEY_7, sizeof(MGCMTBLDAT.KEY_7));
				TRS.add_string(out_node, "NEXT_KEY_8", MGCMTBLDAT.KEY_8, sizeof(MGCMTBLDAT.KEY_8));
				TRS.add_string(out_node, "NEXT_KEY_9", MGCMTBLDAT.KEY_9, sizeof(MGCMTBLDAT.KEY_9));
				TRS.add_string(out_node, "NEXT_KEY_10", MGCMTBLDAT.KEY_10, sizeof(MGCMTBLDAT.KEY_10));
				*/
				CDB_close_cwippmphis(i_step);
				break;
			}
			
			DBC_init_mgcmtbldat(&MGCMTBLDAT_LINE);
			memcpy(MGCMTBLDAT_LINE.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_LINE.TABLE_NAME,"@LINE_CODE", strlen("@LINE_CODE"));
			memcpy(MGCMTBLDAT_LINE.KEY_1,CWIPPMPHIS.LINE_ID, sizeof(CWIPPMPHIS.LINE_ID));

			DBC_select_mgcmtbldat(1, &MGCMTBLDAT_LINE);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "GCM-0008");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT_LINE.FACTORY), MGCMTBLDAT_LINE.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT_LINE.TABLE_NAME), MGCMTBLDAT_LINE.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT_LINE.KEY_1), MGCMTBLDAT_LINE.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				CDB_close_cwippmphis(i_step);
				return MP_FALSE;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_D_POSITION);
			memcpy(MGCMTBLDAT_D_POSITION.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_D_POSITION.TABLE_NAME,"@DETECT_POSITION", strlen("@DETECT_POSITION"));
			memcpy(MGCMTBLDAT_D_POSITION.KEY_1,CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_D_POSITION);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}

			
			DBC_init_mgcmtbldat(&MGCMTBLDAT_SOLDERING);
			memcpy(MGCMTBLDAT_SOLDERING.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_SOLDERING.TABLE_NAME,"@PMPP_SOLDERING", strlen("@PMPP_SOLDERING"));
			//memcpy(MGCMTBLDAT_SOLDERING.KEY_1,CWIPPMPHIS.CMF_1, sizeof(CWIPPMPHIS.CMF_1));

			// 20210810 MES Application Memory leak 점검 및 수정
			// memcpy 메모리 침범 수정
			memcpy(MGCMTBLDAT_SOLDERING.KEY_1,CWIPPMPHIS.CMF_1, sizeof(MGCMTBLDAT_SOLDERING.KEY_1));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_SOLDERING);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_M_DEFECT_TYPE);
			memcpy(MGCMTBLDAT_M_DEFECT_TYPE.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_M_DEFECT_TYPE.TABLE_NAME,"@PMPP_DEFECT_TYPE", strlen("@PMPP_DEFECT_TYPE"));
			memcpy(MGCMTBLDAT_M_DEFECT_TYPE.KEY_1,CWIPPMPHIS.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS.MACHINE_ISSUE_TYPE));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_M_DEFECT_TYPE);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_SHIFT);
			memcpy(MGCMTBLDAT_SHIFT.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_SHIFT.TABLE_NAME,"@SHIFT", strlen("@SHIFT"));
			memcpy(MGCMTBLDAT_SHIFT.KEY_1,CWIPPMPHIS.WORK_SHIFT, sizeof(CWIPPMPHIS.WORK_SHIFT));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_SHIFT);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}
			
			DBC_init_mgcmtbldat(&MGCMTBLDAT_FRAME_EQ);
			memcpy(MGCMTBLDAT_FRAME_EQ.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_FRAME_EQ.TABLE_NAME,"@FRAME_EQUIPMENT", strlen("@FRAME_EQUIPMENT"));
			memcpy(MGCMTBLDAT_FRAME_EQ.KEY_1,CWIPPMPHIS.RES_ID, sizeof(CWIPPMPHIS.RES_ID));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_FRAME_EQ);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}
			
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "LINE", MGCMTBLDAT_LINE.DATA_1, sizeof(MGCMTBLDAT_LINE.DATA_1));
			TRS.add_string(list_item, "MODULE_ID", CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID));
			TRS.add_string(list_item, "PMPP", CWIPPMPHIS.PMPP, sizeof(CWIPPMPHIS.PMPP));
			TRS.add_string(list_item, "DIODE", CWIPPMPHIS.DIODE, sizeof(CWIPPMPHIS.DIODE));
			TRS.add_string(list_item, "RES_ID", MGCMTBLDAT_FRAME_EQ.DATA_1, sizeof(MGCMTBLDAT_FRAME_EQ.DATA_1));
			TRS.add_string(list_item, "INS_TIME", CWIPPMPHIS.INS_TIME, sizeof(CWIPPMPHIS.INS_TIME));
			TRS.add_string(list_item, "WORK_DATE", CWIPPMPHIS.WORK_DATE, sizeof(CWIPPMPHIS.WORK_DATE));
			TRS.add_string(list_item, "WORK_TIME", CWIPPMPHIS.WORK_TIME, sizeof(CWIPPMPHIS.WORK_TIME));
			TRS.add_string(list_item, "WORK_SHIFT", MGCMTBLDAT_SHIFT.DATA_1, sizeof(MGCMTBLDAT_SHIFT.DATA_1));
			TRS.add_string(list_item, "DEFECT_POSITION", MGCMTBLDAT_D_POSITION.KEY_1, sizeof(MGCMTBLDAT_D_POSITION.KEY_1));
			TRS.add_string(list_item, "MACHINE_ISSUE_TYPE", MGCMTBLDAT_M_DEFECT_TYPE.DATA_1, sizeof(MGCMTBLDAT_M_DEFECT_TYPE.DATA_1));

			TRS.add_string(list_item, "DEFECT_TYPE", MGCMTBLDAT_M_DEFECT_TYPE.KEY_1, sizeof(MGCMTBLDAT_M_DEFECT_TYPE.KEY_1));

			TRS.add_string(list_item, "OPERATOR", CWIPPMPHIS.OPERATOR, sizeof(CWIPPMPHIS.OPERATOR));
			TRS.add_string(list_item, "MACHINE_TECHNICIAN", CWIPPMPHIS.MACHINE_TECHNICIAN, sizeof(CWIPPMPHIS.MACHINE_TECHNICIAN));
			TRS.add_string(list_item, "CREATE_USER_ID", CWIPPMPHIS.CREATE_USER_ID, sizeof(CWIPPMPHIS.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", CWIPPMPHIS.CREATE_TIME, sizeof(CWIPPMPHIS.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", CWIPPMPHIS.UPDATE_USER_ID, sizeof(CWIPPMPHIS.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", CWIPPMPHIS.UPDATE_TIME, sizeof(CWIPPMPHIS.UPDATE_TIME));

			TRS.add_string(list_item, "CMF_1", MGCMTBLDAT_SOLDERING.KEY_1, sizeof(MGCMTBLDAT_SOLDERING.KEY_1));  //IS-20-09-118 IS-20-09-118 
			TRS.add_string(list_item, "CMF_1_DATA", MGCMTBLDAT_SOLDERING.DATA_1, sizeof(MGCMTBLDAT_SOLDERING.DATA_1));  //IS-20-09-118 IS-20-09-118 
		}
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 
