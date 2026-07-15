/*******************************************************************************

    System      : MESplus
    Module      : User Defined Shared Library
    File Name   : RTD_queu_time_over.c
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

int RTD_Queue_Time_Over_1(TRSNode *in_node, TRSNode *out_node)
{
    struct MWIPLOTSTS_TAG MWIPLOTSTS;
    struct MWIPQTMDEF_TAG MWIPQTMDEF;
    struct MWIPLOTHIS_TAG MWIPLOTHIS;

    int i_count;
    int i_set_time;
    int i_time_gap;
    int i_hist_select_step;
    int i_upper_error_queue_time;

    char c_predispatch_flag;
    char *s_set_time;
    char c_queue_time_unit;
    char s_current_time[14];
    char s_msg[MP_SIZE_FIELD_MSG];
    char s_msg_code[MP_SIZE_MSG];


    LOG_head("RTD_Queue_Time_Over_1");
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

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    //Default Result
    TRS.set_char(out_node, "RESULT_FLAG", 'N');

    c_predispatch_flag = TRS.get_char(in_node, "PREDISPATCH_FLAG");

    DB_get_systime(s_current_time);



    DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");

    DBC_select_mwiplotsts(1, &MWIPLOTSTS);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            strcpy(s_msg_code, "WIP-0044");
            COM_get_message('1', s_msg_code, s_msg);
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            COM_get_message('1', s_msg_code, s_msg);
        }

        LOG_head("RTD_Queue_Time_Over_1");
        LOG_add("table", MP_NSTR, "MWIPLOTSTS SELECT");
        LOG_add("LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
        LOG_add("error_msg", MP_STR, MP_SIZE_FIELD_MSG, s_msg );
        LOG_add("db_error_msg", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg );
        COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

        return MP_FALSE;
    }

    s_set_time = TRS.get_string(in_node, "KEY_VALUE_1");
    i_set_time = COM_atoi(s_set_time, (int)strlen(s_set_time)) * 60;


    DBC_init_mwipqtmdef(&MWIPQTMDEF);
    memcpy(MWIPQTMDEF.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPQTMDEF.FACTORY));
    memcpy(MWIPQTMDEF.MAT_ID, MWIPLOTSTS.MAT_ID, sizeof(MWIPQTMDEF.MAT_ID));
    MWIPQTMDEF.MAT_VER = MWIPLOTSTS.MAT_VER;
    memcpy(MWIPQTMDEF.FLOW, MWIPLOTSTS.FLOW, sizeof(MWIPQTMDEF.FLOW));
    MWIPQTMDEF.FLOW_SEQ_NUM = MWIPLOTSTS.FLOW_SEQ_NUM;
    memcpy(MWIPQTMDEF.OPER, MWIPLOTSTS.OPER, sizeof(MWIPQTMDEF.OPER));

    i_count = (int)DBC_select_mwipqtmdef_scalar(2, &MWIPQTMDEF);
    i_hist_select_step = 10;
    if(i_count <= 0)
    {
        memset(MWIPQTMDEF.MAT_ID, ' ', sizeof(MWIPQTMDEF.MAT_ID));
        MWIPQTMDEF.MAT_VER = 0;
        i_count = (int)DBC_select_mwipqtmdef_scalar(2, &MWIPQTMDEF);
    }
    if(i_count <= 0)
    {
        memset(MWIPQTMDEF.FLOW, ' ', sizeof(MWIPQTMDEF.FLOW));
        MWIPQTMDEF.FLOW_SEQ_NUM = 0;
        i_count = (int)DBC_select_mwipqtmdef_scalar(2, &MWIPQTMDEF);

        i_hist_select_step = 11;
    }

    //Queue Time Setup exist
    if(i_count > 0)
    {
        c_queue_time_unit = COM_get_global_option_value2(MWIPLOTSTS.FACTORY, MP_OPTION_QUEUE_TIME_UNIT);

        DBC_open_mwipqtmdef(4, &MWIPQTMDEF);
        if(DB_error_code != DB_SUCCESS ) 
        {
            strcpy(s_msg_code, "WIP-0004");
            COM_get_message('1', s_msg_code, s_msg);

            LOG_head("RTD_Queue_Time_Over_1");
            LOG_add("table", MP_NSTR, "MWIPQTMDEF OPEN");
            LOG_add("error_msg", MP_STR, MP_SIZE_FIELD_MSG, s_msg );
            LOG_add("db_error_msg", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg );
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

            return MP_FALSE;  
        }

        while(1)
        {
            DBC_fetch_mwipqtmdef(4, &MWIPQTMDEF);
            if(DB_error_code != DB_SUCCESS ) 
            {
                if(DB_error_code == DB_NOT_FOUND) 
                {
                    DBC_close_mwipqtmdef( 4 );
                    break;
                }
                else 
                {
                    strcpy(s_msg_code, "WIP-0004");
                    COM_get_message('1', s_msg_code, s_msg);

                    LOG_head("RTD_Queue_Time_Over_1");
                    LOG_add("table", MP_NSTR, "MWIPQTMDEF FETCH");
                    LOG_add("error_msg", MP_STR, MP_SIZE_FIELD_MSG, s_msg );
                    LOG_add("db_error_msg", MP_STR, MP_SIZE_DB_ERROR_MSG, DB_error_msg );
                    COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
                    return MP_FALSE;  
                }
            }

            LOG_head("RTD_Queue_Time_Over_1");
            LOG_add("FLOW", MP_STR, sizeof(MWIPQTMDEF.FLOW), MWIPQTMDEF.FLOW);
            LOG_add("OPER", MP_STR, sizeof(MWIPQTMDEF.OPER), MWIPQTMDEF.OPER);
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


            //Check Operation previous operation move time
            DBC_init_mwiplothis(&MWIPLOTHIS);
            memcpy(MWIPLOTHIS.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
            memcpy(MWIPLOTHIS.OLD_FACTORY, MWIPQTMDEF.FROM_FACTORY, sizeof(MWIPLOTHIS.OLD_FACTORY));
            memcpy(MWIPLOTHIS.OLD_FLOW, MWIPQTMDEF.FROM_FLOW, sizeof(MWIPLOTHIS.OLD_FLOW));
            MWIPLOTHIS.OLD_FLOW_SEQ_NUM = MWIPQTMDEF.FROM_FLOW_SEQ_NUM;
            memcpy(MWIPLOTHIS.OLD_OPER, MWIPQTMDEF.FROM_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
            //step 10 : from_flow, from_oper,  step 11: from_oper
            DBC_select_mwiplothis(i_hist_select_step, &MWIPLOTHIS);//end, skip, rework
            if(DB_error_code != DB_SUCCESS) 
            {
                continue;
            }

            COM_diff_time_sec(&i_time_gap, s_current_time, MWIPLOTHIS.TRAN_TIME);

            if(c_queue_time_unit == 'H')
            {
                i_upper_error_queue_time = MWIPQTMDEF.UPPER_ERR_QUE_TIME * 60 * 60;
            }
            else
            {
                i_upper_error_queue_time = MWIPQTMDEF.UPPER_ERR_QUE_TIME * 60;
            }

            LOG_head("RTD_Queue_Time_Over_1");
            LOG_add("i_upper_error_queue_time", MP_INT, i_upper_error_queue_time);
            LOG_add("i_time_gap", MP_INT, i_time_gap);
            LOG_add("i_set_time", MP_INT, i_set_time);
            COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);


            if(i_upper_error_queue_time > 0)
            {
                if( (i_upper_error_queue_time - i_time_gap) < i_set_time )
                {
                    TRS.set_char(out_node, "RESULT_FLAG", 'Y');

                    DBC_close_mwipqtmdef( 4 );
                    break;
                }
            }
        }//fetch while
    }// i_count

    return MP_TRUE;
}
