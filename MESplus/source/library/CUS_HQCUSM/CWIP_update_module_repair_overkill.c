/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_module_repair_overkill.c
    Description : Module Repaires

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Select()
            + Create/Update/Delete Select definition
        - CWIP_UPDATE_SELECT()
            + Main sub function of CWIP_Update_Select function
            + Create/Update/Delete Select definition
    Detail Description
        - CWIP_UPDATE_SELECT()
            + h_proc_step
                + MP_STEP_CREATE : Create Select definition
                + MP_STEP_UPDATE : Update Select definition
                + MP_STEP_DELETE : Delete Select definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019-01-14             SW.HWANG

    Copyright(C) 1998-2019 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_MODULE_REPAIR_OVERKILL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_UPDATE_MODULE_REPAIR_OVERKILL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_DELETE_MODULE_REPAIR_OVERKILL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Select()
        - Create/Update/Delete Select definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Module_Repair_Overkill(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];	
	int i_ret;	

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	i_ret = MP_TRUE;

	if(TRS.get_procstep(in_node) == '2'){
		i_ret = CWIP_VIEW_MODULE_REPAIR_OVERKILL(s_msg_code, in_node, out_node);
	}
	else if(TRS.get_procstep(in_node) == '3'){
		i_ret = CWIP_UPDATE_MODULE_REPAIR_OVERKILL(s_msg_code, in_node, out_node);
	}	
	else if(TRS.get_procstep(in_node) == '4'){
		i_ret = CWIP_DELETE_MODULE_REPAIR_OVERKILL(s_msg_code, in_node, out_node);
	}

	
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
	CWIP_VIEW_MODULE_REPAIR_OVERKILL()
		- Main sub function of "CWIP_VIEW_MODULE_REPAIR_OVERKILL" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_MODULE_REPAIR_OVERKILL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPCELLOS_TAG CWIPCELLOS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CWIPLOTTRC_TAG CWIPLOTTRC;
    struct CEDCLOTSUA_TAG CEDCLOTSUA;
    struct MWIPELTSTS_TAG MWIPELTSTS;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	//[2025/01/17] Management Module Repair add AOI Image And Loss Data
	struct CWIPLOTIMG_TAG CWIPLOTIMG;

	// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
	struct CWIPLOTOVR_TAG CWIPLOTOVR;
	
	
	int i_lossseq;
	int i_step;

	TRSNode *list_item;
    
    LOG_head("CWIP_VIEW_MODULE_REPAIR_OVERKILL");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
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
		TRS.set_string(out_node, "RES_ID", MWIPLOTSTS.END_RES_ID, sizeof(MWIPLOTSTS.END_RES_ID));
	    TRS.set_string(out_node, "LINE_ID", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
	}

	//LOT TRACE TABLE
	CDB_init_cwiplottrc(&CWIPLOTTRC);
	memcpy(CWIPLOTTRC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_cwiplottrc(1, &CWIPLOTTRC);
	if(DB_error_code != DB_SUCCESS)
    {
		//DO NOTHING
	}
	TRS.set_string(out_node, "TABBER_ID", CWIPLOTTRC.TAB_RES_ID, sizeof(CWIPLOTTRC.TAB_RES_ID));
	
    // 0:Manual, 1:Semi Auto, 2:Semi Full Auto, 3:Full Auto
    // Full Auto Mode 일때만 과검 판정 가능하도록 수정.
    // 아래의 값들은 항상 보내주는 코드로 수정.
    CDB_init_cedclotsua(&CEDCLOTSUA);

	// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
	memcpy(CEDCLOTSUA.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));

    memcpy(CEDCLOTSUA.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_cedclotsua(2, &CEDCLOTSUA);
	
    if(DB_error_code != DB_SUCCESS)
    {
		//DO NOTHING

		// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
		TRS.set_int(out_node, "OVERKILL_VALUE", 0);
		TRS.set_int(out_node, "OVERKILL_ENABLE", 0);
	}
	else
	{
		TRS.set_string(out_node, "RES_ID", CEDCLOTSUA.RES_ID, sizeof(CEDCLOTSUA.RES_ID));
	    TRS.set_char(out_node, "MODE_CODE", CEDCLOTSUA.MODE_CODE);
		TRS.set_string(out_node, "LINE_ID", CEDCLOTSUA.LINE_ID, sizeof(CEDCLOTSUA.LINE_ID));

		// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
		if(CEDCLOTSUA.INS_CNT == 1)
		{
			TRS.set_int(out_node, "OVERKILL_ENABLE", 1);
		}
		else
		{
			TRS.set_int(out_node, "OVERKILL_ENABLE", 0);
		}

		CDB_init_cwiplotovr(&CWIPLOTOVR);
		TRS.copy(CWIPLOTOVR.FACTORY, sizeof(CWIPLOTOVR.FACTORY), in_node, IN_FACTORY);
		memcpy(CWIPLOTOVR.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CWIPLOTOVR.LOT_ID));
		CDB_select_cwiplotovr(2, &CWIPLOTOVR);
		if(DB_error_code != DB_SUCCESS)
		{
			// Nothing
		}

		if(CWIPLOTOVR.OVERKILL_FLAG == 'Y')
		{
			TRS.set_int(out_node, "OVERKILL_VALUE", 1);
		}
		else
		{
			TRS.set_int(out_node, "OVERKILL_VALUE", 0);
		}

	}
    
	//후단을 제외한 최신 모듈 이미지를 찾아온다.
	//FEL REL 중 최신것으로 한다.
    CDB_init_mwipeltsts(&MWIPELTSTS);
    memcpy(MWIPELTSTS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_mwipeltsts(2, &MWIPELTSTS);
	
    if(DB_error_code != DB_SUCCESS)
    {
		//DO NOTHING
	}
	else
	{
		CDB_init_cedclotrlt(&CEDCLOTRLT);
		TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
		memcpy(CEDCLOTRLT.INS_TYPE, "E1", strlen("E1"));
		CDB_select_cedclotrlt(1, &CEDCLOTRLT);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		else
		{
			if(CEDCLOTRLT.RES_ID[6] == 'F')
			{	//US-E1-FEL-01
				TRS.set_string(out_node, "EL_IMAGE_PATH", MWIPELTSTS.EL_IMAGE_PATH, sizeof(MWIPELTSTS.EL_IMAGE_PATH));
				TRS.set_string(out_node, "INS_TIME", CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));
			}
			else
			{	//US-E1-REL-01
				TRS.set_string(out_node, "EL_IMAGE_PATH", MWIPELTSTS.EL_IMAGE_PATH2, sizeof(MWIPELTSTS.EL_IMAGE_PATH));
				TRS.set_string(out_node, "INS_TIME", CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));
			}
		}
	}
	//[2025.01.20]Module Management Repair
	//AOI 모듈 이미지를 찾아온다.
    CDB_init_cwiplotimg(&CWIPLOTIMG);
	TRS.copy(CWIPLOTIMG.FACTORY, sizeof(CWIPLOTIMG.FACTORY), in_node, IN_FACTORY); 
    memcpy(CWIPLOTIMG.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    memcpy(CWIPLOTIMG.IMAGE_TYPE, "AOI", sizeof("AOI"));
	CDB_select_cwiplotimg(1, &CWIPLOTIMG);
	
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.set_string(out_node, "AOI_IMAGE_PATH", CWIPLOTIMG.IMAGE_PATH, sizeof(CWIPLOTIMG.IMAGE_PATH));
		TRS.set_string(out_node, "AOI_INS_TIME", CWIPLOTIMG.CREATE_TIME, sizeof(CWIPLOTIMG.CREATE_TIME));
	}
	else
	{
		//Do nothing
	}
	//[2025.01.20]Module Management Repair
	//AOI 모듈 이미지를 찾아온다.
    CDB_init_cwiplotimg(&CWIPLOTIMG);
	TRS.copy(CWIPLOTIMG.FACTORY, sizeof(CWIPLOTIMG.FACTORY), in_node, IN_FACTORY); 
    memcpy(CWIPLOTIMG.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
    memcpy(CWIPLOTIMG.IMAGE_TYPE, "AOI", sizeof("AOI"));
	CDB_select_cwiplotimg(1, &CWIPLOTIMG);
	
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.set_string(out_node, "AOI_IMAGE_PATH", CWIPLOTIMG.IMAGE_PATH, sizeof(CWIPLOTIMG.IMAGE_PATH));
		TRS.set_string(out_node, "AOI_INS_TIME", CWIPLOTIMG.CREATE_TIME, sizeof(CWIPLOTIMG.CREATE_TIME));
	}
	else
	{
		//Do nothing
	}
	//IS-21-08-016 GAP LESS module의 cell 체크

	/* Get material(PRODUCT) information */
	DBC_init_mwipmatdef(&MWIPMATDEF);
	memcpy(MWIPMATDEF.FACTORY, CEDCLOTRLT.FACTORY, sizeof(MWIPMATDEF.FACTORY));
	memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	MWIPMATDEF.MAT_VER = 1;

	DBC_select_mwipmatdef(1, &MWIPMATDEF);
	if(DB_error_code != DB_SUCCESS)
	{
	
	}

	TRS.set_string(out_node, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));
	//IS-21-08-016 GAP LESS module의 cell 체크

	i_lossseq = 1;

    //i_step = 2;
    i_step = 4;

    CDB_init_cwipcellos(&CWIPCELLOS);
    TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");
	
    //memcpy(CWIPCELLOS.LOSS_CATEGORY, "E1", strlen("E1")); // CDB_open_cwipcellos(4,&CWIPCELLOS); 로 쿼리 수정. CWIPCELLOS.LOSS_CATEGORY, "E1"로 값 넣을 필요 없음.
	//TRS.copy(CWIPCELLOS.LOSS_CATEGORY, sizeof(CWIPCELLOS.LOSS_CATEGORY), in_node, "LOSS_CATEGORY");
	
	CDB_open_cwipcellos(i_step,&CWIPCELLOS);
    if(DB_error_code != DB_SUCCESS)
    {        
        strcpy(s_msg_code, "BOM-0004");
        TRS.add_fieldmsg(out_node, "CWIPCELLOS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELLOS.FACTORY), CWIPCELLOS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPCELLOS.LOT_ID), CWIPCELLOS.LOT_ID);
		TRS.add_fieldmsg(out_node, "LOSS_CATEGORY", MP_STR, sizeof(CWIPCELLOS.LOSS_CATEGORY), CWIPCELLOS.LOSS_CATEGORY);

        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		
		// 20210810 MES Application Memory leak 점검 및 수정
		// OPEN 하지 않은 상태에서 CLOSE 처리하는 부분 주석 처리
		//CDB_close_cwipcellos(i_step);
        
		return MP_FALSE;
    }

    while(1) 
    {
        CDB_fetch_cwipcellos(i_step,&CWIPCELLOS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipcellos(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "CWIPCELLOS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELLOS.FACTORY), CWIPCELLOS.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPCELLOS.LOT_ID), CWIPCELLOS.LOT_ID);
			TRS.add_fieldmsg(out_node, "LOSS_CATEGORY", MP_STR, sizeof(CWIPCELLOS.LOSS_CATEGORY), CWIPCELLOS.LOSS_CATEGORY);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_cwipcellos(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Get material data */
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
		memcpy(MGCMTBLDAT.KEY_1, CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));

		//2020-01-10, B1 또는 B2는 버스바로 등록된 불량이라서 분기 처리 
		if (memcmp(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_BUSBAR1, strlen(HQCEL_INS_TYPE_CATEGORY_BUSBAR1)) == 0
			|| memcmp(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_BUSBAR2, strlen(HQCEL_INS_TYPE_CATEGORY_BUSBAR2)) == 0)
		{
			memcpy(MGCMTBLDAT.DATA_2, "BUSBAR", strlen("BUSBAR"));
		}
		else
		{
			memcpy(MGCMTBLDAT.DATA_2, "EL", strlen("EL"));
		}

        DBC_select_mgcmtbldat(103, &MGCMTBLDAT);
        
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
				/*
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPCELLOS.LOSS_CODE), CWIPCELLOS.LOSS_CODE);
				*/

				// 20210810 MES Application Memory leak 점검 및 수정
				// log edit
                strcpy(s_msg_code, "GCM-0007");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(CWIPCELLOS.LOSS_CODE), CWIPCELLOS.LOSS_CODE);
                
                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                
				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipcellos(i_step);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "LIST");
        TRS.add_string(list_item, "LOSS_CATEGORY", CWIPCELLOS.LOSS_CATEGORY, sizeof(CWIPCELLOS.LOSS_CATEGORY));
        TRS.add_string(list_item, "CELL_ID", CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID));
		TRS.add_string(list_item, "STRING_ID", CWIPCELLOS.STRING_ID, sizeof(CWIPCELLOS.STRING_ID));
        TRS.add_string(list_item, "LOSS_CODE", CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));
		TRS.add_string(list_item, "LOSS_DESC", MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_3));
        TRS.add_string(list_item, "LOSS_TYPE", CWIPCELLOS.LOSS_TYPE, sizeof(CWIPCELLOS.LOSS_TYPE));
		TRS.add_string(list_item, "LOSS_GROUP", CWIPCELLOS.LOSS_GROUP, sizeof(CWIPCELLOS.LOSS_GROUP));
        TRS.add_string(list_item, "LOCATION_ID", CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID));
		TRS.add_string(list_item, "LOT_ID", CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID));
        TRS.add_string(list_item, "MAT_ID", CWIPCELLOS.MAT_ID, sizeof(CWIPCELLOS.MAT_ID));
		TRS.add_string(list_item, "FLOW", CWIPCELLOS.FLOW, sizeof(CWIPCELLOS.FLOW));
        TRS.add_string(list_item, "OPER", CWIPCELLOS.OPER, sizeof(CWIPCELLOS.OPER));
		TRS.add_string(list_item, "ORDER_ID", CWIPCELLOS.ORDER_ID, sizeof(CWIPCELLOS.ORDER_ID));
        TRS.add_string(list_item, "LINE_ID", CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID));
		TRS.add_string(list_item, "RES_ID", CWIPCELLOS.RES_ID, sizeof(CWIPCELLOS.RES_ID));
		TRS.add_string(list_item, "INV_LOT_ID", CWIPCELLOS.INV_LOT_ID, sizeof(CWIPCELLOS.INV_LOT_ID));
        
		if (COM_isspace(CWIPCELLOS.LOC_X, sizeof(CWIPCELLOS.LOC_X)) == MP_TRUE)
		{
			CWIPCELLOS.LOC_X[0] = CWIPCELLOS.LOCATION_ID[0];
		}
		TRS.add_string(list_item, "LOC_X", CWIPCELLOS.LOC_X, sizeof(CWIPCELLOS.LOC_X));

		if (COM_isspace(CWIPCELLOS.LOC_Y, sizeof(CWIPCELLOS.LOC_Y)) == MP_TRUE)
		{
			memcpy(CWIPCELLOS.LOC_Y, CWIPCELLOS.LOCATION_ID+1, 3);
		}

		TRS.add_string(list_item, "LOC_Y", CWIPCELLOS.LOC_Y, sizeof(CWIPCELLOS.LOC_Y));
		TRS.add_string(list_item, "CMF_1", CWIPCELLOS.CMF_1, sizeof(CWIPCELLOS.CMF_1));
		TRS.add_string(list_item, "CMF_2", CWIPCELLOS.CMF_2, sizeof(CWIPCELLOS.CMF_2));
		TRS.add_string(list_item, "CMF_3", CWIPCELLOS.CMF_3, sizeof(CWIPCELLOS.CMF_3));
		TRS.add_string(list_item, "CMF_4", CWIPCELLOS.CMF_4, sizeof(CWIPCELLOS.CMF_4));
		TRS.add_string(list_item, "CMF_5", CWIPCELLOS.CMF_5, sizeof(CWIPCELLOS.CMF_5));
		TRS.add_string(list_item, "COLOR", MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4));
		TRS.add_string(list_item, "WORK_DATE", CWIPCELLOS.WORK_DATE, sizeof(CWIPCELLOS.WORK_DATE));
		TRS.add_nstring(list_item, "SAVE_TYPE", "LOSS"); //불량과 / 수리의 구분.
		TRS.add_int(list_item, "LOSS_SEQ", CWIPCELLOS.LOSS_SEQ);
		TRS.add_int(list_item, "DATA_SEQ",i_lossseq++);
    }

	//REPAIR 정보 GET
	CDB_init_cwipcellos(&CWIPCELLOS);
    TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");
	
    //CWIPCELLOS.LOSS_CATEGORY 에 값 넣을 필요 없음.
    //memcpy(CWIPCELLOS.LOSS_CATEGORY, "R-E1", strlen("R-E1")); 'R-E1', 'R-E2', 'R-B1', 'R-B2' 로 검색 CDB_open_cwipcellos(5,&CWIPCELLOS)로 쿼리 
    
	//TRS.copy(CWIPCELLOS.LOSS_CATEGORY, sizeof(CWIPCELLOS.LOSS_CATEGORY), in_node, "LOSS_CATEGORY");
	
    //20190916 LOSS_CATEGROY 'R-E1', 'R-E2', 'R-B1', 'R-B2' 로 검색
    //i_step = 5로 새로운 쿼리 생성.
    i_step = 5;
	
    CDB_open_cwipcellos(i_step,&CWIPCELLOS);
    if(DB_error_code != DB_SUCCESS)
    {        
        strcpy(s_msg_code, "BOM-0004");
        TRS.add_fieldmsg(out_node, "CWIPCELLOS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELLOS.FACTORY), CWIPCELLOS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPCELLOS.LOT_ID), CWIPCELLOS.LOT_ID);
		TRS.add_fieldmsg(out_node, "LOSS_CATEGORY", MP_STR, sizeof(CWIPCELLOS.LOSS_CATEGORY), CWIPCELLOS.LOSS_CATEGORY);

        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		
		// 20210810 MES Application Memory leak 점검 및 수정
		// OPEN 하지 않은 상태에서 CLOSE 처리하는 부분 주석 처리
		//CDB_close_cwipcellos(i_step);

		return MP_FALSE;
    }

    while(1) 
    {
        CDB_fetch_cwipcellos(i_step,&CWIPCELLOS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            //DBC_close_mbomsetmat(i_step);

			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Close 추가
			CDB_close_cwipcellos(i_step);

            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "CWIPCELLOS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELLOS.FACTORY), CWIPCELLOS.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPCELLOS.LOT_ID), CWIPCELLOS.LOT_ID);
			TRS.add_fieldmsg(out_node, "LOSS_CATEGORY", MP_STR, sizeof(CWIPCELLOS.LOSS_CATEGORY), CWIPCELLOS.LOSS_CATEGORY);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            //DBC_close_mbomsetmat(i_step);

			// 20210810 MES Application Memory leak 점검 및 수정
			// DB Close 추가
			CDB_close_cwipcellos(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Get material data */
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		
		if (memcmp(CWIPCELLOS.CREATE_TIME, "20190218123000", 14) > 0)
			memcpy(MGCMTBLDAT.TABLE_NAME, "@REPAIR_CODE", strlen("@REPAIR_CODE"));
		else
			memcpy(MGCMTBLDAT.TABLE_NAME, "@REPAIR", strlen("@REPAIR"));

		memcpy(MGCMTBLDAT.KEY_1, CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));

        DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
				/*
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPCELLOS.LOSS_CODE), CWIPCELLOS.LOSS_CODE);
				*/

				// 20210810 MES Application Memory leak 점검 및 수정
				// log edit
                strcpy(s_msg_code, "GCM-0007");
                TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(CWIPCELLOS.LOSS_CODE), CWIPCELLOS.LOSS_CODE);

                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipcellos(i_step);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "LIST");
        TRS.add_string(list_item, "LOSS_CATEGORY", CWIPCELLOS.LOSS_CATEGORY, sizeof(CWIPCELLOS.LOSS_CATEGORY));
        TRS.add_string(list_item, "CELL_ID", CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID));
		TRS.add_string(list_item, "STRING_ID", CWIPCELLOS.STRING_ID, sizeof(CWIPCELLOS.STRING_ID));
        TRS.add_string(list_item, "LOSS_CODE", CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));
		TRS.add_string(list_item, "LOSS_DESC", MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2));
        TRS.add_string(list_item, "LOSS_TYPE", CWIPCELLOS.LOSS_TYPE, sizeof(CWIPCELLOS.LOSS_TYPE));
		TRS.add_string(list_item, "LOSS_GROUP", CWIPCELLOS.LOSS_GROUP, sizeof(CWIPCELLOS.LOSS_GROUP));
        TRS.add_string(list_item, "LOCATION_ID", CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID));
		TRS.add_string(list_item, "LOT_ID", CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID));
        TRS.add_string(list_item, "MAT_ID", CWIPCELLOS.MAT_ID, sizeof(CWIPCELLOS.MAT_ID));
		TRS.add_string(list_item, "FLOW", CWIPCELLOS.FLOW, sizeof(CWIPCELLOS.FLOW));
        TRS.add_string(list_item, "OPER", CWIPCELLOS.OPER, sizeof(CWIPCELLOS.OPER));
		TRS.add_string(list_item, "ORDER_ID", CWIPCELLOS.ORDER_ID, sizeof(CWIPCELLOS.ORDER_ID));
        TRS.add_string(list_item, "LINE_ID", CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID));
		TRS.add_string(list_item, "RES_ID", CWIPCELLOS.RES_ID, sizeof(CWIPCELLOS.RES_ID));
		TRS.add_string(list_item, "INV_LOT_ID", CWIPCELLOS.INV_LOT_ID, sizeof(CWIPCELLOS.INV_LOT_ID));
        
		if (COM_isspace(CWIPCELLOS.LOC_X, sizeof(CWIPCELLOS.LOC_X)) == MP_TRUE)
		{
			CWIPCELLOS.LOC_X[0] = CWIPCELLOS.LOCATION_ID[0];
		}
		TRS.add_string(list_item, "LOC_X", CWIPCELLOS.LOC_X, sizeof(CWIPCELLOS.LOC_X));

		if (COM_isspace(CWIPCELLOS.LOC_Y, sizeof(CWIPCELLOS.LOC_Y)) == MP_TRUE)
		{
			memcpy(CWIPCELLOS.LOC_Y, CWIPCELLOS.LOCATION_ID+1, 3);
		}

		TRS.add_string(list_item, "LOC_Y", CWIPCELLOS.LOC_Y, sizeof(CWIPCELLOS.LOC_Y));
		TRS.add_string(list_item, "CMF_1", CWIPCELLOS.CMF_1, sizeof(CWIPCELLOS.CMF_1));
		TRS.add_string(list_item, "CMF_2", CWIPCELLOS.CMF_2, sizeof(CWIPCELLOS.CMF_2));
		TRS.add_string(list_item, "CMF_3", CWIPCELLOS.CMF_3, sizeof(CWIPCELLOS.CMF_3)); //CHANGE QTY
		TRS.add_string(list_item, "CHANGE_QTY", CWIPCELLOS.CMF_3, sizeof(CWIPCELLOS.CMF_3)); //CHANGE QTY
		TRS.add_string(list_item, "BACK_COLOR", CWIPCELLOS.CMF_4, sizeof(CWIPCELLOS.CMF_5));
		TRS.add_string(list_item, "WORK_DATE", CWIPCELLOS.WORK_DATE, sizeof(CWIPCELLOS.WORK_DATE));
		TRS.add_nstring(list_item, "SAVE_TYPE", "REPAIR"); //불량과 / 수리의 구분.
		TRS.add_int(list_item, "LOSS_SEQ", CWIPCELLOS.LOSS_SEQ);
		TRS.add_int(list_item, "DATA_SEQ",i_lossseq++);
    }
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 


/*******************************************************************************
    CWIP_UPDATE_MODULE_REPAIR_OVERKILL()
        - Main sub function of "CWIP_Update_Select" function
        - Create/Update/Delete Select definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_MODULE_REPAIR_OVERKILL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	// INIT
    struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CWIPCELLOS_TAG CWIPCELLOS_CNT;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPLOTREP_TAG CWIPLOTREP;
	struct CWIPLOTREP_TAG CWIPLOTREP_CNT;
	struct CWIPLOTREH_TAG CWIPLOTREH;

	// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
	struct CWIPLOTOVR_TAG CWIPLOTOVR;
	struct CWIPLOTOVH_TAG CWIPLOTOVH;

	// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
	// 1차 프로시저 제거를 위하여 기본값 추가
	struct CEDCLOTRLH_TAG CEDCLOTRLH;

	int nUseOverkill = 0;


    char   s_sys_time[14];
	char sworker1[31];
	char sworker2[31];
	
	TRSNode** list;
	int i;
	int iLossSeq = 0;
	int iInsCnt = 0;
	int iRepairCnt = 0;
	long l_ChangeQty = 0;
	
	struct worktime_tag cur_work_time;
	char c_work_shift;
	
	// PROCESS LOT PRINT
    LOG_head("CWIP_UPDATE_MODULE_REPAIR_OVERKILL");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
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

	//memcpy(s_sys_time, "20190219055900", 14);
	/* CURRENT WORK TIME / WORK SHIFT GET   */
	CCOM_get_work_time(s_sys_time, &cur_work_time);
	c_work_shift = CCOM_get_work_shift(s_sys_time);
	
	//		
	// GET MWIPLOTSTS INFORMATION #############################################
	//LOG_head("MWIPLOTSTS_SELECT");
	//LOG_add("h_language", MP_CHR, TRS.get_language(in_node));

	memset(sworker1, ' ', sizeof(sworker1));
	memset(sworker2, ' ', sizeof(sworker2));
	

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);

	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
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

	// PROCESS
    
	CDB_init_cwiplotrep(&CWIPLOTREP_CNT);
	memcpy(CWIPLOTREP_CNT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CWIPLOTREP_CNT.CATEGORY,"R-E1", strlen("R-E1"));
	TRS.copy(CWIPLOTREP_CNT.LOT_ID, sizeof(CWIPLOTREP_CNT.LOT_ID), in_node, "LOT_ID");
	//20190919 전단 버스바 CDB_select_cwiplotrep_scalar(2,&CWIPLOTREP_CNT); -> CDB_select_cwiplotrep_scalar(3,&CWIPLOTREP_CNT);
	iInsCnt = (int) CDB_select_cwiplotrep_scalar(3,&CWIPLOTREP_CNT);
	

	CDB_init_cwipcellos(&CWIPCELLOS_CNT);
	memcpy(CWIPCELLOS_CNT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPCELLOS_CNT.LOT_ID, sizeof(CWIPCELLOS_CNT.CELL_ID), in_node, "LOT_ID");
	memcpy(CWIPLOTREP_CNT.CATEGORY,"R-E1", strlen("R-E1")); //20191010 R-E1의 최종 MAX LOSS_SEQ가져오기
	iLossSeq = (int) CDB_select_cwipcellos_scalar(2,&CWIPCELLOS_CNT);

	CDB_init_cwipcellos(&CWIPCELLOS);
	// GET MWIPLOTSTS INFORMATION #############################################
	iRepairCnt = 0;
	l_ChangeQty = 0;
	list = TRS.get_list(in_node, "LOSS_LIST");		
	for (i = 0; i < TRS.get_item_count(in_node, "LOSS_LIST"); i++)
	{
		// PROCESS
		
		if (TRS.get_char(list[i], "SAVE_FLAG") != 'I')
			continue;

		iLossSeq = iLossSeq + 1;

		CDB_init_cwipcellos(&CWIPCELLOS);
		memcpy(CWIPCELLOS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");
		
		CWIPCELLOS.LOSS_SEQ = iLossSeq;
		//TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), list[i], "CELL_ID");
		TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LOT_ID");
		TRS.copy(CWIPCELLOS.STRING_ID, sizeof(CWIPCELLOS.STRING_ID), list[i], "STRING_ID");
		TRS.copy(CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID), list[i], "LOCATION_ID");
		CWIPCELLOS.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
		CWIPCELLOS.TYPE_FLAG[0] = '1';
		TRS.copy(CWIPCELLOS.LOSS_GROUP, sizeof(CWIPCELLOS.LOSS_GROUP), list[i], "LOSS_GROUP");
		TRS.copy(CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE), list[i], "LOSS_CODE");
		TRS.copy(CWIPCELLOS.LOSS_TYPE, sizeof(CWIPCELLOS.LOSS_TYPE), list[i], "LOSS_TYPE");
		TRS.copy(CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID), in_node, "LINE_ID");
		memcpy(CWIPCELLOS.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		memcpy(CWIPCELLOS.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		memcpy(CWIPCELLOS.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
		memcpy(CWIPCELLOS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		//memcpy(CWIPCELLOS.LINE_ID, MWIPLOTSTS.LOT_CMF_1, sizeof(CWIPCELLOS.LINE_ID));		
		CWIPCELLOS.LOSS_QTY = TRS.get_double(list[i],"LOSS_QTY");
		TRS.copy(CWIPCELLOS.LOC_X, sizeof(CWIPCELLOS.LOC_X), list[i], "LOC_X");
		TRS.copy(CWIPCELLOS.LOC_Y, sizeof(CWIPCELLOS.LOC_Y), list[i], "LOC_Y");
		TRS.copy(CWIPCELLOS.WORKER, sizeof(CWIPCELLOS.WORKER), list[i], "WORKER");
		memcpy(CWIPCELLOS.TRAN_TIME, s_sys_time, sizeof(CWIPCELLOS.TRAN_TIME));
		memcpy(CWIPCELLOS.CREATE_TIME, s_sys_time, sizeof(CWIPCELLOS.CREATE_TIME));
		TRS.copy(CWIPCELLOS.CMF_1, sizeof(CWIPCELLOS.CMF_1), list[i], "CMF_1");  
		TRS.copy(CWIPCELLOS.CMF_2, sizeof(CWIPCELLOS.CMF_2), list[i], "CMF_2");
		TRS.copy(CWIPCELLOS.CMF_3, sizeof(CWIPCELLOS.CMF_3), list[i], "CHANGE_QTY");
		TRS.copy(CWIPCELLOS.CMF_4, sizeof(CWIPCELLOS.CMF_4), list[i], "SAVE_COLOR");
		TRS.copy(CWIPCELLOS.CMF_5, sizeof(CWIPCELLOS.CMF_5), list[i], "SAVE_TYPE");
		TRS.copy(CWIPCELLOS.LOSS_CATEGORY, sizeof(CWIPCELLOS.LOSS_CATEGORY), list[i], "LOSS_CATEGORY"); 
		//20191010 R-E1 으로 합치기 memcpy(CWIPCELLOS.LOSS_CATEGORY,"R-E1", strlen("R-E1"));
		CWIPCELLOS.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

		if (COM_isspace(sworker1, sizeof(sworker1)) == MP_TRUE)
		{
			TRS.copy(sworker1, sizeof(sworker1), list[i], "WORKER");
			TRS.copy(sworker2, sizeof(sworker2), list[i], "WORKER2");
		}

		//LOSS 는 저장 안하고 REPAIR 만 저장함.
		if (memcmp(CWIPCELLOS.CMF_5, "LOSS", 4) == 0)
			continue;

		TRS.copy(CWIPCELLOS.LOSS_COMMENT, sizeof(CWIPCELLOS.LOSS_COMMENT), in_node, "REPAIR_DETAIL");
		
		CWIPCELLOS.WORK_SHIFT = c_work_shift;
		memcpy(CWIPCELLOS.WORK_DATE, cur_work_time.work_date, 8);
		CWIPCELLOS.INS_CNT = iInsCnt + 1; 
		l_ChangeQty = l_ChangeQty + COM_atol(CWIPCELLOS.CMF_3, sizeof(CWIPCELLOS.CMF_3));
		CDB_select_cwipcellos(1,&CWIPCELLOS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_insert_cwipcellos(&CWIPCELLOS);
				if(DB_error_code != DB_SUCCESS)
				{
					if(DB_error_code == DB_DUPLICATE)
					{
						//pk중복?
					}
					else
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "CWIPCELLOS INSERT", MP_NVST);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPCELLOS.LOT_ID), CWIPCELLOS.LOT_ID);
						TRS.add_fieldmsg(out_node, "CELL_ID", MP_STR, sizeof(CWIPCELLOS.CELL_ID), CWIPCELLOS.CELL_ID);

						TRS.add_dberrmsg(out_node,DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
					
				}
				iRepairCnt++;
			}
			//중복키체크
		}

		
	}

	// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
	nUseOverkill = TRS.get_int(in_node, "OVERKILL_ENABLE");
	
	CDB_init_cwiplotovr(&CWIPLOTOVR);
	TRS.copy(CWIPLOTOVR.FACTORY, sizeof(CWIPLOTOVR.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPLOTOVR.LOT_ID, sizeof(CWIPLOTOVR.LOT_ID), in_node, "LOT_ID");
	CDB_select_cwiplotovr(2, &CWIPLOTOVR);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			if(nUseOverkill == 1)
			{
				// IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
				// 1차 프로시저 제거를 위하여 기본값 추가
				CDB_init_cedclotrlh(&CEDCLOTRLH);
				memcpy(CEDCLOTRLH.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
				memcpy(CEDCLOTRLH.INS_TYPE, "E1", strlen("E1"));
				TRS.copy(CEDCLOTRLH.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID), in_node, "LOT_ID");	
				CEDCLOTRLH.INS_CNT = 1;
				CEDCLOTRLH.HIST_SEQ = 1;
				memcpy(CEDCLOTRLH.RESULT_VALUE, "NG", strlen("NG"));
			
				// 20211124
				CDB_select_cedclotrlh(7,&CEDCLOTRLH);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CEDCLOTRLH SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLH.FACTORY), CEDCLOTRLH.FACTORY);
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLH.INS_TYPE), CEDCLOTRLH.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
					TRS.add_fieldmsg(out_node, "INS_CNT", MP_INT, CEDCLOTRLH.INS_CNT);
					TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CEDCLOTRLH.HIST_SEQ);
					TRS.add_fieldmsg(out_node, "RESULT_VALUE", MP_STR, sizeof(CEDCLOTRLH.RESULT_VALUE), CEDCLOTRLH.RESULT_VALUE);
					
					TRS.add_dberrmsg(out_node,DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				memcpy(CWIPLOTOVR.WORK_DATE, CEDCLOTRLH.CMF_1, sizeof(CWIPLOTOVR.WORK_DATE)); // INS_TIME 값으로 WORK_DATE 값 추출 (임시로 CMF_1에 저장)
				memcpy(CWIPLOTOVR.LINE_ID, CEDCLOTRLH.LINE_ID, sizeof(CWIPLOTOVR.LINE_ID));
				memcpy(CWIPLOTOVR.RES_ID, CEDCLOTRLH.RES_ID, sizeof(CWIPLOTOVR.RES_ID));
				memcpy(CWIPLOTOVR.OPER, CEDCLOTRLH.OPER, sizeof(CWIPLOTOVR.OPER));
				memcpy(CWIPLOTOVR.TRAN_TIME, CEDCLOTRLH.INS_TIME, sizeof(CWIPLOTOVR.TRAN_TIME));
				memcpy(CWIPLOTOVR.ORDER_ID, CEDCLOTRLH.ORDER_ID, sizeof(CWIPLOTOVR.ORDER_ID));
				
				CWIPLOTOVR.OVERKILL_FLAG = 'Y';
				memcpy(CWIPLOTOVR.REPAIR_TIME, s_sys_time, sizeof(CWIPLOTOVR.CREATE_TIME));
				memcpy(CWIPLOTOVR.CREATE_TIME, s_sys_time, sizeof(CWIPLOTOVR.CREATE_TIME));
				CDB_insert_cwiplotovr(&CWIPLOTOVR);
				if(DB_error_code != DB_SUCCESS)
				{
					// Nothing
				}

				CDB_init_cwiplotovh(&CWIPLOTOVH);
				memcpy(CWIPLOTOVH.FACTORY , CWIPLOTOVR.FACTORY , sizeof(CWIPLOTOVR.FACTORY ) );
				memcpy(CWIPLOTOVH.LOT_ID , CWIPLOTOVR.LOT_ID , sizeof(CWIPLOTOVR.LOT_ID ) );
				CWIPLOTOVH.OVERKILL_FLAG = CWIPLOTOVR.OVERKILL_FLAG;
				memcpy(CWIPLOTOVH.REPAIR_TIME , CWIPLOTOVR.REPAIR_TIME , sizeof(CWIPLOTOVR.REPAIR_TIME ) );
				memcpy(CWIPLOTOVH.CREATE_TIME , CWIPLOTOVR.CREATE_TIME , sizeof(CWIPLOTOVR.CREATE_TIME ) );

				CWIPLOTOVH.HIST_SEQ = 1;

				memcpy(CWIPLOTOVH.WORK_DATE, CEDCLOTRLH.CMF_1, sizeof(CWIPLOTOVH.WORK_DATE));
				memcpy(CWIPLOTOVH.LINE_ID, CEDCLOTRLH.LINE_ID, sizeof(CWIPLOTOVH.LINE_ID));
				memcpy(CWIPLOTOVH.RES_ID, CEDCLOTRLH.RES_ID, sizeof(CWIPLOTOVH.RES_ID));
				memcpy(CWIPLOTOVH.OPER, CEDCLOTRLH.OPER, sizeof(CWIPLOTOVH.OPER));
				memcpy(CWIPLOTOVH.TRAN_TIME, CEDCLOTRLH.INS_TIME, sizeof(CWIPLOTOVH.TRAN_TIME));
				memcpy(CWIPLOTOVH.ORDER_ID, CEDCLOTRLH.ORDER_ID, sizeof(CWIPLOTOVH.ORDER_ID));

				CDB_insert_cwiplotovh(&CWIPLOTOVH);
				if(DB_error_code != DB_SUCCESS)
				{
					// Nothing
				}
			}
		}
	}
	// update OR DELETE
	else
	{
		// UPDATE -> OVERKILL_FLAG flag change Y
		if(nUseOverkill == 1)
		{
			CWIPLOTOVR.WORK_SHIFT[0] = ' '; // 
			CWIPLOTOVR.OVERKILL_FLAG = 'Y';
			memcpy(CWIPLOTOVR.REPAIR_TIME, s_sys_time, sizeof(CWIPLOTOVR.CREATE_TIME));
			CDB_update_cwiplotovr(3, &CWIPLOTOVR);

			if(DB_error_code != DB_SUCCESS)
			{
				// Nothing
			}
		}
		// DELETE -> OVERKILL_FLAG flag change N
		else
		{
			CWIPLOTOVR.OVERKILL_FLAG = 'N';
			memcpy(CWIPLOTOVR.REPAIR_TIME, s_sys_time, sizeof(CWIPLOTOVR.CREATE_TIME));
			CDB_update_cwiplotovr(2, &CWIPLOTOVR);

			if(DB_error_code != DB_SUCCESS)
			{
				// Nothing
			}
		}

		CDB_init_cwiplotovh(&CWIPLOTOVH);
		memcpy(CWIPLOTOVH.FACTORY , CWIPLOTOVR.FACTORY , sizeof(CWIPLOTOVR.FACTORY ) );
		memcpy(CWIPLOTOVH.LOT_ID , CWIPLOTOVR.LOT_ID , sizeof(CWIPLOTOVR.LOT_ID ) );
		memcpy(CWIPLOTOVH.WORK_DATE , CWIPLOTOVR.WORK_DATE , sizeof(CWIPLOTOVR.WORK_DATE ) );
		memcpy(CWIPLOTOVH.WORK_SHIFT , CWIPLOTOVR.WORK_SHIFT , sizeof(CWIPLOTOVR.WORK_SHIFT ) );
		// HIST_SEQ
		CWIPLOTOVH.OVERKILL_FLAG = CWIPLOTOVR.OVERKILL_FLAG;
		memcpy(CWIPLOTOVH.REPAIR_TIME , CWIPLOTOVR.REPAIR_TIME , sizeof(CWIPLOTOVR.REPAIR_TIME ) );
		memcpy(CWIPLOTOVH.ORDER_ID , CWIPLOTOVR.ORDER_ID , sizeof(CWIPLOTOVR.ORDER_ID ) );
		memcpy(CWIPLOTOVH.LINE_ID , CWIPLOTOVR.LINE_ID , sizeof(CWIPLOTOVR.LINE_ID ) );
		memcpy(CWIPLOTOVH.RES_ID , CWIPLOTOVR.RES_ID , sizeof(CWIPLOTOVR.RES_ID ) );
		memcpy(CWIPLOTOVH.OPER , CWIPLOTOVR.OPER , sizeof(CWIPLOTOVR.OPER ) );
		memcpy(CWIPLOTOVH.TAB_RES_ID , CWIPLOTOVR.TAB_RES_ID , sizeof(CWIPLOTOVR.TAB_RES_ID ) );
		memcpy(CWIPLOTOVH.LOSS_CODE , CWIPLOTOVR.LOSS_CODE , sizeof(CWIPLOTOVR.LOSS_CODE ) );
		memcpy(CWIPLOTOVH.LOSS_TIME , CWIPLOTOVR.LOSS_TIME , sizeof(CWIPLOTOVR.LOSS_TIME ) );
		memcpy(CWIPLOTOVH.CREATE_TIME , CWIPLOTOVR.CREATE_TIME , sizeof(CWIPLOTOVR.CREATE_TIME ) );
		memcpy(CWIPLOTOVH.TRAN_TIME , CWIPLOTOVR.TRAN_TIME , sizeof(CWIPLOTOVR.TRAN_TIME ) );

		CWIPLOTOVH.HIST_SEQ = CDB_select_cwiplotovh_scalar(2, &CWIPLOTOVH) + 1;

		CDB_insert_cwiplotovh(&CWIPLOTOVH);
		if(DB_error_code != DB_SUCCESS)
		{
			// Nothing
		}
	}

	
	if (iLossSeq < 1)
	{
		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}
	
	CDB_init_cwiplotrep(&CWIPLOTREP);
	memcpy(CWIPLOTREP.FACTORY, CWIPCELLOS.FACTORY, sizeof(CWIPLOTREP.FACTORY));
	memcpy(CWIPLOTREP.CATEGORY, CWIPCELLOS.LOSS_CATEGORY, sizeof(CWIPLOTREP.CATEGORY));
	memcpy(CWIPLOTREP.LOT_ID, CWIPCELLOS.LOT_ID, sizeof(CWIPLOTREP.LOT_ID));
	CDB_select_cwiplotrep_for_update(1, &CWIPLOTREP);
	if(DB_error_code != DB_SUCCESS)
	{
		CWIPLOTREP.HIST_SEQ = 0 ;
		memcpy(CWIPLOTREP.CREATE_TIME, s_sys_time, sizeof(CWIPLOTREP.CREATE_TIME));
		CDB_insert_cwiplotrep(&CWIPLOTREP);
	}
	
	CWIPLOTREP.HIST_SEQ = iInsCnt + 1; ;
	CWIPLOTREP.TYPE_FLAG[0] = '1'; 
	memcpy(CWIPLOTREP.REPAIR_TABLE, CWIPCELLOS.CMF_1, sizeof(CWIPLOTREP.REPAIR_TABLE));
	memcpy(CWIPLOTREP.SOLDERING, CWIPCELLOS.CMF_2, sizeof(CWIPLOTREP.SOLDERING));
	memcpy(CWIPLOTREP.REPAIR_WORKER,sworker1, sizeof(CWIPLOTREP.REPAIR_WORKER));
	CWIPLOTREP.REPAIR_QTY = 1;
	COM_dtoa(CWIPLOTREP.REPAIR_COUNT,iRepairCnt, sizeof(CWIPLOTREP.REPAIR_COUNT));
	TRS.copy(CWIPLOTREP.REPAIR_DETAIL, sizeof(CWIPLOTREP.REPAIR_DETAIL), in_node, "REPAIR_DETAIL");
	memcpy(CWIPLOTREP.OPER, CWIPCELLOS.OPER, sizeof(CWIPLOTREP.OPER));
	//memcpy(CWIPLOTREP.LINE_ID, CWIPCELLOS.LINE_ID, sizeof(CWIPLOTREP.ORDER_ID)); // Server Crash 190925
	memcpy(CWIPLOTREP.LINE_ID, CWIPCELLOS.LINE_ID, sizeof(CWIPLOTREP.LINE_ID));
	memcpy(CWIPLOTREP.RES_ID, CWIPCELLOS.RES_ID, sizeof(CWIPLOTREP.RES_ID));
	CWIPLOTREP.WORK_SHIFT = CWIPCELLOS.WORK_SHIFT;
	CWIPLOTREP.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
	TRS.copy(CWIPLOTREP.REP_COMMENT, sizeof(CWIPLOTREP.REP_COMMENT), in_node, "REP_COMMENT");
	memcpy(CWIPLOTREP.TRAN_TIME, CWIPCELLOS.TRAN_TIME, sizeof(CWIPLOTREP.TRAN_TIME));
	memcpy(CWIPLOTREP.WORK_DATE, CWIPCELLOS.WORK_DATE, sizeof(CWIPLOTREP.WORK_DATE));
	CWIPLOTREP.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
	COM_ltoa(CWIPLOTREP.CMF_3, l_ChangeQty, sizeof(CWIPLOTREP.CMF_3)); //CHANGED CELL
	memcpy(CWIPLOTREP.CMF_4,sworker2, sizeof(CWIPLOTREP.CMF_4));
	memcpy(CWIPLOTREP.CMF_5,sworker1, sizeof(CWIPLOTREP.CMF_5));

	/*
				in_node.AddString("REP_TABLE", MPCF.Trim(cdvRepairTable.Text));   //Repair Table
                in_node.AddString("REP_SOLDER", MPCF.Trim(cdvSoldering.Text));     //Repair Soldering IRON
                in_node.AddString("REP_WORKER", MPCF.Trim(cdvWorker1.Text));        //Worker1
                in_node.AddString("REP_WORKER2", MPCF.Trim(cdvWorker2.Text));        //Worker2
	*/

	CDB_update_cwiplotrep(1,&CWIPLOTREP);

	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
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

	// HISTORY
	CDB_init_cwiplotreh(&CWIPLOTREH);
	memcpy(CWIPLOTREH.FACTORY, CWIPLOTREP.FACTORY, sizeof(struct CWIPLOTREP_TAG));        
	CDB_insert_cwiplotreh(&CWIPLOTREH);

	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPLOTREH INSERT", MP_NVST);
		//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CWIPLOTREP.LOT_ID), CWIPLOTREP.LOT_ID); // Server Crash
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTREP.LOT_ID), CWIPLOTREP.LOT_ID); // Server Crash
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 


/*******************************************************************************
    CWIP_UPDATE_MODULE_REPAIR_OVERKILL()
        - Main sub function of "CWIP_Update_Select" function
        - Create/Update/Delete Select definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_DELETE_MODULE_REPAIR_OVERKILL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	// INIT
    struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CEDCLOTSUA_TAG CEDCLOTSUA;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
	struct CWIPSUALOS_TAG CWIPSUALOS;
	

    char   s_sys_time[14];
	int lCnt = 0;

	TRSNode	*sua_in_node;
	TRSNode	*sua_out_node;

	// PROCESS LOT PRINT
    LOG_head("CWIP_DELETE_MODULE_REPAIR_OVERKILL");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
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
	
	// PROCESS
	CDB_init_cwipcellos(&CWIPCELLOS);
	memcpy(CWIPCELLOS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPCELLOS.LOSS_CATEGORY, sizeof(CWIPCELLOS.LOSS_CATEGORY), in_node, "LOSS_CATEGORY");
	TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "CELL_ID");	
	CWIPCELLOS.LOSS_SEQ = TRS.get_int(in_node,"LOSS_SEQ");
	CDB_select_cwipcellos(1,&CWIPCELLOS);

	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				return MP_TRUE;
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
	
	memcpy(CWIPSUALOS.FACTORY, CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS)); 

	CDB_select_cwipsualos(1,&CWIPSUALOS);
	if(DB_error_code == DB_NOT_FOUND)
	{
		CDB_insert_cwipsualos(&CWIPSUALOS);
	}
	
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPSUALOS INSERT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPSUALOS.LOT_ID), CWIPSUALOS.LOT_ID);
		TRS.add_fieldmsg(out_node, "CELL_ID", MP_STR, sizeof(CWIPSUALOS.CELL_ID), CWIPSUALOS.CELL_ID);
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	CDB_delete_cwipcellos(1,&CWIPCELLOS);		

	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCELLOS DELETE", MP_NVST);
		TRS.add_fieldmsg(out_node, "CELL_ID", MP_STR, sizeof(CWIPCELLOS.LOT_ID), CWIPCELLOS.CELL_ID);
		TRS.add_fieldmsg(out_node, "LOSS_SEQ", MP_STR, sizeof(CWIPCELLOS.CELL_ID), CWIPCELLOS.LOSS_SEQ);
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	
	//수아랩 Full Auto Mode일경우 B1,E1 최종 검사회차의 Defect Cell이 모드 Cancel되면 SUA양품판정 호출
	CDB_init_cwipcellos(&CWIPCELLOS);
	memcpy(CWIPCELLOS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "CELL_ID");	
	
	lCnt = (int) CDB_select_cwipcellos_scalar(3,&CWIPCELLOS);
	if(DB_error_code != DB_SUCCESS)
	{
		//NOTTHING 
	}
	if(lCnt == 0)
	{
		CDB_init_cedclotsua(&CEDCLOTSUA);
		memcpy(CEDCLOTSUA.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CEDCLOTSUA.LOT_ID, sizeof(CEDCLOTSUA.LOT_ID), in_node, "CELL_ID");	
		
		CDB_select_cedclotsua(2,&CEDCLOTSUA);

		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "BAS-0026");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				return MP_TRUE;
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
			return MP_TRUE;

		}

		if(CEDCLOTSUA.MODE_CODE == '3') //sua full auto mode
		{
			sua_in_node = TRS.create_node("UPDATE_INSP_DATA_IN");
			sua_out_node = TRS.create_node("UPDATE_INSP_DATA_OUT");

			CCOM_copy_in_node(in_node, sua_in_node);

			TRS.set_string(sua_in_node, "LINE_ID", CEDCLOTSUA.LINE_ID, sizeof(CEDCLOTSUA.LINE_ID));
			TRS.set_string(sua_in_node, "CLIENT_TIME", s_sys_time, sizeof(s_sys_time));
			TRS.set_nstring(sua_in_node, "CLIENT_ID", TRS.get_string(in_node, "CLIENT_ID"));
			TRS.set_char(sua_in_node, "PROCSTEP", '1'); 
			TRS.set_string(sua_in_node, "RES_ID", CEDCLOTSUA.RES_ID, sizeof(CEDCLOTSUA.RES_ID));
			TRS.set_string(sua_in_node, "LOT_ID", CEDCLOTSUA.LOT_ID, sizeof(CEDCLOTSUA.LOT_ID));
			TRS.set_string(sua_in_node, "MODULE_IMAGE", CEDCLOTSUA.MODULE_IMAGE, sizeof(CEDCLOTSUA.MODULE_IMAGE));
			TRS.set_nstring(sua_in_node, "RESULT", "0"); // 0 :OK
			TRS.set_nstring(sua_in_node, "MODE", "3"); // 3: full auto mode
			TRS.set_nstring(sua_in_node, "TYPE_FLAG", "2"); // '1': Inspected by Equipment, '2': Inspected by Workers

			if(EAPMES_COLLECT_INSPECTION_DATA_SUALAB(s_msg_code, sua_in_node,sua_out_node) == MP_FALSE)
			{
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				TRS.clone(out_node, sua_out_node);
				
				TRS.free_node(sua_in_node);
				TRS.free_node(sua_out_node);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			TRS.free_node(sua_in_node);
			TRS.free_node(sua_out_node);

			//CMF_5 수라랩판정 양품전환 여부
			CDB_init_cedclotrlt(&CEDCLOTRLT);
			memcpy(CEDCLOTRLT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CEDCLOTRLT.INS_TYPE, "E1", strlen("E1"));
			TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTSUA.LOT_ID), in_node, "CELL_ID");	
		
			CDB_select_cedclotrlt_for_update(1,&CEDCLOTRLT);
			if(DB_error_code != DB_SUCCESS)
			{
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			CEDCLOTRLT.CMF_5[0] = 'Y';
			CDB_update_cedclotrlt(1,&CEDCLOTRLT);
			if(DB_error_code != DB_SUCCESS)
			{
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//수아랩 적용된 서머리를 위해 1차 판정 결과에 CMF_5=Y 를 처리한다.
			CDB_init_cedclotrlh(&CEDCLOTRLH);
			memcpy(CEDCLOTRLH.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CEDCLOTRLH.INS_TYPE, "E1", strlen("E1"));
			TRS.copy(CEDCLOTRLH.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID), in_node, "CELL_ID");	
			CEDCLOTRLH.INS_CNT = 1;
			
			memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1)); 
			
			CDB_select_cedclotrlh_for_update(2,&CEDCLOTRLH);
			if(DB_error_code != DB_SUCCESS)
			{
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			CEDCLOTRLH.CMF_5[0] = 'Y';
			CDB_update_cedclotrlh(1,&CEDCLOTRLH);
			if(DB_error_code != DB_SUCCESS)
			{
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
 
		}
	}
	

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 


