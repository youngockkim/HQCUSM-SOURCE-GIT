/*******************************************************************************

    System      : MESplus
    Module      : CBAS
    File Name   : CBAS_view_query_result.c
    Description : View Query Result (MBASSQLDEF)

    MES Version : 5.3.1

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2014/04/30  JYPARK         Create

    Copyright(C) 1998-2014 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "BASCore_common.h"

int CBAS_VIEW_QUERY_RESULT(char *s_msg_code,
                           TRSNode *in_node, 
                           TRSNode *out_node);

/*******************************************************************************
    CBAS_View_Query_Result()
        - View Query Result (MBASSQLDEF)
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input TRSNode
        - TRSNode *out_node : Output TRSNode  
*******************************************************************************/
int CBAS_View_Query_Result(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CBAS_VIEW_QUERY_RESULT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CBAS_VIEW_QUERY_RESULT", out_node);

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
    CBAS_VIEW_QUERY_RESULT()
        - Main sub function of "CBAS_View_Query_Result" function
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input TRSNode
        - TRSNode *out_node : Output TRSNode  
*******************************************************************************/
int CBAS_VIEW_QUERY_RESULT(char *s_msg_code,
                           TRSNode *in_node, 
                           TRSNode *out_node)
{
    struct MBASSQLDEF_TAG MBASSQLDEF;
    int i, j;
    int i_loc;
    int i_start, i_end;
    char s_factory[12];

    LOG_head("CBAS_View_Query_Result");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("sql_id_1", MP_NSTR, TRS.get_string(in_node, "SQL_ID_1"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    //if(COM_proc_user_routine("BAS", "CBAS_View_Query_Result",
    //                         MP_UPOINT_BEFORE,
    //                         in_node,
    //                         out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* SQL ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "SQL_ID_1")) == MP_TRUE)
    {
        strcpy(s_msg_code, "BAS-0001");
        TRS.add_fieldmsg(out_node, "SQL_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// '1' : View SQL query with replaced parameter
	if(TRS.get_procstep(in_node) == '1')
	{
		DBC_init_mbassqldef(&MBASSQLDEF);
		TRS.copy(MBASSQLDEF.SQL_ID, sizeof(MBASSQLDEF.SQL_ID), in_node, "SQL_ID_1");

		DBC_select_mbassqldef(1, &MBASSQLDEF);
		if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "MSG-0003");
			TRS.add_dberrmsg(out_node, DB_error_msg);    
			TRS.add_fieldmsg(out_node, "MBASSQLDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "SQL_ID", MP_STR, sizeof(MBASSQLDEF.SQL_ID), MBASSQLDEF.SQL_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		{
			char sql[20001];
			char d_sql[20001];
			char *p_sql;
			char s_argu[4001];
			char s_temp[4001];
			int i_size;

			int i_argu_count;
			TRSNode **argu_list;

			memset(sql, 0x00, sizeof(sql));
			memset(d_sql, 0x00, sizeof(d_sql));
			i_start = 0;
			i_end = 0;

			i_argu_count = TRS.get_item_count(in_node, "ARGU_LIST");
			argu_list = TRS.get_list(in_node, "ARGU_LIST");

			p_sql = sql;
			i_loc = COM_string_length(MBASSQLDEF.SQL_1, sizeof(MBASSQLDEF.SQL_1));  
			memcpy(p_sql, MBASSQLDEF.SQL_1, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_2, sizeof(MBASSQLDEF.SQL_2));  
			memcpy(p_sql, MBASSQLDEF.SQL_2, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_3, sizeof(MBASSQLDEF.SQL_3));  
			memcpy(p_sql, MBASSQLDEF.SQL_3, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_4, sizeof(MBASSQLDEF.SQL_4));  
			memcpy(p_sql, MBASSQLDEF.SQL_4, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_5, sizeof(MBASSQLDEF.SQL_5));  
			memcpy(p_sql, MBASSQLDEF.SQL_5, i_loc);

			i_loc = 0;
			memset(s_factory, 0x00, sizeof(s_factory));
			s_factory[0] = '\'';

			TRS.get_string_param(in_node, IN_FACTORY, s_factory + 1); 
			s_factory[strlen(s_factory)] = '\'';

			i_size = (int)strlen(s_factory);

			while(1)
			{
				i_start = COM_search_string(sql, (int)strlen(sql), "$FACTORY", 8);
				if(i_start > 0)
				{
					COM_replace_string(d_sql, sizeof(d_sql),
						sql, (int)strlen(sql),
						i_start, i_start + 8, 
						s_factory, i_size);
					memset(sql, 0x00, sizeof(sql));
					memcpy(sql, d_sql, sizeof(sql));
					memset(d_sql, 0x00, sizeof(d_sql));
				}
				else
				{
					break;
				}
			}

			memcpy(d_sql, sql, sizeof(d_sql));
			while(1)
			{
				i_start = COM_search_string(d_sql, sizeof(d_sql), "$", 1);
				if(i_start > 0)
				{
					if(i_argu_count < 1)
					{
						strcpy(s_msg_code, "GCM-0022");

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_VALIDATION;
						gs_log_type.category = MP_LOG_CATE_VIEW;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}

					for(i = i_start + 1; i < sizeof(d_sql); i++)
					{
						if(d_sql[i] == ' ' || d_sql[i] == 0x00 || d_sql[i] == '(' || d_sql[i] == ')' || d_sql[i] == '|' || d_sql[i] == ',')
						{
							i_end = i;
							break;
						}

						if(COM_isnum(d_sql + i, 1, 'N', MP_FALSE) == MP_FALSE)
						{
							i_end = i;
							break;
						}
					}
				}
				else
				{
					break;
				}

				j = COM_atoi(d_sql + i_start + 1, i_end - i_start - 1);
				j--;

				if(j < 0)   break;

				//Add by J.S. 2012.06.25 bug fix
				if(i_argu_count <= j)
				{
					strcpy(s_msg_code, "GCM-0023");

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_VALIDATION;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				memset(s_temp, 0x00, sizeof(s_temp));
				memset(s_argu, 0x00, sizeof(s_argu));
				s_argu[0] = '\'';
				TRS.copy(s_temp, sizeof(s_temp), argu_list[j], "ARGUMENT");
				COM_add_null(s_temp, sizeof(s_temp) - 1);

				strcat(s_argu, s_temp);
				s_argu[strlen(s_argu)] = '\'';

				i_size = 0;
				i_size = COM_string_length(s_argu, sizeof(s_argu));
				memset(sql, 0x00, sizeof(sql));
				COM_replace_string(sql, sizeof(sql),
					d_sql, (int)strlen(d_sql),
					i_start, i_end,
					s_argu, i_size);

				memset(d_sql, 0x00, sizeof(d_sql));
				memcpy(d_sql, sql, sizeof(d_sql));
			}

			TRS.set_string(out_node, "SQL", d_sql, sizeof(d_sql));
		}
	}
	// '2' : View raw SQL query
	else if(TRS.get_procstep(in_node) == '2')
	{
		DBC_init_mbassqldef(&MBASSQLDEF);
		TRS.copy(MBASSQLDEF.SQL_ID, sizeof(MBASSQLDEF.SQL_ID), in_node, "SQL_ID_1");

		DBC_select_mbassqldef(1, &MBASSQLDEF);
		if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "MSG-0003");
			TRS.add_dberrmsg(out_node, DB_error_msg);    
			TRS.add_fieldmsg(out_node, "MBASSQLDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "SQL_ID", MP_STR, sizeof(MBASSQLDEF.SQL_ID), MBASSQLDEF.SQL_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		{
			char sql[20001];
			char d_sql[20001];
			char *p_sql;

			int i_argu_count;
			TRSNode **argu_list;

			memset(sql, 0x00, sizeof(sql));
			memset(d_sql, 0x00, sizeof(d_sql));
			i_start = 0;
			i_end = 0;

			i_argu_count = TRS.get_item_count(in_node, "ARGU_LIST");
			argu_list = TRS.get_list(in_node, "ARGU_LIST");

			p_sql = sql;
			i_loc = COM_string_length(MBASSQLDEF.SQL_1, sizeof(MBASSQLDEF.SQL_1));  
			memcpy(p_sql, MBASSQLDEF.SQL_1, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_2, sizeof(MBASSQLDEF.SQL_2));  
			memcpy(p_sql, MBASSQLDEF.SQL_2, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_3, sizeof(MBASSQLDEF.SQL_3));  
			memcpy(p_sql, MBASSQLDEF.SQL_3, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_4, sizeof(MBASSQLDEF.SQL_4));  
			memcpy(p_sql, MBASSQLDEF.SQL_4, i_loc); p_sql += i_loc;
			i_loc = COM_string_length(MBASSQLDEF.SQL_5, sizeof(MBASSQLDEF.SQL_5));  
			memcpy(p_sql, MBASSQLDEF.SQL_5, i_loc);

			TRS.set_string(out_node, "SQL", p_sql, sizeof(p_sql));
		}
    }

    if(COM_proc_user_routine("BAS", "CBAS_View_Query_Result",
                            MP_UPOINT_AFTER,
                            in_node,
                            out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}
