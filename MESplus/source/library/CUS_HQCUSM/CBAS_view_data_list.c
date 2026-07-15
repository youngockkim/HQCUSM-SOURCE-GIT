/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CBAS_view_data_list.c
	Description : View data List Information

    MES Version : 5.3.6.4

	Function List  
		- CBAS_view_Module_grade_list()
			+ View Lot
		- CBAS_view_Module_grade_list()
			+ Main sub function of CBAS_view_data_list function
			+ View Order BOM definition
		- CBAS_view_Module_grade_list_Validation()
			+ Main sub function of CBAS_view_data_list function
			+ Check the condition for view Order BOM List
	Detail Description
		- CBAS_view_Module_grade_list()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  JuhyonHyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
int CBAS_VIEW_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
	CBAS_View_Data_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_View_Data_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];     
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CBAS_VIEW_DATA_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CBAS_View_Data_List", out_node);

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
	CBAS_VIEW_DATA_LIST()
		- Main sub function of "CBAS_View_Data_List" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CBAS_VIEW_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
   struct MGCMTBLDAT_TAG MGCMTBLDAT;

    TRSNode *list_item;
	struct worktime_tag tmp_work_time;
	char s_sys_time[14];
	int i_step;

    LOG_head("CBAS_VIEW_DATA_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

    /* Order BOM List by Factory and Order ID */
    i_step = 0;
    CDB_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
    
	if (TRS.get_procstep(in_node) == '1')
	{
		//TABLE_NAME : @REPIAR_CODE //
		i_step = 2;
		memcpy(MGCMTBLDAT.TABLE_NAME, "@REPAIR_CODE", strlen("@REPAIR_CODE"));
	
	}
	else if (TRS.get_procstep(in_node) == '2')
	{
		//REPAIR WORKER
		i_step = 3;
		memcpy(MGCMTBLDAT.TABLE_NAME, "@REPAIR_WORKER", strlen("@REPAIR_WORKER"));
		memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_time(s_sys_time, &tmp_work_time);

        if(COM_isnullspace(TRS.get_string(in_node, "SHIFT")) == MP_TRUE)
        {
            MGCMTBLDAT.KEY_1[0] = CCOM_get_work_shift(s_sys_time); //WORK SHIFT
        }
        else
        {
            TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "SHIFT");
        }

		MGCMTBLDAT.DATA_2[0] = 'Y' ; //Y가 아닌것.
	
	}
	else if (TRS.get_procstep(in_node) == '3')
	{
		//REPAIR WORKER
		i_step = 5;
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.DATA_10, sizeof(MGCMTBLDAT.DATA_10), in_node, "USE_YN");
	
	}	else if (TRS.get_procstep(in_node) == '4')
	{
		//REPAIR WORKER
		i_step = 6;
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_2");
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "KEY_1");
	} else if (TRS.get_procstep(in_node) == '5')
	{
		//REPAIR WORKER
		i_step = 7;
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.DATA_5, sizeof(MGCMTBLDAT.DATA_5), in_node, "LINE_GROUP");
	} else if (TRS.get_procstep(in_node) == '6')
	{
		//REPAIR WORKER
		i_step = 8;
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_2");
	} else if (TRS.get_procstep(in_node) == '7') //IS-21-04-017 Terminate Module
	{
		//REPAIR WORKER
		i_step = 9;
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_2");
        TRS.copy(MGCMTBLDAT.DATA_10, sizeof(MGCMTBLDAT.DATA_10), in_node, "USE_YN");
	}else if (TRS.get_procstep(in_node) == '8') //IVOC-4375 [MES OI New Page] Repair Operator Incentive Time Tracking
	{
		i_step = 10;
		memcpy(MGCMTBLDAT.TABLE_NAME, "@REPAIR_WORKER", strlen("@REPAIR_WORKER"));
		MGCMTBLDAT.DATA_2[0] = 'Y' ; //Y가 아닌것.

	}else if (TRS.get_procstep(in_node) == 'A') //Laminator Recipe Patrol
	{
		i_step = 900;
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "KEY_1");;
	}else if (TRS.get_procstep(in_node) == 'B') //Worklog FQC
	{
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_1");;
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_2");;
		i_step = 101;
	}
	//25.03.21 Module Terminate Service
	else if (TRS.get_procstep(in_node) == 'C') //TERMINATE_PROCESS
	{
		i_step = 102;
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.DATA_8, sizeof(MGCMTBLDAT.DATA_8), in_node, "USE_YN");
	}
	else if (TRS.get_procstep(in_node) == 'D') //TERMINATE_CODE
	{
		i_step = 103;
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.DATA_8, sizeof(MGCMTBLDAT.DATA_8), in_node, "USE_YN");
	}
	else if (TRS.get_procstep(in_node) == 'E') //Management 4M - OPERATION
	{
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_2"); 
		TRS.copy(MGCMTBLDAT.DATA_2, 1, in_node, "DATA_2"); 
		TRS.copy(MGCMTBLDAT.DATA_4, 1, in_node, "DATA_4");
		i_step = 104;
	}
	else if (TRS.get_procstep(in_node) == 'F') //Management 4M - EQ
	{
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "KEY_1"); 
		TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "KEY_2"); 
		TRS.copy(MGCMTBLDAT.KEY_3, sizeof(MGCMTBLDAT.KEY_3), in_node, "KEY_3"); 
		i_step = 105;
	}
	else if (TRS.get_procstep(in_node) == 'G') //KEY_1, DATA_10 sort
	{
		TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "KEY_1"); 
		i_step = 106;
	}

	//25.03.21 Module Terminate Service
	CDB_open_mgcmtbldat(i_step,&MGCMTBLDAT);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
            strcpy(s_msg_code, "BOM-0042");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
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

    while(1) 
    {
        CDB_fetch_mgcmtbldat(i_step, &MGCMTBLDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_mgcmtbldat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        { 
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_mgcmtbldat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		       
        /* Construct out node */
		if (COM_isnullspace(TRS.get_string(in_node, "WORKER")) == MP_FALSE)
		{
			if (( i_step == 3 ) &&
				memcmp(MGCMTBLDAT.KEY_2, TRS.get_string(in_node, "WORKER"), strlen(TRS.get_string(in_node, "WORKER"))) == 0)
			{
				continue;
			}

		}
		
		list_item = TRS.add_node(out_node, "LIST");
		TRS.add_string(list_item, "KEY_1", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));
        TRS.add_string(list_item, "KEY_2", MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2));
        TRS.add_string(list_item, "KEY_3", MGCMTBLDAT.KEY_3, sizeof(MGCMTBLDAT.KEY_3));
        TRS.add_string(list_item, "KEY_4", MGCMTBLDAT.KEY_4, sizeof(MGCMTBLDAT.KEY_4));
        TRS.add_string(list_item, "KEY_5", MGCMTBLDAT.KEY_5, sizeof(MGCMTBLDAT.KEY_5));
		TRS.add_string(list_item, "DATA_1", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        TRS.add_string(list_item, "DATA_2", MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
		TRS.add_string(list_item, "DATA_3", MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3));
        TRS.add_string(list_item, "DATA_4", MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4));
		TRS.add_string(list_item, "DATA_5", MGCMTBLDAT.DATA_5, sizeof(MGCMTBLDAT.DATA_5));
        TRS.add_string(list_item, "DATA_5", MGCMTBLDAT.DATA_5, sizeof(MGCMTBLDAT.DATA_5));
		TRS.add_string(list_item, "DATA_7", MGCMTBLDAT.DATA_7, sizeof(MGCMTBLDAT.DATA_7));
        TRS.add_string(list_item, "DATA_8", MGCMTBLDAT.DATA_8, sizeof(MGCMTBLDAT.DATA_8));
		TRS.add_string(list_item, "DATA_9", MGCMTBLDAT.DATA_9, sizeof(MGCMTBLDAT.DATA_9));
		TRS.add_string(list_item, "DATA_10", MGCMTBLDAT.DATA_10, sizeof(MGCMTBLDAT.DATA_10));

		
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

