/******************************************************************************'

    System      : MESplus
    Module      : CRAS
    File Name   : CRAS_update_xlinktest.c
    Description : Xlinktest Setup function module

    MES Version : 5.3.4 ~

    Function List
        - CRAS_Update_Xlinktest()
            + Create/Update/Delete Xlinktest definition
        - CRAS_UPDATE_XLINKTEST()
            + Main sub function of CRAS_Update_Xlinktest function
            + Create/Update/Delete Xlinktest definition
        - CRAS_Update_Xlinktest_Validation()
            + Main sub function of CRAS_UPDATE_XLINKTEST function
            + Check the condition for create/update/delete Xlinktest
    Detail Description
        - CRAS_UPDATE_XLINKTEST()
            + h_proc_step
                + MP_STEP_CREATE : Create Xlinktest definition
                + MP_STEP_UPDATE : Update Xlinktest definition
                + MP_STEP_DELETE : Delete Xlinktest definition

    History
    Seq   Date        Developer      Description
    ---------------------------------------------------------------------------
    1     2025/04/11             Create by Generator

    Copyright(C) 1998-2025 Miracom,Inc.
    All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CRAS_Update_Xlinktest_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
    CRAS_Update_Xlinktest()
        - Create/Update/Delete Xlinktest definition
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Xlinktest(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CRAS_UPDATE_XLINKTEST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CRAS_UPDATE_XLINKTEST", out_node);

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
    CRAS_UPDATE_XLINKTEST()
        - Main sub function of "CRAS_Update_Xlinktest" function
        - Create/Update/Delete Xlinktest definition
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_UPDATE_XLINKTEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASXLINKR_TAG CRASXLINKR;
    char   s_sys_time[14];
	int i_tran_count;
	int i ;
	int chk_count = 0;



	TRSNode ** Tran_List;

	LOG_head("CRAS_UPDATE_HOUR_GAP");
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

	Tran_List = TRS.get_list(in_node, "TRAN_LIST");
	i_tran_count = TRS.get_item_count(in_node, "TRAN_LIST");
	
    for(i = 0; i < i_tran_count; i++)
	{
		CDB_init_crasxlinkr(&CRASXLINKR);
		
		

		TRS.copy(CRASXLINKR.WORK_DATE, sizeof(CRASXLINKR.WORK_DATE), in_node, "WORK_DATE");
		TRS.copy(CRASXLINKR.LINE_ID, sizeof(CRASXLINKR.LINE_ID), Tran_List[i], "LINE_ID");
		TRS.copy(CRASXLINKR.LAMI_NUMER, sizeof(CRASXLINKR.LAMI_NUMER), Tran_List[i], "LAMI_NUMER");
		TRS.copy(CRASXLINKR.LAMI_POS, sizeof(CRASXLINKR.LAMI_POS), Tran_List[i], "LAMI_POS");
		TRS.copy(CRASXLINKR.TEST_DATE, sizeof(CRASXLINKR.TEST_DATE), Tran_List[i], "TEST_DATE");
		TRS.copy(CRASXLINKR.CREATE_USER_ID, sizeof(CRASXLINKR.CREATE_USER_ID), in_node, "CREATE_USER_ID");

		chk_count = (int) CDB_select_crasxlinkr_scalar(1,&CRASXLINKR);

		if(chk_count > 0)		//Update	
		{
			CRASXLINKR.LX11 = TRS.get_float(Tran_List[i], "LX11");
			CRASXLINKR.LX12 = TRS.get_float(Tran_List[i], "LX12");
			CRASXLINKR.LX21 = TRS.get_float(Tran_List[i], "LX21");
			CRASXLINKR.LX22 = TRS.get_float(Tran_List[i], "LX22");
			CRASXLINKR.LX31 = TRS.get_float(Tran_List[i], "LX31");
			CRASXLINKR.LX32 = TRS.get_float(Tran_List[i], "LX32");
			CRASXLINKR.LX41 = TRS.get_float(Tran_List[i], "LX41");
			CRASXLINKR.LX42 = TRS.get_float(Tran_List[i], "LX42");
			CRASXLINKR.LX51 = TRS.get_float(Tran_List[i], "LX51");
			CRASXLINKR.LX52 = TRS.get_float(Tran_List[i], "LX52");
			CRASXLINKR.LXTAT1 = TRS.get_float(Tran_List[i], "LXTAT1");

			CRASXLINKR.DX11 = TRS.get_float(Tran_List[i], "DX11");
			CRASXLINKR.DX12 = TRS.get_float(Tran_List[i], "DX12");
			CRASXLINKR.DX21 = TRS.get_float(Tran_List[i], "DX21");
			CRASXLINKR.DX22 = TRS.get_float(Tran_List[i], "DX22");
			CRASXLINKR.DX31 = TRS.get_float(Tran_List[i], "DX31");
			CRASXLINKR.DX32 = TRS.get_float(Tran_List[i], "DX32");
			CRASXLINKR.DX41 = TRS.get_float(Tran_List[i], "DX41");
			CRASXLINKR.DX42 = TRS.get_float(Tran_List[i], "DX42");
			CRASXLINKR.DX51 = TRS.get_float(Tran_List[i], "DX51");
			CRASXLINKR.DX52 = TRS.get_float(Tran_List[i], "DX52");
			CRASXLINKR.DXTAT1 = TRS.get_float(Tran_List[i], "DXTAT1");

			memcpy(CRASXLINKR.UPDATE_TIME, s_sys_time, sizeof(CRASXLINKR.UPDATE_TIME));
			TRS.copy(CRASXLINKR.UPDATE_USER_ID, sizeof(CRASXLINKR.UPDATE_USER_ID), in_node, "CREATE_USER_ID");
			CDB_update_crasxlinkr(2, &CRASXLINKR);

		}
		else					//Insert 
		{
		
			CRASXLINKR.LX11 = TRS.get_float(Tran_List[i], "LX11");
			CRASXLINKR.LX12 = TRS.get_float(Tran_List[i], "LX12");
			CRASXLINKR.LX21 = TRS.get_float(Tran_List[i], "LX21");
			CRASXLINKR.LX22 = TRS.get_float(Tran_List[i], "LX22");
			CRASXLINKR.LX31 = TRS.get_float(Tran_List[i], "LX31");
			CRASXLINKR.LX32 = TRS.get_float(Tran_List[i], "LX32");
			CRASXLINKR.LX41 = TRS.get_float(Tran_List[i], "LX41");
			CRASXLINKR.LX42 = TRS.get_float(Tran_List[i], "LX42");
			CRASXLINKR.LX51 = TRS.get_float(Tran_List[i], "LX51");
			CRASXLINKR.LX52 = TRS.get_float(Tran_List[i], "LX52");
			CRASXLINKR.LXTAT1 = TRS.get_float(Tran_List[i], "LXTAT1");

			CRASXLINKR.DX11 = TRS.get_float(Tran_List[i], "DX11");
			CRASXLINKR.DX12 = TRS.get_float(Tran_List[i], "DX12");
			CRASXLINKR.DX21 = TRS.get_float(Tran_List[i], "DX21");
			CRASXLINKR.DX22 = TRS.get_float(Tran_List[i], "DX22");
			CRASXLINKR.DX31 = TRS.get_float(Tran_List[i], "DX31");
			CRASXLINKR.DX32 = TRS.get_float(Tran_List[i], "DX32");
			CRASXLINKR.DX41 = TRS.get_float(Tran_List[i], "DX41");
			CRASXLINKR.DX42 = TRS.get_float(Tran_List[i], "DX42");
			CRASXLINKR.DX51 = TRS.get_float(Tran_List[i], "DX51");
			CRASXLINKR.DX52 = TRS.get_float(Tran_List[i], "DX52");
			CRASXLINKR.DXTAT1 = TRS.get_float(Tran_List[i], "DXTAT1");

			memcpy(CRASXLINKR.TRAN_TIME, s_sys_time, sizeof(CRASXLINKR.TRAN_TIME));

			

			CDB_insert_crasxlinkr(&CRASXLINKR);
		}


	}




    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
    CRAS_Update_Xlinktest_Validation()
        - Main sub function of "CRAS_UPDATE_XLINKTEST" function
        - Check the condition for create/update/delete Xlinktest
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
int CRAS_Update_Xlinktest_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
    struct CRASXLINKR_TAG CRASXLINKR;
    struct MWIPFACDEF_TAG MWIPFACDEF;


    return MP_TRUE;
}

