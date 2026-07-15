/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_equipment_average_working_time.c
    Description : 

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Equipment_Average_Working_Time()
            + Setup service interface function
        - EAPMES_COLLECT_EQUIPMENT_AVERAGE_WORKING_TIME()
            + Main sub function of EAPMES_Collect_Equipment_Average_Working_Time function
            + Setup service main business function
    Detail Description
        - EAPMES_COLLECT_EQUIPMENT_AVERAGE_WORKING_TIME()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019/10/16  		     Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    EAPMES_Collect_Equipment_Average_Working_Time()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Equipment_Average_Working_Time(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_EQUIPMENT_AVERAGE_WORKING_TIME(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_EQUIPMENT_AVERAGE_WORKING_TIME", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log : CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_EQUIPMENT_AVERAGE_WORKING_TIME()
        - Main sub function of "EAPMES_Collect_Equipment_Average_Working_Time" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_EQUIPMENT_AVERAGE_WORKING_TIME(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
    struct CRASAVGTIM_TAG CRASAVGTIM;

	char   s_sys_time_17[17];
	double d_work_time;

	// in_node 값 로그 작성
    LOG_head("EAPMES_COLLECT_EQUIPMENT_AVERAGE_WORKING_TIME");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_sys_time_17, ' ', sizeof(s_sys_time_17));
	if(COM_isnullspace(TRS.get_string(in_node, "CLIENT_TIME")) == MP_FALSE)
	{
		TRS.copy(s_sys_time_17, sizeof(s_sys_time_17), in_node, "CLIENT_TIME");
		s_sys_time_17[16] = '\0';
	}
	else
	{
		return MP_TRUE;
	}

    // 1. 설비 ID 확인
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

    // 2, 데이터 Insert
 
    //	1	2019101709004752	759867	MDL01	US-E1-FEL-01	18.000000	18.600000	18.600000	
    
    if(TRS.get_char(in_node, "PROCSTEP") == '1')
    {
        CDB_init_crasavgtim(&CRASAVGTIM);
	    TRS.copy(CRASAVGTIM.FACTORY, sizeof(CRASAVGTIM.FACTORY), in_node, IN_FACTORY);
	    TRS.copy(CRASAVGTIM.RES_ID, sizeof(CRASAVGTIM.RES_ID), in_node, "RES_ID");
        TRS.copy(CRASAVGTIM.LINE_ID, sizeof(CRASAVGTIM.LINE_ID), in_node, "LINE_ID");


        //CRASAVGTIM.CURRENT_WORK_TIME = TRS.get_double(in_node, "CURRENT_TIME");
        //CRASAVGTIM.AVERAGE_TIME_100 = TRS.get_double(in_node, "AVERAGE_TIME_100");
        //CRASAVGTIM.AVERAGE_TIME_400 = TRS.get_double(in_node, "AVERAGE_TIME_400");

        CRASAVGTIM.CURRENT_WORK_TIME = COM_atof(TRS.get_string(in_node, "CURRENT_TIME"), (int)strlen(TRS.get_string(in_node, "CURRENT_TIME")));
        CRASAVGTIM.AVERAGE_TIME_100 = COM_atof(TRS.get_string(in_node, "AVERAGE_TIME_100"), (int)strlen(TRS.get_string(in_node, "AVERAGE_TIME_100")));
        CRASAVGTIM.AVERAGE_TIME_400 = COM_atof(TRS.get_string(in_node, "AVERAGE_TIME_400"), (int)strlen(TRS.get_string(in_node, "AVERAGE_TIME_400")));

	    //memcpy(CRASAVGTIM.TRAN_TIME, "2019101709004752", sizeof(CRASAVGTIM.TRAN_TIME));
        memcpy(CRASAVGTIM.TRAN_TIME, s_sys_time_17, sizeof(CRASAVGTIM.TRAN_TIME));

	    CDB_insert_crasavgtim(&CRASAVGTIM);

        if(DB_error_code != DB_SUCCESS)
		{

		}
    }
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}