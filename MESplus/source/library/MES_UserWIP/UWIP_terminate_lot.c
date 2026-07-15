/*******************************************************************************

    System      : MESplus
    Module      : User Routine for WIP
    File Name   : UWIP_Terminate_Lot.c
    Description : User Routine for WIP_Adapt_Lot

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/11/10  Miracom        Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include "UWIP_common.h"
#include "CUS_HQCUSM_common.h"

int WIP_Terminate_Lot_Before_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    return MP_TRUE;
}

int WIP_Terminate_Lot_After_1(TRSNode *in_node, TRSNode *out_node)
{
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct RSUMWIPLOS_TAG RSUMWIPLOS;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct CWIPLOTEXT_TAG CWIPLOTEXT;
	/* - [GERP PROJECT][ERP 23.05.23] 시작****************************************************************/
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPRWKDAT_TAG CWIPRWKDAT;
	/* - [GERP PROJECT] 끝*****************************************************************/

	struct worktime_tag tmp_work_time;

	char s_sys_time[14];
	char s_system_workdate[8];
	int i_system_workshift;
	char c_shift = ' ';

	char s_msg_code[MP_SIZE_MSG];

	TRSNode* tran_in_node;
	TRSNode* tran_out_node;  

	memset(s_msg_code, ' ' , sizeof(s_msg_code));

	
	memset(s_system_workdate, ' ', sizeof(s_system_workdate));
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


	DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
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

	/* - [GERP PROJECT] [ERP 23.05.23] 시작****************************************************************/	
	// 23.05.03 패킹이력이 있을경우 폐기 Validation
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
	memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

	if (CDB_select_cwiplotpak_scalar(8, &CWIPLOTPAK) > 0)
	{
		// [ERP 23.05.23] 패킹되어있을 경우에는 폐기 불가
		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		CWIPLOTPAK.STATUS_FLAG = 'C';
		if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)		//패킹 되었으면 폐기 안됨
		{
			strcpy(s_msg_code, "WIP-0564");			
			TRS.add_fieldmsg(out_node, "CWIPRWKDAT SCALAR(2)", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		// [ERP 23.05.24] 재작업 오더가 있을떈 폐기 가능
		CDB_init_cwiprwkdat(&CWIPRWKDAT);
		memcpy(CWIPRWKDAT.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		memcpy(CWIPRWKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
		if (CDB_select_cwiprwkdat_scalar(2, &CWIPRWKDAT) == 0) // 재작업 오더 없음
		{
			strcpy(s_msg_code, "WIP-0616"); //재 작업 오더가 필요한 모듈입니다
			TRS.add_fieldmsg(out_node, "CWIPRWKDAT SCALAR(2)", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK.LOT_ID), CWIPLOTPAK.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	/* - [GERP PROJECT] 끝*****************************************************************/

	memset(&tmp_work_time, 0x00, sizeof(struct worktime_tag));
	CCOM_get_work_time(MWIPLOTSTS.CREATE_TIME, &tmp_work_time);
	memcpy(s_system_workdate, tmp_work_time.work_date, 8);
	i_system_workshift = tmp_work_time.work_shift;

	
	c_shift = CCOM_get_work_shift(tmp_work_time.work_date_start_time);

	DBC_init_mwiplothis(&MWIPLOTHIS);
	MWIPLOTHIS.LOT_CMF_16[0] = 'N';
	MWIPLOTSTS.LOT_CMF_16[0] = 'N';

    /* TODO : Insert your code */
	/*IS-21-01-049  include check function (Machine Error) cmf_16 */
	TRS.copy(MWIPLOTSTS.LOT_CMF_16, sizeof(MWIPLOTSTS.LOT_CMF_16), in_node, "TRAN_CMF_16");
	if(MWIPLOTSTS.LOT_CMF_16[0] == 'Y' && MWIPLOTSTS.LOT_DEL_FLAG == 'Y') // IS-21-01-094 MES logic °³¼±
	{
		MWIPLOTSTS.LOT_CMF_16[0] = 'Y';
		MWIPLOTHIS.LOT_CMF_16[0] = 'Y';
	}
	TRS.copy(MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17), in_node, "NUM_OF_STRINGS");
	DBC_update_mwiplotsts(1,&MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS) 
	{
		strcpy(s_msg_code, "WIP-0615");
		TRS.add_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
		TRS.add_fieldmsg(out_node, "MACHIN_ERROR_YN", MP_CHR, strlen("Y"), MWIPLOTSTS.LOT_CMF_16);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		
	DBC_select_mwiplothis(1,&MWIPLOTHIS);
	if(DB_error_code != DB_SUCCESS) 
	{
		//DO NOTHING
	}
	TRS.copy(MWIPLOTHIS.TRAN_CMF_17, sizeof(MWIPLOTHIS.TRAN_CMF_17), in_node, "NUM_OF_STRINGS");

	DBC_update_mwiplothis(1,&MWIPLOTHIS);
	if(DB_error_code != DB_SUCCESS) 
	{
		strcpy(s_msg_code, "WIP-0615");
		TRS.add_fieldmsg(out_node, "MWIPLOTHIS UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
		TRS.add_fieldmsg(out_node, "MACHIN_ERROR_YN", MP_CHR, strlen("Y"), MWIPLOTHIS.LOT_CMF_16);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_TRANS;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
	
	/*
	// IS-21-04-017 Terminate Module
	TRS.copy(MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17), in_node, "TRAN_CMF_17");
	TRS.copy(MWIPLOTSTS.LOT_CMF_18, sizeof(MWIPLOTSTS.LOT_CMF_18), in_node, "TRAN_CMF_18");
	if (COM_isspace(MWIPLOTSTS.LOT_CMF_17, sizeof(MWIPLOTSTS.LOT_CMF_17)) == MP_FALSE &&
		COM_isspace(MWIPLOTSTS.LOT_CMF_18, sizeof(MWIPLOTSTS.LOT_CMF_18)) == MP_FALSE)
	{
		DBC_update_mwiplotsts(1,&MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0615");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			TRS.add_fieldmsg(out_node, "MACHIN_ERROR_YN", MP_CHR, strlen("Y"), MWIPLOTSTS.LOT_CMF_16);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		DBC_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		MWIPLOTHIS.HIST_SEQ = MWIPLOTSTS.LAST_HIST_SEQ;
		
		DBC_select_mwiplothis(1,&MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS) 
		{
			//DO NOTHING
		}

		DBC_update_mwiplothis(1,&MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS) 
		{
			strcpy(s_msg_code, "WIP-0615");
			TRS.add_fieldmsg(out_node, "MWIPLOTHIS UPDATE", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);
			TRS.add_fieldmsg(out_node, "MACHIN_ERROR_YN", MP_CHR, strlen("Y"), MWIPLOTHIS.LOT_CMF_16);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_TRANS;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	*/

	// IS-21-05-028 Terminate Module Shift Ãß°¡°Ç °³¹ß
	CDB_init_cwiplotext(&CWIPLOTEXT);
	
    TRS.copy(CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1), in_node, "TERMINATE_SHIFT");	// CMF_1
    TRS.copy(CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2), in_node, "TERMINATE_PROCESS_CODE"); // CMF_2
    TRS.copy(CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3), in_node, "TERMINATE_EQ_CODE"); // CMF_3
	if (COM_isspace(CWIPLOTEXT.CMF_1, sizeof(CWIPLOTEXT.CMF_1)) == MP_FALSE &&
		COM_isspace(CWIPLOTEXT.CMF_2, sizeof(CWIPLOTEXT.CMF_2)) == MP_FALSE &&
		COM_isspace(CWIPLOTEXT.CMF_3, sizeof(CWIPLOTEXT.CMF_3)) == MP_FALSE)
	{
		// MP_TRAN_CODE_TERMINATE
		/* Terminate Lot Extention */
		tran_in_node = TRS.create_node("TERMINATE_LOT_EXTENTION_IN");
		tran_out_node = TRS.create_node("TERMINATE_LOT_EXTENTION_OUT");

		TRS.copy(CWIPLOTEXT.LOT_ID, sizeof(CWIPLOTEXT.LOT_ID), in_node, "LOT_ID");

		CDB_select_cwiplotext(1, &CWIPLOTEXT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {
                CCOM_copy_in_node(in_node, tran_in_node);
		        TRS.add_char(tran_in_node, "PROCSTEP", 'I');
		        TRS.add_string(tran_in_node, "LOT_ID", CWIPLOTEXT.LOT_ID, sizeof(CWIPLOTEXT.LOT_ID));
		        TRS.add_string(tran_in_node,  "CREATE_TIME", s_sys_time, sizeof(s_sys_time)); 

		        TRS.add_nstring(tran_in_node, "CMF_1", TRS.get_string(in_node, "TERMINATE_SHIFT"));
		        TRS.add_nstring(tran_in_node, "CMF_2", TRS.get_string(in_node, "TERMINATE_PROCESS_CODE"));
		        TRS.add_nstring(tran_in_node, "CMF_3", TRS.get_string(in_node, "TERMINATE_EQ_CODE"));

		        // INSERT TABLE
		        if(CWIP_UPDATE_LOT_EXTENTION(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		        {
			        // Do Nothing
		        }
		    }
            else
            {
                
            }
        }else
        {
            CCOM_copy_in_node(in_node, tran_in_node);
		    TRS.add_char(tran_in_node, "PROCSTEP", 'U');
		    TRS.add_string(tran_in_node, "LOT_ID", CWIPLOTEXT.LOT_ID, sizeof(CWIPLOTEXT.LOT_ID));

		    TRS.add_nstring(tran_in_node, "CMF_1", TRS.get_string(in_node, "TERMINATE_SHIFT"));
		    TRS.add_nstring(tran_in_node, "CMF_2", TRS.get_string(in_node, "TERMINATE_PROCESS_CODE"));
		    TRS.add_nstring(tran_in_node, "CMF_3", TRS.get_string(in_node, "TERMINATE_EQ_CODE"));

		    // UPDATE TABLE
		    if(CWIP_UPDATE_LOT_EXTENTION(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
		    {
			    // Do Nothing
		    }
        }

		

		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
	}

	DBC_init_mwipmatdef(&MWIPMATDEF);
    TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
    memcpy(MWIPMATDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
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

	if(memcmp(MWIPMATDEF.MAT_CMF_1, "MDL", strlen("MDL")) == 0)
	{

		CDB_init_rsumwiplos(&RSUMWIPLOS);
		TRS.copy(RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY), in_node, IN_FACTORY);
		memcpy(RSUMWIPLOS.CM_KEY_1, MWIPLOTSTS.LOT_CMF_1, sizeof(RSUMWIPLOS.CM_KEY_1));
		RSUMWIPLOS.CM_KEY_2[0] = c_shift;
		memcpy(RSUMWIPLOS.WORK_DATE, s_system_workdate, sizeof(RSUMWIPLOS.WORK_DATE));

		memcpy(RSUMWIPLOS.CM_KEY_3, "C006", strlen("C006"));
		memcpy(RSUMWIPLOS.LOSS_OPER, MWIPLOTSTS.OPER, sizeof(RSUMWIPLOS.LOSS_OPER));

		if(COM_isnullspace(MWIPLOTSTS.START_RES_ID) == MP_FALSE)
		{
			 memcpy(RSUMWIPLOS.RES_ID, MWIPLOTSTS.START_RES_ID, sizeof(RSUMWIPLOS.RES_ID));
		}
		else if(COM_isnullspace(MWIPLOTSTS.END_RES_ID) == MP_FALSE)
		{
			 memcpy(RSUMWIPLOS.RES_ID, MWIPLOTSTS.END_RES_ID, sizeof(RSUMWIPLOS.RES_ID));
		}
		else
		{

		}

		CDB_select_rsumwiplos(2,&RSUMWIPLOS);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				/* Insert */
				CDB_init_rsumwiplos(&RSUMWIPLOS);
				TRS.copy(RSUMWIPLOS.FACTORY, sizeof(RSUMWIPLOS.FACTORY), in_node, IN_FACTORY);
				memcpy(RSUMWIPLOS.CM_KEY_1, MWIPLOTSTS.LOT_CMF_1, sizeof(RSUMWIPLOS.CM_KEY_1));
				RSUMWIPLOS.CM_KEY_2[0] = c_shift;
				memcpy(RSUMWIPLOS.WORK_DATE, s_system_workdate, sizeof(RSUMWIPLOS.WORK_DATE));
				
				memcpy(RSUMWIPLOS.CM_KEY_3, "C006", strlen("C006"));
				memcpy(RSUMWIPLOS.LOSS_OPER, MWIPLOTSTS.OPER, sizeof(RSUMWIPLOS.LOSS_OPER));

				if(COM_isnullspace(MWIPLOTSTS.START_RES_ID) == MP_FALSE)
				{
					 memcpy(RSUMWIPLOS.RES_ID, MWIPLOTSTS.START_RES_ID, sizeof(RSUMWIPLOS.RES_ID));
				}
				else if(COM_isnullspace(MWIPLOTSTS.END_RES_ID) == MP_FALSE)
				{
					 memcpy(RSUMWIPLOS.RES_ID, MWIPLOTSTS.END_RES_ID, sizeof(RSUMWIPLOS.RES_ID));
				}
				else
				{

				}

				RSUMWIPLOS.LOSS_QTY = COM_atoi(MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));

				TRS.copy(RSUMWIPLOS.CREATE_USER_ID, sizeof(RSUMWIPLOS.CREATE_USER_ID), in_node, IN_USERID);
				memcpy(RSUMWIPLOS.CREATE_TIME, s_sys_time, sizeof(RSUMWIPLOS.CREATE_TIME));

				CDB_insert_rsumwiplos(&RSUMWIPLOS);
				if(DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "RSUMWIPLOS INSERT", MP_NVST);
					TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
					TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
					TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
					TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
					TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
					TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
					TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
					TRS.add_fieldmsg(out_node, "LOSS_QTY", MP_DBL, sizeof(RSUMWIPLOS.LOSS_QTY), RSUMWIPLOS.LOSS_QTY);
					TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(RSUMWIPLOS.LOSS_COMMENT), RSUMWIPLOS.LOSS_COMMENT);

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
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "RSUMWIPLOS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
				TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);

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
			/* Update */
			RSUMWIPLOS.LOSS_QTY = RSUMWIPLOS.LOSS_QTY + COM_atoi(MWIPMATDEF.MAT_CMF_3, sizeof(MWIPMATDEF.MAT_CMF_3));
			TRS.copy(RSUMWIPLOS.UPDATE_USER_ID, sizeof(RSUMWIPLOS.UPDATE_USER_ID), in_node, IN_USERID);
			memcpy(RSUMWIPLOS.UPDATE_TIME, s_sys_time, sizeof(RSUMWIPLOS.UPDATE_TIME));

			CDB_update_rsumwiplos(2,&RSUMWIPLOS);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "RSUMWIPLOS UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(RSUMWIPLOS.FACTORY), RSUMWIPLOS.FACTORY);
				TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_1), RSUMWIPLOS.CM_KEY_1);
				TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_2), RSUMWIPLOS.CM_KEY_2);
				TRS.add_fieldmsg(out_node, "CAUSE", MP_STR, sizeof(RSUMWIPLOS.CM_KEY_3), RSUMWIPLOS.CM_KEY_3);
				TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(RSUMWIPLOS.WORK_DATE), RSUMWIPLOS.WORK_DATE);
				TRS.add_fieldmsg(out_node, "LOSS_OPER", MP_STR, sizeof(RSUMWIPLOS.LOSS_OPER), RSUMWIPLOS.LOSS_OPER);
				TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(RSUMWIPLOS.RES_ID), RSUMWIPLOS.RES_ID);
				TRS.add_fieldmsg(out_node, "LOSS_QTY", MP_DBL, sizeof(RSUMWIPLOS.LOSS_QTY), RSUMWIPLOS.LOSS_QTY);
				TRS.add_fieldmsg(out_node, "LOSS_COMMENT", MP_STR, sizeof(RSUMWIPLOS.LOSS_COMMENT), RSUMWIPLOS.LOSS_COMMENT);

				TRS.add_dberrmsg(out_node,DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}

		}
	}

		//ERP폐기/폐기취소 전송(2025.12.01)
	{
		//Cleaving Half Cell Confirm ERP Interface 수행
		TRS.set_string(in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.set_string(in_node, "BACK_TIME", s_sys_time, sizeof(s_sys_time));
		TRS.set_char(in_node, "INF_UPLOAD_TYPE_FLAG", '7'); 

		if (CINF_UPLOAD_ERP_FUNCTION(s_msg_code,in_node, out_node ) == MP_FALSE)
		{
			//ERROR 
			DB_rollback();
		}
		//if (CSUM_SUMMARY_WIP_TRAN_TERMINATELOT(s_msg_code, &MTMPLOTHIS, in_node, out_node) == MP_FALSE)
		//{
			//ERROR 
		//	DB_rollback();
		//}
	}

    return MP_TRUE;
}

