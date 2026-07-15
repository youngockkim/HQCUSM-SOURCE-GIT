/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_inspection_data.c
    Description : CWIP Collect Inspection Data Service

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Collect_Inspection_Data()
            + Setup service interface function
        - CWIP_COLLECT_INSPECTION_DATA()
            + Main sub function of CWIP_Collect_Inspection_Data function
            + Setup service main business function
        - CWIP_Collect_Inspection_Data_Validation()
            + Main sub function of CWIP_COLLECT_INSPECTION_DATA function
    Detail Description
        - CWIP_COLLECT_INSPECTION_DATA()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Collect_Inspection_Data_Oqc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Collect_Inspection_Data()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Collect_Inspection_Data_Oqc(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
	int i;
	TRSNode** moduleList;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);


	moduleList = TRS.get_list(in_node, "MODULE_LIST");
	for (i = 0; i < TRS.get_item_count(in_node, "MODULE_LIST"); i++)
	{
		//START LOT
		i_ret = CWIP_START_LOT_OQC(s_msg_code, moduleList[i], out_node);

		if(i_ret == MP_FALSE)
		{
            // IS-21-03-045	Dark Chamber OQC 튜닝
			TRS.add_nstring(out_node, "ERROR_TYPE", "WORK_ERROR");
			TRS.add_int(out_node, "LOT_INDEX", i );
			TRS.add_nstring(out_node, "LOT_ID", TRS.get_string(moduleList[i], "LOT_ID") );
			TRS.add_nstring(out_node, "WORK_TYPE", "START_LOT");

			DB_rollback();

			return MP_TRUE;
		}

		//CREATE INSP DATA
		i_ret = CWIP_COLLECT_INSPECTION_DATA_OQC(s_msg_code, moduleList[i], out_node);
		
		if(i_ret == MP_FALSE)
		{
			// IS-21-03-045	Dark Chamber OQC 튜닝
			TRS.add_nstring(out_node, "ERROR_TYPE", "WORK_ERROR");
			TRS.add_int(out_node, "LOT_INDEX", i );
			TRS.add_nstring(out_node, "LOT_ID", TRS.get_string(moduleList[i], "LOT_ID") );
			TRS.add_nstring(out_node, "WORK_TYPE", "INSPECTION_DATA");
			
			DB_rollback();

			return MP_TRUE;
		}

		//END LOT
		i_ret = CWIP_END_LOT_OQC(s_msg_code, moduleList[i], out_node);

		if(i_ret == MP_FALSE)
		{
			// IS-21-03-045	Dark Chamber OQC 튜닝
			TRS.add_nstring(out_node, "ERROR_TYPE", "WORK_ERROR");
			TRS.add_int(out_node, "LOT_INDEX", i );
			TRS.add_nstring(out_node, "LOT_ID", TRS.get_string(moduleList[i], "LOT_ID") );
			TRS.add_nstring(out_node, "WORK_TYPE", "END_LOT");

			DB_rollback();

			return MP_TRUE;
		}
	}

	// 20210810 MES Application Memory leak 점검 및 수정
	// 해당 CASE 없음으로 정상 RETURN 처리
	if(TRS.get_item_count(in_node, "MODULE_LIST") < 1)
	{
		COM_out_msg_log_write(s_msg_code, "CWIP_COLLECT_INSPECTION_DATA_OQC", out_node);
		return MP_TRUE;
	}

    COM_out_msg_log_write(s_msg_code, "CWIP_COLLECT_INSPECTION_DATA_OQC", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CWIP_COLLECT_INSPECTION_DATA()
        - Main sub function of "CWIP_Collect_Inspection_Data" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_COLLECT_INSPECTION_DATA_OQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MRASRESDEF_TAG MRASRESDEF;
    //struct MRASRESMFO_TAG MRASRESMFO;
    struct CWIPCELLOS_TAG CWIPCELLOS;
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CWIPLOTTRC_TAG CWIPLOTTRC;
    struct MWIPELTSTS_TAG MWIPELTSTS;
    struct MWIPELTHIS_TAG MWIPELTHIS;
    struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
    //struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CWIPLOTSTR_TAG CWIPLOTSTR;
	struct CEDCINSDAT_TAG CEDCINSDAT;
	struct MWIPMATDEF_TAG MWIPMATDEF;
    struct CEDCLOTAOI_TAG CEDCLOTAOI;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_SIM;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_GRT;
	struct MSPCCHTDEF_TAG MSPCCHTDEF;
//	struct CEDCLOTRLH_TAG CEDCLOTRLH_A;
//	struct MEDCCHRDEF_TAG MEDCCHRDEF;

    char s_sys_time_stamp[20];  
    char s_sys_time[17];
    int i, j;
    double d_max_seq_num;
    int i_ins_cnt;

    int i_defect_list_count;
    int i_defect_item_count;
    int i_param_list_count;
    int i_param_item_count;
	int i_max_ins_seq;

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

    LOG_head("CWIP_COLLECT_INSPECTION_DATA_OQC");
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
            //memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
            TRS.copy(CEDCINSDAT.TRAN_TIME, sizeof(CEDCINSDAT.TRAN_TIME), in_node, "TRAN_TIME_STAMP");

            d_max_seq_num = CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }

            /* Insert */
            CDB_init_cedcinsdat(&CEDCINSDAT);
            TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "LOT_ID");
            TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
            //memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
            TRS.copy(CEDCINSDAT.TRAN_TIME, sizeof(CEDCINSDAT.TRAN_TIME), in_node, "TRAN_TIME_STAMP");
            CEDCINSDAT.SEQ_NUM = (int)++d_max_seq_num;
            TRS.copy(CEDCINSDAT.FACTORY, sizeof(CEDCINSDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CEDCINSDAT.LINE_ID, sizeof(CEDCINSDAT.LINE_ID), in_node, "LINE_ID");
            memcpy(CEDCINSDAT.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
            CEDCINSDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
            TRS.copy(CEDCINSDAT.PARAM_NAME, sizeof(CEDCINSDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");

            TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");

            CDB_insert_cedcinsdat(&CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                //DO NOTHING
            }
        }
    }

    /* Save Parameter Data */
    // param_list가 있을 때만 commit 하도록 수정.
    if(i_param_list_count > 0)
        //DB_commit();
    
    if(CWIP_Collect_Inspection_Data_Oqc_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

        //TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_HIPOT);   <- 2019-09-25 hchkim 불필요한 부분 주석처리
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
                //0: Not Use, 1:과검, 2:미검, 3:오검, 4:적합
                
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


				//LOCATION 에 따른 위치GET
				CDB_init_cwiplotstr(&CWIPLOTSTR);
				TRS.copy(CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID), in_node, "LOT_ID");
				CWIPLOTSTR.STRING_LOC[0] = CWIPCELLOS.LOCATION_ID[0];
				//location : A1->A01 로 바꿈..
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
				memcpy(CWIPLOTTRC.TAB_ZONE, s_lr_flag, 5) ; //임시로 TABER 불량ZONE 을 사용함.
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
				memcpy(MWIPELTSTS.CURING_TIME, s_sys_time, sizeof(MWIPELTSTS.CURING_TIME)) ;//파티션키로 사용하고 있으므로 업데이트 금지
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
			TRS.add_string(tran_in_node, "TRAN_CMF_2", s_sys_time, sizeof(s_sys_time)); //TRAN_CMF_2 에 검사데이데 처리후 END 했을경우 해당 시간 넣음.
			TRS.add_char(tran_in_node, "INSPECT_FLAG", 'Y');
            if(CWIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
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
				//memcpy(CEDCLOTRLT.CMF_1, s_sys_time, 14); /* Initial Inspection Time */
				TRS.copy(CEDCLOTRLT.CMF_1, 14, in_node, "TRAN_TIME");

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
        //memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));
        TRS.copy(CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME), in_node, "TRAN_TIME");

        TRS.copy(CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE), in_node, "RESULT");
        TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "CLIENT_ID");
        //memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));
        TRS.copy(CEDCLOTRLT.RESULT_TIME, sizeof(CEDCLOTRLT.RESULT_TIME), in_node, "TRAN_TIME");

        CEDCLOTRLT.TYPE_FLAG = '1';
        CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

        CEDCLOTRLT.INS_CNT = CEDCLOTRLT.INS_CNT +1;

        if(CEDCLOTRLT.INS_CNT <= 1)
        {
            //memcpy(CEDCLOTRLT.CMF_1, s_sys_time, 14); /* Initial Inspection Time */
			TRS.copy(CEDCLOTRLT.CMF_1, 14, in_node, "TRAN_TIME");
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
                    TRS.copy(CEDCLOTRLT.ESC, sizeof(CEDCLOTRLT.ESC), PARAM_ITEM[j], "PARAM_VALUE");

            }
        }

        TRS.copy(CEDCLOTRLT.FLASHER_CODE, sizeof(CEDCLOTRLT.FLASHER_CODE), in_node, "RES_ID");

		//First Not Rework Ins Time ISSUE-09-050_일일보고전산화관련 by kim 20191016
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
        //memcpy(CEDCLOTRLH.INS_TIME, s_sys_time, sizeof(CEDCLOTRLH.INS_TIME));
        TRS.copy(CEDCLOTRLH.INS_TIME, sizeof(CEDCLOTRLH.INS_TIME), in_node, "TRAN_TIME");

        TRS.copy(CEDCLOTRLH.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE), in_node, "RESULT");
        TRS.copy(CEDCLOTRLH.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID), in_node, "CLIENT_ID");
        //memcpy(CEDCLOTRLH.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLH.RESULT_TIME));
        TRS.copy(CEDCLOTRLH.RESULT_TIME, sizeof(CEDCLOTRLH.RESULT_TIME), in_node, "TRAN_TIME");

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
				//memcpy(MWIPELTSTS.CURING_TIME, s_sys_time, sizeof(MWIPELTSTS.CURING_TIME)) ;//파티션키로 사용하고 있으므로 업데이트 금지
				TRS.copy(MWIPELTSTS.CURING_TIME, sizeof(MWIPELTSTS.CURING_TIME), in_node, "TRAN_TIME");
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


    }
    else if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_HIPOT_OPER, strlen(HQCEL_M1_HIPOT_OPER)) == 0) /* Hi-Pot */
    {
        /* ISSUE-07-060 20190722 by HCHKIM Hi-Pot이 처리시 Sim공정 처리 내역이 없으면 3회 0.6초 대기 한 후 처리한다. 
		   설비메세지가 거의 동시에 들어옴 SIM 처리 될때까지 3회 기다리고 그전에 확인되면 대기 없이 그대로 진행
		*/

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
        TRS.add_nstring(tran_in_node, "RESULT", "OK");
        //TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));
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
	
	// 대표불량코드 업데이트 로직 공통으로 변경
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
	// CEDCLOTRLT.CMF_2 : 대표불량코드 업데이트
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

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Collect_Inspection_Data_Validation()
        - Main sub function of "CWIP_COLLECT_INSPECTION_DATA" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Collect_Inspection_Data_Oqc_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{

    return MP_TRUE;
}