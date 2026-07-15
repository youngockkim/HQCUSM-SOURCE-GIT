/******************************************************************************'

    System      : MESplus
    Module      : CPSM
    File Name   : CPSM_view_prod_monitoring_list.c
    Description : View Prod_Monitoring List function module

    MES Version : 5.3.4 ~

    Function List
        - CPSM_View_Prod_Monitoring_List()
            + View Prod_Monitoring definition List
        - CPSM_VIEW_PROD_MONITORING_LIST()
            + Main sub function of CPSM_View_Prod_Monitoring_List function
            + View Prod_Monitoring definition List
        - CPSM_View_Prod_Monitoring_List_Validation()
            + Main sub function of CPSM_VIEW_PROD_MONITORING_LIST function
            + Check the condition for view Prod_Monitoring list
    Detail Description
        - CPSM_VIEW_PROD_MONITORING_LIST()
            + h_proc_step
                + 1 : View Prod_Monitoring definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/09/25             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CPSM_View_Prod_Monitoring_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CPSM_View_Prod_Monitoring_List()
        - View Prod_Monitoring definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_View_Prod_Monitoring_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CPSM_VIEW_PROD_MONITORING_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CPSM_VIEW_PROD_MONITORING_LIST", out_node);

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
    CPSM_VIEW_PROD_MONITORING_LIST()
        - Main sub function of "CPSM_View_Prod_Monitoring_List" function
        - View Prod_Monitoring definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_VIEW_PROD_MONITORING_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CPSMMNTSTS_TAG CPSMMNTSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct RSUMRESDWH_TAG RSUMRESDWH;
	/*struct MGCMTBLDAT_TAG MGCMTBLDAT;*/
    TRSNode *list_item;

	char   s_sys_time[14];
    int i_case;

    LOG_head("CPSM_VIEW_PROD_MONITORING_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

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

    if(CPSM_View_Prod_Monitoring_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if(TRS.get_procstep(in_node) == '1') // MC-CIM 조회인 경우 
		i_case = 1;
	else
		i_case = 2;

    CDB_init_cpsmmntsts(&CPSMMNTSTS);
    TRS.copy(CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY), in_node, "CATEGORY");
    TRS.copy(CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE), in_node, "BASE_CODE");
    TRS.copy(CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE), in_node, "SUB_CODE");
    TRS.copy(CPSMMNTSTS.OPTION_1, sizeof(CPSMMNTSTS.OPTION_1), in_node, "OPTION_1");
    TRS.copy(CPSMMNTSTS.OPTION_2, sizeof(CPSMMNTSTS.OPTION_2), in_node, "OPTION_2");
    //TRS.copy(CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE), in_node, "NEXT_SUB_CODE");
    CDB_open_cpsmmntsts(i_case, &CPSMMNTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CPSMMNTSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
        TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
        TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
        TRS.add_fieldmsg(out_node, "OPTION_1", MP_STR, sizeof(CPSMMNTSTS.OPTION_1), CPSMMNTSTS.OPTION_1);
        TRS.add_fieldmsg(out_node, "OPTION_2", MP_STR, sizeof(CPSMMNTSTS.OPTION_2), CPSMMNTSTS.OPTION_2);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cpsmmntsts(i_case, &CPSMMNTSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cpsmmntsts(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_fieldmsg(out_node, "CPSMMNTSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
            TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
            TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
            TRS.add_fieldmsg(out_node, "OPTION_1", MP_STR, sizeof(CPSMMNTSTS.OPTION_1), CPSMMNTSTS.OPTION_1);
            TRS.add_fieldmsg(out_node, "OPTION_2", MP_STR, sizeof(CPSMMNTSTS.OPTION_2), CPSMMNTSTS.OPTION_2);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cpsmmntsts(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //if(COM_check_node_length(out_node) == MP_FALSE)
        //{
        //  //  TRS.set_string(out_node, "NEXT_CATEGORY", CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY));
        //    TRS.set_string(out_node, "NEXT_BASE_CODE", CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE));
        //    TRS.set_string(out_node, "NEXT_SUB_CODE", CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE));
        //    CDB_close_cpsmmntsts(i_case);
        //    break;
        //}

        list_item = TRS.add_node(out_node, "PROD_MONITORING_LIST");

        TRS.add_string(list_item, "FACTORY", CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY));
        TRS.add_string(list_item, "CATEGORY", CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY));
        TRS.add_string(list_item, "BASE_CODE", CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE));
        TRS.add_string(list_item, "SUB_CODE", CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE));
        TRS.add_string(list_item, "DESCRIPTION", CPSMMNTSTS.DESCRIPTION, sizeof(CPSMMNTSTS.DESCRIPTION));
        TRS.add_char(list_item, "PRINT_CHECK", CPSMMNTSTS.PRINT_CHECK);
        TRS.add_int(list_item, "BASE_DT_TIME", CPSMMNTSTS.BASE_DT_TIME);
		if(i_case == 1)
		{
			TRS.add_string(list_item, "OPTION_1", CPSMMNTSTS.OPTION_1, sizeof(CPSMMNTSTS.OPTION_1));
			TRS.add_string(list_item, "OPTION_2", CPSMMNTSTS.OPTION_2, sizeof(CPSMMNTSTS.OPTION_2));
			TRS.add_string(list_item, "OPTION_3", CPSMMNTSTS.OPTION_3, sizeof(CPSMMNTSTS.OPTION_3));
			TRS.add_string(list_item, "OPTION_4", CPSMMNTSTS.OPTION_4, sizeof(CPSMMNTSTS.OPTION_4));
			TRS.add_string(list_item, "OPTION_5", CPSMMNTSTS.OPTION_5, sizeof(CPSMMNTSTS.OPTION_5));
			TRS.add_string(list_item, "CMF_6", CPSMMNTSTS.CMF_6, sizeof(CPSMMNTSTS.CMF_6));
			TRS.add_string(list_item, "CMF_7", CPSMMNTSTS.CMF_7, sizeof(CPSMMNTSTS.CMF_7));
			TRS.add_string(list_item, "CMF_8", CPSMMNTSTS.CMF_8, sizeof(CPSMMNTSTS.CMF_8));
			TRS.add_string(list_item, "CMF_9", CPSMMNTSTS.CMF_9, sizeof(CPSMMNTSTS.CMF_9));
			TRS.add_string(list_item, "CMF_10", CPSMMNTSTS.CMF_10, sizeof(CPSMMNTSTS.CMF_10));
		}        
        TRS.add_string(list_item, "LAST_TRAN_TIME", CPSMMNTSTS.LAST_TRAN_TIME, sizeof(CPSMMNTSTS.LAST_TRAN_TIME));
        TRS.add_string(list_item, "TRAN_USER_ID", CPSMMNTSTS.TRAN_USER_ID, sizeof(CPSMMNTSTS.TRAN_USER_ID));
        TRS.add_string(list_item, "STATUS", CPSMMNTSTS.STATUS, sizeof(CPSMMNTSTS.STATUS));
        TRS.add_string(list_item, "STATUS_MSG", CPSMMNTSTS.STATUS_MSG, sizeof(CPSMMNTSTS.STATUS_MSG));
        TRS.add_string(list_item, "CLIENT_VERSION", CPSMMNTSTS.CLIENT_VERSION, sizeof(CPSMMNTSTS.CLIENT_VERSION));
        TRS.add_string(list_item, "CMF_1", CPSMMNTSTS.CMF_1, sizeof(CPSMMNTSTS.CMF_1));
        TRS.add_string(list_item, "CMF_2", CPSMMNTSTS.CMF_2, sizeof(CPSMMNTSTS.CMF_2));
        TRS.add_string(list_item, "CMF_3", CPSMMNTSTS.CMF_3, sizeof(CPSMMNTSTS.CMF_3));
        TRS.add_string(list_item, "CMF_4", CPSMMNTSTS.CMF_4, sizeof(CPSMMNTSTS.CMF_4));
        TRS.add_string(list_item, "CMF_5", CPSMMNTSTS.CMF_5, sizeof(CPSMMNTSTS.CMF_5));        
        TRS.add_string(list_item, "CREATE_USER_ID", CPSMMNTSTS.CREATE_USER_ID, sizeof(CPSMMNTSTS.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CPSMMNTSTS.CREATE_TIME, sizeof(CPSMMNTSTS.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CPSMMNTSTS.UPDATE_USER_ID, sizeof(CPSMMNTSTS.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CPSMMNTSTS.UPDATE_TIME, sizeof(CPSMMNTSTS.UPDATE_TIME));
		TRS.add_string(list_item, "SYS_TIME", s_sys_time, sizeof(s_sys_time));

		//DBC_init_mgcmtbldat(&MGCMTBLDAT);
		//memcpy(MGCMTBLDAT.FACTORY, CPSMMNTSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		//memcpy(MGCMTBLDAT.TABLE_NAME, "@PSM_CATEGORY", strlen("@PSM_CATEGORY"));
		//memcpy(MGCMTBLDAT.KEY_1, CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY));
		//DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		//if(DB_error_code == DB_SUCCESS)
		//{
		//	TRS.add_string(list_item, "LINE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		//}

		if(TRS.get_procstep(in_node) == '3') // MC-CIM 조회인 경우 
		{
			DBC_init_mrasresdef(&MRASRESDEF);
			memcpy(MRASRESDEF.FACTORY, CPSMMNTSTS.FACTORY, sizeof(MRASRESDEF.FACTORY));
			memcpy(MRASRESDEF.RES_ID, CPSMMNTSTS.BASE_CODE, sizeof(MRASRESDEF.RES_ID));
			DBC_select_mrasresdef(1, &MRASRESDEF);
			if(DB_error_code == DB_SUCCESS)
			{
				if(memcmp(MRASRESDEF.RES_STS_8, "C", strlen("C")) == 0)
				{
					TRS.set_string(list_item, "STATUS", "ON", strlen("ON"));
				}
				else if(memcmp(MRASRESDEF.RES_STS_8, "D", strlen("D")) == 0)
				{
					TRS.set_string(list_item, "STATUS", "OFF", strlen("OFF"));
					TRS.set_string(list_item, "CMF_1", "DT", strlen("DT"));
					TRS.set_string(list_item, "STATUS_MSG", "Off-Line", strlen("Off-Line"));
				}
				else
				{
					TRS.set_string(list_item, "STATUS", "-", strlen("-"));
					TRS.set_string(list_item, "CMF_1", "DT", strlen("DT"));
					TRS.set_string(list_item, "STATUS_MSG", "There is no value", strlen("There is no value"));
				}
				//TRS.set_string(list_item, "DESCRIPTION", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));				
				//TRS.set_string(list_item, "STATUS", MRASRESDEF.RES_STS_8, sizeof(MRASRESDEF.RES_STS_8));
				TRS.set_string(list_item, "LAST_TRAN_TIME", s_sys_time, sizeof(s_sys_time));
			}
		}
		else if(TRS.get_procstep(in_node) == '4') // MC 조회인 경우 
		{
			CDB_init_rsumresdwh(&RSUMRESDWH);
			memcpy(RSUMRESDWH.FACTORY, CPSMMNTSTS.FACTORY, sizeof(RSUMRESDWH.FACTORY));
			memcpy(RSUMRESDWH.RES_ID, CPSMMNTSTS.BASE_CODE, sizeof(RSUMRESDWH.RES_ID));
			CDB_select_rsumresdwh(5, &RSUMRESDWH);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.set_string(list_item, "LAST_TRAN_TIME", RSUMRESDWH.TRAN_TIME, sizeof(RSUMRESDWH.TRAN_TIME));
				TRS.set_string(list_item, "STATUS", RSUMRESDWH.ALID, sizeof(RSUMRESDWH.ALID));
				TRS.set_string(list_item, "STATUS_MSG", RSUMRESDWH.ALTX, sizeof(RSUMRESDWH.ALTX));
			}
		}
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CPSM_View_Prod_Monitoring_List_Validation()
        - Main sub function of "CPSM_VIEW_PROD_MONITORING_LIST" function
        - Check the condition for view Prod_Monitoring list
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_View_Prod_Monitoring_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1234") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CATEGORY Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CATEGORY")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "CATEGORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    

    return MP_TRUE;
}

