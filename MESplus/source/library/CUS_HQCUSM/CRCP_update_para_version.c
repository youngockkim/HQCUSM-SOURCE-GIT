/*******************************************************************************

    System      : MESplus
    Module      : RCP
    File Name   : CRCP_update_para_version.c
    Description : Update parameter version

    MES Version : 4.0.0

    Function List
        - RCP_Update_Para_Version_version()
        - RCP_Update_Para_Version_Version_Main()

    Detail Description

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1  

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "RCPCore_common.h"

/* Skeleton RCP_Update_Para_Version */
int CRCP_Update_Para_Version(
                TRSNode *in_node, 
                TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRCP_UPDATE_PARA_VERSION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRCP_UPDATE_PARA_VERSION", out_node);

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

int CRCP_UPDATE_PARA_VERSION(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node)
{
    struct MRCPRCPDEF_TAG MRCPRCPDEF;
    struct MRCPRCPVER_TAG MRCPRCPVER;
    struct MRCPPRAVER_TAG MRCPPRAVER;
    struct MRASRESDEF_TAG MRASRESDEF;

    char s_sys_time[14];

    LOG_head("CRCP_Update_Para_Version");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("subres_id", MP_NSTR, TRS.get_string(in_node, "SUBRES_ID"));
    LOG_add("recipe", MP_NSTR, TRS.get_string(in_node, "RECIPE"));
    LOG_add("recipe_version", MP_INT, TRS.get_int(in_node, "RECIPE_VERSION"));
    LOG_add("para_seq", MP_INT, TRS.get_int(in_node, "PARA_SEQ"));
    LOG_add("para_id", MP_NSTR, TRS.get_string(in_node, "PARA_ID"));
    LOG_add("para_value", MP_NSTR, TRS.get_string(in_node, "PARA_VALUE"));
    LOG_add("para_desc", MP_NSTR, TRS.get_string(in_node, "PARA_DESC"));
    LOG_add("modify_flag", MP_CHR, TRS.get_char(in_node, "MODIFY_FLAG"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);


    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "RCP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);


        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Resource Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "RCP-0001");
        TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Recipe Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "RECIPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "RCP-0001");
        TRS.add_fieldmsg(out_node, "RECIPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Recipe Version Validation */
    if(TRS.get_int(in_node, "RECIPE_VERSION") <= 0 || TRS.get_int(in_node, "RECIPE_VERSION") >= 10000) 
    {
        strcpy(s_msg_code, "RCP-0001");
        TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Recipe Para Sequence Validation */
    if(TRS.get_int(in_node, "PARA_SEQ") <= 0) 
    {
        strcpy(s_msg_code, "RCP-0001");
        TRS.add_fieldmsg(out_node, "PARA_SEQ", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Para_id Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "PARA_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "RCP-0001");
        TRS.add_fieldmsg(out_node, "PARA_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

   /* approval_require_flag Validation */
    if(TRS.get_char(in_node, "MODIFY_FLAG") != 'Y' && TRS.get_char(in_node, "MODIFY_FLAG") != ' ') 
    {
        strcpy(s_msg_code, "RCP-0014");
        TRS.add_fieldmsg(out_node, "MODIFY_FLAG", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RCP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mrasresdef(&MRASRESDEF);
    TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
    DBC_select_mrasresdef( 1, &MRASRESDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "RAS-0003");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
        else
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
    }

    DBC_init_mrcprcpdef(&MRCPRCPDEF);
    TRS.copy(MRCPRCPDEF.FACTORY, sizeof(MRCPRCPDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRCPRCPDEF.RES_ID, sizeof(MRCPRCPDEF.RES_ID), in_node, "RES_ID");
    TRS.copy(MRCPRCPDEF.RECIPE, sizeof(MRCPRCPDEF.RECIPE), in_node, "RECIPE");

    DBC_select_mrcprcpdef_for_update( 1, &MRCPRCPDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "RCP-0005");
            TRS.add_fieldmsg(out_node, "MRCPRCPDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPRCPDEF.FACTORY), MRCPRCPDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPRCPDEF.RES_ID), MRCPRCPDEF.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPRCPDEF.RECIPE), MRCPRCPDEF.RECIPE);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;   
        }
        else
        {
            strcpy(s_msg_code, "RCP-0004");
            TRS.add_fieldmsg(out_node, "MRCPRCPDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPRCPDEF.FACTORY), MRCPRCPDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPRCPDEF.RES_ID), MRCPRCPDEF.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPRCPDEF.RECIPE), MRCPRCPDEF.RECIPE);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
    }


    DBC_init_mrcprcpver(&MRCPRCPVER);
    TRS.copy(MRCPRCPVER.FACTORY, sizeof(MRCPRCPVER.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRCPRCPVER.RES_ID, sizeof(MRCPRCPVER.RES_ID), in_node, "RES_ID");
    TRS.copy(MRCPRCPVER.RECIPE, sizeof(MRCPRCPVER.RECIPE), in_node, "RECIPE");
    MRCPRCPVER.RECIPE_VERSION  = TRS.get_int(in_node, "RECIPE_VERSION");

    DBC_select_mrcprcpver( 1, &MRCPRCPVER);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "RCP-0029");
            TRS.add_fieldmsg(out_node, "MRCPRCPVER SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPRCPVER.FACTORY), MRCPRCPVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPRCPVER.RES_ID), MRCPRCPVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPRCPVER.RECIPE), MRCPRCPVER.RECIPE);
            TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPRCPVER.RECIPE_VERSION);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;   
        }
        else
        {
            strcpy(s_msg_code, "RCP-0004");
            TRS.add_fieldmsg(out_node, "MRCPRCPVER SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPRCPVER.FACTORY), MRCPRCPVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPRCPVER.RES_ID), MRCPRCPVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPRCPVER.RECIPE), MRCPRCPVER.RECIPE);
            TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPRCPVER.RECIPE_VERSION);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
    }

    //승인이나 릴리즈 된것은 추가,수정,삭제 할 수 없다.
    if(MRCPRCPVER.APPROVAL_FLAG == 'Y' || MRCPRCPVER.RELEASE_FLAG == 'Y')
    {
        strcpy(s_msg_code, "RCP-0031");
        TRS.add_fieldmsg(out_node, "APPROVAL_FLAG", MP_CHR, MRCPRCPVER.APPROVAL_FLAG);
        TRS.add_fieldmsg(out_node, "RELEASE_FLAG", MP_CHR, MRCPRCPVER.RELEASE_FLAG);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;   
    }

    DBC_init_mrcppraver(&MRCPPRAVER);
    TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
    TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "RECIPE");
    MRCPPRAVER.RECIPE_VERSION  = TRS.get_int(in_node, "RECIPE_VERSION");
    MRCPPRAVER.PARA_SEQ  = TRS.get_int(in_node, "PARA_SEQ");

    DBC_select_mrcppraver( 1, &MRCPPRAVER);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
           if(TRS.get_procstep(in_node) == MP_STEP_UPDATE ||TRS.get_procstep(in_node) == MP_STEP_DELETE ) 
            {
                strcpy(s_msg_code, "RCP-0037");
                TRS.add_fieldmsg(out_node, "MRCPPRAVER SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
                TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
                TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
                TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
                TRS.add_fieldmsg(out_node, "PARA_SEQ", MP_INT, MRCPPRAVER.PARA_SEQ);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else
        {
            strcpy(s_msg_code, "RCP-0004");
            TRS.add_fieldmsg(out_node, "MRCPPRAVER SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
            TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
            TRS.add_fieldmsg(out_node, "PARA_SEQ", MP_INT, MRCPPRAVER.PARA_SEQ);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
    }
    else
    {
        if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
            strcpy(s_msg_code, "RCP-0038");
            TRS.add_fieldmsg(out_node, "MRCPPRAVER SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
            TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
            TRS.add_fieldmsg(out_node, "PARA_SEQ", MP_INT, MRCPPRAVER.PARA_SEQ);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;              
        }
    }

    TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
    TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.SUBRES_ID), in_node, "SUBRES_ID");
    TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "RECIPE");
    MRCPPRAVER.RECIPE_VERSION  = TRS.get_int(in_node, "RECIPE_VERSION");
    MRCPPRAVER.PARA_SEQ  = TRS.get_int(in_node, "PARA_SEQ");
    TRS.copy(MRCPPRAVER.PARA_ID, sizeof(MRCPPRAVER.PARA_ID), in_node, "PARA_ID");
    TRS.copy(MRCPPRAVER.PARA_VALUE, sizeof(MRCPPRAVER.PARA_VALUE), in_node, "PARA_VALUE");
    TRS.copy(MRCPPRAVER.PARA_DESC, sizeof(MRCPPRAVER.PARA_DESC), in_node, "PARA_DESC");
    MRCPPRAVER.MODIFY_FLAG  = TRS.get_char(in_node, "MODIFY_FLAG");

    MRCPPRAVER.CUS_MIN_VAL = TRS.get_double(in_node, "CUS_MIN_VAL");
    MRCPPRAVER.CUS_MAX_VAL = TRS.get_double(in_node, "CUS_MAX_VAL");
    TRS.copy(MRCPPRAVER.CUS_UNIT, sizeof(MRCPPRAVER.CUS_UNIT), in_node, "CUS_UNIT");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        DBC_insert_mrcppraver(&MRCPPRAVER);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "RCP-0004");
            TRS.add_fieldmsg(out_node, "MRCPPRAVER INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
            TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
            TRS.add_fieldmsg(out_node, "PARA_SEQ", MP_INT, MRCPPRAVER.PARA_SEQ);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;   
        }
    }


    if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        TRS.copy(MRCPPRAVER.UPDATE_USER_ID, sizeof(MRCPPRAVER.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(MRCPPRAVER.UPDATE_TIME, s_sys_time, sizeof(MRCPPRAVER.UPDATE_TIME));

        DBC_update_mrcppraver( 1, &MRCPPRAVER);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "RCP-0004");
            TRS.add_fieldmsg(out_node, "MRCPPRAVER UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
            TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
            TRS.add_fieldmsg(out_node, "PARA_SEQ", MP_INT, MRCPPRAVER.PARA_SEQ);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;   
        }
    }


    if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {

        DBC_delete_mrcppraver( 1, &MRCPPRAVER);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "RCP-0004");
            TRS.add_fieldmsg(out_node, "MRCPPRAVER DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
            TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
            TRS.add_fieldmsg(out_node, "PARA_SEQ", MP_INT, MRCPPRAVER.PARA_SEQ);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;   
        }
    }

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


