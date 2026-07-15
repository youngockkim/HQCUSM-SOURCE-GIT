/*******************************************************************************

    System      : MESplus
    Module      : Additional Master setup
    File Name   : CINF_download_sd205_terminate_info.c
    Description : ERP IF Table -> MES Backup Table

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2021.06.29  hahakg

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_TERMINATE_INFO(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Material_Master()
        - ERP->MES Additional Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Terminate_Info(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_TERMINATE_INFO(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_INTERFACE_DOWNLOAD_TERMINATE_INFO", out_node);

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
    CUS_INTERFACE_DOWNLOAD_Material_Master()
        - ERP->MES Material Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_TERMINATE_INFO(char *s_msg_code,


                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
    struct IWIPTERINF_TAG IWIPTERINF;
    struct IBAKTERINF_TAG IBAKTERINF;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct MWIPCALDEF_TAG MWIPCALDEF;
	
	struct worktime_tag cur_work_time;



//	TRSNode *list_item;
	TRSNode *in_node1;
	TRSNode *out_node1;

	char s_sys_time[14];
	char s_val_check;
	char s_val_MSG[500];

	int i_post_date_int;
	
	char s_back_time[14];

	char yyyy[4];
	char mm[2];
	char dd[2];
	char s_actual_time[14];


	i_post_date_int = 0;
		
		

  
	// PROCESS LOG PRINT

	LOG_head("CINF_DOWNLOAD_TERMINATE_SD205_PROCESS");
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
	CDB_init_iwipterinf(&IWIPTERINF);
    CDB_open_iwipterinf(2, &IWIPTERINF);

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
            TRS.add_fieldmsg(out_node, "IWIPTERINF OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "ZTSMP", MP_STR, sizeof(IWIPTERINF.ZTSMP), IWIPTERINF.ZTSMP);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IWIPTERINF.MODULE_ID), IWIPTERINF.MODULE_ID);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPTERINF.ZTYP1), IWIPTERINF.ZTYP1);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }
    }

	// FETCH
    while(1)
    {
        CDB_fetch_iwipterinf(2, &IWIPTERINF);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwipterinf(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPTERINF OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "ZTSMP", MP_STR, sizeof(IWIPTERINF.ZTSMP), IWIPTERINF.ZTSMP);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IWIPTERINF.MODULE_ID), IWIPTERINF.MODULE_ID);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPTERINF.ZTYP1), IWIPTERINF.ZTYP1);

            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipterinf(1);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		//0.인터페이스 시간 셋업

	

		memcpy(IWIPTERINF.ZIFDATE, s_sys_time, 8);
		
		IWIPTERINF.ZIFTIME[0] = s_sys_time[8];
		IWIPTERINF.ZIFTIME[1] = s_sys_time[9];
		IWIPTERINF.ZIFTIME[2] = s_sys_time[10];
		IWIPTERINF.ZIFTIME[3] = s_sys_time[11];
		IWIPTERINF.ZIFTIME[4] = s_sys_time[12];
		IWIPTERINF.ZIFTIME[5] = s_sys_time[13];

		

		in_node1 = TRS.create_node("IN_VALUE");
		out_node1 = TRS.create_node("OUT_VALUE");



		//1.validation 체크		
		s_val_check = ' ';
		memset(s_val_MSG,  ' ', sizeof(s_val_MSG));
		//1.1)인터페이스 된 데이터의 유효성 검사(LOT_ID,ZTSMP,ZTYP1,POST_DATE)

		if(COM_isnullspace(IWIPTERINF.REGDAT) == MP_TRUE)
		{
			s_val_check = 'E';	
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [REGDAT] is NULL", strlen("Validation Error : [REGDAT] is NULL"));
		}

		if(COM_isnullspace(IWIPTERINF.REGTIM) == MP_TRUE)
		{
			s_val_check = 'E';	
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [REGTIM] is NULL", strlen("Validation Error : [REGTIM] is NULL"));

		}

		if(COM_isnullspace(IWIPTERINF.MODULE_ID) == MP_TRUE)
		{
			s_val_check = 'E';	
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [Lot] is NULL", strlen("Validation Error : [Lot] is NULL"));
		}

		if(COM_isnullspace(IWIPTERINF.ZTSMP) == MP_TRUE && s_val_check != 'E')
		{
			s_val_check = 'E';
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [ZTSMP] is NULL", strlen("Validation Error : [ZTSMP] is NULL"));
		}

		if(sizeof(IWIPTERINF.ZTYP1)<1 && s_val_check != 'E') 
		{
			s_val_check = 'E';
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [ZTYP1] is NULL", strlen("Validation Error : [ZTYP1] is NULL"));
		}

		if(COM_isnullspace(IWIPTERINF.POST_DATE) == MP_TRUE && s_val_check != 'E')
		{
			s_val_check = 'E';
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [POST_DATE] is NULL", strlen("Validation Error : [POST_DATE] is NULL"));
	
		}

		if(COM_isnullspace(IWIPTERINF.POST_DATE) == MP_FALSE && s_val_check != 'E')
		{
			i_post_date_int = COM_string_length(IWIPTERINF.POST_DATE, sizeof(IWIPTERINF.POST_DATE));  //post date 자릿수 확인
				
			if(i_post_date_int != 8)		//8자리가 아니면 에러
			{
				s_val_check = 'E';
				memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
				memcpy(s_val_MSG, "Validation Error : [POST_DATE] of lenth is error", strlen("Validation Error : [POST_DATE] of lenth is error"));
			}

		}


		
		if(COM_isnullspace(IWIPTERINF.MOVE_TYPE) == MP_TRUE && s_val_check != 'E')
		{
			s_val_check = 'E';
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [MOVE_TYPE] is NULL", strlen("Validation Error : [MOVE_TYPE] is NULL"));
		}



		//1.2)모듈이 존재하는지
		
		CDB_init_mwiplotsts(&MWIPLOTSTS);

		memcpy(MWIPLOTSTS.LOT_ID, IWIPTERINF.MODULE_ID, sizeof(MWIPLOTSTS.LOT_ID));
		CDB_select_mwiplotsts(1, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			s_val_check = 'E';
			memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
			memcpy(s_val_MSG, "Validation Error : [Moudle] IS not found", strlen("Validation Error : [Moudle] IS not found"));
		}

		
		if(s_val_check != 'E')
		{	
			//1.3)폐기시 패킹 여부 확인

			if(IWIPTERINF.ZTYP1 =='I' && s_val_check != 'E')
			{
				CDB_init_cwiplotpak(&CWIPLOTPAK);
				
				memcpy(CWIPLOTPAK.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
				memcpy(CWIPLOTPAK.LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
				CWIPLOTPAK.STATUS_FLAG = 'C';  
				if (CDB_select_cwiplotpak_scalar(3, &CWIPLOTPAK) > 0)		//패킹 되었으면 폐기 안됨
				{
					s_val_check = 'E';
					memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
					memcpy(s_val_MSG, "Validation Error : [Moudle] was packing", strlen("Validation Error : [Moudle] was packing"));
				}
			}
			//1.4)폐기시 이미 폐기 되어 있는지 확인
			if(IWIPTERINF.ZTYP1 =='I' && MWIPLOTSTS.LOT_DEL_FLAG == 'Y' && s_val_check != 'E')
			{
					s_val_check = 'E';
					memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
					memcpy(s_val_MSG, "Validation Error : [Moudle] was already Terminate", strlen("Validation Error : [Moudle] was already Terminate"));
			}

			//1.5)폐기 취소시 폐기 되어 있는 지 확인
			if(IWIPTERINF.ZTYP1 =='D' && MWIPLOTSTS.LOT_DEL_FLAG == ' '&& s_val_check != 'E')
			{
					s_val_check = 'E';

					memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
					memcpy(s_val_MSG, "Validation Error : [Moudle] was Not Terminate", strlen("Validation Error : [Moudle] was Not Terminate"));
					
			}

		}
					

		if (s_val_check == 'E')
		{
            //Insert Error인경우 log를 남긴다.
			IWIPTERINF.RETURN_TYPE  = 'E';
			memcpy(IWIPTERINF.RETURN_MSG, s_val_MSG, sizeof(s_val_MSG));		
			

			CDB_update_iwipterinf(1,&IWIPTERINF);
			DB_commit();
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			continue;
		}
		
		


		//1.6 퍠기 인경우 근무조를 가져온다(캘린더에서)
		if(IWIPTERINF.ZTYP1 =='I')
		{
			//REGDAT 와 타임 기준으로 워킹 데이트와 근무조를 가져온다.

			memset(s_actual_time, 0x00, sizeof(s_actual_time)); // Server Crash 초기화 되지 않은 변수
			
			strncpy(s_actual_time,IWIPTERINF.REGDAT,8);
			s_actual_time[8] = IWIPTERINF.REGTIM[0];
			s_actual_time[9] = IWIPTERINF.REGTIM[1];
			s_actual_time[10] = IWIPTERINF.REGTIM[2];
			s_actual_time[11] = IWIPTERINF.REGTIM[3];
			s_actual_time[12] = IWIPTERINF.REGTIM[4];
			s_actual_time[13] = IWIPTERINF.REGTIM[5];
			
					
			CCOM_get_work_time(s_actual_time, &cur_work_time);

			DBC_init_mwipcaldef(&MWIPCALDEF);
			memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //해당 칼렌다로 변경필요.
			MWIPCALDEF.CALENDAR_TYPE = 'F';

			strncpy(yyyy,cur_work_time.work_date,4);
			strncpy(mm,cur_work_time.work_date+4,2);
			strncpy(dd,cur_work_time.work_date+6,2);

			MWIPCALDEF.SYS_YEAR = COM_atoi(yyyy,sizeof(yyyy));
			MWIPCALDEF.SYS_MONTH = COM_atoi(mm,sizeof(mm));
			MWIPCALDEF.SYS_DAY = COM_atoi(dd,sizeof(dd));
			DBC_select_mwipcaldef(1, &MWIPCALDEF);

			if (DB_error_code != DB_SUCCESS)
			{
				//캘린더 조회가 안되는 경우 에러 발생
				IWIPTERINF.RETURN_TYPE  = 'E';
				memcpy(s_val_MSG, "RAS-0004 : MWIPCALDEF OPEN", sizeof(s_val_MSG));
				memcpy(IWIPTERINF.RETURN_MSG, s_val_MSG, sizeof(IWIPTERINF.RETURN_MSG));		
			
				CDB_update_iwipterinf(1,&IWIPTERINF);
				DB_commit();
				TRS.free_node(in_node1);
				TRS.free_node(out_node1);

				continue;
			}

		
		}

		//2.폐기 시작
		if(IWIPTERINF.ZTYP1 =='I')
		{

			TRS.set_string(in_node1, "FACTORY", "USGAM1", strlen("USGAM1"));				//공장
			TRS.add_char(in_node1, "PROCSTEP", '1');
			TRS.add_char(in_node1, "LANGUAGE", '1');
			TRS.set_string(in_node1, "LOT_ID", IWIPTERINF.MODULE_ID, sizeof(IWIPTERINF.MODULE_ID));				//모듈
			TRS.set_string(in_node1, "TRAN_CMF_16", "Y", 1);				//Don't count to cell loss 체크
			TRS.set_string(in_node1, "TRAN_CMF_20", IWIPTERINF.REGDAT, 8);				//폐기일
	

			memset(s_back_time,  ' ', sizeof(s_back_time));

			memcpy(s_back_time, IWIPTERINF.POST_DATE, 8);		
			s_back_time[8] = '0';
			s_back_time[9] = '0';
			s_back_time[10] = '0';
			s_back_time[11] = '0';
			s_back_time[12] = '0';
			s_back_time[13] = '0';
		

			//TRS.set_string(in_node1, "BACK_TIME", s_back_time, sizeof(s_back_time));				//폐기일
			TRS.set_string(in_node1, "BACK_TIME", s_sys_time, sizeof(s_sys_time));				//폐기일
			TRS.set_string(in_node1, "MAT_ID", MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));		//자재번호
			TRS.set_int(in_node1,"MAT_VER",MWIPLOTSTS.MAT_VER);		//mat_ver
			TRS.set_int(in_node1,"FLOW_SEQ_NUM",MWIPLOTSTS.FLOW_SEQ_NUM);		////FLOW_SEQ_NUM	
			TRS.set_string(in_node1, "FLOW", MWIPLOTSTS.FLOW, sizeof(MWIPLOTSTS.FLOW));				//FLOW
			TRS.set_string(in_node1, "OPER",MWIPLOTSTS.OPER, sizeof(MWIPLOTSTS.OPER));				//OPER
		
			
			
			if(cur_work_time.work_shift == 1)
			{
				TRS.set_string(in_node1, "TERMINATE_SHIFT", MWIPCALDEF.CAL_CMF_1, 1);				//근무조
			}
			else if(cur_work_time.work_shift == 2)
			{	
				TRS.set_string(in_node1, "TERMINATE_SHIFT", MWIPCALDEF.CAL_CMF_2, 1);				//근무조
			}

			
			TRS.set_string(in_node1, "DEL_CODE", IWIPTERINF.MOVE_TYPE, strlen(IWIPTERINF.MOVE_TYPE));				//터미네이트코드

			//［2025.12.10] C003 -> C015 버그 수정 
			TRS.set_string(in_node1, "TRAN_CMF_1", "C015", strlen("C015"));				//터미네이트 cause
			TRS.set_string(in_node1, "TERMINATE_PROCESS_CODE", "P0027", strlen("P0027"));				//프로세스
			TRS.set_string(in_node1, "TERMINATE_EQ_CODE", "E0058", strlen("E0058"));				//EQ
			


			if(WIP_TERMINATE_LOT(s_msg_code, in_node1, out_node1)== MP_FALSE)
			{

				TRS.clone(out_node, out_node1);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(in_node1);
				TRS.free_node(out_node1);

				//Insert Error인경우 log를 남긴다.
				IWIPTERINF.RETURN_TYPE  = 'E';
				memcpy(IWIPTERINF.RETURN_MSG, s_msg_code, sizeof(s_msg_code));		

				CDB_update_iwipterinf(1,&IWIPTERINF);
				DB_commit();
			

				continue;

			}
		}


		//3.폐기 취소 시작

		if(IWIPTERINF.ZTYP1 =='D')
		{
			
			TRS.set_string(in_node1, "FACTORY", "USGAM1", strlen("USGAM1"));				//공장
			TRS.add_char(in_node1, "LANGUAGE", '1');
			TRS.add_char(in_node1, "PROCSTEP", '1');
			TRS.set_string(in_node1, "LOT_ID", IWIPTERINF.MODULE_ID, sizeof(IWIPTERINF.MODULE_ID));				//모듈
			TRS.set_int(in_node1,"LAST_ACTIVE_HIST_SEQ",MWIPLOTSTS.LAST_ACTIVE_HIST_SEQ);		//LAST_ACTIVE_HIST_SEQ



			if(WIP_DELETE_LOT_HISTORY(s_msg_code, in_node1, out_node1)== MP_FALSE)
			{

				TRS.clone(out_node, out_node1);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(in_node1);
				TRS.free_node(out_node1);

				//Insert Error인경우 log를 남긴다.
				IWIPTERINF.RETURN_TYPE  = 'E';
				memcpy(IWIPTERINF.RETURN_MSG, s_msg_code, sizeof(s_msg_code));		

				CDB_update_iwipterinf(1,&IWIPTERINF);
				DB_commit();
			

				continue;

			}
			CDB_update_mwiplotsts(12, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				memset(s_val_MSG, ' ', sizeof(s_val_MSG));	
				memcpy(s_val_MSG, "Update Error : [Moudle] Un-termination failed.", strlen("Update Error : [Moudle] Un-termination failed."));

				TRS.clone(out_node, out_node1);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				TRS.free_node(in_node1);
				TRS.free_node(out_node1);

				//Insert Error인경우 log를 남긴다.
				IWIPTERINF.RETURN_TYPE  = 'E';
				memcpy(IWIPTERINF.RETURN_MSG, s_val_MSG, sizeof(s_val_MSG));		

				CDB_update_iwipterinf(1,&IWIPTERINF);
				DB_commit();
			

				continue;

			}
		}



	//	/***********************************/
      // BACKUP TABLE : IWIPTERINF -> IBAKTERINF
	//	/***********************************/
   
	    CDB_init_ibakterinf(&IBAKTERINF);
		IWIPTERINF.RETURN_TYPE = 'S';
		memcpy(IBAKTERINF.ZTSMP, IWIPTERINF.ZTSMP, sizeof(struct IBAKTERINF_TAG));

		CDB_insert_ibakterinf(&IBAKTERINF);
		if(DB_error_code != DB_SUCCESS)
		{
			
			//Insert Error인경우 log를 남긴다.
			IWIPTERINF.RETURN_TYPE  = 'E';
			memcpy(IWIPTERINF.RETURN_MSG, "Insert ERROR(IBAKTERINF)", strlen("Insert ERROR(IBAKTERINF)"));			
			CDB_update_iwipterinf(1,&IWIPTERINF);
			DB_commit();

			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			continue;

			//DO NOTHING
		}
		//
		//// DELETE IWIPMATGLO
		CDB_delete_iwipterinf(1,&IWIPTERINF);
		if(DB_error_code != DB_SUCCESS)
		{
			//Insert Error인경우 log를 남긴다.
			IWIPTERINF.RETURN_TYPE  = 'E';
			memcpy(IWIPTERINF.RETURN_MSG, "Delete ERROR(IWIPTERINF)", strlen("Insert ERROR(IWIPTERINF)"));			
			CDB_update_iwipterinf(1,&IWIPTERINF);
			DB_commit();

			TRS.free_node(in_node1);
			TRS.free_node(out_node1);

			continue;

			//DO NOTHING
		}

		TRS.free_node(in_node1);
		TRS.free_node(out_node1);

		DB_commit();
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));

	return MP_TRUE;
}
