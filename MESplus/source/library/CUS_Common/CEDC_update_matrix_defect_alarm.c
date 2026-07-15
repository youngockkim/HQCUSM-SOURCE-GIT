/******************************************************************************'

	System      : MESplus
	Module      : CEDC
	File Name   : CEDC_update_matrix_defect_alarm.c
	Description : Update matrix_defect_alarm

    MES Version : 5.3.6.4

	Function List  
		- CEDC_UPDATE_MATRIX_DEFECT_ALARM()
			+ Matrix defect last 3 times record
	Detail Description
		- CEDC_UPDATE_MATRIX_DEFECT_ALARM()
			+ h_proc_step
				 
	History
	Seq   Date        Developer      Description
	---------------------------------------------------------------------------
    1     2020/09/11  hchkim          Created

	Copyright(C) 1998-2018 Miracom,Inc.
	All rights reserved.

******************************************************************************/

#include "CUS_HQCUSM_common.h"

/*******************************************************************************
	CEDC_UPDATE_MATRIX_DEFECT_ALARM()
	Return Value
		- int : 1 (MP_TRUE) or 0 (MP_FALSE) 
	Arguments
		- char *s_msg_code : Error Message Code 
		- TRSNode *in_node : Input Message structure 
		- TRSNode *out_node : Output Message structure
*******************************************************************************/
int CEDC_UPDATE_MATRIX_DEFECT_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node)
{ 	
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPMIXLOS_TAG CWIPMIXLOS_NEW;
	struct CWIPMIXLOS_TAG CWIPMIXLOS;
	struct CWIPMIXLOS_TAG CWIPMIXLOS_UP;
	struct CWIPCELLOS_TAG CWIPCELLOS;
	struct CEDCLOTRLT_TAG CEDCLOTRLT;
	struct MRASRESDEF_TAG MRASRESDEF;
    
	char message[1000];
	char s_tmp[1000];
	char ins_type[3];
	struct CALMTLGHIS_TAG CALMTLGHIS;
	//clock_t start_time;

	//FOR DEBUG
	//start_time = STOPWATCH_START();
	memset(ins_type, 0x00, sizeof(ins_type));

	LOG_head("CEDC_UPDATE_MATRIX_DEFECT_ALARM");
    TRS.log_add_all_members(in_node);
    COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

	/* RES_ID Validation */
    if(COM_isnullspace(TRS.get_string(in_node, "RES_ID")) == MP_TRUE)
    {
		return MP_FALSE;
    }

	/*
	동일 매트릭스에 탑재된 모듈의 첫 FEL, 첫 AOI 판정(동일모듈의 FEL NG가 이미 있으면 제외), 연속 3회 NG 발생 시 알람발생

	FEL, BUSBAR1 (E1, B1) 최초 1회 검사 실적을 대상으로 한다.
	1 : select matrix 
	1.1 if not found insert

	2. 검사실적을 복사한다. 2->3, 1->2
	3. 최근것이 동일모듈의 B1실적이면 E1실적으로 갱신 
	
	*/
	
	DB_commit(); //

	//ins_type set
	DBC_init_mrasresdef(&MRASRESDEF);
	TRS.copy(MRASRESDEF.FACTORY, sizeof(MRASRESDEF.FACTORY), in_node, "FACTORY");
	TRS.copy(MRASRESDEF.RES_ID, sizeof(MRASRESDEF.RES_ID), in_node, "RES_ID");

	DBC_select_mrasresdef(1, &MRASRESDEF);
	if(DB_error_code != DB_SUCCESS)
    {
        if(DB_error_code == DB_NOT_FOUND)
		{
			LOG_head("MATRIX_DEFECT 1 DB_NOT_FOUND return ");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			return MP_FALSE;
		}
	}

	if(memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FRONTEND_EL_OPER, strlen(HQCEL_M1_FRONTEND_EL_OPER)) == 0)
        memcpy(ins_type,"E1",strlen("E1"));
    else if (memcmp(MRASRESDEF.RES_CMF_2, HQCEL_M1_FEEDING_OPER, strlen(HQCEL_M1_FEEDING_OPER)) == 0)
        memcpy(ins_type,"B1",strlen("B1"));
    else
	{
		LOG_head("MATRIX_DEFECT 1 ins_type return ");
		COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		return MP_FALSE;
	}
    
	CDB_init_cedclotrlt(&CEDCLOTRLT);
    TRS.copy(CEDCLOTRLT.FACTORY, sizeof(CEDCLOTRLT.FACTORY), in_node, IN_FACTORY);
    memcpy(CEDCLOTRLT.INS_TYPE,ins_type,strlen("E1"));
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");

	CDB_select_cedclotrlt(1,&CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			LOG_head("MATRIX_DEFECT 1 DB_NOT_FOUND CEDCLOTRLT return ");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

			return MP_TRUE;
		}
	}

	if(CEDCLOTRLT.INS_CNT > 1)
	{
		LOG_head("MATRIX_DEFECT 1 ins_cnt > 1 return ");
		COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		return MP_TRUE;
	}
	
	CDB_init_cwipmixlos(&CWIPMIXLOS_NEW);

	TRS.copy(CWIPMIXLOS_NEW.LOT_ID_1, sizeof(CWIPMIXLOS_NEW.LOT_ID_1), in_node, "LOT_ID");
	memcpy(CWIPMIXLOS_NEW.INS_TYPE_1,ins_type,strlen("E1"));
	memcpy(CWIPMIXLOS_NEW.INS_VALUE_1, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));	
	memcpy(CWIPMIXLOS_NEW.TRAN_TIME_1, CEDCLOTRLT.INS_TIME, sizeof(CEDCLOTRLT.INS_TIME));	

	// SEL MWIPLOTSTS  LOT_CMF_2 = MATRIX_ID
	DBC_init_mwiplotsts(&MWIPLOTSTS);
	memcpy(MWIPLOTSTS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
	
	DBC_select_mwiplotsts(1, &MWIPLOTSTS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "WIP-0004");
			TRS.add_fieldmsg(out_node, "MWIPLOTSTS SELECT LOT_ID", MP_NVST);
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
			TRS.add_dberrmsg(out_node, DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			LOG_head("MATRIX_DEFECT 2 Module DB_NOT_FOUND ");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

			return MP_FALSE;
		}
	}
	
	if(COM_isnullspace(MWIPLOTSTS.LOT_CMF_2)== MP_TRUE)
	{
		strcpy(s_msg_code, "WIP-0004");
		TRS.add_fieldmsg(out_node, "MWIPLOTSTS Matrix ID Check", MP_NVST);
		TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_ID), MWIPLOTSTS.LOT_ID);
		TRS.add_dberrmsg(out_node, DB_error_msg);
		gs_log_type.type = MP_LOG_ERROR;
		gs_log_type.e_type = MP_LOG_E_SYSTEM;
		gs_log_type.category = MP_LOG_CATE_VIEW;

		COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
		LOG_head("MATRIX_DEFECT 2 Matrix ID Check Empty ");
		COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		return MP_FALSE;
	}
	
	CDB_init_cwipcellos(&CWIPCELLOS);
	memcpy(CWIPCELLOS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
	//TRS.copy(CWIPCELLOS.LOSS_CATEGORY, strlen("00"), in_node, "INS_TYPE");
	memcpy(CWIPCELLOS.LOSS_CATEGORY,ins_type,strlen("E1"));
	memcpy(CWIPCELLOS.CELL_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
	CWIPCELLOS.LOSS_SEQ = 1;
	
	CDB_select_cwipcellos(1, &CWIPCELLOS);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING
	}

	//Get Matrix ID
	CDB_init_cwipmixlos(&CWIPMIXLOS);
	memcpy(CWIPMIXLOS.MATRIX_ID, MWIPLOTSTS.LOT_CMF_2, strlen("E02MP023"));

	CDB_init_cwipmixlos(&CWIPMIXLOS_UP);
	memcpy(CWIPMIXLOS_UP.MATRIX_ID, MWIPLOTSTS.LOT_CMF_2, strlen("E02MP023"));

	CDB_select_cwipmixlos(1, &CWIPMIXLOS);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			CDB_insert_cwipmixlos(&CWIPMIXLOS);

			LOG_head("MATRIX_DEFECT 3 Insert");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
		}
		else
		{
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			LOG_head("MATRIX_DEFECT 2 CWIPMIXLOS db error ");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			return MP_FALSE;
		}
	}
	DB_commit(); 
	
	if(memcmp(MWIPLOTSTS.LOT_ID,CWIPMIXLOS.LOT_ID_1,sizeof(MWIPLOTSTS.LOT_ID)) == 0
		&& memcmp(CWIPMIXLOS_NEW.INS_TYPE_1,"E1",strlen("E1")) == 0 
		&& memcmp(CWIPMIXLOS.INS_TYPE_1,"B1",strlen("B1")) == 0)
	{
	
		TRS.copy(CWIPMIXLOS.LOT_ID_1, sizeof(CWIPMIXLOS.LOT_ID_1), in_node, "LOT_ID");
		memcpy(CWIPMIXLOS.TRAN_TIME_1, CWIPMIXLOS_NEW.TRAN_TIME_1, sizeof(CWIPMIXLOS.TRAN_TIME_1));		
		memcpy(CWIPMIXLOS.INS_TYPE_1,ins_type,strlen("E1"));
		memcpy(CWIPMIXLOS.INS_VALUE_1, CWIPMIXLOS_NEW.INS_VALUE_1, sizeof(CWIPMIXLOS.INS_VALUE_1));		
		memcpy(CWIPMIXLOS.DEFECT_CODE_1, CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));
		memcpy(CWIPMIXLOS.CELL_LOCATION_1, CWIPCELLOS.LOCATION_ID, sizeof(CWIPMIXLOS.CELL_LOCATION_1));
		 
		CDB_update_cwipmixlos(1,&CWIPMIXLOS);

		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_insert_cwipmixlos(&CWIPMIXLOS);
			}

			if(DB_error_code != DB_SUCCESS)
			{
				LOG_head("MATRIX_DEFECT 3.2 fail");
				LOG_printf("MATRIX_DEFECT 3.2 ORA- %d   ",DB_error_code);
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPMIXLOS update", MP_NVST);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			
				return MP_FALSE;
			}
		}

		LOG_head("MATRIX_DEFECT 3.1 change B! -> E1");
        COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
	}
	else
	{
		if(memcmp(MWIPLOTSTS.LOT_ID,CWIPMIXLOS.LOT_ID_1,sizeof(MWIPLOTSTS.LOT_ID)) == 0)
		{
			//1st
		}
		else
		{
			//STOPWATCH_END("MATRIX5.1 copy 2->3, 1->2, NEW->1 ", start_time);
			memcpy(CWIPMIXLOS_UP.LOT_ID_3, CWIPMIXLOS.LOT_ID_2, sizeof(CWIPMIXLOS.LOT_ID_3));
			memcpy(CWIPMIXLOS_UP.TRAN_TIME_3, CWIPMIXLOS.TRAN_TIME_2, sizeof(CWIPMIXLOS.TRAN_TIME_3));
			memcpy(CWIPMIXLOS_UP.INS_TYPE_3, CWIPMIXLOS.INS_TYPE_2, sizeof(CWIPMIXLOS.INS_TYPE_3));
			memcpy(CWIPMIXLOS_UP.INS_VALUE_3, CWIPMIXLOS.INS_VALUE_2, sizeof(CWIPMIXLOS.INS_VALUE_3));
			memcpy(CWIPMIXLOS_UP.DEFECT_CODE_3, CWIPMIXLOS.DEFECT_CODE_2, sizeof(CWIPMIXLOS.DEFECT_CODE_3));
			memcpy(CWIPMIXLOS_UP.CELL_LOCATION_3, CWIPMIXLOS.CELL_LOCATION_2, sizeof(CWIPMIXLOS.CELL_LOCATION_3));
			// 1-> 2
			memcpy(CWIPMIXLOS_UP.LOT_ID_2, CWIPMIXLOS.LOT_ID_1, sizeof(CWIPMIXLOS.LOT_ID_2));
			memcpy(CWIPMIXLOS_UP.TRAN_TIME_2, CWIPMIXLOS.TRAN_TIME_1, sizeof(CWIPMIXLOS.TRAN_TIME_2));
			memcpy(CWIPMIXLOS_UP.INS_TYPE_2, CWIPMIXLOS.INS_TYPE_1, sizeof(CWIPMIXLOS.INS_TYPE_2));
			memcpy(CWIPMIXLOS_UP.INS_VALUE_2, CWIPMIXLOS.INS_VALUE_1, sizeof(CWIPMIXLOS.INS_VALUE_2));
			memcpy(CWIPMIXLOS_UP.DEFECT_CODE_2, CWIPMIXLOS.DEFECT_CODE_1, sizeof(CWIPMIXLOS.DEFECT_CODE_2));
			memcpy(CWIPMIXLOS_UP.CELL_LOCATION_2, CWIPMIXLOS.CELL_LOCATION_1, sizeof(CWIPMIXLOS.CELL_LOCATION_2));
			// NEW -> 1
			memcpy(CWIPMIXLOS_UP.LOT_ID_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(CWIPMIXLOS_UP.TRAN_TIME_1, CWIPMIXLOS_NEW.TRAN_TIME_1, sizeof(CWIPMIXLOS.TRAN_TIME_1));	
			memcpy(CWIPMIXLOS_UP.INS_TYPE_1, CWIPMIXLOS_NEW.INS_TYPE_1, sizeof(CWIPMIXLOS.INS_TYPE_1));	
			memcpy(CWIPMIXLOS_UP.INS_VALUE_1, CWIPMIXLOS_NEW.INS_VALUE_1, sizeof(CWIPMIXLOS.INS_VALUE_1));
			memcpy(CWIPMIXLOS_UP.DEFECT_CODE_1, CWIPCELLOS.LOSS_CODE, sizeof(CWIPCELLOS.LOSS_CODE));
			memcpy(CWIPMIXLOS_UP.CELL_LOCATION_1, CWIPCELLOS.LOCATION_ID, sizeof(CWIPMIXLOS.CELL_LOCATION_1));

			CDB_update_cwipmixlos(1,&CWIPMIXLOS_UP);

			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					CDB_insert_cwipmixlos(&CWIPMIXLOS_UP);
				}

				if(DB_error_code != DB_SUCCESS)
				{
					LOG_head("MATRIX_DEFECT 3.2 fail");
					LOG_printf("MATRIX_DEFECT 3.2 ORA- %d   ",DB_error_code);
					COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "CWIPMIXLOS update", MP_NVST);
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
	

	
	{
		CDB_init_cwipmixlos(&CWIPMIXLOS);
		memcpy(CWIPMIXLOS.MATRIX_ID, MWIPLOTSTS.LOT_CMF_2, sizeof(MWIPLOTSTS.LOT_CMF_2));
		CDB_select_cwipmixlos(2,&CWIPMIXLOS);

		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
			{
				LOG_head("MATRIX_DEFECT CWIPMIXLOS DB_NOT_FOUND");
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}
			else
			{
				LOG_head("MATRIX_DEFECT CWIPMIXLOS select Error");
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}
			DB_commit(); //
			return MP_FALSE;
			
		}
		if(CWIPMIXLOS.INS_VALUE_1[0] == 'N'
			&& CWIPMIXLOS.INS_VALUE_2[0] == 'N'
			&& CWIPMIXLOS.INS_VALUE_3[0] == 'N' )
		{
			CDB_init_calmtlghis(&CALMTLGHIS);
					
			memcpy(CALMTLGHIS.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(CALMTLGHIS.NOTIFY_SYSTEM, "HQcellUS_Matrix", strlen("HQcellUS_Matrix")); //HQcellUS_Matrix
			memcpy(CALMTLGHIS.TRAN_TIME, CWIPMIXLOS_NEW.TRAN_TIME_1, sizeof(CALMTLGHIS.TRAN_TIME));
			TRS.copy(CALMTLGHIS.CMF_1, sizeof(CALMTLGHIS.CMF_1), in_node, "RES_ID");
			//HQcellUS_Matrix_Alarm
			//E01MP021
			//- Instance 1: B03 | Soldering Defect (High), E19 | 201720375503002014
			//- Instance 2: A01 | unregistered, E99 | 201820375503002059
			//- Instance 3: A01 | unregistered, E99 | 201820375503002059
			//The matrix has resulted in Front EL defects for 3 consecutive instances.
			//STOPWATCH_END("MATRIX7 message ", start_time);

			LOG_head("MATRIX_DEFECT HQcellUS_Matrix_Alarm");
			COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);

			memset(message, 0x00, sizeof(message));
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.MATRIX_ID, sizeof(CWIPMIXLOS.MATRIX_ID));
			sprintf(message + strlen(message), "%s", s_tmp);
			
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.LOT_ID_3, sizeof(CWIPMIXLOS.LOT_ID_3));
			sprintf(message + strlen(message), "\n- Instance 1: %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.CMF_3, sizeof(CWIPMIXLOS.CMF_3));
			sprintf(message + strlen(message), " | %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.DEFECT_CODE_3, sizeof(CWIPMIXLOS.DEFECT_CODE_3));
			sprintf(message + strlen(message), " , %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.CELL_LOCATION_3, sizeof(CWIPMIXLOS.CELL_LOCATION_3));
			sprintf(message + strlen(message), " | %s", s_tmp);

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.LOT_ID_2, sizeof(CWIPMIXLOS.LOT_ID_2));
			sprintf(message + strlen(message), "\n- Instance 2: %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.CMF_2, sizeof(CWIPMIXLOS.CMF_2));
			sprintf(message + strlen(message), " | %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.DEFECT_CODE_2, sizeof(CWIPMIXLOS.DEFECT_CODE_2));
			sprintf(message + strlen(message), " , %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.CELL_LOCATION_2, sizeof(CWIPMIXLOS.CELL_LOCATION_2));
			sprintf(message + strlen(message), " | %s", s_tmp);

			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.LOT_ID_1, sizeof(CWIPMIXLOS.LOT_ID_1));
			sprintf(message + strlen(message), "\n- Instance 3: %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.CMF_1, sizeof(CWIPMIXLOS.CMF_1));
			sprintf(message + strlen(message), " | %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.DEFECT_CODE_1, sizeof(CWIPMIXLOS.DEFECT_CODE_1));
			sprintf(message + strlen(message), " , %s", s_tmp);
			memset(s_tmp, 0x00, sizeof(s_tmp)); COM_memcpy_add_null(s_tmp, CWIPMIXLOS.CELL_LOCATION_1, sizeof(CWIPMIXLOS.CELL_LOCATION_1));
			sprintf(message + strlen(message), " | %s", s_tmp);

			sprintf(message + strlen(message), "\nThe matrix has resulted in Front EL defects for 3 consecutive instances.");

			memcpy(CALMTLGHIS.NOTIFY_MESSAGE, message, sizeof(message));

			//memcpy(CALMTLGHIS.CMF_1, CWIPMIXLOS.TRAN_TIME_1, sizeof(CALMTLGHIS.CMF_1));IS-21-01-094 MES logic 개선
			//memcpy(CALMTLGHIS.CMF_2, CWIPMIXLOS.TRAN_TIME_2, sizeof(CALMTLGHIS.CMF_2));IS-21-01-094 MES logic 개선
			//memcpy(CALMTLGHIS.CMF_3, CWIPMIXLOS.TRAN_TIME_2, sizeof(CALMTLGHIS.CMF_3));IS-21-01-094 MES logic 개선
			memcpy(CALMTLGHIS.CMF_1, CWIPMIXLOS.TRAN_TIME_1, sizeof(CWIPMIXLOS.TRAN_TIME_1));
			memcpy(CALMTLGHIS.CMF_2, CWIPMIXLOS.TRAN_TIME_2, sizeof(CWIPMIXLOS.TRAN_TIME_2));
			memcpy(CALMTLGHIS.CMF_3, CWIPMIXLOS.TRAN_TIME_2, sizeof(CWIPMIXLOS.TRAN_TIME_2));
		
			CDB_insert_calmtlghis(&CALMTLGHIS); 

		}
	}

    COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

	return MP_TRUE;
} 

