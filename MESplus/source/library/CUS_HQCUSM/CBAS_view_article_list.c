/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CBAS_view_article_list.c
	Description : View Order BOM List Information

    MES Version : 5.3.6.4

	Function List  
		- CBAS_view_article_list()
			+ View Lot
		- CBAS_view_article_list()
			+ Main sub function of CBAS_view_article_list function
			+ View Order BOM definition
		- CBAS_view_article_list_Validation()
			+ Main sub function of CBAS_view_article_list function
			+ Check the condition for view Order BOM List
	Detail Description
		- CBAS_view_article_list()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CBAS_view_article_list_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CBAS_view_article_list()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_view_article_list(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CBAS_VIEW_ARTICLE_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CBAS_view_article_list", out_node);

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
	CBAS_view_article_list()
		- Main sub function of "CBAS_view_article_list" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_VIEW_ARTICLE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MGCMLAGDAT_TAG MGCMLAGDAT;

    int i_step;
	int len;

    LOG_head("CBAS_view_article_list");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CBAS_view_article_list_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Order BOM List by Factory and Order ID */
    
    DBC_init_mgcmlagdat(&MGCMLAGDAT);
    TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MGCMLAGDAT.TABLE_NAME, sizeof(MGCMLAGDAT.TABLE_NAME), in_node, "TABLE_NAME");
	TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "KEY_1");	
	TRS.copy(MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1), in_node, "DATA_1");
	TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "DATA_2");
	
	
	len =  strlen(TRS.get_string(in_node,"DATA_1"));

	if(len == 2)
	{
		memcpy(MGCMLAGDAT.DATA_1, strcat("0", TRS.get_string(in_node,"DATA_1")), sizeof(MGCMLAGDAT.DATA_1));
	}
	else
	{
		memcpy(MGCMLAGDAT.DATA_1, MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
	}

	i_step = 103;


	DBC_open_mgcmlagdat(i_step,&MGCMLAGDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
            strcpy(s_msg_code, "BOM-0042");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);

            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    while(1) 
    {
        DBC_fetch_mgcmlagdat(i_step, &MGCMLAGDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mgcmlagdat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        { 
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mgcmlagdat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		       
        /* Construct out node */

		TRS.add_string(out_node, "KEY_1", MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1));
        TRS.add_string(out_node, "KEY_2", MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2));
		TRS.add_string(out_node, "DATA_1", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
		TRS.add_string(out_node, "DATA_2", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
		TRS.add_string(out_node, "DATA_3", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));
		TRS.add_string(out_node, "DATA_4", MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));
		TRS.add_string(out_node, "DATA_5", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));
		
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CBAS_view_article_list_Validation()
		- Main sub function of "CBAS_view_article_list" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_view_article_list_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
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


    return MP_TRUE;
}