/*******************************************************************************

    System      : MESplus
    Module      : TIV
    File Name   : TIV_view_material_list_for_trs.c
    Description :  

    MES Version : 5.0

    Function List
        - TIV_View_Material_List_For_TRS()
            + Main service
        - TIV_VIEW_MATERIAL_LIST_FOR_TRS()
            + Main sub function of"TIV_View_Material_List_For_TRS" function            
        - TIV_View_Material_List_For_TRS_Validation()
            + Validation Check sub function of"TIV_VIEW_MATERIAL_LIST_FOR_TRS" function

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1      2015-11-29

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.


*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Material_List_For_TRS_Validation(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node);

/*******************************************************************************
    HSSL_View_List_Temlate()
        - Main service
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material_List_For_TRS(TRSNode *in_node, 
                                   TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_MATERIAL_LIST_FOR_TRS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_MATERIAL_LIST_FOR_TRS", out_node); 

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
    TIV_VIEW_MATERIAL_LIST_FOR_TRS()
        - Main sub function of "TIV_View_Material_List_For_TRS" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_MATERIAL_LIST_FOR_TRS(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node)
{

    struct MTIVMLSTRS_TAG MTIVMLSTRS;
	struct MWIPMATDEF_TAG MWIPMATDEF;

	int		i_step = 0;
    int     i_cursor_step = 0;
	int		i_trs_count_sum;

    TRSNode *list_item;

	char	s_mat_id[30];
	char	s_mat_short_desc[50];
	char	s_mat_desc[200];
	char	s_unit_1[10];

	memset(s_mat_id, ' ', sizeof(s_mat_id));	
	memset(s_mat_short_desc, ' ', sizeof(s_mat_short_desc));
	memset(s_mat_desc, ' ', sizeof(s_mat_desc));
	memset(s_unit_1, ' ', sizeof(s_unit_1));
	
    /* Log Generation */
    LOG_head("TIV_View_Material_List_For_TRS");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("FACTORY", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
    LOG_add("WORK_DATE", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("SHIFT", MP_NSTR, TRS.get_string(in_node, "SHIFT"));
    LOG_add("GEN_SEQ_NUM", MP_INT, TRS.get_int(in_node, "GEN_SEQ_NUM"));
    LOG_add("MAT_ID", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("MAT_VER", MP_INT, TRS.get_int(in_node, "MAT_VER"));

    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("TIV", "TIV_View_Material_List_For_TRS",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    if(TIV_View_Material_List_For_TRS_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (TRS.get_procstep(in_node) == '2')
	{
		DBC_init_mtivmlstrs(&MTIVMLSTRS);   
		TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
		MTIVMLSTRS.GEN_SEQ_NUM = 0;
    
		i_step = 2;
		i_trs_count_sum = (int)DBC_select_mtivmlstrs_scalar(i_step, &MTIVMLSTRS);

		TRS.set_int(out_node, "TRS_COUNT_SUM", i_trs_count_sum);

		/*COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;*/
	}
	
	if (TRS.get_procstep(in_node) == '1')
	{
		DBC_init_mtivmlstrs(&MTIVMLSTRS);
		TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, "FACTORY");
		TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
	 
		MTIVMLSTRS.GEN_SEQ_NUM = TRS.get_int(in_node, "NEXT_GEN_SEQ_NUM");
		TRS.copy(MTIVMLSTRS.MAT_ID, sizeof(MTIVMLSTRS.MAT_ID), in_node, "NEXT_MAT_ID");

		i_cursor_step = 2;
	}
	else if (TRS.get_procstep(in_node) == '2')
	{
		DBC_init_mtivmlstrs(&MTIVMLSTRS);
		TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, "FACTORY");
		TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
		MTIVMLSTRS.GEN_SEQ_NUM = TRS.get_int(in_node, "GEN_SEQ_NUM");

		TRS.copy(MTIVMLSTRS.MAT_ID, sizeof(MTIVMLSTRS.MAT_ID), in_node, "NEXT_MAT_ID");

		i_cursor_step = 3;
	}

	DBC_open_mtivmlstrs(i_cursor_step, &MTIVMLSTRS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "MTIVMLSTRS OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
		TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR,  sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
		TRS.add_fieldmsg(out_node, "SHIFT", MP_STR,  sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
		TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
	
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		DBC_fetch_mtivmlstrs(i_cursor_step, &MTIVMLSTRS);
		if(DB_error_code == DB_NOT_FOUND)
		{
			DBC_close_mtivmlstrs(i_cursor_step);
			break;
		}
		else if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MTIVMLSTRS FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR,  sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "SHIFT", MP_STR,  sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
			TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);

			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			DBC_close_mtivmlstrs(i_cursor_step);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if(COM_check_node_length(out_node) == MP_FALSE)
		{
			/* Add Next Value Here */
			TRS.add_int(out_node, "NEXT_GEN_SEQ_NUM", MTIVMLSTRS.GEN_SEQ_NUM);
			TRS.add_string(out_node, "NEXT_MAT_ID", MTIVMLSTRS.MAT_ID, sizeof(MTIVMLSTRS.MAT_ID));
			DBC_close_mtivmlstrs(i_cursor_step);
			break;
		}

		list_item = TRS.add_node(out_node, "LIST_ITEM");
		TRS.add_string(list_item, "FACTORY", MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY));
		TRS.add_string(list_item, "WORK_DATE", MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE));
		TRS.add_string(list_item, "SHIFT", MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT));
		TRS.add_int(list_item, "GEN_SEQ_NUM", MTIVMLSTRS.GEN_SEQ_NUM);
		TRS.add_string(list_item, "MAT_ID", MTIVMLSTRS.MAT_ID, sizeof(MTIVMLSTRS.MAT_ID));
		TRS.add_int(list_item, "MAT_VER", MTIVMLSTRS.MAT_VER);
		TRS.add_string(list_item, "INV_OPER", MTIVMLSTRS.INV_OPER, sizeof(MTIVMLSTRS.INV_OPER));
		TRS.add_double(list_item, "QTY_1", MTIVMLSTRS.QTY_1);
		TRS.add_double(list_item, "QTY_2", MTIVMLSTRS.QTY_2);
		TRS.add_double(list_item, "QTY_3", MTIVMLSTRS.QTY_3);
		TRS.add_int(list_item, "TRS_COUNT", MTIVMLSTRS.TRS_COUNT);
		TRS.add_double(list_item, "TOTAL_TRS_QTY_1", MTIVMLSTRS.TOTAL_TRS_QTY_1);
		TRS.add_double(list_item, "TOTAL_TRS_QTY_2", MTIVMLSTRS.TOTAL_TRS_QTY_2);
		TRS.add_double(list_item, "TOTAL_TRS_QTY_3", MTIVMLSTRS.TOTAL_TRS_QTY_3);
		TRS.add_double(list_item, "TOTAL_RCV_QTY_1", MTIVMLSTRS.TOTAL_RCV_QTY_1);
		TRS.add_double(list_item, "TOTAL_RCV_QTY_2", MTIVMLSTRS.TOTAL_RCV_QTY_2);
		TRS.add_double(list_item, "TOTAL_RCV_QTY_3", MTIVMLSTRS.TOTAL_RCV_QTY_3);
		TRS.add_string(list_item, "MLS_CMF_1", MTIVMLSTRS.MLS_CMF_1, sizeof(MTIVMLSTRS.MLS_CMF_1));
		TRS.add_string(list_item, "MLS_CMF_2", MTIVMLSTRS.MLS_CMF_2, sizeof(MTIVMLSTRS.MLS_CMF_2));
		TRS.add_string(list_item, "MLS_CMF_3", MTIVMLSTRS.MLS_CMF_3, sizeof(MTIVMLSTRS.MLS_CMF_3));
		TRS.add_string(list_item, "MLS_CMF_4", MTIVMLSTRS.MLS_CMF_4, sizeof(MTIVMLSTRS.MLS_CMF_4));
		TRS.add_string(list_item, "MLS_CMF_5", MTIVMLSTRS.MLS_CMF_5, sizeof(MTIVMLSTRS.MLS_CMF_5));
		TRS.add_string(list_item, "MLS_CMF_6", MTIVMLSTRS.MLS_CMF_6, sizeof(MTIVMLSTRS.MLS_CMF_6));
		TRS.add_string(list_item, "MLS_CMF_7", MTIVMLSTRS.MLS_CMF_7, sizeof(MTIVMLSTRS.MLS_CMF_7));
		TRS.add_string(list_item, "MLS_CMF_8", MTIVMLSTRS.MLS_CMF_8, sizeof(MTIVMLSTRS.MLS_CMF_8));
		TRS.add_string(list_item, "MLS_CMF_9", MTIVMLSTRS.MLS_CMF_9, sizeof(MTIVMLSTRS.MLS_CMF_9));
		TRS.add_string(list_item, "MLS_CMF_10", MTIVMLSTRS.MLS_CMF_10, sizeof(MTIVMLSTRS.MLS_CMF_10));
		TRS.add_char(list_item, "APPLY_FLAG", MTIVMLSTRS.APPLY_FLAG);
		TRS.add_string(list_item, "CREATE_USER_ID", MTIVMLSTRS.CREATE_USER_ID, sizeof(MTIVMLSTRS.CREATE_USER_ID));
		TRS.add_string(list_item, "CREATE_TIME", MTIVMLSTRS.CREATE_TIME, sizeof(MTIVMLSTRS.CREATE_TIME));
		TRS.add_string(list_item, "UPDATE_USER_ID", MTIVMLSTRS.UPDATE_USER_ID, sizeof(MTIVMLSTRS.UPDATE_USER_ID));
		TRS.add_string(list_item, "UPDATE_TIME", MTIVMLSTRS.UPDATE_TIME, sizeof(MTIVMLSTRS.UPDATE_TIME));

		if (memcmp(MTIVMLSTRS.MAT_ID, s_mat_id, sizeof(s_mat_id)) != 0)
		{
			DBC_init_mwipmatdef(&MWIPMATDEF);
			TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEF.MAT_ID, MTIVMLSTRS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPMATDEF.MAT_VER  = MTIVMLSTRS.MAT_VER;
			DBC_select_mwipmatdef(1, &MWIPMATDEF);
			if(DB_error_code != DB_SUCCESS) 
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "WIP-0006");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else 
				{
					strcpy(s_msg_code, "WIP-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}

				TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
				TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
 
				DBC_close_mtivmlstrs(i_cursor_step);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			memcpy(s_mat_id, MWIPMATDEF.MAT_ID, sizeof(s_mat_id));
			memcpy(s_mat_short_desc, MWIPMATDEF.MAT_SHORT_DESC, sizeof(s_mat_short_desc));
			memcpy(s_mat_desc, MWIPMATDEF.MAT_DESC, sizeof(s_mat_desc));
			memcpy(s_unit_1, MWIPMATDEF.UNIT_1, sizeof(s_unit_1));
		}
		TRS.add_string(list_item, "MAT_SHORT_DESC", s_mat_short_desc, sizeof(s_mat_short_desc));
		TRS.add_string(list_item, "MAT_DESC", s_mat_desc, sizeof(s_mat_desc));
		TRS.add_string(list_item, "UNIT_1", s_unit_1, sizeof(s_unit_1));

	}
		
    if(COM_proc_user_routine("TIV", "TIV_View_Material_List_For_TRS",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_View_Material_List_For_TRS_Validation()
        - Validation check sub function of"TIV_VIEW_MATERIAL_LIST_FOR_TRS" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material_List_For_TRS_Validation(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node) 
{

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12A") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation   */
    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
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