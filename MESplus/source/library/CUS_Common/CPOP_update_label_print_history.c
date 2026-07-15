/******************************************************************************'

	System      : MESplus
	Module      : CPOP
	File Name   : CPOP_update_label_print_history.c
	Description : Update Label Print History

    MES Version : 5.3.6.4

	Function List  
		- CPOP_Update_Label_Print_History()
			+ Update Label Print History
		- CPOP_UPDATE_LABEL_PRINT_HISTORY()
			+ Main sub function of CPOP_Update_Label_Print_History function
			+ Update Label Print History
		- CPOP_Update_Label_Print_History_Validation()
			+ Main sub function of CPOP_UPDATE_LABEL_PRINT_HISTORY function
			+ Check the condition for Update Label Print History
	Detail Description
		- CPOP_UPDATE_LABEL_PRINT_HISTORY()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CPOP_Update_Label_Print_History_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CPOP_Update_Label_Print_History()
		- Update Label Print History
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPOP_Update_Label_Print_History(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CPOP_UPDATE_LABEL_PRINT_HISTORY(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CPOP_UPDATE_LABEL_PRINT_HISTORY", out_node);

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
	CPOP_UPDATE_LABEL_PRINT_HISTORY()
		- Main sub function of "CPOP_Update_Label_Print_History" function
		- Update Label Print History
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPOP_UPDATE_LABEL_PRINT_HISTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CPOPLBLHIS_TAG CPOPLBLHIS;
    struct MWIPELTSTS_TAG MWIPELTSTS;

    char s_sys_time[14];

    LOG_head("CPOP_UPDATE_LABEL_PRINT_HISTORY");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
    
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

    /*
        Step 1. Power Label
        Step 2. Module Label ( Frame Label )
        Step 3. Backsheet Label
    */

    if(CPOP_Update_Label_Print_History_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Lot Information */
	CDB_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");

    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {

        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0044");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

    }

	/* Power and Grade */
	CDB_init_mwipeltsts(&MWIPELTSTS);
	TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");

	CDB_select_mwipeltsts(2,&MWIPELTSTS);
	if(DB_error_code != DB_SUCCESS)
    {

        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0573");
            TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

    }

    /* Label History */
	CDB_init_cpoplblhis(&CPOPLBLHIS);
    
    if (TRS.get_procstep(in_node) == '1')
    {
	    memcpy(CPOPLBLHIS.LABEL_ID, HQCEL_M1_LABEL_TYPE_POWER, strlen(HQCEL_M1_LABEL_TYPE_POWER));
    }
    else if (TRS.get_procstep(in_node) == '2')
    {
	    memcpy(CPOPLBLHIS.LABEL_ID, HQCEL_M1_LABEL_TYPE_LOT, strlen(HQCEL_M1_LABEL_TYPE_LOT));
    }
    else if (TRS.get_procstep(in_node) == '3')
    {
	    memcpy(CPOPLBLHIS.LABEL_ID, HQCEL_M1_LABEL_TYPE_BACKSHEET, strlen(HQCEL_M1_LABEL_TYPE_BACKSHEET));
    }
    else
    {
        return MP_FALSE;
    }

	TRS.copy(CPOPLBLHIS.PRINTED_ID, sizeof(CPOPLBLHIS.PRINTED_ID), in_node, "LOT_ID");
	if (CDB_select_cpoplblhis_scalar(1, &CPOPLBLHIS) > 0)
	{
		/* Insert */
		CPOPLBLHIS.PRINT_QTY = 1;
		memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		memcpy(CPOPLBLHIS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		memcpy(CPOPLBLHIS.OPERATION, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		memcpy(CPOPLBLHIS.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		memcpy(CPOPLBLHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		CPOPLBLHIS.PRINTED_TYPE = 'M'; /* User */
        memcpy(CPOPLBLHIS.DATA_6, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
        memcpy(CPOPLBLHIS.DATA_7, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));

		memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CPOPLBLHIS.TRAN_USER_ID, sizeof(CPOPLBLHIS.TRAN_USER_ID), in_node, IN_USERID);
		memcpy(CPOPLBLHIS.DATA_20, "ERROR", strlen("ERROR"));

		CDB_insert_cpoplblhis(&CPOPLBLHIS);
		if(DB_error_code == DB_SUCCESS)
		{
    		DB_commit();
		}

		strcpy(s_msg_code, "POP-0002");
        TRS.add_fieldmsg(out_node, "CPOPLBLHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LABEL_ID", MP_STR, sizeof(CPOPLBLHIS.LABEL_ID), CPOPLBLHIS.LABEL_ID);
        TRS.add_fieldmsg(out_node, "PRINTED_ID", MP_STR, sizeof(CPOPLBLHIS.PRINTED_ID), CPOPLBLHIS.PRINTED_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	/* Insert */
	CPOPLBLHIS.PRINT_QTY = 1;
	memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	memcpy(CPOPLBLHIS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
	memcpy(CPOPLBLHIS.OPERATION, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
	memcpy(CPOPLBLHIS.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(CPOPLBLHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
	CPOPLBLHIS.PRINTED_TYPE = 'M'; /* User */
    memcpy(CPOPLBLHIS.DATA_6, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
    memcpy(CPOPLBLHIS.DATA_7, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));

	memcpy(CPOPLBLHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	TRS.copy(CPOPLBLHIS.TRAN_USER_ID, sizeof(CPOPLBLHIS.TRAN_USER_ID), in_node, IN_USERID);

	CDB_insert_cpoplblhis(&CPOPLBLHIS);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "POP-0004");
        TRS.add_fieldmsg(out_node, "CPOPLBLHIS INSERT", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CPOP_Update_Label_Print_History_Validation()
		- Main sub function of "CPOP_UPDATE_LABEL_PRINT_HISTORY" function
		- Check the condition for Update Label Print History
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CPOP_Update_Label_Print_History_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123") == MP_FALSE)
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