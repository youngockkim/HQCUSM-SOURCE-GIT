/*******************************************************************************

    System      : MESplus
    Module      : View Pallet ID Current
    File Name   : CWIP_view_pallet_current_seq.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.02.01  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_PALLET_CURRENT_SEQ(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Pallet_Current_Seq()
        - View_Pallet_Current_Seq
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Pallet_Current_Seq(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_PALLET_CURRENT_SEQ(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Pallet_Current_Seq", out_node);

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
    CWIP_VIEW_PALLET_CURRENT_SEQ()
        - VIEW_PALLET_CURRENT_SEQ
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_PALLET_CURRENT_SEQ(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	char s_sys_time[14];

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_PALLET_CURRENT_SEQ");
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

	// Get CurrentDate Sequence 

	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	memcpy(CWIPLOTPAK.PALLET_ID, TRS.get_string(in_node,"PALLET_ID_SUB"), strlen(TRS.get_string(in_node,"PALLET_ID_SUB")));
	memcpy(CWIPLOTPAK.CMF_1,  TRS.get_string(in_node,"PALLET_ID_SUB"), strlen(TRS.get_string(in_node,"PALLET_ID_SUB")));
	//Manual Packing 
	if(memcmp(TRS.get_string(in_node, "PRINT_CHK"), "M", strlen("M")) == 0){
		//699번이 존재하는지 체크
		CDB_select_cwiplotpak(7, &CWIPLOTPAK);
		
		if(DB_error_code == DB_SUCCESS || DB_error_code == DB_RETURN_MANY)		//존재 하면 (701번으로 채번)
		{
			CDB_select_cwiplotpak(4, &CWIPLOTPAK);
		}
		else		//존재 하지 않는 경우 601~699번 까지 채번
		{
			CDB_select_cwiplotpak(6, &CWIPLOTPAK);
		}

	}
	else			//Auto Packing 
	{
		CDB_select_cwiplotpak(4, &CWIPLOTPAK);
	}
	if(DB_error_code != DB_SUCCESS)
	{
		// Nothing
	}
	
	TRS.add_string(out_node, "PALLET_ID", CWIPLOTPAK.CMF_3, sizeof(CWIPLOTPAK.CMF_3));
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}
