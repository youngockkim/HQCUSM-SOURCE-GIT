/******************************************************************************'

    System      : MESplus
    Module      : CEIS
    File Name   : CEIS_validate_lot_label_e23.c
    Description : EAPMES Validate Lot Label Service

    MES Version : 5.3.4 ~

    Function List
        - EAPMES_Validate_Lot_Label_E23()
            + Setup service interface function
        - EAPMES_VALIDATE_LOT_LABEL_E23()
            + Main sub function of EAPMES_Validate_Lot_Label_E23 function
            + Setup service main business function
        - EAPMES_Validate_Lot_Label_E23_Validation()
            + Main sub function of EAPMES_VALIDATE_LOT_LABEL_E23 function
    Detail Description
        - EAPMES_VALIDATE_LOT_LABEL_E23()
            + h_proc_step

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/02/26  Albert Kim     Created

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int EAPMES_Validate_Lot_Label_E23_Validation(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);

/*******************************************************************************
    EAPMES_Validate_Lot_Label_E23()
        - Setup service interface function
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Lot_Label_E23(TRSNode* in_node)
{
    char s_msg_code[MP_SIZE_MSG];
    char s_channel[100];
    struct MGCMLAGDAT_TAG MGCMLAGDAT;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
    int i_ret;
    TRSNode* out_node;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    out_node = TRS.create_node("OUT_NODE");

    i_ret = EAPMES_VALIDATE_LOT_LABEL_E23(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "EAPMES_VALIDATE_LOT_LABEL_E23", out_node);

    if (i_ret == MP_TRUE)
    {
        DB_commit();
        TRS.set_nstring(in_node, "RESULT_VALUE", "OK");
    }
    else
    {
        TRS.set_nstring(in_node, "RESULT_VALUE", "NG");
        DB_rollback();
    }
    /* Save Message Code */
    TRS.set_string(out_node, "ORG_MSG_ID", s_msg_code, 8);


    // 결과 저장
    if (EAPMES_Validate_Lot_Label_Save_Result(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        // Do Nothing
    }
    DB_commit();


   /* 특정 에러처리를 무시할경우 사용 ERROR  */
    //VALIDATION 하라고 셋팅된 에러만 에러처리함.
    DBC_init_mgcmtbldat(&MGCMTBLDAT);
    TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
    memcpy(MGCMTBLDAT.TABLE_NAME, "@BLA_OPTION", strlen("@BLA_OPTION"));
    memcpy(MGCMTBLDAT.KEY_1, "CHECK", strlen("CHECK"));
    TRS.copy(MGCMTBLDAT.KEY_2, sizeof(MGCMTBLDAT.KEY_2), in_node, "LINE_ID");        //E1, E23 구분하여 처리하기 위해 추가 2023.10.11 YG SON
    DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
    if (DB_error_code == DB_SUCCESS)
    {
        if (MGCMTBLDAT.DATA_2[0] != 'Y')
        {
            TRS.set_nstring(in_node, "RESULT_VALUE", "OK");
            COM_set_result(out_node, MP_SUCCESS_C, s_msg_code, MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
        }
    }

    /* Common Data */
    CCOM_copy_in_node(in_node, out_node);
    TRS.set_nstring(out_node, "IN_SERVICE_NAME", TRS.get_string(in_node, MSG_SERVICE_NAME));
    TRS.add_char(out_node, "PROCSTEP", TRS.get_procstep(in_node));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));
    TRS.set_nstring(out_node, "CIM_ID", TRS.get_string(in_node, "CIM_ID"));
    TRS.set_nstring(out_node, "MSG_NO", TRS.get_string(in_node, "MSG_NO"));
    TRS.set_nstring(out_node, "LINE_ID", TRS.get_string(in_node, "LINE_ID"));
    TRS.set_nstring(out_node, "RES_ID", TRS.get_string(in_node, "RES_ID"));

    /* Additional Data */
    TRS.set_nstring(out_node, "LOT_ID", TRS.get_string(in_node, "LOT_ID"));
    TRS.set_nstring(out_node, "ORDER_ID", TRS.get_string(in_node, "ORDER_ID"));
    
    TRS.set_nstring(out_node, "RESULT_VALUE", TRS.get_string(in_node, "RESULT_VALUE"));
    TRS.set_nstring(out_node, "COMMENT", TRS.get_string(in_node, "__COMMENT"));
    

    LOG_head("EAPMES_VALIDATE_LOT_LABEL_E23 (out_node)");
    TRS.log_add_all_members(out_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    /* MES to EAP */
    memset(s_channel, 0x00, sizeof(s_channel));
    sprintf(s_channel, "/%.*s/EAP/", 4, gs_site_id);
    //strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "RES_ID"));
    strcpy(s_channel + strlen(s_channel), TRS.get_string(in_node, "CIM_ID"));
    COM_add_null(s_channel, sizeof(s_channel));

    if (CallService(MODULE_EAP,
        "MESEAP_Validate_Lot_Label_E23",
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
    EAPMES_VALIDATE_LOT_LABEL_E23()
        - Main sub function of "EAPMES_Validate_Lot_Label_E23" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_VALIDATE_LOT_LABEL_E23(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MGCMLAGDAT_TAG MGCMLAGDAT;
    struct MGCMLAGDAT_TAG MGCMLAGDAT_2;
    struct MWIPELTSTS_TAG MWIPELTSTS;
    struct MWIPMATDEF_TAG MWIPMATDEF;    //24.10.24
    struct CRASPRCDAT_TAG CRASPRCDAT;
    struct MRASRESDEF_TAG MRASRESDEF;

    int i_param_list_count;
    int i_param_item_count;
    int i, j;

    double d_max_seq_num;

    char s_sys_time_stamp[20];
    char s_sys_time[17];

    TRSNode** PARAM_LIST;
    TRSNode** PARAM_ITEM;

    int i_start;

    char s_product_name[300];
    char s_product_name_chg[300];
    char s_pmpp[20];
    
    
    LOG_head("EAPMES_VALIDATE_LOT_LABEL_E23");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    memset(s_sys_time_stamp, ' ', sizeof(s_sys_time_stamp));

    DB_get_systime_m(s_sys_time_stamp);
    if (DB_error_code != DB_SUCCESS)
    {
        TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    memset(s_sys_time, ' ', sizeof(s_sys_time));
    memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));


    if (EAPMES_Validate_Lot_Label_E23_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    
    /* Validate the Lot ID */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0044");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    //0. 설비 ID GET
    DBC_init_mrasresdef(&MRASRESDEF);
    TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
    TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
    DBC_select_mrasresdef(1, &MRASRESDEF);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
    MWIPMATDEF.MAT_VER = MWIPLOTSTS.MAT_VER;
    DBC_select_mwipmatdef(1, &MWIPMATDEF);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0006");
            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
        }
        TRS.add_fieldmsg(out_node, "MWIPMATDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPMATDEF.FACTORY), MWIPMATDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(MWIPMATDEF.MAT_ID), MWIPMATDEF.MAT_ID);
        TRS.add_fieldmsg(out_node, "MAT_VER", MP_INT, MWIPMATDEF.MAT_VER);

        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "MWIPMATDEF");


        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Save All Parameter Data */
    PARAM_LIST = TRS.get_list(in_node, "PARAM_LIST");
    i_param_list_count = TRS.get_item_count(in_node, "PARAM_LIST");


    for (i = 0; i < i_param_list_count; i++)
    {
        PARAM_ITEM = TRS.get_list(PARAM_LIST[i], "PARAM_ITEM");
        i_param_item_count = TRS.get_item_count(PARAM_LIST[i], "PARAM_ITEM");

        for (j = 0; j < i_param_item_count; j++)
        {
            if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "MODULE_NAME") == 0)
            {
                TRS.set_nstring(in_node, "MODULE_NAME", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "STC_PMPP") == 0)
            {
                TRS.set_nstring(in_node, "STC_PMPP", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "STC_ISC") == 0)
            {
                TRS.set_nstring(in_node, "STC_ISC", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "STC_VOC") == 0)
            {
                TRS.set_nstring(in_node, "STC_VOC", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "STC_IMPP") == 0)
            {
                TRS.set_nstring(in_node, "STC_IMPP", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "STC_VMPP") == 0)
            {
                TRS.set_nstring(in_node, "STC_VMPP", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "BSTC_PMPP") == 0)
            {
                TRS.set_nstring(in_node, "BSTC_PMPP", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "BSTC_ISC") == 0)
            {
                TRS.set_nstring(in_node, "BSTC_ISC", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "BSTC_VOC") == 0)
            {
                TRS.set_nstring(in_node, "BSTC_VOC", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "BSTC_IMPP") == 0)
            {
                TRS.set_nstring(in_node, "BSTC_IMPP", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "BSTC_VMPP") == 0)
            {
                TRS.set_nstring(in_node, "BSTC_VMPP", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "VSS_IEC") == 0)
            {
                TRS.set_nstring(in_node, "VSS_IEC", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "VSS_UL") == 0)
            {
                TRS.set_nstring(in_node, "VSS_UL", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
            else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "WEIGHT") == 0)
            {
                TRS.set_nstring(in_node, "WEIGHT", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
			//25.07.03 Model Check - Start
			 else if (TRS.str_cmp(PARAM_ITEM[j], "PARAM_NAME", "MODEL_NAME") == 0)
            {
                TRS.set_nstring(in_node, "MODEL_NAME", TRS.get_string(PARAM_ITEM[j], "PARAM_VALUE"));
            }
			//25.07.03 Model Check - End


            /* Get Max Sequence */
            d_max_seq_num = 0;
            CDB_init_crasprcdat(&CRASPRCDAT);
            TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "STRING_ID");
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
            memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
            //TRS.copy(CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.TRAN_TIME), in_node, "CLIENT_TIME");
            TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            d_max_seq_num = CDB_select_crasprcdat_scalar(2, &CRASPRCDAT);
            if (DB_error_code != DB_SUCCESS)
            {
                //return MP_TRUE;
            }

            /* Insert */
            CDB_init_crasprcdat(&CRASPRCDAT);
            TRS.copy(CRASPRCDAT.LOT_ID, sizeof(CRASPRCDAT.LOT_ID), in_node, "LOT_ID");
            TRS.copy(CRASPRCDAT.RES_ID, sizeof(CRASPRCDAT.RES_ID), in_node, "RES_ID");
            memcpy(CRASPRCDAT.TRAN_TIME, s_sys_time, sizeof(s_sys_time));
            //TRS.copy(CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.TRAN_TIME), in_node, "CLIENT_TIME");
            CRASPRCDAT.SEQ_NUM = (int)++d_max_seq_num; //형변환 2023-07-04
            TRS.copy(CRASPRCDAT.FACTORY, sizeof(CRASPRCDAT.FACTORY), in_node, IN_FACTORY);
            TRS.copy(CRASPRCDAT.LINE_ID, sizeof(CRASPRCDAT.LINE_ID), in_node, "LINE_ID");
            memcpy(CRASPRCDAT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CRASPRCDAT.OPER));
            CRASPRCDAT.LOT_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;

            TRS.copy(CRASPRCDAT.PARAM_NAME, sizeof(CRASPRCDAT.PARAM_NAME), PARAM_ITEM[j], "PARAM_NAME");
            TRS.copy(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE), PARAM_ITEM[j], "PARAM_VALUE");
            memcpy(CRASPRCDAT.CREATE_TIME, CRASPRCDAT.TRAN_TIME, sizeof(CRASPRCDAT.CREATE_TIME));

            //값이 없으면 저장안함. 데이터가 너무많음.
            if (COM_isspace(CRASPRCDAT.PARAM_VALUE, sizeof(CRASPRCDAT.PARAM_VALUE)) == MP_TRUE)
            {
                continue;
            }
            

            //CEDCLOTDAT INSERT: 레포트에서 설비데이터 조회용 
            if (CCOM_COPY_FROM_PRCDATA_TO_LOTDATA(in_node, &CRASPRCDAT) == MP_FALSE)
            {
                //DO NOTHING
            }
        }
    }


    // LABEL DATA SAVE
    DB_commit();

    TRS.set_nstring(in_node, "__COMMENT", "This service is successful.");

    // LOT Validation 2
    CDB_init_mwipeltsts(&MWIPELTSTS);
    TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
    CDB_select_mwipeltsts(2, &MWIPELTSTS);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0573");
            TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);

            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "MWIPELTSTS");

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        else
        {
            strcpy(s_msg_code, "EDC-0004");
            TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "MWIPELTSTS");

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }	
	/*[25.05.29]BLA설비 라벨 벨리데이션 로직 추가  - START	*/
	//*임시로 4라인만 반영//
	//if ((memcmp("MDL06", TRS.get_string(in_node, "LINE_ID"), strlen(TRS.get_string(in_node, "LINE_ID"))) == 0))
	//{

		/* Select Power Grade */
		CDB_init_mgcmlagdat(&MGCMLAGDAT);
		TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_POWER_RANGE, strlen(HQCEL_M1_GCM_POWER_RANGE));
		memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		memcpy(MGCMLAGDAT.KEY_2, "G01", 3);
		memcpy(MGCMLAGDAT.DATA_2, MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));

		CDB_select_mgcmlagdat(4, &MGCMLAGDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "GCM-0034");
				TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
				TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MGCMLAGDAT.KEY_3), MGCMLAGDAT.KEY_3);

				TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
				TRS.set_nstring(in_node, "__RESULT", "NG");
				TRS.set_nstring(in_node, "__PARAM_NAME", "NO_DATA");

				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "GCM-0007");
				TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
				TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
				TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
				TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MGCMLAGDAT.KEY_3), MGCMLAGDAT.KEY_3);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
				TRS.set_nstring(in_node, "__RESULT", "NG");
				TRS.set_nstring(in_node, "__PARAM_NAME", "NO_DATA");

				return MP_FALSE;
			}
		}
		else
		{
			if ((memcmp(MGCMLAGDAT.DATA_1, TRS.get_string(in_node, "STC_PMPP"), strlen(TRS.get_string(in_node, "STC_PMPP"))) != 0))
			{
				strcpy(s_msg_code, "WIP-0654"); //The Label Information does not match.
				TRS.add_fieldmsg(out_node, "STC_PMPP", MP_NSTR, TRS.get_string(in_node, "STC_PMPP"));
				TRS.add_fieldmsg(out_node, "GCM", MP_NSTR, MGCMLAGDAT.DATA_1);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_VALIDATION;
				gs_log_type.category = MP_LOG_CATE_SETUP;
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
				TRS.set_nstring(in_node, "__RESULT", "NG");
				TRS.set_nstring(in_node, "__PARAM_NAME", "STC_PMPP");
				return MP_FALSE;

			}

		}
	//}
	/*[25.05.29]BLA설비 라벨 벨리데이션 로직 추가  - END	*/


    CDB_init_mgcmlagdat(&MGCMLAGDAT);
    TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, IN_FACTORY);
    memcpy(MGCMLAGDAT.TABLE_NAME, "@LABEL", strlen("@LABEL"));
    memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    memcpy(MGCMLAGDAT.KEY_2, "G01", strlen("G01")); // -- 인라인에서는 G01 라벨 부착
    TRS.copy(MGCMLAGDAT.KEY_3, sizeof(MGCMLAGDAT.KEY_3), in_node, "STC_PMPP");
    CDB_select_mgcmlagdat(9, &MGCMLAGDAT);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "GCM-0034");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
            TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MGCMLAGDAT.KEY_3), MGCMLAGDAT.KEY_3);

            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "NO_DATA");

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        else
        {
            strcpy(s_msg_code, "GCM-0007");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
            TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MGCMLAGDAT.KEY_3), MGCMLAGDAT.KEY_3);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "NO_DATA");

            return MP_FALSE;
        }
    }


    CDB_init_mgcmlagdat(&MGCMLAGDAT_2);
    TRS.copy(MGCMLAGDAT_2.FACTORY, sizeof(MGCMLAGDAT_2.FACTORY), in_node, IN_FACTORY);
    memcpy(MGCMLAGDAT_2.TABLE_NAME, "@LABEL_2", strlen("@LABEL_2"));
    memcpy(MGCMLAGDAT_2.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    memcpy(MGCMLAGDAT_2.KEY_2, "G01", strlen("G01")); // -- 인라인에서는 G01 라벨 부착
    TRS.copy(MGCMLAGDAT_2.KEY_3, sizeof(MGCMLAGDAT_2.KEY_3), in_node, "STC_PMPP");

    CDB_select_mgcmlagdat(9, &MGCMLAGDAT_2);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            TRS.set_char(in_node, "__NO_BSTC_FLAG", 'Y');
        }
        else
        {
            strcpy(s_msg_code, "GCM-0007");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT_2.FACTORY), MGCMLAGDAT_2.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT_2.TABLE_NAME), MGCMLAGDAT_2.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(MGCMLAGDAT_2.KEY_1), MGCMLAGDAT_2.KEY_1);
            TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MGCMLAGDAT_2.KEY_3), MGCMLAGDAT_2.KEY_3);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

           

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            
            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "NO_DATA");
            return MP_FALSE;
        }
    }
    else
    {
        TRS.set_char(in_node, "__NO_BSTC_FLAG", 'N');
        TRS.set_string(in_node, "TABLE_BSTC_PMPP", MGCMLAGDAT_2.DATA_2, sizeof(MGCMLAGDAT_2.DATA_2));
        TRS.set_string(in_node, "TABLE_BSTC_ISC", MGCMLAGDAT_2.DATA_3, sizeof(MGCMLAGDAT_2.DATA_3));
        TRS.set_string(in_node, "TABLE_BSTC_VOC", MGCMLAGDAT_2.DATA_4, sizeof(MGCMLAGDAT_2.DATA_4));
        TRS.set_string(in_node, "TABLE_BSTC_IMPP", MGCMLAGDAT_2.DATA_5, sizeof(MGCMLAGDAT_2.DATA_5));
        TRS.set_string(in_node, "TABLE_BSTC_VMPP", MGCMLAGDAT_2.DATA_6, sizeof(MGCMLAGDAT_2.DATA_6));
    }
    
    
    COM_memcpy_add_null(s_product_name, MGCMLAGDAT.DATA_1, sizeof(s_product_name));
    COM_memcpy_add_null(s_pmpp, MGCMLAGDAT.DATA_2, sizeof(s_pmpp));

    memset(s_product_name_chg, '\0', sizeof(s_product_name_chg));
    memcpy(s_product_name_chg, s_product_name, strlen(s_product_name) - strlen(s_pmpp));

    TRS.set_nstring(in_node, "__RESULT", "OK");

    TRS.set_string(in_node, "TABLE_VSS_IEC", MGCMLAGDAT.DATA_8, sizeof(MGCMLAGDAT.DATA_8));
    TRS.set_string(in_node, "TABLE_VSS_UL", MGCMLAGDAT.DATA_10, sizeof(MGCMLAGDAT.DATA_10));
    TRS.set_string(in_node, "TABLE_WEIGHT", MGCMLAGDAT.DATA_9, sizeof(MGCMLAGDAT.DATA_9));




    TRS.set_string(in_node, "TABLE_MODEL_NAME", s_product_name_chg, sizeof(s_product_name_chg));
    TRS.set_string(in_node, "TABLE_STC_PMPP", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));
    TRS.set_string(in_node, "TABLE_STC_ISC", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));
    TRS.set_string(in_node, "TABLE_STC_VOC", MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));
    TRS.set_string(in_node, "TABLE_STC_IMPP", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));
    TRS.set_string(in_node, "TABLE_STC_VMPP", MGCMLAGDAT.DATA_6, sizeof(MGCMLAGDAT.DATA_6));

	//25.07.03 Model Check - Start
	if (TRS.str_cmp(in_node, "MODEL_NAME", TRS.get_string(in_node, "TABLE_MODEL_NAME")) != 0)
    {

        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "MODEL_NAME", MP_NSTR, TRS.get_string(in_node, "MODEL_NAME"));
        TRS.add_fieldmsg(out_node, "TABLE_MODEL_NAME", MP_NSTR, TRS.get_string(in_node, "TABLE_MODEL_NAME"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "MODEL_NAME");
        return MP_FALSE;
    }
	//25.07.03 Model Check - End

    if (TRS.str_cmp(in_node, "STC_PMPP", TRS.get_string(in_node, "TABLE_STC_PMPP")) != 0)
    {

        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "STC_PMPP", MP_NSTR, TRS.get_string(in_node, "STC_PMPP"));
        TRS.add_fieldmsg(out_node, "TABLE_STC_PMPP", MP_NSTR, TRS.get_string(in_node, "TABLE_STC_PMPP"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "STC_PMPP");
        return MP_FALSE;
    }

    if (TRS.str_cmp(in_node, "STC_ISC", TRS.get_string(in_node, "TABLE_STC_ISC")) != 0)
    {
        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "STC_ISC", MP_NSTR, TRS.get_string(in_node, "STC_ISC"));
        TRS.add_fieldmsg(out_node, "TABLE_STC_ISC", MP_NSTR, TRS.get_string(in_node, "TABLE_STC_ISC"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "STC_ISC");


        return MP_FALSE;
    }

    if (TRS.str_cmp(in_node, "STC_VOC", TRS.get_string(in_node, "TABLE_STC_VOC")) != 0)
    {
        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "STC_VOC", MP_NSTR, TRS.get_string(in_node, "STC_VOC"));
        TRS.add_fieldmsg(out_node, "TABLE_STC_VOC", MP_NSTR, TRS.get_string(in_node, "TABLE_STC_VOC"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "STC_VOC");
        return MP_FALSE;
    }

    if (TRS.str_cmp(in_node, "STC_IMPP", TRS.get_string(in_node, "TABLE_STC_IMPP")) != 0)
    {
        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "STC_IMPP", MP_NSTR, TRS.get_string(in_node, "STC_IMPP"));
        TRS.add_fieldmsg(out_node, "TABLE_STC_IMPP", MP_NSTR, TRS.get_string(in_node, "TABLE_STC_IMPP"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "STC_IMPP");

        return MP_FALSE;
    }

    if (TRS.str_cmp(in_node, "STC_VMPP", TRS.get_string(in_node, "TABLE_STC_VMPP")) != 0)
    {
        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "STC_VMPP", MP_NSTR, TRS.get_string(in_node, "STC_VMPP"));
        TRS.add_fieldmsg(out_node, "TABLE_STC_VMPP", MP_NSTR, TRS.get_string(in_node, "TABLE_STC_VMPP"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "STC_VMPP");
        return MP_FALSE;
    }




    if (COM_isnullspace(TRS.get_string(in_node, "TABLE_VSS_IEC")) == MP_FALSE
        && TRS.str_cmp(in_node, "VSS_IEC", TRS.get_string(in_node, "TABLE_VSS_IEC")) != 0)
    {
        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "VSS_IEC", MP_NSTR, TRS.get_string(in_node, "VSS_IEC"));
        TRS.add_fieldmsg(out_node, "TABLE_VSS_IEC", MP_NSTR, TRS.get_string(in_node, "TABLE_VSS_IEC"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "VSS_IEC");
        return MP_FALSE;
    }

    if (COM_isnullspace(TRS.get_string(in_node, "TABLE_VSS_UL")) == MP_FALSE
        && TRS.str_cmp(in_node, "VSS_UL", TRS.get_string(in_node, "TABLE_VSS_UL")) != 0)
    {
        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "VSS_UL", MP_NSTR, TRS.get_string(in_node, "VSS_UL"));
        TRS.add_fieldmsg(out_node, "TABLE_VSS_UL", MP_NSTR, TRS.get_string(in_node, "TABLE_VSS_UL"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "VSS_UL");
        return MP_FALSE;
    }

    if (COM_isnullspace(TRS.get_string(in_node, "TABLE_WEIGHT")) == MP_FALSE
        && TRS.str_cmp(in_node, "WEIGHT", TRS.get_string(in_node, "TABLE_WEIGHT")) != 0)
    {
        strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
        TRS.add_fieldmsg(out_node, "WEIGHT", MP_NSTR, TRS.get_string(in_node, "WEIGHT"));
        TRS.add_fieldmsg(out_node, "TABLE_WEIGHT", MP_NSTR, TRS.get_string(in_node, "TABLE_WEIGHT"));

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
        TRS.set_nstring(in_node, "__RESULT", "NG");
        TRS.set_nstring(in_node, "__PARAM_NAME", "WEIGHT");
        return MP_FALSE;
    }



    if (TRS.get_char(in_node, "__NO_BSTC_FLAG") == 'N')
    {

        if (TRS.str_cmp(in_node, "BSTC_PMPP", TRS.get_string(in_node, "TABLE_BSTC_PMPP")) != 0)
        {
            strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
            TRS.add_fieldmsg(out_node, "BSTC_PMPP", MP_NSTR, TRS.get_string(in_node, "BSTC_PMPP"));
            TRS.add_fieldmsg(out_node, "TABLE_BSTC_PMPP", MP_NSTR, TRS.get_string(in_node, "TABLE_BSTC_PMPP"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "BSTC_PMPP");
            return MP_FALSE;
        }


        if (TRS.str_cmp(in_node, "BSTC_ISC", TRS.get_string(in_node, "TABLE_BSTC_ISC")) != 0)
        {
            strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
            TRS.add_fieldmsg(out_node, "BSTC_ISC", MP_NSTR, TRS.get_string(in_node, "BSTC_ISC"));
            TRS.add_fieldmsg(out_node, "TABLE_BSTC_ISC", MP_NSTR, TRS.get_string(in_node, "TABLE_BSTC_ISC"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "BSTC_ISC");
            return MP_FALSE;
        }

        if (TRS.str_cmp(in_node, "BSTC_VOC", TRS.get_string(in_node, "TABLE_BSTC_VOC")) != 0)
        {
            strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
            TRS.add_fieldmsg(out_node, "BSTC_VOC", MP_NSTR, TRS.get_string(in_node, "BSTC_VOC"));
            TRS.add_fieldmsg(out_node, "TABLE_BSTC_VOC", MP_NSTR, TRS.get_string(in_node, "TABLE_BSTC_VOC"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "BSTC_VOC");
            return MP_FALSE;
        }

        if (TRS.str_cmp(in_node, "BSTC_IMPP", TRS.get_string(in_node, "TABLE_BSTC_IMPP")) != 0)
        {
            strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
            TRS.add_fieldmsg(out_node, "BSTC_IMPP", MP_NSTR, TRS.get_string(in_node, "BSTC_IMPP"));
            TRS.add_fieldmsg(out_node, "TABLE_BSTC_IMPP", MP_NSTR, TRS.get_string(in_node, "TABLE_BSTC_IMPP"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "BSTC_IMPP");
            return MP_FALSE;
        }

        if (TRS.str_cmp(in_node, "BSTC_VMPP", TRS.get_string(in_node, "TABLE_BSTC_VMPP")) != 0)
        {
            strcpy(s_msg_code, "WIP-0654"); //Power Label Printer Validation NG.
            TRS.add_fieldmsg(out_node, "BSTC_VMPP", MP_NSTR, TRS.get_string(in_node, "BSTC_VMPP"));
            TRS.add_fieldmsg(out_node, "TABLE_BSTC_VMPP", MP_NSTR, TRS.get_string(in_node, "TABLE_BSTC_VMPP"));

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_VALIDATION;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            TRS.set_nstring(in_node, "__COMMENT", "Power Label Printer Validation NG");
            TRS.set_nstring(in_node, "__RESULT", "NG");
            TRS.set_nstring(in_node, "__PARAM_NAME", "BSTC_VMPP");
            return MP_FALSE;
        }
    }


    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
}

/*******************************************************************************
    EAPMES_Validate_Lot_Label_E23_Validation()
        - Main sub function of "EAPMES_VALIDATE_LOT_LABEL_E23" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Lot_Label_E23_Validation(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if (COM_service_validation(s_msg_code,
        in_node,
        out_node,
        TRS.get_procstep(in_node),
        "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if (COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
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
    if (DB_error_code != DB_SUCCESS)
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
    EAPMES_Validate_Lot_Label_E23_Validation()
        - Main sub function of "EAPMES_VALIDATE_LOT_LABEL_E23" function
        - Check the condition for create/update/delete
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int EAPMES_Validate_Lot_Label_Save_Result(char* s_msg_code, TRSNode* in_node, TRSNode* out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;
    struct CEDCLOTRLT_TAG CEDCLOTRLT;
    struct CEDCLOTRLH_TAG CEDCLOTRLH;
    struct MRASRESDEF_TAG MRASRESDEF;
    struct MWIPLOTSTS_TAG MWIPLOTSTS;

    char s_sys_time[14];

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

    //0. 설비 ID GET
    DBC_init_mrasresdef(&MRASRESDEF);
    TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
    TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
    DBC_select_mrasresdef(1, &MRASRESDEF);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "RAS-0003");
        TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

        gs_log_type.e_type = MP_LOG_E_EXISTENCE;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* Validate the Lot ID */
    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            strcpy(s_msg_code, "WIP-0044");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

            gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

    TRS.set_nstring(in_node, "RESULT" , TRS.get_string(in_node, "__RESULT"));
   



    /* Result */
    CDB_init_cedclotrlt(&CEDCLOTRLT);
    TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
    memcpy(CEDCLOTRLT.INS_TYPE, "PL", strlen("PL"));
    TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");

    CDB_select_cedclotrlt(2, &CEDCLOTRLT);
    if (DB_error_code != DB_SUCCESS)
    {
        if (DB_error_code == DB_NOT_FOUND)
        {
            CEDCLOTRLT.INS_CNT = 0;
            memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
            CDB_insert_cedclotrlt(&CEDCLOTRLT);
            if (DB_error_code != DB_SUCCESS)
            {
                //DO NOTHING
            }
        }
        else
        {
            strcpy(s_msg_code, "EDC-0004");
            TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_TRANS;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

    }

    TRS.copy(CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID), in_node, "RES_ID");
    TRS.copy(CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID), in_node, "LINE_ID");


    memcpy(CEDCLOTRLT.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCLOTRLT.OPER));


    TRS.copy(CEDCLOTRLT.INS_USER_ID, sizeof(CEDCLOTRLT.INS_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLT.INS_TIME, s_sys_time, sizeof(CEDCLOTRLT.INS_TIME));

    TRS.copy(CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE), in_node, "RESULT");
    TRS.copy(CEDCLOTRLT.RESULT_USER_ID, sizeof(CEDCLOTRLT.RESULT_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLT.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLT.RESULT_TIME));

    CEDCLOTRLT.TYPE_FLAG = TRS.get_char(in_node, "TYPE_FLAG");
    CEDCLOTRLT.LAST_HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
    memcpy(CEDCLOTRLT.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
    memcpy(CEDCLOTRLT.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
    CEDCLOTRLT.QTY = (int)MWIPLOTSTS.QTY_1;
    CEDCLOTRLT.INS_CNT = CEDCLOTRLT.INS_CNT + 1;
    memcpy(CEDCLOTRLT.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

    if (CEDCLOTRLT.INS_CNT <= 1)
    {
        memcpy(CEDCLOTRLT.CMF_1, s_sys_time, sizeof(s_sys_time)); /* Initial Inspection Time */
    }

    TRS.copy(CEDCLOTRLT.CMF_2, sizeof(CEDCLOTRLT.CMF_2), in_node, "__PARAM_NAME");


    CDB_update_cedclotrlt(1, &CEDCLOTRLT);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "EDC-0004");
        TRS.set_fieldmsg(out_node, "CEDCLOTRLT UPDATE", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLT.FACTORY), CEDCLOTRLT.FACTORY);
        TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLT.INS_TYPE), CEDCLOTRLT.INS_TYPE);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLT.LOT_ID), CEDCLOTRLT.LOT_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    /* History */
    CDB_init_cedclotrlh(&CEDCLOTRLH);


    TRS.copy(CEDCLOTRLH.FACTORY, sizeof(CEDCLOTRLH.FACTORY), in_node, IN_FACTORY);
    memcpy(CEDCLOTRLH.INS_TYPE, CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLH.INS_TYPE));
    TRS.copy(CEDCLOTRLH.LOT_ID, sizeof(CEDCLOTRLH.LOT_ID), in_node, "LOT_ID");
    CEDCLOTRLH.INS_CNT = CEDCLOTRLT.INS_CNT;
    //CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.INS_CNT;
    TRS.copy(CEDCLOTRLH.RES_ID, sizeof(CEDCLOTRLH.RES_ID), in_node, "RES_ID");
    TRS.copy(CEDCLOTRLH.LINE_ID, sizeof(CEDCLOTRLH.LINE_ID), in_node, "LINE_ID");

    memcpy(CEDCLOTRLH.OPER, MRASRESDEF.RES_CMF_2, sizeof(CEDCLOTRLH.OPER));

    TRS.copy(CEDCLOTRLH.INS_USER_ID, sizeof(CEDCLOTRLH.INS_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLH.INS_TIME, s_sys_time, sizeof(CEDCLOTRLH.INS_TIME));

    TRS.copy(CEDCLOTRLH.RESULT_VALUE, sizeof(CEDCLOTRLH.RESULT_VALUE), in_node, "RESULT");
    TRS.copy(CEDCLOTRLH.RESULT_USER_ID, sizeof(CEDCLOTRLH.RESULT_USER_ID), in_node, "CLIENT_ID");
    memcpy(CEDCLOTRLH.RESULT_TIME, s_sys_time, sizeof(CEDCLOTRLH.RESULT_TIME));

    CEDCLOTRLH.TYPE_FLAG = '1';

    CEDCLOTRLH.HIST_SEQ = CEDCLOTRLT.INS_CNT;
    memcpy(CEDCLOTRLH.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
    memcpy(CEDCLOTRLH.CMF_1, CEDCLOTRLT.CMF_1, sizeof(CEDCLOTRLH.CMF_1)); /* Initial Inspection Time */
    memcpy(CEDCLOTRLH.CMF_2, CEDCLOTRLT.CMF_2, sizeof(CEDCLOTRLH.CMF_2));
    memcpy(CEDCLOTRLH.CMF_3, CEDCLOTRLT.CMF_3, sizeof(CEDCLOTRLH.CMF_3));
    memcpy(CEDCLOTRLH.CMF_4, CEDCLOTRLT.CMF_4, sizeof(CEDCLOTRLH.CMF_4));
    memcpy(CEDCLOTRLH.CMF_5, CEDCLOTRLT.CMF_5, sizeof(CEDCLOTRLH.CMF_5));

    memcpy(CEDCLOTRLH.LOC_ID, CEDCLOTRLT.LOC_ID, sizeof(CEDCLOTRLT.LOC_ID));

    memcpy(CEDCLOTRLH.MAT_ID, CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));
    memcpy(CEDCLOTRLH.FLOW, CEDCLOTRLT.FLOW, sizeof(CEDCLOTRLT.FLOW));
    CEDCLOTRLH.QTY = CEDCLOTRLT.QTY;

    CDB_insert_cedclotrlh(&CEDCLOTRLH);
    if (DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "EDC-0004");
        TRS.set_fieldmsg(out_node, "CEDCLOTRLH INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CEDCLOTRLH.FACTORY), CEDCLOTRLH.FACTORY);
        TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTRLH.INS_TYPE), CEDCLOTRLH.INS_TYPE);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTRLH.LOT_ID), CEDCLOTRLH.LOT_ID);
        TRS.add_fieldmsg(out_node, "HIST_SEQ", MP_INT, CEDCLOTRLH.HIST_SEQ);
        TRS.add_fieldmsg(out_node, "INS_CNT", MP_INT, CEDCLOTRLH.INS_CNT);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    return MP_TRUE;
}