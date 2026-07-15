/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_validate_lot_fqc.c
    Description : EAPMES Validate Lot for FQC Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Validate_Lot_FQC()
            + Setup service interface function
        - EAPMES_VALIDATE_LOT_FQC()
            + Main sub function of EAPMES_Validate_Lot_FQC function
            + Setup service main business function
        - EAPMES_Validate_Lot_FQC_Validation()
            + Main sub function of EAPMES_VALIDATE_LOT_FQC function
    Detail Description
        - EAPMES_VALIDATE_LOT_FQC()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Validate_Lot_FQC_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Validate_Lot_FQC()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Lot_FQC(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_VALIDATE_LOT_FQC(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_VALIDATE_LOT_FQC", out_node);

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

   /* 특정 에러처리를 무시할경우 사용 ERROR  */
	// VALIDATION 하라고 셋팅된 에러만 에러처리함.
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@FACTORY_OPTION", strlen("@FACTORY_OPTION"));
	memcpy(MGCMLAGDAT.KEY_1, "EIS_OPTION", strlen("EIS_OPTION"));
	memcpy(MGCMLAGDAT.KEY_2, "VALIDATION", strlen("VALIDATION"));
	memcpy(MGCMLAGDAT.KEY_3, "EAPMES_Validate_Lot_FQC", strlen("EAPMES_Validate_Lot_FQC"));
	memcpy(MGCMLAGDAT.KEY_4, s_msg_code, 9);
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if(DB_error_code == DB_SUCCESS)
	{
		if(MGCMLAGDAT.DATA_1[0] == 'Y')
		{
			//VALIDATION SKIP 이 아닌경우 에러발생
			//MGCMLAGDAT TABLE (@FACTORY_OPTION)에서 DATA_1 = 'Y' 이면 에러발생
		}
		else
		{
			//VALIDATION SKIP 일경우 무조건 성공
			//2019/09/03
			//Use the error message instead of CMN-0000 but the message is still success
			COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		}
	}
   
    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_nstring(out_node, "PALLET_ID", TRS.get_string(in_node, "PALLET_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
	/*— [ERP PROJECT]— 시작****************************************************************/
	//[ERP 23.05.23]
	TRS.set_nstring(out_node, "UNPACK_REWORK", TRS.get_string(in_node, "UNPACK_REWORK"));
	/* - [GERP PROJECT] 끝****************************************************************/
	TRS.set_nstring(out_node, "RESULT_VALUE", TRS.get_string(in_node, "RESULT_VALUE"));
	TRS.set_nstring(out_node, "IS_FRONT_REPAIRED", TRS.get_string(in_node, "IS_FRONT_REPAIRED"));
	TRS.set_nstring(out_node, "INVERTER_RESULT", TRS.get_string(in_node, "INVERTER_RESULT"));

    LOG_head("EAPMES_VALIDATE_LOT_FQC (out_node)");
    TRS.log_add_all_members(out_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Validate_Lot_FQC", 
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
    EAPMES_VALIDATE_LOT_FQC()
        - Main sub function of "EAPMES_Validate_Lot_FQC" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_VALIDATE_LOT_FQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPLOTPAK_TAG CWIPLOTPAK_AC;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	struct CWIPLOTREP_TAG CWIPLOTREP;
	struct CWIPRWKDAT_TAG CWIPRWKDAT;// 2023-03-08 JSLEE ADD
	//struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct CWIPORDBOM_TAG CWIPORDBOM;	//25.09.08
	struct CWIPACMHIS_TAG CWIPACMHIS;	//25.09.08
	struct MWIPLOTSTS_TAG MWIPLOTSTS_S;	//26.01.27
	struct CWIPACMHIS_TAG CWIPACMHIS_PCU;   //26.01.13 add
	

	int inverter_lenth ;
	char invter_flag = ' ';
	char inverter_PCU_SN[30] ;
	char invter_rework_flag = ' ';
	char s_sys_time_stamp[20];		//26.01.27


    char   ok_ng = ' ';
    
	LOG_head("EAPMES_VALIDATE_LOT_FQC");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
	
    if(EAPMES_Validate_Lot_FQC_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	//2019/09/03
	//CMN-0000 by default
	strcpy(s_msg_code, "CMN-0000");

	//CDB_init_cwiprwkdat(&CWIPRWKDAT);// 2023-03-09 JSLEE
	////TRS.set_string(in_node, "MODULE_ID", "903322522468300552", strlen("903322522468300552")); // 2023-03-09 JSLEE
	//memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));// 2023-03-09 JSLEE
	////memcpy(CWIPRWKDAT.MODULE_ID, CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID));// 2023-03-09 JSLEE
	//TRS.copy(CWIPRWKDAT.MODULE_ID, sizeof(CWIPRWKDAT.MODULE_ID), in_node, "LOT_ID");
	//CDB_select_cwiprwkdat(3, &CWIPRWKDAT);
	//if(DB_error_code != DB_SUCCESS)
	//{
	//	return MP_FALSE;
	//}
	
	/* Validate the Lot ID */
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0044");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	
	TRS.set_string(in_node, "RESULT_VALUE", "OK", strlen("OK"));
	TRS.set_string(in_node, "INVERTER_RESULT", "OK", strlen("OK"));

	//이미 TERMINATE 된 LOT CHECK
	if (MWIPLOTSTS.LOT_DEL_FLAG == 'Y')
	{
		TRS.set_string(in_node, "RESULT_VALUE", "NG", strlen("NG"));
		//2019/09/03
		//WIP-0594 message if the module is terminated
		strcpy(s_msg_code, "WIP-0594");
	}
	else
	{
		//PACKING 에서 LOT VALIDATION 을 위해 보낸데이터 일경우 체크
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, MWIPLOTSTS.FACTORY,sizeof(MWIPLOTSTS.FACTORY));
		memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		
		//C: COMPLETE,  I:INITIAL(AUTO PACKING 에서 사용함)	, //D: ERP->MES PACKING 해제된 LOT
		CWIPLOTPAK.STATUS_FLAG = 'C';  

		//PACKING LOT CHECK : 이미 PACKING 완료(COMPLETE) 된 모듈은 재FQC 못하게함.
		if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)
		{
			TRS.set_string(in_node, "RESULT_VALUE", "NG", strlen("NG"));
			/*
			if(memcmp(TRS.get_string(in_node, "INVERTER_BCR_ID"), "111111111111", strlen("111111111111")) != 0){
				TRS.set_string(in_node, "INVERTER_RESULT", "NG", strlen("NG"));
			}
			*/
			//2019/09/03
			//WIP-0564 message if the module is already packed
			strcpy(s_msg_code, "WIP-0564");
		}

		if(memcmp(TRS.get_string(in_node, "INVERTER_BCR_ID"), "111111111111", strlen("111111111111")) != 0){
			
			CDB_init_cwiplotpak(&CWIPLOTPAK_AC);
			memcpy(CWIPLOTPAK_AC.FACTORY, MWIPLOTSTS.FACTORY,sizeof(MWIPLOTSTS.FACTORY));
			TRS.copy(CWIPLOTPAK_AC.PCU_SN, sizeof(CWIPLOTPAK_AC.PCU_SN), in_node, "INVERTER_BCR_ID");

			if (CDB_select_cwiplotpak_scalar(5, &CWIPLOTPAK_AC) > 0)
			{
				TRS.set_string(in_node, "INVERTER_RESULT", "NG", strlen("NG"));
			}
		}
	}

	//[26.01.27][MES] 이글 1 FQC-01 보고 누락 Inverter 부착 로직 기술 검토 요청의 건 - start
	if(	(
			memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE1_FQC2, strlen(HQCEL_M1_RES_LINE1_FQC2)) == 0 ||
			memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE2_FQC2, strlen(HQCEL_M1_RES_LINE2_FQC2)) == 0 ||
			memcmp(TRS.get_string(in_node, "RES_ID"), HQCEL_M1_RES_LINE3_FQC2, strlen(HQCEL_M1_RES_LINE3_FQC2)) == 0 
			)
			&&
			(
			memcmp(TRS.get_string(in_node, "INVERTER_BCR_ID"), "111111111111", strlen("111111111111")) != 0
			&&
			COM_isnullspace(TRS.get_string(in_node, "INVERTER_BCR_ID")) == MP_FALSE)	
			)
		
		{
			memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  
			DB_get_systime_m(s_sys_time_stamp);
			//select lot info
			DBC_init_mwiplotsts(&MWIPLOTSTS_S);
			TRS.copy(MWIPLOTSTS_S.LOT_ID, sizeof(MWIPLOTSTS_S.LOT_ID), in_node, "LOT_ID");
			DBC_select_mwiplotsts(1, &MWIPLOTSTS_S);	
			//만약 LOT_CMF_15에 데이터가 없으면 저장을 다시 한번 한다.
			if(DB_error_code == DB_SUCCESS)
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					if (COM_isspace(MWIPLOTSTS_S.LOT_CMF_15, sizeof(MWIPLOTSTS_S.LOT_CMF_15)) == MP_TRUE)
					{
						//insert ac info
						CDB_init_cwipacmhis(&CWIPACMHIS);
						memcpy(CWIPACMHIS.FACTORY, MWIPLOTSTS_S.FACTORY, sizeof(CWIPACMHIS.FACTORY));
						TRS.copy(CWIPACMHIS.LOT_ID, sizeof(CWIPACMHIS.LOT_ID), in_node, "LOT_ID");
						TRS.copy(CWIPACMHIS.RES_ID, sizeof(CWIPACMHIS.RES_ID), in_node, "RES_ID");

						//PCU_SN
						TRS.copy(CWIPACMHIS.PCU_SN, sizeof(CWIPACMHIS.PCU_SN), in_node, "INVERTER_BCR_ID");

						if(COM_isnullspace(CWIPACMHIS.PCU_SN) == MP_FALSE)
						{
							memcpy(CWIPACMHIS.CMF_1, "D", strlen("D"));
						}

						//TRS.copy(CWIPACMHIS.CLIENT_TIME, sizeof(CWIPACMHIS.CLIENT_TIME), in_node, "CLIENT_TIME");
						memcpy(CWIPACMHIS.CLIENT_TIME, s_sys_time_stamp, sizeof(CWIPACMHIS.CLIENT_TIME));
						memcpy(CWIPACMHIS.CREATE_TIME, s_sys_time_stamp, sizeof(CWIPACMHIS.CREATE_TIME));
						memcpy(CWIPACMHIS.CREATE_USER_ID, "FQC-02", strlen("FQC-02"));

						CDB_insert_cwipacmhis(&CWIPACMHIS);

						//update AC Inverter Id 
						DBC_init_mwiplotsts(&MWIPLOTSTS_S);
						TRS.copy(MWIPLOTSTS_S.LOT_ID, sizeof(MWIPLOTSTS_S.LOT_ID), in_node, "LOT_ID");
						TRS.copy(MWIPLOTSTS_S.LOT_CMF_15, sizeof(MWIPLOTSTS_S.LOT_CMF_15), in_node, "INVERTER_BCR_ID");


						CDB_update_mwiplotsts(10, &MWIPLOTSTS_S);
						{
							//DO Nothing
							DB_commit();
						}





					}
				}
			}

		}

	//[26.01.27][MES] 이글 1 FQC-01 보고 누락 Inverter 부착 로직 기술 검토 요청의 건 - end

	TRS.set_string(in_node, "IS_FRONT_REPAIRED", "OK", strlen("OK"));

	CDB_init_cwiplotrep(&CWIPLOTREP);
	TRS.copy(CWIPLOTREP.FACTORY, sizeof(CWIPLOTREP.FACTORY), in_node, IN_FACTORY);
	memcpy(CWIPLOTREP.CATEGORY,"R-E1", strlen("R-E1"));
	TRS.copy(CWIPLOTREP.LOT_ID, sizeof(CWIPLOTREP.LOT_ID), in_node, "LOT_ID");
	if(CDB_select_cwiplotrep_scalar(1, &CWIPLOTREP) > 0)
	{
		TRS.set_string(in_node, "IS_FRONT_REPAIRED", "NG", strlen("NG"));
	}

	//[25.09.08]AC Moudle Inverter FQC Validation 로직 - Start.
	if(memcmp(TRS.get_string(in_node, "INVERTER_BCR_ID"), "111111111111", strlen("111111111111")) != 0
			&&
			COM_isnullspace(TRS.get_string(in_node, "INVERTER_BCR_ID")) == MP_FALSE)	
			
	{


			inverter_lenth = strlen(TRS.get_string(in_node, "INVERTER_BCR_ID"));
			
			if(inverter_lenth > 4)
			{
				//Rework 오더인지 체크
				CDB_init_cwiprwkdat(&CWIPRWKDAT);
				TRS.copy(CWIPRWKDAT.FACTORY, sizeof(CWIPRWKDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(CWIPRWKDAT.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(CWIPRWKDAT.MODULE_ID));
				memcpy(CWIPRWKDAT.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(CWIPRWKDAT.PROD_ORDER_NO));
					
				CDB_select_cwiprwkdat(1,&CWIPRWKDAT);
				if(DB_error_code != DB_SUCCESS) 
				{
					if(DB_error_code == DB_NOT_FOUND)
					{

					}
					else
					{

					}


				}
				else
				{
					invter_rework_flag = 'Y';	
				}

				memset(inverter_PCU_SN, ' ', sizeof(inverter_PCU_SN));  
				TRS.copy(inverter_PCU_SN, sizeof(CWIPACMHIS.PCU_SN), in_node, "INVERTER_BCR_ID");
				invter_flag =  inverter_PCU_SN[3];
				CDB_init_cwipordbom(&CWIPORDBOM);
				TRS.copy(CWIPORDBOM.FACTORY, sizeof(CWIPORDBOM.FACTORY), in_node, "FACTORY");
				
				if(invter_rework_flag == 'Y')
				{
					memcpy(CWIPORDBOM.ORDER_ID, CWIPRWKDAT.CMF_4, sizeof(CWIPORDBOM.ORDER_ID));
				}
				else
				{
					memcpy(CWIPORDBOM.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
				}


				if(invter_flag == '1')
				{
					memcpy(CWIPORDBOM.MAT_ID, "SPMD-00001", 10);
				//	memcpy(CWIPORDBOM.MATE_TYPE, " ", 1);
					CDB_select_cwipordbom(2, &CWIPORDBOM);
				}
				else if(invter_flag =='2')
				{
					memcpy(CWIPORDBOM.MAT_ID, "SPMD-00002", 10);
			//		memcpy(CWIPORDBOM.MATE_TYPE, " ", 1);
					CDB_select_cwipordbom(2, &CWIPORDBOM);
				}
				if (DB_error_code != DB_SUCCESS)
				{
					 if (DB_error_code == DB_NOT_FOUND)
					{
						//[26.03.06]터 MES 밸리데이션 NG Reason Code 테이블 저장 로직 개발
						CDB_init_cwipacmhis(&CWIPACMHIS_PCU);
						memcpy(CWIPACMHIS_PCU.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CWIPACMHIS.FACTORY));
						memcpy(CWIPACMHIS_PCU.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
						memcpy(CWIPACMHIS_PCU.PCU_SN, MWIPLOTSTS.LOT_CMF_15, sizeof(CWIPACMHIS_PCU.PCU_SN));
						memcpy(CWIPACMHIS_PCU.CMF_2, "WIP-0665", strlen("WIP-0665"));
						CDB_update_cwipacmhis(2, &CWIPACMHIS_PCU);
						if(DB_error_code != DB_SUCCESS)
						{
							// DO NOTHING
						}


						DB_commit();

						//[26.03.06]터 MES 밸리데이션 NG Reason Code 테이블 저장 로직 개발

						TRS.set_string(in_node, "INVERTER_RESULT", "NG", strlen("NG"));
						TRS.add_fieldmsg(out_node, "CWIPORDBOM SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTFQC.FACTORY), CEDCLOTFQC.FACTORY);
						TRS.add_fieldmsg(out_node, "CWIPORDBOM", MP_STR, sizeof(CWIPORDBOM.ORDER_ID), CWIPORDBOM.ORDER_ID);
						TRS.add_dberrmsg(out_node,DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						
						//[26.03.13][2차기술검토]-[MES] AC 인버터 MES 밸리데이션 NG Reason Code 테이블 저장 로직 개발 요청의 건
						strcpy(s_msg_code, "WIP-0665");
						TRS.set_string(out_node, OUT_MSGCODE, s_msg_code, 8);
						TRS.set_string(out_node, OUT_MSG, s_msg_code, strlen(s_msg_code));
						//[26.03.13][2차기술검토]-[MES] AC 인버터 MES 밸리데이션 NG Reason Code 테이블 저장 로직 개발 요청의 건
						

						return MP_FALSE;
					}

				
				}

    

			}
	}
	//[25.09.08]AC Moudle Inverter FQC Validation 로직 - End


	
	//2019/09/03
	//Don't check CEDCLOTFQC if the validation is requested from EAP
	//Not even sure why this code is implemented in here
	if(strcmp(TRS.get_string(in_node, "CLIENT_ID"), "EAP") != 0)
	{
		//검사정보가 하나라도 없으면 ERR처리
		CDB_init_cedclotfqc(&CEDCLOTFQC);
		TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTFQC.INS_TYPE, "FC", strlen("FC"));
		TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
		/*
		SELECT 
		LOT_ID
		,MAX(DECODE(INS_TYPE,'FC',RESULT_VALUE,' ')) FQC_RESULT
		,MAX(DECODE(INS_TYPE,'ET',RESULT_VALUE,' ')) AOI_RESULT
		,MAX(DECODE(INS_TYPE,'HI',RESULT_VALUE,' ')) HVT_RESULT
		,MAX(DECODE(INS_TYPE,'E2',RESULT_VALUE,' ')) BEL_RESULT
		,MAX(DECODE(INS_TYPE,'GR',RESULT_VALUE,' ')) GRT_RESULT
		,MAX(DECODE(INS_TYPE,'SI',RESULT_VALUE,' ')) SIM_RESULT
		,MAX(DECODE(INS_TYPE,'SI',PMPP,' ')) FLASH_PMAX
		FROM CEDCLOTRLT 
		WHERE FACTORY = 'USGAM1'
		AND INS_TYPE IN ('E2','ET','FC','GR','HI','SI')
		AND LOT_ID = '203319441522190003'
		GROUP BY LOT_ID ;
		*/	
	
		CDB_select_cedclotfqc(3, &CEDCLOTFQC);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0573");//WIP-0573 : 이 모듈은 존재 하지 않습니다. 확인 하세요.
				TRS.add_fieldmsg(out_node, "CEDCLOTFQC SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTFQC.FACTORY), CEDCLOTFQC.FACTORY);
				TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTFQC.INS_TYPE), CEDCLOTFQC.INS_TYPE);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTFQC.LOT_ID), CEDCLOTFQC.LOT_ID);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CEDCLOTFQC SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTFQC.FACTORY), CEDCLOTFQC.FACTORY);
				TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTFQC.INS_TYPE), CEDCLOTFQC.INS_TYPE);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTFQC.LOT_ID), CEDCLOTFQC.LOT_ID);
				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		if(CEDCLOTFQC.AOI_RESULT[0] == ' ')
		{
			ok_ng = 'A';
			TRS.add_fieldmsg(out_node, "NOT_FOUND_AOI", MP_STR, strlen("AOI_RESULT"), "AOI_RESULT");
		}
		if(CEDCLOTFQC.HVT_RESULT[0] == ' ')
		{
			ok_ng = 'H';
			TRS.add_fieldmsg(out_node, "NOT_FOUND_HVT", MP_STR, strlen("HVT_RESULT"), "HVT_RESULT");
		}
		if(CEDCLOTFQC.GRT_RESULT[0] == ' ')
		{
			ok_ng = 'G';
			TRS.add_fieldmsg(out_node, "NOT_FOUND_GRT", MP_STR, strlen("GRT_RESULT"), "GRT_RESULT");
		}
		if(CEDCLOTFQC.SIM_RESULT[0] == ' ')
		{
			ok_ng = 'S';
			TRS.add_fieldmsg(out_node, "NOT_FOUND_SIM", MP_STR, strlen("SIM_RESULT"), "SIM_RESULT");
		}
		if(CEDCLOTFQC.BEL_RESULT[0] == ' ')
		{
			ok_ng = 'R';
			TRS.add_fieldmsg(out_node, "NOT_FOUND_BEL", MP_STR, strlen("BEL_RESULT"), "BEL_RESULT");
		}
		if(CEDCLOTFQC.FLASH_PMAX[0] == ' ')
		{
			ok_ng = 'F';
			TRS.add_fieldmsg(out_node, "NOT_FOUND_PMAX", MP_STR, strlen("FLASH_PMAX"), "FLASH_PMAX");
		}

		if(ok_ng != ' ')
		{
			TRS.set_string(in_node, "RESULT_VALUE", "NG", strlen("NG"));

			strcpy(s_msg_code, "EDC-0098");
			TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTFQC.FACTORY), CEDCLOTFQC.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTFQC.LOT_ID), CEDCLOTFQC.LOT_ID);
			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	/* - [GERP PROJECT] [ERP 23.05.26] 시작****************************************************************/
	/*
	* [23.05.26] CIM 재작업 관련 정보 추가 - UNPACK_VALUE 2를 제외한 값은 사용하지 않기 때문에 따로 넣지 않음
	RESULT_VALUE : RW 
	1 = 패킹 자체가 이루어지지 않은 모듈
	2 = 언패킹 되어 재 투입되었으나, REWORK 작업 지시가 없는 모듈
	3 = 언패킹 되어 재 투입되었으나, REWORK 작업 지시가 있는 모듈
	4 = 이미 패킹된 모듈
	*/
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID");
	// 2023-05-04 JHEE PACKING 여부와 이력 확인 
	if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
	{
		//PACKING 이력이 있을 경우 재작업 ORDER  유무를 확인 해야 한다. 
		CDB_init_cwiprwkdat(&CWIPRWKDAT);
		memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPRWKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
		//재작업 ORDER가 없다면 
		if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) <= 0)// 2023-03-09 JSLEE ADD
		{
			TRS.set_string(in_node, "RESULT_VALUE", "RW", strlen("RW"));
			TRS.set_string(in_node, "UNPACK_REWORK", "2", strlen("2"));
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Validate_Lot_FQC_Validation()
        - Main sub function of "EAPMES_VALIDATE_LOT_FQC" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Lot_FQC_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
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

