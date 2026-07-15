/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_attached_material_list.c
    Description : Update Attached Material List

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_Attached_Material_List()
            + Update Attached Material List
        - CRAS_UPDATE_ATTACHED_MATERIAL_LIST()
            + Main sub function of CRAS_Update_Attached_Material_List function
        - CRAS_Update_Attached_Material_List_Validation()
            + Main sub function of CRAS_UPDATE_ATTACHED_MATERIAL_LIST function
    Detail Description
        - CRAS_UPDATE_ATTACHED_MATERIAL_LIST()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019-01-03             Create by Generator

    Copyright(C) 1998-2019 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include <WIPCore_common.h>

int CRAS_UPDATE_ATTACHED_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CRAS_UPDATE_DETTACHED_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_Attached_Material_List()
        - Create/Update/Delete Crasresmat definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
		   get_procstep = 1 : ATTACH MATERIAL
		   get_procstep = 2 : DETTACH MATERIAL
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Attached_Material_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

	if (TRS.get_procstep(in_node) == 'I')  // Attach
	{ 
		i_ret = CRAS_UPDATE_ATTACHED_MATERIAL_LIST(s_msg_code, in_node, out_node);
	}
	else if (TRS.get_procstep(in_node) == 'D')  //Dettach
	{
		i_ret = CRAS_UPDATE_DETTACHED_MATERIAL_LIST(s_msg_code, in_node, out_node);
	}
	// 20210810 MES Application Memory leak 점검 및 수정
	// 해당 CASE 없음으로 정상 RETURN 처리
	else
	{
		COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_ATTACHED_MATERIAL_LIST", out_node);
		return MP_TRUE;
	}

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_ATTACHED_MATERIAL_LIST", out_node);

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
    CRAS_UPDATE_ATTACHED_MATERIAL_LIST()
        - Main sub function of "CRAS_Update_Attached_Material_List" function
        - Create/Update/Delete Crasresmat definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_ATTACHED_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASRESMAT_TAG CRASRESMAT;
	struct CRASRESMAT_TAG CRASRESMAT_SEQ;
	struct CRASRESMAH_TAG CRASRESMAH;
	struct CRASRESMAH_TAG CRASRESMAH_SEQ;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
    char   s_sys_time[14];


    LOG_head("CRAS_UPDATE_ATTACHED_MATERIAL_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("seq", MP_INT, TRS.get_int(in_node, "SEQ"));
    LOG_add("position_id", MP_NSTR, TRS.get_string(in_node, "POSITION_ID"));
    LOG_add("inv_barcode_id", MP_NSTR, TRS.get_string(in_node, "INV_BARCODE_ID"));
    LOG_add("inv_mat_id", MP_NSTR, TRS.get_string(in_node, "INV_MAT_ID"));
    LOG_add("inv_lot_id", MP_NSTR, TRS.get_string(in_node, "INV_LOT_ID"));
    LOG_add("inv_lot_desc", MP_NSTR, TRS.get_string(in_node, "INV_LOT_DESC"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("flow", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("materials_kinds", MP_NSTR, TRS.get_string(in_node, "MATERIALS_KINDS"));
    LOG_add("attach_qty", MP_DBL, TRS.get_double(in_node, "ATTACH_QTY"));
    LOG_add("used_qty", MP_DBL, TRS.get_double(in_node, "USED_QTY"));
    LOG_add("remain_qty", MP_DBL, TRS.get_double(in_node, "REMAIN_QTY"));
    LOG_add("unit", MP_NSTR, TRS.get_string(in_node, "UNIT"));
    LOG_add("default_use_qty", MP_DBL, TRS.get_double(in_node, "DEFAULT_USE_QTY"));
    LOG_add("attach_time", MP_NSTR, TRS.get_string(in_node, "ATTACH_TIME"));
    LOG_add("attach_user_id", MP_NSTR, TRS.get_string(in_node, "ATTACH_USER_ID"));
    LOG_add("input_qty", MP_DBL, TRS.get_double(in_node, "INPUT_QTY"));
    LOG_add("total_used_qty", MP_DBL, TRS.get_double(in_node, "TOTAL_USED_QTY"));
    LOG_add("etc_qty", MP_DBL, TRS.get_double(in_node, "ETC_QTY"));
    LOG_add("max_use_qty", MP_DBL, TRS.get_double(in_node, "MAX_USE_QTY"));
    LOG_add("use_batch_id", MP_NSTR, TRS.get_string(in_node, "USE_BATCH_ID"));
    LOG_add("use_type", MP_NSTR, TRS.get_string(in_node, "USE_TYPE"));
    LOG_add("max_use_time", MP_NSTR, TRS.get_string(in_node, "MAX_USE_TIME"));
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    LOG_add("last_action", MP_NSTR, TRS.get_string(in_node, "LAST_ACTION"));
    LOG_add("detach_time", MP_NSTR, TRS.get_string(in_node, "DETACH_TIME"));
    LOG_add("detach_user_id", MP_NSTR, TRS.get_string(in_node, "DETACH_USER_ID"));
    LOG_add("last_hist_seq", MP_INT, TRS.get_int(in_node, "LAST_HIST_SEQ"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

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
	
	// INSERT CWIPCELPAK
		
	CDB_init_cinvlotsts(&CINVLOTSTS);
	TRS.copy(CINVLOTSTS.FACTORY, sizeof(CINVLOTSTS.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CINVLOTSTS.VENDOR_BARCD, sizeof(CINVLOTSTS.VENDOR_BARCD), in_node, "INV_BARCODE_ID");		
	CDB_select_cinvlotsts(2,&CINVLOTSTS); // Material Definition Inquary

	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			/**
			strcpy(s_msg_code, "INV-0012");					
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			**/
			//무조건 넣음.
			
		}
		else
		{
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "CINVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CINVLOTSTS.FACTORY), CINVLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "VENDOR_BARCD", MP_STR, sizeof(CINVLOTSTS.VENDOR_BARCD), CINVLOTSTS.VENDOR_BARCD);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;

		}

		
	}
	
	DBC_init_mwipmatdef(&MWIPMATDEF);
	TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
	MWIPMATDEF.MAT_VER = 1;
	memcpy(MWIPMATDEF.MAT_ID, CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));
	DBC_select_mwipmatdef(1,&MWIPMATDEF); // Material Definition Inquary

	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			/**
			strcpy(s_msg_code, "WIP-0006");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			**/
			//무조건 넣음.
		}
		else
		{
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CINVLOTSTS.FACTORY), CINVLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
		}
	}

	//MAX SEQ Inquery
	CDB_init_crasresmat(&CRASRESMAT_SEQ);
	TRS.copy(CRASRESMAT_SEQ.RES_ID, sizeof(CRASRESMAT_SEQ.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASRESMAT_SEQ.FACTORY, sizeof(CRASRESMAT_SEQ.FACTORY), in_node, IN_FACTORY);
	CDB_select_crasresmat(2,&CRASRESMAT_SEQ);		// MAX Sequence Inquary

	CDB_init_crasresmat(&CRASRESMAT);
	TRS.copy(CRASRESMAT.FACTORY, sizeof(CRASRESMAT.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CRASRESMAT.RES_ID, sizeof(CRASRESMAT.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASRESMAT.INV_BARCODE_ID, sizeof(CRASRESMAT.INV_BARCODE_ID), in_node, "INV_BARCODE_ID");
	TRS.copy(CRASRESMAT.OPER, sizeof(CRASRESMAT.OPER), in_node, "OPER");
	TRS.copy(CRASRESMAT.ORDER_ID, sizeof(CRASRESMAT.ORDER_ID), in_node, "ORDER_ID");
	TRS.copy(CRASRESMAT.FLOW, sizeof(CRASRESMAT.FLOW), in_node, "FLOW");
	memcpy(CRASRESMAT.INV_MAT_ID, CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));
	memcpy(CRASRESMAT.INV_LOT_ID, CINVLOTSTS.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID));

	TRS.copy(CRASRESMAT.MAT_ID, sizeof(CRASRESMAT.MAT_ID), in_node, "MAT_ID");
	TRS.copy(CRASRESMAT.ATTACH_USER_ID, sizeof(CRASRESMAT.ATTACH_USER_ID), in_node, IN_USERID);	
	TRS.copy(CRASRESMAT.ORDER_ID, sizeof(CRASRESMAT.ORDER_ID), in_node, "ORDER_ID");
	TRS.copy(CRASRESMAT.FLOW, sizeof(CRASRESMAT.FLOW), in_node, "FLOW");
	//memcpy(CRASRESMAT.MATERIALS_KINDS, MWIPMATDEF.MAT_CMF_1, sizeof(MWIPMATDEF.MAT_CMF_1)); // Server Crash 190925
	memcpy(CRASRESMAT.MATERIALS_KINDS, MWIPMATDEF.MAT_CMF_1, sizeof(CRASRESMAT.MATERIALS_KINDS)); 
	memcpy(CRASRESMAT.UNIT, MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1));
	memcpy(CRASRESMAT.ATTACH_TIME,s_sys_time, sizeof(s_sys_time));

	CRASRESMAT.SEQ = CRASRESMAT_SEQ.SEQ + 1;
	CRASRESMAT.POSITION_ID[0] = 'A';
	CRASRESMAT.DEFAULT_USE_QTY = 0;
	CRASRESMAT.ATTACH_QTY = CINVLOTSTS.QTY_1;
	CRASRESMAT.USED_QTY = 0;
	CRASRESMAT.REMAIN_QTY = CINVLOTSTS.QTY_1;
	CRASRESMAT.INPUT_QTY = 0;
	CRASRESMAT.TOTAL_USED_QTY = 0;
	CRASRESMAT.ETC_QTY = 0;
	CRASRESMAT.MAX_USE_QTY = 0;
	CRASRESMAT.USE_TYPE[0] = 'A';
	CRASRESMAT.LAST_HIST_SEQ = 1;
		
	//Inquery MAX LAST_SEQ for History 
	CDB_init_crasresmah(&CRASRESMAH_SEQ);
	TRS.copy(CRASRESMAH_SEQ.RES_ID, sizeof(CRASRESMAH_SEQ.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASRESMAH_SEQ.FACTORY, sizeof(CRASRESMAH_SEQ.FACTORY), in_node, IN_FACTORY);
	CRASRESMAH_SEQ.SEQ = CRASRESMAT.SEQ;
	CDB_select_crasresmah(2,&CRASRESMAH_SEQ);		// MAX Sequence Inquary
	CRASRESMAT.LAST_HIST_SEQ = CRASRESMAH_SEQ.LAST_HIST_SEQ + 1;
	TRS.copy(CRASRESMAT.CMF_1, sizeof(CRASRESMAT.CMF_1), in_node, "POSITION_ID");
	TRS.copy(CRASRESMAT.CMF_2, sizeof(CRASRESMAT.CMF_2), in_node, "INV_TYPE");

	if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{
		CDB_insert_crasresmat(&CRASRESMAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CRASRESMAT INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);
			TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CRASRESMAT.SEQ);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// HISTORY
		CDB_init_crasresmah(&CRASRESMAH);
		memcpy(CRASRESMAH.FACTORY, CRASRESMAT.FACTORY, sizeof(struct CRASRESMAT_TAG));        
		CRASRESMAH.LAST_HIST_SEQ = CRASRESMAT.LAST_HIST_SEQ;
		CDB_insert_crasresmah(&CRASRESMAH);

		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "CRASRESMAH INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);
			TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CRASRESMAT.SEQ);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CRAS_UPDATE_ATTACHED_MATERIAL_LIST()
        - Main sub function of "CRAS_Update_Attached_Material_List" function
        - Create/Update/Delete Crasresmat definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_DETTACHED_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASRESMAT_TAG CRASRESMAT;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct CRASRESMAH_TAG CRASRESMAH;
	struct CRASRESMAH_TAG CRASRESMAH_SEQ;

    char   s_sys_time[14];

    LOG_head("CRAS_UPDATE_DETTACHED_MATERIAL_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("seq", MP_INT, TRS.get_int(in_node, "SEQ"));
    LOG_add("materials_kinds", MP_NSTR, TRS.get_string(in_node, "MATERIALS_KINDS"));
    LOG_add("attach_qty", MP_DBL, TRS.get_double(in_node, "ATTACH_QTY"));
    LOG_add("used_qty", MP_DBL, TRS.get_double(in_node, "USED_QTY"));
    LOG_add("remain_qty", MP_DBL, TRS.get_double(in_node, "REMAIN_QTY"));
    LOG_add("unit", MP_NSTR, TRS.get_string(in_node, "UNIT"));    
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    LOG_add("last_action", MP_NSTR, TRS.get_string(in_node, "LAST_ACTION"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

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
	
	CDB_init_crasresmat(&CRASRESMAT);
	TRS.copy(CRASRESMAT.FACTORY, sizeof(CRASRESMAT.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CRASRESMAT.RES_ID, sizeof(CRASRESMAT.RES_ID), in_node, "RES_ID");
	CRASRESMAT.SEQ = TRS.get_int(in_node,"SEQ");
	CDB_select_crasresmat(1,&CRASRESMAT);

	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
			//삭제 데이터 없음
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
            return MP_TRUE;

        }
        else
        {
            strcpy(s_msg_code, "BAS-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }
			
		TRS.add_fieldmsg(out_node, "CRASRESMAT SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
		TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;		
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;

    }

	CDB_init_cinvlotsts(&CINVLOTSTS);
	memcpy(CINVLOTSTS.FACTORY, CRASRESMAT.FACTORY, sizeof(CRASRESMAT.FACTORY));
	memcpy(CINVLOTSTS.INV_LOT_ID, CRASRESMAT.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID));
	CDB_select_cinvlotsts(1,&CINVLOTSTS);

	if(DB_error_code == DB_SUCCESS)
    {
        CINVLOTSTS.QTY_1 = CRASRESMAT.REMAIN_QTY;
		memcpy(CINVLOTSTS.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CINVLOTSTS.LAST_TRAN_USER_ID, sizeof(CINVLOTSTS.LAST_TRAN_USER_ID), in_node, IN_USERID);	

		CDB_update_cinvlotsts(1,&CINVLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

    }

	CDB_delete_crasresmat(1,&CRASRESMAT);

	if(DB_error_code != DB_SUCCESS)
    {
        //DO NOTHING
    }
	
	//Inquery MAX LAST_SEQ for History 
	CDB_init_crasresmah(&CRASRESMAH_SEQ);
	TRS.copy(CRASRESMAH_SEQ.RES_ID, sizeof(CRASRESMAH_SEQ.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASRESMAH_SEQ.FACTORY, sizeof(CRASRESMAH_SEQ.FACTORY), in_node, IN_FACTORY);
	CRASRESMAH_SEQ.SEQ = CRASRESMAT.SEQ;
	CDB_select_crasresmah(2,&CRASRESMAH_SEQ);		// MAX Sequence Inquary	

	// HISTORY
	CDB_init_crasresmah(&CRASRESMAH);
	memcpy(CRASRESMAH.FACTORY, CRASRESMAT.FACTORY, sizeof(struct CRASRESMAT_TAG));        
	CRASRESMAH.LAST_HIST_SEQ = CRASRESMAH_SEQ.LAST_HIST_SEQ + 1;
	TRS.copy(CRASRESMAH.DETACH_USER_ID, sizeof(CRASRESMAH.DETACH_USER_ID), in_node, IN_USERID);	
	memcpy(CRASRESMAH.DETACH_TIME,s_sys_time, sizeof(s_sys_time));

	CDB_insert_crasresmah(&CRASRESMAH);

	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CRAS_UPDATE_ATTACHED_MATERIAL_FOR_EQUIP()
        - Main sub function of "CRAS_Update_Dettached_Material_For Equip" function
        - Create/Update/Delete Crasresmat definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_DETTACHED_MATERIAL_FOR_EQUIP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASRESMAT_TAG CRASRESMAT;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct CRASRESMAH_TAG CRASRESMAH;
	struct CRASRESMAH_TAG CRASRESMAH_SEQ;

    char   s_sys_time[14];

    LOG_head("CRAS_UPDATE_DETTACHED_MATERIAL_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("seq", MP_INT, TRS.get_int(in_node, "SEQ"));
    LOG_add("materials_kinds", MP_NSTR, TRS.get_string(in_node, "MATERIALS_KINDS"));
    LOG_add("attach_qty", MP_DBL, TRS.get_double(in_node, "ATTACH_QTY"));
    LOG_add("used_qty", MP_DBL, TRS.get_double(in_node, "USED_QTY"));
    LOG_add("remain_qty", MP_DBL, TRS.get_double(in_node, "REMAIN_QTY"));
    LOG_add("unit", MP_NSTR, TRS.get_string(in_node, "UNIT"));    
    LOG_add("order_id", MP_NSTR, TRS.get_string(in_node, "ORDER_ID"));
    LOG_add("last_action", MP_NSTR, TRS.get_string(in_node, "LAST_ACTION"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

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
	
	CDB_init_crasresmat(&CRASRESMAT);
	TRS.copy(CRASRESMAT.FACTORY, sizeof(CRASRESMAT.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CRASRESMAT.RES_ID, sizeof(CRASRESMAT.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASRESMAT.INV_BARCODE_ID, sizeof(CRASRESMAT.INV_BARCODE_ID), in_node, "MAT_ID");
	CDB_select_crasresmat(3,&CRASRESMAT);

	CDB_init_cinvlotsts(&CINVLOTSTS);
	memcpy(CINVLOTSTS.FACTORY, CRASRESMAT.FACTORY, sizeof(CRASRESMAT.FACTORY));
	memcpy(CINVLOTSTS.INV_LOT_ID, CRASRESMAT.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID));
	CDB_select_cinvlotsts(1,&CINVLOTSTS);

	CINVLOTSTS.QTY_1 = CRASRESMAT.REMAIN_QTY;
	memcpy(CINVLOTSTS.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
	TRS.copy(CINVLOTSTS.LAST_TRAN_USER_ID, sizeof(CINVLOTSTS.LAST_TRAN_USER_ID), in_node, IN_USERID);	

	CDB_update_cinvlotsts(1,&CINVLOTSTS);

	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			/**
			strcpy(s_msg_code, "INV-0012");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			**/
		}
		else
		{
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "CINVLOTSTS UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CINVLOTSTS.FACTORY), CINVLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_STR, sizeof(CINVLOTSTS.INV_LOT_ID), CINVLOTSTS.INV_LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
		}
			
	}
	
	CDB_init_crasresmat(&CRASRESMAT);
	TRS.copy(CRASRESMAT.FACTORY, sizeof(CRASRESMAT.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CRASRESMAT.RES_ID, sizeof(CRASRESMAT.RES_ID), in_node, "RES_ID");
	TRS.copy(CRASRESMAT.INV_BARCODE_ID, sizeof(CRASRESMAT.INV_BARCODE_ID), in_node, "MAT_ID");
	CDB_open_crasresmat(4,&CRASRESMAT);

	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "BAS-0004");
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        TRS.add_dberrmsg(out_node, DB_error_msg);          
		TRS.add_fieldmsg(out_node, "CRASRESMAT SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
		TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);
		TRS.add_fieldmsg(out_node, "INV_BARCODE_ID", MP_STR, sizeof(CRASRESMAT.INV_BARCODE_ID), CRASRESMAT.INV_BARCODE_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;			
		return MP_FALSE;
    }

	// FETCH
	while(1)
	{
		CDB_fetch_crasresmat(4, &CRASRESMAT);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_crasresmat(4);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CRASRESMAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_crasresmat(4);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		CDB_delete_crasresmat(1,&CRASRESMAT);

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

				TRS.add_fieldmsg(out_node, "CRASRESMAT DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);

				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;			
				return MP_FALSE;
		}

		//Inquery MAX LAST_SEQ for History 
		CDB_init_crasresmah(&CRASRESMAH_SEQ);
		TRS.copy(CRASRESMAH_SEQ.RES_ID, sizeof(CRASRESMAH_SEQ.RES_ID), in_node, "RES_ID");
		TRS.copy(CRASRESMAH_SEQ.FACTORY, sizeof(CRASRESMAH_SEQ.FACTORY), in_node, IN_FACTORY);
		CRASRESMAH_SEQ.SEQ = CRASRESMAT.SEQ;
		CDB_select_crasresmah(2,&CRASRESMAH_SEQ);		// MAX Sequence Inquary	

		if(DB_error_code != DB_SUCCESS)
		{			
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);	
			TRS.add_fieldmsg(out_node, "CRASRESMAH MAX(LAST_SEQ) SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAH.FACTORY), CRASRESMAH.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAH.RES_ID), CRASRESMAH.RES_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
		}

		// HISTORY
		CDB_init_crasresmah(&CRASRESMAH);
		memcpy(CRASRESMAH.FACTORY, CRASRESMAT.FACTORY, sizeof(struct CRASRESMAT_TAG));        
		CRASRESMAH.LAST_HIST_SEQ = CRASRESMAH_SEQ.LAST_HIST_SEQ + 1;
		TRS.copy(CRASRESMAH.DETACH_USER_ID, sizeof(CRASRESMAH.DETACH_USER_ID), in_node, IN_USERID);	
		memcpy(CRASRESMAH.DETACH_TIME,s_sys_time, sizeof(s_sys_time));
		CDB_insert_crasresmah(&CRASRESMAH);

		if(DB_error_code != DB_SUCCESS)
		{			
			strcpy(s_msg_code, "BAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);	
			TRS.add_fieldmsg(out_node, "CRASRESMAH INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAH.FACTORY), CRASRESMAH.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAH.RES_ID), CRASRESMAH.RES_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 
