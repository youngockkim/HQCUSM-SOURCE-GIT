/*******************************************************************************

    System      : MESplus
    Module      : Update AC Module Remove
    File Name   : CWIP_update_acmodule_remove.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.06.24  yeonkeun.lim

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_UPDATE_ACMODULE_REMOVE(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Update_Acmodule_Remove()
        - CWIP_update_acmodule_remove
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Acmodule_Remove(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_ACMODULE_REMOVE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_ACMODULE_REMOVE", out_node);

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
    CWIP_UPDATE_ACMODULE_REMOVE()
        - UPDATE_ACMODULE_REMOVE
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_ACMODULE_REMOVE(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPACMHIS_TAG CWIPACMHIS;
	struct CWIPACMHIS_TAG CWIPACMHIS_A;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS_S;

	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_ACMODULE_REMOVE");
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
	if(TRS.get_procstep(in_node) == '1') 
	{
		CDB_init_mwiplotsts(&MWIPLOTSTS_S);
		TRS.copy(MWIPLOTSTS_S.LOT_ID, sizeof(MWIPLOTSTS_S.LOT_ID), in_node, "LOT_ID");

		CDB_select_mwiplotsts(1, &MWIPLOTSTS_S);

		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0603");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS_S.LOT_ID), MWIPLOTSTS_S.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS_A.LOT_ID), CWIPACMHIS_A.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}
		
		if(COM_isnullspace(MWIPLOTSTS_S.LOT_CMF_15) == MP_TRUE)
		{
			strcpy(s_msg_code, "WIP-0605");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS_S.LOT_ID), MWIPLOTSTS_S.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		CDB_init_cwipacmhis(&CWIPACMHIS_A);
		TRS.copy(CWIPACMHIS_A.FACTORY, sizeof(CWIPACMHIS_A.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPACMHIS_A.LOT_ID, sizeof(CWIPACMHIS_A.LOT_ID), in_node, "LOT_ID");
		TRS.copy(CWIPACMHIS_A.PCU_SN, sizeof(CWIPACMHIS_A.PCU_SN), in_node, "PCU_SN");
		CWIPACMHIS_A.CMF_1[0] = 'D';

		CDB_select_cwipacmhis(1, &CWIPACMHIS_A);

		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0604");
				TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPACMHIS_A.FACTORY), CWIPACMHIS_A.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS_A.LOT_ID), CWIPACMHIS_A.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPACMHIS_A.FACTORY), CWIPACMHIS_A.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS_A.LOT_ID), CWIPACMHIS_A.LOT_ID);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
		}

		if(COM_isnullspace(CWIPACMHIS_A.LOT_ID) == MP_TRUE)
		{
			strcpy(s_msg_code, "WIP-0603");
			TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPACMHIS_A.FACTORY), CWIPACMHIS_A.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS_A.LOT_ID), CWIPACMHIS_A.LOT_ID);
			TRS.add_fieldmsg(out_node, "PCU_SN", MP_STR, sizeof(CWIPACMHIS_A.PCU_SN), CWIPACMHIS_A.PCU_SN);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else if(COM_isnullspace(MWIPLOTSTS_S.LOT_CMF_15) == MP_TRUE) 
		{
			strcpy(s_msg_code, "WIP-0605");
			TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPACMHIS_A.FACTORY), CWIPACMHIS_A.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS_A.LOT_ID), CWIPACMHIS_A.LOT_ID);
			TRS.add_fieldmsg(out_node, "PCU_SN", MP_STR, sizeof(CWIPACMHIS_A.PCU_SN), CWIPACMHIS_A.PCU_SN);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		//validation check
		if(COM_isnullspace(CWIPACMHIS_A.LOT_ID) == MP_FALSE
			&& COM_isnullspace(MWIPLOTSTS_S.LOT_CMF_15) == MP_FALSE)
		{
			//LOT MASTER UPDATE START
			DBC_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
			memset(MWIPLOTSTS.LOT_CMF_15, ' ', sizeof(MWIPLOTSTS.LOT_CMF_15));
			
			CDB_update_mwiplotsts(10, &MWIPLOTSTS);
			
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "MWIPLOTSTS UPDATE", MP_NVST);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
				TRS.add_fieldmsg(out_node, "LOT_CMF_15", MP_STR, sizeof(MWIPLOTSTS.LOT_CMF_15), MWIPLOTSTS.LOT_CMF_15);
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			//LOT MASTER UPDATE END

			//AC MODULE HISTORY INSERT START
			CDB_init_cwipacmhis(&CWIPACMHIS);
			memcpy(CWIPACMHIS.CLIENT_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(CWIPACMHIS.FACTORY, CWIPACMHIS_A.FACTORY, sizeof(CWIPACMHIS_A.FACTORY));
			memcpy(CWIPACMHIS.LOT_ID, CWIPACMHIS_A.LOT_ID, sizeof(CWIPACMHIS_A.LOT_ID));
			memcpy(CWIPACMHIS.RES_ID, CWIPACMHIS_A.RES_ID, sizeof(CWIPACMHIS_A.RES_ID));
			memcpy(CWIPACMHIS.PCU_SN, CWIPACMHIS_A.PCU_SN, sizeof(CWIPACMHIS_A.PCU_SN));
			memcpy(CWIPACMHIS.ACM_SN, CWIPACMHIS_A.ACM_SN, sizeof(CWIPACMHIS_A.ACM_SN));
			CWIPACMHIS.CMF_1[0] = 'C';
			memcpy(CWIPACMHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(CWIPACMHIS.CREATE_USER_ID, CWIPACMHIS_A.CREATE_USER_ID, sizeof(CWIPACMHIS_A.CREATE_USER_ID));

			CDB_insert_cwipacmhis(&CWIPACMHIS);
			
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				//AC 모듈 정보가 오류가 있습니다. 관리자에게 문의해주세요.
				TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
				TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPACMHIS.FACTORY), CWIPACMHIS.FACTORY);
				TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS.LOT_ID), CWIPACMHIS.LOT_ID);
				TRS.add_fieldmsg(out_node, "PCU_SN", MP_STR, sizeof(CWIPACMHIS.PCU_SN), CWIPACMHIS.PCU_SN);
				
				TRS.add_dberrmsg(out_node, DB_error_msg);

				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_SETUP;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;
			}
			//AC MODULE HISTORY INSERT END

		}
		else
		{
			//AC MODULE UNNORMAL
			strcpy(s_msg_code, "WIP-0604");//AC모듈 정보가 일치하지 않습니다. 다시 확인해주세요.
			TRS.add_fieldmsg(out_node, "CWIPACMHIS SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPACMHIS.FACTORY), CWIPACMHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPACMHIS.LOT_ID), CWIPACMHIS.LOT_ID);
			TRS.add_fieldmsg(out_node, "PCU_SN", MP_STR, sizeof(CWIPACMHIS.PCU_SN), CWIPACMHIS.PCU_SN);
			TRS.add_fieldmsg(out_node, "ACM_SN", MP_STR, sizeof(CWIPACMHIS.ACM_SN), CWIPACMHIS.ACM_SN);
				
			TRS.add_dberrmsg(out_node, DB_error_msg);
			
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}