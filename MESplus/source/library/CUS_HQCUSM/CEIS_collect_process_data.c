/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_process_data.c
    Description : EAPMES Collect Process Data Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Process_Data()
            + Setup service interface function
        - EAPMES_COLLECT_PROCESS_DATA()
            + Main sub function of EAPMES_Collect_Process_Data function
            + Setup service main business function
        - EAPMES_Collect_Process_Data_Validation()
            + Main sub function of EAPMES_COLLECT_PROCESS_DATA function
    Detail Description
        - EAPMES_COLLECT_PROCESS_DATA()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Process_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int Send_Material_Tracability_Data_Raw_Material(char* s_msg_code, struct CWIPLOTMAT_TAG* CWIPLOTMAT, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
    EAPMES_Collect_Process_Data()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
	
    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_PROCESS_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_PROCESS_DATA", out_node);

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
    TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_nstring(out_node, "PALLET_ID", TRS.get_string(in_node, "PALLET_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Process_Data", 
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
    //CEIS_Save_Message_Log(in_node, out_node);
    CEIS_Save_Message_Log_For_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_PROCESS_DATA()
        - Main sub function of "EAPMES_Collect_Process_Data" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_PROCESS_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	//struct MWIPLOTSTS_TAG MWIPLOTSTS_A;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_S;
    struct CWIPLOTMAT_TAG CWIPLOTMAT;
    struct CWIPORDBOM_TAG CWIPORDBOM;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct CRASPRCDAT_TAG CRASPRCDAT;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CRASRESMAH_TAG CRASRESMAH;
	struct CWIPACMHIS_TAG CWIPACMHIS;
	struct CWIPJBSLOS_TAG CWIPJBSLOS;
	struct CWIPTRPHIS_TAG CWIPTRPHIS;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct MWIPMATDEF_TAG MWIPMATDEF;  //IS-22-03-054 22.03.23
	struct CWIPTRPSTS_TAG CWIPTRPSTS;

	struct MWIPLOTSTS_TAG MWIPLOTSTS_PCU;   //26.01.13 add
	struct CWIPACMHIS_TAG CWIPACMHIS_PCU;   //26.01.13 add

    char s_sys_time_stamp[20];  
    char s_sys_time_17[17];

    char s_message[30];
    int i, j;
    double d_max_seq_num;

	int s_is_jb_sold = -1;

    int i_param_list_count;
    int i_param_item_count;

    TRSNode ** PARAM_LIST;
    TRSNode ** PARAM_ITEM;
    
	int i_mat_list_count;
    int i_mat_item_count;
	int ordbom_step = 1;
	int i_len;  //IS-22-03-054 22.03.23
	char i_mat_code[40]; //IS-22-03-054 22.03.23
	int pak_seq;


	TRSNode ** MAT_LIST;
    TRSNode ** MAT_ITEM;

	char c_lot_flag = 'N';
	char s_last_lot_id[25];

	char s_lot_id[18];
	char s_pcu_sn[12];
	//char s_acm_sn[31];

	char c_eq_spc_flag = 'N';
	char c_spc_collect_flag = 'N';
	struct MSPCCHTDEF_TAG MSPCCHTDEF;

	char MAT_GUBUN[2];		
	char OTHER_MAT_ID[13];

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
	

    
	LOG_head("EAPMES_COLLECT_PROCESS_DATA");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  
	memset(s_message, ' ', sizeof(s_message));

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

	memset(s_sys_time_17, ' ', sizeof(s_sys_time_17));
    memcpy(s_sys_time_17, s_sys_time_stamp, sizeof(s_sys_time_17));
	memset(s_last_lot_id, ' ', sizeof(s_last_lot_id));

	memset(s_lot_id, ' ', sizeof(s_lot_id));
	memset(s_pcu_sn, ' ', sizeof(s_pcu_sn));

	TRS.copy(s_lot_id, sizeof(s_lot_id), in_node, "LOT_ID");
	
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

	
	 if((memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE1_LCV21, strlen(HQCEL_M1_RES_LINE1_LCV21)) == 0  
				|| memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE2_LCV21, strlen(HQCEL_M1_RES_LINE2_LCV21)) == 0
				|| memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE3_LCV21, strlen(HQCEL_M1_RES_LINE3_LCV21)) == 0
				|| memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE1_LCV23, strlen(HQCEL_M1_RES_LINE1_LCV23)) == 0
				|| memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE2_LCV23, strlen(HQCEL_M1_RES_LINE2_LCV23)) == 0
				|| memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE3_LCV23, strlen(HQCEL_M1_RES_LINE3_LCV23)) == 0)){

				CDB_init_cwipjbslos(&CWIPJBSLOS);
				TRS.copy(CWIPJBSLOS.FACTORY, sizeof(CWIPJBSLOS.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPJBSLOS.LOT_ID, sizeof(CWIPJBSLOS.LOT_ID), in_node, "LOT_ID");
				memcpy(CWIPJBSLOS.TRAN_TIME, s_sys_time_17, 14);
				TRS.copy(CWIPJBSLOS.LINE_ID, sizeof(CWIPJBSLOS.LINE_ID), in_node, "LINE_ID");
				TRS.copy(CWIPJBSLOS.RES_ID, sizeof(CWIPJBSLOS.RES_ID), in_node, "RES_ID");

				memcpy(CWIPJBSLOS.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
				memcpy(CWIPJBSLOS.CREATE_TIME, s_sys_time_17, 14);
				memcpy(CWIPJBSLOS.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
				memcpy(CWIPJBSLOS.UPDATE_TIME, s_sys_time_17, 14); 

				s_is_jb_sold = 0;
	 } 
	 
    /* 1. Parameter List */
    /* Save All Parameter Data */
    PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");

	

    for(i = 0; i < i_param_list_count; i++)
    {
		c_lot_flag = 'Y';
        /* Lot Information */
		DBC_init_mwiplotsts(&MWIPLOTSTS);
        TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");

		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
        if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
			c_lot_flag = 'N';
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
            /* Get Max Sequence */
            d_max_seq_num = 0;
            CDB_init_cwiplotmat(&CWIPLOTMAT);
            //TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
			memcpy(CRASPRCDAT.LOT_ID,  s_last_lot_id, sizeof(CRASPRCDAT.LOT_ID));
		
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
			TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            
            memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time_17, sizeof(s_sys_time_17));

            d_max_seq_num = CDB_select_crasprcdat_scalar(2, &CRASPRCDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }

            /* Insert */
            CDB_init_crasprcdat(&CRASPRCDAT);
            //TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
			memcpy(CRASPRCDAT.LOT_ID,  s_last_lot_id, sizeof(CRASPRCDAT.LOT_ID));
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
            memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time_17, sizeof(s_sys_time_17));
            CRASPRCDAT.SEQ_NUM = (int)++d_max_seq_num;
            TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), in_node, "LINE_ID");
            memcpy(CRASPRCDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CRASPRCDAT.OPER));
            CRASPRCDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

            TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
			memcpy(CRASPRCDAT.CREATE_TIME, CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.CREATE_TIME));

			//AC모듈 장착 저장 START
			if((memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE1_FQC1, strlen(HQCEL_M1_RES_LINE1_FQC1)) == 0
				|| memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE2_FQC1, strlen(HQCEL_M1_RES_LINE2_FQC1)) == 0
				|| memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE3_FQC1, strlen(HQCEL_M1_RES_LINE3_FQC1)) == 0)
			   && TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "AC_INVERTER_BCR_ID", strlen("AC_INVERTER_BCR_ID")) == 0){
				//select lot info
				DBC_init_mwiplotsts(&MWIPLOTSTS_S);
				TRS.copy(MWIPLOTSTS_S.LOT_ID, sizeof(MWIPLOTSTS_S.LOT_ID), in_node, "LOT_ID");

				DBC_select_mwiplotsts(1, &MWIPLOTSTS_S);	
				
				//insert ac info
				CDB_init_cwipacmhis(&CWIPACMHIS);
				memcpy(CWIPACMHIS.FACTORY, MWIPLOTSTS_S.FACTORY, sizeof(CWIPACMHIS.FACTORY));
				TRS.copy(CWIPACMHIS.LOT_ID, sizeof(CWIPACMHIS.LOT_ID), in_node, "LOT_ID");
				TRS.copy(CWIPACMHIS.RES_ID, sizeof(CWIPACMHIS.RES_ID), in_node, "RES_ID");

				//PCU_SN
				TRS.copy(CWIPACMHIS.PCU_SN, sizeof(CWIPACMHIS.PCU_SN), PARAM_ITEM[j], "PARAM_VALUE");

				if(COM_isnullspace(CWIPACMHIS.PCU_SN) == MP_FALSE)
				{
					memcpy(CWIPACMHIS.CMF_1, "D", strlen("D"));
				}

				//[2026.01.12]기존 동일한 LOT ID에 다른 Inverter ID가 매핑된 경우 기존 ID 탈착처리
				//update AC PCU SN
				DBC_init_mwiplotsts(&MWIPLOTSTS_PCU);
				TRS.copy(MWIPLOTSTS_PCU.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
				//TRS.copy(MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15), PARAM_ITEM[j], "PARAM_VALUE");

				CDB_select_mwiplotsts(1, &MWIPLOTSTS_PCU);
				if(DB_error_code == DB_SUCCESS)
				{
					if(COM_isnullspace(MWIPLOTSTS_PCU.LOT_CMF_15) == MP_FALSE) {
						CDB_init_cwipacmhis(&CWIPACMHIS_PCU);
						memcpy(CWIPACMHIS_PCU.FACTORY, MWIPLOTSTS_S.FACTORY, sizeof(CWIPACMHIS.FACTORY));
						memcpy(CWIPACMHIS_PCU.LOT_ID, CWIPACMHIS.LOT_ID, sizeof(CWIPACMHIS.LOT_ID));
						memcpy(CWIPACMHIS_PCU.PCU_SN, MWIPLOTSTS_PCU.LOT_CMF_15, sizeof(MWIPLOTSTS_PCU.LOT_CMF_15));
						memcpy(CWIPACMHIS_PCU.CMF_2, "WIP-0665", strlen("WIP-0665"));
						CDB_update_cwipacmhis(2, &CWIPACMHIS_PCU);
						if(DB_error_code != DB_SUCCESS)
						{
							// DO NOTHING
						}
					}
				}

				//TRS.copy(CWIPACMHIS.CLIENT_TIME, sizeof(CWIPACMHIS.CLIENT_TIME), in_node, "CLIENT_TIME");
				memcpy(CWIPACMHIS.CLIENT_TIME, s_sys_time_stamp, sizeof(CWIPACMHIS.CLIENT_TIME));
				memcpy(CWIPACMHIS.CREATE_TIME, s_sys_time_stamp, sizeof(CWIPACMHIS.CREATE_TIME));
				TRS.copy(CWIPACMHIS.CREATE_USER_ID, sizeof(CWIPACMHIS.CREATE_USER_ID), in_node, "CREATE_USER_ID");

				CDB_insert_cwipacmhis(&CWIPACMHIS);

				//update AC Inverter Id 
				DBC_init_mwiplotsts(&MWIPLOTSTS);
				TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
				TRS.copy(MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15), PARAM_ITEM[j], "PARAM_VALUE");

				CDB_update_mwiplotsts(10, &MWIPLOTSTS);
				{
					//DO Nothing
				}
			}

			/*TR GRADING_PORT_NO process  */

			if((memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-TR-01", strlen("US-E1-TR-01")) == 0
						|| memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-TR-02", strlen("US-E1-TR-02")) == 0
						|| memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-TR-01", strlen("US-E2-TR-01")) == 0
						|| memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-TR-02", strlen("US-E2-TR-02")) == 0
						|| memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-TR-01", strlen("US-E3-TR-01")) == 0
						|| memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-TR-02", strlen("US-E3-TR-02")) == 0))
			{
				if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "GRADING_PORT_NO", strlen("GRADING_PORT_NO")) == 0)
				{
					CDB_init_cwiptrphis(&CWIPTRPHIS);

					TRS.copy(CWIPTRPHIS.LOT_ID, sizeof(CWIPTRPHIS.LOT_ID), in_node, "LOT_ID");
					memcpy(CWIPTRPHIS.TRAN_TIME, s_sys_time_17, 14);
					TRS.copy(CWIPTRPHIS.RES_ID, sizeof(CWIPTRPHIS.RES_ID), in_node, "RES_ID");
					TRS.copy(CWIPTRPHIS.GRANDING_PORT_NO, sizeof(CWIPTRPHIS.GRANDING_PORT_NO), PARAM_ITEM[j], "PARAM_VALUE");
					TRS.copy(CWIPTRPHIS.CMF_1, sizeof(CWIPTRPHIS.CMF_1), in_node, "LINE_ID");
					memcpy(CWIPTRPHIS.CMF_2, MWIPLOTSTS.MAT_ID, sizeof(CWIPTRPHIS.CMF_2));  
					

					CDB_init_cedclotrlt(&CEDCLOTRLT);
					TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, "FACTORY");
					memcpy(CEDCLOTRLT.INS_TYPE, "FC", strlen("FC"));
					TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CWIPTRPHIS.LOT_ID), in_node, "LOT_ID");
					
					CDB_select_cedclotrlt(1, &CEDCLOTRLT);	
					if(DB_error_code == DB_SUCCESS)
					{
						memcpy(CWIPTRPHIS.CMF_3, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME)); 
						memcpy(CWIPTRPHIS.CMF_4, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE)); 
						memcpy(CWIPTRPHIS.CMF_5, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)); 
					}

					CDB_insert_cwiptrphis(&CWIPTRPHIS);

					if(DB_error_code == DB_SUCCESS)
					{
						//DO nothing
					}
					/* GRANDING_PORT_NO , module id pack   [START]
					*/
					CDB_init_cwiptrpsts(&CWIPTRPSTS);

					TRS.copy(CWIPTRPSTS.FACTORY, sizeof(CWIPTRPSTS.FACTORY), in_node, "FACTORY");
					TRS.copy(CWIPTRPSTS.LINE, sizeof(CWIPTRPSTS.LINE), in_node, "LINE_ID");
					TRS.copy(CWIPTRPSTS.RES_ID, sizeof(CWIPTRPSTS.RES_ID), in_node, "RES_ID");
					TRS.copy(CWIPTRPSTS.GRANDING_PORT_NO, sizeof(CWIPTRPSTS.GRANDING_PORT_NO), PARAM_ITEM[j], "PARAM_VALUE");

					
					pak_seq = (int)CDB_select_cwiptrpsts_scalar(100, &CWIPTRPSTS);
					if(DB_error_code == DB_NOT_FOUND)
					{
						pak_seq = 0;
					}
					pak_seq++; 

					CWIPTRPSTS.PAK_SEQ = pak_seq;
					TRS.copy(CWIPTRPSTS.LOT_ID, sizeof(CWIPTRPSTS.LOT_ID), in_node, "LOT_ID");
					memcpy(CWIPTRPSTS.GRADE, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE)); 
					memcpy(CWIPTRPSTS.POWER, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)); 
					memcpy(CWIPTRPSTS.CREATE_USER_ID, "EAP", strlen("EAP"));
					memcpy(CWIPTRPSTS.CREATE_TIME, s_sys_time_17, 14);

					CDB_update_cwiptrpsts(1, &CWIPTRPSTS);	
					if(DB_error_code != DB_SUCCESS)
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							CDB_insert_cwiptrpsts(&CWIPTRPSTS);	
							if(DB_error_code != DB_SUCCESS)
							{
								//DO nothing
							}
						}
					}


					/* GRANDING_PORT_NO , module id pack   [END]
					*/


				}
			 }


			if(s_is_jb_sold == 0)
			{
				
				if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "DEFECT_POS_1", strlen("DEFECT_POS_1")) == 0){
					TRS.copy(CWIPJBSLOS.VALUE_1, sizeof(CWIPJBSLOS.VALUE_1), PARAM_ITEM[j], "PARAM_VALUE");
				}else if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "DEFECT_POS_2", strlen("DEFECT_POS_2")) == 0){
					TRS.copy(CWIPJBSLOS.VALUE_2, sizeof(CWIPJBSLOS.VALUE_2), PARAM_ITEM[j], "PARAM_VALUE");
				}else if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "DEFECT_POS_3", strlen("DEFECT_POS_3")) == 0){
					TRS.copy(CWIPJBSLOS.VALUE_3, sizeof(CWIPJBSLOS.VALUE_3), PARAM_ITEM[j], "PARAM_VALUE");
				}else if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "DEFECT_POS_4", strlen("DEFECT_POS_4")) == 0){
					TRS.copy(CWIPJBSLOS.VALUE_4, sizeof(CWIPJBSLOS.VALUE_4), PARAM_ITEM[j], "PARAM_VALUE");
				}else if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "DEFECT_POS_5", strlen("DEFECT_POS_5")) == 0){
					TRS.copy(CWIPJBSLOS.VALUE_5, sizeof(CWIPJBSLOS.VALUE_5), PARAM_ITEM[j], "PARAM_VALUE");
				}else if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "DEFECT_POS_6", strlen("DEFECT_POS_6")) == 0){
					TRS.copy(CWIPJBSLOS.VALUE_6, sizeof(CWIPJBSLOS.VALUE_6), PARAM_ITEM[j], "PARAM_VALUE");
				}
			}

			//값이 없으면 저장안함. 데이터가 너무많음.
			if (COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) == MP_TRUE)
			{
				continue;
			}

			CRASPRCDAT.CMF_5[0] = c_lot_flag;
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

	if(s_is_jb_sold == 0)
	{	

		if(memcmp(CWIPJBSLOS.VALUE_1, "OK", strlen("OK")) == 0
			&& memcmp(CWIPJBSLOS.VALUE_2, "OK", strlen("OK")) == 0
			&& memcmp(CWIPJBSLOS.VALUE_3, "OK", strlen("OK")) == 0
			&& memcmp(CWIPJBSLOS.VALUE_4, "OK", strlen("OK")) == 0
			&& memcmp(CWIPJBSLOS.VALUE_5, "OK", strlen("OK")) == 0
			&& memcmp(CWIPJBSLOS.VALUE_6, "OK", strlen("OK")) == 0)
		{
			memcpy(CWIPJBSLOS.DEFECT_RESULT, "OK", sizeof("OK"));
		}
		else
		{
			memcpy(CWIPJBSLOS.DEFECT_RESULT, "NG", sizeof("NG"));
		}
		
		CDB_insert_cwipjbslos(&CWIPJBSLOS);
		if(DB_error_code != DB_SUCCESS)
		{

				//DO NOTHING
		}
	}

    /* Save inspection data even if there are errors beyond this point */
    DB_commit();

	/* 2. Material List */

	 /* Lot Information */

	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
            
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	/* Order Information */
	DBC_init_mwipordsts(&MWIPORDSTS);
	TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
     
	DBC_select_mwipordsts(1, &MWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	if (COM_isspace(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID)) == MP_TRUE)
	{
		//PROCESS DATA 에 LOT ID 없는데이터의 자재처리는 안함.
		 COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}
            
        

    MAT_LIST = TRS.get_list(in_node, "MAT_LIST");
    i_mat_list_count = TRS.get_item_count(in_node, "MAT_LIST");

	for(i = 0; i < i_mat_list_count; i++)
    {
		MAT_ITEM = TRS.get_list(MAT_LIST[i], "MAT_ITEM");
        i_mat_item_count = TRS.get_item_count(MAT_LIST[i], "MAT_ITEM");

        for(j = 0; j < i_mat_item_count; j++)
        {
			MAT_GUBUN[0] = '\0';		
			OTHER_MAT_ID[0] = '\0';
            /* Get INVLOT */
			CDB_init_cinvlotsts(&CINVLOTSTS); 			
			TRS.copy(CINVLOTSTS.FACTORY, sizeof(CINVLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CINVLOTSTS.VENDOR_BARCD, sizeof(CINVLOTSTS.VENDOR_BARCD), MAT_ITEM[j], "MAT_ID");
            
			//MAT_ID 이게 blank 일경우가 있다. 정식 장착없이 자재사용
			if (COM_isspace(CINVLOTSTS.VENDOR_BARCD, (int)strlen(CINVLOTSTS.VENDOR_BARCD)) == MP_TRUE)
			{
				continue;
			}

			CDB_select_cinvlotsts(2, &CINVLOTSTS);
			
			ordbom_step = 2;

			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					ordbom_step = 4;
					memcpy(s_message, "not exist INV_LOT", strlen("not exist INV_LOT"));
					//strcpy(s_msg_code, "INV-0013");					
					//gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					//return MP_FALSE;
				}
				else
				{

				}
			}

			//Production Order Bom
			CDB_init_cwipordbom(&CWIPORDBOM);
			TRS.copy(CWIPORDBOM.FACTORY, sizeof(CWIPORDBOM.FACTORY), in_node, "FACTORY");
			memcpy(CWIPORDBOM.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
			memcpy(CWIPORDBOM.MAT_ID, CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));
            TRS.copy(CWIPORDBOM.MATE_TYPE, sizeof(CWIPORDBOM.MATE_TYPE), MAT_ITEM[j], "MAT_TYPE");

			CDB_select_cwipordbom(ordbom_step, &CWIPORDBOM);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					
					//IS-22-03-054 22.03.23 : MAT_TYPE = 'JCB'인경우 
					//입력 된 자재 코드로 맵핑 되도록 변경함
					//AS_IS : 오더에 등록된 자재 가 아닌 경우 가장 첫번째 줄의 자재 코드로 맵핑
					//TO_BE : MAT_TYPE = 'JCB'인 경우 오더에 등록된 자재가 아니면 , 실제 연계된 자재로 등록 되도록 변경
					
					if(memcmp(CWIPORDBOM.MATE_TYPE, "JCB", strlen("JCB")) == 0)
					{

						ordbom_step = 4;
						CDB_select_cwipordbom(ordbom_step, &CWIPORDBOM);
						
						//mat_id가 13자리가 넘는지 확인
						i_len = 0;
						i_len = COM_string_length(CWIPORDBOM.MAT_ID, sizeof(CWIPORDBOM.MAT_ID));
						
						if(i_len > 13)
						{	
							
							memset(CWIPORDBOM.MAT_ID, ' ', sizeof(CWIPORDBOM.MAT_ID));
							memset(CWIPORDBOM.MATE_NO_DESC, ' ', sizeof(CWIPORDBOM.MATE_NO_DESC));
							memset(i_mat_code, ' ', sizeof(i_mat_code));
							
							TRS.copy(i_mat_code, 13,  MAT_ITEM[j], "MAT_ID");

							CWIPORDBOM.MAT_ID[0] = '0';
							CWIPORDBOM.MAT_ID[1] = '0';
							CWIPORDBOM.MAT_ID[2] = '0';
							CWIPORDBOM.MAT_ID[3] = '0';
							CWIPORDBOM.MAT_ID[4] = '0';

							CWIPORDBOM.MAT_ID[5] = i_mat_code[0];
							CWIPORDBOM.MAT_ID[6] = i_mat_code[1];
							CWIPORDBOM.MAT_ID[7] = i_mat_code[2];
							CWIPORDBOM.MAT_ID[8] = i_mat_code[3];
							CWIPORDBOM.MAT_ID[9] = i_mat_code[4];
							CWIPORDBOM.MAT_ID[10] = i_mat_code[5];
							CWIPORDBOM.MAT_ID[11] = i_mat_code[6];
							CWIPORDBOM.MAT_ID[12] = i_mat_code[7];
							CWIPORDBOM.MAT_ID[13] = i_mat_code[8];
							CWIPORDBOM.MAT_ID[14] = i_mat_code[9];
							CWIPORDBOM.MAT_ID[15] = i_mat_code[10];
							CWIPORDBOM.MAT_ID[16] = i_mat_code[11];
							CWIPORDBOM.MAT_ID[17] = i_mat_code[12];

							//자재 명 구하기
							DBC_init_mwipmatdef(&MWIPMATDEF);
							TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
							memcpy(MWIPMATDEF.MAT_ID, CWIPORDBOM.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
							MWIPMATDEF.MAT_VER = 1;
							//DBC_select_mwipmatdef(1, &MWIPMATDEF);
							//23.4.19 GERP 자재 코드 자릿수 변경 대응 13 -> 8 자리 
							CDB_select_mwipmatdef(2, &MWIPMATDEF);
							if(DB_error_code == DB_SUCCESS)
							{
								memcpy(CWIPORDBOM.MATE_NO_DESC, MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
							}

						}


					}					
					else
					{
						ordbom_step = 4;
						CDB_select_cwipordbom(ordbom_step, &CWIPORDBOM);
						//strcpy(s_msg_code, "INV-0013");					
						//gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						//return MP_FALSE;
					}
				}
			}
			
			strncpy(MAT_GUBUN,CINVLOTSTS.VENDOR_BARCD,2);
			strncpy(OTHER_MAT_ID,CINVLOTSTS.VENDOR_BARCD+10,13);

			if((MAT_GUBUN[0] == '4' && MAT_GUBUN[1] == '5') || (MAT_GUBUN[0] == '9' && MAT_GUBUN[1] == '9'))
			{
				ordbom_step = 4;
				CDB_select_cwipordbom(ordbom_step, &CWIPORDBOM);
						
				//mat_id가 13자리가 넘는지 확인
				i_len = 0;
				i_len = COM_string_length(CWIPORDBOM.MAT_ID, sizeof(CWIPORDBOM.MAT_ID));
						
				if(i_len > 13)
				{	
							
					memset(CWIPORDBOM.MAT_ID, ' ', sizeof(CWIPORDBOM.MAT_ID));
					memset(CWIPORDBOM.MATE_NO_DESC, ' ', sizeof(CWIPORDBOM.MATE_NO_DESC));

					CWIPORDBOM.MAT_ID[0] = '0';
					CWIPORDBOM.MAT_ID[1] = '0';
					CWIPORDBOM.MAT_ID[2] = '0';
					CWIPORDBOM.MAT_ID[3] = '0';
					CWIPORDBOM.MAT_ID[4] = '0';

					CWIPORDBOM.MAT_ID[5] = OTHER_MAT_ID[0];
					CWIPORDBOM.MAT_ID[6] = OTHER_MAT_ID[1];
					CWIPORDBOM.MAT_ID[7] = OTHER_MAT_ID[2];
					CWIPORDBOM.MAT_ID[8] = OTHER_MAT_ID[3];
					CWIPORDBOM.MAT_ID[9] = OTHER_MAT_ID[4];
					CWIPORDBOM.MAT_ID[10] = OTHER_MAT_ID[5];
					CWIPORDBOM.MAT_ID[11] = OTHER_MAT_ID[6];
					CWIPORDBOM.MAT_ID[12] = OTHER_MAT_ID[7];
					CWIPORDBOM.MAT_ID[13] = OTHER_MAT_ID[8];
					CWIPORDBOM.MAT_ID[14] = OTHER_MAT_ID[9];
					CWIPORDBOM.MAT_ID[15] = OTHER_MAT_ID[10];
					CWIPORDBOM.MAT_ID[16] = OTHER_MAT_ID[11];
					CWIPORDBOM.MAT_ID[17] = OTHER_MAT_ID[12];

					//자재 명 구하기
					DBC_init_mwipmatdef(&MWIPMATDEF);
					TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
					memcpy(MWIPMATDEF.MAT_ID, CWIPORDBOM.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
					MWIPMATDEF.MAT_VER = 1;
					DBC_select_mwipmatdef(1, &MWIPMATDEF);
					if(DB_error_code == DB_SUCCESS)
					{
						memcpy(CWIPORDBOM.MATE_NO_DESC, MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
					}

				}
			}

			/* Get Max Sequence */
            d_max_seq_num = 0;
            CDB_init_cwiplotmat(&CWIPLOTMAT);
			TRS.copy(CWIPLOTMAT.FACTORY, sizeof(CWIPLOTMAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CWIPLOTMAT.LOT_ID, sizeof(CWIPLOTMAT.LOT_ID), in_node, "LOT_ID");
            CWIPLOTMAT.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
				 
            d_max_seq_num = CDB_select_cwiplotmat_scalar(100, &CWIPLOTMAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }

            /* Insert */
            CDB_init_cwiplotmat(&CWIPLOTMAT);
            TRS.copy(CWIPLOTMAT.FACTORY, sizeof(CWIPLOTMAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CWIPLOTMAT.LOT_ID, sizeof(CWIPLOTMAT.LOT_ID), in_node, "LOT_ID");
            CWIPLOTMAT.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
            CWIPLOTMAT.USE_SEQ =(int) ++d_max_seq_num;
			TRS.copy(CWIPLOTMAT.RES_ID           , sizeof(CWIPLOTMAT.RES_ID)          , in_node, "RES_ID");
			TRS.copy(CWIPLOTMAT.INV_BARCODE_ID   , sizeof(CWIPLOTMAT.INV_BARCODE_ID)  , MAT_ITEM[j], "MAT_ID");
			TRS.copy(CWIPLOTMAT.INV_LOT_ID   , sizeof(CWIPLOTMAT.INV_LOT_ID)  , MAT_ITEM[j], "MAT_ID");
			memcpy(CWIPLOTMAT.INV_MAT_ID, CWIPORDBOM.MAT_ID, sizeof(CWIPLOTMAT.INV_MAT_ID));
			memcpy(CWIPLOTMAT.INV_MAT_DESC, CWIPORDBOM.MATE_NO_DESC, sizeof(CWIPLOTMAT.INV_MAT_DESC));
			memcpy(CWIPLOTMAT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(CWIPLOTMAT.MAT_ID));
			memcpy(CWIPLOTMAT.FLOW, MWIPLOTSTS.FLOW, sizeof(CWIPLOTMAT.FLOW));
			memcpy(CWIPLOTMAT.OPER, MWIPLOTSTS.OPER, sizeof(CWIPLOTMAT.OPER));
			memcpy(CWIPLOTMAT.MAT_TYPE, CWIPORDBOM.MATE_TYPE, sizeof(CWIPLOTMAT.MAT_TYPE));

			
			//TRS.copy(CWIPLOTMAT.ATTACH_QTY       , sizeof(CWIPLOTMAT.ATTACH_QTY)      , in_node, "LINE_ID");
			if(CWIPORDBOM.QTY > 0.0)
			{
				CWIPLOTMAT.USED_QTY = CWIPORDBOM.QTY / MWIPORDSTS.ORD_QTY;
			}
			//TRS.copy(CWIPLOTMAT.REMAIN_QTY       , sizeof(CWIPLOTMAT.REMAIN_QTY)      , in_node, "LINE_ID");
			memcpy(CWIPLOTMAT.UNIT, CWIPORDBOM.UNIT_ID, sizeof(CWIPLOTMAT.UNIT));
			if(CWIPORDBOM.QTY > 0.0)
			{
				CWIPLOTMAT.DEFAULT_USE_QTY = CWIPORDBOM.QTY / MWIPORDSTS.ORD_QTY;
			}
			memcpy(CWIPLOTMAT.ATTACH_TIME, s_sys_time_17, sizeof(CWIPLOTMAT.ATTACH_TIME)); //update 금지.partion key
			memcpy(CWIPLOTMAT.USE_BATCH_ID     , CINVLOTSTS.BATCH_NO   , sizeof(CWIPLOTMAT.USE_BATCH_ID)); 
			memcpy(CWIPLOTMAT.ORDER_ID, CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
			CWIPLOTMAT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
			
			//설비에서 마지막 장착된 이력 GET
			CDB_init_crasresmah(&CRASRESMAH);
			memcpy(CRASRESMAH.FACTORY, CWIPLOTMAT.FACTORY, sizeof(CWIPLOTMAT.FACTORY));
			memcpy(CRASRESMAH.INV_BARCODE_ID, CWIPLOTMAT.INV_BARCODE_ID, sizeof(CWIPLOTMAT.INV_BARCODE_ID));
			CDB_select_crasresmah(3, &CRASRESMAH);
			if(DB_error_code != DB_SUCCESS)
            {
                
            }
			memcpy(CWIPLOTMAT.CMF_1, MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_1)); //설비공정
			memcpy(CWIPLOTMAT.POSITION_ID, CRASRESMAH.POSITION_ID, sizeof(CRASRESMAH.POSITION_ID)); //장착위치
			memcpy(CWIPLOTMAT.CMF_2, CRASRESMAH.RES_ID, sizeof(CRASRESMAH.RES_ID)); //장착설비
			memcpy(CWIPLOTMAT.CMF_3, CRASRESMAH.ATTACH_TIME, sizeof(CRASRESMAH.ATTACH_TIME)); //장착시간
			//memcpy(CWIPLOTMAT.CMF_5, s_message, sizeof(CWIPLOTMAT.CMF_5)); //BATCH ID 가 없음..ERP 에서 안온것임.

            CDB_insert_cwiplotmat(&CWIPLOTMAT);
            if(DB_error_code != DB_SUCCESS)
            {
                
            }
			//자재 추적성(2024.02.23) Start
			// 자재 추적성 생성 Procedure에서 사용할 데이터 생성
            if (Send_Material_Tracability_Data_Raw_Material(s_msg_code, &CWIPLOTMAT, in_node, out_node) == MP_FALSE)
                return MP_FALSE;
			//자재 추적성(2024.02.23) end

        }
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Process_Data_Validation()
        - Main sub function of "EAPMES_COLLECT_PROCESS_DATA" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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


    return MP_TRUE;
}

/*******************************************************************************
  Send_Material_Tracability_Data_Raw_Material()
    - Main sub function of "EAPMES_Collect_Process_Data_E23" function
  Return Value
    - int : 1 (MP_TRUE) or 0 (MP_FALSE)
  Arguments
    - char *s_msg_code : Error Message Code
    - struct CWIPLOTMAT_TAG *CWIPLOTMAT : 사용 자재
    - TRSNode *in_node : Input Message structure
    - TRSNode *out_node : Output Message structure
*******************************************************************************/
int Send_Material_Tracability_Data_Raw_Material(char* s_msg_code, struct CWIPLOTMAT_TAG* CWIPLOTMAT, TRSNode* in_node, TRSNode* out_node)
{
	return MP_TRUE;//24.10.09 RPT 데이터 저장 중지
/*
    struct CWIPCTMTRC_TAG CWIPCTMTRC;

    CDB_init_cwipctmtrc(&CWIPCTMTRC);
    memcpy(CWIPCTMTRC.FACTORY, CWIPLOTMAT->FACTORY, sizeof(CWIPCTMTRC.FACTORY));
    memcpy(CWIPCTMTRC.LOT_ID, CWIPLOTMAT->LOT_ID, sizeof(CWIPLOTMAT->LOT_ID));
    memcpy(CWIPCTMTRC.INV_LOT_ID, CWIPLOTMAT->INV_LOT_ID, sizeof(CWIPCTMTRC.INV_LOT_ID));
    memcpy(CWIPCTMTRC.KIND, "TRACE", strlen("TRACE"));
    CWIPCTMTRC.WIP_FLAG = 'R';  // Raw Material

    CDB_select_cwipctmtrc(2, &CWIPCTMTRC);
    if (DB_error_code == DB_NOT_FOUND)
    {
        memcpy(CWIPCTMTRC.TRAN_TIME, CWIPLOTMAT->ATTACH_TIME, sizeof(CWIPCTMTRC.TRAN_TIME));
        CDB_insert_cwipctmtrc(2, &CWIPCTMTRC);  // RPT에 저장

        //CDB_insert_cwipctmtrc(3, &CWIPCTMTRC);  // ARC에 저장
    }
*/

 //   char s_channel[100];

 //   LOG_head("Send_Material_Tracability_Data_Raw_Material");
 //   TRS.log_add_all_members(in_node);
 //   COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
 //   
	//memset(s_channel, 0x00, sizeof(s_channel));
 //   sprintf(s_channel, "/%.*s/GTMServer", 4, gs_site_id);

 //   // Report DB, Archive DB 에 자재 추적성 데이터 전송
 //   // FACTORY, LOT_ID, KIND, WIP_FLAG 전송
 //   TRS.set_char(in_node, IN_PROCSTEP, '1');
 //   TRS.set_string(in_node, "INV_LOT_ID", CWIPLOTMAT->INV_LOT_ID, sizeof(CWIPLOTMAT->INV_LOT_ID));
 //   TRS.set_nstring(in_node, "KIND", "TRACE");
 //   TRS.set_char(in_node, "WIP_FLAG", 'R');

 //   // Report DB 전용
 //   if (CallService("CEIS",
 //       "CEIS_Save_Traceability_Material_Data",
 //       in_node,
 //       0x00,
 //       s_channel,
 //       18000000, //gi_default_ttl, 
 //       DM_GUNICAST) != MP_TRUE)
 //   {
 //       // Error Log 생성
 //       LOG_head("CEIS_Save_Traceability_Material_Data R Send Error");
 //       COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
 //       return MP_FALSE;
 //   }

	//// Archive DB 전용
 //   memset(s_channel, 0x00, sizeof(s_channel));
 //   sprintf(s_channel, "/%.*s/ARCServer", 4, gs_site_id);

 //   LOG_head("CEIS_Save_Traceability_Material_Data_ARC Channel");
 //   LOG_add("Channel", MP_STR, sizeof(s_channel), s_channel);
 //   LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
 //   COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
 //   
	//if (CallService("CEIS",
 //       "CEIS_Save_Traceability_Material_Data_ARC",
 //       in_node,
 //       0x00,
 //       s_channel,
 //       18000000, //gi_default_ttl, 
 //       DM_GUNICAST) != MP_TRUE)
 //   {
 //       // Error Log 생성
 //       LOG_head("CEIS_Save_Traceability_Material_Data_ARC R Send Error");
 //       COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
 //       return MP_FALSE;
 //   }

    return MP_TRUE;
}