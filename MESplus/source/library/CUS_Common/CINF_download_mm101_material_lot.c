/*******************************************************************************

    System      : MESplus
    Module      : Material lot setup
    File Name   : CINF_download_mm101_material_lot.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.05  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>
#include <INVCore_common.h>

int CUS_INTERFACE_DOWNLOAD_MATERIAL_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Material Lot
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Material_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_MATERIAL_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Lot", out_node);

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
    CUS_INTERFACE_DOWNLOAD_MATERIAL_LOT()
        - ERP->MES Material Lot
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_MATERIAL_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IINVMATLOT_TAG IINVMATLOT;
	struct IBAKMATLOT_TAG IBAKMATLOT;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct CINVLOTHIS_TAG CINVLOTHIS;
	struct MINVMATSTS_TAG MINVMATSTS;

	TRSNode *in_node1;
	TRSNode *out_node1;
	char s_sys_time[14];
	int seq = 1;

	// PROCESS LOG PRINT
	LOG_head("CINF_INTERFACE_DOWNLOAD_MATERIAL_LOT");
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
	CDB_init_iinvmatlot(&IINVMATLOT);
	CDB_open_iinvmatlot(2, &IINVMATLOT);
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
			TRS.add_fieldmsg(out_node, "IINVMATLOT OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVMATLOT.DOC_ID), IINVMATLOT.DOC_ID);			
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
		CDB_fetch_iinvmatlot(2, &IINVMATLOT);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_iinvmatlot(2);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IINVLOTSTS OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVMATLOT.DOC_ID), IINVMATLOT.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iinvmatlot(2);
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
		TRS.add_string(in_node1, "MAT_ID", IINVMATLOT.MATE_NO, sizeof(IINVMATLOT.MATE_NO));
		TRS.add_int(in_node1, "MAT_VER", 1);
		TRS.add_string(in_node1, "OPER", "M0010", strlen("M0010"));
		TRS.add_double(in_node1, "IN_QTY_1", COM_atol(IINVMATLOT.ORI_QTY,sizeof(IINVMATLOT.ORI_QTY)));
		TRS.add_double(in_node1, "ALLOC_QTY", COM_atol(IINVMATLOT.ORI_QTY,sizeof(IINVMATLOT.ORI_QTY)));
		TRS.add_string(in_node1, "TRAN_CMF_1", IINVMATLOT.CMF_1, sizeof(IINVMATLOT.CMF_1));
        TRS.add_string(in_node1, "TRAN_CMF_2", IINVMATLOT.CMF_2, sizeof(IINVMATLOT.CMF_2));
        TRS.add_string(in_node1, "TRAN_CMF_3", IINVMATLOT.CMF_3, sizeof(IINVMATLOT.CMF_3));
        TRS.add_string(in_node1, "TRAN_CMF_4", IINVMATLOT.CMF_4, sizeof(IINVMATLOT.CMF_4));
		TRS.add_string(in_node1, "TRAN_CMF_5", IINVMATLOT.CMF_5, sizeof(IINVMATLOT.CMF_5));
        

		// MINVMATSTS에서 MAT_ID별 LAST_HIST_SEQ를 가져온다.
		DBC_init_minvmatsts(&MINVMATSTS);
		memcpy(MINVMATSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MINVMATSTS.MAT_ID, IINVMATLOT.MATE_NO, sizeof(MINVMATSTS.MAT_ID));
		MINVMATSTS.MAT_VER = 1;
		memcpy(MINVMATSTS.OPER, "M0010", strlen("M0010"));

		DBC_select_minvmatsts(1,&MINVMATSTS);
		if(DB_error_code == DB_NOT_FOUND) {
			TRS.add_int(in_node1,"LAST_HIST_SEQ",0);
		} 
		else {			
			TRS.add_int(in_node1,"LAST_HIST_SEQ",MINVMATSTS.LAST_HIST_SEQ);
		}
		
		// INSERT Core Table
 		if(INV_IN_INVENTORY(s_msg_code, in_node1, out_node1) == MP_FALSE){
			DB_rollback();
            /*
			gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Lot", out_node);
			COM_set_field_db_msg(out_node, out_node1);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
 			TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
			memcpy(IINVMATLOT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_iinvmatlot(2,&IINVMATLOT);
			DB_commit();
			continue;
            */

            //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
            COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Lot", out_node1);
			TRS.copy(IINVMATLOT.RETURN_MSG, sizeof(IINVMATLOT.RETURN_MSG), out_node1, "MSG");
			CDB_update_iinvmatlot(2,&IINVMATLOT);
			
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			DB_commit();
			continue;
		}

		// BACKUP
        CDB_init_ibakmatlot(&IBAKMATLOT);
		memcpy(IBAKMATLOT.DOC_ID, IINVMATLOT.DOC_ID, sizeof(struct IINVMATLOT_TAG));
		CDB_delete_ibakmatlot(1, &IBAKMATLOT);
        CDB_insert_ibakmatlot(&IBAKMATLOT);
        if(DB_error_code != DB_SUCCESS)
        {
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;			
            TRS.add_fieldmsg(out_node, "IBAKMATLOT INSERT", MP_NVST);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_field_db_msg(out_node, out_node1);
			//CDB_close_ibakmatlot(1);
            // IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
            // DB OPEN / FETCH CASE CURSOR CLOSE
            CDB_close_iinvmatlot(2);

			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			return MP_FALSE;
        }


		CDB_select_ibakmatlot(1,&IBAKMATLOT);
		if(DB_error_code != DB_NOT_FOUND) 
		{
			CDB_update_ibakmatlot(1, &IBAKMATLOT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "BAS-0004");
				TRS.add_fieldmsg(out_node, "IBAKMATLOT UPDATE", MP_NVST);			
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;				
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				//CDB_close_ibakmatlot(1);
                // IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
                // DB OPEN / FETCH CASE CURSOR CLOSE
                CDB_close_iinvmatlot(2);

				TRS.free_node(in_node1);
				TRS.free_node(out_node1);
				return MP_FALSE;
			}
		} else {
			CDB_insert_ibakmatlot(&IBAKMATLOT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "BAS-0004");
				TRS.add_fieldmsg(out_node, "IBAKMATLOT INSERT", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				//CDB_close_ibakmatlot(1);
                // IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
                // DB OPEN / FETCH CASE CURSOR CLOSE
                CDB_close_iinvmatlot(2);
				
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(in_node1);
				TRS.free_node(out_node1);
				return MP_FALSE;
			}
		}

		// INSERT CUSTOMER TABLE(CINVLOTSTS)
		CDB_init_cinvlotsts(&CINVLOTSTS);
		memcpy(CINVLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	    memcpy(CINVLOTSTS.INV_LOT_ID, IINVMATLOT.VENDOR_BARCD, sizeof(IINVMATLOT.VENDOR_BARCD));
		memcpy(CINVLOTSTS.VENDOR_BARCD, IINVMATLOT.VENDOR_BARCD, sizeof(IINVMATLOT.VENDOR_BARCD));
		memcpy(CINVLOTSTS.OPER, "M0010", strlen("M0010"));
		memcpy(CINVLOTSTS.MAT_ID, IINVMATLOT.MATE_NO, sizeof(CINVLOTSTS.MAT_ID));
		memcpy(CINVLOTSTS.INV_MAT_TYPE, "M", strlen("M"));
		memcpy(CINVLOTSTS.VENDOR_ID, IINVMATLOT.VENDOR_CREDITOR, sizeof(CINVLOTSTS.VENDOR_ID));
		memcpy(CINVLOTSTS.VENDOR_MAT_TYPE, "M", strlen("M"));			
		memcpy(CINVLOTSTS.BATCH_NO, IINVMATLOT.BATCH_NO, sizeof(IINVMATLOT.BATCH_NO));
		memcpy(CINVLOTSTS.VEN_BATCH_NO, IINVMATLOT.BATCH_NO, sizeof(IINVMATLOT.BATCH_NO));
		memcpy(CINVLOTSTS.VENDOR_MAT_ID, IINVMATLOT.MATE_NO, sizeof(IINVMATLOT.MATE_NO));
		CINVLOTSTS.QTY_1 = COM_atoi(IINVMATLOT.ORI_QTY,sizeof(IINVMATLOT.ORI_QTY));
		memcpy(CINVLOTSTS.UNIT_1, IINVMATLOT.UNIT_ID, sizeof(CINVLOTSTS.UNIT_1));
		memcpy(CINVLOTSTS.VENDOR_LOTID, IINVMATLOT.VENDOR_LOTID, sizeof(IINVMATLOT.VENDOR_LOTID));
		CINVLOTSTS.LAST_HIST_SEQ = seq;
		memcpy(CINVLOTSTS.LAST_TRAN_TIME, s_sys_time, sizeof(CINVLOTSTS.LAST_TRAN_TIME));
		memcpy(CINVLOTSTS.LAST_TRAN_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
		//memcpy(CINVLOTSTS.LAST_TRAN_TYPE, IINVMATLOT.MATE_NO, sizeof(IINVMATLOT.MATE_NO));
		//memcpy(CINVLOTSTS.PUR_ORDER_NO, IINVMATLOT.MATE_NO, sizeof(IINVMATLOT.MATE_NO));
		//memcpy(CINVLOTSTS.PUR_TYPE, IINVMATLOT.MATE_NO, sizeof(IINVMATLOT.MATE_NO));
		//memcpy(CINVLOTSTS.PACKAGE_TYPE, IINVMATLOT.MATE_NO, sizeof(IINVMATLOT.MATE_NO));
		memcpy(CINVLOTSTS.CMF_1, IINVMATLOT.CMF_1, sizeof(IINVMATLOT.CMF_1));
		memcpy(CINVLOTSTS.CMF_2, IINVMATLOT.CMF_2, sizeof(IINVMATLOT.CMF_2));
		memcpy(CINVLOTSTS.CMF_3, IINVMATLOT.CMF_3, sizeof(IINVMATLOT.CMF_3));
		memcpy(CINVLOTSTS.CMF_4, IINVMATLOT.CMF_4, sizeof(IINVMATLOT.CMF_4));
		memcpy(CINVLOTSTS.CMF_5, IINVMATLOT.CMF_5, sizeof(IINVMATLOT.CMF_5));
		memcpy(CINVLOTSTS.INPUT_TIME, s_sys_time, sizeof(CINVLOTSTS.LAST_TRAN_TIME));
		CDB_insert_cinvlotsts(&CINVLOTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            CDB_update_cinvlotsts(1,&CINVLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				TRS.add_fieldmsg(out_node, "CINVLOTSTS UPDATE", MP_NVST);			
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				//CDB_close_cinvlothis(1);
                // IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
                // DB OPEN / FETCH CASE CURSOR CLOSE
                CDB_close_iinvmatlot(2);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

                TRS.free_node(in_node1);
				TRS.free_node(out_node1);
				return MP_FALSE;
			}
		}

		// INSERT CUSTOMER TABLE(CINVLOTHIS)
		CDB_init_cinvlothis(&CINVLOTHIS);
		memcpy(CINVLOTHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CINVLOTHIS.INV_LOT_ID, CINVLOTSTS.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID));
		
		//23.05.03 쿼리 개선
		CINVLOTHIS.HIST_SEQ = (int) CDB_select_cinvlothis_scalar(2,&CINVLOTHIS) ;
		if(CINVLOTHIS.HIST_SEQ == 0)		//데이터가 없으면 1로 셋팀
		{
			CINVLOTHIS.HIST_SEQ = seq;
		}
		else
		{
			CINVLOTHIS.HIST_SEQ++;
		}

		//23.05.03 쿼리 개선

		// 기존 데이터가 없으면 Default로 셋팅한다.
		/*CDB_select_cinvlothis(2,&CINVLOTHIS);
		if(DB_error_code == DB_NOT_FOUND) {
			CINVLOTHIS.HIST_SEQ = seq;
		} else {
			CINVLOTHIS.HIST_SEQ++;
		}*/
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
            if(DB_error_code != DB_NOT_FOUND)
            {             
                CDB_update_cinvlothis(1, &CINVLOTHIS);
				if(DB_error_code != DB_SUCCESS)
				{
					TRS.add_fieldmsg(out_node, "CINVLOTHIS UPDATE", MP_NVST);			
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;					
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					//CDB_close_cinvlothis(1);
                    //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
                    // DB OPEN / FETCH CASE CURSOR CLOSE
                    CDB_close_iinvmatlot(2);

    				TRS.free_node(in_node1);
				    TRS.free_node(out_node1);

					return MP_FALSE;
				}
            }			
		}

		// DELETE
		CDB_delete_iinvmatlot(1,&IINVMATLOT);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		DB_commit();
		seq++;
	}

	return MP_TRUE;
}
