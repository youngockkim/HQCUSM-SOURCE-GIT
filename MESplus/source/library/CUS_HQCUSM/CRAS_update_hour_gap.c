/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_hour_gap.c
    Description : Hour_Gap Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_Hour_Gap()
            + Create/Update/Delete Hour_Gap definition
        - CRAS_UPDATE_HOUR_GAP()
            + Main sub function of CRAS_Update_Hour_Gap function
            + Create/Update/Delete Hour_Gap definition
        - CRAS_Update_Hour_Gap_Validation()
            + Main sub function of CRAS_UPDATE_HOUR_GAP function
            + Check the condition for create/update/delete Hour_Gap
    Detail Description
        - CRAS_UPDATE_HOUR_GAP()
            + h_proc_step
                + MP_STEP_CREATE : Create Hour_Gap definition
                + MP_STEP_UPDATE : Update Hour_Gap definition
                + MP_STEP_DELETE : Delete Hour_Gap definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-02-03             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_Hour_Gap_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_Hour_Gap()
        - Create/Update/Delete Hour_Gap definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Hour_Gap(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_UPDATE_HOUR_GAP(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_HOUR_GAP", out_node);

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
    CRAS_UPDATE_HOUR_GAP()
        - Main sub function of "CRAS_Update_Hour_Gap" function
        - Create/Update/Delete Hour_Gap definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_HOUR_GAP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{	

    struct CRASHURGAP_TAG CRASHURGAP;
    struct CRASHURGAP_TAG CRASHURGAP_o;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CRASMATRPT_TAG CRASMATRPT;
    char   s_sys_time[14];
	int ihisSeq = 0;
	int i_tran_count;
	int i;
	int target = 0;
	int fel = 0;
	int diff = 0;

	int cal_time_loss;
    double cal_diff;
    double cal_time_loss_target;
    double cal_time_loss_value;
	




	
	TRSNode ** Tran_List;

	LOG_head("CRAS_UPDATE_HOUR_GAP");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(CRAS_Update_Hour_Gap_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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


	

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");



    

	ihisSeq = 0 ;

    for(i = 0; i < i_tran_count; i++)
	{
	 
		if (TRS.get_procstep(in_node) == MP_STEP_CREATE )
        {
		
			CDB_init_crashurgap(&CRASHURGAP);
			TRS.copy(CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT), in_node, "WORK_SHIFT");
	
			TRS.copy(CRASHURGAP.WORK_TIME, sizeof(CRASHURGAP.WORK_TIME), Tran_List[i], "WORK_TIME");

			CDB_init_crashurgap(&CRASHURGAP_o);
			TRS.copy(CRASHURGAP_o.WORK_DATE, sizeof(CRASHURGAP_o.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASHURGAP_o.LINE_ID, sizeof(CRASHURGAP_o.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASHURGAP_o.HOUR_TYPE, sizeof(CRASHURGAP_o.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASHURGAP_o.WORK_SHIFT, sizeof(CRASHURGAP_o.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASHURGAP_o.WORK_TIME, sizeof(CRASHURGAP_o.WORK_TIME), Tran_List[i], "WORK_TIME");
			ihisSeq = 0 ;
			ihisSeq = (int) CDB_select_crashurgap_scalar(2,&CRASHURGAP_o);
			ihisSeq = ihisSeq + 1;
			CRASHURGAP.HIST_SEQ = ihisSeq;

			CRASHURGAP.TARGET_QTY = TRS.get_int(Tran_List[i], "TARGET_QTY");
			CRASHURGAP.FEL_QTY = TRS.get_int(Tran_List[i], "FEL_QTY");
			CRASHURGAP.DIFF_QTY = TRS.get_int(Tran_List[i], "DIFF_QTY");
			CRASHURGAP.TIME_LOSS = TRS.get_int(Tran_List[i], "TIME_LOSS");
			CRASHURGAP.DOWN_TIME = TRS.get_int(Tran_List[i], "DOWN_TIME");
			CRASHURGAP.EFF_TIME = TRS.get_int(Tran_List[i], "EFF_TIME");
			CRASHURGAP.TIME_LOSS = TRS.get_int(Tran_List[i], "TIME_LOSS");
			
			TRS.copy(CRASHURGAP.TYPE_4M, sizeof(CRASHURGAP.TYPE_4M), Tran_List[i], "TYPE_4M");
			TRS.copy(CRASHURGAP.EQ, sizeof(CRASHURGAP.EQ), Tran_List[i], "EQ");
			TRS.copy(CRASHURGAP.PROCESS_TYPE, sizeof(CRASHURGAP.PROCESS_TYPE), Tran_List[i], "PROCESS_TYPE");
			TRS.copy(CRASHURGAP.HOUR_DESC, sizeof(CRASHURGAP.HOUR_DESC), Tran_List[i], "HOUR_DESC");
			TRS.copy(CRASHURGAP.CMF_1, sizeof(CRASHURGAP.CMF_1), Tran_List[i], "CMF_1");
			TRS.copy(CRASHURGAP.CMF_2, sizeof(CRASHURGAP.CMF_2), Tran_List[i], "CMF_2");
			TRS.copy(CRASHURGAP.CMF_3, sizeof(CRASHURGAP.CMF_3), Tran_List[i], "CMF_3");
			TRS.copy(CRASHURGAP.CMF_4, sizeof(CRASHURGAP.CMF_4), Tran_List[i], "CMF_4");
            TRS.copy(CRASHURGAP.CREATE_USER_ID, sizeof(CRASHURGAP.CREATE_USER_ID), in_node, IN_USERID);
            memcpy(CRASHURGAP.TRAN_TIME, s_sys_time, sizeof(CRASHURGAP.TRAN_TIME));
			CDB_insert_crashurgap(&CRASHURGAP);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASHURGAP INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASHURGAP.LINE_ID), CRASHURGAP.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASHURGAP.HOUR_TYPE), CRASHURGAP.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASHURGAP.WORK_SHIFT), CRASHURGAP.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASHURGAP.WORK_TIME), CRASHURGAP.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASHURGAP.HIST_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}



		}
		else if (TRS.get_procstep(in_node) == MP_STEP_APPROVAL)
        {


			CDB_init_crashurgap(&CRASHURGAP);
			TRS.copy(CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT), in_node, "WORK_SHIFT");
	
			TRS.copy(CRASHURGAP.WORK_TIME, sizeof(CRASHURGAP.WORK_TIME), Tran_List[i], "WORK_TIME");

			CDB_init_crashurgap(&CRASHURGAP_o);
			TRS.copy(CRASHURGAP_o.WORK_DATE, sizeof(CRASHURGAP_o.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASHURGAP_o.LINE_ID, sizeof(CRASHURGAP_o.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASHURGAP_o.HOUR_TYPE, sizeof(CRASHURGAP_o.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASHURGAP_o.WORK_SHIFT, sizeof(CRASHURGAP_o.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASHURGAP_o.WORK_TIME, sizeof(CRASHURGAP_o.WORK_TIME), Tran_List[i], "WORK_TIME");
			ihisSeq = 0 ;
			ihisSeq = (int) CDB_select_crashurgap_scalar(2,&CRASHURGAP_o);
			ihisSeq = ihisSeq + 1;
			CRASHURGAP.HIST_SEQ = ihisSeq;

			DBC_init_mgcmlagdat(&MGCMLAGDAT);
			TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMLAGDAT.TABLE_NAME, "@HOURLY_GAP_TARGETS", strlen("@HOURLY_GAP_TARGETS"));
			memcpy(MGCMLAGDAT.KEY_1, CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
			memcpy(MGCMLAGDAT.KEY_2, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));
			memcpy(MGCMLAGDAT.KEY_3, CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID));

			DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
			target = 0;
			if(DB_error_code == DB_SUCCESS && COM_isnullspace(MGCMLAGDAT.DATA_1) == MP_FALSE)
			{
				target = COM_atoi(MGCMLAGDAT.DATA_1,sizeof(MGCMLAGDAT.DATA_1));		
			}

			CRASHURGAP.TARGET_QTY = target;
			CDB_init_crasmatrpt(&CRASMATRPT);
			TRS.copy(CRASMATRPT.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASMATRPT.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
			memcpy(CRASMATRPT.RPT_TYPE, "HOUR_GAP", strlen("HOUR_GAP"));
			memcpy(CRASMATRPT.RPT_ITEM, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));
				
			//if (memcmp(CRASHURGAP.HOUR_TYPE, "FE", strlen("FE")) == 0)
			//{
			//	memcpy(CRASMATRPT.RPT_ITEM, "FE", strlen("FE"));
			//}
			//else if (memcmp(CRASHURGAP.HOUR_TYPE, "BE", strlen("BE")) == 0)
			//{
			//	memcpy(CRASMATRPT.RPT_ITEM, "BE", strlen("BE"));
			//}
			
			if(memcmp(CRASHURGAP.WORK_TIME, "24", sizeof(CRASHURGAP.WORK_TIME)) == 0)
			{
				memcpy(CRASMATRPT.WORK_TIME, "00", strlen("00"));
			}
			else
			{
				TRS.copy(CRASMATRPT.WORK_TIME, sizeof(CRASMATRPT.WORK_TIME), Tran_List[i], "WORK_TIME");
			};

			

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
				fel = TRS.get_int(Tran_List[i], "FEL_QTY");
			}

			CRASHURGAP.FEL_QTY = fel;
			diff = 0;
			diff = fel - target;
			CRASHURGAP.DIFF_QTY = diff;

			cal_time_loss = 0;
			cal_time_loss_target = 0;
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

			CRASHURGAP.TIME_LOSS = cal_time_loss;
			CRASHURGAP.DOWN_TIME = TRS.get_int(Tran_List[i], "DOWN_TIME");
			CRASHURGAP.EFF_TIME = TRS.get_int(Tran_List[i], "EFF_TIME");
			CRASHURGAP.EQ_MAX = TRS.get_int(Tran_List[i], "EQ_MAX");
			TRS.copy(CRASHURGAP.TYPE_4M, sizeof(CRASHURGAP.TYPE_4M), Tran_List[i], "TYPE_4M");
			TRS.copy(CRASHURGAP.CMF_1, sizeof(CRASHURGAP.CMF_1), Tran_List[i], "CMF_1");
			TRS.copy(CRASHURGAP.CMF_2, sizeof(CRASHURGAP.CMF_2), Tran_List[i], "CMF_2");
			TRS.copy(CRASHURGAP.CMF_3, sizeof(CRASHURGAP.CMF_3), Tran_List[i], "CMF_3");
			TRS.copy(CRASHURGAP.CMF_4, sizeof(CRASHURGAP.CMF_4), Tran_List[i], "CMF_4");
			TRS.copy(CRASHURGAP.EQ, sizeof(CRASHURGAP.EQ), Tran_List[i], "EQ");
			TRS.copy(CRASHURGAP.PROCESS_TYPE, sizeof(CRASHURGAP.PROCESS_TYPE), Tran_List[i], "PROCESS_TYPE");
			TRS.copy(CRASHURGAP.HOUR_DESC, sizeof(CRASHURGAP.HOUR_DESC), Tran_List[i], "HOUR_DESC");
            TRS.copy(CRASHURGAP.CREATE_USER_ID, sizeof(CRASHURGAP.CREATE_USER_ID), in_node, IN_USERID);
            memcpy(CRASHURGAP.TRAN_TIME, s_sys_time, sizeof(CRASHURGAP.TRAN_TIME));
			CDB_insert_crashurgap(&CRASHURGAP);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASHURGAP INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASHURGAP.LINE_ID), CRASHURGAP.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASHURGAP.HOUR_TYPE), CRASHURGAP.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASHURGAP.WORK_SHIFT), CRASHURGAP.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASHURGAP.WORK_TIME), CRASHURGAP.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASHURGAP.HIST_SEQ);
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

			CDB_init_crashurgap(&CRASHURGAP);
			TRS.copy(CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASHURGAP.WORK_TIME, sizeof(CRASHURGAP.WORK_TIME), Tran_List[i], "WORK_TIME");
			
			CRASHURGAP.HIST_SEQ = TRS.get_int(Tran_List[i], "HIST_SEQ");
			//CRASHURGAP.TARGET_QTY = TRS.get_int(Tran_List[i], "TARGET_QTY");
			CRASHURGAP.DOWN_TIME = TRS.get_int(Tran_List[i], "DOWN_TIME");
			CRASHURGAP.EFF_TIME = TRS.get_int(Tran_List[i], "EFF_TIME");
			CRASHURGAP.EQ_MAX = TRS.get_int(Tran_List[i], "EQ_MAX");			
			
			TRS.copy(CRASHURGAP.TYPE_4M, sizeof(CRASHURGAP.TYPE_4M), Tran_List[i], "TYPE_4M");
			TRS.copy(CRASHURGAP.CMF_1, sizeof(CRASHURGAP.CMF_1), Tran_List[i], "CMF_1");
			TRS.copy(CRASHURGAP.CMF_2, sizeof(CRASHURGAP.CMF_2), Tran_List[i], "CMF_2");
			TRS.copy(CRASHURGAP.CMF_3, sizeof(CRASHURGAP.CMF_3), Tran_List[i], "CMF_3");
			TRS.copy(CRASHURGAP.CMF_4, sizeof(CRASHURGAP.CMF_4), Tran_List[i], "CMF_4");
			TRS.copy(CRASHURGAP.EQ, sizeof(CRASHURGAP.EQ), Tran_List[i], "EQ");
			TRS.copy(CRASHURGAP.PROCESS_TYPE, sizeof(CRASHURGAP.PROCESS_TYPE), Tran_List[i], "PROCESS_TYPE");
			TRS.copy(CRASHURGAP.HOUR_DESC, sizeof(CRASHURGAP.HOUR_DESC), Tran_List[i], "HOUR_DESC");
            TRS.copy(CRASHURGAP.CREATE_USER_ID, sizeof(CRASHURGAP.CREATE_USER_ID), in_node, IN_USERID);
            memcpy(CRASHURGAP.TRAN_TIME, s_sys_time, sizeof(CRASHURGAP.TRAN_TIME));

			//get Target

			DBC_init_mgcmlagdat(&MGCMLAGDAT);
			TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
			memcpy(MGCMLAGDAT.TABLE_NAME, "@HOURLY_GAP_TARGETS", strlen("@HOURLY_GAP_TARGETS"));
			memcpy(MGCMLAGDAT.KEY_1, CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE));
			memcpy(MGCMLAGDAT.KEY_2, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));
			memcpy(MGCMLAGDAT.KEY_3, CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID));

			DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
			target = 0;
			if(DB_error_code == DB_SUCCESS && COM_isnullspace(MGCMLAGDAT.DATA_1) == MP_FALSE)
			{
				target = COM_atoi(MGCMLAGDAT.DATA_1,sizeof(MGCMLAGDAT.DATA_1));		
			}

			CRASHURGAP.TARGET_QTY = target;

			//get END

			//get FEL,DIFF,LOSS START
			CDB_init_crasmatrpt(&CRASMATRPT);
			TRS.copy(CRASMATRPT.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASMATRPT.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
			memcpy(CRASMATRPT.RPT_TYPE, "HOUR_GAP", strlen("HOUR_GAP"));
			memcpy(CRASMATRPT.RPT_ITEM, CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE));

			//if (memcmp(CRASHURGAP.HOUR_TYPE, "FE", strlen("FE")) == 0)
			//{
			//	memcpy(CRASMATRPT.RPT_ITEM, "FE", strlen("FE"));
			//}
			//else if (memcmp(CRASHURGAP.HOUR_TYPE, "BE", strlen("BE")) == 0)
			//{
			//	memcpy(CRASMATRPT.RPT_ITEM, "BE", strlen("BE"));
			//}
			
			if(memcmp(CRASHURGAP.WORK_TIME, "24", sizeof(CRASHURGAP.WORK_TIME)) == 0)
			{
				memcpy(CRASMATRPT.WORK_TIME, "00", strlen("00"));
			}
			else
			{
				TRS.copy(CRASMATRPT.WORK_TIME, sizeof(CRASMATRPT.WORK_TIME), Tran_List[i], "WORK_TIME");
			};
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
				fel = TRS.get_int(Tran_List[i], "FEL_QTY");
			}

			CRASHURGAP.FEL_QTY = fel;
			diff = 0;
			diff = fel - target;
			CRASHURGAP.DIFF_QTY = diff;

			cal_time_loss = 0;
			cal_time_loss_target = 0;
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

			CRASHURGAP.TIME_LOSS = cal_time_loss;
			
			//get END

		

			CDB_update_crashurgap(3, &CRASHURGAP);

			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASHURGAP UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASHURGAP.LINE_ID), CRASHURGAP.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASHURGAP.HOUR_TYPE), CRASHURGAP.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASHURGAP.WORK_SHIFT), CRASHURGAP.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASHURGAP.WORK_TIME), CRASHURGAP.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASHURGAP.HIST_SEQ);
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
			CDB_init_crashurgap(&CRASHURGAP);
			TRS.copy(CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE), in_node, "HOUR_TYPE");
			TRS.copy(CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT), in_node, "WORK_SHIFT");
			TRS.copy(CRASHURGAP.WORK_TIME, sizeof(CRASHURGAP.WORK_TIME), Tran_List[i], "WORK_TIME");
	
			CRASHURGAP.HIST_SEQ = TRS.get_int(Tran_List[i], "HIST_SEQ");
			if(CRASHURGAP.HIST_SEQ == 1)
			{
				CRASHURGAP.HIST_SEQ = TRS.get_int(Tran_List[i], "HIST_SEQ");
				CRASHURGAP.DOWN_TIME = TRS.get_int(Tran_List[i], "DOWN_TIME");
				CRASHURGAP.EFF_TIME = TRS.get_int(Tran_List[i], "EFF_TIME");
				CRASHURGAP.EQ_MAX = TRS.get_int(Tran_List[i], "EQ_MAX");
				
				TRS.copy(CRASHURGAP.TYPE_4M, sizeof(CRASHURGAP.TYPE_4M), Tran_List[i], "TYPE_4M");
				TRS.copy(CRASHURGAP.EQ, sizeof(CRASHURGAP.EQ), Tran_List[i], "EQ");
				TRS.copy(CRASHURGAP.PROCESS_TYPE, sizeof(CRASHURGAP.PROCESS_TYPE), Tran_List[i], "PROCESS_TYPE");
				TRS.copy(CRASHURGAP.HOUR_DESC, sizeof(CRASHURGAP.HOUR_DESC), Tran_List[i], "HOUR_DESC");
				TRS.copy(CRASHURGAP.CREATE_USER_ID, sizeof(CRASHURGAP.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CRASHURGAP.TRAN_TIME, s_sys_time, sizeof(CRASHURGAP.TRAN_TIME));
				CDB_update_crashurgap(2, &CRASHURGAP);
			}
			else
			{
				CDB_delete_crashurgap(1, &CRASHURGAP);
			}
			if(DB_error_code != DB_SUCCESS)
			{
			
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASHURGAP DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASHURGAP.WORK_DATE), CRASHURGAP.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASHURGAP.LINE_ID), CRASHURGAP.LINE_ID);
				TRS.add_fieldmsg(out_node, "HOUR_TYPE", MP_STR, sizeof(CRASHURGAP.HOUR_TYPE), CRASHURGAP.HOUR_TYPE);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASHURGAP.WORK_SHIFT), CRASHURGAP.WORK_SHIFT);
				TRS.add_fieldmsg(out_node, "WORK_TIME", MP_STR, sizeof(CRASHURGAP.WORK_TIME), CRASHURGAP.WORK_TIME);
				TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CRASHURGAP.HIST_SEQ);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}



	}



    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CRAS_Update_Hour_Gap_Validation()
        - Main sub function of "CRAS_UPDATE_HOUR_GAP" function
        - Check the condition for create/update/delete Hour_Gap
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Hour_Gap_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{

	//struct CRASMATRPT_TAG CRASMATRPT;
	struct CRASHURGAP_TAG CRASHURGAP;


	int i;
	int i_tran_count;
	int chk_count = 0;

	char s_sys_time[14];
	char tmp_sys_date[14];
	char s_sys_next_time[14];
	char sys_time[10];
	char sys_time_cal[10];
	char tmp_yyyymmdd[8];
	char tmp_worktime[2];
	
	TRSNode ** Tran_List;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUDA") == MP_FALSE)
    {
        return MP_FALSE;
    }

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

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
	//get next day
	memset(s_sys_next_time, ' ', sizeof(s_sys_next_time));
	memset(tmp_sys_date, ' ', sizeof(tmp_sys_date));
	
	if(i_tran_count > 0)
	{
		TRS.copy(s_sys_next_time, sizeof(s_sys_next_time), in_node, "WORK_DATE");
	}
	s_sys_next_time[8] = '0';
	s_sys_next_time[9] = '1';
	s_sys_next_time[10] = '0';
	s_sys_next_time[11] = '1';
	s_sys_next_time[12] = '0';
	s_sys_next_time[13] = '1';

	COM_add_time_sec(tmp_sys_date, s_sys_next_time,60*60*24);

	for(i = 0; i < i_tran_count; i++)
	{		

			if ((TRS.get_procstep(in_node) == MP_STEP_APPROVAL)  | (TRS.get_procstep(in_node) == MP_STEP_UPDATE))
			{
				
				memset(tmp_yyyymmdd, ' ', sizeof(tmp_yyyymmdd));
				memset(tmp_worktime, ' ', sizeof(tmp_worktime));
			
				TRS.copy(tmp_yyyymmdd, sizeof(tmp_yyyymmdd), in_node, "WORK_DATE");
				TRS.copy(tmp_worktime, sizeof(tmp_worktime), Tran_List[i], "WORK_TIME");
				

				if(TRS.get_procstep(in_node) == MP_STEP_APPROVAL)
				{
					//Start Validation data check if not update first data.
					chk_count = 0;
				
					CDB_init_crashurgap(&CRASHURGAP);
					TRS.copy(CRASHURGAP.WORK_DATE, sizeof(CRASHURGAP.WORK_DATE), in_node, "WORK_DATE");
					TRS.copy(CRASHURGAP.LINE_ID, sizeof(CRASHURGAP.LINE_ID), in_node, "LINE_ID");
					TRS.copy(CRASHURGAP.HOUR_TYPE, sizeof(CRASHURGAP.HOUR_TYPE), in_node, "HOUR_TYPE");
					TRS.copy(CRASHURGAP.WORK_SHIFT, sizeof(CRASHURGAP.WORK_SHIFT), in_node, "WORK_SHIFT");
					TRS.copy(CRASHURGAP.WORK_TIME, sizeof(CRASHURGAP.WORK_TIME), Tran_List[i], "WORK_TIME");

					chk_count = (int) CDB_select_crashurgap_scalar(4,&CRASHURGAP);
					if(chk_count > 0)
					{
						strcpy(s_msg_code, "RAS-0328");
						TRS.add_fieldmsg(out_node, "UPDATE FEL QTY", MP_NVST);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_VALIDATION;
						gs_log_type.category = MP_LOG_CATE_SETUP;
						return MP_FALSE; 
					}
				}

				////Start Validation FEL QTY
				//CDB_init_crasmatrpt(&CRASMATRPT);
				//TRS.copy(CRASMATRPT.WORK_DATE, sizeof(CRASMATRPT.WORK_DATE), in_node, "WORK_DATE");
				//TRS.copy(CRASMATRPT.LINE_ID, sizeof(CRASMATRPT.LINE_ID), in_node, "LINE_ID");
				//memcpy(CRASMATRPT.RPT_TYPE, "HOUR_GAP", strlen("HOUR_GAP"));
				//TRS.copy(CRASMATRPT.RPT_ITEM, sizeof(CRASMATRPT.RPT_ITEM), in_node, "HOUR_TYPE");
				//
			
				//if(memcmp(tmp_worktime, "24", sizeof(tmp_worktime)) == 0)
				//{
				//	memcpy(CRASMATRPT.WORK_TIME, "00", strlen("00"));
				//}
				//else
				//{
				//	memcpy(CRASMATRPT.WORK_TIME, tmp_worktime, sizeof(tmp_worktime));
				//};

				//TRS.copy(CRASMATRPT.WORK_SHIFT, sizeof(CRASMATRPT.WORK_SHIFT), in_node, "WORK_SHIFT");
			
				//CDB_select_crasmatrpt(1, &CRASMATRPT);
	
				//if ((DB_error_code != DB_SUCCESS) | (CRASMATRPT.QTY_1 == 0))
				//{
				//	strcpy(s_msg_code, "RAS-0327");
				//	TRS.add_fieldmsg(out_node, "UPDATE FEL QTY", MP_NVST);
				//	TRS.add_dberrmsg(out_node, DB_error_msg);

				//	gs_log_type.type = MP_LOG_ERROR;
				//	gs_log_type.e_type = MP_LOG_E_VALIDATION;
				//	gs_log_type.category = MP_LOG_CATE_SETUP;
				//	return MP_FALSE;      		
				//}
			
				//Start Validation Time Check Start

				if (memcmp(tmp_worktime, "01", strlen("01")) == 0 || memcmp(tmp_worktime, "02", strlen("02")) == 0 || memcmp(tmp_worktime, "03", strlen("03")) == 0
						|| memcmp(tmp_worktime, "04", strlen("04")) == 0 || memcmp(tmp_worktime, "05", strlen("05")) == 0 )
				{
						memset(sys_time_cal, ' ', sizeof(sys_time_cal));
						memcpy(sys_time_cal, tmp_sys_date, 8);
						COM_add_null(sys_time_cal, sizeof(sys_time_cal));
						sys_time_cal[8] = tmp_worktime[0];
						sys_time_cal[9] = tmp_worktime[1];
				}
				else if(memcmp(tmp_worktime, "24", strlen("24")) == 0)
				{		memset(sys_time_cal, ' ', sizeof(sys_time_cal));
						memcpy(sys_time_cal, tmp_sys_date, 8);
						COM_add_null(sys_time_cal, sizeof(sys_time_cal));
						sys_time_cal[8] = '0';
						sys_time_cal[9] = '0';
				}
				else
				{
					memset(sys_time_cal, ' ', sizeof(sys_time));
					memcpy(sys_time_cal, tmp_yyyymmdd, sizeof(tmp_yyyymmdd));
					COM_add_null(sys_time_cal, sizeof(sys_time_cal));
			
					sys_time_cal[8] = tmp_worktime[0];
					sys_time_cal[9] = tmp_worktime[1];
				}

				if(COM_atoi(sys_time_cal,sizeof(sys_time_cal)) >= COM_atoi(sys_time,sizeof(sys_time)))
				{
					strcpy(s_msg_code, "RAS-0326");
					TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					return MP_FALSE;          
				}

				//Start Validation Time Check End
			}


	}

  

  
    return MP_TRUE;
}

