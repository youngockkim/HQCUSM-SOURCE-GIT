/*******************************************************************************

    System      : MESplus
    Module      : CUS
    File Name   : TIV_view_trs_assigned_lot.c
    Description :  

    MES Version : 5.0

    Function List
        - TIV_View_TRS_Assigned_Lot()
            + Main service
        - TIV_VIEW_TRS_ASSIGNED_LOT()
            + Main sub function of"TIV_View_TRS_Assigned_Lot" function            
        - TIV_View_TRS_Assigned_Lot_Validation()
            + Validation Check sub function of"TIV_VIEW_TRS_ASSIGNED_LOT" function

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1      2015-11-05

    Copyright(C) 1998-2024 Miracom,Inc.
    All rights reserved.


*******************************************************************************/

#include "TIVCore_common.h"


int TIV_View_TRS_Assigned_Lot_Validation(char *s_msg_code,
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
int TIV_View_TRS_Assigned_Lot(TRSNode *in_node, 
                                   TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_TRS_ASSIGNED_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_TRS_ASSIGNED_LOT", out_node); 

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
    TIV_VIEW_TRS_ASSIGNED_LOT()
        - Main sub function of "TIV_View_TRS_Assigned_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_TRS_ASSIGNED_LOT(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node)
{
    struct MTIVTRSLOT_TAG MTIVTRSLOT;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MTIVLOTSTS_TAG MTIVLOTSTS;

    int     i_cursor_step;
	int		i_step;

	char	s_mat_id[30];
	char	s_mat_short_desc[50];
	char	s_mat_desc[200];

    TRSNode *list_item;

    /* Log Generation */
    LOG_head("TIV_View_TRS_Assigned_Lot");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("FACTORY", MP_NSTR, TRS.get_string(in_node, "FACTORY"));
    LOG_add("TRS_NO", MP_NSTR, TRS.get_string(in_node, "TRS_NO"));
    LOG_add("ASSIGN_TYPE", MP_CHR, TRS.get_char(in_node, "ASSIGN_TYPE"));
    LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("OPER", MP_NSTR, TRS.get_string(in_node, "OPER"));

    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("TIV", "TIV_View_TRS_Assigned_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

	memset(s_mat_id, ' ', sizeof(s_mat_id));	
	memset(s_mat_short_desc, ' ', sizeof(s_mat_short_desc));
	memset(s_mat_desc, ' ', sizeof(s_mat_desc));

    if(TIV_View_TRS_Assigned_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivtrslot(&MTIVTRSLOT);
    TRS.copy(MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY), in_node, "FACTORY");
    TRS.copy(MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO), in_node, "TRS_NO");
    //MTIVTRSLOT.ASSIGN_TYPE = TRS.get_char(in_node, "ASSIGN_TYPE");
    TRS.copy(MTIVTRSLOT.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID), in_node, "NEXT_LOT_ID");
    //TRS.copy(MTIVTRSLOT.OPER, sizeof(MTIVTRSLOT.OPER), in_node, "OPER");
 
    i_cursor_step = 3;

    DBC_open_mtivtrslot(i_cursor_step, &MTIVTRSLOT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVTRSLOT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
        TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
        TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);

        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mtivtrslot(i_cursor_step, &MTIVTRSLOT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mtivtrslot(i_cursor_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVTRSLOT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVTRSLOT.FACTORY), MTIVTRSLOT.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR,  sizeof(MTIVTRSLOT.TRS_NO), MTIVTRSLOT.TRS_NO);
			TRS.add_fieldmsg(out_node, "ASSIGN_TYPE", MP_CHR, MTIVTRSLOT.ASSIGN_TYPE);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVTRSLOT.LOT_ID), MTIVTRSLOT.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR,  sizeof(MTIVTRSLOT.OPER), MTIVTRSLOT.OPER);

			TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mtivtrslot(i_cursor_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            /* Add Next Value Here */

			TRS.set_string(out_node, "NEXT_LOT_ID", MTIVTRSLOT.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
			
            DBC_close_mtivtrslot(i_cursor_step);
            break;
        }

        list_item = TRS.add_node(out_node, "LOT_LIST");
        TRS.add_string(list_item, "FACTORY", MTIVTRSLOT.FACTORY, sizeof(MTIVTRSLOT.FACTORY));
        TRS.add_string(list_item, "TRS_NO", MTIVTRSLOT.TRS_NO, sizeof(MTIVTRSLOT.TRS_NO));
        TRS.add_char(list_item, "ASSIGN_TYPE", MTIVTRSLOT.ASSIGN_TYPE);
        TRS.add_string(list_item, "LOT_ID", MTIVTRSLOT.LOT_ID, sizeof(MTIVTRSLOT.LOT_ID));
        TRS.add_string(list_item, "OPER", MTIVTRSLOT.OPER, sizeof(MTIVTRSLOT.OPER));
        TRS.add_double(list_item, "ASSIGN_QTY", MTIVTRSLOT.ASSIGN_QTY);
        TRS.add_string(list_item, "MAT_ID", MTIVTRSLOT.MAT_ID, sizeof(MTIVTRSLOT.MAT_ID));
        TRS.add_int(list_item, "MAT_VER", MTIVTRSLOT.MAT_VER);
        TRS.add_string(list_item, "ASN_CMF_1", MTIVTRSLOT.ASN_CMF_1, sizeof(MTIVTRSLOT.ASN_CMF_1));
        TRS.add_string(list_item, "ASN_CMF_2", MTIVTRSLOT.ASN_CMF_2, sizeof(MTIVTRSLOT.ASN_CMF_2));
        TRS.add_string(list_item, "ASN_CMF_3", MTIVTRSLOT.ASN_CMF_3, sizeof(MTIVTRSLOT.ASN_CMF_3));
        TRS.add_string(list_item, "ASN_CMF_4", MTIVTRSLOT.ASN_CMF_4, sizeof(MTIVTRSLOT.ASN_CMF_4));
        TRS.add_string(list_item, "ASN_CMF_5", MTIVTRSLOT.ASN_CMF_5, sizeof(MTIVTRSLOT.ASN_CMF_5));
        TRS.add_string(list_item, "ASN_CMF_6", MTIVTRSLOT.ASN_CMF_6, sizeof(MTIVTRSLOT.ASN_CMF_6));
        TRS.add_string(list_item, "ASN_CMF_7", MTIVTRSLOT.ASN_CMF_7, sizeof(MTIVTRSLOT.ASN_CMF_7));
        TRS.add_string(list_item, "ASN_CMF_8", MTIVTRSLOT.ASN_CMF_8, sizeof(MTIVTRSLOT.ASN_CMF_8));
        TRS.add_string(list_item, "ASN_CMF_9", MTIVTRSLOT.ASN_CMF_9, sizeof(MTIVTRSLOT.ASN_CMF_9));
        TRS.add_string(list_item, "ASN_CMF_10", MTIVTRSLOT.ASN_CMF_10, sizeof(MTIVTRSLOT.ASN_CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", MTIVTRSLOT.CREATE_USER_ID, sizeof(MTIVTRSLOT.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", MTIVTRSLOT.CREATE_TIME, sizeof(MTIVTRSLOT.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", MTIVTRSLOT.UPDATE_USER_ID, sizeof(MTIVTRSLOT.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", MTIVTRSLOT.UPDATE_TIME, sizeof(MTIVTRSLOT.UPDATE_TIME));

		if (memcmp(MTIVTRSLOT.MAT_ID, s_mat_id, sizeof(s_mat_id)) != 0)
		{
			DBC_init_mwipmatdef(&MWIPMATDEF);
			TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEF.MAT_ID, MTIVTRSLOT.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPMATDEF.MAT_VER  = MTIVTRSLOT.MAT_VER;
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
 
				DBC_close_mtivtrslot(i_cursor_step);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			memcpy(s_mat_id, MWIPMATDEF.MAT_ID, sizeof(s_mat_id));
			memcpy(s_mat_short_desc, MWIPMATDEF.MAT_SHORT_DESC, sizeof(s_mat_short_desc));
			memcpy(s_mat_desc, MWIPMATDEF.MAT_DESC, sizeof(s_mat_desc));
		}
		TRS.add_string(list_item, "MAT_SHORT_DESC", s_mat_short_desc, sizeof(s_mat_short_desc));
		TRS.add_string(list_item, "MAT_DESC", s_mat_desc, sizeof(s_mat_desc));

		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		memcpy(MTIVLOTSTS.LOT_ID, MTIVTRSLOT.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));

		if (MTIVTRSLOT.ASSIGN_TYPE == MP_TIV_TRS_ASSIGN_TYPE_PREASSN)
		{
			memcpy(MTIVLOTSTS.OPER, MTIVTRSLOT.OPER, sizeof(MTIVLOTSTS.OPER));
			i_step = 4;
		}
		else
		{
			i_step = 6;
		}
		
		DBC_select_mtivlotsts(i_step, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0030");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}

			DBC_close_mtivtrslot(i_cursor_step);

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.add_string(list_item, "INV_IN_TIME", MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME));
		TRS.add_string(list_item, "RACK_ID", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
		TRS.add_string(list_item, "UNIT_1", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
    }

    if(COM_proc_user_routine("TIV", "TIV_View_TRS_Assigned_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_View_TRS_Assigned_Lot_Validation()
        - Validation check sub function of"TIV_VIEW_TRS_ASSIGNED_LOT" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_TRS_Assigned_Lot_Validation(char *s_msg_code,
                                  TRSNode *in_node,
                                  TRSNode *out_node) 
{
	 /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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