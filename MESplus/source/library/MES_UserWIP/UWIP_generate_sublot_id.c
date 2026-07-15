/*******************************************************************************

    System      : MESplus
    Module      : UWIP
    File Name   : UWIP_generate_sublot_id.c
    Description : Generate Sublot ID

    MES Version : 5.0.0

    Function List
        - UWIP_generate_sublot_id() 
            + Generate Sublot ID

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/01/12  Daniel Jeong   Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "UWIP_common.h"

char s_from_lot_id[25];
int i_max_sublot_seq = 0;

int UWIP_GENERATE_SUBLOT_ID(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node);

int UWIP_Generate_Custom_Sublot_ID(char *s_msg_code,
                                   TRSNode *in_node,
                                   TRSNode *out_node);

int UWIP_Generate_Sublot_ID_1(TRSNode *in_node,
                              TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = UWIP_GENERATE_SUBLOT_ID(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "UWIP_GENERATE_SUBLOT_ID", out_node);

    return i_ret;
}

int UWIP_GENERATE_SUBLOT_ID(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node)
{
    int                     i;
    char                    s_temp[30];

    i = 0;
    memset(s_temp, ' ', sizeof(s_temp));


    if(TRS.get_char(in_node, "__SCRIBE_SUBLOT_FLAG") == 'Y')
    {
        //SCRIBE SUBLOT Creation
        //Add by J.S. 2009.02.28 for SCRIBE

        TRS.copy(s_temp, sizeof(s_temp), in_node, "SUBLOT_ID");

        for ( i = 29 ; i >= 0 ; i --)
        {
            if(s_temp[i] != ' ')
                break;
        }

        //Prevent from exceeding 30 bytes of sublot id length
        if(i > 25)
        {
            i = 25;
        }

        s_temp[i + 1] = '$';
        COM_itoa_zero(s_temp + i + 2, TRS.get_int(in_node, "SCRIBE_SEQ"), 3);

        TRS.set_string(out_node, "SUBLOT_ID", s_temp, sizeof(s_temp));
    }
    else
    {
        //Normal SUBLOT Creation
        if(TRS.get_char(in_node, "__EXIST_SUBLOT_FLAG") == 'Y')
        {
            if(TRS.get_member(in_node, "SUBLOT_ID") != 0x00)
            {
                TRS.set_nstring(out_node, "SUBLOT_ID", TRS.get_string(in_node, "SUBLOT_ID"));
            }
            if(TRS.get_int(in_node, "SLOT_NO") > 0)
            {
                TRS.set_int(out_node, "SLOT_NO", TRS.get_int(in_node, "SLOT_NO"));
            }
            if(TRS.get_member(in_node, "CRR_ID") != 0x00)
            {
                TRS.set_nstring(out_node, "CRR_ID", TRS.get_string(in_node, "CRR_ID"));
            }
            if(TRS.get_member(in_node, "GRADE") != 0x00)
            {
                TRS.set_char(out_node, "GRADE", TRS.get_char(in_node, "GRADE"));
            }
            if(TRS.get_member(in_node, "SUBLOT_TYPE") != 0x00)
            {
                TRS.set_char(out_node, "SUBLOT_TYPE", TRS.get_char(in_node, "SUBLOT_TYPE"));
            }

            if(COM_isnullspace(TRS.get_string(out_node, "SUBLOT_ID")) == MP_TRUE)
            {
                if(UWIP_Generate_Custom_Sublot_ID(s_msg_code, in_node, out_node) == MP_FALSE)
                {
                    return MP_FALSE;
                }
            }
        }
        else
        {
            if(UWIP_Generate_Custom_Sublot_ID(s_msg_code, in_node, out_node) == MP_FALSE)
            {
                return MP_FALSE;
            }
        }
    }

    return MP_TRUE;
}

int UWIP_Generate_Custom_Sublot_ID(char *s_msg_code,
                                   TRSNode *in_node,
                                   TRSNode *out_node)
{
    struct MWIPSLTSTS_TAG   MWIPSLTSTS;
    char                    s_temp[30];
    int                     i;

    i = 0;
    memset(s_temp, ' ', sizeof(s_temp));

    TRS.copy(s_temp, sizeof(s_temp), in_node, "LOT_ID");

    if(TRS.get_char(in_node, "__FIRST_SUBLOT") == 'Y')
    {
        memset(s_from_lot_id, ' ', sizeof(s_from_lot_id));
    }

    if(memcmp(s_from_lot_id, s_temp, sizeof(s_from_lot_id)) != 0)
    {
        memcpy(s_from_lot_id, s_temp, sizeof(s_from_lot_id));
        i_max_sublot_seq = 0;

        DBC_init_mwipsltsts(&MWIPSLTSTS);
        memcpy(MWIPSLTSTS.LOT_ID, s_from_lot_id, sizeof(MWIPSLTSTS.LOT_ID));
        DBC_select_mwipsltsts(4, &MWIPSLTSTS);

        if(COM_isspace(MWIPSLTSTS.SUBLOT_ID, sizeof(MWIPSLTSTS.SUBLOT_ID)) == MP_FALSE)
        {
            for (i = 29; i >= 0 ;i--)
            {
                if(MWIPSLTSTS.SUBLOT_ID[i] == '#')
                    break;
            }

            if(i > 0)
            {
                i_max_sublot_seq = COM_atoi(MWIPSLTSTS.SUBLOT_ID + i + 1, sizeof(MWIPSLTSTS.SUBLOT_ID) - i);
            }
        }
    }

    for ( i = 29 ; i >= 0 ; i --)
    {
        if(s_temp[i] != ' ')
            break;
    }

    s_temp[i + 1] = '#';

    i_max_sublot_seq++;
    COM_itoa_zero(s_temp + i + 2, i_max_sublot_seq, 4);

    TRS.set_string(out_node, "SUBLOT_ID", s_temp, sizeof(s_temp));

    return MP_TRUE;
}

