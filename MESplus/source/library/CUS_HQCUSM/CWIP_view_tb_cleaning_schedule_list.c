/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_tb_cleaning_schedule_list.c
    Description : View Tb_Cleaning_Schedule List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Tb_Cleaning_Schedule_List()
            + View Tb_Cleaning_Schedule definition List
        - CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST()
            + Main sub function of CWIP_View_Tb_Cleaning_Schedule_List function
            + View Tb_Cleaning_Schedule definition List
    Detail Description
        - CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST()
            + h_proc_step
                + 1 : View Tb_Cleaning_Schedule definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/08/27             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CWIP_View_Tb_Cleaning_Schedule_List()
        - View Tb_Cleaning_Schedule definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Tb_Cleaning_Schedule_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST", out_node);

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
    CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST()
        - Main sub function of "CWIP_View_Tb_Cleaning_Schedule_List" function
        - View Tb_Cleaning_Schedule definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASTBRCLN_TAG CRASTBRCLN;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("line_id", MP_NSTR, TRS.get_string(in_node, "LINE_ID"));
    LOG_add("work_shift", MP_NSTR, TRS.get_string(in_node, "WORK_SHIFT"));
    LOG_add("res_id", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("clng_date", MP_NSTR, TRS.get_string(in_node, "CLNG_DATE"));
    LOG_add("clng_time", MP_NSTR, TRS.get_string(in_node, "CLNG_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);
	 
    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* LINE_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LINE_ID")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* CLNG_DATE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "CLNG_DATE")) == MP_TRUE)
    {
        strncpy(s_msg_code, "CWIP-0001", strlen("CWIP-0001"));
        TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;

    CDB_init_crastbrcln(&CRASTBRCLN);
    TRS.copy(CRASTBRCLN.FACTORY, sizeof(CRASTBRCLN.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASTBRCLN.LINE_ID, sizeof(CRASTBRCLN.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CRASTBRCLN.CLNG_DATE, sizeof(CRASTBRCLN.CLNG_DATE), in_node, "CLNG_DATE");
    CDB_open_crastbrcln(i_case, &CRASTBRCLN);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CWIP-0004");
        TRS.add_fieldmsg(out_node, "CRASTBRCLN OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRCLN.FACTORY), CRASTBRCLN.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASTBRCLN.LINE_ID), CRASTBRCLN.LINE_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASTBRCLN.WORK_SHIFT), CRASTBRCLN.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTBRCLN.RES_ID), CRASTBRCLN.RES_ID);
        TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_STR, sizeof(CRASTBRCLN.CLNG_DATE), CRASTBRCLN.CLNG_DATE);
        TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_STR, sizeof(CRASTBRCLN.CLNG_TIME), CRASTBRCLN.CLNG_TIME);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_crastbrcln(i_case, &CRASTBRCLN);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_crastbrcln(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "CWIP-0004");
            TRS.add_fieldmsg(out_node, "CRASTBRCLN FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASTBRCLN.FACTORY), CRASTBRCLN.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASTBRCLN.LINE_ID), CRASTBRCLN.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASTBRCLN.WORK_SHIFT), CRASTBRCLN.WORK_SHIFT);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASTBRCLN.RES_ID), CRASTBRCLN.RES_ID);
            TRS.add_fieldmsg(out_node, "CLNG_DATE", MP_STR, sizeof(CRASTBRCLN.CLNG_DATE), CRASTBRCLN.CLNG_DATE);
            TRS.add_fieldmsg(out_node, "CLNG_TIME", MP_STR, sizeof(CRASTBRCLN.CLNG_TIME), CRASTBRCLN.CLNG_TIME);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_crastbrcln(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_LINE_ID", CRASTBRCLN.LINE_ID, sizeof(CRASTBRCLN.LINE_ID));
            TRS.set_string(out_node, "NEXT_WORK_SHIFT", CRASTBRCLN.WORK_SHIFT, sizeof(CRASTBRCLN.WORK_SHIFT));
            TRS.set_string(out_node, "NEXT_RES_ID", CRASTBRCLN.RES_ID, sizeof(CRASTBRCLN.RES_ID));
            TRS.set_string(out_node, "NEXT_CLNG_DATE", CRASTBRCLN.CLNG_DATE, sizeof(CRASTBRCLN.CLNG_DATE));
            TRS.set_string(out_node, "NEXT_CLNG_TIME", CRASTBRCLN.CLNG_TIME, sizeof(CRASTBRCLN.CLNG_TIME));
            CDB_close_crastbrcln(i_case);
            break;
        }

        list_item = TRS.add_node(out_node, "TB_CLEANING_SCHEDULE_LIST");

        TRS.add_string(list_item, "FACTORY", CRASTBRCLN.FACTORY, sizeof(CRASTBRCLN.FACTORY));
        TRS.add_string(list_item, "LINE_ID", CRASTBRCLN.LINE_ID, sizeof(CRASTBRCLN.LINE_ID));
        TRS.add_string(list_item, "WORK_SHIFT", CRASTBRCLN.WORK_SHIFT, sizeof(CRASTBRCLN.WORK_SHIFT));
        TRS.add_string(list_item, "RES_ID", CRASTBRCLN.RES_ID, sizeof(CRASTBRCLN.RES_ID));
        TRS.add_string(list_item, "CLNG_DATE", CRASTBRCLN.CLNG_DATE, sizeof(CRASTBRCLN.CLNG_DATE));
        TRS.add_string(list_item, "CLNG_TIME", CRASTBRCLN.CLNG_TIME, sizeof(CRASTBRCLN.CLNG_TIME));
        TRS.add_string(list_item, "CLNG_TYPE", CRASTBRCLN.CLNG_TYPE, sizeof(CRASTBRCLN.CLNG_TYPE));
        TRS.add_string(list_item, "RQST_DPMT", CRASTBRCLN.RQST_DPMT, sizeof(CRASTBRCLN.RQST_DPMT));
        TRS.add_string(list_item, "CLNG_PLAN", CRASTBRCLN.CLNG_PLAN, sizeof(CRASTBRCLN.CLNG_PLAN));
        TRS.add_string(list_item, "CLNG_CMMT", CRASTBRCLN.CLNG_CMMT, sizeof(CRASTBRCLN.CLNG_CMMT));
        TRS.add_string(list_item, "CMF_1", CRASTBRCLN.CMF_1, sizeof(CRASTBRCLN.CMF_1));
        TRS.add_string(list_item, "CMF_2", CRASTBRCLN.CMF_2, sizeof(CRASTBRCLN.CMF_2));
        TRS.add_string(list_item, "CMF_3", CRASTBRCLN.CMF_3, sizeof(CRASTBRCLN.CMF_3));
        TRS.add_string(list_item, "CMF_4", CRASTBRCLN.CMF_4, sizeof(CRASTBRCLN.CMF_4));
        TRS.add_string(list_item, "CMF_5", CRASTBRCLN.CMF_5, sizeof(CRASTBRCLN.CMF_5));
        TRS.add_string(list_item, "CMF_6", CRASTBRCLN.CMF_6, sizeof(CRASTBRCLN.CMF_6));
        TRS.add_string(list_item, "CMF_7", CRASTBRCLN.CMF_7, sizeof(CRASTBRCLN.CMF_7));
        TRS.add_string(list_item, "CMF_8", CRASTBRCLN.CMF_8, sizeof(CRASTBRCLN.CMF_8));
        TRS.add_string(list_item, "CMF_9", CRASTBRCLN.CMF_9, sizeof(CRASTBRCLN.CMF_9));
        TRS.add_string(list_item, "CMF_10", CRASTBRCLN.CMF_10, sizeof(CRASTBRCLN.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CRASTBRCLN.CREATE_USER_ID, sizeof(CRASTBRCLN.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CRASTBRCLN.CREATE_TIME, sizeof(CRASTBRCLN.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CRASTBRCLN.UPDATE_USER_ID, sizeof(CRASTBRCLN.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CRASTBRCLN.UPDATE_TIME, sizeof(CRASTBRCLN.UPDATE_TIME));

        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, "@TBCLN_CLNG_TYP_LINE", strlen("@TBCLN_CLNG_TYP_LINE"));
        memcpy(MGCMTBLDAT.KEY_1, TRS.get_string(in_node, "FACTORY_NO"), sizeof(MGCMTBLDAT.KEY_1));
		memcpy(MGCMTBLDAT.KEY_2, CRASTBRCLN.CLNG_TYPE, sizeof(CRASTBRCLN.CLNG_TYPE));

	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code == DB_SUCCESS)
        {
			TRS.add_string(list_item, "CLNG_TYPE_NM", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        } 

        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	    memcpy(MGCMTBLDAT.TABLE_NAME, "@DEPT_CODE_LINE", strlen("@DEPT_CODE_LINE"));
        memcpy(MGCMTBLDAT.KEY_1, TRS.get_string(in_node, "FACTORY_NO"), sizeof(MGCMTBLDAT.KEY_1));
		memcpy(MGCMTBLDAT.KEY_2, CRASTBRCLN.RQST_DPMT, sizeof(CRASTBRCLN.RQST_DPMT));

	    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
        if(DB_error_code == DB_SUCCESS)
        {
			TRS.add_string(list_item, "RQST_DPMT_NM", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
        } 

	}

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Tb_Cleaning_Schedule_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

