/*******************************************************************************

    System      : MESplus
    Module      : Costcenter master setup
    File Name   : CINF_download_qm101_cell_block.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.11.27  YS KIM

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_CELL_BLOCK(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Costcenter_Master()
        - ERP->MES Costcenter Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Cell_Block(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_CELL_BLOCK(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Cell_Block", out_node);

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
    CUS_INTERFACE_DOWNLOAD_CELL_BLOCK()
        - ERP->MES Costcenter Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_CELL_BLOCK(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IQCMCELBLK_TAG IQCMCELBLK;
	struct CINVCELRCV_TAG CINVCELRCV;
	struct IBAKCELBLK_TAG IBAKCELBLK;

	char s_sys_time[14];

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
	CDB_init_iqcmcelblk(&IQCMCELBLK);

	CDB_open_iqcmcelblk(2, &IQCMCELBLK);
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
			TRS.add_fieldmsg(out_node, "IQCMCELBLK  OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMCELBLK.DOC_ID), IQCMCELBLK.DOC_ID);			
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
		CDB_fetch_iqcmcelblk(2, &IQCMCELBLK);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_iqcmcelblk(2);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IQCMCELBLK OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMCELBLK.DOC_ID), IQCMCELBLK.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipcelgrb(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		CDB_init_cinvcelrcv(&CINVCELRCV);
		memcpy(CINVCELRCV.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CINVCELRCV.SMALLBOXID, IQCMCELBLK.SMALLBOXID, sizeof(CINVCELRCV.SMALLBOXID));
		CDB_select_cinvcelrcv(2, &CINVCELRCV); 
		if(DB_error_code != DB_SUCCESS)
		{ 
			if(DB_error_code == DB_NOT_FOUND)
			{

			}
			else
			{
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CINVCELRCV SELECT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CINVCELRCV.FACTORY), CINVCELRCV.FACTORY); 
				TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_STR, sizeof(CINVCELRCV.INV_LOT_ID), CINVCELRCV.INV_LOT_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}
		}
		else
		{
			CINVCELRCV.BLOCK_STATUS  = IQCMCELBLK.BLOCK_STATUS;
			CDB_update_cinvcelrcv(1, &CINVCELRCV);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CINVCELRCV UPDATE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CINVCELRCV.FACTORY), CINVCELRCV.FACTORY); 
				TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_STR, sizeof(CINVCELRCV.INV_LOT_ID), CINVCELRCV.INV_LOT_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 

			//BACK UP
			CDB_init_ibakcelblk(&IBAKCELBLK);
			memcpy(IBAKCELBLK.DOC_ID, IQCMCELBLK.DOC_ID, sizeof(IBAKCELBLK.DOC_ID));
			memcpy(IBAKCELBLK.SITE_ID, IQCMCELBLK.SITE_ID, sizeof(IBAKCELBLK.SITE_ID));
			memcpy(IBAKCELBLK.SMALLBOXID, IQCMCELBLK.SMALLBOXID, sizeof(IBAKCELBLK.SMALLBOXID));
			CDB_select_ibakcelblk(1, &IBAKCELBLK); 
			if(DB_error_code != DB_SUCCESS)
			{ 
				if(DB_error_code == DB_NOT_FOUND)
				{
					memcpy(IBAKCELBLK.REPORT_NO, IQCMCELBLK.REPORT_NO, sizeof(IBAKCELBLK.REPORT_NO));
					memcpy(IBAKCELBLK.BERGER_NO, IQCMCELBLK.BERGER_NO, sizeof(IBAKCELBLK.BERGER_NO));
					memcpy(IBAKCELBLK.MATE_NO, IQCMCELBLK.MATE_NO, sizeof(IBAKCELBLK.MATE_NO));
					IBAKCELBLK.BLOCK_STATUS  = IQCMCELBLK.BLOCK_STATUS; 
					memcpy(IBAKCELBLK.BLOCK_DATE, IQCMCELBLK.BLOCK_DATE,sizeof(IBAKCELBLK.BLOCK_DATE));
					memcpy(IBAKCELBLK.BLOCK_REASONCODE, IQCMCELBLK.BLOCK_REASONCODE,sizeof(IBAKCELBLK.BLOCK_REASONCODE));
					memcpy(IBAKCELBLK.BLOCK_COMMENTS, IQCMCELBLK.BLOCK_COMMENTS,sizeof(IBAKCELBLK.BLOCK_COMMENTS));
					memcpy(IBAKCELBLK.BLOCK_REASONCODE_SMALLBOX, IQCMCELBLK.BLOCK_REASONCODE_SMALLBOX,sizeof(IBAKCELBLK.BLOCK_REASONCODE_SMALLBOX));
					memcpy(IBAKCELBLK.BLOCK_COMMENTS_SMALLBOX, IQCMCELBLK.BLOCK_COMMENTS_SMALLBOX,sizeof(IBAKCELBLK.BLOCK_COMMENTS_SMALLBOX));
					memcpy(IBAKCELBLK.BLOCK_REASONCODE_LARA, IQCMCELBLK.BLOCK_REASONCODE_LARA,sizeof(IBAKCELBLK.BLOCK_REASONCODE_LARA));
					memcpy(IBAKCELBLK.BLOCK_COMMENTS_LARA, IQCMCELBLK.BLOCK_COMMENTS_LARA,sizeof(IBAKCELBLK.BLOCK_COMMENTS_LARA));
					memcpy(IBAKCELBLK.INF_TIME, IQCMCELBLK.INF_TIME,sizeof(IBAKCELBLK.INF_TIME));
					memcpy(IBAKCELBLK.INF_PROC_TIME, IQCMCELBLK.INF_PROC_TIME,sizeof(IBAKCELBLK.INF_PROC_TIME));
					memcpy(IBAKCELBLK.CMF_1, IQCMCELBLK.CMF_1,sizeof(IBAKCELBLK.CMF_1));
					memcpy(IBAKCELBLK.CMF_2, IQCMCELBLK.CMF_2,sizeof(IBAKCELBLK.CMF_2));
					memcpy(IBAKCELBLK.CMF_3, IQCMCELBLK.CMF_3,sizeof(IBAKCELBLK.CMF_3));
					memcpy(IBAKCELBLK.CMF_4, IQCMCELBLK.CMF_4,sizeof(IBAKCELBLK.CMF_4));
					memcpy(IBAKCELBLK.CMF_5, IQCMCELBLK.CMF_5,sizeof(IBAKCELBLK.CMF_5));
					IBAKCELBLK.DATA_FLAG  = IQCMCELBLK.DATA_FLAG;
					memcpy(IBAKCELBLK.UPDATE_COUNT, IQCMCELBLK.UPDATE_COUNT,sizeof(IBAKCELBLK.UPDATE_COUNT));
					memcpy(IBAKCELBLK.INSERT_COUNT, IQCMCELBLK.INSERT_COUNT,sizeof(IBAKCELBLK.INSERT_COUNT));
					memcpy(IBAKCELBLK.DELETE_COUNT, IQCMCELBLK.DELETE_COUNT,sizeof(IBAKCELBLK.DELETE_COUNT));
					memcpy(IBAKCELBLK.SQL_DML_COUNT, IQCMCELBLK.SQL_DML_COUNT,sizeof(IBAKCELBLK.SQL_DML_COUNT));
					memcpy(IBAKCELBLK.ZPICODE, IQCMCELBLK.ZPICODE,sizeof(IBAKCELBLK.ZPICODE));
					memcpy(IBAKCELBLK.ZPIMSGID, IQCMCELBLK.ZPIMSGID,sizeof(IBAKCELBLK.ZPIMSGID));
					IBAKCELBLK.RETURN_TYPE  = IQCMCELBLK.RETURN_TYPE;
					memcpy(IBAKCELBLK.RETURN_MSG, IQCMCELBLK.RETURN_MSG,sizeof(IBAKCELBLK.RETURN_MSG));
					memcpy(IBAKCELBLK.ZIFERNAM, IQCMCELBLK.ZIFERNAM,sizeof(IBAKCELBLK.ZIFERNAM));
					memcpy(IBAKCELBLK.ZIFDATE, IQCMCELBLK.ZIFDATE,sizeof(IBAKCELBLK.ZIFDATE));
					memcpy(IBAKCELBLK.ZIFTIME, IQCMCELBLK.ZIFTIME,sizeof(IBAKCELBLK.ZIFTIME));
					IBAKCELBLK.ZPISTAT  = IQCMCELBLK.ZPISTAT;
					memcpy(IBAKCELBLK.ZPIMSG, IQCMCELBLK.ZPIMSG,sizeof(IBAKCELBLK.ZPIMSG));
					CDB_insert_ibakcelblk(&IBAKCELBLK); 
					if(DB_error_code != DB_SUCCESS)
					{ 
						strcpy(s_msg_code, "WIP-0004"); 
						TRS.add_fieldmsg(out_node, "IBAKCELBLK INSERT", MP_NVST); 
						TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKCELBLK.DOC_ID), IBAKCELBLK.DOC_ID); 
						TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKCELBLK.SITE_ID), IBAKCELBLK.SITE_ID); 
						TRS.add_fieldmsg(out_node, "SMALLBOXID", MP_STR, sizeof(IBAKCELBLK.SMALLBOXID), IBAKCELBLK.SMALLBOXID); 
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
						return MP_FALSE; 
					} 

				}
				else
				{
					strcpy(s_msg_code, "WIP-0004"); 
					TRS.add_fieldmsg(out_node, "IBAKCELBLK SELECT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKCELBLK.DOC_ID), IBAKCELBLK.DOC_ID); 
					TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKCELBLK.SITE_ID), IBAKCELBLK.SITE_ID); 
					TRS.add_fieldmsg(out_node, "SMALLBOXID", MP_STR, sizeof(IBAKCELBLK.SMALLBOXID), IBAKCELBLK.SMALLBOXID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}
			}
			else
			{
				memcpy(IBAKCELBLK.REPORT_NO, IQCMCELBLK.REPORT_NO, sizeof(IBAKCELBLK.REPORT_NO));
				memcpy(IBAKCELBLK.BERGER_NO, IQCMCELBLK.BERGER_NO, sizeof(IBAKCELBLK.BERGER_NO));
				memcpy(IBAKCELBLK.MATE_NO, IQCMCELBLK.MATE_NO, sizeof(IBAKCELBLK.MATE_NO));
				IBAKCELBLK.BLOCK_STATUS  = IQCMCELBLK.BLOCK_STATUS; 
				memcpy(IBAKCELBLK.BLOCK_DATE, IQCMCELBLK.BLOCK_DATE,sizeof(IBAKCELBLK.BLOCK_DATE));
				memcpy(IBAKCELBLK.BLOCK_REASONCODE, IQCMCELBLK.BLOCK_REASONCODE,sizeof(IBAKCELBLK.BLOCK_REASONCODE));
				memcpy(IBAKCELBLK.BLOCK_COMMENTS, IQCMCELBLK.BLOCK_COMMENTS,sizeof(IBAKCELBLK.BLOCK_COMMENTS));
				memcpy(IBAKCELBLK.BLOCK_REASONCODE_SMALLBOX, IQCMCELBLK.BLOCK_REASONCODE_SMALLBOX,sizeof(IBAKCELBLK.BLOCK_REASONCODE_SMALLBOX));
				memcpy(IBAKCELBLK.BLOCK_COMMENTS_SMALLBOX, IQCMCELBLK.BLOCK_COMMENTS_SMALLBOX,sizeof(IBAKCELBLK.BLOCK_COMMENTS_SMALLBOX));
				memcpy(IBAKCELBLK.BLOCK_REASONCODE_LARA, IQCMCELBLK.BLOCK_REASONCODE_LARA,sizeof(IBAKCELBLK.BLOCK_REASONCODE_LARA));
				memcpy(IBAKCELBLK.BLOCK_COMMENTS_LARA, IQCMCELBLK.BLOCK_COMMENTS_LARA,sizeof(IBAKCELBLK.BLOCK_COMMENTS_LARA));
				memcpy(IBAKCELBLK.INF_TIME, IQCMCELBLK.INF_TIME,sizeof(IBAKCELBLK.INF_TIME));
				memcpy(IBAKCELBLK.INF_PROC_TIME, IQCMCELBLK.INF_PROC_TIME,sizeof(IBAKCELBLK.INF_PROC_TIME));
				memcpy(IBAKCELBLK.CMF_1, IQCMCELBLK.CMF_1,sizeof(IBAKCELBLK.CMF_1));
				memcpy(IBAKCELBLK.CMF_2, IQCMCELBLK.CMF_2,sizeof(IBAKCELBLK.CMF_2));
				memcpy(IBAKCELBLK.CMF_3, IQCMCELBLK.CMF_3,sizeof(IBAKCELBLK.CMF_3));
				memcpy(IBAKCELBLK.CMF_4, IQCMCELBLK.CMF_4,sizeof(IBAKCELBLK.CMF_4));
				memcpy(IBAKCELBLK.CMF_5, IQCMCELBLK.CMF_5,sizeof(IBAKCELBLK.CMF_5));
				IBAKCELBLK.DATA_FLAG  = IQCMCELBLK.DATA_FLAG;
				memcpy(IBAKCELBLK.UPDATE_COUNT, IQCMCELBLK.UPDATE_COUNT,sizeof(IBAKCELBLK.UPDATE_COUNT));
				memcpy(IBAKCELBLK.INSERT_COUNT, IQCMCELBLK.INSERT_COUNT,sizeof(IBAKCELBLK.INSERT_COUNT));
				memcpy(IBAKCELBLK.DELETE_COUNT, IQCMCELBLK.DELETE_COUNT,sizeof(IBAKCELBLK.DELETE_COUNT));
				memcpy(IBAKCELBLK.SQL_DML_COUNT, IQCMCELBLK.SQL_DML_COUNT,sizeof(IBAKCELBLK.SQL_DML_COUNT));
				memcpy(IBAKCELBLK.ZPICODE, IQCMCELBLK.ZPICODE,sizeof(IBAKCELBLK.ZPICODE));
				memcpy(IBAKCELBLK.ZPIMSGID, IQCMCELBLK.ZPIMSGID,sizeof(IBAKCELBLK.ZPIMSGID));
				IBAKCELBLK.RETURN_TYPE  = IQCMCELBLK.RETURN_TYPE;
				memcpy(IBAKCELBLK.RETURN_MSG, IQCMCELBLK.RETURN_MSG,sizeof(IBAKCELBLK.RETURN_MSG));
				memcpy(IBAKCELBLK.ZIFERNAM, IQCMCELBLK.ZIFERNAM,sizeof(IBAKCELBLK.ZIFERNAM));
				memcpy(IBAKCELBLK.ZIFDATE, IQCMCELBLK.ZIFDATE,sizeof(IBAKCELBLK.ZIFDATE));
				memcpy(IBAKCELBLK.ZIFTIME, IQCMCELBLK.ZIFTIME,sizeof(IBAKCELBLK.ZIFTIME));
				IBAKCELBLK.ZPISTAT  = IQCMCELBLK.ZPISTAT;
				memcpy(IBAKCELBLK.ZPIMSG, IQCMCELBLK.ZPIMSG,sizeof(IBAKCELBLK.ZPIMSG));
				CDB_update_ibakcelblk(1, &IBAKCELBLK);
				if(DB_error_code != DB_SUCCESS)
				{ 
					strcpy(s_msg_code, "WIP-0004"); 
					TRS.add_fieldmsg(out_node, "IBAKCELBLK UPDATE", MP_NVST); 
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKCELBLK.DOC_ID), IBAKCELBLK.DOC_ID); 
					TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKCELBLK.SITE_ID), IBAKCELBLK.SITE_ID); 
					TRS.add_fieldmsg(out_node, "SMALLBOXID", MP_STR, sizeof(IBAKCELBLK.SMALLBOXID), IBAKCELBLK.SMALLBOXID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				} 

			}

			// DELETE
			CDB_delete_iqcmcelblk(1, &IQCMCELBLK);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "IQCMCELBLK DELETE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMCELBLK.DOC_ID), IQCMCELBLK.DOC_ID); 
				TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IQCMCELBLK.SITE_ID), IQCMCELBLK.SITE_ID); 
				TRS.add_fieldmsg(out_node, "SMALLBOXID", MP_STR, sizeof(IQCMCELBLK.SMALLBOXID), IQCMCELBLK.SMALLBOXID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 

			DB_commit();

		}

		
	}

	return MP_TRUE;
}