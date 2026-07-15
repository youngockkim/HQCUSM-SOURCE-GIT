/*******************************************************************************

    System      : MESplus
    Module      : TIVCore
    File Name   : TIVCore_update_ship_factory.c
    Description : Create/Update/Delete Ship Factory related function module

    MES Version : 4.0.0

    Function List
        - TIV_Update_Ship_Factory()
            + Create/Update/Delete Ship Factory
        - TIV_UPDATE_SHIP_FACTORY()
            + Main Sub function of "WIP_Update_ShpFac"
            + (called by "TIV_Update_Ship_Factory")

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
    TIV_Update_Ship_Factory()                                                          
        - Update Ship Factory Infor                                                  
    Return Value                                                                  
        - int : 0 (MP_TRUE)                                            
    Arguments                                                                     
        - TRSNode *in_node : Input Message structure
        - WIP_TRSNode *out_node : Output Message structure                       
*******************************************************************************/ 
int TIV_Update_Ship_Factory(TRSNode *in_node, 
                            TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_UPDATE_SHIP_FACTORY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_UPDATE_SHIP_FACTORY", out_node);

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
    TIV_UPDATE_SHIP_FACTORY()                                                          
        - Update Ship Factory Infor                                                  
    Return Value                                                                  
        - int : 0 (MP_TRUE)                                            
    Arguments                                                                     
        - TRSNode *in_node : Input Message structure
        - WIP_TRSNode *out_node : Output Message structure                       
*******************************************************************************/ 
int TIV_UPDATE_SHIP_FACTORY(char *s_msg_code,
                           TRSNode *in_node,
                           TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MTIVFACSHP_TAG MTIVFACSHP;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    char s_tran_time[14];


    LOG_head("TIV_Update_Ship_Factory");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("factory_to", MP_NSTR, TRS.get_string(in_node, "FACTORY_TO"));
    LOG_add("auto_term_flag", MP_CHR, TRS.get_char(in_node, "AUTO_TERM_FLAG"));
    LOG_add("transit_oper", MP_NSTR, TRS.get_string(in_node, "TRANSIT_OPER"));
    LOG_add("remote_flag", MP_CHR, TRS.get_char(in_node, "REMOTE_FLAG"));
    LOG_add("ship_cmf_1", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_1"));
    LOG_add("ship_cmf_2", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_2"));
    LOG_add("ship_cmf_3", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_3"));
    LOG_add("ship_cmf_4", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_4"));
    LOG_add("ship_cmf_5", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_5"));
    LOG_add("ship_cmf_6", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_6"));
    LOG_add("ship_cmf_7", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_7"));
    LOG_add("ship_cmf_8", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_8"));
    LOG_add("ship_cmf_9", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_9"));
    LOG_add("ship_cmf_10", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_10"));
    LOG_add("ship_cmf_11", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_11"));
    LOG_add("ship_cmf_12", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_12"));
    LOG_add("ship_cmf_13", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_13"));
    LOG_add("ship_cmf_14", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_14"));
    LOG_add("ship_cmf_15", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_15"));
    LOG_add("ship_cmf_16", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_16"));
    LOG_add("ship_cmf_17", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_17"));
    LOG_add("ship_cmf_18", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_18"));
    LOG_add("ship_cmf_19", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_19"));
    LOG_add("ship_cmf_20", MP_NSTR, TRS.get_string(in_node, "SHIP_CMF_20"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    if(COM_proc_user_routine("TIV", "TIV_Update_Ship_Factory",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;



    memset(s_tran_time, ' ', sizeof(s_tran_time));
    DB_get_systime(s_tran_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

    /*'Factory Validation*/
    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(COM_isnullspace(TRS.get_string(in_node, "FACTORY_TO")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(TRS.str_tcmp(in_node, "FACTORY_TO", in_node, IN_FACTORY) == 0)
    {
        strcpy(s_msg_code, "WIP-0269");
        TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_NSTR, TRS.get_string(in_node, "FACTORY_TO"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(TRS.str_cmp(in_node, "FACTORY_TO", CENTRAL_FACTORY) == 0)
    {
        strcpy(s_msg_code, "WIP-0270");
        TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_NSTR, TRS.get_string(in_node, "FACTORY_TO"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    //Add by J.S. 2009.03.05 for remote shipping
    if(TRS.get_char(in_node, "REMOTE_FLAG") == 'Y')
    {
        TRS.set_char(in_node,"AUTO_TERM_FLAG", 'Y');
    }

    if(TRS.get_char(in_node, "AUTO_TERM_FLAG") == 'Y')
    {
        //Add by J.S. 2009.03.05 for remote shipping
        if(TRS.get_char(in_node, "REMOTE_FLAG") == 'Y')
        {
            if(COM_isnullspace(TRS.get_string(in_node, "TRANSIT_OPER")) == MP_TRUE)
            {
                strcpy(s_msg_code, "WIP-0001");
                TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_NVST);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else
        {
            TRS.set_string(in_node, "TRANSIT_OPER", " ", 1);
        }
    }
    else 
    {
        if(COM_isnullspace(TRS.get_string(in_node, "TRANSIT_OPER")) == MP_TRUE)
        {
            strcpy(s_msg_code, "WIP-0001");
            TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
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
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    //Modify by J.S. 2009.0306 for remote shipping
    if(TRS.get_char(in_node, "REMOTE_FLAG") != 'Y')
    {

        DBC_init_mwipfacdef(&MWIPFACDEF);

        TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, "FACTORY_TO");

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
            TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    if(TRS.get_char(in_node, "AUTO_TERM_FLAG") != 'Y')
    {
        DBC_init_mtivoprdef(&MTIVOPRDEF);

        TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, "FACTORY_TO");
        TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "TRANSIT_OPER");

        DBC_select_mtivoprdef(1, &MTIVOPRDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            if(DB_error_code == DB_NOT_FOUND) 
            {
                strcpy(s_msg_code, "WIP-0010");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else 
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(MTIVOPRDEF.TRANSIT_FLAG != 'Y')
        {
            strcpy(s_msg_code, "WIP-0095");
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    DBC_init_mtivfacshp(&MTIVFACSHP);

    TRS.copy(MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO), in_node, "FACTORY_TO");
    TRS.copy(MTIVFACSHP.FACTORY_FROM, sizeof(MTIVFACSHP.FACTORY_FROM), in_node, IN_FACTORY);
    TRS.copy(MTIVFACSHP.TRANSIT_OPER, sizeof(MTIVFACSHP.TRANSIT_OPER), in_node, "TRANSIT_OPER");

    DBC_select_mtivfacshp_for_update(1,&MTIVFACSHP);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
            {
                ;
            }
            else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
            {
                TRS.set_char(in_node, IN_PROCSTEP, MP_STEP_CREATE);
            }
            else 
            {
                strcpy(s_msg_code, "WIP-0097");
                TRS.add_fieldmsg(out_node, "MTIVFACSHP SELECT FOR UPDATE", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
                TRS.add_fieldmsg(out_node, "FACTORY_FROM", MP_STR, sizeof(MTIVFACSHP.FACTORY_FROM), MTIVFACSHP.FACTORY_FROM);
                TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_STR, sizeof(MTIVFACSHP.TRANSIT_OPER), MTIVFACSHP.TRANSIT_OPER);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                gs_log_type.category = MP_LOG_CATE_SETUP;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVFACSHP SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
            TRS.add_fieldmsg(out_node, "FACTORY_FROM", MP_STR, sizeof(MTIVFACSHP.FACTORY_FROM), MTIVFACSHP.FACTORY_FROM);
            TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_STR, sizeof(MTIVFACSHP.TRANSIT_OPER), MTIVFACSHP.TRANSIT_OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

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
            strcpy(s_msg_code, "WIP-0096");
            TRS.add_fieldmsg(out_node, "MTIVFACSHP SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
            TRS.add_fieldmsg(out_node, "FACTORY_FROM", MP_STR, sizeof(MTIVFACSHP.FACTORY_FROM), MTIVFACSHP.FACTORY_FROM);
            TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_STR, sizeof(MTIVFACSHP.TRANSIT_OPER), MTIVFACSHP.TRANSIT_OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    TRS.copy(MTIVFACSHP.FACTORY_TO, sizeof(MTIVFACSHP.FACTORY_TO), in_node, "FACTORY_TO");
    TRS.copy(MTIVFACSHP.FACTORY_FROM, sizeof(MTIVFACSHP.FACTORY_FROM), in_node, IN_FACTORY);
    MTIVFACSHP.AUTO_TERM_FLAG= TRS.get_char(in_node, "AUTO_TERM_FLAG");
    TRS.copy(MTIVFACSHP.TRANSIT_OPER, sizeof(MTIVFACSHP.TRANSIT_OPER), in_node, "TRANSIT_OPER");
    MTIVFACSHP.REMOTE_FLAG= TRS.get_char(in_node, "REMOTE_FLAG");
    TRS.copy(MTIVFACSHP.SHIP_CMF_1, sizeof(MTIVFACSHP.SHIP_CMF_1), in_node, "SHIP_CMF_1");
    TRS.copy(MTIVFACSHP.SHIP_CMF_2, sizeof(MTIVFACSHP.SHIP_CMF_2), in_node, "SHIP_CMF_2");
    TRS.copy(MTIVFACSHP.SHIP_CMF_3, sizeof(MTIVFACSHP.SHIP_CMF_3), in_node, "SHIP_CMF_3");
    TRS.copy(MTIVFACSHP.SHIP_CMF_4, sizeof(MTIVFACSHP.SHIP_CMF_4), in_node, "SHIP_CMF_4");
    TRS.copy(MTIVFACSHP.SHIP_CMF_5, sizeof(MTIVFACSHP.SHIP_CMF_5), in_node, "SHIP_CMF_5");
    TRS.copy(MTIVFACSHP.SHIP_CMF_6, sizeof(MTIVFACSHP.SHIP_CMF_6), in_node, "SHIP_CMF_6");
    TRS.copy(MTIVFACSHP.SHIP_CMF_7, sizeof(MTIVFACSHP.SHIP_CMF_7), in_node, "SHIP_CMF_7");
    TRS.copy(MTIVFACSHP.SHIP_CMF_8, sizeof(MTIVFACSHP.SHIP_CMF_8), in_node, "SHIP_CMF_8");
    TRS.copy(MTIVFACSHP.SHIP_CMF_9, sizeof(MTIVFACSHP.SHIP_CMF_9), in_node, "SHIP_CMF_9");
    TRS.copy(MTIVFACSHP.SHIP_CMF_10, sizeof(MTIVFACSHP.SHIP_CMF_10), in_node, "SHIP_CMF_10");
    TRS.copy(MTIVFACSHP.SHIP_CMF_11, sizeof(MTIVFACSHP.SHIP_CMF_11), in_node, "SHIP_CMF_11");
    TRS.copy(MTIVFACSHP.SHIP_CMF_12, sizeof(MTIVFACSHP.SHIP_CMF_12), in_node, "SHIP_CMF_12");
    TRS.copy(MTIVFACSHP.SHIP_CMF_13, sizeof(MTIVFACSHP.SHIP_CMF_13), in_node, "SHIP_CMF_13");
    TRS.copy(MTIVFACSHP.SHIP_CMF_14, sizeof(MTIVFACSHP.SHIP_CMF_14), in_node, "SHIP_CMF_14");
    TRS.copy(MTIVFACSHP.SHIP_CMF_15, sizeof(MTIVFACSHP.SHIP_CMF_15), in_node, "SHIP_CMF_15");
    TRS.copy(MTIVFACSHP.SHIP_CMF_16, sizeof(MTIVFACSHP.SHIP_CMF_16), in_node, "SHIP_CMF_16");
    TRS.copy(MTIVFACSHP.SHIP_CMF_17, sizeof(MTIVFACSHP.SHIP_CMF_17), in_node, "SHIP_CMF_17");
    TRS.copy(MTIVFACSHP.SHIP_CMF_18, sizeof(MTIVFACSHP.SHIP_CMF_18), in_node, "SHIP_CMF_18");
    TRS.copy(MTIVFACSHP.SHIP_CMF_19, sizeof(MTIVFACSHP.SHIP_CMF_19), in_node, "SHIP_CMF_19");
    TRS.copy(MTIVFACSHP.SHIP_CMF_20, sizeof(MTIVFACSHP.SHIP_CMF_20), in_node, "SHIP_CMF_20");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        TRS.copy(MTIVFACSHP.CREATE_USER_ID, sizeof(MTIVFACSHP.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVFACSHP.CREATE_TIME, s_tran_time, sizeof(MTIVFACSHP.CREATE_TIME));

        DBC_insert_mtivfacshp(&MTIVFACSHP);
        if(DB_error_code != DB_SUCCESS) 
        {
           strcpy(s_msg_code, "WIP-0004");
           TRS.add_fieldmsg(out_node, "MTIVFACSHP INSERT", MP_NVST);
           TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
           TRS.add_fieldmsg(out_node, "FACTORY_FROM", MP_STR, sizeof(MTIVFACSHP.FACTORY_FROM), MTIVFACSHP.FACTORY_FROM);
           TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_STR, sizeof(MTIVFACSHP.TRANSIT_OPER), MTIVFACSHP.TRANSIT_OPER);
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
        TRS.copy(MTIVFACSHP.UPDATE_USER_ID, sizeof(MTIVFACSHP.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(MTIVFACSHP.UPDATE_TIME, s_tran_time, sizeof(MTIVFACSHP.UPDATE_TIME));

        DBC_update_mtivfacshp(2, &MTIVFACSHP);
        if(DB_error_code != DB_SUCCESS) 
        {
           strcpy(s_msg_code, "WIP-0004");
           TRS.add_fieldmsg(out_node, "MTIVFACSHP UPDATE", MP_NVST);
           TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
           TRS.add_fieldmsg(out_node, "FACTORY_FROM", MP_STR, sizeof(MTIVFACSHP.FACTORY_FROM), MTIVFACSHP.FACTORY_FROM);
           TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_STR, sizeof(MTIVFACSHP.TRANSIT_OPER), MTIVFACSHP.TRANSIT_OPER);
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
        DBC_delete_mtivfacshp(1, &MTIVFACSHP);
        if(DB_error_code != DB_SUCCESS) 
        {
           strcpy(s_msg_code, "WIP-0004");
           TRS.add_fieldmsg(out_node, "MTIVFACSHP DELETE", MP_NVST);
           TRS.add_fieldmsg(out_node, "FACTORY_TO", MP_STR, sizeof(MTIVFACSHP.FACTORY_TO), MTIVFACSHP.FACTORY_TO);
           TRS.add_fieldmsg(out_node, "FACTORY_FROM", MP_STR, sizeof(MTIVFACSHP.FACTORY_FROM), MTIVFACSHP.FACTORY_FROM);
           TRS.add_fieldmsg(out_node, "TRANSIT_OPER", MP_STR, sizeof(MTIVFACSHP.TRANSIT_OPER), MTIVFACSHP.TRANSIT_OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
       }
    }

    if(COM_proc_user_routine("TIV", "TIV_Update_Ship_Factory",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

