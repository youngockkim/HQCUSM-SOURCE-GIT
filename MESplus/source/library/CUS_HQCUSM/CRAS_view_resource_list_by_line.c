/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CRAS_view_resource_list_by_line.c
	Description : View Resource List By Line

    MES Version : 5.3.6.4

	Function List  
		- CRAS_View_Resource_List_By_Line()
			+ View Lot
		- CRAS_VIEW_RESOURCE_LIST_BY_LINE()
			+ Main sub function of CRAS_View_Resource_List_By_Line function
			+ View Operation List definition
		- CRAS_View_Resource_List_By_Line_Validation()
			+ Main sub function of CRAS_View_Resource_List_By_Line function
			+ Check the condition for view Operation List
	Detail Description
		- CRAS_View_Resource_List_By_Line()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_View_Resource_List_By_Line_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CRAS_View_Resource_List_By_Line()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Resource_List_By_Line(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CRAS_VIEW_RESOURCE_LIST_BY_LINE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CRAS_View_Resource_List_By_Line", out_node);

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
	CRAS_View_Resource_List_By_Line()
		- Main sub function of "CRAS_View_Resource_List_By_Line" function
		- View Operation List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_VIEW_RESOURCE_LIST_BY_LINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MRASRESDEF_TAG MRASRESDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

    TRSNode *list_item;

    int i_step;

    LOG_head("CRAS_View_Resource_List_By_Line");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Resource List by Line and Operation
    */

    if(CRAS_View_Resource_List_By_Line_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
    DBC_init_mrasresdef(&MRASRESDEF);
    TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MRASRESDEF.RES_CMF_1, sizeof(MRASRESDEF.RES_CMF_1), in_node, "LINE_ID");
	TRS.copy(MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2), in_node, "OPER");

    i_step = 0;

    /* 
        Step 1 ~ 6: Resource List
        Step 7:     Resource List by Recipe Equipment
    */

    if (TRS.get_procstep(in_node) == '1')
    {
        i_step = 102;
    }
    else if (TRS.get_procstep(in_node) == '2')
    {
        i_step = 101;
    }
    else if (TRS.get_procstep(in_node) == '3')
    {
        i_step = 103;

        TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
    }
	else if (TRS.get_procstep(in_node) == '4')
	{
        i_step = 104;
	}
	else if (TRS.get_procstep(in_node) == '5')
    {
        i_step = 105;
    }
	else if (TRS.get_procstep(in_node) == '6')
    {
		TRS.copy(MRASRESDEF.SUB_AREA_ID, sizeof(MRASRESDEF.SUB_AREA_ID), in_node, "SUB_AREA_ID");
        i_step = 106;
    }
    else if (TRS.get_procstep(in_node) == '7')
    {
        i_step = 108;
    }
	else if (TRS.get_procstep(in_node) == '9')
    {
		TRS.copy(MRASRESDEF.RES_CMF_1, sizeof(MRASRESDEF.RES_CMF_1), in_node, "RES_CMF_1");
		TRS.copy(MRASRESDEF.RES_CMF_11, sizeof(MRASRESDEF.RES_CMF_11), in_node, "RES_CMF_11");

        i_step = 201;
    }
    else /* default */
    {
        i_step = 0;
    }

    DBC_open_mrasresdef(i_step, &MRASRESDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0004");
        TRS.add_fieldmsg(out_node, "MRASRESDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(MRASRESDEF.RES_CMF_1), MRASRESDEF.RES_CMF_1);
		TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(MRASRESDEF.RES_CMF_2), MRASRESDEF.RES_CMF_2);

        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mrasresdef(i_step, &MRASRESDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "RAS-0003");
            TRS.add_fieldmsg(out_node, "MMRASRESDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(MRASRESDEF.RES_CMF_1), MRASRESDEF.RES_CMF_1);
			TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(MRASRESDEF.RES_CMF_2), MRASRESDEF.RES_CMF_2);

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;

            DBC_close_mrasresdef(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "MWIPOPRDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(MRASRESDEF.RES_CMF_1), MRASRESDEF.RES_CMF_1);
			TRS.add_fieldmsg(out_node, "OPER_ID", MP_STR, sizeof(MRASRESDEF.RES_CMF_2), MRASRESDEF.RES_CMF_2);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mrasresdef(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Construct out node */
        list_item = TRS.add_node(out_node, "RES_LIST");
        TRS.add_string(list_item, "RES_ID", MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
        TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));
		TRS.add_string(list_item, "SUB_AREA_ID", MRASRESDEF.SUB_AREA_ID, sizeof(MRASRESDEF.SUB_AREA_ID));

		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "SUB_AREA", strlen("SUB_AREA"));
		memcpy(MGCMTBLDAT.KEY_1, MRASRESDEF.SUB_AREA_ID, sizeof(MRASRESDEF.SUB_AREA_ID));

		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
			}
			else
			{
				strcpy(s_msg_code, "GCM-0008");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		else
		{
			TRS.add_string(list_item, "SUB_AREA_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
		}
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CRAS_View_Resource_List_By_Line_Validation()
		- Main sub function of "CRAS_View_Resource_List_By_Line" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_View_Resource_List_By_Line_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123456789") == MP_FALSE)
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