/*******************************************************************************

    System      : MESplus
    Module      : Get Grade Information
    File Name   : CWIP_view_grade.c

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
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_VIEW_GRADE(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Grade()
        - View_Grade
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Grade(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_GRADE(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Grade", out_node);

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
    CWIP_VIEW_GRADE()
        - VIEW_GRADE
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_GRADE(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// init
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT2;
	char s_sys_time[14];

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

    TRS.add_string(out_node, "MATE_NO", MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1));
	TRS.add_string(out_node, "GRADE", MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2));
    TRS.add_string(out_node, "POWER", MGCMLAGDAT.KEY_3, sizeof(MGCMLAGDAT.KEY_3));
	TRS.add_string(out_node, "PRODUCT_NM", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
	TRS.add_string(out_node, "PMPP", MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2));

	TRS.add_string(out_node, "ISC", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));
	TRS.add_string(out_node, "VOC", MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));
	TRS.add_string(out_node, "IMPP", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));
	TRS.add_string(out_node, "VMPP", MGCMLAGDAT.DATA_6, sizeof(MGCMLAGDAT.DATA_6));

    TRS.add_string(out_node, "VSYS_UL", MGCMLAGDAT.DATA_8, sizeof(MGCMLAGDAT.DATA_8));
	TRS.add_string(out_node, "WEIGHT", MGCMLAGDAT.DATA_9, sizeof(MGCMLAGDAT.DATA_9));
    TRS.add_string(out_node, "VSYS_LL", MGCMLAGDAT.DATA_10, sizeof(MGCMLAGDAT.DATA_10));

    TRS.add_string(out_node, "LABEL_ID", MGCMLAGDAT.DATA_7, sizeof(MGCMLAGDAT.DATA_7));

	//@LABEL2 Á¶È¸
	CDB_init_mgcmlagdat(&MGCMLAGDAT2);
	memcpy(MGCMLAGDAT2.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	memcpy(MGCMLAGDAT2.TABLE_NAME, "@LABEL_2", strlen("@LABEL_2"));
	memcpy(MGCMLAGDAT2.KEY_1, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
	memcpy(MGCMLAGDAT2.KEY_2, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
	memcpy(MGCMLAGDAT2.KEY_3, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
	CDB_select_mgcmlagdat(3, &MGCMLAGDAT2);
	if (DB_error_code != DB_SUCCESS)
	{
		TRS.add_string(out_node, "BSTC_NOT_NULL", "FALSE", sizeof("FALSE"));
	}
	else
	{
		TRS.add_string(out_node, "BSTC_NOT_NULL", "TRUE", sizeof("TRUE"));		
	}	
		
	TRS.add_string(out_node, "BSTC_PMPP", MGCMLAGDAT2.DATA_2, sizeof(MGCMLAGDAT2.DATA_2));
	TRS.add_string(out_node, "BSTC_ISC", MGCMLAGDAT2.DATA_3, sizeof(MGCMLAGDAT2.DATA_3));
	TRS.add_string(out_node, "BSTC_VOC", MGCMLAGDAT2.DATA_4, sizeof(MGCMLAGDAT2.DATA_4));
	TRS.add_string(out_node, "BSTC_IMPP", MGCMLAGDAT2.DATA_5, sizeof(MGCMLAGDAT2.DATA_5));
	TRS.add_string(out_node, "BSTC_VMPP", MGCMLAGDAT2.DATA_6, sizeof(MGCMLAGDAT2.DATA_6));
	
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}