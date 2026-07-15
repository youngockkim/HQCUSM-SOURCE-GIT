/*******************************************************************************

    System      : MESplus
    Module      : Get Grade Information
    File Name   : CPOP_view_label_print_history.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.31  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
//#include "CUS_common.h"
#include "CUS_HQCUSM_common.h"
//#include <WIPCore_common.h>

int CPOP_VIEW_LABEL_PRINT_HISTORY(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CPOP_View_Label_Print_History()
        - View_Label_Print_History
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CPOP_View_Label_Print_History(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CPOP_VIEW_LABEL_PRINT_HISTORY(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CPOP_View_Label_Print_History", out_node);

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
    CPOP_VIEW_LABEL_PRINT_HISTORY()
        - VIEW_GRADE
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CPOP_VIEW_LABEL_PRINT_HISTORY(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// init
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
    struct CPOPLBLHIS_TAG CPOPLBLHIS;
	char s_sys_time[14];
    int printed_count = 0;
	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_INSPECTION_LIST");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	// SYSTEM TIME SETTING
	memset(s_sys_time, ' ', sizeof(s_sys_time));
	DB_get_systime(s_sys_time);
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.set_fieldmsg(out_node, "DB_get_systime", MP_NVST);
        TRS.add_dberrmsg(out_node, DB_error_msg);
        TRS.set_fieldmsg(out_node,"__FILE__", MP_NSTR, __FILE__);
        TRS.set_fieldmsg(out_node, "__LINE__", MP_INT, __LINE__);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	// LOT Validation 1
	DBC_init_mwiplotsts(&MWIPLOTSTS);
    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if (DB_error_code != DB_SUCCESS)
	{
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0573");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}

	// LOT Validation 2
	CDB_init_mwipeltsts(&MWIPELTSTS);
	TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwipeltsts(2,&MWIPELTSTS);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0573");
            TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "EDC-0004");
            TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }
    //10/23/2019
    //ISSUE-09-074 - Module Backsheet Labe Print 시 Rework일때 프린터 가능하도록 
    //ISSUE-09-016 에서 분기 Grade & Powerlabel Validation 제거.
    /*
	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(MGCMLAGDAT.TABLE_NAME, "@LABEL", strlen("@LABEL"));
	memcpy(MGCMLAGDAT.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(MGCMLAGDAT.KEY_2, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
	memcpy(MGCMLAGDAT.KEY_3, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
	CDB_select_mgcmlagdat(3, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
        if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "GCM-0034");
			TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
            TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(MGCMLAGDAT.KEY_2), MGCMLAGDAT.KEY_2);
            TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MGCMLAGDAT.KEY_3), MGCMLAGDAT.KEY_3);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
		}
        else
        {
            strcpy(s_msg_code, "GCM-0007");
            TRS.add_fieldmsg(out_node, "MGCMLAGDAT SELECT", MP_NVST);
            TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MGCMLAGDAT.FACTORY), MGCMLAGDAT.FACTORY);
            TRS.add_fieldmsg(out_node, "TABLE_NAME", MP_STR, sizeof(MGCMLAGDAT.TABLE_NAME), MGCMLAGDAT.TABLE_NAME);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(MGCMLAGDAT.KEY_1), MGCMLAGDAT.KEY_1);
            TRS.add_fieldmsg(out_node, "GRADE", MP_STR, sizeof(MGCMLAGDAT.KEY_2), MGCMLAGDAT.KEY_2);
            TRS.add_fieldmsg(out_node, "POWER", MP_STR, sizeof(MGCMLAGDAT.KEY_3), MGCMLAGDAT.KEY_3);
            TRS.add_dberrmsg(out_node,DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
	}
    */

    CDB_init_cpoplblhis(&CPOPLBLHIS);
    memcpy(CPOPLBLHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
    TRS.copy(CPOPLBLHIS.PRINTED_ID, sizeof(CPOPLBLHIS.PRINTED_ID), in_node, "LOT_ID");
    memcpy(CPOPLBLHIS.LABEL_ID, HQCEL_M1_LABEL_TYPE_BACKSHEET, strlen(HQCEL_M1_LABEL_TYPE_BACKSHEET));
    CPOPLBLHIS.PRINTED_TYPE ='M';

    printed_count = CDB_select_cpoplblhis_scalar(3, &CPOPLBLHIS);
    if (DB_error_code != DB_SUCCESS)
	{
        if(DB_error_code == DB_NOT_FOUND)
		{
			//TRS.add_fieldmsg(out_node, "CDB_select_cpoplblhis_scalar", MP_NVST);
    		//gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            //COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            //return MP_FALSE;
		}
        else
        {
            //TRS.add_fieldmsg(out_node, "CDB_select_cpoplblhis_scalar", MP_NVST);
            //TRS.add_dberrmsg(out_node,DB_error_msg);
            //gs_log_type.type = MP_LOG_ERROR;
            //gs_log_type.e_type = MP_LOG_E_SYSTEM;
            //gs_log_type.category = MP_LOG_CATE_VIEW;
            //COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            //return MP_FALSE;
        }
	}

    // First Printed Time
    if(printed_count > 0)
    {
        CDB_select_cpoplblhis(3, &CPOPLBLHIS);
        if (DB_error_code != DB_SUCCESS)
	    {
            if(DB_error_code == DB_NOT_FOUND)
		    {
			    //TRS.add_fieldmsg(out_node, "CDB_select_cpoplblhis", MP_NVST);

			    //gs_log_type.e_type = MP_LOG_E_EXISTENCE;
                //COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                //return MP_FALSE;
		    }
            else
            {

                //TRS.add_fieldmsg(out_node, "CDB_select_cpoplblhis", MP_NVST);
                //TRS.add_dberrmsg(out_node,DB_error_msg);

                //gs_log_type.type = MP_LOG_ERROR;
                //gs_log_type.e_type = MP_LOG_E_SYSTEM;
                //gs_log_type.category = MP_LOG_CATE_VIEW;
                //COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                //return MP_FALSE;
            }
	    }
    }
    TRS.add_string(out_node, "MATE_NO", MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1));
	TRS.add_string(out_node, "GRADE", MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2));
    TRS.add_string(out_node, "POWER", MGCMLAGDAT.KEY_3, sizeof(MGCMLAGDAT.KEY_3));
	TRS.add_string(out_node, "PRODUCT_NM", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
	
    TRS.add_int(out_node, "QTY", printed_count); // Printed Count
    TRS.add_string(out_node, "ORDER", MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
    TRS.add_string(out_node, "START_TIME", CPOPLBLHIS.TRAN_TIME, sizeof(CPOPLBLHIS.TRAN_TIME)); // First Printed Time
    TRS.add_string(out_node, "LINE", MWIPLOTSTS.LOT_CMF_1, sizeof(MWIPLOTSTS.LOT_CMF_1)); // Line #
    /*
    TRS.add_string(out_node, "VMPP", MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

    TRS.add_string(out_node, "VSYS_UL", MGCMLAGDAT.DATA_8, sizeof(MGCMLAGDAT.DATA_8));
	TRS.add_string(out_node, "WEIGHT", MGCMLAGDAT.DATA_9, sizeof(MGCMLAGDAT.DATA_9));
    TRS.add_string(out_node, "VSYS_LL", MGCMLAGDAT.DATA_10, sizeof(MGCMLAGDAT.DATA_10));

    TRS.add_string(out_node, "LABEL_ID", MGCMLAGDAT.DATA_7, sizeof(MGCMLAGDAT.DATA_7));
    */
    
    
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}