/********************************************************************************
System      : MESplus
Module      : CUS
File Name   : CINF_upload_erp_function.c
Description : ERP Upload Interface Common Function

MES Version : 5.3.x

Function List

Detail Description
// CUSTOM COMMON FUNCTION

History
Seq   Date        Developer      Description
---------------------------------------------------------------------------
	1     2018/12/26  Juhyeon.Jung       Creation Data
	2	  2023/02/20  JD.Park			 Upadate Data
Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include "WIPCore_common.h"

int CWIP_OPER_CONFIRM_DATA_TEST(char*, TRSNode* in_node, TRSNode* out_node);
int CWIP_CLEAVING_CONFIRM_DATA_TEST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
/*******************************************************************************
	CWIP_upload_erp_function_testdata_creation()
		- MES -> ERP TEST Data 생성서비스
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_upload_erp_function_testdata_creation(TRSNode* in_node, TRSNode* out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret = MP_TRUE;

	//0. operation confirm data test creation
	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_OPER_CONFIRM_DATA_TEST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_upload_erp_function_testdata_creation_0", out_node);

	if (i_ret == MP_TRUE)
	{
		if (gb_multi_transaction == MP_FALSE)
		{
			DB_commit();
		}
	}
	else
	{
		DB_rollback();
	}

	//1. cleaving confirm data test creation
	/*memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_CLEAVING_CONFIRM_DATA_TEST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_upload_erp_function_testdata_creation_1", out_node);

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
	}*/


	return MP_TRUE;
}

/*******************************************************************************
	CINF_UPLOAD_ERP_FUNCTION()
		- MES->ERP UPLOAD FUNCTION
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
			NAME : INF_UPLOAD_TYPE_FLAG
					'1' : CLEAVING FCELL MOVE
					'2' : CLEAVING HCELL CONFIRM / GR
					'3' : CLEAVING HCELL MOVE
					'4' : OPERATION CONFIRM
					'5' : FQC CONFIRM
					'6' : PACKING DATA
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CINF_UPLOAD_ERP_FUNCTION(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{

	char c_inf_type_flag = ' ';
	int i_inscase = 1;
	char c_action_type = ' ';
	int b_cancel = MP_FALSE;
	double d_value = 0;

	int ihisChk = 0;
	int j = 0;
	int k = 0;

	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;

	struct IERPFCLMOV_TAG IERPFCLMOV;
	struct IERPHCLMOV_TAG IERPHCLMOV;
	struct IERPCLVCFM_TAG IERPCLVCFM;
	struct IERPOPRCFM_TAG IERPOPRCFM;
	struct IQCMFSHDAT_TAG IQCMFSHDAT; //[GERP PROJECT] 추가

	struct IERPPAKDAT_TAG IERPPAKDAT;

	struct CWIPORDRTE_TAG CWIPORDRTE;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPLOTPAK_TAG CWIPLOTPAK_CNT;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPCALDEF_TAG MWIPCALDEF;
	struct IBAKOPRCFM_TAG IBAKOPRCFM;

	struct worktime_tag cur_work_time;
	struct worktime_tag fqc_work_time;
	char s_sys_time[14];
	//char s_sys_date[8];

	struct CINVCELRCV_TAG CINVCELRCV;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	//struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct IBAKTERINF_TAG IBAKTERINF;
	struct IERPWIPCFM_TAG IERPWIPCFM;//[GERP PROJECT] 추가
	struct MGCMLAGDAT_TAG MGCMLAGDAT;//[GERP PROJECT] 추가
	struct CWIPRWKDAT_TAG CWIPRWKDAT;//[GERP PROJECT] [ERP 23.05.23] 추가
	struct MWIPMATDEF_TAG MWIPMATDEF;//[GERP PROJECT] [ERP 23.06.14] 추가 

	struct IERPOPRCFM_TAG IERPOPRCFM_LST; //Added 2025.12.19 BC KANG

	// *ERP UPLOAD FLAG
	// *DEFAULT : R - > .실시간 처리
	// *          M - > .문제여지 있음 
	//			  H - > .ERP 의 HM03 TYPE 으로 UPLOAD 하면 안되는 데이터임.
	char c_upload_flag;

	//c_upload_flag = 'R'; //기본적으로 실시간으로 올림.
	c_upload_flag = 'R'; //ERP I/F 당분간 매뉴얼로 UPLOAD , 데이터 확인후 'R' 로 올림.


	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);

	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	//GET Interface Type Flag
	c_inf_type_flag = TRS.get_char(in_node, "INF_UPLOAD_TYPE_FLAG");
	if ((c_inf_type_flag == ' ') || (c_inf_type_flag == '\0'))
	{
		return MP_TRUE;
	}

	if (COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_FALSE)
	{
		//WORKING DATE
		memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_erp_time(TRS.get_string(in_node, "BACK_TIME"), &cur_work_time);
		//FQC DATE 
		memset(&fqc_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_erp_time(TRS.get_string(in_node, "BACK_TIME"), &fqc_work_time);
	}
	else
	{
		//WORKING DATE
		memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_erp_time(s_sys_time, &cur_work_time);
		//FQC DATE
		memset(&fqc_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_erp_time(s_sys_time, &fqc_work_time);
	}



	/* WORK CALENDAR : 해당 SHIFT 의 조를 등록함. */
	DBC_init_mwipcaldef(&MWIPCALDEF);
	memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //해당 칼렌다로 변경필요.
	MWIPCALDEF.CALENDAR_TYPE = 'F';
	MWIPCALDEF.SYS_YEAR = cur_work_time.work_year;
	MWIPCALDEF.SYS_MONTH = cur_work_time.work_month;
	MWIPCALDEF.SYS_DAY = COM_atoi(cur_work_time.work_date + 6, 2);
	DBC_select_mwipcaldef(1, &MWIPCALDEF);
	if (DB_error_code != DB_SUCCESS)
	{
		//DO NOTHGIN
	}

	if (COM_isspace(MWIPCALDEF.CAL_CMF_1, sizeof(MWIPCALDEF.CAL_CMF_1)) == MP_TRUE)
		MWIPCALDEF.CAL_CMF_1[0] = 'A';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_2, sizeof(MWIPCALDEF.CAL_CMF_2)) == MP_TRUE)
		MWIPCALDEF.CAL_CMF_2[0] = 'B';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_3, sizeof(MWIPCALDEF.CAL_CMF_3)) == MP_TRUE)
		MWIPCALDEF.CAL_CMF_3[0] = 'C';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_4, sizeof(MWIPCALDEF.CAL_CMF_4)) == MP_TRUE)
		MWIPCALDEF.CAL_CMF_4[0] = 'D';

	//20190713 HCH KIM  : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	TRS.copy(CEDCLOTRLT.FACTORY, sizeof(MWIPLOTHIS.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTRLT.INS_TYPE, "ET", strlen("ET"));
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);
	if (DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING            
	}

	/******************************************************/
	// 1 : CLEAVING Full Cell Move Interface (PP112)
	/******************************************************/
	if (c_inf_type_flag == '1')
	{
		b_cancel = TRS.get_boolean(in_node, "CANCEL");
		if (b_cancel)
		{
			c_upload_flag = 'R';

			CDB_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.LOT_ID), in_node, "FACTORY");
			TRS.copy(MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "ORDER_ID");
			TRS.copy(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "MAT_ID");
			MWIPLOTSTS.QTY_1 = TRS.get_int(in_node, "QTY_1");
			CDB_select_mwiplotsts(2, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}

			// ORDER GET
			DBC_init_mwipordsts(&MWIPORDSTS);
			memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			DBC_select_mwipordsts(1, &MWIPORDSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
				c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
			}
			else
			{
				if (memcmp(MWIPORDSTS.ORD_CMF_4, "HM03", 4) == 0)
				{
					//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
					c_upload_flag = 'H';
				}
			}


			// IERPFCLMOV 컬럼값 넣어주기 
			CDB_init_ierpfclmov(&IERPFCLMOV);
			memcpy(IERPFCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPFCLMOV.DOC_ID));
			IERPFCLMOV.ACTION_TYPE[0] = 'D';
			memcpy(IERPFCLMOV.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(IERPFCLMOV.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2)); //[GERP PROJECT 추가] SITE ID 포맷양식변경
			memcpy(IERPFCLMOV.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

			//BATCH NO : CEINVCELRCV BATCHNO 
			CDB_init_cinvcelrcv(&CINVCELRCV);
			memcpy(CINVCELRCV.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CINVCELRCV.INV_LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_cinvcelrcv(1, &CINVCELRCV);
			if (DB_error_code != DB_SUCCESS)
			{
				//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
				c_upload_flag = 'M';
			}

			memcpy(IERPFCLMOV.BATCH_NO, CINVCELRCV.GR_BATCHNO, sizeof(CINVCELRCV.GR_BATCHNO));
			if (COM_isspace(IERPFCLMOV.BATCH_NO, sizeof(IERPFCLMOV.BATCH_NO)) == MP_TRUE)
			{
				c_upload_flag = 'M';
			}

			memcpy(IERPFCLMOV.FR_LOC_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2)); //[GERP PROJECT 추가] SITE ID 포맷양식변경
			memcpy(IERPFCLMOV.TO_LOC_ID, HQCEL_FCEL_TO_LOC_ID_V2, strlen(HQCEL_FCEL_TO_LOC_ID_V2)); //[GERP PROJECT 추가] LOC 포맷양식변경
			IERPFCLMOV.QTY = MWIPLOTSTS.QTY_1;
			memcpy(IERPFCLMOV.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CINVCELRCV.UNIT_ID));


			memcpy(IERPFCLMOV.POST_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

			TRS.copy(IERPFCLMOV.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

			memcpy(IERPFCLMOV.INF_TIME, s_sys_time, sizeof(s_sys_time));
			IERPFCLMOV.DATA_FLAG = 'D';
			// IERPFCLMOV 컬럼값 넣어주기
			
			//2025.02.05 풀셀 부하로 우선 M으로 처리
			//c_upload_flag = 'M';
			//2025.02.05 풀셀 부하로 우선 M으로 처리
			IERPFCLMOV.ZPISTAT = c_upload_flag;

			memcpy(IERPFCLMOV.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			IERPFCLMOV.QTY = MWIPLOTSTS.QTY_1;
			//DOC_ID 생성
			CDB_select_ierpfclmov(4, &IERPFCLMOV);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					if (DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}
			}

			//Interface Check
			d_value = CDB_select_ierpfclmov_scalar(3, &IERPFCLMOV);

			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0598");
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					return MP_FALSE;
				}
			}
			else
			{
				if (d_value == 1)
				{
					CDB_insert_ierpfclmov(&IERPFCLMOV); //2025.02.05 풀셀 부하로 우선 M으로 처리

					if (DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}
				else
				{
					strcpy(s_msg_code, "556");
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					return MP_FALSE;
				}
			}

		}
		else
		{
			c_upload_flag = 'R';

			CDB_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
			CDB_select_mwiplotsts(2, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}

			// ORDER GET
			DBC_init_mwipordsts(&MWIPORDSTS);
			memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			DBC_select_mwipordsts(1, &MWIPORDSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
				c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
			}
			else
			{
				if (memcmp(MWIPORDSTS.ORD_CMF_4, "HM03", 4) == 0)
				{
					//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
					c_upload_flag = 'H';
				}
			}


			// IERPFCLMOV 컬럼값 넣어주기 
			CDB_init_ierpfclmov(&IERPFCLMOV);
			memcpy(IERPFCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPFCLMOV.DOC_ID));
			IERPFCLMOV.ACTION_TYPE[0] = 'I';
			memcpy(IERPFCLMOV.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(IERPFCLMOV.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));  //[GERP PROJECT 추가] SITE ID 포맷양식변경
			memcpy(IERPFCLMOV.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

			//BATCH NO : CEINVCELRCV BATCHNO 
			CDB_init_cinvcelrcv(&CINVCELRCV);
			memcpy(CINVCELRCV.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CINVCELRCV.INV_LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_cinvcelrcv(1, &CINVCELRCV);
			if (DB_error_code != DB_SUCCESS)
			{
				//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
				c_upload_flag = 'M';
			}

			memcpy(IERPFCLMOV.BATCH_NO, CINVCELRCV.GR_BATCHNO, sizeof(CINVCELRCV.GR_BATCHNO));
			if (COM_isspace(IERPFCLMOV.BATCH_NO, sizeof(IERPFCLMOV.BATCH_NO)) == MP_TRUE)
			{
				c_upload_flag = 'M';
			}

			memcpy(IERPFCLMOV.FR_LOC_ID, HQCEL_FCEL_FROM_LOC_ID_V2, strlen(HQCEL_FCEL_FROM_LOC_ID_V2));  //[GERP PROJECT 추가] FROM_LOC 포맷양식변경
			memcpy(IERPFCLMOV.TO_LOC_ID, HQCEL_FCEL_TO_LOC_ID_V2, strlen(HQCEL_FCEL_TO_LOC_ID_V2));		 //[GERP PROJECT 추가] TO_LOC 포맷양식변경
			IERPFCLMOV.QTY = MWIPLOTSTS.QTY_1;
			memcpy(IERPFCLMOV.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CINVCELRCV.UNIT_ID));


			memcpy(IERPFCLMOV.POST_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

			TRS.copy(IERPFCLMOV.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

			memcpy(IERPFCLMOV.INF_TIME, s_sys_time, sizeof(s_sys_time));
			IERPFCLMOV.DATA_FLAG = 'I';
			// IERPFCLMOV 컬럼값 넣어주기
			//2025.02.05 풀셀 부하로 우선 M으로 처리
			//c_upload_flag = 'M';
			//2025.02.05 풀셀 부하로 우선 M으로 처리

			IERPFCLMOV.ZPISTAT = c_upload_flag;

			memcpy(IERPFCLMOV.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));


			//Cell Box Duplicate Check
			CDB_select_ierpfclmov(3, &IERPFCLMOV);
			/*
			WHERE ACTION_TYPE = :IERPFCLMOV_N.ACTION_TYPE
			AND SITE_ID = :IERPFCLMOV_N.SITE_ID
			AND PROD_ORDER_NO = :IERPFCLMOV_N.PROD_ORDER_NO
			AND MATE_NO = :IERPFCLMOV_N.MATE_NO
			AND BATCH_NO = :IERPFCLMOV_N.BATCH_NO
			AND FR_LOC_ID = :IERPFCLMOV_N.FR_LOC_ID
			AND TO_LOC_ID = :IERPFCLMOV_N.TO_LOC_ID
			AND CMF_1 = :IERPFCLMOV_N.CMF_1;
			*/
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					CDB_insert_ierpfclmov(&IERPFCLMOV); //2025.02.05 풀셀 부하로 우선 M으로 처리

					if (DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}
			}
		}
	}

	/******************************************************/
	// 2 : Cleaving 실적 (1: Confirmation, 2: Goods Receipts) 한쌍 올려준다. [PP-111]
	/******************************************************/
	if (c_inf_type_flag == '2')
	{
		//Zero values are not processed.
		if (0 == TRS.get_int(in_node, "MAGAZINE_O_QTY"))
			return MP_TRUE;

		c_upload_flag = 'R';

		CDB_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		CDB_select_mwiplotsts(2, &MWIPLOTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		// ORDER GET
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));

		if (COM_isnullspace(TRS.get_string(in_node, "MAIN_ORDER_ID")) == MP_FALSE)
			TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "MAIN_ORDER_ID");
		else
			memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		}
		else
		{
			if (memcmp(MWIPORDSTS.ORD_CMF_4, "HM03", 4) == 0)
			{
				//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				c_upload_flag = 'H';
			}
		}

		CDB_init_ierpclvcfm(&IERPCLVCFM);
		memcpy(IERPCLVCFM.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPCLVCFM.DOC_ID));
		memcpy(IERPCLVCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));	//[GERP PROJECT 추가] SITE ID 포맷양식변경
		memcpy(IERPCLVCFM.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		memcpy(IERPCLVCFM.OPER_NO, "0010", strlen("0010")); //UPDATE 필요
		memcpy(IERPCLVCFM.WORK_CENTER, "H100", strlen("H100")); 								// [GERP PROJECT 추가] C10 -> H100 으로 Work Center변경
		IERPCLVCFM.ACTION_TYPE[0] = '1';
		memcpy(IERPCLVCFM.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		//IERPCLVCFM.PROD_QTY = MWIPLOTSTS.QTY_1;
		IERPCLVCFM.PROD_QTY = TRS.get_int(in_node, "MAGAZINE_O_QTY");//
		IERPCLVCFM.SCRAP_QTY = 0;
		memcpy(IERPCLVCFM.UNIT_ID, "PCS", strlen("PCS"));										// [GERP PROJECT 추가] PC -> PCS 포맷양식변경
		memcpy(IERPCLVCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		//memcpy(IERPCLVCFM.FQC_DATE, "20181231", 8);

		if (cur_work_time.work_shift == 1)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		TRS.copy(IERPCLVCFM.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);
		memcpy(IERPCLVCFM.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

		memcpy(IERPCLVCFM.INF_TIME, s_sys_time, sizeof(s_sys_time));
		IERPCLVCFM.DATA_FLAG = 'I';
		// IERPFCLMOV 컬럼값 넣어주기

		IERPCLVCFM.ZPISTAT = c_upload_flag;

		CDB_insert_ierpclvcfm(&IERPCLVCFM);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}

		//GR DATE INSERT 
		while (1)
		{
			//doc id 중복방지
			CDB_select_mwiplotsts(2, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}
			if (memcmp(IERPOPRCFM.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID)) != 0)
			{
				break;
			}
		}

		memset(IERPCLVCFM.DOC_ID, ' ', sizeof(IERPCLVCFM.DOC_ID));
		memcpy(IERPCLVCFM.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPCLVCFM.DOC_ID));
		IERPCLVCFM.ACTION_TYPE[0] = '2';
		CDB_insert_ierpclvcfm(&IERPCLVCFM);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}
	}


	/******************************************************/
	// 3 : Half-Cell 이동정보를 ERP로 올려준다. [PP-113]
	/******************************************************/
	if (c_inf_type_flag == '3')
	{
		if (TRS.get_procstep(in_node) == '1') //INSERT
		{
			c_upload_flag = 'R';

			CDB_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
			CDB_select_mwiplotsts(2, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}
			// ORDER GET
			DBC_init_mwipordsts(&MWIPORDSTS);
			memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));

			if (COM_isnullspace(TRS.get_string(in_node, "MAIN_ORDER_ID")) == MP_FALSE)
				TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "MAIN_ORDER_ID");
			else
				memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

			DBC_select_mwipordsts(1, &MWIPORDSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
				c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
			}
			else
			{
				if (memcmp(MWIPORDSTS.ORD_CMF_4, "HM03", 4) == 0)
				{
					//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
					c_upload_flag = 'H';
				}
			}

			if (TRS.get_char(in_node, "CLEAVING_END_FLAG") == 'Y') c_upload_flag = ' ';

			CDB_init_ierphclmov(&IERPHCLMOV);
			//memcpy(IERPHCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(MWIPLOTSTS.LOT_DESC));  // Server Crash 190925
			memcpy(IERPHCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPHCLMOV.DOC_ID));
			IERPHCLMOV.ACTION_TYPE[0] = 'I';
			memcpy(IERPHCLMOV.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));	// [GERP PROJECT 추가] SITE_ID 포맷양식변경
			memcpy(IERPHCLMOV.PROD_ORDER_NO, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID)); //MAIN 의 ORDER..
			memcpy(IERPHCLMOV.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

			memcpy(IERPHCLMOV.FR_LOC_ID, HQCEL_HCEL_FROM_LOC_ID_V2, strlen(HQCEL_HCEL_FROM_LOC_ID_V2));	// [GERP PROJECT 추가] FROM_LOC 포맷양식변경
			memcpy(IERPHCLMOV.TO_LOC_ID, HQCEL_HCEL_TO_LOC_ID_V2, strlen(HQCEL_HCEL_TO_LOC_ID_V2));		// [GERP PROJECT 추가] TO_LOC 포맷양식변경
			IERPHCLMOV.QTY = MWIPLOTSTS.QTY_1;
			memcpy(IERPHCLMOV.UNIT_ID, "PCS", strlen("PCS"));		// [GERP PROJECT 추가] PC->PCS 포맷양식변경

			memcpy(IERPHCLMOV.POST_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

			TRS.copy(IERPHCLMOV.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

			memcpy(IERPHCLMOV.INF_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(IERPHCLMOV.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.copy(IERPHCLMOV.INF_PROC_TIME, sizeof(IERPFCLMOV.INF_PROC_TIME), in_node, "MAGAZINE_ID");//Tabber Start시 Update Key로 사용

			IERPHCLMOV.DATA_FLAG = 'I';
			IERPHCLMOV.ZPISTAT = c_upload_flag;
			CDB_insert_ierphclmov(&IERPHCLMOV);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
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
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				return MP_FALSE;
			}
		}
		else if (TRS.get_procstep(in_node) == '2')//UPDATE
		{
			CDB_init_ierphclmov(&IERPHCLMOV);
			TRS.copy(IERPHCLMOV.INF_PROC_TIME, sizeof(IERPHCLMOV.INF_PROC_TIME), in_node, "MAGAZINE_ID");
			TRS.copy(IERPHCLMOV.CMF_1, sizeof(IERPHCLMOV.CMF_1), in_node, "LOT_ID");

			TRS.copy(IERPHCLMOV.PROD_ORDER_NO, sizeof(IERPHCLMOV.PROD_ORDER_NO), in_node, "MAIN_ORDER_ID");
			memcpy(IERPHCLMOV.INF_TIME, s_sys_time, sizeof(s_sys_time));
			IERPHCLMOV.ZPISTAT = 'R';

			CDB_update_ierphclmov(3, &IERPHCLMOV);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
				LOG_head("TABBER_MOVE_IF_UPDATE");
				LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
				LOG_add("MAGAZINE_ID", MP_NSTR, TRS.get_string(in_node, "MAGAZINE_ID"));
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}

		}


	}


	/******************************************************/
	// 4 : OPERATION CONFIRM DATA [IF-PP-305]
	//     [GERP PROJECT 추가] Module Serial Number Flash data Receive [IF-QM-002]IQCMFSHDAT 전송
	/******************************************************/
	if (c_inf_type_flag == '4')
	{		
		c_upload_flag = 'R';
		//마지막 수행이력 GET 
		CDB_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
		CDB_select_mwiplothis(2, &MWIPLOTHIS);
		if (DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		if (memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) != 0)
		{
			return MP_TRUE;
		}


		//이전에 같은공정에서 END한 이력이 있으면 이미  실적처리를 했으므로 다시안함.
		//위에서 MWIPLOTHIS 를 SELECT 해왔기떄문에 그냥쓴것임. 다른곳에서 쓸려면 TRAN_CODE, OLD_OPER, HIST SEQ 주의
		if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) > 0)
		{
			return MP_TRUE;
		}


		// ORDER GET
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		}
		else
		{
			if (memcmp(MWIPORDSTS.ORD_CMF_4, "HM03", 4) == 0)
			{
				//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				c_upload_flag = 'H';
			}
		}

		//OPOERATION SELECT
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		memcpy(MWIPOPRDEF.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(MWIPOPRDEF.OPER, MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
		DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			//에러날수 없음.
		}

		//ERP UPLOAD 공정이 아니면 RETURN TURE
		if (MWIPOPRDEF.ERP_FLAG != 'Y')
		{
			return MP_TRUE;
		}

		// 올려야 하는값이 있는지 체크 (ERP OPETION 이 없으면 TRUE)
		if (COM_isspace(MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1)) == MP_TRUE)
		{
			return MP_TRUE;
		}

		/* Skip FQC Prod Result */
		if (memcmp(MWIPOPRDEF.OPER_CMF_1, "0040", 4) == 0)
		{
			return MP_TRUE;
		}

		//ERP WORK CENTER GET
		CDB_init_cwipordrte(&CWIPORDRTE);
		memcpy(CWIPORDRTE.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(CWIPORDRTE.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		//memcpy(CWIPORDRTE.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(CWIPORDRTE.OPER_NO)); // Server Crash 190925
		memcpy(CWIPORDRTE.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));
		CDB_select_cwipordrte(2, &CWIPORDRTE);
		if (DB_error_code != DB_SUCCESS)
		{
			//에러처리 우선안함.
		}


		// IERPOPRCFM 컬럼값 넣어주기 
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		//while(1)
		//{
		//	//DOC ID 중복방지 : CASE 999 IERPOPRCFM.DOC_ID ->MAX_DOC_ID, IERPOPRCFM.CMF_1 ->CURRENT TIME STAMP
		//	CDB_select_ierpoprcfm(999,&IERPOPRCFM);
		//	if (memcmp(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, 21) != 0)
		//		break;

		//	memcpy(MWIPLOTHIS.LOT_DESC, IERPOPRCFM.CMF_1, sizeof(IERPOPRCFM.CMF_1));
		//}

		memcpy(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID));



		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));	// [GERP PROJECT 추가] SITE_ID 포맷양식변경
		memcpy(IERPOPRCFM.PROD_ORDER_NO, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));

		memcpy(IERPOPRCFM.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));

		memcpy(IERPOPRCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(CWIPORDRTE.WORK_CENTER));
		IERPOPRCFM.ACTION_TYPE[0] = 'I';

		memcpy(IERPOPRCFM.MATE_NO, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));
		COM_dtoa(IERPOPRCFM.PROD_QTY, MWIPLOTHIS.QTY_1, sizeof(IERPOPRCFM.PROD_QTY));

		IERPOPRCFM.SCRAP_QTY[0] = '0';
		memcpy(IERPOPRCFM.UNIT_ID, "PCS", strlen("PCS"));	// [GERP PROJECT 추가] PC->PCS 포맷양식변경
		TRS.copy(IERPOPRCFM.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

		//FQC DATE, SHIFT , LOCATION ( ERP TEST 를 위해  임시로 넣음 )
		CDB_init_mwipeltsts(&MWIPELTSTS);
		memcpy(MWIPELTSTS.LOT_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		CDB_select_mwipeltsts(i_inscase, &MWIPELTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}

		/* FQC date is Work date */
		//memcpy(IERPOPRCFM.FQC_DATE, MWIPELTSTS.FQC_TIME, 8);
		memcpy(IERPOPRCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		memset(IERPOPRCFM.SHIFT, ' ', sizeof(IERPOPRCFM.SHIFT));
		if (cur_work_time.work_shift == 1)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		//memcpy(IERPOPRCFM.LOCATION, MWIPELTSTS.LOC_ID, 3);
		memcpy(IERPOPRCFM.LOCATION, MWIPORDSTS.ORD_CMF_6, 3);

		memcpy(IERPOPRCFM.INF_TIME, s_sys_time, sizeof(s_sys_time));
		IERPOPRCFM.DATA_FLAG = 'I';

		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
		}

		IERPOPRCFM.ZPISTAT = c_upload_flag;

		//20190713 HCH KIM : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
		memcpy(IERPOPRCFM.CMF_1, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));

		//20190905 ISSUE-09-003 IERPOPRCFM.CMF_2에 대표 불량 코드 추가 버그 수정.
		CDB_init_cedclotfqc(&CEDCLOTFQC);
		memcpy(CEDCLOTFQC.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotfqc(2, &CEDCLOTFQC);

		if (DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

		// 10/22/2019 Defect Code만 보내도록 수정.
		/*
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
		memcpy(MGCMTBLDAT.KEY_1, CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE));
		memcpy(MGCMTBLDAT.KEY_2, CEDCLOTFQC.OPER, sizeof(CEDCLOTFQC.OPER));
		DBC_select_mgcmtbldat(104, &MGCMTBLDAT);

		if(DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

		memcpy(IERPOPRCFM.CMF_2, MGCMTBLDAT.DATA_4, sizeof(IERPOPRCFM.CMF_2));
		*/

		memcpy(IERPOPRCFM.CMF_2, CEDCLOTFQC.DEFECT_CODE, sizeof(IERPOPRCFM.CMF_2));

		CDB_insert_ierpoprcfm(&IERPOPRCFM);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}

		//IBAKOPRCFM DATA INSERT
		memcpy(IBAKOPRCFM.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IBAKOPRCFM_TAG));
		CDB_insert_ibakoprcfm(&IBAKOPRCFM);
		if (DB_error_code != DB_SUCCESS)
		{

		}


		/* - [GERP PROJECT] 시작****************************************************************/
			//IQCMFSHDAT DATA INSERT
		memcpy(IQCMFSHDAT.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IQCMFSHDAT_TAG));
		CDB_insert_iqcmfshdat(&IQCMFSHDAT);
		if (DB_error_code != DB_SUCCESS)
		{

		}

		/* - [GERP PROJECT] 끝******************************************************************/
	}


	/******************************************************/
	// 5 : FQC CONFIRM AND GR DATA [IF-PP-305]
	//     [GERP PROJECT 추가]Module Serial Number Flash data Receive [IF-QM-002]IQCMFSHDAT 전송
	/******************************************************/

	if (c_inf_type_flag == '5')
	{		
		c_upload_flag = 'R';

		//마지막 수행이력 GET (FQC ONLY)
		CDB_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
		memcpy(MWIPLOTHIS.OLD_OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER));
		memcpy(MWIPLOTHIS.TRAN_CODE, "END", strlen(HQCEL_M1_FQC_OPER));

		CDB_select_mwiplothis(3, &MWIPLOTHIS);
		if (DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		if (memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) != 0)
		{
			return MP_TRUE;
		}

		//이전에 같은공정에서 END한 이력이 있으면 이미 실적처리를 처음은 I/두번쨰는U 로 올림.
		/*
		c_action_type = 'I';

		if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) > 0)
		{
			c_action_type = 'U';
		}
		*/


		// ORDER GET
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		}
		else
		{
			if (memcmp(MWIPORDSTS.ORD_CMF_4, "HM03", 4) == 0)
			{
				//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				//R 로 다시변경 요청 : 2/7
				c_upload_flag = 'R';
			}
		}

		//OPOERATION SELECT
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		memcpy(MWIPOPRDEF.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//memcpy(MWIPOPRDEF.OPER, MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
		memcpy(MWIPOPRDEF.OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER));  //LOT 공정과 상관없이 FQC 는 무조건 수행함.
		DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		if (DB_error_code != DB_SUCCESS)
		{
			//에러날수 없음.
		}

		//ERP UPLOAD 공정이 아니면 RETURN TURE
		if (MWIPOPRDEF.ERP_FLAG != 'Y')
		{
			return MP_TRUE;
		}

		// 올려야 하는값이 있는지 체크 (ERP OPETION 이 없으면 TRUE)
		if (COM_isspace(MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1)) == MP_TRUE)
		{
			return MP_TRUE;
		}

		//ERP WORK CENTER GET
		CDB_init_cwipordrte(&CWIPORDRTE);
		memcpy(CWIPORDRTE.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(CWIPORDRTE.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(CWIPORDRTE.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));
		CDB_select_cwipordrte(2, &CWIPORDRTE);
		if (DB_error_code != DB_SUCCESS)
		{
			//에러처리 우선안함.
		}

		/* Action Type */
		c_action_type = 'I';

		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));	//[GERP PROJECT 추가] SITE ID 포맷양식변경
		memcpy(IERPOPRCFM.PROD_ORDER_NO, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		TRS.copy(IERPOPRCFM.MODULE_ID, sizeof(IERPOPRCFM.MODULE_ID), in_node, "LOT_ID");
		memcpy(IERPOPRCFM.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));
		memcpy(IERPOPRCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(MWIPOPRDEF.OPER_CMF_1));
		//IERPOPRCFM.ERP_FLAG = 'S';
		//if (CDB_select_ierpoprcfm_scalar(3, &IERPOPRCFM) > 0)
		if (CDB_select_ierpoprcfm_scalar(7, &IERPOPRCFM) > 0)	// [GERP PROJECT 수정] Order 조건 추가
		{
			c_action_type = 'U';
		}


		// FQC Simulator 및 HI-POT 공정 결과값 SELECT (MWIPELTSTS 에 저장됨)
		CDB_init_mwipeltsts(&MWIPELTSTS);
		memcpy(MWIPELTSTS.LOT_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		CDB_select_mwipeltsts(i_inscase, &MWIPELTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}

		/* skip "REWOR" grade */
		// RWK 판정받은 경우 GRADE="R01" 로 I/F 될 수 있도록 수정 --> [GERP 수정] RW 등급, GERP PP,QM 보고안함
		if (memcmp(MWIPELTSTS.GRADE, "REWOR", strlen("REWOR")) == 0)
		{
			return TRUE;
			//memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
		}
		if (memcmp(MWIPELTSTS.GRADE, "RWK", strlen("RWK")) == 0)
		{
			return TRUE;
			//memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
		}


		// IERPOPRCFM 컬럼값 넣어주기 
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID));
		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));	//[GERP PROJECT 추가] SITE ID 포맷양식변경
		memcpy(IERPOPRCFM.PROD_ORDER_NO, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));

		memcpy(IERPOPRCFM.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));

		memcpy(IERPOPRCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(CWIPORDRTE.WORK_CENTER));
		IERPOPRCFM.ACTION_TYPE[0] = c_action_type;

		memcpy(IERPOPRCFM.MATE_NO, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));
		COM_dtoa(IERPOPRCFM.PROD_QTY, MWIPLOTHIS.QTY_1, sizeof(IERPOPRCFM.PROD_QTY));

		IERPOPRCFM.SCRAP_QTY[0] = '0';
		memcpy(IERPOPRCFM.UNIT_ID, "PCS", strlen("PCS"));	//[GERP PROJECT 추가] PC -> PCS 포맷양식변경
		TRS.copy(IERPOPRCFM.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

		/* FQC date is Work date */
		memcpy(IERPOPRCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));
		//임시 변경 시작(2023.08.10)
		//23년8월인 경우, 9월1일로 셋팅 하도록 변경함
		//if ((memcmp(MWIPLOTHIS.LOT_CMF_1, "MDL06", strlen("MDL06")) == 0 || memcmp(MWIPLOTHIS.LOT_CMF_1, "MDL07", strlen("MDL07")) == 0)
	 //   && ((cur_work_time.work_month = 8) && (cur_work_time.work_year = 2023)) )
		//{
		//	memset(IERPOPRCFM.FQC_DATE, ' ', sizeof(IERPOPRCFM.FQC_DATE)); 
		//	memcpy(IERPOPRCFM.FQC_DATE, "20230901", strlen("20230901"));
		//}

		//임시 변경 종료(2023.08.10)



		/* 검사결과값 */
		memcpy(IERPOPRCFM.QUALITY_GRADE, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
		memcpy(IERPOPRCFM.POWER_GRADE, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
		//memcpy(IERPOPRCFM.SHIFT, MWIPELTSTS.LINE_ID, sizeof(MWIPELTSTS.LINE_ID));

		memcpy(IERPOPRCFM.EFF, MWIPELTSTS.EFF, sizeof(MWIPELTSTS.EFF));
		memcpy(IERPOPRCFM.RSH, MWIPELTSTS.RSH, sizeof(MWIPELTSTS.RSH));
		memcpy(IERPOPRCFM.RS, MWIPELTSTS.RS, sizeof(MWIPELTSTS.RS));
		memcpy(IERPOPRCFM.FF, MWIPELTSTS.FF, sizeof(MWIPELTSTS.FF));
		memcpy(IERPOPRCFM.ISC, MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC));
		memcpy(IERPOPRCFM.VOC, MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC));
		memcpy(IERPOPRCFM.IMPP, MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP));
		memcpy(IERPOPRCFM.VMPP, MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP));
		memcpy(IERPOPRCFM.PMPP, MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));
		memcpy(IERPOPRCFM.TEMP, MWIPELTSTS.TEMP, sizeof(MWIPELTSTS.TEMP));
		memcpy(IERPOPRCFM.SURFTEMP, MWIPELTSTS.SURFTEMP, sizeof(MWIPELTSTS.SURFTEMP));
		memcpy(IERPOPRCFM.SUN, MWIPELTSTS.SUN, sizeof(MWIPELTSTS.SUN));
		memcpy(IERPOPRCFM.OSC, MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC));
		memcpy(IERPOPRCFM.ESC, MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC));
		memcpy(IERPOPRCFM.EL, MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL));

		//SIM 설비( 앞의3자리 US- 를 제외하고 뒤의자리만)
		memcpy(IERPOPRCFM.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE + 3, 10);
		//memcpy(IERPOPRCFM.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE, sizeof(MWIPELTSTS.FLASHER_CODE));

		//memcpy(IERPOPRCFM.ARTICLE_CODE, MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO)); 		// [GERP PROJECT] ARTICLE 사용안함으로 제
		memcpy(IERPOPRCFM.COLOR_CLASS, MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS));

		//memcpy(IERPOPRCFM.FQC_DATE, MWIPELTSTS.FQC_TIME, 8);
		memset(IERPOPRCFM.SHIFT, ' ', sizeof(IERPOPRCFM.SHIFT));
		if (cur_work_time.work_shift == 1)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		//memcpy(IERPOPRCFM.LOCATION, MWIPELTSTS.LOC_ID, 3);
		memcpy(IERPOPRCFM.LOCATION, MWIPORDSTS.ORD_CMF_6, 3);

		memcpy(IERPOPRCFM.INF_TIME, s_sys_time, sizeof(s_sys_time));
		IERPOPRCFM.DATA_FLAG = 'I';

		// RWK 판정받은 경우 I/F 될 수 있도록 수정
		if (memcmp(MWIPELTSTS.GRADE, "R01", strlen("R01")) != 0)
		{
			if (COM_isspace(IERPOPRCFM.QUALITY_GRADE, sizeof(IERPOPRCFM.QUALITY_GRADE)) == MP_TRUE)
			{
				c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
			if (COM_isspace(IERPOPRCFM.POWER_GRADE, sizeof(IERPOPRCFM.POWER_GRADE)) == MP_TRUE)
			{
				c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
			if (COM_isspace(IERPOPRCFM.ARTICLE_CODE, sizeof(IERPOPRCFM.ARTICLE_CODE)) == MP_TRUE)
			{
				//c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리	[GERP PROJECT] ARTICLE 사용안함으로 주석처리
			}
			if (COM_isspace(IERPOPRCFM.COLOR_CLASS, sizeof(IERPOPRCFM.COLOR_CLASS)) == MP_TRUE)
			{
				//c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리 [GERP PROJECT] 23.06.02 COLOR_CLASS 사용안함으로 주석처리
			}
			if (COM_isspace(IERPOPRCFM.PMPP, sizeof(IERPOPRCFM.PMPP)) == MP_TRUE)
			{
				c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
		}

		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
		}

		memcpy(IERPOPRCFM.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE + 3, 10);

		memcpy(IERPOPRCFM.FQC_OPERATOR, IERPOPRCFM.FLASHER_CODE, sizeof(IERPOPRCFM.FQC_OPERATOR));

		IERPOPRCFM.ZPISTAT = c_upload_flag;


		///20190713 HCH KIM  : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
		memcpy(IERPOPRCFM.CMF_1, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));

		//20190905 ISSUE-09-003 IERPOPRCFM.CMF_2에 대표 불량 코드 추가 버그 수정.
		CDB_init_cedclotfqc(&CEDCLOTFQC);
		memcpy(CEDCLOTFQC.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotfqc(2, &CEDCLOTFQC);

		if (DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

		memcpy(IERPOPRCFM.CMF_2, CEDCLOTFQC.DEFECT_CODE, sizeof(IERPOPRCFM.CMF_2));

		CDB_insert_ierpoprcfm(&IERPOPRCFM);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}

		//IBAKOPRCFM DATA INSERT

		memcpy(IBAKOPRCFM.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IBAKOPRCFM_TAG));
		CDB_insert_ibakoprcfm(&IBAKOPRCFM);
		if (DB_error_code != DB_SUCCESS)
		{

		}

		/* - [GERP PROJECT] 시작****************************************************************/
			//IQCMFSHDAT DATA INSERT
		memcpy(IQCMFSHDAT.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IQCMFSHDAT_TAG));
		CDB_insert_iqcmfshdat(&IQCMFSHDAT);
		if (DB_error_code != DB_SUCCESS)
		{

		}
		/* - [GERP PROJECT] 끝*******************************************************************/
	}


	//******************************************************/
	// 6 : Module Packing Interface (IF-LE-005)
	//     ZMDL Interface(IERPWIPCFM)
	/******************************************************/
	if (c_inf_type_flag == '6')
	{
		c_upload_flag = 'R';

		//BATCH NO : CEINVCELRCV BATCHNO 
		CDB_init_cwiplotpak(&CWIPLOTPAK_CNT);
		memcpy(CWIPLOTPAK_CNT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPLOTPAK_CNT.PALLET_ID, sizeof(CWIPLOTPAK_CNT.PALLET_ID), in_node, "PALLET_ID");
		CDB_select_cwiplotpak(2, &CWIPLOTPAK_CNT);
		if (DB_error_code != DB_SUCCESS)
		{
			//SELECT CASE 2:
			//PACK_TYPE : TIMESTAMP
			//HIST_SEQW : PACK_COUNT
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);

		}

		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");

		CDB_open_cwiplotpak(2, &CWIPLOTPAK);

		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}


		// FETCH
		while (1)
		{
			CDB_fetch_cwiplotpak(2, &CWIPLOTPAK);
			if (DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwiplotpak(2);
				break;
			}
			else if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_DESC), MWIPLOTSTS.LOT_DESC);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_cwiplotpak(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			// LOT_STS 정보 읽어오기 
			CDB_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));//DOC_ID	
			CDB_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}

			// FQC I/F 값이 있는지 CHECK!
			CDB_init_ierpoprcfm(&IERPOPRCFM);
			memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2)); //[GERP PROJECT] SITE_ID 포맷양식 변경
			memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(IERPOPRCFM.OPER_NO, "0010", strlen("0010"));	//	[GERP PROJECT] OPER_NO 0040 -> 0010 변경
			if (CDB_select_ierpoprcfm_scalar(6, &IERPOPRCFM) <= 0) //	[GERP PROJECT] 구/신 겹칠때 구 보고한 모듈 조회안되서 신으로 또보내는 현상 분기추가해서 처리(4->6)
			{
				//[23.06.27]ZBOM코드가 숫자(구코드인경우] 10번이 없어도 다시 보내지 않는다.
				if (MWIPLOTSTS.MAT_ID[0] != '0')
				{
					//[23.06.27]
					//FQC 값이 없으면 FQC I/F 데이터 자동생성
					TRS.set_string(in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.set_char(in_node, "INF_UPLOAD_TYPE_FLAG", '5');
					if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code, in_node, out_node) == MP_FALSE)
					{
						//ERROR 
						/*DB_rollback();
						continue;*/
					}
				}
			}

			// IERPPAKDAT 컬럼값 넣어주기 
			CDB_init_ierppakdat(&IERPPAKDAT);
			memcpy(IERPPAKDAT.DOC_ID, CWIPLOTPAK_CNT.PAK_TYPE, sizeof(CWIPLOTPAK_CNT.PAK_TYPE));			//DOC_ID	
			memcpy(IERPPAKDAT.PALLET_ID, CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));				//PALLET_ID
			memcpy(IERPPAKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));						//MODULE_ID
			IERPPAKDAT.ACTION_TYPE = 'I';																	//ACTION_TYPE

			COM_itoa(IERPPAKDAT.MODULE_SEQ, CWIPLOTPAK.PAK_SEQ, sizeof(IERPPAKDAT.MODULE_SEQ));				//MODULE_SEQ
			memcpy(IERPPAKDAT.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));			//SITE_ID	[GERP PROJECT SITE_ID 포맷양식변경]
			IERPPAKDAT.QTY = CWIPLOTPAK_CNT.HIST_SEQ;														//QTY
			memcpy(IERPPAKDAT.PACKING_DATE, CWIPLOTPAK.PAK_TIME, 8);										//PACKING DATE
			//임시 변경 시작(2023.08.10)
			//23년8월인 경우, 9월1일로 셋팅 하도록 변경함
			//23년8월이 되면 원복
			if ((memcmp(MWIPLOTSTS.LOT_CMF_1, "MDL06", strlen("MDL06")) == 0 || memcmp(MWIPLOTSTS.LOT_CMF_1, "MDL07", strlen("MDL07")) == 0)
			&& ((cur_work_time.work_month = 8) && (cur_work_time.work_year = 2023)) )
			{
					memset(IERPPAKDAT.PACKING_DATE, ' ', sizeof(IERPPAKDAT.PACKING_DATE)); 
					memcpy(IERPPAKDAT.PACKING_DATE, "20230901", strlen("20230901"));
			}
			//임시 변경 종료(2023.08.10)




			memcpy(IERPPAKDAT.PACKING_TIME, CWIPLOTPAK.PAK_TIME + 8, 6);										//PACKING TIME
			//			memcpy(IERPPAKDAT.PACKING_ID, CWIPLOTPAK.RES_ID, sizeof(CWIPLOTPAK.RES_ID));					//PACKING_ID ( USER ID OR RES ID)
			TRS.copy(IERPPAKDAT.PACKING_ID, sizeof(IERPPAKDAT.PACKING_ID), in_node, IN_USERID);				//PACKING_ID ( USER ID OR RES ID)

			memcpy(IERPPAKDAT.CMF_5, CWIPLOTPAK.CMF_5, sizeof(CWIPLOTPAK.CMF_5));						//Pack H/V (수평/수직포장)

			//[24.04.24]PVM_PN값이 공백이 아니면 자재번호+POWER값으로 맵핑 한다.
			if (COM_isnullspace(CWIPLOTPAK.PVM_PN) == MP_FALSE)
			{
				CDB_init_mwipeltsts(&MWIPELTSTS);
				memcpy(MWIPELTSTS.LOT_ID, IERPPAKDAT.MODULE_ID, sizeof(IERPPAKDAT.MODULE_ID));
				CDB_select_mwipeltsts(i_inscase, &MWIPELTSTS);
				if (DB_error_code != DB_SUCCESS)
				{

				}

				j = 0;
				k = 0;
				CDB_init_mgcmlagdat(&MGCMLAGDAT);
				j = COM_string_length(CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
				memcpy(MGCMLAGDAT.DATA_4, CWIPLOTPAK.MAT_ID, j);
				MGCMLAGDAT.DATA_4[j] = '-';
				k = COM_string_length(MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));

				if (k == 1)	//power 값이 1자리인경우
				{
					MGCMLAGDAT.DATA_4[j + 1] = '0';
					MGCMLAGDAT.DATA_4[j + 2] = '0';
					MGCMLAGDAT.DATA_4[j + 3] = '0';
					MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[0];
				}
				else if (k == 2)	//power 값이 2자리인경우
				{
					MGCMLAGDAT.DATA_4[j + 1] = '0';
					MGCMLAGDAT.DATA_4[j + 2] = '0';
					MGCMLAGDAT.DATA_4[j + 3] = MWIPELTSTS.POWER[0];
					MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[1];
				}
				else if (k == 3)	//power 값이 3자리인경우
				{
					MGCMLAGDAT.DATA_4[j + 1] = '0';
					MGCMLAGDAT.DATA_4[j + 2] = MWIPELTSTS.POWER[0];
					MGCMLAGDAT.DATA_4[j + 3] = MWIPELTSTS.POWER[1];
					MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[2];
				}
				else if (k == 4)//power 값이 4자리인경우
				{
					MGCMLAGDAT.DATA_4[j + 1] = MWIPELTSTS.POWER[0];
					MGCMLAGDAT.DATA_4[j + 2] = MWIPELTSTS.POWER[1];
					MGCMLAGDAT.DATA_4[j + 3] = MWIPELTSTS.POWER[2];
					MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[3];
				}

				memcpy(IERPPAKDAT.PVM_PN, MGCMLAGDAT.DATA_4, j+5);		//ZMATNR
				//memcpy(IERPPAKDAT.PVM_PN, CWIPLOTPAK.PVM_PN, sizeof(CWIPLOTPAK.PVM_PN));


			}
			else
			{
				memcpy(IERPPAKDAT.PVM_PN, CWIPLOTPAK.PVM_PN, sizeof(CWIPLOTPAK.PVM_PN));
			}
			//[24.04.24]PVM_PN값이 공백이 아니면 자재번호+POWER값으로 맵핑 한다.
			memcpy(IERPPAKDAT.PVM_SN, CWIPLOTPAK.PVM_SN, sizeof(CWIPLOTPAK.PVM_SN));
			memcpy(IERPPAKDAT.PCU_SN, CWIPLOTPAK.PCU_SN, sizeof(CWIPLOTPAK.PCU_SN));
			memcpy(IERPPAKDAT.ACM_SN, CWIPLOTPAK.ACM_SN, sizeof(CWIPLOTPAK.ACM_SN));

			memcpy(IERPPAKDAT.INF_PROC_TIME, s_sys_time, sizeof(s_sys_time));								//INTERFACE_TIME
			TRS.copy(IERPPAKDAT.INTERFACE_USERID, sizeof(IERPPAKDAT.INTERFACE_USERID), in_node, IN_USERID);	//INTERFACE_USERID

			IERPPAKDAT.DATA_FLAG = 'I';																		//DATA_FLAG
			IERPPAKDAT.ZPISTAT = c_upload_flag;																//ZPISTAT

			
			//memset(s_sys_date, 0x00, sizeof(s_sys_date));
			//memcpy(s_sys_date, cur_work_time.work_date, 8);

			memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
			CCOM_get_work_time(s_sys_time, &cur_work_time);
			memcpy(IERPPAKDAT.INTERFACE_DATE, s_sys_time, 8);												//INTERFACE_DATE
			memcpy(IERPPAKDAT.INTERFACE_TIME, s_sys_time + 8, 6);												//INF_PROC_TIME




			CDB_insert_ierppakdat(&IERPPAKDAT);

			if (DB_error_code != DB_SUCCESS)
			{

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Error log
				// DB Close 추가
				strcpy(s_msg_code, "BAS-0004");
				TRS.add_fieldmsg(out_node, "IERPPAKDAT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IERPPAKDAT.DOC_ID), IERPPAKDAT.DOC_ID);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(IERPPAKDAT.PALLET_ID), IERPPAKDAT.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IERPPAKDAT.MODULE_ID), IERPPAKDAT.MODULE_ID);
				TRS.add_fieldmsg(out_node, "ACTION_TYPE", MP_CHR, IERPPAKDAT.ACTION_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				CDB_close_cwiplotpak(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			}

			/* - [GERP PROJECT] 시작****************************************************************/
			//IERPWIPCFM 데이터 저장[IF-PP-307] ZMDL 및 팔렛노트 정보 실적보고
			//ERP WORK CENTER GET
			CDB_init_cwipordrte(&CWIPORDRTE);
			memcpy(CWIPORDRTE.FACTORY, CWIPLOTPAK.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
			memcpy(CWIPORDRTE.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(CWIPORDRTE.OPER_NO, "0010", 4);
			CDB_select_cwipordrte(2, &CWIPORDRTE);
			if (DB_error_code != DB_SUCCESS)
			{
				//에러처리 우선안함.
			}

			CDB_init_mwipeltsts(&MWIPELTSTS);
			memcpy(MWIPELTSTS.LOT_ID, IERPPAKDAT.MODULE_ID, sizeof(IERPPAKDAT.MODULE_ID));
			CDB_select_mwipeltsts(i_inscase, &MWIPELTSTS);
			if (DB_error_code != DB_SUCCESS)
			{

			}

			/*[GERP] 23.06.13 *************************************************************************************************/
			// ZBOM -> ZMDL 변경 : @POWER_RANGE -> MAT_ID + POWER 로 변경 
			/*
			CDB_init_mgcmlagdat(&MGCMLAGDAT);
			memcpy(MGCMLAGDAT.FACTORY, CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY));
			memcpy(MGCMLAGDAT.TABLE_NAME, "@POWER_RANGE", strlen("@POWER_RANGE"));
			memcpy(MGCMLAGDAT.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
			memcpy(MGCMLAGDAT.KEY_2, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
			memcpy(MGCMLAGDAT.KEY_3, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
			memcpy(MGCMLAGDAT.DATA_2, MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));

			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			*/
			j = 0;
			k = 0;
			CDB_init_mgcmlagdat(&MGCMLAGDAT);
			j = COM_string_length(CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
			memcpy(MGCMLAGDAT.DATA_4, CWIPLOTPAK.MAT_ID, j);
			MGCMLAGDAT.DATA_4[j] = '-';
			k = COM_string_length(MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));

			if (k == 1)	//power 값이 1자리인경우
			{
				MGCMLAGDAT.DATA_4[j + 1] = '0';
				MGCMLAGDAT.DATA_4[j + 2] = '0';
				MGCMLAGDAT.DATA_4[j + 3] = '0';
				MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[0];
			}
			else if (k == 2)	//power 값이 2자리인경우
			{
				MGCMLAGDAT.DATA_4[j + 1] = '0';
				MGCMLAGDAT.DATA_4[j + 2] = '0';
				MGCMLAGDAT.DATA_4[j + 3] = MWIPELTSTS.POWER[0];
				MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[1];
			}
			else if (k == 3)	//power 값이 3자리인경우
			{
				MGCMLAGDAT.DATA_4[j + 1] = '0';
				MGCMLAGDAT.DATA_4[j + 2] = MWIPELTSTS.POWER[0];
				MGCMLAGDAT.DATA_4[j + 3] = MWIPELTSTS.POWER[1];
				MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[2];
			}
			else if (k == 4)//power 값이 4자리인경우
			{
				MGCMLAGDAT.DATA_4[j + 1] = MWIPELTSTS.POWER[0];
				MGCMLAGDAT.DATA_4[j + 2] = MWIPELTSTS.POWER[1];
				MGCMLAGDAT.DATA_4[j + 3] = MWIPELTSTS.POWER[2];
				MGCMLAGDAT.DATA_4[j + 4] = MWIPELTSTS.POWER[3];
			}

			// 모듈 조회 
			CDB_init_mwipmatdef(&MWIPMATDEF);
			memcpy(MWIPMATDEF.FACTORY, CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY));
			memcpy(MWIPMATDEF.MAT_ID, MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));
			MWIPMATDEF.MAT_VER = 1;
			CDB_select_mwipmatdef(1, &MWIPMATDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0006");
				TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPLOTPAK.MAT_ID), CWIPLOTPAK.MAT_ID);
				TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MWIPELTSTS.POWER), MWIPELTSTS.POWER);
				TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, 1);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			/**************************************************************************************************/



			/* skip "REWOR" grade */
			// RWK 판정받은 경우 GRADE="R01" 로 I/F 될 수 있도록 수정
			if (memcmp(MWIPELTSTS.GRADE, "REWOR", strlen("REWOR")) == 0)
			{
				//return TRUE;
				memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
			}
			if (memcmp(MWIPELTSTS.GRADE, "RWK", strlen("RWK")) == 0)
			{
				//return TRUE;
				memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
			}


			CDB_init_ierpwipcfm(&IERPWIPCFM);
			memcpy(IERPWIPCFM.DOC_ID, IERPPAKDAT.DOC_ID, sizeof(IERPPAKDAT.DOC_ID));			//DOC_ID	
			memcpy(IERPWIPCFM.SITE_ID, IERPPAKDAT.SITE_ID, sizeof(IERPPAKDAT.SITE_ID));			//SITE_ID	
			memcpy(IERPWIPCFM.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));//PROD_ORDER_NO	

			memcpy(IERPWIPCFM.MODULE_ID, IERPPAKDAT.MODULE_ID, sizeof(IERPPAKDAT.MODULE_ID));			//MODULE_ID	
			memcpy(IERPWIPCFM.PALLET_ID, IERPPAKDAT.PALLET_ID, sizeof(IERPPAKDAT.PALLET_ID));			//PALLET_ID	
			memcpy(IERPWIPCFM.OPER_NO, "0010", 4);				//OPER_NO

			memcpy(IERPWIPCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(CWIPORDRTE.WORK_CENTER));			//WORK_CENTER	
			IERPWIPCFM.ACTION_TYPE = 'I';			//ACTION_TYPE	
			memcpy(IERPWIPCFM.ZMATNR, MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));		//ZMATNR
			memcpy(IERPPAKDAT.PALLET_ID, CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));				//PALLET_ID
			memcpy(IERPPAKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));						//MODULE_ID
			IERPWIPCFM.PROD_QTY = 1;			//PROD_QTY
			IERPWIPCFM.SCRAP_QTY = 0;			//SCRAP_QTY
			memcpy(IERPWIPCFM.UNIT_ID, "PCS", 3);		//UNIT_ID

			//FQC_DATE;
			memcpy(IERPWIPCFM.QUALITY_GRADE, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));						//QUALITY_GRADE
			memcpy(IERPWIPCFM.ZIFERNAM, "PIUSIF", 6);		//ZIFERNAM
			memcpy(IERPWIPCFM.ZIFDATE, s_sys_time, 8);		//ZIFDATE		
			memcpy(IERPWIPCFM.ZIFTIME, s_sys_time + 8, 6);	//ZIFTIME
			memcpy(IERPWIPCFM.ZPICODE, "IERPWIPCFM", 9);		//ZPICODE
			IERPWIPCFM.ZPISTAT = 'R'; //ZPISTAT


			//memcpy(IERPWIPCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date)); //FQC_DATE
			//memcpy(IERPWIPCFM.FQC_DATE, s_sys_date, sizeof(s_sys_date)); //FQC_DATE
			memcpy(IERPWIPCFM.FQC_DATE, fqc_work_time.work_date, sizeof(fqc_work_time.work_date)); //FQC_DATE

			// [GERP PROJECT] 같은 오더로 재패킹 됫을때 I->U Rework 모듈 List 있을경우 I
			CDB_init_mwiplothis(&MWIPLOTHIS);
			memcpy(MWIPLOTHIS.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
			memcpy(MWIPLOTHIS.OPER, HQCEL_M1_FGS_OPER, strlen(HQCEL_M1_FGS_OPER));

			CDB_open_mwiplothis(3, &MWIPLOTHIS);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.set_fieldmsg(out_node, "MWIPLOTHIS OPEN", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);

				TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			while (1)
			{
				CDB_fetch_mwiplothis(3, &MWIPLOTHIS);

				if (DB_error_code == DB_NOT_FOUND)
				{
					CDB_close_mwiplothis(3);
					break;
				}
				if ((memcmp(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID)) == 0) && (memcmp(MWIPLOTHIS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID)) == 0)) 
				{
					IERPWIPCFM.ACTION_TYPE = 'U';
				}
			}

			// [GERP PROJECT] ------------------------------


			CDB_insert_ierpwipcfm(&IERPWIPCFM);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "BAS-0004");
				TRS.add_fieldmsg(out_node, "&IERPWIPCFM INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IERPPAKDAT.DOC_ID), IERPWIPCFM.DOC_ID);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(IERPWIPCFM.PALLET_ID), IERPWIPCFM.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IERPWIPCFM.MODULE_ID), IERPWIPCFM.MODULE_ID);
				TRS.add_fieldmsg(out_node, "ACTION_TYPE", MP_CHR, IERPWIPCFM.ACTION_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;


				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			}
			/* - [GERP PROJECT] 끝***********************************************************************************************/
		}
	}

	/******************************************************/
	// 7 : MODULE TERMINATE (LOSS)
	/******************************************************/
	if (c_inf_type_flag == '7')
	{
		c_upload_flag = 'R';

		//마지막 수행이력 GET 
		CDB_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
		//22.08.09 Module Terminate 취소시 정상적으로 SAP에 데이터가 쌓이지 않은 현상수정
		if (TRS.get_char(in_node, "CANCEL_FLAG") == 'Y')
		{
			CDB_select_mwiplothis(7, &MWIPLOTHIS);
		}
		else
		{
			CDB_select_mwiplothis(2, &MWIPLOTHIS);
		}
		if (DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		if (memcmp(MWIPLOTHIS.TRAN_CODE, "TERMINATE", strlen("TERMINATE")) != 0)
		{
			return MP_TRUE;
		}

		//[24.03.08]FQC 보낸 기록이 있는지 확인
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		memcpy(IERPOPRCFM.OPER_NO, "0040", strlen("0040"));
		if (CDB_select_ierpoprcfm_scalar(8, &IERPOPRCFM) < 1)
		{
			//ERP 로 넘긴 실적이 없음 처리안함
			return MP_TRUE;
		}

		//[24.03.08]FQC 보낸 기록이 있는지 확인

		//IERPOPRCFM 에서 마지막 데이터 가져옮
		CDB_init_ierpoprcfm(&IERPOPRCFM_LST);
		memcpy(IERPOPRCFM_LST.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		CDB_select_ierpoprcfm(5, &IERPOPRCFM_LST);
		if(DB_error_code != DB_SUCCESS)
		{
			//ERP 로 넘긴 실적이 없음 처리안함
			return MP_TRUE;
		}

		// IERPOPRCFM 컬럼값 넣어주기 
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID));
		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));	// [GERP PROJECT] 추가 SITE_ID 포맷양식 변경
		memcpy(IERPOPRCFM.PROD_ORDER_NO, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));

		memcpy(IERPOPRCFM.OPER_NO, IERPOPRCFM_LST.OPER_NO, sizeof(IERPOPRCFM_LST.OPER_NO));

		memcpy(IERPOPRCFM.WORK_CENTER, IERPOPRCFM_LST.WORK_CENTER, sizeof(IERPOPRCFM_LST.WORK_CENTER));
		IERPOPRCFM.ACTION_TYPE[0] = 'D';

		memcpy(IERPOPRCFM.MATE_NO, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));

		if (TRS.get_char(in_node, "CANCEL_FLAG") == 'Y')
		{
			IERPOPRCFM.PROD_QTY[0] = '1';
			IERPOPRCFM.SCRAP_QTY[0] = '0';
		}
		else
		{
			IERPOPRCFM.PROD_QTY[0] = '0';
			IERPOPRCFM.SCRAP_QTY[0] = '1';
		}

		memcpy(IERPOPRCFM.UNIT_ID, "PCS", strlen("PCS"));	// [GERP PROJECT] PC -> PCS 양식변경 
		TRS.copy(IERPOPRCFM.INF_USER_ID, sizeof(IERPOPRCFM_LST.INF_USER_ID), in_node, IN_USERID);

		/* FQC date is Work date */
		memcpy(IERPOPRCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		/* - [GERP PROJECT] 시작****************************************************************/
		/*  [ERP 23.05.23] GERP 재작업 오더 공정 폐기 - FQC 전일 경우  */
		// 재작업 오더 확인 
		CDB_init_cwiprwkdat(&CWIPRWKDAT);
		memcpy(CWIPRWKDAT.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(CWIPRWKDAT.PROD_ORDER_NO, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(CWIPRWKDAT.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		CDB_select_cwiprwkdat(4, &CWIPRWKDAT); // 취소 된 재작업 제외 
		if (DB_error_code == DB_SUCCESS)
		{
			// FQC 이력이 있을 없을 경우 POSTING DATE & ACTION TYPE 변경 
			// POSTINFG DATE == REWORK 생성일, ACTION TYPE X
			if (COM_isnullspace(CWIPRWKDAT.REWORK_JUDGE) == MP_TRUE)
			{
				//초기화 FQC_DATE, ACTION_TYPE
				memset(IERPOPRCFM.FQC_DATE, ' ', sizeof(IERPOPRCFM.FQC_DATE));
				memset(IERPOPRCFM.ACTION_TYPE, ' ', sizeof(IERPOPRCFM.ACTION_TYPE));
				IERPOPRCFM.ACTION_TYPE[0] = 'X'; 
				memcpy(IERPOPRCFM.FQC_DATE, CWIPRWKDAT.CREATE_TIME, sizeof(cur_work_time.work_date));
			}
		}
		/* - [GERP PROJECT] 시작****************************************************************/

		/* 검사결과값 */
		memcpy(IERPOPRCFM.QUALITY_GRADE, IERPOPRCFM_LST.QUALITY_GRADE, sizeof(IERPOPRCFM_LST.QUALITY_GRADE));
		memcpy(IERPOPRCFM.POWER_GRADE, IERPOPRCFM_LST.POWER_GRADE, sizeof(IERPOPRCFM_LST.POWER_GRADE));

		memcpy(IERPOPRCFM.EFF, IERPOPRCFM_LST.EFF, sizeof(IERPOPRCFM_LST.EFF));
		memcpy(IERPOPRCFM.RSH, IERPOPRCFM_LST.RSH, sizeof(IERPOPRCFM_LST.RSH));
		memcpy(IERPOPRCFM.RS, IERPOPRCFM_LST.RS, sizeof(IERPOPRCFM_LST.RS));
		memcpy(IERPOPRCFM.FF, IERPOPRCFM_LST.FF, sizeof(IERPOPRCFM_LST.FF));
		memcpy(IERPOPRCFM.ISC, IERPOPRCFM_LST.ISC, sizeof(IERPOPRCFM_LST.ISC));
		memcpy(IERPOPRCFM.VOC, IERPOPRCFM_LST.VOC, sizeof(IERPOPRCFM_LST.VOC));
		memcpy(IERPOPRCFM.IMPP, IERPOPRCFM_LST.IMPP, sizeof(IERPOPRCFM_LST.IMPP));
		memcpy(IERPOPRCFM.VMPP, IERPOPRCFM_LST.VMPP, sizeof(IERPOPRCFM_LST.VMPP));
		memcpy(IERPOPRCFM.PMPP, IERPOPRCFM_LST.PMPP, sizeof(IERPOPRCFM_LST.PMPP));
		memcpy(IERPOPRCFM.TEMP, IERPOPRCFM_LST.TEMP, sizeof(IERPOPRCFM_LST.TEMP));
		memcpy(IERPOPRCFM.SURFTEMP, IERPOPRCFM_LST.SURFTEMP, sizeof(IERPOPRCFM_LST.SURFTEMP));
		memcpy(IERPOPRCFM.SUN, IERPOPRCFM_LST.SUN, sizeof(IERPOPRCFM_LST.SUN));
		memcpy(IERPOPRCFM.OSC, IERPOPRCFM_LST.OSC, sizeof(IERPOPRCFM_LST.OSC));
		memcpy(IERPOPRCFM.ESC, IERPOPRCFM_LST.ESC, sizeof(IERPOPRCFM_LST.ESC));
		memcpy(IERPOPRCFM.EL, IERPOPRCFM_LST.EL, sizeof(IERPOPRCFM_LST.EL));

		//SIM 설비( 앞의3자리 US- 를 제외하고 뒤의자리만)
		memcpy(IERPOPRCFM.FLASHER_CODE, IERPOPRCFM_LST.FLASHER_CODE, sizeof(IERPOPRCFM_LST.FLASHER_CODE));

		//memcpy(IERPOPRCFM.ARTICLE_CODE, IBAKOPRCFM.ARTICLE_NO, sizeof(IBAKOPRCFM.ARTICLE_NO));		// [GERP PROJECT] Article 주석처
		memcpy(IERPOPRCFM.COLOR_CLASS, IERPOPRCFM_LST.COLOR_CLASS, sizeof(IERPOPRCFM_LST.COLOR_CLASS));

		//memcpy(IERPOPRCFM.FQC_DATE, MWIPELTSTS.FQC_TIME, 8);
		memset(IERPOPRCFM.SHIFT, ' ', sizeof(IERPOPRCFM.SHIFT));
		if (cur_work_time.work_shift == 1)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		//memcpy(IERPOPRCFM.LOCATION, MWIPELTSTS.LOC_ID, 3);
		memcpy(IERPOPRCFM.LOCATION, IERPOPRCFM_LST.LOCATION, sizeof(IERPOPRCFM_LST.LOCATION));
		//memcpy(IERPOPRCFM.ARTICLE_CODE, IBAKOPRCFM.ARTICLE_CODE, sizeof(IBAKOPRCFM.ARTICLE_CODE));	// [GERP PROJECT] Article 주석처

		memcpy(IERPOPRCFM.INF_TIME, s_sys_time, sizeof(s_sys_time));
		IERPOPRCFM.DATA_FLAG = 'I';
		IERPOPRCFM.ZPISTAT = c_upload_flag;
		//20190713 HCH KIM  : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
		memcpy(IERPOPRCFM.CMF_1, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));

		//20190905 ISSUE-09-003 IERPOPRCFM.CMF_2에 대표 불량 코드 추가 버그 수정.
		CDB_init_cedclotfqc(&CEDCLOTFQC);
		memcpy(CEDCLOTFQC.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotfqc(2, &CEDCLOTFQC);

		if (DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

		// 10/22/2019 Defect Code만 보내도록 수정.
		/*
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
		memcpy(MGCMTBLDAT.KEY_1, CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE));
		memcpy(MGCMTBLDAT.KEY_2, CEDCLOTFQC.OPER, sizeof(CEDCLOTFQC.OPER));
		DBC_select_mgcmtbldat(104, &MGCMTBLDAT);

		if(DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

		memcpy(IERPOPRCFM.CMF_2, MGCMTBLDAT.DATA_4, sizeof(IERPOPRCFM.CMF_2));
		*/
		memcpy(IERPOPRCFM.CMF_2, CEDCLOTFQC.DEFECT_CODE, sizeof(IERPOPRCFM.CMF_2));

		/* Terminate Description */
		//memcpy(IERPOPRCFM.CMF_3, MWIPLOTHIS.TRAN_COMMENT, sizeof(MWIPLOTHIS.TRAN_COMMENT)); IS-21-01-094 MES logic 개선
		memcpy(IERPOPRCFM.CMF_3, MWIPLOTHIS.TRAN_COMMENT, sizeof(IERPOPRCFM.CMF_3));

		//Z93에서 넘어온 데이터는 실적 처리 안함
		//VOC-5049 Z93인터페이스 된 폐기/취소 인경우 SAP로 재 전송 안되도록 변경(22.10.25)
		ihisChk = 0;
		CDB_init_ibakterinf(&IBAKTERINF);

		memcpy(IBAKTERINF.MODULE_ID, IERPOPRCFM.MODULE_ID, sizeof(IERPOPRCFM.MODULE_ID)); ;
		memcpy(IBAKTERINF.ZIFDATE, s_sys_time, 8);

		if (TRS.get_char(in_node, "CANCEL_FLAG") == 'Y')
		{
			IBAKTERINF.ZTYP1 = 'D';
		}
		else
		{
			IBAKTERINF.ZTYP1 = 'I';
		}
		ihisChk = (int)CDB_select_ibakterinf_scalar(2, &IBAKTERINF);
		if (ihisChk > 0)
		{
			return MP_TRUE;
		}


		//VOC-5049 Z93인터페이스 된 폐기/취소 인경우 SAP로 재 전송 안되도록 변경(22.10.25)

		CDB_insert_ierpoprcfm(&IERPOPRCFM);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
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
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			return MP_FALSE;
		}

		//IBAKOPRCFM DATA INSERT
		memcpy(IBAKOPRCFM.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IBAKOPRCFM_TAG));
		CDB_insert_ibakoprcfm(&IBAKOPRCFM);
		if (DB_error_code != DB_SUCCESS)
		{

		}
	}

	return MP_TRUE;
}




/*******************************************************************************
	CWIP_CLEAVING_CONFIRM_DATA_TEST()
		- TEST 를 위한 공정 CONFIRM 데이터 생성
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- char *s_msg_code : Error Msg Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_CLEAVING_CONFIRM_DATA_TEST(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	// INIT
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;

	struct IERPOPRCFM_TAG IERPOPRCFM;

	char s_sys_time[14];
	char s_to_lot_number[25];
	char s_due_time[14];


	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CWIP_CLEAVING_END_LOT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	if (COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
	{
		//임시
		TRS.set_string(in_node, "LINE_ID", "CVL01", strlen("CVL01"));
	}

	//현재 LINE 의 작업지시  GET
	/* Get current order by line ID */
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
	TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if (DB_error_code != DB_SUCCESS)
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
	if (DB_error_code != DB_SUCCESS)
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
	if (DB_error_code != DB_SUCCESS)
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

	CDB_init_ierpoprcfm(&IERPOPRCFM);
	CDB_select_ierpoprcfm(999, &IERPOPRCFM);

	memset(s_to_lot_number, ' ', sizeof(s_to_lot_number));
	memcpy(s_to_lot_number, IERPOPRCFM.CMF_1, sizeof(s_to_lot_number));

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
	TRS.add_string(tran_in_node, "CREATE_CODE", "PROD", strlen("PROD"));
	TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
	TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
	TRS.add_double(tran_in_node, "QTY_1", 100);
	TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));

	memset(s_due_time, ' ', sizeof(s_due_time));
	COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

	TRS.add_string(tran_in_node, "DUE_TIME", s_due_time, sizeof(s_due_time));

	if (WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		return MP_FALSE;
	}

	//Cleaving Half Cell Confirm ERP Interface 수행
	TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '2');
	if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
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
/*******************************************************************************
	CWIP_OPER_CONFIRM_DATA_TEST()
		- TEST 를 위한 공정 CONFIRM 데이터 생성
	return Value
		- int : 0 (MP_TRUE)
	Arguments
		- char *s_msg_code : Error Msg Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_OPER_CONFIRM_DATA_TEST(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	// INIT
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_STR;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;

	char s_sys_time[14];
	int i_tmpcnt = 1;
	char c_combine_flag = 'N';
	char s_to_lot_number[25];
	char s_due_time[14];

	int i;

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	// PROCESS LOG PRINT
	LOG_head("CWIP_OPER_CONFIRM_DATA_TEST");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	if (COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
	{
		//임시
		TRS.set_string(in_node, "LINE_ID", "MDL01", strlen("MDL01"));
	}

	//현재 LINE 의 작업지시  GET
	/* Get current order by line ID */
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
	TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "LINE_ID");

	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
	if (DB_error_code != DB_SUCCESS)
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
	if (DB_error_code != DB_SUCCESS)
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
	if (DB_error_code != DB_SUCCESS)
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

	// INSERT CWIPCELPAK
	i_tmpcnt = 1;//ERP UPLOAD 대량데이터 만들기 위해 임시.
	if (i_tmpcnt < 1)
	{
		i_tmpcnt = 1; // 실제 처리할떄 데이터는 1건임.
	}
	memset(s_to_lot_number, ' ', sizeof(s_to_lot_number));

	for (i = 0; i < i_tmpcnt; i++)
	{
		/****************************************************************************/
		// 1. STRING 한개를 가지고 와서 Combine 시킴 
		/****************************************************************************/
		// 해당 line 에서 투입된 기준으로 선입선출 해서 가져옮.
		// 설비에서 STRING ID 를 올려줄경우 해당 LOT 으로 진행
		// LOT_DESC 에 TIME_STAMP 값 같이 가져옮.
		/****************************************************************************/
		while (1)
		{
			CDB_init_mwiplotsts(&MWIPLOTSTS_STR);
			memcpy(MWIPLOTSTS_STR.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
			memcpy(MWIPLOTSTS_STR.OPER, HQCEL_M1_LAYUP_OPER, strlen(HQCEL_M1_LAYUP_OPER));
			memcpy(MWIPLOTSTS_STR.MAT_ID, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPLOTSTS_STR.START_FLAG = 'Y';
			CDB_select_mwiplotsts(3, &MWIPLOTSTS_STR);
			if (DB_error_code != DB_SUCCESS)
			{
				//가져올LOT 이 없을경우 해당 공정에 있는 LOT 중 먼저들어온놈중에 하나를 가져옮.
				MWIPLOTSTS_STR.START_FLAG = ' ';
				MWIPLOTSTS_STR.END_FLAG = ' ';
				CDB_select_mwiplotsts(4, &MWIPLOTSTS_STR);
				if (DB_error_code != DB_SUCCESS)
				{
					//COMBINE 하지 않고 강제로 진행 : 필요시 ERROR 처리.가상LotNUMBER  는 현재시간 + 0000000 으로 맞춤
					c_combine_flag = 'N';
					memset(MWIPLOTSTS_STR.LOT_DESC, '0', 21);
					memcpy(MWIPLOTSTS_STR.LOT_DESC, s_sys_time, sizeof(s_sys_time));
				}
			}

			if ((memcmp(s_to_lot_number, MWIPLOTSTS_STR.LOT_DESC, 21) != 0) || (COM_isspace(s_to_lot_number, sizeof(s_to_lot_number)) == MP_TRUE))
			{
				break;
			}
		}

		memcpy(s_to_lot_number, MWIPLOTSTS_STR.LOT_DESC, 17); //임시LOT 은 현재 TIMESTAMP 값을 가지고 사용.

		/****************************************************************************/
		// 2. MAIN LOT CREATION
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
		TRS.add_string(tran_in_node, "OPER", HQCEL_M1_LAYUP_OPER, strlen(HQCEL_M1_LAYUP_OPER));
		TRS.add_char(tran_in_node, "LOT_TYPE", 'P');
		TRS.add_string(tran_in_node, "CREATE_CODE", "PROD", strlen("PROD"));
		TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
		TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
		TRS.add_double(tran_in_node, "QTY_1", 1);
		TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));

		memset(s_due_time, ' ', sizeof(s_due_time));
		COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

		TRS.add_string(tran_in_node, "DUE_TIME", s_due_time, sizeof(s_due_time));

		if (WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
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

			//0. fcell 의 magazine detach

			//1. fcell 의 1/2 combine
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS_STR.LOT_ID, sizeof(MWIPLOTSTS_STR.LOT_ID));

			TRS.add_string(tran_in_node, "INTO_LOT_ID", s_to_lot_number, sizeof(s_to_lot_number));

			//STRING 1개만 Combine
			TRS.add_double(tran_in_node, "MOVE_QTY_1", 1);

			if (WIP_COMBINE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
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
		if (DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING : ERROR 가 나면안됨
		}

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
		TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
		if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
		{
			//설비ID 가 없을경우 처리
			TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS_STR.START_RES_ID, sizeof(MWIPLOTSTS_STR.START_RES_ID));
			if (COM_isnullspace(TRS.get_string(tran_in_node, "RES_ID")) == MP_TRUE)
			{
				TRS.set_nstring(tran_in_node, "RES_ID", "US-E1-MLU-01");
			}

		}

		//ERP Interface 를 위해 임시COCE ( M3000, M3040, M3110 ) 데이터 자동생김
		TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		TRS.set_nstring(tran_in_node, "TO_OPER", "M3000");
		TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '4');
		if (WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		//ERP Interface 를 위해 임시COCE ( M3000, M3040, M3110 ) 데이터 자동생김
		{
			/***************************************************/
			//END LOT (M3000)
			/***************************************************/
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);

			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, s_to_lot_number, sizeof(s_to_lot_number));
			DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING : ERROR 가 나면안됨
			}

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_nstring(tran_in_node, "RES_ID", "US-E1-LAM-01");

			//ERP Interface 를 위해 임시COCE ( M3000, M3040, M3110 ) 데이터 자동생김
			TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.set_nstring(tran_in_node, "TO_OPER", "M3040");
			TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '4');
			if (WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}

			/***************************************************/
			//END LOT (M3040)
			/***************************************************/
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);

			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, s_to_lot_number, sizeof(s_to_lot_number));
			DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING : ERROR 가 나면안됨
			}

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_nstring(tran_in_node, "RES_ID", "US-E1-FAS-01");

			//ERP Interface 를 위해 임시COCE ( M3000, M3040, M3110 ) 데이터 자동생김
			TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.set_nstring(tran_in_node, "TO_OPER", "M3110");
			TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '4');
			if (WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}

			/***************************************************/
			//END LOT (M3110)
			/***************************************************/
			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);

			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, s_to_lot_number, sizeof(s_to_lot_number));
			DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING : ERROR 가 나면안됨
			}

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_nstring(tran_in_node, "RES_ID", "US-E1-FQC-01");
			TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '5');
			if (WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}


		}
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		//DB_commit();
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}