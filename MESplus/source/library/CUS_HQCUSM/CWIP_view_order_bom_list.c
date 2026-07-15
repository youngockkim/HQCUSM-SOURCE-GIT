/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_order_bom_list.c
	Description : View Order BOM List Information

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Order_BOM_List()
			+ View Lot
		- CWIP_VIEW_ORDER_BOM_LIST()
			+ Main sub function of CWIP_View_Order_BOM_List function
			+ View Order BOM definition
		- CWIP_View_Order_BOM_List_Validation()
			+ Main sub function of CWIP_VIEW_ORDER_BOM_LIST function
			+ Check the condition for view Order BOM List
	Detail Description
		- CWIP_VIEW_ORDER_BOM_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Order_BOM_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Order_BOM_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Order_BOM_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_ORDER_BOM_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_VIEW_ORDER_BOM_LIST", out_node);

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
	CWIP_VIEW_ORDER_BOM_LIST()
		- Main sub function of "CWIP_View_Order_BOM_List" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_ORDER_BOM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CWIPORDBOM_TAG CWIPORDBOM;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    TRSNode *list_item;

    int i_step = 0;

    LOG_head("CWIP_VIEW_ORDER_BOM_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_View_Order_BOM_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* 
        Step 1: Order BOM List by Factory and Order ID
        Step 2: Order BOM List by Factory and Order ID (Only 'CELL' type)
    */

    CDB_init_cwipordbom(&CWIPORDBOM);
    TRS.copy(CWIPORDBOM.FACTORY, sizeof(CWIPORDBOM.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID), in_node, "ORDER_ID");

    if (TRS.get_procstep(in_node) == '1')
    {
        i_step = 2;
    }
    else if (TRS.get_procstep(in_node) == '2')
    {
        i_step = 3;
        memcpy(CWIPORDBOM.MATE_TYPE, "CELL", strlen("CELL"));
    }
	// IS-21-09-039 Request on MES OI & EMIPlus Report - "Material Termination"
	else if (TRS.get_procstep(in_node) == '3')
    {
        i_step = 10;

		TRS.copy(CWIPORDBOM.MAT_ID, sizeof(CWIPORDBOM.MAT_ID), in_node, "MAT_ID");
    }
    else
    {
        i_step = 2;
    }

    CDB_open_cwipordbom(i_step, &CWIPORDBOM);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "BOM-0004");
        TRS.add_fieldmsg(out_node, "CWIPORDBOM OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
        TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDBOM.ORDER_ID), CWIPORDBOM.ORDER_ID);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1) 
    {
        CDB_fetch_cwipordbom(i_step, &CWIPORDBOM);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwipordbom(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "BOM-0004");
            TRS.add_fieldmsg(out_node, "CWIPORDBOM FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPORDBOM.FACTORY), CWIPORDBOM.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDBOM.ORDER_ID), CWIPORDBOM.ORDER_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_cwipordbom(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Get material data */
        DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPMATDEF.MAT_ID, CWIPORDBOM.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
        MWIPMATDEF.MAT_VER = 1;
        DBC_select_mwipmatdef(1, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
                TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
                TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
                TRS.add_dberrmsg(out_node,DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Close 추가
				CDB_close_cwipordbom(i_step);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "LIST");
        TRS.add_int(list_item, "SEQ", CWIPORDBOM.SEQ);
        TRS.add_string(list_item, "ORDER_ID", CWIPORDBOM.ORDER_ID, sizeof(CWIPORDBOM.ORDER_ID));
        TRS.add_string(list_item, "MAT_ID", CWIPORDBOM.MAT_ID, sizeof(CWIPORDBOM.MAT_ID));
        TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
        TRS.add_double(list_item, "QTY", CWIPORDBOM.QTY);
        TRS.add_string(list_item, "EFFICIENCY", CWIPORDBOM.CELL_POWER_GRADE_1, sizeof(CWIPORDBOM.CELL_POWER_GRADE_1));
        TRS.add_string(list_item, "GRADE", CWIPORDBOM.CELL_POWER_GRADE_2, sizeof(CWIPORDBOM.CELL_POWER_GRADE_2));

		// IS-21-09-039 Request on MES OI & EMIPlus Report - "Material Termination"
		TRS.add_string(list_item, "MATE_TYPE", CWIPORDBOM.MATE_TYPE, sizeof(CWIPORDBOM.MATE_TYPE));
		TRS.add_string(list_item, "UNIT_ID", CWIPORDBOM.UNIT_ID, sizeof(CWIPORDBOM.UNIT_ID));
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Order_BOM_List_Validation()
		- Main sub function of "CWIP_VIEW_ORDER_BOM_LIST" function
		- Check the condition for view Lot
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Order_BOM_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              //"12") == MP_FALSE)
							  // // IS-21-09-039 Request on MES OI & EMIPlus Report - "Material Termination"
							  "123") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
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


    return MP_TRUE;
}