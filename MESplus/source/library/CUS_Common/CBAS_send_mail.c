#include "CUS_common.h"
#include "BASCore_common.h"

#include <MESCore_common.h>
#include <ACTCore_common.h>
#include <ALMCore_common.h>


int CBAS_SEND_MAIL(char *s_msg_code,
						TRSNode *in_node, 
						TRSNode *out_node);

int CUS_get_recv_alarm_user(char *s_msg_code, 
                            TRSNode *out_node,
                            char *s_factory_t, 
                            char *s_alarm_id_t, 
                            int *i_user_count, 
							char *s_mat_id,
							char *s_pgm_id,
                            struct ALARM_USER_TAG *ALARM_USER);

int Send_Mail_Action(int i_user_count, 
                         struct ALARM_USER_TAG *ALARM_USER,
                         char *s_alarm_id_t,
                         char *s_content,
						 char *s_title);

int Send_Mail_Action_Manual(char* s_alarm_user,
	char* s_alarm_id_t,
	char* s_content,
	char* s_title);

/*******************************************************************************
    CBAS_Send_Mail()
        - View Oper List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CBAS_Send_Mail(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;
//	int b_changed_multi_transaction;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CBAS_SEND_MAIL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Tran_Alarm", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CBAS_SEND_MAIL()
        - View Oper list
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CBAS_SEND_MAIL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MALMMSGDEF_TAG    MALMMSGDEF;
	struct ALARM_USER_TAG    ALARM_USER[1000];

	//struct MWIPLOTHIS_TAG MWIPLOTHIS; //no use 2023-07-04
	//struct MWIPOPRDEF_TAG MWIPOPRDEF; //no use 2023-07-04
	//struct MRASPMSSTS_TAG MRASPMSSTS; //no use 2023-07-04
	//struct MSECUSRDEF_TAG MSECUSRDEF; //no use 2023-07-04

	TRSNode ** TOOL_LIST;

	int i_user_count = 0;
	char s_tran_time[14];
	char s_title[4001];
	char s_content[500000];
	char s_tmp[4001];
	//char s_tmp_1[4001]; //no use 2023-07-04

	//int i_sel = 0; //no use 2023-07-04
	int i_count = 0;
	//int lyd_waf_cnt = 0; //no use 2023-07-04
	int i = 0;
	//int pm_res_cnt = 0; //no use 2023-07-04
	//int inform_note_cnt = 0; //no use 2023-07-04

	//char tmp_date_time[20]; //no use 2023-07-04
	//char s_from_time[14]; //no use 2023-07-04
	//char s_to_time[14]; //no use 2023-07-04
	//char s_tmp_interval[30]; //no use 2023-07-04

	LOG_head("CBAS_Send_Mail");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	LOG_head("CBAS_Send_Mail-0001");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_tran_time, ' ', sizeof(s_tran_time));
	DB_get_systime(s_tran_time);

	if(COM_isnullspace(TRS.get_string(in_node, "ALARM_ID")) == MP_TRUE)  return MP_TRUE;

	// 알람정보 조회
	DBC_init_malmmsgdef(&MALMMSGDEF);
	TRS.copy(MALMMSGDEF.FACTORY, sizeof(MALMMSGDEF.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MALMMSGDEF.ALARM_ID, sizeof(MALMMSGDEF.ALARM_ID), in_node, "ALARM_ID");

	DBC_select_malmmsgdef(1, &MALMMSGDEF);
	if(DB_error_code == DB_SUCCESS) 
	{
		if(MALMMSGDEF.ACTION_MAIL_FLAG != 'Y') return MP_TRUE;

		MALMMSGDEF.ACTION_MAIL_FLAG = ' ';  // 임시로 지움 (CORE에서 메일전송 방지)
		DBC_update_malmmsgdef(1, &MALMMSGDEF);
		if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "ALM-0004");
			TRS.add_fieldmsg(out_node, "MALMMSGDEF UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MALMMSGDEF.FACTORY), MALMMSGDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "ALARM_ID", MP_STR, sizeof(MALMMSGDEF.ALARM_ID), MALMMSGDEF.ALARM_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// After 에서 해당 Flag가 있으면 ACTION_MAIL_FLAG='Y' Update
		TRS.set_char(in_node, "RECOVER_MAIL_FLAG", 'Y');

	}
	else
	{
		return MP_TRUE;
	}
	LOG_head("CBAS_Send_Mail-0002");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// USER LIST 조회
	if(MALMMSGDEF.ALARM_TYPE != MP_ALM_NORMAL)
	{
		if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
		{
			strcpy(s_msg_code, "ALM-0001");
			TRS.add_fieldmsg(out_node, "RES_ID", MP_NVST);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	LOG_head("CBAS_Send_Mail-0003");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(MALMMSGDEF.SEND_TO_USER_FLAG == 'Y')
	{
		if(ALM_get_alarm_user(s_msg_code,
			                  out_node,
			                  MALMMSGDEF.FACTORY, 
			                  TRS.get_userid(in_node), 
			                  &i_user_count, 
			                  ALARM_USER) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	LOG_head("CBAS_Send_Mail-0004");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(COM_isnullspace(TRS.get_string(in_node, "PRV_GRP")) == MP_TRUE)
	{
		// USER MAIL OPTION적용을 위해 CUSTOMIZING FUNCTION을 적용합니다.
		if(CUS_get_recv_alarm_user(s_msg_code,
			                       out_node,
			                       MALMMSGDEF.FACTORY, 
			                       MALMMSGDEF.ALARM_ID, 
			                       &i_user_count, 
								   TRS.get_string(in_node, "MAT_ID"),
								   TRS.get_string(in_node, "PGM_ID"),
			                       ALARM_USER) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	} 
	else
	{
		if(ALM_get_alarm_user_by_prvgrp(s_msg_code,
			                            out_node,
			                            MALMMSGDEF.FACTORY,
			                            TRS.get_string(in_node, "PRV_GRP"),
			                            &i_user_count,
			                            ALARM_USER) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	
	LOG_head("CBAS_Send_Mail-0005");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(i_user_count == 0) return MP_TRUE;

	memset(s_title, 0x00, sizeof(s_title));

    if (COM_isnullspace(TRS.get_string(in_node, "CUSTOM_SUBJECT")) == MP_FALSE)
    {
        sprintf(s_title + strlen(s_title), "%s", TRS.get_string(in_node, "CUSTOM_SUBJECT"));
    }   
    else
    {
		memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
		sprintf(s_title + strlen(s_title), "%s", s_tmp); // $ALARM_DESC
    }

	LOG_head("CBAS_Send_Mail-0006");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// HTML BODY 생성
	memset(s_content, 0x00, sizeof(s_content));
	sprintf(s_content + strlen(s_content), "<html> ");
	sprintf(s_content + strlen(s_content), "<head> ");
	sprintf(s_content + strlen(s_content), "<meta content=\"text/html; charset=euc-kr\" http-equiv=Content-Type> ");
	sprintf(s_content + strlen(s_content), "<style type='text/css'> ");
	sprintf(s_content + strlen(s_content), ".tbl { border-top:1px solid #bbbbbb; } ");
	sprintf(s_content + strlen(s_content), ".tbl tr td { ");
	sprintf(s_content + strlen(s_content), "    height: 25px; ");
	sprintf(s_content + strlen(s_content), "	font-family: '굴림'; ");
	sprintf(s_content + strlen(s_content), "	font-size: 11px; ");
	sprintf(s_content + strlen(s_content), "    color: #666666; ");
	sprintf(s_content + strlen(s_content), "	text-align: center; ");
	sprintf(s_content + strlen(s_content), "	border-bottom:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	border-left:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "} ");
	sprintf(s_content + strlen(s_content), ".tbl tr th { ");
	sprintf(s_content + strlen(s_content), "    height: 25px; ");
	sprintf(s_content + strlen(s_content), "	font-family: '굴림'; ");
	sprintf(s_content + strlen(s_content), "	font-size: 11px; ");
	sprintf(s_content + strlen(s_content), "    color: red; ");
	sprintf(s_content + strlen(s_content), "	font-weight: bold; ");
	sprintf(s_content + strlen(s_content), "	text-align: center; ");
	sprintf(s_content + strlen(s_content), "	border-bottom:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	border-left:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	border-right:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	background-color: #f3f3f3; ");
	sprintf(s_content + strlen(s_content), "} ");
	sprintf(s_content + strlen(s_content), ".border_last { border-right:1px solid #bbbbbb; } ");
	sprintf(s_content + strlen(s_content), "</style> ");
	sprintf(s_content + strlen(s_content), "</head> ");
	sprintf(s_content + strlen(s_content), "<body><table class=tbl cellspacing=0 cellpadding=0> ");
	sprintf(s_content + strlen(s_content), "<tr><th width=448 colspan=2> ");

	LOG_head("CBAS_Send_Mail-0007");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_SUBJECT"), (int)strlen(TRS.get_string(in_node, "ALARM_SUBJECT")));//COM_memcpy_add_null(s_tmp, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
	sprintf(s_content + strlen(s_content), "<p align=left>%s ", s_tmp);
	sprintf(s_content + strlen(s_content), "[%s]</span></p></th></tr> ", TRS.get_string(in_node, "ALARM_ID"));

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGDEF.FACTORY, sizeof(MALMMSGDEF.FACTORY));
	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Factory</p></td><td class='border_last' width=360> ");
	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $FACTORY

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, MALMMSGDEF.ALARM_ID, sizeof(MALMMSGDEF.ALARM_ID));
	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm ID</p></td><td class='border_last' width=360> "); 
	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_ID

	//sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Type</p></td><td class='border_last' width=360> ");
	//sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%c</p></td></tr> ", MALMMSGDEF.ALARM_TYPE); // $ALARM_TYPE

	//sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Level</p></td><td class='border_last' width=360> ");
	//sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%c</p></td></tr> ", MALMMSGDEF.ALARM_LEVEL_FLAG); // $ALARM_LEVEL_FLAG

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, s_tran_time, sizeof(s_tran_time));
	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Create Time</p></td><td class='border_last' width=360> ");
	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $TRAN_TIME

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_SUBJECT"), (int)strlen(TRS.get_string(in_node, "ALARM_SUBJECT")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><b><p align=center>Alarm Subject</p></b></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<b><p align=left>&nbsp;%s</p></b></td></tr> ", s_tmp); // $ALARM_SUBJECT
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_MSG"), (int)strlen(TRS.get_string(in_node, "ALARM_MSG")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Msg</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_MSG_1
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_1"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_1")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 1</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_1
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_2"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_2")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 2</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_2
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_3"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_3")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 3</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_3
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_4"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_4")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 4</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_4
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_5"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_5")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 5</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_5
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "LOT_ID"), (int)strlen(TRS.get_string(in_node, "LOT_ID")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Lot ID</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $LOT_ID
	}
	
	LOG_head("CBAS_Send_Mail-0008");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//2019.12.13 아래 항목 의미 없어서 삭제처리함. Requested Tiger.Lee
	//
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	//memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "RES_ID"), strlen(TRS.get_string(in_node, "RES_ID")));
	//if(COM_isnullspace(s_tmp) == MP_FALSE)
	//{
	//	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Resource ID</p></td><td class='border_last' width=360> ");
	//	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $RES_ID
	//}

	//memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "SOURCE_ID_1"), strlen(TRS.get_string(in_node, "SOURCE_ID_1")));
	//if(COM_isnullspace(s_tmp) == MP_FALSE)
	//{
	//	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Source ID 1</p></td><td class='border_last' width=360> ");
	//	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $SOURCE_ID_1
	//}

	//memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "SOURCE_DESC_1"), strlen(TRS.get_string(in_node, "SOURCE_DESC_1")));
	//if(COM_isnullspace(s_tmp) == MP_FALSE)
	//{
	//	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Source Desc 1</p></td><td class='border_last' width=360> ");
	//	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $SOURCE_DESC_1
	//}

	//memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "SOURCE_ID_2"), strlen(TRS.get_string(in_node, "SOURCE_ID_2")));
	//if(COM_isnullspace(s_tmp) == MP_FALSE)
	//{
	//	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Source ID 2</p></td><td class='border_last' width=360> ");
	//	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $SOURCE_ID_2
	//}

	//memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "SOURCE_DESC_2"), strlen(TRS.get_string(in_node, "SOURCE_DESC_2")));
	//if(COM_isnullspace(s_tmp) == MP_FALSE)
	//{
	//	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Source Desc 2</p></td><td class='border_last' width=360> ");
	//	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $SOURCE_DESC_2
	//}

	//memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "SOURCE_ID_3"), strlen(TRS.get_string(in_node, "SOURCE_ID_3")));
	//if(COM_isnullspace(s_tmp) == MP_FALSE)
	//{
	//	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Source ID 3</p></td><td class='border_last' width=360> ");
	//	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $SOURCE_ID_3
	//}

	//memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "SOURCE_DESC_3"), strlen(TRS.get_string(in_node, "SOURCE_DESC_3")));
	//if(COM_isnullspace(s_tmp) == MP_FALSE)
	//{
	//	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Source Desc 3</p></td><td class='border_last' width=360> ");
	//	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $SOURCE_DESC_3
	//}
	sprintf(s_content + strlen(s_content), "</table>");

	LOG_head("CBAS_Send_Mail-0009");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if (memcmp(MALMMSGDEF.ALARM_ID, "ALM_TOOL_USE_LIMIT", strlen("ALM_TOOL_USE_LIMIT")) == 0)
	{
		
		sprintf(s_content + strlen(s_content), "&nbsp;");//공백추가
		sprintf(s_content + strlen(s_content), "<table class=tbl cellspacing=0 cellpadding=0> ");
		sprintf(s_content + strlen(s_content), "<tr><th width=840 colspan=6> ");
		sprintf(s_content + strlen(s_content), "<p align=left>%s ", s_tmp); // $ALARM_DESC
		sprintf(s_content + strlen(s_content), "[%s]</span></p></th></tr> ", " CHECK TOOL LIST");

		//Header
		sprintf(s_content + strlen(s_content), "<tr><td width=100 bgcolor=\"#D4F4FA\"><p align=center><b>Work Shop</p></td>");
		sprintf(s_content + strlen(s_content), "    <td width=100 bgcolor=\"#D4F4FA\"><p align=center><b>EQ</p></td>");
		sprintf(s_content + strlen(s_content), "    <td width=100 bgcolor=\"#D4F4FA\"><p align=center><b>EQ NAME</p></td>");
		sprintf(s_content + strlen(s_content), "    <td width=100 bgcolor=\"#D4F4FA\"><p align=center><b>EQ GROUP</p></td>");
		sprintf(s_content + strlen(s_content), "    <td width=300 bgcolor=\"#D4F4FA\"><p align=center><b>PART NAME</p></td>");
		sprintf(s_content + strlen(s_content), "    <td width=100 bgcolor=\"#D4F4FA\"><p align=center><b>CHANGE CNT</p></td>");
		sprintf(s_content + strlen(s_content), "    <td width=120 bgcolor=\"#D4F4FA\"><p align=center><b>CURR USE CNT</p></td>");		
		sprintf(s_content + strlen(s_content), "	<td class='border_last' width=120 bgcolor=\"#D4F4FA\"><p align=center><b>LIMIT USE CNT</p></td></tr>");
		
		TOOL_LIST = TRS.get_list(in_node, "TOOL_LIST");
		i_count = TRS.get_item_count(in_node, "TOOL_LIST");

		LOG_head("CBAS_Send_Mail-0010");
		COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

		for(i = 0; i < i_count; i++)
		{
			//Work Shop
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "LINE_ID"), (int)strlen(TRS.get_string(TOOL_LIST[i], "LINE_ID")));
			sprintf(s_content + strlen(s_content), "<tr><td width=100><p align=left>&nbsp;%s</p></td>", s_tmp);

			//EQ
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "RES_ID"), (int)strlen(TRS.get_string(TOOL_LIST[i], "RES_ID")));
			sprintf(s_content + strlen(s_content), "    <td width=100><p align=left>&nbsp;%s</p></td>", s_tmp);

			//EQ NAME
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "RES_DESC"), (int)strlen(TRS.get_string(TOOL_LIST[i], "RES_DESC")));
			sprintf(s_content + strlen(s_content), "    <td width=100><p align=left>&nbsp;%s</p></td>", s_tmp);

			//EQ GROUP
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "RES_GROUP"), (int)strlen(TRS.get_string(TOOL_LIST[i], "RES_GROUP")));
			sprintf(s_content + strlen(s_content), "    <td width=100><p align=left>&nbsp;%s</p></td>", s_tmp);

			//PART_NAME
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "PART_NAME"), (int)strlen(TRS.get_string(TOOL_LIST[i], "PART_NAME")));
			sprintf(s_content + strlen(s_content), "	<td width=300><p align=left>&nbsp;%s</p></td>", s_tmp);

			//CHANGE_CNT
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "CHANGE_CNT"), (int)strlen(TRS.get_string(TOOL_LIST[i], "CHANGE_CNT")));
			sprintf(s_content + strlen(s_content), "	<td width=100><p align=right>&nbsp;%s</p></td>", s_tmp);
			
			//CURR_USE_CNT
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "CURR_USE_CNT"), (int)strlen(TRS.get_string(TOOL_LIST[i], "CURR_USE_CNT")));
			sprintf(s_content + strlen(s_content), "	<td width=120><p align=right>%s&nbsp;</p></td>", s_tmp);

			//LIMIT_USE_CNT
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(TOOL_LIST[i], "LIMIT_USE_CNT"), (int)strlen(TRS.get_string(TOOL_LIST[i], "LIMIT_USE_CNT")));
			sprintf(s_content + strlen(s_content), "	<td class='border_last' width=120><p align=right>%s&nbsp;</p></td></tr>", s_tmp);
		}
		sprintf(s_content + strlen(s_content), "</table>");
	}

	sprintf(s_content + strlen(s_content), "</body> ");
	sprintf(s_content + strlen(s_content), "</html> ");

	LOG_head("CBAS_Send_Mail-0011");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


	if(Send_Mail_Action(i_user_count,
								ALARM_USER,
								TRS.get_string(in_node, "ALARM_ID"),
								s_content,
								s_title) == MP_FALSE)
	{
		return MP_FALSE;
	}

	return MP_TRUE;
}

#define ALARM_MAIL_SEND_PROGRAM     ( "MpSendMail.exe" )
#define ALARM_HEADER_TITLE          ( "Alarm Mail" )
#define ALARM_FROM_TAG              ( "<FR>" )
#define ALARM_FROM_END_TAG          ( "</FR>" )
#define ALARM_TO_TAG                ( "<TO>" )
#define ALARM_TO_END_TAG            ( "</TO>" )
#define ALARM_HEADER_TAG            ( "<HD>" )
#define ALARM_HEADER_END_TAG        ( "</HD>" )
#define ALARM_BODY_TAG              ( "<BD>" )
#define ALARM_BODY_END_TAG          ( "</BD>" )

int Send_Mail_Action(int i_user_count, 
                         struct ALARM_USER_TAG *ALARM_USER,
                         char *s_alarm_id_t,
                         char *s_content,
						 char *s_title)
{
    char s_tran_time[17];
    char s_filename[256];
    // Max User * 40
    char s_tmp[40000];
    char s_email[51];
    char s_alarm_id[21];
    char s_command[512];

    int i;
    int i_ret;
    FILE *fp;

	LOG_head("CBAS_Send_Mail-0012");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(i_user_count <= 0)
    {
        return MP_TRUE;
    }

	/* Added by YJJung 초기화 추가, Title 에 쓰레기 값 들어가는 것 없앰 */
	memset(s_alarm_id, 0x00, sizeof(s_alarm_id));
	/* Added End */
	if(strlen(s_alarm_id_t) >= sizeof(s_alarm_id) - 1 )
	{
		COM_memcpy(s_alarm_id, s_alarm_id_t, sizeof(s_alarm_id) - 1);
	}
	else
	{
		COM_memcpy(s_alarm_id, s_alarm_id_t, (int)strlen(s_alarm_id_t));
	}
	COM_add_null(s_alarm_id, sizeof(s_alarm_id) - 1);

	LOG_head("CBAS_Send_Mail-0013");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /*
    ** Mailing List Filename
    ** Contents Dir + Server Name + Sub No + DateTime +"MAILLIST.dat"
    ** ex) %ContentsDir\MESServer_01_20090727113218_MAILLIST.dat
    */

    // Get current date-time
    memset(s_tran_time, 0x00, sizeof(s_tran_time));
    COM_get_date_time_msec(s_tran_time);

    sprintf( s_filename, "%s%s_%.*s_%.*s_MAILLIST.dat", 
                         gs_mail_contents_dir,
                         gs_server_name,
                         MP_SIZE_SUBNO, gs_subno,
                         sizeof(s_tran_time), s_tran_time );

    fp = fopen( s_filename, "w" );
    if( fp == 0x00 )
    {
        LOG_head("ALM_Send_Mail_Action - Can't make file");
        LOG_add("FILE_NAME", MP_NSTR, s_filename);
        COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        return MP_FALSE;
    }

	LOG_head("CBAS_Send_Mail-0014");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    // Make contents
    /* file format
    ** <FR>Alarm@Server</FR>
    ** <TO>to@miracom.co.kr</TO> OR ** <TO>to1@miracom.co.kr; to2@miracom.co.kr; to3@miracom.co.kr</TO>
    ** <HD>Mailing Test</HD>
    ** <BD>
    ** This is test for alarm mailing service.
    ** </BD>
    */

    // From
#if defined(_SUSE)
    fprintf( fp, "From: %s\n", gs_mail_from_id);
#elif defined (_NO_TAG)
    fprintf( fp, "From: %s\n", gs_mail_from_id);
#else
    fprintf( fp, "%s%s%s\n", ALARM_FROM_TAG, gs_mail_from_id, ALARM_FROM_END_TAG );
#endif

    // To
    memset( s_tmp, 0x00, sizeof(s_tmp) );
    for( i = 0; i < i_user_count; i++ )
    {
        if(COM_isspace(ALARM_USER[i].email_id, sizeof(ALARM_USER[i].email_id)) == MP_FALSE)
        {
            memset(s_email, 0x00, sizeof(s_email));
            memcpy(s_email, ALARM_USER[i].email_id, sizeof(ALARM_USER[i].email_id));
            COM_add_null(s_email, sizeof(s_email) - 1);

            if( i >= i_user_count - 1 )
            {
                sprintf(s_tmp + strlen(s_tmp), "%s", s_email);
            }
            else
            {
                sprintf(s_tmp + strlen(s_tmp), "%s;", s_email);
            }
        }
    }

	LOG_head("CBAS_Send_Mail-0015");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

#if defined(_SUSE)
    fprintf( fp, "To: %s\n", s_tmp);
#elif defined (_NO_TAG)
    fprintf( fp, "To: %s\n", s_tmp);
#else
    fprintf( fp, "%s%s%s\n", ALARM_TO_TAG, s_tmp, ALARM_TO_END_TAG );
#endif


    // Title
    memset( s_tmp, 0x00, sizeof(s_tmp) );
	if (COM_isnullspace(s_title) == MP_TRUE)
		sprintf( s_tmp, "%s [%s]", ALARM_HEADER_TITLE, s_alarm_id );
	else
		sprintf( s_tmp, "%s", s_title);
	
#if defined(_SUSE)
    fprintf( fp, "Subject: %s\n\n", s_tmp);
#elif defined (_NO_TAG)
    fprintf( fp, "Subject: %s\n\n", s_tmp);
#else
    fprintf( fp, "%s%s%s\n", ALARM_HEADER_TAG, s_tmp, ALARM_HEADER_END_TAG );
#endif


    // Body
    if(s_content[strlen(s_content) - 1] == '\n')
    {
        s_content[strlen(s_content) - 1] = 0x00;
    }

#if defined(_SUSE)
    fprintf( fp, "%s\n", s_content );
	fprintf( fp, "\n%s\n", "This mail is outgoing only. Don't reply this mail.");
#elif defined (_NO_TAG)
    fprintf( fp, "%s\n", s_content );
	fprintf( fp, "\n%s\n", "This mail is outgoing only. Don't reply this mail.");
#else
    fprintf( fp, "%s\n", ALARM_BODY_TAG );
    fprintf( fp, "%s\n", s_content );
    fprintf( fp, "%s\n", ALARM_BODY_END_TAG );
#endif

    // file close
    fclose( fp );
    fp = 0x00;

	LOG_head("CBAS_Send_Mail-0016");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

#if defined(WIN32) || defined(WIN64)

    sprintf( s_command, "%s%s %s", gs_bin_dir, ALARM_MAIL_SEND_PROGRAM, s_filename );

    i_ret = WinExec(s_command, SW_HIDE);

    // Write Log 
    LOG_head("ALM_Mail_Action");
    LOG_add("cmd", MP_NSTR, s_command);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

#elif defined(_HPUX_SOURCE) || defined(__digital__) || defined(_AIX) || defined(_SUSE)

    for( i = 0; i < i_user_count; i++ )
    {
        memset(s_email, 0x00, sizeof(s_email));
        memcpy(s_email, ALARM_USER[i].email_id, sizeof(ALARM_USER[i].email_id));
        COM_add_null(s_email, sizeof(s_email) - 1);

#if defined(_SUSE)
        if(COM_isnullspace(gs_mail_user_name) == MP_TRUE || COM_isnullspace(gs_mail_user_pass) == MP_TRUE)
        {
            sprintf( s_command, "ssmtp %s < \"%s\"", 
                                 s_email, 
                                 s_filename );
        }
        else
        {
            sprintf( s_command, "ssmtp %s -au %s -ap %s < \"%s\"", 
                                 s_email, 
                                 gs_mail_user_name,
                                 gs_mail_user_pass,
                                 s_filename );
        }

#elif defined (_NO_TAG)
        sprintf( s_command, "mailx -r %s -s '%s [%s]' %s < %s",
                             gs_mail_from_id,
                             ALARM_HEADER_TITLE,
                             s_alarm_id,
                             s_email, 
                             s_filename );
#else
        sprintf( s_command, "mailx -s '%s [%s]' %s < %s",
                             ALARM_HEADER_TITLE,
                             s_alarm_id,
                             s_email, 
                             s_filename );
#endif

	LOG_head("CBAS_Send_Mail-0017");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

        i_ret = system( s_command );

        // Write Log 
        LOG_head("ALM_Send_Mail_Action");
        LOG_add("cmd", MP_NSTR, s_command);
        LOG_add("i_ret", MP_INT, i_ret);
        COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

        if(i_ret != 0)
        {
            LOG_head("ALM_Send_Mail_Action - Fail to send mail");
            LOG_add("cmd", MP_NSTR, s_command);
            LOG_add("i_ret", MP_INT, i_ret);
            COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

            if(fp == 0x00)
            {
                memset( s_tmp, 0x00, sizeof(s_tmp) );
                sprintf( s_tmp, "%s.FAIL", s_filename );

                fp = fopen( s_tmp, "w" );
                if( fp == NULL )
                {
                    LOG_head("ALM_Send_Mail_Action - Can't make file to write fail information");
                    LOG_add("FILE_NAME", MP_NSTR, s_tmp);
                    COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
                    return MP_FALSE;
                }

                fprintf( fp, "FAIL TO SEND MAIL.\n" );
                fprintf( fp, "==============================\n" );
                fprintf( fp, "Date    : %.*s\n", sizeof(s_tran_time), s_tran_time );
                fprintf( fp, "File    : %s\n\n", s_filename );
            }
            fprintf( fp, "Mail ID : %s     Return Value : %d\n", s_email, i_ret );
        }
    }
	LOG_head("CBAS_Send_Mail-0018");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(fp != 0x00)
    {
        fclose( fp );
    }

    if(gc_mail_file_copy_flag == 'Y')
    {
        sprintf( s_command, "cp %s %s", s_filename,
                                        gs_mail_contents_back_dir);
        system( s_command );
    }

    if(gc_mail_file_del_flag == 'Y')
    {
        remove( s_filename );
    }

#endif
	LOG_head("CBAS_Send_Mail-0019E");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    return MP_TRUE;
}



int CUS_get_recv_alarm_user(char *s_msg_code, 
                            TRSNode *out_node,
                            char *s_factory_t, 
                            char *s_alarm_id_t, 
                            int *i_user_count, 
							char *s_mat_id,
							char *s_pgm_id,
                            struct ALARM_USER_TAG *ALARM_USER)
{
    struct MALMRCVDEF_TAG MALMRCVDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    char s_curr_time[14];
    int i_curr_shift;

    char s_factory[sizeof(MALMRCVDEF.FACTORY)];
    char s_alarm_id[sizeof(MALMRCVDEF.ALARM_ID)];

    COM_memcpy(s_factory, s_factory_t, sizeof(s_factory));
    COM_memcpy(s_alarm_id, s_alarm_id_t, sizeof(s_alarm_id));

    memset(s_curr_time, ' ', sizeof(s_curr_time));
    DB_get_systime(s_curr_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "ALM-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    i_curr_shift = 0;
    //if(ALM_get_shift_by_time(s_msg_code,
    //                         out_node,
    //                         s_factory,
    //                         s_curr_time,
    //                         &i_curr_shift) == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    DBC_init_malmrcvdef(&MALMRCVDEF);
    memcpy(MALMRCVDEF.FACTORY, s_factory, sizeof(MALMRCVDEF.FACTORY));
    memcpy(MALMRCVDEF.ALARM_ID, s_alarm_id, sizeof(MALMRCVDEF.ALARM_ID));
    DBC_open_malmrcvdef(1, &MALMRCVDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "SEC-0004");
        TRS.add_fieldmsg(out_node, "MALMRCVDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MALMRCVDEF.FACTORY), MALMRCVDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "ALARM_ID", MP_STR, sizeof(MALMRCVDEF.ALARM_ID), MALMRCVDEF.ALARM_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;              
    }

    while(1)
    {
        DBC_fetch_malmrcvdef(1, &MALMRCVDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_malmrcvdef(1);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "SEC-0004");
            TRS.add_fieldmsg(out_node, "MALMRCVDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MALMRCVDEF.FACTORY), MALMRCVDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "ALARM_ID", MP_STR, sizeof(MALMRCVDEF.ALARM_ID), MALMRCVDEF.ALARM_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_COMMON;

            DBC_close_malmrcvdef(1);
            return MP_FALSE;              
        }

        /* 현재 시간에 근무조가 있고, 특정 근무조에만 알람을 받겠다고 했으면, 해당 근무조에 설정되어 있는지 확인, 설정이 없으면 다음으로 진행 */
        if(i_curr_shift > 0)
            if(memcmp(MALMRCVDEF.RCV_SHIFT, "____", 4) != 0)
                if(MALMRCVDEF.RCV_SHIFT[i_curr_shift - 1] == '_')
                    continue;

        // User
        if(MALMRCVDEF.REL_LEVEL == 'U')
        {
			DBC_init_mgcmtbldat(&MGCMTBLDAT);
			memcpy(MGCMTBLDAT.FACTORY, s_factory, sizeof(MGCMTBLDAT.FACTORY));
			memcpy(MGCMTBLDAT.TABLE_NAME, "A_USER_MAIL_OPTION", strlen("A_USER_MAIL_OPTION"));
			memcpy(MGCMTBLDAT.KEY_1, MALMRCVDEF.RCVR_ID, sizeof(MALMRCVDEF.RCVR_ID));
			memcpy(MGCMTBLDAT.KEY_2, "ALL", strlen("ALL"));
			DBC_select_mgcmtbldat(1, &MGCMTBLDAT );
			if(DB_error_code == DB_SUCCESS)
			{
				if (COM_isspace(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2)) == MP_FALSE)
				{
					if(ALM_get_alarm_user(s_msg_code,
									  out_node,
									  MALMRCVDEF.FACTORY,
									  MGCMTBLDAT.DATA_2,
									  i_user_count,
									  ALARM_USER) == MP_FALSE)
					{
						//DO NOTHING
					}
				}

				if (COM_isspace(MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3)) == MP_FALSE)
				{
					if(ALM_get_alarm_user(s_msg_code,
									  out_node,
									  MALMRCVDEF.FACTORY,
									  MGCMTBLDAT.DATA_3,
									  i_user_count,
									  ALARM_USER) == MP_FALSE)
					{
						//DO NOTHING
					}
				}

				if (COM_isspace(MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4)) == MP_FALSE)
				{
					if(ALM_get_alarm_user(s_msg_code,
									  out_node,
									  MALMRCVDEF.FACTORY,
									  MGCMTBLDAT.DATA_4,
									  i_user_count,
									  ALARM_USER) == MP_FALSE)
					{
						//DO NOTHING
					}
				}
			}
			else //ALL에 대한 설정이 없을경우에만 해당 ALARM으로 검색
			{
				DBC_init_mgcmtbldat(&MGCMTBLDAT);
				memcpy(MGCMTBLDAT.FACTORY, s_factory, sizeof(MGCMTBLDAT.FACTORY));
				memcpy(MGCMTBLDAT.TABLE_NAME, "A_USER_MAIL_OPTION", strlen("A_USER_MAIL_OPTION"));
				memcpy(MGCMTBLDAT.KEY_1, MALMRCVDEF.RCVR_ID, sizeof(MALMRCVDEF.RCVR_ID));
				memcpy(MGCMTBLDAT.KEY_2, s_alarm_id, sizeof(s_alarm_id));
				DBC_select_mgcmtbldat(1, &MGCMTBLDAT );
				if(DB_error_code == DB_SUCCESS)
				{
					if (COM_isspace(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2)) == MP_FALSE)
					{
						if(ALM_get_alarm_user(s_msg_code,
										  out_node,
										  MALMRCVDEF.FACTORY,
										  MGCMTBLDAT.DATA_2,
										  i_user_count,
										  ALARM_USER) == MP_FALSE)
						{
							//DO NOTHING
						}
					}

					if (COM_isspace(MGCMTBLDAT.DATA_3, sizeof(MGCMTBLDAT.DATA_3)) == MP_FALSE)
					{
						if(ALM_get_alarm_user(s_msg_code,
										  out_node,
										  MALMRCVDEF.FACTORY,
										  MGCMTBLDAT.DATA_3,
										  i_user_count,
										  ALARM_USER) == MP_FALSE)
						{
							//DO NOTHING
						}
					}

					if (COM_isspace(MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4)) == MP_FALSE)
					{
						if(ALM_get_alarm_user(s_msg_code,
										  out_node,
										  MALMRCVDEF.FACTORY,
										  MGCMTBLDAT.DATA_4,
										  i_user_count,
										  ALARM_USER) == MP_FALSE)
						{
							//DO NOTHING
						}
					}
				}
			}


			//// 2016.03.07 추가 
			//// DEVICE 정보가 있고 ENGR 가 알람 수신정보에 셋업되어 있는 경우
			//// 해당 Device 의 개발 Device 담당자와 양산 Device 담당자를 수신자로 추가			
			//if(COM_isnullspace(s_mat_id) == MP_FALSE && memcmp(MALMRCVDEF.RCVR_ID, "ENGR", strlen("ENGR")) == 0)			
			//{
			//	DBU_init_cismprjsts(&CISMPRJSTS);
			//	memcpy(CISMPRJSTS.FACTORY, s_factory, sizeof(CISMPRJSTS.FACTORY));
			//	memcpy(CISMPRJSTS.DEVICE_ID, s_mat_id, sizeof(CISMPRJSTS.DEVICE_ID));
			//	
			//	DBU_select_cismprjsts(4, &CISMPRJSTS);
			//	if(DB_error_code == DB_SUCCESS)
			//	{
			//		// 개발 Device 담당자
			//		if (COM_isspace(CISMPRJSTS.PROD_USER_ID, sizeof(CISMPRJSTS.PROD_USER_ID)) == MP_FALSE)
			//		{
			//			if(ALM_get_alarm_user(s_msg_code,
			//							  out_node,
			//							  MALMRCVDEF.FACTORY,
			//							  CISMPRJSTS.PROD_USER_ID,
			//							  i_user_count,
			//							  ALARM_USER) == MP_FALSE)
			//			{
			//				//DO NOTHING
			//			}
			//		}

			//		// 양산 Device 담당자
			//		if (COM_isspace(CISMPRJSTS.DEV_USER_ID, sizeof(CISMPRJSTS.DEV_USER_ID)) == MP_FALSE)
			//		{
			//			if(ALM_get_alarm_user(s_msg_code,
			//							  out_node,
			//							  MALMRCVDEF.FACTORY,
			//							  CISMPRJSTS.DEV_USER_ID,
			//							  i_user_count,
			//							  ALARM_USER) == MP_FALSE)
			//			{
			//				//DO NOTHING
			//			}
			//		}

			//		// 개발, 양산 Device 담당자가 없는 경우 ENGR 로 전송
			//		if (COM_isspace(CISMPRJSTS.PROD_USER_ID, sizeof(CISMPRJSTS.PROD_USER_ID)) == MP_TRUE &&
			//			COM_isspace(CISMPRJSTS.DEV_USER_ID, sizeof(CISMPRJSTS.DEV_USER_ID)) == MP_TRUE)
			//		{
			//			if(ALM_get_alarm_user(s_msg_code,
			//							  out_node,
			//							  MALMRCVDEF.FACTORY,
			//							  MALMRCVDEF.RCVR_ID,
			//							  i_user_count,
			//							  ALARM_USER) == MP_FALSE)
			//			{
			//				//DO NOTHING
			//			}
			//		}
			//	}
			//}
			// 2016.03.26 추가 
			// PGM_ID 정보가 있고 ENGR 가 알람 수신정보에 셋업되어 있는 경우
			// 해당 PGM 의 담당자를 수신자로 추가			
			//else if(COM_isnullspace(s_pgm_id) == MP_FALSE && memcmp(MALMRCVDEF.RCVR_ID, "PGM_ENGR", strlen("PGM_ENGR")) == 0)			
			//{
			//	DBU_init_cwippgmdef(&CWIPPGMDEF);
			//	memcpy(CWIPPGMDEF.FACTORY, s_factory, sizeof(CWIPPGMDEF.FACTORY));
			//	memcpy(CWIPPGMDEF.PGM_ID, s_pgm_id, sizeof(CWIPPGMDEF.PGM_ID));

			//	DBU_select_cwippgmdef(1, &CWIPPGMDEF);				
			//	if(DB_error_code == DB_SUCCESS) 
			//	{
			//		// PGM 담당자
			//		if (COM_isspace(CWIPPGMDEF.CMF_3, sizeof(CWIPPGMDEF.CMF_3)) == MP_FALSE)
			//		{
			//			if(ALM_get_alarm_user(s_msg_code,
			//							  out_node,
			//							  MALMRCVDEF.FACTORY,
			//							  CWIPPGMDEF.CMF_3,
			//							  i_user_count,
			//							  ALARM_USER) == MP_FALSE)
			//			{
			//				//DO NOTHING
			//			}
			//		}
			//		else
			//		{
			//			if(ALM_get_alarm_user(s_msg_code,
			//							  out_node,
			//							  MALMRCVDEF.FACTORY,
			//							  MALMRCVDEF.RCVR_ID,
			//							  i_user_count,
			//							  ALARM_USER) == MP_FALSE)
			//			{
			//				//DO NOTHING
			//			}
			//		}
			//	}
			//}
			//else
			{
				if (MGCMTBLDAT.DATA_1[0] != 'N')
				{
					if(ALM_get_alarm_user(s_msg_code,
										  out_node,
										  MALMRCVDEF.FACTORY,
										  MALMRCVDEF.RCVR_ID,
										  i_user_count,
										  ALARM_USER) == MP_FALSE)
					{
						DBC_close_malmrcvdef(1);
						return MP_FALSE;
					}
				}
			}
        }

        // Security Group
        else if(MALMRCVDEF.REL_LEVEL == 'S')
        {
            //if(ALM_get_alarm_user_by_secgrp(s_msg_code,
            //                                out_node,
            //                                MALMRCVDEF.FACTORY,
            //                                MALMRCVDEF.RCVR_ID,
            //                                i_user_count,
            //                                ALARM_USER) == MP_FALSE)
            //{
            //    DBC_close_malmrcvdef(1);
            //    return MP_FALSE;
            //}
        }

        // Privilege Group
        else if(MALMRCVDEF.REL_LEVEL == 'P')
        {
            if(ALM_get_alarm_user_by_prvgrp(s_msg_code,
                                            out_node,
                                            MALMRCVDEF.FACTORY,
                                            MALMRCVDEF.RCVR_ID,
                                            i_user_count,
                                            ALARM_USER) == MP_FALSE)
            {
                DBC_close_malmrcvdef(1);
                return MP_FALSE;
            }
        }
    }

    return MP_TRUE;
}

/*******************************************************************************
    CBAS_SEND_MAIL_MANUAL()
        - View Oper list
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CBAS_SEND_MAIL_MANUAL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	char s_tran_time[14];
	char s_title[4001];
	char s_content[500000];
	char s_tmp[4001];

	//int i_count = 0;

	//int i = 0;

	LOG_head("CBAS_Send_Mail_Manual");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	//LOG_head("CBAS_Send_Mail_Menual-0001");
 //   COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_tran_time, ' ', sizeof(s_tran_time));
	DB_get_systime(s_tran_time);
	

	if(COM_isnullspace(TRS.get_string(in_node, "ALARM_ID")) == MP_TRUE)  return MP_TRUE;

	memset(s_title, 0x00, sizeof(s_title));
	sprintf(s_title + strlen(s_title), "%s", TRS.get_string(in_node, "CUSTOM_SUBJECT"));


	LOG_head("CBAS_Send_Mail-0001");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// HTML BODY 생성
	memset(s_content, 0x00, sizeof(s_content));
	sprintf(s_content + strlen(s_content), "<html> ");
	sprintf(s_content + strlen(s_content), "<head> ");
	sprintf(s_content + strlen(s_content), "<meta content=\"text/html; charset=euc-kr\" http-equiv=Content-Type> ");
	sprintf(s_content + strlen(s_content), "<style type='text/css'> ");
	sprintf(s_content + strlen(s_content), ".tbl { border-top:1px solid #bbbbbb; } ");
	sprintf(s_content + strlen(s_content), ".tbl tr td { ");
	sprintf(s_content + strlen(s_content), "    height: 25px; ");
	sprintf(s_content + strlen(s_content), "	font-family: '굴림'; ");
	sprintf(s_content + strlen(s_content), "	font-size: 11px; ");
	sprintf(s_content + strlen(s_content), "    color: #666666; ");
	sprintf(s_content + strlen(s_content), "	text-align: center; ");
	sprintf(s_content + strlen(s_content), "	border-bottom:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	border-left:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "} ");
	sprintf(s_content + strlen(s_content), ".tbl tr th { ");
	sprintf(s_content + strlen(s_content), "    height: 25px; ");
	sprintf(s_content + strlen(s_content), "	font-family: '굴림'; ");
	sprintf(s_content + strlen(s_content), "	font-size: 11px; ");
	sprintf(s_content + strlen(s_content), "    color: red; ");
	sprintf(s_content + strlen(s_content), "	font-weight: bold; ");
	sprintf(s_content + strlen(s_content), "	text-align: center; ");
	sprintf(s_content + strlen(s_content), "	border-bottom:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	border-left:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	border-right:1px solid #bbbbbb; ");
	sprintf(s_content + strlen(s_content), "	background-color: #f3f3f3; ");
	sprintf(s_content + strlen(s_content), "} ");
	sprintf(s_content + strlen(s_content), ".border_last { border-right:1px solid #bbbbbb; } ");
	sprintf(s_content + strlen(s_content), "</style> ");
	sprintf(s_content + strlen(s_content), "</head> ");
	sprintf(s_content + strlen(s_content), "<body><table class=tbl cellspacing=0 cellpadding=0> ");
	sprintf(s_content + strlen(s_content), "<tr><th width=448 colspan=2> ");

	LOG_head("CBAS_Send_Mail-0007");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_SUBJECT"), (int)strlen(TRS.get_string(in_node, "ALARM_SUBJECT")));//COM_memcpy_add_null(s_tmp, MALMMSGDEF.ALARM_DESC, sizeof(MALMMSGDEF.ALARM_DESC));
	sprintf(s_content + strlen(s_content), "<p align=left>%s ", s_tmp);
	sprintf(s_content + strlen(s_content), "[%s]</span></p></th></tr> ", TRS.get_string(in_node, "ALARM_ID"));

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, IN_FACTORY), (int)strlen(TRS.get_string(in_node, IN_FACTORY))); // MALMMSGDEF.FACTORY, sizeof(MALMMSGDEF.FACTORY));
	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Factory</p></td><td class='border_last' width=360> ");
	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $FACTORY

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_ID"), (int)strlen(TRS.get_string(in_node, "ALARM_ID"))); //MALMMSGDEF.ALARM_ID, sizeof(MALMMSGDEF.ALARM_ID));
	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm ID</p></td><td class='border_last' width=360> "); 
	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_ID

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, s_tran_time, sizeof(s_tran_time));
	sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Create Time</p></td><td class='border_last' width=360> ");
	sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $TRAN_TIME

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_SUBJECT"), (int)strlen(TRS.get_string(in_node, "ALARM_SUBJECT")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><b><p align=center>Alarm Subject</p></b></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<b><p align=left>&nbsp;%s</p></b></td></tr> ", s_tmp); // $ALARM_SUBJECT
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_MSG"), (int)strlen(TRS.get_string(in_node, "ALARM_MSG")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Msg</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_MSG_1
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_1"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_1")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 1</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_1
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_2"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_2")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 2</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_2
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_3"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_3")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 3</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_3
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_4"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_4")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 4</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_4
	}

	memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, TRS.get_string(in_node, "ALARM_COMMENT_5"), (int)strlen(TRS.get_string(in_node, "ALARM_COMMENT_5")));
	if(COM_isnullspace(s_tmp) == MP_FALSE)
	{
		sprintf(s_content + strlen(s_content), "<tr><td width=88><p align=center>Alarm Comment 5</p></td><td class='border_last' width=360> ");
		sprintf(s_content + strlen(s_content), "<p align=left>&nbsp;%s</p></td></tr> ", s_tmp); // $ALARM_COMMENT_5
	}

	LOG_head("CBAS_Send_Mail-0008");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	sprintf(s_content + strlen(s_content), "</table>");

	LOG_head("CBAS_Send_Mail-0009");
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	sprintf(s_content + strlen(s_content), "</body> ");
	sprintf(s_content + strlen(s_content), "</html> ");

	LOG_head("CBAS_Send_Mail-0011");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


	if(Send_Mail_Action_Manual(TRS.get_string(in_node, "ALARM_USER"),
								TRS.get_string(in_node, "ALARM_ID"),
								s_content,
								s_title) == MP_FALSE)
	{
		return MP_FALSE;
	}

	//if (COM_isnullspace(TRS.get_string(in_node, "ALARM_USER")) == MP_FALSE)
	//{
	//	
	//}

	return MP_TRUE;
}

int Send_Mail_Action_Manual(char *s_alarm_user,
                         char *s_alarm_id_t,
                         char *s_content,
						 char *s_title)
{
    char s_tran_time[17];
    char s_filename[256];
    // Max User * 40
    char s_tmp[40000];
    char s_email[2001];
    char s_alarm_id[21];
    char s_command[512];

    int i_ret;
    FILE *fp;

	LOG_head("CBAS_Send_Mail-0012");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	/* Added by YJJung 초기화 추가, Title 에 쓰레기 값 들어가는 것 없앰 */
	memset(s_alarm_id, 0x00, sizeof(s_alarm_id));
	/* Added End */
	if(strlen(s_alarm_id_t) >= sizeof(s_alarm_id) - 1 )
	{
		COM_memcpy(s_alarm_id, s_alarm_id_t, sizeof(s_alarm_id) - 1);
	}
	else
	{
		COM_memcpy(s_alarm_id, s_alarm_id_t, (int)strlen(s_alarm_id_t));
	}
	COM_add_null(s_alarm_id, sizeof(s_alarm_id) - 1);

	LOG_head("CBAS_Send_Mail-0013");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /*
    ** Mailing List Filename
    ** Contents Dir + Server Name + Sub No + DateTime +"MAILLIST.dat"
    ** ex) %ContentsDir\MESServer_01_20090727113218_MAILLIST.dat
    */

    // Get current date-time
    memset(s_tran_time, 0x00, sizeof(s_tran_time));
    COM_get_date_time_msec(s_tran_time);

    sprintf( s_filename, "%s%s_%.*s_%.*s_MAILLIST.dat", 
                         gs_mail_contents_dir,
                         gs_server_name,
                         MP_SIZE_SUBNO, gs_subno,
                         sizeof(s_tran_time), s_tran_time );

    fp = fopen( s_filename, "w" );
    if( fp == 0x00 )
    {
        LOG_head("ALM_Send_Mail_Action - Can't make file");
        LOG_add("FILE_NAME", MP_NSTR, s_filename);
        COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        return MP_FALSE;
    }

	LOG_head("CBAS_Send_Mail-0014");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    // Make contents
    /* file format
    ** <FR>Alarm@Server</FR>
    ** <TO>to@miracom.co.kr</TO> OR ** <TO>to1@miracom.co.kr; to2@miracom.co.kr; to3@miracom.co.kr</TO>
    ** <HD>Mailing Test</HD>
    ** <BD>
    ** This is test for alarm mailing service.
    ** </BD>
    */

    // From
#if defined(_SUSE)
    fprintf( fp, "From: %s\n", gs_mail_from_id);
#elif defined (_NO_TAG)
    fprintf( fp, "From: %s\n", gs_mail_from_id);
#else
    fprintf( fp, "%s%s%s\n", ALARM_FROM_TAG, gs_mail_from_id, ALARM_FROM_END_TAG );
#endif

    // To
    memset( s_tmp, 0x00, sizeof(s_tmp) );
    if(COM_isnullspace(s_alarm_user) == MP_FALSE)
    {
        memset(s_email, 0x00, sizeof(s_email));
        memcpy(s_email, s_alarm_user, sizeof(s_email));
        COM_add_null(s_email, sizeof(s_email) - 1);

        sprintf(s_tmp + strlen(s_tmp), "%s", s_email);
    }

	LOG_head("CBAS_Send_Mail-0015");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

#if defined(_SUSE)
    fprintf( fp, "To: %s\n", s_tmp);
#elif defined (_NO_TAG)
    fprintf( fp, "To: %s\n", s_tmp);
#else
    fprintf( fp, "%s%s%s\n", ALARM_TO_TAG, s_tmp, ALARM_TO_END_TAG );
#endif


    // Title
    memset( s_tmp, 0x00, sizeof(s_tmp) );
	if (COM_isnullspace(s_title) == MP_TRUE)
		sprintf( s_tmp, "%s [%s]", ALARM_HEADER_TITLE, s_alarm_id );
	else
		sprintf( s_tmp, "%s", s_title);
	
#if defined(_SUSE)
    fprintf( fp, "Subject: %s\n\n", s_tmp);
#elif defined (_NO_TAG)
    fprintf( fp, "Subject: %s\n\n", s_tmp);
#else
    fprintf( fp, "%s%s%s\n", ALARM_HEADER_TAG, s_tmp, ALARM_HEADER_END_TAG );
#endif


    // Body
    if(s_content[strlen(s_content) - 1] == '\n')
    {
        s_content[strlen(s_content) - 1] = 0x00;
    }

#if defined(_SUSE)
    fprintf( fp, "%s\n", s_content );
	fprintf( fp, "\n%s\n", "This mail is outgoing only. Don't reply this mail.");
#elif defined (_NO_TAG)
    fprintf( fp, "%s\n", s_content );
	fprintf( fp, "\n%s\n", "This mail is outgoing only. Don't reply this mail.");
#else
    fprintf( fp, "%s\n", ALARM_BODY_TAG );
    fprintf( fp, "%s\n", s_content );
    fprintf( fp, "%s\n", ALARM_BODY_END_TAG );
#endif

    // file close
    fclose( fp );
    fp = 0x00;

	LOG_head("CBAS_Send_Mail-0016");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

#if defined(WIN32) || defined(WIN64)

    sprintf( s_command, "%s%s %s", gs_bin_dir, ALARM_MAIL_SEND_PROGRAM, s_filename );

    i_ret = WinExec(s_command, SW_HIDE);

    // Write Log 
    LOG_head("ALM_Mail_Action");
    LOG_add("cmd", MP_NSTR, s_command);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

#elif defined(_HPUX_SOURCE) || defined(__digital__) || defined(_AIX) || defined(_SUSE)

    for( i = 0; i < i_user_count; i++ )
    {
        memset(s_email, 0x00, sizeof(s_email));
        memcpy(s_email, s_alarm_user, sizeof(s_alarm_user));
        COM_add_null(s_email, sizeof(s_email) - 1);

#if defined(_SUSE)
        if(COM_isnullspace(gs_mail_user_name) == MP_TRUE || COM_isnullspace(gs_mail_user_pass) == MP_TRUE)
        {
            sprintf( s_command, "ssmtp %s < \"%s\"", 
                                 s_email, 
                                 s_filename );
        }
        else
        {
            sprintf( s_command, "ssmtp %s -au %s -ap %s < \"%s\"", 
                                 s_email, 
                                 gs_mail_user_name,
                                 gs_mail_user_pass,
                                 s_filename );
        }

#elif defined (_NO_TAG)
        sprintf( s_command, "mailx -r %s -s '%s [%s]' %s < %s",
                             gs_mail_from_id,
                             ALARM_HEADER_TITLE,
                             s_alarm_id,
                             s_email, 
                             s_filename );
#else
        sprintf( s_command, "mailx -s '%s [%s]' %s < %s",
                             ALARM_HEADER_TITLE,
                             s_alarm_id,
                             s_email, 
                             s_filename );
#endif

	LOG_head("CBAS_Send_Mail-0017");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

        i_ret = system( s_command );

        // Write Log 
        LOG_head("ALM_Send_Mail_Action");
        LOG_add("cmd", MP_NSTR, s_command);
        LOG_add("i_ret", MP_INT, i_ret);
        COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

        if(i_ret != 0)
        {
            LOG_head("ALM_Send_Mail_Action - Fail to send mail");
            LOG_add("cmd", MP_NSTR, s_command);
            LOG_add("i_ret", MP_INT, i_ret);
            COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

            if(fp == 0x00)
            {
                memset( s_tmp, 0x00, sizeof(s_tmp) );
                sprintf( s_tmp, "%s.FAIL", s_filename );

                fp = fopen( s_tmp, "w" );
                if( fp == NULL )
                {
                    LOG_head("ALM_Send_Mail_Action - Can't make file to write fail information");
                    LOG_add("FILE_NAME", MP_NSTR, s_tmp);
                    COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
                    return MP_FALSE;
                }

                fprintf( fp, "FAIL TO SEND MAIL.\n" );
                fprintf( fp, "==============================\n" );
                fprintf( fp, "Date    : %.*s\n", sizeof(s_tran_time), s_tran_time );
                fprintf( fp, "File    : %s\n\n", s_filename );
            }
            fprintf( fp, "Mail ID : %s     Return Value : %d\n", s_email, i_ret );
        }
    }
	LOG_head("CBAS_Send_Mail-0018");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(fp != 0x00)
    {
        fclose( fp );
    }

    if(gc_mail_file_copy_flag == 'Y')
    {
        sprintf( s_command, "cp %s %s", s_filename,
                                        gs_mail_contents_back_dir);
        system( s_command );
    }

    if(gc_mail_file_del_flag == 'Y')
    {
        remove( s_filename );
    }

#endif
	LOG_head("CBAS_Send_Mail-0019E");
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    return MP_TRUE;
}