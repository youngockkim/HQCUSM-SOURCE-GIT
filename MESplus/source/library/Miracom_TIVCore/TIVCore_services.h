
#ifndef _TIVCORE_SERVICES_H
#define _TIVCORE_SERVICES_H


//자재 관련 추가
extern int TIV_IQC_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Inspection_Lot(TRSNode *in_node, TRSNode *out_node);

extern int TIV_View_Inv_Operation(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Inv_Operation_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_NEW(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_Data(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_History(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_History_N(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Transfer(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Inspection(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Transfer_Detail(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Inspection_Detail(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Operation_List(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Erp_Order_Master_List(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Erp_Order_Detail_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Transfer_List(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Inspection_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Transfer_Detail_List(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Inspection_Detail_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Oper(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Material(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Material_List(TRSNode *in_node, TRSNode *out_node);
 

extern int TIV_Transfer_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Transfer_Lot_Multi(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_Out_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Defect_Lot(TRSNode *in_node, TRSNode *out_node);

//extern int TIV_Assy_Lot(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_Disassy_Lot(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_Update_Material(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_Update_Operation(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Update_Location(TRSNode *in_node, TRSNode *out_node);

extern int TIV_Hold_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Release_Lot(TRSNode *in_node, TRSNode *out_node);

extern int TIV_Multi_Hold_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Multi_Release_Lot(TRSNode *in_node, TRSNode *out_node);

extern int TIV_Split_Lot(TRSNode *in_node, TRSNode *out_node);

extern int TIV_Merge_Lot(TRSNode *in_node, TRSNode *out_node);

extern int TIV_Loss_Lot(TRSNode *in_node, TRSNode *out_node);

extern int TIV_Adapt_Lot(TRSNode *in_node, TRSNode *out_node);

//extern int TIV_View_Workorder(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Workorder_List(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Workorder_Detail(TRSNode *in_node, TRSNode *out_node);
//extern int TIV_View_Workorder_Detail_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Spare_Part_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Change_CMF(TRSNode *in_node, TRSNode *out_node);
extern int TIV_CV_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Consume_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Consume_Lot_Multi(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Deconsume_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Create_Material_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Transfer_Request(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Transfer_Confirm(TRSNode *in_node, TRSNode *out_node);

extern int TIV_View_Inv_Material(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Inv_Material_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Inv_Operation(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Inv_Operation_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Material_Version_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Update_Inv_Material(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Update_Inv_Operation(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_History_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_List_Detail(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Material_List_By_Bomset(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Transfer_History(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Multi_Split_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Generate_Lot_ID(TRSNode *in_node, TRSNode *out_node);

extern int TIV_View_Material_Inout_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Assign_Lot_List_To_TRS(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_TRS_Assigned_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Adapt_Lot_Multi(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Update_Material_List_For_TRS(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Material_List_For_TRS(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Update_Ship_Factory(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Ship_Factory_List(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Ship_Factory(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Ship_Lot(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Ship_Lot_Multi(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Inspection_Lot_Multi(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Inv_Lot_List_Ext(TRSNode *in_node, TRSNode *out_node);
extern int TIV_View_Lot_Ext(TRSNode *in_node, TRSNode *out_node);
extern int TIV_Multi_Merge_Lot(TRSNode *in_node, TRSNode *out_node);


#endif /* _INVCORE_SERVICES_H */

