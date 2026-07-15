/******************************************************************************'

    System      : MESplus
    Module      : CMMS
    File Name   : CMMS_update_equipment.c
    Description : Equipment Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CMMS_Update_Equipment()
            + Create/Update/Delete Equipment definition
        - CMMS_UPDATE_EQUIPMENT()
            + Main sub function of CMMS_Update_Equipment function
            + Create/Update/Delete Equipment definition
        - CMMS_Update_Equipment_Validation()
            + Main sub function of CMMS_UPDATE_EQUIPMENT function
            + Check the condition for create/update/delete Equipment
    Detail Description
        - CMMS_UPDATE_EQUIPMENT()
            + h_proc_step
                + MP_STEP_CREATE : Create Equipment definition
                + MP_STEP_UPDATE : Update Equipment definition
                + MP_STEP_DELETE : Delete Equipment definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2023-03-20             Create by Generator

    Copyright(C) 1998-2023 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CMMS_Update_Equipment_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CMMS_Update_Equipment()
        - Create/Update/Delete Equipment definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Equipment(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CMMS_UPDATE_EQUIPMENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CMMS_UPDATE_EQUIPMENT", out_node);

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
    CMMS_UPDATE_EQUIPMENT()
        - Main sub function of "CMMS_Update_Equipment" function
        - Create/Update/Delete Equipment definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_UPDATE_EQUIPMENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSEQPDEF_TAG CMMSEQPDEF;
    struct CMMSEQPDEF_TAG CMMSEQPDEF_o;
	struct CMMSEQPHIS_TAG CMMSEQPHIS;
	struct CMMSEQPITM_TAG CMMSEQPITM;
	struct CMMSEQPFLE_TAG CMMSEQPFLE;
	//struct CMMSEQPITM_TAG CMMSEQPITM_o;
	
    char	s_sys_time[14];
	char	file_path[100];
	int		i;
	int		i_item_count;
	TRSNode **item_list;
	MBLOB m_blob;
	

    LOG_head("CMMS_UPDATE_EQUIPMENT");
    LOG_add("h_language", MP_CHR, TRS.get_language(in_node));
    LOG_add("h_factory", MP_NSTR, TRS.get_factory(in_node));
    LOG_add("h_user_id", MP_NSTR, TRS.get_userid(in_node));
    LOG_add("h_proc_step", MP_CHR, TRS.get_procstep(in_node));
    LOG_add("equip_id", MP_NSTR, TRS.get_string(in_node, "EQUIP_ID"));
    LOG_add("equip_code", MP_NSTR, TRS.get_string(in_node, "EQUIP_CODE"));
    LOG_add("equip_name", MP_NSTR, TRS.get_string(in_node, "EQUIP_NAME"));
	LOG_add("equip_type", MP_NSTR, TRS.get_string(in_node, "EQUIP_TYPE"));
    LOG_add("equip_no", MP_NSTR, TRS.get_string(in_node, "EQUIP_NO"));
    LOG_add("mgt_dept_code", MP_NSTR, TRS.get_string(in_node, "MGT_DEPT_CODE"));
    LOG_add("mgt_user_id", MP_NSTR, TRS.get_string(in_node, "MGT_USER_ID"));
    LOG_add("use_dept_code", MP_NSTR, TRS.get_string(in_node, "USE_DEPT_CODE"));
    LOG_add("use_user_id", MP_NSTR, TRS.get_string(in_node, "USE_USER_ID"));
    LOG_add("use_div", MP_NSTR, TRS.get_string(in_node, "USE_DIV"));
    LOG_add("cali_div", MP_CHR, TRS.get_char(in_node, "CALI_DIV"));
    LOG_add("partner_code", MP_NSTR, TRS.get_string(in_node, "PARTNER_CODE"));
    LOG_add("prop_no", MP_NSTR, TRS.get_string(in_node, "PROP_NO"));
    LOG_add("supply_code", MP_NSTR, TRS.get_string(in_node, "SUPPLY_CODE"));
    LOG_add("equip_maker", MP_NSTR, TRS.get_string(in_node, "EQUIP_MAKER"));
    LOG_add("equip_model", MP_NSTR, TRS.get_string(in_node, "EQUIP_MODEL"));
    LOG_add("equip_purpose", MP_NSTR, TRS.get_string(in_node, "EQUIP_PURPOSE"));
    LOG_add("equip_feature", MP_NSTR, TRS.get_string(in_node, "EQUIP_FEATURE"));
    LOG_add("equip_place_code", MP_NSTR, TRS.get_string(in_node, "EQUIP_PLACE_CODE"));
    LOG_add("serial_no", MP_NSTR, TRS.get_string(in_node, "SERIAL_NO"));
    LOG_add("equip_spec", MP_NSTR, TRS.get_string(in_node, "EQUIP_SPEC"));
    LOG_add("buy_date", MP_NSTR, TRS.get_string(in_node, "BUY_DATE"));
    LOG_add("buy_cost", MP_DBL, TRS.get_double(in_node, "BUY_COST"));
    LOG_add("cali_cycle", MP_INT, TRS.get_int(in_node, "CALI_CYCLE"));
    LOG_add("msa_cycle", MP_INT, TRS.get_int(in_node, "MSA_CYCLE"));
    LOG_add("equip_desc", MP_NSTR, TRS.get_string(in_node, "EQUIP_DESC"));
    LOG_add("last_equip_seq", MP_INT, TRS.get_int(in_node, "LAST_EQUIP_SEQ"));
    LOG_add("approve_user_id", MP_NSTR, TRS.get_string(in_node, "APPROVE_USER_ID"));
    LOG_add("approve_flag", MP_CHR, TRS.get_char(in_node, "APPROVE_FLAG"));
    LOG_add("msa_flag", MP_CHR, TRS.get_char(in_node, "MSA_FLAG"));
    LOG_add("spc_flag", MP_CHR, TRS.get_char(in_node, "SPC_FLAG"));
    LOG_add("cali_flag", MP_CHR, TRS.get_char(in_node, "CALI_FLAG"));
    LOG_add("check_flag", MP_CHR, TRS.get_char(in_node, "CHECK_FLAG"));
    LOG_add("none_flag", MP_CHR, TRS.get_char(in_node, "NONE_FLAG"));
    LOG_add("standard_flag", MP_CHR, TRS.get_char(in_node, "STANDARD_FLAG"));
    LOG_add("cmf_flag_01", MP_CHR, TRS.get_char(in_node, "CMF_FLAG_01"));
    LOG_add("cmf_flag_02", MP_CHR, TRS.get_char(in_node, "CMF_FLAG_02"));
    LOG_add("cmf_flag_03", MP_CHR, TRS.get_char(in_node, "CMF_FLAG_03"));
    LOG_add("cmf_1", MP_NSTR, TRS.get_string(in_node, "CMF_1"));
    LOG_add("cmf_2", MP_NSTR, TRS.get_string(in_node, "CMF_2"));
    LOG_add("cmf_3", MP_NSTR, TRS.get_string(in_node, "CMF_3"));
    LOG_add("cmf_4", MP_NSTR, TRS.get_string(in_node, "CMF_4"));
    LOG_add("cmf_5", MP_NSTR, TRS.get_string(in_node, "CMF_5"));
    LOG_add("cmf_6", MP_NSTR, TRS.get_string(in_node, "CMF_6"));
    LOG_add("cmf_7", MP_NSTR, TRS.get_string(in_node, "CMF_7"));
    LOG_add("cmf_8", MP_NSTR, TRS.get_string(in_node, "CMF_8"));
    LOG_add("cmf_9", MP_NSTR, TRS.get_string(in_node, "CMF_9"));
    LOG_add("cmf_10", MP_NSTR, TRS.get_string(in_node, "CMF_10"));
    LOG_add("create_user_id", MP_NSTR, TRS.get_string(in_node, "CREATE_USER_ID"));
    LOG_add("create_time", MP_NSTR, TRS.get_string(in_node, "CREATE_TIME"));
    LOG_add("update_user_id", MP_NSTR, TRS.get_string(in_node, "UPDATE_USER_ID"));
    LOG_add("update_time", MP_NSTR, TRS.get_string(in_node, "UPDATE_TIME"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_SETUP);

    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Equipment",
                             MP_UPOINT_BEFORE,
                             in_node,
                             out_node) == MP_FALSE)     return MP_FALSE;
    if(TRS.get_boolean(in_node, "__BYPASS") == MP_TRUE) return MP_TRUE;
    */

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

    if(CMMS_Update_Equipment_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmseqpdef(&CMMSEQPDEF);
    TRS.copy(CMMSEQPDEF.FACTORY, sizeof(CMMSEQPDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID), in_node, "EQUIP_ID");
    TRS.copy(CMMSEQPDEF.EQUIP_CODE, sizeof(CMMSEQPDEF.EQUIP_CODE), in_node, "EQUIP_CODE");
    TRS.copy(CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPDEF.EQUIP_NAME), in_node, "EQUIP_NAME");
	TRS.copy(CMMSEQPDEF.EQUIP_TYPE, sizeof(CMMSEQPDEF.EQUIP_TYPE), in_node, "EQUIP_TYPE");
    TRS.copy(CMMSEQPDEF.EQUIP_NO, sizeof(CMMSEQPDEF.EQUIP_NO), in_node, "EQUIP_NO");
    TRS.copy(CMMSEQPDEF.MGT_DEPT_CODE, sizeof(CMMSEQPDEF.MGT_DEPT_CODE), in_node, "MGT_DEPT_CODE");
    TRS.copy(CMMSEQPDEF.MGT_USER_ID, sizeof(CMMSEQPDEF.MGT_USER_ID), in_node, "MGT_USER_ID");
    TRS.copy(CMMSEQPDEF.USE_DEPT_CODE, sizeof(CMMSEQPDEF.USE_DEPT_CODE), in_node, "USE_DEPT_CODE");
    TRS.copy(CMMSEQPDEF.USE_USER_ID, sizeof(CMMSEQPDEF.USE_USER_ID), in_node, "USE_USER_ID");
    TRS.copy(CMMSEQPDEF.USE_DIV, sizeof(CMMSEQPDEF.USE_DIV), in_node, "USE_DIV");
    CMMSEQPDEF.CALI_DIV = TRS.get_char(in_node, "CALI_DIV");
    TRS.copy(CMMSEQPDEF.PARTNER_CODE, sizeof(CMMSEQPDEF.PARTNER_CODE), in_node, "PARTNER_CODE");
    TRS.copy(CMMSEQPDEF.PROP_NO, sizeof(CMMSEQPDEF.PROP_NO), in_node, "PROP_NO");
    TRS.copy(CMMSEQPDEF.SUPPLY_CODE, sizeof(CMMSEQPDEF.SUPPLY_CODE), in_node, "SUPPLY_CODE");
    TRS.copy(CMMSEQPDEF.EQUIP_MAKER, sizeof(CMMSEQPDEF.EQUIP_MAKER), in_node, "EQUIP_MAKER");
    TRS.copy(CMMSEQPDEF.EQUIP_MODEL, sizeof(CMMSEQPDEF.EQUIP_MODEL), in_node, "EQUIP_MODEL");
    TRS.copy(CMMSEQPDEF.EQUIP_PURPOSE, sizeof(CMMSEQPDEF.EQUIP_PURPOSE), in_node, "EQUIP_PURPOSE");
    TRS.copy(CMMSEQPDEF.EQUIP_FEATURE, sizeof(CMMSEQPDEF.EQUIP_FEATURE), in_node, "EQUIP_FEATURE");
    TRS.copy(CMMSEQPDEF.EQUIP_PLACE_CODE, sizeof(CMMSEQPDEF.EQUIP_PLACE_CODE), in_node, "EQUIP_PLACE_CODE");
    TRS.copy(CMMSEQPDEF.SERIAL_NO, sizeof(CMMSEQPDEF.SERIAL_NO), in_node, "SERIAL_NO");
    TRS.copy(CMMSEQPDEF.EQUIP_SPEC, sizeof(CMMSEQPDEF.EQUIP_SPEC), in_node, "EQUIP_SPEC");
    TRS.copy(CMMSEQPDEF.BUY_DATE, sizeof(CMMSEQPDEF.BUY_DATE), in_node, "BUY_DATE");
    CMMSEQPDEF.BUY_COST = TRS.get_double(in_node, "BUY_COST");
    CMMSEQPDEF.CALI_CYCLE = TRS.get_int(in_node, "CALI_CYCLE");
    CMMSEQPDEF.MSA_CYCLE = TRS.get_int(in_node, "MSA_CYCLE");
    TRS.copy(CMMSEQPDEF.EQUIP_DESC, sizeof(CMMSEQPDEF.EQUIP_DESC), in_node, "EQUIP_DESC");
    CMMSEQPDEF.LAST_EQUIP_SEQ = TRS.get_int(in_node, "LAST_EQUIP_SEQ");
    TRS.copy(CMMSEQPDEF.APPROVE_USER_ID, sizeof(CMMSEQPDEF.APPROVE_USER_ID), in_node, "APPROVE_USER_ID");
    CMMSEQPDEF.APPROVE_FLAG = TRS.get_char(in_node, "APPROVE_FLAG");
    CMMSEQPDEF.MSA_FLAG = TRS.get_char(in_node, "MSA_FLAG");
    CMMSEQPDEF.SPC_FLAG = TRS.get_char(in_node, "SPC_FLAG");
    CMMSEQPDEF.CALI_FLAG = TRS.get_char(in_node, "CALI_FLAG");
    CMMSEQPDEF.CHECK_FLAG = TRS.get_char(in_node, "CHECK_FLAG");
    CMMSEQPDEF.NONE_FLAG = TRS.get_char(in_node, "NONE_FLAG");
    CMMSEQPDEF.STANDARD_FLAG = TRS.get_char(in_node, "STANDARD_FLAG");
    CMMSEQPDEF.CMF_FLAG_01 = TRS.get_char(in_node, "CMF_FLAG_01");
    CMMSEQPDEF.CMF_FLAG_02 = TRS.get_char(in_node, "CMF_FLAG_02");
    CMMSEQPDEF.CMF_FLAG_03 = TRS.get_char(in_node, "CMF_FLAG_03");
    TRS.copy(CMMSEQPDEF.CMF_1, sizeof(CMMSEQPDEF.CMF_1), in_node, "CMF_1");
    TRS.copy(CMMSEQPDEF.CMF_2, sizeof(CMMSEQPDEF.CMF_2), in_node, "CMF_2");
    TRS.copy(CMMSEQPDEF.CMF_3, sizeof(CMMSEQPDEF.CMF_3), in_node, "CMF_3");
    TRS.copy(CMMSEQPDEF.CMF_4, sizeof(CMMSEQPDEF.CMF_4), in_node, "CMF_4");
    TRS.copy(CMMSEQPDEF.CMF_5, sizeof(CMMSEQPDEF.CMF_5), in_node, "CMF_5");
    TRS.copy(CMMSEQPDEF.CMF_6, sizeof(CMMSEQPDEF.CMF_6), in_node, "CMF_6");
    TRS.copy(CMMSEQPDEF.CMF_7, sizeof(CMMSEQPDEF.CMF_7), in_node, "CMF_7");
    TRS.copy(CMMSEQPDEF.CMF_8, sizeof(CMMSEQPDEF.CMF_8), in_node, "CMF_8");
    TRS.copy(CMMSEQPDEF.CMF_9, sizeof(CMMSEQPDEF.CMF_9), in_node, "CMF_9");
    TRS.copy(CMMSEQPDEF.CMF_10, sizeof(CMMSEQPDEF.CMF_10), in_node, "CMF_10");
    TRS.copy(CMMSEQPDEF.CREATE_USER_ID, sizeof(CMMSEQPDEF.CREATE_USER_ID), in_node, "CREATE_USER_ID");
    TRS.copy(CMMSEQPDEF.CREATE_TIME, sizeof(CMMSEQPDEF.CREATE_TIME), in_node, "CREATE_TIME");
    TRS.copy(CMMSEQPDEF.UPDATE_USER_ID, sizeof(CMMSEQPDEF.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
    TRS.copy(CMMSEQPDEF.UPDATE_TIME, sizeof(CMMSEQPDEF.UPDATE_TIME), in_node, "UPDATE_TIME");

    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {

        //----[Addtional Logic for Create Case]----

        TRS.copy(CMMSEQPDEF.CREATE_USER_ID, sizeof(CMMSEQPDEF.CREATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSEQPDEF.CREATE_TIME, s_sys_time, sizeof(CMMSEQPDEF.CREATE_TIME));
        CDB_insert_cmmseqpdef(&CMMSEQPDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPDEF INSERT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF.FACTORY), CMMSEQPDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF.EQUIP_ID), CMMSEQPDEF.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
        CDB_init_cmmseqpdef(&CMMSEQPDEF_o);
        TRS.copy(CMMSEQPDEF_o.FACTORY, sizeof(CMMSEQPDEF_o.FACTORY), in_node, IN_FACTORY);
        TRS.copy(CMMSEQPDEF_o.EQUIP_ID, sizeof(CMMSEQPDEF_o.EQUIP_ID), in_node, "EQUIP_ID");
        CDB_select_cmmseqpdef_for_update(1, &CMMSEQPDEF_o);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPDEF SELECT FOR UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF_o.FACTORY), CMMSEQPDEF_o.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF_o.EQUIP_ID), CMMSEQPDEF_o.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        //----[Addtional Logic for Update Case]----
        memcpy(CMMSEQPDEF.CREATE_USER_ID, CMMSEQPDEF_o.CREATE_USER_ID, sizeof(CMMSEQPDEF.CREATE_USER_ID));
        memcpy(CMMSEQPDEF.CREATE_TIME, CMMSEQPDEF_o.CREATE_TIME, sizeof(CMMSEQPDEF.CREATE_TIME));
        TRS.copy(CMMSEQPDEF.UPDATE_USER_ID, sizeof(CMMSEQPDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSEQPDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSEQPDEF.UPDATE_TIME));

        CDB_update_cmmseqpdef(1, &CMMSEQPDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPDEF UPDATE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF.FACTORY), CMMSEQPDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF.EQUIP_ID), CMMSEQPDEF.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
		TRS.copy(CMMSEQPDEF.UPDATE_USER_ID, sizeof(CMMSEQPDEF.UPDATE_USER_ID), in_node, IN_USERID);
        memcpy(CMMSEQPDEF.UPDATE_TIME, s_sys_time, sizeof(CMMSEQPDEF.UPDATE_TIME));
        CDB_delete_cmmseqpdef(1, &CMMSEQPDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0004");
            TRS.add_fieldmsg(out_node, "CMMSEQPDEF DELETE", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF.FACTORY), CMMSEQPDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF.EQUIP_ID), CMMSEQPDEF.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		// CMMSEQPITM TABLE 삭제 추가 
		CDB_init_cmmseqpitm(&CMMSEQPITM);
		memcpy(CMMSEQPITM.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPITM.FACTORY));
		memcpy(CMMSEQPITM.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID));
		CDB_delete_cmmseqpitm(1, &CMMSEQPITM);
        if(DB_error_code != DB_SUCCESS)
        {
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSEQPITM DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
        }

		// CMMSEQPFLE TABLE 삭제 추가 
		CDB_init_cmmseqpfle(&CMMSEQPFLE);
		memcpy(CMMSEQPFLE.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPFLE.FACTORY));
		memcpy(CMMSEQPFLE.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPFLE.EQUIP_ID));
		CDB_delete_cmmseqpfle(1, &CMMSEQPFLE);
        if(DB_error_code != DB_SUCCESS)
        {
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSEQPFLE DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
        }
    }

	//CMMSEQPITM TABLE Insert/Update 추가 
	if(TRS.get_procstep(in_node) == MP_STEP_CREATE || TRS.get_procstep(in_node) == MP_STEP_UPDATE)
    {
		i_item_count = TRS.get_item_count(in_node, "EQUIP_ITEM_LIST");
		item_list = TRS.get_list(in_node, "EQUIP_ITEM_LIST");

		for(i = 0; i < i_item_count; i++)
        {
            CDB_init_cmmseqpitm(&CMMSEQPITM);
            memcpy(CMMSEQPITM.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPITM.FACTORY));
			memcpy(CMMSEQPITM.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID));
			TRS.copy(CMMSEQPITM.ITEM_CODE, sizeof(CMMSEQPITM.ITEM_CODE), item_list[i], "ITEM_CODE");
			
			CDB_select_cmmseqpitm(1, &CMMSEQPITM);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSEQPITM SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
					TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}
				// Insert	
				TRS.copy(CMMSEQPITM.ITEM_NAME, sizeof(CMMSEQPITM.ITEM_NAME), item_list[i], "ITEM_NAME");
				TRS.copy(CMMSEQPITM.ITEM_SPEC, sizeof(CMMSEQPITM.ITEM_SPEC), item_list[i], "ITEM_SPEC");
				CMMSEQPITM.LSL = TRS.get_double(item_list[i], "LSL");
				CMMSEQPITM.USL = TRS.get_double(item_list[i], "USL");
				CMMSEQPITM.ITEM_ORDER = TRS.get_int(item_list[i], "ITEM_ORDER");
				TRS.copy(CMMSEQPITM.UNIT_CODE, sizeof(CMMSEQPITM.UNIT_CODE), item_list[i], "UNIT_CODE");
				CMMSEQPITM.DECIMAL_PLACE = TRS.get_int(item_list[i], "DECIMAL_PLACE");
				CMMSEQPITM.USE_GRR_CONT_FLAG = TRS.get_char(item_list[i], "USE_GRR_CONT_FLAG");
				CMMSEQPITM.USE_GRR_DISC_FLAG = TRS.get_char(item_list[i], "USE_GRR_DISC_FLAG");
				CMMSEQPITM.USE_BIAS_FLAG = TRS.get_char(item_list[i], "USE_BIAS_FLAG");
				CMMSEQPITM.USE_LINE_FLAG = TRS.get_char(item_list[i], "USE_LINE_FLAG");
				memcpy(CMMSEQPITM.CMF_10, s_sys_time, sizeof(CMMSEQPITM.CREATE_TIME));
				TRS.copy(CMMSEQPITM.CREATE_USER_ID, sizeof(CMMSEQPITM.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSEQPITM.CREATE_TIME, s_sys_time, sizeof(CMMSEQPITM.CREATE_TIME));
				TRS.copy(CMMSEQPITM.UPDATE_USER_ID, sizeof(CMMSEQPITM.UPDATE_USER_ID), in_node, "UPDATE_USER_ID");
				TRS.copy(CMMSEQPITM.UPDATE_TIME, sizeof(CMMSEQPITM.UPDATE_TIME), in_node, "UPDATE_TIME");
				CDB_insert_cmmseqpitm(&CMMSEQPITM);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSEQPITM INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
					TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
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
				//비교 후 Update 
				if(((int)(CMMSEQPITM.LSL * 100) != (int)(TRS.get_double(item_list[i], "LSL") * 100)) ||
				((int)(CMMSEQPITM.USL * 100) != (int)(TRS.get_double(item_list[i], "USL") * 100)) ||
				CMMSEQPITM.ITEM_ORDER != TRS.get_int(item_list[i], "ITEM_ORDER") ||
				CMMSEQPITM.DECIMAL_PLACE != TRS.get_int(item_list[i], "DECIMAL_PLACE") ||
				CMMSEQPITM.USE_GRR_CONT_FLAG != TRS.get_char(item_list[i], "USE_GRR_CONT_FLAG") ||
				CMMSEQPITM.USE_GRR_DISC_FLAG != TRS.get_char(item_list[i], "USE_GRR_DISC_FLAG") ||
				CMMSEQPITM.USE_BIAS_FLAG != TRS.get_char(item_list[i], "USE_BIAS_FLAG") ||
				CMMSEQPITM.USE_LINE_FLAG != TRS.get_char(item_list[i], "USE_LINE_FLAG"))
				{
					TRS.copy(CMMSEQPITM.ITEM_NAME, sizeof(CMMSEQPITM.ITEM_NAME), item_list[i], "ITEM_NAME");
					TRS.copy(CMMSEQPITM.ITEM_SPEC, sizeof(CMMSEQPITM.ITEM_SPEC), item_list[i], "ITEM_SPEC");
					CMMSEQPITM.LSL = TRS.get_double(item_list[i], "LSL");
					CMMSEQPITM.USL = TRS.get_double(item_list[i], "USL");
					CMMSEQPITM.ITEM_ORDER = TRS.get_int(item_list[i], "ITEM_ORDER");
					TRS.copy(CMMSEQPITM.UNIT_CODE, sizeof(CMMSEQPITM.UNIT_CODE), item_list[i], "UNIT_CODE");
					CMMSEQPITM.DECIMAL_PLACE = TRS.get_int(item_list[i], "DECIMAL_PLACE");
					CMMSEQPITM.USE_GRR_CONT_FLAG = TRS.get_char(item_list[i], "USE_GRR_CONT_FLAG");
					CMMSEQPITM.USE_GRR_DISC_FLAG = TRS.get_char(item_list[i], "USE_GRR_DISC_FLAG");
					CMMSEQPITM.USE_BIAS_FLAG = TRS.get_char(item_list[i], "USE_BIAS_FLAG");
					CMMSEQPITM.USE_LINE_FLAG = TRS.get_char(item_list[i], "USE_LINE_FLAG");
					memcpy(CMMSEQPITM.CMF_10, s_sys_time, sizeof(CMMSEQPITM.CREATE_TIME));
					TRS.copy(CMMSEQPITM.UPDATE_USER_ID, sizeof(CMMSEQPITM.UPDATE_USER_ID), in_node, IN_USERID);
					memcpy(CMMSEQPITM.UPDATE_TIME, s_sys_time, sizeof(CMMSEQPITM.UPDATE_TIME));
					CDB_update_cmmseqpitm(1, &CMMSEQPITM);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "MMS-0004");
						TRS.add_fieldmsg(out_node, "CMMSEQPITM UPDATE", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
						TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
						TRS.add_fieldmsg(out_node, "ITEM_CODE", MP_STR, sizeof(CMMSEQPITM.ITEM_CODE), CMMSEQPITM.ITEM_CODE);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				else
				{   //삭제된 Row 반영을 위한 Update 
					memcpy(CMMSEQPITM.CMF_10, s_sys_time, sizeof(CMMSEQPITM.CREATE_TIME));
					CDB_update_cmmseqpitm(2, &CMMSEQPITM);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "MMS-0004");
						TRS.add_fieldmsg(out_node, "CMMSEQPITM UPDATE", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
						TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
						TRS.add_fieldmsg(out_node, "CMF_10", MP_STR, sizeof(CMMSEQPITM.CMF_10), CMMSEQPITM.CMF_10);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
			}
        }

		//삭제된 Row 적용 
		CDB_init_cmmseqpitm(&CMMSEQPITM);
        memcpy(CMMSEQPITM.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPITM.FACTORY));
		memcpy(CMMSEQPITM.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPITM.EQUIP_ID));
		memcpy(CMMSEQPITM.CMF_10, s_sys_time, sizeof(CMMSEQPITM.CREATE_TIME));
		CDB_delete_cmmseqpitm(2, &CMMSEQPITM);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSEQPITM DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPITM.FACTORY), CMMSEQPITM.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPITM.EQUIP_ID), CMMSEQPITM.EQUIP_ID);
				TRS.add_fieldmsg(out_node, "CMF_10", MP_STR, sizeof(CMMSEQPITM.CMF_10), CMMSEQPITM.CMF_10);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}


		i_item_count = TRS.get_item_count(in_node, "EQUIP_IMAGE_LIST");
		item_list = TRS.get_list(in_node, "EQUIP_IMAGE_LIST");

		for(i = 0; i < i_item_count; i++)
        {
            CDB_init_cmmseqpfle(&CMMSEQPFLE);
            memcpy(CMMSEQPFLE.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPFLE.FACTORY));
			memcpy(CMMSEQPFLE.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPFLE.EQUIP_ID));
			TRS.copy(CMMSEQPFLE.FILE_NAME, sizeof(CMMSEQPFLE.FILE_NAME), item_list[i], "FILE_NAME");			
			CDB_select_cmmseqpfle(1, &CMMSEQPFLE);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code != DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSEQPFLE SELECT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
					TRS.add_fieldmsg(out_node, "FILE_NAME", MP_STR, sizeof(CMMSEQPFLE.FILE_NAME), CMMSEQPFLE.FILE_NAME);
					TRS.add_dberrmsg(out_node, DB_error_msg);

					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

				//이미지 파일 저장 
				m_blob = TRSN.get_blob(item_list[i], TRS.get_string(item_list[i], "FILE_NAME"));
				if (m_blob.IS_NULL != 'Y')
				{
					memset(file_path, 0x00, sizeof(file_path));
					if (CMMS_set_attached_file(s_msg_code, "CMMSEQPFLE", TRS.get_string(in_node, "EQUIP_ID"), TRS.get_string(item_list[i], "FILE_NAME"), m_blob, file_path) == MP_FALSE)
					{
						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
					memcpy(CMMSEQPFLE.FILE_PATH, file_path, sizeof(CMMSEQPFLE.FILE_PATH));
				}


				// Insert	
				CMMSEQPFLE.FILE_ORDER = TRS.get_int(item_list[i], "FILE_ORDER");
				TRS.copy(CMMSEQPFLE.FILE_DESC, sizeof(CMMSEQPFLE.FILE_DESC), item_list[i], "FILE_DESC");
				TRS.copy(CMMSEQPFLE.CREATE_USER_ID, sizeof(CMMSEQPFLE.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(CMMSEQPFLE.CREATE_TIME, s_sys_time, sizeof(CMMSEQPFLE.CREATE_TIME));
				CDB_insert_cmmseqpfle(&CMMSEQPFLE);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "MMS-0004");
					TRS.add_fieldmsg(out_node, "CMMSEQPFLE INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
					TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
					TRS.add_fieldmsg(out_node, "FILE_NAME", MP_STR, sizeof(CMMSEQPFLE.FILE_NAME), CMMSEQPFLE.FILE_NAME);
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

				//비교 후 Update 
				if(CMMSEQPFLE.FILE_ORDER != TRS.get_int(item_list[i], "FILE_ORDER") ||
					CMMSEQPFLE.FILE_DESC != TRS.get_string(item_list[i], "FILE_DESC"))
				{

					//이미지 파일 저장 
					m_blob = TRSN.get_blob(item_list[i], TRS.get_string(item_list[i], "FILE_NAME"));
					if (m_blob.IS_NULL != 'Y')
					{
						memset(file_path, 0x00, sizeof(file_path));
						if (CMMS_set_attached_file(s_msg_code, "CMMSEQPFLE", TRS.get_string(in_node, "EQUIP_ID"), TRS.get_string(item_list[i], "FILE_NAME"), m_blob, file_path) == MP_FALSE)
						{
							COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
							return MP_FALSE;
						}
						memcpy(CMMSEQPFLE.FILE_PATH, file_path, sizeof(CMMSEQPFLE.FILE_PATH));
					}

					CMMSEQPFLE.FILE_ORDER = TRS.get_int(item_list[i], "FILE_ORDER");
					TRS.copy(CMMSEQPFLE.FILE_DESC, sizeof(CMMSEQPFLE.FILE_DESC), item_list[i], "FILE_DESC");
					TRS.copy(CMMSEQPFLE.UPDATE_USER_ID, sizeof(CMMSEQPFLE.UPDATE_USER_ID), in_node, IN_USERID);
					memcpy(CMMSEQPFLE.UPDATE_TIME, s_sys_time, sizeof(CMMSEQPFLE.UPDATE_TIME));
					CDB_update_cmmseqpfle(1, &CMMSEQPFLE);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "MMS-0004");
						TRS.add_fieldmsg(out_node, "CMMSEQPFLE UPDATE", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
						TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
						TRS.add_fieldmsg(out_node, "FILE_NAME", MP_STR, sizeof(CMMSEQPFLE.FILE_NAME), CMMSEQPFLE.FILE_NAME);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
				else
				{   //삭제된 Row 반영을 위한 Update 
					memcpy(CMMSEQPFLE.CMF_5, s_sys_time, sizeof(CMMSEQPFLE.CREATE_TIME));
					CDB_update_cmmseqpfle(2, &CMMSEQPFLE);
					if(DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "MMS-0004");
						TRS.add_fieldmsg(out_node, "CMMSEQPFLE UPDATE", MP_NVST);
						TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
						TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
						TRS.add_fieldmsg(out_node, "CMF_5", MP_STR, sizeof(CMMSEQPFLE.CMF_5), CMMSEQPFLE.CMF_5);
						TRS.add_dberrmsg(out_node, DB_error_msg);

						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_SETUP;

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						return MP_FALSE;
					}
				}
			}
		}

		//삭제된 Row 적용 
		CDB_init_cmmseqpfle(&CMMSEQPFLE);
        memcpy(CMMSEQPFLE.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPFLE.FACTORY));
		memcpy(CMMSEQPFLE.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPFLE.EQUIP_ID));
		memcpy(CMMSEQPFLE.CMF_5, s_sys_time, sizeof(CMMSEQPFLE.CREATE_TIME));
		CDB_delete_cmmseqpfle(2, &CMMSEQPFLE);
		if(DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code != DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "MMS-0004");
				TRS.add_fieldmsg(out_node, "CMMSEQPFLE DELETE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPFLE.FACTORY), CMMSEQPFLE.FACTORY);
				TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPFLE.EQUIP_ID), CMMSEQPFLE.EQUIP_ID);
				TRS.add_fieldmsg(out_node, "CMF_5", MP_STR, sizeof(CMMSEQPFLE.CMF_5), CMMSEQPFLE.CMF_5);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
	}

	/*  Add History Log  */
	CDB_init_cmmseqphis(&CMMSEQPHIS);
	memcpy(CMMSEQPHIS.FACTORY, CMMSEQPDEF.FACTORY, sizeof(CMMSEQPHIS.FACTORY));
	memcpy(CMMSEQPHIS.EQUIP_ID, CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPHIS.EQUIP_ID));
	CMMSEQPHIS.HIST_SEQ = (int)CDB_select_cmmseqphis_scalar(2, &CMMSEQPHIS) + 1;
	memcpy(CMMSEQPHIS.EQUIP_CODE, CMMSEQPDEF.EQUIP_CODE, sizeof(CMMSEQPHIS.EQUIP_CODE));
	memcpy(CMMSEQPHIS.EQUIP_NAME, CMMSEQPDEF.EQUIP_NAME, sizeof(CMMSEQPHIS.EQUIP_NAME));
	memcpy(CMMSEQPHIS.EQUIP_TYPE, CMMSEQPDEF.EQUIP_TYPE, sizeof(CMMSEQPHIS.EQUIP_TYPE));
	memcpy(CMMSEQPHIS.EQUIP_NO, CMMSEQPDEF.EQUIP_NO, sizeof(CMMSEQPHIS.EQUIP_NO));
	memcpy(CMMSEQPHIS.MGT_DEPT_CODE, CMMSEQPDEF.MGT_DEPT_CODE, sizeof(CMMSEQPHIS.MGT_DEPT_CODE));
	memcpy(CMMSEQPHIS.MGT_USER_ID, CMMSEQPDEF.MGT_USER_ID, sizeof(CMMSEQPHIS.MGT_USER_ID));
	memcpy(CMMSEQPHIS.USE_DEPT_CODE, CMMSEQPDEF.USE_DEPT_CODE, sizeof(CMMSEQPHIS.USE_DEPT_CODE));
	memcpy(CMMSEQPHIS.USE_USER_ID, CMMSEQPDEF.USE_USER_ID, sizeof(CMMSEQPHIS.USE_USER_ID));
	memcpy(CMMSEQPHIS.USE_DIV, CMMSEQPDEF.USE_DIV, sizeof(CMMSEQPHIS.USE_DIV));	
	CMMSEQPHIS.CALI_DIV = CMMSEQPDEF.CALI_DIV;
	memcpy(CMMSEQPHIS.PARTNER_CODE, CMMSEQPDEF.PARTNER_CODE, sizeof(CMMSEQPHIS.PARTNER_CODE));
	memcpy(CMMSEQPHIS.PROP_NO, CMMSEQPDEF.PROP_NO, sizeof(CMMSEQPHIS.PROP_NO));
	memcpy(CMMSEQPHIS.SUPPLY_CODE, CMMSEQPDEF.SUPPLY_CODE, sizeof(CMMSEQPHIS.SUPPLY_CODE));
	memcpy(CMMSEQPHIS.EQUIP_MAKER, CMMSEQPDEF.EQUIP_MAKER, sizeof(CMMSEQPHIS.EQUIP_MAKER));
	memcpy(CMMSEQPHIS.EQUIP_MODEL, CMMSEQPDEF.EQUIP_MODEL, sizeof(CMMSEQPHIS.EQUIP_MODEL));
	memcpy(CMMSEQPHIS.EQUIP_PURPOSE, CMMSEQPDEF.EQUIP_PURPOSE, sizeof(CMMSEQPHIS.EQUIP_PURPOSE));
	memcpy(CMMSEQPHIS.EQUIP_FEATURE, CMMSEQPDEF.EQUIP_FEATURE, sizeof(CMMSEQPHIS.EQUIP_FEATURE));
	memcpy(CMMSEQPHIS.EQUIP_PLACE_CODE, CMMSEQPDEF.EQUIP_PLACE_CODE, sizeof(CMMSEQPHIS.EQUIP_PLACE_CODE));
	memcpy(CMMSEQPHIS.SERIAL_NO, CMMSEQPDEF.SERIAL_NO, sizeof(CMMSEQPHIS.SERIAL_NO));
	memcpy(CMMSEQPHIS.BUY_DATE, CMMSEQPDEF.BUY_DATE, sizeof(CMMSEQPHIS.BUY_DATE));
	CMMSEQPHIS.BUY_COST = CMMSEQPDEF.BUY_COST;
	CMMSEQPHIS.CALI_CYCLE = CMMSEQPDEF.CALI_CYCLE;
	CMMSEQPHIS.MSA_CYCLE = CMMSEQPDEF.MSA_CYCLE;
	memcpy(CMMSEQPHIS.EQUIP_DESC, CMMSEQPDEF.EQUIP_DESC, sizeof(CMMSEQPHIS.EQUIP_DESC));
	CMMSEQPHIS.LAST_EQUIP_SEQ = CMMSEQPDEF.LAST_EQUIP_SEQ;
	memcpy(CMMSEQPHIS.APPROVE_USER_ID, CMMSEQPDEF.APPROVE_USER_ID, sizeof(CMMSEQPHIS.APPROVE_USER_ID));	
	CMMSEQPHIS.APPROVE_FLAG = CMMSEQPDEF.APPROVE_FLAG;
	CMMSEQPHIS.MSA_FLAG = CMMSEQPDEF.MSA_FLAG;
	CMMSEQPHIS.SPC_FLAG = CMMSEQPDEF.SPC_FLAG;
	CMMSEQPHIS.CALI_FLAG = CMMSEQPDEF.CALI_FLAG;
	CMMSEQPHIS.CHECK_FLAG = CMMSEQPDEF.CHECK_FLAG;
	CMMSEQPHIS.NONE_FLAG = CMMSEQPDEF.NONE_FLAG;
	CMMSEQPHIS.STANDARD_FLAG = CMMSEQPDEF.STANDARD_FLAG;
	CMMSEQPHIS.CMF_FLAG_01 = CMMSEQPDEF.CMF_FLAG_01;
	CMMSEQPHIS.CMF_FLAG_02 = CMMSEQPDEF.CMF_FLAG_02;
	CMMSEQPHIS.CMF_FLAG_03 = CMMSEQPDEF.CMF_FLAG_03;	
	memcpy(CMMSEQPHIS.CMF_1, CMMSEQPDEF.CMF_1, sizeof(CMMSEQPHIS.CMF_1));
	memcpy(CMMSEQPHIS.CMF_2, CMMSEQPDEF.CMF_2, sizeof(CMMSEQPHIS.CMF_2));
	memcpy(CMMSEQPHIS.CMF_3, CMMSEQPDEF.CMF_3, sizeof(CMMSEQPHIS.CMF_3));
	memcpy(CMMSEQPHIS.CMF_4, CMMSEQPDEF.CMF_4, sizeof(CMMSEQPHIS.CMF_4));
	memcpy(CMMSEQPHIS.CMF_5, CMMSEQPDEF.CMF_5, sizeof(CMMSEQPHIS.CMF_5));
	memcpy(CMMSEQPHIS.CMF_6, CMMSEQPDEF.CMF_6, sizeof(CMMSEQPHIS.CMF_6));
	memcpy(CMMSEQPHIS.CMF_7, CMMSEQPDEF.CMF_7, sizeof(CMMSEQPHIS.CMF_7));
	memcpy(CMMSEQPHIS.CMF_8, CMMSEQPDEF.CMF_8, sizeof(CMMSEQPHIS.CMF_8));
	memcpy(CMMSEQPHIS.CMF_9, CMMSEQPDEF.CMF_9, sizeof(CMMSEQPHIS.CMF_9));
	memcpy(CMMSEQPHIS.CMF_10, CMMSEQPDEF.CMF_10, sizeof(CMMSEQPHIS.CMF_10));
	memcpy(CMMSEQPHIS.CREATE_USER_ID, CMMSEQPDEF.CREATE_USER_ID, sizeof(CMMSEQPHIS.CREATE_USER_ID));
    memcpy(CMMSEQPHIS.CREATE_TIME, CMMSEQPDEF.CREATE_TIME, sizeof(CMMSEQPHIS.CREATE_TIME));
	memcpy(CMMSEQPHIS.UPDATE_USER_ID, CMMSEQPDEF.UPDATE_USER_ID, sizeof(CMMSEQPHIS.UPDATE_USER_ID));
    memcpy(CMMSEQPHIS.UPDATE_TIME, CMMSEQPDEF.UPDATE_TIME, sizeof(CMMSEQPHIS.UPDATE_TIME));
	CDB_insert_cmmseqphis(&CMMSEQPHIS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "MMS-0004");
        TRS.add_fieldmsg(out_node, "CMMSITMHIS INSERT", MP_NVST);
		TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPHIS.FACTORY), CMMSEQPHIS.FACTORY);
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPHIS.EQUIP_ID), CMMSEQPHIS.EQUIP_ID);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_SETUP;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }


    /* Not use in customizing
    if(COM_proc_user_routine("CMMS", "CMMS_Update_Equipment",
                             MP_UPOINT_AFTER,
                             in_node,
                             out_node) == MP_FALSE) return MP_FALSE;
    */

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CMMS_Update_Equipment_Validation()
        - Main sub function of "CMMS_UPDATE_EQUIPMENT" function
        - Check the condition for create/update/delete Equipment
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CMMS_Update_Equipment_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CMMSEQPDEF_TAG CMMSEQPDEF;
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "IUD") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
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

    /* EQUIP_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "EQUIP_ID")) == MP_TRUE)
    {
        strcpy(s_msg_code, "MMS-0001");
        TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

    CDB_init_cmmseqpdef(&CMMSEQPDEF);
    TRS.copy(CMMSEQPDEF.FACTORY, sizeof(CMMSEQPDEF.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CMMSEQPDEF.EQUIP_ID, sizeof(CMMSEQPDEF.EQUIP_ID), in_node, "EQUIP_ID");
    CDB_select_cmmseqpdef(1, &CMMSEQPDEF);
    if(TRS.get_procstep(in_node) == MP_STEP_CREATE)
    {
        if(DB_error_code == DB_SUCCESS)
        {
            strcpy(s_msg_code, "MMS-0010");
            TRS.add_fieldmsg(out_node, "CMMSEQPDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF.FACTORY), CMMSEQPDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF.EQUIP_ID), CMMSEQPDEF.EQUIP_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    else if(TRS.get_procstep(in_node) == MP_STEP_UPDATE || TRS.get_procstep(in_node) == MP_STEP_DELETE)
    {
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "MMS-0011");
                gs_log_type.e_type = MP_LOG_E_VALIDATION;
            }
            else
            {
                strcpy(s_msg_code, "MMS-0004");
                TRS.add_dberrmsg(out_node, DB_error_msg);

                gs_log_type.e_type = MP_LOG_E_SYSTEM;
            }

            TRS.add_fieldmsg(out_node, "CMMSEQPDEF SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CMMSEQPDEF.FACTORY), CMMSEQPDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "EQUIP_ID", MP_STR, sizeof(CMMSEQPDEF.EQUIP_ID), CMMSEQPDEF.EQUIP_ID);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            return MP_FALSE;
        }
    }

    return MP_TRUE;
}

