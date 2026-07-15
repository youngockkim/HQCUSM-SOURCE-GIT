/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_release_lot.c
    Description : Release Lot transaction function module

    MES Version : 4.0.0

    Function List
        - TIV_Release_Lot()
            + Release Lot
        - TIV_RELEASE_LOT()
            + Main sub function of "TIV_Release_Lot" function
            + Release Lot definition
        - TIV_Release_Lot_Validation()
            + Validation Check sub function of "TIV_RELEASE_LOT" function
            + Check the conditions before Release Lot definition
        - TIV_check_lot_cmf_create_release_lot()
            + Check the Conditions before Create Child Lot CMF Definition
        - TIV_check_lot_cmf_release_lot()
            + Check the Conditions before Release Lot CMF Definition

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/15  Laverwon       Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
//#define TIV_RELEASE_CODE		  ("TIV_RELEASE_CODE    ")
#include "TIVCore_common.h"


int TIV_Release_Lot_Validation(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node);

int TIV_check_lot_cmf_release_lot(char *s_msg_code,
                               TRSNode *in_node,
                               TRSNode *out_node);

/*******************************************************************************
    TIV_Release_Lot()
        - Release Lot
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_Release_Lot(TRSNode *in_node,
                 TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

#ifdef _ALM
    /* Save Factory, res_id, lot_id , ...for alarm */
    TRS.copy(gs_alm_factory, sizeof(gs_alm_factory), in_node, IN_FACTORY);
    TRS.copy(gs_alm_user_id, sizeof(gs_alm_user_id), in_node, IN_USERID);
    TRS.copy(gs_alm_lot_id, sizeof(gs_alm_lot_id), in_node, "LOT_ID");
//    TRS.copy(gs_alm_res_id, sizeof(gs_alm_res_id), in_node, "RES_ID");
    TRS.copy(gs_alm_source_id, sizeof(gs_alm_source_id), in_node, "LOT_ID");
    memcpy(gs_alm_module, MP_TRAN_CODE_RELEASE, strlen(MP_TRAN_CODE_RELEASE));
#endif /* _ALM */

    i_ret = TIV_RELEASE_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_RELEASE_LOT", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    TIV_RELEASE_LOT()
        - Main sub function of "TIV_Release_Lot" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure    
*******************************************************************************/
int TIV_RELEASE_LOT(char *s_msg_code,
                      TRSNode *in_node,
                      TRSNode *out_node)
{

    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;

    int i;
    int i_data_count;
    int iReleaseHoldHistSeq;
    char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];
	 
    TRSNode **data_list;
    
    LOG_head("TIV_Release_Lot");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("back_time", MP_NSTR, TRS.get_string(in_node, "BACK_TIME"));
    LOG_add("inv_lot_id", MP_NSTR, TRS.get_string(in_node, "TIV_LOT_ID"));
    LOG_add("LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
   /* LOG_add("flow", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    LOG_add("flow_seq_num", MP_INT, TRS.get_int(in_node, "FLOW_SEQ_NUM"));*/
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    /*LOG_add("hold_password", MP_NSTR, TRS.get_string(in_node, "HOLD_PASSWORD"));*/
    LOG_add("hold_code", MP_NSTR, TRS.get_string(in_node, "HOLD_CODE"));
    /*LOG_add("hold_prv_grp_id", MP_NSTR, TRS.get_string(in_node, "HOLD_PRV_GRP_ID"));*/
    LOG_add("release_code", MP_NSTR, TRS.get_string(in_node, "RELEASE_CODE"));
   /* LOG_add("tran_cmf_1", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_1"));
    LOG_add("tran_cmf_2", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_2"));
    LOG_add("tran_cmf_3", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_3"));
    LOG_add("tran_cmf_4", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_4"));
    LOG_add("tran_cmf_5", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_5"));
    LOG_add("tran_cmf_6", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_6"));
    LOG_add("tran_cmf_7", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_7"));
    LOG_add("tran_cmf_8", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_8"));
    LOG_add("tran_cmf_9", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_9"));
    LOG_add("tran_cmf_10", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_10"));
    LOG_add("tran_cmf_11", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_11"));
    LOG_add("tran_cmf_12", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_12"));
    LOG_add("tran_cmf_13", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_13"));
    LOG_add("tran_cmf_14", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_14"));
    LOG_add("tran_cmf_15", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_15"));
    LOG_add("tran_cmf_16", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_16"));
    LOG_add("tran_cmf_17", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_17"));
    LOG_add("tran_cmf_18", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_18"));
    LOG_add("tran_cmf_19", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_19"));
    LOG_add("tran_cmf_20", MP_NSTR, TRS.get_string(in_node, "TRAN_CMF_20"));*/
    LOG_add("tran_comment", MP_NSTR, TRS.get_string(in_node, "TRAN_COMMENT"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Release_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

	memset(s_erp_tran_time, ' ', sizeof(s_erp_tran_time));
	memset(s_tran_time, ' ', sizeof(s_tran_time));
	memset(s_sys_time, ' ', sizeof(s_sys_time));
    iReleaseHoldHistSeq = 0;

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	 
	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}
	

	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");
	 

    /* Validation Check */
    if(TIV_Release_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    ///* Get TransTime */
    //if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
    //{
    //    memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
    //}
    //else
    //{
    //    TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
    //}
    if(TRS.get_procstep(in_node)=='1')
	{
        DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
        TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");    
	    TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "OPER");    
        DBC_select_mtivlotsts(4, &MTIVLOTSTS_OLD);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "INV-0044");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }     
            TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);
            TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);        

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

        MTIVLOTSTS.HOLD_FLAG = ' ';
        memset(MTIVLOTSTS.HOLD_CODE, ' ', sizeof(MTIVLOTSTS.HOLD_CODE));

        TRS.copy(MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE), in_node, "RELEASE_CODE");
        memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_RELEASE, strlen(MP_INV_TRAN_CODE_RELEASE));
        TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
        memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
        TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

		memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

        MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
        MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

        /*MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
        MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;*/

        /* History Insert */
        DBC_init_mtivlothis(&MTIVLOTHIS);

        if(TIV_update_insert_lot_status_history_For_Release_Hold(s_msg_code,
                                                in_node,
                                                out_node,                                            
                                                s_sys_time,
                                                &MTIVLOTSTS_OLD,
                                                &MTIVLOTSTS,
                                                &MTIVLOTHIS) == MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node)=='2')
    {
        i_data_count = TRS.get_item_count(in_node, "DATA_LIST");
	    data_list = TRS.get_list(in_node, "DATA_LIST");

        for (i = 0; i < i_data_count; i++)
        {
            DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
            TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), data_list[i], "TIV_LOT_ID");    
	        TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), data_list[i], "OPER");    
            DBC_select_mtivlotsts(4, &MTIVLOTSTS_OLD);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "INV-0044");
                    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                }
                else
                {
                    strcpy(s_msg_code, "INV-0004");
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                }     
                TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);
                TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);        

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_TRANS;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
            memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

            MTIVLOTSTS.HOLD_FLAG = ' ';
            memset(MTIVLOTSTS.HOLD_CODE, ' ', sizeof(MTIVLOTSTS.HOLD_CODE));

            TRS.copy(MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE), in_node, "RELEASE_CODE");
            memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_RELEASE, strlen(MP_INV_TRAN_CODE_RELEASE));
            TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");  
            memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
            TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

			memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

            MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
            MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;

			TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
			TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");

            /* History Insert */
            DBC_init_mtivlothis(&MTIVLOTHIS);
			TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
			TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

            if(TIV_update_insert_lot_status_history_For_Release_Hold(s_msg_code,
                                                    in_node,
                                                    out_node,                                            
                                                    s_sys_time,
                                                    &MTIVLOTSTS_OLD,
                                                    &MTIVLOTSTS,
                                                    &MTIVLOTHIS) == MP_FALSE)
            {
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
    }

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Release_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));    
    return MP_TRUE;
}


/*******************************************************************************
    TIV_Release_Lot_Validation()
        - Validation Check sub function of "TIV_UPDATE_FLOW" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Release_Lot_Validation(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{

    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;

    int i;
    int i_data_count;

    TRSNode **data_list;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Proc Step validation */
    if(COM_check_value(s_msg_code,
                       in_node,
                       out_node,
                       IN_PROCSTEP,
                       'Y',
                       ' ',
                       0x00,
                       0x00,
                       0x00) == MP_FALSE)
    {
        return MP_FALSE;
    }


    if(TRS.get_procstep(in_node)=='2')
    {
        i_data_count = TRS.get_item_count(in_node, "DATA_LIST");
	    data_list = TRS.get_list(in_node, "DATA_LIST");

        for (i = 0; i < i_data_count; i++)
        {
            if(COM_isnullspace(TRS.get_string(data_list[i], "TIV_LOT_ID")) == MP_TRUE)
            {
                strcpy(s_msg_code, "INV-0001");
                TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_NVST);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }

             /* Factory Validation */
            if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
            {
                strcpy(s_msg_code, "WIP-0001");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }

            DBC_init_mtivlotsts(&MTIVLOTSTS);
            TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), data_list[i], "TIV_LOT_ID");  
            TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), data_list[i], "OPER"); 
            DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "WIP-0044");
                    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                }
                else
                {
                    strcpy(s_msg_code, "WIP-0004");
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                }     
                TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
			 
            if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") >= 1)
            {
                /* Hist Seq Validation */
                if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ) 
                {
                    strcpy(s_msg_code, "WIP-0113");
                    TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
                    TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
                    TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
         
                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                    gs_log_type.category = MP_LOG_CATE_COMMON;
                    return MP_FALSE;
                }
          
                /* Material Validation */
                if(COM_isnullspace(TRS.get_string(data_list[i], "MAT_ID")) == MP_TRUE)
                {
                    strcpy(s_msg_code, "WIP-0001");
                    TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);
         
                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                    gs_log_type.category = MP_LOG_CATE_COMMON;
                    return MP_FALSE;
                }
                else
                {
                    if(TRS.mem_cmp(in_node, "MAT_ID", MTIVLOTSTS.MAT_ID, strlen(TRS.get_string(data_list[i], "MAT_ID"))) != 0)
                    {
                        strcpy(s_msg_code, "WIP-0064");
                        TRS.add_fieldmsg(out_node, "MAT_ID 1", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
                        TRS.add_fieldmsg(out_node, "MAT_ID 2", MP_STR, sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);
         
                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_VALIDATION;
                        gs_log_type.category = MP_LOG_CATE_COMMON;
                        return MP_FALSE;
                    }
                    if(TRS.get_int(in_node, "MAT_VER") != MTIVLOTSTS.MAT_VER)
                    {
                        strcpy(s_msg_code, "WIP-0331");
                        TRS.add_fieldmsg(out_node, "MAT_VER 1", MP_INT, TRS.get_int(data_list[i], "MAT_VER"));
                        TRS.add_fieldmsg(out_node, "MAT_VER 2", MP_INT, MTIVLOTSTS.MAT_VER);
         
                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_VALIDATION;
                        gs_log_type.category = MP_LOG_CATE_COMMON;
                        return MP_FALSE;
                    }           
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
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                }     
                TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
                
            DBC_init_mtivoprdef(&MTIVOPRDEF);
            TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), data_list[i], "OPER");
            DBC_select_mtivoprdef(1, &MTIVOPRDEF);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "INV-0010");
                    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                }
                else
                {
                    strcpy(s_msg_code, "INV-0004");
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                }     
                TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }

            if(MTIVOPRDEF.SEC_CHK_FLAG == 'Y')
            {
                if(TRS.get_char(in_node, MP_NOTCHECK_PRIVILEGE) != 'Y')
                {
                    /* Privilege Validation */
                    if(COM_check_privilege(s_msg_code, 
                                           out_node, 
                                           '2',
                                           MTIVOPRDEF.FACTORY, 
                                           MP_PRV_TYPE_OPER,
                                           MTIVOPRDEF.OPER,
                                           sizeof(MTIVOPRDEF.OPER),
                                           "",
                                           0,
                                           "",
                                           0,
                                           TRS.get_userid(in_node)) == MP_FALSE)
                    {
                        return MP_FALSE;
                    }
                }
            }

            DBC_init_mwipmatdef(&MWIPMATDEF);
            TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
            TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), data_list[i], "MAT_ID");
            MWIPMATDEF.MAT_VER = TRS.get_int(data_list[i], "MAT_VER");    
            DBC_select_mwipmatdef(1, &MWIPMATDEF);
            if(DB_error_code != DB_SUCCESS) 
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    strcpy(s_msg_code, "WIP-0006");
                    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                }
                else
                {
                    strcpy(s_msg_code, "WIP-0004");
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    TRS.add_dberrmsg(out_node, DB_error_msg);
                }
                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }    
			 
            /* Back Time Check */
            if(TIV_check_backtime(s_msg_code,
                                    in_node,
                                    out_node,
                                    MTIVLOTSTS.LAST_TRAN_TIME) == MP_FALSE)
            {
                return MP_FALSE;
                
            } 

            if(COM_isnullspace(TRS.get_string(in_node, "RELEASE_CODE")) == MP_TRUE)
            {
                strcpy(s_msg_code, "INV-0001");
                TRS.add_fieldmsg(out_node, "RELEASE_CODE", MP_NVST);
            
                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_TRANS;
                return MP_FALSE;
            }

            if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
            {
                strcpy(s_msg_code, "WIP-0076");
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
            
                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
            /* Lot Hold Validation */
            if(MTIVLOTSTS.HOLD_FLAG != 'Y')
            {
                strcpy(s_msg_code, "WIP-0083");
                TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
            
                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_TRANS;
                return MP_FALSE;
            }
            
            /* Hold Code Check */
            if(COM_check_gcm_data(s_msg_code,
                                  out_node,
                                  MP_GCM_TBL_INV_RELEASE_CODE,
                                  TRS.get_factory(in_node),
                                  TRS.get_string(in_node, "RELEASE_CODE"),
                                  (int)strlen(TRS.get_string(in_node, "RELEASE_CODE"))) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
    }
    else
    {
        ///* validation input value */
        //if(TIV_lot_tran_validation_for_inv(s_msg_code,
        //                           out_node,
        //                           in_node,
        //                           &MTIVLOTSTS,
        //                           &MWIPFACDEF,
        //                           &MTIVMATDEF,
        //                           &MTIVOPRDEF) == MP_FALSE)
        //{
        //    return MP_FALSE;
        //}
        
        //if(COM_isnullspace(TRS.get_string(in_node, "RELEASE_CODE")) == MP_TRUE)
        //{
        //    strcpy(s_msg_code, "INV-0001");
        //    TRS.add_fieldmsg(out_node, "RELEASE_CODE", MP_NVST);
        //
        //    gs_log_type.type = MP_LOG_ERROR;
        //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
        //    gs_log_type.category = MP_LOG_CATE_TRANS;
        //    return MP_FALSE;
        //}
        //
        //if(MTIVLOTSTS.LOT_DEL_FLAG == 'Y')
        //{
        //    strcpy(s_msg_code, "WIP-0076");
        //    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        //
        //    gs_log_type.type = MP_LOG_ERROR;
        //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
        //    gs_log_type.category = MP_LOG_CATE_COMMON;
        //    return MP_FALSE;
        //}
        ///* Lot Hold Validation */
        //if(MTIVLOTSTS.HOLD_FLAG != 'Y')
        //{
        //    strcpy(s_msg_code, "WIP-0083");
        //    TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        //
        //    gs_log_type.type = MP_LOG_ERROR;
        //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
        //    gs_log_type.category = MP_LOG_CATE_TRANS;
        //    return MP_FALSE;
        //}
        //
        ///* Hold Code Check */
        //if(COM_check_gcm_data(s_msg_code,
        //                      out_node,
        //                      TIV_RELEASE_CODE,
        //                      TRS.get_factory(in_node),
        //                      TRS.get_string(in_node, "RELEASE_CODE"),
        //                      (int)strlen(TRS.get_string(in_node, "RELEASE_CODE"))) == MP_FALSE)
        //{
        //    return MP_FALSE;
        //}
    }

    return MP_TRUE;
}


/*******************************************************************************
    TIV_check_lot_cmf_release_lot()
        - Check the Conditions before Release Lot CMF Definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_check_lot_cmf_release_lot(char *s_msg_code,
                                TRSNode *in_node,
                                TRSNode *out_node)
{
    struct check_list s_check_list;

    COM_fill_check_list(&s_check_list, in_node, 20, "TRAN_CMF");
    if(COM_check_cmf(s_msg_code, 
                     out_node, 
                     MP_CMF_TRN_RELEASE, 
                     TRS.get_factory(in_node), 
                     &s_check_list) == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}
