/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_tabber_clean_list.c
    Description : View TABBER_CLEAN List function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_TABBER_CLEAN_List()
            + View TABBER_CLEAN definition List
        - CRAS_VIEW_TABBER_CLEAN_LIST()
            + Main sub function of CRAS_View_TABBER_CLEAN_List function
            + View TABBER_CLEAN definition List
    Detail Description
        - CRAS_VIEW_TABBER_CLEAN_LIST()
            + h_proc_step
                + 1 : View TABBER_CLEAN definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-11-17             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_TABBER_CLEAN_List()
        - View TABBER_CLEAN definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_TABBER_CLEAN_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_TABBER_CLEAN_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_TABBER_CLEAN_LIST", out_node);

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
    CRAS_VIEW_TABBER_CLEAN_LIST()
        - Main sub function of "CRAS_View_TABBER_CLEAN_List" function
        - View TABBER_CLEAN definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_TABBER_CLEAN_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASCLNPLN_TAG CRASCLNPLN;
	struct MWIPCALDEF_TAG MWIPCALDEF;

    TRSNode *list_item;

    int i_case;
	int icnt = 0;

    LOG_head("CRAS_VIEW_HOUR_GAP_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

   
    ///* ProcStep Validation */
    //if(COM_service_validation(s_msg_code,
    //                          in_node,
    //                          out_node,
    //                          TRS.get_procstep(in_node),
    //                          "1") == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

	//1.WORK_DATE 기준으로 년.월.WEEK를 구한다.
	DBC_init_mwipcaldef(&MWIPCALDEF);
	memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); 
    MWIPCALDEF.CALENDAR_TYPE = 'F';
	TRS.copy(MWIPCALDEF.SYS_DATE, sizeof(MWIPCALDEF.SYS_DATE), in_node, "WORK_DATE");
	   
    DBC_select_mwipcaldef(5, &MWIPCALDEF);
	if (DB_error_code != DB_SUCCESS)
	{
		CDB_init_crasclnpln(&CRASCLNPLN);
	}
	else
	{
		CDB_init_crasclnpln(&CRASCLNPLN);
		CRASCLNPLN.PLAN_YEAR = MWIPCALDEF.PLAN_YEAR;
		CRASCLNPLN.PLAN_WEEK = MWIPCALDEF.PLAN_WEEK;
	}

	//2.해당 주의 시작일을 구한다.
	if (TRS.get_procstep(in_node) == '2')
		{
		memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); 
	   
		DBC_select_mwipcaldef(2, &MWIPCALDEF);
		if (DB_error_code != DB_SUCCESS)
		{
		
		}
		else
		{
			list_item = TRS.add_node(out_node, "TABBER_DATE");
			TRS.add_string(list_item, "PLAN_MIN_DATE", MWIPCALDEF.SYS_DATE, sizeof(MWIPCALDEF.SYS_DATE));
		}

		//3.해당 주의 종료일 구한다.S
		DBC_select_mwipcaldef(3, &MWIPCALDEF);
		if (DB_error_code != DB_SUCCESS)
		{
		
		}
		else
		{
			TRS.add_string(list_item, "PLAN_MAX_DATE", MWIPCALDEF.SYS_DATE, sizeof(MWIPCALDEF.SYS_DATE));
		}

		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;

	}


	
    i_case = 2;

    TRS.copy(CRASCLNPLN.FACTORY, sizeof(CRASCLNPLN.FACTORY), in_node, IN_FACTORY);
    //CRASCLNPLN.PLAN_YEAR = TRS.get_int(in_node, "PLAN_YEAR");
    //CRASCLNPLN.PLAN_WEEK = TRS.get_int(in_node, "PLAN_WEEK");
    TRS.copy(CRASCLNPLN.WORK_SHIFT, sizeof(CRASCLNPLN.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CRASCLNPLN.LINE_ID, sizeof(CRASCLNPLN.LINE_ID), in_node, "LINE_ID");
	
	icnt = (int) CDB_select_crasclnpln_scalar(2,&CRASCLNPLN);
	//저장이 안된 경우 달력을 조회한다.
	if(icnt == 0)
	{
		//2025.06.17 (Change to MGCMTBLDAT ) for tabber list
		//i_case = 3; 
		i_case = 4;
		CDB_open_crasclnpln(i_case, &CRASCLNPLN);
	}
	else		//저장이 된 경우
	{
		CDB_open_crasclnpln(i_case, &CRASCLNPLN);
	}

	
	

    
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "CRASCLNPLN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
        TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
        TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASCLNPLN.RES_ID), CRASCLNPLN.RES_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_crasclnpln(i_case, &CRASCLNPLN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_crasclnpln(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "CRASCLNPLN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASCLNPLN.FACTORY), CRASCLNPLN.FACTORY);
            TRS.add_fieldmsg(out_node, "PLAN_YEAR", MP_INT, CRASCLNPLN.PLAN_YEAR);
            TRS.add_fieldmsg(out_node, "PLAN_WEEK", MP_INT, CRASCLNPLN.PLAN_WEEK);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASCLNPLN.WORK_SHIFT), CRASCLNPLN.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASCLNPLN.LINE_ID), CRASCLNPLN.LINE_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_crasclnpln(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

      

        list_item = TRS.add_node(out_node, "TABBER_CLEAN_LIST");

        TRS.add_string(list_item, "FACTORY", CRASCLNPLN.FACTORY, sizeof(CRASCLNPLN.FACTORY));
        TRS.add_int(list_item, "PLAN_YEAR", CRASCLNPLN.PLAN_YEAR);
        TRS.add_int(list_item, "PLAN_WEEK", CRASCLNPLN.PLAN_WEEK);
        
		TRS.copy(CRASCLNPLN.WORK_SHIFT, sizeof(CRASCLNPLN.WORK_SHIFT), in_node, "WORK_SHIFT");
		TRS.add_string(list_item, "WORK_SHIFT", CRASCLNPLN.WORK_SHIFT, sizeof(CRASCLNPLN.WORK_SHIFT));

        TRS.add_string(list_item, "LINE_ID", CRASCLNPLN.LINE_ID, sizeof(CRASCLNPLN.LINE_ID));
        TRS.add_string(list_item, "RES_ID", CRASCLNPLN.RES_ID, sizeof(CRASCLNPLN.RES_ID));
        TRS.add_string(list_item, "CLEAN1_PLAN_TIME", CRASCLNPLN.CLEAN1_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN1_PLAN_TIME));
        TRS.add_char(list_item, "CLEAN1_FLAG", CRASCLNPLN.CLEAN1_FLAG);
        TRS.add_string(list_item, "CLEAN1_COM_DT", CRASCLNPLN.CLEAN1_COM_DT, sizeof(CRASCLNPLN.CLEAN1_COM_DT));
        TRS.add_string(list_item, "CLEAN2_PLAN_TIME", CRASCLNPLN.CLEAN2_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN2_PLAN_TIME));
        TRS.add_char(list_item, "CLEAN2_FLAG", CRASCLNPLN.CLEAN2_FLAG);
        TRS.add_string(list_item, "CLEAN2_COM_DT", CRASCLNPLN.CLEAN2_COM_DT, sizeof(CRASCLNPLN.CLEAN2_COM_DT));
        TRS.add_string(list_item, "CLEAN3_PLAN_TIME", CRASCLNPLN.CLEAN3_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN3_PLAN_TIME));
        TRS.add_char(list_item, "CLEAN3_FLAG", CRASCLNPLN.CLEAN3_FLAG);
        TRS.add_string(list_item, "CLEAN3_COM_DT", CRASCLNPLN.CLEAN3_COM_DT, sizeof(CRASCLNPLN.CLEAN3_COM_DT));
        TRS.add_string(list_item, "CLEAN4_PLAN_TIME", CRASCLNPLN.CLEAN4_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN4_PLAN_TIME));
        TRS.add_char(list_item, "CLEAN4_FLAG", CRASCLNPLN.CLEAN4_FLAG);
        TRS.add_string(list_item, "CLEAN4_COM_DT", CRASCLNPLN.CLEAN4_COM_DT, sizeof(CRASCLNPLN.CLEAN4_COM_DT));
        TRS.add_string(list_item, "CLEAN5_PLAN_TIME", CRASCLNPLN.CLEAN5_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN5_PLAN_TIME));
        TRS.add_char(list_item, "CLEAN5_FLAG", CRASCLNPLN.CLEAN5_FLAG);
        TRS.add_string(list_item, "CLEAN5_COM_DT", CRASCLNPLN.CLEAN5_COM_DT, sizeof(CRASCLNPLN.CLEAN5_COM_DT));
        TRS.add_string(list_item, "CLEAN6_PLAN_TIME", CRASCLNPLN.CLEAN6_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN6_PLAN_TIME));
        TRS.add_char(list_item, "CLEAN6_FLAG", CRASCLNPLN.CLEAN6_FLAG);
        TRS.add_string(list_item, "CLEAN6_COM_DT", CRASCLNPLN.CLEAN6_COM_DT, sizeof(CRASCLNPLN.CLEAN6_COM_DT));
        TRS.add_string(list_item, "CLEAN7_PLAN_TIME", CRASCLNPLN.CLEAN7_PLAN_TIME, sizeof(CRASCLNPLN.CLEAN7_PLAN_TIME));
        TRS.add_char(list_item, "CLEAN7_FLAG", CRASCLNPLN.CLEAN7_FLAG);
        TRS.add_string(list_item, "CLEAN7_COM_DT", CRASCLNPLN.CLEAN7_COM_DT, sizeof(CRASCLNPLN.CLEAN7_COM_DT));
        TRS.add_string(list_item, "CREATE_TIME", CRASCLNPLN.CREATE_TIME, sizeof(CRASCLNPLN.CREATE_TIME));
        TRS.add_string(list_item, "CMF_1", CRASCLNPLN.CMF_1, sizeof(CRASCLNPLN.CMF_1));
        TRS.add_string(list_item, "CMF_2", CRASCLNPLN.CMF_2, sizeof(CRASCLNPLN.CMF_2));
        TRS.add_string(list_item, "CMF_3", CRASCLNPLN.CMF_3, sizeof(CRASCLNPLN.CMF_3));
        TRS.add_string(list_item, "CMF_4", CRASCLNPLN.CMF_4, sizeof(CRASCLNPLN.CMF_4));
        TRS.add_string(list_item, "CMF_5", CRASCLNPLN.CMF_5, sizeof(CRASCLNPLN.CMF_5));

		if(icnt == 0)		//저장된 데이터가 없는 경우
		{
			TRS.add_string(list_item, "UPDATE_FLAG", "N", 1);
		}
		else
		{
			TRS.add_string(list_item, "UPDATE_FLAG", "Y", 1);
		}




    }

    /* Not use in customizing
    if(COM_proc_user_routine("CRAS", "CRAS_View_TABBER_CLEAN_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */




    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

