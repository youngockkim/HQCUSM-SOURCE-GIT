/*******************************************************************************

    System      : MESplus
    Module      : BOM Setup
    File Name   : CINF_interface_mcs_cartunload
    Description : //25.08.25 RTD 반복 잡 생성 로직 기술 검토 및 개발 요청의 건

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2025.08.25  -

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"

int CUS_INTERFACE_MCS_CARTUNLOAD(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP IF Table -> MES Bom Table
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Mcs_Cartunload(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);
    i_ret = CUS_INTERFACE_MCS_CARTUNLOAD(s_msg_code, in_node, out_node);
    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Mcs_Cartunload", out_node);

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
    CUS_INTERFACE_MCS_CARTUNLOAD()
        - ERP IF Table -> MES Bom Table
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_MCS_CARTUNLOAD(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	struct IBASBOMDAT_TAG IBASBOMDAT;
	struct IBAKBOMDAT_TAG IBAKBOMDAT;
	struct MBOMSETDEF_TAG MBOMSETDEF;
	struct MBOMSETVER_TAG MBOMSETVER;
	struct MBOMSETMAT_TAG MBOMSETMAT;

	char s_sys_time[14];
	int ibasbomdat_flag = 3;
	int ibasbomdat_next_flag = 4;
	int i;
	int seq;
	int bom_list_count;
	TRSNode ** BOM_GET_LIST;
	TRSNode *bom_item;

	// PROCESS LOG PRINT
	LOG_head("CUS_INTERFACE_MCS_CARTUNLOAD");
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

	


	return MP_TRUE;
}