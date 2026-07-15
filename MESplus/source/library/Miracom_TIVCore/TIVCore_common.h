/*******************************************************************************

    System      : MESplus
    Module      : INVCore
    File Name   : INVCore_common.h
    Description : external function prototype definition of INVCore Library

    MES Version : 5.2.0

    Function List
        - 

    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2012/7/26  Patrick         Create

    Copyright(C) 1998-2012 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#ifndef _TIVCORE_COMMON_H
#define _TIVCORE_COMMON_H


#include <MESCore_common.h>
#include "TIVCore_defines.h"
#include "TIV_common.h"
#include "CUS_common.h"


/****************************************************************************************************************/
/*    INV Common Function Prototypes                                                                            */
/****************************************************************************************************************/

extern int Fill_TIV_Lot_STSHIS_For_Update(char *sLot, TRSNode *in_node, TRSNode *out_node, 
											struct MTIVLOTSTS_TAG *MTIVLOTSTS, struct MTIVLOTHIS_TAG *MTIVLOTHIS);

extern int TIV_Get_INVLOTSTS_Info(char *s_msg_code, struct MTIVLOTSTS_TAG *MTIVLOTSTS, char *in_factory, char *strLotID, 
									 TRSNode *out_node, char *s_user_id, char c_not_check_privilege_flag);

extern int TIV_Get_INVLOTHIS_Info(char *s_msg_code, struct MTIVLOTHIS_TAG *MTIVLOTHIS, char *strLotID,
									 int iHistSeq, TRSNode *out_node);

extern int TIV_get_mat_ext(char *s_msg_code,
                            TRSNode *out_node,
                            char *s_factory, 
                            char *s_material,
                            int i_material_ver,
                            struct MWIPMATDEF_TAG *MWIPMATDEF,
                            struct MTIVMATDEF_TAG *MTIVMATDEF);

extern int TIV_get_oper_ext(char *s_msg_code,
                            TRSNode *out_node,
                            char *s_factory, 
                            char *s_oper,                            
                            struct MWIPOPRDEF_TAG *MWIPOPRDEF,
                            struct MTIVOPRDEF_TAG *MTIVOPRDEF);

extern int TIV_update_insert_lot_status_history(char *s_msg_code,
                                                TRSNode *in_node,
                                                TRSNode *out_node,
                                                char *s_sys_time,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                                struct MTIVLOTHIS_TAG *MTIVLOTHIS);

extern int TIV_update_insert_lot_status_history_2(char *s_msg_code,
                                                TRSNode *in_node,
                                                TRSNode *out_node,
                                                char *s_sys_time,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                                struct MTIVLOTHIS_TAG *MTIVLOTHIS);

extern int TIV_update_insert_lot_status_history_transfer(char *s_msg_code,
                                                TRSNode *in_node,
                                                TRSNode *out_node,
                                                char *s_sys_time,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                                struct MTIVLOTHIS_TAG *MTIVLOTHIS);

extern int TIV_update_insert_lot_status_history_For_Release_Hold(char *s_msg_code,
                                                TRSNode *in_node,
                                                TRSNode *out_node,                                                
                                                char *s_sys_time,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                                struct MTIVLOTHIS_TAG *MTIVLOTHIS);

extern int TIV_update_insert_lot_status_history_for_in_lot(char *s_msg_code,
                                                TRSNode *in_node,
                                                TRSNode *out_node,                                                
                                                char *s_sys_time,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                                                struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                                                struct MTIVLOTHIS_TAG *MTIVLOTHIS);

extern int TIV_fill_detail_message(TRSNode *out_node,
                             struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                             struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD);

extern int TIV_Update_IQC_Master(char *s_msg_code,
                                 char IQC_Flag,
                                 TRSNode *in_node, 
                                 TRSNode *out_node);

extern int TIV_Update_TRS_Master(char *s_msg_code,
                                 char c_step,
								 char *s_trs_no,
                                 TRSNode *in_node, 
                                 TRSNode *out_node);

extern int TIV_Update_TRS_Detail(char *s_msg_code,
								  char c_step,
								  char *s_trs_no,								  
								  char *s_mat_id,								  
								  char *s_lot_id,								  
									TRSNode *in_node, 
									TRSNode *out_node);

extern int TIV_Update_TRS_Detail_List(char *s_msg_code,
								  char c_step,
								  char *s_trs_no,								  
									TRSNode *in_node, 
									TRSNode *out_node);

extern int TIV_Update_TRS_Detail_By_Complete(char *s_msg_code,
								  char c_step,
								  char *s_trs_no,								  
									TRSNode *in_node, 
									TRSNode *out_node);

//extern int TIV_lot_tran_validation(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
//                            struct MWIPFACDEF_TAG *MWIPFACDEF,
//                            struct MTIVMATDEF_TAG *MTIVMATDEF,
//                            struct MTIVOPRDEF_TAG *MTIVOPRDEF);

extern int TIV_lot_tran_validation(char *s_msg_code, 
                            TRSNode *out_node,
                            TRSNode *in_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
                            struct MWIPFACDEF_TAG *MWIPFACDEF,
                            struct MWIPMATDEF_TAG *MWIPMATDEF,
                            struct MTIVOPRDEF_TAG *MTIVOPRDEF);

extern int TIV_IQC_Auto_Confirm(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_lot_tran_validation_wip(char *s_msg_code, 
                               TRSNode *out_node,
                               TRSNode *in_node,
                               struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
                               struct MWIPFACDEF_TAG *MWIPFACDEF,
                               struct MWIPMATDEF_TAG *MWIPMATDEF,
                               struct MWIPOPRDEF_TAG *MWIPOPRDEF);

extern int TIV_update_assy_info(char *s_msg_code,
                         TRSNode *in_node,
                         TRSNode *out_node);



extern int TIV_Lot_Fill_InTag_Cmf(char *s_msg_code,
                         TRSNode *in_node,
                         TRSNode *out_node);

extern int TIV_Lot_Reset_InTag_Cmf(char *s_msg_code,
                         TRSNode *in_node,
                         TRSNode *out_node);

extern int TIV_Get_Last_Active_Lot_Grp_Seq(char *s_msg_code,
                                           TRSNode *in_node,
                                            TRSNode *out_node);

//extern int TIV_View_Material_Inout_List(char *s_msg_code,
//                                           TRSNode *in_node,
//                                            TRSNode *out_node);



/****************************************************************************************************************/
/*    Service Function Prototypes                                                                               */
/****************************************************************************************************************/

extern int TIV_CONSUME(char *s_msg_code,
                      TRSNode *in_node, 
                      TRSNode *out_node);

extern int TIV_CONV_TO_INV(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_CONV_TO_LOT(char *s_msg_code,
                          TRSNode *in_node, 
                          TRSNode *out_node);

extern int TIV_DELETE_INVENTORY_HISTORY(char *s_msg_code,
                                          TRSNode *in_node, 
                                          TRSNode *out_node);

extern int TIV_IN_INVENTORY(char *s_msg_code,
                              TRSNode *in_node, 
                              TRSNode *out_node);

extern int TIV_IN_INVENTORY_SERIAL(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_OUT_INVENTORY(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_OUT_INVENTORY_SERIAL(char *s_msg_code,
                                      TRSNode *in_node, 
                                      TRSNode *out_node);

extern int TIV_SCRAP(char *s_msg_code,
                      TRSNode *in_node, 
                      TRSNode *out_node);


extern int TIV_SCRAP_SERIAL(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_TRANSFER_INVENTORY(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_TRANSFER_INVENTORY_SERIAL(char *s_msg_code,
                                          TRSNode *in_node, 
                                          TRSNode *out_node);

extern int TIV_UPDATE_SERIAL_LIST(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_VIEW_INVENTORY_HISTORY(char *s_msg_code,
                                      TRSNode *in_node, 
                                      TRSNode *out_node);

extern int TIV_VIEW_INVENTORY_INFO(char *s_msg_code,
                                   TRSNode *in_node, 
                                   TRSNode *out_node);

extern int TIV_VIEW_INVENTORY_INFO_SERIAL(char *s_msg_code,
                                          TRSNode *in_node, 
                                          TRSNode *out_node);

//자재 관리 관련 추가
extern int TIV_INSPECTION_LOT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_IQC_LOT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_IQC_CONFIRM(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_IQC_REQUEST(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


extern int TIV_DEFECT_LOT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);


extern int TIV_TRANSFER_LOT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_TRANSFER_LOT_MULTI(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

//extern int TIV_OUT_LOT(char *s_msg_code,
//                                TRSNode *in_node, 
//                                TRSNode *out_node);

extern int TIV_UPDATE_ERP_ORDER(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

//extern int TIV_ASSY_LOT(char *s_msg_code,
//                        TRSNode *in_node, 
//                        TRSNode *out_node);

//extern int TIV_DISASSY_LOT(char *s_msg_code,
//                           TRSNode *in_node, 
//                           TRSNode *out_node);


extern int TIV_UPDATE_INV_MATERIAL(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_UPDATE_OPERATION(char *s_msg_code,
                                  TRSNode *in_node, 
                                  TRSNode *out_node);

extern int TIV_UPDATE_LOCATION(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node);

extern int TIV_VIEW_INV_MATERIAL(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node);

extern int TIV_VIEW_INV_MATERIAL_LIST(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node);


extern int TIV_VIEW_INV_OPERATION(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node);


extern int TIV_VIEW_INV_OPERATION_LIST(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node);


extern int TIV_VIEW_LOT(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node);

extern int TIV_VIEW_LOT_DATA(char *s_msg_code,
                            TRSNode *in_node, 
                            TRSNode *out_node);

extern int TIV_VIEW_LOT_HISTORY(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_VIEW_ERP_ORDER_MASTER(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);

extern int TIV_VIEW_TRANSFER(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

//extern int TIV_VIEW_INSPECTION(char *s_msg_code,
//                                    TRSNode *in_node, 
//                                    TRSNode *out_node);

extern int TIV_VIEW_TRANSFER_DETAIL(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);

//extern int TIV_VIEW_INSPECTION_DETAIL(char *s_msg_code,
//                                            TRSNode *in_node, 
//                                            TRSNode *out_node);



extern int TIV_VIEW_OPERATION_LIST(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

//extern int TIV_VIEW_ERP_ORDER_MASTER_LIST(char *s_msg_code,
//                                            TRSNode *in_node, 
//                                            TRSNode *out_node);
//extern int TIV_VIEW_ERP_ORDER_DETAIL_LIST(char *s_msg_code,
//                                            TRSNode *in_node, 
//                                            TRSNode *out_node);

extern int TIV_VIEW_TRANSFER_LIST(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);

//extern int TIV_VIEW_INSPECTION_LIST(char *s_msg_code,
//                                        TRSNode *in_node, 
//                                        TRSNode *out_node);

extern int TIV_VIEW_TRANSFER_DETAIL_LIST(char *s_msg_code,
                                                TRSNode *in_node, 
                                                TRSNode *out_node);

//extern int TIV_VIEW_INSPECTION_DETAIL_LIST(char *s_msg_code,
//                                                TRSNode *in_node, 
//                                                TRSNode *out_node);

extern int TIV_VIEW_OPER(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_VIEW_MATERIAL(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_VIEW_MATERIAL_LIST(char *s_msg_code,
                                        TRSNode *in_node, 
                                        TRSNode *out_node);

extern int TIV_HOLD_LOT(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_MULTI_HOLD_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_RELEASE_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_MULTI_RELEASE_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_SPLIT_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_MERGE_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_LOSS_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_ADAPT_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);
extern int TIV_VIEW_INV_LOT_LIST_EXT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

//extern int TIV_VIEW_WORKORDER(char *s_msg_code,
//                                    TRSNode *in_node, 
//                                    TRSNode *out_node);

//extern int TIV_VIEW_WORKORDER_LIST(char *s_msg_code,
//                                    TRSNode *in_node, 
//                                    TRSNode *out_node);

//extern int TIV_VIEW_WORKORDER_DETAIL(char *s_msg_code,
//                                    TRSNode *in_node, 
//                                    TRSNode *out_node);

//extern int TIV_VIEW_WORKORDER_DETAIL_LIST(char *s_msg_code,
//                                    TRSNode *in_node, 
//                                    TRSNode *out_node);

extern int TIV_VIEW_SPARE_PART_LIST(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_CHANGE_CMF(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_CV_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_CONSUME_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_CONSUME_LOT_MULTI(char *s_msg_code,
                                TRSNode *in_node, 
                                TRSNode *out_node);

extern int TIV_DECONSUME_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_CREATE_MATERIAL_LOT(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_VIEW_LOT_LIST(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_VIEW_LOT_HISTORY_LIST(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_TRANSFER_REQUEST(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_TRANSFER_CONFIRM(char *s_msg_code,
                                    TRSNode *in_node, 
                                    TRSNode *out_node);

extern int TIV_INSPECTION_LOT_MULTI(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node);

extern int TIV_get_mat_ext_for_inv(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *material,
                             int mat_ver,
                             struct MWIPMATDEF_TAG *MWIPMATDEF);

//extern int TIV_Tran_View_Attribute_Value(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS);

//extern int TIV_View_Attribute_Value_For_Split(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS);

//extern int TIV_View_Attribute_Value(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS,
//							int istep);

extern int TIV_update_insert_lot_status_history_for_adapt(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node,
                            char *s_sys_time_t,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS_OLD,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS,
                            struct MTIVLOTHIS_TAG *MTIVLOTHIS);

extern int TIV_get_oper_ext_for_inv(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *operation,                           
                             struct MTIVOPRDEF_TAG *MTIVOPRDEF);

extern int TIV_Lot_Fill_InTag_Cmf_For_IQC(char *s_msg_code,
                            TRSNode *in_node,
                            TRSNode *out_node);

extern int TIV_get_mat_ext_for_inventory(char *s_msg_code,
                             TRSNode *out_node,
                             char *factory, 
                             char *material,
                             int mat_ver,
                             struct MWIPMATDEF_TAG *MWIPMATDEF);
//
//extern int TIV_View_Attribute_List(char *s_msg_code, 
//                            TRSNode *out_node,
//                            TRSNode *in_node,
//                            struct MATRNAMSTS_TAG *MATRNAMSTS);

extern int TIV_lot_tran_validation_for_inv(char *s_msg_code, 
                            TRSNode *out_node,
                            TRSNode *in_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
                            struct MWIPFACDEF_TAG *MWIPFACDEF,
                            struct MWIPMATDEF_TAG *MWIPMATDEF,
                            struct MTIVOPRDEF_TAG *MTIVOPRDEF);

extern int Fill_TIV_Lot_Info(TRSNode *in_node, TRSNode *out_node, struct MTIVLOTSTS_TAG *MTIVLOTSTS);
extern int Fill_TIV_Lot_Info_By_Lot(char *sLot, TRSNode *in_node, TRSNode *out_node, struct MTIVLOTSTS_TAG *MTIVLOTSTS);

extern int TIV_VIEW_LOT_LIST_DETAIL(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node);

extern int TIV_VIEW_MATERIAL_LIST_BY_BOMSET(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node);

extern int TIV_VIEW_MATERIAL_VERSION_LIST(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node);

extern int TIV_VIEW_TRANSFER_HISTORY(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node);

extern int TIV_MULTI_SPLIT_LOT(char *s_msg_code,
                                    TRSNode *in_node,
                                    TRSNode *out_node);

extern int TIV_Check_Aging_Time(char *s_msg_code, 
									TRSNode *out_node,
									TRSNode *in_node,
									struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
									struct MATRNAMSTS_TAG *MATRNAMSTS, 
									char *s_sys_time_t);

extern int TIV_Check_QTime(char *s_msg_code, 
								TRSNode *out_node,
								TRSNode *in_node,
								struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
								struct MATRNAMSTS_TAG *MATRNAMSTS, 
								char *s_sys_time_t);

extern int TIV_Check_Expire_Date(char *s_msg_code, 
                            TRSNode *out_node,
                            TRSNode *in_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS,
							char *s_sys_time_t);

extern int TIV_Check_Usage_Count(char *s_msg_code, 
                            TRSNode *out_node,
                            TRSNode *in_node,
							struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
							struct MATRNAMSTS_TAG *MATRNAMSTS, 
							char *s_sys_time_t);

extern int TIV_Check_Cycle_Count(char *s_msg_code, 
                            TRSNode *out_node,
                            TRSNode *in_node,
                            struct MTIVLOTSTS_TAG *MTIVLOTSTS, 
							struct MATRNAMSTS_TAG *MATRNAMSTS, 
							char *s_sys_time_t);

extern int TIV_Check_Factory(char *s_msg_code, 
						char *s_global_option,
						char *s_factory);

//extern int TIV_Check_Material_Validation(char *s_msg_code, 
//						char *s_table_name,
//						struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
//						struct MTAPCPOSTS_TAG *MTAPCPOSTS,
//						struct MTIVMATDEF_TAG *MTIVMATDEF);

extern int TIV_Check_Material_Validation(char *s_msg_code, 
						char *s_table_name,
						struct MWIPLOTSTS_TAG *MWIPLOTSTS, 
						struct MTIVMATDEF_TAG *MTIVMATDEF);

extern int TIV_UPDATE_INV_OPERATION(char *s_msg_code,
                              TRSNode *in_node,
                              TRSNode *out_node);

extern int TIV_UPDATE_INV_MATERIAL(char *s_msg_code,
                             TRSNode *in_node, 
                             TRSNode *out_node);

extern int TIV_GENERATE_LOT_ID(char *s_msg_code,
                             TRSNode *in_node, 
                             TRSNode *out_node);

extern int TIV_VIEW_LOT_HISTORY_N(char *s_msg_code,
                             TRSNode *in_node, 
                             TRSNode *out_node);
extern int TIV_VIEW_LOT_NEW(char *s_msg_code,
                             TRSNode *in_node, 
                             TRSNode *out_node);



extern int TIV_Create_Inventory_Adjust_Info(char *s_msg_code,
	                         TRSNode *in_node,
                             TRSNode *out_node);

extern int TIV_Create_Material_Usage_Info(char *s_msg_code,
	                         TRSNode *in_node,
                             TRSNode *out_node);

extern int TIV_check_backtime(char *s_msg_code, TRSNode *in_node, TRSNode *out_node, char *s_last_tran_time_t);

extern int TIV_Get_Lot_Count_In_Other_Oper(char *s_msg_code, 
	                    char *s_factory,
						char *s_lot_id,
						char *s_oper);

extern int TIV_UPDATE_MATERIAL_LIST_FOR_TRS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);

extern int TIV_SHIP_LOT(char *s_msg_code,
                       TRSNode *in_node, 
                       TRSNode *out_node);

extern int TIV_VIEW_MATERIAL_LIST_FOR_TRS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_ASSIGN_LOT_LIST_TO_TRS(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_VIEW_MATERIAL_INOUT_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_VIEW_TRS_ASSIGNED_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_VIEW_SHIP_FACTORY_LIST(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_VIEW_SHIP_FACTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_UPDATE_SHIP_FACTORY(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_SHIP_LOT_MULTI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_ADAPT_LOT_MULTI(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_VIEW_LOT_EXT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
extern int TIV_MULTI_MERGE_LOT(char *s_msg_code, TRSNode *in_node, TRSNode *out_node);
 

#endif /* _INVCORE_COMMON_H */

