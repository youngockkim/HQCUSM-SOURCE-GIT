/******************************************************************************'

	System      : MESplus
	Module      : CMDM
	File Name   : CMDM_view_xlink_data_list.c
	Description : View XLink Data List

    MES Version : 5.3.6.4

	Function List  
		- CMDM_View_XLink_Data_List()
			+ View XLink Data List
		- CMDM_VIEW_XLINK_DATA_LIST()
			+ Main sub function of CMDM_View_XLink_Data_List function
			+ View XLink Data List definition
		- CMDM_View_XLink_Data_List_Validation()
			+ Main sub function of CMDM_VIEW_XLINK_DATA_LIST function
			+ Check the condition for View XLink Data List
	Detail Description
		- CMDM_VIEW_XLINK_DATA_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMDM_View_XLink_Data_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CMDM_View_XLink_Data_List()
		- View XLink Data List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_View_XLink_Data_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CMDM_VIEW_XLINK_DATA_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CMDM_VIEW_XLINK_DATA_LIST", out_node);

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
	CMDM_VIEW_XLINK_DATA_LIST()
		- Main sub function of "CMDM_View_XLink_Data_List" function
		- View XLink Data List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_VIEW_XLINK_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CMDMXLKDAT_TAG CMDMXLKDAT;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;

    TRSNode *list_item;
    int i_step;

    LOG_head("CMDM_VIEW_XLINK_DATA_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CMDM_View_XLink_Data_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

    CDB_init_cmdmxlkdat(&CMDMXLKDAT);
    TRS.copy(CMDMXLKDAT.FACTORY, sizeof(CMDMXLKDAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMDMXLKDAT.CW, sizeof(CMDMXLKDAT.CW), in_node, "CW");
    TRS.copy(CMDMXLKDAT.MAT_ID, sizeof(CMDMXLKDAT.MAT_ID), in_node, "MAT_ID");
    TRS.copy(CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO), in_node, "MACHINE_NO");
    TRS.copy(CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION), in_node, "POSITION");
    TRS.copy(CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE), in_node, "MEASURE_TYPE");

    CDB_open_cmdmxlkdat(i_step, &CMDMXLKDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MDM-0004");
        TRS.add_fieldmsg(out_node, "CMDMXLKDAT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
        TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CMDMXLKDAT.MAT_ID), CMDMXLKDAT.MAT_ID);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
        TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
        TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
        TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cmdmxlkdat(i_step, &CMDMXLKDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmdmxlkdat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MDM-0004");
            TRS.add_fieldmsg(out_node, "CMDMXLKDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CMDMXLKDAT.MAT_ID), CMDMXLKDAT.MAT_ID);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
            TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
            TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
            TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_cmdmxlkdat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        
        DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPMATDEF.MAT_ID, CMDMXLKDAT.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
        MWIPMATDEF.MAT_VER = 1;

	    DBC_select_mwipmatdef(1, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {
                /*
			    strcpy(s_msg_code, "WIP-0006");
                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);

			    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
                */
		    }
            else
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
        memcpy(MGCMTBLDAT.KEY_1, CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID));

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
        
        TRS.add_string(list_item, "FACTORY", CMDMXLKDAT.FACTORY, sizeof(CMDMXLKDAT.FACTORY));
        TRS.add_string(list_item, "CW", CMDMXLKDAT.CW, sizeof(CMDMXLKDAT.CW));
        TRS.add_string(list_item, "LOT_ID", CMDMXLKDAT.LOT_ID, sizeof(CMDMXLKDAT.LOT_ID));
        TRS.add_string(list_item, "MAT_ID", CMDMXLKDAT.MAT_ID, sizeof(CMDMXLKDAT.MAT_ID));
        TRS.add_string(list_item, "LINE_ID", CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID));
        TRS.add_string(list_item, "MACHINE_NO", CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO));
        TRS.add_string(list_item, "POSITION", CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION));
        TRS.add_string(list_item, "MEASURE_TYPE", CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE));
        TRS.add_string(list_item, "X_LINK_TEST_DATE", CMDMXLKDAT.X_LINK_TEST_DATE, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE));
        TRS.add_string(list_item, "X_LINK_TEST_START_TIME", CMDMXLKDAT.X_LINK_TEST_START_TIME, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME));
        TRS.add_string(list_item, "LAMI_DATE", CMDMXLKDAT.LAMI_DATE, sizeof(CMDMXLKDAT.LAMI_DATE));
        TRS.add_string(list_item, "LAMI_END_TIME", CMDMXLKDAT.LAMI_END_TIME, sizeof(CMDMXLKDAT.LAMI_END_TIME));
        TRS.add_string(list_item, "BS_TYPE", CMDMXLKDAT.BS_TYPE, sizeof(CMDMXLKDAT.BS_TYPE));
        TRS.add_string(list_item, "BS_BATCH_NO", CMDMXLKDAT.BS_BATCH_NO, sizeof(CMDMXLKDAT.BS_BATCH_NO));
        TRS.add_string(list_item, "EVA_TYPE", CMDMXLKDAT.EVA_TYPE, sizeof(CMDMXLKDAT.EVA_TYPE));
        TRS.add_string(list_item, "EVA_BATCH_NO", CMDMXLKDAT.EVA_BATCH_NO, sizeof(CMDMXLKDAT.EVA_BATCH_NO));
        TRS.add_string(list_item, "LAMI_RECIPE", CMDMXLKDAT.LAMI_RECIPE, sizeof(CMDMXLKDAT.LAMI_RECIPE));
        TRS.add_string(list_item, "REPEAT_MEASURE_NO", CMDMXLKDAT.REPEAT_MEASURE_NO, sizeof(CMDMXLKDAT.REPEAT_MEASURE_NO));
        TRS.add_string(list_item, "CORRELATION_FILE", CMDMXLKDAT.CORRELATION_FILE, sizeof(CMDMXLKDAT.CORRELATION_FILE));

        TRS.add_double(list_item, "LXM_X1_Y1", CMDMXLKDAT.LXM_X1_Y1);
        TRS.add_double(list_item, "LXM_X1_Y2", CMDMXLKDAT.LXM_X1_Y2);
        TRS.add_double(list_item, "LXM_X2_Y1", CMDMXLKDAT.LXM_X2_Y1);
        TRS.add_double(list_item, "LXM_X2_Y2", CMDMXLKDAT.LXM_X2_Y2);
        TRS.add_double(list_item, "LXM_X3_Y1", CMDMXLKDAT.LXM_X3_Y1);
        TRS.add_double(list_item, "LXM_X3_Y2", CMDMXLKDAT.LXM_X3_Y2);
        TRS.add_double(list_item, "LXM_X4_Y1", CMDMXLKDAT.LXM_X4_Y1);
        TRS.add_double(list_item, "LXM_X4_Y2", CMDMXLKDAT.LXM_X4_Y2);
        TRS.add_double(list_item, "LXM_X5_Y1", CMDMXLKDAT.LXM_X5_Y1);
        TRS.add_double(list_item, "LXM_X5_Y2", CMDMXLKDAT.LXM_X5_Y2);

        TRS.add_double(list_item, "GC_X1_Y1", CMDMXLKDAT.GC_X1_Y1);
        TRS.add_double(list_item, "GC_X1_Y2", CMDMXLKDAT.GC_X1_Y2);
        TRS.add_double(list_item, "GC_X2_Y1", CMDMXLKDAT.GC_X2_Y1);
        TRS.add_double(list_item, "GC_X2_Y2", CMDMXLKDAT.GC_X2_Y2);
        TRS.add_double(list_item, "GC_X3_Y1", CMDMXLKDAT.GC_X3_Y1);
        TRS.add_double(list_item, "GC_X3_Y2", CMDMXLKDAT.GC_X3_Y2);
        TRS.add_double(list_item, "GC_X4_Y1", CMDMXLKDAT.GC_X4_Y1);
        TRS.add_double(list_item, "GC_X4_Y2", CMDMXLKDAT.GC_X4_Y2);
        TRS.add_double(list_item, "GC_X5_Y1", CMDMXLKDAT.GC_X5_Y1);
        TRS.add_double(list_item, "GC_X5_Y2", CMDMXLKDAT.GC_X5_Y2);

        TRS.add_string(list_item, "DATA_COMMENT", CMDMXLKDAT.DATA_COMMENT, sizeof(CMDMXLKDAT.DATA_COMMENT));
        TRS.add_string(list_item, "CREATE_USER_ID", CMDMXLKDAT.CREATE_USER_ID, sizeof(CMDMXLKDAT.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMDMXLKDAT.CREATE_TIME, sizeof(CMDMXLKDAT.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMDMXLKDAT.UPDATE_USER_ID, sizeof(CMDMXLKDAT.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMDMXLKDAT.UPDATE_TIME, sizeof(CMDMXLKDAT.UPDATE_TIME));

        TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
        TRS.add_string(list_item, "LINE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CMDM_View_XLink_Data_List_Validation()
		- Main sub function of "CMDM_VIEW_XLINK_DATA_LIST" function
		- Check the condition for View XLink Data List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_View_XLink_Data_List_Validation(char *s_msg_code,
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