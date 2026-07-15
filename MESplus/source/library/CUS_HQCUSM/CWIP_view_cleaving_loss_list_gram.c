/*******************************************************************************

    System      : MESplus
    Module      : View Cleaving Loss List_GRAM
    File Name   : CWIP_update_cleaving_loss_list_gram.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.10.19    yoock.kim       Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_CLEAVING_LOSS_LIST_GRAM(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Update_Cleaving_Loss_Gram()
        - Update Cleaving Production_Gram
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Cleaving_Loss_List_Gram(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_CLEAVING_LOSS_LIST_GRAM(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Cleaving_Loss_List_Gram", out_node);

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
    CWIP_VIEW_CLEAVING_LOSS_LIST_GRAM()
        - VIEW CLEAVING LOSS LIST_GRAM
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_CLEAVING_LOSS_LIST_GRAM(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
	struct CWIPCLVLOS_TAG CWIPCLVLOS;
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_LINE;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_SHIFT;
	//double i_step; //int형으로 변경 2023-07-04
	int i_step;
	double ret_cmf1 = 0;
	double ret_cmf2 = 0;
	double ret_cmf3 = 0;
	double ret_cmf4 = 0;
	double ret_cmf5 = 0;

    TRSNode *list_item;

	LOG_head("CWIP_VIEW_CLEAVING_LOSS_LIST_GRAM");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	//i_step을 3에서 4로 변경
	//i_step = 3;	
	i_step = 4;

    CDB_init_cwipclvlos(&CWIPCLVLOS);
    TRS.copy(CWIPCLVLOS.FACTORY, sizeof(CWIPCLVLOS.FACTORY), in_node, IN_FACTORY);
	

	TRS.copy(CWIPCLVLOS.CMF_9, strlen("99991231"), in_node, "FROM_DATE");
    TRS.copy(CWIPCLVLOS.CMF_10, strlen("99991231"), in_node, "TO_DATE");

    TRS.copy(CWIPCLVLOS.WORK_SHIFT, sizeof(CWIPCLVLOS.WORK_SHIFT), in_node, "WORK_SHIFT");
    TRS.copy(CWIPCLVLOS.LINE_ID, sizeof(CWIPCLVLOS.LINE_ID), in_node, "LINE_ID");
  
    CDB_open_cwipclvlos(i_step, &CWIPCLVLOS);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "CWIPCLVLOS OPEN #2", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVLOS.FACTORY), CWIPCLVLOS.FACTORY);
        TRS.add_fieldmsg(out_node, "FROM_DATE", MP_STR, sizeof(CWIPCLVLOS.CMF_1), CWIPCLVLOS.CMF_1);
        TRS.add_fieldmsg(out_node, "TO_DATE", MP_STR, sizeof(CWIPCLVLOS.CMF_2), CWIPCLVLOS.CMF_2);
        TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPCLVLOS.WORK_SHIFT), CWIPCLVLOS.WORK_SHIFT);
        TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVLOS.LINE_ID), CWIPCLVLOS.LINE_ID);
        TRS.add_dberrmsg(out_node,DB_error_msg);
		
		TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
		TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;

        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	while(1)
	{
        CDB_fetch_cwipclvlos(i_step, &CWIPCLVLOS);
		if(DB_error_code == DB_NOT_FOUND)
		{
            CDB_close_cwipclvlos(i_step);
			break;
		}
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "CWIPCLVLOS FETCH #2", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(CWIPCLVLOS.FACTORY), CWIPCLVLOS.FACTORY);
			TRS.add_fieldmsg(out_node, "FROM_DATE", MP_STR, sizeof(CWIPCLVLOS.CMF_1), CWIPCLVLOS.CMF_1);
			TRS.add_fieldmsg(out_node, "TO_DATE", MP_STR, sizeof(CWIPCLVLOS.CMF_2), CWIPCLVLOS.CMF_2);
			TRS.add_fieldmsg(out_node, "WORK_SHIFT", MP_STR, sizeof(CWIPCLVLOS.WORK_SHIFT), CWIPCLVLOS.WORK_SHIFT);
			TRS.add_fieldmsg(out_node, "LINE_ID", MP_STR, sizeof(CWIPCLVLOS.LINE_ID), CWIPCLVLOS.LINE_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);
			
			TRS.set_fieldmsg(out_node, "__FILE__", MP_NSTR, __FILE__);
			TRS.set_fieldmsg(out_node, "__LINE__", MP_INT,  __LINE__);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;

            CDB_close_cwipclvlos(i_step);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

        DBC_init_mrasresdef(&MRASRESDEF);
        TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, IN_FACTORY);
        memcpy(MRASRESDEF.RES_ID, CWIPCLVLOS.RES_ID, sizeof(MRASRESDEF.RES_ID));
        DBC_select_mrasresdef(1, &MRASRESDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }

		DBC_init_mwipmatdef(&MWIPMATDEF);
        TRS.copy(MWIPMATDEF.FACTORY, sizeof(MWIPMATDEF.FACTORY), in_node, IN_FACTORY);
		memcpy(MWIPMATDEF.MAT_ID, CWIPCLVLOS.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATDEF.MAT_VER = 1;
        DBC_select_mwipmatdef(1, &MWIPMATDEF);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }

        //2023-08-28 똑같은 Select 주석처리 
        /*DBC_init_mgcmtbldat(&MGCMTBLDAT_LINE);
        TRS.copy(MGCMTBLDAT_LINE.FACTORY, sizeof(MGCMTBLDAT_LINE.FACTORY), in_node, IN_FACTORY);
        memcpy(MGCMTBLDAT_LINE.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
        memcpy(MGCMTBLDAT_LINE.KEY_1, CWIPCLVLOS.LINE_ID, sizeof(CWIPCLVLOS.LINE_ID));
        DBC_select_mgcmtbldat(1, &MGCMTBLDAT_LINE);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }*/


		DBC_init_mgcmtbldat(&MGCMTBLDAT_LINE);
        TRS.copy(MGCMTBLDAT_LINE.FACTORY, sizeof(MGCMTBLDAT_LINE.FACTORY), in_node, IN_FACTORY);
        memcpy(MGCMTBLDAT_LINE.TABLE_NAME, HQCEL_M1_GCM_LINE_CODE, strlen(HQCEL_M1_GCM_LINE_CODE));
        memcpy(MGCMTBLDAT_LINE.KEY_1, CWIPCLVLOS.LINE_ID, sizeof(CWIPCLVLOS.LINE_ID));
        DBC_select_mgcmtbldat(1, &MGCMTBLDAT_LINE);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }

		DBC_init_mgcmtbldat(&MGCMTBLDAT_SHIFT);
        TRS.copy(MGCMTBLDAT_SHIFT.FACTORY, sizeof(MGCMTBLDAT_SHIFT.FACTORY), in_node, IN_FACTORY);
        memcpy(MGCMTBLDAT_SHIFT.TABLE_NAME, HQCEL_M1_GCM_SHIFT, strlen(HQCEL_M1_GCM_SHIFT));
        memcpy(MGCMTBLDAT_SHIFT.KEY_1, CWIPCLVLOS.WORK_SHIFT, sizeof(CWIPCLVLOS.WORK_SHIFT));
        DBC_select_mgcmtbldat(1, &MGCMTBLDAT_SHIFT);
        if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
		    {

		    }
            else
            {

            }
        }
		

        list_item = TRS.add_node(out_node, "SCRAP_LIST");
        TRS.add_string(list_item, "WORK_DATE", CWIPCLVLOS.WORK_DATE, sizeof(CWIPCLVLOS.WORK_DATE));
        TRS.add_string(list_item, "LINE_ID", CWIPCLVLOS.LINE_ID, sizeof(CWIPCLVLOS.LINE_ID));
        TRS.add_string(list_item, "WORK_SHIFT", CWIPCLVLOS.WORK_SHIFT, sizeof(CWIPCLVLOS.WORK_SHIFT));
		TRS.add_string(list_item, "MAT_ID", MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		TRS.add_string(list_item, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
        TRS.add_string(list_item, "RES_ID", MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID));
        TRS.add_string(list_item, "RES_DESC", MRASRESDEF.RES_DESC, sizeof(MRASRESDEF.RES_DESC));
        TRS.add_string(list_item, "EFF", CWIPCLVLOS.EFF,sizeof(CWIPCLVLOS.EFF));
        TRS.add_string(list_item, "GRADE", CWIPCLVLOS.GRADE, sizeof(CWIPCLVLOS.GRADE));
		TRS.add_double(list_item, "LOSS_SEQ", CWIPCLVLOS.LOSS_SEQ);
        TRS.add_double(list_item, "INPUT_QTY", CWIPCLVLOS.INPUT_QTY);
        TRS.add_double(list_item, "OUT_QTY", CWIPCLVLOS.OUT_QTY);
		TRS.add_string(list_item, "LINE_DESC", MGCMTBLDAT_LINE.DATA_1, sizeof(MGCMTBLDAT_LINE.DATA_1));
        TRS.add_string(list_item, "WORK_SHIFT_DESC", MGCMTBLDAT_SHIFT.DATA_1, sizeof(MGCMTBLDAT_SHIFT.DATA_1));
		
		
		

		//retrun until from CMF1 to5 
		ret_cmf1 = 0;
		ret_cmf2 = 0;
		ret_cmf3 = 0;
		ret_cmf4 = 0;
		ret_cmf5 = 0;

		ret_cmf1 = COM_atof(CWIPCLVLOS.CMF_1,sizeof(CWIPCLVLOS.CMF_1));
		ret_cmf2 = COM_atof(CWIPCLVLOS.CMF_2,sizeof(CWIPCLVLOS.CMF_2));
		ret_cmf3 = COM_atof(CWIPCLVLOS.CMF_3,sizeof(CWIPCLVLOS.CMF_3));
		ret_cmf4 = COM_atof(CWIPCLVLOS.CMF_4,sizeof(CWIPCLVLOS.CMF_4));
		ret_cmf5 = COM_atof(CWIPCLVLOS.CMF_5,sizeof(CWIPCLVLOS.CMF_5));
		
		TRS.add_double(list_item, "UNPACK_BROKEN", ret_cmf1);
		TRS.add_double(list_item, "FULL_CHIP", ret_cmf2);
		TRS.add_double(list_item, "FULL_BROKEN", ret_cmf3);
		TRS.add_double(list_item, "HALF_BROKEN", ret_cmf4);
		TRS.add_double(list_item, "CJ", ret_cmf5);

		TRS.add_string(list_item, "UNPACK_COMMENT", CWIPCLVLOS.CMF_6, sizeof(CWIPCLVLOS.CMF_6));
		TRS.add_string(list_item, "FULL_COMMENT", CWIPCLVLOS.CMF_7, sizeof(CWIPCLVLOS.CMF_7));
		TRS.add_string(list_item, "HALF_COMMENT", CWIPCLVLOS.CMF_8, sizeof(CWIPCLVLOS.CMF_8));
		TRS.add_string(list_item, "CJ_COMMENT", CWIPCLVLOS.CMF_9, sizeof(CWIPCLVLOS.CMF_9));



	}
			
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}