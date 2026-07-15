
/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_resource_status_function.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// MTMPRESHIS ���ص����͸� �о  FMB �� ���� ��������

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2019/02/01  YS KIM       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <MESCore_common.h>
#include "ACTCore_common.h"


int CSUM_BATCHPROCESS_RESOURCE_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
CSUM_BatchProcess_Resource_Event()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Resource_Event(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_BATCHPROCESS_RESOURCE_EVENT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_RESOURCE_EVENT", out_node);

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
CSUM_BATCHPROCESS_TRANSACTION()
- Main sub function of "CSUM_BatchProcess_Transaction" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_RESOURCE_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MRASRESDEF_TAG MRASRESDEF;
	struct RSUMRESDWH_TAG RSUMRESDWH;
	struct MRASSRSDEF_TAG MRASSRSDEF;

	struct worktime_tag cur_work_time;

    char s_actual_time[15];
	int i_step  = 0;
	
    LOG_head("CSUM_BATCHPROCESS_RESOURCE_EVENT");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_actual_time, ' ', sizeof(s_actual_time));
	DB_get_systime(s_actual_time);
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
	/* CURRENT TIME   */
	CCOM_get_work_time(s_actual_time, &cur_work_time);

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}

	i_step = 107;
	//TABLE OPEN
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	DBC_open_mrasresdef(i_step, &MRASRESDEF); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "RAS-0004"); 
		TRS.add_fieldmsg(out_node, "MRASRESDEF OPEN", MP_NVST); 
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		DBC_fetch_mrasresdef(i_step, &MRASRESDEF); 
		if(DB_error_code != DB_SUCCESS)
		{
			DBC_close_mrasresdef(i_step); 
			break;
		}
		/***************************************************************************/
		/* FMB ���� �޼��� ������ ���� ���⼭ ó���� */
		/***************************************************************************/
		{
			char s_channel[100]; 
			TRSNode *node;

			/* Common Data */
			
			CDB_init_rsumresdwh(&RSUMRESDWH);
			memcpy(RSUMRESDWH.FACTORY, MRASRESDEF.FACTORY, sizeof(RSUMRESDWH.FACTORY));
			//memcpy(RSUMRESDWH.WORK_DATE, cur_work_time.work_date, strlen(cur_work_time.work_date)); // Server Crash
			memcpy(RSUMRESDWH.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date)); // Server Crash
			memcpy(RSUMRESDWH.RES_ID, MRASRESDEF.RES_ID, sizeof(RSUMRESDWH.RES_ID));
			CDB_open_rsumresdwh(102, &RSUMRESDWH); 
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004"); 
				TRS.add_fieldmsg(out_node, "RSUMRESDWH OPEN", MP_NVST); 
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMRESDWH.WORK_DATE), RSUMRESDWH.WORK_DATE); 
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMRESDWH.RES_ID), RSUMRESDWH.RES_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				DBC_close_mrasresdef(i_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}
			while(1)
			{
				CDB_fetch_rsumresdwh(102, &RSUMRESDWH); 
				if(DB_error_code != DB_SUCCESS)
				{
					CDB_close_rsumresdwh(102); 
					break;
				}

				
				//RECORD LOCK �� �ʹ� ���� ���� �ּ�ȭ��.
				if ((memcmp(MRASRESDEF.RES_CMF_7, RSUMRESDWH.CMF_1, sizeof(MRASRESDEF.RES_CMF_1)) != 0) &&
					(COM_atoi(RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1)) > 0))	
				{
					memcpy(MRASRESDEF.RES_STS_7, RSUMRESDWH.CMF_1, sizeof(MRASRESDEF.RES_STS_7));//TACK_TIME
					memcpy(MRASRESDEF.RES_STS_8, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));//CTRL_MODE

					DBC_select_mrasresdef_for_update(1, &MRASRESDEF);//20190930 ��ִ��� 
					if(DB_error_code != DB_SUCCESS)
					{ 
						 
					}

					//DBC_update_mrasresdef(104, &MRASRESDEF);
					//if(DB_error_code != DB_SUCCESS)
					//{ 
					//	 // BATCH ������ LOCK ��������. COMMIT OR ROLLBACK �Ұ�
					//}
					////2020-08-18 hanchang.kim �ش�κ� ó���� 80~140sec �̻� �ɸ���� ���� MRASRESDEF ��� ���� ���� lock �߻����߷� ���� DB commitó��
					//DB_commit();

				}
				
				if(memcmp(RSUMRESDWH.RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID)) != 0)
				{
					DBC_init_mrassrsdef(&MRASSRSDEF);
					memcpy(MRASSRSDEF.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASSRSDEF.FACTORY));
					memcpy(MRASSRSDEF.RES_ID, RSUMRESDWH.RES_ID, sizeof(MRASSRSDEF.RES_ID));
					memcpy(MRASSRSDEF.SUBRES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(MRASSRSDEF.SUBRES_ID));
					DBC_select_mrassrsdef(1, &MRASSRSDEF);
					if(DB_error_code != DB_SUCCESS)
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							 
						}
						else
						{
							//DO NOTHING ( BATCH ������ ERROR ���� ����, COMMIT OR ROLLBACK �Ұ�)
						}
						
					}
					else
					{
						memcpy(MRASSRSDEF.SUBRES_STS_3, RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
						memcpy(MRASSRSDEF.SUBRES_STS_7, RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1)); // TACK_TIME
						memcpy(MRASSRSDEF.SUBRES_STS_8, MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));//CTRL_MODE

						//DBC_update_mrassrsdef(102,&MRASSRSDEF);
						//if(DB_error_code != DB_SUCCESS)
						//{ 
						//	//DO NOTHING ( BATCH ������ ERROR ���� ����,  COMMIT OR ROLLBACK �Ұ�)
						//}
						////2020-08-18 hanchang.kim �ش�κ� ó���� 80~140sec �̻� �ɸ���� ���� MRASRESDEF ��� ���� ���� lock �߻����߷� ���� DB commitó��
					 //   DB_commit();

						node = TRS.create_node("RAS_Sub_Event_Publish_Msg_In");

						CCOM_copy_in_node(in_node, node);
	

						TRS.add_string(node, "RES_ID", RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
						TRS.add_string(node, "SUBRES_ID", RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID));
						TRS.add_string(node, "SUBRES_STS_1", MRASSRSDEF.SUBRES_STS_1, sizeof(MRASSRSDEF.SUBRES_STS_1));
						TRS.add_string(node, "SUBRES_STS_2", MRASSRSDEF.SUBRES_STS_2, sizeof(MRASSRSDEF.SUBRES_STS_2));
						TRS.add_string(node, "SUBRES_STS_3", RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
						TRS.add_string(node, "SUBRES_STS_4", RSUMRESDWH.CURR_GROUP, sizeof(RSUMRESDWH.CURR_GROUP)); // STATUS GROUP
						TRS.add_string(node, "SUBRES_STS_5", MRASSRSDEF.SUBRES_STS_5, sizeof(MRASSRSDEF.SUBRES_STS_5));
						TRS.add_string(node, "SUBRES_STS_6", MRASSRSDEF.SUBRES_STS_6, sizeof(MRASSRSDEF.SUBRES_STS_6));
						TRS.add_string(node, "SUBRES_STS_7", RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1)); //TACK TIME
						TRS.add_string(node, "SUBRES_STS_8", MRASRESDEF.RES_STS_8, sizeof(MRASSRSDEF.SUBRES_STS_8)); // CTRL_MODE
						TRS.add_string(node, "SUBRES_STS_9", MRASSRSDEF.SUBRES_STS_9, sizeof(MRASSRSDEF.SUBRES_STS_9));
						TRS.add_string(node, "SUBRES_STS_10", MRASSRSDEF.SUBRES_STS_10, sizeof(MRASSRSDEF.SUBRES_STS_10));
						//TRS.add_string(node, "TACK_TIME", RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1));

						/* MES to EAP */
						memset(s_channel, 0x00, sizeof(s_channel));
						sprintf(s_channel, "/%.*s/FMB/*", 4, gs_site_id);
						COM_add_null(s_channel, sizeof(s_channel));
    
						if(MOA.call_service("FMB", 
									"RAS_Sub_Event_Publish", 
									node, 
									0x00, 
									s_channel, 
									gi_default_ttl, 
									DM_MULTICAST) != MP_TRUE)
						{
							//DO NTOHING
						}
						TRS.free_node(node);
					}
				}
				else
				{
					node = TRS.create_node("RAS_Event_Publish_Msg_In");

					CCOM_copy_in_node(in_node, node);
	

					TRS.add_string(node, "RES_ID", RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID)); // (RES_ID - SUB_RES_ID) 
					TRS.add_string(node, "RES_PRI_STS", MRASRESDEF.RES_PRI_STS, sizeof(MRASRESDEF.RES_PRI_STS));
					TRS.add_string(node, "RES_STS_1", MRASRESDEF.RES_STS_1, sizeof(MRASRESDEF.RES_STS_1));
					TRS.add_string(node, "RES_STS_2", MRASRESDEF.RES_STS_2, sizeof(MRASRESDEF.RES_STS_2));
					TRS.add_string(node, "RES_STS_3", RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
					TRS.add_string(node, "RES_STS_4", RSUMRESDWH.CURR_GROUP, sizeof(RSUMRESDWH.CURR_GROUP)); // STATUS_GROUP
					TRS.add_string(node, "RES_STS_5", MRASRESDEF.RES_STS_5, sizeof(MRASRESDEF.RES_STS_5));
					TRS.add_string(node, "RES_STS_6", RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID)); // SUB_RES_ID
					TRS.add_string(node, "RES_STS_7", RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1)); // TACK_TIME
					TRS.add_string(node, "RES_STS_8", MRASRESDEF.RES_STS_8, sizeof(MRASRESDEF.RES_STS_8)); // CTRL_MODE
					TRS.add_string(node, "RES_STS_9", MRASRESDEF.RES_STS_9, sizeof(MRASRESDEF.RES_STS_9));
					TRS.add_string(node, "RES_STS_10", MRASRESDEF.RES_STS_10, sizeof(MRASRESDEF.RES_STS_10));
					TRS.add_string(node, "LOT_ID", MRASRESDEF.LOT_ID, sizeof(MRASRESDEF.LOT_ID));
					TRS.add_string(node, "RES_CTRL_MODE", MRASRESDEF.RES_CTRL_MODE, sizeof(MRASRESDEF.RES_CTRL_MODE));
					TRS.add_string(node, "RES_PROC_MODE", MRASRESDEF.RES_PROC_MODE, sizeof(MRASRESDEF.RES_PROC_MODE));
					TRS.add_string(node, "LAST_DOWN_TIME", MRASRESDEF.LAST_DOWN_TIME, sizeof(MRASRESDEF.LAST_DOWN_TIME));
					//TRS.add_string(node, "TACK_TIME", RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1));

					/* MES to EAP */
					memset(s_channel, 0x00, sizeof(s_channel));
					sprintf(s_channel, "/%.*s/FMB/*", 4, gs_site_id);
					COM_add_null(s_channel, sizeof(s_channel));
    
					if(MOA.call_service("FMB", 
								"RAS_Event_Publish", 
								node, 
								0x00, 
								s_channel, 
								gi_default_ttl, 
								DM_MULTICAST) != MP_TRUE)
					{
						//DO NTOHING
					}
					TRS.free_node(node);
				}
			}
		}
		//���� ���̺� LOCK ���������� ó��
		DB_commit();
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

