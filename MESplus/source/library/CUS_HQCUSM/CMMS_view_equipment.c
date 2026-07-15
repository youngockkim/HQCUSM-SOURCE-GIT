/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_equipment.c
    Description : View Equipment function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Equipment()
            + View Equipment definition
        - CMMS_VIEW_EQUIPMENT()
            + Main sub function of CMMS_View_Equipment function
            + View Equipment definition
    Detail Description
        - CMMS_VIEW_EQUIPMENT()
            + h_proc_step
                + 1 : View Equipment definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-20             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Equipment()
        - View Equipment definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Equipment(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_EQUIPMENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_EQUIPMENT", out_node);

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
    CMMS_VIEW_EQUIPMENT()
        - Main sub function of "CMMS_View_Equipment" function
        - View Equipment definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_EQUIPMENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSEQPDEF_TAG CMMSEQPDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MSECUSRDEF_TAG MSECUSRDEF;
	struct CMMSEQPFLE_TAG CMMSEQPFLE;

	TRSNode *list_item;
	int i_case;

    LOG_head("CMMS_VIEW_EQUIPMENT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Equipment",
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
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* EQUIP_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "EQUIP_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmseqpdef(&CMMSEQPDEF);
    TRS.copy(CMMSEQPDEF.FACTORY, sizeof(CMMSEQPDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID), in_node, "EQUIP_ID");
    CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSEQPDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF.FACTORY), CMMSEQPDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF.EQUIP_ID), CMMSEQPDEF.EQUIP_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CMMSEQPDEF.FACTORY, sizeof(CMMSEQPDEF.FACTORY));
    TRS.add_string(out_node, "EQUIP_ID", CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID));
    TRS.add_string(out_node, "EQUIP_CODE", CMMSEQPDEF.EQUIP_CODE, sizeof(CMMSEQPDEF.EQUIP_CODE));
    TRS.add_string(out_node, "EQUIP_NAME", CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME));
	TRS.add_string(out_node, "EQUIP_TYPE", CMMSEQPDEF.EQUIP_TYPE, sizeof(CMMSEQPDEF.EQUIP_TYPE));
    TRS.add_string(out_node, "EQUIP_NO", CMMSEQPDEF.EQUIP_NO, sizeof(CMMSEQPDEF.EQUIP_NO));
    TRS.add_string(out_node, "MGT_DEPT_CODE", CMMSEQPDEF.MGT_DEPT_CODE, sizeof(CMMSEQPDEF.MGT_DEPT_CODE));
    TRS.add_string(out_node, "MGT_USER_ID", CMMSEQPDEF.MGT_USER_ID, sizeof(CMMSEQPDEF.MGT_USER_ID));
    TRS.add_string(out_node, "USE_DEPT_CODE", CMMSEQPDEF.USE_DEPT_CODE, sizeof(CMMSEQPDEF.USE_DEPT_CODE));
    TRS.add_string(out_node, "USE_USER_ID", CMMSEQPDEF.USE_USER_ID, sizeof(CMMSEQPDEF.USE_USER_ID));
    TRS.add_string(out_node, "USE_DIV", CMMSEQPDEF.USE_DIV, sizeof(CMMSEQPDEF.USE_DIV));
    TRS.add_char(out_node, "CALI_DIV", CMMSEQPDEF.CALI_DIV);
    TRS.add_string(out_node, "PARTNER_CODE", CMMSEQPDEF.PARTNER_CODE, sizeof(CMMSEQPDEF.PARTNER_CODE));
    TRS.add_string(out_node, "PROP_NO", CMMSEQPDEF.PROP_NO, sizeof(CMMSEQPDEF.PROP_NO));
    TRS.add_string(out_node, "SUPPLY_CODE", CMMSEQPDEF.SUPPLY_CODE, sizeof(CMMSEQPDEF.SUPPLY_CODE));
    TRS.add_string(out_node, "EQUIP_MAKER", CMMSEQPDEF.EQUIP_MAKER, sizeof(CMMSEQPDEF.EQUIP_MAKER));
    TRS.add_string(out_node, "EQUIP_MODEL", CMMSEQPDEF.EQUIP_MODEL, sizeof(CMMSEQPDEF.EQUIP_MODEL));
    TRS.add_string(out_node, "EQUIP_PURPOSE", CMMSEQPDEF.EQUIP_PURPOSE, sizeof(CMMSEQPDEF.EQUIP_PURPOSE));
    TRS.add_string(out_node, "EQUIP_FEATURE", CMMSEQPDEF.EQUIP_FEATURE, sizeof(CMMSEQPDEF.EQUIP_FEATURE));
    TRS.add_string(out_node, "EQUIP_PLACE_CODE", CMMSEQPDEF.EQUIP_PLACE_CODE, sizeof(CMMSEQPDEF.EQUIP_PLACE_CODE));
    TRS.add_string(out_node, "SERIAL_NO", CMMSEQPDEF.SERIAL_NO, sizeof(CMMSEQPDEF.SERIAL_NO));
    TRS.add_string(out_node, "EQUIP_SPEC", CMMSEQPDEF.EQUIP_SPEC, sizeof(CMMSEQPDEF.EQUIP_SPEC));
    TRS.add_string(out_node, "BUY_DATE", CMMSEQPDEF.BUY_DATE, sizeof(CMMSEQPDEF.BUY_DATE));
    TRS.add_double(out_node, "BUY_COST", CMMSEQPDEF.BUY_COST);
    TRS.add_int(out_node, "CALI_CYCLE", CMMSEQPDEF.CALI_CYCLE);
    TRS.add_int(out_node, "MSA_CYCLE", CMMSEQPDEF.MSA_CYCLE);
    TRS.add_string(out_node, "EQUIP_DESC", CMMSEQPDEF.EQUIP_DESC, sizeof(CMMSEQPDEF.EQUIP_DESC));
    TRS.add_int(out_node, "LAST_EQUIP_SEQ", CMMSEQPDEF.LAST_EQUIP_SEQ);
    TRS.add_string(out_node, "APPROVE_USER_ID", CMMSEQPDEF.APPROVE_USER_ID, sizeof(CMMSEQPDEF.APPROVE_USER_ID));
    TRS.add_char(out_node, "APPROVE_FLAG", CMMSEQPDEF.APPROVE_FLAG);
    TRS.add_char(out_node, "MSA_FLAG", CMMSEQPDEF.MSA_FLAG);
    TRS.add_char(out_node, "SPC_FLAG", CMMSEQPDEF.SPC_FLAG);
    TRS.add_char(out_node, "CALI_FLAG", CMMSEQPDEF.CALI_FLAG);
    TRS.add_char(out_node, "CHECK_FLAG", CMMSEQPDEF.CHECK_FLAG);
    TRS.add_char(out_node, "NONE_FLAG", CMMSEQPDEF.NONE_FLAG);
    TRS.add_char(out_node, "STANDARD_FLAG", CMMSEQPDEF.STANDARD_FLAG);
    TRS.add_char(out_node, "CMF_FLAG_01", CMMSEQPDEF.CMF_FLAG_01);
    TRS.add_char(out_node, "CMF_FLAG_02", CMMSEQPDEF.CMF_FLAG_02);
    TRS.add_char(out_node, "CMF_FLAG_03", CMMSEQPDEF.CMF_FLAG_03);
    TRS.add_string(out_node, "CMF_1", CMMSEQPDEF.CMF_1, sizeof(CMMSEQPDEF.CMF_1));
    TRS.add_string(out_node, "CMF_2", CMMSEQPDEF.CMF_2, sizeof(CMMSEQPDEF.CMF_2));
    TRS.add_string(out_node, "CMF_3", CMMSEQPDEF.CMF_3, sizeof(CMMSEQPDEF.CMF_3));
    TRS.add_string(out_node, "CMF_4", CMMSEQPDEF.CMF_4, sizeof(CMMSEQPDEF.CMF_4));
    TRS.add_string(out_node, "CMF_5", CMMSEQPDEF.CMF_5, sizeof(CMMSEQPDEF.CMF_5));
    TRS.add_string(out_node, "CMF_6", CMMSEQPDEF.CMF_6, sizeof(CMMSEQPDEF.CMF_6));
    TRS.add_string(out_node, "CMF_7", CMMSEQPDEF.CMF_7, sizeof(CMMSEQPDEF.CMF_7));
    TRS.add_string(out_node, "CMF_8", CMMSEQPDEF.CMF_8, sizeof(CMMSEQPDEF.CMF_8));
    TRS.add_string(out_node, "CMF_9", CMMSEQPDEF.CMF_9, sizeof(CMMSEQPDEF.CMF_9));
    TRS.add_string(out_node, "CMF_10", CMMSEQPDEF.CMF_10, sizeof(CMMSEQPDEF.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSEQPDEF.CREATE_USER_ID, sizeof(CMMSEQPDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSEQPDEF.CREATE_TIME, sizeof(CMMSEQPDEF.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSEQPDEF.UPDATE_USER_ID, sizeof(CMMSEQPDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSEQPDEF.UPDATE_TIME, sizeof(CMMSEQPDEF.UPDATE_TIME));


	//GCM 조회HQCEL_GCM_MMS_EQUIP_TYPE
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_EQUIP_TYPE, strlen(HQCEL_GCM_MMS_EQUIP_TYPE));
    memcpy(MGCMTBLDAT.KEY_1, CMMSEQPDEF.EQUIP_TYPE, sizeof(CMMSEQPDEF.EQUIP_TYPE));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "EQUIP_TYPE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	//GCM 조회	
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_DEPT_CODE, strlen(HQCEL_GCM_MMS_DEPT_CODE));
    memcpy(MGCMTBLDAT.KEY_1, CMMSEQPDEF.MGT_DEPT_CODE, sizeof(MGCMTBLDAT.KEY_1));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "MGT_DEPT_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	//GCM 조회
    memcpy(MGCMTBLDAT.KEY_1, CMMSEQPDEF.USE_DEPT_CODE, sizeof(MGCMTBLDAT.KEY_1));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "USE_DEPT_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	//GCM 조회HQCEL_GCM_MMS_PLACE_CODE
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_PLACE_CODE, strlen(HQCEL_GCM_MMS_PLACE_CODE));
    memcpy(MGCMTBLDAT.KEY_1, CMMSEQPDEF.EQUIP_PLACE_CODE, sizeof(MGCMTBLDAT.KEY_1));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "EQUIP_PLACE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	//GCM 조회HQCEL_GCM_MMS_USE_DIV
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_USE_DIV, strlen(HQCEL_GCM_MMS_USE_DIV));
    memcpy(MGCMTBLDAT.KEY_1, CMMSEQPDEF.USE_DIV, sizeof(MGCMTBLDAT.KEY_1));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "USE_DIV_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	DBC_init_msecusrdef(&MSECUSRDEF);
    TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MSECUSRDEF.USER_ID, CMMSEQPDEF.MGT_USER_ID, sizeof(MSECUSRDEF.USER_ID));
	DBC_select_msecusrdef(1, &MSECUSRDEF);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "MGT_USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
    }

    memcpy(MSECUSRDEF.USER_ID, CMMSEQPDEF.USE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
	DBC_select_msecusrdef(1, &MSECUSRDEF);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "USE_USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
    }

	memcpy(MSECUSRDEF.USER_ID, CMMSEQPDEF.APPROVE_USER_ID, sizeof(MSECUSRDEF.USER_ID));
	DBC_select_msecusrdef(1, &MSECUSRDEF);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "APPROVE_USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
    }

	i_case = 1;
	//이미지 정보 조회
	CDB_init_cmmseqpfle(&CMMSEQPFLE);
	memcpy(CMMSEQPFLE.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPFLE.FACTORY));
	memcpy(CMMSEQPFLE.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPFLE.EQUIP_ID));
	CDB_open_cmmseqpfle(i_case, &CMMSEQPFLE);
	if(DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code != DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSEQPFLE OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	while(1)
	{
		CDB_fetch_cmmseqpfle(i_case, &CMMSEQPFLE);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_cmmseqpfle(i_case);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSEQPFLE FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			CDB_close_cmmsinsdef(i_case);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "EQUIPMENT_IMAGE_LIST");
		TRS.add_string(list_item, "EQUIP_ID", CMMSEQPFLE.EQUIP_ID, sizeof(CMMSEQPFLE.EQUIP_ID));
		TRS.add_int(list_item, "FILE_ORDER", CMMSEQPFLE.FILE_ORDER);
		TRS.add_string(list_item, "FILE_NAME", CMMSEQPFLE.FILE_NAME, sizeof(CMMSEQPFLE.FILE_NAME));
		TRS.add_string(list_item, "FILE_PATH", CMMSEQPFLE.FILE_PATH, sizeof(CMMSEQPFLE.FILE_PATH));
		TRS.add_string(list_item, "FILE_DESC", CMMSEQPFLE.FILE_DESC, sizeof(CMMSEQPFLE.FILE_DESC));

		if (COM_isspace(CMMSEQPFLE.FILE_PATH, sizeof(CMMSEQPFLE.FILE_PATH)) == MP_FALSE)
		{
			if(CMMS_get_attached_file(s_msg_code, out_node, CMMSEQPFLE.FILE_PATH, TRS.get_string(list_item, "FILE_NAME"), 'Y') == MP_FALSE)
			{
				COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
			}
		}
	}


    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Equipment",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

