/*******************************************************************************

    System      : MESplus
    Module      : User Routine for ORD
    File Name   : UORD_View_Order.c
    Description : User Routine for ORD_View_Order

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

#include "UORD_common.h"
#include "CUS_common.h"

int ORD_View_Order_Before_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    return MP_TRUE;
}

int ORD_View_Order_After_1(TRSNode *in_node, TRSNode *out_node)
{
    /* ORDER 의 IN/OUT 수량 GET */
	struct RSUMWIPMOV_TAG RSUMWIPMOV;
	struct CWIPCELPAK_TAG CWIPCELPAK;
	struct MWIPORDSTS_TAG MWIPORDSTS;


	/* Check whether the Order ID exists or not */
    DBC_init_mwipordsts(&MWIPORDSTS);
    TRS.copy(MWIPORDSTS.FACTORY, sizeof(MWIPORDSTS.FACTORY), in_node, IN_FACTORY);
    TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "ORDER_ID");
    DBC_select_mwipordsts(1, &MWIPORDSTS);
    if(DB_error_code != DB_SUCCESS)
	{
		return MP_TRUE;
    }
	
	if (memcmp(MWIPORDSTS.ORD_CMF_1, "CVL", 3) == 0)
	{
		double dPackQty = 0;
		//CLEAVING ORDER
		//CLEAVING 투입수량 / 완료수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		TRS.copy(RSUMWIPMOV.ORDER_ID, sizeof(RSUMWIPMOV.ORDER_ID), in_node, "ORDER_ID");
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_FCELBX, strlen(HQCEL_LOT_CREATECODE_FCELBX));
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_IN_QTY", RSUMWIPMOV.S1_OPER_IN_QTY_1);
			
		}

		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		TRS.copy(RSUMWIPMOV.ORDER_ID, sizeof(RSUMWIPMOV.ORDER_ID), in_node, "ORDER_ID");
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_HCELBX, strlen(HQCEL_LOT_CREATECODE_HCELBX));
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_CLEAVING_OPER, strlen(HQCEL_M1_CLEAVING_OPER));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_OUT_QTY", RSUMWIPMOV.S1_END_QTY_1);
		}

		CDB_init_cwipcelpak(&CWIPCELPAK);
		TRS.copy(CWIPCELPAK.FACTORY, sizeof(CWIPCELPAK.FACTORY), in_node, IN_FACTORY);
		TRS.copy(CWIPCELPAK.ORDER_ID, sizeof(CWIPCELPAK.ORDER_ID), in_node, "ORDER_ID");
		CWIPCELPAK.PACK_TYPE = 'F';
		dPackQty = CDB_select_cwipcelpak_scalar(11, &CWIPCELPAK);

		TRS.set_double(out_node, "ORD_PACK_QTY",dPackQty);
		
	}
	else if (memcmp(MWIPORDSTS.ORD_CMF_1, "MDL", 3) == 0)
	{
		//MAIN 투입수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		TRS.copy(RSUMWIPMOV.ORDER_ID, sizeof(RSUMWIPMOV.ORDER_ID), in_node, "ORDER_ID");
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_LAYUP_OPER, strlen(HQCEL_M1_LAYUP_OPER));
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_IN_QTY", RSUMWIPMOV.S1_OPER_IN_QTY_1);
		}

		//MAIN 완료수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		TRS.copy(RSUMWIPMOV.ORDER_ID, sizeof(RSUMWIPMOV.ORDER_ID), in_node, "ORDER_ID");
		memcpy(RSUMWIPMOV.OPER , HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER));
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE));
		CDB_select_rsumwipmov(4, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_OUT_QTY", RSUMWIPMOV.S1_END_QTY_1);
		}

		//MAIN 불량수량
		CDB_init_rsumwipmov(&RSUMWIPMOV);
		TRS.copy(RSUMWIPMOV.FACTORY, sizeof(RSUMWIPMOV.FACTORY), in_node, IN_FACTORY);
		TRS.copy(RSUMWIPMOV.ORDER_ID, sizeof(RSUMWIPMOV.ORDER_ID), in_node, "ORDER_ID");
		memcpy(RSUMWIPMOV.CM_KEY_3, HQCEL_LOT_CREATECODE_MODULE, strlen(HQCEL_LOT_CREATECODE_MODULE));
		CDB_select_rsumwipmov(3, &RSUMWIPMOV);
		if(DB_error_code == DB_SUCCESS)
		{
			TRS.set_double(out_node, "ORD_LOSS_QTY", RSUMWIPMOV.S1_LOSS_QTY_1);
		}
	}
	else
	{
		return MP_TRUE;
	}

	

    return MP_TRUE;
}

