/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_resource_data.c
    Description : EAPMES Collect Resource Data Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Resource_Data()
            + Setup service interface function
        - EAPMES_COLLECT_RESOURCE_DATA()
            + Main sub function of EAPMES_Collect_Resource_Data function
            + Setup service main business function
        - EAPMES_Collect_Resource_Data_Validation()
            + Main sub function of EAPMES_COLLECT_RESOURCE_DATA function
    Detail Description
        - EAPMES_COLLECT_RESOURCE_DATA()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Resource_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Resource_Data()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Resource_Data(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_RESOURCE_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_RESOURCE_DATA", out_node);

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
    EAPMES_COLLECT_RESOURCE_DATA()
        - Main sub function of "EAPMES_Collect_Resource_Data" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_RESOURCE_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CRASPRCDAT_TAG CRASPRCDAT;
	struct CRASPRCDAT_MOSTUP_TAG CRASPRCDAT_MOSTUP;
	struct CRASPRCDAT_MOSTUP_TAG CRASPRCDAT_MOSTUP2;
	struct CRASPRCDAT_MOSTUP_TAG CRASPRCDAT_MOSTUP3;
	struct CRASPRCDAT_MOSTUP_TAG CRASPRCDAT_MOSTUPTEMP;
	
	struct CRASPRCDAT_ALERT_TAG CRASPRCDAT_ALERT;

	struct CGCMTBLDAT_TAG CGCMTBLDAT_LF_UPPER_CHMB_PRESS;
	struct CGCMTBLDAT_TAG CGCMTBLDAT_LF_DOWN_CHMB_PRESS;

	struct CGCMTBLDAT_TAG CGCMTBLDAT_FDC_ALERT_2;


	double  prev_value ;
	double  curr_value ;
	float  cal_value = 0;
	float curr_seqnum = 0;

	float  prev_master = 0;
	double  curr_master ;
	float  cal_master = 0;
	float  cal_value_master = 0;		//cal_value 계산을 위한 CGCMTBLDAT.DATA_4



	char lv_LF_MODULE_ID_1[25];
	char lv_LF_MODULE_ID_2[25];
	char lv_LF_MODULE_ID_3[25];
	char lv_LF_MODULE_ID_4[25];
	char tmp_PARAM_VALUE[100];




	int i,j;
	
	double d_param_count;  //2025.03.18 FDC 로직 개발 검토


	TRSNode ** PARAM_LIST;
    TRSNode ** PARAM_ITEM;

	int i_param_list_count;
    int i_param_item_count;

    LOG_head("EAPMES_COLLECT_RESOURCE_DATA");
    //TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(lv_LF_MODULE_ID_1, ' ', sizeof(lv_LF_MODULE_ID_1));
	memset(lv_LF_MODULE_ID_2, ' ', sizeof(lv_LF_MODULE_ID_2));
	memset(lv_LF_MODULE_ID_3, ' ', sizeof(lv_LF_MODULE_ID_3));
	memset(lv_LF_MODULE_ID_4, ' ', sizeof(lv_LF_MODULE_ID_4));

/*
    if(EAPMES_Collect_Resource_Data_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
*/
	
	//*FDC 계산 값 변수 처리[25.03.31]  *//
	CDB_init_cgcmtbldat(&CGCMTBLDAT_LF_UPPER_CHMB_PRESS);
 	memcpy(CGCMTBLDAT_LF_UPPER_CHMB_PRESS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CGCMTBLDAT_LF_UPPER_CHMB_PRESS.TYPE_1, "FDC_ALERT_1", strlen("FDC_ALERT_1"));
	memcpy(CGCMTBLDAT_LF_UPPER_CHMB_PRESS.TYPE_2, "LF_UPPER_CHMB_PRESS", strlen("LF_UPPER_CHMB_PRESS"));	
	CDB_select_cgcmtbldat(1, &CGCMTBLDAT_LF_UPPER_CHMB_PRESS);
	if(DB_error_code != DB_SUCCESS)
	{
	
	}

	CDB_init_cgcmtbldat(&CGCMTBLDAT_FDC_ALERT_2);		//FDC ALERT2 마스터 조회
 	memcpy(CGCMTBLDAT_FDC_ALERT_2.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CGCMTBLDAT_FDC_ALERT_2.TYPE_1, "FDC_ALERT_2", strlen("FDC_ALERT_2"));
	memcpy(CGCMTBLDAT_FDC_ALERT_2.TYPE_2, TRS.get_string(in_node, "RES_ID"), strlen(TRS.get_string(in_node, "RES_ID")));
	cal_value_master = 0;
	CDB_select_cgcmtbldat(1, &CGCMTBLDAT_FDC_ALERT_2);
	if(DB_error_code == DB_SUCCESS)
	{
		cal_value_master = COM_atof(CGCMTBLDAT_FDC_ALERT_2.DATA_1, sizeof(CGCMTBLDAT_FDC_ALERT_2.DATA_1));
	}

	

	CDB_init_cgcmtbldat(&CGCMTBLDAT_LF_DOWN_CHMB_PRESS);
	memcpy(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.TYPE_1, "FDC_ALERT_1", strlen("FDC_ALERT_1"));
	memcpy(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.TYPE_2, "LF_DOWN_CHMB_PRESS", strlen("LF_DOWN_CHMB_PRESS"));
	CDB_select_cgcmtbldat(1, &CGCMTBLDAT_LF_DOWN_CHMB_PRESS);
	if(DB_error_code != DB_SUCCESS)
	{
	
	}

	//*FDC 계산 값 변수 처리[25.03.31]  *//

	PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");

    for(i = 0; i < i_param_list_count; i++)
    {

		 PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
        i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");

        for(j = 0; j < i_param_item_count; j++)
        {
			/* Insert */
			CDB_init_crasprcdat(&CRASPRCDAT);
			TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), PARAM_ITEM[j], "RES_ID");
			TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
			TRS.copy(CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.TRAN_TIME), PARAM_ITEM[j], "TRAN_TIME");
			TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), PARAM_ITEM[j], "LOT_ID");
			CRASPRCDAT.SEQ_NUM = TRS.get_int(PARAM_ITEM[j],"SEQ_NUM");
			TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), PARAM_ITEM[j], "FACTORY");
			TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), PARAM_ITEM[j], "LINE_ID");
			TRS.copy(CRASPRCDAT.OPER, sizeof(CRASPRCDAT.OPER), PARAM_ITEM[j], "OPER");
			CRASPRCDAT.LOT_HIST_SEQ = TRS.get_int(PARAM_ITEM[j],"LOT_HIST_SEQ");
			
			TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");

			TRS.copy(CRASPRCDAT.CREATE_TIME, sizeof(CRASPRCDAT.CREATE_TIME), PARAM_ITEM[j], "CREATE_TIME");
			TRS.copy(CRASPRCDAT.CMF_1, sizeof(CRASPRCDAT.CMF_1), PARAM_ITEM[j], "CMF_1");
			TRS.copy(CRASPRCDAT.CMF_2, sizeof(CRASPRCDAT.CMF_2), PARAM_ITEM[j], "CMF_2");
			TRS.copy(CRASPRCDAT.CMF_3, sizeof(CRASPRCDAT.CMF_3), PARAM_ITEM[j], "CMF_3");
			TRS.copy(CRASPRCDAT.CMF_4, sizeof(CRASPRCDAT.CMF_4), PARAM_ITEM[j], "CMF_4");
			TRS.copy(CRASPRCDAT.CMF_5, sizeof(CRASPRCDAT.CMF_5), PARAM_ITEM[j], "CMF_5");

			//°ªÀÌ ¾øÀ¸¸é ÀúÀå¾ÈÇÔ. µ¥ÀÌÅÍ°¡ ³Ê¹«¸¹À½.
			if (COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) == MP_TRUE)
			{
				continue;
			}

			CDB_insert_crasprcdat_use_partition(&CRASPRCDAT);
			if(DB_error_code != DB_SUCCESS)
			{
                //Nothing
				LOG_head("ERROR CDB_insert_crasprcdat_use_partition ");
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}


			//2025.03.18 FDC 로직 개발 검토 - Start
						if(
			(	
			memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-01", strlen("US-E4-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-01", strlen("US-E5-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-01", strlen("US-E6-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-01", strlen("US-E7-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-02", strlen("US-E4-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-02", strlen("US-E5-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-02", strlen("US-E6-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-02", strlen("US-E7-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-03", strlen("US-E4-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-03", strlen("US-E5-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-03", strlen("US-E6-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-03", strlen("US-E7-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-04", strlen("US-E4-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-04", strlen("US-E5-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-04", strlen("US-E6-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-04", strlen("US-E7-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-04", strlen("US-E1-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-04", strlen("US-E2-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-04", strlen("US-E3-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-03", strlen("US-E1-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-03", strlen("US-E2-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-03", strlen("US-E3-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-02", strlen("US-E1-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-02", strlen("US-E2-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-02", strlen("US-E3-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-01", strlen("US-E1-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-01", strlen("US-E2-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-01", strlen("US-E3-LF-01")) == 0
			
			)
			&&
			(
			memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_1", strlen("LF_MODULE_ID_1")) == 0
			||
			memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_2", strlen("LF_MODULE_ID_2")) == 0
			||
			memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_3", strlen("LF_MODULE_ID_3")) == 0
			||
			memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_4", strlen("LF_MODULE_ID_4")) == 0
			)
			)
			{
				if(memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_1", strlen("LF_MODULE_ID_1")) == 0)
				{
					memset(lv_LF_MODULE_ID_1, ' ', sizeof(lv_LF_MODULE_ID_1));
					TRS.copy(lv_LF_MODULE_ID_1, 25, PARAM_ITEM[j], "PARAM_VALUE");
				}
				
				if(memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_2", strlen("LF_MODULE_ID_2")) == 0)
				{
					memset(lv_LF_MODULE_ID_2, ' ', sizeof(lv_LF_MODULE_ID_2));
					TRS.copy(lv_LF_MODULE_ID_2, 25, PARAM_ITEM[j], "PARAM_VALUE");
				}

				if(memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_3", strlen("LF_MODULE_ID_3")) == 0)
				{
					memset(lv_LF_MODULE_ID_3, ' ', sizeof(lv_LF_MODULE_ID_3));
					TRS.copy(lv_LF_MODULE_ID_3, 25, PARAM_ITEM[j], "PARAM_VALUE");
				}

				if(memcmp(CRASPRCDAT.PARAM_NAME, "LF_MODULE_ID_4", strlen("LF_MODULE_ID_4")) == 0)
				{
					memset(lv_LF_MODULE_ID_4, ' ', sizeof(lv_LF_MODULE_ID_4));
					TRS.copy(lv_LF_MODULE_ID_4, 25, PARAM_ITEM[j], "PARAM_VALUE");
				}



				//Moddule name 
			}


			if(
			(	
			memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-01", strlen("US-E4-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-01", strlen("US-E5-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-01", strlen("US-E6-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-01", strlen("US-E7-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-02", strlen("US-E4-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-02", strlen("US-E5-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-02", strlen("US-E6-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-02", strlen("US-E7-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-03", strlen("US-E4-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-03", strlen("US-E5-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-03", strlen("US-E6-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-03", strlen("US-E7-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E4-LF-04", strlen("US-E4-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E5-LF-04", strlen("US-E5-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E6-LF-04", strlen("US-E6-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E7-LF-04", strlen("US-E7-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-04", strlen("US-E1-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-04", strlen("US-E2-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-04", strlen("US-E3-LF-04")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-03", strlen("US-E1-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-03", strlen("US-E2-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-03", strlen("US-E3-LF-03")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-02", strlen("US-E1-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-02", strlen("US-E2-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-02", strlen("US-E3-LF-02")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E1-LF-01", strlen("US-E1-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E2-LF-01", strlen("US-E2-LF-01")) == 0
			|| memcmp(CRASPRCDAT.RES_ID, "US-E3-LF-01", strlen("US-E3-LF-01")) == 0
			)
			&&
			(
			//memcmp(CRASPRCDAT.PARAM_NAME, "LF_UPPER_CHMB_PRESS", strlen("LF_UPPER_CHMB_PRESS")) == 0
			//||
			memcmp(CRASPRCDAT.PARAM_NAME, "LF_DOWN_CHMB_PRESS", strlen("LF_DOWN_CHMB_PRESS")) == 0

			)
			)
				{
				
					CDB_init_crasprcdat_mostup(&CRASPRCDAT_MOSTUP);
					TRS.copy(CRASPRCDAT_MOSTUP.RES_ID, sizeof(CRASPRCDAT_MOSTUP.RES_ID), PARAM_ITEM[j], "RES_ID");
					TRS.copy(CRASPRCDAT_MOSTUP.PARAM_NAME, sizeof(CRASPRCDAT_MOSTUP.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
					TRS.copy(CRASPRCDAT_MOSTUP.TRAN_TIME, sizeof(CRASPRCDAT_MOSTUP.TRAN_TIME), PARAM_ITEM[j], "TRAN_TIME");
					TRS.copy(CRASPRCDAT_MOSTUP.LOT_ID, sizeof(CRASPRCDAT_MOSTUP.LOT_ID), PARAM_ITEM[j], "LOT_ID");
					//CRASPRCDAT_MOSTUP.SEQ_NUM = TRS.get_int(PARAM_ITEM[j],"SEQ_NUM");
					TRS.copy(CRASPRCDAT_MOSTUP.FACTORY, sizeof(CRASPRCDAT_MOSTUP.FACTORY), PARAM_ITEM[j], "FACTORY");
					TRS.copy(CRASPRCDAT_MOSTUP.LINE_ID, sizeof(CRASPRCDAT_MOSTUP.LINE_ID), PARAM_ITEM[j], "LINE_ID");
					TRS.copy(CRASPRCDAT_MOSTUP.OPER, sizeof(CRASPRCDAT_MOSTUP.OPER), PARAM_ITEM[j], "OPER");
					//CRASPRCDAT_MOSTUP.LOT_HIST_SEQ = TRS.get_int(PARAM_ITEM[j],"LOT_HIST_SEQ");
					TRS.copy(CRASPRCDAT_MOSTUP.PARAM_VALUE, sizeof(CRASPRCDAT_MOSTUP.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
					TRS.copy(CRASPRCDAT_MOSTUP.CREATE_TIME, sizeof(CRASPRCDAT_MOSTUP.CREATE_TIME), PARAM_ITEM[j], "CREATE_TIME");

				/*	TRS.copy(CRASPRCDAT_MOSTUP.CMF_1, sizeof(CRASPRCDAT_MOSTUP.CMF_1), PARAM_ITEM[j], "CMF_1");
					TRS.copy(CRASPRCDAT_MOSTUP.CMF_2, sizeof(CRASPRCDAT_MOSTUP.CMF_2), PARAM_ITEM[j], "CMF_2");
					TRS.copy(CRASPRCDAT_MOSTUP.CMF_3, sizeof(CRASPRCDAT_MOSTUP.CMF_3), PARAM_ITEM[j], "CMF_3");
					TRS.copy(CRASPRCDAT_MOSTUP.CMF_4, sizeof(CRASPRCDAT_MOSTUP.CMF_4), PARAM_ITEM[j], "CMF_4");
					TRS.copy(CRASPRCDAT_MOSTUP.CMF_5, sizeof(CRASPRCDAT_MOSTUP.CMF_5), PARAM_ITEM[j], "CMF_5");*/
					memcpy(CRASPRCDAT_MOSTUP.CMF_1, lv_LF_MODULE_ID_1, 25);
					memcpy(CRASPRCDAT_MOSTUP.CMF_2, lv_LF_MODULE_ID_2, 25);
					memcpy(CRASPRCDAT_MOSTUP.CMF_3, lv_LF_MODULE_ID_3, 25);
					memcpy(CRASPRCDAT_MOSTUP.CMF_4, lv_LF_MODULE_ID_4, 25);
					
					//CRASPRCDAT_MOSTUP.SEQ_NUM = CRASPRCDAT_MOSTUP.SEQ_NUM + 1;

					if (COM_isspace(CRASPRCDAT_MOSTUP.PARAM_VALUE, sizeof(CRASPRCDAT_MOSTUP.PARAM_VALUE)) == MP_TRUE)
					{
						continue;
					}

					d_param_count = 0;
					
					//알람 조건을 위해 로직 수행
					CDB_init_crasprcdat_mostup(&CRASPRCDAT_MOSTUP2);
					TRS.copy(CRASPRCDAT_MOSTUP2.RES_ID, sizeof(CRASPRCDAT_MOSTUP2.RES_ID), PARAM_ITEM[j], "RES_ID");
					memcpy(CRASPRCDAT_MOSTUP2.PARAM_NAME, "LF_DOWN_CHMB_PRESS_PREV", sizeof(CRASPRCDAT_MOSTUP.PARAM_VALUE));

					CDB_select_crasprcdat_mostup(2, &CRASPRCDAT_MOSTUP2);
					if(DB_error_code == DB_SUCCESS)
					{
						if (COM_isnullspace(CRASPRCDAT_MOSTUP2.PARAM_VALUE) == MP_FALSE)
						{
							memset(tmp_PARAM_VALUE, ' ', sizeof(tmp_PARAM_VALUE));
							prev_value = COM_atof(CRASPRCDAT_MOSTUP2.PARAM_VALUE, sizeof(CRASPRCDAT_MOSTUP2.PARAM_VALUE)) * 1000;
							memcpy(tmp_PARAM_VALUE, CRASPRCDAT_MOSTUP2.PARAM_VALUE, sizeof(CRASPRCDAT_MOSTUP2.PARAM_VALUE));
					
						}
					}
					//현재 값 조회
					if (COM_isnullspace(CRASPRCDAT_MOSTUP.PARAM_VALUE) == MP_FALSE)
					{

						curr_value = COM_atof(CRASPRCDAT_MOSTUP.PARAM_VALUE,sizeof(CRASPRCDAT_MOSTUP.PARAM_VALUE)) * 1000;
						

					}
					//마스터 조회
					if(memcmp(CRASPRCDAT.PARAM_NAME, "LF_DOWN_CHMB_PRESS", strlen("LF_DOWN_CHMB_PRESS")) == 0)
					{
							prev_master = COM_atof(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.DATA_1, sizeof(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.DATA_1));
							cal_master = COM_atof(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.DATA_2, sizeof(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.DATA_2));
							curr_master = COM_atof(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.DATA_3, sizeof(CGCMTBLDAT_LF_DOWN_CHMB_PRESS.DATA_3)) * 1000;
					}



					d_param_count = CDB_select_crasprcdat_mostup_scalar(2, &CRASPRCDAT_MOSTUP);//RES_ID 데이터가 없다면

					if(d_param_count > 0)		//데이터가 존재 하면 업데이트
					{	
		

						d_param_count = 0;
						
						d_param_count = CDB_select_crasprcdat_mostup_scalar(3, &CRASPRCDAT_MOSTUP);//동일 모듈 아이디가 있다면
						if(d_param_count < 1)		//신규
						{	
							//CRASPRCDAT_MOSTUP.SEQ_NUM = 1;
							CDB_update_crasprcdat_mostup(3,&CRASPRCDAT_MOSTUP);
							continue;
							
						}
						else						//기존 데이터 업데이트
						{	
								CDB_init_crasprcdat_mostup(&CRASPRCDAT_MOSTUP2);
								TRS.copy(CRASPRCDAT_MOSTUP2.RES_ID, sizeof(CRASPRCDAT_MOSTUP2.RES_ID), PARAM_ITEM[j], "RES_ID");
								memcpy(CRASPRCDAT_MOSTUP2.PARAM_NAME, "LF_DOWN_CHMB_PRESS", sizeof(CRASPRCDAT_MOSTUP.PARAM_VALUE));

								CDB_select_crasprcdat_mostup(2, &CRASPRCDAT_MOSTUP2);
								if(DB_error_code == DB_SUCCESS)
								{
									
								}
								//저장 횟수가 마스터보다 크다면 pass
								if(cal_value_master < CRASPRCDAT_MOSTUP2.SEQ_NUM + 1 )
								{	
									continue;
								}

							CDB_update_crasprcdat_mostup(2,&CRASPRCDAT_MOSTUP);
						}

						if(DB_error_code != DB_SUCCESS)
						{
							LOG_head("ERROR CDB_update_crasprcdat_mostup ");
						}


					}
					else						// 초기 데이터 인경우
					{
						CRASPRCDAT_MOSTUP.SEQ_NUM = 1;
						CDB_insert_crasprcdat_mostup(&CRASPRCDAT_MOSTUP);
						if(DB_error_code != DB_SUCCESS)
						{
							LOG_head("ERROR CDB_insert_crasprcdat_mostup ");
						}
						continue;
					}


					//Pin up time 보다 체크 
					//알람 조건을 위해 로직 수행
					CDB_init_crasprcdat_mostup(&CRASPRCDAT_MOSTUP2);
					TRS.copy(CRASPRCDAT_MOSTUP2.RES_ID, sizeof(CRASPRCDAT_MOSTUP2.RES_ID), PARAM_ITEM[j], "RES_ID");
					TRS.copy(CRASPRCDAT_MOSTUP2.PARAM_NAME, sizeof(CRASPRCDAT_MOSTUP2.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
					CDB_select_crasprcdat_mostup(2, &CRASPRCDAT_MOSTUP2);

					if(DB_error_code == DB_SUCCESS)
					{
						curr_seqnum = CRASPRCDAT_MOSTUP2.SEQ_NUM;
						

						if(cal_value_master  == curr_seqnum  )		//저장 횟수 체크
						{

							//저장 횟수가 같으면 이전 데이터로 저장
							CRASPRCDAT_MOSTUP.SEQ_NUM = curr_seqnum;
							memcpy(CRASPRCDAT_MOSTUP.PARAM_NAME, "LF_DOWN_CHMB_PRESS_PREV", sizeof(CRASPRCDAT_MOSTUP.PARAM_VALUE));
							CDB_delete_crasprcdat_mostup(2,&CRASPRCDAT_MOSTUP);
							CDB_insert_crasprcdat_mostup(&CRASPRCDAT_MOSTUP);
							

							//저장 횟수가 같으면 이전 데이터로 저장

							if(curr_master < curr_value)		
							{
								if(prev_value < 0 || prev_value == 0)
								{
									continue;
								}
								if(curr_value < prev_value)	//이전 값보다 작으면 pass
								{
									continue;
								}

								if(curr_value == prev_value)	//이전값과 같으면 패스
								{
									continue;
								}

								

							CDB_init_crasprcdat_alert(&CRASPRCDAT_ALERT);
							
							TRS.copy(CRASPRCDAT_ALERT.FACTORY, sizeof(CRASPRCDAT_ALERT.FACTORY), PARAM_ITEM[j], "FACTORY");
							TRS.copy(CRASPRCDAT_ALERT.RES_ID, sizeof(CRASPRCDAT_ALERT.RES_ID), PARAM_ITEM[j], "RES_ID");
							TRS.copy(CRASPRCDAT_ALERT.PARAM_NAME, sizeof(CRASPRCDAT_ALERT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
							TRS.copy(CRASPRCDAT_ALERT.TRAN_TIME, sizeof(CRASPRCDAT_MOSTUP.TRAN_TIME), PARAM_ITEM[j], "TRAN_TIME");						
							//memcpy(CRASPRCDAT_ALERT.PREV_VALUE, CRASPRCDAT_MOSTUP3.PARAM_VALUE, sizeof(CRASPRCDAT_MOSTUP3.PARAM_VALUE));
							
							
							//COM_ltoa_left(CRASPRCDAT_ALERT.PREV_VALUE, prev_value, sizeof(CRASPRCDAT_ALERT.PREV_VALUE));
							//_snprintf(CRASPRCDAT_ALERT.PREV_VALUE, sizeof(CRASPRCDAT_ALERT.PREV_VALUE), "%f", prev_value);

							memcpy(CRASPRCDAT_ALERT.PREV_VALUE, tmp_PARAM_VALUE, sizeof(tmp_PARAM_VALUE));
	

							TRS.copy(CRASPRCDAT_ALERT.CURR_VALUE, sizeof(CRASPRCDAT_ALERT.CURR_VALUE), PARAM_ITEM[j], "PARAM_VALUE");

							memcpy(CRASPRCDAT_ALERT.MODULE_ID_1, lv_LF_MODULE_ID_1, 25);
							memcpy(CRASPRCDAT_ALERT.MODULE_ID_2, lv_LF_MODULE_ID_2, 25);
							memcpy(CRASPRCDAT_ALERT.MODULE_ID_3, lv_LF_MODULE_ID_3, 25);
							memcpy(CRASPRCDAT_ALERT.MODULE_ID_4, lv_LF_MODULE_ID_4, 25);

							CRASPRCDAT_ALERT.ALERT_FLAG = 'N';

							CDB_insert_crasprcdat_alert(&CRASPRCDAT_ALERT);
							}

						}
					}


					

					//CDB_insert_crasprcdat_alert


			}
			//2025.03.18 FDC 로직 개발 검토 - End




		}
	}
   
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Resource_Data_Validation()
        - Main sub function of "EAPMES_COLLECT_RESOURCE_DATA" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Resource_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
   //struct MWIPFACDEF_TAG MWIPFACDEF;

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

    /*
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

