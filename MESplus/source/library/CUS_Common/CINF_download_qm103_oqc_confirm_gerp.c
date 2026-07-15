/*******************************************************************************

    System      : MESplus
    Module      : Costcenter master setup
    File Name   : CINF_download_qm103_oqc_confirm_gerp.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2023.03.19  lake jang

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_QM103_OQC_CONFIRM(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Costcenter_Master()
        - ERP->MES Costcenter Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Qm103_Oqc_Confirm(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_QM103_OQC_CONFIRM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Qm103_Oqc_Confirm", out_node);

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
    CUS_INTERFACE_DOWNLOAD_QM103_OQC_CONFIRM()
        - ERP->MES OQC Confirm Data
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_QM103_OQC_CONFIRM(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	
	struct MWIPLOTSTS_TAG MWIPLOTSTS;

	struct IQCMSERDAT_TAG IQCMSERDAT;
	struct IBAKSERDAT_TAG IBAKSERDAT;

	struct CWIPREQMST_TAG CWIPREQMST;
	struct CWIPREQDTL_TAG CWIPREQDTL;

	TRSNode *release_lot_In;
	TRSNode *tran_in_node;
	TRSNode *tran_out_node;

	char s_sys_time[14];
	int i_confirm = 0;
	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_DOWNLOAD_QM103_OQC_CONFIRM");
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

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// OPEN
	CDB_init_iqcmserdat(&IQCMSERDAT);
	//QC_INSPECTION ='Q' : 샘플시료 인수 확인
	//QC_INSPECTION ='C' : 샘플시료 인수 거부 확인
	CDB_open_iqcmserdat(2, &IQCMSERDAT); 
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}
		else 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "IQCMSERDAT OPEN(2)", MP_NVST);
			TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);			
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	// FETCH
	while(1)
	{
		CDB_fetch_iqcmserdat(2, &IQCMSERDAT);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_iqcmserdat(2);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IQCMSERDAT FETCH(2)", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iqcmserdat(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
				
		//Get Request Detail Data
		CDB_init_cwipreqdtl(&CWIPREQDTL);
		memcpy(CWIPREQDTL.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPREQDTL.LOT_ID, IQCMSERDAT.MODULE_ID, sizeof(CWIPREQDTL.LOT_ID));
		memcpy(CWIPREQDTL.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(CWIPREQDTL.REQ_NO));
		CDB_select_cwipreqdtl(1, &CWIPREQDTL);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				IQCMSERDAT.RETURN_TYPE = 'E';
				memcpy(IQCMSERDAT.RETURN_MSG, "The module in this request does not exist or This REQ NO is not in the requested state.", strlen("The module in this request does not exist or This REQ NO is not in the requested state."));
				CDB_update_iqcmserdat(1, &IQCMSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSERDAT SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_iqcmserdat(2);
					return MP_FALSE;
				}
				DB_commit();
				continue;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "IQCMSERDAT SELECT(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
				TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				CDB_close_iqcmserdat(2);
				return MP_FALSE;
			}
		}
		else
		{
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.FACTORY, CWIPREQDTL.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(MWIPLOTSTS.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				IQCMSERDAT.RETURN_TYPE = 'E';
				memcpy(IQCMSERDAT.RETURN_MSG, "The module does not exist.", strlen("The module does not exist."));
				CDB_update_iqcmserdat(1, &IQCMSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IQCMSERDAT SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
					TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					CDB_close_iqcmserdat(2);
					return MP_FALSE;
				}
				DB_commit();
				continue;
			}

			//QC_INSPECTION ='Q' : 샘플시료 인수 확인 > OCQ 공정으로 UNSTORE
			if (memcmp(IQCMSERDAT.QC_INSPECTION, "Q", strlen("Q")) == 0)
			{
				//OQC 요청 상태 확인 CANCEL 일 경우 ERROR
				CDB_init_cwipreqmst(&CWIPREQMST);
				memcpy(CWIPREQMST.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CWIPREQMST.REQ_NO, IQCMSERDAT.Z_GROUP, sizeof(IQCMSERDAT.Z_GROUP));
				CDB_select_cwipreqmst(1, &CWIPREQMST);
				if (DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{
						IQCMSERDAT.RETURN_TYPE = 'E';
						memcpy(IQCMSERDAT.RETURN_MSG, "The module in this reqeuest master info does not exist.", strlen("The module in this reqeuest master info does not exist."));
						CDB_update_iqcmserdat(1, &IQCMSERDAT);
						if (DB_error_code != DB_SUCCESS)
						{
							strcpy(s_msg_code, "WIP-0004");
							TRS.add_fieldmsg(out_node, "IQCMSERDAT UPDATE(1)", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
							TRS.add_dberrmsg(out_node, DB_error_msg);
							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							CDB_close_iqcmserdat(2);
							return MP_FALSE;
						}
						DB_commit();
						continue;
					}
					else
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "IQCMSERDAT SELECT(1)", MP_NVST);
						TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPREQDTL.LOT_ID), CWIPREQDTL.LOT_ID);
						TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						CDB_close_iqcmserdat(2);
						return MP_FALSE;
					}
				}
				else
				{
					if (memcmp(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_CL, strlen(HQCEL_M1_REQ_STATUS_CL)) == 0)
					{
						IQCMSERDAT.RETURN_TYPE = 'E';
						memcpy(IQCMSERDAT.RETURN_MSG, "This is a canceled request.", strlen("This is a canceled request."));
						CDB_update_iqcmserdat(1, &IQCMSERDAT);
						if (DB_error_code != DB_SUCCESS)
						{
							strcpy(s_msg_code, "WIP-0004");
							TRS.add_fieldmsg(out_node, "IQCMSERDAT UPDATE(1)", MP_NVST);
							TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IQCMSERDAT.DOC_ID), IQCMSERDAT.DOC_ID);
							TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(IQCMSERDAT.MODULE_ID), IQCMSERDAT.MODULE_ID);
							TRS.add_fieldmsg(out_node, "REQ_NO", MP_STR, sizeof(IQCMSERDAT.Z_GROUP), IQCMSERDAT.Z_GROUP);
							TRS.add_dberrmsg(out_node, DB_error_msg);
							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							CDB_close_iqcmserdat(2);
							return MP_FALSE;
						}

						DB_commit();
						continue;
					}
				}
			}

			///HOLD 상태이면 RELEASE를 한다.
			if (MWIPLOTSTS.HOLD_FLAG == 'Y')
			{ 
				release_lot_In = TRS.create_node("release_lot_In");
				TRS.add_char(release_lot_In, IN_PROCSTEP, '1');
				TRS.add_enc_nstring(release_lot_In, IN_USERID, TRS.get_userid(in_node));
				TRS.add_char(release_lot_In, IN_LANGUAGE, TRS.get_language(in_node));

				TRS.set_string(release_lot_In, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				TRS.set_string(release_lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				TRS.set_int(release_lot_In, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

				TRS.set_string(release_lot_In, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				TRS.set_int(release_lot_In, "MAT_VER", MWIPLOTSTS.MAT_VER);
				TRS.set_string(release_lot_In, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
				TRS.set_int(release_lot_In, "FLOW_SEQ_NO", MWIPLOTSTS.FLOW_SEQ_NUM);

				TRS.set_string(release_lot_In, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
				if (memcmp(IQCMSERDAT.QC_INSPECTION, "Q", strlen("Q")) == 0)
				{
					TRS.set_string(release_lot_In, "RELEASE_CODE", HQCEL_RELEASE_REQ_MOVE, strlen(HQCEL_RELEASE_REQ_MOVE));
				}
				else
				{
					TRS.set_string(release_lot_In, "RELEASE_CODE", HQCEL_RELEASE_REQ_REJECT, strlen(HQCEL_RELEASE_REQ_REJECT));
				}

				TRS.set_char(release_lot_In, "END_FLAG", 'Y');

				if (WIP_RELEASE_LOT(s_msg_code, release_lot_In, out_node) == MP_FALSE)
				{					
					//PASS					
				}

				TRS.free_node(release_lot_In);

				///RELEASE 가 완료 되면 HIST_SEQ가 변경 되니 재조회 한다
				DBC_init_mwiplotsts(&MWIPLOTSTS);
				memcpy(MWIPLOTSTS.FACTORY, CWIPREQDTL.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				memcpy(MWIPLOTSTS.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				DBC_select_mwiplotsts(1, &MWIPLOTSTS);
				
			}

			//현재 공정이 OQC 공정이 아닐 경우 공정 또는 창고 이동 처리 
			if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER)) != 0)
			{
				//QC_INSPECTION ='Q' : 샘플시료 인수 확인 > OCQ 공정으로 UNSTORE
				if (memcmp(IQCMSERDAT.QC_INSPECTION, "Q", strlen("Q")) == 0)
				{
					if (MWIPLOTSTS.INV_FLAG == 'Y')
					{
						//START_RES_ID의 값이 존재 하면 UNSTORE를 다른 FLOW, 다른공정으로 할수 없음(코어 로직)
						if (memcmp(MWIPLOTSTS.STR_RET_OPER, IQCMSERDAT.STORAGE_LOCATION, sizeof(MWIPLOTSTS.STR_RET_OPER)))
						{
							memcpy(MWIPLOTSTS.STR_RET_OPER, IQCMSERDAT.STORAGE_LOCATION, sizeof(MWIPLOTSTS.STR_RET_OPER));
							DBC_update_mwiplotsts(1, &MWIPLOTSTS);
						}

						///등급별 창고에 있는 LOT을 OQC공정으로 UNSTORE 한다.
						/* UNSTORE Lot */
						tran_in_node = TRS.create_node("UNSTORE_LOT_IN");
						tran_out_node = TRS.create_node("UNSTORE_LOT_OUT");

						CCOM_copy_in_node(in_node, tran_in_node);
						TRS.add_char(tran_in_node, "PROCSTEP", '1');
						TRS.set_string(tran_in_node, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
						TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
						TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

						TRS.add_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.STR_RET_FLOW, sizeof(MWIPLOTSTS.STR_RET_FLOW));
						TRS.add_string(tran_in_node, "TO_OPER", HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER));

						TRS.add_char(tran_in_node, "NSTD_FLAG", 'Y');
						TRS.set_string(tran_in_node, "NSTD_RET_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
						TRS.set_int(tran_in_node, "NSTD_RET_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
						TRS.set_string(tran_in_node, "NSTD_RET_OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

						if (WIP_UNSTORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
						{
							//PASS
						}

						TRS.free_node(tran_in_node);
						TRS.free_node(tran_out_node);

					}
					else
					{
						//현재 공정이 OQC가 아닌 타 공정일 경우 OQC로 이동 
						if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER)) != 0)
						{
							tran_in_node = TRS.create_node("END_LOT");

							CCOM_copy_in_node(in_node, tran_in_node);
							TRS.add_char(tran_in_node, "PROCSTEP", '1');
							TRS.set_string(tran_in_node, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
							TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
							TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
							TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
							TRS.add_string(tran_in_node, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
							TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
							TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

							TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
							TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
							TRS.set_string(tran_in_node, "TO_OPER", HQCEL_M1_OQC_OPER, strlen(HQCEL_M1_OQC_OPER));

							if (MWIPLOTSTS.START_FLAG == 'Y')
							{
								TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));
								if (WIP_END_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
								{
									//PASS
								}
							}
							else
							{
								if (WIP_SKIP_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
								{
									//PASS
								}
							}
							TRS.free_node(tran_in_node);
						}
					}
				}
			}

			///TRANSACTION이  완료 되면 HIST_SEQ가 변경 되니 재조회 한다
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.FACTORY, CWIPREQDTL.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			memcpy(MWIPLOTSTS.LOT_ID, CWIPREQDTL.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);

			///이동 요청 상세 HIST_SEQ UPDATE
			CWIPREQDTL.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
			memcpy(CWIPREQDTL.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(CWIPREQDTL.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
			CDB_update_cwipreqdtl(2, &CWIPREQDTL);
			if (DB_error_code != DB_SUCCESS)
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
				CDB_close_iqcmserdat(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//BACK UP
			CDB_init_ibakserdat(&IBAKSERDAT);
			memcpy(IBAKSERDAT.DOC_ID, IQCMSERDAT.DOC_ID, sizeof(IBAKSERDAT.DOC_ID));
			memcpy(IBAKSERDAT.SITE_ID, IQCMSERDAT.SITE_ID, sizeof(IBAKSERDAT.SITE_ID));
			memcpy(IBAKSERDAT.MODULE_ID, IQCMSERDAT.MODULE_ID, sizeof(IBAKSERDAT.MODULE_ID));
			memcpy(IBAKSERDAT.Z_GROUP, IQCMSERDAT.Z_GROUP, sizeof(IBAKSERDAT.Z_GROUP));
			CDB_select_ibakserdat(1, &IBAKSERDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					memcpy(IBAKSERDAT.DOC_ID, IQCMSERDAT.DOC_ID, sizeof(IBAKSERDAT.DOC_ID));
					memcpy(IBAKSERDAT.SITE_ID, IQCMSERDAT.SITE_ID, sizeof(IBAKSERDAT.SITE_ID));
					memcpy(IBAKSERDAT.Z_GROUP, IQCMSERDAT.Z_GROUP, sizeof(IBAKSERDAT.Z_GROUP));
					memcpy(IBAKSERDAT.MODULE_ID, IQCMSERDAT.MODULE_ID, sizeof(IBAKSERDAT.MODULE_ID));
					memcpy(IBAKSERDAT.ACTION_TYPE, IQCMSERDAT.ACTION_TYPE, sizeof(IBAKSERDAT.ACTION_TYPE));
					memcpy(IBAKSERDAT.PROD_ORDER_NO, IQCMSERDAT.PROD_ORDER_NO, sizeof(IBAKSERDAT.PROD_ORDER_NO));
					memcpy(IBAKSERDAT.MATE_NO, IQCMSERDAT.MATE_NO, sizeof(IBAKSERDAT.MATE_NO));
					memcpy(IBAKSERDAT.QC_INSPECTION, IQCMSERDAT.QC_INSPECTION, sizeof(IBAKSERDAT.QC_INSPECTION));
					memcpy(IBAKSERDAT.STORAGE_LOCATION, IQCMSERDAT.STORAGE_LOCATION, sizeof(IBAKSERDAT.STORAGE_LOCATION));
					memcpy(IBAKSERDAT.LOCATION, IQCMSERDAT.LOCATION, sizeof(IBAKSERDAT.LOCATION));
					memcpy(IBAKSERDAT.SHIFT, IQCMSERDAT.SHIFT, sizeof(IBAKSERDAT.SHIFT));
					memcpy(IBAKSERDAT.QUALITY_GRADE, IQCMSERDAT.QUALITY_GRADE, sizeof(IBAKSERDAT.QUALITY_GRADE));
					memcpy(IBAKSERDAT.POWER_GRADE, IQCMSERDAT.POWER_GRADE, sizeof(IBAKSERDAT.POWER_GRADE));
					memcpy(IBAKSERDAT.FQC_DEFECTCODE, IQCMSERDAT.FQC_DEFECTCODE, sizeof(IBAKSERDAT.FQC_DEFECTCODE));
					memcpy(IBAKSERDAT.DIST_ID, IQCMSERDAT.DIST_ID, sizeof(IBAKSERDAT.DIST_ID));
					memcpy(IBAKSERDAT.CMF_1, IQCMSERDAT.CMF_1, sizeof(IBAKSERDAT.CMF_1));
					memcpy(IBAKSERDAT.CMF_2, IQCMSERDAT.CMF_2, sizeof(IBAKSERDAT.CMF_2));
					memcpy(IBAKSERDAT.CMF_3, IQCMSERDAT.CMF_3, sizeof(IBAKSERDAT.CMF_3));
					memcpy(IBAKSERDAT.CMF_4, IQCMSERDAT.CMF_4, sizeof(IBAKSERDAT.CMF_4));
					memcpy(IBAKSERDAT.CMF_5, IQCMSERDAT.CMF_5, sizeof(IBAKSERDAT.CMF_5));
					IBAKSERDAT.DATA_FLAG = IQCMSERDAT.DATA_FLAG;
					memcpy(IBAKSERDAT.UPDATE_COUNT, IQCMSERDAT.UPDATE_COUNT, sizeof(IBAKSERDAT.UPDATE_COUNT));
					memcpy(IBAKSERDAT.INSERT_COUNT, IQCMSERDAT.INSERT_COUNT, sizeof(IBAKSERDAT.INSERT_COUNT));
					memcpy(IBAKSERDAT.DELETE_COUNT, IQCMSERDAT.DELETE_COUNT, sizeof(IBAKSERDAT.DELETE_COUNT));
					memcpy(IBAKSERDAT.SQL_DML_COUNT, IQCMSERDAT.SQL_DML_COUNT, sizeof(IBAKSERDAT.SQL_DML_COUNT));
					IBAKSERDAT.RETURN_TYPE = 'S';
					memcpy(IBAKSERDAT.RETURN_MSG, IQCMSERDAT.RETURN_MSG, sizeof(IBAKSERDAT.RETURN_MSG));
					memcpy(IBAKSERDAT.ZPICODE, IQCMSERDAT.ZPICODE, sizeof(IBAKSERDAT.ZPICODE));
					memcpy(IBAKSERDAT.ZPIMSGID, IQCMSERDAT.ZPIMSGID, sizeof(IBAKSERDAT.ZPIMSGID));
					memcpy(IBAKSERDAT.ZIFERNAM, IQCMSERDAT.ZIFERNAM, sizeof(IBAKSERDAT.ZIFERNAM));
					memcpy(IBAKSERDAT.ZIFDATE, IQCMSERDAT.ZIFDATE, sizeof(IBAKSERDAT.ZIFDATE));
					memcpy(IBAKSERDAT.ZIFTIME, IQCMSERDAT.ZIFTIME, sizeof(IBAKSERDAT.ZIFTIME));
					IBAKSERDAT.ZPISTAT = IQCMSERDAT.ZPISTAT;
					memcpy(IBAKSERDAT.ZPIMSG, IQCMSERDAT.ZPIMSG, sizeof(IBAKSERDAT.ZPIMSG));
					CDB_insert_ibakserdat(&IBAKSERDAT);
					if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "IBAKSERDAT INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
						TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
						TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
						TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;
						CDB_close_iqcmserdat(2);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IBAKSERDAT SELECT(1)", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
					TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
					TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;
					CDB_close_iqcmserdat(2);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
			else
			{
				memcpy(IBAKSERDAT.DOC_ID, IQCMSERDAT.DOC_ID, sizeof(IBAKSERDAT.DOC_ID));
				memcpy(IBAKSERDAT.SITE_ID, IQCMSERDAT.SITE_ID, sizeof(IBAKSERDAT.SITE_ID));
				memcpy(IBAKSERDAT.Z_GROUP, IQCMSERDAT.Z_GROUP, sizeof(IBAKSERDAT.Z_GROUP));
				memcpy(IBAKSERDAT.MODULE_ID, IQCMSERDAT.MODULE_ID, sizeof(IBAKSERDAT.MODULE_ID));
				memcpy(IBAKSERDAT.ACTION_TYPE, IQCMSERDAT.ACTION_TYPE, sizeof(IBAKSERDAT.ACTION_TYPE));
				memcpy(IBAKSERDAT.PROD_ORDER_NO, IQCMSERDAT.PROD_ORDER_NO, sizeof(IBAKSERDAT.PROD_ORDER_NO));
				memcpy(IBAKSERDAT.MATE_NO, IQCMSERDAT.MATE_NO, sizeof(IBAKSERDAT.MATE_NO));
				memcpy(IBAKSERDAT.QC_INSPECTION, IQCMSERDAT.QC_INSPECTION, sizeof(IBAKSERDAT.QC_INSPECTION));
				memcpy(IBAKSERDAT.STORAGE_LOCATION, IQCMSERDAT.STORAGE_LOCATION, sizeof(IBAKSERDAT.STORAGE_LOCATION));
				memcpy(IBAKSERDAT.LOCATION, IQCMSERDAT.LOCATION, sizeof(IBAKSERDAT.LOCATION));
				memcpy(IBAKSERDAT.SHIFT, IQCMSERDAT.SHIFT, sizeof(IBAKSERDAT.SHIFT));
				memcpy(IBAKSERDAT.QUALITY_GRADE, IQCMSERDAT.QUALITY_GRADE, sizeof(IBAKSERDAT.QUALITY_GRADE));
				memcpy(IBAKSERDAT.POWER_GRADE, IQCMSERDAT.POWER_GRADE, sizeof(IBAKSERDAT.POWER_GRADE));
				memcpy(IBAKSERDAT.FQC_DEFECTCODE, IQCMSERDAT.FQC_DEFECTCODE, sizeof(IBAKSERDAT.FQC_DEFECTCODE));
				memcpy(IBAKSERDAT.DIST_ID, IQCMSERDAT.DIST_ID, sizeof(IBAKSERDAT.DIST_ID));
				memcpy(IBAKSERDAT.CMF_1, IQCMSERDAT.CMF_1, sizeof(IBAKSERDAT.CMF_1));
				memcpy(IBAKSERDAT.CMF_2, IQCMSERDAT.CMF_2, sizeof(IBAKSERDAT.CMF_2));
				memcpy(IBAKSERDAT.CMF_3, IQCMSERDAT.CMF_3, sizeof(IBAKSERDAT.CMF_3));
				memcpy(IBAKSERDAT.CMF_4, IQCMSERDAT.CMF_4, sizeof(IBAKSERDAT.CMF_4));
				memcpy(IBAKSERDAT.CMF_5, IQCMSERDAT.CMF_5, sizeof(IBAKSERDAT.CMF_5));
				IBAKSERDAT.DATA_FLAG = IQCMSERDAT.DATA_FLAG;
				memcpy(IBAKSERDAT.UPDATE_COUNT, IQCMSERDAT.UPDATE_COUNT, sizeof(IBAKSERDAT.UPDATE_COUNT));
				memcpy(IBAKSERDAT.INSERT_COUNT, IQCMSERDAT.INSERT_COUNT, sizeof(IBAKSERDAT.INSERT_COUNT));
				memcpy(IBAKSERDAT.DELETE_COUNT, IQCMSERDAT.DELETE_COUNT, sizeof(IBAKSERDAT.DELETE_COUNT));
				memcpy(IBAKSERDAT.SQL_DML_COUNT, IQCMSERDAT.SQL_DML_COUNT, sizeof(IBAKSERDAT.SQL_DML_COUNT));
				IBAKSERDAT.RETURN_TYPE = 'S';
				memcpy(IBAKSERDAT.RETURN_MSG, IQCMSERDAT.RETURN_MSG, sizeof(IBAKSERDAT.RETURN_MSG));
				memcpy(IBAKSERDAT.ZPICODE, IQCMSERDAT.ZPICODE, sizeof(IBAKSERDAT.ZPICODE));
				memcpy(IBAKSERDAT.ZPIMSGID, IQCMSERDAT.ZPIMSGID, sizeof(IBAKSERDAT.ZPIMSGID));
				memcpy(IBAKSERDAT.ZIFERNAM, IQCMSERDAT.ZIFERNAM, sizeof(IBAKSERDAT.ZIFERNAM));
				memcpy(IBAKSERDAT.ZIFDATE, IQCMSERDAT.ZIFDATE, sizeof(IBAKSERDAT.ZIFDATE));
				memcpy(IBAKSERDAT.ZIFTIME, IQCMSERDAT.ZIFTIME, sizeof(IBAKSERDAT.ZIFTIME));
				IBAKSERDAT.ZPISTAT = IQCMSERDAT.ZPISTAT;
				memcpy(IBAKSERDAT.ZPIMSG, IQCMSERDAT.ZPIMSG, sizeof(IBAKSERDAT.ZPIMSG));
				CDB_update_ibakserdat(1, &IBAKSERDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "IBAKSERDAT UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
					TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
					TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
					TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					CDB_close_iqcmserdat(2);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}

			// DELETE
			CDB_delete_iqcmserdat(1, &IQCMSERDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "IQCMSERDAT DELETE(1)", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBAKSERDAT.DOC_ID), IBAKSERDAT.DOC_ID);
				TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBAKSERDAT.SITE_ID), IBAKSERDAT.SITE_ID);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IBAKSERDAT.MODULE_ID), IBAKSERDAT.MODULE_ID);
				TRS.add_fieldmsg(out_node, "DIST_ID", MP_STR, sizeof(IBAKSERDAT.DIST_ID), IBAKSERDAT.DIST_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				CDB_close_iqcmserdat(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//모든 LOT의 이동이 확인 되었다면 이동 요청 마스터 CLOSE
			i_confirm = 0;
			i_confirm = (int)CDB_select_cwipreqdtl_scalar(2, &CWIPREQDTL);

			if (i_confirm == 0)
			{
				///이동 요청 마스터 CLOSE
				CDB_init_cwipreqmst(&CWIPREQMST);
				memcpy(CWIPREQMST.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CWIPREQMST.REQ_NO, CWIPREQDTL.REQ_NO, sizeof(CWIPREQDTL.REQ_NO));

				if (memcmp(IQCMSERDAT.QC_INSPECTION, "C", strlen("C")) == 0)
				{
					memcpy(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_RJ, strlen(HQCEL_M1_REQ_STATUS_RJ));
				}
				else
				{
					memcpy(CWIPREQMST.REQ_STATUS, HQCEL_M1_REQ_STATUS_C, strlen(HQCEL_M1_REQ_STATUS_C));
				}
				memcpy(CWIPREQMST.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
				memcpy(CWIPREQMST.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
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
					CDB_close_iqcmserdat(2);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}				
			DB_commit();
		}
	}	

	return MP_TRUE;
}