/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_view_crasdwntim_list.c
    Description : View Crasdwntim List function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_View_Crasdwntim_List()
            + View Crasdwntim definition List
        - CRAS_VIEW_CRASDWNTIM_LIST()
            + Main sub function of CRAS_View_Crasdwntim_List function
            + View Crasdwntim definition List
    Detail Description
        - CRAS_VIEW_CRASDWNTIM_LIST()
            + h_proc_step
                + 1 : View Crasdwntim definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2021-04-20             Create by Generator

    Copyright(C) 1998-2021 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CRAS_View_Crasdwntim_List()
        - View Crasdwntim definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Crasdwntim_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_VIEW_CRASDWNTIM_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_VIEW_CRASDWNTIM_LIST", out_node);

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
    CRAS_VIEW_CRASDWNTIM_LIST()
        - Main sub function of "CRAS_View_Crasdwntim_List" function
        - View Crasdwntim definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_CRASDWNTIM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASDWNTIM_TAG CRASDWNTIM;
    TRSNode *list_item;

    int i_case;
	int sort_cnt = 0; 
	char chk_line_id[10];
	memset(chk_line_id, ' ', sizeof(chk_line_id));


	LOG_head("CRAS_VIEW_CRASDWNTIM_LIST");
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
	//i_case = 3; //Line location Ãß°¡(2023/11/25)
	i_case = 4; //[2026.02.04] fe,be data only 

    CDB_init_crasdwntim(&CRASDWNTIM);
    TRS.copy(CRASDWNTIM.WORK_DATE, sizeof(CRASDWNTIM.WORK_DATE), in_node, "WORK_DATE");
   // TRS.copy(CRASDWNTIM.LINE_ID, sizeof(CRASDWNTIM.LINE_ID), in_node, "LINE_ID");
    TRS.copy(CRASDWNTIM.WORK_SHIFT, sizeof(CRASDWNTIM.WORK_SHIFT), in_node, "WORK_SHIFT");
	TRS.copy(CRASDWNTIM.CMF_5, sizeof(CRASDWNTIM.CMF_5), in_node, "LINE_LOCATION");
    
    CDB_open_crasdwntim(i_case, &CRASDWNTIM);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "CRASDWNTIM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM.WORK_DATE), CRASDWNTIM.WORK_DATE);
        //TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM.LINE_ID), CRASDWNTIM.LINE_ID);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM.WORK_SHIFT), CRASDWNTIM.WORK_SHIFT);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    while(1)
    {
        CDB_fetch_crasdwntim(i_case, &CRASDWNTIM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_crasdwntim(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "CRASDWNTIM FETCH", MP_NVST);
            //TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CRASDWNTIM.WORK_DATE), CRASDWNTIM.WORK_DATE);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CRASDWNTIM.LINE_ID), CRASDWNTIM.LINE_ID);
            TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CRASDWNTIM.WORK_SHIFT), CRASDWNTIM.WORK_SHIFT);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_crasdwntim(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		
		if(COM_isnullspace(chk_line_id) == MP_TRUE)
		{
			memcpy(chk_line_id, CRASDWNTIM.LINE_ID, sizeof(CRASDWNTIM.LINE_ID));
		}

		if (memcmp(CRASDWNTIM.LINE_ID, chk_line_id, sizeof(chk_line_id)) != 0 )
		{
			memcpy(chk_line_id, CRASDWNTIM.LINE_ID, sizeof(CRASDWNTIM.LINE_ID));
			sort_cnt = 0;
		}

		if (memcmp(CRASDWNTIM.PROCESS_TYPE, "TTL", strlen("TTL")) != 0 && sort_cnt > 2)
		{
			continue;
		}
	
        list_item = TRS.add_node(out_node, "CRASDWNTIM_LIST");

        //TRS.add_string(list_item, "WORK_DATE", CRASDWNTIM.WORK_DATE, sizeof(CRASDWNTIM.WORK_DATE));
        TRS.add_string(list_item, "LINE_ID", CRASDWNTIM.LINE_ID, sizeof(CRASDWNTIM.LINE_ID));
        TRS.add_string(list_item, "WORK_SHIFT", CRASDWNTIM.WORK_SHIFT, sizeof(CRASDWNTIM.WORK_SHIFT));
        TRS.add_string(list_item, "PROCESS_TYPE", CRASDWNTIM.PROCESS_TYPE, sizeof(CRASDWNTIM.PROCESS_TYPE));
        TRS.add_int(list_item, "EFF_TIME", CRASDWNTIM.EFF_TIME);
        //TRS.add_string(list_item, "CREATE_USER_ID", CRASDWNTIM.CREATE_USER_ID, sizeof(CRASDWNTIM.CREATE_USER_ID));
        //TRS.add_string(list_item, "UPDATE_USER_ID", CRASDWNTIM.UPDATE_USER_ID, sizeof(CRASDWNTIM.UPDATE_USER_ID));
        //TRS.add_string(list_item, "TRAN_TIME", CRASDWNTIM.TRAN_TIME, sizeof(CRASDWNTIM.TRAN_TIME));
        TRS.add_string(list_item, "REMARK", CRASDWNTIM.REMARK, sizeof(CRASDWNTIM.REMARK));
        //TRS.add_string(list_item, "CMF_1", CRASDWNTIM.CMF_1, sizeof(CRASDWNTIM.CMF_1));
        //TRS.add_string(list_item, "CMF_2", CRASDWNTIM.CMF_2, sizeof(CRASDWNTIM.CMF_2));
        //TRS.add_string(list_item, "CMF_3", CRASDWNTIM.CMF_3, sizeof(CRASDWNTIM.CMF_3));
        //TRS.add_string(list_item, "CMF_4", CRASDWNTIM.CMF_4, sizeof(CRASDWNTIM.CMF_4));
        //TRS.add_string(list_item, "CMF_5", CRASDWNTIM.CMF_5, sizeof(CRASDWNTIM.CMF_5));
		if (memcmp(CRASDWNTIM.PROCESS_TYPE, "TTL", strlen("TTL")) != 0)
		{
			sort_cnt ++;
		}

    }


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

