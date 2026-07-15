/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_transfer_confirm.c
    Description : Transfer Confirm Transaction

    MES Version : 5.2.0.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/11/08   JJ OH        Update

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

/**********************************************************/
/* INV Doc Type                                   */
/**********************************************************/
#define MP_INV_DOC_TYPE_TIV_REQ         ('R')           //품목 단위 요청
#define MP_INV_DOC_TYPE_TRANSFER         ('T')          //LOT 단위 요청

#include "TIVCore_common.h"

int TIV_Transfer_Confirm_Validation(char *s_msg_code,
                                         TRSNode *in_node, 
                                         TRSNode *out_node);

/*******************************************************************************
    TIV_Transfer_Confirm()
        - Transfer Confirm Transaction
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_Transfer_Confirm(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_TRANSFER_CONFIRM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_TRANSFER_CONFIRM", out_node);

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
    TIV_Transfer_Confirm()
        - Transfer Confirm Transaction
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_TRANSFER_CONFIRM(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    struct MATRNAMSTS_TAG MATRNAMSTS;
    struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MTIVTRSHIS_TAG MTIVTRSHIS;

	TRSNode **mat_list;
    TRSNode **lot_list;
    TRSNode *transfer_lot_in;

    int i = 0;   
	int j = 0;	
    int i_mat_ver = 0;
    //double d_sum_lot_qty = 0;

    char s_sys_time[14];

    LOG_head("TIV_Transfer_Confirm");
    COM_log_add_field_msg(in_node);    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Confirm",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    // get the system time
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime()", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }    

    if(TIV_Transfer_Confirm_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    
	//강제 완료
	if(TRS.get_char(in_node, "COMPLETE_FLAG") == 'Y')
	{
		// Request Master Insert

		if(TIV_Update_TRS_Master(s_msg_code,  MP_STEP_UPDATE, TRS.get_string(in_node, "TRS_NO"),
								in_node, out_node) == MP_FALSE) 
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		if(TIV_Update_TRS_Detail(s_msg_code,  '1', TRS.get_string(in_node, "TRS_NO"),
                                "", "",
								in_node, out_node) == MP_FALSE) 
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}		
	}
	else
	{
		mat_list = TRS.get_list(in_node, "MAT_LIST");
		for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
		{		
            //강제 완료
            if(TRS.get_char(mat_list[i], "COMPLETE_FLAG") == 'Y')
            {
                TRS.set_nstring(mat_list[i], IN_FACTORY, TRS.get_factory(in_node));
                TRS.set_char(mat_list[i], IN_LANGUAGE, TRS.get_language(in_node));
                TRS.set_enc_nstring(mat_list[i], IN_USERID, TRS.get_userid(in_node));
                TRS.set_enc_nstring(mat_list[i], IN_PASSWORD, TRS.get_password(in_node));

                if(TIV_Update_TRS_Detail(s_msg_code,  '1', TRS.get_string(in_node, "TRS_NO"),
                    TRS.get_string(mat_list[i], "MAT_ID"), "",
                    mat_list[i], out_node) == MP_FALSE) 
                {
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                continue;	
            }

			lot_list = TRS.get_list(mat_list[i], "LOT_LIST");
            for (j = 0; j < TRS.get_item_count(mat_list[i], "LOT_LIST"); j++)
			{		
                //강제 완료
                if(TRS.get_char(lot_list[j], "COMPLETE_FLAG") == 'Y')
                {
                    TRS.set_nstring(lot_list[j], IN_FACTORY, TRS.get_factory(in_node));
                    TRS.set_char(lot_list[j], IN_LANGUAGE, TRS.get_language(in_node));
                    TRS.set_enc_nstring(lot_list[j], IN_USERID, TRS.get_userid(in_node));
			        TRS.set_enc_nstring(lot_list[j], IN_PASSWORD, TRS.get_password(in_node));

                    if(TIV_Update_TRS_Detail(s_msg_code,  '1', TRS.get_string(in_node, "TRS_NO"),
                        TRS.get_string(mat_list[i], "MAT_ID"), TRS.get_string(lot_list[j], "LOT_ID"),
                        lot_list[j], out_node) == MP_FALSE) 
                    {
                        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                        return MP_FALSE;
                    }

                    continue;
                }

                //Get Lot information
				DBC_init_mtivlotsts(&MTIVLOTSTS);
				TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), lot_list[j], "LOT_ID");	
				TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), lot_list[j], "OPER");
				DBC_select_mtivlotsts(4, &MTIVLOTSTS);
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
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);				

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

                if(MTIVLOTSTS.QTY_1 < TRS.get_double(lot_list[j], "MOVE_QTY"))
                {
                    strcpy(s_msg_code, "INV-0027");
                    TRS.add_fieldmsg(out_node, "QTY Validation", MP_NVST);
					TRS.add_fieldmsg(out_node, "QTY_1", MP_DBL, MTIVLOTSTS.QTY_1);
                    TRS.add_fieldmsg(out_node, "INPUT_QTY", MP_DBL, TRS.get_double(lot_list[j], "MOVE_QTY"));
                    TRS.add_fieldmsg(out_node, "OVER QTY", MP_DBL, TRS.get_double(lot_list[j], "MOVE_QTY")-MTIVLOTSTS.QTY_1);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;	
                }


                DBC_init_mtivoprdef(&MTIVOPRDEF);
                TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
                memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));   
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

				//요청 품목과 다릅니다.
				if(TRS.mem_cmp(mat_list[i], "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID)) != 0)
				{
					strcpy(s_msg_code, "WIP-0064");
					TRS.add_fieldmsg(out_node, "MTIVREQDTL UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);
					TRS.add_fieldmsg(out_node, "REQ_MAT_ID", MP_NSTR, TRS.get_string(mat_list[i], "MAT_ID"));

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;				
				}
				

				//inspection detail information update
				DBC_init_mtivtrsdtl(&MTIVTRSDTL);
				TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
				TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");			
				memcpy(MTIVTRSDTL.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID));
                MTIVTRSDTL.MAT_VER = TRS.get_int(mat_list[i], "MAT_VER");
				if (TRS.get_char(in_node, "DOC_TYPE") != MP_INV_DOC_TYPE_TRANSFER)       //T 이송처리만 LOT 존재, R은 품목단위 요청
				{
					memcpy(MTIVTRSDTL.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID));
				}
				DBC_select_mtivtrsdtl_for_update(1, &MTIVTRSDTL);
				if(DB_error_code != DB_SUCCESS) 
				{
					strcpy(s_msg_code, "INV-0017");
					TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);				
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
					TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;              
				}

                /*Material Select*/
                DBC_init_mtivmatdef(&MTIVMATDEF);
                memcpy(MTIVMATDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVMATDEF.FACTORY));
                memcpy(MTIVMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
                MTIVMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
                DBC_select_mtivmatdef(1, &MTIVMATDEF);
                if(DB_error_code != DB_SUCCESS) 
                {
                    if(DB_error_code == DB_NOT_FOUND)
                    {
                        strcpy(s_msg_code, "INV-0006");
                        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    }
                    else 
                    {
                        strcpy(s_msg_code, "INV-0004");            
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    }
                    TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
                    TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.category = MP_LOG_CATE_TRANS;
                    return MP_FALSE;
                }

                 /*LotGroup*/
                DBC_init_matrnamsts(&MATRNAMSTS);
	            TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	            memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_MATERIAL, sizeof(MATRNAMSTS.ATTR_TYPE));
	            memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_TIV_LOT_GROUP, strlen(MP_ATTR_TIV_LOT_GROUP));
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
                        TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
		                TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
                        TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_VIEW;

                        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                        return MP_FALSE; 
					}
                }
                
                if(memcmp(MATRNAMSTS.ATTR_VALUE, "Y", strlen("Y"))==0)//LotGroup
                {
                    MTIVTRSDTL.QTY_1 = MTIVTRSDTL.QTY_1 + TRS.get_double(lot_list[j], "MOVE_QTY");
                    MTIVTRSDTL.QTY_2 = MTIVTRSDTL.QTY_2 + TRS.get_double(lot_list[j], "QTY_2");
                    MTIVTRSDTL.REMAIN_QTY = MTIVTRSDTL.REMAIN_QTY - TRS.get_double(lot_list[j], "MOVE_QTY");
                }
                else
                {
				    MTIVTRSDTL.QTY_1 = MTIVTRSDTL.QTY_1 + MTIVLOTSTS.QTY_1;
                    MTIVTRSDTL.QTY_2 = MTIVTRSDTL.QTY_2 + MTIVLOTSTS.QTY_2;
				    MTIVTRSDTL.REMAIN_QTY = MTIVTRSDTL.REQ_QTY - MTIVTRSDTL.QTY_1;
                }

				if(MTIVTRSDTL.REMAIN_QTY <= 0)
					MTIVTRSDTL.REMAIN_QTY = 0;

                if(MTIVTRSDTL.REMAIN_QTY <= 0)
				    MTIVTRSDTL.STATUS_FLAG = MP_INV_STATUS_COMPLETE;

				/*MTIVTRSDTL.QTY_2 = MTIVLOTSTS.QTY_2;*/
				MTIVTRSDTL.QTY_3 = MTIVLOTSTS.QTY_3;		
			


				memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.UPDATE_TIME));
				TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, IN_USERID);


                
                TRS.copy(MTIVTRSDTL.UNIT_2, sizeof(MTIVTRSDTL.UNIT_2), lot_list[j], "UNIT_2");	
                TRS.copy(MTIVTRSDTL.UNIT_3, sizeof(MTIVTRSDTL.UNIT_3), lot_list[j], "UNIT_3");	
                /*MTIVTRSDTL.QTY_2 = TRS.get_double(lot_list[j], "QTY_2");*/
                MTIVTRSDTL.QTY_3 = TRS.get_double(lot_list[j], "QTY_3");

				DBC_update_mtivtrsdtl(1, &MTIVTRSDTL);
				if(DB_error_code != DB_SUCCESS) 
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MTIVTRSDTL UPDATE", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
					TRS.add_fieldmsg(out_node, "TRS_SEQ", MP_INT,  MTIVTRSDTL.TRS_SEQ);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
					TRS.add_fieldmsg(out_node, "DOC_TYPE", MP_CHR, MTIVTRSDTL.DOC_TYPE);

					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				//Transfer lot
				transfer_lot_in = TRS.create_node("TRANSFER_LOT");
                
				TRS.add_char(transfer_lot_in, IN_PROCSTEP, TRS.get_procstep(in_node));
				TRS.add_enc_nstring(transfer_lot_in, IN_USERID, TRS.get_userid(in_node));
				TRS.add_enc_nstring(transfer_lot_in, IN_PASSWORD, TRS.get_password(in_node));
				TRS.add_char(transfer_lot_in, IN_LANGUAGE, TRS.get_language(in_node));
				TRS.add_nstring(transfer_lot_in, IN_FACTORY, TRS.get_factory(in_node));
               
				//추가한 것들
				TRS.set_string(transfer_lot_in, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
                TRS.set_string(transfer_lot_in, "FROM_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
				TRS.set_string(transfer_lot_in, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
                TRS.set_string(transfer_lot_in, "TIV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
				TRS.set_string(transfer_lot_in, "TIV_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
				TRS.set_int(transfer_lot_in, "TIV_MAT_VER", MTIVLOTSTS.MAT_VER);			
				TRS.set_string(transfer_lot_in, "TO_OPER", MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER));
				TRS.set_string(transfer_lot_in, "TO_LOCATION_NO", MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSDTL.TO_LOCATION_NO));		
				TRS.set_string(transfer_lot_in, "TRAN_CODE", MTIVTRSDTL.TRS_CODE, sizeof(MTIVTRSDTL.TRS_CODE)); 
				TRS.set_string(transfer_lot_in, "TRAN_TYPE", MTIVTRSDTL.TRS_TYPE, sizeof(MTIVTRSDTL.TRS_TYPE)); 
				TRS.set_nstring(transfer_lot_in, "TRAN_COMMNET", TRS.get_string(in_node, "LAST_TRAN_COMMENT"));
				TRS.set_string(transfer_lot_in, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
				TRS.add_int(transfer_lot_in, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
                TRS.set_double(transfer_lot_in, "MOVE_QTY_1",  TRS.get_double(lot_list[j], "MOVE_QTY"));
				TRS.add_nstring(transfer_lot_in, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_1", TRS.get_string(in_node, "INV_CMF_1"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_2", TRS.get_string(in_node, "INV_CMF_2"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_3", TRS.get_string(in_node, "INV_CMF_3"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_4", TRS.get_string(in_node, "INV_CMF_4"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_5", TRS.get_string(in_node, "INV_CMF_5"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_6", TRS.get_string(in_node, "INV_CMF_6"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_7", TRS.get_string(in_node, "INV_CMF_7"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_8", TRS.get_string(in_node, "INV_CMF_8"));
				TRS.add_nstring(transfer_lot_in, "INV_CMF_9", TRS.get_string(in_node, "INV_CMF_9"));

				//Transfer NO
				TRS.add_string(transfer_lot_in, "INV_CMF_10", MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO));				

				TRS.add_nstring(transfer_lot_in, "INV_CMF_11", TRS.get_string(in_node, "INV_CMF_11"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_12", TRS.get_string(in_node, "INV_CMF_12"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_13", TRS.get_string(in_node, "INV_CMF_13"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_14", TRS.get_string(in_node, "INV_CMF_14"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_15", TRS.get_string(in_node, "INV_CMF_15"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_16", TRS.get_string(in_node, "INV_CMF_16"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_17", TRS.get_string(in_node, "INV_CMF_17"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_18", TRS.get_string(in_node, "INV_CMF_18"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_19", TRS.get_string(in_node, "INV_CMF_19"));				
				TRS.add_nstring(transfer_lot_in, "INV_CMF_20", TRS.get_string(in_node, "INV_CMF_20"));		


                  /*LotGroup*/
                DBC_init_matrnamsts(&MATRNAMSTS);
	            TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	            memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_MATERIAL, sizeof(MATRNAMSTS.ATTR_TYPE));
	            memcpy(MATRNAMSTS.ATTR_NAME, MP_ATTR_TIV_LOT_GROUP, strlen(MP_ATTR_TIV_LOT_GROUP));
                memcpy(MATRNAMSTS.ATTR_KEY, MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
                i_mat_ver = MTIVMATDEF.MAT_VER;
                memcpy(MATRNAMSTS.ATTR_KEY + COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))," : ", 3);
                MATRNAMSTS.ATTR_KEY[COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))+1]=i_mat_ver + 48;
                DBC_select_matrnamsts(1, &MATRNAMSTS);
                if(DB_error_code == DB_SUCCESS)
                {
                    TRS.add_string(transfer_lot_in, "LOT_GROUP_FLAG", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));	
                    //TRS.set_char(transfer_lot_in, "LOT_GROUP_FLAG", MATRNAMSTS.ATTR_VALUE[0]);
                }

				if(TIV_TRANSFER_LOT(s_msg_code, transfer_lot_in, out_node) == MP_FALSE)
				{
					TRS.free_node(transfer_lot_in);
					return MP_FALSE;
				}
				TRS.free_node(transfer_lot_in);         


                //history쌓기
                DBC_init_mtivtrshis(&MTIVTRSHIS);
                TRS.copy(MTIVTRSHIS.FACTORY, sizeof(MTIVTRSHIS.FACTORY), in_node, IN_FACTORY);
                TRS.copy(MTIVTRSHIS.LOT_ID, sizeof(MTIVTRSHIS.LOT_ID), lot_list[j], "LOT_ID");
                memcpy(MTIVTRSHIS.TRS_NO, MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSHIS.TRS_NO));
                DBC_select_mtivtrshis_for_update(2, &MTIVTRSHIS);
                
                TRS.copy(MTIVTRSHIS.FACTORY, sizeof(MTIVTRSHIS.FACTORY), in_node, IN_FACTORY);
                TRS.copy(MTIVTRSHIS.CREATE_USER_ID, sizeof(MTIVTRSHIS.CREATE_USER_ID), in_node, IN_USERID);
                MTIVTRSHIS.HIST_SEQ = MTIVTRSHIS.HIST_SEQ + 1;
                memcpy(MTIVTRSHIS.CREATE_TIME, s_sys_time, 14);
                memcpy(MTIVTRSHIS.TRS_NO, MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSHIS.TRS_NO));
                TRS.copy(MTIVTRSHIS.LOT_ID, sizeof(MTIVTRSHIS.LOT_ID), lot_list[j], "LOT_ID");
                memcpy(MTIVTRSHIS.FROM_OPER, MTIVTRSDTL.FROM_OPER, sizeof(MTIVTRSHIS.FROM_OPER));
                memcpy(MTIVTRSHIS.FROM_LOCATION_NO, MTIVTRSDTL.FROM_LOCATION_NO, sizeof(MTIVTRSHIS.FROM_LOCATION_NO));
                memcpy(MTIVTRSHIS.TO_OPER, MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSHIS.TO_OPER));
                memcpy(MTIVTRSHIS.TO_LOCATION_NO, MTIVTRSDTL.TO_LOCATION_NO, sizeof(MTIVTRSHIS.TO_LOCATION_NO));
                memcpy(MTIVTRSHIS.MAT_ID, MTIVTRSDTL.MAT_ID, sizeof(MTIVTRSHIS.MAT_ID));
                MTIVTRSHIS.MAT_VER = MTIVTRSDTL.MAT_VER;
                MTIVTRSHIS.QTY_1 = TRS.get_double(lot_list[j], "MOVE_QTY");
                MTIVTRSHIS.QTY_2 = TRS.get_double(lot_list[j], "QTY_2");
                memcpy(MTIVTRSHIS.UNIT_1, MTIVTRSDTL.UNIT_1, sizeof(MTIVTRSHIS.UNIT_1));
                memcpy(MTIVTRSHIS.UNIT_2, MTIVTRSDTL.UNIT_2, sizeof(MTIVTRSHIS.UNIT_2));
                DBC_insert_mtivtrshis(&MTIVTRSHIS);
                if(DB_error_code != DB_SUCCESS) 
				{
					strcpy(s_msg_code, "INV-0004");
					TRS.add_fieldmsg(out_node, "MTIVTSHIS INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSHIS.FACTORY), MTIVTRSHIS.FACTORY);
					TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSHIS.TRS_NO), MTIVTRSHIS.TRS_NO);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSHIS.LOT_ID), MTIVTRSHIS.LOT_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSHIS.MAT_ID), MTIVTRSHIS.MAT_ID);
                    TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVTRSHIS.HIST_SEQ);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
          

                
			}
		}

		//inspection detail information update
		DBC_init_mtivtrsdtl(&MTIVTRSDTL);
		TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");	

		if(DBC_select_mtivtrsdtl_scalar(2, &MTIVTRSDTL) == 0)	
		{
            TRS.set_char(in_node, "STATUS_FLAG", MP_INV_STATUS_COMPLETE);//Complete Flag
		}
        else
        {
            TRS.set_char(in_node, "STATUS_FLAG", MP_INV_STATUS_PROCESSING);//Processing Flag
        }

		// Request Master Insert
		if(TIV_Update_TRS_Master(s_msg_code,  MP_STEP_UPDATE, MTIVTRSDTL.TRS_NO,
								 in_node, out_node) == MP_FALSE) 
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
    
    if(COM_proc_user_routine("MES_UserTIV", "TIV_Transfer_Confirm",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Transfer_Confirm_Validation()
        - Validation Check sub function of "TIV_Transfer_Confirm" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - ALM_in_node_Tag *in_node : Input Message structure
        - out_node_Tag *out_node : Output Message structure
*******************************************************************************/
int TIV_Transfer_Confirm_Validation(char *s_msg_code,
                                         TRSNode *in_node, 
                                         TRSNode *out_node)
{
	struct MTIVTRSMST_TAG MTIVTRSMST;

     /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Validation for factory */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, IN_FACTORY, MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Validation for user id */
    if(COM_isnullspace(TRS.get_userid(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, IN_USERID, MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/* inspection master information Insert Or Update */
    DBC_init_mtivtrsmst(&MTIVTRSMST);
    TRS.copy(MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");	

    DBC_select_mtivtrsmst(1, &MTIVTRSMST);
    if(DB_error_code != DB_SUCCESS) 
    {        
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
        TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;                      
    }

	if(MTIVTRSMST.STATUS_FLAG == MP_INV_STATUS_COMPLETE)
	{
		strcpy(s_msg_code, "INV-0029");        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;               
	}

    return MP_TRUE;
}