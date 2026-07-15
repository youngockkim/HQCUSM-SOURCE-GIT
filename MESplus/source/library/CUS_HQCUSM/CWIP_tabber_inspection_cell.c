/*******************************************************************************

    System      : MESplus
    Module      : Tabber Cell inspection
    File Name   : CWIP_tabber_inspection_cell.c
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

#include "CUS_common.h"

int CWIP_TABBER_INSPECTION_CELL(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_tabber_inspection_cell()
        - Tabber Inspection Cell sum
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_tabber_inspection_cell(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_TABBER_INSPECTION_CELL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_tabber_inspection_cell", out_node);

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
    CWIP_TABBER_INSPECTION_CELL()
        - Tabber Inspection Cell sum
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_TABBER_INSPECTION_CELL(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	
	struct RSUMHORCEL_TAG RSUMHORCEL;
	struct MRASRESDEF_TAG MRASRESDEF_ORD;
	struct worktime_tag cur_work_time;
	char cell_time[16];

    LOG_head("CWIP_TABBER_INSPECTION_CELL");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	//근무일 기준 가져오기
	memset(cell_time, ' ', sizeof(cell_time));  
	TRS.copy(cell_time, sizeof(cell_time), in_node, "CLIENT_TIME");
	CCOM_get_work_time(cell_time, &cur_work_time);

	//설비의 Last PO
	DBC_init_mrasresdef(&MRASRESDEF_ORD);
		
	TRS.copy(MRASRESDEF_ORD.FACTORY, sizeof(MRASRESDEF_ORD.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF_ORD.RES_ID, sizeof(MRASRESDEF_ORD.RES_ID), in_node, "RES_ID");

	DBC_select_mrasresdef(1, &MRASRESDEF_ORD);
	if(DB_error_code != DB_SUCCESS)
	{
		//MRASRESDEF_ORD.RES_CMF_9 Last PO
	}

	/* RSUMHORCEL TABLE */
	CDB_init_rsumhorcel(&RSUMHORCEL);
	TRS.copy(RSUMHORCEL.FACTORY, sizeof(RSUMHORCEL.FACTORY), in_node, "FACTORY");
	memcpy(RSUMHORCEL.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
	TRS.copy(RSUMHORCEL.LINE_ID, sizeof(RSUMHORCEL.LINE_ID), in_node, "LINE_ID");
	TRS.copy(RSUMHORCEL.RES_ID, sizeof(RSUMHORCEL.RES_ID), in_node, "RES_ID");
	memcpy(RSUMHORCEL.ORDER_ID, MRASRESDEF_ORD.RES_CMF_9, sizeof(RSUMHORCEL.ORDER_ID));
	
	TRS.copy(RSUMHORCEL.RESULT_VALUE, sizeof(RSUMHORCEL.RESULT_VALUE), in_node, "RESULT");
	RSUMHORCEL.DEFECT[0] = TRS.get_char(in_node, "REASON_CODE");
	
	RSUMHORCEL.CM_KEY_1[0] = ' ';
	RSUMHORCEL.CM_KEY_2[0] = ' ';
	RSUMHORCEL.CM_KEY_3[0] = ' ';

	if(COM_isnullspace(TRS.get_string(in_node,"LOC_ID")) == MP_FALSE)
	{
		//TRS.copy(RSUMHORCEL.CM_KEY_1, sizeof(RSUMHORCEL.CM_KEY_1[0]), in_node, "LOC_ID");
		RSUMHORCEL.CM_KEY_1[0] = TRS.get_char(in_node,"LOC_ID");
	}
	
	CDB_select_rsumhorcel_for_update(1, &RSUMHORCEL);
	if (DB_error_code != DB_SUCCESS)
	{
		//NOT FOUND
		memcpy(RSUMHORCEL.WORK_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
		CDB_insert_rsumhorcel(&RSUMHORCEL);
		if (DB_error_code != DB_SUCCESS)
		{
			//
		}
	}

	
	
	//00~01  20191018 03 024367
	if(cell_time[8] == '0' && cell_time[9] == '0')
	{
		RSUMHORCEL.TIME01_QTY = RSUMHORCEL.TIME01_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '1')
	{
		RSUMHORCEL.TIME02_QTY = RSUMHORCEL.TIME02_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '2')
	{
		RSUMHORCEL.TIME03_QTY = RSUMHORCEL.TIME03_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '3')
	{
		RSUMHORCEL.TIME04_QTY = RSUMHORCEL.TIME04_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '4')
	{
		RSUMHORCEL.TIME05_QTY = RSUMHORCEL.TIME05_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '5')
	{
		RSUMHORCEL.TIME06_QTY = RSUMHORCEL.TIME06_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '6')
	{
		RSUMHORCEL.TIME07_QTY = RSUMHORCEL.TIME07_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '7')
	{
		RSUMHORCEL.TIME08_QTY = RSUMHORCEL.TIME08_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '8')
	{
		RSUMHORCEL.TIME09_QTY = RSUMHORCEL.TIME09_QTY + 1;
	}
	if(cell_time[8] == '0' && cell_time[9] == '9')
	{
		RSUMHORCEL.TIME10_QTY = RSUMHORCEL.TIME10_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '0')
	{
		RSUMHORCEL.TIME11_QTY = RSUMHORCEL.TIME11_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '1')
	{
		RSUMHORCEL.TIME12_QTY = RSUMHORCEL.TIME12_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '2')
	{
		RSUMHORCEL.TIME13_QTY = RSUMHORCEL.TIME13_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '3')
	{
		RSUMHORCEL.TIME14_QTY = RSUMHORCEL.TIME14_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '4')
	{
		RSUMHORCEL.TIME15_QTY = RSUMHORCEL.TIME15_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '5')
	{
		RSUMHORCEL.TIME16_QTY = RSUMHORCEL.TIME16_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '6')
	{
		RSUMHORCEL.TIME17_QTY = RSUMHORCEL.TIME17_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '7')
	{
		RSUMHORCEL.TIME18_QTY = RSUMHORCEL.TIME18_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '8')
	{
		RSUMHORCEL.TIME19_QTY = RSUMHORCEL.TIME19_QTY + 1;
	}
	if(cell_time[8] == '1' && cell_time[9] == '9')
	{
		RSUMHORCEL.TIME20_QTY = RSUMHORCEL.TIME20_QTY + 1;
	}
	if(cell_time[8] == '2' && cell_time[9] == '0')
	{
		RSUMHORCEL.TIME21_QTY = RSUMHORCEL.TIME21_QTY + 1;
	}
	if(cell_time[8] == '2' && cell_time[9] == '1')
	{
		RSUMHORCEL.TIME22_QTY = RSUMHORCEL.TIME22_QTY + 1;
	}
	if(cell_time[8] == '2' && cell_time[9] == '2')
	{
		RSUMHORCEL.TIME23_QTY = RSUMHORCEL.TIME23_QTY + 1;
	}
	if(cell_time[8] == '2' && cell_time[9] == '3')
	{
		RSUMHORCEL.TIME24_QTY = RSUMHORCEL.TIME24_QTY + 1;
	}
	
	RSUMHORCEL.TOTAL_QTY = RSUMHORCEL.TOTAL_QTY + 1; 
	
	//UPDATE
	CDB_update_rsumhorcel(1,&RSUMHORCEL);
	if (DB_error_code != DB_SUCCESS)
	{
		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}