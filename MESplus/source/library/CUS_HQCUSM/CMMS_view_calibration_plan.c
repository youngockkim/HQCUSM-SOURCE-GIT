/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_calibration_plan.c
    Description : View Calibration_Plan function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Calibration_Plan()
            + View Calibration_Plan definition
        - CMMS_VIEW_CALIBRATION_PLAN()
            + Main sub function of CMMS_View_Calibration_Plan function
            + View Calibration_Plan definition
    Detail Description
        - CMMS_VIEW_CALIBRATION_PLAN()
            + h_proc_step
                + 1 : View Calibration_Plan definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-29             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Calibration_Plan()
        - View Calibration_Plan definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Calibration_Plan(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_CALIBRATION_PLAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_CALIBRATION_PLAN", out_node);

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
    CMMS_VIEW_CALIBRATION_PLAN()
        - Main sub function of "CMMS_View_Calibration_Plan" function
        - View Calibration_Plan definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_CALIBRATION_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSCALPLN_TAG CMMSCALPLN;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CMMSINSDEF_TAG CMMSINSDEF;

	//FILE   *blob_file;
	//char   *file_name;
	//char   file_path[100];
 //   MBLOB  m_blob;

	//unsigned char  *in_data;
 //   unsigned char  out_data[100000];
 //   long            blob_size;
	//int i;

    LOG_head("CMMS_VIEW_CALIBRATION_PLAN");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Plan",
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

    CDB_init_cmmscalpln(&CMMSCALPLN);
    TRS.copy(CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID), in_node, "EQUIP_ID");
    CDB_select_cmmscalpln(1, &CMMSCALPLN);
    if(DB_error_code != DB_SUCCESS)
    {
		if (DB_error_code == DB_NOT_FOUND)
		{	// 교정 정보 없을 경우 True Return 
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}
		else
		{
			strcpy(s_msg_code, "MMS-0004");
			TRS.add_fieldmsg(out_node, "CMMSCALPLN SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSCALPLN.FACTORY), CMMSCALPLN.FACTORY);
			TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSCALPLN.EQUIP_ID), CMMSCALPLN.EQUIP_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
    }

    TRS.add_string(out_node, "FACTORY", CMMSCALPLN.FACTORY, sizeof(CMMSCALPLN.FACTORY));
    TRS.add_string(out_node, "EQUIP_ID", CMMSCALPLN.EQUIP_ID, sizeof(CMMSCALPLN.EQUIP_ID));
    TRS.add_string(out_node, "PLAN_DATE", CMMSCALPLN.PLAN_DATE, sizeof(CMMSCALPLN.PLAN_DATE));
    TRS.add_string(out_node, "CALI_DATE", CMMSCALPLN.CALI_DATE, sizeof(CMMSCALPLN.CALI_DATE));
    TRS.add_string(out_node, "CALI_INSTITUTE", CMMSCALPLN.CALI_INSTITUTE, sizeof(CMMSCALPLN.CALI_INSTITUTE));
    TRS.add_string(out_node, "CALI_METHOD", CMMSCALPLN.CALI_METHOD, sizeof(CMMSCALPLN.CALI_METHOD));
    TRS.add_char(out_node, "CALI_RESULT", CMMSCALPLN.CALI_RESULT);
    TRS.add_double(out_node, "CALI_COST", CMMSCALPLN.CALI_COST);
    TRS.add_string(out_node, "CALI_STATUS", CMMSCALPLN.CALI_STATUS, sizeof(CMMSCALPLN.CALI_STATUS));
    TRS.add_string(out_node, "FILE_NAME", CMMSCALPLN.FILE_NAME, sizeof(CMMSCALPLN.FILE_NAME));
    TRS.add_string(out_node, "FILE_PATH", CMMSCALPLN.FILE_PATH, sizeof(CMMSCALPLN.FILE_PATH));
    TRS.add_char(out_node, "ALARM_FLAG", CMMSCALPLN.ALARM_FLAG);
    TRS.add_string(out_node, "ALARM_CODE", CMMSCALPLN.ALARM_CODE, sizeof(CMMSCALPLN.ALARM_CODE));
    TRS.add_int(out_node, "ALARM_PERIOD", CMMSCALPLN.ALARM_PERIOD);
    TRS.add_string(out_node, "CMF_1", CMMSCALPLN.CMF_1, sizeof(CMMSCALPLN.CMF_1));
    TRS.add_string(out_node, "CMF_2", CMMSCALPLN.CMF_2, sizeof(CMMSCALPLN.CMF_2));
    TRS.add_string(out_node, "CMF_3", CMMSCALPLN.CMF_3, sizeof(CMMSCALPLN.CMF_3));
    TRS.add_string(out_node, "CMF_4", CMMSCALPLN.CMF_4, sizeof(CMMSCALPLN.CMF_4));
    TRS.add_string(out_node, "CMF_5", CMMSCALPLN.CMF_5, sizeof(CMMSCALPLN.CMF_5));
    TRS.add_string(out_node, "CMF_6", CMMSCALPLN.CMF_6, sizeof(CMMSCALPLN.CMF_6));
    TRS.add_string(out_node, "CMF_7", CMMSCALPLN.CMF_7, sizeof(CMMSCALPLN.CMF_7));
    TRS.add_string(out_node, "CMF_8", CMMSCALPLN.CMF_8, sizeof(CMMSCALPLN.CMF_8));
    TRS.add_string(out_node, "CMF_9", CMMSCALPLN.CMF_9, sizeof(CMMSCALPLN.CMF_9));
    TRS.add_string(out_node, "CMF_10", CMMSCALPLN.CMF_10, sizeof(CMMSCALPLN.CMF_10));
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSCALPLN.CREATE_USER_ID, sizeof(CMMSCALPLN.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSCALPLN.CREATE_TIME, sizeof(CMMSCALPLN.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSCALPLN.UPDATE_USER_ID, sizeof(CMMSCALPLN.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSCALPLN.UPDATE_TIME, sizeof(CMMSCALPLN.UPDATE_TIME));

	if (COM_isspace(CMMSCALPLN.FILE_PATH, sizeof(CMMSCALPLN.FILE_PATH)) == MP_FALSE)
    {
        if(CMMS_get_attached_file(s_msg_code, out_node, CMMSCALPLN.FILE_PATH, MP_BIN_DATA_1, 'Y') == MP_FALSE)
        {
            COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_WARN, TRS.get_language(in_node));
        }
    }


	CDB_init_cmmsinsdef(&CMMSINSDEF);
    TRS.copy(CMMSINSDEF.FACTORY, sizeof(CMMSINSDEF.FACTORY), in_node, IN_FACTORY);
	memcpy(CMMSINSDEF.INSTI_CODE, CMMSCALPLN.CALI_INSTITUTE, sizeof(CMMSINSDEF.INSTI_CODE));
	CDB_select_cmmsinsdef(1, &CMMSINSDEF);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "CALI_INSTITUTE_NAME", CMMSINSDEF.INSTI_NAME, sizeof(CMMSINSDEF.INSTI_NAME));
    }

	////GCM 조회
	//DBC_init_mgcmtbldat(&MGCMTBLDAT);
 //   TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	//memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_CALI_INSTITUTE, strlen(HQCEL_GCM_MMS_CALI_INSTITUTE));
 //   memcpy(MGCMTBLDAT.KEY_1, CMMSCALPLN.CALI_INSTITUTE, sizeof(CMMSCALPLN.CALI_INSTITUTE));
	//DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
 //   if(DB_error_code == DB_SUCCESS)
 //   {
 //       TRS.add_string(out_node, "CALI_INSTITUTE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
 //   }

	//GCM 조회
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ALARM_CODE, strlen(HQCEL_GCM_MMS_ALARM_CODE));
    memcpy(MGCMTBLDAT.KEY_1, CMMSCALPLN.ALARM_CODE, sizeof(CMMSCALPLN.ALARM_CODE));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "ALARM_CODE_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }

	

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Calibration_Plan",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

