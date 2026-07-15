/*******************************************************************************
 
    System      : MESplus
    Module      : View FQC Result
    File Name   : CWIP_view_fqc_result.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.22  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_View_Fqc_Result_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_VIEW_FQC_RESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_View_Rework_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int rework_Flag = MP_FALSE;
/*******************************************************************************
    CWIP_View_Fqc_Result()
        - FQC Result
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Fqc_Result(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_FQC_RESULT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_FQC_RESULT", out_node);

    if(i_ret == MP_TRUE)
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
    CWIP_VIEW_FQC_RESULT()
        - VIEW FQC_RESULT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_FQC_RESULT(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node) 
{
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_MAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_MAP;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	//char tmp_Mat[30], tmp_Mat2[30];
    //패킹에서 ERP 실적 확인하는 로직 추가	40번 공정이 I/F되지 않았으면 패킹이 되지 않게 로직 수정. 
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
    //struct IERPOPRCFM_TAG IERPOPRCFM;
	//[IS-20-08-004]FQC DEFECT,CELL 정보를 가져오기 위해 추가
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	// 20210810 MES Application Memory leak 점검 및 수정
	// 불필요 부분 주석처리
	//struct MGCMTBLDAT_TAG MGCMTBLDAT;

	//[IS-20-08-004]

	int mwiplotsts_flag = 102;

	
    //reverted
	LOG_head("CWIP_VIEW_FQC_RESULT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_View_Fqc_Result_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/* - [GERP PROJECT] 시작****************************************************************/
	/*Rework Module FQC Check*/
	if(CWIP_View_Rework_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	/* - [GERP PROJECT] 끝*****************************************************************/

	CDB_init_cedclotrlt(&CEDCLOTRLT);
    TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLT.INS_TYPE), in_node, "INS_TYPE");
    TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);
	//CEDCLOTRLT.INS_TYPE = FC가 없는 경우 RE_JUDGE = N
	//MES OI - FQC Judgment에서만 사용한다
    if(DB_error_code != DB_SUCCESS)
    {
        TRS.add_string(out_node, "RE_JUDGE", "N", sizeof("N"));
		TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
		//memcpy(CEDCLOTRLT.INS_TYPE, "SI", sizeof("SI"));IS-21-01-094 MES logic 개선
		memcpy(CEDCLOTRLT.INS_TYPE, "SI", strlen("SI"));
		TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
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
		CDB_init_cedclotfqc(&CEDCLOTFQC);  ////[IS-20-08-004]
		
	}
	//CEDCLOTRLT.INS_TYPE = FC가 있다면 RE_JUDGE = Y
	//MES OI - FQC Judgment에서만 사용한다
	else
	{
		TRS.add_string(out_node, "RE_JUDGE", "Y", sizeof("Y"));

		//[IS-20-08-004]FQC 결과 조회시 CEDCLOTFQC 에서 CELL_INFO(셀정보),DEFECT_CODE(디펙 코드 정보를 가져온다)
	    if(strcmp(TRS.get_string(in_node, "INS_TYPE"), "FC") == 0)
		{
			CDB_init_cedclotfqc(&CEDCLOTFQC);
			TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
			memcpy(CEDCLOTFQC.INS_TYPE, "FC", strlen("FC"));
			TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
			CDB_select_cedclotfqc(2, &CEDCLOTFQC);
				    
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					/*strcpy(s_msg_code, "WIP-0044");
					TRS.add_fieldmsg(out_node, "CEDCLOTFQC SELECT", MP_NVST);
						
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTFQC.INS_TYPE), CEDCLOTFQC.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTFQC.LOT_ID), CEDCLOTFQC.LOT_ID);

					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;*/
				}
				else
				{

					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CEDCLOTFQC SELECT", MP_NVST);
						
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTFQC.INS_TYPE), CEDCLOTFQC.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTFQC.LOT_ID), CEDCLOTFQC.LOT_ID);

					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

			}
	 	}	
		//[IS-20-08-004]

	}

	



	//MES OI - Module Packing에서만 사용한다
	if (TRS.get_char(in_node, "PACK_VALIDATE_FLAG") == 'Y')
	{
		//PACKING 에서 LOT VALIDATION 을 위해 보낸데이터 일경우 체크
		

		//TERMINATE 된 LOT인지 체크
		// SEL MWIPLOTSTS
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY));	
		memcpy(MWIPLOTSTS.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
		DBC_select_mwiplotsts(mwiplotsts_flag, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0044");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		//이미 TERMINATE 된 LOT CHECK
		if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
		{
			//TERMINATE 정보가 있으면 에러처리함.
			strcpy(s_msg_code, "WIP-0594");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);  // Server Crash
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, CEDCLOTRLT.FACTORY,sizeof(CEDCLOTRLT.FACTORY));
		memcpy(CWIPLOTPAK.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
		
		//C: COMPLETE,  I:INITIAL(AUTO PACKING 에서 사용함)	, //D: ERP->MES PACKING 해제된 LOT
		CWIPLOTPAK.STATUS_FLAG = 'C';  

		//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 재PACKING 못하게함.
		if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
		{
			//완료된 PACKING 정보가 있으면 에러처리함.
			strcpy(s_msg_code, "WIP-0564");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID); // Server Crash
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
        }
		// 패킹에서 ERP 실적 확인하는 로직 추가	40번 공정이 I/F되지 않았으면 패킹이 되지 않게 로직 수정.
        // FQC I/F 값이 있는지 CHECK! 
        /*
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID, strlen(HQCEL_M1_ERP_SITE_ID));
		memcpy(IERPOPRCFM.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
		memcpy(IERPOPRCFM.OPER_NO, "0040", 4);
		if (CDB_select_ierpoprcfm_scalar(5, &IERPOPRCFM) <= 0)
		{
            strcpy(s_msg_code, "WIP-0598");
			TRS.add_fieldmsg(out_node, "IERPOPRCFM SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, strlen(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

            TRS.set_fieldmsg(out_node, "FILE", MP_NSTR, __FILE__);
            TRS.set_fieldmsg(out_node, "LINE", MP_INT,  __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        */
        // 패킹에서 ERP 실적 확인하는 로직 추가	40번 공정이 I/F되지 않았으면 패킹이 되지 않게 로직 수정.
        // 재판정시 FQC I/F 값이 있는지 CHECK! 
        ////////////////////////
        /*
        CDB_init_ierpoprcfm(&IERPOPRCFM);													
		        memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID, strlen(HQCEL_M1_ERP_SITE_ID));											
		        memcpy(IERPOPRCFM.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));											
		        memcpy(IERPOPRCFM.OPER_NO, "0040", 4);											
		        CDB_select_ierpoprcfm(3, &IERPOPRCFM);											
        if(DB_error_code != DB_SUCCESS)													
        {													
													
        }													

        if(IERPOPRCFM.ZPISTAT != 'S' && IERPOPRCFM.ZPISTAT != 'P')												
        {													
            strcpy(s_msg_code, "WIP-0598");													
			            TRS.add_fieldmsg(out_node, "IERPOPRCFM SELECT", MP_NVST);										
			            TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, strlen(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);										
													
            TRS.set_fieldmsg(out_node, "FILE", MP_NSTR, __FILE__);													
            TRS.set_fieldmsg(out_node, "LINE", MP_INT,  __LINE__);													
													
			            gs_log_type.type = MP_LOG_ERROR;										
			            gs_log_type.e_type = MP_LOG_E_SYSTEM;										
			            gs_log_type.category = MP_LOG_CATE_VIEW;										
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));													
            return MP_FALSE;													
        }
        */
		//LOT의 PACKING GROUP
		CDB_init_mgcmlagdat(&MGCMLAGDAT);
		TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
		memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
		memcpy(MGCMLAGDAT.KEY_1, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));
		CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
			//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);  // server Crash
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);  // server Crash
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//제품의 PACKING 그룹
		CDB_init_mgcmlagdat(&MGCMLAGDAT_MAT);
		TRS.copy(MGCMLAGDAT_MAT.FACTORY, sizeof(MGCMLAGDAT_MAT.FACTORY), in_node, "FACTORY");
		memcpy(MGCMLAGDAT_MAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
		TRS.copy(MGCMLAGDAT_MAT.KEY_1, sizeof(MGCMLAGDAT_MAT.KEY_1), in_node, "IN_MAT_ID");
		CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAT);
		if (DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		/******************
		혼류조건[AS-IS]
		1)    포장 시 A급, B급, C급, Scrap 등 전 모듈 등급 혼류 불가
		2)    A급의 경우, 동일 제품(제품군 아님) 동일 PowerClass 만 포장 가능
		3)    B급의 경우, 동일 제품군(제품 아님) 동일 PowerClass 만 포장 가능
		4)    C급, Scrap의 경우, 동일 제품군(제품 아님) 중 서로 다른 PowerClass도 포장 가능

		-> [TO-BE] : 3 / 4 번 조건 삭제 및 변경
		1)    포장 시 A급, B급, C급, Scrap 등 전 모듈 등급 혼류 불가
		2)    A급의 경우, 동일 제품(제품군 아님) 동일 PowerClass 만 포장 가능
		3)	  B급, C급, Scrap의 경우, 서로 다른 Power Class와 서로 다른 제품군도 포장 가능

		05/27 IS-22-05-076 [프로그램_변경]B Grade Packing Logic 수정
		1) B급의 경우도 A급의 경우와 동일하게, 동일 제품(제품군 아님) 동일 PowerClass 만 포장 가능 하도록 수정.
		*******************/

		//1)    포장 시 A급, B급, C급, Scrap 등 전 모듈 등급 혼류 불가
		if((memcmp(CEDCLOTRLT.GRADE, TRS.get_string(in_node, "IN_GRADE"), strlen(TRS.get_string(in_node, "IN_GRADE"))) != 0) &&
			COM_isnullspace(TRS.get_string(in_node, "IN_GRADE")) == MP_FALSE)
		{




			strcpy(s_msg_code, "WIP-0569");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
			//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID); // server Crash
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID); // server Crash
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//2)    A급(G01,G02) 의 경우, 동일 제품(제품군 아님) 동일 PowerClass 만 포장 가능
		/*
				05/27 IS-22-05-076 [프로그램_변경]B Grade Packing Logic 수정
				1) B급의 경우도 A급의 경우와 동일하게, 동일 제품(제품군 아님) 동일 PowerClass 만 포장 가능 하도록 수정.
		*/

		/* - [GERP PROJECT] 시작****************************************************************/
		/*
		memset(tmp_Mat, 0x00, sizeof(tmp_Mat));
		memset(tmp_Mat2, 0x00, sizeof(tmp_Mat2));
		memcpy(tmp_Mat, CEDCLOTRLT.MAT_ID, sizeof(tmp_Mat));
		TRS.copy(tmp_Mat2, sizeof(tmp_Mat2), in_node, "IN_MAT_ID");*/
		/* - [GERP PROJECT] 끝*****************************************************************/

		if((memcmp(TRS.get_string(in_node, "IN_GRADE"), "G01", strlen("G01")) == 0) ||
			(memcmp(TRS.get_string(in_node, "IN_GRADE"), "G02", strlen("G02")) == 0) ||
			(memcmp(TRS.get_string(in_node, "IN_GRADE"), "G03", strlen("G03")) == 0) ||			//--[G03/G04 로직 추가]
			(memcmp(TRS.get_string(in_node, "IN_GRADE"), "G04", strlen("G04")) == 0) ||			//--[G03/G04 로직 추가]
			(memcmp(TRS.get_string(in_node, "IN_GRADE"), "B", strlen("B")) == 0) )
		{
			//동일제품 여부 확인 
			if((memcmp(CEDCLOTRLT.MAT_ID, TRS.get_string(in_node, "IN_MAT_ID"), strlen(TRS.get_string(in_node, "IN_MAT_ID"))) != 0) && 
				COM_isnullspace(TRS.get_string(in_node, "IN_MAT_ID")) == MP_FALSE)
			{

				/* - [GERP PROJECT] 시작****************************************************************/
				// 숫자된 코드가 넘어오는 경우 CEDCLOTRLT.MAT_ID
				//신코드와 맵핑 하여 확인
				if(CEDCLOTRLT.MAT_ID[0] == '0')
				{
					CDB_init_mgcmlagdat(&MGCMLAGDAT_MAP);
					TRS.copy(MGCMLAGDAT_MAP.FACTORY, sizeof(MGCMLAGDAT_MAP.FACTORY), in_node, "FACTORY");
					memcpy(MGCMLAGDAT_MAP.TABLE_NAME, "@CONV_MAT_GERP", strlen("@CONV_MAT_GERP"));
					memcpy(MGCMLAGDAT_MAP.KEY_1, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));
					CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAP);
					if (DB_error_code == DB_SUCCESS)
					{
						//검사 실적의 값과 , 맵핑 코드가 다르면 에러.
						if((memcmp(MGCMLAGDAT_MAP.DATA_1, TRS.get_string(in_node, "IN_MAT_ID"), strlen(TRS.get_string(in_node, "IN_MAT_ID"))) != 0))
						{
							strcpy(s_msg_code, "WIP-0570");
							TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
						else		//만약 동일하면 검사 실적의 mat_id 변경
						{
							memset(CEDCLOTRLT.MAT_ID, ' ', sizeof(CEDCLOTRLT.MAT_ID));
							memcpy(CEDCLOTRLT.MAT_ID, MGCMLAGDAT_MAP.DATA_1, sizeof(CEDCLOTRLT.MAT_ID));


						}



					}
					else				
					{			//에러 출력
						strcpy(s_msg_code, "WIP-0570");
						TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
						gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}		
				}
				else
				{
						strcpy(s_msg_code, "WIP-0570");
						TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
						gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
				}


				/* - [GERP PROJECT] 끝*****************************************************************/

			/*	strcpy(s_msg_code, "WIP-0570");
				TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;*/
				/* - [GERP PROJECT] 시작****************************************************************/
				/*
				if (memcmp(tmp_Mat, "MD", strlen("MD")) != 0)
				{
					// 23.05.01동일 제품이지만 ASIS TOBE MATID 일경우
					CDB_init_mgcmlagdat(&MGCMLAGDAT_MAP);
					TRS.copy(MGCMLAGDAT_MAP.FACTORY, sizeof(MGCMLAGDAT_MAP.FACTORY), in_node, "FACTORY");
					memcpy(MGCMLAGDAT_MAP.TABLE_NAME, "@CONV_MAT_GERP", strlen("@CONV_MAT_GERP"));
					memcpy(MGCMLAGDAT_MAP.KEY_1, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));
					CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAP);
					if (DB_error_code == DB_SUCCESS)
					{
						memcpy(tmp_Mat, MGCMLAGDAT_MAP.DATA_1, sizeof(tmp_Mat));
					}
				}
				else if (memcmp(tmp_Mat2, "MD", strlen("MD")) != 0)
				{
					// 23.05.01동일 제품이지만 ASIS TOBE MATID 일경우
					CDB_init_mgcmlagdat(&MGCMLAGDAT_MAP);
					TRS.copy(MGCMLAGDAT_MAP.FACTORY, sizeof(MGCMLAGDAT_MAP.FACTORY), in_node, "FACTORY");
					memcpy(MGCMLAGDAT_MAP.TABLE_NAME, "@CONV_MAT_GERP", strlen("@CONV_MAT_GERP"));
					memcpy(MGCMLAGDAT_MAP.KEY_1, TRS.get_string(in_node, "IN_MAT_ID"), strlen(TRS.get_string(in_node, "IN_MAT_ID")));
					CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAP);
					if (DB_error_code == DB_SUCCESS)
					{
						memcpy(tmp_Mat2, MGCMLAGDAT_MAP.DATA_1, sizeof(tmp_Mat2));
					}
				}
				//if((memcmp(MGCMLAGDAT_MAP.DATA_1, TRS.get_string(in_node, "IN_MAT_ID"), strlen(TRS.get_string(in_node, "IN_MAT_ID"))) != 0))
				if ((memcmp(tmp_Mat, tmp_Mat2, sizeof(tmp_Mat)) != 0))
				{
					strcpy(s_msg_code, "WIP-0570");
					TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				*/
				/* - [GERP PROJECT] 끝*****************************************************************/
			}

			//동일 파워클라스
			if((memcmp(CEDCLOTRLT.POWER, TRS.get_string(in_node, "IN_POWER"), strlen(TRS.get_string(in_node, "IN_POWER"))) != 0) && 
				COM_isnullspace(TRS.get_string(in_node, "IN_POWER")) == MP_FALSE)
			{
				strcpy(s_msg_code, "WIP-0571");
				TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
								
		}
	}

    TRS.add_string(out_node, "LINE_ID", CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID));
    TRS.add_string(out_node, "OPER", CEDCLOTRLT.OPER, sizeof(CEDCLOTRLT.OPER));
    TRS.add_string(out_node, "RES_ID", CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID));

    TRS.add_string(out_node, "INS_VALUE", CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE));
    TRS.add_string(out_node, "RLT_COMMENT", CEDCLOTRLT.RLT_COMMENT, sizeof(CEDCLOTRLT.RLT_COMMENT));
    TRS.add_string(out_node, "RESULT_VALUE", CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));
    TRS.add_string(out_node, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
	TRS.add_string(out_node, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));

    TRS.add_string(out_node, "OSC", CEDCLOTRLT.OSC, sizeof(CEDCLOTRLT.OSC));
    TRS.add_string(out_node, "ESC", CEDCLOTRLT.ESC, sizeof(CEDCLOTRLT.ESC));
    TRS.add_string(out_node, "EL", CEDCLOTRLT.EL, sizeof(CEDCLOTRLT.EL));
	//TRS.add_string(out_node, "MAT_ID", CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));

	//[IS-20-08-004]FQC 결과 조회시 CEDCLOTFQC 에서 CELL_INFO(셀정보),DEFECT_CODE(디펙 코드 정보를 가져온다)
	if(strcmp(TRS.get_string(in_node, "INS_TYPE"), "FC") == 0)
	{
		TRS.add_string(out_node, "CELL_INFO", CEDCLOTFQC.CELL_INFO, sizeof(CEDCLOTFQC.CELL_INFO));
		TRS.add_string(out_node, "DEFECT_CODE", CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE))	;
			
	}
	//[IS-20-08-004]
	//IS-21-08-016 GAP LESS module의 cell 체크

	/* Get material(PRODUCT) information */

	// SEL MWIPLOTSTS
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY));	
	memcpy(MWIPLOTSTS.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
	DBC_select_mwiplotsts(mwiplotsts_flag, &MWIPLOTSTS);

	DBC_init_mwipmatdef(&MWIPMATDEF);
	memcpy(MWIPMATDEF.FACTORY, CEDCLOTRLT.FACTORY, sizeof(MWIPMATDEF.FACTORY));
	memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	MWIPMATDEF.MAT_VER = 1;

	DBC_select_mwipmatdef(1, &MWIPMATDEF);
	if(DB_error_code != DB_SUCCESS)
	{
	
	}
	//IS-21-08-016 GAP LESS module의 cell 체크

	TRS.add_string(out_node, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));

	/* - [GERP PROJECT] 시작****************************************************************/
	// 23.04.27 PACKING 시 구 제품 코드 > 신제품코드 변경이 가능 
	// 확인 이후 주석 제거 
	//if (TRS.get_char(in_node, "PACK_VALIDATE_FLAG") == 'Y')
	//{
	//	TRS.add_string(out_node, "MAT_ID", tmp_Mat, sizeof(tmp_Mat));
	//}
	//else
	//{
	// 23.04.27 재작업 시 ZBOM 변경 CASE
	if (rework_Flag == 'Y')
	{
		TRS.add_string(out_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	}
	else
	{
		TRS.add_string(out_node, "MAT_ID", CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));
	}
	//}
	/* - [GERP PROJECT] 끝*****************************************************************/
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

/*******************************************************************************
	CWIP_View_Fqc_Result_Validation()
		- Main sub function of "CWIP_VIEW_FQC_RESULT" function
		- Check the condition for View FQC Result
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Fqc_Result_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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
int CWIP_View_Rework_Lot_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	
	/* - [GERP PROJECT] 시작****************************************************************/
	struct CWIPRWKDAT_TAG CWIPRWKDAT;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
 
	/*
	재작업 모듈인경우 
	validation 1 : 포장이력(sap 입고, ZMDL)이 있는경우 재작업 오더 모듈리스트 에 포함 되어있어야 한다. 
	*/
	if (TRS.get_char(in_node, "PACK_VALIDATE_FLAG") == 'Y')
	{
		//포장공정에서는 처리 하지 않는다.  fqc판정시에만 처리한다. 
		return MP_TRUE;
	}
		
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID"); 
	if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
	{
		//재작업 선정 모듈 중 오더 2회 에 대하여 포장이력이 없는 것이 최종 재작업 오더의 모듈
		CDB_init_cwiprwkdat(&CWIPRWKDAT);
		memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "LOT_ID"); 
		
		//case 2 : Unpack 모듈 & 다시 Packing 되지 않음
		if(CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) == 0)
		{
			//[23.05.11] 주석제거 
			rework_Flag = MP_TRUE;
		}
	}
	/* - [GERP PROJECT] 끝*****************************************************************/
    return MP_TRUE;
}