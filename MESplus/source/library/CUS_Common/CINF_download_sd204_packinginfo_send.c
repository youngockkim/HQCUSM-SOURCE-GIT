/*******************************************************************************

    System      : MESplus
    Module      : Packing Information Send
    File Name   : CINF_download_sd204_packinginfo_send.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                         
    ---------------------------------------------------------------------------
    1     2019.1.8  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_PACKINGINFO_SEND(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Packing Information Send
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Packinginfo_Send(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_PACKINGINFO_SEND(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Packinginfo_Send", out_node);

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
    CUS_INTERFACE_DOWNLOAD_PACKINGINFO_SEND()
        - ERP->MES Packing Information Send
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_PACKINGINFO_SEND(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IWIPPAKIFO_TAG IWIPPAKIFO;
    struct IBAKPAKIFO_TAG IBAKPAKIFO;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPPAKHIS_TAG CWIPPAKHIS;
	struct CWIPPAKREG_TAG CWIPPAKREG;		//IS-20-12-012 
	struct CWIPLOTPAK_TAG CWIPLOTPAK_O;
	

	char s_sys_time[14];
	//int iwippakifo_flag = 2;

	// PROCESS LOG PRINT
	LOG_head("CINF_PACKING_INFO_SEND_ERP_SD204_PROCESS");
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
	//#1-UNPACKING 
	CDB_init_iwippakifo(&IWIPPAKIFO);
	CDB_open_iwippakifo(3, &IWIPPAKIFO);			//IS-20-12-012 
	if(DB_error_code != DB_SUCCESS) 
    {
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "IWIPPAKIFO OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPPAKIFO.DOC_ID), IWIPPAKIFO.DOC_ID);            
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
		CDB_fetch_iwippakifo(3,&IWIPPAKIFO);
		if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwippakifo(3);
            break;
        }
        //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
        else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPPAKIFO OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPPAKIFO.DOC_ID), IWIPPAKIFO.DOC_ID);
            TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(IWIPPAKIFO.PALLET_ID), IWIPPAKIFO.PALLET_ID);
            TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IWIPPAKIFO.MODULE_ID), IWIPPAKIFO.MODULE_ID);
            TRS.add_fieldmsg(out_node, "ACTION_TYPE", MP_CHR, sizeof(IWIPPAKIFO.ACTION_TYPE), IWIPPAKIFO.ACTION_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwippakifo(3);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		// INSERT TO CWIPLOTPAK
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		//memcpy(CWIPLOTPAK.LOT_ID, IWIPPAKIFO.MODULE_ID, strlen(CWIPLOTPAK.LOT_ID)); // Server Crash
		memcpy(CWIPLOTPAK.LOT_ID, IWIPPAKIFO.MODULE_ID, sizeof(CWIPLOTPAK.LOT_ID)); // Server Crash
		CDB_select_cwiplotpak(1,&CWIPLOTPAK);
		if(DB_error_code != DB_SUCCESS) 
		{
			CWIPLOTPAK.HIST_SEQ =0;
			
			memcpy(CWIPLOTPAK.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

			CDB_insert_cwiplotpak(&CWIPLOTPAK);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING;
			}

			
		}
		else
		{
			//CWIPPAKHIS INSERT (OLD STATUS)
		}
		
		//HISTORY COPY + MAX HISTORY SEQ;
		CDB_init_cwippakhis(&CWIPPAKHIS);
		memcpy(CWIPPAKHIS.FACTORY, CWIPLOTPAK.FACTORY, sizeof(struct CWIPLOTPAK_TAG));
		CDB_insert_cwippakhis(&CWIPPAKHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING;
		}

		memcpy(CWIPLOTPAK.PALLET_ID, IWIPPAKIFO.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));

		CWIPLOTPAK.HIST_SEQ = (int) CDB_select_cwippakhis_scalar(2, &CWIPPAKHIS) + 1;
		memcpy(CWIPLOTPAK.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		

		//AS-IS LOGIC 
		//if(IWIPPAKIFO.ACTION_TYPE == 'D'){
		//	CWIPLOTPAK.STATUS_FLAG = 'D';
		//}
		//else if(IWIPPAKIFO.ACTION_TYPE == 'I'){
		//	CWIPLOTPAK.STATUS_FLAG = 'C';
		//}	
		//
		//CDB_update_cwiplotpak(1,&CWIPLOTPAK); 
		//
		if(IWIPPAKIFO.ACTION_TYPE == 'D'){
			CWIPLOTPAK.STATUS_FLAG = 'D';
			CDB_init_cwiplotpak(&CWIPLOTPAK_O);
			memcpy(CWIPLOTPAK_O.FACTORY, CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY)); // FACTORY
			memcpy(CWIPLOTPAK_O.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID)); // 모듈 번호
			CDB_delete_cwiplotpak(1, &CWIPLOTPAK_O);

		}
		else if(IWIPPAKIFO.ACTION_TYPE == 'I'){
			CWIPLOTPAK.STATUS_FLAG = 'C';
			CDB_update_cwiplotpak(1,&CWIPLOTPAK); 
		}	
		
		//CDB_update_cwiplotpak(1,&CWIPLOTPAK); 

		
		if(DB_error_code != DB_SUCCESS) 
		{
			//CONTINUE;
		}

		
		// BACKUP
		CDB_init_ibakpakifo(&IBAKPAKIFO);
		memcpy(IBAKPAKIFO.DOC_ID, IWIPPAKIFO.DOC_ID, sizeof(struct IWIPPAKIFO_TAG));
		CDB_delete_ibakpakifo(1,&IBAKPAKIFO);
		CDB_insert_ibakpakifo(&IBAKPAKIFO);

		// DELETE IWIPPAKIFO
		
		CDB_delete_iwippakifo(1,&IWIPPAKIFO);
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_delete_iwippakifo(2,&IWIPPAKIFO); //DOC_ID 가 이상한값이 잇을경우.
		}		

		DB_commit();
	}
		

	// OPEN 
	//#2-Individual UNPACKING 
	CDB_init_iwippakifo(&IWIPPAKIFO);
	CDB_open_iwippakifo(4, &IWIPPAKIFO);
	if(DB_error_code != DB_SUCCESS) 
    {
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "IWIPPAKIFO OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPPAKIFO.DOC_ID), IWIPPAKIFO.DOC_ID);            
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
		CDB_fetch_iwippakifo(4,&IWIPPAKIFO);
		if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwippakifo(4);
            break;
        }
        //IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
        else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPPAKIFO OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPPAKIFO.DOC_ID), IWIPPAKIFO.DOC_ID);
            TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(IWIPPAKIFO.PALLET_ID), IWIPPAKIFO.PALLET_ID);
            TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IWIPPAKIFO.MODULE_ID), IWIPPAKIFO.MODULE_ID);
            TRS.add_fieldmsg(out_node, "ACTION_TYPE", MP_STR, sizeof(IWIPPAKIFO.ACTION_TYPE), IWIPPAKIFO.ACTION_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwippakifo(4);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		// INSERT TO CWIPLOTPAK
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		//memcpy(CWIPLOTPAK.LOT_ID, IWIPPAKIFO.MODULE_ID, strlen(CWIPLOTPAK.LOT_ID)); // Server Crash
		memcpy(CWIPLOTPAK.LOT_ID, IWIPPAKIFO.MODULE_ID, sizeof(CWIPLOTPAK.LOT_ID)); // Server Crash
		CDB_select_cwiplotpak(1,&CWIPLOTPAK);
		if(DB_error_code != DB_SUCCESS) 
		{
			CWIPLOTPAK.HIST_SEQ =0;
			
			memcpy(CWIPLOTPAK.CREATE_TIME, s_sys_time, sizeof(s_sys_time));

			CDB_insert_cwiplotpak(&CWIPLOTPAK);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING;
			}

			
		}
		else
		{
			//CWIPPAKREG INSERT (OLD STATUS)
		}
		
		//HISTORY COPY + MAX HISTORY SEQ;  
		CDB_init_cwippakreg(&CWIPPAKREG);
		memcpy(CWIPPAKREG.FACTORY, CWIPLOTPAK.FACTORY, sizeof(struct CWIPLOTPAK_TAG));
		CDB_insert_cwippakreg(&CWIPPAKREG);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING;
		}

		memcpy(CWIPLOTPAK.PALLET_ID, IWIPPAKIFO.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));

		CWIPLOTPAK.HIST_SEQ = (int) CDB_select_cwippakreg_scalar(2, &CWIPPAKREG) + 1;
		memcpy(CWIPLOTPAK.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		
		//AS_IS LOGIC
		/*if(IWIPPAKIFO.ACTION_TYPE == 'P'){
			CWIPLOTPAK.STATUS_FLAG = 'D';
		}
		CDB_update_cwiplotpak(1,&CWIPLOTPAK);*/ 
		//22.04.19
		if(IWIPPAKIFO.ACTION_TYPE == 'P'){
			CWIPLOTPAK.STATUS_FLAG = 'D';
			CDB_init_cwiplotpak(&CWIPLOTPAK_O);
			memcpy(CWIPLOTPAK_O.FACTORY, CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY)); // FACTORY
			memcpy(CWIPLOTPAK_O.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID)); // 모듈 번호
			CDB_delete_cwiplotpak(1, &CWIPLOTPAK_O);

		}
		else
		{
			CDB_update_cwiplotpak(1,&CWIPLOTPAK); 
		}



		if(DB_error_code != DB_SUCCESS) 
		{
			//CONTINUE;
		}

		
		// BACKUP
		CDB_init_ibakpakifo(&IBAKPAKIFO);
		memcpy(IBAKPAKIFO.DOC_ID, IWIPPAKIFO.DOC_ID, sizeof(struct IWIPPAKIFO_TAG));
		CDB_delete_ibakpakifo(1,&IBAKPAKIFO);
		CDB_insert_ibakpakifo(&IBAKPAKIFO);

		// DELETE IWIPPAKIFO
		
		CDB_delete_iwippakifo(1,&IWIPPAKIFO);
		if(DB_error_code != DB_SUCCESS)
		{
			CDB_delete_iwippakifo(2,&IWIPPAKIFO); //DOC_ID 가 이상한값이 잇을경우.
		}		

		DB_commit();
	}

	return MP_TRUE;
}