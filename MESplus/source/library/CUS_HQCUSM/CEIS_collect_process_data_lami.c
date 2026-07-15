/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_process_data_lami.c
    Description : EAPMES Collect Process Data For LAMI Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Process_Data_LAMI()
            + Setup service interface function
        - EAPMES_COLLECT_PROCESS_DATA_LAMI()
            + Main sub function of EAPMES_Collect_Process_Data_LAMI function
            + Setup service main business function
        - EAPMES_Collect_Process_Data_LAMI_Validation()
            + Main sub function of EAPMES_COLLECT_PROCESS_DATA_LAMI function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_COLLECT_PROCESS_DATA_LAMI()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "SPCCore_common.h"

int EAPMES_Collect_Process_Data_LAMI_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Process_Data_LAMI()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_LAMI(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");
	//i_ret == MP_FALSE;
    i_ret = EAPMES_COLLECT_PROCESS_DATA_LAMI(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_PROCESS_DATA_LAMI", out_node);

	//i_ret == MP_FALSE;
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

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	/***
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Process_Data_LAMI", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}
	***/

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    //CEIS_Save_Message_Log(in_node, out_node);
    CEIS_Save_Message_Log_For_List(in_node, out_node);


	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_PROCESS_DATA_LAMI()
        - Main sub function of "EAPMES_Collect_Process_Data_LAMI" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_PROCESS_DATA_LAMI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CRASPRCDAT_TAG CRASPRCDAT;
	struct MRASRESDEF_TAG MRASRESDEF;

    char s_sys_time_stamp[20];  
    char s_sys_time[17];
	char s_last_lot_id[25];
    int i, j;
    double d_max_seq_num;

    int i_param_list_count;
    int i_param_item_count;

	char c_eq_spc_flag = 'N';
	char c_spc_collect_flag = 'N';
	struct MSPCCHTDEF_TAG MSPCCHTDEF;
	
    TRSNode ** PARAM_LIST;
    TRSNode ** PARAM_ITEM;

    /*init CRASPRCDAT*/
	TRSNode *ras_tran_in_node;
	TRSNode *ras_param_list;
	TRSNode *ras_param_item;
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

	LOG_head("EAPMES_COLLECT_PROCESS_DATA_LAMI");
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

	//0. 설비 ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.free_node(ras_tran_in_node);
		return MP_FALSE;
	}

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));

	//SPC CHART DATA
	c_eq_spc_flag = 'N';
	{
		
		DBC_init_mspcchtdef(&MSPCCHTDEF);
		memcpy(MSPCCHTDEF.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
		memcpy(MSPCCHTDEF.RES_ID, MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
		if (DBC_select_mspcchtdef_scalar(101, &MSPCCHTDEF) > 0)
		{
			c_eq_spc_flag = 'Y';
		}
	}


    /* 1. Parameter List */
    /* Save All Parameter Data */
    PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");

    for(i = 0; i < i_param_list_count; i++)
    {
        /* Lot Information */
		memset(s_last_lot_id, ' ', sizeof(s_last_lot_id));
        DBC_init_mwiplotsts(&MWIPLOTSTS);
        TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
            
        DBC_select_mwiplotsts(1, &MWIPLOTSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
        }
		if (COM_isspace(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID)) == MP_TRUE)
		{
			//해당 설비의 마지막 시작한 LOT 이 있으면 해당 LOT ID 가 있으면 가져옮
			
			TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, "FACTORY");
			//memcpy(MWIPLOTSTS.OPER, MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2)); // Server Crash 190925
			memcpy(MWIPLOTSTS.OPER, MRASRESDEF.RES_CMF_2, sizeof(MWIPLOTSTS.OPER)); 
			MWIPLOTSTS.START_FLAG = 'Y';
			//memcpy(MWIPLOTSTS.START_RES_ID, MRASRESDEF.RES_CMF_3, sizeof(MRASRESDEF.RES_CMF_3)); // Server Crash 190925
			memcpy(MWIPLOTSTS.START_RES_ID, MRASRESDEF.RES_CMF_3, sizeof(MWIPLOTSTS.START_RES_ID)); 
			CDB_select_mwiplotsts(8, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
			else
			{
				memcpy(s_last_lot_id, MWIPLOTSTS.LOT_ID, sizeof(s_last_lot_id));
			}
		}
		else
		{
			memcpy(s_last_lot_id, MWIPLOTSTS.LOT_ID, sizeof(s_last_lot_id));
		}

        PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
        i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");

        for(j = 0; j < i_param_item_count; j++)
        {

			//LOT ID 를 넘겨주는 파라메터.
			if (( strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_CO_MODULE_ID_1") == 0) ||
				( strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_PL_MODULE_ID_1") == 0) ||
				( strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_PHL_MODULE_ID_1") == 0) ||
				( strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_FL_MODULE_ID_1") == 0))
			{
				TRS.copy(s_last_lot_id,  sizeof(s_last_lot_id), PARAM_ITEM[j], "PARAM_VALUE");
			}

            /* Get Max Sequence */
			/*  Change 'Get Max Sequence' to comment and use Oracle sequence
            d_max_seq_num = 0;
            CDB_init_crasprcdat(&CRASPRCDAT);
            //TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
			memcpy(CRASPRCDAT.LOT_ID, s_last_lot_id, sizeof(s_last_lot_id));
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
            memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
			TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            d_max_seq_num = CDB_select_crasprcdat_scalar(2, &CRASPRCDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }
			*/

            /* Insert */
            CDB_init_crasprcdat(&CRASPRCDAT);
            //TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
			memcpy(CRASPRCDAT.LOT_ID, s_last_lot_id, sizeof(s_last_lot_id));
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
            memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
            //CRASPRCDAT.SEQ_NUM = ++d_max_seq_num;
            TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), in_node, "LINE_ID");
            memcpy(CRASPRCDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CRASPRCDAT.OPER));
            CRASPRCDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

            TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
			//값이 없으면 저장안함. 데이터가 너무많음.
			memcpy(CRASPRCDAT.CREATE_TIME, CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.CREATE_TIME));

			if (COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) == MP_TRUE)
			{
				continue;
			}
            /*
			CDB_insert_crasprcdat_use_sequence(&CRASPRCDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                
            }
			*/
			/*if empty CRASPRCDAT*/
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

			//SPC 대상 PARAMETER CHECK ( TEMP TABLE 에 INSERT 하고 BATCH 가 처리함.)
			c_spc_collect_flag = 'N';
			if (c_eq_spc_flag == 'Y')
			{
				DBC_init_mspcchtdef(&MSPCCHTDEF);
				memcpy(MSPCCHTDEF.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
				memcpy(MSPCCHTDEF.RES_ID, MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
				memcpy(MSPCCHTDEF.CHAR_ID, CRASPRCDAT.PARAM_NAME, sizeof(MSPCCHTDEF.CHAR_ID));
				/*if (DBC_select_mspcchtdef_scalar(102, &MSPCCHTDEF) > 0)
				{
					c_spc_collect_flag = 'Y';
				}*/
				DBC_select_mspcchtdef(101, &MSPCCHTDEF) ;
				if(DB_error_code == DB_SUCCESS)
				{
					c_spc_collect_flag = 'Y';
				}
			}

			//SPC 수집.
			if (c_spc_collect_flag == 'Y')
			{
				//직접수행에서 BATCH SERVER 로 변경함.
				struct CTMPSPCDAT_TAG CTMPSPCDAT;

				CDB_init_ctmpspcdat(&CTMPSPCDAT);
				memcpy(CTMPSPCDAT.LOT_ID, CRASPRCDAT.LOT_ID, sizeof(CTMPSPCDAT.LOT_ID));
				memcpy(CTMPSPCDAT.RES_ID, CRASPRCDAT.RES_ID, sizeof(CTMPSPCDAT.RES_ID));
				memcpy(CTMPSPCDAT.TRAN_TIME, CRASPRCDAT.TRAN_TIME, sizeof(CTMPSPCDAT.TRAN_TIME));
				CTMPSPCDAT.SEQ_NUM = CRASPRCDAT.SEQ_NUM;
				memcpy(CTMPSPCDAT.FACTORY, CRASPRCDAT.FACTORY, sizeof(CTMPSPCDAT.FACTORY));
				memcpy(CTMPSPCDAT.LINE_ID, CRASPRCDAT.LINE_ID, sizeof(CTMPSPCDAT.LINE_ID));
				memcpy(CTMPSPCDAT.OPER, CRASPRCDAT.OPER, sizeof(CTMPSPCDAT.OPER));
				CTMPSPCDAT.LOT_HIST_SEQ = CRASPRCDAT.LOT_HIST_SEQ;
				memcpy(CTMPSPCDAT.PARAM_NAME, CRASPRCDAT.PARAM_NAME, sizeof(CTMPSPCDAT.PARAM_NAME));
				memcpy(CTMPSPCDAT.PARAM_VALUE, CRASPRCDAT.PARAM_VALUE, sizeof(CTMPSPCDAT.PARAM_VALUE));
				memcpy(CTMPSPCDAT.CHART_ID, MSPCCHTDEF.CHART_ID, sizeof(MSPCCHTDEF.CHART_ID));
				CDB_insert_ctmpspcdat(&CTMPSPCDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NTOHING
				}
			}

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
    //DB_commit();

    if(EAPMES_Collect_Process_Data_LAMI_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        //return MP_FALSE;
    }


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Process_Data_LAMI_Validation()
        - Main sub function of "EAPMES_COLLECT_PROCESS_DATA_LAMI" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_LAMI_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

