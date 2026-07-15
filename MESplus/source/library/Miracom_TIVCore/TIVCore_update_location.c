/*******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : TIV_Update_Location.c
    Description : Transaction change location function module

    MES Version : 5.2.0

    Function List
        - TIV_Update_Location()
            + Transaction In Lot Material Inventory
        - TIV_UPDATE_LOCATION()
            + Main Sub function of "TIV_Update_Location"
            + (called by "TIV_Update_Location")
        - TIV_Update_Location_Validation()
            + Validation Check sub function of "TIV_UPDATE_LOCATION" function
            + (called by "TIV_UPDATE_LOCATION")
       
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/07/25  Patrick         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_Update_Location_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node);


/*******************************************************************************
    TIV_Update_Location()
        - Lot Material In Inventory
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TIV_Update_Location_In_Tag *TIV_Update_Location_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Update_Location(TRSNode *in_node, 
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_UPDATE_LOCATION(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_UPDATE_LOCATION", out_node);

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
    TIV_UPDATE_LOCATION()
        - Main sub function of "TIV_Update_Location" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_UPDATE_LOCATION_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_UPDATE_LOCATION(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node)

{	
	struct MTIVLOTSTS_TAG MTIVLOTSTS;
	struct MTIVLOTHIS_TAG MTIVLOTHIS;

    char s_sys_time[14];     		

    LOG_head("TIV_UPDATE_LOCATION");
    COM_log_add_field_msg(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);    

    memset(s_sys_time, ' ', sizeof(s_sys_time));

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

	/*' Validation Check*/
    if(TIV_Update_Location_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));		
        return MP_FALSE;
    }	

	if(TRS.get_procstep(in_node) == '1')
	{		
		if(Fill_TIV_Lot_STSHIS_For_Update(TRS.get_string(in_node, "LOT_ID"), in_node, out_node,
											&MTIVLOTSTS, &MTIVLOTHIS) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));		
			return MP_FALSE;
		}	
		
		TRS.copy(MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO), in_node, "TO_LOCATION_NO");		

		DBC_update_mtivlotsts(1, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{			
			memcpy(s_msg_code, "WIP-0004", strlen("WIP-0004"));
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);			

			TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		TRS.copy(MTIVLOTHIS.LOCATION_NO, sizeof(MTIVLOTHIS.LOCATION_NO), in_node, "TO_LOCATION_NO");

		DBC_update_mtivlothis(1, &MTIVLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{			
			memcpy(s_msg_code, "WIP-0004", strlen("WIP-0004"));
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);			

			TRS.add_fieldmsg(out_node, "MTIVLOTHIS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTHIS.OPER), MTIVLOTHIS.OPER);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

	}
     
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_Update_Location_Validation()
        - Validation Check sub function of "TIV_UPDATE_LOCATION" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_UPDATE_LOCATION_IN_TAG *In_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Update_Location_Validation(char *s_msg_code,
                               TRSNode *in_node, 
                               TRSNode *out_node)
{    
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
    
    return MP_TRUE;
}
