/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_common_function.c
    Description : EIS Common Function

    MES Version : 5.3.4 ~

    Function List

    Detail Description

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include "WIPCore_common.h"

/*******************************************************************************
    CEIS_Save_Message_Log()
        - 
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/

int CEIS_Save_Message_Log(TRSNode *in_node, TRSNode *out_node)
{ 
	//历厘咯何 Flag贸府
	return MP_TRUE;
/*
	struct CEISMSGLOG_TAG CEISMSGLOG;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    TRSNode **node;
	char s_temp[4000];
	char s_sys_time[17];

	int i;
    double d_max_seq_num;
        
    double d_tran_time;
	char s_tran_end_time[17];
	//char s_tran_start_time[17];
    char s_sys_time_stamp[20];  

	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@EIS_MSG_LOG", strlen("@EIS_MSG_LOG"));
	TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "_SERVICE_NAME");
	
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'N'))
	{
		 return MP_TRUE;
	}

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  
	    
    //End Add
	if(gc_collect_error_logging == 'Y')
    {

		if(in_node == 0x00 || out_node == 0x00)
		{
			return MP_FALSE;
		}

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

        memset(s_tran_end_time, ' ', sizeof(s_tran_end_time));
        memcpy(s_tran_end_time, s_sys_time_stamp, sizeof(s_tran_end_time));
        COM_diff_time_millisec(&d_tran_time, s_tran_end_time, TRS.get_string(in_node, "TRAN_START_TIME"));

        if(d_tran_time < 0)
        {
            d_tran_time = 0;
        } 

        memset(s_sys_time, ' ', sizeof(s_sys_time));
        memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));


        // Save Message Log
        d_max_seq_num = 0;
     	CDB_init_ceismsglog(&CEISMSGLOG);
        TRS.copy(CEISMSGLOG.RES_ID, sizeof(CEISMSGLOG.RES_ID), in_node, "RES_ID");
		memcpy(CEISMSGLOG.TRAN_TIME, s_sys_time, sizeof(CEISMSGLOG.TRAN_TIME));
        d_max_seq_num = CDB_select_ceismsglog_scalar(2, &CEISMSGLOG);
        if(DB_error_code != DB_SUCCESS)
        {
            return MP_TRUE;
        }

		CDB_init_ceismsglog(&CEISMSGLOG);
        TRS.copy(CEISMSGLOG.RES_ID, sizeof(CEISMSGLOG.RES_ID), in_node, "RES_ID");
		memcpy(CEISMSGLOG.TRAN_TIME, s_sys_time, sizeof(CEISMSGLOG.TRAN_TIME));
        CEISMSGLOG.SEQ_NUM = (int)++d_max_seq_num;
		memcpy(CEISMSGLOG.SYSTEM_NODE, gs_collect_node, sizeof(CEISMSGLOG.SYSTEM_NODE));
		memcpy(CEISMSGLOG.SERVER_NAME, gs_server_name, sizeof(CEISMSGLOG.SERVER_NAME));
		memcpy(CEISMSGLOG.SUBNO, gs_subno, sizeof(CEISMSGLOG.SUBNO));
		TRS.copy(CEISMSGLOG.SERVICE_NAME, sizeof(CEISMSGLOG.SERVICE_NAME), in_node, "_SERVICE_NAME");
		TRS.copy(CEISMSGLOG.FACTORY, sizeof(CEISMSGLOG.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CEISMSGLOG.LOT_ID, sizeof(CEISMSGLOG.LOT_ID), in_node, "LOT_ID");

		CEISMSGLOG.STATUS_VALUE = TRS.get_char(out_node, OUT_STATUSVALUE);
		TRS.copy(CEISMSGLOG.MSG_ID, sizeof(CEISMSGLOG.MSG_ID), out_node, OUT_MSGCODE);
		TRS.copy(CEISMSGLOG.ERROR_MSG, sizeof(CEISMSGLOG.ERROR_MSG), out_node, OUT_MSG);
		TRS.copy(CEISMSGLOG.DB_ERROR_MSG, sizeof(CEISMSGLOG.DB_ERROR_MSG), out_node, OUT_DBERRMSG);

        TRS.copy(CEISMSGLOG.MSG_CMF_1, sizeof(CEISMSGLOG.MSG_CMF_1), in_node, "LINE_ID");
		TRS.copy(CEISMSGLOG.MSG_CMF_2, sizeof(CEISMSGLOG.MSG_CMF_2), in_node, "OPER"); 
        TRS.copy(CEISMSGLOG.MSG_CMF_3, sizeof(CEISMSGLOG.MSG_CMF_3), in_node, "MAT_ID");  

        if (TRS.mem_cmp(out_node, OUT_MSGCODE, "EDC-0016", strlen("EDC-0016")) == 0)
            TRS.copy(CEISMSGLOG.MSG_CMF_4, sizeof(CEISMSGLOG.MSG_CMF_4), in_node, "COL_SET_ID");  

        if (TRS.get_int(out_node, "CHAR_INDEX") > 0)
        {
            memset(s_temp, ' ', sizeof(s_temp));
            COM_itoa_left(CEISMSGLOG.MSG_CMF_5, TRS.get_int(out_node, "CHAR_INDEX"), sizeof(CEISMSGLOG.MSG_CMF_5)); 
            TRS.copy(CEISMSGLOG.MSG_CMF_6, sizeof(CEISMSGLOG.MSG_CMF_6), out_node, "VALUE");
        }

		CEISMSGLOG.CONSUME_SEC = d_tran_time;

		memset(s_temp, 0x0, sizeof(s_temp));
		node = TRS.get_list(out_node, OUT_FIELDMSG);
		if(node != 0x0)
		{
			for(i = 0; i < node[0]->MemberCount; i++)
			{
				if(node[0]->Members[i]->ValueType == DT_STRING ||
					node[0]->Members[i]->ValueType == DT_NSTRING)
				{
					if(node[0]->Members[i]->Value.s != 0x0)
					{
						if((strlen(s_temp) + strlen(node[0]->Members[i]->Value.s)) > 900)
						{
							break;
						}

						sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.s);
					}
				}
				else if(node[0]->Members[i]->ValueType == DT_CHAR)
				{
					if(node[0]->Members[i]->Value.c != 0x0)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.c);
					}
				}
				else if(node[0]->Members[i]->ValueType == DT_INT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i4);
				}
				else if(node[0]->Members[i]->ValueType == DT_LONG)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i8);
				}
				else if(node[0]->Members[i]->ValueType == DT_FLOAT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f4);
				}
				else if(node[0]->Members[i]->ValueType == DT_DOUBLE)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f8);
				}

				if(strlen(s_temp) > 900)
				{
					break;
				}
			}
		}
		memcpy(CEISMSGLOG.ERROR_MSG_DETAIL, s_temp, strlen(s_temp));

		memset(s_temp, 0x0, sizeof(s_temp));
		if(in_node != 0x0)
		{
			for(i = 0; i < in_node->MemberCount; i++)
			{
				if(in_node->Members[i]->ValueType == DT_STRING ||
					in_node->Members[i]->ValueType == DT_NSTRING)
				{
					if(in_node->Members[i]->Value.s != 0x0)
					{
						if((strlen(s_temp) + strlen(in_node->Members[i]->Value.s)) > 900)
						{
							break;
						}
                        
						if(strcmp(in_node->Members[i]->Name, "_SERVICE_NAME") == 0 ||
							strcmp(in_node->Members[i]->Name, "_MODULE_NAME") == 0||
							strcmp(in_node->Members[i]->Name, "PASSWORD") == 0)
						{
							//Do Nothing
						}
						else
						{
							sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.s);
						}
					}
				}
				else if(in_node->Members[i]->ValueType == DT_CHAR)
				{
					if(in_node->Members[i]->Value.c != 0x0)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.c);
					}
				}
				else if(in_node->Members[i]->ValueType == DT_INT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i4);
				}
				else if(in_node->Members[i]->ValueType == DT_LONG)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i8);
				}
				else if(in_node->Members[i]->ValueType == DT_FLOAT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f4);
				}
				else if(in_node->Members[i]->ValueType == DT_DOUBLE)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f8);
				}

				if(strlen(s_temp) > 900)
				{
					break;
				}
			}
		}
		memcpy(CEISMSGLOG.IN_MSG, s_temp, strlen(s_temp));

		TRS.copy(CEISMSGLOG.CREATE_USER_ID, sizeof(CEISMSGLOG.CREATE_USER_ID), in_node, IN_USERID);
		memcpy(CEISMSGLOG.CREATE_TIME, s_sys_time, sizeof(CEISMSGLOG.CREATE_TIME));

		CDB_insert_ceismsglog(&CEISMSGLOG);
		if(DB_error_code != DB_SUCCESS) 
		{
			DB_rollback();
            return MP_TRUE;
		}

		DB_commit();

    }

    return MP_TRUE;
	*/
} 

int CEIS_Save_Message_Log_For_List(TRSNode *in_node, TRSNode *out_node)
{ 

	//历厘咯何 Flag贸府
	return MP_TRUE;

/*
	struct CEISMSGLOG_TAG CEISMSGLOG;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    TRSNode **node;
	char s_temp[4000];
	char s_sys_time[17];

	int i, j, k;
    double d_max_seq_num;
        
    double d_tran_time;
	char s_tran_end_time[17];
	//char s_tran_start_time[17];
    char s_sys_time_stamp[20];

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  

	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@EIS_MSG_LOG", strlen("@EIS_MSG_LOG"));
	TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "_SERVICE_NAME");
	
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'N'))
	{
		 return MP_TRUE;
	}

    //End Add
	if(gc_collect_error_logging == 'Y')
    {

		if(in_node == 0x00 || out_node == 0x00)
		{
			return MP_FALSE;
		}

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

        memset(s_tran_end_time, ' ', sizeof(s_tran_end_time));
        memcpy(s_tran_end_time, s_sys_time_stamp, sizeof(s_tran_end_time));
        COM_diff_time_millisec(&d_tran_time, s_tran_end_time, TRS.get_string(in_node, "TRAN_START_TIME"));

        if(d_tran_time < 0)
        {
            d_tran_time = 0;
        } 

        memset(s_sys_time, ' ', sizeof(s_sys_time));
        memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));


        // Save Message Log
        d_max_seq_num = 0;
     	CDB_init_ceismsglog(&CEISMSGLOG);
        TRS.copy(CEISMSGLOG.RES_ID, sizeof(CEISMSGLOG.RES_ID), in_node, "RES_ID");
		memcpy(CEISMSGLOG.TRAN_TIME, s_sys_time, sizeof(CEISMSGLOG.TRAN_TIME));
        d_max_seq_num = CDB_select_ceismsglog_scalar(2, &CEISMSGLOG);
        if(DB_error_code != DB_SUCCESS)
        {
            return MP_TRUE;
        }

		CDB_init_ceismsglog(&CEISMSGLOG);
        TRS.copy(CEISMSGLOG.RES_ID, sizeof(CEISMSGLOG.RES_ID), in_node, "RES_ID");
		memcpy(CEISMSGLOG.TRAN_TIME, s_sys_time, sizeof(CEISMSGLOG.TRAN_TIME));
        CEISMSGLOG.SEQ_NUM = (int)++d_max_seq_num;
		memcpy(CEISMSGLOG.SYSTEM_NODE, gs_collect_node, sizeof(CEISMSGLOG.SYSTEM_NODE));
		memcpy(CEISMSGLOG.SERVER_NAME, gs_server_name, sizeof(CEISMSGLOG.SERVER_NAME));
		memcpy(CEISMSGLOG.SUBNO, gs_subno, sizeof(CEISMSGLOG.SUBNO));
		TRS.copy(CEISMSGLOG.SERVICE_NAME, sizeof(CEISMSGLOG.SERVICE_NAME), in_node, "_SERVICE_NAME");
		TRS.copy(CEISMSGLOG.FACTORY, sizeof(CEISMSGLOG.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CEISMSGLOG.LOT_ID, sizeof(CEISMSGLOG.LOT_ID), in_node, "LOT_ID");

		if (COM_isspace(CEISMSGLOG.LOT_ID, sizeof(CEISMSGLOG.LOT_ID)) == MP_TRUE)
		{
			TRS.copy(CEISMSGLOG.LOT_ID, sizeof(CEISMSGLOG.LOT_ID), in_node, "STRING_ID");
		}

		CEISMSGLOG.STATUS_VALUE = TRS.get_char(out_node, OUT_STATUSVALUE);
		TRS.copy(CEISMSGLOG.MSG_ID, sizeof(CEISMSGLOG.MSG_ID), out_node, OUT_MSGCODE);
		TRS.copy(CEISMSGLOG.ERROR_MSG, sizeof(CEISMSGLOG.ERROR_MSG), out_node, OUT_MSG);
		TRS.copy(CEISMSGLOG.DB_ERROR_MSG, sizeof(CEISMSGLOG.DB_ERROR_MSG), out_node, OUT_DBERRMSG);

        TRS.copy(CEISMSGLOG.MSG_CMF_1, sizeof(CEISMSGLOG.MSG_CMF_1), in_node, "LINE_ID");
		TRS.copy(CEISMSGLOG.MSG_CMF_2, sizeof(CEISMSGLOG.MSG_CMF_2), in_node, "OPER"); 
        TRS.copy(CEISMSGLOG.MSG_CMF_3, sizeof(CEISMSGLOG.MSG_CMF_3), in_node, "MAT_ID");  
        TRS.copy(CEISMSGLOG.MSG_CMF_4, sizeof(CEISMSGLOG.MSG_CMF_4), out_node, "ORG_MSG_ID");  

        if (TRS.mem_cmp(out_node, OUT_MSGCODE, "EDC-0016", strlen("EDC-0016")) == 0)
            TRS.copy(CEISMSGLOG.MSG_CMF_4, sizeof(CEISMSGLOG.MSG_CMF_4), in_node, "COL_SET_ID");  

        if (TRS.get_int(out_node, "CHAR_INDEX") > 0)
        {
            memset(s_temp, ' ', sizeof(s_temp));
            COM_itoa_left(CEISMSGLOG.MSG_CMF_5, TRS.get_int(out_node, "CHAR_INDEX"), sizeof(CEISMSGLOG.MSG_CMF_5)); 
            TRS.copy(CEISMSGLOG.MSG_CMF_6, sizeof(CEISMSGLOG.MSG_CMF_6), out_node, "VALUE");
        }

		CEISMSGLOG.CONSUME_SEC = d_tran_time;

		memset(s_temp, 0x0, sizeof(s_temp));
		node = TRS.get_list(out_node, OUT_FIELDMSG);
		if(node != 0x0)
		{
			for(i = 0; i < node[0]->MemberCount; i++)
			{
				if(node[0]->Members[i]->ValueType == DT_STRING ||
					node[0]->Members[i]->ValueType == DT_NSTRING)
				{
					if(node[0]->Members[i]->Value.s != 0x0)
					{
						if((strlen(s_temp) + strlen(node[0]->Members[i]->Value.s)) > 900)
						{
							break;
						}

						sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.s);
					}
				}
				else if(node[0]->Members[i]->ValueType == DT_CHAR)
				{
					if(node[0]->Members[i]->Value.c != 0x0)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.c);
					}
				}
				else if(node[0]->Members[i]->ValueType == DT_INT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i4);
				}
				else if(node[0]->Members[i]->ValueType == DT_LONG)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i8);
				}
				else if(node[0]->Members[i]->ValueType == DT_FLOAT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f4);
				}
				else if(node[0]->Members[i]->ValueType == DT_DOUBLE)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f8);
				}

				if(strlen(s_temp) > 900)
				{
					break;
				}
			}
		}
		memcpy(CEISMSGLOG.ERROR_MSG_DETAIL, s_temp, strlen(s_temp));

		memset(s_temp, 0x0, sizeof(s_temp));

		if(in_node != 0x0)
		{
            // Save Member Items 
			for(i = 0; i < in_node->MemberCount; i++)
			{
				if(in_node->Members[i]->ValueType == DT_STRING ||
					in_node->Members[i]->ValueType == DT_NSTRING)
				{
					if(in_node->Members[i]->Value.s != 0x0)
					{
						if((strlen(s_temp) + strlen(in_node->Members[i]->Value.s)) > 900)
						{
							break;
						}
                        
						if(strcmp(in_node->Members[i]->Name, "_SERVICE_NAME") == 0 ||
							strcmp(in_node->Members[i]->Name, "_MODULE_NAME") == 0||
							strcmp(in_node->Members[i]->Name, "PASSWORD") == 0)
						{
							//Do Nothing
						}
						else
						{
							sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.s);
						}
					}
				}
				else if(in_node->Members[i]->ValueType == DT_CHAR)
				{
					if(in_node->Members[i]->Value.c != 0x0)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.c);
					}
				}
				else if(in_node->Members[i]->ValueType == DT_INT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i4);
				}
				else if(in_node->Members[i]->ValueType == DT_LONG)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i8);
				}
				else if(in_node->Members[i]->ValueType == DT_FLOAT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f4);
				}
				else if(in_node->Members[i]->ValueType == DT_DOUBLE)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f8);
				}

				if(strlen(s_temp) > 900)
				{
					break;
				}
			}

            // Save List Items 
			for(i = 0; i < in_node->ListCount; i++)
			{
                if (strlen(s_temp) > 3500)
                {
                    break;
                }

                if(in_node->List[i]->Items[0]->ValueType == DT_LIST) // LIST 
                {
                    sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", in_node->List[i]->Items[0]->Name, in_node->List[i]->Items[0]->Value.s);
                }

                if(in_node->List[i]->Items[0]->MemberCount >= 1)
                {
                    if(in_node->List[i]->Items[0]->Members[0]->ValueType == DT_STRING ||
                        in_node->List[i]->Items[0]->Members[0]->ValueType == DT_NSTRING) // STRING  
                    {
                        sprintf(s_temp+strlen(s_temp), "\t %s=[%s] \n", in_node->List[i]->Items[0]->Members[0]->Name, in_node->List[i]->Items[0]->Members[0]->Value.s);
                    }
                }

 			    for(j = 0; j < in_node->List[i]->Items[0]->SCount; j++)
			    {
                    if (strlen(s_temp) > 3500)
                    {
                        break;
                    }

                    if(in_node->List[i]->Items[0]->List[0]->Items[j]->ValueType == DT_LIST) // LIST  
                    {
                        sprintf(s_temp+strlen(s_temp), "\t %s=[%s] \n", in_node->List[i]->Items[0]->List[0]->Items[j]->Name, in_node->List[i]->Items[0]->List[0]->Items[j]->Value.s);
                    }
                    else
                    {
                        sprintf(s_temp+strlen(s_temp), "\t %s=[%s] \n", in_node->List[i]->Items[0]->List[0]->Items[j]->Name, in_node->List[i]->Items[0]->List[0]->Items[j]->Value.s);
                    }

 			        for(k = 0; k < in_node->List[i]->Items[0]->List[0]->Items[j]->MemberCount; k++)
			        {
                        if (strlen(s_temp) > 3500)
                        {
                            break;
                        }

                        sprintf(s_temp+strlen(s_temp), "\t \t %s=[%s] \n", in_node->List[i]->Items[0]->List[0]->Items[j]->Members[k]->Name, in_node->List[i]->Items[0]->List[0]->Items[j]->Members[k]->Value.s);
                    }
                }
            }

		}

		memcpy(CEISMSGLOG.IN_MSG, s_temp, strlen(s_temp));

		TRS.copy(CEISMSGLOG.CREATE_USER_ID, sizeof(CEISMSGLOG.CREATE_USER_ID), in_node, IN_USERID);
		memcpy(CEISMSGLOG.CREATE_TIME, s_sys_time, sizeof(CEISMSGLOG.CREATE_TIME));

		CDB_insert_ceismsglog(&CEISMSGLOG);
		if(DB_error_code != DB_SUCCESS) 
		{
			DB_rollback();
            return MP_TRUE;
		}

		DB_commit();

    }

    return MP_TRUE;
	*/
} 

int CEIS_Save_Message_Log_For_Single_List(TRSNode *in_node, TRSNode *out_node)
{ 
		//历厘咯何 Flag贸府
	return MP_TRUE;
/*
	struct CEISMSGLOG_TAG CEISMSGLOG;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

    TRSNode **node;
	char s_temp[4000];
	char s_sys_time[17];

	int i, j, k;
    double d_max_seq_num;
        
    double d_tran_time;
	char s_tran_end_time[17];
	//char s_tran_start_time[17];
    char s_sys_time_stamp[20]; 
	
    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));  
	 
	DBC_init_mgcmlagdat(&MGCMLAGDAT);
	TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMLAGDAT.TABLE_NAME, "@EIS_MSG_LOG", strlen("@EIS_MSG_LOG"));
	TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "_SERVICE_NAME");
	
	DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
	if((DB_error_code == DB_SUCCESS) && (MGCMLAGDAT.DATA_1[0] == 'N'))
	{
		 return MP_TRUE;
	}

    //End Add
	if(gc_collect_error_logging == 'Y')
    {

		if(in_node == 0x00 || out_node == 0x00)
		{
			return MP_FALSE;
		}

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

        memset(s_tran_end_time, ' ', sizeof(s_tran_end_time));
        memcpy(s_tran_end_time, s_sys_time_stamp, sizeof(s_tran_end_time));
        COM_diff_time_millisec(&d_tran_time, s_tran_end_time, TRS.get_string(in_node, "TRAN_START_TIME"));

        if(d_tran_time < 0)
        {
            d_tran_time = 0;
        } 

        memset(s_sys_time, ' ', sizeof(s_sys_time));
        memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));


        // Save Message Log
        d_max_seq_num = 0;
     	CDB_init_ceismsglog(&CEISMSGLOG);
        TRS.copy(CEISMSGLOG.RES_ID, sizeof(CEISMSGLOG.RES_ID), in_node, "RES_ID");
		memcpy(CEISMSGLOG.TRAN_TIME, s_sys_time, sizeof(CEISMSGLOG.TRAN_TIME));
        d_max_seq_num = CDB_select_ceismsglog_scalar(2, &CEISMSGLOG);
        if(DB_error_code != DB_SUCCESS)
        {
            return MP_TRUE;
        }

		CDB_init_ceismsglog(&CEISMSGLOG);
        TRS.copy(CEISMSGLOG.RES_ID, sizeof(CEISMSGLOG.RES_ID), in_node, "RES_ID");
		memcpy(CEISMSGLOG.TRAN_TIME, s_sys_time, sizeof(CEISMSGLOG.TRAN_TIME));
        CEISMSGLOG.SEQ_NUM = (int) ++d_max_seq_num;
		memcpy(CEISMSGLOG.SYSTEM_NODE, gs_collect_node, sizeof(CEISMSGLOG.SYSTEM_NODE));
		memcpy(CEISMSGLOG.SERVER_NAME, gs_server_name, sizeof(CEISMSGLOG.SERVER_NAME));
		memcpy(CEISMSGLOG.SUBNO, gs_subno, sizeof(CEISMSGLOG.SUBNO));
		TRS.copy(CEISMSGLOG.SERVICE_NAME, sizeof(CEISMSGLOG.SERVICE_NAME), in_node, "_SERVICE_NAME");
		TRS.copy(CEISMSGLOG.FACTORY, sizeof(CEISMSGLOG.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CEISMSGLOG.LOT_ID, sizeof(CEISMSGLOG.LOT_ID), in_node, "LOT_ID");

		if (COM_isspace(CEISMSGLOG.LOT_ID, sizeof(CEISMSGLOG.LOT_ID)) == MP_TRUE)
		{
			TRS.copy(CEISMSGLOG.LOT_ID, sizeof(CEISMSGLOG.LOT_ID), in_node, "STRING_ID");
		}

		CEISMSGLOG.STATUS_VALUE = TRS.get_char(out_node, OUT_STATUSVALUE);
		TRS.copy(CEISMSGLOG.MSG_ID, sizeof(CEISMSGLOG.MSG_ID), out_node, OUT_MSGCODE);
		TRS.copy(CEISMSGLOG.ERROR_MSG, sizeof(CEISMSGLOG.ERROR_MSG), out_node, OUT_MSG);
		TRS.copy(CEISMSGLOG.DB_ERROR_MSG, sizeof(CEISMSGLOG.DB_ERROR_MSG), out_node, OUT_DBERRMSG);

        TRS.copy(CEISMSGLOG.MSG_CMF_1, sizeof(CEISMSGLOG.MSG_CMF_1), in_node, "LINE_ID");
		TRS.copy(CEISMSGLOG.MSG_CMF_2, sizeof(CEISMSGLOG.MSG_CMF_2), in_node, "OPER"); 
        TRS.copy(CEISMSGLOG.MSG_CMF_3, sizeof(CEISMSGLOG.MSG_CMF_3), in_node, "MAT_ID");  
        TRS.copy(CEISMSGLOG.MSG_CMF_4, sizeof(CEISMSGLOG.MSG_CMF_4), out_node, "ORG_MSG_ID");  

        if (TRS.mem_cmp(out_node, OUT_MSGCODE, "EDC-0016", strlen("EDC-0016")) == 0)
            TRS.copy(CEISMSGLOG.MSG_CMF_4, sizeof(CEISMSGLOG.MSG_CMF_4), in_node, "COL_SET_ID");  

        if (TRS.get_int(out_node, "CHAR_INDEX") > 0)
        {
            memset(s_temp, ' ', sizeof(s_temp));
            COM_itoa_left(CEISMSGLOG.MSG_CMF_5, TRS.get_int(out_node, "CHAR_INDEX"), sizeof(CEISMSGLOG.MSG_CMF_5)); 
            TRS.copy(CEISMSGLOG.MSG_CMF_6, sizeof(CEISMSGLOG.MSG_CMF_6), out_node, "VALUE");
        }

		CEISMSGLOG.CONSUME_SEC = d_tran_time;

		memset(s_temp, 0x0, sizeof(s_temp));
		node = TRS.get_list(out_node, OUT_FIELDMSG);
		if(node != 0x0)
		{
			for(i = 0; i < node[0]->MemberCount; i++)
			{
				if(node[0]->Members[i]->ValueType == DT_STRING ||
					node[0]->Members[i]->ValueType == DT_NSTRING)
				{
					if(node[0]->Members[i]->Value.s != 0x0)
					{
						if((strlen(s_temp) + strlen(node[0]->Members[i]->Value.s)) > 900)
						{
							break;
						}

						sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.s);
					}
				}
				else if(node[0]->Members[i]->ValueType == DT_CHAR)
				{
					if(node[0]->Members[i]->Value.c != 0x0)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.c);
					}
				}
				else if(node[0]->Members[i]->ValueType == DT_INT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i4);
				}
				else if(node[0]->Members[i]->ValueType == DT_LONG)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.i8);
				}
				else if(node[0]->Members[i]->ValueType == DT_FLOAT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f4);
				}
				else if(node[0]->Members[i]->ValueType == DT_DOUBLE)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", node[0]->Members[i]->Name, node[0]->Members[i]->Value.f8);
				}

				if(strlen(s_temp) > 900)
				{
					break;
				}
			}
		}
		memcpy(CEISMSGLOG.ERROR_MSG_DETAIL, s_temp, strlen(s_temp));

		memset(s_temp, 0x0, sizeof(s_temp));

		if(in_node != 0x0)
		{
            // Save Member Items 
			for(i = 0; i < in_node->MemberCount; i++)
			{
				if(in_node->Members[i]->ValueType == DT_STRING ||
					in_node->Members[i]->ValueType == DT_NSTRING)
				{
					if(in_node->Members[i]->Value.s != 0x0)
					{
						if((strlen(s_temp) + strlen(in_node->Members[i]->Value.s)) > 900)
						{
							break;
						}
                        
						if(strcmp(in_node->Members[i]->Name, "_SERVICE_NAME") == 0 ||
							strcmp(in_node->Members[i]->Name, "_MODULE_NAME") == 0||
							strcmp(in_node->Members[i]->Name, "PASSWORD") == 0)
						{
							//Do Nothing
						}
						else
						{
							sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.s);
						}
					}
				}
				else if(in_node->Members[i]->ValueType == DT_CHAR)
				{
					if(in_node->Members[i]->Value.c != 0x0)
					{
						sprintf(s_temp+strlen(s_temp), "%s=[%c] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.c);
					}
				}
				else if(in_node->Members[i]->ValueType == DT_INT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%d] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i4);
				}
				else if(in_node->Members[i]->ValueType == DT_LONG)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%ld] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.i8);
				}
				else if(in_node->Members[i]->ValueType == DT_FLOAT)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f4);
				}
				else if(in_node->Members[i]->ValueType == DT_DOUBLE)
				{
					sprintf(s_temp+strlen(s_temp), "%s=[%f] \n", in_node->Members[i]->Name, in_node->Members[i]->Value.f8);
				}

				if(strlen(s_temp) > 900)
				{
					break;
				}
			}

            // Save List Items
			for(i = 0; i < in_node->ListCount; i++)
			{
                if (strlen(s_temp) > 3500)
                {
                    break;
                }

 			    for(j = 0; j < in_node->List[i]->Count; j++)
			    {
                    if(in_node->List[i]->Items[j]->ValueType == DT_LIST) // LIST
                    {
                        sprintf(s_temp+strlen(s_temp), "%s=[%s] \n", in_node->List[i]->Items[0]->Name, in_node->List[i]->Items[0]->Value.s);
                    }

                    for (k = 0 ; k < in_node->List[i]->Items[j]->MemberCount; k++)
                    {
                        sprintf(s_temp+strlen(s_temp), "\t %s=[%s] \n", in_node->List[i]->Items[j]->Members[k]->Name, in_node->List[i]->Items[j]->Members[k]->Value.s);
                    }
                }


            }

		}

		memcpy(CEISMSGLOG.IN_MSG, s_temp, strlen(s_temp));

		TRS.copy(CEISMSGLOG.CREATE_USER_ID, sizeof(CEISMSGLOG.CREATE_USER_ID), in_node, IN_USERID);
		memcpy(CEISMSGLOG.CREATE_TIME, s_sys_time, sizeof(CEISMSGLOG.CREATE_TIME));

		CDB_insert_ceismsglog(&CEISMSGLOG);
		if(DB_error_code != DB_SUCCESS) 
		{
			DB_rollback();
            return MP_TRUE;
		}

		DB_commit();

    }

    return MP_TRUE;
*/

} 


/*******************************************************************************
	CEIS_Save_Load_Unload_Magazine()
		-
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/

int CEIS_Save_Load_Unload_Magazine(TRSNode* in_node, TRSNode* out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct CRASCRRHIS_TAG CRASCRRHIS;
	
	char   s_sys_time[14];

	DBC_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "@MAGAZINE_RECORD", strlen("@MAGAZINE_RECORD"));
	TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "RES_ID");
	DBC_select_mgcmtbldat(1, &MGCMTBLDAT);

	if (MGCMTBLDAT.DATA_1[0] == 'Y')
	{
		memset(s_sys_time, ' ', sizeof(s_sys_time));
		DB_get_systime(s_sys_time);
		if (DB_error_code != DB_SUCCESS)
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

		CDB_init_crascrrhis(&CRASCRRHIS);
		TRS.copy(CRASCRRHIS.FACTORY, sizeof(CRASCRRHIS.FACTORY), in_node, "FACTORY");
		TRS.copy(CRASCRRHIS.RES_ID, sizeof(CRASCRRHIS.RES_ID), in_node, "RES_ID");
		memcpy(CRASCRRHIS.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CRASCRRHIS.EQ_TYPE, sizeof(CRASCRRHIS.EQ_TYPE), in_node, "EQP_TYPE");
		TRS.copy(CRASCRRHIS.ACTION, sizeof(CRASCRRHIS.ACTION), in_node, "ACTION"); //magazine Loading/Unloading
		TRS.copy(CRASCRRHIS.LOC_ID, sizeof(CRASCRRHIS.LOC_ID), in_node, "LOC_ID");
		TRS.copy(CRASCRRHIS.LINE_ID, sizeof(CRASCRRHIS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(CRASCRRHIS.ORDER_ID, sizeof(CRASCRRHIS.ORDER_ID), in_node, "ORDER_ID");
		TRS.copy(CRASCRRHIS.VMAGAZINE_ID, sizeof(CRASCRRHIS.VMAGAZINE_ID), in_node, "VMAGAZINE_ID");
		TRS.copy(CRASCRRHIS.MAGAZINE_ID, sizeof(CRASCRRHIS.MAGAZINE_ID), in_node, "MAGAZINE_ID");
		CRASCRRHIS.QTY = TRS.get_int(in_node, "MAGAZINE_QTY");
		
		CDB_insert_crascrrhis(&CRASCRRHIS);
		if (DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING

			LOG_head("CEIS_Save_Load_Unload_Magazine Insert Error");
			LOG_add("FACOTRY", MP_STR, sizeof(CRASCRRHIS.FACTORY), CRASCRRHIS.FACTORY);
			LOG_add("RES_ID", MP_STR, sizeof(CRASCRRHIS.RES_ID), CRASCRRHIS.RES_ID);
			LOG_add("TRAN_TIME", MP_STR, sizeof(CRASCRRHIS.TRAN_TIME), CRASCRRHIS.TRAN_TIME);
			LOG_add("EQ_TYPE", MP_STR, sizeof(CRASCRRHIS.EQ_TYPE), CRASCRRHIS.EQ_TYPE);
			LOG_add("ACTION", MP_STR, sizeof(CRASCRRHIS.ACTION), CRASCRRHIS.ACTION);
			LOG_add("LOC_ID", MP_STR, sizeof(CRASCRRHIS.LOC_ID), CRASCRRHIS.LOC_ID);
			LOG_add("LINE_ID", MP_STR, sizeof(CRASCRRHIS.LINE_ID), CRASCRRHIS.LINE_ID);
			LOG_add("ORDER_ID", MP_STR, sizeof(CRASCRRHIS.ORDER_ID), CRASCRRHIS.ORDER_ID);
			LOG_add("VMAGAZINE_ID", MP_STR, sizeof(CRASCRRHIS.VMAGAZINE_ID), CRASCRRHIS.VMAGAZINE_ID);
			LOG_add("MAGAZINE_ID", MP_STR, sizeof(CRASCRRHIS.MAGAZINE_ID), CRASCRRHIS.MAGAZINE_ID);

			COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
		}
	}

	return MP_TRUE;
}
