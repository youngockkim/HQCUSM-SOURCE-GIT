/*******************************************************************************

    System      : MESplus
    Module      : View FQC List
    File Name   : CWIP_view_fqc_list.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.22  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_FQC_LIST(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Fqc_List()
        - View FQC List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Fqc_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_FQC_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Fqc_List", out_node);

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
    CWIP_VIEW_FQC_LIST()
        - VIEW FQC LIST
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_FQC_LIST(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;

	char s_sys_time[14];
	TRSNode *list_item;
	
    int i_step;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_FQC_LIST");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
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

	// OPEN
    i_step = 2;
	CDB_init_cedclotrlh(&CEDCLOTRLH);	
    TRS.copy(CEDCLOTRLH.FACTORY, sizeof(CEDCLOTRLH.FACTORY), in_node, IN_FACTORY);
    memcpy(CEDCLOTRLH.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
	memcpy(CEDCLOTRLH.LOT_ID, TRS.get_string(in_node,"LOT_ID"), strlen(TRS.get_string(in_node,"LOT_ID")));
	CDB_open_cedclotrlh(i_step, &CEDCLOTRLH);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
			return MP_TRUE;
		}
		else
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CEDCLOTRLH OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	// FETCH
	while(1)
	{
		CDB_fetch_cedclotrlh(i_step, &CEDCLOTRLH);
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_close_cedclotrlh(i_step);
			break;
		}
		else if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "CEDCLOTRLH OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_cedclotrlh(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}

		list_item = TRS.add_node(out_node, "VIEW_FQCHIS_OUT");
		TRS.add_int(list_item, "INS_CNT", CEDCLOTRLH.INS_CNT);
        TRS.add_string(list_item, "RES_ID", CEDCLOTRLH.RES_ID, sizeof(CEDCLOTRLH.RES_ID)); 
        TRS.add_string(list_item, "INS_TIME", CEDCLOTRLH.INS_TIME, sizeof(CEDCLOTRLH.INS_TIME));
		TRS.add_string(list_item, "INS_VALUE", CEDCLOTRLH.INS_VALUE, sizeof(CEDCLOTRLH.INS_VALUE));
		TRS.add_string(list_item, "RESULT_TIME", CEDCLOTRLH.RESULT_TIME, sizeof(CEDCLOTRLH.RESULT_TIME));
		TRS.add_string(list_item, "RESULT_VALUE", CEDCLOTRLH.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE));
		TRS.add_string(list_item, "DEFECT_CODE", CEDCLOTRLH.CMF_2, sizeof(CEDCLOTRLH.CMF_2));
        TRS.add_string(list_item, "GRADE", CEDCLOTRLH.GRADE, sizeof(CEDCLOTRLH.GRADE));
        TRS.add_string(list_item, "POWER", CEDCLOTRLH.POWER, sizeof(CEDCLOTRLH.POWER));
        TRS.add_string(list_item, "ARTICLE_NO", CEDCLOTRLH.ARTICLE_NO, sizeof(CEDCLOTRLH.ARTICLE_NO));
        TRS.add_string(list_item, "COLOR_CLASS", CEDCLOTRLH.COLOR_CLASS, sizeof(CEDCLOTRLH.COLOR_CLASS));
		TRS.add_string(list_item, "MAT_ID", CEDCLOTRLH.MAT_ID, sizeof(CEDCLOTRLH.MAT_ID));		//[ERP Project]Mat_id Ãß°¡
        //TRS.add_string(list_item, "OSC", CEDCLOTRLH.OSC, sizeof(CEDCLOTRLH.OSC));
		//TRS.add_string(list_item, "ESC", CEDCLOTRLH.ESC, sizeof(CEDCLOTRLH.ESC));
		//TRS.add_string(list_item, "EL", CEDCLOTRLH.EL, sizeof(CEDCLOTRLH.EL));
        //TRS.add_string(list_item, "INC_COMMENT", CEDCLOTRLH.INC_COMMENT, sizeof(CEDCLOTRLH.INC_COMMENT));
		//TRS.add_string(list_item, "RLT_COMMENT", CEDCLOTRLH.RLT_COMMENT, sizeof(CEDCLOTRLH.RLT_COMMENT));

		CDB_init_cedclotfqc(&CEDCLOTFQC);	
		memcpy(CEDCLOTFQC.LOT_ID, CEDCLOTRLH.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID));
		memcpy(CEDCLOTFQC.RES_ID, CEDCLOTRLH.RES_ID, sizeof(CEDCLOTRLH.RES_ID));
		CEDCLOTFQC.INS_SEQ  = CEDCLOTRLH.INS_CNT;
		CEDCLOTFQC.DEFECT_SEQ = 0;

		CDB_select_cedclotfqc(6, &CEDCLOTFQC);	//[25.03.20]FQC 조회시 CELL_LOCAITON 출력 오류 수정manager
		if(DB_error_code == DB_SUCCESS)
        {
			TRS.add_string(list_item, "CELL_INFO" , CEDCLOTFQC.CELL_INFO , sizeof(CEDCLOTFQC.CELL_INFO));		 
			TRS.add_string(list_item, "REJUDGMENT_CD", CEDCLOTFQC.CMF_5, sizeof(CEDCLOTFQC.CMF_5));

			CDB_init_mgcmtbldat(&MGCMTBLDAT);
			memcpy(MGCMTBLDAT.FACTORY, CEDCLOTRLH.FACTORY, sizeof(MGCMTBLDAT.FACTORY));
			memcpy(MGCMTBLDAT.TABLE_NAME, "@REJUDGMENT", sizeof(MGCMTBLDAT.TABLE_NAME));
			memcpy(MGCMTBLDAT.KEY_1, CEDCLOTFQC.CMF_5, sizeof(MGCMTBLDAT.KEY_1));
			DBC_select_mgcmtbldat(2, &MGCMTBLDAT);
			if(DB_error_code == DB_SUCCESS)
			{
				TRS.add_string(list_item, "REJUDGMENT", MGCMTBLDAT.DATA_1, sizeof(MGCMTBLDAT.DATA_1));
			}
		}	 
	}
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}