/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_hour_gap_list.c
    Description : View Hour_Gap List function module1

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_Hour_Gap_List()
            + View Hour_Gap definition List
        - CRAS_VIEW_HOUR_GAP_LIST()
            + Main sub function of CRAS_View_Hour_Gap_List function
            + View Hour_Gap definition List
    Detail Description
        - CRAS_VIEW_HOUR_GAP_LIST()
            + h_proc_step
                + 1 : View Hour_Gap definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-02-03             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_Hour_Gap_List()
        - View Hour_Gap definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Hour_Gap_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_HOUR_GAP_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_HOUR_GAP_LIST", out_node);

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
    CRAS_VIEW_HOUR_GAP_LIST()
        - Main sub function of "CRAS_View_Hour_Gap_List" function
        - View Hour_Gap definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_HOUR_GAP_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASHURGAP_TAG CRASHURGAP;
	struct MWIPCALDEF_TAG MWIPCALDEF;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CRASMATRPT_TAG CRASMATRPT;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct RSUMHORMOV_TAG RSUMHORMOV; 

	int i;
	int target = 0;
	int fel = 0;
	int fqcQty = 0;
	int diff = 0;
	int icnt = 0;
	int DB_error_code_FQCQty = 0; 

	int cal_time_loss;
    double cal_diff;
    double cal_time_loss_target;
    double cal_time_loss_value;

	char ctime[2];
	char yyyy[4];
	char mm[2];
	char dd[2];
	char tmp_sys_date[14];
	char s_sys_time[14];
	char s_sys_next_time[14];
	char sys_time[10];
	char sys_time_cal[10];
	char int_chk;

    TRSNode *list_item;


	LOG_head("CRAS_VIEW_HOUR_GAP_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
	    
    CDB_init_crashurgap(&CRASHURGAP);
    TRS.copy(CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE), in_node, "HOUR_TYPE");
    TRS.copy(CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT), in_node, "WORK_SHIFT");
  
	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	strncpy(sys_time,s_sys_time,10);
	//get next day
	memset(s_sys_next_time, ' ', sizeof(s_sys_next_time));
	memset(tmp_sys_date, ' ', sizeof(tmp_sys_date));
	memcpy(s_sys_next_time, CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
	s_sys_next_time[8] = '0';
	s_sys_next_time[9] = '1';
	s_sys_next_time[10] = '0';
	s_sys_next_time[11] = '1';
	s_sys_next_time[12] = '0';
	s_sys_next_time[13] = '1';


	COM_add_time_sec(tmp_sys_date, s_sys_next_time,60*60*24);
	
			  

	icnt = (int) CDB_select_crashurgap_scalar(3,&CRASHURGAP);
	//저장이 안된 경우 달력을 조회한다.
	if(icnt == 0)
	{
		int_chk = 'I';
		
		DBC_init_mwipcaldef(&MWIPCALDEF);
		memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //해당 칼렌다로 변경필요.
		MWIPCALDEF.CALENDAR_TYPE = 'F';

		strncpy(yyyy,CRASHURGAP.WORK_DATE,4);
		strncpy(mm,CRASHURGAP.WORK_DATE+4,2);
		strncpy(dd,CRASHURGAP.WORK_DATE+6,2);
		MWIPCALDEF.SYS_YEAR = COM_atoi(yyyy,sizeof(yyyy));
		MWIPCALDEF.SYS_MONTH = COM_atoi(mm,sizeof(mm));
		MWIPCALDEF.SYS_DAY = COM_atoi(dd,sizeof(dd));
		DBC_select_mwipcaldef(1, &MWIPCALDEF);
		if (DB_error_code != DB_SUCCESS)
		{
		    strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "MWIPCALDEF OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		DBC_init_mgcmlagdat(&MGCMLAGDAT);
		TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMLAGDAT.TABLE_NAME, "@HOURLY_GAP_TARGETS", strlen("@HOURLY_GAP_TARGETS"));
		memcpy(MGCMLAGDAT.KEY_1, CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
		memcpy(MGCMLAGDAT.KEY_2, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));
		memcpy(MGCMLAGDAT.KEY_3, CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID));

		DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
		if(DB_error_code == DB_SUCCESS && COM_isnullspace(MGCMLAGDAT.DATA_1) == MP_FALSE)
		{
			target = COM_atoi(MGCMLAGDAT.DATA_1,sizeof(MGCMLAGDAT.DATA_1));				
		}

		CDB_init_rsumhormov(&RSUMHORMOV);
		TRS.copy(RSUMHORMOV.FACTORY, sizeof(RSUMHORMOV.FACTORY), in_node, IN_FACTORY);
		TRS.copy(RSUMHORMOV.WORK_DATE, sizeof(RSUMHORMOV.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(RSUMHORMOV.LINE_ID, sizeof(RSUMHORMOV.LINE_ID), in_node, "LINE_ID");
		memcpy(RSUMHORMOV.OPER, "M3110", sizeof("M3110"));
		TRS.copy(RSUMHORMOV.WORK_SHIFT, sizeof(RSUMHORMOV.WORK_SHIFT), in_node, "WORK_SHIFT");

		CDB_select_rsumhormov(6, &RSUMHORMOV);
		DB_error_code_FQCQty = DB_error_code; 

		if (memcmp(MWIPCALDEF.CAL_CMF_1, CRASHURGAP.WORK_SHIFT, strlen(CRASHURGAP.WORK_SHIFT)) == 0)
		{
				for(i=1;i<=12;i++)
				{	
					memset(ctime, 0x00, sizeof(ctime));
					if (i == 1) {
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME06_QTY:0; 
						memcpy(ctime,"06", sizeof(ctime));
					} else if (i == 2) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME07_QTY:0; 
						memcpy(ctime,"07", sizeof(ctime));
					} else if (i == 3){ 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME08_QTY:0; 
						memcpy(ctime,"08", sizeof(ctime));}
					else if (i == 4) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME09_QTY:0; 
						memcpy(ctime,"09", sizeof(ctime));
					} else if (i == 5){ 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME10_QTY:0; 
						memcpy(ctime,"10", sizeof(ctime));
					} else if (i == 6) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME11_QTY:0; 
						memcpy(ctime,"11", sizeof(ctime));
					} else if (i == 7) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME12_QTY:0; 
						memcpy(ctime,"12", sizeof(ctime));
					} else if (i == 8) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME13_QTY:0; 
						memcpy(ctime,"13", sizeof(ctime));
					} else if (i == 9) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME14_QTY:0; 
						memcpy(ctime,"14", sizeof(ctime));
					} else if (i == 10) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME15_QTY:0; 
						memcpy(ctime,"15", sizeof(ctime));
					} else if (i == 11)	{ 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME16_QTY:0; 
						memcpy(ctime,"16", sizeof(ctime));
					} else if (i == 12) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME17_QTY:0; 
						memcpy(ctime,"17", sizeof(ctime));
					}

					
					memset(sys_time_cal, ' ', sizeof(sys_time));
					memcpy(sys_time_cal, CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
					COM_add_null(sys_time_cal, sizeof(sys_time_cal));
					sys_time_cal[8] = ctime[0];
					sys_time_cal[9] = ctime[1];
				
					if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) >= COM_atoi(sys_time,sizeof(sys_time)))
					{
						//memset(sys_time_cal, ' ', sizeof(sys_time_cal));
						//continue;              
					}
					int_chk = 'C';
					
					list_item = TRS.add_node(out_node, "HOUR_GAP_LIST");
					TRS.add_string(list_item, "WORK_TIME", ctime, sizeof(ctime));
					TRS.add_string(list_item, "WORK_DATE", CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
					TRS.add_string(list_item, "LINE_ID", CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID));
					TRS.add_string(list_item, "HOUR_TYPE", CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));
					TRS.add_string(list_item, "WORK_SHIFT", CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT));
					TRS.add_int(list_item, "HIST_SEQ", 0);
					TRS.add_int(list_item, "TARGET_QTY", target);
					
					CDB_init_crasmatrpt(&CRASMATRPT);
					TRS.copy(CRASMATRPT.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
					TRS.copy(CRASMATRPT.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
					memcpy(CRASMATRPT.RPT_TYPE, "HOUR_GAP", strlen("HOUR_GAP"));
					memcpy(CRASMATRPT.RPT_ITEM, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));

					if (memcmp(CRASHURGAP.HOUR_TYPE, "FE", strlen("FE")) == 0)
					{
						memcpy(CRASMATRPT.RPT_ITEM, "FE", strlen("FE"));
					}
					else if (memcmp(CRASHURGAP.HOUR_TYPE, "BE", strlen("BE")) == 0)
					{
						memcpy(CRASMATRPT.RPT_ITEM, "BE", strlen("BE"));
					} 

					memcpy(CRASMATRPT.WORK_TIME, ctime, sizeof(ctime));
					TRS.copy(CRASMATRPT.WORK_SHIFT, sizeof(CRASMATRPT.WORK_SHIFT), in_node, "WORK_SHIFT");


					CDB_select_crasmatrpt(1, &CRASMATRPT);
					fel = 0 ;

					if (DB_error_code != DB_SUCCESS)
					{
						
					}
					else
					{
						fel = CRASMATRPT.QTY_1;
					}
					
					if (memcmp(CRASHURGAP.HOUR_TYPE, "FQ", strlen("FQ")) == 0)
					{
						fel = fqcQty;
					}

					TRS.add_int(list_item, "FEL_QTY", fel);
										
					diff = 0;
					diff = fel - target;
					cal_time_loss = 0;
					cal_time_loss_value = 0;
					cal_diff = 0;
					if(diff > 0)
					{
						cal_time_loss = 0;
					}
					else
					{
						if(abs(diff) > 0 && target > 0)
						{
							cal_diff = abs(diff);
							cal_time_loss_target = (double)target / 60;
							cal_time_loss_value = ceil(cal_diff / cal_time_loss_target);
							cal_time_loss = (int)cal_time_loss_value;
						}
						else
						{
							cal_time_loss= 0;
						}

					}

					TRS.add_int(list_item, "DIFF_QTY", diff);
					TRS.add_int(list_item, "TIME_LOSS", cal_time_loss);
					TRS.add_int(list_item, "DOWN_TIME", 0);
					TRS.add_int(list_item, "EFF_TIME", 0);
					TRS.add_string(list_item, "TYPE_4M", " ", strlen(" "));
					TRS.add_string(list_item, "PROCESS_TYPE", " ", strlen(" "));
					TRS.add_string(list_item, "EQ", " ", strlen(" "));
					TRS.add_string(list_item, "HOUR_DESC", " ", strlen(" "));
					TRS.add_int(list_item, "EQ_MAX", 0);

				}

				if(int_chk == 'I')
				{
					COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
					return MP_TRUE;
				}
				else
				{
					COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
					return MP_TRUE;
				}
		}

		else if (memcmp(MWIPCALDEF.CAL_CMF_2, CRASHURGAP.WORK_SHIFT, strlen(CRASHURGAP.WORK_SHIFT)) == 0)
		{
				for(i=1;i<=12;i++)
				{	
					memset(ctime, 0x00, sizeof(ctime));
					if (i == 1)
					{
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME18_QTY:0; 
						memcpy(ctime,"18", sizeof(ctime));
					}else if (i == 2)			{ 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME19_QTY:0; 
						memcpy(ctime,"19", sizeof(ctime));
					}else if (i == 3)			{ 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME20_QTY:0; 
						memcpy(ctime,"20", sizeof(ctime));
					}else if (i == 4) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME21_QTY:0; 
						memcpy(ctime,"21", sizeof(ctime));
					}else if (i == 5)			{ 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME22_QTY:0; 
						memcpy(ctime,"22", sizeof(ctime));
					}else if (i == 6) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME23_QTY:0; 
						memcpy(ctime,"23", sizeof(ctime));
					}else if (i == 7)			{
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME24_QTY:0; 
						memcpy(ctime,"24", sizeof(ctime));
					}else if (i == 8) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME01_QTY:0; 
						memcpy(ctime,"01", sizeof(ctime));
					}else if (i == 9)			{
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME02_QTY:0; 
						memcpy(ctime,"02", sizeof(ctime));
					}else if (i == 10)  { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME03_QTY:0; 
						memcpy(ctime,"03", sizeof(ctime));
					}else if (i == 11)			{ 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME04_QTY:0; 
						memcpy(ctime,"04", sizeof(ctime));
					}else if (i == 12) { 
						fqcQty = DB_error_code_FQCQty == 0 ? RSUMHORMOV.TIME05_QTY:0; 
						memcpy(ctime,"05", sizeof(ctime));
					}
					
                    if (memcmp(ctime, "01", strlen("01")) == 0 || memcmp(ctime, "02", strlen("02")) == 0 || memcmp(ctime, "03", strlen("03")) == 0
						|| memcmp(ctime, "04", strlen("04")) == 0 || memcmp(ctime, "05", strlen("05")) == 0 )
					{
						memset(sys_time_cal, ' ', sizeof(sys_time_cal));
						memcpy(sys_time_cal, tmp_sys_date, 8);
						COM_add_null(sys_time_cal, sizeof(sys_time_cal));
						sys_time_cal[8] = ctime[0];
						sys_time_cal[9] = ctime[1];
					}
					else if(memcmp(ctime, "24", strlen("24")) == 0)
					{	memset(sys_time_cal, ' ', sizeof(sys_time_cal));
						memcpy(sys_time_cal, tmp_sys_date, 8);
						COM_add_null(sys_time_cal, sizeof(sys_time_cal));
						sys_time_cal[8] = '0';
						sys_time_cal[9] = '0';
					}
					else
					{
						memset(sys_time_cal, ' ', sizeof(sys_time));
						memcpy(sys_time_cal, CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
						COM_add_null(sys_time_cal, sizeof(sys_time_cal));
						sys_time_cal[8] = ctime[0];
						sys_time_cal[9] = ctime[1];
					}


					
					
					if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) >= COM_atoi(sys_time,sizeof(sys_time)))
					{
						//memset(sys_time_cal, ' ', sizeof(sys_time_cal));
						//continue;              
					}
					int_chk = 'C';

					list_item = TRS.add_node(out_node, "HOUR_GAP_LIST");
					TRS.add_string(list_item, "WORK_TIME", ctime, sizeof(ctime));
					TRS.add_string(list_item, "WORK_DATE", CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
					TRS.add_string(list_item, "LINE_ID", CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID));
					TRS.add_string(list_item, "HOUR_TYPE", CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));
					TRS.add_string(list_item, "WORK_SHIFT", CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT));
					TRS.add_int(list_item, "HIST_SEQ", 0);
					TRS.add_int(list_item, "TARGET_QTY", target);
					
					CDB_init_crasmatrpt(&CRASMATRPT);
					TRS.copy(CRASMATRPT.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
					TRS.copy(CRASMATRPT.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
					memcpy(CRASMATRPT.RPT_TYPE, "HOUR_GAP", strlen("HOUR_GAP"));
					memcpy(CRASMATRPT.RPT_ITEM, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));

					if (memcmp(CRASHURGAP.HOUR_TYPE, "FE", strlen("FE")) == 0)
					{
						memcpy(CRASMATRPT.RPT_ITEM, "FE", strlen("FE"));
					}
					else if (memcmp(CRASHURGAP.HOUR_TYPE, "BE", strlen("BE")) == 0)
					{
						memcpy(CRASMATRPT.RPT_ITEM, "BE", strlen("BE"));
					} 

					if(memcmp(ctime, "24", strlen("24")) == 0)
					{
						memcpy(CRASMATRPT.WORK_TIME, "00", strlen("00"));
					}
					else
					{
						memcpy(CRASMATRPT.WORK_TIME, ctime, sizeof(ctime));
					}

					TRS.copy(CRASMATRPT.WORK_SHIFT, sizeof(CRASMATRPT.WORK_SHIFT), in_node, "WORK_SHIFT");

					CDB_select_crasmatrpt(1, &CRASMATRPT);
					fel = 0 ;

					if (DB_error_code != DB_SUCCESS)
					{
						
					}
					else
					{
						fel = CRASMATRPT.QTY_1;
					}
					if (memcmp(CRASHURGAP.HOUR_TYPE, "FQ", strlen("FQ")) == 0)
					{
						fel = fqcQty;
					} 

					TRS.add_int(list_item, "FEL_QTY", fel);

					diff = 0;
					diff = fel - target;
					cal_time_loss = 0;
					cal_time_loss_value = 0;
					cal_diff = 0;
					if(diff > 0)
					{
						cal_time_loss = 0;
					}
					else
					{
						if(abs(diff) > 0 && target > 0)
						{
							cal_diff = abs(diff);
							cal_time_loss_target = (double)target / 60;
							cal_time_loss_value = ceil(cal_diff / cal_time_loss_target);
							cal_time_loss = (int)cal_time_loss_value;
						}
						else
						{
							cal_time_loss= 0;
						}

					}



					TRS.add_int(list_item, "DIFF_QTY", diff);
					TRS.add_int(list_item, "TIME_LOSS", cal_time_loss);
					TRS.add_int(list_item, "DOWN_TIME", 0);
					TRS.add_int(list_item, "EFF_TIME", 0);
					TRS.add_string(list_item, "TYPE_4M", " ", strlen(" "));
					TRS.add_string(list_item, "PROCESS_TYPE", " ", strlen(" "));
					TRS.add_string(list_item, "EQ", " ", strlen(" "));
					TRS.add_string(list_item, "HOUR_DESC", " ", strlen(" "));
					TRS.add_int(list_item, "EQ_MAX", 0);


				}
				if(int_chk == 'I')
				{
					COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
					return MP_TRUE;
				}
				else
				{
					COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
					return MP_TRUE;
				}
		}
		else
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "MWIPCALDEF OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASHURGAP.WORK_SHIFT), CRASHURGAP.WORK_SHIFT);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}


	}

	CDB_open_crashurgap(2, &CRASHURGAP);
    if(DB_error_code != DB_SUCCESS)
    {	

        strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "CRASHURGAP OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASHURGAP.LINE_ID), CRASHURGAP.LINE_ID);
        TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASHURGAP.HOUR_TYPE), CRASHURGAP.HOUR_TYPE);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASHURGAP.WORK_SHIFT), CRASHURGAP.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASHURGAP.WORK_TIME), CRASHURGAP.WORK_TIME);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASHURGAP.HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_crashurgap(2, &CRASHURGAP);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_crashurgap(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "CRASHURGAP FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASHURGAP.LINE_ID), CRASHURGAP.LINE_ID);
            TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASHURGAP.HOUR_TYPE), CRASHURGAP.HOUR_TYPE);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASHURGAP.WORK_SHIFT), CRASHURGAP.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASHURGAP.WORK_TIME), CRASHURGAP.WORK_TIME);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASHURGAP.HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_crashurgap(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		
          
          

        list_item = TRS.add_node(out_node, "HOUR_GAP_LIST");
        
		TRS.add_string(list_item, "WORK_SHIFT", CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT));
		TRS.add_string(list_item, "WORK_TIME", CRASHURGAP.WORK_TIME, sizeof(CRASHURGAP.WORK_TIME));
		TRS.add_int(list_item, "HIST_SEQ", CRASHURGAP.HIST_SEQ);
        TRS.add_int(list_item, "TARGET_QTY", CRASHURGAP.TARGET_QTY);
		
		if(CRASHURGAP.FEL_QTY == 0)
		{
				CDB_init_crasmatrpt(&CRASMATRPT);
				memcpy(CRASMATRPT.WORK_DATE, CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
				memcpy(CRASMATRPT.LINE_ID, CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID));
				
				memcpy(CRASMATRPT.RPT_TYPE, "HOUR_GAP", strlen("HOUR_GAP"));
				memcpy(CRASMATRPT.RPT_ITEM, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));

				if(memcmp(CRASHURGAP.WORK_TIME, "24", strlen("24")) == 0)
				{
					memcpy(CRASMATRPT.WORK_TIME, "00", strlen("00"));
				}
				else
				{
					memcpy(CRASMATRPT.WORK_TIME, CRASHURGAP.WORK_TIME, sizeof(CRASHURGAP.WORK_TIME));
				}

				TRS.copy(CRASMATRPT.WORK_SHIFT, sizeof(CRASMATRPT.WORK_SHIFT), in_node, "WORK_SHIFT");

				

				fel = 0 ;
				if ( memcmp(CRASHURGAP.HOUR_TYPE, "FE", strlen("FE")) == 0 || 
					memcmp(CRASHURGAP.HOUR_TYPE, "BE", strlen("BE")) == 0 ) {

					if (memcmp(CRASHURGAP.HOUR_TYPE, "FE", strlen("FE")) == 0)
					{
						memcpy(CRASMATRPT.RPT_ITEM, "FE", strlen("FE"));
					}
					else if (memcmp(CRASHURGAP.HOUR_TYPE, "BE", strlen("BE")) == 0)
					{
						memcpy(CRASMATRPT.RPT_ITEM, "BE", strlen("BE"));
					}

					CDB_select_crasmatrpt(1, &CRASMATRPT);
					if (DB_error_code == DB_SUCCESS)
					{
						fel = CRASMATRPT.QTY_1;
					}
				} else if ( memcmp(CRASHURGAP.HOUR_TYPE, "FQ", strlen("FQ")) == 0)
				{
					fel =  get_rsumhormov_time_qty(&RSUMHORMOV, CRASHURGAP.WORK_TIME);
				}
				diff = 0; 
				target = 0 ;

				target = CRASHURGAP.TARGET_QTY;

				//fel = CRASMATRPT.QTY_1;
				diff = fel - target;
				cal_time_loss = 0;
				cal_time_loss_value = 0;
				cal_diff = 0;

				if(diff > 0)
				{
					cal_time_loss = 0;
				}
				else
				{
					if(abs(diff) > 0 && target > 0)
					{
						cal_diff = abs(diff);
						cal_time_loss_target = (double)target / 60;
						cal_time_loss_value = ceil(cal_diff / cal_time_loss_target);
						cal_time_loss = (int)cal_time_loss_value;
					}
					else
					{
						cal_time_loss= 0;
					}

				}


				TRS.add_int(list_item, "FEL_QTY", fel);
				TRS.add_int(list_item, "DIFF_QTY", diff);
				TRS.add_int(list_item, "TIME_LOSS", cal_time_loss);

		}
		else
		{
			TRS.add_int(list_item, "FEL_QTY", CRASHURGAP.FEL_QTY);
			TRS.add_int(list_item, "DIFF_QTY", CRASHURGAP.DIFF_QTY);
			TRS.add_int(list_item, "TIME_LOSS", CRASHURGAP.TIME_LOSS);
		}
		
		TRS.add_string(list_item, "TYPE_4M", CRASHURGAP.TYPE_4M, sizeof(CRASHURGAP.TYPE_4M));
		TRS.add_string(list_item, "PROCESS_TYPE", CRASHURGAP.PROCESS_TYPE, sizeof(CRASHURGAP.PROCESS_TYPE));
		TRS.add_string(list_item, "EQ", CRASHURGAP.EQ, sizeof(CRASHURGAP.EQ));
		TRS.add_int(list_item, "DOWN_TIME", CRASHURGAP.DOWN_TIME);
		TRS.add_int(list_item, "EFF_TIME", CRASHURGAP.EFF_TIME);
		TRS.add_string(list_item, "HOUR_DESC", CRASHURGAP.HOUR_DESC, sizeof(CRASHURGAP.HOUR_DESC));
		TRS.add_string(list_item, "WORK_DATE", CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
        TRS.add_string(list_item, "LINE_ID", CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID));
        TRS.add_string(list_item, "HOUR_TYPE", CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));
		TRS.add_string(list_item, "CMF_1", CRASHURGAP.CMF_1, sizeof(CRASHURGAP.CMF_1));
		TRS.add_string(list_item, "CMF_2", CRASHURGAP.CMF_2, sizeof(CRASHURGAP.CMF_2));
		TRS.add_string(list_item, "CMF_3", CRASHURGAP.CMF_3, sizeof(CRASHURGAP.CMF_3));
		TRS.add_string(list_item, "CMF_4", CRASHURGAP.CMF_4, sizeof(CRASHURGAP.CMF_4));
		TRS.add_int(list_item, "EQ_MAX", CRASHURGAP.EQ_MAX);

		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@4M_KIND", strlen("@4M_KIND"));
		memcpy(MGCMTBLDAT.KEY_1, CRASHURGAP.TYPE_4M, sizeof(CRASHURGAP.TYPE_4M));
		CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "TYPE_4M_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}
// 시간 번호(1~24)로 해당 TIMEnn_QTY 값을 가져오는 함수
int get_rsumhormov_time_qty(struct RSUMHORMOV_TAG *rec, char* strHour)
{
	int hour = atoi(strHour);
    // hour: 1~24
    // TIME01_QTY가 첫 번째, TIME24_QTY가 24번째
    int *base = &rec->TIME01_QTY;
    if (hour < 1 || hour > 24) return 0;
    return base[hour - 1];
}