/******************************************************************************'

    System      : MESplus
    Module      : CWIP
    File Name   : CWIP_Split_Copy_Lot.c
    Description : Change Label Service

    MES Version : 5.3.4 ~

    Function List
        - CWIP_Split_Copy_Lot()
            + Setup service interface function
        - CWIP_SPLIT_OR_COPY_LOT()
            + Main sub function of CWIP_Split_Copy_Lot function
            + Setup service main business function
        - CWIP_Split_Copy_Lot_Validation()
            + Main sub function of CWIP_SPLIT_OR_COPY_LOT function
            + Check the condition for create/update/delete
    Detail Description
        - CWIP_SPLIT_OR_COPY_LOT()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019-03-15  Juhyeon.Jung           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_common.h"

int CWIP_Split_Copy_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_SPLIT_OR_COPY_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
    CWIP_Split_Copy_Lot()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Split_Copy_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_SPLIT_OR_COPY_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_SPLIT_OR_COPY_LOT", out_node);

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
    CWIP_SPLIT_OR_COPY_LOT()
        - Main sub function of "CWIP_Split_Copy_Lot" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_SPLIT_OR_COPY_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_TO;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTRLH_TAG CEDCLOTRLH;
	struct CWIPLOTTRC_TAG CWIPLOTTRC;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
		

	char s_sys_time[14];

    LOG_head("CWIP_SPLIT_OR_COPY_LOT");
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

    if(CWIP_Split_Copy_Lot_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if (TRS.get_char(in_node, "COPY_DATA_FLAG") != 'Y')
	{
		//SPLIT
		
		if(WIP_SPLIT_LOT(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}

		COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
		return MP_TRUE;
	}
	
	

	//SOURCE LOT SELECT
	CDB_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0044");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	if (strlen(TRS.get_string(in_node, "CHILD_LOT_ID")) != 18)
	{
		strcpy(s_msg_code, "WIP-0045");
        TRS.add_fieldmsg(out_node, "LOT SIZE CHECK", MP_NVST);
        TRS.add_fieldmsg(out_node, "TO_LOT_ID", MP_STR, sizeof(MWIPLOTSTS_TO.LOT_ID), MWIPLOTSTS_TO.LOT_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//TARGET LOT SELECT
	CDB_init_mwiplotsts(&MWIPLOTSTS_TO);
	TRS.copy(MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID), in_node, "CHILD_LOT_ID");
	CDB_select_mwiplotsts(1, &MWIPLOTSTS_TO);
	if(DB_error_code == DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0045");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "TO_LOT_ID", MP_STR, sizeof(MWIPLOTSTS_TO.LOT_ID), MWIPLOTSTS_TO.LOT_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	

	//DATA COPY
	//0. LOT STATUS / HISTORY / CWIPLOTTRC / MWIPELTSTS / CEDCLOTRLT / CEDCLOTRLH 

	//0. MWIPLOTSTS COPY
	memcpy(MWIPLOTSTS_TO.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(struct MWIPLOTSTS_TAG));
	memset(MWIPLOTSTS_TO.LOT_ID, ' ', sizeof(MWIPLOTSTS.LOT_ID));
	TRS.copy(MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID), in_node, "CHILD_LOT_ID");

	memcpy(MWIPLOTSTS_TO.FROM_TO_LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	memset(MWIPLOTSTS_TO.LAST_COMMENT , ' ', sizeof(MWIPLOTSTS_TO.LAST_COMMENT));
	memcpy(MWIPLOTSTS_TO.LAST_COMMENT, "DATA COPY LOT", strlen("DATA COPY LOT"));
	
	CDB_insert_mwiplotsts(&MWIPLOTSTS_TO);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0045");
        TRS.add_fieldmsg(out_node, "MWIPLOTSTS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "TO_LOT_ID", MP_STR, sizeof(MWIPLOTSTS_TO.LOT_ID), MWIPLOTSTS_TO.LOT_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//1. MWIPLOTHIS COPY
	CDB_init_mwiplothis(&MWIPLOTHIS);
	memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	memcpy(MWIPLOTHIS.FROM_TO_LOT_ID, MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID));
	CDB_update_mwiplothis(901, &MWIPLOTHIS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0045");
        TRS.add_fieldmsg(out_node, "MWIPLOTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "TO_LOT_ID", MP_STR, sizeof(MWIPLOTSTS_TO.LOT_ID), MWIPLOTSTS_TO.LOT_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	//2. CWIPLOTTRC COPY
	CDB_init_cwiplottrc(&CWIPLOTTRC);
	memcpy(CWIPLOTTRC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_cwiplottrc(1, &CWIPLOTTRC);
	if(DB_error_code == DB_SUCCESS)
	{
		memcpy(CWIPLOTTRC.LOT_ID, MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID));
		memcpy(CWIPLOTTRC.WORK_DATE, MWIPLOTSTS.CREATE_TIME, 8);
		CDB_insert_cwiplottrc(&CWIPLOTTRC);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		if (COM_isnullspace(CWIPLOTTRC.FQC1_TIME) == MP_FALSE)
		{
			CDB_init_cwiplottrc(&CWIPLOTTRC); 
			memcpy(CWIPLOTTRC.LOT_ID, MWIPLOTSTS_TO.LOT_ID, sizeof(CWIPLOTTRC.LOT_ID));
			CDB_select_cwiplottrc(1, &CWIPLOTTRC);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPLOTTRC SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTTRC.LOT_ID), CWIPLOTTRC.LOT_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 
			memcpy(CWIPLOTTRC.FQC1_TIME, s_sys_time, sizeof(s_sys_time));
			CDB_update_cwiplottrc(1, &CWIPLOTTRC);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "CWIPLOTTRC UPDATE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTTRC.LOT_ID), CWIPLOTTRC.LOT_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 

		}

	}

	//3. MWIPELTSTS
	CDB_init_mwipeltsts(&MWIPELTSTS);
	memcpy(MWIPELTSTS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CDB_select_mwipeltsts(1, &MWIPELTSTS);
	if(DB_error_code == DB_SUCCESS)
	{
		memcpy(MWIPELTSTS.LOT_ID, MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID));
		memcpy(MWIPELTSTS.CURING_TIME,s_sys_time, sizeof(MWIPELTSTS.CURING_TIME)) ;//파티션키로 사용하고 있으므로 업데이트 금지
		CDB_insert_mwipeltsts(&MWIPELTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		if (COM_isnullspace(MWIPELTSTS.FQC_TIME) == MP_FALSE)
		{
			CDB_init_mwipeltsts(&MWIPELTSTS); 
			memcpy(MWIPELTSTS.LOT_ID,  MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
			CDB_select_mwipeltsts(1, &MWIPELTSTS);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 

			memcpy(MWIPELTSTS.FQC_TIME, s_sys_time, sizeof(s_sys_time));
			CDB_update_mwipeltsts(1, &MWIPELTSTS);
			if(DB_error_code != DB_SUCCESS)
			{ 
				strcpy(s_msg_code, "WIP-0004"); 
				TRS.add_fieldmsg(out_node, "MWIPELTSTS UPDATE", MP_NVST); 
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			} 


		}
	}

	//4. CEDCLOTRLT
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	memcpy(CEDCLOTRLT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
	memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	memcpy(CEDCLOTRLT.CMF_1, MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID));
	memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(s_sys_time));
	memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(s_sys_time));
	
	CDB_update_cedclotrlt(901, &CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	
	//5. CEDCLOTRLH
	CDB_init_cedclotrlh(&CEDCLOTRLH);
	memcpy(CEDCLOTRLH.FACTORY, MWIPLOTSTS.FACTORY, sizeof(CEDCLOTRLH.FACTORY));
	memcpy(CEDCLOTRLH.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	memcpy(CEDCLOTRLH.CMF_1, MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID));
	memcpy(CEDCLOTRLH.INS_TIME, s_sys_time, sizeof(s_sys_time));  //FC(FQC 이면) SYSTEM TIME 으로
	memcpy(CEDCLOTRLH.RESULT_TIME, s_sys_time, sizeof(s_sys_time)); //FC(FQC 이면) SYSTEM TIME 으로

	CDB_update_cedclotrlh(901, &CEDCLOTRLH);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	

	//6. CEDCLOTFQC
	CDB_init_cedclotfqc(&CEDCLOTFQC);
	memcpy(CEDCLOTFQC.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
	memcpy(CEDCLOTFQC.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	memcpy(CEDCLOTFQC.CMF_1, MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID));
	memcpy(CEDCLOTFQC.INS_TIME, s_sys_time, sizeof(s_sys_time)); //현재 시간으로 FQC 시간 모두 INSERT
	CDB_update_cedclotfqc(901, &CEDCLOTFQC);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}
	

	//7. ERP FQC DATA UPLOAD
	TRS.set_string(in_node, "LOT_ID", MWIPLOTSTS_TO.LOT_ID, sizeof(MWIPLOTSTS_TO.LOT_ID));
	TRS.set_string(in_node, "BACK_TIME", s_sys_time, sizeof(s_sys_time));
	TRS.set_char(in_node, "INF_UPLOAD_TYPE_FLAG", '5'); 
	if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,in_node, out_node ) == MP_FALSE)
	{
		//ERROR 
		strcpy(s_msg_code, "WIP-0045");
        TRS.add_fieldmsg(out_node, "IERPOPRCFM INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "TO_LOT_ID", MP_STR, sizeof(MWIPLOTSTS_TO.LOT_ID), MWIPLOTSTS_TO.LOT_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CWIP_Split_Copy_Lot_Validation()
        - Main sub function of "CWIP_SPLIT_OR_COPY_LOT" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Split_Copy_Lot_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    //struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
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


    return MP_TRUE;
}

