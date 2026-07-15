/*******************************************************************************

    System      : MESplus
    Module      : INV
    File Name   : TIV_view_material_list.c
    Description : Create/Update/Delete Material List

    MES Version : 4.0.0

    Function List
        - TIV_View_Material_List()
            + View Material List
        - TIV_VIEW_MATERIAL_LIST()
            + Main sub function of "TIV_View_Material_List" function
            + View Material List

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/11/30  H.K.Kim        Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

/*******************************************************************************
    TIV_View_Material_List()
        - View Material List
    Return Value
        - Integer : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node :Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material_List(TRSNode *in_node, 
                           TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_MATERIAL_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_MATERIAL_LIST", out_node);

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
    TIV_VIEW_MATERIAL_LIST()
        - Main sub function of "TIV_View_Material_List" function
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
int TIV_VIEW_MATERIAL_LIST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    /* 
        20140829 Blocked for Source Merge by Derek, Oh 
        TAP_TABLE and DBU related logic block
    */
   // struct MWIPMATDEF_TAG MWIPMATDEF;
   // int i_step = 0;
   // TRSNode *list_item;

   // LOG_head("TIV_VIEW_MATERIAL_LIST");
   // LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
   // LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
   // LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
   // LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
   // LOG_add("mat_type", MP_NSTR, TRS.get_string(in_node, "MAT_TYPE"));
   // LOG_add("next_mat_id", MP_NSTR, TRS.get_string(in_node, "NEXT_MAT_ID"));
   // LOG_add("next_mat_ver", MP_INT, TRS.get_int(in_node, "NEXT_MAT_VER"));
   // LOG_add("filter", MP_NSTR, TRS.get_string(in_node, "FILTER"));
   // LOG_add("delete_flag", MP_CHR, TRS.get_char(in_node, "DELETE_FLAG"));
   // LOG_add("deactive_flag", MP_CHR, TRS.get_char(in_node, "DEACTIVE_FLAG"));
   // COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

   // if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_List",
   //                          MP_UPOINT_BEFORE,
   //                          in_node,
   //                          out_node) == MP_FALSE)     return MP_FALSE;
   // if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


   // /* ProcStep Validation */
   //  if(COM_service_validation(s_msg_code,
   //                           in_node,
   //                           out_node,
   //                           TRS.get_procstep(in_node),
   //                           "12") == MP_FALSE)
   // {
   //     COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
   //     return MP_FALSE;
   // }

   // if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
   // {
   //     strcpy(s_msg_code, "WIP-0001");
   //     TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

   //     gs_log_type.type = MP_LOG_ERROR;
   //     gs_log_type.e_type = MP_LOG_E_VALIDATION;
   //     gs_log_type.category = MP_LOG_CATE_VIEW;
   //     COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
   //     return MP_FALSE;
   // }

   // DBU_init_mwipmatdef(&MWIPMATDEF);
   // TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);

   // if(TRS.get_procstep(in_node) == '1' || TRS.get_procstep(in_node) == '2')
   // {
   //     /* h_proc_step = '1' : Last active version */
   //     /* h_proc_step = '2' : All version */

   //     TRS.copy(MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID), in_node, "NEXT_MAT_ID");
   //     MWIPMATDEF.MAT_VER  = TRS.get_int(in_node, "NEXT_MAT_VER");

   //     TRS.copy(MWIPMATDEF.MAT_TYPE, sizeof(MWIPMATDEF.MAT_TYPE), in_node, "MAT_TYPE");
   //     TRS.copy(MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC), in_node, "FILTER");

   //     /* ' ' - Undeleted Material, 'Y' - Deleted Material,  '%' - All Material */
   //     MWIPMATDEF.DELETE_FLAG  = TRS.get_char(in_node, "DELETE_FLAG");

   //     /* ' ' - Active Material,    'Y' - Deactive Material, '%' - All Material */
   //     MWIPMATDEF.DEACTIVE_FLAG  = TRS.get_char(in_node, "DEACTIVE_FLAG");

   //     TRS.copy(MWIPMATDEF.MAT_GRP_1, sizeof(MWIPMATDEF.MAT_GRP_1), in_node, "MAT_GRP_1");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_2, sizeof(MWIPMATDEF.MAT_GRP_2), in_node, "MAT_GRP_2");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_3, sizeof(MWIPMATDEF.MAT_GRP_3), in_node, "MAT_GRP_3");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_4, sizeof(MWIPMATDEF.MAT_GRP_4), in_node, "MAT_GRP_4");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_5, sizeof(MWIPMATDEF.MAT_GRP_5), in_node, "MAT_GRP_5");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_6, sizeof(MWIPMATDEF.MAT_GRP_6), in_node, "MAT_GRP_6");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_7, sizeof(MWIPMATDEF.MAT_GRP_7), in_node, "MAT_GRP_7");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_8, sizeof(MWIPMATDEF.MAT_GRP_8), in_node, "MAT_GRP_8");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_9, sizeof(MWIPMATDEF.MAT_GRP_9), in_node, "MAT_GRP_9");
   //     TRS.copy(MWIPMATDEF.MAT_GRP_10, sizeof(MWIPMATDEF.MAT_GRP_10), in_node, "MAT_GRP_10");

   //     if(TRS.get_procstep(in_node) == '1')
   //     {
   //         //i_step = 7;
			//i_step = 104;
   //     }
   //     else if(TRS.get_procstep(in_node) == '2')
   //     {
   //         i_step = 8;
   //     }


   //     DBU_open_mwipmatdef(i_step, &MWIPMATDEF);
   //     if(DB_error_code != DB_SUCCESS)
   //     {
   //         strcpy(s_msg_code, "WIP-0004");
   //         TRS.add_fieldmsg(out_node, "MWIPMATDEF OPEN", MP_NVST);
   //         TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
   //         TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
   //         TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
   //         TRS.add_fieldmsg(out_node, "MAT_TYPE", MP_STR, sizeof(MWIPMATDEF.MAT_TYPE), MWIPMATDEF.MAT_TYPE);
   //         TRS.add_dberrmsg(out_node, DB_error_msg);

   //         gs_log_type.type = MP_LOG_ERROR;
   //         gs_log_type.e_type = MP_LOG_E_SYSTEM;
   //         gs_log_type.category = MP_LOG_CATE_VIEW;
   //         COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
   //         return MP_FALSE;
   //     }

   //     while(1)
   //     {
   //         DBU_fetch_mwipmatdef(i_step, &MWIPMATDEF);
   //         if(DB_error_code == DB_NOT_FOUND)
   //         {
   //             DBU_close_mwipmatdef(i_step);
   //             break;
   //         }
   //         else if(DB_error_code != DB_SUCCESS) 
   //         {
   //             strcpy(s_msg_code, "WIP-0004");
   //             TRS.add_fieldmsg(out_node, "MWIPMATDEF FETCH", MP_NVST);
   //             TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
   //             TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
   //             TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);
   //             TRS.add_fieldmsg(out_node, "MAT_TYPE", MP_STR, sizeof(MWIPMATDEF.MAT_TYPE), MWIPMATDEF.MAT_TYPE);
   //             TRS.add_dberrmsg(out_node, DB_error_msg);

   //             gs_log_type.type = MP_LOG_ERROR;
   //             gs_log_type.e_type = MP_LOG_E_SYSTEM;
   //             gs_log_type.category = MP_LOG_CATE_VIEW;
   //             DBU_close_mwipmatdef(i_step);
   //             COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
   //             return MP_FALSE;
   //         }

   //         if(COM_check_node_length(out_node) == MP_FALSE)
   //         {
   //             TRS.add_string(out_node, "NEXT_MAT_ID", MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
   //             DBU_close_mwipmatdef(i_step);
   //             break;
   //         }

   //         list_item = TRS.add_node(out_node, "LIST");

   //         TRS.add_string(list_item, "MAT_ID", MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
   //         TRS.add_int(list_item, "MAT_VER", MWIPMATDEF.MAT_VER);
   //         TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
			//TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
   //         TRS.add_char(list_item, "DELETE_FLAG", MWIPMATDEF.DELETE_FLAG);
   //         TRS.add_char(list_item, "DEACTIVE_FLAG", MWIPMATDEF.DEACTIVE_FLAG);
   //         TRS.add_string(list_item, "MAT_GRP_1", MWIPMATDEF.MAT_GRP_1, sizeof(MWIPMATDEF.MAT_GRP_1));
   //         TRS.add_string(list_item, "MAT_GRP_2", MWIPMATDEF.MAT_GRP_2, sizeof(MWIPMATDEF.MAT_GRP_2));
   //         TRS.add_string(list_item, "MAT_GRP_3", MWIPMATDEF.MAT_GRP_3, sizeof(MWIPMATDEF.MAT_GRP_3));
   //         TRS.add_string(list_item, "MAT_GRP_4", MWIPMATDEF.MAT_GRP_4, sizeof(MWIPMATDEF.MAT_GRP_4));
   //         TRS.add_string(list_item, "MAT_GRP_5", MWIPMATDEF.MAT_GRP_5, sizeof(MWIPMATDEF.MAT_GRP_5));
   //         TRS.add_string(list_item, "MAT_GRP_6", MWIPMATDEF.MAT_GRP_6, sizeof(MWIPMATDEF.MAT_GRP_6));
   //         TRS.add_string(list_item, "MAT_GRP_7", MWIPMATDEF.MAT_GRP_7, sizeof(MWIPMATDEF.MAT_GRP_7));
   //         TRS.add_string(list_item, "MAT_GRP_8", MWIPMATDEF.MAT_GRP_8, sizeof(MWIPMATDEF.MAT_GRP_8));
   //         TRS.add_string(list_item, "MAT_GRP_9", MWIPMATDEF.MAT_GRP_9, sizeof(MWIPMATDEF.MAT_GRP_9));
   //         TRS.add_string(list_item, "MAT_GRP_10", MWIPMATDEF.MAT_GRP_10, sizeof(MWIPMATDEF.MAT_GRP_10));
   //         TRS.add_string(list_item, "MAT_CMF_1", MWIPMATDEF.MAT_CMF_1, sizeof(MWIPMATDEF.MAT_CMF_1));
   //         TRS.add_string(list_item, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, sizeof(MWIPMATDEF.MAT_CMF_2));
   //         TRS.add_string(list_item, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));
   //         TRS.add_string(list_item, "MAT_CMF_4", MWIPMATDEF.MAT_CMF_4, sizeof(MWIPMATDEF.MAT_CMF_4));
   //         TRS.add_string(list_item, "MAT_CMF_5", MWIPMATDEF.MAT_CMF_5, sizeof(MWIPMATDEF.MAT_CMF_5));
   //         TRS.add_string(list_item, "MAT_CMF_6", MWIPMATDEF.MAT_CMF_6, sizeof(MWIPMATDEF.MAT_CMF_6));
   //         TRS.add_string(list_item, "MAT_CMF_7", MWIPMATDEF.MAT_CMF_7, sizeof(MWIPMATDEF.MAT_CMF_7));
   //         TRS.add_string(list_item, "MAT_CMF_8", MWIPMATDEF.MAT_CMF_8, sizeof(MWIPMATDEF.MAT_CMF_8));
   //         TRS.add_string(list_item, "MAT_CMF_9", MWIPMATDEF.MAT_CMF_9, sizeof(MWIPMATDEF.MAT_CMF_9));
   //         TRS.add_string(list_item, "MAT_CMF_10", MWIPMATDEF.MAT_CMF_10, sizeof(MWIPMATDEF.MAT_CMF_10));
   //     }
   // }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    //if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

