/******************************************************************************'

    System      : MESplus
    Module      : CINF
    File Name   : CINF_download_le107_inventory_by_module_grade_info.c
    Description : CUS_Interface_Download_Inventory_By_Grade_Info_Gerp Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP()
            + Create/Update/Delete CUS_Interface_Download_Inventory_By_Grade_Info_Gerp definition
        - CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP()
            + Main sub function of CINF_Update_CUS_Interface_Download_Inventory_By_Grade_Info_Gerp function
            + Create/Update/Delete CUS_Interface_Download_Inventory_By_Grade_Info_Gerp definition
    Detail Description
        - CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP()
            + h_proc_step
                + MP_STEP_CREATE : Create CUS_Interface_Download_Inventory_By_Grade_Info_Gerp definition
                + MP_STEP_UPDATE : Update CUS_Interface_Download_Inventory_By_Grade_Info_Gerp definition
                + MP_STEP_DELETE : Delete CUS_Interface_Download_Inventory_By_Grade_Info_Gerp definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-06-13             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
    CINF_Update_CUS_Interface_Download_Inventory_By_Grade_Info_Gerp()
        - Create/Update/Delete CUS_Interface_Download_Inventory_By_Grade_Info_Gerp definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CUS_Interface_Download_Inventory_By_Grade_Info_Gerp(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Inventory_By_Grade_Info_Gerp", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CINF_UPDATE_CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP()
        - Main sub function of "CINF_Update_CUS_Interface_Download_Inventory_By_Grade_Info_Gerp" function
        - Create/Update/Delete CUS_Interface_Download_Inventory_By_Grade_Info_Gerp definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct IINVSAPSTS_TAG IINVSAPSTS;
    struct IINVSAPSTS_TAG IINVSAPSTS_O;
    struct CINVSAPSTS_TAG CINVSAPSTS;
    char   s_sys_time[14];
    int    i_data_count = 0;
	int    i_if_count = 0;

    LOG_head("CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
      
    CDB_init_cinvsapsts(&CINVSAPSTS);
    i_data_count = (int)CDB_select_cinvsapsts_scalar(2, &CINVSAPSTS);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "CINVSAPSTS SCALAR(2)", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	CDB_init_iinvsapsts(&IINVSAPSTS);
    i_if_count = (int)CDB_select_iinvsapsts_scalar(2, &IINVSAPSTS);
	if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "IINVSAPSTS SCALAR(2)", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if (i_data_count > 0 && i_if_count > 0)
    {
		// SAP 창고 IF 데이터가 존재 하면 모든 데이터 삭제 
        CDB_delete_cinvsapsts(2, &CINVSAPSTS);
        if (DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IINVSAPSTS DELETE(2)", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVSAPSTS.DOC_ID), IINVSAPSTS.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    CDB_init_iinvsapsts(&IINVSAPSTS);
    CDB_open_iinvsapsts(1, &IINVSAPSTS);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "IINVSAPSTS OPEN(1)", MP_NVST);
        TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVSAPSTS.DOC_ID), IINVSAPSTS.DOC_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    while (1)
    {
        CDB_fetch_iinvsapsts(1, &IINVSAPSTS);
        if (DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_iinvsapsts(1);
            break;
        }
        else if (DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IINVSAPSTS OPEN(1)", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVSAPSTS.DOC_ID), IINVSAPSTS.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iinvsapsts(1);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
       
        CDB_init_cinvsapsts(&CINVSAPSTS);
        memcpy(CINVSAPSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
        memcpy(CINVSAPSTS.OPER, IINVSAPSTS.OPER_NO, sizeof(IINVSAPSTS.OPER_NO));
        CDB_select_cinvsapsts(1, &CINVSAPSTS);
		if (DB_error_code != DB_SUCCESS)
        {
            if (DB_error_code == DB_NOT_FOUND)
			{
				CDB_init_cinvsapsts(&CINVSAPSTS);
				memcpy(CINVSAPSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CINVSAPSTS.OPER, IINVSAPSTS.OPER_NO, sizeof(CINVSAPSTS.OPER));
				memcpy(CINVSAPSTS.ERP_TIME, IINVSAPSTS.ERP_TIME, sizeof(CINVSAPSTS.ERP_TIME));				
				CINVSAPSTS.TOTAL_QTY = COM_atoi(IINVSAPSTS.TOTAL_QTY, sizeof(IINVSAPSTS.TOTAL_QTY));
				CINVSAPSTS.A_GRADE_QTY = COM_atoi(IINVSAPSTS.A_GRADE_QTY, sizeof(IINVSAPSTS.A_GRADE_QTY));
				CINVSAPSTS.B_GRADE_QTY = COM_atoi(IINVSAPSTS.B_GRADE_QTY, sizeof(IINVSAPSTS.B_GRADE_QTY));
				CINVSAPSTS.C_GRADE_QTY = COM_atoi(IINVSAPSTS.C_GRADE_QTY, sizeof(IINVSAPSTS.C_GRADE_QTY));
				memcpy(CINVSAPSTS.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
				//memcpy(CINVSAPSTS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));				
                memcpy(CINVSAPSTS.CREATE_TIME, "20230701083020", strlen("20230701083020")); // 0704 EMI오류로 고정값(의미없는값)
				CDB_insert_cinvsapsts(&CINVSAPSTS);
				if (DB_error_code != DB_SUCCESS)
				{
					//PASS
				}
			}
			else if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "IINVSAPSTS OPEN(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IINVSAPSTS.DOC_ID), IINVSAPSTS.DOC_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_iinvsapsts(1);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
        }
		else
		{
			memcpy(CINVSAPSTS.ERP_TIME, IINVSAPSTS.ERP_TIME, sizeof(CINVSAPSTS.ERP_TIME));
			CINVSAPSTS.TOTAL_QTY = COM_atoi(IINVSAPSTS.TOTAL_QTY, sizeof(IINVSAPSTS.TOTAL_QTY));
			CINVSAPSTS.A_GRADE_QTY = COM_atoi(IINVSAPSTS.A_GRADE_QTY, sizeof(IINVSAPSTS.A_GRADE_QTY));
            CINVSAPSTS.B_GRADE_QTY = COM_atoi(IINVSAPSTS.B_GRADE_QTY, sizeof(IINVSAPSTS.B_GRADE_QTY));
            CINVSAPSTS.C_GRADE_QTY = COM_atoi(IINVSAPSTS.C_GRADE_QTY, sizeof(IINVSAPSTS.C_GRADE_QTY));
			memcpy(CINVSAPSTS.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
			//memcpy(CINVSAPSTS.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
            memcpy(CINVSAPSTS.UPDATE_TIME, "20230701083020", strlen("20230701083020")); // 0704 EMI오류로 고정값(의미없는값)
			CDB_update_cinvsapsts(1, &CINVSAPSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//PASS
			}
		}
        
        //DELETE IINVSAPSTS 
        CDB_init_iinvsapsts(&IINVSAPSTS_O);
        memcpy(IINVSAPSTS_O.DOC_ID, IINVSAPSTS.DOC_ID, sizeof(IINVSAPSTS.DOC_ID));
        memcpy(IINVSAPSTS_O.SITE_ID, IINVSAPSTS.SITE_ID, sizeof(IINVSAPSTS.SITE_ID));
        memcpy(IINVSAPSTS_O.OPER_NO, IINVSAPSTS.OPER_NO, sizeof(IINVSAPSTS.OPER_NO));
        CDB_delete_iinvsapsts(1, &IINVSAPSTS_O);
        if (DB_error_code != DB_SUCCESS)
        {
            //PASS
        }
    }

    return MP_TRUE;
} 
