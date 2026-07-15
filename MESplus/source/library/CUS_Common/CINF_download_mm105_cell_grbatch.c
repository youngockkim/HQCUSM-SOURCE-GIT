/*******************************************************************************

    System      : MESplus
    Module      : Cell GR Batch Information
    File Name   : CINF_download_mm105_cell_grbatch.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.07  SW.HWANG
	2     2019.02.06  JH.JUNG		 
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>
#include <INVCore_common.h>

int CUS_INTERFACE_DOWNLOAD_CELL_GRBATCH(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Cell GR Batch Information
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Cell_Grbatch(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_CELL_GRBATCH(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Cell_Grbatch", out_node);

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
    CUS_INTERFACE_DOWNLOAD_CELL_GRBATCH()
        - ERP->MES  Cell GR Batch Information
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_CELL_GRBATCH(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IWIPCELGRB_TAG IWIPCELGRB;
	struct IBAKCELGRB_TAG IBAKCELGRB;
//	struct CINVLOTSTS_TAG CINVLOTSTS;
//	struct CINVLOTHIS_TAG CINVLOTHIS;
	struct CINVCELRCV_TAG CINVCELRCV;
	struct MINVMATSTS_TAG MINVMATSTS;

	TRSNode *tran_in_node;
	TRSNode *tran_out_node;

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
	CDB_init_iwipcelgrb(&IWIPCELGRB);
	CDB_open_iwipcelgrb(2, &IWIPCELGRB);
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
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPCELGRB.DOC_ID), IWIPCELGRB.DOC_ID);			
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
		CDB_fetch_iwipcelgrb(2, &IWIPCELGRB);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_iwipcelgrb(2);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPCELGRB OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPCELGRB.DOC_ID), IWIPCELGRB.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipcelgrb(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		tran_in_node = TRS.create_node("Transfer_Inventory_In");
		tran_out_node = TRS.create_node("Cmn_Out");
		TRS.add_char(tran_in_node, "LANGUAGE", '2');
		TRS.set_string(tran_in_node, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.set_string(tran_in_node, "USERID", MODULE_EAP, strlen(MODULE_EAP));
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "BACK_TIME", s_sys_time, sizeof(s_sys_time));
		//TRS.add_string(tran_in_node, "MAT_ID", IWIPCELGRB.P, sizeof(IWIPCELGRB.SMALLBOXID));
		TRS.add_int(tran_in_node, "MAT_VER", 1);
		TRS.add_string(tran_in_node, "OPER", HQCEL_M1_RAWMAT_STOCK_OPER, strlen(HQCEL_M1_RAWMAT_STOCK_OPER));  // 원자재 창고
		TRS.add_string(tran_in_node, "TO_MAT_ID", IWIPCELGRB.SMALLBOXID, sizeof(IWIPCELGRB.SMALLBOXID));
		TRS.add_int(tran_in_node, "TO_MAT_VER", 1);
		TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_FCELL_MOVE_OPER, strlen(HQCEL_M1_FCELL_MOVE_OPER));  //FCELL MOVE STOCK(OPERATION STOCK)
		TRS.add_double(tran_in_node, "TRANSFER_QTY_1", 1);

		// MINVMATSTS에서 MAT_ID별 LAST_HIST_SEQ를 가져온다.
		DBC_init_minvmatsts(&MINVMATSTS);
		memcpy(MINVMATSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MINVMATSTS.MAT_ID, IWIPCELGRB.SMALLBOXID, sizeof(MINVMATSTS.MAT_ID));
		MINVMATSTS.MAT_VER = 1;
		memcpy(MINVMATSTS.OPER, "M0010", strlen("M0010"));

		DBC_select_minvmatsts(1,&MINVMATSTS);
		if(DB_error_code == DB_NOT_FOUND) {
			TRS.add_int(tran_in_node,"LAST_HIST_SEQ",0);
		}
		else {
			TRS.add_int(tran_in_node,"LAST_HIST_SEQ",MINVMATSTS.LAST_HIST_SEQ);
		}

		// INSERT Core Table
 	//	if(INV_TRANSFER_INVENTORY(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE){
		//	/**
		//	DB_rollback();
		//	gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //          gs_log_type.category = MP_LOG_CATE_VIEW;
		//	COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Cell_GR_Batch", out_node);
		//	COM_set_field_db_msg(out_node, tran_out_node);
		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	TRS.set_string(tran_in_node, "RETURN_TYPE", "E", strlen("E"));
 	//		TRS.set_string(tran_in_node, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
		//	memcpy(IWIPCELGRB.RETURN_MSG, s_msg_code, strlen(s_msg_code));
		//	CDB_update_iwipcelgrb(2,&IWIPCELGRB);
		//	DB_commit();
		//	continue;
		//	**/
		//	//참고 데이터로 할려고 했는데.....CELRCV 를 뒤지거나..IINVLOTSTS 를 해야하는데..뭥미..
		//}

		// BACKUP
        CDB_init_ibakcelgrb(&IBAKCELGRB);
		memcpy(IBAKCELGRB.DOC_ID, IWIPCELGRB.DOC_ID, sizeof(struct IWIPCELGRB_TAG));
		CDB_delete_ibakcelgrb(1, &IBAKCELGRB);
		CDB_insert_ibakcelgrb(&IBAKCELGRB);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "BAS-0004");			
			TRS.add_fieldmsg(out_node, "IBAKCELGRB INSERT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			//CDB_close_ibakcelgrb(1);
            
            //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
            // DB OPEN / FETCH CASE CURSOR CLOSE
            CDB_close_iwipcelgrb(2);
            TRS.free_node(tran_in_node);
		    TRS.free_node(tran_out_node);

			return MP_FALSE;
		}

		// INSERT CUSTOMER TABLE(CINVLOTSTS)
		/*CDB_init_cinvlotsts(&CINVLOTSTS);
		memcpy(CINVLOTSTS.MAT_ID, IWIPCELGRB.GI_BATCHNO, sizeof(CINVLOTSTS.MAT_ID));
		CDB_insert_cinvlotsts(&CINVLOTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                CDB_update_cinvlotsts(1, &CINVLOTSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					TRS.add_fieldmsg(out_node, "CINVLOTSTS INSERT", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_cinvlotsts(1);
					return MP_FALSE;
				}
            }
		}*/

		// INSERT CUSTOMER TABLE(CINVLOTHIS)
		// 로직이 엄청 이상해서 일단 무시함.. 얘도 참고데이터임. CINVLOTSTS 쓸려면 살릴것..
		/*CDB_init_cinvlothis(&CINVLOTHIS);
		memcpy(CINVLOTHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CINVLOTHIS.INV_LOT_ID, CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));
		 기존 데이터가 없으면 Default로 셋팅한다.
		CDB_select_cinvlothis(2,&CINVLOTHIS);
		if(DB_error_code == DB_NOT_FOUND) {
			CINVLOTHIS.HIST_SEQ = seq;
		} else {
			CINVLOTHIS.HIST_SEQ++;
		}
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
			strcpy(s_msg_code, "BAS-0004");
			TRS.add_fieldmsg(out_node, "CINVLOTHIS INSERT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_field_db_msg(out_node, tran_out_node);
			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}*/

		// CUSTOMER TABLE(CINVCELRCV)
		CDB_init_cinvcelrcv(&CINVCELRCV);
		memcpy(CINVCELRCV.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CINVCELRCV.INV_LOT_ID, IWIPCELGRB.SMALLBOXID, sizeof(IWIPCELGRB.SMALLBOXID));
		
		CDB_select_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
        {
			if(DB_error_code == DB_NOT_FOUND)
			{
				memcpy(CINVCELRCV.WORKDAY, s_sys_time, sizeof(s_sys_time));
				memcpy(CINVCELRCV.SMALLBOXID, IWIPCELGRB.SMALLBOXID, sizeof(IWIPCELGRB.SMALLBOXID));
				CDB_insert_cinvcelrcv(&CINVCELRCV);
			}
		}

		memcpy(CINVCELRCV.ACTION_TYPE, IWIPCELGRB.ACTION_TYPE, sizeof(IWIPCELGRB.ACTION_TYPE));		
		memcpy(CINVCELRCV.SITE_ID, IWIPCELGRB.SITE_ID, sizeof(IWIPCELGRB.SITE_ID));
		memcpy(CINVCELRCV.GR_BATCHNO, IWIPCELGRB.GR_BATCHNO, sizeof(IWIPCELGRB.GR_BATCHNO));
		memcpy(CINVCELRCV.GR_DATE, IWIPCELGRB.GR_DATE, sizeof(IWIPCELGRB.GR_DATE));
		memcpy(CINVCELRCV.GI_BATCH_NO, IWIPCELGRB.GI_BATCHNO, sizeof(IWIPCELGRB.GI_BATCHNO));
		memcpy(CINVCELRCV.WORKTIME, IWIPCELGRB.INF_TIME, sizeof(IWIPCELGRB.INF_TIME));

		if (COM_isspace(CINVCELRCV.WORKTIME, sizeof(CINVCELRCV.WORKTIME)) != MP_FALSE)
		{
			memcpy(CINVCELRCV.WORKTIME, s_sys_time, 14);
		}

		CINVCELRCV.STATUS_FLAG = IWIPCELGRB.DATA_FLAG;

		CDB_update_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
        {
           /* TRS.add_fieldmsg(out_node, "CINVCELRCV UPDATE", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cinvcelrcv(1);
			return MP_FALSE;*/

            //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
            // DB OPEN / FETCH CASE CURSOR CLOSE
            TRS.free_node(tran_in_node);
		    TRS.free_node(tran_out_node);

			continue;
		}
		
		// DELETE
		CDB_delete_iwipcelgrb(1,&IWIPCELGRB);
		DB_commit();
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		seq++;
	}

	return MP_TRUE;
}