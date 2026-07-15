#include <MESCore_service.h>
#include "CUS_common_service.h"


void CUS_common_add_service()
{   
    /* ERP Interface */
	COM_add_service("CINF", "CUS_Interface_Download_Stock_Transfer", REPLY, CUS_Interface_Download_Stock_Transfer);
	COM_add_service("CINF", "CUS_Interface_Download_Cell_Grbatch", REPLY, CUS_Interface_Download_Cell_Grbatch);
	COM_add_service("CINF", "CUS_Interface_Download_Material_Lot", REPLY, CUS_Interface_Download_Material_Lot);
	COM_add_service("CINF", "CUS_Interface_Download_Cell_Move", REPLY, CUS_Interface_Download_Cell_Move);
	COM_add_service("CINF", "CUS_Interface_Download_Production_Routing", REPLY, CUS_Interface_Download_Production_Routing);
	COM_add_service("CINF", "CUS_Interface_Download_Production_Bom", REPLY, CUS_Interface_Download_Production_Bom);
	COM_add_service("CINF", "CUS_Interface_Download_Production_Order", REPLY, CUS_Interface_Download_Production_Order);
	COM_add_service("CINF", "CUS_Interface_Download_Material_Master", REPLY, CUS_Interface_Download_Material_Master);
	COM_add_service("CINF", "CUS_Interface_Download_Vendor_Master", REPLY, CUS_Interface_Download_Vendor_Master);
	COM_add_service("CINF", "CUS_Interface_Download_Article_Master", REPLY, CUS_Interface_Download_Article_Master);
	COM_add_service("CINF", "CUS_Interface_Download_Packing_Master", REPLY, CUS_Interface_Download_Packing_Master);
	COM_add_service("CINF", "CUS_Interface_Download_Power_Range", REPLY, CUS_Interface_Download_Power_Range);
	COM_add_service("CINF", "CUS_Interface_Download_Costcenter_Master", REPLY, CUS_Interface_Download_Costcenter_Master);	
	COM_add_service("CINF", "CUS_Interface_Download_Module_Location", REPLY, CUS_Interface_Download_Module_Location);
	COM_add_service("CINF", "CUS_Interface_Download_Bom_Function", REPLY, CUS_Interface_Download_Bom_Function);
	COM_add_service("CINF", "CUS_Interface_Download_Packinginfo_Send", REPLY, CUS_Interface_Download_Packinginfo_Send);
	COM_add_service("CINF", "CUS_Interface_Download_Cell_Block", REPLY, CUS_Interface_Download_Cell_Block);
	COM_add_service("CINF", "CUS_Interface_Download_Additional_Master", REPLY, CUS_Interface_Download_Additional_Master);

	COM_add_service("CINF", "CUS_Interface_Download_Terminate_Info", REPLY, CUS_Interface_Download_Terminate_Info);  //VOC-479 22.06.07
	COM_add_service("CINF", "CUS_Interface_Download_Material_Master_Gerp", REPLY, CUS_Interface_Download_Material_Master_Gerp);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Packing_Master_Gerp", REPLY, CUS_Interface_Download_Packing_Master_Gerp); //[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Power_Range_Gerp", REPLY, CUS_Interface_Download_Power_Range_Gerp);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Production_Routing_Gerp", REPLY, CUS_Interface_Download_Production_Routing_Gerp);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Production_Rework_Gerp", REPLY, CUS_Interface_Download_Production_Rework_Gerp);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Vendor_Master_Gerp", REPLY, CUS_Interface_Download_Vendor_Master_Gerp);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Article_Master_Gerp", REPLY, CUS_Interface_Download_Article_Master_Gerp);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Qm103_Oqc_Confirm", REPLY, CUS_Interface_Download_Qm103_Oqc_Confirm);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Qm106_Oqc_Request", REPLY, CUS_Interface_Download_Qm106_Oqc_Request);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Packinginfo_Send_Gerp", REPLY, CUS_Interface_Download_Packinginfo_Send_Gerp);	//[ERP Project]
	COM_add_service("CINF", "CUS_Interface_Download_Stock_Transfer_Gerp", REPLY, CUS_Interface_Download_Stock_Transfer_Gerp); //[ERP Project]
	//COM_add_service("CINF", "CUS_Interface_Mcs_Cartunload", REPLY, CUS_Interface_Mcs_Cartunload); //25.08.25 RTD 반복 잡 생성 로직 기술 검토 및 개발 요청의 건


	//ERP UPLOAD TEST FUNCTION
	COM_add_service("CWIP", "CWIP_upload_erp_function_testdata_creation", REPLY, CWIP_upload_erp_function_testdata_creation);

    /* BAS */
    COM_add_service("CBAS", "CBAS_View_Large_Data_List", REPLY, CBAS_View_Large_Data_List);
    COM_add_service("CBAS", "CBAS_View_Shift_List", REPLY, CBAS_View_Shift_List);
	COM_add_service("CBAS", "CBAS_View_Query_Result", REPLY, CBAS_View_Query_Result);
	COM_add_service("CBAS", "CBAS_Send_Mail", REPLY, CBAS_Send_Mail);

    /* WIP */
    COM_add_service("CWIP", "CWIP_Create_Lot", REPLY, CWIP_Create_Lot);
    COM_add_service("CWIP", "CWIP_Start_Lot", REPLY, CWIP_Start_Lot);
    COM_add_service("CWIP", "CWIP_End_Lot", REPLY, CWIP_End_Lot);
	COM_add_service("CWIP", "CWIP_Layup_Start_Lot", REPLY, CWIP_Layup_Start_Lot);
	COM_add_service("CWIP", "CWIP_Layup_End_Lot", REPLY, CWIP_Layup_End_Lot);	
	COM_add_service("CWIP", "CWIP_Cleaving_Start_Lot", REPLY, CWIP_Cleaving_Start_Lot);
	COM_add_service("CWIP", "CWIP_Cleaving_End_Lot", REPLY, CWIP_Cleaving_End_Lot);
	COM_add_service("CWIP", "CWIP_Tabber_End_Lot", REPLY, CWIP_Tabber_End_Lot);
	COM_add_service("CWIP", "CWIP_Tabber_Start_Lot", REPLY, CWIP_Tabber_Start_Lot);
	COM_add_service("CWIP", "CWIP_Trimming_End_Lot", REPLY, CWIP_Trimming_End_Lot);
    COM_add_service("CWIP", "CWIP_View_Lot_List", REPLY, CWIP_View_Lot_List);
	COM_add_service("CWIP", "CWIP_View_Multi_Lot_List", REPLY, CWIP_View_Multi_Lot_List);
	COM_add_service("CWIP", "CWIP_Split_Copy_Lot", REPLY, CWIP_Split_Copy_Lot);
	COM_add_service("CWIP", "CWIP_View_Lot_List_Terminate", REPLY, CWIP_View_Lot_List_Terminate); //25.03.21 Module Terminate Service

    /* POP */
    COM_add_service("CPOP", "CPOP_Update_Label_Print_History", REPLY, CPOP_Update_Label_Print_History);
    COM_add_service("CPOP", "CPOP_View_Label_Print_History", REPLY, CPOP_View_Label_Print_History);
    

	/* SUM */
	COM_add_service("CSUM", "CSUM_BatchProcess_Transaction", NO_REPLY, CSUM_BatchProcess_Transaction);
	COM_add_service("CSUM", "CSUM_BatchProcess_Transaction_E1", NO_REPLY, CSUM_BatchProcess_Transaction_E1);
	COM_add_service("CSUM", "CSUM_BatchProcess_Transaction_E23", NO_REPLY, CSUM_BatchProcess_Transaction_E23);
	COM_add_service("CSUM", "CSUM_ReSummary_ExecuteByPeriod", NO_REPLY, CSUM_ReSummary_ExecuteByPeriod);

	COM_add_service("CSUM", "CSUM_BatchProcess_Event", NO_REPLY, CSUM_BatchProcess_Event);
	COM_add_service("CSUM", "CSUM_BatchProcess_Event_E1", NO_REPLY, CSUM_BatchProcess_Event_E1);
	COM_add_service("CSUM", "CSUM_BatchProcess_Event_E2", NO_REPLY, CSUM_BatchProcess_Event_E2);
	COM_add_service("CSUM", "CSUM_BatchProcess_Resource_Event", NO_REPLY, CSUM_BatchProcess_Resource_Event);
	COM_add_service("CSUM", "CSUM_BatchProcess_Resource_Cus_Event", NO_REPLY, CSUM_BatchProcess_Resource_Cus_Event);
	COM_add_service("CSUM", "CSUM_BatchProcess_Data_Maint", NO_REPLY, CSUM_BatchProcess_Data_Maint);
	COM_add_service("CSUM", "CSUM_BatchProcess_Summary_Resource", NO_REPLY, CSUM_BatchProcess_Summary_Resource);
	COM_add_service("CSUM", "CSUM_BatchProcess_Summary_ShiftChange", NO_REPLY, CSUM_BatchProcess_Summary_ShiftChange);
	COM_add_service("CSUM", "CSUM_BatchProcess_Spc_Collect_Data",NO_REPLY , CSUM_BatchProcess_Spc_Collect_Data);
	COM_add_service("CSUM", "CSUM_BatchProcess_Summary_LossRate",NO_REPLY , CSUM_BatchProcess_Summary_LossRate);
	COM_add_service("CSUM", "CSUM_BatchProcess_PMPP_Check",NO_REPLY , CSUM_BatchProcess_PMPP_Check);
	COM_add_service("CSUM", "CSUM_BatchProcess_Tool_Use_Check",NO_REPLY , CSUM_BatchProcess_Tool_Use_Check);	
	COM_add_service("CSUM", "CSUM_BatchProcess_Transaction_Gerp", NO_REPLY, CSUM_BatchProcess_Transaction_Gerp); //[ERP Project]
    COM_add_service("CINF", "CUS_Interface_Download_Inventory_By_Grade_Info_Gerp", REPLY, CUS_Interface_Download_Inventory_By_Grade_Info_Gerp);
}


