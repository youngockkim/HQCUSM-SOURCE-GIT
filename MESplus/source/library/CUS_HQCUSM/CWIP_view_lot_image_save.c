/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_lot_image_save.c
    Description : View lot_image_save function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_lot_image_save()
            + View lot_image_save definition
        - CWIP_VIEW_LOT_IMAGE_SAVE()
            + Main sub function of CWIP_View_lot_image_save function
            + View lot_image_save definition
    Detail Description
        - CWIP_VIEW_LOT_IMAGE_SAVE()
            + h_proc_step
                + 1 : View lot_image_save definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-09-02             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_lot_image_save()
        - View lot_image_save definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_lot_image_save(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_LOT_IMAGE_SAVE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_LOT_IMAGE_SAVE", out_node);

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
    CWIP_VIEW_LOT_IMAGE_SAVE()
        - Main sub function of "CWIP_View_lot_image_save" function
        - View lot_image_save definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LOT_IMAGE_SAVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPLOTIMG_TAG CWIPLOTIMG;

    LOG_head("CWIP_VIEW_LOT_IMAGE_SAVE");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("image_type", MP_NSTR, TRS.get_string(in_node, "IMAGE_TYPE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_lot_image_save",
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
    /* LOT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
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
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiplotimg(&CWIPLOTIMG);
    TRS.copy(CWIPLOTIMG.FACTORY, sizeof(CWIPLOTIMG.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTIMG.LOT_ID, sizeof(CWIPLOTIMG.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CWIPLOTIMG.IMAGE_TYPE, sizeof(CWIPLOTIMG.IMAGE_TYPE), in_node, "IMAGE_TYPE");
    CDB_select_cwiplotimg(1, &CWIPLOTIMG);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-9999");
        TRS.add_fieldmsg(out_node, "CWIPLOTIMG SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPLOTIMG.FACTORY), CWIPLOTIMG.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTIMG.LOT_ID), CWIPLOTIMG.LOT_ID);
        TRS.add_fieldmsg(out_node, "IMAGE_TYPE", MP_STR, sizeof(CWIPLOTIMG.IMAGE_TYPE), CWIPLOTIMG.IMAGE_TYPE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CWIPLOTIMG.FACTORY, sizeof(CWIPLOTIMG.FACTORY));
    TRS.add_string(out_node, "LOT_ID", CWIPLOTIMG.LOT_ID, sizeof(CWIPLOTIMG.LOT_ID));
    TRS.add_string(out_node, "IMAGE_TYPE", CWIPLOTIMG.IMAGE_TYPE, sizeof(CWIPLOTIMG.IMAGE_TYPE));
    TRS.add_string(out_node, "IMAGE_PATH", CWIPLOTIMG.IMAGE_PATH, sizeof(CWIPLOTIMG.IMAGE_PATH));
    TRS.add_string(out_node, "CMF_1", CWIPLOTIMG.CMF_1, sizeof(CWIPLOTIMG.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPLOTIMG.CMF_2, sizeof(CWIPLOTIMG.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPLOTIMG.CMF_3, sizeof(CWIPLOTIMG.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPLOTIMG.CMF_4, sizeof(CWIPLOTIMG.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPLOTIMG.CMF_5, sizeof(CWIPLOTIMG.CMF_5));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPLOTIMG.CREATE_USER_ID, sizeof(CWIPLOTIMG.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPLOTIMG.CREATE_TIME, sizeof(CWIPLOTIMG.CREATE_TIME));
    TRS.add_string(out_node, "UPDATE_USER_ID", CWIPLOTIMG.UPDATE_USER_ID, sizeof(CWIPLOTIMG.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", CWIPLOTIMG.UPDATE_TIME, sizeof(CWIPLOTIMG.UPDATE_TIME));

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_lot_image_save",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

