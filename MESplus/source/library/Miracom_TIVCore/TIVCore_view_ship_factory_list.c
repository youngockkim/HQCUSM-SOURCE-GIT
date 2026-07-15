/*******************************************************************************

    System      : MESplus
    Module      : TIV
    File Name   : TIV_view_ship_factory_list.c
    Description : View Shipping Factory List related function module   

    MES Version : 4.0.0

    Function List
        - TIV_View_Ship_Factory_List()
            + View Shipping Factory List   
        - TIV_VIEW_SHIP_FACTORY_LIST()
            + Main Sub function of "TIV_View_Ship_Factory_List"
            + (called by "TIV_View_Ship_Factory_List")
        - TIV_View_Ship_Factory_List_Validation()                               
            + Validation check sub function of "TIV_VIEW_SHIP_FACTORY_LIST"
            + (called by "TIV_VIEW_SHIP_FACTORY_LIST") 

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
    TIV_View_Ship_Factory_List()                                                          
        - View All shipping Factory List                                                 
    Return Value                                                                  
        - int : 0 (MP_TRUE)                                            
    Arguments                                                                     
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure                       
*******************************************************************************/
int TIV_View_Ship_Factory_List(TRSNode *in_node, 
                               TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_SHIP_FACTORY_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_SHIP_FACTORY_LIST", out_node);

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
    TIV_VIEW_SHIP_FACTORY_LIST()                                                     
        - Main sub function of "TIV_VIEW_SHIP_FACTORY_LIST" function               
    Return Value                                                                  
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)                                  
    Arguments                                                                     
        - char *s_msg_code : Error Message Code                                   
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure                       
*******************************************************************************/
int TIV_VIEW_SHIP_FACTORY_LIST(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct MTIVFACSHP_TAG MTIVFACSHP;
    TRSNode *list_item;

    LOG_head("TIV_VIEW_SHIP_FACTORY_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("factory_from", MP_NSTR, TRS.get_string(in_node, "FACTORY_FROM"));
    LOG_add("next_factory_to", MP_NSTR, TRS.get_string(in_node, "NEXT_FACTORY_TO"));
    LOG_add("next_transit_oper", MP_NSTR, TRS.get_string(in_node, "NEXT_TRANSIT_OPER"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("TIV", "TIV_View_Ship_Factory_List",
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

    DBC_init_mtivfacshp(&MTIVFACSHP);

    TRS.copy(MTIVFACSHP.FACTORY_FROM, sizeof(MTIVFACSHP.FACTORY_FROM), in_node, IN_FACTORY);
    if(COM_isnullspace(TRS.get_string(in_node, "NEXT_FACTORY_TO")) == MP_FALSE)
    {
        TRS.copy(MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO), in_node, "NEXT_FACTORY_TO");
    }
    else 
    {
        memset(MTIVFACSHP.FACTORY_TO, ' ', sizeof(MTIVFACSHP.FACTORY_TO));
    }

    DBC_open_mtivfacshp(2, &MTIVFACSHP);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVFACSHP OPEN", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1) 
    {
        DBC_fetch_mtivfacshp(2, &MTIVFACSHP);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            DBC_close_mwipfacdef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVFACSHP FETCH", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mwipfacdef(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_string(out_node, "NEXT_FACTORY_TO", MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO));
            DBC_close_mwipfacdef(2);
            break;
        }

        list_item = TRS.add_node(out_node, "LIST");

        TRS.add_string(list_item, "FACTORY_TO", MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO));
        TRS.add_string(list_item, "TRANSIT_OPER", MTIVFACSHP.TRANSIT_OPER, sizeof(MTIVFACSHP.TRANSIT_OPER));
    }


    if(COM_proc_user_routine("TIV", "TIV_View_Ship_Factory_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

