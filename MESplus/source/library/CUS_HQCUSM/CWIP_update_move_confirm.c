/*******************************************************************************

    System      : MESplus
    Module      : Update Move Confirm
    File Name   : CWIP_update_move_confirm.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2023.03.30  jhji

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "BASCore_common.h"
#include "CUS_common.h"

int CWIP_UPDATE_MOVE_CONFIRM(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);

int CWIP_Update_Move_Confirm_Validation(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node);

/*******************************************************************************
    CWIP_Update_Move_Confirm()
        - Move Confirm
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Move_Confirm(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_MOVE_CONFIRM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Update_Move_Confirm", out_node);

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
    CWIP_Update_Move_Confirm()
        - Update Move COnfirm
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_MOVE_CONFIRM(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPOPRDEF_TAG MWIPOPRDEF_T;
	struct MWIPOPRDEF_TAG MWIPOPRDEF_F;

	struct CWIPREQMST_TAG CWIPREQMST;
	struct CWIPREQDTL_TAG CWIPREQDTL;
	struct IQCMSAMDAT_TAG IQCMSAMDAT;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;

	struct MWIPORDSTS_TAG MWIPORDSTS;	//[ERP 23.05.31] 추가
	struct CWIPLOTPAK_TAG CWIPLOTPAK;   //[ERP 23.06.20] PACKING 여부 추가
	char s_sys_time[14];
	int i;
	int i_list_count;

	TRSNode** lot_list;
	TRSNode* Release_Lot_In;
	TRSNode* Release_Lot_Out;
	TRSNode* tran_in_node;
	TRSNode* tran_out_node;
	TRSNode* msg_in_node;
	TRSNode* msg_out_node;

	TRSNode* list_item;
	// PROCESS LOG PRINT
	LOG_head("CWIP_Update_Move_Request");
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

	if (CWIP_Update_Move_Confirm_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
	{
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	i_list_count = TRS.get_item_count(in_node, "REQ_LOT_LIST");
	lot_list = TRS.get_list(in_node, "REQ_LOT_LIST");
	for (i = 0; i < i_list_count; i++)
	{
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				list_item = TRS.add_node(out_node, "LIST");
				TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				TRS.add_char(list_item, "ERR_FLAG", 'Y');

				//GET Message
				msg_in_node = TRS.create_node("MSG_ID");
				msg_out_node = TRS.create_node("MSG_OUT");

				TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
				TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
				TRS.set_string(msg_in_node, "MSG_ID", "WIP-0631", strlen("WIP-0631")); //The module ID cannot be found.

				if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
				{
					TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
				}

				TRS.free_node(msg_in_node);
				TRS.free_node(msg_out_node);

			}
			else
			{

				strcpy(s_msg_code, "WIP-0004");
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			}
			return MP_FALSE;
		}

		//PACKING 여부 확인 
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
		memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		CWIPLOTPAK.STATUS_FLAG = 'C';
		//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 CONFIRM X
		if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
		{
			list_item = TRS.add_node(out_node, "LIST");
			TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF_F.OPER_SHORT_DESC, sizeof(MWIPOPRDEF_F.OPER_SHORT_DESC));
			TRS.add_char(list_item, "ERR_FLAG", 'Y');

			//GET Message
			msg_in_node = TRS.create_node("MSG_ID");
			msg_out_node = TRS.create_node("MSG_OUT");

			TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
			TRS.set_string(msg_in_node, "MSG_ID", "WIP-0564", strlen("WIP-0564"));
			if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
			{
				TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
			}

			TRS.free_node(msg_in_node);
			TRS.free_node(msg_out_node);

			return MP_FALSE;
		}

		///HOLD 상태이면 RELEASE를 한다.
		if (MWIPLOTSTS.HOLD_FLAG == 'Y')
		{
			Release_Lot_In = TRS.create_node("RELEASE_LOT_IN");
			Release_Lot_Out = TRS.create_node("RELEASE_LOT_OUT");
			TRS.add_char(Release_Lot_In, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(Release_Lot_In, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(Release_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));

			TRS.set_string(Release_Lot_In, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			TRS.set_string(Release_Lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.set_int(Release_Lot_In, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

			TRS.set_string(Release_Lot_In, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.set_int(Release_Lot_In, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.set_string(Release_Lot_In, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(Release_Lot_In, "FLOW_SEQ_NO", MWIPLOTSTS.FLOW_SEQ_NUM);

			TRS.set_string(Release_Lot_In, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_string(Release_Lot_In, "RELEASE_CODE", "REQ_MOVE", strlen("REQ_MOVE"));
			TRS.set_char(Release_Lot_In, "END_FLAG", MWIPLOTSTS.END_FLAG);
			//TRS.set_nstring(Release_Lot_In, "COMMENT", "REQ_MOVE RELEASE");

			if (WIP_RELEASE_LOT(s_msg_code, Release_Lot_In, Release_Lot_Out) == MP_FALSE)
			{
				TRS.free_node(Release_Lot_In);
				TRS.free_node(Release_Lot_Out);

				list_item = TRS.add_node(out_node, "LIST");
				TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				TRS.add_char(list_item, "ERR_FLAG", 'Y');

				//GET Message
				msg_in_node = TRS.create_node("MSG_ID");
				msg_out_node = TRS.create_node("MSG_OUT");

				TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
				TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
				TRS.set_string(msg_in_node, "MSG_ID", "WIP-0632", strlen("WIP-0632")); //The module ID is blocked, please contact production engineer.

				if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
				{
					TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
				}

				TRS.free_node(msg_in_node);
				TRS.free_node(msg_out_node);

				return MP_FALSE;
			}

			TRS.free_node(Release_Lot_In);
			TRS.free_node(Release_Lot_Out);

			//Release 후 재 조회 
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		}

		/*[GRTP PROJECT] 추가 */
		DBC_init_mwipordsts(&MWIPORDSTS);
		TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		DBC_select_mwipordsts(1, &MWIPORDSTS);
		/*[GRTP PROJECT] 끝 */

		if (TRS.get_procstep(in_node) == '1')
		{
			CDB_init_cwipreqmst(&CWIPREQMST);
			TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO), lot_list[i], "REQ_NO");
			CDB_select_cwipreqmst(1, &CWIPREQMST);
			if (DB_error_code != DB_SUCCESS)
			{				
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');

					msg_in_node = TRS.create_node("MSG_ID");
					msg_out_node = TRS.create_node("MSG_OUT");

					TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
					TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
					TRS.set_string(msg_in_node, "MSG_ID", "WIP-0633", strlen("WIP-0633")); //The request cannot be found.

					if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
					{
						TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
					}

					TRS.free_node(msg_in_node);
					TRS.free_node(msg_out_node);
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPREQMST SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				}
				return MP_FALSE;
			}
						
			///이동 요청 마스터 CLOSE
			memcpy(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_C, sizeof(HQCEL_M1_REQ_STATUS_C));
			memcpy(CWIPREQMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQMST.UPDATE_USER_ID, sizeof(CWIPREQMST.UPDATE_USER_ID), in_node, IN_USERID);
			CDB_update_cwipreqmst(2, &CWIPREQMST);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQMST UPDATE(2)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//TO 공정의 정의 조회
			DBC_init_mwipoprdef(&MWIPOPRDEF_T);
			TRS.copy(MWIPOPRDEF_T.FACTORY, sizeof(MWIPOPRDEF_T.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPOPRDEF_T.OPER, sizeof(MWIPOPRDEF_T.OPER), in_node, "TO_OPER");
			DBC_select_mwipoprdef(1, &MWIPOPRDEF_T);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');

					//GET Message
					msg_in_node = TRS.create_node("MSG_ID");
					msg_out_node = TRS.create_node("MSG_OUT");

					TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
					TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
					TRS.set_string(msg_in_node, "MSG_ID", "WIP-0639", strlen("WIP-0639")); // The storage cannot be found.

					if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
					{
						TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
					}

					TRS.free_node(msg_in_node);
					TRS.free_node(msg_out_node);
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF_T.FACTORY), MWIPOPRDEF_T.FACTORY);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF_T.OPER), MWIPOPRDEF_T.OPER);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				}
				
				return MP_FALSE;
			}

			//FROM 공정의 정의 조회
			DBC_init_mwipoprdef(&MWIPOPRDEF_F);
			TRS.copy(MWIPOPRDEF_F.FACTORY, sizeof(MWIPOPRDEF_F.FACTORY), in_node, IN_FACTORY);
			//memcpy(MWIPOPRDEF_F.OPER, CWIPREQMST.FROM_OPER, sizeof(MWIPOPRDEF_F.OPER));
			memcpy(MWIPOPRDEF_F.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF_F);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF_F.OPER_SHORT_DESC, sizeof(MWIPOPRDEF_F.OPER_SHORT_DESC));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');

					//GET Message
					msg_in_node = TRS.create_node("MSG_ID");
					msg_out_node = TRS.create_node("MSG_OUT");

					TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
					TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
					TRS.set_string(msg_in_node, "MSG_ID", "WIP-0639", strlen("WIP-0639")); // The storage cannot be found.

					if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
					{
						TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
					}

					TRS.free_node(msg_in_node);
					TRS.free_node(msg_out_node);					
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF_F.FACTORY), MWIPOPRDEF_F.FACTORY);
					TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF_F.OPER), MWIPOPRDEF_F.OPER);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				}
				return MP_FALSE;
			}

			//To 공정이 창고 공정 Store 생산 공정이면 End 처리 한다.
			if (MWIPOPRDEF_T.INV_FLAG == 'Y') 
			{
				if (MWIPOPRDEF_F.INV_FLAG == 'Y') 
				{   
					//창고에서 창고로 옮기는 경우 STORE MOVE한다. 
					//현재 공정이 동일 공정 (창고) 일경우 MOVE 처리 하지 않는다. 
					if (TRS.mem_cmp(in_node, "TO_OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER)) != 0)
					{
						tran_in_node = TRS.create_node("STORE_MOVE_IN");
						tran_out_node = TRS.create_node("STORE_MOVE_OUT");

						CCOM_copy_in_node(in_node, tran_in_node);
						TRS.add_char(tran_in_node, "PROCSTEP", '1');
						TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
						TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						TRS.add_nstring(tran_in_node, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));

						if (CINV_MOVE_STORE(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
						{
							TRS.free_node(tran_in_node);
							TRS.free_node(tran_out_node);

							list_item = TRS.add_node(out_node, "LIST");
							TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
							TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
							TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF_F.OPER_SHORT_DESC, sizeof(MWIPOPRDEF_F.OPER_SHORT_DESC));
							TRS.add_char(list_item, "ERR_FLAG", 'Y');

							//GET Message
							msg_in_node = TRS.create_node("MSG_ID");
							msg_out_node = TRS.create_node("MSG_OUT");

							TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
							TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
							TRS.set_string(msg_in_node, "MSG_ID", "WIP-0635", strlen("WIP-0635"));  //WIP-0635: Data Error (move); please contact production engineer.
							if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
							{
								TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
							}

							TRS.free_node(msg_in_node);
							TRS.free_node(msg_out_node);

							return MP_FALSE;
						}

						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
					}
				}
				else 
				{ 
					//생산공정에서 창고로 옮기는 경우 STORE 처리한다.
					/* STORE Lot */
					tran_in_node = TRS.create_node("STORE_LOT_IN");
					tran_out_node = TRS.create_node("STORE_LOT_OUT");

					CCOM_copy_in_node(in_node, tran_in_node);
					TRS.add_char(tran_in_node, "PROCSTEP", '1');
					TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
					TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
					TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_nstring(tran_in_node, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));

					if (WIP_STORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
					{
						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);
												
						list_item = TRS.add_node(out_node, "LIST");
						TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
						TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF_F.OPER_SHORT_DESC, sizeof(MWIPOPRDEF_F.OPER_SHORT_DESC));
						TRS.add_char(list_item, "ERR_FLAG", 'Y');

						//GET Message
						msg_in_node = TRS.create_node("MSG_ID");
						msg_out_node = TRS.create_node("MSG_OUT");

						TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
						TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
						TRS.set_string(msg_in_node, "MSG_ID", "WIP-0636", strlen("WIP-0636")); //Data Error (store); please contact production engineer.
						if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
						{
							TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
						}

						TRS.free_node(msg_in_node);
						TRS.free_node(msg_out_node);

						return MP_FALSE;
					}

					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);
				}
			}
			else 
			{
				tran_in_node = TRS.create_node("END_LOT_IN");
				tran_out_node = TRS.create_node("END_LOT_OUT");

				CCOM_copy_in_node(in_node, tran_in_node);
				TRS.add_char(tran_in_node, "PROCSTEP", '1');
				TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
				TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
				TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

				if (WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					TRS.free_node(tran_in_node);
					TRS.free_node(tran_out_node);

					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF_F.OPER_SHORT_DESC, sizeof(MWIPOPRDEF_F.OPER_SHORT_DESC));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');

					//GET Message
					msg_in_node = TRS.create_node("MSG_ID");
					msg_out_node = TRS.create_node("MSG_OUT");

					TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
					TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
					TRS.set_string(msg_in_node, "MSG_ID", "WIP-0640", strlen("WIP-0640"));  //Data Error (end); please contact production engineer."
					if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
					{
						TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
					}

					TRS.free_node(msg_in_node);
					TRS.free_node(msg_out_node);

					return MP_FALSE;
				}

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
			}

			///TRANSATION이 완료 되면 HIST_SEQ가 변경 되니 재조회 한다
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), lot_list[i], "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0044");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			}

			///이동 요청 상세 HIST_SEQ UPDATE
			TRS.copy(CWIPREQDTL.FACTORY, sizeof(CWIPREQDTL.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPREQDTL.REQ_NO, CWIPREQMST.REQ_NO, sizeof(CWIPREQDTL.REQ_NO));
			TRS.copy(CWIPREQDTL.LOT_ID, sizeof(CWIPREQDTL.LOT_ID), lot_list[i], "LOT_ID");
			CWIPREQDTL.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
			memcpy(CWIPREQDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQDTL.UPDATE_USER_ID, sizeof(CWIPREQDTL.UPDATE_USER_ID), in_node, IN_USERID);
			CDB_update_cwipreqdtl(2, &CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					list_item = TRS.add_node(out_node, "LIST");
					TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
					TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
					TRS.add_string(list_item, "OPER_DESC", MWIPOPRDEF_F.OPER_SHORT_DESC, sizeof(MWIPOPRDEF_F.OPER_SHORT_DESC));
					TRS.add_char(list_item, "ERR_FLAG", 'Y');

					//GET Message
					msg_in_node = TRS.create_node("MSG_ID");
					msg_out_node = TRS.create_node("MSG_OUT");

					TRS.add_char(msg_in_node, IN_PROCSTEP, '1');
					TRS.add_enc_nstring(msg_in_node, IN_FACTORY, TRS.get_factory(in_node));
					TRS.set_string(msg_in_node, "MSG_ID", "WIP-0633", strlen("WIP-0633"));  //The request cannot be found.

					if (BAS_VIEW_MESSAGE(s_msg_code, msg_in_node, msg_out_node) == MP_TRUE)
					{
						TRS.add_nstring(list_item, "ERR_DESC", TRS.get_string(msg_out_node, "MSG_1"));
					}

					TRS.free_node(msg_in_node);
					TRS.free_node(msg_out_node);
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPREQDTL UPDATE(2)", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQDTL.FACTORY), CWIPREQDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQDTL.REQ_NO), CWIPREQDTL.REQ_NO);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				}

				return MP_FALSE;			
			}

			if (MWIPOPRDEF_F.ERP_FLAG == 'Y')
			{
				///ERP IF
				CDB_init_iqcmsamdat(&IQCMSAMDAT);
				CDB_select_iqcmsamdat(2, &IQCMSAMDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT SELECT(2)", MP_NVST);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				TRS.add_string(in_node, "DOC_ID", IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID));
				TRS.copy(IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID), in_node, "DOC_ID");
				memcpy(IQCMSAMDAT.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
				memcpy(IQCMSAMDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				memcpy(IQCMSAMDAT.ACTION_TYPE, "I", strlen("I"));
				memcpy(IQCMSAMDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(IQCMSAMDAT.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				memcpy(IQCMSAMDAT.QC_INSPECTION, CWIPREQMST.REQ_TYPE, sizeof(CWIPREQMST.REQ_TYPE));
				TRS.copy(IQCMSAMDAT.STORAGE_LOCATION, sizeof(IQCMSAMDAT.STORAGE_LOCATION), in_node, "TO_OPER");
				memcpy(IQCMSAMDAT.LOCATION, MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
				TRS.copy(IQCMSAMDAT.QUALITY_GRADE, sizeof(IQCMSAMDAT.QUALITY_GRADE), lot_list[i], "GRADE");
				TRS.copy(IQCMSAMDAT.POWER_GRADE, sizeof(IQCMSAMDAT.POWER_GRADE), lot_list[i], "POWER");
				TRS.copy(IQCMSAMDAT.Z_GROUP, sizeof(IQCMSAMDAT.Z_GROUP), lot_list[i], "REQ_NO");
				IQCMSAMDAT.ZPISTAT = 'R';
				CDB_insert_iqcmsamdat(&IQCMSAMDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSAMDAT.DOC_ID), IQCMSAMDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSAMDAT.Z_GROUP), IQCMSAMDAT.Z_GROUP);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}
		// 이동 요청 REJECT
		else if (TRS.get_procstep(in_node) == '2')
		{
			#pragma region CWIPREQMST 데이터 확인 
			CDB_init_cwipreqmst(&CWIPREQMST);
			TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO), lot_list[i], "REQ_NO");
			CDB_select_cwipreqmst(1, &CWIPREQMST);
			
			#pragma region ERP 연계 공정 확인 
			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPOPRDEF.OPER, CWIPREQMST.FROM_OPER, sizeof(CWIPREQMST.TO_OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0010");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
				}

				TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_COMMON;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			if (MWIPOPRDEF.ERP_FLAG == 'Y')
			{
				// INSERT 반납승인 거부 
				CDB_init_iqcmsamdat(&IQCMSAMDAT);
				CDB_select_iqcmsamdat(2, &IQCMSAMDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT SELECT(2)", MP_NVST);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				TRS.add_string(in_node, "DOC_ID", IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID));
				TRS.copy(IQCMSAMDAT.DOC_ID, sizeof(IQCMSAMDAT.DOC_ID), in_node, "DOC_ID");
				memcpy(IQCMSAMDAT.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
				memcpy(IQCMSAMDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				memcpy(IQCMSAMDAT.ACTION_TYPE, "I", strlen("I"));
				memcpy(IQCMSAMDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				memcpy(IQCMSAMDAT.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				if (CWIPREQMST.REQ_TYPE[0] == 'W')
				{
					// 재작업 모듈 인수 거부 
					memcpy(IQCMSAMDAT.QC_INSPECTION, "X", strlen("X"));
				}
				else
				{
					//SAMPLE 반납 인수 거부 CWIPREQMST.REQ_TYPE[0] == 'R'
					memcpy(IQCMSAMDAT.QC_INSPECTION, "Z", strlen("Z"));
				}
				TRS.copy(IQCMSAMDAT.STORAGE_LOCATION, sizeof(IQCMSAMDAT.STORAGE_LOCATION), lot_list[i], "TO_OPER");
				memcpy(IQCMSAMDAT.LOCATION, MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
				TRS.copy(IQCMSAMDAT.QUALITY_GRADE, sizeof(IQCMSAMDAT.QUALITY_GRADE), lot_list[i], "GRADE");
				TRS.copy(IQCMSAMDAT.POWER_GRADE, sizeof(IQCMSAMDAT.POWER_GRADE), lot_list[i], "POWER");
				TRS.copy(IQCMSAMDAT.Z_GROUP, sizeof(IQCMSAMDAT.Z_GROUP), lot_list[i], "REQ_NO");
				IQCMSAMDAT.ZPISTAT = 'R';
				CDB_insert_iqcmsamdat(&IQCMSAMDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSAMDAT INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSAMDAT.DOC_ID), IQCMSAMDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSAMDAT.Z_GROUP), IQCMSAMDAT.Z_GROUP);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			#pragma endregion ERP 연계 공정 확인 

			#pragma region  이동 요청 마스터 CLOSE
			CDB_init_cwipreqmst(&CWIPREQMST);
			TRS.copy(CWIPREQMST.FACTORY, sizeof(CWIPREQMST.FACTORY), in_node, IN_FACTORY);
			memcpy(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_RJ, sizeof(HQCEL_M1_REQ_STATUS_RJ));
			TRS.copy(CWIPREQMST.REQ_NO, sizeof(CWIPREQMST.REQ_NO), lot_list[i], "REQ_NO");
			memcpy(CWIPREQMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CWIPREQMST.UPDATE_USER_ID, sizeof(CWIPREQMST.UPDATE_USER_ID), in_node, IN_USERID);
			CDB_update_cwipreqmst(2, &CWIPREQMST);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPREQMST UPDATE(2)", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPREQMST.FACTORY), CWIPREQMST.FACTORY);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(CWIPREQMST.REQ_NO), CWIPREQMST.REQ_NO);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			#pragma endregion  이동 요청 마스터 CLOSE				
		}
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}


/*******************************************************************************
	CWIP_Update_Move_Confirm_Validation()
		- Main sub function of "CWIP_Update_Move_Confirm" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Move_Confirm_Validation(char* s_msg_code,
	TRSNode* in_node,
	TRSNode* out_node)
{
	struct MWIPFACDEF_TAG MWIPFACDEF;

	/* ProcStep Validation */
	if (COM_service_validation(s_msg_code,
		in_node,
		out_node,
		TRS.get_procstep(in_node),
		"12") == MP_FALSE)
	{
		return MP_FALSE;
	}

	/* Factory Validation */
	if (COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
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
	if (DB_error_code != DB_SUCCESS)
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