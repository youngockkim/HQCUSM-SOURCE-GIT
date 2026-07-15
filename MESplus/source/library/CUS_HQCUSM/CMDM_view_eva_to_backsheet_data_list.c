/******************************************************************************'

	System      : MESplus
	Module      : CMDM
	File Name   : CMDM_view_eva_to_backsheet_data_list.c
	Description : View EVA to Backsheet Data List

    MES Version : 5.3.6.4

	Function List  
		- CMDM_View_EVA_To_Backsheet_Data_List()
			+ View EVA to Backsheet Data List
		- CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST()
			+ Main sub function of CMDM_View_EVA_To_Backsheet_Data_List function
			+ View EVA to Backsheet Data List definition
		- CMDM_View_EVA_To_Backsheet_Data_List_Validation()
			+ Main sub function of CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST function
			+ Check the condition for View EVA to Backsheet Data List
	Detail Description
		- CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMDM_View_EVA_To_Backsheet_Data_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CMDM_View_EVA_To_Backsheet_Data_List()
		- View EVA to Backsheet Data List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_View_EVA_To_Backsheet_Data_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST", out_node);

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
	CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST()
		- Main sub function of "CMDM_View_EVA_To_Backsheet_Data_List" function
		- View EVA to Backsheet Data List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CMDMETBDAT_TAG CMDMETBDAT;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;

    TRSNode *list_item;
    int i_step;

    LOG_head("CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CMDM_View_EVA_To_Backsheet_Data_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

    CDB_init_cmdmetbdat(&CMDMETBDAT);
    TRS.copy(CMDMETBDAT.FACTORY, sizeof(CMDMETBDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMDMETBDAT.CW, sizeof(CMDMETBDAT.CW), in_node, "CW");
    TRS.copy(CMDMETBDAT.SAMPLING_DATE, sizeof(CMDMETBDAT.SAMPLING_DATE), in_node, "SAMPLING_DATE");
    TRS.copy(CMDMETBDAT.TEST_DATE, sizeof(CMDMETBDAT.TEST_DATE), in_node, "TEST_DATE");
    TRS.copy(CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CMDMETBDAT.MACHINE_NO, sizeof(CMDMETBDAT.MACHINE_NO), in_node, "MACHINE_NO");
    TRS.copy(CMDMETBDAT.POSITION, sizeof(CMDMETBDAT.POSITION), in_node, "POSITION");
    TRS.copy(CMDMETBDAT.MEASURE_TYPE, sizeof(CMDMETBDAT.MEASURE_TYPE), in_node, "MEASURE_TYPE");

    CDB_open_cmdmetbdat(i_step, &CMDMETBDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MDM-0004");
        TRS.add_fieldmsg(out_node, "CMDMETBDAT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
        TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
        TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
        TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
        TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
        TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
        TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);

        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cmdmetbdat(i_step, &CMDMETBDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmdmetbdat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MDM-0004");
            TRS.add_fieldmsg(out_node, "CMDMETBDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
            TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
            TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
            TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
            TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
            TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_cmdmetbdat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
        memcpy(MGCMTBLDAT.KEY_1, CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID));

	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {
                /*
			    strcpy(s_msg_code, "GCM-0008");
			    TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
                */
		    }
            else
            {
                strcpy(s_msg_code, "GCM-0007");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "DATA_LIST");
        
        TRS.add_string(list_item, "FACTORY", CMDMETBDAT.FACTORY, sizeof(CMDMETBDAT.FACTORY));
        TRS.add_string(list_item, "CW", CMDMETBDAT.CW, sizeof(CMDMETBDAT.CW));
        TRS.add_string(list_item, "SAMPLING_DATE", CMDMETBDAT.SAMPLING_DATE, sizeof(CMDMETBDAT.SAMPLING_DATE));
        TRS.add_string(list_item, "TEST_DATE", CMDMETBDAT.TEST_DATE, sizeof(CMDMETBDAT.TEST_DATE));
        TRS.add_string(list_item, "LINE_ID", CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID));
        TRS.add_string(list_item, "MACHINE_NO", CMDMETBDAT.MACHINE_NO, sizeof(CMDMETBDAT.MACHINE_NO));
        TRS.add_string(list_item, "POSITION", CMDMETBDAT.POSITION, sizeof(CMDMETBDAT.POSITION));
        TRS.add_string(list_item, "MEASURE_TYPE", CMDMETBDAT.MEASURE_TYPE, sizeof(CMDMETBDAT.MEASURE_TYPE));
        TRS.add_string(list_item, "TYPE_EVA_BACK", CMDMETBDAT.TYPE_EVA_BACK, sizeof(CMDMETBDAT.TYPE_EVA_BACK));
        TRS.add_string(list_item, "GRN_NR_EVA_BACK", CMDMETBDAT.GRN_NR_EVA_BACK, sizeof(CMDMETBDAT.GRN_NR_EVA_BACK));
        TRS.add_string(list_item, "BACKSHEET_TYPE", CMDMETBDAT.BACKSHEET_TYPE, sizeof(CMDMETBDAT.BACKSHEET_TYPE));
        TRS.add_string(list_item, "GRN_NR_BACKSHEET", CMDMETBDAT.GRN_NR_BACKSHEET, sizeof(CMDMETBDAT.GRN_NR_BACKSHEET));
        TRS.add_string(list_item, "REPEAT_MEASURE_NO", CMDMETBDAT.REPEAT_MEASURE_NO, sizeof(CMDMETBDAT.REPEAT_MEASURE_NO));

        TRS.add_double(list_item, "POS_A", CMDMETBDAT.POS_A);
        TRS.add_double(list_item, "POS_B", CMDMETBDAT.POS_B);
        TRS.add_double(list_item, "POS_C", CMDMETBDAT.POS_C);
        TRS.add_double(list_item, "POS_D", CMDMETBDAT.POS_D);
        TRS.add_double(list_item, "POS_E", CMDMETBDAT.POS_E);
        TRS.add_double(list_item, "POS_F", CMDMETBDAT.POS_F);
        TRS.add_double(list_item, "POS_G", CMDMETBDAT.POS_G);
        TRS.add_double(list_item, "POS_H", CMDMETBDAT.POS_H);

        TRS.add_string(list_item, "DATA_COMMENT", CMDMETBDAT.DATA_COMMENT, sizeof(CMDMETBDAT.DATA_COMMENT));
        TRS.add_string(list_item, "CREATE_USER_ID", CMDMETBDAT.CREATE_USER_ID, sizeof(CMDMETBDAT.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMDMETBDAT.CREATE_TIME, sizeof(CMDMETBDAT.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMDMETBDAT.UPDATE_USER_ID, sizeof(CMDMETBDAT.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMDMETBDAT.UPDATE_TIME, sizeof(CMDMETBDAT.UPDATE_TIME));

        TRS.add_string(list_item, "LINE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CMDM_View_EVA_To_Backsheet_Data_List_Validation()
		- Main sub function of "CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST" function
		- Check the condition for View EVA To Glass Data List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_View_EVA_To_Backsheet_Data_List_Validation(char *s_msg_code,
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