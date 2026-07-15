/*******************************************************************************

    System      : MESplus
    Module      : View Rework Result
    File Name   : CWIP_View_Rework_Result.c

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2021.01.20  yookim

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_HQCUSM_common.h"

int CWIP_View_Rework_Result_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Rework_Result()
        - FQC Result
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/

int CWIP_View_Rework_Result(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_REWORK_RESULT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_UPDATE_LOT_REWORK", out_node);

    if(i_ret == MP_TRUE)
    {
        DB_commit();
    }
    else
    {
        DB_rollback();
    }

    return MP_TRUE;
}

/*******************************************************************************
    CWIP_View_Rework_Result()
        - VIEW FQC_RESULT
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_REWORK_RESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;

    //reverted
	LOG_head("CWIP_View_Rework_Result");
	TRS.log_add_all_members(in_node);
	COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

    if(CWIP_View_Rework_Result_Validation(s_msg_code, in_node, out_node) == MP_FALSE)
    {
        COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
        return MP_FALSE;
    }

	CDB_init_cedclotrlt(&CEDCLOTRLT);
    TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
    TRS.copy(CEDCLOTRLT.INS_TYPE, sizeof(CEDCLOTRLT.INS_TYPE), in_node, "INS_TYPE");
    TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);
	//CEDCLOTRLT.INS_TYPE = FC가 없는 경우 RE_JUDGE = N
	//MES OI - FQC Judgment에서만 사용한다
    if(DB_error_code != DB_SUCCESS)
    {
        TRS.add_string(out_node, "RE_JUDGE", "N", sizeof("N"));
		TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
		//memcpy(CEDCLOTRLT.INS_TYPE, "SI", sizeof("SI"));IS-21-01-094 MES logic 개선
		memcpy(CEDCLOTRLT.INS_TYPE, "SI", strlen("SI"));
		TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotrlt(1, &CEDCLOTRLT);
		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				
			}
			else
			{
			
			}

		}
		CDB_init_cedclotfqc(&CEDCLOTFQC);  
		CDB_init_mwiplothis(&MWIPLOTHIS); //2.IS-21-01-022
		
	}
	//CEDCLOTRLT.INS_TYPE = FC가 있다면 RE_JUDGE = Y
	//MES OI - FQC Judgment에서만 사용한다
	else
	{
		TRS.add_string(out_node, "RE_JUDGE", "Y", sizeof("Y"));

		if(strcmp(TRS.get_string(in_node, "INS_TYPE"), "FC") == 0)
		{
			CDB_init_cedclotfqc(&CEDCLOTFQC);
			TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
			memcpy(CEDCLOTFQC.INS_TYPE, "FC", strlen("FC"));
			TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
			CDB_select_cedclotfqc(2, &CEDCLOTFQC);
				    
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CEDCLOTFQC SELECT", MP_NVST);
						
					TRS.add_fieldmsg(out_node, "INS_TYPE", MP_STR, sizeof(CEDCLOTFQC.INS_TYPE), CEDCLOTFQC.INS_TYPE);
					TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CEDCLOTFQC.LOT_ID), CEDCLOTFQC.LOT_ID);

					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;
					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					return MP_FALSE;
				}

			}


	 	}	
		

	}
	
		//IS-21-01-022 / MES OI Rework Management (URGENT REQUEST)

		CDB_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
		CDB_select_mwiplothis(6, &MWIPLOTHIS);
				    
		if(DB_error_code != DB_SUCCESS)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTHIS SELECT", MP_NVST);
						
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTHIS.LOT_ID), MWIPLOTHIS.LOT_ID);

			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;

		}

				

	
    TRS.add_string(out_node, "LINE_ID", CEDCLOTRLT.LINE_ID, sizeof(CEDCLOTRLT.LINE_ID));
    TRS.add_string(out_node, "OPER", CEDCLOTRLT.OPER, sizeof(CEDCLOTRLT.OPER));
    TRS.add_string(out_node, "RES_ID", CEDCLOTRLT.RES_ID, sizeof(CEDCLOTRLT.RES_ID));

    TRS.add_string(out_node, "INS_VALUE", CEDCLOTRLT.INS_VALUE, sizeof(CEDCLOTRLT.INS_VALUE));
    TRS.add_string(out_node, "RLT_COMMENT", CEDCLOTRLT.RLT_COMMENT, sizeof(CEDCLOTRLT.RLT_COMMENT));
    TRS.add_string(out_node, "RESULT_VALUE", CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));
    TRS.add_string(out_node, "GRADE", CEDCLOTRLT.GRADE, sizeof(CEDCLOTRLT.GRADE));
	TRS.add_string(out_node, "POWER", CEDCLOTRLT.POWER, sizeof(CEDCLOTRLT.POWER));

    TRS.add_string(out_node, "OSC", CEDCLOTRLT.OSC, sizeof(CEDCLOTRLT.OSC));
    TRS.add_string(out_node, "ESC", CEDCLOTRLT.ESC, sizeof(CEDCLOTRLT.ESC));
    TRS.add_string(out_node, "EL", CEDCLOTRLT.EL, sizeof(CEDCLOTRLT.EL));
    TRS.add_string(out_node, "MAT_ID", CEDCLOTRLT.MAT_ID, sizeof(CEDCLOTRLT.MAT_ID));


	//[IS-20-08-004]FQC 결과 조회시 CEDCLOTFQC 에서 CELL_INFO(셀정보),DEFECT_CODE(디펙 코드 정보를 가져온다)
	if(strcmp(TRS.get_string(in_node, "INS_TYPE"), "FC") == 0)
	{
		TRS.add_string(out_node, "CELL_INFO", CEDCLOTFQC.CELL_INFO, sizeof(CEDCLOTFQC.CELL_INFO));
		TRS.add_string(out_node, "DEFECT_CODE", CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE))	;
		
		//DEFECT_CODE DESC 를 조회한다
		if(COM_isnullspace(CEDCLOTFQC.DEFECT_CODE) == MP_FALSE)
		{
			CDB_init_mgcmtbldat(&MGCMTBLDAT);
			TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, "FACTORY");
			memcpy(MGCMTBLDAT.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
			memcpy(MGCMTBLDAT.KEY_1, CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE));
			memcpy(MGCMTBLDAT.KEY_2, "M3110", strlen("M3110"));
			CDB_select_mgcmtbldat(1, &MGCMTBLDAT);

			if (DB_error_code != DB_SUCCESS)
			{
				
			}
			TRS.add_string(out_node, "DEFECT_DESC", MGCMTBLDAT.DATA_4, sizeof(MGCMTBLDAT.DATA_4));
		}
		//OPER DESC를 조회한다
		TRS.add_string(out_node, "OLD_OPER", MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
		if(COM_isnullspace(MWIPLOTHIS.OLD_OPER) == MP_FALSE)
		{
			DBC_init_mwipoprdef(&MWIPOPRDEF);
			TRS.copy(MWIPOPRDEF.FACTORY, sizeof(MWIPOPRDEF.FACTORY), in_node, "FACTORY");
			memcpy(MWIPOPRDEF.OPER, MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
			DBC_select_mwipoprdef(1, &MWIPOPRDEF);
			if(DB_error_code != DB_SUCCESS)
			{
				
			}
			TRS.add_string(out_node, "OLD_OPER_DESC", MWIPOPRDEF.OPER_DESC, sizeof(MWIPOPRDEF.OPER_DESC));
			TRS.add_string(out_node, "OLD_OPER_TRAN_TIME", MWIPLOTHIS.TRAN_TIME, sizeof(MWIPLOTHIS.TRAN_TIME));
		}

	}
	//[IS-20-08-004]


	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}

/*******************************************************************************
	CWIP_View_Rework_Result_Validation()
		- Main sub function of "CWIP_View_Rework_Result" function
		- Check the condition for View FQC Result
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CWIP_View_Rework_Result_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    struct MWIPFACDEF_TAG MWIPFACDEF;

    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "1") == MP_FALSE)
    {
        return MP_FALSE;
    }

    /* Factory Validation */
    if(COM_isnullspace(TRS.get_factory(in_node)) == MP_TRUE)
    {
        strcpy(s_msg_code, "EIS-0001");
        TRS.add_fieldmsg(out_node, "FACTORY", MP_NVST);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }

    DBC_init_mwipfacdef(&MWIPFACDEF);
    TRS.copy(MWIPFACDEF.FACTORY, sizeof(MWIPFACDEF.FACTORY), in_node, IN_FACTORY);
    DBC_select_mwipfacdef(1, &MWIPFACDEF);
    if(DB_error_code != DB_SUCCESS)
    {
        strcpy(s_msg_code, "WIP-0005");
        TRS.add_fieldmsg(out_node, "MWIPFACDEF SELECT", MP_NVST);
        TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MWIPFACDEF.FACTORY), MWIPFACDEF.FACTORY);
        TRS.add_dberrmsg(out_node, DB_error_msg);

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_VALIDATION;
        gs_log_type.category = MP_LOG_CATE_SETUP;
        return MP_FALSE;
    }


    return MP_TRUE;
}