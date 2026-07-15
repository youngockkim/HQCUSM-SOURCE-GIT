/*******************************************************************************

    System      : MESplus
    Module      : Update Pmpp Diode Alert
    File Name   : CWIP_update_pmpp_diode_alert.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.08.07  yeonkeun.lim

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_UPDATE_PMPP_DIODE_ALERT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_update_pmpp_diode_alert()
        - CWIP_update_pmpp_diode_alert
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Pmpp_Diode_Alert(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_PMPP_DIODE_ALERT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_PMPP_DIODE_ALERT", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}


/*******************************************************************************
    CWIP_UPDATE_PMPP_DIODE_ALERT()
        - CWIP_UPDATE_PMPP_DIODE_ALERT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_PMPP_DIODE_ALERT(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPPMPHIS_TAG CWIPPMPHIS;
	struct CWIPPMPHIS_TAG CWIPPMPHIS_LOCATION_DATA;

	TRSNode ** Tran_List;

	char s_sys_time[14];
	int    i_tran_count = 0;
	int    i = 0;
	//int    i_step;
	int    i_InsCnt;
	//int    i_InsCntUpdate;
	int    i_InsertFlag=0;

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_PMPP_DIODE_ALERT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
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

	// 20210225 add logic work
	if(TRS.get_procstep(in_node) == '2') 
	{
		Tran_List = TRS.get_list(in_node, "TRAN_LIST");
		i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

		for(i = 0; i < i_tran_count; i++)
		{
			/* Select Area by Line Code */
			CDB_init_cwippmphis(&CWIPPMPHIS);
			/*
			TRS.copy(CWIPPMPHIS.FACTORY, sizeof(CWIPPMPHIS.FACTORY), Tran_List[i], IN_FACTORY);
			TRS.copy(CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID), Tran_List[i], "MODULE_ID");
			TRS.copy(CWIPPMPHIS.WORK_DATE, sizeof(CWIPPMPHIS.WORK_DATE), Tran_List[i], "WORK_DATE");
			memcpy(CWIPPMPHIS.RES_ID, "%", strlen("%"));
			memcpy(CWIPPMPHIS.LINE_ID, "%", strlen("%"));
			memcpy(CWIPPMPHIS.WORK_SHIFT, "%", strlen("%"));
			memcpy(CWIPPMPHIS.MACHINE_ISSUE_TYPE, "%", strlen("%"));
			memcpy(CWIPPMPHIS.CMF_1, "%", strlen("%"));

			i_step = 5;
			//CWIPPMPHIS 조회 기준 변경 : WORK_DATE->INS_TIME
			CDB_open_cwippmphis(i_step, &CWIPPMPHIS);
			
			// AS-IS Data Not in
			if(DB_error_code != DB_SUCCESS)
			{
				break;
			}

			CDB_fetch_cwippmphis(i_step, &CWIPPMPHIS);

			if(DB_error_code == DB_NOT_FOUND) 
			{
				CDB_close_cwippmphis(i_step);
				break;
			}

			memcpy(CWIPPMPHIS.MACHINE_ISSUE_TYPE, "%", strlen("%"));
			memcpy(CWIPPMPHIS.CMF_1, "%", strlen("%"));

			i_InsCnt = CDB_select_cwippmphis_scalar(2, &CWIPPMPHIS) + 1;
			i_step = 6;

			TRS.copy(CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID), Tran_List[i], "MODULE_ID");
			TRS.copy(CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION), Tran_List[i], "DEFECT_POSITION");
			CDB_open_cwippmphis(i_step, &CWIPPMPHIS);
			if(DB_error_code != DB_SUCCESS)
			{
				break;
			}

			CDB_fetch_cwippmphis(i_step, &CWIPPMPHIS);

			i_InsCntUpdate = CWIPPMPHIS.INS_CNT;
			*/

			// 20210810 MES Application Memory leak 점검 및 수정
			// insert / update 기능 개선
			TRS.copy(CWIPPMPHIS.FACTORY, sizeof(CWIPPMPHIS.FACTORY), Tran_List[i], IN_FACTORY);
			TRS.copy(CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID), Tran_List[i], "MODULE_ID");
			TRS.copy(CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION), Tran_List[i], "DEFECT_POSITION");
			CDB_select_cwippmphis(2, &CWIPPMPHIS);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					i_InsertFlag = 1;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPPMPHIS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS.FACTORY), CWIPPMPHIS.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPPMPHIS.LOT_ID), CWIPPMPHIS.LOT_ID);
					TRS.set_fieldmsg(out_node, "INS_CNT", MP_INT, CWIPPMPHIS.INS_CNT);

					TRS.add_dberrmsg(out_node,DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			
			// AS-IS Data not in
			if(i_InsertFlag == 1)
			{
				TRS.copy(CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION), Tran_List[i], "DEFECT_POSITION");
				CWIPPMPHIS.INS_CNT = 1;
				CDB_select_cwippmphis(1, &CWIPPMPHIS);
				if(DB_error_code != DB_SUCCESS)
				{
					// DB Close 추가
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPPMPHIS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS.FACTORY), CWIPPMPHIS.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPPMPHIS.LOT_ID), CWIPPMPHIS.LOT_ID);
					TRS.set_fieldmsg(out_node, "INS_CNT", MP_INT, CWIPPMPHIS.INS_CNT);
					TRS.add_fieldmsg(out_node, "DEFECT_POSITION", MP_STR, sizeof(CWIPPMPHIS.DEFECT_POSITION), CWIPPMPHIS.DEFECT_POSITION);

					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					return MP_FALSE;
				}

				memcpy(&CWIPPMPHIS_LOCATION_DATA, &CWIPPMPHIS, sizeof(CWIPPMPHIS_LOCATION_DATA));

				i_InsCnt = (int)CDB_select_cwippmphis_scalar(3, &CWIPPMPHIS) + 1;

				TRS.copy(CWIPPMPHIS_LOCATION_DATA.DEFECT_POSITION, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), Tran_List[i], "DEFECT_POSITION");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), Tran_List[i], "MACHINE_ISSUE_TYPE");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.OPERATOR, sizeof(CWIPPMPHIS_LOCATION_DATA.OPERATOR), Tran_List[i], "OPERATOR");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.MACHINE_TECHNICIAN, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), Tran_List[i], "MACHINE_TECHNICIAN");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.CMF_1, sizeof(CWIPPMPHIS_LOCATION_DATA.CMF_1), Tran_List[i], "SOLDERING_TYPE");		//IS-20-09-118 IS-20-09-118 

				// 1 is already exists
				CWIPPMPHIS_LOCATION_DATA.INS_CNT = i_InsCnt;

				memcpy(CWIPPMPHIS_LOCATION_DATA.UPDATE_USER_ID, MODULE_CLI, strlen(MODULE_CLI));
				memcpy(CWIPPMPHIS_LOCATION_DATA.UPDATE_TIME, s_sys_time, sizeof(CWIPPMPHIS_LOCATION_DATA.UPDATE_TIME));
				CDB_insert_cwippmphis(&CWIPPMPHIS_LOCATION_DATA);
				if(DB_error_code != DB_SUCCESS)
				{
					// DB Close 추가
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPPMPHIS INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS_LOCATION_DATA.FACTORY), CWIPPMPHIS_LOCATION_DATA.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), CWIPPMPHIS_LOCATION_DATA.LOT_ID);
					TRS.set_fieldmsg(out_node, "INS_CNT", MP_INT, CWIPPMPHIS_LOCATION_DATA.INS_CNT);
					TRS.add_fieldmsg(out_node, "DEFECT_POSITION", MP_STR, sizeof(CWIPPMPHIS_LOCATION_DATA.DEFECT_POSITION), CWIPPMPHIS_LOCATION_DATA.DEFECT_POSITION);

					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					return MP_FALSE;
				}
			}
			// AS-IS Data in
			else
			{
				memcpy(&CWIPPMPHIS_LOCATION_DATA, &CWIPPMPHIS, sizeof(CWIPPMPHIS_LOCATION_DATA));

				memcpy(CWIPPMPHIS_LOCATION_DATA.DEFECT_POSITION, CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.DEFECT_POSITION));
				memcpy(CWIPPMPHIS_LOCATION_DATA.INS_TIME, CWIPPMPHIS.INS_TIME, sizeof(CWIPPMPHIS.INS_TIME));

				TRS.copy(CWIPPMPHIS_LOCATION_DATA.DEFECT_POSITION, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), Tran_List[i], "DEFECT_POSITION");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), Tran_List[i], "MACHINE_ISSUE_TYPE");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.OPERATOR, sizeof(CWIPPMPHIS_LOCATION_DATA.OPERATOR), Tran_List[i], "OPERATOR");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.MACHINE_TECHNICIAN, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), Tran_List[i], "MACHINE_TECHNICIAN");
				TRS.copy(CWIPPMPHIS_LOCATION_DATA.CMF_1, sizeof(CWIPPMPHIS_LOCATION_DATA.CMF_1), Tran_List[i], "SOLDERING_TYPE");		//IS-20-09-118 IS-20-09-118 

				CWIPPMPHIS_LOCATION_DATA.INS_CNT = CWIPPMPHIS.INS_CNT;

				memcpy(CWIPPMPHIS_LOCATION_DATA.UPDATE_USER_ID, MODULE_CLI, strlen(MODULE_CLI));
				memcpy(CWIPPMPHIS_LOCATION_DATA.UPDATE_TIME, s_sys_time, sizeof(CWIPPMPHIS_LOCATION_DATA.UPDATE_TIME));
				CDB_update_cwippmphis(3, &CWIPPMPHIS_LOCATION_DATA);
				if(DB_error_code != DB_SUCCESS)
				{
					// DB Close 추가
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPPMPHIS UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPMPHIS_LOCATION_DATA.FACTORY), CWIPPMPHIS_LOCATION_DATA.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPPMPHIS_LOCATION_DATA.LOT_ID), CWIPPMPHIS_LOCATION_DATA.LOT_ID);
					TRS.set_fieldmsg(out_node, "INS_CNT", MP_INT, CWIPPMPHIS_LOCATION_DATA.INS_CNT);
					TRS.add_fieldmsg(out_node, "DEFECT_POSITION", MP_STR, sizeof(CWIPPMPHIS_LOCATION_DATA.DEFECT_POSITION), CWIPPMPHIS_LOCATION_DATA.DEFECT_POSITION);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					return MP_FALSE;
				}
			}
		}
	}
	// org logic work
	else
	{
		Tran_List = TRS.get_list(in_node, "TRAN_LIST");
		i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");
		for(i = 0; i < i_tran_count; i++)
		{
			CDB_init_cwippmphis(&CWIPPMPHIS);
			TRS.copy(CWIPPMPHIS.FACTORY, sizeof(CWIPPMPHIS.FACTORY), Tran_List[i], "FACTORY");
			TRS.copy(CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID), Tran_List[i], "MODULE_ID");
			TRS.copy(CWIPPMPHIS.DEFECT_POSITION, sizeof(CWIPPMPHIS.LOT_ID), Tran_List[i], "DEFECT_POSITION");
			TRS.copy(CWIPPMPHIS.MACHINE_ISSUE_TYPE, sizeof(CWIPPMPHIS.LOT_ID), Tran_List[i], "MACHINE_ISSUE_TYPE");
			TRS.copy(CWIPPMPHIS.OPERATOR, sizeof(CWIPPMPHIS.OPERATOR), Tran_List[i], "OPERATOR");
			TRS.copy(CWIPPMPHIS.MACHINE_TECHNICIAN, sizeof(CWIPPMPHIS.LOT_ID), Tran_List[i], "MACHINE_TECHNICIAN");
			TRS.copy(CWIPPMPHIS.CMF_1, sizeof(CWIPPMPHIS.CMF_1), Tran_List[i], "SOLDERING_TYPE");		//IS-20-09-118 IS-20-09-118 

			memcpy(CWIPPMPHIS.UPDATE_USER_ID, MODULE_CLI, strlen(MODULE_CLI));
			memcpy(CWIPPMPHIS.UPDATE_TIME, s_sys_time, sizeof(CWIPPMPHIS.UPDATE_TIME));
			CDB_update_cwippmphis(2, &CWIPPMPHIS);
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}