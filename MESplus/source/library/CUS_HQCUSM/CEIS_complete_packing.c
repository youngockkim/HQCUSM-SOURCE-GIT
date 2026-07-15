/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_complete_packing.c
    Description : EAPMES End Lot Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Complete_Packing()
            + Setup service interface function
        - EAPMES_COMPLETE_PACKING()
            + Main sub function of EAPMES_Complete_Packing function
            + Setup service main business function
        - EAPMES_Complete_Packing_Validation()
            + Main sub function of EAPMES_COMPLETE_PACKING function
            + Check the condition for create/update/delete
    Detail Description
        - EAPMES_COMPLETE_PACKING()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2018/11/21  Hyun           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
#include "CUS_common.h"

int EAPMES_Complete_Packing_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int COM_Packing_Log(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
/*******************************************************************************
    EAPMES_Complete_Packing()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Complete_Packing(TRSNode *in_node)
{
	char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COMPLETE_PACKING(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COMPLETE_PACKING", out_node);

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
    /*CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));*/

    /* Additional Data */



	/* MES to EAP */
	//memset(s_channel, 0x00, sizeof(s_channel));
	//sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	////strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
 //   strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	//COM_add_null(s_channel, sizeof(s_channel));
 //   
	//if(CallService(MODULE_EAP, 
	//	"MESEAP_Terminate_Lot", 
	//	out_node, 
	//	0x00, 
	//	s_channel, 
	//	gi_default_ttl, 
	//	DM_UNICAST) != MP_TRUE)
	//{
	//	// Error
	//}

 //   /* Save error service error log */
 //   COM_Save_Service_Error_Log(in_node, out_node);

 //   /* Save all received message log */
 //   /* CEISMSGLOG */
 //   //CEIS_Save_Message_Log(in_node, out_node);
 //   CEIS_Save_Message_Log_For_List(in_node, out_node);

	
    CCOM_copy_in_node(in_node, out_node);
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));

	COM_Publish_Data(s_msg_code, out_node);

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    /* CEISMSGLOG */
    //CEIS_Save_Message_Log(in_node, out_node);
    CEIS_Save_Message_Log_For_List(in_node, out_node);
	
	COM_Packing_Log(s_msg_code, in_node, out_node);

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COMPLETE_PACKING()
        - Main sub function of "EAPMES_Complete_Packing" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COMPLETE_PACKING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CTMPLOTPAK_TAG CTMPLOTPAK;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_ARTICLE;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct MWIPMATDEF_TAG MWIPMATDEF;

	struct MGCMLAGDAT_TAG MGCMLAGDAT_PACK_TYPE;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_POWER_CLASS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_MAP;
	
	
    char   s_sys_time[14];

	TRSNode ** PACK_LIST;
	int pack_list_count;
	int k;
	int j;
	int i;
	
	TRSNode *list_item;

    TRSNode* tran_in_node;
    TRSNode* tran_out_node;  

    LOG_head("EAPMES_COMPLETE_PACKING");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time, ' ', sizeof(s_sys_time));
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

    if(EAPMES_Complete_Packing_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


	// PC ID GET
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
		strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

		gs_log_type.e_type = MP_LOG_E_EXISTENCE;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	TRS.add_string(out_node, "PC_ID", MRASRESDEF.RES_CMF_8, sizeof(MRASRESDEF.RES_CMF_8));

	// GET Pack H V (수직수평포장)

	// GET Pack H V
	if(memcmp(TRS.get_string(in_node, "RES_ID"), "US-E0-PKG-01", strlen("US-E0-PKG-01")) == 0){
		TRS.set_string(in_node, "CMF_5", "V", sizeof("V"));
		TRS.add_string(out_node, "PACK_DIRECTION", "V", sizeof("V")); //[2024.02.23] 추가 이글2  
	}else if(memcmp(TRS.get_string(in_node, "RES_ID"), "US-E0-PKG-02", strlen("US-E0-PKG-02")) == 0){
		TRS.set_string(in_node, "CMF_5", "H", sizeof("H"));
		TRS.add_string(out_node, "PACK_DIRECTION", "H", sizeof("H")); //[2024.02.23] 추가 이글2
	}
	TRS.add_string(out_node, "AUTO_COMPLETE", "Y", sizeof("Y")); //[2024.02.23] 추가 이글2

	CDB_init_ctmplotpak(&CTMPLOTPAK);
	TRS.copy(CTMPLOTPAK.FACTORY, sizeof(CTMPLOTPAK.FACTORY), in_node, "FACTORY");
	TRS.copy(CTMPLOTPAK.RES_ID, sizeof(CTMPLOTPAK.RES_ID), in_node, "RES_ID");
	TRS.copy(CTMPLOTPAK.CMF_5, sizeof(CTMPLOTPAK.CMF_5), in_node, "CMF_5");

	CDB_delete_ctmplotpak(2, &CTMPLOTPAK);
	if(DB_error_code != DB_SUCCESS)
	{ 
		if(DB_error_code == DB_NOT_FOUND)
		{
		}
		else
		{
			strcpy(s_msg_code, "RAS-0004"); 
			TRS.add_fieldmsg(out_node, "CTMPLOTPAK DELETE", MP_NVST); 
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPLOTPAK.FACTORY), CTMPLOTPAK.FACTORY); 
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CTMPLOTPAK.RES_ID), CTMPLOTPAK.RES_ID); 
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
			return MP_FALSE; 
		}
	} 


	//TEMP TABLE SAVE
	
	PACK_LIST = TRS.get_list(in_node, "LOT_ITEM");
	pack_list_count = TRS.get_item_count(in_node, "LOT_ITEM");

	for(i = 0; i <pack_list_count; i++)
	{
		
		CDB_init_ctmplotpak(&CTMPLOTPAK);
		TRS.copy(CTMPLOTPAK.FACTORY, sizeof(CTMPLOTPAK.FACTORY), in_node, "FACTORY");
		TRS.copy(CTMPLOTPAK.LOT_ID, sizeof(CTMPLOTPAK.LOT_ID), PACK_LIST[i], "LOT_ID");
		//[2024.02.23] 추가 - 이글2
		if (i == 0)
		{
		  TRS.add_string(out_node, "PACK_LOT_ID", CTMPLOTPAK.LOT_ID, sizeof(CTMPLOTPAK.LOT_ID));
		}

		//[23.05.19]먼저 삭제 후 UPDATE 
		CDB_delete_ctmplotpak(1, &CTMPLOTPAK);

		CDB_select_ctmplotpak(1, &CTMPLOTPAK);
		if(DB_error_code != DB_SUCCESS)
		{  
			if(DB_error_code == DB_NOT_FOUND)
			{
				//INSERT


				TRS.copy(CTMPLOTPAK.PALLET_ID, sizeof(CTMPLOTPAK.PALLET_ID), in_node, "PACKING_ID");
				CTMPLOTPAK.PAK_SEQ  = i+1; 

				DBC_init_mwiplotsts(&MWIPLOTSTS);
				TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), PACK_LIST[i], "LOT_ID");
				DBC_select_mwiplotsts(1, &MWIPLOTSTS);
				if(DB_error_code != DB_SUCCESS) 
				{
					strcpy(s_msg_code, "WIP-0044");
					TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_TRANS;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				memcpy(CTMPLOTPAK.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(CTMPLOTPAK.MAT_ID));

				DBC_init_mwipmatdef(&MWIPMATDEF);
				TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, "FACTORY");
				memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				MWIPMATDEF.MAT_VER = 1;

				DBC_select_mwipmatdef(1, &MWIPMATDEF);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0006");
					TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
					TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
					TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				memcpy(CTMPLOTPAK.FLOW, MWIPLOTSTS.FLOW, sizeof(CTMPLOTPAK.FLOW));
				memcpy(CTMPLOTPAK.OPER, MWIPLOTSTS.OPER, sizeof(CTMPLOTPAK.OPER));
				//memcpy(CTMPLOTPAK.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(CTMPLOTPAK.ORDER_ID));
				memcpy(CTMPLOTPAK.LINE_ID, MWIPLOTSTS.LOT_CMF_1,sizeof(CTMPLOTPAK.LINE_ID));
				TRS.copy(CTMPLOTPAK.RES_ID, sizeof(CTMPLOTPAK.RES_ID), in_node, "RES_ID");
				//I:INITIAL(AUTO PACKING 에서 사용함)
				CTMPLOTPAK.STATUS_FLAG  = 'I'; 

				CDB_init_mgcmlagdat(&MGCMLAGDAT);
				TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
				memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
				memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
				CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPLOTPAK SELECT", MP_NVST);
					//TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, strlen(CTMPLOTPAK.LOT_ID), CTMPLOTPAK.LOT_ID); // Server Crash
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CTMPLOTPAK.LOT_ID), CTMPLOTPAK.LOT_ID); // Server Crash
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;          
				}
				//구자재인경우 //신자재로 맵핑 가능한지 체크한다.
				if(MWIPMATDEF.MAT_ID[0]== '0')
				{
					CDB_init_mgcmlagdat(&MGCMLAGDAT_MAP);
					TRS.copy(MGCMLAGDAT_MAP.FACTORY, sizeof(MGCMLAGDAT_MAP.FACTORY), in_node, "FACTORY");
					memcpy(MGCMLAGDAT_MAP.TABLE_NAME, "@CONV_MAT_GERP", strlen("@CONV_MAT_GERP"));
					memcpy(MGCMLAGDAT_MAP.KEY_1, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
					CDB_select_mgcmlagdat(2, &MGCMLAGDAT_MAP);
					if (DB_error_code == DB_SUCCESS)
					{
						memset(MWIPMATDEF.MAT_ID, ' ', sizeof(MWIPMATDEF.MAT_ID));
						memcpy(MWIPMATDEF.MAT_ID, MGCMLAGDAT_MAP.DATA_1, sizeof(MWIPMATDEF.MAT_ID));
					}
				}

				memcpy(CTMPLOTPAK.PAK_TYPE, MGCMLAGDAT.KEY_2, sizeof(CTMPLOTPAK.PAK_TYPE));
				//TRS.copy(CTMPLOTPAK.PAK_TIME, sizeof(CTMPLOTPAK.PAK_TIME), in_node, "PAK_TIME");

				CDB_init_cedclotrlt(&CEDCLOTRLT);
				TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
				memcpy(CEDCLOTRLT.INS_TYPE, "FC", strlen("FC"));
				memcpy(CEDCLOTRLT.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID));
				CDB_select_cedclotrlt(1, &CEDCLOTRLT);
				if(DB_error_code != DB_SUCCESS)
				{
					if(DB_error_code == DB_NOT_FOUND)
					{
						strcpy(s_msg_code, "EDC-0098");
						TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
						TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);

						gs_log_type.e_type = MP_LOG_E_EXISTENCE;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
					else
					{
						strcpy(s_msg_code, "EDC-0004");
						TRS.add_fieldmsg(out_node, "CEDCLOTRLT SELECT", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
						TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
						TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
						TRS.add_dberrmsg(out_node,DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}

				memcpy(CTMPLOTPAK.GRADE, CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
				memcpy(CTMPLOTPAK.POWER, CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));
				//[ERP Project]23.03.29 
				//제품 코드가 문자로 시작 되면 아티클 코드를 체크 하지 않는다.
				if(MWIPMATDEF.MAT_ID[0] == '0')
				{	
					CDB_init_mgcmlagdat(&MGCMLAGDAT_ARTICLE);
					TRS.copy(MGCMLAGDAT_ARTICLE.FACTORY, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), in_node, IN_FACTORY);
					memcpy(MGCMLAGDAT_ARTICLE.TABLE_NAME, "@ARTICLE", strlen("@ARTICLE"));
					memcpy(MGCMLAGDAT_ARTICLE.KEY_1, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
					memcpy(MGCMLAGDAT_ARTICLE.DATA_1, CTMPLOTPAK.POWER, sizeof(CTMPLOTPAK.POWER));
					memcpy(MGCMLAGDAT_ARTICLE.DATA_2, CTMPLOTPAK.GRADE,sizeof(CTMPLOTPAK.GRADE));
	
					CDB_select_mgcmlagdat(5, &MGCMLAGDAT_ARTICLE);
					if(DB_error_code != DB_SUCCESS)
					{
						if(DB_error_code == DB_NOT_FOUND)
						{
							strcpy(s_msg_code, "BOM-0042");
							TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), MGCMLAGDAT_ARTICLE.FACTORY);
							TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.TABLE_NAME), MGCMLAGDAT_ARTICLE.TABLE_NAME);
							TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.KEY_1), MGCMLAGDAT_ARTICLE.KEY_1);

							gs_log_type.e_type = MP_LOG_E_EXISTENCE;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
						else
						{
							strcpy(s_msg_code, "BOM-0004");
							TRS.add_fieldmsg(out_node, "MGCMLAGDAT OPEN", MP_NVST);
							TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), MGCMLAGDAT_ARTICLE.FACTORY);
							TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.TABLE_NAME), MGCMLAGDAT_ARTICLE.TABLE_NAME);
							TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMLAGDAT_ARTICLE.KEY_1), MGCMLAGDAT_ARTICLE.KEY_1);

							TRS.add_dberrmsg(out_node,DB_error_msg);

							gs_log_type.type = MP_LOG_ERROR;
							gs_log_type.e_type = MP_LOG_E_SYSTEM;
							gs_log_type.category = MP_LOG_CATE_VIEW;
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
					}
				}
				else		//자재가 문자인 경우
				{
					//모듈 타입 조회
					CDB_init_mgcmlagdat(&MGCMLAGDAT_PACK_TYPE);
					TRS.copy(MGCMLAGDAT_PACK_TYPE.FACTORY, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), in_node, IN_FACTORY);
					memcpy(MGCMLAGDAT_PACK_TYPE.TABLE_NAME, "@PACKING_TYPE", strlen("@PACKING_TYPE"));
					memcpy(MGCMLAGDAT_PACK_TYPE.KEY_1, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
					k = 0;
					k = COM_string_length(MGCMLAGDAT_PACK_TYPE.KEY_1, sizeof(MGCMLAGDAT_PACK_TYPE.KEY_1));		//머트리얼 자릿수를 정의한다.
					if(k>0)
					{
						MGCMLAGDAT_PACK_TYPE.KEY_1[k] = '-';

					}
					j = 0 ;
					if (COM_isnullspace(CEDCLOTRLT.POWER) == MP_FALSE)		//POWER 값 NULL 체크
					{
						j = 0 ;
						j = COM_string_length(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));		//POWER값 자릿수를 체크한다.
					}
					
					if(j==1)	//power 값이 1자리인경우
					{
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = '0';
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = '0';
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = '0';
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[0];
					}
					else if (j == 2)	//power 값이 2자리인경우
					{
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = '0';
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = '0';
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = CEDCLOTRLT.POWER[0];	
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[1];	
					}
					else if (j == 3)	//power 값이 3자리인경우
					{
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = '0';
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = CEDCLOTRLT.POWER[0];	
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = CEDCLOTRLT.POWER[1];	
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[2];	
					}
					else if (j == 4)	//power 값이 4자리인경우
					{
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = CEDCLOTRLT.POWER[0];	
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = CEDCLOTRLT.POWER[1];	
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = CEDCLOTRLT.POWER[2];		
						MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[3];	
					}

					//모듈 타입 조회
					CDB_select_mgcmlagdat(2, &MGCMLAGDAT_PACK_TYPE);
					if (DB_error_code != DB_SUCCESS)
					{

					}
					
					memset(CTMPLOTPAK.PAK_TYPE, ' ', sizeof(CTMPLOTPAK.PAK_TYPE));
					memcpy(CTMPLOTPAK.PAK_TYPE, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(CTMPLOTPAK.PAK_TYPE)); //모듈 타입


				}


				TRS.copy(CTMPLOTPAK.CMF_1, sizeof(CTMPLOTPAK.CMF_1), in_node, "CMF_1");
				TRS.copy(CTMPLOTPAK.CMF_2, sizeof(CTMPLOTPAK.CMF_2), in_node, "CMF_2");
				TRS.copy(CTMPLOTPAK.CMF_3, sizeof(CTMPLOTPAK.CMF_3), in_node, "CMF_3");
				TRS.copy(CTMPLOTPAK.CMF_4, sizeof(CTMPLOTPAK.CMF_4), in_node, "CMF_4");
				TRS.copy(CTMPLOTPAK.CMF_5, sizeof(CTMPLOTPAK.CMF_5), in_node, "CMF_5");

				CTMPLOTPAK.HIST_SEQ  = 0; 
				memcpy(CTMPLOTPAK.CREATE_TIME, s_sys_time, sizeof(CTMPLOTPAK.CREATE_TIME));

				CDB_insert_ctmplotpak(&CTMPLOTPAK); 
				if(DB_error_code != DB_SUCCESS)
				{ 
					strcpy(s_msg_code, "WIP-0004"); 
					TRS.add_fieldmsg(out_node, "CTMPLOTPAK INSERT", MP_NVST); 
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPLOTPAK.FACTORY), CTMPLOTPAK.FACTORY); 
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CTMPLOTPAK.LOT_ID), CTMPLOTPAK.LOT_ID); 
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_SETUP;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
					return MP_FALSE; 
				} 
			}
			else 
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CTMPLOTPAK INSERT", MP_NVST); 
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CTMPLOTPAK.FACTORY), CTMPLOTPAK.FACTORY); 
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CTMPLOTPAK.LOT_ID), CTMPLOTPAK.LOT_ID); 
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node)); 
				return MP_FALSE; 
			}
		}
		else
		{
			//UPDATE  문삭제
			
			
		}
		//[2024.02.23]추가
		TRS.add_string(out_node, "PALLET_ID", CTMPLOTPAK.PALLET_ID, sizeof(CTMPLOTPAK.PALLET_ID));

		list_item = TRS.add_node(out_node, "PACK_LIST");
		TRS.set_string(list_item, "LINE_ID", CTMPLOTPAK.LINE_ID, sizeof(CTMPLOTPAK.LINE_ID));
		TRS.set_string(list_item, "OPER", CTMPLOTPAK.OPER, sizeof(CTMPLOTPAK.OPER));
		TRS.set_string(list_item, "RES_ID", CTMPLOTPAK.RES_ID, sizeof(CTMPLOTPAK.RES_ID));
		TRS.set_string(list_item, "MAT_ID", CTMPLOTPAK.MAT_ID, sizeof(CTMPLOTPAK.MAT_ID));
		TRS.set_string(list_item, "MAT_DESC", MWIPMATDEF.MAT_DESC, sizeof(MWIPMATDEF.MAT_DESC));
		TRS.set_string(list_item, "LOT_ID", CTMPLOTPAK.LOT_ID, sizeof(CTMPLOTPAK.LOT_ID));
		TRS.set_string(list_item, "GRADE", CTMPLOTPAK.GRADE, sizeof(CTMPLOTPAK.GRADE));
		TRS.set_string(list_item, "POWER", CTMPLOTPAK.POWER, sizeof(CTMPLOTPAK.POWER));
		//TRS.set_string(list_item, "MODULE_TYPE", CTMPLOTPAK.PAK_TYPE, sizeof(CTMPLOTPAK.PAK_TYPE));
		TRS.set_string(list_item, "CMF_5", TRS.get_string(in_node,"CMF_5"), sizeof(TRS.get_string(in_node,"CMF_5")));

		
		//제품 코드가 문자로 시작 되면 아티클 코드를 체크 하지 않는다.
		if(MWIPMATDEF.MAT_ID[0] == '0')
		{
			TRS.set_string(list_item, "MODULE_TYPE", CTMPLOTPAK.PAK_TYPE, sizeof(CTMPLOTPAK.PAK_TYPE));
			TRS.set_string(list_item, "POWER_CLASS", MGCMLAGDAT_ARTICLE.DATA_5, sizeof(MGCMLAGDAT_ARTICLE.DATA_5));
			TRS.set_string(list_item, "BARCODE", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
			TRS.set_string(list_item, "ARTICLE_NO", MGCMLAGDAT_ARTICLE.KEY_2, sizeof(MGCMLAGDAT_ARTICLE.KEY_2));
			TRS.set_string(list_item, "ARTICLE_DESC", MGCMLAGDAT_ARTICLE.DATA_4, sizeof(MGCMLAGDAT_ARTICLE.DATA_4));

		}
		else
		{
			//바코드 아이디 뒷에서 2번째 자릿수는 등급에 따라 변경
			if(COM_isnullspace(MGCMLAGDAT.DATA_2) == MP_FALSE)
			{
				k = 0;
				k = COM_string_length(MGCMLAGDAT.DATA_2,sizeof(MGCMLAGDAT.DATA_2));
				if(k == 6) //2024.02.23 변경 
				{
					if(memcmp(CEDCLOTRLT.GRADE, "G01",strlen("G01")) == 0){
						MGCMLAGDAT.DATA_2[4] = '1';
					}
					else if(memcmp(CEDCLOTRLT.GRADE, "G02",strlen("G02")) == 0){
						MGCMLAGDAT.DATA_2[4] = '5';
					}
					else if(memcmp(CEDCLOTRLT.GRADE, "G03",strlen("G03")) == 0){		//--[G03/G04 로직 추가]
						MGCMLAGDAT.DATA_2[4] = '6';
					}
					else if(memcmp(CEDCLOTRLT.GRADE, "G04",strlen("G04")) == 0){		//--[G03/G04 로직 추가]
						MGCMLAGDAT.DATA_2[4] = '0';
					}
					else if(memcmp(CEDCLOTRLT.GRADE, "B",strlen("B")) == 0){
						if (COM_atoi(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)) < 200) //200WP 미만 출력 B 등급 7
						{
							MGCMLAGDAT.DATA_2[4] = '7';
						}
						else
						{
							MGCMLAGDAT.DATA_2[4] = '2';
						}


					}
					else if(memcmp(CEDCLOTRLT.GRADE, "C",strlen("C")) == 0){
						if (COM_atoi(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER))< 200) //200WP 미만 출력 C 등급 8
						{
							MGCMLAGDAT.DATA_2[4] = '8';
						}
						else
						{
							MGCMLAGDAT.DATA_2[4] = '3';
						}
					}
					else
					{
						if (COM_atoi(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER)) < 200) // G60 Z GRADE 
						{
							MGCMLAGDAT.DATA_2[4] = '9';
						}
						else
						{
							MGCMLAGDAT.DATA_2[4] = '4';
						}
					}


				}

			}

		//아티클 중지에 따라 모듈타입과 파워클라스는 조합 하여 사용
		//조회를 사용함
		CDB_init_mgcmlagdat(&MGCMLAGDAT_PACK_TYPE);
		TRS.copy(MGCMLAGDAT_PACK_TYPE.FACTORY, sizeof(MGCMLAGDAT_ARTICLE.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMLAGDAT_PACK_TYPE.TABLE_NAME, "@PACKING_TYPE", strlen("@PACKING_TYPE"));
		
		memcpy(MGCMLAGDAT_PACK_TYPE.KEY_1, MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		k = 0;
		k = COM_string_length(MGCMLAGDAT_PACK_TYPE.KEY_1, sizeof(MGCMLAGDAT_PACK_TYPE.KEY_1));		//머트리얼 자릿수를 정의한다.
		
		if(k>0)
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[k] = '-';

		}
		if (COM_isnullspace(CEDCLOTRLT.POWER) == MP_FALSE)		//POWER 값 NULL 체크
		{
			j = 0 ;
			j = COM_string_length(CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));		//POWER값 자릿수를 체크한다.
		}

		if(j==1)	//power 값이 1자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[0];
		}
		else if (j == 2)	//power 값이 2자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = CEDCLOTRLT.POWER[0];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[1];	
		}
		else if (j == 3)	//power 값이 3자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = '0';
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = CEDCLOTRLT.POWER[0];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = CEDCLOTRLT.POWER[1];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[2];	
		}
		else if (j == 4)	//power 값이 4자리인경우
		{
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+1] = CEDCLOTRLT.POWER[0];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+2] = CEDCLOTRLT.POWER[1];	
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+3] = CEDCLOTRLT.POWER[2];		
			MGCMLAGDAT_PACK_TYPE.KEY_1[k+4] = CEDCLOTRLT.POWER[3];	
		}

		//모듈 타입 조회
		CDB_select_mgcmlagdat(2, &MGCMLAGDAT_PACK_TYPE);
		if (DB_error_code != DB_SUCCESS)
		{

		}
		//파워 글라스 조회
		CDB_init_mgcmlagdat(&MGCMLAGDAT_POWER_CLASS);
		memcpy(MGCMLAGDAT_POWER_CLASS.FACTORY, MGCMLAGDAT_PACK_TYPE.FACTORY, sizeof(struct MGCMLAGDAT_TAG));//스트럭쳐 copy
		memset(MGCMLAGDAT_POWER_CLASS.TABLE_NAME, ' ', sizeof(MGCMLAGDAT_POWER_CLASS.TABLE_NAME));
		memcpy(MGCMLAGDAT_POWER_CLASS.TABLE_NAME, "@PACKING_POWER_CLASS", strlen("@PACKING_POWER_CLASS"));

		CDB_select_mgcmlagdat(2, &MGCMLAGDAT_POWER_CLASS);
		if (DB_error_code != DB_SUCCESS)
		{

		}

		CDB_init_mgcmlagdat(&MGCMLAGDAT_ARTICLE);
		if (memcmp(CEDCLOTRLT.GRADE, "G01", strlen("G01")) == 0) {
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G02", strlen("G02")) == 0) 
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G03", strlen("G03")) == 0)		//--[G03/G04 로직 추가]
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}
		else if (memcmp(CEDCLOTRLT.GRADE, "G04", strlen("G04")) == 0)		//--[G03/G04 로직 추가]
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_1, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_1)); //파워클라스는
		}

		else if (memcmp(CEDCLOTRLT.GRADE, "B", strlen("B")) == 0) 
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_2, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_2)); //파워클라스는
		}
		else
		{
			memcpy(MGCMLAGDAT_ARTICLE.DATA_3, MGCMLAGDAT_PACK_TYPE.DATA_1, sizeof(MGCMLAGDAT_PACK_TYPE.DATA_1)); //모듈 타입
			memcpy(MGCMLAGDAT_ARTICLE.DATA_5, MGCMLAGDAT_POWER_CLASS.DATA_3, sizeof(MGCMLAGDAT_POWER_CLASS.DATA_3)); //파워클라스는
		}

		TRS.set_string(list_item, "MODULE_TYPE", MGCMLAGDAT_ARTICLE.DATA_3, sizeof(MGCMLAGDAT_ARTICLE.DATA_3));
		TRS.set_string(list_item, "POWER_CLASS", MGCMLAGDAT_ARTICLE.DATA_5, sizeof(MGCMLAGDAT_ARTICLE.DATA_5));
		TRS.set_string(list_item, "BARCODE", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
		}
		
		


		
		TRS.set_int(list_item, "MODUL_QTY", COM_atoi(MGCMLAGDAT.DATA_9, 2));

	}



    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Complete_Packing_Validation()
        - Main sub function of "EAPMES_COMPLETE_PACKING" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Complete_Packing_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
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

/*******************************************************************************
  COM_Packing_Log()
    - Main sub function of "EAPMES_COMPLETE_PACKING_E23" function
    - Check the condition for create/update/delete
  Return Value
    - int : 1 (MP_TRUE) or 0 (MP_FALSE)
  Arguments
    - char *s_msg_code : Error Message Code
    - TRSNode *in_node : Input Message structure
    - TRSNode *out_node : Output Message structure
*******************************************************************************/
int COM_Packing_Log(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
  struct CWIPPAKLOG_TAG CWIPPAKLOG;

  char   s_sys_time[14];
  memset(s_sys_time, ' ', sizeof(s_sys_time));

  DB_get_systime(s_sys_time);
  if (DB_error_code != DB_SUCCESS)
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

  CDB_init_cwippaklog(&CWIPPAKLOG);
  TRS.copy(CWIPPAKLOG.FACTORY, sizeof(CWIPPAKLOG.FACTORY), in_node, "FACTORY");
  TRS.copy(CWIPPAKLOG.RES_ID, sizeof(CWIPPAKLOG.RES_ID), in_node, "RES_ID");
  TRS.copy(CWIPPAKLOG.PAKING_ID, sizeof(CWIPPAKLOG.PAKING_ID), in_node, "PACKING_ID");
  TRS.copy(CWIPPAKLOG.LOT_ID, sizeof(CWIPPAKLOG.LOT_ID), out_node, "PACK_LOT_ID");
  TRS.copy(CWIPPAKLOG.PACK_TIME, sizeof(CWIPPAKLOG.PACK_TIME), out_node, "PACK_TIME");
  if (CWIPPAKLOG.PACK_TIME[0] == ' ')
  {
    memcpy(CWIPPAKLOG.PACK_TIME, s_sys_time, sizeof(CWIPPAKLOG.PACK_TIME));
  }
  TRS.copy(CWIPPAKLOG.PALLET_ID, sizeof(CWIPPAKLOG.PALLET_ID), out_node, "PALLET_ID");
  TRS.copy(CWIPPAKLOG.LINE_ID, sizeof(CWIPPAKLOG.LINE_ID), in_node, "LINE_ID");
  TRS.copy(CWIPPAKLOG.PAK_TYPE, sizeof(CWIPPAKLOG.PAK_TYPE), out_node, "PACK_DIRECTION");
  TRS.copy(CWIPPAKLOG.CMF_1, sizeof(CWIPPAKLOG.CMF_1), out_node, "AUTO_COMPLETE");
  TRS.copy(CWIPPAKLOG.CREATE_USER_ID, sizeof(CWIPPAKLOG.CREATE_USER_ID), in_node, IN_USERID);
  CWIPPAKLOG.SUCCESS_YN = 'N';

  memcpy(CWIPPAKLOG.ERR_MSG, s_msg_code, sizeof(s_msg_code));

  if (CWIPPAKLOG.ERR_MSG[0] == ' ')
  {
    CWIPPAKLOG.SUCCESS_YN = 'Y';
  }
  memcpy(CWIPPAKLOG.CREATE_TIME, s_sys_time, sizeof(CWIPPAKLOG.CREATE_TIME));

  CDB_insert_cwippaklog(&CWIPPAKLOG);
  if (DB_error_code != DB_SUCCESS)
  {
    //NOTHING
  }

  DB_commit();

  return MP_TRUE;
}