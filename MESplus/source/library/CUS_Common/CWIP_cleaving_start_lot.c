/*******************************************************************************

    System      : MESplus
    Module      : Cleaving Operation Start Lot
    File Name   : CWIP_cleaving_start.c
    Description : Cleaving OPERATION start ( START / DETACH CARRier )
				  
    MES Version : 5.0

    Function List
        - START :  CELL BOX (FULLCELL MAGAZINE ) START + DETACH CAARRIER: EQUIPMENT 
		
    Detail Description
        - 

    History
    Seq   Date        Developer       Description                        
    ---------------------------------------------------------------------------
    1     2018.01.05  JUHYEON.JUNG    CREATE
	2     2024.02.23  BYUNGCHAE.KANG  자재추적성 반영
    Copyright(C) 1998-2008 Miracom,Inc. 
	All rights reserved.
*******************************************************************************/

#include "CUS_common.h"
#include <RASCore_common.h>

int CWIP_CLEAVING_START_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_cleaving_start_lot()
        - Tabber End Lot Service
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Cleaving_Start_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_CLEAVING_START_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_cleaving_start_lot", out_node);

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
    CWIP_CLEAVING_START_LOT()
        - TABBER OPERATION END LOT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_CLEAVING_START_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF_FCELL;
	struct MWIPCRRLOT_TAG MWIPCRRLOT;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CWIPORDBOM_TAG CWIPORDBOM;
	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct CCLVCRRBAT_TAG CCLVCRRBAT;
	struct CWIPCELMGZ_TAG CWIPCELMGZ;
	clock_t start_time;

	char s_sys_time[14];
	char c_create_flag ;
	char   s_due_time[14];

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CWIP_CLEAVING_START_LOT");
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

	/* 설비에서 준 작업지시로 진행 */
	TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");

	//if (COM_isspace(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID)) == MP_TRUE)
	//	memcpy(MWIPORDSTS.ORDER_ID, MGCMTBLDAT.DATA_3, sizeof(MWIPORDSTS.ORDER_ID));

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

	//0. 설비 ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

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

	start_time = STOPWATCH_START();
	/****************************************************************************/
	// 1. LOT ID 
	/****************************************************************************/
	c_create_flag = 'N'; 
	CDB_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			c_create_flag = 'Y';
		}
		else
		{
			strcpy(s_msg_code, "WIP-0006");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
	}
	/****************************************************************************/
	// 1.1 FULL CELL 구성이 없더라도 정상진행 되게 구성. 
	/****************************************************************************/
	if (c_create_flag == 'Y')
	{
		/****************************************************************************/
		// 1. FCELL LOT CREATION (VMAGAZINE ID)
		/****************************************************************************/
		//FUCELL 품번 가져옮. (먼저가져와서 사용, ERROR 처리를 위해 가져와서 사용권장..)
		CDB_init_cwipordbom(&CWIPORDBOM);
		memcpy(CWIPORDBOM.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		memcpy(CWIPORDBOM.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
		CDB_select_cwipordbom(4, &CWIPORDBOM);
		if(DB_error_code != DB_SUCCESS)
		{
			//에러처리
			//memcpy(CWIPORDBOM.MAT_ID,  "000006581260411126", strlen("000006581260411126")); 
			strcpy(s_msg_code, "WIP-0561");
			TRS.set_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/* Get material information FULLCELL */
		DBC_init_mwipmatdef(&MWIPMATDEF_FCELL);
		TRS.copy(MWIPMATDEF_FCELL.FACTORY, sizeof(MWIPMATDEF_FCELL.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPMATDEF_FCELL.MAT_ID, CWIPORDBOM.MAT_ID, sizeof(MWIPMATDEF_FCELL.MAT_ID));
		MWIPMATDEF_FCELL.MAT_VER = 1;

		DBC_select_mwipmatdef(1, &MWIPMATDEF_FCELL);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0006");
			TRS.add_fieldmsg(out_node, "MWIPMATDEF_FCELL SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
			TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');

		//LOT_ID 는 STRING ID 로 생성.
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPMATDEF_FCELL.MAT_ID, sizeof(MWIPMATDEF_FCELL.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", 1);
		TRS.add_string(tran_in_node, "FLOW", MWIPMATDEF_FCELL.FIRST_FLOW, sizeof(MWIPMATDEF_FCELL.FIRST_FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", 1); 
		TRS.add_string(tran_in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof( MRASRESDEF.RES_CMF_2));
		TRS.add_char(tran_in_node, "LOT_TYPE", 'P');   
		TRS.add_string(tran_in_node, "CREATE_CODE", HQCEL_LOT_CREATECODE_FCELBX, strlen(HQCEL_LOT_CREATECODE_FCELBX));
		TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
		TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
		
		if (TRS.get_int(in_node,"MAGAZINE_QTY") > 0)
			TRS.add_double(tran_in_node, "QTY_1", TRS.get_int(in_node,"MAGAZINE_QTY"));   
		else
			TRS.add_double(tran_in_node, "QTY_1", 300);

		TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));

		/* BACK TIME */
		if (memcmp(s_sys_time, TRS.get_string(in_node, "CLIENT_TIME"), 14) > 0)
		{
			//CLIENT TIME 이 시스템타임보다 빠른경우가 있음..
			if (memcmp(MWIPLOTSTS.LAST_TRAN_TIME, TRS.get_string(in_node, "CLIENT_TIME"), 14) <= 0) 
				TRS.set_string(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "CLIENT_TIME"), 14);
		}
		
		memset(s_due_time, ' ' , sizeof(s_due_time));
		COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

		TRS.add_string(tran_in_node, "DUE_TIME",s_due_time, sizeof(s_due_time));
		TRS.add_string(tran_in_node, "LOT_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));

		TRS.set_string(tran_in_node, "COLOR_CLASS", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
		TRS.set_string(tran_in_node, "LOC_ID", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
		TRS.set_string(tran_in_node, "LINE_ID", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		if(WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		STOPWATCH_END("CLEAVING_LOT_CREATE_ELAPSED_TIME", start_time);
	}
	else
	{

		//MAGAZINE 의 ORDER(CART의 오더) 와 현재 진행오더 체크
		/* FULL CELL 구성된 MAGAZINE 의 ORDER 와 현재 진행오더가 틀리면 오류 */
		if (memcmp(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID)) != 0)
		{
			if( TRS.get_char(in_node, "VALIDATE_CHECK_SKIP_FLAG") != 'Y') {
				strcpy(s_msg_code, "WIP-0582");
				TRS.add_fieldmsg(out_node, "MWIPMATDEF_FCELL SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "MAGAZINE_ID", MP_STR, sizeof(MWIPLOTSTS.CRR_ID), MWIPLOTSTS.CRR_ID);
				TRS.add_fieldmsg(out_node, "CELL_BOX_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID),  MWIPLOTSTS.LOT_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	    STOPWATCH_END("CREATE_SKIP_ELAPSED_TIME", start_time);		
	
	}

	/***************************************************/
	// 2. START LOT
	/***************************************************/
	start_time = STOPWATCH_START();

	tran_in_node = TRS.create_node("TRAN_LOT_IN");
	tran_out_node = TRS.create_node("TRAN_LOT_OUT");
			
	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');
	TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	
	/* BACK TIME */
	if (memcmp(s_sys_time, TRS.get_string(in_node, "CLIENT_TIME"), 14) > 0)
	{
		//CLIENT TIME 이 시스템타임보다 빠른경우가 있음..
		if (memcmp(MWIPLOTSTS.LAST_TRAN_TIME, TRS.get_string(in_node, "CLIENT_TIME"), 14) <= 0) 
			TRS.set_string(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "CLIENT_TIME"), 14);
	}
	
	if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
	{
		//CORE 에서 에러나니..그냥둚.(테스트를 위해 강제 로 셋팅할경우 추가함.)

	}
	
	TRS.add_nstring(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "TRAN_CMF_1"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "TRAN_CMF_2"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_3", TRS.get_string(in_node, "TRAN_CMF_3"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_4", TRS.get_string(in_node, "TRAN_CMF_4"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_5", TRS.get_string(in_node, "TRAN_CMF_5"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_6", TRS.get_string(in_node, "TRAN_CMF_6"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_7", TRS.get_string(in_node, "TRAN_CMF_7"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_8", TRS.get_string(in_node, "TRAN_CMF_8"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_9", TRS.get_string(in_node, "TRAN_CMF_9"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_10", TRS.get_string(in_node, "TRAN_CMF_10"));

	//START LOT 진행
	if(WIP_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		return MP_FALSE;
	}
	STOPWATCH_END("CLEAVING_START_ELAPSED_TIME", start_time);
	/***************************************************/
	// 3. DETACH LOT - CARRIER
	/***************************************************/
	start_time = STOPWATCH_START();
	if (COM_isspace(MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID)) == MP_FALSE)
	{
		DBC_init_mwipcrrlot(&MWIPCRRLOT);
		memcpy(MWIPCRRLOT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(MWIPCRRLOT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		memcpy(MWIPCRRLOT.CRR_ID, MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
		if ( DBC_select_mwipcrrlot_scalar(1, &MWIPCRRLOT) > 0)
		{
			//CRRID 가 있을경우 CARRIER DETACH
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);
			
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "CRR_ID", MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
			TRS.add_double(tran_in_node, "QTY_1", MWIPLOTSTS.QTY_1);

			//DETACH CARRIER LOT 진행
			if(RAS_DETACH_LOT_CARRIER(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{/*
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;*/
				LOG_head("CWIP_Cleaving_Start_Lot_RAS_DETACH_LOT_CARRIER");
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}

			//LOT 의 CRR_ID CLEAR(이전데이터를 위해 강제 클리어)

			/*****************************************************/
			//2019.09.20 : JUHYEON.JUNG -> 주석처리
			//OPEN 초기 CLEAR 되지 않은 CARRIER 를 자동으로 CLEAR 할려고 추가한 소스
			//정상로직에 의해서는 필요없고 현재 처리하는 LOT 의 CRR_ID 이외 다른 LOT 이 해당 CRR_ID 를 
			//가지고 있다면 BLCOK 될 확률이 있어 소스제외함 
			//UPDATE MWIPLOTSTS SET CRR_ID = ' ' WHERE CRR_ID = ? 문장임
			/*****************************************************/
			//CDB_update_mwiplotsts(6, &MWIPLOTSTS);
			//if(DB_error_code != DB_SUCCESS)
			//{
				//DO NOTHING
			//}		
		}
	}
	STOPWATCH_END("DETACH_LOT_ELAPSED_TIME", start_time);

	/***************************************************/
	// 4. FCELL CART CLEAR
	/***************************************************/
	//CWIPCELPAK DATA CART CLEARE ( STATUS_FLAG = 'C' 로 업데이트 )
	/***
	EXEC SQL UPDATE CWIPCELPAK SET
                    STATUS_FLAG = :CWIPCELPAK_N.STATUS_FLAG
                WHERE FACTORY = :CWIPCELPAK_N.FACTORY
                    AND PACK_TYPE = :CWIPCELPAK_N.PACK_TYPE
                    AND LACK_ID = :CWIPCELPAK_N.LACK_ID;
	**/
	start_time = STOPWATCH_START();

	/*Cleaving Carrery Clear Bat*/
	CDB_init_cclvcrrbat(&CCLVCRRBAT);
    TRS.copy(CCLVCRRBAT.ORDER_ID, sizeof(CCLVCRRBAT.ORDER_ID), in_node, "ORDER_ID");
	memcpy(CCLVCRRBAT.CART_ID, MWIPLOTSTS.LOT_GROUP_ID_1, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
	TRS.copy(CCLVCRRBAT.RES_ID, sizeof(CCLVCRRBAT.RES_ID), in_node, "RES_ID");
	memcpy(CCLVCRRBAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	CCLVCRRBAT.CLEAR_FLAG = 'N';
	memcpy(CCLVCRRBAT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
	
	if (COM_isspace(MWIPLOTSTS.LOT_GROUP_ID_1, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1)) == MP_FALSE)
	{
		CDB_init_cwipcelpak(&CWIPCELPAK);
		CWIPCELPAK.STATUS_FLAG = 'I';
		memcpy(CWIPCELPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPCELPAK.FACTORY));
		memcpy(CWIPCELPAK.LACK_ID, MWIPLOTSTS.LOT_GROUP_ID_1, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
		CWIPCELPAK.PACK_TYPE = 'F';
		memcpy(CWIPCELPAK.CMF_2, s_sys_time, sizeof(s_sys_time));

		/* BACK TIME */
		if (memcmp(s_sys_time, TRS.get_string(in_node, "CLIENT_TIME"), 14) > 0)
		{
			//CLIENT TIME 이 시스템타임보다 빠른경우가 있음..
			if (memcmp(MWIPLOTSTS.LAST_TRAN_TIME, TRS.get_string(in_node, "CLIENT_TIME"), 14) <= 0) 
			{
				memset(CWIPCELPAK.CMF_2, ' ', sizeof(CWIPCELPAK.CMF_2));
				TRS.copy(CWIPCELPAK.CMF_2, 14, in_node, "CLIENT_TIME");
			}
		}
		TRS.copy(CWIPCELPAK.CMF_4, sizeof(CWIPCELPAK.CMF_4), in_node, "RES_ID");
		CDB_update_cwipcelpak(4, &CWIPCELPAK); // C로 상태변경 , CMF_2 투입시간, CMF_4 설비
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
			LOG_head("CWIP_Cleaving_Start_Lot_CDB_update_cwipcelpak_4");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		}

		//자재 추적성(2024.02.23) Start
		CDB_init_cwipcelmgz(&CWIPCELMGZ);
        memcpy(CWIPCELMGZ.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPCELPAK.FACTORY));
        CWIPCELMGZ.PACK_TYPE = 'F';
		CWIPCELMGZ.CMF_1[0] = 'I';  // STATUS_FLAG
        memcpy(CWIPCELMGZ.CMF_3, CWIPCELPAK.LACK_ID, sizeof(CWIPCELMGZ.CMF_3));  // LACK_ID

        memcpy(CWIPCELMGZ.CMF_2, CWIPCELPAK.CMF_2, sizeof(s_sys_time));
		TRS.copy(CWIPCELMGZ.CMF_4, sizeof(CWIPCELMGZ.CMF_4), in_node, "RES_ID");
        CDB_update_cwipcelmgz(6, &CWIPCELMGZ); // CMF_2 : 투입시간, CMF_4 : 설비
        if (DB_error_code != DB_SUCCESS)
		{
            LOG_head("CWIP_Cleaving_Start_Lot_CDB_update_cwipcelmgz_1");
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		}
		//자재 추적성(2024.02.23) End
		// LOTDML GROUP_ID_1 ALL CLEAR (FUCLL CELL CART ID)
		// 해당 LOT GROUP ID 를 가지고 있는 전체 FULL CART.CELL CLEAR
		// CART DOCK IN / OUT 이 잘되면 이부분 수정필요..
		// 현재는 DOCK IN / OUT 이 없어 너무 꼬임.. 처음 CART ID 가 있는 놈이 올라오면 해당 cart 를  dock in 으로 보고 cLEAR함
		
		//DO NOTHING
		LOG_head("CWIP_Cleaving_Start_Lot_CDB_insert_cclvcrrbat1");
		COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

		//IS-21-04-008  4월4일 DB 장애 원인 및 대응 방안 점검
		CDB_insert_cclvcrrbat(&CCLVCRRBAT);
		
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
			LOG_head("CWIP_Cleaving_Start_Lot_CDB_insert_cclvcrrbat2");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			
			//CDB_update_mwiplotsts(4, &MWIPLOTSTS);
			//if(DB_error_code != DB_SUCCESS)
			//{
			//	//DO NOTHING
			//	LOG_head("CWIP_Cleaving_Start_Lot_CDB_update_mwiplotsts_4");
			//	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			//}
		}

	}
	STOPWATCH_END("F_CELL_CART_CLEAR_ELAPSED_TIME", start_time);
	
	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}