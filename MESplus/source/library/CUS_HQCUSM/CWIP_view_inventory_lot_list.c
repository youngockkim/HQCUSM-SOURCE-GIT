/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_view_cinvlotsts_list.c
    Description : View Cinvlotsts List function module

    MES Version : 5.3.4 ~

    Function List
        - CWIP_View_Cinvlotsts_List()
            + View Cinvlotsts definition List
        - CWIP_VIEW_CINVLOTSTS_LIST()
            + Main sub function of CWIP_View_Cinvlotsts_List function
            + View Cinvlotsts definition List
    Detail Description
        - CWIP_VIEW_CINVLOTSTS_LIST()
            + h_proc_step
                + 1 : View Cinvlotsts definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019-01-03             Create by Generator

    Copyright(C) 1998-2019 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include <WIPCore_common.h>

/*******************************************************************************
    CWIP_View_Cinvlotsts_List()
        - View Cinvlotsts definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Cinvlotsts_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_CINVLOTSTS_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_CINVLOTSTS_LIST", out_node);

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
    CWIP_VIEW_CINVLOTSTS_LIST()
        - Main sub function of "CWIP_View_Cinvlotsts_List" function
        - View Cinvlotsts definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_CINVLOTSTS_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CINVLOTSTS_TAG CINVLOTSTS;
	struct CINVLOTSTS_TAG CINVLOTSTS_BCR;

//    TRSNode *list_item;

    int i_case;

    LOG_head("CWIP_VIEW_CINVLOTSTS_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("inv_lot_id", MP_NSTR, TRS.get_string(in_node, "INV_LOT_ID"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CWIP", "CWIP_View_Cinvlotsts_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* INV_LOT_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "VENDOR_BARCD")) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
        TRS.add_fieldmsg(out_node, "INV_LOT_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    i_case = 1;
	CDB_init_cinvlotsts(&CINVLOTSTS_BCR);
	TRS.copy(CINVLOTSTS_BCR.FACTORY, sizeof(CINVLOTSTS_BCR.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CINVLOTSTS_BCR.VENDOR_BARCD, sizeof(CINVLOTSTS_BCR.VENDOR_BARCD), in_node, "VENDOR_BARCD");

	CDB_select_cinvlotsts(2,&CINVLOTSTS_BCR);
	
	if(DB_error_code != DB_SUCCESS)
        {
			 if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
			
		}

    CDB_init_cinvlotsts(&CINVLOTSTS);
    TRS.copy(CINVLOTSTS.FACTORY, sizeof(CINVLOTSTS.FACTORY), in_node, IN_FACTORY);
	memcpy(CINVLOTSTS.INV_LOT_ID, CINVLOTSTS_BCR.INV_LOT_ID, sizeof(CINVLOTSTS_BCR.INV_LOT_ID));			//DOC_ID	

	CDB_select_cinvlotsts(1,&CINVLOTSTS);
	   
    if(DB_error_code != DB_SUCCESS)
    {
         if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
    }

    TRS.add_string(out_node, "FACTORY", CINVLOTSTS.FACTORY, sizeof(CINVLOTSTS.FACTORY));
    TRS.add_string(out_node, "INV_LOT_ID", CINVLOTSTS.INV_LOT_ID, sizeof(CINVLOTSTS.INV_LOT_ID));
    TRS.add_string(out_node, "VENDOR_BARCD", CINVLOTSTS.VENDOR_BARCD, sizeof(CINVLOTSTS.VENDOR_BARCD));
    TRS.add_string(out_node, "OPER", CINVLOTSTS.OPER, sizeof(CINVLOTSTS.OPER));
    TRS.add_string(out_node, "MAT_ID", CINVLOTSTS.MAT_ID, sizeof(CINVLOTSTS.MAT_ID));
    TRS.add_string(out_node, "INV_MAT_TYPE", CINVLOTSTS.INV_MAT_TYPE, sizeof(CINVLOTSTS.INV_MAT_TYPE));
    TRS.add_string(out_node, "VENDOR_ID", CINVLOTSTS.VENDOR_ID, sizeof(CINVLOTSTS.VENDOR_ID));
    TRS.add_string(out_node, "VENDOR_MAT_TYPE", CINVLOTSTS.VENDOR_MAT_TYPE, sizeof(CINVLOTSTS.VENDOR_MAT_TYPE));
    TRS.add_string(out_node, "LOCATION", CINVLOTSTS.LOCATION, sizeof(CINVLOTSTS.LOCATION));
    TRS.add_string(out_node, "OLD_LOCATION", CINVLOTSTS.OLD_LOCATION, sizeof(CINVLOTSTS.OLD_LOCATION));
    TRS.add_string(out_node, "BATCH_NO", CINVLOTSTS.BATCH_NO, sizeof(CINVLOTSTS.BATCH_NO));
    TRS.add_string(out_node, "VEN_BATCH_NO", CINVLOTSTS.VEN_BATCH_NO, sizeof(CINVLOTSTS.VEN_BATCH_NO));
    TRS.add_string(out_node, "VENDOR_MAT_ID", CINVLOTSTS.VENDOR_MAT_ID, sizeof(CINVLOTSTS.VENDOR_MAT_ID));
    TRS.add_double(out_node, "QTY_1", CINVLOTSTS.QTY_1);
    TRS.add_double(out_node, "QTY_2", CINVLOTSTS.QTY_2);
    TRS.add_double(out_node, "QTY_3", CINVLOTSTS.QTY_3);
    TRS.add_string(out_node, "UNIT_1", CINVLOTSTS.UNIT_1, sizeof(CINVLOTSTS.UNIT_1));
    TRS.add_string(out_node, "UNIT_2", CINVLOTSTS.UNIT_2, sizeof(CINVLOTSTS.UNIT_2));
    TRS.add_string(out_node, "UNIT_3", CINVLOTSTS.UNIT_3, sizeof(CINVLOTSTS.UNIT_3));
    TRS.add_string(out_node, "VENDOR_LOTID", CINVLOTSTS.VENDOR_LOTID, sizeof(CINVLOTSTS.VENDOR_LOTID));
    TRS.add_char(out_node, "DELETE_FLAG", CINVLOTSTS.DELETE_FLAG);
    TRS.add_int(out_node, "LAST_HIST_SEQ", CINVLOTSTS.LAST_HIST_SEQ);
    TRS.add_string(out_node, "LAST_TRAN_TIME", CINVLOTSTS.LAST_TRAN_TIME, sizeof(CINVLOTSTS.LAST_TRAN_TIME));
    TRS.add_string(out_node, "LAST_TRAN_USER_ID", CINVLOTSTS.LAST_TRAN_USER_ID, sizeof(CINVLOTSTS.LAST_TRAN_USER_ID));
    TRS.add_string(out_node, "LAST_TRAN_TYPE", CINVLOTSTS.LAST_TRAN_TYPE, sizeof(CINVLOTSTS.LAST_TRAN_TYPE));
    TRS.add_string(out_node, "PUR_ORDER_NO", CINVLOTSTS.PUR_ORDER_NO, sizeof(CINVLOTSTS.PUR_ORDER_NO));
    TRS.add_string(out_node, "PUR_TYPE", CINVLOTSTS.PUR_TYPE, sizeof(CINVLOTSTS.PUR_TYPE));
    TRS.add_string(out_node, "PACKAGE_TYPE", CINVLOTSTS.PACKAGE_TYPE, sizeof(CINVLOTSTS.PACKAGE_TYPE));
    TRS.add_char(out_node, "IQC_FLAG", CINVLOTSTS.IQC_FLAG);
    TRS.add_string(out_node, "INPUT_TIME", CINVLOTSTS.INPUT_TIME, sizeof(CINVLOTSTS.INPUT_TIME));
    TRS.add_string(out_node, "PROD_TIME", CINVLOTSTS.PROD_TIME, sizeof(CINVLOTSTS.PROD_TIME));
    TRS.add_string(out_node, "ASSIGN_TIME", CINVLOTSTS.ASSIGN_TIME, sizeof(CINVLOTSTS.ASSIGN_TIME));
    TRS.add_string(out_node, "CMF_1", CINVLOTSTS.CMF_1, sizeof(CINVLOTSTS.CMF_1));
    TRS.add_string(out_node, "CMF_2", CINVLOTSTS.CMF_2, sizeof(CINVLOTSTS.CMF_2));
    TRS.add_string(out_node, "CMF_3", CINVLOTSTS.CMF_3, sizeof(CINVLOTSTS.CMF_3));
    TRS.add_string(out_node, "CMF_4", CINVLOTSTS.CMF_4, sizeof(CINVLOTSTS.CMF_4));
    TRS.add_string(out_node, "CMF_5", CINVLOTSTS.CMF_5, sizeof(CINVLOTSTS.CMF_5));
    TRS.add_string(out_node, "CMF_6", CINVLOTSTS.CMF_6, sizeof(CINVLOTSTS.CMF_6));
    TRS.add_string(out_node, "CMF_7", CINVLOTSTS.CMF_7, sizeof(CINVLOTSTS.CMF_7));
    TRS.add_string(out_node, "CMF_8", CINVLOTSTS.CMF_8, sizeof(CINVLOTSTS.CMF_8));
    TRS.add_string(out_node, "CMF_9", CINVLOTSTS.CMF_9, sizeof(CINVLOTSTS.CMF_9));
    TRS.add_string(out_node, "CMF_10", CINVLOTSTS.CMF_10, sizeof(CINVLOTSTS.CMF_10));

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

