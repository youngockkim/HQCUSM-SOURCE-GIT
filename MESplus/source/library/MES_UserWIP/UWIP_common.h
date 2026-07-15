/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : sl_common.h
    Description : user function prototype of user defined shared library

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

#ifndef _WIP_COMMON_H
#define _WIP_COMMON_H

#include <MESCore_common.h>

/* Business Function Prototype Definitions */
/*
extern int SAMPLE(char *s_msg_code,
                  TRSNode *in_node, 
                  TRSNode *out_node);
*/
/* - [GERP PROJECT] 시작****************************************************************/
extern int RELEASE_UNSTORE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/* - [GERP PROJECT] 끝*****************************************************************/
#endif

