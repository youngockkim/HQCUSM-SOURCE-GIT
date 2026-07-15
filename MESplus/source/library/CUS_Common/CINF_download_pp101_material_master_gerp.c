/*******************************************************************************

    System      : MESplus
    Module      : Material Master setup
    File Name   : CINF_download_pp101_material_master_gerp.c
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
	2	  2023.02.20  JD.PARK

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include "CUS_common.h"
#include <BASCore_common.h>

int CUS_INTERFACE_DOWNLOAD_MATERIAL_MASTER_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    Material_Master_Gerp()
        - ERP->MES Material Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_Interface_Download_Material_Master_Gerp(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CUS_INTERFACE_DOWNLOAD_MATERIAL_MASTER_GERP(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node);

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
    CUS_INTERFACE_DOWNLOAD_Material_Master_Gerp()
        - ERP->MES Material Master
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - char *s_msg_code : Error Msg Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CUS_INTERFACE_DOWNLOAD_MATERIAL_MASTER_GERP(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
    struct IWIPMATDEF_TAG IWIPMATDEF;
    struct IBAKMATDEF_TAG IBAKMATDEF;
	struct MWIPMATDEF_TAG MWIPMATDEF;
	struct MGCMTBLDAT_TAG MGCMTBLDAT;	
	struct MGCMLAGDAT_TAG MGCMLAGDAT;	// MES-2029
	
	TRSNode *in_node1;
	TRSNode *out_node1;

	TRSNode *tran_in_node;
	TRSNode *tran_out_node;

	char s_sys_time[14];
	char procStep;
	int cal_cellqty = 0;

	// PROCESS LOG PRINT
	LOG_head("CINF_MATERIAL_MASTER_ERP_PP101_PROCESS");
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
	CDB_init_iwipmatdef(&IWIPMATDEF);
    CDB_open_iwipmatdef(2, &IWIPMATDEF);
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
            TRS.add_fieldmsg(out_node, "IWIPMATDEF OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPMATDEF.DOC_ID), IWIPMATDEF.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IWIPMATDEF.SITE_ID), IWIPMATDEF.SITE_ID);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPMATDEF.MATE_NO), IWIPMATDEF.MATE_NO);
            TRS.add_fieldmsg(out_node, "MATE_NM", MP_STR, sizeof(IWIPMATDEF.MATE_NM), IWIPMATDEF.MATE_NM);
            TRS.add_fieldmsg(out_node, "MATE_TYPE", MP_STR, sizeof(IWIPMATDEF.MATE_TYPE), IWIPMATDEF.MATE_TYPE);
			TRS.add_fieldmsg(out_node, "SAP_MATE_TYPE", MP_STR, sizeof(IWIPMATDEF.SAP_MATE_TYPE), IWIPMATDEF.SAP_MATE_TYPE);
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
        CDB_fetch_iwipmatdef(2, &IWIPMATDEF);
        if(DB_error_code == DB_NOT_FOUND) 
        {
            CDB_close_iwipmatdef(2);
            break;
        }
        else if(DB_error_code != DB_SUCCESS) 
        {
            strcpy(s_msg_code, "WIP-0004");
            TRS.add_fieldmsg(out_node, "IWIPMATDEF OPEN", MP_NVST);
            TRS.add_fieldmsg(out_node, "DOC_ID", MP_STR, sizeof(IWIPMATDEF.DOC_ID), IWIPMATDEF.DOC_ID);
            TRS.add_fieldmsg(out_node, "SITE_ID", MP_STR, sizeof(IWIPMATDEF.SITE_ID), IWIPMATDEF.SITE_ID);
            TRS.add_fieldmsg(out_node, "MATE_NO", MP_STR, sizeof(IWIPMATDEF.MATE_NO), IWIPMATDEF.MATE_NO);
            TRS.add_fieldmsg(out_node, "MATE_NM", MP_STR, sizeof(IWIPMATDEF.MATE_NM), IWIPMATDEF.MATE_NM);
            TRS.add_fieldmsg(out_node, "MATE_TYPE", MP_STR, sizeof(IWIPMATDEF.MATE_TYPE), IWIPMATDEF.MATE_TYPE);
			TRS.add_fieldmsg(out_node, "SAP_MATE_TYPE", MP_STR, sizeof(IWIPMATDEF.SAP_MATE_TYPE), IWIPMATDEF.SAP_MATE_TYPE);
            TRS.add_dberrmsg(out_node, DB_error_msg);

            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_VIEW;
            CDB_close_iwipmatdef(2);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		DBC_init_mwipmatdef(&MWIPMATDEF);
		memcpy(MWIPMATDEF.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MWIPMATDEF.MAT_ID, IWIPMATDEF.MATE_NO, sizeof(MWIPMATDEF.MAT_ID));
		MWIPMATDEF.MAT_VER = 1;
		DBC_select_mwipmatdef(1, &MWIPMATDEF);
				
		if (DB_error_code == DB_NOT_FOUND)
		{
			//CREATE
			procStep = 'I';
			if (IWIPMATDEF.DEL_YN == 'Y') 
			{
				/***********************************/
				// BACKUP TABLE : IWIPMATDEF -> IBAKMATDEF
				/***********************************/
				CDB_init_ibakmatdef(&IBAKMATDEF);
				memcpy(IBAKMATDEF.DOC_ID, IWIPMATDEF.DOC_ID, sizeof(struct IWIPMATDEF_TAG));
				CDB_delete_ibakmatdef(1, &IBAKMATDEF);
				CDB_insert_ibakmatdef(&IBAKMATDEF);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
		
				// DELETE IWIPMATDEF
				CDB_delete_iwipmatdef(1,&IWIPMATDEF);
				if(DB_error_code != DB_SUCCESS)
				{
					//DO NOTHING
				}
		

				continue;
			}
		} 
		else 
		{
			if (IWIPMATDEF.DEL_YN == 'Y')
			{
				//DELETE
				if (MWIPMATDEF.DELETE_FLAG == 'Y')
				{
					//이미 삭제된 케이스
					/***********************************/
					// BACKUP TABLE : IWIPMATDEF -> IBAKMATDEF
					/***********************************/
					CDB_init_ibakmatdef(&IBAKMATDEF);
					memcpy(IBAKMATDEF.DOC_ID, IWIPMATDEF.DOC_ID, sizeof(struct IWIPMATDEF_TAG));
					CDB_delete_ibakmatdef(1, &IBAKMATDEF);
					CDB_insert_ibakmatdef(&IBAKMATDEF);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
		
					// DELETE IWIPMATDEF
					CDB_delete_iwipmatdef(1,&IWIPMATDEF);
					if(DB_error_code != DB_SUCCESS)
					{
						//DO NOTHING
					}
		

					continue;
				}
				procStep = 'D';
			}
			else
			{
				if (MWIPMATDEF.DELETE_FLAG == 'Y')
				{
					//UNDELETE (이후 필요하면 UPDATE LOGIC 들어가야함)
					procStep = 'R';
				}
				else
				{
					//UPDATE
					procStep = 'U';
				}
			}
		}
	
		in_node1 = TRS.create_node("UPDATE_MATERIAL_IN");
		out_node1 = TRS.create_node("CMN_OUT");
		
		TRS.set_string(in_node1, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		TRS.set_char(in_node1, "PROCSTEP", procStep);
		TRS.set_string(in_node1, "MAT_ID", IWIPMATDEF.MATE_NO, sizeof(IWIPMATDEF.MATE_NO));		
		TRS.set_int(in_node1, "MAT_VER", 1);
		TRS.set_string(in_node1, "MAT_DESC", IWIPMATDEF.MATE_NM, sizeof(IWIPMATDEF.MATE_NM));
		//TRS.set_string(in_node1, "MAT_SHORT_DESC", IWIPMATDEF.MATE_TYPE_DESC, sizeof(IWIPMATDEF.MATE_TYPE_DESC));
		
		//MAT_SHORT_DESC 는 더이상 I/F 받지 않고 신규 모델(Module) 생기는 경우 화면에서 수정한다.
		TRS.set_string(in_node1, "MAT_SHORT_DESC", MWIPMATDEF.MAT_SHORT_DESC, sizeof(MWIPMATDEF.MAT_SHORT_DESC));
		

		//MAT_TYPE (CLASS): 
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "MATERIAL_TYPE", strlen("MATERIAL_TYPE"));
		memcpy(MGCMTBLDAT.KEY_1, IWIPMATDEF.MATE_CLASS, sizeof(MGCMTBLDAT.KEY_1));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			memcpy(MGCMTBLDAT.DATA_1, IWIPMATDEF.MATE_CLASS, sizeof(MGCMTBLDAT.KEY_1));
			DBC_insert_mgcmtbldat(&MGCMTBLDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}
		TRS.set_string(in_node1, "MAT_TYPE", IWIPMATDEF.MATE_CLASS, sizeof(IWIPMATDEF.MATE_CLASS));

		
		//MGCMTBLDAT ( UNIT)
		DBC_init_mgcmtbldat(&MGCMTBLDAT);
		memcpy(MGCMTBLDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
		memcpy(MGCMTBLDAT.TABLE_NAME, "UNIT", strlen("UNIT"));
		memcpy(MGCMTBLDAT.KEY_1, IWIPMATDEF.UNIT_ID, sizeof(MGCMTBLDAT.KEY_1));
		DBC_select_mgcmtbldat(1, &MGCMTBLDAT);
		if (DB_error_code != DB_SUCCESS)
		{
			memcpy(MGCMTBLDAT.DATA_1, IWIPMATDEF.UNIT_ID, sizeof(MGCMTBLDAT.KEY_1));
			DBC_insert_mgcmtbldat(&MGCMTBLDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				//DO NOTHING
			}
		}

		TRS.set_string(in_node1, "UNIT1", IWIPMATDEF.UNIT_ID, sizeof(IWIPMATDEF.UNIT_ID));	

		//CMF_1 (MATERAIL_TYPE) 
		TRS.set_string(in_node1, "MAT_CMF_1", IWIPMATDEF.MATE_TYPE, 30);
				
        //material cmf_2, cmf_3 는 업데이트 되면 안됨 ( 20190626 )
		//MAT_ID 에 이미 CELL 정보가 들어있으므로 해당 정보로 자동 업데이트 되도록 로직 수정함 (20191218)
        //TRS.set_string(in_node1, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, 30 );
        //TRS.set_string(in_node1, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, 30 );

		// MAT_ID 기준이 변경되거나, 셀 정보가 추가/삭제되면 여기도 수정이 필요하다.
		// MODEL CODE 4번째 자리숫자가 CELL 의 NUMBER 구분자임
		// 1 : 144 셀, 2: 120셀 , 3 : 156 셀 , 4 : 132 셀
		// 이걸로 MAT_CMF_2, MAT_CMF_3 정보 업데이트 하도록 수정
		// 01234567
		// 000666120616200087
		//2차 고도화로 인한여 제품 정보가 하프셀 기준으로 /2 나누어서 제공됨
		cal_cellqty = 0;
		if (memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZMDL", strlen("ZMDL")) == 0 ) 
		{		
			if(COM_isnullspace(IWIPMATDEF.CELL_QTY) == MP_FALSE)
			{
				cal_cellqty = 0;
				cal_cellqty = COM_atoi(IWIPMATDEF.CELL_QTY,sizeof(IWIPMATDEF.CELL_QTY));	
				cal_cellqty = cal_cellqty * 2;
				//memset(IWIPMATDEF.CELL_QTY, ' ', sizeof(IWIPMATDEF.CELL_QTY));
				//COM_itoa_left(IWIPMATDEF.CELL_QTY, cal_cellqty, sizeof(cal_cellqty));	
			}
		}
		if (memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZBOM,", strlen("ZBOM")) == 0 ) 
		{		
			if(COM_isnullspace(IWIPMATDEF.CELL_QTY) == MP_FALSE)
			{
				cal_cellqty = 0;
				cal_cellqty = COM_atoi(IWIPMATDEF.CELL_QTY,sizeof(IWIPMATDEF.CELL_QTY));	
				cal_cellqty = cal_cellqty * 2;
				//memset(IWIPMATDEF.CELL_QTY, ' ', sizeof(IWIPMATDEF.CELL_QTY));
				//COM_itoa_left(IWIPMATDEF.CELL_QTY, cal_cellqty, sizeof(cal_cellqty));	
			}
		}




		if (memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZMDL", strlen("ZMDL")) == 0 )
		{
			if(cal_cellqty == 144)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "144");
			}
			else if(cal_cellqty == 120)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", "Y");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "120");
			}
			else if(cal_cellqty == 156)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "156");
			}
			else if(cal_cellqty == 132)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "132");
			}
			else if(cal_cellqty == 108)		//108 제품 추가[23.09.12]
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "108");
			}

			else
			{
				TRS.set_string(in_node1, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, 30 );
				TRS.set_string(in_node1, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, 30 );
			}
		}
		// 2023-01-25 ZBOM 분기 추가 (기존로직은 안건들임)
		else if ( memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZBOM", strlen("ZBOM")) == 0 )
		{
			if(cal_cellqty == 144)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "144");
			}
			else if(cal_cellqty == 120)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", "Y");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "120");
			}
			else if(cal_cellqty == 156)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "156");
			}
			else if(cal_cellqty == 132)
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "132");
			}
			else if(cal_cellqty == 108)			//108 제품 추가[23.09.12]
			{
				TRS.set_nstring(in_node1, "MAT_CMF_2", " ");
		        TRS.set_nstring(in_node1, "MAT_CMF_3", "108");
			}
			else
			{
				TRS.set_string(in_node1, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, 30 );
				TRS.set_string(in_node1, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, 30 );
			}
		}
		else
		{
				TRS.set_string(in_node1, "MAT_CMF_2", MWIPMATDEF.MAT_CMF_2, 30 );
				TRS.set_string(in_node1, "MAT_CMF_3", MWIPMATDEF.MAT_CMF_3, 30 );
		}


		// MAT_SHORT_DESC로 I/F 받던 항목을  CMF에서 받도록 해놓고 필요하면 가져다 쓴다.
		TRS.set_string(in_node1, "MAT_CMF_5", IWIPMATDEF.PROD_SUBTYPE_DESC, sizeof(IWIPMATDEF.PROD_SUBTYPE_DESC));		
		
		// TUV인증위해 칼럼추가 Certification I/F
		TRS.set_string(in_node1, "MAT_CMF_6", IWIPMATDEF.PROD_CERT, sizeof(IWIPMATDEF.PROD_CERT));		
		TRS.set_string(in_node1, "MAT_CMF_7", IWIPMATDEF.PROD_CERT_DESC, sizeof(IWIPMATDEF.PROD_CERT_DESC));		
        TRS.set_string(in_node1, "MAT_CMF_8", MWIPMATDEF.MAT_CMF_8, sizeof(MWIPMATDEF.MAT_CMF_8));
        TRS.set_string(in_node1, "MAT_CMF_9 ", MWIPMATDEF.MAT_CMF_9, sizeof(MWIPMATDEF.MAT_CMF_9));
        TRS.set_string(in_node1, "MAT_CMF_10", MWIPMATDEF.MAT_CMF_10, sizeof(MWIPMATDEF.MAT_CMF_10));
        TRS.set_string(in_node1, "MAT_CMF_11", MWIPMATDEF.MAT_CMF_11, sizeof(MWIPMATDEF.MAT_CMF_11));
        TRS.set_string(in_node1, "MAT_CMF_12", MWIPMATDEF.MAT_CMF_12, sizeof(MWIPMATDEF.MAT_CMF_12));
        TRS.set_string(in_node1, "MAT_CMF_13", MWIPMATDEF.MAT_CMF_13, sizeof(MWIPMATDEF.MAT_CMF_13));
        TRS.set_string(in_node1, "MAT_CMF_14", MWIPMATDEF.MAT_CMF_14, sizeof(MWIPMATDEF.MAT_CMF_14));
        TRS.set_string(in_node1, "MAT_CMF_15", MWIPMATDEF.MAT_CMF_15, sizeof(MWIPMATDEF.MAT_CMF_15));
        TRS.set_string(in_node1, "MAT_CMF_16", MWIPMATDEF.MAT_CMF_16, sizeof(MWIPMATDEF.MAT_CMF_16));
        TRS.set_string(in_node1, "MAT_CMF_17", MWIPMATDEF.MAT_CMF_17, sizeof(MWIPMATDEF.MAT_CMF_17));
        TRS.set_string(in_node1, "MAT_CMF_18", MWIPMATDEF.MAT_CMF_18, sizeof(MWIPMATDEF.MAT_CMF_18));
        TRS.set_string(in_node1, "MAT_CMF_19", MWIPMATDEF.MAT_CMF_19, sizeof(MWIPMATDEF.MAT_CMF_19));
        TRS.set_string(in_node1, "MAT_CMF_20", MWIPMATDEF.MAT_CMF_20, sizeof(MWIPMATDEF.MAT_CMF_20));

		// INSERT GT(General Table)
		if(WIP_UPDATE_MATERIAL(s_msg_code, in_node1, out_node1)== MP_FALSE)
		{
			DB_rollback();
			COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node1);
			COM_set_field_db_msg(out_node, out_node1);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			TRS.set_string(in_node1, "DOC_ID", IWIPMATDEF.DOC_ID, sizeof(IWIPMATDEF.DOC_ID));			
			TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
			TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
			memcpy(IWIPMATDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
			CDB_update_iwipmatdef(2,&IWIPMATDEF);
			TRS.free_node(in_node1);
			TRS.free_node(out_node1);
			DB_commit();
			continue;


		} 

		// TODO
		// 생성된 제품 종류가 Full Cell, Half Cell, Module 인 경우 해당하는 FLOW를 매핑해줘야 한다.
		// SAP_MATE_TYPE : ZMDL, ZHCL, ZCEL
		// ZHCL -> CVP100, ZCEL -> CEL100, ZMDL -> MDP100, ZBOM -> BMP100[RICEF : MES-2029 추가]
		// WIP_Attach_Flow_ToMaterial 호출

		// FACTORY, PROCSTEP, MAT_ID, MAT_VER, FLOW

		tran_in_node = TRS.create_node("TRAN_IN");
		tran_out_node = TRS.create_node("TRAN_OUT");

		TRS.set_string(tran_in_node, "FACTORY", HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));		
		TRS.set_char(tran_in_node, "PROCSTEP", '1');  
		
		TRS.add_string(tran_in_node, "MAT_ID", MWIPMATDEF.MAT_ID, sizeof(MWIPMATDEF.MAT_ID));
		TRS.set_int(tran_in_node, "MAT_VER", MWIPMATDEF.MAT_VER);		

		// Module( ZMDL )				
		if ( memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZMDL", strlen("ZMDL")) == 0 )
		{
			TRS.set_string(tran_in_node, "FLOW", HQCEL_M1_FLOW_MDP100, strlen(HQCEL_M1_FLOW_MDP100));
			if (WIP_ATTACH_FLOW_TOMATERIAL(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				// DO NOTHING
			}
		}
		// RICEF : MES-2029
		// Module ( ZBOM ) 
		// 2023.01.17 ZBOM FLOWCODE Add (HQCEL_M1_FLOW_BMP100)
		// 2023.03.06 ZBOM HQCEL_M1_FLOW_BMP100 -> HQCEL_M1_FLOW_MDP100 Update
		else if ( memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZBOM", strlen("ZBOM")) == 0 )
		{
			//TRS.set_string(tran_in_node, "FLOW", HQCEL_M1_FLOW_BMP100, strlen(HQCEL_M1_FLOW_BMP100));
			TRS.set_string(tran_in_node, "FLOW", HQCEL_M1_FLOW_MDP100, strlen(HQCEL_M1_FLOW_MDP100));
			if (WIP_ATTACH_FLOW_TOMATERIAL(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				// DO NOTHING
			}
		}
		// Half Cell
		else if (memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZHCL", strlen("ZHCL")) == 0)
		{
			TRS.set_string(tran_in_node, "FLOW", HQCEL_M1_FLOW_CVP100, strlen(HQCEL_M1_FLOW_CVP100));
			if (WIP_ATTACH_FLOW_TOMATERIAL(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				// DO NOTHING
			}
		}
		// Full Cell
		else if (memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZCEL", strlen("ZCEL")) == 0)
		{
			TRS.set_string(tran_in_node, "FLOW", HQCEL_M1_FLOW_CEL100, strlen(HQCEL_M1_FLOW_CEL100));
			if (WIP_ATTACH_FLOW_TOMATERIAL(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				// DO NOTHING
			}
		}
		// Full Cell(ZFCL->FULL)
		else if (memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZFCL", strlen("ZFCL")) == 0)
		{
			TRS.set_string(tran_in_node, "FLOW", HQCEL_M1_FLOW_CEL100, strlen(HQCEL_M1_FLOW_CEL100));
			if (WIP_ATTACH_FLOW_TOMATERIAL(s_msg_code, tran_in_node, tran_out_node) == MP_FALSE)
			{
				// DO NOTHING
			}
		}

		/* 05.03 GCM ARTICLE DESC 으로 저장 */
		if (memcmp(IWIPMATDEF.SAP_MATE_TYPE, "ZMDL", strlen("ZMDL")) == 0)
		{
			CDB_init_mgcmlagdat(&MGCMLAGDAT);
			memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_PAKCING_POWER_CLASS, strlen(HQCEL_M1_GCM_PAKCING_POWER_CLASS));  //ARTICLE DESC
			memcpy(MGCMLAGDAT.KEY_1, IWIPMATDEF.MATE_NO, sizeof(IWIPMATDEF.MATE_NO));


			CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					memcpy(MGCMLAGDAT.DATA_1, IWIPMATDEF.CMF_1, sizeof(IWIPMATDEF.CMF_1));
					memcpy(MGCMLAGDAT.DATA_2, IWIPMATDEF.CMF_2, sizeof(IWIPMATDEF.CMF_2));
					memcpy(MGCMLAGDAT.DATA_3, IWIPMATDEF.CMF_3, sizeof(IWIPMATDEF.CMF_3));
					memcpy(MGCMLAGDAT.DATA_4, IWIPMATDEF.CMF_4, sizeof(IWIPMATDEF.CMF_4));	// 23.05.16 [GERP PROJECT] Z GRADE 추가 
					memcpy(MGCMLAGDAT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
					memcpy(MGCMLAGDAT.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));

					DBC_insert_mgcmlagdat(&MGCMLAGDAT);
					if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "Article Desc A, B, C INSERT", MP_NVST);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;

						DB_rollback();
						COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node1);
						COM_set_field_db_msg(out_node, out_node1);

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						TRS.set_string(in_node1, "DOC_ID", IWIPMATDEF.DOC_ID, sizeof(IWIPMATDEF.DOC_ID));
						TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
						TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
						memcpy(IWIPMATDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
						CDB_update_iwipmatdef(2, &IWIPMATDEF);
						TRS.free_node(in_node1);
						TRS.free_node(out_node1);
						DB_commit();
						continue;
					}
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "PACKING_POWER_CLASS A, B, C, Z INSERT", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					DB_rollback();
					COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node1);
					COM_set_field_db_msg(out_node, out_node1);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					TRS.set_string(in_node1, "DOC_ID", IWIPMATDEF.DOC_ID, sizeof(IWIPMATDEF.DOC_ID));
					TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
					TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
					memcpy(IWIPMATDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
					CDB_update_iwipmatdef(2, &IWIPMATDEF);
					TRS.free_node(in_node1);
					TRS.free_node(out_node1);
					DB_commit();
					continue;
				}

			}
			else
			{
				memcpy(MGCMLAGDAT.DATA_1, IWIPMATDEF.CMF_1, sizeof(IWIPMATDEF.CMF_1));
				memcpy(MGCMLAGDAT.DATA_2, IWIPMATDEF.CMF_2, sizeof(IWIPMATDEF.CMF_2));
				memcpy(MGCMLAGDAT.DATA_3, IWIPMATDEF.CMF_3, sizeof(IWIPMATDEF.CMF_3));
				memcpy(MGCMLAGDAT.DATA_4, IWIPMATDEF.CMF_4, sizeof(IWIPMATDEF.CMF_4));	// 23.05.16 [GERP PROJECT] Z GRADE 추가 
				memcpy(MGCMLAGDAT.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
				memcpy(MGCMLAGDAT.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));

				DBC_update_mgcmlagdat(1, &MGCMLAGDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "PACKING_POWER_CLASS A, B, C, Z INSERT", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					DB_rollback();
					COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node1);
					COM_set_field_db_msg(out_node, out_node1);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					TRS.set_string(in_node1, "DOC_ID", IWIPMATDEF.DOC_ID, sizeof(IWIPMATDEF.DOC_ID));
					TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
					TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
					memcpy(IWIPMATDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
					CDB_update_iwipmatdef(2, &IWIPMATDEF);
					TRS.free_node(in_node1);
					TRS.free_node(out_node1);
					DB_commit();
					continue;
				}
			}

			// [GERP PROJECT] 23.05.16 Packing Type 추가
			CDB_init_mgcmlagdat(&MGCMLAGDAT);
			memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));
			memcpy(MGCMLAGDAT.TABLE_NAME, HQCEL_M1_GCM_PACKING_TYPE, strlen(HQCEL_M1_GCM_PACKING_TYPE));  //HQCEL_M1_GCM_PACKING_TYPE
			memcpy(MGCMLAGDAT.KEY_1, IWIPMATDEF.MATE_NO, sizeof(IWIPMATDEF.MATE_NO));


			CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
			if (DB_error_code != DB_SUCCESS)
			{
				if (DB_error_code == DB_NOT_FOUND)
				{
					memcpy(MGCMLAGDAT.DATA_1, IWIPMATDEF.CMF_5, sizeof(IWIPMATDEF.CMF_5));
					memcpy(MGCMLAGDAT.CREATE_TIME, s_sys_time, sizeof(s_sys_time));
					memcpy(MGCMLAGDAT.CREATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));

					DBC_insert_mgcmlagdat(&MGCMLAGDAT);
					if (DB_error_code != DB_SUCCESS)
					{
						strcpy(s_msg_code, "WIP-0004");
						TRS.add_fieldmsg(out_node, "MODULE TYPE INSERT", MP_NVST);
						TRS.add_dberrmsg(out_node, DB_error_msg);
						gs_log_type.type = MP_LOG_ERROR;
						gs_log_type.e_type = MP_LOG_E_SYSTEM;
						gs_log_type.category = MP_LOG_CATE_VIEW;

						DB_rollback();
						COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node1);
						COM_set_field_db_msg(out_node, out_node1);

						COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
						TRS.set_string(in_node1, "DOC_ID", IWIPMATDEF.DOC_ID, sizeof(IWIPMATDEF.DOC_ID));
						TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
						TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
						memcpy(IWIPMATDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
						CDB_update_iwipmatdef(2, &IWIPMATDEF);
						TRS.free_node(in_node1);
						TRS.free_node(out_node1);
						DB_commit();
						continue;
					}
				}
				else
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "MODULE TYPE INSERT", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					DB_rollback();
					COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node1);
					COM_set_field_db_msg(out_node, out_node1);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					TRS.set_string(in_node1, "DOC_ID", IWIPMATDEF.DOC_ID, sizeof(IWIPMATDEF.DOC_ID));
					TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
					TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
					memcpy(IWIPMATDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
					CDB_update_iwipmatdef(2, &IWIPMATDEF);
					TRS.free_node(in_node1);
					TRS.free_node(out_node1);
					DB_commit();
					continue;
				}

			}
			else
			{
				memcpy(MGCMLAGDAT.DATA_1, IWIPMATDEF.CMF_5, sizeof(IWIPMATDEF.CMF_5));
				memcpy(MGCMLAGDAT.UPDATE_TIME, s_sys_time, sizeof(s_sys_time));
				memcpy(MGCMLAGDAT.UPDATE_USER_ID, MODULE_EAP, strlen(MODULE_EAP));

				DBC_update_mgcmlagdat(1, &MGCMLAGDAT);
				if (DB_error_code != DB_SUCCESS)
				{
					strcpy(s_msg_code, "WIP-0004");
					TRS.add_fieldmsg(out_node, "PACKING_POWER_CLASS A, B, C, Z INSERT", MP_NVST);
					TRS.add_dberrmsg(out_node, DB_error_msg);
					gs_log_type.type = MP_LOG_ERROR;
					gs_log_type.e_type = MP_LOG_E_SYSTEM;
					gs_log_type.category = MP_LOG_CATE_VIEW;

					DB_rollback();
					COM_out_msg_log_write(s_msg_code, "CUS_Interface_Download_Material_Master_Gerp", out_node1);
					COM_set_field_db_msg(out_node, out_node1);

					COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
					TRS.set_string(in_node1, "DOC_ID", IWIPMATDEF.DOC_ID, sizeof(IWIPMATDEF.DOC_ID));
					TRS.set_string(in_node1, "RETURN_TYPE", "E", strlen("E"));
					TRS.set_string(in_node1, "RETURN_MSG", s_msg_code, strlen(s_msg_code));
					memcpy(IWIPMATDEF.RETURN_MSG, s_msg_code, strlen(s_msg_code));
					CDB_update_iwipmatdef(2, &IWIPMATDEF);
					TRS.free_node(in_node1);
					TRS.free_node(out_node1);
					DB_commit();
					continue;
				}
			}
		}



		/***********************************/
        // BACKUP TABLE : IWIPMATDEF -> IBAKMATDEF
		/***********************************/
        CDB_init_ibakmatdef(&IBAKMATDEF);
		memcpy(IBAKMATDEF.DOC_ID, IWIPMATDEF.DOC_ID, sizeof(struct IWIPMATDEF_TAG));
		CDB_delete_ibakmatdef(1, &IBAKMATDEF);
		CDB_insert_ibakmatdef(&IBAKMATDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		
		// DELETE IWIPMATDEF
		CDB_delete_iwipmatdef(1,&IWIPMATDEF);
		if(DB_error_code != DB_SUCCESS)
		{
			//DO NOTHING
		}
		
		TRS.free_node(tran_in_node);
		TRS.free_node(tran_out_node);
		TRS.free_node(in_node1);
		TRS.free_node(out_node1);
		DB_commit();
	}

	return MP_TRUE;
}
