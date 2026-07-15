/********************************************************************************

System      : MESplus
Module      : CUS
File Name   : CINF_upload_erp_function.c
Description : ERP Upload Interface Common Function

MES Version : 5.3.x

Function List

Detail Description
// CUSTOM COMMON FUNCTION

History
Seq   Date        Developer      Description                        
---------------------------------------------------------------------------
    1     2018/12/26  Juhyeon.Jung       Creation Data

Copyright(C) 1998-2018 Miracom,Inc.
All rights reserved.

*******************************************************************************/
#include "CUS_common.h"
#include "WIPCore_common.h"

/*******************************************************************************
    CINF_UPLOAD_ERP_FUNCTION_GERP()
        - MES->ERP UPLOAD FUNCTION
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
			NAME : INF_UPLOAD_TYPE_FLAG
					'1' : CLEAVING FCELL MOVE   
					'2' : CLEAVING HCELL CONFIRM / GR  -
					'3' : CLEAVING HCELL MOVE  
					'4' : OPERATION CONFIRM
					'5' : FQC CONFIRM
					'6' : PACKING DATA
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CINF_UPLOAD_ERP_FUNCTION_GERP(char *s_msg_code,TRSNode *in_node, TRSNode *out_node )
{

	char c_inf_type_flag = ' ';
	int i_inscase = 1;
	char c_action_type = ' ';
    int b_cancel = MP_FALSE;
    double d_value = 0;

	int ihisChk = 0;

	struct MWIPLOTHIS_TAG MWIPLOTHIS;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MWIPLOTSTS_TAG MWIPLOTSTS;
	
	struct IERPFCLMOV_TAG IERPFCLMOV;
	struct IERPHCLMOV_TAG IERPHCLMOV;
	struct IERPCLVCFM_TAG IERPCLVCFM;
	struct IERPOPRCFM_TAG IERPOPRCFM;
	struct IQCMFSHDAT_TAG IQCMFSHDAT;
	
	struct IERPPAKDAT_TAG IERPPAKDAT;
	
	struct CWIPORDRTE_TAG CWIPORDRTE;
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPLOTPAK_TAG CWIPLOTPAK_CNT;
	struct MWIPORDSTS_TAG MWIPORDSTS;
	struct MWIPCALDEF_TAG MWIPCALDEF;
	struct IBAKOPRCFM_TAG IBAKOPRCFM;

	struct worktime_tag cur_work_time;	
	char s_sys_time[14];	

	struct CINVCELRCV_TAG CINVCELRCV;
	struct MWIPOPRDEF_TAG MWIPOPRDEF;
    struct CEDCLOTRLT_TAG CEDCLOTRLT;
    struct CEDCLOTFQC_TAG CEDCLOTFQC;
    struct MGCMTBLDAT_TAG MGCMTBLDAT;
	struct IBAKTERINF_TAG IBAKTERINF;
	struct IERPWIPCFM_TAG IERPWIPCFM;

	struct IERPOPRCFM_TAG IERPOPRCFM_LST; //Added 2025.12.19 BC KANG

	// *ERP UPLOAD FLAG
	// *DEFAULT : R - > .실시간 처리
	// *          M - > .문제여지 있음 
	//			  H - > .ERP 의 HM03 TYPE 으로 UPLOAD 하면 안되는 데이터임.
	char c_upload_flag ; 

	//c_upload_flag = 'R'; //기본적으로 실시간으로 올림.
	c_upload_flag = 'R'; //ERP I/F 당분간 매뉴얼로 UPLOAD , 데이터 확인후 'R' 로 올림.
	

    memset(s_msg_code, 0x00, MP_SIZE_MSG);	
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
	//GET Interface Type Flag
	c_inf_type_flag = TRS.get_char(in_node, "INF_UPLOAD_TYPE_FLAG");
	if ((c_inf_type_flag == ' ') ||  (c_inf_type_flag == '\0'))
	{
		return MP_TRUE;
	}

	if (COM_isnullspace(TRS.get_string(in_node,"BACK_TIME")) == MP_FALSE)
	{
		//WORKING DATE
		memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_erp_time(TRS.get_string(in_node,"BACK_TIME"), &cur_work_time);
	}
	else
	{
		//WORKING DATE
		memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
		CCOM_get_work_erp_time(s_sys_time, &cur_work_time);
	}

	

	/* WORK CALENDAR : 해당 SHIFT 의 조를 등록함. */
	DBC_init_mwipcaldef(&MWIPCALDEF);
	memcpy(MWIPCALDEF.CALENDAR_ID, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY)); //해당 칼렌다로 변경필요.
    MWIPCALDEF.CALENDAR_TYPE = 'F';
    MWIPCALDEF.SYS_YEAR = cur_work_time.work_year;
    MWIPCALDEF.SYS_MONTH = cur_work_time.work_month;
    MWIPCALDEF.SYS_DAY = COM_atoi(cur_work_time.work_date+6,2) ;
    DBC_select_mwipcaldef(1, &MWIPCALDEF);
    if (DB_error_code != DB_SUCCESS)
	{
		//DO NOTHGIN
	}
	
	if (COM_isspace(MWIPCALDEF.CAL_CMF_1, sizeof(MWIPCALDEF.CAL_CMF_1)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_1[0] = 'A';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_2, sizeof(MWIPCALDEF.CAL_CMF_2)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_2[0] = 'B';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_3, sizeof(MWIPCALDEF.CAL_CMF_3)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_3[0] = 'C';

	if (COM_isspace(MWIPCALDEF.CAL_CMF_4, sizeof(MWIPCALDEF.CAL_CMF_4)) == MP_TRUE)
			MWIPCALDEF.CAL_CMF_4[0] = 'D';

	//20190713 HCH KIM  : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
	CDB_init_cedclotrlt(&CEDCLOTRLT);
	TRS.copy(CEDCLOTRLT.FACTORY, sizeof(MWIPLOTHIS.FACTORY), in_node, IN_FACTORY);
	memcpy(CEDCLOTRLT.INS_TYPE, "ET", strlen("ET"));
	TRS.copy(CEDCLOTRLT.LOT_ID, sizeof(CEDCLOTRLT.LOT_ID), in_node, "LOT_ID");
	CDB_select_cedclotrlt(1, &CEDCLOTRLT);
	if(DB_error_code != DB_SUCCESS)
	{
		//DO NOTHING            
	}

	/******************************************************/
	// 1 : CLEAVING Full Cell Move Interface (PP112)
	/******************************************************/
	if (c_inf_type_flag == '1')
	{
		b_cancel = TRS.get_boolean(in_node,"CANCEL");
        if(b_cancel)
        {
            c_upload_flag = 'R';

		    CDB_init_mwiplotsts(&MWIPLOTSTS);
		    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
            TRS.copy(MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.LOT_ID), in_node, "FACTORY");
            TRS.copy(MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "ORDER_ID");
            TRS.copy(MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "MAT_ID");
            MWIPLOTSTS.QTY_1 = TRS.get_int (in_node, "QTY_1");
		    CDB_select_mwiplotsts(2, &MWIPLOTSTS);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    //에러나면 안됨..
		    }

		    // ORDER GET
		    DBC_init_mwipordsts(&MWIPORDSTS);
		    memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		    memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		    DBC_select_mwipordsts(1, &MWIPORDSTS);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    //없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			    c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		    }
		    else
		    {
			    if (memcmp( MWIPORDSTS.ORD_CMF_4 , "HM03", 4) == 0)
			    {
				    //ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				    c_upload_flag = 'H';
			    }
		    }
		
				
		    // IERPFCLMOV 컬럼값 넣어주기 
		    CDB_init_ierpfclmov(&IERPFCLMOV);
		    memcpy(IERPFCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPFCLMOV.DOC_ID));
		    IERPFCLMOV.ACTION_TYPE[0] = 'D';
		    memcpy(IERPFCLMOV.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		    memcpy(IERPFCLMOV.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		    memcpy(IERPFCLMOV.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

		    //BATCH NO : CEINVCELRCV BATCHNO 
		    CDB_init_cinvcelrcv(&CINVCELRCV);
		    memcpy(CINVCELRCV.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		    memcpy(CINVCELRCV.INV_LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		    CDB_select_cinvcelrcv(1, &CINVCELRCV);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    //없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			    c_upload_flag = 'M';
		    }

		    memcpy(IERPFCLMOV.BATCH_NO, CINVCELRCV.GR_BATCHNO, sizeof(CINVCELRCV.GR_BATCHNO));
		    if (COM_isspace(IERPFCLMOV.BATCH_NO, sizeof(IERPFCLMOV.BATCH_NO)) == MP_TRUE)
		    {
			    c_upload_flag = 'M';
		    }
		
		    memcpy(IERPFCLMOV.FR_LOC_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		    memcpy(IERPFCLMOV.TO_LOC_ID, HQCEL_FCEL_TO_LOC_ID_V2, strlen(HQCEL_FCEL_TO_LOC_ID_V2));
		    IERPFCLMOV.QTY = MWIPLOTSTS.QTY_1;
		    memcpy(IERPFCLMOV.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CINVCELRCV.UNIT_ID));
		
		
		    memcpy(IERPFCLMOV.POST_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		    TRS.copy(IERPFCLMOV.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

		    memcpy(IERPFCLMOV.INF_TIME,s_sys_time, sizeof(s_sys_time));
		    IERPFCLMOV.DATA_FLAG = 'D';
		    // IERPFCLMOV 컬럼값 넣어주기

			//2025.02.05 풀셀 부하로 우선 M으로 처리
			//c_upload_flag = 'M';
			//2025.02.05 풀셀 부하로 우선 M으로 처리

		    IERPFCLMOV.ZPISTAT = c_upload_flag;

		    memcpy(IERPFCLMOV.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
            IERPFCLMOV.QTY = MWIPLOTSTS.QTY_1;
            //DOC_ID 생성
            CDB_select_ierpfclmov(4, &IERPFCLMOV);
            if(DB_error_code != DB_SUCCESS)
            {
			    if(DB_error_code == DB_NOT_FOUND)
			    {
			       if(DB_error_code != DB_SUCCESS)
			       {
				       //DO NOTHING
			       }
			    }
            }

		    //Interface Check
		    d_value = CDB_select_ierpfclmov_scalar(3, &IERPFCLMOV);
            
            if(DB_error_code != DB_SUCCESS)
            {
			    if(DB_error_code == DB_NOT_FOUND)
			    {
                    strcpy(s_msg_code, "WIP-0598");
                    gs_log_type.type = MP_LOG_ERROR;
			        gs_log_type.e_type = MP_LOG_E_SYSTEM;
			        gs_log_type.category = MP_LOG_CATE_VIEW;			
			        return MP_FALSE;
			    }
            }else
            {
                if(d_value == 1)
                {
                    CDB_insert_ierpfclmov(&IERPFCLMOV); //2025.02.05 풀셀 부하로 우선 M으로 처리

			        if(DB_error_code != DB_SUCCESS)
			        {
				        //DO NOTHING
			        }
                }else
                {
                    strcpy(s_msg_code, "556");
                    gs_log_type.type = MP_LOG_ERROR;
			        gs_log_type.e_type = MP_LOG_E_SYSTEM;
			        gs_log_type.category = MP_LOG_CATE_VIEW;			
			        return MP_FALSE;
                }
            }

        }else
        {
            c_upload_flag = 'R';

		    CDB_init_mwiplotsts(&MWIPLOTSTS);
		    TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		    CDB_select_mwiplotsts(2, &MWIPLOTSTS);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    //에러나면 안됨..
		    }

		    // ORDER GET
		    DBC_init_mwipordsts(&MWIPORDSTS);
		    memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		    memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		    DBC_select_mwipordsts(1, &MWIPORDSTS);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    //없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			    c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		    }
		    else
		    {
			    if (memcmp( MWIPORDSTS.ORD_CMF_4 , "HM03", 4) == 0)
			    {
				    //ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				    c_upload_flag = 'H';
			    }
		    }
		
				
		    // IERPFCLMOV 컬럼값 넣어주기 
		    CDB_init_ierpfclmov(&IERPFCLMOV);
		    memcpy(IERPFCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPFCLMOV.DOC_ID));
		    IERPFCLMOV.ACTION_TYPE[0] = 'I';
		    memcpy(IERPFCLMOV.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		    memcpy(IERPFCLMOV.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		    memcpy(IERPFCLMOV.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

		    //BATCH NO : CEINVCELRCV BATCHNO 
		    CDB_init_cinvcelrcv(&CINVCELRCV);
		    memcpy(CINVCELRCV.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));
		    memcpy(CINVCELRCV.INV_LOT_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
		    CDB_select_cinvcelrcv(1, &CINVCELRCV);
		    if(DB_error_code != DB_SUCCESS)
		    {
			    //없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			    c_upload_flag = 'M';
		    }

		    memcpy(IERPFCLMOV.BATCH_NO, CINVCELRCV.GR_BATCHNO, sizeof(CINVCELRCV.GR_BATCHNO));
		    if (COM_isspace(IERPFCLMOV.BATCH_NO, sizeof(IERPFCLMOV.BATCH_NO)) == MP_TRUE)
		    {
			    c_upload_flag = 'M';
		    }
		
		    memcpy(IERPFCLMOV.FR_LOC_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		    memcpy(IERPFCLMOV.TO_LOC_ID, HQCEL_FCEL_TO_LOC_ID_V2, strlen(HQCEL_FCEL_TO_LOC_ID_V2));
		    IERPFCLMOV.QTY = MWIPLOTSTS.QTY_1;
		    memcpy(IERPFCLMOV.UNIT_ID, CINVCELRCV.UNIT_ID, sizeof(CINVCELRCV.UNIT_ID));
		
		
		    memcpy(IERPFCLMOV.POST_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		    TRS.copy(IERPFCLMOV.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

		    memcpy(IERPFCLMOV.INF_TIME,s_sys_time, sizeof(s_sys_time));
		    IERPFCLMOV.DATA_FLAG = 'I';
		    // IERPFCLMOV 컬럼값 넣어주기

			//2025.02.05 풀셀 부하로 우선 M으로 처리
			//c_upload_flag = 'M';

			//2025.02.05 풀셀 부하로 우선 M으로 처리

		    IERPFCLMOV.ZPISTAT = c_upload_flag;

		    memcpy(IERPFCLMOV.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));


		    //Cell Box Duplicate Check
		    CDB_select_ierpfclmov(3, &IERPFCLMOV);
		    /*
		    WHERE ACTION_TYPE = :IERPFCLMOV_N.ACTION_TYPE
            AND SITE_ID = :IERPFCLMOV_N.SITE_ID
            AND PROD_ORDER_NO = :IERPFCLMOV_N.PROD_ORDER_NO
            AND MATE_NO = :IERPFCLMOV_N.MATE_NO
            AND BATCH_NO = :IERPFCLMOV_N.BATCH_NO
            AND FR_LOC_ID = :IERPFCLMOV_N.FR_LOC_ID
            AND TO_LOC_ID = :IERPFCLMOV_N.TO_LOC_ID
		    AND CMF_1 = :IERPFCLMOV_N.CMF_1;
		    */
		    if(DB_error_code != DB_SUCCESS)
            {
			    if(DB_error_code == DB_NOT_FOUND)
			    {
				    CDB_insert_ierpfclmov(&IERPFCLMOV); //2025.02.05 풀셀 부하로 우선 M으로 처리

			       if(DB_error_code != DB_SUCCESS)
			       {
				       //DO NOTHING
			       }
			    }
            }
        }		            
	}
	/******************************************************/
	// 2 : Cleaving 실적 (1: Confirmation, 2: Goods Receipts) 한쌍 올려준다. [PP-111]
	/******************************************************/
	if (c_inf_type_flag == '2')
	{
		//Zero values are not processed.
		if( 0 == TRS.get_int(in_node, "MAGAZINE_O_QTY"))
			return MP_TRUE;

		c_upload_flag = 'R'; 

		CDB_init_mwiplotsts(&MWIPLOTSTS);
		TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
		CDB_select_mwiplotsts(2, &MWIPLOTSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		// ORDER GET
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));

		if (COM_isnullspace(TRS.get_string(in_node, "MAIN_ORDER_ID")) == MP_FALSE)
			TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "MAIN_ORDER_ID");
		else
			memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		
		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		}
		else
		{
			if (memcmp( MWIPORDSTS.ORD_CMF_4 , "HM03", 4) == 0)
			{
				//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				c_upload_flag = 'H';
			}
		}

		CDB_init_ierpclvcfm(&IERPCLVCFM);
		memcpy(IERPCLVCFM.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPCLVCFM.DOC_ID));		
		memcpy(IERPCLVCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		memcpy(IERPCLVCFM.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
		memcpy(IERPCLVCFM.OPER_NO, "0010", strlen("0010")); //UPDATE 필요
		memcpy(IERPCLVCFM.WORK_CENTER, "H100", strlen("H100")); //UPDATE 필요
		IERPCLVCFM.ACTION_TYPE[0] = '1';
		memcpy(IERPCLVCFM.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));
		//IERPCLVCFM.PROD_QTY = MWIPLOTSTS.QTY_1;
		IERPCLVCFM.PROD_QTY = TRS.get_int(in_node, "MAGAZINE_O_QTY");//
		IERPCLVCFM.SCRAP_QTY = 0;
		memcpy(IERPCLVCFM.UNIT_ID, "PCS", strlen("PCS"));
		memcpy(IERPCLVCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		//memcpy(IERPCLVCFM.FQC_DATE, "20181231", 8);

		if (cur_work_time.work_shift == 1)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPCLVCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		TRS.copy(IERPCLVCFM.INF_USER_ID, sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);
		memcpy(IERPCLVCFM.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));

		memcpy(IERPCLVCFM.INF_TIME,s_sys_time, sizeof(s_sys_time));
		IERPCLVCFM.DATA_FLAG = 'I';
		// IERPFCLMOV 컬럼값 넣어주기

		IERPCLVCFM.ZPISTAT =c_upload_flag;

		CDB_insert_ierpclvcfm(&IERPCLVCFM);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
        }

		//GR DATE INSERT 
		while(1)
		{
			//doc id 중복방지
			CDB_select_mwiplotsts(2, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}
			if (memcmp(IERPOPRCFM.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID)) != 0)
			{
				break;
			}
		}

		memset(IERPCLVCFM.DOC_ID, ' ', sizeof(IERPCLVCFM.DOC_ID));
		memcpy(IERPCLVCFM.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPCLVCFM.DOC_ID));		
		IERPCLVCFM.ACTION_TYPE[0] = '2';
		CDB_insert_ierpclvcfm(&IERPCLVCFM);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
        }
	}


	/******************************************************/
	// 3 : Half-Cell 이동정보를 ERP로 올려준다. [PP-113]
	/******************************************************/
	if (c_inf_type_flag == '3')
	{
		if(TRS.get_procstep(in_node) == '1') //INSERT
		{
			c_upload_flag = 'R';

			CDB_init_mwiplotsts(&MWIPLOTSTS);
			TRS.copy(MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID), in_node, "LOT_ID");
			CDB_select_mwiplotsts(2, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}
			// ORDER GET
			DBC_init_mwipordsts(&MWIPORDSTS);
			memcpy(MWIPORDSTS.FACTORY, MWIPLOTSTS.FACTORY, sizeof(MWIPLOTSTS.FACTORY));

			if (COM_isnullspace(TRS.get_string(in_node, "MAIN_ORDER_ID")) == MP_FALSE)
				TRS.copy(MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID), in_node, "MAIN_ORDER_ID");
			else
				memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));

			DBC_select_mwipordsts(1, &MWIPORDSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
				c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
			}
			else
			{
				if (memcmp( MWIPORDSTS.ORD_CMF_4 , "HM03", 4) == 0)
				{
					//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
					c_upload_flag = 'H';
				}
			}

			if(TRS.get_char(in_node, "CLEAVING_END_FLAG") == 'Y') c_upload_flag = ' ';			

			CDB_init_ierphclmov(&IERPHCLMOV);
			//memcpy(IERPHCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(MWIPLOTSTS.LOT_DESC));  // Server Crash 190925
			memcpy(IERPHCLMOV.DOC_ID, MWIPLOTSTS.LOT_DESC, sizeof(IERPHCLMOV.DOC_ID));
			IERPHCLMOV.ACTION_TYPE[0] = 'I';
			memcpy(IERPHCLMOV.SITE_ID,HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
			memcpy(IERPHCLMOV.PROD_ORDER_NO,  MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID)); //MAIN 의 ORDER..
			memcpy(IERPHCLMOV.MATE_NO, MWIPLOTSTS.MAT_ID, sizeof(MWIPLOTSTS.MAT_ID));

			memcpy(IERPHCLMOV.FR_LOC_ID, HQCEL_HCEL_FROM_LOC_ID_V2, strlen(HQCEL_HCEL_FROM_LOC_ID_V2));
			memcpy(IERPHCLMOV.TO_LOC_ID, HQCEL_HCEL_TO_LOC_ID_V2, strlen(HQCEL_HCEL_TO_LOC_ID_V2));
			IERPHCLMOV.QTY = MWIPLOTSTS.QTY_1;
			memcpy(IERPHCLMOV.UNIT_ID, "PCS", strlen("PCS"));

			memcpy(IERPHCLMOV.POST_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

			TRS.copy(IERPHCLMOV.INF_USER_ID,  sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

			memcpy(IERPHCLMOV.INF_TIME, s_sys_time, sizeof(s_sys_time));
			memcpy(IERPHCLMOV.CMF_1, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			TRS.copy(IERPHCLMOV.INF_PROC_TIME,  sizeof(IERPFCLMOV.INF_PROC_TIME), in_node, "MAGAZINE_ID");//Tabber Start시 Update Key로 사용

			IERPHCLMOV.DATA_FLAG = 'I';
			IERPHCLMOV.ZPISTAT = c_upload_flag;
			CDB_insert_ierphclmov(&IERPHCLMOV);
			if(DB_error_code != DB_SUCCESS)
			{
				if(DB_error_code == DB_NOT_FOUND)
				{
					strcpy(s_msg_code, "BAS-0026");
					gs_log_type.e_type = MP_LOG_E_EXISTENCE;
				}
				else
				{
					strcpy(s_msg_code, "BAS-0004");
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					TRS.add_dberrmsg(out_node, DB_error_msg);
				}
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;			
				return MP_FALSE;
			}
		}
		else if(TRS.get_procstep(in_node) == '2')//UPDATE
		{
			CDB_init_ierphclmov(&IERPHCLMOV);
			TRS.copy(IERPHCLMOV.INF_PROC_TIME, sizeof(IERPHCLMOV.INF_PROC_TIME), in_node, "MAGAZINE_ID");
			TRS.copy(IERPHCLMOV.CMF_1, sizeof(IERPHCLMOV.CMF_1), in_node, "LOT_ID");

			TRS.copy(IERPHCLMOV.PROD_ORDER_NO, sizeof(IERPHCLMOV.PROD_ORDER_NO), in_node, "MAIN_ORDER_ID");
			memcpy(IERPHCLMOV.INF_TIME,s_sys_time, sizeof(s_sys_time));
			IERPHCLMOV.ZPISTAT = 'R';

			CDB_update_ierphclmov(3, &IERPHCLMOV);
			if(DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
				LOG_head("TABBER_MOVE_IF_UPDATE");
				LOG_add("LOT_ID", MP_NSTR, TRS.get_string(in_node, "LOT_ID")); 
				LOG_add("MAGAZINE_ID", MP_NSTR, TRS.get_string(in_node, "MAGAZINE_ID")); 
				COM_log_write(MP_LOG_INFORMATION, MP_LOG_E_LOGIC, MP_LOG_CATE_TRANS);
			}
			
		}

		
	}


	/******************************************************/
	// 4 : OPERATION CONFIRM DATA [IF-PP-305]
	//     Module Serial Number Flash data Receive [IF-QM-002]IQCMFSHDAT 전송
	/******************************************************/
	if (c_inf_type_flag == '4')
	{
		c_upload_flag = 'R';
		//마지막 수행이력 GET 
		CDB_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
		CDB_select_mwiplothis(2, &MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		if (memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) != 0)
		{
			return MP_TRUE;
		}

		
		//이전에 같은공정에서 END한 이력이 있으면 이미  실적처리를 했으므로 다시안함.
		//위에서 MWIPLOTHIS 를 SELECT 해왔기떄문에 그냥쓴것임. 다른곳에서 쓸려면 TRAN_CODE, OLD_OPER, HIST SEQ 주의
		if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) > 0)
		{
			return MP_TRUE;
		}
		

		// ORDER GET
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		}
		else
		{
			if (memcmp( MWIPORDSTS.ORD_CMF_4 , "HM03", 4) == 0)
			{
				//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				c_upload_flag = 'H';
			}
		}

		//OPOERATION SELECT
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		memcpy(MWIPOPRDEF.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(MWIPOPRDEF.OPER, MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
		DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		if(DB_error_code != DB_SUCCESS)
        {
			//에러날수 없음.
		}

		//ERP UPLOAD 공정이 아니면 RETURN TURE
		if (MWIPOPRDEF.ERP_FLAG != 'Y')
		{
			return MP_TRUE;
		}

		// 올려야 하는값이 있는지 체크 (ERP OPETION 이 없으면 TRUE)
		if (COM_isspace(MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1)) == MP_TRUE)
		{
			return MP_TRUE;
		}

        /* Skip FQC Prod Result */
		if (memcmp(MWIPOPRDEF.OPER_CMF_1, "0040", 4) == 0)
		{
			return MP_TRUE;
		}

		//ERP WORK CENTER GET
		CDB_init_cwipordrte(&CWIPORDRTE);
		memcpy(CWIPORDRTE.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(CWIPORDRTE.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		//memcpy(CWIPORDRTE.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(CWIPORDRTE.OPER_NO)); // Server Crash 190925
		memcpy(CWIPORDRTE.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1)); 
		CDB_select_cwipordrte(2, &CWIPORDRTE);
		if(DB_error_code != DB_SUCCESS)
        {
			//에러처리 우선안함.
		}

		
		// IERPOPRCFM 컬럼값 넣어주기 
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		//while(1)
		//{
		//	//DOC ID 중복방지 : CASE 999 IERPOPRCFM.DOC_ID ->MAX_DOC_ID, IERPOPRCFM.CMF_1 ->CURRENT TIME STAMP
		//	CDB_select_ierpoprcfm(999,&IERPOPRCFM);
		//	if (memcmp(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, 21) != 0)
		//		break;

		//	memcpy(MWIPLOTHIS.LOT_DESC, IERPOPRCFM.CMF_1, sizeof(IERPOPRCFM.CMF_1));
		//}

		memcpy(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID));

		

		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		memcpy(IERPOPRCFM.PROD_ORDER_NO,MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));

		memcpy(IERPOPRCFM.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));

		memcpy(IERPOPRCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(CWIPORDRTE.WORK_CENTER));
		IERPOPRCFM.ACTION_TYPE[0] = 'I';

		memcpy(IERPOPRCFM.MATE_NO, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));
		COM_dtoa(IERPOPRCFM.PROD_QTY,MWIPLOTHIS.QTY_1, sizeof(IERPOPRCFM.PROD_QTY));

		IERPOPRCFM.SCRAP_QTY[0] = '0';
		memcpy(IERPOPRCFM.UNIT_ID, "PCS", strlen("PCS"));
		TRS.copy(IERPOPRCFM.INF_USER_ID,sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

		//FQC DATE, SHIFT , LOCATION ( ERP TEST 를 위해  임시로 넣음 )
		CDB_init_mwipeltsts(&MWIPELTSTS);
		memcpy(MWIPELTSTS.LOT_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));	
		CDB_select_mwipeltsts(i_inscase, &MWIPELTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
        }

        /* FQC date is Work date */
		//memcpy(IERPOPRCFM.FQC_DATE, MWIPELTSTS.FQC_TIME, 8);
		memcpy(IERPOPRCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

        memset(IERPOPRCFM.SHIFT,  ' ', sizeof(IERPOPRCFM.SHIFT));
		if (cur_work_time.work_shift == 1)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		//memcpy(IERPOPRCFM.LOCATION, MWIPELTSTS.LOC_ID, 3);
		memcpy(IERPOPRCFM.LOCATION, MWIPORDSTS.ORD_CMF_6, 3);

		memcpy(IERPOPRCFM.INF_TIME,  s_sys_time, sizeof(s_sys_time));
		IERPOPRCFM.DATA_FLAG = 'I';

		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
		}

		IERPOPRCFM.ZPISTAT =c_upload_flag;

		//20190713 HCH KIM : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
		memcpy(IERPOPRCFM.CMF_1, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));

        //20190905 ISSUE-09-003 IERPOPRCFM.CMF_2에 대표 불량 코드 추가 버그 수정.
        CDB_init_cedclotfqc(&CEDCLOTFQC);
        memcpy(CEDCLOTFQC.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotfqc(2, &CEDCLOTFQC);

		if(DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

      

        memcpy(IERPOPRCFM.CMF_2, CEDCLOTFQC.DEFECT_CODE, sizeof(IERPOPRCFM.CMF_2));

		CDB_insert_ierpoprcfm(&IERPOPRCFM);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
        }

		//IBAKOPRCFM DATA INSERT
		memcpy(IBAKOPRCFM.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IBAKOPRCFM_TAG));
		CDB_insert_ibakoprcfm(&IBAKOPRCFM);
		if(DB_error_code != DB_SUCCESS)
        {

		}
		
		//IQCMFSHDAT DATA INSERT
		memcpy(IQCMFSHDAT.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IQCMFSHDAT_TAG));
		CDB_insert_iqcmfshdat(&IQCMFSHDAT);
		if(DB_error_code != DB_SUCCESS)
        {

		}
	}


	/******************************************************/
	// 5 : FQC CONFIRM AND GR DATA [IF-PP-305]
	//     Module Serial Number Flash data Receive [IF-QM-002]IQCMFSHDAT 전송
	/******************************************************/

	if (c_inf_type_flag == '5')
	{
		c_upload_flag = 'R';

		//마지막 수행이력 GET (FQC ONLY)
		CDB_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
		memcpy(MWIPLOTHIS.OLD_OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER));
		memcpy(MWIPLOTHIS.TRAN_CODE, "END", strlen(HQCEL_M1_FQC_OPER));

		CDB_select_mwiplothis(3, &MWIPLOTHIS);
		if(DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		if (memcmp(MWIPLOTHIS.TRAN_CODE, "END", strlen("END")) != 0)
		{
			return MP_TRUE;
		}

		//이전에 같은공정에서 END한 이력이 있으면 이미 실적처리를 처음은 I/두번쨰는U 로 올림.
        /*
		c_action_type = 'I';
        
        if (CDB_select_mwiplothis_scalar(2, &MWIPLOTHIS) > 0)
		{
			c_action_type = 'U';
		}
        */


		// ORDER GET
		DBC_init_mwipordsts(&MWIPORDSTS);
		memcpy(MWIPORDSTS.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(MWIPORDSTS.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		DBC_select_mwipordsts(1, &MWIPORDSTS);
		if(DB_error_code != DB_SUCCESS)
		{
			//없으면 에러처리 필요함. (ERP 의 CELL 입고정보)
			c_upload_flag = 'M'; //MES 에서 ERROR 정보로 보임 ->관리
		}
		else
		{
			if (memcmp( MWIPORDSTS.ORD_CMF_4 , "HM03", 4) == 0)
			{
				//ERP 에서 TEST .오더이면 INTERFACE 하지 않음
				//R 로 다시변경 요청 : 2/7
				c_upload_flag = 'R';
			}
		}

		//OPOERATION SELECT
		DBC_init_mwipoprdef(&MWIPOPRDEF);
		memcpy(MWIPOPRDEF.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//memcpy(MWIPOPRDEF.OPER, MWIPLOTHIS.OLD_OPER, sizeof(MWIPLOTHIS.OLD_OPER));
		memcpy(MWIPOPRDEF.OPER, HQCEL_M1_FQC_OPER, strlen(HQCEL_M1_FQC_OPER));  //LOT 공정과 상관없이 FQC 는 무조건 수행함.
		DBC_select_mwipoprdef(1, &MWIPOPRDEF);
		if(DB_error_code != DB_SUCCESS)
        {
			//에러날수 없음.
		}

		//ERP UPLOAD 공정이 아니면 RETURN TURE
		if (MWIPOPRDEF.ERP_FLAG != 'Y')
		{
			return MP_TRUE;
		}

		// 올려야 하는값이 있는지 체크 (ERP OPETION 이 없으면 TRUE)
		if (COM_isspace(MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1)) == MP_TRUE)
		{
			return MP_TRUE;
		}

		//ERP WORK CENTER GET
		CDB_init_cwipordrte(&CWIPORDRTE);
		memcpy(CWIPORDRTE.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		memcpy(CWIPORDRTE.ORDER_ID, MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(CWIPORDRTE.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));
		CDB_select_cwipordrte(2, &CWIPORDRTE);
		if(DB_error_code != DB_SUCCESS)
        {
			//에러처리 우선안함.
		}

        /* Action Type */
        c_action_type = 'I';
        
        CDB_init_ierpoprcfm(&IERPOPRCFM);
        memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
        memcpy(IERPOPRCFM.PROD_ORDER_NO, MWIPORDSTS.ORDER_ID, sizeof(MWIPORDSTS.ORDER_ID));
        TRS.copy(IERPOPRCFM.MODULE_ID, sizeof(IERPOPRCFM.MODULE_ID), in_node, "LOT_ID");
        memcpy(IERPOPRCFM.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));
        memcpy(IERPOPRCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(MWIPOPRDEF.OPER_CMF_1));
		//IERPOPRCFM.ERP_FLAG = 'S';
        if (CDB_select_ierpoprcfm_scalar(3, &IERPOPRCFM) > 0)
		{
			c_action_type = 'U';
		}
        

		// FQC Simulator 및 HI-POT 공정 결과값 SELECT (MWIPELTSTS 에 저장됨)
		CDB_init_mwipeltsts(&MWIPELTSTS);
		memcpy(MWIPELTSTS.LOT_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));	
		CDB_select_mwipeltsts(i_inscase, &MWIPELTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
        }

        /* skip "REWOR" grade */
		// RWK 판정받은 경우 GRADE="R01" 로 I/F 될 수 있도록 수정
		if (memcmp(MWIPELTSTS.GRADE, "REWOR", strlen("REWOR")) == 0)
        {
            //return TRUE;
			memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
        }
		if (memcmp(MWIPELTSTS.GRADE, "RWK", strlen("RWK")) == 0)
        {
            //return TRUE;
			memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
        }

		
		// IERPOPRCFM 컬럼값 넣어주기 
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID));
		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		memcpy(IERPOPRCFM.PROD_ORDER_NO,MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));

		memcpy(IERPOPRCFM.OPER_NO, MWIPOPRDEF.OPER_CMF_1, sizeof(MWIPOPRDEF.OPER_CMF_1));

		memcpy(IERPOPRCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(CWIPORDRTE.WORK_CENTER));
		IERPOPRCFM.ACTION_TYPE[0] = c_action_type;

		memcpy(IERPOPRCFM.MATE_NO, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));
		COM_dtoa(IERPOPRCFM.PROD_QTY,MWIPLOTHIS.QTY_1, sizeof(IERPOPRCFM.PROD_QTY));

		IERPOPRCFM.SCRAP_QTY[0] = '0';
		memcpy(IERPOPRCFM.UNIT_ID, "PCS", strlen("PCS"));
		TRS.copy(IERPOPRCFM.INF_USER_ID,sizeof(IERPFCLMOV.INF_USER_ID), in_node, IN_USERID);

        /* FQC date is Work date */
		memcpy(IERPOPRCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		/* 검사결과값 */
		memcpy(IERPOPRCFM.QUALITY_GRADE, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));
		memcpy(IERPOPRCFM.POWER_GRADE, MWIPELTSTS.POWER, sizeof(MWIPELTSTS.POWER));
		//memcpy(IERPOPRCFM.SHIFT, MWIPELTSTS.LINE_ID, sizeof(MWIPELTSTS.LINE_ID));

		memcpy(IERPOPRCFM.EFF, MWIPELTSTS.EFF, sizeof(MWIPELTSTS.EFF));
		memcpy(IERPOPRCFM.RSH, MWIPELTSTS.RSH, sizeof(MWIPELTSTS.RSH));
		memcpy(IERPOPRCFM.RS, MWIPELTSTS.RS, sizeof(MWIPELTSTS.RS));
		memcpy(IERPOPRCFM.FF, MWIPELTSTS.FF, sizeof(MWIPELTSTS.FF));
		memcpy(IERPOPRCFM.ISC, MWIPELTSTS.ISC, sizeof(MWIPELTSTS.ISC));
		memcpy(IERPOPRCFM.VOC, MWIPELTSTS.VOC, sizeof(MWIPELTSTS.VOC));
		memcpy(IERPOPRCFM.IMPP, MWIPELTSTS.IMPP, sizeof(MWIPELTSTS.IMPP));
		memcpy(IERPOPRCFM.VMPP, MWIPELTSTS.VMPP, sizeof(MWIPELTSTS.VMPP));
		memcpy(IERPOPRCFM.PMPP, MWIPELTSTS.PMPP, sizeof(MWIPELTSTS.PMPP));
		memcpy(IERPOPRCFM.TEMP, MWIPELTSTS.TEMP, sizeof(MWIPELTSTS.TEMP));
		memcpy(IERPOPRCFM.SURFTEMP, MWIPELTSTS.SURFTEMP, sizeof(MWIPELTSTS.SURFTEMP));
		memcpy(IERPOPRCFM.SUN, MWIPELTSTS.SUN, sizeof(MWIPELTSTS.SUN));
		memcpy(IERPOPRCFM.OSC, MWIPELTSTS.OSC, sizeof(MWIPELTSTS.OSC));
		memcpy(IERPOPRCFM.ESC, MWIPELTSTS.ESC, sizeof(MWIPELTSTS.ESC));
		memcpy(IERPOPRCFM.EL,  MWIPELTSTS.EL, sizeof(MWIPELTSTS.EL));
		
		//SIM 설비( 앞의3자리 US- 를 제외하고 뒤의자리만)
		memcpy(IERPOPRCFM.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE+3, 10);
		//memcpy(IERPOPRCFM.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE, sizeof(MWIPELTSTS.FLASHER_CODE));

        //memcpy(IERPOPRCFM.ARTICLE_CODE, MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO));
		memcpy(IERPOPRCFM.COLOR_CLASS, MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS));

		//memcpy(IERPOPRCFM.FQC_DATE, MWIPELTSTS.FQC_TIME, 8);
        memset(IERPOPRCFM.SHIFT,  ' ', sizeof(IERPOPRCFM.SHIFT));
		if (cur_work_time.work_shift == 1)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		//memcpy(IERPOPRCFM.LOCATION, MWIPELTSTS.LOC_ID, 3);
        memcpy(IERPOPRCFM.LOCATION, MWIPORDSTS.ORD_CMF_6, 3);

		memcpy(IERPOPRCFM.INF_TIME,  s_sys_time, sizeof(s_sys_time));
		IERPOPRCFM.DATA_FLAG = 'I';

		// RWK 판정받은 경우 I/F 될 수 있도록 수정
		if (memcmp(MWIPELTSTS.GRADE, "R01", strlen("R01")) != 0)
        {
			if (COM_isspace(IERPOPRCFM.QUALITY_GRADE, sizeof(IERPOPRCFM.QUALITY_GRADE)) == MP_TRUE)
			{
				c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
			if (COM_isspace(IERPOPRCFM.POWER_GRADE, sizeof(IERPOPRCFM.POWER_GRADE)) == MP_TRUE)
			{
				c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
			if (COM_isspace(IERPOPRCFM.ARTICLE_CODE, sizeof(IERPOPRCFM.ARTICLE_CODE)) == MP_TRUE)
			{
				//c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
			if (COM_isspace(IERPOPRCFM.COLOR_CLASS, sizeof(IERPOPRCFM.COLOR_CLASS)) == MP_TRUE)
			{
				c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
			if (COM_isspace(IERPOPRCFM.PMPP, sizeof(IERPOPRCFM.PMPP)) == MP_TRUE)
			{
				c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
			}
		}

		if (strlen(TRS.get_string(in_node, "LOT_ID")) != 18)
		{
			c_upload_flag = 'M'; //ERROR 정보로 보임 ->관리
		}

		memcpy(IERPOPRCFM.FLASHER_CODE, MWIPELTSTS.FLASHER_CODE+3, 10);
		
		memcpy(IERPOPRCFM.FQC_OPERATOR, IERPOPRCFM.FLASHER_CODE, sizeof(IERPOPRCFM.FQC_OPERATOR));

		IERPOPRCFM.ZPISTAT =c_upload_flag;

		
		///20190713 HCH KIM  : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
		memcpy(IERPOPRCFM.CMF_1, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));

        //20190905 ISSUE-09-003 IERPOPRCFM.CMF_2에 대표 불량 코드 추가 버그 수정.
        CDB_init_cedclotfqc(&CEDCLOTFQC);
        memcpy(CEDCLOTFQC.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotfqc(2, &CEDCLOTFQC);

		if(DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

        memcpy(IERPOPRCFM.CMF_2, CEDCLOTFQC.DEFECT_CODE, sizeof(IERPOPRCFM.CMF_2));

		CDB_insert_ierpoprcfm(&IERPOPRCFM);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
        }
		
		//IBAKOPRCFM DATA INSERT

		memcpy(IBAKOPRCFM.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IBAKOPRCFM_TAG));
		CDB_insert_ibakoprcfm(&IBAKOPRCFM);
		if(DB_error_code != DB_SUCCESS)
        {

		}

		//IQCMFSHDAT DATA INSERT
		memcpy(IQCMFSHDAT.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IQCMFSHDAT_TAG));
		CDB_insert_iqcmfshdat(&IQCMFSHDAT);
		if(DB_error_code != DB_SUCCESS)
        {

		}

	}


	//******************************************************/
	// 6 : Module Packing Interface (IF-LE-005)
	//     ZMDL Interface(IERPWIPCFM)
	/******************************************************/
	if (c_inf_type_flag == '6')
	{		
		c_upload_flag = 'R';

		//BATCH NO : CEINVCELRCV BATCHNO 
		CDB_init_cwiplotpak(&CWIPLOTPAK_CNT);
		memcpy(CWIPLOTPAK_CNT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPLOTPAK_CNT.PALLET_ID, sizeof(CWIPLOTPAK_CNT.PALLET_ID), in_node, "PALLET_ID");
		CDB_select_cwiplotpak(2,&CWIPLOTPAK_CNT);
		if(DB_error_code != DB_SUCCESS)
        {
			//SELECT CASE 2:
			//PACK_TYPE : TIMESTAMP
			//HIST_SEQW : PACK_COUNT
			strcpy(s_msg_code, "BAS-0004");
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            TRS.add_dberrmsg(out_node, DB_error_msg);
			
		}

		CDB_init_cwiplotpak(&CWIPLOTPAK);
		memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");
		
		CDB_open_cwiplotpak(2, &CWIPLOTPAK);

		if(DB_error_code != DB_SUCCESS)
		{
			if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
		}


		// FETCH
		while(1)
		{
			CDB_fetch_cwiplotpak(2, &CWIPLOTPAK);
			if(DB_error_code == DB_NOT_FOUND)
			{
				CDB_close_cwiplotpak(2);
				break;
			}
			else if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "WIP-0004");
				TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(MWIPLOTSTS.LOT_DESC), MWIPLOTSTS.LOT_DESC);			
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
				CDB_close_cwiplotpak(2);
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
				return MP_FALSE;			
			}

			// LOT_STS 정보 읽어오기 
			CDB_init_mwiplotsts(&MWIPLOTSTS);
			memcpy(MWIPLOTSTS.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));//DOC_ID	
			CDB_select_mwiplotsts(1, &MWIPLOTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				//에러나면 안됨..
			}

			// FQC I/F 값이 있는지 CHECK!
			CDB_init_ierpoprcfm(&IERPOPRCFM);
			memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
			memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTSTS.LOT_ID, sizeof(MWIPLOTSTS.LOT_ID));
			memcpy(IERPOPRCFM.OPER_NO, "0040", 4);
			if (CDB_select_ierpoprcfm_scalar(4, &IERPOPRCFM) <= 0)
			{
				//FQC 값이 없으면 FQC I/F 데이터 자동생성
				TRS.set_string(in_node, "LOT_ID", MWIPLOTSTS.LOT_ID, sizeof( MWIPLOTSTS.LOT_ID));
				TRS.set_char(in_node, "INF_UPLOAD_TYPE_FLAG", '5'); 
				if (CINF_UPLOAD_ERP_FUNCTION_GERP(s_msg_code,in_node, out_node ) == MP_FALSE)
				{
					//ERROR 
					/*DB_rollback();
					continue;*/
				}
			}

			// IERPPAKDAT 컬럼값 넣어주기 
			CDB_init_ierppakdat(&IERPPAKDAT);
			memcpy(IERPPAKDAT.DOC_ID, CWIPLOTPAK_CNT.PAK_TYPE, sizeof(CWIPLOTPAK_CNT.PAK_TYPE));			//DOC_ID	
			memcpy(IERPPAKDAT.PALLET_ID, CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));				//PALLET_ID
			memcpy(IERPPAKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));						//MODULE_ID
			IERPPAKDAT.ACTION_TYPE = 'I';																	//ACTION_TYPE

			COM_itoa(IERPPAKDAT.MODULE_SEQ, CWIPLOTPAK.PAK_SEQ, sizeof(IERPPAKDAT.MODULE_SEQ));				//MODULE_SEQ
			memcpy(IERPPAKDAT.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));					//SITE_ID
			IERPPAKDAT.QTY = CWIPLOTPAK_CNT.HIST_SEQ;														//QTY
			memcpy(IERPPAKDAT.PACKING_DATE, CWIPLOTPAK.PAK_TIME, 8);										//PACKING DATE
			memcpy(IERPPAKDAT.PACKING_TIME, CWIPLOTPAK.PAK_TIME+8, 6);										//PACKING TIME
//			memcpy(IERPPAKDAT.PACKING_ID, CWIPLOTPAK.RES_ID, sizeof(CWIPLOTPAK.RES_ID));					//PACKING_ID ( USER ID OR RES ID)
			TRS.copy(IERPPAKDAT.PACKING_ID, sizeof(IERPPAKDAT.PACKING_ID), in_node, IN_USERID);				//PACKING_ID ( USER ID OR RES ID)
			
			memcpy(IERPPAKDAT.CMF_5, CWIPLOTPAK.CMF_5, sizeof(CWIPLOTPAK.CMF_5));						//Pack H/V (수평/수직포장)

			memcpy(IERPPAKDAT.PVM_PN, CWIPLOTPAK.PVM_PN, sizeof(CWIPLOTPAK.PVM_PN));
			memcpy(IERPPAKDAT.PVM_SN, CWIPLOTPAK.PVM_SN, sizeof(CWIPLOTPAK.PVM_SN));
			memcpy(IERPPAKDAT.PCU_SN, CWIPLOTPAK.PCU_SN, sizeof(CWIPLOTPAK.PCU_SN));
			memcpy(IERPPAKDAT.ACM_SN, CWIPLOTPAK.ACM_SN, sizeof(CWIPLOTPAK.ACM_SN));

			memcpy(IERPPAKDAT.INF_PROC_TIME,s_sys_time, sizeof(s_sys_time));								//INTERFACE_TIME
			TRS.copy(IERPPAKDAT.INTERFACE_USERID, sizeof(IERPPAKDAT.INTERFACE_USERID), in_node, IN_USERID);	//INTERFACE_USERID
		
			IERPPAKDAT.DATA_FLAG = 'I';																		//DATA_FLAG
			IERPPAKDAT.ZPISTAT = c_upload_flag;																//ZPISTAT
		
			memset(&cur_work_time, 0x00, sizeof(struct worktime_tag));
			CCOM_get_work_time(s_sys_time, &cur_work_time);
			memcpy(IERPPAKDAT.INTERFACE_DATE, s_sys_time, 8);												//INTERFACE_DATE
			memcpy(IERPPAKDAT.INTERFACE_TIME, s_sys_time+8, 6);												//INF_PROC_TIME
			

			CDB_insert_ierppakdat(&IERPPAKDAT);

			if(DB_error_code != DB_SUCCESS)
			{
				
				// 20210810 MES Application Memory leak 점검 및 수정
				// DB Error log
				// DB Close 추가
				strcpy(s_msg_code, "BAS-0004");
				TRS.add_fieldmsg(out_node, "IERPPAKDAT INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IERPPAKDAT.DOC_ID), IERPPAKDAT.DOC_ID);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(IERPPAKDAT.PALLET_ID), IERPPAKDAT.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IERPPAKDAT.MODULE_ID), IERPPAKDAT.MODULE_ID);
				TRS.add_fieldmsg(out_node, "ACTION_TYPE", MP_CHR, IERPPAKDAT.ACTION_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				
				CDB_close_cwiplotpak(2);

				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			}

			//IERPWIPCFM 데이터 저장[IF-PP-307] ZMDL 및 팔렛노트 정보 실적보고

			//ERP WORK CENTER GET
			CDB_init_cwipordrte(&CWIPORDRTE);
			memcpy(CWIPORDRTE.FACTORY, CWIPLOTPAK.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
			memcpy(CWIPORDRTE.ORDER_ID, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));
			memcpy(CWIPORDRTE.OPER_NO, "0040", 4);		
			CDB_select_cwipordrte(2, &CWIPORDRTE);
			if(DB_error_code != DB_SUCCESS)
			{
				//에러처리 우선안함.
			}

			CDB_init_mwipeltsts(&MWIPELTSTS);
			memcpy(MWIPELTSTS.LOT_ID, IERPPAKDAT.MODULE_ID, sizeof(IERPPAKDAT.MODULE_ID));	
			CDB_select_mwipeltsts(i_inscase, &MWIPELTSTS);
			if(DB_error_code != DB_SUCCESS)
			{
				
			}

			/* skip "REWOR" grade */
			// RWK 판정받은 경우 GRADE="R01" 로 I/F 될 수 있도록 수정
			if (memcmp(MWIPELTSTS.GRADE, "REWOR", strlen("REWOR")) == 0)
			{
				//return TRUE;
				memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
			}
			if (memcmp(MWIPELTSTS.GRADE, "RWK", strlen("RWK")) == 0)
			{
				//return TRUE;
				memcpy(MWIPELTSTS.GRADE, "R01", sizeof(MWIPELTSTS.GRADE));
			}


			CDB_init_ierpwipcfm(&IERPWIPCFM);
			memcpy(IERPWIPCFM.DOC_ID, IERPPAKDAT.DOC_ID, sizeof(IERPPAKDAT.DOC_ID));			//DOC_ID	
			memcpy(IERPWIPCFM.SITE_ID, IERPPAKDAT.SITE_ID, sizeof(IERPPAKDAT.SITE_ID));			//SITE_ID	
			memcpy(IERPWIPCFM.PROD_ORDER_NO, MWIPLOTSTS.ORDER_ID, sizeof(MWIPLOTSTS.ORDER_ID));//PROD_ORDER_NO	

			memcpy(IERPWIPCFM.MODULE_ID, IERPPAKDAT.MODULE_ID, sizeof(IERPPAKDAT.MODULE_ID));			//MODULE_ID	
			memcpy(IERPWIPCFM.PALLET_ID, IERPPAKDAT.PALLET_ID, sizeof(IERPPAKDAT.PALLET_ID));			//PALLET_ID	
			memcpy(IERPWIPCFM.OPER_NO, "0040", 4);				//OPER_NO
			
			memcpy(IERPWIPCFM.WORK_CENTER, CWIPORDRTE.WORK_CENTER, sizeof(CWIPORDRTE.WORK_CENTER));			//WORK_CENTER	
			IERPWIPCFM.ACTION_TYPE = 'I';			//ACTION_TYPE	
			memcpy(IERPWIPCFM.ZMATNR, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));		//ZMATNR
			memcpy(IERPPAKDAT.PALLET_ID, CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));				//PALLET_ID
			memcpy(IERPPAKDAT.MODULE_ID, CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));						//MODULE_ID
			IERPWIPCFM.PROD_QTY = 1;			//PROD_QTY
			IERPWIPCFM.SCRAP_QTY = 0;			//SCRAP_QTY
			memcpy(IERPWIPCFM.UNIT_ID, "PCS", 3);		//UNIT_ID
			
			//FQC_DATE;
			memcpy(IERPWIPCFM.QUALITY_GRADE, MWIPELTSTS.GRADE, sizeof(MWIPELTSTS.GRADE));						//QUALITY_GRADE
			memcpy(IERPWIPCFM.ZIFERNAM, "PIUSIF", 6);		//ZIFERNAM
			memcpy(IERPWIPCFM.ZIFDATE, s_sys_time, 8);		//ZIFDATE		
			memcpy(IERPWIPCFM.ZIFTIME, s_sys_time+8, 6);	//ZIFTIME
			memcpy(IERPWIPCFM.ZPICODE, "IERPWIPCFM", 9);		//ZPICODE
			IERPWIPCFM.ZPISTAT	= 'R' ; //ZPISTAT
			memcpy(IERPWIPCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date)); //FQC_DATE

		
			CDB_insert_ierpwipcfm(&IERPWIPCFM);
			if(DB_error_code != DB_SUCCESS)
			{
				strcpy(s_msg_code, "BAS-0004");
				TRS.add_fieldmsg(out_node, "&IERPWIPCFM INSERT", MP_NVST);
				TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IERPPAKDAT.DOC_ID), IERPWIPCFM.DOC_ID);
				TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(IERPWIPCFM.PALLET_ID), IERPWIPCFM.PALLET_ID);
				TRS.add_fieldmsg(out_node, "MODULE_ID", MP_STR, sizeof(IERPWIPCFM.MODULE_ID), IERPWIPCFM.MODULE_ID);
				TRS.add_fieldmsg(out_node, "ACTION_TYPE", MP_CHR, IERPWIPCFM.ACTION_TYPE);
				TRS.add_dberrmsg(out_node, DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_TRANS;
				
				
				COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));

				return MP_FALSE;
			}




		}
	}

	/******************************************************/
	// 7 : MODULE TERMINATE (LOSS)
	/******************************************************/
	if (c_inf_type_flag == '7')
	{
		c_upload_flag = 'R';

		//마지막 수행이력 GET 
		CDB_init_mwiplothis(&MWIPLOTHIS);
		TRS.copy(MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID), in_node, "LOT_ID");
		//22.08.09 Module Terminate 취소시 정상적으로 SAP에 데이터가 쌓이지 않은 현상수정
		if (TRS.get_char(in_node, "CANCEL_FLAG") == 'Y')
		{
			CDB_select_mwiplothis(7, &MWIPLOTHIS);
		}
		else
		{
			CDB_select_mwiplothis(2, &MWIPLOTHIS);
		}
		if(DB_error_code != DB_SUCCESS)
		{
			//에러나면 안됨..
		}

		if (memcmp(MWIPLOTHIS.TRAN_CODE, "TERMINATE", strlen("TERMINATE")) != 0)
		{
			return MP_TRUE;
		}

		//IERPOPRCFM 에서 마지막 데이터 가져옮
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));
		CDB_select_ierpoprcfm(5, &IERPOPRCFM);
		if(DB_error_code != DB_SUCCESS)
		{
			//ERP 로 넘긴 실적이 없음 처리안함
			return MP_TRUE;
		}

		// IERPOPRCFM 컬럼값 넣어주기 
		CDB_init_ierpoprcfm(&IERPOPRCFM);
		memcpy(IERPOPRCFM.DOC_ID, MWIPLOTHIS.LOT_DESC, sizeof(IERPOPRCFM.DOC_ID));
		memcpy(IERPOPRCFM.SITE_ID, HQCEL_M1_ERP_SITE_ID_V2, strlen(HQCEL_M1_ERP_SITE_ID_V2));
		memcpy(IERPOPRCFM.PROD_ORDER_NO,MWIPLOTHIS.ORDER_ID, sizeof(MWIPLOTHIS.ORDER_ID));
		memcpy(IERPOPRCFM.MODULE_ID, MWIPLOTHIS.LOT_ID, sizeof(MWIPLOTHIS.LOT_ID));

		memcpy(IERPOPRCFM.OPER_NO, IERPOPRCFM_LST.OPER_NO, sizeof(IERPOPRCFM_LST.OPER_NO));

		memcpy(IERPOPRCFM.WORK_CENTER, IERPOPRCFM_LST.WORK_CENTER, sizeof(IERPOPRCFM_LST.WORK_CENTER));
		IERPOPRCFM.ACTION_TYPE[0] = 'D';
		
		memcpy(IERPOPRCFM.MATE_NO, MWIPLOTHIS.MAT_ID, sizeof(MWIPLOTHIS.MAT_ID));

		if (TRS.get_char(in_node, "CANCEL_FLAG") == 'Y')
		{
			IERPOPRCFM.PROD_QTY[0] = '1';
			IERPOPRCFM.SCRAP_QTY[0] = '0';
		}
		else
		{
			IERPOPRCFM.PROD_QTY[0] = '0';
			IERPOPRCFM.SCRAP_QTY[0] = '1';
		}
		
		memcpy(IERPOPRCFM.UNIT_ID, "PCS", strlen("PCS"));
		TRS.copy(IERPOPRCFM.INF_USER_ID,sizeof(IERPOPRCFM_LST.INF_USER_ID), in_node, IN_USERID);

        /* FQC date is Work date */
		memcpy(IERPOPRCFM.FQC_DATE, cur_work_time.work_date, sizeof(cur_work_time.work_date));

		/* 검사결과값 */
		memcpy(IERPOPRCFM.QUALITY_GRADE, IERPOPRCFM_LST.QUALITY_GRADE, sizeof(IERPOPRCFM_LST.QUALITY_GRADE));
		memcpy(IERPOPRCFM.POWER_GRADE, IERPOPRCFM_LST.POWER_GRADE, sizeof(IERPOPRCFM_LST.POWER_GRADE));
		
		memcpy(IERPOPRCFM.EFF, IERPOPRCFM_LST.EFF, sizeof(IERPOPRCFM_LST.EFF));
		memcpy(IERPOPRCFM.RSH, IERPOPRCFM_LST.RSH, sizeof(IERPOPRCFM_LST.RSH));
		memcpy(IERPOPRCFM.RS, IERPOPRCFM_LST.RS, sizeof(IERPOPRCFM_LST.RS));
		memcpy(IERPOPRCFM.FF, IERPOPRCFM_LST.FF, sizeof(IERPOPRCFM_LST.FF));
		memcpy(IERPOPRCFM.ISC, IERPOPRCFM_LST.ISC, sizeof(IERPOPRCFM_LST.ISC));
		memcpy(IERPOPRCFM.VOC, IERPOPRCFM_LST.VOC, sizeof(IERPOPRCFM_LST.VOC));
		memcpy(IERPOPRCFM.IMPP, IERPOPRCFM_LST.IMPP, sizeof(IERPOPRCFM_LST.IMPP));
		memcpy(IERPOPRCFM.VMPP, IERPOPRCFM_LST.VMPP, sizeof(IERPOPRCFM_LST.VMPP));
		memcpy(IERPOPRCFM.PMPP, IERPOPRCFM_LST.PMPP, sizeof(IERPOPRCFM_LST.PMPP));
		memcpy(IERPOPRCFM.TEMP, IERPOPRCFM_LST.TEMP, sizeof(IERPOPRCFM_LST.TEMP));
		memcpy(IERPOPRCFM.SURFTEMP, IERPOPRCFM_LST.SURFTEMP, sizeof(IERPOPRCFM_LST.SURFTEMP));
		memcpy(IERPOPRCFM.SUN, IERPOPRCFM_LST.SUN, sizeof(IERPOPRCFM_LST.SUN));
		memcpy(IERPOPRCFM.OSC, IERPOPRCFM_LST.OSC, sizeof(IERPOPRCFM_LST.OSC));
		memcpy(IERPOPRCFM.ESC, IERPOPRCFM_LST.ESC, sizeof(IERPOPRCFM_LST.ESC));
		memcpy(IERPOPRCFM.EL,  IERPOPRCFM_LST.EL, sizeof(IERPOPRCFM_LST.EL));
		
		//SIM 설비( 앞의3자리 US- 를 제외하고 뒤의자리만)
		memcpy(IERPOPRCFM.FLASHER_CODE, IERPOPRCFM_LST.FLASHER_CODE, sizeof(IERPOPRCFM_LST.FLASHER_CODE));
	
        //memcpy(IERPOPRCFM.ARTICLE_CODE, IBAKOPRCFM.ARTICLE_NO, sizeof(IBAKOPRCFM.ARTICLE_NO));
		memcpy(IERPOPRCFM.COLOR_CLASS, IERPOPRCFM_LST.COLOR_CLASS, sizeof(IERPOPRCFM_LST.COLOR_CLASS));
		
		//memcpy(IERPOPRCFM.FQC_DATE, MWIPELTSTS.FQC_TIME, 8);
        memset(IERPOPRCFM.SHIFT,  ' ', sizeof(IERPOPRCFM.SHIFT));
		if (cur_work_time.work_shift == 1)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_1[0];
		else if (cur_work_time.work_shift == 2)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_2[0];
		else if (cur_work_time.work_shift == 3)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_3[0];
		else if (cur_work_time.work_shift == 4)
			IERPOPRCFM.SHIFT[0] = MWIPCALDEF.CAL_CMF_4[0];


		//memcpy(IERPOPRCFM.LOCATION, MWIPELTSTS.LOC_ID, 3);
        memcpy(IERPOPRCFM.LOCATION, IERPOPRCFM_LST.LOCATION, sizeof(IERPOPRCFM_LST.LOCATION));
		//memcpy(IERPOPRCFM.ARTICLE_CODE, IBAKOPRCFM.ARTICLE_CODE, sizeof(IBAKOPRCFM.ARTICLE_CODE));

		memcpy(IERPOPRCFM.INF_TIME,  s_sys_time, sizeof(s_sys_time));
		IERPOPRCFM.DATA_FLAG = 'I';
		IERPOPRCFM.ZPISTAT =c_upload_flag;
		//20190713 HCH KIM  : ERP 요청으로 AOI_RESULT 를 추가로 전송 CMF_1사용 
		memcpy(IERPOPRCFM.CMF_1, CEDCLOTRLT.RESULT_VALUE, sizeof(CEDCLOTRLT.RESULT_VALUE));

        //20190905 ISSUE-09-003 IERPOPRCFM.CMF_2에 대표 불량 코드 추가 버그 수정.
        CDB_init_cedclotfqc(&CEDCLOTFQC);
        memcpy(CEDCLOTFQC.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
		//TRS.copy(CEDCLOTFQC.FACTORY, sizeof(CEDCLOTFQC.FACTORY), in_node, IN_FACTORY);
		memcpy(CEDCLOTFQC.INS_TYPE, HQCEL_INS_TYPE_CATEGORY_FQC, strlen(HQCEL_INS_TYPE_CATEGORY_FQC));
		TRS.copy(CEDCLOTFQC.LOT_ID, sizeof(CEDCLOTFQC.LOT_ID), in_node, "LOT_ID");
		CDB_select_cedclotfqc(2, &CEDCLOTFQC);

		if(DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

        // 10/22/2019 Defect Code만 보내도록 수정.
        /*
        DBC_init_mgcmtbldat(&MGCMTBLDAT);
        memcpy(MGCMTBLDAT.FACTORY, MWIPLOTHIS.FACTORY, sizeof(MWIPLOTHIS.FACTORY));
        //TRS.copy(MGCMTBLDAT.FACTORY, sizeof(MGCMTBLDAT.FACTORY), in_node, IN_FACTORY);
		memcpy(MGCMTBLDAT.TABLE_NAME, "@DEFECT", strlen("@DEFECT"));
		memcpy(MGCMTBLDAT.KEY_1, CEDCLOTFQC.DEFECT_CODE, sizeof(CEDCLOTFQC.DEFECT_CODE));
        memcpy(MGCMTBLDAT.KEY_2, CEDCLOTFQC.OPER, sizeof(CEDCLOTFQC.OPER));
        DBC_select_mgcmtbldat(104, &MGCMTBLDAT);

        if(DB_error_code != DB_SUCCESS)
		{
			// Do Nothing
		}

        memcpy(IERPOPRCFM.CMF_2, MGCMTBLDAT.DATA_4, sizeof(IERPOPRCFM.CMF_2));
        */
        memcpy(IERPOPRCFM.CMF_2, CEDCLOTFQC.DEFECT_CODE, sizeof(IERPOPRCFM.CMF_2));

		/* Terminate Description */
		//memcpy(IERPOPRCFM.CMF_3, MWIPLOTHIS.TRAN_COMMENT, sizeof(MWIPLOTHIS.TRAN_COMMENT)); IS-21-01-094 MES logic 개선
		memcpy(IERPOPRCFM.CMF_3, MWIPLOTHIS.TRAN_COMMENT, sizeof(IERPOPRCFM.CMF_3));

		//Z93에서 넘어온 데이터는 실적 처리 안함
		//VOC-5049 Z93인터페이스 된 폐기/취소 인경우 SAP로 재 전송 안되도록 변경(22.10.25)
		ihisChk = 0;
		CDB_init_ibakterinf(&IBAKTERINF);
		
		memcpy(IBAKTERINF.MODULE_ID, IERPOPRCFM.MODULE_ID, sizeof(IERPOPRCFM.MODULE_ID));	;
		memcpy(IBAKTERINF.ZIFDATE, s_sys_time, 8);

		if (TRS.get_char(in_node, "CANCEL_FLAG") == 'Y')
		{
			IBAKTERINF.ZTYP1  = 'D';
		}
		else
		{
			IBAKTERINF.ZTYP1  = 'I';
		}
		ihisChk = (int) CDB_select_ibakterinf_scalar(2,&IBAKTERINF);
		if(ihisChk > 0)
		{
			return MP_TRUE;
		}


		//VOC-5049 Z93인터페이스 된 폐기/취소 인경우 SAP로 재 전송 안되도록 변경(22.10.25)

		CDB_insert_ierpoprcfm(&IERPOPRCFM);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code == DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "BAS-0026");
                gs_log_type.e_type = MP_LOG_E_EXISTENCE;
            }
            else
            {
                strcpy(s_msg_code, "BAS-0004");
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                TRS.add_dberrmsg(out_node, DB_error_msg);
            }
            gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;			
			return MP_FALSE;
        }
		
		//IBAKOPRCFM DATA INSERT
		memcpy(IBAKOPRCFM.DOC_ID, IERPOPRCFM.DOC_ID, sizeof(struct IBAKOPRCFM_TAG));
		CDB_insert_ibakoprcfm(&IBAKOPRCFM);
		if(DB_error_code != DB_SUCCESS)
        {

		}
	}

	return MP_TRUE;
}


