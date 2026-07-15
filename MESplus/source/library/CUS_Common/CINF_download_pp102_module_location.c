/*******************************************************************************

    System      : MESplus
    Module      : Module location setup
    File Name   : CINF_download_pp102_module_location.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.11.13  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_MODULE_LOCATION(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Module_Location()
        - ERP->MES Module Location
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Module_Location(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_MODULE_LOCATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Module_Location", out_node);

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
    CUS_INTERFACE_DOWNLOAD_MODULE_LOCATION()
        - ERP->MES Module Location
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_MODULE_LOCATION(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
    struct IBASMODLOC_TAG IBASMODLOC;
    struct IBAKMODLOC_TAG IBAKMODLOC;
	TRSNode *list_item;
	TRSNode *in_node1;
	TRSNode *out_node1;
	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CINF_MODULE_LOCATION_ERP_PP102_PROCESS");
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
	CDB_init_ibasmodloc(&IBASMODLOC);
    CDB_open_ibasmodloc(2, &IBASMODLOC);
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
            TRS.add_fieldmsg(out_node, "IBASMODLOC OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASMODLOC.DOC_ID), IBASMODLOC.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBASMODLOC.SITE_ID), IBASMODLOC.SITE_ID);
            TRS.add_fieldmsg(out_node, "LOC_ID", MP_STR, sizeof(IBASMODLOC.LOC_ID), IBASMODLOC.LOC_ID);
            TRS.add_fieldmsg(out_node, "LOC_NM", MP_STR, sizeof(IBASMODLOC.LOC_NM), IBASMODLOC.LOC_NM);
            TRS.add_fieldmsg(out_node, "DEL_YN", MP_STR, sizeof(IBASMODLOC.DEL_YN), IBASMODLOC.DEL_YN);
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
        CDB_fetch_ibasmodloc(2, &IBASMODLOC);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_ibasmodloc(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IBASMODLOC OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASMODLOC.DOC_ID), IBASMODLOC.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBASMODLOC.SITE_ID), IBASMODLOC.SITE_ID);
            TRS.add_fieldmsg(out_node, "LOC_ID", MP_STR, sizeof(IBASMODLOC.LOC_ID), IBASMODLOC.LOC_ID);
            TRS.add_fieldmsg(out_node, "LOC_NM", MP_STR, sizeof(IBASMODLOC.LOC_NM), IBASMODLOC.LOC_NM);
            TRS.add_fieldmsg(out_node, "DEL_YN", MP_STR, sizeof(IBASMODLOC.DEL_YN), IBASMODLOC.DEL_YN);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_ibasmodloc(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		in_node1 = TRS.create_node("IN_VALUE");
		out_node1 = TRS.create_node("OUT_VALUE");

		TRS.set_string(in_node1, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.set_string(in_node1, "TABLE_NAME", "@LOCATION", strlen("@LOCATION"));
		TRS.set_string(in_node1, "USERID", MODULE_EAP, strlen(MODULE_EAP));		
		TRS.set_char(in_node1, "PROCSTEP", 'U');
		list_item = TRS.add_node(in_node1, "DATA_LIST");		
		TRS.add_string(list_item, "KEY_1", IBASMODLOC.LOC_ID, sizeof(IBASMODLOC.LOC_ID));
		TRS.add_string(list_item, "DATA_1", IBASMODLOC.LOC_NM, sizeof(IBASMODLOC.LOC_NM));

		// INSERT GT(General Table)
		if(BAS_UPDATE_DATA_LIST(s_msg_code, in_node1, out_node1)== MP_FALSE)
		{
			DB_rollback();
			/*
			COM_set_field_db_msg(out_node, out_node1);
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
			TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
			memcpy(IBASMODLOC.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_ibasmodloc(2,&IBASMODLOC);
			DB_commit();
			continue;
			*/

			// IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Module_Location", out_node1);
			TRS.copy(IBASMODLOC.RETURN_MSG, sizeof(IBASMODLOC.RETURN_MSG), out_node1, "MSG");
			CDB_update_ibasmodloc(2,&IBASMODLOC); // pc file 수정 포함 (WHERE 조건 수정)
			
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			DB_commit();
			continue;
		} 
		
		// DELETE
		CDB_delete_ibasmodloc(1,&IBASMODLOC);

        // BACKUP
        CDB_init_ibakmodloc(&IBAKMODLOC);
		memcpy(IBAKMODLOC.DOC_ID, IBASMODLOC.DOC_ID, sizeof(struct IBASMODLOC_TAG));
		CDB_delete_ibakmodloc(1, &IBAKMODLOC);
		CDB_insert_ibakmodloc(&IBAKMODLOC);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		DB_commit();
	}

	return MP_TRUE;
}