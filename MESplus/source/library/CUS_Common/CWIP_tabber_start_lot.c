/*******************************************************************************

    System      : MESplus
    Module      : Tabber End Lot 
    File Name   : CWIP_Tabber_end.c
    Description : TABER OPERATION END ( CREATE / COMBINE / END )
				  
    MES Version : 5.0

    Function List
        - START :  CELL BOX (HALFCELL MAGAZINE ) START + DETACH CAARRIER: EQUIPMENT 
		
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.01.05  JUHYEON.JUNG   CREATE
	2     2024.02.23  BYUNGCHAE.KANG 자재추적성 반영
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.
*******************************************************************************/

#include "CUS_common.h"
#include "RASCore_common.h"
#include "CUS_HQCUSM_common.h"

int CWIP_TABBER_START_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_tabber_start_lot()
        - Tabber End Lot Service
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Tabber_Start_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_TABBER_START_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_tabber_start_lot", out_node);

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
    CWIP_TABBER_START_LOT()
        - TABBER OPERATION END LOT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_TABBER_START_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MWIPCRRLOT_TAG MWIPCRRLOT;
	struct CWIPCELMGZ_TAG CWIPCELMGZ;
	char s_sys_time[14];
	clock_t start_time;
	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CWIP_TABBER_START_LOT");
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
		//임시 향후 에러처리 필요함.
		TRS.set_string(in_node, "LINE_ID", "MDL01", strlen("MDL01"));
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

	/****************************************************************************/
	// 1. LOT ID OR  CARRIER ID ( HALFCELL MAGAZINE 으로 조회된 LOT)
	/****************************************************************************/
	CDB_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0006");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	
	/****************************************************************************/
	// 1.1. LOT 이 MAIN LINE 으로 넘어오지 않았을경우 HALFCELL MOVE 자동 발생함
	/****************************************************************************/
	start_time = STOPWATCH_START();
	if ((MWIPLOTSTS.END_FLAG == 'Y') && (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER)) == 0))
	{
		//실제 CART 의 상태 FLAG UPDATE 함
		/* move 와 MOVE 하지않은 케이스가 혼재되므로 tabber start 에서 clear logic 보강함..CWIPCELPAK만 처리 */
		/*{
			struct CWIPCELPAK_TAG CWIPCELPAK;

			CDB_init_cwipcelpak(&CWIPCELPAK);
			memcpy(CWIPCELPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CWIPCELPAK.LACK_ID, MWIPLOTSTS.LOT_GROUP_ID_2, sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
			CWIPCELPAK.PACK_TYPE = 'H';
			CWIPCELPAK.STATUS_FLAG = 'I';
			memcpy(CWIPCELPAK.CMF_2, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPCELPAK.CMF_4, sizeof(CWIPCELPAK.CMF_4), in_node, "RES_ID");

			CDB_update_cwipcelpak(4, &CWIPCELPAK); 
			if(DB_error_code != DB_SUCCESS)
			{
	
			}
		}*/
		
		//MOVE 안된 매거진의 상태FLAG
		//HALFCELL 매거진을 해당 CART 로 UPDATE 하여 해당 lot 만 move 하도록함  ( HALFCELL 구성작업 전 공동으로 쓸경우 사용)
		//memset(MWIPLOTSTS.LOT_GROUP_ID_2, ' ', sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
		//memcpy(MWIPLOTSTS.LOT_GROUP_ID_2, MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
		//CDB_update_mwiplotsts(3, &MWIPLOTSTS);
		//if(DB_error_code != DB_SUCCESS)
		//{
		//	//DO NOTHING
		//}
		//CART MOVE 수행.( 해당 LOT 의 전체 카트 수행 )
		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");
			
		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '2');
		//TRS.add_string(tran_in_node, "LACK_ID", MWIPLOTSTS.LOT_GROUP_ID_2, sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
		TRS.set_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		TRS.set_string(tran_in_node, "LINE_ID", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		TRS.set_string(tran_in_node, "MAGAZINE_ID", MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
		TRS.set_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node,  "LOT_ID"));

		//MODE LOT 진행
		if(CWIP_MOVE_HALFCELL_CART(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			//에러처리 안함.
		}
		STOPWATCH_END("MOVE_HALFCELL_CART_ELAPSED_TIME", start_time);
		STOPWATCH_END(TRS.get_string(tran_in_node, "LOT_ID"), start_time);
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
	}
	else
	{
		//Magazine의 첫번째 LOT에 대해서 동일한 Magazine에 담긴 LOT들에 대해
		//ERP I/F정보를 일괄 업데이트. 2019.10.09 JGCHOI.
		//(PROD_ORDER_NO = Tabber공정 ORDER_ID , INF_TIME = 현재시간, ZPISTAT ='R') 
		if(TRS.get_char(in_node, "FIRST_LOT_OF_MAGAZINE") == 'Y')
		{
			tran_in_node = TRS.create_node("MOVE_IF_IN");
			tran_out_node = TRS.create_node("CMN_OUT");

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.set_char(tran_in_node, "PROCSTEP", '2');//UPDATE
			TRS.set_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node,  "LOT_ID"));
			TRS.set_nstring(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "LINE_ID"));
			TRS.set_nstring(tran_in_node, "MAIN_ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
			TRS.set_nstring(tran_in_node, "MAGAZINE_ID", MWIPLOTSTS.CRR_ID, sizeof(MWIPLOTSTS.CRR_ID));
			TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '3'); 

			if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}

			STOPWATCH_END("MOV_IF_U_ELAPSED_TIME", start_time);
			STOPWATCH_END(TRS.get_string(tran_in_node, "LOT_ID"), start_time);
			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
		}
		
	}

	/***************************************************/
	// 2. START LOT
	/***************************************************/
	tran_in_node = TRS.create_node("TRAN_LOT_IN");
	tran_out_node = TRS.create_node("TRAN_LOT_OUT");
		
	start_time = STOPWATCH_START();
	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');
	TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	TRS.add_nstring(tran_in_node, "VMAGAZINE_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));
	if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
	{
		//CORE 에서 에러나니..그냥둚.(테스트를 위해 강제 로 셋팅할경우 추가함.)
	}

	TRS.add_nstring(tran_in_node, "TRAN_CMF_1", TRS.get_string(in_node, "TRAN_CMF_1"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_2", TRS.get_string(in_node, "TRAN_CMF_2"));
	TRS.add_nstring(tran_in_node, "TRAN_CMF_3", TRS.get_string(in_node, "VMAGAZINE_ID")); //VMAGAZINE
	TRS.add_string(tran_in_node, "TRAN_CMF_4",  MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));		//START LINE (MAIN LINE)
	TRS.add_string(tran_in_node, "TRAN_CMF_5",  MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));		//START ORDER(MAIN LINE)
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

	STOPWATCH_END("TABBER_START_LOT_ELAPSED_TIME", start_time);
	/***************************************************/
	// 3. DETACH LOT - CARRIER
	/***************************************************/
	start_time = STOPWATCH_START();
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
		{
			/*TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;*/
		}
	}
	STOPWATCH_END("DETACH_CRR_ELAPSED_TIME", start_time);

	/***************************************************/
	// 4. HCELL CART CLEAR
	/***************************************************/
	start_time = STOPWATCH_START();
	if (COM_isspace(MWIPLOTSTS.LOT_GROUP_ID_2, sizeof(MWIPLOTSTS.LOT_GROUP_ID_2)) == MP_FALSE)
	{
		struct CWIPCELPAK_TAG CWIPCELPAK;

		CDB_init_cwipcelpak(&CWIPCELPAK);
		CWIPCELPAK.STATUS_FLAG = 'I';
		memcpy(CWIPCELPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPCELPAK.FACTORY));
		memcpy(CWIPCELPAK.LACK_ID, MWIPLOTSTS.LOT_GROUP_ID_2, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
		CWIPCELPAK.PACK_TYPE = 'H';
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
		CDB_update_cwipcelpak(4, &CWIPCELPAK); // C로 상태변경 , CMF_4 설비
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		

		//자재 추적성(2024.02.23) Start
		CDB_init_cwipcelmgz(&CWIPCELMGZ);
		memcpy(CWIPCELMGZ.FACTORY, CWIPCELPAK.FACTORY, sizeof(CWIPCELMGZ.FACTORY));
		CWIPCELMGZ.PACK_TYPE = 'H';
		CWIPCELMGZ.CMF_1[0] = 'I'; // STATUS_FLAG
		memcpy(CWIPCELMGZ.CMF_3, CWIPCELPAK.LACK_ID, sizeof(CWIPCELMGZ.CMF_3));  // LACK_ID

		memcpy(CWIPCELMGZ.CMF_2, CWIPCELPAK.CMF_2, sizeof(CWIPCELPAK.CMF_2));
		TRS.copy(CWIPCELMGZ.CMF_4, sizeof(CWIPCELMGZ.CMF_4), in_node, "RES_ID");
		CDB_update_cwipcelmgz(6, &CWIPCELMGZ); // C로 상태변경 , CMF_2 투입시간, CMF_4 설비
        if (DB_error_code != DB_SUCCESS)
        {
            //DO NOTHING
        }
		//자재 추적성(2024.02.23) End

		// LOTDML GROUP_ID_2 ALL CLEAR (HCLL CELL CART ID)
		// 해당 LOT GROUP ID 를 가지고 있는 전체 FULL CART.CELL CLEAR
		// 현재는 DOCK IN / OUT 이 없어 너무 꼬임.. 처음 CART ID 가 있는 놈이 올라오면 해당 cart 가 모두 넘어온것으로 보고
		// cLEAR함
		CDB_update_mwiplotsts(5, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		
	}

	//MAIN ORDER UPDATE 
	if (COM_isspace(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID)) == MP_FALSE)
	{
		struct CWIPCELPAK_TAG CWIPCELPAK;
		//MAIN ORDER UPDATE
		CDB_init_cwipcelpak(&CWIPCELPAK);
		memcpy(CWIPCELPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		CWIPCELPAK.PACK_TYPE = 'H';
		memcpy(CWIPCELPAK.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		memcpy(CWIPCELPAK.CMF_10, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		CDB_update_cwipcelpak(7, &CWIPCELPAK); // MAIN ORDER UPDATE
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}
	STOPWATCH_END("CWIPCELPAK_U_ELAPSED_TIME", start_time);
	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}