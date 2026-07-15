/*******************************************************************************

    System      : MESplus
    Module      : Fullcell lot validation
    File Name   : CWIP_view_fullcell_lot_validation.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.28  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_FULLCELL_LOT_VALIDATION(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Fullcell_Lot_Validation()
        - View_Fullcell_Lot_Validation
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Fullcell_Lot_Validation(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_FULLCELL_LOT_VALIDATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Fullcell_Lot_Validation", out_node);

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
    CWIP_VIEW_FULLCELL_LOT_VALIDATION()
        - VIEW_FULLCELL_LOT_VALIDATION
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_FULLCELL_LOT_VALIDATION(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CINVCELRCV_TAG CINVCELRCV;
	struct CWIPORDBOM_TAG CWIPORDBOM;

	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_INSPECTION_LIST");
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
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	// INIT
    CDB_init_cinvcelrcv(&CINVCELRCV);
	TRS.copy(CINVCELRCV.FACTORY, sizeof(CINVCELRCV.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CINVCELRCV.INV_LOT_ID, sizeof(CINVCELRCV.INV_LOT_ID), in_node, "INV_LOT_ID");
	CDB_select_cinvcelrcv(1, &CINVCELRCV);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "CINVCELRCV SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CINVCELRCV.FACTORY), CINVCELRCV.FACTORY);
		TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_STR, sizeof(CINVCELRCV.INV_LOT_ID), CINVCELRCV.INV_LOT_ID);	
        TRS.add_dberrmsg(out_node, DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }
	
	//CELL BOX BLOCKING 정보가 있을경우.
	if (CINVCELRCV.BLOCK_STATUS == 'B')
	{
		//CELL BLOCK.
		strcpy(s_msg_code, "WIP-0563");
		TRS.set_fieldmsg(out_node, "CINVCELRCV_FCELL SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "CELL BOX ID", MP_STR, sizeof(CINVCELRCV.SMALLBOXID), CINVCELRCV.SMALLBOXID);
		TRS.add_fieldmsg(out_node, "BLOCK CODE", MP_STR, sizeof(CINVCELRCV.CMF_1), CINVCELRCV.CMF_1);
		TRS.add_fieldmsg(out_node, "BLOCK NAME", MP_STR, sizeof(CINVCELRCV.CMF_2), CINVCELRCV.CMF_2);

		TRS.add_dberrmsg(out_node, DB_error_msg);
		TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	{
		//1. CELL BOX POWER 와 ORDER 의 POWER 비교 ( CWIPCELRCV.POWERGRADE  / CWIPORDBOM.CELL_POWER_GRADE_1)
		CDB_init_cwipordbom(&CWIPORDBOM);
		memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID), in_node, "ORDER_ID");
		//itmpp = COM_atol(CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE)) * 100;
		//COM_ltoa_left(CWIPORDBOM.CELL_POWER_GRADE_1, itmpp, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
		memcpy(CWIPORDBOM.CELL_POWER_GRADE_1, CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE));
		memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
		if (CDB_select_cwipordbom_scalar(4, &CWIPORDBOM) < 1)
		{
				strcpy(s_msg_code, "INV-0014");
				TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
				TRS.add_fieldmsg(out_node, "CELLBOX", MP_STR, sizeof(CINVCELRCV.INV_LOT_ID), CINVCELRCV.INV_LOT_ID);
				TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(CINVCELRCV.POWERGRADE), CINVCELRCV.POWERGRADE);
				TRS.add_dberrmsg(out_node,DB_error_msg);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				//return MP_FALSE;
		}
	}

	//2. CELL BOX 의 GRADE 와 ORDER 의 GRADE 비교 ( CINVCELRCV.QUALITYGRADE / CWIPORDBOM.CELL_POWER_GRADE_2 )
	CDB_init_cwipordbom(&CWIPORDBOM);
	memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID), in_node, "ORDER_ID");
	memcpy(CWIPORDBOM.CELL_POWER_GRADE_2, CINVCELRCV.QUALITYGRADE, sizeof(CINVCELRCV.QUALITYGRADE));
	memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
    if (CDB_select_cwipordbom_scalar(3, &CWIPORDBOM) < 1)
    {
		strcpy(s_msg_code, "INV-0015");
		TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
        TRS.add_fieldmsg(out_node, "CELLBOX", MP_STR, sizeof(CINVCELRCV.INV_LOT_ID), CINVCELRCV.INV_LOT_ID);
		TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(CINVCELRCV.QUALITYGRADE), CINVCELRCV.QUALITYGRADE);
		TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(CINVCELRCV.POWERGRADE), CINVCELRCV.POWERGRADE);
        TRS.add_dberrmsg(out_node,DB_error_msg);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	//3. CELL BOX 의 GRADE/POWER 와 ORDER 의 GRADE/POWER 함께비교 ( CINVCELRCV.QUALITYGRADE / CWIPORDBOM.CELL_POWER_GRADE_2 )
	CDB_init_cwipordbom(&CWIPORDBOM);
	memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID), in_node, "ORDER_ID");
	memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
	memcpy(CWIPORDBOM.CELL_POWER_GRADE_1, CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE));
	memcpy(CWIPORDBOM.CELL_POWER_GRADE_2, CINVCELRCV.QUALITYGRADE, sizeof(CINVCELRCV.QUALITYGRADE));
	
    if (CDB_select_cwipordbom_scalar(5, &CWIPORDBOM) < 1)
    {
		strcpy(s_msg_code, "INV-0016");
		TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
        TRS.add_fieldmsg(out_node, "CELLBOX", MP_STR, sizeof(CINVCELRCV.INV_LOT_ID), CINVCELRCV.INV_LOT_ID);
		TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(CINVCELRCV.QUALITYGRADE), CINVCELRCV.QUALITYGRADE);
        TRS.add_dberrmsg(out_node,DB_error_msg);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
    }

	//4. CELL BOX의 MAT_ID와 ORDER의 MAT_ID 비교
	/* Get grade & efficiency data */
	CDB_init_cwipordbom(&CWIPORDBOM);
	memcpy(CWIPORDBOM.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID), in_node, "ORDER_ID");
	memcpy(CWIPORDBOM.MAT_ID,  CINVCELRCV.MATERIALDEFINITIONID, sizeof(CINVCELRCV.MATERIALDEFINITIONID));
	memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));

    CDB_select_cwipordbom(5, &CWIPORDBOM);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0019");
            TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPORDBOM.MAT_ID), CWIPORDBOM.MAT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
        }
    }

    /*
    //CDB_select_cwipordbom(4, &CWIPORDBOM);
    //if(DB_error_code != DB_SUCCESS)
    if (CDB_select_cwipordbom_scalar(7, &CWIPORDBOM) < 1)
    {
        //if(DB_error_code == DB_NOT_FOUND)
        //{
            strcpy(s_msg_code, "INV-0019");
            TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPORDBOM.MAT_ID), CWIPORDBOM.MAT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
        //}
    }
    */

	TRS.add_string(out_node, "EFFICIENCY", CWIPORDBOM.CELL_POWER_GRADE_1, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
	TRS.add_string(out_node, "GRADE", CWIPORDBOM.CELL_POWER_GRADE_2, sizeof(CWIPORDBOM.CELL_POWER_GRADE_2));

	if (COM_isspace( CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE)) == MP_TRUE)
		TRS.add_string(out_node, "POWERGRADE", "0 ", 2);
	else
		TRS.add_string(out_node, "POWERGRADE", CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE));
	
	TRS.add_string(out_node, "QUALITYGRADE", CINVCELRCV.QUALITYGRADE, sizeof(CINVCELRCV.QUALITYGRADE));

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}