/*******************************************************************************

    System      : MESplus
    Module      : Layup End Lot 
    File Name   : CWIP_tran_layup_end.c
    Description : LAYUP OPERATION END ( CREATE / COMBINE / END )
				  
    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.22  JUHYEON.JUING  CREATE
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"

int CWIP_TRIMMING_END_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Move_HalfCell_Cart()
        - SOI->MES Move HalfCell Cart
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Trimming_End_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_TRIMMING_END_LOT(s_msg_code, in_node, out_node);

    //COM_out_msg_log_write(s_msg_code, "CWIP_layup_end_lot", out_node);

	// 20210810 MES Application Memory leak 점검 및 수정
	// log edit
	COM_out_msg_log_write(s_msg_code, "CWIP_Trimming_End_Lot", out_node);

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
    CWIP_TRIMMING_END_LOT()
        - SOI->MES Move HalfCell Cart
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_TRIMMING_END_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_STR;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;

	struct CWIPLOTSTR_TAG CWIPLOTSTR;

	char s_sys_time[14];
	char c_combine_flag = 'N';
	char c_split_flag  = 'N';
	char s_to_lot_number[25];
	char s_from_lot_number[25];
	char s_due_time[14];

	int i_combine_count = 0;
	int i_string_count = 12;

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CWIP_TRIMMING_END_LOT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_from_lot_number, ' ', sizeof(s_from_lot_number));
	memset(s_to_lot_number, ' ', sizeof(s_to_lot_number));

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

	if (COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "WIP-0600");
        TRS.set_fieldmsg(out_node, "LINE NUMBER WRONG", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//현재 LINE 의 작업지시  GET
	/* Get current order by line ID */
    DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
    TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code != DB_SUCCESS)
    {
       strcpy(s_msg_code, "WIP-0601");
		TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
        TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Get order information */
    DBC_init_mwipordsts(&MWIPORDSTS);
    TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID));

    DBC_select_mwipordsts(1, &MWIPORDSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "ORD-0002");
        TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Get material information */
    DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPMATDEF.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
    MWIPMATDEF.MAT_VER = 1;

    DBC_select_mwipmatdef(1, &MWIPMATDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0006");
        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//실제 MODULE ID 
	if (COM_isnullspace(TRS.get_string(in_node, "T_MODULE_ID")) == MP_TRUE)
	{
		strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "TO MODULE ID  ERROR", MP_NVST);
      
		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	else
	{
		TRS.copy(s_from_lot_number, sizeof(s_from_lot_number), in_node, "F_MODULE_ID");
		TRS.copy(s_to_lot_number, sizeof(s_to_lot_number), in_node, "T_MODULE_ID");
	}

	//실제 MODULE ID ( T_MODULE_ID) 와 가상 MODULE ID ( F_MODULE_ID ) 가 틀리면 전량 SPLIT
	c_split_flag = 'N';
	if ((memcmp(s_from_lot_number, s_to_lot_number, sizeof(s_from_lot_number)) != 0) &&
		(COM_isspace(s_from_lot_number, sizeof(s_from_lot_number)) == MP_FALSE))
	{
		c_split_flag = 'Y';
	}
	else 
	{
		memcpy(s_from_lot_number, s_to_lot_number, sizeof(s_from_lot_number));
	}

	//LOT SELECT
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.LOT_ID, s_from_lot_number, sizeof(s_from_lot_number));
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "FROM MODULE ID  ERROR", MP_NVST);
      
		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	
	tran_in_node = TRS.create_node("TRAN_LOT_IN");
	tran_out_node = TRS.create_node("TRAN_LOT_OUT");

	//전량 SPLIT
	if ( c_split_flag == 'Y')
	{
		
		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');

		//FROM->TO 로 전량 SPLIT
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

		TRS.add_int(tran_in_node, "MAT_VER", 1);
		TRS.add_int(tran_in_node, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

		TRS.add_int(tran_in_node, "MOVE_QTY_1", (int)MWIPLOTSTS.QTY_1);
	
		TRS.add_string(tran_in_node, "CHILD_LOT_ID", s_to_lot_number, sizeof(s_to_lot_number));
		TRS.add_string(tran_in_node, "CHILD_MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "CHILD_MAT_VER", 1);
		TRS.add_string(tran_in_node, "CHILD_CREATE_CODE", MWIPLOTSTS.CREATE_CODE, sizeof(MWIPLOTSTS.CREATE_CODE));
		TRS.add_string(tran_in_node, "CHILD_OWNER_CODE", MWIPLOTSTS.OWNER_CODE, sizeof(MWIPLOTSTS.OWNER_CODE));
		TRS.add_char(tran_in_node, "CHILD_LOT_TYPE", MWIPLOTSTS.LOT_TYPE);   
		TRS.add_char(tran_in_node, "CHILD_PRIORITY", MWIPLOTSTS.LOT_PRIORITY);
		TRS.add_string(tran_in_node, "ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		
		memset(s_due_time, ' ' , sizeof(s_due_time));
		COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

		TRS.add_string(tran_in_node, "DUE_TIME",s_due_time, sizeof(s_due_time));

		if(WIP_SPLIT_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		//LOT SELECT (FROM -> TO )
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.LOT_ID, s_to_lot_number, sizeof(s_to_lot_number));
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0044");
			TRS.add_fieldmsg(out_node, "FROM MODULE ID  ERROR", MP_NVST);
      
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}
	}
	
	/****************************************************************************/
	// 1. STRING 을 가지고 와서 Combine 시킴 ( 12개 사용 )
	//  2. 설비에서 올라온 데이터가 있을수 잇으므로 해당 데이터는 제외하고 COMBINE
	/****************************************************************************/
	// 해당 line 에서 투입된 기준으로 선입선출 해서 가져옮.
	// 설비에서 STRING ID 를 올려줄경우 해당 LOT 으로 진행
	// LOT_DESC 에 TIME_STAMP 값 같이 가져옮.
	/****************************************************************************/
	CDB_init_cwiplotstr(&CWIPLOTSTR);
	memcpy(CWIPLOTSTR.FACTORY, MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY));
	memcpy(CWIPLOTSTR.LOT_ID, s_from_lot_number, sizeof(MWIPLOTSTS.LOT_ID));
	i_combine_count = i_string_count - (int)CDB_select_cwiplotstr_scalar(2, &CWIPLOTSTR);
		
	while(i_combine_count > 0)
	{
		c_combine_flag = 'Y';
		CDB_init_mwiplotsts(&MWIPLOTSTS_STR);
		memcpy(MWIPLOTSTS_STR.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		memcpy(MWIPLOTSTS_STR.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER));
		memcpy(MWIPLOTSTS_STR.MAT_ID, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		memcpy(MWIPLOTSTS_STR.LOT_CMF_1, MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1)); //LINE NUMBER
		MWIPLOTSTS_STR.END_FLAG = 'Y';
		
		CDB_select_mwiplotsts(6, &MWIPLOTSTS_STR);
		if(DB_error_code != DB_SUCCESS)
		{
			c_combine_flag = 'N';
		}

		if ( c_combine_flag == 'Y')
		{
			//COMBINE 수행
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS_STR.LOT_ID, sizeof(MWIPLOTSTS_STR.LOT_ID));
			
			TRS.add_string(tran_in_node, "INTO_LOT_ID", s_to_lot_number, sizeof(s_to_lot_number));

			//STRING 1개만 Combine
			TRS.add_double(tran_in_node, "MOVE_QTY_1", 1);

			if(WIP_COMBINE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}
		}

		i_combine_count--;
	}

	//LOT RE SELECT
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	/***************************************************/
	//END LOT
	/***************************************************/
	TRS.init_node(tran_in_node);
	TRS.init_node(tran_out_node);

	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');
	TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
	{
		//설비ID 가 없을경우 처리 -> CORE 에러 처리.
		
	}
	if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		return MP_FALSE;
	}
	
	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);


	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}