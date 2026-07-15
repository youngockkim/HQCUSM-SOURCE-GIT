/*******************************************************************************

    System      : MESplus
    Module      : Stock Transfer Information
    File Name   : CINF_download_mm104_stock_transfer_gerp.c
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

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>
#include <INVCore_common.h>

int CUS_INTERFACE_DOWNLOAD_CELL_MOVE_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Stock Transfer Information
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Stock_Transfer_Gerp(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_STOCK_TRANSFER_GERP(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Stock_Transfer_Gerp", out_node);

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
    CUS_INTERFACE_DOWNLOAD_STOCK_TRANSFER_GERP()
        - ERP->MES Stock Transfer Information
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_STOCK_TRANSFER_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IINVSTKTRS_TAG IINVSTKTRS;
	struct IBAKSTKTRS_TAG IBAKSTKTRS;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct CINVLOTHIS_TAG CINVLOTHIS;
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
	CDB_init_iinvstktrs(&IINVSTKTRS);
	CDB_open_iinvstktrs(2, &IINVSTKTRS);
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
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVSTKTRS.DOC_ID), IINVSTKTRS.DOC_ID);			
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
		CDB_fetch_iinvstktrs(2, &IINVSTKTRS);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_iinvstktrs(2);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IINVSTKTRS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVSTKTRS.DOC_ID), IINVSTKTRS.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iinvstktrs(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
		
		in_node1 = TRS.create_node("Transfer_Inventory_In");
		out_node1 = TRS.create_node("Cmn_Out");

		TRS.add_char(in_node1, "LANGUAGE", '2');
		TRS.set_string(in_node1, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.set_string(in_node1, "USERID", MODULE_EAP, strlen(MODULE_EAP));
		TRS.add_char(in_node1, "PROCSTEP", '1');
		
		// MINVMATSTS에서 MAT_ID별 LAST_HIST_SEQ를 가져온다.
		DBC_init_minvmatsts(&MINVMATSTS);
		memcpy(MINVMATSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MINVMATSTS.MAT_ID, IINVSTKTRS.MATE_NO, sizeof(MINVMATSTS.MAT_ID));
		MINVMATSTS.MAT_VER = 1;
		memcpy(MINVMATSTS.OPER, HQCEL_M1_RAWMAT_STOCK_OPER, strlen(HQCEL_M1_RAWMAT_STOCK_OPER));

		DBC_select_minvmatsts(1,&MINVMATSTS);
		if(DB_error_code == DB_NOT_FOUND) {
			TRS.add_int(in_node1,"LAST_HIST_SEQ",0);
		} 
		else {
			TRS.add_int(in_node1,"LAST_HIST_SEQ",MINVMATSTS.LAST_HIST_SEQ);
		}
		TRS.add_int(in_node1, "MAT_VER", 1);
		TRS.add_string(in_node1, "BACK_TIME", s_sys_time, sizeof(s_sys_time));
		TRS.add_string(in_node1, "MAT_ID", IINVSTKTRS.MATE_NO, sizeof(IINVSTKTRS.MATE_NO));
		TRS.add_int(in_node1, "MAT_VER", 1);
		TRS.add_string(in_node1, "OPER", HQCEL_M1_RAWMAT_STOCK_OPER, strlen(HQCEL_M1_RAWMAT_STOCK_OPER));  // 원자재 창고
		TRS.add_string(in_node1, "TO_MAT_ID", IINVSTKTRS.MATE_NO, sizeof(IINVSTKTRS.MATE_NO));
		TRS.add_int(in_node1, "TO_MAT_VER", 1);
		TRS.add_string(in_node1, "TO_OPER",HQCEL_M1_FCELL_MOVE_OPER, strlen(HQCEL_M1_FCELL_MOVE_OPER));  //FCELL MOVE STOCK(OPERATION STOCK)
		TRS.add_double(in_node1, "TRANSFER_QTY_1", COM_atol(IINVSTKTRS.QTY,sizeof(IINVSTKTRS.QTY)));
		

		// INSERT Core Table
		if(INV_TRANSFER_INVENTORY(s_msg_code, in_node1, out_node1) == MP_FALSE){
			DB_rollback();
            

            //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
            COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Stock_Transfer_Gerp", out_node1);
			TRS.copy(IINVSTKTRS.RETURN_MSG, sizeof(IINVSTKTRS.RETURN_MSG), out_node1, "MSG");
			CDB_update_iinvstktrs(2,&IINVSTKTRS);
			
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			DB_commit();
			continue;
		}

		// BACKUP
        CDB_init_ibakstktrs(&IBAKSTKTRS);
		memcpy(IBAKSTKTRS.DOC_ID, IBAKSTKTRS.DOC_ID, sizeof(struct IINVSTKTRS_TAG));

		CDB_select_ibakstktrs(1,&IBAKSTKTRS);
		if(DB_error_code != DB_NOT_FOUND)
		{
			CDB_update_ibakstktrs(1, &IBAKSTKTRS);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "BAS-0026");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "BAS-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "IBAKMATLOT UPDATE", MP_NVST);			
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				//CDB_close_ibakstktrs(1);
                // IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
                // DB OPEN / FETCH CASE CURSOR CLOSE
                CDB_close_iinvstktrs(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(in_node1);
				TRS.free_node(out_node1);
				return MP_FALSE;
			}
		} else {
			CDB_insert_ibakstktrs(&IBAKSTKTRS);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "BAS-0026");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "BAS-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				TRS.add_fieldmsg(out_node, "IBAKSTKTRS INSERT", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				//CDB_close_ibakstktrs(1);
                // IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
                // DB OPEN / FETCH CASE CURSOR CLOSE
                CDB_close_iinvstktrs(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(in_node1);
				TRS.free_node(out_node1);
				return MP_FALSE;
			}
		}

		CDB_delete_ibakstktrs(1, &IBAKSTKTRS);
		CDB_insert_ibakstktrs(&IBAKSTKTRS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		//[23.06.09]
		//6월 2일 ERP 고도화 부터 데이터가 전송됨.
		//

		//// INSERT CUSTOMER TABLE(CINVLOTSTS)		
		//memcpy(CINVLOTSTS.MAT_ID, IINVSTKTRS.MATE_NO, sizeof(CINVLOTSTS.MAT_ID));
		//CDB_delete_cinvlotsts(1, &CINVLOTSTS);

		//memcpy(CINVLOTSTS.INPUT_TIME, s_sys_time, sizeof(CINVLOTSTS.INPUT_TIME));
		//CDB_insert_cinvlotsts(&CINVLOTSTS);
		//if(DB_error_code != DB_SUCCESS)
  //      {
  //          // DO NOTHING
		//}

		//// INSERT CUSTOMER TABLE(CINVLOTHIS)
		//CDB_init_cinvlothis(&CINVLOTHIS);
		//memcpy(CINVLOTHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		//memcpy(CINVLOTHIS.INV_LOT_ID, CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));

		//// 기존 데이터가 없으면 Default로 셋팅한다.
		////CDB_select_cinvlothis(2,&CINVLOTHIS);
		///* - [GERP PROJECT] 시작****************************************************************/
		//CDB_select_cinvlothis(3, &CINVLOTHIS);	// [GERP PROJECT] 추가
		///* - [GERP PROJECT] 끝*****************************************************************/
		//if(DB_error_code == DB_NOT_FOUND) {
		//	CINVLOTHIS.HIST_SEQ = seq;
		//} else {
		//	CINVLOTHIS.HIST_SEQ++;
		//}
		//memcpy(CINVLOTHIS.VENDOR_BARCD, CINVLOTSTS.VENDOR_BARCD, sizeof(CINVLOTSTS.VENDOR_BARCD));
		//memcpy(CINVLOTHIS.OPER, CINVLOTSTS.OPER, sizeof(CINVLOTSTS.OPER));
		//memcpy(CINVLOTHIS.MAT_ID, CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));
		//memcpy(CINVLOTHIS.INV_MAT_TYPE, CINVLOTSTS.INV_MAT_TYPE, sizeof(CINVLOTSTS.INV_MAT_TYPE));
		//memcpy(CINVLOTHIS.VENDOR_ID, CINVLOTSTS.VENDOR_ID, sizeof(CINVLOTSTS.VENDOR_ID));
		//memcpy(CINVLOTHIS.LOCATION, CINVLOTSTS.LOCATION, sizeof(CINVLOTSTS.LOCATION));
		//memcpy(CINVLOTHIS.BATCH_NO, CINVLOTSTS.BATCH_NO, sizeof(CINVLOTSTS.BATCH_NO));
		//CINVLOTHIS.QTY_1 = CINVLOTSTS.QTY_1;
		//memcpy(CINVLOTHIS.UNIT_1, CINVLOTSTS.UNIT_1, sizeof(CINVLOTSTS.UNIT_1));
		//memcpy(CINVLOTHIS.VENDOR_LOTID, CINVLOTSTS.VENDOR_LOTID, sizeof(CINVLOTSTS.VENDOR_LOTID));
		//memcpy(CINVLOTHIS.LAST_TRAN_TIME, CINVLOTSTS.LAST_TRAN_TIME, sizeof(CINVLOTSTS.LAST_TRAN_TIME));
		//memcpy(CINVLOTHIS.LAST_TRAN_USER_ID, CINVLOTSTS.LAST_TRAN_USER_ID, sizeof(CINVLOTSTS.LAST_TRAN_USER_ID));
		//memcpy(CINVLOTHIS.LAST_TRAN_TYPE, CINVLOTSTS.LAST_TRAN_TYPE, sizeof(CINVLOTSTS.LAST_TRAN_TYPE));		
		//memcpy(CINVLOTHIS.INPUT_TIME, CINVLOTSTS.INPUT_TIME, sizeof(CINVLOTSTS.INPUT_TIME));
		//memcpy(CINVLOTHIS.PROD_TIME, CINVLOTSTS.PROD_TIME, sizeof(CINVLOTSTS.PROD_TIME));
		//memcpy(CINVLOTHIS.CMF_1, CINVLOTSTS.CMF_1, sizeof(CINVLOTSTS.CMF_1));
		//memcpy(CINVLOTHIS.CMF_2, CINVLOTSTS.CMF_2, sizeof(CINVLOTSTS.CMF_2));
		//memcpy(CINVLOTHIS.CMF_3, CINVLOTSTS.CMF_3, sizeof(CINVLOTSTS.CMF_3));
		//memcpy(CINVLOTHIS.CMF_4, CINVLOTSTS.CMF_4, sizeof(CINVLOTSTS.CMF_4));
		//memcpy(CINVLOTHIS.CMF_5, CINVLOTSTS.CMF_5, sizeof(CINVLOTSTS.CMF_5));
		//memcpy(CINVLOTHIS.CMF_6, CINVLOTSTS.CMF_6, sizeof(CINVLOTSTS.CMF_6));
		//memcpy(CINVLOTHIS.CMF_7, CINVLOTSTS.CMF_7, sizeof(CINVLOTSTS.CMF_7));
		//memcpy(CINVLOTHIS.CMF_8, CINVLOTSTS.CMF_8, sizeof(CINVLOTSTS.CMF_8));
		//memcpy(CINVLOTHIS.CMF_9, CINVLOTSTS.CMF_9, sizeof(CINVLOTSTS.CMF_9));
		//memcpy(CINVLOTHIS.CMF_10, CINVLOTSTS.CMF_10, sizeof(CINVLOTSTS.CMF_10));
		//
		//CDB_insert_cinvlothis(&CINVLOTHIS);
		//if(DB_error_code != DB_SUCCESS)
  //      {
  //          TRS.add_fieldmsg(out_node, "CINVLOTHIS INSERT", MP_NVST);			
		//	TRS.add_dberrmsg(out_node, DB_error_msg);
		//	gs_log_type.type = MP_LOG_ERROR;
		//	gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//	gs_log_type.category = MP_LOG_CATE_VIEW;
		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	//CDB_close_cinvlothis(1);
  //          // IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
  //          // DB OPEN / FETCH CASE CURSOR CLOSE
  //          CDB_close_iinvstktrs(2);
  //          TRS.free_node(in_node1);
		//    TRS.free_node(out_node1);

		//	return MP_FALSE;
		//}


		// DELETE
		CDB_delete_iinvstktrs(1,&IINVSTKTRS);
		DB_commit();
		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		seq++;		
	}

	return MP_TRUE;
}