/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_start_lot.c
    Description : CWIP Start Lot Service

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Start_Lot()
            + Setup service interface function
        - CWIP_START_LOT()
            + Main sub function of CWIP_Start_Lot function
            + Setup service main business function
        - CWIP_Start_Lot_Oqc_Validation()
            + Main sub function of CWIP_START_LOT function
            + Check the condition for create/update/delete
    Detail Description
        - CWIP_START_LOT()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "UWIP_common.h"

int CWIP_Start_Lot_Oqc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Start_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Start_Lot_Oqc(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_START_LOT_OQC(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_START_LOT", out_node);

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
    CWIP_START_LOT()
        - Main sub function of "CWIP_Start_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_START_LOT_OQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
	// ºÒÇÊ¿ä ºÎºÐ ÁÖ¼®Ã³¸®
	/*
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    */

    char   s_sys_time[14];
	char   s_due_time[14];
	char   c_create_flag ;
    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("CWIP_Start_Lot_Oqc");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


	c_create_flag = ' '; // Server Crash 190925 ¹ÌÃÊ±âÈ­

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
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


    
    if(CWIP_Start_Lot_Oqc_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//0. ¼³ºñ ID GET
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

	//ÇöÀç Àåºñ°¡ TRANSACIOTN ¹ß»ý Àåºñ°¡ ¾Æ´Ï¸é Return True;
	if (MRASRESDEF.RES_CMF_4[0] != 'Y')
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}

    /* get material ID and  operation */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {	
			strcpy(s_msg_code, "WIP-0044");
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			//TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;	
        }
    }
	

	//LOT 이 현재공정이 아니면 현재공정까지 END 시킴.
	if (memcmp(MWIPLOTSTS.OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTSTS.OPER)) != 0)
	{
		/***************************************************/
		//END LOT -> 강제로
		/***************************************************/

		/* [GERP PROJECT] Store 상태면 Unstore 처리 */
		/* -----------시작-----------*/
		/* UNSTORE Lot */
		if (MWIPLOTSTS.INV_FLAG == HQCEL_FLAG_YES)
		{
			tran_in_node = TRS.create_node("UNSTORE_LOT_IN");
			tran_out_node = TRS.create_node("UNSTORE_LOT_OUT");

			CCOM_copy_in_node(in_node, tran_in_node);
			TRS.add_char(tran_in_node, "PROCSTEP", '1');
			TRS.add_string(tran_in_node, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

			TRS.add_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.STR_RET_FLOW, sizeof(MWIPLOTSTS.STR_RET_FLOW));
			TRS.add_nstring(tran_in_node, "BACK_TIME", MWIPLOTSTS.LAST_TRAN_TIME);


			if (memcmp(MWIPLOTSTS.STR_RET_OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTSTS.STR_RET_OPER)))
			{
				memcpy(MWIPLOTSTS.STR_RET_OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTSTS.STR_RET_OPER));
				DBC_update_mwiplotsts(1, &MWIPLOTSTS);
			}

			TRS.add_string(tran_in_node, "TO_OPER", MWIPLOTSTS.STR_RET_OPER, sizeof(MWIPLOTSTS.STR_RET_OPER));

			if (WIP_UNSTORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
				//TRS_add_all_member_to_log(tran_out_node);
			}
			
			//M4240 공정인 경우 릴리즈 후 로직 종료 23.11.15
		    if (memcmp(MWIPLOTSTS.OPER, HQCEL_M1_REWORK_OPER_E2, strlen(HQCEL_M1_REWORK_OPER_E2)) == 0) 
			{
				if(RELEASE_UNSTORE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
				{
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_TRUE;
			}


			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);

			/* get material ID and  operation */
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0044");
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

					//TRS.add_dberrmsg(out_node,DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
			}
		}

		tran_in_node = TRS.create_node("START_LOT_IN");
		tran_out_node = TRS.create_node("START_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
		TRS.add_string(tran_in_node, "FLOW",MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM); 
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		TRS.add_nstring(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "TRAN_TIME"));
		
		TRS.add_int(tran_in_node, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
			
		//ERP Interface ¸¦ À§ÇØ ÀÓ½ÃCOCE ( M3000, M3040, M3110 ) µ¥ÀÌÅÍ ÀÚµ¿»ý±è
		TRS.set_string(tran_in_node, "TO_FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.set_int(tran_in_node, "TO_FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
		TRS.set_string(tran_in_node, "TO_OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_3));

		if (MWIPLOTSTS.START_FLAG == 'Y')
		{
			//TRS.set_string(tran_in_node, "RES_ID", MWIPLOTSTS.START_RES_ID, sizeof(MWIPLOTSTS.START_RES_ID));

			//if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			//{
				//DO NOTHING
			//}


			//ÇØ´ç °øÁ¤À» ¿£µå½ÃÅ°¸é ÇØ´ç¼³ºñ°¡ ¶ôÀÌ °É·Á¼­ ±×³É ÀÌ·ÂÀ» »èÁ¦ÇÑ ÈÄ SKIPÇÏ´Â ÇüÅÂ·Î º¯°æÇÔ
			if(WIP_DELETE_LOT_HISTORY(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
				//TRS.init_node(out_node);
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}
			
			
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{	
					strcpy(s_msg_code, "WIP-0044");
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

					//TRS.add_dberrmsg(out_node,DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;	
				}
			}

			TRS.set_int(tran_in_node, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);


			
			if(WIP_SKIP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
				//TRS.init_node(out_node);
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}
		}
		else
		{
			if(WIP_SKIP_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				//DO NOTHING
				//TRS.init_node(out_node);
				TRS.clone(out_node, tran_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
				return MP_FALSE;
			}
		}
			

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DONOTHING
		}		
	}

    tran_in_node = TRS.create_node("START_LOT_IN");
    tran_out_node = TRS.create_node("START_LOT_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
	TRS.add_string(tran_in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2)); // ¼³ºñ ±âÁØÀÇ OPERATION »ç¿ë
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
	TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID")); // LINE ID ÇÊ¼ö
	TRS.add_nstring(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "TRAN_TIME"));
  
    if(CWIP_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
        //TRS.init_node(out_node);
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
    CWIP_Start_Lot_Oqc_Validation()
        - Main sub function of "CWIP_START_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Start_Lot_Oqc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CWIPRWKDAT_TAG CWIPRWKDAT;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;

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
	
	/*
	1. 패킹 이력이 있는 지 확인
	*/
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID");
	if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
	{
		CDB_init_cwiprwkdat(&CWIPRWKDAT);
		memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPRWKDAT.PROD_ORDER_NO, sizeof(CWIPRWKDAT.PROD_ORDER_NO), in_node, "REWORK_ORDER_ID");
		TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "LOT_ID");

		// 재작업 오더가 있는데 클로즈가안된 재작업 확인 없으면 재작업 오더가 없음
		if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) == 0)
		{
			strcpy(s_msg_code, "WIP-0616"); // This module requires a rework order
			TRS.add_fieldmsg(out_node, "Unpacked module without RWK order", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
    return MP_TRUE;
}




