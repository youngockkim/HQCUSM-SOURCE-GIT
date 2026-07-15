/*******************************************************************************

    System      : MESplus
    Module      : View Packing Label Print
    File Name   : CWIP_packing_label_print.c
    Description : SOI -> MES

    MES Version : 5.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2018.12.31  SW.HWANG

    Copyright(C) 1998-2008 Miracom,Inc.
    All rights reserved.

*******************************************************************************/
#include "CUS_common.h"

int CWIP_VIEW_PACKING_LABEL_PRINT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node);


/*******************************************************************************
    CWIP_View_Packing_Label_Print()
        - View Packing Label Print
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_View_Packing_Label_Print(TRSNode *in_node, TRSNode *out_node)
{
    char s_msg_code[MP_SIZE_MSG];
    int i_ret = MP_TRUE;

    memset(s_msg_code, 0x00, MP_SIZE_MSG);

    i_ret = CWIP_VIEW_PACKING_LABEL_PRINT(s_msg_code, in_node, out_node);

    COM_out_msg_log_write(s_msg_code, "CWIP_View_Packing_Label_Print", out_node);

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
    CWIP_VIEW_PACKING_LABEL_PRINT()
        - View Packing FullCell List
    return Value
        - int : 0 (MP_TRUE)
    Arguments
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure  
*******************************************************************************/
int CWIP_VIEW_PACKING_LABEL_PRINT(char *s_msg_code,
                        TRSNode *in_node, 
                        TRSNode *out_node)
{
	// INIT
	struct CWIPLOTPAK_TAG CWIPLOTPAK;
	struct CWIPLOTPAK_TAG CWIPLOTPAK_H;
	struct MWIPELTSTS_TAG MWIPELTSTS;
	struct MGCMLAGDAT_TAG MGCMLAGDAT;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_V;
	struct MGCMLAGDAT_TAG MGCMLAGDAT_ARTICLE;

	char s_sys_time[14];
	char grade;
	TRSNode *list_item;
	int cwiplotpak_flag = 2;
	int mwipeltsts_flag = 1;
	//int ibakartdef_flag = 2;

	// PROCESS LOG PRINT
	LOG_head("CWIP_VIEW_PACKING_LABEL_PRINT");
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
        return MP_FALSE;
    }

	//horizon packinglist module_id,pallet_id validation check.
	if(TRS.get_procstep(in_node) == '1')
	{    
		CDB_init_cwiplotpak(&CWIPLOTPAK_H);
		memcpy(CWIPLOTPAK_H.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
		TRS.copy(CWIPLOTPAK_H.PALLET_ID, sizeof(CWIPLOTPAK_H.PALLET_ID), in_node, "PALLET_ID");	
		TRS.copy(CWIPLOTPAK_H.LOT_ID, sizeof(CWIPLOTPAK_H.LOT_ID), in_node, "MODULE_ID");	
		if(CDB_select_cwiplotpak_scalar(6, &CWIPLOTPAK_H) < 1){
			strcpy(s_msg_code, "WIP-0613");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPLOTPAK_H.PALLET_ID), CWIPLOTPAK_H.PALLET_ID);	
			TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(CWIPLOTPAK_H.LOT_ID), CWIPLOTPAK_H.LOT_ID);				
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	// INIT
	CDB_init_cwiplotpak(&CWIPLOTPAK);
	memcpy(CWIPLOTPAK.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	TRS.copy(CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID), in_node, "PALLET_ID");		
	CDB_select_cwiplotpak(3, &CWIPLOTPAK);
	if (DB_error_code != DB_SUCCESS)
	{
        TRS.add_dberrmsg(out_node,DB_error_msg);
        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_VIEW;            
        //return MP_FALSE;
	}

	// Get GCM Information
	TRS.add_string(out_node, "PALLET_NO", CWIPLOTPAK.PALLET_ID, sizeof(CWIPLOTPAK.PALLET_ID));	

	CDB_init_mgcmlagdat(&MGCMLAGDAT);
	memcpy(MGCMLAGDAT.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
	if (memcmp(CWIPLOTPAK.CMF_5, "V", 1) == 0) {
		memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
	}else if(memcmp(CWIPLOTPAK.CMF_5, "H", 1) == 0){
		memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING_H", strlen("@PACKING_H"));
	}else {
		memcpy(MGCMLAGDAT.TABLE_NAME, "@PACKING", strlen("@PACKING"));
	}
	memcpy(MGCMLAGDAT.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
	CDB_select_mgcmlagdat(2, &MGCMLAGDAT);
	if (DB_error_code != DB_SUCCESS)
	{
        //TRS.add_dberrmsg(out_node,DB_error_msg);
        //gs_log_type.type = MP_LOG_ERROR;
        //gs_log_type.e_type = MP_LOG_E_SYSTEM;
        //gs_log_type.category = MP_LOG_CATE_VIEW;            
        //return MP_FALSE;
		
		CDB_init_mgcmlagdat(&MGCMLAGDAT_V);
		memcpy(MGCMLAGDAT_V.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
		memcpy(MGCMLAGDAT_V.TABLE_NAME, "@PACKING", strlen("@PACKING"));
		memcpy(MGCMLAGDAT_V.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
		CDB_select_mgcmlagdat(2, &MGCMLAGDAT_V);

		TRS.add_string(out_node, "LENGTH", MGCMLAGDAT_V.DATA_3, sizeof(MGCMLAGDAT_V.DATA_3));      // length
		TRS.add_string(out_node, "BREADTH", MGCMLAGDAT_V.DATA_4, sizeof(MGCMLAGDAT_V.DATA_4));     // breadth
		TRS.add_string(out_node, "HEIGHT", MGCMLAGDAT_V.DATA_5, sizeof(MGCMLAGDAT_V.DATA_5));      // height
		TRS.add_string(out_node, "GROSS_W", MGCMLAGDAT_V.DATA_6, sizeof(MGCMLAGDAT_V.DATA_6));     // gross weight
		TRS.add_string(out_node, "NET_W", MGCMLAGDAT_V.DATA_7, sizeof(MGCMLAGDAT_V.DATA_7));       // net weight
		TRS.add_string(out_node, "TARE_W", MGCMLAGDAT_V.DATA_8, sizeof(MGCMLAGDAT_V.DATA_8));      // tare weight
	}else{
		if (memcmp(MGCMLAGDAT.DATA_3, "0000", 4) == 0) {
			CDB_init_mgcmlagdat(&MGCMLAGDAT_V);
			memcpy(MGCMLAGDAT_V.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
			memcpy(MGCMLAGDAT_V.TABLE_NAME, "@PACKING", strlen("@PACKING"));
			memcpy(MGCMLAGDAT_V.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
			CDB_select_mgcmlagdat(2, &MGCMLAGDAT_V);

			TRS.add_string(out_node, "LENGTH", MGCMLAGDAT_V.DATA_3, sizeof(MGCMLAGDAT_V.DATA_3));      // length
			TRS.add_string(out_node, "BREADTH", MGCMLAGDAT_V.DATA_4, sizeof(MGCMLAGDAT_V.DATA_4));     // breadth
			TRS.add_string(out_node, "HEIGHT", MGCMLAGDAT_V.DATA_5, sizeof(MGCMLAGDAT_V.DATA_5));      // height
			TRS.add_string(out_node, "GROSS_W", MGCMLAGDAT_V.DATA_6, sizeof(MGCMLAGDAT_V.DATA_6));     // gross weight
			TRS.add_string(out_node, "NET_W", MGCMLAGDAT_V.DATA_7, sizeof(MGCMLAGDAT_V.DATA_7));       // net weight
			TRS.add_string(out_node, "TARE_W", MGCMLAGDAT_V.DATA_8, sizeof(MGCMLAGDAT_V.DATA_8));      // tare weight
		}else{
			TRS.add_string(out_node, "LENGTH", MGCMLAGDAT.DATA_3, sizeof(MGCMLAGDAT.DATA_3));      // length
			TRS.add_string(out_node, "BREADTH", MGCMLAGDAT.DATA_4, sizeof(MGCMLAGDAT.DATA_4));     // breadth
			TRS.add_string(out_node, "HEIGHT", MGCMLAGDAT.DATA_5, sizeof(MGCMLAGDAT.DATA_5));      // height
			TRS.add_string(out_node, "GROSS_W", MGCMLAGDAT.DATA_6, sizeof(MGCMLAGDAT.DATA_6));     // gross weight
			TRS.add_string(out_node, "NET_W", MGCMLAGDAT.DATA_7, sizeof(MGCMLAGDAT.DATA_7));       // net weight
			TRS.add_string(out_node, "TARE_W", MGCMLAGDAT.DATA_8, sizeof(MGCMLAGDAT.DATA_8));      // tare weight
		}
	}



	// OPEN
	CDB_open_cwiplotpak(cwiplotpak_flag,&CWIPLOTPAK);
	if(DB_error_code != DB_SUCCESS)
	{
		if(DB_error_code == DB_NOT_FOUND)
		{
			strcpy(s_msg_code, "BOM-0042");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);				
			gs_log_type.e_type = MP_LOG_E_EXISTENCE;
			
			// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
			// ºÒÇÊ¿ä ºÎºÐ ÁÖ¼®Ã³¸®
			//CDB_close_cwiplotpak(cwiplotpak_flag);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
		else
		{
			strcpy(s_msg_code, "BOM-0004");
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK OPEN", MP_NVST);
			TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);
			TRS.add_dberrmsg(out_node,DB_error_msg);
			gs_log_type.type = MP_LOG_ERROR;
			gs_log_type.e_type = MP_LOG_E_SYSTEM;
			gs_log_type.category = MP_LOG_CATE_VIEW;
			
			// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
			// ºÒÇÊ¿ä ºÎºÐ ÁÖ¼®Ã³¸®
			//CDB_close_cwiplotpak(cwiplotpak_flag);

			COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
			return MP_FALSE;
		}
	}

	while(1)
	{
		CDB_fetch_cwiplotpak(cwiplotpak_flag, &CWIPLOTPAK);
		if(DB_error_code == DB_NOT_FOUND)
        {
            CDB_close_cwiplotpak(cwiplotpak_flag);

			// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
			// ºÒÇÊ¿ä ºÎºÐ ÁÖ¼®Ã³¸®
			//COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            break;
        }
        else if(DB_error_code != DB_SUCCESS)
        {
            strcpy(s_msg_code, "BOM-0004");
            //TRS.add_fieldmsg(out_node, "CWIPORDBOM FETCH", MP_NVST);
			// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
			// DB error log edit
			TRS.add_fieldmsg(out_node, "CWIPLOTPAK FETCH", MP_NVST);

            TRS.add_fieldmsg(out_node, "PALLET_ID", MP_STR, sizeof(CWIPLOTPAK.PALLET_ID), CWIPLOTPAK.PALLET_ID);
            TRS.add_dberrmsg(out_node, DB_error_msg);
            gs_log_type.type = MP_LOG_ERROR;
            gs_log_type.e_type = MP_LOG_E_SYSTEM;
            gs_log_type.category = MP_LOG_CATE_SETUP;
            CDB_close_cwiplotpak(cwiplotpak_flag);
            COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
            return MP_FALSE;
        }

		// Get Article Information
		CDB_init_mwipeltsts(&MWIPELTSTS);		
		memcpy(MWIPELTSTS.LOT_ID, CWIPLOTPAK.LOT_ID, sizeof(MWIPELTSTS.LOT_ID));
		CDB_select_mwipeltsts(mwipeltsts_flag,&MWIPELTSTS);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                strcpy(s_msg_code, "WIP-0004");
                TRS.add_fieldmsg(out_node, "MWIPELTSTS SELECT", MP_NVST);
                TRS.add_fieldmsg(out_node, "LOT_ID", MP_STR, sizeof(MWIPELTSTS.LOT_ID), MWIPELTSTS.LOT_ID);
                TRS.add_dberrmsg(out_node,DB_error_msg);
                gs_log_type.type = MP_LOG_ERROR;
                gs_log_type.e_type = MP_LOG_E_SYSTEM;
                gs_log_type.category = MP_LOG_CATE_VIEW;

				// 20210810 MES Application Memory leak Á¡°Ë ¹× ¼öÁ¤
				// DB Close Ãß°¡
				CDB_close_cwiplotpak(cwiplotpak_flag);

                COM_set_result(out_node, MP_FAIL_C, s_msg_code, MP_MSG_CATE_ERROR, TRS.get_language(in_node));
                return MP_FALSE;
            }
        }
		
		// Get Power Class Information
		CDB_init_mgcmlagdat(&MGCMLAGDAT_ARTICLE);
		memcpy(MGCMLAGDAT_ARTICLE.FACTORY, HQCEL_M1_DEFAULT_FACTORY, strlen(HQCEL_M1_DEFAULT_FACTORY));	
		memcpy(MGCMLAGDAT_ARTICLE.TABLE_NAME, "@ARTICLE", strlen("@ARTICLE"));
		memcpy(MGCMLAGDAT_ARTICLE.KEY_1, CWIPLOTPAK.MAT_ID, sizeof(CWIPLOTPAK.MAT_ID));
		memcpy(MGCMLAGDAT_ARTICLE.KEY_2, MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO));
		CDB_select_mgcmlagdat(6, &MGCMLAGDAT_ARTICLE);
		if(DB_error_code != DB_SUCCESS)
        {
            if(DB_error_code != DB_NOT_FOUND)
            {
                TRS.add_dberrmsg(out_node,DB_error_msg);
				gs_log_type.type = MP_LOG_ERROR;
				gs_log_type.e_type = MP_LOG_E_SYSTEM;
				gs_log_type.category = MP_LOG_CATE_VIEW;
                //return MP_FALSE;
            }
        }

		if (memcmp(CWIPLOTPAK.GRADE, "G01", 3) == 0) {
			grade = 'A';
		}
		if (memcmp(CWIPLOTPAK.GRADE, "G02", 3) == 0) {
			grade = 'A';
		}
		if (memcmp(CWIPLOTPAK.GRADE, "G03", 3) == 0) {		//--[G03/G04 로직 추가]
			grade = 'A';
		}

		if (memcmp(CWIPLOTPAK.GRADE, "G04", 3) == 0) {		//--[G03/G04 로직 추가]
			grade = 'A';
		}
		if (memcmp(CWIPLOTPAK.GRADE, "G06", 3) == 0) {
			grade = 'Z';
		}

		if (memcmp(CWIPLOTPAK.GRADE, "B", 1) == 0) {
			grade = 'B';
		}
		
		if (memcmp(CWIPLOTPAK.GRADE, "C", 1) == 0) {
			grade = 'C';
		}

		list_item = TRS.add_node(out_node, "VIEW_OUT");
		TRS.add_int(list_item, "SEQ", CWIPLOTPAK.PAK_SEQ);
		TRS.add_string(list_item, "ARTICLE_NO", MWIPELTSTS.ARTICLE_NO, sizeof(MWIPELTSTS.ARTICLE_NO));
		TRS.add_string(list_item, "BATCH_NO", MWIPELTSTS.COLOR_CLASS, sizeof(MWIPELTSTS.COLOR_CLASS));
		//TRS.add_string(list_item, "POWER_CLASS", CWIPLOTPAK.CMF_2, sizeof(CWIPLOTPAK.CMF_2));
		TRS.add_string(list_item, "POWER_CLASS", MGCMLAGDAT_ARTICLE.DATA_5, sizeof(MGCMLAGDAT_ARTICLE.DATA_5));

		TRS.add_char(list_item, "GRADE", grade);
		TRS.add_string(list_item, "MODULE_ID", CWIPLOTPAK.LOT_ID, sizeof(CWIPLOTPAK.LOT_ID));
	}

	COM_set_result(out_node, MP_SUCCESS_C, "CMN-0000", MP_MSG_CATE_SUCCESS, TRS.get_language(in_node));
	return MP_TRUE;
}