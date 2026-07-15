	/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_view_lot.c
    Description : View Inventory Lot Information related function module

    MES Version : 5.2.0.0

    Function List
        - TIV_View_Lot()
            + View Inventory Lot Information
        - TIV_VIEW_LOT()
            + Main Sub function of "TIV_View_Lot"
            + (called by "TIV_View_Lot")  
        - TIV_View_Lot_Validation()
            + Validation Check sub function of "TIV_VIEW_LOT" function
            + (called by "TIV_VIEW_LOT")

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


int TIV_View_Lot_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


/*******************************************************************************
    TIV_View_Lot()
        - View Inventory Lot Information
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_VIEW_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_VIEW_LOT", out_node);

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
    TIV_VIEW_LOT()
        - Main sub function of "TIV_View_Lot" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_VIEW_LOT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MTIVLOTSTS_TAG MTIVLOTSTS;
	//struct MTIVLOTSTS_TAG MTIVLOTSTS_SUB;
    //struct MTIVMATDEF_TAG MTIVMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
    struct MTIVTRSDTL_TAG MTIVTRSDTL;
    struct MTIVOPRDEF_TAG MTIVOPRDEF;
	struct MTIVTRSMST_TAG MTIVTRSMST;
	//struct CWIPDLVDTL_TAG CWIPDLVDTL;

	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	// CPLNMIMDEF_TAG CPLNMIMDEF;

	//TRSNode *lot_list;
	 TRSNode *list_item;
	 TRSNode *tran_mat_chk;
	 
	int istep = 0;
	int i_cursor_step = 0;
	//int iMaxProjectVer = 0;
    //double dQty = 0;
	double d_palletWt = 0;

	char test = ' ';

	char c_oper_check = ' ';


    LOG_head("TIV_View_Lot");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("oper", MP_NSTR, TRS.get_string(in_node, "OPER"));
    LOG_add("lot_id", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_VIEW);

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
	 
	test = TRS.get_procstep(in_node);


    /* Validation Check - Factory Validation */
    /*if(TIV_View_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }*/

	if(TRS.get_procstep(in_node)=='1'||TRS.get_procstep(in_node)=='4'||
	  TRS.get_procstep(in_node)=='9'||TRS.get_procstep(in_node)=='A'||
	  TRS.get_procstep(in_node)=='B')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");

		if(TRS.get_procstep(in_node)=='1')
		{
			istep = 1;
		}
		else if(TRS.get_procstep(in_node)=='4')
		{
			if (TRS.get_char(in_node, "LAST_ACTIVE_LOT_FLAG") == 'Y')
			{
				istep = 6;
			}
			else
			{
				istep = 4;
				TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
				c_oper_check = 'Y';
			}
		}
        else if(TRS.get_procstep(in_node)=='9')
        {
            istep = 9;
            TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
        }
		else if(TRS.get_procstep(in_node)=='A')
		{
			istep = 900;
		}
		else if(TRS.get_procstep(in_node)=='B')
		{
			istep = 14;
			memcpy(MTIVLOTSTS.LOT_ID, "#%", 2);
			TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");
			MTIVLOTSTS.MAT_VER =1;
			TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), in_node, "VENDOR_ID");

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

		/*if(TRS.get_char(in_node, "TRS_INFO_FLAG") == 'Y')
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
		}*/
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
	}
	else if(TRS.get_procstep(in_node)=='3'||TRS.get_procstep(in_node)=='5')
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY); 
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");

        if(TRS.get_procstep(in_node) == '3')
            DBC_select_mtivlotsts(7, &MTIVLOTSTS);
        else if(TRS.get_procstep(in_node) == '5')
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
			if(TRS.get_procstep(in_node) == '5')
				TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);
		    TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.category = MP_LOG_CATE_VIEW;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}
	}
	else if(TRS.get_procstep(in_node)=='6')
	{
		// LOT Infor with Transfer Request Validation
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
		istep = 1;
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

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.category = MP_LOG_CATE_VIEW;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}

		DBC_init_mtivtrsmst(&MTIVTRSMST);
		TRS.copy(MTIVTRSMST.FACTORY , sizeof(MTIVTRSMST.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVTRSMST.TRS_NO, sizeof(MTIVTRSMST.TRS_NO), in_node, "TRS_NO");
    
		DBC_select_mtivtrsmst(1, &MTIVTRSMST);

		if(DB_error_code != DB_SUCCESS) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "INV-0002");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}

			TRS.add_fieldmsg(out_node, "MTIVTRSMST SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSMST.FACTORY), MTIVTRSMST.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSMST.TRS_NO), MTIVTRSMST.TRS_NO);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		if (MTIVTRSMST.RT_FLAG == 'Y')
		{
			DBC_init_mtivtrsdtl(&MTIVTRSDTL);
			TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
			TRS.copy(MTIVTRSDTL.LOT_ID, sizeof(MTIVTRSDTL.LOT_ID), in_node, "LOT_ID");

			istep = 6;		
		}
		else
		{
			DBC_init_mtivtrsdtl(&MTIVTRSDTL);
			TRS.copy(MTIVTRSDTL.FACTORY , sizeof(MTIVTRSDTL.FACTORY), in_node, IN_FACTORY);
			TRS.copy(MTIVTRSDTL.TRS_NO, sizeof(MTIVTRSDTL.TRS_NO), in_node, "TRS_NO");
			memcpy(MTIVTRSDTL.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVTRSDTL.MAT_ID));

			istep = 4;
			
		}
		DBC_select_mtivtrsdtl(istep, &MTIVTRSDTL);	
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0714");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else 
			{
				strcpy(s_msg_code, "INV-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}

			TRS.add_fieldmsg(out_node, "MTIVREQDTL SELECT FOR UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVTRSDTL.FACTORY), MTIVTRSDTL.FACTORY);
			TRS.add_fieldmsg(out_node, "TRS_NO", MP_STR, sizeof(MTIVTRSDTL.TRS_NO), MTIVTRSDTL.TRS_NO);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MTIVLOTSTS.MAT_ID), MTIVLOTSTS.MAT_ID);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		 

		// LOT Infor with Transfer Request Validation
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
		if (COM_isnullspace(TRS.get_string(in_node, "INV_OPER")) == MP_FALSE)
		{
			TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "INV_OPER");
		}
		else
		{
			memcpy(MTIVLOTSTS.OPER, MTIVTRSDTL.FROM_OPER, sizeof(MTIVLOTSTS.OPER));
		}

		istep = 4;
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
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVLOTSTS.OPER), MTIVLOTSTS.OPER);

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.category = MP_LOG_CATE_VIEW;

		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
		}
	}
	else if(TRS.get_procstep(in_node)=='7')
	{
		// LOT Infor with Transfer Request Validation
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);    
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
		istep = 1;
		DBC_select_mtivlotsts(istep, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
		    if(DB_error_code == DB_NOT_FOUND)
		    {
				/*DBC_init_cwipdlvdtl(&CWIPDLVDTL);
				TRS.copy(CWIPDLVDTL.FACTORY, sizeof(CWIPDLVDTL.FACTORY), in_node, IN_FACTORY);
				TRS.copy(CWIPDLVDTL.LOT_ID, sizeof(CWIPDLVDTL.LOT_ID), in_node, "LOT_ID");
				istep = 2;
				DBC_select_cwipdlvdtl(istep, &CWIPDLVDTL);
				if(DB_error_code != DB_SUCCESS) 
				{
					if(DB_error_code == DB_NOT_FOUND)
					{
						strcpy(s_msg_code, "WIP-0700");
						gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					}
					else 
					{
						strcpy(s_msg_code, "WIP-0004");
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_dberrmsg(out_node, DB_error_msg);
					}
 
					TRS.add_fieldmsg(out_node, "CWIPDLVDTL SELET", MP_NVST);        
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR,  sizeof(CWIPDLVDTL.LOT_ID), CWIPDLVDTL.LOT_ID);
  
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				else
				{
					TRS.set_string(out_node, "IQC_LOT_ID", CWIPDLVDTL.GROUP_LOT_ID, sizeof(CWIPDLVDTL.GROUP_LOT_ID));
				}*/

		    }
		    else 
		    {
		        strcpy(s_msg_code, "INV-0004");
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        TRS.add_dberrmsg(out_node, DB_error_msg);
				
				TRS.add_fieldmsg(out_node, "MTIVLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
		    }
		}
		else
		{
			TRS.set_string(out_node, "IQC_LOT_ID", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
		}

		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE; 
	}

    TRS.add_string(out_node, "FACTORY", MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
	TRS.add_string(out_node, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
	TRS.add_string(out_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	TRS.add_string(out_node, "LOT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));    
	TRS.add_string(out_node, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
	TRS.add_int(out_node, "MAT_VER", MTIVLOTSTS.MAT_VER);
	TRS.add_char(out_node, "LOT_TYPE", MTIVLOTSTS.LOT_TYPE);
	TRS.add_double(out_node, "QTY_1", MTIVLOTSTS.QTY_1);
	TRS.add_double(out_node, "QTY_2", MTIVLOTSTS.QTY_2);
	TRS.add_double(out_node, "QTY_3", MTIVLOTSTS.QTY_3);
	TRS.add_double(out_node, "CREATE_QTY_1", MTIVLOTSTS.CREATE_QTY_1);
	TRS.add_double(out_node, "CREATE_QTY_2", MTIVLOTSTS.CREATE_QTY_2);
	TRS.add_double(out_node, "CREATE_QTY_3", MTIVLOTSTS.CREATE_QTY_3);
	TRS.add_string(out_node, "CREATE_TIME", MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME));
	TRS.add_string(out_node, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
	TRS.add_string(out_node, "OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
	TRS.add_char(out_node, "IN_OUT_FLAG", MTIVLOTSTS.IN_OUT_FLAG);
	TRS.add_string(out_node, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
	TRS.add_string(out_node, "LINE_NO", MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO));
	TRS.add_string(out_node, "UNIT_1", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
	TRS.add_string(out_node, "UNIT_2", MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
	TRS.add_string(out_node, "UNIT_3", MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));
	TRS.add_char(out_node, "INSPECTION_FLAG", MTIVLOTSTS.INSPECTION_FLAG);
	TRS.add_char(out_node, "INSPECTION_RESULT", MTIVLOTSTS.INSPECTION_RESULT);
	TRS.add_string(out_node, "LAST_TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
	TRS.add_string(out_node, "LAST_TRAN_TYPE", MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));
	TRS.add_string(out_node, "LAST_TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
	TRS.add_int(out_node, "LAST_HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);
	TRS.add_int(out_node, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
	TRS.add_string(out_node, "LAST_COMMENT", MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT));
	TRS.add_char(out_node, "LOT_DEL_FLAG", MTIVLOTSTS.LOT_DEL_FLAG);
	TRS.add_enc_string(out_node, "LOT_DEL_USER_ID", MTIVLOTSTS.LOT_DEL_USER_ID, sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
	TRS.add_string(out_node, "LOT_DEL_TIME", MTIVLOTSTS.LOT_DEL_TIME, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
	TRS.add_string(out_node, "LOT_DEL_REASON", MTIVLOTSTS.LOT_DEL_REASON, sizeof(MTIVLOTSTS.LOT_DEL_REASON));
	TRS.add_string(out_node, "LOCATION", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));
	TRS.add_string(out_node, "LOCATION_NO", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));
	TRS.add_char(out_node, "HOLD_FLAG", MTIVLOTSTS.HOLD_FLAG);
	TRS.add_string(out_node, "HOLD_CODE", MTIVLOTSTS.HOLD_CODE, sizeof(MTIVLOTSTS.HOLD_CODE));
	TRS.add_string(out_node, "RELEASE_CODE", MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE));
	TRS.add_char(out_node, "PICK_FLAG", MTIVLOTSTS.PICK_FLAG);
	TRS.add_char(out_node, "SHIP_FLAG", MTIVLOTSTS.SHIP_FLAG);
	TRS.add_string(out_node, "TIV_GRADE", MTIVLOTSTS.GRADE, sizeof(MTIVLOTSTS.GRADE));
	TRS.add_string(out_node, "ADD_ORDER_ID_1", MTIVLOTSTS.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS.ADD_ORDER_ID_1));
	TRS.add_string(out_node, "ADD_ORDER_LINE_1", MTIVLOTSTS.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_1));
	TRS.add_string(out_node, "ADD_ORDER_ID_2", MTIVLOTSTS.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS.ADD_ORDER_ID_2));
	TRS.add_string(out_node, "ADD_ORDER_LINE_2", MTIVLOTSTS.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_2));
	TRS.add_string(out_node, "ADD_ORDER_ID_3", MTIVLOTSTS.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS.ADD_ORDER_ID_3));
	TRS.add_string(out_node, "ADD_ORDER_LINE_3", MTIVLOTSTS.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_3));
	TRS.add_string(out_node, "VENDOR", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
	TRS.add_string(out_node, "PO_MAT_ID", MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID));
	TRS.add_int(out_node, "PO_SEQ_NUM", MTIVLOTSTS.PO_SEQ_NUM);

	
	TRS.add_string(out_node, "LOT_CREATE_TIME", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
	TRS.add_string(out_node, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
	TRS.add_string(out_node, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
	TRS.add_string(out_node, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
	TRS.add_string(out_node, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
	TRS.add_string(out_node, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
	TRS.add_string(out_node, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
	TRS.add_string(out_node, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
	TRS.add_string(out_node, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
	TRS.add_string(out_node, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
	TRS.add_string(out_node, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
	TRS.add_string(out_node, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
	TRS.add_string(out_node, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
	TRS.add_string(out_node, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
	TRS.add_string(out_node, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
	TRS.add_string(out_node, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
	TRS.add_string(out_node, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
	TRS.add_string(out_node, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
	TRS.add_string(out_node, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
	TRS.add_string(out_node, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
	TRS.add_string(out_node, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
	TRS.add_string(out_node, "TIV_OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
	TRS.add_string(out_node, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
	TRS.add_string(out_node, "VENDOR_LOT_ID", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
	TRS.add_string(out_node, "FROM_TO_LOT_ID", MTIVLOTSTS.FROM_TO_LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
	TRS.add_char(out_node, "FROM_TO_FLAG", MTIVLOTSTS.FROM_TO_FLAG);
	TRS.add_string(out_node, "LOT_GROUP_ID", MTIVLOTSTS.LOT_GROUP_ID, sizeof(MTIVLOTSTS.LOT_GROUP_ID));
	TRS.add_string(out_node, "EXPIRE_DATE", MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE));
    TRS.add_string(out_node, "INV_IN_TIME", MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME));
    TRS.add_string(out_node, "INV_OUT_TIME", MTIVLOTSTS.INV_OUT_TIME, sizeof(MTIVLOTSTS.INV_OUT_TIME));
    TRS.add_string(out_node, "OINV_IN_TIME", MTIVLOTSTS.OINV_IN_TIME, sizeof(MTIVLOTSTS.OINV_IN_TIME));
    TRS.add_string(out_node, "OINV_OUT_TIME", MTIVLOTSTS.OINV_OUT_TIME, sizeof(MTIVLOTSTS.OINV_OUT_TIME));
    TRS.add_string(out_node, "WIP_IN_TIME", MTIVLOTSTS.WIP_IN_TIME, sizeof(MTIVLOTSTS.WIP_IN_TIME));
    TRS.add_string(out_node, "WIP_OUT_TIME", MTIVLOTSTS.WIP_OUT_TIME, sizeof(MTIVLOTSTS.WIP_OUT_TIME));
    TRS.add_char(out_node, "TERM_FLAG", MTIVLOTSTS.TERM_FLAG);
    
	TRS.add_int(out_node, "FROM_TO_HIST_SEQ", MTIVLOTSTS.FROM_TO_HIST_SEQ);

	if (MTIVLOTSTS.INSPECTION_FLAG != ' ')
	{
		DBU_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_TYPE, strlen(MP_GCM_INSP_TYPE));
		MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_FLAG;
			 
		istep = 1;
		DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{	
				
			}
			else
			{	
				strcpy(s_msg_code,"GCM-0004");			
				TRS.add_dberrmsg(out_node, DB_error_msg);	
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
 
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		TRS.add_string(out_node, "INSPECTION_FLAG_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}
	else
	{
		TRS.add_string(out_node, "INSPECTION_FLAG_DESC", " ", strlen(" "));
	}

	if (MTIVLOTSTS.INSPECTION_RESULT != ' ')
	{
		DBU_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_RESULT, strlen(MP_GCM_INSP_RESULT));
		MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_RESULT;
			 
		istep = 1;
		DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{	
				
			}
			else
			{	
				strcpy(s_msg_code,"GCM-0004");			
				TRS.add_dberrmsg(out_node, DB_error_msg);	
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
				TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
 
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		TRS.add_string(out_node, "INSPECTION_RESULT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
	}
	else
	{
		TRS.add_string(out_node, "INSPECTION_RESULT_DESC", " ", strlen(" "));
	}

	if(TRS.get_procstep(in_node)=='6')
	{
		TRS.add_string(out_node, "TO_OPER", MTIVTRSDTL.TO_OPER, sizeof(MTIVTRSDTL.TO_OPER));
	}
	
	/*Get Pallete Weight*/
	d_palletWt = 0;

	if(COM_isnullspace(MTIVLOTSTS.INV_CMF_4) == MP_FALSE)
	{
		DBU_init_mgcmtbldat(&MGCMTBLDAT);

		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_PALLET_TYPE, strlen(MP_GCM_PALLET_TYPE));
		memcpy(MGCMTBLDAT.KEY_1, MTIVLOTSTS.INV_CMF_4, sizeof(MGCMTBLDAT.KEY_1));
			 
		istep = 1;
		DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code == DB_SUCCESS)
		{
			d_palletWt = COM_atof(MGCMTBLDAT.DATA_4,sizeof(MGCMTBLDAT.DATA_4));
		}
	}
	
	TRS.add_double(out_node, "PALLETE_WEIGHT", d_palletWt);

	/*Get Mat Desc*/
	DBC_init_mwipmatdef(&MWIPMATDEF);
	TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
	memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
    MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
	DBC_select_mwipmatdef(1, &MWIPMATDEF);
	if(DB_error_code != DB_SUCCESS) 
	{
	    if(DB_error_code == DB_NOT_FOUND)
	    {
	        strcpy(s_msg_code, "WIP-0006");
	        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
	    }
        else
	    {
	        strcpy(s_msg_code, "WIP-0004");
	        gs_log_type.e_type = MP_LOG_E_SYSTEM;	       
	    }

	    TRS.add_dberrmsg(out_node, DB_error_msg);

        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
	    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
	    TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);

	    gs_log_type.type = MP_LOG_ERROR;
	    gs_log_type.category = MP_LOG_CATE_VIEW;
	    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
	    return MP_FALSE;
	}

	//Material Info
	TRS.set_string(out_node, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
    TRS.set_string(out_node, "MAT_TYPE", MWIPMATDEF.MAT_TYPE, sizeof(MWIPMATDEF.MAT_TYPE));
    TRS.set_string(out_node, "MAT_GRP_1", MWIPMATDEF.MAT_GRP_1, sizeof(MWIPMATDEF.MAT_GRP_1));
    TRS.set_string(out_node, "MAT_GRP_2", MWIPMATDEF.MAT_GRP_2, sizeof(MWIPMATDEF.MAT_GRP_2));
    TRS.set_string(out_node, "MAT_GRP_3", MWIPMATDEF.MAT_GRP_3, sizeof(MWIPMATDEF.MAT_GRP_3));
    TRS.set_string(out_node, "MAT_GRP_4", MWIPMATDEF.MAT_GRP_4, sizeof(MWIPMATDEF.MAT_GRP_4));
    TRS.set_string(out_node, "MAT_GRP_5", MWIPMATDEF.MAT_GRP_5, sizeof(MWIPMATDEF.MAT_GRP_5));
    TRS.set_string(out_node, "MAT_GRP_6", MWIPMATDEF.MAT_GRP_6, sizeof(MWIPMATDEF.MAT_GRP_6));
    TRS.set_string(out_node, "MAT_GRP_7", MWIPMATDEF.MAT_GRP_7, sizeof(MWIPMATDEF.MAT_GRP_7));
    TRS.set_string(out_node, "MAT_GRP_8", MWIPMATDEF.MAT_GRP_8, sizeof(MWIPMATDEF.MAT_GRP_8));
    TRS.set_string(out_node, "MAT_GRP_9", MWIPMATDEF.MAT_GRP_9, sizeof(MWIPMATDEF.MAT_GRP_9));
    TRS.set_string(out_node, "MAT_GRP_10", MWIPMATDEF.MAT_GRP_10, sizeof(MWIPMATDEF.MAT_GRP_10));
    TRS.set_string(out_node, "MAT_CMF_1", MWIPMATDEF.MAT_CMF_1, sizeof(MWIPMATDEF.MAT_CMF_1));
    TRS.set_string(out_node, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, sizeof(MWIPMATDEF.MAT_CMF_2));
    TRS.set_string(out_node, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));
    TRS.set_string(out_node, "MAT_CMF_4", MWIPMATDEF.MAT_CMF_4, sizeof(MWIPMATDEF.MAT_CMF_4));
    TRS.set_string(out_node, "MAT_CMF_5", MWIPMATDEF.MAT_CMF_5, sizeof(MWIPMATDEF.MAT_CMF_5));
    TRS.set_string(out_node, "MAT_CMF_6", MWIPMATDEF.MAT_CMF_6, sizeof(MWIPMATDEF.MAT_CMF_6));
    TRS.set_string(out_node, "MAT_CMF_7", MWIPMATDEF.MAT_CMF_7, sizeof(MWIPMATDEF.MAT_CMF_7));
    TRS.set_string(out_node, "MAT_CMF_8", MWIPMATDEF.MAT_CMF_8, sizeof(MWIPMATDEF.MAT_CMF_8));
    TRS.set_string(out_node, "MAT_CMF_9", MWIPMATDEF.MAT_CMF_9, sizeof(MWIPMATDEF.MAT_CMF_9));
    TRS.set_string(out_node, "MAT_CMF_10", MWIPMATDEF.MAT_CMF_10, sizeof(MWIPMATDEF.MAT_CMF_10));
    TRS.set_string(out_node, "MAT_CMF_11", MWIPMATDEF.MAT_CMF_11, sizeof(MWIPMATDEF.MAT_CMF_11));
    TRS.set_string(out_node, "MAT_CMF_12", MWIPMATDEF.MAT_CMF_12, sizeof(MWIPMATDEF.MAT_CMF_12));
    TRS.set_string(out_node, "MAT_CMF_13", MWIPMATDEF.MAT_CMF_13, sizeof(MWIPMATDEF.MAT_CMF_13));
    TRS.set_string(out_node, "MAT_CMF_14", MWIPMATDEF.MAT_CMF_14, sizeof(MWIPMATDEF.MAT_CMF_14));
    TRS.set_string(out_node, "MAT_CMF_15", MWIPMATDEF.MAT_CMF_15, sizeof(MWIPMATDEF.MAT_CMF_15));
    TRS.set_string(out_node, "MAT_CMF_16", MWIPMATDEF.MAT_CMF_16, sizeof(MWIPMATDEF.MAT_CMF_16));
    TRS.set_string(out_node, "MAT_CMF_17", MWIPMATDEF.MAT_CMF_17, sizeof(MWIPMATDEF.MAT_CMF_17));
    TRS.set_string(out_node, "MAT_CMF_18", MWIPMATDEF.MAT_CMF_18, sizeof(MWIPMATDEF.MAT_CMF_18));
    TRS.set_string(out_node, "MAT_CMF_19", MWIPMATDEF.MAT_CMF_19, sizeof(MWIPMATDEF.MAT_CMF_19));
    TRS.set_string(out_node, "MAT_CMF_20", MWIPMATDEF.MAT_CMF_20, sizeof(MWIPMATDEF.MAT_CMF_20));
    TRS.set_string(out_node, "FIRST_FLOW", MWIPMATDEF.FIRST_FLOW, sizeof(MWIPMATDEF.FIRST_FLOW));
    TRS.set_int(out_node, "FIRST_FLOW_SEQ_NUM", MWIPMATDEF.FIRST_FLOW_SEQ_NUM);
    TRS.set_string(out_node, "LAST_FLOW", MWIPMATDEF.LAST_FLOW, sizeof(MWIPMATDEF.LAST_FLOW));
    TRS.set_int(out_node, "LAST_FLOW_SEQ_NUM", MWIPMATDEF.LAST_FLOW_SEQ_NUM);
    TRS.set_string(out_node, "MFG_DEVISION", MWIPMATDEF.MFG_DEVISION, sizeof(MWIPMATDEF.MFG_DEVISION));
    TRS.set_char(out_node, "SUBCONTRACT_FLAG", MWIPMATDEF.SUBCONTRACT_FLAG);
    //TRS.set_string(out_node, "BASE_MAT_ID", MWIPMATDEF.BASE_MAT_ID, sizeof(MWIPMATDEF.BASE_MAT_ID));
    TRS.set_string(out_node, "MAT_VENDOR_ID", MWIPMATDEF.VENDOR_ID, sizeof(MWIPMATDEF.VENDOR_ID));
    //TRS.set_string(out_node, "VENDOR_MAT_ID", MWIPMATDEF.VENDOR_MAT_ID, sizeof(MWIPMATDEF.VENDOR_MAT_ID));
    TRS.set_string(out_node, "CUSTOMER_ID", MWIPMATDEF.CUSTOMER_ID, sizeof(MWIPMATDEF.CUSTOMER_ID));
    TRS.set_string(out_node, "CUSTOMER_MAT_ID", MWIPMATDEF.CUSTOMER_MAT_ID, sizeof(MWIPMATDEF.CUSTOMER_MAT_ID));
    TRS.set_double(out_node, "DEF_QTY_1", MWIPMATDEF.DEF_QTY_1);
    TRS.set_double(out_node, "DEF_QTY_2", MWIPMATDEF.DEF_QTY_2);
    TRS.set_double(out_node, "DEF_QTY_3", MWIPMATDEF.DEF_QTY_3);
    TRS.set_string(out_node, "MAT_UNIT_1", MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1));
    TRS.set_string(out_node, "MAT_UNIT_2", MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2));
    TRS.set_string(out_node, "MAT_UNIT_3", MWIPMATDEF.UNIT_3, sizeof(MWIPMATDEF.UNIT_3));
    TRS.set_double(out_node, "WEIGHT_NET", MWIPMATDEF.WEIGHT_NET);
    TRS.set_double(out_node, "WEIGHT_GROSS", MWIPMATDEF.WEIGHT_GROSS);
    TRS.set_string(out_node, "WEIGHT_UNIT", MWIPMATDEF.WEIGHT_UNIT, sizeof(MWIPMATDEF.WEIGHT_UNIT));
    TRS.set_double(out_node, "VOLUME", MWIPMATDEF.VOLUME);
    TRS.set_string(out_node, "VOLUME_UNIT", MWIPMATDEF.VOLUME_UNIT, sizeof(MWIPMATDEF.VOLUME_UNIT));
    TRS.set_double(out_node, "DIMENSION_HR", MWIPMATDEF.DIMENSION_HR);
    TRS.set_string(out_node, "DIMENSION_HR_UNIT", MWIPMATDEF.DIMENSION_HR_UNIT, sizeof(MWIPMATDEF.DIMENSION_HR_UNIT));
    TRS.set_double(out_node, "DIMENSION_VT", MWIPMATDEF.DIMENSION_VT);
    TRS.set_string(out_node, "DIMENSION_VT_UNIT", MWIPMATDEF.DIMENSION_VT_UNIT, sizeof(MWIPMATDEF.DIMENSION_VT_UNIT));
    TRS.set_double(out_node, "DIMENSION_HT", MWIPMATDEF.DIMENSION_HT);
    TRS.set_string(out_node, "DIMENSION_HT_UNIT", MWIPMATDEF.DIMENSION_HT_UNIT, sizeof(MWIPMATDEF.DIMENSION_HT_UNIT));
    TRS.set_string(out_node, "BOM_SET_ID", MWIPMATDEF.BOM_SET_ID, sizeof(MWIPMATDEF.BOM_SET_ID));
    TRS.set_string(out_node, "DEF_INV_OPER", MWIPMATDEF.DEF_INV_OPER, sizeof(MWIPMATDEF.DEF_INV_OPER));
    TRS.set_char(out_node, "PACK_TYPE", MWIPMATDEF.PACK_TYPE);
    TRS.set_int(out_node, "PACK_LOT_COUNT", MWIPMATDEF.PACK_LOT_COUNT);
    TRS.set_double(out_node, "PACK_QTY", MWIPMATDEF.PACK_QTY);
    TRS.set_double(out_node, "LE_STOCK_LEVEL", MWIPMATDEF.LE_STOCK_LEVEL);
    TRS.set_double(out_node, "LW_STOCK_LEVEL", MWIPMATDEF.LW_STOCK_LEVEL);
    TRS.set_double(out_node, "HW_STOCK_LEVEL", MWIPMATDEF.HW_STOCK_LEVEL);
    TRS.set_double(out_node, "HE_STOCK_LEVEL", MWIPMATDEF.HE_STOCK_LEVEL);
    TRS.set_char(out_node, "IQC_FLAG", MWIPMATDEF.IQC_FLAG);
    TRS.set_char(out_node, "IQC_SAMPLE_FLAG", MWIPMATDEF.IQC_SAMPLE_FLAG);
    TRS.set_char(out_node, "IQC_SAMPLE_RULE", MWIPMATDEF.IQC_SAMPLE_RULE);
    TRS.set_char(out_node, "OQC_FLAG", MWIPMATDEF.OQC_FLAG);
    TRS.set_char(out_node, "OQC_SAMPLE_FLAG", MWIPMATDEF.OQC_SAMPLE_FLAG);
    TRS.set_char(out_node, "OQC_SAMPLE_RULE", MWIPMATDEF.OQC_SAMPLE_RULE);
    TRS.set_double(out_node, "TARGET_YIELD", MWIPMATDEF.TARGET_YIELD);
    TRS.set_double(out_node, "TARGET_DUE_DAY", MWIPMATDEF.TARGET_DUE_DAY);
    TRS.set_double(out_node, "TARGET_QTY_1", MWIPMATDEF.TARGET_QTY_1);
    TRS.set_double(out_node, "TARGET_QTY_2", MWIPMATDEF.TARGET_QTY_2);
    TRS.set_double(out_node, "TARGET_QTY_3", MWIPMATDEF.TARGET_QTY_3);
    TRS.set_string(out_node, "APPLY_START_TIME", MWIPMATDEF.APPLY_START_TIME, sizeof(MWIPMATDEF.APPLY_START_TIME));
    TRS.set_string(out_node, "APPLY_END_TIME", MWIPMATDEF.APPLY_END_TIME, sizeof(MWIPMATDEF.APPLY_END_TIME));
    TRS.set_char(out_node, "APPROVAL_FLAG", MWIPMATDEF.APPROVAL_FLAG);
    TRS.set_string(out_node, "APPROVAL_USER_ID", MWIPMATDEF.APPROVAL_USER_ID, sizeof(MWIPMATDEF.APPROVAL_USER_ID));
    TRS.set_string(out_node, "APPROVAL_TIME", MWIPMATDEF.APPROVAL_TIME, sizeof(MWIPMATDEF.APPROVAL_TIME));
    TRS.set_char(out_node, "RELEASE_FLAG", MWIPMATDEF.RELEASE_FLAG);
    TRS.set_string(out_node, "RELEASE_USER_ID", MWIPMATDEF.RELEASE_USER_ID, sizeof(MWIPMATDEF.RELEASE_USER_ID));
    TRS.set_string(out_node, "RELEASE_TIME", MWIPMATDEF.RELEASE_TIME, sizeof(MWIPMATDEF.RELEASE_TIME));
    TRS.set_char(out_node, "DEACTIVE_FLAG", MWIPMATDEF.DEACTIVE_FLAG);
    TRS.set_string(out_node, "DEACTIVE_USER_ID", MWIPMATDEF.DEACTIVE_USER_ID, sizeof(MWIPMATDEF.DEACTIVE_USER_ID));
    TRS.set_string(out_node, "DEACTIVE_TIME", MWIPMATDEF.DEACTIVE_TIME, sizeof(MWIPMATDEF.DEACTIVE_TIME));
    TRS.set_char(out_node, "DELETE_FLAG", MWIPMATDEF.DELETE_FLAG);
    //TRS.set_string(out_node, "DELETE_USER_ID", MWIPMATDEF.DELETE_USER_ID, sizeof(MWIPMATDEF.DELETE_USER_ID));
    //TRS.set_string(out_node, "DELETE_TIME", MWIPMATDEF.DELETE_TIME, sizeof(MWIPMATDEF.DELETE_TIME));
    //TRS.set_string(out_node, "CREATE_USER_ID", MWIPMATDEF.CREATE_USER_ID, sizeof(MWIPMATDEF.CREATE_USER_ID));
    //TRS.set_string(out_node, "CREATE_TIME", MWIPMATDEF.CREATE_TIME, sizeof(MWIPMATDEF.CREATE_TIME));
    //TRS.set_string(out_node, "UPDATE_USER_ID", MWIPMATDEF.UPDATE_USER_ID, sizeof(MWIPMATDEF.UPDATE_USER_ID));
    //TRS.set_string(out_node, "UPDATE_TIME", MWIPMATDEF.UPDATE_TIME, sizeof(MWIPMATDEF.UPDATE_TIME));
    TRS.set_string(out_node, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));


    //INVentory Lot을 조회하여 Inventory의 오퍼와 일치하는 Lot를 _해둔다. 
		//memcpy(MWIPOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));

	/*Get Oper Desc*/
    DBC_init_mtivoprdef(&MTIVOPRDEF);
    memcpy(MTIVOPRDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
    memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));    
    
    DBC_select_mtivoprdef(1, &MTIVOPRDEF);    
    if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0010");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }

        TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);        
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }  

	TRS.add_string(out_node, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
	TRS.add_string(out_node, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));

	if (MTIVLOTSTS.VENDOR_ID[0] != ' ')
	{
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_VENDOR, strlen(MP_GCM_VENDOR));
		memcpy(MGCMTBLDAT.KEY_1, MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
	 
		istep = 1;
		DBC_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{

			}
			else
			{
				strcpy(s_msg_code,"GCM-0008");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "DATA_2", MP_STR, sizeof(MGCMTBLDAT.DATA_2), MGCMTBLDAT.DATA_2);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
 
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}		
		}

		TRS.add_string(out_node, "VENDOR_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));   
	}
	

    //Get Sum Value
    /*if(TRS.get_char(in_node, "NO_NEED_LOT")=='Y')
    {
        DBC_init_mtivlotsts(&MTIVLOTSTS);
        TRS.copy(MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);
        TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");
        MTIVLOTSTS.MAT_VER = TRS.get_int(in_node, "MAT_VER");
        TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
        dQty = (double)DBC_select_mtivlotsts_scalar(7, &MTIVLOTSTS);

        TRS.add_double(out_node, "CURRENT_QTY", dQty);
    }*/


	/*if(TRS.get_char(in_node, "SUB_STEP") == '1')
	{
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_SHOP, strlen(MP_GCM_SHOP));
		TRS.copy(MGCMTBLDAT.DATA_2, sizeof(MGCMTBLDAT.DATA_2), out_node, "OPER");

		istep = 102;
		DBC_select_mgcmtbldat(istep, &MGCMTBLDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{

			}
			else
			{
				strcpy(s_msg_code,"GCM-0008");
				TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "DATA_2", MP_STR, sizeof(MGCMTBLDAT.DATA_2), MGCMTBLDAT.DATA_2);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
 
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}		
		}

		TRS.add_string(out_node, "SHOP", MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1));   
	}
*/
	//if(TRS.get_char(in_node, "LOT_SUMMARY_FLAG")== 'Y')
	//{
	//	//DBC_init_mtivlotsts(&MTIVLOTSTS);
	//	DBC_open_mtivlotsts(1, &MTIVLOTSTS);
	//	if(DB_error_code==DB_SUCCESS)
	//	{
	//	
	//		while(1)
	//		{
	//			DBC_fetch_mtivlotsts(1, &MTIVLOTSTS);
	//			if(DB_error_code!=DB_SUCCESS)
	//			{
	//				DBC_close_mtivlotsts(1);
	//				break;
	//			}
	//			lot_list = TRS.add_node(out_node, "LOT_LIST");
	//			TRS.set_string(lot_list, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
	//			TRS.set_double(lot_list, "QTY_1", MTIVLOTSTS.QTY_1);
	//			TRS.set_char(lot_list, "HOLD_FLAG", MTIVLOTSTS.HOLD_FLAG);

	//			DBC_init_mtivoprdef(&MTIVOPRDEF);
	//			memcpy(MTIVOPRDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
	//			memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));
	//			DBC_select_mtivoprdef(1, &MTIVOPRDEF);

	//			TRS.set_string(lot_list, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));


	//		}
	//	}
	//}

	/*if (TRS.get_char(in_node, "CHECK_FROM_TO")== 'Y')
	{
		DBC_init_mtivoprdef(&MTIVOPRDEF);
		memcpy(MTIVOPRDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
		TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "FROM_OPER");
		
		DBC_select_mtivoprdef(1, &MTIVOPRDEF);    
		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0010");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}

			TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);        
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		TRS.add_string(out_node, "FROM_OPER_CMF_2", MTIVOPRDEF.OPER_CMF_2, sizeof(MTIVOPRDEF.OPER_CMF_2));


		DBC_init_mtivoprdef(&MTIVOPRDEF);
		memcpy(MTIVOPRDEF.FACTORY, MTIVLOTSTS.FACTORY, sizeof(MTIVOPRDEF.FACTORY));
		TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "TO_OPER");
		
		DBC_select_mtivoprdef(1, &MTIVOPRDEF);    
		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0010");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				TRS.add_dberrmsg(out_node, DB_error_msg);
			}

			TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);        
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_COMMON;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		TRS.add_string(out_node, "TO_OPER_CMF_2", MTIVOPRDEF.OPER_CMF_2, sizeof(MTIVOPRDEF.OPER_CMF_2));

		if (memcmp(TRS.get_string(out_node, "FROM_OPER_CMF_2"), "INV", strlen("INV")) == 0 && 
			memcmp(TRS.get_string(out_node, "TO_OPER_CMF_2"), "WIP", strlen("WIP")) == 0)
		{

			DBC_init_mtivlotsts(&MTIVLOTSTS_SUB);
			TRS.copy(MTIVLOTSTS_SUB.FACTORY , sizeof(MTIVLOTSTS_SUB.FACTORY), in_node, IN_FACTORY);    
			TRS.copy(MTIVLOTSTS_SUB.OPER, sizeof(MTIVLOTSTS_SUB.OPER), in_node, "FROM_OPER");
			memcpy(MTIVLOTSTS_SUB.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS_SUB.MAT_ID));

			DBC_select_mtivlotsts(15, &MTIVLOTSTS_SUB);
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

				TRS.add_fieldmsg(out_node, "MTIVLOTSTS_SUB SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS_SUB.FACTORY), MTIVLOTSTS_SUB.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS_SUB.LOT_ID), MTIVLOTSTS_SUB.LOT_ID);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

			TRS.add_string(out_node, "MIN_LOT_ID", MTIVLOTSTS_SUB.LOT_ID, sizeof(MTIVLOTSTS_SUB.LOT_ID));

		}
	}*/
	
	if (TRS.get_char(in_node, "GROUP_INFO_FLAG") == 'Y' &&
		COM_isnullspace(MTIVLOTSTS.LOT_GROUP_ID) == MP_FALSE)
	{
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		TRS.copy(MTIVLOTSTS.FACTORY , sizeof(MTIVLOTSTS.FACTORY), in_node, IN_FACTORY);		
		TRS.copy(MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER), in_node, "OPER");
		TRS.copy(MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID), in_node, "LOT_ID");
		i_cursor_step = 13;

		DBC_open_mtivlotsts(i_cursor_step, &MTIVLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "INV-0004");
			TRS.add_fieldmsg(out_node, "MTIVLOTSTS OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);        
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		while(1) 
		{
			DBC_fetch_mtivlotsts(i_cursor_step, &MTIVLOTSTS);
			if(DB_error_code == DB_NOT_FOUND) 
			{
				DBC_close_mtivlotsts(i_cursor_step);
				break;
			}
			else if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
			{
				strcpy(s_msg_code, "INV-0004");
				TRS.add_fieldmsg(out_node, "MTIVLOTSTS FETCH", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVLOTSTS.FACTORY), MTIVLOTSTS.FACTORY);            
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MTIVLOTSTS.LOT_ID), MTIVLOTSTS.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				DBC_close_mtivlotsts(i_cursor_step);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			if(COM_check_node_length(out_node) == MP_FALSE)
			{
				TRS.add_string(out_node, "NEXT_LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
				DBC_close_mwiplotsts(i_cursor_step);
				break;
			}

			list_item = TRS.add_node(out_node, "LOT_LIST");

			TRS.add_string(list_item, "FACTORY", MTIVLOTSTS.FACTORY, sizeof(MTIVLOTSTS.FACTORY));
			TRS.add_string(list_item, "OPER", MTIVLOTSTS.OPER, sizeof(MTIVLOTSTS.OPER));
			TRS.add_string(list_item, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
			TRS.add_string(list_item, "LOT_DESC", MTIVLOTSTS.LOT_DESC, sizeof(MTIVLOTSTS.LOT_DESC));    
			TRS.add_string(list_item, "MAT_ID", MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID));
			TRS.add_int(list_item, "MAT_VER", MTIVLOTSTS.MAT_VER);
			TRS.add_char(list_item, "LOT_TYPE", MTIVLOTSTS.LOT_TYPE);
			TRS.add_double(list_item, "QTY_1", MTIVLOTSTS.QTY_1);
			TRS.add_double(list_item, "QTY_2", MTIVLOTSTS.QTY_2);
			TRS.add_double(list_item, "QTY_3", MTIVLOTSTS.QTY_3);
			TRS.add_double(list_item, "CREATE_QTY_1", MTIVLOTSTS.CREATE_QTY_1);
			TRS.add_double(list_item, "CREATE_QTY_2", MTIVLOTSTS.CREATE_QTY_2);
			TRS.add_double(list_item, "CREATE_QTY_3", MTIVLOTSTS.CREATE_QTY_3);
			TRS.add_string(list_item, "CREATE_TIME", MTIVLOTSTS.CREATE_TIME, sizeof(MTIVLOTSTS.CREATE_TIME));
			TRS.add_string(list_item, "CREATE_CODE", MTIVLOTSTS.CREATE_CODE, sizeof(MTIVLOTSTS.CREATE_CODE));
			TRS.add_string(list_item, "OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
			TRS.add_char(list_item, "IN_OUT_FLAG", MTIVLOTSTS.IN_OUT_FLAG);
			TRS.add_string(list_item, "ORDER_ID", MTIVLOTSTS.ORDER_ID, sizeof(MTIVLOTSTS.ORDER_ID));
			TRS.add_string(list_item, "LINE_NO", MTIVLOTSTS.LINE_NO, sizeof(MTIVLOTSTS.LINE_NO));
			TRS.add_string(list_item, "UNIT_1", MTIVLOTSTS.UNIT_1, sizeof(MTIVLOTSTS.UNIT_1));
			TRS.add_string(list_item, "UNIT_2", MTIVLOTSTS.UNIT_2, sizeof(MTIVLOTSTS.UNIT_2));
			TRS.add_string(list_item, "UNIT_3", MTIVLOTSTS.UNIT_3, sizeof(MTIVLOTSTS.UNIT_3));
			TRS.add_char(list_item, "INSPECTION_FLAG", MTIVLOTSTS.INSPECTION_FLAG);
			TRS.add_char(list_item, "INSPECTION_RESULT", MTIVLOTSTS.INSPECTION_RESULT);
			TRS.add_string(list_item, "LAST_TRAN_CODE", MTIVLOTSTS.LAST_TRAN_CODE, sizeof(MTIVLOTSTS.LAST_TRAN_CODE));
			TRS.add_string(list_item, "LAST_TRAN_TYPE", MTIVLOTSTS.LAST_TRAN_TYPE, sizeof(MTIVLOTSTS.LAST_TRAN_TYPE));
			TRS.add_string(list_item, "LAST_TRAN_TIME", MTIVLOTSTS.LAST_TRAN_TIME, sizeof(MTIVLOTSTS.LAST_TRAN_TIME));
			TRS.add_int(list_item, "LAST_LOT_GRP_SEQ", MTIVLOTSTS.LAST_LOT_GRP_SEQ);
			TRS.add_int(list_item, "LAST_ACTIVE_LOT_GRP_SEQ", MTIVLOTSTS.LAST_ACTIVE_LOT_GRP_SEQ);
			TRS.add_int(list_item, "LAST_HIST_SEQ", MTIVLOTSTS.LAST_HIST_SEQ);
			TRS.add_int(list_item, "LAST_ACTIVE_HIST_SEQ", MTIVLOTSTS.LAST_ACTIVE_HIST_SEQ);
			TRS.add_string(list_item, "LAST_COMMENT", MTIVLOTSTS.LAST_TRAN_COMMENT, sizeof(MTIVLOTSTS.LAST_TRAN_COMMENT));
			TRS.add_char(list_item, "LOT_DEL_FLAG", MTIVLOTSTS.LOT_DEL_FLAG);
			TRS.add_enc_string(list_item, "LOT_DEL_USER_ID", MTIVLOTSTS.LOT_DEL_USER_ID, sizeof(MTIVLOTSTS.LOT_DEL_USER_ID));
			TRS.add_string(list_item, "LOT_DEL_TIME", MTIVLOTSTS.LOT_DEL_TIME, sizeof(MTIVLOTSTS.LOT_DEL_TIME));
			TRS.add_string(list_item, "LOT_DEL_REASON", MTIVLOTSTS.LOT_DEL_REASON, sizeof(MTIVLOTSTS.LOT_DEL_REASON));
			TRS.add_string(list_item, "LOCATION", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));    
			TRS.add_string(list_item, "LOCATION_NO", MTIVLOTSTS.LOCATION_NO, sizeof(MTIVLOTSTS.LOCATION_NO));    
			TRS.add_char(list_item, "HOLD_FLAG", MTIVLOTSTS.HOLD_FLAG);
			TRS.add_string(list_item, "HOLD_CODE", MTIVLOTSTS.HOLD_CODE, sizeof(MTIVLOTSTS.HOLD_CODE));
			TRS.add_string(list_item, "RELEASE_CODE", MTIVLOTSTS.RELEASE_CODE, sizeof(MTIVLOTSTS.RELEASE_CODE));
			TRS.add_char(list_item, "PICK_FLAG", MTIVLOTSTS.PICK_FLAG);
			TRS.add_char(list_item, "SHIP_FLAG", MTIVLOTSTS.SHIP_FLAG);
			//TRS.add_string(list_item, "FROM_LOT_ID", MTIVLOTSTS.FROM_LOT_ID, sizeof(MTIVLOTSTS.FROM_LOT_ID));
			//TRS.add_string(list_item, "FROM_OPER", MTIVLOTSTS.FROM_OPER, sizeof(MTIVLOTSTS.FROM_OPER));
			TRS.add_string(list_item, "TIV_GRADE", MTIVLOTSTS.GRADE, sizeof(MTIVLOTSTS.GRADE));
			TRS.add_string(list_item, "ADD_ORDER_ID_1", MTIVLOTSTS.ADD_ORDER_ID_1, sizeof(MTIVLOTSTS.ADD_ORDER_ID_1));
			TRS.add_string(list_item, "ADD_ORDER_LINE_1", MTIVLOTSTS.ADD_ORDER_LINE_1, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_1));
			TRS.add_string(list_item, "ADD_ORDER_ID_2", MTIVLOTSTS.ADD_ORDER_ID_2, sizeof(MTIVLOTSTS.ADD_ORDER_ID_2));
			TRS.add_string(list_item, "ADD_ORDER_LINE_2", MTIVLOTSTS.ADD_ORDER_LINE_2, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_2));
			TRS.add_string(list_item, "ADD_ORDER_ID_3", MTIVLOTSTS.ADD_ORDER_ID_3, sizeof(MTIVLOTSTS.ADD_ORDER_ID_3));
			TRS.add_string(list_item, "ADD_ORDER_LINE_3", MTIVLOTSTS.ADD_ORDER_LINE_3, sizeof(MTIVLOTSTS.ADD_ORDER_LINE_3));
			TRS.add_string(list_item, "VENDOR", MTIVLOTSTS.VENDOR_LOT_ID, sizeof(MTIVLOTSTS.VENDOR_LOT_ID));
			TRS.add_string(list_item, "PO_MAT_ID", MTIVLOTSTS.PO_MAT_ID, sizeof(MTIVLOTSTS.PO_MAT_ID));
			TRS.add_int(list_item, "PO_SEQ_NUM", MTIVLOTSTS.PO_SEQ_NUM);
			TRS.add_string(list_item, "INV_CMF_1", MTIVLOTSTS.INV_CMF_1, sizeof(MTIVLOTSTS.INV_CMF_1));
			TRS.add_string(list_item, "INV_CMF_2", MTIVLOTSTS.INV_CMF_2, sizeof(MTIVLOTSTS.INV_CMF_2));
			TRS.add_string(list_item, "INV_CMF_3", MTIVLOTSTS.INV_CMF_3, sizeof(MTIVLOTSTS.INV_CMF_3));
			TRS.add_string(list_item, "INV_CMF_4", MTIVLOTSTS.INV_CMF_4, sizeof(MTIVLOTSTS.INV_CMF_4));
			TRS.add_string(list_item, "INV_CMF_5", MTIVLOTSTS.INV_CMF_5, sizeof(MTIVLOTSTS.INV_CMF_5));
			TRS.add_string(list_item, "INV_CMF_6", MTIVLOTSTS.INV_CMF_6, sizeof(MTIVLOTSTS.INV_CMF_6));
			TRS.add_string(list_item, "INV_CMF_7", MTIVLOTSTS.INV_CMF_7, sizeof(MTIVLOTSTS.INV_CMF_7));
			TRS.add_string(list_item, "INV_CMF_8", MTIVLOTSTS.INV_CMF_8, sizeof(MTIVLOTSTS.INV_CMF_8));
			TRS.add_string(list_item, "INV_CMF_9", MTIVLOTSTS.INV_CMF_9, sizeof(MTIVLOTSTS.INV_CMF_9));
			TRS.add_string(list_item, "INV_CMF_10", MTIVLOTSTS.INV_CMF_10, sizeof(MTIVLOTSTS.INV_CMF_10));
			TRS.add_string(list_item, "INV_CMF_11", MTIVLOTSTS.INV_CMF_11, sizeof(MTIVLOTSTS.INV_CMF_11));
			TRS.add_string(list_item, "INV_CMF_12", MTIVLOTSTS.INV_CMF_12, sizeof(MTIVLOTSTS.INV_CMF_12));
			TRS.add_string(list_item, "INV_CMF_13", MTIVLOTSTS.INV_CMF_13, sizeof(MTIVLOTSTS.INV_CMF_13));
			TRS.add_string(list_item, "INV_CMF_14", MTIVLOTSTS.INV_CMF_14, sizeof(MTIVLOTSTS.INV_CMF_14));
			TRS.add_string(list_item, "INV_CMF_15", MTIVLOTSTS.INV_CMF_15, sizeof(MTIVLOTSTS.INV_CMF_15));
			TRS.add_string(list_item, "INV_CMF_16", MTIVLOTSTS.INV_CMF_16, sizeof(MTIVLOTSTS.INV_CMF_16));
			TRS.add_string(list_item, "INV_CMF_17", MTIVLOTSTS.INV_CMF_17, sizeof(MTIVLOTSTS.INV_CMF_17));
			TRS.add_string(list_item, "INV_CMF_18", MTIVLOTSTS.INV_CMF_18, sizeof(MTIVLOTSTS.INV_CMF_18));
			TRS.add_string(list_item, "INV_CMF_19", MTIVLOTSTS.INV_CMF_19, sizeof(MTIVLOTSTS.INV_CMF_19));
			TRS.add_string(list_item, "INV_CMF_20", MTIVLOTSTS.INV_CMF_20, sizeof(MTIVLOTSTS.INV_CMF_20));
			TRS.add_string(list_item, "TIV_OWNER_CODE", MTIVLOTSTS.OWNER_CODE, sizeof(MTIVLOTSTS.OWNER_CODE));
			TRS.add_string(list_item, "VENDOR_ID", MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
			TRS.add_string(list_item, "FROM_TO_LOT_ID", MTIVLOTSTS.FROM_TO_LOT_ID, sizeof(MTIVLOTSTS.FROM_TO_LOT_ID));
			TRS.add_int(list_item, "FROM_TO_HIST_SEQ", MTIVLOTSTS.FROM_TO_HIST_SEQ);
			TRS.add_char(list_item, "FROM_TO_FLAG", MTIVLOTSTS.FROM_TO_FLAG);
			TRS.add_string(list_item, "LOT_GROUP_ID", MTIVLOTSTS.LOT_GROUP_ID, sizeof(MTIVLOTSTS.LOT_GROUP_ID));
			TRS.add_string(list_item, "EXPIRE_DATE", MTIVLOTSTS.EXPIRE_DATE, sizeof(MTIVLOTSTS.EXPIRE_DATE));
			TRS.add_string(list_item, "INV_IN_TIME", MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME));
			TRS.add_string(list_item, "INV_OUT_TIME", MTIVLOTSTS.INV_OUT_TIME, sizeof(MTIVLOTSTS.INV_OUT_TIME));
			TRS.add_string(list_item, "OINV_IN_TIME", MTIVLOTSTS.OINV_IN_TIME, sizeof(MTIVLOTSTS.OINV_IN_TIME));
			TRS.add_string(list_item, "OINV_OUT_TIME", MTIVLOTSTS.OINV_OUT_TIME, sizeof(MTIVLOTSTS.OINV_OUT_TIME));
			TRS.add_string(list_item, "WIP_IN_TIME", MTIVLOTSTS.WIP_IN_TIME, sizeof(MTIVLOTSTS.WIP_IN_TIME));
			TRS.add_string(list_item, "WIP_OUT_TIME", MTIVLOTSTS.WIP_OUT_TIME, sizeof(MTIVLOTSTS.WIP_OUT_TIME));

			DBC_init_mwipmatdef(&MWIPMATDEF);
			TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
			memcpy(MWIPMATDEF.MAT_ID, MTIVLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
			MWIPMATDEF.MAT_VER = MTIVLOTSTS.MAT_VER;
			DBC_select_mwipmatdef(1, &MWIPMATDEF);
			if(DB_error_code != DB_SUCCESS) 
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "INV-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);

					TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.category = MP_LOG_CATE_COMMON;
					return MP_FALSE;
				}
			}
			TRS.add_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
			TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
			TRS.add_string(list_item, "BASE_MAT_ID", MWIPMATDEF.BASE_MAT_ID, sizeof(MWIPMATDEF.BASE_MAT_ID));
			TRS.add_string(list_item, "PACK_UNIT_1", MWIPMATDEF.UNIT_1, sizeof(MWIPMATDEF.UNIT_1));//PACK_UNIT_1
			TRS.add_string(list_item, "PACK_UNIT_2", MWIPMATDEF.UNIT_2, sizeof(MWIPMATDEF.UNIT_2));
			TRS.add_double(list_item, "DEF_QTY_1", MWIPMATDEF.DEF_QTY_1);
			TRS.add_double(list_item, "DEF_QTY_2", MWIPMATDEF.DEF_QTY_2);
			TRS.add_string(list_item, "MAT_TYPE", MWIPMATDEF.MAT_TYPE, sizeof(MWIPMATDEF.MAT_TYPE));

			TRS.add_string(list_item, "MAT_CMF_1", MWIPMATDEF.MAT_CMF_1, sizeof(MWIPMATDEF.MAT_CMF_1));
			TRS.add_string(list_item, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, sizeof(MWIPMATDEF.MAT_CMF_2));
			TRS.add_string(list_item, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));
			TRS.add_string(list_item, "MAT_CMF_4", MWIPMATDEF.MAT_CMF_4, sizeof(MWIPMATDEF.MAT_CMF_4));
			TRS.add_string(list_item, "MAT_CMF_5", MWIPMATDEF.MAT_CMF_5, sizeof(MWIPMATDEF.MAT_CMF_5));
			TRS.add_string(list_item, "MAT_CMF_6", MWIPMATDEF.MAT_CMF_6, sizeof(MWIPMATDEF.MAT_CMF_6));
			TRS.add_string(list_item, "MAT_CMF_7", MWIPMATDEF.MAT_CMF_7, sizeof(MWIPMATDEF.MAT_CMF_7));
			TRS.add_string(list_item, "MAT_CMF_8", MWIPMATDEF.MAT_CMF_8, sizeof(MWIPMATDEF.MAT_CMF_8));
			TRS.add_string(list_item, "MAT_CMF_9", MWIPMATDEF.MAT_CMF_9, sizeof(MWIPMATDEF.MAT_CMF_9));
			TRS.add_string(list_item, "MAT_CMF_10", MWIPMATDEF.MAT_CMF_10, sizeof(MWIPMATDEF.MAT_CMF_10));
			TRS.add_string(list_item, "MAT_CMF_11", MWIPMATDEF.MAT_CMF_11, sizeof(MWIPMATDEF.MAT_CMF_11));
			TRS.add_string(list_item, "MAT_CMF_12", MWIPMATDEF.MAT_CMF_12, sizeof(MWIPMATDEF.MAT_CMF_12));
			TRS.add_string(list_item, "MAT_CMF_13", MWIPMATDEF.MAT_CMF_13, sizeof(MWIPMATDEF.MAT_CMF_13));
			TRS.add_string(list_item, "MAT_CMF_14", MWIPMATDEF.MAT_CMF_14, sizeof(MWIPMATDEF.MAT_CMF_14));
			TRS.add_string(list_item, "MAT_CMF_15", MWIPMATDEF.MAT_CMF_15, sizeof(MWIPMATDEF.MAT_CMF_15));
			TRS.add_string(list_item, "MAT_CMF_16", MWIPMATDEF.MAT_CMF_16, sizeof(MWIPMATDEF.MAT_CMF_16));
			TRS.add_string(list_item, "MAT_CMF_17", MWIPMATDEF.MAT_CMF_17, sizeof(MWIPMATDEF.MAT_CMF_17));
			TRS.add_string(list_item, "MAT_CMF_18", MWIPMATDEF.MAT_CMF_18, sizeof(MWIPMATDEF.MAT_CMF_18));
			TRS.add_string(list_item, "MAT_CMF_19", MWIPMATDEF.MAT_CMF_19, sizeof(MWIPMATDEF.MAT_CMF_19));
			TRS.add_string(list_item, "MAT_CMF_20", MWIPMATDEF.MAT_CMF_20, sizeof(MWIPMATDEF.MAT_CMF_20));

			//DBC_init_mtivoprdef(&MTIVOPRDEF);
			//TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
			//memcpy(MTIVOPRDEF.OPER, MTIVLOTSTS.OPER, sizeof(MTIVOPRDEF.OPER));
			//DBC_select_mtivoprdef(1, &MTIVOPRDEF);
			//if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND) 
			//{
			//	strcpy(s_msg_code, "WIP-0004");
			//	gs_log_type.e_type = MP_LOG_E_SYSTEM;
			//	TRS.add_dberrmsg(out_node, DB_error_msg);

			//	TRS.add_fieldmsg(out_node, "MTIVOPRDEF SELECT", MP_NVST);
			//	TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MTIVOPRDEF.FACTORY), MTIVOPRDEF.FACTORY);
			//	TRS.add_fieldmsg(out_node, "OPER", MP_STR, sizeof(MTIVOPRDEF.OPER), MTIVOPRDEF.OPER);        
			//	TRS.add_dberrmsg(out_node, DB_error_msg);

			//	gs_log_type.type = MP_LOG_ERROR;
			//	gs_log_type.e_type = MP_LOG_E_SYSTEM;
			//	gs_log_type.category = MP_LOG_CATE_COMMON;
			//	return MP_FALSE;
			//}  
			//TRS.add_string(list_item, "OPER_DESC", MTIVOPRDEF.OPER_DESC, sizeof(MTIVOPRDEF.OPER_DESC));
			//TRS.add_string(list_item, "OPER_SHORT_DESC", MTIVOPRDEF.OPER_SHORT_DESC, sizeof(MTIVOPRDEF.OPER_SHORT_DESC));
			 
			if (MTIVLOTSTS.INSPECTION_FLAG != ' ')
			{
				DBU_init_mgcmtbldat(&MGCMTBLDAT);
				TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_TYPE, strlen(MP_GCM_INSP_TYPE));
				MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_FLAG;
			 
				istep = 1;
				DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{	
				
					}
					else
					{	
						strcpy(s_msg_code,"GCM-0004");			
						TRS.add_dberrmsg(out_node, DB_error_msg);	
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
						TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
						TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
						TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;
 
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}

				TRS.add_string(list_item, "INSPECTION_FLAG_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
			else
			{
				TRS.add_string(list_item, "INSPECTION_FLAG_DESC", " ", strlen(" "));
			}

			if (MTIVLOTSTS.INSPECTION_RESULT != ' ')
			{
				DBU_init_mgcmtbldat(&MGCMTBLDAT);
				TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_INSP_RESULT, strlen(MP_GCM_INSP_RESULT));
				MGCMTBLDAT.KEY_1[0] = MTIVLOTSTS.INSPECTION_RESULT;
			 
				istep = 1;
				DBU_select_mgcmtbldat(istep, &MGCMTBLDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{	
				
					}
					else
					{	
						strcpy(s_msg_code,"GCM-0004");			
						TRS.add_dberrmsg(out_node, DB_error_msg);	
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
						TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
						TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
						TRS.add_fieldmsg(out_node, "KEY_2", MP_STR, sizeof(MGCMTBLDAT.KEY_2), MGCMTBLDAT.KEY_2);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;
 
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				TRS.add_string(list_item, "INSPECTION_RESULT_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
			else
			{
				TRS.add_string(list_item, "INSPECTION_RESULT_DESC", " ", strlen(" "));
			}

			if (MTIVLOTSTS.VENDOR_ID[0] != ' ')
			{
				DBC_init_mgcmtbldat(&MGCMTBLDAT);
				TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
				memcpy(MGCMTBLDAT.TABLE_NAME, MP_GCM_VENDOR, strlen(MP_GCM_VENDOR));
				memcpy(MGCMTBLDAT.KEY_1, MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID));
	 
				istep = 1;
				DBC_select_mgcmtbldat(istep, &MGCMTBLDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					if (DB_error_code == DB_NOT_FOUND)
					{

					}
					else
					{
						strcpy(s_msg_code,"GCM-0008");
						TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
						TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
						TRS.add_fieldmsg(out_node, "DATA_2", MP_STR, sizeof(MGCMTBLDAT.DATA_2), MGCMTBLDAT.DATA_2);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_TRANS;
 
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}		
				}

				TRS.add_string(list_item, "VENDOR_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));   
			}
		}
	
	}

	//PDA 메뉴명이 넘어와야 MAT_GRP_2 제품 체크
	if(COM_isnullspace(TRS.get_string(in_node,"PDA_MENU_NAME")) ==MP_FALSE)
	{
		tran_mat_chk = TRS.add_node(in_node,"TRAN_MAT_GRP_CHK");

		TRS.add_nstring(tran_mat_chk, IN_PASSPORT, TRS.get_passport(in_node));
		TRS.add_char(tran_mat_chk, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_nstring(tran_mat_chk, IN_FACTORY, TRS.get_factory(in_node));
		TRS.add_nstring(tran_mat_chk, IN_USERID, TRS.get_userid(in_node));
		TRS.add_nstring(tran_mat_chk, IN_PASSWORD, TRS.get_password(in_node));
		TRS.add_char(tran_mat_chk, IN_PROCSTEP, TRS.get_procstep(in_node));
				
		TRS.add_nstring(tran_mat_chk,"PDA_MENU_NAME",TRS.get_string(in_node,"PDA_MENU_NAME"));
		TRS.add_string(tran_mat_chk,"MAT_ID",MTIVLOTSTS.MAT_ID,sizeof(MTIVLOTSTS.MAT_ID));
		TRS.add_int(tran_mat_chk,"MAT_VER",MTIVLOTSTS.MAT_VER);

		// LOT의 제품이 MENU에 해당하는 MAT_GRP_2와 일치하는지 체크
		//if(CUS_MAT_GRP2_CHK(s_msg_code,tran_mat_chk,out_node)==MP_FALSE) 
		//{
		//	return MP_FALSE;
		//}

	}

    if(COM_proc_user_routine("MES_UserTIV", "TIV_View_Lot",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}


/*******************************************************************************
    TIV_View_Lot_Validation()
        - Validation Check sub function of "TIV_VIEW_LOT" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int TIV_View_Lot_Validation(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                               "12345679AB") == MP_FALSE)
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
    
    if(TRS.get_char(in_node, "NO_NEED_LOT")!='Y')
    {
        if(COM_isnullspace(TRS.get_string(in_node, "LOT_ID")) == MP_TRUE)
        {
            strcpy(s_msg_code, "WIP-0001");
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







