/*******************************************************************************

    System      : MESplus
    Module      : Module_Rework Product Order_Component 정보 DownLoad
    File Name   : CINF_download_pp108_production_Rework_Gerp.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2023.02.08  Junesuk.Lee	 Create
	2     2023.02.24  Jaedong.Park   Update
    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include "CUS_HQCUSM_common.h"

int CUS_INTERFACE_DOWNLOAD_PRODUCTION_REWORK_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);// IF-PP-304 Module_Rework Product Order_Component

int CWIP_Move_Lot(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
    Power_Range()
        - ERP->MES Production Order Rework 정보 DownLoad
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Production_Rework_Gerp(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_PRODUCTION_REWORK_GERP(s_msg_code, in_node, out_node);// IF-PP-304 Module_Rework Product Order_Component

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Production_Rework_Gerp", out_node);

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
    CUS_INTERFACE_DOWNLOAD_PRODUCTION_REWORK_GERP()
        - ERP->MES Production Order Rework 정보 DownLoad
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_PRODUCTION_REWORK_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)// IF-PP-304 Module_Rework Product Order_Component
{
	// Variable
	struct IWIPRWKDAT_TAG IWIPRWKDAT; //Interface Table
	struct IBAKRWKDAT_TAG IBAKRWKDAT; //Interface Backup Table
	struct CWIPRWKDAT_TAG CWIPRWKDAT; //Custom Production Rework Table
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPORDSTS_TAG CWIPORDSTS;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MWIPMATFLW_TAG MWIPMATFLW;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct MWIPLOTHIS_TAG MWIPLOTHIS_CHK;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
	struct CWIPREQMST_TAG CWIPREQMST;
	//[23.08.22]이글2적용(시작)
	struct MRASRESDEF_TAG MRASRESDEF;
	 //[23.08.22]이글2적용(종료)

	char s_sys_time[14];
	char tmp_order[25];
	char tmp_mat[30];
	int i_close_oqc = 0;

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_DOWNLOAD_PRODUCTION_REWORK_GERP");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
	// SYSTEM TIME SETTING
    memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(tmp_order, ' ', sizeof(tmp_order));
	memset(tmp_mat, ' ', sizeof(tmp_mat));

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
	/// IF-PP-304
	// INIT
	CDB_init_iwiprwkdat(&IWIPRWKDAT);            
    CDB_open_iwiprwkdat(2, &IWIPRWKDAT);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "IWIPRWKDAT OPEN", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// FETCH
	while(1) 
    {
		CDB_fetch_iwiprwkdat(2, &IWIPRWKDAT);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwiprwkdat(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPORDDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPRWKDAT.DOC_ID), IWIPRWKDAT.DOC_ID);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPRWKDAT.PROD_ORDER_NO), IWIPRWKDAT.PROD_ORDER_NO);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwiprwkdat(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		memcpy(IWIPRWKDAT.INF_PROC_TIME, s_sys_time, sizeof(s_sys_time)); 
		
		/*재작업 모듈의 오더,제품를 수정한다. */
		/*1) validation 재작업 모듈의 존재 확인 */
		CDB_init_mwiplotsts(&MWIPLOTSTS);

		memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPLOTSTS.LOT_ID, IWIPRWKDAT.MODULE_ID, sizeof(MWIPLOTSTS.LOT_ID));
		
		CDB_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				DB_rollback();
				strcpy(s_msg_code, "WIP-0044");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
				memcpy(IWIPRWKDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwiprwkdat(1,&IWIPRWKDAT);
				DB_commit();
			    continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_iwiprwkdat(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		memcpy(tmp_order, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		memcpy(tmp_mat, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

		/*1) validation 패킹여부 확인 */
		CDB_init_cwiplotpak(&CWIPLOTPAK);

		memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPLOTPAK.LOT_ID, IWIPRWKDAT.MODULE_ID, sizeof(MWIPLOTSTS.LOT_ID));

		//[ERP 23.05.24] Search Packing History & status  
		if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) == 0)
		{
			DB_rollback();
			// Packing 이력 존재하지 않음
			strcpy(s_msg_code, "WIP-0618"); //WIP-0618: 이 모듈은 패킹 이력이 없습니다.
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
			memcpy(IWIPRWKDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
			DB_commit();
			continue;
		}

		//ORDER_ID, 제품정보 취득
		CDB_init_cwipordsts(&CWIPORDSTS);
		memcpy(CWIPORDSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPORDSTS.ORDER_ID,  IWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPORDSTS.ORDER_ID));		
		CDB_select_cwipordsts(1, &CWIPORDSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				DB_rollback();
				strcpy(s_msg_code, "WIP-0573");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
				memcpy(IWIPRWKDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
				DB_commit();
				continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPORDSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDSTS.FACTORY), CWIPORDSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iwiprwkdat(2);
			    continue;
			}
		}
		
		// ZBOM 변경 WIPLOTHIS INSERT WIPLOTSTS UPDATE

		//23.4.14 모듈에 재작업 오더, 제품 반영
		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, CWIPORDSTS.MAT_ID, sizeof(CWIPORDSTS.MAT_ID));
		DBC_select_mwipmatdef(3, &MWIPMATDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				DB_rollback();
				strcpy(s_msg_code, "WIP-0006");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
				memcpy(IWIPRWKDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
				DB_commit();
				continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTHIS.MAT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iwiprwkdat(2);
				return MP_FALSE;
			}
		}
		//제품 FLOW 조회 
		CDB_init_mwipmatflw(&MWIPMATFLW);
		memcpy(MWIPMATFLW.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPMATFLW.MAT_ID, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATFLW.MAT_VER = MWIPMATDEF.MAT_VER;
		CDB_select_mwipmatflw(2, &MWIPMATFLW);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				DB_rollback();
				strcpy(s_msg_code, "WIP-0624");	//This material is not attached to flow.
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
				memcpy(IWIPRWKDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
				DB_commit();
				continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "MWIPMATDEF", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iwiprwkdat(2);
			    continue;
			}
		}

		//INSERT WIPLOTHIS
		DBC_init_mwiplothis(&MWIPLOTHIS);
		memcpy(MWIPLOTHIS.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
		MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		DBC_select_mwiplothis(1, &MWIPLOTHIS);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				DB_rollback();
				strcpy(s_msg_code, "WIP-0625"); //WIP-0625: 오더 정보가 없습니다.
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
				memcpy(IWIPRWKDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
				DB_commit();
				continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTHIS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTHIS.FACTORY), MWIPLOTHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iwiprwkdat(2);
				return MP_TRUE;
			}
		}

		MWIPLOTHIS.HIST_SEQ += 1;

		if (IWIPRWKDAT.DATA_FLAG == 'D') /* Rwk Delete  */
		{
			CDB_init_cwiprwkdat(&CWIPRWKDAT);
			memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPRWKDAT.PROD_ORDER_NO, IWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPRWKDAT.PROD_ORDER_NO));
			memcpy(CWIPRWKDAT.MODULE_ID, IWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID));
			CDB_select_cwiprwkdat(1, &CWIPRWKDAT);
			
			if (COM_isspace(CWIPRWKDAT.CMF_3, sizeof(CWIPRWKDAT.CMF_3)) == MP_TRUE  && COM_isspace(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)) == MP_FALSE)
			{
				memset(CWIPRWKDAT.CMF_3, ' ', sizeof(CWIPRWKDAT.CMF_3));
				memcpy(CWIPRWKDAT.CMF_3, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));  // 재작업시 ORDER ZBOM 품번으로 변경 
			}

			memcpy(MWIPLOTHIS.MAT_ID, CWIPRWKDAT.CMF_3, sizeof(CWIPRWKDAT.CMF_3));
		}
		else
		{
			memcpy(MWIPLOTHIS.MAT_ID, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		}
		MWIPLOTHIS.MAT_VER = MWIPMATDEF.MAT_VER;
		memcpy(MWIPLOTHIS.TRAN_TIME, s_sys_time, sizeof(MWIPLOTHIS.TRAN_TIME));
		memcpy(MWIPLOTHIS.SYS_TRAN_TIME, s_sys_time, sizeof(MWIPLOTHIS.SYS_TRAN_TIME));
		memcpy(MWIPLOTHIS.TRAN_CODE, HQCEL_LOT_TRAN_CHANGE, strlen(HQCEL_LOT_TRAN_CHANGE));
		memcpy(MWIPLOTHIS.TRAN_USER_ID, "SERVICE", strlen("SERVICE"));
		MWIPLOTHIS.PREV_ACTIVE_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		
		
		if (IWIPRWKDAT.DATA_FLAG == 'D') /* Rwk Delete  */
		{
			//CMF4가 IF되지 않는 경우 최초 오더로 변경함(24.10.01)-START
			DBC_init_mwiplothis(&MWIPLOTHIS_CHK);
			memcpy(MWIPLOTHIS_CHK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(MWIPLOTHIS_CHK.OPER, HQCEL_M1_LAYUP_OPER, 5);
			MWIPLOTHIS_CHK.HIST_SEQ = 1;//최초 오더를 가져온다 . 24.11.06
			DBC_select_mwiplothis(18, &MWIPLOTHIS_CHK);
			if(DB_error_code != DB_SUCCESS)
			{
				//(MWIPLOTSTS.ORDER_ID, MWIPLOTHIS_CHK.ORDER_ID, sizeof(MWIPLOTHIS_CHK.ORDER_ID));
			}
			else
			{
				memset(MWIPLOTHIS.ORDER_ID, 0x00, sizeof(MWIPLOTHIS.ORDER_ID));
				memcpy(MWIPLOTHIS.ORDER_ID, MWIPLOTHIS_CHK.ORDER_ID, sizeof(MWIPLOTHIS_CHK.ORDER_ID));
			}
			//CMF4가 IF되지 않는 경우 최초 오더로 변경함(24.10.01)-end
		}
		else
		{
			memcpy(MWIPLOTHIS.ORDER_ID, CWIPORDSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		}
		//Update Lot History
		DBC_insert_mwiplothis(&MWIPLOTHIS);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTHIS INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTHIS.FACTORY), MWIPLOTHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_iwiprwkdat(2);
			return MP_FALSE;
		}

		
		//모듈에 재작업 오더, 제품 반영
		if (IWIPRWKDAT.DATA_FLAG == 'D') /* Rwk Delete  */
		{	//CMF4가 IF되지 않는 경우 최초 오더로 변경함(24.10.01)-START
			DBC_init_mwiplothis(&MWIPLOTHIS_CHK);
			memcpy(MWIPLOTHIS_CHK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			//memcpy(MWIPLOTHIS_CHK.OPER, HQCEL_M1_LAYUP_OPER, 5);
			MWIPLOTHIS_CHK.HIST_SEQ = 1;//최초 오더를 가져온다 . 24.11.06
			
			DBC_select_mwiplothis(18, &MWIPLOTHIS_CHK);
			if(DB_error_code != DB_SUCCESS)
			{
				//(MWIPLOTSTS.ORDER_ID, MWIPLOTHIS_CHK.ORDER_ID, sizeof(MWIPLOTHIS_CHK.ORDER_ID));
			}
			else
			{
				memset(MWIPLOTSTS.ORDER_ID, 0x00, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(MWIPLOTSTS.ORDER_ID, MWIPLOTHIS_CHK.ORDER_ID, sizeof(MWIPLOTHIS_CHK.ORDER_ID));
			}

			//CMF4가 IF되지 않는 경우 최초 오더로 변경함(24.10.01)-end
			//memcpy(MWIPLOTSTS.ORDER_ID, CWIPRWKDAT.CMF_4, sizeof(CWIPRWKDAT.CMF_4));
			memcpy(MWIPLOTSTS.MAT_ID, CWIPRWKDAT.CMF_3, sizeof(MWIPLOTSTS.MAT_ID));  // 재작업시 ORDER ZBOM 품번으로 변경 

		}
		else 
		{
			memcpy(MWIPLOTSTS.ORDER_ID, CWIPORDSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(MWIPLOTSTS.MAT_ID, CWIPORDSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));  // 재작업시 ORDER ZBOM 품번으로 변경 
		}
		MWIPLOTSTS.MAT_VER = MWIPMATDEF.MAT_VER;
		MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ = MWIPLOTHIS.HIST_SEQ;
		MWIPLOTSTS.LAST_HIST_SEQ = MWIPLOTHIS.HIST_SEQ;
		CDB_update_mwiplotsts(1, &MWIPLOTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			DB_rollback();
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_iwiprwkdat(2);
			return MP_FALSE;
		}

		/* 23.06.07 GERP 추가, Unpack 창고->등급별 창고 이동 로직 추가 Store 창고 MOVE 처리-------------------------- */
		/* 1. D, X 확인 ( 재작업 삭제인지, 신청인지 확인 ) */
		if (IWIPRWKDAT.DATA_FLAG == 'D')	// 삭제 -> M4050 으로 이동
		{
			// Store 창고에서의 이동 ( 이미 M4050 창고면 이동안함 )			
			if (MWIPLOTSTS.INV_FLAG == HQCEL_FLAG_YES && memcmp(MWIPLOTSTS.OPER, HQCEL_M1_UNPACK_OPER, strlen(HQCEL_M1_UNPACK_OPER)) != 0
				&& memcmp(MWIPLOTSTS.OPER, HQCEL_M1_UNPACK_OPER_E2, strlen(HQCEL_M1_UNPACK_OPER_E2)) != 0) //[23.08.22]이글2적용
			{
				tran_in_node = TRS.create_node("STORE_MOVE_IN");
				tran_out_node = TRS.create_node("STORE_MOVE_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.set_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_UNPACK_OPER, strlen(HQCEL_M1_UNPACK_OPER));
                //E1, E2/3 재작업 창고 구분 
				//[23.08.22]이글2적용(시작)
				if(memcmp(IWIPRWKDAT.CMF_1, "QFN1", strlen("QFN1")) == 0)
					TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_UNPACK_OPER, strlen(HQCEL_M1_UNPACK_OPER));


               if (memcmp(IWIPRWKDAT.CMF_1, "QFN3", strlen("QFN3")) == 0)
                    TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_UNPACK_OPER_E2, strlen(HQCEL_M1_UNPACK_OPER_E2));

			    //[23.08.22]이글2적용(종료)
				if (CWIP_Move_Lot(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					DB_rollback();
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					/*error log add*/
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
					memcpy(IWIPRWKDAT.RETURN_MSG, "CWIP_Move_Lot", strlen("CWIP_Move_Lot"));
					CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
					DB_commit();
					continue;
				}

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
			}
			// 공정창고일때의 이동 (OQC -> Unpack 창고 or 공정/생산창고 -> Unpack 창고)
			else if (MWIPLOTSTS.INV_FLAG != HQCEL_FLAG_YES && memcmp( MWIPLOTSTS.OPER, HQCEL_M1_FGS_OPER, strlen(HQCEL_M1_FGS_OPER)) != 0)
			{
				/* STORE Lot */
				tran_in_node = TRS.create_node("STORE_LOT_IN");
				tran_out_node = TRS.create_node("STORE_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.set_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				//TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));

				TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
				TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);

				//E1, E2/3 재작업 창고 구분 
				//[23.08.22]이글2적용(시작)
				if (memcmp(IWIPRWKDAT.CMF_1, "QFN1", strlen("QFN1")) == 0)
				{	TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_UNPACK_OPER, strlen(HQCEL_M1_UNPACK_OPER));
				}
				else if (memcmp(IWIPRWKDAT.CMF_1, "QFN3", strlen("QFN3")) == 0)
				{TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_UNPACK_OPER_E2, strlen(HQCEL_M1_UNPACK_OPER_E2));
				}
				else		//데이터가 없는 경우
				{
					if (memcmp(MWIPLOTSTS.LOT_CMF_1, "MDL01", strlen("MDL01")) == 0
						||
						memcmp(MWIPLOTSTS.LOT_CMF_1, "MDL02", strlen("MDL02")) == 0
						||
						memcmp(MWIPLOTSTS.LOT_CMF_1, "MDL03", strlen("MDL02")) == 0
						)
					{
						TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_UNPACK_OPER, strlen(HQCEL_M1_UNPACK_OPER));
					}
					else
					{
						TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_UNPACK_OPER_E2, strlen(HQCEL_M1_UNPACK_OPER_E2));
					}


				}

				//[23.08.22]이글2적용(종료)
				
				
				if (WIP_STORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					DB_rollback();
					TRS.clone(out_node, tran_out_node);

					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					/*error log add*/
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
					memcpy(IWIPRWKDAT.RETURN_MSG, "WIP_STORE_LOT", strlen("WIP_STORE_LOT"));
					CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
					DB_commit();

					continue;
				}

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
			}
		}
		else /* M4050, M4250 -> 등급 창고 및 OQC 로 이동 */
		{
			if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_UNPACK_OPER, strlen(HQCEL_M1_UNPACK_OPER)) == 0
				|| memcmp(MWIPLOTSTS.OPER, HQCEL_M1_UNPACK_OPER_E2, strlen(HQCEL_M1_UNPACK_OPER_E2)) == 0) // M4050, M4250 창고 재작업 창고에 있어야지만 보냄, [23.08.22]이글2적용
			{
				CDB_init_mgcmtbldat(&MGCMTBLDAT);
				memcpy(MGCMTBLDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_SAPTOMES_OPER, strlen(HQCEL_M1_GCM_SAPTOMES_OPER));
				memcpy(MGCMTBLDAT.KEY_1, IWIPRWKDAT.CMF_1, sizeof(IWIPRWKDAT.CMF_1));

				CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
				
				//공정 확인 
				DBC_init_mwipoprdef(&MWIPOPRDEF);
				memcpy(MWIPOPRDEF.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				memcpy(MWIPOPRDEF.OPER, MGCMTBLDAT.DATA_1, sizeof(MWIPLOTSTS.OPER));
				DBC_select_mwipoprdef(1, &MWIPOPRDEF);

				if (DB_error_code != DB_NOT_FOUND)
				{
					if (MWIPOPRDEF.INV_FLAG == HQCEL_FLAG_YES)	// Product / Process 창고로 이동 STORE MOVE (TO_OPER 가 Store 창고일경우 STORE_MOVE)
					{
						tran_in_node = TRS.create_node("STORE_MOVE_IN");
						tran_out_node = TRS.create_node("STORE_MOVE_OUT");

						CCOM_copy_in_node(in_node, tran_in_node);
						TRS.add_char(tran_in_node, "PROCSTEP", '1');
						TRS.set_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
						TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
						TRS.add_string(tran_in_node, "TO_OPER", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));


						if (CWIP_Move_Lot(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
						{
							DB_rollback();
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							
							/*error log add*/
							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
							IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
							memcpy(IWIPRWKDAT.RETURN_MSG, "CWIP_Move_Lot", strlen("CWIP_Move_Lot"));
							CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
							DB_commit();

							continue;
						}
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
					}
					else if (MWIPOPRDEF.INV_FLAG == HQCEL_FLAG_NO || MWIPOPRDEF.INV_FLAG == HQCEL_FLAG_NONE)	// OQC 창고로 이동 Unstore ( 일반 공정이면 Unstore 처리)
					{
						TRSNode* tran_in_node;
						TRSNode* tran_out_node;

						/* UNSTORE Lot */
						tran_in_node = TRS.create_node("UNSTORE_LOT_IN");
						tran_out_node = TRS.create_node("UNSTORE_LOT_OUT");

						CCOM_copy_in_node(in_node, tran_in_node);
						TRS.add_char(tran_in_node, "PROCSTEP", '1');
						TRS.set_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
						TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
						TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

						TRS.add_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.STR_RET_FLOW, sizeof(MWIPLOTSTS.STR_RET_FLOW));


						if (memcmp(MWIPLOTSTS.STR_RET_OPER, MGCMTBLDAT.DATA_1, sizeof(MWIPLOTSTS.STR_RET_OPER)))
						{
							memcpy(MWIPLOTSTS.STR_RET_OPER, MGCMTBLDAT.DATA_1, sizeof(MWIPLOTSTS.STR_RET_OPER));
							DBC_update_mwiplotsts(1, &MWIPLOTSTS);
						}

						TRS.add_string(tran_in_node, "TO_OPER", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

						if (WIP_UNSTORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
						{
							DB_rollback();
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							
							/*error log add*/
							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
							IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
							memcpy(IWIPRWKDAT.RETURN_MSG, "WIP_UNSTORE_LOT", strlen("WIP_UNSTORE_LOT"));
							CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
							DB_commit();
						
							continue;
						}
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
					}
				}				
			}
		}

		/*  [GERP]06.22 OQC 2 Step 진행되지 않은 모듈 처리-------------------------- */
		i_close_oqc = 0;
		CDB_init_cwipreqmst(&CWIPREQMST);
		memcpy(CWIPREQMST.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPREQMST.REQ_CMF_1, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
		i_close_oqc = (int)CDB_select_cwipreqmst_scalar(4, &CWIPREQMST);
		//미완료 된 요청이 있다면 
		if (i_close_oqc > 0)
		{
			//모든 REQUEST CLOSE REQ_CMF_1 에 기록
			CDB_init_cwipreqmst(&CWIPREQMST);
			memcpy(CWIPREQMST.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPREQMST.REQ_CMF_1, "R", strlen("R"));
			memcpy(CWIPREQMST.REQ_CMF_2, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
			CDB_update_cwipreqmst(3, &CWIPREQMST);
			if (DB_error_code != DB_SUCCESS)
			{
				//PASS...
			}
		}	
		/* --------------------------[GERP PROJECT] 끝-------------------------------------- */

		// 1. IWIPRWKDAT TABLE CONTROL
		CDB_init_cwiprwkdat(&CWIPRWKDAT);

		// ORDER_ID가 존재하는지 체크한다.
		memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPRWKDAT.PROD_ORDER_NO, IWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPRWKDAT.PROD_ORDER_NO));
		memcpy(CWIPRWKDAT.MODULE_ID, IWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID));
		CDB_select_cwiprwkdat(1,&CWIPRWKDAT);
		if(DB_error_code == DB_SUCCESS) 
		{
			// Add 22.4.12 판정 값이 있다면 UPDATE 불가능 
			if (COM_isspace(CWIPRWKDAT.REWORK_JUDGE, sizeof(CWIPRWKDAT.REWORK_JUDGE)) == MP_FALSE && 
				COM_isspace(CWIPRWKDAT.PALLET_ID, sizeof(CWIPRWKDAT.PALLET_ID)) == MP_FALSE)
			{
				// Do Nothing.
			}	
			else if (COM_isspace(CWIPRWKDAT.REWORK_JUDGE, sizeof(CWIPRWKDAT.REWORK_JUDGE)) == MP_FALSE ||
				COM_isspace(CWIPRWKDAT.PALLET_ID, sizeof(CWIPRWKDAT.PALLET_ID)) == MP_FALSE)
			{
				//DB_rollback();
				//strcpy(s_msg_code, "WIP-0623"); //The rewrok judgement exists. Can't not update rework interface.
				//gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				//IWIPRWKDAT.RETURN_TYPE = MP_LOG_E_EXISTENCE;
				//memcpy(IWIPRWKDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				//CDB_update_iwiprwkdat(1, &IWIPRWKDAT);
				//DB_commit();
				//continue;
			}
						
			// DATA 존재하면 해당 DATA를 지운다.
			CDB_delete_cwiprwkdat(1, &CWIPRWKDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPRWKDAT DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRWKDAT.FACTORY), CWIPRWKDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				CDB_close_iwiprwkdat(2);
				return MP_FALSE;
			}
			CDB_init_cwiprwkdat(&CWIPRWKDAT);

			// ORDER_ID가 존재하는지 체크한다.
			memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPRWKDAT.PROD_ORDER_NO, IWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPRWKDAT.PROD_ORDER_NO));
			memcpy(CWIPRWKDAT.MODULE_ID, IWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID));
		}
		// (IWIPRWKDAT -> CWIPRWKDAT) 
		// 2023-02-08 *********************************************************************************************************
		// 2023.02.24 Update Table(CWIPRWKDAT) Add Col MAT_ID, BDMNG, MEINS, CHARG, R_REASON
		memcpy(CWIPRWKDAT.PROD_NO, IWIPRWKDAT.PROD_NO, sizeof(CWIPRWKDAT.PROD_NO));
		memcpy(CWIPRWKDAT.MATE_NM, IWIPRWKDAT.MATE_NM, sizeof(CWIPRWKDAT.MATE_NM));
		memcpy(CWIPRWKDAT.MAT_ID, IWIPRWKDAT.MATE_NO, sizeof(CWIPRWKDAT.MAT_ID));
		memcpy(CWIPRWKDAT.REQUIRE_QTY, IWIPRWKDAT.REQUIRE_QTY, sizeof(CWIPRWKDAT.REQUIRE_QTY));
		memcpy(CWIPRWKDAT.UNIT, IWIPRWKDAT.UNIT, sizeof(CWIPRWKDAT.UNIT));
		memcpy(CWIPRWKDAT.BATCH_NO, IWIPRWKDAT.BATCH_NO, sizeof(CWIPRWKDAT.BATCH_NO));
		memcpy(CWIPRWKDAT.R_REASON, IWIPRWKDAT.R_REASON, sizeof(CWIPRWKDAT.R_REASON));
		CWIPRWKDAT.CMF_1[0] = IWIPRWKDAT.DATA_FLAG; 

		if (IWIPRWKDAT.DATA_FLAG != 'D') /* GERP PROJECT 이전 LOT, ORDER  */
		{
			if (COM_isspace(CWIPRWKDAT.CMF_3, sizeof(CWIPRWKDAT.CMF_3)) != 0)
			{
				memcpy(CWIPRWKDAT.CMF_3, tmp_mat, sizeof(tmp_mat));
				memcpy(CWIPRWKDAT.CMF_4, tmp_order, sizeof(tmp_order));
			}
		}

		memcpy(CWIPRWKDAT.CREATE_USER_ID, "SERVICE", strlen("SERVICE"));
		memcpy(CWIPRWKDAT.CREATE_TIME, s_sys_time, sizeof(CWIPRWKDAT.CREATE_TIME));
		memcpy(CWIPRWKDAT.UPDATE_USER_ID, "SERVICE", strlen("SERVICE"));
		memcpy(CWIPRWKDAT.UPDATE_TIME, s_sys_time, sizeof(CWIPRWKDAT.UPDATE_TIME));
		//**********************************************************************************************************************
		//1. INSERT 
		CDB_insert_cwiprwkdat(&CWIPRWKDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPRWKDAT INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRWKDAT.FACTORY), CWIPRWKDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_iwiprwkdat(2);
			return MP_FALSE;
		}
		//2.DELETE IWIPRWKDAT
		CDB_delete_iwiprwkdat(1, &IWIPRWKDAT);
        //3. BACKUP TABLE COPY
        CDB_init_ibakrwkdat(&IBAKRWKDAT);
		memcpy(IBAKRWKDAT.DOC_ID, IWIPRWKDAT.DOC_ID, sizeof(struct IBAKRWKDAT_TAG));        
		CDB_delete_ibakrwkdat(1, &IBAKRWKDAT);
		CDB_insert_ibakrwkdat(&IBAKRWKDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IBAKRWKDAT INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKRWKDAT.DOC_ID), IBAKRWKDAT.DOC_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_iwiprwkdat(2);
			return MP_FALSE;
		}
		DB_commit();
	}
	return MP_TRUE;
}


/*******************************************************************************
	CWIP_Move_Lot()
		- Main sub function of "CWIP_VIEW_PACKING_LOT" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Move_Lot(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	tran_in_node = TRS.create_node("STORE_MOVE_IN");
	tran_out_node = TRS.create_node("STORE_MOVE_OUT");

	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.set_char(tran_in_node, "PROCSTEP", '1');
	TRS.set_string(tran_in_node, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
	TRS.add_nstring(tran_in_node, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));

	if (CINV_MOVE_STORE(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		return MP_FALSE;
	}

	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);
	
	return MP_TRUE;
}
