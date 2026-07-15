
/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_batchprocess_resource_cus_status_function.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// 

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2020/10/08  IMM           Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <MESCore_common.h>
#include "ACTCore_common.h"


int CSUM_BATCHPROCESS_RESOURCE_CUS_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
CSUM_BatchProcess_Resource_Cus_Event()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Resource_Cus_Event(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;
	 
	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = CSUM_BATCHPROCESS_RESOURCE_CUS_EVENT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_RESOURCE_CUS_EVENT", out_node);

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
int CSUM_BATCHPROCESS_RESOURCE_CUS_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CRASRESDEF_TAG CRASRESDEF;
	struct RSUMRESDWH_TAG RSUMRESDWH;
	struct CRASSRSDEF_TAG CRASSRSDEF;
	struct MRASSRSDEF_TAG MRASSRSDEF_LIST;
	struct RSUMHOREQP_TAG RSUMHOREQP;

	struct worktime_tag cur_work_time;
	char s_tmp[1000];
    char s_actual_time[15];
	int i_step  = 0;
	
    LOG_head("CSUM_BATCHPROCESS_RESOURCE_CUS_EVENT");
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

	i_step = 101;
	
	// 설비마스터 테이블에서 RES_CMF_10 이 Y 인 값 설비리스트 정보를 가져옴
/*	                SELECT 
                    A.FACTORY,
                    A.RES_ID,
                    DECODE(NVL(B.SUBRES_ID, ' '), ' ', A.RES_ID, B.SUBRES_ID) SUBRES_ID,
                    DECODE(NVL(B.SUBRES_ID, ' '), ' ', A.RES_STS_7, B.SUBRES_STS_7) SUBRES_STS_7
                 FROM MRASRESDEF A, MRASSRSDEF B
                WHERE A.FACTORY = :CRASSRSDEF_N.FACTORY
                    AND A.FACTORY = B.FACTORY(+)
					AND A.RES_ID = B.RES_ID(+)
					AND A.RES_CMF_10 = 'Y'
                ORDER BY A.RES_ID, B.SUBRES_ID ASC;
*/
	DBC_init_mrassrsdef(&MRASSRSDEF_LIST);
	TRS.copy(MRASSRSDEF_LIST.FACTORY, sizeof(MRASSRSDEF_LIST.FACTORY), in_node, "FACTORY");
	DBC_open_mrassrsdef(i_step, &MRASSRSDEF_LIST); 
	if(DB_error_code != DB_SUCCESS)
	{ 
		strcpy(s_msg_code, "RAS-0004"); 
		TRS.add_fieldmsg(out_node, "CRASSRSDEF_LIST OPEN", MP_NVST); 
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASSRSDEF_LIST.FACTORY), MRASSRSDEF_LIST.FACTORY); 
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_SETUP;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE; 
	}
	while(1)
	{
		DBC_fetch_mrassrsdef(i_step, &MRASSRSDEF_LIST); 
		if(DB_error_code != DB_SUCCESS)
		{
			DBC_close_mrassrsdef(i_step); 
			break;
		}
		/***************************************************************************/
		/* FMB 설비상태 갱신을 위한 PUSH 메세지                                    */
		/***************************************************************************/
		{
			char s_channel[100]; 
			TRSNode *node;

			/* Common Data */
			// 설비, 서브 설비에 해당되는 RSUMRESDWH 테이블의 MAX(TRAN_MSEC) 값의 ROW 를 가져옴. 데이터가 존재하지 않을 경우 SKIP  
/*			SELECT DWH.*
                FROM RSUMRESDWH DWH, 
					(SELECT FACTORY, RES_ID, SUB_RES_ID, MAX(TRAN_MSEC) TRAN_MSEC FROM RSUMRESDWH
					  WHERE FACTORY = :RSUMRESDWH_N.FACTORY
					    AND RES_ID = :RSUMRESDWH_N.RES_ID
						AND SUB_RES_ID = :RSUMRESDWH_N.SUB_RES_ID
					  GROUP BY FACTORY, RES_ID, SUB_RES_ID) DWH_MAX
				WHERE DWH.FACTORY = DWH_MAX.FACTORY
				    AND DWH.RES_ID = DWH_MAX.RES_ID
                    AND DWH.SUB_RES_ID = DWH_MAX.SUB_RES_ID
					AND DWH.TRAN_MSEC = DWH_MAX.TRAN_MSEC;
*/
			CDB_init_rsumresdwh(&RSUMRESDWH);
			memcpy(RSUMRESDWH.FACTORY, MRASSRSDEF_LIST.FACTORY, sizeof(RSUMRESDWH.FACTORY));
			memcpy(RSUMRESDWH.RES_ID, MRASSRSDEF_LIST.RES_ID, sizeof(RSUMRESDWH.RES_ID));
			memcpy(RSUMRESDWH.SUB_RES_ID, MRASSRSDEF_LIST.SUBRES_ID, sizeof(RSUMRESDWH.SUB_RES_ID));
			
			CDB_select_rsumresdwh(4, &RSUMRESDWH); 
			if(DB_error_code != DB_SUCCESS)
			{
				continue;
			}
			// RSUMRESDWH 테이블의 MAX(TRAN_MSEC) 값의 ROW 로 TACK_TIME 가져옴. 데이터가 존재하지 않을 경우 SKIP

/*			SELECT 
                    FACTORY,
                    WORK_DATE,
                    WORK_SHIFT,
                    LINE_ID,
                    RES_ID,
                    SUB_RES_ID,
                    TOT_PROC_TIME,
                    TOT_TACK_TIME,
                    TO_CHAR(DECODE(NVL(TOT_PROC_TIME,0),0,0,DECODE(NVL(TOT_TACK_TIME,0), 0, 0 , ROUND(TOT_TACK_TIME/TOT_PROC_TIME,0)))) CMF_5
                FROM RSUMHOREQP
                WHERE FACTORY = :RSUMHOREQP_N.FACTORY
                    AND WORK_DATE = :RSUMHOREQP_N.WORK_DATE
                    AND WORK_SHIFT = :RSUMHOREQP_N.WORK_SHIFT
                    AND RES_ID = :RSUMHOREQP_N.RES_ID
                    AND SUB_RES_ID = :RSUMHOREQP_N.SUB_RES_ID;
*/
			CDB_init_rsumhoreqp(&RSUMHOREQP);
			memcpy(RSUMHOREQP.FACTORY, MRASSRSDEF_LIST.FACTORY, sizeof(RSUMHOREQP.FACTORY));
			memcpy(RSUMHOREQP.RES_ID, MRASSRSDEF_LIST.RES_ID, sizeof(RSUMHOREQP.RES_ID));
			memcpy(RSUMHOREQP.SUB_RES_ID, MRASSRSDEF_LIST.SUBRES_ID, sizeof(RSUMHOREQP.SUB_RES_ID));
			memcpy(RSUMHOREQP.WORK_DATE, RSUMRESDWH.WORK_DATE, sizeof(RSUMHOREQP.WORK_DATE));
			RSUMHOREQP.WORK_SHIFT[0] = RSUMRESDWH.WORK_SHIFT;
			CDB_select_rsumhoreqp(2, &RSUMHOREQP); 
			if(DB_error_code != DB_SUCCESS)
			{
				RSUMHOREQP.CMF_5[0] = '0';
				//continue;
			}

			CDB_init_crasresdef(&CRASRESDEF);
			memcpy(CRASRESDEF.FACTORY, MRASSRSDEF_LIST.FACTORY, sizeof(CRASRESDEF.FACTORY));
			memcpy(CRASRESDEF.RES_ID, MRASSRSDEF_LIST.RES_ID, sizeof(CRASRESDEF.RES_ID));
			CDB_select_crasresdef(1, &CRASRESDEF);  // table lock 2020-10-30 by hanchang.kim
			if(DB_error_code != DB_SUCCESS)
			{
				//continue;
			}
			

			if(memcmp(RSUMRESDWH.RES_ID, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.RES_ID)) != 0)
			{
				//SUB RES_ID 
				CDB_init_crassrsdef(&CRASSRSDEF);
				memcpy(CRASSRSDEF.FACTORY, MRASSRSDEF_LIST.FACTORY, sizeof(CRASSRSDEF.FACTORY));
				memcpy(CRASSRSDEF.RES_ID, MRASSRSDEF_LIST.RES_ID, sizeof(CRASSRSDEF.RES_ID));
				memcpy(CRASSRSDEF.SUBRES_ID, MRASSRSDEF_LIST.SUBRES_ID, sizeof(CRASSRSDEF.SUBRES_ID));
				
				
				CDB_select_crassrsdef(1, &CRASSRSDEF); // Table Lock 2020-10-30 by hanchang.kim
				if(DB_error_code != DB_SUCCESS)
				{
					LOG_head("CDB_select_crassrsdef(1 DB_error_code");
					COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
					continue;
				}

				memcpy(CRASSRSDEF.SUBRES_STS_3, RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
				memcpy(CRASSRSDEF.SUBRES_STS_7, RSUMHOREQP.CMF_5, sizeof(RSUMHOREQP.CMF_5)); // TACK_TIME
				memcpy(CRASSRSDEF.SUBRES_STS_8, CRASRESDEF.RES_CTRL_MODE, sizeof(CRASRESDEF.RES_CTRL_MODE));//CTRL_MODE

				//CDB_update_crassrsdef(101,&CRASSRSDEF);
				CDB_update_crassrsdef(1,&CRASSRSDEF);
				if(DB_error_code != DB_SUCCESS)
				{ 
					//DO NOTHING 
					LOG_head("CDB_update_crassrsdef(101 Error");
					COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
				}
				//DB_commit();
				memcpy(CRASRESDEF.RES_STS_3, RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
				memcpy(CRASRESDEF.RES_STS_7, RSUMHOREQP.CMF_5, sizeof(CRASRESDEF.RES_STS_7));//TACK_TIME
				memcpy(CRASRESDEF.RES_STS_8, CRASRESDEF.RES_CTRL_MODE, sizeof(CRASRESDEF.RES_CTRL_MODE));//CTRL_MODE

				//DB_commit();

				node = TRS.create_node("RAS_Sub_Event_Publish_Msg_In");

				CCOM_copy_in_node(in_node, node);
	
				TRS.add_string(node, "RES_ID", RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
				TRS.add_string(node, "SUBRES_ID", RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID));
				TRS.add_string(node, "SUBRES_STS_1", CRASSRSDEF.SUBRES_STS_1, sizeof(CRASSRSDEF.SUBRES_STS_1));
				TRS.add_string(node, "SUBRES_STS_2", CRASSRSDEF.SUBRES_STS_2, sizeof(CRASSRSDEF.SUBRES_STS_2));
				TRS.add_string(node, "SUBRES_STS_3", RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
				TRS.add_string(node, "SUBRES_STS_4", RSUMRESDWH.CURR_GROUP, sizeof(RSUMRESDWH.CURR_GROUP)); // STATUS GROUP
				TRS.add_string(node, "SUBRES_STS_5", CRASSRSDEF.SUBRES_STS_5, sizeof(CRASSRSDEF.SUBRES_STS_5));
				TRS.add_string(node, "SUBRES_STS_6", CRASSRSDEF.SUBRES_STS_6, sizeof(CRASSRSDEF.SUBRES_STS_6));
				TRS.add_string(node, "SUBRES_STS_7", RSUMHOREQP.CMF_5, sizeof(RSUMHOREQP.CMF_5)); //TACK TIME
				TRS.add_string(node, "SUBRES_STS_8", CRASRESDEF.RES_STS_8, sizeof(CRASSRSDEF.SUBRES_STS_8)); // CTRL_MODE
				TRS.add_string(node, "SUBRES_STS_9", CRASSRSDEF.SUBRES_STS_9, sizeof(CRASSRSDEF.SUBRES_STS_9));
				TRS.add_string(node, "SUBRES_STS_10", CRASSRSDEF.SUBRES_STS_10, sizeof(CRASSRSDEF.SUBRES_STS_10));
				//TRS.add_string(node, "TACK_TIME", RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1));

				/* MES to EAP */
				memset(s_channel, 0x00, sizeof(s_channel));
				sprintf(s_channel, "/%.*s/FMBNEW/*", 4, gs_site_id);
				//sprintf(s_channel, "/%.*s/FMB/*", 4, gs_site_id);
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

				LOG_head("RAS_Sub_Event_Publish_Msg_In");
				memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID));
				LOG_printf("RES_ID- %s   ",s_tmp);
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

			}
			else
			{
				
				memcpy(CRASRESDEF.RES_STS_3, RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
				memcpy(CRASRESDEF.RES_STS_7, RSUMHOREQP.CMF_5, sizeof(CRASRESDEF.RES_STS_7));//TACK_TIME
				memcpy(CRASRESDEF.RES_STS_8, CRASRESDEF.RES_CTRL_MODE, sizeof(CRASRESDEF.RES_CTRL_MODE));//CTRL_MODE

				CDB_update_crasresdef(1, &CRASRESDEF);
				if(DB_error_code != DB_SUCCESS)
				{ 
					//DO NOTHING  BATCH
					LOG_head("CDB_update_crasresdef(104 Error");
					COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

				}
				//DB_commit();

				node = TRS.create_node("RAS_Event_Publish_Msg_In");

				CCOM_copy_in_node(in_node, node);
	
				TRS.add_string(node, "RES_ID", RSUMRESDWH.RES_ID, sizeof(RSUMRESDWH.RES_ID)); // (RES_ID - SUB_RES_ID) 
				TRS.add_string(node, "RES_PRI_STS", CRASRESDEF.RES_PRI_STS, sizeof(CRASRESDEF.RES_PRI_STS));
				TRS.add_string(node, "RES_STS_1", CRASRESDEF.RES_STS_1, sizeof(CRASRESDEF.RES_STS_1));
				TRS.add_string(node, "RES_STS_2", CRASRESDEF.RES_STS_2, sizeof(CRASRESDEF.RES_STS_2));
				TRS.add_string(node, "RES_STS_3", RSUMRESDWH.CURR_CODE, sizeof(RSUMRESDWH.CURR_CODE)); // STATUS
				TRS.add_string(node, "RES_STS_4", RSUMRESDWH.CURR_GROUP, sizeof(RSUMRESDWH.CURR_GROUP)); // STATUS_GROUP
				TRS.add_string(node, "RES_STS_5", CRASRESDEF.RES_STS_5, sizeof(CRASRESDEF.RES_STS_5));
				TRS.add_string(node, "RES_STS_6", RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID)); // SUB_RES_ID
				TRS.add_string(node, "RES_STS_7", RSUMHOREQP.CMF_5, sizeof(RSUMHOREQP.CMF_5)); // TACK_TIME
				TRS.add_string(node, "RES_STS_8", CRASRESDEF.RES_STS_8, sizeof(CRASRESDEF.RES_STS_8)); // CTRL_MODE
				TRS.add_string(node, "RES_STS_9", CRASRESDEF.RES_STS_9, sizeof(CRASRESDEF.RES_STS_9));
				TRS.add_string(node, "RES_STS_10", CRASRESDEF.RES_STS_10, sizeof(CRASRESDEF.RES_STS_10));
				TRS.add_string(node, "LOT_ID", CRASRESDEF.LOT_ID, sizeof(CRASRESDEF.LOT_ID));
				TRS.add_string(node, "RES_CTRL_MODE", CRASRESDEF.RES_CTRL_MODE, sizeof(CRASRESDEF.RES_CTRL_MODE));
				TRS.add_string(node, "RES_PROC_MODE", CRASRESDEF.RES_PROC_MODE, sizeof(CRASRESDEF.RES_PROC_MODE));
				TRS.add_string(node, "LAST_DOWN_TIME", CRASRESDEF.LAST_DOWN_TIME, sizeof(CRASRESDEF.LAST_DOWN_TIME));
				//TRS.add_string(node, "TACK_TIME", RSUMRESDWH.CMF_1, sizeof(RSUMRESDWH.CMF_1));

				/* MES to EAP */
				memset(s_channel, 0x00, sizeof(s_channel));
				sprintf(s_channel, "/%.*s/FMB/*", 4, gs_site_id);
				//sprintf(s_channel, "/%.*s/FMBNEW/*", 4, gs_site_id);
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

				LOG_head("RAS_Event_Publish_Msg_In");
				memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, RSUMRESDWH.SUB_RES_ID, sizeof(RSUMRESDWH.SUB_RES_ID));
				LOG_printf("RES_ID- %s   ",s_tmp);
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

