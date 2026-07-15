/*******************************************************************************

    System      : MESplus
    Module      : User Routine for WIP
    File Name   : UWIP_End_Lot.c
    Description : User Routine for WIP_End_Lot

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

int WIP_Create_Lot_Before_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    return MP_TRUE;
}

int WIP_Create_Lot_After_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */	
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPELTHIS_TAG MWIPELTHIS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;

	char s_msg_code[MP_SIZE_MSG];
	
	memset(s_msg_code, ' ' , sizeof(s_msg_code));

	//WIPLOTSELECT
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
    {
		//DO NOTHING
	}

	if (memcmp(MWIPLOTSTS.CREATE_CODE, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE)) == 0)
	{
		//MWIPELTSTS & MWIPELTHIS CREATE
		CDB_init_mwipeltsts(&MWIPELTSTS);
		TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
		MWIPELTSTS.HIST_SEQ = 1;
		TRS.copy(MWIPELTSTS.LOC_ID, sizeof(MWIPELTSTS.LOC_ID), in_node, "LOC_ID");
		TRS.copy(MWIPELTSTS.LINE_ID, sizeof(MWIPELTSTS.LINE_ID), in_node, "LINE_ID");
		TRS.copy(MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS), in_node, "COLOR_CLASS");
		memcpy(MWIPELTSTS.CURING_TIME, MWIPLOTSTS.CREATE_TIME, sizeof(MWIPELTSTS.CURING_TIME)) ;//파티션키로 사용하고 있으므로 업데이트 금지
		CDB_insert_mwipeltsts(&MWIPELTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}

		//HISORY SEQUENCE
		CDB_init_mwipelthis(&MWIPELTHIS);
		memcpy(MWIPELTHIS.LOT_ID, MWIPELTSTS.LOT_ID, sizeof(struct MWIPELTSTS_TAG));
		CDB_insert_mwipelthis(&MWIPELTHIS);	
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
	}
	
	return MP_TRUE;
}

