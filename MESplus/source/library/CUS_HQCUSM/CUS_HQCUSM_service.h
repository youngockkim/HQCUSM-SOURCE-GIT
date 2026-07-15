
#ifndef _CUS_HQCUSM_SERVICE_H
#define _CUS_HQCUSM_SERVICE_H

#include <SLCCore_common.h>

extern void CUS_HQCUSM_add_service();
/*ERP*/
DllExport int CWIP_Update_Move_Request(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Move_Confirm(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Rework_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Move_Confirm(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Move_Request(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Port_Operation_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CINV_Move_Store(TRSNode *in_node, TRSNode *out_node);
/* WIP. */
DllExport int CWIP_Update_Tray_Management(TRSNode* in_node, TRSNode* out_node); //[25.05.02]Tray Use
DllExport int CWIP_Packing_Fullcell(TRSNode *in_node, TRSNode* out_node);
DllExport int CWIP_Packing_Halfcell(TRSNode* in_node, TRSNode* out_node);
DllExport int CWIP_View_Packing_Fullcell_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Packing_Halfcell_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Packing_Module_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Packing_Module_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Move_HalfCell_Cart(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Fqc_Result(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Fqc_Flash_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Fqc_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Fqc_Result(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Order_BOM_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Packing_Label_Print(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Packing_Label_Print_V1(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Packing_Label_Print_V2(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Inspection_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Inspection_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Line_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Cinvlotsts_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_BOM_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Operation_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Packing_Barcode_Print(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Module_Label_Print(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Module_Repair(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Fullcell_Lot_Validation(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Grade(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Grade_Multi(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Pallet_Current_Seq(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Scrap_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Scrap_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_ScrapLb_List_Tb(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Cart(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Packing_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Monthly_Plan(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Plan(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Multi_Update_Plan(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_4m(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_4m_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Terminate_Cause_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Cleaving_Loss_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Cleaving_Loss(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Validate_Terminate_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Product_Plan(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Fmb_Notice(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Ctm(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Material_List_By_Production(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Tray(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Tray(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Validate_For_Fqc_Rejudgment(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Start_Lot_Oqc(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_End_Lot_Oqc(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Collect_Inspection_Data_Oqc(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Silicone_Management(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Validation_Silicone_Management(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Silicone_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Acmodule_History_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Acmodule_Remove(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Pmpp_Diode_Alert_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Pmpp_Diode_Alert(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Tabber_Status(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Tabber_Status(TRSNode *in_node, TRSNode *out_node);

DllExport int CWIP_Update_Oqc_Technician(TRSNode *in_node, TRSNode *out_node); //[IS-20-08-004]
DllExport int CWIP_View_Oqc_Technician(TRSNode *in_node, TRSNode *out_node);  //[IS-20-08-004]

DllExport int CWIP_View_Cleaving_Loss_List_Gram(TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
DllExport int CWIP_Update_Cleaving_Loss_Gram(TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
DllExport int CWIP_View_Scrap_List_Lb(TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
DllExport int CWIP_Update_Scrap_List_Lb(TRSNode *in_node, TRSNode *out_node);  //[IS-20-09-182]
DllExport int CWIP_Update_Lot_Rework(TRSNode *in_node, TRSNode *out_node);  //[IS-21-01-022]
DllExport int CWIP_View_Rework_Result(TRSNode *in_node, TRSNode *out_node);  //[IS-21-01-022]
DllExport int CWIP_Update_lot_extention(TRSNode *in_node, TRSNode *out_node);  //[IS-21-05-028]
DllExport int CWIP_View_lot_extention(TRSNode *in_node, TRSNode *out_node);  //[IS-21-05-028]
DllExport int CWIP_View_lot_extention_List(TRSNode *in_node, TRSNode *out_node);  //[IS-21-05-028]
DllExport int CWIP_Update_Entry_List(TRSNode *in_node, TRSNode *out_node);  //[IS-21-09-007]
DllExport int CWIP_View_Entry(TRSNode *in_node, TRSNode *out_node);  //[IS-21-09-007]
DllExport int CWIP_View_Entry_List(TRSNode *in_node, TRSNode *out_node);  //[IS-21-09-007]
DllExport int CWIP_Update_Material_Termination(TRSNode *in_node, TRSNode *out_node); //[IS-21-09-039]
DllExport int CWIP_View_Material_Termination(TRSNode *in_node, TRSNode *out_node); //[IS-21-09-039]
DllExport int CWIP_View_Material_Termination_List(TRSNode *in_node, TRSNode *out_node); //[IS-21-09-039]

DllExport int CWIP_Update_Module_Repair_Overkill(TRSNode *in_node, TRSNode *out_node);// IS-21-11-013
DllExport int CWIP_Update_Cleaving_Status(TRSNode *in_node, TRSNode *out_node);// IS-22-02-009
DllExport int CWIP_View_Cleaving_Status(TRSNode *in_node, TRSNode *out_node);// IS-22-02-009
DllExport int CWIP_View_Cleaving_Status_List(TRSNode *in_node, TRSNode *out_node);// IS-22-02-009

DllExport int CWIP_Get_Db_Systime(TRSNode *in_node, TRSNode *out_node);//IS-22-03-082

DllExport int CWIP_View_lot_image_save(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_lot_image_save_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_lot_image_save(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Repair_Insentive(TRSNode *in_node, TRSNode *out_node); //VOC-4375
DllExport int CWIP_Update_Repair_Insentive(TRSNode *in_node, TRSNode *out_node);  //VOC-4375

DllExport int CWIP_Collect_Peel_Test_Data(TRSNode *in_node, TRSNode *out_node); //PEEL TEST DATA


DllExport int CWIP_Update_String_Repair_Data(TRSNode *in_node, TRSNode *out_node); 
DllExport int CWIP_View_String_Repair_Data(TRSNode *in_node, TRSNode *out_node); 
DllExport int CWIP_View_String_Repair_Data_List(TRSNode *in_node, TRSNode *out_node); 

DllExport int CWIP_Update_ScrapLb_Tb(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_ScrapLb_Tb(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_ScrapLb_Tb_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Scraplb_Tb_Mst_List(TRSNode *in_node, TRSNode *out_node);

DllExport int CWIP_View_Hourly_Fqc_Worklog(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Update_Hourly_Fqc_Worklog(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Hourly_Fqc_Worklog_List(TRSNode *in_node, TRSNode *out_node);

DllExport int CWIP_Update_Laminator_Recipe(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Laminator_Recipe(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Laminator_Recipe_List(TRSNode *in_node, TRSNode *out_node);

DllExport int CWIP_Update_Day_Inventory(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Day_Inventory(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Day_Inventory_List(TRSNode *in_node, TRSNode *out_node);

DllExport int CWIP_View_Materials_In_Bom_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Orders_By_Material_List(TRSNode *in_node, TRSNode *out_node);

/*Laminator pull test [2025.04.23]*/
DllExport int CWIP_Update_Laminator_Pull_Test(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Laminator_Pull_Test(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Laminator_Pull_Test_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_Update_Xlinktest(TRSNode* in_node, TRSNode* out_node);		//25.04.11 X-Link Test
DllExport int CRAS_View_Xlinktest(TRSNode* in_node, TRSNode* out_node);			//25.04.11 X-Link Test
DllExport int CRAS_View_Xlinktest_List(TRSNode* in_node, TRSNode* out_node);	//25.04.11 X-Link Test

DllExport int CWIP_Update_PeelTestResult(TRSNode* in_node, TRSNode* out_node);    //2025-06-25
DllExport int CWIP_View_PeelTestResult(TRSNode* in_node, TRSNode* out_node);      //2025-06-25
DllExport int CWIP_View_PeelTestResult_List(TRSNode* in_node, TRSNode* out_node); //2025-06-25

DllExport int CWIP_Update_Repacking_Log(TRSNode* in_node, TRSNode* out_node);    //2025-07-31
DllExport int CWIP_View_Repacking_Log(TRSNode* in_node, TRSNode* out_node);      //2025-07-31
DllExport int CWIP_View_Repacking_Log_List(TRSNode* in_node, TRSNode* out_node); //2025-07-31

DllExport int CWIP_Update_Tb_Cleaning_Schedule(TRSNode* in_node, TRSNode* out_node);    //2025-07-31
DllExport int CWIP_View_Tb_Cleaning_Schedule(TRSNode* in_node, TRSNode* out_node);      //2025-07-31
DllExport int CWIP_View_Tb_Cleaning_Schedule_List(TRSNode* in_node, TRSNode* out_node); //2025-07-31

/* EIS */
DllExport int EAPMES_Validate_Lot_Label_E23(TRSNode* in_node); // Lee Jong Hwan Reqest 2025-02-26
DllExport int EAPMES_Change_Resource_Bypass_Mode(TRSNode* in_node);  // [25.05.02]Auto Module Repair
DllExport int EAPMES_Change_Resource_State_Nozzle_Pressure(TRSNode* in_node);  // [25.05.02]Auto Module Repair
DllExport int EAPMES_Create_Lot(TRSNode *in_node);
DllExport int EAPMES_Start_Lot(TRSNode *in_node);
DllExport int EAPMES_Start_Lot_LAMI(TRSNode *in_node);
DllExport int EAPMES_End_Lot(TRSNode *in_node);
DllExport int EAPMES_End_Lot_LAMI(TRSNode *in_node);
DllExport int EAPMES_Change_Resource_Control_Mode(TRSNode *in_node);
DllExport int EAPMES_Change_Resource_State(TRSNode *in_node);
DllExport int EAPMES_Raise_Alarm(TRSNode *in_node);
DllExport int EAPMES_Clear_Alarm(TRSNode *in_node);
DllExport int EAPMES_Request_Login(TRSNode *in_node);
DllExport int MESEAP_Notify_System_Alarm(TRSNode *in_node);
DllExport int EAPMES_Collect_Resource_Event(TRSNode *in_node);
DllExport int MESEAP_Set_Resource_Data_Collection_Method(TRSNode *in_node);
DllExport int EAPMES_Collect_Resource_Data(TRSNode *in_node);
DllExport int EAPMES_Request_Production_Order_List(TRSNode *in_node);
DllExport int EAPMES_Validate_Production_Order(TRSNode *in_node);
DllExport int EAPMES_Dock_In_Cart(TRSNode *in_node);
DllExport int EAPMES_Dock_Out_Cart(TRSNode *in_node);
DllExport int EAPMES_Validate_Magazine(TRSNode *in_node);
DllExport int EAPMES_Load_Magazine(TRSNode *in_node);
DllExport int EAPMES_Unload_Magazine(TRSNode *in_node);
DllExport int EAPMES_Assign_Magazine_To_Cart(TRSNode *in_node);
DllExport int EAPMES_Load_Material(TRSNode *in_node);
DllExport int EAPMES_Unload_Material(TRSNode *in_node);
DllExport int EAPMES_Collect_Process_Data(TRSNode *in_node);
DllExport int EAPMES_Collect_Process_Data_String(TRSNode *in_node);
DllExport int EAPMES_Collect_Process_Data_Cell(TRSNode *in_node);
DllExport int EAPMES_Collect_Process_Data_LAMI(TRSNode *in_node);
DllExport int EAPMES_Collect_Process_Data_FQC(TRSNode *in_node);
DllExport int EAPMES_Collect_Inspection_Data(TRSNode *in_node);
DllExport int EAPMES_Collect_Inspection_Data_Cleaving(TRSNode *in_node);
DllExport int EAPMES_Collect_Inspection_Data_Cell(TRSNode *in_node);
DllExport int EAPMES_Collect_Inspection_Data_String(TRSNode *in_node);
DllExport int EAPMES_Update_Tool_Usage_Count(TRSNode *in_node);
DllExport int EAPMES_Get_Process_Tack_Time(TRSNode *in_node);
DllExport int EAPMES_Validate_Lot(TRSNode *in_node);
DllExport int EAPMES_Validate_Lot_FQC(TRSNode *in_node);
DllExport int EAPMES_Save_Module_Information(TRSNode *in_node);
DllExport int EAPMES_Save_Module_Information(TRSNode *in_node);
DllExport int EAPMES_Match_Matrix_Pallet(TRSNode *in_node);
DllExport int EAPMES_Load_Module(TRSNode *in_node);
DllExport int EAPMES_Unload_Module(TRSNode *in_node);
DllExport int EAPMES_Terminate_Lot(TRSNode *in_node);
DllExport int EAPMES_Collect_Cell_ID(TRSNode *in_node);
DllExport int EAPMES_Collect_Image(TRSNode *in_node);
DllExport int EAPMES_Complete_Packing(TRSNode *in_node);

DllExport int EAPMES_Management_Recipe(TRSNode *in_node);
DllExport int EAPMES_RecipeID_List(TRSNode *in_node);
DllExport int EAPMES_RecipeParameter_List(TRSNode *in_node);
DllExport int EAPMES_ReleaseConfirm_Recipe(TRSNode *in_node);

DllExport int MESEAP_Remote_Request_MesToEap(TRSNode *in_node, TRSNode *out_node);
DllExport int EAPMES_Download_Fqc_Inspection_Data(TRSNode *in_node);
DllExport int EAPMES_Collect_Process_Data(TRSNode *in_node);


DllExport int EAPMES_Collect_Equipment_Working_Time(TRSNode *in_node, TRSNode *out_node);
DllExport int EAPMES_Collect_Equipment_Average_Working_Time(TRSNode *in_node, TRSNode *out_node);
DllExport int EAPMES_Collect_Inspection_Data_Sualab(TRSNode *in_node);
DllExport int EAPMES_Collect_Inspection_Data_Busbar(TRSNode *in_node);

DllExport int EAPMES_Update_Recipe(TRSNode *in_node);

DllExport int EAPMES_Collect_Inspection_Vision_Cleaving(TRSNode *in_node);
DllExport int EAPMES_Hourly_Summary_Cleaving(TRSNode *in_node);
DllExport int EAPMES_Layup_Repair_Tray_Input_Data(TRSNode *in_node);
DllExport int EAPMES_BufferCount_Inquiry_RES(TRSNode *in_node);

DllExport int EAPMES_LGV_Load_Alarm(TRSNode *in_node);
DllExport int EAPMES_LGV_Acmodule_Alarm(TRSNode *in_node);

DllExport int EAPMES_Collect_LGV_Terminal_Event(TRSNode *in_node);//IS-21-11-033 [LGV] Terminal Message
DllExport int CEIS_Save_Traceability_Material_Data(TRSNode* in_node, TRSNode *out_node);  // 2024-02-23 자재추적성 및 CTM 집계용 데이터 생성

/* RAS */
DllExport int CRAS_View_Attached_Material_List_By_Resource(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_Update_Attached_Material_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_View_Resource_List_By_Line(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_View_Daily_Work_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_Update_Daily_Work_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_Multi_Update_Daily_Work_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_View_Patrol_Check_Sheet(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_Update_Patrol_Check_Sheet(TRSNode *in_node, TRSNode *out_node);
DllExport int CRAS_Multi_Update_Patrol_Check_Sheet(TRSNode *in_node, TRSNode *out_node);
 
DllExport int CRAS_Update_Hour_Gap(TRSNode *in_node, TRSNode *out_node);        //IS-21-01-077
DllExport int CRAS_View_Hour_Gap_List(TRSNode *in_node, TRSNode *out_node);  //IS-21-01-077

DllExport int CRAS_View_Crasdshift_List(TRSNode *in_node, TRSNode *out_node);        //IS-21-04-033 End of Shift Report
DllExport int CRAS_Update_Crasdshift(TRSNode *in_node, TRSNode *out_node);  //IS-21-04-033 End of Shift Report
DllExport int CRAS_View_Crasdwntim_List(TRSNode *in_node, TRSNode *out_node);       //IS-21-04-033 End of Shift Report
DllExport int CRAS_Update_Crasdwntim(TRSNode *in_node, TRSNode *out_node);  //IS-21-04-033 End of Shift Report
DllExport int CRAS_View_equipment_work_log_List(TRSNode *in_node, TRSNode *out_node);      //IS-21-06-040 MES OI Request - Equipment Worklog °³¹ß
DllExport int CRAS_Update_equipment_work_log(TRSNode *in_node, TRSNode *out_node);  //IS-21-06-040 MES OI Request - Equipment Worklog °³¹ß
DllExport int CRAS_View_TABBER_CLEAN_List(TRSNode *in_node, TRSNode *out_node);	//IS-21-11-028 Tabber Cleaning Schedule Management
DllExport int CRAS_Update_TABBER_CLEAN(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);	//IS-21-11-028 Tabber Cleaning Schedule Management

DllExport int CRAS_Update_Tabber_Jig_Repair(TRSNode *in_node, TRSNode *out_node);  //2025.10.09 Tabber Jig Repair
DllExport int CRAS_View_Tabber_Jig_Repair(TRSNode *in_node, TRSNode *out_node);  //2025.10.09 Tabber Jig Repair
DllExport int CRAS_View_Tabber_Jig_Repair_List(TRSNode *in_node, TRSNode *out_node);  //2025.10.09 Tabber Jig Repair

/* ORD */
DllExport int CORD_View_Order_List_By_Line(TRSNode *in_node, TRSNode *out_node);
DllExport int CORD_View_Current_Order_By_Line(TRSNode *in_node, TRSNode *out_node);
DllExport int CORD_Change_Current_Order(TRSNode *in_node, TRSNode *out_node);

/* MDM */
DllExport int CMDM_View_XLink_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CMDM_Update_XLink_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CMDM_View_Reference_Sample_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CMDM_Update_Reference_Sample_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CMDM_View_EVA_To_Glass_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CMDM_Update_EVA_To_Glass_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CMDM_View_EVA_To_Backsheet_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CMDM_Update_EVA_To_Backsheet_Data_List(TRSNode *in_node, TRSNode *out_node);

/* BAS */
DllExport int CBAS_view_Module_grade_list(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_view_article_list(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_view_article_list(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_Update_CGCMTBLDAT(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_View_CGCMTBLDAT(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_View_CGCMTBLDAT_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_View_Data(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_View_Data_List(TRSNode *in_node, TRSNode *out_node);

/* RPT */
DllExport int CRPT_View_Fullcell_Cart_Label(TRSNode *in_node, TRSNode *out_node);
DllExport int CRPT_View_Halfcell_Cart_Label(TRSNode *in_node, TRSNode *out_node);
DllExport int CRPT_View_Productivity_By_Order(TRSNode *in_node, TRSNode *out_node);
DllExport int CRPT_View_Productivity_By_Period(TRSNode *in_node, TRSNode *out_node);
DllExport int CRPT_View_Manage_Fullcell_Cart_Label(TRSNode *in_node, TRSNode *out_node);


/* RCP */
DllExport int CRCP_Update_Para_Version(TRSNode *in_node, TRSNode *out_node);

/* MMS */
//-----------------------------------
//[2023.10.25]이글 2/3의 Batch Job 운영을 위한 소스 Merge - start
//-----------------------------------
DllExport int CMMS_Update_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Item_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Sample(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Sample(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Sample_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Calibration_user(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_user(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_user_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Calibration_Institute(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Institute(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Institute_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Equipment(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Equipment(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Equipment_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Equipment_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Equipment_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Equipment_Item_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Calibration_Plan(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Plan(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Plan_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Calibration_Result_Registration(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Result_Registration(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Result_Registration_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Calibration_Equipment(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Equipment(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Calibration_Equipment_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Analysis_Plan(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Analysis_Plan(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Analysis_Plan_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Measuring_Result_Registration(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Measuring_Result_Registration(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Measuring_Result_Registration_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Analysis_Plan_Item_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Equipment_Ledger_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Analysis_Plan_Result_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Update_Evaluation_Result_Registration(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Evaluation_Result_Registration(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_Evaluation_Result_Registration_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_Raise_Alarm(TRSNode* in_node, TRSNode* out_node);
DllExport int CMMS_View_CMMS_Equip_List_List(TRSNode* in_node, TRSNode* out_node);
/* JCM */
DllExport int CJCM_Update_Job_Change_Status(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Job_Change_Status(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Job_Change_Status_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Update_Job_Change_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Job_Change_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Job_Change_Item_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Update_Setup_Job_Change_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Setup_Job_Change_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Setup_Job_Change_Item_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Create_Job_Change_Master(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Insert_Job_Item_History(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Order_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_View_Cjcm_Join_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Check_Job_Change_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Raise_Alarm(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Close_Job_Change_Master(TRSNode* in_node, TRSNode* out_node);
DllExport int CJCM_Copy_Job_Change_Master(TRSNode* in_node, TRSNode* out_node);
DllExport int CPSM_Update_Prod_Monitoring(TRSNode* in_node, TRSNode* out_node);
DllExport int CPSM_View_Prod_Monitoring(TRSNode* in_node, TRSNode* out_node);
DllExport int CPSM_View_Prod_Monitoring_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CPSM_Update_Monitoring_Status(TRSNode* in_node, TRSNode* out_node);

//AMS
DllExport int CAMS_Update_Audit_Plan(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_View_Audit_Plan(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_View_Audit_Plan_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_Update_Audit_Result_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_View_Audit_Result_Item(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_View_Audit_Result_Item_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_Update_Audit_Result(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_View_Audit_Result(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_View_Audit_Result_List(TRSNode* in_node, TRSNode* out_node);
DllExport int CAMS_View_Cams_Join_List(TRSNode* in_node, TRSNode* out_node);

//-----------------------------------
//[2023.10.25]이글 2/3의 Batch Job 운영을 위한 소스 Merge - end
//-----------------------------------

#endif /* _CUST_SAMPLE_SERVICES_H */


