/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_repacking_log.c
    Description : Repacking_Log Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Repacking_Log()
            + Create/Update/Delete Repacking_Log definition
        - CWIP_UPDATE_REPACKING_LOG()
            + Main sub function of CWIP_Update_Repacking_Log function
            + Create/Update/Delete Repacking_Log definition
        - CWIP_Update_Repacking_Log_Validation()
            + Main sub function of CWIP_UPDATE_REPACKING_LOG function
            + Check the condition for create/update/delete Repacking_Log
    Detail Description
        - CWIP_UPDATE_REPACKING_LOG()
            + h_proc_step
                + MP_STEP_CREATE : Create Repacking_Log definition
                + MP_STEP_UPDATE : Update Repacking_Log definition
                + MP_STEP_DELETE : Delete Repacking_Log definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/08/01             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "CUS_common.h"

int CWIP_Update_Repacking_Log_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Repacking_Log()
        - Create/Update/Delete Repacking_Log definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Repacking_Log(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_REPACKING_LOG(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_REPACKING_LOG", out_node);

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
    CWIP_UPDATE_REPACKING_LOG()
        - Main sub function of "CWIP_Update_Repacking_Log" function
        - Create/Update/Delete Repacking_Log definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_REPACKING_LOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPRPKHIS_TAG CWIPRPKHIS;
    struct CWIPRPKHIS_TAG CWIPRPKHIS_o;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
    char   s_sys_time[14];
    int i_tran_count;
    int i;
    //int i_step;

    TRSNode ** Tran_List;

    LOG_head("CWIP_UPDATE_REPACKING_LOG");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("factory_no", MP_NSTR, TRS.get_string(in_node, "FACTORY_NO"));
    LOG_add("pallet_id", MP_NSTR, TRS.get_string(in_node, "PALLET_ID"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("cause_id", MP_NSTR, TRS.get_string(in_node, "CAUSE_ID"));
    LOG_add("pack_time", MP_NSTR, TRS.get_string(in_node, "PACK_TIME"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Repacking_Log",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

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

    if(CWIP_Update_Repacking_Log_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
    CDB_init_cwiplotpak(&CWIPLOTPAK);
    TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID"); 
	CDB_select_cwiplotpak(8, &CWIPLOTPAK);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0658");
        TRS.add_fieldmsg(out_node, "PALLET_ID", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	Tran_List = TRS.get_list(in_node, "DATA_LIST");
    i_tran_count = TRS.get_item_count(in_node, "DATA_LIST");

    for(i = 0; i < i_tran_count; i++)
    {
		CDB_init_cwiprpkhis(&CWIPRPKHIS);
		TRS.copy(CWIPRPKHIS.FACTORY, sizeof(CWIPRPKHIS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPRPKHIS.FACTORY_NO, sizeof(CWIPRPKHIS.FACTORY_NO), in_node, "FACTORY_NO");
		TRS.copy(CWIPRPKHIS.PALLET_ID, sizeof(CWIPRPKHIS.PALLET_ID), in_node, "PALLET_ID");
		TRS.copy(CWIPRPKHIS.MAT_ID, sizeof(CWIPRPKHIS.MAT_ID), Tran_List[i], "MAT_ID");
		TRS.copy(CWIPRPKHIS.CAUSE_ID, sizeof(CWIPRPKHIS.CAUSE_ID), Tran_List[i], "CAUSE_ID");
		memcpy(CWIPRPKHIS.PACK_TIME, CWIPLOTPAK.PAK_TIME, sizeof(CWIPRPKHIS.PACK_TIME));

		TRS.copy(CWIPRPKHIS.CMF_1, sizeof(CWIPRPKHIS.CMF_1), Tran_List[i], "CMF_1");
		TRS.copy(CWIPRPKHIS.CMF_2, sizeof(CWIPRPKHIS.CMF_2), Tran_List[i], "CMF_2");
		TRS.copy(CWIPRPKHIS.CMF_3, sizeof(CWIPRPKHIS.CMF_3), Tran_List[i], "CMF_3");
		TRS.copy(CWIPRPKHIS.CMF_4, sizeof(CWIPRPKHIS.CMF_4), Tran_List[i], "CMF_4");
		TRS.copy(CWIPRPKHIS.CMF_5, sizeof(CWIPRPKHIS.CMF_5), Tran_List[i], "CMF_5");
		TRS.copy(CWIPRPKHIS.CMF_6, sizeof(CWIPRPKHIS.CMF_6), Tran_List[i], "CMF_6");
		TRS.copy(CWIPRPKHIS.CMF_7, sizeof(CWIPRPKHIS.CMF_7), Tran_List[i], "CMF_7");
		TRS.copy(CWIPRPKHIS.CMF_8, sizeof(CWIPRPKHIS.CMF_8), Tran_List[i], "CMF_8");
		TRS.copy(CWIPRPKHIS.CMF_9, sizeof(CWIPRPKHIS.CMF_9), Tran_List[i], "CMF_9");
		TRS.copy(CWIPRPKHIS.CMF_10, sizeof(CWIPRPKHIS.CMF_10), Tran_List[i], "CMF_10");

		if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
			//----[Addtional Logic for Create Case]----

			TRS.copy(CWIPRPKHIS.CREATE_USER_ID, sizeof(CWIPRPKHIS.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CWIPRPKHIS.CREATE_TIME, s_sys_time, sizeof(CWIPRPKHIS.CREATE_TIME));
			CDB_insert_cwiprpkhis(&CWIPRPKHIS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CWIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPRPKHIS INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRPKHIS.FACTORY), CWIPRPKHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "FACTORY_NO", MP_STR, sizeof(CWIPRPKHIS.FACTORY_NO), CWIPRPKHIS.FACTORY_NO);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPRPKHIS.PALLET_ID), CWIPRPKHIS.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPRPKHIS.MAT_ID), CWIPRPKHIS.MAT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}           

        }
        else if (TRS.get_procstep(in_node) == MP_STEP_UPDATE)
        {
			CDB_init_cwiprpkhis(&CWIPRPKHIS_o);
			TRS.copy(CWIPRPKHIS_o.FACTORY, sizeof(CWIPRPKHIS_o.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPRPKHIS_o.FACTORY_NO, sizeof(CWIPRPKHIS_o.FACTORY_NO), in_node, "FACTORY_NO");
			TRS.copy(CWIPRPKHIS_o.PALLET_ID, sizeof(CWIPRPKHIS_o.PALLET_ID), in_node, "PALLET_ID");
			TRS.copy(CWIPRPKHIS_o.MAT_ID, sizeof(CWIPRPKHIS_o.MAT_ID), Tran_List[i], "MAT_ID");
			CDB_select_cwiprpkhis_for_update(1, &CWIPRPKHIS_o);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CWIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPRPKHIS SELECT FOR UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRPKHIS_o.FACTORY), CWIPRPKHIS_o.FACTORY);
				TRS.add_fieldmsg(out_node, "FACTORY_NO", MP_STR, sizeof(CWIPRPKHIS.FACTORY_NO), CWIPRPKHIS.FACTORY_NO);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPRPKHIS_o.PALLET_ID), CWIPRPKHIS_o.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPRPKHIS_o.MAT_ID), CWIPRPKHIS_o.MAT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//----[Addtional Logic for Update Case]----

			TRS.copy(CWIPRPKHIS.UPDATE_USER_ID, sizeof(CWIPRPKHIS.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CWIPRPKHIS.UPDATE_TIME, s_sys_time, sizeof(CWIPRPKHIS.UPDATE_TIME));

			CDB_update_cwiprpkhis(1, &CWIPRPKHIS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CWIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPRPKHIS UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRPKHIS.FACTORY), CWIPRPKHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "FACTORY_NO", MP_STR, sizeof(CWIPRPKHIS.FACTORY_NO), CWIPRPKHIS.FACTORY_NO);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPRPKHIS.PALLET_ID), CWIPRPKHIS.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPRPKHIS.MAT_ID), CWIPRPKHIS.MAT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}           
        }
        else if (TRS.get_procstep(in_node) == MP_STEP_DELETE)
        { 
			CDB_delete_cwiprpkhis(1, &CWIPRPKHIS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CWIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPRPKHIS DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRPKHIS.FACTORY), CWIPRPKHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "FACTORY_NO", MP_STR, sizeof(CWIPRPKHIS.FACTORY_NO), CWIPRPKHIS.FACTORY_NO);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPRPKHIS.PALLET_ID), CWIPRPKHIS.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPRPKHIS.MAT_ID), CWIPRPKHIS.MAT_ID);
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
    CWIP_Update_Repacking_Log_Validation()
        - Main sub function of "CWIP_UPDATE_REPACKING_LOG" function
        - Check the condition for create/update/delete Repacking_Log
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Repacking_Log_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	char s_curr_time[14];
	char s_work_time[14];
	char s_calc_work_time[14];

	int i_diff_sec;

    struct CWIPRPKHIS_TAG CWIPRPKHIS;
    struct MWIPFACDEF_TAG MWIPFACDEF;

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
        strcpy(s_msg_code, "CWIP-0001");
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


	//2019 11 11 일에 입력하면
	//2019 11 13 일 05:59:59 까지는 수정 삭제가 가능해야 한다.
	//현재 시간이 SCRAP_DATE + 2일 05:59:59 보다 크면 에러 
	memset(s_curr_time, ' ', sizeof(s_curr_time));
	DB_get_systime(s_curr_time);
	if(DB_error_code != DB_SUCCESS)
	{
		TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_COMMON;

		COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
		
	memset(s_work_time, ' ', sizeof(s_work_time));
	TRS.copy(s_work_time, sizeof(s_work_time), in_node, "WORK_DATE");
	memcpy(s_work_time+8, "055959", strlen("055959"));

	// 입력받은 scrap date + 2일 한 값의 05:59:59 까지 수정가능		
	// work_time 에 +2일 하여 수정가능한 최종 시간 구한다.
	DB_get_calc_time(s_calc_work_time, s_work_time, 3, 2);		

	COM_diff_time_sec(&i_diff_sec, s_curr_time, s_calc_work_time);

	// 현재 시간이 최종 작업가능 시간 보다 크면 수정 불가
	// 그 외에는 수정 가능
	if (i_diff_sec > 0)
	{
		// 수정 가능한 시간이 지났습니다.
		strcpy(s_msg_code, "WIP-0601");
		TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
		TRS.add_fieldmsg(out_node, "LIMIT TIME", MP_STR, sizeof(s_calc_work_time), s_calc_work_time);
		TRS.add_fieldmsg(out_node, "CURRENT TIME", MP_STR, sizeof(s_curr_time), s_curr_time);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		return MP_FALSE;
	}		

    return MP_TRUE; 
}

