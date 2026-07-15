/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_multi_lot_list.c
	Description : View Lot List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Multi_Lot_List()
			+ View Lot List
		- CWIP_VIEW_MULTI_LOT_LIST()
			+ Main sub function of CWIP_View_Lot_List function
			+ View Lot List definition
		- CWIP_View_Multi_Lot_List_Validation()
			+ Main sub function of CWIP_VIEW_LOT_LIST function
			+ Check the condition for View Lot List
	Detail Description
		- CWIP_VIEW_MULTI_LOT_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2022/12/20  KBC           Created

	Copyright(C) 1998-2022 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Multi_Lot_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_SELECT_LOT_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node, char shift);
int CWIP_SELECT_TERMINTED_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Multi_Lot_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Multi_Lot_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_MULTI_LOT_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_MULTI_LOT_LIST", out_node);

	if (i_ret == MP_TRUE)
	{
		DB_commit();
	}
	else
	{
		DB_rollback();
	}

	return MP_TRUE;
}
/*******************************************************************************
	CWIP_VIEW_MULTI_LOT_LIST()
		- Main sub function of "CWIP_View_Lot_List" function
		- View Lot List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_MULTI_LOT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	char *temp_lot_id;
	char *temp_factory;
	TRSNode** lot_id_list;
	int inx, count;
    TRSNode *list_item;
	TRSNode* temp_node;
	
	struct worktime_tag tmp_work_time;

	char s_sys_time[14];
	char s_system_workdate[8];
	int i_system_workshift;
	char c_shift = ' ';

    LOG_head("CWIP_VIEW_MULTI_LOT_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	temp_node = TRS.add_node( in_node, "temp_node");
	TRS.add_string( temp_node, "LOT_ID", "", strlen(""));
	TRS.add_string( temp_node, "FACTORY", "", sizeof(""));
	lot_id_list = TRS.get_list(in_node, "LOT_ID_LIST");
	count = TRS.get_item_count( in_node, "LOT_ID_LIST");

	memset(s_system_workdate, ' ', sizeof(s_system_workdate));
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

	c_shift = CCOM_get_work_shift(s_sys_time);

	for ( inx = 0; inx < count; inx++ ) 
	{	
		temp_lot_id = TRS.get_string( lot_id_list[inx], "LOT_ID");
		temp_factory = TRS.get_string( lot_id_list[inx], "FACTORY");
		TRS.set_string( temp_node, "LOT_ID", temp_lot_id, strlen(temp_lot_id));
		TRS.set_string( temp_node, "FACTORY", temp_factory, strlen(temp_factory));
		list_item = TRS.add_node(out_node, "LIST");
		if ( CWIP_SELECT_LOT_STATUS( s_msg_code, temp_node, list_item, c_shift ) == MP_FALSE ) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(temp_lot_id), temp_lot_id);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}
		//폐기가능성 있으므로 리턴값을 통해서 확인하지 않고 내부에서 없는 해당 값을 null처리하는 형태로 진행 
		CWIP_SELECT_TERMINTED_LOT( s_msg_code, temp_node, list_item );
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

/*******************************************************************************
	CWIP_SELECT_LOT_STATUS()
		- Main sub function of "CWIP_View_Lot_List" function
		- View Lot List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_SELECT_LOT_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node, char shift)
{
	char msg[1024+1];
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct CWIPLOTEXT_TAG CWIPLOTEXT;

	/* - [GERP PROJECT] [ERP 23.05.23] 시작****************************************************************/
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPRWKDAT_TAG CWIPRWKDAT;
	/* - [GERP PROJECT] 끝*****************************************************************/

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, "FACTORY");
	memcpy(MWIPLOTSTS.OPER, "M4000", strlen("M4000"));
	memcpy(MWIPLOTSTS.CREATE_CODE, "MODULE", strlen("MODULE"));

	memset(msg, 0, sizeof(msg));

	DBC_select_mwiplotsts(1, &MWIPLOTSTS);

    if(DB_error_code != DB_SUCCESS)
    {
	    if(DB_error_code == DB_NOT_FOUND)
        {
			TRS.add_string(out_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(out_node, "REMARK", "The Module ID does not exist." , strlen("The Module ID does not exist."));
			return MP_TRUE;
		}
		return MP_FALSE;
    }

	TRS.add_string(out_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    TRS.add_string(out_node, "LOT_DESC", MWIPLOTSTS.LOT_DESC, sizeof(MWIPLOTSTS.LOT_DESC));
    TRS.add_string(out_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    TRS.add_int(out_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
    TRS.add_string(out_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
    TRS.add_int(out_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
    TRS.add_string(out_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
    TRS.add_double(out_node, "QTY_1", MWIPLOTSTS.QTY_1);
    TRS.add_double(out_node, "QTY_2", MWIPLOTSTS.QTY_2);
    TRS.add_double(out_node, "QTY_3", MWIPLOTSTS.QTY_3);
    TRS.add_char(out_node, "LOT_TYPE", MWIPLOTSTS.LOT_TYPE);
    TRS.add_string(out_node, "CREATE_TIME", MWIPLOTSTS.CREATE_TIME, sizeof(MWIPLOTSTS.CREATE_TIME));
    TRS.add_string(out_node, "OWNER_CODE", MWIPLOTSTS.OWNER_CODE, sizeof(MWIPLOTSTS.OWNER_CODE));
    TRS.add_string(out_node, "CREATE_CODE", MWIPLOTSTS.CREATE_CODE, sizeof(MWIPLOTSTS.CREATE_CODE));
    TRS.add_char(out_node, "LOT_PRIORITY", MWIPLOTSTS.LOT_PRIORITY);
    TRS.add_string(out_node, "LOT_STATUS", MWIPLOTSTS.LOT_STATUS, sizeof(MWIPLOTSTS.LOT_STATUS));
    TRS.add_char(out_node, "HOLD_FLAG", MWIPLOTSTS.HOLD_FLAG);
    TRS.add_string(out_node, "HOLD_CODE", MWIPLOTSTS.HOLD_CODE, sizeof(MWIPLOTSTS.HOLD_CODE));
    TRS.add_string(out_node, "HOLD_PRV_GRP_ID", MWIPLOTSTS.HOLD_PRV_GRP_ID, sizeof(MWIPLOTSTS.HOLD_PRV_GRP_ID));
    TRS.add_string(out_node, "ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
    TRS.add_string(out_node, "LOT_CMF_1", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
    TRS.add_string(out_node, "LOT_CMF_2", MWIPLOTSTS.LOT_CMF_2, sizeof(MWIPLOTSTS.LOT_CMF_2));
    TRS.add_string(out_node, "LOT_CMF_3", MWIPLOTSTS.LOT_CMF_3, sizeof(MWIPLOTSTS.LOT_CMF_3));
    TRS.add_string(out_node, "LOT_CMF_4", MWIPLOTSTS.LOT_CMF_4, sizeof(MWIPLOTSTS.LOT_CMF_4));
    TRS.add_string(out_node, "LOT_CMF_5", MWIPLOTSTS.LOT_CMF_5, sizeof(MWIPLOTSTS.LOT_CMF_5));
    TRS.add_string(out_node, "LOT_CMF_6", MWIPLOTSTS.LOT_CMF_6, sizeof(MWIPLOTSTS.LOT_CMF_6));
    TRS.add_string(out_node, "LOT_CMF_7", MWIPLOTSTS.LOT_CMF_7, sizeof(MWIPLOTSTS.LOT_CMF_7));
    TRS.add_string(out_node, "LOT_CMF_8", MWIPLOTSTS.LOT_CMF_8, sizeof(MWIPLOTSTS.LOT_CMF_8));
    TRS.add_string(out_node, "LOT_CMF_9", MWIPLOTSTS.LOT_CMF_9, sizeof(MWIPLOTSTS.LOT_CMF_9));
    TRS.add_string(out_node, "LOT_CMF_10", MWIPLOTSTS.LOT_CMF_10, sizeof(MWIPLOTSTS.LOT_CMF_10));
    TRS.add_string(out_node, "LOT_CMF_11", MWIPLOTSTS.LOT_CMF_11, sizeof(MWIPLOTSTS.LOT_CMF_11));
    TRS.add_string(out_node, "LOT_CMF_12", MWIPLOTSTS.LOT_CMF_12, sizeof(MWIPLOTSTS.LOT_CMF_12));
    TRS.add_string(out_node, "LOT_CMF_13", MWIPLOTSTS.LOT_CMF_13, sizeof(MWIPLOTSTS.LOT_CMF_13));
    TRS.add_string(out_node, "LOT_CMF_14", MWIPLOTSTS.LOT_CMF_14, sizeof(MWIPLOTSTS.LOT_CMF_14));
    TRS.add_string(out_node, "LOT_CMF_15", MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
    TRS.add_string(out_node, "LOT_CMF_16", MWIPLOTSTS.LOT_CMF_16, sizeof(MWIPLOTSTS.LOT_CMF_16));
    TRS.add_string(out_node, "LOT_CMF_17", MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17));
    TRS.add_string(out_node, "LOT_CMF_18", MWIPLOTSTS.LOT_CMF_18, sizeof(MWIPLOTSTS.LOT_CMF_18));
    TRS.add_string(out_node, "LOT_CMF_19", MWIPLOTSTS.LOT_CMF_19, sizeof(MWIPLOTSTS.LOT_CMF_19));
    TRS.add_string(out_node, "LOT_CMF_20", MWIPLOTSTS.LOT_CMF_20, sizeof(MWIPLOTSTS.LOT_CMF_20));
    TRS.add_char(out_node, "LOT_DEL_FLAG", MWIPLOTSTS.LOT_DEL_FLAG);
    TRS.add_string(out_node, "LOT_DEL_CODE", MWIPLOTSTS.LOT_DEL_CODE, sizeof(MWIPLOTSTS.LOT_DEL_CODE));
    TRS.add_string(out_node, "LOT_DEL_TIME", MWIPLOTSTS.LOT_DEL_TIME, sizeof(MWIPLOTSTS.LOT_DEL_TIME));
    TRS.add_string(out_node, "LAST_TRAN_CODE", MWIPLOTSTS.LAST_TRAN_CODE, sizeof(MWIPLOTSTS.LAST_TRAN_CODE));
    TRS.add_string(out_node, "LAST_TRAN_TIME", MWIPLOTSTS.LAST_TRAN_TIME, sizeof(MWIPLOTSTS.LAST_TRAN_TIME));
    TRS.add_string(out_node, "LAST_COMMENT", MWIPLOTSTS.LAST_COMMENT, sizeof(MWIPLOTSTS.LAST_COMMENT));
    TRS.add_int(out_node, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
    TRS.add_int(out_node, "LAST_HIST_SEQ", MWIPLOTSTS.LAST_HIST_SEQ);

	CDB_init_cedclotfqc(&CEDCLOTFQC);
	memcpy(CEDCLOTFQC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

	CDB_select_cedclotfqc(5, &CEDCLOTFQC);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			TRS.add_string(out_node, "FQC_FLAG", "N", strlen("N"));
		}
		else
		{
			TRS.add_dberrmsg(out_node,DB_error_msg);
		}
	}
	else
	{
		TRS.add_string(out_node, "FQC_FLAG", "Y", strlen("Y"));
		TRS.add_string(out_node, "GRADE", CEDCLOTFQC.GRADE, sizeof(CEDCLOTFQC.GRADE));
		TRS.add_string(out_node, "INS_TIME", CEDCLOTFQC.INS_TIME, sizeof(CEDCLOTFQC.INS_TIME));
		TRS.add_string(out_node, "LIMIT_DATE", CEDCLOTFQC.CMF_8, sizeof(CEDCLOTFQC.CMF_8));
		TRS.add_string(out_node, "TODATE", CEDCLOTFQC.CMF_9, sizeof(CEDCLOTFQC.CMF_9));
		TRS.add_string(out_node, "SAME_FLAG", CEDCLOTFQC.CMF_10, strlen("Y"));
	}
	
	CDB_init_cwiplotext(&CWIPLOTEXT);
	memcpy(CWIPLOTEXT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_cwiplotext(1, &CWIPLOTEXT );
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "TERMINATE_SHIFT", CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1));
		TRS.add_string(out_node, "TERMINATE_PROCESS_CODE", CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2));
		TRS.add_string(out_node, "TERMINATE_EQ_CODE", CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3));
	}
	else
	{
		TRS.add_char(out_node, "TERMINATE_SHIFT", shift);
	}

	CDB_init_cwiplotext(&CWIPLOTEXT);
	memcpy(CWIPLOTEXT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_cwiplotext(1, &CWIPLOTEXT );
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.add_string(out_node, "TERMINATE_SHIFT", CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1));
		TRS.add_string(out_node, "TERMINATE_PROCESS_CODE", CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2));
		TRS.add_string(out_node, "TERMINATE_EQ_CODE", CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3));
	}
	else
	{
		TRS.add_char(out_node, "TERMINATE_SHIFT", shift);
	}

	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);
	
	if(DB_error_code != DB_SUCCESS)
	{
//		TRS.add_string(out_node, "REMARK", "Only G06 grade modules can be terminated on this page." , sizeof("Only G06 grade modules can be terminated on this page."));
		sprintf(msg, "%s", "Only G06 grade modules can be terminated on this page.\r\n");
		if(DB_error_code != DB_NOT_FOUND)
		{
			TRS.add_dberrmsg(out_node,DB_error_msg);
		}
	}
	else
	{
		if ( strncmp(MWIPELTSTS.GRADE , "G06", strlen("G06") ) != 0 ) 
		{
			//TRS.add_string(out_node, "REMARK", "Only G06 grade modules can be terminated on this page." , sizeof("Only G06 grade modules can be terminated on this page."));
			sprintf(msg, "%s", "Only G06 grade modules can be terminated on this page.\r\n");
		}
	}

	
	if ( strncmp(MWIPLOTSTS.CREATE_CODE , "MODULE", strlen("MODULE") ) != 0 ) 
	{
//		TRS.add_string(out_node, "REMARK", "The Module ID does not exist." , sizeof("The Module ID does not exist."));
		sprintf(msg, "%s%s",msg, "The Module ID does not exist.\r\n");
	}
	
//	if ( strncmp(MWIPLOTSTS.OPER , "M4000", strlen("M4000") ) == 0 ) 
//	{
//		//TRS.add_string(out_node, "REMARK", "The module cannot be terminated: the modules is in packing." , sizeof("The module cannot be terminated: the modules is in packing."));
//		sprintf(msg, "%s%s", msg, "The module cannot be terminated: the modules is in packing.\r\n");
//	}

	/* - [GERP PROJECT] [ERP 23.05.23] 시작****************************************************************/
	/*REMARK 추가*/
	// 23.05.03 패킹이력이 있을경우 폐기 Validation
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
	memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

	if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
	{		
		CDB_select_cwiplotpak(1, &CWIPLOTPAK);
		if(DB_error_code == DB_SUCCESS)
		{
			if ( CWIPLOTPAK.STATUS_FLAG == 'C') 
			{
				sprintf(msg, "%s%s", msg, "Packed module: requires to unpack the module and to have a rework order.\r\n");
			} else if (CWIPLOTPAK.STATUS_FLAG == 'D' ) 
			{
				// 23.05.03 패킹이력이 있지만 재작업 오더가 있을떈 폐기 가능
				CDB_init_cwiprwkdat(&CWIPRWKDAT);
				memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CWIPRWKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
				if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) == 0) // 재작업 오더 없음
				{
					sprintf(msg, "%s%s", msg, "Unpacked module: requires a rework order.\r\n");
				}
			}
		}
	}
	/* - [GERP PROJECT] 끝*****************************************************************/

	TRS.add_string(out_node, "REMARK", msg, sizeof(msg));

	return MP_TRUE;
}

/*******************************************************************************
	CWIP_SELECT_TERMINTED_LOT()
		- View terminated Lot List
	Return Value
		- void
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_SELECT_TERMINTED_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node) 
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MWIPLOTHIS_TAG MWIPLOTHIS;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    struct MGCMTBLDAT_TAG MGCMTBLDAT_C;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_PROCESS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_EQ;
	struct CWIPLOTEXT_TAG CWIPLOTEXT;

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, "FACTORY");

	DBC_open_mwiplotsts(106, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_1), MWIPLOTSTS.LOT_CMF_1);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mwiplotsts(106, &MWIPLOTSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwiplotsts(106);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_1), MWIPLOTSTS.LOT_CMF_1);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwiplotsts(106);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}

    DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, MP_WIP_TERMINATE_CODE, strlen(MP_WIP_TERMINATE_CODE));
    memcpy(MGCMTBLDAT.KEY_1, MWIPLOTSTS.LOT_DEL_CODE, sizeof(MWIPLOTSTS.LOT_DEL_CODE));

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT); 

    DBC_init_mwiplothis(&MWIPLOTHIS);
    memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
            
    DBC_select_mwiplothis(1, &MWIPLOTHIS); 

    DBC_init_mgcmtbldat(&MGCMTBLDAT_C);
    TRS.copy(MGCMTBLDAT_C.FACTORY, sizeof(MGCMTBLDAT_C.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT_C.TABLE_NAME, HQCEL_M1_GCM_TERMINATE_CAUSE, strlen(HQCEL_M1_GCM_TERMINATE_CAUSE));
    memcpy(MGCMTBLDAT_C.KEY_1, MWIPLOTHIS.TRAN_CMF_1, sizeof(MWIPLOTHIS.TRAN_CMF_1));

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT_C); 

			
	// IS-21-05-028 Terminate Module Shift 추가건 개발
	CDB_init_cwiplotext(&CWIPLOTEXT);
	memcpy(CWIPLOTEXT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

	CDB_select_cwiplotext(2, &CWIPLOTEXT); 

	// IS-21-04-017 Terminate Module
	// TERMINATE_PROCESS
	DBC_init_mgcmtbldat(&MGCMTBLDAT_PROCESS);
    TRS.copy(MGCMTBLDAT_PROCESS.FACTORY, sizeof(MGCMTBLDAT_PROCESS.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT_PROCESS.TABLE_NAME, "TERMINATE_PROCESS", strlen("TERMINATE_PROCESS"));
	memcpy(MGCMTBLDAT_PROCESS.KEY_1, CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2)); // IS-21-05-028 Terminate Module Shift Ãß°¡°Ç °³¹ß

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT_PROCESS); 
	// IS-21-04-017 Terminate Module
	// TERMINATE_EQ
	DBC_init_mgcmtbldat(&MGCMTBLDAT_EQ);
    TRS.copy(MGCMTBLDAT_EQ.FACTORY, sizeof(MGCMTBLDAT_EQ.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT_EQ.TABLE_NAME, "TERMINATE_EQ", strlen("TERMINATE_EQ"));
	memcpy(MGCMTBLDAT_EQ.KEY_1, CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3)); // IS-21-05-028 Terminate Module Shift Ãß°¡°Ç °³¹ß

	DBC_select_mgcmtbldat(2, &MGCMTBLDAT_EQ); 

	TRS.add_string(out_node, "LOT_DEL_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    TRS.add_string(out_node, "LOT_DEL_CAUSE", MGCMTBLDAT_C.DATA_1, sizeof(MGCMTBLDAT_C.DATA_1));
	TRS.add_string(out_node, "TRAN_CMF_20", MWIPLOTHIS.TRAN_CMF_20, sizeof(MWIPLOTHIS.TRAN_CMF_20));

	// IS-21-05-028 Terminate Module Shift 추가건 개발
	TRS.add_string(out_node, "TERMINATE_SHIFT", CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1));
	TRS.add_string(out_node, "TERMINATE_PROCESS", MGCMTBLDAT_PROCESS.DATA_1, sizeof(MGCMTBLDAT_PROCESS.DATA_1));
	TRS.add_string(out_node, "TERMINATE_PROCESS_CODE", CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2));
	TRS.add_string(out_node, "TERMINATE_EQ", MGCMTBLDAT_EQ.DATA_1, sizeof(MGCMTBLDAT_EQ.DATA_1));
	TRS.add_string(out_node, "TERMINATE_EQ_CODE", CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3));
	TRS.add_string(out_node, "TERMINATE_TIME", CWIPLOTEXT.CREATE_TIME, sizeof(CWIPLOTEXT.CREATE_TIME));
	TRS.add_string(out_node, "TRAN_CMF_16", MWIPLOTHIS.TRAN_CMF_16, sizeof(MWIPLOTHIS.TRAN_CMF_16)); // //IS-21-04-017 Terminate Module
	TRS.add_string(out_node, "SYS_TRAN_TIME", MWIPLOTHIS.SYS_TRAN_TIME, sizeof(MWIPLOTHIS.SYS_TRAN_TIME)); // //IS-21-04-017 Terminate Module

	return MP_TRUE;
}

 
/*******************************************************************************
	CWIP_View_Multi_Lot_List_Validation()
		- Main sub function of "CWIP_VIEW_LOT_LIST" function
		- Check the condition for View Lot List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Multi_Lot_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }


    return MP_TRUE;
}