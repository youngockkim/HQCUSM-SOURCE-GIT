/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : CINV_in_lot_mes.c
    Description : Transaction Lot Material In function module

    MES Version : 5.2.0

    Function List
        - INV_In_Lot()
            + Transaction In Lot Material Inventory
        - INV_IN_LOT()
            + Main Sub function of "INV_In_Lot"
            + (called by "INV_In_Lot")
        - INV_In_Lot_Validation()
            + Validation Check sub function of "INV_IN_LOT" function
            + (called by "CINV_IN_LOT_MES")
       
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/24  hans         Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

#include <WIPCore_common.h>
#include <RASCore_common.h>

#define MP_RULE_ID_DEFAULT_TOOL ("TOOL_ID")

int INV_In_Lot_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node);


/*******************************************************************************
    INV_In_Lot()
        - Lot Material In Inventory
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - INV_In_Lot_In_Tag *INV_In_Mes_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int INV_In_Lot(TRSNode *in_node, 
                  TRSNode *out_node)
{
    /*struct MTIVOPRDEF_TAG       MTIVOPRDEF;
    struct MTIVOPRDEF_TAG       MTIVOPRDEF_OLD;*/
    struct MWIPMATDEF_TAG       MWIPMATDEF;
	struct MWIPOPRDEF_TAG       MWIPOPRDEF;
	struct MWIPOPRDEF_TAG       MWIPOPRDEF_OLD;


    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
    
    /*------------------------------------------------------------------------------------
	 * ERP Inteface 호출
	 * ==> 자재입고실적 : 입고 실적
     * 대기공정 -> 입고승인 -> 자재창고 
     * => PDA 입고분에 대해 입고승인시 자재창고 이동시 입고실적 처리
     * FROM OPER가 대기창고인 경우만 처리
     * 대기창고가 아닌경우 이송실적 처리
     * FROM_OPER 가 공백이고 TO_OPER 가 자재창고 인경우 처리안함
	-------------------------------------------------------------------------------------*/
    DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "MAT_ID");

    DBC_select_mwipmatdef(1, &MWIPMATDEF);

    DBC_init_mwipoprdef(&MWIPOPRDEF_OLD);
    TRS.copy(MWIPOPRDEF_OLD.FACTORY, sizeof(MWIPOPRDEF_OLD.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPOPRDEF_OLD.OPER, sizeof(MWIPOPRDEF_OLD.OPER), in_node, "FROM_OPER");

    DBC_select_mwipoprdef(1, &MWIPOPRDEF);

    DBC_init_mwipoprdef(&MWIPOPRDEF);
    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "TO_OPER");

    DBC_select_mwipoprdef(1, &MWIPOPRDEF);

    ////TRANSFER 발생중 FROM_OPER 가 입고대기이고 FROM 창고가 창고인경우 입고처리 -> Client 입고처리시 사용
    //if(MTIVOPRDEF.INV_WH_FLAG == 'Y' && MTIVOPRDEF_OLD.INV_INTRANSIT_FLAG == 'Y' && MWIPMATDEF.IQC_FLAG != 'Y')
    //{
    //    if(CCOM_ERP_UPLOAD_DATA(s_msg_code, MP_ERP_UPLOAD_INV_IN, in_node, out_node) == MP_FALSE)
	   // {
		  //  COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		  //  return MP_FALSE;
	   // }
    //}
    DB_commit();
    /*************************************************************************************/


    i_ret = INV_IN_LOT(s_msg_code, in_node, out_node);

    /* ERP API FUNCTION CALL */
    /*if(i_ret == MP_TRUE)
    {
        if (CCOM_ERP_API_FUNCTION(1, TRS.get_double(in_node, "GROUP_KEY"), s_msg_code, in_node, out_node) == MP_FALSE)
        {
            DB_rollback();

            if (CCOM_ERP_UPLOAD_DATA_DELETE(TRS.get_double(in_node, "GROUP_KEY"), s_msg_code, in_node, out_node) == MP_TRUE)
            {
                DB_commit();
            }
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }*/

    COM_out_msg_log_write(s_msg_code, "INV_APPROVAL_IN_LOT", out_node);

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

        //if (CCOM_ERP_UPLOAD_DATA_DELETE(TRS.get_double(in_node, "GROUP_KEY"), s_msg_code, in_node, out_node) == MP_TRUE)
        //{
        //    DB_commit();
        //}
    }

    return MP_TRUE;}

/*******************************************************************************
    CINV_IN_LOT_MES()
        - Main sub function of "CINV_In_Lot_Mes" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - CINV_IN_LOT_MES_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int INV_IN_LOT(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node)

{
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MTIVERPORD_TAG MTIVERPORD;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MTIVLOTSTS_TAG MTIVLOTSTS_OLD;
	struct MTIVLOTSTS_TAG MTIVLOTSTS_COMP;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
	/*struct MTIVOPRDEF_TAG MTIVOPRDEF;*/
	struct MATRNAMSTS_TAG MATRNAMSTS;

    char s_sys_time[14];
    int i, n;
    int i_lot_count = 0;   
	double d_cv_qty = 0;
	int i_last_hist_seq = 0;
	//int i_count_inv_lot = 0;
	
	char c_to_oper_lot_exist = 'N';

	TRSNode *cv_lot_in;
    TRSNode *transfer_lot_in;
    TRSNode** inv_lot_list;
	TRSNode *list_item;
	TRSNode *cv_item;

    //Tool
	TRSNode *gen_id_in, *tool_item, *sts_item;

    LOG_head("INV_IN_LOT");
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(COM_proc_user_routine("INV", "INV_In_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    memset(s_sys_time, ' ', sizeof(s_sys_time));

    if(COM_isnullspace(TRS.get_string(in_node, "BACK_TIME") ) == MP_FALSE)
    {
        memset(s_sys_time, '0', sizeof(s_sys_time));
        TRS.copy(s_sys_time, sizeof(s_sys_time), in_node, "BACK_TIME");
    }
    else
    {
        DB_get_systime(s_sys_time);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "INV-0004");
            TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    /*' Validation Check*/
    if(INV_In_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    //Get Material information        
	if (INV_get_mat_ext(s_msg_code, out_node, TRS.get_factory(in_node), TRS.get_string(in_node, "MAT_ID"),0,
                        &MWIPMATDEF) == MP_FALSE)
    {
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }    	
    
	//타 인터페이스의 View를 보지 않고 Core를 이용하면,	
	if(TRS.get_char(in_node, "VIEW_FLAG") != 'Y')
	{	
        DBC_init_mtiverpord(&MTIVERPORD);

        TRS.copy(MTIVERPORD.FACTORY, sizeof(MTIVERPORD.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVERPORD.ORDER_ID, sizeof(MTIVERPORD.ORDER_ID), in_node, "ORDER_ID");
        TRS.copy(MTIVERPORD.MAT_ID, sizeof(MTIVERPORD.MAT_ID), in_node, "MAT_ID");
        MTIVERPORD.SEQ_NUM = TRS.get_int(in_node, "ORDER_SEQ_NUM");
        DBC_select_mtiverpord_for_update(1, &MTIVERPORD);
        if(DB_error_code != DB_SUCCESS) 
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
				strcpy(s_msg_code, "INV-0027");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
            else 
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;

				TRS.add_fieldmsg(out_node, "MTIVERPORD SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVERPORD.FACTORY), MTIVERPORD.FACTORY);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MTIVERPORD.ORDER_ID), MTIVERPORD.ORDER_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
            }            
        }
		else
		{
			//Order status check( REVOKE, CLOSE, PERFACT)
			if(MTIVERPORD.ORD_STS_FLAG =='R')
			{
				strcpy(s_msg_code, "INV-0029");
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MTIVERPORD.ORDER_ID), MTIVERPORD.ORDER_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else if(MTIVERPORD.ORD_STS_FLAG =='C')
			{
				strcpy(s_msg_code, "INV-0030");
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MTIVERPORD.ORDER_ID), MTIVERPORD.ORDER_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else if(MTIVERPORD.ORD_STS_FLAG =='P')
			{
				strcpy(s_msg_code, "INV-0019");
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MTIVERPORD.ORDER_ID), MTIVERPORD.ORDER_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			//Input Qty Over..
			if(MTIVERPORD.RATIO == 0)
			{
				if((MTIVERPORD.ORDER_QTY < (MTIVERPORD.QTY_1 + TRS.get_double(in_node, "INPUT_QTY")))) 
				{
					strcpy(s_msg_code, "INV-0020");
					TRS.add_fieldmsg(out_node, "ORDER_QTY", MP_DBL, MTIVERPORD.ORDER_QTY);
					TRS.add_fieldmsg(out_node, "IN_QTY", MP_DBL, (MTIVERPORD.QTY_1 + TRS.get_double(in_node, "INPUT_QTY")));

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;        
				}
			}
			else
			{
				if((MTIVERPORD.ORDER_QTY * MTIVERPORD.RATIO)/100 < (MTIVERPORD.QTY_1 + TRS.get_double(in_node, "INPUT_QTY")) )
				{
					strcpy(s_msg_code, "INV-0020");
					TRS.add_fieldmsg(out_node, "ORDER_QTY", MP_DBL, MTIVERPORD.ORDER_QTY);
					TRS.add_fieldmsg(out_node, "IN_QTY", MP_DBL, (MTIVERPORD.QTY_1 + TRS.get_double(in_node, "INPUT_QTY")));

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;        
				}
			}			

			if(MTIVERPORD.ORDER_QTY <= (MTIVERPORD.QTY_1 + TRS.get_double(in_node, "INPUT_QTY")))
			{
				MTIVERPORD.ORD_STS_FLAG = 'P';
			}

			MTIVERPORD.QTY_1 = MTIVERPORD.QTY_1 + TRS.get_double(in_node, "INPUT_QTY");
			MTIVERPORD.REMAIN_QTY = MTIVERPORD.ORDER_QTY - MTIVERPORD.QTY_1;

			TRS.copy(MTIVERPORD.ORD_CMF_1, sizeof(MTIVERPORD.ORD_CMF_1), in_node, "ORD_CMF_1");
			TRS.copy(MTIVERPORD.ORD_CMF_2, sizeof(MTIVERPORD.ORD_CMF_2), in_node, "ORD_CMF_2");
			TRS.copy(MTIVERPORD.ORD_CMF_3, sizeof(MTIVERPORD.ORD_CMF_3), in_node, "ORD_CMF_3");
			TRS.copy(MTIVERPORD.ORD_CMF_4, sizeof(MTIVERPORD.ORD_CMF_4), in_node, "ORD_CMF_4");
			TRS.copy(MTIVERPORD.ORD_CMF_5, sizeof(MTIVERPORD.ORD_CMF_5), in_node, "ORD_CMF_5");
			TRS.copy(MTIVERPORD.ORD_CMF_6, sizeof(MTIVERPORD.ORD_CMF_6), in_node, "ORD_CMF_6");
			TRS.copy(MTIVERPORD.ORD_CMF_7, sizeof(MTIVERPORD.ORD_CMF_7), in_node, "ORD_CMF_7");
			TRS.copy(MTIVERPORD.ORD_CMF_8, sizeof(MTIVERPORD.ORD_CMF_8), in_node, "ORD_CMF_8");
			TRS.copy(MTIVERPORD.ORD_CMF_9, sizeof(MTIVERPORD.ORD_CMF_9), in_node, "ORD_CMF_9");
			TRS.copy(MTIVERPORD.ORD_CMF_10, sizeof(MTIVERPORD.ORD_CMF_10), in_node, "ORD_CMF_10");

			TRS.copy(MTIVERPORD.UPDATE_USER_ID, sizeof(MTIVERPORD.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(MTIVERPORD.UPDATE_TIME, s_sys_time, sizeof(MTIVERPORD.UPDATE_TIME));
			DBC_update_mtiverpord(1, &MTIVERPORD);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "INV-0004");
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.add_fieldmsg(out_node, "MTIVERPORD UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVERPORD.FACTORY), MTIVERPORD.FACTORY);
				TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MTIVERPORD.ORDER_ID), MTIVERPORD.ORDER_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
    }
	
	transfer_lot_in = TRS.create_node("TRANSFER_LOT_IN");

	TRS.add_char(transfer_lot_in, IN_PROCSTEP, '1');
	TRS.add_nstring(transfer_lot_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
	TRS.add_char(transfer_lot_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
	TRS.add_nstring(transfer_lot_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
	TRS.add_nstring(transfer_lot_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
	TRS.add_nstring(transfer_lot_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));

	i_lot_count = TRS.get_item_count(in_node, "INV_LOT_LIST");
	inv_lot_list = TRS.get_list(in_node, "INV_LOT_LIST");        

	for(i=0; i<i_lot_count; i++)
	{   
		//LOT이 다른공정에 존재할때 CV처리가 되지않고 만들어지도록 해야함
		//in_node로 전해지는 TO_OPER와 다를때 처리되도록 해야함 
		//ATTRIBUTE도 고려하기 

		//MATERIAL에 대한 IQC_FLAG값을 가지고옴
		DBC_init_mwipmatdef(&MWIPMATDEF);
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "MAT_ID");
		DBC_select_mwipmatdef(1, &MWIPMATDEF);

		DBC_init_mtivlotsts(&MTIVLOTSTS_COMP);
		TRS.copy(MTIVLOTSTS_COMP.FACTORY, sizeof(MTIVLOTSTS_COMP.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS_COMP.LOT_ID, sizeof(MTIVLOTSTS_COMP.LOT_ID), inv_lot_list[i], "INV_LOT_ID");
		TRS.copy(MTIVLOTSTS_COMP.OPER, sizeof(MTIVLOTSTS_COMP.OPER), inv_lot_list[i], "INV_OPER");//생성되야할 OPER
		DBC_select_mtivlotsts(4, &MTIVLOTSTS_COMP);
		if(DB_error_code != DB_SUCCESS) 
		{
			c_to_oper_lot_exist = 'N';//존재하지 않는다.
		}
		else
		{
			c_to_oper_lot_exist = 'Y';//존재한다.
		}
		

		//최근꺼 얻어오기 
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), inv_lot_list[i], "INV_LOT_ID");
		//TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), inv_lot_list[i], "INV_OPER");
		//DBC_select_mtivlotsts(1, &MTIVLOTSTS); //기존에 쓰던 것
		DBC_select_mtivlotsts(6, &MTIVLOTSTS);
		i_last_hist_seq = MTIVLOTSTS.LAST_HIST_SEQ;//없으면 0으로 있음


		DBC_init_mtivlotsts(&MTIVLOTSTS_COMP);
		TRS.copy(MTIVLOTSTS_COMP.FACTORY, sizeof(MTIVLOTSTS_COMP.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS_COMP.LOT_ID, sizeof(MTIVLOTSTS_COMP.LOT_ID), inv_lot_list[i], "INV_LOT_ID");
		TRS.copy(MTIVLOTSTS_COMP.OPER, sizeof(MTIVLOTSTS_COMP.OPER), inv_lot_list[i], "INV_OPER");
		//DBC_select_mtivlotsts(1, &MTIVLOTSTS); //기존에 쓰던 것
		DBC_select_mtivlotsts(4, &MTIVLOTSTS_COMP);
		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);			
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(transfer_lot_in);	
				return MP_FALSE;
			}
		}
		
		if(c_to_oper_lot_exist == 'Y')       //있으면 CV를 한다.
		{
			//Lot 관리 하지 않으면(Special Case, Lot이 여러 공정에 존재 할수 있다.)
			//Lot_Group_ID 를 통해서

			//다른 공정에 Lot이 생성될 경우를 위한 변수 
			

			//ATTRIBUTE VALUE를 들고온다.
			DBC_init_matrnamsts(&MATRNAMSTS);
			//ATTRIBUTE SELECT IN_NODE(MATERIAL_ID), Get ATTR_VALUE; //Attribute가 필요할때마다 호출한다. 
			TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MATRNAMSTS.ATTR_TYPE, sizeof(MATRNAMSTS.ATTR_TYPE), in_node, "ATTR_TYPE");
			TRS.copy(MATRNAMSTS.ATTR_NAME, sizeof(MATRNAMSTS.ATTR_NAME), in_node, "ATTR_NAME"); 
			TRS.copy(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY), in_node, "ATTR_KEY");

			if(INV_View_Attribute_Value(s_msg_code, 
			                                        in_node,
			                                        out_node,
			                                        &MATRNAMSTS,4) == MP_FALSE)
			{
			    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			    return MP_FALSE;
			}


			/*if(MTIVMATDEF.LOT_GROUP_FLAG == 'Y')*/
			if(memcmp(MATRNAMSTS.ATTR_VALUE, "Y", strlen("Y")) == 0)//어트리뷰트의 Lot Group Flag가 Y이면
			{
				//Get Operation information
				if ( INV_get_oper_ext(s_msg_code, out_node, TRS.get_string(in_node, IN_FACTORY), MTIVLOTSTS.OPER,
									&MWIPOPRDEF) != MP_TRUE)
				{
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					TRS.free_node(transfer_lot_in);	
					return MP_FALSE;
				}	

				//수입 검사 진행이 끝나지 않아도 입고 가능
				//if(MTIVOPRDEF.INV_INTRANSIT_FLAG == 'Y')
				//{
				//	//수입 검사 진행이 끝나지 않아 입고 불가능
				//	strcpy(s_msg_code, "INV-0014");
				//	gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				//	TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);					
				//	TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

				//	gs_log_type.type = MP_LOG_ERROR;
				//	gs_log_type.category = MP_LOG_CATE_VIEW;

				//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				//	TRS.free_node(transfer_lot_in);	
				//	return MP_FALSE; 
				//}
				//CV 처리 후 Return
				/*else
				{*/
					cv_lot_in = TRS.create_node("CV_LOT_IN");

					TRS.add_char(cv_lot_in, IN_PROCSTEP, '1');
					TRS.add_nstring(cv_lot_in, IN_PASSPORT, TRS.get_string(in_node, IN_PASSPORT));
					TRS.add_char(cv_lot_in, IN_LANGUAGE, TRS.get_char(in_node, IN_LANGUAGE));
					TRS.add_nstring(cv_lot_in, IN_FACTORY, TRS.get_string(in_node, IN_FACTORY));
					TRS.add_nstring(cv_lot_in, IN_USERID, TRS.get_string(in_node, IN_USERID));
					TRS.add_nstring(cv_lot_in, IN_PASSWORD, TRS.get_string(in_node, IN_PASSWORD));
					TRS.set_nstring(cv_lot_in, "MAT_ID", TRS.get_string(in_node, "MAT_ID"));
					//Operation 추가 
					

					list_item = TRS.add_node(cv_lot_in, "INV_LOT_LIST");
					TRS.set_string(list_item, "TRAN_TYPE", MP_INV_TRAN_TYPE_MAT_TRN, strlen(MP_INV_TRAN_TYPE_MAT_TRN)); 
					TRS.set_string(list_item, "INV_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
					TRS.set_nstring(list_item, "TRAN_COMMNET", TRS.get_string(inv_lot_list[0], "INV_LOT_COMMENT"));										
					TRS.set_string(list_item, "INV_OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));

					cv_item = TRS.add_node(list_item, "UNIT1");
					TRS.set_string(cv_item, "CODE", "P100", strlen("P100")); 
					//TRS.set_double(cv_item, "QTY", MTIVLOTSTS.QTY_1);

					d_cv_qty = TRS.get_double(in_node, "IN_QTY");

					TRS.set_double(cv_item, "QTY", d_cv_qty);

					if(INV_CV_LOT(s_msg_code, cv_lot_in, out_node) == MP_FALSE)
					{
						TRS.free_node(transfer_lot_in);
						TRS.free_node(cv_lot_in);
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
					TRS.free_node(cv_lot_in);

					COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
					return MP_TRUE;
				/*}*/

			}		
		}       


		//CV처리가 아닌경우 계속 진행된다.
		TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");
		MTIVLOTSTS.MAT_VER = 1;

		MTIVLOTSTS.LOT_TYPE = 'P';
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TO_OPER");//OPER설정에 따라 생성되는 OPER결정
		memcpy(MTIVLOTSTS.CREATE_TIME, s_sys_time, sizeof(MTIVLOTSTS.CREATE_TIME));
		MTIVLOTSTS.IN_OUT_FLAG ='I';
		TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), in_node, "ORDER_ID");
		TRS.copy(MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO), in_node, "LINE_ID");
		TRS.copy(MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID), in_node, "ORDER_ID");    
		TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), in_node, "VENDOR_ID");

		TRS.copy(MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1), in_node, "UNIT");        		
		
		TRS.copy(MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC), inv_lot_list[i], "LOT_DESC");        

		if(TRS.get_char(inv_lot_list[i], "LOT_TYPE") == ' ')
		{
			MTIVLOTSTS.LOT_TYPE = MP_LOT_TYPE_PROD;
		}
		else
		{
			MTIVLOTSTS.LOT_TYPE = TRS.get_char(inv_lot_list[i], "LOT_TYPE");
		}

		memcpy(MTIVLOTSTS.LAST_TRAN_CODE, MP_INV_TRAN_CODE_IN, strlen(MP_INV_TRAN_CODE_IN));
		TRS.copy(MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE), inv_lot_list[i], "IN_TYPE");
		memcpy(MTIVLOTSTS.LAST_TRAN_TIME, s_sys_time, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
        
		TRS.copy(MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT), inv_lot_list[i], "INV_LOT_COMMENT");
		TRS.copy(MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID), in_node, "VENDOR_LOT_ID");		
		TRS.copy(MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO), in_node, "LOCATION_NO");
		
		TRS.copy(MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID), in_node, "MAT_ID");
		MTIVLOTSTS.PO_SEQ_NUM = TRS.get_int(in_node, "ORDER_SEQ_NUM");
		TRS.copy(MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE), in_node, "EXPIRE_DATE");

		memcpy(&MTIVLOTSTS_OLD, &MTIVLOTSTS, sizeof(MTIVLOTSTS));

		DBC_init_mtivlothis(&MTIVLOTHIS);         
        

		// 신규 생성 
		//신규 생성이라도 2번째로 만들어지는 것은 HIST_SEQ를 받아와야함
		MTIVLOTSTS.CREATE_QTY_1 = TRS.get_double(inv_lot_list[i], "IN_QTY");
		MTIVLOTSTS.CREATE_QTY_2 = 0;
		MTIVLOTSTS.CREATE_QTY_3 = 0;
		MTIVLOTSTS.LAST_HIST_SEQ = i_last_hist_seq+1;
		MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ = i_last_hist_seq+1;                          


		MTIVLOTSTS.QTY_1 = TRS.get_double(inv_lot_list[i], "IN_QTY");
		MTIVLOTSTS.QTY_2 = 0;
		MTIVLOTSTS.QTY_3 = 0;    

		TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_1");
		TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_2");
		TRS.copy(MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_3");
		TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_4");
		TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_5");
		TRS.copy(MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_6");
		TRS.copy(MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_7");
		TRS.copy(MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_8");
		TRS.copy(MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_9");
		TRS.copy(MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_10");
		TRS.copy(MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_11");
		TRS.copy(MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_12");
		TRS.copy(MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_13");
		TRS.copy(MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_14");
		TRS.copy(MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_15");
		TRS.copy(MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_16");
		TRS.copy(MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_17");
		TRS.copy(MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_18");
		TRS.copy(MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_19");
		TRS.copy(MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_1), inv_lot_list[i], "INV_CMF_20");


		if(MTIVLOTSTS.QTY_1 == 0)
		{
			MTIVLOTSTS.LOT_DEL_FLAG = 'Y';
			TRS.copy(MTIVLOTSTS.LOT_DEL_USER_ID,  sizeof(MTIVLOTSTS.LOT_DEL_USER_ID), in_node, IN_USERID);
			memcpy(MTIVLOTSTS.LOT_DEL_TIME, s_sys_time, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
			memcpy(MTIVLOTSTS.LOT_DEL_REASON, "QTY_ZERO", strlen("QTY_ZERO"));
		}
		else
		{
			MTIVLOTSTS.LOT_DEL_FLAG = ' ';
			memset(MTIVLOTSTS.LOT_DEL_USER_ID, ' ', sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
			memset(MTIVLOTSTS.LOT_DEL_TIME, ' ', sizeof(MTIVLOTSTS.LOT_DEL_TIME));
			memset(MTIVLOTSTS.LOT_DEL_REASON, ' ', sizeof(MTIVLOTSTS.LOT_DEL_REASON));
		}
        
		if(INV_update_insert_lot_status_history_for_in_lot(s_msg_code, 
												in_node,
												out_node,
												s_sys_time,
												&MTIVLOTSTS_OLD,
												&MTIVLOTSTS,
												&MTIVLOTHIS) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.free_node(transfer_lot_in);	
			return MP_FALSE;
		}



		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "MAT_ID");
        DBC_select_mwipmatdef(3, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
				strcpy(s_msg_code, "INV-0006");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
            else 
            {
                strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;

				TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVERPORD.FACTORY), MTIVERPORD.FACTORY);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVERPORD.MAT_ID), MTIVERPORD.MAT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
            }            
        }

        //Material 의 ToolFlag='Y' 인 경우 Tool 생성
		//if(MWIPMATDEF.MAT_CMF_1 == 'Y')

		if(memcmp(MWIPMATDEF.MAT_CMF_3, "Y", strlen("Y")) == 0)
        {
            if(COM_isnullspace(TRS.get_string(inv_lot_list[i], "TOOL_ID")) == MP_TRUE)
            {
                if(COM_isnullspace(TRS.get_string(inv_lot_list[i], "RULE_ID")) == MP_TRUE)
                {
#ifdef MP_RULE_ID_DEFAULT_TOOL
                    TRS.set_nstring(inv_lot_list[i], "RULE_ID", MP_RULE_ID_DEFAULT_TOOL);
#else
					strcpy(s_msg_code, "INV-0001");
					TRS.add_fieldmsg(out_node, "TOOL_ID or RULE_ID", MP_NVST);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_TRAN;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE; 
#endif
                }

                gen_id_in = TRS.create_node("WIP_GENERATE_ID_IN");
                TRS.add_char(gen_id_in, IN_PROCSTEP, '2');
                TRS.add_enc_nstring(gen_id_in, IN_USERID, TRS.get_userid(in_node));
                TRS.add_enc_nstring(gen_id_in, IN_PASSWORD, TRS.get_password(in_node));
                TRS.add_char(gen_id_in, IN_LANGUAGE, TRS.get_language(in_node));
                TRS.add_nstring(gen_id_in, IN_FACTORY, TRS.get_factory(in_node));

                TRS.add_nstring(gen_id_in, "RULE_ID", TRS.get_string(inv_lot_list[i], "RULE_ID"));
                TRS.add_nstring(gen_id_in, "LOT_ID", TRS.get_string(inv_lot_list[i], "INV_LOT_ID"));

                if (WIP_GENERATE_ID(s_msg_code, gen_id_in, out_node) == MP_FALSE)
                {
                    TRS.free_node(gen_id_in);
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                TRS.free_node(gen_id_in);

                TRS.set_nstring(inv_lot_list[i], "TOOL_ID", TRS.get_string(out_node, "GEN_ID"));
                TRS.init_node(out_node);
            }

            if(COM_isnullspace(TRS.get_string(inv_lot_list[i], "TOOL_ID")) == MP_FALSE)
            {
                tool_item = TRS.create_node("RAS_UPDATE_TOOL_IN");
                TRS.add_char(tool_item, IN_PROCSTEP, MP_STEP_CREATE);
                TRS.add_enc_nstring(tool_item, IN_USERID, TRS.get_userid(in_node));
                TRS.add_enc_nstring(tool_item, IN_PASSWORD, TRS.get_password(in_node));
                TRS.add_char(tool_item, IN_LANGUAGE, TRS.get_language(in_node));
                TRS.add_nstring(tool_item, IN_FACTORY, TRS.get_factory(in_node));

                TRS.add_nstring(tool_item, "TOOL_ID", TRS.get_string(inv_lot_list[i], "TOOL_ID"));
                
				//Attribute를 얻어와서 넣어준다. 
				DBC_init_matrnamsts(&MATRNAMSTS);
				//ATTRIBUTE SELECT IN_NODE(MATERIAL_ID), Get ATTR_VALUE; //Attribute가 필요할때마다 호출한다. 
				TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
				memcpy(MATRNAMSTS.ATTR_TYPE, "MATERIAL", strlen("MATERIAL"));
				memcpy(MATRNAMSTS.ATTR_NAME, "TOOL_TYPE", strlen("TOOL_TYPE"));
				memcpy(MATRNAMSTS.ATTR_KEY, TRS.get_string(in_node, "MAT_ID"), sizeof(MWIPMATDEF.MAT_ID));
				DBC_select_matrnamsts(3, &MATRNAMSTS);
				if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS)
				{
				    strcpy(s_msg_code, "WIP-0004");            
				    TRS.add_dberrmsg(out_node, DB_error_msg);
				    TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);                
				    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
				    TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
				    TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
				    TRS.add_fieldmsg(out_node, "ATTR_VALUE", MP_STR, sizeof(MATRNAMSTS.ATTR_VALUE), MATRNAMSTS.ATTR_VALUE);

				    gs_log_type.type = MP_LOG_ERROR;
				    gs_log_type.e_type = MP_LOG_E_SYSTEM;
				    gs_log_type.category = MP_LOG_CATE_VIEW;
				    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				    return MP_FALSE; 
				}

				TRS.add_string(tool_item, "TOOL_TYPE", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));
				TRS.add_string(tool_item, "TOOL_DESC", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID)); //TOOL DESC에 INV_LOT_ID를 넣어버림.



                for(n = 0; n < 30; n++)
                {
                    sts_item = TRS.add_node(tool_item, "STS_LIST");
                }
                if(RAS_UPDATE_TOOL(s_msg_code, tool_item, out_node) == MP_FALSE)
                {
                    TRS.free_node(tool_item);
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                TRS.free_node(tool_item);
            }
        }

		//이곳에 추가
		//IQC_FLAG를 진행하는 Material이라면 
		//if(memcmp(MWIPMATDEF.IQC_FLAG, "Y", strlen("Y")==0))
		//{
		//	DBC_init_matrnamsts(&MATRNAMSTS);//IQC_FLAG플레그 값을 가지고 오기 
		//	TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
		//	memcpy(MATRNAMSTS.ATTR_TYPE, "OPER", strlen("OPER"));
		//	memcpy(MATRNAMSTS.ATTR_NAME, "IQC_REQ_FLAG", strlen("IQC_REQ_FLAG"));
		//	memcpy(MATRNAMSTS.ATTR_VALUE, "Y", strlne("Y"));
		//}


		//수입검사 진행하지 않더라도 진행될 수 있도록 로직빼버리기
		//수입검사 진행여부가 N인경우 tran type MAT_IN경우 원창으로 자동 이송...(add)
		/*if(MWIPMATDEF.IQC_FLAG !='Y' && -
			COM_isnullspace(TRS.get_string(in_node, "ORDER_ID")) == MP_FALSE &&
			TRS.mem_cmp(inv_lot_list[i], "IN_TYPE", MP_INV_TRAN_TYPE_MAT_IN, strlen(MP_INV_TRAN_TYPE_MAT_IN))==0)
		{
			TRS.set_nstring(transfer_lot_in, "INV_LOT_ID", TRS.get_string(inv_lot_list[i], "INV_LOT_ID"));
			TRS.set_nstring(transfer_lot_in, "INV_MAT_ID", TRS.get_string(in_node, "MAT_ID"));
			TRS.set_int(transfer_lot_in, "INV_MAT_VER", 1);            
            TRS.set_nstring(transfer_lot_in, "FROM_OPER", TRS.get_string(in_node, "FROM_OPER"));
			TRS.set_nstring(transfer_lot_in, "TO_OPER", TRS.get_string(in_node, "TO_OPER"));
			TRS.set_nstring(transfer_lot_in, "TO_LOCATION_NO", TRS.get_string(in_node, "TO_LOCATION_NO"));
			TRS.set_double(transfer_lot_in, "MOV_QTY",  TRS.get_double(inv_lot_list[i], "IN_QTY"));
			TRS.set_string(transfer_lot_in, "TRAN_CODE", MP_INV_TRAN_CODE_TRANSFER, strlen(MP_INV_TRAN_CODE_TRANSFER)); 
			TRS.set_string(transfer_lot_in, "TRAN_TYPE", MP_INV_TRAN_TYPE_MAT_TRN, strlen(MP_INV_TRAN_TYPE_MAT_TRN)); 
			TRS.set_nstring(transfer_lot_in, "TRAN_COMMNET", TRS.get_string(inv_lot_list[i], "INV_LOT_COMMENT"));
			TRS.set_int(transfer_lot_in, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
            
			TRS.set_string(transfer_lot_in, "INV_CMF_1", TRS.get_string(inv_lot_list[i], "INV_CMF_1"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_1")));
			TRS.set_string(transfer_lot_in, "INV_CMF_2", TRS.get_string(inv_lot_list[i], "INV_CMF_2"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_2")));
			TRS.set_string(transfer_lot_in, "INV_CMF_3", TRS.get_string(inv_lot_list[i], "INV_CMF_3"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_3")));
			TRS.set_string(transfer_lot_in, "INV_CMF_4", TRS.get_string(inv_lot_list[i], "INV_CMF_4"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_4")));
			TRS.set_string(transfer_lot_in, "INV_CMF_5", TRS.get_string(inv_lot_list[i], "INV_CMF_5"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_5")));
			TRS.set_string(transfer_lot_in, "INV_CMF_6", TRS.get_string(inv_lot_list[i], "INV_CMF_6"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_6")));
			TRS.set_string(transfer_lot_in, "INV_CMF_7", TRS.get_string(inv_lot_list[i], "INV_CMF_7"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_7")));
			TRS.set_string(transfer_lot_in, "INV_CMF_8", TRS.get_string(inv_lot_list[i], "INV_CMF_8"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_8")));
			TRS.set_string(transfer_lot_in, "INV_CMF_9", TRS.get_string(inv_lot_list[i], "INV_CMF_9"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_9")));
			TRS.set_string(transfer_lot_in, "INV_CMF_10", TRS.get_string(inv_lot_list[i], "INV_CMF_10"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_10")));
			TRS.set_string(transfer_lot_in, "INV_CMF_11", TRS.get_string(inv_lot_list[i], "INV_CMF_11"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_11")));
			TRS.set_string(transfer_lot_in, "INV_CMF_12", TRS.get_string(inv_lot_list[i], "INV_CMF_12"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_12")));
			TRS.set_string(transfer_lot_in, "INV_CMF_13", TRS.get_string(inv_lot_list[i], "INV_CMF_13"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_13")));
			TRS.set_string(transfer_lot_in, "INV_CMF_14", TRS.get_string(inv_lot_list[i], "INV_CMF_14"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_14")));
			TRS.set_string(transfer_lot_in, "INV_CMF_15", TRS.get_string(inv_lot_list[i], "INV_CMF_15"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_15")));
			TRS.set_string(transfer_lot_in, "INV_CMF_16", TRS.get_string(inv_lot_list[i], "INV_CMF_16"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_16")));
			TRS.set_string(transfer_lot_in, "INV_CMF_17", TRS.get_string(inv_lot_list[i], "INV_CMF_17"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_17")));
			TRS.set_string(transfer_lot_in, "INV_CMF_18", TRS.get_string(inv_lot_list[i], "INV_CMF_18"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_18")));
			TRS.set_string(transfer_lot_in, "INV_CMF_19", TRS.get_string(inv_lot_list[i], "INV_CMF_19"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_19")));
			TRS.set_string(transfer_lot_in, "INV_CMF_20", TRS.get_string(inv_lot_list[i], "INV_CMF_20"), sizeof(TRS.get_string(inv_lot_list[i], "INV_CMF_20")));

			if(INV_TRANSFER_LOT(s_msg_code, transfer_lot_in, out_node) == MP_FALSE)
			{
				TRS.free_node(transfer_lot_in);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}*/
	}
	TRS.free_node(transfer_lot_in);	
    
    if(COM_proc_user_routine("INV", "INV_In_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    CINV_In_Lot_Mes_Validation()
        - Validation Check sub function of "CINV_IN_LOT_MES" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - CINV_IN_LOT_MES_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int INV_In_Lot_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MWIPOPRDEF_TAG MWIPOPRDEF;
    //struct MTIVOPRDEF_TAG MTIVOPRDEF;
	struct MATRNAMSTS_TAG MATRNAMSTS;
    
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
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

    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if(COM_isnullspace(TRS.get_string(in_node, "TO_OPER")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "TO_OPER", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    if (TRS.get_item_count(in_node, "INV_LOT_LIST") < 1)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "INV_LOT_LIST", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);

    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);

    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0005");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mwipmatdef(&MWIPMATDEF);

    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "MAT_ID");
  
    DBC_select_mwipmatdef(3, &MWIPMATDEF);
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
        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mwipoprdef(&MWIPOPRDEF);

    TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPOPRDEF.OPER, sizeof(MWIPOPRDEF.OPER), in_node, "TO_OPER");

    DBC_select_mwipoprdef(1, &MWIPOPRDEF);
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
        }
        TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    /* Extends Oper Information Validation */
    //DBC_init_mtivoprdef(&MTIVOPRDEF);

    //TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
    //TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "TO_OPER");

    //DBC_select_mtivoprdef(1, &MTIVOPRDEF);
    //if(DB_error_code != DB_SUCCESS) 
    //{
    //    if(DB_error_code == DB_NOT_FOUND)
    //    {
    //        strcpy(s_msg_code, "INV-0025");
    //        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
    //    }
    //    else 
    //    {
    //        strcpy(s_msg_code, "INV-0004");
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    }
    //    TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
    //    TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    return MP_FALSE;
    //}

    //입고 하려는 곳이 공정창고 일 경우 Error 처리
  /*  if(MTIVOPRDEF.WIP_FLAG =='Y')
    {
        strcpy(s_msg_code, "INV-0026");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }*/

	//ATTRIBUTE VALUE를 들고온다.
	DBC_init_matrnamsts(&MATRNAMSTS);
	//ATTRIBUTE SELECT IN_NODE(MATERIAL_ID), Get ATTR_VALUE; //Attribute가 필요할때마다 호출한다. 
	TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MATRNAMSTS.ATTR_TYPE, "OPER", strlen("OPER"));
	memcpy(MATRNAMSTS.ATTR_NAME, "TRAN_IN_FLAG", strlen("TRAN_IN_FLAG"));
	TRS.copy(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY), in_node, "TO_OPER");

	if(INV_View_Attribute_Value(s_msg_code, 
	                                        in_node,
	                                        out_node,
	                                        &MATRNAMSTS,5) == MP_FALSE)
	{
	    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	    return MP_FALSE;
	}

	TRS.add_string(out_node,"ATTR_VALUE", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));
	
    //사내입고가능한 자재만 입고처리.
    if(memcmp(MATRNAMSTS.ATTR_VALUE,"Y", strlen("Y"))!=0)
    {
        strcpy(s_msg_code, "INV-0021");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF.FACTORY), MWIPOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPOPRDEF.OPER), MWIPOPRDEF.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }
    
    return MP_TRUE;
}





