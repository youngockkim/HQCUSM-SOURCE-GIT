/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_crasdshift_list.c
    Description : View Crasdshift List function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_Crasdshift_List()
            + View Crasdshift definition List
        - CRAS_VIEW_CRASDSHIFT_LIST()
            + Main sub function of CRAS_View_Crasdshift_List function
            + View Crasdshift definition List
    Detail Description
        - CRAS_VIEW_CRASDSHIFT_LIST()
            + h_proc_step
                + 1 : View Crasdshift definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-04-20             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_Crasdshift_List()
        - View Crasdshift definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Crasdshift_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_CRASDSHIFT_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_CRASDSHIFT_LIST", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CRAS_VIEW_CRASDSHIFT_LIST()
        - Main sub function of "CRAS_View_Crasdshift_List" function
        - View Crasdshift definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_CRASDSHIFT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASDSHIFT_TAG CRASDSHIFT;
	struct CRASSFTHIS_TAG CRASSFTHIS;

	int chk_count = 0;

    TRSNode *list_item;

    int i_case;

	LOG_head("CRAS_VIEW_CRASDSHIFT_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    
    //i_case = 2;
	i_case = 3; //add line location [2023.11.24] 

    CDB_init_crasdshift(&CRASDSHIFT);
    TRS.copy(CRASDSHIFT.WORK_DATE, sizeof(CRASDSHIFT.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CRASDSHIFT.WORK_SHIFT, sizeof(CRASDSHIFT.WORK_SHIFT), in_node, "WORK_SHIFT");
	TRS.copy(CRASDSHIFT.CMF_5, sizeof(CRASDSHIFT.CMF_5), in_node, "LINE_LOCATION");
	
	chk_count = (int) CDB_select_crasdshift_scalar( i_case, &CRASDSHIFT);

	if(chk_count > 1)
	{

			CDB_open_crasdshift(i_case, &CRASDSHIFT);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "RAS-0004");
				TRS.add_fieldmsg(out_node, "CRASDSHIFT OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT.WORK_DATE), CRASDSHIFT.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT.LINE_ID), CRASDSHIFT.LINE_ID);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT.WORK_SHIFT), CRASDSHIFT.WORK_SHIFT);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
					while(1)
					{
						CDB_fetch_crasdshift(i_case, &CRASDSHIFT);
						if(DB_error_code == DB_NOT_FOUND)
						{
							CDB_close_crasdshift(i_case);
							break;
						}
						else if(DB_error_code != DB_SUCCESS)
						{
							strcpy(s_msg_code, "RAS-0004");
							TRS.add_fieldmsg(out_node, "CRASDSHIFT FETCH", MP_NVST);
							TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDSHIFT.WORK_DATE), CRASDSHIFT.WORK_DATE);
							TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDSHIFT.LINE_ID), CRASDSHIFT.LINE_ID);
							TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDSHIFT.WORK_SHIFT), CRASDSHIFT.WORK_SHIFT);
							TRS.add_dberrmsg(out_node, DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;

							CDB_close_crasdshift(i_case);
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}

       

						list_item = TRS.add_node(out_node, "CRASDSHIFT_LIST");

						TRS.add_string(list_item, "WORK_DATE", CRASDSHIFT.WORK_DATE, sizeof(CRASDSHIFT.WORK_DATE));
						TRS.add_string(list_item, "LINE_ID", CRASDSHIFT.LINE_ID, sizeof(CRASDSHIFT.LINE_ID));
						TRS.add_string(list_item, "WORK_SHIFT", CRASDSHIFT.WORK_SHIFT, sizeof(CRASDSHIFT.WORK_SHIFT));
						TRS.add_int(list_item, "RW", CRASDSHIFT.RW);
						TRS.add_int(list_item, "FRA", CRASDSHIFT.FRA);
						TRS.add_int(list_item, "ETC", CRASDSHIFT.ETC);
						TRS.add_int(list_item, "OK", CRASDSHIFT.OK);
						TRS.add_int(list_item, "NG", CRASDSHIFT.NG);
						TRS.add_string(list_item, "CREATE_USER_ID", CRASDSHIFT.CREATE_USER_ID, sizeof(CRASDSHIFT.CREATE_USER_ID));
						TRS.add_string(list_item, "UPDATE_USER_ID", CRASDSHIFT.UPDATE_USER_ID, sizeof(CRASDSHIFT.UPDATE_USER_ID));
						TRS.add_string(list_item, "TRAN_TIME", CRASDSHIFT.TRAN_TIME, sizeof(CRASDSHIFT.TRAN_TIME));
						TRS.add_string(list_item, "CMF_1", CRASDSHIFT.CMF_1, sizeof(CRASDSHIFT.CMF_1));
						TRS.add_string(list_item, "CMF_2", CRASDSHIFT.CMF_2, sizeof(CRASDSHIFT.CMF_2));
						TRS.add_string(list_item, "CMF_3", CRASDSHIFT.CMF_3, sizeof(CRASDSHIFT.CMF_3));
						TRS.add_string(list_item, "CMF_4", CRASDSHIFT.CMF_4, sizeof(CRASDSHIFT.CMF_4));
						TRS.add_string(list_item, "CMF_5", CRASDSHIFT.CMF_5, sizeof(CRASDSHIFT.CMF_5));
					}

					CDB_init_crasdshift(&CRASSFTHIS);
					TRS.copy(CRASSFTHIS.FACTORY, sizeof(CRASSFTHIS.FACTORY), in_node, "FACTORY");
					TRS.copy(CRASSFTHIS.WORK_DATE, sizeof(CRASSFTHIS.WORK_DATE), in_node, "WORK_DATE"); 
					TRS.copy(CRASSFTHIS.WORK_SHIFT, sizeof(CRASSFTHIS.WORK_SHIFT), in_node, "WORK_SHIFT"); 
					TRS.copy(CRASSFTHIS.FACTORY_NO, sizeof(CRASSFTHIS.FACTORY_NO), in_node, "LINE_LOCATION");
					CDB_select_crassfthis(1, &CRASSFTHIS);
					if(DB_error_code == DB_SUCCESS)
					{
						TRS.add_string(out_node, "SHIFT_COMMENT", CRASSFTHIS.SHIFT_COMMENT, sizeof(CRASSFTHIS.SHIFT_COMMENT));
					}
			}
	}
	else
	{
		list_item = TRS.add_node(out_node, "CRASDSHIFT_LIST");
		if ( strcmp( TRS.get_string( in_node, "LINE_LOCATION" ), "E1" ) == 0 ) 
		{
			TRS.add_string(list_item, "LINE_ID", "MDL01", strlen("MDL01"));
			list_item = TRS.add_node(out_node, "CRASDSHIFT_LIST");
			TRS.add_string(list_item, "LINE_ID", "MDL02", strlen("MDL02"));
			list_item = TRS.add_node(out_node, "CRASDSHIFT_LIST");
			TRS.add_string(list_item, "LINE_ID", "MDL03", strlen("MDL03"));
		} else if (strcmp( TRS.get_string( in_node, "LINE_LOCATION" ), "E2" ) == 0)
		{
			//Add by E23
			TRS.add_string(list_item, "LINE_ID", "MDL04", strlen("MDL04"));
			list_item = TRS.add_node(out_node, "CRASDSHIFT_LIST");
			TRS.add_string(list_item, "LINE_ID", "MDL05", strlen("MDL05"));
			list_item = TRS.add_node(out_node, "CRASDSHIFT_LIST");
			TRS.add_string(list_item, "LINE_ID", "MDL06", strlen("MDL06"));
			list_item = TRS.add_node(out_node, "CRASDSHIFT_LIST");
			TRS.add_string(list_item, "LINE_ID", "MDL07", strlen("MDL07"));
		}

	}



    /* Not use in customizing
    if(COM_proc_user_routine("CRAS", "CRAS_View_Crasdshift_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

