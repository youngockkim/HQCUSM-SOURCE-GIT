/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_packing_lot.c
	Description : View Lot Information

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Packing_Lot()
			+ View Lot
		- CWIP_VIEW_PACKING_LOT()
			+ Main sub function of CWIP_View_Packing_Lot function
			+ View Lot definition
		- CWIP_View_Packing_Lot_Validation()
			+ Main sub function of CWIP_VIEW_PACKING_LOT function
			+ Check the condition for view Lot
	Detail Description
		- CWIP_VIEW_PACKING_LOT()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/03/11  YS KIM           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Packing_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_View_Rework_Lot_Fqc_Judgment_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
	CWIP_View_Packing_Lot()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Packing_Lot(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_PACKING_LOT(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_PACKING_LOT", out_node);

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
	CWIP_VIEW_PACKING_LOT()
		- Main sub function of "CWIP_View_Packing_Lot" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_PACKING_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
    //struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_ARTICLE;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_MAP;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	
	struct MGCMLAGDAT_TAG MGCMLAGDAT_PACK_TYPE;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_POWER_CLASS;
	
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

	int i;
	int j;
	int iCnt = 0;

    LOG_head("CWIP_VIEW_PACKING_LOT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_View_Packing_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE; 
    }  

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS) 
	{
		strcpy(s_msg_code, "WIP-0044");
		TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	//E2/3인 경우 처리하지 않고 바로 리턴하는 로직 추가[2023.11.24]
	CDB_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
	memcpy(MGCMTBLDAT.TABLE_NAME,  "@LINE_CODE", strlen("@LINE_CODE")); 
	memcpy(MGCMTBLDAT.KEY_1,  MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
	memcpy(MGCMTBLDAT.DATA_7, "E1", strlen("E1"));
	memcpy(MGCMTBLDAT.DATA_5, "MA", strlen("MA"));

	iCnt = CDB_select_mgcmtbldat_scalar(101, &MGCMTBLDAT);

	if ( iCnt <= 0 )
	{
		strcpy(s_msg_code, "WIP-0647");
		TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_1), MWIPLOTSTS.LOT_CMF_1);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		return MP_FALSE;
	}

	
	/* - [GERP PROJECT] 시작****************************************************************/
	TRS.set_string(in_node, "REWORK_ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
	
	/* - [GERP PROJECT] 시작****************************************************************/
	if(CWIP_View_Rework_Lot_Fqc_Judgment_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	/* - [GERP PROJECT] 끝*****************************************************************/

	/*DBC_init_mwipoprdef(&MWIPOPRDEF);
    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPOPRDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPOPRDEF.OPER));
            
    DBC_select_mwipoprdef(1, &MWIPOPRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0044");
		TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	memcpy(MRASRESDEF.RES_CMF_2, MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER));
	DBC_select_mrasresdef(100, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "RAS-0003");
		TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
		TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}*/
	
	/* - [GERP PROJECT] 시작****************************************************************/
	//제품 코드가 숫자로 시작 되면(구코드)
	//제품 코드를 구코드->신코드로 전환한다.
		if(MWIPLOTSTS.MAT_ID[0]== '0')
		{
			CDB_init_mgcmlagdat(&MGCMLAGDAT_MAP);
			TRS.copy(MGCMLAGDAT_MAP.FACTORY, sizeof(MGCMLAGDAT_MAP.FACTORY), in_node, "FACTORY");
			memcpy(MGCMLAGDAT_MAP.TABLE_NAME, "@CONV_MAT_GERP", strlen("@CONV_MAT_GERP"));
			memcpy(MGCMLAGDAT_MAP.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAP);
			if (DB_error_code == DB_SUCCESS)
			{
				memset(MWIPLOTSTS.MAT_ID, ' ', sizeof(MWIPLOTSTS.MAT_ID));
				memcpy(MWIPLOTSTS.MAT_ID, MGCMLAGDAT_MAP.DATA_1, sizeof(MWIPLOTSTS.MAT_ID));
			}
		}



			/* - [GERP PROJECT] 끝*****************************************************************/


		
	DBC_init_mwipmatdef(&MWIPMATDEF);
	TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, "FACTORY");
	memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
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

	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
	memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		//TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
		//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);
        // IS-21-07-055 CWIP_view_packing_lot 수정
		TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT (@PACKING)", MP_NVST);
		TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;     
	}

	CDB_init_cedclotrlt(&CEDCLOTRLT);
	TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTRLT.INS_TYPE, "FC", strlen("FC"));
	memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "EDC-0098");
			TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
			TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else
		{
			strcpy(s_msg_code, "EDC-0004");
			TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
			TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	/* - [GERP PROJECT] 시작****************************************************************/
	//[ERP Project]23.03.29 
	//제품 코드가 문자로 시작 되면 아티클 코드를 체크 하지 않는다.
	if (MWIPMATDEF.MAT_ID[0] == '0')
	{
		CDB_init_mgcmlagdat(&MGCMLAGDAT_ARTICLE);
		TRS.copy(MGCMLAGDAT_ARTICLE.FACTORY, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMLAGDAT_ARTICLE.TABLE_NAME, "@ARTICLE", strlen("@ARTICLE"));
		memcpy(MGCMLAGDAT_ARTICLE.KEY_1, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		memcpy(MGCMLAGDAT_ARTICLE.DATA_1, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
		memcpy(MGCMLAGDAT_ARTICLE.DATA_2, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));

		CDB_select_mgcmlagdat(5, &MGCMLAGDAT_ARTICLE);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				if (strcmp(CEDCLOTRLT.GRADE, "RW") == 0) { // IS-21-01-094 MES Packing logic 개선
					strcpy(s_msg_code, "WIP-0602");
					//This Module is in REWORK status.  
					//이 모듈은 REWORK 상태입니다.
				}
				else {
					strcpy(s_msg_code, "BOM-0042");
					//기준 정보에 없습니다.
				}
				//strcpy(s_msg_code, "BOM-0042");
				TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), MGCMLAGDAT_ARTICLE.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.TABLE_NAME), MGCMLAGDAT_ARTICLE.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.KEY_1), MGCMLAGDAT_ARTICLE.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "BOM-0004");
				TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), MGCMLAGDAT_ARTICLE.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.TABLE_NAME), MGCMLAGDAT_ARTICLE.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.KEY_1), MGCMLAGDAT_ARTICLE.KEY_1);

				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}
	else
	{
		//바코드 아이디 뒷에서 2번째 자릿수는 등급에 따라 변경
		if (COM_isnullspace(MGCMLAGDAT.DATA_2) == MP_FALSE)
		{
			i = 0;
			i = COM_string_length(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
			if (i == 6)
			{
				if (memcmp(CEDCLOTRLT.GRADE, "G01", strlen("G01")) == 0) {
					MGCMLAGDAT.DATA_2[4] = '1';
				}
				else if (memcmp(CEDCLOTRLT.GRADE, "G02", strlen("G02")) == 0) 
				{
					MGCMLAGDAT.DATA_2[4] = '5';
				}
				else if(memcmp(CEDCLOTRLT.GRADE, "G03",strlen("G03")) == 0){		//--[G03/G04 로직 추가]
					MGCMLAGDAT.DATA_2[4] = '6';
				}
				else if(memcmp(CEDCLOTRLT.GRADE, "G04",strlen("G04")) == 0){		//--[G03/G04 로직 추가]
					MGCMLAGDAT.DATA_2[4] = '0';
				}
				else if (memcmp(CEDCLOTRLT.GRADE, "B", strlen("B")) == 0) 
				{
					if (COM_atoi(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)) < 200) //200WP 미만 출력 B 등급 7
					{
						MGCMLAGDAT.DATA_2[4] = '7';
					}
					else
					{
						MGCMLAGDAT.DATA_2[4] = '2';
					}
				}
				else if (memcmp(CEDCLOTRLT.GRADE, "C", strlen("C")) == 0) 
				{
					if (COM_atoi(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER))< 200) //200WP 미만 출력 C 등급 8
					{
						MGCMLAGDAT.DATA_2[4] = '8';
					}
					else
					{
						MGCMLAGDAT.DATA_2[4] = '3';
					}
				}
				else
				{
					if (COM_atoi(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)) < 200) // G60 Z GRADE 
					{
						MGCMLAGDAT.DATA_2[4] = '9';
					}
					else
					{
						MGCMLAGDAT.DATA_2[4] = '4';
					}
				}
			}
		}
		//아티클 중지에 따른 @PACKING_TYPE,@PACKING_POWER_CLASS 
		//조회를 사용함
		
		CDB_init_mgcmlagdat(&MGCMLAGDAT_PACK_TYPE);
		TRS.copy(MGCMLAGDAT_PACK_TYPE.FACTORY, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMLAGDAT_PACK_TYPE.TABLE_NAME, "@PACKING_TYPE", strlen("@PACKING_TYPE"));
		
		memcpy(MGCMLAGDAT_PACK_TYPE.KEY_1, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		i = 0;
		i = COM_string_length(MGCMLAGDAT_PACK_TYPE.KEY_1, sizeof(MGCMLAGDAT_PACK_TYPE.KEY_1));		//머트리얼 자릿수를 정의한다.
		
		if(i>0)
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[i] = '-';

		}
		j = 0 ;
		if (COM_isnullspace(CEDCLOTRLT.POWER) == MP_FALSE)		//POWER 값 NULL 체크
		{
			j = 0 ;
			j = COM_string_length(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));		//POWER값 자릿수를 체크한다.
		}

		if(j==1)	//power 값이 1자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+1] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+2] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+3] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+4] = CEDCLOTRLT.POWER[0];
		}
		else if (j == 2)	//power 값이 2자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+1] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+2] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+3] = CEDCLOTRLT.POWER[0];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+4] = CEDCLOTRLT.POWER[1];	
		}
		else if (j == 3)	//power 값이 3자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+1] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+2] = CEDCLOTRLT.POWER[0];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+3] = CEDCLOTRLT.POWER[1];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+4] = CEDCLOTRLT.POWER[2];	
		}
		else if (j == 4)	//power 값이 4자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+1] = CEDCLOTRLT.POWER[0];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+2] = CEDCLOTRLT.POWER[1];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+3] = CEDCLOTRLT.POWER[2];	
			
			MGCMLAGDAT_PACK_TYPE.KEY_1[i+4] = CEDCLOTRLT.POWER[3];	
		}

		//모듈 타입 조회
		CDB_select_mgcmlagdat(2, &MGCMLAGDAT_PACK_TYPE);
		if (DB_error_code != DB_SUCCESS)
		{

		}
		//파워 글라스 조회
		CDB_init_mgcmlagdat(&MGCMLAGDAT_POWER_CLASS);
		memcpy(MGCMLAGDAT_POWER_CLASS.FACTORY, MGCMLAGDAT_PACK_TYPE.FACTORY, sizeof(struct MGCMLAGDAT_TAG));//스트럭쳐 copy
		memset(MGCMLAGDAT_POWER_CLASS.TABLE_NAME, ' ', sizeof(MGCMLAGDAT_POWER_CLASS.TABLE_NAME));
		memcpy(MGCMLAGDAT_POWER_CLASS.TABLE_NAME, "@PACKING_POWER_CLASS", strlen("@PACKING_POWER_CLASS"));

		CDB_select_mgcmlagdat(2, &MGCMLAGDAT_POWER_CLASS);
		if (DB_error_code != DB_SUCCESS)
		{

		}

		CDB_init_mgcmlagdat(&MGCMLAGDAT_ARTICLE);
		if (memcmp(CEDCLOTRLT.GRADE, "G01", strlen("G01")) == 0) {
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G02", strlen("G02")) == 0) 
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G03", strlen("G03")) == 0)		//--[G03/G04 로직 추가]
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G04", strlen("G04")) == 0)		//--[G03/G04 로직 추가]
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "B", strlen("B")) == 0) 
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_2, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_2)); //파워클라스는
		}
		else
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_3, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_3)); //파워클라스는
		}

		
		//i = 0;
		//i = COM_string_length(MGCMLAGDAT_ARTICLE.DATA_5, sizeof(MGCMLAGDAT_ARTICLE.DATA_5));

		//if (COM_isnullspace(CEDCLOTRLT.POWER) == MP_FALSE)
		//{
		//	j = 0;
		//	j = COM_string_length(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
		//	if (j == 3)
		//	{
		//		MGCMLAGDAT_ARTICLE.DATA_5[i] = ' ';
		//		MGCMLAGDAT_ARTICLE.DATA_5[i + 1] = CEDCLOTRLT.POWER[0];
		//		MGCMLAGDAT_ARTICLE.DATA_5[i + 2] = CEDCLOTRLT.POWER[1];
		//		MGCMLAGDAT_ARTICLE.DATA_5[i + 3] = CEDCLOTRLT.POWER[2];
		//	}
		//	else if (j == 2)
		//	{
		//		MGCMLAGDAT_ARTICLE.DATA_5[i] = ' ';
		//		MGCMLAGDAT_ARTICLE.DATA_5[i + 1] = CEDCLOTRLT.POWER[0];
		//		MGCMLAGDAT_ARTICLE.DATA_5[i + 2] = CEDCLOTRLT.POWER[1];
		//	}
		//	else if (j == 1)
		//	{
		//		MGCMLAGDAT_ARTICLE.DATA_5[i] = ' ';
		//		MGCMLAGDAT_ARTICLE.DATA_5[i + 1] = CEDCLOTRLT.POWER[0];
		//	}
		//}
	}
	/* - [GERP PROJECT] 끝*****************************************************************/

	// ASIS TOBE MAPPING 
	///* - [GERP PROJECT] 시작****************************************************************/
	//CDB_init_mgcmlagdat(&MGCMLAGDAT_MAP);
	//TRS.copy(MGCMLAGDAT_MAP.FACTORY, sizeof(MGCMLAGDAT_MAP.FACTORY), in_node, "FACTORY");
	//memcpy(MGCMLAGDAT_MAP.TABLE_NAME, "@CONV_MAT_GERP", strlen("@CONV_MAT_GERP"));
	//memcpy(MGCMLAGDAT_MAP.KEY_1, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));
	//CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAP);
	//if (DB_error_code == DB_SUCCESS)

	//{	//TRS.set_string(out_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));	
	//	TRS.set_string(out_node, "MAT_ID", MGCMLAGDAT_MAP.DATA_1, sizeof(MGCMLAGDAT_MAP.DATA_1));
	//}
	//else 
	//{
	TRS.set_string(out_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	//}
	/* - [GERP PROJECT] 끝*****************************************************************/
	TRS.set_string(out_node, "LINE_ID", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
	TRS.set_string(out_node, "OPER", "M3120", strlen("M3120"));
	TRS.set_string(out_node, "RES_ID", "US-E0-PKG-01", strlen("US-E0-PKG-01"));
	//TRS.set_string(out_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	TRS.set_string(out_node, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
	TRS.set_string(out_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	TRS.set_string(out_node, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
	TRS.set_string(out_node, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
	TRS.set_string(out_node, "MODULE_TYPE", MGCMLAGDAT_ARTICLE.DATA_3, sizeof(MGCMLAGDAT_ARTICLE.DATA_3));
	TRS.set_string(out_node, "ARTICLE_NO", MGCMLAGDAT_ARTICLE.KEY_2, sizeof(MGCMLAGDAT_ARTICLE.KEY_2));
	TRS.set_string(out_node, "ARTICLE_DESC", MGCMLAGDAT_ARTICLE.DATA_4, sizeof(MGCMLAGDAT_ARTICLE.DATA_4));
	TRS.set_string(out_node, "POWER_CLASS", MGCMLAGDAT_ARTICLE.DATA_5, sizeof(MGCMLAGDAT_ARTICLE.DATA_5));
	TRS.set_string(out_node, "BARCODE", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
	TRS.set_int(out_node, "MODUL_QTY", COM_atoi(MGCMLAGDAT.DATA_9, 2));

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Packing_Lot_Validation()
		- Main sub function of "CWIP_VIEW_PACKING_LOT" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Packing_Lot_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
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

/*******************************************************************************
	CWIP_View_Rework_Lot_Fqc_Validation()
		- Main sub function of "CWIP_VIEW_PACKING_LOT" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Rework_Lot_Fqc_Judgment_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct CWIPRWKDAT_TAG CWIPRWKDAT;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
 
	/* - [GERP PROJECT] 시작****************************************************************/
	/*
	재작업 모듈인경우 
	validation 1 : 포장이력(sap 입고, ZMDL)이 있는경우 재작업 오더 모듈리스트 에 포함 되어있어야 한다. 
	*/
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID"); 
	//if (CDB_select_cwiplotpak_scalar(1, &CWIPLOTPAK) > 0)
	if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
	{
		//재작업 선정 모듈 중 오더 2회 에 대하여 포장이력이 없는 것이 최종 재작업 오더의 모듈
		CDB_init_cwiprwkdat(&CWIPRWKDAT);
		memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPRWKDAT.PROD_ORDER_NO), in_node, "REWORK_ORDER_ID"); 
		TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "LOT_ID"); 
		
		//case 2 : 재작업오더에 포함되었으나 fqc 판정이 없는 모듈
		if(CDB_select_cwiprwkdat_scalar(3, &CWIPRWKDAT) > 0)
		{
			strcpy(s_msg_code, "WIP-0617"); // This module of the rework order requires fqc Judgment
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);// 2023-03-09 JSLEE ADD
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//case 3 : 재작업오더가 없는 모듈 (패킹 ->
		//if(CDB_select_cwiprwkdat_scalar(8, &CWIPRWKDAT) == 0)
		//{
		//	strcpy(s_msg_code, "WIP-0617"); // This module of the rework order requires fqc Judgment
		//	TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
		//	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);// 2023-03-09 JSLEE ADD
		//	TRS.add_dberrmsg(out_node,DB_error_msg);
		//
		//	gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	gs_log_type.category = MP_LOG_CATE_VIEW;
		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	return MP_FALSE;
		//}
		// case 3 : 2개이상의 재작업 오더일경우 Pallet ID 가 있는경우는 제외
		//if(CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) == 0)
		//{
		//	strcpy(s_msg_code, "WIP-0617"); // This module of the rework order requires fqc Judgment
		//	TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
		//	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);// 2023-03-09 JSLEE ADD
		//	TRS.add_dberrmsg(out_node,DB_error_msg);
		//
		//	gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	gs_log_type.category = MP_LOG_CATE_VIEW;
		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	return MP_FALSE;
		//}
		//포장에서 요청인지 확인 필요

		/* - [GERP PROJECT] 끝*****************************************************************/
	}
	
    return MP_TRUE;
}