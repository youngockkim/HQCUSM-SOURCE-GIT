/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_item.c
    Description : View Item function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Item()
            + View Item definition
        - CMMS_VIEW_ITEM()
            + Main sub function of CMMS_View_Item function
            + View Item definition
        - CMMS_View_Item_Validation()
            + Main sub function of CMMS_VIEW_ITEM function
            + Check the condition for view Item
    Detail Description
        - CMMS_VIEW_ITEM()
            + h_proc_step
                + 1 : View Item definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-08             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_View_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_View_Item()
        - View Item definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Item(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_ITEM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_ITEM", out_node);

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
    CMMS_VIEW_ITEM()
        - Main sub function of "CMMS_View_Item" function
        - View Item definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSITMDEF_TAG CMMSITMDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    LOG_head("CMMS_VIEW_ITEM");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Item",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    if(CMMS_View_Item_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsitmdef(&CMMSITMDEF);
	TRS.copy(CMMSITMDEF.FACTORY, sizeof(CMMSITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSITMDEF.ITEM_CODE, sizeof(CMMSITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cmmsitmdef(1, &CMMSITMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSITMDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF.ITEM_CODE), CMMSITMDEF.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	TRS.add_string(out_node, "FACTORY", CMMSITMDEF.FACTORY, sizeof(CMMSITMDEF.FACTORY));
    TRS.add_string(out_node, "ITEM_CODE", CMMSITMDEF.ITEM_CODE, sizeof(CMMSITMDEF.ITEM_CODE));
    TRS.add_string(out_node, "ITEM_NAME", CMMSITMDEF.ITEM_NAME, sizeof(CMMSITMDEF.ITEM_NAME));
    TRS.add_string(out_node, "ITEM_SPEC", CMMSITMDEF.ITEM_SPEC, sizeof(CMMSITMDEF.ITEM_SPEC));
    TRS.add_string(out_node, "ITEM_GROUP_CODE", CMMSITMDEF.ITEM_GROUP_CODE, sizeof(CMMSITMDEF.ITEM_GROUP_CODE));
    TRS.add_string(out_node, "TAG_NAME", CMMSITMDEF.TAG_NAME, sizeof(CMMSITMDEF.TAG_NAME));
    TRS.add_char(out_node, "SPEC_TYPE", CMMSITMDEF.SPEC_TYPE);
    TRS.add_double(out_node, "LSL", CMMSITMDEF.LSL);
    TRS.add_double(out_node, "TARGET", CMMSITMDEF.TARGET);
    TRS.add_double(out_node, "USL", CMMSITMDEF.USL);
    TRS.add_double(out_node, "LCL", CMMSITMDEF.LCL);
    TRS.add_double(out_node, "UCL", CMMSITMDEF.UCL);
    TRS.add_string(out_node, "UNIT_CODE", CMMSITMDEF.UNIT_CODE, sizeof(CMMSITMDEF.UNIT_CODE));
    TRS.add_int(out_node, "DECIMAL_PLACE", CMMSITMDEF.DECIMAL_PLACE);
    TRS.add_char(out_node, "USE_FLAG", CMMSITMDEF.USE_FLAG);
    TRS.add_char(out_node, "DELETE_FLAG", CMMSITMDEF.DELETE_FLAG);
    TRS.add_string(out_node, "CREATE_USER_ID", CMMSITMDEF.CREATE_USER_ID, sizeof(CMMSITMDEF.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CMMSITMDEF.CREATE_TIME, sizeof(CMMSITMDEF.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CMMSITMDEF.UPDATE_USER_ID, sizeof(CMMSITMDEF.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CMMSITMDEF.UPDATE_TIME, sizeof(CMMSITMDEF.UPDATE_TIME));

	//Item Group Description Á¶È¸
	DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, HQCEL_GCM_MMS_ITEM_GROUP, strlen(HQCEL_GCM_MMS_ITEM_GROUP));
	//memcpy(MGCMTBLDAT.TABLE_NAME, "MMS_ITEM_GROUP", strlen("MMS_ITEM_GROUP"));
    memcpy(MGCMTBLDAT.KEY_1, CMMSITMDEF.ITEM_GROUP_CODE, sizeof(MGCMTBLDAT.KEY_1));
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if(DB_error_code == DB_SUCCESS)
    {
        TRS.add_string(out_node, "ITEM_GROUP_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
    }



    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Item",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CMMS_View_Item_Validation()
        - Main sub function of "CMMS_VIEW_ITEM" function
        - Check the condition for view Item
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Item_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSITMDEF_TAG CMMSITMDEF;

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

    /* ITEM_CODE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "ITEM_CODE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001"); //MMS-0001 : This is required field. Please enter valid value.
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmsitmdef(&CMMSITMDEF);
	TRS.copy(CMMSITMDEF.FACTORY, sizeof(CMMSITMDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSITMDEF.ITEM_CODE, sizeof(CMMSITMDEF.ITEM_CODE), in_node, "ITEM_CODE");
    CDB_select_cmmsitmdef(1, &CMMSITMDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "MMS-0011"); // MMS-0011 : The data is not exist.
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "CMMSITMDEF SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSITMDEF.FACTORY), CMMSITMDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSITMDEF.ITEM_CODE), CMMSITMDEF.ITEM_CODE);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }

    return MP_TRUE;
}

