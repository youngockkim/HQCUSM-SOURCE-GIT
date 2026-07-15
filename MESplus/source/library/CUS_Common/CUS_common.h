
#ifndef _CUS_COMMON_H
#define _CUS_COMMON_H
/*
** MESplus include files
*/

#include <MESCore_common.h>
#include <WIPCore_common.h>
#include <ORDCore_common.h>
#include <RASCore_common.h>
#include <CUS_common_service.h>
#include "CDB_common.h"
#include "CUS_defines.h"

#define  NOT_CHANGE_PASSWORD "_NOTCHANGE_PASSWORD_"

/* Common Function */
extern int COM_Save_Service_Error_Log(TRSNode *in_node, TRSNode *out_node);

/* EIS Common Function */
extern int CEIS_Save_Message_Log(TRSNode *in_node, TRSNode *out_node);
extern int CEIS_Save_Message_Log_For_List(TRSNode *in_node, TRSNode *out_node);
extern int CEIS_Save_Message_Log_For_Single_List(TRSNode *in_node, TRSNode *out_node);
extern int CUS_Interface_Ras_Parameter_Data(TRSNode *in_node, TRSNode *out_node);
extern char CCOM_get_work_shift(char *s_trantime);

/* ERP Interface */
extern int CUS_INTERFACE_DOWNLOAD_CELL_GRBATCH(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_STOCK_TRANSFER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_MATERIAL_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_CELL_MOVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ROUTING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_PRODUCTION_BOM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ORDER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_MATERIAL_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_ARTICLE_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_PACKING_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_COSTCENTER_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_POWER_RANGE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_MODULE_LOCATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_BOM_FUNCTION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_PACKINGINFO_SEND(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_CELL_BLOCK(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_ADDITIONAL_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CUS_INTERFACE_DOWNLOAD_TERMINATE_INFO(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //VOC-479 22.06.07
extern int CUS_INTERFACE_DOWNLOAD_MATERIAL_MASTER_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_PACKING_MASTER_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_POWER_RANGE_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_PRODUCTION_ROUTING_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_PRODUCTION_REWORK_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_VENDOR_MASTER_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_ARTICLE_MASTER_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_QM103_OQC_CONFIRM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_QM106_OQC_REQUEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_PACKINGINFO_SEND_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_STOCK_TRANSFER_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[ERP Project]
extern int CUS_INTERFACE_DOWNLOAD_INVENTORY_BY_GRADE_INFO_GERP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[ERP Project]
/* BAS */
extern int CBAS_VIEW_LARGE_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CBAS_VIEW_SHIFT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CBAS_VIEW_QUERY_RESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CBAS_SEND_MAIL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CBAS_SEND_MAIL_MANUAL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* WIP */
extern int CWIP_CREATE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_START_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_END_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_LOT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_MULTI_LOT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_TABBER_INSPECTION_CELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);//
//extern int CUS_INTERFACE_MCS_CARTUNLOAD(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//25.08.25 RTD 반복 잡 생성 로직 기술 검토 및 개발 요청의 건

/* POP */
extern int CPOP_UPDATE_LABEL_PRINT_HISTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CPOP_VIEW_LABEL_PRINT_HISTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* EDC */
extern int CEDC_UPDATE_INSPECTION_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CEDC_UPDATE_MAIN_DEFECT_CODE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CEDC_UPDATE_MATRIX_DEFECT_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* WIP TRANSACTION º° SUMMARY */
extern int CSUM_SUMMARY_WIP_TRAN_STARTLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_ENDLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_CREATELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_ADAPTLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_COMBINELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_CVLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_LOSSLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_MERGELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_REWORKLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_SHIPLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_SKIPLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_SPLITLOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_TERMINATELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SYNC_WIP_TRAN_STATUS(char *s_msg_code, struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_EOH(char *s_msg_code, struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_HOUR(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CSUM_SUMMARY_WIP_TRAN_MOVELOT(char *s_msg_code,  struct MTMPLOTHIS_TAG *MTMPLOTHIS, TRSNode *in_node, TRSNode *out_node);
extern int CCOM_COPY_FROM_PRCDATA_TO_LOTDATA (TRSNode *in_node, struct CRASPRCDAT_TAG *CRASPRCDAT);
extern int COM_Publish_Data(char *s_msg_code, TRSNode *in_node);
extern int CUS_COM_BATCHPROCESS_STATUS_UPDATE(char cStep, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_LOT_UNSTORE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node, struct MWIPLOTSTS_TAG *MWIPLOTSTS); //[ERP Project]
extern int CSUM_BatchProcess_Transaction_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
extern int CSUM_BATCHPROCESS_TRANSACTION_E1(TRSNode *in_node, TRSNode *out_node);
extern int CSUM_BATCHPROCESS_TRANSACTION_E23(TRSNode *in_node, TRSNode *out_node);
extern int CSUM_BATCHPROCESS_EVENT_E1(TRSNode *in_node, TRSNode *out_node);
extern int CSUM_BATCHPROCESS_EVENT_E2(TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_LOT_LIST_TERMINATE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);		 //25.03.21 Module Terminate Service

extern char RPT_get_work_shift(char *s_trantime);;

extern int COM_Guaranteed_CRASPRCDATA(char *s_msg_code, TRSNode *in_node);

#endif /* _CUS_COMMON_H */
