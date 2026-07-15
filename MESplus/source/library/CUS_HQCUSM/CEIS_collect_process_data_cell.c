/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_process_data_cell.c
    Description : EAPMES Collect Process Data for Cell Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Process_Data_Cell()
            + Setup service interface function
        - EAPMES_COLLECT_PROCESS_DATA_CELL()
            + Main sub function of EAPMES_Collect_Process_Data_Cell function
            + Setup service main business function
        - EAPMES_Collect_Process_Data_Cell_Validation()
            + Main sub function of EAPMES_COLLECT_PROCESS_DATA_CELL function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_COLLECT_PROCESS_DATA_CELL()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Process_Data_Cell_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Process_Data_Cell()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_Cell(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_PROCESS_DATA_CELL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_PROCESS_DATA_CELL", out_node);

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
    TRS.set_nstring(out_node, "VMAGAZINE_ID", TRS.get_string(in_node, "VMAGAZINE_ID"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));
    TRS.set_nstring(out_node, "CELL_TYPE", TRS.get_string(in_node, "CELL_TYPE"));
    TRS.set_nstring(out_node, "CELL_ID", TRS.get_string(in_node, "CELL_ID"));
    TRS.set_nstring(out_node, "LAMA_ID", TRS.get_string(in_node, "LAMA_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Process_Data_Cell", 
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
    EAPMES_COLLECT_PROCESS_DATA_CELL()
        - Main sub function of "EAPMES_Collect_Process_Data_Cell" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_PROCESS_DATA_CELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CRASPRCDAT_TAG CRASPRCDAT;
	struct MRASRESDEF_TAG MRASRESDEF;

    char s_sys_time_stamp[20];  
    char s_sys_time[17];
    int j;
    double d_max_seq_num;

    int i_param_item_count;

    TRSNode ** PARAM_ITEM;
	/*init CRASPRCDAT*/
	TRSNode * ras_tran_in_node;
	TRSNode * ras_param_list;
	TRSNode * ras_param_item;
	int send_data_count = 0;

	ras_tran_in_node = TRS.create_node("RAS_PARAM_IN");
	CCOM_copy_in_node(in_node, ras_tran_in_node);
	TRS.add_char(ras_tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(ras_tran_in_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(ras_tran_in_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(ras_tran_in_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(ras_tran_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(ras_tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
	TRS.set_nstring(ras_tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_nstring(ras_tran_in_node, "PALLET_ID", TRS.get_string(in_node, "PALLET_ID"));
    TRS.set_nstring(ras_tran_in_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
	ras_param_list = TRS.add_node(ras_tran_in_node, "PARAM_LIST");

    LOG_head("EAPMES_COLLECT_PROCESS_DATA_CELL");
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
        TRS.free_node(ras_tran_in_node);
		return MP_FALSE;
    }

	/* Check Resource */
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		//DO NOTHING
	}
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));


    /* 1. Parameter List */
    /* Save All Parameter Data */
    /* Lot Information */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    //TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
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

    PARAM_ITEM = TRS.get_list(in_node, "PARAM_ITEM");
    i_param_item_count = TRS.get_item_count(in_node, "PARAM_ITEM");

    for(j = 0; j < i_param_item_count; j++)
    {
        /* Get Max Sequence */
        d_max_seq_num = 0;
        CDB_init_crasprcdat(&CRASPRCDAT);
        //TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
		memcpy(CRASPRCDAT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CRASPRCDAT.LOT_ID));
        TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
        memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");

        d_max_seq_num = CDB_select_crasprcdat_scalar(2, &CRASPRCDAT);
        if(DB_error_code != DB_SUCCESS)
        {
            //return MP_TRUE;
        }

        /* Insert */
        CDB_init_crasprcdat(&CRASPRCDAT);
        //TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
		memcpy(CRASPRCDAT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CRASPRCDAT.LOT_ID));
        TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
        memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
        CRASPRCDAT.SEQ_NUM = ++d_max_seq_num;
        TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), in_node, "LINE_ID");
        
		memcpy(CRASPRCDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CRASPRCDAT.OPER));

        CRASPRCDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

        TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
        TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
		TRS.copy(CRASPRCDAT.CMF_1, sizeof(CRASPRCDAT.CMF_1), in_node, "LAMA_ID");
		TRS.copy(CRASPRCDAT.CMF_2, sizeof(CRASPRCDAT.CMF_2), in_node, "LOC_ID");
		TRS.copy(CRASPRCDAT.CMF_3, sizeof(CRASPRCDAT.CMF_3), in_node, "CELL_TYPE");
		TRS.copy(CRASPRCDAT.CMF_4, sizeof(CRASPRCDAT.CMF_4), in_node, "VMAGAZINE_ID");
		memcpy(CRASPRCDAT.CREATE_TIME, CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.CREATE_TIME));
		//값이 없으면 저장안함. 데이터가 너무많음.
		if (COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) == MP_TRUE)
		{
			continue;
		}
		/*
        CDB_insert_crasprcdat(&CRASPRCDAT);
        if(DB_error_code != DB_SUCCESS)
        {
                
        }
		*/
		//if empty CRASPRCDAT
		if(COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) == MP_FALSE)
		{
			ras_param_item = TRS.add_node(ras_param_list, "PARAM_ITEM");
			TRS.add_string(ras_param_item, "RES_ID", CRASPRCDAT.RES_ID , sizeof(CRASPRCDAT.RES_ID));
			TRS.add_string(ras_param_item, "PARAM_NAME", CRASPRCDAT.PARAM_NAME , sizeof(CRASPRCDAT.PARAM_NAME));
			TRS.add_string(ras_param_item, "TRAN_TIME", CRASPRCDAT.TRAN_TIME , sizeof(CRASPRCDAT.TRAN_TIME));
			TRS.add_string(ras_param_item, "LOT_ID", CRASPRCDAT.LOT_ID , sizeof(CRASPRCDAT.LOT_ID));
			TRS.add_int(ras_param_item, "SEQ_NUM", CRASPRCDAT.SEQ_NUM);
			TRS.add_string(ras_param_item, "FACTORY", CRASPRCDAT.FACTORY , sizeof(CRASPRCDAT.FACTORY));
			TRS.add_string(ras_param_item, "LINE_ID", CRASPRCDAT.LINE_ID , sizeof(CRASPRCDAT.LINE_ID));
			TRS.add_string(ras_param_item, "OPER", CRASPRCDAT.OPER , sizeof(CRASPRCDAT.OPER));
			TRS.add_int(ras_param_item, "LOT_HIST_SEQ", CRASPRCDAT.LOT_HIST_SEQ);
			TRS.add_string(ras_param_item, "PARAM_VALUE", CRASPRCDAT.PARAM_VALUE , sizeof(CRASPRCDAT.PARAM_VALUE));
			TRS.add_string(ras_param_item, "CREATE_TIME", CRASPRCDAT.CREATE_TIME , sizeof(CRASPRCDAT.CREATE_TIME));
			TRS.add_string(ras_param_item, "CMF_1", CRASPRCDAT.CMF_1 , sizeof(CRASPRCDAT.CMF_1));
			TRS.add_string(ras_param_item, "CMF_2", CRASPRCDAT.CMF_2 , sizeof(CRASPRCDAT.CMF_2));
			TRS.add_string(ras_param_item, "CMF_3", CRASPRCDAT.CMF_3 , sizeof(CRASPRCDAT.CMF_3));
			TRS.add_string(ras_param_item, "CMF_4", CRASPRCDAT.CMF_4 , sizeof(CRASPRCDAT.CMF_4));
			TRS.add_string(ras_param_item, "CMF_5", CRASPRCDAT.CMF_5 , sizeof(CRASPRCDAT.CMF_5));	
			send_data_count++;
		}
		//CEDCLOTDAT INSERT: 레포트에서 설비데이터 조회용 
		if (CCOM_COPY_FROM_PRCDATA_TO_LOTDATA (in_node, &CRASPRCDAT) == MP_FALSE)
		{
			//DO NOTHING
		}
    }
 
	/*CRASPRCDAT free*/
	if(send_data_count > 0)
	{
		if(COM_Guaranteed_CRASPRCDATA(s_msg_code,ras_tran_in_node) == MP_FALSE)
		{
			//DO NOTHING 
		}
	}
	TRS.free_node(ras_tran_in_node);

    /* Save inspection data even if there are errors beyond this point */
    DB_commit();

    if(EAPMES_Collect_Process_Data_Cell_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//Edit Inspection Node
	TRS.set_nstring(in_node, "RESULT", "OK"); // 0 :OK
	TRS.set_char(in_node, "REASON_CODE", '0'); // 0 :OK

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
    EAPMES_Collect_Process_Data_Cell_Validation()
        - Main sub function of "EAPMES_COLLECT_PROCESS_DATA_CELL" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_Cell_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

