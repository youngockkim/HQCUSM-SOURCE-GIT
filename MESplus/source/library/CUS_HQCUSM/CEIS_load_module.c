/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_load_module.c
    Description : EAPMES Load Module Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Load_Module()
            + Setup service interface function
        - EAPMES_LOAD_MODULE()
            + Main sub function of EAPMES_Load_Module function
            + Setup service main business function
        - EAPMES_Load_Module_Validation()
            + Main sub function of EAPMES_LOAD_MODULE function
    Detail Description
        - EAPMES_LOAD_MODULE()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Load_Module_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Load_Module()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Load_Module(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_LOAD_MODULE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_LOAD_MODULE", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);

    /* Temp */
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));


    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */


	/* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"MESEAP_Load_Module", 
		out_node, 
		0x00, 
		s_channel, 
		gi_default_ttl, 
		DM_UNICAST) != MP_TRUE)
	{
		// Error
	}

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    //CEIS_Save_Message_Log_For_List(in_node, out_node);
    CEIS_Save_Message_Log_For_Single_List(in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_LOAD_MODULE()
        - Main sub function of "EAPMES_Load_Module" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_LOAD_MODULE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPLOTRAM_TAG CWIPLOTRAM;

	char s_tmplot[26];
	TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    char   s_sys_time[14];
	char   s_res_id[20];

	TRSNode **LOT_ITEM;
	int icnt = 0, i = 0;

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	memset(s_res_id, ' ', sizeof(s_res_id));

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    LOG_head("EAPMES_LOAD_MODULE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(EAPMES_Load_Module_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	memset(s_tmplot, ' ', sizeof(s_tmplot));

    /* To Do */
	LOT_ITEM = TRS.get_list(in_node, "LOT_ITEM");
	icnt   =  TRS.get_item_count(in_node, "LOT_ITEM");

	for (i = 0; i < icnt; i++)
	{
		
		/* Get material ID and  operation */
		DBC_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), LOT_ITEM[i], "LOT_ID");
		DBC_select_mwiplotsts_for_update(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//LOT 있는놈이라도 시작시킴.
			//continue; :없는놈은 생성위해..
		}
		
		//LOT 의 그룹ID :  LOT_GROUP_ID 3에 처음 LOT ID ( LAMI 동시에 들어가는 LOT 구분)
		//                 LOT_CMF_3 에 순번
		//                 LOT_CMF_4 에 UPPER_BAR_ID(TRANSFER)
		//                 LOT_CMF_5 에 OWER_BAR_ID(TRANSFER)
		if (COM_isspace(s_tmplot, sizeof(s_tmplot)) == MP_TRUE)
		{
 			memcpy(s_tmplot, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		}
		memcpy(MWIPLOTSTS.LOT_GROUP_ID_3, s_tmplot, 25);
		COM_itoa_left(MWIPLOTSTS.LOT_CMF_3, i+1, sizeof(MWIPLOTSTS.LOT_CMF_3));
		TRS.copy(MWIPLOTSTS.LOT_CMF_4, sizeof(MWIPLOTSTS.LOT_CMF_4), in_node, "UPPER_BAR_ID");
		TRS.copy(MWIPLOTSTS.LOT_CMF_5, sizeof(MWIPLOTSTS.LOT_CMF_5), in_node, "LOWER_BAR_ID");

		CDB_update_mwiplotsts(7, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		/*Laminator Chamber IS-20-12-058*/
		/* Get Lot Info */
        CDB_init_cwiplotram(&CWIPLOTRAM);
        TRS.copy(CWIPLOTRAM.FACTORY, sizeof(CWIPLOTRAM.FACTORY), in_node, "FACTORY");
        TRS.copy(CWIPLOTRAM.LOT_ID, sizeof(CWIPLOTRAM.LOT_ID), LOT_ITEM[i], "LOT_ID");
        //memcpy(CWIPLOTRAM.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(CWIPLOTRAM.ORDER_ID));IS-21-01-094 MES logic 개선
		memcpy(CWIPLOTRAM.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		TRS.copy(CWIPLOTRAM.LINE_ID, sizeof(CWIPLOTRAM.LOT_ID), in_node, "LINE_ID");
        TRS.copy(CWIPLOTRAM.RES_ID, sizeof(CWIPLOTRAM.RES_ID), in_node, "RES_ID");
		
		CDB_select_cwiplotram(1, &CWIPLOTRAM);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
				memcpy(CWIPLOTRAM.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
				memcpy(CWIPLOTRAM.LOAD_TIME, s_sys_time, sizeof(s_sys_time));
				memcpy(CWIPLOTRAM.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
				CDB_insert_cwiplotram(&CWIPLOTRAM);
            }
            else
            {
				//Do Nothing
            }
        }

		TRS.copy(CWIPLOTRAM.RES_ID, sizeof(CWIPLOTRAM.RES_ID), in_node, "RES_ID");
        memcpy(CWIPLOTRAM.LOAD_TIME, s_sys_time, sizeof(s_sys_time));
		memcpy(CWIPLOTRAM.LAST_TRAN_TIME, s_sys_time, sizeof(s_sys_time));
				
		CDB_update_cwiplotram(1,&CWIPLOTRAM);
		if(DB_error_code != DB_SUCCESS)
		{
			//Do Nothing
		}
		
		tran_in_node = TRS.create_node("START_LOT_IN");
		tran_out_node = TRS.create_node("START_LOT_OUT");

		CCOM_copy_in_node(in_node, tran_in_node);
		TRS.add_char(tran_in_node, "PROCSTEP", TRS.get_procstep(in_node));  
		TRS.add_nstring(tran_in_node, "LOT_ID", TRS.get_string(LOT_ITEM[i], "LOT_ID"));  
		TRS.add_string(tran_in_node,  "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID)); 
		TRS.add_string(tran_in_node, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER)); 
		TRS.add_nstring(tran_in_node, "RES_ID", TRS.get_string(in_node,"RES_ID"));
  
		if(EAPMES_START_LOT(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		{
			//TRS.init_node(out_node);
			TRS.clone(out_node, tran_out_node);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			TRS.free_node(tran_in_node);
			TRS.free_node(tran_out_node);
			return MP_FALSE;
		}
		
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);

	}
	
    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Load_Module_Validation()
        - Main sub function of "EAPMES_LOAD_MODULE" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Load_Module_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    return MP_TRUE;
}

