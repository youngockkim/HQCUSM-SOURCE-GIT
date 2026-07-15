/******************************************************************************'

	System      : MESplus
	Module      : CORD
	File Name   : CEDC_update_inspection_data.c
	Description : Update inspection data

    MES Version : 5.3.6.4

	Function List  
		- CEDC_Update_Inspection_Data()
			+ Update inspection data
		- CEDC_UPDATE_INSPECTION_DATA()
			+ Main sub function of CEDC_Update_Inspection_Data function
			+ Change Current Order definition
		- CEDC_Update_Inspection_Data_Validation()
			+ Main sub function of CEDC_UPDATE_INSPECTION_DATA function
			+ Check the condition for Update inspection data
	Detail Description
		- CEDC_UPDATE_INSPECTION_DATA()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CEDC_Update_Inspection_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CEDC_Update_Inspection_Data()
		- Change Current Order
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEDC_Update_Inspection_Data(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CEDC_UPDATE_INSPECTION_DATA(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CEDC_UPDATE_INSPECTION_DATA", out_node);

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
	CEDC_UPDATE_INSPECTION_DATA()
		- Main sub function of "CEDC_Update_Inspection_Data" function
		- Change Current Order
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEDC_UPDATE_INSPECTION_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MRASRESDEF_TAG MRASRESDEF;
    struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;

    char s_sys_time[14];

    LOG_head("CEDC_UPDATE_INSPECTION_DATA");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
    
    if(CEDC_Update_Inspection_Data_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

    /* Get Lot Info */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {

        }
        else
        {

        }
    }

    /* Check Resource */
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "RAS-0003");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}


    /* Result */
	CDB_init_cedclotrlt(&CEDCLOTRLT);
    TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLT.INS_TYPE), in_node, "INS_TYPE");
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");

	CDB_select_cedclotrlt(2,&CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
    {
		if(DB_error_code == DB_NOT_FOUND)
		{
			CEDCLOTRLT.INS_CNT = 0;
			memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
			CDB_insert_cedclotrlt(&CEDCLOTRLT);	
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
		else
		{
			strcpy(s_msg_code, "EDC-0004");
			TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
        
    }

    TRS.copy(CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID), in_node, "RES_ID");
    TRS.copy(CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID), in_node, "LINE_ID");

	if (MRASRESDEF.RES_CMF_14[0] == 'Y')
	{
		memcpy(CEDCLOTRLT.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)); //OPER
	}
	else
	{
		memcpy(CEDCLOTRLT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCLOTRLT.OPER));
	}

    TRS.copy(CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));

    TRS.copy(CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE), in_node, "RESULT");
    TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));

    CEDCLOTRLT.TYPE_FLAG = TRS.get_char(in_node, "TYPE_FLAG");
    CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
	memcpy(CEDCLOTRLT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(CEDCLOTRLT.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
	CEDCLOTRLT.QTY = (int) MWIPLOTSTS.QTY_1;
    CEDCLOTRLT.INS_CNT = CEDCLOTRLT.INS_CNT +1;
	memcpy(CEDCLOTRLT.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

    if(CEDCLOTRLT.INS_CNT <= 1)
    {
        memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
    }
	TRS.copy(CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLT.LOC_ID), in_node, "LOC_ID");

	if (memcmp(CEDCLOTRLT.INS_TYPE, HQCEL_LOSS_CATEGORY_TABBER, strlen(HQCEL_LOSS_CATEGORY_TABBER)) == 0)
	{
		CEDCLOTRLT.LOC_ID[0] = CEDCLOTRLT.LOT_ID[2]; 
	}
	//First Not Rework Ins Time ISSUE-09-050_일일보고전산화관련 by kim 20191016
	if (memcmp(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC)) == 0)
	{
		if (memcmp(CEDCLOTRLT.RESULT_VALUE, "RW", strlen("RW")) != 0 && CEDCLOTRLT.CMF_3[0] == ' ')
		{
			memcpy(CEDCLOTRLT.CMF_3, s_sys_time, sizeof(s_sys_time));
		}
	}
	

	CDB_update_cedclotrlt(1, &CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "EDC-0004");
		TRS.set_fieldmsg(out_node, "CEDCLOTRLT UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
        TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	/* History */
    CDB_init_cedclotrlh(&CEDCLOTRLH);

    TRS.copy(CEDCLOTRLH.FACTORY, sizeof(CEDCLOTRLH.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CEDCLOTRLH.INS_TYPE, sizeof(CEDCLOTRLH.INS_TYPE), in_node, "INS_TYPE");
    TRS.copy(CEDCLOTRLH.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID), in_node, "LOT_ID");
	CEDCLOTRLH.INS_CNT = CEDCLOTRLT.INS_CNT;
	//CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.INS_CNT;
    TRS.copy(CEDCLOTRLH.RES_ID, sizeof(CEDCLOTRLH.RES_ID), in_node, "RES_ID");
    TRS.copy(CEDCLOTRLH.LINE_ID, sizeof(CEDCLOTRLH.LINE_ID), in_node, "LINE_ID");

	if (MRASRESDEF.RES_CMF_14[0] == 'Y')
	{
		memcpy(CEDCLOTRLH.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)); //OPER
	}
	else
	{
		memcpy(CEDCLOTRLH.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCLOTRLH.OPER));
	}
                    
    TRS.copy(CEDCLOTRLH.INS_USER_ID, sizeof(CEDCLOTRLH.INS_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLH.INS_TIME, s_sys_time, sizeof(CEDCLOTRLH.INS_TIME));

    TRS.copy(CEDCLOTRLH.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE), in_node, "RESULT");
    TRS.copy(CEDCLOTRLH.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLH.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLH.RESULT_TIME));

    CEDCLOTRLH.TYPE_FLAG = TRS.get_char(in_node, "TYPE_FLAG");

    CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.INS_CNT;
	memcpy(CEDCLOTRLH.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
    memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1)); /* Initial Inspection Time */
	memcpy(CEDCLOTRLH.CMF_2, CEDCLOTRLT.CMF_2, sizeof(CEDCLOTRLH.CMF_2)); /* Initial Inspection Time */
	memcpy(CEDCLOTRLH.CMF_3, CEDCLOTRLT.CMF_3, sizeof(CEDCLOTRLH.CMF_3)); /* Initial Inspection Time */
	memcpy(CEDCLOTRLH.CMF_4, CEDCLOTRLT.CMF_4, sizeof(CEDCLOTRLH.CMF_4)); /* Initial Inspection Time */
	memcpy(CEDCLOTRLH.CMF_5, CEDCLOTRLT.CMF_5, sizeof(CEDCLOTRLH.CMF_5)); /* Initial Inspection Time */
	
	memcpy(CEDCLOTRLH.LOC_ID, CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLT.LOC_ID));

	memcpy(CEDCLOTRLH.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));
	memcpy(CEDCLOTRLH.FLOW, CEDCLOTRLT.FLOW, sizeof(CEDCLOTRLT.FLOW));
	CEDCLOTRLH.QTY = CEDCLOTRLT.QTY;

	CDB_insert_cedclotrlh(&CEDCLOTRLH);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "EDC-0004");
		TRS.set_fieldmsg(out_node, "CEDCLOTRLH INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLH.FACTORY), CEDCLOTRLH.FACTORY);
        TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLH.INS_TYPE), CEDCLOTRLH.INS_TYPE);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CEDCLOTRLH.HIST_SEQ);
        TRS.add_fieldmsg(out_node, "INS_CNT", MP_INT, CEDCLOTRLH.INS_CNT);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	//CWIPCELLOS 검사결과
	TRS.add_int(out_node, "INS_CNT", CEDCLOTRLT.INS_CNT);

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CEDC_Update_Inspection_Data_Validation()
		- Main sub function of "CEDC_UPDATE_INSPECTION_DATA" function
		- Check the condition for Update inspection data
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEDC_Update_Inspection_Data_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}