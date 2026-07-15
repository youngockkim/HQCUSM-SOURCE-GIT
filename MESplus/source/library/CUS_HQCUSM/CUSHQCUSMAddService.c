#include <MESCore_service.h>
#include "CUS_HQCUSM_service.h"


void CUS_HQCUSM_add_service()
{	
	/* ERP */
	COM_add_service("CWIP", "CWIP_Update_Move_Request", REPLY, CWIP_Update_Move_Request);
	COM_add_service("CWIP", "CWIP_Update_Move_Confirm", REPLY, CWIP_Update_Move_Confirm);
	COM_add_service("CWIP", "CWIP_View_Rework_List", REPLY, CWIP_View_Rework_List);
	COM_add_service("CWIP", "CWIP_Update_Move_Confirm", REPLY, CWIP_Update_Move_Confirm);
	COM_add_service("CWIP", "CWIP_Update_Move_Request", REPLY, CWIP_Update_Move_Request);
	COM_add_service("CWIP", "CWIP_View_Port_Operation_List", REPLY, CWIP_View_Port_Operation_List);
	COM_add_service("CWIP", "CINV_Move_Store", REPLY, CINV_Move_Store);

	/* WIP */
	COM_add_service("CWIP", "CWIP_Update_Tray_Management", REPLY, CWIP_Update_Tray_Management); //[25.05.02]Tray Use
	COM_add_service("CWIP", "CWIP_Packing_Fullcell", REPLY, CWIP_Packing_Fullcell);
	COM_add_service("CWIP", "CWIP_Packing_Halfcell", REPLY, CWIP_Packing_Halfcell);
	COM_add_service("CWIP", "CWIP_View_Packing_Fullcell_List", REPLY, CWIP_View_Packing_Fullcell_List);
	COM_add_service("CWIP", "CWIP_View_Packing_Halfcell_List", REPLY, CWIP_View_Packing_Halfcell_List);
	COM_add_service("CWIP", "CWIP_View_Packing_Module_List", REPLY, CWIP_View_Packing_Module_List);
	COM_add_service("CWIP", "CWIP_Update_Packing_Module_List", REPLY, CWIP_Update_Packing_Module_List);
	COM_add_service("CWIP", "CWIP_Move_HalfCell_Cart", REPLY, CWIP_Move_HalfCell_Cart);
    COM_add_service("CWIP", "CWIP_View_Lot", REPLY, CWIP_View_Lot);
	COM_add_service("CWIP", "CWIP_View_Fqc_Result", REPLY, CWIP_View_Fqc_Result);
  //COM_add_service("CWIP", "CWIP_View_Multi_Fqc_Result", REPLY, CWIP_View_Multi_Fqc_Result);  
	COM_add_service("CWIP", "CWIP_View_Fqc_Flash_List", REPLY, CWIP_View_Fqc_Flash_List);
	COM_add_service("CWIP", "CWIP_View_Fqc_List", REPLY, CWIP_View_Fqc_List);
	COM_add_service("CWIP", "CWIP_Update_Fqc_Result", REPLY, CWIP_Update_Fqc_Result);
    COM_add_service("CWIP", "CWIP_View_Order_BOM_List", REPLY, CWIP_View_Order_BOM_List);
	COM_add_service("CWIP", "CWIP_View_Packing_Label_Print", REPLY, CWIP_View_Packing_Label_Print);
	COM_add_service("CWIP", "CWIP_View_Packing_Label_Print_V1", REPLY, CWIP_View_Packing_Label_Print_V1);
	COM_add_service("CWIP", "CWIP_View_Packing_Label_Print_V2", REPLY, CWIP_View_Packing_Label_Print_V2);
	COM_add_service("CWIP", "CWIP_View_Inspection_List", REPLY, CWIP_View_Inspection_List);
	COM_add_service("CWIP", "CWIP_Update_Inspection_List", REPLY, CWIP_Update_Inspection_List);
    COM_add_service("CWIP", "CWIP_View_Line_List", REPLY, CWIP_View_Line_List);
	COM_add_service("CWIP", "CWIP_View_Cinvlotsts_List", REPLY, CWIP_View_Cinvlotsts_List);
	COM_add_service("CWIP", "CWIP_View_BOM_List", REPLY, CWIP_View_BOM_List);
    COM_add_service("CWIP", "CWIP_View_Operation_List", REPLY, CWIP_View_Operation_List);
	COM_add_service("CWIP", "CWIP_View_Packing_Barcode_Print", REPLY, CWIP_View_Packing_Barcode_Print);
	COM_add_service("CWIP", "CWIP_View_Module_Label_Print", REPLY, CWIP_View_Module_Label_Print);
	COM_add_service("CWIP", "CWIP_Update_Module_Repair", REPLY, CWIP_Update_Module_Repair);
	COM_add_service("CWIP", "CWIP_View_Fullcell_Lot_Validation", REPLY, CWIP_View_Fullcell_Lot_Validation);
	COM_add_service("CWIP", "CWIP_View_Grade", REPLY, CWIP_View_Grade);
    COM_add_service("CWIP", "CWIP_View_Grade_Multi", REPLY, CWIP_View_Grade_Multi);
	COM_add_service("CWIP", "CWIP_View_Pallet_Current_Seq", REPLY, CWIP_View_Pallet_Current_Seq);
    COM_add_service("CWIP", "CWIP_View_Scrap_List", REPLY, CWIP_View_Scrap_List);
    COM_add_service("CWIP", "CWIP_Update_Scrap_List", REPLY, CWIP_Update_Scrap_List);
    COM_add_service("CWIP", "CWIP_Update_Cart", REPLY, CWIP_Update_Cart);
    COM_add_service("CWIP", "CWIP_View_Packing_Lot", REPLY, CWIP_View_Packing_Lot);
    COM_add_service("CWIP", "CWIP_View_Monthly_Plan", REPLY, CWIP_View_Monthly_Plan);
    COM_add_service("CWIP", "CWIP_Update_Plan", REPLY, CWIP_Update_Plan);
    COM_add_service("CWIP", "CWIP_Multi_Update_Plan", REPLY, CWIP_Multi_Update_Plan);
    COM_add_service("CWIP", "CWIP_Update_4m", REPLY, CWIP_Update_4m);
    COM_add_service("CWIP", "CWIP_View_4m_List", REPLY, CWIP_View_4m_List);
    COM_add_service("CWIP", "CWIP_View_Terminate_Cause_List", REPLY, CWIP_View_Terminate_Cause_List);
    COM_add_service("CWIP", "CWIP_Validate_Terminate_Lot", REPLY, CWIP_Validate_Terminate_Lot);
	COM_add_service("CWIP", "CWIP_Update_Product_Plan", REPLY, CWIP_Update_Product_Plan);
    COM_add_service("CWIP", "CWIP_View_Cleaving_Loss_List", REPLY, CWIP_View_Cleaving_Loss_List);
    COM_add_service("CWIP", "CWIP_Update_Cleaving_Loss", REPLY, CWIP_Update_Cleaving_Loss);
	COM_add_service("CWIP", "CWIP_Update_Fmb_Notice", REPLY, CWIP_Update_Fmb_Notice);	
	COM_add_service("CWIP", "CWIP_Update_Ctm", REPLY, CWIP_Update_Ctm);
	COM_add_service("CWIP", "CWIP_View_Material_List_By_Production", REPLY, CWIP_View_Material_List_By_Production);
	COM_add_service("CWIP", "CWIP_View_Tray", REPLY, CWIP_View_Tray);
	COM_add_service("CWIP", "CWIP_Update_Tray", REPLY, CWIP_Update_Tray);
	COM_add_service("CWIP", "CWIP_Validate_For_Fqc_Rejudgment", REPLY, CWIP_Validate_For_Fqc_Rejudgment);
    COM_add_service("CWIP", "CWIP_Start_Lot_Oqc", REPLY, CWIP_Start_Lot_Oqc);
    COM_add_service("CWIP", "CWIP_End_Lot_Oqc", REPLY, CWIP_End_Lot_Oqc);
    COM_add_service("CWIP", "CWIP_Collect_Inspection_Data_Oqc", REPLY, CWIP_Collect_Inspection_Data_Oqc);
	COM_add_service("CWIP", "CWIP_Update_Silicone_Management", REPLY, CWIP_Update_Silicone_Management);
	COM_add_service("CWIP", "CWIP_Validation_Silicone_Management", REPLY, CWIP_Validation_Silicone_Management);
	COM_add_service("CWIP", "CWIP_View_Silicone_List", REPLY, CWIP_View_Silicone_List);
	COM_add_service("CWIP", "CWIP_View_Acmodule_History_List", REPLY, CWIP_View_Acmodule_History_List);
	COM_add_service("CWIP", "CWIP_Update_Acmodule_Remove", REPLY, CWIP_Update_Acmodule_Remove);
	COM_add_service("CWIP", "CWIP_View_Pmpp_Diode_Alert_List", REPLY, CWIP_View_Pmpp_Diode_Alert_List);
	COM_add_service("CWIP", "CWIP_Update_Pmpp_Diode_Alert", REPLY, CWIP_Update_Pmpp_Diode_Alert);
	COM_add_service("CWIP", "CWIP_View_Tabber_Status", REPLY, CWIP_View_Tabber_Status);
	COM_add_service("CWIP", "CWIP_Update_Tabber_Status", REPLY, CWIP_Update_Tabber_Status);

	COM_add_service("CWIP", "CWIP_Update_Oqc_Technician", REPLY, CWIP_Update_Oqc_Technician);	//[IS-20-08-004]
	COM_add_service("CWIP", "CWIP_View_Oqc_Technician", REPLY, CWIP_View_Oqc_Technician);	//[IS-20-08-004]
	COM_add_service("CWIP", "CWIP_View_Cleaving_Loss_List_Gram", REPLY, CWIP_View_Cleaving_Loss_List_Gram); //IS-20-09-182 
	COM_add_service("CWIP", "CWIP_Update_Cleaving_Loss_Gram", REPLY, CWIP_Update_Cleaving_Loss_Gram);	 //IS-20-09-182 
	COM_add_service("CWIP", "CWIP_View_Scrap_List_Lb", REPLY, CWIP_View_Scrap_List_Lb);	 //IS-20-09-182 
	COM_add_service("CWIP", "CWIP_Update_Scrap_List_Lb", REPLY, CWIP_Update_Scrap_List_Lb);	 //IS-20-09-182 
	COM_add_service("CWIP", "CWIP_Update_Lot_Rework", REPLY, CWIP_Update_Lot_Rework);	 //IS-21-01-022  
	COM_add_service("CWIP", "CWIP_View_Rework_Result", REPLY, CWIP_View_Rework_Result);	 //IS-21-01-022  
	COM_add_service("CWIP", "CWIP_View_Entry_List", REPLY, CWIP_View_Entry_List);	 //IS-21-09-007
	COM_add_service("CWIP", "CWIP_Update_Entry_List", REPLY, CWIP_Update_Entry_List);	 //IS-21-09-007
    COM_add_service("CWIP", "CWIP_Update_Material_Termination", REPLY, CWIP_Update_Material_Termination);   //IS-21-09-039
    COM_add_service("CWIP", "CWIP_View_Material_Termination", REPLY, CWIP_View_Material_Termination);   //IS-21-09-039
    COM_add_service("CWIP", "CWIP_View_Material_Termination_List", REPLY, CWIP_View_Material_Termination_List);   //IS-21-09-039

	COM_add_service("CWIP", "CWIP_Update_Module_Repair_Overkill", REPLY, CWIP_Update_Module_Repair_Overkill);// IS-21-11-013
	COM_add_service("CWIP", "CWIP_Update_Cleaving_Status", REPLY, CWIP_Update_Cleaving_Status);// IS-22-02-009
	COM_add_service("CWIP", "CWIP_View_Cleaving_Status", REPLY, CWIP_View_Cleaving_Status);// IS-22-02-009
	COM_add_service("CWIP", "CWIP_View_Cleaving_Status_List", REPLY, CWIP_View_Cleaving_Status_List);// IS-22-02-009

	COM_add_service("CWIP", "CWIP_Get_Db_Systime", REPLY, CWIP_Get_Db_Systime);//IS-22-03-082

	COM_add_service("CWIP", "CWIP_View_lot_image_save", REPLY, CWIP_View_lot_image_save);
	COM_add_service("CWIP", "CWIP_View_lot_image_save_List", REPLY, CWIP_View_lot_image_save_List);
	COM_add_service("CWIP", "CWIP_Update_lot_image_save", REPLY, CWIP_Update_lot_image_save);
	COM_add_service("CWIP", "CWIP_View_Repair_Insentive", REPLY, CWIP_View_Repair_Insentive);
	COM_add_service("CWIP", "CWIP_Update_Repair_Insentive", REPLY, CWIP_Update_Repair_Insentive);

    COM_add_service("CWIP", "CWIP_Collect_Peel_Test_Data", REPLY, CWIP_Collect_Peel_Test_Data); //Peel Test Data

	COM_add_service("CWIP", "CWIP_Update_String_Repair_Data", REPLY, CWIP_Update_String_Repair_Data);
    COM_add_service("CWIP", "CWIP_View_String_Repair_Data", REPLY, CWIP_View_String_Repair_Data);
    COM_add_service("CWIP", "CWIP_View_String_Repair_Data_List", REPLY, CWIP_View_String_Repair_Data_List);

	COM_add_service("CWIP", "CWIP_Update_ScrapLb_Tb", REPLY, CWIP_Update_ScrapLb_Tb);
    COM_add_service("CWIP", "CWIP_View_ScrapLb_Tb", REPLY, CWIP_View_ScrapLb_Tb);
    COM_add_service("CWIP", "CWIP_View_ScrapLb_Tb_List", REPLY, CWIP_View_ScrapLb_Tb_List);
	COM_add_service("CWIP", "CWIP_Update_ScrapLb_List_Tb", REPLY, CWIP_Update_ScrapLb_List_Tb);
	COM_add_service("CWIP", "CWIP_View_Scraplb_Tb_Mst_List", REPLY, CWIP_View_Scraplb_Tb_Mst_List);
	
	COM_add_service("CWIP", "CWIP_View_Hourly_Fqc_Worklog", REPLY, CWIP_View_Hourly_Fqc_Worklog);
	COM_add_service("CWIP", "CWIP_Update_Hourly_Fqc_Worklog", REPLY, CWIP_Update_Hourly_Fqc_Worklog);
	COM_add_service("CWIP", "CWIP_View_Hourly_Fqc_Worklog_List", REPLY, CWIP_View_Hourly_Fqc_Worklog_List);

	COM_add_service("CWIP", "CWIP_Update_Laminator_Recipe", REPLY, CWIP_Update_Laminator_Recipe);
	COM_add_service("CWIP", "CWIP_View_Laminator_Recipe", REPLY, CWIP_View_Laminator_Recipe);
	COM_add_service("CWIP", "CWIP_View_Laminator_Recipe_List", REPLY, CWIP_View_Laminator_Recipe_List);

	COM_add_service("CWIP", "CWIP_Update_Day_Inventory", REPLY, CWIP_Update_Day_Inventory);
	COM_add_service("CWIP", "CWIP_View_Day_Inventory", REPLY, CWIP_View_Day_Inventory);
	COM_add_service("CWIP", "CWIP_View_Day_Inventory_List", REPLY, CWIP_View_Day_Inventory_List);

	COM_add_service("CWIP", "CWIP_View_Materials_In_Bom_List", REPLY, CWIP_View_Materials_In_Bom_List);
	COM_add_service("CWIP", "CWIP_View_Orders_By_Material_List", REPLY, CWIP_View_Orders_By_Material_List);
	COM_add_service("CRAS", "CRAS_Update_Xlinktest", REPLY, CRAS_Update_Xlinktest);		//25.04.11 X-Link Test
    COM_add_service("CRAS", "CRAS_View_Xlinktest", REPLY, CRAS_View_Xlinktest);			//25.04.11 X-Link Test
    COM_add_service("CRAS", "CRAS_View_Xlinktest_List", REPLY, CRAS_View_Xlinktest_List);	//25.04.11 X-Link Test
	/*Laminator pull test [2025.04.23]*/
	COM_add_service("CWIP", "CWIP_Update_Laminator_Pull_Test", REPLY, CWIP_Update_Laminator_Pull_Test);
	COM_add_service("CWIP", "CWIP_View_Laminator_Pull_Test", REPLY, CWIP_View_Laminator_Pull_Test);
	COM_add_service("CWIP", "CWIP_View_Laminator_Pull_Test_List", REPLY, CWIP_View_Laminator_Pull_Test_List);

	/*Peel Test Result*/
	COM_add_service("CWIP", "CWIP_Update_PeelTestResult", REPLY, CWIP_Update_PeelTestResult);
	COM_add_service("CWIP", "CWIP_View_PeelTestResult", REPLY, CWIP_View_PeelTestResult);
	COM_add_service("CWIP", "CWIP_View_PeelTestResult_List", REPLY, CWIP_View_PeelTestResult_List);

	/*Pallet Repacking Log*/
	COM_add_service("CWIP", "CWIP_Update_Repacking_Log", REPLY, CWIP_Update_Repacking_Log); // 2025-07-31 Pallet Repacking Log
	COM_add_service("CWIP", "CWIP_View_Repacking_Log", REPLY, CWIP_View_Repacking_Log); // 2025-07-31 Pallet Repacking Log
	COM_add_service("CWIP", "CWIP_View_Repacking_Log_List", REPLY, CWIP_View_Repacking_Log_List); // 2025-07-31 Pallet Repacking Log

    COM_add_service("CWIP", "CWIP_Update_Tb_Cleaning_Schedule", REPLY, CWIP_Update_Tb_Cleaning_Schedule);
    COM_add_service("CWIP", "CWIP_View_Tb_Cleaning_Schedule", REPLY, CWIP_View_Tb_Cleaning_Schedule);
    COM_add_service("CWIP", "CWIP_View_Tb_Cleaning_Schedule_List", REPLY, CWIP_View_Tb_Cleaning_Schedule_List);
    
    /* EIS */
	COM_add_service("CEIS", "EAPMES_Change_Resource_Bypass_Mode", NO_REPLY, EAPMES_Change_Resource_Bypass_Mode);// // [25.05.02]Auto Module Repair
    COM_add_service("CEIS", "EAPMES_Change_Resource_State_Nozzle_Pressure", NO_REPLY, EAPMES_Change_Resource_State_Nozzle_Pressure);// // [25.05.02]Auto Module Repair
    COM_add_service("CEIS", "EAPMES_Validate_Lot_Label_E23", REPLY, EAPMES_Validate_Lot_Label_E23); // Lee Jong Hwan Reqest 2025-02-26

    COM_add_service("CEIS", "EAPMES_Create_Lot", NO_REPLY, EAPMES_Create_Lot);
    COM_add_service("CEIS", "EAPMES_Start_Lot", NO_REPLY, EAPMES_Start_Lot);
    COM_add_service("CEIS", "EAPMES_Start_Lot_LAMI", NO_REPLY, EAPMES_Start_Lot_LAMI);
    COM_add_service("CEIS", "EAPMES_End_Lot", NO_REPLY, EAPMES_End_Lot);
    COM_add_service("CEIS", "EAPMES_End_Lot_LAMI", NO_REPLY, EAPMES_End_Lot_LAMI);
    COM_add_service("CEIS", "EAPMES_Change_Resource_Control_Mode", NO_REPLY, EAPMES_Change_Resource_Control_Mode);
    COM_add_service("CEIS", "EAPMES_Change_Resource_State", NO_REPLY, EAPMES_Change_Resource_State);
    COM_add_service("CEIS", "EAPMES_Raise_Alarm", NO_REPLY, EAPMES_Raise_Alarm);
    COM_add_service("CEIS", "EAPMES_Clear_Alarm", NO_REPLY, EAPMES_Clear_Alarm);
    COM_add_service("CEIS", "EAPMES_Request_Login", NO_REPLY, EAPMES_Request_Login);
    COM_add_service("CEIS", "MESEAP_Notify_System_Alarm", NO_REPLY, MESEAP_Notify_System_Alarm);
    COM_add_service("CEIS", "EAPMES_Collect_Resource_Event", NO_REPLY, EAPMES_Collect_Resource_Event);
    COM_add_service("CEIS", "MESEAP_Set_Resource_Data_Collection_Method", NO_REPLY, MESEAP_Set_Resource_Data_Collection_Method);
    COM_add_service("CEIS", "EAPMES_Collect_Resource_Data", NO_REPLY, EAPMES_Collect_Resource_Data);
    COM_add_service("CEIS", "EAPMES_Request_Production_Order_List", NO_REPLY, EAPMES_Request_Production_Order_List);
    COM_add_service("CEIS", "EAPMES_Validate_Production_Order", NO_REPLY, EAPMES_Validate_Production_Order);
    COM_add_service("CEIS", "EAPMES_Dock_In_Cart", NO_REPLY, EAPMES_Dock_In_Cart);
    COM_add_service("CEIS", "EAPMES_Dock_Out_Cart", NO_REPLY, EAPMES_Dock_Out_Cart);
    COM_add_service("CEIS", "EAPMES_Validate_Magazine", NO_REPLY, EAPMES_Validate_Magazine);
    COM_add_service("CEIS", "EAPMES_Load_Magazine", NO_REPLY, EAPMES_Load_Magazine);
    COM_add_service("CEIS", "EAPMES_Unload_Magazine", NO_REPLY, EAPMES_Unload_Magazine);
    COM_add_service("CEIS", "EAPMES_Assign_Magazine_To_Cart", NO_REPLY, EAPMES_Assign_Magazine_To_Cart);
    COM_add_service("CEIS", "EAPMES_Load_Material", NO_REPLY, EAPMES_Load_Material);
    COM_add_service("CEIS", "EAPMES_Unload_Material", NO_REPLY, EAPMES_Unload_Material);
    COM_add_service("CEIS", "EAPMES_Collect_Process_Data", NO_REPLY, EAPMES_Collect_Process_Data);
    COM_add_service("CEIS", "EAPMES_Collect_Process_Data_String", NO_REPLY, EAPMES_Collect_Process_Data_String);
    COM_add_service("CEIS", "EAPMES_Collect_Process_Data_Cell", NO_REPLY, EAPMES_Collect_Process_Data_Cell);
    COM_add_service("CEIS", "EAPMES_Collect_Process_Data_LAMI", NO_REPLY, EAPMES_Collect_Process_Data_LAMI);
    COM_add_service("CEIS", "EAPMES_Collect_Process_Data_FQC", NO_REPLY, EAPMES_Collect_Process_Data_FQC);
    COM_add_service("CEIS", "EAPMES_Collect_Inspection_Data", NO_REPLY, EAPMES_Collect_Inspection_Data);
    COM_add_service("CEIS", "EAPMES_Collect_Inspection_Data_Cleaving", NO_REPLY, EAPMES_Collect_Inspection_Data_Cleaving);
    COM_add_service("CEIS", "EAPMES_Collect_Inspection_Data_Cell", NO_REPLY, EAPMES_Collect_Inspection_Data_Cell);
    COM_add_service("CEIS", "EAPMES_Collect_Inspection_Data_String", NO_REPLY, EAPMES_Collect_Inspection_Data_String);
    COM_add_service("CEIS", "EAPMES_Update_Tool_Usage_Count", NO_REPLY, EAPMES_Update_Tool_Usage_Count);
    COM_add_service("CEIS", "EAPMES_Get_Process_Tack_Time", NO_REPLY, EAPMES_Get_Process_Tack_Time);
    COM_add_service("CEIS", "EAPMES_Validate_Lot", NO_REPLY, EAPMES_Validate_Lot);
    COM_add_service("CEIS", "EAPMES_Validate_Lot_FQC", NO_REPLY, EAPMES_Validate_Lot_FQC);
	COM_add_service("CEIS", "EAPMES_Save_Module_Information", NO_REPLY, EAPMES_Save_Module_Information);
    COM_add_service("CEIS", "EAPMES_Match_Matrix_Pallet", NO_REPLY, EAPMES_Match_Matrix_Pallet);
    COM_add_service("CEIS", "EAPMES_Load_Module", NO_REPLY, EAPMES_Load_Module);
    COM_add_service("CEIS", "EAPMES_Unload_Module", NO_REPLY, EAPMES_Unload_Module);
    COM_add_service("CEIS", "EAPMES_Terminate_Lot", NO_REPLY, EAPMES_Terminate_Lot);
    COM_add_service("CEIS", "EAPMES_Collect_Cell_ID", NO_REPLY, EAPMES_Collect_Cell_ID);
	COM_add_service("CEIS", "EAPMES_Collect_Image", NO_REPLY, EAPMES_Collect_Image);
	COM_add_service("CEIS", "EAPMES_Complete_Packing", NO_REPLY, EAPMES_Complete_Packing);
	COM_add_service("CEIS", "EAPMES_Management_Recipe", NO_REPLY, EAPMES_Management_Recipe);
	COM_add_service("CEIS", "EAPMES_RecipeID_List", NO_REPLY, EAPMES_RecipeID_List);
	COM_add_service("CEIS", "EAPMES_RecipeParameter_List", NO_REPLY, EAPMES_RecipeParameter_List);
	COM_add_service("CEIS", "EAPMES_ReleaseConfirm_Recipe", NO_REPLY, EAPMES_ReleaseConfirm_Recipe);

	COM_add_service("CEIS", "MESEAP_Remote_Request_MesToEap", NO_REPLY, MESEAP_Remote_Request_MesToEap);
	COM_add_service("CEIS", "EAPMES_Download_Fqc_Inspection_Data", NO_REPLY, EAPMES_Download_Fqc_Inspection_Data);	
	
    COM_add_service("CEIS", "EAPMES_Collect_Equipment_Average_Working_Time", NO_REPLY, EAPMES_Collect_Equipment_Average_Working_Time);
    COM_add_service("CEIS", "EAPMES_Collect_Equipment_Working_Time", NO_REPLY, EAPMES_Collect_Equipment_Working_Time);
    COM_add_service("CEIS", "EAPMES_Collect_Inspection_Data_Sualab", NO_REPLY, EAPMES_Collect_Inspection_Data_Sualab);
    COM_add_service("CEIS", "EAPMES_Collect_Inspection_Data_Busbar", NO_REPLY, EAPMES_Collect_Inspection_Data_Busbar);

    COM_add_service("CEIS", "EAPMES_Update_Recipe", NO_REPLY, EAPMES_Update_Recipe);

	COM_add_service("CEIS", "EAPMES_Collect_Inspection_Vision_Cleaving", NO_REPLY, EAPMES_Collect_Inspection_Vision_Cleaving);
	COM_add_service("CEIS", "EAPMES_Hourly_Summary_Cleaving", NO_REPLY, EAPMES_Hourly_Summary_Cleaving);
	COM_add_service("CEIS", "EAPMES_Layup_Repair_Tray_Input_Data", NO_REPLY, EAPMES_Layup_Repair_Tray_Input_Data);
	COM_add_service("CEIS", "EAPMES_BufferCount_Inquiry_RES", NO_REPLY, EAPMES_BufferCount_Inquiry_RES);

	COM_add_service("CEIS", "EAPMES_LGV_Load_Alarm", NO_REPLY, EAPMES_LGV_Load_Alarm);
	COM_add_service("CEIS", "EAPMES_LGV_Acmodule_Alarm", NO_REPLY, EAPMES_LGV_Acmodule_Alarm);

	COM_add_service("CEIS", "EAPMES_Collect_LGV_Terminal_Event", NO_REPLY, EAPMES_Collect_LGV_Terminal_Event);//IS-21-11-033 [LGV] Terminal Message
	COM_add_service("CEIS", "CEIS_Save_Traceability_Material_Data", NO_REPLY, CEIS_Save_Traceability_Material_Data); // 2024-02-23 자재추적성 및 CTM 집계용 데이터 생성
    COM_add_service("CEIS", "CEIS_Save_Traceability_Material_Data_ARC", NO_REPLY, CEIS_Save_Traceability_Material_Data); // 2024-02-23 자재추적성 및 CTM 집계용 데이터 생성

	//COM_add_service("CEIS", "CEIS_Update_Ac_process_data", NO_RsssssEPLY, CEIS_Update_Ac_process_data);
	//COM_add_service("CEIS", "CEIS_View_Ac_process_data_List", NO_REPLY, CEIS_View_Ac_process_data_List);


    /* RAS */
    COM_add_service("CRAS", "CRAS_View_Attached_Material_List_By_Resource", REPLY, CRAS_View_Attached_Material_List_By_Resource);
	COM_add_service("CRAS", "CRAS_Update_Attached_Material_List", REPLY, CRAS_Update_Attached_Material_List);
    COM_add_service("CRAS", "CRAS_View_Resource_List_By_Line", REPLY, CRAS_View_Resource_List_By_Line);
    COM_add_service("CRAS", "CRAS_View_Daily_Work_List", REPLY, CRAS_View_Daily_Work_List);
    COM_add_service("CRAS", "CRAS_Update_Daily_Work_List", REPLY, CRAS_Update_Daily_Work_List);
    COM_add_service("CRAS", "CRAS_Multi_Update_Daily_Work_List", REPLY, CRAS_Multi_Update_Daily_Work_List);
    COM_add_service("CRAS", "CRAS_View_Patrol_Check_Sheet", REPLY, CRAS_View_Patrol_Check_Sheet);
    COM_add_service("CRAS", "CRAS_Update_Patrol_Check_Sheet", REPLY, CRAS_Update_Patrol_Check_Sheet);
    COM_add_service("CRAS", "CRAS_Multi_Update_Patrol_Check_Sheet", REPLY, CRAS_Multi_Update_Patrol_Check_Sheet);
    
	COM_add_service("CRAS", "CRAS_View_Hour_Gap_List", REPLY, CRAS_View_Hour_Gap_List);   //IS-21-01-077
    COM_add_service("CRAS", "CRAS_Update_Hour_Gap", REPLY, CRAS_Update_Hour_Gap); //IS-21-01-077

	COM_add_service("CRAS", "CRAS_View_Crasdshift_List", REPLY, CRAS_View_Crasdshift_List);   //IS-21-04-033 End of Shift Report
    COM_add_service("CRAS", "CRAS_Update_Crasdshift", REPLY, CRAS_Update_Crasdshift); //IS-21-04-033 End of Shift Report
	COM_add_service("CRAS", "CRAS_View_Crasdwntim_List", REPLY, CRAS_View_Crasdwntim_List);   //IS-21-04-033 End of Shift Report
    COM_add_service("CRAS", "CRAS_Update_Crasdwntim", REPLY, CRAS_Update_Crasdwntim); //IS-21-04-033 End of Shift Report

    COM_add_service("CRAS", "CRAS_View_equipment_work_log_List", REPLY, CRAS_View_equipment_work_log_List);   //IS-21-06-040 MES OI Request - Equipment Worklog °³¹ß
    COM_add_service("CRAS", "CRAS_Update_equipment_work_log", REPLY, CRAS_Update_equipment_work_log); //IS-21-06-040 MES OI Request - Equipment Worklog °³¹ß

	COM_add_service("CRAS", "CRAS_View_TABBER_CLEAN_List", REPLY, CRAS_View_TABBER_CLEAN_List);   //IS-21-11-028 Tabber Cleaning Schedule Management
    COM_add_service("CRAS", "CRAS_Update_TABBER_CLEAN", REPLY, CRAS_Update_TABBER_CLEAN); //IS-21-11-028 Tabber Cleaning Schedule Management

	COM_add_service("CRAS", "CRAS_Update_Tabber_Jig_Repair", REPLY, CRAS_Update_Tabber_Jig_Repair);
    COM_add_service("CRAS", "CRAS_View_Tabber_Jig_Repair", REPLY, CRAS_View_Tabber_Jig_Repair);
    COM_add_service("CRAS", "CRAS_View_Tabber_Jig_Repair_List", REPLY, CRAS_View_Tabber_Jig_Repair_List);

	/* ORD */
    COM_add_service("CORD", "CORD_View_Order_List_By_Line", REPLY, CORD_View_Order_List_By_Line);
    COM_add_service("CORD", "CORD_View_Current_Order_By_Line", REPLY, CORD_View_Current_Order_By_Line);
    COM_add_service("CORD", "CORD_Change_Current_Order", REPLY, CORD_Change_Current_Order);

	/* MDM */
    COM_add_service("CMDM", "CMDM_View_XLink_Data_List", REPLY, CMDM_View_XLink_Data_List);
    COM_add_service("CMDM", "CMDM_Update_XLink_Data_List", REPLY, CMDM_Update_XLink_Data_List);
    COM_add_service("CMDM", "CMDM_View_Reference_Sample_Data_List", REPLY, CMDM_View_Reference_Sample_Data_List);
    COM_add_service("CMDM", "CMDM_Update_Reference_Sample_Data_List", REPLY, CMDM_Update_Reference_Sample_Data_List);
    COM_add_service("CMDM", "CMDM_View_EVA_To_Glass_Data_List", REPLY, CMDM_View_EVA_To_Glass_Data_List);
    COM_add_service("CMDM", "CMDM_Update_EVA_To_Glass_Data_List", REPLY, CMDM_Update_EVA_To_Glass_Data_List);
    COM_add_service("CMDM", "CMDM_View_EVA_To_Backsheet_Data_List", REPLY, CMDM_View_EVA_To_Backsheet_Data_List);
    COM_add_service("CMDM", "CMDM_Update_EVA_To_Backsheet_Data_List", REPLY, CMDM_Update_EVA_To_Backsheet_Data_List);

	/* BAS */
    COM_add_service("CBAS", "CBAS_view_Module_grade_list", REPLY, CBAS_view_Module_grade_list);
	COM_add_service("CBAS", "CBAS_view_article_list", REPLY, CBAS_view_article_list);
	COM_add_service("CBAS", "CBAS_View_Data", REPLY,  CBAS_View_Data);
	COM_add_service("CBAS", "CBAS_View_Data_List", REPLY,  CBAS_View_Data_List);

	COM_add_service("CBAS", "CBAS_Update_CGCMTBLDAT", REPLY,  CBAS_Update_CGCMTBLDAT);
	COM_add_service("CBAS", "CBAS_View_CGCMTBLDAT", REPLY,  CBAS_View_CGCMTBLDAT);
	COM_add_service("CBAS", "CBAS_View_CGCMTBLDAT_List", REPLY,  CBAS_View_CGCMTBLDAT_List);

	/* RPT */	
	COM_add_service("CRPT", "CRPT_View_Fullcell_Cart_Label", REPLY, CRPT_View_Fullcell_Cart_Label);
	COM_add_service("CRPT", "CRPT_View_Halfcell_Cart_Label", REPLY, CRPT_View_Halfcell_Cart_Label);
	COM_add_service("CRPT", "CRPT_View_Productivity_By_Order", REPLY, CRPT_View_Productivity_By_Order);
	COM_add_service("CRPT", "CRPT_View_Productivity_By_Period", REPLY, CRPT_View_Productivity_By_Period);
	COM_add_service("CRPT", "CRPT_View_Manage_Fullcell_Cart_Label", REPLY, CRPT_View_Manage_Fullcell_Cart_Label);

	/* RCP */
    COM_add_service("CRCP", "CRCP_Update_Para_Version", REPLY, CRCP_Update_Para_Version);


	/* MMS */
	//-----------------------------------
	//[2023.10.25]이글 2/3의 Batch Job 운영을 위한 소스 Merge - start
	//-----------------------------------
	COM_add_service("CMMS", "CMMS_Update_Item", REPLY, CMMS_Update_Item);
	COM_add_service("CMMS", "CMMS_View_Item", REPLY, CMMS_View_Item);
	COM_add_service("CMMS", "CMMS_View_Item_List", REPLY, CMMS_View_Item_List);
	COM_add_service("CMMS", "CMMS_Update_Sample", REPLY, CMMS_Update_Sample);
	COM_add_service("CMMS", "CMMS_View_Sample", REPLY, CMMS_View_Sample);
	COM_add_service("CMMS", "CMMS_View_Sample_List", REPLY, CMMS_View_Sample_List);
	COM_add_service("CMMS", "CMMS_Update_Calibration_user", REPLY, CMMS_Update_Calibration_user);
	COM_add_service("CMMS", "CMMS_View_Calibration_user", REPLY, CMMS_View_Calibration_user);
	COM_add_service("CMMS", "CMMS_View_Calibration_user_List", REPLY, CMMS_View_Calibration_user_List);
	COM_add_service("CMMS", "CMMS_Update_Calibration_Institute", REPLY, CMMS_Update_Calibration_Institute);
	COM_add_service("CMMS", "CMMS_View_Calibration_Institute", REPLY, CMMS_View_Calibration_Institute);
	COM_add_service("CMMS", "CMMS_View_Calibration_Institute_List", REPLY, CMMS_View_Calibration_Institute_List);
	COM_add_service("CMMS", "CMMS_Update_Equipment", REPLY, CMMS_Update_Equipment);
	COM_add_service("CMMS", "CMMS_View_Equipment", REPLY, CMMS_View_Equipment);
	COM_add_service("CMMS", "CMMS_View_Equipment_List", REPLY, CMMS_View_Equipment_List);
	COM_add_service("CMMS", "CMMS_Update_Equipment_Item", REPLY, CMMS_Update_Equipment_Item);
	COM_add_service("CMMS", "CMMS_View_Equipment_Item", REPLY, CMMS_View_Equipment_Item);
	COM_add_service("CMMS", "CMMS_View_Equipment_Item_List", REPLY, CMMS_View_Equipment_Item_List);
	COM_add_service("CMMS", "CMMS_Update_Calibration_Plan", REPLY, CMMS_Update_Calibration_Plan);
	COM_add_service("CMMS", "CMMS_View_Calibration_Plan", REPLY, CMMS_View_Calibration_Plan);
	COM_add_service("CMMS", "CMMS_View_Calibration_Plan_List", REPLY, CMMS_View_Calibration_Plan_List);
	COM_add_service("CMMS", "CMMS_Update_Calibration_Result_Registration", REPLY, CMMS_Update_Calibration_Result_Registration);
	COM_add_service("CMMS", "CMMS_View_Calibration_Result_Registration", REPLY, CMMS_View_Calibration_Result_Registration);
	COM_add_service("CMMS", "CMMS_View_Calibration_Result_Registration_List", REPLY, CMMS_View_Calibration_Result_Registration_List);
	COM_add_service("CMMS", "CMMS_Update_Calibration_Equipment", REPLY, CMMS_Update_Calibration_Equipment);
	COM_add_service("CMMS", "CMMS_View_Calibration_Equipment", REPLY, CMMS_View_Calibration_Equipment);
	COM_add_service("CMMS", "CMMS_View_Calibration_Equipment_List", REPLY, CMMS_View_Calibration_Equipment_List);
	COM_add_service("CMMS", "CMMS_Update_Analysis_Plan", REPLY, CMMS_Update_Analysis_Plan);
	COM_add_service("CMMS", "CMMS_View_Analysis_Plan", REPLY, CMMS_View_Analysis_Plan);
	COM_add_service("CMMS", "CMMS_View_Analysis_Plan_List", REPLY, CMMS_View_Analysis_Plan_List);
	COM_add_service("CMMS", "CMMS_Update_Measuring_Result_Registration", REPLY, CMMS_Update_Measuring_Result_Registration);
	COM_add_service("CMMS", "CMMS_View_Measuring_Result_Registration", REPLY, CMMS_View_Measuring_Result_Registration);
	COM_add_service("CMMS", "CMMS_View_Measuring_Result_Registration_List", REPLY, CMMS_View_Measuring_Result_Registration_List);
	COM_add_service("CMMS", "CMMS_View_Analysis_Plan_Item_List", REPLY, CMMS_View_Analysis_Plan_Item_List);
	COM_add_service("CMMS", "CMMS_View_Equipment_Ledger_List", REPLY, CMMS_View_Equipment_Ledger_List);
	COM_add_service("CMMS", "CMMS_View_Analysis_Plan_Result_List", REPLY, CMMS_View_Analysis_Plan_Result_List);
	COM_add_service("CMMS", "CMMS_Update_Evaluation_Result_Registration", REPLY, CMMS_Update_Evaluation_Result_Registration);
	COM_add_service("CMMS", "CMMS_View_Evaluation_Result_Registration", REPLY, CMMS_View_Evaluation_Result_Registration);
	COM_add_service("CMMS", "CMMS_View_Evaluation_Result_Registration_List", REPLY, CMMS_View_Evaluation_Result_Registration_List);
	COM_add_service("CMMS", "CMMS_Raise_Alarm", REPLY, CMMS_Raise_Alarm);
	COM_add_service("CMMS", "CMMS_View_CMMS_Equip_List_List", REPLY, CMMS_View_CMMS_Equip_List_List);

	COM_add_service("CAMS", "CAMS_Update_Audit_Plan", REPLY, CAMS_Update_Audit_Plan);
    COM_add_service("CAMS", "CAMS_View_Audit_Plan", REPLY, CAMS_View_Audit_Plan);
    COM_add_service("CAMS", "CAMS_View_Audit_Plan_List", REPLY, CAMS_View_Audit_Plan_List);
    COM_add_service("CAMS", "CAMS_Update_Audit_Result_Item", REPLY, CAMS_Update_Audit_Result_Item);
    COM_add_service("CAMS", "CAMS_View_Audit_Result_Item", REPLY, CAMS_View_Audit_Result_Item);
    COM_add_service("CAMS", "CAMS_View_Audit_Result_Item_List", REPLY, CAMS_View_Audit_Result_Item_List);
    
    COM_add_service("CAMS", "CAMS_Update_Audit_Result", REPLY, CAMS_Update_Audit_Result);
    COM_add_service("CAMS", "CAMS_View_Audit_Result", REPLY, CAMS_View_Audit_Result);
    COM_add_service("CAMS", "CAMS_View_Audit_Result_List", REPLY, CAMS_View_Audit_Result_List);
	COM_add_service("CAMS", "CAMS_View_Cams_Join_List", REPLY, CAMS_View_Cams_Join_List);

    COM_add_service("CJCM", "CJCM_Update_Job_Change_Status", REPLY, CJCM_Update_Job_Change_Status);
    COM_add_service("CJCM", "CJCM_View_Job_Change_Status", REPLY, CJCM_View_Job_Change_Status);
    COM_add_service("CJCM", "CJCM_View_Job_Change_Status_List", REPLY, CJCM_View_Job_Change_Status_List);
    COM_add_service("CJCM", "CJCM_Update_Job_Change_Item", REPLY, CJCM_Update_Job_Change_Item);
    COM_add_service("CJCM", "CJCM_View_Job_Change_Item", REPLY, CJCM_View_Job_Change_Item);
    COM_add_service("CJCM", "CJCM_View_Job_Change_Item_List", REPLY, CJCM_View_Job_Change_Item_List);
	COM_add_service("CJCM", "CJCM_Update_Setup_Job_Change_Item", REPLY, CJCM_Update_Setup_Job_Change_Item);
    COM_add_service("CJCM", "CJCM_View_Setup_Job_Change_Item", REPLY, CJCM_View_Setup_Job_Change_Item);
    COM_add_service("CJCM", "CJCM_View_Setup_Job_Change_Item_List", REPLY, CJCM_View_Setup_Job_Change_Item_List);
    COM_add_service("CJCM", "CJCM_Create_Job_Change_Master", REPLY, CJCM_Create_Job_Change_Master);
    COM_add_service("CJCM", "CJCM_Insert_Job_Item_History", REPLY, CJCM_Insert_Job_Item_History);
    COM_add_service("CJCM", "CJCM_View_Order_List", REPLY, CJCM_View_Order_List);
	COM_add_service("CJCM", "CJCM_View_Cjcm_Join_List", REPLY, CJCM_View_Cjcm_Join_List);
	COM_add_service("CJCM", "CJCM_Check_Job_Change_Item", REPLY, CJCM_Check_Job_Change_Item);
    COM_add_service("CJCM", "CJCM_Raise_Alarm", REPLY, CJCM_Raise_Alarm);
	COM_add_service("CPSM", "CPSM_Update_Prod_Monitoring", REPLY, CPSM_Update_Prod_Monitoring);
    COM_add_service("CPSM", "CPSM_View_Prod_Monitoring", REPLY, CPSM_View_Prod_Monitoring);
    COM_add_service("CPSM", "CPSM_View_Prod_Monitoring_List", REPLY, CPSM_View_Prod_Monitoring_List);
    COM_add_service("CPSM", "CPSM_Update_Monitoring_Status", REPLY, CPSM_Update_Monitoring_Status);

    COM_add_service("CJCM", "CJCM_Close_Job_Change_Master", REPLY, CJCM_Close_Job_Change_Master);
    COM_add_service("CJCM", "CJCM_Copy_Job_Change_Master", REPLY, CJCM_Copy_Job_Change_Master);
	//-----------------------------------
	//[2023.10.25]이글 2/3의 Batch Job 운영을 위한 소스 Merge - end
	//-----------------------------------
}


