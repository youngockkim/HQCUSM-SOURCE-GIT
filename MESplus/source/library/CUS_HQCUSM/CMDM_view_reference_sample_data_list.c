/******************************************************************************'

	System      : MESplus
	Module      : CMDM
	File Name   : CMDM_view_reference_sample_data_list.c
	Description : View Reference Sample Data List

    MES Version : 5.3.6.4

	Function List  
		- CMDM_View_Reference_Sample_Data_List()
			+ View Reference Sample Data List
		- CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST()
			+ Main sub function of CMDM_View_Reference_Sample_Data_List function
			+ View Reference Sample Data List definition
		- CMDM_View_Reference_Sample_Data_List_Validation()
			+ Main sub function of CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST function
			+ Check the condition for View Reference Sample Data List
	Detail Description
		- CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMDM_View_Reference_Sample_Data_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CMDM_View_Reference_Sample_Data_List()
		- View Reference Sample Data List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_View_Reference_Sample_Data_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST", out_node);

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
	CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST()
		- Main sub function of "CMDM_View_Reference_Sample_Data_List" function
		- View Reference Sample Data List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CMDMREFDAT_TAG CMDMREFDAT;

    TRSNode *list_item;
    int i_step;

    LOG_head("CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CMDM_View_Reference_Sample_Data_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if (TRS.get_procstep(in_node) == '1')
    {
        i_step = 2;
    }
    else
    {
        i_step = 0;
    }

	DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE), in_node, "FROM_DATE");
    TRS.copy(DBC_Q_COND.TO_DATE, sizeof(DBC_Q_COND.TO_DATE), in_node, "TO_DATE");
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

    CDB_init_cmdmrefdat(&CMDMREFDAT);
    TRS.copy(CMDMREFDAT.FACTORY, sizeof(CMDMREFDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMDMREFDAT.CW, sizeof(CMDMREFDAT.CW), in_node, "CW");
    TRS.copy(CMDMREFDAT.X_LINK_NO, sizeof(CMDMREFDAT.X_LINK_NO), in_node, "X_LINK_NO");
    TRS.copy(CMDMREFDAT.TEST_DATE, sizeof(CMDMREFDAT.TEST_DATE), in_node, "TEST_DATE");

    CDB_open_cmdmrefdat(i_step, &CMDMREFDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MDM-0004");
        TRS.add_fieldmsg(out_node, "CMDMREFDAT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
        TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
        TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
        TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);

        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cmdmrefdat(i_step, &CMDMREFDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmdmrefdat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MDM-0004");
            TRS.add_fieldmsg(out_node, "CMDMREFDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
            TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
            TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_cmdmrefdat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "DATA_LIST");
        
        TRS.add_string(list_item, "FACTORY", CMDMREFDAT.FACTORY, sizeof(CMDMREFDAT.FACTORY));
        TRS.add_string(list_item, "CW", CMDMREFDAT.CW, sizeof(CMDMREFDAT.CW));
        TRS.add_string(list_item, "X_LINK_NO", CMDMREFDAT.X_LINK_NO, sizeof(CMDMREFDAT.X_LINK_NO));
        TRS.add_string(list_item, "TEST_DATE", CMDMREFDAT.TEST_DATE, sizeof(CMDMREFDAT.TEST_DATE));

        TRS.add_double(list_item, "POINT1_LXM", CMDMREFDAT.POINT1_LXM);
        TRS.add_double(list_item, "POINT1_GC", CMDMREFDAT.POINT1_GC);
        TRS.add_double(list_item, "POINT2_LXM", CMDMREFDAT.POINT2_LXM);
        TRS.add_double(list_item, "POINT2_GC", CMDMREFDAT.POINT2_GC);

        TRS.add_string(list_item, "DATA_COMMENT", CMDMREFDAT.DATA_COMMENT, sizeof(CMDMREFDAT.DATA_COMMENT));
        TRS.add_string(list_item, "CREATE_USER_ID", CMDMREFDAT.CREATE_USER_ID, sizeof(CMDMREFDAT.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMDMREFDAT.CREATE_TIME, sizeof(CMDMREFDAT.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMDMREFDAT.UPDATE_USER_ID, sizeof(CMDMREFDAT.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMDMREFDAT.UPDATE_TIME, sizeof(CMDMREFDAT.UPDATE_TIME));

    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CMDM_View_Reference_Sample_Data_List_Validation()
		- Main sub function of "CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST" function
		- Check the condition for View Reference Sample Data List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_View_Reference_Sample_Data_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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


    return MP_TRUE;
}