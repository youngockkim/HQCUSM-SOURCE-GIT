/*******************************************************************************

    System      : MESplus
    Module      : User Routine for BAS
    File Name   : UBAS_Update_Message.c
    Description : User Routine for BAS_Update_Message

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

#include "UBAS_common.h"

int BAS_Update_Message_Before_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    return MP_TRUE;
}

int BAS_Update_Message_After_1(TRSNode *in_node, TRSNode *out_node)
{
    /* TODO : Insert your code */
    //unsigned char  *in_data;
    //unsigned char  out_data[10000000];
    //long            blob_size;
    //FILE           *blob_file;
    //int             i;

    //TRS.get_blob(in_node, MP_BIN_DATA_2, &in_data, &blob_size);

    //blob_file = fopen("D:\\S_aa.pdf", "wb");
    //fwrite(in_data, sizeof(unsigned char), blob_size, blob_file);
    //fclose(blob_file);


    //memset(out_data, 0x00, sizeof(out_data));
    //i = 0;

    //blob_file = fopen("D:\\S_aa.pdf", "rb");
    //while(!feof(blob_file))
    //{
    //    fread(out_data + i, sizeof(unsigned char), 1, blob_file);
    //    i++;
    //}
    //fclose(blob_file);

    //TRS.add_blob(out_node, MP_BIN_DATA_3, out_data, i - 1);

    return MP_TRUE;
}

