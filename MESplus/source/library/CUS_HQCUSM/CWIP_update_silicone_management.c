/*******************************************************************************

    System      : MESplus
    Module      : Update Silicone Management
    File Name   : CWIP_update_silicone_Management.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.06.13  yeonkeun.lim

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_UPDATE_SILICONE_MANAGEMENT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Update_Silicone_Management()
        - CWIP_Update_Silicone_Management
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Silicone_Management(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_SILICONE_MANAGEMENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_SILICONE_MANAGEMENT", out_node);

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
    CWIP_UPDATE_SILICONE_MANAGEMENT()
        - UPDATE_SILICONE_MANAGEMENT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_SILICONE_MANAGEMENT(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPSILMNG_TAG CWIPSILMNG;
	//struct CWIPSILMNG_TAG CWIPSILMNG_TMP;
	struct CWIPSILHIS_TAG CWIPSILHIS;
	//struct MGCMLAGDAT_TAG MGCMLAGDAT;

	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CWIP_UPDATE_SILICONE_MANAGEMENT");
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

		//CDB_init_mgcmlagdat(&MGCMLAGDAT);
		//TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
		//TRS.copy(MGCMLAGDAT.TABLE_NAME, sizeof(MGCMLAGDAT.TABLE_NAME), in_node, "TABLE_NAME");
		//TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "SILICONE_TYPE");

		CDB_init_cwipsilmng(&CWIPSILMNG);
		TRS.copy(CWIPSILMNG.FACTORY, sizeof(CWIPSILMNG.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPSILMNG.NAME, sizeof(CWIPSILMNG.NAME), in_node, "NAME");
		TRS.copy(CWIPSILMNG.TABLE_NAME, sizeof(CWIPSILMNG.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(CWIPSILMNG.LINE, sizeof(CWIPSILMNG.LINE), in_node, "LINE");
		TRS.copy(CWIPSILMNG.SILICONE_TYPE, sizeof(CWIPSILMNG.SILICONE_TYPE), in_node, "SILICONE_TYPE");
		TRS.copy(CWIPSILMNG.SILICONE_SIDE, sizeof(CWIPSILMNG.SILICONE_SIDE), in_node, "SILICONE_SIDE");
		
		TRS.copy(CWIPSILMNG.LEFT_WEIGHT, sizeof(CWIPSILMNG.LEFT_WEIGHT), in_node, "LEFT_WEIGHT");
		TRS.copy(CWIPSILMNG.LEFT_WEIGHT_RESULT, sizeof(CWIPSILMNG.LEFT_WEIGHT_RESULT), in_node, "LEFT_WEIGHT_RESULT");
		TRS.copy(CWIPSILMNG.RIGHT_WEIGHT, sizeof(CWIPSILMNG.RIGHT_WEIGHT), in_node, "RIGHT_WEIGHT");
		TRS.copy(CWIPSILMNG.RIGHT_WEIGHT_RESULT, sizeof(CWIPSILMNG.RIGHT_WEIGHT_RESULT), in_node, "RIGHT_WEIGHT_RESULT");
		TRS.copy(CWIPSILMNG.CENTER_WEIGHT, sizeof(CWIPSILMNG.CENTER_WEIGHT), in_node, "CENTER_WEIGHT");
		TRS.copy(CWIPSILMNG.CENTER_WEIGHT_RESULT, sizeof(CWIPSILMNG.CENTER_WEIGHT_RESULT), in_node, "CENTER_WEIGHT_RESULT");
		TRS.copy(CWIPSILMNG.POTTING_WEIGHT_A, sizeof(CWIPSILMNG.POTTING_WEIGHT_A), in_node, "POTTING_WEIGHT_A");
		TRS.copy(CWIPSILMNG.POTTING_WEIGHT_B, sizeof(CWIPSILMNG.POTTING_WEIGHT_B), in_node, "POTTING_WEIGHT_B");
		TRS.copy(CWIPSILMNG.POTTING_WEIGHT_RATIO, sizeof(CWIPSILMNG.POTTING_WEIGHT_RATIO), in_node, "POTTING_WEIGHT_RATIO");
		TRS.copy(CWIPSILMNG.RATIO_WEIGHT_RESULT, sizeof(CWIPSILMNG.RATIO_WEIGHT_RESULT), in_node, "RATIO_WEIGHT_RESULT");

		TRS.copy(CWIPSILMNG.FRAME_SHORT_WEIGHT, sizeof(CWIPSILMNG.FRAME_SHORT_WEIGHT), in_node, "FRAME_SHORT_WEIGHT");
		TRS.copy(CWIPSILMNG.FRAME_SHORT_RESULT, sizeof(CWIPSILMNG.FRAME_SHORT_RESULT), in_node, "FRAME_SHORT_RESULT");
		TRS.copy(CWIPSILMNG.FRAME_LONG_WEIGHT, sizeof(CWIPSILMNG.FRAME_LONG_WEIGHT), in_node, "FRAME_LONG_WEIGHT");
		TRS.copy(CWIPSILMNG.FRAME_LONG_RESULT, sizeof(CWIPSILMNG.FRAME_LONG_RESULT), in_node, "FRAME_LONG_RESULT");
		TRS.copy(CWIPSILMNG.FRAME_MODULE_TYPE, sizeof(CWIPSILMNG.FRAME_MODULE_TYPE), in_node, "FRAME_MODULE_TYPE");

		TRS.copy(CWIPSILMNG.CREATE_USER_ID, sizeof(CWIPSILMNG.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		//memcpy(CWIPSILMNG.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CWIPSILMNG.COMMENT_CONT, sizeof(CWIPSILMNG.COMMENT_CONT), in_node, "COMMENT_CONT");
		TRS.copy(CWIPSILMNG.CREATE_TIME, sizeof(CWIPSILMNG.CREATE_TIME), in_node, "CREATE_TIME");

		//현재 삭제 START
		CDB_delete_cwipsilmng(1,&CWIPSILMNG);
		if(DB_error_code != DB_SUCCESS)
		{
			//Do Nothing
		}
	
		//현재 삭제 END
		//신규 데이터 저장 START
		CDB_insert_cwipsilmng(&CWIPSILMNG);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPSILMNG INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSILMNG.FACTORY), CWIPSILMNG.FACTORY);
			TRS.add_fieldmsg(out_node, "NAME", MP_STR, sizeof(CWIPSILMNG.NAME), CWIPSILMNG.NAME);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(CWIPSILMNG.TABLE_NAME), CWIPSILMNG.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CWIPSILMNG.LINE), CWIPSILMNG.LINE);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		
		//신규 데이터 저장 END

		//히스토리 저장 START
		CDB_init_cwipsilhis(&CWIPSILHIS);
		TRS.copy(CWIPSILHIS.FACTORY, sizeof(CWIPSILHIS.FACTORY), in_node, "FACTORY");
		TRS.copy(CWIPSILHIS.NAME, sizeof(CWIPSILHIS.NAME), in_node, "NAME");
		TRS.copy(CWIPSILHIS.TABLE_NAME, sizeof(CWIPSILHIS.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(CWIPSILHIS.LINE, sizeof(CWIPSILHIS.LINE), in_node, "LINE");
		TRS.copy(CWIPSILHIS.SILICONE_TYPE, sizeof(CWIPSILHIS.SILICONE_TYPE), in_node, "SILICONE_TYPE");
		TRS.copy(CWIPSILHIS.SILICONE_SIDE, sizeof(CWIPSILHIS.SILICONE_SIDE), in_node, "SILICONE_SIDE");
		
		TRS.copy(CWIPSILHIS.LEFT_WEIGHT, sizeof(CWIPSILHIS.LEFT_WEIGHT), in_node, "LEFT_WEIGHT");
		TRS.copy(CWIPSILHIS.LEFT_WEIGHT_RESULT, sizeof(CWIPSILHIS.LEFT_WEIGHT_RESULT), in_node, "LEFT_WEIGHT_RESULT");
		TRS.copy(CWIPSILHIS.RIGHT_WEIGHT, sizeof(CWIPSILHIS.RIGHT_WEIGHT), in_node, "RIGHT_WEIGHT");
		TRS.copy(CWIPSILHIS.RIGHT_WEIGHT_RESULT, sizeof(CWIPSILHIS.RIGHT_WEIGHT_RESULT), in_node, "RIGHT_WEIGHT_RESULT");
		TRS.copy(CWIPSILHIS.CENTER_WEIGHT, sizeof(CWIPSILHIS.CENTER_WEIGHT), in_node, "CENTER_WEIGHT");
		TRS.copy(CWIPSILHIS.CENTER_WEIGHT_RESULT, sizeof(CWIPSILHIS.CENTER_WEIGHT_RESULT), in_node, "CENTER_WEIGHT_RESULT");
		TRS.copy(CWIPSILHIS.POTTING_WEIGHT_A, sizeof(CWIPSILHIS.POTTING_WEIGHT_A), in_node, "POTTING_WEIGHT_A");
		TRS.copy(CWIPSILHIS.POTTING_WEIGHT_B, sizeof(CWIPSILHIS.POTTING_WEIGHT_B), in_node, "POTTING_WEIGHT_B");
		TRS.copy(CWIPSILHIS.POTTING_WEIGHT_RATIO, sizeof(CWIPSILHIS.POTTING_WEIGHT_RATIO), in_node, "POTTING_WEIGHT_RATIO");
		TRS.copy(CWIPSILHIS.RATIO_WEIGHT_RESULT, sizeof(CWIPSILHIS.RATIO_WEIGHT_RESULT), in_node, "RATIO_WEIGHT_RESULT");

		TRS.copy(CWIPSILHIS.FRAME_SHORT_WEIGHT, sizeof(CWIPSILHIS.FRAME_SHORT_WEIGHT), in_node, "FRAME_SHORT_WEIGHT");
		TRS.copy(CWIPSILHIS.FRAME_SHORT_RESULT, sizeof(CWIPSILHIS.FRAME_SHORT_RESULT), in_node, "FRAME_SHORT_RESULT");
		TRS.copy(CWIPSILHIS.FRAME_LONG_WEIGHT, sizeof(CWIPSILHIS.FRAME_LONG_WEIGHT), in_node, "FRAME_LONG_WEIGHT");
		TRS.copy(CWIPSILHIS.FRAME_LONG_RESULT, sizeof(CWIPSILHIS.FRAME_LONG_RESULT), in_node, "FRAME_LONG_RESULT");
		TRS.copy(CWIPSILHIS.FRAME_MODULE_TYPE, sizeof(CWIPSILHIS.FRAME_MODULE_TYPE), in_node, "FRAME_MODULE_TYPE");



		TRS.copy(CWIPSILHIS.CREATE_USER_ID, sizeof(CWIPSILHIS.CREATE_USER_ID), in_node, "CREATE_USER_ID");
		//memcpy(CWIPSILHIS.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
		TRS.copy(CWIPSILHIS.CREATE_TIME, sizeof(CWIPSILHIS.CREATE_TIME), in_node, "CREATE_TIME");

		TRS.copy(CWIPSILHIS.COMMENT_CONT, sizeof(CWIPSILHIS.COMMENT_CONT), in_node, "COMMENT_CONT");

		CDB_insert_cwipsilhis(&CWIPSILHIS);

		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPSILHIS INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPSILHIS.FACTORY), CWIPSILHIS.FACTORY);
			TRS.add_fieldmsg(out_node, "NAME", MP_STR, sizeof(CWIPSILHIS.NAME), CWIPSILHIS.NAME);
			TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(CWIPSILHIS.TABLE_NAME), CWIPSILHIS.TABLE_NAME);
			TRS.add_fieldmsg(out_node, "LINE", MP_STR, sizeof(CWIPSILHIS.LINE), CWIPSILHIS.LINE);
			TRS.add_dberrmsg(out_node, DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		//히스토리 저장 END
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}