/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_spc_function.c.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// CTMPSPCDAT 기준데이터를 읽어서  SPC 호출

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2018/11/27  Juhyeon.Jung       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include "SPCCore_common.h"
#include <MessageCaster.h>
int CSUM_BATCHPROCESS_SPC_COLLECT_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CSUM_BatchProcess_Spc_Collect_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
CSUM_BatchProcess_Spc_Collect_Data()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Spc_Collect_Data(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_BATCHPROCESS_SPC_COLLECT_DATA(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_SPC_COLLECT_DATA", out_node);

	if(i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	CUS_COM_BATCHPROCESS_STATUS_UPDATE('E', in_node, out_node);

	return MP_TRUE;
}


/*******************************************************************************
CSUM_BATCHPROCESS_SPC_COLLECT_DATA()
- Main sub function of "CSUM_BatchProcess_Spc_Collect_Data" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_SPC_COLLECT_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CTMPSPCDAT_TAG CTMPSPCDAT;
	struct MSPCCHTDEF_TAG MSPCCHTDEF;
	struct MSPCEDCDAT_TAG MSPCEDCDAT;

	char cIUDFlag ;
	char s_sys_time[14];
	char s_tmp_date_time[14];
	int iStep  = 0;
	char c_eq_spc_flag = ' ';
		
    LOG_head("CSUM_BATCHPROCESS_SPC_COLLECT_DATA");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time, ' ', sizeof(s_sys_time));
	
	DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}

	//EOH (향후 진행)
	//CSUM_BATCHPROCESS_EOH();

	//SUMMARY TEMP TABLE OPEN
	iStep = 1;
	CDB_init_ctmpspcdat(&CTMPSPCDAT);  //PROCESS_FLAG 가 SPACE 인것만 조회

	if(TRS.get_char(in_node, "PROCSTEP") == 'E')
	{
		//PROCESS STEP 이 E 인것을 CMF_1 이 ERROR 인것만 조회함.
		memcpy(CTMPSPCDAT.CMF_1, "ERR", strlen("ERR"));
	}

	CDB_open_ctmpspcdat(iStep, &CTMPSPCDAT);
	if(DB_error_code != DB_SUCCESS)
	{ 		
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "CTMPSPCDAT OPEN", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
        
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		CDB_fetch_ctmpspcdat(iStep, &CTMPSPCDAT);
		if(DB_error_code == DB_NOT_FOUND)
		{ 
			CDB_close_ctmpspcdat(iStep);
			break; 
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.set_fieldmsg(out_node, "CTMPSPCDAT FETCH", MP_NVST);
			TRS.set_fieldmsg(out_node, "ITEM CODE", MP_STR, sizeof(CTMPSPCDAT.LOT_ID), CTMPSPCDAT.LOT_ID);				
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			CDB_close_ctmpspcdat(iStep);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		c_eq_spc_flag = 'N';
		//CHART SELECT
		DBC_init_mspcchtdef(&MSPCCHTDEF);
		memcpy(MSPCCHTDEF.FACTORY, CTMPSPCDAT.FACTORY, sizeof(CTMPSPCDAT.FACTORY));
		memcpy(MSPCCHTDEF.CHART_ID, CTMPSPCDAT.CHART_ID, sizeof(MSPCCHTDEF.CHART_ID));
		DBC_select_mspcchtdef(1, &MSPCCHTDEF) ;
		if(DB_error_code != DB_SUCCESS)
		{
			c_eq_spc_flag = 'N';
		}

		
		//SPC 마지막 데이터 GET
		DBC_init_mspcedcdat(&MSPCEDCDAT);
		memcpy(MSPCEDCDAT.FACTORY,  MSPCCHTDEF.FACTORY, sizeof(MSPCEDCDAT.FACTORY));
		memcpy(MSPCEDCDAT.CHART_ID, MSPCCHTDEF.CHART_ID, sizeof(MSPCEDCDAT.CHART_ID));
		DBC_select_mspcedcdat(101, &MSPCEDCDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
				c_eq_spc_flag = 'Y';
		}

		if (memcmp(MSPCEDCDAT.VALUE_1, CTMPSPCDAT.PARAM_VALUE, sizeof(MSPCEDCDAT.VALUE_1)) != 0)
			c_eq_spc_flag = 'Y';

		if (memcmp(MSPCEDCDAT.UNIT_ID, CTMPSPCDAT.LOT_ID, sizeof(MSPCEDCDAT.UNIT_ID)) != 0)
			c_eq_spc_flag = 'Y';

		//주기비교 MSPCCHTDEF.CMF_1 (SEC) 주기값.
		memset(s_tmp_date_time, ' ', sizeof(s_tmp_date_time));
		DB_get_calc_time(s_tmp_date_time, MSPCEDCDAT.TRAN_TIME, 1, (COM_atoi(MSPCCHTDEF.CHT_CMF_1, sizeof(MSPCCHTDEF.CHT_CMF_1)) / 60) );

		if (memcmp(s_tmp_date_time, CTMPSPCDAT.TRAN_TIME, sizeof(s_tmp_date_time)) <= 0)
		{
			c_eq_spc_flag = 'Y';
		}

		if (MSPCCHTDEF.DELETE_FLAG == 'Y')
		{
			c_eq_spc_flag = 'N';
		}

		//SPC 수집.
		if (c_eq_spc_flag == 'Y')
		{
			char s_tmsg_code[MP_SIZE_MSG];
			char s_channel_name[256];

			TRSNode* tran_in_node;
			TRSNode* tran_out_node;
			TRSNode *list_item;
			TRSNode *value_item;
				
			memset(s_tmsg_code, 0x00, MP_SIZE_MSG);

			tran_in_node = TRS.create_node("SPC_COLLECT_IN");
			tran_out_node = TRS.create_node("SPC_COLLECT_OUT");

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", 'I');
			
			/*
			#define MP_STEP_TRAN                    ( 'T' )
			#define MP_STEP_PEND                    ( 'P' )
			#define MP_STEP_CONT                    ( 'N' )
			*/
			TRS.add_char(tran_in_node, "SUB_STEP", MP_STEP_CONT);
			TRS.add_char(tran_in_node, "LOT_RES_FLAG", 'R');
			TRS.set_nstring(tran_in_node, "USER_ID", "ADMIN");
			TRS.set_nstring(tran_in_node, IN_USERID, "ADMIN");
			TRS.add_string(tran_in_node, "RES_ID", CTMPSPCDAT.RES_ID, sizeof(CTMPSPCDAT.RES_ID));
			TRS.add_string(tran_in_node, "GRAPH_TYPE", MSPCCHTDEF.GRAPH_TYPE, sizeof(MSPCCHTDEF.GRAPH_TYPE));
			TRS.add_string(tran_in_node, "CHART_ID", MSPCCHTDEF.CHART_ID, sizeof(MSPCCHTDEF.CHART_ID));
			TRS.add_string(tran_in_node, "CHAR_ID", MSPCCHTDEF.CHAR_ID, sizeof(MSPCCHTDEF.CHAR_ID));
			TRS.add_int(tran_in_node, "UNIT_COUNT", MSPCCHTDEF.UNIT_COUNT);
			TRS.add_int(tran_in_node, "SAMPLE_SIZE", MSPCCHTDEF.SAMPLE_SIZE);
			TRS.add_char(tran_in_node, "UNIT_USE_FLAG", MSPCCHTDEF.UNIT_USE_FLAG);
			TRS.add_string(tran_in_node, "TRAN_TIME", CTMPSPCDAT.TRAN_TIME, sizeof(CTMPSPCDAT.TRAN_TIME));

			list_item = TRS.add_node(tran_in_node, "UNIT_LIST");
			TRS.add_string(list_item, "UNIT_ID", CTMPSPCDAT.LOT_ID, sizeof(CTMPSPCDAT.LOT_ID));
			TRS.add_int(list_item, "UNIT_SEQ", 1);
			
			if (MSPCCHTDEF.GRAPH_TYPE[0] == 'P')
			{
				TRS.add_int(list_item, "VALUE_COUNT", 2);
				value_item = TRS.add_node(list_item, "VALUE_LIST");
				TRS.add_string(value_item, "VALUE", CTMPSPCDAT.CMF_2, sizeof(CTMPSPCDAT.CMF_2));
				value_item = TRS.add_node(list_item, "VALUE_LIST");
				TRS.add_string(value_item, "VALUE", CTMPSPCDAT.CMF_3, sizeof(CTMPSPCDAT.CMF_3));
			}
			else
			{
				TRS.add_int(list_item, "VALUE_COUNT", 1);
				value_item = TRS.add_node(list_item, "VALUE_LIST");
				TRS.add_string(value_item, "VALUE", CTMPSPCDAT.PARAM_VALUE, sizeof(CTMPSPCDAT.PARAM_VALUE));
			}
			/*
			if(SPC_COLLECT_EDC_DATA(s_tmsg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{	
				COM_out_msg_log_write(s_tmsg_code, "SPC_COLLECT_EDC_DATA", tran_out_node);
			}
			*/
				
			memset(s_channel_name, 0x00, sizeof(s_channel_name));
			//COM_memcpy_add_null(s_channel_name, MBATPRCDEF.MES_CHANNEL, 255);
			sprintf(s_channel_name, "/%.*s/CUSServer", 4, gs_site_id);
			//memcpy(s_channel_name, "/MPP1/MESServer", strlen("/MPP1/MESServer"));
			

			if(CallService("SPC", 
							"SPC_Collect_EDC_Data", 
							tran_in_node, 
							tran_out_node, 
							s_channel_name, 
							gi_default_ttl, 
							DM_RREPLY) != MP_TRUE)
			{
				//DO NOTHING
			}
			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);

        }

		// Delete CTMPSPCDAT Data
		cIUDFlag = 'D';
		if (cIUDFlag == 'D')
		{
			CDB_delete_ctmpspcdat(1, &CTMPSPCDAT);
		}
		
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.set_fieldmsg(out_node, "CTMPSPCDAT DELETE", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				continue;
			}
		}

		DB_commit();

		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
CSUM_BatchProcess_Spc_Collect_Data_Validation()
- Validation check sub function of "CSUM_BatchProcess_Spc_Collect_Data" function
- Check the Conditions before Custom End Lot Function List
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Spc_Collect_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	/* ProcStep Validation */
	if ((TRS.get_procstep(in_node) == ' ')  || (TRS.get_procstep(in_node) == '\0'))
	{
		//BATCH 에서 실행되므로 PROC STEP 은 1로 무조건 실행함.
		TRS.set_char(in_node, IN_PROCSTEP, '1');
	}
	if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
		strcpy(s_msg_code, "WIP-0001");
        TRS.set_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

	return MP_TRUE;
}

