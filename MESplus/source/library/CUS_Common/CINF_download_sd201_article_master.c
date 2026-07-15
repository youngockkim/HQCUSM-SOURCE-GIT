/*******************************************************************************

    System      : MESplus
    Module      : Article master setup
    File Name   : CINF_download_sd201_article_master.c 
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
	2     2023.05.09  원복
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_ARTICLE_MASTER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Power Range
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Article_Master(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_ARTICLE_MASTER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Article_Master", out_node);

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
    CUS_INTERFACE_DOWNLOAD_ARTICLE_MASTER()
        - ERP->MES Article Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_ARTICLE_MASTER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IBASARTDEF_TAG IBASARTDEF;
    struct IBAKARTDEF_TAG IBAKARTDEF;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

	TRSNode *list_item;
	TRSNode *in_node1;
	TRSNode *out_node1;
	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CINF_ARTICLE_MASTER_ERP_SD201_PROCESS");
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
	CDB_init_ibasartdef(&IBASARTDEF);
    CDB_open_ibasartdef(2, &IBASARTDEF);
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
            TRS.add_fieldmsg(out_node, "IBASARTDEF OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASARTDEF.DOC_ID), IBASARTDEF.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBASARTDEF.SITE_ID), IBASARTDEF.SITE_ID);
			TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IBASARTDEF.MATE_NO), IBASARTDEF.MATE_NO);
            TRS.add_fieldmsg(out_node, "ARTICLE_NO", MP_STR, sizeof(IBASARTDEF.ARTICLE_NO), IBASARTDEF.ARTICLE_NO);
            TRS.add_fieldmsg(out_node, "MODULE_TYPE", MP_STR, sizeof(IBASARTDEF.MODULE_TYPE), IBASARTDEF.MODULE_TYPE);
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
		CDB_fetch_ibasartdef(2, &IBASARTDEF);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_ibasartdef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IBASARTDEF OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASARTDEF.DOC_ID), IBASARTDEF.DOC_ID);
			TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IBASARTDEF.MATE_NO), IBASARTDEF.MATE_NO);
			TRS.add_fieldmsg(out_node, "ARTICLE_NO", MP_STR, sizeof(IBASARTDEF.ARTICLE_NO), IBASARTDEF.ARTICLE_NO);
            TRS.add_fieldmsg(out_node, "ACTION_TYPE", MP_STR, sizeof(IBASARTDEF.ACTION_TYPE), IBASARTDEF.ACTION_TYPE);
			TRS.add_fieldmsg(out_node, "MODULE_TYPE", MP_STR, sizeof(IBASARTDEF.MODULE_TYPE), IBASARTDEF.MODULE_TYPE);
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
		TRS.set_string(in_node1, "TABLE_NAME", HQCEL_M1_GCM_ARTICLE, strlen(HQCEL_M1_GCM_ARTICLE));
		TRS.set_string(in_node1, "USERID", MODULE_EAP, strlen(MODULE_EAP));		
		TRS.set_char(in_node1, "PROCSTEP", 'U');
		list_item = TRS.add_node(in_node1, "DATA_LIST");		
		TRS.add_string(list_item, "KEY_1", IBASARTDEF.MATE_NO, sizeof(IBASARTDEF.MATE_NO));
		TRS.add_string(list_item, "KEY_2", IBASARTDEF.ARTICLE_NO, sizeof(IBASARTDEF.ARTICLE_NO));

		TRS.add_string(list_item, "DATA_1", IBASARTDEF.POWER, sizeof(IBASARTDEF.POWER));
		TRS.add_string(list_item, "DATA_2", IBASARTDEF.GRADE, sizeof(IBASARTDEF.GRADE));
		TRS.add_string(list_item, "DATA_3", IBASARTDEF.MODULE_TYPE, sizeof(IBASARTDEF.MODULE_TYPE));
		TRS.add_string(list_item, "DATA_4", IBASARTDEF.MODULEARTICLE_DESC, sizeof(IBASARTDEF.MODULEARTICLE_DESC));
		TRS.add_string(list_item, "DATA_5", IBASARTDEF.POWER_CLASS, sizeof(IBASARTDEF.POWER_CLASS));


		//ISSUE-11-006	ERP I/F D flag처리 안되는것 아티클,파워레인지
		//Delete flag ERP 에 추가해서 삭제 기능 추가함
		if (IBASARTDEF.ACTION_TYPE == 'D')
		{
			DBC_init_mgcmlagdat(&MGCMLAGDAT);
			memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_ARTICLE, strlen(HQCEL_M1_GCM_ARTICLE));
			memcpy(MGCMLAGDAT.KEY_1, IBASARTDEF.MATE_NO, sizeof(IBASARTDEF.MATE_NO));
			memcpy(MGCMLAGDAT.KEY_2, IBASARTDEF.ARTICLE_NO, sizeof(IBASARTDEF.ARTICLE_NO));			

			DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
			if (DB_error_code == DB_NOT_FOUND)
			{
				// DELETE
				CDB_delete_ibasartdef(1,&IBASARTDEF);

				// BACKUP
				CDB_init_ibakartdef(&IBAKARTDEF);
				memcpy(IBAKARTDEF.DOC_ID, IBASARTDEF.DOC_ID, sizeof(struct IBASARTDEF_TAG));
				CDB_delete_ibakartdef(1,&IBAKARTDEF);
				CDB_insert_ibakartdef(&IBAKARTDEF);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}

				// IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
				TRS.free_node(in_node1);
				TRS.free_node(out_node1);

				DB_commit();
				continue;
			}
			else
			{
				TRS.set_char(in_node1, "PROCSTEP", 'D');
			}
		}

		
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
			memcpy(IBASARTDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_ibasartdef(2,&IBASARTDEF);
			DB_commit();
			continue;
			*/

			// IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Article_Master", out_node1);
			TRS.copy(IBASARTDEF.RETURN_MSG, sizeof(IBASARTDEF.RETURN_MSG), out_node1, "MSG");
			CDB_update_ibasartdef(2,&IBASARTDEF);
			
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			DB_commit();
			continue;
		}

		// DELETE
		CDB_delete_ibasartdef(1,&IBASARTDEF);

		// BACKUP
        CDB_init_ibakartdef(&IBAKARTDEF);
		memcpy(IBAKARTDEF.DOC_ID, IBASARTDEF.DOC_ID, sizeof(struct IBASARTDEF_TAG));
		CDB_delete_ibakartdef(1,&IBAKARTDEF);
        CDB_insert_ibakartdef(&IBAKARTDEF);
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