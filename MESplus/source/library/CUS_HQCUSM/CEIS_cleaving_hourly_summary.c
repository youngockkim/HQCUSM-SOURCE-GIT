/*******************************************************************************

    System      : MESplus
    Module      : Tabber Cell inspection
    File Name   : CEIS_Cleaving_Hourly_Summary.c
    Description : Tabber Cell inspection 
				  
    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.01.15  HANCHANG.KIM  CREATE
    Copyright(C) 1998-2020 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_HOURLY_SUMMARY_CLEAVING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int EAPMES_Validate_Hourly_Summary_Cleaving(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Hourly_Summary_Cleaving()
        - Cleaving Hourly Summary
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int EAPMES_Hourly_Summary_Cleaving(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;
	TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_HOURLY_SUMMARY_CLEAVING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_Hourly_Summary_Cleaving", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

	    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "TRAY_ID", TRS.get_string(in_node, "TRAY_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}


/*******************************************************************************
    EAPMES_HOURLY_SUMMARY_CLEAVING()
        - Cleaving Hourly Summary
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int EAPMES_HOURLY_SUMMARY_CLEAVING(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	struct CRASCLVHOR_TAG CRASCLVHOR; 
	struct MRASRESDEF_TAG MRASRESDEF;
 	struct worktime_tag cur_work_time;
	char cell_time[16];
	char s_sys_time[14];

	LOG_head("EAPMES_COLLECT_INSPECTION_VISION_CLEAVING");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

	//근무일 기준 가져오기
	memset(cell_time, '0', sizeof(cell_time));


	//START_TIME 기준으로 작업일자 가져오도록 변경 20200203
	TRS.copy(cell_time, strlen("YYYYMMDDHH"), in_node, "START_TIME");
	//memcpy(cell_time,s_sys_time, sizeof(s_sys_time));
	
	CCOM_get_work_time(cell_time, &cur_work_time);


	if(EAPMES_Validate_Hourly_Summary_Cleaving(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	//RESOURCE SELECT
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "RAS-0044");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "RES ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
	}

	/* CRASCLVLOS TABLE */
	CDB_init_crasclvhor(&CRASCLVHOR);
	TRS.copy(CRASCLVHOR.FACTORY, sizeof(CRASCLVHOR.FACTORY), in_node, "FACTORY");
	memcpy(CRASCLVHOR.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
	memset(CRASCLVHOR.WORK_TIME, '0', sizeof(CRASCLVHOR.WORK_TIME));
	TRS.copy(CRASCLVHOR.WORK_TIME, strlen("YYYYMMDDHH"), in_node, "START_TIME");
	memcpy(CRASCLVHOR.LINE_ID, MRASRESDEF.RES_CMF_1, sizeof(CRASCLVHOR.LINE_ID));
	TRS.copy(CRASCLVHOR.RES_ID, sizeof(CRASCLVHOR.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASCLVHOR.ORDER_ID, sizeof(CRASCLVHOR.ORDER_ID), in_node, "ORDER_ID"); 
	
	CDB_select_crasclvhor_for_update(1, &CRASCLVHOR);
	if (DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			TRS.copy(CRASCLVHOR.CREATE_USER_ID, sizeof(CRASCLVHOR.CREATE_USER_ID), in_node, "USERID");
			memcpy(CRASCLVHOR.CREATE_TIME, s_sys_time, sizeof(CRASCLVHOR.CREATE_TIME)); 

			CDB_insert_crasclvhor(&CRASCLVHOR);
			if (DB_error_code != DB_SUCCESS)
			{
				//
			}
		}
	}

	CRASCLVHOR.LD_INPUT = COM_atoi(TRS.get_string(in_node, "LD_INPUT"),strlen(TRS.get_string(in_node, "LD_INPUT")));
	CRASCLVHOR.LD_REJECT = COM_atoi(TRS.get_string(in_node, "LD_REJECT"),strlen(TRS.get_string(in_node, "LD_REJECT")));
	CRASCLVHOR.ULD_INPUT = COM_atoi(TRS.get_string(in_node, "ULD_INPUT"),strlen(TRS.get_string(in_node, "ULD_INPUT")));
	CRASCLVHOR.ULD_REJECT = COM_atoi(TRS.get_string(in_node, "ULD_REJECT"),strlen(TRS.get_string(in_node, "ULD_REJECT")));
	CRASCLVHOR.ULD_DEFECT_1 = COM_atoi(TRS.get_string(in_node, "ULD_DEFECT_1"),strlen(TRS.get_string(in_node, "ULD_DEFECT_1")));
	CRASCLVHOR.ULD_DEFECT_2 = COM_atoi(TRS.get_string(in_node, "ULD_DEFECT_2"),strlen(TRS.get_string(in_node, "ULD_DEFECT_2")));
	CRASCLVHOR.ULD_DEFECT_3 = COM_atoi(TRS.get_string(in_node, "ULD_DEFECT_3"),strlen(TRS.get_string(in_node, "ULD_DEFECT_3")));
	CRASCLVHOR.ULD_DEFECT_4 = COM_atoi(TRS.get_string(in_node, "ULD_DEFECT_4"),strlen(TRS.get_string(in_node, "ULD_DEFECT_4")));
	CRASCLVHOR.ULD_DEFECT_TOTAL = COM_atoi(TRS.get_string(in_node, "ULD_DEFECT_TOTAL"),strlen(TRS.get_string(in_node, "ULD_DEFECT_TOTAL")));
	TRS.copy(CRASCLVHOR.UPDATE_USER_ID, sizeof(CRASCLVHOR.UPDATE_USER_ID), in_node, "USERID");
	memcpy(CRASCLVHOR.UPDATE_TIME, s_sys_time, sizeof(CRASCLVHOR.UPDATE_TIME)); 
	
	//UPDATE
	CDB_update_crasclvhor(1,&CRASCLVHOR);
	if (DB_error_code != DB_SUCCESS)
	{
		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

/*******************************************************************************
    EAPMES_Validate_Hourly_Summary_Cleaving()
        - Main sub function of "EAPMES_VALIDATE_PRODUCTION_ORDER" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Hourly_Summary_Cleaving(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
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


    return MP_TRUE;
}
