/*******************************************************************************

    System      : MESplus
    Module      : User Routine for WIP
    File Name   : UWIP_Start_Lot.c
    Description : User Routine for WIP_Start_Lot

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

#include "UWIP_common.h"

int WIP_Start_Lot_Before_1(TRSNode *in_node, TRSNode *out_node)
{

    /* TODO : Insert your code */
	/* - [GERP PROJECT] 시작****************************************************************/
	struct MWIPLOTSTS_TAG MWIPLOTSTS;	
	char s_msg_code[MP_SIZE_MSG];
	
	memset(s_msg_code, ' ' , sizeof(s_msg_code));
	
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(in_node, "LOT_ID"), sizeof(MWIPLOTSTS.LOT_ID));
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	

	if(COM_isnullspace(TRS.get_string(in_node, "CIM_ID")) == MP_FALSE)	// 설비 데이터 일때만 Store 처리된 모듈 In Line 강제 투입
	{
		if(RELEASE_UNSTORE_LOT(s_msg_code, in_node, out_node) == MP_FALSE)
		{
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_VALIDATION;
			gs_log_type.category = MP_LOG_CATE_SETUP;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	/* - [GERP PROJECT] 끝*****************************************************************/
    return MP_TRUE;
}

int WIP_Start_Lot_After_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    return MP_TRUE;
}

