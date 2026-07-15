/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_start_lot.c
    Description : Customized Start Lot Service

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Start_Lot()
            + Setup service interface function
        - CWIP_START_LOT()
            + Main sub function of CWIP_Start_Lot function
            + Setup service main business function
        - CWIP_Start_Lot_Validation()
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
    1     2018-11-21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"

int CWIP_Start_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Start_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Start_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_START_LOT(s_msg_code, in_node, out_node);

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
int CWIP_START_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MWIPCRRLOT_TAG MWIPCRRLOT;

    TRSNode* tran_in_node;
	int i_datacnt = 0;
	int i_crrlot_cnt = 0;
	clock_t start_time;

    LOG_head("CWIP_START_LOT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_Start_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    tran_in_node = TRS.create_node("START_LOT_IN");
    CCOM_copy_in_node(in_node, tran_in_node);
    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
    TRS.add_nstring(tran_in_node, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
	TRS.set_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_int(tran_in_node, "LAST_ACTIVE_HIST_SEQ", TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
	TRS.add_nstring(tran_in_node,  "MAT_ID", TRS.get_string(in_node, "MAT_ID")); 
    TRS.set_int(tran_in_node, "MAT_VER", TRS.get_int(in_node, "MAT_VER"));
    TRS.add_nstring(tran_in_node, "FLOW", TRS.get_string(in_node, "FLOW"));
    TRS.set_int(tran_in_node, "FLOW_SEQ_NUM", TRS.get_int(in_node, "FLOW_SEQ_NUM"));
    TRS.add_nstring(tran_in_node, "OPER", TRS.get_string(in_node, "OPER"));
    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.add_nstring(tran_in_node, "COMMENT", TRS.get_string(in_node, "COMMENT"));

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
    TRS.add_nstring(tran_in_node, "TRAN_CMF_11", TRS.get_string(in_node, "TRAN_CMF_11"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_12", TRS.get_string(in_node, "TRAN_CMF_12"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_13", TRS.get_string(in_node, "TRAN_CMF_13"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_14", TRS.get_string(in_node, "TRAN_CMF_14"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_15", TRS.get_string(in_node, "TRAN_CMF_15"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_16", TRS.get_string(in_node, "TRAN_CMF_16"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_17", TRS.get_string(in_node, "TRAN_CMF_17"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_18", TRS.get_string(in_node, "TRAN_CMF_18"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_19", TRS.get_string(in_node, "TRAN_CMF_19"));
    TRS.add_nstring(tran_in_node, "TRAN_CMF_20", TRS.get_string(in_node, "TRAN_CMF_20"));

	TRS.add_nstring(tran_in_node, "CLIENT_TIME", TRS.get_string(in_node, "CLIENT_TIME"));
	TRS.add_nstring(tran_in_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));

	//CUSTOM ADD
	TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));

	//Carrier Input Flag
	TRS.add_char(tran_in_node, "MAGAZINE_INPUT_FLAG", TRS.get_char(in_node, "MAGAZINE_INPUT_FLAG") );

	TRS.set_nstring(tran_in_node, "VMAGAZINE_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));
	TRS.set_nstring(tran_in_node, "MAGAZINE_ID", TRS.get_string(in_node, "MAGAZINE_ID"));
	TRS.set_char(tran_in_node, "FIRST_LOT_OF_MAGAZINE", 'Y');

	/* VMAGAZINE ID 를 START 시 TRAN_CMF_3  에 사용)*/
	if (COM_isnullspace(TRS.get_string(in_node, "VMAGAZINE_ID")) == MP_FALSE)
		TRS.set_nstring(tran_in_node, "TRAN_CMF_3", TRS.get_string(in_node, "VMAGAZINE_ID"));
	
	//공정에 따른 분기 
	//#define HQCEL_M1_CLEAVING_OPER                            ("M1000")
	//#define HQCEL_M1_LAYUP_OPER                               ("M2010")
	//#define HQCEL_M1_TABBER_OPER                              ("M2000")
	if (strcmp(TRS.get_string(tran_in_node, "OPER"), HQCEL_M1_CLEAVING_OPER) == 0)
	{
		if (TRS.get_char(tran_in_node, "MAGAZINE_INPUT_FLAG") == 'Y')
		{
			i_datacnt = 0;
			//MAGAZINE 으로 시작햇을경우.
			DBC_init_mwipcrrlot(&MWIPCRRLOT);
			TRS.copy(MWIPCRRLOT.FACTORY, sizeof(MWIPCRRLOT.FACTORY), tran_in_node, "FACTORY");
			TRS.copy(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID), tran_in_node, "LOT_ID"); //LOT_ID 에 캐리어 ID 가 올라옮

			i_crrlot_cnt = (int) DBC_select_mwipcrrlot_scalar(2, &MWIPCRRLOT);

			DBC_open_mwipcrrlot(101, &MWIPCRRLOT);
			if (DB_error_code != DB_SUCCESS)
			{
				//strcpy(s_msg_code, "RAS-00238");
				
				// 20210810 MES Application Memory leak 점검 및 수정
				// memcpy 메모리 침범 수정
				strcpy(s_msg_code, "RAS-0238");

				TRS.add_fieldmsg(out_node, "MWIPCRRLOT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				// 20210810 MES Application Memory leak 점검 및 수정
				// free_node call
				TRS.free_node(tran_in_node);

				return MP_FALSE;
			}
			while(1)
			{
				DBC_fetch_mwipcrrlot(101, &MWIPCRRLOT);
				if (DB_error_code == DB_NOT_FOUND)
				{
					DBC_close_mwipcrrlot(101);
					break;
				}
				// 20210810 MES Application Memory leak 점검 및 수정
				else if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPCRRLOT FETCH", MP_NVST);
					TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					DBC_close_mwipcrrlot(101);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(tran_in_node);

					return MP_FALSE;
				}
				
				TRS.set_string(tran_in_node, "LOT_ID", MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID));


				if (i_crrlot_cnt == i_datacnt+1)
				{
					//마지막 캐리어만 VALIDATION CHECK 함
					TRS.set_char(tran_in_node, "VALIDATE_CHECK_SKIP_FLAG", 'N');
				}
				else
				{
					TRS.set_char(tran_in_node, "VALIDATE_CHECK_SKIP_FLAG", 'Y');
				}

				if(CWIP_CLEAVING_START_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
				{
					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					DBC_close_mwipcrrlot(101);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(tran_in_node);
					return MP_FALSE;
				}
				i_datacnt++;
			}

			if (i_datacnt < 1)
			{
				/* FCELL 이 없더라도 생성되도록 수정 */
				TRS.set_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));
				if(CWIP_CLEAVING_START_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(tran_in_node);
					return MP_FALSE;
				}
				
				/*strcpy(s_msg_code, "RAS-0238");
				TRS.add_fieldmsg(out_node, "MWIPCRRLOT FETCH NOT FOUND", MP_NVST);
				TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				return MP_FALSE;*/
			}
			start_time = STOPWATCH_START();
			if(COM_isspace(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID)) == MP_FALSE)
			{
				struct MWIPLOTSTS_TAG MWIPLOTSTS;
				//CRRLOT 삭제..(이전데이터 정리를 위해 강제삭제)
				DBC_delete_mwipcrrlot(2, &MWIPCRRLOT);
				if (DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}

				CDB_init_mwiplotsts(&MWIPLOTSTS);
				memcpy(MWIPLOTSTS.CRR_ID, MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID));
				//LOT 의 CRR_ID CLEAR(이전데이터를 위해 강제 클리어)
				CDB_update_mwiplotsts(6, &MWIPLOTSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}
			STOPWATCH_END("CRR_CLEAR_ELAPSED_TIME", start_time);
		}
		else
		{
			//LOT 으로 시작했을경우
			if(CWIP_CLEAVING_START_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				return MP_FALSE;
			}
		}
		
	}
	else if (strcmp(TRS.get_string(tran_in_node, "OPER"), HQCEL_M1_LAYUP_OPER) == 0)
	{
		//LAYUP START 시 가상 모듈 ID 는 
		TRS.set_nstring(tran_in_node, "MODULE_ID", TRS.get_string(in_node, "LOT_ID"));

		if(CWIP_LAYUP_START_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}
	else if (strcmp(TRS.get_string(tran_in_node, "OPER"), HQCEL_M1_TABBER_OPER) == 0)
	{
		if (TRS.get_char(tran_in_node, "MAGAZINE_INPUT_FLAG") == 'Y')
		{
			i_datacnt = 0;
			//MAGAZINE 으로 시작햇을경우.
			DBC_init_mwipcrrlot(&MWIPCRRLOT);
			TRS.copy(MWIPCRRLOT.FACTORY, sizeof(MWIPCRRLOT.FACTORY), tran_in_node, "FACTORY");
			TRS.copy(MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID), tran_in_node, "LOT_ID"); //LOT_ID 에 캐리어 ID 가 올라옮
			DBC_open_mwipcrrlot(2, &MWIPCRRLOT);
			if (DB_error_code != DB_SUCCESS)
			{
				//strcpy(s_msg_code, "RAS-00238");

				// 20210810 MES Application Memory leak 점검 및 수정
				// memcpy 메모리 침범 수정
				strcpy(s_msg_code, "RAS-0238");

				TRS.add_fieldmsg(out_node, "MWIPCRRLOT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				TRS.free_node(tran_in_node);
				return MP_FALSE;
			}
			while(1)
			{
				DBC_fetch_mwipcrrlot(2, &MWIPCRRLOT);
				if (DB_error_code == DB_NOT_FOUND)
				{
					DBC_close_mwipcrrlot(2);
					break;
				}
				// 20210810 MES Application Memory leak 점검 및 수정
				else if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MWIPCRRLOT FETCH", MP_NVST);
					TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					DBC_close_mwipcrrlot(2);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(tran_in_node);

					return MP_FALSE;
				}
				
				TRS.set_string(tran_in_node, "LOT_ID", MWIPCRRLOT.LOT_ID, sizeof(MWIPCRRLOT.LOT_ID));
				if(i_datacnt > 0)
				{
					TRS.set_char(tran_in_node, "FIRST_LOT_OF_MAGAZINE", 'N');
				}

				if(CWIP_TABBER_START_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
				{
					// 20210810 MES Application Memory leak 점검 및 수정
					// DB Close 추가
					DBC_close_mwipcrrlot(2);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

					TRS.free_node(tran_in_node);
					return MP_FALSE;
				}
				i_datacnt++;
			}

			if (i_datacnt < 1)
			{
				strcpy(s_msg_code, "RAS-0238");
				TRS.add_fieldmsg(out_node, "MWIPCRRLOT FETCH NOT FOUND", MP_NVST);
				TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MWIPCRRLOT.CRR_ID), MWIPCRRLOT.CRR_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				TRS.free_node(tran_in_node);
				return MP_FALSE;
			}

			{
				struct MWIPLOTSTS_TAG MWIPLOTSTS;
				//CRRLOT 삭제..(이전데이터 정리를 위해 강제삭제)
				DBC_delete_mwipcrrlot(2, &MWIPCRRLOT);
				if (DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}

				CDB_init_mwiplotsts(&MWIPLOTSTS);
				memcpy(MWIPLOTSTS.CRR_ID, MWIPCRRLOT.CRR_ID, sizeof(MWIPCRRLOT.CRR_ID));
				//LOT 의 CRR_ID CLEAR(이전데이터를 위해 강제 클리어)
				CDB_update_mwiplotsts(6, &MWIPLOTSTS);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
		

			}
		}
		else
		{
			//LOT 으로 시작했을경우
			if(CWIP_TABBER_START_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(tran_in_node);
				return MP_FALSE;
			}
		}
	}
	else
	{
		if(WIP_START_LOT(s_msg_code, tran_in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			return MP_FALSE;
		}
	}

	TRS.free_node(tran_in_node);

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Start_Lot_Validation()
        - Main sub function of "CWIP_START_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Start_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct MWIPLOTSTS_TAG MWIPLOTSTS;
//    struct MWIPFACDEF_TAG MWIPFACDEF;

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
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

   
    return MP_TRUE;
}

