/*******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : TIV_view_inv_operation_list.c.c
    Description : View operation list function module

    MES Version : 4.0.0

    Function List
        - TIV_View_Inv_Operation_List()
            + View Operation list definition
        - TIV_VIEW_TIV_OPERATION_LIST()
            + Main sub function of "WIP_View_Operation_List" function
            + View Operation list definition 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/12/13	BS.KWAK			CREATE

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

int TIV_View_Inv_Operation_List_Validation(char *s_msg_code,
                                       TRSNode *in_node,  
                                       TRSNode *out_node);

/*******************************************************************************
    TIV_View_Inv_Operation_List()
        - View Operation list 
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Inv_Operation_List(TRSNode *in_node, 
                            TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_INV_OPERATION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_TIV_OPERATION_LIST", out_node);

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
    TIV_VIEW_TIV_OPERATION_LIST()
        - Main sub function of "TIV_View_Inv_Operation_List" function
        - View Operation list 
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_INV_OPERATION_LIST(char *s_msg_code,
                                 TRSNode *in_node, 
                                 TRSNode *out_node)
{
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
    //struct MATRNAMSTS_TAG MATRNAMSTS;
    int i_step = 0;
    TRSNode *list_item;

    LOG_head("TIV_VIEW_INV_OPERATION_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("mat_id", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("mat_ver", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    LOG_add("next_oper", MP_NSTR, TRS.get_string(in_node, "NEXT_OPER"));
    LOG_add("filter", MP_NSTR, TRS.get_string(in_node, "FILTER"));
    LOG_add("sec_chk_flag", MP_CHR, TRS.get_char(in_node, "SEC_CHK_FLAG"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Inv_Operation_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    /* Validation Check */
    if(TIV_View_Inv_Operation_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE) 
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mtivoprdef(&MTIVOPRDEF);
    /*View All Operation List in factory*/
    if(TRS.get_procstep(in_node) == '1')
    {
        if(TRS.get_char(in_node, "SEC_CHK_FLAG") == 'Y')
        {
            i_step = 7;
        }
        else
        {
            i_step = 1;
        }
        TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "NEXT_OPER");
        TRS.copy(MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC), in_node, "FILTER");
        MTIVOPRDEF.SEC_CHK_FLAG = TRS.get_char(in_node, "SEC_CHK_FLAG"); 

    }
  
    /*View Transit Operation List */
    else if(TRS.get_procstep(in_node) == '5')
    {
        i_step = 5;
        if(COM_isnullspace(TRS.get_string(in_node, "TARGET_FACTORY")) == MP_TRUE)
        {
            TRS.set_string(in_node, "TARGET_FACTORY", TRS.get_factory(in_node), strlen(TRS.get_factory(in_node)));
        }
        TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, "TARGET_FACTORY");
        TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "NEXT_OPER");
        TRS.copy(MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC), in_node, "FILTER");
        MTIVOPRDEF.TRANSIT_FLAG = 'Y';
    }
    /*View Inventory Operation List */
    else if(TRS.get_procstep(in_node) == '6')
    {
        i_step = 6;
        TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "NEXT_OPER");
        TRS.copy(MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC), in_node, "FILTER");
        MTIVOPRDEF.INV_FLAG = 'Y';

    }
    DBC_open_mtivoprdef(i_step, &MTIVOPRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVOPRDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mtivoprdef(i_step, &MTIVOPRDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mtivoprdef(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVOPRDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mtivoprdef(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_string(out_node, "NEXT_OPER", MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER));
            DBC_close_mtivoprdef(i_step);
            break;
        }

        list_item = TRS.add_node(out_node, "LIST");

		if (TRS.get_procstep(in_node) != '1')
		{
			TRS.add_string(list_item, "OPER", MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER));
			TRS.add_string(list_item, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
			TRS.set_string(list_item, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));
		}
		else
		{
			TRS.add_string(list_item, "FACTORY", MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
			TRS.add_string(list_item, "OPER", MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER));
			TRS.add_string(list_item, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
			TRS.add_string(list_item, "OPER_GRP_1", MTIVOPRDEF.OPER_GRP_1, sizeof(MTIVOPRDEF.OPER_GRP_1));
			TRS.add_string(list_item, "OPER_GRP_2", MTIVOPRDEF.OPER_GRP_2, sizeof(MTIVOPRDEF.OPER_GRP_2));
			TRS.add_string(list_item, "OPER_GRP_3", MTIVOPRDEF.OPER_GRP_3, sizeof(MTIVOPRDEF.OPER_GRP_3));
			TRS.add_string(list_item, "OPER_GRP_4", MTIVOPRDEF.OPER_GRP_4, sizeof(MTIVOPRDEF.OPER_GRP_4));
			TRS.add_string(list_item, "OPER_GRP_5", MTIVOPRDEF.OPER_GRP_5, sizeof(MTIVOPRDEF.OPER_GRP_5));
			TRS.add_string(list_item, "OPER_GRP_6", MTIVOPRDEF.OPER_GRP_6, sizeof(MTIVOPRDEF.OPER_GRP_6));
			TRS.add_string(list_item, "OPER_GRP_7", MTIVOPRDEF.OPER_GRP_7, sizeof(MTIVOPRDEF.OPER_GRP_7));
			TRS.add_string(list_item, "OPER_GRP_8", MTIVOPRDEF.OPER_GRP_8, sizeof(MTIVOPRDEF.OPER_GRP_8));
			TRS.add_string(list_item, "OPER_GRP_9", MTIVOPRDEF.OPER_GRP_9, sizeof(MTIVOPRDEF.OPER_GRP_9));
			TRS.add_string(list_item, "OPER_GRP_10", MTIVOPRDEF.OPER_GRP_10, sizeof(MTIVOPRDEF.OPER_GRP_10));
			TRS.add_string(list_item, "OPER_CMF_1", MTIVOPRDEF.OPER_CMF_1, sizeof(MTIVOPRDEF.OPER_CMF_1));
			TRS.add_string(list_item, "OPER_CMF_2", MTIVOPRDEF.OPER_CMF_2, sizeof(MTIVOPRDEF.OPER_CMF_2));
			TRS.add_string(list_item, "OPER_CMF_3", MTIVOPRDEF.OPER_CMF_3, sizeof(MTIVOPRDEF.OPER_CMF_3));
			TRS.add_string(list_item, "OPER_CMF_4", MTIVOPRDEF.OPER_CMF_4, sizeof(MTIVOPRDEF.OPER_CMF_4));
			TRS.add_string(list_item, "OPER_CMF_5", MTIVOPRDEF.OPER_CMF_5, sizeof(MTIVOPRDEF.OPER_CMF_5));
			TRS.add_string(list_item, "OPER_CMF_6", MTIVOPRDEF.OPER_CMF_6, sizeof(MTIVOPRDEF.OPER_CMF_6));
			TRS.add_string(list_item, "OPER_CMF_7", MTIVOPRDEF.OPER_CMF_7, sizeof(MTIVOPRDEF.OPER_CMF_7));
			TRS.add_string(list_item, "OPER_CMF_8", MTIVOPRDEF.OPER_CMF_8, sizeof(MTIVOPRDEF.OPER_CMF_8));
			TRS.add_string(list_item, "OPER_CMF_9", MTIVOPRDEF.OPER_CMF_9, sizeof(MTIVOPRDEF.OPER_CMF_9));
			TRS.add_string(list_item, "OPER_CMF_10", MTIVOPRDEF.OPER_CMF_10, sizeof(MTIVOPRDEF.OPER_CMF_10));
			TRS.add_string(list_item, "OPER_CMF_11", MTIVOPRDEF.OPER_CMF_11, sizeof(MTIVOPRDEF.OPER_CMF_11));
			TRS.add_string(list_item, "OPER_CMF_12", MTIVOPRDEF.OPER_CMF_12, sizeof(MTIVOPRDEF.OPER_CMF_12));
			TRS.add_string(list_item, "OPER_CMF_13", MTIVOPRDEF.OPER_CMF_13, sizeof(MTIVOPRDEF.OPER_CMF_13));
			TRS.add_string(list_item, "OPER_CMF_14", MTIVOPRDEF.OPER_CMF_14, sizeof(MTIVOPRDEF.OPER_CMF_14));
			TRS.add_string(list_item, "OPER_CMF_15", MTIVOPRDEF.OPER_CMF_15, sizeof(MTIVOPRDEF.OPER_CMF_15));
			TRS.add_string(list_item, "OPER_CMF_16", MTIVOPRDEF.OPER_CMF_16, sizeof(MTIVOPRDEF.OPER_CMF_16));
			TRS.add_string(list_item, "OPER_CMF_17", MTIVOPRDEF.OPER_CMF_17, sizeof(MTIVOPRDEF.OPER_CMF_17));
			TRS.add_string(list_item, "OPER_CMF_18", MTIVOPRDEF.OPER_CMF_18, sizeof(MTIVOPRDEF.OPER_CMF_18));
			TRS.add_string(list_item, "OPER_CMF_19", MTIVOPRDEF.OPER_CMF_19, sizeof(MTIVOPRDEF.OPER_CMF_19));
			TRS.add_string(list_item, "OPER_CMF_20", MTIVOPRDEF.OPER_CMF_20, sizeof(MTIVOPRDEF.OPER_CMF_20));
			TRS.add_string(list_item, "UNIT_1", MTIVOPRDEF.UNIT_1, sizeof(MTIVOPRDEF.UNIT_1));
			TRS.add_string(list_item, "UNIT_2", MTIVOPRDEF.UNIT_2, sizeof(MTIVOPRDEF.UNIT_2));
			TRS.add_string(list_item, "UNIT_3", MTIVOPRDEF.UNIT_3, sizeof(MTIVOPRDEF.UNIT_3));
			TRS.add_char(list_item, "TRANSIT_FLAG", MTIVOPRDEF.TRANSIT_FLAG);
			TRS.add_char(list_item, "SHIP_FLAG", MTIVOPRDEF.SHIP_FLAG);
			TRS.add_char(list_item, "INV_FLAG", MTIVOPRDEF.INV_FLAG);
			TRS.add_char(list_item, "ERP_FLAG", MTIVOPRDEF.ERP_FLAG);
			TRS.add_char(list_item, "START_REQUIRE_FLAG", MTIVOPRDEF.START_REQUIRE_FLAG);
			TRS.add_char(list_item, "END_OPER_FLAG", MTIVOPRDEF.END_OPER_FLAG);
			TRS.add_char(list_item, "PUSH_PULL_FLAG", MTIVOPRDEF.PUSH_PULL_FLAG);
			TRS.add_string(list_item, "LOSS_TBL", MTIVOPRDEF.LOSS_TBL, sizeof(MTIVOPRDEF.LOSS_TBL));
			TRS.add_string(list_item, "BONUS_TBL", MTIVOPRDEF.BONUS_TBL, sizeof(MTIVOPRDEF.BONUS_TBL));
			TRS.add_string(list_item, "REWORK_TBL", MTIVOPRDEF.REWORK_TBL, sizeof(MTIVOPRDEF.REWORK_TBL));
			TRS.add_char(list_item, "SEC_CHK_FLAG", MTIVOPRDEF.SEC_CHK_FLAG);
			TRS.add_string(list_item, "AREA_ID", MTIVOPRDEF.AREA_ID, sizeof(MTIVOPRDEF.AREA_ID));
			TRS.add_string(list_item, "SUB_AREA_ID", MTIVOPRDEF.SUB_AREA_ID, sizeof(MTIVOPRDEF.SUB_AREA_ID));
			TRS.add_string(list_item, "CREATE_USER_ID", MTIVOPRDEF.CREATE_USER_ID, sizeof(MTIVOPRDEF.CREATE_USER_ID));
			TRS.add_string(list_item, "CREATE_TIME", MTIVOPRDEF.CREATE_TIME, sizeof(MTIVOPRDEF.CREATE_TIME));
			TRS.add_string(list_item, "UPDATE_USER_ID", MTIVOPRDEF.UPDATE_USER_ID, sizeof(MTIVOPRDEF.UPDATE_USER_ID));
			TRS.add_string(list_item, "UPDATE_TIME", MTIVOPRDEF.UPDATE_TIME, sizeof(MTIVOPRDEF.UPDATE_TIME));
			TRS.add_string(list_item, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));
		}
	
        /*DBC_init_matrnamsts(&MATRNAMSTS);
	    TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	    memcpy(MATRNAMSTS.ATTR_TYPE, "TIV_OPER", strlen("TIV_OPER")); 
	    memcpy(MATRNAMSTS.ATTR_NAME, "OperationType", strlen("OperationType"));
        memcpy(MATRNAMSTS.ATTR_KEY, MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER));
        DBC_select_matrnamsts(1, &MATRNAMSTS);
        if(DB_error_code != DB_SUCCESS)
        {
	    	if(DB_error_code != DB_NOT_FOUND)
	    	{
	    		strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
	    		
                TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS.FACTORY), MATRNAMSTS.FACTORY);
	    	    TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
	    	    TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
	    	    TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
	    	}
        }

        TRS.add_string(list_item, "ATTR_OPER_TYPE", MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS.ATTR_VALUE));*/
    }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Inv_Operation_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}
/*******************************************************************************
WIP_View_Operation_List_Validation()
- Validation Check sub function of "WIP_View_Operation_List" function
return Value
- int : 1 (MP_TRUE) or 0 (MP_FALSE)
Arguments
- char *s_msg_code : Error Message Code
- TRSNode *in_node
- TRSNode *out_node
*******************************************************************************/
int TIV_View_Inv_Operation_List_Validation(char *s_msg_code,
                                       TRSNode *in_node,  
                                       TRSNode *out_node)
{
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "123456") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_check_value(s_msg_code,
                       in_node,
                       out_node,
                       "FACTORY",
                       'Y',
                       'Y',
                       0x00,
                       0x00,
                       0x00) == MP_FALSE)
    {
        return MP_FALSE;
    }
	   
    return MP_TRUE;
}
