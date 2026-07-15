/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : RTD_time_type_sample.c
    Description : user function of user defined shared library

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/06/03  Aiden          Create

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "SLIB_common.h"

int RTD_Time_Type_1(TRSNode *in_node, TRSNode *out_node)
{
    LOG_head("RTD_Time_Type_1");
    LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID"));
    LOG_add("RES_ID", MP_NSTR, TRS.get_string(in_node, "RES_ID"));
    LOG_add("KEY_VALUE_1", MP_NSTR, TRS.get_string(in_node, "KEY_VALUE_1"));
    LOG_add("KEY_VALUE_2", MP_NSTR, TRS.get_string(in_node, "KEY_VALUE_2"));
    LOG_add("PREDISPATCH_FLAG", MP_CHR, TRS.get_char(in_node, "PREDISPATCH_FLAG"));
    LOG_add("MAT_ID", MP_NSTR, TRS.get_string(in_node, "MAT_ID"));
    LOG_add("MAT_VER", MP_INT, TRS.get_int(in_node, "MAT_VER"));
    LOG_add("FLOW", MP_NSTR, TRS.get_string(in_node, "FLOW"));
    LOG_add("OPER", MP_NSTR, TRS.get_string(in_node, "OPER"));
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    //maxvalue next year 12¿ù 31ÀÏ 23:59:59
    TRS.set_nstring(out_node, "TIME_VALUE",  "20081231235959");

    return MP_TRUE;
}
