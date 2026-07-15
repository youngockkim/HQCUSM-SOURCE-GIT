/******************************************************************************'

	System      : MESplus
	Module      : CWIP
	File Name   : CWIP_view_lot_list.c
	Description : View Lot List

    MES Version : 5.3.6.4

	Function List  
		- CWIP_View_Lot_List()
			+ View Lot List
		- CWIP_VIEW_LOT_LIST()
			+ Main sub function of CWIP_View_Lot_List function
			+ View Lot List definition
		- CWIP_View_Lot_List_Validation()
			+ Main sub function of CWIP_VIEW_LOT_LIST function
			+ Check the condition for View Lot List
	Detail Description
		- CWIP_VIEW_LOT_LIST()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CWIP_View_Lot_List_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CWIP_View_Lot_List()
		- View Lot
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Lot_List(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CWIP_VIEW_LOT_LIST(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code, "CWIP_VIEW_LOT_LIST", out_node);

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
	CWIP_VIEW_LOT_LIST()
		- Main sub function of "CWIP_View_Lot_List" function
		- View Lot List
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_VIEW_LOT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MWIPLOTHIS_TAG MWIPLOTHIS;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    struct MGCMTBLDAT_TAG MGCMTBLDAT_C;
    //IS-21-04-017 Terminate Module
	struct MGCMTBLDAT_TAG MGCMTBLDAT_PROCESS;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_EQ;
	// IS-21-05-028 Terminate Module Shift Ãß°¡°Ç °³¹ß
	struct CWIPLOTEXT_TAG CWIPLOTEXT;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;

    TRSNode *list_item;

    int i_step;

    LOG_head("CWIP_VIEW_LOT_LIST");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* 
        Step 1: Lot List by Create Time, Line ID, Material ID 
        Step 2: Lot List by Lot ID
        Step 3: Terminated Lot List by Create Time, Line ID, Material ID 
        Step 4: Terminated Lot List by Lot ID
    */

    if(CWIP_View_Lot_List_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	DB_init_condition(&DBC_Q_COND);
    TRS.copy(DBC_Q_COND.FROM_TIME, sizeof(DBC_Q_COND.FROM_TIME), in_node, "FROM_TIME");
    TRS.copy(DBC_Q_COND.TO_TIME, sizeof(DBC_Q_COND.TO_TIME), in_node, "TO_TIME");
    DB_add_null_condition(&DBC_Q_COND, &DBC_Q_COND_N);

    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1), in_node, "LINE_ID");
    TRS.copy(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID), in_node, "MAT_ID");
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");


    if (TRS.get_procstep(in_node) == '1')
    {
        i_step = 103;
		memcpy(MWIPLOTSTS.OPER, "M4000", strlen("M4000"));
		memcpy(MWIPLOTSTS.CREATE_CODE, "MODULE", strlen("MODULE"));
    }
    else if (TRS.get_procstep(in_node) == '2')
    {
        i_step = 104;
    }
    else if (TRS.get_procstep(in_node) == '3')
    {
        i_step = 105;
		memcpy(MWIPLOTSTS.OPER, "M4000", strlen("M4000"));
		memcpy(MWIPLOTSTS.CREATE_CODE, "MODULE", strlen("MODULE"));
		MWIPLOTSTS.LOT_DEL_FLAG = 'Y';
    }
    else if (TRS.get_procstep(in_node) == '4')
    {
        i_step = 106;
    }
	else if (TRS.get_procstep(in_node) == '5') // [ERP 23.05.24] M4000 보다 큰 공정에서 M4000이 아닌 공정으로 
    {
        i_step = 110;
    }
    else if (TRS.get_procstep(in_node) == '6') // [ERP 23.05.24] M4000 보다 큰 공정에서 M4000이 아닌 공정으로 
    {
        i_step = 111;
    }
    else /* default */
    {
        i_step = 103;
    }

    
    DBC_open_mwiplotsts(i_step, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS OPEN", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_1), MWIPLOTSTS.LOT_CMF_1);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);
        TRS.add_dberrmsg(out_node,DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    while(1)
    {
        DBC_fetch_mwiplotsts(i_step, &MWIPLOTSTS);
        if(DB_error_code == DB_NOT_FOUND)
        {
            DBC_close_mwiplotsts(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS FETCH", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPLOTSTS.FACTORY), MWIPLOTSTS.FACTORY);
            TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_1), MWIPLOTSTS.LOT_CMF_1);
            TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPLOTSTS.MAT_ID), MWIPLOTSTS.MAT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            DBC_close_mwiplotsts(i_step);

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        /* Get Terminate Code Description */
        if (TRS.get_procstep(in_node) == '3' || TRS.get_procstep(in_node) == '4' || TRS.get_procstep(in_node) == '6') // [ERP 23.05.24] Step 추가
        {
            DBC_init_mgcmtbldat(&MGCMTBLDAT);
            TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	        memcpy(MGCMTBLDAT.TABLE_NAME, MP_WIP_TERMINATE_CODE, strlen(MP_WIP_TERMINATE_CODE));
            memcpy(MGCMTBLDAT.KEY_1, MWIPLOTSTS.LOT_DEL_CODE, sizeof(MWIPLOTSTS.LOT_DEL_CODE));

	        DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
                    /*
			        strcpy(s_msg_code, "GCM-0008");
			        TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                    TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);

			        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                    */
		        }
                else
                {
                    /*
                    strcpy(s_msg_code, "GCM-0007");
                    TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
                    TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
                    TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                    */
                }
            }

            DBC_init_mwiplothis(&MWIPLOTHIS);
            memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
            MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ;
            
            DBC_select_mwiplothis(1, &MWIPLOTHIS);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {

		        }
                else
                {

                }
            }

            DBC_init_mgcmtbldat(&MGCMTBLDAT_C);
            TRS.copy(MGCMTBLDAT_C.FACTORY, sizeof(MGCMTBLDAT_C.FACTORY), in_node, IN_FACTORY);
	        memcpy(MGCMTBLDAT_C.TABLE_NAME, HQCEL_M1_GCM_TERMINATE_CAUSE, strlen(HQCEL_M1_GCM_TERMINATE_CAUSE));
            memcpy(MGCMTBLDAT_C.KEY_1, MWIPLOTHIS.TRAN_CMF_1, sizeof(MWIPLOTHIS.TRAN_CMF_1));

	        DBC_select_mgcmtbldat(1, &MGCMTBLDAT_C);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
                    /*
			        strcpy(s_msg_code, "GCM-0008");
			        TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT_C.FACTORY), MGCMTBLDAT_C.FACTORY);
                    TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT_C.TABLE_NAME), MGCMTBLDAT_C.TABLE_NAME);
                    TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT_C.KEY_1), MGCMTBLDAT_C.KEY_1);

			        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                    */
		        }
                else
                {
                    /*
                    strcpy(s_msg_code, "GCM-0007");
                    TRS.add_fieldmsg(out_node, "MGCMTBLDAT SELECT", MP_NVST);
                    TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT_C.FACTORY), MGCMTBLDAT_C.FACTORY);
                    TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT_C.TABLE_NAME), MGCMTBLDAT_C.TABLE_NAME);
                    TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT_C.KEY_1), MGCMTBLDAT_C.KEY_1);
                    TRS.add_dberrmsg(out_node,DB_error_msg);

                    gs_log_type.type = MP_LOG_ERROR;
                    gs_log_type.e_type = MP_LOG_E_SYSTEM;
                    gs_log_type.category = MP_LOG_CATE_VIEW;
                    COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                    return MP_FALSE;
                    */
                }
            }

			
			// IS-21-05-028 Terminate Module Shift Ãß°¡°Ç °³¹ß
			CDB_init_cwiplotext(&CWIPLOTEXT);
			memcpy(CWIPLOTEXT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

			CDB_select_cwiplotext(2, &CWIPLOTEXT);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
		        }
                else
                {
                }
            }

			// IS-21-04-017 Terminate Module
			// TERMINATE_PROCESS
			DBC_init_mgcmtbldat(&MGCMTBLDAT_PROCESS);
            TRS.copy(MGCMTBLDAT_PROCESS.FACTORY, sizeof(MGCMTBLDAT_PROCESS.FACTORY), in_node, IN_FACTORY);
	        memcpy(MGCMTBLDAT_PROCESS.TABLE_NAME, "TERMINATE_PROCESS", strlen("TERMINATE_PROCESS"));
            //memcpy(MGCMTBLDAT_PROCESS.KEY_1, MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17));
			memcpy(MGCMTBLDAT_PROCESS.KEY_1, CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2)); // IS-21-05-028 Terminate Module Shift Ãß°¡°Ç °³¹ß

	        DBC_select_mgcmtbldat(1, &MGCMTBLDAT_PROCESS);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
		        }
                else
                {
                }
            }

			// IS-21-04-017 Terminate Module
			// TERMINATE_EQ
			DBC_init_mgcmtbldat(&MGCMTBLDAT_EQ);
            TRS.copy(MGCMTBLDAT_EQ.FACTORY, sizeof(MGCMTBLDAT_EQ.FACTORY), in_node, IN_FACTORY);
	        memcpy(MGCMTBLDAT_EQ.TABLE_NAME, "TERMINATE_EQ", strlen("TERMINATE_EQ"));
            //memcpy(MGCMTBLDAT_EQ.KEY_1, MWIPLOTSTS.LOT_CMF_18, sizeof(MWIPLOTSTS.LOT_CMF_18));
			memcpy(MGCMTBLDAT_EQ.KEY_1, CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3)); // IS-21-05-028 Terminate Module Shift Ãß°¡°Ç °³¹ß

	        DBC_select_mgcmtbldat(2, &MGCMTBLDAT_EQ);
            if(DB_error_code != DB_SUCCESS)
            {
                if(DB_error_code == DB_NOT_FOUND)
		        {
		        }
                else
                {
                }
            }

        }


        /* Construct out node */
        list_item = TRS.add_node(out_node, "LIST");
        TRS.add_string(list_item, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
        TRS.add_string(list_item, "LOT_DESC", MWIPLOTSTS.LOT_DESC, sizeof(MWIPLOTSTS.LOT_DESC));
        TRS.add_string(list_item, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
        TRS.add_int(list_item, "MAT_VER", MWIPLOTSTS.MAT_VER);
        TRS.add_string(list_item, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
        TRS.add_int(list_item, "FLOW_SEQ_NUM", MWIPLOTSTS.FLOW_SEQ_NUM);
        TRS.add_string(list_item, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
        TRS.add_double(list_item, "QTY_1", MWIPLOTSTS.QTY_1);
        TRS.add_double(list_item, "QTY_2", MWIPLOTSTS.QTY_2);
        TRS.add_double(list_item, "QTY_3", MWIPLOTSTS.QTY_3);
        TRS.add_char(list_item, "LOT_TYPE", MWIPLOTSTS.LOT_TYPE);
        TRS.add_string(list_item, "CREATE_TIME", MWIPLOTSTS.CREATE_TIME, sizeof(MWIPLOTSTS.CREATE_TIME));
        TRS.add_string(list_item, "OWNER_CODE", MWIPLOTSTS.OWNER_CODE, sizeof(MWIPLOTSTS.OWNER_CODE));
        TRS.add_string(list_item, "CREATE_CODE", MWIPLOTSTS.CREATE_CODE, sizeof(MWIPLOTSTS.CREATE_CODE));
        TRS.add_char(list_item, "LOT_PRIORITY", MWIPLOTSTS.LOT_PRIORITY);
        TRS.add_string(list_item, "LOT_STATUS", MWIPLOTSTS.LOT_STATUS, sizeof(MWIPLOTSTS.LOT_STATUS));
        TRS.add_char(list_item, "HOLD_FLAG", MWIPLOTSTS.HOLD_FLAG);
        TRS.add_string(list_item, "HOLD_CODE", MWIPLOTSTS.HOLD_CODE, sizeof(MWIPLOTSTS.HOLD_CODE));
        TRS.add_string(list_item, "HOLD_PRV_GRP_ID", MWIPLOTSTS.HOLD_PRV_GRP_ID, sizeof(MWIPLOTSTS.HOLD_PRV_GRP_ID));
        TRS.add_string(list_item, "ORDER_ID", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
        TRS.add_string(list_item, "LOT_CMF_1", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1));
        TRS.add_string(list_item, "LOT_CMF_2", MWIPLOTSTS.LOT_CMF_2, sizeof(MWIPLOTSTS.LOT_CMF_2));
        TRS.add_string(list_item, "LOT_CMF_3", MWIPLOTSTS.LOT_CMF_3, sizeof(MWIPLOTSTS.LOT_CMF_3));
        TRS.add_string(list_item, "LOT_CMF_4", MWIPLOTSTS.LOT_CMF_4, sizeof(MWIPLOTSTS.LOT_CMF_4));
        TRS.add_string(list_item, "LOT_CMF_5", MWIPLOTSTS.LOT_CMF_5, sizeof(MWIPLOTSTS.LOT_CMF_5));
        TRS.add_string(list_item, "LOT_CMF_6", MWIPLOTSTS.LOT_CMF_6, sizeof(MWIPLOTSTS.LOT_CMF_6));
        TRS.add_string(list_item, "LOT_CMF_7", MWIPLOTSTS.LOT_CMF_7, sizeof(MWIPLOTSTS.LOT_CMF_7));
        TRS.add_string(list_item, "LOT_CMF_8", MWIPLOTSTS.LOT_CMF_8, sizeof(MWIPLOTSTS.LOT_CMF_8));
        TRS.add_string(list_item, "LOT_CMF_9", MWIPLOTSTS.LOT_CMF_9, sizeof(MWIPLOTSTS.LOT_CMF_9));
        TRS.add_string(list_item, "LOT_CMF_10", MWIPLOTSTS.LOT_CMF_10, sizeof(MWIPLOTSTS.LOT_CMF_10));
        TRS.add_string(list_item, "LOT_CMF_11", MWIPLOTSTS.LOT_CMF_11, sizeof(MWIPLOTSTS.LOT_CMF_11));
        TRS.add_string(list_item, "LOT_CMF_12", MWIPLOTSTS.LOT_CMF_12, sizeof(MWIPLOTSTS.LOT_CMF_12));
        TRS.add_string(list_item, "LOT_CMF_13", MWIPLOTSTS.LOT_CMF_13, sizeof(MWIPLOTSTS.LOT_CMF_13));
        TRS.add_string(list_item, "LOT_CMF_14", MWIPLOTSTS.LOT_CMF_14, sizeof(MWIPLOTSTS.LOT_CMF_14));
        TRS.add_string(list_item, "LOT_CMF_15", MWIPLOTSTS.LOT_CMF_15, sizeof(MWIPLOTSTS.LOT_CMF_15));
        TRS.add_string(list_item, "LOT_CMF_16", MWIPLOTSTS.LOT_CMF_16, sizeof(MWIPLOTSTS.LOT_CMF_16));
        TRS.add_string(list_item, "LOT_CMF_17", MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17));
        TRS.add_string(list_item, "LOT_CMF_18", MWIPLOTSTS.LOT_CMF_18, sizeof(MWIPLOTSTS.LOT_CMF_18));
        TRS.add_string(list_item, "LOT_CMF_19", MWIPLOTSTS.LOT_CMF_19, sizeof(MWIPLOTSTS.LOT_CMF_19));
        TRS.add_string(list_item, "LOT_CMF_20", MWIPLOTSTS.LOT_CMF_20, sizeof(MWIPLOTSTS.LOT_CMF_20));
        TRS.add_char(list_item, "LOT_DEL_FLAG", MWIPLOTSTS.LOT_DEL_FLAG);
        TRS.add_string(list_item, "LOT_DEL_CODE", MWIPLOTSTS.LOT_DEL_CODE, sizeof(MWIPLOTSTS.LOT_DEL_CODE));
        TRS.add_string(list_item, "LOT_DEL_TIME", MWIPLOTSTS.LOT_DEL_TIME, sizeof(MWIPLOTSTS.LOT_DEL_TIME));
        TRS.add_string(list_item, "LAST_TRAN_CODE", MWIPLOTSTS.LAST_TRAN_CODE, sizeof(MWIPLOTSTS.LAST_TRAN_CODE));
        TRS.add_string(list_item, "LAST_TRAN_TIME", MWIPLOTSTS.LAST_TRAN_TIME, sizeof(MWIPLOTSTS.LAST_TRAN_TIME));
        TRS.add_string(list_item, "LAST_COMMENT", MWIPLOTSTS.LAST_COMMENT, sizeof(MWIPLOTSTS.LAST_COMMENT));
        TRS.add_int(list_item, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);
        TRS.add_int(list_item, "LAST_HIST_SEQ", MWIPLOTSTS.LAST_HIST_SEQ);
        
		CDB_init_cedclotfqc(&CEDCLOTFQC);
		memcpy(CEDCLOTFQC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

		CDB_select_cedclotfqc(4, &CEDCLOTFQC);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {
				TRS.add_string(list_item, "FQC_FLAG", "N", strlen("N"));
		    }
            else
            {
				TRS.add_dberrmsg(out_node,DB_error_msg);
            }
        }
		else
		{
			TRS.add_string(list_item, "FQC_FLAG", "Y", strlen("Y"));
			TRS.add_string(list_item, "INS_TIME", CEDCLOTFQC.INS_TIME, sizeof(CEDCLOTFQC.INS_TIME));
			TRS.add_string(list_item, "LIMIT_DATE", CEDCLOTFQC.CMF_8, sizeof(CEDCLOTFQC.INS_TIME));
			TRS.add_string(list_item, "TODATE", CEDCLOTFQC.CMF_9, sizeof(CEDCLOTFQC.INS_TIME));
			TRS.add_string(list_item, "SAME_FLAG", CEDCLOTFQC.CMF_10, strlen("Y"));
		}
        if (TRS.get_procstep(in_node) == '3' || TRS.get_procstep(in_node) == '4' || TRS.get_procstep(in_node) == '6') // [ERP 23.05.24] Step 추가
        {
            TRS.add_string(list_item, "LOT_DEL_DESC", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
            TRS.add_string(list_item, "LOT_DEL_CAUSE", MGCMTBLDAT_C.DATA_1, sizeof(MGCMTBLDAT_C.DATA_1));
			TRS.add_string(list_item, "TRAN_CMF_20", MWIPLOTHIS.TRAN_CMF_20, sizeof(MWIPLOTHIS.TRAN_CMF_20));

			/*
			// IS-21-04-017 Terminate Module
			TRS.add_string(list_item, "TERMINATE_PROCESS", MGCMTBLDAT_PROCESS.DATA_1, sizeof(MGCMTBLDAT_PROCESS.DATA_1));
			TRS.add_string(list_item, "TERMINATE_PROCESS_CODE", MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17));
			TRS.add_string(list_item, "TERMINATE_EQ", MGCMTBLDAT_EQ.DATA_1, sizeof(MGCMTBLDAT_EQ.DATA_1));
			TRS.add_string(list_item, "TERMINATE_EQ_CODE", MWIPLOTSTS.LOT_CMF_18, sizeof(MWIPLOTSTS.LOT_CMF_18));
			*/
			
			// IS-21-05-028 Terminate Module Shift 추가건 개발
			TRS.add_string(list_item, "TERMINATE_SHIFT", CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1));
			TRS.add_string(list_item, "TERMINATE_PROCESS", MGCMTBLDAT_PROCESS.DATA_1, sizeof(MGCMTBLDAT_PROCESS.DATA_1));
			TRS.add_string(list_item, "TERMINATE_PROCESS_CODE", CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2));
			TRS.add_string(list_item, "TERMINATE_EQ", MGCMTBLDAT_EQ.DATA_1, sizeof(MGCMTBLDAT_EQ.DATA_1));
			TRS.add_string(list_item, "TERMINATE_EQ_CODE", CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3));
			TRS.add_string(list_item, "TERMINATE_TIME", CWIPLOTEXT.CREATE_TIME, sizeof(CWIPLOTEXT.CREATE_TIME));
			
        }
		TRS.add_string(list_item, "TRAN_CMF_16", MWIPLOTHIS.TRAN_CMF_16, sizeof(MWIPLOTHIS.TRAN_CMF_16)); // //IS-21-04-017 Terminate Module
    }

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE; 
} 

/*******************************************************************************
	CWIP_View_Lot_List_Validation()
		- Main sub function of "CWIP_VIEW_LOT_LIST" function
		- Check the condition for View Lot List
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Lot_List_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
	 /* - [GERP PROJECT] 시작****************************************************************/
    // [ERP 23.05.23] 패킹 된이력이 있을경우 MES 폐기 불가
    struct CWIPLOTPAK_TAG CWIPLOTPAK;
    struct CWIPRWKDAT_TAG CWIPRWKDAT;
    /* - [GERP PROJECT] 끝*****************************************************************/

	// [ERP 23.05.24] Step 추가
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

	/* - [GERP PROJECT] [ERP 23.05.23] 시작****************************************************************/
    // 23.05.03 패킹이력이 있을경우 폐기 Validation
    CDB_init_cwiplotpak(&CWIPLOTPAK);
    TRS.copy(CWIPLOTPAK.FACTORY, sizeof(CWIPLOTPAK.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID), in_node, "LOT_ID");

	//[2023.10.24] LOT_ID null check 추가 
    if (ISSPACE(CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID)) == DB_FALSE && CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
    {
        // 23.05.03 패킹이력이 있지만 재작업 오더가 있을떈 폐기 가능
        CDB_init_cwiprwkdat(&CWIPRWKDAT);
        memcpy(CWIPRWKDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
        memcpy(CWIPRWKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
        if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) == 0) // 재작업으로 패킹된이력이 있으면  Error
        {
            strcpy(s_msg_code, "WIP-0616"); // This module requires a rework order
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPRWKDAT.MODULE_ID), CWIPRWKDAT.MODULE_ID);// 2023-03-09 JSLEE ADD
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    /* - [GERP PROJECT] 끝*****************************************************************/

    return MP_TRUE;
}