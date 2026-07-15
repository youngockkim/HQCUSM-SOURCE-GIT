/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_xlinktest_list.c
    Description : View Xlinktest List function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_Xlinktest_List()
            + View Xlinktest definition List
        - CRAS_VIEW_XLINKTEST_LIST()
            + Main sub function of CRAS_View_Xlinktest_List function
            + View Xlinktest definition List
    Detail Description
        - CRAS_VIEW_XLINKTEST_LIST()
            + h_proc_step
                + 1 : View Xlinktest definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/04/11             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_Xlinktest_List()
        - View Xlinktest definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Xlinktest_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_XLINKTEST_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_XLINKTEST_LIST", out_node);

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
    CRAS_VIEW_XLINKTEST_LIST()
        - Main sub function of "CRAS_View_Xlinktest_List" function
        - View Xlinktest definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_XLINKTEST_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASXLINKR_TAG CRASXLINKR;
    TRSNode *list_item;

    int i_case;
	int chk_count = 0;
	int i ;
	char i_lami_numer ;
	char i_lami_pos ;


	LOG_head("CRAS_VIEW_XLINKTEST_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


	CDB_init_crasxlinkr(&CRASXLINKR);
    TRS.copy(CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID), in_node, "LINE_ID");
	
	chk_count = (int) CDB_select_crasxlinkr_scalar(2,&CRASXLINKR);

	if(chk_count > 1)	
	{
		CDB_open_crasxlinkr(2, &CRASXLINKR);
		while(1)
		{
			CDB_fetch_crasxlinkr(2, &CRASXLINKR);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_crasxlinkr(2);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
					strcpy(s_msg_code, "RAS-0004");
					TRS.add_fieldmsg(out_node, "CRASXLINKR FETCH", MP_NVST);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASXLINKR.WORK_DATE), CRASXLINKR.WORK_DATE);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASXLINKR.LINE_ID), CRASXLINKR.LINE_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					CDB_close_crasxlinkr(2);
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
			}

			list_item = TRS.add_node(out_node, "CRASXLINKR_LIST");

			//Header of Log 
			TRS.add_string(list_item, "WORK_DATE", CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE));
			TRS.add_string(list_item, "LINE_ID", CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID));
			TRS.add_string(list_item, "TEST_DATE", CRASXLINKR.TEST_DATE, sizeof(CRASXLINKR.TEST_DATE));
			TRS.add_string(list_item, "LAMI_NUMER", CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER));
			TRS.add_string(list_item, "LAMI_POS", CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS));

			//Middle  of Log
			TRS.add_float(list_item, "LX11", CRASXLINKR.LX11);
			TRS.add_float(list_item, "LX12", CRASXLINKR.LX12);
			TRS.add_float(list_item, "LX21", CRASXLINKR.LX21);
			TRS.add_float(list_item, "LX22", CRASXLINKR.LX22);
			TRS.add_float(list_item, "LX31", CRASXLINKR.LX31);
			TRS.add_float(list_item, "LX32", CRASXLINKR.LX32);
			TRS.add_float(list_item, "LX41", CRASXLINKR.LX41);
			TRS.add_float(list_item, "LX42", CRASXLINKR.LX42);
			TRS.add_float(list_item, "LX51", CRASXLINKR.LX51);
			TRS.add_float(list_item, "LX52", CRASXLINKR.LX52);
			TRS.add_float(list_item, "LXTAT1", CRASXLINKR.LXTAT1);
			TRS.add_float(list_item, "LXTAT2", CRASXLINKR.LXTAT2);
			TRS.add_float(list_item, "DX11", CRASXLINKR.DX11);
			TRS.add_float(list_item, "DX12", CRASXLINKR.DX12);
			TRS.add_float(list_item, "DX21", CRASXLINKR.DX21);
			TRS.add_float(list_item, "DX22", CRASXLINKR.DX22);
			TRS.add_float(list_item, "DX31", CRASXLINKR.DX31);
			TRS.add_float(list_item, "DX32", CRASXLINKR.DX32);
			TRS.add_float(list_item, "DX41", CRASXLINKR.DX41);
			TRS.add_float(list_item, "DX42", CRASXLINKR.DX42);
			TRS.add_float(list_item, "DX51", CRASXLINKR.DX51);
			TRS.add_float(list_item, "DX52", CRASXLINKR.DX52);
			TRS.add_float(list_item, "DXTAT1", CRASXLINKR.DXTAT1);
			TRS.add_float(list_item, "DXTAT2", CRASXLINKR.DXTAT2);

			//End of Log
			TRS.add_string(list_item, "CREATE_USER_ID", CRASXLINKR.CREATE_USER_ID, sizeof(CRASXLINKR.CREATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_USER_ID", CRASXLINKR.UPDATE_USER_ID, sizeof(CRASXLINKR.UPDATE_USER_ID));
			TRS.add_string(list_item, "TRAN_TIME", CRASXLINKR.TRAN_TIME, sizeof(CRASXLINKR.TRAN_TIME));
			TRS.add_string(list_item, "UPDATE_TIME", CRASXLINKR.UPDATE_TIME, sizeof(CRASXLINKR.UPDATE_TIME));
			TRS.add_string(list_item, "CMF_1", CRASXLINKR.CMF_1, sizeof(CRASXLINKR.CMF_1));
			TRS.add_string(list_item, "CMF_2", CRASXLINKR.CMF_2, sizeof(CRASXLINKR.CMF_2));
			TRS.add_string(list_item, "CMF_3", CRASXLINKR.CMF_3, sizeof(CRASXLINKR.CMF_3));
			TRS.add_string(list_item, "CMF_4", CRASXLINKR.CMF_4, sizeof(CRASXLINKR.CMF_4));
			TRS.add_string(list_item, "CMF_5", CRASXLINKR.CMF_5, sizeof(CRASXLINKR.CMF_5));
			TRS.add_string(list_item, "CMF_6", CRASXLINKR.CMF_6, sizeof(CRASXLINKR.CMF_6));
			TRS.add_string(list_item, "CMF_7", CRASXLINKR.CMF_7, sizeof(CRASXLINKR.CMF_7));
			TRS.add_string(list_item, "CMF_8", CRASXLINKR.CMF_8, sizeof(CRASXLINKR.CMF_8));
			TRS.add_string(list_item, "CMF_9", CRASXLINKR.CMF_9, sizeof(CRASXLINKR.CMF_9));
			TRS.add_string(list_item, "CMF_10", CRASXLINKR.CMF_10, sizeof(CRASXLINKR.CMF_10));		
		}

	}
	else
	{
		for(i = 0; i < 16; i++)
		{
			list_item = TRS.add_node(out_node, "CRASXLINKR_LIST");

			//Header of Log 
			TRS.add_string(list_item, "WORK_DATE", CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE));
			TRS.add_string(list_item, "LINE_ID", CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID));




			//Middle of Log - LAMI_NUMER
			if(i < 4 )
			{
				TRS.add_string(list_item, "LAMI_NUMER", "1", 1);
			}
			else if(i < 8)
			{
				TRS.add_string(list_item, "LAMI_NUMER", "2", 1);
			}
			else if(i < 12)
			{
				TRS.add_string(list_item, "LAMI_NUMER", "3", 1);
			}

			else if(i > 11)
			{
				TRS.add_string(list_item, "LAMI_NUMER", "4", 1);
			}

			//Middle of Log - LAMI_POS
			if(i ==  0 || i ==  4 ||  i ==  8   ||  i ==  12 )
			{
				TRS.add_string(list_item, "LAMI_POS", "1", 1);
			}

			if(i ==  1 || i ==  5 ||  i ==  9   ||  i ==  13 )
			{
				TRS.add_string(list_item, "LAMI_POS", "2", 1);
			}
			if(i ==  2 || i ==  6 ||  i ==  10   ||  i ==  14 )
			{
				TRS.add_string(list_item, "LAMI_POS", "3", 1);
			}

			if(i ==  3 || i ==  7 ||  i ==  11   ||  i ==  15 )
			{
				TRS.add_string(list_item, "LAMI_POS", "4", 1);
			}


		
		}

	}



    //LOG_head("CRAS_VIEW_XLINKTEST_LIST");
    //LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    //LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    //LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    //LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    //LOG_add("work_date", MP_NSTR, TRS.get_string(in_node, "WORK_DATE"));
    //LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    //LOG_add("lami_numer", MP_NSTR, TRS.get_string(in_node, "LAMI_NUMER"));
    //LOG_add("lami_pos", MP_NSTR, TRS.get_string(in_node, "LAMI_POS"));
    //COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    ///* Not use in customizing
    //if(COM_proc_user_routine("CRAS", "CRAS_View_Xlinktest_List",
    //                         MP_UPOINT_BEFORE,
    //                         in_node,
    //                         out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    //*/

    ///* ProcStep Validation */
    //if(COM_service_validation(s_msg_code,
    //                          in_node,
    //                          out_node,
    //                          TRS.get_procstep(in_node),
    //                          "1") == MP_FALSE)
    //{
    //    return MP_FALSE;
    //}

    ///* WORK_DATE Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* LINE_ID Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* LAMI_NUMER Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LAMI_NUMER")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "LAMI_NUMER", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}
    ///* LAMI_POS Validation */
    //if(COM_isnullspace(TRS.get_string(in_node, "LAMI_POS")) == MP_TRUE)
    //{
    //    strcpy(s_msg_code, "CRAS-0001");
    //    TRS.add_fieldmsg(out_node, "LAMI_POS", MP_NVST);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_VALIDATION;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;
    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}

    //i_case = 1;

    //DBC_init_crasxlinkr(&CRASXLINKR);
    //TRS.copy(CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE), in_node, "WORK_DATE");
    //TRS.copy(CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID), in_node, "LINE_ID");
    //TRS.copy(CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER), in_node, "LAMI_NUMER");
    //TRS.copy(CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS), in_node, "LAMI_POS");
    //TRS.copy(CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE), in_node, "NEXT_WORK_DATE");
    //TRS.copy(CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID), in_node, "NEXT_LINE_ID");
    //TRS.copy(CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER), in_node, "NEXT_LAMI_NUMER");
    //TRS.copy(CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS), in_node, "NEXT_LAMI_POS");
    //DBC_open_crasxlinkr(i_case, &CRASXLINKR);
    //if(DB_error_code != DB_SUCCESS)
    //{
    //    strcpy(s_msg_code, "CRAS-0004");
    //    TRS.add_fieldmsg(out_node, "CRASXLINKR OPEN", MP_NVST);
    //    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASXLINKR.WORK_DATE), CRASXLINKR.WORK_DATE);
    //    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASXLINKR.LINE_ID), CRASXLINKR.LINE_ID);
    //    TRS.add_fieldmsg(out_node, "LAMI_NUMER", MP_STR, sizeof(CRASXLINKR.LAMI_NUMER), CRASXLINKR.LAMI_NUMER);
    //    TRS.add_fieldmsg(out_node, "LAMI_POS", MP_STR, sizeof(CRASXLINKR.LAMI_POS), CRASXLINKR.LAMI_POS);
    //    TRS.add_dberrmsg(out_node, DB_error_msg);

    //    gs_log_type.type = MP_LOG_ERROR;
    //    gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //    gs_log_type.category = MP_LOG_CATE_VIEW;

    //    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //    return MP_FALSE;
    //}


    //while(1)
    //{
    //    DBC_fetch_crasxlinkr(i_case, &CRASXLINKR);
    //    if(DB_error_code == DB_NOT_FOUND)
    //    {
    //        DBC_close_crasxlinkr(i_case);
    //        break;
    //    }
    //    else if(DB_error_code != DB_SUCCESS)
    //    {
    //        strcpy(s_msg_code, "CRAS-0004");
    //        TRS.add_fieldmsg(out_node, "CRASXLINKR FETCH", MP_NVST);
    //        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASXLINKR.WORK_DATE), CRASXLINKR.WORK_DATE);
    //        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASXLINKR.LINE_ID), CRASXLINKR.LINE_ID);
    //        TRS.add_fieldmsg(out_node, "LAMI_NUMER", MP_STR, sizeof(CRASXLINKR.LAMI_NUMER), CRASXLINKR.LAMI_NUMER);
    //        TRS.add_fieldmsg(out_node, "LAMI_POS", MP_STR, sizeof(CRASXLINKR.LAMI_POS), CRASXLINKR.LAMI_POS);
    //        TRS.add_dberrmsg(out_node, DB_error_msg);

    //        gs_log_type.type = MP_LOG_ERROR;
    //        gs_log_type.e_type = MP_LOG_E_SYSTEM;
    //        gs_log_type.category = MP_LOG_CATE_VIEW;

    //        DBC_close_crasxlinkr(i_case);
    //        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
    //        return MP_FALSE;
    //    }

    //    if(COM_check_node_length(out_node) == MP_FALSE)
    //    {
    //        TRS.set_string(out_node, "NEXT_WORK_DATE", CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE));
    //        TRS.set_string(out_node, "NEXT_LINE_ID", CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID));
    //        TRS.set_string(out_node, "NEXT_LAMI_NUMER", CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER));
    //        TRS.set_string(out_node, "NEXT_LAMI_POS", CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS));
    //        DBC_close_crasxlinkr(i_case);
    //        break;
    //    }

    //    list_item = TRS.add_node(out_node, "XLINKTEST_LIST");

    //    TRS.add_string(list_item, "WORK_DATE", CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE));
    //    TRS.add_string(list_item, "LINE_ID", CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID));
    //    TRS.add_string(list_item, "LAMI_NUMER", CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER));
    //    TRS.add_string(list_item, "LAMI_POS", CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS));
    //    TRS.add_string(list_item, "TEST_DATE", CRASXLINKR.TEST_DATE, sizeof(CRASXLINKR.TEST_DATE));
    //    TRS.add_double(list_item, "LX11", CRASXLINKR.LX11);
    //    TRS.add_double(list_item, "LX12", CRASXLINKR.LX12);
    //    TRS.add_double(list_item, "LX21", CRASXLINKR.LX21);
    //    TRS.add_double(list_item, "LX22", CRASXLINKR.LX22);
    //    TRS.add_double(list_item, "LX31", CRASXLINKR.LX31);
    //    TRS.add_double(list_item, "LX32", CRASXLINKR.LX32);
    //    TRS.add_double(list_item, "LX41", CRASXLINKR.LX41);
    //    TRS.add_double(list_item, "LX42", CRASXLINKR.LX42);
    //    TRS.add_double(list_item, "LX51", CRASXLINKR.LX51);
    //    TRS.add_double(list_item, "LX52", CRASXLINKR.LX52);
    //    TRS.add_double(list_item, "LXTAT1", CRASXLINKR.LXTAT1);
    //    TRS.add_double(list_item, "LXTAT2", CRASXLINKR.LXTAT2);
    //    TRS.add_double(list_item, "DX11", CRASXLINKR.DX11);
    //    TRS.add_double(list_item, "DX12", CRASXLINKR.DX12);
    //    TRS.add_double(list_item, "DX21", CRASXLINKR.DX21);
    //    TRS.add_double(list_item, "DX22", CRASXLINKR.DX22);
    //    TRS.add_double(list_item, "DX31", CRASXLINKR.DX31);
    //    TRS.add_double(list_item, "DX32", CRASXLINKR.DX32);
    //    TRS.add_double(list_item, "DX41", CRASXLINKR.DX41);
    //    TRS.add_double(list_item, "DX42", CRASXLINKR.DX42);
    //    TRS.add_double(list_item, "DX51", CRASXLINKR.DX51);
    //    TRS.add_double(list_item, "DX52", CRASXLINKR.DX52);
    //    TRS.add_double(list_item, "DXTAT1", CRASXLINKR.DXTAT1);
    //    TRS.add_double(list_item, "DXTAT2", CRASXLINKR.DXTAT2);
    //    TRS.add_string(list_item, "CREATE_USER_ID", CRASXLINKR.CREATE_USER_ID, sizeof(CRASXLINKR.CREATE_USER_ID));
    //    TRS.add_string(list_item, "TRAN_TIME", CRASXLINKR.TRAN_TIME, sizeof(CRASXLINKR.TRAN_TIME));
    //    TRS.add_string(list_item, "UPDATE_USER_ID", CRASXLINKR.UPDATE_USER_ID, sizeof(CRASXLINKR.UPDATE_USER_ID));
    //    TRS.add_string(list_item, "UPDATE_TIME", CRASXLINKR.UPDATE_TIME, sizeof(CRASXLINKR.UPDATE_TIME));
    //    TRS.add_string(list_item, "CMF_1", CRASXLINKR.CMF_1, sizeof(CRASXLINKR.CMF_1));
    //    TRS.add_string(list_item, "CMF_2", CRASXLINKR.CMF_2, sizeof(CRASXLINKR.CMF_2));
    //    TRS.add_string(list_item, "CMF_3", CRASXLINKR.CMF_3, sizeof(CRASXLINKR.CMF_3));
    //    TRS.add_string(list_item, "CMF_4", CRASXLINKR.CMF_4, sizeof(CRASXLINKR.CMF_4));
    //    TRS.add_string(list_item, "CMF_5", CRASXLINKR.CMF_5, sizeof(CRASXLINKR.CMF_5));
    //    TRS.add_string(list_item, "CMF_6", CRASXLINKR.CMF_6, sizeof(CRASXLINKR.CMF_6));
    //    TRS.add_string(list_item, "CMF_7", CRASXLINKR.CMF_7, sizeof(CRASXLINKR.CMF_7));
    //    TRS.add_string(list_item, "CMF_8", CRASXLINKR.CMF_8, sizeof(CRASXLINKR.CMF_8));
    //    TRS.add_string(list_item, "CMF_9", CRASXLINKR.CMF_9, sizeof(CRASXLINKR.CMF_9));
    //    TRS.add_string(list_item, "CMF_10", CRASXLINKR.CMF_10, sizeof(CRASXLINKR.CMF_10));
    //}

    ///* Not use in customizing
    //if(COM_proc_user_routine("CRAS", "CRAS_View_Xlinktest_List",
    //                         MP_UPOINT_AFTER,
    //                         in_node,
    //                         out_node) == MP_FALSE) return MP_FALSE;
    //*/

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

