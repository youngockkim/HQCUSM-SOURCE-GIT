/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_material_termination.c
    Description : Material_Termination Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Material_Termination()
            + Create/Update/Delete Material_Termination definition
        - CWIP_UPDATE_MATERIAL_TERMINATION()
            + Main sub function of CWIP_Update_Material_Termination function
            + Create/Update/Delete Material_Termination definition
        - CWIP_Update_Material_Termination_Validation()
            + Main sub function of CWIP_UPDATE_MATERIAL_TERMINATION function
            + Check the condition for create/update/delete Material_Termination
    Detail Description
        - CWIP_UPDATE_MATERIAL_TERMINATION()
            + h_proc_step
                + MP_STEP_CREATE : Create Material_Termination definition
                + MP_STEP_UPDATE : Update Material_Termination definition
                + MP_STEP_DELETE : Delete Material_Termination definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-09-18             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Material_Termination_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Material_Termination()
        - Create/Update/Delete Material_Termination definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Material_Termination(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_MATERIAL_TERMINATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_MATERIAL_TERMINATION", out_node);

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
    CWIP_UPDATE_MATERIAL_TERMINATION()
        - Main sub function of "CWIP_Update_Material_Termination" function
        - Create/Update/Delete Material_Termination definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_MATERIAL_TERMINATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPMATTER_TAG CWIPMATTER;
    struct CWIPMATTER_TAG CWIPMATTER_o;
    char   s_sys_time[14];

    LOG_head("CWIP_UPDATE_MATERIAL_TERMINATION");
    TRS.log_add_all_members(in_node);
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

    if(CWIP_Update_Material_Termination_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwipmatter(&CWIPMATTER);
    TRS.copy(CWIPMATTER.FACTORY, sizeof(CWIPMATTER.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPMATTER.ORDER_ID, sizeof(CWIPMATTER.ORDER_ID), in_node, "ORDER_ID");
    TRS.copy(CWIPMATTER.LINE_ID, sizeof(CWIPMATTER.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPMATTER.WORK_SHIFT, sizeof(CWIPMATTER.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPMATTER.MAT_ID, sizeof(CWIPMATTER.MAT_ID), in_node, "MAT_ID");
    CWIPMATTER.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
    CWIPMATTER.SEQ = TRS.get_int(in_node, "SEQ");
    TRS.copy(CWIPMATTER.TERMINATION_DT, sizeof(CWIPMATTER.TERMINATION_DT), in_node, "TERMINATION_DT");
    TRS.copy(CWIPMATTER.MATE_NO_DESC, sizeof(CWIPMATTER.MATE_NO_DESC), in_node, "MATE_NO_DESC");
    TRS.copy(CWIPMATTER.MATE_TYPE, sizeof(CWIPMATTER.MATE_TYPE), in_node, "MATE_TYPE");
    CWIPMATTER.QTY = TRS.get_int(in_node, "QTY");
    TRS.copy(CWIPMATTER.UNIT_ID, sizeof(CWIPMATTER.UNIT_ID), in_node, "UNIT_ID");
    TRS.copy(CWIPMATTER.REASON_CODE, sizeof(CWIPMATTER.REASON_CODE), in_node, "REASON_CODE");
    TRS.copy(CWIPMATTER.TER_COMMENT, sizeof(CWIPMATTER.TER_COMMENT), in_node, "TER_COMMENT");
    TRS.copy(CWIPMATTER.CMF_1, sizeof(CWIPMATTER.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPMATTER.CMF_2, sizeof(CWIPMATTER.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPMATTER.CMF_3, sizeof(CWIPMATTER.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPMATTER.CMF_4, sizeof(CWIPMATTER.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPMATTER.CMF_5, sizeof(CWIPMATTER.CMF_5), in_node, "CMF_5");
    TRS.copy(CWIPMATTER.CREATE_USER_ID, sizeof(CWIPMATTER.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPMATTER.CREATE_TIME, sizeof(CWIPMATTER.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPMATTER.UPDATE_USER_ID, sizeof(CWIPMATTER.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPMATTER.UPDATE_TIME, sizeof(CWIPMATTER.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        //----[Addtional Logic for Create Case]----

		//CWIPMATTER.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
		CWIPMATTER.HIST_SEQ = CDB_select_cwipmatter_scalar(2, &CWIPMATTER) + 1;

        TRS.copy(CWIPMATTER.CREATE_USER_ID, sizeof(CWIPMATTER.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPMATTER.CREATE_TIME, s_sys_time, sizeof(CWIPMATTER.CREATE_TIME));
        CDB_insert_cwipmatter(&CWIPMATTER);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPMATTER INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPMATTER.ORDER_ID), CWIPMATTER.ORDER_ID);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPMATTER.LINE_ID), CWIPMATTER.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPMATTER.WORK_SHIFT), CWIPMATTER.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPMATTER.MAT_ID), CWIPMATTER.MAT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPMATTER.HIST_SEQ);
            TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPMATTER.SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        CDB_init_cwipmatter(&CWIPMATTER_o);
        TRS.copy(CWIPMATTER_o.ORDER_ID, sizeof(CWIPMATTER_o.ORDER_ID), in_node, "ORDER_ID");
        TRS.copy(CWIPMATTER_o.LINE_ID, sizeof(CWIPMATTER_o.LINE_ID), in_node, "LINE_ID");
        TRS.copy(CWIPMATTER_o.WORK_SHIFT, sizeof(CWIPMATTER_o.WORK_SHIFT), in_node, "WORK_SHIFT");
        TRS.copy(CWIPMATTER_o.MAT_ID, sizeof(CWIPMATTER_o.MAT_ID), in_node, "MAT_ID");
        CWIPMATTER_o.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
        CWIPMATTER_o.SEQ = TRS.get_int(in_node, "SEQ");
        CDB_select_cwipmatter_for_update(1, &CWIPMATTER_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPMATTER SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPMATTER_o.ORDER_ID), CWIPMATTER_o.ORDER_ID);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPMATTER_o.LINE_ID), CWIPMATTER_o.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPMATTER_o.WORK_SHIFT), CWIPMATTER_o.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPMATTER_o.MAT_ID), CWIPMATTER_o.MAT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPMATTER_o.HIST_SEQ);
            TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPMATTER_o.SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		
        //----[Addtional Logic for Update Case]----
		if(strcmp("Y", TRS.get_string(in_node,"CANCEL_YN")) == 0)
		{
			memcpy(CWIPMATTER.CMF_1, "CANCEL", sizeof(CWIPMATTER.CMF_1));
		}
        memcpy(CWIPMATTER.CREATE_USER_ID, CWIPMATTER_o.CREATE_USER_ID, sizeof(CWIPMATTER.CREATE_USER_ID));
        memcpy(CWIPMATTER.CREATE_TIME, CWIPMATTER_o.CREATE_TIME, sizeof(CWIPMATTER.CREATE_TIME));
        TRS.copy(CWIPMATTER.UPDATE_USER_ID, sizeof(CWIPMATTER.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPMATTER.UPDATE_TIME, s_sys_time, sizeof(CWIPMATTER.UPDATE_TIME));

        CDB_update_cwipmatter(1, &CWIPMATTER);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPMATTER UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPMATTER.ORDER_ID), CWIPMATTER.ORDER_ID);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPMATTER.LINE_ID), CWIPMATTER.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPMATTER.WORK_SHIFT), CWIPMATTER.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPMATTER.MAT_ID), CWIPMATTER.MAT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPMATTER.HIST_SEQ);
            TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPMATTER.SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        CDB_delete_cwipmatter(1, &CWIPMATTER);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPMATTER DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPMATTER.ORDER_ID), CWIPMATTER.ORDER_ID);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPMATTER.LINE_ID), CWIPMATTER.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPMATTER.WORK_SHIFT), CWIPMATTER.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPMATTER.MAT_ID), CWIPMATTER.MAT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPMATTER.HIST_SEQ);
            TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPMATTER.SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
	
    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Material_Termination",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_Material_Termination_Validation()
        - Main sub function of "CWIP_UPDATE_MATERIAL_TERMINATION" function
        - Check the condition for create/update/delete Material_Termination
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Material_Termination_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPMATTER_TAG CWIPMATTER;
    struct MWIPFACDEF_TAG MWIPFACDEF;

	struct MWIPCALDEF_TAG MWIPCALDEF;

	int i_errorflag = 0;
	int i_timehour;

	char s_sys_time[14];
	char s_sys_time_next_day[14];

	char yyyy[4];
	char mm[2];
	char dd[2];

	char tmp_sys_date[14];
	char s_sys_next_time[14];
	char sys_time[10];
	char sys_time_cal[10];
	char sys_time_yyyymmdd[8];
	char tmp_worktime[2];

	char c_shift_1 = ' ';
	char c_shift_2 = ' ';
	char c_shift_current = ' ';

	char sys_time_shift_end[10];
	
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
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

	//--------------------------------------------

	TRS.copy(CWIPMATTER.WORK_SHIFT, sizeof(CWIPMATTER.WORK_SHIFT), in_node, "WORK_SHIFT");
	TRS.copy(CWIPMATTER.TERMINATION_DT, sizeof(CWIPMATTER.TERMINATION_DT), in_node, "TERMINATION_DT");

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

	strncpy(sys_time,s_sys_time,10);
	strncpy(sys_time_yyyymmdd,s_sys_time,8);
	
	//get next day
	memset(s_sys_next_time, ' ', sizeof(s_sys_next_time));
	memset(tmp_sys_date, ' ', sizeof(tmp_sys_date));
	
	TRS.copy(s_sys_next_time, sizeof(s_sys_next_time), in_node, "TERMINATION_DT");

	s_sys_next_time[8] = '0'; 
	s_sys_next_time[9] = '1';
	s_sys_next_time[10] = '0';
	s_sys_next_time[11] = '1';
	s_sys_next_time[12] = '0';
	s_sys_next_time[13] = '1';

	// Terminate Date combo box Day (next day)
	COM_add_time_sec(tmp_sys_date, s_sys_next_time,60*60*24);
	
	// MES DB Server Day (next day)
	COM_add_time_sec(s_sys_time_next_day, s_sys_time,60*60*24);
	
	strncpy(sys_time_shift_end,s_sys_time,10);
	
	tmp_worktime[0] = sys_time_shift_end[8];
	tmp_worktime[1] = sys_time_shift_end[9];
	i_timehour = COM_atoi(tmp_worktime, 2);

	//============================================
	// MES Calender ( YYYYMMSS )
	//============================================
	DBC_init_mwipcaldef(&MWIPCALDEF);
	memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //ÇØ´ç Ä®·»´Ù·Î º¯°æÇÊ¿ä.
	MWIPCALDEF.CALENDAR_TYPE = 'F';

	strncpy(yyyy,s_sys_next_time,4);
	strncpy(mm,s_sys_next_time+4,2);
	strncpy(dd,s_sys_next_time+6,2);
	MWIPCALDEF.SYS_YEAR = COM_atoi(yyyy,sizeof(yyyy));
	MWIPCALDEF.SYS_MONTH = COM_atoi(mm,sizeof(mm));
	MWIPCALDEF.SYS_DAY = COM_atoi(dd,sizeof(dd));
	DBC_select_mwipcaldef(1, &MWIPCALDEF);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "RAS-0004");
		TRS.add_fieldmsg(out_node, "MWIPCALDEF OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "TERMINATION_DT", MP_STR, sizeof(s_sys_next_time), s_sys_next_time);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	//============================================
	
	c_shift_1 = MWIPCALDEF.CAL_CMF_1[0];
	c_shift_2 = MWIPCALDEF.CAL_CMF_2[0];

	if(06 <= i_timehour && i_timehour < 18)
	{
		c_shift_current = c_shift_1;

		sys_time_shift_end[8] = '1';
		sys_time_shift_end[9] = '8';
	}
	else
	{
		c_shift_current = c_shift_2;

		strncpy(sys_time_shift_end,s_sys_time_next_day,10);
		sys_time_shift_end[8] = '0';
		sys_time_shift_end[9] = '6';
	}
	
	if ((TRS.get_procstep(in_node) == MP_STEP_CREATE)  | (TRS.get_procstep(in_node) == MP_STEP_UPDATE))
	{
		// old date (none check)
		if(COM_atoi(CWIPMATTER.TERMINATION_DT,sizeof(CWIPMATTER.TERMINATION_DT)) < COM_atoi(sys_time_yyyymmdd,sizeof(sys_time_yyyymmdd)))
		{
			
		}
		// today or future date
		else
		{
			// A C shift
			if(c_shift_1 == CWIPMATTER.WORK_SHIFT[0])
			{
				// YYYYMMDD18 - 2021092818
				strncpy(sys_time_cal,CWIPMATTER.TERMINATION_DT,8);
				sys_time_cal[8] = '1';
				sys_time_cal[9] = '8';
			}
			// B D shift
			else if(c_shift_2 == CWIPMATTER.WORK_SHIFT[0])
			{
				// YYYYMMDD(+1)06 - 2021092906
				strncpy(sys_time_cal,tmp_sys_date,8);
				sys_time_cal[8] = '0';
				sys_time_cal[9] = '6';
			}
			else
			{
				i_errorflag = 1;
			}

			if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) > COM_atoi(sys_time_shift_end,sizeof(sys_time_shift_end)) || 
				i_errorflag == 1)
			{
				strcpy(s_msg_code, "RAS-0326");
				TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				return MP_FALSE;          
			}
		}

		//Start Validation Time Check End
	}

	//--------------------------------------------

    return MP_TRUE;
}

