/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot.c
    Description : View Inventory Lot Information related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Lot_NEW()
            + View Inventory Lot Information
        - TIV_View_Lot_NEW()
            + Main Sub function of "TIV_View_Lot_NEW"
            + (called by "TIV_VIEW_LOT_NEW")
        - TIV_View_Lot_NEW_Validation()
            + Validation Check sub function of "TIV_View_Lot_NEW" function
            + (called by "TIV_View_Lot_NEW")

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


int TIV_View_Lot_NEW_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


/*******************************************************************************
    TIV_View_Lot_NEW()
        - View Inventory Lot Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_NEW(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT_NEW(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT_NEW", out_node);

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
    TIV_View_Lot_NEW()
        - Main sub function of "TIV_View_Lot_NEW" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT_NEW(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    //struct MTIVOPRDEF_TAG MTIVOPRDEF;
    struct MTIVLOTHIS_TAG MTIVLOTHIS;

	//struct MGCMTBLDAT_TAG MGCMTBLDAT;

	//TRSNode *lot_list;
    TRSNode *list_item;

	int istep = 0;
    //double dQty = 0;

    LOG_head("TIV_View_Lot_NEW");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_NEW",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;


    /* Validation Check - Factory Validation */
   /* if(TIV_View_Lot_NEW_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }*/

	if(TRS.get_procstep(in_node)=='1'||TRS.get_procstep(in_node)=='4'||TRS.get_procstep(in_node)=='9'||TRS.get_procstep(in_node)=='A')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
		TRS.copy(MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME), in_node, "FROM_TIME");
		TRS.copy(MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME), in_node, "TO_TIME"); //구조체에 임시에 담아두기 위해 INV_IN_TIME 필드 사용

		if(TRS.get_procstep(in_node)=='1')
		{
			istep = 101; //INV
		}
		else if(TRS.get_procstep(in_node)=='2')
		{
			istep = 101; //WIP			
        }else if(TRS.get_procstep(in_node) == '3')
        {
            istep = 103;
        }

		DBC_select_mtivlotsts(istep, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
		    if(DB_error_code == DB_NOT_FOUND)
		    {
		        strcpy(s_msg_code, "INV-0030");
		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		    }
		    else 
		    {
		        strcpy(s_msg_code, "INV-0004");
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        TRS.add_dberrmsg(out_node, DB_error_msg);
		    }

		    TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
		    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
		    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

            if(TRS.get_procstep(in_node)!='1')
                TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.category = MP_LOG_CATE_VIEW;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}

		if(TRS.get_char(in_node, "TRS_INFO_FLAG") == 'Y')
		{
			DBC_init_mtivtrsdtl(&MTIVTRSDTL);
			memcpy(MTIVTRSDTL.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
		    memcpy(MTIVTRSDTL.TRS_NO, MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.MAT_ID));
			memcpy(MTIVTRSDTL.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
			memcpy(MTIVTRSDTL.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));

		    DBC_select_mtivtrsdtl(1, &MTIVTRSDTL);
		    if(DB_error_code == DB_NOT_FOUND)
		    {
		        memset(MTIVTRSDTL.LOT_ID, ' ', sizeof(MTIVTRSDTL.LOT_ID));
			    memcpy(MTIVTRSDTL.LOT_ID, MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
		        DBC_select_mtivtrsdtl(1, &MTIVTRSDTL);
		    }
		    TRS.add_char(out_node, "DOC_TYPE", MTIVTRSDTL.DOC_TYPE);
		    TRS.add_char(out_node, "STATUS_FLAG", MTIVTRSDTL.STATUS_FLAG);
			TRS.add_int(out_node, "TRS_SEQ", MTIVTRSDTL.TRS_SEQ);
			TRS.add_string(out_node, "TO_OPER", MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER));
		}
        TRS.add_string(out_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));   
	    TRS.add_string(out_node, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	    TRS.add_string(out_node, "MAT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC)); //구조체에 MAT_DESC가 없어서 LOT_DESC에 임시로 담아둠
	    TRS.add_int(out_node, "MAT_VER", MTIVLOTSTS.MAT_VER);
	    TRS.add_string(out_node, "TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
	    TRS.add_double(out_node, "QTY", MTIVLOTSTS.QTY_1);
	}
	else if(TRS.get_procstep(in_node)=='2')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");

		DBC_select_mtivlotsts(1, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
		    if(DB_error_code == DB_NOT_FOUND)
		    {
		        strcpy(s_msg_code, "INV-0030");
		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		    }
		    else 
		    {
		        strcpy(s_msg_code, "INV-0004");
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        TRS.add_dberrmsg(out_node, DB_error_msg);
		    }

		    TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
		    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
		    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.category = MP_LOG_CATE_VIEW;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}
        TRS.add_string(out_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));   
	    TRS.add_string(out_node, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	    TRS.add_string(out_node, "MAT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC)); //구조체에 MAT_DESC가 없어서 LOT_DESC에 임시로 담아둠
	    TRS.add_int(out_node, "MAT_VER", MTIVLOTSTS.MAT_VER);
	    TRS.add_string(out_node, "TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
	TRS.add_double(out_node, "QTY", MTIVLOTSTS.QTY_1);
	}
	else if(TRS.get_procstep(in_node)=='3'||TRS.get_procstep(in_node)=='5')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY); 
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");

        if(TRS.get_procstep(in_node)=='3')
            DBC_select_mtivlotsts(7, &MTIVLOTSTS);
        else if(TRS.get_procstep(in_node)=='5')
        {
            TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
            DBC_select_mtivlotsts(9, &MTIVLOTSTS);
        }
		
        if(DB_error_code != DB_SUCCESS) 
		{
		    if(DB_error_code == DB_NOT_FOUND)
		    {
		        strcpy(s_msg_code, "INV-0030");
		        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		    }
		    else 
		    {
		        strcpy(s_msg_code, "INV-0004");
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        TRS.add_dberrmsg(out_node, DB_error_msg);
		    }

		    TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
		    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
		    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.category = MP_LOG_CATE_VIEW;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}
            TRS.add_string(out_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));   
	        TRS.add_string(out_node, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	        TRS.add_string(out_node, "MAT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC)); //구조체에 MAT_DESC가 없어서 LOT_DESC에 임시로 담아둠
	        TRS.add_int(out_node, "MAT_VER", MTIVLOTSTS.MAT_VER);
	        TRS.add_string(out_node, "TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
	        TRS.add_double(out_node, "QTY", MTIVLOTSTS.QTY_1);
	}

    else if(TRS.get_procstep(in_node)=='6')
	{
                    /*    in_node.AddString("FROM_TIME", s_from_time);
                in_node.AddString("TO_TIME", s_to_time);
                in_node.AddString("SHOP", MPCF.Trim(shop));
                in_node.AddString("OLD_OPER", MPCF.Trim(in_oper));
                in_node.AddString("OPER",MPCF.Trim(out_oper)); 
                in_node.AddString("PROJECT_ID", MPCF.Trim(project_id));
                in_node.AddString("LOT_ID", MPCF.Trim(lotId));
                in_node.AddString("MAT_ID", MPCF.Trim(matId));*/

        istep = 102; 

        DBC_init_mtivlothis(&MTIVLOTHIS);
		TRS.copy(MTIVLOTHIS.FACTORY , sizeof(MTIVLOTHIS.FACTORY), in_node, IN_FACTORY); 
		TRS.copy(MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME), in_node, "FROM_TIME");
        TRS.copy(MTIVLOTHIS.SYS_TRAN_TIME, sizeof(MTIVLOTHIS.SYS_TRAN_TIME), in_node, "TO_TIME");
        TRS.copy(MTIVLOTHIS.TRAN_CMF_2, sizeof(MTIVLOTHIS.TRAN_CMF_2), in_node, "SHOP");
        TRS.copy(MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER), in_node, "OPER");

        TRS.copy(MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER), in_node, "OLD_OPER");
        TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), in_node, "PROJECT_ID");
        TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "LOT_ID");
        TRS.copy(MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID), in_node, "MAT_ID");

      /*  if(TRS.get_string(in_node, "OPER") != null && TRS.get_string(in_node, "OPER") != "")
        {
            TRS.copy(MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER), in_node, "OPER");
            istep = 102;
        }

         if(TRS.get_string(in_node, "PROJECT_ID") != null && TRS.get_string(in_node, "PROJECT_ID") != "")
        {
            TRS.copy(MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1), in_node, "PROJECT_ID");
            istep = 103;
         }

         if(TRS.get_string(in_node, "LOT_ID") != null && TRS.get_string(in_node, "LOT_ID") != "")
        {
            TRS.copy(MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID), in_node, "LOT_ID");
            istep=104;
        }

         if(TRS.get_string(in_node, "MAT_ID") != null && TRS.get_string(in_node, "MAT_ID") != "")
        {
            TRS.copy(MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID), in_node, "MAT_ID");
            istep=105;
         }
*/
        DBC_open_mtivlothis(istep,&MTIVLOTHIS );

        //TRS.get_int(in_node, "PROJECT_VER");           

         if(DB_error_code != DB_SUCCESS)
        { 
            strcpy(s_msg_code, "PLN-0004");

            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
            TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR,  sizeof(MTIVLOTHIS.TRAN_TIME), MTIVLOTHIS.TRAN_TIME); 
            TRS.add_fieldmsg(out_node, "SYS_TRAN_TIME", MP_STR,  sizeof(MTIVLOTHIS.SYS_TRAN_TIME), MTIVLOTHIS.SYS_TRAN_TIME);
            TRS.add_fieldmsg(out_node, "TRAN_CMF_2", MP_STR,  sizeof(MTIVLOTHIS.TRAN_CMF_2), MTIVLOTHIS.TRAN_CMF_2);
            TRS.add_fieldmsg(out_node, "OLD_OPER", MP_STR,  sizeof(MTIVLOTHIS.OLD_OPER), MTIVLOTHIS.OLD_OPER);

            TRS.add_dberrmsg(out_node, DB_error_msg); 

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

          while(1)
        {
            DBC_fetch_mtivlothis(istep, &MTIVLOTHIS);
            if(DB_error_code == DB_NOT_FOUND)
            {
                DBC_close_mtivlothis(istep);
                break;
            }
            else if(DB_error_code != DB_SUCCESS) 
            {
                strcpy(s_msg_code, "PLN-0004");
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTHIS.FACTORY), MTIVLOTHIS.FACTORY);
                TRS.add_fieldmsg(out_node, "TRAN_TIME", MP_STR,  sizeof(MTIVLOTHIS.TRAN_TIME), MTIVLOTHIS.TRAN_TIME); 
                TRS.add_fieldmsg(out_node, "SYS_TRAN_TIME", MP_STR,  sizeof(MTIVLOTHIS.SYS_TRAN_TIME), MTIVLOTHIS.SYS_TRAN_TIME);
                TRS.add_fieldmsg(out_node, "TRAN_CMF_2", MP_STR,  sizeof(MTIVLOTHIS.TRAN_CMF_2), MTIVLOTHIS.TRAN_CMF_2);
                TRS.add_fieldmsg(out_node, "OLD_OPER", MP_STR,  sizeof(MTIVLOTHIS.OLD_OPER), MTIVLOTHIS.OLD_OPER);

                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;
                //DBC_close_cplnmimsts(istep);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
                }

                list_item = TRS.add_node(out_node, "VIEW_LABELLIST_OUT");

             //HIS.TRAN_TIME,  HIS.TRAN_CMF_1 AS PROJECT, HIS.LOT_ID,HIS.MAT_ID, MAT.MAT_DESC, 
            //HIS.MAT_VER,  STS.VENDOR_ID, HIS.OLD_OPER, HIS.CREATE_QTY_1, HIS.OPER, HIS.QTY_1, HIS.CREATE_TIME

            TRS.add_string(list_item, "TRAN_TIME", MTIVLOTHIS.TRAN_TIME, sizeof(MTIVLOTHIS.TRAN_TIME));
            TRS.add_string(list_item, "PROJECT", MTIVLOTHIS.TRAN_CMF_1, sizeof(MTIVLOTHIS.TRAN_CMF_1));
            TRS.add_string(list_item, "LOT_ID", MTIVLOTHIS.LOT_ID, sizeof(MTIVLOTHIS.LOT_ID));
            TRS.add_string(list_item, "MAT_ID", MTIVLOTHIS.MAT_ID, sizeof(MTIVLOTHIS.MAT_ID));
            TRS.add_string(list_item, "MAT_DESC", MTIVLOTHIS.TRAN_COMMENT, sizeof(MTIVLOTHIS.TRAN_COMMENT));
            TRS.add_int(list_item, "MAT_VER", MTIVLOTHIS.MAT_VER);
            TRS.add_string(list_item, "VENDOR_ID", MTIVLOTHIS.VENDOR_LOT_ID, sizeof(MTIVLOTHIS.VENDOR_LOT_ID));
            TRS.add_string(list_item, "OLD_OPER", MTIVLOTHIS.OLD_OPER, sizeof(MTIVLOTHIS.OLD_OPER));
            TRS.add_int(list_item, "FROM_QTY", (int)MTIVLOTHIS.CREATE_QTY_1);
            TRS.add_string(list_item, "OPER", MTIVLOTHIS.OPER, sizeof(MTIVLOTHIS.OPER));
            TRS.add_int(list_item, "TO_QTY", (int)MTIVLOTHIS.QTY_1);
            TRS.add_string(list_item, "CREATE_TIME", MTIVLOTHIS.CREATE_TIME, sizeof(MTIVLOTHIS.CREATE_TIME));

        }
     }
	


    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot_NEW",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) 
return MP_FALSE;
    
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Lot_NEW_Validation()
        - Validation Check sub function of "TIV_View_Lot_NEW" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
//int TIV_View_Lot_NEW_Validation(char *s_msg_code,
//                                TRSNode *in_node, 
//                                TRSNode *out_node)
//{
//    struct MWIPFACDEF_TAG MWIPFACDEF;
//    struct MTIVLOTSTS_TAG MTIVLOTSTS;
//    struct MTIVMATDEF_TAG MTIVMATDEF;
//    struct MTIVTRSDTL_TAG MTIVTRSDTL;
//    struct MTIVOPRDEF_TAG MTIVOPRDEF;
//    struct MTIVLOTHIS_TAG MTIVLOTHIS;
//
//	struct MGCMTBLDAT_TAG MGCMTBLDAT;
//
//    /* ProcStep Validation */
//    if(COM_service_validation(s_msg_code,
//                              in_node,
//                              out_node,
//                              TRS.get_procstep(in_node),
//                              "123459A") == MP_FALSE)
//    {
//        return MP_FALSE;
//    }
//
//    /* Factory Validation */
//    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
//    {
//        strcpy(s_msg_code, "INV-0001");
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.e_type = MP_LOG_E_VALIDATION;
//        gs_log_type.category = MP_LOG_CATE_VIEW;
//        return MP_FALSE;
//    }    
//    /* Lot ID Validation */
//    
//    if(TRS.get_char(in_node, "NO_NEED_LOT")!='Y')
//    {
//        if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
//        {
//            strcpy(s_msg_code, "WIP-0001");
//            TRS.add_fieldmsg(out_node, "LOT_ID", MP_NVST);
//
//            gs_log_type.type = MP_LOG_ERROR;
//            gs_log_type.e_type = MP_LOG_E_VALIDATION;
//            gs_log_type.category = MP_LOG_CATE_VIEW;
//            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
//            return MP_FALSE;
//        }
//    }
//
//    DBC_init_mwipfacdef(&MWIPFACDEF);
//    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
//
//    DBC_select_mwipfacdef(1, &MWIPFACDEF);
//    if(DB_error_code != DB_SUCCESS) 
//    {
//        if(DB_error_code == DB_NOT_FOUND)
//        {
//            strcpy(s_msg_code, "INV-0005");
//            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
//        }
//        else 
//        {
//            strcpy(s_msg_code, "INV-0004");
//            gs_log_type.e_type = MP_LOG_E_SYSTEM;
//        }
//
//        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
//        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
//
//        gs_log_type.type = MP_LOG_ERROR;
//        gs_log_type.category = MP_LOG_CATE_VIEW;
//        return MP_FALSE;
//    }    
//
//    return MP_TRUE;
//}







