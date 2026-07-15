/******************************************************************************'

	System      : MESplus
	Module      : CMDM
	File Name   : CMDM_update_reference_sample_data_list.c
	Description : Update Reference Sample Data List

    MES Version : 5.3.6.4

	Function List  
		- CMDM_Update_Reference_Sample_Data_List()
			+ Update Reference Sample Data List
		- CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST()
			+ Main sub function of CMDM_Update_Reference_Sample_Data_List function
			+ Update Reference Sample Data List definition
		- CMDM_Update_Reference_Sample_Data_List_Validation()
			+ Main sub function of CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST function
			+ Check the condition for View XLink Data List
	Detail Description
		- CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMDM_Update_Reference_Sample_Data_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CMDM_Update_Reference_Sample_Data_List()
		- Update Reference Sample Data List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_Update_Reference_Sample_Data_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST", out_node);

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
	CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST()
		- Main sub function of "CMDM_Update_Reference_Sample_Data_List" function
		- Update Reference Sample Data List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CMDMREFDAT_TAG CMDMREFDAT;

    char s_sys_time[14];
    int i_tran_count;
    int i;

    TRSNode ** Tran_List;

    LOG_head("CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CMDM_Update_Reference_Sample_Data_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
            CDB_init_cmdmrefdat(&CMDMREFDAT);
            TRS.copy(CMDMREFDAT.FACTORY, sizeof(CMDMREFDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMREFDAT.CW, sizeof(CMDMREFDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMREFDAT.X_LINK_NO, sizeof(CMDMREFDAT.X_LINK_NO), Tran_List[i], "X_LINK_NO");
            TRS.copy(CMDMREFDAT.TEST_DATE, sizeof(CMDMREFDAT.TEST_DATE), Tran_List[i], "TEST_DATE");

            CDB_select_cmdmrefdat(1,&CMDMREFDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* Insert */
                    CDB_init_cmdmrefdat(&CMDMREFDAT);
                    TRS.copy(CMDMREFDAT.FACTORY, sizeof(CMDMREFDAT.FACTORY), in_node, IN_FACTORY);
                    TRS.copy(CMDMREFDAT.CW, sizeof(CMDMREFDAT.CW), Tran_List[i], "CW");
                    TRS.copy(CMDMREFDAT.X_LINK_NO, sizeof(CMDMREFDAT.X_LINK_NO), Tran_List[i], "X_LINK_NO");
                    TRS.copy(CMDMREFDAT.TEST_DATE, sizeof(CMDMREFDAT.TEST_DATE), Tran_List[i], "TEST_DATE");

                    CMDMREFDAT.POINT1_LXM = TRS.get_double(Tran_List[i], "POINT1_LXM");
                    CMDMREFDAT.POINT1_GC = TRS.get_double(Tran_List[i], "POINT1_GC");
                    CMDMREFDAT.POINT2_LXM = TRS.get_double(Tran_List[i], "POINT2_LXM");
                    CMDMREFDAT.POINT2_GC = TRS.get_double(Tran_List[i], "POINT2_GC");

                    TRS.copy(CMDMREFDAT.DATA_COMMENT, sizeof(CMDMREFDAT.DATA_COMMENT), Tran_List[i], "DATA_COMMENT");
                    TRS.copy(CMDMREFDAT.CREATE_USER_ID, sizeof(CMDMREFDAT.CREATE_USER_ID), in_node, IN_USERID);
                    memcpy(CMDMREFDAT.CREATE_TIME, s_sys_time, sizeof(CMDMREFDAT.CREATE_TIME));

                    CDB_insert_cmdmrefdat(&CMDMREFDAT);
                    if(DB_error_code != DB_SUCCESS)
                    {
                        strcpy(s_msg_code, "MDM-0004");
                        TRS.add_fieldmsg(out_node, "CMDMREFDAT INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                        TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                        TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                        TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);
                        TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMREFDAT.CREATE_USER_ID), CMDMREFDAT.CREATE_USER_ID);
                        TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMREFDAT.CREATE_TIME), CMDMREFDAT.CREATE_TIME);

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
                    TRS.add_fieldmsg(out_node, "CMDMREFDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                    TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMREFDAT.CREATE_USER_ID), CMDMREFDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMREFDAT.CREATE_TIME), CMDMREFDAT.CREATE_TIME);

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
                TRS.add_fieldmsg(out_node, "CMDMREFDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);
                TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMREFDAT.CREATE_USER_ID), CMDMREFDAT.CREATE_USER_ID);
                TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMREFDAT.CREATE_TIME), CMDMREFDAT.CREATE_TIME);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else if (TRS.get_procstep(in_node) == MP_STEP_UPDATE)
        {
            CDB_init_cmdmrefdat(&CMDMREFDAT);
            TRS.copy(CMDMREFDAT.FACTORY, sizeof(CMDMREFDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMREFDAT.CW, sizeof(CMDMREFDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMREFDAT.X_LINK_NO, sizeof(CMDMREFDAT.X_LINK_NO), Tran_List[i], "X_LINK_NO");
            TRS.copy(CMDMREFDAT.TEST_DATE, sizeof(CMDMREFDAT.TEST_DATE), Tran_List[i], "TEST_DATE");

            CDB_select_cmdmrefdat(1,&CMDMREFDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* There are no data to update */
                    strcpy(s_msg_code, "MDM-0006");
                    TRS.add_fieldmsg(out_node, "CMDMREFDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                    TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMREFDAT.CREATE_USER_ID), CMDMREFDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMREFDAT.CREATE_TIME), CMDMREFDAT.CREATE_TIME);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                else 
                {            
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMREFDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                    TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMREFDAT.CREATE_USER_ID), CMDMREFDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMREFDAT.CREATE_TIME), CMDMREFDAT.CREATE_TIME);

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
                CMDMREFDAT.POINT1_LXM = TRS.get_double(Tran_List[i], "POINT1_LXM");
                CMDMREFDAT.POINT1_GC = TRS.get_double(Tran_List[i], "POINT1_GC");
                CMDMREFDAT.POINT2_LXM = TRS.get_double(Tran_List[i], "POINT2_LXM");
                CMDMREFDAT.POINT2_GC = TRS.get_double(Tran_List[i], "POINT2_GC");

                TRS.copy(CMDMREFDAT.DATA_COMMENT, sizeof(CMDMREFDAT.DATA_COMMENT), Tran_List[i], "DATA_COMMENT");

                TRS.copy(CMDMREFDAT.UPDATE_USER_ID, sizeof(CMDMREFDAT.UPDATE_USER_ID), in_node, IN_USERID);
                memcpy(CMDMREFDAT.UPDATE_TIME, s_sys_time, sizeof(CMDMREFDAT.UPDATE_TIME));

                CDB_update_cmdmrefdat(1,&CMDMREFDAT);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMREFDAT UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                    TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);
                    TRS.add_fieldmsg(out_node, "UPDATE_USER_ID", MP_STR, sizeof(CMDMREFDAT.UPDATE_USER_ID), CMDMREFDAT.UPDATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "UPDATE_TIME", MP_STR, sizeof(CMDMREFDAT.UPDATE_TIME), CMDMREFDAT.UPDATE_TIME);
                    TRS.add_fieldmsg(out_node, "CREATE_USER_ID", MP_STR, sizeof(CMDMREFDAT.CREATE_USER_ID), CMDMREFDAT.CREATE_USER_ID);
                    TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CMDMREFDAT.CREATE_TIME), CMDMREFDAT.CREATE_TIME);

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
            CDB_init_cmdmrefdat(&CMDMREFDAT);
            TRS.copy(CMDMREFDAT.FACTORY, sizeof(CMDMREFDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMREFDAT.CW, sizeof(CMDMREFDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMREFDAT.X_LINK_NO, sizeof(CMDMREFDAT.X_LINK_NO), Tran_List[i], "X_LINK_NO");
            TRS.copy(CMDMREFDAT.TEST_DATE, sizeof(CMDMREFDAT.TEST_DATE), Tran_List[i], "TEST_DATE");

            CDB_select_cmdmrefdat(1,&CMDMREFDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* There are no data to delete */
                    strcpy(s_msg_code, "MDM-0007");
                    TRS.add_fieldmsg(out_node, "CMDMREFDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                    TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
                else 
                {            
                    strcpy(s_msg_code, "MDM-0004");
                    TRS.add_fieldmsg(out_node, "CMDMREFDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                    TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                    TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }

            CDB_init_cmdmrefdat(&CMDMREFDAT);
            TRS.copy(CMDMREFDAT.FACTORY, sizeof(CMDMREFDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CMDMREFDAT.CW, sizeof(CMDMREFDAT.CW), Tran_List[i], "CW");
            TRS.copy(CMDMREFDAT.X_LINK_NO, sizeof(CMDMREFDAT.X_LINK_NO), Tran_List[i], "X_LINK_NO");
            TRS.copy(CMDMREFDAT.TEST_DATE, sizeof(CMDMREFDAT.TEST_DATE), Tran_List[i], "TEST_DATE");

            CDB_delete_cmdmrefdat(1,&CMDMREFDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "MDM-0004");
                TRS.add_fieldmsg(out_node, "CMDMREFDAT SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMDMREFDAT.FACTORY), CMDMREFDAT.FACTORY);
                TRS.add_fieldmsg(out_node, "CW", MP_STR, sizeof(CMDMREFDAT.CW), CMDMREFDAT.CW);
                TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, sizeof(CMDMREFDAT.X_LINK_NO), CMDMREFDAT.X_LINK_NO);
                TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, sizeof(CMDMREFDAT.TEST_DATE), CMDMREFDAT.TEST_DATE);

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
	CMDM_Update_Reference_Sample_Data_List_Validation()
		- Main sub function of "CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST" function
		- Check the condition for Update Reference Sample Data List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMDM_Update_Reference_Sample_Data_List_Validation(char *s_msg_code,
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

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "X_LINK_NO")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0010");
            TRS.add_fieldmsg(out_node, "X_LINK_NO", MP_STR, strlen(TRS.get_string(in_node, "X_LINK_NO")), TRS.get_string(in_node, "X_LINK_NO"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }

        if(COM_isnullspace(TRS.get_string(Tran_List[i], "TEST_DATE")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "MDM-0011");
            TRS.add_fieldmsg(out_node, "TEST_DATE", MP_STR, strlen(TRS.get_string(in_node, "TEST_DATE")), TRS.get_string(in_node, "TEST_DATE"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }
    }

    return MP_TRUE;
}