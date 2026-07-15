/*******************************************************************************

    System      : MESplus
    Module      : TIV
    File Name   : TIV_view_ship_factory.c
    Description : View Ship Factory related function module   

    MES Version : 4.0.0

    Function List
        - TIV_View_Ship_Factory()
            + View Ship Factory   
        - TIV_VIEW_SHIP_FACTORY()
            + Main Sub function of "TIV_View_Ship_Factory"
            + (called by "TIV_View_Ship_Factory")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/03  HS Kim         Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"

/*******************************************************************************
    TIV_View_Ship_Factory()                                                          
        - View Shipping Factory Infor                                                  
    Return Value                                                                  
        - int : 0 (MP_TRUE)                                            
    Arguments                                                                     
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure                       
*******************************************************************************/
int TIV_View_Ship_Factory(TRSNode *in_node, 
                          TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_SHIP_FACTORY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_SHIP_FACTORY", out_node);

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
    TIV_VIEW_SHIP_FACTORY()                                                     
        - Main sub function of "TIV_VIEW_SHIP_FACTORY" function               
    Return Value                                                                  
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)                                  
    Arguments                                                                     
        - char *s_msg_code : Error Message Code                                   
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure                       
*******************************************************************************/
int TIV_VIEW_SHIP_FACTORY(char *s_msg_code,
                         TRSNode *in_node,
                         TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MTIVFACSHP_TAG MTIVFACSHP;


    LOG_head("TIV_VIEW_SHIP_FACTORY");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("factory_to", MP_NSTR, TRS.get_string(in_node, "FACTORY_TO"));
    LOG_add("factory_from", MP_NSTR, TRS.get_string(in_node, "FACTORY_FROM"));
    LOG_add("transit_oper", MP_NSTR, TRS.get_string(in_node, "TRANSIT_OPER"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("TIV", "TIV_View_Ship_Factory",
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
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY_TO")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);

    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);

    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "WIP-0005");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivfacshp(&MTIVFACSHP);

    TRS.copy(MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO), in_node, "FACTORY_TO");
    TRS.copy(MTIVFACSHP.FACTORY_FROM, sizeof(MTIVFACSHP.FACTORY_FROM), in_node, IN_FACTORY);
    TRS.copy(MTIVFACSHP.TRANSIT_OPER, sizeof(MTIVFACSHP.TRANSIT_OPER), in_node, "TRANSIT_OPER");

    DBC_select_mtivfacshp(1, &MTIVFACSHP);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0097");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MTIVFACSHP SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
        TRS.add_fieldmsg(out_node, "FACTORY_FROM", MP_STR, sizeof(MTIVFACSHP.FACTORY_FROM), MTIVFACSHP.FACTORY_FROM);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", MTIVFACSHP.FACTORY_FROM, sizeof(MTIVFACSHP.FACTORY_FROM));
    TRS.add_string(out_node, "FACTORY_TO", MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO));
    TRS.add_char(out_node, "AUTO_TERM_FLAG", MTIVFACSHP.AUTO_TERM_FLAG);
    TRS.add_string(out_node, "TRANSIT_OPER", MTIVFACSHP.TRANSIT_OPER, sizeof(MTIVFACSHP.TRANSIT_OPER));
    //Add by J.S. 2009.03.05 fro remote shipping
    TRS.add_char(out_node, "REMOTE_FLAG", MTIVFACSHP.REMOTE_FLAG);
    TRS.add_string(out_node, "SHIP_CMF_1", MTIVFACSHP.SHIP_CMF_1, sizeof(MTIVFACSHP.SHIP_CMF_1));
    TRS.add_string(out_node, "SHIP_CMF_2", MTIVFACSHP.SHIP_CMF_2, sizeof(MTIVFACSHP.SHIP_CMF_2));
    TRS.add_string(out_node, "SHIP_CMF_3", MTIVFACSHP.SHIP_CMF_3, sizeof(MTIVFACSHP.SHIP_CMF_3));
    TRS.add_string(out_node, "SHIP_CMF_4", MTIVFACSHP.SHIP_CMF_4, sizeof(MTIVFACSHP.SHIP_CMF_4));
    TRS.add_string(out_node, "SHIP_CMF_5", MTIVFACSHP.SHIP_CMF_5, sizeof(MTIVFACSHP.SHIP_CMF_5));
    TRS.add_string(out_node, "SHIP_CMF_6", MTIVFACSHP.SHIP_CMF_6, sizeof(MTIVFACSHP.SHIP_CMF_6));
    TRS.add_string(out_node, "SHIP_CMF_7", MTIVFACSHP.SHIP_CMF_7, sizeof(MTIVFACSHP.SHIP_CMF_7));
    TRS.add_string(out_node, "SHIP_CMF_8", MTIVFACSHP.SHIP_CMF_8, sizeof(MTIVFACSHP.SHIP_CMF_8));
    TRS.add_string(out_node, "SHIP_CMF_9", MTIVFACSHP.SHIP_CMF_9, sizeof(MTIVFACSHP.SHIP_CMF_9));
    TRS.add_string(out_node, "SHIP_CMF_10", MTIVFACSHP.SHIP_CMF_10, sizeof(MTIVFACSHP.SHIP_CMF_10));
    TRS.add_string(out_node, "SHIP_CMF_11", MTIVFACSHP.SHIP_CMF_11, sizeof(MTIVFACSHP.SHIP_CMF_11));
    TRS.add_string(out_node, "SHIP_CMF_12", MTIVFACSHP.SHIP_CMF_12, sizeof(MTIVFACSHP.SHIP_CMF_12));
    TRS.add_string(out_node, "SHIP_CMF_13", MTIVFACSHP.SHIP_CMF_13, sizeof(MTIVFACSHP.SHIP_CMF_13));
    TRS.add_string(out_node, "SHIP_CMF_14", MTIVFACSHP.SHIP_CMF_14, sizeof(MTIVFACSHP.SHIP_CMF_14));
    TRS.add_string(out_node, "SHIP_CMF_15", MTIVFACSHP.SHIP_CMF_15, sizeof(MTIVFACSHP.SHIP_CMF_15));
    TRS.add_string(out_node, "SHIP_CMF_16", MTIVFACSHP.SHIP_CMF_16, sizeof(MTIVFACSHP.SHIP_CMF_16));
    TRS.add_string(out_node, "SHIP_CMF_17", MTIVFACSHP.SHIP_CMF_17, sizeof(MTIVFACSHP.SHIP_CMF_17));
    TRS.add_string(out_node, "SHIP_CMF_18", MTIVFACSHP.SHIP_CMF_18, sizeof(MTIVFACSHP.SHIP_CMF_18));
    TRS.add_string(out_node, "SHIP_CMF_19", MTIVFACSHP.SHIP_CMF_19, sizeof(MTIVFACSHP.SHIP_CMF_19));
    TRS.add_string(out_node, "SHIP_CMF_20", MTIVFACSHP.SHIP_CMF_20, sizeof(MTIVFACSHP.SHIP_CMF_20));
    TRS.add_enc_string(out_node, "CREATE_USER_ID", MTIVFACSHP.CREATE_USER_ID, sizeof(MTIVFACSHP.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", MTIVFACSHP.CREATE_TIME, sizeof(MTIVFACSHP.CREATE_TIME));
    TRS.add_enc_string(out_node, "UPDATE_USER_ID", MTIVFACSHP.UPDATE_USER_ID, sizeof(MTIVFACSHP.UPDATE_USER_ID));
    TRS.add_string(out_node, "UPDATE_TIME", MTIVFACSHP.UPDATE_TIME, sizeof(MTIVFACSHP.UPDATE_TIME));


    if(COM_proc_user_routine("TIV", "TIV_View_Ship_Factory",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

