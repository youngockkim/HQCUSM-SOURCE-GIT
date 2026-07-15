/*******************************************************************************

    System      : MESplus
    Module      : TIV
    File Name   : TIV_update_material_list_for_trs.c
    Description : 

    MES Version : 5.0.0

    Function List
        - TIV_Update_Material_List_For_TRS()
            + Main service
        - TIV_UPDATE_MATERIAL_LIST_FOR_TRS()
            + Main sub function of "TIV_Update_Material_List_For_TRS" function
        - TIV_Update_Material_List_For_TRS_Validation()
            + Validation Check sub function of"TIV_UPDATE_MATERIAL_LIST_FOR_TRS" function

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


int TIV_Update_Material_List_For_TRS_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node);

/*******************************************************************************
    TIV_Update_Material_List_For_TRS()
        - Main service
    Return Value
        - Integer : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node :Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_Material_List_For_TRS(TRSNode *in_node, 
                        TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_UPDATE_MATERIAL_LIST_FOR_TRS(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_UPDATE_MATERIAL_LIST_FOR_TRS", out_node);

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
    TIV_UPDATE_MATERIAL_LIST_FOR_TRS()
        - Main sub function of "TIV_Update_Material_List_For_TRS" function
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_UPDATE_MATERIAL_LIST_FOR_TRS(char *s_msg_code,
                             TRSNode *in_node, 
                             TRSNode *out_node)
{
    struct  MTIVMLSTRS_TAG  MTIVMLSTRS;

    char    s_sys_time[14];

	int		i;
    int     i_step;
	int		i_max_gen_seq_num = 0;

	int		i_mat_count = 0;

	TRSNode** Mat_List;

    /* Log Generation */
    LOG_head("TIV_Update_Material_List_For_TRS");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("FACTORY", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
    LOG_add("WORK_DATE", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    LOG_add("SHIFT", MP_NSTR, TRS.get_string(in_node, "SHIFT"));
    LOG_add("GEN_SEQ_NUM", MP_INT, TRS.get_int(in_node, "GEN_SEQ_NUM"));
    LOG_add("MAT_ID", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("MAT_VER", MP_INT, TRS.get_int(in_node, "MAT_VER"));
   
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    if(COM_proc_user_routine("TIV", "TIV_Update_Material_List_For_TRS",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    if(TIV_Update_Material_List_For_TRS_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}

	if (TRS.get_procstep(in_node) == '1')
	{
		DBC_init_mtivmlstrs(&MTIVMLSTRS);   
		TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
		MTIVMLSTRS.GEN_SEQ_NUM = 0;
    
		i_step = 2;
		DBC_delete_mtivmlstrs(i_step, &MTIVMLSTRS);

		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
		{
			strcpy(s_msg_code, "INV-0004");            
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_fieldmsg(out_node, "MTIVMLSTRS DELETE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "SHIFT", MP_STR, sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			return MP_FALSE;
		}

		i_mat_count = TRS.get_item_count(in_node, "MAT_LIST");
		Mat_List = TRS.get_list(in_node, "MAT_LIST");

		for (i = 0; i < i_mat_count; i++)
		{
			DBC_init_mtivmlstrs(&MTIVMLSTRS);   
			TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
			MTIVMLSTRS.GEN_SEQ_NUM = 0;

			TRS.copy(MTIVMLSTRS.MAT_ID, sizeof(MTIVMLSTRS.MAT_ID), Mat_List[i], "MAT_ID");
			MTIVMLSTRS.MAT_VER = TRS.get_int(Mat_List[i], "MAT_VER");
			TRS.copy(MTIVMLSTRS.INV_OPER, sizeof(MTIVMLSTRS.INV_OPER), Mat_List[i], "INV_OPER");
			MTIVMLSTRS.QTY_1 = TRS.get_double(Mat_List[i], "QTY_1");
			MTIVMLSTRS.QTY_2 = TRS.get_double(Mat_List[i], "QTY_2");
			MTIVMLSTRS.QTY_3 = TRS.get_double(Mat_List[i], "QTY_3");

			TRS.copy(MTIVMLSTRS.MLS_CMF_1, sizeof(MTIVMLSTRS.MLS_CMF_1), Mat_List[i], "MLS_CMF_1");
			TRS.copy(MTIVMLSTRS.MLS_CMF_2, sizeof(MTIVMLSTRS.MLS_CMF_2), Mat_List[i], "MLS_CMF_2");
			TRS.copy(MTIVMLSTRS.MLS_CMF_3, sizeof(MTIVMLSTRS.MLS_CMF_3), Mat_List[i], "MLS_CMF_3");
			TRS.copy(MTIVMLSTRS.MLS_CMF_4, sizeof(MTIVMLSTRS.MLS_CMF_4), Mat_List[i], "MLS_CMF_4");
			TRS.copy(MTIVMLSTRS.MLS_CMF_5, sizeof(MTIVMLSTRS.MLS_CMF_5), Mat_List[i], "MLS_CMF_5");
			TRS.copy(MTIVMLSTRS.MLS_CMF_6, sizeof(MTIVMLSTRS.MLS_CMF_6), Mat_List[i], "MLS_CMF_6");
			TRS.copy(MTIVMLSTRS.MLS_CMF_7, sizeof(MTIVMLSTRS.MLS_CMF_7), Mat_List[i], "MLS_CMF_7");
			TRS.copy(MTIVMLSTRS.MLS_CMF_8, sizeof(MTIVMLSTRS.MLS_CMF_8), Mat_List[i], "MLS_CMF_8");
			TRS.copy(MTIVMLSTRS.MLS_CMF_9, sizeof(MTIVMLSTRS.MLS_CMF_9), Mat_List[i], "MLS_CMF_9");
			TRS.copy(MTIVMLSTRS.MLS_CMF_10, sizeof(MTIVMLSTRS.MLS_CMF_10), Mat_List[i], "MLS_CMF_10");

			TRS.copy(MTIVMLSTRS.CREATE_USER_ID, sizeof(MTIVMLSTRS.CREATE_USER_ID), in_node, "PRC_USER");
			memcpy(MTIVMLSTRS.CREATE_TIME, s_sys_time, sizeof(MTIVMLSTRS.CREATE_TIME));

			DBC_insert_mtivmlstrs(&MTIVMLSTRS);        
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVMLSTRS INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR,  sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "SHIFT", MP_STR,  sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
				TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
				TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);
            
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}
	
	if (TRS.get_procstep(in_node) == '2')
	{
		DBC_init_mtivmlstrs(&MTIVMLSTRS);   
		TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
		
		i_step = 3;
		i_max_gen_seq_num = (int)DBC_select_mtivmlstrs_scalar(i_step, &MTIVMLSTRS);
		i_max_gen_seq_num++;

		TRS.set_int(out_node, "GEN_SEQ_NUM", i_max_gen_seq_num);

		i_mat_count = TRS.get_item_count(in_node, "MAT_LIST");
		Mat_List = TRS.get_list(in_node, "MAT_LIST");

		for (i = 0; i < i_mat_count; i++)
		{
			DBC_init_mtivmlstrs(&MTIVMLSTRS);   
			TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
			TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
			MTIVMLSTRS.GEN_SEQ_NUM = i_max_gen_seq_num;

			TRS.copy(MTIVMLSTRS.MAT_ID, sizeof(MTIVMLSTRS.MAT_ID), Mat_List[i], "MAT_ID");
			MTIVMLSTRS.MAT_VER = TRS.get_int(Mat_List[i], "MAT_VER");
			//TRS.copy(MTIVMLSTRS.INV_OPER, sizeof(MTIVMLSTRS.INV_OPER), Mat_List[i], "INV_OPER");
			//MTIVMLSTRS.QTY_1 = TRS.get_double(Mat_List[i], "QTY_1");
			MTIVMLSTRS.QTY_1 = TRS.get_double(Mat_List[i], "REQ_QTY");
			/*MTIVMLSTRS.QTY_2 = TRS.get_double(Mat_List[i], "QTY_2");
			MTIVMLSTRS.QTY_3 = TRS.get_double(Mat_List[i], "QTY_3");*/

			TRS.copy(MTIVMLSTRS.MLS_CMF_1, sizeof(MTIVMLSTRS.MLS_CMF_1), Mat_List[i], "MLS_CMF_1");
			TRS.copy(MTIVMLSTRS.MLS_CMF_2, sizeof(MTIVMLSTRS.MLS_CMF_2), Mat_List[i], "MLS_CMF_2");
			TRS.copy(MTIVMLSTRS.MLS_CMF_3, sizeof(MTIVMLSTRS.MLS_CMF_3), Mat_List[i], "MLS_CMF_3");
			TRS.copy(MTIVMLSTRS.MLS_CMF_4, sizeof(MTIVMLSTRS.MLS_CMF_4), Mat_List[i], "MLS_CMF_4");
			TRS.copy(MTIVMLSTRS.MLS_CMF_5, sizeof(MTIVMLSTRS.MLS_CMF_5), Mat_List[i], "MLS_CMF_5");
			TRS.copy(MTIVMLSTRS.MLS_CMF_6, sizeof(MTIVMLSTRS.MLS_CMF_6), Mat_List[i], "MLS_CMF_6");
			TRS.copy(MTIVMLSTRS.MLS_CMF_7, sizeof(MTIVMLSTRS.MLS_CMF_7), Mat_List[i], "MLS_CMF_7");
			TRS.copy(MTIVMLSTRS.MLS_CMF_8, sizeof(MTIVMLSTRS.MLS_CMF_8), Mat_List[i], "MLS_CMF_8");
			TRS.copy(MTIVMLSTRS.MLS_CMF_9, sizeof(MTIVMLSTRS.MLS_CMF_9), Mat_List[i], "MLS_CMF_9");
			TRS.copy(MTIVMLSTRS.MLS_CMF_10, sizeof(MTIVMLSTRS.MLS_CMF_10), Mat_List[i], "MLS_CMF_10");

			TRS.copy(MTIVMLSTRS.CREATE_USER_ID, sizeof(MTIVMLSTRS.CREATE_USER_ID), in_node, "PRC_USER");
			memcpy(MTIVMLSTRS.CREATE_TIME, s_sys_time, sizeof(MTIVMLSTRS.CREATE_TIME));

			DBC_insert_mtivmlstrs(&MTIVMLSTRS);        
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MTIVMLSTRS INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR,  sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "SHIFT", MP_STR,  sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
				TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVMLSTRS.MAT_ID), MTIVMLSTRS.MAT_ID);
				TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMLSTRS.MAT_VER);
            
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}

    if(COM_proc_user_routine("TIV", "TIV_Update_Material_List_For_TRS",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Update_Material_List_For_TRS_Validation()
        - Validation Check sub function of "TIV_Update_Material_List_For_TRS" function
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_Material_List_For_TRS_Validation(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node)
{   
	struct  MTIVMLSTRS_TAG  MTIVMLSTRS;

	int i_step;

	int i_trs_count_sum = 0;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123") == MP_FALSE)
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

	if (TRS.get_procstep(in_node) == '1')
	{
		// CHECK FOR CASE CREATE / UPDATE
		DBC_init_mtivmlstrs(&MTIVMLSTRS);   
		TRS.copy(MTIVMLSTRS.FACTORY, sizeof(MTIVMLSTRS.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVMLSTRS.WORK_DATE, sizeof(MTIVMLSTRS.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(MTIVMLSTRS.SHIFT, sizeof(MTIVMLSTRS.SHIFT), in_node, "SHIFT");
		MTIVMLSTRS.GEN_SEQ_NUM = 0;
    
		i_step = 2;
		i_trs_count_sum = (int)DBC_select_mtivmlstrs_scalar(i_step, &MTIVMLSTRS);

		if (i_trs_count_sum > 0)
		{
			strcpy(s_msg_code, "WIP-0727");
			TRS.add_fieldmsg(out_node, "MTIVMLSTRS SELECT", MP_NVST);        
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMLSTRS.FACTORY), MTIVMLSTRS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR,  sizeof(MTIVMLSTRS.WORK_DATE), MTIVMLSTRS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "SHIFT", MP_STR,  sizeof(MTIVMLSTRS.SHIFT), MTIVMLSTRS.SHIFT);
			TRS.add_fieldmsg(out_node, "GEN_SEQ_NUM", MP_INT, MTIVMLSTRS.GEN_SEQ_NUM);
       
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

	}
	
    return MP_TRUE;
}
