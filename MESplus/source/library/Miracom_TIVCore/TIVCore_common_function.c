/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_common_function.c
    Description : Transaction common function module

    MES Version : 5.2.0

    Function List
        - WIP_insert_sublot_history()
            + Insert Sublot History

    Detail Description
        -

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/21  Patrick         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "TIVCore_common.h"


/*******************************************************************************
    TIV_get_mat_ext()
        - Get material include exetention
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
        - char *factory : Factory Name
        - char *material : Material Name
        - char *mat_ver : Material Version
        - struct MWIPMATDEF_TAG *MWIPMATDEF : Original material table
        - struct MTIVMATDEF_TAG *MTIVMATDEF : Exetention material table
*******************************************************************************/
int TIV_get_mat_ext(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *material,
                             int mat_ver,
                             struct MWIPMATDEF_TAG *MWIPMATDEF,
                             struct MTIVMATDEF_TAG *MTIVMATDEF)
{

    char s_factory[10];
    char s_mat_id[30];

    COM_memcpy(s_factory, factory, sizeof(s_factory));
    COM_memcpy(s_mat_id, material, sizeof(s_mat_id));

    /* Get material information */
    DBC_init_mwipmatdef(MWIPMATDEF);
    memcpy(MWIPMATDEF->FACTORY, s_factory, sizeof(MWIPMATDEF->FACTORY));
    memcpy(MWIPMATDEF->MAT_ID, s_mat_id, sizeof(MWIPMATDEF->MAT_ID));    

    if( mat_ver != 0)
    {
        MWIPMATDEF->MAT_VER = mat_ver;
        DBC_select_mwipmatdef(1, MWIPMATDEF);
    }
    else
    {
        DBC_select_mwipmatdef(3, MWIPMATDEF);
    }
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF->FACTORY), MWIPMATDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF->MAT_ID), MWIPMATDEF->MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF->MAT_VER);        
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }  

    DBC_init_mtivmatdef(MTIVMATDEF);
    memcpy(MTIVMATDEF->FACTORY, MWIPMATDEF->FACTORY, sizeof(MTIVMATDEF->FACTORY));
    memcpy(MTIVMATDEF->MAT_ID, MWIPMATDEF->MAT_ID, sizeof(MTIVMATDEF->MAT_ID));
    MTIVMATDEF->MAT_VER = MWIPMATDEF->MAT_VER;    
    DBC_select_mtivmatdef(1, MTIVMATDEF);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF->FACTORY), MTIVMATDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF->MAT_ID), MTIVMATDEF->MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF->MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }    

    return MP_TRUE;
}




/*******************************************************************************
    TIV_get_oper_ext()
        - Get oper include exetention
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
        - char *factory : Factory Name
        - char *operation : Operation Name        
        - struct MWIPOPRDEF_TAG *MWIPOPRDEF : Original opreation table
        - struct MTIVOPRDEF_TAG *MTIVOPRDEF : Exetention operation table
*******************************************************************************/
int TIV_get_oper_ext(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *operation,                           
                             struct MWIPOPRDEF_TAG *MWIPOPRDEF,
                             struct MTIVOPRDEF_TAG *MTIVOPRDEF)
{

    char s_factory[10];
    char s_oper_id[10];

    COM_memcpy(s_factory, factory, sizeof(s_factory));
    COM_memcpy(s_oper_id, operation, sizeof(s_oper_id));

    /* Get oper information */
    DBC_init_mwipoprdef(MWIPOPRDEF);
    memcpy(MWIPOPRDEF->FACTORY, s_factory, sizeof(MWIPOPRDEF->FACTORY));
    memcpy(MWIPOPRDEF->OPER, s_oper_id, sizeof(MWIPOPRDEF->OPER));    
    
    DBC_select_mwipoprdef(1, MWIPOPRDEF);    
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
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

        TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF->FACTORY), MWIPOPRDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF->OPER), MWIPOPRDEF->OPER);        
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }  

    DBC_init_mtivoprdef(MTIVOPRDEF);
    memcpy(MTIVOPRDEF->FACTORY, MWIPOPRDEF->FACTORY, sizeof(MTIVOPRDEF->FACTORY));
    memcpy(MTIVOPRDEF->OPER, MWIPOPRDEF->OPER, sizeof(MTIVOPRDEF->OPER));   
    DBC_select_mtivoprdef(1, MTIVOPRDEF);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF->FACTORY), MTIVOPRDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF->OPER), MTIVOPRDEF->OPER);        

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }    

    return MP_TRUE;
}

/*******************************************************************************
    TIV_update_insert_lot_status_history()
        - Insert Lot History
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code                      : Error Message Code 
        - TRSNode *in_node                      : Input TRS Node
        - TRSNode *out_node                     : Output TRS Node
        - char *s_sys_time                      : System Transaction Time
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD : Old INV Lot Status Info
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS        : New INV Lot Status Info
        - struct MTIVLOTHIS_TAG *MTIVLOTHIS        : Insert INV Lot History Info
*******************************************************************************/
int TIV_update_insert_lot_status_history(char *s_msg_code,
                                         TRSNode *in_node,
                                         TRSNode *out_node,
                                         char *s_sys_time_t,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                         struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{
    char s_sys_time[14];
    //struct MTIVLOTHIS_TAG MTIVLOTHIS_GET_HIST_SEQ;
	
    COM_memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));
    memcpy(MTIVLOTHIS->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTHIS->LOT_ID));


	//DBC_init_mtivlothis(&MTIVLOTHIS_GET_HIST_SEQ);
	///*if(MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ>1)
	//{*/
	//	TRS.copy(MTIVLOTHIS_GET_HIST_SEQ.FACTORY, sizeof(MTIVLOTHIS_GET_HIST_SEQ.FACTORY), in_node, IN_FACTORY);
	//	memcpy(MTIVLOTHIS_GET_HIST_SEQ.LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID));
	//	DBC_select_mtivlothis(4, &MTIVLOTHIS_GET_HIST_SEQ);
	//	if(DB_error_code != DB_SUCCESS)
	//	{
	//		if(DB_error_code == DB_NOT_FOUND)
	//		{
	//			/*strcpy(s_msg_code, "INV-0030");
	//			gs_log_type.e_type = MP_LOG_E_EXISTENCE;*/
	//			MTIVLOTHIS_GET_HIST_SEQ.HIST_SEQ = 0;
	//		}
	//		else
	//		{
	//			strcpy(s_msg_code, "INV-0004");
	//			gs_log_type.e_type = MP_LOG_E_SYSTEM;
	//			TRS.add_dberrmsg(out_node, DB_error_msg);
	//			TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
	//			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS_GET_HIST_SEQ.FACTORY), MTIVLOTHIS_GET_HIST_SEQ.FACTORY);
	//			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS_GET_HIST_SEQ.LOT_ID), MTIVLOTHIS_GET_HIST_SEQ.LOT_ID);

	//			return MP_FALSE;
	//		}			
	//	}
	////}
    //
    //MTIVLOTHIS->HIST_SEQ = MTIVLOTHIS_GET_HIST_SEQ.HIST_SEQ + 1;
	MTIVLOTHIS->HIST_SEQ = MTIVLOTSTS->LAST_HIST_SEQ;
    memcpy(MTIVLOTHIS->TRAN_TIME, MTIVLOTSTS->LAST_TRAN_TIME, sizeof(MTIVLOTHIS->TRAN_TIME));
    memcpy(MTIVLOTHIS->SYS_TRAN_TIME, s_sys_time, sizeof(MTIVLOTHIS->SYS_TRAN_TIME));
    memcpy(MTIVLOTHIS->TRAN_CODE, MTIVLOTSTS->LAST_TRAN_CODE, sizeof(MTIVLOTHIS->TRAN_CODE));
    memcpy(MTIVLOTHIS->TRAN_TYPE, MTIVLOTSTS->LAST_TRAN_TYPE, sizeof(MTIVLOTHIS->TRAN_TYPE));    
    
    if(TRS.get_char(in_node,"LOSS_TRAN_FLAG")=='Y')
    {
        memcpy(MTIVLOTHIS->TRAN_USER_ID, TRS.get_string(in_node, "TRAN_USER_ID"), sizeof(MTIVLOTHIS->TRAN_USER_ID));
    }
    else
    {
        TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, IN_USERID);
    }
    
    /****** New INV Lot Status *******/
    memcpy(MTIVLOTHIS->FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTHIS->OPER));
    memcpy(MTIVLOTHIS->MAT_ID, MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTHIS->MAT_ID));
    MTIVLOTHIS->MAT_VER = MTIVLOTSTS->MAT_VER;
    MTIVLOTHIS->LOT_TYPE = MTIVLOTSTS->LOT_TYPE;
    MTIVLOTHIS->QTY_1 = MTIVLOTSTS->QTY_1;
    MTIVLOTHIS->QTY_2 = MTIVLOTSTS->QTY_2;
    MTIVLOTHIS->QTY_3 = MTIVLOTSTS->QTY_3;

    MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS_OLD->QTY_1;  
    MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS_OLD->QTY_2;
    MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS_OLD->QTY_3; 

    MTIVLOTHIS->CREATE_QTY_1 = MTIVLOTSTS->CREATE_QTY_1;
    MTIVLOTHIS->CREATE_QTY_2 = MTIVLOTSTS->CREATE_QTY_2;
    MTIVLOTHIS->CREATE_QTY_3 = MTIVLOTSTS->CREATE_QTY_3;

    memcpy(MTIVLOTHIS->CREATE_TIME, MTIVLOTSTS->CREATE_TIME, sizeof(MTIVLOTHIS->CREATE_TIME));
	memcpy(MTIVLOTHIS->CREATE_CODE, MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTHIS->CREATE_CODE));
	memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));
    MTIVLOTHIS->IN_OUT_FLAG =  MTIVLOTSTS->IN_OUT_FLAG;

    memcpy(MTIVLOTHIS->ORDER_ID, MTIVLOTSTS->ORDER_ID, sizeof(MTIVLOTHIS->ORDER_ID));

    memcpy(MTIVLOTHIS->LINE_NO, MTIVLOTSTS->LINE_NO, sizeof(MTIVLOTHIS->LINE_NO));
    memcpy(MTIVLOTHIS->UNIT_1, MTIVLOTSTS->UNIT_1, sizeof(MTIVLOTHIS->UNIT_1));
    memcpy(MTIVLOTHIS->UNIT_2, MTIVLOTSTS->UNIT_2, sizeof(MTIVLOTHIS->UNIT_2));
    memcpy(MTIVLOTHIS->UNIT_3, MTIVLOTSTS->UNIT_3, sizeof(MTIVLOTHIS->UNIT_3));

    MTIVLOTHIS->INSPECTION_FLAG = MTIVLOTSTS->INSPECTION_FLAG;
    MTIVLOTHIS->INSPECTION_RESULT = MTIVLOTSTS->INSPECTION_RESULT;

    memcpy(MTIVLOTHIS->TRAN_COMMENT, MTIVLOTSTS->LAST_TRAN_COMMENT, sizeof(MTIVLOTHIS->TRAN_COMMENT));

    MTIVLOTHIS->LOT_DEL_FLAG =  MTIVLOTSTS->LOT_DEL_FLAG;

    memcpy(MTIVLOTHIS->LOT_DEL_USER_ID, MTIVLOTSTS->LOT_DEL_USER_ID, sizeof(MTIVLOTHIS->LOT_DEL_USER_ID));
    memcpy(MTIVLOTHIS->LOT_DEL_REASON, MTIVLOTSTS->LOT_DEL_REASON, sizeof(MTIVLOTHIS->LOT_DEL_REASON));
    memcpy(MTIVLOTHIS->LOT_DEL_TIME, MTIVLOTSTS->LOT_DEL_TIME, sizeof(MTIVLOTHIS->LOT_DEL_TIME));
    memcpy(MTIVLOTHIS->LOCATION_NO, MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTHIS->LOCATION_NO));

    MTIVLOTHIS->HOLD_FLAG = MTIVLOTSTS->HOLD_FLAG;
    memcpy(MTIVLOTHIS->HOLD_CODE, MTIVLOTSTS->HOLD_CODE, sizeof(MTIVLOTHIS->HOLD_CODE));
    memcpy(MTIVLOTHIS->RELEASE_CODE, MTIVLOTSTS->RELEASE_CODE, sizeof(MTIVLOTHIS->RELEASE_CODE));

    MTIVLOTHIS->PICK_FLAG = MTIVLOTSTS->PICK_FLAG;
    MTIVLOTHIS->SHIP_FLAG = MTIVLOTSTS->SHIP_FLAG;

    memcpy(MTIVLOTHIS->ADD_ORDER_ID_1, MTIVLOTSTS->ADD_ORDER_ID_1, sizeof(MTIVLOTHIS->ADD_ORDER_ID_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_1, MTIVLOTSTS->ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_2, MTIVLOTSTS->ADD_ORDER_ID_2, sizeof(MTIVLOTHIS->ADD_ORDER_ID_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_2, MTIVLOTSTS->ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_3, MTIVLOTSTS->ADD_ORDER_ID_3, sizeof(MTIVLOTHIS->ADD_ORDER_ID_3));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_3, MTIVLOTSTS->ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_3));
    
    memcpy(MTIVLOTHIS->PO_MAT_ID, MTIVLOTSTS->PO_MAT_ID, sizeof(MTIVLOTHIS->PO_MAT_ID));
    MTIVLOTHIS->PO_SEQ_NUM = MTIVLOTSTS->PO_SEQ_NUM;

    memcpy(MTIVLOTHIS->INV_CMF_1, MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1));
    memcpy(MTIVLOTHIS->INV_CMF_2, MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2));
    memcpy(MTIVLOTHIS->INV_CMF_3, MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3));
    memcpy(MTIVLOTHIS->INV_CMF_4, MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4));
    memcpy(MTIVLOTHIS->INV_CMF_5, MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5));
    memcpy(MTIVLOTHIS->INV_CMF_6, MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6));
    memcpy(MTIVLOTHIS->INV_CMF_7, MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7));
    memcpy(MTIVLOTHIS->INV_CMF_8, MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8));
    memcpy(MTIVLOTHIS->INV_CMF_9, MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9));
    memcpy(MTIVLOTHIS->INV_CMF_10, MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10));
    memcpy(MTIVLOTHIS->INV_CMF_11, MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11));
    memcpy(MTIVLOTHIS->INV_CMF_12, MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12));
    memcpy(MTIVLOTHIS->INV_CMF_13, MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13));
    memcpy(MTIVLOTHIS->INV_CMF_14, MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14));
    memcpy(MTIVLOTHIS->INV_CMF_15, MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15));
    memcpy(MTIVLOTHIS->INV_CMF_16, MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16));
    memcpy(MTIVLOTHIS->INV_CMF_17, MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17));
    memcpy(MTIVLOTHIS->INV_CMF_18, MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18));
    memcpy(MTIVLOTHIS->INV_CMF_19, MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19));
    memcpy(MTIVLOTHIS->INV_CMF_20, MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20));

	memcpy(MTIVLOTHIS->INV_IN_TIME, MTIVLOTSTS->INV_IN_TIME, sizeof(MTIVLOTSTS->INV_IN_TIME));
	memcpy(MTIVLOTHIS->INV_OUT_TIME, MTIVLOTSTS->INV_OUT_TIME, sizeof(MTIVLOTSTS->INV_OUT_TIME));
	memcpy(MTIVLOTHIS->OINV_IN_TIME, MTIVLOTSTS->OINV_IN_TIME, sizeof(MTIVLOTSTS->OINV_IN_TIME));
	memcpy(MTIVLOTHIS->OINV_OUT_TIME, MTIVLOTSTS->OINV_OUT_TIME, sizeof(MTIVLOTSTS->OINV_OUT_TIME));
	memcpy(MTIVLOTHIS->WIP_IN_TIME, MTIVLOTSTS->WIP_IN_TIME, sizeof(MTIVLOTSTS->WIP_IN_TIME));
	memcpy(MTIVLOTHIS->WIP_OUT_TIME, MTIVLOTSTS->WIP_OUT_TIME, sizeof(MTIVLOTSTS->WIP_OUT_TIME));

    memcpy(MTIVLOTHIS->VENDOR_LOT_ID, MTIVLOTSTS->VENDOR_LOT_ID, sizeof(MTIVLOTHIS->VENDOR_LOT_ID));
    memcpy(MTIVLOTHIS->VENDOR_ID, MTIVLOTSTS->VENDOR_ID, sizeof(MTIVLOTHIS->VENDOR_ID));
    memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));

    memcpy(MTIVLOTHIS->FROM_TO_LOT_ID, MTIVLOTSTS->FROM_TO_LOT_ID, sizeof(MTIVLOTHIS->FROM_TO_LOT_ID));
	MTIVLOTHIS->FROM_TO_HIST_SEQ = MTIVLOTSTS->FROM_TO_HIST_SEQ;
    MTIVLOTHIS->FROM_TO_FLAG = MTIVLOTSTS->FROM_TO_FLAG;

    memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS_OLD->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS_OLD->OPER, sizeof(MTIVLOTHIS->OLD_OPER));

    memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS_OLD->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
	
	memcpy(MTIVLOTHIS->INV_CMF_21, MTIVLOTSTS->INV_CMF_21, sizeof(MTIVLOTHIS->INV_CMF_21));
	memcpy(MTIVLOTHIS->INV_CMF_22, MTIVLOTSTS->INV_CMF_22, sizeof(MTIVLOTHIS->INV_CMF_22));
	memcpy(MTIVLOTHIS->INV_CMF_23, MTIVLOTSTS->INV_CMF_23, sizeof(MTIVLOTHIS->INV_CMF_23));
	memcpy(MTIVLOTHIS->INV_CMF_24, MTIVLOTSTS->INV_CMF_24, sizeof(MTIVLOTHIS->INV_CMF_24));
	memcpy(MTIVLOTHIS->INV_CMF_25, MTIVLOTSTS->INV_CMF_25, sizeof(MTIVLOTHIS->INV_CMF_25));
	memcpy(MTIVLOTHIS->INV_CMF_26, MTIVLOTSTS->INV_CMF_26, sizeof(MTIVLOTHIS->INV_CMF_26));
	memcpy(MTIVLOTHIS->INV_CMF_27, MTIVLOTSTS->INV_CMF_27, sizeof(MTIVLOTHIS->INV_CMF_27));
	memcpy(MTIVLOTHIS->INV_CMF_28, MTIVLOTSTS->INV_CMF_28, sizeof(MTIVLOTHIS->INV_CMF_28));
	memcpy(MTIVLOTHIS->INV_CMF_29, MTIVLOTSTS->INV_CMF_29, sizeof(MTIVLOTHIS->INV_CMF_29));
	memcpy(MTIVLOTHIS->INV_CMF_30, MTIVLOTSTS->INV_CMF_30, sizeof(MTIVLOTHIS->INV_CMF_30));
	 
	MTIVLOTHIS->INV_FLAG_1 = MTIVLOTSTS->INV_FLAG_1;
	MTIVLOTHIS->INV_FLAG_2 = MTIVLOTSTS->INV_FLAG_2;
	MTIVLOTHIS->INV_FLAG_3 = MTIVLOTSTS->INV_FLAG_3;
	MTIVLOTHIS->INV_FLAG_4 = MTIVLOTSTS->INV_FLAG_4;
	MTIVLOTHIS->INV_FLAG_5 = MTIVLOTSTS->INV_FLAG_5;

	memcpy(MTIVLOTHIS->ERP_CREATE_DATE, MTIVLOTSTS->ERP_CREATE_DATE, sizeof(MTIVLOTHIS->ERP_CREATE_DATE));
	memcpy(MTIVLOTHIS->ERP_INV_IN_DATE, MTIVLOTSTS->ERP_INV_IN_DATE, sizeof(MTIVLOTHIS->ERP_INV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_OINV_IN_DATE, MTIVLOTSTS->ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS->ERP_OINV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_TRAN_DATE, MTIVLOTSTS->ERP_LAST_TRAN_DATE, sizeof(MTIVLOTHIS->ERP_TRAN_DATE));

	//추가된 것 - 만료일
	memcpy(MTIVLOTHIS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTHIS->EXPIRE_DATE));
		
	memcpy(MTIVLOTSTS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTSTS_OLD->EXPIRE_DATE));

	TRS.copy(MTIVLOTHIS->TRAN_CMF_7, sizeof(MTIVLOTHIS->TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS->TRAN_CMF_8, sizeof(MTIVLOTHIS->TRAN_CMF_8), in_node, "SHIFT");

	//LOT이 없을 경우 새롭게 LOT을 만들어서 HISTORY를 쌓는다. 
    /* Update/Insert Lot Status */
    if(MTIVLOTSTS->LAST_HIST_SEQ > 1)
    {
		DBC_update_mtivlotsts(3, MTIVLOTSTS);
    }
    else
    {
        DBC_insert_mtivlotsts(MTIVLOTSTS);
    }
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "EXPIRE_DATE", MP_STR, sizeof(MTIVLOTSTS->EXPIRE_DATE), MTIVLOTSTS->EXPIRE_DATE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Insert Lot History */
    DBC_insert_mtivlothis(MTIVLOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    TIV_fill_detail_message(out_node, MTIVLOTSTS, MTIVLOTSTS_OLD);

    return MP_TRUE;
}

/*******************************************************************************
    TIV_update_insert_lot_status_history_transfer()
        - Insert Lot History
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - char *s_field_msg : Field Error Message
        - char *s_db_err_msg : DB Error Message
        - char *s_user_id : Transaction User ID
        - char *s_sys_time : System Transaction Time
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD     : Old INV Lot Status Info
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS            : New INV Lot Status Info
        - struct MTIVLOTHIS_TAG *MTIVLOTHIS            : Insert INV Lot History Info
*******************************************************************************/
int TIV_update_insert_lot_status_history_transfer(char *s_msg_code,
                                         TRSNode *in_node,
                                         TRSNode *out_node,                                         
                                         char *s_sys_time_t,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                         struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{
    char s_sys_time[14];
    
    COM_memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));
	
    memcpy(MTIVLOTHIS->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTHIS->LOT_ID));

	MTIVLOTHIS->HIST_SEQ = MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ;

    memcpy(MTIVLOTHIS->TRAN_TIME, MTIVLOTSTS->LAST_TRAN_TIME, sizeof(MTIVLOTHIS->TRAN_TIME));
    memcpy(MTIVLOTHIS->SYS_TRAN_TIME, s_sys_time, sizeof(MTIVLOTHIS->SYS_TRAN_TIME));
    memcpy(MTIVLOTHIS->TRAN_CODE, MTIVLOTSTS->LAST_TRAN_CODE, sizeof(MTIVLOTHIS->TRAN_CODE));
    memcpy(MTIVLOTHIS->TRAN_TYPE, MTIVLOTSTS->LAST_TRAN_TYPE, sizeof(MTIVLOTHIS->TRAN_TYPE));

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}
	
	
    TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, "PRC_USER");

	
    memcpy(MTIVLOTSTS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTSTS->EXPIRE_DATE));
    
    memcpy(MTIVLOTHIS->FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTHIS->OPER));
    memcpy(MTIVLOTHIS->MAT_ID, MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTHIS->MAT_ID));
    MTIVLOTHIS->MAT_VER = MTIVLOTSTS->MAT_VER;
    MTIVLOTHIS->LOT_TYPE = MTIVLOTSTS->LOT_TYPE;
    MTIVLOTHIS->QTY_1 = MTIVLOTSTS->QTY_1;
    MTIVLOTHIS->QTY_2 = MTIVLOTSTS->QTY_2;
    MTIVLOTHIS->QTY_3 = MTIVLOTSTS->QTY_3;        
    MTIVLOTHIS->CREATE_QTY_1 = MTIVLOTSTS->CREATE_QTY_1;
    MTIVLOTHIS->CREATE_QTY_2 = MTIVLOTSTS->CREATE_QTY_2;
    MTIVLOTHIS->CREATE_QTY_3 = MTIVLOTSTS->CREATE_QTY_3;
    memcpy(MTIVLOTHIS->CREATE_TIME, MTIVLOTSTS->CREATE_TIME, sizeof(MTIVLOTHIS->CREATE_TIME));
	memcpy(MTIVLOTHIS->CREATE_CODE, MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTHIS->CREATE_CODE));
	memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));

    MTIVLOTHIS->IN_OUT_FLAG =  MTIVLOTSTS->IN_OUT_FLAG;

	memcpy(MTIVLOTHIS->INV_IN_TIME, MTIVLOTSTS->INV_IN_TIME, sizeof(MTIVLOTHIS->INV_IN_TIME));
	memcpy(MTIVLOTHIS->INV_OUT_TIME, MTIVLOTSTS->INV_OUT_TIME, sizeof(MTIVLOTHIS->INV_OUT_TIME));
	memcpy(MTIVLOTHIS->OINV_IN_TIME, MTIVLOTSTS->OINV_IN_TIME, sizeof(MTIVLOTHIS->OINV_IN_TIME));
	memcpy(MTIVLOTHIS->OINV_OUT_TIME, MTIVLOTSTS->OINV_OUT_TIME, sizeof(MTIVLOTHIS->OINV_OUT_TIME));
	memcpy(MTIVLOTHIS->WIP_IN_TIME, MTIVLOTSTS->WIP_IN_TIME, sizeof(MTIVLOTHIS->WIP_IN_TIME));
	memcpy(MTIVLOTHIS->WIP_OUT_TIME, MTIVLOTSTS->WIP_OUT_TIME, sizeof(MTIVLOTHIS->WIP_OUT_TIME));
	
	memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS_OLD->OPER, sizeof(MTIVLOTHIS->OLD_OPER));
	memcpy(MTIVLOTHIS->OLD_LOCATION_NO, MTIVLOTSTS_OLD->LOCATION_NO, sizeof(MTIVLOTHIS->OLD_LOCATION_NO));
	memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS_OLD->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
	memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS_OLD->FACTORY, sizeof(MTIVLOTHIS->FACTORY));

	MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS_OLD->QTY_1;  
	MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS_OLD->QTY_2;
	MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS_OLD->QTY_3; 

	/*if (TRS.get_char(in_node, "__INSERT_OR_UPDATE") == 'I')
	{
		memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS_OLD->OPER, sizeof(MTIVLOTHIS->OLD_OPER));
		memcpy(MTIVLOTHIS->OLD_LOCATION_NO, MTIVLOTSTS_OLD->LOCATION_NO, sizeof(MTIVLOTHIS->OLD_LOCATION_NO));
		memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS_OLD->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
		memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS_OLD->FACTORY, sizeof(MTIVLOTHIS->FACTORY));

		MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS_OLD->QTY_1;  
		MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS_OLD->QTY_2;
		MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS_OLD->QTY_3; 

	}
	else
	{
		memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTHIS->OLD_OPER));
		memcpy(MTIVLOTHIS->OLD_LOCATION_NO, MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTHIS->OLD_LOCATION_NO));
		memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
		memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));

		MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS->QTY_1;  
		MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS->QTY_2;
		MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS->QTY_3; 

	}*/
    
    //WIP Lot Information
    TRS.copy(MTIVLOTHIS->PROD_LOT_ID, sizeof(MTIVLOTHIS->PROD_LOT_ID), in_node, "PROD_LOT_ID");
    MTIVLOTHIS->PROD_HIST_SEQ = TRS.get_int(in_node, "PROD_HIST_SEQ");
    MTIVLOTHIS->PROD_QTY_1 = TRS.get_double(in_node, "PROD_QTY_1");
    MTIVLOTHIS->PROD_QTY_2 = TRS.get_double(in_node, "PROD_QTY_2");
    MTIVLOTHIS->PROD_QTY_3 = TRS.get_double(in_node, "PROD_QTY_3");

    memcpy(MTIVLOTHIS->ORDER_ID, MTIVLOTSTS->ORDER_ID, sizeof(MTIVLOTHIS->ORDER_ID));

    memcpy(MTIVLOTHIS->LINE_NO, MTIVLOTSTS->LINE_NO, sizeof(MTIVLOTHIS->LINE_NO));

    memcpy(MTIVLOTHIS->UNIT_1, MTIVLOTSTS->UNIT_1, sizeof(MTIVLOTHIS->UNIT_1));
    memcpy(MTIVLOTHIS->UNIT_2, MTIVLOTSTS->UNIT_2, sizeof(MTIVLOTHIS->UNIT_2));
    memcpy(MTIVLOTHIS->UNIT_3, MTIVLOTSTS->UNIT_3, sizeof(MTIVLOTHIS->UNIT_3));

    MTIVLOTHIS->INSPECTION_FLAG =  MTIVLOTSTS->INSPECTION_FLAG;
    MTIVLOTHIS->INSPECTION_RESULT =  MTIVLOTSTS->INSPECTION_RESULT;

    memcpy(MTIVLOTHIS->TRAN_COMMENT, MTIVLOTSTS->LAST_TRAN_COMMENT, sizeof(MTIVLOTHIS->TRAN_COMMENT));

    MTIVLOTHIS->LOT_DEL_FLAG =  MTIVLOTSTS->LOT_DEL_FLAG;

    memcpy(MTIVLOTHIS->LOT_DEL_USER_ID, MTIVLOTSTS->LOT_DEL_USER_ID, sizeof(MTIVLOTHIS->LOT_DEL_USER_ID));
    memcpy(MTIVLOTHIS->LOT_DEL_REASON, MTIVLOTSTS->LOT_DEL_REASON, sizeof(MTIVLOTHIS->LOT_DEL_REASON));
    memcpy(MTIVLOTHIS->LOT_DEL_TIME, MTIVLOTSTS->LOT_DEL_TIME, sizeof(MTIVLOTHIS->LOT_DEL_TIME));
    memcpy(MTIVLOTHIS->LOCATION_NO, MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTHIS->LOCATION_NO));

    MTIVLOTHIS->HOLD_FLAG =  MTIVLOTSTS->HOLD_FLAG;
    memcpy(MTIVLOTHIS->HOLD_CODE, MTIVLOTSTS->HOLD_CODE, sizeof(MTIVLOTHIS->HOLD_CODE));
    memcpy(MTIVLOTHIS->RELEASE_CODE, MTIVLOTSTS->RELEASE_CODE, sizeof(MTIVLOTHIS->RELEASE_CODE));

    MTIVLOTHIS->PICK_FLAG =  MTIVLOTSTS->PICK_FLAG;
    MTIVLOTHIS->SHIP_FLAG =  MTIVLOTSTS->SHIP_FLAG;

    memcpy(MTIVLOTHIS->ADD_ORDER_ID_1, MTIVLOTSTS->ADD_ORDER_ID_1, sizeof(MTIVLOTHIS->ADD_ORDER_ID_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_1, MTIVLOTSTS->ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_2, MTIVLOTSTS->ADD_ORDER_ID_2, sizeof(MTIVLOTHIS->ADD_ORDER_ID_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_2, MTIVLOTSTS->ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_3, MTIVLOTSTS->ADD_ORDER_ID_3, sizeof(MTIVLOTHIS->ADD_ORDER_ID_3));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_3, MTIVLOTSTS->ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_3));
    
    memcpy(MTIVLOTHIS->VENDOR_LOT_ID, MTIVLOTSTS->VENDOR_LOT_ID, sizeof(MTIVLOTHIS->VENDOR_LOT_ID));
    memcpy(MTIVLOTHIS->PO_MAT_ID, MTIVLOTSTS->PO_MAT_ID, sizeof(MTIVLOTHIS->PO_MAT_ID));
    MTIVLOTHIS->PO_SEQ_NUM = MTIVLOTSTS->PO_SEQ_NUM;

    memcpy(MTIVLOTHIS->INV_CMF_1, MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1));
    memcpy(MTIVLOTHIS->INV_CMF_2, MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2));
    memcpy(MTIVLOTHIS->INV_CMF_3, MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3));
    memcpy(MTIVLOTHIS->INV_CMF_4, MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4));
    memcpy(MTIVLOTHIS->INV_CMF_5, MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5));
    memcpy(MTIVLOTHIS->INV_CMF_6, MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6));
    memcpy(MTIVLOTHIS->INV_CMF_7, MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7));
    memcpy(MTIVLOTHIS->INV_CMF_8, MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8));
    memcpy(MTIVLOTHIS->INV_CMF_9, MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9));
    memcpy(MTIVLOTHIS->INV_CMF_10, MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10));
    memcpy(MTIVLOTHIS->INV_CMF_11, MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11));
    memcpy(MTIVLOTHIS->INV_CMF_12, MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12));
    memcpy(MTIVLOTHIS->INV_CMF_13, MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13));
    memcpy(MTIVLOTHIS->INV_CMF_14, MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14));
    memcpy(MTIVLOTHIS->INV_CMF_15, MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15));
    memcpy(MTIVLOTHIS->INV_CMF_16, MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16));
    memcpy(MTIVLOTHIS->INV_CMF_17, MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17));
    memcpy(MTIVLOTHIS->INV_CMF_18, MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18));
    memcpy(MTIVLOTHIS->INV_CMF_19, MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19));
    memcpy(MTIVLOTHIS->INV_CMF_20, MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20));
	memcpy(MTIVLOTHIS->EXPIRE_DATE, MTIVLOTSTS->EXPIRE_DATE, sizeof(MTIVLOTSTS->EXPIRE_DATE));

    memcpy(MTIVLOTHIS->VENDOR_ID, MTIVLOTSTS->VENDOR_ID, sizeof(MTIVLOTHIS->VENDOR_ID));
    memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));
    memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
    
	COM_dtoa(MTIVLOTHIS->TRAN_CMF_1, TRS.get_double(in_node, "MOVE_QTY_1"), sizeof(MTIVLOTHIS->TRAN_CMF_1));
	COM_dtoa(MTIVLOTHIS->TRAN_CMF_2, TRS.get_double(in_node, "MOVE_QTY_2"), sizeof(MTIVLOTHIS->TRAN_CMF_2));
	COM_dtoa(MTIVLOTHIS->TRAN_CMF_3, TRS.get_double(in_node, "MOVE_QTY_3"), sizeof(MTIVLOTHIS->TRAN_CMF_3));
	TRS.copy(MTIVLOTHIS->TRAN_CMF_7, sizeof(MTIVLOTHIS->TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS->TRAN_CMF_8, sizeof(MTIVLOTHIS->TRAN_CMF_8), in_node, "SHIFT");

	if (TRS.get_char(in_node, "TRS_FLAG") == 'Y')
	{
		TRS.copy(MTIVLOTHIS->TRAN_CMF_4, sizeof(MTIVLOTHIS->TRAN_CMF_4), in_node, "TRS_NO");
	}   

	memcpy(MTIVLOTHIS->INV_CMF_21, MTIVLOTSTS->INV_CMF_21, sizeof(MTIVLOTHIS->INV_CMF_21));
	memcpy(MTIVLOTHIS->INV_CMF_22, MTIVLOTSTS->INV_CMF_22, sizeof(MTIVLOTHIS->INV_CMF_22));
	memcpy(MTIVLOTHIS->INV_CMF_23, MTIVLOTSTS->INV_CMF_23, sizeof(MTIVLOTHIS->INV_CMF_23));
	memcpy(MTIVLOTHIS->INV_CMF_24, MTIVLOTSTS->INV_CMF_24, sizeof(MTIVLOTHIS->INV_CMF_24));
	memcpy(MTIVLOTHIS->INV_CMF_25, MTIVLOTSTS->INV_CMF_25, sizeof(MTIVLOTHIS->INV_CMF_25));
	memcpy(MTIVLOTHIS->INV_CMF_26, MTIVLOTSTS->INV_CMF_26, sizeof(MTIVLOTHIS->INV_CMF_26));
	memcpy(MTIVLOTHIS->INV_CMF_27, MTIVLOTSTS->INV_CMF_27, sizeof(MTIVLOTHIS->INV_CMF_27));
	memcpy(MTIVLOTHIS->INV_CMF_28, MTIVLOTSTS->INV_CMF_28, sizeof(MTIVLOTHIS->INV_CMF_28));
	memcpy(MTIVLOTHIS->INV_CMF_29, MTIVLOTSTS->INV_CMF_29, sizeof(MTIVLOTHIS->INV_CMF_29));
	memcpy(MTIVLOTHIS->INV_CMF_30, MTIVLOTSTS->INV_CMF_30, sizeof(MTIVLOTHIS->INV_CMF_30));
	 
	MTIVLOTHIS->INV_FLAG_1 = MTIVLOTSTS->INV_FLAG_1;
	MTIVLOTHIS->INV_FLAG_2 = MTIVLOTSTS->INV_FLAG_2;
	MTIVLOTHIS->INV_FLAG_3 = MTIVLOTSTS->INV_FLAG_3;
	MTIVLOTHIS->INV_FLAG_4 = MTIVLOTSTS->INV_FLAG_4;
	MTIVLOTHIS->INV_FLAG_5 = MTIVLOTSTS->INV_FLAG_5;

	memcpy(MTIVLOTHIS->ERP_CREATE_DATE, MTIVLOTSTS->ERP_CREATE_DATE, sizeof(MTIVLOTHIS->ERP_CREATE_DATE));
	memcpy(MTIVLOTHIS->ERP_INV_IN_DATE, MTIVLOTSTS->ERP_INV_IN_DATE, sizeof(MTIVLOTHIS->ERP_INV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_OINV_IN_DATE, MTIVLOTSTS->ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS->ERP_OINV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_TRAN_DATE, MTIVLOTSTS->ERP_LAST_TRAN_DATE, sizeof(MTIVLOTHIS->ERP_TRAN_DATE));

	if (TRS.get_char(in_node, "__INSERT_OR_UPDATE") == 'I')
    {
        DBC_insert_mtivlotsts(MTIVLOTSTS);
    }
	else
    {	
		if (TRS.get_char(in_node, "__SHIP_FLAG") == 'Y')
		{
			DBC_update_mtivlotsts(9, MTIVLOTSTS);
		}
		else
		{
			DBC_update_mtivlotsts(3, MTIVLOTSTS);
		}
		
	}
	if(DB_error_code != DB_SUCCESS)
    {
	    strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
	 
	if (TRS.get_char(in_node, "__SKIP_HIST_GEN") != 'Y')
	{
		/* Insert Lot History */
		DBC_insert_mtivlothis(MTIVLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{	
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MTIVLOTHIS INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);
			TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			return MP_FALSE;
		}
	}

    TIV_fill_detail_message(out_node, MTIVLOTSTS, MTIVLOTSTS_OLD);
	
    return MP_TRUE;
}


/*******************************************************************************
    TIV_update_insert_lot_status_history_transfer() -
        - Insert Lot History
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - char *s_field_msg : Field Error Message
        - char *s_db_err_msg : DB Error Message
        - char *s_user_id : Transaction User ID
        - char *s_sys_time : System Transaction Time
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD     : Old INV Lot Status Info
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS            : New INV Lot Status Info
        - struct MTIVLOTHIS_TAG *MTIVLOTHIS            : Insert INV Lot History Info
*******************************************************************************/
int TIV_update_insert_lot_status_history_2(char *s_msg_code,
                                         TRSNode *in_node,
                                         TRSNode *out_node,                                         
                                         char *s_sys_time_t,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                         struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{    
    char s_sys_time[14];
   
    COM_memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));
	
    memcpy(MTIVLOTHIS->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTHIS->LOT_ID));

	MTIVLOTHIS->HIST_SEQ = MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ;

    memcpy(MTIVLOTHIS->TRAN_TIME, MTIVLOTSTS->LAST_TRAN_TIME, sizeof(MTIVLOTHIS->TRAN_TIME));
    memcpy(MTIVLOTHIS->SYS_TRAN_TIME, s_sys_time, sizeof(MTIVLOTHIS->SYS_TRAN_TIME));
    memcpy(MTIVLOTHIS->TRAN_CODE, MTIVLOTSTS->LAST_TRAN_CODE, sizeof(MTIVLOTHIS->TRAN_CODE));
    memcpy(MTIVLOTHIS->TRAN_TYPE, MTIVLOTSTS->LAST_TRAN_TYPE, sizeof(MTIVLOTHIS->TRAN_TYPE));

	if (COM_isnullspace(TRS.get_string(in_node, "PRC_USER")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "PRC_USER", TRS.get_userid(in_node));
	}
	

    TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, "PRC_USER");

    memcpy(MTIVLOTSTS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTSTS->EXPIRE_DATE));
    /****** New INV Lot Status *******/
    memcpy(MTIVLOTHIS->FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTHIS->OPER));
    memcpy(MTIVLOTHIS->MAT_ID, MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTHIS->MAT_ID));
    MTIVLOTHIS->MAT_VER = MTIVLOTSTS->MAT_VER;
    MTIVLOTHIS->LOT_TYPE = MTIVLOTSTS->LOT_TYPE;
    MTIVLOTHIS->QTY_1 = MTIVLOTSTS->QTY_1;
    MTIVLOTHIS->QTY_2 = MTIVLOTSTS->QTY_2;
    MTIVLOTHIS->QTY_3 = MTIVLOTSTS->QTY_3;        
    MTIVLOTHIS->CREATE_QTY_1 = MTIVLOTSTS->CREATE_QTY_1;
    MTIVLOTHIS->CREATE_QTY_2 = MTIVLOTSTS->CREATE_QTY_2;
    MTIVLOTHIS->CREATE_QTY_3 = MTIVLOTSTS->CREATE_QTY_3;
    memcpy(MTIVLOTHIS->CREATE_TIME, MTIVLOTSTS->CREATE_TIME, sizeof(MTIVLOTHIS->CREATE_TIME));
	memcpy(MTIVLOTHIS->CREATE_CODE, MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTHIS->CREATE_CODE));
	memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));

    MTIVLOTHIS->IN_OUT_FLAG =  MTIVLOTSTS->IN_OUT_FLAG;

	//NEW INV LOT STATUS WINPAC - MTIVLOTSTS INOUT TIME -> MTIVLOTHIS INOUT TIME
	memcpy(MTIVLOTHIS->INV_IN_TIME, MTIVLOTSTS->INV_IN_TIME, sizeof(MTIVLOTHIS->INV_IN_TIME));
	memcpy(MTIVLOTHIS->INV_OUT_TIME, MTIVLOTSTS->INV_OUT_TIME, sizeof(MTIVLOTHIS->INV_OUT_TIME));
	memcpy(MTIVLOTHIS->OINV_IN_TIME, MTIVLOTSTS->OINV_IN_TIME, sizeof(MTIVLOTHIS->OINV_IN_TIME));
	memcpy(MTIVLOTHIS->OINV_OUT_TIME, MTIVLOTSTS->OINV_OUT_TIME, sizeof(MTIVLOTHIS->OINV_OUT_TIME));
	memcpy(MTIVLOTHIS->WIP_IN_TIME, MTIVLOTSTS->WIP_IN_TIME, sizeof(MTIVLOTHIS->WIP_IN_TIME));
	memcpy(MTIVLOTHIS->WIP_OUT_TIME, MTIVLOTSTS->WIP_OUT_TIME, sizeof(MTIVLOTHIS->WIP_OUT_TIME));
	
    memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS_OLD->OPER, sizeof(MTIVLOTHIS->OLD_OPER));

    memcpy(MTIVLOTHIS->OLD_LOCATION_NO, MTIVLOTSTS_OLD->LOCATION_NO, sizeof(MTIVLOTHIS->OLD_LOCATION_NO));
	memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS_OLD->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
    memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS_OLD->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    

    MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS_OLD->QTY_1;  
    MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS_OLD->QTY_2;
    MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS_OLD->QTY_3; 

    //WIP Lot Information
    TRS.copy(MTIVLOTHIS->PROD_LOT_ID, sizeof(MTIVLOTHIS->PROD_LOT_ID), in_node, "PROD_LOT_ID");
    MTIVLOTHIS->PROD_HIST_SEQ = TRS.get_int(in_node, "PROD_HIST_SEQ");
    MTIVLOTHIS->PROD_QTY_1 = TRS.get_double(in_node, "PROD_QTY_1");
    MTIVLOTHIS->PROD_QTY_2 = TRS.get_double(in_node, "PROD_QTY_2");
    MTIVLOTHIS->PROD_QTY_3 = TRS.get_double(in_node, "PROD_QTY_3");

    memcpy(MTIVLOTHIS->ORDER_ID, MTIVLOTSTS->ORDER_ID, sizeof(MTIVLOTHIS->ORDER_ID));

    memcpy(MTIVLOTHIS->LINE_NO, MTIVLOTSTS->LINE_NO, sizeof(MTIVLOTHIS->LINE_NO));

    memcpy(MTIVLOTHIS->UNIT_1, MTIVLOTSTS->UNIT_1, sizeof(MTIVLOTHIS->UNIT_1));
    memcpy(MTIVLOTHIS->UNIT_2, MTIVLOTSTS->UNIT_2, sizeof(MTIVLOTHIS->UNIT_2));
    memcpy(MTIVLOTHIS->UNIT_3, MTIVLOTSTS->UNIT_3, sizeof(MTIVLOTHIS->UNIT_3));

    MTIVLOTHIS->INSPECTION_FLAG =  MTIVLOTSTS->INSPECTION_FLAG;
    MTIVLOTHIS->INSPECTION_RESULT =  MTIVLOTSTS->INSPECTION_RESULT;

    memcpy(MTIVLOTHIS->TRAN_COMMENT, MTIVLOTSTS->LAST_TRAN_COMMENT, sizeof(MTIVLOTHIS->TRAN_COMMENT));

    MTIVLOTHIS->LOT_DEL_FLAG =  MTIVLOTSTS->LOT_DEL_FLAG;

    memcpy(MTIVLOTHIS->LOT_DEL_USER_ID, MTIVLOTSTS->LOT_DEL_USER_ID, sizeof(MTIVLOTHIS->LOT_DEL_USER_ID));
    memcpy(MTIVLOTHIS->LOT_DEL_REASON, MTIVLOTSTS->LOT_DEL_REASON, sizeof(MTIVLOTHIS->LOT_DEL_REASON));
    memcpy(MTIVLOTHIS->LOT_DEL_TIME, MTIVLOTSTS->LOT_DEL_TIME, sizeof(MTIVLOTHIS->LOT_DEL_TIME));
    memcpy(MTIVLOTHIS->LOCATION_NO, MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTHIS->LOCATION_NO));

    MTIVLOTHIS->HOLD_FLAG =  MTIVLOTSTS->HOLD_FLAG;
    memcpy(MTIVLOTHIS->HOLD_CODE, MTIVLOTSTS->HOLD_CODE, sizeof(MTIVLOTHIS->HOLD_CODE));
    memcpy(MTIVLOTHIS->RELEASE_CODE, MTIVLOTSTS->RELEASE_CODE, sizeof(MTIVLOTHIS->RELEASE_CODE));

    MTIVLOTHIS->PICK_FLAG =  MTIVLOTSTS->PICK_FLAG;
    MTIVLOTHIS->SHIP_FLAG =  MTIVLOTSTS->SHIP_FLAG;

    memcpy(MTIVLOTHIS->ADD_ORDER_ID_1, MTIVLOTSTS->ADD_ORDER_ID_1, sizeof(MTIVLOTHIS->ADD_ORDER_ID_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_1, MTIVLOTSTS->ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_2, MTIVLOTSTS->ADD_ORDER_ID_2, sizeof(MTIVLOTHIS->ADD_ORDER_ID_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_2, MTIVLOTSTS->ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_3, MTIVLOTSTS->ADD_ORDER_ID_3, sizeof(MTIVLOTHIS->ADD_ORDER_ID_3));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_3, MTIVLOTSTS->ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_3));
    
    memcpy(MTIVLOTHIS->VENDOR_LOT_ID, MTIVLOTSTS->VENDOR_LOT_ID, sizeof(MTIVLOTHIS->VENDOR_LOT_ID));
    memcpy(MTIVLOTHIS->PO_MAT_ID, MTIVLOTSTS->PO_MAT_ID, sizeof(MTIVLOTHIS->PO_MAT_ID));
    MTIVLOTHIS->PO_SEQ_NUM = MTIVLOTSTS->PO_SEQ_NUM;

    memcpy(MTIVLOTHIS->INV_CMF_1, MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1));
    memcpy(MTIVLOTHIS->INV_CMF_2, MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2));
    memcpy(MTIVLOTHIS->INV_CMF_3, MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3));
    memcpy(MTIVLOTHIS->INV_CMF_4, MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4));
    memcpy(MTIVLOTHIS->INV_CMF_5, MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5));
    memcpy(MTIVLOTHIS->INV_CMF_6, MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6));
    memcpy(MTIVLOTHIS->INV_CMF_7, MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7));
    memcpy(MTIVLOTHIS->INV_CMF_8, MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8));
    memcpy(MTIVLOTHIS->INV_CMF_9, MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9));
    memcpy(MTIVLOTHIS->INV_CMF_10, MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10));
    memcpy(MTIVLOTHIS->INV_CMF_11, MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11));
    memcpy(MTIVLOTHIS->INV_CMF_12, MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12));
    memcpy(MTIVLOTHIS->INV_CMF_13, MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13));
    memcpy(MTIVLOTHIS->INV_CMF_14, MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14));
    memcpy(MTIVLOTHIS->INV_CMF_15, MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15));
    memcpy(MTIVLOTHIS->INV_CMF_16, MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16));
    memcpy(MTIVLOTHIS->INV_CMF_17, MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17));
    memcpy(MTIVLOTHIS->INV_CMF_18, MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18));
    memcpy(MTIVLOTHIS->INV_CMF_19, MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19));
    memcpy(MTIVLOTHIS->INV_CMF_20, MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20));
	memcpy(MTIVLOTHIS->EXPIRE_DATE, MTIVLOTSTS->EXPIRE_DATE, sizeof(MTIVLOTSTS->EXPIRE_DATE));

    memcpy(MTIVLOTHIS->VENDOR_ID, MTIVLOTSTS->VENDOR_ID, sizeof(MTIVLOTHIS->VENDOR_ID));
    memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));
    memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));

	memcpy(MTIVLOTHIS->INV_CMF_21, MTIVLOTSTS->INV_CMF_21, sizeof(MTIVLOTHIS->INV_CMF_21));
	memcpy(MTIVLOTHIS->INV_CMF_22, MTIVLOTSTS->INV_CMF_22, sizeof(MTIVLOTHIS->INV_CMF_22));
	memcpy(MTIVLOTHIS->INV_CMF_23, MTIVLOTSTS->INV_CMF_23, sizeof(MTIVLOTHIS->INV_CMF_23));
	memcpy(MTIVLOTHIS->INV_CMF_24, MTIVLOTSTS->INV_CMF_24, sizeof(MTIVLOTHIS->INV_CMF_24));
	memcpy(MTIVLOTHIS->INV_CMF_25, MTIVLOTSTS->INV_CMF_25, sizeof(MTIVLOTHIS->INV_CMF_25));
	memcpy(MTIVLOTHIS->INV_CMF_26, MTIVLOTSTS->INV_CMF_26, sizeof(MTIVLOTHIS->INV_CMF_26));
	memcpy(MTIVLOTHIS->INV_CMF_27, MTIVLOTSTS->INV_CMF_27, sizeof(MTIVLOTHIS->INV_CMF_27));
	memcpy(MTIVLOTHIS->INV_CMF_28, MTIVLOTSTS->INV_CMF_28, sizeof(MTIVLOTHIS->INV_CMF_28));
	memcpy(MTIVLOTHIS->INV_CMF_29, MTIVLOTSTS->INV_CMF_29, sizeof(MTIVLOTHIS->INV_CMF_29));
	memcpy(MTIVLOTHIS->INV_CMF_30, MTIVLOTSTS->INV_CMF_30, sizeof(MTIVLOTHIS->INV_CMF_30));
	 
	MTIVLOTHIS->INV_FLAG_1 = MTIVLOTSTS->INV_FLAG_1;
	MTIVLOTHIS->INV_FLAG_2 = MTIVLOTSTS->INV_FLAG_2;
	MTIVLOTHIS->INV_FLAG_3 = MTIVLOTSTS->INV_FLAG_3;
	MTIVLOTHIS->INV_FLAG_4 = MTIVLOTSTS->INV_FLAG_4;
	MTIVLOTHIS->INV_FLAG_5 = MTIVLOTSTS->INV_FLAG_5;

	memcpy(MTIVLOTHIS->ERP_CREATE_DATE, MTIVLOTSTS->ERP_CREATE_DATE, sizeof(MTIVLOTHIS->ERP_CREATE_DATE));
	memcpy(MTIVLOTHIS->ERP_INV_IN_DATE, MTIVLOTSTS->ERP_INV_IN_DATE, sizeof(MTIVLOTHIS->ERP_INV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_OINV_IN_DATE, MTIVLOTSTS->ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS->ERP_OINV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_TRAN_DATE, MTIVLOTSTS->ERP_LAST_TRAN_DATE, sizeof(MTIVLOTHIS->ERP_TRAN_DATE));

   
    if (TRS.get_char(in_node, "__INSERT_OR_UPDATE") == 'I')
    {
        DBC_insert_mtivlotsts(MTIVLOTSTS);
    }        
    else
    {           
        MTIVLOTSTS->LAST_HIST_SEQ = MTIVLOTHIS->HIST_SEQ; 
        MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ = MTIVLOTHIS->HIST_SEQ;
        DBC_update_mtivlotsts(3, MTIVLOTSTS);            
    }
        
    if(DB_error_code != DB_SUCCESS)
    {
	    strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
  
    /* Insert Lot History */
    DBC_insert_mtivlothis(MTIVLOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {	
		strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

	//if( TRS.get_char(in_node, "CREATE_FLAG") == 'Y')
	//{
	//	DBC_init_mtivlotcrt(&MTIVLOTCRT);

	//	memcpy(&MTIVLOTCRT, MTIVLOTHIS, sizeof(MTIVLOTCRT));

	//	DBC_insert_mtivlotcrt(&MTIVLOTCRT);
	//	if(DB_error_code != DB_SUCCESS)
	//	{
	//		//No Error
	//	}
	//}

    TIV_fill_detail_message(out_node, MTIVLOTSTS, MTIVLOTSTS_OLD);
	
    return MP_TRUE;
}

/*******************************************************************************
    TIV_fill_detail_message()
        - INV 트랜잭션에 대한 내용을 Out Message에 채운다.
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - TRSNode *out_node : Out Node 
        - struct MTIVLOTSTS_TAG &MTIVLOTSTS : MTIVLOTSTS
        - struct MTIVLOTSTS_TAG &MTIVLOTSTS_OLD : MTIVLOTSTS_OLD
*******************************************************************************/

int TIV_fill_detail_message(TRSNode *out_node,
                             struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                             struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD)
{
    TRSNode *lot_item;
    
    lot_item = TRS.add_node(out_node, "CINVSTATUS");

    TRS.set_string(lot_item, "FACTORY", MTIVLOTSTS->FACTORY, sizeof(MTIVLOTSTS->FACTORY));
    TRS.set_string(lot_item, "OPER", MTIVLOTSTS->OPER, sizeof(MTIVLOTSTS->OPER));
    TRS.set_string(lot_item, "LOT_ID", MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID));
    TRS.set_string(lot_item, "MAT_ID", MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTSTS->MAT_ID));
    TRS.set_int(lot_item, "MAT_VER", MTIVLOTSTS->MAT_VER);
    TRS.set_double(lot_item, "QTY_1", MTIVLOTSTS->QTY_1);
    TRS.set_double(lot_item, "QTY_2", MTIVLOTSTS->QTY_2);
    TRS.set_double(lot_item, "QTY_3", MTIVLOTSTS->QTY_3);

    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LOT_DESC, MTIVLOTSTS_OLD->LOT_DESC, sizeof(MTIVLOTSTS->LOT_DESC)) != 0)
    {
        TRS.set_string(lot_item, "LOT_DESC", MTIVLOTSTS->LOT_DESC, sizeof(MTIVLOTSTS->LOT_DESC));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->LOT_TYPE != MTIVLOTSTS_OLD->LOT_TYPE)
    {
        TRS.set_char(lot_item, "LOT_TYPE", MTIVLOTSTS->LOT_TYPE);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->CREATE_QTY_1 != MTIVLOTSTS_OLD->CREATE_QTY_1)
    {
        TRS.set_double(lot_item, "CREATE_QTY_1", MTIVLOTSTS->CREATE_QTY_1);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->CREATE_QTY_2 != MTIVLOTSTS_OLD->CREATE_QTY_2)
    {
        TRS.set_double(lot_item, "CREATE_QTY_2", MTIVLOTSTS->CREATE_QTY_2);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->CREATE_QTY_3 != MTIVLOTSTS_OLD->CREATE_QTY_3)
    {
        TRS.set_double(lot_item, "CREATE_QTY_3", MTIVLOTSTS->CREATE_QTY_3);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->CREATE_TIME, MTIVLOTSTS_OLD->CREATE_TIME, sizeof(MTIVLOTSTS->CREATE_TIME)) != 0)
    {
        TRS.set_string(lot_item, "CREATE_TIME", MTIVLOTSTS->CREATE_TIME, sizeof(MTIVLOTSTS->CREATE_TIME));
    }
	if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->CREATE_CODE, MTIVLOTSTS_OLD->CREATE_CODE, sizeof(MTIVLOTSTS->CREATE_CODE)) != 0)
    {
        TRS.set_string(lot_item, "CREATE_CODE", MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTSTS->CREATE_CODE));
    }
	if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->OWNER_CODE, MTIVLOTSTS_OLD->OWNER_CODE, sizeof(MTIVLOTSTS->OWNER_CODE)) != 0)
    {
        TRS.set_string(lot_item, "OWNER_CODE", MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTSTS->OWNER_CODE));
    }

    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->IN_OUT_FLAG != MTIVLOTSTS_OLD->IN_OUT_FLAG)
    {
        TRS.set_char(lot_item, "IN_OUT_FLAG", MTIVLOTSTS->IN_OUT_FLAG);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->ORDER_ID, MTIVLOTSTS_OLD->ORDER_ID, sizeof(MTIVLOTSTS->ORDER_ID)) != 0)
    {
        TRS.set_string(lot_item, "ORDER_ID", MTIVLOTSTS->ORDER_ID, sizeof(MTIVLOTSTS->ORDER_ID));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LINE_NO, MTIVLOTSTS_OLD->LINE_NO, sizeof(MTIVLOTSTS->LINE_NO)) != 0)
    {
        TRS.set_string(lot_item, "LINE_NO", MTIVLOTSTS->LINE_NO, sizeof(MTIVLOTSTS->LINE_NO));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->UNIT_1, MTIVLOTSTS_OLD->UNIT_1, sizeof(MTIVLOTSTS->UNIT_1)) != 0)
    {
        TRS.set_string(lot_item, "UNIT_1", MTIVLOTSTS->UNIT_1, sizeof(MTIVLOTSTS->UNIT_1));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->UNIT_2, MTIVLOTSTS_OLD->UNIT_2, sizeof(MTIVLOTSTS->UNIT_2)) != 0)
    {
        TRS.set_string(lot_item, "UNIT_2", MTIVLOTSTS->UNIT_2, sizeof(MTIVLOTSTS->UNIT_2));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->UNIT_3, MTIVLOTSTS_OLD->UNIT_3, sizeof(MTIVLOTSTS->UNIT_3)) != 0)
    {
        TRS.set_string(lot_item, "UNIT_3", MTIVLOTSTS->UNIT_3, sizeof(MTIVLOTSTS->UNIT_3));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->INSPECTION_FLAG != MTIVLOTSTS_OLD->INSPECTION_FLAG)
    {
        TRS.set_char(lot_item, "INSPECTION_FLAG", MTIVLOTSTS->INSPECTION_FLAG);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->INSPECTION_RESULT != MTIVLOTSTS_OLD->INSPECTION_RESULT)
    {
        TRS.set_char(lot_item, "INSPECTION_RESULT", MTIVLOTSTS->INSPECTION_RESULT);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LAST_TRAN_CODE, MTIVLOTSTS_OLD->LAST_TRAN_CODE, sizeof(MTIVLOTSTS->LAST_TRAN_CODE)) != 0)
    {
        TRS.set_string(lot_item, "LAST_TRAN_CODE", MTIVLOTSTS->LAST_TRAN_CODE, sizeof(MTIVLOTSTS->LAST_TRAN_CODE));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LAST_TRAN_TYPE, MTIVLOTSTS_OLD->LAST_TRAN_TYPE, sizeof(MTIVLOTSTS->LAST_TRAN_TYPE)) != 0)
    {
        TRS.set_string(lot_item, "LAST_TRAN_TYPE", MTIVLOTSTS->LAST_TRAN_TYPE, sizeof(MTIVLOTSTS->LAST_TRAN_TYPE));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LAST_TRAN_TIME, MTIVLOTSTS_OLD->LAST_TRAN_TIME, sizeof(MTIVLOTSTS->LAST_TRAN_TIME)) != 0)
    {
        TRS.set_string(lot_item, "LAST_TRAN_TIME", MTIVLOTSTS->LAST_TRAN_TIME, sizeof(MTIVLOTSTS->LAST_TRAN_TIME));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ != MTIVLOTSTS_OLD->LAST_ACTIVE_HIST_SEQ)
    {
        TRS.set_int(lot_item, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->LAST_HIST_SEQ != MTIVLOTSTS_OLD->LAST_HIST_SEQ)
    {
        TRS.set_int(lot_item, "LAST_HIST_SEQ", MTIVLOTSTS->LAST_HIST_SEQ);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LAST_TRAN_COMMENT, MTIVLOTSTS_OLD->LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS->LAST_TRAN_COMMENT)) != 0)
    {
        TRS.set_string(lot_item, "LAST_TRAN_COMMENT", MTIVLOTSTS->LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS->LAST_TRAN_COMMENT));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->LOT_DEL_FLAG != MTIVLOTSTS_OLD->LOT_DEL_FLAG)
    {
        TRS.set_char(lot_item, "LOT_DEL_FLAG", MTIVLOTSTS->LOT_DEL_FLAG);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LOT_DEL_USER_ID, MTIVLOTSTS_OLD->LOT_DEL_USER_ID, sizeof(MTIVLOTSTS->LOT_DEL_USER_ID)) != 0)
    {
        TRS.set_string(lot_item, "LOT_DEL_USER_ID", MTIVLOTSTS->LOT_DEL_USER_ID, sizeof(MTIVLOTSTS->LOT_DEL_USER_ID));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LOT_DEL_TIME, MTIVLOTSTS_OLD->LOT_DEL_TIME, sizeof(MTIVLOTSTS->LOT_DEL_TIME)) != 0)
    {
        TRS.set_string(lot_item, "LOT_DEL_TIME", MTIVLOTSTS->LOT_DEL_TIME, sizeof(MTIVLOTSTS->LOT_DEL_TIME));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LOT_DEL_REASON, MTIVLOTSTS_OLD->LOT_DEL_REASON, sizeof(MTIVLOTSTS->LOT_DEL_REASON)) != 0)
    {
        TRS.set_string(lot_item, "LOT_DEL_REASON", MTIVLOTSTS->LOT_DEL_REASON, sizeof(MTIVLOTSTS->LOT_DEL_REASON));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->LOCATION_NO, MTIVLOTSTS_OLD->LOCATION_NO, sizeof(MTIVLOTSTS->LOCATION_NO)) != 0)
    {
        TRS.set_string(lot_item, "LOCATION_NO", MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTSTS->LOCATION_NO));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->HOLD_FLAG != MTIVLOTSTS_OLD->HOLD_FLAG)
    {
        TRS.set_char(lot_item, "HOLD_FLAG", MTIVLOTSTS->HOLD_FLAG);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->HOLD_CODE, MTIVLOTSTS_OLD->HOLD_CODE, sizeof(MTIVLOTSTS->HOLD_CODE)) != 0)
    {
        TRS.set_string(lot_item, "HOLD_CODE", MTIVLOTSTS->HOLD_CODE, sizeof(MTIVLOTSTS->HOLD_CODE));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->RELEASE_CODE, MTIVLOTSTS_OLD->RELEASE_CODE, sizeof(MTIVLOTSTS->RELEASE_CODE)) != 0)
    {
        TRS.set_string(lot_item, "RELEASE_CODE", MTIVLOTSTS->RELEASE_CODE, sizeof(MTIVLOTSTS->RELEASE_CODE));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->PICK_FLAG != MTIVLOTSTS_OLD->PICK_FLAG)
    {
        TRS.set_char(lot_item, "PICK_FLAG", MTIVLOTSTS->PICK_FLAG);
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || MTIVLOTSTS->SHIP_FLAG != MTIVLOTSTS_OLD->SHIP_FLAG)
    {
        TRS.set_char(lot_item, "SHIP_FLAG", MTIVLOTSTS->SHIP_FLAG);
    }
    /*if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->FROM_LOT_ID, MTIVLOTSTS_OLD->FROM_LOT_ID, sizeof(MTIVLOTSTS->FROM_LOT_ID)) != 0)
    {
        TRS.set_string(lot_item, "FROM_LOT_ID", MTIVLOTSTS->FROM_LOT_ID, sizeof(MTIVLOTSTS->FROM_LOT_ID));
    }*/
    /*if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->FROM_OPER, MTIVLOTSTS_OLD->FROM_OPER, sizeof(MTIVLOTSTS->FROM_OPER)) != 0)
    {
        TRS.set_string(lot_item, "FROM_OPER", MTIVLOTSTS->FROM_OPER, sizeof(MTIVLOTSTS->FROM_OPER));
    }*/
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->GRADE, MTIVLOTSTS_OLD->GRADE, sizeof(MTIVLOTSTS->GRADE)) != 0)
    {
        TRS.set_string(lot_item, "GRADE", MTIVLOTSTS->GRADE, sizeof(MTIVLOTSTS->GRADE));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->ADD_ORDER_ID_1, MTIVLOTSTS_OLD->ADD_ORDER_ID_1, sizeof(MTIVLOTSTS->ADD_ORDER_ID_1)) != 0)
    {
        TRS.set_string(lot_item, "ADD_ORDER_ID_1", MTIVLOTSTS->ADD_ORDER_ID_1, sizeof(MTIVLOTSTS->ADD_ORDER_ID_1));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->ADD_ORDER_LINE_1, MTIVLOTSTS_OLD->ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS->ADD_ORDER_LINE_1)) != 0)
    {
        TRS.set_string(lot_item, "ADD_ORDER_LINE_1", MTIVLOTSTS->ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS->ADD_ORDER_LINE_1));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->ADD_ORDER_ID_2, MTIVLOTSTS_OLD->ADD_ORDER_ID_2, sizeof(MTIVLOTSTS->ADD_ORDER_ID_2)) != 0)
    {
        TRS.set_string(lot_item, "ADD_ORDER_ID_2", MTIVLOTSTS->ADD_ORDER_ID_2, sizeof(MTIVLOTSTS->ADD_ORDER_ID_2));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->ADD_ORDER_LINE_2, MTIVLOTSTS_OLD->ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS->ADD_ORDER_LINE_2)) != 0)
    {
        TRS.set_string(lot_item, "ADD_ORDER_LINE_2", MTIVLOTSTS->ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS->ADD_ORDER_LINE_2));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->ADD_ORDER_ID_3, MTIVLOTSTS_OLD->ADD_ORDER_ID_3, sizeof(MTIVLOTSTS->ADD_ORDER_ID_3)) != 0)
    {
        TRS.set_string(lot_item, "ADD_ORDER_ID_3", MTIVLOTSTS->ADD_ORDER_ID_3, sizeof(MTIVLOTSTS->ADD_ORDER_ID_3));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->ADD_ORDER_LINE_3, MTIVLOTSTS_OLD->ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS->ADD_ORDER_LINE_3)) != 0)
    {
        TRS.set_string(lot_item, "ADD_ORDER_LINE_3", MTIVLOTSTS->ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS->ADD_ORDER_LINE_3));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->VENDOR_LOT_ID, MTIVLOTSTS_OLD->VENDOR_LOT_ID, sizeof(MTIVLOTSTS->VENDOR_LOT_ID)) != 0)
    {
        TRS.set_string(lot_item, "VENDOR_LOT_ID", MTIVLOTSTS->VENDOR_LOT_ID, sizeof(MTIVLOTSTS->VENDOR_LOT_ID));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_1, MTIVLOTSTS_OLD->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_1", MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_2, MTIVLOTSTS_OLD->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_2", MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_3, MTIVLOTSTS_OLD->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_3", MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_4, MTIVLOTSTS_OLD->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_4", MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_5, MTIVLOTSTS_OLD->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_5", MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_6, MTIVLOTSTS_OLD->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_6", MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_7, MTIVLOTSTS_OLD->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_7", MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_8, MTIVLOTSTS_OLD->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_8", MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_9, MTIVLOTSTS_OLD->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_9", MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_10, MTIVLOTSTS_OLD->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_10", MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_10, MTIVLOTSTS_OLD->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_11", MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_12, MTIVLOTSTS_OLD->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_12", MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_13, MTIVLOTSTS_OLD->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_13", MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_14, MTIVLOTSTS_OLD->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_14", MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_15, MTIVLOTSTS_OLD->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_15", MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_16, MTIVLOTSTS_OLD->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_16", MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_17, MTIVLOTSTS_OLD->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_17", MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_17, MTIVLOTSTS_OLD->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_18", MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_19, MTIVLOTSTS_OLD->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_19", MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19));
    }
    if(MTIVLOTSTS->LAST_HIST_SEQ == 1 || memcmp(MTIVLOTSTS->INV_CMF_20, MTIVLOTSTS_OLD->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20)) != 0)
    {
        TRS.set_string(lot_item, "INV_CMF_20", MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20));
    }
    
   
    return MP_TRUE;
}

/*******************************************************************************
    INV_IQC_Auto_Confirm()
        - Auto Confirm IQC 
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int TIV_IQC_Auto_Confirm(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node)
{
  //  struct MTIVLOTSTS_TAG MTIVLOTSTS;
  //  struct MWIPOPRDEF_TAG MWIPOPRDEF;
  //  struct MTIVOPRDEF_TAG MTIVOPRDEF;

  //  struct MTIVINSDTL_TAG MTIVINSDTL;

  //  TRSNode **lot_list;

  //  int i = 0;    

  //  char s_sys_time[14];

  //  LOG_head("INV_IQC_AUTO_CONFIRM");
  //  COM_log_add_field_msg(in_node);    

  //  COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);    

  //  // get the system time
  //  memset(s_sys_time, ' ', sizeof(s_sys_time));
  //  DB_get_systime(s_sys_time);
  //  if(DB_error_code != DB_SUCCESS)
  //  {
  //      strcpy(s_msg_code, "WIP-0004");
  //      TRS.add_fieldmsg(out_node, "DB_get_systime()", MP_NVST);
  //      TRS.add_dberrmsg(out_node, DB_error_msg);

  //      gs_log_type.type = MP_LOG_ERROR;
  //      gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //      gs_log_type.category = MP_LOG_CATE_TRANS;
  //      COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //      return MP_FALSE;
  //  }    

  //  lot_list = TRS.get_list(in_node, "LOT_LIST");
  //  for (i = 0; i < TRS.get_item_count(in_node, "LOT_LIST"); i++)
  //  {

  //      //Get Lot information
  //      DBC_init_mtivlotsts(&MTIVLOTSTS);
  //      TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
  //      TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), lot_list[i], "LOT_ID");        
  //      DBC_select_mtivlotsts(1, &MTIVLOTSTS);
  //      if(DB_error_code != DB_SUCCESS)
  //      {
  //          if(DB_error_code == DB_NOT_FOUND)
  //          {
  //              strcpy(s_msg_code, "WIP-0044");
  //              gs_log_type.e_type = MP_LOG_E_EXISTENCE;
  //          }
  //          else
  //          {
  //              strcpy(s_msg_code, "WIP-0004");
  //              gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //              TRS.add_dberrmsg(out_node, DB_error_msg);
  //          }
  //          TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
  //          TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
  //          TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.category = MP_LOG_CATE_TRANS;
  //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //          return MP_FALSE;
  //      }

  //      //Get material information
  //      if (INV_get_oper_ext(s_msg_code, out_node,
  //                          TRS.get_factory(in_node), 
  //                          MTIVLOTSTS.OPER,
  //                          &MWIPOPRDEF, &MTIVOPRDEF) == MP_FALSE)
  //      {
  //          return MP_FALSE;
  //      }

  //      //No use IQC process
		////INVOPRDEF사용하지 않음 
  //      /*if(MTIVOPRDEF.IQC_REQ_FLAG == ' ')
  //      {
  //          strcpy(s_msg_code, "INV-0014");

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //          gs_log_type.category = MP_LOG_CATE_SETUP;

  //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //          return MP_FALSE;  
  //      }     */           

  //      //inspection detail information update
  //      DBC_init_mtivinsdtl(&MTIVINSDTL);
  //      TRS.copy(MTIVINSDTL.FACTORY, sizeof(MTIVINSDTL.FACTORY), in_node, IN_FACTORY);
  //      TRS.copy(MTIVINSDTL.INS_NO, sizeof(MTIVINSDTL.INS_NO), in_node, "INS_NO");
  //      MTIVINSDTL.INS_SEQ = TRS.get_int(lot_list[i], "INS_SEQ");
  //      memcpy(MTIVINSDTL.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVINSDTL.LOT_ID));
  //      DBC_select_mtivinsdtl(1, &MTIVINSDTL);
  //      if(DB_error_code != DB_SUCCESS) 
  //      {
  //          strcpy(s_msg_code, "INV-0017");
  //          TRS.add_fieldmsg(out_node, "MTIVINSDTL SELECT", MP_NVST);
  //          TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVINSDTL.FACTORY), MTIVINSDTL.FACTORY);
  //          TRS.add_fieldmsg(out_node, "INS_NO", MP_STR, sizeof(MTIVINSDTL.INS_NO), MTIVINSDTL.INS_NO);
  //          TRS.add_fieldmsg(out_node, "INS_SEQ", MP_INT, MTIVINSDTL.INS_SEQ);
  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVINSDTL.LOT_ID), MTIVINSDTL.LOT_ID);
  //          TRS.add_dberrmsg(out_node, DB_error_msg);

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //          gs_log_type.category = MP_LOG_CATE_SETUP;

  //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //          return MP_FALSE;              
  //      }

  //      ////MTIVINSDTL.HIST_SEQ = MTIVLOTSTS.LAS;
  //      //TRS.copy(MTIVINSDTL.INS_CMF_1, sizeof(MTIVINSDTL.INS_CMF_1), in_node, "INS_CMF_1");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_2, sizeof(MTIVINSDTL.INS_CMF_2), in_node, "INS_CMF_2");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_3, sizeof(MTIVINSDTL.INS_CMF_3), in_node, "INS_CMF_3");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_4, sizeof(MTIVINSDTL.INS_CMF_4), in_node, "INS_CMF_4");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_5, sizeof(MTIVINSDTL.INS_CMF_5), in_node, "INS_CMF_5");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_6, sizeof(MTIVINSDTL.INS_CMF_6), in_node, "INS_CMF_6");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_7, sizeof(MTIVINSDTL.INS_CMF_7), in_node, "INS_CMF_7");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_8, sizeof(MTIVINSDTL.INS_CMF_8), in_node, "INS_CMF_8");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_9, sizeof(MTIVINSDTL.INS_CMF_9), in_node, "INS_CMF_9");                    
  //      //TRS.copy(MTIVINSDTL.INS_CMF_10, sizeof(MTIVINSDTL.INS_CMF_10), in_node, "INS_CMF_10");                    

  //      memcpy(MTIVINSDTL.UPDATE_TIME, s_sys_time, sizeof(MTIVINSDTL.UPDATE_TIME));
  //      TRS.copy(MTIVINSDTL.UPDATE_USER_ID, sizeof(MTIVINSDTL.UPDATE_USER_ID), in_node, IN_USERID);

  //      DBC_update_mtivinsdtl(1, &MTIVINSDTL);
  //      if(DB_error_code != DB_SUCCESS) 
  //      {
  //          strcpy(s_msg_code, "WIP-0004");
  //          TRS.add_fieldmsg(out_node, "MTIVINSDTL UPDATE", MP_NVST);
  //          TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVINSDTL.FACTORY), MTIVINSDTL.FACTORY);
  //          TRS.add_fieldmsg(out_node, "INS_NO", MP_STR, sizeof(MTIVINSDTL.INS_NO), MTIVINSDTL.INS_NO);
  //          TRS.add_fieldmsg(out_node, "INS_SEQ", MP_INT, MTIVINSDTL.INS_SEQ);
  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVINSDTL.LOT_ID), MTIVINSDTL.LOT_ID);

  //          TRS.add_dberrmsg(out_node, DB_error_msg);

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //          gs_log_type.category = MP_LOG_CATE_SETUP;

  //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //          return MP_FALSE;
  //      }                            

  //      TRS.set_string(in_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
  //      TRS.set_string(in_node, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
  //      TRS.set_char(in_node, "INSPECTION_FLAG", MP_INV_IQC_CONFIRM);
  //      
  //      /* IQC inventory lot */
  //      if (TIV_IQC_LOT(s_msg_code, in_node, out_node) != MP_TRUE)
  //      {            
  //          return MP_FALSE;
  //      }                
  //  }    

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_Update_IQC_Master()
        - Update IQC Master
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - char *IQC_Flag   : IQC Flag
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_IQC_Master(char *s_msg_code,
                          char IQC_Flag,
                            TRSNode *in_node, 
                            TRSNode *out_node)
{
    //struct MTIVINSMST_TAG MTIVINSMST;

    //char s_sys_time[14];

    //// get the system time
    //memset(s_sys_time, ' ', sizeof(s_sys_time));
    //DB_get_systime(s_sys_time);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    strcpy(s_msg_code, "WIP-0004");
    //    TRS.add_fieldmsg(out_node, "DB_get_systime()", MP_NVST);
    //    TRS.add_dberrmsg(out_node, DB_error_msg);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    gs_log_type.category = MP_LOG_CATE_TRANS;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}    

    //if(IQC_Flag == MP_INV_ALL || IQC_Flag == MP_INV_IQC_REQUEST)
    //{
    //    /* inspection master information Insert Or Update */
    //    DBC_init_mtivinsmst(&MTIVINSMST);
    //    TRS.copy(MTIVINSMST.FACTORY, sizeof(MTIVINSMST.FACTORY), in_node, IN_FACTORY);
    //    TRS.copy(MTIVINSMST.INS_NO, sizeof(MTIVINSMST.INS_NO), in_node, "INS_NO");
    //    DBC_select_mtivinsmst(1, &MTIVINSMST);
    //    if(DB_error_code == DB_SUCCESS) 
    //    {
    //        strcpy(s_msg_code, "INV-0015");
    //        TRS.add_fieldmsg(out_node, "MTIVINSMST SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVINSMST.FACTORY), MTIVINSMST.FACTORY);
    //        TRS.add_fieldmsg(out_node, "INS_NO", MP_STR, sizeof(MTIVINSMST.INS_NO), MTIVINSMST.INS_NO);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;              
    //    }

    //    if (IQC_Flag == MP_INV_ALL)
    //    {
    //        TRS.copy(MTIVINSMST.REQ_DATE_TIME, sizeof(MTIVINSMST.REQ_DATE_TIME), in_node, "REQ_DATE_TIME");    
    //        TRS.copy(MTIVINSMST.USE_PLAN_DATE, sizeof(MTIVINSMST.USE_PLAN_DATE), in_node, "USE_PLAN_DATE");
    //        MTIVINSMST.INS_PRIORITY = TRS.get_char(in_node, "INS_PRIORITY");

    //        TRS.copy(MTIVINSMST.INS_USER, sizeof(MTIVINSMST.INS_USER), in_node, "INS_USER");
    //        memcpy(MTIVINSMST.CREATE_TIME, s_sys_time, sizeof(MTIVINSMST.CREATE_TIME));
    //        TRS.copy(MTIVINSMST.CREATE_USER_ID, sizeof(MTIVINSMST.CREATE_USER_ID), in_node, IN_USERID);        

    //        TRS.copy(MTIVINSMST.INS_USER, sizeof(MTIVINSMST.INS_USER), in_node, "REQ_USER_ID");        

    //        memcpy(MTIVINSMST.UPDATE_TIME, s_sys_time, sizeof(MTIVINSMST.UPDATE_TIME));
    //        TRS.copy(MTIVINSMST.UPDATE_USER_ID, sizeof(MTIVINSMST.UPDATE_USER_ID), in_node, IN_USERID);    
    //    }
    //    else
    //    {
    //        // Request
    //        TRS.copy(MTIVINSMST.INS_USER, sizeof(MTIVINSMST.INS_USER), in_node, "INS_USER");
    //        TRS.copy(MTIVINSMST.REQ_DATE_TIME, sizeof(MTIVINSMST.REQ_DATE_TIME), in_node, "REQ_DATE_TIME");    
    //        TRS.copy(MTIVINSMST.USE_PLAN_DATE, sizeof(MTIVINSMST.USE_PLAN_DATE), in_node, "USE_PLAN_DATE");
    //        MTIVINSMST.INS_PRIORITY = TRS.get_char(in_node, "INS_PRIORITY");

    //        memcpy(MTIVINSMST.CREATE_TIME, s_sys_time, sizeof(MTIVINSMST.CREATE_TIME));
    //        TRS.copy(MTIVINSMST.CREATE_USER_ID, sizeof(MTIVINSMST.CREATE_USER_ID), in_node, IN_USERID);
    //    }

    //    TRS.copy(MTIVINSMST.INS_CMF_1, sizeof(MTIVINSMST.INS_CMF_1), in_node, "INS_CMF_1");
    //    TRS.copy(MTIVINSMST.INS_CMF_2, sizeof(MTIVINSMST.INS_CMF_2), in_node, "INS_CMF_2");
    //    TRS.copy(MTIVINSMST.INS_CMF_3, sizeof(MTIVINSMST.INS_CMF_3), in_node, "INS_CMF_3");
    //    TRS.copy(MTIVINSMST.INS_CMF_4, sizeof(MTIVINSMST.INS_CMF_4), in_node, "INS_CMF_4");
    //    TRS.copy(MTIVINSMST.INS_CMF_5, sizeof(MTIVINSMST.INS_CMF_5), in_node, "INS_CMF_5");
    //    TRS.copy(MTIVINSMST.INS_CMF_6, sizeof(MTIVINSMST.INS_CMF_6), in_node, "INS_CMF_6");
    //    TRS.copy(MTIVINSMST.INS_CMF_7, sizeof(MTIVINSMST.INS_CMF_7), in_node, "INS_CMF_7");
    //    TRS.copy(MTIVINSMST.INS_CMF_8, sizeof(MTIVINSMST.INS_CMF_8), in_node, "INS_CMF_8");
    //    TRS.copy(MTIVINSMST.INS_CMF_9, sizeof(MTIVINSMST.INS_CMF_9), in_node, "INS_CMF_9");
    //    TRS.copy(MTIVINSMST.INS_CMF_10, sizeof(MTIVINSMST.INS_CMF_10), in_node, "INS_CMF_10");

    //    DBC_insert_mtivinsmst(&MTIVINSMST);
    //    if(DB_error_code != DB_SUCCESS) 
    //    {
    //        strcpy(s_msg_code, "INV-0004");
    //        TRS.add_fieldmsg(out_node, "MTIVINSMST INSERT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVINSMST.FACTORY), MTIVINSMST.FACTORY);
    //        TRS.add_fieldmsg(out_node, "INS_NO", MP_STR, sizeof(MTIVINSMST.INS_NO), MTIVINSMST.INS_NO);

    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}
    //else if(IQC_Flag == MP_INV_IQC_CONFIRM)
    //{
    //    /* inspection master information Insert Or Update */
    //    DBC_init_mtivinsmst(&MTIVINSMST);
    //    TRS.copy(MTIVINSMST.FACTORY, sizeof(MTIVINSMST.FACTORY), in_node, IN_FACTORY);
    //    TRS.copy(MTIVINSMST.INS_NO, sizeof(MTIVINSMST.INS_NO), in_node, "INS_NO");
    //    DBC_select_mtivinsmst(1, &MTIVINSMST);
    //    if(DB_error_code != DB_SUCCESS) 
    //    {
    //        strcpy(s_msg_code, "INV-0004");
    //        TRS.add_fieldmsg(out_node, "MTIVINSMST SELECT", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVINSMST.FACTORY), MTIVINSMST.FACTORY);
    //        TRS.add_fieldmsg(out_node, "INS_NO", MP_STR, sizeof(MTIVINSMST.INS_NO), MTIVINSMST.INS_NO);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;              
    //    }

    //    memcpy(MTIVINSMST.UPDATE_TIME, s_sys_time, sizeof(MTIVINSMST.UPDATE_TIME));
    //    TRS.copy(MTIVINSMST.UPDATE_USER_ID, sizeof(MTIVINSMST.UPDATE_USER_ID), in_node, IN_USERID);

    //    DBC_update_mtivinsmst(1, &MTIVINSMST);
    //    if(DB_error_code != DB_SUCCESS) 
    //    {
    //        strcpy(s_msg_code, "INV-0004");
    //        TRS.add_fieldmsg(out_node, "MTIVINSMST UPDATE", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVINSMST.FACTORY), MTIVINSMST.FACTORY);
    //        TRS.add_fieldmsg(out_node, "INS_NO", MP_STR, sizeof(MTIVINSMST.INS_NO), MTIVINSMST.INS_NO);

    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_TRANS;

    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }
    //}
    return MP_TRUE;
}




/*******************************************************************************
    TIV_Update_TRS_Master()
        - Update  Lot Out Transfer Master
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - char *IQC_Flag   : IQC Flag
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_TRS_Master(char *s_msg_code,
                          char c_step,
						  char *s_trs_no, 
                            TRSNode *in_node, 
                            TRSNode *out_node)
{
    struct MTIVTRSMST_TAG MTIVTRSMST;

    char s_sys_time[14];

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

    /* inspection master information Insert Or Update */
    DBC_init_mtivtrsmst(&MTIVTRSMST);
    TRS.copy(MTIVTRSMST.FACTORY, sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
	memcpy(MTIVTRSMST.TRS_NO, s_trs_no, strlen(s_trs_no));    
    DBC_select_mtivtrsmst_for_update(1, &MTIVTRSMST);
    if(DB_error_code != DB_SUCCESS) 
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            if (c_step == MP_STEP_CREATE)
            {
                TRS.copy(MTIVTRSMST.TRS_USER, sizeof(MTIVTRSMST.TRS_USER), in_node, "TRS_USER");
                TRS.copy(MTIVTRSMST.INV_USER, sizeof(MTIVTRSMST.INV_USER), in_node, "INV_USER");
                TRS.copy(MTIVTRSMST.TRS_DATE_TIME, sizeof(MTIVTRSMST.TRS_DATE_TIME), in_node, "TRS_DATE_TIME");    
                MTIVTRSMST.TRS_PRIORITY = TRS.get_char(in_node, "TRS_PRIORITY");
                MTIVTRSMST.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
                MTIVTRSMST.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");
                TRS.copy(MTIVTRSMST.TRS_COMMENT, sizeof(MTIVTRSMST.TRS_COMMENT), in_node, "TRS_COMMENT");        

                TRS.copy(MTIVTRSMST.TRS_CMF_1, sizeof(MTIVTRSMST.TRS_CMF_1), in_node, "TRS_CMF_1");
                TRS.copy(MTIVTRSMST.TRS_CMF_2, sizeof(MTIVTRSMST.TRS_CMF_2), in_node, "TRS_CMF_2");
                TRS.copy(MTIVTRSMST.TRS_CMF_3, sizeof(MTIVTRSMST.TRS_CMF_3), in_node, "TRS_CMF_3");
                TRS.copy(MTIVTRSMST.TRS_CMF_4, sizeof(MTIVTRSMST.TRS_CMF_4), in_node, "TRS_CMF_4");
                TRS.copy(MTIVTRSMST.TRS_CMF_5, sizeof(MTIVTRSMST.TRS_CMF_5), in_node, "TRS_CMF_5");
                TRS.copy(MTIVTRSMST.TRS_CMF_6, sizeof(MTIVTRSMST.TRS_CMF_6), in_node, "TRS_CMF_6");
                TRS.copy(MTIVTRSMST.TRS_CMF_7, sizeof(MTIVTRSMST.TRS_CMF_7), in_node, "TRS_CMF_7");
                TRS.copy(MTIVTRSMST.TRS_CMF_8, sizeof(MTIVTRSMST.TRS_CMF_8), in_node, "TRS_CMF_8");
                TRS.copy(MTIVTRSMST.TRS_CMF_9, sizeof(MTIVTRSMST.TRS_CMF_9), in_node, "TRS_CMF_9");
                TRS.copy(MTIVTRSMST.TRS_CMF_10, sizeof(MTIVTRSMST.TRS_CMF_10), in_node, "TRS_CMF_10");
                memcpy(MTIVTRSMST.CREATE_TIME, s_sys_time, sizeof(MTIVTRSMST.CREATE_TIME));
                TRS.copy(MTIVTRSMST.CREATE_USER_ID, sizeof(MTIVTRSMST.CREATE_USER_ID), in_node, IN_USERID);

                MTIVTRSMST.INV_FLAG = TRS.get_char(in_node, "INV_FLAG");
                MTIVTRSMST.OSP_FLAG = TRS.get_char(in_node, "OSP_FLAG");
                MTIVTRSMST.RT_FLAG = TRS.get_char(in_node, "RT_FLAG");
                TRS.copy(MTIVTRSMST.RT_REASON, sizeof(MTIVTRSMST.TRS_CMF_10), in_node, "RT_REASON");

                if(MTIVTRSMST.STATUS_FLAG == ' ')
                {
                    MTIVTRSMST.STATUS_FLAG = MP_INV_STATUS_OPEN;
                }

                DBC_insert_mtivtrsmst(&MTIVTRSMST);
                if(DB_error_code != DB_SUCCESS) 
                {
                    strcpy(s_msg_code, "INV-0004");
                    TRS.add_fieldmsg(out_node, "MTIVTRSMST INSERT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
                    TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);

                    TRS.add_dberrmsg(out_node, DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_TRANS;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }
        }
        else
        {
            strcpy(s_msg_code, "INV-0015");
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
    }
    else
    {
		if (c_step == MP_STEP_UPDATE)
		{
			//if(TRS.get_member(in_node, "TRS_USER") != 0x0) TRS.copy(MTIVTRSMST.TRS_USER, sizeof(MTIVTRSMST.TRS_USER), in_node, "TRS_USER");
			if(TRS.get_member(in_node, "INV_USER") != 0x0) TRS.copy(MTIVTRSMST.INV_USER, sizeof(MTIVTRSMST.INV_USER), in_node, "INV_USER");
			if(TRS.get_member(in_node, "TRS_DATE_TIME") != 0x0) TRS.copy(MTIVTRSMST.TRS_DATE_TIME, sizeof(MTIVTRSMST.TRS_DATE_TIME), in_node, "TRS_DATE_TIME");    
			if(TRS.get_member(in_node, "TRS_PRIORITY") != 0x0) MTIVTRSMST.TRS_PRIORITY = TRS.get_char(in_node, "TRS_PRIORITY");
			if(TRS.get_member(in_node, "STATUS_FLAG") != 0x0) MTIVTRSMST.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
			if(TRS.get_member(in_node, "DOC_TYPE") != 0x0) MTIVTRSMST.DOC_TYPE = TRS.get_char(in_node, "DOC_TYPE");
			if(TRS.get_member(in_node, "TRS_COMMENT") != 0x0) TRS.copy(MTIVTRSMST.TRS_COMMENT, sizeof(MTIVTRSMST.TRS_COMMENT), in_node, "TRS_COMMENT");        

			/*if(TRS.get_member(in_node, "TRS_CMF_1") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_1, sizeof(MTIVTRSMST.TRS_CMF_1), in_node, "TRS_CMF_1");
			if(TRS.get_member(in_node, "TRS_CMF_2") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_2, sizeof(MTIVTRSMST.TRS_CMF_2), in_node, "TRS_CMF_2");
			if(TRS.get_member(in_node, "TRS_CMF_3") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_3, sizeof(MTIVTRSMST.TRS_CMF_3), in_node, "TRS_CMF_3");
			*/
			if(TRS.get_member(in_node, "TRS_CMF_4") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_4, sizeof(MTIVTRSMST.TRS_CMF_4), in_node, "TRS_CMF_4");
			
			if(TRS.get_member(in_node, "TRS_CMF_5") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_5, sizeof(MTIVTRSMST.TRS_CMF_5), in_node, "TRS_CMF_5");
			if(TRS.get_member(in_node, "TRS_CMF_6") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_6, sizeof(MTIVTRSMST.TRS_CMF_6), in_node, "TRS_CMF_6");
			if(TRS.get_member(in_node, "TRS_CMF_7") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_7, sizeof(MTIVTRSMST.TRS_CMF_7), in_node, "TRS_CMF_7");
			if(TRS.get_member(in_node, "TRS_CMF_8") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_8, sizeof(MTIVTRSMST.TRS_CMF_8), in_node, "TRS_CMF_8");
			if(TRS.get_member(in_node, "TRS_CMF_9") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_9, sizeof(MTIVTRSMST.TRS_CMF_9), in_node, "TRS_CMF_9");
			if(TRS.get_member(in_node, "TRS_CMF_10") != 0x0) TRS.copy(MTIVTRSMST.TRS_CMF_10, sizeof(MTIVTRSMST.TRS_CMF_10), in_node, "TRS_CMF_10");

			if(TRS.get_member(in_node, "INV_FLAG") != 0x0) MTIVTRSMST.INV_FLAG = TRS.get_char(in_node, "INV_FLAG");
			if(TRS.get_member(in_node, "OSP_FLAG") != 0x0) MTIVTRSMST.OSP_FLAG = TRS.get_char(in_node, "OSP_FLAG");
			if(TRS.get_member(in_node, "RT_FLAG") != 0x0) MTIVTRSMST.RT_FLAG = TRS.get_char(in_node, "RT_FLAG");
			if(TRS.get_member(in_node, "RT_REASON") != 0x0) TRS.copy(MTIVTRSMST.RT_REASON, sizeof(MTIVTRSMST.TRS_CMF_10), in_node, "RT_REASON");

			if(MTIVTRSMST.STATUS_FLAG == ' ')
			{
				MTIVTRSMST.STATUS_FLAG = MP_INV_STATUS_OPEN;
			}

			memcpy(MTIVTRSMST.UPDATE_TIME, s_sys_time, sizeof(MTIVTRSMST.UPDATE_TIME));
			TRS.copy(MTIVTRSMST.UPDATE_USER_ID, sizeof(MTIVTRSMST.UPDATE_USER_ID), in_node, IN_USERID);    

			DBC_update_mtivtrsmst(1, &MTIVTRSMST);
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "INV-0004");
				TRS.add_fieldmsg(out_node, "MTIVTRSMST UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
				TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);

				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			DBC_delete_mtivtrsmst(1, &MTIVTRSMST);
			if(DB_error_code != DB_SUCCESS) 
			{
				strcpy(s_msg_code, "INV-0004");
				TRS.add_fieldmsg(out_node, "MTIVTRSMST DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
				TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);

				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
    }

    return MP_TRUE;
}

/*******************************************************************************
    INV_Update_TRS_Detail_By_Complete()
        - Update  Lot Out Transfer Detail
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - char *IQC_Flag   : IQC Flag
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_TRS_Detail(char *s_msg_code,
								  char c_step,
								  char *s_trs_no,					  
								  char *s_mat_id,					  
								  char *s_lot_id,							  
									TRSNode *in_node, 
									TRSNode *out_node)
{
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    char s_sys_time[14];

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

    if(COM_isnullspace(s_lot_id) == MP_TRUE && COM_isnullspace(s_mat_id) == MP_TRUE)
    {
        DBC_init_mtivtrsdtl(&MTIVTRSDTL);
        TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
	    memcpy(MTIVTRSDTL.TRS_NO, s_trs_no, strlen(s_trs_no));
        memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.UPDATE_TIME));
        TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, IN_USERID);

        MTIVTRSDTL.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");

        DBC_update_mtivtrsdtl(3, &MTIVTRSDTL);
        if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "INV-0004");
            TRS.add_fieldmsg(out_node, "MTIVTRSDTL UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
            TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);

            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else
    {
        /* inspection master information Insert Or Update */
        DBC_init_mtivtrsdtl(&MTIVTRSDTL);
        TRS.copy(MTIVTRSDTL.FACTORY, sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
        memcpy(MTIVTRSDTL.TRS_NO, s_trs_no, strlen(s_trs_no));    	
        memcpy(MTIVTRSDTL.MAT_ID, s_mat_id, strlen(s_mat_id));    	
        memcpy(MTIVTRSDTL.LOT_ID, s_lot_id, strlen(s_lot_id));    	
        DBC_select_mtivtrsdtl_for_update(1, &MTIVTRSDTL);
        if(DB_error_code != DB_SUCCESS) 
        {        
            strcpy(s_msg_code, "INV-0015");
            TRS.add_fieldmsg(out_node, "MTIVTRSDTL SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
            TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;                      
        }
        else
        {
            MTIVTRSDTL.STATUS_FLAG = TRS.get_char(in_node, "STATUS_FLAG");
            memcpy(MTIVTRSDTL.UPDATE_TIME, s_sys_time, sizeof(MTIVTRSDTL.UPDATE_TIME));
            TRS.copy(MTIVTRSDTL.UPDATE_USER_ID, sizeof(MTIVTRSDTL.UPDATE_USER_ID), in_node, IN_USERID);    

            DBC_update_mtivtrsdtl(1, &MTIVTRSDTL);
            if(DB_error_code != DB_SUCCESS) 
            {        
                strcpy(s_msg_code, "INV-0015");
                TRS.add_fieldmsg(out_node, "MTIVTRSDTL UPDATE", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
                TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVTRSDTL.MAT_ID), MTIVTRSDTL.MAT_ID);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVTRSDTL.LOT_ID), MTIVTRSDTL.LOT_ID);
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_TRANS;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;                      
            }
        }
    }
    return MP_TRUE;
}


/*******************************************************************************
    TIV_Update_TRS_Detail_By_Complete()
        - Update  Lot Out Transfer Detail
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - char *IQC_Flag   : IQC Flag
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_Update_TRS_Detail_List(char *s_msg_code,
								  char c_step,
								  char *s_trs_no,								  
									TRSNode *in_node, 
									TRSNode *out_node)
{
    //struct MTIVTRSDTL_TAG MTIVTRSDTL;

    TRSNode **mat_list;
    TRSNode **lot_list;

    char s_sys_time[14];

    int i, j;

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

    mat_list = TRS.get_list(in_node, "MAT_LIST");
    for (i = 0; i < TRS.get_item_count(in_node, "MAT_LIST"); i++)
    {		
        lot_list = TRS.get_list(mat_list[i], "LOT_LIST");
        for (j = 0; j < TRS.get_item_count(mat_list[i], "LOT_LIST"); j++)
        {
            TRS.set_nstring(lot_list[j], IN_FACTORY, TRS.get_factory(in_node));
            TRS.set_char(lot_list[j], IN_LANGUAGE, TRS.get_language(in_node));
            TRS.set_enc_nstring(lot_list[j], IN_USERID, TRS.get_userid(in_node));
			TRS.add_enc_nstring(lot_list[j], IN_PASSWORD, TRS.get_password(in_node));

            // Request Master Insert
            if(TIV_Update_TRS_Detail(s_msg_code,  MP_STEP_UPDATE, TRS.get_string(in_node, "TRS_NO"),
                TRS.get_string(mat_list[i], "MAT_ID"), TRS.get_string(lot_list[j], "LOT_ID"),
                lot_list[j], out_node) == MP_FALSE) 
            {
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
    }
    return MP_TRUE;
}
/*******************************************************************************
    TIV_lot_tran_validation()
        - check validatiton of lot transaction value except flow
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code 
            + Message Code to be returned
        - char *s_field_msg
            + Field Key Message to be returned
        - char *s_db_err_msg
            + DB Error Message to be returned
        - char *s_factory
            + input factory
        - char *s_lot_id
            + input lot id
        - int i_last_active_hist_seq
            + input last active hist sequence
        - char *s_mat_id
            + input material id
        - int i_mat_ver
            + input material version
        - char *s_oper 
            + input operation
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS 
            + retrived lot information
        - struct MWIPFACDEF_TAG *MWIPFACDEF 
            + retrived factory information
        - struct MWIPMATDEF_TAG *MWIPMATDEF 
            + retrived material information
        - struct MWIPOPRDEF_TAG *MWIPOPRDEF 
            + retrived operation information
        - char *s_user_id
            + for check privilege
*******************************************************************************/
int TIV_lot_tran_validation(char *s_msg_code, 
                            TRSNode *out_node,
                            TRSNode *in_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
                            struct MWIPFACDEF_TAG *MWIPFACDEF,
                            struct MWIPMATDEF_TAG *MWIPMATDEF,
                            struct MTIVOPRDEF_TAG *MTIVOPRDEF)
{    
	char s_factory[10];

	memset(s_factory, ' ', sizeof(s_factory));
	
	if (COM_isnullspace(TRS.get_string(in_node, "SHIP_FACTORY")) == MP_FALSE)
	{
		TRS.copy(s_factory, sizeof(s_factory), in_node, "SHIP_FACTORY");
	}
	else
	{
		TRS.copy(s_factory, sizeof(s_factory), in_node, IN_FACTORY);
	}

    /* Lot ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "INV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_NVST);

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

    DBC_init_mtivlotsts(MTIVLOTSTS);
    memcpy(MTIVLOTSTS->FACTORY, s_factory, sizeof(MTIVLOTSTS->FACTORY));
    TRS.copy(MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID), in_node, "INV_LOT_ID");
	TRS.copy(MTIVLOTSTS->OPER, sizeof(MTIVLOTSTS->OPER), in_node, "OPER"); 
    DBC_select_mtivlotsts_for_update(2, MTIVLOTSTS);
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
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
   
	if (TRS.get_char(in_node, "IGNORE_INPUT_STS") != 'Y')
	{
		if (COM_isnullspace(MTIVLOTSTS->INV_CMF_8) == MP_FALSE)
		{
			/*strcpy(s_msg_code, "WIP-0731");  
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
			TRS.add_fieldmsg(out_node, "INV_CMF_8", MP_STR, sizeof(MTIVLOTSTS->INV_CMF_8), MTIVLOTSTS->INV_CMF_8);
			TRS.add_fieldmsg(out_node, "INV_CMF_9", MP_STR, sizeof(MTIVLOTSTS->INV_CMF_9), MTIVLOTSTS->INV_CMF_9);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			return MP_FALSE;*/
		}
	}

    /*if(TRS.mem_cmp(in_node, IN_FACTORY, MTIVLOTSTS->FACTORY, strlen(TRS.get_string(in_node, IN_FACTORY))) != 0)
    {
        strcpy(s_msg_code, "WIP-0063");
        TRS.add_fieldmsg(out_node, "FACTORY 1", MP_NSTR, TRS.get_string(in_node, IN_FACTORY));
        TRS.add_fieldmsg(out_node, "FACTORY 2", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }*/

    if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") < 1)
    {
        /*strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;*/    
    }
    else
    {

        //TRS.set_nstring(in_node, "__F_INV_LOT_ID", TRS.get_string(in_node, "INV_LOT_ID"));
        //if (INV_Get_Last_Active_Lot_Grp_Seq(s_msg_code, in_node, out_node) == MP_FALSE)
        //{
        //    return MP_FALSE;
        //}
        //
        ///* Hist Seq Validation */
  //      if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != TRS.get_int(in_node, "__F_LAST_ACTIVE_HIST_SEQ")) 
  //      {
  //          strcpy(s_msg_code, "WIP-0113");
  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
  //          TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ);
  //          TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_VALIDATION;
  //          gs_log_type.category = MP_LOG_CATE_COMMON;
  //          return MP_FALSE;
  //      }


        /* Hist Seq Validation */
        if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ) 
        {
            strcpy(s_msg_code, "WIP-0113");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
            TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ);
            TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
        }


        /* Material Validation */
        if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
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
            if(TRS.mem_cmp(in_node, "MAT_ID", MTIVLOTSTS->MAT_ID, strlen(TRS.get_string(in_node, "MAT_ID"))) != 0)
            {
                strcpy(s_msg_code, "WIP-0064");
                TRS.add_fieldmsg(out_node, "MAT_ID 1", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
                TRS.add_fieldmsg(out_node, "MAT_ID 2", MP_STR, sizeof(MTIVLOTSTS->MAT_ID), MTIVLOTSTS->MAT_ID);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
			// Version check disable by Derek Oh for DTR 20151214
           /* if(TRS.get_int(in_node, "MAT_VER") != MTIVLOTSTS->MAT_VER)
            {
                strcpy(s_msg_code, "WIP-0331");
                TRS.add_fieldmsg(out_node, "MAT_VER 1", MP_INT, TRS.get_int(in_node, "MAT_VER"));
                TRS.add_fieldmsg(out_node, "MAT_VER 2", MP_INT, MTIVLOTSTS->MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }          */ 
        }       
    }

    DBC_init_mwipfacdef(MWIPFACDEF);
    TRS.copy(MWIPFACDEF->FACTORY, sizeof(MWIPFACDEF->FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, MWIPFACDEF);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF->FACTORY), MWIPFACDEF->FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

	if (TRS.get_char(in_node, "SHIP_RTN_FLAG") != 'Y')
	{
		DBC_init_mtivoprdef(MTIVOPRDEF);
		TRS.copy(MTIVOPRDEF->FACTORY, sizeof(MTIVOPRDEF->FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVOPRDEF->OPER, sizeof(MTIVOPRDEF->OPER), in_node, "OPER");
		DBC_select_mtivoprdef(1, MTIVOPRDEF);
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
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF->FACTORY), MTIVOPRDEF->FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF->OPER), MTIVOPRDEF->OPER);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			return MP_FALSE;
		}

		DBC_init_mwipmatdef(MWIPMATDEF);
		TRS.copy(MWIPMATDEF->FACTORY, sizeof(MWIPMATDEF->FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPMATDEF->MAT_ID, TRS.get_string(in_node,"MAT_ID"), sizeof(MWIPMATDEF->MAT_ID));
		MWIPMATDEF->MAT_VER = TRS.get_int(in_node, "MAT_VER");    
		DBC_select_mwipmatdef(1, MWIPMATDEF);
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
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF->FACTORY), MWIPMATDEF->FACTORY);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF->MAT_ID), MWIPMATDEF->MAT_ID);
			TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF->MAT_VER);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			return MP_FALSE;
		} 

	}

    
    //if(MWIPOPRDEF->SEC_CHK_FLAG == 'Y')
    //{
    //    if(TRS.get_char(in_node, MP_NOTCHECK_PRIVILEGE) != 'Y')
    //    {
    //        /* Privilege Validation */
    //        if(COM_check_privilege(s_msg_code, 
    //                               out_node, 
    //                               '2',
    //                               MWIPOPRDEF->FACTORY, 
    //                               MP_PRV_TYPE_OPER,
    //                               MWIPOPRDEF->OPER,
    //                               sizeof(MWIPOPRDEF->OPER),
    //                               "",
    //                               0,
    //                               "",
    //                               0,
    //                               TRS.get_userid(in_node)) == MP_FALSE)
    //        {
    //            return MP_FALSE;
    //        }
    //    }
    //}


    
        
    /* Back Time Check */
    if(TIV_check_backtime(s_msg_code,
                            in_node,
                            out_node,
                            MTIVLOTSTS->LAST_TRAN_TIME) == MP_FALSE)
    {
        return MP_FALSE;
        
    } 

    return MP_TRUE;
}

int TIV_lot_tran_validation_wip(char *s_msg_code, 
                               TRSNode *out_node,
                               TRSNode *in_node,
                               struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
                               struct MWIPFACDEF_TAG *MWIPFACDEF,
                               struct MWIPMATDEF_TAG *MWIPMATDEF,
                               struct MWIPOPRDEF_TAG *MWIPOPRDEF)
{
    
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
    
    /* Lot ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WIP_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "WIP_LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    
    DBC_init_mwiplotsts(MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS->LOT_ID, sizeof(MWIPLOTSTS->LOT_ID), in_node, "WIP_LOT_ID");
    DBC_select_mwiplotsts_for_update(1, MWIPLOTSTS);
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
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS->LOT_ID), MWIPLOTSTS->LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
   
    if(TRS.mem_cmp(in_node, IN_FACTORY, MWIPLOTSTS->FACTORY, strlen(TRS.get_string(in_node, IN_FACTORY))) != 0)
    {
        strcpy(s_msg_code, "WIP-0063");
        TRS.add_fieldmsg(out_node, "FACTORY 1", MP_NSTR, TRS.get_string(in_node, IN_FACTORY));
        TRS.add_fieldmsg(out_node, "FACTORY 2", MP_STR, sizeof(MWIPLOTSTS->FACTORY), MWIPLOTSTS->FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    if(TRS.get_int(in_node, "WIP_LAST_ACTIVE_HIST_SEQ") < 1)
    {
        //strcpy(s_msg_code, "INV-0001");
        //TRS.add_fieldmsg(out_node, "WIP_LAST_ACTIVE_HIST_SEQ", MP_NVST);

        //gs_log_type.type = MP_LOG_ERROR;
        //gs_log_type.e_type = MP_LOG_E_VALIDATION;
        //gs_log_type.category = MP_LOG_CATE_TRANS;
        //return MP_FALSE;
    }
    else
    {
        /* Hist Seq Validation */
        if(TRS.get_int(in_node, "WIP_LAST_ACTIVE_HIST_SEQ") != MWIPLOTSTS->LAST_ACTIVE_HIST_SEQ) 
        {
            strcpy(s_msg_code, "WIP-0113");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS->LOT_ID), MWIPLOTSTS->LOT_ID);
            TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MWIPLOTSTS->LAST_ACTIVE_HIST_SEQ);
            TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
        }
        
    }

    DBC_init_mwipmatdef(MWIPMATDEF);
    TRS.copy(MWIPMATDEF->FACTORY, sizeof(MWIPMATDEF->FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPMATDEF->MAT_ID, MWIPLOTSTS->MAT_ID, sizeof(MWIPMATDEF->MAT_ID));
    //TRS.copy(MWIPMATDEF->MAT_ID, sizeof(MWIPMATDEF->MAT_ID), in_node, "MAT_ID");
    MWIPMATDEF->MAT_VER = MWIPLOTSTS->MAT_VER;
    DBC_select_mwipmatdef(1, MWIPMATDEF);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF->FACTORY), MWIPMATDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF->MAT_ID), MWIPMATDEF->MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF->MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    DBC_init_mwipoprdef(MWIPOPRDEF);
    TRS.copy(MWIPOPRDEF->FACTORY, sizeof(MWIPOPRDEF->FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPOPRDEF->OPER, MWIPLOTSTS->OPER, sizeof(MWIPOPRDEF->OPER));
    //TRS.copy(MWIPOPRDEF->OPER, sizeof(MWIPOPRDEF->OPER), in_node, "OPER");
    DBC_select_mwipoprdef(1, MWIPOPRDEF);
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
        TRS.add_fieldmsg(out_node, "MWIPOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPOPRDEF->FACTORY), MWIPOPRDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MWIPOPRDEF->OPER), MWIPOPRDEF->OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Lot Delete Validation */
    if(MWIPLOTSTS->LOT_DEL_FLAG == 'Y')
    {
        strcpy(s_msg_code, "WIP-0076");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS->LOT_ID), MWIPLOTSTS->LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

   
    return MP_TRUE;
}

int TIV_update_assy_info(char *s_msg_code,
                         TRSNode *in_node,
                         TRSNode *out_node)
{
    struct MTIVLOTASY_TAG MTIVLOTASY;
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    struct MWIPLOTSTS_TAG MWIPLOTSTS;

    BOOL bError;

    if ((TRS.get_char(in_node, "__ASSY_STEP") != 'A') && 
        (TRS.get_char(in_node, "__ASSY_STEP") != 'D') && 
        (TRS.get_char(in_node, "__ASSY_STEP") != 'U'))
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "__ASSY_STEP", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
    
	bError = 0;

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "__WIP_LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
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
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
    
    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "INV_LOT_ID");

    DBC_select_mtivlotsts(1, &MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    DBC_init_mtivlotasy(&MTIVLOTASY);
    TRS.copy(MTIVLOTASY.FACTORY, sizeof(MTIVLOTASY.FACTORY), in_node, IN_FACTORY);    
    memcpy(MTIVLOTASY.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTASY.LOT_ID));
	memcpy(MTIVLOTASY.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTASY.MAT_ID));
	MTIVLOTASY.MAT_VER = MTIVLOTSTS.MAT_VER;
    MTIVLOTASY.HIST_SEQ = MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ;
    memcpy(MTIVLOTASY.WIP_LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MTIVLOTASY.WIP_LOT_ID));
    MTIVLOTASY.WIP_HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;

	if(MWIPLOTSTS.QTY_1 <= TRS.get_double(in_node, "USE_QTY_1"))
		MTIVLOTASY.USE_QTY_1 = MWIPLOTSTS.QTY_1;    
	else
		MTIVLOTASY.USE_QTY_1 = TRS.get_double(in_node, "USE_QTY_1");    

	if(MWIPLOTSTS.QTY_2 <= TRS.get_double(in_node, "USE_QTY_2"))
		MTIVLOTASY.USE_QTY_2 = MWIPLOTSTS.QTY_2;    
	else
		MTIVLOTASY.USE_QTY_2 = TRS.get_double(in_node, "USE_QTY_2");    

	if(MWIPLOTSTS.QTY_3 <= TRS.get_double(in_node, "USE_QTY_3"))
		MTIVLOTASY.USE_QTY_3 = MWIPLOTSTS.QTY_3;    
	else
		MTIVLOTASY.USE_QTY_3 = TRS.get_double(in_node, "USE_QTY_3");        

    DBC_select_mtivlotasy_for_update(1, &MTIVLOTASY);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            if ((TRS.get_char(in_node, "__ASSY_STEP") == 'A') || 
                (TRS.get_char(in_node, "__ASSY_STEP") == 'D'))
            {
                bError = 0;
            }
            else 
            {
                strcpy(s_msg_code, "INV-0032");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;    
                bError = 1;
            }            
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
            bError = 1;
        }         
    }
    else
    {
        if ((TRS.get_char(in_node, "__ASSY_STEP") == 'A') || 
            (TRS.get_char(in_node, "__ASSY_STEP") == 'D'))
        {
            strcpy(s_msg_code, "INV-0033");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            bError = 1;
        }
        else 
        {            
            bError = 0;
        }        
    }

    if (bError == 1)
    {            
        TRS.add_fieldmsg(out_node, "MTIVLOTASY SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTASY.LOT_ID), MTIVLOTASY.LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTASY.HIST_SEQ);
        TRS.add_fieldmsg(out_node, "WIP_LOT_ID", MP_STR, sizeof(MTIVLOTASY.WIP_LOT_ID), MTIVLOTASY.WIP_LOT_ID);
        TRS.add_fieldmsg(out_node, "WIP_HIST_SEQ", MP_INT, MTIVLOTASY.WIP_HIST_SEQ);
        
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    if (TRS.get_char(in_node, "__ASSY_STEP") == 'A')
    {
        memcpy(MTIVLOTASY.TRAN_CODE, MP_INV_TRAN_CODE_ASSY, strlen(MP_INV_TRAN_CODE_ASSY));
        memcpy(MTIVLOTASY.WIP_MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MTIVLOTASY.WIP_MAT_ID));
        MTIVLOTASY.WIP_MAT_VER = MWIPLOTSTS.MAT_VER;    
        TRS.copy(MTIVLOTASY.TRAN_TIME, sizeof(MTIVLOTASY.TRAN_TIME), in_node, "__SYS_TIME");
        DBC_insert_mtivlotasy(&MTIVLOTASY);
    }
    else if (TRS.get_char(in_node, "__ASSY_STEP") == 'D')
    {
        memcpy(MTIVLOTASY.TRAN_CODE, MP_INV_TRAN_CODE_DISASSY, strlen(MP_INV_TRAN_CODE_DISASSY));
        memcpy(MTIVLOTASY.WIP_MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MTIVLOTASY.WIP_MAT_ID));
        MTIVLOTASY.WIP_MAT_VER = MWIPLOTSTS.MAT_VER;    
        TRS.copy(MTIVLOTASY.TRAN_TIME, sizeof(MTIVLOTASY.TRAN_TIME), in_node, "__SYS_TIME");
        DBC_insert_mtivlotasy(&MTIVLOTASY);
    }
    else if (TRS.get_char(in_node, "__ASSY_STEP") == 'U')
    {
        MTIVLOTASY.HIST_DEL_FLAG = 'Y';
        DBC_update_mtivlotasy(1, &MTIVLOTASY);
    }    
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MTIVLOTASY ", MP_NVST);
        TRS.add_fieldmsg(out_node, "__ASSY_STEP", MP_CHR, TRS.get_char(in_node, "__ASSY_STEP"));
       
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

   
    return MP_TRUE;
}



int TIV_Lot_Fill_InTag_Cmf(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    TRSNode *member;

    if(COM_isnullspace(TRS.get_string(in_node, "TIV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS);
 //   TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, "__FACTORY");
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "TIV_LOT_ID");

	//if (COM_isnullspace(TRS.get_string(in_node, "FROM_OPER")) == MP_FALSE)
	//	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "FROM_OPER");
	//else if (COM_isnullspace(TRS.get_string(in_node, "TIV_OPER")) == MP_FALSE)
	//	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "TIV_OPER");
	//else if (COM_isnullspace(TRS.get_string(in_node, "OPER")) == MP_FALSE)
	//	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
	//else if (COM_isnullspace(TRS.get_string(in_node, "INV_OPER")) == MP_FALSE)
	//	TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "INV_OPER");
	
 //   DBC_select_mtivlotsts(4, &MTIVLOTSTS);
    DBC_select_mtivlotsts(20, &MTIVLOTSTS);
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
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        //TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if((member = TRS.get_member(in_node, "ORDER_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
    }    

     if((member = TRS.get_member(in_node, "INV_CMF_1")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_2")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_3")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_4")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_5")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_6")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_7")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_8")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_9")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_10")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_11")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_12")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_13")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_14")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_15")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_16")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_17")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_18")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_19")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_20")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
    }

    if((member = TRS.get_member(in_node, "VENDOR_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
    }

	if((member = TRS.get_member(in_node, "INV_FLAG_1")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_1") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_1", MTIVLOTSTS.INV_FLAG_1);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_2")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_2") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_2", MTIVLOTSTS.INV_FLAG_2);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_3")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_3") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_3", MTIVLOTSTS.INV_FLAG_3);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_4")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_4") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_4", MTIVLOTSTS.INV_FLAG_4);
    }
	if((member = TRS.get_member(in_node, "INV_FLAG_5")) == 0x00 || member->NullFlag == 'Y' || TRS.get_char(in_node, "INV_FLAG_5") == ' ')
    {
        TRS.set_char(in_node, "INV_FLAG_5", MTIVLOTSTS.INV_FLAG_5);
    }

	if((member = TRS.get_member(in_node, "INV_CMF_21")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_21", MTIVLOTSTS.INV_CMF_21, sizeof(MTIVLOTSTS.INV_CMF_21));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_22")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_22", MTIVLOTSTS.INV_CMF_22, sizeof(MTIVLOTSTS.INV_CMF_22));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_23")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_23", MTIVLOTSTS.INV_CMF_23, sizeof(MTIVLOTSTS.INV_CMF_23));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_24")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_24", MTIVLOTSTS.INV_CMF_24, sizeof(MTIVLOTSTS.INV_CMF_24));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_25")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_25", MTIVLOTSTS.INV_CMF_25, sizeof(MTIVLOTSTS.INV_CMF_25));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_26")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_26", MTIVLOTSTS.INV_CMF_26, sizeof(MTIVLOTSTS.INV_CMF_26));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_27")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_27", MTIVLOTSTS.INV_CMF_27, sizeof(MTIVLOTSTS.INV_CMF_27));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_28")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_28", MTIVLOTSTS.INV_CMF_28, sizeof(MTIVLOTSTS.INV_CMF_28));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_29")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_29", MTIVLOTSTS.INV_CMF_29, sizeof(MTIVLOTSTS.INV_CMF_29));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_30")) == 0x00 || member->NullFlag == 'Y')
    {
        TRS.set_string(in_node, "INV_CMF_30", MTIVLOTSTS.INV_CMF_30, sizeof(MTIVLOTSTS.INV_CMF_30));
    }

	if((member = TRS.get_member(in_node, "ERP_CREATE_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_CREATE_DATE", MTIVLOTSTS.ERP_CREATE_DATE, sizeof(MTIVLOTSTS.ERP_CREATE_DATE));
    }
	if((member = TRS.get_member(in_node, "ERP_INV_IN_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_INV_IN_DATE", MTIVLOTSTS.ERP_INV_IN_DATE, sizeof(MTIVLOTSTS.ERP_INV_IN_DATE));
    }
	if((member = TRS.get_member(in_node, "ERP_OINV_IN_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_OINV_IN_DATE", MTIVLOTSTS.ERP_OINV_IN_DATE, sizeof(MTIVLOTSTS.ERP_OINV_IN_DATE));
    }
	if((member = TRS.get_member(in_node, "ERP_LAST_TRAN_DATE")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "ERP_LAST_TRAN_DATE", MTIVLOTSTS.ERP_LAST_TRAN_DATE, sizeof(MTIVLOTSTS.ERP_LAST_TRAN_DATE));
    }
	if((member = TRS.get_member(in_node, "LAST_TRAN_USER_ID")) == 0x00 || member->NullFlag == 'Y')
    {
		TRS.set_string(in_node, "LAST_TRAN_USER_ID", MTIVLOTSTS.LAST_TRAN_USER_ID, sizeof(MTIVLOTSTS.LAST_TRAN_USER_ID));
    }


    return MP_TRUE;
}

int TIV_Lot_Reset_InTag_Cmf(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{   
    TRS.set_string(in_node, "ORDER_ID", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_1", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_2", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_3", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_4", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_5", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_6", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_7", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_8", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_9", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_10", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_11", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_12", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_13", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_14", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_15", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_16", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_17", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_18", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_19", " ", sizeof(" "));
    TRS.set_string(in_node, "INV_CMF_20", " ", sizeof(" "));
    TRS.set_string(in_node, "VENDOR_ID", " ", sizeof(" "));
    
    return MP_TRUE;
}

int TIV_Get_Last_Active_Lot_Grp_Seq(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node)
{   
    struct MTIVLOTHIS_TAG MTIVLOTHIS;
    int i_last_active_lot_grp_seq;
    
    DBC_init_mtivlothis(&MTIVLOTHIS);
    TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "__F_INV_LOT_ID");
    MTIVLOTHIS.HIST_DEL_FLAG = ' ';
    i_last_active_lot_grp_seq = (int)DBC_select_mtivlothis_scalar(3, &MTIVLOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    TRS.set_int(in_node, "__F_LAST_ACTIVE_HIST_SEQ", i_last_active_lot_grp_seq);

    
    return MP_TRUE;
}

int TIV_Get_INVLOTSTS_Info(char *s_msg_code, struct MTIVLOTSTS_TAG *MTIVLOTSTS, char *in_factory, char *strLotID, TRSNode *out_node, char *s_user_id, char c_not_check_privilege_flag)
{
    DBC_init_mtivlotsts(MTIVLOTSTS);
    memcpy(MTIVLOTSTS->FACTORY, in_factory, sizeof(MTIVLOTSTS->FACTORY));	
    memcpy(MTIVLOTSTS->LOT_ID, strLotID, sizeof(MTIVLOTSTS->LOT_ID));	
    DBC_select_mtivlotsts_for_update(1, MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS) {
        if(DB_error_code == DB_NOT_FOUND) {
            strcpy(s_msg_code, "WIP-0044");
            TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);			

            gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_EXISTENCE;    gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;              
        }
        else {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);			
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_SYSTEM;    gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;              
        }
    }

    if(c_not_check_privilege_flag != 'Y')
    {
        /* Privilege Validation */
        if(COM_check_privilege(s_msg_code, 
                               out_node, 
                               '1',
                               MTIVLOTSTS->FACTORY, 
                               MP_PRV_TYPE_OPER,
                               MTIVLOTSTS->OPER,
                               sizeof(MTIVLOTSTS->OPER),
                               "",
                               0,
                               "",
                               0,
                               s_user_id) == MP_FALSE)
        {
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

int TIV_Get_INVLOTHIS_Info(char *s_msg_code, struct MTIVLOTHIS_TAG *MTIVLOTHIS, char *strLotID, int iHistSeq, TRSNode *out_node)
{
    DBC_init_mtivlothis(MTIVLOTHIS);
    memcpy(MTIVLOTHIS->LOT_ID, strLotID, sizeof(MTIVLOTHIS->LOT_ID));	
    MTIVLOTHIS->HIST_SEQ = iHistSeq;
    DBC_select_mtivlothis_for_update(1, MTIVLOTHIS);
    if(DB_error_code != DB_SUCCESS) {
        if(DB_error_code == DB_NOT_FOUND) {
            strcpy(s_msg_code, "WIP-0111");
            TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);			
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);

            gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_EXISTENCE;    gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;              
        }
        else {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);			
            TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;    gs_log_type.e_type = MP_LOG_E_SYSTEM;    gs_log_type.category = MP_LOG_CATE_TRANS;
            return MP_FALSE;              
        }
    }

    return MP_TRUE;
}

/*******************************************************************************
Fill_TIV_Lot_STSHIS_For_Update()
- Fill Lot Information By Lot ID
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- string sLot
- TRSNode *in_node : In Node from each transaction function
- TRSNode *out_node : Common out node for result message
- struct MTIVLOTSTS_TAG *MTIVLOTSTS : 
*******************************************************************************/
int Fill_TIV_Lot_STSHIS_For_Update(char *sLot, TRSNode *in_node, TRSNode *out_node, struct MTIVLOTSTS_TAG *MTIVLOTSTS, struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{
	char s_msg_code[MP_SIZE_MSG];

	DBC_init_mtivlotsts(MTIVLOTSTS);

	TRS.copy(MTIVLOTSTS->FACTORY, sizeof(MTIVLOTSTS->FACTORY), in_node, IN_FACTORY);
	memcpy(MTIVLOTSTS->LOT_ID, sLot, sizeof(MTIVLOTSTS->LOT_ID));	

	DBC_select_mtivlotsts_for_update(1, MTIVLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			memcpy(s_msg_code, "WIP-0044", strlen("WIP-0044"));
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else
		{
			memcpy(s_msg_code, "WIP-0004", strlen("WIP-0004"));
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}

		TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);		

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	DBC_init_mtivlothis(MTIVLOTHIS);

	memcpy(MTIVLOTHIS->FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
	memcpy(MTIVLOTHIS->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTHIS->LOT_ID));	
	MTIVLOTHIS->HIST_SEQ = MTIVLOTSTS->LAST_HIST_SEQ;

	DBC_select_mtivlothis_for_update(1, MTIVLOTHIS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			memcpy(s_msg_code, "WIP-0044", strlen("WIP-0044"));
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else
		{
			memcpy(s_msg_code, "WIP-0004", strlen("WIP-0004"));
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}

		TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);		

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	return MP_TRUE;
}

/*******************************************************************************
Fill_TIV_Lot_Info()
- Fill Lot Information
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- TRSNode *in_node : In Node from each transaction function
- TRSNode *out_node : Common out node for result message
- struct MTIVLOTSTS_TAG *MTIVLOTSTS : 
*******************************************************************************/
int Fill_TIV_Lot_Info(TRSNode *in_node, TRSNode *out_node, struct MTIVLOTSTS_TAG *MTIVLOTSTS)
{
	char s_msg_code[MP_SIZE_MSG];

	//// Call Fill_Lot_Info
	//if(Fill_Lot_Info(in_node, out_node, &MTIVLOTSTS) == MP_FALSE)
	//{
	//	TRS.copy(s_msg_code, sizeof(s_msg_code), out_node, "MSGCODE");
	//	return MP_FALSE;
	//}

	DBC_init_mtivlotsts(MTIVLOTSTS);

	TRS.copy(MTIVLOTSTS->FACTORY, sizeof(MTIVLOTSTS->FACTORY), in_node, IN_FACTORY);
	TRS.copy(MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID), in_node, "LOT_ID");	

	DBC_select_mtivlotsts(1, MTIVLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			memcpy(s_msg_code, "WIP-0044", strlen("WIP-0044"));
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else
		{
			memcpy(s_msg_code, "WIP-0004", strlen("WIP-0004"));
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}

		TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);		

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	return MP_TRUE;
}

/*******************************************************************************
Fill_TIV_Lot_Info_By_Lot()
- Fill Lot Information By Lot ID
Return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- string sLot
- TRSNode *in_node : In Node from each transaction function
- TRSNode *out_node : Common out node for result message
- struct MTIVLOTSTS_TAG *MTIVLOTSTS : 
*******************************************************************************/
int Fill_TIV_Lot_Info_By_Lot(char *sLot, TRSNode *in_node, TRSNode *out_node, struct MTIVLOTSTS_TAG *MTIVLOTSTS)
{
	char s_msg_code[MP_SIZE_MSG];

	DBC_init_mtivlotsts(MTIVLOTSTS);

	TRS.copy(MTIVLOTSTS->FACTORY, sizeof(MTIVLOTSTS->FACTORY), in_node, IN_FACTORY);
	memcpy(MTIVLOTSTS->LOT_ID, sLot, sizeof(MTIVLOTSTS->LOT_ID));	

	DBC_select_mtivlotsts(1, MTIVLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			memcpy(s_msg_code, "WIP-0044", strlen("WIP-0044"));
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else
		{
			memcpy(s_msg_code, "WIP-0004", strlen("WIP-0004"));
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}

		TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);		

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	return MP_TRUE;
}

int TIV_update_insert_lot_status_history_For_Release_Hold(char *s_msg_code,
                                         TRSNode *in_node,
                                         TRSNode *out_node,
                                         char *s_sys_time_t,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                         struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{
	
    char s_sys_time[14];
    //int i_time_gap;
	
    COM_memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));

    memcpy(MTIVLOTHIS->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTHIS->LOT_ID));
    MTIVLOTHIS->HIST_SEQ = MTIVLOTSTS->LAST_HIST_SEQ;

    memcpy(MTIVLOTHIS->TRAN_TIME, MTIVLOTSTS->LAST_TRAN_TIME, sizeof(MTIVLOTHIS->TRAN_TIME));
    memcpy(MTIVLOTHIS->SYS_TRAN_TIME, s_sys_time, sizeof(MTIVLOTHIS->SYS_TRAN_TIME));
    memcpy(MTIVLOTHIS->TRAN_CODE, MTIVLOTSTS->LAST_TRAN_CODE, sizeof(MTIVLOTHIS->TRAN_CODE));
    memcpy(MTIVLOTHIS->TRAN_TYPE, MTIVLOTSTS->LAST_TRAN_TYPE, sizeof(MTIVLOTHIS->TRAN_TYPE));    
    TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, IN_USERID);

    /****** New INV Lot Status *******/
    memcpy(MTIVLOTHIS->FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTHIS->OPER));
    memcpy(MTIVLOTHIS->MAT_ID, MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTHIS->MAT_ID));
    MTIVLOTHIS->MAT_VER = MTIVLOTSTS->MAT_VER;
    MTIVLOTHIS->LOT_TYPE = MTIVLOTSTS->LOT_TYPE;
    MTIVLOTHIS->QTY_1 = MTIVLOTSTS->QTY_1;
    MTIVLOTHIS->QTY_2 = MTIVLOTSTS->QTY_2;
    MTIVLOTHIS->QTY_3 = MTIVLOTSTS->QTY_3;

    //MTIVLOTHIS->MOVE_QTY_1 = 0;
    //MTIVLOTHIS->MOVE_QTY_2 = 0;
    //MTIVLOTHIS->MOVE_QTY_3 = 0;
    //MTIVLOTHIS->CHANGE_QTY_1 = 0;
    //MTIVLOTHIS->CHANGE_QTY_2 = 0;
    //MTIVLOTHIS->CHANGE_QTY_3 = 0;    

    MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS_OLD->QTY_1;  
    MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS_OLD->QTY_2;
    MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS_OLD->QTY_3; 

    MTIVLOTHIS->CREATE_QTY_1 = MTIVLOTSTS->CREATE_QTY_1;
    MTIVLOTHIS->CREATE_QTY_2 = MTIVLOTSTS->CREATE_QTY_2;
    MTIVLOTHIS->CREATE_QTY_3 = MTIVLOTSTS->CREATE_QTY_3;
    memcpy(MTIVLOTHIS->CREATE_TIME, MTIVLOTSTS->CREATE_TIME, sizeof(MTIVLOTHIS->CREATE_TIME));
	memcpy(MTIVLOTHIS->CREATE_CODE, MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTHIS->CREATE_CODE));
	memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));
    MTIVLOTHIS->IN_OUT_FLAG =  MTIVLOTSTS->IN_OUT_FLAG;

    memcpy(MTIVLOTHIS->ORDER_ID, MTIVLOTSTS->ORDER_ID, sizeof(MTIVLOTHIS->ORDER_ID));

    memcpy(MTIVLOTHIS->LINE_NO, MTIVLOTSTS->LINE_NO, sizeof(MTIVLOTHIS->LINE_NO));
    memcpy(MTIVLOTHIS->UNIT_1, MTIVLOTSTS->UNIT_1, sizeof(MTIVLOTHIS->UNIT_1));
    memcpy(MTIVLOTHIS->UNIT_2, MTIVLOTSTS->UNIT_2, sizeof(MTIVLOTHIS->UNIT_2));
    memcpy(MTIVLOTHIS->UNIT_3, MTIVLOTSTS->UNIT_3, sizeof(MTIVLOTHIS->UNIT_3));

    MTIVLOTHIS->INSPECTION_FLAG = MTIVLOTSTS->INSPECTION_FLAG;
    MTIVLOTHIS->INSPECTION_RESULT = MTIVLOTSTS->INSPECTION_RESULT;

    memcpy(MTIVLOTHIS->TRAN_COMMENT, MTIVLOTSTS->LAST_TRAN_COMMENT, sizeof(MTIVLOTHIS->TRAN_COMMENT));
    TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, IN_USERID);

    MTIVLOTHIS->LOT_DEL_FLAG =  MTIVLOTSTS->LOT_DEL_FLAG;

    memcpy(MTIVLOTHIS->LOT_DEL_USER_ID, MTIVLOTSTS->LOT_DEL_USER_ID, sizeof(MTIVLOTHIS->LOT_DEL_USER_ID));
    memcpy(MTIVLOTHIS->LOT_DEL_REASON, MTIVLOTSTS->LOT_DEL_REASON, sizeof(MTIVLOTHIS->LOT_DEL_REASON));
    memcpy(MTIVLOTHIS->LOT_DEL_TIME, MTIVLOTSTS->LOT_DEL_TIME, sizeof(MTIVLOTHIS->LOT_DEL_TIME));
    memcpy(MTIVLOTHIS->LOCATION_NO, MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTHIS->LOCATION_NO));

    MTIVLOTHIS->HOLD_FLAG = MTIVLOTSTS->HOLD_FLAG;
    memcpy(MTIVLOTHIS->HOLD_CODE, MTIVLOTSTS->HOLD_CODE, sizeof(MTIVLOTHIS->HOLD_CODE));
    memcpy(MTIVLOTHIS->RELEASE_CODE, MTIVLOTSTS->RELEASE_CODE, sizeof(MTIVLOTHIS->RELEASE_CODE));

    MTIVLOTHIS->PICK_FLAG = MTIVLOTSTS->PICK_FLAG;
    MTIVLOTHIS->SHIP_FLAG = MTIVLOTSTS->SHIP_FLAG;


    memcpy(MTIVLOTHIS->ADD_ORDER_ID_1, MTIVLOTSTS->ADD_ORDER_ID_1, sizeof(MTIVLOTHIS->ADD_ORDER_ID_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_1, MTIVLOTSTS->ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_2, MTIVLOTSTS->ADD_ORDER_ID_2, sizeof(MTIVLOTHIS->ADD_ORDER_ID_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_2, MTIVLOTSTS->ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_3, MTIVLOTSTS->ADD_ORDER_ID_3, sizeof(MTIVLOTHIS->ADD_ORDER_ID_3));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_3, MTIVLOTSTS->ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_3));
    
    memcpy(MTIVLOTHIS->PO_MAT_ID, MTIVLOTSTS->PO_MAT_ID, sizeof(MTIVLOTHIS->PO_MAT_ID));
    MTIVLOTHIS->PO_SEQ_NUM = MTIVLOTSTS->PO_SEQ_NUM;

    memcpy(MTIVLOTHIS->INV_CMF_1, MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1));
    memcpy(MTIVLOTHIS->INV_CMF_2, MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2));
    memcpy(MTIVLOTHIS->INV_CMF_3, MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3));
    memcpy(MTIVLOTHIS->INV_CMF_4, MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4));
    memcpy(MTIVLOTHIS->INV_CMF_5, MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5));
    memcpy(MTIVLOTHIS->INV_CMF_6, MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6));
    memcpy(MTIVLOTHIS->INV_CMF_7, MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7));
    memcpy(MTIVLOTHIS->INV_CMF_8, MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8));
    memcpy(MTIVLOTHIS->INV_CMF_9, MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9));
    memcpy(MTIVLOTHIS->INV_CMF_10, MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10));
    memcpy(MTIVLOTHIS->INV_CMF_11, MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11));
    memcpy(MTIVLOTHIS->INV_CMF_12, MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12));
    memcpy(MTIVLOTHIS->INV_CMF_13, MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13));
    memcpy(MTIVLOTHIS->INV_CMF_14, MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14));
    memcpy(MTIVLOTHIS->INV_CMF_15, MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15));
    memcpy(MTIVLOTHIS->INV_CMF_16, MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16));
    memcpy(MTIVLOTHIS->INV_CMF_17, MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17));
    memcpy(MTIVLOTHIS->INV_CMF_18, MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18));
    memcpy(MTIVLOTHIS->INV_CMF_19, MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19));
    memcpy(MTIVLOTHIS->INV_CMF_20, MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20));

    memcpy(MTIVLOTHIS->VENDOR_LOT_ID, MTIVLOTSTS->VENDOR_LOT_ID, sizeof(MTIVLOTHIS->VENDOR_LOT_ID));
    memcpy(MTIVLOTHIS->VENDOR_ID, MTIVLOTSTS->VENDOR_ID, sizeof(MTIVLOTHIS->VENDOR_ID));
    memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));

    memcpy(MTIVLOTHIS->FROM_TO_LOT_ID, MTIVLOTSTS->FROM_TO_LOT_ID, sizeof(MTIVLOTHIS->FROM_TO_LOT_ID));
	MTIVLOTHIS->FROM_TO_HIST_SEQ = MTIVLOTSTS->FROM_TO_HIST_SEQ;
    MTIVLOTHIS->FROM_TO_FLAG = MTIVLOTSTS->FROM_TO_FLAG;

	memcpy(MTIVLOTHIS->INV_CMF_21, MTIVLOTSTS->INV_CMF_21, sizeof(MTIVLOTHIS->INV_CMF_21));
	memcpy(MTIVLOTHIS->INV_CMF_22, MTIVLOTSTS->INV_CMF_22, sizeof(MTIVLOTHIS->INV_CMF_22));
	memcpy(MTIVLOTHIS->INV_CMF_23, MTIVLOTSTS->INV_CMF_23, sizeof(MTIVLOTHIS->INV_CMF_23));
	memcpy(MTIVLOTHIS->INV_CMF_24, MTIVLOTSTS->INV_CMF_24, sizeof(MTIVLOTHIS->INV_CMF_24));
	memcpy(MTIVLOTHIS->INV_CMF_25, MTIVLOTSTS->INV_CMF_25, sizeof(MTIVLOTHIS->INV_CMF_25));
	memcpy(MTIVLOTHIS->INV_CMF_26, MTIVLOTSTS->INV_CMF_26, sizeof(MTIVLOTHIS->INV_CMF_26));
	memcpy(MTIVLOTHIS->INV_CMF_27, MTIVLOTSTS->INV_CMF_27, sizeof(MTIVLOTHIS->INV_CMF_27));
	memcpy(MTIVLOTHIS->INV_CMF_28, MTIVLOTSTS->INV_CMF_28, sizeof(MTIVLOTHIS->INV_CMF_28));
	memcpy(MTIVLOTHIS->INV_CMF_29, MTIVLOTSTS->INV_CMF_29, sizeof(MTIVLOTHIS->INV_CMF_29));
	memcpy(MTIVLOTHIS->INV_CMF_30, MTIVLOTSTS->INV_CMF_30, sizeof(MTIVLOTHIS->INV_CMF_30));
	 
	MTIVLOTHIS->INV_FLAG_1 = MTIVLOTSTS->INV_FLAG_1;
	MTIVLOTHIS->INV_FLAG_2 = MTIVLOTSTS->INV_FLAG_2;
	MTIVLOTHIS->INV_FLAG_3 = MTIVLOTSTS->INV_FLAG_3;
	MTIVLOTHIS->INV_FLAG_4 = MTIVLOTSTS->INV_FLAG_4;
	MTIVLOTHIS->INV_FLAG_5 = MTIVLOTSTS->INV_FLAG_5;

	memcpy(MTIVLOTHIS->ERP_CREATE_DATE, MTIVLOTSTS->ERP_CREATE_DATE, sizeof(MTIVLOTHIS->ERP_CREATE_DATE));
	memcpy(MTIVLOTHIS->ERP_INV_IN_DATE, MTIVLOTSTS->ERP_INV_IN_DATE, sizeof(MTIVLOTHIS->ERP_INV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_OINV_IN_DATE, MTIVLOTSTS->ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS->ERP_OINV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_TRAN_DATE, MTIVLOTSTS->ERP_LAST_TRAN_DATE, sizeof(MTIVLOTHIS->ERP_TRAN_DATE));


    memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS_OLD->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS_OLD->OPER, sizeof(MTIVLOTHIS->OLD_OPER));

    memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS_OLD->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
	
	//추가된 것 - 만료일
	memcpy(MTIVLOTHIS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTHIS->EXPIRE_DATE));

	memcpy(MTIVLOTSTS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTSTS_OLD->EXPIRE_DATE));


	TRS.copy(MTIVLOTHIS->TRAN_CMF_7, sizeof(MTIVLOTHIS->TRAN_CMF_7), in_node, "WORK_DATE");
	TRS.copy(MTIVLOTHIS->TRAN_CMF_8, sizeof(MTIVLOTHIS->TRAN_CMF_8), in_node, "SHIFT");

	////LOT이 없을 경우 새롭게 LOT을 만들어서 HISTORY를 쌓는다. 
 //   /* Update/Insert Lot Status */
 //   if(MTIVLOTSTS->LAST_HIST_SEQ > 1)
 //   {
	 DBC_update_mtivlotsts(3,MTIVLOTSTS);
 //   }
 //   else
 //   {
 //       DBC_insert_mtivlotsts(MTIVLOTSTS);
 //   }
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "EXPIRE_DATE", MP_STR, sizeof(MTIVLOTSTS->EXPIRE_DATE), MTIVLOTSTS->EXPIRE_DATE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Insert Lot History */
    DBC_insert_mtivlothis(MTIVLOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    TIV_fill_detail_message(out_node, MTIVLOTSTS, MTIVLOTSTS_OLD);

    return MP_TRUE;
}


int TIV_update_insert_lot_status_history_for_in_lot(char *s_msg_code,
                                         TRSNode *in_node,
                                         TRSNode *out_node,
                                         char *s_sys_time_t,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                         struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{
	struct MTIVLOTSTS_TAG *MTIVLOTSTS_COMP;
	//struct MTIVLOTCRT_TAG MTIVLOTCRT;
	
    char s_sys_time[14];
    //int i_time_gap;
	
    COM_memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));

    memcpy(MTIVLOTHIS->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTHIS->LOT_ID));
    MTIVLOTHIS->HIST_SEQ = MTIVLOTSTS->LAST_HIST_SEQ;

    memcpy(MTIVLOTHIS->TRAN_TIME, MTIVLOTSTS->LAST_TRAN_TIME, sizeof(MTIVLOTHIS->TRAN_TIME));
    memcpy(MTIVLOTHIS->SYS_TRAN_TIME, s_sys_time, sizeof(MTIVLOTHIS->SYS_TRAN_TIME));
    memcpy(MTIVLOTHIS->TRAN_CODE, MTIVLOTSTS->LAST_TRAN_CODE, sizeof(MTIVLOTHIS->TRAN_CODE));
    memcpy(MTIVLOTHIS->TRAN_TYPE, MTIVLOTSTS->LAST_TRAN_TYPE, sizeof(MTIVLOTHIS->TRAN_TYPE));    
    TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, "PRC_USER");

    /****** New INV Lot Status *******/
    memcpy(MTIVLOTHIS->FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTHIS->OPER));
    memcpy(MTIVLOTHIS->MAT_ID, MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTHIS->MAT_ID));
    MTIVLOTHIS->MAT_VER = MTIVLOTSTS->MAT_VER;
    MTIVLOTHIS->LOT_TYPE = MTIVLOTSTS->LOT_TYPE;
    MTIVLOTHIS->QTY_1 = MTIVLOTSTS->QTY_1;
    MTIVLOTHIS->QTY_2 = MTIVLOTSTS->QTY_2;
    MTIVLOTHIS->QTY_3 = MTIVLOTSTS->QTY_3;

	memcpy(MTIVLOTHIS->CREATE_CODE, MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTHIS->CREATE_CODE));
	memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));

    //MTIVLOTHIS->MOVE_QTY_1 = 0;
    //MTIVLOTHIS->MOVE_QTY_2 = 0;
    //MTIVLOTHIS->MOVE_QTY_3 = 0;
    //MTIVLOTHIS->CHANGE_QTY_1 = 0;
    //MTIVLOTHIS->CHANGE_QTY_2 = 0;
    //MTIVLOTHIS->CHANGE_QTY_3 = 0;    

    MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS_OLD->QTY_1;  
    MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS_OLD->QTY_2;
    MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS_OLD->QTY_3; 

    MTIVLOTHIS->CREATE_QTY_1 = MTIVLOTSTS->CREATE_QTY_1;
    MTIVLOTHIS->CREATE_QTY_2 = MTIVLOTSTS->CREATE_QTY_2;
    MTIVLOTHIS->CREATE_QTY_3 = MTIVLOTSTS->CREATE_QTY_3;
    memcpy(MTIVLOTHIS->CREATE_TIME, MTIVLOTSTS->CREATE_TIME, sizeof(MTIVLOTHIS->CREATE_TIME));
	memcpy(MTIVLOTHIS->CREATE_CODE, MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTHIS->CREATE_CODE));
	memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));
    MTIVLOTHIS->IN_OUT_FLAG =  MTIVLOTSTS->IN_OUT_FLAG;

    memcpy(MTIVLOTHIS->ORDER_ID, MTIVLOTSTS->ORDER_ID, sizeof(MTIVLOTHIS->ORDER_ID));

    memcpy(MTIVLOTHIS->LINE_NO, MTIVLOTSTS->LINE_NO, sizeof(MTIVLOTHIS->LINE_NO));
    memcpy(MTIVLOTHIS->UNIT_1, MTIVLOTSTS->UNIT_1, sizeof(MTIVLOTHIS->UNIT_1));
    memcpy(MTIVLOTHIS->UNIT_2, MTIVLOTSTS->UNIT_2, sizeof(MTIVLOTHIS->UNIT_2));
    memcpy(MTIVLOTHIS->UNIT_3, MTIVLOTSTS->UNIT_3, sizeof(MTIVLOTHIS->UNIT_3));

    MTIVLOTHIS->INSPECTION_FLAG = MTIVLOTSTS->INSPECTION_FLAG;
    MTIVLOTHIS->INSPECTION_RESULT = MTIVLOTSTS->INSPECTION_RESULT;

    memcpy(MTIVLOTHIS->TRAN_COMMENT, MTIVLOTSTS->LAST_TRAN_COMMENT, sizeof(MTIVLOTHIS->TRAN_COMMENT));
     
    MTIVLOTHIS->LOT_DEL_FLAG =  MTIVLOTSTS->LOT_DEL_FLAG;

    memcpy(MTIVLOTHIS->LOT_DEL_USER_ID, MTIVLOTSTS->LOT_DEL_USER_ID, sizeof(MTIVLOTHIS->LOT_DEL_USER_ID));
    memcpy(MTIVLOTHIS->LOT_DEL_REASON, MTIVLOTSTS->LOT_DEL_REASON, sizeof(MTIVLOTHIS->LOT_DEL_REASON));
    memcpy(MTIVLOTHIS->LOT_DEL_TIME, MTIVLOTSTS->LOT_DEL_TIME, sizeof(MTIVLOTHIS->LOT_DEL_TIME));
    memcpy(MTIVLOTHIS->LOCATION_NO, MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTHIS->LOCATION_NO));

    MTIVLOTHIS->HOLD_FLAG = MTIVLOTSTS->HOLD_FLAG;
    memcpy(MTIVLOTHIS->HOLD_CODE, MTIVLOTSTS->HOLD_CODE, sizeof(MTIVLOTHIS->HOLD_CODE));
    memcpy(MTIVLOTHIS->RELEASE_CODE, MTIVLOTSTS->RELEASE_CODE, sizeof(MTIVLOTHIS->RELEASE_CODE));

    MTIVLOTHIS->PICK_FLAG = MTIVLOTSTS->PICK_FLAG;
    MTIVLOTHIS->SHIP_FLAG = MTIVLOTSTS->SHIP_FLAG;


    memcpy(MTIVLOTHIS->ADD_ORDER_ID_1, MTIVLOTSTS->ADD_ORDER_ID_1, sizeof(MTIVLOTHIS->ADD_ORDER_ID_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_1, MTIVLOTSTS->ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_2, MTIVLOTSTS->ADD_ORDER_ID_2, sizeof(MTIVLOTHIS->ADD_ORDER_ID_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_2, MTIVLOTSTS->ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_3, MTIVLOTSTS->ADD_ORDER_ID_3, sizeof(MTIVLOTHIS->ADD_ORDER_ID_3));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_3, MTIVLOTSTS->ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_3));
    
    memcpy(MTIVLOTHIS->PO_MAT_ID, MTIVLOTSTS->PO_MAT_ID, sizeof(MTIVLOTHIS->PO_MAT_ID));
    MTIVLOTHIS->PO_SEQ_NUM = MTIVLOTSTS->PO_SEQ_NUM;

    memcpy(MTIVLOTHIS->INV_CMF_1, MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1));
    memcpy(MTIVLOTHIS->INV_CMF_2, MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2));
    memcpy(MTIVLOTHIS->INV_CMF_3, MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3));
    memcpy(MTIVLOTHIS->INV_CMF_4, MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4));
    memcpy(MTIVLOTHIS->INV_CMF_5, MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5));
    memcpy(MTIVLOTHIS->INV_CMF_6, MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6));
    memcpy(MTIVLOTHIS->INV_CMF_7, MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7));
    memcpy(MTIVLOTHIS->INV_CMF_8, MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8));
    memcpy(MTIVLOTHIS->INV_CMF_9, MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9));
    memcpy(MTIVLOTHIS->INV_CMF_10, MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10));
    memcpy(MTIVLOTHIS->INV_CMF_11, MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11));
    memcpy(MTIVLOTHIS->INV_CMF_12, MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12));
    memcpy(MTIVLOTHIS->INV_CMF_13, MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13));
    memcpy(MTIVLOTHIS->INV_CMF_14, MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14));
    memcpy(MTIVLOTHIS->INV_CMF_15, MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15));
    memcpy(MTIVLOTHIS->INV_CMF_16, MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16));
    memcpy(MTIVLOTHIS->INV_CMF_17, MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17));
    memcpy(MTIVLOTHIS->INV_CMF_18, MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18));
    memcpy(MTIVLOTHIS->INV_CMF_19, MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19));
    memcpy(MTIVLOTHIS->INV_CMF_20, MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20));
	 
    memcpy(MTIVLOTHIS->VENDOR_LOT_ID, MTIVLOTSTS->VENDOR_LOT_ID, sizeof(MTIVLOTHIS->VENDOR_LOT_ID));
    memcpy(MTIVLOTHIS->VENDOR_ID, MTIVLOTSTS->VENDOR_ID, sizeof(MTIVLOTHIS->VENDOR_ID));
    memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));

    memcpy(MTIVLOTHIS->FROM_TO_LOT_ID, MTIVLOTSTS->FROM_TO_LOT_ID, sizeof(MTIVLOTHIS->FROM_TO_LOT_ID)); 
	MTIVLOTHIS->FROM_TO_HIST_SEQ = MTIVLOTSTS->FROM_TO_HIST_SEQ;
    MTIVLOTHIS->FROM_TO_FLAG = MTIVLOTSTS->FROM_TO_FLAG;

    memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS_OLD->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS_OLD->OPER, sizeof(MTIVLOTHIS->OLD_OPER));

    memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS_OLD->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
	
	//추가된 것 - 만료일
	memcpy(MTIVLOTHIS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTHIS->EXPIRE_DATE));
	
    if(TRS.get_char(in_node, "IQC_CHECK")=='N')
    {
        memcpy(MTIVLOTHIS->TRAN_CMF_1, "Y", strlen("Y"));
    }

	//LOT이 없을 경우 새롭게 LOT을 만들어서 HISTORY를 쌓는다. 
    /* Update/Insert Lot Status */

	memcpy(MTIVLOTSTS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTSTS_OLD->EXPIRE_DATE));

	memcpy(MTIVLOTHIS->INV_CMF_21, MTIVLOTSTS->INV_CMF_21, sizeof(MTIVLOTHIS->INV_CMF_21));
	memcpy(MTIVLOTHIS->INV_CMF_22, MTIVLOTSTS->INV_CMF_22, sizeof(MTIVLOTHIS->INV_CMF_22));
	memcpy(MTIVLOTHIS->INV_CMF_23, MTIVLOTSTS->INV_CMF_23, sizeof(MTIVLOTHIS->INV_CMF_23));
	memcpy(MTIVLOTHIS->INV_CMF_24, MTIVLOTSTS->INV_CMF_24, sizeof(MTIVLOTHIS->INV_CMF_24));
	memcpy(MTIVLOTHIS->INV_CMF_25, MTIVLOTSTS->INV_CMF_25, sizeof(MTIVLOTHIS->INV_CMF_25));
	memcpy(MTIVLOTHIS->INV_CMF_26, MTIVLOTSTS->INV_CMF_26, sizeof(MTIVLOTHIS->INV_CMF_26));
	memcpy(MTIVLOTHIS->INV_CMF_27, MTIVLOTSTS->INV_CMF_27, sizeof(MTIVLOTHIS->INV_CMF_27));
	memcpy(MTIVLOTHIS->INV_CMF_28, MTIVLOTSTS->INV_CMF_28, sizeof(MTIVLOTHIS->INV_CMF_28));
	memcpy(MTIVLOTHIS->INV_CMF_29, MTIVLOTSTS->INV_CMF_29, sizeof(MTIVLOTHIS->INV_CMF_29));
	memcpy(MTIVLOTHIS->INV_CMF_30, MTIVLOTSTS->INV_CMF_30, sizeof(MTIVLOTHIS->INV_CMF_30));
	 
	MTIVLOTHIS->INV_FLAG_1 = MTIVLOTSTS->INV_FLAG_1;
	MTIVLOTHIS->INV_FLAG_2 = MTIVLOTSTS->INV_FLAG_2;
	MTIVLOTHIS->INV_FLAG_3 = MTIVLOTSTS->INV_FLAG_3;
	MTIVLOTHIS->INV_FLAG_4 = MTIVLOTSTS->INV_FLAG_4;
	MTIVLOTHIS->INV_FLAG_5 = MTIVLOTSTS->INV_FLAG_5;

	memcpy(MTIVLOTHIS->INV_IN_TIME, MTIVLOTSTS->INV_IN_TIME, sizeof(MTIVLOTSTS->INV_IN_TIME));
	memcpy(MTIVLOTHIS->INV_OUT_TIME, MTIVLOTSTS->INV_OUT_TIME, sizeof(MTIVLOTSTS->INV_OUT_TIME));

	memcpy(MTIVLOTHIS->ERP_CREATE_DATE, MTIVLOTSTS->ERP_CREATE_DATE, sizeof(MTIVLOTHIS->ERP_CREATE_DATE));
	memcpy(MTIVLOTHIS->ERP_INV_IN_DATE, MTIVLOTSTS->ERP_INV_IN_DATE, sizeof(MTIVLOTHIS->ERP_INV_IN_DATE));	
	memcpy(MTIVLOTHIS->ERP_OINV_IN_DATE, MTIVLOTSTS->ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS->ERP_OINV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_TRAN_DATE, MTIVLOTSTS->ERP_LAST_TRAN_DATE, sizeof(MTIVLOTHIS->ERP_TRAN_DATE));

    if(MTIVLOTSTS->LAST_HIST_SEQ > 1)
    {
		memcpy(&MTIVLOTSTS_COMP, &MTIVLOTSTS_OLD, sizeof(MTIVLOTSTS_COMP));
		DBC_init_mtivlotsts(MTIVLOTSTS_COMP);
		memcpy(MTIVLOTSTS_COMP->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID));
		memcpy(MTIVLOTSTS_COMP->OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTSTS->OPER));
		if((int)DBC_select_mtivlotsts_scalar(9, MTIVLOTSTS_COMP)!=0)
		{
			DBC_update_mtivlotsts(1,MTIVLOTSTS);
		}
		else
		{
			DBC_insert_mtivlotsts(MTIVLOTSTS);
		}
    }
    else
    {
        DBC_insert_mtivlotsts(MTIVLOTSTS);
    }
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "EXPIRE_DATE", MP_STR, sizeof(MTIVLOTSTS->EXPIRE_DATE), MTIVLOTSTS->EXPIRE_DATE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Insert Lot History */
    DBC_insert_mtivlothis(MTIVLOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

	//if( TRS.get_char(in_node, "CREATE_FLAG") == 'Y')
	//{
	//	DBC_init_mtivlotcrt(&MTIVLOTCRT);
	//	memcpy(&MTIVLOTCRT, &MTIVLOTHIS, sizeof(MTIVLOTHIS));

	//	DBC_insert_mtivlotcrt(&MTIVLOTCRT);
	//	if(DB_error_code != DB_SUCCESS)
	//	{
	//		//No Error
	//	}
	//}

    TIV_fill_detail_message(out_node, MTIVLOTSTS, MTIVLOTSTS_OLD);

    return MP_TRUE;
}


int TIV_update_insert_lot_status_history_for_adapt(char *s_msg_code,
                                         TRSNode *in_node,
                                         TRSNode *out_node,
                                         char *s_sys_time_t,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                         struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                         struct MTIVLOTHIS_TAG *MTIVLOTHIS)
{
	//struct MTIVLOTHIS_TAG MTIVLOTHIS_GET_HIST_SEQ;
	//struct MTIVLOTSTS_TAG *MTIVLOTSTS_COMP;
	
    char s_sys_time[14];
    //int i_time_gap;
	
    COM_memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));

	/*DBC_init_mtivlothis(&MTIVLOTHIS_GET_HIST_SEQ);
	TRS.copy(MTIVLOTHIS_GET_HIST_SEQ.FACTORY, sizeof(MTIVLOTHIS_GET_HIST_SEQ.FACTORY), in_node, IN_FACTORY);
    memcpy(MTIVLOTHIS_GET_HIST_SEQ.LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID));
    DBC_select_mtivlothis(4, &MTIVLOTHIS_GET_HIST_SEQ);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
			MTIVLOTHIS_GET_HIST_SEQ.HIST_SEQ = 0;                    
        }
        else if(DB_error_code != DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);

            TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS_GET_HIST_SEQ.FACTORY), MTIVLOTHIS_GET_HIST_SEQ.FACTORY);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS_GET_HIST_SEQ.LOT_ID), MTIVLOTHIS_GET_HIST_SEQ.LOT_ID);
        }
                

        return MP_FALSE;
    }*/

    memcpy(MTIVLOTHIS->LOT_ID, MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTHIS->LOT_ID));
    //MTIVLOTHIS->HIST_SEQ = MTIVLOTHIS_GET_HIST_SEQ.HIST_SEQ + 1;
	MTIVLOTHIS->HIST_SEQ = MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ;

    memcpy(MTIVLOTHIS->TRAN_TIME, MTIVLOTSTS->LAST_TRAN_TIME, sizeof(MTIVLOTHIS->TRAN_TIME));
    memcpy(MTIVLOTHIS->SYS_TRAN_TIME, s_sys_time, sizeof(MTIVLOTHIS->SYS_TRAN_TIME));
    memcpy(MTIVLOTHIS->TRAN_CODE, MTIVLOTSTS->LAST_TRAN_CODE, sizeof(MTIVLOTHIS->TRAN_CODE));
    memcpy(MTIVLOTHIS->TRAN_TYPE, MTIVLOTSTS->LAST_TRAN_TYPE, sizeof(MTIVLOTHIS->TRAN_TYPE));    
    TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, IN_USERID);

    /****** New INV Lot Status *******/
    memcpy(MTIVLOTHIS->FACTORY, MTIVLOTSTS->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OPER, MTIVLOTSTS->OPER, sizeof(MTIVLOTHIS->OPER));
    memcpy(MTIVLOTHIS->MAT_ID, MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTHIS->MAT_ID));
    MTIVLOTHIS->MAT_VER = MTIVLOTSTS->MAT_VER;
    MTIVLOTHIS->LOT_TYPE = MTIVLOTSTS->LOT_TYPE;
    MTIVLOTHIS->QTY_1 = MTIVLOTSTS->QTY_1;
    MTIVLOTHIS->QTY_2 = MTIVLOTSTS->QTY_2;
    MTIVLOTHIS->QTY_3 = MTIVLOTSTS->QTY_3;

    //MTIVLOTHIS->MOVE_QTY_1 = 0;
    //MTIVLOTHIS->MOVE_QTY_2 = 0;
    //MTIVLOTHIS->MOVE_QTY_3 = 0;
    //MTIVLOTHIS->CHANGE_QTY_1 = 0;
    //MTIVLOTHIS->CHANGE_QTY_2 = 0;
    //MTIVLOTHIS->CHANGE_QTY_3 = 0;    

    MTIVLOTHIS->OLD_QTY_1 = MTIVLOTSTS_OLD->QTY_1;  
    MTIVLOTHIS->OLD_QTY_2 = MTIVLOTSTS_OLD->QTY_2;
    MTIVLOTHIS->OLD_QTY_3 = MTIVLOTSTS_OLD->QTY_3; 

    MTIVLOTHIS->CREATE_QTY_1 = MTIVLOTSTS->CREATE_QTY_1;
    MTIVLOTHIS->CREATE_QTY_2 = MTIVLOTSTS->CREATE_QTY_2;
    MTIVLOTHIS->CREATE_QTY_3 = MTIVLOTSTS->CREATE_QTY_3;
    memcpy(MTIVLOTHIS->CREATE_TIME, MTIVLOTSTS->CREATE_TIME, sizeof(MTIVLOTHIS->CREATE_TIME));
	memcpy(MTIVLOTHIS->CREATE_CODE, MTIVLOTSTS->CREATE_CODE, sizeof(MTIVLOTHIS->CREATE_CODE));
	memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));
    MTIVLOTHIS->IN_OUT_FLAG =  MTIVLOTSTS->IN_OUT_FLAG;

    memcpy(MTIVLOTHIS->ORDER_ID, MTIVLOTSTS->ORDER_ID, sizeof(MTIVLOTHIS->ORDER_ID));

    memcpy(MTIVLOTHIS->LINE_NO, MTIVLOTSTS->LINE_NO, sizeof(MTIVLOTHIS->LINE_NO));
    memcpy(MTIVLOTHIS->UNIT_1, MTIVLOTSTS->UNIT_1, sizeof(MTIVLOTHIS->UNIT_1));
    memcpy(MTIVLOTHIS->UNIT_2, MTIVLOTSTS->UNIT_2, sizeof(MTIVLOTHIS->UNIT_2));
    memcpy(MTIVLOTHIS->UNIT_3, MTIVLOTSTS->UNIT_3, sizeof(MTIVLOTHIS->UNIT_3));

    MTIVLOTHIS->INSPECTION_FLAG = MTIVLOTSTS->INSPECTION_FLAG;
    MTIVLOTHIS->INSPECTION_RESULT = MTIVLOTSTS->INSPECTION_RESULT;

    memcpy(MTIVLOTHIS->TRAN_COMMENT, MTIVLOTSTS->LAST_TRAN_COMMENT, sizeof(MTIVLOTHIS->TRAN_COMMENT));
    TRS.copy(MTIVLOTHIS->TRAN_USER_ID, sizeof(MTIVLOTHIS->TRAN_USER_ID), in_node, IN_USERID);

    MTIVLOTHIS->LOT_DEL_FLAG =  MTIVLOTSTS->LOT_DEL_FLAG;

    memcpy(MTIVLOTHIS->LOT_DEL_USER_ID, MTIVLOTSTS->LOT_DEL_USER_ID, sizeof(MTIVLOTHIS->LOT_DEL_USER_ID));
    memcpy(MTIVLOTHIS->LOT_DEL_REASON, MTIVLOTSTS->LOT_DEL_REASON, sizeof(MTIVLOTHIS->LOT_DEL_REASON));
    memcpy(MTIVLOTHIS->LOT_DEL_TIME, MTIVLOTSTS->LOT_DEL_TIME, sizeof(MTIVLOTHIS->LOT_DEL_TIME));
    memcpy(MTIVLOTHIS->LOCATION_NO, MTIVLOTSTS->LOCATION_NO, sizeof(MTIVLOTHIS->LOCATION_NO));

    MTIVLOTHIS->HOLD_FLAG = MTIVLOTSTS->HOLD_FLAG;
    memcpy(MTIVLOTHIS->HOLD_CODE, MTIVLOTSTS->HOLD_CODE, sizeof(MTIVLOTHIS->HOLD_CODE));
    memcpy(MTIVLOTHIS->RELEASE_CODE, MTIVLOTSTS->RELEASE_CODE, sizeof(MTIVLOTHIS->RELEASE_CODE));

    MTIVLOTHIS->PICK_FLAG = MTIVLOTSTS->PICK_FLAG;
    MTIVLOTHIS->SHIP_FLAG = MTIVLOTSTS->SHIP_FLAG;

    memcpy(MTIVLOTHIS->ADD_ORDER_ID_1, MTIVLOTSTS->ADD_ORDER_ID_1, sizeof(MTIVLOTHIS->ADD_ORDER_ID_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_1, MTIVLOTSTS->ADD_ORDER_LINE_1, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_1));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_2, MTIVLOTSTS->ADD_ORDER_ID_2, sizeof(MTIVLOTHIS->ADD_ORDER_ID_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_2, MTIVLOTSTS->ADD_ORDER_LINE_2, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_2));
    memcpy(MTIVLOTHIS->ADD_ORDER_ID_3, MTIVLOTSTS->ADD_ORDER_ID_3, sizeof(MTIVLOTHIS->ADD_ORDER_ID_3));
    memcpy(MTIVLOTHIS->ADD_ORDER_LINE_3, MTIVLOTSTS->ADD_ORDER_LINE_3, sizeof(MTIVLOTHIS->ADD_ORDER_LINE_3));
    
    memcpy(MTIVLOTHIS->PO_MAT_ID, MTIVLOTSTS->PO_MAT_ID, sizeof(MTIVLOTHIS->PO_MAT_ID));
    MTIVLOTHIS->PO_SEQ_NUM = MTIVLOTSTS->PO_SEQ_NUM;

    memcpy(MTIVLOTHIS->INV_CMF_1, MTIVLOTSTS->INV_CMF_1, sizeof(MTIVLOTSTS->INV_CMF_1));
    memcpy(MTIVLOTHIS->INV_CMF_2, MTIVLOTSTS->INV_CMF_2, sizeof(MTIVLOTSTS->INV_CMF_2));
    memcpy(MTIVLOTHIS->INV_CMF_3, MTIVLOTSTS->INV_CMF_3, sizeof(MTIVLOTSTS->INV_CMF_3));
    memcpy(MTIVLOTHIS->INV_CMF_4, MTIVLOTSTS->INV_CMF_4, sizeof(MTIVLOTSTS->INV_CMF_4));
    memcpy(MTIVLOTHIS->INV_CMF_5, MTIVLOTSTS->INV_CMF_5, sizeof(MTIVLOTSTS->INV_CMF_5));
    memcpy(MTIVLOTHIS->INV_CMF_6, MTIVLOTSTS->INV_CMF_6, sizeof(MTIVLOTSTS->INV_CMF_6));
    memcpy(MTIVLOTHIS->INV_CMF_7, MTIVLOTSTS->INV_CMF_7, sizeof(MTIVLOTSTS->INV_CMF_7));
    memcpy(MTIVLOTHIS->INV_CMF_8, MTIVLOTSTS->INV_CMF_8, sizeof(MTIVLOTSTS->INV_CMF_8));
    memcpy(MTIVLOTHIS->INV_CMF_9, MTIVLOTSTS->INV_CMF_9, sizeof(MTIVLOTSTS->INV_CMF_9));
    memcpy(MTIVLOTHIS->INV_CMF_10, MTIVLOTSTS->INV_CMF_10, sizeof(MTIVLOTSTS->INV_CMF_10));
    memcpy(MTIVLOTHIS->INV_CMF_11, MTIVLOTSTS->INV_CMF_11, sizeof(MTIVLOTSTS->INV_CMF_11));
    memcpy(MTIVLOTHIS->INV_CMF_12, MTIVLOTSTS->INV_CMF_12, sizeof(MTIVLOTSTS->INV_CMF_12));
    memcpy(MTIVLOTHIS->INV_CMF_13, MTIVLOTSTS->INV_CMF_13, sizeof(MTIVLOTSTS->INV_CMF_13));
    memcpy(MTIVLOTHIS->INV_CMF_14, MTIVLOTSTS->INV_CMF_14, sizeof(MTIVLOTSTS->INV_CMF_14));
    memcpy(MTIVLOTHIS->INV_CMF_15, MTIVLOTSTS->INV_CMF_15, sizeof(MTIVLOTSTS->INV_CMF_15));
    memcpy(MTIVLOTHIS->INV_CMF_16, MTIVLOTSTS->INV_CMF_16, sizeof(MTIVLOTSTS->INV_CMF_16));
    memcpy(MTIVLOTHIS->INV_CMF_17, MTIVLOTSTS->INV_CMF_17, sizeof(MTIVLOTSTS->INV_CMF_17));
    memcpy(MTIVLOTHIS->INV_CMF_18, MTIVLOTSTS->INV_CMF_18, sizeof(MTIVLOTSTS->INV_CMF_18));
    memcpy(MTIVLOTHIS->INV_CMF_19, MTIVLOTSTS->INV_CMF_19, sizeof(MTIVLOTSTS->INV_CMF_19));
    memcpy(MTIVLOTHIS->INV_CMF_20, MTIVLOTSTS->INV_CMF_20, sizeof(MTIVLOTSTS->INV_CMF_20));

	memcpy(MTIVLOTHIS->INV_IN_TIME, MTIVLOTSTS->INV_IN_TIME, sizeof(MTIVLOTSTS->INV_IN_TIME));
	memcpy(MTIVLOTHIS->INV_OUT_TIME, MTIVLOTSTS->INV_OUT_TIME, sizeof(MTIVLOTSTS->INV_OUT_TIME));
	memcpy(MTIVLOTHIS->OINV_IN_TIME, MTIVLOTSTS->OINV_IN_TIME, sizeof(MTIVLOTSTS->OINV_IN_TIME));
	memcpy(MTIVLOTHIS->OINV_OUT_TIME, MTIVLOTSTS->OINV_OUT_TIME, sizeof(MTIVLOTSTS->OINV_OUT_TIME));
	memcpy(MTIVLOTHIS->WIP_IN_TIME, MTIVLOTSTS->WIP_IN_TIME, sizeof(MTIVLOTSTS->WIP_IN_TIME));
	memcpy(MTIVLOTHIS->WIP_OUT_TIME, MTIVLOTSTS->WIP_OUT_TIME, sizeof(MTIVLOTSTS->WIP_OUT_TIME));

    memcpy(MTIVLOTHIS->VENDOR_LOT_ID, MTIVLOTSTS->VENDOR_LOT_ID, sizeof(MTIVLOTHIS->VENDOR_LOT_ID));
    memcpy(MTIVLOTHIS->VENDOR_ID, MTIVLOTSTS->VENDOR_ID, sizeof(MTIVLOTHIS->VENDOR_ID));
    memcpy(MTIVLOTHIS->OWNER_CODE, MTIVLOTSTS->OWNER_CODE, sizeof(MTIVLOTHIS->OWNER_CODE));

    memcpy(MTIVLOTHIS->FROM_TO_LOT_ID, MTIVLOTSTS->FROM_TO_LOT_ID, sizeof(MTIVLOTHIS->FROM_TO_LOT_ID));
	MTIVLOTHIS->FROM_TO_HIST_SEQ = MTIVLOTSTS->FROM_TO_HIST_SEQ;
    MTIVLOTHIS->FROM_TO_FLAG = MTIVLOTSTS->FROM_TO_FLAG;

    memcpy(MTIVLOTHIS->OLD_FACTORY, MTIVLOTSTS_OLD->FACTORY, sizeof(MTIVLOTHIS->FACTORY));
    memcpy(MTIVLOTHIS->OLD_OPER, MTIVLOTSTS_OLD->OPER, sizeof(MTIVLOTHIS->OLD_OPER));

    memcpy(MTIVLOTHIS->LOT_GROUP_ID, MTIVLOTSTS_OLD->LOT_GROUP_ID, sizeof(MTIVLOTHIS->LOT_GROUP_ID));
	
	//추가된 것 - 만료일
	memcpy(MTIVLOTHIS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTHIS->EXPIRE_DATE));
	
	memcpy(MTIVLOTHIS->INV_CMF_21, MTIVLOTSTS->INV_CMF_21, sizeof(MTIVLOTHIS->INV_CMF_21));
	memcpy(MTIVLOTHIS->INV_CMF_22, MTIVLOTSTS->INV_CMF_22, sizeof(MTIVLOTHIS->INV_CMF_22));
	memcpy(MTIVLOTHIS->INV_CMF_23, MTIVLOTSTS->INV_CMF_23, sizeof(MTIVLOTHIS->INV_CMF_23));
	memcpy(MTIVLOTHIS->INV_CMF_24, MTIVLOTSTS->INV_CMF_24, sizeof(MTIVLOTHIS->INV_CMF_24));
	memcpy(MTIVLOTHIS->INV_CMF_25, MTIVLOTSTS->INV_CMF_25, sizeof(MTIVLOTHIS->INV_CMF_25));
	memcpy(MTIVLOTHIS->INV_CMF_26, MTIVLOTSTS->INV_CMF_26, sizeof(MTIVLOTHIS->INV_CMF_26));
	memcpy(MTIVLOTHIS->INV_CMF_27, MTIVLOTSTS->INV_CMF_27, sizeof(MTIVLOTHIS->INV_CMF_27));
	memcpy(MTIVLOTHIS->INV_CMF_28, MTIVLOTSTS->INV_CMF_28, sizeof(MTIVLOTHIS->INV_CMF_28));
	memcpy(MTIVLOTHIS->INV_CMF_29, MTIVLOTSTS->INV_CMF_29, sizeof(MTIVLOTHIS->INV_CMF_29));
	memcpy(MTIVLOTHIS->INV_CMF_30, MTIVLOTSTS->INV_CMF_30, sizeof(MTIVLOTHIS->INV_CMF_30));
	 
	MTIVLOTHIS->INV_FLAG_1 = MTIVLOTSTS->INV_FLAG_1;
	MTIVLOTHIS->INV_FLAG_2 = MTIVLOTSTS->INV_FLAG_2;
	MTIVLOTHIS->INV_FLAG_3 = MTIVLOTSTS->INV_FLAG_3;
	MTIVLOTHIS->INV_FLAG_4 = MTIVLOTSTS->INV_FLAG_4;
	MTIVLOTHIS->INV_FLAG_5 = MTIVLOTSTS->INV_FLAG_5;

	memcpy(MTIVLOTHIS->ERP_CREATE_DATE, MTIVLOTSTS->ERP_CREATE_DATE, sizeof(MTIVLOTHIS->ERP_CREATE_DATE));
	memcpy(MTIVLOTHIS->ERP_INV_IN_DATE, MTIVLOTSTS->ERP_INV_IN_DATE, sizeof(MTIVLOTHIS->ERP_INV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_OINV_IN_DATE, MTIVLOTSTS->ERP_OINV_IN_DATE, sizeof(MTIVLOTHIS->ERP_OINV_IN_DATE));
	memcpy(MTIVLOTHIS->ERP_TRAN_DATE, MTIVLOTSTS->ERP_LAST_TRAN_DATE, sizeof(MTIVLOTHIS->ERP_TRAN_DATE));
	 
	////memcpy(MTIVLOTSTS->EXPIRE_DATE, MTIVLOTSTS_OLD->EXPIRE_DATE, sizeof(MTIVLOTSTS_OLD->EXPIRE_DATE));
	////LOT이 없을 경우 새롭게 LOT을 만들어서 HISTORY를 쌓는다. 
 //   /* Update/Insert Lot Status */
 //   if(MTIVLOTSTS->LAST_HIST_SEQ > 1)
 //   {
	//	DBC_update_mtivlotsts(1, MTIVLOTSTS);
 //   }
 //   else
 //   {
 //       DBC_insert_mtivlotsts(MTIVLOTSTS);
 //   }

	DBC_update_mtivlotsts(3, MTIVLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTSTS INSERT/UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "EXPIRE_DATE", MP_STR, sizeof(MTIVLOTSTS->EXPIRE_DATE), MTIVLOTSTS->EXPIRE_DATE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    /* Insert Lot History */
    DBC_insert_mtivlothis(MTIVLOTHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVLOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS->LOT_ID), MTIVLOTHIS->LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVLOTHIS->HIST_SEQ);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    TIV_fill_detail_message(out_node, MTIVLOTSTS, MTIVLOTSTS_OLD);

    return MP_TRUE;
}




/*******************************************************************************
    TIV_get_mat_ext_for_inv()
        - Get material include exetention
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
        - char *factory : Factory Name
        - char *material : Material Name
        - char *mat_ver : Material Version
        - struct MWIPMATDEF_TAG *MWIPMATDEF : Original material table
*******************************************************************************/
int TIV_get_mat_ext_for_inv(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *material,
                             int mat_ver,
                             struct MWIPMATDEF_TAG *MWIPMATDEF)
{

    char s_factory[10];
    char s_mat_id[30];

    COM_memcpy(s_factory, factory, sizeof(s_factory));
    COM_memcpy(s_mat_id, material, sizeof(s_mat_id));

    /* Get material information */
    DBC_init_mwipmatdef(MWIPMATDEF);
    memcpy(MWIPMATDEF->FACTORY, s_factory, sizeof(MWIPMATDEF->FACTORY));
    memcpy(MWIPMATDEF->MAT_ID, s_mat_id, sizeof(MWIPMATDEF->MAT_ID));    

    if( mat_ver != 0)
    {
        MWIPMATDEF->MAT_VER = mat_ver;
        DBC_select_mwipmatdef(1, MWIPMATDEF);
    }
    else
    {
        DBC_select_mwipmatdef(3, MWIPMATDEF);
    }
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF->FACTORY), MWIPMATDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF->MAT_ID), MWIPMATDEF->MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF->MAT_VER);        
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }  

    return MP_TRUE;
}

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
//Get Attribete Value - Flag값을 가지고옴//MAT - Case추가하기 
//4번 CASE문에는 LOT_GROUP_FLAG쿼리 조회 조건에 ATTR_NAME으로 들어가 있음 
//int TIV_Tran_View_Attribute_Value(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS)
//{    
//	
//    
//	memcpy(MATRNAMSTS->FACTORY, MATRNAMSTS->FACTORY, sizeof(MATRNAMSTS->FACTORY));
//	memcpy(MATRNAMSTS->ATTR_TYPE, MATRNAMSTS->ATTR_TYPE, sizeof(MATRNAMSTS->ATTR_TYPE));
//	memcpy(MATRNAMSTS->ATTR_KEY, MATRNAMSTS->ATTR_KEY, sizeof(MATRNAMSTS->ATTR_KEY));
//	
//	
//
//
//    DBU_select_matrnamsts(4, MATRNAMSTS);//ATTR_VALUE만 가지고온다. 
//    if(DB_error_code != DB_SUCCESS)
//    {
//		//ATTRIBUTE에 FLAG를 사용할 경우 없는 경우도 있기 때문에 에러 메시지를 고친다. 
//		if(DB_error_code != DB_NOT_FOUND)
//		{
//			strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//			
//		}
//		else
//		{
//			return MP_TRUE;
//		}
//
//        /*if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "WIP-0005");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else
//        {
//            strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//        }  */   
//        TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS->FACTORY), MATRNAMSTS->FACTORY);
//		TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS->ATTR_TYPE), MATRNAMSTS->ATTR_TYPE);
//		TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS->ATTR_NAME), MATRNAMSTS->ATTR_NAME);
//		TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS->ATTR_KEY), MATRNAMSTS->ATTR_KEY);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//   
//    return MP_TRUE;
//}

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
//Get Attribete Value - Flag값을 가지고옴//Like문으로 비교하여 값을 가져오기 - Case추가하기 
//4번 CASE문에는 LOT_GROUP_FLAG쿼리 조회 조건에 ATTR_NAME으로 들어가 있음 
//int TIV_View_Attribute_Value_For_Split(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS)
//{    
//	
//    
//	memcpy(MATRNAMSTS->FACTORY, MATRNAMSTS->FACTORY, sizeof(MATRNAMSTS->FACTORY));
//	memcpy(MATRNAMSTS->ATTR_TYPE, MATRNAMSTS->ATTR_TYPE, sizeof(MATRNAMSTS->ATTR_TYPE));
//	memcpy(MATRNAMSTS->ATTR_KEY, MATRNAMSTS->ATTR_KEY, sizeof(MATRNAMSTS->ATTR_KEY));
//	
//
//    DBU_select_matrnamsts(4, MATRNAMSTS);//ATTR_VALUE만 가지고온다. 
//    if(DB_error_code != DB_SUCCESS)
//    {
//		//ATTRIBUTE에 FLAG를 사용할 경우 없는 경우도 있기 때문에 에러 메시지를 고친다. 
//		if(DB_error_code != DB_NOT_FOUND)
//		{
//			strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//			
//		}
//		else
//		{
//			return MP_TRUE;
//		}
//
//        /*if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "WIP-0005");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else
//        {
//            strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//        }  */   
//        TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS->FACTORY), MATRNAMSTS->FACTORY);
//		TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS->ATTR_TYPE), MATRNAMSTS->ATTR_TYPE);
//		TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS->ATTR_NAME), MATRNAMSTS->ATTR_NAME);
//		TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS->ATTR_KEY), MATRNAMSTS->ATTR_KEY);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//   
//    return MP_TRUE;
//}

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
//
//int TIV_View_Attribute_Value(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS,
//							int istep)
//{    
//	
//    
//	memcpy(MATRNAMSTS->FACTORY, MATRNAMSTS->FACTORY, sizeof(MATRNAMSTS->FACTORY));
//	memcpy(MATRNAMSTS->ATTR_TYPE, MATRNAMSTS->ATTR_TYPE, sizeof(MATRNAMSTS->ATTR_TYPE));
//	memcpy(MATRNAMSTS->ATTR_KEY, MATRNAMSTS->ATTR_KEY, sizeof(MATRNAMSTS->ATTR_KEY));
//	memcpy(MATRNAMSTS->ATTR_NAME, MATRNAMSTS->ATTR_NAME, sizeof(MATRNAMSTS->ATTR_NAME));
//	
//
//
//    DBU_select_matrnamsts(istep, MATRNAMSTS);//ATTR_VALUE만 가지고온다. 
//    if(DB_error_code != DB_SUCCESS)
//    {
//		//ATTRIBUTE에 FLAG를 사용할 경우 없는 경우도 있기 때문에 에러 메시지를 고친다. 
//		if(DB_error_code != DB_NOT_FOUND)
//		{
//			strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//			
//		}
//		else
//		{
//			return MP_TRUE;
//		}
//
//        /*if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "WIP-0005");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else
//        {
//            strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//        }  */   
//        TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS->FACTORY), MATRNAMSTS->FACTORY);
//		TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS->ATTR_TYPE), MATRNAMSTS->ATTR_TYPE);
//		TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS->ATTR_NAME), MATRNAMSTS->ATTR_NAME);
//		TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS->ATTR_KEY), MATRNAMSTS->ATTR_KEY);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//   
//    return MP_TRUE;
//}

/*******************************************************************************
    TIV_get_oper_ext_for_inv()
        - Get oper include exetention
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
        - char *factory : Factory Name
        - char *operation : Operation Name        
        - struct MWIPOPRDEF_TAG *MWIPOPRDEF : Original opreation table
        - struct MTIVOPRDEF_TAG *MTIVOPRDEF : Exetention operation table
*******************************************************************************/
int TIV_get_oper_ext_for_inv(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *operation,                           
                             struct MTIVOPRDEF_TAG *MTIVOPRDEF)
{

    char s_factory[10];
    char s_oper_id[10];

    COM_memcpy(s_factory, factory, sizeof(s_factory));
    COM_memcpy(s_oper_id, operation, sizeof(s_oper_id));

    /* Get oper information */
    DBC_init_mtivoprdef(MTIVOPRDEF);
    memcpy(MTIVOPRDEF->FACTORY, s_factory, sizeof(MTIVOPRDEF->FACTORY));
    memcpy(MTIVOPRDEF->OPER, s_oper_id, sizeof(MTIVOPRDEF->OPER));    
    
    DBC_select_mtivoprdef(1, MTIVOPRDEF);    
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF->FACTORY), MTIVOPRDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF->OPER), MTIVOPRDEF->OPER);        
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }  

    return MP_TRUE;
}



int TIV_Lot_Fill_InTag_Cmf_For_IQC(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    TRSNode *member;

    if(COM_isnullspace(TRS.get_string(in_node, "INV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    DBC_init_mtivlotsts(&MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, "__FACTORY");
    TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "INV_LOT_ID");
    TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
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
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

    if((member = TRS.get_member(in_node, "ORDER_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
    }    

     if((member = TRS.get_member(in_node, "INV_CMF_1")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_2")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_3")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_4")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_5")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_6")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_7")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_8")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_9")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_10")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_11")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_12")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_13")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_14")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_15")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_16")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_17")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_18")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_19")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
    }
    if((member = TRS.get_member(in_node, "INV_CMF_20")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
    }

    if((member = TRS.get_member(in_node, "VENDOR_ID")) == 0x00 || member->NullFlag == 'Y' || COM_isnullspace(member->Value.s) == MP_TRUE)
    {
        TRS.set_string(in_node, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
    }

    return MP_TRUE;
}


/*******************************************************************************
    TIV_get_mat_ext_for_inventory()
        - Get material include exetention
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
        - char *factory : Factory Name
        - char *material : Material Name
        - char *mat_ver : Material Version
        - struct MTIVMATDEF_TAG *MTIVMATDEF : Inv material table
*******************************************************************************/
int TIV_get_mat_ext_for_inventory(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *material,
                             int mat_ver,
                             struct MWIPMATDEF_TAG *MWIPMATDEF)
{

    char s_factory[10];
    char s_mat_id[30];

    COM_memcpy(s_factory, factory, sizeof(s_factory));
    COM_memcpy(s_mat_id, material, sizeof(s_mat_id));

    /* Get material information */
    DBC_init_mwipmatdef(MWIPMATDEF);
    memcpy(MWIPMATDEF->FACTORY, s_factory, sizeof(MWIPMATDEF->FACTORY));
    memcpy(MWIPMATDEF->MAT_ID, s_mat_id, sizeof(MWIPMATDEF->MAT_ID));
    MWIPMATDEF->MAT_VER = mat_ver;    
    DBC_select_mwipmatdef(1, MWIPMATDEF);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF->FACTORY), MWIPMATDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF->MAT_ID), MWIPMATDEF->MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF->MAT_VER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }    

    return MP_TRUE;
}

    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
/*******************************************************************************
    TIV_View_Attribute_List()
        - Get Attribute Value List
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
        - struct MATRNAMSTS_TAG *MATRNAMSTS : attribute table
*******************************************************************************/
//int TIV_View_Attribute_List(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS)
//{    
//	
//    
//	memcpy(MATRNAMSTS->FACTORY, MATRNAMSTS->FACTORY, sizeof(MATRNAMSTS->FACTORY));
//	memcpy(MATRNAMSTS->ATTR_TYPE, MATRNAMSTS->ATTR_TYPE, sizeof(MATRNAMSTS->ATTR_TYPE));
//	memcpy(MATRNAMSTS->ATTR_NAME, MATRNAMSTS->ATTR_NAME, sizeof(MATRNAMSTS->ATTR_NAME));
//	memcpy(MATRNAMSTS->ATTR_KEY, MATRNAMSTS->ATTR_KEY, sizeof(MATRNAMSTS->ATTR_KEY));
//
//    DBU_select_matrnamsts(4, MATRNAMSTS);//ATTR_VALUE만 가지고온다.
//    if(DB_error_code != DB_SUCCESS)
//    {
//		//ATTRIBUTE에 FLAG를 사용할 경우 없는 경우도 있기 때문에 에러 메시지를 고친다. 
//		if(DB_error_code != DB_NOT_FOUND)
//		{
//			strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//			
//		}
//		else
//		{
//			return MP_TRUE;
//		}
//
//        /*if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "WIP-0005");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else
//        {
//            strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//        }  */   
//        TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS->FACTORY), MATRNAMSTS->FACTORY);
//		TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS->ATTR_TYPE), MATRNAMSTS->ATTR_TYPE);
//		TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS->ATTR_NAME), MATRNAMSTS->ATTR_NAME);
//		TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS->ATTR_KEY), MATRNAMSTS->ATTR_KEY);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//   
//    return MP_TRUE;
//}

/*******************************************************************************
    TIV_lot_tran_validation_for_inv()
        - check validatiton of lot transaction value except flow
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code 
            + Message Code to be returned
        - char *s_field_msg
            + Field Key Message to be returned
        - char *s_db_err_msg
            + DB Error Message to be returned
        - char *s_factory
            + input factory
        - char *s_lot_id
            + input lot id
        - int i_last_active_hist_seq
            + input last active hist sequence
        - char *s_mat_id
            + input material id
        - int i_mat_ver
            + input material version
        - char *s_oper 
            + input operation
        - struct MTIVLOTSTS_TAG *MTIVLOTSTS 
            + retrived lot information
        - struct MWIPFACDEF_TAG *MWIPFACDEF 
            + retrived factory information
        - struct MWIPMATDEF_TAG *MWIPMATDEF 
            + retrived material information
        - struct MWIPOPRDEF_TAG *MWIPOPRDEF 
            + retrived operation information
        - char *s_user_id
            + for check privilege
*******************************************************************************/
//int TIV_lot_tran_validation_for_inv(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
//                            struct MWIPFACDEF_TAG *MWIPFACDEF,
//                            struct MWIPMATDEF_TAG *MWIPMATDEF,
//                            struct MTIVOPRDEF_TAG *MTIVOPRDEF)
//{    
//
//    /* Lot ID Validation */
//    if(COM_isnullspace(TRS.get_string(in_node, "INV_LOT_ID")) == MP_TRUE)
//    {
//        strcpy(s_msg_code, "INV-0001");
//        TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_NVST);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.e_type = MP_LOG_E_VALIDATION;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//
//     /* Factory Validation */
//    if(COM_isnullspace(TRS.get_string(in_node, IN_FACTORY)) == MP_TRUE)
//    {
//        strcpy(s_msg_code, "WIP-0001");
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.e_type = MP_LOG_E_VALIDATION;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//
//    DBC_init_mtivlotsts(MTIVLOTSTS);
//    TRS.copy(MTIVLOTSTS->FACTORY, sizeof(MTIVLOTSTS->FACTORY), in_node, IN_FACTORY);
//    TRS.copy(MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID), in_node, "INV_LOT_ID");    
//    TRS.copy(MTIVLOTSTS->OPER, sizeof(MTIVLOTSTS->OPER), in_node, "OPER");
//    DBC_select_mtivlotsts_for_update(2, MTIVLOTSTS);
//    if(DB_error_code != DB_SUCCESS)
//    {
//        if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "WIP-0044");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else
//        {
//            strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//        }     
//        TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
//        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//   
//    if(TRS.mem_cmp(in_node, IN_FACTORY, MTIVLOTSTS->FACTORY, strlen(TRS.get_string(in_node, IN_FACTORY))) != 0)
//    {
//        strcpy(s_msg_code, "WIP-0063");
//        TRS.add_fieldmsg(out_node, "FACTORY 1", MP_NSTR, TRS.get_string(in_node, IN_FACTORY));
//        TRS.add_fieldmsg(out_node, "FACTORY 2", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.e_type = MP_LOG_E_VALIDATION;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//
//    if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") < 1)
//    {
//        /*strcpy(s_msg_code, "INV-0001");
//        TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_NVST);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.e_type = MP_LOG_E_VALIDATION;
//        gs_log_type.category = MP_LOG_CATE_TRANS;
//        return MP_FALSE;*/    
//    }
//    else
//    {
//
//        //TRS.set_nstring(in_node, "__F_INV_LOT_ID", TRS.get_string(in_node, "INV_LOT_ID"));
//        //if (INV_Get_Last_Active_Lot_Grp_Seq(s_msg_code, in_node, out_node) == MP_FALSE)
//        //{
//        //    return MP_FALSE;
//        //}
//        //
//        ///* Hist Seq Validation */
//  //      if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != TRS.get_int(in_node, "__F_LAST_ACTIVE_HIST_SEQ")) 
//  //      {
//  //          strcpy(s_msg_code, "WIP-0113");
//  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
//  //          TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ);
//  //          TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
//
//  //          gs_log_type.type = MP_LOG_ERROR;
//  //          gs_log_type.e_type = MP_LOG_E_VALIDATION;
//  //          gs_log_type.category = MP_LOG_CATE_COMMON;
//  //          return MP_FALSE;
//  //      }
//
//
//        /* Hist Seq Validation */
//        if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ) 
//        {
//            strcpy(s_msg_code, "WIP-0113");
//            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
//            TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ);
//            TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_VALIDATION;
//            gs_log_type.category = MP_LOG_CATE_COMMON;
//            return MP_FALSE;
//        }
//
//
//        /* Material Validation */
//        if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
//        {
//            strcpy(s_msg_code, "WIP-0001");
//            TRS.add_fieldmsg(out_node, "MAT_ID", MP_NVST);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_VALIDATION;
//            gs_log_type.category = MP_LOG_CATE_COMMON;
//            return MP_FALSE;
//        }
//        else
//        {
//            if(TRS.mem_cmp(in_node, "MAT_ID", MTIVLOTSTS->MAT_ID, strlen(TRS.get_string(in_node, "MAT_ID"))) != 0)
//            {
//                strcpy(s_msg_code, "WIP-0064");
//                TRS.add_fieldmsg(out_node, "MAT_ID 1", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
//                TRS.add_fieldmsg(out_node, "MAT_ID 2", MP_STR, sizeof(MTIVLOTSTS->MAT_ID), MTIVLOTSTS->MAT_ID);
//
//                gs_log_type.type = MP_LOG_ERROR;
//                gs_log_type.e_type = MP_LOG_E_VALIDATION;
//                gs_log_type.category = MP_LOG_CATE_COMMON;
//                return MP_FALSE;
//            }
//            if(TRS.get_int(in_node, "MAT_VER") != MTIVLOTSTS->MAT_VER)
//            {
//                strcpy(s_msg_code, "WIP-0331");
//                TRS.add_fieldmsg(out_node, "MAT_VER 1", MP_INT, TRS.get_int(in_node, "MAT_VER"));
//                TRS.add_fieldmsg(out_node, "MAT_VER 2", MP_INT, MTIVLOTSTS->MAT_VER);
//
//                gs_log_type.type = MP_LOG_ERROR;
//                gs_log_type.e_type = MP_LOG_E_VALIDATION;
//                gs_log_type.category = MP_LOG_CATE_COMMON;
//                return MP_FALSE;
//            }           
//        }       
//    }
//
//    DBC_init_mwipfacdef(MWIPFACDEF);
//    TRS.copy(MWIPFACDEF->FACTORY, sizeof(MWIPFACDEF->FACTORY), in_node, IN_FACTORY);
//    DBC_select_mwipfacdef(1, MWIPFACDEF);
//    if(DB_error_code != DB_SUCCESS)
//    {
//        if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "WIP-0005");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else
//        {
//            strcpy(s_msg_code, "WIP-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//        }     
//        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF->FACTORY), MWIPFACDEF->FACTORY);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//        
//    DBC_init_mtivoprdef(MTIVOPRDEF);
//    TRS.copy(MTIVOPRDEF->FACTORY, sizeof(MTIVOPRDEF->FACTORY), in_node, IN_FACTORY);
//    TRS.copy(MTIVOPRDEF->OPER, sizeof(MTIVOPRDEF->OPER), in_node, "OPER");
//    DBC_select_mtivoprdef(1, MTIVOPRDEF);
//    if(DB_error_code != DB_SUCCESS)
//    {
//        if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "INV-0010");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else
//        {
//            strcpy(s_msg_code, "INV-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//            TRS.add_dberrmsg(out_node, DB_error_msg);
//        }     
//        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF->FACTORY), MTIVOPRDEF->FACTORY);
//        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF->OPER), MTIVOPRDEF->OPER);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_COMMON;
//        return MP_FALSE;
//    }
//    
//
//    if(MTIVOPRDEF->SEC_CHK_FLAG == 'Y')
//    {
//        if(TRS.get_char(in_node, MP_NOTCHECK_PRIVILEGE) != 'Y')
//        {
//            /* Privilege Validation */
//            if(COM_check_privilege(s_msg_code, 
//                                   out_node, 
//                                   '2',
//                                   MTIVOPRDEF->FACTORY, 
//                                   MP_PRV_TYPE_OPER,
//                                   MTIVOPRDEF->OPER,
//                                   sizeof(MTIVOPRDEF->OPER),
//                                   "",
//                                   0,
//                                   "",
//                                   0,
//                                   TRS.get_userid(in_node)) == MP_FALSE)
//            {
//                return MP_FALSE;
//            }
//        }
//    }
//
//    
//	//Get Material information        
//	if (TIV_get_mat_ext_for_inventory(s_msg_code, out_node, TRS.get_factory(in_node), TRS.get_string(in_node, "MAT_ID"),TRS.get_int(in_node, "MAT_VER"),
//                        MWIPMATDEF) == MP_FALSE)
//    {
//        return MP_FALSE;
//    } 
//        
//    /* Back Time Check */
//    if(COM_check_backtime(s_msg_code,
//                            in_node,
//                            out_node,
//                            MTIVLOTSTS->LAST_TRAN_TIME) == MP_FALSE)
//    {
//        return MP_FALSE;
//        
//    } 
//
//    return MP_TRUE;
//}

int TIV_lot_tran_validation_for_inv(char *s_msg_code, 
                            TRSNode *out_node,
                            TRSNode *in_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
                            struct MWIPFACDEF_TAG *MWIPFACDEF,
                            struct MWIPMATDEF_TAG *MWIPMATDEF,
                            struct MTIVOPRDEF_TAG *MTIVOPRDEF)
{    

    /* Lot ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "INV_LOT_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_NVST);

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

    DBC_init_mtivlotsts(MTIVLOTSTS);
    TRS.copy(MTIVLOTSTS->FACTORY, sizeof(MTIVLOTSTS->FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVLOTSTS->LOT_ID, sizeof(MTIVLOTSTS->LOT_ID), in_node, "INV_LOT_ID");    
    TRS.copy(MTIVLOTSTS->OPER, sizeof(MTIVLOTSTS->OPER), in_node, "OPER");
    DBC_select_mtivlotsts_for_update(2, MTIVLOTSTS);
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
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
   
    if(TRS.mem_cmp(in_node, IN_FACTORY, MTIVLOTSTS->FACTORY, strlen(TRS.get_string(in_node, IN_FACTORY))) != 0)
    {
        strcpy(s_msg_code, "WIP-0063");
        TRS.add_fieldmsg(out_node, "FACTORY 1", MP_NSTR, TRS.get_string(in_node, IN_FACTORY));
        TRS.add_fieldmsg(out_node, "FACTORY 2", MP_STR, sizeof(MTIVLOTSTS->FACTORY), MTIVLOTSTS->FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") < 1)
    {
        /*strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;*/    
    }
    else
    {

        //TRS.set_nstring(in_node, "__F_INV_LOT_ID", TRS.get_string(in_node, "INV_LOT_ID"));
        //if (INV_Get_Last_Active_Lot_Grp_Seq(s_msg_code, in_node, out_node) == MP_FALSE)
        //{
        //    return MP_FALSE;
        //}
        //
        ///* Hist Seq Validation */
  //      if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != TRS.get_int(in_node, "__F_LAST_ACTIVE_HIST_SEQ")) 
  //      {
  //          strcpy(s_msg_code, "WIP-0113");
  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
  //          TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ);
  //          TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_VALIDATION;
  //          gs_log_type.category = MP_LOG_CATE_COMMON;
  //          return MP_FALSE;
  //      }


        /* Hist Seq Validation */
        if(TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ") != MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ) 
        {
            strcpy(s_msg_code, "WIP-0113");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
            TRS.add_fieldmsg(out_node, "LAST_ACTIVE_HIST_SEQ", MP_INT, MTIVLOTSTS->LAST_ACTIVE_HIST_SEQ);
            TRS.add_fieldmsg(out_node, "INPUT_LAST_ACTIVE_HIST_SEQ", MP_INT, TRS.get_int(in_node, "LAST_ACTIVE_HIST_SEQ"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
        }


        /* Material Validation */
        if(COM_isnullspace(TRS.get_string(in_node, "MAT_ID")) == MP_TRUE)
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
            if(TRS.mem_cmp(in_node, "MAT_ID", MTIVLOTSTS->MAT_ID, strlen(TRS.get_string(in_node, "MAT_ID"))) != 0)
            {
                strcpy(s_msg_code, "WIP-0064");
                TRS.add_fieldmsg(out_node, "MAT_ID 1", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
                TRS.add_fieldmsg(out_node, "MAT_ID 2", MP_STR, sizeof(MTIVLOTSTS->MAT_ID), MTIVLOTSTS->MAT_ID);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
            if(TRS.get_int(in_node, "MAT_VER") != MTIVLOTSTS->MAT_VER)
            {
                strcpy(s_msg_code, "WIP-0331");
                TRS.add_fieldmsg(out_node, "MAT_VER 1", MP_INT, TRS.get_int(in_node, "MAT_VER"));
                TRS.add_fieldmsg(out_node, "MAT_VER 2", MP_INT, MTIVLOTSTS->MAT_VER);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }           
        }       
    }

    DBC_init_mwipfacdef(MWIPFACDEF);
    TRS.copy(MWIPFACDEF->FACTORY, sizeof(MWIPFACDEF->FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, MWIPFACDEF);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF->FACTORY), MWIPFACDEF->FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
        
    DBC_init_mtivoprdef(MTIVOPRDEF);
    TRS.copy(MTIVOPRDEF->FACTORY, sizeof(MTIVOPRDEF->FACTORY), in_node, IN_FACTORY);
    TRS.copy(MTIVOPRDEF->OPER, sizeof(MTIVOPRDEF->OPER), in_node, "OPER");
    DBC_select_mtivoprdef(1, MTIVOPRDEF);
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
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF->FACTORY), MTIVOPRDEF->FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF->OPER), MTIVOPRDEF->OPER);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }
    

    if(MTIVOPRDEF->SEC_CHK_FLAG == 'Y')
    {
        if(TRS.get_char(in_node, MP_NOTCHECK_PRIVILEGE) != 'Y')
        {
            /* Privilege Validation */
            if(COM_check_privilege(s_msg_code, 
                                   out_node, 
                                   '2',
                                   MTIVOPRDEF->FACTORY, 
                                   MP_PRV_TYPE_OPER,
                                   MTIVOPRDEF->OPER,
                                   sizeof(MTIVOPRDEF->OPER),
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

	TRS.set_string(in_node, "MAT_ID", MTIVLOTSTS->MAT_ID, sizeof(MTIVLOTSTS->MAT_ID));
	TRS.set_int(in_node, "MAT_VER", MTIVLOTSTS->MAT_VER);
    
	//Get Material information        
	if (TIV_get_mat_ext_for_inventory(s_msg_code, out_node, TRS.get_factory(in_node), TRS.get_string(in_node, "MAT_ID"),TRS.get_int(in_node, "MAT_VER"),
                        MWIPMATDEF) == MP_FALSE)
    {
        return MP_FALSE;
    } 
        
    /* Back Time Check */
    if(TIV_check_backtime(s_msg_code,
                            in_node,
                            out_node,
                            MTIVLOTSTS->LAST_TRAN_TIME) == MP_FALSE)
    {
        return MP_FALSE;
        
    } 

    return MP_TRUE;
}

/*******************************************************************************
    TIV_Check_Aging_Time
        - Check Aging Time
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
*******************************************************************************/
int TIV_Check_Aging_Time(char *s_msg_code, 
                            TRSNode *in_node,
							TRSNode *out_node,
							struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
							struct MATRNAMSTS_TAG *MATRNAMSTS, 
							char *s_sys_time_t)
{    
	
	char s_aging_time[14];
	char s_sys_time[14];

	memset(s_sys_time,' ', sizeof(s_sys_time));
	memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));

	if(COM_isnullspace(MATRNAMSTS->ATTR_VALUE) == MP_TRUE)
		return MP_TRUE;

	memset(s_aging_time, ' ', sizeof(s_aging_time));
	COM_add_time_sec(s_aging_time,MTIVLOTSTS->OINV_OUT_TIME, COM_atol(MATRNAMSTS->ATTR_VALUE, sizeof(MATRNAMSTS->ATTR_VALUE)) * 60);

	if(memcmp(s_aging_time, s_sys_time, sizeof(s_sys_time)) > 0)
	{
		strcpy(s_msg_code, "INV-0053"); 
		TRS.add_fieldmsg(out_node, "Check Aging Time", MP_NVST); 
		TRS.add_fieldmsg(out_node, "Inv_Lot_Id", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "Inv_Oper", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
		TRS.add_fieldmsg(out_node, "Oper_In_Time+Setup_Aging_Time", MP_STR, sizeof(s_aging_time), s_aging_time);
		TRS.add_fieldmsg(out_node, "Current time", MP_STR, sizeof(s_sys_time), s_sys_time);
		TRS.add_fieldmsg(out_node, "Oper_In_Time", MP_STR, sizeof(MTIVLOTSTS->OINV_OUT_TIME), MTIVLOTSTS->OINV_OUT_TIME);
		TRS.add_fieldmsg(out_node, "Setup_Aging_Time", MP_STR, sizeof(MATRNAMSTS->ATTR_VALUE), MATRNAMSTS->ATTR_VALUE);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		return MP_FALSE;
	}
   
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Check_QTime
        - Check QTime
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
*******************************************************************************/
int TIV_Check_QTime(char *s_msg_code, 
                            TRSNode *in_node,
							TRSNode *out_node,
							struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
							struct MATRNAMSTS_TAG *MATRNAMSTS, 
							char *s_sys_time_t)
{
	char s_Qtime[14];
	char s_sys_time[14];

	if(COM_isnullspace(MATRNAMSTS->ATTR_VALUE) == MP_TRUE || COM_atoi(MATRNAMSTS->ATTR_VALUE, sizeof(MATRNAMSTS->ATTR_VALUE)) <= 0)
		return MP_TRUE;

	memset(s_sys_time,' ', sizeof(s_sys_time));
	memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));

	memset(s_Qtime, ' ', sizeof(s_Qtime));
	COM_add_time_sec(s_Qtime,MTIVLOTSTS->OINV_IN_TIME, COM_atol(MATRNAMSTS->ATTR_VALUE, sizeof(MATRNAMSTS->ATTR_VALUE)) * 60);

	if(memcmp(s_sys_time, s_Qtime, sizeof(s_sys_time)) > 0)
	{
		strcpy(s_msg_code, "INV-0054"); 
		TRS.add_fieldmsg(out_node, "Check_QTime", MP_NVST);
		TRS.add_fieldmsg(out_node, "Inv_Lot_Id", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "Inv_Oper", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
		TRS.add_fieldmsg(out_node, "Oper_In_Time+Setup_QTime", MP_STR, sizeof(s_Qtime), s_Qtime);
		TRS.add_fieldmsg(out_node, "Current time", MP_STR, sizeof(s_sys_time), s_sys_time);
		TRS.add_fieldmsg(out_node, "Oper_In_Time", MP_STR, sizeof(MTIVLOTSTS->OINV_IN_TIME), MTIVLOTSTS->OINV_IN_TIME);
		TRS.add_fieldmsg(out_node, "Setup_QTime", MP_STR, sizeof(MATRNAMSTS->ATTR_VALUE), MATRNAMSTS->ATTR_VALUE);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		return MP_FALSE;
	}
   
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Check_Expire_Date
        - Check Expire Date
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
*******************************************************************************/
int TIV_Check_Expire_Date(char *s_msg_code, 
                            TRSNode *in_node,
							TRSNode *out_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS,
							char *s_sys_time_t)
{
	char s_sys_time[14];

	if(COM_isnullspace(MTIVLOTSTS->EXPIRE_DATE) == MP_TRUE)
		return MP_TRUE;

	memset(s_sys_time,' ', sizeof(s_sys_time));
	memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));
	
	//if(memcmp(MTIVLOTSTS->EXPIRE_DATE,s_sys_time, sizeof(s_sys_time)) > 0)
	if(memcmp(s_sys_time, MTIVLOTSTS->EXPIRE_DATE,sizeof(s_sys_time)) > 0)
	{
		strcpy(s_msg_code, "INV-0057"); 
		TRS.add_fieldmsg(out_node, "Check_Expire_Date", MP_NVST); 
		TRS.add_fieldmsg(out_node, "Inv_Lot_Id", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "Inv_Oper", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
		TRS.add_fieldmsg(out_node, "Expire_Date", MP_STR, sizeof(MTIVLOTSTS->EXPIRE_DATE), MTIVLOTSTS->EXPIRE_DATE);
		TRS.add_fieldmsg(out_node, "Current_time", MP_STR, sizeof(s_sys_time), s_sys_time);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		return MP_FALSE;
	}
   
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Check_Use_Count
        - Check Usage Count
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
*******************************************************************************/
int TIV_Check_Usage_Count(char *s_msg_code, 
                            TRSNode *in_node,
							TRSNode *out_node,
							struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
							struct MATRNAMSTS_TAG *MATRNAMSTS, 
							char *s_sys_time_t)
{
	int i_used_count;
	char s_sys_time[14];

	if(COM_isnullspace(MATRNAMSTS->ATTR_VALUE) == MP_TRUE|| COM_atoi(MATRNAMSTS->ATTR_VALUE, sizeof(MATRNAMSTS->ATTR_VALUE)) <= 0)
		return MP_TRUE;

	memset(s_sys_time,' ', sizeof(s_sys_time));
	memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));

	i_used_count = COM_atoi(MTIVLOTSTS->INV_CMF_11,sizeof(MTIVLOTSTS->INV_CMF_11)) + (int)MWIPLOTSTS->QTY_1;

	if(i_used_count > COM_atoi(MATRNAMSTS->ATTR_VALUE, sizeof(MATRNAMSTS->ATTR_VALUE))) 
	{
		strcpy(s_msg_code, "INV-0055");
		TRS.add_fieldmsg(out_node, "Check_Use_Count", MP_NVST); 
		TRS.add_fieldmsg(out_node, "Inv_Lot_Id", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "Inv_Oper", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
		TRS.add_fieldmsg(out_node, "Used_Count+Current_Count", MP_INT,i_used_count);
		TRS.add_fieldmsg(out_node, "Setup_Use_Count", MP_STR, sizeof(MATRNAMSTS->ATTR_VALUE), MATRNAMSTS->ATTR_VALUE);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		return MP_FALSE;
	}
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Check_Init_Count
        - Check Init Count
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
*******************************************************************************/
int TIV_Check_Cycle_Count(char *s_msg_code, 
                            TRSNode *in_node,
							TRSNode *out_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
							struct MATRNAMSTS_TAG *MATRNAMSTS, 
							char *s_sys_time_t)
{
	int i_cycle_count;
	char s_sys_time[14];

	if(COM_isnullspace(MATRNAMSTS->ATTR_VALUE) == MP_TRUE|| COM_atoi(MATRNAMSTS->ATTR_VALUE, sizeof(MATRNAMSTS->ATTR_VALUE)) <= 0)
		return MP_TRUE;

	memset(s_sys_time,' ', sizeof(s_sys_time));
	memcpy(s_sys_time, s_sys_time_t, sizeof(s_sys_time));

	i_cycle_count = COM_atoi(MTIVLOTSTS->INV_CMF_12,sizeof(MTIVLOTSTS->INV_CMF_12));

	if(i_cycle_count >= COM_atoi(MATRNAMSTS->ATTR_VALUE, sizeof(MATRNAMSTS->ATTR_VALUE))) 
	{
		strcpy(s_msg_code, "INV-0056");
		TRS.add_fieldmsg(out_node, "Check_Cycle_Count", MP_NVST); 
		TRS.add_fieldmsg(out_node, "Inv_Lot_Id", MP_STR, sizeof(MTIVLOTSTS->LOT_ID), MTIVLOTSTS->LOT_ID);
		TRS.add_fieldmsg(out_node, "Inv_Oper", MP_STR, sizeof(MTIVLOTSTS->OPER), MTIVLOTSTS->OPER);
		TRS.add_fieldmsg(out_node, "Cycle_Count", MP_INT,i_cycle_count);
		TRS.add_fieldmsg(out_node, "Setup_Cycle_Count", MP_STR, sizeof(MATRNAMSTS->ATTR_VALUE), MATRNAMSTS->ATTR_VALUE);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
		return MP_FALSE;
	}
    return MP_TRUE;
}

/*******************************************************************************
    TIV_Check_Factory
        - Check Usage Count
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
*******************************************************************************/
int TIV_Check_Factory(char *s_msg_code, 
						char *s_global_option,
						char *s_factory)
{
	struct MBASGLBDEF_TAG MBASGLBDEF;
	char global_option[30];
	char factory[10];

	memset(global_option,' ', sizeof(global_option));
	memset(factory,' ', sizeof(factory));
	memcpy(global_option, s_global_option, sizeof(global_option));
	memcpy(factory, s_factory, sizeof(factory));

	DBC_init_mbasglbdef(&MBASGLBDEF);
	memcpy(MBASGLBDEF.FACTORY, factory, sizeof(MBASGLBDEF.FACTORY));
	memcpy(MBASGLBDEF.OPTION_NAME, global_option, sizeof(MBASGLBDEF.OPTION_NAME)); // MP_CheckINVMaterialValidation
	DBC_select_mbasglbdef(1,&MBASGLBDEF);
	if(DB_error_code == DB_SUCCESS && memcmp(MBASGLBDEF.VALUE_1, "Y", 1) == 0) // Global Option Check
	{
		return MP_TRUE;
	}
	else
	{
		return MP_FALSE;
	}
}

/*******************************************************************************
    TIV_Check_Material_Validation
        - Check Usage Count
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
*******************************************************************************/
int TIV_Check_Material_Validation(char *s_msg_code, 
						char *s_table_name,
						struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
						struct MTIVMATDEF_TAG *MTIVMATDEF)
{
    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic altered
        
    */

	/*int TIV_Check_Material_Validation(char *s_msg_code, 
						char *s_table_name,
						struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
						struct MTAPCPOSTS_TAG *MTAPCPOSTS,
						struct MTIVMATDEF_TAG *MTIVMATDEF)*/

	//struct MGCMTBLDAT_TAG MGCMTBLDAT;
	//struct MBASGLBDEF_TAG MBASGLBDEF;
	char table_name[20];

	memset(table_name,' ', sizeof(table_name));
	memcpy(table_name, s_table_name, sizeof(table_name));

	//DBC_init_mgcmtbldat(&MGCMTBLDAT);
	//memcpy(MGCMTBLDAT.FACTORY, MWIPLOTSTS->FACTORY, sizeof(MGCMTBLDAT.FACTORY));
	//memcpy(MGCMTBLDAT.TABLE_NAME , table_name, sizeof(MGCMTBLDAT.TABLE_NAME)); // B@INV_MAT_CHECK
	//memcpy(MGCMTBLDAT.KEY_1 , MTIVMATDEF->MAT_TYPE , sizeof(MTIVMATDEF->MAT_TYPE));
	//memcpy(MGCMTBLDAT.KEY_2 , MWIPLOTSTS->OPER , sizeof(MWIPLOTSTS->OPER));
	//memcpy(MGCMTBLDAT.KEY_3 , MTAPCPOSTS->ORDER_TYPE , sizeof(MTAPCPOSTS->ORDER_TYPE));
	//DBU_select_mgcmtbldat(7,&MGCMTBLDAT);
	//if(DB_error_code == DB_SUCCESS && memcmp(MGCMTBLDAT.DATA_1, "Y", 1) == 0) // GCM Check
	//{
	//	return MP_TRUE;
	//}
	//else
	//{
		return MP_FALSE;
	//}
}

						/*******************************************************************************
    TIV_get_mat_ext_for_inv()
        - Get material include exetention
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Message Code
        - TRSNode *out_node : Output structure
        - char *factory : Factory Name
        - char *material : Material Name
        - char *mat_ver : Material Version
        - struct MWIPMATDEF_TAG *MWIPMATDEF : Original material table
*******************************************************************************/
int TIV_Create_Inventory_Adjust_Info(char *s_msg_code,
	                         TRSNode *in_node,
                             TRSNode *out_node)
{
	//struct CSUMADJLOT_TAG CSUMADJLOT;
	//
 //   /* Get material information */
 //   DBC_init_csumadjlot(&CSUMADJLOT);
	//if (COM_isnullspace(TRS.get_string(in_node, "EXT_FACTORY")) == MP_TRUE)
	//{
	//	TRS.copy(CSUMADJLOT.FACTORY, sizeof(CSUMADJLOT.FACTORY), in_node, "FACTORY");
	//}
	//else
	//{
	//	TRS.copy(CSUMADJLOT.FACTORY, sizeof(CSUMADJLOT.FACTORY), in_node, "EXT_FACTORY");
	//}
	//
	//TRS.copy(CSUMADJLOT.MAT_ID, sizeof(CSUMADJLOT.MAT_ID), in_node, "MAT_ID");
	//CSUMADJLOT.MAT_VER = TRS.get_int(in_node, "MAT_VER");
	//TRS.copy(CSUMADJLOT.OPER, sizeof(CSUMADJLOT.OPER), in_node, "OPER");
	//TRS.copy(CSUMADJLOT.SHIFT, sizeof(CSUMADJLOT.SHIFT), in_node, "SHIFT");
	//TRS.copy(CSUMADJLOT.WORK_DATE, sizeof(CSUMADJLOT.WORK_DATE), in_node, "WORK_DATE");
	//TRS.copy(CSUMADJLOT.LOT_ID, sizeof(CSUMADJLOT.LOT_ID), in_node, "LOT_ID");
	//CSUMADJLOT.HIST_SEQ = TRS.get_int(in_node, "HIST_SEQ");
	//TRS.copy(CSUMADJLOT.TRAN_TIME, sizeof(CSUMADJLOT.TRAN_TIME), in_node, "__ERP_TRAN_TIME");
	//CSUMADJLOT.IN_OUT_FLAG = TRS.get_char(in_node, "IN_OUT_FLAG");
	//CSUMADJLOT.ADJUST_QTY_1 = TRS.get_double(in_node, "ADJUST_QTY_1");
	//CSUMADJLOT.ADJUST_QTY_2 = TRS.get_double(in_node, "ADJUST_QTY_2");
	//CSUMADJLOT.ADJUST_QTY_3 = TRS.get_double(in_node, "ADJUST_QTY_3");
	//TRS.copy(CSUMADJLOT.CREATE_TIME, sizeof(CSUMADJLOT.CREATE_TIME), in_node, "__SYS_TIME");
	//TRS.copy(CSUMADJLOT.CREATE_USER_ID, sizeof(CSUMADJLOT.CREATE_USER_ID), in_node, IN_USERID);

	//DBC_insert_csumadjlot(&CSUMADJLOT);
 //   if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
 //   {
 //       strcpy(s_msg_code, "WIP-0004");
 //       gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //       TRS.add_dberrmsg(out_node, DB_error_msg);

 //       TRS.add_fieldmsg(out_node, "CSUMADJLOT SELECT", MP_NVST);
 //       TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CSUMADJLOT.FACTORY), CSUMADJLOT.FACTORY);
 //       TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CSUMADJLOT.LOT_ID), CSUMADJLOT.LOT_ID);
	//	TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CSUMADJLOT.CREATE_TIME), CSUMADJLOT.CREATE_TIME);
 //       TRS.add_dberrmsg(out_node, DB_error_msg);

 //       gs_log_type.type = MP_LOG_ERROR;
 //       gs_log_type.e_type = MP_LOG_E_SYSTEM;
 //       gs_log_type.category = MP_LOG_CATE_COMMON;

	//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
 //       return MP_FALSE;
 //   }  

    return MP_TRUE;
}

int TIV_Create_Material_Usage_Info(char *s_msg_code,
	                         TRSNode *in_node,
                             TRSNode *out_node)
{
	struct MTIVLOTSTS_TAG MTIVLOTSTS;
	struct MTIVLOTSTS_TAG MTIVLOTSTS_TO;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MTIVMATUSE_TAG MTIVMATUSE;

	int i_step;

	char c_wip_or_tiv = ' ';
	char c_i_or_u = ' ';

	if (TRS.get_char(in_node, "ADJUST_FLAG") == 'Y')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "INPUT_LOT_ID");
		i_step = 6;
		DBC_select_mtivlotsts(i_step, &MTIVLOTSTS);
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

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);            
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	else
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);        
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "INPUT_LOT_ID");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "USE_OPER");
		i_step = 4;
		DBC_select_mtivlotsts(i_step, &MTIVLOTSTS);
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

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);            
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

	}
    
	DBC_init_mwiplotsts(&MWIPLOTSTS);  
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "TO_LOT_ID");
			 
	i_step = 1;
	DBC_select_mwiplotsts(i_step, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS) 
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			DBC_init_mtivlotsts(&MTIVLOTSTS_TO);
			TRS.copy(MTIVLOTSTS_TO.FACTORY, sizeof(MTIVLOTSTS_TO.FACTORY), in_node, IN_FACTORY);        
			TRS.copy(MTIVLOTSTS_TO.LOT_ID, sizeof(MTIVLOTSTS_TO.LOT_ID), in_node, "TO_LOT_ID");
			//TRS.copy(MTIVLOTSTS_TO.OPER, sizeof(MTIVLOTSTS_TO.OPER), in_node, "USE_OPER");
			DBC_select_mtivlotsts(6, &MTIVLOTSTS_TO);
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

				TRS.add_fieldmsg(out_node, "MTIVLOTSTS_TO SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_TO.FACTORY), MTIVLOTSTS_TO.FACTORY);            
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_TO.LOT_ID), MTIVLOTSTS_TO.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			c_wip_or_tiv = 'I';
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");				
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}						
	}
	else
	{
		c_wip_or_tiv = 'W';
	}

	 
	DBC_init_mtivmatuse(&MTIVMATUSE);	

	if (c_wip_or_tiv == 'W')
	{
		MTIVMATUSE.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
	}
	else
	{
		MTIVMATUSE.HIST_SEQ = MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ;
	}
	 	 
	TRS.copy(MTIVMATUSE.FACTORY, sizeof(MTIVMATUSE.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MTIVMATUSE.LOT_ID, sizeof(MTIVMATUSE.LOT_ID), in_node, "TO_LOT_ID");
	memcpy(MTIVMATUSE.INPUT_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));

	i_step = 1;
	DBC_select_mtivmatuse(i_step, &MTIVMATUSE);
	if(DB_error_code != DB_SUCCESS)
	{
		if (DB_error_code == DB_NOT_FOUND)
		{
			c_i_or_u = 'I';
		}
		else
		{	
			strcpy(s_msg_code,"GCM-0008");			
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.add_fieldmsg(out_node, "MTIVMATUSE SELECT FACTORY", MP_STR, sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
			TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR, sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
  
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}				
	}
	else
	{
		c_i_or_u = 'U';
	}

	if (c_wip_or_tiv == 'W')
	{
		MTIVMATUSE.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
		MTIVMATUSE.MAT_VER = MWIPLOTSTS.MAT_VER;
		memcpy(MTIVMATUSE.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MTIVMATUSE.MAT_ID));
		memcpy(MTIVMATUSE.FLOW, MWIPLOTSTS.FLOW, sizeof(MTIVMATUSE.FLOW));
		memcpy(MTIVMATUSE.OPER, MWIPLOTSTS.OPER, sizeof(MTIVMATUSE.OPER));

		//PROD_LOT_QTY
		if (TRS.get_char(in_node, "ADJUST_FLAG") == 'Y')		
		{
			MTIVMATUSE.QTY_1 = TRS.get_double(in_node, "PROD_LOT_QTY");
			MTIVMATUSE.QTY_2 = MWIPLOTSTS.QTY_2;
			MTIVMATUSE.QTY_3 = MWIPLOTSTS.QTY_3;			
		}
		else
		{
			MTIVMATUSE.QTY_1 = MWIPLOTSTS.QTY_1;
			MTIVMATUSE.QTY_2 = MWIPLOTSTS.QTY_2;
			MTIVMATUSE.QTY_3 = MWIPLOTSTS.QTY_3;
		}
	}
	else
	{
		MTIVMATUSE.HIST_SEQ = MTIVLOTSTS_TO.LAST_ACTIVE_HIST_SEQ;
		MTIVMATUSE.MAT_VER = MTIVLOTSTS_TO.MAT_VER;
		memcpy(MTIVMATUSE.OPER, MTIVLOTSTS_TO.OPER, sizeof(MTIVMATUSE.OPER));
		memcpy(MTIVMATUSE.MAT_ID, MTIVLOTSTS_TO.MAT_ID, sizeof(MTIVMATUSE.MAT_ID));

		//PROD_LOT_QTY
		if (TRS.get_char(in_node, "ADJUST_FLAG") == 'Y')		
		{
			MTIVMATUSE.QTY_1 = TRS.get_double(in_node, "PROD_LOT_QTY");
			MTIVMATUSE.QTY_2 = MTIVLOTSTS_TO.QTY_2;
			MTIVMATUSE.QTY_3 = MTIVLOTSTS_TO.QTY_3;			
		}
		else
		{
			MTIVMATUSE.QTY_1 = MTIVLOTSTS_TO.QTY_1;
			MTIVMATUSE.QTY_2 = MTIVLOTSTS_TO.QTY_2;
			MTIVMATUSE.QTY_3 = MTIVLOTSTS_TO.QTY_3;
		}
	}

	if (TRS.get_int(in_node, "MAT_IN_HIST_SEQ") > 0)
	{
		MTIVMATUSE.HIST_SEQ = TRS.get_int(in_node, "MAT_IN_HIST_SEQ");
	}
	 	  
	if (TRS.get_char(in_node, "ADJUST_FLAG") == 'Y' && c_i_or_u == 'U')
	{
		MTIVMATUSE.INPUT_QTY_1 += TRS.get_double(in_node, "INPUT_QTY_1");
		MTIVMATUSE.INPUT_QTY_2 += TRS.get_double(in_node, "INPUT_QTY_2");
		MTIVMATUSE.INPUT_QTY_3 += TRS.get_double(in_node, "INPUT_QTY_3");
	}
	else
	{
		MTIVMATUSE.INPUT_QTY_1 = TRS.get_double(in_node, "INPUT_QTY_1");
		MTIVMATUSE.INPUT_QTY_2 = TRS.get_double(in_node, "INPUT_QTY_2");
		MTIVMATUSE.INPUT_QTY_3 = TRS.get_double(in_node, "INPUT_QTY_3");
	}

	TRS.copy(MTIVMATUSE.FACTORY, sizeof(MTIVMATUSE.FACTORY), in_node, IN_FACTORY);
	MTIVMATUSE.WIP_OR_INV = c_wip_or_tiv;
	TRS.copy(MTIVMATUSE.LOT_ID, sizeof(MTIVMATUSE.LOT_ID), in_node, "TO_LOT_ID");

	MTIVMATUSE.INPUT_TYPE = 'I';
	memcpy(MTIVMATUSE.INPUT_LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	memcpy(MTIVMATUSE.INPUT_MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	MTIVMATUSE.INPUT_MAT_VER = MTIVLOTSTS.MAT_VER;
	//memcpy(MTIVMATUSE.INPUT_FLOW, MTIVLOTSTS.FLOW, sizeof(MTIVLOTSTS.FLOW));
	memcpy(MTIVMATUSE.INPUT_OPER, MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
	MTIVMATUSE.INPUT_HIST_SEQ = MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ;
	

	TRS.copy(MTIVMATUSE.TRAN_CODE, sizeof(MTIVMATUSE.TRAN_CODE), in_node, "TRAN_CODE");
	TRS.copy(MTIVMATUSE.WORK_DATE, sizeof(MTIVMATUSE.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(MTIVMATUSE.SHIFT, sizeof(MTIVMATUSE.SHIFT), in_node, "SHIFT");
	
	TRS.copy(MTIVMATUSE.TRAN_USER_ID, sizeof(MTIVMATUSE.TRAN_USER_ID), in_node, "PRC_USER");
	TRS.copy(MTIVMATUSE.TRAN_TIME, sizeof(MTIVMATUSE.TRAN_TIME), in_node, "__ERP_TRAN_TIME");
	TRS.copy(MTIVMATUSE.ORDER_ID, sizeof(MTIVMATUSE.ORDER_ID), in_node, "ORDER_ID");
	MTIVMATUSE.USE_FLAG_1 = TRS.get_char(in_node, "USE_FLAG_1");
	MTIVMATUSE.USE_FLAG_2 = TRS.get_char(in_node, "USE_FLAG_2");
	MTIVMATUSE.USE_FLAG_3 = TRS.get_char(in_node, "USE_FLAG_3");
	MTIVMATUSE.USE_FLAG_4 = TRS.get_char(in_node, "USE_FLAG_4");
	MTIVMATUSE.USE_FLAG_5 = TRS.get_char(in_node, "USE_FLAG_5");
	TRS.copy(MTIVMATUSE.USE_CMF_1, sizeof(MTIVMATUSE.USE_CMF_1), in_node, "__SYS_TIME");
	TRS.copy(MTIVMATUSE.USE_CMF_2, sizeof(MTIVMATUSE.USE_CMF_2), in_node, "USE_CMF_2");
	TRS.copy(MTIVMATUSE.USE_CMF_3, sizeof(MTIVMATUSE.USE_CMF_3), in_node, "USE_CMF_3");
	TRS.copy(MTIVMATUSE.USE_CMF_4, sizeof(MTIVMATUSE.USE_CMF_4), in_node, "USE_CMF_4");
	TRS.copy(MTIVMATUSE.USE_CMF_5, sizeof(MTIVMATUSE.USE_CMF_5), in_node, "USE_CMF_5");
	TRS.copy(MTIVMATUSE.USE_CMF_6, sizeof(MTIVMATUSE.USE_CMF_6), in_node, "USE_CMF_6");
	TRS.copy(MTIVMATUSE.USE_CMF_7, sizeof(MTIVMATUSE.USE_CMF_7), in_node, "USE_CMF_7");
	TRS.copy(MTIVMATUSE.USE_CMF_8, sizeof(MTIVMATUSE.USE_CMF_8), in_node, "USE_CMF_8");
	TRS.copy(MTIVMATUSE.USE_CMF_9, sizeof(MTIVMATUSE.USE_CMF_9), in_node, "USE_CMF_9");
	TRS.copy(MTIVMATUSE.USE_CMF_10, sizeof(MTIVMATUSE.USE_CMF_10), in_node, "USE_CMF_10");
  
	if (c_i_or_u == 'I')
	{
		DBC_insert_mtivmatuse(&MTIVMATUSE); 
	}
	else
	{
		DBC_update_mtivmatuse(1, &MTIVMATUSE); 
	}          
    if(DB_error_code != DB_SUCCESS) 
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVMATUSE INSERT/UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR,  sizeof(MTIVMATUSE.FACTORY), MTIVMATUSE.FACTORY);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVMATUSE.LOT_ID), MTIVMATUSE.LOT_ID);
		TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, MTIVMATUSE.HIST_SEQ);
		TRS.add_fieldmsg(out_node, "INPUT_LOT_ID", MP_STR,  sizeof(MTIVMATUSE.INPUT_LOT_ID), MTIVMATUSE.INPUT_LOT_ID);
            
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	 
    return MP_TRUE;
}



int TIV_check_backtime(char *s_msg_code, TRSNode *in_node, TRSNode *out_node, char *s_last_tran_time_t)
{
    char s_last_tran_time[14];
    char s_backtime[14];
    char s_sys_time[14];

    COM_memcpy(s_last_tran_time, s_last_tran_time_t, sizeof(s_last_tran_time));
    TRS.copy(s_backtime, sizeof(s_backtime), in_node, "BACK_TIME");

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    if(COM_isspace(s_backtime, 14) == MP_FALSE)
    {
        if(COM_compare_global_option(TRS.get_factory(in_node), 
                                     MP_OPTION_USE_BACK_DATE, 
                                     'Y') == MP_TRUE)
        {
            /* Back Time을 사용하는 경우 */
            if(COM_isdatetime(s_backtime) == MP_FALSE)
            {
                strcpy(s_msg_code, "WIP-0118");
                TRS.add_fieldmsg(out_node, "BACK_TIME", MP_STR, sizeof(s_backtime), s_backtime);
                TRS.add_fieldmsg(out_node, "FORMAT", MP_NSTR, "YYYYMMDD24HHMISS");

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }

            if(COM_compare_global_option(TRS.get_factory(in_node), 
                                         MP_OPTION_ALLOW_FUTURE_DATETIME, 
                                         'Y') != MP_TRUE)
            {
                /* Back Time은 현재 시간보다 미래 일수 없다. */
                if(memcmp(s_backtime, s_sys_time, 14) > 0)
                {
                    strcpy(s_msg_code, "WIP-0384");
                    TRS.add_fieldmsg(out_node, "SYSTEM_TIME", MP_STR, 14, s_sys_time);
                    TRS.add_fieldmsg(out_node, "BACK_TIME", MP_STR, 14, s_backtime);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_VALIDATION;
                    gs_log_type.category = MP_LOG_CATE_COMMON;
                    return MP_FALSE;
                }
            }

            /* Back Time은 마지막 진행 시간보다 과거일수 없다. */
            if(memcmp(s_last_tran_time, s_backtime, 14) > 0)
            {
                strcpy(s_msg_code, "WIP-0068");
                TRS.add_fieldmsg(out_node, "LAST_TRAN_TIME", MP_STR, 14, s_last_tran_time);
                TRS.add_fieldmsg(out_node, "BACK_TIME", MP_STR, 14, s_backtime);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
        }
        else
        {
            /* Back Time을 사용하지 않는 경우 */
            /* 입력된 Back Time을 무시하도록 값을 지워주고 현재 시간과 마지막 시간에 대해서만 체크한다. */
            TRS.set_nstring(in_node, "BACK_TIME", "");

            /* 현재 시간은 마지막 진행 시간보다 과거일수 없다. */
            if(memcmp(s_sys_time, s_last_tran_time, 14) < 0)
            {
                strcpy(s_msg_code, "WIP-0068");
                TRS.add_fieldmsg(out_node, "LAST_TRAN_TIME", MP_STR, 14, s_last_tran_time);
                TRS.add_fieldmsg(out_node, "SYSTEM_TIME", MP_STR, 14, s_sys_time);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
            }
        }
    } 
    else
    {
        /* 현재 시간은 마지막 진행 시간보다 과거일수 없다. */
        if(memcmp(s_sys_time, s_last_tran_time, 14) < 0)
        {
            strcpy(s_msg_code, "WIP-0068");
            TRS.add_fieldmsg(out_node, "LAST_TRAN_TIME", MP_STR, 14, s_last_tran_time);
            TRS.add_fieldmsg(out_node, "SYSTEM_TIME", MP_STR, 14, s_sys_time);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_COMMON;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

int TIV_Get_Lot_Count_In_Other_Oper(char *s_msg_code, 
	                    char *s_factory,
						char *s_lot_id,
						char *s_oper)
{
	struct MTIVLOTSTS_TAG MTIVLOTSTS;

	char factory[10];
	char lot_id[25];
	char oper[10];
	
	int i_lot_count = 0;;

	memset(factory,' ', sizeof(factory));
	memset(lot_id,' ', sizeof(lot_id));
	memset(oper,' ', sizeof(oper));

	memcpy(factory, s_factory, sizeof(factory));
	memcpy(lot_id, s_lot_id, sizeof(lot_id));
	memcpy(oper, s_oper, sizeof(oper));

	DBC_init_mtivlotsts(&MTIVLOTSTS);
	memcpy(MTIVLOTSTS.FACTORY, factory, sizeof(MTIVLOTSTS.FACTORY));
	memcpy(MTIVLOTSTS.LOT_ID, lot_id, sizeof(MTIVLOTSTS.LOT_ID));
	memcpy(MTIVLOTSTS.OPER, oper, sizeof(MTIVLOTSTS.OPER));
	MTIVLOTSTS.LOT_DEL_FLAG = ' ';

	i_lot_count = (int)DBC_select_mtivlotsts_scalar(13, &MTIVLOTSTS);
	
	return i_lot_count;
}