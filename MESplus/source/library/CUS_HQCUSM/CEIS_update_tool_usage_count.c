/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_update_tool_usage_count.c
    Description : EAPMES Update Tool Usage Count Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Update_Tool_Usage_Count()
            + Setup service interface function
        - EAPMES_UPDATE_TOOL_USAGE_COUNT()
            + Main sub function of EAPMES_Update_Tool_Usage_Count function
            + Setup service main business function
        - EAPMES_Update_Tool_Usage_Count_Validation()
            + Main sub function of EAPMES_UPDATE_TOOL_USAGE_COUNT function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_UPDATE_TOOL_USAGE_COUNT()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Update_Tool_Usage_Count_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Update_Tool_Usage_Count()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Update_Tool_Usage_Count(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_UPDATE_TOOL_USAGE_COUNT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_UPDATE_TOOL_USAGE_COUNT", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

    /* Temp */
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));


    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */



    /* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	/****
	if(CallService(MODULE_EAP, 
		"MESEAP_Update_Tool_Usage_Count", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}
	****/

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);
    //CEIS_Save_Message_Log_For_List(in_node, out_node);
    //CEIS_Save_Message_Log_For_Single_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_UPDATE_TOOL_USAGE_COUNT()
        - Main sub function of "EAPMES_Update_Tool_Usage_Count" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_UPDATE_TOOL_USAGE_COUNT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASTOLSTS_TAG CRASTOLSTS;
    struct CRASTOLHIS_TAG CRASTOLHIS;
	struct CRASTOLRST_TAG CRASTOLRST;

    char s_sys_time[14];
	char c_reset_flag = 'N';
    int i = 0;
    int i_part_item_count = 0;
	
    TRSNode ** PART_ITEM;
    
    LOG_head("EAPMES_UPDATE_TOOL_USAGE_COUNT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Update_Tool_Usage_Count_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

    PART_ITEM = TRS.get_list(in_node, "PART_ITEM");
    i_part_item_count = TRS.get_item_count(in_node, "PART_ITEM");
	
	//22.04.19 IS-22-04-024  [프로그램_변경]Lami 설비에 대해 Tool_Usage_Count 이력 저장[lami 설비만 저장]
	//lami 인 경우 history 테이블에 데이터 남김.
	//나머지는 그대로 .
	if(memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-LAM-01", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-LAM-02", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-LAM-03", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-LAM-04", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-LAM-01", 12) == 0 || 
		    memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-LAM-02", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-LAM-03", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-LAM-04", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-LAM-01", 12) == 0 || 
		    memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-LAM-02", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-LAM-03", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-LAM-04", 12) == 0 )
	{

		
				for (i = 0; i < i_part_item_count; i++)
				{
					

					c_reset_flag = 'N';
					CDB_init_crastolsts(&CRASTOLSTS);
					TRS.copy(CRASTOLSTS.FACTORY, sizeof(CRASTOLSTS.FACTORY), in_node, IN_FACTORY);
					TRS.copy(CRASTOLSTS.RES_ID, sizeof(CRASTOLSTS.RES_ID), in_node, "RES_ID");
					TRS.copy(CRASTOLSTS.PART_NAME, sizeof(CRASTOLSTS.PART_NAME), PART_ITEM[i], "PART_NAME");

					CDB_select_crastolsts_for_update(1, &CRASTOLSTS);
	
					if(DB_error_code != DB_SUCCESS)
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							// Insert
							TRS.copy(CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID), in_node, "LINE_ID");

							if(COM_isnullspace(TRS.get_string(PART_ITEM[i], "PART_ID")) == MP_TRUE)
							{
								CRASTOLSTS.CHANGE_CNT = 0;
							}
							else
							{
								CRASTOLSTS.CHANGE_CNT = COM_atoi(TRS.get_string(PART_ITEM[i], "PART_ID"), (int)strlen(TRS.get_string(PART_ITEM[i], "PART_ID")));
							}
							CRASTOLSTS.CURR_USE_CNT = TRS.get_int(PART_ITEM[i], "CURR_USE_CNT");
							CRASTOLSTS.MAX_USE_CNT = TRS.get_int(PART_ITEM[i], "MAX_USE_CNT");
							CRASTOLSTS.LIMIT_USE_CNT = TRS.get_int(PART_ITEM[i], "LIMIT_USE_CNT");

							TRS.copy(CRASTOLSTS.CREATE_USER_ID, sizeof(CRASTOLSTS.CREATE_USER_ID), in_node, "CLIENT_ID");
							memcpy(CRASTOLSTS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
							memcpy(CRASTOLSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
							CRASTOLSTS.LAST_HIST_SEQ = 1;

							CDB_insert_crastolsts(&CRASTOLSTS);
							if(DB_error_code != DB_SUCCESS)
							{
								strcpy(s_msg_code, "RAS-0004");
								TRS.add_fieldmsg(out_node, "CRASTOLSTS INSERT", MP_NVST);
								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTOLSTS.FACTORY), CRASTOLSTS.FACTORY);
								TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTOLSTS.RES_ID), CRASTOLSTS.RES_ID);
								TRS.add_fieldmsg(out_node, "PART_NAME", MP_STR, sizeof(CRASTOLSTS.PART_NAME), CRASTOLSTS.PART_NAME);
								TRS.add_dberrmsg(out_node,DB_error_msg);

								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								gs_log_type.category = MP_LOG_CATE_VIEW;
								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
								return MP_FALSE;                
							}
						}
						else
						{
							strcpy(s_msg_code, "RAS-0004");
							TRS.add_fieldmsg(out_node, "CRASTOLSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTOLSTS.FACTORY), CRASTOLSTS.FACTORY);
							TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTOLSTS.RES_ID), CRASTOLSTS.RES_ID);
							TRS.add_fieldmsg(out_node, "PART_NAME", MP_STR, sizeof(CRASTOLSTS.PART_NAME), CRASTOLSTS.PART_NAME);
							TRS.add_dberrmsg(out_node,DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;

						}
        
					}
					else
					{
						if (CRASTOLSTS.CURR_USE_CNT == TRS.get_int(PART_ITEM[i], "CURR_USE_CNT"))
						{
							continue;
						}

						if (CRASTOLSTS.CURR_USE_CNT > TRS.get_int(PART_ITEM[i], "CURR_USE_CNT"))
						{
							 c_reset_flag = 'Y';
				
						}
			
						if (c_reset_flag == 'Y')
						{
							
							CRASTOLSTS.CHANGE_CNT = CRASTOLSTS.CHANGE_CNT + 1;	
							CRASTOLSTS.LAST_HIST_SEQ = 1;
						}
						else
						{
							CRASTOLSTS.LAST_HIST_SEQ =  CRASTOLSTS.LAST_HIST_SEQ + 1;
						}
			
						TRS.copy(CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID), in_node, "LINE_ID");
						CRASTOLSTS.CURR_USE_CNT = TRS.get_int(PART_ITEM[i], "CURR_USE_CNT");
						CRASTOLSTS.MAX_USE_CNT = TRS.get_int(PART_ITEM[i], "MAX_USE_CNT");
						CRASTOLSTS.LIMIT_USE_CNT = TRS.get_int(PART_ITEM[i], "LIMIT_USE_CNT");
						memcpy(CRASTOLSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
						TRS.copy(CRASTOLSTS.UPDATE_USER_ID, sizeof(CRASTOLSTS.UPDATE_USER_ID), in_node, "CLIENT_ID");

						CDB_update_crastolsts(1, &CRASTOLSTS);
						if(DB_error_code != DB_SUCCESS)
						{
							strcpy(s_msg_code, "RAS-0004");
							TRS.add_fieldmsg(out_node, "CRASTOLSTS UPDATE", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTOLSTS.FACTORY), CRASTOLSTS.FACTORY);
							TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTOLSTS.RES_ID), CRASTOLSTS.RES_ID);
							TRS.add_fieldmsg(out_node, "PART_NAME", MP_STR, sizeof(CRASTOLSTS.PART_NAME), CRASTOLSTS.PART_NAME);
							TRS.add_dberrmsg(out_node,DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;                  
						}

					}
					//HISTORY 기록
					CDB_init_crastolhis(&CRASTOLHIS);
					TRS.copy(CRASTOLHIS.FACTORY, sizeof(CRASTOLHIS.FACTORY), in_node, IN_FACTORY);
					TRS.copy(CRASTOLHIS.RES_ID, sizeof(CRASTOLHIS.RES_ID), in_node, "RES_ID");
					TRS.copy(CRASTOLHIS.PART_NAME, sizeof(CRASTOLHIS.PART_NAME), PART_ITEM[i], "PART_NAME");

					CRASTOLHIS.HIST_SEQ = CRASTOLSTS.LAST_HIST_SEQ;
					CRASTOLHIS.CHANGE_CNT = CRASTOLSTS.CHANGE_CNT;

					TRS.copy(CRASTOLHIS.LINE_ID, sizeof(CRASTOLHIS.LINE_ID), in_node, "LINE_ID");
					CRASTOLHIS.CURR_USE_CNT = TRS.get_int(PART_ITEM[i], "CURR_USE_CNT");
					CRASTOLHIS.MAX_USE_CNT = TRS.get_int(PART_ITEM[i], "MAX_USE_CNT");
					CRASTOLHIS.LIMIT_USE_CNT = TRS.get_int(PART_ITEM[i], "LIMIT_USE_CNT");

					memcpy(CRASTOLHIS.CREATE_TIME, CRASTOLSTS.UPDATE_TIME, sizeof(CRASTOLHIS.CREATE_TIME));
					memcpy(CRASTOLHIS.CREATE_USER_ID, CRASTOLSTS.CREATE_USER_ID, sizeof(CRASTOLSTS.CREATE_USER_ID));
					memcpy(CRASTOLHIS.UPDATE_USER_ID, CRASTOLSTS.UPDATE_USER_ID, sizeof(CRASTOLSTS.UPDATE_USER_ID));
					memcpy(CRASTOLHIS.UPDATE_TIME, CRASTOLSTS.UPDATE_TIME, sizeof(CRASTOLHIS.UPDATE_TIME));

					CDB_insert_crastolhis(&CRASTOLHIS);
					if(DB_error_code != DB_SUCCESS)
					{
						// DO NOTHING ( HISTORY   큰의미없음)     
						// RESET 시 데이터 삭제함.
					}



				}
	}
	else					//lami가 아닌 경우
	{
				for (i = 0; i < i_part_item_count; i++)
				{
					//
					// Tool Status
					//

					c_reset_flag = 'N';
					CDB_init_crastolsts(&CRASTOLSTS);
					TRS.copy(CRASTOLSTS.FACTORY, sizeof(CRASTOLSTS.FACTORY), in_node, IN_FACTORY);
					TRS.copy(CRASTOLSTS.RES_ID, sizeof(CRASTOLSTS.RES_ID), in_node, "RES_ID");
					TRS.copy(CRASTOLSTS.PART_NAME, sizeof(CRASTOLSTS.PART_NAME), PART_ITEM[i], "PART_NAME");

					CDB_select_crastolsts_for_update(1, &CRASTOLSTS);
	
					if(DB_error_code != DB_SUCCESS)
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							// Insert
							TRS.copy(CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID), in_node, "LINE_ID");

							if(COM_isnullspace(TRS.get_string(PART_ITEM[i], "PART_ID")) == MP_TRUE)
							{
								CRASTOLSTS.CHANGE_CNT = 0;
							}
							else
							{
								CRASTOLSTS.CHANGE_CNT = COM_atoi(TRS.get_string(PART_ITEM[i], "PART_ID"), (int)strlen(TRS.get_string(PART_ITEM[i], "PART_ID")));
							}
							CRASTOLSTS.CURR_USE_CNT = TRS.get_int(PART_ITEM[i], "CURR_USE_CNT");
							CRASTOLSTS.MAX_USE_CNT = TRS.get_int(PART_ITEM[i], "MAX_USE_CNT");
							CRASTOLSTS.LIMIT_USE_CNT = TRS.get_int(PART_ITEM[i], "LIMIT_USE_CNT");

							TRS.copy(CRASTOLSTS.CREATE_USER_ID, sizeof(CRASTOLSTS.CREATE_USER_ID), in_node, "CLIENT_ID");
							memcpy(CRASTOLSTS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
							memcpy(CRASTOLSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
							CRASTOLSTS.LAST_HIST_SEQ = 1;

							CDB_insert_crastolsts(&CRASTOLSTS);
							if(DB_error_code != DB_SUCCESS)
							{
								strcpy(s_msg_code, "RAS-0004");
								TRS.add_fieldmsg(out_node, "CRASTOLSTS INSERT", MP_NVST);
								TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTOLSTS.FACTORY), CRASTOLSTS.FACTORY);
								TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTOLSTS.RES_ID), CRASTOLSTS.RES_ID);
								TRS.add_fieldmsg(out_node, "PART_NAME", MP_STR, sizeof(CRASTOLSTS.PART_NAME), CRASTOLSTS.PART_NAME);
								TRS.add_dberrmsg(out_node,DB_error_msg);

								gs_log_type.type = MP_LOG_ERROR;
								gs_log_type.e_type = MP_LOG_E_SYSTEM;
								gs_log_type.category = MP_LOG_CATE_VIEW;
								COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
								return MP_FALSE;                
							}
						}
						else
						{
							strcpy(s_msg_code, "RAS-0004");
							TRS.add_fieldmsg(out_node, "CRASTOLSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTOLSTS.FACTORY), CRASTOLSTS.FACTORY);
							TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTOLSTS.RES_ID), CRASTOLSTS.RES_ID);
							TRS.add_fieldmsg(out_node, "PART_NAME", MP_STR, sizeof(CRASTOLSTS.PART_NAME), CRASTOLSTS.PART_NAME);
							TRS.add_dberrmsg(out_node,DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;

						}
        
					}
					else
					{
						if (CRASTOLSTS.CURR_USE_CNT == TRS.get_int(PART_ITEM[i], "CURR_USE_CNT"))
						{
							continue;
						}

						if (CRASTOLSTS.CURR_USE_CNT > TRS.get_int(PART_ITEM[i], "CURR_USE_CNT"))
						{
							 c_reset_flag = 'Y';
				
						}
			
						if (c_reset_flag == 'Y')
						{
							//RESET DATA INSERT
							CDB_init_crastolrst(&CRASTOLRST);
							TRS.copy(CRASTOLRST.FACTORY, sizeof(CRASTOLRST.FACTORY), in_node, IN_FACTORY);
							TRS.copy(CRASTOLRST.RES_ID, sizeof(CRASTOLRST.RES_ID), in_node, "RES_ID");
							//TRS.copy(CRASTOLRST.PART_ID, sizeof(CRASTOLRST.PART_ID), PART_ITEM[i], "PART_ID");
							if(COM_isnullspace(TRS.get_string(PART_ITEM[i], "PART_ID")) == MP_TRUE)
							{
								CRASTOLRST.CHANGE_CNT = 0;
							}
							else
							{
								CRASTOLRST.CHANGE_CNT = COM_atoi(TRS.get_string(PART_ITEM[i], "PART_ID"), (int)strlen(TRS.get_string(PART_ITEM[i], "PART_ID")));
							}

							TRS.copy(CRASTOLRST.PART_NAME, sizeof(CRASTOLRST.PART_NAME), PART_ITEM[i], "PART_NAME");

							TRS.copy(CRASTOLRST.LINE_ID, sizeof(CRASTOLRST.LINE_ID), in_node, "LINE_ID");
							CRASTOLRST.CURR_USE_CNT = CRASTOLSTS.CURR_USE_CNT;
							CRASTOLRST.MAX_USE_CNT = CRASTOLSTS.MAX_USE_CNT;
							CRASTOLRST.LIMIT_USE_CNT = CRASTOLSTS.LIMIT_USE_CNT;

							memcpy(CRASTOLRST.CREATE_TIME, CRASTOLSTS.CREATE_TIME, sizeof(CRASTOLRST.CREATE_TIME));
							memcpy(CRASTOLRST.UPDATE_TIME, CRASTOLSTS.UPDATE_TIME, sizeof(CRASTOLRST.UPDATE_TIME));
							memcpy(CRASTOLRST.RESET_TIME, s_sys_time, sizeof(CRASTOLRST.RESET_TIME));
							CDB_insert_crastolrst( &CRASTOLRST);
							if(DB_error_code != DB_SUCCESS)
							{
								//DO NOTHING
							}
							CRASTOLRST.CNT_1 = CRASTOLSTS.LAST_HIST_SEQ;
							CRASTOLSTS.LAST_HIST_SEQ =  0;

							//HISTORY DATA DELETE 불필요한 이력으로 이력 안남김.  2019.10.24 JGCHOI.
							//CDB_init_crastolhis(&CRASTOLHIS);
							//TRS.copy(CRASTOLHIS.FACTORY, sizeof(CRASTOLHIS.FACTORY), in_node, IN_FACTORY);
							//TRS.copy(CRASTOLHIS.RES_ID, sizeof(CRASTOLHIS.RES_ID), in_node, "RES_ID");
							//TRS.copy(CRASTOLHIS.PART_ID, sizeof(CRASTOLHIS.PART_ID), PART_ITEM[i], "PART_ID");
							//TRS.copy(CRASTOLHIS.PART_NAME, sizeof(CRASTOLHIS.PART_NAME), PART_ITEM[i], "PART_NAME");
							//CDB_delete_crastolhis( 2, &CRASTOLHIS);
							//if(DB_error_code != DB_SUCCESS)
							//{
							//	//DO NOTHING
							//}

						}
						// Update
						if(COM_isnullspace(TRS.get_string(PART_ITEM[i], "PART_ID")) == MP_TRUE)
						{
							CRASTOLSTS.CHANGE_CNT = 0;
						}
						else
						{
							CRASTOLSTS.CHANGE_CNT = COM_atoi(TRS.get_string(PART_ITEM[i], "PART_ID"), (int)strlen(TRS.get_string(PART_ITEM[i], "PART_ID")));
						}
						TRS.copy(CRASTOLSTS.LINE_ID, sizeof(CRASTOLSTS.LINE_ID), in_node, "LINE_ID");
						CRASTOLSTS.CURR_USE_CNT = TRS.get_int(PART_ITEM[i], "CURR_USE_CNT");
						CRASTOLSTS.MAX_USE_CNT = TRS.get_int(PART_ITEM[i], "MAX_USE_CNT");
						CRASTOLSTS.LIMIT_USE_CNT = TRS.get_int(PART_ITEM[i], "LIMIT_USE_CNT");
						CRASTOLSTS.LAST_HIST_SEQ =  CRASTOLSTS.LAST_HIST_SEQ + 1;
						memcpy(CRASTOLSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
						TRS.copy(CRASTOLSTS.UPDATE_USER_ID, sizeof(CRASTOLSTS.UPDATE_USER_ID), in_node, "CLIENT_ID");

						CDB_update_crastolsts(1, &CRASTOLSTS);
						if(DB_error_code != DB_SUCCESS)
						{
							strcpy(s_msg_code, "RAS-0004");
							TRS.add_fieldmsg(out_node, "CRASTOLSTS UPDATE", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTOLSTS.FACTORY), CRASTOLSTS.FACTORY);
							TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTOLSTS.RES_ID), CRASTOLSTS.RES_ID);
							TRS.add_fieldmsg(out_node, "PART_NAME", MP_STR, sizeof(CRASTOLSTS.PART_NAME), CRASTOLSTS.PART_NAME);
							TRS.add_dberrmsg(out_node,DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;                  
						}

					}

					//
					// Tool History
					//
					/* 불필요한 이력으로 이력 안남김.  2019.10.24 JGCHOI.
					CDB_init_crastolhis(&CRASTOLHIS);
					TRS.copy(CRASTOLHIS.FACTORY, sizeof(CRASTOLHIS.FACTORY), in_node, IN_FACTORY);
					TRS.copy(CRASTOLHIS.RES_ID, sizeof(CRASTOLHIS.RES_ID), in_node, "RES_ID");
					TRS.copy(CRASTOLHIS.PART_ID, sizeof(CRASTOLHIS.PART_ID), PART_ITEM[i], "PART_ID");
					TRS.copy(CRASTOLHIS.PART_NAME, sizeof(CRASTOLHIS.PART_NAME), PART_ITEM[i], "PART_NAME");

					CRASTOLHIS.HIST_SEQ = CRASTOLSTS.LAST_HIST_SEQ;

					TRS.copy(CRASTOLHIS.LINE_ID, sizeof(CRASTOLHIS.LINE_ID), in_node, "LINE_ID");
					CRASTOLHIS.CURR_USE_CNT = TRS.get_int(PART_ITEM[i], "CURR_USE_CNT");
					CRASTOLHIS.MAX_USE_CNT = TRS.get_int(PART_ITEM[i], "MAX_USE_CNT");
					CRASTOLHIS.LIMIT_USE_CNT = TRS.get_int(PART_ITEM[i], "LIMIT_USE_CNT");

					memcpy(CRASTOLHIS.CREATE_TIME, CRASTOLSTS.CREATE_TIME, sizeof(CRASTOLHIS.CREATE_TIME));
					memcpy(CRASTOLHIS.CREATE_USER_ID, CRASTOLSTS.CREATE_USER_ID, sizeof(CRASTOLSTS.CREATE_USER_ID));
					memcpy(CRASTOLHIS.UPDATE_USER_ID, CRASTOLSTS.UPDATE_USER_ID, sizeof(CRASTOLSTS.UPDATE_USER_ID));
					memcpy(CRASTOLHIS.UPDATE_TIME, CRASTOLSTS.UPDATE_TIME, sizeof(CRASTOLHIS.UPDATE_TIME));

					CDB_insert_crastolhis(&CRASTOLHIS);
					if(DB_error_code != DB_SUCCESS)
					{
						// DO NOTHING ( HISTORY   큰의미없음)     
						// RESET 시 데이터 삭제함.
					}
					*/


				}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Update_Tool_Usage_Count_Validation()
        - Main sub function of "EAPMES_UPDATE_TOOL_USAGE_COUNT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Update_Tool_Usage_Count_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }


    return MP_TRUE;
}