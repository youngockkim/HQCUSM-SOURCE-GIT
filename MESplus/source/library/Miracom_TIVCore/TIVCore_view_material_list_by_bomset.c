/*******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : TIV_view_material_list_by_bomset.c
    Description : View Material List by Bomset related function module

    MES Version : 4.0.0
    
    Function List
        - TIV_View_Material_List_By_BomSet()
            + View_Material_List_By_BomSet
        - TIV_VIEW_MATERIAL_LIST_BY_BOMSET()
            + Main Sub function of "TIV_View_Material_List_By_Bomset"
            + (called by "TIV_View_Material_List_By_Bomset")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2013/01/08  JJ OH         Create        

    Copyright(C) 1998-2013 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"

/*******************************************************************************
    TIV_View_Material_List_By_BomSet()                                                          
        - View Material List By BomSet                                               
    Return Value                                                                  
        - int : 0 (MP_TRUE)                                            
    Arguments                                                                     
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure                       
*******************************************************************************/
int TIV_View_Material_List_By_Bomset(TRSNode *in_node, 
                      TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_MATERIAL_LIST_BY_BOMSET(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_MATERIAL_LIST_BY_BOMSET", out_node);

    if(i_ret == MP_TRUE) 
    {
        DB_commit();
    }
    else 
    {
        DB_rollback();
    }

    return MP_TRUE;

    //SLP_call_service("View_Lot_List", 0, "MES_SampleLib", 0x00, "", in_node, out_node);
    //return MP_TRUE;
}


/*******************************************************************************
    TIV_VIEW_MATERIAL_LIST_BY_BOMSET()                                                     
        - Main sub function of "TIV_View_Material_List_By_Bomset" function  
        - View Material List 
    Return Value                                                                  
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)                                  
    Arguments                                                                     
        - char *s_msg_code : Error Message Code                                   
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure                       
*******************************************************************************/
int TIV_VIEW_MATERIAL_LIST_BY_BOMSET(char *s_msg_code,
                           TRSNode *in_node, 
                           TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MBOMSETMAT_TAG MBOMSETMAT;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MTIVMATDEF_TAG MTIVMATDEF;
    TRSNode *list_item;
    int i_lot_step = 0;
    int i_bom_step = 0;


    LOG_head("TIV_VIEW_MATERIAL_LIST_BY_BOMSET");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("next_lot_id", MP_NSTR, TRS.get_string(in_node, "NEXT_LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_List_By_Bomset",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
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

    if(TRS.get_procstep(in_node) == '1')//Get By WIP Lot_ID
    {
        i_lot_step = 2;
        i_bom_step = 4;

        /*Lot Input Validation*/
        if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
        {
            return MP_FALSE;
        }

        /*Lot Info*/
        DBC_init_mwiplotsts(&MWIPLOTSTS);
        TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
        DBC_select_mwiplotsts(i_lot_step, &MWIPLOTSTS);
        if(DB_error_code != DB_SUCCESS) 
        {
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == '2')//Get By WIP Material
    {
        i_bom_step = 4;

        if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
        {
            return MP_FALSE;
        }
    }

    if(TRS.get_procstep(in_node)=='1' || TRS.get_procstep(in_node) == '2')
    {
        /*Wip Mat Info*/
        DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);

        if(TRS.get_procstep(in_node)=='1')
        {
            memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
            MWIPMATDEF.MAT_VER = MWIPLOTSTS.MAT_VER; 
        }
        else if(TRS.get_procstep(in_node)=='2')
        {
            TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "MAT_ID");
            MWIPMATDEF.MAT_VER = TRS.get_int(in_node, "MAT_VER");
        }
    
        DBC_select_mwipmatdef(1, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            return MP_FALSE;
        }

        DBC_init_mbomsetmat(&MBOMSETMAT);
        TRS.copy(MBOMSETMAT.FACTORY, sizeof(MBOMSETMAT.FACTORY), in_node, IN_FACTORY);
        memcpy(MBOMSETMAT.BOM_SET_ID, MWIPMATDEF.BOM_SET_ID, sizeof(MBOMSETMAT.BOM_SET_ID));
        DBC_open_mbomsetmat(i_bom_step, &MBOMSETMAT);
        if(DB_error_code != DB_SUCCESS) 
        {
            return MP_FALSE;
        }
        while(1) 
        {
            DBC_fetch_mbomsetmat(i_bom_step, &MBOMSETMAT);
            if(DB_error_code == DB_NOT_FOUND) 
            {
                DBC_close_mbomsetmat(i_bom_step);
                break;
            }
            else if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "BOM-0004");
                TRS.add_fieldmsg(out_node, "MBOMSETMAT OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MBOMSETMAT.FACTORY), MBOMSETMAT.FACTORY);
                TRS.add_fieldmsg(out_node, "BOM_SET_ID", MP_STR, sizeof(MBOMSETMAT.BOM_SET_ID), MBOMSETMAT.BOM_SET_ID);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                DBC_close_mwiplotsts(i_bom_step);
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

            DBC_init_mtivmatdef(&MTIVMATDEF);
            memcpy(MTIVMATDEF.FACTORY, MBOMSETMAT.FACTORY, sizeof(MTIVMATDEF.FACTORY));
            memcpy(MTIVMATDEF.MAT_ID, MBOMSETMAT.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
            MTIVMATDEF.MAT_VER = MBOMSETMAT.MAT_VER; 
            DBC_select_mtivmatdef(1, &MTIVMATDEF);
            if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS) 
            {
                return MP_FALSE;
            }

            list_item = TRS.add_node(out_node, "BOM_MAT_LIST");

            TRS.add_string(list_item, "BOM_SET_ID", MBOMSETMAT.BOM_SET_ID, sizeof(MBOMSETMAT.BOM_SET_ID));
            TRS.add_int(list_item, "BOM_SET_VERSION", MBOMSETMAT.BOM_SET_VERSION);
            TRS.add_int(list_item, "SEQ_NUM", MBOMSETMAT.SEQ_NUM);
            TRS.add_string(list_item, "PART_GRP", MBOMSETMAT.PART_GRP, sizeof(MBOMSETMAT.PART_GRP));
            TRS.add_char(list_item, "ALT_MAT_FLAG", MBOMSETMAT.ALT_MAT_FLAG);
            TRS.add_string(list_item, "MAT_ID", MBOMSETMAT.MAT_ID, sizeof(MBOMSETMAT.MAT_ID));
            TRS.add_int(list_item, "MAT_VER", MBOMSETMAT.MAT_VER);
            TRS.add_string(list_item, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));
            TRS.add_string(list_item, "MAT_SHORT_DESC", MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC));
            TRS.add_string(list_item, "UNIT_1", MTIVMATDEF.UNIT_1, sizeof(MTIVMATDEF.UNIT_1));
            TRS.add_double(list_item, "MAT_QTY", MBOMSETMAT.MAT_QTY);
            TRS.add_string(list_item, "MAT_UNIT", MBOMSETMAT.MAT_UNIT, sizeof(MBOMSETMAT.MAT_UNIT));
            TRS.add_char(list_item, "OPT_INPUT_FLAG", MBOMSETMAT.OPT_INPUT_FLAG);
            TRS.add_char(list_item, "AUTO_INPUT_FLAG", MBOMSETMAT.AUTO_INPUT_FLAG);
            TRS.add_char(list_item, "SERIAL_INPUT_FLAG", MBOMSETMAT.SERIAL_INPUT_FLAG);
            TRS.add_char(list_item, "SERIAL_TYPE", MBOMSETMAT.SERIAL_TYPE);
            TRS.add_char(list_item, "CHK_SERIAL_FLAG", MBOMSETMAT.CHK_SERIAL_FLAG);
            TRS.add_string(list_item, "FLOW", MBOMSETMAT.FLOW, sizeof(MBOMSETMAT.FLOW));
            TRS.add_string(list_item, "OPER", MBOMSETMAT.OPER, sizeof(MBOMSETMAT.OPER));
            TRS.add_string(list_item, "PART_CMF_1", MBOMSETMAT.PART_CMF_1, sizeof(MBOMSETMAT.PART_CMF_1));
            TRS.add_string(list_item, "PART_CMF_2", MBOMSETMAT.PART_CMF_2, sizeof(MBOMSETMAT.PART_CMF_2));
            TRS.add_string(list_item, "PART_CMF_3", MBOMSETMAT.PART_CMF_3, sizeof(MBOMSETMAT.PART_CMF_3));
            TRS.add_string(list_item, "PART_CMF_4", MBOMSETMAT.PART_CMF_4, sizeof(MBOMSETMAT.PART_CMF_4));
            TRS.add_string(list_item, "PART_CMF_5", MBOMSETMAT.PART_CMF_5, sizeof(MBOMSETMAT.PART_CMF_5));
            TRS.add_string(list_item, "PART_CMF_6", MBOMSETMAT.PART_CMF_6, sizeof(MBOMSETMAT.PART_CMF_6));
            TRS.add_string(list_item, "PART_CMF_7", MBOMSETMAT.PART_CMF_7, sizeof(MBOMSETMAT.PART_CMF_7));
            TRS.add_string(list_item, "PART_CMF_8", MBOMSETMAT.PART_CMF_8, sizeof(MBOMSETMAT.PART_CMF_8));
            TRS.add_string(list_item, "PART_CMF_9", MBOMSETMAT.PART_CMF_9, sizeof(MBOMSETMAT.PART_CMF_9));
            TRS.add_string(list_item, "PART_CMF_10", MBOMSETMAT.PART_CMF_10, sizeof(MBOMSETMAT.PART_CMF_10));
            TRS.add_enc_string(list_item, "CREATE_USER_ID", MBOMSETMAT.CREATE_USER_ID, sizeof(MBOMSETMAT.CREATE_USER_ID));
            TRS.add_string(list_item, "CREATE_TIME", MBOMSETMAT.CREATE_TIME, sizeof(MBOMSETMAT.CREATE_TIME));
            TRS.add_enc_string(list_item, "UPDATE_USER_ID", MBOMSETMAT.UPDATE_USER_ID, sizeof(MBOMSETMAT.UPDATE_USER_ID));
            TRS.add_string(list_item, "UPDATE_TIME", MBOMSETMAT.UPDATE_TIME, sizeof(MBOMSETMAT.UPDATE_TIME));
			TRS.add_string(list_item, "MAT_CMF_1", MTIVMATDEF.MAT_CMF_1, sizeof(MTIVMATDEF.MAT_CMF_1));
            TRS.add_string(list_item, "MAT_CMF_2", MTIVMATDEF.MAT_CMF_2, sizeof(MTIVMATDEF.MAT_CMF_2));
            TRS.add_string(list_item, "MAT_CMF_3", MTIVMATDEF.MAT_CMF_3, sizeof(MTIVMATDEF.MAT_CMF_3));
            TRS.add_string(list_item, "MAT_CMF_4", MTIVMATDEF.MAT_CMF_4, sizeof(MTIVMATDEF.MAT_CMF_4));
            TRS.add_string(list_item, "MAT_CMF_5", MTIVMATDEF.MAT_CMF_5, sizeof(MTIVMATDEF.MAT_CMF_5));
            TRS.add_string(list_item, "MAT_CMF_6", MTIVMATDEF.MAT_CMF_6, sizeof(MTIVMATDEF.MAT_CMF_6));
            TRS.add_string(list_item, "MAT_CMF_7", MTIVMATDEF.MAT_CMF_7, sizeof(MTIVMATDEF.MAT_CMF_7));
            TRS.add_string(list_item, "MAT_CMF_8", MTIVMATDEF.MAT_CMF_8, sizeof(MTIVMATDEF.MAT_CMF_8));
            TRS.add_string(list_item, "MAT_CMF_9", MTIVMATDEF.MAT_CMF_9, sizeof(MTIVMATDEF.MAT_CMF_9));
			TRS.add_string(list_item, "MAT_CMF_10", MTIVMATDEF.MAT_CMF_10, sizeof(MTIVMATDEF.MAT_CMF_10));

        }    
    }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_List_By_Bomset",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

