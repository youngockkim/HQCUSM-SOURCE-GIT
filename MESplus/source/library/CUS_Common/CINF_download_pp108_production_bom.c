/*******************************************************************************

    System      : MESplus
    Module      : Production Order Bom Á¤º¸ DownLoad
    File Name   : CINF_download_pp108_production_bom.cpp
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.03  Seongwook.Hwang	 Create

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"

int CUS_INTERFACE_DOWNLOAD_PRODUCTION_BOM(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Production Order Bom Á¤º¸ DownLoad
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Production_Bom(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_PRODUCTION_BOM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Production_Bom", out_node);

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
    CUS_INTERFACE_DOWNLOAD_PRODUCTION_BOM()
        - ERP->MES Production Order Bom Á¤º¸ DownLoad
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_PRODUCTION_BOM(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// Variable
	struct IWIPORDBOM_TAG IWIPORDBOM; //Interface Table
	struct IBAKORDBOM_TAG IBAKORDBOM; //Interface Backup Table
	struct CWIPORDBOM_TAG CWIPORDBOM; //Custom Order Table
	
	char s_sys_time[14];
	int ibomseq = 0;

	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_DOWNLOAD_PRODUCTION_BOM");
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

	// INIT
	CDB_init_iwipordbom(&IWIPORDBOM);            
    CDB_open_iwipordbom(2, &IWIPORDBOM);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "IWIPORDBOM OPEN", MP_NVST);
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
		CDB_fetch_iwipordbom(2, &IWIPORDBOM);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwipordbom(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPORDDAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPORDBOM.DOC_ID), IWIPORDBOM.DOC_ID);
			TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(IWIPORDBOM.PROD_ORDER_NO), IWIPORDBOM.PROD_ORDER_NO);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipordbom(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		memcpy(IWIPORDBOM.INF_PROC_TIME, s_sys_time, sizeof(s_sys_time)); 
		
		// »èÁ¦ FLAG ÀÏ °æ¿ì
		//if (IWIPORDBOM.DEL_YN == 'Y')
		//{
		//	/***********************************/
		//	// BACKUP TABLE : IWIPORDBOM -> IBAKORDBOM
		//	// IBAKORDBOM Table Insert
		//	/***********************************/

		//	CDB_init_ibakordbom(&IBAKORDBOM);
		//	memcpy(IBAKORDBOM.DOC_ID, IWIPORDBOM.DOC_ID, sizeof(struct IWIPORDBOM_TAG));
		//	CDB_delete_ibakordbom(1, &IBAKORDBOM);
		//	CDB_insert_ibakordbom(&IBAKORDBOM);
		//	if(DB_error_code != DB_SUCCESS)
		//	{
		//		//DO NOTHING
		//	}
		//	
		//	/***********************************/
		//	// 1. CWIPORDSTS Table Delete
		//	/***********************************/

		//	CDB_init_cwipordbom(&CWIPORDBOM);

		//	// ORDER_ID°¡ Á¸ÀçÇÏ´ÂÁö Ã¼Å©ÇÑ´Ù.
		//	memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		//	memcpy(CWIPORDBOM.ORDER_ID, IWIPORDBOM.PROD_ORDER_NO, sizeof(CWIPORDBOM.ORDER_ID));
		//	CDB_select_cwipordbom(1,&CWIPORDBOM);

		//	if(DB_error_code != DB_NOT_FOUND) 
		//	{
		//		CDB_delete_cwipordbom(1,&CWIPORDBOM);
		//		if(DB_error_code != DB_SUCCESS)
		//		{
		//			//DO NOTHING
		//		}
		//	}

		//	/***********************************/
		//	// 2.IWIPORDDAT Table Delete
		//	/***********************************/

		//	// DELETE IWIPMATDEF
		//	CDB_delete_iwipordbom(2,&IWIPORDBOM);
		//	if(DB_error_code != DB_SUCCESS)
		//	{
		//		//DO NOTHING
		//	}		

		//	DB_commit();
		//	continue;
		//}
		
		// 1. CWIPORDBOM TABLE CONTROL
		CDB_init_cwipordbom(&CWIPORDBOM);

		// ORDER_ID°¡ Á¸ÀçÇÏ´ÂÁö Ã¼Å©ÇÑ´Ù.
		memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPORDBOM.ORDER_ID, IWIPORDBOM.PROD_ORDER_NO, sizeof(CWIPORDBOM.ORDER_ID));

		ibomseq = COM_atoi(IWIPORDBOM.RS_POS, sizeof(IWIPORDBOM.RS_POS));
		CWIPORDBOM.SEQ = ibomseq;
		CDB_select_cwipordbom(1,&CWIPORDBOM);
		if(DB_error_code == DB_SUCCESS) 
		{
			// DATA Á¸ÀçÇÏ¸é ÇØ´ç DATA¸¦ Áö¿î´Ù.
			CDB_delete_cwipordbom(1,&CWIPORDBOM);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}

		//µ¥ÀÌÅÍº¹»ç (IWIPORDBOM -> CWIPORDBOM)			
		memcpy(CWIPORDBOM.RS_NUM, IWIPORDBOM.RS_NUM, sizeof(CWIPORDBOM.RS_NUM));
		memcpy(CWIPORDBOM.RS_POS, IWIPORDBOM.RS_POS, sizeof(CWIPORDBOM.RS_POS));
		memcpy(CWIPORDBOM.BOM_PJT_CATE, IWIPORDBOM.BOM_PJT_CATE, sizeof(CWIPORDBOM.BOM_PJT_CATE));
		memcpy(CWIPORDBOM.BOM_PJT_NO, IWIPORDBOM.BOM_PJT_NO, sizeof(CWIPORDBOM.BOM_PJT_NO));
		memcpy(CWIPORDBOM.MAT_ID, IWIPORDBOM.MATE_NO, sizeof(CWIPORDBOM.MAT_ID));
		memcpy(CWIPORDBOM.MATE_TYPE, IWIPORDBOM.MATE_TYPE, sizeof(CWIPORDBOM.MATE_TYPE));
		memcpy(CWIPORDBOM.MATE_NO_DESC, IWIPORDBOM.MATE_NO_DESC, sizeof(CWIPORDBOM.MATE_NO_DESC));
		CWIPORDBOM.QTY = IWIPORDBOM.QTY;
		memcpy(CWIPORDBOM.UNIT_ID, IWIPORDBOM.UNIT_ID, sizeof(CWIPORDBOM.UNIT_ID));
		memcpy(CWIPORDBOM.BATCH_NO, IWIPORDBOM.BATCH_NO, sizeof(CWIPORDBOM.BATCH_NO));
		memcpy(CWIPORDBOM.VEN_BATCH_NO, IWIPORDBOM.VEN_BATCH_NO, sizeof(CWIPORDBOM.VEN_BATCH_NO));
		memcpy(CWIPORDBOM.LOC_ID, IWIPORDBOM.LOC_ID, sizeof(CWIPORDBOM.LOC_ID));
		CWIPORDBOM.BACKFLUSH_YN = IWIPORDBOM.BACKFLUSH_YN;
		memcpy(CWIPORDBOM.HAND_BOOK, IWIPORDBOM.HAND_BOOK, sizeof(CWIPORDBOM.HAND_BOOK));
		memcpy(CWIPORDBOM.VENDOR, IWIPORDBOM.VENDOR, sizeof(CWIPORDBOM.VENDOR));
		memcpy(CWIPORDBOM.COMMENTS, IWIPORDBOM.COMMENTS, sizeof(CWIPORDBOM.COMMENTS));
		memcpy(CWIPORDBOM.CELL_PROD_TYPE, IWIPORDBOM.CELL_PROD_TYPE, sizeof(CWIPORDBOM.CELL_PROD_TYPE));
		memcpy(CWIPORDBOM.CELL_POWER_GRADE_1, IWIPORDBOM.CELL_POWER_GRADE_1, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
		memcpy(CWIPORDBOM.CELL_POWER_GRADE_2, IWIPORDBOM.CELL_POWER_GRADE_2, sizeof(CWIPORDBOM.CELL_POWER_GRADE_2));
		memcpy(CWIPORDBOM.CELL_CONVERSION_RATE, IWIPORDBOM.CELL_CONVERSION_RATE, sizeof(CWIPORDBOM.CELL_CONVERSION_RATE));
		memcpy(CWIPORDBOM.CELL_POWER_RATE, IWIPORDBOM.CELL_POWER_RATE, sizeof(CWIPORDBOM.CELL_POWER_RATE));
		CWIPORDBOM.DEL_YN = IWIPORDBOM.DEL_YN;

		//CMF_1 필드 맵핑(GLASS 자재인 경우 , 1차 2차 구분)
		memcpy(CWIPORDBOM.CMF_1, IWIPORDBOM.CMF_1, sizeof(CWIPORDBOM.CMF_1));

		//1. INSERT CWIPORDBOM
		CDB_insert_cwipordbom(&CWIPORDBOM);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		
		//2.DELETE IWIPORDBOM
		CDB_delete_iwipordbom(1,&IWIPORDBOM);
		
        //3. BACKUP TABLE COPY
        CDB_init_ibakordbom(&IBAKORDBOM);
		memcpy(IBAKORDBOM.DOC_ID, IWIPORDBOM.DOC_ID, sizeof(struct IWIPORDBOM_TAG));        
		CDB_delete_ibakordbom(1, &IBAKORDBOM);
		CDB_insert_ibakordbom(&IBAKORDBOM);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		DB_commit();
	}
	return MP_TRUE;
}
