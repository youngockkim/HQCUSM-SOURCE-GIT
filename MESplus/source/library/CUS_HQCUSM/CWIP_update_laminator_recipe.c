/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_laminator_recipe.c
    Description : Laminator_Recipe Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Laminator_Recipe()
            + Create/Update/Delete Laminator_Recipe definition
        - CWIP_UPDATE_LAMINATOR_RECIPE()
            + Main sub function of CWIP_Update_Laminator_Recipe function
            + Create/Update/Delete Laminator_Recipe definition
        - CWIP_Update_Laminator_Recipe_Validation()
            + Main sub function of CWIP_UPDATE_LAMINATOR_RECIPE function
            + Check the condition for create/update/delete Laminator_Recipe
    Detail Description
        - CWIP_UPDATE_LAMINATOR_RECIPE()
            + h_proc_step
                + MP_STEP_CREATE : Create Laminator_Recipe definition
                + MP_STEP_UPDATE : Update Laminator_Recipe definition
                + MP_STEP_DELETE : Delete Laminator_Recipe definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-08-08             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Laminator_Recipe_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Laminator_Recipe()
        - Create/Update/Delete Laminator_Recipe definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Laminator_Recipe(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_LAMINATOR_RECIPE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_LAMINATOR_RECIPE", out_node);

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
    CWIP_UPDATE_LAMINATOR_RECIPE()
        - Main sub function of "CWIP_Update_Laminator_Recipe" function
        - Create/Update/Delete Laminator_Recipe definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_LAMINATOR_RECIPE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLAMRCP_TAG CWIPLAMRCP;
    struct CWIPLAMRCP_TAG CWIPLAMRCP_o;
    char   s_sys_time[14];
	int i_tran_count;
    int inx;
    TRSNode ** Tran_List;

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

    if(CWIP_Update_Laminator_Recipe_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

    if( TRS.get_procstep(in_node) == MP_STEP_CREATE ||
		TRS.get_procstep(in_node) == MP_STEP_UPDATE )
    {
		for(inx = 0; inx < i_tran_count; inx++)
		{
			CDB_init_cwiplamrcp(&CWIPLAMRCP_o);
			TRS.copy(CWIPLAMRCP_o.FACTORY, sizeof(CWIPLAMRCP_o.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPLAMRCP_o.WORK_DATE, sizeof(CWIPLAMRCP_o.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CWIPLAMRCP_o.LINE_ID, sizeof(CWIPLAMRCP_o.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CWIPLAMRCP_o.RES_ID, sizeof(CWIPLAMRCP_o.RES_ID), Tran_List[inx], "RES_ID");
			TRS.copy(CWIPLAMRCP_o.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD), Tran_List[inx], "CHMB_CD");
			TRS.copy(CWIPLAMRCP_o.CHMB_ATTR, sizeof(CWIPLAMRCP_o.CHMB_ATTR), Tran_List[inx], "CHMB_ATTR");
			CWIPLAMRCP_o.ATTR_VAL = TRS.get_double(Tran_List[inx], "ATTR_VAL");
			CDB_select_cwiplamrcp(1, &CWIPLAMRCP_o);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					CDB_init_cwiplamrcp(&CWIPLAMRCP);
					TRS.copy(CWIPLAMRCP.FACTORY, sizeof(CWIPLAMRCP.FACTORY), in_node, IN_FACTORY);
					TRS.copy(CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE), in_node, "WORK_DATE");
					TRS.copy(CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID), in_node, "LINE_ID");
					TRS.copy(CWIPLAMRCP.RES_ID, sizeof(CWIPLAMRCP.RES_ID), Tran_List[inx], "RES_ID");
					TRS.copy(CWIPLAMRCP.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD), Tran_List[inx], "CHMB_CD");
					TRS.copy(CWIPLAMRCP.CHMB_ATTR, sizeof(CWIPLAMRCP.CHMB_ATTR), Tran_List[inx], "CHMB_ATTR");
					CWIPLAMRCP.ATTR_VAL = TRS.get_double(Tran_List[inx], "ATTR_VAL");
					TRS.copy(CWIPLAMRCP.CREATE_USER_ID, sizeof(CWIPLAMRCP.CREATE_USER_ID), in_node, IN_USERID);
					memcpy(CWIPLAMRCP.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
    				CDB_insert_cwiplamrcp(&CWIPLAMRCP);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "CWIP-0004");
						TRS.add_fieldmsg(out_node, "CWIPLAMRCP INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLAMRCP.FACTORY), CWIPLAMRCP.FACTORY);
						TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLAMRCP.WORK_DATE), CWIPLAMRCP.WORK_DATE);
						TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMRCP.LINE_ID), CWIPLAMRCP.LINE_ID);
						TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMRCP.RES_ID), CWIPLAMRCP.RES_ID);
						TRS.add_fieldmsg(out_node, "CHMB_CD", MP_STR, sizeof(CWIPLAMRCP.CHMB_CD), CWIPLAMRCP.CHMB_CD);
						TRS.add_fieldmsg(out_node, "CHMB_ATTR", MP_STR, sizeof(CWIPLAMRCP.CHMB_ATTR), CWIPLAMRCP.CHMB_ATTR);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
			} else 
			{
				CDB_init_cwiplamrcp(&CWIPLAMRCP);
				TRS.copy(CWIPLAMRCP.FACTORY, sizeof(CWIPLAMRCP.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE), in_node, "WORK_DATE");
				TRS.copy(CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID), in_node, "LINE_ID");
				TRS.copy(CWIPLAMRCP.RES_ID, sizeof(CWIPLAMRCP.RES_ID), Tran_List[inx], "RES_ID");
				TRS.copy(CWIPLAMRCP.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD), Tran_List[inx], "CHMB_CD");
				TRS.copy(CWIPLAMRCP.CHMB_ATTR, sizeof(CWIPLAMRCP.CHMB_ATTR), Tran_List[inx], "CHMB_ATTR");
				CWIPLAMRCP.ATTR_VAL = TRS.get_double(Tran_List[inx], "ATTR_VAL");
				TRS.copy(CWIPLAMRCP.UPDATE_USER_ID, sizeof(CWIPLAMRCP.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(CWIPLAMRCP.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));

				CDB_update_cwiplamrcp(1, &CWIPLAMRCP);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "CWIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPLAMRCP UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLAMRCP.FACTORY), CWIPLAMRCP.FACTORY);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLAMRCP.WORK_DATE), CWIPLAMRCP.WORK_DATE);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMRCP.LINE_ID), CWIPLAMRCP.LINE_ID);
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMRCP.RES_ID), CWIPLAMRCP.RES_ID);
					TRS.add_fieldmsg(out_node, "CHMB_CD", MP_STR, sizeof(CWIPLAMRCP.CHMB_CD), CWIPLAMRCP.CHMB_CD);
					TRS.add_fieldmsg(out_node, "CHMB_ATTR", MP_STR, sizeof(CWIPLAMRCP.CHMB_ATTR), CWIPLAMRCP.CHMB_ATTR);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
		for(inx = 0; inx < i_tran_count; inx++)
		{
			CDB_init_cwiplamrcp(&CWIPLAMRCP);
			TRS.copy(CWIPLAMRCP.FACTORY, sizeof(CWIPLAMRCP.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPLAMRCP.WORK_DATE, sizeof(CWIPLAMRCP.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(CWIPLAMRCP.LINE_ID, sizeof(CWIPLAMRCP.LINE_ID), in_node, "LINE_ID");
			TRS.copy(CWIPLAMRCP.RES_ID, sizeof(CWIPLAMRCP.RES_ID), Tran_List[inx], "RES_ID");
			TRS.copy(CWIPLAMRCP.CHMB_CD, sizeof(CWIPLAMRCP.CHMB_CD), Tran_List[inx], "CHMB_CD");
			TRS.copy(CWIPLAMRCP.CHMB_ATTR, sizeof(CWIPLAMRCP.CHMB_ATTR), Tran_List[inx], "CHMB_ATTR");
			CDB_delete_cwiplamrcp(1, &CWIPLAMRCP);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "CWIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLAMRCP DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLAMRCP.FACTORY), CWIPLAMRCP.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPLAMRCP.WORK_DATE), CWIPLAMRCP.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPLAMRCP.LINE_ID), CWIPLAMRCP.LINE_ID);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPLAMRCP.RES_ID), CWIPLAMRCP.RES_ID);
				TRS.add_fieldmsg(out_node, "CHMB_CD", MP_STR, sizeof(CWIPLAMRCP.CHMB_CD), CWIPLAMRCP.CHMB_CD);
				TRS.add_fieldmsg(out_node, "CHMB_ATTR", MP_STR, sizeof(CWIPLAMRCP.CHMB_ATTR), CWIPLAMRCP.CHMB_ATTR);
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
    CWIP_Update_Laminator_Recipe_Validation()
        - Main sub function of "CWIP_UPDATE_LAMINATOR_RECIPE" function
        - Check the condition for create/update/delete Laminator_Recipe
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Laminator_Recipe_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	int i_tran_count;
    int inx;
    TRSNode ** Tran_List;
    struct CWIPLAMRCP_TAG CWIPLAMRCP;
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

    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

	for(inx = 0; inx < i_tran_count; inx++)
	{
		/* RES_ID Validation */
		if(COM_isnullspace(TRS.get_string(Tran_List[inx], "RES_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "CWIP-0001");
			TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		if(COM_isnullspace(TRS.get_string(Tran_List[inx], "CHMB_CD")) == MP_TRUE)
		{
			strcpy(s_msg_code, "CWIP-0001");
			TRS.add_fieldmsg(out_node, "CHMB_CD", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/* CHMB_ATTR Validation */
		if(COM_isnullspace(TRS.get_string(Tran_List[inx], "CHMB_ATTR")) == MP_TRUE)
		{
			strcpy(s_msg_code, "CWIP-0001");
			TRS.add_fieldmsg(out_node, "CHMB_ATTR", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		 
	}
    return MP_TRUE;
}

