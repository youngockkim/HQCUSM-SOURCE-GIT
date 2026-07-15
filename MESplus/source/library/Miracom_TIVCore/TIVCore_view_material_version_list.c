/*******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : TIV_view_material_version_list.c
    Description : View material version list

    MES Version : 4.2.0

    Function List
        - TIV_View_Material_Version_List()
            + View Material Version List
        - TIV_VIEW_MATERIAL_VERSION_LIST()
            + Main sub function of "TIV_View_Material_Version_List" function
            + View Material Version List

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2013/01/09  JJ.OH          Create        

    Copyright(C) 1998-2007 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

/*******************************************************************************
    TIV_View_Material_Version_List()
        - View Material Version List
    Return Value
        - Integer : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node :Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material_Version_List(TRSNode *in_node, 
                                   TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_MATERIAL_VERSION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_MATERIAL_VERSION_LIST", out_node);

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
    TIV_VIEW_MATERIAL_VERSION_LIST()
        - Main sub function of "TIV_View_Material_Version_List" function
        - View Material Version List
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_MATERIAL_VERSION_LIST(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node)
{
    struct MTIVMATDEF_TAG MTIVMATDEF;
    TRSNode *list_item;

    LOG_head("TIV_VIEW_MATERIAL_VERSION_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("mat_type", MP_NSTR, TRS.get_string(in_node, "MAT_TYPE"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("delete_flag", MP_CHR, TRS.get_char(in_node, "DELETE_FLAG"));
    LOG_add("deactive_flag", MP_CHR, TRS.get_char(in_node, "DEACTIVE_FLAG"));
    LOG_add("next_mat_ver", MP_INT, TRS.get_int(in_node, "NEXT_MAT_VER"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_Version_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
    TRS.copy(MTIVMATDEF.MAT_TYPE, sizeof(MTIVMATDEF.MAT_TYPE), in_node, "MAT_TYPE");
    MTIVMATDEF.MAT_VER  = TRS.get_int(in_node, "NEXT_MAT_VER");
    MTIVMATDEF.DELETE_FLAG  = TRS.get_char(in_node, "DELETE_FLAG");
    MTIVMATDEF.DEACTIVE_FLAG  = TRS.get_char(in_node, "DEACTIVE_FLAG");

    DBC_open_mtivmatdef(5, &MTIVMATDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVMATDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mtivmatdef(5, &MTIVMATDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwipmatdef(5);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "INV-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            DBC_close_mwipmatdef(5);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_int(out_node, "NEXT_MAT_VER", MTIVMATDEF.MAT_VER);
            DBC_close_mwipmatdef(5);
            break;
        }

        list_item = TRS.add_node(out_node, "LIST");

        TRS.add_string(list_item, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));
        TRS.add_string(list_item, "MAT_SHORT_DESC", MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC));
        TRS.add_int(list_item, "MAT_VER", MTIVMATDEF.MAT_VER);
        TRS.add_char(list_item, "DELETE_FLAG", MTIVMATDEF.DELETE_FLAG);
        TRS.add_char(list_item, "DEACTIVE_FLAG", MTIVMATDEF.DEACTIVE_FLAG);
    }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_Version_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

