/*******************************************************************************

    System      : MESplus
    Module      : CRPT_View_FullCell_Cart_Label
    File Name   : CRPT_View_Fullcell_Cart_Label.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.15   Miracom

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"

int CRPT_View_Fullcell_Cart_Label_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRPT_View_FullCell_Cart_Label()
        - View_FullCell_Cart_Label
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_View_Fullcell_Cart_Label(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRPT_VIEW_FULLCELL_CART_LABEL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRPT_View_Fullcell_Cart_Label", out_node);

    if(i_ret == MP_TRUE)
    {
        if(gb_multi_transaction == MP_FALSE)
        {
            DB_commit();
        }
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CRPT_VIEW_FULLCELL_CART_LABEL()
        - VIEW_FULLCELL_CART_LABEL
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CRPT_VIEW_FULLCELL_CART_LABEL(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct CWIPORDSTS_TAG CWIPORDSTS;
    TRSNode *list_item;

	char s_sys_time[14];
    int i_step;
	double num_fullcell_boxes = 0;
    double num_magazines = 0;
    double total_num_cells = 0;
    double num_magazine_150_cells = 0;
	  
	LOG_head("CWIP_VIEW_PACKING_LABEL_PRINT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Ordered by Magazine ID
        Step 2: Ordered by Scanning Time
        Step 3: Step 1 + Printing Validation
        Step 4: Step 1 + Without Order ID
    */

    if(CRPT_View_Fullcell_Cart_Label_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        return MP_FALSE;
    }

	if (TRS.get_procstep(in_node) == '1' || TRS.get_procstep(in_node) == '3' || TRS.get_procstep(in_node) == '4')
	{
		i_step = 7;
	}
	else if (TRS.get_procstep(in_node) == '2')
	{
		i_step = 8;
	}
	else
	{
		i_step = 0;
	}

    /* 1. Check Order */
    if (TRS.get_procstep(in_node) == '4') /* Reprint */
    {
	    CDB_init_cwipcelpak(&CWIPCELPAK);
        TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	    memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(in_node, "LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
        CWIPCELPAK.PACK_TYPE = 'F';
        CWIPCELPAK.STATUS_FLAG = 'I';

        CDB_select_cwipcelpak(2, &CWIPCELPAK);
	    if(DB_error_code != DB_SUCCESS)
	    {
            if(DB_error_code == DB_NOT_FOUND)
            {
		        strcpy(s_msg_code, "WIP-0590");
		        TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		        TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);

		        gs_log_type.type = MP_LOG_ERROR;
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        gs_log_type.category = MP_LOG_CATE_VIEW;
		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		        return MP_FALSE;
            }
            else
            {
		        strcpy(s_msg_code, "WIP-0004");
		        TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		        TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
		        TRS.add_dberrmsg(out_node,DB_error_msg);

		        gs_log_type.type = MP_LOG_ERROR;
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        gs_log_type.category = MP_LOG_CATE_VIEW;
		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		        return MP_FALSE;
            }
        }

	    CDB_init_cwipordsts(&CWIPORDSTS);
	    TRS.copy(CWIPORDSTS.FACTORY, sizeof(CWIPORDSTS.FACTORY), in_node, IN_FACTORY);
	    //TRS.copy(CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
        memcpy(CWIPORDSTS.ORDER_ID, CWIPCELPAK.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID));
	    CDB_select_cwipordsts(1,&CWIPORDSTS);
	    if(DB_error_code != DB_SUCCESS)
	    {
            if(DB_error_code == DB_NOT_FOUND)
		    {
			    strcpy(s_msg_code, "ORD-0002");
			    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		    }
            else
            {
                strcpy(s_msg_code, "ORD-0004");
                TRS.add_dberrmsg(out_node,DB_error_msg);
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CWIPORDSTS SELECT", MP_NVST);
		    TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
	    }	

	    TRS.add_double(out_node, "CLEAVING_PO_CNT", CWIPORDSTS.PROD_QTY);   
    }
    else /* Normal */
    {
	    CDB_init_cwipordsts(&CWIPORDSTS);
	    TRS.copy(CWIPORDSTS.FACTORY, sizeof(CWIPORDSTS.FACTORY), in_node, IN_FACTORY);
	    TRS.copy(CWIPORDSTS.ORDER_ID, sizeof(CWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
	    CDB_select_cwipordsts(1,&CWIPORDSTS);
	    if(DB_error_code != DB_SUCCESS)
	    {
            if(DB_error_code == DB_NOT_FOUND)
		    {
			    strcpy(s_msg_code, "ORD-0002");
			    gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		    }
            else
            {
                strcpy(s_msg_code, "ORD-0004");
                TRS.add_dberrmsg(out_node,DB_error_msg);
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CWIPORDSTS SELECT", MP_NVST);
		    TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(CWIPORDSTS.ORDER_ID), CWIPORDSTS.ORDER_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
	    }	

	    TRS.add_double(out_node, "CLEAVING_PO_CNT", CWIPORDSTS.PROD_QTY);   
    }

	/* 2. Number of Cell Boxes */
	CDB_init_cwipcelpak(&CWIPCELPAK);
	TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "LACK_ID");
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

	num_fullcell_boxes = CDB_select_cwipcelpak_scalar(7, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
        TRS.add_fieldmsg(out_node, "PACK_TYPE", MP_CHR, CWIPCELPAK.PACK_TYPE);
        TRS.add_fieldmsg(out_node, "STATUS_FLAG", MP_CHR, CWIPCELPAK.STATUS_FLAG);
		TRS.add_dberrmsg(out_node,DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	TRS.add_double(out_node, "FULLCELL_CNT", num_fullcell_boxes);

	/* 3. Number of Magazines */
	CDB_init_cwipcelpak(&CWIPCELPAK);
	TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "LACK_ID");
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

	num_magazines = CDB_select_cwipcelpak_scalar(6, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
        TRS.add_fieldmsg(out_node, "PACK_TYPE", MP_CHR, CWIPCELPAK.PACK_TYPE);
        TRS.add_fieldmsg(out_node, "STATUS_FLAG", MP_CHR, CWIPCELPAK.STATUS_FLAG);
		TRS.add_dberrmsg(out_node,DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	TRS.add_double(out_node, "MAGAZINE_CNT", num_magazines);

	/* 4. Total Number of Cells */
	CDB_init_cwipcelpak(&CWIPCELPAK);
	TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "LACK_ID");
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

	total_num_cells = CDB_select_cwipcelpak_scalar(9, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
        TRS.add_fieldmsg(out_node, "PACK_TYPE", MP_CHR, CWIPCELPAK.PACK_TYPE);
        TRS.add_fieldmsg(out_node, "STATUS_FLAG", MP_CHR, CWIPCELPAK.STATUS_FLAG);
		TRS.add_dberrmsg(out_node,DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	TRS.add_double(out_node, "TOTAL_NUM_CELLS", total_num_cells);

    /* Number of Cell Boxes must be 50*300 = 15000 */
    if (TRS.get_procstep(in_node) == '3')
    {
        /*
        if (total_num_cells < 50*300)
        {
		    strcpy(s_msg_code, "WIP-0587");
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        */
    }

    /* 5. Check whether magazine having 150 Cells exists or not */
    if (TRS.get_procstep(in_node) == '3')
    {
	    CDB_init_cwipcelpak(&CWIPCELPAK);
	    TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	    TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "LACK_ID");
        CWIPCELPAK.PACK_TYPE = 'F';
        CWIPCELPAK.STATUS_FLAG = 'I';

	    num_magazine_150_cells = CDB_select_cwipcelpak_scalar(10, &CWIPCELPAK);
	    if(DB_error_code != DB_SUCCESS)
	    {
		    strcpy(s_msg_code, "WIP-0004");
		    TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
		    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		    TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
            TRS.add_fieldmsg(out_node, "PACK_TYPE", MP_CHR, CWIPCELPAK.PACK_TYPE);
            TRS.add_fieldmsg(out_node, "STATUS_FLAG", MP_CHR, CWIPCELPAK.STATUS_FLAG);
		    TRS.add_dberrmsg(out_node,DB_error_msg);

		    gs_log_type.type = MP_LOG_ERROR;
		    gs_log_type.e_type = MP_LOG_E_SYSTEM;
		    gs_log_type.category = MP_LOG_CATE_VIEW;
		    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		    return MP_FALSE;
	    }

        if (num_magazine_150_cells >= 1)
        {
		    strcpy(s_msg_code, "WIP-0588");
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    /* 6. Full Cell Delivery Slip */
	CDB_init_cwipcelpak(&CWIPCELPAK);
	TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), in_node, "LACK_ID");
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

	CDB_open_cwipcelpak(i_step, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCELPAK OPEN", MP_NVST);
		TRS.add_fieldmsg(out_node, "CART_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	while(1)
	{
		CDB_fetch_cwipcelpak(i_step, &CWIPCELPAK);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_cwipcelpak(i_step);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPCELPAK FETCH", MP_NVST);
			TRS.add_fieldmsg(out_node, "CARRIER_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;
			CDB_close_cwipcelpak(i_step);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "VIEW_OUT");
		TRS.add_string(list_item, "MAGAZINE", CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID));             
		TRS.add_int(list_item, "CNT", CWIPCELPAK.PACK_QTY);                                                
		TRS.add_string(list_item, "SMALLBOX_ID", CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID));  
		TRS.add_string(list_item, "BATCH_NO", CWIPCELPAK.GR_BATCHNO, sizeof(CWIPCELPAK.GR_BATCHNO));             
		TRS.add_string(list_item, "CARRIER_ID", CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID));           
		TRS.add_string(list_item, "EFFICIENCY", CWIPCELPAK.POWERGRADE, sizeof(CWIPCELPAK.POWERGRADE));     
		TRS.add_string(list_item, "GRADE", CWIPCELPAK.QUALITYGRADE, sizeof(CWIPCELPAK.QUALITYGRADE));      
		//TRS.add_string(list_item, "MODULE_PO", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));          
		TRS.add_string(list_item, "CLEAVING_PO", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID));        
		TRS.add_double(list_item, "STOCK_CELL",0);                                                         
		TRS.add_string(list_item, "DATE_TIME", s_sys_time, sizeof(s_sys_time));                            
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;

}

/*******************************************************************************
	CRPT_View_Fullcell_Cart_Label_Validation()
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRPT_View_Fullcell_Cart_Label_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct MRASCRRDEF_TAG MRASCRRDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1234") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "WIP-0001");
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

	/* Check whether Cart ID exits or not */
	DBC_init_mrascrrdef(&MRASCRRDEF);
	TRS.copy(MRASCRRDEF.FACTORY, sizeof(MRASCRRDEF.FACTORY), in_node, IN_FACTORY);
	TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), in_node,"LACK_ID");
	memcpy(MRASCRRDEF.CRR_GROUP, "US_FH_C", strlen("US_FH_C")); /* Full/Half Cell Cart */

	DBC_select_mrascrrdef(101, &MRASCRRDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND) 
		{
			strcpy(s_msg_code, "RAS-0321");
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		}
		else 
		{
			strcpy(s_msg_code, "RAS-0004");
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			TRS.add_dberrmsg(out_node, DB_error_msg);
		}


		TRS.add_fieldmsg(out_node, "MRASCRRDEF SELECT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASCRRDEF.FACTORY), MRASCRRDEF.FACTORY);
		TRS.add_fieldmsg(out_node, "CRR_ID", MP_STR, sizeof(MRASCRRDEF.CRR_ID), MRASCRRDEF.CRR_ID);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

    return MP_TRUE;
}