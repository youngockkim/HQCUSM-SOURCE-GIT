/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_process_data_string.c
    Description : EAPMES Collect Process Data String Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Process_Data_String()
            + Setup service interface function
        - EAPMES_COLLECT_PROCESS_DATA_STRING()
            + Main sub function of EAPMES_Collect_Process_Data_String function
            + Setup service main business function
        - EAPMES_Collect_Process_Data_String_Validation()
            + Main sub function of EAPMES_COLLECT_PROCESS_DATA_STRING function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_COLLECT_PROCESS_DATA_STRING()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Process_Data_String_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Process_Data_String()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_String(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_PROCESS_DATA_STRING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_PROCESS_DATA_STRING", out_node);

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
    TRS.set_nstring(out_node, "STRING_ID", TRS.get_string(in_node, "STRING_ID"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Process_Data_String", 
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
    EAPMES_COLLECT_PROCESS_DATA_STRING()
        - Main sub function of "EAPMES_Collect_Process_Data_String" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_PROCESS_DATA_STRING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPSTRCEL_TAG CWIPSTRCEL;
	struct MRASRESDEF_TAG MRASRESDEF;
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CRASPRCDAT_TAG CRASPRCDAT;
	struct CINVLOTSTS_TAG CINVLOTSTS;
	struct CWIPORDBOM_TAG CWIPORDBOM;
	struct CWIPLOTMAT_TAG CWIPLOTMAT;
	struct CRASRESMAH_TAG CRASRESMAH;
	struct MWIPORDSTS_TAG MWIPORDSTS;

    char s_sys_time_stamp[20];  
    char s_sys_time[17];
	char s_sys_time_17[17];
    int i, j;
    double d_max_seq_num;
	clock_t start_time;

    int i_cell_list_count;
    int i_cell_item_count;

    int i_mat_list_count;
    int i_mat_item_count;
	int ordbom_step = 0;

    int i_param_list_count;
    int i_param_item_count;

    TRSNode ** CELL_LIST;
    TRSNode ** CELL_ITEM;

    TRSNode ** MAT_LIST;
    TRSNode ** MAT_ITEM;

    TRSNode ** PARAM_LIST;
    TRSNode ** PARAM_ITEM;

	/*init CRASPRCDAT*/
	TRSNode * ras_tran_in_node;
	TRSNode * ras_param_list;
	TRSNode * ras_param_item;
	int send_data_count=0;

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
	
    LOG_head("EAPMES_COLLECT_PROCESS_DATA_STRING");
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
	memcpy(s_sys_time_17, s_sys_time, sizeof(s_sys_time));

	start_time = STOPWATCH_START();
    /* 1. Parameter List */
    /* Save All Parameter Data */
    PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");

    /* Lot Information */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "STRING_ID");           
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

	for(i = 0; i < i_param_list_count; i++)
    {
        PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
        i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");

        for(j = 0; j < i_param_item_count; j++)
        {
            /* Get Max Sequence */
            d_max_seq_num = 0;
            CDB_init_crasprcdat(&CRASPRCDAT);
            TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "STRING_ID");
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
			memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
			//TRS.copy(CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.TRAN_TIME), in_node, "CLIENT_TIME");
            TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            d_max_seq_num = CDB_select_crasprcdat_scalar(2, &CRASPRCDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }

            /* Insert */
            CDB_init_crasprcdat(&CRASPRCDAT);
            TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "STRING_ID");
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
            memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
			//TRS.copy(CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.TRAN_TIME), in_node, "CLIENT_TIME");
            CRASPRCDAT.SEQ_NUM = ++d_max_seq_num;
            TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), in_node, "LINE_ID");
            memcpy(CRASPRCDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CRASPRCDAT.OPER));
            CRASPRCDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

            TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
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
	STOPWATCH_END("CRASPRCDAT_I_ELAPSED_TIME", start_time);


    if(EAPMES_Collect_Process_Data_String_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
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
        return MP_FALSE;
	}

	start_time = STOPWATCH_START();
	/******************************************************************************/
	/* TABBER 의 STRING 완료되는 시점에 STRING END 트랜잭션 발생 */
	/******************************************************************************/
	if (COM_isnullspace(TRS.get_string(in_node, "STRING_ID")) == MP_FALSE)
	{
		//STRING 별, TABBER END LOT 수행
		TRS.set_string(in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2));
		TRS.set_nstring(in_node, "LOT_ID",TRS.get_string(in_node, "STRING_ID"));
		if(CWIP_END_LOT(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	STOPWATCH_END("END_LOT_ELAPSED_TIME", start_time);

	start_time = STOPWATCH_START();
	/* Cell List */
    CELL_LIST = TRS.get_list(in_node, "CELL_LIST");
    i_cell_list_count = TRS.get_item_count(in_node, "CELL_LIST");

    for(i = 0; i < i_cell_list_count; i++)
    {
        CELL_ITEM = TRS.get_list(CELL_LIST[i], "CELL_ITEM");
        i_cell_item_count = TRS.get_item_count(CELL_LIST[i], "CELL_ITEM");

	    for(j = 0; j < i_cell_item_count; j++)
        {
            CDB_init_cwipstrcel(&CWIPSTRCEL);

            TRS.copy(CWIPSTRCEL.FACTORY, sizeof(CWIPSTRCEL.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CWIPSTRCEL.STRING_ID, sizeof(CWIPSTRCEL.STRING_ID), in_node, "STRING_ID");
            TRS.copy(CWIPSTRCEL.CELL_ID, sizeof(CWIPSTRCEL.CELL_ID), CELL_ITEM[j], "CELL_ID");
            
            CDB_select_cwipstrcel_for_update(1, &CWIPSTRCEL);
            if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)            
            {
				//DO NOTHING
				return MP_TRUE;
            }

            /* Insert or Update */
            TRS.copy(CWIPSTRCEL.LINE_ID, sizeof(CWIPSTRCEL.LINE_ID), in_node, "LINE_ID");
            TRS.copy(CWIPSTRCEL.RES_ID, sizeof(CWIPSTRCEL.RES_ID), in_node, "RES_ID");
            TRS.copy(CWIPSTRCEL.CMF_1, sizeof(CWIPSTRCEL.CMF_1), CELL_ITEM[j], "LAMA_ID");
            TRS.copy(CWIPSTRCEL.CMF_2, sizeof(CWIPSTRCEL.CMF_2), CELL_ITEM[j], "TIDYUP");
            TRS.copy(CWIPSTRCEL.CMF_3, sizeof(CWIPSTRCEL.CMF_3), CELL_ITEM[j], "SOLDER");
            TRS.copy(CWIPSTRCEL.CMF_4, sizeof(CWIPSTRCEL.CMF_4), CELL_ITEM[j], "ZIG");

            if(DB_error_code == DB_SUCCESS)
            {
                /* Update */
                memcpy(CWIPSTRCEL.LAST_TRAN_TIME, s_sys_time, sizeof(CWIPSTRCEL.LAST_TRAN_TIME));

                CDB_update_cwipstrcel(1, &CWIPSTRCEL);
                if(DB_error_code != DB_SUCCESS)
                {
					//DO NOTHING
					return MP_TRUE;
                }
            }
            else if (DB_error_code == DB_NOT_FOUND)
            {
                /* Insert */
                memcpy(CWIPSTRCEL.CREATE_TIME, s_sys_time, sizeof(CWIPSTRCEL.CREATE_TIME));
                memcpy(CWIPSTRCEL.LAST_TRAN_TIME, s_sys_time, sizeof(CWIPSTRCEL.LAST_TRAN_TIME));
				COM_itoa_left(CWIPSTRCEL.CELL_LOATION, j+1, sizeof(CWIPSTRCEL.CELL_LOATION)); 
                CDB_insert_cwipstrcel(&CWIPSTRCEL);
                if(DB_error_code != DB_SUCCESS)
                {
					//DO NOTHING
					return MP_TRUE;
                   
                }
            }
            
        }

		
    }
	STOPWATCH_END("CWIPSTRCEL_IU_ELAPSED_TIME", start_time);

	start_time = STOPWATCH_START();
    /* Input Material List */
    MAT_LIST = TRS.get_list(in_node, "MAT_LIST");
    i_mat_list_count = TRS.get_item_count(in_node, "MAT_LIST");

    for(i = 0; i < i_mat_list_count; i++)
    {
        MAT_ITEM = TRS.get_list(MAT_LIST[i], "MAT_ITEM");
        i_mat_item_count = TRS.get_item_count(MAT_LIST[i], "MAT_ITEM");

        for(j = 0; j < i_mat_item_count; j++)
        {
            /* Get INVLOT */
			CDB_init_cinvlotsts(&CINVLOTSTS); 			
			TRS.copy(CINVLOTSTS.FACTORY, sizeof(CINVLOTSTS.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CINVLOTSTS.VENDOR_BARCD, sizeof(CINVLOTSTS.VENDOR_BARCD), MAT_ITEM[j], "MAT_ID");
            
			//MAT_ID 이게 blank 일경우가 있다. 정식 장착없이 자재사용
			if (COM_isspace(CINVLOTSTS.VENDOR_BARCD, strlen(CINVLOTSTS.VENDOR_BARCD)) == MP_TRUE) //Server crash
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
					ordbom_step = 4;
					CDB_select_cwipordbom(ordbom_step, &CWIPORDBOM);
					//strcpy(s_msg_code, "INV-0013");					
					//gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					//return MP_FALSE;
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

			//
			DBC_init_mwipordsts(&MWIPORDSTS);
			//memcpy(MWIPORDSTS.ORDER_ID, CWIPLOTMAT.ORDER_ID, sizeof(CWIPLOTMAT.ORDER_ID)); // Server Crash 190925
			memcpy(MWIPORDSTS.ORDER_ID, CWIPLOTMAT.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
			memcpy(MWIPORDSTS.FACTORY, CWIPLOTMAT.FACTORY, sizeof(CWIPLOTMAT.FACTORY));
			DBC_select_mwipordsts(1, &MWIPORDSTS);
			if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }
			
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
        }
    }
	STOPWATCH_END("CWIPLOTMAT_I_ELAPSED_TIME", start_time);




    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Process_Data_String_Validation()
        - Main sub function of "EAPMES_COLLECT_PROCESS_DATA_STRING" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_String_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

