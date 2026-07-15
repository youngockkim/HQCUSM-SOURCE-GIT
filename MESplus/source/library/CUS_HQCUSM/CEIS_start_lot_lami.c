/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_start_lot_lami.c
    Description : EAPMES Start Lot for LAMI Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Start_Lot_LAMI()
            + Setup service interface function
        - EAPMES_START_LOT_LAMI()
            + Main sub function of EAPMES_Start_Lot_LAMI function
            + Setup service main business function
        - EAPMES_Start_Lot_LAMI_Validation()
            + Main sub function of EAPMES_START_LOT_LAMI function
    Detail Description
        - EAPMES_START_LOT_LAMI()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Start_Lot_LAMI_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Start_Lot_LAMI()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Start_Lot_LAMI(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_START_LOT_LAMI(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_START_LOT_LAMI", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
    TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Start_Lot_LAMI", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log_For_Single_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_START_LOT_LAMI()
        - Main sub function of "EAPMES_Start_Lot_LAMI" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_START_LOT_LAMI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPLOTRAM_TAG CWIPLOTRAM;
    
    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    TRSNode ** LOT_ITEM;
    int i_lot_item_count;
    int i;

	char   s_sys_time[14];
	char   s_res_id[20];
	
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(s_res_id, ' ', sizeof(s_res_id));

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    LOG_head("EAPMES_START_LOT_LAMI");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if (COM_isnullspace(TRS.get_string(in_node, "FACTORY")) == MP_TRUE)
	{
		TRS.set_nstring(in_node, "FACTORY", HQCEL_M1_DEFAULT_FACTORY);
	}

    if(EAPMES_Start_Lot_LAMI_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    LOT_ITEM = TRS.get_list(in_node, "LOT_ITEM");
    i_lot_item_count = TRS.get_item_count(in_node, "LOT_ITEM");

    for(i = 0; i < i_lot_item_count; i++)
    {
        /* Get Lot Info */
        DBC_init_mwiplotsts(&MWIPLOTSTS);
        TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), LOT_ITEM[i], "LOT_ID");
        DBC_select_mwiplotsts(1, &MWIPLOTSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0044");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Start Lot */
        if (MWIPLOTSTS.START_FLAG != 'Y')
        {
            tran_in_node = TRS.create_node("START_LOT_IN");
            tran_out_node = TRS.create_node("START_LOT_OUT");

            CCOM_copy_in_node(in_node, tran_in_node);
	        TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
	        TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(LOT_ITEM[i], "LOT_ID"));  
	        TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
	        TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER)); 
	        TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
  
            if(EAPMES_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	        {
                // Do Nothing
	        }
    
	        TRS.free_node(tran_in_node);
            TRS.free_node(tran_out_node);
        }

		/*Laminator Chamber IS-20-12-058*/
		/* Get Lot Info */
        CDB_init_cwiplotram(&CWIPLOTRAM);
        TRS.copy(CWIPLOTRAM.FACTORY, sizeof(CWIPLOTRAM.FACTORY), in_node, "FACTORY");
        TRS.copy(CWIPLOTRAM.LOT_ID, sizeof(CWIPLOTRAM.LOT_ID), LOT_ITEM[i], "LOT_ID");
        //memcpy(CWIPLOTRAM.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(CWIPLOTRAM.ORDER_ID));IS-21-01-094 MES logic °³¼±
		memcpy(CWIPLOTRAM.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		TRS.copy(CWIPLOTRAM.LINE_ID, sizeof(CWIPLOTRAM.LOT_ID), in_node, "LINE_ID");
        
		TRS.copy(s_res_id, sizeof(CWIPLOTRAM.RES_ID), in_node, "RES_ID");
		TRS.copy(CWIPLOTRAM.RES_ID, sizeof(CWIPLOTRAM.RES_ID), in_node, "RES_ID");
		memcpy(CWIPLOTRAM.RES_ID+6, "LAM-00", strlen("LAM-00"));
		CWIPLOTRAM.RES_ID[10] = s_res_id[ 9];
		CWIPLOTRAM.RES_ID[11] = s_res_id[10];
		
		CDB_select_cwiplotram(1, &CWIPLOTRAM);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
				memcpy(CWIPLOTRAM.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
				CDB_insert_cwiplotram(&CWIPLOTRAM);
            }
            else
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }
        }

		if(s_res_id[6] == 'P' && s_res_id[7] == 'H')
		{
			memcpy(CWIPLOTRAM.PH_START_TIME, s_sys_time, sizeof(s_sys_time));
		}
		if(s_res_id[6] == 'L' && s_res_id[7] == 'F')
		{
			memcpy(CWIPLOTRAM.LF_START_TIME, s_sys_time, sizeof(s_sys_time));
		}
		if(s_res_id[6] == 'L' && s_res_id[7] == 'P')
		{
			memcpy(CWIPLOTRAM.LP_START_TIME, s_sys_time, sizeof(s_sys_time));
		}
		if(s_res_id[6] == 'L' && s_res_id[7] == 'C')
		{
			memcpy(CWIPLOTRAM.LC_START_TIME, s_sys_time, sizeof(s_sys_time));
		}

		memcpy(CWIPLOTRAM.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
				
		CDB_update_cwiplotram(1,&CWIPLOTRAM);
		if(DB_error_code != DB_SUCCESS)
        {
			//Do Nothing
		}
    }


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Start_Lot_LAMI_Validation()
        - Main sub function of "EAPMES_START_LOT_LAMI" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Start_Lot_LAMI_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
//    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    /*
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }
    */

    return MP_TRUE;
}




