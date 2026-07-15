/********************************************************************************

System      : MESplus
Module      : UWIP
File Name   : UWIP_common_function.c
Description : CUSTOM COMMON FUNCTION

MES Version : 5.3.x

Function List

Detail Description
// CUSTOM COMMON FUNCTION

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
1     2023/04/20  Yadon.Park       Create        

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include "UWIP_common.h"
#include "../CUS_Common/CUS_defines.h"

int RELEASE_UNSTORE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	//Define
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	TRSNode* Release_Lot_In;
	TRSNode* Unstore_Lot_In;

	//Initialize
	memset(s_msg_code, ' ' , sizeof(s_msg_code));
	
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);


	if(MWIPLOTSTS.INV_FLAG == HQCEL_FLAG_YES && COM_isnullspace(MWIPLOTSTS.FLOW) == MP_TRUE)
	{
		//HOLD 상태이면 RELEASE를 한다.
		if (MWIPLOTSTS.HOLD_FLAG == HQCEL_FLAG_YES)
		{
			Release_Lot_In = TRS.create_node("RELEASE_LOT_IN");

			TRS.add_char(Release_Lot_In, IN_PROCSTEP, '1');
			TRS.add_enc_nstring(Release_Lot_In, IN_USERID, TRS.get_userid(in_node));
			TRS.add_char(Release_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));

			TRS.set_string(Release_Lot_In, "FACTORY", MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
			TRS.set_string(Release_Lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.set_int(Release_Lot_In, "LAST_ACTIVE_HIST_SEQ", MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);

			TRS.set_string(Release_Lot_In, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
			TRS.set_int(Release_Lot_In, "MAT_VER", MWIPLOTSTS.MAT_VER);
			TRS.set_string(Release_Lot_In, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));
			TRS.set_int(Release_Lot_In, "FLOW_SEQ_NO", MWIPLOTSTS.FLOW_SEQ_NUM);

			TRS.set_string(Release_Lot_In, "OPER", MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));
			TRS.set_string(Release_Lot_In, "RELEASE_CODE", HQCEL_RELEASE_ABN_MOVE, strlen(HQCEL_RELEASE_ABN_MOVE));

			TRS.set_char(Release_Lot_In, "END_FLAG", 'Y');

			if (WIP_RELEASE_LOT(s_msg_code, Release_Lot_In, out_node) == MP_FALSE)
			{
				TRS.free_node(Release_Lot_In);
				CDB_close_iqcmserdat(2);
				return MP_FALSE;
			}

			TRS.free_node(Release_Lot_In);
		}		

		DBC_init_mwiplotsts(&MWIPLOTSTS);
		memcpy(MWIPLOTSTS.LOT_ID, TRS.get_string(in_node, "LOT_ID"), sizeof(MWIPLOTSTS.LOT_ID));
		DBC_select_mwiplotsts(1, &MWIPLOTSTS);
		if (DB_error_code != DB_SUCCESS)
		{
			if (DB_error_code == DB_NOT_FOUND)
			{
				strcpy(s_msg_code, "WIP-0044");
				gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			}
			else
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
			}
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT(1)", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.category = MP_LOG_CATE_TRANS;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

			return MP_FALSE;
		}
				
		Unstore_Lot_In = TRS.create_node("UNSTORE_LOT_IN");
		TRS.init_node(Unstore_Lot_In);
		TRS.add_string(Unstore_Lot_In, IN_FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		TRS.add_char(Unstore_Lot_In, IN_PROCSTEP, '1'); 
		TRS.add_enc_nstring(Unstore_Lot_In, IN_USERID, TRS.get_userid(in_node));
		TRS.add_char(Unstore_Lot_In, IN_LANGUAGE, TRS.get_language(in_node));
		TRS.add_string(Unstore_Lot_In, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		TRS.add_nstring(Unstore_Lot_In, "OPER", TRS.get_string(in_node, "TO_OPER"));

		if (CWIP_UPDATE_LOT_UNSTORE(s_msg_code, Unstore_Lot_In, out_node, &MWIPLOTSTS) == MP_FALSE)
		{
			TRS.free_node(Unstore_Lot_In);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}

		TRS.free_node(Unstore_Lot_In);			
	}
	return MP_TRUE;
}