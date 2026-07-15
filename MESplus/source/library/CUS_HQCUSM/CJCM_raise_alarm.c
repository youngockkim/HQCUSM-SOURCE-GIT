/******************************************************************************'

    System      : MESplus
    Module      : CJCM
    File Name   : CJCM_raise_alarm.c
    Description : Raise_Alarm Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CJCM_Raise_Alarm()
            + Create/Update/Delete Raise_Alarm definition
        - CJCM_RAISE_ALARM()
            + Main sub function of CJCM_Raise_Alarm function
            + Create/Update/Delete Raise_Alarm definition
        - CJCM_Raise_Alarm_Validation()
            + Main sub function of CJCM_RAISE_ALARM function
            + Check the condition for create/update/delete Raise_Alarm
    Detail Description
        - CJCM_RAISE_ALARM()
            + h_proc_step
                + MP_STEP_CREATE : Create Raise_Alarm definition
                + MP_STEP_UPDATE : Update Raise_Alarm definition
                + MP_STEP_DELETE : Delete Raise_Alarm definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/10/20             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CJCM_Raise_Alarm_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CJCM_Raise_Alarm()
        - Create/Update/Delete Raise_Alarm definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_Raise_Alarm(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CJCM_RAISE_ALARM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CJCM_RAISE_ALARM", out_node);

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
    CJCM_RAISE_ALARM()
        - Main sub function of "CJCM_Raise_Alarm" function
        - Create/Update/Delete Raise_Alarm definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CJCM_RAISE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CJCM_ALARM_TAG CJCM_ALARM;
	struct MALMMSGDEF_TAG MALMMSGDEF;

	TRSNode* tran_in_node;
    char   s_sys_time[14];
	char   c_alarm_desc[200];
	char   s_tmpstr[2000];
	char   s_order_id[25];
	char   s_start_date[10];
	char   s_mat_id[30];
	char   s_mat_desc[200];
	char   s_line_code[40];

	int   i_case;

    LOG_head("CJCM_RAISE_ALARM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

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

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
		TRS.set_string(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
    }
	i_case = 1;

    CDB_init_cjcm_alarm(&CJCM_ALARM);
    TRS.copy(CJCM_ALARM.FACTORY, sizeof(CJCM_ALARM.FACTORY), in_node, IN_FACTORY);
    CDB_open_cjcm_alarm(i_case, &CJCM_ALARM);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CJCM_ALARM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCM_ALARM.FACTORY), CJCM_ALARM.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	while(1)
    {
        CDB_fetch_cjcm_alarm(i_case, &CJCM_ALARM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cjcm_alarm(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CJCM_ALARM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CJCM_ALARM.FACTORY), CJCM_ALARM.FACTORY);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cjcm_alarm(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		memset(s_tmpstr, ' ', sizeof(s_tmpstr));
		memset(s_order_id, ' ', sizeof(s_order_id));
		memset(s_start_date, ' ', sizeof(s_start_date));
		memset(s_mat_id, ' ', sizeof(s_mat_id));
		memset(s_mat_desc, ' ', sizeof(s_mat_desc));
		memset(s_line_code, ' ', sizeof(s_line_code));
		memset(c_alarm_desc, ' ', sizeof(c_alarm_desc));

		DBC_init_malmmsgdef(&MALMMSGDEF);
		memcpy(MALMMSGDEF.FACTORY, CJCM_ALARM.FACTORY, sizeof(MALMMSGDEF.FACTORY)); 
		memcpy(MALMMSGDEF.ALARM_ID, CJCM_ALARM.ALARM_CODE, sizeof(MALMMSGDEF.ALARM_ID));
		DBC_select_malmmsgdef(1, &MALMMSGDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			COM_memcpy_add_null(c_alarm_desc, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
		}
		else
		{
			COM_memcpy_add_null(c_alarm_desc, "Job Change Alarm", (int)strlen("Job Change Alarm"));
		}

		COM_memcpy_add_null(s_order_id, CJCM_ALARM.ORDER_ID, sizeof(CJCM_ALARM.ORDER_ID));
		COM_memcpy_add_null(s_start_date, CJCM_ALARM.ORD_START_DATE, sizeof(CJCM_ALARM.ORD_START_DATE));
		COM_memcpy_add_null(s_mat_id, CJCM_ALARM.MAT_ID, sizeof(CJCM_ALARM.MAT_ID));
		COM_memcpy_add_null(s_mat_desc, CJCM_ALARM.MAT_DESC, sizeof(CJCM_ALARM.MAT_DESC));
		COM_memcpy_add_null(s_line_code, CJCM_ALARM.LINE_ID, sizeof(CJCM_ALARM.LINE_ID));
		
		sprintf(s_tmpstr, "nbsp;Order No.: %s <br>nbsp;Order Start Date : %s <br>nbsp;Line Code : %s <br>nbsp;Material : [%s] - %s <br>nbsp;Job Item Count : %i", s_order_id, s_start_date, s_line_code,  s_mat_id, s_mat_desc, CJCM_ALARM.ITEM_COUNT);

		tran_in_node = TRS.create_node("alarm_in_node");
		CCOM_copy_in_node(in_node, tran_in_node);

		TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_factory(in_node));
		TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
		TRS.set_string(tran_in_node, "ALARM_ID", CJCM_ALARM.ALARM_CODE, sizeof(CJCM_ALARM.ALARM_CODE)); 
		TRS.set_nstring(tran_in_node, "SOURCE_ID_1", "JCM");
		TRS.set_string(tran_in_node, "ALARM_SUBJECT", c_alarm_desc, strlen(c_alarm_desc));
		TRS.set_nstring(tran_in_node, "ALARM_MSG", s_tmpstr);
	
		if(ALM_RAISE_ALARM(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
		TRS.free_node(tran_in_node);

    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 
