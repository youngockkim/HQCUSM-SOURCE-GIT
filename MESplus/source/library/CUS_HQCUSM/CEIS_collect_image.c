/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_collect_image.c
    Description : EAPMES Collect Cell ID Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Collect_Image()
            + Image Save
        
    Detail Description
        - EAPMES_COLLECT_IMAGE()
            + h_proc_step
                + MP_STEP_CREATE : Create case
                + MP_STEP_UPDATE : Update case
                + MP_STEP_DELETE : Delete case

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2019/02/26  Juhyeon           Created

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"
int EAPMES_COLLECT_IMAGE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/*******************************************************************************
    EAPMES_Collect_Image()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Collect_Image(TRSNode *in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100]; 
    int i_ret;
    TRSNode *out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_COLLECT_IMAGE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_COLLECT_IMAGE", out_node);

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
	TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
	TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
	TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* MES to EAP */
	memset(s_channel, 0x00, sizeof(s_channel));
	sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
	//strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
	COM_add_null(s_channel, sizeof(s_channel));
    
	if(CallService(MODULE_EAP, 
		"EAPMES_Collect_Image", 
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
    //CEIS_Save_Message_Log(in_node, out_node);
    CEIS_Save_Message_Log_For_List(in_node, out_node);


	TRS.free_node(out_node);

    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_COLLECT_IMAGE()
        - Main sub function of "EAPMES_Collect_Image" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_COLLECT_IMAGE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPELTHIS_TAG MWIPELTHIS;
	struct MRASRESDEF_TAG MRASRESDEF;

	// IS-21-08-049 [후단 AOI 이미지 백업] 구축
	struct CWIPLOTIMG_TAG CWIPLOTIMG;
    struct CWIPLOTIMG_TAG CWIPLOTIMG_o;
	char c_dataflag = 'N';

	// IS-21-08-049 [후단 AOI 이미지 백업] 구축
    char   s_sys_time[14];

    LOG_head("EAPMES_COLLECT_IMAGE");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// IS-21-08-049 [후단 AOI 이미지 백업] 구축
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
	//0. 설비 ID GET
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

	
    /* get material ID and  operation */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0044");
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.e_type = MP_LOG_E_SYSTEM;
        }

        TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	//MWIPELTSTS & MWIPELTHIS CREATE
	CDB_init_mwipeltsts(&MWIPELTSTS);
	TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwipeltsts(1, &MWIPELTSTS);
	if(DB_error_code != DB_SUCCESS)
    {
		MWIPELTSTS.HIST_SEQ = 1;
		memcpy(MWIPELTSTS.CURING_TIME, MWIPLOTSTS.CREATE_TIME, sizeof(MWIPELTSTS.CURING_TIME)) ;//파티션키로 사용하고 있으므로 업데이트 금지
		CDB_insert_mwipeltsts(&MWIPELTSTS);
	}

	if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
	{
		if (memcmp(MRASRESDEF.RES_CMF_6, HQCEL_RES_CATEGORY_REPAIR_EL, strlen(HQCEL_RES_CATEGORY_REPAIR_EL)) == 0)
		{
			//EL1 FRONT EL OPER 인데 REPAIR EL 이면  EL_IMAGE_PATCH1 에 저장
			memset(MWIPELTSTS.EL_IMAGE_PATH2, ' ', sizeof(MWIPELTSTS.EL_IMAGE_PATH2));
			TRS.copy(MWIPELTSTS.EL_IMAGE_PATH2, sizeof(MWIPELTSTS.EL_IMAGE_PATH2), in_node, "IMG_PATH");
		}
		else
		{
			
			//EL1 FRONT EL OPER 이면 EL_IMAGE_PATCH 에 저장
			memset(MWIPELTSTS.EL_IMAGE_PATH, ' ', sizeof(MWIPELTSTS.EL_IMAGE_PATH));
			TRS.copy(MWIPELTSTS.EL_IMAGE_PATH, sizeof(MWIPELTSTS.EL_IMAGE_PATH), in_node, "IMG_PATH");
		}
		c_dataflag = 'Y';
		
	}
	else if  (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
	{
		//EL3 FRONT EL OPER 이면 EL_IMAGE_PATCH3 에 저장
		c_dataflag = 'Y';
		memset(MWIPELTSTS.EL_IMAGE_PATH3, ' ', sizeof(MWIPELTSTS.EL_IMAGE_PATH3));
		TRS.copy(MWIPELTSTS.EL_IMAGE_PATH3, sizeof(MWIPELTSTS.EL_IMAGE_PATH3), in_node, "IMG_PATH");
	}
	// IS-21-08-049 [후단 AOI 이미지 백업] 구축
	else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_AOI_OPER, strlen(HQCEL_M1_AOI_OPER)) == 0)
	{
		CDB_init_cwiplotimg(&CWIPLOTIMG);
        TRS.copy(CWIPLOTIMG.FACTORY, sizeof(CWIPLOTIMG.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CWIPLOTIMG.LOT_ID, sizeof(CWIPLOTIMG.LOT_ID), in_node, "LOT_ID");
		memcpy(CWIPLOTIMG.IMAGE_TYPE, "AOI", strlen("AOI"));
        CDB_select_cwiplotimg_for_update(1, &CWIPLOTIMG);
        if(DB_error_code != DB_SUCCESS)
        {
			TRS.copy(CWIPLOTIMG.IMAGE_PATH, sizeof(CWIPLOTIMG.IMAGE_PATH), in_node, "IMG_PATH");
			TRS.copy(CWIPLOTIMG.CREATE_USER_ID, sizeof(CWIPLOTIMG.CREATE_USER_ID), in_node, IN_USERID);
			memcpy(CWIPLOTIMG.CREATE_TIME, s_sys_time, sizeof(CWIPLOTIMG.CREATE_TIME));
			CDB_insert_cwiplotimg(&CWIPLOTIMG);
			if(DB_error_code != DB_SUCCESS)
			{
			}
		}
		else
		{
			TRS.copy(CWIPLOTIMG.IMAGE_PATH, sizeof(CWIPLOTIMG.IMAGE_PATH), in_node, "IMG_PATH");
			TRS.copy(CWIPLOTIMG.UPDATE_USER_ID, sizeof(CWIPLOTIMG.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(CWIPLOTIMG.UPDATE_TIME, s_sys_time, sizeof(CWIPLOTIMG.UPDATE_TIME));
			CDB_update_cwiplotimg(1, &CWIPLOTIMG);
			if(DB_error_code != DB_SUCCESS)
			{
			}
		}
	}

	if ( c_dataflag == 'Y')
	{
		//STATUS UPDATE
		MWIPELTSTS.HIST_SEQ++;
		CDB_update_mwipeltsts(1, &MWIPELTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		//HISORY SEQUENCE
		CDB_init_mwipelthis(&MWIPELTHIS);
		memcpy(MWIPELTHIS.LOT_ID, MWIPELTSTS.LOT_ID, sizeof(struct MWIPELTSTS_TAG));
		CDB_insert_mwipelthis(&MWIPELTHIS);	
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 
