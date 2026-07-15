/******************************************************************************'

	System      : MESplus
	Module      : CORD
	File Name   : CEDC_update_main_defect_code.c
	Description : Update inspection data

    MES Version : 5.3.6.4

	Function List  
		- CEDC_Update_Inspection_Data()
			+ Update inspection data
		- CEDC_UPDATE_INSPECTION_DATA()
			+ Main sub function of CEDC_Update_Inspection_Data function
			+ Change Current Order definition
		- CEDC_Update_Inspection_Data_Validation()
			+ Main sub function of CEDC_UPDATE_INSPECTION_DATA function
			+ Check the condition for Update inspection data
	Detail Description
		- CEDC_UPDATE_INSPECTION_DATA()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2018/12/20  Hyun           Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

int CEDC_Update_Main_Defect_Code_Validation(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/*******************************************************************************
	CEDC_Update_Main_Defect_Code()
		- Change Current Order
	Return Value
		- int : 0 (MP_TRUE)
	Arguments
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEDC_Update_Main_Defect_Code(TRSNode *in_node, TRSNode *out_node)
{
	char s_msg_code[MP_SIZE_MSG];
	int i_ret;

	memset(s_msg_code, 0x00, MP_SIZE_MSG);

	i_ret = CEDC_UPDATE_MAIN_DEFECT_CODE(s_msg_code, in_node, out_node);

	COM_out_msg_log_write(s_msg_code,"CEDC_UPDATE_INSPECTION_DATA", out_node);

	if (i_ret == MP_TRUE)
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
	CEDC_UPDATE_MAIN_DEFECT_CODE()
		- Main sub function of "CEDC_Update_Inspection_Data" function
		- Change Current Order
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEDC_UPDATE_MAIN_DEFECT_CODE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 	
	struct MRASRESDEF_TAG MRASRESDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT_L;
	struct CEDCLOTRLT_TAG CEDCLOTRLT_L;
	struct CEDCLOTRLH_TAG CEDCLOTRLH_L;
	struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CEDCLOTFQC_TAG CEDCLOTFQC;
	char c_t_update_flag = 'Y';
		
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");
	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "RAS-0003");
			TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else
		{
			strcpy(s_msg_code, "RAS-0004");
			TRS.add_fieldmsg(out_node, "MRASRESDEF SELECT", MP_NVST);
			TRS.add_fieldmsg(out_node, "FACTORY", MP_STR, sizeof(MRASRESDEF.FACTORY), MRASRESDEF.FACTORY);
			TRS.add_fieldmsg(out_node, "RES_ID", MP_STR, sizeof(MRASRESDEF.RES_ID), MRASRESDEF.RES_ID);

			TRS.add_dberrmsg(out_node,DB_error_msg);

			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	/***************************************************/
	// CEDCLOTRLT.CMF_2 : 대표불량코드 업데이트 - START
	/***************************************************/
    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0
        || memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0
        || memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0) /* FrontEnd or BackEnd EL or FQC */
	{
		//20191006
        //수와랩의 경우 CWILCELLOS에 DATA를 쌓지 않는다.
        /*
        //수와랩일 경우.
        if (strcmp(TRS.get_string(in_node, "SUALAB"), HQCEL_INS_TYPE_CATEGORY_SUALAB) == 0)
        {

		    // 1. 최종검사결과 테이블 조회
		    CDB_init_cedclotrlt(&CEDCLOTRLT_L);
		    TRS.copy(CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY), in_node, "FACTORY");
		    TRS.copy(CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLT_L.LOT_ID), in_node, "LOT_ID");


            memset(CEDCLOTRLT_L.INS_TYPE, ' ' , sizeof(CEDCLOTRLT_L.INS_TYPE));
            TRS.copy(CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLT_L.INS_TYPE), in_node, "INS_TYPE");
		    CDB_select_cedclotrlt(1, &CEDCLOTRLT_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    c_t_update_flag = 'N';
		    }

		    // 2. GCM의 DEFECT CODE 중 우선 순위가 높은 값 조회 
		    //	- CWIPCELLOS 테이블에 입력된 불량코드 중 GCM : @DEFECT 테이블의 DATA_8 컬럼의 우선순위가 높은 코드 조회(오름차순)
		    CDB_init_mgcmtbldat(&MGCMTBLDAT_L);

            //if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
            //    memcpy(CEDCLOTRLT_L.INS_TYPE, HQCEL_LOSS_CATEGORY_EL1, strlen(HQCEL_LOSS_CATEGORY_EL1));
            //else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
            //    memcpy(CEDCLOTRLT_L.INS_TYPE, HQCEL_LOSS_CATEGORY_EL2, strlen(HQCEL_LOSS_CATEGORY_EL2));
            //else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0)
            //    memcpy(CEDCLOTRLT_L.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));

		    memcpy(MGCMTBLDAT_L.FACTORY, CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY));
		    memcpy(MGCMTBLDAT_L.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
		    memcpy(MGCMTBLDAT_L.KEY_3, CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLT_L.LOT_ID));  //LOT ID
		    memcpy(MGCMTBLDAT_L.KEY_2, MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2)); //OPER
		    memcpy(MGCMTBLDAT_L.DATA_1, CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLT_L.INS_TYPE)); //INSPECTION TYPE
		    COM_itoa_left(MGCMTBLDAT_L.DATA_2, CEDCLOTRLT_L.INS_CNT, sizeof(MGCMTBLDAT_L.DATA_2)); //INSPECTION COUNT
		    CDB_select_mgcmtbldat(3, &MGCMTBLDAT_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    memset(MGCMTBLDAT_L.KEY_1, ' ' , sizeof(MGCMTBLDAT_L.KEY_1));
		    }
		
		    // 3. CEDCLOTRLT UPDATE CMF_2 : 대표불량코드
            memset(CEDCLOTRLT_L.INS_TYPE, ' ' , sizeof(CEDCLOTRLT_L.INS_TYPE));
            TRS.copy(CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLT_L.INS_TYPE), in_node, "INS_TYPE");
		    memcpy(CEDCLOTRLT_L.CMF_2, MGCMTBLDAT_L.KEY_1, sizeof(CEDCLOTRLT_L.CMF_2)); //대표불량코드
		    CDB_update_cedclotrlt(2, &CEDCLOTRLT_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    c_t_update_flag = 'N';
		    }
			
		    // 4. 이력 테이블 업데이트
		    CDB_init_cedclotrlh(&CEDCLOTRLH_L);
		    memcpy(CEDCLOTRLH_L.FACTORY, CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY));
		    memcpy(CEDCLOTRLH_L.LOT_ID, CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLH_L.LOT_ID));
		    memcpy(CEDCLOTRLH_L.INS_TYPE, CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLH_L.INS_TYPE));
		    CEDCLOTRLH_L.INS_CNT = CEDCLOTRLT_L.INS_CNT;
		    memcpy(CEDCLOTRLH_L.CMF_2, MGCMTBLDAT_L.KEY_1, sizeof(CEDCLOTRLH_L.CMF_2)); //대표불량코드
		    CDB_update_cedclotrlh(2, &CEDCLOTRLH_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    c_t_update_flag = 'N';
		    }

		    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0)
		    {
			    CDB_init_cwipcellos(&CWIPCELLOS);
			    TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, "FACTORY");
			    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			    memcpy(CWIPCELLOS.LOT_ID, CEDCLOTRLT_L.LOT_ID, sizeof(CWIPCELLOS.LOT_ID));
			    CWIPCELLOS.INS_CNT = CEDCLOTRLT_L.INS_CNT;
			    memcpy(CWIPCELLOS.LOSS_CODE, MGCMTBLDAT_L.KEY_1, sizeof(CWIPCELLOS.LOSS_CODE));
			    CDB_select_cwipcellos(2, &CWIPCELLOS);
			    if(DB_error_code != DB_SUCCESS)
			    {
				    c_t_update_flag = 'N';
			    }
			    else
			    {
				    CDB_init_cedclotfqc(&CEDCLOTFQC);
				    TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
				    memcpy(CEDCLOTFQC.INS_TYPE, "FC", sizeof("FC"));
				    TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
				    CDB_select_cedclotfqc(2, &CEDCLOTFQC);
				    if(DB_error_code != DB_SUCCESS)
				    {
					    // Do Nothing
				    }

				    memcpy(CEDCLOTFQC.DEFECT_CODE, CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));
				    memcpy(CEDCLOTFQC.POS_X, CWIPCELLOS.LOC_X, sizeof(CEDCLOTFQC.POS_X));
				    memcpy(CEDCLOTFQC.POS_Y, CWIPCELLOS.LOC_Y, sizeof(CEDCLOTFQC.POS_Y));
				    memcpy(CEDCLOTFQC.CELL_INFO, CWIPCELLOS.LOCATION_ID, sizeof(CEDCLOTFQC.CELL_INFO));
				    CDB_update_cedclotfqc(1, &CEDCLOTFQC);
				    if(DB_error_code != DB_SUCCESS)
				    {
					    // Do Nothing
				    }
			    }
		    }
        }else
        {
        */

		    // 1. 최종검사결과 테이블 조회
		    CDB_init_cedclotrlt(&CEDCLOTRLT_L);
		    TRS.copy(CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY), in_node, "FACTORY");
		    TRS.copy(CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLT_L.LOT_ID), in_node, "LOT_ID");
		    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
                memcpy(CEDCLOTRLT_L.INS_TYPE, HQCEL_LOSS_CATEGORY_EL1, strlen(HQCEL_LOSS_CATEGORY_EL1));
            else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_BACKEND_EL_OPER, strlen(HQCEL_M1_BACKEND_EL_OPER)) == 0)
                memcpy(CEDCLOTRLT_L.INS_TYPE, HQCEL_LOSS_CATEGORY_EL2, strlen(HQCEL_LOSS_CATEGORY_EL2));
            else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0)
                memcpy(CEDCLOTRLT_L.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		    CDB_select_cedclotrlt(1, &CEDCLOTRLT_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    c_t_update_flag = 'N';
		    }

		    // 2. GCM의 DEFECT CODE 중 우선 순위가 높은 값 조회 
		    //	- CWIPCELLOS 테이블에 입력된 불량코드 중 GCM : @DEFECT 테이블의 DATA_8 컬럼의 우선순위가 높은 코드 조회(오름차순)
		    CDB_init_mgcmtbldat(&MGCMTBLDAT_L);
		    memcpy(MGCMTBLDAT_L.FACTORY, CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY));
		    memcpy(MGCMTBLDAT_L.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
		    memcpy(MGCMTBLDAT_L.KEY_3, CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLT_L.LOT_ID));  //LOT ID
		    memcpy(MGCMTBLDAT_L.KEY_2, MRASRESDEF.RES_CMF_2, sizeof(MRASRESDEF.RES_CMF_2)); //OPER
		    memcpy(MGCMTBLDAT_L.DATA_1, CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLT_L.INS_TYPE)); //INSPECTION TYPE
		    COM_itoa_left(MGCMTBLDAT_L.DATA_2, CEDCLOTRLT_L.INS_CNT, sizeof(MGCMTBLDAT_L.DATA_2)); //INSPECTION COUNT
		    CDB_select_mgcmtbldat(3, &MGCMTBLDAT_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    memset(MGCMTBLDAT_L.KEY_1, ' ' , sizeof(MGCMTBLDAT_L.KEY_1));
		    }
		
		    // 3. CEDCLOTRLT UPDATE CMF_2 : 대표불량코드
		    memcpy(CEDCLOTRLT_L.CMF_2, MGCMTBLDAT_L.KEY_1, sizeof(CEDCLOTRLT_L.CMF_2)); //대표불량코드
		    CDB_update_cedclotrlt(2, &CEDCLOTRLT_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    c_t_update_flag = 'N';
		    }
			
		    // 4. 이력 테이블 업데이트
		    CDB_init_cedclotrlh(&CEDCLOTRLH_L);
		    memcpy(CEDCLOTRLH_L.FACTORY, CEDCLOTRLT_L.FACTORY, sizeof(CEDCLOTRLT_L.FACTORY));
		    memcpy(CEDCLOTRLH_L.LOT_ID, CEDCLOTRLT_L.LOT_ID, sizeof(CEDCLOTRLH_L.LOT_ID));
		    memcpy(CEDCLOTRLH_L.INS_TYPE, CEDCLOTRLT_L.INS_TYPE, sizeof(CEDCLOTRLH_L.INS_TYPE));
		    CEDCLOTRLH_L.INS_CNT = CEDCLOTRLT_L.INS_CNT;
		    memcpy(CEDCLOTRLH_L.CMF_2, MGCMTBLDAT_L.KEY_1, sizeof(CEDCLOTRLH_L.CMF_2)); //대표불량코드
		    CDB_update_cedclotrlh(2, &CEDCLOTRLH_L);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    c_t_update_flag = 'N';
		    }

		    if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER)) == 0)
		    {
			    CDB_init_cwipcellos(&CWIPCELLOS);
			    TRS.copy(CWIPCELLOS.FACTORY, sizeof(CWIPCELLOS.FACTORY), in_node, "FACTORY");
			    memcpy(CWIPCELLOS.LOSS_CATEGORY, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
			    memcpy(CWIPCELLOS.LOT_ID, CEDCLOTRLT_L.LOT_ID, sizeof(CWIPCELLOS.LOT_ID));
			    CWIPCELLOS.INS_CNT = CEDCLOTRLT_L.INS_CNT;
			    memcpy(CWIPCELLOS.LOSS_CODE, MGCMTBLDAT_L.KEY_1, sizeof(CWIPCELLOS.LOSS_CODE));
			    CDB_select_cwipcellos(2, &CWIPCELLOS);
			    if(DB_error_code != DB_SUCCESS)
			    {
				    c_t_update_flag = 'N';
			    }
			    else
			    {
				    CDB_init_cedclotfqc(&CEDCLOTFQC);
				    TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
				    //memcpy(CEDCLOTFQC.INS_TYPE, "FC", sizeof("FC"));  IS-21-01-094 MES logic 개선
				    memcpy(CEDCLOTFQC.INS_TYPE, "FC", strlen("FC"));
				    TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
				    CDB_select_cedclotfqc(2, &CEDCLOTFQC);
				    if(DB_error_code != DB_SUCCESS)
				    {
					    // Do Nothing
				    }

				    memcpy(CEDCLOTFQC.DEFECT_CODE, CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));
				    memcpy(CEDCLOTFQC.POS_X, CWIPCELLOS.LOC_X, sizeof(CEDCLOTFQC.POS_X));
				    memcpy(CEDCLOTFQC.POS_Y, CWIPCELLOS.LOC_Y, sizeof(CEDCLOTFQC.POS_Y));
				    memcpy(CEDCLOTFQC.CELL_INFO, CWIPCELLOS.LOCATION_ID, sizeof(CEDCLOTFQC.CELL_INFO));
				    CDB_update_cedclotfqc(1, &CEDCLOTFQC);
				    if(DB_error_code != DB_SUCCESS)
				    {
					    // Do Nothing
				    }
			    }
		    }
            
           
        //}
	}
	/***************************************************/
	// CEDCLOTRLT.CMF_2 : 대표불량코드 업데이트 - END
	/***************************************************/

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
    return MP_TRUE;
} 

/*******************************************************************************
	CEDC_Update_Main_Defect_Code_Validation()
		- Main sub function of "CEDC_UPDATE_INSPECTION_DATA" function
		- Check the condition for Update inspection data
		- int : 1 (MP_TRUE) or 0 (MP_FALSE)
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEDC_Update_Main_Defect_Code_Validation(char *s_msg_code,
									TRSNode *in_node,
									TRSNode *out_node)
{
    /* ProcStep Validation */
    if(COM_service_validation(s_msg_code,
                              in_node,
                              out_node,
                              TRS.get_procstep(in_node),
                              "12") == MP_FALSE)
    {
        return MP_FALSE;
    }

    return MP_TRUE;
}