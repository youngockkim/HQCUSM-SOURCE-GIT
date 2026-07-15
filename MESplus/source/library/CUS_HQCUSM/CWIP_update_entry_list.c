/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_update_entry.c
    Description : Entry Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Update_Entry_List()
            + Create/Update/Delete Entry definition
        - CWIP_UPDATE_ENTRY_LIST()
            + Main sub function of CWIP_Update_Entry_List function
            + Create/Update/Delete Entry definition
        - CWIP_Update_Entry_List_Validation()
            + Main sub function of CWIP_UPDATE_ENTRY_LIST function
            + Check the condition for create/update/delete Entry
    Detail Description
        - CWIP_UPDATE_ENTRY_LIST()
            + h_proc_step
                + MP_STEP_CREATE : Create Entry definition
                + MP_STEP_UPDATE : Update Entry definition
                + MP_STEP_DELETE : Delete Entry definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-09-07             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Entry_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_Entry_List()
        - Create/Update/Delete Entry definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Entry_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_ENTRY_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_ENTRY_LIST", out_node);

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
    CWIP_UPDATE_ENTRY_LIST()
        - Main sub function of "CWIP_Update_Entry_List" function
        - Create/Update/Delete Entry definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_ENTRY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPTSCLOS_TAG CWIPTSCLOS;
    struct CWIPTSCLOS_TAG CWIPTSCLOS_o;
    char   s_sys_time[14];

	LOG_head("CWIP_UPDATE_ENTRY_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Entry_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */
    
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
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

    if(CWIP_Update_Entry_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cwiptsclos(&CWIPTSCLOS);
    TRS.copy(CWIPTSCLOS.WORK_DATE, sizeof(CWIPTSCLOS.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPTSCLOS.LINE_ID, sizeof(CWIPTSCLOS.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPTSCLOS.WORK_SHIFT, sizeof(CWIPTSCLOS.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPTSCLOS.TABBER, sizeof(CWIPTSCLOS.TABBER), in_node, "TABBER");
    TRS.copy(CWIPTSCLOS.SIDE, sizeof(CWIPTSCLOS.SIDE), in_node, "SIDE");
    TRS.copy(CWIPTSCLOS.TYPE_RECOVERY, sizeof(CWIPTSCLOS.TYPE_RECOVERY), in_node, "TYPE_RECOVERY");
    TRS.copy(CWIPTSCLOS.ADD_COMMENTS, sizeof(CWIPTSCLOS.ADD_COMMENTS), in_node, "ADD_COMMENTS");
    TRS.copy(CWIPTSCLOS.CMF_1, sizeof(CWIPTSCLOS.CMF_1), in_node, "CMF_1");
    TRS.copy(CWIPTSCLOS.CMF_2, sizeof(CWIPTSCLOS.CMF_2), in_node, "CMF_2");
    TRS.copy(CWIPTSCLOS.CMF_3, sizeof(CWIPTSCLOS.CMF_3), in_node, "CMF_3");
    TRS.copy(CWIPTSCLOS.CMF_4, sizeof(CWIPTSCLOS.CMF_4), in_node, "CMF_4");
    TRS.copy(CWIPTSCLOS.CMF_5, sizeof(CWIPTSCLOS.CMF_5), in_node, "CMF_5");
    TRS.copy(CWIPTSCLOS.CREATE_USER_ID, sizeof(CWIPTSCLOS.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CWIPTSCLOS.CREATE_TIME, sizeof(CWIPTSCLOS.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CWIPTSCLOS.UPDATE_USER_ID, sizeof(CWIPTSCLOS.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CWIPTSCLOS.UPDATE_TIME, sizeof(CWIPTSCLOS.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----
		CDB_init_cwiptsclos(&CWIPTSCLOS_o);
        TRS.copy(CWIPTSCLOS_o.WORK_DATE, sizeof(CWIPTSCLOS_o.WORK_DATE), in_node, "WORK_DATE");
        TRS.copy(CWIPTSCLOS_o.LINE_ID, sizeof(CWIPTSCLOS_o.LINE_ID), in_node, "LINE_ID");
        TRS.copy(CWIPTSCLOS_o.WORK_SHIFT, sizeof(CWIPTSCLOS_o.WORK_SHIFT), in_node, "WORK_SHIFT");
        memcpy(CWIPTSCLOS_o.CREATE_TIME, s_sys_time, sizeof(CWIPTSCLOS.CREATE_TIME));
		CDB_select_cwiptsclos(1, &CWIPTSCLOS_o);
		if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTSCLOS SELECT (CREATE_TIME Data duplication)", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS_o.WORK_DATE), CWIPTSCLOS_o.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS_o.LINE_ID), CWIPTSCLOS_o.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS_o.WORK_SHIFT), CWIPTSCLOS_o.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS_o.CREATE_TIME), CWIPTSCLOS_o.CREATE_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        TRS.copy(CWIPTSCLOS.CREATE_USER_ID, sizeof(CWIPTSCLOS.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPTSCLOS.CREATE_TIME, s_sys_time, sizeof(CWIPTSCLOS.CREATE_TIME));
        CDB_insert_cwiptsclos(&CWIPTSCLOS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTSCLOS INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS.WORK_DATE), CWIPTSCLOS.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS.CREATE_TIME), CWIPTSCLOS.CREATE_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        CDB_init_cwiptsclos(&CWIPTSCLOS_o);
        TRS.copy(CWIPTSCLOS_o.WORK_DATE, sizeof(CWIPTSCLOS_o.WORK_DATE), in_node, "WORK_DATE");
        TRS.copy(CWIPTSCLOS_o.LINE_ID, sizeof(CWIPTSCLOS_o.LINE_ID), in_node, "LINE_ID");
        TRS.copy(CWIPTSCLOS_o.WORK_SHIFT, sizeof(CWIPTSCLOS_o.WORK_SHIFT), in_node, "WORK_SHIFT");
        TRS.copy(CWIPTSCLOS_o.CREATE_TIME, sizeof(CWIPTSCLOS_o.CREATE_TIME), in_node, "CREATE_TIME");
        CDB_select_cwiptsclos_for_update(1, &CWIPTSCLOS_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTSCLOS SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS_o.WORK_DATE), CWIPTSCLOS_o.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS_o.LINE_ID), CWIPTSCLOS_o.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS_o.WORK_SHIFT), CWIPTSCLOS_o.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS_o.CREATE_TIME), CWIPTSCLOS_o.CREATE_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----

        memcpy(CWIPTSCLOS.CREATE_USER_ID, CWIPTSCLOS_o.CREATE_USER_ID, sizeof(CWIPTSCLOS.CREATE_USER_ID));
        memcpy(CWIPTSCLOS.CREATE_TIME, CWIPTSCLOS_o.CREATE_TIME, sizeof(CWIPTSCLOS.CREATE_TIME));
        TRS.copy(CWIPTSCLOS.UPDATE_USER_ID, sizeof(CWIPTSCLOS.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CWIPTSCLOS.UPDATE_TIME, s_sys_time, sizeof(CWIPTSCLOS.UPDATE_TIME));

        CDB_update_cwiptsclos(1, &CWIPTSCLOS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTSCLOS UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS.WORK_DATE), CWIPTSCLOS.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS.CREATE_TIME), CWIPTSCLOS.CREATE_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        CDB_delete_cwiptsclos(1, &CWIPTSCLOS);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTSCLOS DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS.WORK_DATE), CWIPTSCLOS.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS.CREATE_TIME), CWIPTSCLOS.CREATE_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    
    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_Update_Entry_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;

} 

/*******************************************************************************
    CWIP_Update_Entry_List_Validation()
        - Main sub function of "CWIP_UPDATE_ENTRY_LIST" function
        - Check the condition for create/update/delete Entry
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Entry_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPTSCLOS_TAG CWIPTSCLOS;
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

    /* WORK_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_DATE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* WORK_SHIFT Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "WORK_SHIFT")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CREATE_TIME Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CREATE_TIME")) == MP_TRUE
		&&
		COM_service_validation(s_msg_code,in_node,out_node,TRS.get_procstep(in_node),"UD") == MP_TRUE
    )
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    
    CDB_init_cwiptsclos(&CWIPTSCLOS);
    TRS.copy(CWIPTSCLOS.WORK_DATE, sizeof(CWIPTSCLOS.WORK_DATE), in_node, "WORK_DATE");
    TRS.copy(CWIPTSCLOS.LINE_ID, sizeof(CWIPTSCLOS.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CWIPTSCLOS.WORK_SHIFT, sizeof(CWIPTSCLOS.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPTSCLOS.CREATE_TIME, sizeof(CWIPTSCLOS.CREATE_TIME), in_node, "CREATE_TIME");
    CDB_select_cwiptsclos(1, &CWIPTSCLOS);

	// 생성시 MES Server 시간 기준임으로 시간 확인은 의미가 없음
	/*
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CWIPTSCLOS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS.WORK_DATE), CWIPTSCLOS.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS.CREATE_TIME), CWIPTSCLOS.CREATE_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    //else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
	*/

	if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0004");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CWIPTSCLOS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPTSCLOS.WORK_DATE), CWIPTSCLOS.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPTSCLOS.LINE_ID), CWIPTSCLOS.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPTSCLOS.WORK_SHIFT), CWIPTSCLOS.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "CREATE_TIME", MP_STR, sizeof(CWIPTSCLOS.CREATE_TIME), CWIPTSCLOS.CREATE_TIME);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }
    
    return MP_TRUE;
}

