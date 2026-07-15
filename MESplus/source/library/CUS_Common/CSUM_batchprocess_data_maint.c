
/********************************************************************************

System      : MESplus
Module      : CSUM(CUSTOM SUMMARY)
File Name   : CSUM_BatchProcess_Data_Maint.c
Description : MAIN BATCH PROCESS

MES Version : 5.3.x

Function List

Detail Description
// DATA 정리가 필요한 테이블 데이터 정리 프로세스

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2018/11/27  Juhyeon.Jung       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <MESCore_common.h>
#include "ACTCore_common.h"


int CSUM_BATCHPROCESS_DATA_MAINT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CSUM_BATCHPROCESS_DATA_MAINT_PRCDAT_COPY_TMP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
CSUM_BatchProcess_Event()
- End Lot
Return Value
- int : 0 (MP_TRUE)
Arguments
- TRSNode *in_node  : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BatchProcess_Data_Maint(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	if(CUS_COM_BATCHPROCESS_STATUS_UPDATE('S', in_node, out_node) == MP_FALSE)
		return MP_TRUE;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	if (TRS.get_procstep(in_node) == 'T')
		i_ret =  CSUM_BATCHPROCESS_DATA_MAINT_PRCDAT_COPY_TMP(s_msg_code, in_node, out_node);
	else
		i_ret = CSUM_BATCHPROCESS_DATA_MAINT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CSUM_BATCHPROCESS_TRANSACTION", out_node);

	if(i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	CUS_COM_BATCHPROCESS_STATUS_UPDATE('E', in_node, out_node);

	return MP_TRUE;
}
/*******************************************************************************
CSUM_BATCHPROCESS_TRANSACTION()
- Main sub function of "CSUM_BatchProcess_Transaction" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_DATA_MAINT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CEISMSGLOG_TAG CEISMSGLOG;
	struct IERPOPRCFM_TAG IERPOPRCFM;
	struct IBAKOPRCFM_TAG IBAKOPRCFM;
	struct IERPCLVCFM_TAG IERPCLVCFM;
	struct IERPHCLMOV_TAG IERPHCLMOV; //
	struct IERPFCLMOV_TAG IERPFCLMOV; //
	struct IERPPAKDAT_TAG IERPPAKDAT; //
	struct IBAKCLVCFM_TAG IBAKCLVCFM;
	struct IBAKFCLMOV_TAG IBAKFCLMOV;//ISSUE-07-045
	struct IBAKHCLMOV_TAG IBAKHCLMOV;
	struct IBAKPAKDAT_TAG IBAKPAKDAT;

	char s_sys_time[14];
	
    LOG_head("CSUM_BATCHPROCESS_DATA_MAINT");
	TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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

	//DEFAULT FACTORY
	if (COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
	{
		TRS.set_nstring(in_node, IN_FACTORY, HQCEL_M1_DEFAULT_FACTORY);
	}

	/*********************************************************/
	//1. CEISMSGLOG TABLE -6 DAY DATA CLEAR
	/*********************************************************/
	CDB_init_ceismsglog(&CEISMSGLOG);

	CDB_delete_ceismsglog(2, &CEISMSGLOG);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	/*********************************************************/
	//2. IERPOPRCFMDAT  ERP_FLAG = 'S'
	//2.1 BACKUP TABLE DATA DELETE
	//2.2 BACKUP TABLE COPY 
	//2.3 MAIN TABLE DELETE
	/*********************************************************/
	CDB_init_ibakoprcfm(&IBAKOPRCFM);
	CDB_delete_ibakoprcfm(2, &IBAKOPRCFM);  //IERPOPRCFM 의 'S' 인것 IBAKOPRCFM 에서 삭제.
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_update_ibakoprcfm(2, &IBAKOPRCFM);  //IERPOPRCFM 에-> IBAKOPRCFM INSERT
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_init_ierpoprcfm(&IERPOPRCFM);
	CDB_delete_ierpoprcfm(2, &IERPOPRCFM);  //IOPRCFM TABLE 삭제
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	/*********************************************************/
	//3. IERPCLVCFM  ERP_FLAG = 'S'
	//3.1 BACKUP TABLE COPY 
	//3.2 MAIN TABLE DELETE
	/*********************************************************/
	CDB_init_ibakclvcfm(&IBAKCLVCFM);
	CDB_delete_ibakclvcfm(2, &IBAKCLVCFM);  //IERPCLVCFM 의 'S' 인것 IBAKCLVCFM 에서 삭제.
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_update_ibakclvcfm(2, &IBAKCLVCFM);  //IERPCLVCFM 에-> IBAKCLVCFM INSERT
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_init_ierpclvcfm(&IERPCLVCFM);
	CDB_delete_ierpclvcfm(2, &IERPCLVCFM);  //IERPCLVCFM TABLE 삭제
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	/*********************************************************/
	//4. IERPHCLMOV  ERP_FLAG = 'S'
	//4.1 BACKUP TABLE COPY 
	//4.2 MAIN TABLE DELETE
	/*********************************************************/
	CDB_init_ierphclmov(&IERPHCLMOV);
	CDB_delete_ibakhclmov(2, &IBAKHCLMOV);  //IERPHCLMOV 의 'S' 인것 IBAKHCLMOV 에서 삭제.
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_update_ibakhclmov(2, &IBAKHCLMOV);  //IERPHCLMOV 에-> IBAKHCLMOV INSERT
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_init_ierphclmov(&IERPHCLMOV);
	CDB_delete_ierphclmov(2, &IERPHCLMOV);  //IERPHCLMOV TABLE 삭제
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	/*********************************************************/
	//5. IERPFCLMOV  ERP_FLAG = 'S'
	//5.1 BACKUP TABLE COPY 
	//5.2 MAIN TABLE DELETE
	/*********************************************************/
	CDB_init_ierpfclmov(&IERPFCLMOV);
	CDB_delete_ibakfclmov(2, &IBAKFCLMOV);  //IERPFCLMOV 의 'S' 인것 IBAKFCLMOV 에서 삭제.
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_update_ibakfclmov(2, &IBAKFCLMOV);  //IERPFCLMOV 에-> IBAKFCLMOV INSERT
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_init_ierpfclmov(&IERPFCLMOV);
	CDB_delete_ierpfclmov(2, &IERPFCLMOV);  //IERPFCLMOV TABLE 삭제
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	/*********************************************************/
	//6. IERPPAKDAT  ERP_FLAG = 'S'
	//6.1 BACKUP TABLE COPY 
	//6.2 MAIN TABLE DELETE
	/*********************************************************/
	CDB_init_ierppakdat(&IERPPAKDAT);
	CDB_delete_ibakpakdat(2, &IBAKPAKDAT);  //IERPPAKDAT 의 'S' 인것 IBAKPAKDAT 에서 삭제.
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_update_ibakpakdat(2, &IBAKPAKDAT);  //IERPPAKDAT 에-> IBAKPAKDAT INSERT
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	CDB_init_ierppakdat(&IERPPAKDAT);
	CDB_delete_ierppakdat(2, &IERPPAKDAT);  //IERPPAKDAT TABLE 삭제
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
CSUM_BATCHPROCESS_DATA_MAINT_PRCDAT_COPY_TMP()
- Main sub function of "CSUM_BatchProcess_Transaction" function
Return Value
- int : 1 (MP_TRUE) / 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code 
- TRSNode *in_node : Input Message structure
- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CSUM_BATCHPROCESS_DATA_MAINT_PRCDAT_COPY_TMP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CRASPRCDAT_TAG CRASPRCDAT;
	

    while(1)
	{
		CDB_init_crasprcdat(&CRASPRCDAT);
		CDB_select_crasprcdat_for_update(901, &CRASPRCDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			break;
		}
		CDB_insert_crasprcdat(&CRASPRCDAT);
		CDB_delete_crasprcdat(901, &CRASPRCDAT);
		DB_commit();
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}
