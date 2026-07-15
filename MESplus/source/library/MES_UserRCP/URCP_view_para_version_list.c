/*******************************************************************************

    System      : MESplus
    Module      : User Routine for RCP
    File Name   : URCP_view_para_version_list.c
    Description : User Routine for URCP_View_Para_Version_List

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

int RCP_View_Para_Version_List_Before_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    return MP_TRUE;
}

int RCP_View_Para_Version_List_After_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    struct MRCPPRAVER_TAG MRCPPRAVER;
    int i_step = 0;
    char s_msg_code[MP_SIZE_MSG];
    TRSNode *list_item;

    i_step = 2;

    DBC_init_mrcppraver(&MRCPPRAVER);
    TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
    TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "RECIPE");
    MRCPPRAVER.RECIPE_VERSION  = TRS.get_int(in_node, "RECIPE_VERSION");

    DBC_open_mrcppraver(i_step, &MRCPPRAVER);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "RCP-0004");
        TRS.add_fieldmsg(out_node, "MRCPPRAVER OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
        TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
        TRS.add_fieldmsg(out_node, "RECIPE_VERSION", MP_INT, MRCPPRAVER.RECIPE_VERSION);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_mrcppraver(i_step, &MRCPPRAVER);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            DBC_close_mrcppraver(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RCP-0004");
            TRS.add_fieldmsg(out_node, "MRCPPRAVER FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPPRAVER.FACTORY), MRCPPRAVER.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPPRAVER.RES_ID), MRCPPRAVER.RES_ID);
            TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPPRAVER.RECIPE), MRCPPRAVER.RECIPE);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mrcppraver(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        list_item = TRS.add_node(out_node, "URCP_PARA_LIST");

        TRS.add_int(list_item, "PARA_SEQ", MRCPPRAVER.PARA_SEQ);
        TRS.add_string(list_item, "PARA_ID", MRCPPRAVER.PARA_ID, sizeof(MRCPPRAVER.PARA_ID));
        TRS.add_string(list_item, "PARA_VALUE", MRCPPRAVER.PARA_VALUE, sizeof(MRCPPRAVER.PARA_VALUE));
        TRS.add_string(list_item, "PARA_DESC", MRCPPRAVER.PARA_DESC, sizeof(MRCPPRAVER.PARA_DESC));
        TRS.add_char(list_item, "MODIFY_FLAG", MRCPPRAVER.MODIFY_FLAG);
        
        TRS.add_double(list_item, "CUS_MIN_VAL", MRCPPRAVER.CUS_MIN_VAL);
        TRS.add_double(list_item, "CUS_MAX_VAL", MRCPPRAVER.CUS_MAX_VAL);
        TRS.add_string(list_item, "CUS_UNIT", MRCPPRAVER.CUS_UNIT, sizeof(MRCPPRAVER.CUS_UNIT));

        TRS.add_enc_string(list_item, "CREATE_USER_ID", MRCPPRAVER.CREATE_USER_ID, sizeof(MRCPPRAVER.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", MRCPPRAVER.CREATE_TIME, sizeof(MRCPPRAVER.CREATE_TIME));
        TRS.add_enc_string(list_item, "UPDATE_USER_ID", MRCPPRAVER.UPDATE_USER_ID, sizeof(MRCPPRAVER.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", MRCPPRAVER.UPDATE_TIME, sizeof(MRCPPRAVER.UPDATE_TIME));
    }


    return MP_TRUE;
}

