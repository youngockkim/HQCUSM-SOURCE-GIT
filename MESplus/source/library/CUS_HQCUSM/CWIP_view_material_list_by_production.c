/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_material_list_by_production.c
	Description : View Material List by Production

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Material_List_By_Production()
			+ View Material List
		- CWIP_VIEW_MATERIAL_LIST_BY_PRODUCTION()
			+ Main sub function of CWIP_View_Material_List_By_Production function
			+ View Material List definition
		- CWIP_View_Material_List_By_Production_Validation()
			+ Main sub function of CWIP_View_Material_List_By_Production function
			+ Check the condition for view Material List
	Detail Description
		- CWIP_View_Material_List_By_Production()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2019/11/11  Miracom        Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Material_List_By_Production_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Material_List_By_Production()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Material_List_By_Production(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_MATERIAL_LIST_BY_PRODUCTION(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CWIP_View_Material_List_By_Production", out_node);

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
	CWIP_View_Material_List_By_Production()
		- Main sub function of "CWIP_View_Material_List_By_Production" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_MATERIAL_LIST_BY_PRODUCTION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
	struct RSUMHORMOV_TAG RSUMHORMOV;
    struct MWIPMATDEF_TAG MWIPMATDEF;
//	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    TRSNode *list_item;

    int i_step;

    LOG_head("CWIP_View_Material_List_By_Production");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CWIP_View_Material_List_By_Production_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	CDB_init_rsumhormov(&RSUMHORMOV);
	TRS.copy(RSUMHORMOV.FACTORY, sizeof(RSUMHORMOV.FACTORY), in_node, IN_FACTORY);
	TRS.copy(RSUMHORMOV.WORK_DATE, sizeof(RSUMHORMOV.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(RSUMHORMOV.LINE_ID, sizeof(RSUMHORMOV.LINE_ID), in_node, "LINE_ID");
	memcpy(RSUMHORMOV.OPER, HQCEL_M1_TABBER_OPER, strlen(HQCEL_M1_TABBER_OPER));
	
	
    i_step = 2;    

    CDB_open_rsumhormov(i_step, &RSUMHORMOV);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "RSUMHORMOV OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMHORMOV.FACTORY), RSUMHORMOV.FACTORY);
		TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMHORMOV.WORK_DATE), RSUMHORMOV.WORK_DATE);
		TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMHORMOV.LINE_ID), RSUMHORMOV.LINE_ID);
		TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(RSUMHORMOV.OPER), RSUMHORMOV.OPER);

        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        CDB_fetch_rsumhormov(i_step, &RSUMHORMOV);
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0003");
            TRS.add_fieldmsg(out_node, "RSUMHORMOV FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMHORMOV.FACTORY), RSUMHORMOV.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMHORMOV.WORK_DATE), RSUMHORMOV.WORK_DATE);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMHORMOV.LINE_ID), RSUMHORMOV.LINE_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(RSUMHORMOV.OPER), RSUMHORMOV.OPER);

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;

            CDB_close_rsumhormov(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "RSUMHORMOV OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMHORMOV.FACTORY), RSUMHORMOV.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMHORMOV.WORK_DATE), RSUMHORMOV.WORK_DATE);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMHORMOV.LINE_ID), RSUMHORMOV.LINE_ID);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(RSUMHORMOV.OPER), RSUMHORMOV.OPER);

			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			CDB_close_rsumhormov(i_step);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
        }

        /* Construct out node */

		DBC_init_mwipmatdef(&MWIPMATDEF);
		TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPMATDEF.MAT_ID, RSUMHORMOV.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATDEF.MAT_VER = 1;
		DBC_select_mwipmatdef(1, &MWIPMATDEF);

        list_item = TRS.add_node(out_node, "MAT_LIST");
		TRS.add_string(list_item, "MAT_ID", MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));		
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Material_List_By_Production_Validation()
		- Main sub function of "CWIP_View_Material_List_By_Production" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Material_List_By_Production_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1234567") == MP_FALSE)
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