/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : SLIB_common.h
    Description : user function prototype of user defined shared library

    MES Version : 5.1

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2009/11/09  Miracom        Create

    Copyright(C) 1998-2009 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#ifndef _SLIB_COMMON_H
#define _SLIB_COMMON_H

#include <MESCore_common.h>
#include "SLIB_services.h"

extern int MULTI_TRANSACTION_1(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);

extern int MULTI_TRANSACTION_2(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);

extern int START_LOT_1(char *s_msg_code,
                TRSNode *in_node, 
                TRSNode *out_node);

extern int END_LOT_1(char *s_msg_code,
              TRSNode *in_node, 
              TRSNode *out_node);

extern int VIEW_LOT_LIST_SAMPLE(char *s_msg_code,
                           TRSNode *in_node, 
                           TRSNode *out_node);



#endif

