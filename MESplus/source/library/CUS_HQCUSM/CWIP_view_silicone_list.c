/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_silicone_list.c
	Description : View Operation List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Silicone_List()
			+ View Lot
		- CWIP_VIEW_SILICONE_LIST()
			+ Main sub function of CWIP_View_Operation_List function
			+ View Silicone List definition
		- CWIP_View_Silicone_List_Validation()
			+ Main sub function of CWIP_VIEW_OPERATION_LIST function
			+ Check the condition for view Operation List
	Detail Description
		- CWIP_VIEW_SILICONE_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2020/06/17  Lim Yeon Keun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"


/*******************************************************************************
	CWIP_View_Operation_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Silicone_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_SILICONE_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_SILICONE_LIST", out_node);

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
	CWIP_VIEW_SILICONE_LIST()
		- Main sub function of "CWIP_View_Silicone_List" function
		- View Silicone List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_SILICONE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPSILHIS_TAG CWIPSILHIS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_LINE;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_NAME;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_SIL;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_MODULE;

    TRSNode *list_item;

    int i_step;

    LOG_head("CWIP_VIEW_SILICONE_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(TRS.get_procstep(in_node) == '1') 
	{
		i_step = 1;

		/* Select Area by Line Code */
		CDB_init_cwipsilhis(&CWIPSILHIS);

		TRS.copy(CWIPSILHIS.FACTORY, sizeof(CWIPSILHIS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPSILHIS.CREATE_TIME, sizeof(CWIPSILHIS.CREATE_TIME), in_node, "CREATE_TIME");
		TRS.copy(CWIPSILHIS.TABLE_NAME, sizeof(CWIPSILHIS.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(CWIPSILHIS.SILICONE_TYPE, sizeof(CWIPSILHIS.SILICONE_TYPE), in_node, "SILICONE_TYPE");
		TRS.copy(CWIPSILHIS.NAME, sizeof(CWIPSILHIS.NAME), in_node, "NAME");
		TRS.copy(CWIPSILHIS.LINE, sizeof(CWIPSILHIS.LINE), in_node, "LINE");
		
	
		CDB_open_cwipsilhis(i_step, &CWIPSILHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CWIPSILHIS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSILHIS.FACTORY), CWIPSILHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(CWIPSILHIS.TABLE_NAME), CWIPSILHIS.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPSILHIS.CREATE_TIME), CWIPSILHIS.CREATE_TIME);
			TRS.add_fieldmsg(out_node, "SILICONE_TYPE", MP_STR, sizeof(CWIPSILHIS.SILICONE_TYPE), CWIPSILHIS.SILICONE_TYPE);
			TRS.add_fieldmsg(out_node, "NAME", MP_STR, sizeof(CWIPSILHIS.NAME), CWIPSILHIS.NAME);
			TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CWIPSILHIS.LINE), CWIPSILHIS.LINE);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		while(1)
		{
			CDB_fetch_cwipsilhis(i_step, &CWIPSILHIS);

			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwipsilhis(i_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "CWIPSILHIS FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSILHIS.FACTORY), CWIPSILHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(CWIPSILHIS.TABLE_NAME), CWIPSILHIS.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPSILHIS.CREATE_TIME), CWIPSILHIS.CREATE_TIME);
				TRS.add_fieldmsg(out_node, "SILICONE_TYPE", MP_STR, sizeof(CWIPSILHIS.SILICONE_TYPE), CWIPSILHIS.SILICONE_TYPE);
				TRS.add_fieldmsg(out_node, "NAME", MP_STR, sizeof(CWIPSILHIS.NAME), CWIPSILHIS.NAME);
				TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CWIPSILHIS.LINE), CWIPSILHIS.LINE);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cwipsilhis(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				DBC_close_mgcmtbldat(i_step);
				break;
			}
			
			DBC_init_mgcmtbldat(&MGCMTBLDAT_LINE);
			memcpy(MGCMTBLDAT_LINE.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_LINE.TABLE_NAME,"@LINE_CODE", strlen("@LINE_CODE"));
			memcpy(MGCMTBLDAT_LINE.KEY_1,CWIPSILHIS.LINE, sizeof(CWIPSILHIS.LINE));

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

				CDB_close_cwipsilhis(i_step);
				return MP_FALSE;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_NAME);
			memcpy(MGCMTBLDAT_NAME.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_NAME.TABLE_NAME,"@SILICONE_NAME", strlen("@SILICONE_NAME"));
			memcpy(MGCMTBLDAT_NAME.KEY_1,CWIPSILHIS.NAME, sizeof(CWIPSILHIS.NAME));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_NAME);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_SIL);
			memcpy(MGCMTBLDAT_SIL.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_SIL.TABLE_NAME,"@SILICONE_TYPE", strlen("@SILICONE_TYPE"));
			//memcpy(MGCMTBLDAT_SIL.KEY_1,CWIPSILHIS.SILICONE_TYPE, sizeof(CWIPSILHIS.SILICONE_TYPE));IS-21-01-094 MES logic 개선
			memcpy(MGCMTBLDAT_SIL.KEY_1,CWIPSILHIS.SILICONE_TYPE, sizeof(MGCMTBLDAT_SIL.KEY_1));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_SIL);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}

			DBC_init_mgcmtbldat(&MGCMTBLDAT_MODULE);
			memcpy(MGCMTBLDAT_MODULE.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT_MODULE.TABLE_NAME,"@FRAME_MODULE_TYPE", strlen("@FRAME_MODULE_TYPE"));
			memcpy(MGCMTBLDAT_MODULE.KEY_1,CWIPSILHIS.FRAME_MODULE_TYPE, sizeof(CWIPSILHIS.FRAME_MODULE_TYPE));
			//memcpy(MGCMTBLDAT_MODULE.KEY_2,CWIPSILHIS.SILICONE_TYPE, sizeof(CWIPSILHIS.SILICONE_TYPE));IS-21-01-094 MES logic 개선
			memcpy(MGCMTBLDAT_MODULE.KEY_2,CWIPSILHIS.SILICONE_TYPE, sizeof(MGCMTBLDAT_MODULE.KEY_2));
			DBC_select_mgcmtbldat(1,&MGCMTBLDAT_MODULE);
			if (DB_error_code != DB_SUCCESS)
			{
				TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
			}
			
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "FACTORY", CWIPSILHIS.FACTORY, sizeof(CWIPSILHIS.FACTORY));
			TRS.add_string(list_item, "CREATE_TIME", CWIPSILHIS.CREATE_TIME, sizeof(CWIPSILHIS.CREATE_TIME));
			TRS.add_string(list_item, "TABLE_NAME", CWIPSILHIS.TABLE_NAME, sizeof(CWIPSILHIS.TABLE_NAME));
			TRS.add_string(list_item, "SILICONE_TYPE", MGCMTBLDAT_SIL.DATA_1, sizeof(MGCMTBLDAT_SIL.DATA_1));
			TRS.add_string(list_item, "NAME", MGCMTBLDAT_NAME.DATA_1, sizeof(MGCMTBLDAT_NAME.DATA_1));
			TRS.add_string(list_item, "LINE", MGCMTBLDAT_LINE.DATA_1, sizeof(MGCMTBLDAT_LINE.DATA_1));

			TRS.add_string(list_item, "SILICONE_SIDE", CWIPSILHIS.SILICONE_SIDE, sizeof(CWIPSILHIS.SILICONE_SIDE));
			TRS.add_string(list_item, "LEFT_WEIGHT", CWIPSILHIS.LEFT_WEIGHT, sizeof(CWIPSILHIS.LEFT_WEIGHT));
			TRS.add_string(list_item, "CENTER_WEIGHT", CWIPSILHIS.CENTER_WEIGHT, sizeof(CWIPSILHIS.CENTER_WEIGHT));
			TRS.add_string(list_item, "RIGHT_WEIGHT", CWIPSILHIS.RIGHT_WEIGHT, sizeof(CWIPSILHIS.RIGHT_WEIGHT));
			TRS.add_string(list_item, "POTTING_WEIGHT_A", CWIPSILHIS.POTTING_WEIGHT_A, sizeof(CWIPSILHIS.POTTING_WEIGHT_A));
			TRS.add_string(list_item, "POTTING_WEIGHT_B", CWIPSILHIS.POTTING_WEIGHT_B, sizeof(CWIPSILHIS.POTTING_WEIGHT_B));
			TRS.add_string(list_item, "POTTING_WEIGHT_RATIO", CWIPSILHIS.POTTING_WEIGHT_RATIO, sizeof(CWIPSILHIS.POTTING_WEIGHT_RATIO));

			TRS.add_string(list_item, "LEFT_WEIGHT_RESULT", CWIPSILHIS.LEFT_WEIGHT_RESULT, sizeof(CWIPSILHIS.LEFT_WEIGHT_RESULT));
			TRS.add_string(list_item, "CENTER_WEIGHT_RESULT", CWIPSILHIS.CENTER_WEIGHT_RESULT, sizeof(CWIPSILHIS.CENTER_WEIGHT_RESULT));
			TRS.add_string(list_item, "RIGHT_WEIGHT_RESULT", CWIPSILHIS.RIGHT_WEIGHT_RESULT, sizeof(CWIPSILHIS.RIGHT_WEIGHT_RESULT));
			TRS.add_string(list_item, "RATIO_WEIGHT_RESULT", CWIPSILHIS.RATIO_WEIGHT_RESULT, sizeof(CWIPSILHIS.RATIO_WEIGHT_RESULT));

			TRS.add_string(list_item, "FRAME_SHORT_WEIGHT", CWIPSILHIS.FRAME_SHORT_WEIGHT, sizeof(CWIPSILHIS.FRAME_SHORT_WEIGHT));
			TRS.add_string(list_item, "FRAME_SHORT_RESULT", CWIPSILHIS.FRAME_SHORT_RESULT, sizeof(CWIPSILHIS.FRAME_SHORT_RESULT));
			TRS.add_string(list_item, "FRAME_LONG_WEIGHT", CWIPSILHIS.FRAME_LONG_WEIGHT, sizeof(CWIPSILHIS.FRAME_LONG_WEIGHT));
			TRS.add_string(list_item, "FRAME_LONG_RESULT", CWIPSILHIS.FRAME_SHORT_RESULT, sizeof(CWIPSILHIS.FRAME_SHORT_RESULT));
			TRS.add_string(list_item, "FRAME_MODULE_TYPE", MGCMTBLDAT_MODULE.DATA_1, sizeof(MGCMTBLDAT_MODULE.DATA_1));

			TRS.add_string(list_item, "CREATE_USER_ID", CWIPSILHIS.CREATE_USER_ID, sizeof(CWIPSILHIS.CREATE_USER_ID));
			TRS.add_string(list_item, "COMMENT_CONT", CWIPSILHIS.COMMENT_CONT, sizeof(CWIPSILHIS.COMMENT_CONT));
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

	return MP_TRUE; 
} 
