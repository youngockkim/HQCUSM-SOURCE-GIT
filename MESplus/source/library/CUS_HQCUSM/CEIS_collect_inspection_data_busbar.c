/*******************************************************************************

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_inspection_data_busbar.c
    Description : EAPMES Collect Inspection Data for Busbar Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Inspection_Data_Busbar()
            + Setup service interface function
        - EAPMES_COLLECT_INSPECTION_DATA_BUSBAR()
            + Main sub function of EAPMES_Collect_Inspection_Data_Busbar function
            + Setup service main business function
    Detail Description
        - EAPMES_COLLECT_INSPECTION_DATA_BUSBAR()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019/07/26  sy7.kwon       Create 

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "CUS_common.h"

int EAPMES_Collect_Inspection_Data_Busbar_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Busbar()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Busbar(TRSNode *in_node)
{	
	//struct	MGCMLAGDAT_TAG MGCMLAGDAT;	// 설비로 응답이 필요할 경우 추가

    char	s_msg_code[MP_SIZE_MSG];
	//char		s_channel[100];				// 설비로 응답이 필요할 경우 추가

    int		i_ret;

    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_INSPECTION_DATA_BUSBAR(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_INSPECTION_DATA_BUSBAR", out_node);

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


	// 설비로 응답이 필요할 경우 추가
	///* 특정 에러처리를 무시할경우 사용 ERROR  */
	//// VALIDATION 하라고 셋팅된 에러만 에러처리함.
	//DBC_init_mgcmlagdat(&MGCMLAGDAT);
	//TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	//memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
	//memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
	//memcpy(MGCMLAGDAT.KEY_2, "VALIDATION", strlen("VALIDATION"));
	//memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Assign_Magazine_To_Cart", strlen("EAPMES_Collect_Inspection_Data_Busbar"));
	//memcpy(MGCMLAGDAT.KEY_4, s_msg_code, 9);
	//DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	//if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'Y'))
	//{
	//	//VALIDATION SKIP 이 아닌경우 에러발생
	//	//MGCMLAGDAT TABLE (@FACTORY_OPTION)에서 DATA_1 = 'Y' 이면 에러발생
	//}
	//else
	//{
	//	//VALIDATION SKIP 일경우 무조건 성공 
	//	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	//}

	///* Common Data */
	//CCOM_copy_in_node(in_node, out_node);
	//TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	//TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	//TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	//TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
	//TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
	//TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

	///* Additional Data */
	//TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
	
	///* MES to EAP */
	//memset(s_channel, 0x00, sizeof(s_channel));
	//sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	////strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	//COM_add_null(s_channel, sizeof(s_channel));
	//
	//if(CallService(MODULE_EAP, 
	//				"MESEAP_Collect_Inspection_Data_Busbar",	// 응답 메시지 명
	//				out_node, 
	//				0x00, 
	//				s_channel, 
	//				gi_default_ttl, 
	//				DM_UNICAST) != MP_TRUE)
	//{
	//	// Error
	//}

    /* Save all received message log (CEISMSGLOG) */
    CEIS_Save_Message_Log_For_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_INSPECTION_DATA_BUSBAR()
        - Main sub function of "EAPMES_Collect_Inspection_Data_Busbar" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_INSPECTION_DATA_BUSBAR(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)	// CUS_HQCUSM_common.h 선언 추가
{
	// 사용할 변수 선언
    struct	MWIPLOTSTS_TAG MWIPLOTSTS;
    struct	MRASRESDEF_TAG MRASRESDEF;
	struct	CEDCINSDAT_TAG CEDCINSDAT;
    struct	CWIPCELLOS_TAG CWIPCELLOS;
	struct	CWIPLOTSTR_TAG CWIPLOTSTR;
	struct	CWIPLOTTRC_TAG CWIPLOTTRC;
	
	char	s_sys_time_stamp[20];
    char	s_sys_time[17];
	char	s_ins_type[2];
	char	resId[16];//for US-E1-BA-01, US-E2-BA-01, US-E3-BA-01 

	int		i, j;
	int		i_param_list_count;
	int		i_param_item_count;
	int		i_defect_list_count;
	int		i_defect_item_count;

	int		i_ins_cnt = 0;

	double	d_max_seq_num;

	TRSNode	**PARAM_LIST;
	TRSNode	**PARAM_ITEM;

	TRSNode	**DEFECT_LIST;
	TRSNode	**DEFECT_ITEM;

	TRSNode	*tran_in_node;
	TRSNode	*tran_out_node;
	
	// 사용할 문자열 초기화
    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memset(s_ins_type, ' ', sizeof(s_ins_type));
	memset(resId, 0, 16);

	// 설비/OI에서 전송한 in_node 값 전부 로그 작성
    LOG_head("EAPMES_COLLECT_INSPECTION_DATA_BUSBAR");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);  
	
    /********************************************************/
	/*	0. 현재 DB 시간 조회								*/
    /********************************************************/	 
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
	/*	1. Get Lot Info										*/
    /********************************************************/
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");

    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
       // Label 교체된 경우 EMI 레포트 데이터 맞지않아 수정 
	   // Lot 생성
	   TRSNode* create_tran_out_node = TRS.create_node("CREATE_TRAN_LOT_OUT");

	   EAPMES_CREATE_LOT(s_msg_code, in_node, create_tran_out_node);

	   // Save Module Image Path
	   CDB_init_cwiplottrc(&CWIPLOTTRC);
       TRS.copy(CWIPLOTTRC.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	   CDB_select_cwiplottrc_for_update(1, &CWIPLOTTRC);
	   if (DB_error_code != DB_SUCCESS)
	   {
		   memcpy(CWIPLOTTRC.WORK_DATE, s_sys_time, 8);
		   CDB_insert_cwiplottrc(&CWIPLOTTRC);
	   }

	   TRS.free_node(create_tran_out_node);
    }
	
    /********************************************************/
	/*	2. Save All Parameter Data (CEDCINSDAT)				*/
    /********************************************************/

	//	2-1. 설비에서 올려준 PARAM_LIST / count 
    PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");
	
    for(i = 0; i < i_param_list_count; i++)
    {
		//	2-2. PARAM_LIST 내의 PARAM_ITEM 리스트 / count
        PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
        i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");
		
        for(j = 0; j < i_param_item_count; j++)
        {
            d_max_seq_num = 0;

            CDB_init_cedcinsdat(&CEDCINSDAT);
            TRS.copy(CEDCINSDAT.LOT_ID, sizeof(CEDCINSDAT.LOT_ID), in_node, "LOT_ID");
            TRS.copy(CEDCINSDAT.RES_ID, sizeof(CEDCINSDAT.RES_ID), in_node, "RES_ID");
            memcpy(CEDCINSDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
            /*	
				CDB_select_cedcinsdat_scalar - case 2 

				SELECT NVL(MAX(SEQ_NUM),0)
				  FROM CEDCINSDAT
				 WHERE LOT_ID	 = :CEDCINSDAT_N.LOT_ID
				   AND RES_ID	 = :CEDCINSDAT_N.RES_ID
				   AND TRAN_TIME = :CEDCINSDAT_N.TRAN_TIME; 
			*/
            d_max_seq_num = CDB_select_cedcinsdat_scalar(2, &CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                // DO NOTHING
            }

            // 2-3. CEDCINSDAT에 모든 PARAM_ITEM 저장
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
            TRS.copy(CEDCINSDAT.PARAM_VALUE, sizeof(CEDCINSDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");

            CDB_insert_cedcinsdat(&CEDCINSDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                // DO NOTHING
            }
        }
    }

	// 2-4. CEDCINSDAT 테이블 입력 데이터 Commit
    DB_commit();
	
    /********************************************************/
	/*	3. Validation Check									*/
    /********************************************************/
    if(EAPMES_Collect_Inspection_Data_Busbar_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
    /********************************************************/
	/*	4. Check Resource									*/
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

	//for US-E1-BA-01, US-E2-BA-01, US-E3-BA-01 
    //추후 다른 테이블로 데이터 옮길예정.
	TRS.copy(resId, 11, in_node, "RES_ID");
	if(strcmp(resId, "US-E1-BA-01")==0)
		memcpy(s_ins_type, "B3", 2);	
	else if(strcmp(resId, "US-E2-BA-01")==0)
		memcpy(s_ins_type, "B3", 2);
	else if(strcmp(resId, "US-E3-BA-01")==0)
		memcpy(s_ins_type, "B3", 2);
	else
		memcpy(s_ins_type, HQCEL_INS_TYPE_CATEGORY_BUSBAR1, strlen(HQCEL_INS_TYPE_CATEGORY_BUSBAR1));

	//if(TRS.get_char(in_node, "PROCSTEP") == '1')
	//{
	//	// PROCSTEP = 1 : ELU-01	
	//	// INS_TYPE = B1
	//	memcpy(s_ins_type, HQCEL_INS_TYPE_CATEGORY_BUSBAR1, strlen(HQCEL_INS_TYPE_CATEGORY_BUSBAR1));
	//}
	//else if(TRS.get_char(in_node, "PROCSTEP") == '2')
	//{
	//	// PROCSTEP = 2 : BA-01 (MANUAL)
	//	// INS_TYPE = B2
	//	memcpy(s_ins_type, HQCEL_INS_TYPE_CATEGORY_BUSBAR2, strlen(HQCEL_INS_TYPE_CATEGORY_BUSBAR2));
	//}
	//else
	//{
	//	// 일단 1번?
	//	memcpy(s_ins_type, HQCEL_INS_TYPE_CATEGORY_BUSBAR1, strlen(HQCEL_INS_TYPE_CATEGORY_BUSBAR1));
	//}

    /********************************************************/
	/*	5. Save Inspection Data and Result					*/
    /********************************************************/
    tran_in_node = TRS.create_node("UPDATE_INSP_DATA_IN");
    tran_out_node = TRS.create_node("UPDATE_INSP_DATA_OUT");

    CCOM_copy_in_node(in_node, tran_in_node);
	TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
    TRS.add_nstring(tran_in_node, "INS_TYPE", s_ins_type);  
    TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));  
	TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
    TRS.add_nstring(tran_in_node, "LINE_ID", TRS.get_string(in_node,"LINE_ID"));
    TRS.add_nstring(tran_in_node, "CLIENT_ID", TRS.get_string(in_node,"CLIENT_ID"));
    TRS.add_nstring(tran_in_node, "RESULT", TRS.get_string(in_node,"RESULT"));
    TRS.add_char(tran_in_node, "TYPE_FLAG", '1');	/* Inspection Type - 1: by equipment, 2: by worker (reinspection) */ 

    if(CEDC_UPDATE_INSPECTION_DATA(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
        TRS.clone(out_node, tran_out_node);
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

        TRS.free_node(tran_in_node);
        TRS.free_node(tran_out_node);

		return MP_FALSE;
	}
	
	i_ins_cnt = TRS.get_int(tran_out_node, "INS_CNT");	// i_ins_cnt = CEDECLOTRLT.INS_CNT
	
    /********************************************************/
	/*	6. Save Loss Data									*/
    /********************************************************/
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
            d_max_seq_num = 0;
            CDB_init_cwipcellos(&CWIPCELLOS);
            TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, IN_FACTORY);
            memcpy(CWIPCELLOS.LOSS_CATEGORY, s_ins_type, sizeof(s_ins_type));
            TRS.copy(CWIPCELLOS.CELL_ID, sizeof(CWIPCELLOS.CELL_ID), in_node, "LOT_ID");
			/* 
				CDB_select_cwipcellos_scalar - case 2 :

				SELECT NVL(MAX(LOSS_SEQ),0) 
                  FROM CWIPCELLOS
				 WHERE FACTORY		 = :CWIPCELLOS_N.FACTORY
                   AND LOSS_CATEGORY = :CWIPCELLOS_N.LOSS_CATEGORY
                   AND CELL_ID		 = :CWIPCELLOS_N.CELL_ID;
			*/
            d_max_seq_num = CDB_select_cwipcellos_scalar(2, &CWIPCELLOS);
            if(DB_error_code != DB_SUCCESS)
            {
				TRS.free_node(tran_in_node);
				TRS.free_node(tran_out_node);
                return MP_TRUE;
            }
				
            /* Insert defect items */
            CWIPCELLOS.LOSS_SEQ = (int)++d_max_seq_num;
            TRS.copy(CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE), DEFECT_ITEM[j], "REASON_CODE");
            TRS.copy(CWIPCELLOS.LINE_ID, sizeof(CWIPCELLOS.LINE_ID), in_node, "LINE_ID");
            TRS.copy(CWIPCELLOS.RES_ID, sizeof(CWIPCELLOS.RES_ID), in_node, "RES_ID");
            TRS.copy(CWIPCELLOS.LOT_ID, sizeof(CWIPCELLOS.LOT_ID), in_node, "LOT_ID");
            TRS.copy(CWIPCELLOS.LOCATION_ID, sizeof(CWIPCELLOS.LOCATION_ID), DEFECT_ITEM[j], "LOC_ID");
            TRS.copy(CWIPCELLOS.RESULT_VALUE, sizeof(CWIPCELLOS.RESULT_VALUE), in_node, "RESULT");
            CWIPCELLOS.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
            memcpy(CWIPCELLOS.CREATE_TIME, s_sys_time, sizeof(CWIPCELLOS.CREATE_TIME));
            memcpy(CWIPCELLOS.TRAN_TIME, s_sys_time, sizeof(CWIPCELLOS.TRAN_TIME));

            CWIPCELLOS.INS_CNT = i_ins_cnt; // CEDECLOTRLT.INS_CNT

			// LOCATION 에 따른 위치GET
			CDB_init_cwiplotstr(&CWIPLOTSTR);
			TRS.copy(CWIPLOTSTR.FACTORY, sizeof(CWIPLOTSTR.FACTORY), in_node, IN_FACTORY);
			TRS.copy(CWIPLOTSTR.LOT_ID, sizeof(CWIPLOTSTR.LOT_ID), in_node, "LOT_ID");
			CWIPLOTSTR.STRING_LOC[0] = CWIPCELLOS.LOCATION_ID[0];
			// location : A1->A01 로 바꿈..
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
				
			if (COM_isspace(CWIPCELLOS.ORDER_ID, sizeof(CWIPCELLOS.ORDER_ID)) == MP_TRUE)
			{
				memcpy(CWIPCELLOS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			}
				
            CDB_insert_cwipcellos(&CWIPCELLOS);
            if(DB_error_code != DB_SUCCESS)
            {
                //DO NOTHING
            }
        }
    }

	//Matrix Defect 3 times
	if(CEDC_UPDATE_MATRIX_DEFECT_ALARM(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
	{
		//DO NOTHING
	}

	TRS.free_node(tran_in_node);
    TRS.free_node(tran_out_node);

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Collect_Inspection_Data_Busbar_Validation()
        - Main sub function of "EAPMES_COLLECT_INSPECTION_DATA_BUSBAR" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Inspection_Data_Busbar_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{	

    return MP_TRUE;
}