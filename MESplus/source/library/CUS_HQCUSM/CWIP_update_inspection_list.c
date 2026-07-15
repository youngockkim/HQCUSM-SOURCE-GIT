/*******************************************************************************

    System      : MESplus
    Module      : Update Inspection List
    File Name   : CWIP_update_inspection_list.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2019.1.4  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <WIPCore_common.h>

int CWIP_UPDATE_INSPECTION_LIST(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_Update_Inspection_List()
        - Update_Inspection_List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_Update_Inspection_List(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_UPDATE_INSPECTION_LIST(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_Update_Inspection_List", out_node);

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
    CWIP_UPDATE_INSPECTION_LIST()
        - UPDATE_INSPECTION_LIST
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_UPDATE_INSPECTION_LIST(char *s_msg_code,
                        TRSNode *in_node,
                        TRSNode *out_node)
{

	// INIT
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPELTHIS_TAG MWIPELTHIS;
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

	// INIT
	CDB_init_mwipeltsts(&MWIPELTSTS);
	TRS.copy(MWIPELTSTS.LOT_ID, sizeof(MWIPELTSTS.LOT_ID), in_node, "LOT_ID");
	CDB_select_mwipeltsts(1, &MWIPELTSTS);
	if(DB_error_code != DB_SUCCESS)
    {
		if(DB_error_code == DB_NOT_FOUND)
		{
			MWIPELTSTS.HIST_SEQ = 0;
			memcpy(MWIPELTSTS.CURING_TIME, s_sys_time, sizeof(MWIPELTSTS.CURING_TIME)) ;//파티션키로 사용하고 있으므로 업데이트 금지
			CDB_insert_mwipeltsts(&MWIPELTSTS);	
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
		else
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
        
    }

	//현재 ELTSTS.HISTORY SEQUENCE  와 실제 DB 의 HISTORY SEQUENCE 비교
	//데이터 다 날릴 위험 회피
	if (MWIPELTSTS.HIST_SEQ != TRS.get_int(in_node, "HIST_SEQ"))
	{
		strcpy(s_msg_code, "WIP-0602");
        TRS.set_fieldmsg(out_node, "HISTORY SEQUECT MISMATCH", MP_NVST);
         gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_TRANS;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
	}

	MWIPELTSTS.HIST_SEQ = MWIPELTSTS.HIST_SEQ + 1;
	TRS.copy(MWIPELTSTS.ARTICLE_EXT_NO, sizeof(MWIPELTSTS.ARTICLE_EXT_NO), in_node, "ARTICLE_EXT_NO");
	TRS.copy(MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO), in_node, "ARTICLE_NO");
	TRS.copy(MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS), in_node, "COLOR_CLASS");
	TRS.copy(MWIPELTSTS.EFF, sizeof(MWIPELTSTS.EFF), in_node, "EFF");
	TRS.copy(MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL), in_node, "EL");
	//TRS.copy(MWIPELTSTS.EL_IMAGE_PATH, sizeof(MWIPELTSTS.EL_IMAGE_PATH), in_node, "EL_IMAGE_PATH");
	TRS.copy(MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC), in_node, "ESC");
	TRS.copy(MWIPELTSTS.FF, sizeof(MWIPELTSTS.FF), in_node, "FF");
	TRS.copy(MWIPELTSTS.FLASHER_CODE, sizeof(MWIPELTSTS.FLASHER_CODE), in_node, "FLASHER_CODE");
	TRS.copy(MWIPELTSTS.FQC_TIME, sizeof(MWIPELTSTS.FQC_TIME), in_node, "FQC_TIME");
	TRS.copy(MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE), in_node, "GRADE");	
	TRS.copy(MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP), in_node, "IMPP");
	TRS.copy(MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC), in_node, "ISC");
	TRS.copy(MWIPELTSTS.LINE_ID, sizeof(MWIPELTSTS.LINE_ID), in_node, "LINE_ID");
	TRS.copy(MWIPELTSTS.LOC_ID, sizeof(MWIPELTSTS.LOC_ID), in_node, "LOC_ID");
	TRS.copy(MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC), in_node, "OSC");
	TRS.copy(MWIPELTSTS.PAK_BAR_INFO, sizeof(MWIPELTSTS.PAK_BAR_INFO), in_node, "PAK_BAR_INFO");
	TRS.copy(MWIPELTSTS.PAK_GROUP, sizeof(MWIPELTSTS.PAK_GROUP), in_node, "PAK_GROUP");
	TRS.copy(MWIPELTSTS.PAK_MOD_TYPE, sizeof(MWIPELTSTS.PAK_MOD_TYPE), in_node, "PAK_MOD_TYPE");
	TRS.copy(MWIPELTSTS.PALLET_ID, sizeof(MWIPELTSTS.PALLET_ID), in_node, "PALLET_ID");
	TRS.copy(MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP), in_node, "PMPP");
	TRS.copy(MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER), in_node, "POWER");
	TRS.copy(MWIPELTSTS.RS, sizeof(MWIPELTSTS.RS), in_node, "RS");
	TRS.copy(MWIPELTSTS.RSH, sizeof(MWIPELTSTS.RSH), in_node, "RSH");
	TRS.copy(MWIPELTSTS.SUN, sizeof(MWIPELTSTS.SUN), in_node, "SUN");
	TRS.copy(MWIPELTSTS.SURFTEMP, sizeof(MWIPELTSTS.SURFTEMP), in_node, "SURFTEMP");
	TRS.copy(MWIPELTSTS.TEMP, sizeof(MWIPELTSTS.TEMP), in_node, "TEMP");
	TRS.copy(MWIPELTSTS.TREF, sizeof(MWIPELTSTS.TREF), in_node, "TREF");
	TRS.copy(MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP), in_node, "VMPP");
	TRS.copy(MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC), in_node, "VOC");
	
	CDB_update_mwipeltsts(1, &MWIPELTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "MWIPELTSTS UPDATE", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
		TRS.add_dberrmsg(out_node,DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;
		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		return MP_FALSE;
	}

	// INIT
	CDB_init_mwipelthis(&MWIPELTHIS);

	//STRUCTURE 구조가 같을경우 전체 STRUCT 를 COPY 할떄 사용.
	//( 대상이 되는 첫주소 에 소스의 첫주소 부터 전체 STRUCTURE 를 카피하라는 문장임)
		// 이해안됨 사용함 안됨.
		// 두스트럭쳐가 틀리면 사용하면 안됨.
	memcpy(MWIPELTHIS.LOT_ID, MWIPELTSTS.LOT_ID, sizeof(struct MWIPELTSTS_TAG));

	/****
	MWIPELTHIS.HIST_SEQ = MWIPELTSTS.HIST_SEQ;
	TRS.copy(MWIPELTHIS.LOT_ID, sizeof(MWIPELTHIS.LOT_ID), in_node, "LOT_ID");
	TRS.copy(MWIPELTHIS.ARTICLE_EXT_NO, sizeof(MWIPELTHIS.ARTICLE_EXT_NO), in_node, "ARTICLE_EXT_NO");
	TRS.copy(MWIPELTHIS.ARTICLE_NO, sizeof(MWIPELTHIS.ARTICLE_NO), in_node, "ARTICLE_NO");
	TRS.copy(MWIPELTHIS.COLOR_CLASS, sizeof(MWIPELTHIS.COLOR_CLASS), in_node, "COLOR_CLASS");
	TRS.copy(MWIPELTHIS.CURING_TIME, sizeof(MWIPELTHIS.CURING_TIME), in_node, "CURING_TIME");
	TRS.copy(MWIPELTHIS.EFF, sizeof(MWIPELTHIS.EFF), in_node, "EFF");
	TRS.copy(MWIPELTHIS.EL, sizeof(MWIPELTHIS.EL), in_node, "EL");
	TRS.copy(MWIPELTHIS.EL_IMAGE_PATH, sizeof(MWIPELTHIS.EL_IMAGE_PATH), in_node, "EL_IMAGE_PATH");
	TRS.copy(MWIPELTHIS.ESC, sizeof(MWIPELTHIS.ESC), in_node, "ESC");
	TRS.copy(MWIPELTHIS.FF, sizeof(MWIPELTHIS.FF), in_node, "FF");
	TRS.copy(MWIPELTHIS.FLASHER_CODE, sizeof(MWIPELTHIS.FLASHER_CODE), in_node, "FLASHER_CODE");
	TRS.copy(MWIPELTHIS.FQC_TIME, sizeof(MWIPELTHIS.FQC_TIME), in_node, "FQC_TIME");
	TRS.copy(MWIPELTHIS.GRADE, sizeof(MWIPELTHIS.GRADE), in_node, "GRADE");	
	TRS.copy(MWIPELTHIS.IMPP, sizeof(MWIPELTHIS.IMPP), in_node, "IMPP");
	TRS.copy(MWIPELTHIS.ISC, sizeof(MWIPELTHIS.ISC), in_node, "ISC");
	TRS.copy(MWIPELTHIS.LINE_ID, sizeof(MWIPELTHIS.LINE_ID), in_node, "LINE_ID");
	TRS.copy(MWIPELTHIS.LOC_ID, sizeof(MWIPELTHIS.LOC_ID), in_node, "LOC_ID");
	TRS.copy(MWIPELTHIS.OSC, sizeof(MWIPELTHIS.OSC), in_node, "OSC");
	TRS.copy(MWIPELTHIS.PAK_BAR_INFO, sizeof(MWIPELTHIS.PAK_BAR_INFO), in_node, "PAK_BAR_INFO");
	TRS.copy(MWIPELTHIS.PAK_GROUP, sizeof(MWIPELTHIS.PAK_GROUP), in_node, "PAK_GROUP");
	TRS.copy(MWIPELTHIS.PAK_MOD_TYPE, sizeof(MWIPELTHIS.PAK_MOD_TYPE), in_node, "PAK_MOD_TYPE");
	TRS.copy(MWIPELTHIS.PALLET_ID, sizeof(MWIPELTHIS.PALLET_ID), in_node, "PALLET_ID");
	TRS.copy(MWIPELTHIS.PMPP, sizeof(MWIPELTHIS.PMPP), in_node, "PMPP");
	TRS.copy(MWIPELTHIS.POWER, sizeof(MWIPELTHIS.POWER), in_node, "POWER");
	TRS.copy(MWIPELTHIS.RS, sizeof(MWIPELTHIS.RS), in_node, "RS");
	TRS.copy(MWIPELTHIS.RSH, sizeof(MWIPELTHIS.RSH), in_node, "RSH");
	TRS.copy(MWIPELTHIS.SUN, sizeof(MWIPELTHIS.SUN), in_node, "SUN");
	TRS.copy(MWIPELTHIS.SURFTEMP, sizeof(MWIPELTHIS.SURFTEMP), in_node, "SURFTEMP");
	TRS.copy(MWIPELTHIS.TEMP, sizeof(MWIPELTHIS.TEMP), in_node, "TEMP");
	TRS.copy(MWIPELTHIS.TREF, sizeof(MWIPELTHIS.TREF), in_node, "TREF");
	TRS.copy(MWIPELTHIS.VMPP, sizeof(MWIPELTHIS.VMPP), in_node, "VMPP");
	TRS.copy(MWIPELTHIS.VOC, sizeof(MWIPELTHIS.VOC), in_node, "VOC");
	***/

	CDB_insert_mwipelthis(&MWIPELTHIS);	
	if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0004");
        TRS.add_fieldmsg(out_node, "MWIPELTHIS INSERT", MP_NVST);
        TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTHIS.LOT_ID), MWIPELTHIS.LOT_ID);
        TRS.add_dberrmsg(out_node,DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }
		
	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;

}