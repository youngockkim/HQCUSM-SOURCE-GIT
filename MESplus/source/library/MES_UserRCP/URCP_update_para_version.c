/*******************************************************************************

    System      : MESplus
    Module      : User Routine for RCP
    File Name   : URCP_update_para_version.c
    Description : User Routine for Update_Para_Version

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/11/10  Miracom        Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "URCP_common.h"
#include "CUS_common.h"

int RCP_Update_Para_Version_Before_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    return MP_TRUE;
}

int RCP_Update_Para_Version_After_1(TRSNode *in_node, TRSNode *out_node)
{
    /*
    struct MRCPPRAVER_TAG MRCPPRAVER;
    char s_msg_code[MP_SIZE_MSG];
    char s_sys_time[14];

    if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        return MP_TRUE;
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

    CDB_init_mrcppraver(&MRCPPRAVER);
    TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
    TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "RECIPE");
    MRCPPRAVER.RECIPE_VERSION  = TRS.get_int(in_node, "RECIPE_VERSION");
    MRCPPRAVER.PARA_SEQ  = TRS.get_int(in_node, "PARA_SEQ");

    CDB_select_mrcppraver(1, &MRCPPRAVER);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            if(TRS.get_procstep(in_node) == MP_STEP_CREATE || TRS.get_procstep(in_node) == MP_STEP_UPDATE)
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

    TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
    TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.SUBRES_ID), in_node, "SUBRES_ID");
    TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "RECIPE");
    MRCPPRAVER.RECIPE_VERSION  = TRS.get_int(in_node, "RECIPE_VERSION");
    MRCPPRAVER.PARA_SEQ  = TRS.get_int(in_node, "PARA_SEQ");
    
    TRS.copy(MRCPPRAVER.PARA_VALUE, sizeof(MRCPPRAVER.PARA_VALUE), in_node, "PARA_VALUE");
    MRCPPRAVER.CUS_MIN_VAL = TRS.get_double(in_node, "CUS_MIN_VAL");
    MRCPPRAVER.CUS_MAX_VAL = TRS.get_double(in_node, "CUS_MAX_VAL");
    TRS.copy(MRCPPRAVER.CUS_UNIT, sizeof(MRCPPRAVER.CUS_UNIT), in_node, "CUS_UNIT");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE || TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        //TRS.copy(MRCPPRAVER.UPDATE_USER_ID, sizeof(MRCPPRAVER.UPDATE_USER_ID), in_node, IN_USERID);
        //memcpy(MRCPPRAVER.UPDATE_TIME, s_sys_time, sizeof(MRCPPRAVER.UPDATE_TIME));

        CDB_update_mrcppraver(1, &MRCPPRAVER);
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
    */

    return MP_TRUE;
}

