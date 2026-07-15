/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_inspection_data_cell.c
    Description : EAPMES Collect Inspection Data for Cell Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Inspection_Data_Cell()
            + Setup service interface function
        - EAPMES_COLLECT_INSPECTION_DATA_CELL()
            + Main sub function of EAPMES_Collect_Inspection_Data_Cell function
            + Setup service main business function
        - EAPMES_Collect_Inspection_Data_Cell_Validation()
            + Main sub function of EAPMES_COLLECT_INSPECTION_DATA_CELL function
    Detail Description
        - EAPMES_COLLECT_INSPECTION_DATA_CELL()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Inspection_Data_Cell_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_TABBER_INSPECTION_CELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Cell()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Cell(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_INSPECTION_DATA_CELL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_INSPECTION_DATA_CELL", out_node);

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

    /* Temp */
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "CELL_ID", TRS.get_string(in_node, "CELL_ID"));
    TRS.set_nstring(out_node, "LAMA_ID", TRS.get_string(in_node, "LAMA_ID"));
    TRS.set_nstring(out_node, "REASON_CODE", TRS.get_string(in_node, "REASON_CODE"));
    TRS.set_nstring(out_node, "VMAGAZINE_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Inspection_Data_Cell", 
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
    //CEIS_Save_Message_Log_For_List(in_node, out_node);
    CEIS_Save_Message_Log_For_Single_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_INSPECTION_DATA_CELL()
        - Main sub function of "EAPMES_Collect_Inspection_Data_Cell" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_INSPECTION_DATA_CELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CEDCINSDAT_TAG CEDCINSDAT;
	struct MRASRESDEF_TAG MRASRESDEF;
	
    char s_sys_time_stamp[20];  
    char s_sys_time[17];
    int  j;
    double d_max_seq_num;

    int i_param_item_count;

    TRSNode ** PARAM_ITEM;

    LOG_head("EAPMES_COLLECT_INSPECTION_DATA_CELL");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  

    DB_get_systime_m(s_sys_time_stamp);
    if(DB_error_code != DB_SUCCESS)
    {
        TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));


    /* 1. Parameter Item */
    /* Save All Parameter Data */
    /* Lot Information */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "CELL_ID");
            
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{

		}
        else
        {

        }
    }

	/*MFO get Oper */
	DBC_init_mrasresdef(&MRASRESDEF);
    TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
    TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
            
    DBC_select_mrasresdef(1, &MRASRESDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{

		}
        else
        {

        }
    }

    PARAM_ITEM = TRS.get_list(in_node, "PARAM_ITEM");
    i_param_item_count = TRS.get_item_count(in_node, "PARAM_ITEM");

    for(j = 0; j < i_param_item_count; j++)
    {
        /* Get Max Sequence */
        d_max_seq_num = 0;
        CDB_init_cedcinsdat(&CEDCINSDAT);
        TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "CELL_ID");
        TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
        //memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CEDCINSDAT.TRAN_TIME, sizeof(CEDCINSDAT.TRAN_TIME), in_node, "CLIENT_TIME");
        
		d_max_seq_num = CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);
        
		if(DB_error_code != DB_SUCCESS)
        {
            //return MP_TRUE;
        }

        /* Insert */
        CDB_init_cedcinsdat(&CEDCINSDAT);
        TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "CELL_ID");
        TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
        memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CEDCINSDAT.TRAN_TIME, sizeof(CEDCINSDAT.TRAN_TIME), in_node, "CLIENT_TIME");
        CEDCINSDAT.SEQ_NUM = ++d_max_seq_num;
        TRS.copy(CEDCINSDAT.FACTORY, sizeof(CEDCINSDAT.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CEDCINSDAT.LINE_ID, sizeof(CEDCINSDAT.LINE_ID), in_node, "LINE_ID");
		memcpy(CEDCINSDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCINSDAT.OPER));
        CEDCINSDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

        TRS.copy(CEDCINSDAT.PARAM_NAME, sizeof(CEDCINSDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
        TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");

        CDB_insert_cedcinsdat(&CEDCINSDAT);
        if(DB_error_code != DB_SUCCESS)
        {
                
        }
    }

    /* Save inspection data even if there are errors beyond this point */
    DB_commit();

    if(EAPMES_Collect_Inspection_Data_Cell_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* To Do */
	if(CWIP_TABBER_INSPECTION_CELL(s_msg_code, in_node,out_node) == MP_FALSE)
	{
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_TRUE;
	} 

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Cell_Validation()
        - Main sub function of "EAPMES_COLLECT_INSPECTION_DATA_CELL" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Cell_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

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


    return MP_TRUE;
}

