/*******************************************************************************

    System      : MESplus
    Module      : Cell Move Information
    File Name   : CINF_download_mm103_cell_move.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.06  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>
#include <INVCore_common.h>

int CUS_INTERFACE_DOWNLOAD_CELL_MOVE(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Cell Move Information
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Cell_Move(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_CELL_MOVE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Cell_Move", out_node);

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
    CUS_INTERFACE_DOWNLOAD_CELL_MOVE()
        - ERP->MES Cell Move Information
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_CELL_MOVE(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IWIPCELHUI_TAG IWIPCELHUI;
	struct IBAKCELHUI_TAG IBAKCELHUI;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct CINVLOTHIS_TAG CINVLOTHIS;
	struct CINVCELRCV_TAG CINVCELRCV;
	struct MINVMATSTS_TAG MINVMATSTS;
	
	TRSNode *in_node1;
	TRSNode *out_node1;
	char s_sys_time[14];	
	int seq = 1;

	// PROCESS LOG PRINT
	LOG_head("CINF_INTERFACE_DOWNLOAD_CELL_MOVE");
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

	// OPEN
	CDB_init_iwipcelhui(&IWIPCELHUI);
	CDB_open_iwipcelhui(2, &IWIPCELHUI);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}
		else 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IWIPCELHUI OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPCELHUI.DOC_ID), IWIPCELHUI.DOC_ID);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	// FETCH
	while(1)
	{
		CDB_fetch_iwipcelhui(2, &IWIPCELHUI);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_iwipcelhui(2);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPCELHUI OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPCELHUI.DOC_ID), IWIPCELHUI.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipcelhui(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		in_node1 = TRS.create_node("In_Inventory_In");
		out_node1 = TRS.create_node("Cmn_Out");
		TRS.add_char(in_node1, "LANGUAGE", '2');
		TRS.set_string(in_node1, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.set_string(in_node1, "USERID", MODULE_EAP, strlen(MODULE_EAP));
		TRS.add_char(in_node1, "PROCSTEP", '1');
		TRS.add_string(in_node1, "BACK_TIME", s_sys_time, sizeof(s_sys_time));
		TRS.add_string(in_node1, "MAT_ID", IWIPCELHUI.MATERIALDEFINITIONID, sizeof(IWIPCELHUI.MATERIALDEFINITIONID));
		TRS.add_int(in_node1, "MAT_VER", 1);
		TRS.add_string(in_node1, "OPER", HQCEL_M1_RAWMAT_STOCK_OPER, strlen(HQCEL_M1_RAWMAT_STOCK_OPER));
		TRS.add_double(in_node1, "IN_QTY_1", COM_atol(IWIPCELHUI.ORI_QTY,sizeof(IWIPCELHUI.ORI_QTY)));
		TRS.add_double(in_node1, "ALLOC_QTY", COM_atol(IWIPCELHUI.ORI_QTY,sizeof(IWIPCELHUI.ORI_QTY)));
 		

		// MINVMATSTS에서 MAT_ID별 LAST_HIST_SEQ를 가져온다.
		DBC_init_minvmatsts(&MINVMATSTS);
		memcpy(MINVMATSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MINVMATSTS.MAT_ID, IWIPCELHUI.MATERIALDEFINITIONID, sizeof(MINVMATSTS.MAT_ID));
		MINVMATSTS.MAT_VER = 1;
		memcpy(MINVMATSTS.OPER, HQCEL_M1_RAWMAT_STOCK_OPER, strlen(HQCEL_M1_RAWMAT_STOCK_OPER));

		DBC_select_minvmatsts(1,&MINVMATSTS);
		if(DB_error_code == DB_NOT_FOUND) {
			TRS.add_int(in_node1,"LAST_HIST_SEQ",0);
		} 
		else {			
			TRS.add_int(in_node1,"LAST_HIST_SEQ",MINVMATSTS.LAST_HIST_SEQ);
		}

		// INSERT Core Table
		/*
		if(INV_IN_INVENTORY(s_msg_code, in_node1, out_node1) == MP_FALSE){
			/*DB_rollback();
			gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Cell_Move", out_node);
			COM_set_field_db_msg(out_node, out_node1);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
 			TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
			memcpy(IWIPCELHUI.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_iwipcelhui(2,&IWIPCELHUI);
			DB_commit();
			continue;
		}
	**/

		// BACKUP
        CDB_init_ibakcelhui(&IBAKCELHUI);
		memcpy(IBAKCELHUI.DOC_ID, IWIPCELHUI.DOC_ID, sizeof(struct IWIPCELHUI_TAG));
		CDB_delete_ibakcelhui(1, &IBAKCELHUI);
		CDB_insert_ibakcelhui(&IBAKCELHUI);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		// INSERT CUSTOMER TABLE(CINVLOTSTS)
		CDB_init_cinvlotsts(&CINVLOTSTS);
		memcpy(CINVLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		//memcpy(CINVLOTSTS.INV_LOT_ID, IWIPCELHUI.SMALLBOXID, sizeof(CINVLOTSTS.INV_LOT_ID)); // Server Crash 190925
		memcpy(CINVLOTSTS.INV_LOT_ID, IWIPCELHUI.SMALLBOXID, sizeof(IWIPCELHUI.SMALLBOXID)); 

		CDB_select_cinvlotsts(1, &CINVLOTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
				memcpy(CINVLOTSTS.INPUT_TIME, s_sys_time, sizeof(CINVLOTSTS.INPUT_TIME));
				CDB_insert_cinvlotsts(&CINVLOTSTS);
			}
		}

		memcpy(CINVLOTSTS.VENDOR_BARCD, IWIPCELHUI.CELLBOXBARCODE, sizeof(IWIPCELHUI.CELLBOXBARCODE));
		memcpy(CINVLOTSTS.OPER, MINVMATSTS.OPER, sizeof(MINVMATSTS.OPER));
		memcpy(CINVLOTSTS.MAT_ID, IWIPCELHUI.MATERIALDEFINITIONID, sizeof(CINVLOTSTS.MAT_ID));
		//memcpy(CINVLOTSTS.INV_MAT_TYPE, IWIPCELHUI.MATERIALDEFINITIONID, sizeof(CINVLOTSTS.MAT_ID)); // Server Crash 190925
		memcpy(CINVLOTSTS.INV_MAT_TYPE, IWIPCELHUI.MATERIALDEFINITIONID, sizeof(CINVLOTSTS.INV_MAT_TYPE)); // Server Crash 190925
		CINVLOTSTS.QTY_1 = COM_atoi(IWIPCELHUI.ORI_QTY,sizeof(CINVLOTSTS.QTY_1));
		CINVLOTSTS.QTY_2 = 0;
		CINVLOTSTS.QTY_3 = 0;

		// INSERT CUSTOMER TABLE(CINVLOTHIS)
		CDB_init_cinvlothis(&CINVLOTHIS);
		memcpy(CINVLOTHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CINVLOTHIS.INV_LOT_ID, CINVLOTSTS.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID));

		// 기존 데이터가 없으면 Default로 셋팅한다.
		

		CINVLOTSTS.LAST_HIST_SEQ = (int) CDB_select_cinvlothis_scalar(2,&CINVLOTHIS) + 1;
		
		memcpy(CINVLOTSTS.MAT_ID, IWIPCELHUI.MATERIALDEFINITIONID, sizeof(CINVLOTSTS.MAT_ID));
		CDB_update_cinvlotsts(1, &CINVLOTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            // DO NOTHING
		}

		// INSERT CUSTOMER TABLE(CINVLOTHIS)
		CDB_init_cinvlothis(&CINVLOTHIS);
		memcpy(CINVLOTHIS.FACTORY, CINVLOTSTS.FACTORY, sizeof(CINVLOTSTS.FACTORY));
		memcpy(CINVLOTHIS.INV_LOT_ID, CINVLOTSTS.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID));
		CINVLOTHIS.HIST_SEQ = CINVLOTSTS.LAST_HIST_SEQ;
		memcpy(CINVLOTHIS.VENDOR_BARCD, CINVLOTSTS.VENDOR_BARCD, sizeof(CINVLOTSTS.VENDOR_BARCD));
		memcpy(CINVLOTHIS.OPER, CINVLOTSTS.OPER, sizeof(CINVLOTSTS.OPER));
		memcpy(CINVLOTHIS.MAT_ID, CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));
		memcpy(CINVLOTHIS.INV_MAT_TYPE, CINVLOTSTS.INV_MAT_TYPE, sizeof(CINVLOTSTS.INV_MAT_TYPE));
		memcpy(CINVLOTHIS.VENDOR_ID, CINVLOTSTS.VENDOR_ID, sizeof(CINVLOTSTS.VENDOR_ID));
		memcpy(CINVLOTHIS.LOCATION, CINVLOTSTS.LOCATION, sizeof(CINVLOTSTS.LOCATION));
		memcpy(CINVLOTHIS.BATCH_NO, CINVLOTSTS.BATCH_NO, sizeof(CINVLOTSTS.BATCH_NO));
		CINVLOTHIS.QTY_1 = CINVLOTSTS.QTY_1;
		memcpy(CINVLOTHIS.UNIT_1, CINVLOTSTS.UNIT_1, sizeof(CINVLOTSTS.UNIT_1));
		memcpy(CINVLOTHIS.VENDOR_LOTID, CINVLOTSTS.VENDOR_LOTID, sizeof(CINVLOTSTS.VENDOR_LOTID));
		memcpy(CINVLOTHIS.LAST_TRAN_TIME, CINVLOTSTS.LAST_TRAN_TIME, sizeof(CINVLOTSTS.LAST_TRAN_TIME));
		memcpy(CINVLOTHIS.LAST_TRAN_USER_ID, CINVLOTSTS.LAST_TRAN_USER_ID, sizeof(CINVLOTSTS.LAST_TRAN_USER_ID));
		memcpy(CINVLOTHIS.LAST_TRAN_TYPE, CINVLOTSTS.LAST_TRAN_TYPE, sizeof(CINVLOTSTS.LAST_TRAN_TYPE));		
		memcpy(CINVLOTHIS.INPUT_TIME, CINVLOTSTS.INPUT_TIME, sizeof(CINVLOTSTS.INPUT_TIME));
		memcpy(CINVLOTHIS.PROD_TIME, CINVLOTSTS.PROD_TIME, sizeof(CINVLOTSTS.PROD_TIME));
		memcpy(CINVLOTHIS.CMF_1, CINVLOTSTS.CMF_1, sizeof(CINVLOTSTS.CMF_1));
		memcpy(CINVLOTHIS.CMF_2, CINVLOTSTS.CMF_2, sizeof(CINVLOTSTS.CMF_2));
		memcpy(CINVLOTHIS.CMF_3, CINVLOTSTS.CMF_3, sizeof(CINVLOTSTS.CMF_3));
		memcpy(CINVLOTHIS.CMF_4, CINVLOTSTS.CMF_4, sizeof(CINVLOTSTS.CMF_4));
		memcpy(CINVLOTHIS.CMF_5, CINVLOTSTS.CMF_5, sizeof(CINVLOTSTS.CMF_5));
		memcpy(CINVLOTHIS.CMF_6, CINVLOTSTS.CMF_6, sizeof(CINVLOTSTS.CMF_6));
		memcpy(CINVLOTHIS.CMF_7, CINVLOTSTS.CMF_7, sizeof(CINVLOTSTS.CMF_7));
		memcpy(CINVLOTHIS.CMF_8, CINVLOTSTS.CMF_8, sizeof(CINVLOTSTS.CMF_8));
		memcpy(CINVLOTHIS.CMF_9, CINVLOTSTS.CMF_9, sizeof(CINVLOTSTS.CMF_9));
		memcpy(CINVLOTHIS.CMF_10, CINVLOTSTS.CMF_10, sizeof(CINVLOTSTS.CMF_10));
		CDB_insert_cinvlothis(&CINVLOTHIS);
		if(DB_error_code != DB_SUCCESS)
        {
			//DO NOTHING
		}

		// INSERT CUSTOMER TABLE(CINVCELRCV)
		CDB_init_cinvcelrcv(&CINVCELRCV);
		memcpy(CINVCELRCV.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CINVCELRCV.INV_LOT_ID, IWIPCELHUI.SMALLBOXID, sizeof(IWIPCELHUI.SMALLBOXID));
		CDB_select_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
				memcpy(CINVCELRCV.WORKDAY, s_sys_time, sizeof(s_sys_time));
				CDB_insert_cinvcelrcv(&CINVCELRCV);
			}
		}


		memcpy(CINVCELRCV.ACTION_TYPE, IWIPCELHUI.ACTION_TYPE, sizeof(IWIPCELHUI.ACTION_TYPE));
		memcpy(CINVCELRCV.SMALLBOXID, IWIPCELHUI.SMALLBOXID, sizeof(IWIPCELHUI.SMALLBOXID));
		memcpy(CINVCELRCV.SITE_ID, IWIPCELHUI.SITE_ID, sizeof(IWIPCELHUI.SITE_ID));		
		memcpy(CINVCELRCV.STORAGE_LOCATION, IWIPCELHUI.STORAGE_LOCATION, sizeof(IWIPCELHUI.STORAGE_LOCATION));
		memcpy(CINVCELRCV.FR_SITE_ID, IWIPCELHUI.FR_SITE_ID, sizeof(IWIPCELHUI.FR_SITE_ID));
		memcpy(CINVCELRCV.MATERIALDEFINITIONID, IWIPCELHUI.MATERIALDEFINITIONID, sizeof(IWIPCELHUI.MATERIALDEFINITIONID));
		memcpy(CINVCELRCV.ORI_QTY, IWIPCELHUI.ORI_QTY, sizeof(IWIPCELHUI.ORI_QTY));
		memcpy(CINVCELRCV.UNIT_ID, IWIPCELHUI.UNIT_ID, sizeof(IWIPCELHUI.UNIT_ID));
		memcpy(CINVCELRCV.MIDDLEBOXID, IWIPCELHUI.MIDDLEBOXID, sizeof(IWIPCELHUI.MIDDLEBOXID));
		memcpy(CINVCELRCV.LARGEBOXID, IWIPCELHUI.LARGEBOXID, sizeof(IWIPCELHUI.LARGEBOXID));
		memcpy(CINVCELRCV.CELLTYPE, IWIPCELHUI.CELLTYPE, sizeof(IWIPCELHUI.CELLTYPE));
		memcpy(CINVCELRCV.CELLBOXBARCODE, IWIPCELHUI.CELLBOXBARCODE, sizeof(IWIPCELHUI.CELLBOXBARCODE));
		CINVCELRCV.INSPECT_STATUS = IWIPCELHUI.INSPECT_STATUS;
		CINVCELRCV.BLOCK_STATUS = IWIPCELHUI.BLOCK_STATUS;
		memcpy(CINVCELRCV.BLOCK_DATE, IWIPCELHUI.BLOCK_DATE, sizeof(IWIPCELHUI.BLOCK_DATE));
		memcpy(CINVCELRCV.POWERGRADE, IWIPCELHUI.POWERGRADE, sizeof(IWIPCELHUI.POWERGRADE));
		memcpy(CINVCELRCV.QUALITYGRADE, IWIPCELHUI.QUALITYGRADE, sizeof(IWIPCELHUI.QUALITYGRADE));
		memcpy(CINVCELRCV.CELLPRODUCTDATE, IWIPCELHUI.CELLPRODUCTDATE, sizeof(CINVCELRCV.CELLPRODUCTDATE));
		memcpy(CINVCELRCV.CELLGRADE, IWIPCELHUI.CELLGRADE, sizeof(CINVCELRCV.CELLGRADE));

		//23.06.05 말레이시아 셀 입고을 GR정보가 별도로 존재함
		memcpy(CINVCELRCV.GR_BATCHNO, IWIPCELHUI.BATCHNO, sizeof(IWIPCELHUI.BATCHNO));
		//23.06.05 말레이시아 셀 입고을 GR정보가 별도로 존재함


		CINVCELRCV.ERP_MW = IWIPCELHUI.ERP_MW;
		CINVCELRCV.SORTER_MW = IWIPCELHUI.SORTER_MW;
		CINVCELRCV.AVG_NCELL = IWIPCELHUI.AVG_NCELL;
		CINVCELRCV.AVG_ISC = IWIPCELHUI.AVG_ISC;
		CINVCELRCV.AVG_UOC = IWIPCELHUI.AVG_UOC;
		CINVCELRCV.AVG_FF = IWIPCELHUI.AVG_FF;
		CINVCELRCV.AVG_RS = IWIPCELHUI.AVG_RS;
		CINVCELRCV.AVG_RSH = IWIPCELHUI.AVG_RSH;
		CINVCELRCV.AVG_TEMPERATURE = IWIPCELHUI.AVG_TEMPERATURE;
		//memcpy(CINVCELRCV.WORKDAY, IWIPCELHUI.WORKDAY, sizeof(IWIPCELHUI.WORKDAY));
		memcpy(CINVCELRCV.PRODUCTCLASSID, IWIPCELHUI.PRODUCTCLASSID, sizeof(IWIPCELHUI.PRODUCTCLASSID));
		memcpy(CINVCELRCV.PRODUCTDEFINITIONTYPE, IWIPCELHUI.PRODUCTDEFINITIONTYPE, sizeof(IWIPCELHUI.PRODUCTDEFINITIONTYPE));
		memcpy(CINVCELRCV.MATERIALDEFINITIONID, IWIPCELHUI.MATERIALDEFINITIONID, sizeof(IWIPCELHUI.MATERIALDEFINITIONID));
		
		CDB_update_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
		{
			/*TRS.add_fieldmsg(out_node, "CINVCELRCV UPDATE", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cinvcelrcv(1);
			return MP_FALSE;*/
		}

		/*CDB_select_cinvcelrcv(1,&CINVCELRCV);
		{
			if(DB_error_code != DB_SUCCESS)
			{
				TRS.add_fieldmsg(out_node, "CINVCELRCV SELECT", MP_NVST);			
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));				
				return MP_FALSE;
			}
		}

		CDB_update_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
		{
			TRS.add_fieldmsg(out_node, "CINVCELRCV UPDATE", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}*/

		// DELETE
		CDB_delete_iwipcelhui(1,&IWIPCELHUI);
		DB_commit();
		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		seq++;
	}

	return MP_TRUE;
}