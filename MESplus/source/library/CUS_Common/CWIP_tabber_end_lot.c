/*******************************************************************************

    System      : MESplus
    Module      : Tabber End Lot 
    File Name   : CWIP_Tabber_end.c
    Description : TABER OPERATION END ( CREATE / COMBINE / END )
				  
    MES Version : 5.0

    Function List
        - START :  CELL BOX (HALFCELL MAGAZINE ) START + DETACH CAARRIER: EQUIPMENT 
		  END   : 1) CREATE LOT (STRING )
		          2) COMBINE LOT ( HALFCELL MAGAZINE -> STRING )
		          3) END LOT ( STRING) - FULL OPERATION 
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.01.05  JUHYEON.JUING  CREATE
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"

int CWIP_TABBER_END_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_tabber_end_lot()
        - Tabber End Lot Service
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Tabber_End_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_TABBER_END_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_tabber_end_lot", out_node);

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
    CWIP_TABBER_END_LOT()
        - TABBER OPERATION END LOT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_TABBER_END_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_CELL;  //START 중인 CELL LOT ( HALFCELL START LOT )
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	
	struct CWIPORDBOM_TAG CWIPORDBOM;
	struct MWIPCRRLOT_TAG MWIPCRRLOT;

	char s_sys_time[14];
	char c_combine_flag = 'N';
	char s_string_lot_number[25];
	
	char s_due_time[14];

	char c_string_create_flag = 'N';

	int i_combine_qty ;

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CWIP_TABBER_END_LOT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_string_lot_number, ' ', sizeof(s_string_lot_number)); // 가상Lot 에러로 초기화

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
        strcpy(s_msg_code, "GCM-0008");
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

    /* Get material(PRODUCT) information */
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

	//BOM 에서 HALF CELL 품번 가져옮. (먼저가져와서 사용, ERROR 처리를 위해 가져와서 사용권장..)
	CDB_init_cwipordbom(&CWIPORDBOM);
	memcpy(CWIPORDBOM.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
	memcpy(CWIPORDBOM.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
	memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
	CDB_select_cwipordbom(4, &CWIPORDBOM);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0561");
		TRS.set_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}


	//cell->string combine 수량 get ( 임시로 12개 사용)
	i_combine_qty = 12;
	c_combine_flag = 'Y';

	/****************************************************************************/
	// 1. CELL BOX (HALFCELL MAGAZINE 으로 현재장비에서 START 된 LOT 중 선입선출로 Combine 시킴 
	/****************************************************************************/
	// 해당 line 에서 투입된 기준으로 선입선출 해서 가져옮.
	// 설비에서 STRING ID 를 올려줄경우 해당 LOT 으로 진행
	// LOT_DESC 에 TIME_STAMP 값 같이 가져옮.
	// COMBINE 수량 : CELL 수량 12EA ( 셋팅된 수량을 가지고옮)
	// 설비에서 HALFCELL 정보나 LAMA 정보 올려주면 최대한 해당 정보를 가지고 진행.
	/****************************************************************************/
	CDB_init_mwiplotsts(&MWIPLOTSTS_CELL);
	memcpy(MWIPLOTSTS_CELL.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
	memcpy(MWIPLOTSTS_CELL.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER));
	memcpy(MWIPLOTSTS_CELL.MAT_ID, CWIPORDBOM.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	
	TRS.copy(MWIPLOTSTS_CELL.START_RES_ID, sizeof(MWIPLOTSTS_CELL.START_RES_ID), in_node, "RES_ID");

	MWIPLOTSTS_CELL.START_FLAG = 'Y';

	//장비 - BOM기준 FULL  CELL 품번중 먼저 START 된놈
	//2019.10.03 : CASE 5->10 로 변경 : LOT_GROUP_ID_1 = ' ' 인것만.
	//CDB_select_mwiplotsts(5, &MWIPLOTSTS_CELL);
	CDB_select_mwiplotsts(10, &MWIPLOTSTS_CELL);
	if(DB_error_code != DB_SUCCESS)
	{
		//가져올LOT 이 없을경우 해당 공정에 있는 품번중 START 하지 않은 LOT 중 먼저들어온놈중에 하나를 가져옮.
		MWIPLOTSTS_CELL.START_FLAG = ' ';
		MWIPLOTSTS_CELL.END_FLAG = ' ';
		//2019.10.03 : CASE 4->12 로 변경 : LOT_GROUP_ID_1 = ' ' 인것만.
		//CDB_select_mwiplotsts(4, &MWIPLOTSTS_FCELL);
		CDB_select_mwiplotsts(12, &MWIPLOTSTS_CELL);
		if(DB_error_code != DB_SUCCESS)
		{	
			//COMBINE 하지 않고 강제로 진행 : 필요시 ERROR 처리.가상LotNUMBER (LOT NUMBER 입력없을시 사용)  는 현재시간 + 0000000 으로 맞춤
			c_combine_flag = 'N';
			memset(MWIPLOTSTS_CELL.LOT_DESC, '0', 21);
			memcpy(MWIPLOTSTS_CELL.LOT_DESC, s_sys_time, sizeof(s_sys_time));
		}
	}
	
	//STRING ID 
	if (COM_isnullspace(TRS.get_string(in_node, "STRING_ID")) == MP_TRUE)
	{
		memcpy(s_string_lot_number, MWIPLOTSTS_CELL.LOT_DESC, 21); //임시LOT 은 현재 TIMESTAMP 값을 가지고 사용.
	}
	else
	{
		TRS.copy(s_string_lot_number, sizeof(s_string_lot_number), in_node, "STRING_ID");
	}

	c_string_create_flag = 'N';
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.LOT_ID, s_string_lot_number, sizeof(s_string_lot_number));
	DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		//STRING 을 생성 
		c_string_create_flag = 'Y';
	}

	/****************************************************************************/
	// 2. STRING LOT CREATION (STRING ID)
	/****************************************************************************/
	tran_in_node = TRS.create_node("TRAN_LOT_IN");
	tran_out_node = TRS.create_node("TRAN_LOT_OUT");

	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');

	//LOT_ID 는 STRING ID 로 생성.
	TRS.add_string(tran_in_node, "LOT_ID", s_string_lot_number, sizeof(s_string_lot_number));
	TRS.add_string(tran_in_node, "MAT_ID", MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
	TRS.add_int(tran_in_node, "MAT_VER", 1);
	TRS.add_string(tran_in_node, "FLOW", MWIPMATDEF.FIRST_FLOW, sizeof(MWIPMATDEF.FIRST_FLOW));
	TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", 1); 
	TRS.add_string(tran_in_node, "OPER", HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER));
	TRS.add_char(tran_in_node, "LOT_TYPE", 'P');   
	TRS.add_string(tran_in_node, "CREATE_CODE", HQCEL_LOT_CREATECODE_STRING, strlen(HQCEL_LOT_CREATECODE_STRING));
	TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
	TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
	TRS.add_double(tran_in_node, "QTY_1", 1);   
	TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		
	memset(s_due_time, ' ' , sizeof(s_due_time));
	COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

	TRS.add_string(tran_in_node, "DUE_TIME",s_due_time, sizeof(s_due_time));
	TRS.add_string(tran_in_node, "LOT_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
	
	TRS.set_string(tran_in_node, "COLOR_CLASS", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
	TRS.set_string(tran_in_node, "LOC_ID", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
	TRS.set_string(tran_in_node, "LINE_ID", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
	
	if (c_string_create_flag == 'Y')
	{
		if(WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}
	}

	if (c_combine_flag == 'Y')
	{
		// 2024-01-19 
		// Combine 되는 Lot(자식 Lot)이 Carrier에 Attach되어 있을때 Detach한다.
		// 원인 EAPMES_Load_Magazine 서비스가 호출될때 장비에서 MAGAZINE_ID이 누락으로 발생.
		DBC_init_mwipcrrlot(&MWIPCRRLOT);
		memcpy(MWIPCRRLOT.LOT_ID, MWIPLOTSTS_CELL.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID));
		DBC_select_mwipcrrlot(5, &MWIPCRRLOT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID));
			TRS.add_string(tran_in_node, "CRR_ID", MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID));
			TRS.add_double(tran_in_node, "QTY_1", MWIPCRRLOT.QTY_1);

			//DETACH CARRIER LOT 진행
			if (RAS_DETACH_LOT_CARRIER(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				LOG_head("CWIP_Tabber_End_Carrier_Detach_Error");
                LOG_add("Err_Code", MP_STR, sizeof(s_msg_code), s_msg_code);
                LOG_add("LOT_ID", MP_STR, sizeof(MWIPCRRLOT.LOT_ID), MWIPCRRLOT.LOT_ID);
                LOG_add("INTO_LOT_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
                LOG_add("QTY_1", MP_INT, MWIPCRRLOT.QTY_1);
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}
		}

		//COMBINE TRASACTION
		TRS.init_node(tran_in_node);
		TRS.init_node(tran_out_node);

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS_CELL.LOT_ID, sizeof(MWIPLOTSTS_CELL.LOT_ID));
			
		TRS.add_string(tran_in_node, "INTO_LOT_ID", s_string_lot_number, sizeof(s_string_lot_number));

		if (MWIPLOTSTS_CELL.QTY_1 < i_combine_qty )
		{
			i_combine_qty = (int)MWIPLOTSTS_CELL.QTY_1; // 여러개 BOX 를 Combine 할려면 이곳에서 COMBINE TRANSACTION LOOP 돌면됨.
		}
		//Combine 수량.
		TRS.add_double(tran_in_node, "MOVE_QTY_1", i_combine_qty);

		if(WIP_COMBINE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			LOG_head("CWIP_Tabber_end_Lot Combine Error");
			LOG_add("Err_Code", MP_STR, sizeof(s_msg_code), s_msg_code);
			LOG_add("LOT_ID", MP_STR, sizeof(MWIPLOTSTS_CELL.LOT_ID), MWIPLOTSTS_CELL.LOT_ID);
			LOG_add("INTO_LOT_ID", MP_STR, sizeof(s_string_lot_number), s_string_lot_number);
			LOG_add("MOVE_QTY_1", MP_INT, i_combine_qty);
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			/*TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;*/
		}
	}
	
	//락이 잘 걸려서 일단 임시로 커밋 처리 20200117 김한창 수석 요청
	DB_commit();

	/***************************************************/
	//END LOT
	/***************************************************/
	TRS.init_node(tran_in_node);
	TRS.init_node(tran_out_node);

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.LOT_ID, s_string_lot_number, sizeof(s_string_lot_number));
	DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING : ERROR 가 나면안됨
	}
		
	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');
	TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
	{
		//설비ID 가 없을경우 처리
		TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS_CELL.START_RES_ID, sizeof(MWIPLOTSTS_CELL.START_RES_ID));
		if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
		{
			//
		}

	}
		
	//END LOT 진행
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