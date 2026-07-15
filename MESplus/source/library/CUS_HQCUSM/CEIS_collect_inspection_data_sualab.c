/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_inspection_data_sualab.c
    Description : EAPMES Collect Inspection Data for Sualab Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Inspection_Data_Sualab()
            + Setup service interface function
        - EAPMES_COLLECT_INSPECTION_DATA_SUALAB()
            + Main sub function of EAPMES_Collect_Inspection_Data_Sualab function
            + Setup service main business function
    Detail Description
        - EAPMES_COLLECT_INSPECTION_DATA_SUALAB()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019/07/26  sy7.kwon       Create 

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Collect_Inspection_Data_Sualab_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Sualab()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Sualab(TRSNode *in_node)
{	
	//struct	MGCMLAGDAT_TAG MGCMLAGDAT;	// 설비로 응답이 필요할 경우 추가

    char s_msg_code[MP_SIZE_MSG];
	//char s_channel[100];					// 설비로 응답이 필요할 경우 추가
    int i_ret;
    TRSNode *out_node;
	
    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_INSPECTION_DATA_SUALAB(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_INSPECTION_DATA_SUALAB", out_node);

	// 결과가 성공일 경우 DB commit
    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
	// 결과가 실패일 경우 DB rollback
	else
    {
        DB_rollback();
    }

    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);
	
    /* Save error service error log (MSVMERRLOG) */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log (CEISMSGLOG) */
    CEIS_Save_Message_Log(in_node, out_node);
    //CEIS_Save_Message_Log_For_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_INSPECTION_DATA_SUALAB()
        - Main sub function of "EAPMES_Collect_Inspection_Data_Sualab" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_INSPECTION_DATA_SUALAB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	// 사용할 변수 선언
    struct	MRASRESDEF_TAG MRASRESDEF;
    struct	MWIPLOTSTS_TAG MWIPLOTSTS;	
	struct	CWIPCELLOS_TAG CWIPCELLOS;
	struct	CWIPLOTSTR_TAG CWIPLOTSTR;
	struct	CEDCLOTSUA_TAG CEDCLOTSUA;
	struct	CEDCSUADAT_TAG CEDCSUADAT;
	struct worktime_tag cur_work_time;

	char	s_sys_time_stamp[20];
    char	s_sys_time[17];
	char	s_ins_type[2];
	char	s_result[2];

	int		i, j;	
	int		itmp;
	int		i_ins_cnt;
	int		i_defect_seq;
	int		i_max_seq_num;
	int		i_insp_list_count;
	int		i_insp_item_count;

	TRSNode **INSP_LIST;
	TRSNode **INSP_ITEM;
    
	TRSNode	*tran_in_node;
	TRSNode	*tran_out_node;
	
    TRSNode *list_item;
    TRSNode *list_param;

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memset(s_ins_type, ' ', sizeof(s_ins_type));
    memset(s_result, ' ', sizeof(s_result));

	// 설비/OI에서 전송한 in_node 데이터 전부 로그 작성
    LOG_head("EAPMES_COLLECT_INSPECTION_DATA_SUALAB");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);  
	
    /********************************************************/
	/*	0. 현재 DB 시간 조회								*/
    /********************************************************/	 
    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));
    DB_get_systime_m(s_sys_time_stamp);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");	// CMN-0003 : A fatal database error occurred. Please contact an administrator.
        TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));
	
    /********************************************************/
	/*	1. Validation Check									*/
    /********************************************************/
    if(EAPMES_Collect_Inspection_Data_Sualab_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
    /********************************************************/
	/*	2. Check Resource									*/
    /********************************************************/
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");

	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "RAS-0003");	// RAS-0003 : The Equipment does not exist , please setup resource
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT #1", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID",  MP_STR, sizeof(MRASRESDEF.RES_ID),  MRASRESDEF.RES_ID);

			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "RAS-0004");	// RAS-0004 : A fatal database error occurred. Please contact an administrator.
			TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT #1", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID",  MP_STR, sizeof(MRASRESDEF.RES_ID),  MRASRESDEF.RES_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}
	
    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
        memcpy(s_ins_type, HQCEL_INS_TYPE_CATEGORY_SUALAB1, strlen(HQCEL_INS_TYPE_CATEGORY_SUALAB1)); 
    else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
        memcpy(s_ins_type, HQCEL_INS_TYPE_CATEGORY_SUALAB2, strlen(HQCEL_INS_TYPE_CATEGORY_SUALAB2));
    else
        memcpy(s_ins_type, HQCEL_INS_TYPE_CATEGORY_SUALAB, strlen(HQCEL_INS_TYPE_CATEGORY_SUALAB)); 

	// RESULT - 0:OK, 1:NG, 2:Image data time out
	if(TRS.get_char(in_node, "RESULT") == '0')
	{
		memcpy(s_result, "OK", strlen("OK"));
	}
	else if(TRS.get_char(in_node, "RESULT") == '1')
	{
		memcpy(s_result, "NG", strlen("NG"));
	}
	else
	{
		s_result[0] = TRS.get_char(in_node, "RESULT");
	}
	
    /********************************************************/
	/*	3. Get Lot Info										*/
    /********************************************************/
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");

    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
       //DO NOTHING
    }
	
    /********************************************************/
	/*	4. Save Inspection Data and Result					*/
    /********************************************************/
    tran_in_node = TRS.create_node("UPDATE_INSP_DATA_IN");
    tran_out_node = TRS.create_node("UPDATE_INSP_DATA_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
    TRS.add_string(tran_in_node, "INS_TYPE", s_ins_type, sizeof(s_ins_type));  
    TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
    TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
    TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
    TRS.add_string(tran_in_node, "RESULT", s_result, sizeof(s_result));
    
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

    i_ins_cnt = TRS.get_int(tran_out_node, "INS_CNT");	// i_ins_cnt = CEDECLOTRLT.INS_CNT
    
	TRS.free_node(tran_in_node);
    TRS.free_node(tran_out_node);

    /********************************************************/
	/*	5. Save Sualab Result Data (CEDCLOTSUA)				*/
    /********************************************************/
	CDB_init_cedclotsua(&CEDCLOTSUA);
	TRS.copy(CEDCLOTSUA.FACTORY, sizeof(CEDCLOTSUA.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTSUA.INS_TYPE, s_ins_type, sizeof(s_ins_type));
	TRS.copy(CEDCLOTSUA.LOT_ID, sizeof(CEDCLOTSUA.LOT_ID), in_node, "LOT_ID");
	CEDCLOTSUA.HIST_SEQ = i_ins_cnt;
	CEDCLOTSUA.INS_CNT = i_ins_cnt;
	
	TRS.copy(CEDCLOTSUA.RES_ID, sizeof(CEDCLOTSUA.RES_ID), in_node, "RES_ID");
	TRS.copy(CEDCLOTSUA.LINE_ID, sizeof(CEDCLOTSUA.LINE_ID), in_node, "LINE_ID");
	memcpy(CEDCLOTSUA.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCLOTSUA.OPER));
	CEDCLOTSUA.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
	memcpy(CEDCLOTSUA.INS_TIME, s_sys_time, sizeof(CEDCLOTSUA.INS_TIME));
	TRS.copy(CEDCLOTSUA.INS_USER_ID, sizeof(CEDCLOTSUA.INS_USER_ID), in_node, "CLIENT_ID");
	
	memcpy(CEDCLOTSUA.RESULT_VALUE, s_result, sizeof(CEDCLOTSUA.RESULT_VALUE));	
	TRS.copy(CEDCLOTSUA.MODULE_IMAGE, sizeof(CEDCLOTSUA.MODULE_IMAGE), in_node, "MODULE_IMAGE");
	CEDCLOTSUA.MODE_CODE = TRS.get_char(in_node, "MODE");
	TRS.copy(CEDCLOTSUA.PRODUCT_INFO, sizeof(CEDCLOTSUA.PRODUCT_INFO), in_node, "PRODUCT_INFO");

    TRS.copy(CEDCLOTSUA.CMF_1, sizeof(CEDCLOTSUA.CMF_1), in_node, "USER_ID");

	CDB_insert_cedclotsua(&CEDCLOTSUA);
	if(DB_error_code != DB_SUCCESS)
	{
		// do notThing
	}

    /********************************************************/
	/*	6. Save Inspection Data	(CEDCSUADAT, CWIPCELLOS)	*/
    /********************************************************/
	INSP_LIST = TRS.get_list(in_node, "INSPECTION_LIST");
    i_insp_list_count = TRS.get_item_count(in_node, "INSPECTION_LIST");
    
    CCOM_get_work_time(s_sys_time, &cur_work_time);

    for(i = 0; i < i_insp_list_count; i++)
    {
        INSP_ITEM = TRS.get_list(INSP_LIST[i], "INSPECTION_ITEM");
        i_insp_item_count = TRS.get_item_count(INSP_LIST[i], "INSPECTION_ITEM");

	    for(j = 0; j < i_insp_item_count; j++)
        {
			i_defect_seq = 0;

			// 5-1. CEDCSUADAT 저장
			CDB_init_cedcsuadat(&CEDCSUADAT);
			TRS.copy(CEDCSUADAT.FACTORY, sizeof(CEDCSUADAT.FACTORY), in_node, IN_FACTORY);
			memcpy(CEDCSUADAT.INS_TYPE, s_ins_type, sizeof(s_ins_type));
			TRS.copy(CEDCSUADAT.LOT_ID, sizeof(CEDCSUADAT.LOT_ID), in_node, "LOT_ID");
			CEDCSUADAT.HIST_SEQ = i_ins_cnt;
			CEDCSUADAT.INS_CNT = i_ins_cnt;
			/*
				CDB_select_cedcsuadat_scalar - case 2
				
				SELECT NVL(MAX(DEFECT_SEQ), 0)
                  FROM CEDCSUADAT
                 WHERE FACTORY	= :CEDCLOTSUA_N.FACTORY
                   AND INS_TYPE = :CEDCLOTSUA_N.INS_TYPE
                   AND LOT_ID	= :CEDCLOTSUA_N.LOT_ID
                   AND HIST_SEQ = :CEDCLOTSUA_N.HIST_SEQ
                   AND INS_CNT	= :CEDCLOTSUA_N.INS_CNT;
			*/
			i_defect_seq = (int) CDB_select_cedcsuadat_scalar(2, &CEDCSUADAT);
			if(DB_error_code != DB_SUCCESS)
			{
				// Do nothing
			}
			
			CEDCSUADAT.DEFECT_SEQ = ++i_defect_seq;

			TRS.copy(CEDCSUADAT.RES_ID, sizeof(CEDCSUADAT.RES_ID), in_node, "RES_ID");
			TRS.copy(CEDCSUADAT.LINE_ID, sizeof(CEDCSUADAT.LINE_ID), in_node, "LINE_ID");
			memcpy(CEDCSUADAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCSUADAT.OPER));
			CEDCSUADAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
			memcpy(CEDCSUADAT.INS_TIME, s_sys_time, sizeof(CEDCSUADAT.INS_TIME));
			TRS.copy(CEDCSUADAT.INS_USER_ID, sizeof(CEDCSUADAT.INS_USER_ID), in_node, "CLIENT_ID");
			
			memcpy(CEDCSUADAT.RESULT_VALUE, s_result, sizeof(CEDCSUADAT.RESULT_VALUE));	

			TRS.copy(CEDCSUADAT.AOI_LOCATION, sizeof(CEDCSUADAT.AOI_LOCATION), INSP_ITEM[j], "AOI_LOCATION");
			TRS.copy(CEDCSUADAT.AOI_REASON_CODE, sizeof(CEDCSUADAT.AOI_REASON_CODE), INSP_ITEM[j], "AOI_REASON_CODE");
			TRS.copy(CEDCSUADAT.ML_LOCATION, sizeof(CEDCSUADAT.ML_LOCATION), INSP_ITEM[j], "ML_LOCATION");
			TRS.copy(CEDCSUADAT.ML_REASON_CODE, sizeof(CEDCSUADAT.ML_REASON_CODE), INSP_ITEM[j], "ML_REASON_CODE");
			CEDCSUADAT.INSPECTION_RESULT = TRS.get_char(INSP_ITEM[j], "INSPECTION_RESULT");
			TRS.copy(CEDCSUADAT.CELL_IMAGE, sizeof(CEDCSUADAT.CELL_IMAGE), INSP_ITEM[j], "CELL_IMAGE");
            TRS.copy(CEDCSUADAT.AOI_IMAGE, sizeof(CEDCSUADAT.AOI_IMAGE), INSP_ITEM[j], "AOI_IMAGE");
            
			if( CEDCLOTSUA.MODE_CODE != '0' )
			{
				CDB_insert_cedcsuadat(&CEDCSUADAT);
				if(DB_error_code != DB_SUCCESS)
				{
					// do notThing
				}
			}
			
        }
    }

    tran_in_node = TRS.create_node("INSPECTION_DATA_IN");
    tran_out_node = TRS.create_node("INSPECTION_DATA_OUT");
    


    //701번 메세지 받은 것을 가지고 700 번 메세지 호출.
    //CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  

    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
        TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_EL1);  
    else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
        TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_EL2);  
    else
        TRS.add_nstring(tran_in_node, "INS_TYPE", HQCEL_INS_TYPE_CATEGORY_EL1);  

    TRS.add_nstring(tran_in_node, "FACTORY", TRS.get_string(in_node, "FACTORY"));  
    TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));  
    TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
    TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
    TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
    //TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));
    TRS.add_string(tran_in_node, "RESULT", s_result, sizeof(s_result));
    if(strcmp(TRS.get_string(in_node, "TYPE_FLAG"), "2") == 0) /* Inspection Type - 1: by equipment, 2: by worker (reinspection) */
    {
        TRS.add_nstring(tran_in_node, "TYPE_FLAG", "2");
    }
    
    list_item = TRS.add_node(tran_in_node, "DEFECT_LIST");
    
    //PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    //i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");

    for(i = 0; i < i_insp_list_count; i++)
    {

        INSP_ITEM = TRS.get_list(INSP_LIST[i], "INSPECTION_ITEM");
        i_insp_item_count = TRS.get_item_count(INSP_LIST[i], "INSPECTION_ITEM");

	    for(j = 0; j < i_insp_item_count; j++)
        {
            list_param = TRS.add_node(list_item, "DEFECT_ITEM");
			/*
            SUALAB 아래의 기준으로 디펙트 결정
            MODE = 0 - 메뉴얼, MODE = 1 세미오토, 2 세미풀오토

            AOI_LOCATION = CWIPCELLOS.LOCATION_ID
            AOI_REASON_CODE = CWIPCELLOS.LOSS_CODE
            AOI_IMAGE = URL

            3 풀오토
            ML_LOCATION = CWIPCELLOS.LOCATION_ID
            ML_REASON_CODE = CWIPCELLOS.LOSS_CODE
            CELL_IMAGE
            */    
            //20191005 매뉴얼 모드를 제외한때는 과검일경우 CWIPCELLOS에 생성하지 않기 위한 구분자.
            //0: Not Use, 1:과검, 2:미검, 3:오검, 4:적합
            TRS.add_nstring(list_param, "INSPECTION_TYPE", HQCEL_INS_TYPE_CATEGORY_SUALAB );
            TRS.add_char(list_param, "INSPECTION_RESULT", TRS.get_char(INSP_ITEM[j],"INSPECTION_RESULT"));
            
            if(TRS.get_char(in_node, "MODE") == '0' || TRS.get_char(in_node, "MODE") == '1'|| TRS.get_char(in_node, "MODE") == '2')
            {
                if (TRS.mem_cmp(INSP_ITEM[j], "PARAM_NAME", "AOI_REASON_CODE", strlen(TRS.get_string(INSP_ITEM[j], "PARAM_NAME"))) == 0)
                {
                    TRS.add_nstring(list_param, "REASON_CODE", TRS.get_string(INSP_ITEM[j],"AOI_REASON_CODE"));
                }
            
                if (TRS.mem_cmp(INSP_ITEM[j], "PARAM_NAME", "AOI_LOCATION", strlen(TRS.get_string(INSP_ITEM[j], "PARAM_NAME"))) == 0)
                {
                    TRS.add_nstring(list_param, "LOC_ID", TRS.get_string(INSP_ITEM[j],"AOI_LOCATION"));
                }
            }
            else
            {
                if (TRS.mem_cmp(INSP_ITEM[j], "PARAM_NAME", "ML_REASON_CODE", strlen(TRS.get_string(INSP_ITEM[j], "PARAM_NAME"))) == 0)
                {
                    TRS.add_nstring(list_param, "REASON_CODE", TRS.get_string(INSP_ITEM[j],"ML_REASON_CODE"));
                }
            
                if (TRS.mem_cmp(INSP_ITEM[j], "PARAM_NAME", "ML_LOCATION", strlen(TRS.get_string(INSP_ITEM[j], "PARAM_NAME"))) == 0)
                {
                    TRS.add_nstring(list_param, "LOC_ID", TRS.get_string(INSP_ITEM[j],"ML_LOCATION"));
                }
            }
            
        }
    }
    

    if (EAPMES_COLLECT_INSPECTION_DATA(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
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
    EAPMES_Collect_Inspection_Data_Sualab_Validation()
        - Main sub function of "EAPMES_COLLECT_INSPECTION_DATA_SUALAB" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Sualab_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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