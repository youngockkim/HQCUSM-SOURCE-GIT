/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_inspection_data.c
    Description : EAPMES Collect Inspection Data Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Inspection_Data()
            + Setup service interface function
        - EAPMES_COLLECT_INSPECTION_DATA()
            + Main sub function of EAPMES_Collect_Inspection_Data function
            + Setup service main business function
        - EAPMES_Collect_Inspection_Data_Validation()
            + Main sub function of EAPMES_COLLECT_INSPECTION_DATA function
    Detail Description
        - EAPMES_COLLECT_INSPECTION_DATA()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created1

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/
#include "CUS_HQCUSM_common.h"
#include "CUS_common.h"

int EAPMES_Collect_Inspection_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int Send_CTM_Summary(char* s_msg_code, char* s_sys_time, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
    EAPMES_Collect_Inspection_Data()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

	TRS.set_char(in_node, "_ZPROCSTEP", TRS.get_char(in_node, "PROCSTEP"));
	TRS.set_char(in_node, "PROCSTEP", '1');
	

    i_ret = EAPMES_COLLECT_INSPECTION_DATA(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_INSPECTION_DATA", out_node);

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

	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Collect_Inspection_Data", 
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
    EAPMES_COLLECT_INSPECTION_DATA()
        - Main sub function of "EAPMES_Collect_Inspection_Data" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_INSPECTION_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
    //struct MRASRESMFO_TAG MRASRESMFO;
    struct CWIPCELLOS_TAG CWIPCELLOS;
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CWIPLOTTRC_TAG CWIPLOTTRC;
	struct CWIPLOTTRC_TAG CWIPLOTTRC_ALARM;
    struct MWIPELTSTS_TAG MWIPELTSTS;
    struct MWIPELTHIS_TAG MWIPELTHIS;
    struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
    //struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CWIPLOTSTR_TAG CWIPLOTSTR;
	struct CEDCINSDAT_TAG CEDCINSDAT;
//	struct MWIPMATDEF_TAG MWIPMATDEF;
//    struct CEDCLOTAOI_TAG CEDCLOTAOI;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_SIM;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_GRT;
	struct MSPCCHTDEF_TAG MSPCCHTDEF;
	struct CALMTLGHIS_TAG CALMTLGHIS;
	struct CWIPPMPHIS_TAG CWIPPMPHIS;
//	struct CEDCLOTRLH_TAG CEDCLOTRLH_A;
//	struct MEDCCHRDEF_TAG MEDCCHRDEF;
	struct CWIPGRTAVG_TAG CWIPGRTAVG;

    char s_sys_time_stamp[20];  
    char s_sys_time[17];
    int i, j;
    double d_max_seq_num;
    int i_ins_cnt;
	double compare_pmpp = 0;
	double compare_diode = 0;


    char message[500];
	/*
	char *res = (char*)malloc(sizeof(char) * (20 + 1));
	char *pmpp = (char*)malloc(sizeof(char) * (20 + 1));
	char *diode = (char*)malloc(sizeof(char) * (20 + 1));
	char *lotId = (char*)malloc(sizeof(char) * (20 + 1));
	char *yyyy = (char*)malloc(sizeof(char) * (4 + 1));
	char *MM = (char*)malloc(sizeof(char) * (2 + 1));
	char *dd = (char*)malloc(sizeof(char) * (2 + 1));
	char *hh = (char*)malloc(sizeof(char) * (2 + 1));
	char *mm = (char*)malloc(sizeof(char) * (2 + 1));
	char *ss = (char*)malloc(sizeof(char) * (2 + 1));
	char *workDate = (char*)malloc(sizeof(char) * (8 + 1));
	char *workTime = (char*)malloc(sizeof(char) * (6 + 1));
	*/
	// 20210810 MES Application Memory leak 점검 및 수정
	// Change to local variable in malloc
	char res[20+1];
	char pmpp[20+1];
	char diode[20+1];
	char lotId[20+1];
	char yyyy[4+1];
	char MM[2+1];
	char dd[2+1];
	char hh[2+1];
	char mm[2+1];
	char ss[2+1];
	char workDate[8+1];
	char workTime[6+1];
	
	// IS-21-04-006 Update Request for Cold Soldering Telegram Alert
	int i_pmppStatusFlag = 0;

	// Modify to specify the maximum size of alarm transmission data
	int i_AlarmDataMaxsize = 0;
	
    int i_defect_list_count;
    int i_defect_item_count;
    int i_param_list_count;
    int i_param_item_count;
//	int i_max_ins_seq;

	int re_cnt;

	char s_lr_flag[5] ;
	int b_exist_pmpp = MP_FALSE;
	
    TRSNode ** DEFECT_LIST;
    TRSNode ** DEFECT_ITEM;
    TRSNode ** PARAM_LIST;
    TRSNode ** PARAM_ITEM;

    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

	TRSNode* spc_in_node;
	TRSNode* spc_out_node;
	TRSNode* list_item;
	TRSNode* list_param;

    LOG_head("EAPMES_COLLECT_INSPECTION_DATA");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


	// 20210810 MES Application Memory leak 점검 및 수정
	// Change to local variable in malloc
	memset(res, 0x00, sizeof(res));
	memset(pmpp, 0x00, sizeof(pmpp));
	memset(diode, 0x00, sizeof(diode));
	memset(lotId, 0x00, sizeof(lotId));
	memset(yyyy, 0x00, sizeof(yyyy));
	memset(MM, 0x00, sizeof(MM));
	memset(dd, 0x00, sizeof(dd));
	memset(hh, 0x00, sizeof(hh));
	memset(mm, 0x00, sizeof(mm));
	memset(ss, 0x00, sizeof(ss));
	memset(workDate, 0x00, sizeof(workDate));
	memset(workTime, 0x00, sizeof(workTime));


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

	memset(s_lr_flag, ' ' , 5);
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));

    /* Get Lot Info */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
       //DO NOTHING
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

    //GRT ONLY
    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_GROUND_TEST_OPER, strlen(HQCEL_M1_GROUND_TEST_OPER)) == 0)
    {
		if(strcmp(TRS.get_string(in_node, "RESULT"), "NG") == 0)
		{

			CDB_init_cedclotrlt(&CEDCLOTRLT_GRT);
			memcpy(CEDCLOTRLT_GRT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

			//20201002 HCHKIM CWIPGRTAVG CHECK
			CDB_init_cwipgrtavg(&CWIPGRTAVG);
			memcpy(CWIPGRTAVG.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(CWIPGRTAVG.MAT_ID));
			
			CDB_select_cwipgrtavg(1, &CWIPGRTAVG);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					CDB_select_cedclotrlt(3, &CEDCLOTRLT_GRT);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
				}
			}
			else
			{
				memcpy(CEDCLOTRLT_GRT.CMF_1, CWIPGRTAVG.STEP_1_MEASURE, sizeof(CEDCLOTRLT_GRT.CMF_1));
				memcpy(CEDCLOTRLT_GRT.CMF_2, CWIPGRTAVG.STEP_2_MEASURE, sizeof(CEDCLOTRLT_GRT.CMF_2));
				memcpy(CEDCLOTRLT_GRT.CMF_3, CWIPGRTAVG.STEP_3_MEASURE, sizeof(CEDCLOTRLT_GRT.CMF_3));
				memcpy(CEDCLOTRLT_GRT.CMF_4, CWIPGRTAVG.STEP_4_MEASURE, sizeof(CEDCLOTRLT_GRT.CMF_4));
			}
			//CEDCLOTRLT_GRT.CMF_1 - I_GRD_01_STEP_1_MEASURE_OHM
			//CEDCLOTRLT_GRT.CMF_2 - I_GRD_01_STEP_2_MEASURE_OHM
			//CEDCLOTRLT_GRT.CMF_3 - I_GRD_01_STEP_3_MEASURE_OHM
			//CEDCLOTRLT_GRT.CMF_4 - I_GRD_01_STEP_4_MEASURE_OHM
		}
			
    }

    /* Parameter List */
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
            TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "LOT_ID");
            TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
            memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));

            d_max_seq_num = CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }

            /* Insert */
            CDB_init_cedcinsdat(&CEDCINSDAT);
            TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "LOT_ID");
            TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
            memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
            CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
            TRS.copy(CEDCINSDAT.FACTORY, sizeof(CEDCINSDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CEDCINSDAT.LINE_ID, sizeof(CEDCINSDAT.LINE_ID), in_node, "LINE_ID");
            memcpy(CEDCINSDAT.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
            CEDCINSDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
            TRS.copy(CEDCINSDAT.PARAM_NAME, sizeof(CEDCINSDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");


            //GRT
            if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_GROUND_TEST_OPER, strlen(HQCEL_M1_GROUND_TEST_OPER)) == 0)
            {
				//NG only
				if(strcmp(TRS.get_string(in_node, "RESULT"), "NG") == 0)
				{
					//if the parameter name ends with _RESULT
					if(strstr(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "_RESULT") != NULL)
					{
						//if parameter name is step 4 
						if(strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_GRD_01_STEP_4_RESULT") == 0)
						{
							//if average has the step 4 value
							if(CEDCLOTRLT_GRT.CMF_4[0] != '\0')
							{
								memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
							}
						}
						else
						{
							memcpy(CEDCINSDAT.PARAM_VALUE, "0", sizeof("0"));
						}
					}
					else if(strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_GRD_01_STEP_1_MEASURE_OHM") == 0)
					{
						memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_GRT.CMF_1, sizeof(CEDCLOTRLT_GRT.CMF_1));
					}
					else if(strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_GRD_01_STEP_2_MEASURE_OHM") == 0)
					{
						memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_GRT.CMF_2, sizeof(CEDCLOTRLT_GRT.CMF_2));
					}
					else if(strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_GRD_01_STEP_3_MEASURE_OHM") == 0)
					{
						memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_GRT.CMF_3, sizeof(CEDCLOTRLT_GRT.CMF_3));
					}
					else if(strcmp(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"), "I_GRD_01_STEP_4_MEASURE_OHM") == 0)
					{
						memcpy(CEDCINSDAT.PARAM_VALUE, CEDCLOTRLT_GRT.CMF_4, sizeof(CEDCLOTRLT_GRT.CMF_4));
					}
				}
				else
				{
					TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
				}
            }
            else
            {
                TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
            }

            CDB_insert_cedcinsdat(&CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //DO NOTHING
            }
        }
    }

    /* Save Parameter Data */
    // param_list°¡ ÀÖÀ» ¶§¸¸ commit ÇÏµµ·Ï ¼öÁ¤.
    if(i_param_list_count > 0)
        DB_commit();
    
    if(EAPMES_Collect_Inspection_Data_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	
    /*
        Save Inspection Data By Operation
    */
    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0
        || memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0) /* FrontEnd or BackEnd EL */
    {

		//MODULE ID SIZE CHECK
		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			strcpy(s_msg_code, "WIP-0583");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SIZE CHECK", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

        /*
            1. Save Inspection Data and Result
        */
        tran_in_node = TRS.create_node("END_LOT_IN");
        tran_out_node = TRS.create_node("END_LOT_OUT");

        CCOM_copy_in_node(in_node, tran_in_node);
	    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  

        if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
            TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_EL1);  
        else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
            TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_EL2);  
        else
            TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_EL1);  

        //TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_HIPOT);   <- 2019-09-25 hchkim ºÒÇÊ¿äÇÑ ºÎºÐ ÁÖ¼®Ã³¸®
        TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
        TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
        TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
        TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));

        if(strcmp(TRS.get_string(in_node, "TYPE_FLAG"), "2") == 0) /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */
            TRS.add_char(tran_in_node, "TYPE_FLAG", '2');	 
        else
            TRS.add_char(tran_in_node, "TYPE_FLAG", '1');

        if(CEDC_UPDATE_INSPECTION_DATA(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	    {
            TRS.clone(out_node, tran_out_node);
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

            TRS.free_node(tran_in_node);
            TRS.free_node(tran_out_node);
		    return MP_FALSE;
	    }
        
        i_ins_cnt = 0;
        i_ins_cnt = TRS.get_int(tran_out_node, "INS_CNT");

	    TRS.free_node(tran_in_node);
        TRS.free_node(tran_out_node);

        /*
            2. Save Loss and Repair Data
        */
        /* Defect List */
        DEFECT_LIST = TRS.get_list(in_node, "DEFECT_LIST");
        i_defect_list_count = TRS.get_item_count(in_node, "DEFECT_LIST");

        for(i = 0; i < i_defect_list_count; i++)
        {
            DEFECT_ITEM = TRS.get_list(DEFECT_LIST[i], "DEFECT_ITEM");
            i_defect_item_count = TRS.get_item_count(DEFECT_LIST[i], "DEFECT_ITEM");

	        for(j = 0; j < i_defect_item_count; j++)
            {
                /* 1-1. Save Loss Data */
                /* Get Max Sequence */
                //0: Not Use, 1:°ú°Ë, 2:¹Ì°Ë, 3:¿À°Ë, 4:ÀûÇÕ
                
                if(TRS.get_char(DEFECT_ITEM[j],"INSPECTION_RESULT") == '1' 
                    && strcmp(TRS.get_string(DEFECT_ITEM[j],"INSPECTION_TYPE"), HQCEL_INS_TYPE_CATEGORY_SUALAB ) == 0 )

                {
                    continue;
                }
            
                d_max_seq_num = 0;
                CDB_init_cwipcellos(&CWIPCELLOS);
                TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
                if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
                    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_EL1, strlen(HQCEL_LOSS_CATEGORY_EL1));
                else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
                    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_EL2, strlen(HQCEL_LOSS_CATEGORY_EL2));
                else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER)) == 0)
                    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_TABBER, strlen(HQCEL_LOSS_CATEGORY_TABBER));
                else /* Default */
                    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_EL1, strlen(HQCEL_LOSS_CATEGORY_EL1));

                /* Cell ID */
                TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LOT_ID");

                d_max_seq_num = CDB_select_cwipcellos_scalar(2, &CWIPCELLOS);
                if(DB_error_code != DB_SUCCESS)
                {
                    return MP_TRUE;
                }

				
                /* Insert defect items */
                CDB_init_cwipcellos(&CWIPCELLOS);
                TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);

                if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
                    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_EL1, strlen(HQCEL_LOSS_CATEGORY_EL1));
                else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
                    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_EL2, strlen(HQCEL_LOSS_CATEGORY_EL2));
                else /* Default */
                    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_LOSS_CATEGORY_EL1, strlen(HQCEL_LOSS_CATEGORY_EL1));

                TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LOT_ID");

                CWIPCELLOS.LOSS_SEQ = (int)++d_max_seq_num;
                TRS.copy(CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE), DEFECT_ITEM[j], "REASON_CODE");
                TRS.copy(CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID), in_node, "LINE_ID");
                TRS.copy(CWIPCELLOS.RES_ID, sizeof(CWIPCELLOS.RES_ID), in_node, "RES_ID");
                TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");
                TRS.copy(CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID), DEFECT_ITEM[j], "LOC_ID");
                //TRS.copy(CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID), DEFECT_ITEM[j], "LOC_ID");

                if (COM_isspace(CWIPCELLOS.LOC_X, sizeof(CWIPCELLOS.LOC_X)) == MP_TRUE)
		        {
			        CWIPCELLOS.LOC_X[0] = CWIPCELLOS.LOCATION_ID[0];
		        }

                if (COM_isspace(CWIPCELLOS.LOC_Y, sizeof(CWIPCELLOS.LOC_Y)) == MP_TRUE)
		        {
			        memcpy(CWIPCELLOS.LOC_Y, CWIPCELLOS.LOCATION_ID+1, 3);
		        }

                TRS.copy(CWIPCELLOS.RESULT_VALUE, sizeof(CWIPCELLOS.RESULT_VALUE), in_node, "RESULT");
                CWIPCELLOS.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
                memcpy(CWIPCELLOS.CREATE_TIME, s_sys_time, sizeof(CWIPCELLOS.CREATE_TIME));
                memcpy(CWIPCELLOS.TRAN_TIME, s_sys_time, sizeof(CWIPCELLOS.TRAN_TIME));

                CWIPCELLOS.INS_CNT = i_ins_cnt; // CEDECLOTRLT.INS_CNT


				//LOCATION ¿¡ µû¸¥ À§Ä¡GET
				CDB_init_cwiplotstr(&CWIPLOTSTR);
				TRS.copy(CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID), in_node, "LOT_ID");
				CWIPLOTSTR.STRING_LOC[0] = CWIPCELLOS.LOCATION_ID[0];
				//location : A1->A01 ·Î ¹Ù²Þ..
				{
					int itmp = 0;
					itmp = COM_atoi(CWIPCELLOS.LOCATION_ID+1, 2);
					COM_itoa_zero(CWIPLOTSTR.STRING_LOC+1, itmp, 2);
				}
				CDB_select_cwiplotstr(2, &CWIPLOTSTR);
				if(DB_error_code != DB_SUCCESS)
                {
					//DO NOTHING
				}
                
				memcpy(CWIPCELLOS.STRING_ID, CWIPLOTSTR.STRING_ID, sizeof(CWIPLOTSTR.STRING_ID));
				memcpy(CWIPCELLOS.LOSS_GROUP, CWIPLOTSTR.CMF_2, sizeof(CWIPCELLOS.LOSS_GROUP));
				
				if (j < 5)
					s_lr_flag[j] = CWIPLOTSTR.CMF_2[0];

				if (COM_isspace(CWIPCELLOS.ORDER_ID, sizeof(CWIPCELLOS.ORDER_ID)) == MP_TRUE)
					memcpy(CWIPCELLOS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
				
                CDB_insert_cwipcellos(&CWIPCELLOS);
                if(DB_error_code != DB_SUCCESS)
                {
                   //DO NOTHING
                }
            }
        }


        /* 3. Save Module Image Path */
        /* CWIPLOTTRC */
	    CDB_init_cwiplottrc(&CWIPLOTTRC);
        TRS.copy(CWIPLOTTRC.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	    CDB_select_cwiplottrc_for_update(1, &CWIPLOTTRC);
	    if (DB_error_code != DB_SUCCESS)
	    {
			memcpy(CWIPLOTTRC.WORK_DATE, MWIPLOTSTS.CREATE_TIME, 8);
		    CDB_insert_cwiplottrc(&CWIPLOTTRC);
	    }

		if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
		{
			TRS.copy(CWIPLOTTRC.FACTORY, sizeof(CWIPLOTTRC.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPLOTTRC.EL_IMAGE_PATH1, sizeof(CWIPLOTTRC.EL_IMAGE_PATH1), in_node, "MODULE_IMAGE");

			if (COM_isspace(CWIPLOTTRC.TAB_ZONE,sizeof(CWIPLOTTRC.TAB_ZONE)) == MP_TRUE)
			{
				memcpy(CWIPLOTTRC.TAB_ZONE, s_lr_flag, 5) ; //ÀÓ½Ã·Î TABER ºÒ·®ZONE À» »ç¿ëÇÔ.
			}

			CDB_update_cwiplottrc(1, &CWIPLOTTRC);
			if (DB_error_code != DB_SUCCESS)
			{

			}
		}

        /* MWIPELTSTS */
	    CDB_init_mwipeltsts(&MWIPELTSTS);
	    TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	    CDB_select_mwipeltsts(1, &MWIPELTSTS);
	    if(DB_error_code != DB_SUCCESS)
        {
		    if(DB_error_code == DB_NOT_FOUND)
		    {
			    MWIPELTSTS.HIST_SEQ = 0;
				memcpy(MWIPELTSTS.CURING_TIME, s_sys_time, sizeof(MWIPELTSTS.CURING_TIME)) ;//ÆÄÆ¼¼ÇÅ°·Î »ç¿ëÇÏ°í ÀÖÀ¸¹Ç·Î ¾÷µ¥ÀÌÆ® ±ÝÁö
			    CDB_insert_mwipeltsts(&MWIPELTSTS);	
			    if(DB_error_code != DB_SUCCESS)
			    {

			    }
		    }
		    else
		    {

		    }        
        }
        
        /* End Lot*/
        if(memcmp(MWIPLOTSTS.OPER, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0) 
	    {
            /* End Lot */
            tran_in_node = TRS.create_node("END_LOT_IN");
            tran_out_node = TRS.create_node("END_LOT_OUT");

            CCOM_copy_in_node(in_node, tran_in_node);
	        TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
	        TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	        TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
	        TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER)); 
	        TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
			TRS.add_string(tran_in_node, "TRAN_CMF_2", s_sys_time, sizeof(s_sys_time)); //TRAN_CMF_2 ¿¡ °Ë»çµ¥ÀÌµ¥ Ã³¸®ÈÄ END ÇßÀ»°æ¿ì ÇØ´ç ½Ã°£ ³ÖÀ½.
			TRS.add_char(tran_in_node, "INSPECT_FLAG", 'Y');
            if(EAPMES_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	        {
                // Do Nothing
	        }
    
	        TRS.free_node(tran_in_node);
            TRS.free_node(tran_out_node);
        }

    }
    else if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_SIMULATOR_OPER, strlen(HQCEL_M1_SIMULATOR_OPER)) == 0) /* Simulator */
    {
		/*
            1. Save Inspection Data and Result
        */
        /* Result */
	    CDB_init_cedclotrlt(&CEDCLOTRLT);
        TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
	    memcpy(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_SIMULATOR, strlen(HQCEL_INS_TYPE_CATEGORY_SIMULATOR));
	    TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");

	    CDB_select_cedclotrlt(2,&CEDCLOTRLT);
	    if(DB_error_code != DB_SUCCESS)
        {
		    if(DB_error_code == DB_NOT_FOUND)
		    {
			    CEDCLOTRLT.INS_CNT = 0;
				memcpy(CEDCLOTRLT.CMF_1, s_sys_time, 14); /* Initial Inspection Time */
			    CDB_insert_cedclotrlt(&CEDCLOTRLT);	
			    if(DB_error_code != DB_SUCCESS)
			    {
				    //DO NOTHING
			    }
		    }
		    else
		    {
                
			    strcpy(s_msg_code, "EDC-0004");
			    TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
			    TRS.add_dberrmsg(out_node, DB_error_msg);

			    gs_log_type.type = MP_LOG_ERROR;
			    gs_log_type.e_type = MP_LOG_E_SYSTEM;
			    gs_log_type.category = MP_LOG_CATE_TRANS;
			    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			    return MP_FALSE;
                
		    }
        
        }

        TRS.copy(CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID), in_node, "RES_ID");
        TRS.copy(CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID), in_node, "LINE_ID");
        memcpy(CEDCLOTRLT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCLOTRLT.OPER));

        TRS.copy(CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID), in_node, "CLIENT_ID");
        memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));

        TRS.copy(CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE), in_node, "RESULT");
        TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "CLIENT_ID");
        memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));

        CEDCLOTRLT.TYPE_FLAG = '1';
        CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

        CEDCLOTRLT.INS_CNT = CEDCLOTRLT.INS_CNT +1;

        if(CEDCLOTRLT.INS_CNT <= 1)
        {
            memcpy(CEDCLOTRLT.CMF_1, s_sys_time, 14); /* Initial Inspection Time */
        }
		
		memcpy(CEDCLOTRLT.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		memcpy(CEDCLOTRLT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		memcpy(CEDCLOTRLT.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

        /* Save Parameter Data - Simulator */
        PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
        i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");

        for(i = 0; i < i_param_list_count; i++)
        {
            PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
            i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");

            for(j = 0; j < i_param_item_count; j++)
            {
                /* Get Simulator Data */
                if(TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_EFF", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.EFF, sizeof(CEDCLOTRLT.EFF), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_ENV_TEMP", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.TREF, sizeof(CEDCLOTRLT.TREF), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_FF", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.FF, sizeof(CEDCLOTRLT.FF), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_IMAX", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.IMPP, sizeof(CEDCLOTRLT.IMPP), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_ISC", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.ISC, sizeof(CEDCLOTRLT.ISC), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_MODULE_TEMP", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.TEMP, sizeof(CEDCLOTRLT.TEMP), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_PMAX", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
				{
                    TRS.copy(CEDCLOTRLT.PMPP, sizeof(CEDCLOTRLT.PMPP), PARAM_ITEM[j], "PARAM_VALUE");

					//strncpy(pmpp, TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE") + '\0', strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE")) + 1);

					// Modify to specify the maximum size of alarm transmission data
					memset(pmpp,0x0,20+1);
					i_AlarmDataMaxsize = strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
					if(20 < i_AlarmDataMaxsize)
						i_AlarmDataMaxsize = 20;
					TRS.copy(pmpp, i_AlarmDataMaxsize, PARAM_ITEM[j], "PARAM_VALUE");

					//Simulator ÀúÃâ·Â(PMPP) Ã¼Å© ÈÄ SPEC OUT½Ã Raise Alarm.  2019.10.03 JGCHOI.
					DBC_init_mspcchtdef(&MSPCCHTDEF);
					memcpy(MSPCCHTDEF.FACTORY, MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY));
					TRS.copy(MSPCCHTDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "LINE_ID");
					memcpy(MSPCCHTDEF.CHT_CMF_1, "I_SIM_01_PMAX", strlen("I_SIM_01_PMAX"));

					DBC_select_mspcchtdef(102, &MSPCCHTDEF);
					if(DB_error_code == DB_SUCCESS)
					{
						b_exist_pmpp = MP_TRUE;
					}

				}
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_RESULT", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.EL, sizeof(CEDCLOTRLT.EL), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_RS", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.RS, sizeof(CEDCLOTRLT.RS), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_RSH", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.RSH, sizeof(CEDCLOTRLT.RSH), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_SUN", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.SUN, sizeof(CEDCLOTRLT.SUN), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_SURF_TEMP", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.SURFTEMP, sizeof(CEDCLOTRLT.SURFTEMP), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_VMAX", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.VMPP, sizeof(CEDCLOTRLT.VMPP), PARAM_ITEM[j], "PARAM_VALUE");
                else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_VOC", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                    TRS.copy(CEDCLOTRLT.VOC, sizeof(CEDCLOTRLT.VOC), PARAM_ITEM[j], "PARAM_VALUE");
				else if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_IREVMAX", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
                {
					TRS.copy(CEDCLOTRLT.ESC, sizeof(CEDCLOTRLT.ESC), PARAM_ITEM[j], "PARAM_VALUE");
					//strncpy(diode, CEDCLOTRLT.ESC, 12);
					//strncpy(diode, TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE")+ '\0', strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE")) + 1);

					// Modify to specify the maximum size of alarm transmission data
					memset(diode,0x0,20+1);
					i_AlarmDataMaxsize = strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
					if(20 < i_AlarmDataMaxsize)
						i_AlarmDataMaxsize = 20;
					TRS.copy(diode, i_AlarmDataMaxsize, PARAM_ITEM[j], "PARAM_VALUE");
				}
            }
        }

        TRS.copy(CEDCLOTRLT.FLASHER_CODE, sizeof(CEDCLOTRLT.FLASHER_CODE), in_node, "RES_ID");

		//First Not Rework Ins Time ISSUE-09-050_ÀÏÀÏº¸°íÀü»êÈ­°ü·Ã by kim 20191016
		if (memcmp(CEDCLOTRLT.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC)) == 0)
		{
			if (memcmp(CEDCLOTRLT.RESULT_VALUE, "RW", strlen("RW")) != 0 && CEDCLOTRLT.CMF_3[0] == ' ')
			{
				memcpy(CEDCLOTRLT.CMF_3, s_sys_time, sizeof(s_sys_time));
			}
		}

	    CDB_update_cedclotrlt(1, &CEDCLOTRLT);
	
	    if(DB_error_code != DB_SUCCESS)
	    {
			strcpy(s_msg_code, "EDC-0044");
			TRS.set_fieldmsg(out_node, "CEDCLOTRLT UPDATE", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
	    }else{
			//IS-22-01-042	[프로그램변경][Telegram Alarm Modification] Cold Soldering Alarm  22.01.26 프로시저로 전환
			//PMPP DIODE DATA ALARM
			//CDB_select_cedclotrlt(4, &CEDCLOTRLT);
			//if(DB_error_code == DB_SUCCESS)
			//{
			//	if (DB_error_code != DB_NOT_FOUND)
			//	{
			//		CDB_init_cwiplottrc(&CWIPLOTTRC_ALARM);
			//		TRS.copy(CWIPLOTTRC_ALARM.LOT_ID, sizeof(CWIPLOTTRC_ALARM.LOT_ID), in_node, "LOT_ID");
			//		CDB_select_cwiplottrc(1, &CWIPLOTTRC_ALARM);
			//		if(memcmp(CWIPLOTTRC_ALARM.FRM_RES_ID, " ", strlen(" ")) != 0){
			//			strncpy(res, CWIPLOTTRC_ALARM.FRM_RES_ID + '\0', 20);
			//			res[20] = 0x00;
			//			CDB_init_calmtlghis(&CALMTLGHIS);
			//		
			//			memcpy(CALMTLGHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			//			memcpy(CALMTLGHIS.NOTIFY_SYSTEM, "HQcellUS_SOLD_ALARM", strlen("HQcellUS_SOLD_ALARM"));
			//			memcpy(CALMTLGHIS.TRAN_TIME, s_sys_time, sizeof(CALMTLGHIS.TRAN_TIME));
			//			TRS.copy(CALMTLGHIS.CMF_1, sizeof(CALMTLGHIS.CMF_1), in_node, "RES_ID");
			//			strncpy(lotId, (TRS.get_string(in_node, "LOT_ID") + '\0'), 19);
			//			
			//			//strncpy(alertTime, s_sys_time + '\0', 16);
			//			//alertTime[16] = 0x00;
			//			strncpy(workDate,s_sys_time,8);
			//			strncpy(workTime,s_sys_time+8,6);
			//			strncpy(yyyy,s_sys_time,4);
			//			strncpy(MM,s_sys_time+4,2);
			//			strncpy(dd,s_sys_time+6,2);
			//			strncpy(hh,s_sys_time+8,2);
			//			strncpy(mm,s_sys_time+10,2);
			//			strncpy(ss,s_sys_time+12,2);
			//			workDate[8] = 0x00;
			//			workTime[6] = 0x00;
			//			yyyy[4] = 0x00;
			//			MM[2] = 0x00;
			//			dd[2] = 0x00;
			//			hh[2] = 0x00;
			//			mm[2] = 0x00;
			//			ss[2] = 0x00;

			//			compare_pmpp = 0;
			//			compare_diode = 0;
			//			compare_diode = COM_atof(diode,sizeof(diode));
			//			compare_pmpp = COM_atof(pmpp,sizeof(pmpp));
			//			
			//			// IS-21-04-006 Update Request for Cold Soldering Telegram Alert
			//			//if(compare_pmpp >= 200 && compare_pmpp <= 299.999)
			//			//if(compare_pmpp >= 200 && compare_pmpp <= 299.9999)
			//			//{

			//			//}
			//			////else if(compare_pmpp >= 0 && compare_pmpp <= 199.999)
			//			//else if(compare_pmpp >= 0 && compare_pmpp < 200)
			//			//{

			//			//}
			//			////else if(compare_pmpp > 300 && compare_diode > 0 && compare_diode <= 3.999 )
			//			//else if(compare_pmpp > 300 && compare_diode > 0 && compare_diode <= 3.9999 )
			//			//{

			//			//}
			//			//else
			//			//{



			//			//}

			//			// IS-21-04-006 Update Request for Cold Soldering Telegram Alert
			//			if(i_pmppStatusFlag == 1)
			//			{
			//				//sprintf(message , "-MODULE ID : %s \n-PMPP : %s \n-DIODE : %s \n-FRAME EQ : %s \n-ALERT TIME : %s-%s-%s %s:%s:%s" , lotId, pmpp,diode, res, yyyy, MM, dd, hh, mm, ss);

			//				memcpy(CALMTLGHIS.NOTIFY_MESSAGE, message, sizeof(message));

			//				//CDB_insert_calmtlghis(&CALMTLGHIS); 
			//	
			//				// 결과 -> 실패로 return 할 경우 
			//				//		1. strcpy로 s_msg_code 에 직접 작성해도 되고, 
			//				//strcpy(s_msg_code, "RAS-0003");
			//				//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			//				//return MP_FALSE;
			//				if(DB_error_code == DB_SUCCESS)
			//				{
			//					//CDB_init_cwippmphis(&CWIPPMPHIS);
			//					//TRS.copy(CWIPPMPHIS.FACTORY, sizeof(CWIPPMPHIS.FACTORY), in_node, "FACTORY");
			//					//TRS.copy(CWIPPMPHIS.LOT_ID, sizeof(CWIPPMPHIS.LOT_ID), in_node, "LOT_ID");
			//					//TRS.copy(CWIPPMPHIS.RES_ID, sizeof(CWIPPMPHIS.RES_ID), in_node, "RES_ID");
			//					//TRS.copy(CWIPPMPHIS.LINE_ID, sizeof(CWIPPMPHIS.LINE_ID), in_node, "LINE_ID");

			//					//CWIPPMPHIS.INS_CNT = CEDCLOTRLT.INS_CNT;

			//					//CWIPPMPHIS.WORK_SHIFT[0] = CCOM_get_work_shift(s_sys_time);
			//					//memcpy(CWIPPMPHIS.PMPP, CEDCLOTRLT.PMPP, sizeof(CWIPPMPHIS.PMPP));
			//					//memcpy(CWIPPMPHIS.DIODE, CEDCLOTRLT.ESC, sizeof(CWIPPMPHIS.DIODE));
			//					//memcpy(CWIPPMPHIS.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));
			//					//memcpy(CWIPPMPHIS.INS_TIME, CEDCLOTRLT.INS_TIME, sizeof(CWIPPMPHIS.INS_TIME));
			//					//memcpy(CWIPPMPHIS.WORK_DATE, workDate, strlen(workDate));
			//					//memcpy(CWIPPMPHIS.WORK_TIME, workTime, strlen(workTime));
			//					////memcpy(CWIPPMPHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			//					//
			//					//// 20210810 MES Application Memory leak 점검 및 수정// malloc 제거로 주석처리
			//					//// memcpy 범위 문제
			//					//memcpy(CWIPPMPHIS.CREATE_TIME, s_sys_time, sizeof(CWIPPMPHIS.CREATE_TIME));

			//					//memcpy(CWIPPMPHIS.UPDATE_USER_ID, " ", sizeof(" "));

			//					//CDB_insert_cwippmphis(&CWIPPMPHIS);
			//					//if(DB_error_code != DB_SUCCESS)
			//					//{

			//					//}

			//				}else{

			//				}
			//			}

			//			// 20210810 MES Application Memory leak 점검 및 수정
			//			// malloc 제거로 주석처리
			//			/*
			//			free(lotId);
			//			free(res);
			//			free(pmpp);
			//			// IS-21-04-006 Update Request for Cold Soldering Telegram Alert
			//			// diode 를 free 처리하면 프로그램 오류 발생하여 주석처리함. (최대 21자리 데이터가 전송되여 문제가 발생 할 것으로 보이면 소스 수정이 필요함)

			//			// Modify to specify the maximum size of alarm transmission data
			//			free(diode);	// IS-21-04-006 Update Request for Cold Soldering Telegram Alert
			//			free(workDate);
			//			free(workTime);
			//			free(yyyy);
			//			free(MM);
			//			free(dd);
			//			free(hh);
			//			free(mm);
			//			free(ss);
			//			*/
			//		}
			//	}
			//}else{

			//}  //IS-22-01-042	[프로그램변경][Telegram Alarm Modification] Cold Soldering Alarm  22.01.26 프로시저로 전환
		}



	    /* History */
        CDB_init_cedclotrlh(&CEDCLOTRLH);

        TRS.copy(CEDCLOTRLH.FACTORY, sizeof(CEDCLOTRLH.FACTORY), in_node, IN_FACTORY);
	    memcpy(CEDCLOTRLH.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_SIMULATOR, strlen(HQCEL_INS_TYPE_CATEGORY_SIMULATOR));
        TRS.copy(CEDCLOTRLH.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID), in_node, "LOT_ID");
	    CEDCLOTRLH.INS_CNT = CEDCLOTRLT.INS_CNT;
	    //CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.INS_CNT;
        TRS.copy(CEDCLOTRLH.RES_ID, sizeof(CEDCLOTRLH.RES_ID), in_node, "RES_ID");
        TRS.copy(CEDCLOTRLH.FLASHER_CODE, sizeof(CEDCLOTRLH.FLASHER_CODE), in_node, "RES_ID");
        TRS.copy(CEDCLOTRLH.LINE_ID, sizeof(CEDCLOTRLH.LINE_ID), in_node, "LINE_ID");
        memcpy(CEDCLOTRLH.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCLOTRLH.OPER));
                    
        TRS.copy(CEDCLOTRLH.INS_USER_ID, sizeof(CEDCLOTRLH.INS_USER_ID), in_node, "CLIENT_ID");
        memcpy(CEDCLOTRLH.INS_TIME, s_sys_time, sizeof(CEDCLOTRLH.INS_TIME));

        TRS.copy(CEDCLOTRLH.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE), in_node, "RESULT");
        TRS.copy(CEDCLOTRLH.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID), in_node, "CLIENT_ID");
        memcpy(CEDCLOTRLH.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLH.RESULT_TIME));

        CEDCLOTRLH.TYPE_FLAG = CEDCLOTRLT.TYPE_FLAG;

        /* Simulator Result */
        memcpy(CEDCLOTRLH.EFF, CEDCLOTRLT.EFF, sizeof(CEDCLOTRLH.EFF));
        memcpy(CEDCLOTRLH.RS, CEDCLOTRLT.RS, sizeof(CEDCLOTRLH.RS));
        memcpy(CEDCLOTRLH.RSH, CEDCLOTRLT.RSH, sizeof(CEDCLOTRLH.RSH));
        memcpy(CEDCLOTRLH.FF, CEDCLOTRLT.FF, sizeof(CEDCLOTRLH.FF));
        memcpy(CEDCLOTRLH.ISC, CEDCLOTRLT.ISC, sizeof(CEDCLOTRLH.ISC));
        memcpy(CEDCLOTRLH.VOC, CEDCLOTRLT.VOC, sizeof(CEDCLOTRLH.VOC));
        memcpy(CEDCLOTRLH.IMPP, CEDCLOTRLT.IMPP, sizeof(CEDCLOTRLH.IMPP));
        memcpy(CEDCLOTRLH.VMPP, CEDCLOTRLT.VMPP, sizeof(CEDCLOTRLH.VMPP));
        memcpy(CEDCLOTRLH.PMPP, CEDCLOTRLT.PMPP, sizeof(CEDCLOTRLH.PMPP));
        memcpy(CEDCLOTRLH.TEMP, CEDCLOTRLT.TEMP, sizeof(CEDCLOTRLH.TEMP));
        memcpy(CEDCLOTRLH.TREF, CEDCLOTRLT.TREF, sizeof(CEDCLOTRLH.TREF));
        memcpy(CEDCLOTRLH.SURFTEMP, CEDCLOTRLT.SURFTEMP, sizeof(CEDCLOTRLH.SURFTEMP));
        memcpy(CEDCLOTRLH.SUN, CEDCLOTRLT.SUN, sizeof(CEDCLOTRLH.SUN));
        memcpy(CEDCLOTRLH.OSC, CEDCLOTRLT.OSC, sizeof(CEDCLOTRLH.OSC));
        memcpy(CEDCLOTRLH.ESC, CEDCLOTRLT.ESC, sizeof(CEDCLOTRLH.ESC));
        memcpy(CEDCLOTRLH.EL, CEDCLOTRLT.EL, sizeof(CEDCLOTRLH.EL));
		memcpy(CEDCLOTRLH.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		memcpy(CEDCLOTRLH.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		memcpy(CEDCLOTRLH.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
        
        CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.INS_CNT;

        /* Initial Inspection Time */
        memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1)); 
		memcpy(CEDCLOTRLH.CMF_2, CEDCLOTRLT.CMF_2, sizeof(CEDCLOTRLH.CMF_2)); 
		memcpy(CEDCLOTRLH.CMF_3, CEDCLOTRLT.CMF_3, sizeof(CEDCLOTRLH.CMF_3)); 
		memcpy(CEDCLOTRLH.CMF_4, CEDCLOTRLT.CMF_4, sizeof(CEDCLOTRLH.CMF_4)); 
		memcpy(CEDCLOTRLH.CMF_5, CEDCLOTRLT.CMF_5, sizeof(CEDCLOTRLH.CMF_5)); 

	    CDB_insert_cedclotrlh(&CEDCLOTRLH);
	    if(DB_error_code != DB_SUCCESS)
	    {
		    strcpy(s_msg_code, "EDC-0004");
		    TRS.set_fieldmsg(out_node, "CEDCLOTRLH INSERT", MP_NVST);
		    TRS.add_dberrmsg(out_node, DB_error_msg);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLH.FACTORY), CEDCLOTRLH.FACTORY);
            TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLH.INS_TYPE), CEDCLOTRLH.INS_TYPE);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_SYSTEM;
		    gs_log_type.category = MP_LOG_CATE_TRANS;
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
	    }

        /* MWIPELTSTS */
	    CDB_init_mwipeltsts(&MWIPELTSTS);
	    TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	    CDB_select_mwipeltsts(1, &MWIPELTSTS);
	    if(DB_error_code != DB_SUCCESS)
        {
			if (DB_error_code == DB_NOT_FOUND)
			{
				MWIPELTHIS.HIST_SEQ = 1;
				memcpy(MWIPELTSTS.CURING_TIME, s_sys_time, sizeof(MWIPELTSTS.CURING_TIME)) ;//ÆÄÆ¼¼ÇÅ°·Î »ç¿ëÇÏ°í ÀÖÀ¸¹Ç·Î ¾÷µ¥ÀÌÆ® ±ÝÁö
				CDB_insert_mwipeltsts(&MWIPELTSTS);
			}
        }

        /* Flasher Code */
        memcpy(MWIPELTSTS.FLASHER_CODE, CEDCLOTRLT.FLASHER_CODE, sizeof(MWIPELTSTS.FLASHER_CODE));

        /* Simulator Result */
        memcpy(MWIPELTSTS.EFF, CEDCLOTRLT.EFF, sizeof(MWIPELTSTS.EFF));
        memcpy(MWIPELTSTS.RS, CEDCLOTRLT.RS, sizeof(MWIPELTSTS.RS));
        memcpy(MWIPELTSTS.RSH, CEDCLOTRLT.RSH, sizeof(MWIPELTSTS.RSH));
        memcpy(MWIPELTSTS.FF, CEDCLOTRLT.FF, sizeof(MWIPELTSTS.FF));
        memcpy(MWIPELTSTS.ISC, CEDCLOTRLT.ISC, sizeof(MWIPELTSTS.ISC));
        memcpy(MWIPELTSTS.VOC, CEDCLOTRLT.VOC, sizeof(MWIPELTSTS.VOC));
        memcpy(MWIPELTSTS.IMPP, CEDCLOTRLT.IMPP, sizeof(MWIPELTSTS.IMPP));
        memcpy(MWIPELTSTS.VMPP, CEDCLOTRLT.VMPP, sizeof(MWIPELTSTS.VMPP));
        memcpy(MWIPELTSTS.PMPP, CEDCLOTRLT.PMPP, sizeof(MWIPELTSTS.PMPP));
        memcpy(MWIPELTSTS.TEMP, CEDCLOTRLT.TEMP, sizeof(MWIPELTSTS.TEMP));
        memcpy(MWIPELTSTS.TREF, CEDCLOTRLT.TREF, sizeof(MWIPELTSTS.TREF));
        memcpy(MWIPELTSTS.SURFTEMP, CEDCLOTRLT.SURFTEMP, sizeof(MWIPELTSTS.SURFTEMP));
        memcpy(MWIPELTSTS.SUN, CEDCLOTRLT.SUN, sizeof(MWIPELTSTS.SUN));
        //memcpy(MWIPELTSTS.OSC, CEDCLOTRLT.OSC, sizeof(MWIPELTSTS.OSC));
        memcpy(MWIPELTSTS.ESC, CEDCLOTRLT.ESC, sizeof(MWIPELTSTS.ESC));
        memcpy(MWIPELTSTS.EL, CEDCLOTRLT.EL, sizeof(MWIPELTSTS.EL));
        
	    CDB_update_mwipeltsts(1, &MWIPELTSTS);
	    if(DB_error_code != DB_SUCCESS)
	    {
            
	    }

		if(b_exist_pmpp == MP_TRUE)
		{
			//SPC DATA INSERT. 2019.10.01 JGCHOI.
			spc_in_node = TRS.create_node("SPC_IN");
			spc_out_node = TRS.create_node("SPC_OUT");

			CCOM_copy_in_node(in_node, spc_in_node);
			TRS.add_nstring(spc_in_node, "RES_ID", TRS.get_string(in_node, "LINE_ID"));  
			TRS.add_nstring(spc_in_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));  
			TRS.add_nstring(spc_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  

			

			PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
			i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");
			for(i = 0; i < i_param_list_count; i++)
			{
				list_item = TRS.add_node(spc_in_node, "PARAM_LIST");

				PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
				i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");

				for(j = 0; j < i_param_item_count; j++)
				{
					if (TRS.mem_cmp(PARAM_ITEM[j], "PARAM_NAME", "I_SIM_01_PMAX", strlen(TRS.get_string(PARAM_ITEM[j], "PARAM_NAME"))) == 0)
					{
						list_param = TRS.add_node(list_item, "PARAM_ITEM");

						TRS.add_string(list_param, "PARAM_NAME", MSPCCHTDEF.CHART_ID, sizeof(MSPCCHTDEF.CHART_ID));
						TRS.add_nstring(list_param,  "PARAM_VALUE", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
						break;
					}
				}
			}

			//EAPMES_COLLECT_PROCESS_DATA Ã³¸® Áö¿¬À¸·Î µ¥ÀÌÅÍ ´©¶ôÀÌ ¹ß»ýÇÏ¿© Áß°£¿¡ Ä¿¹Ô Ã³¸®
			//20200124 ±èÇÑÃ» ¼ö¼®´Ô ¿äÃ»
			DB_commit();

			if(EAPMES_COLLECT_PROCESS_DATA(s_msg_code, spc_in_node, spc_out_node) == MP_FALSE)
			{
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.free_node(spc_in_node);
				TRS.free_node(spc_out_node);
				return MP_FALSE;
			}
			TRS.free_node(spc_in_node);
			TRS.free_node(spc_out_node);
		}
		//2023.12.18
		// CTM Summary에서 사용할 데이터 생성
        if (Send_CTM_Summary(s_msg_code, s_sys_time, in_node, out_node) == MP_FALSE)
            return MP_FALSE;
    }
    else if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_HIPOT_OPER, strlen(HQCEL_M1_HIPOT_OPER)) == 0) /* Hi-Pot */
    {
        /* ISSUE-07-060 20190722 by HCHKIM Hi-Pot*/

		re_cnt = 3;

		CDB_init_cedclotrlt(&CEDCLOTRLT_SIM);
		TRS.copy(CEDCLOTRLT_SIM.FACTORY, sizeof(CEDCLOTRLT_SIM.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTRLT_SIM.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_SIMULATOR, strlen(HQCEL_INS_TYPE_CATEGORY_SIMULATOR));
		TRS.copy(CEDCLOTRLT_SIM.LOT_ID, sizeof(CEDCLOTRLT_SIM.LOT_ID), in_node, "LOT_ID");

		for(j = 0; j < re_cnt; j++)
		{
			CDB_select_cedclotrlt(2,&CEDCLOTRLT_SIM);
			if(DB_error_code == DB_NOT_FOUND)
			{
				_sleep(600);
			}
			else
			{
				j=re_cnt;
			}
		}

        /*
            1. Save Inspection Data and Result
        */
        tran_in_node = TRS.create_node("END_LOT_IN");
        tran_out_node = TRS.create_node("END_LOT_OUT");

        CCOM_copy_in_node(in_node, tran_in_node);
	    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
        TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_HIPOT);  
        TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
        TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
        TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
        TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));
        TRS.add_char(tran_in_node, "TYPE_FLAG", '1'); /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */ 

        if(CEDC_UPDATE_INSPECTION_DATA(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	    {
            TRS.clone(out_node, tran_out_node);
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

            TRS.free_node(tran_in_node);
            TRS.free_node(tran_out_node);
		    return MP_FALSE;
	    }

	    TRS.free_node(tran_in_node);
        TRS.free_node(tran_out_node);

    }
    else if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_GROUND_TEST_OPER, strlen(HQCEL_M1_GROUND_TEST_OPER)) == 0) /* Ground Test */
    {
        /*
            1. Save Inspection Data and Result
        */
        tran_in_node = TRS.create_node("END_LOT_IN");
        tran_out_node = TRS.create_node("END_LOT_OUT");

        CCOM_copy_in_node(in_node, tran_in_node);
	    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
        TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_GROUND);  
        TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
        TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
        TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
        //TRS.add_nstring(tran_in_node, "RESULT", "OK");
        TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT")); //// 25.03.04 Ground Test 결과 MES 로직 수정 요청의 건
        TRS.add_char(tran_in_node, "TYPE_FLAG", '1'); /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */ 

        if(CEDC_UPDATE_INSPECTION_DATA(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	    {
            TRS.clone(out_node, tran_out_node);
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

            TRS.free_node(tran_in_node);
            TRS.free_node(tran_out_node);
		    return MP_FALSE;
	    }

	    TRS.free_node(tran_in_node);
        TRS.free_node(tran_out_node);
    }
    else /* Etc */
    {
        /*
            1. Save Inspection Data and Result
        */
        tran_in_node = TRS.create_node("END_LOT_IN");
        tran_out_node = TRS.create_node("END_LOT_OUT");

        CCOM_copy_in_node(in_node, tran_in_node);
	    TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
        TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_ET);  
        TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
        TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
        TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
        TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));
        TRS.add_char(tran_in_node, "TYPE_FLAG", '1'); /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */ 

        if(CEDC_UPDATE_INSPECTION_DATA(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	    {
            TRS.clone(out_node, tran_out_node);
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

            TRS.free_node(tran_in_node);
            TRS.free_node(tran_out_node);
		    return MP_FALSE;
	    }
    
	    TRS.free_node(tran_in_node);
        TRS.free_node(tran_out_node);

    }
	
	tran_in_node = TRS.create_node("MAIN_DEFECT_CODE_IN");
	tran_out_node = TRS.create_node("MAIN_DEFECT_CODE_OUT");

	CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));   
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
	TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
	TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
	TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));

    if(strcmp(TRS.get_string(in_node, "TYPE_FLAG"), "2") == 0) /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */
    {
        TRS.add_char(tran_in_node, "TYPE_FLAG", '2');
    }else
    {
        TRS.add_char(tran_in_node, "TYPE_FLAG", '1');
    }
 
    
	/***************************************************/
	// CEDCLOTRLT.CMF_2 :  Main Defect Code
	/***************************************************/
	if(CEDC_UPDATE_MAIN_DEFECT_CODE(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		return MP_FALSE;
	}

	TRS.free_node(tran_in_node);
    TRS.free_node(tran_out_node);

	//MATRIX_DEFECT_ALRAM_PROCESS
	if(CEDC_UPDATE_MATRIX_DEFECT_ALARM(s_msg_code, in_node, out_node) == MP_FALSE)
	{

	}
	
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Validation()
        - Main sub function of "EAPMES_COLLECT_INSPECTION_DATA" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct MWIPFACDEF_TAG MWIPFACDEF;

    ///* ProcStep Validation */
    //if(COM_service_validation(s_msg_code,
    //                          in_node,
    //                          out_node,
    //                          TRS.get_procstep(in_node),
    //                          "1") == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    ///* Factory Validation */
    //if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "EIS-0001");
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    return MP_FALSE;
    //}

    //DBC_init_mwipfacdef(&MWIPFACDEF);
    //TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    //DBC_select_mwipfacdef(1, &MWIPFACDEF);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    strcpy(s_msg_code, "WIP-0005");
    //    TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
    //    TRS.add_dberrmsg(out_node, DB_error_msg);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_SETUP;
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}

/*******************************************************************************
  Send_CTM_Summary()
    - Main sub function of "EAPMES_COLLECT_INSPECTION_DATA" function
  Return Value
    - int : 1 (MP_TRUE) or 0 (MP_FALSE)
  Arguments
    - char *s_msg_code : Error Message Code
    - char *s_sys_time : System Time
    - TRSNode *in_node : Input Message structure
    - TRSNode *out_node : Output Message structure
*******************************************************************************/
int Send_CTM_Summary(char* s_msg_code, char* s_sys_time, TRSNode* in_node, TRSNode* out_node)
{
/*
    struct CWIPCTMTRC_TAG CWIPCTMTRC;

    CDB_init_cwipctmtrc(&CWIPCTMTRC);
    TRS.copy(CWIPCTMTRC.FACTORY, sizeof(CWIPCTMTRC.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPCTMTRC.LOT_ID, sizeof(CWIPCTMTRC.LOT_ID), in_node, "LOT_ID");
    memcpy(CWIPCTMTRC.KIND, "CTM", strlen("CTM"));
    CWIPCTMTRC.WIP_FLAG = ' ';   // WIP

    CDB_select_cwipctmtrc(2, &CWIPCTMTRC);
    if (DB_error_code == DB_NOT_FOUND)
    {
        memcpy(CWIPCTMTRC.TRAN_TIME, s_sys_time, sizeof(CWIPCTMTRC.TRAN_TIME));
        CDB_insert_cwipctmtrc(2, &CWIPCTMTRC);  // RPT에 저장

        //CDB_insert_cwipctmtrc(3, &CWIPCTMTRC);  // ARC에 저장
    }
*/
    char s_channel[100];

    LOG_head("Send_CTM_Summary");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_channel, 0x00, sizeof(s_channel));
    sprintf(s_channel, "/%.*s/GTMServer", 4, gs_site_id);

    //Report DB, Archive DB 에 CTM 집계 용 데이터 전송
    //FACTORY, LOT_ID, KIND 전송
    TRS.set_char(in_node, IN_PROCSTEP, '1');
    TRS.set_nstring(in_node, "KIND", "CTM");

    // Report DB 전송용
    if (CallService("CEIS",
        "CEIS_Save_Traceability_Material_Data",
        in_node,
        0x00,
        s_channel,
        18000000, //gi_default_ttl, 
        DM_GUNICAST) != MP_TRUE)
    {
        // Error Log 생성
        LOG_head("CEIS_Save_Traceability_Material_Data CTM Send Error");
        COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
        return MP_FALSE;
    }

    //// Archive DB 전송용
    //memset(s_channel, 0x00, sizeof(s_channel));
    //sprintf(s_channel, "/%.*s/ARCServer", 4, gs_site_id);

    //LOG_head("Send_CTM_Summary_ARC Channel");
    //LOG_add("Channel", MP_STR, sizeof(s_channel), s_channel);
    //LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    //COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    //if (CallService("CEIS",
    //    "CEIS_Save_Traceability_Material_Data_ARC",
    //    in_node,
    //    0x00,
    //    s_channel,
    //    18000000, //gi_default_ttl, 
    //    DM_GUNICAST) != MP_TRUE)
    //{
    //    // Error Log 생성
    //    LOG_head("CEIS_Save_Traceability_Material_Data_ARC CTM Send Error");
    //    COM_log_write(MP_LOG_WARNING, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
    //    return MP_FALSE;
    //}

    return MP_TRUE;
}
