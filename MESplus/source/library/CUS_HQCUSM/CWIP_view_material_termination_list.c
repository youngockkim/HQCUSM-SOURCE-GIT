/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_material_termination_list.c
    Description : View Material_Termination List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Material_Termination_List()
            + View Material_Termination definition List
        - CWIP_VIEW_MATERIAL_TERMINATION_LIST()
            + Main sub function of CWIP_View_Material_Termination_List function
            + View Material_Termination definition List
    Detail Description
        - CWIP_VIEW_MATERIAL_TERMINATION_LIST()
            + h_proc_step
                + 1 : View Material_Termination definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-09-18             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Material_Termination_List()
        - View Material_Termination definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Material_Termination_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_MATERIAL_TERMINATION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_MATERIAL_TERMINATION_LIST", out_node);

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
    CWIP_VIEW_MATERIAL_TERMINATION_LIST()
        - Main sub function of "CWIP_View_Material_Termination_List" function
        - View Material_Termination definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_MATERIAL_TERMINATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPMATTER_TAG CWIPMATTER;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
    TRSNode *list_item;

    int i_case;

	LOG_head("CWIP_VIEW_MATERIAL_TERMINATION_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
	
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* ORDER_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ORDER_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if (TRS.get_procstep(in_node) == '1')
    {
        i_case = 2;
    }
    else
    {
        i_case = 2;
    }

	/*
	ORDER BY TERMINATION_DT ASC,
					ORDER_ID ASC,
                    MAT_ID ASC,
					LINE_ID ASC,
                    WORK_SHIFT ASC,
					SEQ ASC,
					HIST_SEQ ASC;
	*/

	DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_DATE, sizeof(DBC_Q_COND.FROM_DATE), in_node, "FROM_DATE");
    TRS.copy(DBC_Q_COND.TO_DATE, sizeof(DBC_Q_COND.TO_DATE), in_node, "TO_DATE");
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

    CDB_init_cwipmatter(&CWIPMATTER);

	TRS.copy(CWIPMATTER.FACTORY, sizeof(CWIPMATTER.FACTORY), in_node, IN_FACTORY);
	TRS.copy(CWIPMATTER.TERMINATION_DT, sizeof(CWIPMATTER.TERMINATION_DT), in_node, "TERMINATION_DT");
    TRS.copy(CWIPMATTER.ORDER_ID, sizeof(CWIPMATTER.ORDER_ID), in_node, "ORDER_ID");
    TRS.copy(CWIPMATTER.LINE_ID, sizeof(CWIPMATTER.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPMATTER.WORK_SHIFT, sizeof(CWIPMATTER.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPMATTER.MAT_ID, sizeof(CWIPMATTER.MAT_ID), in_node, "MAT_ID");
    
	CDB_open_cwipmatter(i_case, &CWIPMATTER);

	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPMATTER OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPMATTER.ORDER_ID), CWIPMATTER.ORDER_ID);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPMATTER.LINE_ID), CWIPMATTER.LINE_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPMATTER.WORK_SHIFT), CWIPMATTER.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPMATTER.MAT_ID), CWIPMATTER.MAT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPMATTER.HIST_SEQ);
        TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPMATTER.SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwipmatter(i_case, &CWIPMATTER);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipmatter(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPMATTER FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPMATTER.ORDER_ID), CWIPMATTER.ORDER_ID);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPMATTER.LINE_ID), CWIPMATTER.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPMATTER.WORK_SHIFT), CWIPMATTER.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPMATTER.MAT_ID), CWIPMATTER.MAT_ID);
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CWIPMATTER.HIST_SEQ);
            TRS.add_fieldmsg(out_node, "SEQ", MP_INT, CWIPMATTER.SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwipmatter(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		
        list_item = TRS.add_node(out_node, "MATERIAL_TERMINATION_LIST");

        TRS.add_string(list_item, "FACTORY", CWIPMATTER.FACTORY, sizeof(CWIPMATTER.FACTORY));
        TRS.add_string(list_item, "ORDER_ID", CWIPMATTER.ORDER_ID, sizeof(CWIPMATTER.ORDER_ID));
        TRS.add_string(list_item, "LINE_ID", CWIPMATTER.LINE_ID, sizeof(CWIPMATTER.LINE_ID));
        TRS.add_string(list_item, "WORK_SHIFT", CWIPMATTER.WORK_SHIFT, sizeof(CWIPMATTER.WORK_SHIFT));
        TRS.add_string(list_item, "MAT_ID", CWIPMATTER.MAT_ID, sizeof(CWIPMATTER.MAT_ID));
        TRS.add_int(list_item, "HIST_SEQ", CWIPMATTER.HIST_SEQ);
        TRS.add_int(list_item, "SEQ", CWIPMATTER.SEQ);
        TRS.add_string(list_item, "TERMINATION_DT", CWIPMATTER.TERMINATION_DT, sizeof(CWIPMATTER.TERMINATION_DT));
        TRS.add_string(list_item, "MATE_NO_DESC", CWIPMATTER.MATE_NO_DESC, sizeof(CWIPMATTER.MATE_NO_DESC));
        TRS.add_string(list_item, "MATE_TYPE", CWIPMATTER.MATE_TYPE, sizeof(CWIPMATTER.MATE_TYPE));
        TRS.add_int(list_item, "QTY", CWIPMATTER.QTY);
        TRS.add_string(list_item, "UNIT_ID", CWIPMATTER.UNIT_ID, sizeof(CWIPMATTER.UNIT_ID));
        TRS.add_string(list_item, "REASON_CODE", CWIPMATTER.REASON_CODE, sizeof(CWIPMATTER.REASON_CODE));
        TRS.add_string(list_item, "TER_COMMENT", CWIPMATTER.TER_COMMENT, sizeof(CWIPMATTER.TER_COMMENT));
        TRS.add_string(list_item, "CMF_1", CWIPMATTER.CMF_1, sizeof(CWIPMATTER.CMF_1));
        TRS.add_string(list_item, "CMF_2", CWIPMATTER.CMF_2, sizeof(CWIPMATTER.CMF_2));
        TRS.add_string(list_item, "CMF_3", CWIPMATTER.CMF_3, sizeof(CWIPMATTER.CMF_3));
        TRS.add_string(list_item, "CMF_4", CWIPMATTER.CMF_4, sizeof(CWIPMATTER.CMF_4));
        TRS.add_string(list_item, "CMF_5", CWIPMATTER.CMF_5, sizeof(CWIPMATTER.CMF_5));
        TRS.add_string(list_item, "CREATE_USER_ID", CWIPMATTER.CREATE_USER_ID, sizeof(CWIPMATTER.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CWIPMATTER.CREATE_TIME, sizeof(CWIPMATTER.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPMATTER.UPDATE_USER_ID, sizeof(CWIPMATTER.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CWIPMATTER.UPDATE_TIME, sizeof(CWIPMATTER.UPDATE_TIME));

		// GCM Data
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME,"@LINE_CODE", strlen("@LINE_CODE"));
		memcpy(MGCMTBLDAT.KEY_1,CWIPMATTER.LINE_ID, sizeof(CWIPMATTER.LINE_ID));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cwiptsclos(i_case);
			return MP_FALSE;
		}
		
		TRS.add_string(list_item, "LINE_ID_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY,HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME,"@SHIFT", strlen("@SHIFT"));
		memcpy(MGCMTBLDAT.KEY_1,CWIPMATTER.WORK_SHIFT, sizeof(CWIPMATTER.WORK_SHIFT));
		DBC_select_mgcmtbldat(1,&MGCMTBLDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "GCM-0008");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			CDB_close_cwiptsclos(i_case);
			return MP_FALSE;
		}

		TRS.add_string(list_item, "WORK_SHIFT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));

    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*

    // LINE_ID Validation
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    // WORK_SHIFT Validation
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    // MAT_ID Validation
    if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	

    //// HIST_SEQ Validation
    //if(TRS.get_int(in_node, "HIST_SEQ") == 0)
    //{
    //    strcpy(s_msg_code, "CWIP-0001");
    //    TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    //// SEQ Validation
    //if(TRS.get_int(in_node, "SEQ") == 0)
    //{
    //    strcpy(s_msg_code, "CWIP-0001");
    //    TRS.add_fieldmsg(out_node, "SEQ", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

	//
	//					AND TERMINATION_DT = :CWIPMATTER_N.TERMINATION_DT
	//				AND ORDER_ID = :CWIPMATTER_N.ORDER_ID
 //                   AND MAT_ID like :CWIPMATTER_N.MAT_ID
	//				AND LINE_ID like :CWIPMATTER_N.LINE_ID
 //                   AND WORK_SHIFT like :CWIPMATTER_N.WORK_SHIFT



    //
		CWIPMATTER.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
    CWIPMATTER.SEQ = TRS.get_int(in_node, "SEQ");
	
    // Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Material_Termination_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    

*/