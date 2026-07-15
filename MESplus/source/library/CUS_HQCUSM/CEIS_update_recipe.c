/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_update_recipe.c
    Description : 

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Update_Recipe()
            + Setup service interface function
        - EAPMES_UPDATE_RECIPE()
            + Main sub function of EAPMES_Update_Recipe function
            + Setup service main business function
    Detail Description
        - EAPMES_UPDATE_RECIPE()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     yyyy/mm/dd  developer      desc 

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Update_Recipe_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    EAPMES_Update_Recipe()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Update_Recipe(TRSNode *in_node)		// CUS_HQCUSM_service.h	/ CUSHQCUSMAddService.c ¼±¾ð Ãß°¡
{	
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;
    TRSNode *out_node;

	///* ¼³ºñ·Î ÀÀ´äÀÌ ÇÊ¿äÇÒ °æ¿ì Ãß°¡ */
	// char s_channel[100];	

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_UPDATE_RECIPE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_UPDATE_RECIPE", out_node);

	// °á°ú°¡ ¼º°øÀÏ °æ¿ì DB commit
    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
	// °á°ú°¡ ½ÇÆÐÀÏ °æ¿ì DB rollback
	else
    {
        DB_rollback();
    }
	
	///* ¼³ºñ·Î ÀÀ´äÀÌ ÇÊ¿äÇÒ °æ¿ì Ãß°¡ */
	///* MES to EAP */
	//memset(s_channel, 0x00, sizeof(s_channel));
	//sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	////strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	//COM_add_null(s_channel, sizeof(s_channel));
	//
	//if(CallService(MODULE_EAP, 
	//				"MESEAP_Sample",	// ÀÀ´ä ¸Þ½ÃÁö ¸í
	//				out_node, 
	//				0x00, 
	//				s_channel, 
	//				gi_default_ttl, 
	//				DM_UNICAST) != MP_TRUE)
	//{
	//	// Error
	//}

    /* Save error service error log */
    COM_Save_Service_Error_Log(in_node, out_node);

    /* Save all received message log */
    CEIS_Save_Message_Log(in_node, out_node);	// CEISMSGLOG Å×ÀÌºí¿¡ ÀÌ·Â ³²±è 

	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_UPDATE_RECIPE()
        - Main sub function of "EAPMES_Update_Recipe" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_UPDATE_RECIPE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)	// CUS_HQCUSM_common.h ¼±¾ð Ãß°¡
{
	// »ç¿ëÇÒ º¯¼ö ¼±¾ð 
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MRASRESDEF_TAG MRASRESDEF;

	struct MRCPRCPDEF_TAG MRCPRCPDEF;
	struct MRCPRCPVER_TAG MRCPRCPVER;
	struct MRCPPRAVER_TAG MRCPPRAVER;

	struct CRCPVERHIS_TAG CRCPVERHIS;
	struct CRCPPRAHIS_TAG CRCPPRAHIS;

	char s_sys_time[14];

	int i_param_list_count;
	int i;
	int i_hist_seq;
	int	i_para_seq;
	int i_step;

	TRSNode **PARAM_LIST;

	// ¼³ºñ¿¡¼­ Àü¼ÛÇÑ in_node °ª ÀüºÎ ·Î±× ÀÛ¼º
    LOG_head("EAPMES_UPDATE_RECIPE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// ÇÊ¼ö Validation Ã³¸®
	if(EAPMES_Update_Recipe_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
	{
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	
    /********************************************************/
	/*	0. ÇöÀç DB ½Ã°£ Á¶È¸								*/
    /********************************************************/	

    memset(s_sys_time, ' ', sizeof(s_sys_time));

    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "CMN-0003");	// CMN-0003 : A fatal database error occurred. Please contact an administrator.
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);		

		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /********************************************************/
	/*	1. PLC - ¼³ºñ Á¤º¸ Á¶È¸								*/
    /********************************************************/	

	i_step = 4;
	
	CDB_init_mgcmtbldat(&MGCMTBLDAT);
	TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
	memcpy(MGCMTBLDAT.TABLE_NAME, "@PLC_RES_MAPPING", strlen("@PLC_RES_MAPPING"));	// KEY_1 = PLC ID, KEY_2 = RES ID, DATA_1 = RES ID
	TRS.copy(MGCMTBLDAT.KEY_1, sizeof(MGCMTBLDAT.KEY_1), in_node, "RES_ID");
	CDB_open_mgcmtbldat(i_step, &MGCMTBLDAT);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "EIS-0004");
		TRS.add_fieldmsg(out_node, "MGCMTBLDAT OPEN #4", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
        TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
		TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
        TRS.add_dberrmsg(out_node,DB_error_msg);
		
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	
	/********************************************************/
	/*	2. Á¶È¸µÈ ¼³ºñ¿¡ ·¹½ÃÇÇ µî·Ï						*/
	/********************************************************/

	while(1)
	{
		CDB_fetch_mgcmtbldat(i_step, &MGCMTBLDAT);
        if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_mgcmtbldat(i_step);
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        { 
            strcpy(s_msg_code, "EIS-0004");
			TRS.add_fieldmsg(out_node, "MGCMTBLDAT FETCH #4", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMTBLDAT.FACTORY), MGCMTBLDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMTBLDAT.TABLE_NAME), MGCMTBLDAT.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "KEY_1", MP_STR, sizeof(MGCMTBLDAT.KEY_1), MGCMTBLDAT.KEY_1);
            TRS.add_dberrmsg(out_node, DB_error_msg);

			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_mgcmtbldat(i_step);	// open~fetch~close ¹® ³»ÀÇ error Ã³¸®½Ã ¹«Á¶°Ç close ¹®ÀÌ ÇÊ¿äÇÏ´Ù. 
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
		
		/********************************************************/
		/*	2-1. ¼³ºñ Á¤º¸ Á¶È¸ (MRASRESDEF)					*/
		/********************************************************/

		DBC_init_mrasresdef(&MRASRESDEF);
		TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MRASRESDEF.RES_ID, MGCMTBLDAT.DATA_1, sizeof(MRASRESDEF.RES_ID));
		DBC_select_mrasresdef(1, &MRASRESDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			//strcpy(s_msg_code, "RAS-0003");
			//TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT #1", MP_NVST);
			//TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
			//TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
			//TRS.add_dberrmsg(out_node, DB_error_msg);

			//TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			//TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

			//gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			
            //CDB_close_mgcmtbldat(i_step);
			//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			//return MP_FALSE;
		}
		
		/********************************************************/
		/*	2-2. ·¹½ÃÇÇ Á¤º¸ Á¶È¸ ¹× ÀÔ·Â (MRCPRCPDEF)			*/
		/********************************************************/

		DBC_init_mrcprcpdef(&MRCPRCPDEF);
		TRS.copy(MRCPRCPDEF.FACTORY, sizeof(MRCPRCPDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MRCPRCPDEF.RES_ID, MGCMTBLDAT.DATA_1, sizeof(MRCPRCPDEF.RES_ID));
		TRS.copy(MRCPRCPDEF.SUBRES_ID, sizeof(MRCPRCPDEF.SUBRES_ID), in_node, "SUB_RES_ID");
		TRS.copy(MRCPRCPDEF.RECIPE, sizeof(MRCPRCPDEF.RECIPE), in_node, "PP_ID");
		DBC_select_mrcprcpdef(1, &MRCPRCPDEF);
		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
		{
			//strcpy(s_msg_code, "EIS-0004");
			//TRS.add_fieldmsg(out_node, "MRCPRCPDEF SELECT #1", MP_NVST);
			//TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPRCPDEF.FACTORY), MRCPRCPDEF.FACTORY);
			//TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPRCPDEF.RES_ID), MRCPRCPDEF.RES_ID);
			//TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRCPRCPDEF.SUBRES_ID), MRCPRCPDEF.SUBRES_ID);
			//TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPRCPDEF.RECIPE), MRCPRCPDEF.RECIPE);
			//TRS.add_dberrmsg(out_node, DB_error_msg);

			//TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			//TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);
			
			//gs_log_type.type = MP_LOG_ERROR;
			//gs_log_type.e_type = MP_LOG_E_SYSTEM;
			//gs_log_type.category = MP_LOG_CATE_VIEW;

			//CDB_close_mgcmtbldat(i_step);
			//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			//return MP_FALSE;
		}
		else if(DB_error_code == DB_NOT_FOUND)
		{
			// DB¿¡ Á¤º¸ ¾øÀ» °æ¿ì INSERT
			TRS.copy(MRCPRCPDEF.CREATE_USER_ID, sizeof(MRCPRCPDEF.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(MRCPRCPDEF.CREATE_TIME, s_sys_time, sizeof(MRCPRCPDEF.CREATE_TIME));
			DBC_insert_mrcprcpdef(&MRCPRCPDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				//strcpy(s_msg_code, "EIS-0004");
				//TRS.add_fieldmsg(out_node, "MRCPRCPDEF INSERT", MP_NVST);
				//TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPRCPDEF.FACTORY), MRCPRCPDEF.FACTORY);
				//TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPRCPDEF.RES_ID), MRCPRCPDEF.RES_ID);
				//TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRCPRCPDEF.SUBRES_ID), MRCPRCPDEF.SUBRES_ID);
				//TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPRCPDEF.RECIPE), MRCPRCPDEF.RECIPE);
				//TRS.add_dberrmsg(out_node, DB_error_msg);

				//TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
				//TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

				//gs_log_type.type = MP_LOG_ERROR;
				//gs_log_type.e_type = MP_LOG_E_SYSTEM;
				//gs_log_type.category = MP_LOG_CATE_VIEW;

				//CDB_close_mgcmtbldat(i_step);
				//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				//return MP_FALSE;
			}
		}
		
		/********************************************************/
		/*	2-2. ·¹½ÃÇÇ ¹öÀü Á¤º¸ Á¶È¸ ¹× ÀÔ·Â (MRCPRCPVER)		*/
		/********************************************************/
	
		i_hist_seq = 0;

		// ¸¶Áö¸· ÀÌ·Â SEQUENCE Á¶È¸
		CDB_init_crcpverhis(&CRCPVERHIS);
		memcpy(CRCPVERHIS.FACTORY, MRCPRCPDEF.FACTORY, sizeof(CRCPVERHIS.FACTORY));
		memcpy(CRCPVERHIS.RES_ID, MRCPRCPDEF.RES_ID, sizeof(CRCPVERHIS.RES_ID));
		memcpy(CRCPVERHIS.SUBRES_ID, MRCPRCPDEF.SUBRES_ID, sizeof(CRCPVERHIS.SUBRES_ID));
		memcpy(CRCPVERHIS.RECIPE, MRCPRCPDEF.RECIPE, sizeof(CRCPVERHIS.RECIPE));
		CRCPVERHIS.RECIPE_VERSION = TRS.get_int( in_node, "RECIPE_VERSION");
		i_hist_seq = (int) CDB_select_crcpverhis_scalar(2, &CRCPVERHIS);
	
		// ÇöÀç ·¹½ÃÇÇ ¹öÀü Á¤º¸ Á¶È¸
		DBC_init_mrcprcpver(&MRCPRCPVER);
		memcpy(MRCPRCPVER.FACTORY, MRCPRCPDEF.FACTORY, sizeof(MRCPRCPVER.FACTORY));
		memcpy(MRCPRCPVER.RES_ID, MRCPRCPDEF.RES_ID, sizeof(MRCPRCPVER.RES_ID));
		memcpy(MRCPRCPVER.SUBRES_ID, MRCPRCPDEF.SUBRES_ID, sizeof(MRCPRCPVER.SUBRES_ID));
		memcpy(MRCPRCPVER.RECIPE, MRCPRCPDEF.RECIPE, sizeof(MRCPRCPVER.RECIPE));
		MRCPRCPVER.RECIPE_VERSION = TRS.get_int( in_node, "RECIPE_VERSION");;
		DBC_select_mrcprcpver(1, &MRCPRCPVER);
		if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
		{
			//strcpy(s_msg_code, "EIS-0004");
			//TRS.add_fieldmsg(out_node, "MRCPRCPVER SELECT #1", MP_NVST);
			//TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRCPRCPDEF.FACTORY), MRCPRCPDEF.FACTORY);
			//TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRCPRCPDEF.RES_ID), MRCPRCPDEF.RES_ID);
			//TRS.add_fieldmsg(out_node, "SUBRES_ID", MP_STR, sizeof(MRCPRCPDEF.SUBRES_ID), MRCPRCPDEF.SUBRES_ID);
			//TRS.add_fieldmsg(out_node, "RECIPE", MP_STR, sizeof(MRCPRCPDEF.RECIPE), MRCPRCPDEF.RECIPE);
			//TRS.add_fieldmsg(out_node, "RECIPE", MP_INT, MRCPRCPVER.RECIPE_VERSION);
			//TRS.add_dberrmsg(out_node, DB_error_msg);

			//TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			//TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);
			
			//gs_log_type.type = MP_LOG_ERROR;
			//gs_log_type.e_type = MP_LOG_E_SYSTEM;
			//gs_log_type.category = MP_LOG_CATE_VIEW;

			//CDB_close_mgcmtbldat(i_step);
			//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			//return MP_FALSE;
		}

		COM_itoa_left(MRCPRCPVER.COL_SET_ID, i_hist_seq + 1, sizeof(MRCPRCPVER.COL_SET_ID));	// ÇöÀç ·¹½ÃÇÇ ÀÌ·Â SEQUENCE ÀÔ·Â
		if(DB_error_code == DB_SUCCESS)
		{
			// DB¿¡ Á¤º¸ ÀÖÀ» °æ¿ì UPDATE
			TRS.copy(MRCPRCPVER.UPDATE_USER_ID, sizeof(MRCPRCPVER.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(MRCPRCPVER.UPDATE_TIME, s_sys_time, sizeof(MRCPRCPVER.UPDATE_TIME));
			DBC_update_mrcprcpver(1, &MRCPRCPVER);
			if(DB_error_code != DB_SUCCESS)
			{

			}
		}
		else if(DB_error_code == DB_NOT_FOUND)
		{
			// DB¿¡ Á¤º¸ ¾øÀ» °æ¿ì INSERT
			TRS.copy(MRCPRCPVER.CREATE_USER_ID, sizeof(MRCPRCPVER.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(MRCPRCPVER.CREATE_TIME, s_sys_time, sizeof(MRCPRCPVER.CREATE_TIME));
			DBC_insert_mrcprcpver(&MRCPRCPVER);
			if(DB_error_code != DB_SUCCESS)
			{

			}
		}	

		/********************************************************/
		/*	2-3. ·¹½ÃÇÇ ¹öÀü ÀÌ·Â ÀÔ·Â (CRCPVERHIS)				*/
		/********************************************************/

		CDB_init_crcpverhis(&CRCPVERHIS);
		memcpy(CRCPVERHIS.FACTORY, MRCPRCPVER.FACTORY, sizeof(CRCPVERHIS.FACTORY));
		memcpy(CRCPVERHIS.RES_ID, MRCPRCPVER.RES_ID, sizeof(CRCPVERHIS.RES_ID));
		memcpy(CRCPVERHIS.SUBRES_ID, MRCPRCPVER.SUBRES_ID, sizeof(CRCPVERHIS.SUBRES_ID));
		memcpy(CRCPVERHIS.RECIPE, MRCPRCPVER.RECIPE, sizeof(CRCPVERHIS.RECIPE));
		CRCPVERHIS.RECIPE_VERSION = MRCPRCPVER.RECIPE_VERSION;

		CRCPVERHIS.HIST_SEQ = i_hist_seq + 1;

		TRS.copy(CRCPVERHIS.TRAN_USER_ID, sizeof(CRCPVERHIS.TRAN_USER_ID), in_node, IN_USERID);
		memcpy(CRCPVERHIS.TRAN_TIME, s_sys_time, sizeof(CRCPVERHIS.TRAN_TIME));
		CRCPVERHIS.ACTION_FLAG = 'C';	// C:Cretae(Update), D:Delete, S:Select(ReleaseConfirm)
		
		// ÀÌ·ÂÀÌ¹Ç·Î ¹«Á¶°Ç ÀÔ·Â
		CDB_insert_crcpverhis(&CRCPVERHIS);
		if(DB_error_code != DB_SUCCESS)
		{

		}	

		PARAM_LIST = TRS.get_list(in_node, "PARAM_ITEM");
		i_param_list_count = TRS.get_item_count(in_node, "PARAM_ITEM"); // ¸®½ºÆ®¿¡ ¾È¿¡ ÀÖ´Â Ç×¸ñÀÇ ¼ö¸¦ °¡Á®¿È

		for(i = 0; i < i_param_list_count; i++)
		{
			/********************************************************/
			/*	2-4. ·¹½ÃÇÇ ÆÄ¶ó¹ÌÅÍ ¹öÀü ÀÔ·Â (MRCPPRAVER)			*/
			/********************************************************/

			// ÇöÀç µ¥ÀÌÅÍ Á¶È¸
			CDB_init_mrcppraver(&MRCPPRAVER);
			TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, IN_FACTORY);
			//TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
            memcpy(MRCPPRAVER.RES_ID, MRCPRCPDEF.RES_ID, sizeof(MRCPPRAVER.RES_ID));

			TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.SUBRES_ID), in_node, "SUB_RES_ID");
			TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "PP_ID");
			MRCPPRAVER.RECIPE_VERSION = MRCPRCPVER.RECIPE_VERSION;
			TRS.copy(MRCPPRAVER.PARA_ID, sizeof(MRCPPRAVER.PARA_ID),  PARAM_LIST[i], "PARAM_NAME");
			CDB_select_mrcppraver(2, &MRCPPRAVER);
			if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
			{

			}
		
			TRS.copy(MRCPPRAVER.PARA_ID, sizeof(MRCPPRAVER.PARA_ID),  PARAM_LIST[i], "PARAM_NAME");			// ÆÄ¶ó¹ÌÅÍ ¸í
			TRS.copy(MRCPPRAVER.PARA_VALUE, sizeof(MRCPPRAVER.PARA_VALUE),  PARAM_LIST[i], "PARAM_VALUE");	// ÆÄ¶ó¹ÌÅÍ °ª
			TRS.copy(MRCPPRAVER.PARA_DESC, sizeof(MRCPPRAVER.PARA_DESC),  PARAM_LIST[i], "PARAM_DESC");		// ÆÄ¶ó¹ÌÅÍ ¼³¸í
			TRS.copy(MRCPPRAVER.CUS_UNIT, sizeof(MRCPPRAVER.CUS_UNIT),  PARAM_LIST[i], "UNIT");				// ÆÄ¶ó¹ÌÅÍ UNIT
			MRCPPRAVER.CUS_MAX_VAL = TRS.get_double(PARAM_LIST[i], "SPEC_USL");								// ÆÄ¶ó¹ÌÅÍ ÃÖ´ë°ª
			MRCPPRAVER.CUS_MIN_VAL = TRS.get_double(PARAM_LIST[i], "SPEC_LSL");								// ÆÄ¶ó¹ÌÅÍ ÃÖ¼Ò°ª
			TRS.copy(MRCPPRAVER.CUS_CMF1, sizeof(MRCPPRAVER.CUS_CMF1),  PARAM_LIST[i], "ETC");				// ÆÄ¶ó¹ÌÅÍ ETC

			if(DB_error_code == DB_SUCCESS)
			{
				// DB¿¡ Á¤º¸ ÀÖÀ» °æ¿ì UPDATE
				TRS.copy(MRCPPRAVER.UPDATE_USER_ID, sizeof(MRCPPRAVER.UPDATE_USER_ID), in_node, IN_USERID);
				memcpy(MRCPPRAVER.UPDATE_TIME, s_sys_time, sizeof(MRCPPRAVER.UPDATE_TIME));
				CDB_update_mrcppraver(1, &MRCPPRAVER);
				if(DB_error_code != DB_SUCCESS)
				{

				}
			}
			else if(DB_error_code == DB_NOT_FOUND)
			{
				i_para_seq = 0;
				
				// ¸¶Áö¸· ÆÄ¶ó¹ÌÅÍ SEQUENCE Á¶È¸
				CDB_init_mrcppraver(&MRCPPRAVER);
				TRS.copy(MRCPPRAVER.FACTORY, sizeof(MRCPPRAVER.FACTORY), in_node, IN_FACTORY);
				//TRS.copy(MRCPPRAVER.RES_ID, sizeof(MRCPPRAVER.RES_ID), in_node, "RES_ID");
                memcpy(MRCPPRAVER.RES_ID, MRCPRCPDEF.RES_ID, sizeof(MRCPPRAVER.RES_ID));

				TRS.copy(MRCPPRAVER.SUBRES_ID, sizeof(MRCPPRAVER.SUBRES_ID), in_node, "SUB_RES_ID");
				TRS.copy(MRCPPRAVER.RECIPE, sizeof(MRCPPRAVER.RECIPE), in_node, "PP_ID");
				MRCPPRAVER.RECIPE_VERSION = MRCPRCPVER.RECIPE_VERSION;
			    TRS.copy(MRCPPRAVER.PARA_ID, sizeof(MRCPPRAVER.PARA_ID),  PARAM_LIST[i], "PARAM_NAME");			// ÆÄ¶ó¹ÌÅÍ ¸í
			    TRS.copy(MRCPPRAVER.PARA_VALUE, sizeof(MRCPPRAVER.PARA_VALUE),  PARAM_LIST[i], "PARAM_VALUE");	// ÆÄ¶ó¹ÌÅÍ °ª
				i_para_seq = (int) CDB_select_mrcppraver_scalar(3, &MRCPPRAVER);

				//SEQ 중복 문제로 RECIPE 비정상 작동으로 수정 2023.06.01
				MRCPPRAVER.PARA_SEQ = i + 1;
				
				// DB¿¡ Á¤º¸ ¾øÀ» °æ¿ì INSERT
				TRS.copy(MRCPPRAVER.CREATE_USER_ID, sizeof(MRCPPRAVER.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(MRCPPRAVER.CREATE_TIME, s_sys_time, sizeof(MRCPPRAVER.CREATE_TIME));
				CDB_insert_mrcppraver(&MRCPPRAVER);
				if(DB_error_code != DB_SUCCESS)
				{

				}
			}
			
			/********************************************************/
			/*	2-5. ·¹½ÃÇÇ ÆÄ¶ó¹ÌÅÍ ÀÌ·Â ÀÔ·Â (CRCPPRAHIS)			*/
			/********************************************************/

			CDB_init_crcpprahis(&CRCPPRAHIS);
			memcpy(CRCPPRAHIS.FACTORY, MRCPPRAVER.FACTORY, sizeof(CRCPPRAHIS.FACTORY));
			//memcpy(CRCPPRAHIS.RES_ID, MRCPPRAVER.RES_ID, sizeof(CRCPPRAHIS.RES_ID));
            memcpy(CRCPPRAHIS.RES_ID, MRCPRCPDEF.RES_ID, sizeof(CRCPPRAHIS.RES_ID));
			memcpy(CRCPPRAHIS.SUBRES_ID, MRCPPRAVER.SUBRES_ID, sizeof(CRCPPRAHIS.SUBRES_ID));
			memcpy(CRCPPRAHIS.RECIPE, MRCPPRAVER.RECIPE, sizeof(CRCPPRAHIS.RECIPE));
            CRCPPRAHIS.RECIPE_VERSION = MRCPRCPVER.RECIPE_VERSION;
			CRCPPRAHIS.HIST_SEQ = i_hist_seq + 1;
			CRCPPRAHIS.PARA_SEQ = MRCPPRAVER.PARA_SEQ;
		
			TRS.copy(CRCPPRAHIS.TRAN_USER_ID, sizeof(CRCPPRAHIS.TRAN_USER_ID), in_node, IN_USERID);
			memcpy(CRCPPRAHIS.TRAN_TIME, s_sys_time, sizeof(CRCPPRAHIS.TRAN_TIME));
		
			memcpy(CRCPPRAHIS.PARA_ID, MRCPPRAVER.PARA_ID, sizeof(CRCPPRAHIS.PARA_ID));				// ÆÄ¶ó¹ÌÅÍ ¸í
			memcpy(CRCPPRAHIS.PARA_VALUE, MRCPPRAVER.PARA_VALUE, sizeof(CRCPPRAHIS.PARA_VALUE));	// ÆÄ¶ó¹ÌÅÍ °ª
			memcpy(CRCPPRAHIS.PARA_DESC, MRCPPRAVER.PARA_DESC, sizeof(CRCPPRAHIS.PARA_DESC));		// ÆÄ¶ó¹ÌÅÍ ¼³¸í
			memcpy(CRCPPRAHIS.CUS_UNIT, MRCPPRAVER.PARA_ID, sizeof(CRCPPRAHIS.CUS_UNIT));			// ÆÄ¶ó¹ÌÅÍ UNIT
			CRCPPRAHIS.CUS_MAX_VAL = MRCPPRAVER.CUS_MAX_VAL;										// ÆÄ¶ó¹ÌÅÍ ÃÖ´ë°ª
			CRCPPRAHIS.CUS_MIN_VAL = MRCPPRAVER.CUS_MIN_VAL;										// ÆÄ¶ó¹ÌÅÍ ÃÖ¼Ò°ª
			memcpy(CRCPPRAHIS.ETC, MRCPPRAVER.CUS_CMF1, sizeof(CRCPPRAHIS.ETC));					// ÆÄ¶ó¹ÌÅÍ ETC

			// ÀÌ·ÂÀÌ¹Ç·Î ¹«Á¶°Ç ÀÔ·Â
			CDB_insert_crcpprahis(&CRCPPRAHIS);
			if(DB_error_code != DB_SUCCESS)
			{

			}
		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    EAPMES_Update_Recipe_Validation()
        - Main sub function of "EAPMES_UPDATE_RECIPE" function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Update_Recipe_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)	// ¸¶Áö¸·¿¡ "1"ÀÎ °æ¿ì procstep°ªÀÌ 1ÀÎÁö È®ÀÎ , "12" ÀÏ°æ¿ì 1 ¶Ç´Â 2, "123"ÀÏ °æ¿ì 1 ¶Ç´Â 2 ¶Ç´Â 3
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
