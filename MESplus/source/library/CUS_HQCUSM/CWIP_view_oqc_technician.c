/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_oqc_technician.c
    Description : View OQC_TECHNICIAN function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_OQC_TECHNICIAN()
            + View OQC_TECHNICIAN definition
        - CWIP_VIEW_OQC_TECHNICIAN()
            + Main sub function of CWIP_View_OQC_TECHNICIAN function
            + View OQC_TECHNICIAN definition
    Detail Description
        - CWIP_VIEW_OQC_TECHNICIAN()
            + h_proc_step
                + 1 : View OQC_TECHNICIAN definition  by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2020-09-05             Create by Generator

    Copyright(C) 1998-2020 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"


int CWIP_View_Oqc_Technician_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CWIP_View_OQC_TECHNICIAN()
        - View OQC_TECHNICIAN definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Oqc_Technician(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

	if(CWIP_View_Oqc_Technician_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_ret = CWIP_VIEW_OQC_TECHNICIAN(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_OQC_TECHNICIAN", out_node);

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
    CWIP_VIEW_OQC_TECHNICIAN()
        - Main sub function of "CWIP_View_OQC_TECHNICIAN" function
        - View OQC_TECHNICIAN definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_OQC_TECHNICIAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CWIPOQCSTS_TAG CWIPOQCSTS;


   // PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_OQC_TECHNICIAN");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    
    CDB_init_cwipoqcsts(&CWIPOQCSTS);
    TRS.copy(CWIPOQCSTS.LOT_ID, sizeof(CWIPOQCSTS.LOT_ID), in_node, "LOT_ID");
    TRS.copy(CWIPOQCSTS.INS_TYPE, sizeof(CWIPOQCSTS.INS_TYPE), in_node, "INS_TYPE");
    CDB_select_cwipoqcsts(1, &CWIPOQCSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0614");
        TRS.add_fieldmsg(out_node, "CWIPOQCSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPOQCSTS.LOT_ID), CWIPOQCSTS.LOT_ID);
        TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CWIPOQCSTS.INS_TYPE), CWIPOQCSTS.INS_TYPE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    TRS.add_string(out_node, "LOT_ID", CWIPOQCSTS.LOT_ID, sizeof(CWIPOQCSTS.LOT_ID));
    TRS.add_string(out_node, "INS_TYPE", CWIPOQCSTS.INS_TYPE, sizeof(CWIPOQCSTS.INS_TYPE));
    TRS.add_int(out_node, "INS_CNT", CWIPOQCSTS.INS_CNT);
    TRS.add_string(out_node, "TRAN_TIME", CWIPOQCSTS.TRAN_TIME, sizeof(CWIPOQCSTS.TRAN_TIME));
    TRS.add_string(out_node, "FACTORY", CWIPOQCSTS.FACTORY, sizeof(CWIPOQCSTS.FACTORY));
    TRS.add_string(out_node, "INS_USER_ID", CWIPOQCSTS.INS_USER_ID, sizeof(CWIPOQCSTS.INS_USER_ID));   
	TRS.add_string(out_node, "GRADE", CWIPOQCSTS.GRADE, sizeof(CWIPOQCSTS.GRADE));
    TRS.add_string(out_node, "DEFECT_CODE", CWIPOQCSTS.DEFECT_CODE, sizeof(CWIPOQCSTS.DEFECT_CODE));
    TRS.add_string(out_node, "CELL_INFO", CWIPOQCSTS.CELL_INFO, sizeof(CWIPOQCSTS.CELL_INFO));
	TRS.add_string(out_node, "REMARK", CWIPOQCSTS.REMARK, sizeof(CWIPOQCSTS.REMARK));
    TRS.add_string(out_node, "CMF_1", CWIPOQCSTS.CMF_1, sizeof(CWIPOQCSTS.CMF_1));
    TRS.add_string(out_node, "CMF_2", CWIPOQCSTS.CMF_2, sizeof(CWIPOQCSTS.CMF_2));
    TRS.add_string(out_node, "CMF_3", CWIPOQCSTS.CMF_3, sizeof(CWIPOQCSTS.CMF_3));
    TRS.add_string(out_node, "CMF_4", CWIPOQCSTS.CMF_4, sizeof(CWIPOQCSTS.CMF_4));
    TRS.add_string(out_node, "CMF_5", CWIPOQCSTS.CMF_5, sizeof(CWIPOQCSTS.CMF_5));
    TRS.add_string(out_node, "CREATE_USER_ID", CWIPOQCSTS.CREATE_USER_ID, sizeof(CWIPOQCSTS.CREATE_USER_ID));
    TRS.add_string(out_node, "CREATE_TIME", CWIPOQCSTS.CREATE_TIME, sizeof(CWIPOQCSTS.CREATE_TIME));

 
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}



int CWIP_View_Oqc_Technician_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	/* LOT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
    {

		/*strcpy(s_msg_code, "WIP-0001");
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		return MP_FALSE;*/


        strcpy(s_msg_code, "WIP-0001");
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, TRS.get_string(in_node,"LOT_ID"), strlen(TRS.get_string(in_node,"LOT_ID")));
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* INS_TYPE Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "INS_TYPE")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);
		TRS.add_fieldmsg(out_node, "INS_TYPE", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	
	return MP_TRUE;


}
