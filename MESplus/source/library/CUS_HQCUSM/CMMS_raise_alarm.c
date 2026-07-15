/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_raise_alarm.c
    Description : Raise MMS Alarm function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Raise_Alarm()
            + Raise MMS Alarm definition List
        - CMMS_RAISE_ALARM()
            + Main sub function of CMMS_Raise_Alarm function
            + Raise MMS Alarm List
    Detail Description
        - CMMS_RAISE_ALARM()
            + h_proc_step
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-05-23             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_Raise_Alarm()
        - Raise MMS Alarm
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Raise_Alarm(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_RAISE_ALARM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_RAISE_ALARM", out_node);

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
    CMMS_RAISE_ALARM()
        - Main sub function of "CMMS_Raise_Alarm" function
        - View Calibration_Plan definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_RAISE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALPLN_TAG CMMSCALPLN;
	struct CMMSANAPLN_TAG CMMSANAPLN;
	struct CMMSEQPDEF_TAG CMMSEQPDEF;
	struct MALMMSGDEF_TAG MALMMSGDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

	TRSNode* tran_in_node;
	char s_tmpstr[2000];
	char s_equip_id[50];
	char s_equip_name[51];
	char c_alarm_flag;
	char c_alarm_code[20];
	char c_alarm_desc[200];
	char c_plan_date[50];
	char c_analysis_method[50];
	//char c_[50];
    int i_case;
	int i_gcm_case;

    LOG_head("CMMS_RAISE_ALARM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
		TRS.set_string(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
    }
   
	i_case = 3;

    CDB_init_cmmscalpln(&CMMSCALPLN);
    TRS.copy(CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY), in_node, IN_FACTORY);

    CDB_open_cmmscalpln(i_case, &CMMSCALPLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSCALPLN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	memset(s_tmpstr, 0x00, sizeof(s_tmpstr));
	memset(c_alarm_code, 0x00, sizeof(c_alarm_code));
	memset(c_alarm_desc, 0x00, sizeof(c_alarm_desc));
	c_alarm_flag = 'N';
    while(1)
    {
        CDB_fetch_cmmscalpln(i_case, &CMMSCALPLN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmscalpln(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSCALPLN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmscalpln(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		memset(s_equip_id, 0x00, sizeof(s_equip_id));
		memset(s_equip_name, 0x00, sizeof(s_equip_name));
		memset(c_plan_date, 0x00, sizeof(c_plan_date));
		
		if (COM_isnullspace(c_alarm_code) == MP_FALSE)
		{
			if (memcmp(c_alarm_code, CMMSCALPLN.ALARM_CODE, strlen(c_alarm_code)) != 0)
			{
				if (c_alarm_flag == 'Y')
				{
					memset(c_alarm_desc, 0x00, sizeof(c_alarm_desc));
					DBC_init_malmmsgdef(&MALMMSGDEF);
					memcpy(MALMMSGDEF.FACTORY, CMMSCALPLN.FACTORY, sizeof(MALMMSGDEF.FACTORY)); 
					memcpy(MALMMSGDEF.ALARM_ID, c_alarm_code, sizeof(MALMMSGDEF.ALARM_ID));
					DBC_select_malmmsgdef(1, &MALMMSGDEF);
					if(DB_error_code == DB_SUCCESS)
					{
						COM_memcpy_add_null(c_alarm_desc, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
					}
					else
					{
						COM_memcpy_add_null(c_alarm_desc, "Instrument Calibration Plan Alarm", (int)strlen("Instrument Calibration Plan Alarm"));//size_t -> int 형변환 고려 2023-07-04
					}
					
					tran_in_node = TRS.create_node("alarm_in_node");
					CCOM_copy_in_node(in_node, tran_in_node);

					TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_factory(in_node));
					TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
					TRS.set_string(tran_in_node, "ALARM_ID", c_alarm_code, strlen(c_alarm_code)); 
					TRS.set_nstring(tran_in_node, "SOURCE_ID_1", "MMS");
					TRS.set_string(tran_in_node, "ALARM_SUBJECT", c_alarm_desc, strlen(c_alarm_desc));
					TRS.set_nstring(tran_in_node, "ALARM_MSG", s_tmpstr);
	
					if(ALM_RAISE_ALARM(s_msg_code, tran_in_node, out_node) == MP_FALSE)
					{
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						TRS.free_node(tran_in_node);
						return MP_FALSE;
					}
					TRS.free_node(tran_in_node);
					memset(s_tmpstr, 0x00, sizeof(s_tmpstr));
				}
			}
		}

		COM_memcpy_add_null(c_alarm_code, CMMSCALPLN.ALARM_CODE, sizeof(CMMSCALPLN.ALARM_CODE));
		c_alarm_flag = 'Y';

		COM_memcpy_add_null(c_plan_date, CMMSCALPLN.CMF_1, sizeof(CMMSCALPLN.CMF_1));

		COM_memcpy_add_null(s_equip_id, CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID));
		CDB_init_cmmseqpdef(&CMMSEQPDEF);
		memcpy(CMMSEQPDEF.FACTORY, CMMSCALPLN.FACTORY, sizeof(CMMSEQPDEF.FACTORY)); 
		memcpy(CMMSEQPDEF.EQUIP_ID, CMMSCALPLN.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
		CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			COM_memcpy_add_null(s_equip_name, CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));
		}
		sprintf(s_tmpstr + strlen(s_tmpstr), "<br>&nbsp;%s - [%s]%s", c_plan_date, s_equip_id, s_equip_name);
    }

	if (c_alarm_flag == 'Y')
	{
		memset(c_alarm_desc, 0x00, sizeof(c_alarm_desc));
		DBC_init_malmmsgdef(&MALMMSGDEF);
		memcpy(MALMMSGDEF.FACTORY, CMMSCALPLN.FACTORY, sizeof(MALMMSGDEF.FACTORY)); 
		memcpy(MALMMSGDEF.ALARM_ID, c_alarm_code, sizeof(MALMMSGDEF.ALARM_ID));
		DBC_select_malmmsgdef(1, &MALMMSGDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			COM_memcpy_add_null(c_alarm_desc, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
		}
		else
		{
			COM_memcpy_add_null(c_alarm_desc, "Instrument Calibration Plan Alarm", (int)strlen("Instrument Calibration Plan Alarm"));//size_t -> int 형변환 고려 2023-07-04
		}

		tran_in_node = TRS.create_node("alarm_in_node");
		CCOM_copy_in_node(in_node, tran_in_node);

		TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_factory(in_node));
		TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
		TRS.set_string(tran_in_node, "ALARM_ID", c_alarm_code, strlen(c_alarm_code)); 
		TRS.set_nstring(tran_in_node, "SOURCE_ID_1", "MMS");
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
	//--------------------------------------------------------------------------------------------------//

	c_alarm_flag = 'N';
	CDB_init_cmmsanapln(&CMMSANAPLN);
    TRS.copy(CMMSANAPLN.FACTORY, sizeof(CMMSANAPLN.FACTORY), in_node, IN_FACTORY);

    CDB_open_cmmsanapln(i_case, &CMMSANAPLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSANAPLN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSANAPLN.EQUIP_ID), CMMSANAPLN.EQUIP_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	memset(s_tmpstr, 0x00, sizeof(s_tmpstr));
	memset(c_alarm_code, 0x00, sizeof(c_alarm_code));
	memset(c_alarm_desc, 0x00, sizeof(c_alarm_desc));

    while(1)
    {
        CDB_fetch_cmmsanapln(i_case, &CMMSANAPLN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmscalpln(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSANAPLN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSANAPLN.FACTORY), CMMSANAPLN.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSANAPLN.EQUIP_ID), CMMSANAPLN.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmsanapln(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		memset(s_equip_id, 0x00, sizeof(s_equip_id));
		memset(s_equip_name, 0x00, sizeof(s_equip_name));
		memset(c_plan_date, 0x00, sizeof(c_plan_date));
		memset(c_analysis_method, 0x00, sizeof(c_analysis_method));
		if (COM_isnullspace(c_alarm_code) == MP_FALSE)
		{
			if (memcmp(c_alarm_code, CMMSANAPLN.ALARM_CODE, strlen(c_alarm_code)) != 0)
			{
				if (c_alarm_flag == 'Y')
				{
					memset(c_alarm_desc, 0x00, sizeof(c_alarm_desc));
					DBC_init_malmmsgdef(&MALMMSGDEF);
					memcpy(MALMMSGDEF.FACTORY, CMMSANAPLN.FACTORY, sizeof(MALMMSGDEF.FACTORY)); 
					memcpy(MALMMSGDEF.ALARM_ID, c_alarm_code, sizeof(MALMMSGDEF.ALARM_ID));
					DBC_select_malmmsgdef(1, &MALMMSGDEF);
					if(DB_error_code == DB_SUCCESS)
					{
						COM_memcpy_add_null(c_alarm_desc, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
					}
					else
					{
						COM_memcpy_add_null(c_alarm_desc, "Instrument Calibration Plan Alarm", (int)strlen("Instrument Measurement Plan Alarm"));//size_t -> int 형변환 고려 2023-07-04
					}

					tran_in_node = TRS.create_node("alarm_in_node");
					CCOM_copy_in_node(in_node, tran_in_node);

					TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_factory(in_node));
					TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
					TRS.set_string(tran_in_node, "ALARM_ID", c_alarm_code, strlen(c_alarm_code)); 
					TRS.set_nstring(tran_in_node, "SOURCE_ID_1", "MMS");
					TRS.set_string(tran_in_node, "ALARM_SUBJECT", c_alarm_desc, strlen(c_alarm_desc));
					TRS.set_nstring(tran_in_node, "ALARM_MSG", s_tmpstr);
	
					if(ALM_RAISE_ALARM(s_msg_code, tran_in_node, out_node) == MP_FALSE)
					{
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						TRS.free_node(tran_in_node);
						return MP_FALSE;
					}
					TRS.free_node(tran_in_node);
					memset(s_tmpstr, 0x00, sizeof(s_tmpstr));
				}
			}
		}

		COM_memcpy_add_null(c_alarm_code, CMMSANAPLN.ALARM_CODE, sizeof(CMMSANAPLN.ALARM_CODE));
		c_alarm_flag = 'Y';

		COM_memcpy_add_null(c_plan_date, CMMSANAPLN.CMF_1, sizeof(CMMSANAPLN.CMF_1));

		COM_memcpy_add_null(s_equip_id, CMMSANAPLN.EQUIP_ID, sizeof(CMMSANAPLN.EQUIP_ID));		
		CDB_init_cmmseqpdef(&CMMSEQPDEF);
		memcpy(CMMSEQPDEF.FACTORY, CMMSANAPLN.FACTORY, sizeof(CMMSEQPDEF.FACTORY)); 
		memcpy(CMMSEQPDEF.EQUIP_ID, CMMSANAPLN.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
		CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			COM_memcpy_add_null(s_equip_name, CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));
		}

		//GCM 조회(ANA_DIV_DESC)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ANA_MOTHOD, strlen(HQCEL_GCM_MMS_ANA_MOTHOD));
		MGCMTBLDAT.KEY_1[0] = CMMSANAPLN.ANA_DIV;
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			COM_memcpy_add_null(c_analysis_method, MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
		sprintf(s_tmpstr + strlen(s_tmpstr), "<br>&nbsp;%s:%s - [%s]%s", c_plan_date, c_analysis_method, s_equip_id, s_equip_name);
    }

	if (c_alarm_flag == 'Y')
	{
		memset(c_alarm_desc, 0x00, sizeof(c_alarm_desc));
		DBC_init_malmmsgdef(&MALMMSGDEF);
		memcpy(MALMMSGDEF.FACTORY, CMMSANAPLN.FACTORY, sizeof(MALMMSGDEF.FACTORY)); 
		memcpy(MALMMSGDEF.ALARM_ID, c_alarm_code, sizeof(MALMMSGDEF.ALARM_ID));
		DBC_select_malmmsgdef(1, &MALMMSGDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			COM_memcpy_add_null(c_alarm_desc, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
		}
		else
		{
			COM_memcpy_add_null(c_alarm_desc, "Instrument Calibration Plan Alarm", (int)strlen("Instrument Measurement Plan Alarm"));//size_t -> int 형변환 고려 2023-07-04
		}

		tran_in_node = TRS.create_node("alarm_in_node");
		CCOM_copy_in_node(in_node, tran_in_node);

		TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_factory(in_node));
		TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
		TRS.set_string(tran_in_node, "ALARM_ID", c_alarm_code, strlen(c_alarm_code)); 
		TRS.set_nstring(tran_in_node, "SOURCE_ID_1", "MMS");
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

	//=========================================================================================================================	
	//2023.07.03 Calibration Alarm GCM으로 추가.
	i_gcm_case = 5;
	CDB_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_CALIBRATION_ARM", strlen("MMS_CALIBRATION_ARM"));
	memcpy(MGCMTBLDAT.DATA_10, "Y", strlen("Y"));  // DATA_10이 "Y" 인 것만 
	CDB_open_mgcmtbldat(i_gcm_case, &MGCMTBLDAT);
	while(1)
    {
        CDB_fetch_mgcmtbldat(i_gcm_case, &MGCMTBLDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_mgcmtbldat(i_gcm_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "GCM-0004");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_mgcmtbldat(i_gcm_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		memset(c_alarm_code, 0x00, sizeof(c_alarm_code));
		COM_memcpy_add_null(c_alarm_code, MGCMTBLDAT.DATA_4, sizeof(c_alarm_code));

		//반복 여부 확인 DATA_3
		if(memcmp(MGCMTBLDAT.DATA_3, "Y", strlen("Y")) == 0)
		{
			i_case = 4;
		}
		else
		{
			i_case = 5;
		}

		CDB_init_cmmscalpln(&CMMSCALPLN);
		TRS.copy(CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY), in_node, IN_FACTORY);
		CMMSCALPLN.ALARM_PERIOD = COM_atoi(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
		CDB_open_cmmscalpln(i_case, &CMMSCALPLN);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSCALPLN OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	
		memset(s_tmpstr, 0x00, sizeof(s_tmpstr));		
		c_alarm_flag = 'N';
		while(1)
		{
			CDB_fetch_cmmscalpln(i_case, &CMMSCALPLN);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cmmscalpln(i_case);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSCALPLN FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				CDB_close_cmmscalpln(i_case);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			memset(s_equip_id, 0x00, sizeof(s_equip_id));
			memset(s_equip_name, 0x00, sizeof(s_equip_name));
			memset(c_plan_date, 0x00, sizeof(c_plan_date));
		

			COM_memcpy_add_null(c_plan_date, CMMSCALPLN.CMF_1, sizeof(CMMSCALPLN.CMF_1));
			COM_memcpy_add_null(s_equip_id, CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID));

			CDB_init_cmmseqpdef(&CMMSEQPDEF);
			memcpy(CMMSEQPDEF.FACTORY, CMMSCALPLN.FACTORY, sizeof(CMMSEQPDEF.FACTORY)); 
			memcpy(CMMSEQPDEF.EQUIP_ID, CMMSCALPLN.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
			CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
			if(DB_error_code == DB_SUCCESS)
			{
				COM_memcpy_add_null(s_equip_name, CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));
			}
			sprintf(s_tmpstr + strlen(s_tmpstr), "<br>&nbsp;%s - [%s]%s", c_plan_date, s_equip_id, s_equip_name);

			c_alarm_flag = 'Y';
		}

		if (c_alarm_flag == 'Y')
		{
			memset(c_alarm_desc, 0x00, sizeof(c_alarm_desc));
			DBC_init_malmmsgdef(&MALMMSGDEF);
			memcpy(MALMMSGDEF.FACTORY, CMMSCALPLN.FACTORY, sizeof(MALMMSGDEF.FACTORY)); 
			memcpy(MALMMSGDEF.ALARM_ID, c_alarm_code, sizeof(MALMMSGDEF.ALARM_ID));
			DBC_select_malmmsgdef(1, &MALMMSGDEF);
			if(DB_error_code == DB_SUCCESS)
			{
				COM_memcpy_add_null(c_alarm_desc, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
			}
			else
			{
				COM_memcpy_add_null(c_alarm_desc, "Instrument Calibration Plan Alarm", (int)strlen("Instrument Calibration Plan Alarm"));
			}

			tran_in_node = TRS.create_node("alarm_in_node");
			CCOM_copy_in_node(in_node, tran_in_node);

			TRS.set_nstring(tran_in_node, IN_FACTORY, TRS.get_factory(in_node));
			TRS.set_char(tran_in_node, IN_PROCSTEP, '1');
			TRS.set_string(tran_in_node, "ALARM_ID", c_alarm_code, strlen(c_alarm_code)); 
			TRS.set_nstring(tran_in_node, "SOURCE_ID_1", "MMS");
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
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

