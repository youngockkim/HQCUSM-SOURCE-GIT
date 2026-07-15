/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot_history.c
    Description : View Inventory Lot History related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Material_Inout_List()
            + View Inventory Lot History
        - TIV_View_Material_Inout_List()
            + Main Sub function of "TIV_View_Material_Inout_List"
            + (called by "TIV_View_Material_Inout_List")
        - TIV_View_Material_Inout_List_Validation()
            + Validation Check sub function of "TIV_View_Material_Inout_List" function
            + (called by "TIV_View_Material_Inout_List")

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/05/24  DY Oh         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"
//#include "DBC_cus_common.h"

int TIV_View_Material_Inout_List_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


/*******************************************************************************
    TIV_View_Material_Inout_List()
        - View Inventory Lot History
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material_Inout_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_MATERIAL_INOUT_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_MATERIAL_INOUT_LIST", out_node);

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
    TIV_VIEW_MATERIAL_INOUT_LIST()
        - Main sub function of "TIV_View_Material_Inout_List" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_MATERIAL_INOUT_LIST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
  //  struct MTIVLOTSTS_TAG MTIVLOTSTS;
  //  struct MTIVLOTHIS_TAG MTIVLOTHIS;
  //  struct MTIVOPRDEF_TAG MTIVOPRDEF;
  //  struct MTIVMATDEF_TAG MTIVMATDEF;
  //  struct MATRNAMSTS_TAG MATRNAMSTS;
  //  struct MTIVIQCHIS_TAG MTIVIQCHIS;

  //  struct MGCMTBLDAT_TAG MGCMTBLDAT;

  //  struct CPLNMIMMST_TAG CPLNMIMMST;

  //  struct MSECUSRDEF_TAG MSECUSRDEF;

  //  struct CPLNMIMDEF_TAG CPLNMIMDEF;

  //  TRSNode* list_item;

  //  int i_step = 0;
  //  int i_his_step = 0;
  //  int i_def_step = 0;
  //  int i_vendor_step = 0;

  //  LOG_head("TIV_View_Material_Inout_List");
  //  LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
  //  LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
  //  LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
  //  LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
  //  
  //  COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

  //  if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_Inout_List",
  //                           MP_UPOINT_BEFORE,
  //                           in_node,
  //                           out_node) == MP_FALSE)     return MP_FALSE;
  //  if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;

  //  TRS.add_int(out_node, "NEXT_HIST_SEQ", 0);

  //  /* Validation Check */
  //  if(TIV_View_Material_Inout_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
  //  {
  //      COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //      return MP_FALSE;
  //  }

  //  if(TRS.get_procstep(in_node)=='1' || TRS.get_procstep(in_node) == '2' || TRS.get_procstep(in_node) == '3')
  //  {
  //      DBC_init_mgcmtbldat(&MGCMTBLDAT);
  //    
  //      TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
  //      TRS.copy(MGCMTBLDAT.TABLE_NAME, sizeof(MGCMTBLDAT.TABLE_NAME), in_node, "TABLE_NAME");	 
  //      TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "KEY_1");            

  //       i_step = 201; //lot list search      

  //      DBC_select_mgcmtbldat(i_step, &MGCMTBLDAT);
  //       if(DB_error_code != DB_SUCCESS )
		//{
		//	if(DB_error_code == DB_NOT_FOUND)
		//	{
		//		strcpy(s_msg_code, "WIP-0019");
		//		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	}
		//	else
		//	{
		//		strcpy(s_msg_code, "WIP-0004"); 
		//		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		TRS.add_dberrmsg(out_node, DB_error_msg);
		//	}
		//	TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
		//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
		//	TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
		//	TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

		//	gs_log_type.type = MP_LOG_ERROR;
		//	gs_log_type.category = MP_LOG_CATE_COMMON;

		//	COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	return MP_FALSE;
		//}
  //      else
  //      {           
  //          TRS.add_string(out_node, "DATA_1", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
  //      }
  //  }
  //  else if(TRS.get_procstep(in_node) == '7')
  //  {
  //      DBC_init_cplnmimdef(&CPLNMIMDEF);

  //      TRS.copy(CPLNMIMDEF.FACTORY, sizeof(CPLNMIMDEF.FACTORY), in_node, IN_FACTORY);
  //      TRS.copy(CPLNMIMDEF.PROJECT_ID, sizeof(CPLNMIMDEF.PROJECT_ID), in_node, "PROJECT_ID");
  //      TRS.copy(CPLNMIMDEF.MAT_ID, sizeof(CPLNMIMDEF.MAT_ID), in_node, "MAT_ID");

  //      i_step = 207;

  //      DBC_open_cplnmimdef(i_step, &CPLNMIMDEF);

  //      if(DB_error_code != DB_SUCCESS)
  //        { 
  //           strcpy(s_msg_code, "PLN-0004");
  //          TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPLNMIMDEF.FACTORY), CPLNMIMDEF.FACTORY);
  //          TRS.add_fieldmsg(out_node, "SHOP", MP_STR, sizeof(CPLNMIMDEF.PROJECT_ID), CPLNMIMDEF.PROJECT_ID);
  //          TRS.add_fieldmsg(out_node, "MODEL", MP_STR,  sizeof(CPLNMIMDEF.MAT_ID), CPLNMIMDEF.MAT_ID); 


  //          TRS.add_dberrmsg(out_node, DB_error_msg); 

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //          gs_log_type.category = MP_LOG_CATE_VIEW;
  //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //          return MP_FALSE;
  //        }        

  //       while(1)
  //          {
  //              DBC_fetch_cplnmimdef(i_step, &CPLNMIMDEF);
  //              if(DB_error_code == DB_NOT_FOUND)
  //              {
  //                  DBC_close_cplnmimdef(i_step);
  //                  break;
  //              }
  //              else if(DB_error_code != DB_SUCCESS) 
  //              {
  //                  strcpy(s_msg_code, "PLN-0004");
  //                  TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CPLNMIMDEF.FACTORY), CPLNMIMDEF.FACTORY);
  //                  TRS.add_fieldmsg(out_node, "PROJECT_ID", MP_STR, sizeof(CPLNMIMDEF.PROJECT_ID), CPLNMIMDEF.PROJECT_ID);
  //                  TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(CPLNMIMDEF.MAT_ID), CPLNMIMDEF.MAT_ID); 

  //                  TRS.add_dberrmsg(out_node, DB_error_msg);

  //                  gs_log_type.type = MP_LOG_ERROR;
  //                  gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //                  gs_log_type.category = MP_LOG_CATE_VIEW;
  //                  DBC_close_mtivlothis(i_step);

  //                  COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //                  return MP_FALSE;
  //              }
  //              list_item = TRS.add_node(out_node, "LOT_LIST");
  //         
  //              TRS.add_string(list_item, "FACTORY", CPLNMIMDEF.FACTORY, sizeof(CPLNMIMDEF.FACTORY));
  //              TRS.add_string(list_item, "MODEL", CPLNMIMDEF.CMF_1, sizeof(CPLNMIMDEF.CMF_1));
  //              TRS.add_string(list_item, "SYSTEM", CPLNMIMDEF.CMF_3, sizeof(CPLNMIMDEF.CMF_3));
  //              TRS.add_string(list_item, "PROJECT_ID", CPLNMIMDEF.PROJECT_ID, sizeof(CPLNMIMDEF.PROJECT_ID));
  //              TRS.add_int(list_item, "PROJECT_VER", CPLNMIMDEF.PROJECT_VER);
  //              TRS.add_int(list_item, "TOTAL", CPLNMIMDEF.TOTAL);
  //              TRS.add_int(list_item, "OUT_QTY", CPLNMIMDEF.ARRAY_QTY);
  //              TRS.add_int(list_item, "REMAIN_QTY", CPLNMIMDEF.VALUE_COUNT_1);
  //       }


  //  }
  //  else if(TRS.get_procstep(in_node) == '8')
  //  {
  //      DBC_init_mtivlotsts(&MTIVLOTSTS);

  //      TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
  //      TRS.copy(MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1), in_node, "SHOP");
  //      TRS.copy(MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2), in_node, "MODEL");
  //      TRS.copy(MTIVLOTSTS.INV_CMF_3 , sizeof(MTIVLOTSTS.INV_CMF_3 ), in_node, "SYSTEM");
  //      TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID"); 
  //      TRS.copy(MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4), in_node, "PROJECT_ID");
  //      TRS.copy(MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5), in_node, "PROJECT_VER");
  //      TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");  

  //      i_step = 208; //

  //      DBC_open_mtivlotsts(i_step, &MTIVLOTSTS);

  //       if(DB_error_code != DB_SUCCESS)
  //        { 
  //           strcpy(s_msg_code, "PLN-0004");
  //          TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
  //          TRS.add_fieldmsg(out_node, "SHOP", MP_STR, sizeof(MTIVLOTSTS.INV_CMF_1), MTIVLOTSTS.INV_CMF_1);
  //          TRS.add_fieldmsg(out_node, "MODEL", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_2), MTIVLOTSTS.INV_CMF_2); 
  //          TRS.add_fieldmsg(out_node, "SYSTEM", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_3), MTIVLOTSTS.INV_CMF_3);
  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
  //          TRS.add_fieldmsg(out_node, "PROJECT_ID", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_4), MTIVLOTSTS.INV_CMF_4);
  //          TRS.add_fieldmsg(out_node, "PROJECT_VER", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_5), MTIVLOTSTS.INV_CMF_5);
  //          TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);

  //          TRS.add_dberrmsg(out_node, DB_error_msg); 

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //          gs_log_type.category = MP_LOG_CATE_VIEW;
  //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //          return MP_FALSE;
  //        }        
  //        while(1)
  //          {
  //              DBC_fetch_mtivlotsts(i_step, &MTIVLOTSTS);
  //              if(DB_error_code == DB_NOT_FOUND)
  //              {
  //                  DBC_close_mtivlothis(i_step);
  //                  break;
  //              }
  //              else if(DB_error_code != DB_SUCCESS) 
  //              {
  //                  strcpy(s_msg_code, "PLN-0004");
  //                  TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
  //                  TRS.add_fieldmsg(out_node, "SHOP", MP_STR, sizeof(MTIVLOTSTS.INV_CMF_1), MTIVLOTSTS.INV_CMF_1);
  //                  TRS.add_fieldmsg(out_node, "MODEL", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_2), MTIVLOTSTS.INV_CMF_2); 
  //                  TRS.add_fieldmsg(out_node, "SYSTEM", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_3), MTIVLOTSTS.INV_CMF_3);
  //                  TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
  //                  TRS.add_fieldmsg(out_node, "PROJECT_ID", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_4), MTIVLOTSTS.INV_CMF_4);
  //                  TRS.add_fieldmsg(out_node, "PROJECT_VER", MP_STR,  sizeof(MTIVLOTSTS.INV_CMF_5), MTIVLOTSTS.INV_CMF_5);
  //                  TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);

  //                  TRS.add_dberrmsg(out_node, DB_error_msg);

  //                  gs_log_type.type = MP_LOG_ERROR;
  //                  gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //                  gs_log_type.category = MP_LOG_CATE_VIEW;
  //                  DBC_close_mtivlothis(i_step);

  //                  COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //                  return MP_FALSE;
  //              }
  //              list_item = TRS.add_node(out_node, "LOT_LIST");
  //         
  //              TRS.add_string(list_item, "FACTORY", MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
  //              TRS.add_string(list_item, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
  //              TRS.add_int(list_item, "MAT_VER", MTIVLOTSTS.MAT_VER);
  //              TRS.add_string(list_item, "MAT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));
  //              TRS.add_string(list_item, "SPEC1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
  //              TRS.add_string(list_item, "SPEC2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
  //              TRS.add_string(list_item, "SPEC3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
  //              TRS.add_string(list_item, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
  //              TRS.add_double(list_item, "INV_QTY", MTIVLOTSTS.QTY_1);
  //              TRS.add_double(list_item, "WIP_QTY", MTIVLOTSTS.QTY_2);

  //              DBC_init_mtivlothis(&MTIVLOTHIS);

  //              TRS.copy(MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);
  //              memcpy(MTIVLOTHIS.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID)); // mat_id     
  //              memcpy(MTIVLOTHIS.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID)); // mat_id     

  //               i_his_step = 208; //vondor id search

  //              DBC_select_mtivlothis(i_his_step, &MTIVLOTHIS);
  //               if(DB_error_code != DB_SUCCESS )
		//        {
		//	        if(DB_error_code == DB_NOT_FOUND)
		//	        {
		//		        strcpy(s_msg_code, "WIP-0019");
		//		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	        }
		//	        else
		//	        {
		//		        strcpy(s_msg_code, "WIP-0004"); 
		//		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		        TRS.add_dberrmsg(out_node, DB_error_msg);
		//	        }
		//	        TRS.add_string(list_item, "VENDOR_ID", "", sizeof(MTIVLOTHIS.VENDOR_ID));
  //                  TRS.add_string(list_item, "TRAN_TIME", "", sizeof(MTIVLOTHIS.TRAN_TIME));
		//        }
  //              else
  //              {           
  //                  TRS.add_string(list_item, "VENDOR_ID", MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID));
  //                  TRS.add_string(list_item, "TRAN_TIME", MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME));
  //              }
  //              


  //      }
  //  }
  //  else if(TRS.get_procstep(in_node) == '9')
  //  {
  //      DBC_init_mtivlothis(&MTIVLOTHIS);

  //      TRS.copy(MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);
  //      TRS.copy(MTIVLOTHIS.INV_IN_TIME, sizeof(MTIVLOTHIS.INV_IN_TIME), in_node, "FROM_TIME");
  //      TRS.copy(MTIVLOTHIS.INV_OUT_TIME, sizeof(MTIVLOTHIS.INV_OUT_TIME), in_node, "TO_TIME");
  //      TRS.copy(MTIVLOTHIS.OLD_OPER , sizeof(MTIVLOTHIS.OLD_OPER ), in_node, "FROM_OPER");
  //      TRS.copy(MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER), in_node, "TO_OPER");
  //      TRS.copy(MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2), in_node, "IO_TYPE"); //수불 구분
  //      TRS.copy(MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE), in_node, "LOSS_CODE"); //기타출고 구분
  //      TRS.copy(MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID), in_node, "VENDOR_ID");
  //      TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "LOT_ID");
  //      TRS.copy(MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID), in_node, "MAT_ID");   

  //      TRS.copy(MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10), in_node, "MAT_VER"); 

  //      TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), in_node, "PROJECT_ID");
  //      TRS.copy(MTIVLOTHIS.INV_CMF_1, sizeof(MTIVLOTHIS.INV_CMF_1), in_node, "MODEL");	
  //      TRS.copy(MTIVLOTHIS.INV_CMF_3, sizeof(MTIVLOTHIS.INV_CMF_3), in_node, "SYSTEM");	

  //      i_step = 209; //

  //      DBC_open_mtivlothis(i_step, &MTIVLOTHIS);

  //        if(DB_error_code != DB_SUCCESS)
  //        { 
  //          strcpy(s_msg_code, "PLN-0004");
  //          TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
  //          TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(MTIVLOTHIS.INV_IN_TIME), MTIVLOTHIS.INV_IN_TIME);
  //          TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR,  sizeof(MTIVLOTHIS.INV_OUT_TIME), MTIVLOTHIS.INV_OUT_TIME); 
  //          TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR,  sizeof(MTIVLOTHIS.OLD_OPER), MTIVLOTHIS.OLD_OPER);
  //          TRS.add_fieldmsg(out_node, "TO_OPER", MP_STR,  sizeof(MTIVLOTHIS.OPER), MTIVLOTHIS.OPER);
  //          TRS.add_fieldmsg(out_node, "IO_TYPE", MP_STR,  sizeof(MTIVLOTHIS.TRAN_CMF_2), MTIVLOTHIS.TRAN_CMF_2);
  //          TRS.add_fieldmsg(out_node, "LOSS_CODE", MP_STR,  sizeof(MTIVLOTHIS.TRAN_TYPE), MTIVLOTHIS.TRAN_TYPE);
  //              TRS.add_fieldmsg(out_node, "VENDOR_ID", MP_STR, sizeof(MTIVLOTHIS.VENDOR_ID), MTIVLOTHIS.VENDOR_ID);
  //          TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID); 
  //          TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVLOTHIS.MAT_ID), MTIVLOTHIS.MAT_ID);

  //          TRS.add_fieldmsg(out_node, "MAT_VER", MP_STR,   sizeof(MTIVLOTHIS.TRAN_CMF_10), MTIVLOTHIS.TRAN_CMF_10);
  //          TRS.add_fieldmsg(out_node, "PROJECT_ID", MP_STR,  sizeof(MTIVLOTHIS.TRAN_CMF_1), MTIVLOTHIS.TRAN_CMF_1);
  //          TRS.add_fieldmsg(out_node, "MODEL", MP_STR,  sizeof(MTIVLOTHIS.INV_CMF_1), MTIVLOTHIS.INV_CMF_1);
  //          TRS.add_fieldmsg(out_node, "SYSTEM", MP_STR,  sizeof(MTIVLOTHIS.INV_CMF_3), MTIVLOTHIS.INV_CMF_3);

  //          TRS.add_dberrmsg(out_node, DB_error_msg); 

  //          gs_log_type.type = MP_LOG_ERROR;
  //          gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //          gs_log_type.category = MP_LOG_CATE_VIEW;
  //          COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //          return MP_FALSE;
  //        }        
  //          while(1)
  //          {
  //              DBC_fetch_mtivlothis(i_step, &MTIVLOTHIS);
  //              if(DB_error_code == DB_NOT_FOUND)
  //              {
  //                  DBC_close_mtivlothis(i_step);
  //                  break;
  //              }
  //              else if(DB_error_code != DB_SUCCESS) 
  //              {
  //                  strcpy(s_msg_code, "PLN-0004");
  //                  TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
  //                  TRS.add_fieldmsg(out_node, "FROM_TIME", MP_STR, sizeof(MTIVLOTHIS.INV_IN_TIME), MTIVLOTHIS.INV_IN_TIME);
  //                  TRS.add_fieldmsg(out_node, "TO_TIME", MP_STR,  sizeof(MTIVLOTHIS.INV_OUT_TIME), MTIVLOTHIS.INV_OUT_TIME); 
  //                  TRS.add_fieldmsg(out_node, "FROM_OPER", MP_STR,  sizeof(MTIVLOTHIS.OLD_OPER), MTIVLOTHIS.OLD_OPER);
  //                  TRS.add_fieldmsg(out_node, "TO_OPER", MP_STR,  sizeof(MTIVLOTHIS.OPER), MTIVLOTHIS.OPER);
  //                  TRS.add_fieldmsg(out_node, "IO_TYPE", MP_STR,  sizeof(MTIVLOTHIS.TRAN_CMF_2), MTIVLOTHIS.TRAN_CMF_2);
  //                  TRS.add_fieldmsg(out_node, "LOSS_CODE", MP_STR,  sizeof(MTIVLOTHIS.TRAN_TYPE), MTIVLOTHIS.TRAN_TYPE);
  //                   TRS.add_fieldmsg(out_node, "VENDOR_ID", MP_STR, sizeof(MTIVLOTHIS.VENDOR_ID), MTIVLOTHIS.VENDOR_ID);
  //                  TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(MTIVLOTHIS.LOT_ID), MTIVLOTHIS.LOT_ID); 
  //                  TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR,  sizeof(MTIVLOTHIS.MAT_ID), MTIVLOTHIS.MAT_ID);

  //                  TRS.add_fieldmsg(out_node, "MAT_VER", MP_STR,   sizeof(MTIVLOTHIS.TRAN_CMF_10), MTIVLOTHIS.TRAN_CMF_10);
  //                  TRS.add_fieldmsg(out_node, "PROJECT_ID", MP_STR,  sizeof(MTIVLOTHIS.TRAN_CMF_1), MTIVLOTHIS.TRAN_CMF_1);
  //                  TRS.add_fieldmsg(out_node, "MODEL", MP_STR,  sizeof(MTIVLOTHIS.INV_CMF_1), MTIVLOTHIS.INV_CMF_1);
  //                  TRS.add_fieldmsg(out_node, "SYSTEM", MP_STR,  sizeof(MTIVLOTHIS.INV_CMF_3), MTIVLOTHIS.INV_CMF_3);


  //                  TRS.add_dberrmsg(out_node, DB_error_msg);

  //                  gs_log_type.type = MP_LOG_ERROR;
  //                  gs_log_type.e_type = MP_LOG_E_SYSTEM;
  //                  gs_log_type.category = MP_LOG_CATE_VIEW;
  //                  DBC_close_mtivlothis(i_step);

  //                  COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
  //                  return MP_FALSE;
  //              }
  //              list_item = TRS.add_node(out_node, "LOT_LIST");
  //         
  //              TRS.add_string(list_item, "FACTORY", MTIVLOTHIS.FACTORY, sizeof(MTIVLOTHIS.FACTORY));
  //              TRS.add_string(list_item, "TRAN_TIME", MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME));
  //              TRS.add_string(list_item, "MAT_ID", MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID));
  //              TRS.add_int(list_item, "MAT_VER", MTIVLOTHIS.MAT_VER);
  //              TRS.add_string(list_item, "MAT_SPEC", MTIVLOTHIS.TRAN_CMF_20, sizeof(MTIVLOTHIS.TRAN_CMF_20));

  //              TRS.add_string(list_item, "MAT_TYPE", MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19));
  //              TRS.add_string(list_item, "IO_TYPE", MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18));
  //             /* TRS.add_string(list_item, "FROM_OPER", MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER));*/
  //              /*TRS.add_string(list_item, "TO_OPER", MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER));*/
  //              TRS.add_string(list_item, "LOT_ID", MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID));

  //              TRS.add_double(list_item, "QTY", MTIVLOTHIS.OLD_QTY_1);
  //              TRS.add_string(list_item, "VENDOR_ID", MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID));
  //              TRS.add_string(list_item, "LOSS_CODE", MTIVLOTHIS.TRAN_CMF_7, sizeof(MTIVLOTHIS.TRAN_CMF_7));
  //              TRS.add_string(list_item, "TRAN_COMMENT", MTIVLOTHIS.TRAN_COMMENT, sizeof(MTIVLOTHIS.TRAN_COMMENT));
  //              TRS.add_string(list_item, "USER_ID", MTIVLOTHIS.TRAN_USER_ID, sizeof(MTIVLOTHIS.TRAN_USER_ID));

  //              TRS.add_string(list_item, "SYS_TRAN_TIME", MTIVLOTHIS.SYS_TRAN_TIME, sizeof(MTIVLOTHIS.SYS_TRAN_TIME));
  //              TRS.add_string(list_item, "TRAN_CODE", MTIVLOTHIS.TRAN_CODE, sizeof(MTIVLOTHIS.TRAN_CODE));
  //              TRS.add_string(list_item, "TRAN_TYPE", MTIVLOTHIS.TRAN_TYPE, sizeof(MTIVLOTHIS.TRAN_TYPE));
  //              TRS.add_string(list_item, "PROJECT_ID", MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1)); 
  //              TRS.add_string(list_item, "PROJECT_VER", MTIVLOTHIS.TRAN_CMF_6, sizeof(MTIVLOTHIS.TRAN_CMF_6));

  //              TRS.add_int(list_item, "HIST_SEQ", MTIVLOTHIS.HIST_SEQ);
  //              TRS.add_string(list_item, "TRAN_MODEL", MTIVLOTHIS.TRAN_CMF_10, sizeof(MTIVLOTHIS.TRAN_CMF_10));
  //              TRS.add_string(list_item, "TRAN_SYSTEM", MTIVLOTHIS.TRAN_CMF_11, sizeof(MTIVLOTHIS.TRAN_CMF_11));


  //          
  //              DBC_init_mgcmtbldat(&MGCMTBLDAT);
  //    
  //              TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
  //              memcpy(MGCMTBLDAT.KEY_1, MTIVLOTHIS.TRAN_CMF_19, sizeof(MTIVLOTHIS.TRAN_CMF_19)); // mat_type         

  //               i_his_step = 202; //lot list search      

  //              DBC_select_mgcmtbldat(i_his_step, &MGCMTBLDAT);
  //               if(DB_error_code != DB_SUCCESS )
		//        {
		//	        if(DB_error_code == DB_NOT_FOUND)
		//	        {
		//		        strcpy(s_msg_code, "WIP-0019");
		//		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	        }
		//	        else
		//	        {
		//		        strcpy(s_msg_code, "WIP-0004"); 
		//		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		        TRS.add_dberrmsg(out_node, DB_error_msg);
		//	        }
		//	        TRS.add_string(list_item, "MAT_DESC", "", sizeof(MGCMTBLDAT.DATA_1));
		//        }
  //              else
  //              {           
  //                  TRS.add_string(list_item, "MAT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
  //              }

  //              DBC_init_mtivmatdef(&MTIVMATDEF);           

  //              TRS.copy(MTIVMATDEF.FACTORY, sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY);
  //              memcpy(MTIVMATDEF.MAT_ID, MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID));

  //              MTIVMATDEF.MAT_VER = MTIVLOTHIS.MAT_VER;

  //              DBC_select_mtivmatdef(i_his_step, &MTIVMATDEF);
  //              if(DB_error_code != DB_SUCCESS )
		//	    {
		//		    if(DB_error_code == DB_NOT_FOUND)
		//		    {
		//			    strcpy(s_msg_code, "WIP-0019");
		//			    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//		    }
		//		    else
		//		    {
		//			    strcpy(s_msg_code, "WIP-0004"); 
		//			    gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//			    TRS.add_dberrmsg(out_node, DB_error_msg);
		//		    }
		//		    TRS.add_fieldmsg(out_node, "MTIVMATDEF SELECT", MP_NVST);
		//		    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVMATDEF.FACTORY), MTIVMATDEF.FACTORY);
		//		    TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVMATDEF.MAT_ID), MTIVMATDEF.MAT_ID);
		//		    TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MTIVMATDEF.MAT_VER);

		//		    gs_log_type.type = MP_LOG_ERROR;
		//		    gs_log_type.category = MP_LOG_CATE_COMMON;

		//		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//		    return MP_FALSE;
		//	    }
  //              TRS.add_string(list_item, "MAT_NAME", MTIVMATDEF.MAT_DESC, sizeof(MTIVMATDEF.MAT_DESC));      



  //              DBC_init_mgcmtbldat(&MGCMTBLDAT);
  //    
  //              TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);     
  //              memcpy(MGCMTBLDAT.KEY_1, MTIVLOTHIS.TRAN_CMF_18, sizeof(MTIVLOTHIS.TRAN_CMF_18)); //IO_TYPE : 수불 구분

  //               i_def_step = 203; //lot list search      

  //              DBC_select_mgcmtbldat(i_def_step, &MGCMTBLDAT);
  //               if(DB_error_code != DB_SUCCESS )
		//        {
		//	        if(DB_error_code == DB_NOT_FOUND)
		//	        {
		//		        strcpy(s_msg_code, "WIP-0019");
		//		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	        }
		//	        else
		//	        {
		//		        strcpy(s_msg_code, "WIP-0004"); 
		//		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		        TRS.add_dberrmsg(out_node, DB_error_msg);
		//	        }
		//	        TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
		//	        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
		//	        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
		//	        TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

		//	        gs_log_type.type = MP_LOG_ERROR;
		//	        gs_log_type.category = MP_LOG_CATE_COMMON;

		//	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	        return MP_FALSE;
		//        }
  //              else
  //              {           
  //                  TRS.add_string(list_item, "DATA_1", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
  //              }
  //               
  //              DBC_init_mtivoprdef(&MTIVOPRDEF);
  //    
  //              TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);     
  //              memcpy(MTIVOPRDEF.OPER, MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER)); // FROM OPER

  //               i_def_step = 203; //lot list search      

  //              DBC_select_mtivoprdef(i_def_step, &MTIVOPRDEF);
  //               if(DB_error_code != DB_SUCCESS )
		//        {
		//	        if(DB_error_code == DB_NOT_FOUND)
		//	        {
		//		        strcpy(s_msg_code, "WIP-0019");
		//		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	        }
		//	        else
		//	        {
		//		        strcpy(s_msg_code, "WIP-0004"); 
		//		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		        TRS.add_dberrmsg(out_node, DB_error_msg);
		//	        }
		//	        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
		//	        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
		//	        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

		//	        gs_log_type.type = MP_LOG_ERROR;
		//	        gs_log_type.category = MP_LOG_CATE_COMMON;

		//	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	        return MP_FALSE;
		//        }
  //              else
  //              {           
  //                  TRS.add_string(list_item, "FROM_OPER", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
  //              }


  //               DBC_init_mtivoprdef(&MTIVOPRDEF);
  //    
  //              TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);     
  //              memcpy(MTIVOPRDEF.OPER, MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER)); // TO OPER

  //               i_def_step = 203; //lot list search      

  //              DBC_select_mtivoprdef(i_def_step, &MTIVOPRDEF);
  //               if(DB_error_code != DB_SUCCESS )
		//        {
		//	        if(DB_error_code == DB_NOT_FOUND)
		//	        {
		//		        strcpy(s_msg_code, "WIP-0019");
		//		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	        }
		//	        else
		//	        {
		//		        strcpy(s_msg_code, "WIP-0004"); 
		//		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		        TRS.add_dberrmsg(out_node, DB_error_msg);
		//	        }
		//	        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
		//	        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
		//	        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);

		//	        gs_log_type.type = MP_LOG_ERROR;
		//	        gs_log_type.category = MP_LOG_CATE_COMMON;

		//	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	        return MP_FALSE;
		//        }
  //              else
  //              {           
  //                  TRS.add_string(list_item, "TO_OPER", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
  //              }



  //                DBC_init_mgcmtbldat(&MGCMTBLDAT);
  //    
  //              TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);     
  //              memcpy(MGCMTBLDAT.KEY_1, MTIVLOTHIS.VENDOR_ID, sizeof(MTIVLOTHIS.VENDOR_ID)); //VENDOR_ID : 밴더 ID

  //               i_vendor_step = 204; //lot list search      

  //              DBC_select_mgcmtbldat(i_vendor_step, &MGCMTBLDAT);
  //               if(DB_error_code != DB_SUCCESS )
		//        {
		//	        if(DB_error_code == DB_NOT_FOUND)
		//	        {
		//		        strcpy(s_msg_code, "WIP-0019");
		//		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	        }
		//	        else
		//	        {
		//		        strcpy(s_msg_code, "WIP-0004"); 
		//		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		        TRS.add_dberrmsg(out_node, DB_error_msg);
		//	        }
		//	        TRS.add_string(list_item, "VENDOR_NAME", " ", sizeof(MGCMTBLDAT.DATA_1));
		//        }
  //              else
  //              {           
  //                  TRS.add_string(list_item, "VENDOR_NAME", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
  //              }


  //               DBC_init_msecusrdef(&MSECUSRDEF);
  //    
  //              TRS.copy(MSECUSRDEF.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);     
  //              memcpy(MSECUSRDEF.USER_ID, MTIVLOTHIS.TRAN_USER_ID, sizeof(MTIVLOTHIS.TRAN_USER_ID)); //USER : 유저 ID

  //               i_vendor_step = 204; //lot list search      

  //              DBC_select_msecusrdef(i_vendor_step, &MSECUSRDEF);
  //               if(DB_error_code != DB_SUCCESS )
		//        {
		//	        if(DB_error_code == DB_NOT_FOUND)
		//	        {
		//		        strcpy(s_msg_code, "WIP-0019");
		//		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		//	        }
		//	        else
		//	        {
		//		        strcpy(s_msg_code, "WIP-0004"); 
		//		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		//		        TRS.add_dberrmsg(out_node, DB_error_msg);
		//	        }
		//	        TRS.add_fieldmsg(out_node, "MSECUSRDEF SELECT", MP_NVST);
		//	        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MSECUSRDEF.FACTORY), MSECUSRDEF.FACTORY);
		//	        TRS.add_fieldmsg(out_node, "USER_ID", MP_STR, sizeof(MSECUSRDEF.USER_ID), MSECUSRDEF.USER_ID);

		//	        gs_log_type.type = MP_LOG_ERROR;
		//	        gs_log_type.category = MP_LOG_CATE_COMMON;

		//	        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		//	        return MP_FALSE;
		//        }
  //              else
  //              {           
  //                  TRS.add_string(list_item, "USER_NAME", MSECUSRDEF.USER_DESC, sizeof(MSECUSRDEF.USER_DESC));
  //              }




  //      }
  //  }


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Material_Inout_List",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Material_Inout_List_Validation()
        - Validation Check sub function of "TIV_View_Material_Inout_List" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Material_Inout_List_Validation(char *s_msg_code,
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
        strcpy(s_msg_code, "INV-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }    
    /* Lot ID Validation */
    if(TRS.get_procstep(in_node)!='2' && TRS.get_char(in_node, "NO_LOT_VALIDATION")!='Y')
    {
        if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
        {
            strcpy(s_msg_code, "INV-0001");
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);

    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "INV-0005");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else 
        {
            strcpy(s_msg_code, "INV-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        return MP_FALSE;
    }    

    return MP_TRUE;
}