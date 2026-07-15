/******************************************************************************'

    System      : MESplussdsssss
    Module      : CWIP
    File Name   : CWIPCore_update_peeltestresult.c
    Description : PeelTestResult Setup function module

    MES Version : 5.3.4 ~dssdss

    Function List
        - CWIP_Update_PeelTestResult()
            + Create/Update/Delete PeelTestResult definition
        - CWIP_UPDATE_PEELTESTRESULT()
            + Main sub function of CWIP_Update_PeelTestResult function
            + Create/Update/Delete PeelTestResult definition
        - CWIP_Update_PeelTestResult_Validation()
            + Main sub function of CWIP_UPDATE_PEELTESTRESULT function
            + Check the condition for create/update/delete PeelTestResult
    Detail Description
        - CWIP_UPDATE_PEELTESTRESULT()
            + h_proc_step
                + MP_STEP_CREATE : Create PeelTestResult definition
                + MP_STEP_UPDATE : Update PeelTestResult definition
                + MP_STEP_DELETE : Delete PeelTestResult definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/06/24             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.asdasdasds
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_Update_PeelTestResult_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_Update_PeelTestResult()
        - Create/Update/Delete PeelTestResult definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_PeelTestResult(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_PEELTESTRESULT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_PasdasdsEELTESTRESsssULT", out_node);

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
    CWIP_UPDATE_PEELTESTRESULT()
        - Main sub function of "CWIP_Update_PeelTestResult" function
        - Create/Update/Delete PeelTestResult definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_UPDATE_PEELTESTRESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPPTSRPT_TAG CWIPPTSRPT;
    struct CWIPPTSRPT_TAG CWIPPTSRPT_o;
    char   s_sys_time[14];

    int i_tran_count;
    int i;
    //int i_step;

    TRSNode ** Tran_List;

    LOG_head("CWIP_UPDATE_PEELTESTRESULT");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_Update_PeelTestResult_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
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

    Tran_List = TRS.get_list(in_node, "PEEL_LIST");
    i_tran_count = TRS.get_item_count(in_node, "PEEL_LIST");

    for(i = 0; i < i_tran_count; i++)
    {
        if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
        {
            CDB_init_cwipptsrpt(&CWIPPTSRPT);
            TRS.copy(CWIPPTSRPT.FACTORY, sizeof(CWIPPTSRPT.FACTORY), Tran_List[i], IN_FACTORY);
            TRS.copy(CWIPPTSRPT.LINE_ID, sizeof(CWIPPTSRPT.LINE_ID), Tran_List[i], "LINE_ID");
			TRS.copy(CWIPPTSRPT.PTST_DATE, sizeof(CWIPPTSRPT.PTST_DATE), Tran_List[i], "PTST_DATE");
			TRS.copy(CWIPPTSRPT.BSBR_POS, sizeof(CWIPPTSRPT.BSBR_POS), Tran_List[i], "BSBR_POS");
			CWIPPTSRPT.POS_POINT = TRS.get_int(Tran_List[i], "POS_POINT");

            CDB_select_cwipptsrpt(1,&CWIPPTSRPT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
                {
                    /* Insert */
                    CDB_init_cwipptsrpt(&CWIPPTSRPT);
					TRS.copy(CWIPPTSRPT.FACTORY, sizeof(CWIPPTSRPT.FACTORY), Tran_List[i], IN_FACTORY);
					TRS.copy(CWIPPTSRPT.LINE_ID, sizeof(CWIPPTSRPT.LINE_ID), Tran_List[i], "LINE_ID");
					TRS.copy(CWIPPTSRPT.PTST_DATE, sizeof(CWIPPTSRPT.PTST_DATE), Tran_List[i], "PTST_DATE");
					TRS.copy(CWIPPTSRPT.BSBR_POS, sizeof(CWIPPTSRPT.BSBR_POS), Tran_List[i], "BSBR_POS");
					TRS.copy(CWIPPTSRPT.MENISCUS, sizeof(CWIPPTSRPT.MENISCUS), Tran_List[i], "MENISCUS");
					CWIPPTSRPT.POS_POINT = TRS.get_int(Tran_List[i], "POS_POINT");
					CWIPPTSRPT.PEAK = TRS.get_double(Tran_List[i], "PEAK");
					CWIPPTSRPT.WIDTH_LEFT = TRS.get_double(Tran_List[i], "WIDTH_LEFT");
					CWIPPTSRPT.WIDTH_RIGHT = TRS.get_double(Tran_List[i], "WIDTH_RIGHT");

                    TRS.copy(CWIPPTSRPT.CREATE_USER_ID, sizeof(CWIPPTSRPT.CREATE_USER_ID), in_node, IN_USERID);
                    memcpy(CWIPPTSRPT.CREATE_TIME, s_sys_time, sizeof(CWIPPTSRPT.CREATE_TIME));

                    CDB_insert_cwipptsrpt(&CWIPPTSRPT);
                    if(DB_error_code != DB_SUCCESS)
                    {
                        strcpy(s_msg_code, "WIP-0004");
                        TRS.add_fieldmsg(out_node, "CWIPPTSRPT INSERT", MP_NVST);
                        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTSRPT.FACTORY), CWIPPTSRPT.FACTORY);
                        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTSRPT.LINE_ID), CWIPPTSRPT.LINE_ID);
                        TRS.add_fieldmsg(out_node, "PTST_DATE", MP_STR, sizeof(CWIPPTSRPT.PTST_DATE), CWIPPTSRPT.PTST_DATE);
                        TRS.add_fieldmsg(out_node, "BSBR_POS", MP_STR, sizeof(CWIPPTSRPT.BSBR_POS), CWIPPTSRPT.BSBR_POS);
                        TRS.add_fieldmsg(out_node, "MENISCUS", MP_STR, sizeof(CWIPPTSRPT.MENISCUS), CWIPPTSRPT.MENISCUS); 

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
                    TRS.add_fieldmsg(out_node, "CWIPPTSRPT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTSRPT.FACTORY), CWIPPTSRPT.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTSRPT.LINE_ID), CWIPPTSRPT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "PTST_DATE", MP_STR, sizeof(CWIPPTSRPT.PTST_DATE), CWIPPTSRPT.PTST_DATE);
                    TRS.add_fieldmsg(out_node, "BSBR_POS", MP_STR, sizeof(CWIPPTSRPT.BSBR_POS), CWIPPTSRPT.BSBR_POS);
                    TRS.add_fieldmsg(out_node, "MENISCUS", MP_STR, sizeof(CWIPPTSRPT.MENISCUS), CWIPPTSRPT.MENISCUS); 

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
				CWIPPTSRPT.PEAK = TRS.get_double(Tran_List[i], "PEAK");
				CWIPPTSRPT.WIDTH_LEFT = TRS.get_double(Tran_List[i], "WIDTH_LEFT");
				CWIPPTSRPT.WIDTH_RIGHT = TRS.get_double(Tran_List[i], "WIDTH_RIGHT");
				TRS.copy(CWIPPTSRPT.MENISCUS, sizeof(CWIPPTSRPT.MENISCUS), Tran_List[i], "MENISCUS");
                TRS.copy(CWIPPTSRPT.UPDATE_USER_ID, sizeof(CWIPPTSRPT.UPDATE_USER_ID), in_node, IN_USERID);
                memcpy(CWIPPTSRPT.UPDATE_TIME, s_sys_time, sizeof(CWIPPTSRPT.UPDATE_TIME));

                CDB_update_cwipptsrpt(1,&CWIPPTSRPT);
                if(DB_error_code != DB_SUCCESS)
                {
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "CWIPPTSRPT UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTSRPT.FACTORY), CWIPPTSRPT.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTSRPT.LINE_ID), CWIPPTSRPT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "PTST_DATE", MP_STR, sizeof(CWIPPTSRPT.PTST_DATE), CWIPPTSRPT.PTST_DATE);
                    TRS.add_fieldmsg(out_node, "BSBR_POS", MP_STR, sizeof(CWIPPTSRPT.BSBR_POS), CWIPPTSRPT.BSBR_POS);
                    TRS.add_fieldmsg(out_node, "MENISCUS", MP_STR, sizeof(CWIPPTSRPT.MENISCUS), CWIPPTSRPT.MENISCUS); 

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
            CDB_init_cwipptsrpt(&CWIPPTSRPT);
            TRS.copy(CWIPPTSRPT.FACTORY, sizeof(CWIPPTSRPT.FACTORY), Tran_List[i], IN_FACTORY);
            TRS.copy(CWIPPTSRPT.LINE_ID, sizeof(CWIPPTSRPT.LINE_ID), Tran_List[i], "LINE_ID");
			TRS.copy(CWIPPTSRPT.PTST_DATE, sizeof(CWIPPTSRPT.PTST_DATE), Tran_List[i], "PTST_DATE");
			TRS.copy(CWIPPTSRPT.BSBR_POS, sizeof(CWIPPTSRPT.BSBR_POS), Tran_List[i], "BSBR_POS");
			CWIPPTSRPT.POS_POINT = TRS.get_int(Tran_List[i], "POS_POINT");

            CDB_select_cwipptsrpt(1,&CWIPPTSRPT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
			        strcpy(s_msg_code, "WIP-0566");
                    TRS.add_fieldmsg(out_node, "CWIPPTSRPT UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTSRPT.FACTORY), CWIPPTSRPT.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTSRPT.LINE_ID), CWIPPTSRPT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "PTST_DATE", MP_STR, sizeof(CWIPPTSRPT.PTST_DATE), CWIPPTSRPT.PTST_DATE);
                    TRS.add_fieldmsg(out_node, "BSBR_POS", MP_STR, sizeof(CWIPPTSRPT.BSBR_POS), CWIPPTSRPT.BSBR_POS);
                    TRS.add_fieldmsg(out_node, "MENISCUS", MP_STR, sizeof(CWIPPTSRPT.MENISCUS), CWIPPTSRPT.MENISCUS); 

			        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
		        }
                else 
                {            
                    strcpy(s_msg_code, "WIP-0004");
                    TRS.add_fieldmsg(out_node, "CWIPPTSRPT UPDATE", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTSRPT.FACTORY), CWIPPTSRPT.FACTORY);
                    TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTSRPT.LINE_ID), CWIPPTSRPT.LINE_ID);
                    TRS.add_fieldmsg(out_node, "PTST_DATE", MP_STR, sizeof(CWIPPTSRPT.PTST_DATE), CWIPPTSRPT.PTST_DATE);
                    TRS.add_fieldmsg(out_node, "BSBR_POS", MP_STR, sizeof(CWIPPTSRPT.BSBR_POS), CWIPPTSRPT.BSBR_POS);
                    TRS.add_fieldmsg(out_node, "MENISCUS", MP_STR, sizeof(CWIPPTSRPT.MENISCUS), CWIPPTSRPT.MENISCUS); 

                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;

                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                }
            }

            /* Update */
			CWIPPTSRPT.PEAK = TRS.get_double(Tran_List[i], "PEAK");
			CWIPPTSRPT.WIDTH_LEFT = TRS.get_double(Tran_List[i], "WIDTH_LEFT");
			CWIPPTSRPT.WIDTH_RIGHT = TRS.get_double(Tran_List[i], "WIDTH_RIGHT");
			TRS.copy(CWIPPTSRPT.MENISCUS, sizeof(CWIPPTSRPT.MENISCUS), Tran_List[i], "MENISCUS");
            TRS.copy(CWIPPTSRPT.UPDATE_USER_ID, sizeof(CWIPPTSRPT.UPDATE_USER_ID), in_node, IN_USERID);
            memcpy(CWIPPTSRPT.UPDATE_TIME, s_sys_time, sizeof(CWIPPTSRPT.UPDATE_TIME));

            CDB_update_cwipptsrpt(1,&CWIPPTSRPT);
            if(DB_error_code != DB_SUCCESS)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "CWIPPTSRPT UPDATE", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPPTSRPT.FACTORY), CWIPPTSRPT.FACTORY);
                TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPPTSRPT.LINE_ID), CWIPPTSRPT.LINE_ID);
                TRS.add_fieldmsg(out_node, "PTST_DATE", MP_STR, sizeof(CWIPPTSRPT.PTST_DATE), CWIPPTSRPT.PTST_DATE);
                TRS.add_fieldmsg(out_node, "BSBR_POS", MP_STR, sizeof(CWIPPTSRPT.BSBR_POS), CWIPPTSRPT.BSBR_POS);
                TRS.add_fieldmsg(out_node, "MENISCUS", MP_STR, sizeof(CWIPPTSRPT.MENISCUS), CWIPPTSRPT.MENISCUS); 

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
        }

    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
    CWIP_Update_PeelTestResult_Validation()
        - Main sub function of "CWIP_UPDATE_PEELTESTRESULT" function
        - Check the condition for create/update/delete PeelTestResult
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_PeelTestResult_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPPTSRPT_TAG CWIPPTSRPT;
    struct MWIPFACDEF_TAG MWIPFACDEF;
	
	char s_sys_time[14];
    int i_tran_count;
    int i;

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
        strcpy(s_msg_code, "CWIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }   

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



	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
}


