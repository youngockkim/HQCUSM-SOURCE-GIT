/*******************************************************************************

    System      : MESplus
    Module      : Additional Master setup
    File Name   : CINF_download_pp115_material_master.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2021.06.29  hahakg

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_ADDITIONAL_MASTER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Material_Master()
        - ERP->MES Additional Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Additional_Master(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_ADDITIONAL_MASTER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Additional_Master", out_node);

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
    CUS_INTERFACE_DOWNLOAD_Material_Master()
        - ERP->MES Material Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_ADDITIONAL_MASTER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
    struct IWIPMATGLO_TAG IWIPMATGLO;
    struct IBAKMATGLO_TAG IBAKMATGLO;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

	TRSNode *list_item;
	TRSNode *in_node1;
	TRSNode *out_node1;

	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CINF_ADDITIONAL_MASTER_ERP_PP115_PROCESS");
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
	CDB_init_iwipmatglo(&IWIPMATGLO);
    CDB_open_iwipmatglo(2, &IWIPMATGLO);
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
            TRS.add_fieldmsg(out_node, "IWIPMATGLO OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPMATGLO.DOC_ID), IWIPMATGLO.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IWIPMATGLO.SITE_ID), IWIPMATGLO.SITE_ID);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPMATGLO.MATE_NO), IWIPMATGLO.MATE_NO);
            TRS.add_fieldmsg(out_node, "MATE_NM", MP_STR, sizeof(IWIPMATGLO.MATE_NM), IWIPMATGLO.MATE_NM);
            TRS.add_fieldmsg(out_node, "MAT_TYPE", MP_STR, sizeof(IWIPMATGLO.MAT_TYPE), IWIPMATGLO.MAT_TYPE);
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
        CDB_fetch_iwipmatglo(2, &IWIPMATGLO);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwipmatglo(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPMATGLO OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPMATGLO.DOC_ID), IWIPMATGLO.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IWIPMATGLO.SITE_ID), IWIPMATGLO.SITE_ID);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPMATGLO.MATE_NO), IWIPMATGLO.MATE_NO);
            TRS.add_fieldmsg(out_node, "MATE_NM", MP_STR, sizeof(IWIPMATGLO.MATE_NM), IWIPMATGLO.MATE_NM);
            TRS.add_fieldmsg(out_node, "MAT_TYPE", MP_STR, sizeof(IWIPMATGLO.MAT_TYPE), IWIPMATGLO.MAT_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipmatglo(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		in_node1 = TRS.create_node("IN_VALUE");
		out_node1 = TRS.create_node("OUT_VALUE");

		TRS.set_string(in_node1, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));		
		TRS.set_string(in_node1, "TABLE_NAME", "TMP_MAT_INFO", strlen("TMP_MAT_INFO"));
		TRS.set_string(in_node1, "USERID", MODULE_EAP, strlen(MODULE_EAP));		
		TRS.set_char(in_node1, "PROCSTEP", 'U');

		list_item = TRS.add_node(in_node1, "DATA_LIST");		
		TRS.add_string(list_item, "KEY_1", IWIPMATGLO.MATE_NO, sizeof(MGCMTBLDAT.KEY_1));

		// Material info Copy
		TRS.add_string(list_item, "DATA_1", IWIPMATGLO.PRODUCT_DEFINITION, sizeof(IWIPMATGLO.PRODUCT_DEFINITION));
		TRS.add_string(list_item, "DATA_2", IWIPMATGLO.WAFER_SIZE        , sizeof(IWIPMATGLO.WAFER_SIZE));
		TRS.add_string(list_item, "DATA_3", IWIPMATGLO.BUSBAR            , sizeof(IWIPMATGLO.BUSBAR));
		TRS.add_string(list_item, "DATA_4", IWIPMATGLO.MAT_TYPE          , sizeof(IWIPMATGLO.MAT_TYPE));
		TRS.add_string(list_item, "DATA_5", IWIPMATGLO.BF                , sizeof(IWIPMATGLO.BF));
		TRS.add_string(list_item, "DATA_6", IWIPMATGLO.CFP               , sizeof(IWIPMATGLO.CFP));
		TRS.add_string(list_item, "DATA_7", IWIPMATGLO.GAP               , sizeof(IWIPMATGLO.GAP));
		TRS.add_string(list_item, "DATA_8", IWIPMATGLO.FCHC              , sizeof(IWIPMATGLO.FCHC));
		TRS.add_string(list_item, "DATA_9", IWIPMATGLO.WEIGHT            , sizeof(IWIPMATGLO.WEIGHT));

		// DELETE GT(General Table)
		if(IWIPMATGLO.DATA_FLAG == 'D')
		{
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			memcpy(MGCMTBLDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMTBLDAT.TABLE_NAME, "TMP_MAT_INFO", strlen("TMP_MAT_INFO"));
			memcpy(MGCMTBLDAT.KEY_1, IWIPMATGLO.MATE_NO, sizeof(MGCMTBLDAT.KEY_1));
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
			if (DB_error_code == DB_NOT_FOUND)
			{
				// BACKUP TABLE : IWIPMATGLO -> IBAKMATGLO
				CDB_init_ibakmatglo(&IBAKMATGLO);
				memcpy(IBAKMATGLO.DOC_ID, IWIPMATGLO.DOC_ID, sizeof(struct IWIPMATGLO_TAG));
				CDB_delete_ibakmatglo(1, &IBAKMATGLO);
				CDB_insert_ibakmatglo(&IBAKMATGLO);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}

				// DELETE IWIPMATGLO
				CDB_delete_iwipmatglo(1,&IWIPMATGLO);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}

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

			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Additional_Master", out_node1);
			TRS.copy(IWIPMATGLO.RETURN_MSG, sizeof(IWIPMATGLO.RETURN_MSG), out_node1, "MSG");
			CDB_update_iwipmatglo(3,&IWIPMATGLO);
			
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			DB_commit();
			continue;
		}
		
		/***********************************/
        // BACKUP TABLE : IWIPMATGLO -> IBAKMATGLO
		/***********************************/
        CDB_init_ibakmatglo(&IBAKMATGLO);
		memcpy(IBAKMATGLO.DOC_ID, IWIPMATGLO.DOC_ID, sizeof(struct IWIPMATGLO_TAG));
		CDB_delete_ibakmatglo(1, &IBAKMATGLO);
		CDB_insert_ibakmatglo(&IBAKMATGLO);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		
		// DELETE IWIPMATGLO
		CDB_delete_iwipmatglo(1,&IWIPMATGLO);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		TRS.free_node(in_node1);
		TRS.free_node(out_node1);

		DB_commit();
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

	return MP_TRUE;
}
