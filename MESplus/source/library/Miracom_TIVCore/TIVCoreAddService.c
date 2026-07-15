#include <MESCore_service.h>
#include "TIVCore_services.h"


void TIVCore_add_service()
{
    
    COM_add_service("TIV", "TIV_IQC_Lot", REPLY, TIV_IQC_Lot);
    COM_add_service("TIV", "TIV_Inspection_Lot", REPLY, TIV_Inspection_Lot);    
    

    COM_add_service("TIV", "TIV_Transfer_Lot", REPLY, TIV_Transfer_Lot);
    COM_add_service("TIV", "TIV_Transfer_Lot_Multi", REPLY, TIV_Transfer_Lot_Multi);
    //COM_add_service("TIV", "TIV_Out_Lot", REPLY, TIV_Out_Lot);
    COM_add_service("TIV", "TIV_Defect_Lot", REPLY, TIV_Defect_Lot);


    //COM_add_service("TIV", "TIV_Assy_Lot", REPLY, TIV_Assy_Lot);
    //COM_add_service("TIV", "TIV_Disassy_Lot", REPLY, TIV_Disassy_Lot);

    /*COM_add_service("TIV", "TIV_Update_Material", REPLY, TIV_Update_Material);
    COM_add_service("TIV", "TIV_Update_Operation", REPLY, TIV_Update_Operation);*/
	COM_add_service("TIV", "TIV_Update_Location", REPLY, TIV_Update_Location);

	COM_add_service("TIV", "TIV_View_Inv_Operation", REPLY, TIV_View_Inv_Operation);
	COM_add_service("TIV", "TIV_View_Inv_Operation_List", REPLY, TIV_View_Inv_Operation_List);
    COM_add_service("TIV", "TIV_View_Lot", REPLY, TIV_View_Lot);
	COM_add_service("TIV", "TIV_View_Lot_Data", REPLY, TIV_View_Lot_Data);
    COM_add_service("TIV", "TIV_View_Lot_History", REPLY, TIV_View_Lot_History);
    COM_add_service("TIV", "TIV_View_Transfer", REPLY, TIV_View_Transfer);
    //COM_add_service("TIV", "TIV_View_Inspection", REPLY, TIV_View_Inspection);    
    COM_add_service("TIV", "TIV_View_Transfer_Detail", REPLY, TIV_View_Transfer_Detail);
    //COM_add_service("TIV", "TIV_View_Inspection_Detail", REPLY, TIV_View_Inspection_Detail);
    COM_add_service("TIV", "TIV_View_Operation_List", REPLY, TIV_View_Operation_List);
    //COM_add_service("TIV", "TIV_View_Erp_Order_Master_List", REPLY, TIV_View_Erp_Order_Master_List);    
	//COM_add_service("TIV", "TIV_View_Erp_Order_Detail_List", REPLY, TIV_View_Erp_Order_Detail_List);    
    COM_add_service("TIV", "TIV_View_Transfer_List", REPLY, TIV_View_Transfer_List);
    //COM_add_service("TIV", "TIV_View_Inspection_List", REPLY, TIV_View_Inspection_List);    
    COM_add_service("TIV", "TIV_View_Transfer_Detail_List", REPLY, TIV_View_Transfer_Detail_List);
    //COM_add_service("TIV", "TIV_View_Inspection_Detail_List", REPLY, TIV_View_Inspection_Detail_List);
    COM_add_service("TIV", "TIV_View_Oper", REPLY, TIV_View_Oper);
    COM_add_service("TIV", "TIV_View_Material", REPLY, TIV_View_Material);
    COM_add_service("TIV", "TIV_View_Material_List", REPLY, TIV_View_Material_List);

    COM_add_service("TIV", "TIV_Hold_Lot", REPLY, TIV_Hold_Lot);
    COM_add_service("TIV", "TIV_Multi_Hold_Lot", REPLY, TIV_Multi_Hold_Lot);

    COM_add_service("TIV", "TIV_Release_Lot", REPLY, TIV_Release_Lot);
    COM_add_service("TIV", "TIV_Multi_Release_Lot", REPLY, TIV_Release_Lot);

    COM_add_service("TIV", "TIV_Split_Lot", REPLY, TIV_Split_Lot);
    COM_add_service("TIV", "TIV_Merge_Lot", REPLY, TIV_Merge_Lot);
    COM_add_service("TIV", "TIV_Loss_Lot", REPLY, TIV_Loss_Lot);

    COM_add_service("TIV", "TIV_Adapt_Lot", REPLY, TIV_Adapt_Lot);

    //COM_add_service("TIV", "TIV_View_Workorder", REPLY, TIV_View_Workorder);
    //COM_add_service("TIV", "TIV_View_Workorder_List", REPLY, TIV_View_Workorder_List);
    //COM_add_service("TIV", "TIV_View_Workorder_Detail", REPLY, TIV_View_Workorder_Detail);
    //COM_add_service("TIV", "TIV_View_Workorder_Detail_List", REPLY, TIV_View_Workorder_Detail_List);
	COM_add_service("TIV", "TIV_View_Spare_Part_List", REPLY, TIV_View_Spare_Part_List);
    COM_add_service("TIV", "TIV_Change_CMF", REPLY, TIV_Change_CMF);
	COM_add_service("TIV", "TIV_CV_Lot", REPLY, TIV_CV_Lot);
	COM_add_service("TIV", "TIV_Consume_Lot", REPLY, TIV_Consume_Lot);
	COM_add_service("TIV", "TIV_Consume_Lot_Multi", REPLY, TIV_Consume_Lot_Multi);
	COM_add_service("TIV", "TIV_Deconsume_Lot", REPLY, TIV_Deconsume_Lot);
	COM_add_service("TIV", "TIV_Create_Material_Lot", REPLY, TIV_Create_Material_Lot);
	COM_add_service("TIV", "TIV_View_Lot_List", REPLY, TIV_View_Lot_List);
	COM_add_service("TIV", "TIV_Transfer_Request", REPLY, TIV_Transfer_Request);
	COM_add_service("TIV", "TIV_Transfer_Confirm", REPLY, TIV_Transfer_Confirm);
	

    COM_add_service("TIV", "TIV_Update_Inv_Material", REPLY, TIV_Update_Inv_Material);
    COM_add_service("TIV", "TIV_View_Inv_Material", REPLY, TIV_View_Inv_Material);
    COM_add_service("TIV", "TIV_View_Inv_Material_List", REPLY, TIV_View_Inv_Material_List);
    COM_add_service("TIV", "TIV_View_Inv_Operation", REPLY, TIV_View_Inv_Operation);
    COM_add_service("TIV", "TIV_View_Inv_Operation_List", REPLY, TIV_View_Inv_Operation_List);
    COM_add_service("TIV", "TIV_View_Lot_History_List", REPLY, TIV_View_Lot_History_List);
    COM_add_service("TIV", "TIV_View_Lot_List_Detail", REPLY, TIV_View_Lot_List_Detail);
    COM_add_service("TIV", "TIV_View_Material_List_By_Bomset", REPLY, TIV_View_Material_List_By_Bomset);
    COM_add_service("TIV", "TIV_View_Material_Version_List", REPLY, TIV_View_Material_Version_List);
    COM_add_service("TIV", "TIV_View_Transfer_History", REPLY, TIV_View_Transfer_History);
	COM_add_service("TIV", "TIV_Multi_Split_Lot", REPLY, TIV_Multi_Split_Lot);
	
	COM_add_service("TIV", "TIV_Update_Inv_Operation", REPLY, TIV_Update_Inv_Operation);

	COM_add_service("TIV", "TIV_View_Lot_History_N", REPLY, TIV_View_Lot_History_N);
	COM_add_service("TIV", "TIV_View_Lot_NEW", REPLY, TIV_View_Lot_NEW);

	COM_add_service("TIV", "TIV_Generate_Lot_ID", REPLY, TIV_Generate_Lot_ID);

    COM_add_service("TIV", "TIV_View_Material_Inout_List", REPLY, TIV_View_Material_Inout_List);
	COM_add_service("TIV", "TIV_Assign_Lot_List_To_TRS", REPLY, TIV_Assign_Lot_List_To_TRS);
	COM_add_service("TIV", "TIV_View_TRS_Assigned_Lot", REPLY, TIV_View_TRS_Assigned_Lot);
	COM_add_service("TIV", "TIV_Adapt_Lot_Multi", REPLY, TIV_Adapt_Lot_Multi);
	COM_add_service("TIV", "TIV_Update_Material_List_For_TRS", REPLY, TIV_Update_Material_List_For_TRS);
	COM_add_service("TIV", "TIV_View_Material_List_For_TRS", REPLY, TIV_View_Material_List_For_TRS);
	COM_add_service("TIV", "TIV_Update_Ship_Factory", REPLY, TIV_Update_Ship_Factory);
	COM_add_service("TIV", "TIV_View_Ship_Factory_List", REPLY, TIV_View_Ship_Factory_List);
	COM_add_service("TIV", "TIV_View_Ship_Factory", REPLY, TIV_View_Ship_Factory);
	COM_add_service("TIV", "TIV_Ship_Lot_Multi", REPLY, TIV_Ship_Lot_Multi);
	COM_add_service("TIV", "TIV_Ship_Lot", REPLY, TIV_Ship_Lot);
	COM_add_service("TIV", "TIV_Inspection_Lot_Multi", REPLY, TIV_Inspection_Lot_Multi);
	COM_add_service("TIV", "TIV_View_Inv_Lot_List_Ext", REPLY, TIV_View_Inv_Lot_List_Ext);
	COM_add_service("TIV", "TIV_View_Lot_Ext", REPLY, TIV_View_Lot_Ext);

	COM_add_service("TIV", "TIV_Multi_Merge_Lot", REPLY, TIV_Multi_Merge_Lot);
 
}


