/*******************************************************************************

    System      : MESplus
    Module      : Power range setup
    File Name   : CINF_download_pp105_power_range_gerp.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.11.27  SW.HWANG
	2	  2023.02.13  JD.PARK

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_POWER_RANGE_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Power_Range()
        - ERP->MES Power Range
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Power_Range_Gerp(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_POWER_RANGE_GERP(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Power_Range_Gerp", out_node);

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
    CUS_INTERFACE_DOWNLOAD_POWER_RANGE_GERP()
        - ERP->MES Power Range
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_POWER_RANGE_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct IBASPWRDAT_TAG IBASPWRDAT;
    struct IBAKPWRDAT_TAG IBAKPWRDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;

	TRSNode *list_item;
	TRSNode *in_node1;
	TRSNode *out_node1;
	char s_sys_time[14];
	char cTmp1[40];
	char cTmp2[40];
	char cTmp3[40];

	// PROCESS LOG PRINT
	LOG_head("CINF_POWER_RANGE_ERP_PP105_PROCESS");
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

	// OPEN
	CDB_init_ibaspwrdat(&IBASPWRDAT);
    CDB_open_ibaspwrdat(2, &IBASPWRDAT);
    if(DB_error_code != DB_SUCCESS) 
    {
        if(DB_error_code == DB_NOT_FOUND) 
        {
            COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
            return MP_TRUE;
        }
        else 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IBASPWRDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASPWRDAT.DOC_ID), IBASPWRDAT.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IBASPWRDAT.SITE_ID), IBASPWRDAT.SITE_ID);
			TRS.add_fieldmsg(out_node, "PROD_NO", MP_STR, sizeof(IBASPWRDAT.PROD_NO), IBASPWRDAT.PROD_NO);
            TRS.add_fieldmsg(out_node, "SALES_GRP", MP_STR, sizeof(IBASPWRDAT.SALES_GRP), IBASPWRDAT.SALES_GRP);
            TRS.add_fieldmsg(out_node, "SALES_GRP_ITEM", MP_STR, sizeof(IBASPWRDAT.SALES_GRP_ITEM), IBASPWRDAT.SALES_GRP_ITEM);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
			CDB_close_ibaspwrdat(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

	// FETCH
	while(1) 
    {
		CDB_fetch_ibaspwrdat(2, &IBASPWRDAT);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_ibaspwrdat(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IBASPWRDAT OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IBASPWRDAT.DOC_ID), IBASPWRDAT.DOC_ID);
			TRS.add_fieldmsg(out_node, "SALES_GRP", MP_STR, sizeof(IBASPWRDAT.SALES_GRP), IBASPWRDAT.SALES_GRP);
			TRS.add_fieldmsg(out_node, "SALES_GRP_ITEM", MP_STR, sizeof(IBASPWRDAT.SALES_GRP_ITEM), IBASPWRDAT.SALES_GRP_ITEM);
            TRS.add_fieldmsg(out_node, "PROD_NO", MP_STR, sizeof(IBASPWRDAT.PROD_NO), IBASPWRDAT.PROD_NO);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_ibaspwrdat(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
			

		in_node1 = TRS.create_node("IN_VALUE");
		out_node1 = TRS.create_node("OUT_VALUE");

		TRS.set_string(in_node1, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));		
		TRS.set_string(in_node1, "TABLE_NAME", HQCEL_M1_GCM_POWER_RANGE, strlen(HQCEL_M1_GCM_POWER_RANGE));
		TRS.set_string(in_node1, "USERID", MODULE_EAP, strlen(MODULE_EAP));		
		TRS.set_char(in_node1, "PROCSTEP", 'U');

		list_item = TRS.add_node(in_node1, "DATA_LIST");		
		TRS.add_string(list_item, "KEY_1", IBASPWRDAT.PROD_NO, sizeof(IBASPWRDAT.PROD_NO));
		TRS.add_string(list_item, "KEY_2", IBASPWRDAT.SALES_ORDER_NO, sizeof(IBASPWRDAT.SALES_ORDER_NO));	

		memset(cTmp1 , ' ', sizeof(cTmp1));
		memset(cTmp2 , ' ', sizeof(cTmp2));
		memset(cTmp3 , ' ', sizeof(cTmp3));
		COM_dtoa(cTmp1,IBASPWRDAT.POWER_GRADE, sizeof(IBASPWRDAT.POWER_GRADE));
		COM_dtoa(cTmp2,IBASPWRDAT.POWER_LOW  , sizeof(IBASPWRDAT.POWER_LOW));
		COM_dtoa(cTmp3,IBASPWRDAT.POWER_HIGH, sizeof(IBASPWRDAT.POWER_HIGH));
		TRS.add_string(list_item, "KEY_3", cTmp1, sizeof(cTmp1));
		TRS.add_string(list_item, "DATA_1", cTmp1, sizeof(cTmp1));
		TRS.add_string(list_item, "DATA_2", cTmp2, sizeof(cTmp2));
		TRS.add_string(list_item, "DATA_3", cTmp3, sizeof(cTmp3));


		TRS.add_string(list_item, "DATA_4", IBASPWRDAT.CMF_1, sizeof(IBASPWRDAT.CMF_1)); // MES-2033

		//Delete flag 없음 => 주석 처리
		
		//ISSUE-11-006	ERP I/F D flag처리 안되는것 아티클,파워레인지
		//Delete flag ERP 에 추가해서 삭제 기능 추가함
		if (IBASPWRDAT.DATA_FLAG == 'D')
		{
			DBC_init_mgcmlagdat(&MGCMLAGDAT);
			memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_POWER_RANGE, strlen(HQCEL_M1_GCM_POWER_RANGE));
			memcpy(MGCMLAGDAT.KEY_1, IBASPWRDAT.PROD_NO, sizeof(IBASPWRDAT.PROD_NO));
			memcpy(MGCMLAGDAT.KEY_2, IBASPWRDAT.SALES_ORDER_NO, sizeof(IBASPWRDAT.SALES_ORDER_NO));
			memcpy(MGCMLAGDAT.KEY_3, cTmp1, sizeof(cTmp1));

			DBC_select_mgcmlagdat(1, &MGCMLAGDAT);
			if (DB_error_code == DB_NOT_FOUND)
			{
				// DELETE
				CDB_delete_ibaspwrdat(1,&IBASPWRDAT);

				// BACKUP
				CDB_init_ibakpwrdat(&IBAKPWRDAT);
				memcpy(IBAKPWRDAT.DOC_ID, IBASPWRDAT.DOC_ID, sizeof(struct IBASPWRDAT_TAG));
				CDB_delete_ibakpwrdat(1, &IBAKPWRDAT);
				CDB_insert_ibakpwrdat(&IBAKPWRDAT);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}

				DB_commit();
				continue;
			}
			else
			{
				TRS.set_char(in_node1, "PROCSTEP", 'D');
			}
		}

		// INSERT GT(General Table)
		if(BAS_UPDATE_DATA_LIST(s_msg_code, in_node1, out_node1)== MP_FALSE)
		{
			DB_rollback();
			COM_set_field_db_msg(out_node, out_node1);

			// free_node 선언 후 해당 노드를 사용하여 오류 발생 및 db 에러 처리 문제 발생으로 주석 처리
			/*
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
			TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
			memcpy(IBASPWRDAT.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_ibaspwrdat(2,&IBASPWRDAT);
			*/
			// IS-21-07-007 ERP 인터페이스 방어로직 개발(Power Range)
			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Power_Range_Gerp", out_node1);

			TRS.copy(IBASPWRDAT.RETURN_MSG, sizeof(IBASPWRDAT.RETURN_MSG), out_node1, "MSG");
			CDB_update_ibaspwrdat(3,&IBASPWRDAT);
			
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			DB_commit();
			continue;
		}

		// DELETE
		CDB_delete_ibaspwrdat(1,&IBASPWRDAT);

        // BACKUP
        CDB_init_ibakpwrdat(&IBAKPWRDAT);
		memcpy(IBAKPWRDAT.DOC_ID, IBASPWRDAT.DOC_ID, sizeof(struct IBASPWRDAT_TAG));
		CDB_delete_ibakpwrdat(1, &IBAKPWRDAT);
		CDB_insert_ibakpwrdat(&IBAKPWRDAT);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		
		        
		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		DB_commit();
	}
	
	return MP_TRUE;
}