/*******************************************************************************

    System      : MESplus
    Module      : Packing master setup
    File Name   : CINF_download_sd202_packing_master.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.11.27  SW.HWANG
	2     2020.09.01  HCHKIM         Packing H

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_PACKING_MASTER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Packing Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Packing_Master(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_PACKING_MASTER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Packing_Master", out_node);

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
    CUS_INTERFACE_DOWNLOAD_PACKING_MASTER()
        - ERP->MES Packing Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_PACKING_MASTER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IWIPPAKMST_TAG IWIPPAKMST;
    struct IBAKPAKMST_TAG IBAKPAKMST;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_H;

	char s_sys_time[14];
	char s_tmp[10];
	
	memset(s_tmp, ' ', sizeof(s_tmp));

	// PROCESS LOG PRINT
	LOG_head("CINF_PACKING_MASTER_ERP_SD202_PROCESS");
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
	CDB_init_iwippakmst(&IWIPPAKMST);
    CDB_open_iwippakmst(2, &IWIPPAKMST);
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
            TRS.add_fieldmsg(out_node, "IWIPPAKMST OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPPAKMST.DOC_ID), IWIPPAKMST.DOC_ID);            
			TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPPAKMST.MATE_NO), IWIPPAKMST.MATE_NO);
            TRS.add_fieldmsg(out_node, "QCELL_MODULE_TYPE", MP_STR, sizeof(IWIPPAKMST.QCELL_MODULE_TYPE), IWIPPAKMST.QCELL_MODULE_TYPE);
            TRS.add_fieldmsg(out_node, "PACK_TYPE", MP_STR, sizeof(IWIPPAKMST.PACK_TYPE), IWIPPAKMST.PACK_TYPE);
			TRS.add_fieldmsg(out_node, "BARCODE_ID", MP_STR, sizeof(IWIPPAKMST.BARCODE_ID), IWIPPAKMST.BARCODE_ID);
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
		CDB_fetch_iwippakmst(2, &IWIPPAKMST);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwippakmst(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPPAKMST OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPPAKMST.DOC_ID), IWIPPAKMST.DOC_ID);            
			TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPPAKMST.MATE_NO), IWIPPAKMST.MATE_NO);
            TRS.add_fieldmsg(out_node, "QCELL_MODULE_TYPE", MP_STR, sizeof(IWIPPAKMST.QCELL_MODULE_TYPE), IWIPPAKMST.QCELL_MODULE_TYPE);
            TRS.add_fieldmsg(out_node, "PACK_TYPE", MP_STR, sizeof(IWIPPAKMST.PACK_TYPE), IWIPPAKMST.PACK_TYPE);
			TRS.add_fieldmsg(out_node, "BARCODE_ID", MP_STR, sizeof(IWIPPAKMST.BARCODE_ID), IWIPPAKMST.BARCODE_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwippakmst(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		
		memcpy(IWIPPAKMST.INF_PROC_TIME, s_sys_time, sizeof(s_sys_time)); 
		//PAKQTY, PACKTYPE 누락수정.JJH
		//COM_itoa(s_tmp, IWIPPAKMST.MODULE_QTY, sizeof(s_tmp));
		//인트를 스트링으로 변경 시 앞에 공백이 들어가서 있어서 left로 변경
		COM_itoa_left(s_tmp, IWIPPAKMST.MODULE_QTY, sizeof(s_tmp));

		//@PACKING
		DBC_init_mgcmlagdat(&MGCMLAGDAT);
		
		memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
		memcpy(MGCMLAGDAT.KEY_1, IWIPPAKMST.MATE_NO, sizeof(IWIPPAKMST.MATE_NO));
		memcpy(MGCMLAGDAT.KEY_2, IWIPPAKMST.QCELL_MODULE_TYPE, sizeof(IWIPPAKMST.QCELL_MODULE_TYPE));		
		
		DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				memcpy(MGCMLAGDAT.DATA_1 , IWIPPAKMST.PACK_TYPE, sizeof(IWIPPAKMST.PACK_TYPE));		
				memcpy(MGCMLAGDAT.DATA_2 , IWIPPAKMST.BARCODE_ID, sizeof(IWIPPAKMST.BARCODE_ID));		
				memcpy(MGCMLAGDAT.DATA_3 , IWIPPAKMST.LENGTH, sizeof(IWIPPAKMST.LENGTH));		
				memcpy(MGCMLAGDAT.DATA_4 , IWIPPAKMST.BREADTH, sizeof(IWIPPAKMST.BREADTH));		
				memcpy(MGCMLAGDAT.DATA_5 , IWIPPAKMST.HEIGHT, sizeof(IWIPPAKMST.HEIGHT));		
				memcpy(MGCMLAGDAT.DATA_6 , IWIPPAKMST.GROSS_WEIGHT, sizeof(IWIPPAKMST.GROSS_WEIGHT));		
				memcpy(MGCMLAGDAT.DATA_7 , IWIPPAKMST.NET_WEIGHT, sizeof(IWIPPAKMST.NET_WEIGHT));		
				memcpy(MGCMLAGDAT.DATA_8 , IWIPPAKMST.TARE_WEIGHT, sizeof(IWIPPAKMST.TARE_WEIGHT));		
				memcpy(MGCMLAGDAT.DATA_9 , s_tmp, sizeof(s_tmp));
				memcpy(MGCMLAGDAT.DATA_10, IWIPPAKMST.AC_FLAG, sizeof(IWIPPAKMST.AC_FLAG));	
				memcpy(MGCMLAGDAT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));	
				memcpy(MGCMLAGDAT.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
				
				DBC_insert_mgcmlagdat(&MGCMLAGDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "PACKING master V INSERT", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					CDB_close_iwippakmst(2);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					DB_rollback();

					memcpy(IWIPPAKMST.RETURN_MSG, s_msg_code, strlen(s_msg_code));
					CDB_update_iwippakmst(2, &IWIPPAKMST);
					DB_commit();

					return MP_FALSE;
				}
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "PACKING master V SELECT", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_iwippakmst(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				DB_rollback();

				memcpy(IWIPPAKMST.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwippakmst(2, &IWIPPAKMST);
				DB_commit();
				
				return MP_FALSE;
			}

		}
		else
		{
			memcpy(MGCMLAGDAT.DATA_1 , IWIPPAKMST.PACK_TYPE, sizeof(IWIPPAKMST.PACK_TYPE));		
			memcpy(MGCMLAGDAT.DATA_2 , IWIPPAKMST.BARCODE_ID, sizeof(IWIPPAKMST.BARCODE_ID));		
			memcpy(MGCMLAGDAT.DATA_3 , IWIPPAKMST.LENGTH, sizeof(IWIPPAKMST.LENGTH));		
			memcpy(MGCMLAGDAT.DATA_4 , IWIPPAKMST.BREADTH, sizeof(IWIPPAKMST.BREADTH));		
			memcpy(MGCMLAGDAT.DATA_5 , IWIPPAKMST.HEIGHT, sizeof(IWIPPAKMST.HEIGHT));		
			memcpy(MGCMLAGDAT.DATA_6 , IWIPPAKMST.GROSS_WEIGHT, sizeof(IWIPPAKMST.GROSS_WEIGHT));		
			memcpy(MGCMLAGDAT.DATA_7 , IWIPPAKMST.NET_WEIGHT, sizeof(IWIPPAKMST.NET_WEIGHT));		
			memcpy(MGCMLAGDAT.DATA_8 , IWIPPAKMST.TARE_WEIGHT, sizeof(IWIPPAKMST.TARE_WEIGHT));		
			memcpy(MGCMLAGDAT.DATA_9 , s_tmp, sizeof(s_tmp));
			memcpy(MGCMLAGDAT.DATA_10, IWIPPAKMST.AC_FLAG, sizeof(IWIPPAKMST.AC_FLAG));	
			memcpy(MGCMLAGDAT.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));	
			memcpy(MGCMLAGDAT.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));

			DBC_update_mgcmlagdat(1,&MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "PACKING master V UPDATE", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_iwippakmst(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				DB_rollback();
				
				memcpy(IWIPPAKMST.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwippakmst(2, &IWIPPAKMST);
				DB_commit();
				
				return MP_FALSE;
			}
		}

		//@PACKING_H
		DBC_init_mgcmlagdat(&MGCMLAGDAT_H);
		
		memcpy(MGCMLAGDAT_H.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMLAGDAT_H.TABLE_NAME, "@PACKING_H", strlen("@PACKING_H"));
		memcpy(MGCMLAGDAT_H.KEY_1, IWIPPAKMST.MATE_NO, sizeof(IWIPPAKMST.MATE_NO));
		memcpy(MGCMLAGDAT_H.KEY_2, IWIPPAKMST.QCELL_MODULE_TYPE, sizeof(IWIPPAKMST.QCELL_MODULE_TYPE));		
		
		DBC_select_mgcmlagdat(1, &MGCMLAGDAT_H);
		if (DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				memcpy(MGCMLAGDAT_H.DATA_1 , IWIPPAKMST.PACK_TYPE, sizeof(IWIPPAKMST.PACK_TYPE));		
				memcpy(MGCMLAGDAT_H.DATA_2 , IWIPPAKMST.BARCODE_ID, sizeof(IWIPPAKMST.BARCODE_ID));		
				memcpy(MGCMLAGDAT_H.DATA_3 , IWIPPAKMST.LENGTH, sizeof(IWIPPAKMST.LENGTH));		
				memcpy(MGCMLAGDAT_H.DATA_4 , IWIPPAKMST.BREADTH, sizeof(IWIPPAKMST.BREADTH));		
				memcpy(MGCMLAGDAT_H.DATA_5 , IWIPPAKMST.HEIGHT, sizeof(IWIPPAKMST.HEIGHT));		
				memcpy(MGCMLAGDAT_H.DATA_6 , IWIPPAKMST.GROSS_WEIGHT, sizeof(IWIPPAKMST.GROSS_WEIGHT));		
				memcpy(MGCMLAGDAT_H.DATA_7 , IWIPPAKMST.NET_WEIGHT, sizeof(IWIPPAKMST.NET_WEIGHT));		
				memcpy(MGCMLAGDAT_H.DATA_8 , IWIPPAKMST.TARE_WEIGHT, sizeof(IWIPPAKMST.TARE_WEIGHT));		
				memcpy(MGCMLAGDAT_H.DATA_9 , s_tmp, sizeof(s_tmp)); //MODULE_QTY
				memcpy(MGCMLAGDAT_H.DATA_10, IWIPPAKMST.AC_FLAG, sizeof(IWIPPAKMST.AC_FLAG));	
				memcpy(MGCMLAGDAT_H.CREATE_TIME, s_sys_time, sizeof(s_sys_time));	
				memcpy(MGCMLAGDAT_H.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
				
				DBC_insert_mgcmlagdat(&MGCMLAGDAT_H);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "PACKING_H master INSERT", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					CDB_close_iwippakmst(2);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					DB_rollback();
				
					memcpy(IWIPPAKMST.RETURN_MSG, s_msg_code, strlen(s_msg_code));
					CDB_update_iwippakmst(2, &IWIPPAKMST);
					DB_commit();
				}
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "PACKING_H master SELECT", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_iwippakmst(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				DB_rollback();
				
				memcpy(IWIPPAKMST.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwippakmst(2, &IWIPPAKMST);
				DB_commit();
				
				return MP_FALSE;
			}

		}
		else
		{
			memcpy(MGCMLAGDAT_H.DATA_1 , IWIPPAKMST.PACK_TYPE, sizeof(IWIPPAKMST.PACK_TYPE));		
			memcpy(MGCMLAGDAT_H.DATA_2 , IWIPPAKMST.BARCODE_ID, sizeof(IWIPPAKMST.BARCODE_ID));		
			memcpy(MGCMLAGDAT_H.DATA_3 , IWIPPAKMST.LENGTH_H, sizeof(IWIPPAKMST.LENGTH_H));		
			memcpy(MGCMLAGDAT_H.DATA_4 , IWIPPAKMST.BREADTH_H, sizeof(IWIPPAKMST.BREADTH_H));		
			memcpy(MGCMLAGDAT_H.DATA_5 , IWIPPAKMST.HEIGHT_H, sizeof(IWIPPAKMST.HEIGHT_H));		
			memcpy(MGCMLAGDAT_H.DATA_6 , IWIPPAKMST.GROSS_WEIGHT_H, sizeof(IWIPPAKMST.GROSS_WEIGHT_H));		
			memcpy(MGCMLAGDAT_H.DATA_7 , IWIPPAKMST.NET_WEIGHT_H, sizeof(IWIPPAKMST.NET_WEIGHT_H));		
			memcpy(MGCMLAGDAT_H.DATA_8 , IWIPPAKMST.TARE_WEIGHT_H, sizeof(IWIPPAKMST.TARE_WEIGHT_H));		
			memcpy(MGCMLAGDAT_H.DATA_9 , s_tmp, sizeof(s_tmp)); //MODULE_QTY
			memcpy(MGCMLAGDAT_H.DATA_10, IWIPPAKMST.AC_FLAG, sizeof(IWIPPAKMST.AC_FLAG));	
			memcpy(MGCMLAGDAT_H.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));	
			memcpy(MGCMLAGDAT_H.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));

			DBC_update_mgcmlagdat(1,&MGCMLAGDAT_H);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "PACKING_H master UPDATE", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_iwippakmst(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				DB_rollback();
				
				memcpy(IWIPPAKMST.RETURN_MSG, s_msg_code, strlen(s_msg_code));
				CDB_update_iwippakmst(2, &IWIPPAKMST);
				DB_commit();
				
				return MP_FALSE;
			}
		}
		/****************************************/
        // BACKUP TABLE : IWIPPAKMST -> IBAKPAKMST
		/****************************************/
		CDB_init_ibakpakmst(&IBAKPAKMST);

		IWIPPAKMST.RETURN_TYPE = 'S';

		memcpy(IBAKPAKMST.DOC_ID, IWIPPAKMST.DOC_ID, sizeof(struct IWIPPAKMST_TAG));
		CDB_delete_ibakpakmst(1,&IBAKPAKMST);
		CDB_insert_ibakpakmst(&IBAKPAKMST);
        if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IBAKPAKMST INSERT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			CDB_close_iwippakmst(2);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			DB_rollback();
				
			CDB_update_iwippakmst(2, &IWIPPAKMST);
			DB_commit();
			return MP_FALSE;
		}
		
		// DELETE IWIPPAKMST
		CDB_delete_iwippakmst(1,&IWIPPAKMST);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IWIPPAKMST DELETE", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			CDB_close_iwippakmst(2);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			DB_rollback();
				
			CDB_update_iwippakmst(2, &IWIPPAKMST);
			DB_commit();
			return MP_FALSE;
		}

		DB_commit();
	}
	
	return MP_TRUE; 
}