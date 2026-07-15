/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_view_equipment_item_list.c
    Description : View Equipment_Item List function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_View_Equipment_Item_List()
            + View Equipment_Item definition List
        - CMMS_VIEW_EQUIPMENT_ITEM_LIST()
            + Main sub function of CMMS_View_Equipment_Item_List function
            + View Equipment_Item definition List
    Detail Description
        - CMMS_VIEW_EQUIPMENT_ITEM_LIST()
            + h_proc_step
                + 1 : View Equipment_Item definition List by Primary Key
    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-21             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
    CMMS_View_Equipment_Item_List()
        - View Equipment_Item definition List
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_View_Equipment_Item_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_VIEW_EQUIPMENT_ITEM_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_VIEW_EQUIPMENT_ITEM_LIST", out_node);

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
    CMMS_VIEW_EQUIPMENT_ITEM_LIST()
        - Main sub function of "CMMS_View_Equipment_Item_List" function
        - View Equipment_Item definition List
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_VIEW_EQUIPMENT_ITEM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSEQPITM_TAG CMMSEQPITM;
    TRSNode *list_item;

    int i_case;

    LOG_head("CMMS_VIEW_EQUIPMENT_ITEM_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    LOG_add("item_code", MP_NSTR, TRS.get_string(in_node, "ITEM_CODE"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Equipment_Item_List",
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
                              "1234") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* FACTORY Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    /* EQUIP_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "EQUIP_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	i_case = 2;

	if(TRS.get_procstep(in_node) == '3')
	{
		i_case = 3;
	}

    CDB_init_cmmseqpitm(&CMMSEQPITM);
    TRS.copy(CMMSEQPITM.FACTORY, sizeof(CMMSEQPITM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSEQPITM.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID), in_node, "EQUIP_ID");
    //TRS.copy(CMMSEQPITM.ITEM_CODE, sizeof(CMMSEQPITM.ITEM_CODE), in_node, "ITEM_CODE");
    //TRS.copy(CMMSEQPITM.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID), in_node, "NEXT_EQUIP_ID");
    //TRS.copy(CMMSEQPITM.ITEM_CODE, sizeof(CMMSEQPITM.ITEM_CODE), in_node, "NEXT_ITEM_CODE");
	if(TRS.get_procstep(in_node) == '4')
	{
		i_case = 4;
		if(TRS.get_char(in_node,"ANA_DIV") == '0')
		{
			CMMSEQPITM.USE_GRR_CONT_FLAG = 'Y';			
		} 
		else if(TRS.get_char(in_node,"ANA_DIV") == '1')
		{
			CMMSEQPITM.USE_GRR_DISC_FLAG = 'Y';
		}
		else if(TRS.get_char(in_node,"ANA_DIV") == '2')
		{
			CMMSEQPITM.USE_BIAS_FLAG = 'Y';
		}
		else if(TRS.get_char(in_node,"ANA_DIV") == '3')
		{
			CMMSEQPITM.USE_LINE_FLAG = 'Y';
		}
	}

    CDB_open_cmmseqpitm(i_case, &CMMSEQPITM);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSEQPITM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
        TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_cmmseqpitm(i_case, &CMMSEQPITM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cmmseqpitm(i_case);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPITM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
            TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            CDB_close_cmmseqpitm(i_case);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /*if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.set_string(out_node, "NEXT_EQUIP_ID", CMMSEQPITM.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID));
            TRS.set_string(out_node, "NEXT_ITEM_CODE", CMMSEQPITM.ITEM_CODE, sizeof(CMMSEQPITM.ITEM_CODE));
            CDB_close_cmmseqpitm(i_case);
            break;
        }*/

        list_item = TRS.add_node(out_node, "EQUIPMENT_ITEM_LIST");

        TRS.add_string(list_item, "FACTORY", CMMSEQPITM.FACTORY, sizeof(CMMSEQPITM.FACTORY));
        TRS.add_string(list_item, "EQUIP_ID", CMMSEQPITM.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID));
        TRS.add_string(list_item, "ITEM_CODE", CMMSEQPITM.ITEM_CODE, sizeof(CMMSEQPITM.ITEM_CODE));
        TRS.add_string(list_item, "ITEM_NAME", CMMSEQPITM.ITEM_NAME, sizeof(CMMSEQPITM.ITEM_NAME));
        TRS.add_string(list_item, "ITEM_SPEC", CMMSEQPITM.ITEM_SPEC, sizeof(CMMSEQPITM.ITEM_SPEC));
        TRS.add_int(list_item, "ITEM_ORDER", CMMSEQPITM.ITEM_ORDER);
        TRS.add_double(list_item, "LSL", CMMSEQPITM.LSL);
        TRS.add_double(list_item, "USL", CMMSEQPITM.USL);
        TRS.add_string(list_item, "UNIT_CODE", CMMSEQPITM.UNIT_CODE, sizeof(CMMSEQPITM.UNIT_CODE));
        TRS.add_int(list_item, "DECIMAL_PLACE", CMMSEQPITM.DECIMAL_PLACE);
        TRS.add_char(list_item, "USE_GRR_CONT_FLAG", CMMSEQPITM.USE_GRR_CONT_FLAG);
        TRS.add_char(list_item, "USE_GRR_DISC_FLAG", CMMSEQPITM.USE_GRR_DISC_FLAG);
        TRS.add_char(list_item, "USE_BIAS_FLAG", CMMSEQPITM.USE_BIAS_FLAG);
        TRS.add_char(list_item, "USE_LINE_FLAG", CMMSEQPITM.USE_LINE_FLAG);
        TRS.add_string(list_item, "CMF_1", CMMSEQPITM.CMF_1, sizeof(CMMSEQPITM.CMF_1));
        TRS.add_string(list_item, "CMF_2", CMMSEQPITM.CMF_2, sizeof(CMMSEQPITM.CMF_2));
        TRS.add_string(list_item, "CMF_3", CMMSEQPITM.CMF_3, sizeof(CMMSEQPITM.CMF_3));
        TRS.add_string(list_item, "CMF_4", CMMSEQPITM.CMF_4, sizeof(CMMSEQPITM.CMF_4));
        TRS.add_string(list_item, "CMF_5", CMMSEQPITM.CMF_5, sizeof(CMMSEQPITM.CMF_5));
        TRS.add_string(list_item, "CMF_6", CMMSEQPITM.CMF_6, sizeof(CMMSEQPITM.CMF_6));
        TRS.add_string(list_item, "CMF_7", CMMSEQPITM.CMF_7, sizeof(CMMSEQPITM.CMF_7));
        TRS.add_string(list_item, "CMF_8", CMMSEQPITM.CMF_8, sizeof(CMMSEQPITM.CMF_8));
        TRS.add_string(list_item, "CMF_9", CMMSEQPITM.CMF_9, sizeof(CMMSEQPITM.CMF_9));
        TRS.add_string(list_item, "CMF_10", CMMSEQPITM.CMF_10, sizeof(CMMSEQPITM.CMF_10));
        TRS.add_string(list_item, "CREATE_USER_ID", CMMSEQPITM.CREATE_USER_ID, sizeof(CMMSEQPITM.CREATE_USER_ID));
        TRS.add_string(list_item, "CREATE_TIME", CMMSEQPITM.CREATE_TIME, sizeof(CMMSEQPITM.CREATE_TIME));
        TRS.add_string(list_item, "UPDATE_USER_ID", CMMSEQPITM.UPDATE_USER_ID, sizeof(CMMSEQPITM.UPDATE_USER_ID));
        TRS.add_string(list_item, "UPDATE_TIME", CMMSEQPITM.UPDATE_TIME, sizeof(CMMSEQPITM.UPDATE_TIME));
    }

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_View_Equipment_Item_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

