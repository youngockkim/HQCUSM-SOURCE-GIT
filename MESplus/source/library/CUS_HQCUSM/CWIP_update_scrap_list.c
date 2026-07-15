/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_update_scrap_list.c
	Description : Update Scrap List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_Update_Scrap_List()
			+ View Scrap List
		- CWIP_UPDATE_SCRAP_LIST()
			+ Main sub function of CWIP_Update_Scrap_List function
			+ View Scrap List definition
		- CWIP_Update_Scrap_List_Validation()
			+ Main sub function of CWIP_UPDATE_SCRAP_LIST function
			+ Check the condition for View Scrap List
	Detail Description
		- CWIP_UPDATE_SCRAP_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_Update_Scrap_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_Update_Scrap_List()
		- View Scrap List
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Scrap_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_UPDATE_SCRAP_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_SCRAP_LIST", out_node);

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
	CWIP_UPDATE_SCRAP_LIST()
		- Main sub function of "CWIP_Update_Scrap_List" function
		- View Scrap List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_SCRAP_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct RSUMWIPLOS_TAG RSUMWIPLOS;

    char s_sys_time[14];
    int i_tran_count;
    int i;
    //int i_step;

    TRSNode ** Tran_List;

    LOG_head("CWIP_UPDATE_SCRAP_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_Update_Scrap_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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
            CDB_init_rsumwiplos(&RSUMWIPLOS);
            TRS.copy(RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY), in_node, IN_FACTORY);
            TRS.copy(RSUMWIPLOS.CM_KEY_1, sizeof(RSUMWIPLOS.CM_KEY_1), in_node, "LINE_ID");
            TRS.copy(RSUMWIPLOS.CM_KEY_2, sizeof(RSUMWIPLOS.CM_KEY_2), in_node, "WORK_SHIFT");
            TRS.copy(RSUMWIPLOS.WORK_DATE, sizeof(RSUMWIPLOS.WORK_DATE), in_node, "WORK_DATE");

            TRS.copy(RSUMWIPLOS.CM_KEY_3, sizeof(RSUMWIPLOS.CM_KEY_3), Tran_List[i], "CAUSE");
            TRS.copy(RSUMWIPLOS.LOSS_OPER, sizeof(RSUMWIPLOS.LOSS_OPER), Tran_List[i], "LOSS_OPER");
            TRS.copy(RSUMWIPLOS.RES_ID, sizeof(RSUMWIPLOS.RES_ID), Tran_List[i], "RES_ID");
			TRS.copy(RSUMWIPLOS.MAT_ID, sizeof(RSUMWIPLOS.MAT_ID), Tran_List[i], "MAT_ID");

            CDB_select_rsumwiplos(2,&RSUMWIPLOS);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* Insert */
                    CDB_init_rsumwiplos(&RSUMWIPLOS);
                    TRS.copy(RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY), in_node, IN_FACTORY);
                    TRS.copy(RSUMWIPLOS.CM_KEY_1, sizeof(RSUMWIPLOS.CM_KEY_1), in_node, "LINE_ID");
                    TRS.copy(RSUMWIPLOS.CM_KEY_2, sizeof(RSUMWIPLOS.CM_KEY_2), in_node, "WORK_SHIFT");
                    TRS.copy(RSUMWIPLOS.WORK_DATE, sizeof(RSUMWIPLOS.WORK_DATE), in_node, "WORK_DATE");
                    TRS.copy(RSUMWIPLOS.CM_KEY_3, sizeof(RSUMWIPLOS.CM_KEY_3), Tran_List[i], "CAUSE");
                    TRS.copy(RSUMWIPLOS.LOSS_OPER, sizeof(RSUMWIPLOS.LOSS_OPER), Tran_List[i], "LOSS_OPER");
                    TRS.copy(RSUMWIPLOS.RES_ID, sizeof(RSUMWIPLOS.RES_ID), Tran_List[i], "RES_ID");
					TRS.copy(RSUMWIPLOS.MAT_ID, sizeof(RSUMWIPLOS.MAT_ID), Tran_List[i], "MAT_ID");

                    RSUMWIPLOS.LOSS_QTY = TRS.get_double(Tran_List[i], "LOSS_QTY");
                    TRS.copy(RSUMWIPLOS.LOSS_COMMENT, sizeof(RSUMWIPLOS.LOSS_COMMENT), Tran_List[i], "LOSS_COMMENT");
                    TRS.copy(RSUMWIPLOS.CREATE_USER_ID, sizeof(RSUMWIPLOS.CREATE_USER_ID), in_node, IN_USERID);
                    memcpy(RSUMWIPLOS.CREATE_TIME, s_sys_time, sizeof(RSUMWIPLOS.CREATE_TIME));

                    CDB_insert_rsumwiplos(&RSUMWIPLOS);
                    if(DB_error_code != DB_SUCCESS)
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_fieldmsg(out_node, "RSUMWIPLOS INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                        TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                        TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
						TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);
                        TRS.add_fieldmsg(out_node, "LOSS_QTY", MP_DBL, sizeof(RSUMWIPLOS.LOSS_QTY), RSUMWIPLOS.LOSS_QTY);
                        TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(RSUMWIPLOS.LOSS_COMMENT), RSUMWIPLOS.LOSS_COMMENT);

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
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "RSUMWIPLOS SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);

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
                RSUMWIPLOS.LOSS_QTY = TRS.get_double(Tran_List[i], "LOSS_QTY");
                TRS.copy(RSUMWIPLOS.LOSS_COMMENT, sizeof(RSUMWIPLOS.LOSS_COMMENT), Tran_List[i], "LOSS_COMMENT");
                TRS.copy(RSUMWIPLOS.UPDATE_USER_ID, sizeof(RSUMWIPLOS.UPDATE_USER_ID), in_node, IN_USERID);
                memcpy(RSUMWIPLOS.UPDATE_TIME, s_sys_time, sizeof(RSUMWIPLOS.UPDATE_TIME));

                CDB_update_rsumwiplos(2,&RSUMWIPLOS);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "RSUMWIPLOS UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);
                    TRS.add_fieldmsg(out_node, "LOSS_QTY", MP_DBL, sizeof(RSUMWIPLOS.LOSS_QTY), RSUMWIPLOS.LOSS_QTY);
                    TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(RSUMWIPLOS.LOSS_COMMENT), RSUMWIPLOS.LOSS_COMMENT);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }

            }

        }
        else if (TRS.get_procstep(in_node) == MP_STEP_UPDATE)
        {
            CDB_init_rsumwiplos(&RSUMWIPLOS);
            TRS.copy(RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY), in_node, IN_FACTORY);
            TRS.copy(RSUMWIPLOS.CM_KEY_1, sizeof(RSUMWIPLOS.CM_KEY_1), in_node, "LINE_ID");
            TRS.copy(RSUMWIPLOS.CM_KEY_2, sizeof(RSUMWIPLOS.CM_KEY_2), in_node, "WORK_SHIFT");
            TRS.copy(RSUMWIPLOS.WORK_DATE, sizeof(RSUMWIPLOS.WORK_DATE), in_node, "WORK_DATE");

            TRS.copy(RSUMWIPLOS.CM_KEY_3, sizeof(RSUMWIPLOS.CM_KEY_3), Tran_List[i], "CAUSE");
            TRS.copy(RSUMWIPLOS.LOSS_OPER, sizeof(RSUMWIPLOS.LOSS_OPER), Tran_List[i], "LOSS_OPER");
            TRS.copy(RSUMWIPLOS.RES_ID, sizeof(RSUMWIPLOS.RES_ID), Tran_List[i], "RES_ID");
			TRS.copy(RSUMWIPLOS.MAT_ID, sizeof(RSUMWIPLOS.MAT_ID), Tran_List[i], "MAT_ID");

            CDB_select_rsumwiplos(2,&RSUMWIPLOS);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
			        strcpy(s_msg_code, "WIP-0566");
                    TRS.add_fieldmsg(out_node, "RSUMWIPLOS DELETE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);

			        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
		        }
                else 
                {            
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "RSUMWIPLOS DELETE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }

            /* Update */
            RSUMWIPLOS.LOSS_QTY = TRS.get_double(Tran_List[i], "LOSS_QTY");
            TRS.copy(RSUMWIPLOS.LOSS_COMMENT, sizeof(RSUMWIPLOS.LOSS_COMMENT), Tran_List[i], "LOSS_COMMENT");
            TRS.copy(RSUMWIPLOS.UPDATE_USER_ID, sizeof(RSUMWIPLOS.UPDATE_USER_ID), in_node, IN_USERID);
            memcpy(RSUMWIPLOS.UPDATE_TIME, s_sys_time, sizeof(RSUMWIPLOS.UPDATE_TIME));

            CDB_update_rsumwiplos(2,&RSUMWIPLOS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "RSUMWIPLOS OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);
                TRS.add_fieldmsg(out_node, "LOSS_QTY", MP_DBL, sizeof(RSUMWIPLOS.LOSS_QTY), RSUMWIPLOS.LOSS_QTY);
                TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(RSUMWIPLOS.LOSS_COMMENT), RSUMWIPLOS.LOSS_COMMENT);

                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
        else if (TRS.get_procstep(in_node) == MP_STEP_DELETE)
        {
            CDB_init_rsumwiplos(&RSUMWIPLOS);
            TRS.copy(RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY), in_node, IN_FACTORY);
            TRS.copy(RSUMWIPLOS.CM_KEY_1, sizeof(RSUMWIPLOS.CM_KEY_1), in_node, "LINE_ID");
            TRS.copy(RSUMWIPLOS.CM_KEY_2, sizeof(RSUMWIPLOS.CM_KEY_2), in_node, "WORK_SHIFT");
            TRS.copy(RSUMWIPLOS.WORK_DATE, sizeof(RSUMWIPLOS.WORK_DATE), in_node, "WORK_DATE");

            TRS.copy(RSUMWIPLOS.CM_KEY_3, sizeof(RSUMWIPLOS.CM_KEY_3), Tran_List[i], "CAUSE");
            TRS.copy(RSUMWIPLOS.LOSS_OPER, sizeof(RSUMWIPLOS.LOSS_OPER), Tran_List[i], "LOSS_OPER");
            TRS.copy(RSUMWIPLOS.RES_ID, sizeof(RSUMWIPLOS.RES_ID), Tran_List[i], "RES_ID");
			TRS.copy(RSUMWIPLOS.MAT_ID, sizeof(RSUMWIPLOS.MAT_ID), Tran_List[i], "MAT_ID");

            CDB_select_rsumwiplos(2,&RSUMWIPLOS);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
			        strcpy(s_msg_code, "WIP-0566");
                    TRS.add_fieldmsg(out_node, "RSUMWIPLOS DELETE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);

			        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
		        }
                else 
                {            
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "RSUMWIPLOS DELETE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                    TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                    TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                    TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                    TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                    TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }

            CDB_delete_rsumwiplos(2,&RSUMWIPLOS);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "RSUMWIPLOS OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
                TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
                TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
                TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
                TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
                TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
				TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(RSUMWIPLOS.MAT_ID), RSUMWIPLOS.MAT_ID);
                TRS.add_fieldmsg(out_node, "LOSS_QTY", MP_DBL, sizeof(RSUMWIPLOS.LOSS_QTY), RSUMWIPLOS.LOSS_QTY);
                TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(RSUMWIPLOS.LOSS_COMMENT), RSUMWIPLOS.LOSS_COMMENT);

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
	CWIP_Update_Scrap_List_Validation()
		- Main sub function of "CWIP_UPDATE_SCRAP_LIST" function
		- Check the condition for View Scrap List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Scrap_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    int     i_tran_count;
    int		i;
    TRSNode ** Tran_List;

	char s_curr_time[14];
	char s_work_time[14];
	char s_calc_work_time[14];

	int i_diff_sec;

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

    for(i = 0; i < i_tran_count; i++)
    {
        if(COM_isnullspace(TRS.get_string(Tran_List[i], "CAUSE")) == MP_TRUE)
	    {
		    strcpy(s_msg_code, "WIP-0568");
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, strlen(TRS.get_string(in_node, "LINE_ID")), TRS.get_string(in_node, "LINE_ID"));
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, strlen(TRS.get_string(in_node, "WORK_SHIFT")), TRS.get_string(in_node, "WORK_SHIFT"));
            TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, strlen(TRS.get_string(in_node, "WORK_DATE")), TRS.get_string(in_node, "WORK_DATE"));
            TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, strlen(TRS.get_string(Tran_List[i], "LOSS_OPER")), TRS.get_string(Tran_List[i], "LOSS_OPER"));
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, strlen(TRS.get_string(Tran_List[i], "RES_ID")), TRS.get_string(Tran_List[i], "RES_ID"));
            TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, strlen(TRS.get_string(Tran_List[i], "CAUSE")), TRS.get_string(Tran_List[i], "LOSS_TYPE"));

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_VALIDATION;
		    gs_log_type.category = MP_LOG_CATE_SETUP;
		    return MP_FALSE;
	    }
    }

    if (i_tran_count < 1)
    {
        if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
            strcpy(s_msg_code, "WIP-0568");
        }
        else
        {
		    strcpy(s_msg_code, "WIP-0567");
        }

        gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		return MP_FALSE;
    }

	//2019 11 11 일에 입력하면
	//2019 11 13 일 05:59:59 까지는 수정 삭제가 가능해야 한다.
	//현재 시간이 SCRAP_DATE + 2일 05:59:59 보다 크면 에러 
	memset(s_curr_time, ' ', sizeof(s_curr_time));
	DB_get_systime(s_curr_time);
	if(DB_error_code != DB_SUCCESS)
	{
		TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_COMMON;

		COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
		
	memset(s_work_time, ' ', sizeof(s_work_time));
	TRS.copy(s_work_time, sizeof(s_work_time), in_node, "WORK_DATE");
	memcpy(s_work_time+8, "055959", strlen("055959"));

	// 입력받은 scrap date + 2일 한 값의 05:59:59 까지 수정가능		
	// work_time 에 +2일 하여 수정가능한 최종 시간 구한다.
	DB_get_calc_time(s_calc_work_time, s_work_time, 3, 2);		

	COM_diff_time_sec(&i_diff_sec, s_curr_time, s_calc_work_time);

	// 현재 시간이 최종 작업가능 시간 보다 크면 수정 불가
	// 그 외에는 수정 가능
	if (i_diff_sec > 0)
	{
		// 수정 가능한 시간이 지났습니다.
		strcpy(s_msg_code, "WIP-0601");
		TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
		TRS.add_fieldmsg(out_node, "LIMIT TIME", MP_STR, sizeof(s_calc_work_time), s_calc_work_time);
		TRS.add_fieldmsg(out_node, "CURRENT TIME", MP_STR, sizeof(s_curr_time), s_curr_time);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		return MP_FALSE;
	}		

    return MP_TRUE;
}