/*******************************************************************************

    System      : MESplus
    Module      : Production Order Routing 정보 DownLoad
    File Name   : CINF_download_pp107_production_routing.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.03  Seongwook.Hwang	 Create

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"

int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ROUTING(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Production Order Routing 정보 DownLoad
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Production_Routing(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_PRODUCTION_ROUTING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Production_Routing", out_node);

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
    CUS_INTERFACE_DOWNLOAD_PRODUCTION_ROUTING()
        - ERP->MES Production Routing Interface
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ROUTING(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// Variable
	struct IWIPORDRTE_TAG IWIPORDRTE; //Interface Table
	struct IBAKORDRTE_TAG IBAKORDRTE; //Interface Backup Table
	struct CWIPORDRTE_TAG CWIPORDRTE; //Custom Order Table
	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_DOWNLOAD_PRODUCTION_ROUTING");
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
	CDB_init_iwipordrte(&IWIPORDRTE);
    CDB_open_iwipordrte(2, &IWIPORDRTE);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "IWIPORDRTE OPEN", MP_NVST);
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
		CDB_fetch_iwipordrte(2, &IWIPORDRTE);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwipordrte(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPORDRTE FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPORDRTE.DOC_ID), IWIPORDRTE.DOC_ID);            
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPORDRTE.PROD_ORDER_NO), IWIPORDRTE.PROD_ORDER_NO);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipordrte(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		memcpy(IWIPORDRTE.INF_PROC_TIME, s_sys_time, sizeof(s_sys_time)); 

		// 삭제 FLAG 일 경우
		if (IWIPORDRTE.DEL_YN == 'Y')
		{
			/***********************************/
			// BACKUP TABLE : IWIPORDRTE -> IBAKORDRTE
			// IBAKORDRTE Table Insert
			/***********************************/

			CDB_init_ibakordrte(&IBAKORDRTE);
			memcpy(IBAKORDRTE.DOC_ID, IWIPORDRTE.DOC_ID, sizeof(struct IWIPORDRTE_TAG));
			CDB_delete_ibakordrte(1, &IBAKORDRTE);
			CDB_insert_ibakordrte(&IBAKORDRTE);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			
			/***********************************/
			// 1. CWIPORDSTS Table Delete
			/***********************************/

			CDB_init_cwipordrte(&CWIPORDRTE);

			// ORDER_ID가 존재하는지 체크한다.
			memcpy(CWIPORDRTE.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPORDRTE.ORDER_ID, IWIPORDRTE.PROD_ORDER_NO, sizeof(CWIPORDRTE.ORDER_ID));
			CWIPORDRTE.SEQ = COM_atoi(IWIPORDRTE.SEQ,6); //IS-21-01-108 SAP 생산 실적 관리 인터페이스 삭제처리 수정
			CDB_select_cwipordrte(1,&CWIPORDRTE);

			if(DB_error_code != DB_NOT_FOUND) 
			{
				CDB_delete_cwipordrte(1, &CWIPORDRTE);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}

			/***********************************/
			// 2.IWIPORDDAT Table Delete
			/***********************************/

			// DELETE IWIPMATDEF
			CDB_delete_iwipordrte(1,&IWIPORDRTE);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}		

			DB_commit();
			continue;
		}

		// 1. CWIPORDRTE TABLE CONTROL
		CDB_init_cwipordrte(&CWIPORDRTE);

		// ORDER_ID가 존재하는지 체크한다.
		memcpy(CWIPORDRTE.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPORDRTE.ORDER_ID, IWIPORDRTE.PROD_ORDER_NO, sizeof(CWIPORDRTE.ORDER_ID));
		CDB_select_cwipordrte(1,&CWIPORDRTE);
		if(DB_error_code != DB_NOT_FOUND) 
		{
			// ORDER_ID가 존재하면 해당 DATA를 지운다.
			memcpy(CWIPORDRTE.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPORDRTE.ORDER_ID, IWIPORDRTE.PROD_ORDER_NO, sizeof(CWIPORDRTE.ORDER_ID));
			CWIPORDRTE.SEQ = COM_atoi(IWIPORDRTE.SEQ,6);
			CDB_delete_cwipordrte(1,&CWIPORDRTE);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPORDRTE DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPORDRTE.DOC_ID), IWIPORDRTE.DOC_ID);            				
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPORDRTE.PROD_ORDER_NO), IWIPORDRTE.PROD_ORDER_NO);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				//CDB_close_iwipordrte(1);

				// IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
				// DB OPEN / FETCH CASE CURSOR CLOSE
				CDB_close_iwipordrte(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		//데이터복사 (IWIPORDRTE -> CWIPORDRTE)			
		memcpy(CWIPORDRTE.ORDER_ID, IWIPORDRTE.PROD_ORDER_NO, sizeof(CWIPORDRTE.ORDER_ID));
		CWIPORDRTE.SEQ = COM_atoi(IWIPORDRTE.SEQ,6);
		CWIPORDRTE.DEL_YN = IWIPORDRTE.DEL_YN;
		memcpy(CWIPORDRTE.OPER_NO, IWIPORDRTE.OPER_NO, sizeof(CWIPORDRTE.OPER_NO));
		memcpy(CWIPORDRTE.WORK_CENTER, IWIPORDRTE.WORK_CENTER, sizeof(CWIPORDRTE.WORK_CENTER));
		memcpy(CWIPORDRTE.WORK_CENTER_DESC, IWIPORDRTE.WORK_CENTER_DESC, sizeof(CWIPORDRTE.WORK_CENTER_DESC));
		CWIPORDRTE.BASE_QUANTITY = IWIPORDRTE.BASE_QUANTITY;
		memcpy(CWIPORDRTE.BASE_UNIT, IWIPORDRTE.BASE_UNIT, sizeof(CWIPORDRTE.BASE_UNIT));
		memcpy(CWIPORDRTE.DIRECT_LABOUR_UNIT, IWIPORDRTE.DIRECT_LABOUR_UNIT, sizeof(CWIPORDRTE.DIRECT_LABOUR_UNIT));
		CWIPORDRTE.DIRECT_LABOUR = IWIPORDRTE.DIRECT_LABOUR;
		memcpy(CWIPORDRTE.INDIRECT_LABOUR_UNIT, IWIPORDRTE.INDIRECT_LABOUR_UNIT, sizeof(CWIPORDRTE.INDIRECT_LABOUR_UNIT));
		CWIPORDRTE.INDIRECT_LABOUR = IWIPORDRTE.INDIRECT_LABOUR;
		memcpy(CWIPORDRTE.DEPRECIATION_UNIT, IWIPORDRTE.DEPRECIATION_UNIT, sizeof(CWIPORDRTE.DEPRECIATION_UNIT));
		CWIPORDRTE.DEPRECIATION = IWIPORDRTE.DEPRECIATION;
		memcpy(CWIPORDRTE.UTILITIES_UNIT, IWIPORDRTE.UTILITIES_UNIT, sizeof(CWIPORDRTE.UTILITIES_UNIT));
		CWIPORDRTE.UTILITIES = IWIPORDRTE.UTILITIES;
		memcpy(CWIPORDRTE.SPARE_PARTS_UNIT, IWIPORDRTE.SPARE_PARTS_UNIT, sizeof(CWIPORDRTE.SPARE_PARTS_UNIT));
		CWIPORDRTE.SPARE_PARTS = IWIPORDRTE.SPARE_PARTS;
		memcpy(CWIPORDRTE.OTHER_COST_UNIT, IWIPORDRTE.OTHER_COST_UNIT, sizeof(CWIPORDRTE.OTHER_COST_UNIT));
		CWIPORDRTE.OTHER_COST = IWIPORDRTE.OTHER_COST;
		memcpy(CWIPORDRTE.CRE_ID, IWIPORDRTE.CRE_ID, sizeof(CWIPORDRTE.CRE_ID));
		memcpy(CWIPORDRTE.CRE_DATE, IWIPORDRTE.CRE_DATE, sizeof(CWIPORDRTE.CRE_DATE));
		memcpy(CWIPORDRTE.MOD_ID, IWIPORDRTE.MOD_ID, sizeof(CWIPORDRTE.MOD_ID));
		memcpy(CWIPORDRTE.MOD_DATE, IWIPORDRTE.MOD_DATE, sizeof(CWIPORDRTE.MOD_DATE));

		CDB_delete_cwipordrte(1, &CWIPORDRTE);
		CDB_insert_cwipordrte(&CWIPORDRTE);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		//2.DELETE IWIPORDRTE
		CDB_delete_iwipordrte(2,&IWIPORDRTE);
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

            TRS.add_fieldmsg(out_node, "IWIPORDRTE DELETE", MP_NVST);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			CDB_close_iwipordrte(2);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

        //3. BACKUP TABLE COPY
        CDB_init_ibakordrte(&IBAKORDRTE);
        //Structur Copy (IWIPORDRTE->IBAKORDRTE)
		memcpy(IBAKORDRTE.DOC_ID, IWIPORDRTE.DOC_ID, sizeof(struct IWIPORDRTE_TAG));
		CDB_delete_ibakordrte(1, &IBAKORDRTE);
		CDB_insert_ibakordrte(&IBAKORDRTE);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		DB_commit();
	}
	return MP_TRUE;
}
