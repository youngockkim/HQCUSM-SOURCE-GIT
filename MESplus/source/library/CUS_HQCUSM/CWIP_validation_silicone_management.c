/*******************************************************************************

    System      : MESplus
    Module      : Validation Silicone Management
    File Name   : CWIP_validation_silicone_management.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2020.06.13  yeonkeun.lim

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>
#include "CUS_HQCUSM_common.h"

int CWIP_VALIDATOIN_SILICONE_MANAGEMENT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_validation_silicone_management()
        - CWIP_validation_silicone_management
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Validation_Silicone_Management(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VALIDATION_SILICONE_MANAGEMENT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_VALIDATION_SILICONE_MANAGEMENT", out_node);

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
    CWIP_VALIDATION_SILICONE_MANAGEMENT()
        - VALIDATION_SILICONE_MANAGEMENT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VALIDATION_SILICONE_MANAGEMENT(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{
	// INIT
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	TRSNode *list_item;
	
	// PROCESS LOG PRINT
	LOG_head("CWIP_VALIDATION_SILICONE_MANAGEMENT");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	if(TRS.get_procstep(in_node) == '1') 
	{
		list_item = TRS.add_node(out_node, "VIEW_RESULT_OUT");

		CDB_init_mgcmlagdat(&MGCMLAGDAT);
		TRS.copy(MGCMLAGDAT.FACTORY, sizeof(MGCMLAGDAT.FACTORY), in_node, "FACTORY");
		TRS.copy(MGCMLAGDAT.TABLE_NAME, sizeof(MGCMLAGDAT.TABLE_NAME), in_node, "TABLE_NAME");
		TRS.copy(MGCMLAGDAT.KEY_1, sizeof(MGCMLAGDAT.KEY_1), in_node, "SILICONE_TYPE");
		
		if(memcmp(MGCMLAGDAT.TABLE_NAME, "@JB_ATTCH_SIL_WEIGHT", strlen("@JB_ATTCH_SIL_WEIGHT")) == 0)
		{
			//memcpy(MGCMLAGDAT.KEY_2, "L", sizeof("L"));
			memset(MGCMLAGDAT.KEY_2, ' ', sizeof(MGCMLAGDAT.KEY_2));
			MGCMLAGDAT.KEY_2[0] = 'L';
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "LEFT_WEIGHT");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "LEFT_WEIGHT_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
			
			memset(MGCMLAGDAT.KEY_2, ' ', sizeof(MGCMLAGDAT.KEY_2));
			memcpy(MGCMLAGDAT.KEY_2, "R", strlen("R"));
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "RIGHT_WEIGHT");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "RIGHT_WEIGHT_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));

			memset(MGCMLAGDAT.KEY_2, ' ', sizeof(MGCMLAGDAT.KEY_2));
			memcpy(MGCMLAGDAT.KEY_2, "M", strlen("M"));
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "CENTER_WEIGHT");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "CENTER_WEIGHT_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
		}
		else if(memcmp(MGCMLAGDAT.TABLE_NAME, "@POTT_SIL_RATIO", strlen("@POTT_SIL_RATIO")) == 0)
		{
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "POTTING_WEIGHT_RATIO");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "RATIO_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
			
		/*}
		else if(memcmp(MGCMLAGDAT.TABLE_NAME, "@POTT_SIL_RATIO2", strlen("@POTT_SIL_RATIO2")) == 0)
		{*/
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "POTTING_WEIGHT_RATIO2");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "RATIO_RS2", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
			
		}
		else if(memcmp(MGCMLAGDAT.TABLE_NAME, "@POTT_SIL_WEIGHT", strlen("@POTT_SIL_WEIGHT")) == 0)
		{
			//TRS.copy(MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2), in_node, "SILICONE_SIDE");
			memset(MGCMLAGDAT.KEY_2, ' ', sizeof(MGCMLAGDAT.KEY_2));
			memcpy(MGCMLAGDAT.KEY_2, "L", strlen("L"));
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "LEFT_WEIGHT");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "LEFT_WEIGHT_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
			
			memset(MGCMLAGDAT.KEY_2, ' ', sizeof(MGCMLAGDAT.KEY_2));
			memcpy(MGCMLAGDAT.KEY_2, "R", strlen("R"));
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "RIGHT_WEIGHT");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "RIGHT_WEIGHT_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
			
			memset(MGCMLAGDAT.KEY_2, ' ', sizeof(MGCMLAGDAT.KEY_2));
			memcpy(MGCMLAGDAT.KEY_2, "M", strlen("M"));
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "CENTER_WEIGHT");
			CDB_select_mgcmlagdat(7, &MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "CENTER_WEIGHT_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
			
		}
		else if(memcmp(MGCMLAGDAT.TABLE_NAME, "@FRAME_MODULE_WEIGHT", strlen("@FRAME_MODULE_WEIGHT")) == 0)
		{
			memset(MGCMLAGDAT.KEY_2, ' ', sizeof(MGCMLAGDAT.KEY_2));
			TRS.copy(MGCMLAGDAT.KEY_2, sizeof(MGCMLAGDAT.KEY_2), in_node, "FRAME_MODULE_TYPE");
			memcpy(MGCMLAGDAT.KEY_3, "Short", strlen("Short"));
			
			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "FRAME_SHORT_WEIGHT");
			CDB_select_mgcmlagdat(8, &MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "FRAME_SHORT_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));
			
			memset(MGCMLAGDAT.KEY_3, ' ', sizeof(MGCMLAGDAT.KEY_3));
			memcpy(MGCMLAGDAT.KEY_3, "Long", strlen("Long"));

			TRS.copy(MGCMLAGDAT.DATA_2, sizeof(MGCMLAGDAT.DATA_2), in_node, "FRAME_LONG_WEIGHT");
			CDB_select_mgcmlagdat(8, &MGCMLAGDAT);
			if(DB_error_code != DB_SUCCESS)
			{
				memcpy(MGCMLAGDAT.DATA_1, "NG", strlen("NG"));
			}
			TRS.add_string(list_item, "FRAME_LONG_RS", MGCMLAGDAT.DATA_1, sizeof(MGCMLAGDAT.DATA_1));

		}
		//히스토리 저장 END
	}
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}