/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_IQC_Lot.c
    Description : IQC Transaction Process

    MES Version : 5.2.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/21  Patrick        Create

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"

int TIV_IQC_Lot_Validation(char *Msg_Code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    TIV_IQC_Lot()
        - IQC Lot Transaction Process
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_IQC_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_IQC_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_IQC_LOT", out_node);

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
    TIV_IQC_LOT()
        - IQC Lot
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_IQC_LOT(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    struct MTIVLOTHIS_TAG MTIVLOTHIS_OLD;
	struct MATRNAMSTS_TAG MATRNAMSTS;
    struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MTIVIQCHIS_TAG MTIVIQCHIS;


    TRSNode *transfer_lot_in;    
    TRSNode *hold_lot_in;    

    char s_sys_time[14];
    char s_tran_time[14];

    int i_mat_ver;

    LOG_head("TIV_IQC_LOT");
    COM_log_add_field_msg(in_node);    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_IQC_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    TRS.set_nstring(in_node, "__FACTORY", TRS.get_string(in_node, IN_FACTORY));
    TRS.set_nstring(in_node, "__OPER", TRS.get_string(in_node, "OPER"));
    if(TIV_Lot_Fill_InTag_Cmf_For_IQC(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /*Validation*/
    if(TIV_IQC_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memset(s_tran_time, ' ', sizeof(s_tran_time));

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

     /* Get TransTime */
    if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_TRUE)
    {
        memcpy(s_tran_time, s_sys_time, sizeof(s_tran_time));
    }
    else
    {
        TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "BACK_TIME");
    }


    
	
   
    /*IQC - Not use*/
    // Loss transaction
	/*if(TRS.get_item_count(in_node, "UNIT1") > 0 || TRS.get_item_count(in_node, "UNIT2") > 0 || TRS.get_item_count(in_node, "UNIT3") > 0)
    {
        if(TIV_LOSS_LOT(s_msg_code, in_node, out_node) == MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        

        TRS.set_nstring(in_node, "__F_TIV_LOT_ID", TRS.get_string(in_node, "TIV_LOT_ID"));
        if (TIV_Get_Last_Active_Lot_Grp_Seq(s_msg_code, in_node, out_node) == MP_FALSE)
        {
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        TRS.set_int(in_node, "LAST_ACTIVE_HIST_SEQ",  TRS.get_int(in_node, "__F_LAST_ACTIVE_HIST_SEQ"));
    }*/
    
    /*Defect transaction*/
    if(TRS.get_item_count(in_node, "DEFECT_LIST") > 0)
    {
        if(TIV_DEFECT_LOT(s_msg_code, in_node, out_node) == MP_FALSE)
        {
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }        

        TRS.set_nstring(in_node, "__F_TIV_LOT_ID", TRS.get_string(in_node, "TIV_LOT_ID"));
        if (TIV_Get_Last_Active_Lot_Grp_Seq(s_msg_code, in_node, out_node) == MP_FALSE)
        {
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        TRS.set_int(in_node, "LAST_ACTIVE_HIST_SEQ",  TRS.get_int(in_node, "__F_LAST_ACTIVE_HIST_SEQ"));
    }


    //대체할것 OPER, LOT_ID, HIST_SEQ, FACTORY
    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");   
    TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "OPER");
    DBC_select_mtivlotsts_for_update(2, &MTIVLOTSTS_OLD);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0030");             
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");            
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT FOR UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_OLD.FACTORY), MTIVLOTSTS_OLD.FACTORY);        
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS_OLD.LOT_ID), MTIVLOTSTS_OLD.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    //TRASFER에 수량을 넘겨줄때 이것으로 넘겨주지 않으면 LOSS에서 update된 STS의 QTY값이 들어가기 때문에 별도로 수량을 넘겨준다.
   

    DBC_init_mtivlothis(&MTIVLOTHIS_OLD);
    TRS.copy(MTIVLOTHIS_OLD.FACTORY, sizeof(MTIVLOTHIS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTHIS_OLD.LOT_ID, sizeof(MTIVLOTHIS_OLD.LOT_ID), in_node, "TIV_LOT_ID");   
    TRS.copy(MTIVLOTHIS_OLD.OPER, sizeof(MTIVLOTHIS_OLD.OPER), in_node, "OPER");
    MTIVLOTHIS_OLD.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
    DBC_select_mtivlothis_for_update(2, &MTIVLOTHIS_OLD);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0030");             
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");            
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT FOR UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS_OLD.FACTORY), MTIVLOTHIS_OLD.FACTORY);        
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTHIS_OLD.LOT_ID), MTIVLOTHIS_OLD.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTHIS_OLD.OPER), MTIVLOTHIS_OLD.OPER);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_STR, sizeof(MTIVLOTHIS_OLD.HIST_DEL_USER_ID), MTIVLOTHIS_OLD.HIST_DEL_USER_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /*IQC Complete Flag*/
    if(TRS.get_char(in_node, "PASS_FLAG") != 'F')
        memcpy(MTIVLOTHIS_OLD.TRAN_CMF_1,"Y", strlen("Y"));
    
    /* TRAN_CODE of MTIVLOTHIS is 'IN' or 'CV' -> Update history TRAN_CMF_1 */
    DBC_update_mtivlothis(1, &MTIVLOTHIS_OLD);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTHIS UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS_OLD.LOT_ID), MTIVLOTHIS_OLD.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTHIS_OLD.OPER), MTIVLOTHIS_OLD.OPER);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS_OLD.HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_SYSTEM;    gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    } 

    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

    MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;
    
    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_IQC, strlen(MP_INV_TRAN_CODE_IQC));
    memset(MTIVLOTSTS.LAST_TRAN_TYPE, ' ', sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));
    MTIVLOTSTS.INSPECTION_FLAG = TRS.get_char(in_node, "INSPECTION_FLAG");
    MTIVLOTSTS.INSPECTION_RESULT = TRS.get_char(in_node, "PASS_FLAG");
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "COMMENT");

    if (MTIVLOTSTS.INSPECTION_FLAG == 'I')
    {
        TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_1");
        TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_2");
        TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_3");
        TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_4");
        TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_5");
        TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_6");
        TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_7");
        TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_8");
        TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_9");
        TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_10");
        TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_11");
        TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_12");
        TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_13");
        TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_14");
        TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_15");
        TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_16");
        TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_17");
        TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_18");
        TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_19");
        TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_20");
    }

    DBC_init_mtivlothis(&MTIVLOTHIS);
    /* Lot Status & History Update Insert */
    if(TIV_update_insert_lot_status_history(s_msg_code, 
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

     //MTIVIQCHIS
    DBC_init_mtiviqchis(&MTIVIQCHIS);
    TRS.copy(MTIVIQCHIS.FACTORY, sizeof(MTIVIQCHIS.FACTORY), in_node, IN_FACTORY);
    DBC_select_mtiviqchis(2, &MTIVIQCHIS);//단순히 HIST_SEQ얻기 위해 
    {
        memcpy(MTIVIQCHIS.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVIQCHIS.FACTORY));
        memcpy(MTIVIQCHIS.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVIQCHIS.LOT_ID));
        MTIVIQCHIS.LOT_HIST_SEQ = MTIVLOTHIS.HIST_SEQ;
        memcpy(MTIVIQCHIS.TRAN_TIME, s_tran_time, sizeof(MTIVIQCHIS.TRAN_TIME));
        MTIVIQCHIS.PASS_FAIL_FLAG = TRS.get_char(in_node, "PASS_FLAG");
        MTIVIQCHIS.SAMPLE_SIZE = TRS.get_int(in_node, "SAMPLE_SIZE");
        MTIVIQCHIS.TOTAL_DEF_QTY = TRS.get_double(in_node, "TOTAL_DEF_QTY");
        DBC_insert_mtiviqchis(&MTIVIQCHIS);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "INV-0004");
            TRS.add_fieldmsg(out_node, "MTIVIQCHIS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVIQCHIS.LOT_ID), MTIVIQCHIS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
  
    /* Get material information */
    DBC_init_mtivmatdef(&MTIVMATDEF);
    memcpy(MTIVMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVMATDEF.FACTORY));
    memcpy(MTIVMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
    MTIVMATDEF.MAT_VER = TRS.get_int(in_node, "MAT_VER");    
    DBC_select_mtivmatdef(1, &MTIVMATDEF);
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
        TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

	/*Get Attribute Value pushpullflag*/
	DBC_init_matrnamsts(&MATRNAMSTS);
    TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_MATERIAL, sizeof(MATRNAMSTS.ATTR_TYPE));
    memcpy(MATRNAMSTS.ATTR_NAME, "PushPullFlag", strlen(MP_ATTR_TIV_LOT_GROUP)); 
    memcpy(MATRNAMSTS.ATTR_KEY, MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
    i_mat_ver = MTIVMATDEF.MAT_VER;
    memcpy(MATRNAMSTS.ATTR_KEY + COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))," : ", 3);
    MATRNAMSTS.ATTR_KEY[COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))+1]=i_mat_ver + 48;
    DBC_select_matrnamsts(1, &MATRNAMSTS);
    if(DB_error_code != DB_SUCCESS)
    {
		if(DB_error_code != DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
			
            TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
		    TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
		    TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
		    TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
		}
    }

    /* P : Pass, F : Fail , S : 특채 */
    if(TRS.get_char(in_node, "PASS_FLAG") == 'P' || TRS.get_char(in_node, "PASS_FLAG") == 'S')
    {    
        /*
        NORMAL은 다음 공정으로 이송해야 하나, PULL FLAG 체크 일시 해당 공정에서 대기한다.
        */

		/*Compare With PushPullFlag*/
		if(memcmp(MATRNAMSTS.ATTR_VALUE, "Y", strlen("Y"))!= 0)
		{
			//Transfer lot
            transfer_lot_in = TRS.create_node("TRANSFER_LOT");
                
            TRS.set_char(transfer_lot_in, "IQC_LOT", 'Y');

            TRS.add_char(transfer_lot_in, IN_PROCSTEP, TRS.get_procstep(in_node));
            TRS.add_enc_nstring(transfer_lot_in, IN_USERID, TRS.get_userid(in_node));
            TRS.add_enc_nstring(transfer_lot_in, IN_PASSWORD, TRS.get_password(in_node));
            TRS.add_char(transfer_lot_in, IN_LANGUAGE, TRS.get_language(in_node));
            TRS.add_nstring(transfer_lot_in, IN_FACTORY, TRS.get_factory(in_node));
			
            TRS.set_string(transfer_lot_in, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
            TRS.set_string(transfer_lot_in, "TIV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
            TRS.set_string(transfer_lot_in, "TIV_MAT_ID", MTIVMATDEF.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
            TRS.set_int(transfer_lot_in, "TIV_MAT_VER", MTIVMATDEF.MAT_VER);         
			TRS.set_nstring(transfer_lot_in, "FROM_OPER", TRS.get_string(in_node, "FROM_OPER"));
            TRS.set_nstring(transfer_lot_in, "OPER", TRS.get_string(in_node, "FROM_OPER"));
            TRS.set_nstring(transfer_lot_in, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));
			TRS.set_nstring(transfer_lot_in, "TO_LOCATION_NO", TRS.get_string(in_node, "TO_LOCATION_NO"));
            TRS.set_double(transfer_lot_in, "MOV_QTY",  MTIVLOTSTS.QTY_1);
            TRS.set_double(transfer_lot_in, "MOVE_QTY_1", TRS.get_double(in_node, "OUT_QTY_1"));
            if( TRS.get_char(in_node, "PASS_FLAG") == 'P')
                TRS.set_string(transfer_lot_in, "TRAN_TYPE",  MP_INV_TRAN_TYPE_MAT_TRN, strlen(MP_INV_TRAN_TYPE_MAT_TRN)); 
            else
                TRS.set_string(transfer_lot_in, "TRAN_TYPE",  MP_INV_TRAN_TYPE_SPE_TRN, strlen(MP_INV_TRAN_TYPE_SPE_TRN));

            TRS.set_nstring(transfer_lot_in, "TRAN_COMMNET", TRS.get_string(in_node, "COMMENT"));
            TRS.set_string(transfer_lot_in, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
            TRS.add_int(transfer_lot_in, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
            TRS.add_nstring(transfer_lot_in, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
            
			//Transfer로직 lot_in
			TRS.set_nstring(transfer_lot_in, "ATTR_KEY", TRS.get_string(in_node, "ATTR_KEY"));//MAT_ID
			TRS.set_nstring(transfer_lot_in, "EXPIRE_DATE", TRS.get_string(in_node, "EXPIRE_DATE"));

            //i_lot_qty
            //TRS.set_double(transfer_lot_in, "LOT_QTY_1", i_lot_qty);
            //TRS.set_double(transfer_lot_in, "TOTAL_LOSS_QTY_1", TRS.get_double(in_node, "TOTAL_LOSS_QTY_1"));

            if(TIV_TRANSFER_LOT(s_msg_code, transfer_lot_in, out_node) == MP_FALSE)
            {
                TRS.free_node(transfer_lot_in);
                return MP_FALSE;
            }

            TRS.free_node(transfer_lot_in);     
		} 
    }
    /*수입검사가 Fail인 경우*/
    else if(TRS.get_char(in_node, "PASS_FLAG") == 'F')
    {
		if(TRS.get_char(in_node, "NO_HOLD_FLAG") != 'Y')
		{
			/*Hold Transaction*/
			hold_lot_in = TRS.create_node("HOLD_LOT_IN");

			TRS.add_char(hold_lot_in, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(hold_lot_in, IN_USERID, TRS.get_userid(in_node));
			TRS.add_enc_nstring(hold_lot_in, IN_PASSWORD, TRS.get_password(in_node));
			TRS.add_char(hold_lot_in, IN_LANGUAGE, TRS.get_language(in_node));
			TRS.add_nstring(hold_lot_in, IN_FACTORY, TRS.get_factory(in_node));
			TRS.set_string(hold_lot_in, "TIV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.set_string(hold_lot_in, "MAT_ID", MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
			TRS.set_int(hold_lot_in, "MAT_VER", MTIVMATDEF.MAT_VER);
			TRS.add_string(hold_lot_in, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.set_nstring(hold_lot_in, "TRAN_COMMNET", TRS.get_string(in_node, "COMMENT"));
			TRS.set_string(hold_lot_in, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
			TRS.add_int(hold_lot_in, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
			TRS.add_nstring(hold_lot_in, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
			TRS.add_nstring(hold_lot_in, "TIV_HOLD_CODE", "IQC_FAIL");
			TRS.add_nstring(hold_lot_in, "HOLD_PASSWORD","");
			TRS.add_nstring(hold_lot_in, "COMMENT","IQC Lot Insp Fail Hold");
            /*TRS.add_nstring(hold_lot_in, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1);
            TRS.add_nstring(hold_lot_in, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2);
            TRS.add_nstring(hold_lot_in, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3);
            TRS.add_nstring(hold_lot_in, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4);
            TRS.add_nstring(hold_lot_in, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5);
            TRS.add_nstring(hold_lot_in, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6);
            TRS.add_nstring(hold_lot_in, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7);
            TRS.add_nstring(hold_lot_in, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8);
            TRS.add_nstring(hold_lot_in, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9);
            TRS.add_nstring(hold_lot_in, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10);
            TRS.add_nstring(hold_lot_in, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11);
            TRS.add_nstring(hold_lot_in, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12);
            TRS.add_nstring(hold_lot_in, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13);
            TRS.add_nstring(hold_lot_in, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14);
            TRS.add_nstring(hold_lot_in, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15);
            TRS.add_nstring(hold_lot_in, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16);
            TRS.add_nstring(hold_lot_in, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17);
            TRS.add_nstring(hold_lot_in, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18);
            TRS.add_nstring(hold_lot_in, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19);
            TRS.add_nstring(hold_lot_in, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20);*/
			if (TIV_HOLD_LOT(s_msg_code, hold_lot_in, out_node) != MP_TRUE)
			{
				TRS.free_node(hold_lot_in);
				return MP_FALSE;
			}
			TRS.free_node(hold_lot_in);
		}
    }
    
    if(COM_proc_user_routine("MES_UserTIV", "TIV_IQC_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_IQC_Lot_Validation()
        - Lot Transaction Validation Check
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_IQC_Lot_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    //struct MWIPFACDEF_TAG MWIPFACDEF;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    //struct MTIVOPRDEF_TAG MTIVOPRDEF;  
	struct MATRNAMSTS_TAG MATRNAMSTS;
	struct MSECUSRDEF_TAG MSECUSRDEF;


	char *s_Attr_Value;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    


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

	/*validation user*/
	DBC_init_msecusrdef(&MSECUSRDEF);
    TRS.copy(MSECUSRDEF.FACTORY, sizeof(MSECUSRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MSECUSRDEF.USER_ID, sizeof(MSECUSRDEF.USER_ID), in_node, "USER_ID");

    DBC_select_msecusrdef(1, &MSECUSRDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "SEC-0006");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "SEC-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node,DB_error_msg);
        }
        TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
   }

    
    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "TIV_LOT_ID");
    TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "FROM_OPER");
    DBC_select_mtivlotsts(4, &MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0030");             
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");            
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT FOR UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);        
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Lot Delete Validation */
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
    if(MTIVLOTSTS.HOLD_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0059");
        TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
	//실제로는 UNIT1만 쓰고 있음 LOSS가 존재한다면(로쓰설정이 없다면 타지 않음)
    if(TRS.get_item_count(in_node, "UNIT1") > 0 || TRS.get_item_count(in_node, "UNIT2") > 0 || TRS.get_item_count(in_node, "UNIT13") > 0)
    {
        if(TRS.get_double(in_node, "OUT_QTY_1") < -0.0005)
        {
            strcpy(s_msg_code, "WIP-0041");
            TRS.add_fieldmsg(out_node, "OUT_QTY_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY_1"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }

        /* 2005.10.13. CM Koo. */
        //if(TRS.get_double(in_node, "OUT_QTY_2") < -0.00009)
        if(TRS.get_double(in_node, "OUT_QTY_2") < -0.0005)
        {
            strcpy(s_msg_code, "WIP-0041");
            TRS.add_fieldmsg(out_node, "OUT_QTY_2", MP_DBL, TRS.get_double(in_node, "OUT_QTY_2"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }

        /* 2005.10.13. CM Koo. */
        //if(TRS.get_double(in_node, "OUT_QTY_3") < -0.00009)
        if(TRS.get_double(in_node, "OUT_QTY_3") < -0.0005)
        {
            strcpy(s_msg_code, "WIP-0041");
            TRS.add_fieldmsg(out_node, "OUT_QTY_3", MP_DBL, TRS.get_double(in_node, "OUT_QTY_3"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }

        /* 2005.10.13. CM Koo. */
        /* 소수점 4째 이하의 값은 무시 */
        //if(TRS.get_double(in_node, "OUT_QTY_1") > MTIVLOTSTS.QTY_1) 
        if(MTIVLOTSTS.QTY_1 - TRS.get_double(in_node, "OUT_QTY_1") < -0.0005) 
        {
            strcpy(s_msg_code, "WIP-0078");
            TRS.add_fieldmsg(out_node, "OUT_QTY_1", MP_DBL, TRS.get_double(in_node, "OUT_QTY_1"));
            TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;
        }        
    }

	//FLAG값에 따른 IQC처리
     /* P : Pass, F : Fail , S : 특채 */
    if(TRS.get_char(in_node, "PASS_FLAG") == 'P' || TRS.get_char(in_node, "PASS_FLAG") == 'S')
    {   //Attribute로 만들도록 한다.  
		
		s_Attr_Value = TRS.get_string(out_node, "ATTR_VALUE");

		//if(MATRNAMSTS.ATTR_VALUE != "Y")//PUSH_PULL_FLAG
		if(strcmp(s_Attr_Value, "Y")!=0)
		{            
            if(COM_isnullspace(TRS.get_string(in_node, "TO_OPER")) == MP_TRUE)
            {
                strcpy(s_msg_code, "INV-0001");
                TRS.add_fieldmsg(out_node, "TO_OPER", MP_NVST);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
        } 
    }


    if(memcmp(MTIVLOTSTS.OPER, TRS.get_string(in_node, "TO_OPER"), sizeof(MTIVLOTSTS.OPER))==0)
    {
        strcpy(s_msg_code, "INV-0028");
        TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
        TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
        TRS.add_fieldmsg(out_node, "ATTR_VALUE", MP_STR, sizeof(MATRNAMSTS.ATTR_VALUE), MATRNAMSTS.ATTR_VALUE);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }




    /*Add. 2012.12.11 JJ.OH  
	IQC OPERATION VALIDATION*/
	DBC_init_matrnamsts(&MATRNAMSTS);
	TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MATRNAMSTS.ATTR_TYPE, "TIV_OPER", strlen("TIV_OPER")); 
	memcpy(MATRNAMSTS.ATTR_NAME, "IQCOper", strlen("IQCOper"));
	TRS.copy(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY), in_node, "OPER");
    DBC_select_matrnamsts(1, &MATRNAMSTS);//ATTR_VALUE만 가지고온다. 
    if(DB_error_code != DB_SUCCESS)
    {
		if(DB_error_code != DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
			
            TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
		    TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
		    TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
		    TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
		}
    }

	if(memcmp(MATRNAMSTS.ATTR_VALUE, "Y", strlen("Y"))!=0)
	{
		strcpy(s_msg_code, "INV-0017");
        TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
        TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
        TRS.add_fieldmsg(out_node, "ATTR_VALUE", MP_STR, sizeof(MATRNAMSTS.ATTR_VALUE), MATRNAMSTS.ATTR_VALUE);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

    return MP_TRUE;
}




