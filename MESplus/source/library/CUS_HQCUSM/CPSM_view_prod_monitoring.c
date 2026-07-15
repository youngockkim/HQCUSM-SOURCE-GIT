/******************************************************************************'

    System      : MESplus
    Module      : CPSM
    File Name   : CPSM_view_prod_monitoring.c
    Description : View Prod_Monitoring function module

    MES Version : 5.3.4 ~

    Function List
        - CPSM_View_Prod_Monitoring()
            + View Prod_Monitoring definition
        - CPSM_VIEW_PROD_MONITORING()
            + Main sub function of CPSM_View_Prod_Monitoring function
            + View Prod_Monitoring definition
        - CPSM_View_Prod_Monitoring_Validation()
            + Main sub function of CPSM_VIEW_PROD_MONITORING function
            + Check the condition for view Prod_Monitoring
    Detail Description
        - CPSM_VIEW_PROD_MONITORING()
            + h_proc_step
                + 1 : View Prod_Monitoring definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023/09/25             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CPSM_View_Prod_Monitoring_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CPSM_View_Prod_Monitoring()
        - View Prod_Monitoring definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_View_Prod_Monitoring(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CPSM_VIEW_PROD_MONITORING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CPSM_VIEW_PROD_MONITORING", out_node);

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
    CPSM_VIEW_PROD_MONITORING()
        - Main sub function of "CPSM_View_Prod_Monitoring" function
        - View Prod_Monitoring definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_VIEW_PROD_MONITORING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CPSMMNTSTS_TAG CPSMMNTSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MRASRESDEF_TAG MRASRESDEF;

    LOG_head("CPSM_VIEW_PROD_MONITORING");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("category", MP_NSTR, TRS.get_string(in_node, "CATEGORY"));
    LOG_add("base_code", MP_NSTR, TRS.get_string(in_node, "BASE_CODE"));
    LOG_add("sub_code", MP_NSTR, TRS.get_string(in_node, "SUB_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CPSM", "CPSM_View_Prod_Monitoring",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CPSM_View_Prod_Monitoring_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cpsmmntsts(&CPSMMNTSTS);
    TRS.copy(CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY), in_node, "CATEGORY");
    TRS.copy(CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE), in_node, "BASE_CODE");
    TRS.copy(CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE), in_node, "SUB_CODE");
    CDB_select_cpsmmntsts(1, &CPSMMNTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "CPSMMNTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
        TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
        TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY));
    TRS.add_string(out_node, "CATEGORY", CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY));
    TRS.add_string(out_node, "BASE_CODE", CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE));
    TRS.add_string(out_node, "SUB_CODE", CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE));
    TRS.add_string(out_node, "DESCRIPTION", CPSMMNTSTS.DESCRIPTION, sizeof(CPSMMNTSTS.DESCRIPTION));
    TRS.add_char(out_node, "PRINT_CHECK", CPSMMNTSTS.PRINT_CHECK);
    TRS.add_int(out_node, "BASE_DT_TIME", CPSMMNTSTS.BASE_DT_TIME);
    TRS.add_string(out_node, "OPTION_1", CPSMMNTSTS.OPTION_1, sizeof(CPSMMNTSTS.OPTION_1));
    TRS.add_string(out_node, "OPTION_2", CPSMMNTSTS.OPTION_2, sizeof(CPSMMNTSTS.OPTION_2));
    TRS.add_string(out_node, "OPTION_3", CPSMMNTSTS.OPTION_3, sizeof(CPSMMNTSTS.OPTION_3));
    TRS.add_string(out_node, "OPTION_4", CPSMMNTSTS.OPTION_4, sizeof(CPSMMNTSTS.OPTION_4));
    TRS.add_string(out_node, "OPTION_5", CPSMMNTSTS.OPTION_5, sizeof(CPSMMNTSTS.OPTION_5));
    TRS.add_string(out_node, "LAST_TRAN_TIME", CPSMMNTSTS.LAST_TRAN_TIME, sizeof(CPSMMNTSTS.LAST_TRAN_TIME));
    TRS.add_string(out_node, "TRAN_USER_ID", CPSMMNTSTS.TRAN_USER_ID, sizeof(CPSMMNTSTS.TRAN_USER_ID));
    TRS.add_string(out_node, "STATUS", CPSMMNTSTS.STATUS, sizeof(CPSMMNTSTS.STATUS));
    TRS.add_string(out_node, "STATUS_MSG", CPSMMNTSTS.STATUS_MSG, sizeof(CPSMMNTSTS.STATUS_MSG));
    TRS.add_string(out_node, "CLIENT_VERSION", CPSMMNTSTS.CLIENT_VERSION, sizeof(CPSMMNTSTS.CLIENT_VERSION));
    TRS.add_string(out_node, "CMF_1", CPSMMNTSTS.CMF_1, sizeof(CPSMMNTSTS.CMF_1));
    TRS.add_string(out_node, "CMF_2", CPSMMNTSTS.CMF_2, sizeof(CPSMMNTSTS.CMF_2));
    TRS.add_string(out_node, "CMF_3", CPSMMNTSTS.CMF_3, sizeof(CPSMMNTSTS.CMF_3));
    TRS.add_string(out_node, "CMF_4", CPSMMNTSTS.CMF_4, sizeof(CPSMMNTSTS.CMF_4));
    TRS.add_string(out_node, "CMF_5", CPSMMNTSTS.CMF_5, sizeof(CPSMMNTSTS.CMF_5));
    TRS.add_string(out_node, "CMF_6", CPSMMNTSTS.CMF_6, sizeof(CPSMMNTSTS.CMF_6));
    TRS.add_string(out_node, "CMF_7", CPSMMNTSTS.CMF_7, sizeof(CPSMMNTSTS.CMF_7));
    TRS.add_string(out_node, "CMF_8", CPSMMNTSTS.CMF_8, sizeof(CPSMMNTSTS.CMF_8));
    TRS.add_string(out_node, "CMF_9", CPSMMNTSTS.CMF_9, sizeof(CPSMMNTSTS.CMF_9));
    TRS.add_string(out_node, "CMF_10", CPSMMNTSTS.CMF_10, sizeof(CPSMMNTSTS.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CPSMMNTSTS.CREATE_USER_ID, sizeof(CPSMMNTSTS.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CPSMMNTSTS.CREATE_TIME, sizeof(CPSMMNTSTS.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CPSMMNTSTS.UPDATE_USER_ID, sizeof(CPSMMNTSTS.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CPSMMNTSTS.UPDATE_TIME, sizeof(CPSMMNTSTS.UPDATE_TIME));

	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	memcpy(MGCMTBLDAT.FACTORY, CPSMMNTSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
	memcpy(MGCMTBLDAT.TABLE_NAME, "@CPSM_CATEGORY", strlen("@CPSM_CATEGORY"));
	memcpy(MGCMTBLDAT.KEY_1, CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "CATEGORY_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}

	if(TRS.mem_cmp(in_node, "CATEGORY", "CIM", strlen("CIM")) == 0)
	{
		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, CPSMMNTSTS.FACTORY, sizeof(MRASRESDEF.FACTORY));
		memcpy(MRASRESDEF.RES_ID, CPSMMNTSTS.BASE_CODE, sizeof(MRASRESDEF.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code == DB_SUCCESS)
		{
			if(memcmp(MRASRESDEF.RES_STS_8, "C", strlen("C")) == 0)
			{
				TRS.set_string(out_node, "STATUS", "ON", strlen("ON"));
			}
			else if(memcmp(MRASRESDEF.RES_STS_8, "D", strlen("D")) == 0)
			{
				TRS.set_string(out_node, "STATUS", "OFF", strlen("OFF"));
				TRS.set_string(out_node, "CMF_1", "DT", strlen("DT"));
				TRS.set_string(out_node, "STATUS_MSG", "Off-Line", strlen("Off-Line"));
			}
			else
			{
				TRS.set_string(out_node, "STATUS", "-", strlen("-"));
				TRS.set_string(out_node, "CMF_1", "DT", strlen("DT"));
				TRS.set_string(out_node, "STATUS_MSG", "There is no value", strlen("There is no value"));
			}
/*			TRS.set_string(out_node, "DESCRIPTION", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));	*/			
		}
	}

    /* Not use in customizing
    if(COM_proc_user_routine("CPSM", "CPSM_View_Prod_Monitoring",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CPSM_View_Prod_Monitoring_Validation()
        - Main sub function of "CPSM_VIEW_PROD_MONITORING" function
        - Check the condition for view Prod_Monitoring
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPSM_View_Prod_Monitoring_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CPSMMNTSTS_TAG CPSMMNTSTS;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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
        strcpy(s_msg_code, "CPSM-0001");
        TRS.add_fieldmsg(out_node, "CATEGORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* BASE_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "BASE_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CMN-0002");
        TRS.add_fieldmsg(out_node, "BASE_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    //* SUB_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SUB_CODE")) == MP_TRUE)
    {
       TRS.set_nstring(in_node, "SUB_CODE", " ");
    }

    CDB_init_cpsmmntsts(&CPSMMNTSTS);
    TRS.copy(CPSMMNTSTS.FACTORY, sizeof(CPSMMNTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CPSMMNTSTS.CATEGORY, sizeof(CPSMMNTSTS.CATEGORY), in_node, "CATEGORY");
    TRS.copy(CPSMMNTSTS.BASE_CODE, sizeof(CPSMMNTSTS.BASE_CODE), in_node, "BASE_CODE");
    TRS.copy(CPSMMNTSTS.SUB_CODE, sizeof(CPSMMNTSTS.SUB_CODE), in_node, "SUB_CODE");
    CDB_select_cpsmmntsts(1, &CPSMMNTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "CMN-0004");
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "CMN-0003");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "CPSMMNTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPSMMNTSTS.FACTORY), CPSMMNTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "CATEGORY", MP_STR, sizeof(CPSMMNTSTS.CATEGORY), CPSMMNTSTS.CATEGORY);
        TRS.add_fieldmsg(out_node, "BASE_CODE", MP_STR, sizeof(CPSMMNTSTS.BASE_CODE), CPSMMNTSTS.BASE_CODE);
        TRS.add_fieldmsg(out_node, "SUB_CODE", MP_STR, sizeof(CPSMMNTSTS.SUB_CODE), CPSMMNTSTS.SUB_CODE);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

