/*******************************************************************************

    System      : MESplus
    Module      : Packing HalfCell
    File Name   : CWIP_packing_halfcell.c
    Description : SOI -> MES

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.05  SW.HWANG
	2          12,26  JUHYEON       ADD / MODIFY / DEBUG .....
	3     2024.02.23  BYUNGCHAE.KANG 자재추적성 반영
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_Packing_Halfcell()
        - SOI->MES Packing HalfCell
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Packing_Halfcell(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

	/****************************************************************************************/
	///클래빙 공정 운영,  Full Cell 대차 구성부터 시작 시  TRS.get_procstep(in_node) == '1' 
	// 클래빙 공정 미운영, Half Cell 대차 구성부터 시작 시 TRS.get_procstep(in_node) == '2' 
	/***************************************************************************************/

	if (TRS.get_procstep(in_node) == '1')
	{
		i_ret = CWIP_PACKING_HALFCELL(s_msg_code, in_node, out_node);
	}
	else
	{
		i_ret = CWIP_PACKING_HALFCELL_BOX(s_msg_code, in_node, out_node);
	}

    COM_out_msg_log_write(s_msg_code, "CWIP_Packing_Halfcell", out_node);

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
    CWIP_Packing_Halfcell()
        - SOI->MES Packing HalfCell
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_PACKING_HALFCELL(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct CWIPCELPAK_TAG CWIPCELPAK;

	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_FCELL;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct CINVCELRCV_TAG CINVCELRCV;
	struct CWIPORDBOM_TAG CWIPORDBOM;
	struct CWIPHAFHIS_TAG CWIPHAFHIS;  //IS-21-10-017
	struct CWIPCELMGZ_TAG CWIPCELMGZ;  // 자재 추적성
	
	TRSNode* tran_in_node;
	TRSNode* tran_out_node;
	TRSNode* res_list;
	clock_t start_time;

	char s_sys_time[14];
	char s_to_lot_number[25];
	char s_due_time[14];

	TRSNode** list ;
	int i;
	int icellqty = 0;

	char c_combine_flag = ' ';

	// PROCESS LOG PRINT
	LOG_head("CWIP_PACKING_HALFCELL");
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

	//ORDER SELECT (CLEAVING LINE 작업지시)
	DBC_init_mwipordsts(&MWIPORDSTS);
	TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, "FACTORY");
	TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
	DBC_select_mwipordsts(1, &MWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "ORD-0002");
        TRS.set_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//ORDER TYPE (CMF_4 == 'HM03' 이면 ERP INTERFACE 안함) -> ERP UPLOAD COMMON 에 있음


	//PRODUCT SELECT
	DBC_init_mwipmatdef(&MWIPMATDEF);
	memcpy(MWIPMATDEF.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
	memcpy(MWIPMATDEF.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	MWIPMATDEF.MAT_VER = 1;
	DBC_select_mwipmatdef(1, &MWIPMATDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "WIP-0006");
        TRS.set_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	// HALF Cell MAT-FLOW 등록 체크
	if(COM_isnullspace(MWIPMATDEF.FIRST_FLOW) == MP_TRUE)
	{
		strcpy(s_msg_code, "WIP-0597");
        TRS.add_fieldmsg(out_node, "MWIPMATDEF.MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
		
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

	// INSERT CWIPCELPAK
	list = TRS.get_list(in_node, "HALFCELL_PACK_LIST");

	for (i = 0; i < TRS.get_item_count(in_node, "HALFCELL_PACK_LIST"); i++)
	{
		/****************************************************************************/
		////Full Cell 에서 한개를 가지고 와서 Combine 시킴 
		// 해당 line 에서 투입된 기준으로 선입선출 해서 가져옮.
		// LOT_DESC 에 TIME_STAMP 값 같이 가져옮.
		/****************************************************************************/

		CDB_init_cinvcelrcv(&CINVCELRCV);
		memset(s_to_lot_number, ' ', sizeof(s_to_lot_number));

		c_combine_flag = 'Y';
		CDB_init_mwiplotsts(&MWIPLOTSTS_FCELL);
		memcpy(MWIPLOTSTS_FCELL.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		memcpy(MWIPLOTSTS_FCELL.OPER, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		memcpy(MWIPLOTSTS_FCELL.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		//memcpy(MWIPLOTSTS_FCELL.MAT_ID, CWIPORDBOM.MAT_ID, sizeof(CWIPORDBOM.MAT_ID)); // Server Crash 190925
		memcpy(MWIPLOTSTS_FCELL.MAT_ID, CWIPORDBOM.MAT_ID, sizeof(MWIPLOTSTS_FCELL.MAT_ID)); 
		TRS.copy(MWIPLOTSTS_FCELL.START_RES_ID, sizeof(MWIPLOTSTS_FCELL.START_RES_ID), in_node, "RES_ID");
		MWIPLOTSTS_FCELL.START_FLAG = 'Y';

		//CDB_select_mwiplotsts(7, &MWIPLOTSTS_FCELL);
		//2019.09.20 : CASE 7->9 로 변경 : LOT_GROUP_ID_1 = ' ' 인것만.
		CDB_select_mwiplotsts(9, &MWIPLOTSTS_FCELL);
		if(DB_error_code != DB_SUCCESS)
		{
			//2. 장비 - BOM기준 FULL  CELL 품번중 먼저 START 된놈
			//2019.09.20 : CASE 5->10 로 변경 : LOT_GROUP_ID_1 = ' ' 인것만.
			//CDB_select_mwiplotsts(5, &MWIPLOTSTS_FCELL);
			CDB_select_mwiplotsts(10, &MWIPLOTSTS_FCELL);
		}
		
		if(DB_error_code == DB_NOT_FOUND)
		{	
			//3.장비 - START기준 FULL  CELL 품번중 먼저 START 된놈
			//2019.09.20 : CASE 3->11 로 변경 : LOT_GROUP_ID_1 = ' ' 인것만.
			//CDB_select_mwiplotsts(3, &MWIPLOTSTS_FCELL);
			CDB_select_mwiplotsts(11, &MWIPLOTSTS_FCELL);
		}
		if(DB_error_code != DB_SUCCESS)
		{
			//가져올LOT 이 없을경우 해당 공정에 있는 LOT 중 먼저들어온놈중에 하나를 가져옮.
			MWIPLOTSTS_FCELL.START_FLAG = ' ';
			MWIPLOTSTS_FCELL.END_FLAG = ' ';
			//2019.09.20 : CASE 4->12 로 변경 : LOT_GROUP_ID_1 = ' ' 인것만.
			//CDB_select_mwiplotsts(4, &MWIPLOTSTS_FCELL);
			CDB_select_mwiplotsts(12, &MWIPLOTSTS_FCELL);
			if(DB_error_code != DB_SUCCESS)
			{	
				//COMBINE 하지 않고 강제로 진행 : 필요시 ERROR 처리.가상LotNUMBER  는 현재시간 + 0000000 으로 맞춤
				c_combine_flag = 'N';
				memset(MWIPLOTSTS_FCELL.LOT_DESC, '0', 21);
				memcpy(MWIPLOTSTS_FCELL.LOT_DESC, s_sys_time, sizeof(s_sys_time));
			}
		}
		
		//CINVCELRCV DATA GET
		memcpy(CINVCELRCV.FACTORY, MWIPLOTSTS_FCELL.FACTORY, sizeof(CINVCELRCV.FACTORY));
		memcpy(CINVCELRCV.INV_LOT_ID, MWIPLOTSTS_FCELL.LOT_ID, sizeof(MWIPLOTSTS_FCELL.LOT_ID));
		CDB_select_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		memcpy(s_to_lot_number, MWIPLOTSTS_FCELL.LOT_DESC, 21); //임시LOT 은 현재 TIMESTAMP 값을 가지고 사용.

		icellqty = TRS.get_int(in_node, "MAGAZINE_QTY");
		if (icellqty < 1)
			icellqty = 300; //HALFCELL 300 EA 씩 만듦. ,설비에서 올려준값을 사용하나 혹 없으면 셋팅값 사용..
	
		//Cleaving VMagazine ID(2024/02/04)
		CDB_init_mwiplothis(&MWIPLOTHIS);
		memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS_FCELL.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		memcpy(MWIPLOTHIS.TRAN_CODE, "START", strlen("START"));
		memcpy(MWIPLOTHIS.OLD_OPER, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		CDB_select_mwiplothis(3, &MWIPLOTHIS);

		//CELL PACK DATA CONTROL
		CDB_init_cwipcelpak(&CWIPCELPAK);
		
		memcpy(CWIPCELPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		//memcpy(CWIPCELPAK.PACK_ID, TRS.get_string(list[i],"PACK_ID"), sizeof(CWIPCELPAK.PACK_ID));
		TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), list[i], "PACK_ID"); //Server Crash 20200906
		memcpy(CWIPCELPAK.CELL_BOX_ID, MWIPLOTSTS_FCELL.LOT_ID, sizeof(MWIPLOTSTS_FCELL.LOT_ID));
		
		CDB_select_cwipcelpak(1, &CWIPCELPAK);
		if(DB_error_code == DB_SUCCESS)
		{
			//삭제하고 다시 넣음
			//CMF_3 이 EMI PARTITON KEY 이므로 변경되면 안됨.
			CDB_delete_cwipcelpak(1, &CWIPCELPAK);  //waiting
			{
				LOG_head("CWIP_Packing_Halfcell_CDB_delete_cwipcelpak");
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}
		}
		else
		{
			memcpy(CWIPCELPAK.CMF_3, s_sys_time, 14);
		}
		//memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[i],"LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
		TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), list[i], "LACK_ID"); //Server Crash 20200906
		

		CWIPCELPAK.PACK_TYPE = 'H';
		memcpy(CWIPCELPAK.OPER, HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		memcpy(CWIPCELPAK.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
		memcpy(CWIPCELPAK.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		CWIPCELPAK.PACK_QTY = icellqty ; 

		memcpy(CWIPCELPAK.FLOW, MWIPMATDEF.FIRST_FLOW, sizeof(MWIPMATDEF.FIRST_FLOW));

		//CWIPCELPAK의 BATCH NO (MES ) 는 같이 묶인 MAGAZINE ID 로함
		memcpy(CWIPCELPAK.BATCHNO, CWIPCELPAK.PACK_ID, sizeof(CINVCELRCV.BATCHNO));

		//memcpy(CWIPCELPAK.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CINVCELRCV.UNIT_ID)); // Server Crash 190925
		memcpy(CWIPCELPAK.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CWIPCELPAK.UNIT_ID)); 
		memcpy(CWIPCELPAK.RCV_CELLBOX_ID, CINVCELRCV.SMALLBOXID, sizeof(CINVCELRCV.SMALLBOXID));
		memcpy(CWIPCELPAK.LARGEBOXID, CINVCELRCV.LARGEBOXID, sizeof( CINVCELRCV.LARGEBOXID));
		memcpy(CWIPCELPAK.CELLTYPE,  CINVCELRCV.CELLTYPE, sizeof(CWIPCELPAK.CELLTYPE));
		memcpy(CWIPCELPAK.CELLPRODUCTDATE, CINVCELRCV.CELLPRODUCTDATE, sizeof(CINVCELRCV.CELLPRODUCTDATE));
		memcpy(CWIPCELPAK.CELLGRADE, CINVCELRCV.CELLGRADE, sizeof(CINVCELRCV.CELLGRADE));
		memcpy(CWIPCELPAK.CELLBOXBARCODE, CINVCELRCV.CELLBOXBARCODE, sizeof(CINVCELRCV.CELLBOXBARCODE));
		CWIPCELPAK.INSPECT_STATUS =CINVCELRCV.INSPECT_STATUS;
		CWIPCELPAK.BLOCK_STATUS = CINVCELRCV.BLOCK_STATUS;
		memcpy(CWIPCELPAK.BLOCK_DATE, CINVCELRCV.BLOCK_DATE, sizeof(CINVCELRCV.BLOCK_DATE));
		memcpy(CWIPCELPAK.POWERGRADE, CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE));
		memcpy(CWIPCELPAK.QUALITYGRADE, CINVCELRCV.QUALITYGRADE, sizeof(CINVCELRCV.QUALITYGRADE));
		CWIPCELPAK.AVG_NCELL = CINVCELRCV.AVG_NCELL;
		CWIPCELPAK.AVG_ISC = CINVCELRCV.AVG_ISC;
		CWIPCELPAK.AVG_UOC = CINVCELRCV.AVG_UOC;
		CWIPCELPAK.AVG_FF = CINVCELRCV.AVG_FF;
		CWIPCELPAK.AVG_RS = CINVCELRCV.AVG_RS;
		CWIPCELPAK.AVG_RSH = CINVCELRCV.AVG_RSH;
		CWIPCELPAK.AVG_TEMPERATURE = CINVCELRCV.AVG_TEMPERATURE;
		CWIPCELPAK.AVG_NCELL = CINVCELRCV.AVG_NCELL;
		memcpy(CWIPCELPAK.PRODUCTCLASSID, CINVCELRCV.PRODUCTCLASSID, sizeof(CINVCELRCV.PRODUCTCLASSID));
		memcpy(CWIPCELPAK.PRODUCTDEFINITIONTYPE, CINVCELRCV.PRODUCTDEFINITIONTYPE, sizeof(CINVCELRCV.PRODUCTDEFINITIONTYPE));
		memcpy(CWIPCELPAK.GR_BATCHNO,  CINVCELRCV.GR_BATCHNO, sizeof(CINVCELRCV.GR_BATCHNO));
		memcpy(CWIPCELPAK.GR_DATE, CINVCELRCV.GR_DATE, sizeof(CINVCELRCV.GR_DATE));
		memcpy(CWIPCELPAK.GI_BATCH_NO, CINVCELRCV.GR_DATE, sizeof(CINVCELRCV.GR_DATE));
		CWIPCELPAK.STATUS_FLAG = 'I';
		memcpy(CWIPCELPAK.CMF_1, s_to_lot_number, sizeof(s_to_lot_number));  //LOT NUMBER (HALF CELL VIRTUAL)

		TRS.copy(CWIPCELPAK.CMF_6, sizeof(CWIPCELPAK.CMF_6), in_node, "RES_ID"); //CLEAVING EQUIPMENT

		//RPT MView데이터가 있는 경우 기존 데이터를 삭제하는 로직 추가(2023/06/02 by kbc)
		if ( strncmp(CWIPCELPAK.CELL_BOX_ID, " ", 1 ) == 0 )  
		{
			//PRT DATABASE MV_CWIPCELPAK 삭제
			CDB_delete_cwipcelpak(100, &CWIPCELPAK);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			//PRT DATABASE CWIPCELPAK 삭제
			CDB_delete_cwipcelpak(101, &CWIPCELPAK);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}

		CDB_insert_cwipcelpak(&CWIPCELPAK); 
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
			LOG_head("CWIP_Packing_Halfcell_CDB_insert_cwipcelpak");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

		}

		//자재 추적성(2024.02.23) Start
        CDB_init_cwipcelmgz(&CWIPCELMGZ);
        memcpy(CWIPCELMGZ.FACTORY, CWIPCELPAK.FACTORY, sizeof(CWIPCELMGZ.FACTORY));
        memcpy(CWIPCELMGZ.CELL_BOX_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELMGZ.CELL_BOX_ID));
        memcpy(CWIPCELMGZ.PACK_ID, CWIPCELPAK.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID));

        CDB_select_cwipcelmgz(4, &CWIPCELMGZ);
        if (DB_error_code == DB_SUCCESS)
        {
            CDB_delete_cwipcelmgz(2, &CWIPCELMGZ);  //waiting
            if (DB_error_code == DB_SUCCESS)
            {
                LOG_head("CWIP_Packing_Halfcell_CDB_delete_cwipcelpak");
                COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
            }
        }

        CDB_init_cwipcelmgz(&CWIPCELMGZ);
        memcpy(CWIPCELMGZ.FACTORY, MWIPORDSTS.FACTORY, sizeof(CWIPCELMGZ.FACTORY));
        memcpy(CWIPCELMGZ.CELL_BOX_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELMGZ.CELL_BOX_ID));
        CDB_select_cwipcelmgz(3, &CWIPCELMGZ);

        memcpy(CWIPCELMGZ.PACK_ID, CWIPCELPAK.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID));
		memcpy(CWIPCELMGZ.CVMAGAZINE_ID, MWIPLOTHIS.TRAN_CMF_3, sizeof(MWIPLOTHIS.TRAN_CMF_3));
		// Half Cell, 자재추적성 데이터 생성 Procedure(P_BAT_RPT_TRACE_N_CTM) 사용
		memcpy(CWIPCELMGZ.CMF_5, s_to_lot_number, sizeof(s_to_lot_number)); 
        CWIPCELMGZ.PACK_TYPE = 'H';
		CWIPCELMGZ.CMF_1[0] = 'I';
		memcpy(CWIPCELMGZ.CMF_3, CWIPCELPAK.LACK_ID, sizeof(CWIPCELMGZ.CMF_3));
        memcpy(CWIPCELMGZ.CREATE_TIME, s_sys_time, sizeof(CWIPCELMGZ.CREATE_TIME));
        CDB_insert_cwipcelmgz(&CWIPCELMGZ);
        if (DB_error_code != DB_SUCCESS)
        {
            //DO NOTHING
            LOG_head("CWIP_Packing_Halfcell_CDB_insert_cwipcelmgz");
			LOG_add("FILE", MP_NSTR, __FILE__);
			LOG_add("LINE", MP_INT, __LINE__);
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
        }
		//자재 추적성(2024.02.23) End
		/****************************************************************************/
		////LOT CREATION (Half Cell 생성) 
		/****************************************************************************/
		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');

		//LOT_ID 는 임시생성.
		TRS.add_string(tran_in_node, "LOT_ID", s_to_lot_number, sizeof(s_to_lot_number));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPORDSTS.MAT_ID, sizeof(MWIPORDSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", 1);
		TRS.add_string(tran_in_node, "FLOW", MWIPMATDEF.FIRST_FLOW, sizeof(MWIPMATDEF.FIRST_FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", 1); 
		TRS.add_string(tran_in_node, "OPER", HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		TRS.add_char(tran_in_node, "LOT_TYPE", 'P');   
		TRS.add_string(tran_in_node, "CREATE_CODE", HQCEL_LOT_CREATECODE_HCELBX, strlen(HQCEL_LOT_CREATECODE_HCELBX));
		TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
		TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
		
		TRS.add_double(tran_in_node, "QTY_1", icellqty);   

		TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		
		memset(s_due_time, ' ' , sizeof(s_due_time));
		COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

		TRS.add_string(tran_in_node, "DUE_TIME",s_due_time, sizeof(s_due_time));
		TRS.set_string(tran_in_node, "COLOR_CLASS", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
		TRS.set_string(tran_in_node, "LOC_ID", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
		TRS.set_string(tran_in_node, "LINE_ID", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		TRS.set_string(tran_in_node, "LOT_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));

		//CARRIER ID
		TRS.add_nstring(tran_in_node, "CRR_ID", TRS.get_string(list[i],"PACK_ID"));

		if(WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		TRS.init_node(tran_in_node);
		TRS.init_node(tran_out_node);

		if (c_combine_flag == 'Y')
		{

			//1. fcell 의 1/2 combine
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS_FCELL.LOT_ID, sizeof(MWIPLOTSTS_FCELL.LOT_ID));
			
			TRS.add_string(tran_in_node, "INTO_LOT_ID", s_to_lot_number, sizeof(s_to_lot_number));

			/* 설비에서 수량을 주면 해당수량으로 사용 */
			
			if (MWIPLOTSTS_FCELL.QTY_1 <= (icellqty/2))
			{
				//기준수량 보다 작으면 LOT 수량 전체
				TRS.add_double(tran_in_node, "MOVE_QTY_1", (double)MWIPLOTSTS_FCELL.QTY_1);
			}
			else
			{
				//기준 수량 만큼만 Combine
				TRS.add_double(tran_in_node, "MOVE_QTY_1", (double)(icellqty/2));
			}

			if(WIP_COMBINE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				/*TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;*/
				LOG_head("WIP_COMBINE_LOT_Error");
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}
		}
		
		/***************************************************/
		//END LOT
		/***************************************************/
		TRS.init_node(tran_in_node);
		TRS.init_node(tran_out_node);

		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.LOT_ID, s_to_lot_number, sizeof(s_to_lot_number));
		
		DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING : ERROR 가 나면안됨
		}
		
		//LOT_GROUP_ID_2 HALFCELL 대차 UPDATE
		memset(MWIPLOTSTS.LOT_GROUP_ID_2, ' ', sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
		memcpy(MWIPLOTSTS.LOT_GROUP_ID_2, CWIPCELPAK.LACK_ID, sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
		DBC_update_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING : ERROR 가 나면안됨
			LOG_head("CWIP_Packing_Half_update_mwiplotsts");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		}

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
		TRS.add_string(tran_in_node, "FLOW",MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM); 
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	
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

		if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
		{
			//설비ID 가 없을경우 처리
			TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS_FCELL.START_RES_ID, sizeof(MWIPLOTSTS_FCELL.START_RES_ID));
			if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
			{
				//코어에서 에러처리 맞김.
			}

		}

		//RES_ID(EQUIPMENT ID)
		res_list = TRS.add_node(tran_in_node, "RES_LIST");
		TRS.add_nstring(res_list, "RES_ID", TRS.get_string(tran_in_node, "RES_ID"));
		

		//User Routine End 에서 ERP I/F 호출안하도록 'Y' 로 셋팅
		TRS.set_char(tran_in_node, "_SKIP_ERP_IF", 'Y'); 
		if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		//Cleaving Half Cell Confirm ERP Interface 수행
		TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '2'); 		
		TRS.set_int(tran_in_node, "MAGAZINE_O_QTY", TRS.get_int (in_node, "MAGAZINE_O_QTY")); //
		if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		//IS-21-10-017 Half Cell 실제 수량 저장 되도록(Lot 생성 성공시 데이터 저장)
		
		CDB_init_cwiphafhis(&CWIPHAFHIS);
		memcpy(CWIPHAFHIS.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		memcpy(CWIPHAFHIS.LOT_ID, s_to_lot_number, sizeof(s_to_lot_number));

		CWIPHAFHIS.QTY_1 = TRS.get_int (in_node, "MAGAZINE_O_QTY");
		
	    if(COM_isnullspace(TRS.get_string(in_node, "MAGAZINE_ID")) == MP_FALSE)
		{
			TRS.copy(CWIPHAFHIS.MAGAZINE_ID, sizeof(CWIPHAFHIS.MAGAZINE_ID), in_node, "MAGAZINE_ID");
		}
		if(COM_isnullspace(TRS.get_string(in_node, "VMAGAZINE_ID")) == MP_FALSE)
		{
			TRS.copy(CWIPHAFHIS.VMAGAZINE_ID, sizeof(CWIPHAFHIS.VMAGAZINE_ID), in_node, "VMAGAZINE_ID");
		}

		memcpy(CWIPHAFHIS.CREATE_TIME,s_sys_time, sizeof(s_sys_time));
		CDB_insert_cwiphafhis(&CWIPHAFHIS);
		
		if(DB_error_code != DB_SUCCESS)  //에러 나더라도 넘어가도록 
        {
		
		}

		//IS-21-10-017 Half Cell 실제 수량 저장 되도록

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		//Tabber이동 정보 I/F
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.LOT_ID, s_to_lot_number, sizeof(s_to_lot_number));

		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING : ERROR 가 나면안됨
		}

		if(memcmp(MWIPLOTSTS.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER) ) == 0)
		{
			start_time = STOPWATCH_START();
			tran_in_node = TRS.create_node("MOVE_LOT_IN");
			tran_out_node = TRS.create_node("CMN_OUT");

			// IN_NODE FOR WIP_MOVE_LOT
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.set_char(tran_in_node, "PROCSTEP", '1');
			TRS.set_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.set_string(tran_in_node, "TRAN_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
			TRS.set_string(tran_in_node, "TRAN_CMF_2", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
			TRS.set_string(tran_in_node, "MAIN_ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
			TRS.set_nstring(tran_in_node, "MAGAZINE_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
			TRS.set_char(tran_in_node, "CLEAVING_END_FLAG", 'Y');
			TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '3'); 

			if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			STOPWATCH_END("CLEAVING_END_UPLOAD_ERP_I_ELAPSED_TIME", start_time);

		}

	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

/*******************************************************************************
    CWIP_PACKING_HALFCELL_BOX()
        - SOI->MES Packing HalfCell
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_PACKING_HALFCELL_BOX(char *s_msg_code,
							TRSNode *in_node, 
							TRSNode *out_node)
{
	// INIT
	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF_HCELL;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CINVCELRCV_TAG CINVCELRCV;
	//struct CWIPCELMGZ_TAG CWIPCELMGZ;

	char s_sys_time[14];
	char s_due_time[14];

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	TRSNode** list ;
	int i;

	// PROCESS LOG PRINT
	LOG_head("CWIP_PACKING_HALFCELL_BOX");
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

	//ORDER SELECT
	DBC_init_mwipordsts(&MWIPORDSTS);
	TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, "FACTORY");
	TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
	DBC_select_mwipordsts(1, &MWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "ORD-0002");
        TRS.set_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//ORDER TYPE (CMF_5 == 'HM03' 이면 ERP INTERFACE 안함)


	//PRODUCT SELECT (Module )
	DBC_init_mwipmatdef(&MWIPMATDEF);
	memcpy(MWIPMATDEF.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
	memcpy(MWIPMATDEF.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	MWIPMATDEF.MAT_VER = 1;
	DBC_select_mwipmatdef(1, &MWIPMATDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "WIP-0006");
        TRS.set_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	// INSERT CWIPCELPAK
	list = TRS.get_list(in_node, "HALFCELL_PACK_LIST");

	for (i = 0; i < TRS.get_item_count(in_node, "HALFCELL_PACK_LIST"); i++)
	{

		/* CELL RECEIVE 정보 GET */
		CDB_init_cinvcelrcv(&CINVCELRCV);
		memcpy(CINVCELRCV.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		//memcpy(CINVCELRCV.INV_LOT_ID, TRS.get_string(list[i],"CELL_BOX_ID"), sizeof(CWIPCELPAK.CELL_BOX_ID));
		TRS.copy(CINVCELRCV.INV_LOT_ID, sizeof(CINVCELRCV.INV_LOT_ID), list[i], "CELL_BOX_ID"); //Server Crash
		CDB_select_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
		{
			// CELL RECEVICE 정보가 없을경우 강제로 진행하기 위해 품번정보 하고 셋팅함.
			// 향후 옵션으로 처리하든 , BOM 으로 체크하던 (CWIPORDBOM 에서 CELL 품번을 가지고 와서 기본수량으로 처리)
			// 그것도 아니면 에러처리하던 해야함.
			memcpy(CINVCELRCV.MATERIALDEFINITIONID, "000006581260411126", strlen("000006581260411126"));
			memcpy(CINVCELRCV.ORI_QTY, "300", strlen("300"));
		}

		//PRODUCT SELECT (HALF CELL )
		DBC_init_mwipmatdef(&MWIPMATDEF_HCELL);
		memcpy(MWIPMATDEF_HCELL.FACTORY, CINVCELRCV.FACTORY, sizeof(MWIPMATDEF_HCELL.FACTORY));
		memcpy(MWIPMATDEF_HCELL.MAT_ID, CINVCELRCV.MATERIALDEFINITIONID, sizeof(MWIPMATDEF_HCELL.MAT_ID));
		MWIPMATDEF_HCELL.MAT_VER = 1;
		DBC_select_mwipmatdef(1, &MWIPMATDEF_HCELL);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0006");
			TRS.set_fieldmsg(out_node, "MWIPMATDEF_FCELL SELECT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// HALF Cell MAT-FLOW 등록 체크
		if(COM_isnullspace(MWIPMATDEF_HCELL.FIRST_FLOW) == MP_TRUE)
		{
			strcpy(s_msg_code, "WIP-0597");
			TRS.add_fieldmsg(out_node, "MWIPMATDEF_HCELL.MAT_ID", MP_STR, sizeof(MWIPMATDEF_HCELL.MAT_ID), MWIPMATDEF_HCELL.MAT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CDB_init_cwipcelpak(&CWIPCELPAK);

		memcpy(CWIPCELPAK.FACTORY, MWIPMATDEF_HCELL.FACTORY , sizeof(MWIPMATDEF_HCELL.FACTORY));
		//memcpy(CWIPCELPAK.PACK_ID, TRS.get_string(list[i],"PACK_ID"), sizeof(CWIPCELPAK.PACK_ID));
		//memcpy(CWIPCELPAK.CELL_BOX_ID, TRS.get_string(list[i],"CELL_BOX_ID"), sizeof(CWIPCELPAK.CELL_BOX_ID));
		TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), list[i], "PACK_ID"); //Server Crash 20200906
		TRS.copy(CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID), list[i], "CELL_BOX_ID"); //Server Crash 20200906
		
		CDB_select_cwipcelpak(1, &CWIPCELPAK);
		if(DB_error_code == DB_SUCCESS)
		{
			//삭제하고 다시 넣음
			//CMF_3 이 EMI PARTITON KEY 이므로 변경되면 안됨.
			CDB_delete_cwipcelpak(1, &CWIPCELPAK);
		}
		else
		{
			memcpy(CWIPCELPAK.CMF_3, s_sys_time, 14);
		}
		CWIPCELPAK.PACK_TYPE = 'F';
		memcpy(CWIPCELPAK.MAT_ID, MWIPMATDEF_HCELL.MAT_ID, sizeof(MWIPMATDEF_HCELL.MAT_ID));
		//memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[i],"LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
		TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), list[i], "LACK_ID"); //Server Crash 20200906
		

		memcpy(CWIPCELPAK.OPER, HQCEL_M1_FCELL_MOVE_OPER, strlen(HQCEL_M1_FCELL_MOVE_OPER));
		memcpy(CWIPCELPAK.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		
		CWIPCELPAK.PACK_QTY = TRS.get_int(list[i],"PACK_QTY");
		memcpy(CWIPCELPAK.FLOW, MWIPMATDEF_HCELL.FIRST_FLOW, sizeof(MWIPMATDEF_HCELL.FIRST_FLOW));
		
		//CWIPCELPAK의 BATCH NO (MES ) 는 같이 묶인 MAGAZINE ID 로함
		memcpy(CWIPCELPAK.BATCHNO, CWIPCELPAK.PACK_ID, sizeof(CINVCELRCV.BATCHNO));

		//memcpy(CWIPCELPAK.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CINVCELRCV.UNIT_ID)); // Server Crash 190925
		memcpy(CWIPCELPAK.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CWIPCELPAK.UNIT_ID)); 

		memcpy(CWIPCELPAK.RCV_CELLBOX_ID, CINVCELRCV.SMALLBOXID, sizeof(CINVCELRCV.SMALLBOXID));

		memcpy(CWIPCELPAK.LARGEBOXID, CINVCELRCV.LARGEBOXID, sizeof( CINVCELRCV.LARGEBOXID));
		memcpy(CWIPCELPAK.CELLTYPE,  CINVCELRCV.CELLTYPE, sizeof(CWIPCELPAK.CELLTYPE));

		memcpy(CWIPCELPAK.CELLPRODUCTDATE, CINVCELRCV.CELLPRODUCTDATE, sizeof(CINVCELRCV.CELLPRODUCTDATE));
		memcpy(CWIPCELPAK.CELLGRADE, CINVCELRCV.CELLGRADE, sizeof(CINVCELRCV.CELLGRADE));

		memcpy(CWIPCELPAK.CELLBOXBARCODE, CINVCELRCV.CELLBOXBARCODE, sizeof(CINVCELRCV.CELLBOXBARCODE));
		CWIPCELPAK.INSPECT_STATUS =CINVCELRCV.INSPECT_STATUS;
		CWIPCELPAK.BLOCK_STATUS = CINVCELRCV.BLOCK_STATUS;
		memcpy(CWIPCELPAK.BLOCK_DATE, CINVCELRCV.BLOCK_DATE, sizeof(CINVCELRCV.BLOCK_DATE));
		memcpy(CWIPCELPAK.POWERGRADE, CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE));
		memcpy(CWIPCELPAK.QUALITYGRADE, CINVCELRCV.QUALITYGRADE, sizeof(CINVCELRCV.QUALITYGRADE));
		
		CWIPCELPAK.AVG_NCELL = CINVCELRCV.AVG_NCELL;
		CWIPCELPAK.AVG_ISC = CINVCELRCV.AVG_ISC;
		CWIPCELPAK.AVG_UOC = CINVCELRCV.AVG_UOC;
		CWIPCELPAK.AVG_FF = CINVCELRCV.AVG_FF;
		CWIPCELPAK.AVG_RS = CINVCELRCV.AVG_RS;
		CWIPCELPAK.AVG_RSH = CINVCELRCV.AVG_RSH;
		CWIPCELPAK.AVG_TEMPERATURE = CINVCELRCV.AVG_TEMPERATURE;
		CWIPCELPAK.AVG_NCELL = CINVCELRCV.AVG_NCELL;
		memcpy(CWIPCELPAK.PRODUCTCLASSID, CINVCELRCV.PRODUCTCLASSID, sizeof(CINVCELRCV.PRODUCTCLASSID));
		memcpy(CWIPCELPAK.PRODUCTDEFINITIONTYPE, CINVCELRCV.PRODUCTDEFINITIONTYPE, sizeof(CINVCELRCV.PRODUCTDEFINITIONTYPE));
		memcpy(CWIPCELPAK.GR_BATCHNO,  CINVCELRCV.GR_BATCHNO, sizeof(CINVCELRCV.GR_BATCHNO));
		memcpy(CWIPCELPAK.GR_DATE, CINVCELRCV.GR_DATE, sizeof(CINVCELRCV.GR_DATE));
		memcpy(CWIPCELPAK.GI_BATCH_NO, CINVCELRCV.GR_DATE, sizeof(CINVCELRCV.GR_DATE));
		CWIPCELPAK.STATUS_FLAG = 'I';

		CDB_insert_cwipcelpak(&CWIPCELPAK);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		// 자재 추적성(2023.12.02)
  //      CDB_init_cwipcelmgz(&CWIPCELMGZ);
  //      memcpy(CWIPCELMGZ.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPCELMGZ.FACTORY));
		//memcpy(CWIPCELMGZ.CELL_BOX_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELMGZ.CELL_BOX_ID));
		//CDB_select_cwipcelmgz(3, &CWIPCELMGZ);

		//memcpy(CWIPCELMGZ.PACK_ID, CWIPCELPAK.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID));
		//CWIPCELMGZ.PACK_TYPE = 'H';
		//memcpy(CWIPCELMGZ.CREATE_TIME, s_sys_time, sizeof(CWIPCELMGZ.CREATE_TIME));
		//CDB_insert_cwipcelmgz(&CWIPCELMGZ);
		//if (DB_error_code != DB_SUCCESS)
		//{
		//	LOG_head("CWIP_Packing_Halfcell_BOX_CDB_insert_cwipcelmgz");
		//	LOG_add("FILE", MP_NSTR, __FILE__);
		//	LOG_add("LINE", MP_INT, __LINE__);
		//	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		//}

		/****************************************************************************/
		////LOT CREATION (작업지시 기준 Small Box Lot 생성) 
		/****************************************************************************/
		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(list[i], "CELL_BOX_ID"));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPMATDEF_HCELL.MAT_ID, sizeof(MWIPMATDEF_HCELL.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", 1);
		TRS.add_string(tran_in_node, "FLOW", MWIPMATDEF_HCELL.FIRST_FLOW, sizeof(MWIPMATDEF_HCELL.FIRST_FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", 1); 
		TRS.add_string(tran_in_node, "OPER", HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER));
		TRS.add_char(tran_in_node, "LOT_TYPE", 'P');   
		TRS.add_string(tran_in_node, "CREATE_CODE",HQCEL_LOT_CREATECODE_HCELBX, strlen(HQCEL_LOT_CREATECODE_HCELBX));
		TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
		TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
		TRS.add_double(tran_in_node, "QTY_1", COM_atol(CINVCELRCV.ORI_QTY, sizeof(CINVCELRCV.ORI_QTY)));   
		TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		
		memset(s_due_time, ' ' , sizeof(s_due_time));
		COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

		TRS.add_string(tran_in_node, "DUE_TIME",s_due_time, sizeof(s_due_time));
		TRS.set_string(tran_in_node, "COLOR_CLASS", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
		TRS.set_string(tran_in_node, "LOC_ID", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
		TRS.set_string(tran_in_node, "LINE_ID", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		TRS.set_string(tran_in_node, "LOT_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		//CARRIER ID
		TRS.add_nstring(tran_in_node, "CRR_ID", TRS.get_string(list[i],"PACK_ID"));
		if(WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		CDB_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		//memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(list[i],"CELL_BOX_ID"), sizeof(MWIPLOTSTS.LOT_ID));
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), list[i], "CELL_BOX_ID"); //Server Crash 20200906
		CDB_select_mwiplotsts(1, &MWIPLOTSTS);

		//LOT_GROUP_ID_2 HALFCELL 대차 UPDATE
		memset(MWIPLOTSTS.LOT_GROUP_ID_2, ' ', sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
		memcpy(MWIPLOTSTS.LOT_GROUP_ID_2, CWIPCELPAK.LACK_ID, sizeof(MWIPLOTSTS.LOT_GROUP_ID_2));
		DBC_update_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING : ERROR 가 나면안됨
		}

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}