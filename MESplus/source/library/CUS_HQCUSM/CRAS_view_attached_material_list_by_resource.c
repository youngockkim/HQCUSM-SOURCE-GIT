/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CRAS_view_attached_material_list_by_resource.c
	Description : View Attached Material List Information

    MES Version : 5.3.6.4

	Function List  
		- CRAS_View_Attached_Material_List_By_Resource()
			+ View Attached Material List
		- CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE()
			+ Main sub function of CRAS_View_Attached_Material_List_By_Resource function
		- CRAS_View_Attached_Material_List_By_Resource_Validation()
			+ Main sub function of CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE function
	Detail Description
		- CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_View_Attached_Material_List_By_Resource_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CRAS_View_Attached_Material_List_By_Resource()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Attached_Material_List_By_Resource(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE", out_node);

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
	CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE()
		- Main sub function of "CRAS_View_Attached_Material_List_By_Resource" function
		- View Lot
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct CRASRESMAT_TAG CRASRESMAT;
    struct MWIPMATDEF_TAG MWIPMATDEF;
    TRSNode *list_item;

    int i_step;

    LOG_head("CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CRAS_View_Attached_Material_List_By_Resource_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Attached Material List by Resource */
    i_step = 2;

    CDB_init_crasresmat(&CRASRESMAT);
    TRS.copy(CRASRESMAT.FACTORY, sizeof(CRASRESMAT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CRASRESMAT.RES_ID, sizeof(CRASRESMAT.RES_ID), in_node, "RES_ID");

    CDB_open_crasresmat(i_step, &CRASRESMAT);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "CRASRESMAT OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1) 
    {
        CDB_fetch_crasresmat(i_step, &CRASRESMAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "RAS-0320"); /* The attached material list does not exist. */
            TRS.add_fieldmsg(out_node, "CRASRESMAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;

            CDB_close_crasresmat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "CRASRESMAT FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CRASRESMAT.FACTORY), CRASRESMAT.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CRASRESMAT.RES_ID), CRASRESMAT.RES_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_crasresmat(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Get material data */
        DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MWIPMATDEF.MAT_ID, CRASRESMAT.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
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
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "LIST");
        TRS.add_int(list_item, "SEQ", CRASRESMAT.SEQ);
        TRS.add_string(list_item, "RES_ID", CRASRESMAT.RES_ID, sizeof(CRASRESMAT.RES_ID));
        TRS.add_string(list_item, "INV_BARCODE_ID", CRASRESMAT.INV_BARCODE_ID, sizeof(CRASRESMAT.INV_BARCODE_ID));
        TRS.add_string(list_item, "INV_MAT_ID", CRASRESMAT.INV_MAT_ID, sizeof(CRASRESMAT.INV_MAT_ID));
        TRS.add_string(list_item, "INV_LOT_ID", CRASRESMAT.INV_LOT_ID, sizeof(CRASRESMAT.INV_LOT_ID));
        TRS.add_string(list_item, "MAT_ID", CRASRESMAT.MAT_ID, sizeof(CRASRESMAT.MAT_ID));
        TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
        TRS.add_string(list_item, "ATTACH_TIME", CRASRESMAT.ATTACH_TIME, sizeof(CRASRESMAT.ATTACH_TIME));
		TRS.add_string(list_item, "MAT_TYPE", CRASRESMAT.MATERIALS_KINDS, sizeof(CRASRESMAT.MATERIALS_KINDS));
		TRS.add_string(list_item, "ATTACH_USER_ID", CRASRESMAT.ATTACH_USER_ID, sizeof(CRASRESMAT.ATTACH_USER_ID));
        TRS.add_double(list_item, "ATTACH_QTY", CRASRESMAT.ATTACH_QTY);
        TRS.add_double(list_item, "USED_QTY", CRASRESMAT.USED_QTY);
        TRS.add_double(list_item, "REMAIN_QTY", CRASRESMAT.REMAIN_QTY);
        TRS.add_string(list_item, "UNIT", CRASRESMAT.UNIT, sizeof(CRASRESMAT.UNIT));
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CRAS_View_Attached_Material_List_By_Resource_Validation()
		- Main sub function of "CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE" function
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Attached_Material_List_By_Resource_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
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