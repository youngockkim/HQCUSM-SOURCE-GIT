/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_View_Tabber_Status.c
	Description : View Tabber Status

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Tabber_Status()
		- CWIP_VIEW_TABBER_STATUS()
	Detail Description
		- CWIP_VIEW_TABBER_STATUS()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2020/08/11  Lim Yeon Keun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"


/*******************************************************************************
	CWIP_Get_Db_Systime()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Get_Db_Systime(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_GET_DB_SYSTIME(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_GET_DB_SYSTIME", out_node);

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
	CWIP_VIEW_TABBER_STATUS()
		- Main sub function of "CWIP_View_Tabber_Status" function
		- View Tabber Status
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_GET_DB_SYSTIME(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
  	char s_sys_time[14];
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	TRS.add_string(out_node, "SYSTIME", s_sys_time, sizeof(s_sys_time));

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 
