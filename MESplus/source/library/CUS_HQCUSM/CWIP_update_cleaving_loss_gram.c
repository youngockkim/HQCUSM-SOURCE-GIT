/*******************************************************************************

    System      : MESplus
    Module      : Update Cleaving Loss_Gram
    File Name   : CWIP_update_cleaving_loss_Gram.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.8.2    sy7.kwon       Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_Update_Cleaving_Loss_Gram_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
int CWIP_UPDATE_CLEAVING_LOSS_GRAM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);


/*******************************************************************************
    CWIP_Update_Cleaving_Loss_GRAM()
        - Update Cleaving Loss
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Cleaving_Loss_Gram(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_CLEAVING_LOSS_GRAM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Update_Cleaving_Loss_Gram", out_node);

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
    CWIP_UPDATE_CLEAVING_LOSS_GRAM()
        - UPDATE_CLEAVING_LOSS_GRAM
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_CLEAVING_LOSS_GRAM(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct MRASRESDEF_TAG MRASRESDEF;
	struct CWIPCLVLOS_TAG CWIPCLVLOS;

	char s_sys_time[14];
	
	LOG_head("CWIP_UPDATE_CLEAVING_LOSS_GRAM");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(CWIP_Update_Cleaving_Loss_Gram_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
    memset(s_sys_time, ' ', sizeof(s_sys_time));
    DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);

		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;

        COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
	
	//memset(s_sys_time, ' ', sizeof(s_sys_time));
	//memcpy(s_sys_time, s_sys_time_stamp, sizeof(s_sys_time));
	//memcpy(s_actual_time, s_sys_time_stamp, sizeof(s_actual_time));

	// 작업일자 조회
	//CCOM_get_work_time(s_actual_time, &cur_work_time);

	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "RAS-0003");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT #1", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
			
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "RAS-0004");
            TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT #1", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
            TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);
			
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;

            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}
	
	CDB_init_cwipclvlos(&CWIPCLVLOS);
	TRS.copy(CWIPCLVLOS.FACTORY, sizeof(CWIPCLVLOS.FACTORY), in_node, "FACTORY");
	TRS.copy(CWIPCLVLOS.WORK_DATE, sizeof(CWIPCLVLOS.WORK_DATE), in_node, "WORK_DATE");
	TRS.copy(CWIPCLVLOS.WORK_SHIFT, sizeof(CWIPCLVLOS.WORK_SHIFT), in_node, "WORK_SHIFT");
	TRS.copy(CWIPCLVLOS.LINE_ID, sizeof(CWIPCLVLOS.LINE_ID), in_node, "LINE_ID");
	TRS.copy(CWIPCLVLOS.RES_ID, sizeof(CWIPCLVLOS.RES_ID), in_node, "RES_ID");
	TRS.copy(CWIPCLVLOS.MAT_ID, sizeof(CWIPCLVLOS.MAT_ID), in_node, "MAT_ID");
	CWIPCLVLOS.LOSS_SEQ = TRS.get_double(in_node, "LOSS_SEQ");

	CDB_select_cwipclvlos(1, &CWIPCLVLOS);
	if(DB_error_code != DB_SUCCESS && DB_error_code != DB_NOT_FOUND)
    {
        strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCLVLOS SELECT #1", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVLOS.FACTORY), CWIPCLVLOS.FACTORY);
        TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCLVLOS.WORK_DATE), CWIPCLVLOS.WORK_DATE);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPCLVLOS.WORK_SHIFT), CWIPCLVLOS.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVLOS.LINE_ID), CWIPCLVLOS.LINE_ID);
        TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPCLVLOS.RES_ID), CWIPCLVLOS.RES_ID);
		TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPCLVLOS.MAT_ID), CWIPCLVLOS.MAT_ID);
		TRS.add_fieldmsg(out_node, "LOSS_SEQ", MP_DBL, CWIPCLVLOS.LOSS_SEQ);
        TRS.add_dberrmsg(out_node,DB_error_msg);
		
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}
	
	TRS.copy(CWIPCLVLOS.EFF, sizeof(CWIPCLVLOS.EFF), in_node, "EFF");
	TRS.copy(CWIPCLVLOS.GRADE, sizeof(CWIPCLVLOS.GRADE), in_node, "GRADE");

	CWIPCLVLOS.INPUT_QTY = TRS.get_double(in_node, "INPUT_QTY");
	CWIPCLVLOS.OUT_QTY = TRS.get_double(in_node, "OUT_QTY");

	//기존 입력 값 삭제 후 모두 CMF_1~5필드로 정리
		

	TRS.copy(CWIPCLVLOS.CMF_1, sizeof(CWIPCLVLOS.CMF_1), in_node, "UNPACK_BROKEN");
	TRS.copy(CWIPCLVLOS.CMF_2, sizeof(CWIPCLVLOS.CMF_2), in_node, "FULL_CHIP");
	TRS.copy(CWIPCLVLOS.CMF_3, sizeof(CWIPCLVLOS.CMF_3), in_node, "FULL_BROKEN");
	TRS.copy(CWIPCLVLOS.CMF_4, sizeof(CWIPCLVLOS.CMF_4), in_node, "HALF_BROKEN");
	TRS.copy(CWIPCLVLOS.CMF_5, sizeof(CWIPCLVLOS.CMF_5), in_node, "CJ");

	TRS.copy(CWIPCLVLOS.CMF_6, sizeof(CWIPCLVLOS.CMF_6), in_node, "UNPACK_COMMENT");
	TRS.copy(CWIPCLVLOS.CMF_7, sizeof(CWIPCLVLOS.CMF_7), in_node, "FULL_COMMENT");
	TRS.copy(CWIPCLVLOS.CMF_8, sizeof(CWIPCLVLOS.CMF_8), in_node, "HALF_COMMENT");
	TRS.copy(CWIPCLVLOS.CMF_9, sizeof(CWIPCLVLOS.CMF_9), in_node, "CJ_COMMENT");
	
	

    if (TRS.get_procstep(in_node) == MP_STEP_CREATE)
	{
		// CREATE 일때 LOSS_SEQ 를 +1 해준다.
		CWIPCLVLOS.LOSS_SEQ = CDB_select_cwipclvlos_scalar(2, &CWIPCLVLOS) + 1;
		TRS.copy(CWIPCLVLOS.CREATE_USER_ID, sizeof(CWIPCLVLOS.CREATE_USER_ID), in_node, "LINE_ID");
		memcpy(CWIPCLVLOS.CREATE_TIME, s_sys_time, sizeof(CWIPCLVLOS.CREATE_TIME));
		CDB_insert_cwipclvlos(&CWIPCLVLOS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPCLVLOS INSERT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVLOS.FACTORY), CWIPCLVLOS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCLVLOS.WORK_DATE), CWIPCLVLOS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPCLVLOS.WORK_SHIFT), CWIPCLVLOS.WORK_SHIFT);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVLOS.LINE_ID), CWIPCLVLOS.LINE_ID);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPCLVLOS.RES_ID), CWIPCLVLOS.RES_ID);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPCLVLOS.MAT_ID), CWIPCLVLOS.MAT_ID);
			TRS.add_fieldmsg(out_node, "LOSS_SEQ", MP_DBL, CWIPCLVLOS.LOSS_SEQ);
			TRS.add_dberrmsg(out_node,DB_error_msg);
		
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	else if (TRS.get_procstep(in_node) == MP_STEP_UPDATE)
	{
		TRS.copy(CWIPCLVLOS.UPDATE_USER_ID, sizeof(CWIPCLVLOS.UPDATE_USER_ID), in_node, "USERID");
		memcpy(CWIPCLVLOS.UPDATE_TIME, s_sys_time, sizeof(CWIPCLVLOS.UPDATE_TIME));
		CDB_update_cwipclvlos(1, &CWIPCLVLOS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPCLVLOS UPDATE #1", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVLOS.FACTORY), CWIPCLVLOS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCLVLOS.WORK_DATE), CWIPCLVLOS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPCLVLOS.WORK_SHIFT), CWIPCLVLOS.WORK_SHIFT);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVLOS.LINE_ID), CWIPCLVLOS.LINE_ID);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPCLVLOS.RES_ID), CWIPCLVLOS.RES_ID);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPCLVLOS.MAT_ID), CWIPCLVLOS.MAT_ID);
			TRS.add_fieldmsg(out_node, "EFF", MP_STR, sizeof(CWIPCLVLOS.EFF), CWIPCLVLOS.EFF);
			TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(CWIPCLVLOS.GRADE), CWIPCLVLOS.GRADE);
			TRS.add_fieldmsg(out_node, "LOSS_SEQ", MP_DBL, CWIPCLVLOS.LOSS_SEQ);
			TRS.add_dberrmsg(out_node,DB_error_msg);
		
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
	else if (TRS.get_procstep(in_node) == MP_STEP_DELETE)
	{
		CDB_delete_cwipclvlos(1, &CWIPCLVLOS);
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPCLVLOS DELETE #1", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVLOS.FACTORY), CWIPCLVLOS.FACTORY);
			TRS.add_fieldmsg(out_node, "WORK_DATE", MP_STR, sizeof(CWIPCLVLOS.WORK_DATE), CWIPCLVLOS.WORK_DATE);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPCLVLOS.WORK_SHIFT), CWIPCLVLOS.WORK_SHIFT);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVLOS.LINE_ID), CWIPCLVLOS.LINE_ID);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(CWIPCLVLOS.RES_ID), CWIPCLVLOS.RES_ID);
			TRS.add_fieldmsg(out_node, "MAT_ID", MP_STR, sizeof(CWIPCLVLOS.MAT_ID), CWIPCLVLOS.MAT_ID);
			TRS.add_fieldmsg(out_node, "EFF", MP_STR, sizeof(CWIPCLVLOS.EFF), CWIPCLVLOS.EFF);
			TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(CWIPCLVLOS.GRADE), CWIPCLVLOS.GRADE);
			TRS.add_fieldmsg(out_node, "LOSS_SEQ", MP_DBL, CWIPCLVLOS.LOSS_SEQ);
			TRS.add_dberrmsg(out_node,DB_error_msg);
		
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}
			
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

/*******************************************************************************
	CWIP_View_Material_List_By_Production_Validation()
		- Main sub function of "CWIP_View_Material_List_By_Production" function
		- Check the condition for View Operation
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_Update_Cleaving_Loss_Gram_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

	struct tm tm_curr, tm_work;
	char s_curr_time[14];
	char s_work_time[14];
	char s_calc_work_time[14];

	int i_diff_sec;

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

	//2019 11 11 일에 입력하면
	//2019 11 13 일 05:59:59 까지는 수정 삭제가 가능해야 한다.
	//현재 시간이 SCRAP_DATE + 2일 05:59:59 보다 크면 에러 
	memset(s_curr_time, ' ', sizeof(s_curr_time));
	DB_get_systime(s_curr_time);
	if(DB_error_code != DB_SUCCESS)
	{
		TRS.add_fieldmsg(out_node, "DB_get_systime_m", MP_NVST);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_COMMON;

		COM_set_result(out_node, MP_FAIL_C, "CMN-0004", MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}
		
	memset(s_work_time, ' ', sizeof(s_work_time));
	TRS.copy(s_work_time, sizeof(s_work_time), in_node, "WORK_DATE");
	memcpy(s_work_time+8, "055959", strlen("055959"));

	// 입력받은 scrap date + 2일 한 값의 05:59:59 까지 수정가능		
	// work_time 에 +2일 하여 수정가능한 최종 시간 구한다.
	DB_get_calc_time(s_calc_work_time, s_work_time, 3, 2);		

	COM_diff_time_sec(&i_diff_sec, s_curr_time, s_calc_work_time);

	// 현재 시간이 최종 작업가능 시간 보다 크면 수정 불가
	// 그 외에는 수정 가능
	if (i_diff_sec > 0)
	{
		// 수정 가능한 시간이 지났습니다.
		strcpy(s_msg_code, "WIP-0601");
		TRS.add_fieldmsg(out_node, "UPDATE TIME CHECK", MP_NVST);
		TRS.add_fieldmsg(out_node, "LIMIT TIME", MP_STR, sizeof(s_calc_work_time), s_calc_work_time);
		TRS.add_fieldmsg(out_node, "CURRENT TIME", MP_STR, sizeof(s_curr_time), s_curr_time);
		TRS.add_dberrmsg(out_node, DB_error_msg);

		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_VALIDATION;
		gs_log_type.category = MP_LOG_CATE_SETUP;
		return MP_FALSE;
	}	

    return MP_TRUE;
}