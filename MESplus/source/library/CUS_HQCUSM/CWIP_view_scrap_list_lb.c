/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_scrap_list.c
	Description : View Scrap List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Scrap_List_Lb()
			+ View Scrap List
		- CWIP_VIEW_SCRAP_LIST_LB()
			+ Main sub function of CWIP_View_Scrap_List_Lb function
			+ View Scrap List definition
		- CWIP_View_Scrap_List_Lb_Validation()
			+ Main sub function of CWIP_VIEW_SCRAP_LIST_Lb function
			+ Check the condition for View Scrap List
	Detail Description
		- CWIP_VIEW_SCRAP_LIST_LB()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Scrap_List_Lb_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Scrap_List_Lb()
		- View Scrap List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Scrap_List_Lb(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_SCRAP_LIST_LB(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_SCRAP_LIST_LB", out_node);

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
	CWIP_VIEW_SCRAP_LIST_LB()
		- Main sub function of "CWIP_View_Scrap_List_Lb" function
		- View Scrap List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_SCRAP_LIST_LB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct RSUMWIPLOS_TAG RSUMWIPLOS;
    struct MWIPOPRDEF_TAG MWIPOPRDEF;
    struct MRASRESDEF_TAG MRASRESDEF;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;

    TRSNode *list_item;
    int i_step;
	
	//double ret_cmf1 = 0;

    LOG_head("CWIP_VIEW_SCRAP_LIST_LB");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Scrap List
    */

    if(CWIP_View_Scrap_List_Lb_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_step = 3;
	
    CDB_init_rsumwiplos(&RSUMWIPLOS);
    TRS.copy(RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(RSUMWIPLOS.CM_KEY_1, sizeof(RSUMWIPLOS.CM_KEY_1), in_node, "LINE_ID");
    TRS.copy(RSUMWIPLOS.CM_KEY_2, sizeof(RSUMWIPLOS.CM_KEY_2), in_node, "WORK_SHIFT");
  	TRS.copy(RSUMWIPLOS.CMF_4, strlen("99991231"), in_node, "FROM_DATE");
    TRS.copy(RSUMWIPLOS.CMF_5, strlen("99991231"), in_node, "TO_DATE");

	if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
	{
		memcpy(RSUMWIPLOS.MAT_ID, "%", strlen("%"));

	}
	else
	{
		TRS.copy(RSUMWIPLOS.MAT_ID, sizeof(RSUMWIPLOS.MAT_ID), in_node, "MAT_ID"); 
	}

    CDB_open_rsumwiplos(i_step, &RSUMWIPLOS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "RSUMWIPLOS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_rsumwiplos(i_step, &RSUMWIPLOS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_rsumwiplos(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "RSUMWIPLOS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_rsumwiplos(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }


        DBC_init_mwipoprdef(&MWIPOPRDEF);
        TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPOPRDEF.OPER, RSUMWIPLOS.LOSS_OPER, sizeof(MWIPOPRDEF.OPER));
            
        DBC_select_mwipoprdef(1, &MWIPOPRDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }

        DBC_init_mrasresdef(&MRASRESDEF);
        TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MRASRESDEF.RES_ID, RSUMWIPLOS.RES_ID, sizeof(MRASRESDEF.RES_ID));
            
        DBC_select_mrasresdef(1, &MRASRESDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }

		DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPMATDEF.MAT_ID, RSUMWIPLOS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATDEF.MAT_VER = 1;
        DBC_select_mwipmatdef(1, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }

        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_TERMINATE_CAUSE, strlen(HQCEL_M1_GCM_TERMINATE_CAUSE));
        memcpy(MGCMTBLDAT.KEY_1, RSUMWIPLOS.CM_KEY_3, sizeof(MGCMTBLDAT.KEY_1));

	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "SCRAP_LIST");
        TRS.add_string(list_item, "WORK_DATE", RSUMWIPLOS.WORK_DATE, sizeof(RSUMWIPLOS.WORK_DATE));
        TRS.add_string(list_item, "FACTORY", RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY));
        TRS.add_string(list_item, "RES_ID", RSUMWIPLOS.RES_ID, sizeof(RSUMWIPLOS.RES_ID));
        TRS.add_string(list_item, "MAT_ID", RSUMWIPLOS.MAT_ID, sizeof(RSUMWIPLOS.MAT_ID));
        TRS.add_int(list_item, "MAT_VER", RSUMWIPLOS.MAT_VER);
        TRS.add_string(list_item, "FLOW", RSUMWIPLOS.FLOW, sizeof(RSUMWIPLOS.FLOW));
        TRS.add_int(list_item, "FLOW_SEQ_NUM", RSUMWIPLOS.FLOW_SEQ_NUM);
        TRS.add_string(list_item, "LOSS_OPER", RSUMWIPLOS.LOSS_OPER, sizeof(RSUMWIPLOS.LOSS_OPER));
        TRS.add_string(list_item, "LOT_TYPE", RSUMWIPLOS.LOT_TYPE, sizeof(RSUMWIPLOS.LOT_TYPE));
        TRS.add_string(list_item, "CM_KEY_1", RSUMWIPLOS.CM_KEY_1, sizeof(RSUMWIPLOS.CM_KEY_1));
        TRS.add_string(list_item, "CM_KEY_2", RSUMWIPLOS.CM_KEY_2, sizeof(RSUMWIPLOS.CM_KEY_2));
        TRS.add_string(list_item, "CM_KEY_3", RSUMWIPLOS.CM_KEY_3, sizeof(RSUMWIPLOS.CM_KEY_3));
        TRS.add_string(list_item, "CM_KEY_4", RSUMWIPLOS.CM_KEY_4, sizeof(RSUMWIPLOS.CM_KEY_4));
        TRS.add_string(list_item, "CM_KEY_5", RSUMWIPLOS.CM_KEY_5, sizeof(RSUMWIPLOS.CM_KEY_5));
        TRS.add_string(list_item, "LOSS_CODE", RSUMWIPLOS.LOSS_CODE, sizeof(RSUMWIPLOS.LOSS_CODE));
        TRS.add_double(list_item, "LOSS_QTY", RSUMWIPLOS.LOSS_QTY);
        TRS.add_string(list_item, "LOSS_TYPE", RSUMWIPLOS.LOSS_TYPE, sizeof(RSUMWIPLOS.LOSS_TYPE));
        TRS.add_string(list_item, "LOSS_GROUP", RSUMWIPLOS.LOSS_GROUP, sizeof(RSUMWIPLOS.LOSS_GROUP));
        TRS.add_string(list_item, "LOSS_COMMENT", RSUMWIPLOS.LOSS_COMMENT, sizeof(RSUMWIPLOS.LOSS_COMMENT));
        TRS.add_string(list_item, "ORDER_ID", RSUMWIPLOS.ORDER_ID, sizeof(RSUMWIPLOS.ORDER_ID));
        TRS.add_string(list_item, "CMF_2", RSUMWIPLOS.CMF_2, sizeof(RSUMWIPLOS.CMF_2));
        TRS.add_string(list_item, "CMF_3", RSUMWIPLOS.CMF_3, sizeof(RSUMWIPLOS.CMF_3));
        TRS.add_string(list_item, "CMF_4", RSUMWIPLOS.CMF_4, sizeof(RSUMWIPLOS.CMF_4));
        TRS.add_string(list_item, "CMF_5", RSUMWIPLOS.CMF_5, sizeof(RSUMWIPLOS.CMF_5));
        TRS.add_string(list_item, "LINE_ID", RSUMWIPLOS.LINE_ID, sizeof(RSUMWIPLOS.LINE_ID));
        TRS.add_string(list_item, "WORK_SHIFT", RSUMWIPLOS.WORK_SHIFT, sizeof(RSUMWIPLOS.WORK_SHIFT));
        TRS.add_string(list_item, "WORK_MONTH", RSUMWIPLOS.WORK_MONTH, sizeof(RSUMWIPLOS.WORK_MONTH));
        TRS.add_string(list_item, "WORK_WEEK", RSUMWIPLOS.WORK_WEEK, sizeof(RSUMWIPLOS.WORK_WEEK));
        TRS.add_string(list_item, "WORK_DAYS", RSUMWIPLOS.WORK_DAYS, sizeof(RSUMWIPLOS.WORK_DAYS));
        TRS.add_string(list_item, "WORK_DAY_OF_WEEK", RSUMWIPLOS.WORK_DAY_OF_WEEK, sizeof(RSUMWIPLOS.WORK_DAY_OF_WEEK));
        TRS.add_string(list_item, "CREATE_USER_ID", RSUMWIPLOS.CREATE_USER_ID, sizeof(RSUMWIPLOS.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", RSUMWIPLOS.CREATE_TIME, sizeof(RSUMWIPLOS.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", RSUMWIPLOS.UPDATE_USER_ID, sizeof(RSUMWIPLOS.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", RSUMWIPLOS.UPDATE_TIME, sizeof(RSUMWIPLOS.UPDATE_TIME));
		TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
        TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));
        TRS.add_string(list_item, "CAUSE_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
				
		TRS.add_string(list_item, "LOSS_LB", RSUMWIPLOS.CMF_1, sizeof(RSUMWIPLOS.CMF_1));

    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Scrap_List_Lb_Validation()
		- Main sub function of "CWIP_VIEW_SCRAP_LIST" function
		- Check the condition for View Scrap List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Scrap_List_Lb_Validation(char *s_msg_code,
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