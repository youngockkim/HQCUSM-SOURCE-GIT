/*******************************************************************************

    System      : MESplus
    Module      : Cleaving End Lot 
    File Name   : CWIP_cleaving_end_lot.c
    Description : CLEAVING OPERATION END ( CREATE / COMBINE / END )
				  
    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.22  JUHYEON.JUNG  CREATE
    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"

int CWIP_CLEAVING_END_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Move_HalfCell_Cart()
        - SOI->MES Move HalfCell Cart
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Cleaving_End_Lot(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_CLEAVING_END_LOT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_cleaving_end_lot", out_node);

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
    CWIP_CLEAVING_END_LOT()
        - SOI->MES Move HalfCell Cart
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_CLEAVING_END_LOT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	
	//CWIP_packing_halfcell 서비스 이용 
	// Cleaving End 는 Cart 단위 및 Half Cell Magazine 단위로 처리를 하므로 
	// OI 의 HalfCell 관리 와 Server 의 CWIP_packing_halfcell 화면을 이용하여 처리함.
	// 설비단에서는 CART_IN (RES_STS_2 값의 CART), MAGAZINE UNLOAD 의 EVENT 를 잡아서 처리함.
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}