/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_update_scraplb_list_tb.c
	Description : Update Scrap List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_Update_ScrapLb_List_Tb()
			+ View Scrap List
		- CWIP_UPDATE_SCRAPLB_LIST_TB()
			+ Main sub function of CWIP_Update_Scrap_List_Lb function
			+ View Scrap List definition
		- CWIP_Update_ScrapLb_List_Tb_Validation()
			+ Main sub function of CWIP_UPDATE_SCRAPLB_LIST_TB function
			+ Check the condition for View Scrap List
	Detail Description
		- CWIP_UPDATE_SCRAPLB_LIST_TB()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2023/06/16  KBC           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_ScrapLb_List_Tb_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_Update_ScrapLb_List_Tb()
		- Update Scrap List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_ScrapLb_List_Tb(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_SCRAPLB_LIST_TB(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_SCRAPLB_LIST_TB", out_node);

	if (i_ret == MP_TRUE)
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
	CWIP_UPDATE_SCRAPLB_LIST_TB()
		- Main sub function of "CWIP_Update_Scrap_List_Lb" function
		- View Scrap List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_SCRAPLB_LIST_TB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPLOSTAB_TAG CWIPLOSTAB;

    char s_sys_time[14];
    int i_tran_count;
    int i;
    //int i_step;

    TRSNode ** Tran_List;

    LOG_head("CWIP_UPDATE_SCRAPLB_LIST_TB");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	//validation 수정 필요
    if(CWIP_Update_ScrapLb_List_Tb_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

    Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

    for(i = 0; i < i_tran_count; i++)
    {
		if ( TRS.get_procstep(in_node) == MP_STEP_CREATE ||  TRS.get_procstep(in_node) == MP_STEP_UPDATE  ) 
		{
		    CDB_init_cwiplostab(&CWIPLOSTAB);
            TRS.copy(CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID), in_node, "LINE_ID");
            TRS.copy(CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT), in_node, "WORK_SHIFT");
            TRS.copy(CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE), in_node, "WORK_DATE");
            TRS.copy(CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID), in_node, "OPERATOR_ID");
            TRS.copy(CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID), Tran_List[i], "OPER_ID");
            TRS.copy(CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID), Tran_List[i], "RES_ID");
			TRS.copy(CWIPLOSTAB.OPER_SUB_ID, sizeof(CWIPLOSTAB.OPER_SUB_ID), Tran_List[i], "OPER_SUB_ID");
			
			CDB_select_cwiplostab(1,&CWIPLOSTAB);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					CWIPLOSTAB.LOSS_QTY = TRS.get_double(Tran_List[i], "LOSS_QTY");
					TRS.copy(CWIPLOSTAB.LOSS_CAUSE, sizeof(CWIPLOSTAB.LOSS_CAUSE), Tran_List[i], "LOSS_CAUSE");
					TRS.copy(CWIPLOSTAB.BOX_USE, sizeof(CWIPLOSTAB.BOX_USE), Tran_List[i], "BOX_USE");
					TRS.copy(CWIPLOSTAB.LOSS_COMMENT, sizeof(CWIPLOSTAB.LOSS_COMMENT), Tran_List[i], "LOSS_COMMENT");
					TRS.copy(CWIPLOSTAB.CREATE_USER_ID, sizeof(CWIPLOSTAB.CREATE_USER_ID), in_node, IN_USERID);
					memcpy(CWIPLOSTAB.CREATE_TIME, s_sys_time, sizeof(CWIPLOSTAB.CREATE_TIME));

					CDB_insert_cwiplostab(&CWIPLOSTAB);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "CWIPLOSTAB INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
						TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
						TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
						TRS.add_fieldmsg(out_node, "LOSS_CAUSE", MP_STR, sizeof(CWIPLOSTAB.LOSS_CAUSE), CWIPLOSTAB.LOSS_CAUSE);
						TRS.add_fieldmsg(out_node, "BOX_USE", MP_STR, sizeof(CWIPLOSTAB.BOX_USE), CWIPLOSTAB.BOX_USE);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
						TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
						TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(CWIPLOSTAB.LOSS_COMMENT), CWIPLOSTAB.LOSS_COMMENT);
						TRS.copy(CWIPLOSTAB.UPDATE_USER_ID, sizeof(CWIPLOSTAB.CREATE_USER_ID), in_node, IN_USERID);
						memcpy(CWIPLOSTAB.CREATE_TIME, s_sys_time, sizeof(CWIPLOSTAB.CREATE_TIME));

						TRS.add_dberrmsg(out_node,DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}					
			} else 
			{            
				/* Update */
				CWIPLOSTAB.LOSS_QTY = TRS.get_double(Tran_List[i], "LOSS_QTY");
				TRS.copy(CWIPLOSTAB.LOSS_CAUSE, sizeof(CWIPLOSTAB.LOSS_CAUSE), Tran_List[i], "LOSS_CAUSE");
				TRS.copy(CWIPLOSTAB.LOSS_COMMENT, sizeof(CWIPLOSTAB.LOSS_COMMENT), Tran_List[i], "LOSS_COMMENT");
				TRS.copy(CWIPLOSTAB.UPDATE_USER_ID, sizeof(CWIPLOSTAB.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CWIPLOSTAB.UPDATE_TIME, s_sys_time, sizeof(CWIPLOSTAB.UPDATE_TIME));
				TRS.copy(CWIPLOSTAB.BOX_USE, sizeof(CWIPLOSTAB.BOX_USE), Tran_List[i], "BOX_USE");
	
				CDB_update_cwiplostab(1,&CWIPLOSTAB);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPLOSTAB UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
					TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
					TRS.add_fieldmsg(out_node, "LOSS_CAUSE", MP_STR, sizeof(CWIPLOSTAB.LOSS_CAUSE), CWIPLOSTAB.LOSS_CAUSE);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
					TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(CWIPLOSTAB.LOSS_COMMENT), CWIPLOSTAB.LOSS_COMMENT);

					TRS.add_dberrmsg(out_node,DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
        else if (TRS.get_procstep(in_node) == MP_STEP_DELETE)
        {
            CDB_init_cwiplostab(&CWIPLOSTAB);
            TRS.copy(CWIPLOSTAB.FACTORY, sizeof(CWIPLOSTAB.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CWIPLOSTAB.LINE_ID, sizeof(CWIPLOSTAB.LINE_ID), in_node, "LINE_ID");
            TRS.copy(CWIPLOSTAB.WORK_SHIFT, sizeof(CWIPLOSTAB.WORK_SHIFT), in_node, "WORK_SHIFT");
            TRS.copy(CWIPLOSTAB.WORK_DATE, sizeof(CWIPLOSTAB.WORK_DATE), in_node, "WORK_DATE");
            TRS.copy(CWIPLOSTAB.OPERATOR_ID, sizeof(CWIPLOSTAB.OPERATOR_ID), in_node, "OPERATOR_ID");
            TRS.copy(CWIPLOSTAB.OPER_ID, sizeof(CWIPLOSTAB.OPER_ID), Tran_List[i], "OPER_ID");
            TRS.copy(CWIPLOSTAB.RES_ID, sizeof(CWIPLOSTAB.RES_ID), Tran_List[i], "RES_ID");
			TRS.copy(CWIPLOSTAB.OPER_SUB_ID, sizeof(CWIPLOSTAB.OPER_SUB_ID), Tran_List[i], "OPER_SUB_ID");

            CDB_select_cwiplostab(1,&CWIPLOSTAB);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
			        strcpy(s_msg_code, "WIP-0566");
                    TRS.add_fieldmsg(out_node, "CWIPLOSTAB DELETE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(CWIPLOSTAB.LOSS_CAUSE), CWIPLOSTAB.LOSS_CAUSE);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);

			        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
		        }
                else 
                {            
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "CWIPLOSTAB DELETE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(CWIPLOSTAB.LOSS_CAUSE), CWIPLOSTAB.LOSS_CAUSE);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }

            CDB_delete_cwiplostab(1,&CWIPLOSTAB);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "CWIPLOSTAB OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOSTAB.FACTORY), CWIPLOSTAB.FACTORY);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLOSTAB.LINE_ID), CWIPLOSTAB.LINE_ID);
                TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPLOSTAB.WORK_SHIFT), CWIPLOSTAB.WORK_SHIFT);
                TRS.add_fieldmsg(out_node, "LOSS_CAUSE", MP_STR, sizeof(CWIPLOSTAB.LOSS_CAUSE), CWIPLOSTAB.LOSS_CAUSE);
                TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLOSTAB.WORK_DATE), CWIPLOSTAB.WORK_DATE);
                TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLOSTAB.RES_ID), CWIPLOSTAB.RES_ID);
                TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(CWIPLOSTAB.LOSS_COMMENT), CWIPLOSTAB.LOSS_COMMENT);

                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_Update_ScrapLb_List_Tb_Validation()
		- Main sub function of "CWIP_UPDATE_SCRAPLB_LIST_TB" function
		- Check the condition for View Scrap List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_ScrapLb_List_Tb_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    int     i_tran_count;
    int		i;
    TRSNode ** Tran_List;

	char s_curr_time[14];
	char s_work_time[14];
	char s_calc_work_time[14];

	int i_diff_sec;

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

    Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

    //for(i = 0; i < i_tran_count; i++)
    //{
    //    if(com_isnullspace(trs.get_string(tran_list[i], "loss_cause")) == mp_true)
	   // {
		  //  strcpy(s_msg_code, "wip-0568");
    //        trs.add_fieldmsg(out_node, "line_id", mp_str, strlen(trs.get_string(in_node, "line_id")), trs.get_string(in_node, "line_id"));
    //        trs.add_fieldmsg(out_node, "work_shift", mp_str, strlen(trs.get_string(in_node, "work_shift")), trs.get_string(in_node, "work_shift"));
    //        trs.add_fieldmsg(out_node, "work_date", mp_str, strlen(trs.get_string(in_node, "work_date")), trs.get_string(in_node, "work_date"));
    //        trs.add_fieldmsg(out_node, "loss_oper", mp_str, strlen(trs.get_string(tran_list[i], "loss_oper")), trs.get_string(tran_list[i], "loss_oper"));
    //        trs.add_fieldmsg(out_node, "res_id", mp_str, strlen(trs.get_string(tran_list[i], "res_id")), trs.get_string(tran_list[i], "res_id"));
    //        trs.add_fieldmsg(out_node, "cause", mp_str, strlen(trs.get_string(tran_list[i], "cause")), trs.get_string(tran_list[i], "loss_type"));

		  //  gs_log_type.type = mp_log_error;
		  //  gs_log_type.e_type = mp_log_e_validation;
		  //  gs_log_type.category = mp_log_cate_setup;
		  //  return mp_false;
	   // }
    //}

    if (i_tran_count < 1)
    {
        if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
            strcpy(s_msg_code, "WIP-0568");
        }
        else
        {
		    strcpy(s_msg_code, "WIP-0567");
        }

        gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_TRANS;
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

	// 입력받은 scrap date + 3일 한 값의 05:59:59 까지 수정가능		
	// work_time 에 +2일 하여 수정가능한 최종 시간 구한다.
	DB_get_calc_time(s_calc_work_time, s_work_time, 3, 3);		

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