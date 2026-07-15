/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_repair_insentive.c
    Description : Repair_Insentive Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Repair_Insentive()
            + Create/Update/Delete Repair_Insentive definition
        - CWIP_UPDATE_REPAIR_INSENTIVE()
            + Main sub function of CWIP_Update_Repair_Insentive function
            + Create/Update/Delete Repair_Insentive definition
        - CWIP_Update_Repair_Insentive_Validation()
            + Main sub function of CWIP_UPDATE_REPAIR_INSENTIVE function
            + Check the condition for create/update/delete Repair_Insentive
    Detail Description
        - CWIP_UPDATE_REPAIR_INSENTIVE()
            + h_proc_step
                + MP_STEP_CREATE : Create Repair_Insentive definition
                + MP_STEP_UPDATE : Update Repair_Insentive definition
                + MP_STEP_DELETE : Delete Repair_Insentive definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2022-06-28             Create by Generator

    Copyright(C) 1998-2022 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Repair_Insentive_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Repair_Insentive()
        - Create/Update/Delete Repair_Insentive definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Repair_Insentive(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_REPAIR_INSENTIVE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_REPAIR_INSENTIVE", out_node);

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
    CWIP_UPDATE_REPAIR_INSENTIVE()
        - Main sub function of "CWIP_Update_Repair_Insentive" function
        - Create/Update/Delete Repair_Insentive definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_REPAIR_INSENTIVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPREPOIT_TAG CWIPREPOIT;
    char   s_sys_time[14];
	
	int cnt_start = 0;


	LOG_head("CWIP_UPDATE_REPAIR_INSENTIVE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

  
	if(CWIP_Update_Repair_Insentive_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//1.START 인경우 END 되지 않은 데이터가 존재 하는지 확인
    CDB_init_cwiprepoit(&CWIPREPOIT);
    TRS.copy(CWIPREPOIT.FACTORY, sizeof(CWIPREPOIT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPREPOIT.WORKER, sizeof(CWIPREPOIT.WORKER), in_node, "WORKER");
    TRS.copy(CWIPREPOIT.LOCATION, sizeof(CWIPREPOIT.LOCATION), in_node, "LOCATION");

	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)		//start 인경우 
	{
		memcpy(CWIPREPOIT.START_TIME, s_sys_time, sizeof(CWIPREPOIT.START_TIME));    
	}
	else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)		//END  인경우 
	{
		TRS.copy(CWIPREPOIT.START_TIME, sizeof(CWIPREPOIT.START_TIME), in_node, "START_TIME");
	}

    //TRS.copy(CWIPREPOIT.START_TIME, sizeof(CWIPREPOIT.START_TIME), in_node, "START_TIME");
	//memcpy(CWIPREPOIT.START_TIME, s_sys_time, sizeof(CWIPREPOIT.START_TIME));    
	TRS.copy(CWIPREPOIT.END_TIME, sizeof(CWIPREPOIT.END_TIME), in_node, "END_TIME");
    TRS.copy(CWIPREPOIT.STATUS, sizeof(CWIPREPOIT.STATUS), in_node, "STATUS");
    TRS.copy(CWIPREPOIT.CREATE_USER_ID, sizeof(CWIPREPOIT.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPREPOIT.CREATE_TIME, sizeof(CWIPREPOIT.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPREPOIT.UPDATE_USER_ID, sizeof(CWIPREPOIT.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPREPOIT.UPDATE_TIME, sizeof(CWIPREPOIT.UPDATE_TIME), in_node, "UPDATE_TIME");
    TRS.copy(CWIPREPOIT.CMF_1, sizeof(CWIPREPOIT.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPREPOIT.CMF_2, sizeof(CWIPREPOIT.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPREPOIT.CMF_3, sizeof(CWIPREPOIT.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPREPOIT.CMF_4, sizeof(CWIPREPOIT.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPREPOIT.CMF_5, sizeof(CWIPREPOIT.CMF_5), in_node, "CMF_5");
	TRS.copy(CWIPREPOIT.CREATE_USER_ID, sizeof(CWIPREPOIT.CREATE_USER_ID), in_node, IN_USERID);
	memcpy(CWIPREPOIT.CREATE_TIME, s_sys_time, sizeof(CWIPREPOIT.CREATE_TIME));

	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)		//start 인경우 
	{
			//기존에 end되지 않은 데이터가 존재하는지 확인
			cnt_start = 0;
			cnt_start = (int) CDB_select_cwiprepoit_scalar(2,&CWIPREPOIT);
			if(cnt_start > 0 )
			{
					strcpy(s_msg_code, "WIP-0615");
					TRS.add_fieldmsg(out_node, "CWIPREPOIT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREPOIT.FACTORY), CWIPREPOIT.FACTORY);
					TRS.add_fieldmsg(out_node, "WORKER", MP_STR, sizeof(CWIPREPOIT.WORKER), CWIPREPOIT.WORKER);
					TRS.add_fieldmsg(out_node, "LOCATION", MP_STR, sizeof(CWIPREPOIT.LOCATION), CWIPREPOIT.LOCATION);
					TRS.add_fieldmsg(out_node, "START_TIME", MP_STR, sizeof(CWIPREPOIT.START_TIME), CWIPREPOIT.START_TIME);
					TRS.add_fieldmsg(out_node, "END_TIME", MP_STR, sizeof(CWIPREPOIT.END_TIME), CWIPREPOIT.END_TIME);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
			}

			CDB_insert_cwiprepoit(&CWIPREPOIT);
			if(DB_error_code != DB_SUCCESS)
			{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPREPOIT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREPOIT.FACTORY), CWIPREPOIT.FACTORY);
					TRS.add_fieldmsg(out_node, "WORKER", MP_STR, sizeof(CWIPREPOIT.WORKER), CWIPREPOIT.WORKER);
					TRS.add_fieldmsg(out_node, "LOCATION", MP_STR, sizeof(CWIPREPOIT.LOCATION), CWIPREPOIT.LOCATION);
					TRS.add_fieldmsg(out_node, "START_TIME", MP_STR, sizeof(CWIPREPOIT.START_TIME), CWIPREPOIT.START_TIME);
					TRS.add_fieldmsg(out_node, "END_TIME", MP_STR, sizeof(CWIPREPOIT.END_TIME), CWIPREPOIT.END_TIME);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
			 }
	}


	//2.END 인 경우 15시간 이내 END 되지 않은 데이터가 존재하는 경우
	if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)		//END  인경우 
	{
		//기존 start_time 기준 end되지 않은 데이터가 존재하는지 확인
		
		cnt_start = 0;
		cnt_start = (int) CDB_select_cwiprepoit_scalar(3,&CWIPREPOIT);
		if(cnt_start < 1 )
		{
				strcpy(s_msg_code, "WIP-0615");
				TRS.add_fieldmsg(out_node, "CWIPREPOIT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREPOIT.FACTORY), CWIPREPOIT.FACTORY);
				TRS.add_fieldmsg(out_node, "WORKER", MP_STR, sizeof(CWIPREPOIT.WORKER), CWIPREPOIT.WORKER);
				TRS.add_fieldmsg(out_node, "LOCATION", MP_STR, sizeof(CWIPREPOIT.LOCATION), CWIPREPOIT.LOCATION);
				TRS.add_fieldmsg(out_node, "START_TIME", MP_STR, sizeof(CWIPREPOIT.START_TIME), CWIPREPOIT.START_TIME);
				TRS.add_fieldmsg(out_node, "END_TIME", MP_STR, sizeof(CWIPREPOIT.END_TIME), CWIPREPOIT.END_TIME);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

 	    TRS.copy(CWIPREPOIT.UPDATE_USER_ID, sizeof(CWIPREPOIT.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPREPOIT.UPDATE_TIME, s_sys_time, sizeof(CWIPREPOIT.UPDATE_TIME));
		memcpy(CWIPREPOIT.END_TIME, s_sys_time, sizeof(CWIPREPOIT.END_TIME));
		CDB_update_cwiprepoit(2, &CWIPREPOIT);
		if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPREPOIT UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREPOIT.FACTORY), CWIPREPOIT.FACTORY);
            TRS.add_fieldmsg(out_node, "WORKER", MP_STR, sizeof(CWIPREPOIT.WORKER), CWIPREPOIT.WORKER);
            TRS.add_fieldmsg(out_node, "LOCATION", MP_STR, sizeof(CWIPREPOIT.LOCATION), CWIPREPOIT.LOCATION);
            TRS.add_fieldmsg(out_node, "START_TIME", MP_STR, sizeof(CWIPREPOIT.START_TIME), CWIPREPOIT.START_TIME);
            TRS.add_fieldmsg(out_node, "END_TIME", MP_STR, sizeof(CWIPREPOIT.END_TIME), CWIPREPOIT.END_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		TRS.add_string(out_node, "END_TIME", CWIPREPOIT.END_TIME, sizeof(CWIPREPOIT.END_TIME));
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/********************************************************************************
    CWIP_Update_Repair_Insentive_Validation()
        - Main sub function of "CWIP_UPDATE_REPAIR_INSENTIVE" function
        - Check the condition for create/update/delete Repair_Insentive
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Repair_Insentive_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
   
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

   

    return MP_TRUE;
}



