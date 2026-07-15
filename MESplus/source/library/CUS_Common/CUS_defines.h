
/*******************************************************************************

    System      : MESplus
    Module      : CUS
    File Name   : CUS_defines.h
    Description : constant definitions of CUS library

    MES Version : 5.3.7

    Function List
        - 

    Detail Description
    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
  1     2018/11/27  Juhyeon.Jung       Create        

    Copyright(C) 1998-2018 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#ifndef _CUS_DEFINES_H
#define _CUS_DEFINES_H 
  

/*
** Variable Definitions
*/

/**************************************/
/* variable for Summary */
/**************************************/
char    gsShiftStartTime[5][4];
char    gsShiftDayFlag[4];
double gd_work_date_start_time;

struct worktime_tag {
    int work_year;
    int work_month;
    int work_week;
    int work_days;
    int work_shift;
    int work_day_of_week;
    char work_date[8];
    int last_shift;
	char work_date_time[14];
	char work_shift_end_time[14];
	char work_shift_start_time[14];
	char work_date_end_time[14];
	char work_date_start_time[14];
};


extern int CCOM_get_factory_shift(char *factory);
extern int CCOM_get_factory_erp_shift(char *factory);
extern int CCOM_get_work_time(char *last_work_time, struct worktime_tag *work_time);
extern int CCOM_get_work_erp_time(char *last_work_time, struct worktime_tag *work_time);
extern void CCOM_copy_in_node(TRSNode *in_node, TRSNode *target_node);
extern void CCOM_get_work_date(char *s_tran_time,char *s_work_date);

/* DEFINE PROTOTYPE */
extern int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ORDER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CINF_UPLOAD_ERP_FUNCTION(char *s_msg_code,TRSNode *in_node, TRSNode *out_node );
extern int CINF_UPLOAD_ERP_FUNCTION_GERP(char *s_msg_code,TRSNode *in_node, TRSNode *out_node );
extern int CWIP_PACKING_HALFCELL(char *s_msg_code,TRSNode *in_node, TRSNode *out_node);
extern int CWIP_LAYUP_START_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_LAYUP_END_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_CLEAVING_START_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_CLEAVING_END_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_TABBER_START_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_TABBER_END_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

extern int CSUM_SUMMARY_RESOURCE_SHIFTCHANGE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-06-038

/*
** Constant Definitions
*/


#define LOG_SAVE_STEP   '1' // 1: save all log, 2: save only error log

/*************************************************************************************************/
/* GCM TABLE NAME                                                                                */
/*********************************************************123456789012345678901234567890**********/
#define HQCEL_M1_GCM_LINE_CODE                          ("@LINE_CODE          ")    /* Line Code */
#define HQCEL_M1_GCM_CIM_CONTROL_MODE                   ("@CIM_CONTROL_MODE   ")    /* CIM Control Mode */
#define HQCEL_M1_GCM_CELL_LOCATION_CONV                 ("@CELL_LOCATION_CONV ")    /* Cell Location Conversion */
#define HQCEL_M1_GCM_INSP_ITEM                          ("@INSP_ITEM          ")    /* Inspection Item */
#define HQCEL_M1_GCM_POWER_RANGE                        ("@POWER_RANGE        ")    /* Power Range */
#define HQCEL_M1_GCM_ARTICLE                            ("@ARTICLE            ")    /* ARTICLE */
#define HQCEL_M1_GCM_ARTICLE_DESC                       ("@ARTICLE_DSEC    ")	    /* ARTICLE_DESC ADD 23.05.03 */
#define HQCEL_M1_GCM_TERMINATE_CAUSE                    ("@TERMINATE_CAUSE    ")	/* Terminate Cause */
#define HQCEL_M1_GCM_PAKCING_POWER_CLASS                ("@PACKING_POWER_CLASS")	    /* PAKCING_POWER_CLASS ADD 23.05.16 */
#define HQCEL_M1_GCM_PACKING_TYPE                       ("@PACKING_TYPE       ")	    /* PACKING_TYPE ADD 23.05.16 */
#define HQCEL_M1_GCM_SAPTOMES_OPER                      ("@OPER_SAPTOMES      ")	    /* SAP TO MES OPER ADD 23.06.07 */
//#define HQCEL_M1_GCM_EQ_STATUS                          ("@EQ_STATUS            ")	/* EQ STATUS */ // Server Crash 190925
#define HQCEL_M1_GCM_EQ_STATUS                          ("@EQ_STATUS          ")	/* EQ STATUS */ 
#define HQCEL_M1_GCM_EQ_TROUBLE                         ("@EQ_TROUBLE    ")			/* EQ_TROUBLE */
#define HQCEL_M1_GCM_PATROL_CHECK                       ("@PATROL_CHECK    ")		/* EQ_TROUBLE */
#define HQCEL_M1_GCM_4M_KIND                            ("@4M_KIND    ")			/* 4M_KIND */
#define HQCEL_M1_GCM_4M_ISSUE                           ("@4M_ISSUE           ")			/* 4M_ISSUE */
#define HQCEL_M1_GCM_4M_MACHINE                         ("@4M_MACHINE         ")			/* 4M_MACHINE */
#define HQCEL_M1_GCM_4M_MACHINE_DTL                     ("@4M_MACHINE_DTL     ")			/* 4M_MACHINE_DTL */
#define HQCEL_M1_GCM_4M_PERSON                          ("@4M_PERSON          ")			/* 4M_PERSON */
#define HQCEL_M1_GCM_SHIFT	                            ("@SHIFT")	/* SHIFT */
#define HQCEL_M1_GCM_SL_MAPPING_PRV	                    ("@SL_MAPPING_PRV")	         /* @SL_MAPPING_PRV */
#define HQCEL_M1_GCM_TR_RES_PORT	                    ("@TR_RES_PORT")	         /* @TR_RES_PORT */          
/*************************************************************************************************/
/* MMS GCM TABLE NAME -- 2023.03.08 yk.Yoo Create                                                                                */
/*****************************************************123456789012345678901234567890**************/
#define HQCEL_GCM_MMS_ITEM_GROUP                    ("MMS_ITEM_GROUP      ")    /* Item Group */
#define HQCEL_GCM_MMS_SAMPLE_GROUP					("MMS_SAMPLE_GROUP    ")    /* Sample Group */
#define HQCEL_GCM_MMS_USE_GROUP						("MMS_USE_GROUP       ")    /* User Group */
#define HQCEL_GCM_MMS_MGR_GROUP						("MMS_MGR_GROUP       ")    /* Manager Group */
#define HQCEL_GCM_MMS_CALI_INSTITUTE				("MMS_CALI_INSTITUTE  ")    /* 교정 기관 */
#define HQCEL_GCM_MMS_CALI_DIV						("MMS_CALI_DIV        ")    /* 교정 기관 */
#define HQCEL_GCM_MMS_TOOL							("MMS_TOOL            ")    /* 표준장비 */
#define HQCEL_GCM_MMS_ALARM_CODE					("MMS_ALARM_CODE      ")    /* 알람 */
#define HQCEL_GCM_MMS_DEPT_CODE						("MMS_DEPT_CODE       ")    /* 부서정보 */
#define HQCEL_GCM_MMS_PLACE_CODE					("MMS_PLACE_CODE      ")    /* 설치장소 */
#define HQCEL_GCM_MMS_USE_DIV   					("MMS_USE_DIV         ")    /* 사용구분(0:사용, 1:고장, 2:폐각) */
#define HQCEL_GCM_MMS_ANA_MOTHOD					("MMS_ANALYSIS_METHOD ")    /* 측정 (분석)계획 구분 */
#define HQCEL_GCM_MMS_ANA_STATUS					("MMS_ANALYSIS_STATUS ")    /* 측정 (분석)계획 상태 */
#define HQCEL_GCM_MMS_EQUIP_TYPE					("MMS_EQUIP_TYPE      ")    /* 측정기 종류 */
#define HQCEL_GCM_MMS_RESULT_TYPE					("MMS_RESULT_TYPE     ")    /* 결과 TYPE */
#define HQCEL_GCM_MMS_UNIT					        ("MMS_UNIT            ")    /* UNIT */
#define HQCEL_GCM_MMS_CONST_CODE   					("MMS_CONST_CODE      ")    /* 분설 결과 계산 상수값 */
/*************************************************************************************************/
/* AUDIT GCM TABLE NAME -- 2023.05.26 yk.Yoo Create                                                                                */
/*****************************************************123456789012345678901234567890**************/
#define HQCEL_GCM_AMS_CUSTOMER                      ("AMS_CUSTOMER        ")    /* Customer List */
#define HQCEL_GCM_AMS_AUDIT_STATUS					("AMS_AUDIT_STATUS    ")    /* Status */
#define HQCEL_GCM_AMS_ITEM_DIV						("AMS_ITEM_DIV        ")    /* Item Division */
/**************************************/
/* FACTORY(2023.12.28 kim han chang ) */
/**************************************/
#define HQCEL_M1_EAGLE_01                             ("E1")
#define HQCEL_M1_EAGLE_02                             ("E2")
/**************************************/
/* LINE                               */
/**************************************/
#define HQCEL_M1_LINE_CVL01                             ("CVL01")
#define HQCEL_M1_LINE_MDL01                             ("MDL01")
#define HQCEL_M1_LINE_MDL02                             ("MDL02")
#define HQCEL_M1_LINE_MDL03                             ("MDL03")


/**************************************/
/* MODULE NAME                        */
/**************************************/
#define MODULE_EAP                                      ("MESEAP")
#define MODULE_CLI                                      ("MESCLI")

#define HQCEL_M1_DEFAULT_FACTORY						("USGAM1")
#define HQCEL_M1_DEFAULT_USERID                         ("ADMIN")

/**************************************/
/* FLOW                               */
/**************************************/
#define HQCEL_M1_FLOW_MDP100							("MDP100")
#define HQCEL_M1_FLOW_CVP100							("CVP100")
#define HQCEL_M1_FLOW_CEL100							("CEL100")
#define HQCEL_M1_FLOW_BMP100							("BMP100") // Module ( ZBOM ) -- 2023-01-17 ZBOM FLOWCODE
/**************************************/
/* OPERATION                          */
/**************************************/

#define HQCEL_M1_RAWMAT_STOCK_OPER                      ("M0010")
#define HQCEL_M1_FCELL_MOVE_OPER                        ("M0050")
#define HQCEL_M1_CLEAVING_OPER                          ("M1000")
#define HQCEL_M1_TABBER_OPER                            ("M2000")

#define HQCEL_M1_LAYUP_OPER                             ("M2010")
#define HQCEL_M1_SOLDER_OPER                            ("M2020")
#define HQCEL_M1_FEEDING_OPER                           ("M2030")
#define HQCEL_M1_FRONTEND_EL_OPER                       ("M2040")
#define HQCEL_M1_G2G_OPER							    ("M2050")

#define HQCEL_M1_LAMI_OPER								("M3000")
#define HQCEL_M1_TRIMMING_OPER							("M3010")
#define HQCEL_M1_AOI_OPER								("M3020")
#define HQCEL_M1_ATTCH_JBX_OPER							("M3030")
#define HQCEL_M1_ASSEMBLY_FRAME_OPER					("M3040")

#define HQCEL_M1_SIMULATOR_OPER							("M3050")
#define HQCEL_M1_HIPOT_OPER					            ("M3060")
#define HQCEL_M1_BACKEND_EL_OPER                        ("M3070")
#define HQCEL_M1_POTTING_OPER	                        ("M3080")
#define HQCEL_M1_CURING_OPER	                        ("M3090")
#define HQCEL_M1_GROUND_TEST_OPER                       ("M3100")
#define HQCEL_M1_FQC_OPER								("M3110")
#define HQCEL_M1_PACKING_OPER							("M3120")

#define HQCEL_M1_FGS_OPER								("M4000")

#define HQCEL_M1_PRODUCT_OPER							("M4010")
#define HQCEL_M1_PROCESS_OPER							("M4020")
#define HQCEL_M1_OQC_OPER								("M4030")
#define HQCEL_M1_OQC_OPER_E2							("M4230")
#define HQCEL_M1_REWORK_OPER							("M4040")
#define HQCEL_M1_REWORK_OPER_E2							("M4240")

#define HQCEL_M1_UNPACK_OPER							("M4050")
#define HQCEL_M1_UNPACK_OPER_E2							("M4250")
#define HQCEL_M1_EHS_OPER							    ("M4060")
/**************************************/
/* RESOURCE                           */
/**************************************/
#define HQCEL_M1_RES_LINE1_FRONTEND_EL1                 ("US-E1-FEL-01")
#define HQCEL_M1_RES_LINE2_FRONTEND_EL1					("US-E2-FEL-01")
#define HQCEL_M1_RES_LINE3_FRONTEND_EL1					("US-E3-FEL-01")
#define HQCEL_M1_RES_LINE1_SIMULATOR1					("US-E1-SIM-01")
#define HQCEL_M1_RES_LINE2_SIMULATOR1					("US-E2-SIM-01")
#define HQCEL_M1_RES_LINE3_SIMULATOR1					("US-E3-SIM-01")
#define HQCEL_M1_RES_LINE1_FQC1					        ("US-E1-FQC-01")
#define HQCEL_M1_RES_LINE1_FQC2					        ("US-E1-FQC-02")
#define HQCEL_M1_RES_LINE2_FQC1					        ("US-E2-FQC-01")
#define HQCEL_M1_RES_LINE2_FQC2					        ("US-E2-FQC-02")
#define HQCEL_M1_RES_LINE3_FQC1					        ("US-E3-FQC-01")
#define HQCEL_M1_RES_LINE3_FQC2					        ("US-E3-FQC-02")

#define HQCEL_M1_RES_LINE1_LCV21					    ("US-E1-LCV-21")
#define HQCEL_M1_RES_LINE2_LCV21					    ("US-E2-LCV-21")
#define HQCEL_M1_RES_LINE3_LCV21					    ("US-E3-LCV-21")
#define HQCEL_M1_RES_LINE1_LCV23					    ("US-E1-LCV-23")
#define HQCEL_M1_RES_LINE2_LCV23					    ("US-E2-LCV-23")
#define HQCEL_M1_RES_LINE3_LCV23					    ("US-E3-LCV-23")


/* ERP CONSTANT VALUE */
#define HQCEL_M1_ERP_SITE_ID                            ("3001")
#define HQCEL_FCEL_FROM_LOC_ID                          ("T04")
#define HQCEL_FCEL_TO_LOC_ID                            ("T02")
#define HQCEL_HCEL_FROM_LOC_ID                          ("T03")
#define HQCEL_HCEL_TO_LOC_ID                            ("H21")

#define HQCEL_M1_ERP_SITE_ID_V2                          ("P300")
#define HQCEL_FCEL_FROM_LOC_ID_V2                        ("PRT4")
#define HQCEL_FCEL_TO_LOC_ID_V2                          ("PRT2")
#define HQCEL_HCEL_FROM_LOC_ID_V2                        ("PRT3")
#define HQCEL_HCEL_TO_LOC_ID_V2                          ("PRN1")

#define HQCEL_HCEL_ERP_INIT_FLAG                        ('I')


/* LOT CREATION TYPE CODE */
#define HQCEL_LOT_CREATECODE_MODULE                     ("MODULE")  //MODULE
#define HQCEL_LOT_CREATECODE_STRING                     ("STRING")  //STRING
#define HQCEL_LOT_CREATECODE_FCELBX                     ("FCELBX")  //FULL CELL
#define HQCEL_LOT_CREATECODE_HCELBX                     ("HCELBX")  //HALF CELL
#define HQCEL_LOT_CREATECODE_CELMAT                     ("MATLOT")  //MATERIAL

/* CATEGORY LOSS OR INSPECTION */
#define HQCEL_LOSS_CATEGORY_CLEAVING					("CL") //CLEAVING
#define HQCEL_LOSS_CATEGORY_TABBER						("TA") //TABBER
#define HQCEL_LOSS_CATEGORY_EL1							("E1") //FRONTEND EL
#define HQCEL_LOSS_CATEGORY_EL2							("E2") //BACKEND EL
#define HQCEL_INS_TYPE_CATEGORY_EL1                     ("E1") //EL1
#define HQCEL_INS_TYPE_CATEGORY_EL2                     ("E2") //EL2
#define HQCEL_INS_TYPE_CATEGORY_FQC                     ("FC") //FQC
#define HQCEL_INS_TYPE_CATEGORY_SIMULATOR               ("SI") //SIMULATOR
#define HQCEL_INS_TYPE_CATEGORY_HIPOT                   ("HI") //HIPOT
#define HQCEL_INS_TYPE_CATEGORY_GROUND                  ("GR") //GROUND
#define HQCEL_INS_TYPE_CATEGORY_ET                      ("ET") //ETC
#define HQCEL_INS_TYPE_CATEGORY_BUSBAR1                 ("B1") //BUSBAR 1
#define HQCEL_INS_TYPE_CATEGORY_BUSBAR2                 ("B2") //BUSBAR 2
#define HQCEL_INS_TYPE_CATEGORY_SUALAB1                  ("S1") //SUALAB 1
#define HQCEL_INS_TYPE_CATEGORY_SUALAB2                  ("S2") //SUALAB 2
#define HQCEL_INS_TYPE_CATEGORY_SUALAB                  ("SU") //SUALAB

#define HQCEL_RES_CATEGORY_REPAIR_EL                    ("REPAIR-EL") // REPAIR EL 구분

/* POWER GRADE */
#define HQCEL_M1_POWER_GRADE_G01				        ("G01") //G01
#define HQCEL_M1_POWER_GRADE_G02				        ("G02") //G02
#define HQCEL_M1_POWER_GRADE_G03				        ("G03") //G03
#define HQCEL_M1_POWER_GRADE_G04				        ("G04") //G04
#define HQCEL_M1_POWER_GRADE_G06				        ("G06") //G06
#define HQCEL_M1_POWER_GRADE_G05				        ("G05") //G05
#define HQCEL_M1_POWER_GRADE_B				            ("B")   //B
#define HQCEL_M1_POWER_GRADE_C				            ("C")   //C
#define HQCEL_M1_POWER_GRADE_X				            ("X")   //X
#define HQCEL_M1_POWER_GRADE_RW				            ("RW")  //[GERP PROJECT][ERP 23.05.23]RW 
/* EVENT  */
#define HQCEL_M1_EVENT_LD_CART_IN						("LD_CARTIN")	//LOAD PORT DOCK IN CART
#define HQCEL_M1_EVENT_LD_CART_OUT						("LD_CARTOUT")	//LOAD PORT DOCK OUT CART
#define HQCEL_M1_EVENT_ULD_CART_IN						("ULD_CARTIN")	//UNLOAD PORT DOCK IN CART
#define HQCEL_M1_EVENT_ULD_CART_OUT						("ULD_CARTOUT")	//UNLOAD PORT DOCK OUT CART
#define HQCEL_M1_EVENT_EQ_CHGSTATUS						("CHGSTATUS")	//CHGSTATUS
#define HQCEL_M1_EVENT_EQ_CHGMODE						("CHGMODE")		//CHGMODE


/* LABEL TYPE */
#define HQCEL_M1_LABEL_TYPE_MODULEID					("MODULE")  //MODULE
#define HQCEL_M1_LABEL_TYPE_POWER   					("POWER")   //POWER
#define HQCEL_M1_LABEL_TYPE_LOT			        		("LOT")     //LOT
#define HQCEL_M1_LABEL_TYPE_BACKSHEET			        ("BACKSHEET") //BACKSHEET

#define ONE_YEAR										(31104000)	// 360ÀÏ ±âÁØ 1³â ÃÊ
#define ONE_MONTH										(2592000)	// 30ÀÏ ±âÁØ 1´Þ ÃÊ
#define ONE_DAY											(86400)		// 1ÀÏ ±âÁØ 24½Ã°£ ÃÊ
#define ONE_HOUR										(3600)		// 1½Ã°£ ±âÁØ ÃÊ
#define ONE_MINUTE										(60)		// 1ºÐ ±âÁØ ÃÊ 


/* TRAY STATUS */
#define HQCEL_M1_TRAY_STATUS_START            ("S")    //Start Repair
#define HQCEL_M1_TRAY_STATUS_END			  ("E")    //End Repair
#define HQCEL_M1_TRAY_STATUS_INPUT            ("I")    //Input to Equipment


/* CUSTOM LOT TRAN_CODE*/
#define HQCEL_LOT_TRAN_MOVE_STORE                       ("MOVE       ")
#define HQCEL_LOT_TRAN_CHANGE                           ("CHANGE     ")

#endif  /* _CUS_DEFINES_H */

/* Release Code */
/*****************************************************123456789012345678901234567890**************/
#define HQCEL_RELEASE_ABN_MOVE			            ("ABN_MOVE  ")
#define HQCEL_RELEASE_REQ_REJECT                    ("REQ_REJECT")
#define HQCEL_RELEASE_REQ_MOVE                      ("REQ_MOVE  ")
#define HQCEL_RELEASE_REQ_CANCEL                    ("REQ_CANCEL")
#define HQCEL_HOLD_REQ_MOVE                         ("REQ_MOVE  ")
/* HOLD Code */
/*****************************************************123456789012345678901234567890**************/
#define HQCEL_HOLD_REQ_MOVE                      ("REQ_MOVE  ")

/* CUSTOM STATUS */
#define HQCEL_FLAG_YES					('Y')
#define HQCEL_FLAG_NO					('N')
#define HQCEL_FLAG_NONE					(' ')

/*REQ STATUS*/
#define HQCEL_M1_REQ_STATUS_C                        ("CLOSE    ")
#define HQCEL_M1_REQ_STATUS_R                        ("REQUEST  ")
#define HQCEL_M1_REQ_STATUS_CL                       ("CANCEL   ")
#define HQCEL_M1_REQ_STATUS_RJ                       ("REJECT   ")

/* TELEGRAM GCM CODE */
#define HQCEL_TEL_QCELL_PACKING               ("QCELL_PACKING") // Telegram Packing 시 창고가 다른 모듈일경우 TELEGRAM

/* ABN Log CODE */
#define HQCEL_ABN_NOT_POWER     ("ABN_NOT_POWER") // POWER_RANGE가 없음

/* TELEGRAM Send */
#define HQCEL_TEL_ORCRECO ("OCR||RECO")
#define HQCEL_TEL_OVER50 ("OVER50")

/*MCS JOB STATUS*/
#define HQCEL_M1_MCS_JOB_STATUS_REQ                  ("REQ      ")
#define HQCEL_M1_MCS_JOB_STATUS_SEND                 ("SEND     ")
#define HQCEL_M1_MCS_JOB_STATUS_REPLY                ("REPLY    ")
#define HQCEL_M1_MCS_JOB_STATUS_CREATE               ("CREATE   ")
#define HQCEL_M1_MCS_JOB_STATUS_START                ("START    ")
#define HQCEL_M1_MCS_JOB_STATUS_LOCATE               ("LOCATE   ")
#define HQCEL_M1_MCS_JOB_STATUS_END                  ("END      ")
#define HQCEL_M1_MCS_JOB_STATUS_TERM                 ("TERM     ")
#define HQCEL_M1_MCS_JOB_STATUS_ALTER                ("ALTER    ")
#define HQCEL_M1_MCS_JOB_STATUS_PAUSE                ("PAUSE    ")
#define HQCEL_M1_MCS_JOB_STATUS_RESUME               ("RESUME   ")
#define HQCEL_M1_MCS_JOB_STATUS_CANCEL               ("CANCEL   ")


/* CUSTOM STATUS */
#define HQCEL_M1_MCS_JOB_SUCCESS                     ("S")
#define HQCEL_M1_MCS_JOB_FAIL                        ("F")


/* CUSTOM STATUS */
#define HQCEL_M1_MCS_REQ_TYPE_MATERIAL               ("MAT")
#define HQCEL_M1_MCS_REQ_TYPE_CARRIER                ("CRR")


/* MCS REQUEST SYSTEM */
#define HQCEL_M1_MCS_REQ_SYSTEM_MCS                  ("MCS")
#define HQCEL_M1_MCS_REQ_SYSTEM_MES                  ("MES")