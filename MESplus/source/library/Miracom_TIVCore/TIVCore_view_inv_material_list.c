/*******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : TIV_view_inv_material_list.c.c
    Description : Create/Update/Delete Material List

    MES Version : 4.0.0

    Function List
        - TIV_view_inv_material_list()
            + View Material List
        - TIV_VIEW_TIV_MATERIAL_LIST()
            + Main sub function of "TIV_view_inv_material_list" function
            + View Material List

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ------------------------------ ---------------------------------------------
    1     2012/12/13   BS.KWAK			CREATE

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

/*******************************************************************************
    TIV_View_Inv_Material_List()
        - View Material List
    Return Value
        - Integer : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node :Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Inv_Material_List(TRSNode *in_node, 
                           TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_INV_MATERIAL_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_TIV_MATERIAL_LIST", out_node);

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
    TIV_VIEW_TIV_MATERIAL_LIST()
        - Main sub function of "TIV_View_Inv_Material_List" function
        - View Material List
        - h_proc_step  
          1 : view exclude deleted material list
          2 : view include deleted material list
          3 : view material list by operation
    return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_INV_MATERIAL_LIST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MATRNAMSTS_TAG MATRNAMSTS;
    struct MATRNAMSTS_TAG MATRNAMSTS_OPER;
    int i_step = 0;
    int i_mat_ver = 0;
    TRSNode *list_item;

    LOG_head("TIV_VIEW_INV_MATERIAL_LIST");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("mat_type", MP_NSTR, TRS.get_string(in_node, "MAT_TYPE"));
    LOG_add("next_mat_id", MP_NSTR, TRS.get_string(in_node, "NEXT_MAT_ID"));
    LOG_add("next_mat_ver", MP_INT, TRS.get_int(in_node, "NEXT_MAT_VER"));
    LOG_add("filter", MP_NSTR, TRS.get_string(in_node, "FILTER"));
    LOG_add("delete_flag", MP_CHR, TRS.get_char(in_node, "DELETE_FLAG"));
    LOG_add("deactive_flag", MP_CHR, TRS.get_char(in_node, "DEACTIVE_FLAG"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Inv_Material_List",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1239AB") == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

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

    DBC_init_mtivmatdef(&MTIVMATDEF);
    TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVMATDEF.FACTORY), in_node, IN_FACTORY);

    /* h_proc_step = '1' : Last active version */
    /* h_proc_step = '2' : All version */

    TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "NEXT_MAT_ID");
    MTIVMATDEF.MAT_VER  = TRS.get_int(in_node, "NEXT_MAT_VER");

    TRS.copy(MTIVMATDEF.MAT_TYPE, sizeof(MTIVMATDEF.MAT_TYPE), in_node, "MAT_TYPE");
    TRS.copy(MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC), in_node, "FILTER");

    /* ' ' - Undeleted Material, 'Y' - Deleted Material,  '%' - All Material */
    MTIVMATDEF.DELETE_FLAG  = TRS.get_char(in_node, "DELETE_FLAG");

    /* ' ' - Active Material,    'Y' - Deactive Material, '%' - All Material */
    MTIVMATDEF.DEACTIVE_FLAG  = TRS.get_char(in_node, "DEACTIVE_FLAG");

    if(TRS.get_procstep(in_node) == '1')
    {
        i_step = 1;
    }
    else if(TRS.get_procstep(in_node) == '2')
    {
        i_step = 6;
    }
    else if(TRS.get_procstep(in_node) == '3')
    {
        TRS.copy(MTIVMATDEF.VENDOR_ID, sizeof(MTIVMATDEF.VENDOR_ID), in_node, "VENDOR_ID");
        i_step = 8;
    }
    else if(TRS.get_procstep(in_node) == '9')
    {
        i_step = 9;
        TRS.copy(MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC), in_node, "LOT_ID");
    }
    else if(TRS.get_procstep(in_node) == 'A')
    {
        i_step = 10;
        TRS.copy(MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID), in_node, "MAT_ID");
        MTIVMATDEF.MAT_VER  = TRS.get_int(in_node, "MAT_VER");
    }
    else if(TRS.get_procstep(in_node) == 'B')
    {
        i_step = 11;
        TRS.copy(MTIVMATDEF.MAT_CMF_1, sizeof(MTIVMATDEF.MAT_CMF_1), in_node, "PACKAGE_CODE");
    }

    DBC_open_mtivmatdef(i_step, &MTIVMATDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MTIVMATDEF OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
        TRS.add_fieldmsg(out_node, "MAT_TYPE", MP_STR, sizeof(MTIVMATDEF.MAT_TYPE), MTIVMATDEF.MAT_TYPE);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mtivmatdef(i_step, &MTIVMATDEF);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mtivmatdef(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MTIVMATDEF FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
            TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);
            TRS.add_fieldmsg(out_node, "MAT_TYPE", MP_STR, sizeof(MTIVMATDEF.MAT_TYPE), MTIVMATDEF.MAT_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            DBC_close_mtivmatdef(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        if(COM_check_node_length(out_node) == MP_FALSE)
        {
            TRS.add_string(out_node, "NEXT_MAT_ID", MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
            DBC_close_mtivmatdef(i_step);
            break;
        }

        list_item = TRS.add_node(out_node, "LIST");

        TRS.add_string(list_item, "MAT_ID", MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
        TRS.add_int(list_item, "MAT_VER", MTIVMATDEF.MAT_VER);
        TRS.add_string(list_item, "MAT_DESC", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));
        TRS.add_string(list_item, "MAT_SHORT_DESC", MTIVMATDEF.MAT_SHORT_DESC, sizeof(MTIVMATDEF.MAT_SHORT_DESC));
        TRS.add_char(list_item, "DELETE_FLAG", MTIVMATDEF.DELETE_FLAG);
        TRS.add_char(list_item, "DEACTIVE_FLAG", MTIVMATDEF.DEACTIVE_FLAG);
        TRS.add_string(list_item, "UNIT_1", MTIVMATDEF.UNIT_1, sizeof(MTIVMATDEF.UNIT_1));
        TRS.add_string(list_item, "UNIT_2", MTIVMATDEF.UNIT_2, sizeof(MTIVMATDEF.UNIT_2));
        TRS.add_string(list_item, "UNIT_3", MTIVMATDEF.UNIT_3, sizeof(MTIVMATDEF.UNIT_3));
        TRS.add_double(list_item, "DEF_QTY_1", MTIVMATDEF.DEF_QTY_1);
		TRS.add_string(list_item, "MAT_CMF_1", MTIVMATDEF.MAT_CMF_1, sizeof(MTIVMATDEF.MAT_CMF_1));
		TRS.add_string(list_item, "MAT_CMF_2", MTIVMATDEF.MAT_CMF_2, sizeof(MTIVMATDEF.MAT_CMF_2));
		TRS.add_string(list_item, "MAT_CMF_3", MTIVMATDEF.MAT_CMF_3, sizeof(MTIVMATDEF.MAT_CMF_3));
		TRS.add_string(list_item, "MAT_CMF_4", MTIVMATDEF.MAT_CMF_4, sizeof(MTIVMATDEF.MAT_CMF_4));
		TRS.add_string(list_item, "MAT_CMF_5", MTIVMATDEF.MAT_CMF_5, sizeof(MTIVMATDEF.MAT_CMF_5));
		TRS.add_string(list_item, "MAT_CMF_6", MTIVMATDEF.MAT_CMF_6, sizeof(MTIVMATDEF.MAT_CMF_6));
		TRS.add_string(list_item, "MAT_CMF_7", MTIVMATDEF.MAT_CMF_7, sizeof(MTIVMATDEF.MAT_CMF_7));
		TRS.add_string(list_item, "MAT_CMF_8", MTIVMATDEF.MAT_CMF_8, sizeof(MTIVMATDEF.MAT_CMF_8));
		TRS.add_string(list_item, "MAT_CMF_9", MTIVMATDEF.MAT_CMF_9, sizeof(MTIVMATDEF.MAT_CMF_9));
		TRS.add_string(list_item, "MAT_CMF_10", MTIVMATDEF.MAT_CMF_10, sizeof(MTIVMATDEF.MAT_CMF_10));
		TRS.add_string(list_item, "MAT_CMF_11", MTIVMATDEF.MAT_CMF_11, sizeof(MTIVMATDEF.MAT_CMF_11));
		TRS.add_string(list_item, "MAT_CMF_12", MTIVMATDEF.MAT_CMF_12, sizeof(MTIVMATDEF.MAT_CMF_12));
		TRS.add_string(list_item, "MAT_CMF_13", MTIVMATDEF.MAT_CMF_13, sizeof(MTIVMATDEF.MAT_CMF_13));
		TRS.add_string(list_item, "MAT_CMF_14", MTIVMATDEF.MAT_CMF_14, sizeof(MTIVMATDEF.MAT_CMF_14));
		TRS.add_string(list_item, "MAT_CMF_15", MTIVMATDEF.MAT_CMF_15, sizeof(MTIVMATDEF.MAT_CMF_15));
		TRS.add_string(list_item, "MAT_CMF_16", MTIVMATDEF.MAT_CMF_16, sizeof(MTIVMATDEF.MAT_CMF_16));
		TRS.add_string(list_item, "MAT_CMF_17", MTIVMATDEF.MAT_CMF_17, sizeof(MTIVMATDEF.MAT_CMF_17));
		TRS.add_string(list_item, "MAT_CMF_18", MTIVMATDEF.MAT_CMF_18, sizeof(MTIVMATDEF.MAT_CMF_18));
		TRS.add_string(list_item, "MAT_CMF_19", MTIVMATDEF.MAT_CMF_19, sizeof(MTIVMATDEF.MAT_CMF_19));
		TRS.add_string(list_item, "MAT_CMF_20", MTIVMATDEF.MAT_CMF_20, sizeof(MTIVMATDEF.MAT_CMF_20));

        DBC_init_matrnamsts(&MATRNAMSTS);
	    TRS.copy(MATRNAMSTS.FACTORY, sizeof(MATRNAMSTS.FACTORY), in_node, IN_FACTORY);
	    memcpy(MATRNAMSTS.ATTR_TYPE, MP_ATTR_TYPE_INV_MATERIAL, sizeof(MATRNAMSTS.ATTR_TYPE));
	    memcpy(MATRNAMSTS.ATTR_NAME, "DefaultOperation", strlen("DefaultOperation"));
        memcpy(MATRNAMSTS.ATTR_KEY, MTIVMATDEF.MAT_ID, sizeof(MTIVMATDEF.MAT_ID));
        i_mat_ver = MTIVMATDEF.MAT_VER;
        memcpy(MATRNAMSTS.ATTR_KEY + COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))," : ", 3);
        MATRNAMSTS.ATTR_KEY[COM_string_length(MATRNAMSTS.ATTR_KEY, sizeof(MATRNAMSTS.ATTR_KEY))+1]=i_mat_ver + 48;
        DBC_select_matrnamsts(1, &MATRNAMSTS);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);

                TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS.ATTR_TYPE), MATRNAMSTS.ATTR_TYPE);
		        TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS.ATTR_NAME), MATRNAMSTS.ATTR_NAME);
                TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS.ATTR_KEY), MATRNAMSTS.ATTR_KEY);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE; 
			}
        }

        DBC_init_matrnamsts(&MATRNAMSTS_OPER);
	    TRS.copy(MATRNAMSTS_OPER.FACTORY, sizeof(MATRNAMSTS_OPER.FACTORY), in_node, IN_FACTORY);
	    memcpy(MATRNAMSTS_OPER.ATTR_TYPE, "TIV_OPER", strlen("TIV_OPER")); 
	    memcpy(MATRNAMSTS_OPER.ATTR_NAME, "OperationType", strlen("OperationType"));
	    memcpy(MATRNAMSTS_OPER.ATTR_KEY, MATRNAMSTS.ATTR_VALUE, sizeof(MATRNAMSTS_OPER.ATTR_KEY));
        DBC_select_matrnamsts(1, &MATRNAMSTS_OPER);
        if(DB_error_code != DB_SUCCESS)
        {
	    	if(DB_error_code != DB_NOT_FOUND)
	    	{
	    		strcpy(s_msg_code, "INV-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
	    		
                TRS.add_fieldmsg(out_node, "MATRNAMSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MATRNAMSTS_OPER.FACTORY), MATRNAMSTS_OPER.FACTORY);
	    	    TRS.add_fieldmsg(out_node, "ATTR_TYPE", MP_STR, sizeof(MATRNAMSTS_OPER.ATTR_TYPE), MATRNAMSTS_OPER.ATTR_TYPE);
	    	    TRS.add_fieldmsg(out_node, "ATTR_NAME", MP_STR, sizeof(MATRNAMSTS_OPER.ATTR_NAME), MATRNAMSTS_OPER.ATTR_NAME);
	    	    TRS.add_fieldmsg(out_node, "ATTR_KEY", MP_STR, sizeof(MATRNAMSTS_OPER.ATTR_KEY), MATRNAMSTS_OPER.ATTR_KEY);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.category = MP_LOG_CATE_COMMON;
                return MP_FALSE;
	    	}
        }
        TRS.add_string(list_item, "OPER_TYPE", MATRNAMSTS_OPER.ATTR_VALUE, sizeof(MATRNAMSTS_OPER.ATTR_VALUE));
    }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Inv_Material_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

