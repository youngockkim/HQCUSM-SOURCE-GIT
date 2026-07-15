/*******************************************************************************

    System      : MESplus
    Module      : Tabber Cell inspection
    File Name   : CEIS_Collect_Inspection_Vision_Cleaving.c
    Description : Tabber Cell inspection 
				  
    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.10.18  HANCHANG.KIM  CREATE
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_COLLECT_INSPECTION_VISION_CLEAVING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_tabber_inspection_cell()
        - Tabber Inspection Cell sum
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int EAPMES_Collect_Inspection_Vision_Cleaving(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;
	TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_INSPECTION_VISION_CLEAVING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_Collect_Inspection_Vision_Cleaving", out_node);

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

	 /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "TRAY_ID", TRS.get_string(in_node, "TRAY_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}


/*******************************************************************************
    EAPMES_COLLECT_INSPECTION_VISION_CLEAVING()
        - Tabber Inspection Cell sum
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int EAPMES_COLLECT_INSPECTION_VISION_CLEAVING(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	struct CRASCLVLOS_TAG CRASCLVLOS;
 	struct worktime_tag cur_work_time;
	char cell_time[16];
	char s_sys_time[14];

    LOG_head("EAPMES_COLLECT_INSPECTION_VISION_CLEAVING");
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

	//근무일 기준 가져오기
	memset(cell_time, '0', sizeof(cell_time));
	memcpy(cell_time,s_sys_time, sizeof(s_sys_time));
	CCOM_get_work_time(cell_time, &cur_work_time);

	/* CRASCLVLOS TABLE */
	CDB_init_crasclvlos(&CRASCLVLOS);
	TRS.copy(CRASCLVLOS.FACTORY, sizeof(CRASCLVLOS.FACTORY), in_node, "FACTORY");
	memcpy(CRASCLVLOS.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
	memset(CRASCLVLOS.WORK_TIME, '0', sizeof(CRASCLVLOS.WORK_TIME));
	memcpy(CRASCLVLOS.WORK_TIME, s_sys_time, strlen("YYYYMMDDHH")); 
	TRS.copy(CRASCLVLOS.LINE_ID, sizeof(CRASCLVLOS.LINE_ID), in_node, "LINE_ID");
	TRS.copy(CRASCLVLOS.ORDER_ID, sizeof(CRASCLVLOS.ORDER_ID), in_node, "ORDER_ID"); 
	TRS.copy(CRASCLVLOS.RES_ID, sizeof(CRASCLVLOS.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASCLVLOS.LOC_ID, sizeof(CRASCLVLOS.LOC_ID), in_node, "LOC_ID"); 
	TRS.copy(CRASCLVLOS.LOSS_CODE, sizeof(CRASCLVLOS.LOC_ID), in_node, "DEFECT"); 
	
	CDB_select_crasclvlos_for_update(1, &CRASCLVLOS);
	if (DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			TRS.copy(CRASCLVLOS.CREATE_USER_ID, sizeof(CRASCLVLOS.CREATE_USER_ID), in_node, "USERID");
			memcpy(CRASCLVLOS.CREATE_TIME, s_sys_time, sizeof(CRASCLVLOS.CREATE_TIME)); 
			CRASCLVLOS.LOSS_QTY = 0;
	
			CDB_insert_crasclvlos(&CRASCLVLOS);
		}
	}
	
	CRASCLVLOS.LOSS_QTY = CRASCLVLOS.LOSS_QTY + 1;
	TRS.copy(CRASCLVLOS.UPDATE_USER_ID, sizeof(CRASCLVLOS.UPDATE_USER_ID), in_node, "USERID");
	memcpy(CRASCLVLOS.UPDATE_TIME, s_sys_time, sizeof(CRASCLVLOS.UPDATE_TIME)); 
	
	CDB_update_crasclvlos(1,&CRASCLVLOS);
	if (DB_error_code != DB_SUCCESS)
	{
		
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}