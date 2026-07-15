/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_inspection_data_string.c
    Description : EAPMES Collect Inspection Data for String Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Inspection_Data_String()
            + Setup service interface function
        - EAPMES_COLLECT_INSPECTION_DATA_STRING()
            + Main sub function of EAPMES_Collect_Inspection_Data_String function
            + Setup service main business function
        - EAPMES_Collect_Inspection_Data_String_Validation()
            + Main sub function of EAPMES_COLLECT_INSPECTION_DATA_STRING function
    Detail Description
        - EAPMES_COLLECT_INSPECTION_DATA_STRING()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Inspection_Data_String_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_String()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_String(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_INSPECTION_DATA_STRING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_INSPECTION_DATA_STRING", out_node);

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
    TRS.set_nstring(out_node, "RESULT", TRS.get_string(in_node, "RESULT"));
    TRS.set_nstring(out_node, "LOC_ID", TRS.get_string(in_node, "LOC_ID"));
    TRS.set_nstring(out_node, "INSP_ZONE", TRS.get_string(in_node, "INSP_ZONE"));

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Inspection_Data_String", 
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
    EAPMES_COLLECT_INSPECTION_DATA_STRING()
        - Main sub function of "EAPMES_Collect_Inspection_Data_String" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_INSPECTION_DATA_STRING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CEDCINSDAT_TAG CEDCINSDAT;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CWIPTRYSTS_TAG CWIPTRYSTS;
	
    char s_sys_time_stamp[20];  
    char s_sys_time[17];
    int i, j;
    double d_max_seq_num;
	char c_create_flag= 'N';

    int i_param_list_count;
    int i_param_item_count;

    TRSNode ** PARAM_LIST;
    TRSNode ** PARAM_ITEM;

	TRSNode ** CELL_LIST;
    TRSNode ** CELL_ITEM;

    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("EAPMES_COLLECT_INSPECTION_DATA_STRING");
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

    /* Lot Information */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "STRING_ID");
            
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			c_create_flag = 'Y';
		}
        else
        {

        }
    }

	

	/* Check Resource */
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "RAS-0003");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}

	/* LOT 생성 */
	if (c_create_flag == 'Y')
	{
		//STRING 생성 (하지않음.. 삭제함 다른 이벤트에서 처리)
	}

    /* 1. Parameter List */
    /* Save All Parameter Data */
    PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");

    for(i = 0; i < i_param_list_count; i++)
    {
        PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
        i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");

        for(j = 0; j < i_param_item_count; j++)
        {
            /* Get Max Sequence */
            d_max_seq_num = 0;
            CDB_init_cedcinsdat(&CEDCINSDAT);
            TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "STRING_ID");
            TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
            memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
			//TRS.copy(CEDCINSDAT.TRAN_TIME, sizeof(CEDCINSDAT.TRAN_TIME), in_node, "CLIENT_TIME");
            d_max_seq_num = CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }

            /* Insert */
            CDB_init_cedcinsdat(&CEDCINSDAT);
            TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "STRING_ID");
            TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
			memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
			if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)) == 0
				|| MRASRESDEF.RES_CMF_14[0] == 'Y')
			{
				memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
				//TRS.copy(CEDCINSDAT.TRAN_TIME, sizeof(CEDCINSDAT.TRAN_TIME), in_node, "CLIENT_TIME");
			}
            CEDCINSDAT.SEQ_NUM = ++d_max_seq_num;
            TRS.copy(CEDCINSDAT.FACTORY, sizeof(CEDCINSDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CEDCINSDAT.LINE_ID, sizeof(CEDCINSDAT.LINE_ID), in_node, "LINE_ID");
			if (MRASRESDEF.RES_CMF_14[0] == 'Y')
			{
				memcpy(CEDCINSDAT.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)); //OPER
			}
			else{
				memcpy(CEDCINSDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCINSDAT.OPER));
			}
            
            CEDCINSDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

            TRS.copy(CEDCINSDAT.PARAM_NAME, sizeof(CEDCINSDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");

            CDB_insert_cedcinsdat(&CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                
            }
        }
    }

    /* Save inspection data even if there are errors beyond this point */
    //DB_commit();

	/*
        3. Save Inspection Data and Result
		 CEDCLOTRLT 
		 CEDCLOTRLH 
    */
    tran_in_node = TRS.create_node("END_LOT_IN");
    tran_out_node = TRS.create_node("END_LOT_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  

    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)) == 0 ||
		MRASRESDEF.RES_CMF_14[0] == 'Y')
	{
		TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_LOSS_CATEGORY_TABBER);  
        TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "STRING_ID"));  
		TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
		TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
		TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
		TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));
		TRS.add_nstring(tran_in_node, "LOC_ID",  TRS.get_string(in_node,"LOC_ID"));
		TRS.add_char(tran_in_node, "TYPE_FLAG", '1'); /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */ 

		if(CEDC_UPDATE_INSPECTION_DATA(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		/* 2. string List */
		/* string 검사 List */
		CELL_LIST = TRS.get_list(in_node, "CELL_LIST");
		i_param_list_count = TRS.get_item_count(in_node, "CELL_LIST");

		for(i = 0; i < i_param_list_count; i++)
		{
			CELL_ITEM = TRS.get_list(CELL_LIST[i], "CELL_ITEM");
			i_param_item_count = TRS.get_item_count(CELL_LIST[i], "CELL_ITEM");

			for(j = 0; j < i_param_item_count; j++)
			{
				/* Get Max Sequence */
				d_max_seq_num = 0;
				/* 1-1. Save Loss Data */
				/* Get Max Sequence */
				d_max_seq_num = 0;
				CDB_init_cwipcellos(&CWIPCELLOS);
				TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
				memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_TABBER, strlen(HQCEL_LOSS_CATEGORY_TABBER));

				/* Cell ID */
				TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LAMA_ID");
				if (COM_isnullspace(CWIPCELLOS.CELL_ID) == MP_TRUE)
				{
					TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "STRING_ID");
				}

				TRS.copy(CWIPCELLOS.STRING_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "STRING_ID");
				TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "STRING_ID");
				d_max_seq_num = CDB_select_cwipcellos_scalar(2, &CWIPCELLOS);
				if(DB_error_code != DB_SUCCESS)
				{
					d_max_seq_num = 1;
				}

				/* Insert defect items */
				CDB_init_cwipcellos(&CWIPCELLOS);
				TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
				memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_TABBER, strlen(HQCEL_LOSS_CATEGORY_TABBER));

				TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LAMA_ID");
				if (COM_isnullspace(CWIPCELLOS.CELL_ID) == MP_TRUE)
				{
					TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "STRING_ID");
				}

				TRS.copy(CWIPCELLOS.STRING_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "STRING_ID");
				TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "STRING_ID");

				CWIPCELLOS.LOSS_SEQ = (int)++d_max_seq_num;
				TRS.copy(CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE), CELL_ITEM[j], "REASON_CODE");
				TRS.copy(CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID), in_node, "LINE_ID");
				TRS.copy(CWIPCELLOS.RES_ID, sizeof(CWIPCELLOS.RES_ID), in_node, "RES_ID");
				TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "STRING_ID");
				TRS.copy(CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID), CELL_ITEM[j], "LOC_ID");

				TRS.copy(CWIPCELLOS.RESULT_VALUE, sizeof(CWIPCELLOS.RESULT_VALUE), in_node, "RESULT");
				TRS.copy(CWIPCELLOS.INV_LOT_ID, sizeof(CWIPCELLOS.INV_LOT_ID), in_node, "VMAGAZINE_ID");
				CWIPCELLOS.LOT_HIST_SEQ = 1;
				memcpy(CWIPCELLOS.CREATE_TIME, s_sys_time, sizeof(CWIPCELLOS.CREATE_TIME));
				memcpy(CWIPCELLOS.TRAN_TIME, s_sys_time, sizeof(CWIPCELLOS.TRAN_TIME));

				CWIPCELLOS.INS_CNT = TRS.get_int(tran_out_node, "INS_CNT"); // CEDECLOTRLT.INS_CNT
                   
				if (COM_isspace(CWIPCELLOS.ORDER_ID, sizeof(CWIPCELLOS.ORDER_ID)) == MP_TRUE)
					memcpy(CWIPCELLOS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

				if (memcmp(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_TABBER, strlen(HQCEL_LOSS_CATEGORY_TABBER)) == 0)
				{
					CWIPCELLOS.LOSS_GROUP[0] = CWIPCELLOS.LOT_ID[2]; 
				}

				// Tray 추가
				if (COM_isnullspace(TRS.get_string(in_node, "TRAY_ID")) == MP_FALSE)
				{
					CDB_init_cwiptrysts(&CWIPTRYSTS);
					TRS.copy(CWIPTRYSTS.FACTORY, sizeof(CWIPTRYSTS.FACTORY), in_node, IN_FACTORY);
					TRS.copy(CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID), in_node, "TRAY_ID");
					CDB_select_cwiptrysts(1, &CWIPTRYSTS);

					if(DB_error_code == DB_SUCCESS)
					{
						// CWIPLOTSTR 에 Tray Id 와 SEQ 입력
						memcpy(CWIPCELLOS.CMF_1, CWIPTRYSTS.TRAY_ID, sizeof(CWIPTRYSTS.TRAY_ID));
						COM_itoa_left(CWIPCELLOS.CMF_2, CWIPTRYSTS.SEQ, sizeof(CWIPCELLOS.CMF_2));
					}
				}

				CDB_insert_cwipcellos(&CWIPCELLOS);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
			}
		}
    	
		//CEDCLOTRLT.CMF_2 : 대표불량코드 저장
		{
			struct MGCMTBLDAT_TAG MGCMTBLDAT_L;
			struct CEDCLOTRLT_TAG CEDCLOTRLT_L;
			struct CEDCLOTRLH_TAG CEDCLOTRLH_L;
			char c_t_update_flag = 'Y';
			
			CDB_init_cedclotrlt(&CEDCLOTRLT_L);
			TRS.copy(CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY), in_node, "FACTORY");
			TRS.copy(CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLT_L.LOT_ID), in_node, "STRING_ID");
			memcpy(CEDCLOTRLT_L.INS_TYPE, HQCEL_LOSS_CATEGORY_TABBER, strlen(HQCEL_LOSS_CATEGORY_TABBER));
			CDB_select_cedclotrlt(1, &CEDCLOTRLT_L);
			if(DB_error_code != DB_SUCCESS)
			{
				c_t_update_flag = 'N';
			}

			CDB_init_mgcmtbldat(&MGCMTBLDAT_L);
			memcpy(MGCMTBLDAT_L.FACTORY, CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY));
			memcpy(MGCMTBLDAT_L.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
			memcpy(MGCMTBLDAT_L.KEY_3,CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLT_L.LOT_ID));  //LOT ID ( STRING_ID)
			if (MRASRESDEF.RES_CMF_14[0] == 'Y')
			{
				memcpy(MGCMTBLDAT_L.KEY_2, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)); //OPER
			}
			else
			{
				memcpy(MGCMTBLDAT_L.KEY_2,MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2)); //OPER
			}
			
			memcpy(MGCMTBLDAT_L.DATA_1,CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLT_L.INS_TYPE)); //INSPECTION TYPE
			COM_itoa_left(MGCMTBLDAT_L.DATA_2,CEDCLOTRLT_L.INS_CNT, sizeof(MGCMTBLDAT_L.DATA_2)); //INSPECTION COUNT
			CDB_select_mgcmtbldat(3, &MGCMTBLDAT_L);
			if(DB_error_code != DB_SUCCESS)
			{
				 memset(MGCMTBLDAT_L.KEY_1, ' ' , sizeof(MGCMTBLDAT_L.KEY_1));
			}

			//CEDCLOTRLT UPDATE CMF_2 : 대표불량코드
			memcpy(CEDCLOTRLT_L.CMF_2, MGCMTBLDAT_L.KEY_1, sizeof(CEDCLOTRLT_L.CMF_2)); //대표불량코드
			CDB_update_cedclotrlt(2, &CEDCLOTRLT_L);
			if(DB_error_code != DB_SUCCESS)
			{
				c_t_update_flag = 'N';
			}

			//CEDCLOTRLH UPDATE CMF_2 : 대표불량코드
			CDB_init_cedclotrlh(&CEDCLOTRLH_L);
			memcpy(CEDCLOTRLH_L.FACTORY, CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY));
			memcpy(CEDCLOTRLH_L.LOT_ID, CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLH_L.LOT_ID));
			memcpy(CEDCLOTRLH_L.INS_TYPE, CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLH_L.INS_TYPE));
			CEDCLOTRLH_L.INS_CNT = CEDCLOTRLT_L.INS_CNT;
			memcpy(CEDCLOTRLH_L.CMF_2, MGCMTBLDAT_L.KEY_1, sizeof(CEDCLOTRLH_L.CMF_2)); //대표불량코드
			CDB_update_cedclotrlh(2, &CEDCLOTRLH_L);
			if(DB_error_code != DB_SUCCESS)
			{
				c_t_update_flag = 'N';
			}
			

		}
	}
	
	TRS.free_node(tran_in_node);
	TRS.free_node(tran_out_node);

	
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_String_Validation()
        - Main sub function of "EAPMES_COLLECT_INSPECTION_DATA_STRING" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_String_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

