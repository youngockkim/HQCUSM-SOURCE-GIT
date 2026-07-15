/******************************************************************************'

	System      : MESplus
	Module      : CMDM
	File Name   : CMDM_update_xlink_data_list.c
	Description : Update XLink Data List

    MES Version : 5.3.6.4

	Function List  
		- CMDM_Update_XLink_Data_List()
			+ Update XLink Data List
		- CMDM_UPDATE_XLINK_DATA_LIST()
			+ Main sub function of CMDM_Update_XLink_Data_List function
			+ Update XLink Data List definition
		- CMDM_Update_XLink_Data_List_Validation()
			+ Main sub function of CMDM_UPDATE_XLINK_DATA_LIST function
			+ Check the condition for View XLink Data List
	Detail Description
		- CMDM_UPDATE_XLINK_DATA_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMDM_Update_XLink_Data_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CMDM_Update_XLink_Data_List()
		- Update XLink Data List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_Update_XLink_Data_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CMDM_UPDATE_XLINK_DATA_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CMDM_UPDATE_XLINK_DATA_LIST", out_node);

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
	CMDM_UPDATE_XLINK_DATA_LIST()
		- Main sub function of "CMDM_Update_XLink_Data_List" function
		- Update XLink Data List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_UPDATE_XLINK_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CMDMXLKDAT_TAG CMDMXLKDAT;

    char s_sys_time[14];
    int i_tran_count;
    int i;

    TRSNode ** Tran_List;

    LOG_head("CMDM_UPDATE_XLINK_DATA_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CMDM_Update_XLink_Data_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
            CDB_init_cmdmxlkdat(&CMDMXLKDAT);
            TRS.copy(CMDMXLKDAT.FACTORY, sizeof(CMDMXLKDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMXLKDAT.CW, sizeof(CMDMXLKDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMXLKDAT.LOT_ID, sizeof(CMDMXLKDAT.LOT_ID), Tran_List[i], "LOT_ID");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_DATE, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), Tran_List[i], "X_LINK_TEST_DATE");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_START_TIME, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), Tran_List[i], "X_LINK_TEST_START_TIME");
            TRS.copy(CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_select_cmdmxlkdat(1,&CMDMXLKDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* Insert */
                    CDB_init_cmdmxlkdat(&CMDMXLKDAT);
                    TRS.copy(CMDMXLKDAT.FACTORY, sizeof(CMDMXLKDAT.FACTORY), in_node, IN_FACTORY);
                    TRS.copy(CMDMXLKDAT.CW, sizeof(CMDMXLKDAT.CW), Tran_List[i], "CW");
                    TRS.copy(CMDMXLKDAT.LOT_ID, sizeof(CMDMXLKDAT.LOT_ID), Tran_List[i], "LOT_ID");
                    TRS.copy(CMDMXLKDAT.MAT_ID, sizeof(CMDMXLKDAT.MAT_ID), Tran_List[i], "MAT_ID");
                    TRS.copy(CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID), Tran_List[i], "LINE_ID");
                    TRS.copy(CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
                    TRS.copy(CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION), Tran_List[i], "POSITION");
                    TRS.copy(CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");
                    TRS.copy(CMDMXLKDAT.X_LINK_TEST_DATE, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), Tran_List[i], "X_LINK_TEST_DATE");
                    TRS.copy(CMDMXLKDAT.X_LINK_TEST_START_TIME, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), Tran_List[i], "X_LINK_TEST_START_TIME");

                    TRS.copy(CMDMXLKDAT.LAMI_DATE, sizeof(CMDMXLKDAT.LAMI_DATE), Tran_List[i], "LAMI_DATE");
                    TRS.copy(CMDMXLKDAT.LAMI_END_TIME, sizeof(CMDMXLKDAT.LAMI_END_TIME), Tran_List[i], "LAMI_END_TIME");
                    TRS.copy(CMDMXLKDAT.BS_TYPE, sizeof(CMDMXLKDAT.BS_TYPE), Tran_List[i], "BS_TYPE");
                    TRS.copy(CMDMXLKDAT.BS_BATCH_NO, sizeof(CMDMXLKDAT.BS_BATCH_NO), Tran_List[i], "BS_BATCH_NO");
                    TRS.copy(CMDMXLKDAT.EVA_TYPE, sizeof(CMDMXLKDAT.EVA_TYPE), Tran_List[i], "EVA_TYPE");
                    TRS.copy(CMDMXLKDAT.EVA_BATCH_NO, sizeof(CMDMXLKDAT.EVA_BATCH_NO), Tran_List[i], "EVA_BATCH_NO");
                    TRS.copy(CMDMXLKDAT.LAMI_RECIPE, sizeof(CMDMXLKDAT.LAMI_RECIPE), Tran_List[i], "LAMI_RECIPE");
                    TRS.copy(CMDMXLKDAT.REPEAT_MEASURE_NO, sizeof(CMDMXLKDAT.REPEAT_MEASURE_NO), Tran_List[i], "REPEAT_MEASURE_NO");
                    TRS.copy(CMDMXLKDAT.CORRELATION_FILE, sizeof(CMDMXLKDAT.CORRELATION_FILE), Tran_List[i], "CORRELATION_FILE");

                    CMDMXLKDAT.LXM_X1_Y1 = TRS.get_double(Tran_List[i], "LXM_X1_Y1");
                    CMDMXLKDAT.LXM_X1_Y2 = TRS.get_double(Tran_List[i], "LXM_X1_Y2");
                    CMDMXLKDAT.LXM_X2_Y1 = TRS.get_double(Tran_List[i], "LXM_X2_Y1");
                    CMDMXLKDAT.LXM_X2_Y2 = TRS.get_double(Tran_List[i], "LXM_X2_Y2");
                    CMDMXLKDAT.LXM_X3_Y1 = TRS.get_double(Tran_List[i], "LXM_X3_Y1");
                    CMDMXLKDAT.LXM_X3_Y2 = TRS.get_double(Tran_List[i], "LXM_X3_Y2");
                    CMDMXLKDAT.LXM_X4_Y1 = TRS.get_double(Tran_List[i], "LXM_X4_Y1");
                    CMDMXLKDAT.LXM_X4_Y2 = TRS.get_double(Tran_List[i], "LXM_X4_Y2");
                    CMDMXLKDAT.LXM_X5_Y1 = TRS.get_double(Tran_List[i], "LXM_X5_Y1");
                    CMDMXLKDAT.LXM_X5_Y2 = TRS.get_double(Tran_List[i], "LXM_X5_Y2");

                    CMDMXLKDAT.GC_X1_Y1 = TRS.get_double(Tran_List[i], "GC_X1_Y1");
                    CMDMXLKDAT.GC_X1_Y2 = TRS.get_double(Tran_List[i], "GC_X1_Y2");
                    CMDMXLKDAT.GC_X2_Y1 = TRS.get_double(Tran_List[i], "GC_X2_Y1");
                    CMDMXLKDAT.GC_X2_Y2 = TRS.get_double(Tran_List[i], "GC_X2_Y2");
                    CMDMXLKDAT.GC_X3_Y1 = TRS.get_double(Tran_List[i], "GC_X3_Y1");
                    CMDMXLKDAT.GC_X3_Y2 = TRS.get_double(Tran_List[i], "GC_X3_Y2");
                    CMDMXLKDAT.GC_X4_Y1 = TRS.get_double(Tran_List[i], "GC_X4_Y1");
                    CMDMXLKDAT.GC_X4_Y2 = TRS.get_double(Tran_List[i], "GC_X4_Y2");
                    CMDMXLKDAT.GC_X5_Y1 = TRS.get_double(Tran_List[i], "GC_X5_Y1");
                    CMDMXLKDAT.GC_X5_Y2 = TRS.get_double(Tran_List[i], "GC_X5_Y2");

                    TRS.copy(CMDMXLKDAT.DATA_COMMENT, sizeof(CMDMXLKDAT.DATA_COMMENT), Tran_List[i], "DATA_COMMENT");
                    TRS.copy(CMDMXLKDAT.CREATE_USER_ID, sizeof(CMDMXLKDAT.CREATE_USER_ID), in_node, IN_USERID);
                    memcpy(CMDMXLKDAT.CREATE_TIME, s_sys_time, sizeof(CMDMXLKDAT.CREATE_TIME));

                    CDB_insert_cmdmxlkdat(&CMDMXLKDAT);
                    if(DB_error_code != DB_SUCCESS)
                    {
                        strcpy(s_msg_code, "MDM-0004");
                        TRS.add_fieldmsg(out_node, "CMDMXLKDAT INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                        TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CMDMXLKDAT.MAT_ID), CMDMXLKDAT.MAT_ID);
                        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                        TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                        TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                        TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);
                        TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                        TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                        TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMXLKDAT.CREATE_USER_ID), CMDMXLKDAT.CREATE_USER_ID);
                        TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMXLKDAT.CREATE_TIME), CMDMXLKDAT.CREATE_TIME);

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
                    TRS.add_fieldmsg(out_node, "CMDMXLKDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

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
                TRS.add_fieldmsg(out_node, "CMDMXLKDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else if (TRS.get_procstep(in_node) == MP_STEP_UPDATE)
        {
            CDB_init_cmdmxlkdat(&CMDMXLKDAT);
            TRS.copy(CMDMXLKDAT.FACTORY, sizeof(CMDMXLKDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMXLKDAT.CW, sizeof(CMDMXLKDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMXLKDAT.LOT_ID, sizeof(CMDMXLKDAT.LOT_ID), Tran_List[i], "LOT_ID");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_DATE, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), Tran_List[i], "X_LINK_TEST_DATE");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_START_TIME, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), Tran_List[i], "X_LINK_TEST_START_TIME");
            TRS.copy(CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_select_cmdmxlkdat(1,&CMDMXLKDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* There are no data to update */
                    strcpy(s_msg_code, "MDM-0006");
                    TRS.add_fieldmsg(out_node, "CMDMXLKDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                else 
                {            
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMXLKDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

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
                TRS.copy(CMDMXLKDAT.MAT_ID, sizeof(CMDMXLKDAT.MAT_ID), Tran_List[i], "MAT_ID");
                TRS.copy(CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID), Tran_List[i], "LINE_ID");
                TRS.copy(CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
                TRS.copy(CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION), Tran_List[i], "POSITION");
                TRS.copy(CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");
                TRS.copy(CMDMXLKDAT.LAMI_DATE, sizeof(CMDMXLKDAT.LAMI_DATE), Tran_List[i], "LAMI_DATE");
                TRS.copy(CMDMXLKDAT.LAMI_END_TIME, sizeof(CMDMXLKDAT.LAMI_END_TIME), Tran_List[i], "LAMI_END_TIME");
                TRS.copy(CMDMXLKDAT.BS_TYPE, sizeof(CMDMXLKDAT.BS_TYPE), Tran_List[i], "BS_TYPE");
                TRS.copy(CMDMXLKDAT.BS_BATCH_NO, sizeof(CMDMXLKDAT.BS_BATCH_NO), Tran_List[i], "BS_BATCH_NO");
                TRS.copy(CMDMXLKDAT.EVA_TYPE, sizeof(CMDMXLKDAT.EVA_TYPE), Tran_List[i], "EVA_TYPE");
                TRS.copy(CMDMXLKDAT.EVA_BATCH_NO, sizeof(CMDMXLKDAT.EVA_BATCH_NO), Tran_List[i], "EVA_BATCH_NO");
                TRS.copy(CMDMXLKDAT.LAMI_RECIPE, sizeof(CMDMXLKDAT.LAMI_RECIPE), Tran_List[i], "LAMI_RECIPE");
                TRS.copy(CMDMXLKDAT.REPEAT_MEASURE_NO, sizeof(CMDMXLKDAT.REPEAT_MEASURE_NO), Tran_List[i], "REPEAT_MEASURE_NO");
                TRS.copy(CMDMXLKDAT.CORRELATION_FILE, sizeof(CMDMXLKDAT.CORRELATION_FILE), Tran_List[i], "CORRELATION_FILE");

                CMDMXLKDAT.LXM_X1_Y1 = TRS.get_double(Tran_List[i], "LXM_X1_Y1");
                CMDMXLKDAT.LXM_X1_Y2 = TRS.get_double(Tran_List[i], "LXM_X1_Y2");
                CMDMXLKDAT.LXM_X2_Y1 = TRS.get_double(Tran_List[i], "LXM_X2_Y1");
                CMDMXLKDAT.LXM_X2_Y2 = TRS.get_double(Tran_List[i], "LXM_X2_Y2");
                CMDMXLKDAT.LXM_X3_Y1 = TRS.get_double(Tran_List[i], "LXM_X3_Y1");
                CMDMXLKDAT.LXM_X3_Y2 = TRS.get_double(Tran_List[i], "LXM_X3_Y2");
                CMDMXLKDAT.LXM_X4_Y1 = TRS.get_double(Tran_List[i], "LXM_X4_Y1");
                CMDMXLKDAT.LXM_X4_Y2 = TRS.get_double(Tran_List[i], "LXM_X4_Y2");
                CMDMXLKDAT.LXM_X5_Y1 = TRS.get_double(Tran_List[i], "LXM_X5_Y1");
                CMDMXLKDAT.LXM_X5_Y2 = TRS.get_double(Tran_List[i], "LXM_X5_Y2");

                CMDMXLKDAT.GC_X1_Y1 = TRS.get_double(Tran_List[i], "GC_X1_Y1");
                CMDMXLKDAT.GC_X1_Y2 = TRS.get_double(Tran_List[i], "GC_X1_Y2");
                CMDMXLKDAT.GC_X2_Y1 = TRS.get_double(Tran_List[i], "GC_X2_Y1");
                CMDMXLKDAT.GC_X2_Y2 = TRS.get_double(Tran_List[i], "GC_X2_Y2");
                CMDMXLKDAT.GC_X3_Y1 = TRS.get_double(Tran_List[i], "GC_X3_Y1");
                CMDMXLKDAT.GC_X3_Y2 = TRS.get_double(Tran_List[i], "GC_X3_Y2");
                CMDMXLKDAT.GC_X4_Y1 = TRS.get_double(Tran_List[i], "GC_X4_Y1");
                CMDMXLKDAT.GC_X4_Y2 = TRS.get_double(Tran_List[i], "GC_X4_Y2");
                CMDMXLKDAT.GC_X5_Y1 = TRS.get_double(Tran_List[i], "GC_X5_Y1");
                CMDMXLKDAT.GC_X5_Y2 = TRS.get_double(Tran_List[i], "GC_X5_Y2");

                TRS.copy(CMDMXLKDAT.DATA_COMMENT, sizeof(CMDMXLKDAT.DATA_COMMENT), Tran_List[i], "DATA_COMMENT");
                TRS.copy(CMDMXLKDAT.UPDATE_USER_ID, sizeof(CMDMXLKDAT.UPDATE_USER_ID), in_node, IN_USERID);
                memcpy(CMDMXLKDAT.UPDATE_TIME, s_sys_time, sizeof(CMDMXLKDAT.UPDATE_TIME));

                CDB_update_cmdmxlkdat(1,&CMDMXLKDAT);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMXLKDAT UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                    TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CMDMXLKDAT.MAT_ID), CMDMXLKDAT.MAT_ID);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMXLKDAT.CREATE_USER_ID), CMDMXLKDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMXLKDAT.CREATE_TIME), CMDMXLKDAT.CREATE_TIME);

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
            CDB_init_cmdmxlkdat(&CMDMXLKDAT);
            TRS.copy(CMDMXLKDAT.FACTORY, sizeof(CMDMXLKDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMXLKDAT.CW, sizeof(CMDMXLKDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMXLKDAT.LOT_ID, sizeof(CMDMXLKDAT.LOT_ID), Tran_List[i], "LOT_ID");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_DATE, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), Tran_List[i], "X_LINK_TEST_DATE");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_START_TIME, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), Tran_List[i], "X_LINK_TEST_START_TIME");
            TRS.copy(CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_select_cmdmxlkdat(1,&CMDMXLKDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* There are no data to delete */
                    strcpy(s_msg_code, "MDM-0007");
                    TRS.add_fieldmsg(out_node, "CMDMXLKDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                else 
                {            
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMXLKDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                    TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                    TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                    TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }

            CDB_init_cmdmxlkdat(&CMDMXLKDAT);
            TRS.copy(CMDMXLKDAT.FACTORY, sizeof(CMDMXLKDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMXLKDAT.CW, sizeof(CMDMXLKDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMXLKDAT.LOT_ID, sizeof(CMDMXLKDAT.LOT_ID), Tran_List[i], "LOT_ID");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_DATE, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), Tran_List[i], "X_LINK_TEST_DATE");
            TRS.copy(CMDMXLKDAT.X_LINK_TEST_START_TIME, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), Tran_List[i], "X_LINK_TEST_START_TIME");
            TRS.copy(CMDMXLKDAT.LINE_ID, sizeof(CMDMXLKDAT.LINE_ID), Tran_List[i], "LINE_ID");
            TRS.copy(CMDMXLKDAT.MACHINE_NO, sizeof(CMDMXLKDAT.MACHINE_NO), Tran_List[i], "MACHINE_NO");
            TRS.copy(CMDMXLKDAT.POSITION, sizeof(CMDMXLKDAT.POSITION), Tran_List[i], "POSITION");
            TRS.copy(CMDMXLKDAT.MEASURE_TYPE, sizeof(CMDMXLKDAT.MEASURE_TYPE), Tran_List[i], "MEASURE_TYPE");

            CDB_delete_cmdmxlkdat(1,&CMDMXLKDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "MDM-0004");
                TRS.add_fieldmsg(out_node, "CMDMXLKDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMXLKDAT.FACTORY), CMDMXLKDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMXLKDAT.CW), CMDMXLKDAT.CW);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CMDMXLKDAT.LOT_ID), CMDMXLKDAT.LOT_ID);
                TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_DATE), CMDMXLKDAT.X_LINK_TEST_DATE);
                TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, sizeof(CMDMXLKDAT.X_LINK_TEST_START_TIME), CMDMXLKDAT.X_LINK_TEST_START_TIME);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CMDMXLKDAT.LINE_ID), CMDMXLKDAT.LINE_ID);
                TRS.add_fieldmsg(out_node, "MACHINE_NO", MP_STR, sizeof(CMDMXLKDAT.MACHINE_NO), CMDMXLKDAT.MACHINE_NO);
                TRS.add_fieldmsg(out_node, "POSITION", MP_STR, sizeof(CMDMXLKDAT.POSITION), CMDMXLKDAT.POSITION);
                TRS.add_fieldmsg(out_node, "MEASURE_TYPE", MP_STR, sizeof(CMDMXLKDAT.MEASURE_TYPE), CMDMXLKDAT.MEASURE_TYPE);

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
	CMDM_Update_XLink_Data_List_Validation()
		- Main sub function of "CMDM_UPDATE_XLINK_DATA_LIST" function
		- Check the condition for Update XLink Data List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_Update_XLink_Data_List_Validation(char *s_msg_code,
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
        if(COM_isnullspace(TRS.get_string(Tran_List[i], "CW")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0009");
            TRS.add_fieldmsg(out_node, "CW", MP_STR, strlen(TRS.get_string(in_node, "CW")), TRS.get_string(in_node, "CW"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "LOT_ID")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0012");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(TRS.get_string(in_node, "LOT_ID")), TRS.get_string(in_node, "LOT_ID"));

            gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "MAT_ID")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0019");
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, strlen(TRS.get_string(in_node, "MAT_ID")), TRS.get_string(in_node, "MAT_ID"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "X_LINK_TEST_DATE")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0013");
            TRS.add_fieldmsg(out_node, "X_LINK_TEST_DATE", MP_STR, strlen(TRS.get_string(in_node, "X_LINK_TEST_DATE")), TRS.get_string(in_node, "X_LINK_TEST_DATE"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "X_LINK_TEST_START_TIME")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0014");
            TRS.add_fieldmsg(out_node, "X_LINK_TEST_START_TIME", MP_STR, strlen(TRS.get_string(in_node, "X_LINK_TEST_START_TIME")), TRS.get_string(in_node, "X_LINK_TEST_START_TIME"));

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