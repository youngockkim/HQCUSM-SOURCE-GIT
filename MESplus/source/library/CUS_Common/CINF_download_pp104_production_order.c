/*******************************************************************************

    System      : MESplus
    Module      : Production Order ���� DownLoad
    File Name   : CINF_download_pp104_production_order.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.11.30  Juhyeon.Jung	 Create

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"

int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ORDER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Production Order ���� DownLoad
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Production_Order(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_PRODUCTION_ORDER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Production_Order", out_node);

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
    CUS_INTERFACE_DOWNLOAD_PRODUCTION_ORDER()
        - ERP->MES Production Order Interface
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ORDER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// Variable
	struct IWIPORDDAT_TAG IWIPORDDAT; //Interface Table
	struct IBAKORDDAT_TAG IBAKORDDAT; //Interface Backup Table
    struct MWIPORDSTS_TAG MWIPORDSTS; //MESplus Order Table
	struct CWIPORDSTS_TAG CWIPORDSTS; //Custom Order Table

	struct MGCMTBLDAT_TAG MGCMTBLDAT;

	char s_sys_time[14];
	char c_newflag = ' ';

	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_DOWNLOAD_PRODUCTION_ORDER");
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

	// INIT
	CDB_init_iwiporddat(&IWIPORDDAT);
    CDB_open_iwiporddat(2, &IWIPORDDAT);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "IWIPORDDAT OPEN", MP_NVST);
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
		CDB_fetch_iwiporddat(2, &IWIPORDDAT);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwiporddat(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPORDDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPORDDAT.DOC_ID), IWIPORDDAT.DOC_ID);            
			TRS.add_fieldmsg(out_node, "PROD_NO", MP_STR, sizeof(IWIPORDDAT.PROD_NO), IWIPORDDAT.PROD_NO);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPORDDAT.PROD_ORDER_NO), IWIPORDDAT.PROD_ORDER_NO);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwiporddat(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		c_newflag = ' ';
		memcpy(IWIPORDDAT.INF_PROC_TIME, s_sys_time, sizeof(s_sys_time)); 

		//0.MWIPORDSTS TABLE CONTROL
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, IWIPORDDAT.PROD_ORDER_NO, sizeof(MWIPORDSTS.ORDER_ID));
		DBC_select_mwipordsts_for_update(1, &MWIPORDSTS);
		if(DB_error_code == DB_NOT_FOUND) 
		{
			c_newflag = 'Y';
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			IWIPORDDAT.RETURN_TYPE = 'E';
			memcpy(IWIPORDDAT.RETURN_MSG, DB_error_msg, sizeof(IWIPORDDAT.RETURN_MSG));
			
			CDB_update_iwiporddat(1, &IWIPORDDAT);
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "IWIPORDDAT FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPORDDAT.DOC_ID), IWIPORDDAT.DOC_ID);            
				TRS.add_fieldmsg(out_node, "PROD_NO", MP_STR, sizeof(IWIPORDDAT.PROD_NO), IWIPORDDAT.PROD_NO);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPORDDAT.PROD_ORDER_NO), IWIPORDDAT.PROD_ORDER_NO);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				//CDB_close_iwiporddat(1);

				// IS-21-07-007 ERP �������̽� ������ ����(Power Range)
				// DB OPEN / FETCH CASE CURSOR CLOSE
				CDB_close_iwiporddat(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			DB_commit();
			continue;
		}

		//�����ͺ��� (IWIPORDDAT -> MWIPORDSTS)
		memcpy(MWIPORDSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, IWIPORDDAT.PROD_ORDER_NO, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(MWIPORDSTS.MAT_ID, IWIPORDDAT.PROD_NO, sizeof(MWIPORDSTS.MAT_ID));
		MWIPORDSTS.MAT_VER = 1;
		MWIPORDSTS.FLOW_SEQ_NUM = 1;
		MWIPORDSTS.ORD_QTY = IWIPORDDAT.PROD_QTY;
		memcpy(MWIPORDSTS.WORK_DATE, IWIPORDDAT.START_DATE, sizeof(MWIPORDSTS.WORK_DATE));
		MWIPORDSTS.QTY = IWIPORDDAT.PROD_QTY;
		MWIPORDSTS.LOT_TYPE = 'P';
		memcpy(MWIPORDSTS.CREATE_CODE, "PROD", strlen( "PROD"));
		memcpy(MWIPORDSTS.ORG_DUE_TIME, IWIPORDDAT.FINISH_DATE, sizeof(IWIPORDDAT.FINISH_DATE));
		
		//생산오더 / 리워크오더 구분 로직 수정 요청의 건[25.03.19]
		if(memcmp(IWIPORDDAT.PROD_ORDER_SUBTYPE, "HM02", strlen("HM02")) == 0)
		{
			MWIPORDSTS.ORD_STATUS_FLAG = 'X';
		}
		else
		{
			MWIPORDSTS.ORD_STATUS_FLAG = 'O';
		}


		//생산오더 / 리워크오더 구분 로직 수정 요청의 건[25.03.19]


		//�߰��ʵ�.
		memcpy(MWIPORDSTS.ORDER_DESC, IWIPORDDAT.PROD_NO_DESC, sizeof(MWIPORDSTS.ORDER_DESC));
		//CMF_1 : LINE, CMF_2 : WORK CENTER, CMF_3 : Color Class, CMF_4 : Order Type , CMF_5 : Work Shop
		
		//LINE CODE GET
		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, MWIPORDSTS.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
		memcpy(MGCMTBLDAT.DATA_2, IWIPORDDAT.WORK_CENTER, sizeof(IWIPORDDAT.WORK_CENTER));
		CDB_select_mgcmtbldat(2, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		memcpy(MWIPORDSTS.ORD_CMF_1, MGCMTBLDAT.KEY_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		memcpy(MWIPORDSTS.ORD_CMF_2, MGCMTBLDAT.DATA_2, sizeof(MWIPORDSTS.ORD_CMF_2));
		memcpy(MWIPORDSTS.ORD_CMF_3, IWIPORDDAT.ZARTCOR, sizeof(MWIPORDSTS.ORD_CMF_3));
		memcpy(MWIPORDSTS.ORD_CMF_4, IWIPORDDAT.PROD_ORDER_SUBTYPE, sizeof(MWIPORDSTS.ORD_CMF_4));
		memcpy(MWIPORDSTS.ORD_CMF_5, IWIPORDDAT.WORK_SHOP, sizeof(MWIPORDSTS.ORD_CMF_5));
		//ORD_CMF_6 : LOCATION
		memcpy(MWIPORDSTS.ORD_CMF_6, MGCMTBLDAT.DATA_4, sizeof(MWIPORDSTS.ORD_CMF_6));
		memcpy(MWIPORDSTS.ORD_CMF_7, IWIPORDDAT.ZZBOMID, sizeof(IWIPORDDAT.ZZBOMID));
		

		// ���� FLAG �� ���
		if ((IWIPORDDAT.DEL_YN == 'Y') || (IWIPORDDAT.DEL_YN == 'X'))
		{
			/***********************************/
			// BACKUP TABLE : IWIPORDDAT -> IBAKORDDAT
			// IBAKORDDAT Table Insert
			/***********************************/

			CDB_init_ibakorddat(&IBAKORDDAT);
			memcpy(IBAKORDDAT.DOC_ID, IWIPORDDAT.DOC_ID, sizeof(struct IWIPORDDAT_TAG));
			CDB_delete_ibakorddat(1, &IBAKORDDAT);
			CDB_insert_ibakorddat(&IBAKORDDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			
			/***********************************/
			// 1. CWIPORDSTS Table Delete
			/***********************************/

			CDB_init_cwipordsts(&CWIPORDSTS);

			// ORDER_ID�� �����ϴ��� üũ�Ѵ�.
			memcpy(CWIPORDSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPORDSTS.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
			CDB_select_cwipordsts(1,&CWIPORDSTS);

			if(DB_error_code != DB_NOT_FOUND) 
			{
				CDB_delete_cwipordsts(1, &CWIPORDSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}

			/***********************************/
			// 2. MWIPORDSTS Table Delete
			/***********************************/

			if(c_newflag != 'Y') 
			{
				DBC_delete_mwipordsts(1, &MWIPORDSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}

			/***********************************/
			// 3.IWIPORDDAT Table Delete
			/***********************************/

			// DELETE IWIPMATDEF
			CDB_delete_iwiporddat(1,&IWIPORDDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}		

			DB_commit();
			continue;
		}

		if (c_newflag == 'Y')
		{
			memcpy(MWIPORDSTS.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
			memcpy(MWIPORDSTS.CREATE_TIME, s_sys_time, sizeof(s_sys_time)); 
			DBC_insert_mwipordsts(&MWIPORDSTS);
		}
		else
		{
			memcpy(MWIPORDSTS.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
			memcpy(MWIPORDSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time)); 
			DBC_update_mwipordsts(1, &MWIPORDSTS);
		}
		if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPORDSTS INSERT/UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPORDDAT.DOC_ID), IWIPORDDAT.DOC_ID);            
			TRS.add_fieldmsg(out_node, "PROD_NO", MP_STR, sizeof(IWIPORDDAT.PROD_NO), IWIPORDDAT.PROD_NO);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPORDDAT.PROD_ORDER_NO), IWIPORDDAT.PROD_ORDER_NO);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			//CDB_close_iwiporddat(1);

			// IS-21-07-007 ERP �������̽� ������ ����(Power Range)
			// DB OPEN / FETCH CASE CURSOR CLOSE
			CDB_close_iwiporddat(2);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// 1. CWIPORDSTS TABLE CONTROL
		CDB_init_cwipordsts(&CWIPORDSTS);

		// ORDER_ID�� �����ϴ��� üũ�Ѵ�.
		memcpy(CWIPORDSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPORDSTS.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
		CDB_select_cwipordsts(1,&CWIPORDSTS);
		if(DB_error_code != DB_NOT_FOUND) 
		{
			// ORDER_ID�� �����ϸ� �ش� DATA�� �����.
			memcpy(CWIPORDSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPORDSTS.ORDER_ID, IWIPORDDAT.PROD_ORDER_NO, sizeof(CWIPORDSTS.ORDER_ID));
			CDB_delete_cwipordsts(1,&CWIPORDSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPORDSTS DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPORDDAT.DOC_ID), IWIPORDDAT.DOC_ID);            
				TRS.add_fieldmsg(out_node, "PROD_NO", MP_STR, sizeof(IWIPORDDAT.PROD_NO), IWIPORDDAT.PROD_NO);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPORDDAT.PROD_ORDER_NO), IWIPORDDAT.PROD_ORDER_NO);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				//CDB_close_iwiporddat(1);

				// IS-21-07-007 ERP �������̽� ������ ����(Power Range)
				// DB OPEN / FETCH CASE CURSOR CLOSE
				CDB_close_iwiporddat(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		//�����ͺ��� (IWIPORDDAT -> CWIPORDSTS)			
		memcpy(CWIPORDSTS.MAT_ID, IWIPORDDAT.PROD_NO, sizeof(CWIPORDSTS.MAT_ID));
		memcpy(CWIPORDSTS.PROD_ORDER_VER, IWIPORDDAT.PROD_ORDER_VER, sizeof(CWIPORDSTS.PROD_ORDER_VER));
		memcpy(CWIPORDSTS.PROD_NO_DESC, IWIPORDDAT.PROD_NO_DESC, sizeof(CWIPORDSTS.PROD_NO_DESC));
		memcpy(CWIPORDSTS.PROD_ORDER_TYPE, IWIPORDDAT.PROD_ORDER_TYPE, sizeof(CWIPORDSTS.PROD_ORDER_TYPE));
		memcpy(CWIPORDSTS.PROD_ORDER_SUBTYPE, IWIPORDDAT.PROD_ORDER_SUBTYPE, sizeof(CWIPORDSTS.PROD_ORDER_SUBTYPE));
		CWIPORDSTS.PROD_QTY = IWIPORDDAT.PROD_QTY;
		memcpy(CWIPORDSTS.START_DATE, IWIPORDDAT.START_DATE, sizeof(CWIPORDSTS.START_DATE));
		memcpy(CWIPORDSTS.FINISH_DATE, IWIPORDDAT.FINISH_DATE, sizeof(CWIPORDSTS.FINISH_DATE));
		memcpy(CWIPORDSTS.WORK_SHOP, IWIPORDDAT.WORK_SHOP, sizeof(CWIPORDSTS.WORK_SHOP));
		CWIPORDSTS.BLOCK_YN = IWIPORDDAT.BLOCK_YN;		
		memcpy(CWIPORDSTS.ROUTE_GRP, IWIPORDDAT.ROUTE_GRP, sizeof(CWIPORDSTS.ROUTE_GRP));
		memcpy(CWIPORDSTS.ROUTE, IWIPORDDAT.ROUTE, sizeof(CWIPORDSTS.ROUTE));
		memcpy(CWIPORDSTS.BOM_KEY, IWIPORDDAT.BOM_KEY, sizeof(CWIPORDSTS.BOM_KEY));
		memcpy(CWIPORDSTS.OPT_BOM, IWIPORDDAT.OPT_BOM, sizeof(CWIPORDSTS.OPT_BOM));
		memcpy(CWIPORDSTS.COMMENTS, IWIPORDDAT.COMMENTS, sizeof(CWIPORDSTS.COMMENTS));
		memcpy(CWIPORDSTS.CRE_ID, IWIPORDDAT.CRE_ID, sizeof(CWIPORDSTS.CRE_ID));
		memcpy(CWIPORDSTS.CRE_DATE, IWIPORDDAT.CRE_DATE, sizeof(CWIPORDSTS.CRE_DATE));
		memcpy(CWIPORDSTS.MOD_ID, IWIPORDDAT.MOD_ID, sizeof(CWIPORDSTS.MOD_ID));
		memcpy(CWIPORDSTS.MOD_DATE, IWIPORDDAT.MOD_DATE, sizeof(CWIPORDSTS.MOD_DATE));
		memcpy(CWIPORDSTS.EX_BATCH_NO, IWIPORDDAT.EX_BATCH_NO, sizeof(CWIPORDSTS.EX_BATCH_NO));		
		CWIPORDSTS.PROD_ORDER_STATE = IWIPORDDAT.PROD_ORDER_STATE;
		memcpy(CWIPORDSTS.SALES_ORDER_GRP, IWIPORDDAT.SALES_ORDER_GRP, sizeof(CWIPORDSTS.SALES_ORDER_GRP));
		memcpy(CWIPORDSTS.HAND_BOOK, IWIPORDDAT.HAND_BOOK, sizeof(CWIPORDSTS.HAND_BOOK));
		memcpy(CWIPORDSTS.CO_PROD_NO_1, IWIPORDDAT.CO_PROD_NO_1, sizeof(CWIPORDSTS.CO_PROD_NO_1));
		memcpy(CWIPORDSTS.CO_PROD_NO_2, IWIPORDDAT.CO_PROD_NO_2, sizeof(CWIPORDSTS.CO_PROD_NO_2));
		memcpy(CWIPORDSTS.CO_PROD_NO_3, IWIPORDDAT.CO_PROD_NO_3, sizeof(CWIPORDSTS.CO_PROD_NO_3));
		memcpy(CWIPORDSTS.CO_PROD_NO_4, IWIPORDDAT.CO_PROD_NO_4, sizeof(CWIPORDSTS.CO_PROD_NO_4));
		memcpy(CWIPORDSTS.CO_PROD_NO_5, IWIPORDDAT.CO_PROD_NO_5, sizeof(CWIPORDSTS.CO_PROD_NO_5));
		memcpy(CWIPORDSTS.CO_PROD_NO_6, IWIPORDDAT.CO_PROD_NO_6, sizeof(CWIPORDSTS.CO_PROD_NO_6));
		memcpy(CWIPORDSTS.CO_PROD_NUMBER_1, IWIPORDDAT.CO_PROD_NUMBER_1, sizeof(CWIPORDSTS.CO_PROD_NUMBER_1));
		memcpy(CWIPORDSTS.CO_PROD_NUMBER_2, IWIPORDDAT.CO_PROD_NUMBER_2, sizeof(CWIPORDSTS.CO_PROD_NUMBER_2));
		memcpy(CWIPORDSTS.CO_PROD_NUMBER_3, IWIPORDDAT.CO_PROD_NUMBER_3, sizeof(CWIPORDSTS.CO_PROD_NUMBER_3));
		memcpy(CWIPORDSTS.CO_PROD_NUMBER_4, IWIPORDDAT.CO_PROD_NUMBER_4, sizeof(CWIPORDSTS.CO_PROD_NUMBER_4));
		memcpy(CWIPORDSTS.CO_PROD_NUMBER_5, IWIPORDDAT.CO_PROD_NUMBER_5, sizeof(CWIPORDSTS.CO_PROD_NUMBER_5));
		memcpy(CWIPORDSTS.CO_PROD_NUMBER_6, IWIPORDDAT.CO_PROD_NUMBER_6, sizeof(CWIPORDSTS.CO_PROD_NUMBER_6));
		memcpy(CWIPORDSTS.CELL_RATE, IWIPORDDAT.CELL_RATE, sizeof(CWIPORDSTS.CELL_RATE));
		memcpy(CWIPORDSTS.BCR_POWER, IWIPORDDAT.BCR_POWER, sizeof(CWIPORDSTS.BCR_POWER));
		memcpy(CWIPORDSTS.BCR_LIST_CODE, IWIPORDDAT.BCR_LIST_CODE, sizeof(CWIPORDSTS.BCR_LIST_CODE));
		memcpy(CWIPORDSTS.BCR_MOD_CLASS, IWIPORDDAT.BCR_MOD_CLASS, sizeof(CWIPORDSTS.BCR_MOD_CLASS));
		memcpy(CWIPORDSTS.BCR_MOD_TYPE, IWIPORDDAT.BCR_MOD_TYPE, sizeof(CWIPORDSTS.BCR_MOD_TYPE));
		memcpy(CWIPORDSTS.BCR_MOD_SUBTYPE, IWIPORDDAT.BCR_MOD_SUBTYPE, sizeof(CWIPORDSTS.BCR_MOD_SUBTYPE));		
		CWIPORDSTS.CUST_ISC_YN = IWIPORDDAT.CUST_ISC_YN;
		memcpy(CWIPORDSTS.OPER_NO, IWIPORDDAT.OPER_NO, sizeof(CWIPORDSTS.OPER_NO));
		memcpy(CWIPORDSTS.WORK_CENTER, IWIPORDDAT.WORK_CENTER, sizeof(CWIPORDSTS.WORK_CENTER));		
		memcpy(CWIPORDSTS.WORK_CENTER_DESC, IWIPORDDAT.WORK_CENTER_DESC, sizeof(CWIPORDSTS.WORK_CENTER_DESC));
		memcpy(CWIPORDSTS.STD_TEXT_KEY, IWIPORDDAT.STD_TEXT_KEY, sizeof(CWIPORDSTS.STD_TEXT_KEY));
		memcpy(CWIPORDSTS.OPER_SHORT_DESC, IWIPORDDAT.OPER_SHORT_DESC, sizeof(CWIPORDSTS.OPER_SHORT_DESC));		
		CWIPORDSTS.DEL_YN  = IWIPORDDAT.DEL_YN;
		memcpy(CWIPORDSTS.VALUATION_TYPE, IWIPORDDAT.VALUATION_TYPE, sizeof(CWIPORDSTS.VALUATION_TYPE));
		memcpy(CWIPORDSTS.ZZBOMID, IWIPORDDAT.ZZBOMID, sizeof(CWIPORDSTS.ZZBOMID));
		memcpy(CWIPORDSTS.ZSHIPNO, IWIPORDDAT.ZSHIPNO, sizeof(CWIPORDSTS.ZSHIPNO));
		memcpy(CWIPORDSTS.ZARTCOR, IWIPORDDAT.ZARTCOR, sizeof(CWIPORDSTS.ZARTCOR));

		CDB_insert_cwipordsts(&CWIPORDSTS);
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

			TRS.add_fieldmsg(out_node, "CWIPORDSTS INSERT", MP_NVST);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			//CDB_close_iwiporddat(1);

			// IS-21-07-007 ERP �������̽� ������ ����(Power Range)
			// DB OPEN / FETCH CASE CURSOR CLOSE
			CDB_close_iwiporddat(2);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
				
		//2.DELETE IWIPORDDAT
		CDB_delete_iwiporddat(1,&IWIPORDDAT);
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

            TRS.add_fieldmsg(out_node, "IWIPORDDAT DELETE", MP_NVST);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			//CDB_close_iwiporddat(1);
			
			// IS-21-07-007 ERP �������̽� ������ ����(Power Range)
			// DB OPEN / FETCH CASE CURSOR CLOSE
			CDB_close_iwiporddat(2);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

        //3. BACKUP TABLE COPY
        CDB_init_ibakorddat(&IBAKORDDAT);
        //Structur Copy (IWIPORDDAT->IBAKORDDAT)
		memcpy(IBAKORDDAT.DOC_ID, IWIPORDDAT.DOC_ID, sizeof(struct IWIPORDDAT_TAG));
		CDB_delete_ibakorddat(1, &IBAKORDDAT);
		CDB_insert_ibakorddat(&IBAKORDDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		DB_commit();
	}
	
	return MP_TRUE;
}