
#ifndef _CUS_COMMON_SERVICE_H
#define _CUS_COMMON_SERVICE_H

#include <SLCCore_common.h>

extern void CUS_common_add_service();

/* ERP Interface *///
//DllExport int CUS_Interface_Mcs_Cartunload(TRSNode *in_node, TRSNode *out_node);		//25.08.25 RTD 반복 잡 생성 로직 기술 검토 및 개발 요청의 건
DllExport int CUS_Interface_Download_Stock_Transfer(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Cell_Grbatch(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Material_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Cell_Move(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Production_Routing(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Production_Bom(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Production_Order(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Material_Master(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Vendor_Master(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Article_Master(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Packing_Master(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Costcenter_Master(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Power_Range(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Module_Location(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Bom_Function(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Packinginfo_Send(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Cell_Block(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Additional_Master(TRSNode *in_node, TRSNode *out_node);
DllExport int CUS_Interface_Download_Terminate_Info(TRSNode *in_node, TRSNode *out_node);  //VOC-479 22.06.07
DllExport int CUS_Interface_Download_Material_Master_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Packing_Master_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Power_Range_Gerp(TRSNode *in_node, TRSNode *out_node); //[ERP Project]
DllExport int CUS_Interface_Download_Production_Routing_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Production_Rework_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Vendor_Master_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Article_Master_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Qm103_Oqc_Confirm(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Qm106_Oqc_Request(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Packinginfo_Send_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
DllExport int CUS_Interface_Download_Stock_Transfer_Gerp(TRSNode *in_node, TRSNode *out_node); //[ERP Project]
DllExport int CUS_Interface_Download_Inventory_By_Grade_Info_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]

DllExport int CWIP_upload_erp_function_testdata_creation(TRSNode *in_node, TRSNode *out_node);

/* BAS */
DllExport int CBAS_View_Large_Data_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_View_Shift_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_View_Query_Result(TRSNode *in_node, TRSNode *out_node);
DllExport int CBAS_Send_Mail(TRSNode *in_node, TRSNode *out_node);

/* WIP */
DllExport int CWIP_Create_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Start_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_End_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Layup_Start_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Layup_End_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Cleaving_End_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Cleaving_Start_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Tabber_Start_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Tabber_End_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Trimming_End_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Lot_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Multi_Lot_List(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_Split_Copy_Lot(TRSNode *in_node, TRSNode *out_node);
DllExport int CWIP_View_Lot_List_Terminate(TRSNode* in_node, TRSNode* out_node);		//25.03.21 Module Terminate Service
DllExport int CWIP_tabber_inspection_cell(TRSNode *in_node);	//25.04.23 하프셀 계산 로직

/* POP */
DllExport int CPOP_Update_Label_Print_History(TRSNode *in_node, TRSNode *out_node);
DllExport int CPOP_View_Label_Print_History(TRSNode *in_node, TRSNode *out_node);

/* SUM */
DllExport int CSUM_BatchProcess_Transaction(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Transaction_E1(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Transaction_E23(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_ReSummary_ExecuteByPeriod(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Event(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Event_E1(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Event_E2(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Resource_Event(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Resource_Cus_Event(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Data_Maint(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Summary_Resource(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Summary_ShiftChange(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Spc_Collect_Data(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Summary_LossRate(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_PMPP_Check(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Tool_Use_Check(TRSNode *in_node, TRSNode *out_node);
DllExport int CSUM_BatchProcess_Transaction_Gerp(TRSNode *in_node, TRSNode *out_node);	//[ERP Project]
#endif /* _CUST_SAMPLE_SERVICE_H */
