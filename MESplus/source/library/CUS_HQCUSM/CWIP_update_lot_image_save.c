/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_lot_image_save.c
    Description : lot_image_save Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_lot_image_save()
            + Create/Update/Delete lot_image_save definition
        - CWIP_UPDATE_LOT_IMAGE_SAVE()
            + Main sub function of CWIP_Update_lot_image_save function
            + Create/Update/Delete lot_image_save definition
        - CWIP_Update_lot_image_save_Validation()
            + Main sub function of CWIP_UPDATE_LOT_IMAGE_SAVE function
            + Check the condition for create/update/delete lot_image_save
    Detail Description
        - CWIP_UPDATE_LOT_IMAGE_SAVE()
            + h_proc_step
                + MP_STEP_CREATE : Create lot_image_save definition
                + MP_STEP_UPDATE : Update lot_image_save definition
                + MP_STEP_DELETE : Delete lot_image_save definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-09-02             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_lot_image_save_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_lot_image_save()
        - Create/Update/Delete lot_image_save definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_lot_image_save(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_LOT_IMAGE_SAVE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_LOT_IMAGE_SAVE", out_node);

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
    CWIP_UPDATE_LOT_IMAGE_SAVE()
        - Main sub function of "CWIP_Update_lot_image_save" function
        - Create/Update/Delete lot_image_save definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_LOT_IMAGE_SAVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTIMG_TAG CWIPLOTIMG;
    struct CWIPLOTIMG_TAG CWIPLOTIMG_o;
    char   s_sys_time[14];

    LOG_head("CWIP_UPDATE_LOT_IMAGE_SAVE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("image_type", MP_NSTR, TRS.get_string(in_node, "IMAGE_TYPE"));
    LOG_add("image_path", MP_NSTR, TRS.get_string(in_node, "IMAGE_PATH"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_lot_image_save",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
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

    if(CWIP_Update_lot_image_save_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplotimg(&CWIPLOTIMG);
    TRS.copy(CWIPLOTIMG.FACTORY, sizeof(CWIPLOTIMG.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTIMG.LOT_ID, sizeof(CWIPLOTIMG.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CWIPLOTIMG.IMAGE_TYPE, sizeof(CWIPLOTIMG.IMAGE_TYPE), in_node, "IMAGE_TYPE");
    TRS.copy(CWIPLOTIMG.IMAGE_PATH, sizeof(CWIPLOTIMG.IMAGE_PATH), in_node, "IMAGE_PATH");
    TRS.copy(CWIPLOTIMG.CMF_1, sizeof(CWIPLOTIMG.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPLOTIMG.CMF_2, sizeof(CWIPLOTIMG.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPLOTIMG.CMF_3, sizeof(CWIPLOTIMG.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPLOTIMG.CMF_4, sizeof(CWIPLOTIMG.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPLOTIMG.CMF_5, sizeof(CWIPLOTIMG.CMF_5), in_node, "CMF_5");
    TRS.copy(CWIPLOTIMG.CREATE_USER_ID, sizeof(CWIPLOTIMG.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPLOTIMG.CREATE_TIME, sizeof(CWIPLOTIMG.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPLOTIMG.UPDATE_USER_ID, sizeof(CWIPLOTIMG.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPLOTIMG.UPDATE_TIME, sizeof(CWIPLOTIMG.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CWIPLOTIMG.CREATE_USER_ID, sizeof(CWIPLOTIMG.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPLOTIMG.CREATE_TIME, s_sys_time, sizeof(CWIPLOTIMG.CREATE_TIME));
        CDB_insert_cwiplotimg(&CWIPLOTIMG);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTIMG INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTIMG.FACTORY), CWIPLOTIMG.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTIMG.LOT_ID), CWIPLOTIMG.LOT_ID);
            TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_STR, sizeof(CWIPLOTIMG.IMAGE_TYPE), CWIPLOTIMG.IMAGE_TYPE);
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
        CDB_init_cwiplotimg(&CWIPLOTIMG_o);
        TRS.copy(CWIPLOTIMG_o.FACTORY, sizeof(CWIPLOTIMG_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CWIPLOTIMG_o.LOT_ID, sizeof(CWIPLOTIMG_o.LOT_ID), in_node, "LOT_ID");
        TRS.copy(CWIPLOTIMG_o.IMAGE_TYPE, sizeof(CWIPLOTIMG_o.IMAGE_TYPE), in_node, "IMAGE_TYPE");
        CDB_select_cwiplotimg_for_update(1, &CWIPLOTIMG_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTIMG SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTIMG_o.FACTORY), CWIPLOTIMG_o.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTIMG_o.LOT_ID), CWIPLOTIMG_o.LOT_ID);
            TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_STR, sizeof(CWIPLOTIMG_o.IMAGE_TYPE), CWIPLOTIMG_o.IMAGE_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CWIPLOTIMG.CREATE_USER_ID, CWIPLOTIMG_o.CREATE_USER_ID, sizeof(CWIPLOTIMG.CREATE_USER_ID));
        memcpy(CWIPLOTIMG.CREATE_TIME, CWIPLOTIMG_o.CREATE_TIME, sizeof(CWIPLOTIMG.CREATE_TIME));
        TRS.copy(CWIPLOTIMG.UPDATE_USER_ID, sizeof(CWIPLOTIMG.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPLOTIMG.UPDATE_TIME, s_sys_time, sizeof(CWIPLOTIMG.UPDATE_TIME));

        CDB_update_cwiplotimg(1, &CWIPLOTIMG);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTIMG UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTIMG.FACTORY), CWIPLOTIMG.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTIMG.LOT_ID), CWIPLOTIMG.LOT_ID);
            TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_STR, sizeof(CWIPLOTIMG.IMAGE_TYPE), CWIPLOTIMG.IMAGE_TYPE);
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
        CDB_delete_cwiplotimg(1, &CWIPLOTIMG);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPLOTIMG DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTIMG.FACTORY), CWIPLOTIMG.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTIMG.LOT_ID), CWIPLOTIMG.LOT_ID);
            TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_STR, sizeof(CWIPLOTIMG.IMAGE_TYPE), CWIPLOTIMG.IMAGE_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_lot_image_save",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Update_lot_image_save_Validation()
        - Main sub function of "CWIP_UPDATE_LOT_IMAGE_SAVE" function
        - Check the condition for create/update/delete lot_image_save
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_lot_image_save_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTIMG_TAG CWIPLOTIMG;
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
        strcpy(s_msg_code, "CWIP-0001");
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

    /* LOT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* IMAGE_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "IMAGE_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplotimg(&CWIPLOTIMG);
    TRS.copy(CWIPLOTIMG.FACTORY, sizeof(CWIPLOTIMG.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTIMG.LOT_ID, sizeof(CWIPLOTIMG.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CWIPLOTIMG.IMAGE_TYPE, sizeof(CWIPLOTIMG.IMAGE_TYPE), in_node, "IMAGE_TYPE");
    CDB_select_cwiplotimg(1, &CWIPLOTIMG);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-XXXX");
            TRS.add_fieldmsg(out_node, "CWIPLOTIMG SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTIMG.FACTORY), CWIPLOTIMG.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTIMG.LOT_ID), CWIPLOTIMG.LOT_ID);
            TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_STR, sizeof(CWIPLOTIMG.IMAGE_TYPE), CWIPLOTIMG.IMAGE_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "CWIP-XXXX");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "CWIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CWIPLOTIMG SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTIMG.FACTORY), CWIPLOTIMG.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTIMG.LOT_ID), CWIPLOTIMG.LOT_ID);
            TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_STR, sizeof(CWIPLOTIMG.IMAGE_TYPE), CWIPLOTIMG.IMAGE_TYPE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

