/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_sample.c
    Description : 

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Sample()
            + Setup service interface function
        - EAPMES_SAMPLE()
            + Main sub function of EAPMES_Sample function
            + Setup service main business function
    Detail Description
        - EAPMES_SAMPLE()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     yyyy/mm/dd  developer      desc 

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_SAMPLE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	// CUS_HQCUSM_common.h 선언해주면 필요없음

/*******************************************************************************
    EAPMES_Sample()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Sample(TRSNode *in_node)		// CUS_HQCUSM_service.h	/ CUSHQCUSMAddService.c 선언 추가
{	
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;
    TRSNode *out_node;

	///* 설비로 응답이 필요할 경우 추가 */
	// char s_channel[100];	

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_SAMPLE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_SAMPLE", out_node);

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
	
	///* 설비로 응답이 필요할 경우 추가 */
	///* MES to EAP */
	//memset(s_channel, 0x00, sizeof(s_channel));
	//sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	////strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	//COM_add_null(s_channel, sizeof(s_channel));
	//
	//if(CallService(MODULE_EAP, 
	//				"MESEAP_Sample",	// 응답 메시지 명
	//				out_node, 
	//				0x00, 
	//				s_channel, 
	//				gi_default_ttl, 
	//				DM_UNICAST) != MP_TRUE)
	//{
	//	// Error
	//}

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
    EAPMES_SAMPLE()
        - Main sub function of "EAPMES_Sample" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_SAMPLE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)	// CUS_HQCUSM_common.h 선언 추가
{
	// 사용할 변수 선언  

	// 설비/OI에서 전송한 in_node 값 전부 로그 작성
    LOG_head("EAPMES_SAMPLE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);  

	// 결과 -> 실패로 return 할 경우 
	//		1. strcpy로 s_msg_code 에 직접 작성해도 되고, 
	//strcpy(s_msg_code, "RAS-0003");
	//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	//return MP_FALSE;
	
	// 결과 -> 성공으로 return 할 경우
	//		2. COM_set_result의 3번째 파라미터에 직접 입력해도 됨
	//			[MP_] 로 시작되는 사전 정의된 값들은 잘 보고 사용해야합니다. ex) MP_SUCCESS_C / MP_FAIL_C
	//			잘못 사용하면 성공인데 실패로 설비에 메시지가 내려가는 경우가 생깁니다. 
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 