/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_item.c
    Description : Item Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Item()
            + Create/Update/Delete Item definition
        - CMMS_UPDATE_ITEM()
            + Main sub function of CMMS_Update_Item function
            + Create/Update/Delete Item definition
        - CMMS_Update_Item_Validation()
            + Main sub function of CMMS_UPDATE_ITEM function
            + Check the condition for create/update/delete Item
    Detail Description
        - CMMS_UPDATE_ITEM()
            + h_proc_step
                + MP_STEP_CREATE : Create Item definition
                + MP_STEP_UPDATE : Update Item definition
                + MP_STEP_DELETE : Delete Item definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-08             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Item()
        - Create/Update/Delete Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_ITEM", out_node);

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
    CMMS_UPDATE_ITEM()
        - Main sub function of "CMMS_Update_Item" function
        - Create/Update/Delete Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSITMDEF_TAG CMMSITMDEF;
    struct CMMSITMDEF_TAG CMMSITMDEF_o;
	struct CMMSITMHIS_TAG CMMSITMHIS;

    char   s_sys_time[14];

    LOG_head("CMMS_UPDATE_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    LOG_add("item_name", MP_NSTR, TRS.get_string(in_node, "ITEM_NAME"));
    LOG_add("item_spec", MP_NSTR, TRS.get_string(in_node, "ITEM_SPEC"));
    LOG_add("item_group_code", MP_NSTR, TRS.get_string(in_node, "ITEM_GROUP_CODE"));
    LOG_add("tag_name", MP_NSTR, TRS.get_string(in_node, "TAG_NAME"));
    LOG_add("spec_type", MP_CHR, TRS.get_char(in_node, "SPEC_TYPE"));
    LOG_add("lsl", MP_DBL, TRS.get_double(in_node, "LSL"));
    LOG_add("target", MP_DBL, TRS.get_double(in_node, "TARGET"));
    LOG_add("usl", MP_DBL, TRS.get_double(in_node, "USL"));
    LOG_add("lcl", MP_DBL, TRS.get_double(in_node, "LCL"));
    LOG_add("ucl", MP_DBL, TRS.get_double(in_node, "UCL"));
    LOG_add("unit_code", MP_NSTR, TRS.get_string(in_node, "UNIT_CODE"));
    LOG_add("decimal_place", MP_INT, TRS.get_int(in_node, "DECIMAL_PLACE"));
    LOG_add("use_flag", MP_CHR, TRS.get_char(in_node, "USE_FLAG"));
    LOG_add("delete_flag", MP_CHR, TRS.get_char(in_node, "DELETE_FLAG"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Item",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

	/*
		History Table 저장 Logic 추가 필요 
		저장 전/후 결정 필요 (V6 버전 확인 후 추가 작업 진행 예정)
	*/

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

    if(CMMS_Update_Item_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsitmdef(&CMMSITMDEF);
	TRS.copy(CMMSITMDEF.FACTORY, sizeof(CMMSITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSITMDEF.ITEM_CODE, sizeof(CMMSITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    TRS.copy(CMMSITMDEF.ITEM_NAME, sizeof(CMMSITMDEF.ITEM_NAME), in_node, "ITEM_NAME");
    TRS.copy(CMMSITMDEF.ITEM_SPEC, sizeof(CMMSITMDEF.ITEM_SPEC), in_node, "ITEM_SPEC");
    TRS.copy(CMMSITMDEF.ITEM_GROUP_CODE, sizeof(CMMSITMDEF.ITEM_GROUP_CODE), in_node, "ITEM_GROUP_CODE");
    TRS.copy(CMMSITMDEF.TAG_NAME, sizeof(CMMSITMDEF.TAG_NAME), in_node, "TAG_NAME");
    CMMSITMDEF.SPEC_TYPE = TRS.get_char(in_node, "SPEC_TYPE");
    CMMSITMDEF.LSL = TRS.get_double(in_node, "LSL");
    CMMSITMDEF.TARGET = TRS.get_double(in_node, "TARGET");
    CMMSITMDEF.USL = TRS.get_double(in_node, "USL");
    CMMSITMDEF.LCL = TRS.get_double(in_node, "LCL");
    CMMSITMDEF.UCL = TRS.get_double(in_node, "UCL");
    TRS.copy(CMMSITMDEF.UNIT_CODE, sizeof(CMMSITMDEF.UNIT_CODE), in_node, "UNIT_CODE");
    CMMSITMDEF.DECIMAL_PLACE = TRS.get_int(in_node, "DECIMAL_PLACE");
    CMMSITMDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
    CMMSITMDEF.DELETE_FLAG = TRS.get_char(in_node, "DELETE_FLAG");
    TRS.copy(CMMSITMDEF.CREATE_USER_ID, sizeof(CMMSITMDEF.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSITMDEF.CREATE_TIME, sizeof(CMMSITMDEF.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSITMDEF.UPDATE_USER_ID, sizeof(CMMSITMDEF.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSITMDEF.UPDATE_TIME, sizeof(CMMSITMDEF.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMSITMDEF.CREATE_USER_ID, sizeof(CMMSITMDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSITMDEF.CREATE_TIME, s_sys_time, sizeof(CMMSITMDEF.CREATE_TIME));
        CDB_insert_cmmsitmdef(&CMMSITMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSITMDEF INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSITMDEF.FACTORY), CMMSITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF.ITEM_CODE), CMMSITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        CDB_init_cmmsitmdef(&CMMSITMDEF_o);
		TRS.copy(CMMSITMDEF_o.FACTORY, sizeof(CMMSITMDEF_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSITMDEF_o.ITEM_CODE, sizeof(CMMSITMDEF_o.ITEM_CODE), in_node, "ITEM_CODE");
        CDB_select_cmmsitmdef_for_update(1, &CMMSITMDEF_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSITMDEF SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSITMDEF_o.FACTORY), CMMSITMDEF_o.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF_o.ITEM_CODE), CMMSITMDEF_o.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----
		TRS.copy(CMMSITMDEF.ITEM_NAME, sizeof(CMMSITMDEF.ITEM_NAME), in_node, "ITEM_NAME");
		TRS.copy(CMMSITMDEF.ITEM_SPEC, sizeof(CMMSITMDEF.ITEM_SPEC), in_node, "ITEM_SPEC");
		TRS.copy(CMMSITMDEF.ITEM_GROUP_CODE, sizeof(CMMSITMDEF.ITEM_GROUP_CODE), in_node, "ITEM_GROUP_CODE");
		TRS.copy(CMMSITMDEF.TAG_NAME, sizeof(CMMSITMDEF.TAG_NAME), in_node, "TAG_NAME");
		CMMSITMDEF.SPEC_TYPE = TRS.get_char(in_node, "SPEC_TYPE");
		CMMSITMDEF.LSL = TRS.get_double(in_node, "LSL");
		CMMSITMDEF.TARGET = TRS.get_double(in_node, "TARGET");
		CMMSITMDEF.USL = TRS.get_double(in_node, "USL");
		CMMSITMDEF.LCL = TRS.get_double(in_node, "LCL");
		CMMSITMDEF.UCL = TRS.get_double(in_node, "UCL");
		TRS.copy(CMMSITMDEF.UNIT_CODE, sizeof(CMMSITMDEF.UNIT_CODE), in_node, "UNIT_CODE");
		CMMSITMDEF.DECIMAL_PLACE = TRS.get_int(in_node, "DECIMAL_PLACE");
		CMMSITMDEF.USE_FLAG = TRS.get_char(in_node, "USE_FLAG");
		CMMSITMDEF.DELETE_FLAG = TRS.get_char(in_node, "DELETE_FLAG");
        memcpy(CMMSITMDEF.CREATE_USER_ID, CMMSITMDEF_o.CREATE_USER_ID, sizeof(CMMSITMDEF.CREATE_USER_ID));
        memcpy(CMMSITMDEF.CREATE_TIME, CMMSITMDEF_o.CREATE_TIME, sizeof(CMMSITMDEF.CREATE_TIME));
        TRS.copy(CMMSITMDEF.UPDATE_USER_ID, sizeof(CMMSITMDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSITMDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSITMDEF.UPDATE_TIME));

        CDB_update_cmmsitmdef(1, &CMMSITMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSITMDEF UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSITMDEF.FACTORY), CMMSITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF.ITEM_CODE), CMMSITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {		
		//Log 기록을 위한 Update User/Time 바인딩 
		TRS.copy(CMMSITMDEF.UPDATE_USER_ID, sizeof(CMMSITMDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSITMDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSITMDEF.UPDATE_TIME));
        CDB_delete_cmmsitmdef(1, &CMMSITMDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSITMDEF DELETE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSITMDEF.FACTORY), CMMSITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF.ITEM_CODE), CMMSITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

	/*  Add History Log  */
	CDB_init_cmmsitmhis(&CMMSITMHIS);
	memcpy(CMMSITMHIS.FACTORY, CMMSITMDEF.FACTORY, sizeof(CMMSITMHIS.FACTORY));
	memcpy(CMMSITMHIS.ITEM_CODE, CMMSITMDEF.ITEM_CODE, sizeof(CMMSITMHIS.ITEM_CODE));
	CMMSITMHIS.HIST_SEQ = (int)CDB_select_cmmsitmhis_scalar(2, &CMMSITMHIS) + 1;
	memcpy(CMMSITMHIS.ITEM_NAME, CMMSITMDEF.ITEM_NAME, sizeof(CMMSITMHIS.ITEM_NAME));
	memcpy(CMMSITMHIS.ITEM_SPEC, CMMSITMDEF.ITEM_SPEC, sizeof(CMMSITMHIS.ITEM_SPEC));
	memcpy(CMMSITMHIS.ITEM_GROUP_CODE, CMMSITMDEF.ITEM_GROUP_CODE, sizeof(CMMSITMHIS.ITEM_GROUP_CODE));
	memcpy(CMMSITMHIS.TAG_NAME, CMMSITMDEF.TAG_NAME, sizeof(CMMSITMHIS.TAG_NAME));
	CMMSITMHIS.SPEC_TYPE = CMMSITMDEF.SPEC_TYPE;
	CMMSITMHIS.LSL = CMMSITMDEF.LSL;
	CMMSITMHIS.TARGET = CMMSITMDEF.TARGET;
	CMMSITMHIS.USL = CMMSITMDEF.USL;
	CMMSITMHIS.LCL = CMMSITMDEF.LCL;
	CMMSITMHIS.UCL = CMMSITMDEF.UCL;
	memcpy(CMMSITMHIS.UNIT_CODE, CMMSITMDEF.UNIT_CODE, sizeof(CMMSITMHIS.UNIT_CODE));
	CMMSITMHIS.DECIMAL_PLACE = CMMSITMDEF.DECIMAL_PLACE;
	CMMSITMHIS.USE_FLAG = CMMSITMDEF.USE_FLAG;
	CMMSITMHIS.DELETE_FLAG = CMMSITMDEF.DELETE_FLAG;
	memcpy(CMMSITMHIS.CREATE_USER_ID, CMMSITMDEF.CREATE_USER_ID, sizeof(CMMSITMHIS.CREATE_USER_ID));
    memcpy(CMMSITMHIS.CREATE_TIME, CMMSITMDEF.CREATE_TIME, sizeof(CMMSITMHIS.CREATE_TIME));
	memcpy(CMMSITMHIS.UPDATE_USER_ID, CMMSITMDEF.UPDATE_USER_ID, sizeof(CMMSITMHIS.UPDATE_USER_ID));
    memcpy(CMMSITMHIS.UPDATE_TIME, CMMSITMDEF.UPDATE_TIME, sizeof(CMMSITMHIS.UPDATE_TIME));

	CDB_insert_cmmsitmhis(&CMMSITMHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSITMHIS INSERT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSITMHIS.FACTORY), CMMSITMHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMHIS.ITEM_CODE), CMMSITMHIS.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Item_Validation()
        - Main sub function of "CMMS_UPDATE_ITEM" function
        - Check the condition for create/update/delete Item
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSITMDEF_TAG CMMSITMDEF;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    /* ITEM_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsitmdef(&CMMSITMDEF);
	TRS.copy(CMMSITMDEF.FACTORY, sizeof(CMMSITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSITMDEF.ITEM_CODE, sizeof(CMMSITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cmmsitmdef(1, &CMMSITMDEF);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0010"); //MMS-0010 : The data is already exist.
            TRS.add_fieldmsg(out_node, "CMMSITMDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSITMDEF.FACTORY), CMMSITMDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF.ITEM_CODE), CMMSITMDEF.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		TRS.set_char(in_node, "DELETE_FLAG", 'N');
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "MMS-0011"); //MMS-0011 : The data is not exist.
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "MMS-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CMMSITMDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF.ITEM_CODE), CMMSITMDEF.ITEM_CODE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

