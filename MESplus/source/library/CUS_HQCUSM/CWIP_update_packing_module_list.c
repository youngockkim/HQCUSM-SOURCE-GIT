/*******************************************************************************
 
    System      : MESplus
    Module      : Update packing module list
    File Name   : CWIP_update_packing_module_list.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018.12.27  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "UWIP_common.h"
#include "CUS_HQCUSM_common.h"
#include <string.h>

int CWIP_UPDATE_PACKING_MODULE_LIST(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);
int COM_Packing_Log_Client(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
int CWIP_View_Rework_Lot_Fqc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_View_AcModule_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]
/*******************************************************************************
    CWIP_Update_Fqc_Result()
        - Update Packing Module List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Packing_Module_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_PACKING_MODULE_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Update_Packing_Module_List", out_node);

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
	
	COM_Packing_Log_Client(s_msg_code, in_node, out_node);

    return MP_TRUE;
}


/*******************************************************************************
    CWIP_UPDATE_PACKING_MODULE_LIST()
        - UPDATE_PACKING_MODULE_LIST
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_PACKING_MODULE_LIST(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_AC;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_TEMP;
	struct CTMPLOTPAK_TAG CTMPLOTPAK;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CWIPACMHIS_TAG CWIPACMHIS;
	struct CWIPLOTPAK_TAG CWIPLOTPAK_AC;
	struct CWIPLOTPAK_TAG CWIPLOTPAK_O;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_MAP;

	/* - [GERP PROJECT] 시작****************************************************************/
    struct CWIPRWKDAT_TAG CWIPRWKDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_POW;
	struct CWIPABNLOG_TAG CWIPABNLOG; // 23.4.25 Log Add
	char pack_Flag = 'N';
	char pack_tmp[10];
	/* - [GERP PROJECT] 끝*****************************************************************/
	char s_sys_time[14];
	int i;
	int j;
	int k;
	int txtSize;
	int moduleQty;
	int moduleQty_diff;
	char packing_limit = 'N';
	

	TRSNode** list = TRS.get_list(in_node, "MODULE_PACK_LIST");
	
	TRSNode* tran_in_node;
	TRSNode* tran_out_node;
    TRSNode* check_in_node;
    TRSNode* check_out_node;   
	TRSNode* release_in_node;
	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_PACKING_MODULE_LIST");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	memset(pack_tmp, ' ', sizeof(pack_tmp)); // 23.4.24 Telegram Alam Add

	moduleQty = 0;
	moduleQty_diff = 0;

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
	
	TRS.add_string(out_node, "PACK_TIME", s_sys_time, sizeof(s_sys_time));

	CDB_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
	memcpy(MGCMTBLDAT.TABLE_NAME, "@VALIDATION_RULE", strlen("@VALIDATION_RULE"));
	memcpy(MGCMTBLDAT.KEY_1, "LIMIT_PACKING", strlen("LIMIT_PACKING"));
	CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
	if (DB_error_code == DB_SUCCESS)
	{
		//Nothing
	}
	// LIMIT_PACKING : Y이면 수량체크, N 이면 해제
	packing_limit = MGCMTBLDAT.DATA_2[0];


	if(TRS.get_procstep(in_node) == '2')
	{
		//AUTO

		if(TRS.get_int(in_node, "PACK_QTY") > TRS.get_item_count(in_node, "MODULE_PACK_LIST"))
		{
			strcpy(s_msg_code, "WIP-0574");

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else if(TRS.get_int(in_node, "PACK_QTY") < TRS.get_item_count(in_node, "MODULE_PACK_LIST"))
		{
			strcpy(s_msg_code, "WIP-0575");

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		/* PACKING ID CHECK */
		// 현재 PACKING ID 로 데이터가 있으면 PACKING 하지 못하게함. 
		// CLIENT 에서 다시 GEN 하고 변경된 PACKING ID 로 PACKING 되어야함.
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
		if (CDB_select_cwiplotpak_scalar(2, &CWIPLOTPAK) > 0)
		{
			strcpy(s_msg_code, "WIP-0562");
			TRS.add_fieldmsg(out_node, "CWIPLOTPACK COUNT SACLAR(2)", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
			TRS.add_fieldmsg(out_node, "PACKING ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		/* CREATE NODE */
		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");

		// init CWIPLOTPAK
		CCOM_copy_in_node(in_node, out_node);

		list = TRS.get_list(in_node, "MODULE_PACK_LIST");
		
		for (i=0; i< TRS.get_item_count(in_node, "MODULE_PACK_LIST"); i++)
		{
		
			CDB_init_ctmplotpak(&CTMPLOTPAK);
			TRS.copy(CTMPLOTPAK.FACTORY, sizeof(CTMPLOTPAK.FACTORY), in_node, "FACTORY");
			memcpy(CTMPLOTPAK.LOT_ID, TRS.get_string(list[i],"LOT_ID"), strlen(TRS.get_string(list[i],"LOT_ID")));
			CDB_select_ctmplotpak(1, &CTMPLOTPAK);
			if(DB_error_code != DB_SUCCESS)
			{  
				if(DB_error_code == DB_NOT_FOUND)
				{

				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CTMPLOTPAK INSERT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPLOTPAK.FACTORY), CTMPLOTPAK.FACTORY); 
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CTMPLOTPAK.LOT_ID), CTMPLOTPAK.LOT_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				}
			}
			else
			{
				// LOT SELECT
				DBC_init_mwiplotsts(&MWIPLOTSTS);
				memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(list[i],"LOT_ID"), strlen(TRS.get_string(list[i],"LOT_ID")));
				DBC_select_mwiplotsts(1, &MWIPLOTSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0044");
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);  // Server Crash
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);  // Server Crash
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				/* - [GERP PROJECT] 시작****************************************************************/
				/* 23.04.24 Packing Telegram INFO */
				if (COM_isspace(pack_tmp, sizeof(pack_tmp)) == MP_TRUE)
				{
					memcpy(pack_tmp, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				}
				else
				{
					if (memcmp(pack_tmp, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER))) {
						pack_Flag = HQCEL_FLAG_YES;
					}
				}

				memcpy(pack_tmp, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				/* - [GERP PROJECT] 끝*****************************************************************/
				
				//이미 TERMINATE 된 LOT CHECK
				if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
				{
					//TERMINATE 정보가 있으면 에러처리함.
					strcpy(s_msg_code, "WIP-0594");
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				/* - [GERP PROJECT] [ERP 23.05.29] HOLD LOT - 강제 RELEASE ****************************************************************/
				//HOLD 상태이면 RELEASE를 한다.
				if (MWIPLOTSTS.HOLD_FLAG == HQCEL_FLAG_YES)
				{
					release_in_node = TRS.create_node("RELEASE_LOT_IN");

					TRS.add_char(release_in_node, IN_PROCSTEP, '1');
					TRS.add_enc_nstring(release_in_node, IN_USERID, TRS.get_userid(in_node));
					TRS.add_char(release_in_node, IN_LANGUAGE, TRS.get_language(in_node));

					TRS.set_string(release_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
					TRS.set_string(release_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.set_int(release_in_node, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

					TRS.set_string(release_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
					TRS.set_int(release_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
					TRS.set_string(release_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
					TRS.set_int(release_in_node, "FLOW_SEQ_NO", MWIPLOTSTS.FLOW_SEQ_NUM);

					TRS.set_string(release_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.set_string(release_in_node, "RELEASE_CODE", HQCEL_RELEASE_ABN_MOVE, strlen(HQCEL_RELEASE_ABN_MOVE));

					TRS.set_char(release_in_node, "END_FLAG", 'Y');

					if (WIP_RELEASE_LOT(s_msg_code, release_in_node, out_node) == MP_FALSE)
					{
						TRS.free_node(release_in_node);
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					// RELEASE 후 LOT 재 조회 
					DBC_init_mwiplotsts(&MWIPLOTSTS);
					TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), list[i],"LOT_ID");
					DBC_select_mwiplotsts(1, &MWIPLOTSTS);

					TRS.free_node(release_in_node);
				}		
				/* - [GERP PROJECT] 끝*****************************************************************/

				//LOT 이 PACKING 공정이 아니면 PACKING 공정으로 이동
				//LOT 이 현재공정이 아니면 현재공정까지 END 시킴.
				//LOT에 대한 체크는 PACKING 화면에서 하나씩 읽을때 처리하고 이곳트랜잭션에서는 모든것을 성공해야함.
				if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_PACKING_OPER, strlen(HQCEL_M1_PACKING_OPER)) != 0)
				{
					/* - [GERP PROJECT] 시작****************************************************************/
					///23.03.23 LAKE JANG 추가
					/*등급 창고에 있는 경우는 END가 진행 되지 않아 스캔 된 LOT이 창고에 있다면 UNSTORE로 창고에서 빼온다.*/

					if (MWIPLOTSTS.INV_FLAG == HQCEL_FLAG_YES)
					{	
						TRS.set_char(in_node, "PACK_FLAG", HQCEL_FLAG_YES);
						if (CWIP_UPDATE_LOT_UNSTORE(s_msg_code, in_node, out_node, &MWIPLOTSTS) == MP_FALSE)
						{
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							//[23.05.11] free
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							return MP_FALSE;
						}
					}
					/* - [GERP PROJECT] 끝*****************************************************************/

					
					/***************************************************/
					//END LOT -> 강제로
					/***************************************************/
					TRS.init_node(tran_in_node);
					TRS.init_node(tran_out_node);

					CCOM_copy_in_node(in_node, tran_in_node);
					TRS.add_char(tran_in_node, "PROCSTEP", '1');
					TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
					TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
					TRS.add_string(tran_in_node, "FLOW",MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
					TRS.add_int(tran_in_node, "FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM); 
					TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			
					TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
					TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
					TRS.set_string(tran_in_node, "TO_OPER", HQCEL_M1_PACKING_OPER, strlen(HQCEL_M1_PACKING_OPER));

					if (MWIPLOTSTS.START_FLAG == 'Y')
					{
						TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
						if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
						{
							//DO NOTHING
						}
					}
					else
					{
						if (WIP_SKIP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
						{
							//DO NOTHING
						}
					}
			

					TRS.init_node(tran_in_node);
					TRS.init_node(tran_out_node);

					DBC_select_mwiplotsts(1, &MWIPLOTSTS);
					if(DB_error_code != DB_SUCCESS)
					{
						//DONOTHING
					}		
				}
				
			
				/// GRADE, POWER, MAT 체크
				check_in_node = TRS.create_node("CRC_Result_IN");
				check_out_node = TRS.create_node("CRC_Result_OUT");

				//Common In node 설정
				CCOM_copy_in_node(in_node, check_in_node);
				TRS.add_char(check_in_node, "PROCSTEP", '1');

				TRS.add_string(check_in_node,  "INS_TYPE", "FC", strlen("FC"));
				TRS.add_string(check_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));  
				TRS.add_char(check_in_node, "PACK_VALIDATE_FLAG", 'Y');
				TRS.set_nstring(check_in_node, "IN_POWER", TRS.get_string(in_node, "IN_POWER"));// 2023-03-08 JSLEE
				TRS.set_nstring(check_in_node, "IN_GRADE", TRS.get_string(in_node, "IN_GRADE"));
				TRS.set_nstring(check_in_node, "IN_MAT_ID", TRS.get_string(in_node, "IN_MAT_ID"));
				TRS.set_nstring(check_in_node, "IN_MODULETYPE", TRS.get_string(in_node, "IN_MODULETYPE"));
				if(CWIP_VIEW_FQC_RESULT(s_msg_code, check_in_node, check_out_node) == MP_FALSE)
				{
					//TRS.init_node(out_node);
					TRS.clone(out_node, check_out_node);
					TRS.free_node(check_in_node);
					TRS.free_node(check_out_node);
					
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				TRS.free_node(check_in_node);
				TRS.free_node(check_out_node);

				CDB_init_cwiplotpak(&CWIPLOTPAK);
				memcpy(CWIPLOTPAK.FACTORY, CTMPLOTPAK.FACTORY, sizeof(CTMPLOTPAK.FACTORY));
				memcpy(CWIPLOTPAK.LOT_ID, CTMPLOTPAK.LOT_ID, sizeof(CTMPLOTPAK.LOT_ID));
				CDB_select_cwiplotpak(1, &CWIPLOTPAK);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
				memcpy(CWIPLOTPAK.PALLET_ID, TRS.get_string(list[i],"PALLET_ID"), strlen(TRS.get_string(list[i],"PALLET_ID")));
				CWIPLOTPAK.PAK_SEQ = TRS.get_int(list[i],"PAK_SEQ");
				memset(CWIPLOTPAK.PAK_TYPE, ' ', sizeof(CWIPLOTPAK.PAK_TYPE));
				memcpy(CWIPLOTPAK.PAK_TYPE, CTMPLOTPAK.PAK_TYPE, sizeof(CTMPLOTPAK.PAK_TYPE));
				memcpy(CWIPLOTPAK.GRADE, CTMPLOTPAK.GRADE, sizeof(CTMPLOTPAK.GRADE));
				memcpy(CWIPLOTPAK.POWER, CTMPLOTPAK.POWER, sizeof(CTMPLOTPAK.POWER));
				/* - [GERP PROJECT] 시작****************************************************************/
				//제품 코드가 숫자로 시작 되면(구코드)
				//제품 코드를 구코드->신코드로 전환한다.
				if(MWIPLOTSTS.MAT_ID[0]== '0')
				{
					CDB_init_mgcmlagdat(&MGCMLAGDAT_MAP);
					TRS.copy(MGCMLAGDAT_MAP.FACTORY, sizeof(MGCMLAGDAT_MAP.FACTORY), in_node, "FACTORY");
					memcpy(MGCMLAGDAT_MAP.TABLE_NAME, "@CONV_MAT_GERP", strlen("@CONV_MAT_GERP"));
					memcpy(MGCMLAGDAT_MAP.KEY_1, CTMPLOTPAK.MAT_ID, sizeof(CTMPLOTPAK.MAT_ID));
					CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAP);
					if (DB_error_code == DB_SUCCESS)
					{
						memset(CWIPLOTPAK.MAT_ID, ' ', sizeof(CWIPLOTPAK.MAT_ID));
						memcpy(CWIPLOTPAK.MAT_ID, MGCMLAGDAT_MAP.DATA_1, sizeof(CWIPLOTPAK.MAT_ID));
					}
				}
				else
				{
					memcpy(CWIPLOTPAK.MAT_ID, CTMPLOTPAK.MAT_ID, sizeof(CTMPLOTPAK.MAT_ID));
				}


				/* - [GERP PROJECT] 끝*****************************************************************/

				

				memcpy(CWIPLOTPAK.OPER, CTMPLOTPAK.OPER, sizeof(CTMPLOTPAK.OPER));
				memcpy(CWIPLOTPAK.FLOW, CTMPLOTPAK.FLOW, sizeof(CTMPLOTPAK.FLOW));
				memcpy(CWIPLOTPAK.LINE_ID, CTMPLOTPAK.LINE_ID, sizeof(CTMPLOTPAK.LINE_ID));
				memcpy(CWIPLOTPAK.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID)); //2023.03.30 cWIPLOTPAK - FQC ORDER ID로 vallidation 되어 있음(필수)

				CWIPLOTPAK.STATUS_FLAG = 'C';  

				memcpy(CWIPLOTPAK.RES_ID, CTMPLOTPAK.RES_ID, sizeof(CTMPLOTPAK.RES_ID));
				memcpy(CWIPLOTPAK.CMF_1, TRS.get_string(list[i],"CMF_1"), strlen(TRS.get_string(list[i],"CMF_1")));
				memcpy(CWIPLOTPAK.CMF_2, TRS.get_string(list[i],"CMF_2"), strlen(TRS.get_string(list[i],"CMF_2")));
				memcpy(CWIPLOTPAK.CMF_3, TRS.get_string(list[i],"CMF_3"), strlen(TRS.get_string(list[i],"CMF_3")));
				memcpy(CWIPLOTPAK.CMF_4, "Y", 1);
				memcpy(CWIPLOTPAK.CMF_5, CTMPLOTPAK.CMF_5, sizeof(CTMPLOTPAK.CMF_5));

				memcpy(CWIPLOTPAK.PAK_TIME, s_sys_time, sizeof(s_sys_time));

				memcpy(CWIPLOTPAK.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));


				//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 재PACKING 못하게함.
				if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
				{
					//완료된 PACKING 정보가 있으면 에러처리함.
				    strcpy(s_msg_code, "WIP-0564");
					TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
					//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID); // Server Crash
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID); // Server Crash
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				/* - [GERP PROJECT] 시작****************************************************************/
				/*Rework Module FQC Check*/
				TRS.set_string(in_node, "REWORK_ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				TRS.set_string(in_node, "REWORK_MODULE_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				if(CWIP_View_Rework_Lot_Fqc_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				/* - [GERP PROJECT] 끝*****************************************************************/
				//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]-START
				if(memcmp(CWIPLOTPAK.GRADE, "G01", strlen("G01")) == 0 
					||
					memcmp(CWIPLOTPAK.GRADE, "G02", strlen("G02")) == 0 )
					{
					if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) != 0)
					{
						if(CWIP_View_AcModule_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
						{
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
					}
				}
				//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]-END

				if (COM_isspace(CWIPLOTPAK.CREATE_TIME, sizeof(CWIPLOTPAK.CREATE_TIME)) == MP_TRUE)
				{
					//기존 데이터가 없을경우만 CREATE TIME 변경함 : EMI 데이터복제시 문제되어..
					memcpy(CWIPLOTPAK.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
				}

				if(i == 0)
				{
					//[AC모듈]대상인경우
					CDB_init_mgcmlagdat(&MGCMLAGDAT_AC);
		 			memcpy(MGCMLAGDAT_AC.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
					memcpy(MGCMLAGDAT_AC.TABLE_NAME, "@PACKING", strlen("@PACKING"));
					memcpy(MGCMLAGDAT_AC.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
					CDB_select_mgcmlagdat(2, &MGCMLAGDAT_AC);
				}

				//Just One : Check MAT_ID Packing Qty
				
				CDB_init_mgcmlagdat(&MGCMLAGDAT_TEMP);
				memcpy(MGCMLAGDAT_TEMP.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
				memcpy(MGCMLAGDAT_TEMP.TABLE_NAME, "@PACKING", strlen("@PACKING"));
				memcpy(MGCMLAGDAT_TEMP.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));

				moduleQty_diff = (int)CDB_select_mgcmlagdat_scalar(4, &MGCMLAGDAT_TEMP);
				if(i > 0)
				{
					if(moduleQty != moduleQty_diff)
					{
						strcpy(s_msg_code, "WIP-0606");
						TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT_TEMP.TABLE_NAME), MGCMLAGDAT_TEMP.TABLE_NAME);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MGCMLAGDAT_TEMP.KEY_1), MGCMLAGDAT_TEMP.KEY_1);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
					
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				moduleQty =  moduleQty_diff;
				
				/**
				 3. SAP의 AC모듈이면서 G01/G02 포장의 경우
				 1) 인버터 데이터 있으면(자리수 체크 포함) 아니면 OK
				 2) 인버터 데이터 없거나, 자리수 다르면 NG
				**/
				if(memcmp(MGCMLAGDAT_AC.DATA_10, "Y", strlen("Y")) == 0)
				{
					if(memcmp(CWIPLOTPAK.GRADE, "G01", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G02", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G03", 3) == 0|| memcmp(CWIPLOTPAK.GRADE, "G04", 3) == 0)	//--[G03/G04 로직 추가]
					{
						for(txtSize = 0; MWIPLOTSTS.LOT_CMF_15[txtSize] != ' '; ++txtSize);

						if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) == 0)
						{
							//[AC ALARM]인버터 ID가 없습니다.
							strcpy(s_msg_code, "WIP-0610");
							TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
							TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
							TRS.add_dberrmsg(out_node, DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}

						if(txtSize != 12){
							//[AC ALARM]잘못된 인버터 ID 자리수를 가지고 있습니다.
							strcpy(s_msg_code, "WIP-0607");
							TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
							TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
							TRS.add_dberrmsg(out_node, DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}

						CDB_init_cwiplotpak(&CWIPLOTPAK_AC);
						memcpy(CWIPLOTPAK_AC.FACTORY, MWIPLOTSTS.FACTORY,sizeof(MWIPLOTSTS.FACTORY));
						memcpy(CWIPLOTPAK_AC.PCU_SN, MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
			
						if (CDB_select_cwiplotpak_scalar(5, &CWIPLOTPAK_AC) > 0)
						{
							strcpy(s_msg_code, "WIP-0612");
							TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
							TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
							TRS.add_dberrmsg(out_node, DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}


						//OK
						//CWIPLOTPAK.PVM_PN, CWIPLOTPAK.PVM_SN, PCU_SN, ACM_SN µî·Ï
						CDB_init_cwipacmhis(&CWIPACMHIS);
						memcpy(CWIPACMHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
						//memcpy(CWIPACMHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						memcpy(CWIPACMHIS.PCU_SN, MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
						memcpy(CWIPACMHIS.CMF_1, "D", sizeof("D"));

						CDB_select_cwipacmhis(3, &CWIPACMHIS);

						/**
						1. LOT마스터의 LOT_ID / 인버터ID로 인버터 데이터 크로스체크하여 다르면 ERROR								
						**/
						if(memcmp(MWIPLOTSTS.LOT_ID, CWIPACMHIS.LOT_ID, sizeof(CWIPACMHIS.LOT_ID)) == 0)
						{//크로스체크
						
							memcpy(CWIPLOTPAK.PVM_PN, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
							memcpy(CWIPLOTPAK.PVM_SN, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
							memcpy(CWIPLOTPAK.PCU_SN, CWIPACMHIS.PCU_SN, sizeof(CWIPACMHIS.PCU_SN));
							memcpy(CWIPLOTPAK.ACM_SN, CWIPACMHIS.ACM_SN, sizeof(CWIPACMHIS.ACM_SN));
						
						}
						else
						{
							//error
							strcpy(s_msg_code, "WIP-0611");//[AC ALARM]잘못된 인버터ID이거나 정보를 가지고 있습니다. 
							TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
							TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS.LOT_ID), CWIPACMHIS.LOT_ID);
							TRS.add_dberrmsg(out_node, DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
					}
					else if(memcmp(CWIPLOTPAK.GRADE, "B", 1) == 0)
					{
						/*Do Nothing*/
					}
				}
				else
				{
					if(memcmp(CWIPLOTPAK.GRADE, "G01", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G02", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "B", 1) == 0 || memcmp(CWIPLOTPAK.GRADE, "G03", 3) == 0|| memcmp(CWIPLOTPAK.GRADE, "G04", 3) == 0) //--[G03/G04 로직 추가]
					{
						if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) != 0 )
						{
							strcpy(s_msg_code, "WIP-0608"); // [AC ALARM]AC모듈 대상이 아닙니다. 인버터ID 정보가 존재합니다.
							TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
							TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
							TRS.add_dberrmsg(out_node, DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
					}
				}

				//G01/G02가 아닌 B/C/Z 포장
				/**
				4. 전 모듈 대상 B/C/Z 포장의 경우
				1) Inverter 장착 정보 한 개라도 존재하면 ERROR
				**/
				if(memcmp(CWIPLOTPAK.GRADE, "G01", 3) != 0 && memcmp(CWIPLOTPAK.GRADE, "G02", 3) != 0 && memcmp(CWIPLOTPAK.GRADE, "B", 1) != 0 && memcmp(CWIPLOTPAK.GRADE, "G03", 3) != 0 && memcmp(CWIPLOTPAK.GRADE, "G04", 3) != 0) //--[G03/G04 로직 추가]
				{
					if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) != 0)
					{
						//ERROR [AC ALARM]A등급외에는 인버터 ID를 가질 수 없습니다.
						strcpy(s_msg_code, "WIP-0609");
						TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
						TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
					
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}

				//삭제 로직 추가
				CDB_init_cwiplotpak(&CWIPLOTPAK_O);
				memcpy(CWIPLOTPAK_O.FACTORY, CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY)); // FACTORY
				memcpy(CWIPLOTPAK_O.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID)); // 모듈 번호
				CDB_delete_cwiplotpak(1, &CWIPLOTPAK_O);
				//삭제 로직 추가
				if(DB_error_code == DB_SUCCESS)
				{
					LOG_head("DELETE START");
					LOG_add("DELETE LOT_ID : ", MP_NSTR,CWIPLOTPAK_O.LOT_ID); 
					COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
				}

				CDB_init_cwiplotpak(&CWIPLOTPAK_O);
				memcpy(CWIPLOTPAK_O.FACTORY, CWIPLOTPAK.FACTORY, sizeof(struct CWIPLOTPAK_TAG));//스트럭쳐 copy
				CDB_insert_cwiplotpak(&CWIPLOTPAK_O);
				//CDB_insert_cwiplotpak(&CWIPLOTPAK);				
				if(DB_error_code != DB_SUCCESS)
				{
		
					strcpy(s_msg_code, "BAS-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;		
					
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				// MWIPELTSTS PALLET ID UPDATE
				CDB_init_mwipeltsts(&MWIPELTSTS);
				memcpy(MWIPELTSTS.LOT_ID, TRS.get_string(list[i],"LOT_ID"), strlen(TRS.get_string(list[i],"LOT_ID")));
				memcpy(MWIPELTSTS.PALLET_ID, TRS.get_string(list[i],"PALLET_ID"), strlen(TRS.get_string(list[i],"PALLET_ID")));
				memcpy(MWIPELTSTS.PAK_MOD_TYPE, TRS.get_string(list[i],"PAK_TYPE"), strlen(TRS.get_string(list[i],"PAK_TYPE")));
				CDB_update_mwipeltsts(3,&MWIPELTSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					// Nothing
				}

				/* - [GERP PROJECT] 시작****************************************************************/
				// CWIPRWKDAT PALLET ID UPDATE 2023-03-30 재작업 포장시 
				CDB_init_cwiprwkdat(&CWIPRWKDAT);
				memcpy(CWIPRWKDAT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				memcpy(CWIPRWKDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(CWIPRWKDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				//CDB_select_cwiprwkdat(1,&CWIPRWKDAT);
				CDB_select_cwiprwkdat(4, &CWIPRWKDAT); // 취소 된 재작업 제외 
				if(DB_error_code != DB_SUCCESS)
				{
					// Nothing
				}
				else
				{
					memcpy(CWIPRWKDAT.PALLET_ID, TRS.get_string(list[i],"PALLET_ID"), strlen(TRS.get_string(list[i],"PALLET_ID")));
					//[ERP 23.05.26] PACKING TIME 
					memcpy(CWIPRWKDAT.PAK_TIME, s_sys_time, sizeof(CWIPRWKDAT.PAK_TIME));
					CDB_update_cwiprwkdat(1,&CWIPRWKDAT);
					if(DB_error_code != DB_SUCCESS)
					{
						// Nothing
					}
				}

				/***************************************************/
				//END LOT
				/***************************************************/
				//CDB_init_mgcmlagdat(&MGCMLAGDAT_POW); // 23.04.18 POWER_RANGE 파워값 가져옴
				//memcpy(MGCMLAGDAT_POW.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				//memcpy(MGCMLAGDAT_POW.TABLE_NAME, "@POWER_RANGE", strlen("@POWER_RANGE"));
				//memcpy(MGCMLAGDAT_POW.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				//memcpy(MGCMLAGDAT_POW.KEY_2, CWIPLOTPAK.GRADE, sizeof(CWIPLOTPAK.GRADE));
				//memcpy(MGCMLAGDAT_POW.KEY_3, CWIPLOTPAK.POWER, sizeof(CWIPLOTPAK.POWER));
				////CWIPLOTPAK.GRADE
				//CDB_select_mgcmlagdat(3, &MGCMLAGDAT_POW);
				
				//[23.06.13]ZMDL 출력시 POWER RANGE->ZMDL로 변경 되도록 함(ZBOM + POWER 값)
				j = 0;
				k = 0;
				CDB_init_mgcmlagdat(&MGCMLAGDAT_POW);
				j = COM_string_length(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				if(j > 0)
				{
					memcpy(MGCMLAGDAT_POW.DATA_4, MWIPLOTSTS.MAT_ID, j);
					MGCMLAGDAT_POW.DATA_4[j] = '-';
				}
				k = COM_string_length(CWIPLOTPAK.POWER, sizeof(CWIPLOTPAK.POWER));	
				if(k==1)	//power 값이 1자리인경우
				{
					MGCMLAGDAT_POW.DATA_4[j+1] = '0';
					MGCMLAGDAT_POW.DATA_4[j+2] = '0';
					MGCMLAGDAT_POW.DATA_4[j+3] = '0';
					MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[0];
				}
				else if (k == 2)	//power 값이 2자리인경우
				{
					MGCMLAGDAT_POW.DATA_4[j+1] = '0';
					MGCMLAGDAT_POW.DATA_4[j+2] = '0';
					MGCMLAGDAT_POW.DATA_4[j+3] = CWIPLOTPAK.POWER[0];	
					MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[1];	
				}
				else if (k == 3)	//power 값이 3자리인경우
				{
					MGCMLAGDAT_POW.DATA_4[j+1] = '0';
					MGCMLAGDAT_POW.DATA_4[j+2] = CWIPLOTPAK.POWER[0];	
					MGCMLAGDAT_POW.DATA_4[j+3] = CWIPLOTPAK.POWER[1];	
					MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[2];	
				}
				else if (k == 4)	//power 값이 4자리인경우
				{
					MGCMLAGDAT_POW.DATA_4[j+1] = CWIPLOTPAK.POWER[0];	
					MGCMLAGDAT_POW.DATA_4[j+2] = CWIPLOTPAK.POWER[1];	
					MGCMLAGDAT_POW.DATA_4[j+3] = CWIPLOTPAK.POWER[2];		
					MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[3];	
				}
				//[23.06.13]ZMDL 출력시 POWER RANGE->ZMDL로 변경 되도록 함(ZBOM + POWER 값)


				//MGCMLAGDAT_POW

				TRS.init_node(tran_in_node);
				TRS.init_node(tran_out_node);
		
				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
				TRS.set_string(tran_in_node, "TRAN_CMF_19",  MGCMLAGDAT_POW.DATA_4, sizeof(MWIPLOTSTS.LOT_CMF_19)); // 23.04.18 MWIPLOTHIS TRAN_CMF_19 ZMDL 품번 저장
				
				//User Routine End 에서 ERP I/F 호출안하도록 'Y' 로 셋팅
				TRS.set_char(tran_in_node, "_SKIP_ERP_IF", 'Y');

				memcpy(MWIPLOTSTS.LOT_CMF_19, MGCMLAGDAT_POW.DATA_4, sizeof(MWIPLOTSTS.LOT_CMF_19)); // 23.04.18 LOT END 전 MWIPLOTSTS CMF_19 ZMDL 품번 저장
				DBC_update_mwiplotsts(1, &MWIPLOTSTS);

				if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					TRS.clone(out_node, tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					return MP_FALSE;
				}
				//[23.05.11] Free node 잘못됨
				//TRS.free_node(tran_in_node);
				//TRS.free_node(tran_out_node);
				/* - [GERP PROJECT] 끝*****************************************************************/

				CDB_delete_ctmplotpak(1, &CTMPLOTPAK);
				if(DB_error_code != DB_SUCCESS)
				{ 
					strcpy(s_msg_code, "WIP-0004"); 
					TRS.add_fieldmsg(out_node, "CTMPLOTPAK DELETE", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPLOTPAK.FACTORY), CTMPLOTPAK.FACTORY); 
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CTMPLOTPAK.LOT_ID), CTMPLOTPAK.LOT_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 

					//[23.05.11] Free node 잘못됨
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					return MP_FALSE; 
				}
			}
		}
	}
	else
	{
		//MANUAL
		/* PACKING ID CHECK */
		// 현재 PACKING ID 로 데이터가 있으면 PACKING 하지 못하게함. 
		// CLIENT 에서 다시 GEN 하고 변경된 PACKING ID 로 PACKING 되어야함.
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
		if (CDB_select_cwiplotpak_scalar(2, &CWIPLOTPAK) > 0)
		{
			strcpy(s_msg_code, "WIP-0562");
			TRS.add_fieldmsg(out_node, "CWIPLOTPACK COUNT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
			TRS.add_fieldmsg(out_node, "PACKING ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		/* CREATE NODE */
		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");

		// init CWIPLOTPAK
		CCOM_copy_in_node(in_node, out_node);

		list = TRS.get_list(in_node, "MODULE_PACK_LIST");

		for (i=0; i< TRS.get_item_count(in_node, "MODULE_PACK_LIST"); i++)
		{
		
			// LOT SELECT
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(list[i],"LOT_ID"), strlen(TRS.get_string(list[i],"LOT_ID")));
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0044");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID); // Server Crash
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID); // Server Crash
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				
				return MP_FALSE;
			}

			if( i == 0 )
			{  
				//메뉴얼 패킹 첫번째 모듈
				TRS.set_string(out_node, "PACK_LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			}

			/* - [GERP PROJECT] 시작****************************************************************/
			/* 23.04.24 Packing Telegram Info*/
			if (COM_isspace(pack_tmp, sizeof(pack_tmp)) == MP_TRUE)
			{
				memcpy(pack_tmp, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			}
			else 
			{
				if (memcmp(pack_tmp, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER))) {
					pack_Flag = HQCEL_FLAG_YES;
				}
			}
			/* - [GERP PROJECT] 끝*****************************************************************/

			/* - [GERP PROJECT] [ERP 23.05.26] 시작****************************************************************/
			// CWIPRWKDAT PALLET ID UPDATE 2023-03-30 재작업 포장시 
			CDB_init_cwiprwkdat(&CWIPRWKDAT);
			memcpy(CWIPRWKDAT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CWIPRWKDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(CWIPRWKDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			CDB_select_cwiprwkdat(4, &CWIPRWKDAT); // 취소 된 재작업 제외 
			if(DB_error_code != DB_SUCCESS)
			{
				// Nothing
			}
			else
			{
				TRS.copy(CWIPRWKDAT.PALLET_ID, sizeof(CWIPRWKDAT.PALLET_ID), in_node, "PALLET_ID");
				memcpy(CWIPRWKDAT.PAK_TIME, s_sys_time, sizeof(CWIPRWKDAT.PAK_TIME));
				CDB_update_cwiprwkdat(1,&CWIPRWKDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					// Nothing
				}
			}
			/* - [GERP PROJECT] 끝*****************************************************************/

			/* - [GERP PROJECT] [ERP 23.05.29] HOLD LOT - 강제 RELEASE ****************************************************************/
			//HOLD 상태이면 RELEASE를 한다.
			if (MWIPLOTSTS.HOLD_FLAG == HQCEL_FLAG_YES)
			{
				release_in_node = TRS.create_node("RELEASE_LOT_IN");

				TRS.add_char(release_in_node, IN_PROCSTEP, '1');
				TRS.add_enc_nstring(release_in_node, IN_USERID, TRS.get_userid(in_node));
				TRS.add_char(release_in_node, IN_LANGUAGE, TRS.get_language(in_node));

				TRS.set_string(release_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				TRS.set_string(release_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.set_int(release_in_node, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

				TRS.set_string(release_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.set_int(release_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
				TRS.set_string(release_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.set_int(release_in_node, "FLOW_SEQ_NO", MWIPLOTSTS.FLOW_SEQ_NUM);

				TRS.set_string(release_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				TRS.set_string(release_in_node, "RELEASE_CODE", HQCEL_RELEASE_ABN_MOVE, strlen(HQCEL_RELEASE_ABN_MOVE));

				TRS.set_char(release_in_node, "END_FLAG", 'Y');

				if (WIP_RELEASE_LOT(s_msg_code, release_in_node, out_node) == MP_FALSE)
				{
					TRS.free_node(release_in_node);
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				// RELEASE 후 LOT 재 조회 
				DBC_init_mwiplotsts(&MWIPLOTSTS);
				TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), list[i],"LOT_ID");
				DBC_select_mwiplotsts(1, &MWIPLOTSTS);

				TRS.free_node(release_in_node);
			}		
			/* - [GERP PROJECT] 끝*****************************************************************/

			/**/
			//LOT 이 PACKING 공정이 아니면 PACKING 공정으로 이동
			//LOT 이 현재공정이 아니면 현재공정까지 END 시킴.
			//LOT에 대한 체크는 PACKING 화면에서 하나씩 읽을때 처리하고 이곳트랜잭션에서는 모든것을 성공해야함.
			if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_PACKING_OPER, strlen(HQCEL_M1_PACKING_OPER)) != 0)
			{				
				/* - [GERP PROJECT] 시작****************************************************************/
				///23.03.23 LAKE JANG 추가
				/* 등급 창고에 있는 경우는 END가 진행 되지 않아 스캔 된 LOT이 창고에 있다면 UNSTORE로 창고에서 빼온다.*/
				if (MWIPLOTSTS.INV_FLAG == HQCEL_FLAG_YES)
				{
					TRS.set_char(in_node, "PACK_FLAG", HQCEL_FLAG_YES);
					if (CWIP_UPDATE_LOT_UNSTORE(s_msg_code, in_node, out_node, &MWIPLOTSTS) == MP_FALSE)
					{
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

						//[23.05.11] Free ~ 
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						return MP_FALSE;
					}		
				}
				/* - [GERP PROJECT] 끝*****************************************************************/

				/***************************************************/
				//END LOT -> 강제로
				/***************************************************/
				TRS.init_node(tran_in_node);
				TRS.init_node(tran_out_node);

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
				TRS.add_string(tran_in_node, "FLOW",MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.add_int(tran_in_node, "FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM); 
				TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			
				TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
				TRS.set_string(tran_in_node, "TO_OPER", HQCEL_M1_PACKING_OPER, strlen(HQCEL_M1_PACKING_OPER));

				if (MWIPLOTSTS.START_FLAG == 'Y')
				{
					TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
					if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
					{
						//DO NOTHING
					}
				}
				else
				{
					if (WIP_SKIP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
					{
						//DO NOTHING
					}
				}
			

				TRS.init_node(tran_in_node);
				TRS.init_node(tran_out_node);

				DBC_select_mwiplotsts(1, &MWIPLOTSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					//DONOTHING
				}		
			}
	
	
			CDB_init_cwiplotpak(&CWIPLOTPAK);
			memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CWIPLOTPAK.LOT_ID, TRS.get_string(list[i],"LOT_ID"), strlen(TRS.get_string(list[i],"LOT_ID")));
			CDB_select_cwiplotpak(1, &CWIPLOTPAK);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			memcpy(CWIPLOTPAK.PALLET_ID, TRS.get_string(list[i],"PALLET_ID"), strlen(TRS.get_string(list[i],"PALLET_ID")));
			CWIPLOTPAK.PAK_SEQ = TRS.get_int(list[i],"PAK_SEQ");
			memset(CWIPLOTPAK.PAK_TYPE, ' ', sizeof(CWIPLOTPAK.PAK_TYPE));
			memcpy(CWIPLOTPAK.PAK_TYPE, TRS.get_string(list[i],"PAK_TYPE"), strlen(TRS.get_string(list[i],"PAK_TYPE")));
			memcpy(CWIPLOTPAK.GRADE, TRS.get_string(list[i],"GRADE"), strlen(TRS.get_string(list[i],"GRADE")));
			memcpy(CWIPLOTPAK.POWER, TRS.get_string(list[i],"POWER"), strlen(TRS.get_string(list[i],"POWER")));
			
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
					memset(CWIPLOTPAK.MAT_ID, ' ', sizeof(CWIPLOTPAK.MAT_ID));
					memcpy(CWIPLOTPAK.MAT_ID, MGCMLAGDAT_MAP.DATA_1, sizeof(CWIPLOTPAK.MAT_ID));
				}
				else
				{
					//[ERP 23.05.29] 구코드 > 신코드 조회되지 않는다면 구 코드로
					memcpy(CWIPLOTPAK.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				}
			}
			else
			{
				memcpy(CWIPLOTPAK.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			}
			/* - [GERP PROJECT] 끝*****************************************************************/

			//memcpy(CWIPLOTPAK.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

			memcpy(CWIPLOTPAK.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			memcpy(CWIPLOTPAK.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			memcpy(CWIPLOTPAK.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID)); //2023.03.30 cWIPLOTPAK - FQC ORDER ID로 vallidation 되어 있음(필수)
			//memcpy(CWIPLOTPAK.LINE_ID, MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1)); // Server Crash 190925
			memcpy(CWIPLOTPAK.LINE_ID, MWIPLOTSTS.LOT_CMF_1, sizeof(CWIPLOTPAK.LINE_ID)); 

			//C: COMPLETE,  I:INITIAL(AUTO PACKING 에서 사용함)	, //D: ERP->MES PACKING 해제된 LOT
			if (TRS.get_char(in_node, "AUTO_PACKING_FLAG") == 'Y')
			{
				CWIPLOTPAK.STATUS_FLAG = 'I';  
			}
			else
			{
				CWIPLOTPAK.STATUS_FLAG = 'C';  
			}

			memcpy(CWIPLOTPAK.RES_ID, TRS.get_string(in_node,"RES_ID"), strlen(TRS.get_string(in_node,"RES_ID")));
			memcpy(CWIPLOTPAK.CMF_1, TRS.get_string(list[i],"CMF_1"), strlen(TRS.get_string(list[i],"CMF_1")));
			memcpy(CWIPLOTPAK.CMF_2, TRS.get_string(list[i],"CMF_2"), strlen(TRS.get_string(list[i],"CMF_2")));
			memcpy(CWIPLOTPAK.CMF_3, TRS.get_string(list[i],"CMF_3"), strlen(TRS.get_string(list[i],"CMF_3")));
			//memcpy(CWIPLOTPAK.CMF_4, TRS.get_string(list[i],"CMF_4"), strlen(TRS.get_string(list[i],"CMF_4")));
			memcpy(CWIPLOTPAK.CMF_4, " ", sizeof(" "));
			memcpy(CWIPLOTPAK.CMF_5, TRS.get_string(list[i],"CMF_5"), strlen(TRS.get_string(list[i],"CMF_5")));
			
			memcpy(CWIPLOTPAK.PAK_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(CWIPLOTPAK.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));

			//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 재PACKING 못하게함.
			if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
			{
				//완료된 PACKING 정보가 있으면 에러처리함.
				strcpy(s_msg_code, "WIP-0564");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
				//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID); // Server Crash
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID); // Server Crash
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				
				return MP_FALSE;
			}
			/* - [GERP PROJECT] 시작****************************************************************/
			/*Rework Module FQC Check*/
			TRS.set_string(in_node, "REWORK_ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			TRS.set_string(in_node, "REWORK_MODULE_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			if(CWIP_View_Rework_Lot_Fqc_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}
			/* - [GERP PROJECT] 끝*****************************************************************/
			//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]-START
			if(memcmp(CWIPLOTPAK.GRADE, "G01", strlen("G01")) == 0 
				||
				memcmp(CWIPLOTPAK.GRADE, "G02", strlen("G02")) == 0 )
				{
				if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) != 0)
				{
					if(CWIP_View_AcModule_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
					{
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
			}
			//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]-END

			//이미 TERMINATE 된 LOT CHECK
			if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
			{
				//TERMINATE 정보가 있으면 에러처리함.
				strcpy(s_msg_code, "WIP-0594");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				//[23.05.11] free
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				
				return MP_FALSE;
			}

			if (COM_isspace(CWIPLOTPAK.CREATE_TIME, sizeof(CWIPLOTPAK.CREATE_TIME)) == MP_TRUE)
			{
				//기존 데이터가 없을경우만 CREATE TIME 변경함 : EMI 데이터복제시 문제되어..
				memcpy(CWIPLOTPAK.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			}

			//Just One : Check MAT_ID AC inverter
			if(i == 0)
			{
				CDB_init_mgcmlagdat(&MGCMLAGDAT_AC);
		 		memcpy(MGCMLAGDAT_AC.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
				memcpy(MGCMLAGDAT_AC.TABLE_NAME, "@PACKING", strlen("@PACKING"));
				memcpy(MGCMLAGDAT_AC.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
				CDB_select_mgcmlagdat(2, &MGCMLAGDAT_AC);
			}
	
			CDB_init_mgcmlagdat(&MGCMLAGDAT_TEMP);
			memcpy(MGCMLAGDAT_TEMP.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
			memcpy(MGCMLAGDAT_TEMP.TABLE_NAME, "@PACKING", strlen("@PACKING"));
			memcpy(MGCMLAGDAT_TEMP.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));

			moduleQty_diff = (int)CDB_select_mgcmlagdat_scalar(4, &MGCMLAGDAT_TEMP);
			
			if(i > 0)
			{
				if(moduleQty != moduleQty_diff)
				{
					strcpy(s_msg_code, "WIP-0606");
					TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT_TEMP.TABLE_NAME), MGCMLAGDAT_TEMP.TABLE_NAME);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MGCMLAGDAT_TEMP.KEY_1), MGCMLAGDAT_TEMP.KEY_1);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			moduleQty =  moduleQty_diff;
			 
			/**
			3. SAP의 AC모듈이면서 G01/G02 포장의 경우
			 1) 인버터 데이터 있으면(자리수 체크 포함) 아니면 OK
			 2) 인버터 데이터 없거나, 자리수 다르면 NG
			**/
			if(memcmp(MGCMLAGDAT_AC.DATA_10, "Y", strlen("Y")) == 0)
			{
				if(memcmp(CWIPLOTPAK.GRADE, "G01", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G02", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G03", 3) == 0|| memcmp(CWIPLOTPAK.GRADE, "G04", 3) == 0) //--[G03/G04 로직 추가]
				{

					for(txtSize = 0; MWIPLOTSTS.LOT_CMF_15[txtSize] != ' '; ++txtSize);

					if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) == 0)
					{
						//[AC_ALARM] 인버터 ID가 없습니다.
						//ERROR
						strcpy(s_msg_code, "WIP-0610");
						TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
						TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						return MP_FALSE;
					}

					if(txtSize != 12){
						//[AC_ALARM] 잘못된 인버터 ID를 자리수를 가지고 있습니다.
						//ERROR
						strcpy(s_msg_code, "WIP-0607");
						TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
						TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						return MP_FALSE;
					}

					CDB_init_cwiplotpak(&CWIPLOTPAK_AC);
					memcpy(CWIPLOTPAK_AC.FACTORY, MWIPLOTSTS.FACTORY,sizeof(MWIPLOTSTS.FACTORY));
					memcpy(CWIPLOTPAK_AC.PCU_SN, MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
			
					if (CDB_select_cwiplotpak_scalar(5, &CWIPLOTPAK_AC) > 0)
					{
						strcpy(s_msg_code, "WIP-0612");
						TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
						TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						return MP_FALSE;
					}

					//OK
					//CWIPLOTPAK.PVM_PN, CWIPLOTPAK.PVM_SN, PCU_SN, ACM_SN µî·Ï
					CDB_init_cwipacmhis(&CWIPACMHIS);
					memcpy(CWIPACMHIS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
					//memcpy(CWIPACMHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					memcpy(CWIPACMHIS.PCU_SN, MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
					memcpy(CWIPACMHIS.CMF_1, "D", sizeof("D"));

					CDB_select_cwipacmhis(3, &CWIPACMHIS);

					/**
					1. LOT마스터의 LOT_ID / 인버터ID로 인버터 데이터 크로스체크하여 다르면 ERROR								
					**/
					if(memcmp(MWIPLOTSTS.LOT_ID, CWIPACMHIS.LOT_ID, sizeof(CWIPACMHIS.LOT_ID)) == 0){//크로스체크
						
						memcpy(CWIPLOTPAK.PVM_PN, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
						memcpy(CWIPLOTPAK.PVM_SN, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						memcpy(CWIPLOTPAK.PCU_SN, CWIPACMHIS.PCU_SN, sizeof(CWIPACMHIS.PCU_SN));
						memcpy(CWIPLOTPAK.ACM_SN, CWIPACMHIS.ACM_SN, sizeof(CWIPACMHIS.ACM_SN));
						
					}else{
						//error
						strcpy(s_msg_code, "WIP-0611");
						TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
						TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS.LOT_ID), CWIPACMHIS.LOT_ID);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						return MP_FALSE;
					}
				}
				else if(memcmp(CWIPLOTPAK.GRADE, "B", 1) == 0)
				{
					/*Do Nothing*/
				}
			}else{
				if(memcmp(CWIPLOTPAK.GRADE, "G01", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G02", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "B", 1) == 0 || memcmp(CWIPLOTPAK.GRADE, "G03", 3) == 0|| memcmp(CWIPLOTPAK.GRADE, "G04", 3) == 0){ //--[G03/G04 로직 추가]
					if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) != 0 ){
						strcpy(s_msg_code, "WIP-0608"); // [AC_ALARM]AC모듈이 포함되어 있습니다.
						TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
						TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
						return MP_FALSE;
					}
				}
			}

			//G01/G02가 아닌 B/C/Z 포장
			/**
			4. 전 모듈 대상 B/C/Z 포장의 경우
			1) Inverter 장착 정보 한 개라도 존재하면 ERROR
			**/
			if(memcmp(CWIPLOTPAK.GRADE, "G01", 3) != 0 && memcmp(CWIPLOTPAK.GRADE, "G02", 3) != 0 && memcmp(CWIPLOTPAK.GRADE, "G03", 3) != 0 && memcmp(CWIPLOTPAK.GRADE, "G04", 3) != 0){ //--[G03/G04 로직 추가]

				if(memcmp(MWIPLOTSTS.LOT_CMF_15, " ", strlen(" ")) != 0){
					//ERROR A이외의 등급은 인버터 ID를 가질 수 없습니다.
					strcpy(s_msg_code, "WIP-0609");
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
					TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
					
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
					return MP_FALSE;
				}
			}

			//삭제 로직 추가
			CDB_init_cwiplotpak(&CWIPLOTPAK_O);
			memcpy(CWIPLOTPAK_O.FACTORY, CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY)); // FACTORY
			memcpy(CWIPLOTPAK_O.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID)); // 모듈 번호
			CDB_delete_cwiplotpak(1, &CWIPLOTPAK_O);
			//삭제 로직 추가
			if (DB_error_code == DB_SUCCESS)
			{
				LOG_head("DELETE START");
				LOG_add("DELETE LOT_ID : ", MP_NSTR, CWIPLOTPAK.LOT_ID);
				COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}


			CDB_init_cwiplotpak(&CWIPLOTPAK_O);
			memcpy(CWIPLOTPAK_O.FACTORY, CWIPLOTPAK.FACTORY, sizeof(struct CWIPLOTPAK_TAG));//스트럭쳐 copy

			CDB_insert_cwiplotpak(&CWIPLOTPAK_O);

			if(DB_error_code != DB_SUCCESS)
			{
		
				strcpy(s_msg_code, "BAS-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;		
				
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}

			// MWIPELTSTS PALLET ID UPDATE
			CDB_init_mwipeltsts(&MWIPELTSTS);
			memcpy(MWIPELTSTS.LOT_ID, TRS.get_string(list[i],"LOT_ID"), strlen(TRS.get_string(list[i],"LOT_ID")));
			memcpy(MWIPELTSTS.PALLET_ID, TRS.get_string(list[i],"PALLET_ID"), strlen(TRS.get_string(list[i],"PALLET_ID")));
			memcpy(MWIPELTSTS.PAK_MOD_TYPE, TRS.get_string(list[i],"PAK_TYPE"), strlen(TRS.get_string(list[i],"PAK_TYPE")));
			CDB_update_mwipeltsts(3,&MWIPELTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				// Nothing
			}

			/* - [GERP PROJECT] 시작****************************************************************/
			// CWIPRWKDAT PALLET ID UPDATE
			CDB_init_cwiprwkdat(&CWIPRWKDAT);
			memcpy(CWIPRWKDAT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(CWIPRWKDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(CWIPRWKDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			//CDB_select_cwiprwkdat(1,&CWIPRWKDAT);
			CDB_select_cwiprwkdat(4, &CWIPRWKDAT); //취소된 재작업 제외
			if(DB_error_code != DB_SUCCESS)
			{
				// Nothing
			}
			else{
				memcpy(CWIPRWKDAT.PALLET_ID, TRS.get_string(list[i],"PALLET_ID"), strlen(TRS.get_string(list[i],"PALLET_ID")));
				CDB_update_cwiprwkdat(1,&CWIPRWKDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					// Nothing
				}
			}
			/* - [GERP PROJECT] 끝*****************************************************************/

			/***************************************************/
			//END LOT
			/***************************************************/
			/* - [GERP PROJECT] 시작****************************************************************/
			//CDB_init_mgcmlagdat(&MGCMLAGDAT_POW); // 23.04.18 POWER_RANGE 파워값 가져옴
			//memcpy(MGCMLAGDAT_POW.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
			//memcpy(MGCMLAGDAT_POW.TABLE_NAME, "@POWER_RANGE", strlen("@POWER_RANGE"));
			//memcpy(MGCMLAGDAT_POW.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			//memcpy(MGCMLAGDAT_POW.KEY_2, CWIPLOTPAK.GRADE, sizeof(CWIPLOTPAK.GRADE));
			//memcpy(MGCMLAGDAT_POW.KEY_3, CWIPLOTPAK.POWER, sizeof(CWIPLOTPAK.POWER));

			////CWIPLOTPAK.GRADE
			//CDB_select_mgcmlagdat(3, &MGCMLAGDAT_POW);

			//[23.06.13]ZMDL 출력시 POWER RANGE->ZMDL로 변경 되도록 함(ZBOM + POWER 값)
			j = 0;
			k = 0;
			CDB_init_mgcmlagdat(&MGCMLAGDAT_POW);
			j = COM_string_length(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			if(j > 0)
			{
				memcpy(MGCMLAGDAT_POW.DATA_4, MWIPLOTSTS.MAT_ID, j);
				MGCMLAGDAT_POW.DATA_4[j] = '-';
			}
			k = COM_string_length(CWIPLOTPAK.POWER, sizeof(CWIPLOTPAK.POWER));	
			if(k==1)	//power 값이 1자리인경우
			{
				MGCMLAGDAT_POW.DATA_4[j+1] = '0';
				MGCMLAGDAT_POW.DATA_4[j+2] = '0';
				MGCMLAGDAT_POW.DATA_4[j+3] = '0';
				MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[0];
			}
			else if (k == 2)	//power 값이 2자리인경우
			{
				MGCMLAGDAT_POW.DATA_4[j+1] = '0';
				MGCMLAGDAT_POW.DATA_4[j+2] = '0';
				MGCMLAGDAT_POW.DATA_4[j+3] = CWIPLOTPAK.POWER[0];	
				MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[1];	
			}
			else if (k == 3)	//power 값이 3자리인경우
			{
				MGCMLAGDAT_POW.DATA_4[j+1] = '0';
				MGCMLAGDAT_POW.DATA_4[j+2] = CWIPLOTPAK.POWER[0];	
				MGCMLAGDAT_POW.DATA_4[j+3] = CWIPLOTPAK.POWER[1];	
				MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[2];	
			}
			else if (k == 4)	//power 값이 4자리인경우
			{
				MGCMLAGDAT_POW.DATA_4[j+1] = CWIPLOTPAK.POWER[0];	
				MGCMLAGDAT_POW.DATA_4[j+2] = CWIPLOTPAK.POWER[1];	
				MGCMLAGDAT_POW.DATA_4[j+3] = CWIPLOTPAK.POWER[2];		
				MGCMLAGDAT_POW.DATA_4[j+4] = CWIPLOTPAK.POWER[3];	
			}
			//[23.06.13]ZMDL 출력시 POWER RANGE->ZMDL로 변경 되도록 함(ZBOM + POWER 값)
			//MGCMLAGDAT_POW

			TRS.init_node(tran_in_node);
			TRS.init_node(tran_out_node);
		
			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
			TRS.set_string(tran_in_node, "TRAN_CMF_19",  MGCMLAGDAT_POW.DATA_4, sizeof(MWIPLOTSTS.LOT_CMF_19)); // 23.04.18 MWIPLOTHIS TRAN_CMF_19 ZMDL 품번 저장
			
			//User Routine End 에서 ERP I/F 호출안하도록 'Y' 로 셋팅
			TRS.set_char(tran_in_node, "_SKIP_ERP_IF", 'Y');

			memcpy(MWIPLOTSTS.LOT_CMF_19, MGCMLAGDAT_POW.DATA_4, sizeof(MWIPLOTSTS.LOT_CMF_19)); // 23.04.18 LOT END 전 MWIPLOTSTS CMF_19 ZMDL 품번 저장
			DBC_update_mwiplotsts(1, &MWIPLOTSTS);
			if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}
			//[23.05.11] Free node 잘못됨
			//TRS.free_node(tran_in_node);
			//TRS.free_node(tran_out_node);
			/* - [GERP PROJECT] 끝*****************************************************************/
		}		
	}

	/* - [GERP PROJECT] 시작****************************************************************/
	// 다른 등급별 창고지만 같은 등급의 모듈 ( 23.04.24 )
	// [ERP 23.05.23] 혼합 패킹 시 Module 별 Log 저장 
	if (pack_Flag == HQCEL_FLAG_YES)
	{
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
		CDB_open_cwiplotpak(4, &CWIPLOTPAK);

		if (DB_error_code == DB_SUCCESS)
		{
			while (1)
			{
				CDB_fetch_cwiplotpak(4, &CWIPLOTPAK);
				if (DB_error_code == DB_NOT_FOUND)
				{
					CDB_close_cwiplotpak(4);
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
					CDB_close_cwiplotpak(4);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				// Save Log
				CDB_init_cwipabnlog(&CWIPABNLOG);
				memcpy(CWIPABNLOG.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CWIPABNLOG.LOG_TYPE, HQCEL_TEL_QCELL_PACKING, strlen(HQCEL_TEL_QCELL_PACKING));
				memcpy(CWIPABNLOG.PALLET_ID, CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));
				memcpy(CWIPABNLOG.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
				memcpy(CWIPABNLOG.CMF_1, CWIPLOTPAK.OPER, sizeof(CWIPLOTPAK.OPER));
				memcpy(CWIPABNLOG.CMF_2, CWIPLOTPAK.CMF_2, sizeof(CWIPLOTPAK.CMF_2));
				memcpy(CWIPABNLOG.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
				TRS.copy(CWIPABNLOG.TRAN_USER_ID, sizeof(CWIPABNLOG.TRAN_USER_ID), in_node, IN_USERID);
				memcpy(CWIPABNLOG.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
				TRS.copy(CWIPABNLOG.CREATE_USER_ID, sizeof(CWIPABNLOG.CREATE_USER_ID), in_node, IN_USERID);
				CDB_insert_cwipabnlog(&CWIPABNLOG);

			}
		}
	}
	/* - [GERP PROJECT] 끝*****************************************************************/

	/****************************************************************************/
	//// Module Packing I/F (MES -> ERP)
	/****************************************************************************/
	TRS.init_node(tran_in_node);
	TRS.init_node(tran_out_node);

	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');
	TRS.add_nstring(tran_in_node, "PALLET_ID", TRS.get_string(in_node,"PALLET_ID"));
		
	//Cleaving Full Cell Move ERP Interface 수행
	TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '6');
	if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
	{
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		return MP_FALSE;
	}

	/* FREE NODE */
 	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);


	/* PACKING QTY CHECK */
	// 현재 PACKING ID 로 PACKING 된 LIST 를 체크하여 수량이 맞지 않으면 동시에 한것이므로 다시 하도록 설정함. 
	// CLIENT 에서 다시 GEN 하고 변경된 PACKING ID 로 PACKING 되어야함.
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, "FACTORY");
	TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
	if (CDB_select_cwiplotpak_scalar(2, &CWIPLOTPAK) != TRS.get_item_count(in_node, "MODULE_PACK_LIST"))
	{
		strcpy(s_msg_code, "WIP-0562");
		TRS.add_fieldmsg(out_node, "CWIPLOTPACK COUNT SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
		TRS.add_fieldmsg(out_node, "PACKING ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}


	/*
	/제품군이 틀리면 PACKING 하면 안됨.
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, "FACTORY");
	TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
	CWIPLOTPAK.STATUS_FLAG = 'C';
	if (CDB_select_cwiplotpak_scalar(4, &CWIPLOTPAK) > 1)
	{
		strcpy(s_msg_code, "WIP-0576");
		TRS.add_fieldmsg(out_node, "CWIPLOTPACK COUNT SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
		TRS.add_fieldmsg(out_node, "PACKING ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
    */
	//A등급의 경우 수량이 최대가 아님면 오류처리 ( 2019/05/11 JUHYEON.JUNG)
    //AUTO 일 경우만 ( Manual 의 경우 처리를 안하기 위하여 
    if(TRS.get_procstep(in_node) == '2')
    {
	    CDB_init_cwiplotpak(&CWIPLOTPAK);
	    TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, "FACTORY");
	    TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
	    CWIPLOTPAK.STATUS_FLAG = 'C';
	    CDB_select_cwiplotpak(5, &CWIPLOTPAK);
	    if((DB_error_code == DB_SUCCESS) && 
		    ( memcmp(CWIPLOTPAK.GRADE, "G01", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G02", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "B", 1) == 0 || memcmp(CWIPLOTPAK.GRADE, "G03", 3) == 0 || memcmp(CWIPLOTPAK.GRADE, "G04", 3) == 0) //--[G03/G04 로직 추가]
	      )
	    {
		    //G01이 아니면 GRADE 는 XXX로 넘오옮.
		    CDB_init_mgcmlagdat(&MGCMLAGDAT);
		    TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
		    memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
		    memcpy(MGCMLAGDAT.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
		    CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
		    if (DB_error_code == DB_SUCCESS)
		    {
			    //
		    }

		    if (COM_atoi(MGCMLAGDAT.DATA_9, sizeof(MGCMLAGDAT.DATA_9)) !=  CWIPLOTPAK.HIST_SEQ)
		    {
			    strcpy(s_msg_code, "WIP-0574");
			    TRS.add_fieldmsg(out_node, "CWIPLOTPACK MAX COUNT CHECK", MP_NVST);
			    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
			    TRS.add_fieldmsg(out_node, "PACKING ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);
			    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			    return MP_FALSE;
		    }
	    }
    }
	else
	{
		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
		memcpy(MGCMTBLDAT.TABLE_NAME, "@VALIDATION_RULE", strlen("@VALIDATION_RULE"));
		memcpy(MGCMTBLDAT.KEY_1, "LIMIT_PACKING", strlen("LIMIT_PACKING"));
		CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
		if (DB_error_code == DB_SUCCESS)
		{
			//Nothing
		}

		// LIMIT_PACKING : Y이면 수량체크, N 이면 해제
		if (MGCMTBLDAT.DATA_2[0] == 'Y')
		{
			CDB_init_cwiplotpak(&CWIPLOTPAK);
			TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, "FACTORY");
			TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
			CWIPLOTPAK.STATUS_FLAG = 'C';
			CDB_select_cwiplotpak(5, &CWIPLOTPAK);
			if(DB_error_code == DB_SUCCESS) 
			{
				CDB_init_mgcmlagdat(&MGCMLAGDAT);
				TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
				memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
				memcpy(MGCMLAGDAT.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
				CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
				if (DB_error_code == DB_SUCCESS)
				{
					//
				}

				if (COM_atoi(MGCMLAGDAT.DATA_9, sizeof(MGCMLAGDAT.DATA_9)) !=  CWIPLOTPAK.HIST_SEQ)
				{
					strcpy(s_msg_code, "WIP-0574");
					TRS.add_fieldmsg(out_node, "CWIPLOTPACK MAX COUNT CHECK", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTPAK.FACTORY), CWIPLOTPAK.FACTORY);
					TRS.add_fieldmsg(out_node, "PACKING ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}	
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
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
int CWIP_View_Rework_Lot_Fqc_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	/* - [GERP PROJECT] 시작****************************************************************/
    struct CWIPRWKDAT_TAG CWIPRWKDAT;

    /* Rework Validation 1 :  재작업 대상 모듈이 FQC 검사 정보 없이 포장될 수 없다  */
	CDB_init_cwiprwkdat(&CWIPRWKDAT);
	memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPRWKDAT.PROD_ORDER_NO), in_node, "REWORK_ORDER_ID");
	TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "REWORK_MODULE_ID"); 

	//CDB_select_cwiprwkdat(1,&CWIPRWKDAT);
	CDB_select_cwiprwkdat(4, &CWIPRWKDAT); //취소된 재작업 제외 
	if(DB_error_code == DB_SUCCESS) 
	{
		//Rework Moudle
		if(CWIPRWKDAT.REWORK_JUDGE[0] == ' ')
		{
			strcpy(s_msg_code, "WIP-0617"); 
			TRS.add_fieldmsg(out_node, "CWIPRWKDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "PROD_ORDER_NO", MP_STR, sizeof(CWIPRWKDAT.PROD_ORDER_NO), CWIPRWKDAT.PROD_ORDER_NO); 
			TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	/* - [GERP PROJECT] 끝*****************************************************************/
    return MP_TRUE;
}
/*******************************************************************************
  COM_Packing_Log()
    - Main sub function of "EAPMES_COMPLETE_PACKING_E23" function
    - Check the condition for create/update/delete
  Return Value
    - int : 1 (MP_TRUE) or 0 (MP_FALSE)
  Arguments
    - char *s_msg_code : Error Message Code
    - TRSNode *in_node : Input Message structure
    - TRSNode *out_node : Output Message structure
*******************************************************************************/
int COM_Packing_Log_Client(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
  struct CWIPPAKLOG_TAG CWIPPAKLOG;

  char   s_sys_time[14];
  TRSNode** list = TRS.get_list(in_node, "MODULE_PACK_LIST");
  memset(s_sys_time, ' ', sizeof(s_sys_time));

  DB_get_systime(s_sys_time);
  if (DB_error_code != DB_SUCCESS)
  {
    strcpy(s_msg_code, "CMN-0003");
    TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
    TRS.add_dberrmsg(out_node, DB_error_msg);

    gs_log_type.type = MP_LOG_ERROR;
    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    gs_log_type.category = MP_LOG_CATE_SETUP;
    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    return MP_FALSE;
  }

  CDB_init_cwippaklog(&CWIPPAKLOG);
  TRS.copy(CWIPPAKLOG.FACTORY, sizeof(CWIPPAKLOG.FACTORY), in_node, "FACTORY");
  TRS.copy(CWIPPAKLOG.RES_ID, sizeof(CWIPPAKLOG.RES_ID), in_node, "RES_ID");
  TRS.copy(CWIPPAKLOG.PAKING_ID, sizeof(CWIPPAKLOG.PAKING_ID), in_node, "PACKING_ID"); //자동포장일때설비가 보고함  
  TRS.copy(CWIPPAKLOG.LOT_ID, sizeof(CWIPPAKLOG.LOT_ID), out_node, "PACK_LOT_ID");  //첫 모듈  아이디
  TRS.copy(CWIPPAKLOG.PACK_TIME, sizeof(CWIPPAKLOG.PACK_TIME), out_node, "PACK_TIME");
  TRS.copy(CWIPPAKLOG.PAK_TYPE, sizeof(CWIPPAKLOG.PAK_TYPE), in_node, "PACK_DIRECTION"); //MGCMTBLDAT.DATA_1
  TRS.copy(CWIPPAKLOG.CMF_1, sizeof(CWIPPAKLOG.CMF_1), in_node, "AUTO_COMPLETE");
  TRS.copy(CWIPPAKLOG.CMF_2, sizeof(CWIPPAKLOG.CMF_2), in_node, "CLIENT_IP"); //OIClient CLIENT_IP
  TRS.copy(CWIPPAKLOG.CMF_3, sizeof(CWIPPAKLOG.CMF_3), in_node, "CLIENT_VERSION"); //OIClient CLIENT_VERSION
  CWIPPAKLOG.SUCCESS_YN = 'N';

  if (COM_isnullspace(TRS.get_string(in_node, "FUNC_NAME")) == MP_FALSE)
  { //OIClient에서 호출 한경우
    TRS.copy(CWIPPAKLOG.PAKING_ID, sizeof(CWIPPAKLOG.PAKING_ID), in_node, "FUNC_NAME"); //OIClient 화면아이디

    if (0 < TRS.get_item_count(in_node, "MODULE_PACK_LIST"))
    {
      memcpy(CWIPPAKLOG.LOT_ID, TRS.get_string(list[0], "LOT_ID"), strlen(TRS.get_string(list[0], "LOT_ID")));
    }
  }
  
  if (CWIPPAKLOG.PACK_TIME[0] == ' ')
  {
    memcpy(CWIPPAKLOG.PACK_TIME, s_sys_time, sizeof(CWIPPAKLOG.PACK_TIME));
  }
  TRS.copy(CWIPPAKLOG.PALLET_ID, sizeof(CWIPPAKLOG.PALLET_ID), out_node, "PALLET_ID");

  if (COM_isnullspace(TRS.get_string(out_node, "PALLET_ID")) == MP_TRUE)
  {
    TRS.copy(CWIPPAKLOG.PALLET_ID, sizeof(CWIPPAKLOG.PALLET_ID), in_node, "PALLET_ID");
  }
  TRS.copy(CWIPPAKLOG.LINE_ID, sizeof(CWIPPAKLOG.LINE_ID), in_node, "LINE_ID");
  
  TRS.copy(CWIPPAKLOG.CREATE_USER_ID, sizeof(CWIPPAKLOG.CREATE_USER_ID), in_node, IN_USERID);
  CWIPPAKLOG.SUCCESS_YN = 'Y';

  memcpy(CWIPPAKLOG.ERR_MSG, s_msg_code, sizeof(s_msg_code));

  if (CWIPPAKLOG.ERR_MSG[0] == ' ')
  {
    CWIPPAKLOG.SUCCESS_YN = 'Y';
  }

  memcpy(CWIPPAKLOG.CREATE_TIME, s_sys_time, sizeof(CWIPPAKLOG.CREATE_TIME));

  CDB_insert_cwippaklog(&CWIPPAKLOG);
  if (DB_error_code != DB_SUCCESS)
  {
    //NOTHING
  }

  DB_commit();

  return MP_TRUE;
}
/*******************************************************************************
	CWIP_View_AcModule_Validation()
		- Main sub function of "CWIP_VIEW_PACKING_LOT" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_AcModule_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	/* - [GERP PROJECT] 시작****************************************************************/
    struct CWIPRWKDAT_TAG CWIPRWKDAT;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]
	struct CWIPORDBOM_TAG CWIPORDBOM;//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]
	char invter_rework_flag = ' ';
	char inverter_PCU_SN[30] ;
	char invter_flag = ' ';
	int txtSize;
	//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]-START
	//EALGE 1/23 은 AC/NON AC 모듈인 경우 체크
	//--[적용 로직]
	//1]LOT_CMF_15번으로 AC/NON AC를 체크
		//1.1]LOT_CMF_15 체크[바코드 아이디]
		//1.2]LOT_CMF_15 자릿수 체크 [12자리]
		//1.3]LOT_CMF_15 111111111111 가 아닌지
	//2]AC모듈인 경우 PO 기준으로 BOM 정보를 체크한다
	//기존적으로 Packing에서는 체크하지 않는다
	//0]G01/G02가 아니면 PASS

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "REWORK_MODULE_ID");

	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code == DB_SUCCESS)
	{	
		////1.1]LOT_CMF_15 체크[바코드 아이디]
		if (COM_isspace(MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15)) == MP_TRUE)
		{
			return MP_TRUE;
		}
		for(txtSize = 0; MWIPLOTSTS.LOT_CMF_15[txtSize] != ' '; ++txtSize);
		////1.2]LOT_CMF_15 자릿수 체크 [12자리]
		if(txtSize != 12)		
		{
			return MP_TRUE;
		}

		////1.3]LOT_CMF_15 111111111111 가 아닌지
		if(memcmp(MWIPLOTSTS.LOT_CMF_15, "111111111111", strlen("111111111111")) == 0)	////1.3]
		{
			return MP_TRUE;
		}		
	}
	else
	{
		return MP_TRUE;
	}

	//2]AC모듈인 경우 PO 기준으로 BOM 정보를 체크한다
	CDB_init_cwiprwkdat(&CWIPRWKDAT);
	TRS.copy(CWIPRWKDAT.FACTORY, sizeof(CWIPRWKDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(CWIPRWKDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(CWIPRWKDAT.MODULE_ID));
	memcpy(CWIPRWKDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(CWIPRWKDAT.PROD_ORDER_NO));
			
	CDB_select_cwiprwkdat(1,&CWIPRWKDAT);
	if(DB_error_code != DB_SUCCESS) 
	{
				

	}
	else
	{
		invter_rework_flag = 'Y';	
	}
	memset(inverter_PCU_SN, ' ', sizeof(inverter_PCU_SN));  
	memcpy(inverter_PCU_SN, MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
	invter_flag =  inverter_PCU_SN[3];
	CDB_init_cwipordbom(&CWIPORDBOM);
				
	memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	if(invter_rework_flag == 'Y')
	{
		memcpy(CWIPORDBOM.ORDER_ID, CWIPRWKDAT.CMF_4, sizeof(CWIPORDBOM.ORDER_ID));
	}
	else
		{
		memcpy(CWIPORDBOM.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
	}

	if(invter_flag == '1')
	{
		memcpy(CWIPORDBOM.MAT_ID, "SPMD-00001", 10);
		CDB_select_cwipordbom(2, &CWIPORDBOM);
		}
	else if(invter_flag =='2')
	{
		memcpy(CWIPORDBOM.MAT_ID, "SPMD-00002", 10);
		CDB_select_cwipordbom(2, &CWIPORDBOM);
	}

	if (DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0659"); 
		TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "PROD_ORDER_NO", MP_STR, sizeof(CWIPRWKDAT.PROD_ORDER_NO), CWIPRWKDAT.PROD_ORDER_NO); 
		TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID); 
		if(invter_flag == '1')
		{
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, 10, "SPMD-00001");
		}
		else if(invter_flag =='2')
		{
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, 10, "SPMD-00002");
		}


		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	

	

	//25.10.01[Eagle 공장 DCA(AC Module)/NonDca Validation 확산 검토]-END
    return MP_TRUE;
}