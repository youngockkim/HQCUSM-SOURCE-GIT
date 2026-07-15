/*******************************************************************************

    System      : MESplus
    Module      : Packing FullCell
    File Name   : CWIP_packing_fullcell.c
    Description : SOI -> MES

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.05  SW.HWANG
	2          12,26  JUHYEON       ADD / MODIFY / DEBUG .....
	3     2024.02.23  BYUNGCHAE.KANG 자재추적성 반영
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.
*******************************************************************************/
#include "CUS_HQCUSM_common.h"


/*******************************************************************************
    CWIP_Packing_Fullcell()
        - SOI->MES Packing FullCell
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Packing_Fullcell(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_PACKING_FULLCELL(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Packing_Fullcell", out_node);

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
    CWIP_Packing_Fullcell()
        - SOI->MES Packing HalfCell
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_PACKING_FULLCELL(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF_FCELL;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CINVCELRCV_TAG CINVCELRCV;
    struct MRASCRRDEF_TAG MRASCRRDEF;
	struct CWIPCELMGZ_TAG CWIPCELMGZ;  // 자재 추적성

	char s_sys_time[14];
	char s_due_time[14];

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;

	TRSNode** list ;

	int i;
    int sizeOfCart = 0;

    double totalNumMagazine = 0;
    double numMagazine = 0;
    double numCells = 0;
    double totalNumCells = 0;
	clock_t start_time;

	//FOR DEBUG
	start_time = STOPWATCH_START();
	
	LOG_head("CWIP_PACKING_FULLCELL");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

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
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	/* 1. Check Order */
	DBC_init_mwipordsts(&MWIPORDSTS);
	TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, "FACTORY");
	TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
	DBC_select_mwipordsts(1, &MWIPORDSTS);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "ORD-0002");
            TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "ORD-0004");
            TRS.add_fieldmsg(out_node, "MWIPORDSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPORDSTS.FACTORY), MWIPORDSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "ORDER_ID", MP_STR, sizeof(MWIPORDSTS.ORDER_ID), MWIPORDSTS.ORDER_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}
	STOPWATCH_END("1. Check Order", start_time);
	
	/* 2. Check Product ID */
	DBC_init_mwipmatdef(&MWIPMATDEF);
	memcpy(MWIPMATDEF.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
	memcpy(MWIPMATDEF.MAT_ID, MWIPORDSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
	MWIPMATDEF.MAT_VER = 1;
	DBC_select_mwipmatdef(1, &MWIPMATDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "WIP-0006");
        TRS.set_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	// INSERT CWIPCELPAK
	list = TRS.get_list(in_node, "FULLCELL_PACK_LIST");

	STOPWATCH_END("2. Check Product ID", start_time);
	
    /* 3. Check whether Cart ID exits or not */
    DBC_init_mrascrrdef(&MRASCRRDEF);
    TRS.copy(MRASCRRDEF.FACTORY, sizeof(MRASCRRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), list[0],"LACK_ID");
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
	STOPWATCH_END("3. Check whether Cart ID exits or not", start_time);

    sizeOfCart = MRASCRRDEF.CRR_SIZE;

    /* 4. Check whether Magazine ID exits or not */
	DBC_init_mrascrrdef(&MRASCRRDEF);
    TRS.copy(MRASCRRDEF.FACTORY, sizeof(MRASCRRDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MRASCRRDEF.CRR_ID, sizeof(MRASCRRDEF.CRR_ID), list[0], "PACK_ID");
	memcpy(MRASCRRDEF.CRR_GROUP, "US_F_M", strlen("US_F_M")); /* Full Cell Magazine */

    DBC_select_mrascrrdef(101, &MRASCRRDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "RAS-0322");
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
	STOPWATCH_END("4. Check whether Magazine ID exits or not", start_time);
    
    /* 5. When using two 150-Qty cell boxes, check whether the current magazine is equal to the previous magazine */
	CDB_init_cwipcelpak(&CWIPCELPAK);
    TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	//memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[0],"LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
    TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID),list[0], "LACK_ID");  //Server crash 20200904
	CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

    CDB_select_cwipcelpak(5, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
        /*
        if(DB_error_code != DB_NOT_FOUND) 
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
        */
    }
    else // if(DB_error_code == DB_SUCCESS)
    {
	    if(TRS.mem_cmp(list[0], "PACK_ID", CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID)) != 0)
        {   
		    strcpy(s_msg_code, "WIP-0588");
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
	STOPWATCH_END("5. When using two 150-Qty cell boxes", start_time);
    
    /* 6-1. Check whether magazine ID was already used or not */
    numMagazine = 0;

	CDB_init_cwipcelpak(&CWIPCELPAK);
    TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	//memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[0],"LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID),list[0], "LACK_ID"); //server crash 20200904
    TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID), list[0], "PACK_ID");
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

    numMagazine = CDB_select_cwipcelpak_scalar(5, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
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
	STOPWATCH_END("6-1. Check whether magazine ID", start_time);
    
    /* 6-2. Check Number of Magazines */
    /* Number of Magazines must be no more than 50 */
    totalNumMagazine = 0;

	CDB_init_cwipcelpak(&CWIPCELPAK);
    TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	//memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[0],"LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID),list[0], "LACK_ID"); //server crash 20200904
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

    totalNumMagazine = CDB_select_cwipcelpak_scalar(6, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
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

    if (totalNumMagazine >= sizeOfCart && numMagazine == 0)
    {
		strcpy(s_msg_code, "WIP-0577");
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	STOPWATCH_END("6-2. Check Number of Magazines", start_time);
    
	/* 7. Check Total Number of Cells */
	CDB_init_cwipcelpak(&CWIPCELPAK);
	TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID), list[0], "LACK_ID");
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

	totalNumCells = CDB_select_cwipcelpak_scalar(9, &CWIPCELPAK);
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

    /*
    if (totalNumCells >= sizeOfCart * 300) 
    {
		strcpy(s_msg_code, "WIP-0589");
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
    */
	STOPWATCH_END("7. Check Total Number of Cells", start_time);
    
    /* 8. Check whether Order ID is equal to the other ones */
	CDB_init_cwipcelpak(&CWIPCELPAK);
    TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	//memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[0],"LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
	TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID),list[0], "LACK_ID"); //server crash 20200904
    CWIPCELPAK.PACK_TYPE = 'F';
    CWIPCELPAK.STATUS_FLAG = 'I';

    CDB_select_cwipcelpak(2, &CWIPCELPAK);
	if(DB_error_code != DB_SUCCESS)
	{
        if(DB_error_code != DB_NOT_FOUND) 
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
    else
    {
	    if(TRS.mem_cmp(in_node, "ORDER_ID", CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID)) != 0)
        {   
		    strcpy(s_msg_code, "WIP-0580");
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

	STOPWATCH_END("8. Check whether Order ID", start_time);
    
	for (i = 0; i < TRS.get_item_count(in_node, "FULLCELL_PACK_LIST"); i++)
	{
		//for debug
		LOG_head("FULLCELL_PACK_LIST CELL");
		TRS.log_add_all_members(list[i]);
		COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

		/* CELL RECEIVE 정보 GET */
		CDB_init_cinvcelrcv(&CINVCELRCV);
		memcpy(CINVCELRCV.FACTORY, MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY));
		//memcpy(CINVCELRCV.INV_LOT_ID, TRS.get_string(list[i],"CELL_BOX_ID"), sizeof(CWIPCELPAK.CELL_BOX_ID)); //SERVER Crash 2020.09.04
		TRS.copy(CINVCELRCV.INV_LOT_ID, sizeof(CINVCELRCV.INV_LOT_ID),list[i], "CELL_BOX_ID");
		CDB_select_cinvcelrcv(1, &CINVCELRCV);
		if(DB_error_code != DB_SUCCESS)
		{
			// CELL RECEVICE 정보가 없을경우 강제로 진행하기 위해 품번정보 하고 셋팅함.
			// 향후 옵션으로 처리하든 , BOM 으로 체크하던 (CWIPORDBOM 에서 CELL 품번을 가지고 와서 기본수량으로 처리)
			// 그것도 아니면 에러처리하던 해야함.
			//memcpy(CINVCELRCV.MATERIALDEFINITIONID, "000006581260411126", strlen("000006581260411126"));
			//memcpy(CINVCELRCV.ORI_QTY, "300", strlen("300"));
			strcpy(s_msg_code, "WIP-0560");
			TRS.set_fieldmsg(out_node, "CINVCELRCV_FCELL SELECT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//CELL BOX BLOCKING 정보가 있을경우.
		if (CINVCELRCV.BLOCK_STATUS == 'B')
		{
			//CELL BLOCK.
			strcpy(s_msg_code, "WIP-0563");
			TRS.set_fieldmsg(out_node, "CINVCELRCV_FCELL SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "CELL BOX ID", MP_STR, sizeof(CINVCELRCV.SMALLBOXID), CINVCELRCV.SMALLBOXID);
			TRS.add_fieldmsg(out_node, "BLOCK CODE", MP_STR, sizeof(CINVCELRCV.CMF_1), CINVCELRCV.CMF_1);
			TRS.add_fieldmsg(out_node, "BLOCK NAME", MP_STR, sizeof(CINVCELRCV.CMF_2), CINVCELRCV.CMF_2);

			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

        /* Check magazine duplication */
        STOPWATCH_END(" Check magazine duplication", start_time);
	    
		numCells = 0;
		CDB_init_cwipcelpak(&CWIPCELPAK);
        TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);	
	    //memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[i], "LACK_ID"), sizeof(CWIPCELPAK.LACK_ID)); /* Cart ID */
        //memcpy(CWIPCELPAK.PACK_ID, TRS.get_string(list[i], "PACK_ID"), sizeof(CWIPCELPAK.PACK_ID)); /* Magazine ID */
		TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID),list[i], "LACK_ID"); //server crash 20200904
		TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID),list[i], "PACK_ID"); //server crash 20200904

        CWIPCELPAK.PACK_TYPE = 'F';
        CWIPCELPAK.STATUS_FLAG = 'I';

        //numMagazine = CDB_select_cwipcelpak_scalar(5, &CWIPCELPAK);
        numCells = CDB_select_cwipcelpak_scalar(8, &CWIPCELPAK);
	    if(DB_error_code != DB_SUCCESS)
	    {
            if(DB_error_code != DB_NOT_FOUND) 
            {
		        strcpy(s_msg_code, "WIP-0004");
		        TRS.add_fieldmsg(out_node, "CWIPCELPAK SELECT SCALAR", MP_NVST);
                TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCELPAK.FACTORY), CWIPCELPAK.FACTORY);
		        TRS.add_fieldmsg(out_node, "LACK_ID", MP_STR, sizeof(CWIPCELPAK.LACK_ID), CWIPCELPAK.LACK_ID);
                TRS.add_fieldmsg(out_node, "PACK_ID", MP_STR, sizeof(CWIPCELPAK.PACK_ID), CWIPCELPAK.PACK_ID);
                TRS.add_fieldmsg(out_node, "PACK_TYPE", MP_CHR, CWIPCELPAK.PACK_TYPE);
                TRS.add_fieldmsg(out_node, "STATUS_FLAG", MP_CHR, CWIPCELPAK.STATUS_FLAG);
		        TRS.add_dberrmsg(out_node,DB_error_msg);

		        gs_log_type.type = MP_LOG_ERROR;
		        gs_log_type.e_type = MP_LOG_E_SYSTEM;
		        gs_log_type.category = MP_LOG_CATE_VIEW;
		        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		        return MP_FALSE;
            }
        }

        if (memcmp(CINVCELRCV.ORI_QTY, "300", 3) == 0)
        {
            /* Check Max Number of Cells */
            if (numCells >= 300) 
            {
		        strcpy(s_msg_code, "WIP-0586");
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }            
            else if (numCells + 300 > 300) 
            {
		        strcpy(s_msg_code, "WIP-0585");
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }            

        }
        else if (memcmp(CINVCELRCV.ORI_QTY, "150", 3) == 0)
        {
            /* Check Max Number of Cells */
            if (numCells >= 300) 
            {
		        strcpy(s_msg_code, "WIP-0586");
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }            
            else if (numCells + 150 > 300) 
            {
		        strcpy(s_msg_code, "WIP-0585");
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }            
        }
        else
        {
            /*
            if (numCells >= 300) 
            {
		        strcpy(s_msg_code, "WIP-0585");
                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
            */
        }
		STOPWATCH_END(" PRODUCT SELECT (FULL CELL )", start_time);

		//PRODUCT SELECT (FULL CELL )
		DBC_init_mwipmatdef(&MWIPMATDEF_FCELL);
		memcpy(MWIPMATDEF_FCELL.FACTORY, CINVCELRCV.FACTORY, sizeof(MWIPMATDEF_FCELL.FACTORY));
		memcpy(MWIPMATDEF_FCELL.MAT_ID, CINVCELRCV.MATERIALDEFINITIONID, sizeof(MWIPMATDEF_FCELL.MAT_ID));
		MWIPMATDEF_FCELL.MAT_VER = 1;
		DBC_select_mwipmatdef(1, &MWIPMATDEF_FCELL);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0006");
			TRS.set_fieldmsg(out_node, "MWIPMATDEF_FCELL SELECT", MP_NVST);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// Full Cell MAT-FLOW 등록 체크
		if(COM_isnullspace(MWIPMATDEF_FCELL.FIRST_FLOW) == MP_TRUE)
		{
			strcpy(s_msg_code, "WIP-0597");
            TRS.add_fieldmsg(out_node, "MWIPMATDEF_FCELL.MAT_ID", MP_STR, sizeof(MWIPMATDEF_FCELL.MAT_ID), MWIPMATDEF_FCELL.MAT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CDB_init_cwipcelpak(&CWIPCELPAK);

		memcpy(CWIPCELPAK.FACTORY, MWIPMATDEF_FCELL.FACTORY , sizeof(MWIPMATDEF_FCELL.FACTORY));
		//memcpy(CWIPCELPAK.PACK_ID, TRS.get_string(list[i],"PACK_ID"), sizeof(CWIPCELPAK.PACK_ID));
		TRS.copy(CWIPCELPAK.PACK_ID, sizeof(CWIPCELPAK.PACK_ID),list[i], "PACK_ID"); //server crash 20200904
		//memcpy(CWIPCELPAK.CELL_BOX_ID, TRS.get_string(list[i],"CELL_BOX_ID"), sizeof(CWIPCELPAK.CELL_BOX_ID));
		TRS.copy(CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELPAK.CELL_BOX_ID),list[i], "CELL_BOX_ID"); //server crash 20200904
		
		CDB_select_cwipcelpak(1, &CWIPCELPAK);
        if(DB_error_code == DB_SUCCESS)
		{
			//삭제하고 다시 넣음
			//CMF_3 이 EMI PARTITON KEY 이므로 변경되면 안됨.
			CDB_delete_cwipcelpak(1, &CWIPCELPAK);
		}
		else
		{
			memcpy(CWIPCELPAK.CMF_3, s_sys_time, 14);
		}
		CWIPCELPAK.PACK_TYPE = 'F';
		memcpy(CWIPCELPAK.MAT_ID, MWIPMATDEF_FCELL.MAT_ID, sizeof(MWIPMATDEF_FCELL.MAT_ID));
		//memcpy(CWIPCELPAK.LACK_ID, TRS.get_string(list[i],"LACK_ID"), sizeof(CWIPCELPAK.LACK_ID));
		TRS.copy(CWIPCELPAK.LACK_ID, sizeof(CWIPCELPAK.LACK_ID),list[i], "LACK_ID"); //server crash 20200904
		memcpy(CWIPCELPAK.OPER, HQCEL_M1_FCELL_MOVE_OPER, strlen(HQCEL_M1_FCELL_MOVE_OPER));
		memcpy(CWIPCELPAK.ORDER_ID, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
		
        CWIPCELPAK.PACK_QTY = COM_atoi(CINVCELRCV.ORI_QTY, sizeof(CINVCELRCV.ORI_QTY));
        
        /*
		if (TRS.get_int(list[i],"PACK_QTY") < 1)
		{
			//CWIPCELPAK.PACK_QTY = 300;
			CWIPCELPAK.PACK_QTY = COM_atoi(CINVCELRCV.ORI_QTY, sizeof(CINVCELRCV.ORI_QTY));
		}
		else
			CWIPCELPAK.PACK_QTY = TRS.get_int(list[i],"PACK_QTY");
        */

		memcpy(CWIPCELPAK.FLOW, MWIPMATDEF_FCELL.FIRST_FLOW, sizeof(MWIPMATDEF_FCELL.FIRST_FLOW));

		//CWIPCELPAK의 BATCH NO (MES ) 는 같이 묶인 MAGAZINE ID 로함
		memcpy(CWIPCELPAK.BATCHNO, CWIPCELPAK.PACK_ID, sizeof(CINVCELRCV.BATCHNO));
		
		//memcpy(CWIPCELPAK.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CINVCELRCV.UNIT_ID)); // Server Crash 190925
		memcpy(CWIPCELPAK.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CWIPCELPAK.UNIT_ID)); 

		memcpy(CWIPCELPAK.RCV_CELLBOX_ID, CINVCELRCV.SMALLBOXID, sizeof(CINVCELRCV.SMALLBOXID));

		memcpy(CWIPCELPAK.LARGEBOXID, CINVCELRCV.LARGEBOXID, sizeof( CINVCELRCV.LARGEBOXID));
		memcpy(CWIPCELPAK.CELLTYPE,  CINVCELRCV.CELLTYPE, sizeof(CWIPCELPAK.CELLTYPE));

		memcpy(CWIPCELPAK.CELLPRODUCTDATE, CINVCELRCV.CELLPRODUCTDATE, sizeof(CINVCELRCV.CELLPRODUCTDATE));
		memcpy(CWIPCELPAK.CELLGRADE, CINVCELRCV.CELLGRADE, sizeof(CINVCELRCV.CELLGRADE));

		memcpy(CWIPCELPAK.CELLBOXBARCODE, CINVCELRCV.CELLBOXBARCODE, sizeof(CINVCELRCV.CELLBOXBARCODE));
		CWIPCELPAK.INSPECT_STATUS =CINVCELRCV.INSPECT_STATUS;
		CWIPCELPAK.BLOCK_STATUS = CINVCELRCV.BLOCK_STATUS;
		memcpy(CWIPCELPAK.BLOCK_DATE, CINVCELRCV.BLOCK_DATE, sizeof(CINVCELRCV.BLOCK_DATE));
		memcpy(CWIPCELPAK.POWERGRADE, CINVCELRCV.POWERGRADE, sizeof(CINVCELRCV.POWERGRADE));
		memcpy(CWIPCELPAK.QUALITYGRADE, CINVCELRCV.QUALITYGRADE, sizeof(CINVCELRCV.QUALITYGRADE));
		
		CWIPCELPAK.AVG_NCELL = CINVCELRCV.AVG_NCELL;
		CWIPCELPAK.AVG_ISC = CINVCELRCV.AVG_ISC;
		CWIPCELPAK.AVG_UOC = CINVCELRCV.AVG_UOC;
		CWIPCELPAK.AVG_FF = CINVCELRCV.AVG_FF;
		CWIPCELPAK.AVG_RS = CINVCELRCV.AVG_RS;
		CWIPCELPAK.AVG_RSH = CINVCELRCV.AVG_RSH;
		CWIPCELPAK.AVG_TEMPERATURE = CINVCELRCV.AVG_TEMPERATURE;
		CWIPCELPAK.AVG_NCELL = CINVCELRCV.AVG_NCELL;
		memcpy(CWIPCELPAK.PRODUCTCLASSID, CINVCELRCV.PRODUCTCLASSID, sizeof(CINVCELRCV.PRODUCTCLASSID));
		memcpy(CWIPCELPAK.PRODUCTDEFINITIONTYPE, CINVCELRCV.PRODUCTDEFINITIONTYPE, sizeof(CINVCELRCV.PRODUCTDEFINITIONTYPE));
		memcpy(CWIPCELPAK.GR_BATCHNO,  CINVCELRCV.GR_BATCHNO, sizeof(CINVCELRCV.GR_BATCHNO));
		memcpy(CWIPCELPAK.GR_DATE, CINVCELRCV.GR_DATE, sizeof(CINVCELRCV.GR_DATE));
		memcpy(CWIPCELPAK.GI_BATCH_NO, CINVCELRCV.GR_DATE, sizeof(CINVCELRCV.GR_DATE));
		CWIPCELPAK.STATUS_FLAG = 'I';

        CDB_insert_cwipcelpak(&CWIPCELPAK);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		//자재 추적성(2024.02.23) Start
        CDB_init_cwipcelmgz(&CWIPCELMGZ);
        memcpy(CWIPCELMGZ.FACTORY, MWIPORDSTS.FACTORY, sizeof(CWIPCELMGZ.FACTORY));
        memcpy(CWIPCELMGZ.CELL_BOX_ID, CWIPCELPAK.CELL_BOX_ID, sizeof(CWIPCELMGZ.CELL_BOX_ID));
        CDB_select_cwipcelmgz(3, &CWIPCELMGZ);

        memcpy(CWIPCELMGZ.PACK_ID, CWIPCELPAK.PACK_ID, sizeof(CWIPCELMGZ.PACK_ID));
        CWIPCELMGZ.PACK_TYPE = 'F';
		CWIPCELMGZ.CMF_1[0] = 'I'; // STATUS_FLAG
		memcpy(CWIPCELMGZ.CMF_3, CWIPCELPAK.LACK_ID, sizeof(CWIPCELMGZ.CMF_3)); //LACK_ID
        memcpy(CWIPCELMGZ.CREATE_TIME, s_sys_time, sizeof(CWIPCELMGZ.CREATE_TIME));
        CDB_insert_cwipcelmgz(&CWIPCELMGZ);
        if (DB_error_code != DB_SUCCESS)
        {
            //do nothing
            LOG_head("CWIP_Packing_FullCell_CDB_insert_cwipcelmgz");
            LOG_add("FILE", MP_NSTR, __FILE__);
            LOG_add("LINE", MP_INT, __LINE__);
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
        }
		//자재 추적성(2024.02.23) End

		/****************************************************************************/
		////LOT CREATION (작업지시 기준 Small Box Lot 생성) 
		/****************************************************************************/
		tran_in_node = TRS.create_node("TRAN_LOT_IN");
		tran_out_node = TRS.create_node("TRAN_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(list[i], "CELL_BOX_ID"));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPMATDEF_FCELL.MAT_ID, sizeof(MWIPMATDEF_FCELL.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", 1);
		TRS.add_string(tran_in_node, "FLOW", MWIPMATDEF_FCELL.FIRST_FLOW, sizeof(MWIPMATDEF_FCELL.FIRST_FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM", 1); 
		TRS.add_string(tran_in_node, "OPER", HQCEL_M1_FCELL_MOVE_OPER, strlen(HQCEL_M1_FCELL_MOVE_OPER));
		TRS.add_char(tran_in_node, "LOT_TYPE", 'P');   
		TRS.add_string(tran_in_node, "CREATE_CODE", HQCEL_LOT_CREATECODE_FCELBX, strlen(HQCEL_LOT_CREATECODE_FCELBX));
		TRS.add_string(tran_in_node, "OWNER_CODE", "PROD", strlen("PROD"));
		TRS.add_char(tran_in_node, "LOT_PRIORITY", '5');
		TRS.add_double(tran_in_node, "QTY_1", COM_atol(CINVCELRCV.ORI_QTY, sizeof(CINVCELRCV.ORI_QTY)));   
		TRS.add_string(tran_in_node, "ORDER_ID", MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));

		memset(s_due_time, ' ' , sizeof(s_due_time));
		COM_calc_time(s_due_time, s_sys_time, 3, 100); //due time 임시계산

		TRS.add_string(tran_in_node, "DUE_TIME",s_due_time, sizeof(s_due_time));
		TRS.set_string(tran_in_node, "COLOR_CLASS", MWIPORDSTS.ORD_CMF_3, sizeof(MWIPORDSTS.ORD_CMF_3));
		TRS.set_string(tran_in_node, "LOC_ID", MWIPORDSTS.ORD_CMF_6, sizeof(MWIPORDSTS.ORD_CMF_6));
		TRS.set_string(tran_in_node, "LINE_ID", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		TRS.set_string(tran_in_node, "LOT_CMF_1", MWIPORDSTS.ORD_CMF_1, sizeof(MWIPORDSTS.ORD_CMF_1));
		
		//CARRIER ID
		TRS.add_nstring(tran_in_node, "CRR_ID", TRS.get_string(list[i],"PACK_ID"));

		STOPWATCH_END(" CARRIER ID", start_time);
		if(WIP_CREATE_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		/***************************************************/
		//END LOT
		/***************************************************/
		TRS.init_node(tran_in_node);
		TRS.init_node(tran_out_node);

		DBC_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), list[i], "CELL_BOX_ID");
		DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING : ERROR 가 나면안됨
		}
		
		//LOT_GROUP_ID_1 UPDATE
		memset(MWIPLOTSTS.LOT_GROUP_ID_1, ' ', sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
		memcpy(MWIPLOTSTS.LOT_GROUP_ID_1, CWIPCELPAK.LACK_ID, sizeof(MWIPLOTSTS.LOT_GROUP_ID_1));
		DBC_update_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING : ERROR 가 나면안됨
		}

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", '1');
		TRS.add_string(tran_in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_string(tran_in_node, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		TRS.add_int(tran_in_node, "MAT_VER", MWIPLOTSTS.MAT_VER);
		TRS.add_string(tran_in_node, "FLOW",MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
		TRS.add_int(tran_in_node, "FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM); 
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));

		//User Routine End 에서 ERP I/F 호출안하도록 'Y' 로 셋팅
		TRS.set_char(tran_in_node, "_SKIP_ERP_IF", 'Y'); 

		STOPWATCH_END(" END LOT", start_time);
		if(WIP_END_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}

		//Cleaving Full Cell Move ERP Interface 수행
		STOPWATCH_END("Cleaving Full Cell Move ERP", start_time);
		TRS.set_char(tran_in_node, "INF_UPLOAD_TYPE_FLAG", '1'); 
		if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,tran_in_node, tran_out_node ) == MP_FALSE)
		{
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}
		
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

		STOPWATCH_END("__FOR", start_time);
		
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}