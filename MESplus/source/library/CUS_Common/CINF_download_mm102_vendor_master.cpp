/*******************************************************************************

    System      : MESplus
    Module      : Vendor master setup
    File Name   : CINF_download_mm102_vendor_master.c
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

int CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER(char *s_msg_code,
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
int CUS_Interface_Download_Vendor_Master(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Vendor_Master", out_node);

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
    CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER()
        - ERP->MES Vendor Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IBASVDRMST_TAG IBASVDRMST;
    struct IBAKVDRMST_TAG IBAKVDRMST;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	TRSNode *list_item;
	TRSNode *in_node1;
	TRSNode *out_node1;

	// OPEN
	CDB_init_ibasvdrmst(&IBASVDRMST);
    CDB_open_ibasvdrmst(1, &IBASVDRMST);
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
		// INSERT GT
		CDB_fetch_ibasvdrmst(1, &IBASVDRMST);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_ibasmodloc(1);
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
            CDB_close_ibasvdrmst(1);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		// DELETE
		CDB_delete_ibasvdrmst(1,&IBASVDRMST);

        // BACKUP
        CDB_init_ibakvdrmst(&IBAKVDRMST);
        memcpy(IBAKVDRMST.DOC_ID, IBASVDRMST.DOC_ID, sizeof(IBASVDRMST.DOC_ID));
        memcpy(IBAKVDRMST.SITE_ID, IBASVDRMST.SITE_ID, sizeof(IBASVDRMST.SITE_ID));
		memcpy(IBAKVDRMST.VEN_ID, IBASVDRMST.VEN_ID, sizeof(IBASVDRMST.VEN_ID));
		memcpy(IBAKVDRMST.VEN_NM, IBASVDRMST.VEN_NM, sizeof(IBASVDRMST.VEN_NM));
		memcpy(IBAKVDRMST.VEN_GRP, IBASVDRMST.VEN_GRP, sizeof(IBASVDRMST.VEN_GRP));
		memcpy(IBAKVDRMST.VEN_GRP_NM, IBASVDRMST.VEN_GRP_NM, sizeof(IBASVDRMST.VEN_GRP_NM));
		memcpy(IBAKVDRMST.ADDRESS, IBASVDRMST.ADDRESS, sizeof(IBASVDRMST.ADDRESS));
		memcpy(IBAKVDRMST.COUNTRY, IBASVDRMST.COUNTRY, sizeof(IBASVDRMST.COUNTRY));
		IBAKVDRMST.DELIVERY_BLOCK = IBASVDRMST.DELIVERY_BLOCK;
		IBAKVDRMST.DEL_YN = IBASVDRMST.DEL_YN;
        
        CDB_insert_ibakmodloc(&IBAKVDRMST);
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

            TRS.add_fieldmsg(out_node, "IBAKMODLOC SELECT", MP_NVST);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_field_db_msg(out_node, out_node1);
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			return MP_FALSE;
        }
		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		DB_commit();
	}
	
	return MP_TRUE;
}