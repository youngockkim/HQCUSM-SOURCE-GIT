/******************************************************************************'

	System      : MESplus
	Module      : CMDM
	File Name   : CMDM_update_eva_to_backsheet_data_list.c
	Description : Update EVA to Backsheet Data List

    MES Version : 5.3.6.4

	Function List  
		- CMDM_Update_EVA_To_Backsheet_Data_List()
			+ Update EVA to Backsheet Data List
		- CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST()
			+ Main sub function of CMDM_Update_EVA_To_Backsheet_Data_List function
			+ Update EVA to Backsheet Data List definition
		- CMDM_Update_EVA_To_Backsheet_Data_List_Validation()
			+ Main sub function of CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST function
			+ Check the condition for View EVA to Backsheet Data List
	Detail Description
		- CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMDM_Update_EVA_To_Backsheet_Data_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CMDM_Update_EVA_To_Backsheet_Data_List()
		- Update EVA to Backsheet Data List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_Update_EVA_To_Backsheet_Data_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST", out_node);

	if (i_ret == MP_TRUE)
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
	CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST()
		- Main sub function of "CMDM_Update_EVA_To_Backsheet_Data_List" function
		- Update EVA to Backsheet Data List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CMDMETBDAT_TAG CMDMETBDAT;

    char s_sys_time[14];
    int i_tran_count;
    int i;

    TRSNode ** Tran_List;

    LOG_head("CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CMDM_Update_EVA_To_Backsheet_Data_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_sys_time, ' ', sizeof(s_sys_time));
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

    Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

    for(i = 0; i < i_tran_count; i++)
    {
        if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
            CDB_init_cmdmetbdat(&CMDMETBDAT);
            TRS.copy(CMDMETBDAT.FACTORY, sizeof(CMDMETBDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMETBDAT.CW, sizeof(CMDMETBDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMETBDAT.SAMPLING_DATE, sizeof(CMDMETBDAT.SAMPLING_DATE), Tran_List[i], "SAMPLING_DATE");
            TRS.copy(CMDMETBDAT.TEST_DATE, sizeof(CMDMETBDAT.TEST_DATE), Tran_List[i], "TEST_DATE");
            TRS.copy(CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMETBDAT.MACHINE_NO, sizeof(CMDMETBDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMETBDAT.POSITION, sizeof(CMDMETBDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMETBDAT.MEASURE_TYPE, sizeof(CMDMETBDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_select_cmdmetbdat(1,&CMDMETBDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* Insert */
                    CDB_init_cmdmetbdat(&CMDMETBDAT);
                    TRS.copy(CMDMETBDAT.FACTORY, sizeof(CMDMETBDAT.FACTORY), in_node, IN_FACTORY);
                    TRS.copy(CMDMETBDAT.CW, sizeof(CMDMETBDAT.CW), Tran_List[i], "CW");
                    TRS.copy(CMDMETBDAT.SAMPLING_DATE, sizeof(CMDMETBDAT.SAMPLING_DATE), Tran_List[i], "SAMPLING_DATE");
                    TRS.copy(CMDMETBDAT.TEST_DATE, sizeof(CMDMETBDAT.TEST_DATE), Tran_List[i], "TEST_DATE");
                    TRS.copy(CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID), Tran_List[i], "LINE_ID");
                    TRS.copy(CMDMETBDAT.MACHINE_NO, sizeof(CMDMETBDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
                    TRS.copy(CMDMETBDAT.POSITION, sizeof(CMDMETBDAT.POSITION), Tran_List[i], "POSITION");
                    TRS.copy(CMDMETBDAT.MEASURE_TYPE, sizeof(CMDMETBDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

                    TRS.copy(CMDMETBDAT.TYPE_EVA_BACK, sizeof(CMDMETBDAT.TYPE_EVA_BACK), Tran_List[i], "TYPE_EVA_BACK");
                    TRS.copy(CMDMETBDAT.GRN_NR_EVA_BACK, sizeof(CMDMETBDAT.GRN_NR_EVA_BACK), Tran_List[i], "GRN_NR_EVA_BACK");
                    TRS.copy(CMDMETBDAT.BACKSHEET_TYPE, sizeof(CMDMETBDAT.BACKSHEET_TYPE), Tran_List[i], "BACKSHEET_TYPE");
                    TRS.copy(CMDMETBDAT.GRN_NR_BACKSHEET, sizeof(CMDMETBDAT.GRN_NR_BACKSHEET), Tran_List[i], "GRN_NR_BACKSHEET");
                    TRS.copy(CMDMETBDAT.REPEAT_MEASURE_NO, sizeof(CMDMETBDAT.REPEAT_MEASURE_NO), Tran_List[i], "REPEAT_MEASURE_NO");

                    CMDMETBDAT.POS_A = TRS.get_double(Tran_List[i], "POS_A");
                    CMDMETBDAT.POS_B = TRS.get_double(Tran_List[i], "POS_B");
                    CMDMETBDAT.POS_C = TRS.get_double(Tran_List[i], "POS_C");
                    CMDMETBDAT.POS_D = TRS.get_double(Tran_List[i], "POS_D");
                    CMDMETBDAT.POS_E = TRS.get_double(Tran_List[i], "POS_E");
                    CMDMETBDAT.POS_F = TRS.get_double(Tran_List[i], "POS_F");
                    CMDMETBDAT.POS_G = TRS.get_double(Tran_List[i], "POS_G");
                    CMDMETBDAT.POS_H = TRS.get_double(Tran_List[i], "POS_H");

                    TRS.copy(CMDMETBDAT.DATA_COMMENT, sizeof(CMDMETBDAT.DATA_COMMENT), Tran_List[i], "DATA_COMMENT");
                    TRS.copy(CMDMETBDAT.CREATE_USER_ID, sizeof(CMDMETBDAT.CREATE_USER_ID), in_node, IN_USERID);
                    memcpy(CMDMETBDAT.CREATE_TIME, s_sys_time, sizeof(CMDMETBDAT.CREATE_TIME));

                    CDB_insert_cmdmetbdat(&CMDMETBDAT);
                    if(DB_error_code != DB_SUCCESS)
                    {
                        strcpy(s_msg_code, "MDM-0004");
                        TRS.add_fieldmsg(out_node, "CMDMETBDAT INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                        TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                        TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                        TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                        TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                        TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                        TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                        TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                        TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                        TRS.add_dberrmsg(out_node,DB_error_msg);

                        gs_log_type.type = MP_LOG_ERROR;
                        gs_log_type.e_type = MP_LOG_E_SYSTEM;
                        gs_log_type.category = MP_LOG_CATE_TRANS;

                        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                        return MP_FALSE;
                    }
                }
                else 
                {            
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMETBDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                    TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }
            else 
            {
                /* Already Created Data */
                strcpy(s_msg_code, "MDM-0005");
                TRS.add_fieldmsg(out_node, "CMDMETBDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else if (TRS.get_procstep(in_node) == MP_STEP_UPDATE)
        {
            CDB_init_cmdmetbdat(&CMDMETBDAT);
            TRS.copy(CMDMETBDAT.FACTORY, sizeof(CMDMETBDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMETBDAT.CW, sizeof(CMDMETBDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMETBDAT.SAMPLING_DATE, sizeof(CMDMETBDAT.SAMPLING_DATE), Tran_List[i], "SAMPLING_DATE");
            TRS.copy(CMDMETBDAT.TEST_DATE, sizeof(CMDMETBDAT.TEST_DATE), Tran_List[i], "TEST_DATE");
            TRS.copy(CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMETBDAT.MACHINE_NO, sizeof(CMDMETBDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMETBDAT.POSITION, sizeof(CMDMETBDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMETBDAT.MEASURE_TYPE, sizeof(CMDMETBDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_select_cmdmetbdat(1,&CMDMETBDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* There are no data to update */
                    strcpy(s_msg_code, "MDM-0006");
                    TRS.add_fieldmsg(out_node, "CMDMETBDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                    TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                else 
                {            
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMETBDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                    TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }
            else 
            {
                /* Update */
                TRS.copy(CMDMETBDAT.TYPE_EVA_BACK, sizeof(CMDMETBDAT.TYPE_EVA_BACK), Tran_List[i], "TYPE_EVA_BACK");
                TRS.copy(CMDMETBDAT.GRN_NR_EVA_BACK, sizeof(CMDMETBDAT.GRN_NR_EVA_BACK), Tran_List[i], "GRN_NR_EVA_BACK");
                TRS.copy(CMDMETBDAT.BACKSHEET_TYPE, sizeof(CMDMETBDAT.BACKSHEET_TYPE), Tran_List[i], "BACKSHEET_TYPE");
                TRS.copy(CMDMETBDAT.GRN_NR_BACKSHEET, sizeof(CMDMETBDAT.GRN_NR_BACKSHEET), Tran_List[i], "GRN_NR_BACKSHEET");
                TRS.copy(CMDMETBDAT.REPEAT_MEASURE_NO, sizeof(CMDMETBDAT.REPEAT_MEASURE_NO), Tran_List[i], "REPEAT_MEASURE_NO");

                CMDMETBDAT.POS_A = TRS.get_double(Tran_List[i], "POS_A");
                CMDMETBDAT.POS_B = TRS.get_double(Tran_List[i], "POS_B");
                CMDMETBDAT.POS_C = TRS.get_double(Tran_List[i], "POS_C");
                CMDMETBDAT.POS_D = TRS.get_double(Tran_List[i], "POS_D");
                CMDMETBDAT.POS_E = TRS.get_double(Tran_List[i], "POS_E");
                CMDMETBDAT.POS_F = TRS.get_double(Tran_List[i], "POS_F");
                CMDMETBDAT.POS_G = TRS.get_double(Tran_List[i], "POS_G");
                CMDMETBDAT.POS_H = TRS.get_double(Tran_List[i], "POS_H");

                TRS.copy(CMDMETBDAT.DATA_COMMENT, sizeof(CMDMETBDAT.DATA_COMMENT), Tran_List[i], "DATA_COMMENT");
                TRS.copy(CMDMETBDAT.UPDATE_USER_ID, sizeof(CMDMETBDAT.UPDATE_USER_ID), in_node, IN_USERID);
                memcpy(CMDMETBDAT.UPDATE_TIME, s_sys_time, sizeof(CMDMETBDAT.UPDATE_TIME));

                CDB_update_cmdmetbdat(1,&CMDMETBDAT);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMETBDAT UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                    TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);
                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                
            }
            
        }
        else if (TRS.get_procstep(in_node) == MP_STEP_DELETE)
        {
            CDB_init_cmdmetbdat(&CMDMETBDAT);
            TRS.copy(CMDMETBDAT.FACTORY, sizeof(CMDMETBDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMETBDAT.CW, sizeof(CMDMETBDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMETBDAT.SAMPLING_DATE, sizeof(CMDMETBDAT.SAMPLING_DATE), Tran_List[i], "SAMPLING_DATE");
            TRS.copy(CMDMETBDAT.TEST_DATE, sizeof(CMDMETBDAT.TEST_DATE), Tran_List[i], "TEST_DATE");
            TRS.copy(CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMETBDAT.MACHINE_NO, sizeof(CMDMETBDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMETBDAT.POSITION, sizeof(CMDMETBDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMETBDAT.MEASURE_TYPE, sizeof(CMDMETBDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_select_cmdmetbdat(1,&CMDMETBDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* There are no data to delete */
                    strcpy(s_msg_code, "MDM-0007");
                    TRS.add_fieldmsg(out_node, "CMDMETBDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                    TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                else 
                {            
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMETBDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                    TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }

            CDB_init_cmdmetbdat(&CMDMETBDAT);
            TRS.copy(CMDMETBDAT.FACTORY, sizeof(CMDMETBDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMETBDAT.CW, sizeof(CMDMETBDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMETBDAT.SAMPLING_DATE, sizeof(CMDMETBDAT.SAMPLING_DATE), Tran_List[i], "SAMPLING_DATE");
            TRS.copy(CMDMETBDAT.TEST_DATE, sizeof(CMDMETBDAT.TEST_DATE), Tran_List[i], "TEST_DATE");
            TRS.copy(CMDMETBDAT.LINE_ID, sizeof(CMDMETBDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMETBDAT.MACHINE_NO, sizeof(CMDMETBDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMETBDAT.POSITION, sizeof(CMDMETBDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMETBDAT.MEASURE_TYPE, sizeof(CMDMETBDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_delete_cmdmetbdat(1,&CMDMETBDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "MDM-0004");
                TRS.add_fieldmsg(out_node, "CMDMETBDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMETBDAT.FACTORY), CMDMETBDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMETBDAT.CW), CMDMETBDAT.CW);
                TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, sizeof(CMDMETBDAT.SAMPLING_DATE), CMDMETBDAT.SAMPLING_DATE);
                TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMETBDAT.TEST_DATE), CMDMETBDAT.TEST_DATE);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMETBDAT.LINE_ID), CMDMETBDAT.LINE_ID);
                TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMETBDAT.MACHINE_NO), CMDMETBDAT.MACHINE_NO);
                TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMETBDAT.POSITION), CMDMETBDAT.POSITION);
                TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMETBDAT.MEASURE_TYPE), CMDMETBDAT.MEASURE_TYPE);
                TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMETBDAT.CREATE_USER_ID), CMDMETBDAT.CREATE_USER_ID);
                TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMETBDAT.CREATE_TIME), CMDMETBDAT.CREATE_TIME);

                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }

        }

    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CMDM_Update_EVA_To_Backsheet_Data_List_Validation()
		- Main sub function of "CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST" function
		- Check the condition for Update EVA to Backsheet Data List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_Update_EVA_To_Backsheet_Data_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    int     i_tran_count;
    int		i;
    TRSNode ** Tran_List;

    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
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

    Tran_List = TRS.get_list(in_node, "TRAN_LIST");
    i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");

    if (i_tran_count < 1)
    {
        /* Please select at least one row */
        strcpy(s_msg_code, "MDM-0008");

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    for(i = 0; i < i_tran_count; i++)
    {
        if(COM_isnullspace(TRS.get_string(Tran_List[i], "SAMPLING_DATE")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0020");
            TRS.add_fieldmsg(out_node, "SAMPLING_DATE", MP_STR, strlen(TRS.get_string(in_node, "SAMPLING_DATE")), TRS.get_string(in_node, "SAMPLING_DATE"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "TEST_DATE")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0021");
            TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, strlen(TRS.get_string(in_node, "TEST_DATE")), TRS.get_string(in_node, "TEST_DATE"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "CW")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0009");
            TRS.add_fieldmsg(out_node, "CW", MP_STR, strlen(TRS.get_string(in_node, "CW")), TRS.get_string(in_node, "CW"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "LINE_ID")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0015");
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, strlen(TRS.get_string(in_node, "LINE_ID")), TRS.get_string(in_node, "LINE_ID"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "MACHINE_NO")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0016");
            TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, strlen(TRS.get_string(in_node, "MACHINE_NO")), TRS.get_string(in_node, "MACHINE_NO"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "POSITION")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0017");
            TRS.add_fieldmsg(out_node, "POSITION", MP_STR, strlen(TRS.get_string(in_node, "POSITION")), TRS.get_string(in_node, "POSITION"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "MEASURE_TYPE")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0018");
            TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, strlen(TRS.get_string(in_node, "MEASURE_TYPE")), TRS.get_string(in_node, "MEASURE_TYPE"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }


    }

    return MP_TRUE;
}