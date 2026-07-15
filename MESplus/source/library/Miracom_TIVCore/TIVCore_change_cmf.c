/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_update_cmf_lot_list.c
    Description : CMF Value Set related function module

    MES Version : 5.2.0

    Function List
        - TIV_Change_CMF()
            + Create/Update CMF Value List
        - TIV_Change_CMF_Main()
            + Main sub function of "TIV_Change_CMF" function
            + Create/Update CMF Value List

   Detail Description
        - TIV_Change_CMF_Main()
            + h_proc_step 
                + MP_STEP_CREATE : Create CMF Value List
                + MP_STEP_UPDATE : Update CMF Value List

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/7/26  Patrick           Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"

int TIV_Change_CMF_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

void TIV_Change_CMF_In2LOT(int iType, struct MTIVLOTSTS_TAG *MTIVLOTSTS, TRSNode *in_node);
void TIV_Change_CMF_In2LTH(int iType, struct MTIVLOTHIS_TAG *MTIVLOTHIS, TRSNode *in_node);

/*******************************************************************************
    TIV_Change_CMF()
        - Update one or more General Code Data list 
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - WIP_CMF_in_node_Tag *in_node : Input Message structure
        - out_node_Tag *out_node : Output Message structure
*******************************************************************************/
int TIV_Change_CMF(TRSNode *in_node,
                   TRSNode *out_node) 
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_CHANGE_CMF(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_CHANGE_CMF", out_node);

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
    TIV_CHANGE_CMF()
        - Main sub function of "TIV_Change_CMF" function
        - Create/Update CMF Value List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - INV_CMF_CHANGE_IN_TAG *WIP_in_node : Input Message structure
        - out_node_Tag *out_node : Output Message structure
*******************************************************************************/
int TIV_CHANGE_CMF(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    char s_sys_time[14];
    char s_tran_time[14];
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD, MTIVLOTSTS;    
    struct MTIVLOTHIS_TAG MTIVLOTHIS;    

    LOG_head("TIV_CHANGE_CMF");
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Change_CMF",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    if(TIV_Change_CMF_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if(COM_compare_global_option(TRS.get_factory(in_node), 
                                 MP_OPTION_MAKE_HISTORY_CMF_CHANGE, 
                                 'Y') == MP_TRUE) 
    {
        memset(s_tran_time, ' ', sizeof(s_tran_time));
        memset(s_sys_time, ' ', sizeof(s_sys_time));

        DB_get_systime(s_sys_time);
        if(DB_error_code != DB_SUCCESS) {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;    
            gs_log_type.e_type = MP_LOG_E_SYSTEM;    
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        switch(TRS.get_procstep(in_node)) {
            case '1':
				if(!TIV_Get_INVLOTSTS_Info(s_msg_code, &MTIVLOTSTS, TRS.get_factory(in_node), TRS.get_string(in_node, "LOT_ID"),  out_node, TRS.get_userid(in_node), TRS.get_char(in_node, MP_NOTCHECK_PRIVILEGE)))
                {
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }                

                if(COM_check_backtime(s_msg_code,
                                      in_node,
                                      out_node,
                                      MTIVLOTSTS.LAST_TRAN_TIME) == MP_FALSE)
                {
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

                if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
                {
                    memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
                }
                else
                {
                    TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
                }

                memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS, sizeof(MTIVLOTSTS_OLD));

                TIV_Change_CMF_In2LOT(1, &MTIVLOTSTS, in_node);
                memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_TRAN_CODE_CHANGE_CMF, strlen(MP_TRAN_CODE_CHANGE_CMF));
                memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));

                MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
                MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;


                /* History Insert */
                DBC_init_mtivlothis(&MTIVLOTHIS);
                if(TIV_update_insert_lot_status_history(s_msg_code, 
                                                        out_node, 
                                                        in_node,
                                                        s_sys_time, 
                                                        &MTIVLOTSTS_OLD, 
                                                        &MTIVLOTSTS, 
                                                        &MTIVLOTHIS) == MP_FALSE)
                {
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

                /*************************************************************************************************************/
                /* Summary Temp Lot Routine Start */
                /*if(COM_compare_global_option(TRS.get_factory(in_node), 
                                             MP_OPTION_MAKE_SUM_TEMP_HISTORY, 
                                             'Y') == MP_TRUE)
                {
                    TRSNode* sum_in_node;
                    sum_in_node = TRS.create_node("SUMMARY_LOT_IN");
                     
                    TRS.add_string(sum_in_node, "TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
                    TRS.add_string(sum_in_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
                    TRS.add_int(sum_in_node, "HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

                    if(COM_proc_user_routine("MES_UserTIV", "TIV_Change_Cmf",
                                       MP_UPOINT_SUMMARY_LOT,
                                       sum_in_node,
                                       out_node) == MP_FALSE)
                    {
                        TRS.free_node(sum_in_node);
                        return MP_FALSE;
                    }
                    TRS.free_node(sum_in_node);
                }*/
                /* Summary Temp Lot Routine End */
                /*************************************************************************************************************/

                break;
        }
    }
    else 
    {
        switch(TRS.get_procstep(in_node)) {
            case '1':
                if(!TIV_Get_INVLOTSTS_Info(s_msg_code, &MTIVLOTSTS, TRS.get_factory(in_node), TRS.get_string(in_node, "LOT_ID"), out_node, TRS.get_userid(in_node), TRS.get_char(in_node, MP_NOTCHECK_PRIVILEGE)))
                {
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

                TIV_Change_CMF_In2LOT(1, &MTIVLOTSTS, in_node);
                DBC_update_mtivlotsts(1, &MTIVLOTSTS);
                if(DB_error_code != DB_SUCCESS) {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MTIVLOTSTS UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_SYSTEM;    gs_log_type.category = MP_LOG_CATE_TRANS;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

                if(!TIV_Get_INVLOTHIS_Info(s_msg_code, &MTIVLOTHIS, TRS.get_string(in_node, "LOT_ID"),  MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ, out_node))
                {
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

                TIV_Change_CMF_In2LTH(1, &MTIVLOTHIS, in_node);
                DBC_update_mtivlothis(1, &MTIVLOTHIS);
                if(DB_error_code != DB_SUCCESS) {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "MTIVLOTHIS UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);
                    TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS.HIST_SEQ);
                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_SYSTEM;    gs_log_type.category = MP_LOG_CATE_TRANS;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }            
                break;            
        }
    }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_Change_CMF",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


int TIV_Change_CMF_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACCMF_TAG MWIPFACCMF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, IN_FACTORY, MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_VALIDATION;    gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* Data Validation */
    DBC_init_mwipfaccmf(&MWIPFACCMF);
    TRS.copy(MWIPFACCMF.FACTORY, sizeof(MWIPFACCMF.FACTORY), in_node, IN_FACTORY);

    /* LOT Validation */
    if(TRS.get_procstep(in_node) == '1')
    {
        if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
        {
            strcpy(s_msg_code, "WIP-0001");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_VALIDATION;    gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }
        memcpy(MWIPFACCMF.ITEM_NAME, MP_CMF_LOT, strlen(MP_CMF_LOT));  
    }    

    DBC_select_mwipfaccmf(1, &MWIPFACCMF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "WIP-0145");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.e_type = MP_LOG_CATE_TRANS;
        }  
        
        TRS.add_fieldmsg(out_node, "MWIPFACCMF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, IN_FACTORY, MP_STR, sizeof(MWIPFACCMF.FACTORY), MWIPFACCMF.FACTORY);
        TRS.add_fieldmsg(out_node, "ITEM_NAME", MP_STR, sizeof(MWIPFACCMF.ITEM_NAME), MWIPFACCMF.ITEM_NAME);
        gs_log_type.type = MP_LOG_ERROR;    gs_log_type.category = MP_LOG_CATE_TRANS;
        
        return MP_FALSE;
    }

    return MP_TRUE;
}

void TIV_Change_CMF_In2LOT(int iType, struct MTIVLOTSTS_TAG *MTIVLOTSTS, TRSNode *in_node)
{
    TRSNode *member;

    if((member = TRS.get_member(in_node, "INV_CMF_1")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1), in_node, "INV_CMF_1");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_2")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2), in_node, "INV_CMF_2");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_3")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3), in_node, "INV_CMF_3");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_4")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4), in_node, "INV_CMF_4");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_5")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5), in_node, "INV_CMF_5");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_6")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6), in_node, "INV_CMF_6");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_7")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7), in_node, "INV_CMF_7");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_8")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8), in_node, "INV_CMF_8");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_9")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9), in_node, "INV_CMF_9");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_10")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10), in_node, "INV_CMF_10");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_11")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11), in_node, "INV_CMF_11");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_12")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12), in_node, "INV_CMF_12");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_13")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13), in_node, "INV_CMF_13");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_14")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14), in_node, "INV_CMF_14");
    }  
    if((member = TRS.get_member(in_node, "INV_CMF_15")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15), in_node, "INV_CMF_15");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_16")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16), in_node, "INV_CMF_16");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_17")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17), in_node, "INV_CMF_17");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_18")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18), in_node, "INV_CMF_18");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_19")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19), in_node, "INV_CMF_19");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_20")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20), in_node, "INV_CMF_20");
    }
}

void TIV_Change_CMF_In2LTH(int iType, struct MTIVLOTHIS_TAG *MTIVLOTHIS, TRSNode *in_node)
{
    TRSNode *member;

    if((member = TRS.get_member(in_node, "INV_CMF_1")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_1, sizeof(MTIVLOTHIS->INV_CMF_1), in_node, "INV_CMF_1");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_2")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_2, sizeof(MTIVLOTHIS->INV_CMF_2), in_node, "INV_CMF_2");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_3")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_3, sizeof(MTIVLOTHIS->INV_CMF_3), in_node, "INV_CMF_3");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_4")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_4, sizeof(MTIVLOTHIS->INV_CMF_4), in_node, "INV_CMF_4");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_5")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_5, sizeof(MTIVLOTHIS->INV_CMF_5), in_node, "INV_CMF_5");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_6")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_6, sizeof(MTIVLOTHIS->INV_CMF_6), in_node, "INV_CMF_6");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_7")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_7, sizeof(MTIVLOTHIS->INV_CMF_7), in_node, "INV_CMF_7");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_8")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_8, sizeof(MTIVLOTHIS->INV_CMF_8), in_node, "INV_CMF_8");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_9")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_9, sizeof(MTIVLOTHIS->INV_CMF_9), in_node, "INV_CMF_9");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_10")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_10, sizeof(MTIVLOTHIS->INV_CMF_10), in_node, "INV_CMF_10");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_11")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_11, sizeof(MTIVLOTHIS->INV_CMF_11), in_node, "INV_CMF_11");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_12")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_12, sizeof(MTIVLOTHIS->INV_CMF_12), in_node, "INV_CMF_12");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_13")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_13, sizeof(MTIVLOTHIS->INV_CMF_13), in_node, "INV_CMF_13");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_14")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_14, sizeof(MTIVLOTHIS->INV_CMF_14), in_node, "INV_CMF_14");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_15")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_15, sizeof(MTIVLOTHIS->INV_CMF_15), in_node, "INV_CMF_15");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_16")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_16, sizeof(MTIVLOTHIS->INV_CMF_16), in_node, "INV_CMF_16");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_17")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_17, sizeof(MTIVLOTHIS->INV_CMF_17), in_node, "INV_CMF_17");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_18")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_18, sizeof(MTIVLOTHIS->INV_CMF_18), in_node, "INV_CMF_18");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_19")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_19, sizeof(MTIVLOTHIS->INV_CMF_19), in_node, "INV_CMF_19");
    }
    if((member = TRS.get_member(in_node, "INV_CMF_20")) != 0x00 && member->NullFlag != 'Y')
    {
        TRS.copy(MTIVLOTHIS->INV_CMF_20, sizeof(MTIVLOTHIS->INV_CMF_20), in_node, "INV_CMF_20");
    }
}

