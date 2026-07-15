/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_buffercount_inquiry_res.c
    Description : 

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_BufferCount_Inquiry_RES()
            + Setup service interface function
        - EAPMES_BufferCount_Inquiry_RES()
            + Main sub function of EAPMES_BufferCount_Inquiry_RES function
            + Setup service main business function
    Detail Description
        - EAPMES_BufferCount_Inquiry_RES()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     yyyy/mm/dd  developer      desc 

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_BUFFERCOUNT_INQUIRY_RES(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	// CUS_HQCUSM_common.h 선언해주면 필요없음

/*******************************************************************************
    EAPMES_BufferCount_Inquiry_RES()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_BufferCount_Inquiry_RES(TRSNode *in_node)		// CUS_HQCUSM_service.h	/ CUSHQCUSMAddService.c 선언 추가
{	
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;
    TRSNode *out_node;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_BUFFERCOUNT_INQUIRY_RES(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_BufferCount_Inquiry_RES", out_node);

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
	

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);				// CEISMSGLOG 테이블에 이력 남김 
    //CEIS_Save_Message_Log_For_List(in_node, out_node);	// CEISMSGLOG 테이블에 이력 남김 (out_node에 List 가 있을 경우) ??

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_BUFFERCOUNT_INQUIRY_RES()
        - Main sub function of "EAPMES_BufferCount_Inquiry_RES" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_BUFFERCOUNT_INQUIRY_RES(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)	// CUS_HQCUSM_common.h 선언 추가
{
	// 사용할 변수 선언  
	struct CALMTLGHIS_TAG CALMTLGHIS;
	struct CWIPCELLOS_TAG CWIPCELLOS;
	struct MRASRESDEF_TAG MRASRESDEF;

	struct CEDCBUFDAT_TAG CEDCBUFDAT;
	struct CEDCBUFHIS_TAG CEDCBUFHIS;

	char s_sys_time[14];
	char s_work_date[8];
	char message[130];

	char buffercount[20];

	/*
	char *line = (char*)malloc(sizeof(char) * (2 + 1));
	char *res = (char*)malloc(sizeof(char) * (10 + 1));
	char *tab = (char*)malloc(sizeof(char) * (63 + 1));
	*/
	// 20210810 MES Application Memory leak 점검 및 수정
	char line[2+1];
	char res[10+1];
	char tab[63+1];
	memset(line, 0x00, sizeof(line));
	memset(res, 0x00, sizeof(res));
	memset(tab, 0x00, sizeof(tab));

	// 설비/OI에서 전송한 in_node 값 전부 로그 작성
    LOG_head("EAPMES_BufferCount_Inquiry_RES");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);  


	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(s_work_date, ' ', sizeof(s_work_date));


	memset(buffercount, 0x00, sizeof(buffercount));

	DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);

        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
		
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

		// 20210810 MES Application Memory leak 점검 및 수정
		// malloc 제거로 주석처리
		/*
		free(line); //IS-21-01-094 MES logic 개선
		free(res);
		free(tab);
		*/
        return MP_FALSE;
    }

	memcpy(s_work_date, s_sys_time, sizeof(s_work_date));


	// When the buffer is full
	//if(memcmp(TRS.get_string(in_node, "BUFFER_COUNT"), "14", 2) == 0)
    //IS-21-09-089	[MC개발]1라인 전단 버퍼 신규 인터페이스 개발
	if(memcmp(TRS.get_string(in_node, "BUFFER_COUNT"), "14", 2) == 0
		&& (memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-ELB-01", 12) == 0 || 
		    memcmp(TRS.get_string(in_node, "RES_ID"), "US-E1-ELB-02", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-ELB-01", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E2-ELB-02", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-ELB-01", 12) == 0 || 
			memcmp(TRS.get_string(in_node, "RES_ID"), "US-E3-ELB-02", 12) == 0)
		)
	{
		DBC_init_mrasresdef(&MRASRESDEF);
		memcpy(MRASRESDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");

		DBC_select_mrasresdef(1, &MRASRESDEF);

		// 연속 풀이면 Telegram 전송 안한다. 
		if(memcmp(MRASRESDEF.RES_CMF_15, "14", 2) == 0)
		{
			// 20210810 MES Application Memory leak 점검 및 수정
			// malloc 제거로 주석처리
			/*
			free(line); //IS-21-01-094 MES logic 개선
			free(res);
			free(tab);
			*/
			return MP_FALSE;
		}


		// DEFECT 수량 많은 3개 태버 조회
		CDB_init_cwipcellos(&CWIPCELLOS);
		memcpy(CWIPCELLOS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(CWIPCELLOS.WORK_DATE, s_work_date, sizeof(s_work_date));

		//strncpy(line, (TRS.get_string(in_node, "RES_ID") + 3), 2);
		// 20210810 MES Application Memory leak 점검 및 수정
		// memcpy 메모리 침범 수정
		memcpy(line, MRASRESDEF.RES_ID + 3, 2);

		line[2] = 0x00;
		if(memcmp(line, "E1", 2) == 0)
		{
			memcpy(CWIPCELLOS.LINE_ID, "MDL01", strlen("MDL01"));
		} 
		else if(memcmp(line, "E2", 2) == 0)
		{
			memcpy(CWIPCELLOS.LINE_ID, "MDL02", strlen("MDL02"));
		}
		else if(memcmp(line, "E3", 2) == 0)
		{
			memcpy(CWIPCELLOS.LINE_ID, "MDL03", strlen("MDL03"));
		}

		CDB_select_cwipcellos(3, &CWIPCELLOS);

		if(DB_error_code != DB_SUCCESS)
		{ 
			//DO NOTHING
		}


		CDB_init_calmtlghis(&CALMTLGHIS);
		memcpy(CALMTLGHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		if(COM_isnullspace(TRS.get_string(in_node, "NOTIFY_SYSTEM")) == MP_FALSE)
		{
			TRS.copy(CALMTLGHIS.NOTIFY_SYSTEM, sizeof(CALMTLGHIS.NOTIFY_SYSTEM), in_node, "NOTIFY_SYSTEM");
		}
		else
		{
			memcpy(CALMTLGHIS.NOTIFY_SYSTEM, "HQcellUS_EL_Buffer", strlen("HQcellUS_EL_Buffer"));
		}

		memcpy(CALMTLGHIS.TRAN_TIME, s_sys_time, sizeof(CALMTLGHIS.TRAN_TIME));
		TRS.copy(CALMTLGHIS.CMF_1, sizeof(CALMTLGHIS.CMF_1), in_node, "RES_ID");
		

		//strncpy(res, (TRS.get_string(in_node, "RES_ID") + 3), 10);

		// 20210810 MES Application Memory leak 점검 및 수정
		// memcpy 메모리 침범 수정
		memcpy(res, CALMTLGHIS.CMF_1 + 3, 10);
		strncpy(tab, CWIPCELLOS.LOSS_COMMENT, 63);
		tab[63] = 0x00;
		//sprintf(message , "#%s buffer is FULL.%c%cTop 3 Tabbers with High Defect Qty%s" , res, (char)13,(char)10, tab);

		// 20210810 MES Application Memory leak 점검 및 수정
		// memcpy 메모리 침범 수정
		_snprintf_s(message, _countof(message), _countof(message)-1, "#%s buffer is FULL.%c%cTop 3 Tabbers with High Defect Qty%s" , res, (char)13,(char)10, tab);

		memcpy(CALMTLGHIS.NOTIFY_MESSAGE, message, sizeof(message));

		CDB_insert_calmtlghis(&CALMTLGHIS); 

		// 결과 -> 실패로 return 할 경우 
		//		1. strcpy로 s_msg_code 에 직접 작성해도 되고, 
		//strcpy(s_msg_code, "RAS-0003");
		//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//return MP_FALSE;
		if(DB_error_code != DB_SUCCESS)
		{ 
			strcpy(s_msg_code, "ALM-0004"); 
			TRS.add_fieldmsg(out_node, "CALMTLGHIS INSERT", MP_NVST); 
			TRS.add_fieldmsg(out_node, "SEQ_NUM", MP_INT, CALMTLGHIS.SEQ_NUM); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CALMTLGHIS.FACTORY), CALMTLGHIS.FACTORY); 
			TRS.add_fieldmsg(out_node, "NOTIFY_SYSTEM", MP_STR, sizeof(CALMTLGHIS.NOTIFY_SYSTEM), CALMTLGHIS.NOTIFY_SYSTEM); 
			TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR, sizeof(CALMTLGHIS.TRAN_TIME), CALMTLGHIS.TRAN_TIME); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 

			// 20210810 MES Application Memory leak 점검 및 수정
			// malloc 제거로 주석처리
			/*
			free(line); //IS-21-01-094 MES logic 개선
			free(res);
			free(tab);
			*/
			return MP_FALSE; 
		}

		// 20210810 MES Application Memory leak 점검 및 수정
		// malloc 제거로 주석처리
		/*
		free(line);
		free(res);
		free(tab);
		*/
	}
	
	// 연속 풀인지 체크하기 위해 Buffer Count 저장해놓는다.
	DBC_init_mrasresdef(&MRASRESDEF);
	memcpy(MRASRESDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");

	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	TRS.copy(MRASRESDEF.RES_CMF_15, sizeof(MRASRESDEF.RES_CMF_15), in_node, "BUFFER_COUNT");

	DBC_update_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	//========================================================================
	// IS-21-09-089	[MC개발]1라인 전단 버퍼 신규 인터페이스 개발
	CDB_init_cedcbufdat(&CEDCBUFDAT);
    TRS.copy(CEDCBUFDAT.LINE_ID, sizeof(CEDCBUFDAT.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CEDCBUFDAT.RES_ID, sizeof(CEDCBUFDAT.RES_ID), in_node, "RES_ID");
	memcpy(CEDCBUFDAT.TYPE, "BUFF", strlen("BUFF"));     //TRS.copy(CEDCBUFDAT.TYPE, sizeof(CEDCBUFDAT.TYPE), in_node, "TYPE");
    CDB_select_cedcbufdat_for_update(1, &CEDCBUFDAT);
    if(DB_error_code == DB_SUCCESS)
    {
		TRS.copy(buffercount, sizeof(buffercount), in_node, "BUFFER_COUNT");
		CEDCBUFDAT.QTY_1 = COM_atoi(buffercount, sizeof(buffercount));
		
		TRS.copy(CEDCBUFDAT.UPDATE_USER_ID, sizeof(CEDCBUFDAT.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CEDCBUFDAT.UPDATE_TIME, s_sys_time, sizeof(CEDCBUFDAT.UPDATE_TIME));

        CDB_update_cedcbufdat(1, &CEDCBUFDAT);
        if(DB_error_code == DB_SUCCESS)
        {
			CDB_init_cedcbufhis(&CEDCBUFHIS);

			memcpy(CEDCBUFHIS.LINE_ID, CEDCBUFDAT.LINE_ID, sizeof(CEDCBUFDAT.LINE_ID));
			memcpy(CEDCBUFHIS.RES_ID , CEDCBUFDAT.RES_ID , sizeof(CEDCBUFDAT.RES_ID));
			memcpy(CEDCBUFHIS.TYPE   , CEDCBUFDAT.TYPE   , sizeof(CEDCBUFDAT.TYPE));

			CEDCBUFHIS.HIST_SEQ = CDB_select_cedcbufhis_scalar(2, &CEDCBUFHIS) + 1;

			CEDCBUFHIS.QTY_1 = CEDCBUFDAT.QTY_1;
			CEDCBUFHIS.QTY_2 = CEDCBUFDAT.QTY_2;

			TRS.copy(CEDCBUFHIS.CREATE_USER_ID, sizeof(CEDCBUFHIS.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CEDCBUFHIS.CREATE_TIME, s_sys_time, sizeof(CEDCBUFHIS.CREATE_TIME));
			CDB_insert_cedcbufhis(&CEDCBUFHIS);
			if(DB_error_code != DB_SUCCESS)
			{
			}
		}
    }

	//========================================================================

	// 결과 -> 성공으로 return 할 경우
	//		2. COM_set_result의 3번째 파라미터에 직접 입력해도 됨
	//			[MP_] 로 시작되는 사전 정의된 값들은 잘 보고 사용해야합니다. ex) MP_SUCCESS_C / MP_FAIL_C
	//			잘못 사용하면 성공인데 실패로 설비에 메시지가 내려가는 경우가 생깁니다. 

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 