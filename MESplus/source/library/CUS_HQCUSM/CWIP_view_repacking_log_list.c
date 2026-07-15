/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_repacking_log_list.c
    Description : View Repacking_Log List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Repacking_Log_List()
            + View Repacking_Log definition List
        - CWIP_VIEW_REPACKING_LOG_LIST()
            + Main sub function of CWIP_View_Repacking_Log_List function
            + View Repacking_Log definition List
    Detail Description
        - CWIP_VIEW_REPACKING_LOG_LIST()
            + h_proc_step
                + 1 : View Repacking_Log definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/08/01             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "CUS_common.h"

/*******************************************************************************
    CWIP_View_Repacking_Log_List()
        - View Repacking_Log definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Repacking_Log_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_REPACKING_LOG_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_REPACKING_LOG_LIST", out_node);

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
    CWIP_VIEW_REPACKING_LOG_LIST()
        - Main sub function of "CWIP_View_Repacking_Log_List" function
        - View Repacking_Log definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_REPACKING_LOG_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
    struct CWIPRPKHIS_TAG CWIPRPKHIS;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_REPACKING_LOG_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("pallet_id", MP_NSTR, TRS.get_string(in_node, "PALLET_ID"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Repacking_Log_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	/* FACTORY_NO Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY_NO")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY_NO", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }  
    /* PALLET_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "PALLET_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "PALLET_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplotpak(&CWIPLOTPAK);
    TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID"); 
	CDB_select_cwiplotpak(8, &CWIPLOTPAK);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0658");
        TRS.add_fieldmsg(out_node, "PALLET_ID", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_cwiprpkhis(&CWIPRPKHIS);
    TRS.copy(CWIPRPKHIS.FACTORY, sizeof(CWIPRPKHIS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPRPKHIS.FACTORY_NO, sizeof(CWIPRPKHIS.FACTORY_NO), in_node, "FACTORY_NO"); 
    TRS.copy(CWIPRPKHIS.PALLET_ID, sizeof(CWIPRPKHIS.PALLET_ID), in_node, "PALLET_ID"); 
    CDB_open_cwiprpkhis(i_case, &CWIPRPKHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CWIPRPKHIS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRPKHIS.FACTORY), CWIPRPKHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "FACTORY_NO", MP_STR, sizeof(CWIPRPKHIS.FACTORY_NO), CWIPRPKHIS.FACTORY_NO);
        TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPRPKHIS.PALLET_ID), CWIPRPKHIS.PALLET_ID);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPRPKHIS.MAT_ID), CWIPRPKHIS.MAT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_cwiprpkhis(i_case, &CWIPRPKHIS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiprpkhis(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPRPKHIS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPRPKHIS.FACTORY), CWIPRPKHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "FACTORY_NO", MP_STR, sizeof(CWIPRPKHIS.FACTORY_NO), CWIPRPKHIS.FACTORY_NO);
            TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPRPKHIS.PALLET_ID), CWIPRPKHIS.PALLET_ID);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPRPKHIS.MAT_ID), CWIPRPKHIS.MAT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cwiprpkhis(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_PALLET_ID", CWIPRPKHIS.PALLET_ID, sizeof(CWIPRPKHIS.PALLET_ID));
            TRS.set_string(out_node, "NEXT_MAT_ID", CWIPRPKHIS.MAT_ID, sizeof(CWIPRPKHIS.MAT_ID));
            CDB_close_cwiprpkhis(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "REPACKING_LOG_LIST");

        TRS.add_string(list_item, "FACTORY", CWIPRPKHIS.FACTORY, sizeof(CWIPRPKHIS.FACTORY));
        TRS.add_string(list_item, "FACTORY_NO", CWIPRPKHIS.FACTORY_NO, sizeof(CWIPRPKHIS.FACTORY_NO));
        TRS.add_string(list_item, "PALLET_ID", CWIPRPKHIS.PALLET_ID, sizeof(CWIPRPKHIS.PALLET_ID));
        TRS.add_string(list_item, "MAT_ID", CWIPRPKHIS.MAT_ID, sizeof(CWIPRPKHIS.MAT_ID));
        TRS.add_string(list_item, "CAUSE_ID", CWIPRPKHIS.CAUSE_ID, sizeof(CWIPRPKHIS.CAUSE_ID));
        TRS.add_string(list_item, "PACK_TIME", CWIPRPKHIS.PACK_TIME, sizeof(CWIPRPKHIS.PACK_TIME));
        TRS.add_string(list_item, "CMF_1", CWIPRPKHIS.CMF_1, sizeof(CWIPRPKHIS.CMF_1));
        TRS.add_string(list_item, "CMF_2", CWIPRPKHIS.CMF_2, sizeof(CWIPRPKHIS.CMF_2));
        TRS.add_string(list_item, "CMF_3", CWIPRPKHIS.CMF_3, sizeof(CWIPRPKHIS.CMF_3));
        TRS.add_string(list_item, "CMF_4", CWIPRPKHIS.CMF_4, sizeof(CWIPRPKHIS.CMF_4));
        TRS.add_string(list_item, "CMF_5", CWIPRPKHIS.CMF_5, sizeof(CWIPRPKHIS.CMF_5));
        TRS.add_string(list_item, "CMF_6", CWIPRPKHIS.CMF_6, sizeof(CWIPRPKHIS.CMF_6));
        TRS.add_string(list_item, "CMF_7", CWIPRPKHIS.CMF_7, sizeof(CWIPRPKHIS.CMF_7));
        TRS.add_string(list_item, "CMF_8", CWIPRPKHIS.CMF_8, sizeof(CWIPRPKHIS.CMF_8));
        TRS.add_string(list_item, "CMF_9", CWIPRPKHIS.CMF_9, sizeof(CWIPRPKHIS.CMF_9));
        TRS.add_string(list_item, "CMF_10", CWIPRPKHIS.CMF_10, sizeof(CWIPRPKHIS.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CWIPRPKHIS.CREATE_USER_ID, sizeof(CWIPRPKHIS.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CWIPRPKHIS.CREATE_TIME, sizeof(CWIPRPKHIS.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CWIPRPKHIS.UPDATE_USER_ID, sizeof(CWIPRPKHIS.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CWIPRPKHIS.UPDATE_TIME, sizeof(CWIPRPKHIS.UPDATE_TIME));

		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CWIPRPKHIS.FACTORY, sizeof(CWIPRPKHIS.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@PAKING_MTRL_LIST", sizeof("@PAKING_MTRL_LIST")); 
		memcpy(MGCMTBLDAT.KEY_1,CWIPRPKHIS.MAT_ID, sizeof(CWIPRPKHIS.MAT_ID)); 
		CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "MATERIAL_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}

		CDB_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, CWIPRPKHIS.FACTORY, sizeof(CWIPRPKHIS.FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "@REPAKING_CAUSE_LIST", sizeof("@REPAKING_CAUSE_LIST")); 
		memcpy(MGCMTBLDAT.KEY_1,CWIPRPKHIS.CAUSE_ID, sizeof(CWIPRPKHIS.CAUSE_ID)); 
		CDB_select_mgcmtbldat(4, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.add_string(list_item, "CAUSE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Repacking_Log_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

