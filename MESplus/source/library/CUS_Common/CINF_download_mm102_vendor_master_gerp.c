/*******************************************************************************

    System      : MESplus
    Module      : vendor master setup
    File Name   : CINF_download_mm102_vendor_master_Gerp.c
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

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>
#include <String.h>

int CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Vendor Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Vendor_Master_Gerp(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER_GERP(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Vendor_Master_Gerp", out_node);

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
    CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER_GERP()
        - ERP->MES Vendor Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IBASVDRMST_TAG IBASVDRMST;
    struct IBAKVDRMST_TAG IBAKVDRMST;

	TRSNode *list_item;
	TRSNode *in_node1;
	TRSNode *out_node1;
	char s_sys_time[14];
	char DELIVERY_BLOCK[2];
	char DEL_YN[2];

	// PROCESS LOG PRINT
	LOG_head("CINF_VENDOR_MASTER_ERP_MM102_PROCESS");
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
	CDB_init_ibasvdrmst(&IBASVDRMST);
    CDB_open_ibasvdrmst(2, &IBASVDRMST);
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
            TRS.add_fieldmsg(out_node, "IBASVDRMST OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASVDRMST.DOC_ID), IBASVDRMST.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBASVDRMST.SITE_ID), IBASVDRMST.SITE_ID);
			TRS.add_fieldmsg(out_node, "VEN_ID", MP_STR, sizeof(IBASVDRMST.VEN_ID), IBASVDRMST.VEN_ID);
            TRS.add_fieldmsg(out_node, "VEN_NM", MP_STR, sizeof(IBASVDRMST.VEN_NM), IBASVDRMST.VEN_NM);
			TRS.add_fieldmsg(out_node, "VEN_GRP", MP_STR, sizeof(IBASVDRMST.VEN_GRP), IBASVDRMST.VEN_GRP);
            TRS.add_fieldmsg(out_node, "VEN_SHORT_NM", MP_STR, sizeof(IBASVDRMST.VEN_SHORT_NM), IBASVDRMST.VEN_SHORT_NM);
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
		CDB_fetch_ibasvdrmst(2, &IBASVDRMST);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_ibasvdrmst(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IBASVDRMST OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASVDRMST.DOC_ID), IBASVDRMST.DOC_ID);            
            TRS.add_fieldmsg(out_node, "VEN_ID", MP_STR, sizeof(IBASVDRMST.VEN_ID), IBASVDRMST.VEN_ID);
			TRS.add_fieldmsg(out_node, "VEN_NM", MP_STR, sizeof(IBASVDRMST.VEN_NM), IBASVDRMST.VEN_NM);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_ibasvdrmst(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		in_node1 = TRS.create_node("IN_VALUE");
		out_node1 = TRS.create_node("OUT_VALUE");

		TRS.set_string(in_node1, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.set_string(in_node1, "TABLE_NAME", "@VENDOR", strlen("@VENDOR"));
		TRS.set_string(in_node1, "USERID", MODULE_EAP, strlen(MODULE_EAP));		
		TRS.set_char(in_node1, "PROCSTEP", 'U');
		list_item = TRS.add_node(in_node1, "DATA_LIST");		
		TRS.add_string(list_item, "KEY_1", IBASVDRMST.VEN_ID, sizeof(IBASVDRMST.VEN_ID));
		
		TRS.add_string(list_item, "DATA_1", IBASVDRMST.VEN_NM, sizeof(IBASVDRMST.VEN_NM));

		/* 2023 - 01 - 31 */
		/* RICEF : MES-2040 */
		/* Vendor Data MES I/F */
		TRS.add_string(list_item, "DATA_2", IBASVDRMST.VEN_GRP, sizeof(IBASVDRMST.VEN_GRP));
		TRS.add_string(list_item, "DATA_3", IBASVDRMST.VEN_GRP_NM, sizeof(IBASVDRMST.VEN_GRP_NM));
		TRS.add_string(list_item, "DATA_4", IBASVDRMST.VEN_SHORT_NM, sizeof(IBASVDRMST.VEN_SHORT_NM));
		TRS.add_string(list_item, "DATA_5", IBASVDRMST.ADDRESS, sizeof(IBASVDRMST.ADDRESS));
		TRS.add_string(list_item, "DATA_6", IBASVDRMST.COUNTRY, sizeof(IBASVDRMST.COUNTRY));
		
		DELIVERY_BLOCK[0] = 0;
		DEL_YN[0] = 0;
		memset(DELIVERY_BLOCK, IBASVDRMST.DELIVERY_BLOCK, 1);
		memset(DEL_YN, IBASVDRMST.DEL_YN, 1);
		
		TRS.add_string(list_item, "DATA_7", DELIVERY_BLOCK, 2);
		TRS.add_string(list_item, "DATA_8", DEL_YN, 2);
		

		// INSERT GT(General Table)
		if(BAS_UPDATE_DATA_LIST(s_msg_code, in_node1, out_node1)== MP_FALSE)
		{
			DB_rollback();
            /*
			gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Vendor_Master_Gerp", out_node);
			COM_set_field_db_msg(out_node, out_node1);
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
			TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
			memcpy(IBASVDRMST.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_ibasvdrmst(2,&IBASVDRMST);
			DB_commit();
			continue;
            */

            //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
            COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Vendor_Master_Gerp", out_node1);
			TRS.copy(IBASVDRMST.RETURN_MSG, sizeof(IBASVDRMST.RETURN_MSG), out_node1, "MSG");
			CDB_update_ibasvdrmst(2,&IBASVDRMST);
			
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			DB_commit();
			continue;
		} 

        // BACKUP
        CDB_init_ibakvdrmst(&IBAKVDRMST);
		memcpy(IBAKVDRMST.DOC_ID, IBASVDRMST.DOC_ID, sizeof(struct IBASVDRMST_TAG));        
		CDB_delete_ibakvdrmst(1, &IBAKVDRMST);
        CDB_insert_ibakvdrmst(&IBAKVDRMST);
        if(DB_error_code != DB_SUCCESS)
        {
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;			
            TRS.add_fieldmsg(out_node, "IBAKVDRMST INSERT", MP_NVST);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_field_db_msg(out_node, out_node1);
			//CDB_close_ibakvdrmst(1);
            //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
            // DB OPEN / FETCH CASE CURSOR CLOSE
            CDB_close_ibasvdrmst(2);

			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			return MP_FALSE;
        }

		// DELETE
		CDB_delete_ibasvdrmst(1,&IBASVDRMST);
		
		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		DB_commit();
	}
	
	return MP_TRUE;
}