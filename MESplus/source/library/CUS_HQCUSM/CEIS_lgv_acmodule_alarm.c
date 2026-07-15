/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_lgv_acmodule_alarm.c
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

int EAPMES_LGV_ACMODULE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	// CUS_HQCUSM_common.h ¼±¾ðÇØÁÖ¸é ÇÊ¿ä¾øÀ½

/*******************************************************************************
    EAPMES_BufferCount_Inquiry_RES()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_LGV_Acmodule_Alarm(TRSNode *in_node)		// CUS_HQCUSM_service.h	/ CUSHQCUSMAddService.c ¼±¾ð Ãß°¡
{	
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;
    TRSNode *out_node;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);
	out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_LGV_ACMODULE_ALARM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_LGV_Acmodule_Alarm", out_node);

	// °á°ú°¡ ¼º°øÀÏ °æ¿ì DB commit
    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
	// °á°ú°¡ ½ÇÆÐÀÏ °æ¿ì DB rollback
	else
    {
        DB_rollback();
    }
	

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    CEIS_Save_Message_Log(in_node, out_node);				// CEISMSGLOG Å×ÀÌºí¿¡ ÀÌ·Â ³²±è 
    //CEIS_Save_Message_Log_For_List(in_node, out_node);	// CEISMSGLOG Å×ÀÌºí¿¡ ÀÌ·Â ³²±è (out_node¿¡ List °¡ ÀÖÀ» °æ¿ì) ??

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_LGV_ACMODULE_ALARM()
        - Main sub function of "EAPMES_BufferCount_Inquiry_RES" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_LGV_ACMODULE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)	// CUS_HQCUSM_common.h ¼±¾ð Ãß°¡
{
	struct CALMTLGHIS_TAG CALMTLGHIS;

	char s_sys_time[14];
	char s_work_date[8];
	char message[130];

	TRSNode ** PACK_LIST;
	int pack_list_count;
	int i;

	TRSNode* tran_in_node;

	/*
	char *line = (char*)malloc(sizeof(char) * (10 + 1));
	char *grade = (char*)malloc(sizeof(char) * (10 + 1));
	char *portNo = (char*)malloc(sizeof(char) * (10 + 1));
	char *stackedQty = (char*)malloc(sizeof(char) * (10 + 1));
	*/
	// 20210810 MES Application Memory leak 점검 및 수정
	char line[10+1];
	char grade[10+1];
	char portNo[10+1];
	char stackedQty[10+1];
	memset(line, 0x00, sizeof(line));
	memset(grade, 0x00, sizeof(grade));
	memset(portNo, 0x00, sizeof(portNo));
	memset(stackedQty, 0x00, sizeof(stackedQty));

	// ¼³ºñ/OI¿¡¼­ Àü¼ÛÇÑ in_node °ª ÀüºÎ ·Î±× ÀÛ¼º
    LOG_head("EAPMES_LGV_Acmodule_Alarm");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);  


	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(s_work_date, ' ', sizeof(s_work_date));

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
        return MP_FALSE;
    }

	memcpy(s_work_date, s_sys_time, sizeof(s_work_date));

	/*
	strncpy(line, TRS.get_string(in_node, "LINE_ID") + '\0', strlen(TRS.get_string(in_node, "LINE_ID")) + 1);
	strncpy(grade, TRS.get_string(in_node, "GRADE") + '\0', strlen(TRS.get_string(in_node, "GRADE")) + 1);
	strncpy(portNo, TRS.get_string(in_node, "PORT_NO") + '\0', strlen(TRS.get_string(in_node, "PORT_NO")) + 1);
	strncpy(stackedQty, TRS.get_string(in_node, "STACKED_QTY") + '\0', strlen(TRS.get_string(in_node, "STACKED_QTY")) + 1);
	*/

	// 20210810 MES Application Memory leak 점검 및 수정
	// strncpy 에서 TRS.copy 로 수정
	_snprintf_s(line, _countof(line), _countof(line)-1, "%s", TRS.get_string(in_node, "LINE_ID"));
	_snprintf_s(grade, _countof(grade), _countof(grade)-1, "%s", TRS.get_string(in_node, "GRADE"));
	_snprintf_s(portNo, _countof(portNo), _countof(portNo)-1, "%s", TRS.get_string(in_node, "PORT_NO"));
	_snprintf_s(stackedQty, _countof(stackedQty), _countof(stackedQty)-1, "%s", TRS.get_string(in_node, "STACKED_QTY"));


	CDB_init_calmtlghis(&CALMTLGHIS);
	memcpy(CALMTLGHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));

	memcpy(CALMTLGHIS.NOTIFY_SYSTEM, "HQcell_ACMODULE_PORT", strlen("HQcell_ACMODULE_PORT"));

	memcpy(CALMTLGHIS.TRAN_TIME, s_sys_time, sizeof(CALMTLGHIS.TRAN_TIME));
	TRS.copy(CALMTLGHIS.CMF_1, sizeof(CALMTLGHIS.CMF_1), in_node, "RES_ID");
		

	//sprintf(message , "Please check the below Sorting Port in Packing area. \n-LINE : %s \n-GRADE : %s \n-PORT_NO : %s \n-STACKED_QTY : %s" , line, grade, portNo, stackedQty);
	
	// 20210810 MES Application Memory leak 점검 및 수정
	// remove memory leak (sprintf to _snprintf_s)
	_snprintf_s(message, _countof(message), _countof(message)-1, "Please check the below Sorting Port in Packing area. \n-LINE : %s \n-GRADE : %s \n-PORT_NO : %s \n-STACKED_QTY : %s" , line, grade, portNo, stackedQty);

	memcpy(CALMTLGHIS.NOTIFY_MESSAGE, message, sizeof(message));

	CDB_insert_calmtlghis(&CALMTLGHIS); 
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
		return MP_FALSE; 
	}

	// 20210810 MES Application Memory leak 점검 및 수정
	// malloc 제거로 주석처리
	/*
	free(line);
	free(grade);
	free(portNo);
	free(stackedQty);
	*/

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 