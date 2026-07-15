/*******************************************************************************

    System      : MESplus
    Module      : BOM Setup
    File Name   : CINF_download_pp103_bom_function.c
    Description : ERP IF Table -> MES Bom Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.4  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BOMCore_common.h>

int CUS_INTERFACE_DOWNLOAD_BOM_FUNCTION(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP IF Table -> MES Bom Table
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Bom_Function(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
    i_ret = CUS_INTERFACE_DOWNLOAD_BOM_FUNCTION(s_msg_code, in_node, out_node);
    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Bom_Function", out_node);

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
    CUS_INTERFACE_DOWNLOAD_BOM_FUNCTION()
        - ERP IF Table -> MES Bom Table
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_BOM_FUNCTION(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	struct IBASBOMDAT_TAG IBASBOMDAT;
	struct IBAKBOMDAT_TAG IBAKBOMDAT;
	struct MBOMSETDEF_TAG MBOMSETDEF;
	struct MBOMSETVER_TAG MBOMSETVER;
	struct MBOMSETMAT_TAG MBOMSETMAT;

	char s_sys_time[14];
	int ibasbomdat_flag = 3;
	int ibasbomdat_next_flag = 4;
	int i;
	int seq;
	int bom_list_count;
	TRSNode ** BOM_GET_LIST;
	TRSNode *bom_item;

	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_DOWNLOAD_BOM_FUNCTION");
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

	// OPEN TO IBASBOMDAT
	CDB_init_ibasbomdat(&IBASBOMDAT);
	CDB_open_ibasbomdat(ibasbomdat_flag, &IBASBOMDAT);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "IBASBOMDAT OPEN", MP_NVST);			
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		CDB_close_ibasbomdat(ibasbomdat_flag);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	// FETCH
	while(1)
	{
		CDB_fetch_ibasbomdat(ibasbomdat_flag, &IBASBOMDAT);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_ibasbomdat(ibasbomdat_flag);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IBASBOMDAT FETCH", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_ibasbomdat(ibasbomdat_flag);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		// INSERT TO MBOMSETDEF
		DBC_init_mbomsetdef(&MBOMSETDEF);
		memcpy(MBOMSETDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MBOMSETDEF.BOM_SET_ID, IBASBOMDAT.PROD_NO, sizeof(MBOMSETDEF.BOM_SET_ID));
		DBC_delete_mbomsetdef(1, &MBOMSETDEF);
		memcpy(MBOMSETDEF.BOM_SET_DESC, "PRODUCT BOM", strlen("PRODUCT BOM"));
		memcpy(MBOMSETDEF.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
		memcpy(MBOMSETDEF.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		DBC_insert_mbomsetdef(&MBOMSETDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		
		// INSERT TO MBOMSETVER
		DBC_init_mbomsetver(&MBOMSETVER);
		memcpy(MBOMSETVER.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MBOMSETVER.BOM_SET_ID, IBASBOMDAT.PROD_NO, sizeof(MBOMSETVER.BOM_SET_ID));
		MBOMSETVER.BOM_SET_VERSION = 1;
		memcpy(MBOMSETVER.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
		memcpy(MBOMSETVER.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		DBC_delete_mbomsetver(1, &MBOMSETVER);
		DBC_insert_mbomsetver(&MBOMSETVER);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		DBC_init_mbomsetmat(&MBOMSETMAT);
		memcpy(MBOMSETMAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, sizeof(MBOMSETMAT.FACTORY));
		memcpy(MBOMSETMAT.BOM_SET_ID, IBASBOMDAT.PROD_NO, sizeof(MBOMSETMAT.BOM_SET_ID));
		DBC_delete_mbomsetmat(102,&MBOMSETMAT);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		bom_item = TRS.add_node(in_node, "BOM_LIST");
		TRS.add_string(bom_item, "PROD_NO", IBASBOMDAT.PROD_NO, sizeof(IBASBOMDAT.PROD_NO));
		TRS.add_string(bom_item, "BOM_KEY", IBASBOMDAT.BOM_KEY, sizeof(IBASBOMDAT.BOM_KEY));
		TRS.add_string(bom_item, "ZIFDATE", IBASBOMDAT.ZIFDATE, sizeof(IBASBOMDAT.ZIFDATE));
	}
	
	// GET TRS BOM_LIST
	BOM_GET_LIST = TRS.get_list(in_node, "BOM_LIST");
	bom_list_count = TRS.get_item_count(in_node, "BOM_LIST");

	for(i = 0; i <bom_list_count; i++)
	{
		seq = 1;
		// REOPEN TO IBASBOMDAT
		CDB_init_ibasbomdat(&IBASBOMDAT);

		TRS.copy(IBASBOMDAT.PROD_NO, sizeof(IBASBOMDAT.PROD_NO), BOM_GET_LIST[i], "PROD_NO");
		TRS.copy(IBASBOMDAT.BOM_KEY, sizeof(IBASBOMDAT.BOM_KEY), BOM_GET_LIST[i], "BOM_KEY");
		TRS.copy(IBASBOMDAT.ZIFDATE, sizeof(IBASBOMDAT.ZIFDATE), BOM_GET_LIST[i], "ZIFDATE");
		
		CDB_open_ibasbomdat(ibasbomdat_next_flag, &IBASBOMDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IBASBOMDAT OPEN", MP_NVST);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			CDB_close_ibasbomdat(ibasbomdat_flag);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		// FETCH
		while(1)
		{
			CDB_fetch_ibasbomdat(ibasbomdat_next_flag,&IBASBOMDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					break;
				}
			}

			DBC_init_mbomsetmat(&MBOMSETMAT);
			memcpy(MBOMSETMAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, sizeof(MBOMSETMAT.FACTORY));
			memcpy(MBOMSETMAT.BOM_SET_ID, IBASBOMDAT.PROD_NO, sizeof(MBOMSETMAT.BOM_SET_ID));
			MBOMSETMAT.BOM_SET_VERSION = 1;
			MBOMSETMAT.SEQ_NUM = seq;
			memcpy(MBOMSETMAT.MAT_ID, IBASBOMDAT.MATE_NO, sizeof(MBOMSETMAT.MAT_ID));
			MBOMSETMAT.MAT_VER = 1;
			MBOMSETMAT.MAT_QTY = IBASBOMDAT.QTY;
			memcpy(MBOMSETMAT.MAT_UNIT, IBASBOMDAT.UNIT_ID, sizeof(MBOMSETMAT.MAT_UNIT));
			memcpy(MBOMSETMAT.PART_CMF_1, IBASBOMDAT.BOM_KEY, sizeof(MBOMSETMAT.PART_CMF_1));
			memcpy(MBOMSETMAT.PART_CMF_2, IBASBOMDAT.EFF_START_DATE, sizeof(MBOMSETMAT.PART_CMF_2));
			memcpy(MBOMSETMAT.PART_CMF_3, IBASBOMDAT.EFF_END_DATE, sizeof(MBOMSETMAT.PART_CMF_3));
			memcpy(MBOMSETMAT.PART_CMF_4, IBASBOMDAT.BOM_PJT, sizeof(MBOMSETMAT.PART_CMF_4));
			COM_dtoa(MBOMSETMAT.PART_CMF_5 , IBASBOMDAT.STD_QTY, sizeof(MBOMSETMAT.PART_CMF_5));
			memcpy(MBOMSETMAT.PART_CMF_6, IBASBOMDAT.STD_UNIT, sizeof(MBOMSETMAT.PART_CMF_6));
			memcpy(MBOMSETMAT.CREATE_USER_ID, "ADMIN", sizeof(MBOMSETMAT.CREATE_USER_ID));
			memcpy(MBOMSETMAT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			DBC_insert_mbomsetmat(&MBOMSETMAT);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			seq++;

			// INSERT TO IBAKBOMDAT
			CDB_init_ibakbomdat(&IBAKBOMDAT);
			memcpy(IBAKBOMDAT.DOC_ID, IBASBOMDAT.DOC_ID, sizeof(struct IBASBOMDAT_TAG));
			CDB_insert_ibakbomdat(&IBAKBOMDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}

			// DELETE TO IBASBOMDAT
			CDB_delete_ibasbomdat(1,&IBASBOMDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}

		DB_commit();

	}

	return MP_TRUE;
}