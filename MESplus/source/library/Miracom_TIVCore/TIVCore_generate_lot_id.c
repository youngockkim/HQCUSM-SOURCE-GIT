/*******************************************************************************

    System      : MESplus
    Module      : TVICore
    File Name   : TIVCore_generate_lot_id.c
    Description : Generate Lot ID

    MES Version : 5.2.0

    Function List
        - TIV_Generate_Lot_ID()
            + Transaction Out Generate Lot ID
        - TIV_GENERATE_LOT_ID()
            + Main Sub function of "TIV_Generate_Lot_ID"
            + (called by "TIV_Generate_Lot_ID")
       
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/07/25  patrick         Create        

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "TIVCore_common.h"

/*******************************************************************************
    TIV_Generate_Lot_ID()
        - Generate Lot ID
    Return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TIV_CV_Lot_In_Tag *TIV_CV_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_Generate_Lot_ID(TRSNode *in_node, 
                  TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = TIV_GENERATE_LOT_ID(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "TIV_GENERATE_LOT_ID", out_node);

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
    TIV_GENERATE_LOT_ID()
        - Main sub function of "TIV_Generate_Lot_ID" function
    Return Value
        - int : 1 (MP_TRUE) / 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code 
        - TIV_GENERATE_LOT_ID_IN_TAG *Out_Lot_In : Input Message structure
        - Cmn_Out_Tag *Cmn_Out : Output Message structure
*******************************************************************************/
int TIV_GENERATE_LOT_ID(char* s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct MTIVLOTSTS_TAG MTIVLOTSTS;
	struct MTIVOPRDEF_TAG MTIVOPRDEF;
	char s_lot[25];
	int i_seq=0;

	char s_sys_time[14];

	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "INV-0004");
        TRS.add_fieldmsg(out_node, "DB_get_systime", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	if(COM_isnullspace(TRS.get_string(in_node, "INV_IN_TIME"))==MP_FALSE)
	{
		TRS.copy( s_sys_time, sizeof(s_sys_time), in_node, "INV_IN_TIME");
	}
	TRS.set_string(in_node, "INV_IN_TIME", s_sys_time, 8);

	DBC_init_mtivlotsts(&MTIVLOTSTS);
	TRS.copy(MTIVLOTSTS.MAT_ID, sizeof(MTIVLOTSTS.MAT_ID), in_node, "MAT_ID");
	MTIVLOTSTS.MAT_VER = TRS.get_int(in_node, "MAT_VER");
	TRS.copy(MTIVLOTSTS.VENDOR_ID, sizeof(MTIVLOTSTS.VENDOR_ID), in_node, "VENDOR_ID");
	TRS.copy(MTIVLOTSTS.INV_IN_TIME, sizeof(MTIVLOTSTS.INV_IN_TIME), in_node, "INV_IN_TIME");
	memcpy(MTIVLOTSTS.INV_IN_TIME+8,"      ", strlen("      ")); 
	DBC_select_mtivlotsts(13, &MTIVLOTSTS);
	if(DB_error_code == DB_SUCCESS)
	{
		TRS.set_string(out_node, "LOT_ID", MTIVLOTSTS.LOT_ID, sizeof(MTIVLOTSTS.LOT_ID));
	}
	else if(DB_error_code==DB_NOT_FOUND)
	{
		DBC_init_mtivoprdef(&MTIVOPRDEF);
		TRS.copy(MTIVOPRDEF.FACTORY, sizeof(MTIVOPRDEF.FACTORY), in_node, IN_FACTORY);
		TRS.copy(MTIVOPRDEF.OPER, sizeof(MTIVOPRDEF.OPER), in_node, "OPER");
		DBC_select_mtivoprdef(1, &MTIVOPRDEF);

		if(COM_isspace(MTIVOPRDEF.OPER_CMF_1, sizeof(MTIVOPRDEF.OPER_CMF_1))==MP_TRUE)
		{
			return MP_FALSE;
		}

		memset(s_lot, ' ', sizeof(s_lot));
		s_lot[0]='#';
		memcpy(s_lot+1, MTIVOPRDEF.OPER_CMF_1, 3);
		memcpy(s_lot+4, s_sys_time+2, 6);
		DBC_init_mtivlotsts(&MTIVLOTSTS);
		memcpy(MTIVLOTSTS.LOT_ID, s_lot, sizeof(MTIVLOTSTS.LOT_ID));
		MTIVLOTSTS.LOT_ID[10] = '%';
		DBC_select_mtivlotsts(12, &MTIVLOTSTS);

		i_seq = COM_atoi(MTIVLOTSTS.LOT_ID + 10,4);
		COM_itoa_zero(s_lot+10, i_seq+1,4);

		TRS.set_char(out_node, "NEW_GEN_FLAG", 'Y');
		TRS.set_string(out_node, "LOT_ID", s_lot, sizeof(s_lot));
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}