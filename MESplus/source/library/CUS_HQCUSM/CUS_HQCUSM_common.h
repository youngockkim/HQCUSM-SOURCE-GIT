
#ifndef _CUS_HQCUSM_H
#define _CUS_HQCUSM_H

/*
** MESplus include files
*/

#include <MESCore_common.h>
#include <WIPCore_common.h>

#include <CUS_common.h>
#include "CUS_defines.h"
#include "MessageCaster.h"

#define  NOT_CHANGE_PASSWORD "_NOTCHANGE_PASSWORD_"
/*ERP */
extern int CWIP_UPDATE_MOVE_REQUEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_MOVE_CONFIRM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_REWORK_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_MOVE_CONFIRM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_MOVE_REQUEST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PORT_OPERATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CINV_MOVE_STORE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
/* WIP */
extern int CWIP_UPDATE_TRAY_MANAGEMENT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node); //[25.05.02]Tray Use
extern int CWIP_PACKING_FULLCELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_PACKING_HALFCELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_PACKING_HALFCELL_BOX(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PACKING_FULLCELL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PACKING_HALFCELL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PACKING_MODULE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_PACKING_MODULE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_MOVE_HALFCELL_CART(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_FQC_RESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_FQC_FLASH_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_FQC_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_FQC_RESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_ORDER_BOM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PACKING_LABEL_PRINT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_INSPECTION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_INSPECTION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_LINE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_CINVLOTSTS_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_BOM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_OPERATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PACKING_BARCODE_PRINT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_MODULE_LABEL_PRINT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_MODULE_REPAIR(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_FULLCELL_LOT_VALIDATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_GRADE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_GRADE_MULTI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PALLET_CURRENT_SEQ(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_SCRAP_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_SCRAP_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_SCRAPLB_LIST_TB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_SCRAPLB_TB_MST_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_CART(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PACKING_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_MONTHLY_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_MULTI_UPDATE_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_4M(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_4M_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_TERMINATE_CAUSE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_CLEAVING_LOSS_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_CLEAVING_LOSS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VALIDATE_TERMINATE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_PRODUCT_PLAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_FMB_NOTICE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_CTM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_MATERIAL_LIST_BY_PRODUCTION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_TRAY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_TRAY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VALIDATE_FOR_FQC_REJUDGMENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_START_LOT_OQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_END_LOT_OQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_COLLECT_INSPECTION_DATA_OQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);


extern int CWIP_VIEW_SILICONE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_SILICONE_MANAGEMENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_ACMODULE_HISTORY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_ACMODULE_REMOVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_PMPP_DIODE_ALERT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_PMPP_DIODE_ALERT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_TABBER_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_TABBER_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);


extern int CWIP_UPDATE_OQC_TECHNICIAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[IS-20-08-004]
extern int CWIP_VIEW_OQC_TECHNICIAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[IS-20-08-004]
extern int CWIP_VIEW_CLEAVING_LOSS_LIST_GRAM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
extern int CWIP_UPDATE_CLEAVING_LOSS_GRAM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
extern int CWIP_VIEW_SCRAP_LIST_LB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
extern int CWIP_UPDATE_SCRAP_LIST_LB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
extern int CWIP_UPDATE_LOT_REWORK(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-21-01-022]
extern int CWIP_VIEW_REWORK_RESULT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-21-01-022]
extern int CWIP_UPDATE_LOT_EXTENTION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-21-05-028]
extern int CWIP_VIEW_LOT_EXTENTION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-21-05-028]
extern int CWIP_VIEW_LOT_EXTENTION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-21-05-028]
extern int CWIP_VIEW_ENTRY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-21-09-007]
extern int CWIP_VIEW_ENTRY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);  //[IS-21-09-007]
extern int CWIP_UPDATE_MATERIAL_TERMINATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[IS-21-09-039]
extern int CWIP_VIEW_MATERIAL_TERMINATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[IS-21-09-039]
extern int CWIP_VIEW_MATERIAL_TERMINATION_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //[IS-21-09-039]

extern int CWIP_UPDATE_MODULE_REPAIR_OVERKILL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);// IS-21-11-013
extern int CWIP_UPDATE_CLEAVING_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);// IS-22-02-009
extern int CWIP_VIEW_CLEAVING_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);// IS-22-02-009
extern int CWIP_VIEW_CLEAVING_STATUS_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);// IS-22-02-009

extern int CWIP_GET_DB_SYSTIME(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);//IS-22-03-082

extern int CWIP_VIEW_LOT_IMAGE_SAVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_LOT_IMAGE_SAVE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_LOT_IMAGE_SAVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_REPAIR_INSENTIVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //VOC-4375
extern int CWIP_UPDATE_REPAIR_INSENTIVE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //VOC-4375

extern int CWIP_COLLECT_PEEL_TEST_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //PEEL TEST INPUT 

extern int CWIP_VIEW_HOURLY_FQC_WORKLOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_UPDATE_HOURLY_FQC_WORKLOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_HOURLY_FQC_WORKLOG_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

extern int CWIP_UPDATE_LAMINATOR_RECIPE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Laminator Recipe
extern int CWIP_VIEW_LAMINATOR_RECIPE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Laminator Recipe
extern int CWIP_VIEW_LAMINATOR_RECIPE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Laminator Recipe

extern int CWIP_UPDATE_DAY_INVENTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Data Inventory
extern int CWIP_VIEW_DAY_INVENTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Data Inventory
extern int CWIP_VIEW_DAY_INVENTORY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Data Inventory

extern int CWIP_VIEW_MATERIALS_IN_BOM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Material Termination
extern int CWIP_VIEW_ORDERS_BY_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //Material Termination

/*Laminator pull test*/
extern int CWIP_UPDATE_LAMINATOR_PULL_TEST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CWIP_VIEW_LAMINATOR_PULL_TEST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CWIP_VIEW_LAMINATOR_PULL_TEST_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);

extern int CWIP_UPDATE_PEELTESTRESULT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node); //2025.06.25 Peel Test Result
extern int CWIP_VIEW_PEELTESTRESULT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);   //2025.06.25 Peel Test Result
extern int CWIP_VIEW_PEELTESTRESULT_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);//2025.06.25 Peel Test Result

extern int CWIP_UPDATE_REPACKING_LOG(char* s_msg_code, TRSNode* in_node, TRSNode* out_node); //2025.07.31 Pallet Repacking Log
extern int CWIP_VIEW_REPACKING_LOG(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);   //2025.07.31 Pallet Repacking Log
extern int CWIP_VIEW_REPACKING_LOG_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);//2025.07.31 Pallet Repacking Log

/* EIS. */
extern int EAPMES_VALIDATE_LOT_LABEL_E23(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);//Auto Module Repair 2025-02-05
extern int EAPMES_CHANGE_RESOURCE_STATE_NOZZLE_PRESSURE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);// [25.05.02]Auto Module Repair
extern int EAPMES_CHANGE_RESOURCE_BYPASS_MODE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node); // [25.05.02]Auto Module Repair
extern int EAPMES_CREATE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_START_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_START_LOT_LAMI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_END_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_END_LOT_LAMI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_CHANGE_RESOURCE_CONTROL_MODE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_CHANGE_RESOURCE_STATE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_RAISE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_CLEAR_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_REQUEST_LOGIN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int MESEAP_NOTIFY_SYSTEM_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_RESOURCE_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int MESEAP_SET_RESOURCE_DATA_COLLECTION_METHOD(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_RESOURCE_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_REQUEST_PRODUCTION_ORDER_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_VALIDATE_PRODUCTION_ORDER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_DOCK_IN_CART(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_DOCK_OUT_CART(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_VALIDATE_MAGAZINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_LOAD_MAGAZINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_UNLOAD_MAGAZINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_ASSIGN_MAGAZINE_TO_CART(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_LOAD_MATERIAL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_UNLOAD_MATERIAL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_PROCESS_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_PROCESS_DATA_STRING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_PROCESS_DATA_CELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_PROCESS_DATA_LAMI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_PROCESS_DATA_FQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_INSPECTION_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_INSPECTION_DATA_CLEAVING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_INSPECTION_DATA_CELL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_INSPECTION_DATA_STRING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_UPDATE_TOOL_USAGE_COUNT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_GET_PROCESS_TACK_TIME(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_VALIDATE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_VALIDATE_LOT_FQC(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_SVAE_MODULE_INFORMATION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_MATCH_MATRIX_PALLET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_LOAD_MODULE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_UNLOAD_MODULE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_TERMINATE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_CELL_ID(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COMPLETE_PACKING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_DOWNLOAD_FQC_INSPECTION_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_EQUIPMENT_WORKING_TIME(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_INSPECTION_DATA_SUALAB(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_INSPECTION_DATA_BUSBAR(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_RECIPEPARAMETER_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_COLLECT_INSPECTION_VISION_CLEAVING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_HOURLY_SUMMARY_CLEAVING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_LAYUP_REPAIR_TRAY_INPUT_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_BUFFERCOUNT_INQUIRY_RES(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

extern int EAPMES_LGV_LOAD_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int EAPMES_LGV_ACMODULE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

extern int EAPMES_COLLECT_LGV_TERMINAL_EVENT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);//IS-21-11-033 [LGV] Terminal Message

/* RAS */
extern int CRAS_VIEW_ATTACHED_MATERIAL_LIST_BY_RESOURCE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_UPDATE_ATTACHED_MATERIAL_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_VIEW_RESOURCE_LIST_BY_LINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_VIEW_DAILY_WORK_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_UPDATE_DAILY_WORK_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_MULTI_UPDATE_DAILY_WORK_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_VIEW_PATROL_CHECK_SHEET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_MULTI_UPDATE_PATROL_CHECK_SHEET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_UPDATE_PATROL_CHECK_SHEET(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_VIEW_HOUR_GAP_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//IS-21-01-077
extern int CRAS_UPDATE_HOUR_GAP(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-01-077

extern int CRAS_VIEW_CRASDSHIFT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-04-033 End of Shift Report
extern int CRAS_VIEW_CRASDWNTIM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-04-033 End of Shift Report
extern int CRAS_UPDATE_CRASDWNTIM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//IS-21-04-033 End of Shift Report
extern int CRAS_UPDATE_CRASDSHIFT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-04-033 End of Shift Report
extern int CRAS_VIEW_EQUIPMENT_WORK_LOG_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-06-040 MES OI Request - Equipment Worklog °³¹ß
extern int CRAS_UPDATE_EQUIPMENT_WORK_LOG(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-06-040 MES OI Request - Equipment Worklog °³¹ß
extern int CRAS_VIEW_TABBER_CLEAN_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //IS-21-11-028 Tabber Cleaning Schedule Management
extern int CRAS_UPDATE_TABBER_CLEAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//IS-21-11-028 Tabber Cleaning Schedule Management


/* ORD */
extern int CORD_VIEW_ORDER_LIST_BY_LINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CORD_VIEW_CURRENT_ORDER_BY_LINE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CORD_CHANGE_CURRENT_ORDER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* MDM */
extern int CMDM_VIEW_XLINK_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CMDM_UPDATE_XLINK_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CMDM_VIEW_REFERENCE_SAMPLE_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CMDM_UPDATE_REFERENCE_SAMPLE_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CMDM_VIEW_EVA_TO_GLASS_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CMDM_UPDATE_EVA_TO_GLASS_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CMDM_VIEW_EVA_TO_BACKSHEET_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CMDM_UPDATE_EVA_TO_BACKSHEET_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* BAS */
extern int CBAS_VIEW_MODULE_GRADE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CBAS_VIEW_ARTICLE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

extern int CBAS_UPDATE_CGCMTBLDAT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CBAS_VIEW_CGCMTBLDAT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CBAS_VIEW_CGCMTBLDAT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* RPT */
extern int CRPT_VIEW_FULLCELL_CART_LABEL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRPT_VIEW_HALFCELL_CART_LABEL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRPT_VIEW_PRODUCTIVITY_BY_ORDER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRPT_VIEW_PRODUCTIVITY_BY_PERIOD(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRPT_VIEW_MANAGE_FULLCELL_CART_LABEL(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* RCP */
extern int CRCP_UPDATE_PARA_VERSION(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);



extern int CWIP_UPDATE_STRING_REPAIR_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_STRING_REPAIR_DATA(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CWIP_VIEW_STRING_REPAIR_DATA_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

extern int CWIP_UPDATE_TB_CLEANING_SCHEDULE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //2025.08.27 TB Cleaning Schedule
extern int CWIP_VIEW_TB_CLEANING_SCHEDULE(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //2025.08.27 TB Cleaning Schedule
extern int CWIP_VIEW_TB_CLEANING_SCHEDULE_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node); //2025.08.27 TB Cleaning Schedule

extern int CRAS_UPDATE_TABBER_JIG_REPAIR(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_VIEW_TABBER_JIG_REPAIR(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CRAS_VIEW_TABBER_JIG_REPAIR_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

#endif /* _CUST_SAMPLE_COMMON_H */



/* CMMS */
//-----------------------------------
//[2023.10.25]이글 2/3의 Batch Job 운영을 위한 소스 Merge - start
//-----------------------------------
extern int CMMS_set_attached_file(char* s_msg_code, char* tran_id, char* file_id, char* file_name, MBLOB m_blob, char* file_path);
extern int CMMS_get_attached_file(char* s_msg_code, TRSNode* out_node, char* s_file_path, char* s_put_member_name, char c_add_fieldmsg);
extern int CMMS_UPDATE_ITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_ITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_ITEM_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_SAMPLE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_SAMPLE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_SAMPLE_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_CALIBRATION_USER(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_USER(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_USER_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_CALIBRATION_INSTITUTE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_INSTITUTE(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_INSTITUTE_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_EQUIPMENT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EQUIPMENT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EQUIPMENT_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_EQUIPMENT_ITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EQUIPMENT_ITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EQUIPMENT_ITEM_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_CALIBRATION_PLAN(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_PLAN(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_PLAN_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_CALIBRATION_EQUIPMENT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_EQUIPMENT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CALIBRATION_EQUIPMENT_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_ANALYSIS_PLAN(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_ANALYSIS_PLAN(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_ANALYSIS_PLAN_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_MEASURING_RESULT_REGISTRATION(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_MEASURING_RESULT_REGISTRATION(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_MEASURING_RESULT_REGISTRATION_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_ANALYSIS_PLAN_ITEM_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EQUIPMENT_LEDGER_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EVALUATION_RESULT_REGISTRATION(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_RAISE_ALARM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EQUIPMENTITEM_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_EQUIPMENTITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_UPDATE_EQUIPMENTITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CMMS_VIEW_CMMS_EQUIP_LIST_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);

extern int CJCM_UPDATE_JOB_CHANGE_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_JOB_CHANGE_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_JOB_CHANGE_STATUS_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_UPDATE_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_JOB_CHANGE_ITEM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_CHECK_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_SETUP_JOB_CHANGE_ITEM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_CREATE_JOB_CHANGE_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_INSERT_JOB_ITEM_HISTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_ORDER_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_VIEW_CJCM_JOIN_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CJCM_RAISE_ALARM(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_CLOSE_JOB_CHANGE_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CJCM_COPY_JOB_CHANGE_MASTER(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CPSM_UPDATE_PROD_MONITORING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CPSM_VIEW_PROD_MONITORING(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CPSM_VIEW_PROD_MONITORING_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int CPSM_UPDATE_MONITORING_STATUS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

/* CAMS */
extern int CAMS_UPDATE_AUDIT_PLAN(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_VIEW_AUDIT_PLAN(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_VIEW_AUDIT_PLAN_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_UPDATE_AUDIT_RESULT_ITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_VIEW_AUDIT_RESULT_ITEM(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_VIEW_AUDIT_RESULT_ITEM_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_VIEW_CAMS_JOIN_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_UPDATE_AUDIT_RESULT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_VIEW_AUDIT_RESULT(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);
extern int CAMS_VIEW_AUDIT_RESULT_LIST(char* s_msg_code, TRSNode* in_node, TRSNode* out_node);


//-----------------------------------
//[2023.10.25]이글 2/3의 Batch Job 운영을 위한 소스 Merge - end
//-----------------------------------