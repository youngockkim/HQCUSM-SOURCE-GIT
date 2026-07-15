/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_Inspection_Lot.c
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
 

int TIV_Inspection_Lot_Validation(char *Msg_Code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    TIV_Inspection_Lot()
        - IQC Lot Transaction Process
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_Inspection_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_INSPECTION_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_INSPECTION_LOT", out_node);

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
    TIV_INSPECTION_LOT()
        - IQC Lot
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_INSPECTION_LOT(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
	//struct CTIVISPHIS_TAG CTIVISPHIS;
     
	int i_step;
     
	TRSNode * Hold_INV_Lot_In;
	TRSNode * hold_inv_lot_list;

	TRSNode * Release_INV_Lot_In;
	TRSNode * release_inv_lot_list;


	TRSNode * Loss_Lot_In;
	TRSNode * list_item;

	//char c_proc_step;
	char s_insp_result[10];

    char    s_sys_time[14];
	char    s_tran_time[14];
	char    s_erp_tran_time[14];

    LOG_head("TIV_INSPECTION_LOT");
    COM_log_add_field_msg(in_node);    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_Inspection_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    TRS.set_nstring(in_node, "__FACTORY", TRS.get_string(in_node, IN_FACTORY));
    TRS.set_nstring(in_node, "__OPER", TRS.get_string(in_node, "OPER"));
    if(TIV_Lot_Fill_InTag_Cmf(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    // Validation
    if(TIV_Inspection_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}

	memset(s_insp_result, ' ', sizeof(s_insp_result));
    memset(s_erp_tran_time, ' ', sizeof(s_erp_tran_time));
	memset(s_tran_time, ' ', sizeof(s_tran_time));
	memset(s_sys_time, ' ', sizeof(s_sys_time));

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

	if (CUS_Get_Time_Info(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
	{
		return MP_FALSE;
	}

	TRS.set_nstring(in_node, "WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
	TRS.set_nstring(in_node, "SHIFT", TRS.get_string(in_node, "__SHIFT"));
	TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "__SYS_TIME");
	TRS.copy(s_tran_time, sizeof(s_tran_time), in_node, "__TRAN_TIME");
	TRS.copy(s_erp_tran_time, sizeof(s_erp_tran_time), in_node, "__ERP_TRAN_TIME");


    DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
    TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");
	TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "TIV_OPER"); 

	i_step = 2;
    DBC_select_mtivlotsts_for_update(i_step, &MTIVLOTSTS_OLD);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0022");             
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

	if (MTIVLOTSTS_OLD.HOLD_FLAG == 'Y')
	{
		Release_INV_Lot_In = TRS.add_node(in_node, "RELEASE_INV_LOT_IN");
		//Create_Lot_In = TRS.create_node("CREATE_INV_LOT_ID");
		TRS.add_char(Release_INV_Lot_In, IN_PROCSTEP, '2');
		TRS.add_enc_nstring(Release_INV_Lot_In, IN_USERID, TRS.get_userid(in_node));
		TRS.add_char(Release_INV_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(Release_INV_Lot_In, IN_FACTORY, TRS.get_factory(in_node));
		TRS.add_nstring(Release_INV_Lot_In, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));
		if (COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_FALSE)
		{
			TRS.add_nstring(Release_INV_Lot_In, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
		}
		TRS.add_nstring(Release_INV_Lot_In, "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
		TRS.add_nstring(Release_INV_Lot_In, "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
		TRS.add_nstring(Release_INV_Lot_In, "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
		TRS.add_nstring(Release_INV_Lot_In, "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
		TRS.add_nstring(Release_INV_Lot_In, "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
		TRS.add_char(Release_INV_Lot_In, "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));
		TRS.add_char(Release_INV_Lot_In, "__GET_TIME_INFO_FLAG", 'Y');

		TRS.add_string(Release_INV_Lot_In, "RELEASE_CODE", MP_RELEASE_CODE_QC_REINSP, strlen(MP_RELEASE_CODE_QC_REINSP));
					 
		release_inv_lot_list = TRS.add_node(Release_INV_Lot_In, "DATA_LIST");
		TRS.set_string(release_inv_lot_list, "TIV_LOT_ID", MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID));
		TRS.set_string(release_inv_lot_list, "INV_LOT_ID", MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID));
		TRS.set_string(release_inv_lot_list, "OPER", MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER));
		TRS.set_string(release_inv_lot_list, "TIV_OPER", MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER));
		TRS.set_string(release_inv_lot_list, "MAT_ID", MTIVLOTSTS_OLD.MAT_ID, sizeof(MTIVLOTSTS_OLD.MAT_ID));
		TRS.set_int(release_inv_lot_list, "MAT_VER", MTIVLOTSTS_OLD.MAT_VER);
		TRS.set_string(release_inv_lot_list, "TIV_MAT_ID", MTIVLOTSTS_OLD.MAT_ID, sizeof(MTIVLOTSTS_OLD.MAT_ID));
		TRS.set_int(release_inv_lot_list, "TIV_MAT_VER", MTIVLOTSTS_OLD.MAT_VER);
						 
		if(TIV_RELEASE_LOT(s_msg_code, Release_INV_Lot_In, out_node) == MP_FALSE)
		{			
			return MP_FALSE;
		}

		DBC_init_mtivlotsts(&MTIVLOTSTS_OLD);
		TRS.copy(MTIVLOTSTS_OLD.FACTORY, sizeof(MTIVLOTSTS_OLD.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVLOTSTS_OLD.LOT_ID, sizeof(MTIVLOTSTS_OLD.LOT_ID), in_node, "TIV_LOT_ID");
		TRS.copy(MTIVLOTSTS_OLD.OPER, sizeof(MTIVLOTSTS_OLD.OPER), in_node, "TIV_OPER"); 

		i_step = 4;
		DBC_select_mtivlotsts(i_step, &MTIVLOTSTS_OLD);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0022");             
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

	}


    memcpy(&MTIVLOTSTS, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS));

    
    MTIVLOTSTS.LAST_HIST_SEQ = MTIVLOTSTS_OLD.LAST_HIST_SEQ + 1;
    MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = MTIVLOTSTS.LAST_HIST_SEQ;
    
    memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_INSPECTION, strlen(MP_INV_TRAN_CODE_INSPECTION));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE,  sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), in_node, "TRAN_TYPE");
    MTIVLOTSTS.INSPECTION_FLAG = TRS.get_char(in_node, "INSP_TYPE");
    MTIVLOTSTS.INSPECTION_RESULT = TRS.get_char(in_node, "INSP_RESULT");
    memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_tran_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
    TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT,  sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), in_node, "TRAN_COMMENT");

	memcpy(MTIVLOTSTS.INV_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));

    //TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "INV_CMF_1");
    
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

	TRS.copy(MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID), in_node, "PRC_USER");
	
    DBC_init_mtivlothis(&MTIVLOTHIS);

	TRS.copy(MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS.TRAN_CMF_8, sizeof(MTIVLOTHIS.TRAN_CMF_8), in_node, "SHIFT");

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

	//DBC_init_ctivisphis(&CTIVISPHIS);
	//
	//memcpy(CTIVISPHIS.FACTORY, MTIVLOTSTS.FACTORY, sizeof(CTIVISPHIS.FACTORY));
	//memcpy(CTIVISPHIS.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(CTIVISPHIS.LOT_ID));
	//memcpy(CTIVISPHIS.OPER, MTIVLOTSTS.OPER, sizeof(CTIVISPHIS.OPER));
	//CTIVISPHIS.HIST_SEQ = MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ;
	//memcpy(CTIVISPHIS.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(CTIVISPHIS.MAT_ID));
	//CTIVISPHIS.MAT_VER = MTIVLOTSTS.MAT_VER;
	// 
	//CTIVISPHIS.QTY_1 = MTIVLOTSTS.QTY_1;
 //   CTIVISPHIS.QTY_2 = MTIVLOTSTS.QTY_2;
 //   CTIVISPHIS.QTY_3 = MTIVLOTSTS.QTY_3;

	//CTIVISPHIS.SAMPLE_QTY_1 = MTIVLOTSTS.QTY_1;
 //   CTIVISPHIS.SAMPLE_QTY_2 = MTIVLOTSTS.QTY_2;
 //   CTIVISPHIS.SAMPLE_QTY_3 = MTIVLOTSTS.QTY_3;

 //   CTIVISPHIS.INSPECTION_FLAG = MTIVLOTSTS.INSPECTION_FLAG;
 //   CTIVISPHIS.INSPECTION_RESULT = MTIVLOTSTS.INSPECTION_RESULT;

	//memcpy(CTIVISPHIS.TRAN_TIME, MTIVLOTSTS.LAST_TRAN_TIME, sizeof(CTIVISPHIS.TRAN_TIME));
	//memcpy(CTIVISPHIS.SYS_TRAN_TIME, s_sys_time, sizeof(s_sys_time));


	//TRS.copy(CTIVISPHIS.QC_USER_ID, sizeof(CTIVISPHIS.QC_USER_ID), in_node, "PRC_USER");

	//
 //   //TRS.copy(CTIVISPHIS.ISP_CMF_1, sizeof(CTIVISPHIS.ISP_CMF_1), in_node, "ISP_CMF_1");
 //   //TRS.copy(CTIVISPHIS.ISP_CMF_2, sizeof(CTIVISPHIS.ISP_CMF_2), in_node, "ISP_CMF_2");
	//memcpy(CTIVISPHIS.ISP_CMF_1, s_erp_tran_time, sizeof(s_erp_tran_time));
	//TRS.copy(CTIVISPHIS.ISP_CMF_2, sizeof(CTIVISPHIS.ISP_CMF_2), in_node, "WORK_DATE");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_3, sizeof(CTIVISPHIS.ISP_CMF_3), in_node, "ISP_CMF_3");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_4, sizeof(CTIVISPHIS.ISP_CMF_4), in_node, "ISP_CMF_4");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_5, sizeof(CTIVISPHIS.ISP_CMF_5), in_node, "ISP_CMF_5");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_6, sizeof(CTIVISPHIS.ISP_CMF_6), in_node, "ISP_CMF_6");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_7, sizeof(CTIVISPHIS.ISP_CMF_7), in_node, "ISP_CMF_7");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_8, sizeof(CTIVISPHIS.ISP_CMF_8), in_node, "ISP_CMF_8");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_9, sizeof(CTIVISPHIS.ISP_CMF_9), in_node, "ISP_CMF_9");
 //   TRS.copy(CTIVISPHIS.ISP_CMF_10, sizeof(CTIVISPHIS.ISP_CMF_10), in_node, "ISP_CMF_10");

	//memcpy(CTIVISPHIS.LOT_GROUP_ID, MTIVLOTSTS.LOT_GROUP_ID, sizeof(CTIVISPHIS.LOT_GROUP_ID));
 // 
 //   DBC_insert_ctivisphis(&CTIVISPHIS);        
 //   if(DB_error_code != DB_SUCCESS) 
 //   {
 //       strcpy(s_msg_code, "WIP-0004");
 //       TRS.add_fieldmsg(out_node, "CTIVISPHIS INSERT", MP_NVST);
	//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(CTIVISPHIS.FACTORY), CTIVISPHIS.FACTORY);
	//	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(CTIVISPHIS.LOT_ID), CTIVISPHIS.LOT_ID);
	//	TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CTIVISPHIS.HIST_SEQ);
 //           
 //       TRS.add_dberrmsg(out_node, DB_error_msg);

 //       gs_log_type.type = MP_LOG_ERROR;
 //       gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //       gs_log_type.category = MP_LOG_CATE_SETUP;

 //       COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
 //       return MP_FALSE;
 //   }

	if (TRS.get_char(in_node, "AUTO_LOSS_FLAG") == 'Y')
	{
		Loss_Lot_In = TRS.add_node(in_node, "LOSS_INV_LOT_ID");	
		TRS.add_char(Loss_Lot_In, IN_PROCSTEP, '1');
		TRS.add_enc_nstring(Loss_Lot_In, IN_USERID, TRS.get_userid(in_node));
		TRS.add_char(Loss_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(Loss_Lot_In, IN_FACTORY, TRS.get_factory(in_node));
		TRS.add_nstring(Loss_Lot_In, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));
		if (COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_FALSE)
		{
			TRS.add_nstring(Loss_Lot_In, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
		}
		TRS.add_nstring(Loss_Lot_In, "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
		TRS.add_nstring(Loss_Lot_In, "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
		TRS.add_nstring(Loss_Lot_In, "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
		TRS.add_nstring(Loss_Lot_In, "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
		TRS.add_nstring(Loss_Lot_In, "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
		TRS.add_char(Loss_Lot_In, "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));
		TRS.add_char(Loss_Lot_In, "__GET_TIME_INFO_FLAG", 'Y');

		TRS.set_string(Loss_Lot_In, "INV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		TRS.set_string(Loss_Lot_In, "TIV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		TRS.set_int(Loss_Lot_In, "LAST_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);

		TRS.set_string(Loss_Lot_In, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		TRS.set_string(Loss_Lot_In, "TIV_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			
		TRS.set_string(Loss_Lot_In, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
		TRS.set_string(Loss_Lot_In, "TIV_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
			  
		TRS.set_int(Loss_Lot_In, "MAT_VER", MTIVLOTSTS.MAT_VER);
		TRS.set_int(Loss_Lot_In, "TIV_MAT_VER", MTIVLOTSTS.MAT_VER);
	  
		TRS.set_double(Loss_Lot_In, "OUT_QTY_1", 0);
		 
		s_insp_result[0] = TRS.get_char(in_node, "INSP_TYPE");

		list_item = TRS.add_node(Loss_Lot_In, "UNIT1");
		TRS.set_string(list_item, "CODE", s_insp_result, sizeof(s_insp_result));
		TRS.set_double(list_item, "QTY", MTIVLOTSTS.QTY_1);
		TRS.set_char(list_item,	"NO_SCRAP_FLAG", ' ');	
		 
		if(TIV_LOSS_LOT(s_msg_code, Loss_Lot_In, out_node) == MP_FALSE)
		{			
			return MP_FALSE;
		}
	}
	else if (TRS.get_char(in_node, "INSP_RESULT") == MP_TIV_INSP_RESULT_FAIL)
	{
		Hold_INV_Lot_In = TRS.add_node(in_node, "HOLD_INV_LOT_IN");
		//Create_Lot_In = TRS.create_node("CREATE_INV_LOT_ID");
		TRS.add_char(Hold_INV_Lot_In, IN_PROCSTEP, '2');
		TRS.add_enc_nstring(Hold_INV_Lot_In, IN_USERID, TRS.get_userid(in_node));
		TRS.add_char(Hold_INV_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(Hold_INV_Lot_In, IN_FACTORY, TRS.get_factory(in_node));

		TRS.add_nstring(Hold_INV_Lot_In, "PRC_USER", TRS.get_string(in_node, "PRC_USER"));

		if (COM_isnullspace(TRS.get_string(in_node, "BACK_TIME")) == MP_FALSE)
		{
			TRS.add_nstring(Hold_INV_Lot_In, "BACK_TIME", TRS.get_string(in_node, "BACK_TIME"));
		}
		TRS.add_nstring(Hold_INV_Lot_In, "__WORK_DATE", TRS.get_string(in_node, "__WORK_DATE"));
		TRS.add_nstring(Hold_INV_Lot_In, "__SHIFT", TRS.get_string(in_node, "__SHIFT"));
		TRS.add_nstring(Hold_INV_Lot_In, "__SYS_TIME", TRS.get_string(in_node, "__SYS_TIME"));
		TRS.add_nstring(Hold_INV_Lot_In, "__TRAN_TIME", TRS.get_string(in_node, "__TRAN_TIME"));
		TRS.add_nstring(Hold_INV_Lot_In, "__ERP_TRAN_TIME", TRS.get_string(in_node, "__ERP_TRAN_TIME"));
		TRS.add_char(Hold_INV_Lot_In, "__ERP_BACK_TIME_FLAG", TRS.get_char(in_node, "__ERP_BACK_TIME_FLAG"));
		TRS.add_char(Hold_INV_Lot_In, "__GET_TIME_INFO_FLAG", 'Y');

		TRS.add_string(Hold_INV_Lot_In, "INV_HOLD_CODE", MP_HOLD_CODE_QC_FAIL, strlen(MP_HOLD_CODE_QC_FAIL));
		TRS.add_string(Hold_INV_Lot_In, "TIV_HOLD_CODE", MP_HOLD_CODE_QC_FAIL, strlen(MP_HOLD_CODE_QC_FAIL));

		hold_inv_lot_list = TRS.add_node(Hold_INV_Lot_In, "DATA_LIST");
		TRS.set_string(hold_inv_lot_list, "TIV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		TRS.set_string(hold_inv_lot_list, "INV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		TRS.set_string(hold_inv_lot_list, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		TRS.set_string(hold_inv_lot_list, "TIV_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
		TRS.set_string(hold_inv_lot_list, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
		TRS.set_int(hold_inv_lot_list, "MAT_VER", MTIVLOTSTS.MAT_VER);
		TRS.set_string(hold_inv_lot_list, "TIV_MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
		TRS.set_int(hold_inv_lot_list, "TIV_MAT_VER", MTIVLOTSTS.MAT_VER);
						 
		if(TIV_HOLD_LOT(s_msg_code, Hold_INV_Lot_In, out_node) == MP_FALSE)
		{			
			return MP_FALSE;
		}
	}


    if(COM_proc_user_routine("MES_UserTIV", "TIV_Inspection_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_Inspection_Lot_Validation()
        - Lot Transaction Validation Check
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_Inspection_Lot_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    //struct MTIVMATDEF_TAG MWIPMATDEF;
    //struct MWIPFLWDEF_TAG MWIPFLWDEF;
    //struct MWIPOPRDEF_TAG MWIPOPRDEF;    
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    //struct MWIPMHDSTS_TAG MWIPMHDSTS;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* validation input value */
    if(TIV_lot_tran_validation(s_msg_code,
                               out_node,
                               in_node,
                               &MTIVLOTSTS,
                               &MWIPFACDEF,
                               &MWIPMATDEF,
                               &MTIVOPRDEF) == MP_FALSE)
    {
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

    ///* Lot Hold Validation */
    //if(MTIVLOTSTS.HOLD_FLAG == 'Y')
    //{
    //    strcpy(s_msg_code, "WIP-0059");
    //    TRS.add_fieldmsg(out_node, "TIV_LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

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
 
    return MP_TRUE;
}
