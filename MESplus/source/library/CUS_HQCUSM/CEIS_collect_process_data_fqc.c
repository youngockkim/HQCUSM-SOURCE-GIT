/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_process_data_fqc.c
    Description : EAPMES Collect Process Data For FQC Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Process_Data_FQC()
            + Setup service interface function
        - EAPMES_COLLECT_PROCESS_DATA_FQC()
            + Main sub function of EAPMES_Collect_Process_Data_FQC function
            + Setup service main business function
        - EAPMES_Collect_Process_Data_FQC_Validation()
            + Main sub function of EAPMES_COLLECT_PROCESS_DATA_FQC function
    Detail Description
        - EAPMES_COLLECT_PROCESS_DATA_FQC()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Process_Data_FQC_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Process_Data_FQC()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_FQC(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_PROCESS_DATA_FQC(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_PROCESS_DATA_FQC", out_node);

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
		"MESEAP_Collect_Process_Data_FQC", 
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
    EAPMES_COLLECT_PROCESS_DATA_FQC()
        - Main sub function of "EAPMES_Collect_Process_Data_FQC" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_PROCESS_DATA_FQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
    struct MRASRESDEF_TAG MRASRESDEF;
    struct CEDCLOTFQC_TAG CEDCLOTFQC;
    struct CEDCLOTFQC_TAG CEDCLOTFQC_DEF; /* Defect List */

	struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CWIPLOTSTR_TAG CWIPLOTSTR;

    char s_sys_time[14];
    int i, j;
    int i_max_ins_seq;
    int i_ins_cnt;

	//char s_lr_flag[5] ;
    double d_max_seq_num;

    int i_defect_list_count;
    int i_defect_item_count;
    int i_tracking_list_count;
    int i_tracking_item_count;

	char c_main_complete_flag = 'N';


    TRSNode ** DEFECT_LIST;
    TRSNode ** DEFECT_ITEM;
    TRSNode ** TRACKING_LIST;
    TRSNode ** TRACKING_ITEM;

	
    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("EAPMES_COLLECT_PROCESS_DATA_FQC");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time, ' ', sizeof(s_sys_time));
	//memset(s_lr_flag, ' ' , sizeof(s_lr_flag));

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

    /* Lot Information */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
            
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

    if(EAPMES_Collect_Process_Data_FQC_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /*
        2. Save Inspection Data and Result
    */
    tran_in_node = TRS.create_node("INSP_DATA_IN");
    tran_out_node = TRS.create_node("INSP_DATA_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", '1');  
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
    TRS.add_string(tran_in_node, "OPER", MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2));
	TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_nstring(tran_in_node, "WORK_LINE", TRS.get_string(in_node, "LINE_ID"));  
    TRS.add_string(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));  
    TRS.add_nstring(tran_in_node, "INS_VALUE", TRS.get_string(in_node, "FQC_JUDGE"));
    TRS.add_nstring(tran_in_node, "INS_USER_ID", TRS.get_string(in_node, "FQC_OPGROUP"));
    TRS.add_nstring(tran_in_node, "RESULT_VALUE", TRS.get_string(in_node, "FQC_RESULT"));
    TRS.add_nstring(tran_in_node, "RESULT_USER_ID", TRS.get_string(in_node, "FQC_OPGROUP"));
    TRS.add_nstring(tran_in_node, "GRADE", TRS.get_string(in_node, "GRADE"));
    TRS.add_nstring(tran_in_node, "POWER", TRS.get_string(in_node, "POWER_GRADE"));

	//FRONT_USERID
	TRS.add_nstring(tran_in_node, "FRONT_USERID", TRS.get_string(in_node, "FRONT_USERID"));
	//REAR_USERID
	TRS.add_nstring(tran_in_node, "REAR_USERID", TRS.get_string(in_node, "REAR_USERID"));

    TRS.add_char(tran_in_node, "TYPE_FLAG", '1');
	c_main_complete_flag ='Y';
    if(CWIP_UPDATE_FQC_RESULT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
        //TRS.init_node(out_node);
		TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        //TRS.free_node(tran_in_node);
        //TRS.free_node(tran_out_node);
		//return MP_FALSE;
		c_main_complete_flag ='N';
	}

    i_ins_cnt = 0;
    i_ins_cnt = TRS.get_int(tran_out_node, "INS_CNT");

	TRS.free_node(tran_in_node);
    TRS.free_node(tran_out_node);


    /* 1. Save All Tracking and Defect Data */
    i_max_ins_seq = 0;
    CDB_init_cedclotfqc(&CEDCLOTFQC);
    TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CEDCLOTFQC.RES_ID, sizeof(CEDCLOTFQC.RES_ID), in_node, "RES_ID");

    i_max_ins_seq = CDB_select_cedclotfqc_scalar(2, &CEDCLOTFQC);
    if(DB_error_code != DB_SUCCESS)
    {
        //return MP_TRUE;
    }

	if (c_main_complete_flag =='N')
	{
		//CEDCLOTRLT, RLH 에 테이블에 값이 안들어 갔을경우 
		//INS_CNT 로 관리하고 잇으므로 일단 안함..
	}

    CDB_init_cedclotfqc(&CEDCLOTFQC);
    TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CEDCLOTFQC.RES_ID, sizeof(CEDCLOTFQC.RES_ID), in_node, "RES_ID");
    CEDCLOTFQC.INS_SEQ = ++i_max_ins_seq;
    CEDCLOTFQC.DEFECT_SEQ = 1; // initial defect sequence
    TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CEDCLOTFQC.LINE_ID, sizeof(CEDCLOTFQC.LINE_ID), in_node, "LINE_ID");
    memcpy(CEDCLOTFQC.OPER, MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
    CEDCLOTFQC.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
    memcpy(CEDCLOTFQC.INS_TIME, s_sys_time, sizeof(CEDCLOTFQC.INS_TIME));
    memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
    CEDCLOTFQC.INS_CNT = i_ins_cnt; // CEDECLOTRLT.INS_CNT
    TRS.copy(CEDCLOTFQC.INS_USER_ID, sizeof(CEDCLOTFQC.INS_USER_ID), in_node, "CLIENT_ID");
    TRS.copy(CEDCLOTFQC.GRADE, sizeof(CEDCLOTFQC.GRADE), in_node, "GRADE");
    TRS.copy(CEDCLOTFQC.POWER_GRADE, sizeof(CEDCLOTFQC.POWER_GRADE), in_node, "POWER_GRADE");
    TRS.copy(CEDCLOTFQC.ARTICLE_NO, sizeof(CEDCLOTFQC.ARTICLE_NO), in_node, "ARTICLE_NUMBER");
    TRS.copy(CEDCLOTFQC.FQC_JUDGE, sizeof(CEDCLOTFQC.FQC_JUDGE), in_node, "FQC_JUDGE");
    TRS.copy(CEDCLOTFQC.WORK_SHIFT, sizeof(CEDCLOTFQC.WORK_SHIFT), in_node, "FQC_OPGROUP");
    TRS.copy(CEDCLOTFQC.TRACKING_REQUEST, sizeof(CEDCLOTFQC.TRACKING_REQUEST), in_node, "TRACKING_REQUEST");
    TRS.copy(CEDCLOTFQC.FQC_RESULT, sizeof(CEDCLOTFQC.FQC_RESULT), in_node, "FQC_RESULT");

    /* Tracking List */
    TRACKING_LIST = TRS.get_list(in_node, "TRACKING_LIST");
    i_tracking_list_count = TRS.get_item_count(in_node, "TRACKING_LIST");
    
    for(i = 0; i < i_tracking_list_count; i++)
    {
        TRACKING_ITEM = TRS.get_list(TRACKING_LIST[i], "TRACKING_ITEM");
        i_tracking_item_count = TRS.get_item_count(TRACKING_LIST[i], "TRACKING_ITEM");

        for(j = 0; j < i_tracking_item_count; j++)
        {

    		if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "AOIRes", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.AOI_RESULT, sizeof(CEDCLOTFQC.AOI_RESULT), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "HVRes", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.HVT_RESULT, sizeof(CEDCLOTFQC.HVT_RESULT), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "BELRes", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.BEL_RESULT, sizeof(CEDCLOTFQC.BEL_RESULT), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "GTRes", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.GRT_RESULT, sizeof(CEDCLOTFQC.GRT_RESULT), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "FlashRes", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.SIM_RESULT, sizeof(CEDCLOTFQC.SIM_RESULT), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "FlashPMAX", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.FLASH_PMAX, sizeof(CEDCLOTFQC.FLASH_PMAX), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "FlashISC", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.FLASH_ISC, sizeof(CEDCLOTFQC.FLASH_ISC), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "FlashVOC", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.FLASH_VOC, sizeof(CEDCLOTFQC.FLASH_VOC), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "FlashIMPP", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.FLASH_IMPP, sizeof(CEDCLOTFQC.FLASH_IMPP), TRACKING_ITEM[j], "TRACKING_VALUE");
    		else if(TRS.mem_cmp(TRACKING_ITEM[j], "TRACKING_NAME", "CuringTime", strlen(TRS.get_string(TRACKING_ITEM[j], "TRACKING_NAME"))) == 0)
	    		TRS.copy(CEDCLOTFQC.CURING_TIME, sizeof(CEDCLOTFQC.CURING_TIME), TRACKING_ITEM[j], "TRACKING_VALUE");

        }
    }

	if (c_main_complete_flag != 'Y')
	{
		CEDCLOTFQC.INS_CNT = 0;
		memcpy(CEDCLOTFQC.CMF_2, "ERROR", strlen("ERROR"));
	}

	//FRONT_USERID
	TRS.copy(CEDCLOTFQC.CMF_3, sizeof(CEDCLOTFQC.CMF_3), in_node, "FRONT_USERID");
	//REAR_USERID
	TRS.copy(CEDCLOTFQC.CMF_4, sizeof(CEDCLOTFQC.CMF_4), in_node, "REAR_USERID");
	
    CDB_insert_cedclotfqc(&CEDCLOTFQC);
    if(DB_error_code != DB_SUCCESS)
    {
        // Do Nothing
    }

    CDB_init_cedclotfqc(&CEDCLOTFQC_DEF);
    TRS.copy(CEDCLOTFQC_DEF.LOT_ID, sizeof(CEDCLOTFQC_DEF.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CEDCLOTFQC_DEF.RES_ID, sizeof(CEDCLOTFQC_DEF.RES_ID), in_node, "RES_ID");
    CEDCLOTFQC_DEF.INS_SEQ = CEDCLOTFQC.INS_SEQ;
    CEDCLOTFQC_DEF.DEFECT_SEQ = CEDCLOTFQC.DEFECT_SEQ;

    CDB_select_cedclotfqc(1, &CEDCLOTFQC_DEF);
    if(DB_error_code != DB_SUCCESS)
    {
        // Do Nothing
    }
	

	 /* REMARK_ITEM */
	/***
	TRSNode ** REMARK_ITEM;
    TRSNode ** REMARK_DETAIL;
	int i_remarkitem_count;
    int i_remarkdetail_count;
	***/
	//CEDCLOTRLT 와 CEDCLOTRLH 에 FQC REMARK 값 넣음.
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	memcpy(CEDCLOTRLT.FACTORY, CEDCLOTFQC_DEF.FACTORY, sizeof(CEDCLOTFQC_DEF.FACTORY));
	memcpy(CEDCLOTRLT.INS_TYPE, "FC", strlen("FC"));
	memcpy(CEDCLOTRLT.LOT_ID, CEDCLOTFQC_DEF.LOT_ID, sizeof(CEDCLOTFQC_DEF.LOT_ID));
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
    {
       //DO NOTHING
    }

    /* Defect List */
    DEFECT_LIST = TRS.get_list(in_node, "DEFECT_LIST");
    i_defect_list_count = TRS.get_item_count(in_node, "DEFECT_LIST");
    
    for(i = 0; i < i_defect_list_count; i++)
    {
        DEFECT_ITEM = TRS.get_list(DEFECT_LIST[i], "DEFECT_ITEM");
        i_defect_item_count = TRS.get_item_count(DEFECT_LIST[i], "DEFECT_ITEM");

        for(j = 0; j < i_defect_item_count; j++)
        {
            if (j == 0) /* 1st Defect Item */
            {
                CEDCLOTFQC_DEF.DEFECT_SEQ = (j+1);
                TRS.copy(CEDCLOTFQC_DEF.CELL_INFO, sizeof(CEDCLOTFQC_DEF.CELL_INFO), DEFECT_ITEM[j], "CELL_INFO");
                TRS.copy(CEDCLOTFQC_DEF.POS_X, sizeof(CEDCLOTFQC_DEF.POS_X), DEFECT_ITEM[j], "POS_X");
                TRS.copy(CEDCLOTFQC_DEF.POS_Y, sizeof(CEDCLOTFQC_DEF.POS_Y), DEFECT_ITEM[j], "POS_Y");
                TRS.copy(CEDCLOTFQC_DEF.DEFECT_CODE, sizeof(CEDCLOTFQC_DEF.DEFECT_CODE), DEFECT_ITEM[j], "DEFECT_CODE");
                TRS.copy(CEDCLOTFQC_DEF.REMARK, sizeof(CEDCLOTFQC_DEF.REMARK), DEFECT_ITEM[j], "REMARK");

                CDB_update_cedclotfqc(1, &CEDCLOTFQC_DEF);
                if(DB_error_code != DB_SUCCESS)
                {
                
                }
            }
            //else /* 2nd or later Defect Item */
            //{
            //    CEDCLOTFQC_DEF.DEFECT_SEQ = (j+1);
            //    TRS.copy(CEDCLOTFQC_DEF.CELL_INFO, sizeof(CEDCLOTFQC_DEF.CELL_INFO), DEFECT_ITEM[j], "CELL_INFO");
            //    TRS.copy(CEDCLOTFQC_DEF.POS_X, sizeof(CEDCLOTFQC_DEF.POS_X), DEFECT_ITEM[j], "POS_X");
            //    TRS.copy(CEDCLOTFQC_DEF.POS_Y, sizeof(CEDCLOTFQC_DEF.POS_Y), DEFECT_ITEM[j], "POS_Y");
            //    TRS.copy(CEDCLOTFQC_DEF.DEFECT_CODE, sizeof(CEDCLOTFQC_DEF.DEFECT_CODE), DEFECT_ITEM[j], "DEFECT_CODE");
            //    TRS.copy(CEDCLOTFQC_DEF.REMARK, sizeof(CEDCLOTFQC_DEF.REMARK), DEFECT_ITEM[j], "REMARK");

            //    CDB_insert_cedclotfqc(&CEDCLOTFQC_DEF);
            //    if(DB_error_code != DB_SUCCESS)
            //    {
            //    
            //    }
            //}

			/* 1-1. Save Loss Data */
            /* Get Max Sequence */
            d_max_seq_num = 0;
            CDB_init_cwipcellos(&CWIPCELLOS);
            TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
            memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
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
            memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
            TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LOT_ID");

            CWIPCELLOS.LOSS_SEQ = (int)++d_max_seq_num;
			
			//LOSS_QTY

            TRS.copy(CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE), DEFECT_ITEM[j], "DEFECT_CODE");
			
			//LOSS_TYPE
			
            TRS.copy(CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID), DEFECT_ITEM[j], "CELL_INFO");
            TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");
			
			//MAT_ID
			//FLOW
			//OPER
			
			if (COM_isspace(CWIPCELLOS.ORDER_ID, sizeof(CWIPCELLOS.ORDER_ID)) == MP_TRUE)
				memcpy(CWIPCELLOS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

            TRS.copy(CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID), in_node, "LINE_ID");
            TRS.copy(CWIPCELLOS.RES_ID, sizeof(CWIPCELLOS.RES_ID), in_node, "RES_ID");

			//STATUS_FLAG
			//INV_LOT_ID
			
            TRS.copy(CWIPCELLOS.LOC_X, sizeof(CWIPCELLOS.LOC_X), DEFECT_ITEM[j], "POS_X");
            TRS.copy(CWIPCELLOS.LOC_Y, sizeof(CWIPCELLOS.LOC_Y), DEFECT_ITEM[j], "POS_Y");
			
			//TYPE_FLAG
			//LOSS_COMMENT
						
            memcpy(CWIPCELLOS.CREATE_TIME, s_sys_time, sizeof(CWIPCELLOS.CREATE_TIME));
            memcpy(CWIPCELLOS.TRAN_TIME, s_sys_time, sizeof(CWIPCELLOS.TRAN_TIME));

			//WORK_DATE
			CWIPCELLOS.WORK_SHIFT = CEDCLOTFQC.WORK_SHIFT[0];
			//WORKER

            CWIPCELLOS.INS_CNT = i_ins_cnt; // CEDECLOTRLT.INS_CNT
            memcpy(CWIPCELLOS.RESULT_VALUE, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));
            CWIPCELLOS.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

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
				
			//if (j < 5)
			//	s_lr_flag[j] = CWIPLOTSTR.CMF_2[0];

				
            CDB_insert_cwipcellos(&CWIPCELLOS);
            if(DB_error_code != DB_SUCCESS)
            {
                //DO NOTHING
            }
        }
    }
	
	/***************************************************/
	/* FQC REMARK */
	/***************************************************/
	//CEDCLOTRLT.RLT_COMMENT 에 값넣음.
	{
		char tmp_str[1000];
		struct CEDCFQCRMK_TAG CEDCFQCRMK;
		TRSNode ** REMARK_ITEM;
		TRSNode ** REMARK_SET;

		int i_remarkitem_count;
		int i_remarkset_count;
		int iKeySeq = 1;

		memset(tmp_str, '\0', sizeof(tmp_str));

		//memcpy(tmp_str, TRS.get_string
		CDB_init_cedcfqcrmk(&CEDCFQCRMK);
		memcpy(CEDCFQCRMK.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCFQCRMK.LOT_ID));
		CEDCFQCRMK.INS_CNT = CEDCLOTRLT.INS_CNT;
		memcpy(CEDCFQCRMK.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY));
		memcpy(CEDCFQCRMK.LINE_ID, CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID));
		memcpy(CEDCFQCRMK.OPER, CEDCLOTRLT.OPER, sizeof(CEDCLOTRLT.OPER));
		memcpy(CEDCFQCRMK.RES_ID, CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID));
		CEDCFQCRMK.LOT_HIST_SEQ = CEDCLOTRLT.LAST_HIST_SEQ;
		memcpy(CEDCFQCRMK.CREATE_TIME, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));

		//COM_memcpy_add_null
		 REMARK_ITEM = TRS.get_list(in_node, "REMARK_ITEM");
		i_remarkitem_count = TRS.get_item_count(in_node, "REMARK_ITEM");

		for(i = 0; i < i_remarkitem_count; i++)
		{
			//TRS.copy(CEDCLOTRLT.INC_COMMENT, sizeof(CEDCLOTRLT.INC_COMMENT), REMARK_ITEM[i], "REMARK_CATEGORY");
			sprintf(tmp_str + strlen(tmp_str), "%s:", TRS.get_string(REMARK_ITEM[i], "REMARK_CATEGORY"));

			REMARK_SET = TRS.get_list(REMARK_ITEM[i], "REMARK_SET");
			i_remarkset_count = TRS.get_item_count( REMARK_ITEM[i], "REMARK_SET");
			
			CEDCFQCRMK.REMARK_CATE_SEQ = i+1;
			memset(CEDCFQCRMK.REMARK_CATEGORY, ' ', sizeof(CEDCFQCRMK.REMARK_CATEGORY));
			TRS.copy(CEDCFQCRMK.REMARK_CATEGORY, sizeof(CEDCFQCRMK.REMARK_CATEGORY), REMARK_ITEM[i], "REMARK_CATEGORY");

			if (i_remarkset_count < 1)
			{
				CEDCFQCRMK.KEY_SEQ = iKeySeq++;
				CDB_insert_cedcfqcrmk(&CEDCFQCRMK);
				if(DB_error_code != DB_SUCCESS)
				{
				   //DO NOTHING
				}
			}

			for(j = 0; j < i_remarkset_count; j++)
			{
				CEDCFQCRMK.KEY_SEQ = iKeySeq++;
				CEDCFQCRMK.REMARK_DETAIL_SEQ = j+1;
				memset(CEDCFQCRMK.REMARK_DETAIL, ' ', sizeof(CEDCFQCRMK.REMARK_DETAIL));
				TRS.copy(CEDCFQCRMK.REMARK_DETAIL, sizeof(CEDCFQCRMK.REMARK_CATEGORY), REMARK_SET[j], "REMARK_DETAIL");
				CDB_insert_cedcfqcrmk(&CEDCFQCRMK);
				if(DB_error_code != DB_SUCCESS)
				{
				   //DO NOTHING
				}

				if (strlen(tmp_str) > 400)
				{
					continue;
				}
				
				//TRS.copy(CEDCLOTRLT.RLT_COMMENT, sizeof(CEDCLOTRLT.RLT_COMMENT), REMARK_ITEM[i], "REMARK_DETAIL");
				if(j==0)
				{
					sprintf(tmp_str + strlen(tmp_str), "%s", TRS.get_string(REMARK_SET[j], "REMARK_DETAIL"));
				} else
				{ 
					sprintf(tmp_str + strlen(tmp_str), ",%s", TRS.get_string(REMARK_SET[j], "REMARK_DETAIL"));
				}

				
			}
			if (strlen(tmp_str) > 400)
			{
				continue;
			}
		}

		//cedclotrlt 에 inc_comment + rlt_comment 에 fqc remark 정보를 넣음.
		memcpy(CEDCLOTRLT.INC_COMMENT, tmp_str, 199);
		if (strlen(tmp_str) > 200)
		{
			memcpy(CEDCLOTRLT.RLT_COMMENT, tmp_str+199, 199);
		}
		
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
		   //DO NOTHING
		}
		//CEDCLOTRLH UPDATE
		CDB_init_cedclotrlh(&CEDCLOTRLH);
		memcpy(CEDCLOTRLH.FACTORY, CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY));
		memcpy(CEDCLOTRLH.INS_TYPE, CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLT.INS_TYPE));
		memcpy(CEDCLOTRLH.LOT_ID, CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
		CEDCLOTRLH.INS_CNT = CEDCLOTRLT.INS_CNT;
		CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.LAST_HIST_SEQ;
		CDB_select_cedclotrlh(2, &CEDCLOTRLH);
		if(DB_error_code != DB_SUCCESS)
		{
		   //DO NOTHING
		}
		memcpy(CEDCLOTRLH.INC_COMMENT, CEDCLOTRLT.INC_COMMENT, sizeof(CEDCLOTRLT.INC_COMMENT));
		memcpy(CEDCLOTRLH.RLT_COMMENT, CEDCLOTRLT.RLT_COMMENT, sizeof(CEDCLOTRLT.RLT_COMMENT));
		
		CDB_update_cedclotrlh(1, &CEDCLOTRLH);
		if(DB_error_code != DB_SUCCESS)
		{
		   //DO NOTHING
		}
	}
	

	// ISSUE-07-002 : FQC  대표 불량 코드 로직 추가 (2019.07.10)
    tran_in_node = TRS.create_node("MAIN_DEFECT_CODE_IN");
    tran_out_node = TRS.create_node("MAIN_DEFECT_CODE_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));   
    TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
    TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
    TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
    TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));
    TRS.add_char(tran_in_node, "TYPE_FLAG", '1'); /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */ 
       
	/***************************************************/
	// CEDCLOTRLT.CMF_2 : 대표불량코드 업데이트
	/***************************************************/
    if(CEDC_UPDATE_MAIN_DEFECT_CODE(s_msg_code, in_node, tran_out_node) == MP_FALSE)
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
    EAPMES_Collect_Process_Data_FQC_Validation()
        - Main sub function of "EAPMES_COLLECT_PROCESS_DATA_FQC" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Process_Data_FQC_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

