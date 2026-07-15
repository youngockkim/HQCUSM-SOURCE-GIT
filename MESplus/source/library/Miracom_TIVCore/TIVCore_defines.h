/*******************************************************************************

    System      : MESplus
    Module      : MESCore
    File Name   : MESCore_defines.h
    Description : Common Macro definition of MESplus Server

    MES Version : 4.0.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2004/12/16  SK Jin         Create

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#ifndef _TIVCORE_DEFINES_H
#define _TIVCORE_DEFINES_H

#include <TRSCore_common.h>

/****************************************************/
/* System Constant                                  */
/****************************************************/

/* Central Factory */
#define MP_ATTR_TIV_LOT_GROUP ("LotGroup")
#define MP_ATTR_TIV_OPER_TYPE ("OperationType")
#define MP_ATTR_TIV_OPER_IQC ("IQC")
#define MP_ATTR_TIV_OPER_WH ("WH")
#define MP_ATTR_TIV_OPER_WIPWH ("WIPWH")
#define MP_ATTR_TIV_OPER_WIP ("WIP")

#define MP_ATTR_TYPE_INV_LOT ("INV_LOT")
#define MP_ATTR_NAME_CUSTOMER_MAT_ID ("CUSTOMER_MAT_ID")
#define MP_ATTR_NAME_CUSTOMER_ID ("CUSTOMER_ID")
#define MP_ATTR_NAME_USE_FACTORY  ("USE_FACTORY")
#define MP_TIV_MATERIAL_TYPE ("INV_MATERIAL_TYPE")


/**********************************************************/
/* INV Transaction Code                                   */
/**********************************************************/
#define MP_TIV_TRAN_CODE_IN             ("IN          ")
#define MP_TIV_TRAN_CODE_OUT            ("OUT         ")
#define MP_TIV_TRAN_CODE_TRANSFER       ("TRANSFER    ")
#define MP_TIV_TRAN_CODE_INSPECTION     ("INSPECTION  ")
#define MP_TIV_TRAN_CODE_IQC            ("IQC         ")
#define MP_TIV_TRAN_CODE_ASSY           ("ASSY        ")
#define MP_TIV_TRAN_CODE_DISASSY        ("DISASSY     ")
#define MP_TIV_TRAN_CODE_HOLD           ("HOLD        ")
#define MP_TIV_TRAN_CODE_RELEASE        ("RELEASE     ")
#define MP_TIV_TRAN_CODE_SPLIT          ("SPLIT       ")
#define MP_TIV_TRAN_CODE_LOSS           ("LOSS        ")
#define MP_TIV_TRAN_CODE_DEFECT         ("DEFECT      ")
#define MP_TIV_TRAN_CODE_ADAPT          ("ADAPT       ")
#define MP_TIV_TRAN_CODE_MERGE          ("MERGE       ")
#define MP_TIV_TRAN_CODE_EDC            ("EDC         ")
#define MP_TIV_TRAN_CODE_ETC_IN         ("ETC_IN      ")
#define MP_TIV_TRAN_CODE_CV             ("CV          ")
#define MP_TIV_TRAN_CODE_CONSUME        ("CONSUME     ") 
#define MP_TIV_TRAN_CODE_DECONSUME      ("DECONSUME   ")  
#define MP_TIV_TRAN_CODE_SHIP   		("SHIP        ")

#define MP_TIV_TRAN_TYPE_LS_SCRAP		    ("LS_SCRAP  ")
#define MP_TIV_TRAN_TYPE_LS_CLAIM		    ("LS_CLAIM  ")
#define MP_TIV_TRAN_TYPE_LS_MRG		        ("LS_MRG    ")
#define MP_TIV_TRAN_TYPE_LS_REWORK		    ("LS_REWORK ")
#define MP_TIV_TRAN_TYPE_LS_GOOD		    ("LS_GOOD   ")
#define MP_TIV_TRAN_TYPE_LS_GD_MRG		    ("LS_GD_MRG ")
#define MP_TIV_TRAN_TYPE_DLLH				("DLLH")
#define MP_TIV_TRAN_TYPE_MV_LOSS		    ("MV_LOSS   ")

#define MP_TIV_TRAN_TYPE_RW_SCRAP		    ("RW_SCRAP  ")
#define MP_TIV_TRAN_TYPE_RW_MRG		        ("RW_MRG    ")
#define MP_TIV_TRAN_TYPE_RW_GOOD		    ("RW_GOOD   ")
#define MP_TIV_TRAN_TYPE_RW_REVIVE		    ("RW_REVIVE ")
#define MP_TIV_TRAN_TYPE_RW_GD_MRG		    ("RW_GD_MRG ")

#define MP_TIV_TRAN_TYPE_MAT_CHG		    ("MAT_CHG   ")
 
#define MP_TIV_DOC_TYPE_BY_MATERIAL         ('M')           //품목 단위 요청
#define MP_TIV_DOC_TYPE_BY_LOT         ('L')          //LOT 단위 요청 

//#define MP_GEN_ID_TRS_NO_TRANSFER         ("InvTransferReqNo")  
//#define MP_GEN_ID_TRS_NO_RETURN         ("InvReturnReqNo")  
#define MP_GCM_TBL_INV_CV_CODE      ("C@INV_CV_CODE") 
#define MP_GCM_TBL_INV_HOLD_CODE    ("C@INV_HOLD_CODE") 
#define MP_GCM_TBL_INV_RELEASE_CODE    ("C@INV_RELEASE_CODE") 
#define MP_GCM_TBL_INV_LOCATION    ("C@INV_LOCATION") 
#define MP_GCM_TBL_CUSTOMER_CODE_LAG    ("C@CUSTOMER_CODE_LAG ") 

#define MP_GCM_TBL_MAT_VALID_MONTH        ("C@MAT_VALID_MONTH") 
#define MP_GCM_MAT_VALID_GROUP_EXP_DATE			  ("EXP_DATE") 

#define MP_ATTR_KEY_VALID_MONTH_SM        ("VALID_MONTH_SM") 
#define MP_ATTR_KEY_VALID_MONTH_WT        ("VALID_MONTH_WT") 

#define MP_INV_CV_CODE_PROC_AUTO      ("PROC_AUTO") 
#define MP_INV_TRAN_TYPE_RJT_TRN      ("RJT_TRN") 


#define MP_TIV_TRS_ASSIGN_TYPE_PREASSN ('P')
#define MP_TIV_TRS_ASSIGN_TYPE_TRANSFER ('T')

#define MP_GLOBAL_OPT_ONLY_ONE_LIVE_INV_LOT ("MP_OnlyOneLiveINVLot          ");

#define MP_TIV_SHIP_TYPE_INTERNAL         ('I')   
#define MP_TIV_SHIP_TYPE_CUSTOMER         ('C')   
#define MP_TIV_CUSTOMER_FACTORY         ("CUSTOMER")   

#define MP_TIV_INSP_FLAG_OQC         ('O')  
#define MP_TIV_INSP_FLAG_QC         ('Q')  
#define MP_TIV_INSP_RESULT_FAIL         ('F')  
#define MP_TIV_INSP_RESULT_PASS         ('P')   
 
#define MP_TIV_LOT_TYPE_PROD         ('P')   
#define MP_TIV_LOT_TYPE_ADJUST         ('A')   

#define MP_TIV_CV_CODE_MV_ADJ          ("MV_ADJ")   
#define MP_TIV_LOSS_CODE_MV_LOSS           ("MV_LOSS") 

#define MP_TIV_OPER_LOSS_P900           ("P900") 

#define MP_TIV_OPER_CMF_2_OSC		    ("OSC                           ")

#define MP_TIV_ERP_MVT_309 ("309")     /* 자재품번변경 */
#define MP_TIV_ERP_MVT_311 ("311")     /* 창고간 이동 */
#define MP_TIV_ERP_MVT_541 ("541")     /* GI창고 -> 외주창고 */
#define MP_TIV_ERP_MVT_542 ("542")     /* 외주창고 -> DTR창고 */ 






//from DTR

#define MP_WIP_CUSTOMER_FACTORY			("CUSTOMER  ")
#define MP_GCM_MATERIAL_MODEL		("C@MATERIAL_MODEL    ")
#define MP_GCM_SHIP_TO				("C@SHIP_TO    ")
#define MP_GCM_FEEDER_FILE_TYPE		("C@FEEDER_FILE_TYPE  ")
#define MP_GCM_LABEL_TYPE			("C@LABEL_TYPE        ")
//#define MP_GCM_GROUP_LOT_PROC      ("C@GROUP_LOT_PROC    ")
#define MP_GCM_GEN_ID_RULE			("C@GEN_ID_RULE       ")
#define MP_GCM_SEQUENCER			("C@SEQUENCER         ")
#define MP_GCM_GEN_ID_RULE			("C@GEN_ID_RULE       ")
#define MP_GCM_IDG_DATE_FORMAT	    ("C@IDG_DATE_FORMAT   ")
#define MP_GCM_FILE_TYPE			("C@FILE_TYPE         ")
#define MP_GCM_SHIFT    			("C@SHIFT             ")
#define MP_GCM_LOSS_CODE	        ("LOSS_CODE           ")
#define MP_GCM_LOSS_TYPE	        ("C@LOSS_TYPE         ")
#define MP_GCM_OPER_GROUP_SHIFT		("C@OPER_GROUP_SHIFT  ")

#define MP_GCM_IQC_TYPE  			("C@IQC_TYPE          ")
#define MP_GCM_INSP_TYPE  			("C@INSP_TYPE         ")
#define MP_GCM_INSP_RESULT  		("C@INSP_RESULT       ")
#define MP_GCM_ERP_MVT_CODE  		("C@ERP_MVT_CODE      ")

#define MP_PROC_GROUP_PROD_01    			("PROD_01")
#define MP_PROC_GROUP_SHIP_01    			("SHIP_01")
#define MP_PROC_GROUP_LOSS_01    			("LOSS_01")

#define MP_GCM_OPER_QC_TYPE    		("C@OPER_QC_TYPE      ")

#define MP_GCM_PLAN_OPER            ("C@PLAN_OPER         ")

#define MP_GCM_SCALE_FACTOR         ("C@SCALE_FACTOR      ")

#define DTR_GCM_TABLE_AREA			("AREA                ")          /* AREA */
#define DTR_GCM_TABLE_SUB_AREA		("SUB_AREA            ")          /* SUB AREA */
#define DTR_GCM_TABLE_RAS_DAT_LIST ("C$RAS_DAT_LIST      ")          /* 설비데이터 기준정보 */
#define DTR_GCM_TABLE_RAS_DOWN_TYPE						 ("C$RAS_DOWN_TYPE     ")		   /* 설비 비가동 유형 */
#define DTR_GCM_TABLE_RAS_DOWN_CODE						 ("C$RAS_DOWN_CODE     ")		   /* 설비 비가동 코드 */
#define DTR_GCM_TABLE_RAS_DOWN_CODE_L                      ("C$RAS_DOWN_CODE_L   ")		   /* 설비 정비 항목(대분류)	*/
#define DTR_GCM_TABLE_RAS_DOWN_CODE_M                      ("C$RAS_DOWN_CODE_M   ")		   /* 설비 정비 항목(중분류)	*/
#define DTR_GCM_TABLE_RAS_DOWN_CODE_S                      ("C$RAS_DOWN_CODE_S   ")		   /* 설비 정비 항목(소분류)	*/
#define DTR_GCM_TABLE_RAS_DOWN_DIVISION                    ("C$RAS_DOWN_DIVISION ")		   /* 설비 가동 분류	*/

#define MP_DTR_LOSS_TYPE_LOSS_OPER_HALF  ("LT01")
#define MP_DTR_LOSS_TYPE_LOSS_OPER_RAW   ("LT02")
#define MP_DTR_LOSS_TYPE_LOSS_OPER_REQ   ("LT03")

#define MP_HOLD_CODE_REPAIR        ("REPAIR")
#define MP_REL_CODE_REPAIR_END     ("REPAIR_END")
#define MP_REL_CODE_NO_REPAIR      ("NO_REPAIR")
#define MP_REL_CODE_SCRAP_REL      ("SCRAP_REL")

#define MP_REPAIR_SCRAP            ("REPAIR_SCRAP")

#define MP_ATTR_LABEL_ID           ("LABEL_ID")
#define MP_ATTR_BARCODE_GEN_ID     ("BARCODE_GEN_ID")
#define MP_ATTR_LOT_GEN_ID         ("LOT_GEN_ID")
#define MP_ATTR_GRP_LOT_FLAG       ("GRP_LOT_FLAG")
#define MP_ATTR_GRP_SPLIT_OPER     ("GRP_SPLIT_OPER")
#define MP_ATTR_GRP_SPLIT_POINT    ("GRP_SPLIT_POINT")

#define MP_ATTR_BOX_LABEL_ID       ("BOX_LABEL_ID")
#define MP_ATTR_BOX_BARCODE_GEN_ID ("BOX_BARCODE_GEN_ID")
#define MP_ATTR_BOX_LOT_GEN_ID     ("BOX_LOT_GEN_ID")

#define MP_ATTR_SECONDARY_BARCODE_GEN_ID    ("SECONDARY_BARCODE_GEN_ID")
#define MP_ATTR_SECONDARY_LABEL_ID			("SECONDARY_LABEL_ID")
#define MP_ATTR_SECONDARY_LABEL_SCAN_FLAG	("SECONDARY_LABEL_SCAN_FLAG")

#define MP_ATTR_MULIT_SHEET_FLAG   ("MULIT_SHEET_FLAG")
#define MP_ATTR_LINE_OR_RES        ("LINE_OR_RES")
#define MP_ATTR_START_ROW_TYPE     ("START_ROW_TYPE")
#define MP_ATTR_START_ROW          ("START_ROW")
#define MP_ATTR_SLOT_COL_TYPE      ("SLOT_COL_TYPE")
#define MP_ATTR_SLOT_COL           ("SLOT_COL")
#define MP_ATTR_SILKPOS_COL_TYPE   ("SILKPOS_COL_TYPE")
#define MP_ATTR_SILKPOS_COL        ("SILKPOS_COL")
#define MP_ATTR_INV_MAT_COL_TYPE   ("INV_MAT_COL_TYPE")
#define MP_ATTR_INV_MAT_COL        ("INV_MAT_COL")
#define MP_ATTR_VENDOR_COL_TYPE    ("VENDOR_COL_TYPE")
#define MP_ATTR_VENDOR_COL         ("VENDOR_COL")

#define MP_LABEL_TYPE_LOT          ("LOT")
#define MP_LABEL_TYPE_BOX          ("BOX")

#define MP_OPER_AGING              ("4010")
#define MP_OPER_ATE                ("4020")

#define MP_GCM_SHOP                ("C@SHOP              ")
#define MP_GCM_ARRARY_LABEL        ("C@ARRARY_LABEL      ")
//#define MP_GCM_VENDOR              ("C@VENDOR_CODE       ")
#define MP_GCM_VENDOR              ("VENDOR_CODE       ")
#define MP_GCM_MATERIAL_TYPE       ("MATERIAL_TYPE       ")
#define MP_GCM_LINE_LABEL          ("C@LINE_LABEL        ")
#define MP_GCM_POPUP_OPER_RES      ("C@POPUP_OPER_RES    ")

#define MP_GCM_REP_RST_GROUP       ("C@REP_RST_GROUP     ")
#define MP_GCM_REP_RST_CODE        ("C@REP_RST_CODE      ")
#define MP_GCM_REPAIR_CODE         ("REPAIR_CODE         ")
#define MP_GCM_LABEL_PRINTER       ("C@LABEL_PRINTER     ")

#define GCM_TERM_CODE_INPUT        ("INPUT               ")

#define ATR_TYPE_PPC_INFO          ("C@PPC_INFO          ")
#define ATR_NAME_OPERS             ("MainOperation       ")
#define ATR_NAME_IPADDR            ("IPAddress           ")

#define MP_CMN_GRP_LOT_ID_01       ("CMN_GRP_LOT_ID_01")
#define MP_GCM_BOM_INPUT_TYPE      ("C@BOM_INPUT_TYPE    ")


#define MP_FLOW_TYPE_QC          ("QC")
#define MP_OPER_TYPE_IQC          ("IQC")
#define MP_OPER_TYPE_QC          ("QC")

#define MP_LOT_REMARK_IQC  			("IQC INSPECTION LOT")
#define MP_LOT_REMARK_QC  			("QC INSPECTION LOT")
#define MP_LOT_REMARK_PR_LOSS_MRG  			("OP MERGE BF REQ LOSS")

#define MP_IQC_RESULT_OK  			("OK")
#define MP_IQC_RESULT_NG  			("NG")
#define MP_IQC_RESULT_SKIP  			("SKIP")

#define MP_INV_OPER_TYPE_RJT      ("RJT")

#define MP_LOT_PROC_AUTO_TERM      ("AUTO_TERM")
#define MP_LOT_TERMINATE_REJECT      ("IQC_RJT")
#define MP_LOT_TERMINATE_IQC_END           ("IQC_END")

#define MP_FILE_GROUP_IQC            ("IQC")

#define MP_MAT_GRP_2_RUB          ("R1030")
#define MP_MAT_GRP_2_STL          ("R2010")
//
///* Setup Related CMF */
//#define MP_CMF_RULE               ("CMF_RULE       ")
#define MP_CMF_LINE               ("CMF_LINE       ")
//#define MP_CMF_SHOP               ("CMF_SHOP       ")
//
///* Group Definition related CMF */
//#define MP_GRP_RULE               ("GRP_RULE       ")
#define MP_GRP_LINE               ("GRP_LINE       ")
//#define MP_GRP_SHOP               ("GRP_SHOP       ")
//
///*Rule Group Table 1~10 */
//#define MP_GCM_RULE_GRP_1         ("RULE_GRP_1     ")
//#define MP_GCM_RULE_GRP_2         ("RULE_GRP_2     ")
//#define MP_GCM_RULE_GRP_3         ("RULE_GRP_3     ")
//#define MP_GCM_RULE_GRP_4         ("RULE_GRP_4     ")
//#define MP_GCM_RULE_GRP_5         ("RULE_GRP_5     ")
//#define MP_GCM_RULE_GRP_6         ("RULE_GRP_6     ")
//#define MP_GCM_RULE_GRP_7         ("RULE_GRP_7     ")
//#define MP_GCM_RULE_GRP_8         ("RULE_GRP_8     ")
//#define MP_GCM_RULE_GRP_9         ("RULE_GRP_9     ")
//#define MP_GCM_RULE_GRP_10        ("RULE_GRP_10    ")
//
///*Line Group Table 1~10 */
#define MP_GCM_LINE_GRP_1         ("LINE_GRP_1     ")
#define MP_GCM_LINE_GRP_2         ("LINE_GRP_2     ")
#define MP_GCM_LINE_GRP_3         ("LINE_GRP_3     ")
#define MP_GCM_LINE_GRP_4         ("LINE_GRP_4     ")
#define MP_GCM_LINE_GRP_5         ("LINE_GRP_5     ")
#define MP_GCM_LINE_GRP_6         ("LINE_GRP_6     ")
#define MP_GCM_LINE_GRP_7         ("LINE_GRP_7     ")
#define MP_GCM_LINE_GRP_8         ("LINE_GRP_8     ")
#define MP_GCM_LINE_GRP_9         ("LINE_GRP_9     ")
#define MP_GCM_LINE_GRP_10        ("LINE_GRP_10    ")
//
///*Shop Group Table 1~10 */
//#define MP_GCM_SHOP_GRP_1         ("SHOP_GRP_1     ")
//#define MP_GCM_SHOP_GRP_2         ("SHOP_GRP_2     ")
//#define MP_GCM_SHOP_GRP_3         ("SHOP_GRP_3     ")
//#define MP_GCM_SHOP_GRP_4         ("SHOP_GRP_4     ")
//#define MP_GCM_SHOP_GRP_5         ("SHOP_GRP_5     ")
//#define MP_GCM_SHOP_GRP_6         ("SHOP_GRP_6     ")
//#define MP_GCM_SHOP_GRP_7         ("SHOP_GRP_7     ")
//#define MP_GCM_SHOP_GRP_8         ("SHOP_GRP_8     ")
//#define MP_GCM_SHOP_GRP_9         ("SHOP_GRP_9     ")
//#define MP_GCM_SHOP_GRP_10        ("SHOP_GRP_10    ")
//
///*Oper Group Table 1~10 */
//#define MP_GCM_OPER_GRP_1         ("OPER_GRP_1     ")
//#define MP_GCM_OPER_GRP_2         ("OPER_GRP_2     ")
//#define MP_GCM_OPER_GRP_3         ("OPER_GRP_3     ")
//#define MP_GCM_OPER_GRP_4         ("OPER_GRP_4     ")
//#define MP_GCM_OPER_GRP_5         ("OPER_GRP_5     ")
//#define MP_GCM_OPER_GRP_6         ("OPER_GRP_6     ")
//#define MP_GCM_OPER_GRP_7         ("OPER_GRP_7     ")
//#define MP_GCM_OPER_GRP_8         ("OPER_GRP_8     ")
//#define MP_GCM_OPER_GRP_9         ("OPER_GRP_9     ")
//#define MP_GCM_OPER_GRP_10        ("OPER_GRP_10    ")

#define MP_INV_CV_INPUT  	      ("INV_CHG   ")
#define MP_TERM_CODE_SUB_END      ("SUB_END")
#define MP_INV_TYPE_COMPLETE      ("COMPLETE")
#define MP_VENDOR_HANSOL		  ("HANSOL")

#define MP_GCM_TBL_WORK_CENTER          ("C@WORK_CENTER")
#define MP_GCM_TBL_ROUTE_CONTROL          ("C@ROUTE_CONTROL")
#define MP_GCM_TBL_ORD_STATUS          ("C@ORD_STATUS")

#define MP_GCM_TBL_STOCK_INVG_MST         ("C@STOCK_INVG_MST")

#define MP_GCM_TBL_RAS_DOWN_CODE_L         ("C$RAS_DOWN_CODE_L")
#define MP_GCM_TBL_RAS_DOWN_TYPE          ("C$RAS_DOWN_TYPE")
#define MP_GCM_TBL_RAS_DOWN_TYPE_RES_DOWN          ("RD001")

#define MP_GCM_TBL_BATCH_MODULE_TRG    ("BATCH_MODULE_TRG    ")
  
#define MP_RAS_EVENT_RES_DOWN          ("RES_DOWN")
#define MP_RAS_EVENT_RES_UP          ("RES_UP")

/* Step Option Type */
#define MP_STEP_OPTION_RULE                 ("RUL       ")
#define MP_STEP_OPTION_RES                  ("RES       ")
#define MP_STEP_OPTION_INTERLOCK_STEP       ("STP       ")

/* RULE Define */
#define MP_GCM_STEP_RULE_DEFINE         ("STEP_RULE_DEFINE")
#define MP_RULE_PREVIOUS_STEP_CHECK     ("RULE_PREVIOUS_STEP_CHECK")
#define MP_RULE_PREVIOUS_STEP_DATA_CHECK     ("RULE_PREVIOUS_STEP_DATA_CHECK")
#define MP_RULE_PREVIOUS_STEP_INTERVAL_TIME_CHECK     ("RULE_INTERVAL_TIME_CHECK")
#define MP_RULE_MOUNT_RESULT_CHECK		("RULE_MOUNT_RESULT_CHECK")

#define MP_MESA_FILE_PATH ("MeasurementFilePath")
#define MP_FORMAT_FILE_DIR ("MESplusDocFormatDir")

#define MP_LOT_CODE_BX                 ("BX")
#define MP_LOT_CODE_TH                 ("TH")
#define MP_LOT_CODE_AM5R               ("AM5R")

#define MP_MAT_GRP_PD				   ("PD                            ")
#define MP_MAT_GRP_SIP				   ("SIP                           ")
#define MP_MAT_GRP_FUNAI			   ("FUNAI                         ")
#define MP_MAT_GRP_DUNT  			   ("DUNT                          ")
#define MP_FACTORY_CUSTOMER				("CUSTOMER")

#define	MP_GID_MAX_SEQ_SIZE (10)
#define	MP_GID_MAX_DATE_SIZE (11)

#define MP_OPTION_DOWN_CALC_INTERVAL	("DownTimeCalulationInterval")
#define MP_OPTION_SEND_MAIL_BOM_INTERVAL	("SendMailBOMIFInterval")

#define MP_ID_RULE_DLV_MATERIAL_LOT_ID	("DlvMaterialLotID")
#define MP_ID_RULE_WORK_ORDER_ID	("WorkOrderID")
#define MP_ID_RULE_CMN_LOSS_LOT_ID	("CmnLossLotID01")
#define MP_ID_RULE_CMN_QC_LOT_ID	("CmnQCLotID01")

#define MP_DTR_WIP_LOT_CREATE_CODE_PROD ("PROD")
#define MP_DTR_WIP_LOT_CREATE_CODE_LOSS ("LOSS")
#define MP_DTR_WIP_LOT_CREATE_CODE_RWRK ("RWRK")
#define MP_DTR_WIP_LOT_CREATE_CODE_QC ("QC")

#define MP_TOOL_EVENT_ATTACH	("ATTACH")
#define MP_TOOL_EVENT_DETACH	("DETACH")

#define MP_ORDER_CRITERIA_RESOURCE ('R')
#define MP_ORDER_CRITERIA_WORK_CENTER ('W')

#define MP_ORDER_STATUS_OPEN ('0')
#define MP_ORDER_STATUS_PROC ('P')
#define MP_ORDER_STATUS_WAIT ('W')
#define MP_ORDER_STATUS_CLOSED ('C')
#define MP_ORDER_STATUS_DELETED ('D')

#define MP_BOM_INPUT_TYPE_AUTO ('A')
#define MP_BOM_INPUT_TYPE_SCAN ('S')
#define MP_BOM_INPUT_TYPE_OPTIONAL ('O')
#define MP_ORDER_STATUS_DELETED ('D')

#define MP_WIP_BONUS_CODE_HANDOVER ("HANDOVER")
 
#define MP_GCM_TBL_TERMINAL_INFO ("C@TERMINAL_INFO")

#define ATTR_NAME_TERMINAL_IPADDR ("IP_ADDRESS")
#define ATTR_NAME_TERMINAL_OPER ("OPER")
#define ATTR_NAME_TERMINAL_RES_LIST ("RES_LIST")
#define ATTR_NAME_TERMINAL_WORK_CENTER_LIST ("WORK_CENTER_LIST")
#define ATTR_NAME_TERMINAL_LABEL_PRINTER ("LABEL_PRINTER")


#define CUS_G_OPTION_USE_SHIFT_RES_PLAN    ("UseWorkShiftResourcePlanning")           //Shift별 설비 가동 계획을 관리할지 여부를 관리하는 Global option

#define MP_RUT_CNTL_KEY_ZP03 ("ZP03")

#define MP_HOLD_CODE_SUSPEND_LOT        ("SUSPENDLOT")
#define MP_RELEASE_CODE_SUSPEND_LOT     ("SUSPENDLOT")
#define MP_RELEASE_CODE_QC_REINSP     ("QC_REINSP")
#define  MP_HOLD_CODE_QC_FAIL ("QC_FAIL")

#define MP_INSP_RESULT_SPECIAL ('S')

#define MP_TIV_CV_HIST_ADJUST_PLUS ("HIST_ADJ_P")
#define MP_TIV_CV_HIST_ADJUST_MINUS ("HIST_ADJ_M")
#define MP_TIV_CV_HIST_ADJUST_CANCEL ("HIST_ADJ_C")

#define MP_TIV_LS_STINVG ("LS_STINVG")
#define MP_TIV_CV_STINVG ("CV_STINVG")
#define MP_TIV_LS_DELLOT ("LS_DELLOT")
#define MP_TIV_CV_DELLOT ("CV_DELLOT")


#define MP_GCM_PALLET_TYPE ("C@PALLET_TYPE")

#define MP_ERP_MVT_101 ("101")  // 실적등록
#define MP_ERP_MVT_102 ("102")  // 실적보정
#define MP_ERP_MVT_261 ("261")  // 하위자재 실적등록
#define MP_ERP_MVT_262 ("262")  // 하위자재 실적등록 취소
#define MP_ERP_MVT_351 ("351")  // 공장간 이동
#define MP_ERP_MVT_543 ("543")  // 외주창고->DTR입고 하위자재출고
#define MP_ERP_MVT_544 ("544")  // 외주창고->DTR입고 하위자재출고
#define MP_ERP_MVT_551 ("551")  // GI 스크랩
#define MP_ERP_MVT_552 ("552")  // GI 스크랩 취소
#define MP_ERP_MVT_601 ("601")  // 출하 601
#define MP_ERP_MVT_602 ("602")  // 출하 601 취소
#define MP_ERP_MVT_631 ("631")  // 출하 601
#define MP_ERP_MVT_632 ("632")  // 출하 601 취소

#define MP_ERP_MVT_905 ("905")  // 파괴시험 GI (초중종)
#define MP_ERP_MVT_951 ("951")  // 해체입고
#define MP_ERP_MVT_953 ("953")  // 재작업입고
#define MP_ERP_MVT_NA ("NA")  // 재작업입고
#define MP_ERP_MVT_SIV ("SIV")  // 재고실사

#define MP_MES_ORDER_TYPE_NORMAL ("PROD      ")		// MES 오더 타입 NORMAL
#define MP_MES_ORDER_TYPE_REWORK ("RWRK      ")		// MES 오더 타입 REWORK
#define MP_MES_ORDER_TYPE_EMERGENCY ("EMGC      ")  // MES 오더 타입 EMERGENCY

#define MP_ERP_ORDER_TYPE_NORMAL ("PV02      ")  // ERP 오더 타입 NORMAL
#define MP_ERP_ORDER_TYPE_REWORK ("PV06      ")  // ERP 오더 타입 REWORK

#define MP_MVT_IN_OUT_FLAG_IN ('I')
#define MP_MVT_IN_OUT_FLAG_OUT ('O')
#define MP_MVT_IN_OUT_FLAG_BOTH ('B')

#define MP_DLV_DML_TYPE_FAC_IN ('A') // 입하
#define MP_DLV_DML_TYPE_IN ('I') // 입고
#define MP_DLV_DML_TYPE_CANCEL ('C') // 입고취소
#define MP_DLV_DML_TYPE_RETURN ('R') // 수입검사 반품 불합격

#define MP_ERP_LOT_MOVE_LOT_FLAG ('L')  
#define MP_ERP_LOT_MOVE_DLV_FLAG ('D')  
#define MP_ERP_LOT_MOVE_SHP_FLAG ('S')  


#define MP_INV_OPER			("W110") //Raw Material Warehouse
#define MP_INV_OPER_WOPR    ("W210") //Process Warehouse
#define MP_INV_OPER_SHIP    ("W310") //Ship Warehouse
#define MP_INV_OPER_REPAIR  ("W410") //Repair Warehouse




#endif  /* _INVCORE_DEFINES_H */

